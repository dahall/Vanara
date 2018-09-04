using System;
using System.Linq;
using System.Runtime.InteropServices;
using System.Security.AccessControl;
using System.Text;
using Vanara.Extensions;
using Vanara.InteropServices;

// ReSharper disable UnusedMember.Global
// ReSharper disable FieldCanBeMadeReadOnly.Global
// ReSharper disable MemberCanBePrivate.Global

namespace Vanara.PInvoke
{
	public static partial class AdvApi32
	{
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

		/// <summary>Used by the <see cref="GetAclInformation(IntPtr,ref ACL_REVISION_INFORMATION,uint,ACL_INFORMATION_CLASS)"/> function.</summary>
		[PInvokeData("winnt.h")]
		public enum ACL_INFORMATION_CLASS : uint
		{
			/// <summary>Indicates ACL revision information.</summary>
			AclRevisionInformation = 1,
			/// <summary>Indicates ACL size information.</summary>
			AclSizeInformation
		}

		/// <summary>Group attributes.</summary>
		[Flags]
		[PInvokeData("winnt.h")]
		public enum GroupAttributes : uint
		{
			/// <summary>The SID cannot have the SE_GROUP_ENABLED attribute cleared by a call to the AdjustTokenGroups function. However, you can use the CreateRestrictedToken function to convert a mandatory SID to a deny-only SID.</summary>
			SE_GROUP_MANDATORY = 0x00000001,
			/// <summary>The SID is enabled by default.</summary>
			SE_GROUP_ENABLED_BY_DEFAULT = 0x00000002,
			/// <summary>The SID is enabled for access checks. When the system performs an access check, it checks for access-allowed and access-denied access control entries (ACEs) that apply to the SID. A SID without this attribute is ignored during an access check unless the SE_GROUP_USE_FOR_DENY_ONLY attribute is set.</summary>
			SE_GROUP_ENABLED = 0x00000004,
			/// <summary>The SID identifies a group account for which the user of the token is the owner of the group, or the SID can be assigned as the owner of the token or objects.</summary>
			SE_GROUP_OWNER = 0x00000008,
			/// <summary>The SID is a deny-only SID in a restricted token. When the system performs an access check, it checks for access-denied ACEs that apply to the SID; it ignores access-allowed ACEs for the SID. If this attribute is set, SE_GROUP_ENABLED is not set, and the SID cannot be reenabled.</summary>
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
			/// The privilege was used to gain access to an object or service. This flag is used to identify the relevant privileges in a set passed by a client
			/// application that may contain unnecessary privileges.
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
		/// A set of bit flags that qualify the meaning of a security descriptor or its components. Each security descriptor has a Control member that stores the
		/// SECURITY_DESCRIPTOR_CONTROL bits.
		/// </summary>
		[Flags]
		public enum SECURITY_DESCRIPTOR_CONTROL : ushort
		{
			/// <summary>
			/// Indicates a required security descriptor in which the discretionary access control list (DACL) is set up to support automatic propagation of
			/// inheritable access control entries (ACEs) to existing child objects.
			/// <para>
			/// For access control lists (ACLs) that support auto inheritance, this bit is always set. Protected servers can call the
			/// ConvertToAutoInheritPrivateObjectSecurity function to convert a security descriptor and set this flag.
			/// </para>
			/// </summary>
			SE_DACL_AUTO_INHERIT_REQ = 0x0100,
			/// <summary>
			/// Indicates a security descriptor in which the discretionary access control list (DACL) is set up to support automatic propagation of inheritable
			/// access control entries (ACEs) to existing child objects.
			/// <para>
			/// For access control lists (ACLs) that support auto inheritance, this bit is always set. Protected servers can call the
			/// ConvertToAutoInheritPrivateObjectSecurity function to convert a security descriptor and set this flag.
			/// </para>
			/// </summary>
			SE_DACL_AUTO_INHERITED = 0x0400,
			/// <summary>
			/// Indicates a security descriptor with a default DACL. For example, if the creator an object does not specify a DACL, the object receives the
			/// default DACL from the access token of the creator. This flag can affect how the system treats the DACL with respect to ACE inheritance. The
			/// system ignores this flag if the SE_DACL_PRESENT flag is not set.
			/// <para>
			/// This flag is used to determine how the final DACL on the object is to be computed and is not stored physically in the security descriptor control
			/// of the securable object.
			/// </para>
			/// <para>To set this flag, use the SetSecurityDescriptorDacl function.</para>
			/// </summary>
			SE_DACL_DEFAULTED = 0x0008,
			/// <summary>
			/// Indicates a security descriptor that has a DACL. If this flag is not set, or if this flag is set and the DACL is NULL, the security descriptor
			/// allows full access to everyone.
			/// <para>
			/// This flag is used to hold the security information specified by a caller until the security descriptor is associated with a securable object.
			/// After the security descriptor is associated with a securable object, the SE_DACL_PRESENT flag is always set in the security descriptor control.
			/// </para>
			/// <para>To set this flag, use the SetSecurityDescriptorDacl function.</para>
			/// </summary>
			SE_DACL_PRESENT = 0x0004,
			/// <summary>
			/// Prevents the DACL of the security descriptor from being modified by inheritable ACEs. To set this flag, use the SetSecurityDescriptorControl function.
			/// </summary>
			SE_DACL_PROTECTED = 0x1000,
			/// <summary>
			/// Indicates that the security identifier (SID) of the security descriptor group was provided by a default mechanism. This flag can be used by a
			/// resource manager to identify objects whose security descriptor group was set by a default mechanism. To set this flag, use the
			/// SetSecurityDescriptorGroup function.
			/// </summary>
			SE_GROUP_DEFAULTED = 0x0002,
			/// <summary>
			/// Indicates that the SID of the owner of the security descriptor was provided by a default mechanism. This flag can be used by a resource manager
			/// to identify objects whose owner was set by a default mechanism. To set this flag, use the SetSecurityDescriptorOwner function.
			/// </summary>
			SE_OWNER_DEFAULTED = 0x0001,
			/// <summary>Indicates that the resource manager control is valid.</summary>
			SE_RM_CONTROL_VALID = 0x4000,
			/// <summary>
			/// Indicates a required security descriptor in which the system access control list (SACL) is set up to support automatic propagation of inheritable
			/// ACEs to existing child objects.
			/// <para>
			/// The system sets this bit when it performs the automatic inheritance algorithm for the object and its existing child objects. To convert a
			/// security descriptor and set this flag, protected servers can call the ConvertToAutoInheritPrivateObjectSecurity function.
			/// </para>
			/// </summary>
			SE_SACL_AUTO_INHERIT_REQ = 0x0200,
			/// <summary>
			/// Indicates a security descriptor in which the system access control list (SACL) is set up to support automatic propagation of inheritable ACEs to
			/// existing child objects.
			/// <para>
			/// The system sets this bit when it performs the automatic inheritance algorithm for the object and its existing child objects. To convert a
			/// security descriptor and set this flag, protected servers can call the ConvertToAutoInheritPrivateObjectSecurity function.
			/// </para>
			/// </summary>
			SE_SACL_AUTO_INHERITED = 0x0800,
			/// <summary>
			/// A default mechanism, rather than the original provider of the security descriptor, provided the SACL. This flag can affect how the system treats
			/// the SACL, with respect to ACE inheritance. The system ignores this flag if the SE_SACL_PRESENT flag is not set. To set this flag, use the
			/// SetSecurityDescriptorSacl function.
			/// </summary>
			SE_SACL_DEFAULTED = 0x0008,
			/// <summary>Indicates a security descriptor that has a SACL. To set this flag, use the SetSecurityDescriptorSacl function.</summary>
			SE_SACL_PRESENT = 0x0010,
			/// <summary>
			/// Prevents the SACL of the security descriptor from being modified by inheritable ACEs. To set this flag, use the SetSecurityDescriptorControl function.
			/// </summary>
			SE_SACL_PROTECTED = 0x2000,
			/// <summary>
			/// Indicates a self-relative security descriptor. If this flag is not set, the security descriptor is in absolute format. For more information, see
			/// Absolute and Self-Relative Security Descriptors.
			/// </summary>
			SE_SELF_RELATIVE = 0x8000
		}

