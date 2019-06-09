using System;
using System.Linq;
using System.Runtime.InteropServices;
using System.Security.AccessControl;
using System.Text;
using Vanara.Extensions;
using Vanara.InteropServices;
using static Vanara.PInvoke.Kernel32;

namespace Vanara.PInvoke
{
	public static partial class AdvApi32
	{
		/// <summary>Indicates whether the ObjectTypeName and InheritedObjectTypeName members contain strings.</summary>
		[PInvokeData("winnt.h")]
		[Flags]
		public enum AceObjectPresence : uint
		{
			/// <summary>The ObjectTypeName member contains a string.</summary>
			ACE_OBJECT_TYPE_PRESENT = 0x1,

			/// <summary>The InheritedObjectTypeName member contains a string.</summary>
			ACE_INHERITED_OBJECT_TYPE_PRESENT = 0x2
		}

		/// <summary>Used by the <see cref="GetAclInformation(PACL, ref ACL_SIZE_INFORMATION, uint, ACL_INFORMATION_CLASS)"/> function.</summary>
		[PInvokeData("winnt.h")]
		public enum ACL_INFORMATION_CLASS : uint
		{
			/// <summary>Indicates ACL revision information.</summary>
			[CorrespondingType(typeof(ACL_REVISION_INFORMATION))]
			AclRevisionInformation = 1,

			/// <summary>Indicates ACL size information.</summary>
			[CorrespondingType(typeof(ACL_SIZE_INFORMATION))]
			AclSizeInformation
		}

		/// <summary>Flags that affect the behavior of <see cref="CheckTokenMembershipEx"/>.</summary>
		[PInvokeData("winnt.h")]
		[Flags]
		public enum CTMF : uint
		{
			/// <summary>
			/// Allows app containers to pass the call as long as the other requirements of the token are met, such as the group specified is
			/// present and enabled.
			/// </summary>
			CTMF_INCLUDE_APPCONTAINER = 0x00000001,

			/// <summary>Undocumented.</summary>
			CTMF_INCLUDE_LPAC = 0x00000002
		}

		/// <summary>Group attributes.</summary>
		[Flags]
		[PInvokeData("winnt.h")]
		public enum GroupAttributes : uint
		{
			/// <summary>
			/// The SID cannot have the SE_GROUP_ENABLED attribute cleared by a call to the AdjustTokenGroups function. However, you can use
			/// the CreateRestrictedToken function to convert a mandatory SID to a deny-only SID.
			/// </summary>
			SE_GROUP_MANDATORY = 0x00000001,

			/// <summary>The SID is enabled by default.</summary>
			SE_GROUP_ENABLED_BY_DEFAULT = 0x00000002,

			/// <summary>
			/// The SID is enabled for access checks. When the system performs an access check, it checks for access-allowed and
			/// access-denied access control entries (ACEs) that apply to the SID. A SID without this attribute is ignored during an access
			/// check unless the SE_GROUP_USE_FOR_DENY_ONLY attribute is set.
			/// </summary>
			SE_GROUP_ENABLED = 0x00000004,

			/// <summary>
			/// The SID identifies a group account for which the user of the token is the owner of the group, or the SID can be assigned as
			/// the owner of the token or objects.
			/// </summary>
			SE_GROUP_OWNER = 0x00000008,

			/// <summary>
			/// The SID is a deny-only SID in a restricted token. When the system performs an access check, it checks for access-denied ACEs
			/// that apply to the SID; it ignores access-allowed ACEs for the SID. If this attribute is set, SE_GROUP_ENABLED is not set, and
			/// the SID cannot be reenabled.
			/// </summary>
			SE_GROUP_USE_FOR_DENY_ONLY = 0x00000010,

			/// <summary>The SID is a mandatory integrity SID.</summary>
			SE_GROUP_INTEGRITY = 0x00000020,

			/// <summary>The SID is enabled for mandatory integrity checks.</summary>
			SE_GROUP_INTEGRITY_ENABLED = 0x00000040,

			/// <summary>The SID is a logon SID that identifies the logon session associated with an access token.</summary>
			SE_GROUP_LOGON_ID = 0xC0000000,

			/// <summary>The SID identifies a domain-local group.</summary>
			SE_GROUP_RESOURCE = 0x20000000
		}

		/// <summary>
		/// A set of bit flags that indicate whether the <c>ObjectType</c> and <c>InheritedObjectType</c> members are present in an object ACE.
		/// </summary>
		[Flags]
		public enum ObjectAceFlags : uint
		{
			/// <summary>
			/// ObjectType is present and contains a GUID. If this value is not specified, the InheritedObjectType member follows immediately
			/// after the Flags member.
			/// </summary>
			ACE_OBJECT_TYPE_PRESENT = 0x1,

			/// <summary>
			/// InheritedObjectType is present and contains a GUID. If this value is not specified, all types of child objects can inherit
			/// the ACE.
			/// </summary>
			ACE_INHERITED_OBJECT_TYPE_PRESENT = 0x2
		}

		/// <summary>Privilege attributes.</summary>
		[Flags]
		[PInvokeData("winnt.h")]
		public enum PrivilegeAttributes : uint
		{
			/// <summary>The privilege is disabled.</summary>
			SE_PRIVILEGE_DISABLED = 0x00000000,

			/// <summary>The privilege is enabled by default.</summary>
			SE_PRIVILEGE_ENABLED_BY_DEFAULT = 0x00000001,

			/// <summary>The privilege is enabled.</summary>
			SE_PRIVILEGE_ENABLED = 0x00000002,

			/// <summary>Used to remove a privilege. The other privileges in the list are reordered to remain contiguous.</summary>
			SE_PRIVILEGE_REMOVED = 0x00000004,

			/// <summary>
			/// The privilege was used to gain access to an object or service. This flag is used to identify the relevant privileges in a set
			/// passed by a client application that may contain unnecessary privileges.
			/// </summary>
			SE_PRIVILEGE_USED_FOR_ACCESS = 0x80000000
		}

		/// <summary>Flags used by PRIVILEGE_SET.</summary>
		[PInvokeData("winnt.h")]
		public enum PrivilegeSetControl
		{
			/// <summary>The presence of any privileges in the user's access token grants the access.</summary>
			None = 0,

			/// <summary>Indicates that all of the specified privileges must be held by the process requesting access.</summary>
			PRIVILEGE_SET_ALL_NECESSARY = 1
		}

		/// <summary>
		/// A set of bit flags that qualify the meaning of a security descriptor or its components. Each security descriptor has a Control
		/// member that stores the SECURITY_DESCRIPTOR_CONTROL bits.
		/// </summary>
		[Flags]
		public enum SECURITY_DESCRIPTOR_CONTROL : ushort
		{
			/// <summary>
			/// Indicates a required security descriptor in which the discretionary access control list (DACL) is set up to support automatic
			/// propagation of inheritable access control entries (ACEs) to existing child objects.
			/// <para>
			/// For access control lists (ACLs) that support auto inheritance, this bit is always set. Protected servers can call the
			/// ConvertToAutoInheritPrivateObjectSecurity function to convert a security descriptor and set this flag.
			/// </para>
			/// </summary>
			SE_DACL_AUTO_INHERIT_REQ = 0x0100,

			/// <summary>
			/// Indicates a security descriptor in which the discretionary access control list (DACL) is set up to support automatic
			/// propagation of inheritable access control entries (ACEs) to existing child objects.
			/// <para>
			/// For access control lists (ACLs) that support auto inheritance, this bit is always set. Protected servers can call the
			/// ConvertToAutoInheritPrivateObjectSecurity function to convert a security descriptor and set this flag.
			/// </para>
			/// </summary>
			SE_DACL_AUTO_INHERITED = 0x0400,

			/// <summary>
			/// Indicates a security descriptor with a default DACL. For example, if the creator an object does not specify a DACL, the
			/// object receives the default DACL from the access token of the creator. This flag can affect how the system treats the DACL
			/// with respect to ACE inheritance. The system ignores this flag if the SE_DACL_PRESENT flag is not set.
			/// <para>
			/// This flag is used to determine how the final DACL on the object is to be computed and is not stored physically in the
			/// security descriptor control of the securable object.
			/// </para>
			/// <para>To set this flag, use the SetSecurityDescriptorDacl function.</para>
			/// </summary>
			SE_DACL_DEFAULTED = 0x0008,

			/// <summary>
			/// Indicates a security descriptor that has a DACL. If this flag is not set, or if this flag is set and the DACL is NULL, the
			/// security descriptor allows full access to everyone.
			/// <para>
			/// This flag is used to hold the security information specified by a caller until the security descriptor is associated with a
			/// securable object. After the security descriptor is associated with a securable object, the SE_DACL_PRESENT flag is always set
			/// in the security descriptor control.
			/// </para>
			/// <para>To set this flag, use the SetSecurityDescriptorDacl function.</para>
			/// </summary>
			SE_DACL_PRESENT = 0x0004,

			/// <summary>
			/// Prevents the DACL of the security descriptor from being modified by inheritable ACEs. To set this flag, use the
			/// SetSecurityDescriptorControl function.
			/// </summary>
			SE_DACL_PROTECTED = 0x1000,

			/// <summary>
			/// Indicates that the security identifier (SID) of the security descriptor group was provided by a default mechanism. This flag
			/// can be used by a resource manager to identify objects whose security descriptor group was set by a default mechanism. To set
			/// this flag, use the SetSecurityDescriptorGroup function.
			/// </summary>
			SE_GROUP_DEFAULTED = 0x0002,

			/// <summary>
			/// Indicates that the SID of the owner of the security descriptor was provided by a default mechanism. This flag can be used by
			/// a resource manager to identify objects whose owner was set by a default mechanism. To set this flag, use the
			/// SetSecurityDescriptorOwner function.
			/// </summary>
			SE_OWNER_DEFAULTED = 0x0001,

			/// <summary>Indicates that the resource manager control is valid.</summary>
			SE_RM_CONTROL_VALID = 0x4000,

			/// <summary>
			/// Indicates a required security descriptor in which the system access control list (SACL) is set up to support automatic
			/// propagation of inheritable ACEs to existing child objects.
			/// <para>
			/// The system sets this bit when it performs the automatic inheritance algorithm for the object and its existing child objects.
			/// To convert a security descriptor and set this flag, protected servers can call the ConvertToAutoInheritPrivateObjectSecurity function.
			/// </para>
			/// </summary>
			SE_SACL_AUTO_INHERIT_REQ = 0x0200,

			/// <summary>
			/// Indicates a security descriptor in which the system access control list (SACL) is set up to support automatic propagation of
			/// inheritable ACEs to existing child objects.
			/// <para>
			/// The system sets this bit when it performs the automatic inheritance algorithm for the object and its existing child objects.
			/// To convert a security descriptor and set this flag, protected servers can call the ConvertToAutoInheritPrivateObjectSecurity function.
			/// </para>
			/// </summary>
			SE_SACL_AUTO_INHERITED = 0x0800,

			/// <summary>
			/// A default mechanism, rather than the original provider of the security descriptor, provided the SACL. This flag can affect
			/// how the system treats the SACL, with respect to ACE inheritance. The system ignores this flag if the SE_SACL_PRESENT flag is
			/// not set. To set this flag, use the SetSecurityDescriptorSacl function.
			/// </summary>
			SE_SACL_DEFAULTED = 0x0008,

			/// <summary>Indicates a security descriptor that has a SACL. To set this flag, use the SetSecurityDescriptorSacl function.</summary>
			SE_SACL_PRESENT = 0x0010,

			/// <summary>
			/// Prevents the SACL of the security descriptor from being modified by inheritable ACEs. To set this flag, use the
			/// SetSecurityDescriptorControl function.
			/// </summary>
			SE_SACL_PROTECTED = 0x2000,

			/// <summary>
			/// Indicates a self-relative security descriptor. If this flag is not set, the security descriptor is in absolute format. For
			/// more information, see Absolute and Self-Relative Security Descriptors.
			/// </summary>
			SE_SELF_RELATIVE = 0x8000
		}

		/// <summary>
		/// The SECURITY_IMPERSONATION_LEVEL enumeration contains values that specify security impersonation levels. Security impersonation
		/// levels govern the degree to which a server process can act on behalf of a client process.
		/// </summary>
		[PInvokeData("winnt.h")]
		public enum SECURITY_IMPERSONATION_LEVEL
		{
			/// <summary>
			/// The server process cannot obtain identification information about the client, and it cannot impersonate the client. It is
			/// defined with no value given, and thus, by ANSI C rules, defaults to a value of zero.
			/// </summary>
			SecurityAnonymous,

			/// <summary>
			/// The server process can obtain information about the client, such as security identifiers and privileges, but it cannot
			/// impersonate the client. This is useful for servers that export their own objects, for example, database products that export
			/// tables and views. Using the retrieved client-security information, the server can make access-validation decisions without
			/// being able to use other services that are using the client's security context.
			/// </summary>
			SecurityIdentification,

			/// <summary>
			/// The server process can impersonate the client's security context on its local system. The server cannot impersonate the
			/// client on remote systems.
			/// </summary>
			SecurityImpersonation,

			/// <summary>The server process can impersonate the client's security context on remote systems.</summary>
			SecurityDelegation
		}

		/// <summary>A set of bit flags that control how access control entries (ACEs) are inherited from ParentDescriptor.</summary>
		[PInvokeData("winnt.h")]
		[Flags]
		public enum SEF : uint
		{
			/// <summary>
			/// The new discretionary access control list (DACL) contains ACEs inherited from the DACL of ParentDescriptor, as well as any
			/// explicit ACEs specified in the DACL of CreatorDescriptor. If this flag is not set, the new DACL does not inherit ACEs.
			/// </summary>
			SEF_DACL_AUTO_INHERIT = 0x01,

			/// <summary>
			/// The new system access control list (SACL) contains ACEs inherited from the SACL of ParentDescriptor, as well as any explicit
			/// ACEs specified in the SACL of CreatorDescriptor. If this flag is not set, the new SACL does not inherit ACEs.
			/// </summary>
			SEF_SACL_AUTO_INHERIT = 0x02,

			/// <summary>
			/// CreatorDescriptor is the default descriptor for the types of objects specified by ObjectTypes. As such, CreatorDescriptor is
			/// ignored if ParentDescriptor has any object-specific ACEs for the types of objects specified by the ObjectTypes parameter. If
			/// no such ACEs are inherited, CreatorDescriptor is handled as though this flag were not specified.
			/// </summary>
			SEF_DEFAULT_DESCRIPTOR_FOR_OBJECT = 0x04,

			/// <summary>
			/// The function does not perform privilege checking. If the SEF_AVOID_OWNER_CHECK flag is also set, the Token parameter can be
			/// NULL. This flag is useful while implementing automatic inheritance to avoid checking privileges on each child updated.
			/// </summary>
			SEF_AVOID_PRIVILEGE_CHECK = 0x08,

			/// <summary>
			/// The function does not check the validity of the owner in the resultant NewDescriptor as described in the Remarks section. If
			/// the SEF_AVOID_PRIVILEGE_CHECK flag is also set, the Token parameter can be NULL.
			/// </summary>
			SEF_AVOID_OWNER_CHECK = 0x10,

			/// <summary>
			/// The owner of NewDescriptor defaults to the owner from ParentDescriptor. If not set, the owner of NewDescriptor defaults to
			/// the owner of the token specified by the Token parameter. The owner of the token is specified in the token itself. In either
			/// case, if the CreatorDescriptor parameter is not NULL, the NewDescriptor owner is set to the owner from CreatorDescriptor.
			/// </summary>
			SEF_DEFAULT_OWNER_FROM_PARENT = 0x20,

			/// <summary>
			/// The group of NewDescriptor defaults to the group from ParentDescriptor. If not set, the group of NewDescriptor defaults to
			/// the group of the token specified by the Token parameter. The group of the token is specified in the token itself. In either
			/// case, if the CreatorDescriptor parameter is not NULL, the NewDescriptor group is set to the group from CreatorDescriptor.
			/// </summary>
			SEF_DEFAULT_GROUP_FROM_PARENT = 0x40,

			/// <summary>A principal with a mandatory level lower than that of the object cannot write to the object.</summary>
			SEF_MACL_NO_WRITE_UP = 0x100,

			/// <summary>A principal with a mandatory level lower than that of the object cannot read the object.</summary>
			SEF_MACL_NO_READ_UP = 0x200,

			/// <summary>A principal with a mandatory level lower than that of the object cannot execute the object.</summary>
			SEF_MACL_NO_EXECUTE_UP = 0x400,

