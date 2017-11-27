using System;
using System.Runtime.InteropServices;
using System.Security.AccessControl;
using System.Security.Principal;
using Vanara.PInvoke;
using Vanara.InteropServices;
using static Vanara.Security.AccessControl.AccessControlHelper;
using static Vanara.PInvoke.AclUI;
using static Vanara.PInvoke.AdvApi32;
using static Vanara.PInvoke.Authz;
using static Vanara.PInvoke.Macros;

namespace Vanara.Security.AccessControl
{
	internal class SecurityEventArg : EventArgs
	{
		public SecurityEventArg(IntPtr sd, SECURITY_INFORMATION parts)
		{
			Parts = parts;
			SecurityDesciptor = sd;
		}
		public SECURITY_INFORMATION Parts { get; }
		public IntPtr SecurityDesciptor { get; }
	}

	internal class SecurityInfoImpl : ISecurityInformation, ISecurityInformation3, ISecurityObjectTypeInfo, IEffectivePermission, ISecurityInformation4, IEffectivePermission2
	{
		internal SI_OBJECT_INFO objectInfo;
		private SI_OBJECT_INFO_Flags currentElevation;
		private readonly string fullObjectName;
		private IAccessControlEditorDialogProvider prov;
		private SafeByteArray pSD;

		public SecurityInfoImpl(SI_OBJECT_INFO_Flags flags, string objectName, string fullName, string serverName = null, string pageTitle = null)
		{
			objectInfo = new SI_OBJECT_INFO(flags, objectName, serverName, pageTitle);
			currentElevation = 0; // flags & (SI_OBJECT_INFO_Flags.OwnerElevationRequired | SI_OBJECT_INFO_Flags.AuditElevationRequired | SI_OBJECT_INFO_Flags.PermsElevationRequired);
			fullObjectName = fullName;
		}

		public event EventHandler<SecurityEventArg> OnSetSecurity;

		public byte[] SecurityDescriptor
		{
			get => pSD.ToArray(); set => pSD = new SafeByteArray(value);
		}

		void IEffectivePermission.GetEffectivePermission(Guid pguidObjectType, PSID pUserSid, string pszServerName, IntPtr pSecDesc, out OBJECT_TYPE_LIST[] ppObjectTypeList, out uint pcObjectTypeListLength, out uint[] ppGrantedAccessList, out uint pcGrantedAccessListLength)
		{
			System.Diagnostics.Debug.WriteLine($"GetEffectivePermission: {pguidObjectType}, {pszServerName}");
			if (pguidObjectType == Guid.Empty)
			{
				ppGrantedAccessList = prov.GetEffectivePermission(pUserSid, pszServerName, pSecDesc);
				pcGrantedAccessListLength = (uint)ppGrantedAccessList.Length;
				ppObjectTypeList = new [] { OBJECT_TYPE_LIST.Self };
				pcObjectTypeListLength = (uint)ppObjectTypeList.Length;
			}
			else
			{
				ppGrantedAccessList = prov.GetEffectivePermission(pguidObjectType, pUserSid, pszServerName, pSecDesc, out ppObjectTypeList);
				pcGrantedAccessListLength = (uint)ppGrantedAccessList.Length;
				pcObjectTypeListLength = (uint)ppObjectTypeList.Length;
			}
		}

		void ISecurityInformation.GetAccessRights(Guid guidObject, int dwFlags, out SI_ACCESS[] access, ref uint accessCount, out uint defaultAccess)
		{
			System.Diagnostics.Debug.WriteLine($"GetAccessRight: {guidObject}, {(SI_OBJECT_INFO_Flags)dwFlags}");
			uint defAcc;
			SI_ACCESS[] ari;
			prov.GetAccessListInfo((SI_OBJECT_INFO_Flags)dwFlags, out ari, out defAcc);
			defaultAccess = defAcc;
			access = ari;
			accessCount = (uint)access.Length;
		}