		/// <summary>
		/// The SECURITY_IMPERSONATION_LEVEL enumeration contains values that specify security impersonation levels. Security impersonation levels govern the
		/// degree to which a server process can act on behalf of a client process.
		/// </summary>
		[PInvokeData("winnt.h")]
		public enum SECURITY_IMPERSONATION_LEVEL
		{
			/// <summary>
			/// The server process cannot obtain identification information about the client, and it cannot impersonate the client. It is defined with no value
			/// given, and thus, by ANSI C rules, defaults to a value of zero.
			/// </summary>
			SecurityAnonymous,

			/// <summary>
			/// The server process can obtain information about the client, such as security identifiers and privileges, but it cannot impersonate the client.
			/// This is useful for servers that export their own objects, for example, database products that export tables and views. Using the retrieved
			/// client-security information, the server can make access-validation decisions without being able to use other services that are using the client's
			/// security context.
			/// </summary>
			SecurityIdentification,

			/// <summary>
			/// The server process can impersonate the client's security context on its local system. The server cannot impersonate the client on remote systems.
			/// </summary>
			SecurityImpersonation,

			/// <summary>The server process can impersonate the client's security context on remote systems.</summary>
			SecurityDelegation
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

		/// <summary>The TOKEN_ELEVATION_TYPE enumeration indicates the elevation type of token being queried by the GetTokenInformation function.</summary>
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
		/// The TOKEN_INFORMATION_CLASS enumeration contains values that specify the type of information being assigned to or retrieved from an access token.
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

			/// <summary>The buffer receives a TOKEN_OWNER structure that contains the default owner security identifier (SID) for newly created objects.</summary>
			[CorrespondingType(typeof(TOKEN_OWNER))]
			TokenOwner,

			/// <summary>The buffer receives a TOKEN_PRIMARY_GROUP structure that contains the default primary group SID for newly created objects.</summary>
			[CorrespondingType(typeof(TOKEN_PRIMARY_GROUP))]
			TokenPrimaryGroup,

			/// <summary>The buffer receives a TOKEN_DEFAULT_DACL structure that contains the default DACL for newly created objects.</summary>
			[CorrespondingType(typeof(TOKEN_DEFAULT_DACL))]
			TokenDefaultDacl,

