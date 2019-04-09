using System;
using System.ComponentModel;
using System.Linq;
using System.Runtime.ConstrainedExecution;
using System.Runtime.InteropServices;
using Vanara.Extensions;
using Vanara.InteropServices;
using static Vanara.PInvoke.Kernel32;

namespace Vanara.PInvoke
{
	public static partial class AdvApi32
	{
		/// <summary>Specifies the logon provider.</summary>
		public enum LogonUserProvider
		{
			/// <summary>
			/// Use the standard logon provider for the system. The default security provider is negotiate, unless you pass NULL for the
			/// domain name and the user name is not in UPN format. In this case, the default provider is NTLM.
			/// </summary>
			LOGON32_PROVIDER_DEFAULT = 0,

			/// <summary>Use the Windows NT 3.5 logon provider.</summary>
			LOGON32_PROVIDER_WINNT35 = 1,

			/// <summary>Use the NTLM logon provider.</summary>
			LOGON32_PROVIDER_WINNT40 = 2,

			/// <summary>Use the negotiate logon provider.</summary>
			LOGON32_PROVIDER_WINNT50 = 3,

			/// <summary>Use the virtual logon provider.</summary>
			LOGON32_PROVIDER_VIRTUAL = 4
		}

		/// <summary>The type of logon operation to perform.</summary>
		public enum LogonUserType
		{
			/// <summary>
			/// This logon type is intended for users who will be interactively using the computer, such as a user being logged on by a
			/// terminal server, remote shell, or similar process. This logon type has the additional expense of caching logon information
			/// for disconnected operations; therefore, it is inappropriate for some client/server applications, such as a mail server.
			/// </summary>
			LOGON32_LOGON_INTERACTIVE = 2,

			/// <summary>
			/// This logon type is intended for high performance servers to authenticate plaintext passwords. The LogonUser function does not
			/// cache credentials for this logon type.
			/// </summary>
			LOGON32_LOGON_NETWORK = 3,

			/// <summary>
			/// This logon type is intended for batch servers, where processes may be executing on behalf of a user without their direct
			/// intervention. This type is also for higher performance servers that process many plaintext authentication attempts at a time,
			/// such as mail or web servers.
			/// </summary>
			LOGON32_LOGON_BATCH = 4,

			/// <summary>Indicates a service-type logon. The account provided must have the service privilege enabled.</summary>
			LOGON32_LOGON_SERVICE = 5,

			/// <summary>
			/// GINAs are no longer supported.
			/// <para>
			/// <c>Windows Server 2003 and Windows XP:</c> This logon type is for GINA DLLs that log on users who will be interactively using
			/// the computer. This logon type can generate a unique audit record that shows when the workstation was unlocked.
			/// </para>
			/// </summary>
			LOGON32_LOGON_UNLOCK = 7,

			/// <summary>
			/// This logon type preserves the name and password in the authentication package, which allows the server to make connections to
			/// other network servers while impersonating the client. A server can accept plain-text credentials from a client, call
			/// LogonUser, verify that the user can access the system across the network, and still communicate with other servers.
			/// </summary>
			LOGON32_LOGON_NETWORK_CLEARTEXT = 8,

			/// <summary>
			/// This logon type allows the caller to clone its current token and specify new credentials for outbound connections. The new
			/// logon session has the same local identifier but uses different credentials for other network connections. This logon type is
			/// supported only by the LOGON32_PROVIDER_WINNT50 logon provider.
			/// </summary>
			LOGON32_LOGON_NEW_CREDENTIALS = 9
		}

		/// <summary>
		/// The <c>AccessCheck</c> function determines whether a security descriptor grants a specified set of access rights to the client
		/// identified by an access token. Typically, server applications use this function to check access to a private object.
		/// </summary>
		/// <param name="pSecurityDescriptor">A pointer to a SECURITY_DESCRIPTOR structure against which access is checked.</param>
		/// <param name="ClientToken">
		/// A handle to an impersonation token that represents the client that is attempting to gain access. The handle must have TOKEN_QUERY
		/// access to the token; otherwise, the function fails with ERROR_ACCESS_DENIED.
		/// </param>
		/// <param name="DesiredAccess">
		/// <para>
		/// Access mask that specifies the access rights to check. This mask must have been mapped by the MapGenericMask function to contain
		/// no generic access rights.
		/// </para>
		/// <para>
		/// If this parameter is MAXIMUM_ALLOWED, the function sets the GrantedAccess access mask to indicate the maximum access rights the
		/// security descriptor allows the client.
		/// </para>
		/// </param>
		/// <param name="GenericMapping">
		/// A pointer to the GENERIC_MAPPING structure associated with the object for which access is being checked.
		/// </param>
		/// <param name="PrivilegeSet">
		/// A pointer to a PRIVILEGE_SET structure that receives the privileges used to perform the access validation. If no privileges were
		/// used, the function sets the <c>PrivilegeCount</c> member to zero.
		/// </param>
		/// <param name="PrivilegeSetLength">Specifies the size, in bytes, of the buffer pointed to by the PrivilegeSet parameter.</param>
		/// <param name="GrantedAccess">
		/// A pointer to an access mask that receives the granted access rights. If AccessStatus is set to <c>FALSE</c>, the function sets
		/// the access mask to zero. If the function fails, it does not set the access mask.
		/// </param>
		/// <param name="AccessStatus">
		/// A pointer to a variable that receives the results of the access check. If the security descriptor allows the requested access
		/// rights to the client identified by the access token, AccessStatus is set to <c>TRUE</c>. Otherwise, AccessStatus is set to
		/// <c>FALSE</c>, and you can call GetLastError to get extended error information.
		/// </param>
		/// <returns>
		/// <para>If the function succeeds, the return value is nonzero.</para>
		/// <para>If the function fails, the return value is zero. To get extended error information, call GetLastError.</para>
		/// </returns>
		/// <remarks>
		/// <para>For more information, see the How AccessCheck Works overview.</para>
		/// <para>
		/// The <c>AccessCheck</c> function compares the specified security descriptor with the specified access token and indicates, in the
		/// AccessStatus parameter, whether access is granted or denied. If access is granted, the requested access mask becomes the object's
		/// granted access mask.
		/// </para>
		/// <para>
		/// If the security descriptor's DACL is <c>NULL</c>, the AccessStatus parameter returns <c>TRUE</c>, which indicates that the client
		/// has the requested access.
		/// </para>
		/// <para>
		/// The <c>AccessCheck</c> function fails with ERROR_INVALID_SECURITY_DESCR if the security descriptor does not contain owner and
		/// group SIDs.
		/// </para>
		/// <para>
		/// The <c>AccessCheck</c> function does not generate an audit. If your application requires audits for access checks, use functions
		/// such as AccessCheckAndAuditAlarm, AccessCheckByTypeAndAuditAlarm, AccessCheckByTypeResultListAndAuditAlarm, or
		/// AccessCheckByTypeResultListAndAuditAlarmByHandle, instead of <c>AccessCheck</c>.
		/// </para>
		/// <para>Examples</para>
		/// <para>For an example that uses this function, see Verifying Client Access with ACLs.</para>
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows/desktop/api/securitybaseapi/nf-securitybaseapi-accesscheck BOOL AccessCheck(
		// PSECURITY_DESCRIPTOR pSecurityDescriptor, HANDLE ClientToken, DWORD DesiredAccess, PGENERIC_MAPPING GenericMapping, PPRIVILEGE_SET
		// PrivilegeSet, LPDWORD PrivilegeSetLength, LPDWORD GrantedAccess, LPBOOL AccessStatus );
		[DllImport(Lib.AdvApi32, SetLastError = true, ExactSpelling = true)]
		[PInvokeData("securitybaseapi.h", MSDNShortId = "d9fd2e44-5782-40c9-a1cf-1788ca7afc50")]
		[return: MarshalAs(UnmanagedType.Bool)]
		public static extern bool AccessCheck(PSECURITY_DESCRIPTOR pSecurityDescriptor, HTOKEN ClientToken, uint DesiredAccess, in GENERIC_MAPPING GenericMapping,
			[In, Out, MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef = typeof(PRIVILEGE_SET.Marshaler))] ref PRIVILEGE_SET PrivilegeSet, ref uint PrivilegeSetLength,
			out uint GrantedAccess, [MarshalAs(UnmanagedType.Bool)] out bool AccessStatus);

		/// <summary>
		/// The <c>AccessCheckByType</c> function determines whether a security descriptor grants a specified set of access rights to the
		/// client identified by an access token. The function can check the client's access to a hierarchy of objects, such as an object,
		/// its property sets, and properties. The function grants or denies access to the hierarchy as a whole. Typically, server
		/// applications use this function to check access to a private object.
		/// </summary>
		/// <param name="pSecurityDescriptor">A pointer to a SECURITY_DESCRIPTOR structure against which access is checked.</param>
		/// <param name="PrincipalSelfSid">
		/// <para>
		/// A pointer to a security identifier (SID). If the security descriptor is associated with an object that represents a principal
		/// (for example, a user object), the PrincipalSelfSid parameter should be the SID of the object. When evaluating access, this SID
		/// logically replaces the SID in any access control entry containing the well-known PRINCIPAL_SELF SID (S-1-5-10). For information
		/// about well-known SIDs, see Well-known SIDs.
		/// </para>
		/// <para>Set this parameter to <c>NULL</c> if the protected object does not represent a principal.</para>
		/// </param>
		/// <param name="ClientToken">
		/// A handle to an impersonation token that represents the client attempting to gain access. The handle must have TOKEN_QUERY access
		/// to the token; otherwise, the function fails with ERROR_ACCESS_DENIED.
		/// </param>
		/// <param name="DesiredAccess">
		/// <para>
		/// Access mask that specifies the access rights to check. This mask must have been mapped by the MapGenericMask function to contain
		/// no generic access rights.
		/// </para>
		/// <para>
		/// If this parameter is MAXIMUM_ALLOWED, the function sets the GrantedAccess access mask to indicate the maximum access rights the
		/// security descriptor allows the client.
		/// </para>
		/// </param>
		/// <param name="ObjectTypeList">
		/// <para>
		/// A pointer to an array of OBJECT_TYPE_LIST structures that identify the hierarchy of object types for which to check access. Each
		/// element in the array specifies a GUID that identifies the object type and a value indicating the level of the object type in the
		/// hierarchy of object types. The array should not have two elements with the same GUID.
		/// </para>
		/// <para>
		/// The array must have at least one element. The first element in the array must be at level zero and identify the object itself.
		/// The array can have only one level zero element. The second element is a subobject, such as a property set, at level 1. Following
		/// each level 1 entry are subordinate entries for the level 2 through 4 subobjects. Thus, the levels for the elements in the array
		/// might be {0, 1, 2, 2, 1, 2, 3}. If the object type list is out of order, <c>AccessCheckByType</c> fails and GetLastError returns ERROR_INVALID_PARAMETER.
		/// </para>
		/// <para>If ObjectTypeList is <c>NULL</c>, <c>AccessCheckByType</c> is the same as the AccessCheck function.</para>
		/// </param>
		/// <param name="ObjectTypeListLength">Specifies the number of elements in the ObjectTypeList array.</param>
		/// <param name="GenericMapping">
		/// A pointer to the GENERIC_MAPPING structure associated with the object for which access is being checked. The <c>GenericAll</c>
		/// member of the <c>GENERIC_MAPPING</c> structure should contain all the access rights that can be granted by the resource manager,
		/// including STANDARD_RIGHTS_ALL and all of the rights that are set in the <c>GenericRead</c>, <c>GenericWrite</c>, and
		/// <c>GenericExecute</c> members.
		/// </param>
		/// <param name="PrivilegeSet">
		/// A pointer to a PRIVILEGE_SET structure that receives the privileges used to perform the access validation. If no privileges were
		/// used, the function sets the <c>PrivilegeCount</c> member to zero.
		/// </param>
		/// <param name="PrivilegeSetLength">Specifies the size, in bytes, of the buffer pointed to by the PrivilegeSet parameter.</param>
		/// <param name="GrantedAccess">
		/// A pointer to an access mask that receives the granted access rights. If AccessStatus is set to <c>FALSE</c>, the function sets
		/// the access mask to zero. If the function fails, it does not set the access mask.
		/// </param>
		/// <param name="AccessStatus">
		/// A pointer to a variable that receives the results of the access check. If the security descriptor allows the requested access
		/// rights to the client identified by the access token, AccessStatus is set to <c>TRUE</c>. Otherwise, AccessStatus is set to
		/// <c>FALSE</c>, and you can call GetLastError to get extended error information.
		/// </param>
		/// <returns>
		/// <para>If the function succeeds, the return value is nonzero.</para>
		/// <para>If the function fails, the return value is zero. To get extended error information, call GetLastError.</para>
		/// </returns>
		/// <remarks>
		/// <para>For more information, see the How AccessCheck Works overview.</para>
		/// <para>
		/// The <c>AccessCheckByType</c> function compares the specified security descriptor with the specified access token and indicates,
		/// in the AccessStatus parameter, whether access is granted or denied.
		/// </para>
		/// <para>
		/// The ObjectTypeList array does not necessarily represent the entire defined object. Rather, it represents that subset of the
		/// object for which to check access. For instance, to check access to two properties in a property set, specify an object type list
		/// with four elements: the object itself at level zero, the property set at level 1, and the two properties at level 2.
		/// </para>
		/// <para>
		/// The <c>AccessCheckByType</c> function evaluates ACEs that apply to the object itself and object-specific ACEs for the object
		/// types listed in the ObjectTypeList array. The function ignores object-specific ACEs for object types not listed in the
		/// ObjectTypeList array. Thus, the results returned in the AccessStatus parameter indicate the access allowed to the subset of the
		/// object defined by the ObjectTypeList parameter, not to the entire object.
		/// </para>
		/// <para>
		/// For more information about how a hierarchy of ACEs controls access to an object and its subobjects, see ACEs to Control Access to
		/// an Object's Properties.
		/// </para>
		/// <para>
		/// If the security descriptor's DACL is <c>NULL</c>, the AccessStatus parameter returns <c>TRUE</c>, indicating that the client has
		/// the requested access.
		/// </para>
		/// <para>If the security descriptor does not contain owner and group SIDs, <c>AccessCheckByType</c> fails with ERROR_INVALID_SECURITY_DESCR.</para>
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows/desktop/api/securitybaseapi/nf-securitybaseapi-accesscheckbytype BOOL AccessCheckByType(
		// PSECURITY_DESCRIPTOR pSecurityDescriptor, PSID PrincipalSelfSid, HANDLE ClientToken, DWORD DesiredAccess, POBJECT_TYPE_LIST
		// ObjectTypeList, DWORD ObjectTypeListLength, PGENERIC_MAPPING GenericMapping, PPRIVILEGE_SET PrivilegeSet, LPDWORD
		// PrivilegeSetLength, LPDWORD GrantedAccess, LPBOOL AccessStatus );
		[DllImport(Lib.AdvApi32, SetLastError = true, ExactSpelling = true)]
		[PInvokeData("securitybaseapi.h", MSDNShortId = "50acfc17-459d-464c-9927-88b32dd424c7")]
		[return: MarshalAs(UnmanagedType.Bool)]
		public static extern bool AccessCheckByType(PSECURITY_DESCRIPTOR pSecurityDescriptor, PSID PrincipalSelfSid, HTOKEN ClientToken, uint DesiredAccess, OBJECT_TYPE_LIST[] ObjectTypeList,
			uint ObjectTypeListLength, in GENERIC_MAPPING GenericMapping, [Out, MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef = typeof(PRIVILEGE_SET.Marshaler))] PRIVILEGE_SET PrivilegeSet,
			ref uint PrivilegeSetLength, out uint GrantedAccess, [MarshalAs(UnmanagedType.Bool)] out bool AccessStatus);