		void ISecurityInformation.GetInheritTypes(out SI_INHERIT_TYPE[] inheritTypes, out uint inheritTypesCount)
		{
			System.Diagnostics.Debug.WriteLine("GetInheritTypes");
			inheritTypes = prov.GetInheritTypes();
			inheritTypesCount = (uint)inheritTypes.Length;
		}

		void ISecurityInformation.GetObjectInformation(ref SI_OBJECT_INFO objInfo)
		{
			System.Diagnostics.Debug.WriteLine($"GetObjectInformation: {objInfo.dwFlags} {currentElevation}");
			objInfo = objectInfo;
			objInfo.dwFlags &= ~(currentElevation);
		}

		void ISecurityInformation.GetSecurity(SECURITY_INFORMATION requestInformation, out IntPtr ppSecurityDescriptor, bool fDefault)
		{
			System.Diagnostics.Debug.WriteLine($"GetSecurity: {requestInformation}{(fDefault ? " (Def)" : "")}");
			ppSecurityDescriptor = GetPrivateObjectSecurity(fDefault ? prov.GetDefaultSecurity() : (IntPtr)pSD, requestInformation);
			System.Diagnostics.Debug.WriteLine(
				$"GetSecurity={SecurityDescriptorPtrToSdll(ppSecurityDescriptor, requestInformation) ?? "null"} <- {SecurityDescriptorPtrToSdll((IntPtr)pSD, requestInformation) ?? "null"}");
		}

		void ISecurityInformation.MapGeneric(Guid guidObjectType, ref sbyte AceFlags, ref uint Mask)
		{
			var stMask = Mask;
			var gm = prov.GetGenericMapping(AceFlags);
			MapGenericMask(ref Mask, ref gm);
			//if (Mask != gm.GenericAll)
			//	Mask &= ~(uint)FileSystemRights.Synchronize;
			System.Diagnostics.Debug.WriteLine($"MapGeneric: {guidObjectType}, {(AceFlags)AceFlags}, 0x{stMask:X}->0x{Mask:X}");
		}

		void ISecurityInformation.PropertySheetPageCallback(IntPtr hwnd, PropertySheetCallbackMessage uMsg, SI_PAGE_TYPE uPage)
		{
			System.Diagnostics.Debug.WriteLine($"PropertySheetPageCallback: {hwnd}, {uMsg}, {uPage}");
			prov.PropertySheetPageCallback(hwnd, uMsg, uPage);
		}

		void ISecurityInformation.SetSecurity(SECURITY_INFORMATION requestInformation, IntPtr sd)
		{
			OnSetSecurity?.Invoke(this, new SecurityEventArg(sd, requestInformation));
		}

		string ISecurityInformation3.GetFullResourceName() => fullObjectName;

		void ISecurityInformation3.OpenElevatedEditor(IntPtr hWnd, SI_PAGE_TYPE uPage)
		{
			var pgType = (SI_PAGE_TYPE)LOWORD((uint)uPage);
			var pgActv = (SI_PAGE_ACTIVATED)HIWORD((uint)uPage);
			System.Diagnostics.Debug.WriteLine($"OpenElevatedEditor: {pgType} - {pgActv}");
			var lastElev = currentElevation;
			switch (pgActv)
			{
				case SI_PAGE_ACTIVATED.SI_SHOW_DEFAULT:
					currentElevation |= (SI_OBJECT_INFO_Flags.SI_PERMS_ELEVATION_REQUIRED | SI_OBJECT_INFO_Flags.SI_VIEW_ONLY);
					break;

				case SI_PAGE_ACTIVATED.SI_SHOW_PERM_ACTIVATED:
					currentElevation |= (SI_OBJECT_INFO_Flags.SI_PERMS_ELEVATION_REQUIRED | SI_OBJECT_INFO_Flags.SI_VIEW_ONLY);
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
					break;

				case SI_PAGE_ACTIVATED.SI_SHOW_SHARE_ACTIVATED:
					break;

				case SI_PAGE_ACTIVATED.SI_SHOW_CENTRAL_POLICY_ACTIVATED:
					break;
			}
			ShowDialog(hWnd, pgType, pgActv);
			currentElevation = lastElev;
		}

