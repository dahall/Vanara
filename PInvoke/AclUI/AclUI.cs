using System;
using System.Runtime.InteropServices;
using Vanara.InteropServices;
using static Vanara.PInvoke.AdvApi32;
using static Vanara.PInvoke.Authz;

namespace Vanara.PInvoke
{
	/// <summary>Platform invokable enumerated types, constants and functions from aclui.h</summary>
	public static partial class AclUI
	{
		/// <summary>Messages sent from property sheet.</summary>
		public enum PropertySheetCallbackMessage : uint
		{
			/// <summary>Add reference.</summary>
			PSPCB_ADDREF = 0,

			/// <summary>Release reference.</summary>
			PSPCB_RELEASE = 1,

			/// <summary>Create page.</summary>
			PSPCB_CREATE = 2,

			/// <summary>Initialize dialog.</summary>
			PSPCB_SI_INITDIALOG = 0x00401 // wm_user + 1
		}

		/// <summary>Specifies the security descriptor to use.</summary>
		public enum SECURITY_OBJECT_ID
		{
			/// <summary>
			/// The security descriptor of the resource.
			/// <para>If Id is set to this value, then pData points to a security descriptor and cbData is the number of bytes in pData.</para>
			/// <para>pData2 is NULL and cbData2 is 0.</para>
			/// </summary>
			SECURITY_OBJECT_ID_OBJECT_SD = 1,

			/// <summary>
			/// The security descriptor of a network share.
			/// <para>
			/// If Id is set to this value, then pData points to the ISecurityInformation interface of an object that represents the security
			/// context of the share.
			/// </para>
			/// <para>
			/// If the security descriptor is not yet available, then pData2 must be a handle to a waitable object that is signaled when the
			/// security descriptor is ready when the GetSecondarySecurity method returns S_FALSE. The waitable object should be created by
			/// the CreateEvent function. In this case, cbData2 is 0.
			/// </para>
			/// <para>This identifier is only applicable to file system objects.</para>
			/// </summary>
			SECURITY_OBJECT_ID_SHARE = 2,

			/// <summary>
			/// The security descriptor of a central access policy.
			/// <para>
			/// If Id is set to this value, then pData points to the security descriptor with an empty DACL, an owner, group, and attribute
			/// access control entries (ACEs) that match the resource's owner, group, and attributes as well as a
			/// SCOPE_SECURITY_INFORMATION_ACE that contains the central policy's ID. cbData is set to the number of bytes in pData.
			/// </para>
			/// <para>pData2 is NULL and cbData2 is 0.</para>
			/// <para>
			/// The security descriptor is constructed to allow computing effective permissions to correctly determine when access is limited
			/// by the central policy and higher detail of the central access rule cannot be determined. This is used when a central access
			/// policy that applies to a resource cannot be resolved into its elemental central access rules.
			/// </para>
			/// </summary>
			SECURITY_OBJECT_ID_CENTRAL_POLICY = 3,

			/// <summary>
			/// The security descriptor of a central access rule.
			/// <para>
			/// If Id is set to this value, then pData points to the security descriptor with an owner, group, and attribute ACEs that match
			/// the resource's owner, group, and attributes, and a discretionary access control list (DACL) that matches the central access
			/// rule's DACL. cbData is set to the number of bytes in pData.
			/// </para>
			/// <para>
			/// In addition, pData2 points to a security descriptor with a DACL that contains a conditional ACE that grants 0x1 to Everyone
			/// if the resource condition from the central access rule evaluates to TRUE. cbData2 is set to the number of bytes in pData2.
			/// </para>
			/// <para>
			/// The security descriptor is constructed to allow computing effective permissions to determine when access is limited by the
			/// central access policy at the highest detail. That is, access is limited by pointing to a central policy rule.
			/// </para>
			/// </summary>
			SECURITY_OBJECT_ID_CENTRAL_ACCESS_RULE = 4
		}

		/// <summary>A set of bit flags that determine the editing options available to the user.</summary>
		[Flags]
		public enum SI_OBJECT_INFO_Flags : uint
		{
			/// <summary>
			/// The Advanced button is displayed on the basic security property page. If the user clicks this button, the system displays an
			/// advanced security property sheet that enables advanced editing of the discretionary access control list (DACL) of the object.
			/// </summary>
			SI_ADVANCED = 0x00000010,

			/// <summary>
			/// If this flag is set, a shield is displayed on the Edit button of the advanced Auditing pages. For NTFS objects, this flag is
			/// requested when the user does not have READ_CONTROL or ACCESS_SYSTEM_SECURITY access. Windows Server 2003 and Windows XP: This
			/// flag is not supported.
			/// </summary>
			SI_AUDITS_ELEVATION_REQUIRED = 0x02000000,

			/// <summary>
			/// Indicates that the object is a container. If this flag is set, the access control editor enables the controls relevant to the
			/// inheritance of permissions onto child objects.
			/// </summary>
			SI_CONTAINER = 0x00000004,

			/// <summary>Combines the EditPerms, EditOwner, and EditAudit flags.</summary>
			SI_EDIT_ALL = (SI_EDIT_PERMS | SI_EDIT_OWNER | SI_EDIT_AUDITS),

			/// <summary>
			/// If this flag is set and the user clicks the Advanced button, the system displays an advanced security property sheet that
			/// includes an Auditing property page for editing the object's SACL.
			/// </summary>
			SI_EDIT_AUDITS = 0x00000002,

			/// <summary>If this flag is set, the Effective Permissions page is displayed.</summary>
			SI_EDIT_EFFECTIVE = 0x00020000,

			/// <summary>
			/// If this flag is set and the user clicks the Advanced button, the system displays an advanced security property sheet that
			/// includes an Owner property page for changing the object's owner.
			/// </summary>
			SI_EDIT_OWNER = 0x00000001,

			/// <summary>
			/// This is the default value. The basic security property page always displays the controls for basic editing of the object's
			/// DACL. To disable these controls, set the ReadOnly flag.
			/// </summary>
			SI_EDIT_PERMS = 0x00000000,

			/// <summary>
			/// If this flag is set, the system enables controls for editing ACEs that apply to the object's property sets and properties.
			/// These controls are available only on the property sheet displayed when the user clicks the Advanced button.
			/// </summary>
			SI_EDIT_PROPERTIES = 0x00000080,

			/// <summary>
			/// Indicates that the access control editor cannot read the DACL but might be able to write to the DACL. If a call to the
			/// ISecurityInformation::GetSecurity method returns AccessDenied, the user can try to add a new ACE, and a more appropriate
			/// warning is displayed.
			/// </summary>
			SI_MAY_WRITE = 0x10000000,

			/// <summary>
			/// If this flag is set, the access control editor hides the check box that allows inheritable ACEs to propagate from the parent
			/// object to this object. If this flag is not set, the check box is visible. The check box is clear if the SE_DACL_PROTECTED
			/// flag is set in the object's security descriptor. In this case, the object's DACL is protected from being modified by
			/// inheritable ACEs. If the user clears the check box, any inherited ACEs in the security descriptor are deleted or converted to
			/// noninherited ACEs. Before proceeding with this conversion, the system displays a warning message box to confirm the change.
			/// </summary>
			SI_NO_ACL_PROTECT = 0x00000200,