			/// <summary>
			/// The buffer receives a TOKEN_SOURCE structure that contains the source of the token. TOKEN_QUERY_SOURCE access is needed to retrieve this information.
			/// </summary>
			[CorrespondingType(typeof(TOKEN_SOURCE))]
			TokenSource,

			/// <summary>The buffer receives a TOKEN_TYPE value that indicates whether the token is a primary or impersonation token.</summary>
			[CorrespondingType(typeof(TOKEN_TYPE))]
			TokenType,

			/// <summary>
			/// The buffer receives a SECURITY_IMPERSONATION_LEVEL value that indicates the impersonation level of the token. If the access token is not an
			/// impersonation token, the function fails.
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
			/// <para>Windows Server 2003 and Windows XP: If the token is associated with the terminal server console session, the session identifier is zero.</para>
			/// <para>In a non-Terminal Services environment, the session identifier is zero.</para>
			/// <para>
			/// If TokenSessionId is set with SetTokenInformation, the application must have the Act As Part Of the Operating System privilege, and the
			/// application must be enabled to set the session ID in a token.
			/// </para>
			/// </summary>
			[CorrespondingType(typeof(uint))]
			TokenSessionId,

			/// <summary>
			/// The buffer receives a TOKEN_GROUPS_AND_PRIVILEGES structure that contains the user SID, the group accounts, the restricted SIDs, and the
			/// authentication ID associated with the token.
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
			/// If the token resulted from a logon that used explicit credentials, such as passing a name, domain, and password to the LogonUser function, then
			/// the TOKEN_ORIGIN structure will contain the ID of the logon session that created it.
			/// </para>
			/// <para>
			/// If the token resulted from network authentication, such as a call to AcceptSecurityContext or a call to LogonUser with dwLogonType set to
			/// LOGON32_LOGON_NETWORK or LOGON32_LOGON_NETWORK_CLEARTEXT, then this value will be zero.
			/// </para>
			/// </summary>
			[CorrespondingType(typeof(TOKEN_ORIGIN))]
			TokenOrigin,

			/// <summary>The buffer receives a TOKEN_ELEVATION_TYPE value that specifies the elevation level of the token.</summary>
			[CorrespondingType(typeof(TOKEN_ELEVATION_TYPE))]
			TokenElevationType,

			/// <summary>The buffer receives a TOKEN_LINKED_TOKEN structure that contains a handle to another token that is linked to this token.</summary>
			[CorrespondingType(typeof(TOKEN_LINKED_TOKEN))]
			TokenLinkedToken,

			/// <summary>The buffer receives a TOKEN_ELEVATION structure that specifies whether the token is elevated.</summary>
			[CorrespondingType(typeof(TOKEN_ELEVATION))]
			TokenElevation,

			/// <summary>The buffer receives a DWORD value that is nonzero if the token has ever been filtered.</summary>
			[CorrespondingType(typeof(uint))]
			TokenHasRestrictions,

			/// <summary>The buffer receives a TOKEN_ACCESS_INFORMATION structure that specifies security information contained in the token.</summary>
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
			/// The buffer receives a DWORD value that is nonzero if the token is an application container token. Any callers who check the TokenIsAppContainer
			/// and have it return 0 should also verify that the caller token is not an identify level impersonation token. If the current token is not an
			/// application container but is an identity level token, you should return AccessDenied.
			/// </summary>
			[CorrespondingType(typeof(uint))]
			TokenIsAppContainer,

			/// <summary>The buffer receives a TOKEN_GROUPS structure that contains the capabilities associated with the token.</summary>
			[CorrespondingType(typeof(TOKEN_GROUPS))]
			TokenCapabilities,

			/// <summary>
			/// The buffer receives a TOKEN_APPCONTAINER_INFORMATION structure that contains the AppContainerSid associated with the token. If the token is not
			/// associated with an application container, the TokenAppContainer member of the TOKEN_APPCONTAINER_INFORMATION structure points to NULL.
			/// </summary>
			[CorrespondingType(typeof(TOKEN_APPCONTAINER_INFORMATION))]
			TokenAppContainerSid,

			/// <summary>
			/// The buffer receives a DWORD value that includes the application container number for the token. For tokens that are not application container
			/// tokens, this value is zero.
			/// </summary>
			[CorrespondingType(typeof(uint))]
			TokenAppContainerNumber,

			/// <summary>The buffer receives a CLAIM_SECURITY_ATTRIBUTES_INFORMATION structure that contains the user claims associated with the token.</summary>
			[CorrespondingType(typeof(CLAIM_SECURITY_ATTRIBUTES_INFORMATION))]
			TokenUserClaimAttributes,

			/// <summary>The buffer receives a CLAIM_SECURITY_ATTRIBUTES_INFORMATION structure that contains the device claims associated with the token.</summary>
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