		/// <summary>
		/// The <c>AccessCheckByTypeResultList</c> function determines whether a security descriptor grants a specified set of access rights
		/// to the client identified by an access token. The function can check the client's access to a hierarchy of objects, such as an
		/// object, its property sets, and properties. The function reports the access rights granted or denied to each object type in the
		/// hierarchy. Typically, server applications use this function to check access to a private object.
		/// </summary>
		/// <param name="pSecurityDescriptor">A pointer to a SECURITY_DESCRIPTOR structure against which access is checked.</param>
		/// <param name="PrincipalSelfSid">
		/// <para>
		/// A pointer to a security identifier (SID). If the security descriptor is associated with an object that represents a principal
		/// (for example, a user object), the PrincipalSelfSid parameter should be the SID of the object. When evaluating access, this SID
		/// logically replaces the SID in any access control entry (ACE) that contains the well-known PRINCIPAL_SELF SID (S-1-5-10). For
		/// information about well-known SIDs, see Well-known SIDs.
		/// </para>
		/// <para>If the protected object does not represent a principal, set this parameter to <c>NULL</c>.</para>
		/// </param>
		/// <param name="ClientToken">
		/// A handle to an impersonation token that represents the client attempting to gain access. The handle must have TOKEN_QUERY access
		/// to the token; otherwise, the function fails with ERROR_ACCESS_DENIED.
		/// </param>
		/// <param name="DesiredAccess">
		/// <para>
		/// An access mask that specifies the access rights to check. This mask must have been mapped by the MapGenericMask function to
		/// contain no generic access rights.
		/// </para>
		/// <para>
		/// If this parameter is MAXIMUM_ALLOWED, the function sets the access masks in the GrantedAccess array to indicate the client's
		/// maximum access rights to each element in the object type list.
		/// </para>
		/// </param>
		/// <param name="ObjectTypeList">
		/// <para>
		/// A pointer to an array of OBJECT_TYPE_LIST structures that identify the hierarchy of object types for which to check access. Each
		/// element in the array specifies a GUID that identifies the object type and a value that indicates the level of the object type in
		/// the hierarchy of object types. The array should not have two elements with the same GUID.
		/// </para>
		/// <para>
		/// The array must have at least one element. The first element in the array must be at level zero and identify the object itself.
		/// The array can have only one level zero element. The second element is a subobject, such as a property set, at level 1. Following
		/// each level 1 entry are subordinate entries for the level 2 through 4 subobjects. Thus, the levels for the elements in the array
		/// might be {0, 1, 2, 2, 1, 2, 3}. If the object type list is out of order, <c>AccessCheckByTypeResultList</c> fails and
		/// GetLastError returns ERROR_INVALID_PARAMETER.
		/// </para>
		/// </param>
		/// <param name="ObjectTypeListLength">
		/// The number of elements in the ObjectTypeList array. This is also the number of elements in the arrays pointed to by the
		/// GrantedAccessList and AccessStatusList parameters.
		/// </param>
		/// <param name="GenericMapping">
		/// A pointer to the GENERIC_MAPPING structure associated with the object for which access is being checked.
		/// </param>
		/// <param name="PrivilegeSet">
		/// A pointer to a PRIVILEGE_SET structure that receives the privileges used to perform the access validation. If no privileges were
		/// used, the function sets the <c>PrivilegeCount</c> member to zero.
		/// </param>
		/// <param name="PrivilegeSetLength">The size, in bytes, of the buffer pointed to by the PrivilegeSet parameter.</param>
		/// <param name="GrantedAccessList">
		/// A pointer to an array of access masks. The function sets each access mask to indicate the access rights granted to the
		/// corresponding element in the object type list. If the function fails, it does not set the access masks.
		/// </param>
		/// <param name="AccessStatusList">
		/// A pointer to an array of status codes for the corresponding elements in the object type list. The function sets an element to
		/// zero to indicate success or a nonzero value to indicate the specific error during the access check. If the function fails, it
		/// does not set any of the elements in the array.
		/// </param>
		/// <returns>
		/// <para>If the function succeeds, the function returns nonzero.</para>
		/// <para>If the function fails, it returns zero. To get extended error information, call GetLastError.</para>
		/// </returns>
		/// <remarks>
		/// <para>For more information, see the How AccessCheck Works overview.</para>
		/// <para>
		/// The <c>AccessCheckByTypeResultList</c> function compares the specified security descriptor with the specified access token and
		/// indicates, in the AccessStatusList parameter, whether access is granted or denied for each of the elements in the object types list.
		/// </para>
		/// <para>
		/// The ObjectTypeList array does not necessarily represent the entire defined object. Rather, it represents that subset of the
		/// object for which to check access. For instance, to check access to two properties in a property set, specify an object type list
		/// with four elements: the object itself at level zero, the property set at level 1, and the two properties at level 2.
		/// </para>
		/// <para>
		/// The <c>AccessCheckByTypeResultList</c> function evaluates ACEs that apply to the object itself and object-specific ACEs for the
		/// object types listed in the ObjectTypeList array. The function ignores object-specific ACEs for object types not listed in the
		/// ObjectTypeList array. Thus, the results returned for element zero in the AccessStatusList parameter indicate the access allowed
		/// to the subset of the object defined by the ObjectTypeList parameter, not to the entire object.
		/// </para>
		/// <para>
		/// For more information about how a hierarchy of ACEs controls access to an object and its subobjects, see ACEs to Control Access to
		/// an Object's Properties.
		/// </para>
		/// <para>
		/// If the security descriptor's discretionary access control list (DACL) is <c>NULL</c>, the function grants the requested access to
		/// all of the elements in the object type list.
		/// </para>
		/// <para>If the security descriptor does not contain owner and group SIDs, <c>AccessCheckByTypeResultList</c> fails with ERROR_INVALID_SECURITY_DESCR.</para>
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows/desktop/api/securitybaseapi/nf-securitybaseapi-accesscheckbytyperesultlist BOOL
		// AccessCheckByTypeResultList( PSECURITY_DESCRIPTOR pSecurityDescriptor, PSID PrincipalSelfSid, HANDLE ClientToken, DWORD
		// DesiredAccess, POBJECT_TYPE_LIST ObjectTypeList, DWORD ObjectTypeListLength, PGENERIC_MAPPING GenericMapping, PPRIVILEGE_SET
		// PrivilegeSet, LPDWORD PrivilegeSetLength, LPDWORD GrantedAccessList, LPDWORD AccessStatusList );
		[DllImport(Lib.AdvApi32, SetLastError = true, ExactSpelling = true)]
		[PInvokeData("securitybaseapi.h", MSDNShortId = "ce713421-d4ff-48ed-b751-5e5c5397d820")]
		[return: MarshalAs(UnmanagedType.Bool)]
		public static extern bool AccessCheckByTypeResultList(PSECURITY_DESCRIPTOR pSecurityDescriptor, PSID PrincipalSelfSid, HTOKEN ClientToken, uint DesiredAccess, [In] OBJECT_TYPE_LIST[] ObjectTypeList,
			uint ObjectTypeListLength, in GENERIC_MAPPING GenericMapping, [Out, MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef = typeof(PRIVILEGE_SET.Marshaler))] PRIVILEGE_SET PrivilegeSet,
			ref uint PrivilegeSetLength, out uint GrantedAccessList, out uint AccessStatusList);

		/// <summary>
		/// <para>
		/// The <c>AddAccessAllowedAce</c> function adds an access-allowed access control entry (ACE) to an access control list (ACL). The
		/// access is granted to a specified security identifier (SID).
		/// </para>
		/// <para>To control whether the new ACE can be inherited by child objects, use the AddAccessAllowedAceEx function.</para>
		/// </summary>
		/// <param name="pAcl">
		/// A pointer to an ACL. This function adds an access-allowed ACE to the end of this ACL. The ACE is in the form of an
		/// ACCESS_ALLOWED_ACE structure.
		/// </param>
		/// <param name="dwAceRevision">
		/// <para>Specifies the revision level of the ACL being modified.</para>
		/// <para>This value can be ACL_REVISION or ACL_REVISION_DS. Use ACL_REVISION_DS if the ACL contains object-specific ACEs.</para>
		/// </param>
		/// <param name="AccessMask">Specifies the mask of access rights to be granted to the specified SID.</param>
		/// <param name="pSid">A pointer to the SID representing a user, group, or logon account being granted access.</param>
		/// <returns>
		/// <para>If the function succeeds, the return value is nonzero.</para>
		/// <para>
		/// If the function fails, the return value is zero. To get extended error information, call GetLastError. The following are possible
		/// error values.
		/// </para>
		/// <list type="table">
		/// <listheader>
		/// <term>Return code</term>
		/// <term>Description</term>
		/// </listheader>
		/// <item>
		/// <term>ERROR_ALLOTTED_SPACE_EXCEEDED</term>
		/// <term>The new ACE does not fit into the ACL. A larger ACL buffer is required.</term>
		/// </item>
		/// <item>
		/// <term>ERROR_INVALID_ACL</term>
		/// <term>The specified ACL is not properly formed.</term>
		/// </item>
		/// <item>
		/// <term>ERROR_INVALID_SID</term>
		/// <term>The specified SID is not structurally valid.</term>
		/// </item>
		/// <item>
		/// <term>ERROR_REVISION_MISMATCH</term>
		/// <term>The specified revision is not known or is incompatible with that of the ACL.</term>
		/// </item>
		/// <item>
		/// <term>ERROR_SUCCESS</term>
		/// <term>The ACE was successfully added.</term>
		/// </item>
		/// </list>
		/// </returns>
		/// <remarks>
		/// <para>The addition of an access-allowed ACE to an ACL is the most common form of ACL modification.</para>
		/// <para>
		/// The <c>AddAccessAllowedAce</c> and AddAccessDeniedAce functions add a new ACE to the end of the list of ACEs for the ACL. These
		/// functions do not automatically place the new ACE in the proper canonical order. It is the caller's responsibility to ensure that
		/// the ACL is in canonical order by adding ACEs in the proper sequence.
		/// </para>
		/// <para>
		/// The ACE_HEADER structure placed in the ACE by the <c>AddAccessAllowedAce</c> function specifies a type and size, but provides no
		/// inheritance and no ACE flags.
		/// </para>
		/// <para>Examples</para>
		/// <para>For an example that uses this function, see Starting an Interactive Client Process.</para>
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows/desktop/api/securitybaseapi/nf-securitybaseapi-addaccessallowedace
		// BOOL AddAccessAllowedAce( PACL pAcl, DWORD dwAceRevision, DWORD AccessMask, PSID pSid );
		[DllImport(Lib.AdvApi32, SetLastError = true, ExactSpelling = true)]
		[PInvokeData("securitybaseapi.h", MSDNShortId = "1004353a-f907-4452-9c0f-85eba0ece813")]
		[return: MarshalAs(UnmanagedType.Bool)]
		public static extern bool AddAccessAllowedAce(PACL pAcl, uint dwAceRevision, uint AccessMask, PSID pSid);