			/// <summary>Undocumented</summary>
			SEF_AI_USE_EXTRA_PARAMS = 0x800,

			/// <summary>
			/// Any restrictions specified by the ParentDescriptor parameter that would limit the caller's ability to specify a DACL in the
			/// CreatorDescriptor are ignored.
			/// </summary>
			SEF_AVOID_OWNER_RESTRICTION = 0x1000,

			/// <summary>Undocumented</summary>
			SEF_FORCE_USER_MODE = 0x2000
		}

		/// <summary>The SID_NAME_USE enumeration contains values that specify the type of a security identifier (SID).</summary>
		public enum SID_NAME_USE
		{
			/// <summary>A user SID.</summary>
			SidTypeUser = 1,

			/// <summary>A group SID</summary>
			SidTypeGroup,

			/// <summary>A domain SID.</summary>
			SidTypeDomain,

			/// <summary>An alias SID.</summary>
			SidTypeAlias,

			/// <summary>A SID for a well-known group.</summary>
			SidTypeWellKnownGroup,

			/// <summary>A SID for a deleted account.</summary>
			SidTypeDeletedAccount,

			/// <summary>A SID that is not valid.</summary>
			SidTypeInvalid,

			/// <summary>A SID of unknown type/.</summary>
			SidTypeUnknown,

			/// <summary>A SID for a computer.</summary>
			SidTypeComputer,

			/// <summary>A mandatory integrity label SID.</summary>
			SidTypeLabel
		}

		/// <summary>
		/// The access policy for principals with a mandatory integrity level lower than the object associated with the SACL that contains
		/// this ACE.
		/// </summary>
		[PInvokeData("winnt.h")]
		[Flags]
		public enum SYSTEM_MANDATORY_LABEL : uint
		{
			/// <summary>A principal with a lower mandatory level than the object cannot write to the object.</summary>
			SYSTEM_MANDATORY_LABEL_NO_WRITE_UP = 0x1,

			/// <summary>A principal with a lower mandatory level than the object cannot read the object.</summary>
			SYSTEM_MANDATORY_LABEL_NO_READ_UP = 0x2,

			/// <summary>A principal with a lower mandatory level than the object cannot execute the object.</summary>
			SYSTEM_MANDATORY_LABEL_NO_EXECUTE_UP = 0x4,
		}

		/// <summary>
		/// The TOKEN_ELEVATION_TYPE enumeration indicates the elevation type of token being queried by the GetTokenInformation function.
		/// </summary>
		[PInvokeData("winnt.h")]
		public enum TOKEN_ELEVATION_TYPE
		{
			/// <summary>The token does not have a linked token.</summary>
			TokenElevationTypeDefault = 1,

			/// <summary>The token is an elevated token.</summary>
			TokenElevationTypeFull,

			/// <summary>The token is a limited token.</summary>
			TokenElevationTypeLimited
		}

		/// <summary>
		/// The TOKEN_INFORMATION_CLASS enumeration contains values that specify the type of information being assigned to or retrieved from
		/// an access token.
		/// <para>The GetTokenInformation function uses these values to indicate the type of token information to retrieve.</para>
		/// <para>The SetTokenInformation function uses these values to set the token information.</para>
		/// </summary>
		[PInvokeData("winnt.h")]
		public enum TOKEN_INFORMATION_CLASS
		{
			/// <summary>The buffer receives a TOKEN_USER structure that contains the user account of the token.</summary>
			[CorrespondingType(typeof(TOKEN_USER))]
			TokenUser = 1,

			/// <summary>The buffer receives a TOKEN_GROUPS structure that contains the group accounts associated with the token.</summary>
			[CorrespondingType(typeof(TOKEN_GROUPS))]
			TokenGroups,

			/// <summary>The buffer receives a TOKEN_PRIVILEGES structure that contains the privileges of the token.</summary>
			[CorrespondingType(typeof(PTOKEN_PRIVILEGES))]
			TokenPrivileges,

			/// <summary>
			/// The buffer receives a TOKEN_OWNER structure that contains the default owner security identifier (SID) for newly created objects.
			/// </summary>
			[CorrespondingType(typeof(TOKEN_OWNER))]
			TokenOwner,

			/// <summary>
			/// The buffer receives a TOKEN_PRIMARY_GROUP structure that contains the default primary group SID for newly created objects.
			/// </summary>
			[CorrespondingType(typeof(TOKEN_PRIMARY_GROUP))]
			TokenPrimaryGroup,

			/// <summary>The buffer receives a TOKEN_DEFAULT_DACL structure that contains the default DACL for newly created objects.</summary>
			[CorrespondingType(typeof(TOKEN_DEFAULT_DACL))]
			TokenDefaultDacl,

			/// <summary>
			/// The buffer receives a TOKEN_SOURCE structure that contains the source of the token. TOKEN_QUERY_SOURCE access is needed to
			/// retrieve this information.
			/// </summary>
			[CorrespondingType(typeof(TOKEN_SOURCE))]
			TokenSource,

			/// <summary>The buffer receives a TOKEN_TYPE value that indicates whether the token is a primary or impersonation token.</summary>
			[CorrespondingType(typeof(TOKEN_TYPE))]
			TokenType,

			/// <summary>
			/// The buffer receives a SECURITY_IMPERSONATION_LEVEL value that indicates the impersonation level of the token. If the access
			/// token is not an impersonation token, the function fails.
			/// </summary>
			[CorrespondingType(typeof(SECURITY_IMPERSONATION_LEVEL))]
			TokenImpersonationLevel,

			/// <summary>The buffer receives a TOKEN_STATISTICS structure that contains various token statistics.</summary>
			[CorrespondingType(typeof(TOKEN_STATISTICS))]
			TokenStatistics,

			/// <summary>The buffer receives a TOKEN_GROUPS structure that contains the list of restricting SIDs in a restricted token.</summary>
			[CorrespondingType(typeof(TOKEN_GROUPS))]
			TokenRestrictedSids,

			/// <summary>
			/// The buffer receives a DWORD value that indicates the Terminal Services session identifier that is associated with the token.
			/// <para>If the token is associated with the terminal server client session, the session identifier is nonzero.</para>
			/// <para>
			/// Windows Server 2003 and Windows XP: If the token is associated with the terminal server console session, the session
			/// identifier is zero.
			/// </para>
			/// <para>In a non-Terminal Services environment, the session identifier is zero.</para>
			/// <para>
			/// If TokenSessionId is set with SetTokenInformation, the application must have the Act As Part Of the Operating System
			/// privilege, and the application must be enabled to set the session ID in a token.
			/// </para>
			/// </summary>
			[CorrespondingType(typeof(uint))]
			TokenSessionId,

			/// <summary>
			/// The buffer receives a TOKEN_GROUPS_AND_PRIVILEGES structure that contains the user SID, the group accounts, the restricted
			/// SIDs, and the authentication ID associated with the token.
			/// </summary>
			[CorrespondingType(typeof(TOKEN_GROUPS_AND_PRIVILEGES))]
			TokenGroupsAndPrivileges,

			/// <summary>Reserved.</summary>
			[CorrespondingType(CorrepsondingAction.Exception)]
			TokenSessionReference,

			/// <summary>The buffer receives a DWORD value that is nonzero if the token includes the SANDBOX_INERT flag.</summary>
			[CorrespondingType(typeof(uint))]
			TokenSandBoxInert,

			/// <summary>Reserved.</summary>
			[CorrespondingType(CorrepsondingAction.Exception)]
			TokenAuditPolicy,

			/// <summary>
			/// The buffer receives a TOKEN_ORIGIN value.
			/// <para>
			/// If the token resulted from a logon that used explicit credentials, such as passing a name, domain, and password to the
			/// LogonUser function, then the TOKEN_ORIGIN structure will contain the ID of the logon session that created it.
			/// </para>
			/// <para>
			/// If the token resulted from network authentication, such as a call to AcceptSecurityContext or a call to LogonUser with
			/// dwLogonType set to LOGON32_LOGON_NETWORK or LOGON32_LOGON_NETWORK_CLEARTEXT, then this value will be zero.
			/// </para>
			/// </summary>
			[CorrespondingType(typeof(TOKEN_ORIGIN))]
			TokenOrigin,

			/// <summary>The buffer receives a TOKEN_ELEVATION_TYPE value that specifies the elevation level of the token.</summary>
			[CorrespondingType(typeof(TOKEN_ELEVATION_TYPE))]
			TokenElevationType,

			/// <summary>
			/// The buffer receives a TOKEN_LINKED_TOKEN structure that contains a handle to another token that is linked to this token.
			/// </summary>
			[CorrespondingType(typeof(TOKEN_LINKED_TOKEN))]
			TokenLinkedToken,

			/// <summary>The buffer receives a TOKEN_ELEVATION structure that specifies whether the token is elevated.</summary>
			[CorrespondingType(typeof(TOKEN_ELEVATION))]
			TokenElevation,

			/// <summary>The buffer receives a DWORD value that is nonzero if the token has ever been filtered.</summary>
			[CorrespondingType(typeof(uint))]
			TokenHasRestrictions,

			/// <summary>
			/// The buffer receives a TOKEN_ACCESS_INFORMATION structure that specifies security information contained in the token.
			/// </summary>
			[CorrespondingType(typeof(TOKEN_ACCESS_INFORMATION))]
			TokenAccessInformation,

			/// <summary>The buffer receives a DWORD value that is nonzero if virtualization is allowed for the token.</summary>
			[CorrespondingType(typeof(uint))]
			TokenVirtualizationAllowed,

			/// <summary>The buffer receives a DWORD value that is nonzero if virtualization is enabled for the token.</summary>
			[CorrespondingType(typeof(uint))]
			TokenVirtualizationEnabled,

			/// <summary>The buffer receives a TOKEN_MANDATORY_LABEL structure that specifies the token's integrity level.</summary>
			[CorrespondingType(typeof(TOKEN_MANDATORY_LABEL))]
			TokenIntegrityLevel,

			/// <summary>The buffer receives a DWORD value that is nonzero if the token has the UIAccess flag set.</summary>
			[CorrespondingType(typeof(uint))]
			TokenUIAccess,

			/// <summary>The buffer receives a TOKEN_MANDATORY_POLICY structure that specifies the token's mandatory integrity policy.</summary>
			[CorrespondingType(typeof(TOKEN_MANDATORY_POLICY))]
			TokenMandatoryPolicy,

			/// <summary>The buffer receives a TOKEN_GROUPS structure that specifies the token's logon SID.</summary>
			[CorrespondingType(typeof(TOKEN_GROUPS))]
			TokenLogonSid,

			/// <summary>
			/// The buffer receives a DWORD value that is nonzero if the token is an application container token. Any callers who check the
			/// TokenIsAppContainer and have it return 0 should also verify that the caller token is not an identify level impersonation
			/// token. If the current token is not an application container but is an identity level token, you should return AccessDenied.
			/// </summary>
			[CorrespondingType(typeof(uint))]
			TokenIsAppContainer,

			/// <summary>The buffer receives a TOKEN_GROUPS structure that contains the capabilities associated with the token.</summary>
			[CorrespondingType(typeof(TOKEN_GROUPS))]
			TokenCapabilities,

			/// <summary>
			/// The buffer receives a TOKEN_APPCONTAINER_INFORMATION structure that contains the AppContainerSid associated with the token.
			/// If the token is not associated with an application container, the TokenAppContainer member of the
			/// TOKEN_APPCONTAINER_INFORMATION structure points to NULL.
			/// </summary>
			[CorrespondingType(typeof(TOKEN_APPCONTAINER_INFORMATION))]
			TokenAppContainerSid,

			/// <summary>
			/// The buffer receives a DWORD value that includes the application container number for the token. For tokens that are not
			/// application container tokens, this value is zero.
			/// </summary>
			[CorrespondingType(typeof(uint))]
			TokenAppContainerNumber,

			/// <summary>
			/// The buffer receives a CLAIM_SECURITY_ATTRIBUTES_INFORMATION structure that contains the user claims associated with the token.
			/// </summary>
			[CorrespondingType(typeof(CLAIM_SECURITY_ATTRIBUTES_INFORMATION))]
			TokenUserClaimAttributes,

			/// <summary>
			/// The buffer receives a CLAIM_SECURITY_ATTRIBUTES_INFORMATION structure that contains the device claims associated with the token.
			/// </summary>
			[CorrespondingType(typeof(CLAIM_SECURITY_ATTRIBUTES_INFORMATION))]
			TokenDeviceClaimAttributes,

			/// <summary>This value is reserved.</summary>
			[CorrespondingType(CorrepsondingAction.Exception)]
			TokenRestrictedUserClaimAttributes,

			/// <summary>This value is reserved.</summary>
			[CorrespondingType(CorrepsondingAction.Exception)]
			TokenRestrictedDeviceClaimAttributes,

			/// <summary>The buffer receives a TOKEN_GROUPS structure that contains the device groups that are associated with the token.</summary>
			[CorrespondingType(typeof(TOKEN_GROUPS))]
			TokenDeviceGroups,

			/// <summary>
			/// The buffer receives a TOKEN_GROUPS structure that contains the restricted device groups that are associated with the token.
			/// </summary>
			[CorrespondingType(typeof(TOKEN_GROUPS))]
			TokenRestrictedDeviceGroups,

			/// <summary>This value is reserved.</summary>
			[CorrespondingType(CorrepsondingAction.Exception)]
			TokenSecurityAttributes,

			/// <summary>This value is reserved.</summary>
			[CorrespondingType(CorrepsondingAction.Exception)]
			TokenIsRestricted
		}

		/// <summary>The TOKEN_TYPE enumeration contains values that differentiate between a primary token and an impersonation token.</summary>
		[Serializable]
		[PInvokeData("winnt.h")]
		public enum TOKEN_TYPE
		{
			/// <summary>Indicates a primary token.</summary>
			TokenPrimary = 1,

			/// <summary>Indicates an impersonation token.</summary>
			TokenImpersonation = 2
		}

		/// <summary>Token access flags.</summary>
		[Flags]
		[PInvokeData("winnt.h")]
		public enum TokenAccess : uint
		{
			/// <summary>
			/// Required to attach a primary token to a process. The SE_ASSIGNPRIMARYTOKEN_NAME privilege is also required to accomplish this task.
			/// </summary>
			TOKEN_ASSIGN_PRIMARY = 0x0001,

			/// <summary>Required to duplicate an access token.</summary>
			TOKEN_DUPLICATE = 0x0002,

			/// <summary>Required to attach an impersonation access token to a process.</summary>
			TOKEN_IMPERSONATE = 0x0004,

			/// <summary>Required to query an access token.</summary>
			TOKEN_QUERY = 0x0008,

			/// <summary>Required to query the source of an access token.</summary>
			TOKEN_QUERY_SOURCE = 0x0010,

			/// <summary>Required to enable or disable the privileges in an access token.</summary>
			TOKEN_ADJUST_PRIVILEGES = 0x0020,

			/// <summary>Required to adjust the attributes of the groups in an access token.</summary>
			TOKEN_ADJUST_GROUPS = 0x0040,

			/// <summary>Required to change the default owner, primary group, or DACL of an access token.</summary>
			TOKEN_ADJUST_DEFAULT = 0x0080,

			/// <summary>Required to adjust the session ID of an access token. The SE_TCB_NAME privilege is required.</summary>
			TOKEN_ADJUST_SESSIONID = 0x0100,

			/// <summary>The token all access p</summary>
			TOKEN_ALL_ACCESS_P = 0x000F00FF,

			/// <summary>Combines all possible access rights for a token.</summary>
			TOKEN_ALL_ACCESS = 0x000F01FF,

			/// <summary>Combines STANDARD_RIGHTS_READ and TOKEN_QUERY.</summary>
			TOKEN_READ = 0x00020008,

			/// <summary>Combines STANDARD_RIGHTS_WRITE, TOKEN_ADJUST_PRIVILEGES, TOKEN_ADJUST_GROUPS, and TOKEN_ADJUST_DEFAULT.</summary>
			TOKEN_WRITE = 0x000200E0,

			/// <summary>Combines STANDARD_RIGHTS_EXECUTE and TOKEN_IMPERSONATE.</summary>
			TOKEN_EXECUTE = 0x00020000
		}

		/// <summary>
		/// <para>
		/// The <c>WELL_KNOWN_SID_TYPE</c> enumeration is a list of commonly used security identifiers (SIDs). Programs can pass these values
		/// to the CreateWellKnownSid function to create a SID from this list.
		/// </para>
		/// </summary>
		// https://docs.microsoft.com/en-us/windows/desktop/api/winnt/ne-winnt-well_known_sid_type
		[PInvokeData("winnt.h", MSDNShortId = "6f1fa59e-17c0-412b-937b-ddf746ed68bd")]
		public enum WELL_KNOWN_SID_TYPE
		{
			/// <summary>Indicates a null SID.</summary>
			WinNullSid,