			/// <summary>The buffer receives a TOKEN_GROUPS structure that contains the restricted device groups that are associated with the token.</summary>
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
			/// <summary>Required to attach a primary token to a process. The SE_ASSIGNPRIMARYTOKEN_NAME privilege is also required to accomplish this task.</summary>
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
		/// The ACCESS_ALLOWED_ACE structure defines an access control entry (ACE) for the discretionary access control list (DACL) that controls access to an
		/// object. An access-allowed ACE allows access to an object for a specific trustee identified by a security identifier (SID).
		/// </summary>
		[StructLayout(LayoutKind.Sequential)]
		[PInvokeData("Winnt.h", MSDNShortId = "aa374847")]
		public struct ACCESS_ALLOWED_ACE
		{
			/// <summary>
			/// ACE_HEADER structure that specifies the size and type of ACE. It also contains flags that control inheritance of the ACE by child objects. The
			/// AceType member of the ACE_HEADER structure should be set to ACCESS_ALLOWED_ACE_TYPE, and the AceSize member should be set to the total number of
			/// bytes allocated for the ACCESS_ALLOWED_ACE structure.
			/// </summary>
			public ACE_HEADER Header;
			/// <summary>Specifies an ACCESS_MASK structure that specifies the access rights granted by this ACE.</summary>
			public int Mask;
			/// <summary>
			/// The first DWORD of a trustee's SID. The remaining bytes of the SID are stored in contiguous memory after the SidStart member. This SID can be
			/// appended with application data.
			/// </summary>
			public int SidStart;

			/// <summary>Determines whether the specified <see cref="System.Object"/>, is equal to this instance.</summary>
			/// <param name="obj">The <see cref="System.Object"/> to compare with this instance.</param>
			/// <returns><c>true</c> if the specified <see cref="System.Object"/> is equal to this instance; otherwise, <c>false</c>.</returns>
			public override bool Equals(object obj)
			{
				return obj is ACCESS_ALLOWED_ACE aaa
					? Header.AceType == aaa.Header.AceType && Header.AceFlags == aaa.Header.AceFlags && Mask == aaa.Mask
					: base.Equals(obj);
			}

			/// <summary>Returns a hash code for this instance.</summary>
			/// <returns>A hash code for this instance, suitable for use in hashing algorithms and data structures like a hash table.</returns>
			public override int GetHashCode() => new { A = Header.AceFlags, B = Header.AceType, C = Mask }.GetHashCode();
		}

		/// <summary>The ACE_HEADER structure defines the type and size of an access control entry (ACE).</summary>
		[StructLayout(LayoutKind.Sequential)]
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
		/// The ACL structure is the header of an access control list (ACL). A complete ACL consists of an ACL structure followed by an ordered list of zero or more access control entries (ACEs).
		/// </summary>
		/// <remarks>An ACL includes a sequential list of zero or more ACEs. The individual ACEs in an ACL are numbered from 0 to n, where n+1 is the number of ACEs in the ACL. When editing an ACL, an application refers to an ACE within the ACL by the ACE's index.
		/// <para>There are two types of ACL: discretionary and system.</para>
		/// <para>A discretionary access control list (DACL) is controlled by the owner of an object or anyone granted WRITE_DAC access to the object. It specifies the access particular users and groups can have to an object. For example, the owner of a file can use a DACL to control which users and groups can and cannot have access to the file.</para>
		/// <para>An object can also have system-level security information associated with it, in the form of a system access control list (SACL) controlled by a system administrator. A SACL allows the system administrator to audit any attempts to gain access to an object.</para>
		/// <para>For a list of currently defined ACE structures, see ACE.</para>
		/// <para>A fourth ACE structure, SYSTEM_ALARM_ACE, is not currently supported.</para>
		/// <para>The ACL structure is to be treated as though it were opaque and applications are not to attempt to work with its members directly. To ensure that ACLs are semantically correct, applications can use the functions listed in the See Also section to create and manipulate ACLs.</para>
		/// <para>Each ACL and ACE structure begins on a DWORD boundary.</para>
		/// <para>The maximum size for an ACL, including its ACEs, is 64 KB.</para>
		/// </remarks>
		[StructLayout(LayoutKind.Sequential, Pack = 1)]
		[PInvokeData("Winnt.h", MSDNShortId = "aa374931")]
		public struct ACL
		{
			/// <summary>Specifies the revision level of the ACL. This value should be ACL_REVISION, unless the ACL contains an object-specific ACE, in which case this value must be ACL_REVISION_DS. All ACEs in an ACL must be at the same revision level.</summary>
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
			/// The number of bytes in the ACL actually used to store the ACEs and ACL structure. This may be less than the total number of bytes allocated to
			/// the ACL.
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

			/// <summary>This member is currently reserved and must be zero when setting an attribute and is ignored when getting an attribute.</summary>
			public ushort Reserved;

			/// <summary>The number of values.</summary>
			public uint AttributeCount;

			/// <summary>The actual attribute.</summary>
			public CLAIM_SECURITY_ATTRIBUTE_INFORMATION_V1 Attribute;
		}

		/// <summary>
		/// Defines the mapping of generic access rights to specific and standard access rights for an object. When a client application requests generic access
		/// to an object, that request is mapped to the access rights defined in this structure.
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
		}