		/// <summary>
		/// <para>
		/// The <c>AddAccessDeniedAce</c> function adds an access-denied access control entry (ACE) to an access control list (ACL). The
		/// access is denied to a specified security identifier (SID).
		/// </para>
		/// <para>To control whether the new ACE can be inherited by child objects, use the AddAccessDeniedAceEx function.</para>
		/// </summary>
		/// <param name="pAcl">
		/// A pointer to an ACL . This function adds an access-denied ACE to the end of this ACL. The ACE is in the form of an
		/// ACCESS_DENIED_ACE structure.
		/// </param>
		/// <param name="dwAceRevision">
		/// <para>Specifies the revision level of the ACL being modified.</para>
		/// <para>This value can be ACL_REVISION or ACL_REVISION_DS. Use ACL_REVISION_DS if the ACL contains object-specific ACEs.</para>
		/// </param>
		/// <param name="AccessMask">Specifies the mask of access rights being denied to the specified SID.</param>
		/// <param name="pSid">A pointer to the SID structure representing the user, group, or logon account being denied access.</param>
		/// <returns>
		/// <para>If the function succeeds, the return value is nonzero.</para>
		/// <para>
		/// If the function fails, the return value is zero. To get extended error information, call GetLastError. The following are possible
		/// error values.
		/// </para>
		/// <list type="table">
		/// <listheader>
		/// <term>Return code</term>
		/// <term>Description</term>
		/// </listheader>
		/// <item>
		/// <term>ERROR_ALLOTTED_SPACE_EXCEEDED</term>
		/// <term>The new ACE does not fit into the ACL. A larger ACL buffer is required.</term>
		/// </item>
		/// <item>
		/// <term>ERROR_INVALID_ACL</term>
		/// <term>The specified ACL is not properly formed.</term>
		/// </item>
		/// <item>
		/// <term>ERROR_INVALID_SID</term>
		/// <term>The specified SID is not structurally valid.</term>
		/// </item>
		/// <item>
		/// <term>ERROR_REVISION_MISMATCH</term>
		/// <term>The specified revision is not known or is incompatible with that of the ACL.</term>
		/// </item>
		/// <item>
		/// <term>ERROR_SUCCESS</term>
		/// <term>The ACE was successfully added.</term>
		/// </item>
		/// </list>
		/// </returns>
		/// <remarks>
		/// <para>
		/// The AddAccessAllowedAce and <c>AddAccessDeniedAce</c> functions add a new ACE to the end of the list of ACEs for the ACL. These
		/// functions do not automatically place the new ACE in the proper canonical order. It is the caller's responsibility to ensure that
		/// the ACL is in canonical order by adding ACEs in the proper sequence.
		/// </para>
		/// <para>
		/// The ACE_HEADER structure placed in the ACE by the <c>AddAccessDeniedAce</c> function specifies a type and size, but provides no
		/// ACE flags.
		/// </para>
		/// <para>The ACE added by <c>AddAccessDeniedAce</c> is not inheritable.</para>
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows/desktop/api/securitybaseapi/nf-securitybaseapi-addaccessdeniedace
		// BOOL AddAccessDeniedAce( PACL pAcl, DWORD dwAceRevision, DWORD AccessMask, PSID pSid );
		[DllImport(Lib.AdvApi32, SetLastError = true, ExactSpelling = true)]
		[PInvokeData("securitybaseapi.h", MSDNShortId = "5b4c4164-48f4-4cd5-b60e-554f2498d547")]
		[return: MarshalAs(UnmanagedType.Bool)]
		public static extern bool AddAccessDeniedAce(PACL pAcl, uint dwAceRevision, uint AccessMask, PSID pSid);

		/// <summary>The <c>AddAce</c> function adds one or more access control entries (ACEs) to a specified access control list (ACL).</summary>
		/// <param name="pAcl">A pointer to an ACL. This function adds an ACE to this ACL.</param>
		/// <param name="dwAceRevision">
		/// <para>Specifies the revision level of the ACL being modified.</para>
		/// <para>
		/// This value can be ACL_REVISION or ACL_REVISION_DS. Use ACL_REVISION_DS if the ACL contains object-specific ACEs. This value must
		/// be compatible with the <c>AceType</c> field of all ACEs in pAceList. Otherwise, the function will fail and set the last error to ERROR_INVALID_PARAMETER.
		/// </para>
		/// </param>
		/// <param name="dwStartingAceIndex">
		/// Specifies the position in the ACL's list of ACEs at which to add new ACEs. A value of zero inserts the ACEs at the beginning of
		/// the list. A value of MAXDWORD appends the ACEs to the end of the list.
		/// </param>
		/// <param name="pAceList">
		/// A pointer to a list of one or more ACEs to be added to the specified ACL. The ACEs in the list must be stored contiguously.
		/// </param>
		/// <param name="nAceListLength">Specifies the size, in bytes, of the input buffer pointed to by the pAceList parameter.</param>
		/// <returns>
		/// <para>If the function succeeds, the return value is nonzero.</para>
		/// <para>
		/// If the function fails, the return value is zero. To get extended error information, call GetLastError. The following are possible
		/// error values.
		/// </para>
		/// <list type="table">
		/// <listheader>
		/// <term>Return code</term>
		/// <term>Description</term>
		/// </listheader>
		/// <item>
		/// <term>ERROR_INSUFFICIENT_BUFFER</term>
		/// <term>The new ACE does not fit into the ACL. A larger ACL buffer is required.</term>
		/// </item>
		/// <item>
		/// <term>ERROR_INVALID_PARAMETER</term>
		/// <term>The specified ACL is not properly formed.</term>
		/// </item>
		/// <item>
		/// <term>ERROR_SUCCESS</term>
		/// <term>The ACE was successfully added.</term>
		/// </item>
		/// </list>
		/// </returns>
		/// <remarks>
		/// <para>
		/// Applications frequently use the FindFirstFreeAce and GetAce functions when using the <c>AddAce</c> function to manipulate an ACL.
		/// In addition, the ACL_SIZE_INFORMATION structure retrieved by the GetAclInformation function contains the size of the ACL and the
		/// number of ACEs it contains.
		/// </para>
		/// <para>Examples</para>
		/// <para>For an example that uses this function, see Starting an Interactive Client Process.</para>
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows/desktop/api/securitybaseapi/nf-securitybaseapi-addace
		// BOOL AddAce( PACL pAcl, DWORD dwAceRevision, DWORD dwStartingAceIndex, LPVOID pAceList, DWORD nAceListLength );
		[DllImport(Lib.AdvApi32, SetLastError = true, ExactSpelling = true)]
		[PInvokeData("securitybaseapi.h", MSDNShortId = "f472d864-a273-49b5-b5e2-98772989971e")]
		[return: MarshalAs(UnmanagedType.Bool)]
		public static extern bool AddAce(PACL pAcl, uint dwAceRevision, uint dwStartingAceIndex, IntPtr pAceList, uint nAceListLength);

		/// <summary>
		/// <para>
		/// The <c>AddAuditAccessAce</c> function adds a system-audit access control entry (ACE) to a system access control list (ACL). The
		/// access of a specified security identifier (SID) is audited.
		/// </para>
		/// <para>To control whether the new ACE can be inherited by child objects, use the AddAuditAccessAceEx function.</para>
		/// </summary>
		/// <param name="pAcl">
		/// A pointer to an ACL. This function adds a system-audit ACE to this ACL. The ACE is in the form of a SYSTEM_AUDIT_ACE structure.
		/// </param>
		/// <param name="dwAceRevision">
		/// <para>Specifies the revision level of the ACL being modified.</para>
		/// <para>This value can be ACL_REVISION or ACL_REVISION_DS. Use ACL_REVISION_DS if the ACL contains object-specific ACEs.</para>
		/// </param>
		/// <param name="dwAccessMask">Specifies the mask of access rights to be audited for the specified SID.</param>
		/// <param name="pSid">A pointer to the SID representing the process whose access is being audited.</param>
		/// <param name="bAuditSuccess">
		/// Specifies whether successful access attempts are to be audited. Set this flag to <c>TRUE</c> to enable auditing; otherwise, set
		/// it to <c>FALSE</c>.
		/// </param>
		/// <param name="bAuditFailure">
		/// Specifies whether unsuccessful access attempts are to be audited. Set this flag to <c>TRUE</c> to enable auditing; otherwise, set
		/// it to <c>FALSE</c>.
		/// </param>
		/// <returns>
		/// <para>If the function succeeds, the return value is nonzero.</para>
		/// <para>
		/// If the function fails, the return value is zero. To get extended error information, call GetLastError. The following are possible
		/// error values.
		/// </para>
		/// <list type="table">
		/// <listheader>
		/// <term>Return code</term>
		/// <term>Description</term>
		/// </listheader>
		/// <item>
		/// <term>ERROR_ALLOTTED_SPACE_EXCEEDED</term>
		/// <term>The new ACE does not fit into the ACL. A larger ACL buffer is required.</term>
		/// </item>
		/// <item>
		/// <term>ERROR_INVALID_ACL</term>
		/// <term>The specified ACL is not properly formed.</term>
		/// </item>
		/// <item>
		/// <term>ERROR_INVALID_SID</term>
		/// <term>The specified SID is not structurally valid.</term>
		/// </item>
		/// <item>
		/// <term>ERROR_REVISION_MISMATCH</term>
		/// <term>The specified revision is not known or is incompatible with that of the ACL.</term>
		/// </item>
		/// <item>
		/// <term>ERROR_SUCCESS</term>
		/// <term>The ACE was successfully added.</term>
		/// </item>
		/// </list>
		/// </returns>
		/// <remarks>
		/// The ACE_HEADER structure placed in the ACE by the <c>AddAuditAccessAce</c> function specifies a type and size, but provides no
		/// ACE flags.
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows/desktop/api/securitybaseapi/nf-securitybaseapi-addauditaccessace
		// BOOL AddAuditAccessAce( PACL pAcl, DWORD dwAceRevision, DWORD dwAccessMask, PSID pSid, BOOL bAuditSuccess, BOOL bAuditFailure );
		[DllImport(Lib.AdvApi32, SetLastError = true, ExactSpelling = true)]
		[PInvokeData("securitybaseapi.h", MSDNShortId = "34f22aea-9cde-411e-b2d5-bfcd3bfe325d")]
		[return: MarshalAs(UnmanagedType.Bool)]
		public static extern bool AddAuditAccessAce(PACL pAcl, uint dwAceRevision, uint dwAccessMask, PSID pSid, [MarshalAs(UnmanagedType.Bool)] bool bAuditSuccess, [MarshalAs(UnmanagedType.Bool)] bool bAuditFailure);