			/// <summary>Indicates a SID that matches everyone.</summary>
			WinWorldSid,

			/// <summary>Indicates a local SID.</summary>
			WinLocalSid,

			/// <summary>Indicates a SID that matches the owner or creator of an object.</summary>
			WinCreatorOwnerSid,

			/// <summary>Indicates a SID that matches the creator group of an object.</summary>
			WinCreatorGroupSid,

			/// <summary>Indicates a creator owner server SID.</summary>
			WinCreatorOwnerServerSid,

			/// <summary>Indicates a creator group server SID.</summary>
			WinCreatorGroupServerSid,

			/// <summary>Indicates a SID for the Windows NT authority account.</summary>
			WinNtAuthoritySid,

			/// <summary>Indicates a SID for a dial-up account.</summary>
			WinDialupSid,

			/// <summary>
			/// Indicates a SID for a network account. This SID is added to the process of a token when it logs on across a network. The
			/// corresponding logon type is LOGON32_LOGON_NETWORK.
			/// </summary>
			WinNetworkSid,

			/// <summary>
			/// Indicates a SID for a batch process. This SID is added to the process of a token when it logs on as a batch job. The
			/// corresponding logon type is LOGON32_LOGON_BATCH.
			/// </summary>
			WinBatchSid,

			/// <summary>
			/// Indicates a SID for an interactive account. This SID is added to the process of a token when it logs on interactively. The
			/// corresponding logon type is LOGON32_LOGON_INTERACTIVE.
			/// </summary>
			WinInteractiveSid,

			/// <summary>
			/// Indicates a SID for a service. This SID is added to the process of a token when it logs on as a service. The corresponding
			/// logon type is LOGON32_LOGON_SERVICE.
			/// </summary>
			WinServiceSid,

			/// <summary>Indicates a SID for the anonymous account.</summary>
			WinAnonymousSid,

			/// <summary>Indicates a proxy SID.</summary>
			WinProxySid,

			/// <summary>Indicates a SID for an enterprise controller.</summary>
			WinEnterpriseControllersSid,

			/// <summary>Indicates a SID for self.</summary>
			WinSelfSid,

			/// <summary>Indicates a SID that matches any authenticated user.</summary>
			WinAuthenticatedUserSid,

			/// <summary>Indicates a SID for restricted code.</summary>
			WinRestrictedCodeSid,

			/// <summary>Indicates a SID that matches a terminal server account.</summary>
			WinTerminalServerSid,

			/// <summary>Indicates a SID that matches remote logons.</summary>
			WinRemoteLogonIdSid,

			/// <summary>Indicates a SID that matches logon IDs.</summary>
			WinLogonIdsSid,

			/// <summary>Indicates a SID that matches the local system.</summary>
			WinLocalSystemSid,

			/// <summary>Indicates a SID that matches a local service.</summary>
			WinLocalServiceSid,

			/// <summary>Indicates a SID that matches a network service.</summary>
			WinNetworkServiceSid,

			/// <summary>Indicates a SID that matches the domain account.</summary>
			WinBuiltinDomainSid,

			/// <summary>Indicates a SID that matches the administrator group.</summary>
			WinBuiltinAdministratorsSid,

			/// <summary>Indicates a SID that matches built-in user accounts.</summary>
			WinBuiltinUsersSid,

			/// <summary>Indicates a SID that matches the guest account.</summary>
			WinBuiltinGuestsSid,

			/// <summary>Indicates a SID that matches the power users group.</summary>
			WinBuiltinPowerUsersSid,

			/// <summary>Indicates a SID that matches the account operators account.</summary>
			WinBuiltinAccountOperatorsSid,

			/// <summary>Indicates a SID that matches the system operators group.</summary>
			WinBuiltinSystemOperatorsSid,

			/// <summary>Indicates a SID that matches the print operators group.</summary>
			WinBuiltinPrintOperatorsSid,

			/// <summary>Indicates a SID that matches the backup operators group.</summary>
			WinBuiltinBackupOperatorsSid,

			/// <summary>Indicates a SID that matches the replicator account.</summary>
			WinBuiltinReplicatorSid,

			/// <summary>Indicates a SID that matches pre-Windows 2000 compatible accounts.</summary>
			WinBuiltinPreWindows2000CompatibleAccessSid,

			/// <summary>Indicates a SID that matches remote desktop users.</summary>
			WinBuiltinRemoteDesktopUsersSid,

			/// <summary>Indicates a SID that matches the network operators group.</summary>
			WinBuiltinNetworkConfigurationOperatorsSid,

			/// <summary>Indicates a SID that matches the account administrator's account.</summary>
			WinAccountAdministratorSid,

			/// <summary>Indicates a SID that matches the account guest group.</summary>
			WinAccountGuestSid,

			/// <summary>Indicates a SID that matches account Kerberos target group.</summary>
			WinAccountKrbtgtSid,

			/// <summary>Indicates a SID that matches the account domain administrator group.</summary>
			WinAccountDomainAdminsSid,

			/// <summary>Indicates a SID that matches the account domain users group.</summary>
			WinAccountDomainUsersSid,

			/// <summary>Indicates a SID that matches the account domain guests group.</summary>
			WinAccountDomainGuestsSid,

			/// <summary>Indicates a SID that matches the account computer group.</summary>
			WinAccountComputersSid,

			/// <summary>Indicates a SID that matches the account controller group.</summary>
			WinAccountControllersSid,

			/// <summary>Indicates a SID that matches the certificate administrators group.</summary>
			WinAccountCertAdminsSid,

			/// <summary>Indicates a SID that matches the schema administrators group.</summary>
			WinAccountSchemaAdminsSid,

			/// <summary>Indicates a SID that matches the enterprise administrators group.</summary>
			WinAccountEnterpriseAdminsSid,

			/// <summary>Indicates a SID that matches the policy administrators group.</summary>
			WinAccountPolicyAdminsSid,

			/// <summary>Indicates a SID that matches the RAS and IAS server account.</summary>
			WinAccountRasAndIasServersSid,

			/// <summary>Indicates a SID present when the Microsoft NTLM authentication package authenticated the client.</summary>
			WinNTLMAuthenticationSid,

			/// <summary>Indicates a SID present when the Microsoft Digest authentication package authenticated the client.</summary>
			WinDigestAuthenticationSid,

			/// <summary>Indicates a SID present when the Secure Channel (SSL/TLS) authentication package authenticated the client.</summary>
			WinSChannelAuthenticationSid,

			/// <summary>
			/// Indicates a SID present when the user authenticated from within the forest or across a trust that does not have the selective
			/// authentication option enabled. If this SID is present, then WinOtherOrganizationSid cannot be present.
			/// </summary>
			WinThisOrganizationSid,

			/// <summary>
			/// Indicates a SID present when the user authenticated across a forest with the selective authentication option enabled. If this
			/// SID is present, then WinThisOrganizationSid cannot be present.
			/// </summary>
			WinOtherOrganizationSid,

			/// <summary>
			/// Indicates a SID that allows a user to create incoming forest trusts. It is added to the token of users who are a member of
			/// the Incoming Forest Trust Builders built-in group in the root domain of the forest.
			/// </summary>
			WinBuiltinIncomingForestTrustBuildersSid,

			/// <summary>Indicates a SID that matches the performance monitor user group.</summary>
			WinBuiltinPerfMonitoringUsersSid,

			/// <summary>Indicates a SID that matches the performance log user group.</summary>
			WinBuiltinPerfLoggingUsersSid,

			/// <summary>Indicates a SID that matches the Windows Authorization Access group.</summary>
			WinBuiltinAuthorizationAccessSid,

			/// <summary>Indicates a SID is present in a server that can issue terminal server licenses.</summary>
			WinBuiltinTerminalServerLicenseServersSid,

			/// <summary>Indicates a SID that matches the distributed COM user group.</summary>
			WinBuiltinDCOMUsersSid,

			/// <summary>Indicates a SID that matches the Internet built-in user group.</summary>
			WinBuiltinIUsersSid,

			/// <summary>Indicates a SID that matches the Internet user group.</summary>
			WinIUserSid,

			/// <summary>
			/// Indicates a SID that allows a user to use cryptographic operations. It is added to the token of users who are a member of the
			/// CryptoOperators built-in group.
			/// </summary>
			WinBuiltinCryptoOperatorsSid,

			/// <summary>Indicates a SID that matches an untrusted label.</summary>
			WinUntrustedLabelSid,

			/// <summary>Indicates a SID that matches an low level of trust label.</summary>
			WinLowLabelSid,

			/// <summary>Indicates a SID that matches an medium level of trust label.</summary>
			WinMediumLabelSid,

			/// <summary>Indicates a SID that matches a high level of trust label.</summary>
			WinHighLabelSid,

			/// <summary>Indicates a SID that matches a system label.</summary>
			WinSystemLabelSid,

			/// <summary>Indicates a SID that matches a write restricted code group.</summary>
			WinWriteRestrictedCodeSid,

			/// <summary>Indicates a SID that matches a creator and owner rights group.</summary>
			WinCreatorOwnerRightsSid,

			/// <summary>Indicates a SID that matches a cacheable principals group.</summary>
			WinCacheablePrincipalsGroupSid,

			/// <summary>Indicates a SID that matches a non-cacheable principals group.</summary>
			WinNonCacheablePrincipalsGroupSid,

			/// <summary>Indicates a SID that matches an enterprise wide read-only controllers group.</summary>
			WinEnterpriseReadonlyControllersSid,

			/// <summary>Indicates a SID that matches an account read-only controllers group.</summary>
			WinAccountReadonlyControllersSid,

			/// <summary>Indicates a SID that matches an event log readers group.</summary>
			WinBuiltinEventLogReadersGroup,

			/// <summary>Indicates a SID that matches a read-only enterprise domain controller.</summary>
			WinNewEnterpriseReadonlyControllersSid,

			/// <summary>Indicates a SID that matches the built-in DCOM certification services access group.</summary>
			WinBuiltinCertSvcDComAccessGroup,

			/// <summary>
			/// Indicates a SID that matches the medium plus integrity label. Windows Server 2008 R2, Windows 7, Windows Server 2008, Windows
			/// Vista, Windows Server 2003 and Windows XP: This value is not available.
			/// </summary>
			WinMediumPlusLabelSid,

			/// <summary>
			/// Indicates a SID that matches a local logon group. Windows Server 2008 R2, Windows 7, Windows Server 2008, Windows Vista,
			/// Windows Server 2003 and Windows XP: This value is not available.
			/// </summary>
			WinLocalLogonSid,

			/// <summary>
			/// Indicates a SID that matches a console logon group. Windows Server 2008 R2, Windows 7, Windows Server 2008, Windows Vista,
			/// Windows Server 2003 and Windows XP: This value is not available.
			/// </summary>
			WinConsoleLogonSid,

			/// <summary>Undocumented</summary>
			WinThisOrganizationCertificateSid,

			/// <summary>
			/// Indicates a SID that matches the application package authority. Windows Server 2008 R2, Windows 7, Windows Server 2008,
			/// Windows Vista, Windows Server 2003 and Windows XP: This value is not available.
			/// </summary>
			WinApplicationPackageAuthoritySid,

			/// <summary>Undocumented</summary>
			WinBuiltinAnyPackageSid,

			/// <summary>
			/// Indicates a SID of Internet client capability for app containers. Windows Server 2008 R2, Windows 7, Windows Server 2008,
			/// Windows Vista, Windows Server 2003 and Windows XP: This value is not available.
			/// </summary>
			WinCapabilityInternetClientSid,

			/// <summary>Undocumented</summary>
			WinCapabilityInternetClientServerSid,

			/// <summary>
			/// Indicates a SID of private network client and server capability for app containers. Windows Server 2008 R2, Windows 7,
			/// Windows Server 2008, Windows Vista, Windows Server 2003 and Windows XP: This value is not available.
			/// </summary>
			WinCapabilityPrivateNetworkClientServerSid,

			/// <summary>Undocumented</summary>
			WinCapabilityPicturesLibrarySid,

			/// <summary>
			/// Indicates a SID for videos library capability for app containers. Windows Server 2008 R2, Windows 7, Windows Server 2008,
			/// Windows Vista, Windows Server 2003 and Windows XP: This value is not available.
			/// </summary>
			WinCapabilityVideosLibrarySid,

			/// <summary>Undocumented</summary>
			WinCapabilityMusicLibrarySid,

			/// <summary>
			/// Indicates a SID for documents library capability for app containers. Windows Server 2008 R2, Windows 7, Windows Server 2008,
			/// Windows Vista, Windows Server 2003 and Windows XP: This value is not available.
			/// </summary>
			WinCapabilityDocumentsLibrarySid,

			/// <summary>Undocumented</summary>
			WinCapabilitySharedUserCertificatesSid,

			/// <summary>
			/// Indicates a SID for Windows credentials capability for app containers. Windows Server 2008 R2, Windows 7, Windows Server
			/// 2008, Windows Vista, Windows Server 2003 and Windows XP: This value is not available.
			/// </summary>
			WinCapabilityEnterpriseAuthenticationSid,

			/// <summary>Undocumented</summary>
			WinCapabilityRemovableStorageSid,

			/// <summary/>
			WinBuiltinRDSRemoteAccessServersSid,

			/// <summary/>
			WinBuiltinRDSEndpointServersSid,

			/// <summary/>
			WinBuiltinRDSManagementServersSid,

			/// <summary/>
			WinUserModeDriversSid,

			/// <summary/>
			WinBuiltinHyperVAdminsSid,

			/// <summary/>
			WinAccountCloneableControllersSid,

			/// <summary/>
			WinBuiltinAccessControlAssistanceOperatorsSid,

			/// <summary/>
			WinBuiltinRemoteManagementUsersSid,

			/// <summary/>
			WinAuthenticationAuthorityAssertedSid,

			/// <summary/>
			WinAuthenticationServiceAssertedSid,

			/// <summary/>
			WinLocalAccountSid,

			/// <summary/>
			WinLocalAccountAndAdministratorSid,

			/// <summary/>
			WinAccountProtectedUsersSid,

			/// <summary/>
			WinCapabilityAppointmentsSid,

			/// <summary/>
			WinCapabilityContactsSid,

			/// <summary/>
			WinAccountDefaultSystemManagedSid,

			/// <summary/>
			WinBuiltinDefaultSystemManagedGroupSid,

			/// <summary/>
			WinBuiltinStorageReplicaAdminsSid,

			/// <summary/>
			WinAccountKeyAdminsSid,

			/// <summary/>
			WinAccountEnterpriseKeyAdminsSid,

			/// <summary/>
			WinAuthenticationKeyTrustSid,

			/// <summary/>
			WinAuthenticationKeyPropertyMFASid,

			/// <summary/>
			WinAuthenticationKeyPropertyAttestationSid,

			/// <summary/>
			WinAuthenticationFreshKeyAuthSid,

			/// <summary/>
			WinBuiltinDeviceOwnersSid,
		}

		/// <summary>Gets the Flags for an ACE, if defined.</summary>
		/// <param name="pAce">A pointer to an ACE.</param>
		/// <returns>The Flags value, if this is an object ACE, otherwise <see langword="null"/>.</returns>
		/// <exception cref="System.ArgumentNullException">pAce</exception>
		public static ObjectAceFlags? GetFlags(this PACE pAce)
		{
			if (pAce.IsNull) throw new ArgumentNullException(nameof(pAce));
			return !pAce.IsObjectAce() ? null : (ObjectAceFlags?)pAce.DangerousGetHandle().ToStructure<ACCESS_ALLOWED_OBJECT_ACE>().Flags;
		}

		/// <summary>Gets the header for an ACE.</summary>
		/// <param name="pAce">A pointer to an ACE.</param>
		/// <returns>The <see cref="ACE_HEADER"/> value.</returns>
		/// <exception cref="System.ArgumentNullException">pAce</exception>
		public static ACE_HEADER GetHeader(this PACE pAce) => !pAce.IsNull ? pAce.DangerousGetHandle().ToStructure<ACE_HEADER>() : throw new ArgumentNullException(nameof(pAce));