			/// <summary>
			/// If this flag is set, the access control editor hides the Special Permissions tab on the Advanced Security Settings page.
			/// </summary>
			SI_NO_ADDITIONAL_PERMISSION = 0x00200000,

			/// <summary>
			/// If this flag is set, the access control editor hides the check box that controls the NO_PROPAGATE_INHERIT_ACE flag. This flag
			/// is relevant only when the Advanced flag is also set.
			/// </summary>
			SI_NO_TREE_APPLY = 0x00000400,

			/// <summary>
			/// When set, indicates that the ObjectGuid property is valid. This is set in comparisons with object-specific ACEs in
			/// determining whether the ACE applies to the current object.
			/// </summary>
			SI_OBJECT_GUID = 0x00010000,

			/// <summary>
			/// If this flag is set, a shield is displayed on the Edit button of the advanced Owner page. For NTFS objects, this flag is
			/// requested when the user does not have WRITE_OWNER access. This flag is valid only if the owner page is requested. Windows
			/// Server 2003 and Windows XP: This flag is not supported.
			/// </summary>
			SI_OWNER_ELEVATION_REQUIRED = 0x04000000,

			/// <summary>
			/// If this flag is set, the user cannot change the owner of the object. Set this flag if EditOwner is set but the user does not
			/// have permission to change the owner.
			/// </summary>
			SI_OWNER_READONLY = 0x00000040,

			/// <summary>
			/// Combine this flag with Container to display a check box on the owner page that indicates whether the user intends the new
			/// owner to be applied to all child objects as well as the current object. The access control editor does not perform the recursion.
			/// </summary>
			SI_OWNER_RECURSE = 0x00000100,

			/// <summary>
			/// If this flag is set, the Title property value is used as the title of the basic security property page. Otherwise, a default
			/// title is used.
			/// </summary>
			SI_PAGE_TITLE = 0x00000800,

			/// <summary>
			/// If this flag is set, an image of a shield is displayed on the Edit button of the simple and advanced Permissions pages. For
			/// NTFS objects, this flag is requested when the user does not have READ_CONTROL or WRITE_DAC access. Windows Server 2003 and
			/// Windows XP: This flag is not supported.
			/// </summary>
			SI_PERMS_ELEVATION_REQUIRED = 0x01000000,

			/// <summary>
			/// If this flag is set, the editor displays the object's security information, but the controls for editing the information are
			/// disabled. This flag cannot be combined with the ViewOnly flag.
			/// </summary>
			SI_READONLY = 0x00000008,

			/// <summary>
			/// If this flag is set, the Default button is displayed. If the user clicks this button, the access control editor calls the
			/// IAccessControlEditorDialogProvider.DefaultSecurity to retrieve an application-defined default security descriptor. The access
			/// control editor uses this security descriptor to reinitialize the property sheet, and the user is allowed to apply the change
			/// or cancel.
			/// </summary>
			SI_RESET = 0x00000020,

			/// <summary>When set, this flag displays the Reset Defaults button on the Permissions page.</summary>
			SI_RESET_DACL = 0x00040000,

			/// <summary>
			/// When set, this flag displays the Reset permissions on all child objects and enable propagation of inheritable permissions
			/// check box in the Permissions page of the Access Control Settings window. This function does not reset the permissions and
			/// enable propagation of inheritable permissions.
			/// </summary>
			SI_RESET_DACL_TREE = 0x00004000,

			/// <summary>When set, this flag displays the Reset Defaults button on the Owner page.</summary>
			SI_RESET_OWNER = 0x00100000,

			/// <summary>When set, this flag displays the Reset Defaults button on the Auditing page.</summary>
			SI_RESET_SACL = 0x00080000,

			/// <summary>
			/// When set, this flag displays the Reset auditing entries on all child objects and enables propagation of the inheritable
			/// auditing entries check box in the Auditing page of the Access Control Settings window. This function does not reset the
			/// permissions and enable propagation of inheritable permissions.
			/// </summary>
			SI_RESET_SACL_TREE = 0x00008000,

			/// <summary>
			/// Set this flag if the computer defined by the ServerName property is known to be a domain controller. If this flag is set, the
			/// domain name is included in the scope list of the Add Users and Groups dialog box. Otherwise, the pszServerName computer is
			/// used to determine the scope list of the dialog box.
			/// </summary>
			SI_SERVER_IS_DC = 0x00001000,

			// ISecurityInformation3
			/// <summary>View Only.</summary>
			SI_VIEW_ONLY = 0x00400000,

			// ISecurityInformation4
			//SI_DISABLE_DENY_ACE = 0x80000000,
			//SI_ENABLE_CENTRAL_POLICY = 0x40000000,
			//SI_ENABLE_EDIT_ATTRIBUTE_CONDITION = 0x20000000,
			//SI_SCOPE_ELEVATION_REQUIRED = 0x08000000,
		}

		/// <summary>Page types used by the new advanced ACL UI</summary>
		public enum SI_PAGE_ACTIVATED : uint
		{
			/// <summary></summary>
			SI_SHOW_DEFAULT = 0,

			/// <summary></summary>
			SI_SHOW_PERM_ACTIVATED,

			/// <summary></summary>
			SI_SHOW_AUDIT_ACTIVATED,

			/// <summary></summary>
			SI_SHOW_OWNER_ACTIVATED,

			/// <summary></summary>
			SI_SHOW_EFFECTIVE_ACTIVATED,

			/// <summary></summary>
			SI_SHOW_SHARE_ACTIVATED,

			/// <summary></summary>
			SI_SHOW_CENTRAL_POLICY_ACTIVATED,
		}

		/// <summary>Values that indicate the types of property pages in an access control editor property sheet.</summary>
		public enum SI_PAGE_TYPE : uint
		{
			/// <summary>Permissions page.</summary>
			SI_PAGE_PERM = 0,

			/// <summary>Advanced page.</summary>
			SI_PAGE_ADVPERM,

			/// <summary>Audit page.</summary>
			SI_PAGE_AUDIT,

			/// <summary>Owner page.</summary>
			SI_PAGE_OWNER,

			/// <summary>Effective Rights page.</summary>
			SI_PAGE_EFFECTIVE,

			/// <summary>Take Ownership page.</summary>
			SI_PAGE_TAKEOWNERSHIP,

			/// <summary>Share page.</summary>
			SI_PAGE_SHARE
		}