		/// <summary>
		/// An LUID is a 64-bit value guaranteed to be unique only on the system on which it was generated. The uniqueness of a locally unique identifier (LUID)
		/// is guaranteed only until the system is restarted.
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
			/// <param name="systemName">Name of the system on which to perform the lookup. Specifying <c>null</c> will query the local system.</param>
			/// <returns>The name retrieved for the LUID.</returns>
			public string GetName(string systemName = null)
			{
				var sb = new StringBuilder(1024);
				var sz = sb.Capacity;
				if (!LookupPrivilegeName(systemName, ref this, sb, ref sz))
					Win32Error.ThrowLastError();
				return sb.ToString();
			}

			/// <summary>Creates a new LUID instance from a privilege name.</summary>
			/// <param name="name">The privilege name.</param>
			/// <param name="systemName">Name of the system on which to perform the lookup. Specifying <c>null</c> will query the local system.</param>
			/// <returns>The LUID instance corresponding to the <paramref name="name"/>.</returns>
			public static LUID FromName(string name, string systemName = null) =>
				!LookupPrivilegeValue(systemName, name, out LUID val) ? throw Win32Error.GetLastError().GetException() : val;

			/// <summary>Creates a new LUID that is unique to the local system only, and uniqueness is guaranteed only until the system is next restarted.</summary>
			/// <returns>A new LUID.</returns>
			public static LUID NewLUID()
			{
				if (!AllocateLocallyUniqueId(out LUID ret))
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
		/// An LUID_AND_ATTRIBUTES structure can represent an LUID whose attributes change frequently, such as when the LUID is used to represent privileges in
		/// the PRIVILEGE_SET structure. Privileges are represented by LUIDs and have attributes indicating whether they are currently enabled or disabled.
		/// </remarks>
		[StructLayout(LayoutKind.Sequential, Pack = 1)]
		public struct LUID_AND_ATTRIBUTES
		{
			/// <summary>Specifies a LUID value.</summary>
			public LUID Luid;

			/// <summary>
			/// Specifies attributes of the LUID. This value contains up to 32 one-bit flags. Its meaning is dependent on the definition and use of the LUID.
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
			/// Specifies the amount of paged pool memory assigned to the user. The paged pool is an area of system memory (physical memory used by the operating
			/// system) for objects that can be written to disk when they are not being used.
			/// <para>The value set in this member is not enforced by the LSA. You should set this member to 0, which causes the default value to be used.</para>
			/// </summary>
			public uint PagedPoolLimit;
			/// <summary>
			/// Specifies the amount of nonpaged pool memory assigned to the user. The nonpaged pool is an area of system memory for objects that cannot be
			/// written to disk but must remain in physical memory as long as they are allocated.
			/// <para>The value set in this member is not enforced by the LSA. You should set this member to 0, which causes the default value to be used.</para>
			/// </summary>
			public uint NonPagedPoolLimit;
			/// <summary>
			/// Specifies the minimum set size assigned to the user. The "working set" of a process is the set of memory pages currently visible to the process
			/// in physical RAM memory. These pages are present in memory when the application is running and available for an application to use without
			/// triggering a page fault.
			/// <para>The value set in this member is not enforced by the LSA. You should set this member to NULL, which causes the default value to be used.</para>
			/// </summary>
			public uint MinimumWorkingSetSize;
			/// <summary>
			/// Specifies the maximum set size assigned to the user.
			/// <para>The value set in this member is not enforced by the LSA. You should set this member to 0, which causes the default value to be used.</para>
			/// </summary>
			public uint MaximumWorkingSetSize;
			/// <summary>
			/// Specifies the maximum size, in bytes, of the paging file, which is a reserved space on disk that backs up committed physical memory on the computer.
			/// <para>The value set in this member is not enforced by the LSA. You should set this member to 0, which causes the default value to be used.</para>
			/// </summary>
			public uint PagefileLimit;
			/// <summary>
			/// Indicates the maximum amount of time the process can run.
			/// <para>The value set in this member is not enforced by the LSA. You should set this member to NULL, which causes the default value to be used.</para>
			/// </summary>
			public long TimeLimit;
		}

		/// <summary>
		/// The SECURITY_DESCRIPTOR structure contains the security information associated with an object. Applications use this structure to set and query an
		/// object's security status.
		/// <para>
		/// Because the internal format of a security descriptor can vary, we recommend that applications not modify the SECURITY_DESCRIPTOR structure directly.
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
			public IntPtr Owner;
			/// <summary>Undocumented.</summary>
			public IntPtr Group;
			/// <summary>Undocumented.</summary>
			public IntPtr Sacl;
			/// <summary>Undocumented.</summary>
			public IntPtr Dacl;
		}

		/// <summary>
		/// The SID_AND_ATTRIBUTES structure represents a security identifier (SID) and its attributes. SIDs are used to uniquely identify users or groups.
		/// </summary>
		[StructLayout(LayoutKind.Sequential)]
		public struct SID_AND_ATTRIBUTES
		{
			/// <summary>A pointer to a SID structure.</summary>
			public IntPtr Sid;

			/// <summary>
			/// Specifies attributes of the SID. This value contains up to 32 one-bit flags. Its meaning depends on the definition and use of the SID.
			/// </summary>
			public uint Attributes;
		}