		/// <summary>Gets the InheritedObjectType for an ACE, if defined.</summary>
		/// <param name="pAce">A pointer to an ACE.</param>
		/// <returns>The InheritedObjectType value, if this is an object ACE, otherwise <see langword="null"/>.</returns>
		/// <exception cref="System.ArgumentNullException">pAce</exception>
		public static Guid? GetInheritedObjectType(this PACE pAce)
		{
			if (pAce.IsNull) throw new ArgumentNullException(nameof(pAce));
			return !pAce.IsObjectAce() ? null : (Guid?)pAce.DangerousGetHandle().ToStructure<ACCESS_ALLOWED_OBJECT_ACE>().InheritedObjectType;
		}

		/// <summary>Gets the mask for an ACE.</summary>
		/// <param name="pAce">A pointer to an ACE.</param>
		/// <returns>The ACCESS_MASK value.</returns>
		/// <exception cref="System.ArgumentNullException">pAce</exception>
		public static uint GetMask(this PACE pAce) => !pAce.IsNull ? pAce.DangerousGetHandle().ToStructure<ACCESS_ALLOWED_ACE>().Mask : throw new ArgumentNullException(nameof(pAce));

		/// <summary>Gets the ObjectType for an ACE, if defined.</summary>
		/// <param name="pAce">A pointer to an ACE.</param>
		/// <returns>The ObjectType value, if this is an object ACE, otherwise <see langword="null"/>.</returns>
		/// <exception cref="System.ArgumentNullException">pAce</exception>
		public static Guid? GetObjectType(this PACE pAce)
		{
			if (pAce.IsNull) throw new ArgumentNullException(nameof(pAce));
			return !pAce.IsObjectAce() ? null : (Guid?)pAce.DangerousGetHandle().ToStructure<ACCESS_ALLOWED_OBJECT_ACE>().ObjectType;
		}

		/// <summary>Gets the SID for an ACE.</summary>
		/// <param name="pAce">A pointer to an ACE.</param>
		/// <returns>The SID value.</returns>
		/// <exception cref="System.ArgumentNullException">pAce</exception>
		public static SafePSID GetSid(this PACE pAce)
		{
			if (pAce.IsNull) throw new ArgumentNullException(nameof(pAce));
			var offset = Marshal.SizeOf(typeof(ACE_HEADER)) + sizeof(uint);
			if (pAce.IsObjectAce()) offset += sizeof(uint) + Marshal.SizeOf(typeof(Guid)) * 2;
			unsafe
			{
				return SafePSID.CreateFromPtr((IntPtr)((byte*)pAce.DangerousGetHandle() + offset));
			}
		}

		/// <summary>Determines if a ACE is an object ACE.</summary>
		/// <param name="pAce">A pointer to an ACE.</param>
		/// <returns><see langword="true"/> if is this is an object ACE; otherwise, <see langword="false"/>.</returns>
		/// <exception cref="System.ArgumentNullException">pAce</exception>
		/// <exception cref="System.ArgumentOutOfRangeException">pAce - Unknown ACE type.</exception>
		public static bool IsObjectAce(this PACE pAce)
		{
			if (pAce.IsNull) throw new ArgumentNullException(nameof(pAce));
			var aceType = (byte)GetHeader(pAce).AceType;
			if (aceType > 0x15) throw new ArgumentOutOfRangeException(nameof(pAce), "Unknown ACE type.");
			return (aceType >= 0x5 && aceType <= 0x8) || aceType == 0xB || aceType == 0xC || aceType == 0xF || aceType == 0x10;
		}

		/// <summary>
		/// The ACCESS_ALLOWED_ACE structure defines an access control entry (ACE) for the discretionary access control list (DACL) that
		/// controls access to an object. An access-allowed ACE allows access to an object for a specific trustee identified by a security
		/// identifier (SID).
		/// </summary>
		[StructLayout(LayoutKind.Sequential)]
		[PInvokeData("Winnt.h", MSDNShortId = "aa374847")]
		public struct ACCESS_ALLOWED_ACE
		{
			/// <summary>
			/// ACE_HEADER structure that specifies the size and type of ACE. It also contains flags that control inheritance of the ACE by
			/// child objects. The AceType member of the ACE_HEADER structure should be set to ACCESS_ALLOWED_ACE_TYPE, and the AceSize
			/// member should be set to the total number of bytes allocated for the ACCESS_ALLOWED_ACE structure.
			/// </summary>
			public ACE_HEADER Header;

			/// <summary>Specifies an ACCESS_MASK structure that specifies the access rights granted by this ACE.</summary>
			public uint Mask;

			/// <summary>
			/// The first DWORD of a trustee's SID. The remaining bytes of the SID are stored in contiguous memory after the SidStart member.
			/// This SID can be appended with application data.
			/// </summary>
			public uint SidStart;
		}

		/// <summary>
		/// The <c>ACCESS_ALLOWED_OBJECT_ACE</c> structure defines an access control entry (ACE) that controls allowed access to an object, a
		/// property set, or property. The ACE contains a set of access rights, a <c>GUID</c> that identifies the type of object, and a
		/// security identifier (SID) that identifies the trustee to whom the system will grant access. The ACE also contains a <c>GUID</c>
		/// and a set of flags that control inheritance of the ACE by child objects.
		/// </summary>
		/// <remarks>
		/// <para>
		/// If neither the <c>ObjectType</c> nor <c>InheritedObjectType</c> GUID is specified, the <c>ACCESS_ALLOWED_OBJECT_ACE</c> structure
		/// has the same semantics as those used by the ACCESS_ALLOWED_ACE structure. In that case, use the <c>ACCESS_ALLOWED_ACE</c>
		/// structure because it is smaller and more efficient.
		/// </para>
		/// <para>An ACL that contains an <c>ACCESS_ALLOWED_OBJECT_ACE</c> must specify the ACL_REVISION_DS revision number in its ACL header.</para>
		/// <para>
		/// The access rights specified by the <c>Mask</c> member are granted to any trustee that possesses an enabled SID that matches the
		/// SID stored in the <c>SidStart</c> member.
		/// </para>
		/// <para>
		/// An <c>ACCESS_ALLOWED_OBJECT_ACE</c> structure can be created in an access control list (ACL) by a call to the
		/// AddAccessAllowedObjectAce function. When this function is used, the correct amount of memory needed to accommodate the GUID
		/// structures in the <c>ObjectType</c> and <c>InheritedObjectType</c> members, if one or both of them exists, as well as to
		/// accommodate the trustee's SID is automatically allocated. In addition, the values of the <c>Header.AceType</c> and
		/// <c>Header.AceSize</c> members are set automatically. When an <c>ACCESS_ALLOWED_OBJECT_ACE</c> structure is created outside an
		/// ACL, sufficient memory must be allocated to accommodate the GUID structures in the <c>ObjectType</c> and
		/// <c>InheritedObjectType</c> members, if one or both of them exists, as well as to accommodate the complete SID of the trustee in
		/// the <c>SidStart</c> member and the contiguous memory following it. In addition, the values of the <c>Header.AceType</c> and
		/// <c>Header.AceSize</c> members must be set explicitly by the application.
		/// </para>
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows/desktop/api/winnt/ns-winnt-_access_allowed_object_ace typedef struct
		// _ACCESS_ALLOWED_OBJECT_ACE { ACE_HEADER Header; ACCESS_MASK Mask; DWORD Flags; GUID ObjectType; GUID InheritedObjectType; DWORD
		// SidStart; } ACCESS_ALLOWED_OBJECT_ACE, *PACCESS_ALLOWED_OBJECT_ACE;
		[PInvokeData("winnt.h", MSDNShortId = "ee91ca50-e81b-4872-95eb-349c2d5be004")]
		[StructLayout(LayoutKind.Sequential)]
		public struct ACCESS_ALLOWED_OBJECT_ACE
		{
			/// <summary>
			/// ACE_HEADER structure that specifies the size and type of ACE. It also contains flags that control inheritance of the ACE by
			/// child objects. The <c>AceType</c> member of the <c>ACE_HEADER</c> structure should be set to ACCESS_ALLOWED_OBJECT_ACE_TYPE,
			/// and the <c>AceSize</c> member should be set to the total number of bytes allocated for the <c>ACCESS_ALLOWED_OBJECT_ACE</c> structure.
			/// </summary>
			public ACE_HEADER Header;

			/// <summary>An ACCESS_MASK that specifies the access rights the system will allow to the trustee.</summary>
			public uint Mask;

			/// <summary>
			/// <para>
			/// A set of bit flags that indicate whether the <c>ObjectType</c> and <c>InheritedObjectType</c> members are present. This
			/// parameter can be one or more of the following values.
			/// </para>
			/// <list type="table">
			/// <listheader>
			/// <term>Value</term>
			/// <term>Meaning</term>
			/// </listheader>
			/// <item>
			/// <term>0</term>
			/// <term>Neither ObjectType nor InheritedObjectType are present. The SidStart member follows immediately after the Flags member.</term>
			/// </item>
			/// <item>
			/// <term>ACE_OBJECT_TYPE_PRESENT</term>
			/// <term>
			/// ObjectType is present and contains a GUID. If this value is not specified, the InheritedObjectType member follows immediately
			/// after the Flags member.
			/// </term>
			/// </item>
			/// <item>
			/// <term>ACE_INHERITED_OBJECT_TYPE_PRESENT</term>
			/// <term>
			/// InheritedObjectType is present and contains a GUID. If this value is not specified, all types of child objects can inherit
			/// the ACE.
			/// </term>
			/// </item>
			/// </list>
			/// </summary>
			public ObjectAceFlags Flags;

			/// <summary>
			/// <para>
			/// This member exists only if the ACE_OBJECT_TYPE_PRESENT bit is set in the <c>Flags</c> member. Otherwise, the
			/// <c>InheritedObjectType</c> member follows immediately after the <c>Flags</c> member.
			/// </para>
			/// <para>
			/// If this member exists, it is a GUID structure that identifies a property set, property, extended right, or type of child
			/// object. The purpose of this <c>GUID</c> depends on the access rights specified in the <c>Mask</c> member.
			/// </para>
			/// <list type="table">
			/// <listheader>
			/// <term>Value</term>
			/// <term>Meaning</term>
			/// </listheader>
			/// <item>
			/// <term>ADS_RIGHT_DS_CONTROL_ACCESS</term>
			/// <term>The ObjectType GUID identifies an extended access right.</term>
			/// </item>
			/// <item>
			/// <term>ADS_RIGHT_DS_CREATE_CHILD</term>
			/// <term>
			/// The ObjectType GUID identifies a type of child object. The ACE controls the trustee's right to create this type of child object.
			/// </term>
			/// </item>
			/// <item>
			/// <term>ADS_RIGHT_DS_READ_PROP</term>
			/// <term>
			/// The ObjectType GUID identifies a property set or property of the object. The ACE controls the trustee's right to read the
			/// property or property set.
			/// </term>
			/// </item>
			/// <item>
			/// <term>ADS_RIGHT_DS_WRITE_PROP</term>
			/// <term>
			/// The ObjectType GUID identifies a property set or property of the object. The ACE controls the trustee's right to write the
			/// property or property set.
			/// </term>
			/// </item>
			/// <item>
			/// <term>ADS_RIGHT_DS_SELF</term>
			/// <term>The ObjectType GUID identifies a validated write.</term>
			/// </item>
			/// </list>
			/// </summary>
			public Guid ObjectType;

			/// <summary>
			/// <para>This member exists only if the ACE_INHERITED_OBJECT_TYPE_PRESENT bit is set in the <c>Flags</c> member.</para>
			/// <para>
			/// If this member exists, it is a GUID structure that identifies the type of child object that can inherit the ACE. Inheritance
			/// is also controlled by the inheritance flags in the ACE_HEADER, as well as by any protection against inheritance placed on the
			/// child objects.
			/// </para>
			/// <para>
			/// The offset of this member can vary. If the <c>Flags</c> member does not contain the ACE_OBJECT_TYPE_PRESENT flag, the
			/// <c>InheritedObjectType</c> member starts at the offset specified by the <c>ObjectType</c> member.
			/// </para>
			/// </summary>
			public Guid InheritedObjectType;

			/// <summary>
			/// <para>
			/// Specifies the first <c>DWORD</c> of a SID that identifies the trustee to whom the access rights are granted. The remaining
			/// bytes of the SID are stored in contiguous memory after the <c>SidStart</c> member. This SID can be appended with application data.
			/// </para>
			/// <para>
			/// The offset of this member can vary. If the <c>Flags</c> member is zero, the <c>SidStart</c> member starts at the offset
			/// specified by the <c>ObjectType</c> member. If <c>Flags</c> contains only one flag (either ACE_OBJECT_TYPE_PRESENT or
			/// ACE_INHERITED_OBJECT_TYPE_PRESENT), the <c>SidStart</c> member starts at the offset specified by the
			/// <c>InheritedObjectType</c> member.
			/// </para>
			/// </summary>
			public uint SidStart;
		}

		/// <summary>The ACE_HEADER structure defines the type and size of an access control entry (ACE).</summary>
		[StructLayout(LayoutKind.Sequential, Pack = 1)]
		[PInvokeData("Winnt.h", MSDNShortId = "aa374919")]
		public struct ACE_HEADER
		{
			/// <summary>Specifies the ACE type.</summary>
			public AceType AceType;

			/// <summary>Specifies a set of ACE type-specific control flags.</summary>
			public AceFlags AceFlags;

			/// <summary>Specifies the size, in bytes, of the ACE.</summary>
			public ushort AceSize;
		}

		/// <summary>
		/// The ACL structure is the header of an access control list (ACL). A complete ACL consists of an ACL structure followed by an
		/// ordered list of zero or more access control entries (ACEs).
		/// </summary>
		/// <remarks>
		/// An ACL includes a sequential list of zero or more ACEs. The individual ACEs in an ACL are numbered from 0 to n, where n+1 is the
		/// number of ACEs in the ACL. When editing an ACL, an application refers to an ACE within the ACL by the ACE's index.
		/// <para>There are two types of ACL: discretionary and system.</para>
		/// <para>
		/// A discretionary access control list (DACL) is controlled by the owner of an object or anyone granted WRITE_DAC access to the
		/// object. It specifies the access particular users and groups can have to an object. For example, the owner of a file can use a
		/// DACL to control which users and groups can and cannot have access to the file.
		/// </para>
		/// <para>
		/// An object can also have system-level security information associated with it, in the form of a system access control list (SACL)
		/// controlled by a system administrator. A SACL allows the system administrator to audit any attempts to gain access to an object.
		/// </para>
		/// <para>For a list of currently defined ACE structures, see ACE.</para>
		/// <para>A fourth ACE structure, SYSTEM_ALARM_ACE, is not currently supported.</para>
		/// <para>
		/// The ACL structure is to be treated as though it were opaque and applications are not to attempt to work with its members
		/// directly. To ensure that ACLs are semantically correct, applications can use the functions listed in the See Also section to
		/// create and manipulate ACLs.
		/// </para>
		/// <para>Each ACL and ACE structure begins on a DWORD boundary.</para>
		/// <para>The maximum size for an ACL, including its ACEs, is 64 KB.</para>
		/// </remarks>
		[StructLayout(LayoutKind.Sequential, Pack = 1)]
		[PInvokeData("Winnt.h", MSDNShortId = "aa374931")]
		public struct ACL
		{
			/// <summary>
			/// Specifies the revision level of the ACL. This value should be ACL_REVISION, unless the ACL contains an object-specific ACE,
			/// in which case this value must be ACL_REVISION_DS. All ACEs in an ACL must be at the same revision level.
			/// </summary>
			public byte AclRevision;

			/// <summary>Specifies a zero byte of padding that aligns the AclRevision member on a 16-bit boundary.</summary>
			public byte Sbz1;

			/// <summary>Specifies the size, in bytes, of the ACL. This value includes both the ACL structure and all the ACEs.</summary>
			public ushort AclSize;

			/// <summary>Specifies the number of ACEs stored in the ACL.</summary>
			public ushort AceCount;

			/// <summary>Specifies two zero-bytes of padding that align the ACL structure on a 32-bit boundary.</summary>
			public ushort Sbz2;
		}

		/// <summary>The ACL_REVISION_INFORMATION structure contains revision information about an ACL structure.</summary>
		[StructLayout(LayoutKind.Sequential)]
		[PInvokeData("Winnt.h", MSDNShortId = "aa374942")]
		public struct ACL_REVISION_INFORMATION
		{
			/// <summary>Specifies a revision number. The current revision number is ACL_REVISION.</summary>
			public uint AclRevision;
		}