		/// <summary>
		/// The IEffectivePermission interface provides a means to determine effective permission for a security principal on an object. The
		/// access control editor uses this information to communicate the effective permission to the client.
		/// </summary>
		[ComImport, InterfaceType(ComInterfaceType.InterfaceIsIUnknown), Guid("3853DC76-9F35-407c-88A1-D19344365FBC")]
		[PInvokeData("aclui.h", MSDNShortId = "aa378393")]
		public interface IEffectivePermission
		{
			/// <summary>Returns the effective permission for an object type.</summary>
			/// <param name="pguidObjectType">A GUID for the object type whose permission is being queried.</param>
			/// <param name="pUserSid">
			/// A pointer to a SID structure that represents the security principal whose effective permission is being determined.
			/// </param>
			/// <param name="pszServerName">A pointer to null-terminated wide character string that represents the server name.</param>
			/// <param name="pSD">
			/// A pointer to a SECURITY_DESCRIPTOR structure that represents the object's security descriptor. The security descriptor is
			/// used to perform the access check.
			/// </param>
			/// <param name="ppObjectTypeList">
			/// A pointer to a pointer to an OBJECT_TYPE_LIST structure that represents the array of object types in the object tree for the
			/// object. If an object does not support property access, use the following technique to specify the value for the OBJECT_TYPE_LIST.
			/// </param>
			/// <param name="pcObjectTypeListLength">A pointer to a ULONG that receives the count of object types pointed to by ppObjectTypeList.</param>
			/// <param name="ppGrantedAccessList">
			/// A pointer to a pointer to an ACCESS_MASK that receives the array of granted access masks. The operating system will use
			/// LocalFree to free the memory allocated for this parameter.
			/// </param>
			/// <param name="pcGrantedAccessListLength">
			/// A pointer to a ULONG variable that receives the count of granted access masks pointed to by the ppGrantedAccessList parameter.
			/// </param>
			[PreserveSig]
			HRESULT GetEffectivePermission(in Guid pguidObjectType, [In] PSID pUserSid,
				[In, MarshalAs(UnmanagedType.LPWStr)] string pszServerName, [In] PSECURITY_DESCRIPTOR pSD,
				[MarshalAs(UnmanagedType.LPArray)] out OBJECT_TYPE_LIST[] ppObjectTypeList,
				out uint pcObjectTypeListLength,
				[MarshalAs(UnmanagedType.LPArray)] out ACCESS_MASK[] ppGrantedAccessList,
				out uint pcGrantedAccessListLength);
		}

		/// <summary>
		/// The IEffectivePermission2 interface provides a way to determine effective permissions for a security principal on an object in a
		/// way where the principal's security context may be compounded with a device context or adjusted in other ways. Additionally, it
		/// determines the effective permissions even when multiple security checks apply. The access control editor uses this information to
		/// communicate the effective permissions to the client.
		/// </summary>
		[ComImport, InterfaceType(ComInterfaceType.InterfaceIsIUnknown), Guid("941FABCA-DD47-4FCA-90BB-B0E10255F20D")]
		[PInvokeData("aclui.h", MSDNShortId = "hh448520")]
		public interface IEffectivePermission2
		{
			/// <summary>
			/// The ComputeEffectivePermissionWithSecondarySecurity method computes the effective permissions for an object. It supports
			/// integrating secondary or custom security policies. You may choose to provide this additional security information by
			/// implementing the ISecurityInformation4 interface. This method supports compound identity, which is when a principal's access
			/// token contains user and device authorization information.
			/// </summary>
			/// <param name="pSid">
			/// A pointer to a SID structure that represents the security principal whose effective permission is being determined.
			/// </param>
			/// <param name="pDeviceSid">
			/// A pointer to a SID structure that represents the device from which the principal is accessing the object. If this is not NULL
			/// and you are using the AuthzAccessCheck function to compute the effective permissions, then the device SID may be compounded
			/// with the pSid parameter by using the AuthzInitializeCompoundContext function.
			/// </param>
			/// <param name="pszServerName">
			/// The name of the server on which the object resides. This is the same name that was returned from the
			/// ISecurityInformation::GetObjectInformation method.
			/// </param>
			/// <param name="pSecurityObjects">
			/// An array of security objects. This array is composed of objects that were deduced by the access control editor in addition to
			/// the ones returned from the ISecurityInformation4::GetSecondarySecurity method.
			/// </param>
			/// <param name="dwSecurityObjectCount">
			/// The number of security objects in the pSecurityObjects parameter, and the number of results lists in the pEffpermResultLists parameter.
			/// </param>
			/// <param name="pUserGroups">
			/// A pointer to additional user groups that should be used to modify the security context which was initialized from the pSid
			/// parameter. If you are using the AuthzAccessCheck function to compute the effective permissions, then the modification may be
			/// done by calling the AuthzModifySids function using AuthzContextInfoGroupsSids as the SidClass parameter.
			/// </param>
			/// <param name="pAuthzUserGroupsOperations">
			/// Pointer to an array of AUTHZ_SID_OPERATION structures that specify how the user groups in the authz context must be modified
			/// for each user group in the pUserGroups argument. This array contains as many elements as the number of groups in the
			/// pUserGroups parameter.
			/// </param>
			/// <param name="pDeviceGroups">
			/// A pointer to additional device groups that should be used to modify the security context which was initialized from the pSid
			/// parameter or one that was created by compounding the contexts that were initialized from the pSid and pDeviceSid parameters.
			/// If you are using the AuthzAccessCheck function to compute the effective permissions, then the modification may be done by
			/// calling the AuthzModifySids function using AuthzContextInfoDeviceSids as the SidClass parameter.
			/// </param>
			/// <param name="pAuthzDeviceGroupsOperations">
			/// Pointer to an array of AUTHZ_SID_OPERATION enumeration types that specify how the device groups in the authz context must be
			/// modified for each device group in the pDeviceGroups argument. This array contains as many elements as the number of groups in
			/// the pDeviceGroups parameter.
			/// </param>
			/// <param name="pAuthzUserClaims">
			/// Pointer to an AUTHZ_SECURITY_ATTRIBUTES_INFORMATION structure that contains the user claims context that should be used to
			/// modify the security context that was initialized from the pSid parameter. If you are using the AuthzAccessCheck function to
			/// compute the effective permissions, then the modification may be done by calling the AuthzModifyClaims function using
			/// AuthzContextInfoUserClaims as the ClaimClass parameter.
			/// </param>
			/// <param name="pAuthzUserClaimsOperations">
			/// Pointer to an AUTHZ_SECURITY_ATTRIBUTE_OPERATION enumeration type that specifies the operations associated with the user
			/// claims context.
			/// </param>
			/// <param name="pAuthzDeviceClaims">
			/// A pointer to the device claims context that should be used to modify the security context that was initialized from the pSid
			/// parameter or one that was created by compounding the contexts that were initialized from the pSid and pDeviceSid parameters.
			/// This may be supplied by the caller, even if the pDeviceSid parameter is not. If you are using the AuthzAccessCheck function
			/// to compute the effective permissions, then the modification may be done by calling the AuthzModifyClaims function using
			/// AuthzContextInfoDeviceClaims as the ClaimClass parameter.
			/// </param>
			/// <param name="pAuthzDeviceClaimsOperations">
			/// Pointer to an AUTHZ_SECURITY_ATTRIBUTE_OPERATION enumeration type that specifies the operations associated with the device
			/// claims context.
			/// </param>
			/// <param name="pEffpermResultLists">
			/// A pointer to an array of the effective permissions results of type EFFPERM_RESULT_LIST. This array is dwSecurityObjectCount
			/// elements long. The array is initialized by the caller and the implementation is expected to set all fields of each member in
			/// the array, indicating what access was granted by the corresponding security object.
			/// <para>
			/// If a security object was considered, the fEvaluated member should be set to TRUE. In this case, the pObjectTypeList and
			/// pGrantedAccessList members should both be cObjectTypeListLength elements long. The pObjectTypeList member must point to
			/// memory that is owned by the resource manager and must remain valid until the EditSecurity function exits. The
			/// pGrantedAccessList member is freed by the caller by using the LocalFree function. If the resource manager does not support
			/// object ACEs, then the pObjectTypeList member should point to the NULL GUID, the cObjectTypeListLength member should be 1, and
			/// the pGrantedAccessList member should be a single DWORD.
			/// </para>
			/// </param>
			[PreserveSig]
			HRESULT ComputeEffectivePermissionWithSecondarySecurity(
				[In] PSID pSid,
				[In, Optional] PSID pDeviceSid,
				[In, Optional, MarshalAs(UnmanagedType.LPWStr)] string pszServerName,
				[In, MarshalAs(UnmanagedType.LPArray, SizeParamIndex = 4)] SECURITY_OBJECT[] pSecurityObjects,
				uint dwSecurityObjectCount,
				in TOKEN_GROUPS pUserGroups,
				[In, Optional] AUTHZ_SID_OPERATION[] pAuthzUserGroupsOperations,
				in TOKEN_GROUPS pDeviceGroups,
				[In, Optional] AUTHZ_SID_OPERATION[] pAuthzDeviceGroupsOperations,
				in AUTHZ_SECURITY_ATTRIBUTES_INFORMATION pAuthzUserClaims,
				[In, Optional] AUTHZ_SECURITY_ATTRIBUTE_OPERATION[] pAuthzUserClaimsOperations,
				in AUTHZ_SECURITY_ATTRIBUTES_INFORMATION pAuthzDeviceClaims,
				[In, Optional] AUTHZ_SECURITY_ATTRIBUTE_OPERATION[] pAuthzDeviceClaimsOperations,
				[MarshalAs(UnmanagedType.LPArray, SizeParamIndex = 4)] EFFPERM_RESULT_LIST[] pEffpermResultLists);
		}