		/// <summary>The SID_IDENTIFIER_AUTHORITY structure represents the top-level authority of a security identifier (SID).</summary>
		[StructLayout(LayoutKind.Sequential, Pack = 1)]
		[PInvokeData("Winnt.h", MSDNShortId = "aa379598")]
		public struct SID_IDENTIFIER_AUTHORITY
		{
			/// <summary>An array of 6 bytes specifying a SID's top-level authority.</summary>
			[MarshalAs(UnmanagedType.ByValArray, SizeConst = 6)] public byte[] Value;
		}

		/// <summary>The TOKEN_ACCESS_INFORMATION structure specifies all the information in a token that is necessary to perform an access check.</summary>
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
			/// <summary>The app container number for the token or zero if this is not an app container token.<para><c>Windows Server 2008 R2, Windows 7, Windows Server 2008 and Windows Vista:</c> This member is not available.</para></summary>
			public uint AppContainerNumber;
			/// <summary>The app container SID or NULL if this is not an app container token.<para><c>Windows Server 2008 R2, Windows 7, Windows Server 2008 and Windows Vista:</c> This member is not available.</para></summary>
			public PSID PackageSid;
			/// <summary>Pointer to a SID_AND_ATTRIBUTES_HASH structure that specifies a hash of the token's capability SIDs.<para><c>Windows Server 2008 R2, Windows 7, Windows Server 2008 and Windows Vista:</c> This member is not available.</para></summary>
			public IntPtr CapabilitiesHash;
			/// <summary>The protected process trust level of the token.</summary>
			public PSID TrustLevelSid;
			/// <summary>Reserved. Must be set to NULL.<para><c>Prior to Windows 10:</c> This member is not available.</para></summary>
			public IntPtr SecurityAttributes;
		}

		/// <summary>The TOKEN_APPCONTAINER_INFORMATION structure specifies all the information in a token that is necessary for an app container.</summary>
		[StructLayout(LayoutKind.Sequential)]
		public struct TOKEN_APPCONTAINER_INFORMATION
		{
			/// <summary>The security identifier (SID) of the app container.</summary>
			public IntPtr TokenAppContainer;
		}

		/// <summary>The TOKEN_DEFAULT_DACL structure specifies a discretionary access control list (DACL).</summary>
		[StructLayout(LayoutKind.Sequential)]
		[PInvokeData("WinNT.h", MSDNShortId = "aa379623")]
		public struct TOKEN_DEFAULT_DACL
		{
			/// <summary>A pointer to an ACL structure assigned by default to any objects created by the user. The user is represented by the access token.</summary>
			public IntPtr DefaultDacl;
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

		/// <summary>The TOKEN_GROUPS_AND_PRIVILEGES structure contains information about the group security identifiers (SIDs) and privileges in an access token.</summary>
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
			/// <summary>A pointer to an array of SID_AND_ATTRIBUTES structures that contain a set of restricted SIDs and corresponding attributes.
			/// <para>The Attributes members of the SID_AND_ATTRIBUTES structures can have the same values as those listed for the preceding Sids member.</para></summary>
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

		/// <summary>The TOKEN_MANDATORY_POLICY structure specifies the mandatory integrity policy for a token.</summary>
		[StructLayout(LayoutKind.Sequential)]
		[PInvokeData("WinNT.h", MSDNShortId = "bb394728")]
		public struct TOKEN_MANDATORY_POLICY
		{
			/// <summary>The mandatory integrity access policy for the associated token.</summary>
			// TODO: Convert to enum
			public uint Policy;
		}

		/// <summary>The TOKEN_MANDATORY_LABEL structure specifies the mandatory integrity level for a token.</summary>
		[StructLayout(LayoutKind.Sequential)]
		public struct TOKEN_MANDATORY_LABEL
		{
			/// <summary>A SID_AND_ATTRIBUTES structure that specifies the mandatory integrity level of the token.</summary>
			public SID_AND_ATTRIBUTES Label;
		}

		/// <summary>The TOKEN_LINKED_TOKEN structure contains a handle to a token. This token is linked to the token being queried by the GetTokenInformation function or set by the SetTokenInformation function.</summary>
		[StructLayout(LayoutKind.Sequential)]
		[PInvokeData("WinNT.h", MSDNShortId = "bb530719")]
		public struct TOKEN_LINKED_TOKEN
		{
			/// <summary>A handle to the linked token. When you have finished using the handle, close it by calling the CloseHandle function.</summary>
			public IntPtr LinkedToken;
		}

		/// <summary>The TOKEN_ORIGIN structure contains information about the origin of the logon session. This structure is used by the GetTokenInformation function.</summary>
		[StructLayout(LayoutKind.Sequential)]
		[PInvokeData("WinNT.h", MSDNShortId = "aa379627")]
		public struct TOKEN_ORIGIN
		{
			/// <summary>Locally unique identifier (LUID) for the logon session. If the token passed to GetTokenInformation resulted from a logon using explicit credentials, such as passing name, domain, and password to the LogonUser function, then this member will contain the ID of the logon session that created it. If the token resulted from network authentication, such as a call to AcceptSecurityContext, or a call to LogonUser with dwLogonType set to LOGON32_LOGON_NETWORK or LOGON32_LOGON_NETWORK_CLEARTEXT, then this member will be zero.</summary>
			public LUID OriginatingLogonSession;
		}