		/// <summary>The ACL_SIZE_INFORMATION structure contains information about the size of an ACL structure.</summary>
		[StructLayout(LayoutKind.Sequential)]
		[PInvokeData("Winnt.h", MSDNShortId = "aa374945")]
		public struct ACL_SIZE_INFORMATION
		{
			/// <summary>The number of access control entries (ACEs) in the access control list (ACL).</summary>
			public uint AceCount;

			/// <summary>
			/// The number of bytes in the ACL actually used to store the ACEs and ACL structure. This may be less than the total number of
			/// bytes allocated to the ACL.
			/// </summary>
			public uint AclBytesInUse;

			/// <summary>The number of unused bytes in the ACL.</summary>
			public uint AclBytesFree;
		}

		/// <summary>The actual attribute.</summary>
		[StructLayout(LayoutKind.Explicit)]
		[PInvokeData("Winnt.h", MSDNShortId = "hh448481")]
		public struct CLAIM_SECURITY_ATTRIBUTE_INFORMATION_V1
		{
			/// <summary>Pointer to an array that contains the AttributeCount member of the CLAIM_SECURITY_ATTRIBUTE_V1 structure.</summary>
			[FieldOffset(0)]
			public IntPtr pAttributeV1;
		}

		/// <summary>The CLAIM_SECURITY_ATTRIBUTES_INFORMATION structure defines the security attributes for the claim.</summary>
		[StructLayout(LayoutKind.Sequential)]
		[PInvokeData("Winnt.h", MSDNShortId = "hh448481")]
		public struct CLAIM_SECURITY_ATTRIBUTES_INFORMATION
		{
			/// <summary>The version of the security attribute. This must be 1.</summary>
			public ushort Version;

			/// <summary>
			/// This member is currently reserved and must be zero when setting an attribute and is ignored when getting an attribute.
			/// </summary>
			public ushort Reserved;

			/// <summary>The number of values.</summary>
			public uint AttributeCount;

			/// <summary>The actual attribute.</summary>
			public CLAIM_SECURITY_ATTRIBUTE_INFORMATION_V1 Attribute;
		}

		/// <summary>
		/// <para>Contains information that is included immediately after the newest event log record.</para>
		/// <para>
		/// The <c>ELF_EOF_RECORD</c> structure is used in an event log to enable the event-logging service to reconstruct the
		/// <c>ELF_LOGFILE_HEADER</c>. The event-logging service must add the <c>ELF_EOF_RECORD</c> to the event log. For more information
		/// about <c>ELF_EOF_RECORD</c>, see Event Log File Format.
		/// </para>
		/// </summary>
		// typedef struct _EVENTLOGEOF { ULONG RecordSizeBeginning; ULONG One; ULONG Two; ULONG Three; ULONG Four; ULONG BeginRecord; ULONG
		// EndRecord; ULONG CurrentRecordNumber; ULONG OldestRecordNumber; ULONG RecordSizeEnd;} EVENTLOGEOF, *PEVENTLOGEOF; https://msdn.microsoft.com/en-us/library/windows/desktop/bb309022(v=vs.85).aspx
		[PInvokeData("Winnt.h", MSDNShortId = "bb309022")]
		[StructLayout(LayoutKind.Sequential, CharSet = CharSet.Auto)]
		public struct EVENTLOGEOF
		{
			/// <summary>The beginning size of the <c>ELF_EOF_RECORD</c>. The beginning size is always 0x28.</summary>
			public uint RecordSizeBeginning;

			/// <summary>
			/// An identifier that helps to differentiate this record from other records in the event log. The value is always set to 0x11111111.
			/// </summary>
			public uint One;

			/// <summary>
			/// An identifier that helps to differentiate this record from other records in the event log. The value is always set to 0x22222222.
			/// </summary>
			public uint Two;

			/// <summary>
			/// An identifier that helps to differentiate this record from other records in the event log. The value is always set to 0x33333333.
			/// </summary>
			public uint Three;

			/// <summary>
			/// An identifier that helps to differentiate this record from other records in the event log. The value is always set to 0x44444444.
			/// </summary>
			public uint Four;

			/// <summary>The offset to the oldest record. If the event log is empty, this is set to the start of this structure.</summary>
			public uint BeginRecord;

			/// <summary>The offset to the start of this structure.</summary>
			public uint EndRecord;

			/// <summary>The record number of the next event that will be written to the event log.</summary>
			public uint CurrentRecordNumber;

			/// <summary>The record number of the oldest record in the event log. The record number will be 0 if the event log is empty.</summary>
			public uint OldestRecordNumber;

			/// <summary>The ending size of the <c>ELF_EOF_RECORD</c>. The ending size is always 0x28.</summary>
			public uint RecordSizeEnd;
		}

		/// <summary>
		/// <para>Contains information that is included at the beginning of an event log.</para>
		/// <para>
		/// The <c>ELF_LOGFILE_HEADER</c> structure is used at the beginning of an event log to define information about the event log. The
		/// event-logging service must add the <c>ELF_LOGFILE_HEADER</c> to the event log. For more information about how the
		/// <c>ELF_LOGFILE_HEADER</c> is used, see Event Log File Format.
		/// </para>
		/// </summary>
		// typedef struct _EVENTLOGHEADER { ULONG HeaderSize; ULONG Signature; ULONG MajorVersion; ULONG MinorVersion; ULONG StartOffset;
		// ULONG EndOffset; ULONG CurrentRecordNumber; ULONG OldestRecordNumber; ULONG MaxSize; ULONG Flags; ULONG Retention; ULONG
		// EndHeaderSize;} EVENTLOGHEADER, *PEVENTLOGHEADER; https://msdn.microsoft.com/en-us/library/windows/desktop/bb309024(v=vs.85).aspx
		[PInvokeData("Winnt.h", MSDNShortId = "bb309024")]
		[StructLayout(LayoutKind.Sequential, CharSet = CharSet.Auto)]
		public struct EVENTLOGHEADER
		{
			/// <summary>The size of the header structure. The size is always 0x30.</summary>
			public uint HeaderSize;

			/// <summary>The signature is always 0x654c664c, which is ASCII for eLfL.</summary>
			public uint Signature;

			/// <summary>The major version number of the event log. The major version number is always set to 1.</summary>
			public uint MajorVersion;

			/// <summary>The minor version number of the event log. The minor version number is always set to 1.</summary>
			public uint MinorVersion;

			/// <summary>The offset to the oldest record in the event log.</summary>
			public uint StartOffset;

			/// <summary>The offset to the <c>ELF_EOF_RECORD</c> in the event log.</summary>
			public uint EndOffset;

			/// <summary>The number of the next record that will be added to the event log.</summary>
			public uint CurrentRecordNumber;

			/// <summary>The number of the oldest record in the event log. For an empty file, the oldest record number is set to 0.</summary>
			public uint OldestRecordNumber;

			/// <summary>
			/// The maximum size, in bytes, of the event log. The maximum size is defined when the event log is created. The event-logging
			/// service does not typically update this value, it relies on the registry configuration. The reader of the event log can use
			/// normal file APIs to determine the size of the file. For more information about registry configuration values, see Eventlog Key.
			/// </summary>
			public uint MaxSize;

			/// <summary>
			/// <para>The status of the event log. This member can be one of the following values:</para>
			/// <para>
			/// <list type="table">
			/// <listheader>
			/// <term>Value</term>
			/// <term>Meaning</term>
			/// </listheader>
			/// <item>
			/// <term>ELF_LOGFILE_HEADER_DIRTY0x0001</term>
			/// <term>
			/// Indicates that records have been written to an event log, but the event log file has not been properly closed. For more
			/// information about this flag, see the Remarks section.
			/// </term>
			/// </item>
			/// <item>
			/// <term>ELF_LOGFILE_HEADER_WRAP0x0002</term>
			/// <term>Indicates that records in the event log have wrapped.</term>
			/// </item>
			/// <item>
			/// <term>ELF_LOGFILE_LOGFULL_WRITTEN0x0004</term>
			/// <term>Indicates that the most recent write attempt failed due to insufficient space.</term>
			/// </item>
			/// <item>
			/// <term>ELF_LOGFILE_ARCHIVE_SET0x0008</term>
			/// <term>
			/// Indicates that the archive attribute has been set for the file. Normal file APIs can also be used to determine the value of
			/// this flag.
			/// </term>
			/// </item>
			/// </list>
			/// </para>
			/// </summary>
			public ELF_FLAGS Flags;

			/// <summary>
			/// The retention value of the file when it is created. The event-logging service does not typically update this value, it relies
			/// on the registry configuration. For more information about registry configuration values, see Eventlog Key.
			/// </summary>
			public uint Retention;

			/// <summary>The ending size of the header structure. The size is always 0x30.</summary>
			public uint EndHeaderSize;
		}