		/// <summary>
		/// The ISecurityInformation interface enables the access control editor to communicate with the caller of the CreateSecurityPage and
		/// EditSecurity functions. The editor calls the interface methods to retrieve information that is used to initialize its pages and
		/// to determine the editing options available to the user. The editor also calls the interface methods to pass the user's input back
		/// to the application.
		/// </summary>
		[ComImport, InterfaceType(ComInterfaceType.InterfaceIsIUnknown), Guid("965FC360-16FF-11d0-91CB-00AA00BBB723")]
		[PInvokeData("aclui.h", MSDNShortId = "aa378900")]
		public interface ISecurityInformation
		{
			/// <summary>
			/// The GetObjectInformation method requests information that the access control editor uses to initialize its pages and to
			/// determine the editing options available to the user.
			/// </summary>
			/// <param name="object_info">
			/// A pointer to an SI_OBJECT_INFO structure. Your implementation must fill this structure to pass information back to the access
			/// control editor.
			/// </param>
			[PreserveSig]
			HRESULT GetObjectInformation(ref SI_OBJECT_INFO object_info);

			/// <summary>
			/// The GetSecurity method requests a security descriptor for the securable object whose security descriptor is being edited. The
			/// access control editor calls this method to retrieve the object's current or default security descriptor.
			/// </summary>
			/// <param name="RequestInformation">
			/// A set of SECURITY_INFORMATION bit flags that indicate the parts of the security descriptor being requested. This parameter
			/// can be a combination of the following values.
			/// </param>
			/// <param name="SecurityDescriptor">
			/// A pointer to a variable that your implementation must set to a pointer to the object's security descriptor. The security
			/// descriptor must include the components requested by the RequestedInformation parameter.
			/// <para>The system calls the LocalFree function to free the returned pointer.</para>
			/// </param>
			/// <param name="fDefault">
			/// If this parameter is TRUE, ppSecurityDescriptor should return an application-defined default security descriptor for the
			/// object. The access control editor uses this default security descriptor to reinitialize the property page.
			/// <para>
			/// The access control editor sets this parameter to TRUE only if the user clicks the Default button. The Default button is
			/// displayed only if you set the SI_RESET flag in the ISecurityInformation::GetObjectInformation method. If no default security
			/// descriptor is available, do not set the SI_RESET flag.
			/// </para>
			/// <para>If this flag is FALSE, ppSecurityDescriptor should return the object's current security descriptor.</para>
			/// </param>
			[PreserveSig]
			HRESULT GetSecurity([In] SECURITY_INFORMATION RequestInformation, out PSECURITY_DESCRIPTOR SecurityDescriptor, [In, MarshalAs(UnmanagedType.Bool)] bool fDefault);

			/// <summary>
			/// The SetSecurity method provides a security descriptor containing the security information the user wants to apply to the
			/// securable object. The access control editor calls this method when the user clicks Okay or Apply.
			/// </summary>
			/// <param name="RequestInformation">
			/// A set of SECURITY_INFORMATION bit flags that indicate the parts of the security descriptor to set.
			/// </param>
			/// <param name="SecurityDescriptor">
			/// A pointer to a security descriptor containing the new security information. Do not assume the security descriptor is in
			/// self-relative form; it can be either absolute or self-relative.
			/// </param>
			[PreserveSig]
			HRESULT SetSecurity([In] SECURITY_INFORMATION RequestInformation, [In] PSECURITY_DESCRIPTOR SecurityDescriptor);

			/// <summary>
			/// The GetAccessRights method requests information about the access rights that can be controlled for a securable object. The
			/// access control editor calls this method to retrieve display strings and other information used to initialize the property pages.
			/// </summary>
			/// <param name="guidObject">
			/// A pointer to a GUID structure that identifies the type of object for which access rights are being requested. If this
			/// parameter is NULL or a pointer to GUID_NULL, return the access rights for the object being edited. Otherwise, the GUID
			/// identifies a child object type returned by the ISecurityInformation::GetInheritTypes method. The GUID corresponds to the
			/// InheritedObjectType member of an object-specific ACE.
			/// </param>
			/// <param name="dwFlags">
			/// A set of bit flags that indicate the property page being initialized. This value is zero if the basic security page is being
			/// initialized. Otherwise, it is a combination of the following values.
			/// </param>
			/// <param name="access">
			/// A pointer to an array of SI_ACCESS structures. The array must include one entry for each access right. You can specify access
			/// rights that apply to the object itself, as well as object-specific access rights that apply only to a property set or
			/// property on the object.
			/// </param>
			/// <param name="access_count">A pointer to ULONG that indicates the number of entries in the ppAccess array.</param>
			/// <param name="DefaultAccess">
			/// A pointer to ULONG that indicates the zero-based index of the array entry that contains the default access rights. The access
			/// control editor uses this entry as the initial access rights in a new ACE.
			/// </param>
			[PreserveSig]
			HRESULT GetAccessRights(in Guid guidObject, [In] int dwFlags, [MarshalAs(UnmanagedType.LPArray, SizeParamIndex = 3)] out SI_ACCESS[] access, ref uint access_count, out uint DefaultAccess);