		/// <summary>The TOKEN_OWNER structure contains the default owner security identifier (SID) that will be applied to newly created objects.</summary>
		[StructLayout(LayoutKind.Sequential)]
		[PInvokeData("WinNT.h", MSDNShortId = "aa379628")]
		public struct TOKEN_OWNER
		{
			/// <summary>A pointer to a SID structure representing a user who will become the owner of any objects created by a process using this access token. The SID must be one of the user or group SIDs already in the token.</summary>
			public IntPtr Owner;
		}

		/// <summary>The TOKEN_PRIMARY_GROUP structure specifies a group security identifier (SID) for an access token.</summary>
		[StructLayout(LayoutKind.Sequential)]
		[PInvokeData("WinNT.h", MSDNShortId = "aa379629")]
		public struct TOKEN_PRIMARY_GROUP
		{
			/// <summary>A pointer to a SID structure representing a group that will become the primary group of any objects created by a process using this access token. The SID must be one of the group SIDs already in the token.</summary>
			public IntPtr PrimaryGroup;
		}

		/// <summary>The TOKEN_SOURCE structure identifies the source of an access token.</summary>
		[StructLayout(LayoutKind.Sequential)]
		[PInvokeData("WinNT.h", MSDNShortId = "aa379631")]
		public struct TOKEN_SOURCE
		{
			private const int TOKEN_SOURCE_LENGTH = 8;

			/// <summary>Specifies an 8-byte character string used to identify the source of an access token. This is used to distinguish between such sources as Session Manager, LAN Manager, and RPC Server. A string, rather than a constant, is used to identify the source so users and developers can make extensions to the system, such as by adding other networks, that act as the source of access tokens.</summary>
			[MarshalAs(UnmanagedType.ByValArray, SizeConst = TOKEN_SOURCE_LENGTH)]
			public char[] SourceName;
			/// <summary>Specifies a locally unique identifier (LUID) provided by the source component named by the SourceName member. This value aids the source component in relating context blocks, such as session-control structures, to the token. This value is typically, but not necessarily, an LUID.</summary>
			public LUID SourceIdentifier;
		}

		/// <summary>
		/// The TOKEN_STATISTICS structure contains information about an access token. An application can retrieve this information by calling the
		/// GetTokenInformation function.
		/// </summary>
		[StructLayout(LayoutKind.Sequential, CharSet = CharSet.Unicode)]
		[PInvokeData("WinNT.h", MSDNShortId = "aa379632")]
		public struct TOKEN_STATISTICS
		{
			/// <summary>Specifies a locally unique identifier (LUID) that identifies this instance of the token object.</summary>
			public LUID TokenId;
			/// <summary>Specifies an LUID assigned to the session this token represents. There can be many tokens representing a single logon session.</summary>
			public LUID AuthenticationId;
			/// <summary>Specifies the time at which this token expires. Expiration times for access tokens are not currently supported.</summary>
			public long ExpirationTime;
			/// <summary>Specifies a TOKEN_TYPE enumeration type indicating whether the token is a primary or impersonation token.</summary>
			public TOKEN_TYPE TokenType;
			/// <summary>Specifies a SECURITY_IMPERSONATION_LEVEL enumeration type indicating the impersonation level of the token. This member is valid only if the TokenType is TokenImpersonation.</summary>
			public SECURITY_IMPERSONATION_LEVEL ImpersonationLevel;
			/// <summary>Specifies the amount, in bytes, of memory allocated for storing default protection and a primary group identifier.</summary>
			public uint DynamicCharged;
			/// <summary>Specifies the portion of memory allocated for storing default protection and a primary group identifier not already in use. This value is returned as a count of free bytes.</summary>
			public uint DynamicAvailable;
			/// <summary>Specifies the number of supplemental group security identifiers (SIDs) included in the token.</summary>
			public uint GroupCount;
			/// <summary>Specifies the number of privileges included in the token.</summary>
			public uint PrivilegeCount;
			/// <summary>Specifies an LUID that changes each time the token is modified. An application can use this value as a test of whether a security context has changed since it was last used.</summary>
			public LUID ModifiedId;
		}
		
		/// <summary>The TOKEN_USER structure identifies the user associated with an access token.</summary>
		[StructLayout(LayoutKind.Sequential)]
		public struct TOKEN_USER
		{
			/// <summary>Specifies a SID_AND_ATTRIBUTES structure representing the user associated with the access token. There are currently no attributes defined for user security identifiers (SIDs).</summary>
			public SID_AND_ATTRIBUTES User;
		}

		/// <summary>
		/// The PRIVILEGE_SET structure specifies a set of privileges. It is also used to indicate which, if any, privileges are held by a user or group
		/// requesting access to an object.
		/// </summary>
		[StructLayout(LayoutKind.Sequential)]
		public class PRIVILEGE_SET
		{
			/// <summary>Specifies the number of privileges in the privilege set.</summary>
			public uint PrivilegeCount;

			/// <summary>
			/// Specifies a control flag related to the privileges. The PRIVILEGE_SET_ALL_NECESSARY control flag is currently defined. It indicates that all of
			/// the specified privileges must be held by the process requesting access. If this flag is not set, the presence of any privileges in the user's
			/// access token grants the access.
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
			public uint SizeInBytes => Marshaler.GetSize(PrivilegeCount);