		/// <summary>
		/// The AdjustTokenPrivileges function enables or disables privileges in the specified access token. Enabling or disabling privileges
		/// in an access token requires TOKEN_ADJUST_PRIVILEGES access.
		/// </summary>
		/// <param name="objectHandle">
		/// A handle to the access token that contains the privileges to be modified. The handle must have TOKEN_ADJUST_PRIVILEGES access to
		/// the token. If the PreviousState parameter is not NULL, the handle must also have TOKEN_QUERY access.
		/// </param>
		/// <param name="DisableAllPrivileges">
		/// Specifies whether the function disables all of the token's privileges. If this value is TRUE, the function disables all
		/// privileges and ignores the NewState parameter. If it is FALSE, the function modifies privileges based on the information pointed
		/// to by the NewState parameter.
		/// </param>
		/// <param name="NewState">
		/// A pointer to a TOKEN_PRIVILEGES structure that specifies an array of privileges and their attributes. If DisableAllPrivileges is
		/// TRUE, the function ignores this parameter. If the DisableAllPrivileges parameter is FALSE, the AdjustTokenPrivileges function
		/// enables, disables, or removes these privileges for the token. The following table describes the action taken by the
		/// AdjustTokenPrivileges function, based on the privilege attribute.
		/// </param>
		/// <param name="BufferLength">
		/// Specifies the size, in bytes, of the buffer pointed to by the PreviousState parameter. This parameter can be zero if the
		/// PreviousState parameter is NULL.
		/// </param>
		/// <param name="PreviousState">
		/// A pointer to a buffer that the function fills with a TOKEN_PRIVILEGES structure that contains the previous state of any
		/// privileges that the function modifies. That is, if a privilege has been modified by this function, the privilege and its previous
		/// state are contained in the TOKEN_PRIVILEGES structure referenced by PreviousState. If the PrivilegeCount member of
		/// TOKEN_PRIVILEGES is zero, then no privileges have been changed by this function. This parameter can be NULL.
		/// <para>
		/// If you specify a buffer that is too small to receive the complete list of modified privileges, the function fails and does not
		/// adjust any privileges. In this case, the function sets the variable pointed to by the ReturnLength parameter to the number of
		/// bytes required to hold the complete list of modified privileges.
		/// </para>
		/// </param>
		/// <param name="ReturnLength">
		/// A pointer to a variable that receives the required size, in bytes, of the buffer pointed to by the PreviousState parameter. This
		/// parameter can be NULL if PreviousState is NULL.
		/// </param>
		/// <returns>
		/// If the function succeeds, the return value is nonzero. To determine whether the function adjusted all of the specified
		/// privileges, call GetLastError, which returns either ERROR_SUCCESS, indicating that the function adjusted all specified
		/// privileges, or ERROR_NOT_ALL_ASSIGNED, indicating that the token does not have one or more of the privileges specified in the
		/// NewState parameter. The function may succeed with this error value even if no privileges were adjusted. The PreviousState
		/// parameter indicates the privileges that were adjusted.
		/// <para>If the function fails, the return value is zero. To get extended error information, call GetLastError.</para>
		/// </returns>
		[ReliabilityContract(Consistency.WillNotCorruptState, Cer.MayFail), DllImport(Lib.AdvApi32, ExactSpelling = true, SetLastError = true)]
		[return: MarshalAs(UnmanagedType.Bool)]
		[PInvokeData("securitybaseapi.h", MSDNShortId = "aa375202")]
		public static extern bool AdjustTokenPrivileges([In] HTOKEN objectHandle,
			[In, MarshalAs(UnmanagedType.Bool)] bool DisableAllPrivileges,
			[MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef = typeof(PTOKEN_PRIVILEGES.Marshaler))] PTOKEN_PRIVILEGES NewState,
			[In] uint BufferLength,
			[In, Out] SafeCoTaskMemHandle PreviousState,
			//[MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef = typeof(PTOKEN_PRIVILEGES.Marshaler), MarshalCookie = "Out")] PTOKEN_PRIVILEGES PreviousState,
			[In, Out] ref uint ReturnLength);

		/// <summary>
		/// The AdjustTokenPrivileges function enables or disables privileges in the specified access token. Enabling or disabling privileges
		/// in an access token requires TOKEN_ADJUST_PRIVILEGES access.
		/// </summary>
		/// <param name="objectHandle">
		/// A handle to the access token that contains the privileges to be modified. The handle must have TOKEN_ADJUST_PRIVILEGES access to
		/// the token. If the PreviousState parameter is not NULL, the handle must also have TOKEN_QUERY access.
		/// </param>
		/// <param name="DisableAllPrivileges">
		/// Specifies whether the function disables all of the token's privileges. If this value is TRUE, the function disables all
		/// privileges and ignores the NewState parameter. If it is FALSE, the function modifies privileges based on the information pointed
		/// to by the NewState parameter.
		/// </param>
		/// <param name="NewState">
		/// A pointer to a TOKEN_PRIVILEGES structure that specifies an array of privileges and their attributes. If DisableAllPrivileges is
		/// TRUE, the function ignores this parameter. If the DisableAllPrivileges parameter is FALSE, the AdjustTokenPrivileges function
		/// enables, disables, or removes these privileges for the token. The following table describes the action taken by the
		/// AdjustTokenPrivileges function, based on the privilege attribute.
		/// </param>
		/// <param name="BufferLength">
		/// Specifies the size, in bytes, of the buffer pointed to by the PreviousState parameter. This parameter can be zero if the
		/// PreviousState parameter is NULL.
		/// </param>
		/// <param name="PreviousState">
		/// A pointer to a buffer that the function fills with a TOKEN_PRIVILEGES structure that contains the previous state of any
		/// privileges that the function modifies. That is, if a privilege has been modified by this function, the privilege and its previous
		/// state are contained in the TOKEN_PRIVILEGES structure referenced by PreviousState. If the PrivilegeCount member of
		/// TOKEN_PRIVILEGES is zero, then no privileges have been changed by this function. This parameter can be NULL.
		/// <para>
		/// If you specify a buffer that is too small to receive the complete list of modified privileges, the function fails and does not
		/// adjust any privileges. In this case, the function sets the variable pointed to by the ReturnLength parameter to the number of
		/// bytes required to hold the complete list of modified privileges.
		/// </para>
		/// </param>
		/// <param name="ReturnLength">
		/// A pointer to a variable that receives the required size, in bytes, of the buffer pointed to by the PreviousState parameter. This
		/// parameter can be NULL if PreviousState is NULL.
		/// </param>
		/// <returns>
		/// If the function succeeds, the return value is nonzero. To determine whether the function adjusted all of the specified
		/// privileges, call GetLastError, which returns either ERROR_SUCCESS, indicating that the function adjusted all specified
		/// privileges, or ERROR_NOT_ALL_ASSIGNED, indicating that the token does not have one or more of the privileges specified in the
		/// NewState parameter. The function may succeed with this error value even if no privileges were adjusted. The PreviousState
		/// parameter indicates the privileges that were adjusted.
		/// <para>If the function fails, the return value is zero. To get extended error information, call GetLastError.</para>
		/// </returns>
		[ReliabilityContract(Consistency.WillNotCorruptState, Cer.MayFail), DllImport(Lib.AdvApi32, ExactSpelling = true, SetLastError = true)]
		[return: MarshalAs(UnmanagedType.Bool)]
		[PInvokeData("securitybaseapi.h", MSDNShortId = "aa375202")]
		public static extern bool AdjustTokenPrivileges([In] HTOKEN objectHandle,
			[In, MarshalAs(UnmanagedType.Bool)] bool DisableAllPrivileges, [In] SafeCoTaskMemHandle NewState,
			[In] uint BufferLength, [In, Out] SafeCoTaskMemHandle PreviousState, [In, Out] ref uint ReturnLength);

		/// <summary>The <c>AllocateLocallyUniqueId</c> function allocates a locally unique identifier (LUID).</summary>
		/// <param name="Luid">A pointer to a <c>LUID</c> structure that receives the allocated LUID.</param>
		/// <returns>
		/// <para>If the function succeeds, the return value is nonzero.</para>
		/// <para>If the function fails, the return value is zero. To get extended error information, call <c>GetLastError</c>.</para>
		/// </returns>
		// BOOL WINAPI AllocateLocallyUniqueId( _Out_ PLUID Luid); https://msdn.microsoft.com/en-us/library/windows/desktop/aa375260(v=vs.85).aspx
		[DllImport(Lib.AdvApi32, SetLastError = true, ExactSpelling = true)]
		[PInvokeData("securitybaseapi.h", MSDNShortId = "aa375260")]
		[return: MarshalAs(UnmanagedType.Bool)]
		public static extern bool AllocateLocallyUniqueId(out LUID Luid);

		/// <summary>The <c>DuplicateToken</c> function creates a new access token that duplicates one already in existence.</summary>
		/// <param name="ExistingTokenHandle">A handle to an access token opened with TOKEN_DUPLICATE access.</param>
		/// <param name="ImpersonationLevel">
		/// Specifies a <c>SECURITY_IMPERSONATION_LEVEL</c> enumerated type that supplies the impersonation level of the new token.
		/// </param>
		/// <param name="DuplicateTokenHandle">
		/// <para>
		/// A pointer to a variable that receives a handle to the duplicate token. This handle has TOKEN_IMPERSONATE and TOKEN_QUERY access
		/// to the new token.
		/// </para>
		/// <para>When you have finished using the new token, call the <c>CloseHandle</c> function to close the token handle.</para>
		/// </param>
		/// <returns>
		/// <para>If the function succeeds, the return value is nonzero.</para>
		/// <para>If the function fails, the return value is zero. To get extended error information, call <c>GetLastError</c>.</para>
		/// </returns>
		// BOOL WINAPI DuplicateToken( _In_ HANDLE ExistingTokenHandle, _In_ SECURITY_IMPERSONATION_LEVEL ImpersonationLevel, _Out_ PHANDLE
		// DuplicateTokenHandle); https://msdn.microsoft.com/en-us/library/windows/desktop/aa446616(v=vs.85).aspx
		[DllImport(Lib.AdvApi32, SetLastError = true, ExactSpelling = true)]
		[PInvokeData("securitybaseapi.h", MSDNShortId = "aa446616")]
		[return: MarshalAs(UnmanagedType.Bool)]
		public static extern bool DuplicateToken(HTOKEN ExistingTokenHandle,
			SECURITY_IMPERSONATION_LEVEL ImpersonationLevel, out SafeHTOKEN DuplicateTokenHandle);

		/// <summary>
		/// The <c>DuplicateTokenEx</c> function creates a new access token that duplicates an existing token. This function can create
		/// either a primary token or an impersonation token.
		/// </summary>
		/// <param name="hExistingToken">A handle to an access token opened with TOKEN_DUPLICATE access.</param>
		/// <param name="dwDesiredAccess">
		/// <para>
		/// Specifies the requested access rights for the new token. The <c>DuplicateTokenEx</c> function compares the requested access
		/// rights with the existing token's discretionary access control list (DACL) to determine which rights are granted or denied. To
		/// request the same access rights as the existing token, specify zero. To request all access rights that are valid for the caller,
		/// specify MAXIMUM_ALLOWED.
		/// </para>
		/// <para>For a list of access rights for access tokens, see Access Rights for Access-Token Objects.</para>
		/// </param>
		/// <param name="lpTokenAttributes">
		/// <para>
		/// A pointer to a <c>SECURITY_ATTRIBUTES</c> structure that specifies a security descriptor for the new token and determines whether
		/// child processes can inherit the token. If lpTokenAttributes is <c>NULL</c>, the token gets a default security descriptor and the
		/// handle cannot be inherited. If the security descriptor contains a system access control list (SACL), the token gets
		/// ACCESS_SYSTEM_SECURITY access right, even if it was not requested in dwDesiredAccess.
		/// </para>
		/// <para>
		/// To set the owner in the security descriptor for the new token, the caller's process token must have the <c>SE_RESTORE_NAME</c>
		/// privilege set.
		/// </para>
		/// </param>
		/// <param name="ImpersonationLevel">
		/// Specifies a value from the <c>SECURITY_IMPERSONATION_LEVEL</c> enumeration that indicates the impersonation level of the new token.
		/// </param>
		/// <param name="TokenType">
		/// <para>Specifies one of the following values from the <c>TOKEN_TYPE</c> enumeration.</para>
		/// <para>
		/// <list type="table">
		/// <listheader>
		/// <term>Value</term>
		/// <term>Meaning</term>
		/// </listheader>
		/// <item>
		/// <term>TokenPrimary</term>
		/// <term>The new token is a primary token that you can use in the CreateProcessAsUser function.</term>
		/// </item>
		/// <item>
		/// <term>TokenImpersonation</term>
		/// <term>The new token is an impersonation token.</term>
		/// </item>
		/// </list>
		/// </para>
		/// </param>
		/// <param name="phNewToken">
		/// <para>A pointer to a <c>HANDLE</c> variable that receives the new token.</para>
		/// <para>When you have finished using the new token, call the <c>CloseHandle</c> function to close the token handle.</para>
		/// </param>
		/// <returns>
		/// <para>If the function succeeds, the function returns a nonzero value.</para>
		/// <para>If the function fails, it returns zero. To get extended error information, call <c>GetLastError</c>.</para>
		/// </returns>
		// BOOL WINAPI DuplicateTokenEx( _In_ HANDLE hExistingToken, _In_ DWORD dwDesiredAccess, _In_opt_ LPSECURITY_ATTRIBUTES
		// lpTokenAttributes, _In_ SECURITY_IMPERSONATION_LEVEL ImpersonationLevel, _In_ TOKEN_TYPE TokenType, _Out_ PHANDLE phNewToken); https://msdn.microsoft.com/en-us/library/windows/desktop/aa446617(v=vs.85).aspx
		[ReliabilityContract(Consistency.WillNotCorruptState, Cer.MayFail)]
		[DllImport(Lib.AdvApi32, SetLastError = true, ExactSpelling = true)]
		[PInvokeData("securitybaseapi.h", MSDNShortId = "aa446617")]
		[return: MarshalAs(UnmanagedType.Bool)]
		public static extern bool DuplicateTokenEx(HTOKEN hExistingToken, TokenAccess dwDesiredAccess, SECURITY_ATTRIBUTES lpTokenAttributes,
			SECURITY_IMPERSONATION_LEVEL ImpersonationLevel, TOKEN_TYPE TokenType, out SafeHTOKEN phNewToken);

		/// <summary>The <c>GetAce</c> function obtains a pointer to an access control entry (ACE) in an access control list (ACL).</summary>
		/// <param name="pAcl">A pointer to an ACL that contains the ACE to be retrieved.</param>
		/// <param name="dwAceIndex">
		/// The index of the ACE to be retrieved. A value of zero corresponds to the first ACE in the ACL, a value of one to the second ACE,
		/// and so on.
		/// </param>
		/// <param name="pAce">A pointer to a pointer that the function sets to the address of the ACE.</param>
		/// <returns>
		/// <para>If the function succeeds, the function returns nonzero.</para>
		/// <para>If the function fails, it returns zero. To get extended error information, call GetLastError.</para>
		/// </returns>
		// https://docs.microsoft.com/en-us/windows/desktop/api/securitybaseapi/nf-securitybaseapi-getace
		// BOOL GetAce( PACL pAcl, DWORD dwAceIndex, LPVOID *pAce );
		[DllImport(Lib.AdvApi32, SetLastError = true, ExactSpelling = true)]
		[PInvokeData("securitybaseapi.h", MSDNShortId = "5b5d8751-20d7-40a2-bd70-cfbe956aaa03")]
		[return: MarshalAs(UnmanagedType.Bool)]
		public static extern bool GetAce(PACL pAcl, uint dwAceIndex, out PACE pAce);

		/// <summary>The GetAclInformation function retrieves information about an access control list (ACL).</summary>
		/// <param name="pAcl">
		/// A pointer to an ACL. The function retrieves information about this ACL. If a null value is passed, the function causes an access violation.
		/// </param>
		/// <param name="pAclInformation">
		/// A pointer to a buffer to receive the requested information. The structure that is placed into the buffer depends on the
		/// information class requested in the dwAclInformationClass parameter.
		/// </param>
		/// <param name="nAclInformationLength">The size, in bytes, of the buffer pointed to by the pAclInformation parameter.</param>
		/// <param name="dwAclInformationClass">
		/// A value of the ACL_INFORMATION_CLASS enumeration that indicates the class of information requested. This parameter can be one of
		/// two values from this enumeration:
		/// <list type="bullet">
		/// <listItem>
		/// <para>
		/// If the value is AclRevisionInformation, the function fills the buffer pointed to by the pAclInformation parameter with an
		/// ACL_REVISION_INFORMATION structure.
		/// </para>
		/// </listItem><listItem>
		/// <para>
		/// If the value is AclSizeInformation, the function fills the buffer pointed to by the pAclInformation parameter with an
		/// ACL_SIZE_INFORMATION structure.
		/// </para>
		/// </listItem>
		/// </list>
		/// </param>
		/// <returns>
		/// If the function succeeds, the function returns nonzero. If the function fails, it returns zero. To get extended error
		/// information, call GetLastError.
		/// </returns>
		[DllImport(Lib.AdvApi32, ExactSpelling = true, SetLastError = true)]
		[PInvokeData("securitybaseapi.h", MSDNShortId = "aa446635")]
		public static extern bool GetAclInformation(PACL pAcl, IntPtr pAclInformation, uint nAclInformationLength, ACL_INFORMATION_CLASS dwAclInformationClass);

		/// <summary>The GetAclInformation function retrieves information about an access control list (ACL).</summary>
		/// <param name="pAcl">
		/// A pointer to an ACL. The function retrieves information about this ACL. If a null value is passed, the function causes an access violation.
		/// </param>
		/// <param name="pAclInformation">
		/// A pointer to a buffer to receive the requested information. The structure that is placed into the buffer depends on the
		/// information class requested in the dwAclInformationClass parameter.
		/// </param>
		/// <param name="nAclInformationLength">The size, in bytes, of the buffer pointed to by the pAclInformation parameter.</param>
		/// <param name="dwAclInformationClass">
		/// A value of the ACL_INFORMATION_CLASS enumeration that indicates the class of information requested. This parameter can be one of
		/// two values from this enumeration:
		/// <list type="bullet">
		/// <listItem>
		/// <para>
		/// If the value is AclRevisionInformation, the function fills the buffer pointed to by the pAclInformation parameter with an
		/// ACL_REVISION_INFORMATION structure.
		/// </para>
		/// </listItem><listItem>
		/// <para>
		/// If the value is AclSizeInformation, the function fills the buffer pointed to by the pAclInformation parameter with an
		/// ACL_SIZE_INFORMATION structure.
		/// </para>
		/// </listItem>
		/// </list>
		/// </param>
		/// <returns>
		/// If the function succeeds, the function returns nonzero. If the function fails, it returns zero. To get extended error
		/// information, call GetLastError.
		/// </returns>
		[DllImport(Lib.AdvApi32, ExactSpelling = true, SetLastError = true)]
		[PInvokeData("securitybaseapi.h", MSDNShortId = "aa446635")]
		public static extern bool GetAclInformation(PACL pAcl, ref ACL_REVISION_INFORMATION pAclInformation, uint nAclInformationLength = 4, ACL_INFORMATION_CLASS dwAclInformationClass = ACL_INFORMATION_CLASS.AclRevisionInformation);

		/// <summary>The GetAclInformation function retrieves information about an access control list (ACL).</summary>
		/// <param name="pAcl">
		/// A pointer to an ACL. The function retrieves information about this ACL. If a null value is passed, the function causes an access violation.
		/// </param>
		/// <param name="pAclInformation">
		/// A pointer to a buffer to receive the requested information. The structure that is placed into the buffer depends on the
		/// information class requested in the dwAclInformationClass parameter.
		/// </param>
		/// <param name="nAclInformationLength">The size, in bytes, of the buffer pointed to by the pAclInformation parameter.</param>
		/// <param name="dwAclInformationClass">
		/// A value of the ACL_INFORMATION_CLASS enumeration that indicates the class of information requested. This parameter can be one of
		/// two values from this enumeration:
		/// <list type="bullet">
		/// <listItem>
		/// <para>
		/// If the value is AclRevisionInformation, the function fills the buffer pointed to by the pAclInformation parameter with an
		/// ACL_REVISION_INFORMATION structure.
		/// </para>
		/// </listItem><listItem>
		/// <para>
		/// If the value is AclSizeInformation, the function fills the buffer pointed to by the pAclInformation parameter with an
		/// ACL_SIZE_INFORMATION structure.
		/// </para>
		/// </listItem>
		/// </list>
		/// </param>
		/// <returns>
		/// If the function succeeds, the function returns nonzero. If the function fails, it returns zero. To get extended error
		/// information, call GetLastError.
		/// </returns>
		[DllImport(Lib.AdvApi32, ExactSpelling = true, SetLastError = true)]
		[PInvokeData("securitybaseapi.h", MSDNShortId = "aa446635")]
		public static extern bool GetAclInformation(PACL pAcl, ref ACL_SIZE_INFORMATION pAclInformation, uint nAclInformationLength = 12, ACL_INFORMATION_CLASS dwAclInformationClass = ACL_INFORMATION_CLASS.AclSizeInformation);

		/// <summary>The GetAclInformation function retrieves information about an access control list (ACL).</summary>
		/// <param name="pAcl">
		/// A pointer to an ACL. The function retrieves information about this ACL. If a null value is passed, the function causes an access violation.
		/// </param>
		/// <returns>
		/// The requested information. The structure that is returned depends on the information class requested in the dwAclInformationClass parameter.
		/// </returns>
		public static T GetAclInformation<T>(this PACL pAcl) where T : struct
		{
			if (!CorrespondingTypeAttribute.CanGet<T, ACL_INFORMATION_CLASS>(out var c)) throw new ArgumentException("Cannot retrieve value of type T.");
			using (var mem = new SafeCoTaskMemHandle(12))
			{
				if (!GetAclInformation(pAcl, (IntPtr)mem, (uint)Marshal.SizeOf(typeof(T)), c))
					throw new Win32Exception();
				return mem.ToStructure<T>();
			}
		}

		/// <summary>The GetPrivateObjectSecurity function retrieves information from a private object's security descriptor.</summary>
		/// <param name="ObjectDescriptor">A pointer to a SECURITY_DESCRIPTOR structure. This is the security descriptor to be queried.</param>
		/// <param name="SecurityInformation">
		/// A set of bit flags that indicate the parts of the security descriptor to retrieve. This parameter can be a combination of the
		/// SECURITY_INFORMATION bit flags.
		/// </param>
		/// <param name="ResultantDescriptor">
		/// A pointer to a buffer that receives a copy of the requested information from the specified security descriptor. The
		/// SECURITY_DESCRIPTOR structure is returned in self-relative format.
		/// </param>
		/// <param name="DescriptorLength">Specifies the size, in bytes, of the buffer pointed to by the ResultantDescriptor parameter.</param>
		/// <param name="ReturnLength">
		/// A pointer to a variable the function sets to zero if the descriptor is copied successfully. If the buffer is too small for the
		/// security descriptor, this variable receives the number of bytes required. If this variable's value is greater than the value of
		/// the DescriptorLength parameter when the function returns, the function returns FALSE and none of the security descriptor is
		/// copied to the buffer.
		/// </param>
		/// <returns>
		/// If the function succeeds, the return value is nonzero. If the function fails, the return value is zero. To get extended error
		/// information, call GetLastError.
		/// </returns>
		[DllImport(Lib.AdvApi32, ExactSpelling = true, SetLastError = true)]
		[return: MarshalAs(UnmanagedType.Bool)]
		[PInvokeData("securitybaseapi.h", MSDNShortId = "aa446646")]
		public static extern bool GetPrivateObjectSecurity(PSECURITY_DESCRIPTOR ObjectDescriptor, SECURITY_INFORMATION SecurityInformation,
			SafeSecurityDescriptor ResultantDescriptor, uint DescriptorLength, out uint ReturnLength);

		/// <summary>The GetPrivateObjectSecurity function retrieves information from a private object's security descriptor.</summary>
		/// <param name="ObjectDescriptor">A pointer to a SECURITY_DESCRIPTOR structure. This is the security descriptor to be queried.</param>
		/// <param name="SecurityInformation">
		/// A set of bit flags that indicate the parts of the security descriptor to retrieve. This parameter can be a combination of the
		/// SECURITY_INFORMATION bit flags.
		/// </param>
		/// <returns>
		/// The requested information from the specified security descriptor. The SECURITY_DESCRIPTOR structure is returned in self-relative format.
		/// </returns>
		public static SafeSecurityDescriptor GetPrivateObjectSecurity(this PSECURITY_DESCRIPTOR ObjectDescriptor, SECURITY_INFORMATION SecurityInformation)
		{
			var pResSD = SafeSecurityDescriptor.Null;
			AdvApi32.GetPrivateObjectSecurity(ObjectDescriptor, SecurityInformation, pResSD, 0, out var ret);
			if (ret > 0)
			{
				pResSD = new SafeSecurityDescriptor((int)ret);
				if (!pResSD.IsInvalid && !AdvApi32.GetPrivateObjectSecurity(ObjectDescriptor, SecurityInformation, pResSD, ret, out ret))
					Win32Error.GetLastError().ThrowIfFailed();
			}
			return pResSD;
		}

		/// <summary>The GetPrivateObjectSecurity function retrieves information from a private object's security descriptor.</summary>
		/// <param name="ObjectDescriptor">A pointer to a SECURITY_DESCRIPTOR structure. This is the security descriptor to be queried.</param>
		/// <param name="SecurityInformation">
		/// A set of bit flags that indicate the parts of the security descriptor to retrieve. This parameter can be a combination of the
		/// SECURITY_INFORMATION bit flags.
		/// </param>
		/// <returns>
		/// The requested information from the specified security descriptor. The SECURITY_DESCRIPTOR structure is returned in self-relative format.
		/// </returns>
		public static SafeSecurityDescriptor GetPrivateObjectSecurity(this SafeSecurityDescriptor ObjectDescriptor, SECURITY_INFORMATION SecurityInformation) =>
			GetPrivateObjectSecurity((PSECURITY_DESCRIPTOR)ObjectDescriptor, SecurityInformation);

		/// <summary>
		/// <para>The <c>GetSecurityDescriptorControl</c> function retrieves a security descriptor control and revision information.</para>
		/// </summary>
		/// <param name="pSecurityDescriptor">
		/// <para>A pointer to a SECURITY_DESCRIPTOR structure whose control and revision information the function retrieves.</para>
		/// </param>
		/// <param name="pControl">
		/// <para>A pointer to a SECURITY_DESCRIPTOR_CONTROL structure that receives the security descriptor's control information.</para>
		/// </param>
		/// <param name="lpdwRevision">
		/// <para>
		/// A pointer to a variable that receives the security descriptor's revision value. This value is always set, even when
		/// <c>GetSecurityDescriptorControl</c> returns an error.
		/// </para>
		/// </param>
		/// <returns>
		/// <para>If the function succeeds, the return value is nonzero.</para>
		/// <para>If the function fails, the return value is zero. To get extended error information, call GetLastError.</para>
		/// </returns>
		// https://docs.microsoft.com/en-us/windows/desktop/api/securitybaseapi/nf-securitybaseapi-getsecuritydescriptorcontrol BOOL
		// GetSecurityDescriptorControl( PSECURITY_DESCRIPTOR pSecurityDescriptor, PSECURITY_DESCRIPTOR_CONTROL pControl, LPDWORD
		// lpdwRevision );
		[DllImport(Lib.AdvApi32, SetLastError = true, ExactSpelling = true)]
		[PInvokeData("securitybaseapi.h", MSDNShortId = "d66682f2-8017-4245-9d93-5f8332a5b483")]
		[return: MarshalAs(UnmanagedType.Bool)]
		public static extern bool GetSecurityDescriptorControl(PSECURITY_DESCRIPTOR pSecurityDescriptor, out SECURITY_DESCRIPTOR_CONTROL pControl, out SDDL_REVISION lpdwRevision);

		/// <summary>
		/// The GetSecurityDescriptorDacl function retrieves a pointer to the discretionary access control list (DACL) in a specified
		/// security descriptor.
		/// </summary>
		/// <param name="pSecurityDescriptor">
		/// A pointer to the SECURITY_DESCRIPTOR structure that contains the DACL. The function retrieves a pointer to it.
		/// </param>
		/// <param name="lpbDaclPresent">
		/// A pointer to a value that indicates the presence of a DACL in the specified security descriptor. If lpbDaclPresent is TRUE, the
		/// security descriptor contains a DACL, and the remaining output parameters in this function receive valid values. If lpbDaclPresent
		/// is FALSE, the security descriptor does not contain a DACL, and the remaining output parameters do not receive valid values.
		/// <para>
		/// A value of TRUE for lpbDaclPresent does not mean that pDacl is not NULL. That is, lpbDaclPresent can be TRUE while pDacl is NULL,
		/// meaning that a NULL DACL is in effect. A NULL DACL implicitly allows all access to an object and is not the same as an empty
		/// DACL. An empty DACL permits no access to an object. For information about creating a proper DACL, see Creating a DACL.
		/// </para>
		/// </param>
		/// <param name="pDacl">
		/// A pointer to a pointer to an access control list (ACL). If a DACL exists, the function sets the pointer pointed to by pDacl to
		/// the address of the security descriptor's DACL. If a DACL does not exist, no value is stored.
		/// <para>
		/// If the function stores a NULL value in the pointer pointed to by pDacl, the security descriptor has a NULL DACL. A NULL DACL
		/// implicitly allows all access to an object.
		/// </para>
		/// <para>
		/// If an application expects a non-NULL DACL but encounters a NULL DACL, the application should fail securely and not allow access.
		/// </para>
		/// </param>
		/// <param name="lpbDaclDefaulted">
		/// A pointer to a flag set to the value of the SE_DACL_DEFAULTED flag in the SECURITY_DESCRIPTOR_CONTROL structure if a DACL exists
		/// for the security descriptor. If this flag is TRUE, the DACL was retrieved by a default mechanism; if FALSE, the DACL was
		/// explicitly specified by a user.
		/// </param>
		/// <returns>
		/// If the function succeeds, the return value is nonzero. If the function fails, the return value is zero. To get extended error
		/// information, call GetLastError.
		/// </returns>
		[DllImport(Lib.AdvApi32, ExactSpelling = true, SetLastError = true)]
		[return: MarshalAs(UnmanagedType.Bool)]
		[PInvokeData("securitybaseapi.h", MSDNShortId = "aa446648")]
		public static extern bool GetSecurityDescriptorDacl(PSECURITY_DESCRIPTOR pSecurityDescriptor, [MarshalAs(UnmanagedType.Bool)] out bool lpbDaclPresent,
			out PACL pDacl, [MarshalAs(UnmanagedType.Bool)] out bool lpbDaclDefaulted);

		/// <summary>
		/// <para>The <c>GetSecurityDescriptorGroup</c> function retrieves the primary group information from a security descriptor.</para>
		/// </summary>
		/// <param name="pSecurityDescriptor">
		/// <para>A pointer to a SECURITY_DESCRIPTOR structure whose primary group information the function retrieves.</para>
		/// </param>
		/// <param name="pGroup">
		/// <para>
		/// A pointer to a pointer to a security identifier (SID) that identifies the primary group when the function returns. If the
		/// security descriptor does not contain a primary group, the function sets the pointer pointed to by pGroup to <c>NULL</c> and
		/// ignores the remaining output parameter, lpbGroupDefaulted. If the security descriptor contains a primary group, the function sets
		/// the pointer pointed to by pGroup to the address of the security descriptor's group SID and provides a valid value for the
		/// variable pointed to by lpbGroupDefaulted.
		/// </para>
		/// </param>
		/// <param name="lpbGroupDefaulted">
		/// <para>
		/// A pointer to a flag that is set to the value of the SE_GROUP_DEFAULTED flag in the SECURITY_DESCRIPTOR_CONTROL structure when the
		/// function returns. If the value stored in the variable pointed to by the pGroup parameter is <c>NULL</c>, no value is set.
		/// </para>
		/// </param>
		/// <returns>
		/// <para>If the function succeeds, the function returns nonzero.</para>
		/// <para>If the function fails, it returns zero. To get extended error information, call GetLastError.</para>
		/// </returns>
		// https://docs.microsoft.com/en-us/windows/desktop/api/securitybaseapi/nf-securitybaseapi-getsecuritydescriptorgroup BOOL
		// GetSecurityDescriptorGroup( PSECURITY_DESCRIPTOR pSecurityDescriptor, PSID *pGroup, LPBOOL lpbGroupDefaulted );
		[DllImport(Lib.AdvApi32, SetLastError = true, ExactSpelling = true)]
		[PInvokeData("securitybaseapi.h", MSDNShortId = "a920b49e-a4c2-4e49-b529-88c12205d995")]
		[return: MarshalAs(UnmanagedType.Bool)]
		public static extern bool GetSecurityDescriptorGroup(PSECURITY_DESCRIPTOR pSecurityDescriptor, out PSID pGroup, [MarshalAs(UnmanagedType.Bool)] out bool lpbGroupDefaulted);

		/// <summary>
		/// The <c>GetSecurityDescriptorLength</c> function returns the length, in bytes, of a structurally valid security descriptor. The
		/// length includes the length of all associated structures.
		/// </summary>
		/// <param name="pSecurityDescriptor">
		/// <para>A pointer to the SECURITY_DESCRIPTOR structure whose length the function returns. The pointer is assumed to be valid.</para>
		/// </param>
		/// <returns>
		/// <para>If the function succeeds, the function returns the length, in bytes, of the SECURITY_DESCRIPTOR structure.</para>
		/// <para>If the SECURITY_DESCRIPTOR structure is not valid, the return value is undefined.</para>
		/// </returns>
		/// <remarks>
		/// <para>
		/// The minimum length of a security descriptor is SECURITY_DESCRIPTOR_MIN_LENGTH. A security descriptor of this length has no
		/// associated security identifiers (SIDs) or access control lists (ACLs).
		/// </para>
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows/desktop/api/securitybaseapi/nf-securitybaseapi-getsecuritydescriptorlength DWORD
		// GetSecurityDescriptorLength( PSECURITY_DESCRIPTOR pSecurityDescriptor );
		[DllImport(Lib.AdvApi32, SetLastError = false, ExactSpelling = true)]
		[PInvokeData("securitybaseapi.h", MSDNShortId = "eb331839-ff3e-4f4b-b93b-18da2ea72697")]
		public static extern uint GetSecurityDescriptorLength(PSECURITY_DESCRIPTOR pSecurityDescriptor);

		/// <summary>The GetSecurityDescriptorOwner function retrieves the owner information from a security descriptor.</summary>
		/// <param name="pSecurityDescriptor">A pointer to a SECURITY_DESCRIPTOR structure whose owner information the function retrieves.</param>
		/// <param name="pOwner">
		/// A pointer to a pointer to a security identifier (SID) that identifies the owner when the function returns. If the security
		/// descriptor does not contain an owner, the function sets the pointer pointed to by pOwner to NULL and ignores the remaining output
		/// parameter, lpbOwnerDefaulted. If the security descriptor contains an owner, the function sets the pointer pointed to by pOwner to
		/// the address of the security descriptor's owner SID and provides a valid value for the variable pointed to by lpbOwnerDefaulted.
		/// </param>
		/// <param name="lpbOwnerDefaulted">
		/// A pointer to a flag that is set to the value of the SE_OWNER_DEFAULTED flag in the SECURITY_DESCRIPTOR_CONTROL structure when the
		/// function returns. If the value stored in the variable pointed to by the pOwner parameter is NULL, no value is set.
		/// </param>
		/// <returns>
		/// If the function succeeds, the return value is nonzero. If the function fails, the return value is zero. To get extended error
		/// information, call GetLastError.
		/// </returns>
		[DllImport(Lib.AdvApi32, ExactSpelling = true, SetLastError = true)]
		[return: MarshalAs(UnmanagedType.Bool)]
		[PInvokeData("securitybaseapi.h", MSDNShortId = "aa446651")]
		public static extern bool GetSecurityDescriptorOwner(PSECURITY_DESCRIPTOR pSecurityDescriptor, out PSID pOwner, [MarshalAs(UnmanagedType.Bool)] out bool lpbOwnerDefaulted);

		/// <summary>
		/// <para>
		/// The <c>GetSecurityDescriptorSacl</c> function retrieves a pointer to the system access control list (SACL) in a specified
		/// security descriptor.
		/// </para>
		/// </summary>
		/// <param name="pSecurityDescriptor">
		/// <para>A pointer to the SECURITY_DESCRIPTOR structure that contains the SACL to which the function retrieves a pointer.</para>
		/// </param>
		/// <param name="lpbSaclPresent">
		/// <para>
		/// A pointer to a flag the function sets to indicate the presence of a SACL in the specified security descriptor. If this parameter
		/// is <c>TRUE</c>, the security descriptor contains a SACL, and the remaining output parameters in this function receive valid
		/// values. If this parameter is <c>FALSE</c>, the security descriptor does not contain a SACL, and the remaining output parameters
		/// do not receive valid values.
		/// </para>
		/// </param>
		/// <param name="pSacl">
		/// <para>
		/// A pointer to a pointer to an access control list (ACL). If a SACL exists, the function sets the pointer pointed to by pSacl to
		/// the address of the security descriptor's SACL. If a SACL does not exist, no value is stored.
		/// </para>
		/// <para>
		/// If the function stores a <c>NULL</c> value in the pointer pointed to by pSacl, the security descriptor has a <c>NULL</c> SACL.
		/// </para>
		/// </param>
		/// <param name="lpbSaclDefaulted">
		/// <para>
		/// A pointer to a flag that is set to the value of the SE_SACL_DEFAULTED flag in the SECURITY_DESCRIPTOR_CONTROL structure if a SACL
		/// exists for the security descriptor.
		/// </para>
		/// </param>
		/// <returns>
		/// <para>If the function succeeds, the function returns nonzero.</para>
		/// <para>If the function fails, it returns zero. To get extended error information, call GetLastError.</para>
		/// </returns>
		// https://docs.microsoft.com/en-us/windows/desktop/api/securitybaseapi/nf-securitybaseapi-getsecuritydescriptorsacl BOOL
		// GetSecurityDescriptorSacl( PSECURITY_DESCRIPTOR pSecurityDescriptor, LPBOOL lpbSaclPresent, PACL *pSacl, LPBOOL lpbSaclDefaulted );
		[DllImport(Lib.AdvApi32, SetLastError = true, ExactSpelling = true)]
		[PInvokeData("securitybaseapi.h", MSDNShortId = "6bf59735-aaa3-4751-8c98-00cc197df4e5")]
		[return: MarshalAs(UnmanagedType.Bool)]
		public static extern bool GetSecurityDescriptorSacl(PSECURITY_DESCRIPTOR pSecurityDescriptor, [MarshalAs(UnmanagedType.Bool)] out bool lpbSaclPresent, out PACL pSacl,
			[MarshalAs(UnmanagedType.Bool)] out bool lpbSaclDefaulted);

		/// <summary>
		/// The GetTokenInformation function retrieves a specified type of information about an access token. The calling process must have
		/// appropriate access rights to obtain the information.
		/// </summary>
		/// <param name="hObject">
		/// A handle to an access token from which information is retrieved. If TokenInformationClass specifies TokenSource, the handle must
		/// have TOKEN_QUERY_SOURCE access. For all other TokenInformationClass values, the handle must have TOKEN_QUERY access.
		/// </param>
		/// <param name="tokenInfoClass">
		/// Specifies a value from the TOKEN_INFORMATION_CLASS enumerated type to identify the type of information the function retrieves.
		/// Any callers who check the TokenIsAppContainer and have it return 0 should also verify that the caller token is not an identify
		/// level impersonation token. If the current token is not an application container but is an identity level token, you should return AccessDenied.
		/// </param>
		/// <param name="pTokenInfo">
		/// A pointer to a buffer the function fills with the requested information. The structure put into this buffer depends upon the type
		/// of information specified by the TokenInformationClass parameter.
		/// </param>
		/// <param name="tokenInfoLength">
		/// Specifies the size, in bytes, of the buffer pointed to by the TokenInformation parameter. If TokenInformation is NULL, this
		/// parameter must be zero.
		/// </param>
		/// <param name="returnLength">
		/// A pointer to a variable that receives the number of bytes needed for the buffer pointed to by the TokenInformation parameter. If
		/// this value is larger than the value specified in the TokenInformationLength parameter, the function fails and stores no data in
		/// the buffer.
		/// <para>
		/// If the value of the TokenInformationClass parameter is TokenDefaultDacl and the token has no default DACL, the function sets the
		/// variable pointed to by ReturnLength to sizeof(TOKEN_DEFAULT_DACL) and sets the DefaultDacl member of the TOKEN_DEFAULT_DACL
		/// structure to NULL.
		/// </para>
		/// </param>
		/// <returns>
		/// If the function succeeds, the return value is nonzero. If the function fails, the return value is zero. To get extended error
		/// information, call GetLastError.
		/// </returns>
		[DllImport(Lib.AdvApi32, SetLastError = true, ExactSpelling = true)]
		[return: MarshalAs(UnmanagedType.Bool)]
		[PInvokeData("securitybaseapi.h", MSDNShortId = "aa446671")]
		public static extern bool GetTokenInformation(HTOKEN hObject, TOKEN_INFORMATION_CLASS tokenInfoClass, SafeAllocatedMemoryHandle pTokenInfo, int tokenInfoLength, out int returnLength);

		/// <summary>
		/// <para>
		/// The <c>ImpersonateLoggedOnUser</c> function lets the calling thread impersonate the security context of a logged-on user. The
		/// user is represented by a token handle.
		/// </para>
		/// </summary>
		/// <param name="hToken">
		/// <para>
		/// A handle to a primary or impersonation access token that represents a logged-on user. This can be a token handle returned by a
		/// call to LogonUser, CreateRestrictedToken, DuplicateToken, DuplicateTokenEx, OpenProcessToken, or OpenThreadToken functions. If
		/// hToken is a handle to a primary token, the token must have <c>TOKEN_QUERY</c> and <c>TOKEN_DUPLICATE</c> access. If hToken is a
		/// handle to an impersonation token, the token must have <c>TOKEN_QUERY</c> and <c>TOKEN_IMPERSONATE</c> access.
		/// </para>
		/// </param>
		/// <returns>
		/// <para>If the function succeeds, the return value is nonzero.</para>
		/// <para>If the function fails, the return value is zero. To get extended error information, call GetLastError.</para>
		/// </returns>
		/// <remarks>
		/// <para>The impersonation lasts until the thread exits or until it calls RevertToSelf.</para>
		/// <para>The calling thread does not need to have any particular privileges to call <c>ImpersonateLoggedOnUser</c>.</para>
		/// <para>
		/// If the call to <c>ImpersonateLoggedOnUser</c> fails, the client connection is not impersonated and the client request is made in
		/// the security context of the process. If the process is running as a highly privileged account, such as LocalSystem, or as a
		/// member of an administrative group, the user may be able to perform actions they would otherwise be disallowed. Therefore, it is
		/// important to always check the return value of the call, and if it fails, raise an error; do not continue execution of the client request.
		/// </para>
		/// <para>
		/// All impersonate functions, including <c>ImpersonateLoggedOnUser</c> allow the requested impersonation if one of the following is true:
		/// </para>
		/// <list type="bullet">
		/// <item>
		/// <term>
		/// The requested impersonation level of the token is less than <c>SecurityImpersonation</c>, such as <c>SecurityIdentification</c>
		/// or <c>SecurityAnonymous</c>.
		/// </term>
		/// </item>
		/// <item>
		/// <term>The caller has the <c>SeImpersonatePrivilege</c> privilege.</term>
		/// </item>
		/// <item>
		/// <term>
		/// A process (or another process in the caller's logon session) created the token using explicit credentials through LogonUser or
		/// LsaLogonUser function.
		/// </term>
		/// </item>
		/// <item>
		/// <term>The authenticated identity is same as the caller.</term>
		/// </item>
		/// </list>
		/// <para><c>Windows XP with SP1 and earlier:</c> The <c>SeImpersonatePrivilege</c> privilege is not supported.</para>
		/// <para>For more information about impersonation, see Client Impersonation.</para>
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows/desktop/api/securitybaseapi/nf-securitybaseapi-impersonateloggedonuser BOOL
		// ImpersonateLoggedOnUser( HANDLE hToken );
		[DllImport(Lib.AdvApi32, SetLastError = true, ExactSpelling = true)]
		[PInvokeData("securitybaseapi.h", MSDNShortId = "cf5c31ae-6749-45c2-888f-697060cc8c75")]
		[return: MarshalAs(UnmanagedType.Bool)]
		public static extern bool ImpersonateLoggedOnUser(HTOKEN hToken);

		/// <summary>
		/// <para>The <c>IsValidSecurityDescriptor</c> function determines whether the components of a security descriptor are valid.</para>
		/// </summary>
		/// <param name="pSecurityDescriptor">
		/// <para>A pointer to a SECURITY_DESCRIPTOR structure that the function validates.</para>
		/// </param>
		/// <returns>
		/// <para>If the components of the security descriptor are valid, the return value is nonzero.</para>
		/// <para>
		/// If any of the components of the security descriptor are not valid, the return value is zero. There is no extended error
		/// information for this function; do not call GetLastError.
		/// </para>
		/// </returns>
		/// <remarks>
		/// <para>
		/// The <c>IsValidSecurityDescriptor</c> function checks the validity of the components that are present in the security descriptor.
		/// It does not verify whether certain components are present nor does it verify the contents of the individual ACE or ACL.
		/// </para>
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows/desktop/api/securitybaseapi/nf-securitybaseapi-isvalidsecuritydescriptor BOOL
		// IsValidSecurityDescriptor( PSECURITY_DESCRIPTOR pSecurityDescriptor );
		[DllImport(Lib.AdvApi32, SetLastError = true, ExactSpelling = true)]
		[PInvokeData("securitybaseapi.h", MSDNShortId = "24a98229-11e4-45ef-988b-c2cf831275e7")]
		[return: MarshalAs(UnmanagedType.Bool)]
		public static extern bool IsValidSecurityDescriptor(PSECURITY_DESCRIPTOR pSecurityDescriptor);

		/// <summary>
		/// The MapGenericMask function maps the generic access rights in an access mask to specific and standard access rights. The function
		/// applies a mapping supplied in a <see cref="GENERIC_MAPPING"/> structure.
		/// </summary>
		/// <param name="AccessMask">A pointer to an access mask.</param>
		/// <param name="GenericMapping">
		/// A pointer to a <see cref="GENERIC_MAPPING"/> structure specifying a mapping of generic access types to specific and standard
		/// access types.
		/// </param>
		[DllImport(Lib.AdvApi32, ExactSpelling = true)]
		[PInvokeData("securitybaseapi.h", MSDNShortId = "aa379266")]
		public static extern void MapGenericMask(ref uint AccessMask, in GENERIC_MAPPING GenericMapping);

		/// <summary>
		/// The PrivilegeCheck function determines whether a specified set of privileges are enabled in an access token. The PrivilegeCheck
		/// function is typically called by a server application to check the privileges of a client's access token.
		/// </summary>
		/// <param name="ClientToken">
		/// A handle to an access token representing a client process. This handle must have been obtained by opening the token of a thread
		/// impersonating the client. The token must be open for TOKEN_QUERY access.
		/// </param>
		/// <param name="RequiredPrivileges">
		/// A pointer to a PRIVILEGE_SET structure. The Privilege member of this structure is an array of LUID_AND_ATTRIBUTES structures.
		/// Before calling PrivilegeCheck, use the Privilege array to indicate the set of privileges to check. Set the Control member to
		/// PRIVILEGE_SET_ALL_NECESSARY if all of the privileges must be enabled; or set it to zero if it is sufficient that any one of the
		/// privileges be enabled.
		/// <para>
		/// When PrivilegeCheck returns, the Attributes member of each LUID_AND_ATTRIBUTES structure is set to SE_PRIVILEGE_USED_FOR_ACCESS
		/// if the corresponding privilege is enabled.
		/// </para>
		/// </param>
		/// <param name="pfResult">
		/// A pointer to a value the function sets to indicate whether any or all of the specified privileges are enabled in the access
		/// token. If the Control member of the PRIVILEGE_SET structure specifies PRIVILEGE_SET_ALL_NECESSARY, this value is TRUE only if all
		/// the privileges are enabled; otherwise, this value is TRUE if any of the privileges are enabled.
		/// </param>
		/// <returns>
		/// If the function succeeds, the function returns nonzero. If the function fails, it returns zero. To get extended error
		/// information, call GetLastError.
		/// </returns>
		[PInvokeData("securitybaseapi.h", MSDNShortId = "aa379304")]
		[DllImport(Lib.AdvApi32, SetLastError = true, ExactSpelling = true)]
		[return: MarshalAs(UnmanagedType.Bool)]
		public static extern bool PrivilegeCheck(HTOKEN ClientToken,
			[MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef = typeof(PRIVILEGE_SET.Marshaler))] PRIVILEGE_SET RequiredPrivileges,
			[MarshalAs(UnmanagedType.Bool)] out bool pfResult);

		/// <summary>The RevertToSelf function terminates the impersonation of a client application.</summary>
		/// <returns>
		/// If the function succeeds, the function returns nonzero. If the function fails, it returns zero. To get extended error
		/// information, call GetLastError.
		/// </returns>
		[DllImport(Lib.AdvApi32, ExactSpelling = true, SetLastError = true)]
		[return: MarshalAs(UnmanagedType.Bool)]
		[PInvokeData("securitybaseapi.h", MSDNShortId = "aa379317")]
		public static extern bool RevertToSelf();

		/// <summary>Provides a <see cref="SafeHandle"/> to a that releases a created HTOKEN instance at disposal using CloseHandle.</summary>
		public class SafeHTOKEN : SafeKernelHandle
		{
			/// <summary>
			/// Retrieves a pseudo-handle that you can use as a shorthand way to refer to the access token associated with a process.
			/// </summary>
			/// <remarks>
			/// A pseudo-handle is a special constant that can function as the access token for the current process. The calling process can
			/// use a pseudo-handle to specify the access token for that process whenever a token handle is required. Child processes do not
			/// inherit pseudo-handles.
			/// <para>Starting in Windows 8, this pseudo-handle has only TOKEN_QUERY and TOKEN_QUERY_SOURCE access rights.</para>
			/// <para>
			/// A process can create a standard handle that is valid in the context of other processes and can be inherited by other
			/// processes. To create this standard handle, call the DuplicateHandle function and specify the pseudo-handle as the source handle.
			/// </para>
			/// <para>
			/// You do not need to close the pseudo-handle when you no longer need it. If you call the CloseHandle function with a
			/// pseudo-handle, the function has no effect. If you call DuplicateHandle to duplicate the pseudo-handle, however, you must
			/// close the duplicate handle.
			/// </para>
			/// </remarks>
			public static readonly SafeHTOKEN CurrentProcessToken = new SafeHTOKEN((IntPtr)4, false);

			/// <summary>
			/// Retrieves a pseudo-handle that you can use as a shorthand way to refer to the token that is currently in effect for the
			/// thread, which is the thread token if one exists and the process token otherwise.
			/// </summary>
			/// <remarks>
			/// A pseudo-handle is a special constant that can function as the access token for the current thread. The calling thread can
			/// use a pseudo-handle to specify the access token for that thread whenever a token handle is required. Child threads do not
			/// inherit pseudo-handles.
			/// <para>Starting in Windows 8, this pseudo-handle has only TOKEN_QUERY and TOKEN_QUERY_SOURCE access rights.</para>
			/// <para>
			/// A thread can create a standard handle that is valid in the context of other threads and can be inherited by other threads. To
			/// create this standard handle, call the DuplicateHandle function and specify the pseudo-handle as the source handle.
			/// </para>
			/// <para>
			/// You do not need to close the pseudo-handle when you no longer need it. If you call the CloseHandle function with a
			/// pseudo-handle, the function has no effect. If you call DuplicateHandle to duplicate the pseudo-handle, however, you must
			/// close the duplicate handle.
			/// </para>
			/// </remarks>
			public static readonly SafeHTOKEN CurrentThreadEffectiveToken = new SafeHTOKEN((IntPtr)6, false);

			/// <summary>
			/// Retrieves a pseudo-handle that you can use as a shorthand way to refer to the impersonation token that was assigned to the
			/// current thread.
			/// </summary>
			/// <remarks>
			/// A pseudo-handle is a special constant that can function as the impersonation token for the current thread. The calling thread
			/// can use a pseudo-handle to specify the impersonation token for that thread whenever a token handle is required. Child threads
			/// do not inherit pseudo-handles.
			/// <para>Starting in Windows 8, this pseudo-handle has only TOKEN_QUERY and TOKEN_QUERY_SOURCE access rights.</para>
			/// <para>
			/// A thread can create a standard handle that is valid in the context of other threads and can be inherited by other threads. To
			/// create this standard handle, call the DuplicateHandle function and specify the pseudo-handle as the source handle.
			/// </para>
			/// <para>
			/// You do not need to close the pseudo-handle when you no longer need it. If you call the CloseHandle function with a
			/// pseudo-handle, the function has no effect. If you call DuplicateHandle to duplicate the pseudo-handle, however, you must
			/// close the duplicate handle.
			/// </para>
			/// </remarks>
			public static readonly SafeHTOKEN CurrentThreadToken = new SafeHTOKEN((IntPtr)5, false);

			/// <summary>Initializes a new instance of the <see cref="HTOKEN"/> class and assigns an existing handle.</summary>
			/// <param name="preexistingHandle">An <see cref="IntPtr"/> object that represents the pre-existing handle to use.</param>
			/// <param name="ownsHandle">
			/// <see langword="true"/> to reliably release the handle during the finalization phase; otherwise, <see langword="false"/> (not recommended).
			/// </param>
			public SafeHTOKEN(IntPtr preexistingHandle, bool ownsHandle = true) : base(preexistingHandle, ownsHandle) { }

			private SafeHTOKEN() : base()
			{
			}

			/// <summary>Gets a value indicating whether this token is elevated.</summary>
			/// <value><c>true</c> if this instance is elevated; otherwise, <c>false</c>.</value>
			public bool IsElevated => GetInfo<TOKEN_ELEVATION>(TOKEN_INFORMATION_CLASS.TokenElevation).TokenIsElevated;

			/// <summary>Get the token handle instance from a process handle.</summary>
			/// <param name="hProcess">The process handle.</param>
			/// <param name="desiredAccess">The desired access. TOKEN_DUPLICATE must usually be included.</param>
			/// <returns>Resulting token handle.</returns>
			public static SafeHTOKEN FromProcess(HPROCESS hProcess, TokenAccess desiredAccess = TokenAccess.TOKEN_DUPLICATE) =>
				!OpenProcessToken(hProcess, desiredAccess, out var val) ? throw new Win32Exception() : val;

			/// <summary>Get the token handle instance from a process instance.</summary>
			/// <param name="process">The process instance. If this value is <see langword="null"/>, the current process will be used.</param>
			/// <param name="desiredAccess">The desired access. TOKEN_DUPLICATE must usually be included.</param>
			/// <returns>Resulting token handle.</returns>
			public static SafeHTOKEN FromProcess(System.Diagnostics.Process process, TokenAccess desiredAccess = TokenAccess.TOKEN_DUPLICATE) =>
				FromProcess((process ?? System.Diagnostics.Process.GetCurrentProcess()).Handle, desiredAccess);

			/// <summary>Get the token handle instance from a process handle.</summary>
			/// <param name="hThread">The thread handle.</param>
			/// <param name="desiredAccess">The desired access. TOKEN_DUPLICATE must usually be included.</param>
			/// <param name="openAsSelf">if set to <c>true</c> open as self.</param>
			/// <returns>Resulting token handle.</returns>
			public static SafeHTOKEN FromThread(HTHREAD hThread, TokenAccess desiredAccess = TokenAccess.TOKEN_DUPLICATE, bool openAsSelf = true)
			{
				if (!OpenThreadToken(hThread, desiredAccess, openAsSelf, out var val))
				{
					if (Marshal.GetLastWin32Error() == Win32Error.ERROR_NO_TOKEN)
					{
						var pval = FromProcess(System.Diagnostics.Process.GetCurrentProcess());
						if (!DuplicateTokenEx(pval, TokenAccess.TOKEN_IMPERSONATE | desiredAccess, null, SECURITY_IMPERSONATION_LEVEL.SecurityImpersonation, TOKEN_TYPE.TokenImpersonation, out val))
							Win32Error.ThrowLastError();
						if (!SetThreadToken(IntPtr.Zero, val))
							Win32Error.ThrowLastError();
					}
					else
						Win32Error.ThrowLastError();
				}
				return val;
			}

			/// <summary>Performs an implicit conversion from <see cref="SafeHTOKEN"/> to <see cref="HTOKEN"/>.</summary>
			/// <param name="h">The safe handle instance.</param>
			/// <returns>The result of the conversion.</returns>
			public static implicit operator HTOKEN(SafeHTOKEN h) => h.handle;

			/// <summary>The <c>Duplicate</c> function creates a new access token that duplicates the current one.</summary>
			/// <param name="level">
			/// Specifies a <c>SECURITY_IMPERSONATION_LEVEL</c> enumerated type that supplies the impersonation level of the new token.
			/// </param>
			/// <returns>A new token.</returns>
			public SafeHTOKEN Duplicate(SECURITY_IMPERSONATION_LEVEL level)
			{
				if (!DuplicateToken(this, level, out var dup)) Win32Error.ThrowLastError();
				return dup;
			}

			/// <summary>
			/// The <c>DuplicateImpersonate</c> function creates a new impersonated access token that duplicates an existing token.
			/// </summary>
			/// <param name="impersonationLevel">
			/// Specifies a value from the <c>SECURITY_IMPERSONATION_LEVEL</c> enumeration that indicates the impersonation level of the new token.
			/// </param>
			/// <param name="desiredAccess">
			/// <para>
			/// Specifies the requested access rights for the new token. The <c>DuplicateTokenEx</c> function compares the requested access
			/// rights with the existing token's discretionary access control list (DACL) to determine which rights are granted or denied. To
			/// request the same access rights as the existing token, specify zero. To request all access rights that are valid for the
			/// caller, specify MAXIMUM_ALLOWED.
			/// </para>
			/// <para>For a list of access rights for access tokens, see Access Rights for Access-Token Objects.</para>
			/// </param>
			/// <param name="tokenAttributes">
			/// <para>
			/// A pointer to a <c>SECURITY_ATTRIBUTES</c> structure that specifies a security descriptor for the new token and determines
			/// whether child processes can inherit the token. If lpTokenAttributes is <c>NULL</c>, the token gets a default security
			/// descriptor and the handle cannot be inherited. If the security descriptor contains a system access control list (SACL), the
			/// token gets ACCESS_SYSTEM_SECURITY access right, even if it was not requested in dwDesiredAccess.
			/// </para>
			/// <para>
			/// To set the owner in the security descriptor for the new token, the caller's process token must have the
			/// <c>SE_RESTORE_NAME</c> privilege set.
			/// </para>
			/// </param>
			/// <returns>A pointer to a <c>SafeHTOKEN</c> variable that receives the new token.</returns>
			public SafeHTOKEN DuplicateImpersonate(SECURITY_IMPERSONATION_LEVEL impersonationLevel = SECURITY_IMPERSONATION_LEVEL.SecurityImpersonation, TokenAccess desiredAccess = TokenAccess.TOKEN_QUERY | TokenAccess.TOKEN_DUPLICATE | TokenAccess.TOKEN_ASSIGN_PRIMARY | TokenAccess.TOKEN_ADJUST_DEFAULT | TokenAccess.TOKEN_ADJUST_SESSIONID | TokenAccess.TOKEN_IMPERSONATE, SECURITY_ATTRIBUTES tokenAttributes = null)
			{
				if (!DuplicateTokenEx(this, desiredAccess, tokenAttributes, impersonationLevel, TOKEN_TYPE.TokenImpersonation, out var dup)) Win32Error.ThrowLastError();
				return dup;
			}

			/// <summary>The <c>DuplicatePrimary</c> function creates a new primary access token that duplicates an existing token.</summary>
			/// <param name="desiredAccess">
			/// <para>
			/// Specifies the requested access rights for the new token. The <c>DuplicateTokenEx</c> function compares the requested access
			/// rights with the existing token's discretionary access control list (DACL) to determine which rights are granted or denied. To
			/// request the same access rights as the existing token, specify zero. To request all access rights that are valid for the
			/// caller, specify MAXIMUM_ALLOWED.
			/// </para>
			/// <para>For a list of access rights for access tokens, see Access Rights for Access-Token Objects.</para>
			/// </param>
			/// <param name="impersonationLevel">
			/// Specifies a value from the <c>SECURITY_IMPERSONATION_LEVEL</c> enumeration that indicates the impersonation level of the new token.
			/// </param>
			/// <param name="tokenAttributes">
			/// <para>
			/// A pointer to a <c>SECURITY_ATTRIBUTES</c> structure that specifies a security descriptor for the new token and determines
			/// whether child processes can inherit the token. If lpTokenAttributes is <c>NULL</c>, the token gets a default security
			/// descriptor and the handle cannot be inherited. If the security descriptor contains a system access control list (SACL), the
			/// token gets ACCESS_SYSTEM_SECURITY access right, even if it was not requested in dwDesiredAccess.
			/// </para>
			/// <para>
			/// To set the owner in the security descriptor for the new token, the caller's process token must have the
			/// <c>SE_RESTORE_NAME</c> privilege set.
			/// </para>
			/// </param>
			/// <returns>A pointer to a <c>SafeHTOKEN</c> variable that receives the new token.</returns>
			public SafeHTOKEN DuplicatePrimary(TokenAccess desiredAccess = TokenAccess.TOKEN_ASSIGN_PRIMARY | TokenAccess.TOKEN_ALL_ACCESS, SECURITY_IMPERSONATION_LEVEL impersonationLevel = SECURITY_IMPERSONATION_LEVEL.SecurityIdentification, SECURITY_ATTRIBUTES tokenAttributes = null)
			{
				if (!DuplicateTokenEx(this, desiredAccess, tokenAttributes, impersonationLevel, TOKEN_TYPE.TokenPrimary, out var dup)) Win32Error.ThrowLastError();
				return dup;
			}

			/// <summary>
			/// Retrieves a specified type of information about an access token cast to supplied <typeparamref name="T"/> type. The calling
			/// process must have appropriate access rights to obtain the information. <note type="note">The caller is responsible for
			/// ensuring that the type requested by <typeparamref name="T"/> matches the type information requested by <paramref name="tokenInfoClass"/>.</note>
			/// </summary>
			/// <param name="tokenInfoClass">
			/// Specifies a value from the TOKEN_INFORMATION_CLASS enumerated type to identify the type of information the function
			/// retrieves. Any callers who check the TokenIsAppContainer and have it return 0 should also verify that the caller token is not
			/// an identify level impersonation token. If the current token is not an application container but is an identity level token,
			/// you should return AccessDenied.
			/// </param>
			public T GetInfo<T>(TOKEN_INFORMATION_CLASS tokenInfoClass)
			{
				if (CorrespondingTypeAttribute.GetCorrespondingTypes(tokenInfoClass).FirstOrDefault() != typeof(T))
					throw new InvalidCastException();
				using (var pType = GetInfo(tokenInfoClass))
				{
					// Marshal from native to .NET.
					switch (tokenInfoClass)
					{
						// DWORD
						case TOKEN_INFORMATION_CLASS.TokenSessionId:
						case TOKEN_INFORMATION_CLASS.TokenAppContainerNumber:
						// BOOL
						case TOKEN_INFORMATION_CLASS.TokenSandBoxInert:
						case TOKEN_INFORMATION_CLASS.TokenHasRestrictions:
						case TOKEN_INFORMATION_CLASS.TokenVirtualizationAllowed:
						case TOKEN_INFORMATION_CLASS.TokenVirtualizationEnabled:
						case TOKEN_INFORMATION_CLASS.TokenIsAppContainer:
							return (T)Convert.ChangeType(Marshal.ReadInt32((IntPtr)pType), typeof(T));

						// Enum
						case TOKEN_INFORMATION_CLASS.TokenType:
						case TOKEN_INFORMATION_CLASS.TokenImpersonationLevel:
						case TOKEN_INFORMATION_CLASS.TokenOrigin:
						case TOKEN_INFORMATION_CLASS.TokenElevationType:
						case TOKEN_INFORMATION_CLASS.TokenUIAccess:
							var i = Marshal.ReadInt32((IntPtr)pType);
							if (typeof(T).IsEnum)
								return (T)Enum.ToObject(typeof(T), i);
							return (T)Convert.ChangeType(i, typeof(T));

						case TOKEN_INFORMATION_CLASS.TokenLinkedToken:
							if (typeof(T) == typeof(IntPtr))
								return (T)Convert.ChangeType(Marshal.ReadIntPtr((IntPtr)pType), typeof(T));
							return default;

						// Struct
						case TOKEN_INFORMATION_CLASS.TokenUser:
						case TOKEN_INFORMATION_CLASS.TokenGroups:
						case TOKEN_INFORMATION_CLASS.TokenOwner:
						case TOKEN_INFORMATION_CLASS.TokenPrimaryGroup:
						case TOKEN_INFORMATION_CLASS.TokenDefaultDacl:
						case TOKEN_INFORMATION_CLASS.TokenSource:
						case TOKEN_INFORMATION_CLASS.TokenStatistics:
						case TOKEN_INFORMATION_CLASS.TokenRestrictedSids:
						case TOKEN_INFORMATION_CLASS.TokenGroupsAndPrivileges:
						case TOKEN_INFORMATION_CLASS.TokenElevation:
						case TOKEN_INFORMATION_CLASS.TokenAccessInformation:
						case TOKEN_INFORMATION_CLASS.TokenIntegrityLevel:
						case TOKEN_INFORMATION_CLASS.TokenMandatoryPolicy:
						case TOKEN_INFORMATION_CLASS.TokenLogonSid:
						case TOKEN_INFORMATION_CLASS.TokenCapabilities:
						case TOKEN_INFORMATION_CLASS.TokenAppContainerSid:
						case TOKEN_INFORMATION_CLASS.TokenUserClaimAttributes:
						case TOKEN_INFORMATION_CLASS.TokenDeviceClaimAttributes:
						case TOKEN_INFORMATION_CLASS.TokenDeviceGroups:
						case TOKEN_INFORMATION_CLASS.TokenRestrictedDeviceGroups:
							return pType.ToStructure<T>();

						case TOKEN_INFORMATION_CLASS.TokenPrivileges:
							return (T)Convert.ChangeType(PTOKEN_PRIVILEGES.FromPtr((IntPtr)pType), typeof(T));

						default:
							return default;
					}
				}
			}

			/// <summary>
			/// Retrieves a specified type of information about an access token. The calling process must have appropriate access rights to
			/// obtain the information.
			/// </summary>
			/// <param name="tokenInfoClass">
			/// Specifies a value from the TOKEN_INFORMATION_CLASS enumerated type to identify the type of information the function
			/// retrieves. Any callers who check the TokenIsAppContainer and have it return 0 should also verify that the caller token is not
			/// an identify level impersonation token. If the current token is not an application container but is an identity level token,
			/// you should return AccessDenied.
			/// </param>
			/// <returns>The block of memory containing the requested information.</returns>
			public SafeCoTaskMemHandle GetInfo(TOKEN_INFORMATION_CLASS tokenInfoClass)
			{
				// Get information size
				if (!GetTokenInformation(this, tokenInfoClass, SafeCoTaskMemHandle.Null, 0, out int cbSize))
				{
					var e = Win32Error.GetLastError();
					if (e.Failed && e != Win32Error.ERROR_INSUFFICIENT_BUFFER && e != Win32Error.ERROR_BAD_LENGTH)
						e.ThrowIfFailed();
				}

				// Retrieve token information.
				var pType = new SafeCoTaskMemHandle(cbSize);
				if (!GetTokenInformation(this, tokenInfoClass, pType, cbSize, out cbSize))
					Win32Error.ThrowLastError();

				return pType;
			}
		}

		/*
		AddAccessAllowedAceEx function
		AddAccessAllowedObjectAce function
		AddAccessDeniedAceEx function
		AddAccessDeniedObjectAce function
		AddAuditAccessAceEx function
		AddAuditAccessObjectAce function
		AddMandatoryAce function
		AddResourceAttributeAce function
		AddScopedPolicyIDAce function
		AdjustTokenGroups function
		AreAllAccessesGranted function
		AreAnyAccessesGranted function
		CheckTokenCapability function
		CheckTokenMembership function
		CheckTokenMembershipEx function
		ConvertToAutoInheritPrivateObjectSecurity function
		CreatePrivateObjectSecurity function
		CreatePrivateObjectSecurityEx function
		CreatePrivateObjectSecurityWithMultipleInheritance function
		CreateRestrictedToken function
		CreateWellKnownSid function
		CveEventWrite function
		DeleteAce function
		DeriveCapabilitySidsFromName function
		DestroyPrivateObjectSecurity function
		EqualDomainSid function
		EqualPrefixSid function
		FindFirstFreeAce function
		GetKernelObjectSecurity function
		GetSecurityDescriptorRMControl function
		GetSidSubAuthorityCount function
		GetWindowsAccountDomainSid function
		ImpersonateAnonymousToken function
		ImpersonateSelf function
		InitializeAcl function
		InitializeSecurityDescriptor function
		InitializeSid function
		IsTokenRestricted function
		IsValidAcl function
		IsValidSecurityDescriptor function
		IsValidSid function
		IsWellKnownSid function
		MakeAbsoluteSD function
		MakeSelfRelativeSD function
		QuerySecurityAccessMask function
		SetAclInformation function
		SetKernelObjectSecurity function
		SetPrivateObjectSecurity function
		SetPrivateObjectSecurityEx function
		SetSecurityAccessMask function
		SetSecurityDescriptorControl function
		SetSecurityDescriptorDacl function
		SetSecurityDescriptorGroup function
		SetSecurityDescriptorOwner function
		SetSecurityDescriptorRMControl function
		SetSecurityDescriptorSacl function
		SetTokenInformation function
		*/
	}
}