			/// <summary>
			/// The MapGeneric method requests that the generic access rights in an access mask be mapped to their corresponding standard and
			/// specific access rights. For more information about generic, standard, and specific access rights, see Access Rights and
			/// Access Masks.
			/// </summary>
			/// <param name="guidObjectType">
			/// A pointer to a GUID structure that identifies the type of object to which the access mask applies. If this member is NULL or
			/// a pointer to GUID_NULL, the access mask applies to the object itself.
			/// </param>
			/// <param name="AceFlags">
			/// A pointer to the AceFlags member of the ACE_HEADER structure from the ACE whose access mask is being mapped.
			/// </param>
			/// <param name="Mask">
			/// A pointer to an access mask that contains the generic access rights to map. Your implementation must map the generic access
			/// rights to the corresponding standard and specific access rights for the specified object type.
			/// </param>
			[PreserveSig]
			HRESULT MapGeneric(in Guid guidObjectType, ref System.Security.AccessControl.AceFlags AceFlags, ref ACCESS_MASK Mask);

			/// <summary>
			/// The GetInheritTypes method requests information about how ACEs can be inherited by child objects. For more information, see
			/// ACE Inheritance.
			/// </summary>
			/// <param name="InheritType">
			/// A pointer to a variable you should set to a pointer to an array of SI_INHERIT_TYPE structures. The array should include one
			/// entry for each combination of inheritance flags and child object type that you support.
			/// </param>
			/// <param name="InheritTypesCount">
			/// A pointer to a variable that you should set to indicate the number of entries in the ppInheritTypes array.
			/// </param>
			[PreserveSig]
			HRESULT GetInheritTypes([MarshalAs(UnmanagedType.LPArray, SizeParamIndex = 1)] out SI_INHERIT_TYPE[] InheritType, out uint InheritTypesCount);

			/// <summary>
			/// The PropertySheetPageCallback method notifies an EditSecurity or CreateSecurityPage caller that an access control editor
			/// property page is being created or destroyed.
			/// </summary>
			/// <param name="hwnd">
			/// If uMsg is PSPCB_SI_INITDIALOG, hwnd is a handle to the property page dialog box. Otherwise, hwnd is NULL.
			/// </param>
			/// <param name="uMsg">Identifies the message being received.</param>
			/// <param name="uPage">
			/// A value from the SI_PAGE_TYPE enumeration type that indicates the type of access control editor property page being created
			/// or destroyed.
			/// </param>
			[PreserveSig]
			HRESULT PropertySheetPageCallback([In] HWND hwnd, [In] PropertySheetCallbackMessage uMsg, [In] SI_PAGE_TYPE uPage);
		}

		/// <summary>
		/// The ISecurityInformation2 interface enables the access control editor to obtain information from the client that is not provided
		/// by the ISecurityInformation interface. The client does not need to implement ISecurityInformation2 unless the default behavior of
		/// the access control editor is unsuitable for the client.
		/// </summary>
		[ComImport, InterfaceType(ComInterfaceType.InterfaceIsIUnknown), Guid("c3ccfdb4-6f88-11d2-a3ce-00c04fb1782a")]
		[PInvokeData("aclui.h", MSDNShortId = "aa378908")]
		public interface ISecurityInformation2
		{
			/// <summary>
			/// The IsDaclCanonical method determines whether the ACEs contained in the specified DACL structure are ordered according to the
			/// definition of DACL ordering implemented by the client.
			/// </summary>
			/// <param name="pDacl">A pointer to a discretionary ACL structure initialized by InitializeAcl.</param>
			/// <returns>
			/// Returns TRUE if the ACEs contained in the specified DACL structure are ordered according to the definition of DACL ordering
			/// implemented by the client. Returns FALSE if the ACEs are not ordered correctly.
			/// </returns>
			[return: MarshalAs(UnmanagedType.Bool)]
			bool IsDaclCanonical([In] PACL pDacl);

			/// <summary>
			/// The LookupSids method returns the common names corresponding to each of the elements in the specified list of SIDs.
			/// </summary>
			/// <param name="cSids">The number of pointers to SID structures pointed to by rgpSids.</param>
			/// <param name="rgpSids">A pointer to an array of pointers to SID structures.</param>
			/// <param name="ppdo">
			/// A pointer to a pointer to a returned data transfer object that contains the common names of the SIDs. Optionally, this
			/// parameter also returns the user principal name (UPN) of the SIDs in the rgpSids parameter. The data transfer object is a
			/// SID_INFO structure.
			/// </param>
			[PreserveSig]
			HRESULT LookupSids([In] uint cSids, [In, MarshalAs(UnmanagedType.LPArray)] PSID[] rgpSids, out IntPtr ppdo);
		}

		/// <summary>
		/// The ISecurityInformation3 interface provides methods necessary for displaying an elevated access control editor when a user
		/// clicks the Edit button on an access control editor page that displays an image of a shield on that Edit button. The image of a
		/// shield is displayed on the Edit button when the access control editor is launched by a process with a token that lacks permission
		/// to save changes to the object being edited.
		/// </summary>
		[ComImport, InterfaceType(ComInterfaceType.InterfaceIsIUnknown), Guid("E2CDC9CC-31BD-4f8f-8C8B-B641AF516A1A")]
		[PInvokeData("aclui.h", MSDNShortId = "bb540757")]
		public interface ISecurityInformation3
		{
			/// <summary>
			/// The GetFullResourceName method retrieves the full path and file name of the object associated with the access control editor
			/// that is displayed by calling the OpenElevatedEditor method.
			/// </summary>
			/// <returns>The full path and file name of the object for which permissions are to be edited.</returns>
			[PreserveSig]
			HRESULT GetFullResourceName([MarshalAs(UnmanagedType.LPWStr)] out string ppszResourceName);

			/// <summary>
			/// The OpenElevatedEditor method opens an access control editor when a user clicks the Edit button on an access control editor
			/// page that displays an image of a shield on that Edit button. The image of a shield is displayed when the access control
			/// editor is launched by a process with a token that lacks permission to save changes to the object being edited.
			/// </summary>
			/// <param name="hWnd">The parent window of the access control editor.</param>
			/// <param name="uPage">
			/// A value of the SI_PAGE_TYPE enumeration that indicates the page type on which to display the elevated access control editor.
			/// </param>
			[PreserveSig]
			HRESULT OpenElevatedEditor([In] HWND hWnd, [In] SI_PAGE_TYPE uPage);
		}

		/// <summary>
		/// The ISecurityInformation4 interface enables the resource manager to provide additional information when computing effective
		/// permissions using the IEffectivePermission2 interface.
		/// </summary>
		[ComImport, InterfaceType(ComInterfaceType.InterfaceIsIUnknown), Guid("EA961070-CD14-4621-ACE4-F63C03E583E4")]
		[PInvokeData("aclui.h", MSDNShortId = "hh448522")]
		public interface ISecurityInformation4
		{
			/// <summary>The GetSecondarySecurity method returns additional security contexts that may impact access to the resource.</summary>
			/// <param name="pSecurityObjects">
			/// An array of SECURITY_OBJECT structures that contain the secondary security objects associated with the resources that are set
			/// on success. The array is owned by the caller and is freed by using the LocalFree function. The pwszName member is also freed
			/// by using LocalFree. If the cbData or cbData2 members of the SECURITY_OBJECT structure are not zero, then the caller must free
			/// the corresponding pData or pData2 by using LocalFree. If either of those members are zero, then the corresponding pData and
			/// pData2 members are owned by the resource manager and must remain valid until the EditSecurity function returns.
			/// </param>
			/// <param name="pSecurityObjectCount">The number of security objects in the pSecurityObjects parameter that are set on success.</param>
			[PreserveSig]
			HRESULT GetSecondarySecurity([MarshalAs(UnmanagedType.LPArray, SizeParamIndex = 1)] out SECURITY_OBJECT[] pSecurityObjects, out uint pSecurityObjectCount);
		}

