using System.Security.AccessControl;
using System.Security.Principal;
using Vanara.PInvoke;
using static Vanara.PInvoke.AclUI;
using static Vanara.PInvoke.AdvApi32;
using static Vanara.PInvoke.Authz;
using static Vanara.PInvoke.Macros;

namespace Vanara.Security.AccessControl;

internal class SecurityEventArg(SafePSECURITY_DESCRIPTOR sd, SECURITY_INFORMATION parts) : EventArgs
{
	public SECURITY_INFORMATION Parts { get; } = parts;
	public SafePSECURITY_DESCRIPTOR SecurityDesciptor { get; } = sd;
}

/// <summary>Internal implementation of a number of COM interfaces needed for interaction with the Windows ACL Editor.</summary>
internal class SecurityInfoImpl(SI_OBJECT_INFO_Flags flags, string objectName, string fullName, string? serverName = null, string? pageTitle = null) :
	ISecurityInformation, ISecurityInformation3, ISecurityInformation4, ISecurityObjectTypeInfo, IEffectivePermission, IEffectivePermission2
{
	internal SI_OBJECT_INFO objectInfo = new(flags, objectName, serverName ?? Environment.MachineName, pageTitle);
	private SI_OBJECT_INFO_Flags currentElevation = 0;
	private IAccessControlEditorDialogProvider? prov;

	public event EventHandler<SecurityEventArg>? OnSetSecurity;

	public SafePSECURITY_DESCRIPTOR SecurityDescriptor { get; set; } = SafePSECURITY_DESCRIPTOR.Null;

	HRESULT IEffectivePermission.GetEffectivePermission(in Guid pguidObjectType, PSID pUserSid, string? pszServerName, PSECURITY_DESCRIPTOR pSecDesc,
		out OBJECT_TYPE_LIST[]? ppObjectTypeList, out uint pcObjectTypeListLength, out ACCESS_MASK[]? ppGrantedAccessList, out uint pcGrantedAccessListLength)
	{
		System.Diagnostics.Debug.WriteLine($"GetEffectivePermission: {pguidObjectType}, {pszServerName}");
		ppObjectTypeList = null; ppGrantedAccessList = null; pcObjectTypeListLength = pcGrantedAccessListLength = 0;
		if (prov is null) return HRESULT.E_NOINTERFACE;
		if (pguidObjectType == Guid.Empty)
		{
			ppGrantedAccessList = prov.GetEffectivePermission(pUserSid, pszServerName, pSecDesc);
			pcGrantedAccessListLength = (uint)ppGrantedAccessList.Length;
			ppObjectTypeList = [OBJECT_TYPE_LIST.Self];
			pcObjectTypeListLength = (uint)ppObjectTypeList.Length;
		}
		else
		{
			var hr = prov.GetEffectivePermission(pguidObjectType, pUserSid, pszServerName, pSecDesc, out ppObjectTypeList, out ppGrantedAccessList);
			pcGrantedAccessListLength = (uint)(ppGrantedAccessList?.Length ?? 0);
			pcObjectTypeListLength = (uint)(ppObjectTypeList?.Length ?? 0);
			if (hr.Failed) return hr;
		}
		return HRESULT.S_OK;
	}

	HRESULT ISecurityInformation.GetAccessRights(GuidPtr guidObject, SI_OBJECT_INFO_Flags dwFlags, out SI_ACCESS[] access, ref uint accessCount, out uint defaultAccess)
	{
		System.Diagnostics.Debug.WriteLine($"GetAccessRight: {guidObject}, {dwFlags}");
		access = []; defaultAccess = 0;
		if (prov is null) return HRESULT.E_NOINTERFACE;
		prov.GetAccessListInfo(dwFlags, out access, out defaultAccess);
		accessCount = (uint)access.Length;
		return HRESULT.S_OK;
	}

	HRESULT ISecurityInformation.GetInheritTypes(out SI_INHERIT_TYPE[] inheritTypes, out uint inheritTypesCount)
	{
		System.Diagnostics.Debug.WriteLine("GetInheritTypes");
		inheritTypes = []; inheritTypesCount = 0;
		if (prov is null) return HRESULT.E_NOINTERFACE;
		inheritTypes = prov.GetInheritTypes();
		inheritTypesCount = (uint)inheritTypes.Length;
		return HRESULT.S_OK;
	}

	HRESULT ISecurityInformation.GetObjectInformation(ref SI_OBJECT_INFO objInfo)
	{
		System.Diagnostics.Debug.WriteLine($"GetObjectInformation: {objInfo.dwFlags} {currentElevation}");
		objInfo = objectInfo;
		objInfo.dwFlags &= ~currentElevation;
		return HRESULT.S_OK;
	}

	HRESULT ISecurityInformation.GetSecurity(SECURITY_INFORMATION requestInformation, out PSECURITY_DESCRIPTOR ppSecurityDescriptor, bool fDefault)
	{
		System.Diagnostics.Debug.WriteLine($"GetSecurity: {requestInformation}{(fDefault ? " (Def)" : "")}");
		ppSecurityDescriptor = default;
		if (prov is null) return HRESULT.E_NOINTERFACE;
		PSECURITY_DESCRIPTOR sd = fDefault ? prov.GetDefaultSecurity() : SecurityDescriptor;
		SafePSECURITY_DESCRIPTOR ret = sd.GetPrivateObjectSecurity(requestInformation);
		System.Diagnostics.Debug.WriteLine($"GetSecurity={ret.ToSddl(requestInformation) ?? "null"} <- {sd.ToSddl(requestInformation) ?? "null"}");
		ppSecurityDescriptor = ret.TakeOwnership();
		return HRESULT.S_OK;
	}

	HRESULT ISecurityInformation.MapGeneric(GuidPtr guidObjectType, ref AceFlags AceFlags, ref ACCESS_MASK Mask)
	{
		if (prov is null) return HRESULT.E_NOINTERFACE;
		var stMask = Mask;
		var gm = prov.GetGenericMapping(AceFlags);
		MapGenericMask(ref Mask, gm);
		//if (Mask != gm.GenericAll)
		//	Mask &= ~(uint)FileSystemRights.Synchronize;
		System.Diagnostics.Debug.WriteLine($"MapGeneric: {guidObjectType}, {AceFlags}, 0x{stMask:X}->0x{Mask:X}");
		return HRESULT.S_OK;
	}

	HRESULT ISecurityInformation.PropertySheetPageCallback(HWND hwnd, PropertySheetCallbackMessage uMsg, SI_PAGE_TYPE uPage)
	{
		System.Diagnostics.Debug.WriteLine($"PropertySheetPageCallback: {hwnd}, {uMsg}, {uPage}");
		if (prov is null) return HRESULT.E_NOINTERFACE;
		return prov.PropertySheetPageCallback(hwnd, uMsg, uPage);
	}

	HRESULT ISecurityInformation.SetSecurity(SECURITY_INFORMATION requestInformation, PSECURITY_DESCRIPTOR sd)
	{
		OnSetSecurity?.Invoke(this, new SecurityEventArg(new SafePSECURITY_DESCRIPTOR((IntPtr)sd, false), requestInformation));
		return HRESULT.S_OK;
	}

	HRESULT ISecurityInformation3.GetFullResourceName(out string name)
	{
		name = fullName;
		return HRESULT.S_OK;
	}

	HRESULT ISecurityInformation3.OpenElevatedEditor(HWND hWnd, SI_PAGE_TYPE uPage)
	{
		var pgType = (SI_PAGE_TYPE)LOWORD((uint)uPage);
		var pgActv = (SI_PAGE_ACTIVATED)HIWORD((uint)uPage);
		System.Diagnostics.Debug.WriteLine($"OpenElevatedEditor: {pgType} - {pgActv}");
		var lastElev = currentElevation;
		switch (pgActv)
		{
			case SI_PAGE_ACTIVATED.SI_SHOW_DEFAULT:
				currentElevation |= SI_OBJECT_INFO_Flags.SI_PERMS_ELEVATION_REQUIRED | SI_OBJECT_INFO_Flags.SI_VIEW_ONLY;
				break;

			case SI_PAGE_ACTIVATED.SI_SHOW_PERM_ACTIVATED:
				currentElevation |= SI_OBJECT_INFO_Flags.SI_PERMS_ELEVATION_REQUIRED | SI_OBJECT_INFO_Flags.SI_VIEW_ONLY;
				pgType = SI_PAGE_TYPE.SI_PAGE_ADVPERM;
				break;

			case SI_PAGE_ACTIVATED.SI_SHOW_AUDIT_ACTIVATED:
				currentElevation |= SI_OBJECT_INFO_Flags.SI_AUDITS_ELEVATION_REQUIRED;
				pgType = SI_PAGE_TYPE.SI_PAGE_AUDIT;
				break;

			case SI_PAGE_ACTIVATED.SI_SHOW_OWNER_ACTIVATED:
				currentElevation |= SI_OBJECT_INFO_Flags.SI_OWNER_ELEVATION_REQUIRED;
				pgType = SI_PAGE_TYPE.SI_PAGE_OWNER;
				break;

			case SI_PAGE_ACTIVATED.SI_SHOW_EFFECTIVE_ACTIVATED:
			case SI_PAGE_ACTIVATED.SI_SHOW_SHARE_ACTIVATED:
			case SI_PAGE_ACTIVATED.SI_SHOW_CENTRAL_POLICY_ACTIVATED:
				break;
		}
		ShowDialog(hWnd, pgType, pgActv);
		currentElevation = lastElev;
		return HRESULT.S_OK;
	}

	public HRESULT GetSecondarySecurity(out SECURITY_OBJECT[] securityObjects, out uint securityObjectCount)
	{
		System.Diagnostics.Debug.WriteLine("GetSecondarySecurity:");
		securityObjects = [];
		securityObjectCount = 0;
		return HRESULT.S_OK;
	}

	HRESULT ISecurityObjectTypeInfo.GetInheritSource(SECURITY_INFORMATION si, PACL pAcl, out INHERITED_FROM[] ppInheritArray)
	{
		System.Diagnostics.Debug.WriteLine($"GetInheritSource: {si}");
		ppInheritArray = [];
		if (prov is null) return HRESULT.E_NOINTERFACE;
		ppInheritArray = prov.GetInheritSource(fullName, objectInfo.pszServerName, objectInfo.IsContainer, (uint)si, pAcl);
		return HRESULT.S_OK;
	}

	public void SetProvider(IAccessControlEditorDialogProvider provider) => prov = provider;

	public RawSecurityDescriptor? ShowDialog(HWND hWnd, SI_PAGE_TYPE pageType = SI_PAGE_TYPE.SI_PAGE_PERM, SI_PAGE_ACTIVATED pageAct = SI_PAGE_ACTIVATED.SI_SHOW_DEFAULT)
	{
		System.Diagnostics.Debug.WriteLine($"ShowDialog: {pageType} {pageAct}");
		SecurityEventArg? sd = null;
		void fn(object? o, SecurityEventArg e) => sd = e;
		try
		{
			OnSetSecurity += fn;
			if (Environment.OSVersion.Version.Major == 5 || pageType == SI_PAGE_TYPE.SI_PAGE_PERM && pageAct == SI_PAGE_ACTIVATED.SI_SHOW_DEFAULT)
			{
				Win32Error.ThrowLastErrorIfFalse(EditSecurity(hWnd, this));
			}
			else
			{
				EditSecurityAdvanced(hWnd, this, pageType, pageAct).ThrowIfFailed();
			}
			if (sd != null)
			{
				var sddl = sd.SecurityDesciptor.ToSddl(sd.Parts);
				if (!string.IsNullOrEmpty(sddl))
				{
					System.Diagnostics.Debug.WriteLine($"ShowDialog: Return: {sddl}");
					return new RawSecurityDescriptor(sddl);
				}
			}
		}
		finally
		{
			OnSetSecurity -= fn;
		}
		System.Diagnostics.Debug.WriteLine("ShowDialog: Return: null");
		return null;
	}

	public HRESULT ComputeEffectivePermissionWithSecondarySecurity(PSID pSid, PSID pDeviceSid, string? pszServerName, SECURITY_OBJECT[] pSecurityObjects,
		uint dwSecurityObjectCount, in TOKEN_GROUPS pUserGroups, AUTHZ_SID_OPERATION[]? pAuthzUserGroupsOperations, in TOKEN_GROUPS pDeviceGroups,
		AUTHZ_SID_OPERATION[]? pAuthzDeviceGroupsOperations, in AUTHZ_SECURITY_ATTRIBUTES_INFORMATION pAuthzUserClaims,
		AUTHZ_SECURITY_ATTRIBUTE_OPERATION[]? pAuthzUserClaimsOperations, in AUTHZ_SECURITY_ATTRIBUTES_INFORMATION pAuthzDeviceClaims,
		AUTHZ_SECURITY_ATTRIBUTE_OPERATION[]? pAuthzDeviceClaimsOperations, EFFPERM_RESULT_LIST[] pEffpermResultLists)
	{
		System.Diagnostics.Debug.WriteLine($"ComputeEffectivePermissionWithSecondarySecurity({dwSecurityObjectCount}):{new SecurityIdentifier((IntPtr)pSid).Value};{new SecurityIdentifier((IntPtr)pDeviceSid).Value}");
		if (dwSecurityObjectCount != 1)
			return HRESULT.E_FAIL;
		if (pSecurityObjects[0].Id != (uint)SECURITY_OBJECT_ID.SECURITY_OBJECT_ID_OBJECT_SD)
			return HRESULT.E_FAIL;
		if (pSid.IsNull)
			return HRESULT.E_INVALIDARG;
		if (prov is null) return HRESULT.E_NOINTERFACE;

		if (!AuthzInitializeResourceManager(AuthzResourceManagerFlags.AUTHZ_RM_FLAG_NO_AUDIT, null, null, null, prov.ToString(), out var hAuthzResourceManager))
			return HRESULT.S_OK;

		var identifier = new LUID();
		SafeAUTHZ_CLIENT_CONTEXT_HANDLE? hAuthzCompoundContext = null;
		if (!AuthzInitializeContextFromSid(AuthzContextFlags.DEFAULT, pSid, hAuthzResourceManager, IntPtr.Zero, identifier, IntPtr.Zero, out var hAuthzUserContext))
			return HRESULT.S_OK;

		pAuthzDeviceGroupsOperations ??= [];
		pAuthzUserClaimsOperations ??= [];
		pAuthzDeviceClaimsOperations ??= [];
		if (!pDeviceSid.IsNull)
		{
			if (AuthzInitializeContextFromSid(AuthzContextFlags.DEFAULT, pDeviceSid, hAuthzResourceManager, IntPtr.Zero, identifier, IntPtr.Zero, out var hAuthzDeviceContext))
				if (AuthzInitializeCompoundContext(hAuthzUserContext, hAuthzDeviceContext, out hAuthzCompoundContext))
					if (pAuthzDeviceClaims.Version != 0)
						AuthzModifyClaims(hAuthzCompoundContext, AUTHZ_CONTEXT_INFORMATION_CLASS.AuthzContextInfoDeviceClaims, pAuthzDeviceClaimsOperations, pAuthzDeviceClaims);
		}
		else
		{
			hAuthzCompoundContext = hAuthzUserContext;
		}

		if (hAuthzCompoundContext is null)
			return HRESULT.S_OK;

		if (pAuthzUserClaims.Version != 0)
			if (!AuthzModifyClaims(hAuthzCompoundContext, AUTHZ_CONTEXT_INFORMATION_CLASS.AuthzContextInfoUserClaims, pAuthzUserClaimsOperations, pAuthzUserClaims))
				return HRESULT.S_OK;

		if (pDeviceGroups.GroupCount != 0)
			if (!AuthzModifySids(hAuthzCompoundContext, AUTHZ_CONTEXT_INFORMATION_CLASS.AuthzContextInfoDeviceSids, pAuthzDeviceGroupsOperations, pDeviceGroups))
				return HRESULT.S_OK;

		if (pUserGroups.GroupCount != 0 && pAuthzUserGroupsOperations != null)
			if (!AuthzModifySids(hAuthzCompoundContext, AUTHZ_CONTEXT_INFORMATION_CLASS.AuthzContextInfoGroupsSids, pAuthzUserGroupsOperations, pUserGroups))
				return HRESULT.S_OK;

		var request = new AUTHZ_ACCESS_REQUEST(ACCESS_MASK.MAXIMUM_ALLOWED);
		var sd = new SafePSECURITY_DESCRIPTOR(pSecurityObjects[0].pData, false);
		var reply = new AUTHZ_ACCESS_REPLY(1);
		if (!AuthzAccessCheck(AuthzAccessCheckFlags.NONE, hAuthzCompoundContext, request, default, sd, null, 0, reply, out _))
			return HRESULT.S_OK;

		pEffpermResultLists[0].fEvaluated = true;
		pEffpermResultLists[0].pGrantedAccessList = reply.GrantedAccessMaskValues;
		pEffpermResultLists[0].pObjectTypeList = [OBJECT_TYPE_LIST.Self];
		pEffpermResultLists[0].cObjectTypeListLength = 1;

		return HRESULT.S_OK;
	}
}