		public void GetSecondarySecurity(out SECURITY_OBJECT[] securityObjects, out uint securityObjectCount)
		{
			System.Diagnostics.Debug.WriteLine("GetSecondarySecurity:");
			securityObjects = new SECURITY_OBJECT[0];
			securityObjectCount = 0;
		}

		void ISecurityObjectTypeInfo.GetInheritSource(int si, IntPtr pAcl, out INHERITED_FROM[] ppInheritArray)
		{
			System.Diagnostics.Debug.WriteLine($"GetInheritSource: {(SECURITY_INFORMATION)si}");
			ppInheritArray = prov.GetInheritSource(fullObjectName, objectInfo.pszServerName, objectInfo.IsContainer, (uint)si, pAcl);
		}

		public void SetProvider(IAccessControlEditorDialogProvider provider)
		{
			prov = provider;
		}

		public RawSecurityDescriptor ShowDialog(IntPtr hWnd, SI_PAGE_TYPE pageType = SI_PAGE_TYPE.SI_PAGE_PERM, SI_PAGE_ACTIVATED pageAct = SI_PAGE_ACTIVATED.SI_SHOW_DEFAULT)
		{
			System.Diagnostics.Debug.WriteLine($"ShowDialog: {pageType} {pageAct}");
			SecurityEventArg sd = null;
			EventHandler<SecurityEventArg> fn = (o, e) => sd = e;
			try
			{
				OnSetSecurity += fn;
				if (Environment.OSVersion.Version.Major == 5 || (pageType == SI_PAGE_TYPE.SI_PAGE_PERM && pageAct == SI_PAGE_ACTIVATED.SI_SHOW_DEFAULT))
				{
					if (!EditSecurity(hWnd, this))
						Marshal.ThrowExceptionForHR(Marshal.GetHRForLastWin32Error());
				}
				else
				{
					EditSecurityAdvanced(hWnd, this, pageType, pageAct);
				}
				if (sd != null)
				{
					var sddl = SecurityDescriptorPtrToSdll(sd.SecurityDesciptor, sd.Parts);
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

		public uint ComputeEffectivePermissionWithSecondarySecurity(PSID pSid, PSID pDeviceSid, string pszServerName, SECURITY_OBJECT[] pSecurityObjects, uint dwSecurityObjectCount, ref TOKEN_GROUPS pUserGroups, Authz.AUTHZ_SID_OPERATION[] pAuthzUserGroupsOperations, ref TOKEN_GROUPS pDeviceGroups, Authz.AUTHZ_SID_OPERATION[] pAuthzDeviceGroupsOperations, ref Authz.AUTHZ_SECURITY_ATTRIBUTES_INFORMATION pAuthzUserClaims, Authz.AUTHZ_SECURITY_ATTRIBUTE_OPERATION[] pAuthzUserClaimsOperations, ref Authz.AUTHZ_SECURITY_ATTRIBUTES_INFORMATION pAuthzDeviceClaims, Authz.AUTHZ_SECURITY_ATTRIBUTE_OPERATION[] pAuthzDeviceClaimsOperations, EFFPERM_RESULT_LIST[] pEffpermResultLists)
		{
			System.Diagnostics.Debug.WriteLine($"ComputeEffectivePermissionWithSecondarySecurity({dwSecurityObjectCount}):{new SecurityIdentifier((IntPtr)pSid).Value};{new SecurityIdentifier((IntPtr)pDeviceSid).Value}");
			if (dwSecurityObjectCount != 1)
				return HRESULT.E_FAIL;
			if (pSecurityObjects[0].Id != (uint)SECURITY_OBJECT_ID.SECURITY_OBJECT_ID_OBJECT_SD)
				return HRESULT.E_FAIL;
			if (pSid == null || pSid.IsInvalid)
				return HRESULT.E_INVALIDARG;

			SafeAUTHZ_RESOURCE_MANAGER_HANDLE hAuthzResourceManager;
			if (!AuthzInitializeResourceManager(AuthzResourceManagerFlags.AUTHZ_RM_FLAG_NO_AUDIT, null, null, null, prov.ToString(), out hAuthzResourceManager))
				return HRESULT.S_OK;

			var identifier = new LUID();
			SafeAUTHZ_CLIENT_CONTEXT_HANDLE hAuthzUserContext;
			SafeAUTHZ_CLIENT_CONTEXT_HANDLE hAuthzCompoundContext = null;
			if (!AuthzInitializeContextFromSid(AuthzContextFlags.DEFAULT, pSid, hAuthzResourceManager, IntPtr.Zero, identifier, IntPtr.Zero, out hAuthzUserContext))
				return HRESULT.S_OK;

			if (pDeviceSid != null && !pDeviceSid.IsInvalid)
			{
				SafeAUTHZ_CLIENT_CONTEXT_HANDLE hAuthzDeviceContext;
				if (AuthzInitializeContextFromSid(AuthzContextFlags.DEFAULT, pDeviceSid, hAuthzResourceManager, IntPtr.Zero, identifier, IntPtr.Zero, out hAuthzDeviceContext))
					if (AuthzInitializeCompoundContext(hAuthzUserContext, hAuthzDeviceContext, out hAuthzCompoundContext))
						if (pAuthzDeviceClaims.Version != 0)
							AuthzModifyClaims(hAuthzCompoundContext, AUTHZ_CONTEXT_INFORMATION_CLASS.AuthzContextInfoDeviceClaims, pAuthzDeviceClaimsOperations, pAuthzDeviceClaims);
			}
			else
			{
				hAuthzCompoundContext = hAuthzUserContext;
			}

			if (hAuthzCompoundContext == null)
				return HRESULT.S_OK;

			if (pAuthzUserClaims.Version != 0)
				if (!AuthzModifyClaims(hAuthzCompoundContext, AUTHZ_CONTEXT_INFORMATION_CLASS.AuthzContextInfoUserClaims, pAuthzUserClaimsOperations, pAuthzUserClaims))
					return HRESULT.S_OK;

			if (pDeviceGroups.GroupCount != 0)
				if (!AuthzModifySids(hAuthzCompoundContext, AUTHZ_CONTEXT_INFORMATION_CLASS.AuthzContextInfoDeviceSids, pAuthzDeviceGroupsOperations, ref pDeviceGroups))
					return HRESULT.S_OK;

			if (pUserGroups.GroupCount != 0 && pAuthzUserGroupsOperations != null)
				if (!AuthzModifySids(hAuthzCompoundContext, AUTHZ_CONTEXT_INFORMATION_CLASS.AuthzContextInfoGroupsSids, pAuthzUserGroupsOperations, ref pUserGroups))
					return HRESULT.S_OK;

			var request = new AUTHZ_ACCESS_REQUEST((uint)ACCESS_MASK.MAXIMUM_ALLOWED);
			var sd = new SafeSecurityDescriptor(pSecurityObjects[0].pData, false);
			var reply = new AUTHZ_ACCESS_REPLY(1);
			SafeAUTHZ_ACCESS_CHECK_RESULTS_HANDLE phAccessCheckResults;
			if (!AuthzAccessCheck(AuthzAccessCheckFlags.NONE, hAuthzCompoundContext, ref request, null, sd, null, 0, reply, out phAccessCheckResults))
				return HRESULT.S_OK;

			pEffpermResultLists[0].fEvaluated = true;
			pEffpermResultLists[0].pGrantedAccessList = reply.GrantedAccessMaskValues;
			pEffpermResultLists[0].pObjectTypeList = new[] {OBJECT_TYPE_LIST.Self};
			pEffpermResultLists[0].cObjectTypeListLength = 1;

			return HRESULT.S_OK;
		}
	}
}