		/// <summary>
		/// The ISecurityObjectTypeInfo interface provides a means of determining the source of inherited access control entries (ACEs) in
		/// discretionary access control lists (DACLs) and system access control lists (SACLs). The access control editor uses this
		/// information to communicate the inheritance source to the client.
		/// </summary>
		[ComImport, InterfaceType(ComInterfaceType.InterfaceIsIUnknown), Guid("FC3066EB-79EF-444b-9111-D18A75EBF2FA")]
		[PInvokeData("aclui.h", MSDNShortId = "aa379128")]
		public interface ISecurityObjectTypeInfo
		{
			/// <summary>
			/// The GetInheritSource method provides a means of determining the source of inherited access control entries (ACEs) in
			/// discretionary access control lists (DACLs) and system access control lists (SACLs).
			/// </summary>
			/// <param name="si">A SECURITY_INFORMATION structure that represents the security information of the object.</param>
			/// <param name="pACL">A pointer to an ACL structure that represents the access control list (ACL) of the object.</param>
			/// <param name="ppInheritArray">
			/// A pointer to a pointer to an INHERITED_FROM structure that receives an array of INHERITED_FROM structures. The length of this
			/// array is the same as the number of ACEs in the ACL referenced by pACL. Each INHERITED_FROM entry in ppInheritArray provides
			/// inheritance information for the corresponding ACE entry in pACL.
			/// </param>
			[PreserveSig]
			HRESULT GetInheritSource([In] int si, [In] PACL pACL, [MarshalAs(UnmanagedType.LPArray)] out INHERITED_FROM[] ppInheritArray);
		}

		/// <summary>
		/// Combines the <see cref="SI_PAGE_TYPE"/> and <see cref="SI_PAGE_ACTIVATED"/> types for use in the last parameter of
		/// <see cref="EditSecurityAdvanced(HWND, ISecurityInformation, SI_PAGE_TYPE, SI_PAGE_ACTIVATED)"/> method.
		/// </summary>
		/// <param name="pt">The <see cref="SI_PAGE_TYPE"/> value.</param>
		/// <param name="pa">The <see cref="SI_PAGE_ACTIVATED"/> value.</param>
		/// <returns>A combined value.</returns>
		public static uint COMBINE_PAGE_ACTIVATION(SI_PAGE_TYPE pt, SI_PAGE_ACTIVATED pa) => (uint)pt | ((uint)pa << 16);

		/// <summary>
		/// The CreateSecurityPage function creates a basic security property page that enables the user to view and edit the access rights
		/// allowed or denied by the access control entries (ACEs) in an object's discretionary access control list (DACL). Use the
		/// PropertySheet function or the PSM_ADDPAGE message to add this page to a property sheet.
		/// </summary>
		/// <param name="psi">
		/// A pointer to your implementation of the ISecurityInformation interface. The system calls the interface methods to retrieve
		/// information about the object being edited and to return the user's input.
		/// </param>
		/// <returns>
		/// If the function succeeds, the function returns a handle to a basic security property page. If the function fails, it returns
		/// NULL. To get extended error information, call GetLastError.
		/// </returns>
		[DllImport(Lib.AclUI, ExactSpelling = true, SetLastError = true)]
		[PInvokeData("aclui.h", Dll = "Aclui.dll", MSDNShortId = "aa446584")]
		public static extern IntPtr CreateSecurityPage([In] ISecurityInformation psi);