		/// <summary>Contains information about an event record returned by the ReadEventLog function.</summary>
		/// <remarks>
		/// <para>
		/// The defined members are followed by the replacement strings for the message identified by the event identifier, the binary
		/// information, some pad bytes to make sure the full entry is on a <c>DWORD</c> boundary, and finally the length of the log entry
		/// again. Because the strings and the binary information can be of any length, no structure members are defined to reference them.
		/// The declaration of this structure in Winnt.h describes these members as follows:
		/// </para>
		/// <para>
		/// The source name is a variable-length string that specifies the name of the event source. The computer name is the name of the
		/// computer that generated the event. It may be followed with some padding bytes so that the user SID is aligned on a <c>DWORD</c>
		/// boundary. The user SID identifies the active user at the time this event was logged. If <c>UserSidLength</c> is zero, this field
		/// may be empty.
		/// </para>
		/// <para>
		/// The event identifier together with source name and a language identifier identify a string that describes the event in more
		/// detail. The strings are used as replacement strings and are merged into the message string to make a complete message. The
		/// message strings are contained in a message file specified in the source entry in the registry. To obtain the appropriate message
		/// string from the message file, load the message file with the LoadLibrary function and use the FormatMessage function.
		/// </para>
		/// <para>
		/// The binary information is information that is specific to the event. It could be the contents of the processor registers when a
		/// device driver got an error, a dump of an invalid packet that was received from the network, a dump of all the structures in a
		/// program (when the data area was detected to be corrupt), and so on. This information should be useful to the writer of the device
		/// driver or the application in tracking down bugs or unauthorized breaks into the application.
		/// </para>
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows/desktop/api/winnt/ns-winnt-_eventlogrecord typedef struct _EVENTLOGRECORD { DWORD Length;
		// DWORD Reserved; DWORD RecordNumber; DWORD TimeGenerated; DWORD TimeWritten; DWORD EventID; WORD EventType; WORD NumStrings; WORD
		// EventCategory; WORD ReservedFlags; DWORD ClosingRecordNumber; DWORD StringOffset; DWORD UserSidLength; DWORD UserSidOffset; DWORD
		// DataLength; DWORD DataOffset; } EVENTLOGRECORD, *PEVENTLOGRECORD;
		[PInvokeData("winnt.h", MSDNShortId = "669b182a-bc81-4386-9815-6ffa09e2e743")]
		[StructLayout(LayoutKind.Sequential, CharSet = CharSet.Auto)]
		public struct EVENTLOGRECORD
		{
			/// <summary>
			/// The size of this event record, in bytes. Note that this value is stored at both ends of the entry to ease moving forward or
			/// backward through the log. The length includes any pad bytes inserted at the end of the record for <c>DWORD</c> alignment.
			/// </summary>
			public uint Length;

			/// <summary>A DWORD value that is always set to <c>ELF_LOG_SIGNATURE</c> (the value is 0x654c664c), which is ASCII for eLfL.</summary>
			public uint Reserved;

			/// <summary>
			/// The number of the record. This value can be used with the EVENTLOG_SEEK_READ flag in the ReadEventLog function to begin
			/// reading at a specified record. For more information, see Event Log Records.
			/// </summary>
			public uint RecordNumber;

			/// <summary>
			/// The time at which this entry was submitted. This time is measured in the number of seconds elapsed since 00:00:00 January 1,
			/// 1970, Universal Coordinated Time.
			/// </summary>
			public uint TimeGenerated;

			/// <summary>
			/// The time at which this entry was received by the service to be written to the log. This time is measured in the number of
			/// seconds elapsed since 00:00:00 January 1, 1970, Universal Coordinated Time.
			/// </summary>
			public uint TimeWritten;

			/// <summary>
			/// The event identifier. The value is specific to the event source for the event, and is used with source name to locate a
			/// description string in the message file for the event source. For more information, see Event Identifiers.
			/// </summary>
			public uint EventID;

			/// <summary>
			/// <para>The type of event. This member can be one of the following values.</para>
			/// <list type="table">
			/// <listheader>
			/// <term>Value</term>
			/// <term>Meaning</term>
			/// </listheader>
			/// <item>
			/// <term>EVENTLOG_ERROR_TYPE 0x0001</term>
			/// <term>Error event</term>
			/// </item>
			/// <item>
			/// <term>EVENTLOG_AUDIT_FAILURE 0x0010</term>
			/// <term>Failure Audit event</term>
			/// </item>
			/// <item>
			/// <term>EVENTLOG_AUDIT_SUCCESS 0x0008</term>
			/// <term>Success Audit event</term>
			/// </item>
			/// <item>
			/// <term>EVENTLOG_INFORMATION_TYPE 0x0004</term>
			/// <term>Information event</term>
			/// </item>
			/// <item>
			/// <term>EVENTLOG_WARNING_TYPE 0x0002</term>
			/// <term>Warning event</term>
			/// </item>
			/// </list>
			/// <para>For more information, see Event Types.</para>
			/// </summary>
			public ushort EventType;

			/// <summary>
			/// The number of strings present in the log (at the position indicated by <c>StringOffset</c>). These strings are merged into
			/// the message before it is displayed to the user.
			/// </summary>
			public ushort NumStrings;

			/// <summary>
			/// The category for this event. The meaning of this value depends on the event source. For more information, see Event Categories.
			/// </summary>
			public ushort EventCategory;

			/// <summary>Reserved.</summary>
			public ushort ReservedFlags;

			/// <summary>Reserved.</summary>
			public uint ClosingRecordNumber;

			/// <summary>The offset of the description strings within this event log record.</summary>
			public uint StringOffset;

			/// <summary>The size of the <c>UserSid</c> member, in bytes. This value can be zero if no security identifier was provided.</summary>
			public uint UserSidLength;

			/// <summary>
			/// The offset of the security identifier (SID) within this event log record. To obtain the user name for this SID, use the
			/// LookupAccountSid function.
			/// </summary>
			public uint UserSidOffset;

			/// <summary>The size of the event-specific data (at the position indicated by <c>DataOffset</c>), in bytes.</summary>
			public uint DataLength;

			/// <summary>
			/// The offset of the event-specific information within this event log record, in bytes. This information could be something
			/// specific (a disk driver might log the number of retries, for example), followed by binary information specific to the event
			/// being logged and to the source that generated the entry.
			/// </summary>
			public uint DataOffset;
		}

		/// <summary>
		/// Defines the mapping of generic access rights to specific and standard access rights for an object. When a client application
		/// requests generic access to an object, that request is mapped to the access rights defined in this structure.
		/// </summary>
		[StructLayout(LayoutKind.Sequential)]
		[PInvokeData("Winnt.h", MSDNShortId = "aa446633")]
		public struct GENERIC_MAPPING
		{
			/// <summary>Specifies an access mask defining read access to an object.</summary>
			public uint GenericRead;

			/// <summary>Specifies an access mask defining write access to an object.</summary>
			public uint GenericWrite;

			/// <summary>Specifies an access mask defining execute access to an object.</summary>
			public uint GenericExecute;

			/// <summary>Specifies an access mask defining all possible types of access to an object.</summary>
			public uint GenericAll;

			/// <summary>Initializes a new instance of the <see cref="GENERIC_MAPPING"/> structure.</summary>
			/// <param name="read">The read mapping.</param>
			/// <param name="write">The write mapping.</param>
			/// <param name="execute">The execute mapping.</param>
			/// <param name="all">The 'all' mapping.</param>
			public GENERIC_MAPPING(uint read, uint write, uint execute, uint all)
			{
				GenericRead = read;
				GenericWrite = write;
				GenericExecute = execute;
				GenericAll = all;
			}

			/// <summary>The generic file mappings (FILE_GENERIC_READ, FILE_GENERIC_WRITE, FILE_GENERIC_READ, FILE_ALL_ACCESS).</summary>
			public static readonly GENERIC_MAPPING GenericFileMapping = new GENERIC_MAPPING((uint)FileAccess.FILE_GENERIC_READ, (uint)FileAccess.FILE_GENERIC_WRITE, (uint)FileAccess.FILE_GENERIC_READ, (uint)FileAccess.FILE_ALL_ACCESS);
		}

		/// <summary>
		/// An LUID is a 64-bit value guaranteed to be unique only on the system on which it was generated. The uniqueness of a locally
		/// unique identifier (LUID) is guaranteed only until the system is restarted.
		/// <para>Applications must use functions and structures to manipulate LUID values.</para>
		/// </summary>
		[StructLayout(LayoutKind.Sequential, Pack = 1)]
		public struct LUID
		{
			/// <summary>Low order bits.</summary>
			public uint LowPart;

			/// <summary>High order bits.</summary>
			public int HighPart;

			/// <summary>Gets the privilege name for this LUID.</summary>
			/// <param name="systemName">
			/// Name of the system on which to perform the lookup. Specifying <c>null</c> will query the local system.
			/// </param>
			/// <returns>The name retrieved for the LUID.</returns>
			public string GetName(string systemName = null)
			{
				var sb = new StringBuilder(1024);
				var sz = sb.Capacity;
				if (!LookupPrivilegeName(systemName, in this, sb, ref sz))
					Win32Error.ThrowLastError();
				return sb.ToString();
			}

			/// <summary>Creates a new LUID instance from a privilege name.</summary>
			/// <param name="name">The privilege name.</param>
			/// <param name="systemName">
			/// Name of the system on which to perform the lookup. Specifying <c>null</c> will query the local system.
			/// </param>
			/// <returns>The LUID instance corresponding to the <paramref name="name"/>.</returns>
			public static LUID FromName(string name, string systemName = null) =>
				!LookupPrivilegeValue(systemName, name, out var val) ? throw Win32Error.GetLastError().GetException() : val;

			/// <summary>
			/// Creates a new LUID that is unique to the local system only, and uniqueness is guaranteed only until the system is next restarted.
			/// </summary>
			/// <returns>A new LUID.</returns>
			public static LUID NewLUID()
			{
				if (!AllocateLocallyUniqueId(out var ret))
					Win32Error.ThrowLastError();
				return ret;
			}

			/// <summary>Returns a <see cref="System.String"/> that represents this instance.</summary>
			/// <returns>A <see cref="System.String"/> that represents this instance.</returns>
			public override string ToString()
			{
				try { return GetName(); } catch { return $"0x{Macros.MAKELONG64(LowPart, (uint)HighPart):X}"; }
			}
		}

		/// <summary>The LUID_AND_ATTRIBUTES structure represents a locally unique identifier (LUID) and its attributes.</summary>
		/// <remarks>
		/// An LUID_AND_ATTRIBUTES structure can represent an LUID whose attributes change frequently, such as when the LUID is used to
		/// represent privileges in the PRIVILEGE_SET structure. Privileges are represented by LUIDs and have attributes indicating whether
		/// they are currently enabled or disabled.
		/// </remarks>
		[StructLayout(LayoutKind.Sequential, Pack = 1)]
		public struct LUID_AND_ATTRIBUTES
		{
			/// <summary>Specifies a LUID value.</summary>
			public LUID Luid;

			/// <summary>
			/// Specifies attributes of the LUID. This value contains up to 32 one-bit flags. Its meaning is dependent on the definition and
			/// use of the LUID.
			/// </summary>
			public PrivilegeAttributes Attributes;

			/// <summary>Initializes a new instance of the <see cref="LUID_AND_ATTRIBUTES"/> struct.</summary>
			/// <param name="luid">The LUID value.</param>
			/// <param name="attr">The attribute value.</param>
			public LUID_AND_ATTRIBUTES(LUID luid, PrivilegeAttributes attr)
			{
				Luid = luid;
				Attributes = attr;
			}

			/// <summary>Returns a <see cref="System.String"/> that represents this instance.</summary>
			/// <returns>A <see cref="System.String"/> that represents this instance.</returns>
			public override string ToString() => $"{Luid}:{Attributes}";
		}

		/// <summary>The QUOTA_LIMITS structure describes the amount of system resources available to a user.</summary>
		[StructLayout(LayoutKind.Sequential)]
		[PInvokeData("Winnt.h", MSDNShortId = "aa379363")]
		public struct QUOTA_LIMITS
		{
			/// <summary>
			/// Specifies the amount of paged pool memory assigned to the user. The paged pool is an area of system memory (physical memory
			/// used by the operating
			/// system) for objects that can be written to disk when they are not being used.
			/// <para>
			/// The value set in this member is not enforced by the LSA. You should set this member to 0, which causes the default value to
			/// be used.
			/// </para>
			/// </summary>
			public uint PagedPoolLimit;

			/// <summary>
			/// Specifies the amount of nonpaged pool memory assigned to the user. The nonpaged pool is an area of system memory for objects
			/// that cannot be written to disk but must remain in physical memory as long as they are allocated.
			/// <para>
			/// The value set in this member is not enforced by the LSA. You should set this member to 0, which causes the default value to
			/// be used.
			/// </para>
			/// </summary>
			public uint NonPagedPoolLimit;

			/// <summary>
			/// Specifies the minimum set size assigned to the user. The "working set" of a process is the set of memory pages currently
			/// visible to the process in physical RAM memory. These pages are present in memory when the application is running and
			/// available for an application to use without triggering a page fault.
			/// <para>
			/// The value set in this member is not enforced by the LSA. You should set this member to NULL, which causes the default value
			/// to be used.
			/// </para>
			/// </summary>
			public uint MinimumWorkingSetSize;

			/// <summary>
			/// Specifies the maximum set size assigned to the user.
			/// <para>
			/// The value set in this member is not enforced by the LSA. You should set this member to 0, which causes the default value to
			/// be used.
			/// </para>
			/// </summary>
			public uint MaximumWorkingSetSize;

			/// <summary>
			/// Specifies the maximum size, in bytes, of the paging file, which is a reserved space on disk that backs up committed physical
			/// memory on the computer.
			/// <para>
			/// The value set in this member is not enforced by the LSA. You should set this member to 0, which causes the default value to
			/// be used.
			/// </para>
			/// </summary>
			public uint PagefileLimit;

			/// <summary>
			/// Indicates the maximum amount of time the process can run.
			/// <para>
			/// The value set in this member is not enforced by the LSA. You should set this member to NULL, which causes the default value
			/// to be used.
			/// </para>
			/// </summary>
			public long TimeLimit;
		}

		/// <summary>
		/// The SECURITY_DESCRIPTOR structure contains the security information associated with an object. Applications use this structure to
		/// set and query an object's security status.
		/// <para>
		/// Because the internal format of a security descriptor can vary, we recommend that applications not modify the SECURITY_DESCRIPTOR
		/// structure directly.
		/// </para>
		/// </summary>
		[StructLayout(LayoutKind.Sequential, Pack = 1)]
		[PInvokeData("Winnt.h", MSDNShortId = "aa379561")]
		public struct SECURITY_DESCRIPTOR
		{
			/// <summary>Undocumented.</summary>
			public byte Revision;

			/// <summary>Undocumented.</summary>
			public byte Sbz1;

			/// <summary>Undocumented.</summary>
			public SECURITY_DESCRIPTOR_CONTROL Control;

			/// <summary>Undocumented.</summary>
			public PSID Owner;

			/// <summary>Undocumented.</summary>
			public PSID Group;

			/// <summary>Undocumented.</summary>
			public PACL Sacl;

			/// <summary>Undocumented.</summary>
			public PACL Dacl;
		}

		/// <summary>
		/// The SID_AND_ATTRIBUTES structure represents a security identifier (SID) and its attributes. SIDs are used to uniquely identify
		/// users or groups.
		/// </summary>
		[StructLayout(LayoutKind.Sequential)]
		public struct SID_AND_ATTRIBUTES
		{
			/// <summary>A pointer to a SID structure.</summary>
			public PSID Sid;

			/// <summary>
			/// Specifies attributes of the SID. This value contains up to 32 one-bit flags. Its meaning depends on the definition and use of
			/// the SID.
			/// </summary>
			public uint Attributes;

			/// <summary>Initializes a new instance of the <see cref="SID_AND_ATTRIBUTES"/> struct.</summary>
			/// <param name="sid">The SID.</param>
			/// <param name="attributes">The attributes of the SID.</param>
			public SID_AND_ATTRIBUTES(PSID sid, uint attributes)
			{
				Sid = sid;
				Attributes = attributes;
			}
		}

		/// <summary>The SID_IDENTIFIER_AUTHORITY structure represents the top-level authority of a security identifier (SID).</summary>
		[StructLayout(LayoutKind.Sequential, Pack = 1)]
		[PInvokeData("Winnt.h", MSDNShortId = "aa379598")]
		public struct SID_IDENTIFIER_AUTHORITY
		{
			/// <summary>An array of 6 bytes specifying a SID's top-level authority.</summary>
			[MarshalAs(UnmanagedType.ByValArray, SizeConst = 6)] public byte[] Value;
		}

		/// <summary>
		/// The TOKEN_ACCESS_INFORMATION structure specifies all the information in a token that is necessary to perform an access check.
		/// </summary>
		[StructLayout(LayoutKind.Sequential)]
		[PInvokeData("WinNT.h", MSDNShortId = "bb394726")]
		public struct TOKEN_ACCESS_INFORMATION
		{
			/// <summary>A pointer to a SID_AND_ATTRIBUTES_HASH structure that specifies a hash of the token's security identifier (SID).</summary>
			public IntPtr SidHash;

			/// <summary>A pointer to a SID_AND_ATTRIBUTES_HASH structure that specifies a hash of the token's restricted SID.</summary>
			public IntPtr RestrictedSidHash;

			/// <summary>A pointer to a TOKEN_PRIVILEGES structure that specifies information about the token's privileges.</summary>
			public PTOKEN_PRIVILEGES Privileges;

			/// <summary>A LUID structure that specifies the token's identity.</summary>
			public LUID AuthenticationId;

			/// <summary>A value of the TOKEN_TYPE enumeration that specifies the token's type.</summary>
			public TOKEN_TYPE TokenType;

			/// <summary>A value of the SECURITY_IMPERSONATION_LEVEL enumeration that specifies the token's impersonation level.</summary>
			public SECURITY_IMPERSONATION_LEVEL ImpersonationLevel;

			/// <summary>A TOKEN_MANDATORY_POLICY structure that specifies the token's mandatory integrity policy.</summary>
			public TOKEN_MANDATORY_POLICY MandatoryPolicy;

			/// <summary>Reserved. Must be set to zero.</summary>
			public uint Flags;

			/// <summary>
			/// The app container number for the token or zero if this is not an app container token.
			/// <para><c>Windows Server 2008 R2, Windows 7, Windows Server 2008 and Windows Vista:</c> This member is not available.</para>
			/// </summary>
			public uint AppContainerNumber;

			/// <summary>
			/// The app container SID or NULL if this is not an app container token.
			/// <para><c>Windows Server 2008 R2, Windows 7, Windows Server 2008 and Windows Vista:</c> This member is not available.</para>
			/// </summary>
			public PSID PackageSid;

			/// <summary>
			/// Pointer to a SID_AND_ATTRIBUTES_HASH structure that specifies a hash of the token's capability SIDs.
			/// <para><c>Windows Server 2008 R2, Windows 7, Windows Server 2008 and Windows Vista:</c> This member is not available.</para>
			/// </summary>
			public IntPtr CapabilitiesHash;

			/// <summary>The protected process trust level of the token.</summary>
			public PSID TrustLevelSid;

			/// <summary>
			/// Reserved. Must be set to NULL.
			/// <para><c>Prior to Windows 10:</c> This member is not available.</para>
			/// </summary>
			public IntPtr SecurityAttributes;
		}

		/// <summary>
		/// The TOKEN_APPCONTAINER_INFORMATION structure specifies all the information in a token that is necessary for an app container.
		/// </summary>
		[StructLayout(LayoutKind.Sequential)]
		public struct TOKEN_APPCONTAINER_INFORMATION
		{
			/// <summary>The security identifier (SID) of the app container.</summary>
			public PSID TokenAppContainer;
		}

		/// <summary>The TOKEN_DEFAULT_DACL structure specifies a discretionary access control list (DACL).</summary>
		[StructLayout(LayoutKind.Sequential)]
		[PInvokeData("WinNT.h", MSDNShortId = "aa379623")]
		public struct TOKEN_DEFAULT_DACL
		{
			/// <summary>
			/// A pointer to an ACL structure assigned by default to any objects created by the user. The user is represented by the access token.
			/// </summary>
			public PACL DefaultDacl;
		}

		/// <summary>The TOKEN_ELEVATION structure indicates whether a token has elevated privileges.</summary>
		[StructLayout(LayoutKind.Sequential)]
		public struct TOKEN_ELEVATION
		{
			/// <summary>A nonzero value if the token has elevated privileges; otherwise, a zero value.</summary>
			[MarshalAs(UnmanagedType.Bool)]
			public bool TokenIsElevated;
		}

		/// <summary>The TOKEN_GROUPS structure contains information about the group security identifiers (SIDs) in an access token.</summary>
		[StructLayout(LayoutKind.Sequential)]
		public struct TOKEN_GROUPS
		{
			/// <summary>Specifies the number of groups in the access token.</summary>
			public uint GroupCount;

			/// <summary>Specifies an array of SID_AND_ATTRIBUTES structures that contain a set of SIDs and corresponding attributes.</summary>
			[MarshalAs(UnmanagedType.ByValArray)]
			public SID_AND_ATTRIBUTES[] Groups;

			/// <summary>Initializes a new instance of the <see cref="TOKEN_GROUPS"/> struct.</summary>
			/// <param name="count">The number of groups.</param>
			public TOKEN_GROUPS(uint count = 0)
			{
				GroupCount = count;
				Groups = new SID_AND_ATTRIBUTES[count];
			}
		}

		/// <summary>
		/// The TOKEN_GROUPS_AND_PRIVILEGES structure contains information about the group security identifiers (SIDs) and privileges in an
		/// access token.
		/// </summary>
		[StructLayout(LayoutKind.Sequential)]
		[PInvokeData("WinNT.h", MSDNShortId = "aa379625")]
		public struct TOKEN_GROUPS_AND_PRIVILEGES
		{
			/// <summary>Number of SIDs in the access token.</summary>
			public uint SidCount;

			/// <summary>Length, in bytes, required to hold all of the user SIDs and the account SID for the group.</summary>
			public uint SidLength;

			/// <summary>A pointer to an array of SID_AND_ATTRIBUTES structures that contain a set of SIDs and corresponding attributes.</summary>
			public IntPtr Sids;

			/// <summary>Number of restricted SIDs.</summary>
			public uint RestrictedSidCount;

			/// <summary>Length, in bytes, required to hold all of the restricted SIDs.</summary>
			public uint RestrictedSidLength;

			/// <summary>
			/// A pointer to an array of SID_AND_ATTRIBUTES structures that contain a set of restricted SIDs and corresponding attributes.
			/// <para>
			/// The Attributes members of the SID_AND_ATTRIBUTES structures can have the same values as those listed for the preceding Sids member.
			/// </para>
			/// </summary>
			public IntPtr RestrictedSids;

			/// <summary>Number of privileges.</summary>
			public uint PrivilegeCount;

			/// <summary>Length, in bytes, needed to hold the privilege array.</summary>
			public uint PrivilegeLength;

			/// <summary>Array of privileges.</summary>
			public IntPtr Privileges;

			/// <summary>Locally unique identifier (LUID) of the authenticator of the token.</summary>
			public LUID AuthenticationId;
		}

		/// <summary>
		/// The TOKEN_LINKED_TOKEN structure contains a handle to a token. This token is linked to the token being queried by the
		/// GetTokenInformation function or set by the SetTokenInformation function.
		/// </summary>
		[StructLayout(LayoutKind.Sequential)]
		[PInvokeData("WinNT.h", MSDNShortId = "bb530719")]
		public struct TOKEN_LINKED_TOKEN
		{
			/// <summary>A handle to the linked token. When you have finished using the handle, close it by calling the CloseHandle function.</summary>
			public IntPtr LinkedToken;
		}

		/// <summary>The TOKEN_MANDATORY_LABEL structure specifies the mandatory integrity level for a token.</summary>
		[StructLayout(LayoutKind.Sequential)]
		public struct TOKEN_MANDATORY_LABEL
		{
			/// <summary>A SID_AND_ATTRIBUTES structure that specifies the mandatory integrity level of the token.</summary>
			public SID_AND_ATTRIBUTES Label;
		}

		/// <summary>The TOKEN_MANDATORY_POLICY structure specifies the mandatory integrity policy for a token.</summary>
		[StructLayout(LayoutKind.Sequential)]
		[PInvokeData("WinNT.h", MSDNShortId = "bb394728")]
		public struct TOKEN_MANDATORY_POLICY
		{
			/// <summary>The mandatory integrity access policy for the associated token.</summary>
			// TODO: Convert to enum
			public uint Policy;
		}

		/// <summary>
		/// The TOKEN_ORIGIN structure contains information about the origin of the logon session. This structure is used by the
		/// GetTokenInformation function.
		/// </summary>
		[StructLayout(LayoutKind.Sequential)]
		[PInvokeData("WinNT.h", MSDNShortId = "aa379627")]
		public struct TOKEN_ORIGIN
		{
			/// <summary>
			/// Locally unique identifier (LUID) for the logon session. If the token passed to GetTokenInformation resulted from a logon
			/// using explicit credentials, such as passing name, domain, and password to the LogonUser function, then this member will
			/// contain the ID of the logon session that created it. If the token resulted from network authentication, such as a call to
			/// AcceptSecurityContext, or a call to LogonUser with dwLogonType set to LOGON32_LOGON_NETWORK or
			/// LOGON32_LOGON_NETWORK_CLEARTEXT, then this member will be zero.
			/// </summary>
			public LUID OriginatingLogonSession;
		}

		/// <summary>
		/// The TOKEN_OWNER structure contains the default owner security identifier (SID) that will be applied to newly created objects.
		/// </summary>
		[StructLayout(LayoutKind.Sequential)]
		[PInvokeData("WinNT.h", MSDNShortId = "aa379628")]
		public struct TOKEN_OWNER
		{
			/// <summary>
			/// A pointer to a SID structure representing a user who will become the owner of any objects created by a process using this
			/// access token. The SID must be one of the user or group SIDs already in the token.
			/// </summary>
			public PSID Owner;
		}

		/// <summary>The TOKEN_PRIMARY_GROUP structure specifies a group security identifier (SID) for an access token.</summary>
		[StructLayout(LayoutKind.Sequential)]
		[PInvokeData("WinNT.h", MSDNShortId = "aa379629")]
		public struct TOKEN_PRIMARY_GROUP
		{
			/// <summary>
			/// A pointer to a SID structure representing a group that will become the primary group of any objects created by a process
			/// using this access token. The SID must be one of the group SIDs already in the token.
			/// </summary>
			public PSID PrimaryGroup;
		}

		/// <summary>The TOKEN_SOURCE structure identifies the source of an access token.</summary>
		[StructLayout(LayoutKind.Sequential)]
		[PInvokeData("WinNT.h", MSDNShortId = "aa379631")]
		public struct TOKEN_SOURCE
		{
			private const int TOKEN_SOURCE_LENGTH = 8;

			/// <summary>
			/// Specifies an 8-byte character string used to identify the source of an access token. This is used to distinguish between such
			/// sources as Session Manager, LAN Manager, and RPC Server. A string, rather than a constant, is used to identify the source so
			/// users and developers can make extensions to the system, such as by adding other networks, that act as the source of access tokens.
			/// </summary>
			[MarshalAs(UnmanagedType.ByValArray, SizeConst = TOKEN_SOURCE_LENGTH)]
			public char[] SourceName;

			/// <summary>
			/// Specifies a locally unique identifier (LUID) provided by the source component named by the SourceName member. This value aids
			/// the source component in relating context blocks, such as session-control structures, to the token. This value is typically,
			/// but not necessarily, an LUID.
			/// </summary>
			public LUID SourceIdentifier;
		}

		/// <summary>
		/// The TOKEN_STATISTICS structure contains information about an access token. An application can retrieve this information by
		/// calling the GetTokenInformation function.
		/// </summary>
		[StructLayout(LayoutKind.Sequential, CharSet = CharSet.Unicode)]
		[PInvokeData("WinNT.h", MSDNShortId = "aa379632")]
		public struct TOKEN_STATISTICS
		{
			/// <summary>Specifies a locally unique identifier (LUID) that identifies this instance of the token object.</summary>
			public LUID TokenId;

			/// <summary>
			/// Specifies an LUID assigned to the session this token represents. There can be many tokens representing a single logon session.
			/// </summary>
			public LUID AuthenticationId;

			/// <summary>Specifies the time at which this token expires. Expiration times for access tokens are not currently supported.</summary>
			public long ExpirationTime;

			/// <summary>Specifies a TOKEN_TYPE enumeration type indicating whether the token is a primary or impersonation token.</summary>
			public TOKEN_TYPE TokenType;

			/// <summary>
			/// Specifies a SECURITY_IMPERSONATION_LEVEL enumeration type indicating the impersonation level of the token. This member is
			/// valid only if the TokenType is TokenImpersonation.
			/// </summary>
			public SECURITY_IMPERSONATION_LEVEL ImpersonationLevel;

			/// <summary>Specifies the amount, in bytes, of memory allocated for storing default protection and a primary group identifier.</summary>
			public uint DynamicCharged;

			/// <summary>
			/// Specifies the portion of memory allocated for storing default protection and a primary group identifier not already in use.
			/// This value is returned as a count of free bytes.
			/// </summary>
			public uint DynamicAvailable;

			/// <summary>Specifies the number of supplemental group security identifiers (SIDs) included in the token.</summary>
			public uint GroupCount;

			/// <summary>Specifies the number of privileges included in the token.</summary>
			public uint PrivilegeCount;

			/// <summary>
			/// Specifies an LUID that changes each time the token is modified. An application can use this value as a test of whether a
			/// security context has changed since it was last used.
			/// </summary>
			public LUID ModifiedId;
		}

		/// <summary>The TOKEN_USER structure identifies the user associated with an access token.</summary>
		[StructLayout(LayoutKind.Sequential)]
		public struct TOKEN_USER
		{
			/// <summary>
			/// Specifies a SID_AND_ATTRIBUTES structure representing the user associated with the access token. There are currently no
			/// attributes defined for user security identifiers (SIDs).
			/// </summary>
			public SID_AND_ATTRIBUTES User;
		}

		/// <summary>Known SID authorities.</summary>
		public static class KnownSIDAuthority
		{
			/// <summary>The application package authority</summary>
			public static readonly PSID_IDENTIFIER_AUTHORITY SECURITY_APP_PACKAGE_AUTHORITY = new byte[] { 0, 0, 0, 0, 0, 15 };

			/// <summary>The authentication authority</summary>
			public static readonly PSID_IDENTIFIER_AUTHORITY SECURITY_AUTHENTICATION_AUTHORITY = new byte[] { 0, 0, 0, 0, 0, 18 };

			/// <summary>The identifier authority for the creator owner.</summary>
			public static readonly PSID_IDENTIFIER_AUTHORITY SECURITY_CREATOR_SID_AUTHORITY = new byte[] { 0, 0, 0, 0, 0, 3 };

			/// <summary>The identifier authority for locally connected users.</summary>
			public static readonly PSID_IDENTIFIER_AUTHORITY SECURITY_LOCAL_SID_AUTHORITY = new byte[] { 0, 0, 0, 0, 0, 2 };

			/// <summary>The mandatory label authority</summary>
			public static readonly PSID_IDENTIFIER_AUTHORITY SECURITY_MANDATORY_LABEL_AUTHORITY = new byte[] { 0, 0, 0, 0, 0, 16 };

			/// <summary>The non-unique identifier authority.</summary>
			public static readonly PSID_IDENTIFIER_AUTHORITY SECURITY_NON_UNIQUE_AUTHORITY = new byte[] { 0, 0, 0, 0, 0, 4 };

			/// <summary>The Windows security authority</summary>
			public static readonly PSID_IDENTIFIER_AUTHORITY SECURITY_NT_AUTHORITY = new byte[] { 0, 0, 0, 0, 0, 5 };

			/// <summary>The identifier authority with no members.</summary>
			public static readonly PSID_IDENTIFIER_AUTHORITY SECURITY_NULL_SID_AUTHORITY = new byte[] { 0, 0, 0, 0, 0, 0 };

			/// <summary>The process trust authority</summary>
			public static readonly PSID_IDENTIFIER_AUTHORITY SECURITY_PROCESS_TRUST_AUTHORITY = new byte[] { 0, 0, 0, 0, 0, 19 };

			/// <summary>The security resource manager authority</summary>
			public static readonly PSID_IDENTIFIER_AUTHORITY SECURITY_RESOURCE_MANAGER_AUTHORITY = new byte[] { 0, 0, 0, 0, 0, 9 };

			/// <summary>The scoped policy identifier authority</summary>
			public static readonly PSID_IDENTIFIER_AUTHORITY SECURITY_SCOPED_POLICY_ID_AUTHORITY = new byte[] { 0, 0, 0, 0, 0, 17 };

			/// <summary>The identifier authority all users.</summary>
			public static readonly PSID_IDENTIFIER_AUTHORITY SECURITY_WORLD_SID_AUTHORITY = new byte[] { 0, 0, 0, 0, 0, 1 };
		}

		/// <summary>Known RIDs</summary>
		public static class KnownSIDRelativeID
		{
			/// <summary>The security creator group rid</summary>
			public const int SECURITY_CREATOR_GROUP_RID = 0x00000001;

			/// <summary>The security creator group server rid</summary>
			public const int SECURITY_CREATOR_GROUP_SERVER_RID = 0x00000003;

			/// <summary>The security creator owner rid</summary>
			public const int SECURITY_CREATOR_OWNER_RID = 0x00000000;

			/// <summary>The security creator owner rights rid</summary>
			public const int SECURITY_CREATOR_OWNER_RIGHTS_RID = 0x00000004;

			/// <summary>The security creator owner server rid</summary>
			public const int SECURITY_CREATOR_OWNER_SERVER_RID = 0x00000002;

			/// <summary>The security local logon rid</summary>
			public const int SECURITY_LOCAL_LOGON_RID = 0x00000001;

			/// <summary>The security local rid</summary>
			public const int SECURITY_LOCAL_RID = 0x00000000;

			/// <summary>The security null rid</summary>
			public const int SECURITY_NULL_RID = 0x00000000;

			/// <summary>The security world rid</summary>
			public const int SECURITY_WORLD_RID = 0x00000000;
		}

		/// <summary>
		/// The PRIVILEGE_SET structure specifies a set of privileges. It is also used to indicate which, if any, privileges are held by a
		/// user or group requesting access to an object.
		/// </summary>
		[StructLayout(LayoutKind.Sequential)]
		public class PRIVILEGE_SET
		{
			/// <summary>Specifies the number of privileges in the privilege set.</summary>
			public uint PrivilegeCount;

			/// <summary>
			/// Specifies a control flag related to the privileges. The PRIVILEGE_SET_ALL_NECESSARY control flag is currently defined. It
			/// indicates that all of the specified privileges must be held by the process requesting access. If this flag is not set, the
			/// presence of any privileges in the user's access token grants the access.
			/// </summary>
			public PrivilegeSetControl Control;

			/// <summary>Specifies an array of LUID_AND_ATTRIBUTES structures describing the set's privileges.</summary>
			[MarshalAs(UnmanagedType.ByValArray, SizeConst = 1)]
			public LUID_AND_ATTRIBUTES[] Privilege;

			/// <summary>Initializes a new instance of the <see cref="PRIVILEGE_SET"/> class with a single LUID_AND_ATTRIBUTES value.</summary>
			/// <param name="control">The control flag. See <see cref="Control"/>.</param>
			/// <param name="luid">The LUID value.</param>
			/// <param name="attribute">The attribute value.</param>
			public PRIVILEGE_SET(PrivilegeSetControl control, LUID luid, PrivilegeAttributes attribute)
			{
				PrivilegeCount = 1;
				Control = control;
				Privilege = new[] { new LUID_AND_ATTRIBUTES(luid, attribute) };
			}

			/// <summary>Initializes a new instance of the <see cref="PRIVILEGE_SET"/> class.</summary>
			/// <param name="control">The control flag. See <see cref="Control"/>.</param>
			/// <param name="privileges">A list of privileges to assign to the structure.</param>
			public PRIVILEGE_SET(PrivilegeSetControl control, LUID_AND_ATTRIBUTES[] privileges)
			{
				PrivilegeCount = (uint)(privileges?.Length ?? 0);
				Control = control;
				Privilege = (LUID_AND_ATTRIBUTES[])privileges?.Clone() ?? new LUID_AND_ATTRIBUTES[0];
			}

			/// <summary>Initializes a new instance of the <see cref="PRIVILEGE_SET"/> class.</summary>
			internal PRIVILEGE_SET() : this(PrivilegeSetControl.PRIVILEGE_SET_ALL_NECESSARY, null)
			{
			}

			/// <summary>Gets the size in bytes of this instance.</summary>
			/// <value>The size in bytes.</value>
			public uint SizeInBytes => (uint)Marshal.SizeOf(typeof(uint)) * 2 + (uint)(Marshal.SizeOf(typeof(LUID_AND_ATTRIBUTES)) * (PrivilegeCount == 0 ? 1 : PrivilegeCount));

			/// <summary>Returns a <see cref="System.String"/> that represents this instance.</summary>
			/// <returns>A <see cref="System.String"/> that represents this instance.</returns>
			public override string ToString() => $"Count:{PrivilegeCount}";

			/// <summary>Initializes a new <c>PRIVILEGE_SET</c> the with capacity to hold the specified number of privileges.</summary>
			/// <param name="privilegeCount">The privilege count to allocate.</param>
			/// <returns>A <c>PRIVILEGE_SET</c> instance with sufficient capacity for marshaling.</returns>
			public static PRIVILEGE_SET InitializeWithCapacity(int privilegeCount = 1) => new PRIVILEGE_SET() { PrivilegeCount = (uint)privilegeCount };

			internal class Marshaler : ICustomMarshaler
			{
				public static ICustomMarshaler GetInstance(string cookie) => new Marshaler();

				public void CleanUpManagedData(object ManagedObj)
				{
				}

				public void CleanUpNativeData(IntPtr pNativeData) => Marshal.FreeCoTaskMem(pNativeData);

				public int GetNativeDataSize() => -1;

				public IntPtr MarshalManagedToNative(object ManagedObj)
				{
					if (!(ManagedObj is PRIVILEGE_SET ps)) return IntPtr.Zero;
					var ptr = Marshal.AllocCoTaskMem((int)ps.SizeInBytes);
					if (ps.Privilege?.Length != ps.PrivilegeCount)
						ptr.FillMemory(0, (int)ps.SizeInBytes);
					Marshal.WriteInt32(ptr, (int)ps.PrivilegeCount);
					Marshal.WriteInt32(ptr, Marshal.SizeOf(typeof(int)), (int)ps.Control);
					ps.Privilege.MarshalToPtr(ptr, Marshal.SizeOf(typeof(int)) * 2);
					return ptr;
				}

				public object MarshalNativeToManaged(IntPtr pNativeData)
				{
					if (pNativeData == IntPtr.Zero) return new PRIVILEGE_SET();
					var sz = Marshal.SizeOf(typeof(uint));
					var cnt = Marshal.ReadInt32(pNativeData);
					var ctrl = (PrivilegeSetControl)Marshal.ReadInt32(pNativeData, sz);
					var privPtr = Marshal.ReadIntPtr(pNativeData, sz * 2);
					return new PRIVILEGE_SET { PrivilegeCount = (uint)cnt, Control = ctrl, Privilege = cnt > 0 ? privPtr.ToIEnum<LUID_AND_ATTRIBUTES>(cnt).ToArray() : new LUID_AND_ATTRIBUTES[0] };
				}
			}
		}

		/// <summary>
		/// <para>The <c>SID_IDENTIFIER_AUTHORITY</c> structure represents the top-level authority of a security identifier (SID).</para>
		/// </summary>
		/// <remarks>
		/// <para>The identifier authority value identifies the agency that issued the SID. The following identifier authorities are predefined.</para>
		/// <list type="table">
		/// <listheader>
		/// <term>Identifier authority</term>
		/// <term>Value</term>
		/// </listheader>
		/// <item>
		/// <term>SECURITY_NULL_SID_AUTHORITY</term>
		/// <term>0</term>
		/// </item>
		/// <item>
		/// <term>SECURITY_WORLD_SID_AUTHORITY</term>
		/// <term>1</term>
		/// </item>
		/// <item>
		/// <term>SECURITY_LOCAL_SID_AUTHORITY</term>
		/// <term>2</term>
		/// </item>
		/// <item>
		/// <term>SECURITY_CREATOR_SID_AUTHORITY</term>
		/// <term>3</term>
		/// </item>
		/// <item>
		/// <term>SECURITY_NON_UNIQUE_AUTHORITY</term>
		/// <term>4</term>
		/// </item>
		/// <item>
		/// <term>SECURITY_NT_AUTHORITY</term>
		/// <term>5</term>
		/// </item>
		/// <item>
		/// <term>SECURITY_RESOURCE_MANAGER_AUTHORITY</term>
		/// <term>9</term>
		/// </item>
		/// </list>
		/// <para>A SID must contain a top-level authority and at least one relative identifier (RID) value.</para>
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows/desktop/api/winnt/ns-winnt-_sid_identifier_authority typedef struct
		// _SID_IDENTIFIER_AUTHORITY { BYTE Value[6]; } SID_IDENTIFIER_AUTHORITY, *PSID_IDENTIFIER_AUTHORITY;
		[PInvokeData("winnt.h", MSDNShortId = "450a6d2d-d2e4-4098-90af-a8024ddcfcb5")]
		[StructLayout(LayoutKind.Sequential, Pack = 1)]
		public class PSID_IDENTIFIER_AUTHORITY
		{
			/// <summary>An array of 6 bytes specifying a SID's top-level authority.</summary>
			[MarshalAs(UnmanagedType.ByValArray, SizeConst = 6)]
			public byte[] Value;

			/// <summary>Initializes a new instance of the <see cref="SID_IDENTIFIER_AUTHORITY"/> struct.</summary>
			/// <param name="value">The value.</param>
			/// <exception cref="System.ArgumentOutOfRangeException">value</exception>
			public PSID_IDENTIFIER_AUTHORITY(byte[] value)
			{
				if (value == null || value.Length != 6)
					throw new ArgumentOutOfRangeException(nameof(value));
				Value = new byte[6];
				Array.Copy(value, Value, 6);
			}

			/// <summary>Initializes a new instance of the <see cref="SID_IDENTIFIER_AUTHORITY"/> struct.</summary>
			/// <param name="value">The value.</param>
			public PSID_IDENTIFIER_AUTHORITY(long value)
			{
				Value = new byte[6];
				LongValue = value;
			}

			/// <summary>Gets or sets the long value.</summary>
			/// <value>The long value.</value>
			public long LongValue
			{
				get
				{
					long nAuthority = 0;
					for (var i = 0; i <= 5; i++)
					{
						nAuthority <<= 8;
						nAuthority |= Value[i];
					}
					return nAuthority;
				}
				set
				{
					var bsia = BitConverter.GetBytes(value);
					for (var i = 0; i <= 5; i++)
						Value[i] = bsia[5 - i];
				}
			}

			/// <summary>Performs an implicit conversion from byte[] to <see cref="PSID_IDENTIFIER_AUTHORITY"/>.</summary>
			/// <param name="bytes">The bytes.</param>
			/// <returns>The result of the conversion.</returns>
			public static implicit operator PSID_IDENTIFIER_AUTHORITY(byte[] bytes) => new PSID_IDENTIFIER_AUTHORITY(bytes);

			/// <summary>Performs an implicit conversion from <see cref="SID_IDENTIFIER_AUTHORITY"/> to <see cref="PSID_IDENTIFIER_AUTHORITY"/>.</summary>
			/// <param name="sia">The sia.</param>
			/// <returns>The result of the conversion.</returns>
			public static implicit operator PSID_IDENTIFIER_AUTHORITY(SID_IDENTIFIER_AUTHORITY sia) => new PSID_IDENTIFIER_AUTHORITY(sia.Value);
		}

		/// <summary>The TOKEN_PRIVILEGES structure contains information about a set of privileges for an access token.</summary>
		[StructLayout(LayoutKind.Sequential)]
		public class PTOKEN_PRIVILEGES
		{
			/// <summary>This must be set to the number of entries in the Privileges array.</summary>
			public int PrivilegeCount;

			/// <summary>
			/// Specifies an array of LUID_AND_ATTRIBUTES structures. Each structure contains the LUID and attributes of a privilege. To get
			/// the name of the privilege associated with a LUID, call the LookupPrivilegeName function, passing the address of the LUID as
			/// the value of the lpLuid parameter.
			/// </summary>
			public LUID_AND_ATTRIBUTES[] Privileges;

			/// <summary>Initializes a new instance of the <see cref="PTOKEN_PRIVILEGES"/> class.</summary>
			public PTOKEN_PRIVILEGES() : this(null) { }

			/// <summary>Initializes a new instance of the <see cref="PTOKEN_PRIVILEGES"/> class with a single LUID_AND_ATTRIBUTES value.</summary>
			/// <param name="luid">The LUID value.</param>
			/// <param name="attribute">The attribute value.</param>
			public PTOKEN_PRIVILEGES(LUID luid, PrivilegeAttributes attribute)
			{
				PrivilegeCount = 1;
				Privileges = new[] { new LUID_AND_ATTRIBUTES(luid, attribute) };
			}

			/// <summary>Initializes a new instance of the <see cref="PTOKEN_PRIVILEGES"/> class from a list of privileges.</summary>
			/// <param name="values">The values.</param>
			public PTOKEN_PRIVILEGES(LUID_AND_ATTRIBUTES[] values)
			{
				PrivilegeCount = values?.Length ?? 0;
				Privileges = (LUID_AND_ATTRIBUTES[])values?.Clone() ?? new LUID_AND_ATTRIBUTES[0];
			}

			/// <summary>Gets the size of this instance in bytes.</summary>
			/// <value>The size in bytes.</value>
			public uint SizeInBytes => Marshaler.GetSize(PrivilegeCount);

			/// <summary>Creates a new instance of <see cref="PTOKEN_PRIVILEGES"/> from a pointer.</summary>
			/// <param name="hMem">A pointer to a memory block that contains a native TOKEN_PRIVILEGES structure.</param>
			/// <returns>A new instance of <see cref="PTOKEN_PRIVILEGES"/>.</returns>
			public static PTOKEN_PRIVILEGES FromPtr(IntPtr hMem) => Marshaler.GetInstance(null).MarshalNativeToManaged(hMem) as PTOKEN_PRIVILEGES;

			/// <summary>Gets unmanaged memory allocated to hold the number of privileges specified by <paramref name="privilegeCount"/>.</summary>
			/// <param name="privilegeCount">The privilege count.</param>
			public static SafeCoTaskMemHandle GetAllocatedAndEmptyInstance(int privilegeCount = 100) => new SafeCoTaskMemHandle((int)Marshaler.GetSize(privilegeCount));

			/// <summary>Returns a <see cref="System.String"/> that represents this instance.</summary>
			/// <returns>A <see cref="System.String"/> that represents this instance.</returns>
			public override string ToString() => $"Count:{PrivilegeCount}";

			internal class Marshaler : ICustomMarshaler
			{
				private readonly bool allocOut;

				private Marshaler(string cookie) => allocOut = cookie == "Out";

				public static ICustomMarshaler GetInstance(string cookie) => new Marshaler(cookie);

				/// <summary>Performs necessary cleanup of the managed data when it is no longer needed.</summary>
				/// <param name="ManagedObj">The managed object to be destroyed.</param>
				public void CleanUpManagedData(object ManagedObj) { }

				/// <summary>Performs necessary cleanup of the unmanaged data when it is no longer needed.</summary>
				/// <param name="pNativeData">A pointer to the unmanaged data to be destroyed.</param>
				public void CleanUpNativeData(IntPtr pNativeData) => Marshal.FreeCoTaskMem(pNativeData);

				/// <summary>Returns the size of the native data to be marshaled.</summary>
				/// <returns>The size in bytes of the native data.</returns>
				public int GetNativeDataSize() => -1;

				/// <summary>Converts the managed data to unmanaged data.</summary>
				/// <param name="ManagedObj">The managed object to be converted.</param>
				/// <returns>Returns the COM view of the managed object.</returns>
				public IntPtr MarshalManagedToNative(object ManagedObj)
				{
					if (!(ManagedObj is PTOKEN_PRIVILEGES ps)) return IntPtr.Zero;
					if (allocOut)
					{
						var sz = Math.Abs(ps.PrivilegeCount);
						ps.PrivilegeCount = 0;
						return Marshal.AllocCoTaskMem(sz);
					}
					var ptr = Marshal.AllocCoTaskMem((int)GetSize(ps.PrivilegeCount));
					Marshal.WriteInt32(ptr, ps.PrivilegeCount);
					ps.Privileges?.MarshalToPtr(ptr, Marshal.SizeOf(typeof(int)));
					return ptr;
				}

				/// <summary>Converts the unmanaged data to managed data.</summary>
				/// <param name="pNativeData">A pointer to the unmanaged data to be wrapped.</param>
				/// <returns>Returns the managed view of the COM data.</returns>
				public object MarshalNativeToManaged(IntPtr pNativeData)
				{
					if (pNativeData == IntPtr.Zero) return new PTOKEN_PRIVILEGES();
					var sz = Marshal.SizeOf(typeof(uint));
					var cnt = Marshal.ReadInt32(pNativeData);
					var privPtr = pNativeData.Offset(sz);
					return new PTOKEN_PRIVILEGES { PrivilegeCount = cnt, Privileges = cnt > 0 ? privPtr.ToIEnum<LUID_AND_ATTRIBUTES>(cnt).ToArray() : new LUID_AND_ATTRIBUTES[0] };
				}

				internal static uint GetSize(int privCount) => (uint)Marshal.SizeOf(typeof(uint)) + (uint)(Marshal.SizeOf(typeof(LUID_AND_ATTRIBUTES)) * (privCount == 0 ? 1 : Math.Abs(privCount)));
			}
		}

		/// <summary>A SafeHandle for security descriptors. If owned, will call LocalFree on the pointer when disposed.</summary>
		public class SafeSecurityDescriptor : SafeMemoryHandle<LocalMemoryMethods>, IEquatable<SafeSecurityDescriptor>, IEquatable<PSECURITY_DESCRIPTOR>, IEquatable<IntPtr>, ISecurityObject
		{
			/// <summary>The null value for a SafeSecurityDescriptor.</summary>
			public static readonly SafeSecurityDescriptor Null = new SafeSecurityDescriptor();

			private const SECURITY_INFORMATION defSecInfo = SECURITY_INFORMATION.DACL_SECURITY_INFORMATION | SECURITY_INFORMATION.SACL_SECURITY_INFORMATION | SECURITY_INFORMATION.OWNER_SECURITY_INFORMATION | SECURITY_INFORMATION.GROUP_SECURITY_INFORMATION;

			/// <summary>Initializes a new instance of the <see cref="SafeSecurityDescriptor"/> class.</summary>
			public SafeSecurityDescriptor() : base(IntPtr.Zero, 0, false) { }

			/// <summary>Initializes a new instance of the <see cref="SafeSecurityDescriptor"/> class from an existing pointer.</summary>
			/// <param name="pSecurityDescriptor">The security descriptor pointer.</param>
			/// <param name="own">if set to <c>true</c> indicates that this pointer should be freed when disposed.</param>
			public SafeSecurityDescriptor(PSECURITY_DESCRIPTOR pSecurityDescriptor, bool own = true) :
				base((IntPtr)pSecurityDescriptor, (int)GetSecurityDescriptorLength(pSecurityDescriptor), own)
			{ }

			/// <summary>Initializes a new instance of the <see cref="SafeSecurityDescriptor"/> class to an empty memory buffer.</summary>
			/// <param name="size">The size of the uninitialized security descriptor.</param>
			public SafeSecurityDescriptor(int size) : base(size) { }

			/// <summary>Initializes a new instance of the <see cref="SafeSecurityDescriptor"/> class.</summary>
			/// <param name="bytes">An array of bytes that contain an existing security descriptor.</param>
			public SafeSecurityDescriptor(byte[] bytes) : this(bytes?.Length ?? 0)
			{
				if (bytes is null) return;
				Marshal.Copy(bytes, 0, handle, bytes.Length);
			}

			/// <summary>Initializes a new instance of the <see cref="SafeSecurityDescriptor"/> class with an SDDL string.</summary>
			/// <param name="sddl">An SDDL value representing the security descriptor.</param>
			public SafeSecurityDescriptor(string sddl)
			{
				if (!ConvertStringSecurityDescriptorToSecurityDescriptor(sddl, SDDL_REVISION.SDDL_REVISION_1, out var sd, out var sdsz))
					Win32Error.ThrowLastError();
				handle = sd.DangerousGetHandle();
				sz = (int)sdsz;
				sd.SetHandleAsInvalid();
			}

			/// <summary>Determines whether the components of this security descriptor are valid.</summary>
			public bool IsValidSecurityDescriptor => IsValidSecurityDescriptor(handle);

			/// <summary>
			/// Gets the length, in bytes, of a structurally valid security descriptor. The length includes the length of all associated structures.
			/// </summary>
			public uint Length => GetSecurityDescriptorLength(handle);

			/// <summary>Performs an explicit conversion from <see cref="SafeSecurityDescriptor"/> to <see cref="PSECURITY_DESCRIPTOR"/>.</summary>
			/// <param name="sd">The safe security descriptor.</param>
			/// <returns>The result of the conversion.</returns>
			public static implicit operator PSECURITY_DESCRIPTOR(SafeSecurityDescriptor sd) => sd.DangerousGetHandle();

			/// <summary>Implements the operator !=.</summary>
			/// <param name="psd1">The first value.</param>
			/// <param name="psd2">The second value.</param>
			/// <returns>The result of the operator.</returns>
			public static bool operator !=(SafeSecurityDescriptor psd1, SafeSecurityDescriptor psd2) => !(psd1 == psd2);

			/// <summary>Implements the operator ==.</summary>
			/// <param name="psd1">The first value.</param>
			/// <param name="psd2">The second value.</param>
			/// <returns>The result of the operator.</returns>
			public static bool operator ==(SafeSecurityDescriptor psd1, SafeSecurityDescriptor psd2)
			{
				if (ReferenceEquals(psd1, psd2)) return true;
				if (Equals(null, psd1) || Equals(null, psd2)) return false;
				return psd1.Equals(psd2);
			}

			/// <summary>Indicates whether the current object is equal to another object of the same type.</summary>
			/// <param name="other">An object to compare with this object.</param>
			/// <returns>true if the current object is equal to the <paramref name="other"/> parameter; otherwise, false.</returns>
			public bool Equals(SafeSecurityDescriptor other) => Equals(other.DangerousGetHandle());

			/// <summary>Indicates whether the current object is equal to another object of the same type.</summary>
			/// <param name="other">An object to compare with this object.</param>
			/// <returns>true if the current object is equal to the <paramref name="other"/> parameter; otherwise, false.</returns>
			public bool Equals(PSECURITY_DESCRIPTOR other) => Equals(other.DangerousGetHandle());

			/// <summary>Indicates whether the current object is equal to another object of the same type.</summary>
			/// <param name="other">An object to compare with this object.</param>
			/// <returns>true if the current object is equal to the <paramref name="other"/> parameter; otherwise, false.</returns>
			public bool Equals(IntPtr other)
			{
				if (GetSecurityDescriptorLength(handle) != GetSecurityDescriptorLength(other)) return false;
				var s1 = ConvertSecurityDescriptorToStringSecurityDescriptor(handle, defSecInfo);
				var s2 = ConvertSecurityDescriptorToStringSecurityDescriptor(other, defSecInfo);
				return string.CompareOrdinal(s1, s2) == 0;
			}

			/// <summary>Determines whether the specified <see cref="T:System.Object"/> is equal to the current <see cref="T:System.Object"/>.</summary>
			/// <param name="obj">The object to compare with the current object.</param>
			/// <returns>
			/// true if the specified <see cref="T:System.Object"/> is equal to the current <see cref="T:System.Object"/>; otherwise, false.
			/// </returns>
			public override bool Equals(object obj)
			{
				if (obj is SafeSecurityDescriptor psid2)
					return Equals(psid2);
				if (obj is PSECURITY_DESCRIPTOR psidh)
					return Equals(psidh);
				if (obj is IntPtr ptr)
					return Equals(ptr);
				return false;
			}

			/// <summary>Returns a hash code for this instance.</summary>
			/// <returns>A hash code for this instance, suitable for use in hashing algorithms and data structures like a hash table.</returns>
			public override int GetHashCode() => ToString().GetHashCode();

			/// <summary>Returns a <see cref="string"/> that represents this instance.</summary>
			/// <returns>A <see cref="string"/> that represents this instance.</returns>
			public override string ToString() => ConvertSecurityDescriptorToStringSecurityDescriptor(handle, defSecInfo);
		}
	}
}