			/// <summary>Returns a <see cref="System.String"/> that represents this instance.</summary>
			/// <returns>A <see cref="System.String"/> that represents this instance.</returns>
			public override string ToString() => $"Count:{PrivilegeCount}";

			internal class Marshaler : ICustomMarshaler
			{
				public static ICustomMarshaler GetInstance(string cookie) => new Marshaler();

				public void CleanUpManagedData(object ManagedObj)
				{
				}

				public void CleanUpNativeData(IntPtr pNativeData)
				{
					Marshal.FreeCoTaskMem(pNativeData);
				}

				public int GetNativeDataSize() => -1;

				public IntPtr MarshalManagedToNative(object ManagedObj)
				{
					if (!(ManagedObj is PRIVILEGE_SET)) return IntPtr.Zero;
					var ps = (PRIVILEGE_SET)ManagedObj;
					var ptr = Marshal.AllocCoTaskMem((int)GetSize(ps.PrivilegeCount));
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

				internal static uint GetSize(uint privCount) => (uint)Marshal.SizeOf(typeof(uint)) * 2 + (uint)(Marshal.SizeOf(typeof(LUID_AND_ATTRIBUTES)) * (privCount == 0 ? 1 : privCount));
			}
		}

		/// <summary><para>The <c>SID_IDENTIFIER_AUTHORITY</c> structure represents the top-level authority of a security identifier (SID).</para></summary><remarks><para>The identifier authority value identifies the agency that issued the SID. The following identifier authorities are predefined.</para><list type="table"><listheader><term>Identifier authority</term><term>Value</term></listheader><item><term>SECURITY_NULL_SID_AUTHORITY</term><term>0</term></item><item><term>SECURITY_WORLD_SID_AUTHORITY</term><term>1</term></item><item><term>SECURITY_LOCAL_SID_AUTHORITY</term><term>2</term></item><item><term>SECURITY_CREATOR_SID_AUTHORITY</term><term>3</term></item><item><term>SECURITY_NON_UNIQUE_AUTHORITY</term><term>4</term></item><item><term>SECURITY_NT_AUTHORITY</term><term>5</term></item><item><term>SECURITY_RESOURCE_MANAGER_AUTHORITY</term><term>9</term></item></list><para>A SID must contain a top-level authority and at least one relative identifier (RID) value.</para></remarks>
		// https://docs.microsoft.com/en-us/windows/desktop/api/winnt/ns-winnt-_sid_identifier_authority
		// typedef struct _SID_IDENTIFIER_AUTHORITY { BYTE Value[6]; } SID_IDENTIFIER_AUTHORITY, *PSID_IDENTIFIER_AUTHORITY;
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
			/// Specifies an array of LUID_AND_ATTRIBUTES structures. Each structure contains the LUID and attributes of a privilege. To get the name of the
			/// privilege associated with a LUID, call the LookupPrivilegeName function, passing the address of the LUID as the value of the lpLuid parameter.
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

				private Marshaler(string cookie) { allocOut = cookie == "Out"; }

				public static ICustomMarshaler GetInstance(string cookie) => new Marshaler(cookie);

				/// <summary>Performs necessary cleanup of the managed data when it is no longer needed.</summary>
				/// <param name="ManagedObj">The managed object to be destroyed.</param>
				public void CleanUpManagedData(object ManagedObj) { }

				/// <summary>Performs necessary cleanup of the unmanaged data when it is no longer needed.</summary>
				/// <param name="pNativeData">A pointer to the unmanaged data to be destroyed.</param>
				public void CleanUpNativeData(IntPtr pNativeData) { Marshal.FreeCoTaskMem(pNativeData); }

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

		/// <summary>
		/// A SafeHandle for security descriptors. If owned, will call LocalFree on the pointer when disposed.
		/// </summary>
		public class SafeSecurityDescriptor : GenericSafeHandle
		{
			private static LocalMemoryMethods lmem = new LocalMemoryMethods();

			/// <summary>Initializes a new instance of the <see cref="SafeSecurityDescriptor"/> class.</summary>
			public SafeSecurityDescriptor() : this(IntPtr.Zero) { }

			/// <summary>Initializes a new instance of the <see cref="SafeSecurityDescriptor"/> class from an existing pointer.</summary>
			/// <param name="pSecurityDescriptor">The security descriptor pointer.</param>
			/// <param name="own">if set to <c>true</c> indicates that this pointer should be freed when disposed.</param>
			public SafeSecurityDescriptor(IntPtr pSecurityDescriptor, bool own = true) : base(pSecurityDescriptor, h => { lmem.FreeMem(h); return true; }, own) { }

			/// <summary>Initializes a new instance of the <see cref="SafeSecurityDescriptor"/> class to an empty memory buffer.</summary>
			/// <param name="size">The size of the uninitialized security descriptor.</param>
			public SafeSecurityDescriptor(int size) : this(lmem.AllocMem(size), true) { }

			/// <summary>The null value for a SafeSecurityDescriptor.</summary>
			public static readonly SafeSecurityDescriptor Null = new SafeSecurityDescriptor();
		}
	}
}