		/// <summary>
		/// The <c>EditSecurity</c> function displays a property sheet that contains a basic security property page. This property page
		/// enables the user to view and edit the access rights allowed or denied by the ACEs in an object's DACL.
		/// </summary>
		/// <param name="hwndOwner">A handle to the window that owns the property sheet. This parameter can be <c>NULL</c>.</param>
		/// <param name="psi">
		/// A pointer to your implementation of the ISecurityInformation interface. The system calls the interface methods to retrieve
		/// information about the object being edited and to return the user's input.
		/// </param>
		/// <returns>
		/// <para>If the function succeeds, the return value is a nonzero value.</para>
		/// <para>If the function fails, the return value is zero. To get extended error information, call GetLastError.</para>
		/// </returns>
		/// <remarks>
		/// <para>The <c>EditSecurity</c> function calls the CreateSecurityPage function to create a basic security property page.</para>
		/// <para>
		/// During the property page initialization, the system calls the ISecurityInformation::GetSecurity and
		/// ISecurityInformation::SetSecurity methods to determine whether the user has permission to edit the object's security descriptor.
		/// The system displays an error message if the user does not have permission.
		/// </para>
		/// <para>
		/// The basic security property page can include an <c>Advanced</c> button for displaying the advanced security property sheet. This
		/// advanced security property sheet can contain three additional property pages that enable the user to view and edit the object's
		/// DACL, SACL, and owner.
		/// </para>
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows/desktop/api/aclui/nf-aclui-editsecurity BOOL ACLUIAPI EditSecurity( HWND hwndOwner,
		// LPSECURITYINFO psi );
		[DllImport(Lib.AclUI, SetLastError = true, ExactSpelling = true)]
		[PInvokeData("aclui.h", MSDNShortId = "756c94b0-946f-47eb-b4b4-db3e6e89fe46")]
		[return: MarshalAs(UnmanagedType.Bool)]
		public static extern bool EditSecurity([Optional] HWND hwndOwner, ISecurityInformation psi);

		/// <summary>
		/// The <c>EditSecurityAdvanced</c> function extends the EditSecurity function to include the security page type when displaying the
		/// property sheet that contains a basic security property page. This property page enables the user to view and edit the access
		/// rights allowed or denied by the access control entries (ACEs) in an object's discretionary access control list (DACL).
		/// </summary>
		/// <param name="hwndOwner">A handle to the window that owns the property sheet. This parameter can be <c>NULL</c>.</param>
		/// <param name="psi">
		/// A pointer to your implementation of the ISecurityInformation interface. The system calls the interface methods to retrieve
		/// information about the object being edited and to return the user's input.
		/// </param>
		/// <param name="uSIPage">
		/// A value of the SI_PAGE_TYPE enumeration that indicates the page type on which to display the elevated access control editor.
		/// </param>
		/// <returns>
		/// <para>If the function succeeds, the return value is S_OK.</para>
		/// <para>
		/// If the function fails, any other <c>HRESULT</c> value indicates an error. For a list of common error codes, see Common HRESULT Values.
		/// </para>
		/// </returns>
		// https://docs.microsoft.com/en-us/windows/desktop/api/aclui/nf-aclui-editsecurityadvanced HRESULT ACLUIAPI EditSecurityAdvanced(
		// HWND hwndOwner, LPSECURITYINFO psi, SI_PAGE_TYPE uSIPage );
		[DllImport(Lib.AclUI, SetLastError = false, ExactSpelling = true)]
		[PInvokeData("aclui.h", MSDNShortId = "E451BBB9-4E01-4A8F-9ACD-750351F16453")]
		public static extern HRESULT EditSecurityAdvanced([Optional] HWND hwndOwner, ISecurityInformation psi, uint uSIPage);

		/// <summary>
		/// The <c>EditSecurityAdvanced</c> function extends the EditSecurity function to include the security page type when displaying the
		/// property sheet that contains a basic security property page. This property page enables the user to view and edit the access
		/// rights allowed or denied by the access control entries (ACEs) in an object's discretionary access control list (DACL).
		/// </summary>
		/// <param name="hwndOwner">A handle to the window that owns the property sheet. This parameter can be <c>NULL</c>.</param>
		/// <param name="psi">
		/// A pointer to your implementation of the ISecurityInformation interface. The system calls the interface methods to retrieve
		/// information about the object being edited and to return the user's input.
		/// </param>
		/// <param name="pageType">
		/// A value of the SI_PAGE_TYPE enumeration that indicates the page type on which to display the elevated access control editor.
		/// </param>
		/// <param name="pageActivated">A value of the SI_PAGE_ACTIVATED enumeration that indicates the page type to display.</param>
		/// <returns>
		/// <para>If the function succeeds, the return value is S_OK.</para>
		/// <para>
		/// If the function fails, any other <c>HRESULT</c> value indicates an error. For a list of common error codes, see Common HRESULT Values.
		/// </para>
		/// </returns>
		[PInvokeData("aclui.h", MSDNShortId = "E451BBB9-4E01-4A8F-9ACD-750351F16453")]
		public static HRESULT EditSecurityAdvanced([Optional] HWND hwndOwner, ISecurityInformation psi, SI_PAGE_TYPE pageType, SI_PAGE_ACTIVATED pageActivated) =>
			EditSecurityAdvanced(hwndOwner, psi, COMBINE_PAGE_ACTIVATION(pageType, pageActivated));

		/// <summary>The EFFPERM_RESULT_LIST structure lists the effective permissions.</summary>
		[StructLayout(LayoutKind.Sequential, CharSet = CharSet.Unicode)]
		[PInvokeData("aclui.h", MSDNShortId = "hh448491")]
		public struct EFFPERM_RESULT_LIST
		{
			/// <summary>Indicates if the effective permissions results have been evaluated.</summary>
			[MarshalAs(UnmanagedType.Bool)] public bool fEvaluated;

			/// <summary>The number of elements in both the pObjectTypeList and pGrantedAccessList members.</summary>
			public uint cObjectTypeListLength;

			/// <summary>
			/// A pointer to an array of OBJECT_TYPE_LIST structures that specifies the properties and property sets for which access was evaluated.
			/// </summary>
			[MarshalAs(UnmanagedType.LPArray)] public OBJECT_TYPE_LIST[] pObjectTypeList;

			/// <summary>
			/// A pointer to an array of ACCESS_MASK values that specifies the access rights granted for each corresponding object type.
			/// </summary>
			[MarshalAs(UnmanagedType.LPArray)] public uint[] pGrantedAccessList;
		}

		/// <summary>The SECURITY_OBJECT structure contains the security object information.</summary>
		[StructLayout(LayoutKind.Sequential, CharSet = CharSet.Unicode)]
		[PInvokeData("aclui.h", MSDNShortId = "hh448532")]
		public struct SECURITY_OBJECT
		{
			/// <summary>A pointer to the name.</summary>
			[MarshalAs(UnmanagedType.LPWStr)] public string pwszName;

			/// <summary>A pointer to the security data.</summary>
			public IntPtr pData;

			/// <summary>
			/// The size, in bytes, of the data pointed to by the pData member. This may be zero if pData contains the data, such as when the
			/// data is an IUnknown interface pointer, a handle, or data specific to the resource manager that can be stored in pData
			/// directly without a memory allocation.
			/// </summary>
			public uint cbData;

			/// <summary>A pointer to the additional security data.</summary>
			public IntPtr pData2;

			/// <summary>
			/// The size, in bytes, of the data pointed to by the pData2 member. This may be zero if pData2 contains the data, such as when
			/// the data is an IUnknown interface pointer, a handle, or data specific to the resource manager that can be stored in pData2
			/// directly without a memory allocation.
			/// </summary>
			public uint cbData2;

			/// <summary>
			/// The identifier for the security object's type. If the fWellKnown member is FALSE, then the Id member has no special
			/// significance other than to help resource managers distinguish it from other classes of security objects. If the fWellKnown
			/// member is TRUE, then the Id member is one of the following and the entire structure follows the corresponding representation.
			/// </summary>
			public uint Id;

			/// <summary>TRUE if the security object represents one of the well-know security objects listed in the Id member.</summary>
			[MarshalAs(UnmanagedType.Bool)] public bool fWellKnown;
		}

		/// <summary>
		/// The SI_OBJECT_INFO structure is used by the ISecurityInformation::GetObjectInformation method to specify information used to
		/// initialize the access control editor.
		/// </summary>
		[StructLayout(LayoutKind.Sequential, CharSet = CharSet.Unicode)]
		[PInvokeData("aclui.h", MSDNShortId = "aa379605")]
		public struct SI_OBJECT_INFO
		{
			/// <summary>A set of bit flags that determine the editing options available to the user.</summary>
			public SI_OBJECT_INFO_Flags dwFlags;

			/// <summary>
			/// Identifies a module that contains string resources to be used in the property sheet. The
			/// ISecurityInformation::GetAccessRights and ISecurityInformation::GetInheritTypes methods can specify string resource
			/// identifiers for display names.
			/// </summary>
			public HINSTANCE hInstance;

			/// <summary>
			/// A pointer to a null-terminated, Unicode string that names the computer on which to look up account names and SIDs. This value
			/// can be NULL to specify the local computer. The access control editor does not free this pointer.
			/// </summary>
			[MarshalAs(UnmanagedType.LPWStr)]
			public string pszServerName;

			/// <summary>
			/// A pointer to a null-terminated, Unicode string that names the object being edited. This name appears in the title of the
			/// advanced security property sheet and any error message boxes displayed by the access control editor. The access control
			/// editor does not free this pointer.
			/// </summary>
			[MarshalAs(UnmanagedType.LPWStr)]
			public string pszObjectName;

			/// <summary>
			/// A pointer to a null-terminated, Unicode string used as the title of the basic security property page. This member is ignored
			/// unless the SI_PAGE_TITLE flag is set in dwFlags. If the page title is not provided, a default title is used. The access
			/// control editor does not free this pointer.
			/// </summary>
			[MarshalAs(UnmanagedType.LPWStr)]
			public string pszPageTitle;

			/// <summary>A GUID for the object. This member is ignored unless the SI_OBJECT_GUID flag is set in dwFlags.</summary>
			public Guid guidObjectType;

			/// <summary>Initializes a new instance of the <see cref="SI_OBJECT_INFO"/> struct.</summary>
			/// <param name="flags">A set of bit flags that determine the editing options available to the user.</param>
			/// <param name="objectName">Names the object being edited.</param>
			/// <param name="serverName">Names the computer on which to look up account names and SIDs.</param>
			/// <param name="pageTitle">The title of the basic security property page.</param>
			/// <param name="guidObject">The unique identifier for the object.</param>
			public SI_OBJECT_INFO(SI_OBJECT_INFO_Flags flags, string objectName, string serverName = null, string pageTitle = null, Guid? guidObject = null)
			{
				dwFlags = flags;
				hInstance = IntPtr.Zero;
				pszObjectName = objectName;
				pszServerName = serverName;
				pszPageTitle = pageTitle;
				guidObjectType = guidObject ?? Guid.Empty;
				if (pageTitle != null)
					dwFlags |= SI_OBJECT_INFO_Flags.SI_PAGE_TITLE;
				if (guidObjectType != Guid.Empty)
					dwFlags |= SI_OBJECT_INFO_Flags.SI_OBJECT_GUID;
			}

			/// <summary>Gets a value indicating whether this instance is container.</summary>
			/// <value><c>true</c> if this instance is container; otherwise, <c>false</c>.</value>
			public bool IsContainer => ((dwFlags & SI_OBJECT_INFO_Flags.SI_CONTAINER) == SI_OBJECT_INFO_Flags.SI_CONTAINER);

			/// <summary>Returns a <see cref="System.String"/> that represents this instance.</summary>
			/// <returns>A <see cref="System.String"/> that represents this instance.</returns>
			public override string ToString() => $"{pszObjectName}: {dwFlags}{(IsContainer ? " (Cont)" : "")}";
		}

		/// <summary>
		/// The SID_INFO structure contains the list of common names corresponding to the SID structures returned by
		/// ISecurityInformation2::LookupSids. It is a member of the SID_INFO_LIST structure.
		/// </summary>
		[StructLayout(LayoutKind.Sequential, CharSet = CharSet.Unicode)]
		[PInvokeData("aclui.h", MSDNShortId = "aa379599")]
		public struct SID_INFO
		{
			/// <summary>A pointer to a SID structure that identifies one of the SIDs passed into ISecurityInformation2::LookupSids.</summary>
			public IntPtr pSid;

			/// <summary>A pointer to a string containing the common name corresponding to the SID structure specified in pSid.</summary>
			[MarshalAs(UnmanagedType.LPWStr)]
			public string pwzCommonName;

			/// <summary>
			/// A pointer to a string describing the SID structure as either a user or a group. The possible values of this string are as
			/// follows: "Computer", "Group", or "User"
			/// </summary>
			[MarshalAs(UnmanagedType.LPWStr)]
			public string pwzClass;

			/// <summary>
			/// A pointer to the user principal name (UPN) corresponding to the SID structure specified in pSid. If a UPN has not been
			/// designated for the SID structure, the value of this parameter is NULL.
			/// </summary>
			[MarshalAs(UnmanagedType.LPWStr)]
			public string pwzUPN;
		}

		/// <summary>
		/// Class contains information about an access right or default access mask for a securable object. The
		/// <see cref="ISecurityInformation.GetAccessRights"/> method uses this class to specify information that the access control editor
		/// uses to initialize its property pages.
		/// </summary>
		[StructLayout(LayoutKind.Sequential, CharSet = CharSet.Unicode)]
		[PInvokeData("aclui.h", MSDNShortId = "aa379603")]
		public sealed class SI_ACCESS : IDisposable
		{
			/// <summary>
			/// A pointer to a GUID structure that identifies the type of object to which the access right or default access mask applies.
			/// The GUID can identify a property set or property on the object, or a type of child object that can be contained by the
			/// object. If this member points to GUID_NULL, the access right applies to the object itself.
			/// </summary>
			public GuidPtr pguid;

			/// <summary>
			/// A bitmask that specifies the access right described by this structure. The mask can contain any combination of standard and
			/// specific rights, but should not contain generic rights such as GENERIC_ALL.
			/// </summary>
			public uint mask;

			/// <summary>A display string that describes the access right.</summary>
			[MarshalAs(UnmanagedType.LPWStr)]
			public string pszName;

			/// <summary>A set of <see cref="INHERIT_FLAGS"/> that indicate where the access right is displayed.</summary>
			public INHERIT_FLAGS dwFlags;

			/// <summary>Initializes a new instance of the <see cref="SI_ACCESS"/> class.</summary>
			/// <param name="mask">The access mask.</param>
			/// <param name="name">The display name.</param>
			/// <param name="flags">The access flags.</param>
			/// <param name="objType">Type of the object.</param>
			public SI_ACCESS(uint mask, string name, INHERIT_FLAGS flags, Guid? objType = null)
			{
				this.mask = mask;
				pszName = name;
				dwFlags = flags;
				if (objType != null)
					ObjectTypeId = objType.Value;
			}

			/// <summary>
			/// The type of object. This member can be <see cref="Guid.Empty"/>. The GUID corresponds to the InheritedObjectType member of an
			/// object-specific ACE.
			/// </summary>
			/// <value>The object type identifier.</value>
			public Guid ObjectTypeId
			{
				get => pguid.Value.GetValueOrDefault();
				set => pguid.Assign(value);
			}

			void IDisposable.Dispose() => pguid.Free();
		}

		/// <summary>
		/// Contains information about how access control entries (ACEs) can be inherited by child objects. The
		/// <see cref="ISecurityInformation.GetInheritTypes"/> method uses this structure to specify display strings that the access control
		/// editor uses to initialize its property pages.
		/// </summary>
		[StructLayout(LayoutKind.Sequential, CharSet = CharSet.Unicode)]
		[PInvokeData("aclui.h", MSDNShortId = "aa379604")]
		public sealed class SI_INHERIT_TYPE : IDisposable
		{
			/// <summary>
			/// A pointer to a GUID structure that identifies the type of child object. This member can be a pointer to GUID_NULL. The GUID
			/// corresponds to the InheritedObjectType member of an object-specific ACE.
			/// </summary>
			public GuidPtr pguid;

			/// <summary>
			/// A set of <see cref="INHERIT_FLAGS"/> that indicate the types of ACEs that can be inherited by the
			/// <see cref="ChildObjectTypeId"/>. These flags correspond to the AceFlags member of an ACE_HEADER structure.
			/// </summary>
			public INHERIT_FLAGS dwFlags;

			/// <summary>A display string that describes the child object.</summary>
			[MarshalAs(UnmanagedType.LPWStr)]
			public string pszName;

			/// <summary>Initializes a new instance of the <see cref="SI_INHERIT_TYPE"/> struct.</summary>
			/// <param name="flags">The inheritance flags.</param>
			/// <param name="name">The display name.</param>
			public SI_INHERIT_TYPE(INHERIT_FLAGS flags, string name)
			{
				dwFlags = flags;
				pszName = name;
			}

			/// <summary>Initializes a new instance of the <see cref="SI_INHERIT_TYPE"/> struct.</summary>
			/// <param name="childObjectType">Type of the child object.</param>
			/// <param name="flags">The inheritance flags.</param>
			/// <param name="name">The display name.</param>
			public SI_INHERIT_TYPE(Guid childObjectType, INHERIT_FLAGS flags, string name) : this(flags, name)
			{
				ChildObjectTypeId = childObjectType;
			}

			/// <summary>
			/// The type of child object. This member can be <see cref="Guid.Empty"/>. The GUID corresponds to the InheritedObjectType member
			/// of an object-specific ACE.
			/// </summary>
			/// <value>The child object type identifier.</value>
			public Guid ChildObjectTypeId
			{
				get => pguid.Value.GetValueOrDefault();
				set => pguid.Assign(value);
			}

			void IDisposable.Dispose() => pguid.Free();
		}
	}
}