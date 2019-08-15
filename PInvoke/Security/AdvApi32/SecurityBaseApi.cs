using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.ConstrainedExecution;
using System.Runtime.InteropServices;
using System.Security.AccessControl;
using Vanara.Extensions;
using Vanara.InteropServices;
using static Vanara.PInvoke.Kernel32;

namespace Vanara.PInvoke
{
	public static partial class AdvApi32
	{
		private static readonly Dictionary<Type, int> StructSizes = new Dictionary<Type, int>();

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
		public static extern bool AccessCheck(PSECURITY_DESCRIPTOR pSecurityDescriptor, HTOKEN ClientToken, ACCESS_MASK DesiredAccess, in GENERIC_MAPPING GenericMapping,
			[In, Out, MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef = typeof(PRIVILEGE_SET.Marshaler))] PRIVILEGE_SET PrivilegeSet, ref uint PrivilegeSetLength,
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
		public static extern bool AccessCheckByType(PSECURITY_DESCRIPTOR pSecurityDescriptor, [Optional] PSID PrincipalSelfSid, HTOKEN ClientToken, ACCESS_MASK DesiredAccess,
			[In, Optional] OBJECT_TYPE_LIST[] ObjectTypeList, [Optional] uint ObjectTypeListLength, in GENERIC_MAPPING GenericMapping,
			[In, Out, MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef = typeof(PRIVILEGE_SET.Marshaler))] PRIVILEGE_SET PrivilegeSet,
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
		public static extern bool AccessCheckByTypeResultList(PSECURITY_DESCRIPTOR pSecurityDescriptor, PSID PrincipalSelfSid, HTOKEN ClientToken, ACCESS_MASK DesiredAccess,
			[In] OBJECT_TYPE_LIST[] ObjectTypeList, uint ObjectTypeListLength, in GENERIC_MAPPING GenericMapping,
			[In, Out, MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef = typeof(PRIVILEGE_SET.Marshaler))] PRIVILEGE_SET PrivilegeSet,
			ref uint PrivilegeSetLength, [In, Out, MarshalAs(UnmanagedType.LPArray, SizeParamIndex = 5)] uint[] GrantedAccessList,
			[In, Out, MarshalAs(UnmanagedType.LPArray, SizeParamIndex = 5)] uint[] AccessStatusList);

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
		// https://docs.microsoft.com/en-us/windows/desktop/api/securitybaseapi/nf-securitybaseapi-addaccessallowedace BOOL
		// AddAccessAllowedAce( PACL pAcl, DWORD dwAceRevision, DWORD AccessMask, PSID pSid );
		[DllImport(Lib.AdvApi32, SetLastError = true, ExactSpelling = true)]
		[PInvokeData("securitybaseapi.h", MSDNShortId = "1004353a-f907-4452-9c0f-85eba0ece813")]
		[return: MarshalAs(UnmanagedType.Bool)]
		public static extern bool AddAccessAllowedAce(PACL pAcl, uint dwAceRevision, ACCESS_MASK AccessMask, PSID pSid);

		/// <summary>
		/// The <c>AddAccessAllowedAceEx</c> function adds an access-allowed access control entry (ACE) to the end of a discretionary access
		/// control list (DACL).
		/// </summary>
		/// <param name="pAcl">
		/// A pointer to a DACL. The <c>AddAccessAllowedAceEx</c> function adds an access-allowed ACE to the end of this DACL. The ACE is in
		/// the form of an ACCESS_ALLOWED_ACE structure.
		/// </param>
		/// <param name="dwAceRevision">
		/// Specifies the revision level of the DACL being modified. This value can be ACL_REVISION or ACL_REVISION_DS. Use ACL_REVISION_DS
		/// if the DACL contains object-specific ACEs.
		/// </param>
		/// <param name="AceFlags">
		/// <para>
		/// A set of bit flags that control ACE inheritance. The function sets these flags in the <c>AceFlags</c> member of the ACE_HEADER
		/// structure of the new ACE. This parameter can be a combination of the following values.
		/// </para>
		/// <list type="table">
		/// <listheader>
		/// <term>Value</term>
		/// <term>Meaning</term>
		/// </listheader>
		/// <item>
		/// <term>CONTAINER_INHERIT_ACE</term>
		/// <term>The ACE is inherited by container objects.</term>
		/// </item>
		/// <item>
		/// <term>INHERIT_ONLY_ACE</term>
		/// <term>
		/// The ACE does not apply to the object to which the access control list (ACL) is assigned, but it can be inherited by child objects.
		/// </term>
		/// </item>
		/// <item>
		/// <term>INHERITED_ACE</term>
		/// <term>
		/// Indicates an inherited ACE. This flag allows operations that change the security on a tree of objects to modify inherited ACEs
		/// while not changing ACEs that were directly applied to the object.
		/// </term>
		/// </item>
		/// <item>
		/// <term>NO_PROPAGATE_INHERIT_ACE</term>
		/// <term>The OBJECT_INHERIT_ACE and CONTAINER_INHERIT_ACE bits are not propagated to an inherited ACE.</term>
		/// </item>
		/// <item>
		/// <term>OBJECT_INHERIT_ACE</term>
		/// <term>The ACE is inherited by non-container objects.</term>
		/// </item>
		/// </list>
		/// </param>
		/// <param name="AccessMask">
		/// A set of bit flags that use the ACCESS_MASK format. These flags specify the access rights that the new ACE allows for the
		/// specified security identifier (SID).
		/// </param>
		/// <param name="pSid">A pointer to a SID that identifies the user, group, or logon session to which the new ACE allows access.</param>
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
		/// <term>ERROR_INVALID_FLAGS</term>
		/// <term>The AceFlags parameter is not valid.</term>
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
		/// The caller must ensure that ACEs are added to the DACL in the correct order. For more information, see Order of ACEs in a DACL.
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows/desktop/api/securitybaseapi/nf-securitybaseapi-addaccessallowedaceex BOOL
		// AddAccessAllowedAceEx( PACL pAcl, DWORD dwAceRevision, DWORD AceFlags, DWORD AccessMask, PSID pSid );
		[DllImport(Lib.AdvApi32, SetLastError = true, ExactSpelling = true)]
		[PInvokeData("securitybaseapi.h", MSDNShortId = "6ddec01f-237f-4b6a-8ea8-a126017b30c5")]
		[return: MarshalAs(UnmanagedType.Bool)]
		public static extern bool AddAccessAllowedAceEx(PACL pAcl, uint dwAceRevision, AceFlags AceFlags, ACCESS_MASK AccessMask, PSID pSid);

		/// <summary>
		/// The <c>AddAccessAllowedObjectAce</c> function adds an access-allowed access control entry (ACE) to the end of a discretionary
		/// access control list (DACL). The new ACE can grant access to an object, or to a property set or property on an object. You can
		/// also use <c>AddAccessAllowedObjectAce</c> to add an ACE that only a specified type of child object can inherit.
		/// </summary>
		/// <param name="pAcl">
		/// A pointer to a DACL. The <c>AddAccessAllowedObjectAce</c> function adds an access-allowed ACE to the end of this DACL. The ACE is
		/// in the form of an ACCESS_ALLOWED_OBJECT_ACE structure.
		/// </param>
		/// <param name="dwAceRevision">
		/// Specifies the revision level of the DACL being modified. This value must be ACL_REVISION_DS. If the DACL's revision level is
		/// lower than ACL_REVISION_DS, the function changes it to ACL_REVISION_DS.
		/// </param>
		/// <param name="AceFlags">
		/// <para>
		/// A set of bit flags that control ACE inheritance. The function sets these flags in the <c>AceFlags</c> member of the ACE_HEADER
		/// structure of the new ACE. This parameter can be a combination of the following values.
		/// </para>
		/// <list type="table">
		/// <listheader>
		/// <term>Value</term>
		/// <term>Meaning</term>
		/// </listheader>
		/// <item>
		/// <term>CONTAINER_INHERIT_ACE</term>
		/// <term>The ACE is inherited by container objects.</term>
		/// </item>
		/// <item>
		/// <term>INHERIT_ONLY_ACE</term>
		/// <term>
		/// The ACE does not apply to the object to which the access control list (ACL) is assigned, but it can be inherited by child objects.
		/// </term>
		/// </item>
		/// <item>
		/// <term>INHERITED_ACE</term>
		/// <term>
		/// Indicates an inherited ACE. This flag allows operations that change the security on a tree of objects to modify inherited ACEs,
		/// while not changing ACEs that were directly applied to the object.
		/// </term>
		/// </item>
		/// <item>
		/// <term>NO_PROPAGATE_INHERIT_ACE</term>
		/// <term>The OBJECT_INHERIT_ACE and CONTAINER_INHERIT_ACE bits are not propagated to an inherited ACE.</term>
		/// </item>
		/// <item>
		/// <term>OBJECT_INHERIT_ACE</term>
		/// <term>The ACE is inherited by non-container objects.</term>
		/// </item>
		/// </list>
		/// </param>
		/// <param name="AccessMask">
		/// A set of bit flags that use the ACCESS_MASK format. These flags specify the access rights that the new ACE allows for the
		/// specified security identifier (SID).
		/// </param>
		/// <param name="ObjectTypeGuid">
		/// A pointer to a GUID structure that identifies the type of object, property set, or property protected by the new ACE. If this
		/// parameter is <c>NULL</c>, the new ACE protects the object to which the DACL is assigned.
		/// </param>
		/// <param name="InheritedObjectTypeGuid">
		/// A pointer to a GUID structure that identifies the type of object that can inherit the new ACE. If this parameter is non-
		/// <c>NULL</c>, only the specified object type can inherit the ACE. If <c>NULL</c>, any type of child object can inherit the ACE. In
		/// either case, inheritance is also controlled by the value of the AceFlags parameter, as well as by any protection against
		/// inheritance placed on the child objects.
		/// </param>
		/// <param name="pSid">A pointer to a SID that identifies the user, group, or logon session to which the new ACE allows access.</param>
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
		/// <term>ERROR_INVALID_FLAGS</term>
		/// <term>The AceFlags parameter is not valid.</term>
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
		/// If both ObjectTypeGuid and InheritedObjectTypeGuid are <c>NULL</c>, use the AddAccessAllowedAceEx function rather than
		/// <c>AddAccessAllowedObjectAce</c>. This is suggested because an ACCESS_ALLOWED_ACE is smaller and more efficient than an ACCESS_ALLOWED_OBJECT_ACE.
		/// </para>
		/// <para>
		/// The caller must ensure that ACEs are added to the DACL in the correct order. For more information, see Order of ACEs in a DACL.
		/// </para>
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows/desktop/api/securitybaseapi/nf-securitybaseapi-addaccessallowedobjectace BOOL
		// AddAccessAllowedObjectAce( PACL pAcl, DWORD dwAceRevision, DWORD AceFlags, DWORD AccessMask, GUID *ObjectTypeGuid, GUID
		// *InheritedObjectTypeGuid, PSID pSid );
		[DllImport(Lib.AdvApi32, SetLastError = true, ExactSpelling = true)]
		[PInvokeData("securitybaseapi.h", MSDNShortId = "ccf83e95-ba6f-49f5-a312-52eac90f209a")]
		[return: MarshalAs(UnmanagedType.Bool)]
		public static extern bool AddAccessAllowedObjectAce(PACL pAcl, uint dwAceRevision, AceFlags AceFlags, ACCESS_MASK AccessMask, in Guid ObjectTypeGuid, in Guid InheritedObjectTypeGuid, PSID pSid);

		/// <summary>
		/// The <c>AddAccessAllowedObjectAce</c> function adds an access-allowed access control entry (ACE) to the end of a discretionary
		/// access control list (DACL). The new ACE can grant access to an object, or to a property set or property on an object. You can
		/// also use <c>AddAccessAllowedObjectAce</c> to add an ACE that only a specified type of child object can inherit.
		/// </summary>
		/// <param name="pAcl">
		/// A pointer to a DACL. The <c>AddAccessAllowedObjectAce</c> function adds an access-allowed ACE to the end of this DACL. The ACE is
		/// in the form of an ACCESS_ALLOWED_OBJECT_ACE structure.
		/// </param>
		/// <param name="dwAceRevision">
		/// Specifies the revision level of the DACL being modified. This value must be ACL_REVISION_DS. If the DACL's revision level is
		/// lower than ACL_REVISION_DS, the function changes it to ACL_REVISION_DS.
		/// </param>
		/// <param name="AceFlags">
		/// <para>
		/// A set of bit flags that control ACE inheritance. The function sets these flags in the <c>AceFlags</c> member of the ACE_HEADER
		/// structure of the new ACE. This parameter can be a combination of the following values.
		/// </para>
		/// <list type="table">
		/// <listheader>
		/// <term>Value</term>
		/// <term>Meaning</term>
		/// </listheader>
		/// <item>
		/// <term>CONTAINER_INHERIT_ACE</term>
		/// <term>The ACE is inherited by container objects.</term>
		/// </item>
		/// <item>
		/// <term>INHERIT_ONLY_ACE</term>
		/// <term>
		/// The ACE does not apply to the object to which the access control list (ACL) is assigned, but it can be inherited by child objects.
		/// </term>
		/// </item>
		/// <item>
		/// <term>INHERITED_ACE</term>
		/// <term>
		/// Indicates an inherited ACE. This flag allows operations that change the security on a tree of objects to modify inherited ACEs,
		/// while not changing ACEs that were directly applied to the object.
		/// </term>
		/// </item>
		/// <item>
		/// <term>NO_PROPAGATE_INHERIT_ACE</term>
		/// <term>The OBJECT_INHERIT_ACE and CONTAINER_INHERIT_ACE bits are not propagated to an inherited ACE.</term>
		/// </item>
		/// <item>
		/// <term>OBJECT_INHERIT_ACE</term>
		/// <term>The ACE is inherited by non-container objects.</term>
		/// </item>
		/// </list>
		/// </param>
		/// <param name="AccessMask">
		/// A set of bit flags that use the ACCESS_MASK format. These flags specify the access rights that the new ACE allows for the
		/// specified security identifier (SID).
		/// </param>
		/// <param name="ObjectTypeGuid">
		/// A pointer to a GUID structure that identifies the type of object, property set, or property protected by the new ACE. If this
		/// parameter is <c>NULL</c>, the new ACE protects the object to which the DACL is assigned.
		/// </param>
		/// <param name="InheritedObjectTypeGuid">
		/// A pointer to a GUID structure that identifies the type of object that can inherit the new ACE. If this parameter is non-
		/// <c>NULL</c>, only the specified object type can inherit the ACE. If <c>NULL</c>, any type of child object can inherit the ACE. In
		/// either case, inheritance is also controlled by the value of the AceFlags parameter, as well as by any protection against
		/// inheritance placed on the child objects.
		/// </param>
		/// <param name="pSid">A pointer to a SID that identifies the user, group, or logon session to which the new ACE allows access.</param>
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
		/// <term>ERROR_INVALID_FLAGS</term>
		/// <term>The AceFlags parameter is not valid.</term>
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
		/// If both ObjectTypeGuid and InheritedObjectTypeGuid are <c>NULL</c>, use the AddAccessAllowedAceEx function rather than
		/// <c>AddAccessAllowedObjectAce</c>. This is suggested because an ACCESS_ALLOWED_ACE is smaller and more efficient than an ACCESS_ALLOWED_OBJECT_ACE.
		/// </para>
		/// <para>
		/// The caller must ensure that ACEs are added to the DACL in the correct order. For more information, see Order of ACEs in a DACL.
		/// </para>
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows/desktop/api/securitybaseapi/nf-securitybaseapi-addaccessallowedobjectace BOOL
		// AddAccessAllowedObjectAce( PACL pAcl, DWORD dwAceRevision, DWORD AceFlags, DWORD AccessMask, GUID *ObjectTypeGuid, GUID
		// *InheritedObjectTypeGuid, PSID pSid );
		[DllImport(Lib.AdvApi32, SetLastError = true, ExactSpelling = true)]
		[PInvokeData("securitybaseapi.h", MSDNShortId = "ccf83e95-ba6f-49f5-a312-52eac90f209a")]
		[return: MarshalAs(UnmanagedType.Bool)]
		public static extern bool AddAccessAllowedObjectAce(PACL pAcl, uint dwAceRevision, AceFlags AceFlags, ACCESS_MASK AccessMask, [Optional] IntPtr ObjectTypeGuid, [Optional] IntPtr InheritedObjectTypeGuid, PSID pSid);

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
		// https://docs.microsoft.com/en-us/windows/desktop/api/securitybaseapi/nf-securitybaseapi-addaccessdeniedace BOOL
		// AddAccessDeniedAce( PACL pAcl, DWORD dwAceRevision, DWORD AccessMask, PSID pSid );
		[DllImport(Lib.AdvApi32, SetLastError = true, ExactSpelling = true)]
		[PInvokeData("securitybaseapi.h", MSDNShortId = "5b4c4164-48f4-4cd5-b60e-554f2498d547")]
		[return: MarshalAs(UnmanagedType.Bool)]
		public static extern bool AddAccessDeniedAce(PACL pAcl, uint dwAceRevision, ACCESS_MASK AccessMask, PSID pSid);

		/// <summary>
		/// The <c>AddAccessDeniedAceEx</c> function adds an access-denied access control entry (ACE) to the end of a discretionary access
		/// control list (DACL).
		/// </summary>
		/// <param name="pAcl">
		/// A pointer to a DACL. The <c>AddAccessDeniedAceEx</c> function adds an access-denied ACE to the end of this DACL. The ACE is in
		/// the form of an ACCESS_DENIED_ACE structure.
		/// </param>
		/// <param name="dwAceRevision">
		/// Specifies the revision level of the DACL being modified. This value can be ACL_REVISION or ACL_REVISION_DS. Use ACL_REVISION_DS
		/// if the DACL contains object-specific ACEs.
		/// </param>
		/// <param name="AceFlags">
		/// <para>
		/// A set of bit flags that control ACE inheritance. The function sets these flags in the <c>AceFlags</c> member of the ACE_HEADER
		/// structure of the new ACE. This parameter can be a combination of the following values.
		/// </para>
		/// <list type="table">
		/// <listheader>
		/// <term>Value</term>
		/// <term>Meaning</term>
		/// </listheader>
		/// <item>
		/// <term>CONTAINER_INHERIT_ACE</term>
		/// <term>The ACE is inherited by container objects.</term>
		/// </item>
		/// <item>
		/// <term>INHERIT_ONLY_ACE</term>
		/// <term>
		/// The ACE does not apply to the object to which the access control list (ACL) is assigned, but it can be inherited by child objects.
		/// </term>
		/// </item>
		/// <item>
		/// <term>INHERITED_ACE</term>
		/// <term>
		/// Indicates an inherited ACE. This flag allows operations that change the security on a tree of objects to modify inherited ACEs,
		/// while not changing ACEs that were directly applied to the object.
		/// </term>
		/// </item>
		/// <item>
		/// <term>NO_PROPAGATE_INHERIT_ACE</term>
		/// <term>The OBJECT_INHERIT_ACE and CONTAINER_INHERIT_ACE bits are not propagated to an inherited ACE.</term>
		/// </item>
		/// <item>
		/// <term>OBJECT_INHERIT_ACE</term>
		/// <term>The ACE is inherited by non-container objects.</term>
		/// </item>
		/// </list>
		/// </param>
		/// <param name="AccessMask">
		/// A set of bit flags that use the ACCESS_MASK format to specify the access rights that the new ACE denies to the specified security
		/// identifier (SID).
		/// </param>
		/// <param name="pSid">A pointer to a SID that identifies the user, group, or logon session to which the new ACE denies access.</param>
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
		/// <term>ERROR_INVALID_FLAGS</term>
		/// <term>The AceFlags parameter is not valid.</term>
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
		/// Although the <c>AddAccessDeniedAceEx</c> function adds the new ACE to the end of the DACL, access-denied ACEs should appear at
		/// the beginning of a DACL. The caller must ensure that ACEs are added to the DACL in the correct order. For more information, see
		/// Order of ACEs in a DACL.
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows/desktop/api/securitybaseapi/nf-securitybaseapi-addaccessdeniedaceex BOOL
		// AddAccessDeniedAceEx( PACL pAcl, DWORD dwAceRevision, DWORD AceFlags, DWORD AccessMask, PSID pSid );
		[DllImport(Lib.AdvApi32, SetLastError = true, ExactSpelling = true)]
		[PInvokeData("securitybaseapi.h", MSDNShortId = "e353c88c-f82e-40c0-b676-38f0060acc81")]
		[return: MarshalAs(UnmanagedType.Bool)]
		public static extern bool AddAccessDeniedAceEx(PACL pAcl, uint dwAceRevision, AceFlags AceFlags, ACCESS_MASK AccessMask, PSID pSid);

		/// <summary>
		/// The <c>AddAccessDeniedObjectAce</c> function adds an access-denied access control entry (ACE) to the end of a discretionary
		/// access control list (DACL). The new ACE can deny access to an object, or to a property set or property on an object. You can also
		/// use <c>AddAccessDeniedObjectAce</c> to add an ACE that only a specified type of child object can inherit.
		/// </summary>
		/// <param name="pAcl">
		/// A pointer to a DACL. The <c>AddAccessDeniedObjectAce</c> function adds an access-denied ACE to the end of this DACL. The ACE is
		/// in the form of an ACCESS_DENIED_OBJECT_ACE structure.
		/// </param>
		/// <param name="dwAceRevision">
		/// Specifies the revision level of the DACL being modified. This value must be ACL_REVISION_DS. If the DACL's revision level is
		/// lower than ACL_REVISION_DS, the function changes it to ACL_REVISION_DS.
		/// </param>
		/// <param name="AceFlags">
		/// <para>
		/// A set of bit flags that control ACE inheritance. The function sets these flags in the <c>AceFlags</c> member of the ACE_HEADER
		/// structure of the new ACE. This parameter can be a combination of the following values.
		/// </para>
		/// <list type="table">
		/// <listheader>
		/// <term>Value</term>
		/// <term>Meaning</term>
		/// </listheader>
		/// <item>
		/// <term>CONTAINER_INHERIT_ACE</term>
		/// <term>The ACE is inherited by container objects.</term>
		/// </item>
		/// <item>
		/// <term>INHERIT_ONLY_ACE</term>
		/// <term>
		/// The ACE does not apply to the object to which the access control list (ACL) is assigned, but it can be inherited by child objects.
		/// </term>
		/// </item>
		/// <item>
		/// <term>INHERITED_ACE</term>
		/// <term>
		/// Indicates an inherited ACE. This flag allows operations that change the security on a tree of objects to modify inherited ACEs,
		/// while not changing ACEs that were directly applied to the object.
		/// </term>
		/// </item>
		/// <item>
		/// <term>NO_PROPAGATE_INHERIT_ACE</term>
		/// <term>The OBJECT_INHERIT_ACE and CONTAINER_INHERIT_ACE bits are not propagated to an inherited ACE.</term>
		/// </item>
		/// <item>
		/// <term>OBJECT_INHERIT_ACE</term>
		/// <term>The ACE is inherited by non-container objects.</term>
		/// </item>
		/// </list>
		/// </param>
		/// <param name="AccessMask">
		/// A set of bit flags that use the ACCESS_MASK format to specify the access rights that the new ACE denies to the specified security
		/// identifier (SID).
		/// </param>
		/// <param name="ObjectTypeGuid">
		/// A pointer to a GUID structure that identifies the type of object, property set, or property protected by the new ACE. If this
		/// parameter is <c>NULL</c>, the new ACE protects the object to which the ACL is assigned.
		/// </param>
		/// <param name="InheritedObjectTypeGuid">
		/// A pointer to a GUID structure that identifies the type of object that can inherit the new ACE. If this parameter is non-
		/// <c>NULL</c>, only the specified object type can inherit the ACE. If <c>NULL</c>, any type of child object can inherit the ACE. In
		/// either case, inheritance is also controlled by the value of the AceFlags parameter, as well as by any protection against
		/// inheritance placed on the child objects.
		/// </param>
		/// <param name="pSid">A pointer to a SID that identifies the user, group, or logon session to which the new ACE allows access.</param>
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
		/// <term>ERROR_INVALID_FLAGS</term>
		/// <term>The AceFlags parameter is not valid.</term>
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
		/// If both ObjectTypeGuid and InheritedObjectTypeGuid are <c>NULL</c>, use the AddAccessDeniedAceEx function rather than
		/// <c>AddAccessDeniedObjectAce</c>. This is suggested because an ACCESS_DENIED_ACE is smaller and more efficient than an ACCESS_DENIED_OBJECT_ACE.
		/// </para>
		/// <para>
		/// Although the <c>AddAccessDeniedObjectAce</c> function adds the new ACE to the end of the ACL, access-denied ACEs should appear at
		/// the beginning of an ACL. The caller must ensure that ACEs are added to the DACL in the correct order. For more information, see
		/// Order of ACEs in a DACL.
		/// </para>
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows/desktop/api/securitybaseapi/nf-securitybaseapi-addaccessdeniedobjectace BOOL
		// AddAccessDeniedObjectAce( PACL pAcl, DWORD dwAceRevision, DWORD AceFlags, DWORD AccessMask, GUID *ObjectTypeGuid, GUID
		// *InheritedObjectTypeGuid, PSID pSid );
		[DllImport(Lib.AdvApi32, SetLastError = true, ExactSpelling = true)]
		[PInvokeData("securitybaseapi.h", MSDNShortId = "1427c908-92b6-46b2-9189-a2fd93c470b1")]
		[return: MarshalAs(UnmanagedType.Bool)]
		public static extern bool AddAccessDeniedObjectAce(PACL pAcl, uint dwAceRevision, AceFlags AceFlags, ACCESS_MASK AccessMask, in Guid ObjectTypeGuid, in Guid InheritedObjectTypeGuid, PSID pSid);

		/// <summary>
		/// The <c>AddAccessDeniedObjectAce</c> function adds an access-denied access control entry (ACE) to the end of a discretionary
		/// access control list (DACL). The new ACE can deny access to an object, or to a property set or property on an object. You can also
		/// use <c>AddAccessDeniedObjectAce</c> to add an ACE that only a specified type of child object can inherit.
		/// </summary>
		/// <param name="pAcl">
		/// A pointer to a DACL. The <c>AddAccessDeniedObjectAce</c> function adds an access-denied ACE to the end of this DACL. The ACE is
		/// in the form of an ACCESS_DENIED_OBJECT_ACE structure.
		/// </param>
		/// <param name="dwAceRevision">
		/// Specifies the revision level of the DACL being modified. This value must be ACL_REVISION_DS. If the DACL's revision level is
		/// lower than ACL_REVISION_DS, the function changes it to ACL_REVISION_DS.
		/// </param>
		/// <param name="AceFlags">
		/// <para>
		/// A set of bit flags that control ACE inheritance. The function sets these flags in the <c>AceFlags</c> member of the ACE_HEADER
		/// structure of the new ACE. This parameter can be a combination of the following values.
		/// </para>
		/// <list type="table">
		/// <listheader>
		/// <term>Value</term>
		/// <term>Meaning</term>
		/// </listheader>
		/// <item>
		/// <term>CONTAINER_INHERIT_ACE</term>
		/// <term>The ACE is inherited by container objects.</term>
		/// </item>
		/// <item>
		/// <term>INHERIT_ONLY_ACE</term>
		/// <term>
		/// The ACE does not apply to the object to which the access control list (ACL) is assigned, but it can be inherited by child objects.
		/// </term>
		/// </item>
		/// <item>
		/// <term>INHERITED_ACE</term>
		/// <term>
		/// Indicates an inherited ACE. This flag allows operations that change the security on a tree of objects to modify inherited ACEs,
		/// while not changing ACEs that were directly applied to the object.
		/// </term>
		/// </item>
		/// <item>
		/// <term>NO_PROPAGATE_INHERIT_ACE</term>
		/// <term>The OBJECT_INHERIT_ACE and CONTAINER_INHERIT_ACE bits are not propagated to an inherited ACE.</term>
		/// </item>
		/// <item>
		/// <term>OBJECT_INHERIT_ACE</term>
		/// <term>The ACE is inherited by non-container objects.</term>
		/// </item>
		/// </list>
		/// </param>
		/// <param name="AccessMask">
		/// A set of bit flags that use the ACCESS_MASK format to specify the access rights that the new ACE denies to the specified security
		/// identifier (SID).
		/// </param>
		/// <param name="ObjectTypeGuid">
		/// A pointer to a GUID structure that identifies the type of object, property set, or property protected by the new ACE. If this
		/// parameter is <c>NULL</c>, the new ACE protects the object to which the ACL is assigned.
		/// </param>
		/// <param name="InheritedObjectTypeGuid">
		/// A pointer to a GUID structure that identifies the type of object that can inherit the new ACE. If this parameter is non-
		/// <c>NULL</c>, only the specified object type can inherit the ACE. If <c>NULL</c>, any type of child object can inherit the ACE. In
		/// either case, inheritance is also controlled by the value of the AceFlags parameter, as well as by any protection against
		/// inheritance placed on the child objects.
		/// </param>
		/// <param name="pSid">A pointer to a SID that identifies the user, group, or logon session to which the new ACE allows access.</param>
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
		/// <term>ERROR_INVALID_FLAGS</term>
		/// <term>The AceFlags parameter is not valid.</term>
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
		/// If both ObjectTypeGuid and InheritedObjectTypeGuid are <c>NULL</c>, use the AddAccessDeniedAceEx function rather than
		/// <c>AddAccessDeniedObjectAce</c>. This is suggested because an ACCESS_DENIED_ACE is smaller and more efficient than an ACCESS_DENIED_OBJECT_ACE.
		/// </para>
		/// <para>
		/// Although the <c>AddAccessDeniedObjectAce</c> function adds the new ACE to the end of the ACL, access-denied ACEs should appear at
		/// the beginning of an ACL. The caller must ensure that ACEs are added to the DACL in the correct order. For more information, see
		/// Order of ACEs in a DACL.
		/// </para>
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows/desktop/api/securitybaseapi/nf-securitybaseapi-addaccessdeniedobjectace BOOL
		// AddAccessDeniedObjectAce( PACL pAcl, DWORD dwAceRevision, DWORD AceFlags, DWORD AccessMask, GUID *ObjectTypeGuid, GUID
		// *InheritedObjectTypeGuid, PSID pSid );
		[DllImport(Lib.AdvApi32, SetLastError = true, ExactSpelling = true)]
		[PInvokeData("securitybaseapi.h", MSDNShortId = "1427c908-92b6-46b2-9189-a2fd93c470b1")]
		[return: MarshalAs(UnmanagedType.Bool)]
		public static extern bool AddAccessDeniedObjectAce(PACL pAcl, uint dwAceRevision, AceFlags AceFlags, ACCESS_MASK AccessMask, [Optional] IntPtr ObjectTypeGuid, [Optional] IntPtr InheritedObjectTypeGuid, PSID pSid);

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
		// https://docs.microsoft.com/en-us/windows/desktop/api/securitybaseapi/nf-securitybaseapi-addace BOOL AddAce( PACL pAcl, DWORD
		// dwAceRevision, DWORD dwStartingAceIndex, LPVOID pAceList, DWORD nAceListLength );
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
		// https://docs.microsoft.com/en-us/windows/desktop/api/securitybaseapi/nf-securitybaseapi-addauditaccessace BOOL AddAuditAccessAce(
		// PACL pAcl, DWORD dwAceRevision, DWORD dwAccessMask, PSID pSid, BOOL bAuditSuccess, BOOL bAuditFailure );
		[DllImport(Lib.AdvApi32, SetLastError = true, ExactSpelling = true)]
		[PInvokeData("securitybaseapi.h", MSDNShortId = "34f22aea-9cde-411e-b2d5-bfcd3bfe325d")]
		[return: MarshalAs(UnmanagedType.Bool)]
		public static extern bool AddAuditAccessAce(PACL pAcl, uint dwAceRevision, ACCESS_MASK dwAccessMask, PSID pSid, [MarshalAs(UnmanagedType.Bool)] bool bAuditSuccess, [MarshalAs(UnmanagedType.Bool)] bool bAuditFailure);

		/// <summary>
		/// The <c>AddAuditAccessAceEx</c> function adds a system-audit access control entry (ACE) to the end of a system access control list (SACL).
		/// </summary>
		/// <param name="pAcl">
		/// A pointer to a SACL. The <c>AddAuditAccessAceEx</c> function adds a system-audit ACE to this SACL. The ACE is in the form of a
		/// SYSTEM_AUDIT_ACE structure.
		/// </param>
		/// <param name="dwAceRevision">
		/// Specifies the revision level of the SACL being modified. This value can be ACL_REVISION or ACL_REVISION_DS. Use ACL_REVISION_DS
		/// if the SACL contains object-specific ACEs.
		/// </param>
		/// <param name="AceFlags">
		/// <para>
		/// A set of bit flags that control ACE inheritance and the type of access attempts to audit. The function sets these flags in the
		/// <c>AceFlags</c> member of the ACE_HEADER structure of the new ACE. This parameter can be a combination of the following values.
		/// </para>
		/// <list type="table">
		/// <listheader>
		/// <term>Value</term>
		/// <term>Meaning</term>
		/// </listheader>
		/// <item>
		/// <term>CONTAINER_INHERIT_ACE</term>
		/// <term>The ACE is inherited by container objects.</term>
		/// </item>
		/// <item>
		/// <term>FAILED_ACCESS_ACE_FLAG</term>
		/// <term>
		/// If you set this flag or specify TRUE for the bAuditFailure parameter, failed attempts to use the specified access rights cause
		/// the system to generate an audit record in the security event log.
		/// </term>
		/// </item>
		/// <item>
		/// <term>INHERIT_ONLY_ACE</term>
		/// <term>
		/// The ACE does not apply to the object to which the access control list (ACL) is assigned, but it can be inherited by child objects.
		/// </term>
		/// </item>
		/// <item>
		/// <term>INHERITED_ACE</term>
		/// <term>
		/// Indicates an inherited ACE. This flag allows operations that change the security on a tree of objects to modify inherited ACEs,
		/// while not changing ACEs that were directly applied to the object.
		/// </term>
		/// </item>
		/// <item>
		/// <term>NO_PROPAGATE_INHERIT_ACE</term>
		/// <term>The OBJECT_INHERIT_ACE and CONTAINER_INHERIT_ACE bits are not propagated to an inherited ACE.</term>
		/// </item>
		/// <item>
		/// <term>OBJECT_INHERIT_ACE</term>
		/// <term>The ACE is inherited by non-container objects.</term>
		/// </item>
		/// <item>
		/// <term>SUCCESSFUL_ACCESS_ACE_FLAG</term>
		/// <term>
		/// If you set this flag or specify TRUE for the bAuditSuccess parameter, successful uses of the specified access rights cause the
		/// system to generate an audit record in the security event log.
		/// </term>
		/// </item>
		/// </list>
		/// </param>
		/// <param name="dwAccessMask">
		/// A set of bit flags that use the ACCESS_MASK format to specify the access rights that the new ACE audits for the specified
		/// security identifier (SID).
		/// </param>
		/// <param name="pSid">A pointer to a SID that identifies the user, group, or logon session for which the new ACE audits access.</param>
		/// <param name="bAuditSuccess">
		/// Specifies whether successful uses of the specified access rights cause the system to generate an audit record in the security
		/// event log. If this flag is <c>TRUE</c> or if the AceFlags parameter specifies the SUCCESSFUL_ACCESS_ACE_FLAG flag, the system
		/// records successful access attempts; otherwise, it does not.
		/// </param>
		/// <param name="bAuditFailure">
		/// Specifies whether failed attempts to use the specified access rights cause the system to generate an audit record in the security
		/// event log. If this flag is <c>TRUE</c> or if the AceFlags parameter specifies the FAILED_ACCESS_ACE_FLAG flag, the system records
		/// failed access attempts; otherwise, it does not.
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
		/// <term>ERROR_INVALID_FLAGS</term>
		/// <term>The AceFlags parameter is not valid.</term>
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
		// https://docs.microsoft.com/en-us/windows/desktop/api/securitybaseapi/nf-securitybaseapi-addauditaccessaceex BOOL
		// AddAuditAccessAceEx( PACL pAcl, DWORD dwAceRevision, DWORD AceFlags, DWORD dwAccessMask, PSID pSid, BOOL bAuditSuccess, BOOL
		// bAuditFailure );
		[DllImport(Lib.AdvApi32, SetLastError = true, ExactSpelling = true)]
		[PInvokeData("securitybaseapi.h", MSDNShortId = "ddd1d815-c4ce-4572-982c-139e17cda192")]
		[return: MarshalAs(UnmanagedType.Bool)]
		public static extern bool AddAuditAccessAceEx(PACL pAcl, uint dwAceRevision, AceFlags AceFlags, ACCESS_MASK dwAccessMask, PSID pSid, [MarshalAs(UnmanagedType.Bool)] bool bAuditSuccess, [MarshalAs(UnmanagedType.Bool)] bool bAuditFailure);

		/// <summary>
		/// The <c>AddAuditAccessObjectAce</c> function adds a system-audit access control entry (ACE) to the end of a system access control
		/// list (SACL). The new ACE can audit access to an object, or to a property set or property on an object. You can also use
		/// <c>AddAuditAccessObjectAce</c> to add an ACE that only a specified type of child object can inherit.
		/// </summary>
		/// <param name="pAcl">
		/// A pointer to a SACL. The <c>AddAuditAccessObjectAce</c> function adds a system-audit ACE to the end of this SACL. The ACE is in
		/// the form of a SYSTEM_AUDIT_OBJECT_ACE structure.
		/// </param>
		/// <param name="dwAceRevision">
		/// Specifies the revision level of the SACL being modified. This value must be ACL_REVISION_DS. If the SACL's revision level is
		/// lower than ACL_REVISION_DS, the function changes it to ACL_REVISION_DS.
		/// </param>
		/// <param name="AceFlags">
		/// <para>
		/// A set of bit flags that control ACE inheritance and the type of access attempts to audit. The function sets these flags in the
		/// <c>AceFlags</c> member of the ACE_HEADER structure of the new ACE. This parameter can be a combination of the following values.
		/// </para>
		/// <list type="table">
		/// <listheader>
		/// <term>Value</term>
		/// <term>Meaning</term>
		/// </listheader>
		/// <item>
		/// <term>CONTAINER_INHERIT_ACE</term>
		/// <term>The ACE is inherited by container objects.</term>
		/// </item>
		/// <item>
		/// <term>FAILED_ACCESS_ACE_FLAG</term>
		/// <term>
		/// If you set this flag or specify TRUE for the bAuditFailure parameter, failed attempts to use the specified access rights cause
		/// the system to generate an audit record in the security event log.
		/// </term>
		/// </item>
		/// <item>
		/// <term>INHERIT_ONLY_ACE</term>
		/// <term>
		/// The ACE does not apply to the object to which the access control list (ACL) is assigned, but it can be inherited by child objects.
		/// </term>
		/// </item>
		/// <item>
		/// <term>INHERITED_ACE</term>
		/// <term>
		/// Indicates an inherited ACE. This flag allows operations that change the security on a tree of objects to modify inherited ACEs,
		/// while not changing ACEs that were directly applied to the object.
		/// </term>
		/// </item>
		/// <item>
		/// <term>NO_PROPAGATE_INHERIT_ACE</term>
		/// <term>The OBJECT_INHERIT_ACE and CONTAINER_INHERIT_ACE bits are not propagated to an inherited ACE.</term>
		/// </item>
		/// <item>
		/// <term>OBJECT_INHERIT_ACE</term>
		/// <term>The ACE is inherited by non-container objects.</term>
		/// </item>
		/// <item>
		/// <term>SUCCESSFUL_ACCESS_ACE_FLAG</term>
		/// <term>
		/// If you set this flag or specify TRUE for the bAuditSuccess parameter, successful uses of the specified access rights cause the
		/// system to generate an audit record in the security event log.
		/// </term>
		/// </item>
		/// </list>
		/// </param>
		/// <param name="AccessMask">
		/// An ACCESS_MASK that specifies the access rights that the new ACE audits for the specified security identifier (SID).
		/// </param>
		/// <param name="ObjectTypeGuid">
		/// A pointer to a GUID structure that identifies the type of object, property set, or property protected by the new ACE. If this
		/// parameter is <c>NULL</c>, the new ACE protects the object to which the ACL is assigned.
		/// </param>
		/// <param name="InheritedObjectTypeGuid">
		/// A pointer to a GUID structure that identifies the type of object that can inherit the new ACE. If this parameter is non-
		/// <c>NULL</c>, only the specified object type can inherit the ACE. If <c>NULL</c>, any type of child object can inherit the ACE. In
		/// either case, inheritance is also controlled by the value of the AceFlags parameter, as well as by any protection against
		/// inheritance placed on the child objects.
		/// </param>
		/// <param name="pSid">A pointer to a SID that identifies the user, group, or logon session for which the new ACE audits access.</param>
		/// <param name="bAuditSuccess">
		/// Specifies whether successful uses of the specified access rights cause the system to generate an audit record in the security
		/// event log. If this flag is <c>TRUE</c> or if the AceFlags parameter specifies the SUCCESSFUL_ACCESS_ACE_FLAG flag, the system
		/// records successful access attempts; otherwise, it does not.
		/// </param>
		/// <param name="bAuditFailure">
		/// Specifies whether failed attempts to use the specified access rights cause the system to generate an audit record in the security
		/// event log. If this flag is <c>TRUE</c> or if the AceFlags parameter specifies the FAILED_ACCESS_ACE_FLAG flag, the system records
		/// failed access attempts; otherwise, it does not.
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
		/// <term>ERROR_INVALID_FLAGS</term>
		/// <term>The AceFlags parameter is not valid.</term>
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
		/// If both ObjectTypeGuid and InheritedObjectTypeGuid are <c>NULL</c>, use the AddAuditAccessAceEx function rather than
		/// <c>AddAuditAccessObjectAce</c>. This is suggested because a SYSTEM_AUDIT_ACE is smaller and more efficient than a SYSTEM_AUDIT_OBJECT_ACE.
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows/desktop/api/securitybaseapi/nf-securitybaseapi-addauditaccessobjectace BOOL
		// AddAuditAccessObjectAce( PACL pAcl, DWORD dwAceRevision, DWORD AceFlags, DWORD AccessMask, GUID *ObjectTypeGuid, GUID
		// *InheritedObjectTypeGuid, PSID pSid, BOOL bAuditSuccess, BOOL bAuditFailure );
		[DllImport(Lib.AdvApi32, SetLastError = true, ExactSpelling = true)]
		[PInvokeData("securitybaseapi.h", MSDNShortId = "be852a0c-9d96-4b29-b5f9-d9c41d838c12")]
		[return: MarshalAs(UnmanagedType.Bool)]
		public static extern bool AddAuditAccessObjectAce(PACL pAcl, uint dwAceRevision, AceFlags AceFlags, ACCESS_MASK AccessMask, in Guid ObjectTypeGuid, in Guid InheritedObjectTypeGuid, PSID pSid, [MarshalAs(UnmanagedType.Bool)] bool bAuditSuccess, [MarshalAs(UnmanagedType.Bool)] bool bAuditFailure);

		/// <summary>
		/// The <c>AddAuditAccessObjectAce</c> function adds a system-audit access control entry (ACE) to the end of a system access control
		/// list (SACL). The new ACE can audit access to an object, or to a property set or property on an object. You can also use
		/// <c>AddAuditAccessObjectAce</c> to add an ACE that only a specified type of child object can inherit.
		/// </summary>
		/// <param name="pAcl">
		/// A pointer to a SACL. The <c>AddAuditAccessObjectAce</c> function adds a system-audit ACE to the end of this SACL. The ACE is in
		/// the form of a SYSTEM_AUDIT_OBJECT_ACE structure.
		/// </param>
		/// <param name="dwAceRevision">
		/// Specifies the revision level of the SACL being modified. This value must be ACL_REVISION_DS. If the SACL's revision level is
		/// lower than ACL_REVISION_DS, the function changes it to ACL_REVISION_DS.
		/// </param>
		/// <param name="AceFlags">
		/// <para>
		/// A set of bit flags that control ACE inheritance and the type of access attempts to audit. The function sets these flags in the
		/// <c>AceFlags</c> member of the ACE_HEADER structure of the new ACE. This parameter can be a combination of the following values.
		/// </para>
		/// <list type="table">
		/// <listheader>
		/// <term>Value</term>
		/// <term>Meaning</term>
		/// </listheader>
		/// <item>
		/// <term>CONTAINER_INHERIT_ACE</term>
		/// <term>The ACE is inherited by container objects.</term>
		/// </item>
		/// <item>
		/// <term>FAILED_ACCESS_ACE_FLAG</term>
		/// <term>
		/// If you set this flag or specify TRUE for the bAuditFailure parameter, failed attempts to use the specified access rights cause
		/// the system to generate an audit record in the security event log.
		/// </term>
		/// </item>
		/// <item>
		/// <term>INHERIT_ONLY_ACE</term>
		/// <term>
		/// The ACE does not apply to the object to which the access control list (ACL) is assigned, but it can be inherited by child objects.
		/// </term>
		/// </item>
		/// <item>
		/// <term>INHERITED_ACE</term>
		/// <term>
		/// Indicates an inherited ACE. This flag allows operations that change the security on a tree of objects to modify inherited ACEs,
		/// while not changing ACEs that were directly applied to the object.
		/// </term>
		/// </item>
		/// <item>
		/// <term>NO_PROPAGATE_INHERIT_ACE</term>
		/// <term>The OBJECT_INHERIT_ACE and CONTAINER_INHERIT_ACE bits are not propagated to an inherited ACE.</term>
		/// </item>
		/// <item>
		/// <term>OBJECT_INHERIT_ACE</term>
		/// <term>The ACE is inherited by non-container objects.</term>
		/// </item>
		/// <item>
		/// <term>SUCCESSFUL_ACCESS_ACE_FLAG</term>
		/// <term>
		/// If you set this flag or specify TRUE for the bAuditSuccess parameter, successful uses of the specified access rights cause the
		/// system to generate an audit record in the security event log.
		/// </term>
		/// </item>
		/// </list>
		/// </param>
		/// <param name="AccessMask">
		/// An ACCESS_MASK that specifies the access rights that the new ACE audits for the specified security identifier (SID).
		/// </param>
		/// <param name="ObjectTypeGuid">
		/// A pointer to a GUID structure that identifies the type of object, property set, or property protected by the new ACE. If this
		/// parameter is <c>NULL</c>, the new ACE protects the object to which the ACL is assigned.
		/// </param>
		/// <param name="InheritedObjectTypeGuid">
		/// A pointer to a GUID structure that identifies the type of object that can inherit the new ACE. If this parameter is non-
		/// <c>NULL</c>, only the specified object type can inherit the ACE. If <c>NULL</c>, any type of child object can inherit the ACE. In
		/// either case, inheritance is also controlled by the value of the AceFlags parameter, as well as by any protection against
		/// inheritance placed on the child objects.
		/// </param>
		/// <param name="pSid">A pointer to a SID that identifies the user, group, or logon session for which the new ACE audits access.</param>
		/// <param name="bAuditSuccess">
		/// Specifies whether successful uses of the specified access rights cause the system to generate an audit record in the security
		/// event log. If this flag is <c>TRUE</c> or if the AceFlags parameter specifies the SUCCESSFUL_ACCESS_ACE_FLAG flag, the system
		/// records successful access attempts; otherwise, it does not.
		/// </param>
		/// <param name="bAuditFailure">
		/// Specifies whether failed attempts to use the specified access rights cause the system to generate an audit record in the security
		/// event log. If this flag is <c>TRUE</c> or if the AceFlags parameter specifies the FAILED_ACCESS_ACE_FLAG flag, the system records
		/// failed access attempts; otherwise, it does not.
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
		/// <term>ERROR_INVALID_FLAGS</term>
		/// <term>The AceFlags parameter is not valid.</term>
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
		/// If both ObjectTypeGuid and InheritedObjectTypeGuid are <c>NULL</c>, use the AddAuditAccessAceEx function rather than
		/// <c>AddAuditAccessObjectAce</c>. This is suggested because a SYSTEM_AUDIT_ACE is smaller and more efficient than a SYSTEM_AUDIT_OBJECT_ACE.
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows/desktop/api/securitybaseapi/nf-securitybaseapi-addauditaccessobjectace BOOL
		// AddAuditAccessObjectAce( PACL pAcl, DWORD dwAceRevision, DWORD AceFlags, DWORD AccessMask, GUID *ObjectTypeGuid, GUID
		// *InheritedObjectTypeGuid, PSID pSid, BOOL bAuditSuccess, BOOL bAuditFailure );
		[DllImport(Lib.AdvApi32, SetLastError = true, ExactSpelling = true)]
		[PInvokeData("securitybaseapi.h", MSDNShortId = "be852a0c-9d96-4b29-b5f9-d9c41d838c12")]
		[return: MarshalAs(UnmanagedType.Bool)]
		public static extern bool AddAuditAccessObjectAce(PACL pAcl, uint dwAceRevision, AceFlags AceFlags, ACCESS_MASK AccessMask, [Optional] IntPtr ObjectTypeGuid, [Optional] IntPtr InheritedObjectTypeGuid, PSID pSid, [MarshalAs(UnmanagedType.Bool)] bool bAuditSuccess, [MarshalAs(UnmanagedType.Bool)] bool bAuditFailure);

		/// <summary>
		/// The <c>AddMandatoryAce</c> function adds a SYSTEM_MANDATORY_LABEL_ACE access control entry (ACE) to the specified system access
		/// control list (SACL).
		/// </summary>
		/// <param name="pAcl">
		/// A pointer to an SACL. This function adds a mandatory ACE to the end of this SACL. The ACE is in the form of a
		/// SYSTEM_MANDATORY_LABEL_ACE structure.
		/// </param>
		/// <param name="dwAceRevision">
		/// <para>The revision level of the SACL being modified. This value can be one of the following values.</para>
		/// <list type="table">
		/// <listheader>
		/// <term>Value</term>
		/// <term>Meaning</term>
		/// </listheader>
		/// <item>
		/// <term>ACL_REVISION</term>
		/// <term>The SACL does not contain object-specific ACEs.</term>
		/// </item>
		/// <item>
		/// <term>ACL_REVISION_DS</term>
		/// <term>The SACL contains object-specified ACEs.</term>
		/// </item>
		/// </list>
		/// </param>
		/// <param name="AceFlags">
		/// <para>
		/// A set of bit flags that control ACE inheritance. This function sets these flags in the <c>AceFlags</c> member of the ACE_HEADER
		/// structure of the new ACE.
		/// </para>
		/// <para>This parameter can be a combination of the following values.</para>
		/// <list type="table">
		/// <listheader>
		/// <term>Value</term>
		/// <term>Meaning</term>
		/// </listheader>
		/// <item>
		/// <term>OBJECT_INHERIT_ACE 0x1</term>
		/// <term>The ACE is inherited by non-container objects.</term>
		/// </item>
		/// <item>
		/// <term>CONTAINER_INHERIT_ACE 0x2</term>
		/// <term>The ACE is inherited by container objects.</term>
		/// </item>
		/// <item>
		/// <term>NO_PROPAGATE_INHERIT_ACE 0x4</term>
		/// <term>The OBJECT_INHERIT_ACE and CONTAINER_INHERIT_ACE bits are not propagated to an inherited ACE.</term>
		/// </item>
		/// <item>
		/// <term>INHERIT_ONLY_ACE 0x8</term>
		/// <term>The ACE does not apply to the object to which the SACL is assigned, but the ACE can be inherited by child objects.</term>
		/// </item>
		/// <item>
		/// <term>INHERITED_ACE 0x10</term>
		/// <term>
		/// The ACE is inherited. Operations that change the security on a tree of objects may modify inherited ACEs without changing ACEs
		/// that were directly applied to the object.
		/// </term>
		/// </item>
		/// </list>
		/// </param>
		/// <param name="MandatoryPolicy">
		/// <para>
		/// The access policy for principals with a mandatory integrity level lower than the object associated with the SACL that contains
		/// this ACE.
		/// </para>
		/// <list type="table">
		/// <listheader>
		/// <term>Value</term>
		/// <term>Meaning</term>
		/// </listheader>
		/// <item>
		/// <term>SYSTEM_MANDATORY_LABEL_NO_WRITE_UP 0x1</term>
		/// <term>A principal with a lower mandatory level than the object cannot write to the object.</term>
		/// </item>
		/// <item>
		/// <term>SYSTEM_MANDATORY_LABEL_NO_READ_UP 0x2</term>
		/// <term>A principal with a lower mandatory level than the object cannot read the object.</term>
		/// </item>
		/// <item>
		/// <term>SYSTEM_MANDATORY_LABEL_NO_EXECUTE_UP 0x4</term>
		/// <term>A principal with a lower mandatory level than the object cannot execute the object.</term>
		/// </item>
		/// </list>
		/// </param>
		/// <param name="pLabelSid">
		/// A pointer to an SID that specifies the mandatory integrity level of the object associated with the SACL being appended.
		/// </param>
		/// <returns>
		/// <para>If the function succeeds, it returns <c>TRUE</c>.</para>
		/// <para>
		/// If the function fails, it returns <c>FALSE</c>. For extended error information, call GetLastError. The following are possible
		/// error values.
		/// </para>
		/// <list type="table">
		/// <listheader>
		/// <term>Return code/value</term>
		/// <term>Description</term>
		/// </listheader>
		/// <item>
		/// <term>ERROR_ALLOTTED_SPACE_EXCEEDED 0x540</term>
		/// <term>The new ACE does not fit into the pAcl buffer.</term>
		/// </item>
		/// </list>
		/// </returns>
		/// <remarks>
		/// To compile an application that uses this function, define _WIN32_WINNT as 0x0600 or later. For more information, see Using the
		/// Windows Headers.
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows/desktop/api/securitybaseapi/nf-securitybaseapi-addmandatoryace BOOL AddMandatoryAce( PACL
		// pAcl, DWORD dwAceRevision, DWORD AceFlags, DWORD MandatoryPolicy, PSID pLabelSid );
		[DllImport(Lib.AdvApi32, SetLastError = true, ExactSpelling = true)]
		[PInvokeData("securitybaseapi.h", MSDNShortId = "22c8f384-fdb7-4d5a-8854-d9fd25cd351e")]
		[return: MarshalAs(UnmanagedType.Bool)]
		public static extern bool AddMandatoryAce(PACL pAcl, uint dwAceRevision, AceFlags AceFlags, SYSTEM_MANDATORY_LABEL MandatoryPolicy, PSID pLabelSid);

		/// <summary>
		/// The <c>AddResourceAttributeAce</c> function adds a SYSTEM_RESOURCE_ATTRIBUTE_ACE access control entry (ACE) to the end of a
		/// system access control list (SACL). A <c>SYSTEM_RESOURCE_ATTRIBUTE_ACE</c> structure specifies an attribute name and a
		/// value-ordered list of elements that is associated with a resource and potentially used during access checks. The set of standard
		/// access rights are defined in the Standard Access Rights topic.
		/// </summary>
		/// <param name="pAcl">
		/// A pointer to an access control list (ACL). This function adds an ACE to this ACL. The value of this parameter cannot be
		/// <c>NULL</c>. The ACE is in the form of a SYSTEM_RESOURCE_ATTRIBUTE_ACE structure.
		/// </param>
		/// <param name="dwAceRevision">
		/// Specifies the revision level of the ACL being modified. This value can be ACL_REVISION or ACL_REVISION_DS. Use ACL_REVISION_DS if
		/// the ACL contains object-specific ACEs.
		/// </param>
		/// <param name="AceFlags">
		/// <para>
		/// A set of bit flags that control ACE inheritance. The function sets these flags in the <c>AceFlags</c> member of the ACE_HEADER
		/// structure of the new ACE.
		/// </para>
		/// <para>
		/// For consistency with the Windows 8 Advanced File Permissions UI, applications should specify the CONTAINER_INHERIT_ACE and
		/// OBJECT_INHERIT_ACE flags in the AceFlags parameter.
		/// </para>
		/// <para>This parameter can be a combination of the following values.</para>
		/// <list type="table">
		/// <listheader>
		/// <term>Value</term>
		/// <term>Meaning</term>
		/// </listheader>
		/// <item>
		/// <term>CONTAINER_INHERIT_ACE 2 (0x2)</term>
		/// <term>The ACE is inherited by the container objects.</term>
		/// </item>
		/// <item>
		/// <term>INHERIT_ONLY_ACE 8 (0x8)</term>
		/// <term>The ACE does not apply to the object the ACE is assigned to, but it can be inherited by child objects.</term>
		/// </item>
		/// <item>
		/// <term>INHERITED_ACE 16 (0x10)</term>
		/// <term>
		/// Indicates an inherited ACE. This flag allows operations that change the security on a tree of objects to modify inherited ACEs
		/// while not changing ACEs that were directly applied to the object.
		/// </term>
		/// </item>
		/// <item>
		/// <term>NO_PROPAGATE_INHERIT_ACE 4 (0x4)</term>
		/// <term>The OBJECT_INHERIT_ACE and CONTAINER_INHERIT_ACE bits are not propagated to an inherited ACE.</term>
		/// </item>
		/// <item>
		/// <term>OBJECT_INHERIT_ACE 1 (0x1)</term>
		/// <term>The ACE is inherited by non-container objects.</term>
		/// </item>
		/// </list>
		/// </param>
		/// <param name="AccessMask">Must be zero for Windows 8 and Windows Server 2012.</param>
		/// <param name="pSid">Must be the Everyone SID (S-1-1-0) for Windows 8 and Windows Server 2012.</param>
		/// <param name="pAttributeInfo">Specifies the attribute information that will be appended after the SID in the ACE.</param>
		/// <param name="pReturnLength">
		/// The size, in bytes, of the actual ACL buffer used. If the buffer specified by the pAcl parameter is not big enough, the value of
		/// this parameter is the total size required for the ACL buffer.
		/// </param>
		/// <returns>
		/// <para>If the function succeeds, it returns <c>TRUE</c>.</para>
		/// <para>If the function fails, it returns <c>FALSE</c>. To get extended error information, call GetLastError.</para>
		/// </returns>
		// https://docs.microsoft.com/en-us/windows/desktop/api/securitybaseapi/nf-securitybaseapi-addresourceattributeace BOOL
		// AddResourceAttributeAce( PACL pAcl, DWORD dwAceRevision, DWORD AceFlags, DWORD AccessMask, PSID pSid,
		// PCLAIM_SECURITY_ATTRIBUTES_INFORMATION pAttributeInfo, PDWORD pReturnLength );
		[DllImport(Lib.Kernel32, SetLastError = true, ExactSpelling = true)]
		[PInvokeData("securitybaseapi.h", MSDNShortId = "AA2064E4-6F76-4D7B-8540-D55A91168825")]
		[return: MarshalAs(UnmanagedType.Bool)]
		public static extern bool AddResourceAttributeAce(PACL pAcl, uint dwAceRevision, AceFlags AceFlags, ACCESS_MASK AccessMask, PSID pSid, in CLAIM_SECURITY_ATTRIBUTES_INFORMATION pAttributeInfo, ref uint pReturnLength);

		/// <summary>
		/// The <c>AddScopedPolicyIDAce</c> function adds a SYSTEM_SCOPED_POLICY_ID_ACE access control entry (ACE) to the end of a system
		/// access control list (SACL). A <c>SYSTEM_SCOPED_POLICY_ID_ACE</c> structure specifies a central access policy (CAP) to be
		/// associated with the resource and can be used during access checks. The set of standard access rights are defined in the Standard
		/// Access Rights topic.
		/// </summary>
		/// <param name="pAcl">
		/// A pointer to an access control list (ACL). This function adds an ACE to this ACL. The value of this parameter cannot be <c>NULL</c>.
		/// </param>
		/// <param name="dwAceRevision">
		/// Specifies the revision level of the ACL being modified. This value can be ACL_REVISION or ACL_REVISION_DS. Use ACL_REVISION_DS if
		/// the ACL contains object-specific ACEs.
		/// </param>
		/// <param name="AceFlags">
		/// <para>
		/// A set of bit flags that control ACE inheritance. The function sets these flags in the <c>AceFlags</c> member of the ACE_HEADER
		/// structure of the new ACE.
		/// </para>
		/// <para>
		/// For consistency with the Windows 8 Advanced File Permissions UI, applications should specify the CONTAINER_INHERIT_ACE and
		/// OBJECT_INHERIT_ACE flags in the AceFlags parameter.
		/// </para>
		/// <para>This parameter can be a combination of the following values.</para>
		/// <list type="table">
		/// <listheader>
		/// <term>Value</term>
		/// <term>Meaning</term>
		/// </listheader>
		/// <item>
		/// <term>CONTAINER_INHERIT_ACE 2 (0x2)</term>
		/// <term>The ACE is inherited by the container objects.</term>
		/// </item>
		/// <item>
		/// <term>INHERIT_ONLY_ACE 8 (0x8)</term>
		/// <term>The ACE does not apply to the object the ACE is assigned to, but it can be inherited by child objects.</term>
		/// </item>
		/// <item>
		/// <term>INHERITED_ACE 16 (0x10)</term>
		/// <term>
		/// Indicates an inherited ACE. This flag allows operations that change the security on a tree of objects to modify inherited ACEs
		/// while not changing ACEs that were directly applied to the object.
		/// </term>
		/// </item>
		/// <item>
		/// <term>NO_PROPAGATE_INHERIT_ACE 4 (0x4)</term>
		/// <term>The OBJECT_INHERIT_ACE and CONTAINER_INHERIT_ACE bits are not propagated to an inherited ACE.</term>
		/// </item>
		/// <item>
		/// <term>OBJECT_INHERIT_ACE 1 (0x1)</term>
		/// <term>The ACE is inherited by non-container objects.</term>
		/// </item>
		/// </list>
		/// </param>
		/// <param name="AccessMask">Must be zero for Windows 8 and Windows Server 2012.</param>
		/// <param name="pSid">A pointer to the SID (S-1-17-*) that identifies the Central Access Policy to be associated with the resource.</param>
		/// <returns>
		/// <para>If the function succeeds, it returns <c>TRUE</c>.</para>
		/// <para>If the function fails, it returns <c>FALSE</c>. To get extended error information, call GetLastError.</para>
		/// </returns>
		// https://docs.microsoft.com/en-us/windows/desktop/api/securitybaseapi/nf-securitybaseapi-addscopedpolicyidace BOOL
		// AddScopedPolicyIDAce( PACL pAcl, DWORD dwAceRevision, DWORD AceFlags, DWORD AccessMask, PSID pSid );
		[DllImport(Lib.Kernel32, SetLastError = true, ExactSpelling = true)]
		[PInvokeData("securitybaseapi.h", MSDNShortId = "30AA5730-566C-4B02-A904-5A38237EE8E3")]
		[return: MarshalAs(UnmanagedType.Bool)]
		public static extern bool AddScopedPolicyIDAce(PACL pAcl, uint dwAceRevision, AceFlags AceFlags, ACCESS_MASK AccessMask, PSID pSid);

		/// <summary>
		/// The <c>AdjustTokenGroups</c> function enables or disables groups already present in the specified access token. Access to
		/// TOKEN_ADJUST_GROUPS is required to enable or disable groups in an access token.
		/// </summary>
		/// <param name="TokenHandle">
		/// A handle to the access token that contains the groups to be enabled or disabled. The handle must have TOKEN_ADJUST_GROUPS access
		/// to the token. If the PreviousState parameter is not <c>NULL</c>, the handle must also have TOKEN_QUERY access.
		/// </param>
		/// <param name="ResetToDefault">
		/// Boolean value that indicates whether the groups are to be set to their default enabled and disabled states. If this value is
		/// <c>TRUE</c>, the groups are set to their default states and the NewState parameter is ignored. If this value is <c>FALSE</c>, the
		/// groups are set according to the information pointed to by the NewState parameter.
		/// </param>
		/// <param name="NewState">
		/// A pointer to a TOKEN_GROUPS structure that contains the groups to be enabled or disabled. If the ResetToDefault parameter is
		/// <c>FALSE</c>, the function sets each of the groups to the value of that group's SE_GROUP_ENABLED attribute in the
		/// <c>TOKEN_GROUPS</c> structure. If ResetToDefault is <c>TRUE</c>, this parameter is ignored.
		/// </param>
		/// <param name="BufferLength">
		/// The size, in bytes, of the buffer pointed to by the PreviousState parameter. This parameter can be zero if the PreviousState
		/// parameter is <c>NULL</c>.
		/// </param>
		/// <param name="PreviousState">
		/// <para>
		/// A pointer to a buffer that receives a TOKEN_GROUPS structure containing the previous state of any groups the function modifies.
		/// That is, if a group has been modified by this function, the group and its previous state are contained in the <c>TOKEN_GROUPS</c>
		/// structure referenced by PreviousState. If the <c>GroupCount</c> member of <c>TOKEN_GROUPS</c> is zero, then no groups have been
		/// changed by this function. This parameter can be <c>NULL</c>.
		/// </para>
		/// <para>
		/// If a buffer is specified but it does not contain enough space to receive the complete list of modified groups, no group states
		/// are changed and the function fails. In this case, the function sets the variable pointed to by the ReturnLength parameter to the
		/// number of bytes required to hold the complete list of modified groups.
		/// </para>
		/// </param>
		/// <param name="ReturnLength">
		/// A pointer to a variable that receives the actual number of bytes needed for the buffer pointed to by the PreviousState parameter.
		/// This parameter can be <c>NULL</c> and is ignored if PreviousState is <c>NULL</c>.
		/// </param>
		/// <returns>
		/// <para>If the function succeeds, the return value is nonzero.</para>
		/// <para>If the function fails, the return value is zero. To get extended error information, call GetLastError.</para>
		/// </returns>
		/// <remarks>
		/// <para>
		/// The information retrieved in the PreviousState parameter is formatted as a TOKEN_GROUPS structure. This means a pointer to the
		/// buffer can be passed as the NewState parameter in a subsequent call to the <c>AdjustTokenGroups</c> function, restoring the
		/// original state of the groups.
		/// </para>
		/// <para>
		/// The NewState parameter can list groups to be changed that are not present in the access token. This does not affect the
		/// successful modification of the groups in the token.
		/// </para>
		/// <para>
		/// The <c>AdjustTokenGroups</c> function cannot disable groups with the SE_GROUP_MANDATORY attribute in the TOKEN_GROUPS structure.
		/// Use CreateRestrictedToken instead.
		/// </para>
		/// <para>You cannot enable a group that has the SE_GROUP_USE_FOR_DENY_ONLY attribute.</para>
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows/desktop/api/securitybaseapi/nf-securitybaseapi-adjusttokengroups BOOL AdjustTokenGroups(
		// HANDLE TokenHandle, BOOL ResetToDefault, PTOKEN_GROUPS NewState, DWORD BufferLength, PTOKEN_GROUPS PreviousState, PDWORD
		// ReturnLength );
		[DllImport(Lib.AdvApi32, SetLastError = true, ExactSpelling = true)]
		[PInvokeData("securitybaseapi.h", MSDNShortId = "839c4b58-4c61-4f72-8337-1e3dfa267ee5")]
		[return: MarshalAs(UnmanagedType.Bool)]
		public static extern bool AdjustTokenGroups(HTOKEN TokenHandle, [MarshalAs(UnmanagedType.Bool)] bool ResetToDefault, in TOKEN_GROUPS NewState, uint BufferLength, IntPtr PreviousState, out uint ReturnLength);

		/// <summary>
		/// The <c>AdjustTokenPrivileges</c> function enables or disables privileges in the specified access token. Enabling or disabling
		/// privileges in an access token requires TOKEN_ADJUST_PRIVILEGES access.
		/// </summary>
		/// <param name="TokenHandle">
		/// A handle to the access token that contains the privileges to be modified. The handle must have TOKEN_ADJUST_PRIVILEGES access to
		/// the token. If the PreviousState parameter is not <c>NULL</c>, the handle must also have TOKEN_QUERY access.
		/// </param>
		/// <param name="DisableAllPrivileges">
		/// Specifies whether the function disables all of the token's privileges. If this value is <c>TRUE</c>, the function disables all
		/// privileges and ignores the NewState parameter. If it is <c>FALSE</c>, the function modifies privileges based on the information
		/// pointed to by the NewState parameter.
		/// </param>
		/// <param name="NewState">
		/// <para>
		/// A pointer to a TOKEN_PRIVILEGES structure that specifies an array of privileges and their attributes. If the DisableAllPrivileges
		/// parameter is <c>FALSE</c>, the <c>AdjustTokenPrivileges</c> function enables, disables, or removes these privileges for the
		/// token. The following table describes the action taken by the <c>AdjustTokenPrivileges</c> function, based on the privilege attribute.
		/// </para>
		/// <list type="table">
		/// <listheader>
		/// <term>Value</term>
		/// <term>Meaning</term>
		/// </listheader>
		/// <item>
		/// <term>SE_PRIVILEGE_ENABLED</term>
		/// <term>The function enables the privilege.</term>
		/// </item>
		/// <item>
		/// <term>SE_PRIVILEGE_REMOVED</term>
		/// <term>
		/// The privilege is removed from the list of privileges in the token. The other privileges in the list are reordered to remain
		/// contiguous. SE_PRIVILEGE_REMOVED supersedes SE_PRIVILEGE_ENABLED. Because the privilege has been removed from the token, attempts
		/// to reenable the privilege result in the warning ERROR_NOT_ALL_ASSIGNED as if the privilege had never existed. Attempting to
		/// remove a privilege that does not exist in the token results in ERROR_NOT_ALL_ASSIGNED being returned. Privilege checks for
		/// removed privileges result in STATUS_PRIVILEGE_NOT_HELD. Failed privilege check auditing occurs as normal. The removal of the
		/// privilege is irreversible, so the name of the removed privilege is not included in the PreviousState parameter after a call to
		/// AdjustTokenPrivileges. Windows XP with SP1: The function cannot remove privileges. This value is not supported.
		/// </term>
		/// </item>
		/// <item>
		/// <term>None</term>
		/// <term>The function disables the privilege.</term>
		/// </item>
		/// </list>
		/// <para>If DisableAllPrivileges is <c>TRUE</c>, the function ignores this parameter.</para>
		/// </param>
		/// <param name="BufferLength">
		/// Specifies the size, in bytes, of the buffer pointed to by the PreviousState parameter. This parameter can be zero if the
		/// PreviousState parameter is <c>NULL</c>.
		/// </param>
		/// <param name="PreviousState">
		/// <para>
		/// A pointer to a buffer that the function fills with a TOKEN_PRIVILEGES structure that contains the previous state of any
		/// privileges that the function modifies. That is, if a privilege has been modified by this function, the privilege and its previous
		/// state are contained in the <c>TOKEN_PRIVILEGES</c> structure referenced by PreviousState. If the <c>PrivilegeCount</c> member of
		/// <c>TOKEN_PRIVILEGES</c> is zero, then no privileges have been changed by this function. This parameter can be <c>NULL</c>.
		/// </para>
		/// <para>
		/// If you specify a buffer that is too small to receive the complete list of modified privileges, the function fails and does not
		/// adjust any privileges. In this case, the function sets the variable pointed to by the ReturnLength parameter to the number of
		/// bytes required to hold the complete list of modified privileges.
		/// </para>
		/// </param>
		/// <param name="ReturnLength">
		/// A pointer to a variable that receives the required size, in bytes, of the buffer pointed to by the PreviousState parameter. This
		/// parameter can be <c>NULL</c> if PreviousState is <c>NULL</c>.
		/// </param>
		/// <returns>
		/// <para>
		/// If the function succeeds, the return value is nonzero. To determine whether the function adjusted all of the specified
		/// privileges, call GetLastError, which returns one of the following values when the function succeeds:
		/// </para>
		/// <list type="table">
		/// <listheader>
		/// <term>Return code</term>
		/// <term>Description</term>
		/// </listheader>
		/// <item>
		/// <term>ERROR_SUCCESS</term>
		/// <term>The function adjusted all specified privileges.</term>
		/// </item>
		/// <item>
		/// <term>ERROR_NOT_ALL_ASSIGNED</term>
		/// <term>
		/// The token does not have one or more of the privileges specified in the NewState parameter. The function may succeed with this
		/// error value even if no privileges were adjusted. The PreviousState parameter indicates the privileges that were adjusted.
		/// </term>
		/// </item>
		/// </list>
		/// <para>If the function fails, the return value is zero. To get extended error information, call GetLastError.</para>
		/// </returns>
		/// <remarks>
		/// <para>
		/// The <c>AdjustTokenPrivileges</c> function cannot add new privileges to the access token. It can only enable or disable the
		/// token's existing privileges. To determine the token's privileges, call the GetTokenInformation function.
		/// </para>
		/// <para>
		/// The NewState parameter can specify privileges that the token does not have, without causing the function to fail. In this case,
		/// the function adjusts the privileges that the token does have and ignores the other privileges so that the function succeeds. Call
		/// the GetLastError function to determine whether the function adjusted all of the specified privileges. The PreviousState parameter
		/// indicates the privileges that were adjusted.
		/// </para>
		/// <para>
		/// The PreviousState parameter retrieves a TOKEN_PRIVILEGES structure that contains the original state of the adjusted privileges.
		/// To restore the original state, pass the PreviousState pointer as the NewState parameter in a subsequent call to the
		/// <c>AdjustTokenPrivileges</c> function.
		/// </para>
		/// <para>Examples</para>
		/// <para>For an example that uses this function, see Enabling and Disabling Privileges.</para>
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows/desktop/api/securitybaseapi/nf-securitybaseapi-adjusttokenprivileges BOOL
		// AdjustTokenPrivileges( HANDLE TokenHandle, BOOL DisableAllPrivileges, PTOKEN_PRIVILEGES NewState, DWORD BufferLength,
		// PTOKEN_PRIVILEGES PreviousState, PDWORD ReturnLength );
		[DllImport(Lib.AdvApi32, SetLastError = true, ExactSpelling = true)]
		[PInvokeData("securitybaseapi.h", MSDNShortId = "8e3f70cd-814e-4aab-8f48-0ca482beef2e")]
		[return: MarshalAs(UnmanagedType.Bool)]
		public static extern bool AdjustTokenPrivileges([In] HTOKEN objectHandle, [In, MarshalAs(UnmanagedType.Bool)] bool DisableAllPrivileges,
			[MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef = typeof(PTOKEN_PRIVILEGES.Marshaler))] PTOKEN_PRIVILEGES NewState,
			[In] uint BufferLength, [In, Out] IntPtr PreviousState, out uint ReturnLength);

		/// <summary>
		/// The <c>AdjustTokenPrivileges</c> function enables or disables privileges in the specified access token. Enabling or disabling
		/// privileges in an access token requires TOKEN_ADJUST_PRIVILEGES access.
		/// </summary>
		/// <param name="TokenHandle">
		/// A handle to the access token that contains the privileges to be modified. The handle must have TOKEN_ADJUST_PRIVILEGES access to
		/// the token. If the PreviousState parameter is not <c>NULL</c>, the handle must also have TOKEN_QUERY access.
		/// </param>
		/// <param name="DisableAllPrivileges">
		/// Specifies whether the function disables all of the token's privileges. If this value is <c>TRUE</c>, the function disables all
		/// privileges and ignores the NewState parameter. If it is <c>FALSE</c>, the function modifies privileges based on the information
		/// pointed to by the NewState parameter.
		/// </param>
		/// <param name="NewState">
		/// <para>
		/// A pointer to a TOKEN_PRIVILEGES structure that specifies an array of privileges and their attributes. If the DisableAllPrivileges
		/// parameter is <c>FALSE</c>, the <c>AdjustTokenPrivileges</c> function enables, disables, or removes these privileges for the
		/// token. The following table describes the action taken by the <c>AdjustTokenPrivileges</c> function, based on the privilege attribute.
		/// </para>
		/// <list type="table">
		/// <listheader>
		/// <term>Value</term>
		/// <term>Meaning</term>
		/// </listheader>
		/// <item>
		/// <term>SE_PRIVILEGE_ENABLED</term>
		/// <term>The function enables the privilege.</term>
		/// </item>
		/// <item>
		/// <term>SE_PRIVILEGE_REMOVED</term>
		/// <term>
		/// The privilege is removed from the list of privileges in the token. The other privileges in the list are reordered to remain
		/// contiguous. SE_PRIVILEGE_REMOVED supersedes SE_PRIVILEGE_ENABLED. Because the privilege has been removed from the token, attempts
		/// to reenable the privilege result in the warning ERROR_NOT_ALL_ASSIGNED as if the privilege had never existed. Attempting to
		/// remove a privilege that does not exist in the token results in ERROR_NOT_ALL_ASSIGNED being returned. Privilege checks for
		/// removed privileges result in STATUS_PRIVILEGE_NOT_HELD. Failed privilege check auditing occurs as normal. The removal of the
		/// privilege is irreversible, so the name of the removed privilege is not included in the PreviousState parameter after a call to
		/// AdjustTokenPrivileges. Windows XP with SP1: The function cannot remove privileges. This value is not supported.
		/// </term>
		/// </item>
		/// <item>
		/// <term>None</term>
		/// <term>The function disables the privilege.</term>
		/// </item>
		/// </list>
		/// <para>If DisableAllPrivileges is <c>TRUE</c>, the function ignores this parameter.</para>
		/// </param>
		/// <param name="BufferLength">
		/// Specifies the size, in bytes, of the buffer pointed to by the PreviousState parameter. This parameter can be zero if the
		/// PreviousState parameter is <c>NULL</c>.
		/// </param>
		/// <param name="PreviousState">
		/// <para>
		/// A pointer to a buffer that the function fills with a TOKEN_PRIVILEGES structure that contains the previous state of any
		/// privileges that the function modifies. That is, if a privilege has been modified by this function, the privilege and its previous
		/// state are contained in the <c>TOKEN_PRIVILEGES</c> structure referenced by PreviousState. If the <c>PrivilegeCount</c> member of
		/// <c>TOKEN_PRIVILEGES</c> is zero, then no privileges have been changed by this function. This parameter can be <c>NULL</c>.
		/// </para>
		/// <para>
		/// If you specify a buffer that is too small to receive the complete list of modified privileges, the function fails and does not
		/// adjust any privileges. In this case, the function sets the variable pointed to by the ReturnLength parameter to the number of
		/// bytes required to hold the complete list of modified privileges.
		/// </para>
		/// </param>
		/// <param name="ReturnLength">
		/// A pointer to a variable that receives the required size, in bytes, of the buffer pointed to by the PreviousState parameter. This
		/// parameter can be <c>NULL</c> if PreviousState is <c>NULL</c>.
		/// </param>
		/// <returns>
		/// <para>
		/// If the function succeeds, the return value is nonzero. To determine whether the function adjusted all of the specified
		/// privileges, call GetLastError, which returns one of the following values when the function succeeds:
		/// </para>
		/// <list type="table">
		/// <listheader>
		/// <term>Return code</term>
		/// <term>Description</term>
		/// </listheader>
		/// <item>
		/// <term>ERROR_SUCCESS</term>
		/// <term>The function adjusted all specified privileges.</term>
		/// </item>
		/// <item>
		/// <term>ERROR_NOT_ALL_ASSIGNED</term>
		/// <term>
		/// The token does not have one or more of the privileges specified in the NewState parameter. The function may succeed with this
		/// error value even if no privileges were adjusted. The PreviousState parameter indicates the privileges that were adjusted.
		/// </term>
		/// </item>
		/// </list>
		/// <para>If the function fails, the return value is zero. To get extended error information, call GetLastError.</para>
		/// </returns>
		/// <remarks>
		/// <para>
		/// The <c>AdjustTokenPrivileges</c> function cannot add new privileges to the access token. It can only enable or disable the
		/// token's existing privileges. To determine the token's privileges, call the GetTokenInformation function.
		/// </para>
		/// <para>
		/// The NewState parameter can specify privileges that the token does not have, without causing the function to fail. In this case,
		/// the function adjusts the privileges that the token does have and ignores the other privileges so that the function succeeds. Call
		/// the GetLastError function to determine whether the function adjusted all of the specified privileges. The PreviousState parameter
		/// indicates the privileges that were adjusted.
		/// </para>
		/// <para>
		/// The PreviousState parameter retrieves a TOKEN_PRIVILEGES structure that contains the original state of the adjusted privileges.
		/// To restore the original state, pass the PreviousState pointer as the NewState parameter in a subsequent call to the
		/// <c>AdjustTokenPrivileges</c> function.
		/// </para>
		/// <para>Examples</para>
		/// <para>For an example that uses this function, see Enabling and Disabling Privileges.</para>
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows/desktop/api/securitybaseapi/nf-securitybaseapi-adjusttokenprivileges BOOL
		// AdjustTokenPrivileges( HANDLE TokenHandle, BOOL DisableAllPrivileges, PTOKEN_PRIVILEGES NewState, DWORD BufferLength,
		// PTOKEN_PRIVILEGES PreviousState, PDWORD ReturnLength );
		[DllImport(Lib.AdvApi32, SetLastError = true, ExactSpelling = true)]
		[PInvokeData("securitybaseapi.h", MSDNShortId = "8e3f70cd-814e-4aab-8f48-0ca482beef2e")]
		[return: MarshalAs(UnmanagedType.Bool)]
		public static extern bool AdjustTokenPrivileges([In] HTOKEN objectHandle, [In, MarshalAs(UnmanagedType.Bool)] bool DisableAllPrivileges,
			[In] IntPtr NewState, [In] uint BufferLength, [In, Out] IntPtr PreviousState, out uint ReturnLength);

		/// <summary>
		/// The <c>AdjustTokenPrivileges</c> function enables or disables privileges in the specified access token. Enabling or disabling
		/// privileges in an access token requires TOKEN_ADJUST_PRIVILEGES access.
		/// </summary>
		/// <param name="TokenHandle">
		/// A handle to the access token that contains the privileges to be modified. The handle must have TOKEN_ADJUST_PRIVILEGES access to
		/// the token. If the PreviousState parameter is not <c>NULL</c>, the handle must also have TOKEN_QUERY access.
		/// </param>
		/// <param name="DisableAllPrivileges">
		/// Specifies whether the function disables all of the token's privileges. If this value is <c>TRUE</c>, the function disables all
		/// privileges and ignores the NewState parameter. If it is <c>FALSE</c>, the function modifies privileges based on the information
		/// pointed to by the NewState parameter.
		/// </param>
		/// <param name="NewState">
		/// <para>
		/// A pointer to a TOKEN_PRIVILEGES structure that specifies an array of privileges and their attributes. If the DisableAllPrivileges
		/// parameter is <c>FALSE</c>, the <c>AdjustTokenPrivileges</c> function enables, disables, or removes these privileges for the
		/// token. The following table describes the action taken by the <c>AdjustTokenPrivileges</c> function, based on the privilege attribute.
		/// </para>
		/// <list type="table">
		/// <listheader>
		/// <term>Value</term>
		/// <term>Meaning</term>
		/// </listheader>
		/// <item>
		/// <term>SE_PRIVILEGE_ENABLED</term>
		/// <term>The function enables the privilege.</term>
		/// </item>
		/// <item>
		/// <term>SE_PRIVILEGE_REMOVED</term>
		/// <term>
		/// The privilege is removed from the list of privileges in the token. The other privileges in the list are reordered to remain
		/// contiguous. SE_PRIVILEGE_REMOVED supersedes SE_PRIVILEGE_ENABLED. Because the privilege has been removed from the token, attempts
		/// to reenable the privilege result in the warning ERROR_NOT_ALL_ASSIGNED as if the privilege had never existed. Attempting to
		/// remove a privilege that does not exist in the token results in ERROR_NOT_ALL_ASSIGNED being returned. Privilege checks for
		/// removed privileges result in STATUS_PRIVILEGE_NOT_HELD. Failed privilege check auditing occurs as normal. The removal of the
		/// privilege is irreversible, so the name of the removed privilege is not included in the PreviousState parameter after a call to
		/// AdjustTokenPrivileges. Windows XP with SP1: The function cannot remove privileges. This value is not supported.
		/// </term>
		/// </item>
		/// <item>
		/// <term>None</term>
		/// <term>The function disables the privilege.</term>
		/// </item>
		/// </list>
		/// <para>If DisableAllPrivileges is <c>TRUE</c>, the function ignores this parameter.</para>
		/// </param>
		/// <param name="BufferLength">
		/// Specifies the size, in bytes, of the buffer pointed to by the PreviousState parameter. This parameter can be zero if the
		/// PreviousState parameter is <c>NULL</c>.
		/// </param>
		/// <param name="PreviousState">
		/// <para>
		/// A pointer to a buffer that the function fills with a TOKEN_PRIVILEGES structure that contains the previous state of any
		/// privileges that the function modifies. That is, if a privilege has been modified by this function, the privilege and its previous
		/// state are contained in the <c>TOKEN_PRIVILEGES</c> structure referenced by PreviousState. If the <c>PrivilegeCount</c> member of
		/// <c>TOKEN_PRIVILEGES</c> is zero, then no privileges have been changed by this function. This parameter can be <c>NULL</c>.
		/// </para>
		/// <para>
		/// If you specify a buffer that is too small to receive the complete list of modified privileges, the function fails and does not
		/// adjust any privileges. In this case, the function sets the variable pointed to by the ReturnLength parameter to the number of
		/// bytes required to hold the complete list of modified privileges.
		/// </para>
		/// </param>
		/// <param name="ReturnLength">
		/// A pointer to a variable that receives the required size, in bytes, of the buffer pointed to by the PreviousState parameter. This
		/// parameter can be <c>NULL</c> if PreviousState is <c>NULL</c>.
		/// </param>
		/// <returns>
		/// <para>
		/// If the function succeeds, the return value is nonzero. To determine whether the function adjusted all of the specified
		/// privileges, call GetLastError, which returns one of the following values when the function succeeds:
		/// </para>
		/// <list type="table">
		/// <listheader>
		/// <term>Return code</term>
		/// <term>Description</term>
		/// </listheader>
		/// <item>
		/// <term>ERROR_SUCCESS</term>
		/// <term>The function adjusted all specified privileges.</term>
		/// </item>
		/// <item>
		/// <term>ERROR_NOT_ALL_ASSIGNED</term>
		/// <term>
		/// The token does not have one or more of the privileges specified in the NewState parameter. The function may succeed with this
		/// error value even if no privileges were adjusted. The PreviousState parameter indicates the privileges that were adjusted.
		/// </term>
		/// </item>
		/// </list>
		/// <para>If the function fails, the return value is zero. To get extended error information, call GetLastError.</para>
		/// </returns>
		/// <remarks>
		/// <para>
		/// The <c>AdjustTokenPrivileges</c> function cannot add new privileges to the access token. It can only enable or disable the
		/// token's existing privileges. To determine the token's privileges, call the GetTokenInformation function.
		/// </para>
		/// <para>
		/// The NewState parameter can specify privileges that the token does not have, without causing the function to fail. In this case,
		/// the function adjusts the privileges that the token does have and ignores the other privileges so that the function succeeds. Call
		/// the GetLastError function to determine whether the function adjusted all of the specified privileges. The PreviousState parameter
		/// indicates the privileges that were adjusted.
		/// </para>
		/// <para>
		/// The PreviousState parameter retrieves a TOKEN_PRIVILEGES structure that contains the original state of the adjusted privileges.
		/// To restore the original state, pass the PreviousState pointer as the NewState parameter in a subsequent call to the
		/// <c>AdjustTokenPrivileges</c> function.
		/// </para>
		/// <para>Examples</para>
		/// <para>For an example that uses this function, see Enabling and Disabling Privileges.</para>
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows/desktop/api/securitybaseapi/nf-securitybaseapi-adjusttokenprivileges BOOL
		// AdjustTokenPrivileges( HANDLE TokenHandle, BOOL DisableAllPrivileges, PTOKEN_PRIVILEGES NewState, DWORD BufferLength,
		// PTOKEN_PRIVILEGES PreviousState, PDWORD ReturnLength );
		[DllImport(Lib.AdvApi32, SetLastError = true, ExactSpelling = true)]
		[PInvokeData("securitybaseapi.h", MSDNShortId = "8e3f70cd-814e-4aab-8f48-0ca482beef2e")]
		[return: MarshalAs(UnmanagedType.Bool)]
		public static extern bool AdjustTokenPrivileges([In] HTOKEN objectHandle, [In, MarshalAs(UnmanagedType.Bool)] bool DisableAllPrivileges,
			[MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef = typeof(PTOKEN_PRIVILEGES.Marshaler))] PTOKEN_PRIVILEGES NewState,
			[In] uint BufferLength = 0, IntPtr PreviousState = default, IntPtr ReturnLength = default);

		/// <summary>
		/// The <c>AdjustTokenPrivileges</c> function enables or disables privileges in the specified access token. Enabling or disabling
		/// privileges in an access token requires TOKEN_ADJUST_PRIVILEGES access.
		/// </summary>
		/// <param name="TokenHandle">
		/// A handle to the access token that contains the privileges to be modified. The handle must have TOKEN_ADJUST_PRIVILEGES access to
		/// the token. If the PreviousState parameter is not <c>NULL</c>, the handle must also have TOKEN_QUERY access.
		/// </param>
		/// <param name="DisableAllPrivileges">
		/// Specifies whether the function disables all of the token's privileges. If this value is <c>TRUE</c>, the function disables all
		/// privileges and ignores the NewState parameter. If it is <c>FALSE</c>, the function modifies privileges based on the information
		/// pointed to by the NewState parameter.
		/// </param>
		/// <param name="NewState">
		/// <para>
		/// A pointer to a TOKEN_PRIVILEGES structure that specifies an array of privileges and their attributes. If the DisableAllPrivileges
		/// parameter is <c>FALSE</c>, the <c>AdjustTokenPrivileges</c> function enables, disables, or removes these privileges for the
		/// token. The following table describes the action taken by the <c>AdjustTokenPrivileges</c> function, based on the privilege attribute.
		/// </para>
		/// <list type="table">
		/// <listheader>
		/// <term>Value</term>
		/// <term>Meaning</term>
		/// </listheader>
		/// <item>
		/// <term>SE_PRIVILEGE_ENABLED</term>
		/// <term>The function enables the privilege.</term>
		/// </item>
		/// <item>
		/// <term>SE_PRIVILEGE_REMOVED</term>
		/// <term>
		/// The privilege is removed from the list of privileges in the token. The other privileges in the list are reordered to remain
		/// contiguous. SE_PRIVILEGE_REMOVED supersedes SE_PRIVILEGE_ENABLED. Because the privilege has been removed from the token, attempts
		/// to reenable the privilege result in the warning ERROR_NOT_ALL_ASSIGNED as if the privilege had never existed. Attempting to
		/// remove a privilege that does not exist in the token results in ERROR_NOT_ALL_ASSIGNED being returned. Privilege checks for
		/// removed privileges result in STATUS_PRIVILEGE_NOT_HELD. Failed privilege check auditing occurs as normal. The removal of the
		/// privilege is irreversible, so the name of the removed privilege is not included in the PreviousState parameter after a call to
		/// AdjustTokenPrivileges. Windows XP with SP1: The function cannot remove privileges. This value is not supported.
		/// </term>
		/// </item>
		/// <item>
		/// <term>None</term>
		/// <term>The function disables the privilege.</term>
		/// </item>
		/// </list>
		/// <para>If DisableAllPrivileges is <c>TRUE</c>, the function ignores this parameter.</para>
		/// </param>
		/// <param name="BufferLength">
		/// Specifies the size, in bytes, of the buffer pointed to by the PreviousState parameter. This parameter can be zero if the
		/// PreviousState parameter is <c>NULL</c>.
		/// </param>
		/// <param name="PreviousState">
		/// <para>
		/// A pointer to a buffer that the function fills with a TOKEN_PRIVILEGES structure that contains the previous state of any
		/// privileges that the function modifies. That is, if a privilege has been modified by this function, the privilege and its previous
		/// state are contained in the <c>TOKEN_PRIVILEGES</c> structure referenced by PreviousState. If the <c>PrivilegeCount</c> member of
		/// <c>TOKEN_PRIVILEGES</c> is zero, then no privileges have been changed by this function. This parameter can be <c>NULL</c>.
		/// </para>
		/// <para>
		/// If you specify a buffer that is too small to receive the complete list of modified privileges, the function fails and does not
		/// adjust any privileges. In this case, the function sets the variable pointed to by the ReturnLength parameter to the number of
		/// bytes required to hold the complete list of modified privileges.
		/// </para>
		/// </param>
		/// <param name="ReturnLength">
		/// A pointer to a variable that receives the required size, in bytes, of the buffer pointed to by the PreviousState parameter. This
		/// parameter can be <c>NULL</c> if PreviousState is <c>NULL</c>.
		/// </param>
		/// <returns>
		/// <para>
		/// If the function succeeds, the return value is nonzero. To determine whether the function adjusted all of the specified
		/// privileges, call GetLastError, which returns one of the following values when the function succeeds:
		/// </para>
		/// <list type="table">
		/// <listheader>
		/// <term>Return code</term>
		/// <term>Description</term>
		/// </listheader>
		/// <item>
		/// <term>ERROR_SUCCESS</term>
		/// <term>The function adjusted all specified privileges.</term>
		/// </item>
		/// <item>
		/// <term>ERROR_NOT_ALL_ASSIGNED</term>
		/// <term>
		/// The token does not have one or more of the privileges specified in the NewState parameter. The function may succeed with this
		/// error value even if no privileges were adjusted. The PreviousState parameter indicates the privileges that were adjusted.
		/// </term>
		/// </item>
		/// </list>
		/// <para>If the function fails, the return value is zero. To get extended error information, call GetLastError.</para>
		/// </returns>
		/// <remarks>
		/// <para>
		/// The <c>AdjustTokenPrivileges</c> function cannot add new privileges to the access token. It can only enable or disable the
		/// token's existing privileges. To determine the token's privileges, call the GetTokenInformation function.
		/// </para>
		/// <para>
		/// The NewState parameter can specify privileges that the token does not have, without causing the function to fail. In this case,
		/// the function adjusts the privileges that the token does have and ignores the other privileges so that the function succeeds. Call
		/// the GetLastError function to determine whether the function adjusted all of the specified privileges. The PreviousState parameter
		/// indicates the privileges that were adjusted.
		/// </para>
		/// <para>
		/// The PreviousState parameter retrieves a TOKEN_PRIVILEGES structure that contains the original state of the adjusted privileges.
		/// To restore the original state, pass the PreviousState pointer as the NewState parameter in a subsequent call to the
		/// <c>AdjustTokenPrivileges</c> function.
		/// </para>
		/// <para>Examples</para>
		/// <para>For an example that uses this function, see Enabling and Disabling Privileges.</para>
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows/desktop/api/securitybaseapi/nf-securitybaseapi-adjusttokenprivileges BOOL
		// AdjustTokenPrivileges( HANDLE TokenHandle, BOOL DisableAllPrivileges, PTOKEN_PRIVILEGES NewState, DWORD BufferLength,
		// PTOKEN_PRIVILEGES PreviousState, PDWORD ReturnLength );
		[DllImport(Lib.AdvApi32, SetLastError = true, ExactSpelling = true)]
		[PInvokeData("securitybaseapi.h", MSDNShortId = "8e3f70cd-814e-4aab-8f48-0ca482beef2e")]
		[return: MarshalAs(UnmanagedType.Bool)]
		public static extern bool AdjustTokenPrivileges([In] HTOKEN objectHandle, [In, MarshalAs(UnmanagedType.Bool)] bool DisableAllPrivileges,
			[In] IntPtr NewState, [In] uint BufferLength = 0, IntPtr PreviousState = default, IntPtr ReturnLength = default);

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

		/// <summary>
		/// The <c>AreAllAccessesGranted</c> function checks whether a set of requested access rights has been granted. The access rights are
		/// represented as bit flags in an access mask.
		/// </summary>
		/// <param name="GrantedAccess">An access mask that specifies the access rights that have been granted.</param>
		/// <param name="DesiredAccess">
		/// An access mask that specifies the access rights that have been requested. This mask must have been mapped from generic to
		/// specific and standard access rights, usually by calling the MapGenericMask function.
		/// </param>
		/// <returns>
		/// <para>If all requested access rights have been granted, the return value is nonzero.</para>
		/// <para>If not all requested access rights have been granted, the return value is zero.</para>
		/// </returns>
		/// <remarks>
		/// The <c>AreAllAccessesGranted</c> function is commonly used by a server application to check the access rights of a client
		/// attempting to gain access to an object. When the bits set in the DesiredAccess parameter match the bits set in the GrantedAccess
		/// parameter, all requested rights have been granted.
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows/desktop/api/securitybaseapi/nf-securitybaseapi-areallaccessesgranted BOOL
		// AreAllAccessesGranted( DWORD GrantedAccess, DWORD DesiredAccess );
		[DllImport(Lib.AdvApi32, SetLastError = false, ExactSpelling = true)]
		[PInvokeData("securitybaseapi.h", MSDNShortId = "91349693-8667-49dd-a813-657497b7d467")]
		[return: MarshalAs(UnmanagedType.Bool)]
		public static extern bool AreAllAccessesGranted(uint GrantedAccess, ACCESS_MASK DesiredAccess);

		/// <summary>
		/// The <c>AreAnyAccessesGranted</c> function tests whether any of a set of requested access rights has been granted. The access
		/// rights are represented as bit flags in an access mask.
		/// </summary>
		/// <param name="GrantedAccess">Specifies the granted access mask.</param>
		/// <param name="DesiredAccess">
		/// Specifies the access mask to be requested. This mask must have been mapped from generic to specific and standard access rights,
		/// usually by calling the MapGenericMask function.
		/// </param>
		/// <returns>
		/// <para>If any of the requested access rights have been granted, the return value is nonzero.</para>
		/// <para>If none of the requested access rights have been granted, the return value is zero.</para>
		/// </returns>
		/// <remarks>
		/// The <c>AreAnyAccessesGranted</c> function is often used by a server application to check the access rights of a client attempting
		/// to gain access to an object. When any of the bits set in the DesiredAccess parameter match the bits set in the GrantedAccess
		/// parameter, at least one of the requested access rights has been granted.
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows/desktop/api/securitybaseapi/nf-securitybaseapi-areanyaccessesgranted BOOL
		// AreAnyAccessesGranted( DWORD GrantedAccess, DWORD DesiredAccess );
		[DllImport(Lib.AdvApi32, SetLastError = false, ExactSpelling = true)]
		[PInvokeData("securitybaseapi.h", MSDNShortId = "4bac6ebc-716a-4725-b9e6-a109b27dfc18")]
		[return: MarshalAs(UnmanagedType.Bool)]
		public static extern bool AreAnyAccessesGranted(uint GrantedAccess, ACCESS_MASK DesiredAccess);

		/// <summary>The <c>CheckTokenCapability</c> function checks the capabilities of a given token.</summary>
		/// <param name="TokenHandle">
		/// <para>
		/// A handle to an access token. The handle must have TOKEN_QUERY access to the token. The token must be an impersonation token.
		/// </para>
		/// <para>
		/// If TokenHandle is <c>NULL</c>, <c>CheckTokenCapability</c> uses the impersonation token of the calling thread. If the thread is
		/// not impersonating, the function duplicates the thread's primary token to create an impersonation token.
		/// </para>
		/// </param>
		/// <param name="CapabilitySidToCheck">
		/// A pointer to a capability SID structure. The <c>CheckTokenCapability</c> function checks the capabilities of this access token.
		/// </param>
		/// <param name="HasCapability">
		/// Receives the results of the check. If the access token has the capability, it returns <c>TRUE</c>, otherwise, it returns <c>FALSE</c>.
		/// </param>
		/// <returns>
		/// <para>If the function succeeds, the return value is nonzero.</para>
		/// <para>If the function fails, the return value is zero. To get extended error information, call GetLastError</para>
		/// </returns>
		// https://docs.microsoft.com/en-us/windows/desktop/api/securitybaseapi/nf-securitybaseapi-checktokencapability BOOL
		// CheckTokenCapability( HANDLE TokenHandle, PSID CapabilitySidToCheck, PBOOL HasCapability );
		[DllImport(Lib.Kernel32, SetLastError = true, ExactSpelling = true)]
		[PInvokeData("securitybaseapi.h", MSDNShortId = "436A5110-B79E-4E64-92E8-1C9E713D0948")]
		[return: MarshalAs(UnmanagedType.Bool)]
		public static extern bool CheckTokenCapability(HTOKEN TokenHandle, PSID CapabilitySidToCheck, [MarshalAs(UnmanagedType.Bool)] out bool HasCapability);

		/// <summary>
		/// The <c>CheckTokenMembership</c> function determines whether a specified security identifier (SID) is enabled in an access token.
		/// If you want to determine group membership for app container tokens, you need to use the CheckTokenMembershipEx function.
		/// </summary>
		/// <param name="TokenHandle">
		/// <para>
		/// A handle to an access token. The handle must have TOKEN_QUERY access to the token. The token must be an impersonation token.
		/// </para>
		/// <para>
		/// If TokenHandle is <c>NULL</c>, <c>CheckTokenMembership</c> uses the impersonation token of the calling thread. If the thread is
		/// not impersonating, the function duplicates the thread's primary token to create an impersonation token.
		/// </para>
		/// </param>
		/// <param name="SidToCheck">
		/// A pointer to a SID structure. The <c>CheckTokenMembership</c> function checks for the presence of this SID in the user and group
		/// SIDs of the access token.
		/// </param>
		/// <param name="IsMember">
		/// A pointer to a variable that receives the results of the check. If the SID is present and has the SE_GROUP_ENABLED attribute,
		/// IsMember returns <c>TRUE</c>; otherwise, it returns <c>FALSE</c>.
		/// </param>
		/// <returns>
		/// <para>If the function succeeds, the return value is nonzero.</para>
		/// <para>If the function fails, the return value is zero. To get extended error information, call GetLastError.</para>
		/// </returns>
		/// <remarks>
		/// <para>
		/// The <c>CheckTokenMembership</c> function simplifies the process of determining whether a SID is both present and enabled in an
		/// access token.
		/// </para>
		/// <para>
		/// Even if a SID is present in the token, the system may not use the SID in an access check. The SID may be disabled or have the
		/// <c>SE_GROUP_USE_FOR_DENY_ONLY</c> attribute. The system uses only enabled SIDs to grant access when performing an access check.
		/// For more information, see SID Attributes in an Access Token.
		/// </para>
		/// <para>
		/// If TokenHandle is a restricted token, or if TokenHandle is <c>NULL</c> and the current effective token of the calling thread is a
		/// restricted token, <c>CheckTokenMembership</c> also checks whether the SID is present in the list of restricting SIDs.
		/// </para>
		/// <para>Examples</para>
		/// <para>The following example shows checking a token for membership in the Administrators local group.</para>
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows/desktop/api/securitybaseapi/nf-securitybaseapi-checktokenmembership BOOL
		// CheckTokenMembership( HANDLE TokenHandle, PSID SidToCheck, PBOOL IsMember );
		[DllImport(Lib.AdvApi32, SetLastError = true, ExactSpelling = true)]
		[PInvokeData("securitybaseapi.h", MSDNShortId = "c254a167-c4e7-4b84-9be3-6862761309f8")]
		[return: MarshalAs(UnmanagedType.Bool)]
		public static extern bool CheckTokenMembership(HTOKEN TokenHandle, PSID SidToCheck, [MarshalAs(UnmanagedType.Bool)] out bool IsMember);

		/// <summary>The <c>CheckTokenMembershipEx</c> function determines whether the specified SID is enabled in the specified token.</summary>
		/// <param name="TokenHandle">
		/// A handle to an access token. If present, this token is checked for the SID. If not present, then the current effective token is
		/// used. This must be an impersonation token.
		/// </param>
		/// <param name="SidToCheck">
		/// A pointer to a SID structure. The function checks for the presence of this SID in the presence of the token.
		/// </param>
		/// <param name="Flags">
		/// Flags that affect the behavior of the function. Currently the only valid flag is CTMF_INCLUDE_APPCONTAINER which allows app
		/// containers to pass the call as long as the other requirements of the token are met, such as the group specified is present and enabled.
		/// </param>
		/// <param name="IsMember"><c>TRUE</c> if the SID is enabled in the token; otherwise, <c>FALSE</c>.</param>
		/// <returns>
		/// <para>If the function succeeds, it returns <c>TRUE</c>.</para>
		/// <para>If the function fails, it returns zero. To get extended error information, call GetLastError.</para>
		/// </returns>
		// https://docs.microsoft.com/en-us/windows/desktop/api/securitybaseapi/nf-securitybaseapi-checktokenmembershipex BOOL
		// CheckTokenMembershipEx( HANDLE TokenHandle, PSID SidToCheck, DWORD Flags, PBOOL IsMember );
		[DllImport(Lib.Kernel32, SetLastError = true, ExactSpelling = true)]
		[PInvokeData("securitybaseapi.h", MSDNShortId = "0420FC77-8035-42A5-8907-83D0CE53FB64")]
		[return: MarshalAs(UnmanagedType.Bool)]
		public static extern bool CheckTokenMembershipEx(HTOKEN TokenHandle, PSID SidToCheck, CTMF Flags, [MarshalAs(UnmanagedType.Bool)] out bool IsMember);

		/// <summary>
		/// The <c>ConvertToAutoInheritPrivateObjectSecurity</c> function converts a security descriptor and its access control lists (ACLs)
		/// to a format that supports automatic propagation of inheritable access control entries (ACEs).
		/// </summary>
		/// <param name="ParentDescriptor">
		/// A pointer to the security descriptor for the parent container of the object. If there is no parent container, this parameter is <c>NULL</c>.
		/// </param>
		/// <param name="CurrentSecurityDescriptor">A pointer to the current security descriptor of the object.</param>
		/// <param name="NewSecurityDescriptor">
		/// A pointer to a variable that receives a pointer to the newly allocated self-relative security descriptor. It is the caller's
		/// responsibility to call the DestroyPrivateObjectSecurity function to free this security descriptor.
		/// </param>
		/// <param name="ObjectType">
		/// A pointer to a GUID structure that identifies the type of object associated with the CurrentSecurityDescriptor parameter. If the
		/// object does not have a GUID, this parameter must be <c>NULL</c>.
		/// </param>
		/// <param name="IsDirectoryObject">
		/// If <c>TRUE</c>, the new object is a container and can contain other objects. If <c>FALSE</c>, the new object is not a container.
		/// </param>
		/// <param name="GenericMapping">
		/// A pointer to a GENERIC_MAPPING structure that specifies the mapping from each generic right to specific rights for the object.
		/// </param>
		/// <returns>
		/// <para>If the function succeeds, the function returns nonzero.</para>
		/// <para>If the function fails, it returns zero. To get extended error information, call GetLastError.</para>
		/// </returns>
		/// <remarks>
		/// <para>
		/// The <c>ConvertToAutoInheritPrivateObjectSecurity</c> function attempts to determine whether the ACEs in the discretionary access
		/// control list (DACL) and system access control list (SACL) of the current security descriptor were inherited from the parent
		/// security descriptor. The function passes the ParentDescriptor parameter to the CreatePrivateObjectSecurityEx function to get ACLs
		/// that contain only inherited ACEs. Then it compares these ACEs to the ACEs in the original security descriptor to determine which
		/// of the original ACEs were inherited. The ACEs do not need to match one-to-one. For instance, an ACE that allows read and write
		/// access to a trustee can be equivalent to two ACEs: an ACE that allows read access and an ACE that allows write access.
		/// </para>
		/// <para>
		/// Any ACEs in the original security descriptor that are equivalent to the ACEs inherited from the parent security descriptor are
		/// marked with the INHERITED_ACE flag and added to the new security descriptor. All other ACEs in the original security descriptor
		/// are added to the new security descriptor as noninherited ACEs.
		/// </para>
		/// <para>
		/// If the original DACL does not have any inherited ACEs, the function sets the SE_DACL_PROTECTED flag in the control bits of the
		/// new security descriptor. Similarly, the SE_SACL_PROTECTED flag is set if none of the ACEs in the SACL is inherited.
		/// </para>
		/// <para>
		/// For DACLs that have inherited ACEs, the function reorders the ACEs into two groups. The first group has ACEs that were directly
		/// applied to the object. The second group has inherited ACEs. This ordering ensures that noninherited ACEs have precedence over
		/// inherited ACEs. For more information, see Order of ACEs in a DACL.
		/// </para>
		/// <para>
		/// The function sets the SE_DACL_AUTO_INHERITED and SE_SACL_AUTO_INHERITED flags in the control bits of the new security descriptor.
		/// </para>
		/// <para>
		/// The function does not change the ordering of access-allowed ACEs in relation to access-denied ACEs in the DACL because to do so
		/// would change the semantics of the resulting security descriptor. If the function cannot convert the DACL without changing the
		/// semantics, it leaves the DACL unchanged and sets the SE_DACL_PROTECTED flag.
		/// </para>
		/// <para>The new security descriptor has the same owner and primary group as the original security descriptor.</para>
		/// <para>
		/// The new security descriptor is equivalent to the original security descriptor, so the caller needs no access rights or privileges
		/// to update the security descriptor to the new format.
		/// </para>
		/// <para>This function works with ACL_REVISION and ACL_REVISION_DS ACLs.</para>
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows/desktop/api/securitybaseapi/nf-securitybaseapi-converttoautoinheritprivateobjectsecurity
		// BOOL ConvertToAutoInheritPrivateObjectSecurity( PSECURITY_DESCRIPTOR ParentDescriptor, PSECURITY_DESCRIPTOR
		// CurrentSecurityDescriptor, PSECURITY_DESCRIPTOR *NewSecurityDescriptor, GUID *ObjectType, BOOLEAN IsDirectoryObject,
		// PGENERIC_MAPPING GenericMapping );
		[DllImport(Lib.AdvApi32, SetLastError = true, ExactSpelling = true)]
		[PInvokeData("securitybaseapi.h", MSDNShortId = "eaaa5509-eff5-461d-843b-7ebbbe0dd58f")]
		[return: MarshalAs(UnmanagedType.Bool)]
		public static extern bool ConvertToAutoInheritPrivateObjectSecurity([In, Optional] PSECURITY_DESCRIPTOR ParentDescriptor, [In] PSECURITY_DESCRIPTOR CurrentSecurityDescriptor,
			out SafePrivateObjectSecurity NewSecurityDescriptor, in Guid ObjectType, [MarshalAs(UnmanagedType.U1)] bool IsDirectoryObject, in GENERIC_MAPPING GenericMapping);

		/// <summary>
		/// The <c>ConvertToAutoInheritPrivateObjectSecurity</c> function converts a security descriptor and its access control lists (ACLs)
		/// to a format that supports automatic propagation of inheritable access control entries (ACEs).
		/// </summary>
		/// <param name="ParentDescriptor">
		/// A pointer to the security descriptor for the parent container of the object. If there is no parent container, this parameter is <c>NULL</c>.
		/// </param>
		/// <param name="CurrentSecurityDescriptor">A pointer to the current security descriptor of the object.</param>
		/// <param name="NewSecurityDescriptor">
		/// A pointer to a variable that receives a pointer to the newly allocated self-relative security descriptor. It is the caller's
		/// responsibility to call the DestroyPrivateObjectSecurity function to free this security descriptor.
		/// </param>
		/// <param name="ObjectType">
		/// A pointer to a GUID structure that identifies the type of object associated with the CurrentSecurityDescriptor parameter. If the
		/// object does not have a GUID, this parameter must be <c>NULL</c>.
		/// </param>
		/// <param name="IsDirectoryObject">
		/// If <c>TRUE</c>, the new object is a container and can contain other objects. If <c>FALSE</c>, the new object is not a container.
		/// </param>
		/// <param name="GenericMapping">
		/// A pointer to a GENERIC_MAPPING structure that specifies the mapping from each generic right to specific rights for the object.
		/// </param>
		/// <returns>
		/// <para>If the function succeeds, the function returns nonzero.</para>
		/// <para>If the function fails, it returns zero. To get extended error information, call GetLastError.</para>
		/// </returns>
		/// <remarks>
		/// <para>
		/// The <c>ConvertToAutoInheritPrivateObjectSecurity</c> function attempts to determine whether the ACEs in the discretionary access
		/// control list (DACL) and system access control list (SACL) of the current security descriptor were inherited from the parent
		/// security descriptor. The function passes the ParentDescriptor parameter to the CreatePrivateObjectSecurityEx function to get ACLs
		/// that contain only inherited ACEs. Then it compares these ACEs to the ACEs in the original security descriptor to determine which
		/// of the original ACEs were inherited. The ACEs do not need to match one-to-one. For instance, an ACE that allows read and write
		/// access to a trustee can be equivalent to two ACEs: an ACE that allows read access and an ACE that allows write access.
		/// </para>
		/// <para>
		/// Any ACEs in the original security descriptor that are equivalent to the ACEs inherited from the parent security descriptor are
		/// marked with the INHERITED_ACE flag and added to the new security descriptor. All other ACEs in the original security descriptor
		/// are added to the new security descriptor as noninherited ACEs.
		/// </para>
		/// <para>
		/// If the original DACL does not have any inherited ACEs, the function sets the SE_DACL_PROTECTED flag in the control bits of the
		/// new security descriptor. Similarly, the SE_SACL_PROTECTED flag is set if none of the ACEs in the SACL is inherited.
		/// </para>
		/// <para>
		/// For DACLs that have inherited ACEs, the function reorders the ACEs into two groups. The first group has ACEs that were directly
		/// applied to the object. The second group has inherited ACEs. This ordering ensures that noninherited ACEs have precedence over
		/// inherited ACEs. For more information, see Order of ACEs in a DACL.
		/// </para>
		/// <para>
		/// The function sets the SE_DACL_AUTO_INHERITED and SE_SACL_AUTO_INHERITED flags in the control bits of the new security descriptor.
		/// </para>
		/// <para>
		/// The function does not change the ordering of access-allowed ACEs in relation to access-denied ACEs in the DACL because to do so
		/// would change the semantics of the resulting security descriptor. If the function cannot convert the DACL without changing the
		/// semantics, it leaves the DACL unchanged and sets the SE_DACL_PROTECTED flag.
		/// </para>
		/// <para>The new security descriptor has the same owner and primary group as the original security descriptor.</para>
		/// <para>
		/// The new security descriptor is equivalent to the original security descriptor, so the caller needs no access rights or privileges
		/// to update the security descriptor to the new format.
		/// </para>
		/// <para>This function works with ACL_REVISION and ACL_REVISION_DS ACLs.</para>
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows/desktop/api/securitybaseapi/nf-securitybaseapi-converttoautoinheritprivateobjectsecurity
		// BOOL ConvertToAutoInheritPrivateObjectSecurity( PSECURITY_DESCRIPTOR ParentDescriptor, PSECURITY_DESCRIPTOR
		// CurrentSecurityDescriptor, PSECURITY_DESCRIPTOR *NewSecurityDescriptor, GUID *ObjectType, BOOLEAN IsDirectoryObject,
		// PGENERIC_MAPPING GenericMapping );
		[DllImport(Lib.AdvApi32, SetLastError = true, ExactSpelling = true)]
		[PInvokeData("securitybaseapi.h", MSDNShortId = "eaaa5509-eff5-461d-843b-7ebbbe0dd58f")]
		[return: MarshalAs(UnmanagedType.Bool)]
		public static extern bool ConvertToAutoInheritPrivateObjectSecurity([In, Optional] PSECURITY_DESCRIPTOR ParentDescriptor, [In] PSECURITY_DESCRIPTOR CurrentSecurityDescriptor,
			out SafePrivateObjectSecurity NewSecurityDescriptor, [In, Optional] IntPtr ObjectType, [MarshalAs(UnmanagedType.U1)] bool IsDirectoryObject, in GENERIC_MAPPING GenericMapping);

		/// <summary>
		/// <para>
		/// The <c>CreatePrivateObjectSecurity</c> function allocates and initializes a self-relative security descriptor for a new private
		/// object. A protected server calls this function when it creates a new private object.
		/// </para>
		/// <para>
		/// To specify the object type GUID of the new object or control how access control entries (ACEs) are inherited, use the
		/// CreatePrivateObjectSecurityEx function.
		/// </para>
		/// </summary>
		/// <param name="ParentDescriptor">
		/// A pointer to the security descriptor for the parent directory in which a new object is being created. If there is no parent
		/// directory, this parameter can be <c>NULL</c>.
		/// </param>
		/// <param name="CreatorDescriptor">
		/// A pointer to a security descriptor provided by the creator of the object. If the object's creator does not explicitly pass
		/// security information for the new object, this parameter is intended to be <c>NULL</c>.
		/// </param>
		/// <param name="NewDescriptor">
		/// A pointer to a variable that receives a pointer to the newly allocated self-relative security descriptor. The caller must call
		/// the DestroyPrivateObjectSecurity function to free this security descriptor.
		/// </param>
		/// <param name="IsDirectoryObject">
		/// Specifies whether the new object is a container. A value of <c>TRUE</c> indicates the object contains other objects, such as a directory.
		/// </param>
		/// <param name="Token">
		/// <para>
		/// A handle to the access token for the client process on whose behalf the object is being created. If this is an impersonation
		/// token, it must be at SecurityIdentification level or higher. For a full description of the SecurityIdentification impersonation
		/// level, see the SECURITY_IMPERSONATION_LEVEL enumerated type.
		/// </para>
		/// <para>
		/// A client token is used to retrieve default security information for the new object, such as its default owner, primary group, and
		/// discretionary access control list. The token must be open for <c>TOKEN_QUERY</c> access.
		/// </para>
		/// <para>
		/// If all of the following conditions are true, then the handle must be opened for <c>TOKEN_DUPLICATE</c> access in addition to
		/// <c>TOKEN_QUERY</c> access.
		/// </para>
		/// <list type="bullet">
		/// <item>
		/// <term>The token handle refers to a primary token.</term>
		/// </item>
		/// <item>
		/// <term>The security descriptor of the token contains one or more ACEs with the <c>OwnerRights</c> SID.</term>
		/// </item>
		/// <item>
		/// <term>A security descriptor is specified for the CreatorDescriptor parameter.</term>
		/// </item>
		/// <item>
		/// <term>The caller of this function does not set the <c>SEF_AVOID_OWNER_RESTRICTION</c> flag in the AutoInheritFlags parameter.</term>
		/// </item>
		/// </list>
		/// </param>
		/// <param name="GenericMapping">
		/// A pointer to a GENERIC_MAPPING structure that specifies the mapping from each generic right to specific rights for the object.
		/// </param>
		/// <returns>
		/// <para>If the function succeeds, the function returns nonzero.</para>
		/// <para>If the function fails, it returns zero. To get extended error information, call GetLastError.</para>
		/// </returns>
		/// <remarks>
		/// If a system access control list (SACL) is specified in the SECURITY_DESCRIPTOR specified by the CreatorDescriptor parameter, the
		/// Token parameter must have the SE_SECURITY_NAME privilege enabled. The <c>CreatePrivateObjectSecurity</c> function checks this
		/// privilege and may generate audits during the process.
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows/desktop/api/securitybaseapi/nf-securitybaseapi-createprivateobjectsecurity BOOL
		// CreatePrivateObjectSecurity( PSECURITY_DESCRIPTOR ParentDescriptor, PSECURITY_DESCRIPTOR CreatorDescriptor, PSECURITY_DESCRIPTOR
		// *NewDescriptor, BOOL IsDirectoryObject, HANDLE Token, PGENERIC_MAPPING GenericMapping );
		[DllImport(Lib.AdvApi32, SetLastError = true, ExactSpelling = true)]
		[PInvokeData("securitybaseapi.h", MSDNShortId = "5f4832b6-5cf5-4050-9e20-56674f2e2cb1")]
		[return: MarshalAs(UnmanagedType.Bool)]
		public static extern bool CreatePrivateObjectSecurity([In, Optional] PSECURITY_DESCRIPTOR ParentDescriptor, [In, Optional] PSECURITY_DESCRIPTOR CreatorDescriptor, out SafePrivateObjectSecurity NewDescriptor,
			[MarshalAs(UnmanagedType.Bool)] bool IsDirectoryObject, [In, Optional] HTOKEN Token, in GENERIC_MAPPING GenericMapping);

		/// <summary>
		/// The <c>CreatePrivateObjectSecurityEx</c> function allocates and initializes a self-relative security descriptor for a new private
		/// object created by the resource manager calling this function.
		/// </summary>
		/// <param name="ParentDescriptor">
		/// A pointer to the security descriptor for the parent container of the object. If there is no parent container, this parameter is <c>NULL</c>.
		/// </param>
		/// <param name="CreatorDescriptor">
		/// A pointer to a security descriptor provided by the creator of the object. If the object's creator does not explicitly pass
		/// security information for the new object, this parameter can be <c>NULL</c>. Alternatively, this parameter can point to a default
		/// security descriptor.
		/// </param>
		/// <param name="NewDescriptor">
		/// A pointer to a variable that receives a pointer to the newly allocated self-relative security descriptor. When you have finished
		/// using the security descriptor, free it by calling the <c>DestroyPrivateObjectSecurity</c> function.
		/// </param>
		/// <param name="ObjectType">
		/// A pointer to a <c>GUID</c> structure that identifies the type of object associated with NewDescriptor. If the object does not
		/// have a GUID, set ObjectType to <c>NULL</c>.
		/// </param>
		/// <param name="IsContainerObject">
		/// Specifies whether the new object can contain other objects. A value of <c>TRUE</c> indicates that the new object is a container.
		/// A value of <c>FALSE</c> indicates that the new object is not a container.
		/// </param>
		/// <param name="AutoInheritFlags">
		/// <para>
		/// A set of bit flags that control how access control entries (ACEs) are inherited from ParentDescriptor. This parameter can be a
		/// combination of the following values.
		/// </para>
		/// <para>
		/// <list type="table">
		/// <listheader>
		/// <term>Value</term>
		/// <term>Meaning</term>
		/// </listheader>
		/// <item>
		/// <term>SEF_AVOID_OWNER_CHECK0x10</term>
		/// <term>
		/// The function does not check the validity of the owner in the resultant NewDescriptor as described in Remarks below. If the
		/// SEF_AVOID_PRIVILEGE_CHECK flag is also set, the Token parameter can be NULL.
		/// </term>
		/// </item>
		/// <item>
		/// <term>SEF_AVOID_OWNER_RESTRICTION0x1000</term>
		/// <term>
		/// Any restrictions specified by the ParentDescriptor that would limit the caller&amp;#39;s ability to specify a DACL in the
		/// CreatorDescriptor are ignored.
		/// </term>
		/// </item>
		/// <item>
		/// <term>SEF_AVOID_PRIVILEGE_CHECK0x08</term>
		/// <term>
		/// The function does not perform privilege checking. If the SEF_AVOID_OWNER_CHECK flag is also set, the Token parameter can be NULL.
		/// This flag is useful while implementing automatic inheritance to avoid checking privileges on each child updated.
		/// </term>
		/// </item>
		/// <item>
		/// <term>SEF_DACL_AUTO_INHERIT0x01</term>
		/// <term>
		/// The new discretionary access control list (DACL) contains ACEs inherited from the DACL of ParentDescriptor, as well as any
		/// explicit ACEs specified in the DACL of CreatorDescriptor. If this flag is not set, the new DACL does not inherit ACEs.
		/// </term>
		/// </item>
		/// <item>
		/// <term>SEF_DEFAULT_DESCRIPTOR_FOR_OBJECT0x04</term>
		/// <term>
		/// CreatorDescriptor is the default descriptor for the type of object specified by ObjectType. As such, CreatorDescriptor is ignored
		/// if ParentDescriptor has any object-specific ACEs for the type of object specified by the ObjectType parameter. If no such ACEs
		/// are inherited, CreatorDescriptor is handled as though this flag were not specified.
		/// </term>
		/// </item>
		/// <item>
		/// <term>SEF_DEFAULT_GROUP_FROM_PARENT0x40</term>
		/// <term>
		/// The group of NewDescriptor defaults to the group from ParentDescriptor. If not set, the group of NewDescriptor defaults to the
		/// group of the token specified by the Token parameter. The group of the token is specified in the token itself. In either case, if
		/// the CreatorDescriptor parameter is not NULL, the NewDescriptor group is set to the group from CreatorDescriptor.
		/// </term>
		/// </item>
		/// <item>
		/// <term>SEF_DEFAULT_OWNER_FROM_PARENT0x20</term>
		/// <term>
		/// The owner of NewDescriptor defaults to the owner from ParentDescriptor. If not set, the owner of NewDescriptor defaults to the
		/// owner of the token specified by the Token parameter. The owner of the token is specified in the token itself. In either case, if
		/// the CreatorDescriptor parameter is not NULL, the NewDescriptor owner is set to the owner from CreatorDescriptor.
		/// </term>
		/// </item>
		/// <item>
		/// <term>SEF_MACL_NO_EXECUTE_UP0x400</term>
		/// <term>
		/// When this flag is set, the mandatory label ACE in CreatorDescriptor is not used to create a mandatory label ACE in NewDescriptor.
		/// Instead, a new SYSTEM_MANDATORY_LABEL_ACE with an access mask of SYSTEM_MANDATORY_LABEL_NO_EXECUTE_UP and the SID from the
		/// token&amp;#39;s integrity SID is added to NewDescriptor.
		/// </term>
		/// </item>
		/// <item>
		/// <term>SEF_MACL_NO_READ_UP0x200</term>
		/// <term>
		/// When this flag is set, the mandatory label ACE in CreatorDescriptor is not used to create a mandatory label ACE in NewDescriptor.
		/// Instead, a new SYSTEM_MANDATORY_LABEL_ACE with an access mask of SYSTEM_MANDATORY_LABEL_NO_READ_UP and the SID from the
		/// token&amp;#39;s integrity SID is added to NewDescriptor.
		/// </term>
		/// </item>
		/// <item>
		/// <term>SEF_MACL_NO_WRITE_UP0x100</term>
		/// <term>
		/// When this flag is set, the mandatory label ACE in CreatorDescriptor is not used to create a mandatory label ACE in NewDescriptor.
		/// Instead, a new SYSTEM_MANDATORY_LABEL_ACE with an access mask of SYSTEM_MANDATORY_LABEL_NO_WRITE_UP and the SID from the
		/// token&amp;#39;s integrity SID is added to NewDescriptor.
		/// </term>
		/// </item>
		/// <item>
		/// <term>SEF_SACL_AUTO_INHERIT0x02</term>
		/// <term>
		/// The new system access control list (SACL) contains ACEs inherited from the SACL of ParentDescriptor, as well as any explicit ACEs
		/// specified in the SACL of CreatorDescriptor. If this flag is not set, the new SACL does not inherit ACEs.
		/// </term>
		/// </item>
		/// </list>
		/// </para>
		/// </param>
		/// <param name="Token">
		/// <para>
		/// A handle to the access token for the client process on whose behalf the object is being created. If this is an impersonation
		/// token, it must be at SecurityIdentification level or higher. For a full description of the SecurityIdentification impersonation
		/// level, see the <c>SECURITY_IMPERSONATION_LEVEL</c> enumerated type.
		/// </para>
		/// <para>
		/// The client token contains default security information, such as the default owner, primary group, and DACL. The function uses
		/// these defaults if the information is not in the input security descriptors. The token must be open for <c>TOKEN_QUERY</c> access.
		/// </para>
		/// <para>
		/// If all of the following conditions are true, then the handle must be opened for <c>TOKEN_DUPLICATE</c> access in addition to
		/// <c>TOKEN_QUERY</c> access.
		/// </para>
		/// </param>
		/// <param name="GenericMapping">
		/// A pointer to a <c>GENERIC_MAPPING</c> structure that specifies the mapping from each generic right to specific rights for the object.
		/// </param>
		/// <returns>
		/// <para>If the function succeeds, the function returns nonzero.</para>
		/// <para>
		/// If the function fails, it returns zero. To get extended error information, call <c>GetLastError</c>. Some of the extended error
		/// codes and their meanings are listed in the following table.
		/// </para>
		/// <para>
		/// <list type="table">
		/// <listheader>
		/// <term>Return code</term>
		/// <term>Description</term>
		/// </listheader>
		/// <item>
		/// <term>ERROR_INVALID_OWNER</term>
		/// <term>
		/// The function cannot retrieve an owner for the new security descriptor or the SID cannot be assigned as an owner. This occurs when
		/// validating the owner SID against the passed-in token.
		/// </term>
		/// </item>
		/// <item>
		/// <term>ERROR_INVALID_PRIMARY_GROUP</term>
		/// <term>The function cannot retrieve a primary group for the new security descriptor.</term>
		/// </item>
		/// <item>
		/// <term>ERROR_NO_TOKEN</term>
		/// <term>The function received NULL instead of a token for owner validation or privilege checking.</term>
		/// </item>
		/// <item>
		/// <term>ERROR_PRIVILEGE_NOT_HELD</term>
		/// <term>
		/// A SACL is being set, SEF_AVOID_PRIVILEGE_CHECK was not passed in, and the token passed in did not have SE_SECURITY_NAME enabled.
		/// </term>
		/// </item>
		/// </list>
		/// </para>
		/// </returns>
		// BOOL WINAPI CreatePrivateObjectSecurityEx( _In_opt_ PSECURITY_DESCRIPTOR ParentDescriptor, _In_opt_ PSECURITY_DESCRIPTOR
		// CreatorDescriptor, _Out_ PSECURITY_DESCRIPTOR *NewDescriptor, _In_opt_ GUID *ObjectType, _In_ BOOL IsContainerObject, _In_ ULONG
		// AutoInheritFlags, _In_opt_ HANDLE Token, _In_ PGENERIC_MAPPING GenericMapping); https://msdn.microsoft.com/en-us/library/windows/desktop/aa446581(v=vs.85).aspx
		[DllImport(Lib.AdvApi32, SetLastError = true, ExactSpelling = true)]
		[PInvokeData("Winbase.h", MSDNShortId = "aa446581")]
		[return: MarshalAs(UnmanagedType.Bool)]
		public static extern bool CreatePrivateObjectSecurityEx([In, Optional] PSECURITY_DESCRIPTOR ParentDescriptor, [In, Optional] PSECURITY_DESCRIPTOR CreatorDescriptor, out SafePrivateObjectSecurity NewDescriptor,
			in Guid ObjectType, [MarshalAs(UnmanagedType.Bool)] bool IsContainerObject, SEF AutoInheritFlags, [In, Optional] HTOKEN Token, in GENERIC_MAPPING GenericMapping);

		/// <summary>
		/// The <c>CreatePrivateObjectSecurityEx</c> function allocates and initializes a self-relative security descriptor for a new private
		/// object created by the resource manager calling this function.
		/// </summary>
		/// <param name="ParentDescriptor">
		/// A pointer to the security descriptor for the parent container of the object. If there is no parent container, this parameter is <c>NULL</c>.
		/// </param>
		/// <param name="CreatorDescriptor">
		/// A pointer to a security descriptor provided by the creator of the object. If the object's creator does not explicitly pass
		/// security information for the new object, this parameter can be <c>NULL</c>. Alternatively, this parameter can point to a default
		/// security descriptor.
		/// </param>
		/// <param name="NewDescriptor">
		/// A pointer to a variable that receives a pointer to the newly allocated self-relative security descriptor. When you have finished
		/// using the security descriptor, free it by calling the <c>DestroyPrivateObjectSecurity</c> function.
		/// </param>
		/// <param name="ObjectType">
		/// A pointer to a <c>GUID</c> structure that identifies the type of object associated with NewDescriptor. If the object does not
		/// have a GUID, set ObjectType to <c>NULL</c>.
		/// </param>
		/// <param name="IsContainerObject">
		/// Specifies whether the new object can contain other objects. A value of <c>TRUE</c> indicates that the new object is a container.
		/// A value of <c>FALSE</c> indicates that the new object is not a container.
		/// </param>
		/// <param name="AutoInheritFlags">
		/// <para>
		/// A set of bit flags that control how access control entries (ACEs) are inherited from ParentDescriptor. This parameter can be a
		/// combination of the following values.
		/// </para>
		/// <para>
		/// <list type="table">
		/// <listheader>
		/// <term>Value</term>
		/// <term>Meaning</term>
		/// </listheader>
		/// <item>
		/// <term>SEF_AVOID_OWNER_CHECK0x10</term>
		/// <term>
		/// The function does not check the validity of the owner in the resultant NewDescriptor as described in Remarks below. If the
		/// SEF_AVOID_PRIVILEGE_CHECK flag is also set, the Token parameter can be NULL.
		/// </term>
		/// </item>
		/// <item>
		/// <term>SEF_AVOID_OWNER_RESTRICTION0x1000</term>
		/// <term>
		/// Any restrictions specified by the ParentDescriptor that would limit the caller&amp;#39;s ability to specify a DACL in the
		/// CreatorDescriptor are ignored.
		/// </term>
		/// </item>
		/// <item>
		/// <term>SEF_AVOID_PRIVILEGE_CHECK0x08</term>
		/// <term>
		/// The function does not perform privilege checking. If the SEF_AVOID_OWNER_CHECK flag is also set, the Token parameter can be NULL.
		/// This flag is useful while implementing automatic inheritance to avoid checking privileges on each child updated.
		/// </term>
		/// </item>
		/// <item>
		/// <term>SEF_DACL_AUTO_INHERIT0x01</term>
		/// <term>
		/// The new discretionary access control list (DACL) contains ACEs inherited from the DACL of ParentDescriptor, as well as any
		/// explicit ACEs specified in the DACL of CreatorDescriptor. If this flag is not set, the new DACL does not inherit ACEs.
		/// </term>
		/// </item>
		/// <item>
		/// <term>SEF_DEFAULT_DESCRIPTOR_FOR_OBJECT0x04</term>
		/// <term>
		/// CreatorDescriptor is the default descriptor for the type of object specified by ObjectType. As such, CreatorDescriptor is ignored
		/// if ParentDescriptor has any object-specific ACEs for the type of object specified by the ObjectType parameter. If no such ACEs
		/// are inherited, CreatorDescriptor is handled as though this flag were not specified.
		/// </term>
		/// </item>
		/// <item>
		/// <term>SEF_DEFAULT_GROUP_FROM_PARENT0x40</term>
		/// <term>
		/// The group of NewDescriptor defaults to the group from ParentDescriptor. If not set, the group of NewDescriptor defaults to the
		/// group of the token specified by the Token parameter. The group of the token is specified in the token itself. In either case, if
		/// the CreatorDescriptor parameter is not NULL, the NewDescriptor group is set to the group from CreatorDescriptor.
		/// </term>
		/// </item>
		/// <item>
		/// <term>SEF_DEFAULT_OWNER_FROM_PARENT0x20</term>
		/// <term>
		/// The owner of NewDescriptor defaults to the owner from ParentDescriptor. If not set, the owner of NewDescriptor defaults to the
		/// owner of the token specified by the Token parameter. The owner of the token is specified in the token itself. In either case, if
		/// the CreatorDescriptor parameter is not NULL, the NewDescriptor owner is set to the owner from CreatorDescriptor.
		/// </term>
		/// </item>
		/// <item>
		/// <term>SEF_MACL_NO_EXECUTE_UP0x400</term>
		/// <term>
		/// When this flag is set, the mandatory label ACE in CreatorDescriptor is not used to create a mandatory label ACE in NewDescriptor.
		/// Instead, a new SYSTEM_MANDATORY_LABEL_ACE with an access mask of SYSTEM_MANDATORY_LABEL_NO_EXECUTE_UP and the SID from the
		/// token&amp;#39;s integrity SID is added to NewDescriptor.
		/// </term>
		/// </item>
		/// <item>
		/// <term>SEF_MACL_NO_READ_UP0x200</term>
		/// <term>
		/// When this flag is set, the mandatory label ACE in CreatorDescriptor is not used to create a mandatory label ACE in NewDescriptor.
		/// Instead, a new SYSTEM_MANDATORY_LABEL_ACE with an access mask of SYSTEM_MANDATORY_LABEL_NO_READ_UP and the SID from the
		/// token&amp;#39;s integrity SID is added to NewDescriptor.
		/// </term>
		/// </item>
		/// <item>
		/// <term>SEF_MACL_NO_WRITE_UP0x100</term>
		/// <term>
		/// When this flag is set, the mandatory label ACE in CreatorDescriptor is not used to create a mandatory label ACE in NewDescriptor.
		/// Instead, a new SYSTEM_MANDATORY_LABEL_ACE with an access mask of SYSTEM_MANDATORY_LABEL_NO_WRITE_UP and the SID from the
		/// token&amp;#39;s integrity SID is added to NewDescriptor.
		/// </term>
		/// </item>
		/// <item>
		/// <term>SEF_SACL_AUTO_INHERIT0x02</term>
		/// <term>
		/// The new system access control list (SACL) contains ACEs inherited from the SACL of ParentDescriptor, as well as any explicit ACEs
		/// specified in the SACL of CreatorDescriptor. If this flag is not set, the new SACL does not inherit ACEs.
		/// </term>
		/// </item>
		/// </list>
		/// </para>
		/// </param>
		/// <param name="Token">
		/// <para>
		/// A handle to the access token for the client process on whose behalf the object is being created. If this is an impersonation
		/// token, it must be at SecurityIdentification level or higher. For a full description of the SecurityIdentification impersonation
		/// level, see the <c>SECURITY_IMPERSONATION_LEVEL</c> enumerated type.
		/// </para>
		/// <para>
		/// The client token contains default security information, such as the default owner, primary group, and DACL. The function uses
		/// these defaults if the information is not in the input security descriptors. The token must be open for <c>TOKEN_QUERY</c> access.
		/// </para>
		/// <para>
		/// If all of the following conditions are true, then the handle must be opened for <c>TOKEN_DUPLICATE</c> access in addition to
		/// <c>TOKEN_QUERY</c> access.
		/// </para>
		/// </param>
		/// <param name="GenericMapping">
		/// A pointer to a <c>GENERIC_MAPPING</c> structure that specifies the mapping from each generic right to specific rights for the object.
		/// </param>
		/// <returns>
		/// <para>If the function succeeds, the function returns nonzero.</para>
		/// <para>
		/// If the function fails, it returns zero. To get extended error information, call <c>GetLastError</c>. Some of the extended error
		/// codes and their meanings are listed in the following table.
		/// </para>
		/// <para>
		/// <list type="table">
		/// <listheader>
		/// <term>Return code</term>
		/// <term>Description</term>
		/// </listheader>
		/// <item>
		/// <term>ERROR_INVALID_OWNER</term>
		/// <term>
		/// The function cannot retrieve an owner for the new security descriptor or the SID cannot be assigned as an owner. This occurs when
		/// validating the owner SID against the passed-in token.
		/// </term>
		/// </item>
		/// <item>
		/// <term>ERROR_INVALID_PRIMARY_GROUP</term>
		/// <term>The function cannot retrieve a primary group for the new security descriptor.</term>
		/// </item>
		/// <item>
		/// <term>ERROR_NO_TOKEN</term>
		/// <term>The function received NULL instead of a token for owner validation or privilege checking.</term>
		/// </item>
		/// <item>
		/// <term>ERROR_PRIVILEGE_NOT_HELD</term>
		/// <term>
		/// A SACL is being set, SEF_AVOID_PRIVILEGE_CHECK was not passed in, and the token passed in did not have SE_SECURITY_NAME enabled.
		/// </term>
		/// </item>
		/// </list>
		/// </para>
		/// </returns>
		// BOOL WINAPI CreatePrivateObjectSecurityEx( _In_opt_ PSECURITY_DESCRIPTOR ParentDescriptor, _In_opt_ PSECURITY_DESCRIPTOR
		// CreatorDescriptor, _Out_ PSECURITY_DESCRIPTOR *NewDescriptor, _In_opt_ GUID *ObjectType, _In_ BOOL IsContainerObject, _In_ ULONG
		// AutoInheritFlags, _In_opt_ HANDLE Token, _In_ PGENERIC_MAPPING GenericMapping); https://msdn.microsoft.com/en-us/library/windows/desktop/aa446581(v=vs.85).aspx
		[DllImport(Lib.AdvApi32, SetLastError = true, ExactSpelling = true)]
		[PInvokeData("Winbase.h", MSDNShortId = "aa446581")]
		[return: MarshalAs(UnmanagedType.Bool)]
		public static extern bool CreatePrivateObjectSecurityEx([In, Optional] PSECURITY_DESCRIPTOR ParentDescriptor, [In, Optional] PSECURITY_DESCRIPTOR CreatorDescriptor, out SafePrivateObjectSecurity NewDescriptor,
			[In, Optional] IntPtr ObjectType, [MarshalAs(UnmanagedType.Bool)] bool IsContainerObject, SEF AutoInheritFlags, [In, Optional] HTOKEN Token, in GENERIC_MAPPING GenericMapping);

		/// <summary>
		/// The <c>CreatePrivateObjectSecurityWithMultipleInheritance</c> function allocates and initializes a self-relative security
		/// descriptor for a new private object created by the resource manager calling this function. This function supports private objects
		/// (such as Directory Service objects with attached auxiliary classes) composed of multiple object types or classes.
		/// </summary>
		/// <param name="ParentDescriptor">
		/// A pointer to the security descriptor for the parent container of the object. If there is no parent container, this parameter is <c>NULL</c>.
		/// </param>
		/// <param name="CreatorDescriptor">
		/// A pointer to a security descriptor provided by the creator of the object. If the object's creator does not explicitly pass
		/// security information for the new object, this parameter can be <c>NULL</c>. Alternatively, this parameter can point to a default
		/// security descriptor.
		/// </param>
		/// <param name="NewDescriptor">
		/// A pointer to a variable to receive a pointer to the newly allocated self-relative security descriptor. When you have finished
		/// using the security descriptor, free it by calling the DestroyPrivateObjectSecurity function.
		/// </param>
		/// <param name="ObjectTypes">
		/// An array of pointers to GUID structures that identify the object types or classes of the object associated with NewDescriptor.
		/// For Active Directory objects, this array contains pointers to the class GUIDs of the object's structural class and all attached
		/// auxiliary classes. Set ObjectTypes to <c>NULL</c> if the object does not have a GUID.
		/// </param>
		/// <param name="GuidCount">The number of GUIDs present in the ObjectTypes parameter.</param>
		/// <param name="IsContainerObject">
		/// Specifies whether the new object can contain other objects. A value of <c>TRUE</c> indicates that the new object is a container.
		/// A value of <c>FALSE</c> indicates that the new object is not a container.
		/// </param>
		/// <param name="AutoInheritFlags">
		/// <para>
		/// A set of bit flags that control how access control entries (ACEs) are inherited from ParentDescriptor. This parameter can be a
		/// combination of the following values.
		/// </para>
		/// <list type="table">
		/// <listheader>
		/// <term>Value</term>
		/// <term>Meaning</term>
		/// </listheader>
		/// <item>
		/// <term>SEF_DACL_AUTO_INHERIT 0x01</term>
		/// <term>
		/// The new discretionary access control list (DACL) contains ACEs inherited from the DACL of ParentDescriptor, as well as any
		/// explicit ACEs specified in the DACL of CreatorDescriptor. If this flag is not set, the new DACL does not inherit ACEs.
		/// </term>
		/// </item>
		/// <item>
		/// <term>SEF_SACL_AUTO_INHERIT 0x02</term>
		/// <term>
		/// The new system access control list (SACL) contains ACEs inherited from the SACL of ParentDescriptor, as well as any explicit ACEs
		/// specified in the SACL of CreatorDescriptor. If this flag is not set, the new SACL does not inherit ACEs.
		/// </term>
		/// </item>
		/// <item>
		/// <term>SEF_DEFAULT_DESCRIPTOR_FOR_OBJECT 0x04</term>
		/// <term>
		/// CreatorDescriptor is the default descriptor for the types of objects specified by ObjectTypes. As such, CreatorDescriptor is
		/// ignored if ParentDescriptor has any object-specific ACEs for the types of objects specified by the ObjectTypes parameter. If no
		/// such ACEs are inherited, CreatorDescriptor is handled as though this flag were not specified.
		/// </term>
		/// </item>
		/// <item>
		/// <term>SEF_AVOID_PRIVILEGE_CHECK 0x08</term>
		/// <term>
		/// The function does not perform privilege checking. If the SEF_AVOID_OWNER_CHECK flag is also set, the Token parameter can be NULL.
		/// This flag is useful while implementing automatic inheritance to avoid checking privileges on each child updated.
		/// </term>
		/// </item>
		/// <item>
		/// <term>SEF_AVOID_OWNER_CHECK 0x10</term>
		/// <term>
		/// The function does not check the validity of the owner in the resultant NewDescriptor as described in the Remarks section. If the
		/// SEF_AVOID_PRIVILEGE_CHECK flag is also set, the Token parameter can be NULL.
		/// </term>
		/// </item>
		/// <item>
		/// <term>SEF_DEFAULT_OWNER_FROM_PARENT 0x20</term>
		/// <term>
		/// The owner of NewDescriptor defaults to the owner from ParentDescriptor. If not set, the owner of NewDescriptor defaults to the
		/// owner of the token specified by the Token parameter. The owner of the token is specified in the token itself. In either case, if
		/// the CreatorDescriptor parameter is not NULL, the NewDescriptor owner is set to the owner from CreatorDescriptor.
		/// </term>
		/// </item>
		/// <item>
		/// <term>SEF_DEFAULT_GROUP_FROM_PARENT 0x40</term>
		/// <term>
		/// The group of NewDescriptor defaults to the group from ParentDescriptor. If not set, the group of NewDescriptor defaults to the
		/// group of the token specified by the Token parameter. The group of the token is specified in the token itself. In either case, if
		/// the CreatorDescriptor parameter is not NULL, the NewDescriptor group is set to the group from CreatorDescriptor.
		/// </term>
		/// </item>
		/// <item>
		/// <term>SEF_MACL_NO_WRITE_UP 0x100</term>
		/// <term>A principal with a mandatory level lower than that of the object cannot write to the object.</term>
		/// </item>
		/// <item>
		/// <term>SEF_MACL_NO_READ_UP 0x200</term>
		/// <term>A principal with a mandatory level lower than that of the object cannot read the object.</term>
		/// </item>
		/// <item>
		/// <term>SEF_MACL_NO_EXECUTE_UP 0x400</term>
		/// <term>A principal with a mandatory level lower than that of the object cannot execute the object.</term>
		/// </item>
		/// <item>
		/// <term>SEF_AVOID_OWNER_RESTRICTION 0x1000</term>
		/// <term>
		/// Any restrictions specified by the ParentDescriptor parameter that would limit the caller's ability to specify a DACL in the
		/// CreatorDescriptor are ignored.
		/// </term>
		/// </item>
		/// </list>
		/// </param>
		/// <param name="Token">
		/// <para>
		/// A handle to the access token for the client process on whose behalf the object is being created. If this is an impersonation
		/// token, it must be at SecurityIdentification level or higher. For a full description of the SecurityIdentification impersonation
		/// level, see the SECURITY_IMPERSONATION_LEVEL enumerated type.
		/// </para>
		/// <para>
		/// The client token contains default security information, such as the default owner, primary group, and DACL. This function uses
		/// these defaults if the information is not in the input security descriptors. The token must be open for <c>TOKEN_QUERY</c> access.
		/// </para>
		/// <para>
		/// If all of the following conditions are true, then the handle must be opened for <c>TOKEN_DUPLICATE</c> access in addition to
		/// <c>TOKEN_QUERY</c> access.
		/// </para>
		/// <list type="bullet">
		/// <item>
		/// <term>The token handle refers to a primary token.</term>
		/// </item>
		/// <item>
		/// <term>The security descriptor of the token contains one or more ACEs with the <c>OwnerRights</c> SID.</term>
		/// </item>
		/// <item>
		/// <term>A security descriptor is specified for the CreatorDescriptor parameter.</term>
		/// </item>
		/// <item>
		/// <term>The caller of this function does not set the <c>SEF_AVOID_OWNER_RESTRICTION</c> flag in the AutoInheritFlags parameter.</term>
		/// </item>
		/// </list>
		/// </param>
		/// <param name="GenericMapping">
		/// A pointer to a GENERIC_MAPPING structure that specifies the mapping from each generic right to specific rights for the object.
		/// </param>
		/// <returns>
		/// <para>If the function succeeds, the function returns a nonzero value.</para>
		/// <para>
		/// If the function fails, it returns zero. Call GetLastError for extended error information. Some extended error codes and their
		/// meanings are listed in the following table.
		/// </para>
		/// <list type="table">
		/// <listheader>
		/// <term>Return code</term>
		/// <term>Description</term>
		/// </listheader>
		/// <item>
		/// <term>ERROR_INVALID_PRIMARY_GROUP</term>
		/// <term>The function cannot retrieve a primary group for the new security descriptor.</term>
		/// </item>
		/// <item>
		/// <term>ERROR_INVALID_OWNER</term>
		/// <term>
		/// The function cannot retrieve an owner for the new security descriptor or the security identifier (SID) cannot be assigned as an
		/// owner. This occurs when validating the owner SID against the passed-in token.
		/// </term>
		/// </item>
		/// <item>
		/// <term>ERROR_NO_TOKEN</term>
		/// <term>The function received NULL instead of a token for owner validation or privilege checking.</term>
		/// </item>
		/// <item>
		/// <term>ERROR_PRIVILEGE_NOT_HELD</term>
		/// <term>
		/// A SACL is being set, SEF_AVOID_PRIVILEGE_CHECK was not passed in, and the token passed in did not have SE_SECURITY_NAME enabled.
		/// </term>
		/// </item>
		/// </list>
		/// </returns>
		/// <remarks>
		/// <para>
		/// The CreatePrivateObjectSecurityEx function is identical to calling the <c>CreatePrivateObjectSecurityWithMultipleInheritance</c>
		/// function with a single GUID in ObjectTypes.
		/// </para>
		/// <para>
		/// The AutoInheritFlags are distinct from the similarly named bits in the <c>Control</c> member of the SECURITY_DESCRIPTOR
		/// structure. For an explanation of the control bits, see SECURITY_DESCRIPTOR_CONTROL.
		/// </para>
		/// <para>
		/// If AutoInheritFlags specifies the SEF_DACL_AUTO_INHERIT bit, the function applies the following rules to the DACL in the new
		/// security descriptor:
		/// </para>
		/// <list type="bullet">
		/// <item>
		/// <term>The SE_DACL_AUTO_INHERITED flag is set in the <c>Control</c> member of the new security descriptor.</term>
		/// </item>
		/// <item>
		/// <term>
		/// The DACL of the new security descriptor inherits ACEs from ParentDescriptor regardless of whether CreatorDescriptor is the
		/// default security descriptor or was explicitly specified by the creator. The new DACL is a combination of the parent and creator
		/// DACLs as defined by the rules of inheritance. Specifically, any ACEs in ParentDescriptor that are inheritable either to all child
		/// objects or to any object class listed in ObjectTypes will be applied to the new DACL.
		/// </term>
		/// </item>
		/// <item>
		/// <term>Inherited ACEs are marked as INHERITED_ACE.</term>
		/// </item>
		/// </list>
		/// <para>If AutoInheritFlags specifies the SEF_SACL_AUTO_INHERIT bit, the function applies similar rules to the new SACL.</para>
		/// <para>
		/// For both DACLs and SACLs, certain types of ACEs in ParentDescriptor and CreatorDescriptor will be manipulated and possibly
		/// replaced by two ACEs in NewDescriptor. Specifically, an inheritable ACE that contains at least one of the following mappable
		/// elements may result in two ACEs in the output security descriptor. Mappable elements include:
		/// </para>
		/// <list type="bullet">
		/// <item>
		/// <term>Generic access rights in the ACCESS_MASK</term>
		/// </item>
		/// <item>
		/// <term>Creator Owner SID or Creator Group SID as the ACE subject identifier</term>
		/// </item>
		/// </list>
		/// <para>ACEs with any of these mappable elements will result in the following two ACEs in NewDescriptor:</para>
		/// <list type="bullet">
		/// <item>
		/// <term>
		/// An ACE that is a copy of the original, but with the INHERIT_ONLY flag set. However, this ACE will not be created if either of the
		/// following two conditions exist:
		/// </term>
		/// </item>
		/// <item>
		/// <term>An effective ACE in which the INHERITED_ACE bit is turned on and the generic elements are mapped to specific elements:</term>
		/// </item>
		/// </list>
		/// <para>
		/// If AutoInheritFlags does not specify the SEF_AVOID_OWNER_CHECK bit, owner validity checking is performed according to the
		/// following rules. The Owner in the resultant NewDescriptormust be a legally formed SID, and either must match the TokenUser in
		/// Token or must match a group in the TokenGroups in Token. The attributes on the group:
		/// </para>
		/// <list type="bullet">
		/// <item>
		/// <term>Must include SE_GROUP_OWNER</term>
		/// </item>
		/// <item>
		/// <term>Must not include SE_GROUP_USE_FOR_DENY_ONLY</term>
		/// </item>
		/// </list>
		/// <para>
		/// Callers that do not have access to the token of the client that will ultimately be setting the owner may choose to skip owner
		/// validation checking.
		/// </para>
		/// <para>
		/// To create a security descriptor for a new object, call <c>CreatePrivateObjectSecurityWithMultipleInheritance</c> with
		/// ParentDescriptor set to the security descriptor of the parent container and CreatorDescriptor set to the security descriptor
		/// proposed by the creator of the object.
		/// </para>
		/// <para>
		/// To verify the current security descriptor on an object, call <c>CreatePrivateObjectSecurityWithMultipleInheritance</c> with
		/// ParentDescriptor set to the security descriptor of the parent container and CreatorDescriptor set to the current security
		/// descriptor of the object. This call ensures that the ACEs are appropriately inherited from parent to child security descriptors.
		/// </para>
		/// <para>
		/// If the CreatorDescriptor security descriptor contains a SACL, Token must have the SE_SECURITY_NAME privilege enabled or the
		/// caller must specify the SEF_AVOID_PRIVILEGE_CHECK flag in AutoInheritFlags.
		/// </para>
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows/desktop/api/securitybaseapi/nf-securitybaseapi-createprivateobjectsecuritywithmultipleinheritance
		// BOOL CreatePrivateObjectSecurityWithMultipleInheritance( PSECURITY_DESCRIPTOR ParentDescriptor, PSECURITY_DESCRIPTOR
		// CreatorDescriptor, PSECURITY_DESCRIPTOR *NewDescriptor, GUID **ObjectTypes, ULONG GuidCount, BOOL IsContainerObject, ULONG
		// AutoInheritFlags, HANDLE Token, PGENERIC_MAPPING GenericMapping );
		[DllImport(Lib.AdvApi32, SetLastError = true, ExactSpelling = true)]
		[PInvokeData("securitybaseapi.h", MSDNShortId = "8c5a2ac2-612c-4625-8c68-27d99d4ba9d5")]
		[return: MarshalAs(UnmanagedType.Bool)]
		public static extern bool CreatePrivateObjectSecurityWithMultipleInheritance([In, Optional] PSECURITY_DESCRIPTOR ParentDescriptor, [In, Optional] PSECURITY_DESCRIPTOR CreatorDescriptor, out SafePrivateObjectSecurity NewDescriptor,
			[In, MarshalAs(UnmanagedType.LPArray), Optional] Guid[] ObjectTypes, uint GuidCount, [MarshalAs(UnmanagedType.Bool)] bool IsContainerObject, SEF AutoInheritFlags, HTOKEN Token, in GENERIC_MAPPING GenericMapping);

		/// <summary>
		/// The <c>CreateRestrictedToken</c> function creates a new access token that is a restricted version of an existing access token.
		/// The restricted token can have disabled security identifiers (SIDs), deleted privileges, and a list of restricting SIDs. For more
		/// information, see Restricted Tokens.
		/// </summary>
		/// <param name="ExistingTokenHandle">
		/// A handle to a primary or impersonation token. The token can also be a restricted token. The handle must have TOKEN_DUPLICATE
		/// access to the token.
		/// </param>
		/// <param name="Flags">
		/// <para>Specifies additional privilege options. This parameter can be zero or a combination of the following values.</para>
		/// <list type="table">
		/// <listheader>
		/// <term>Value</term>
		/// <term>Meaning</term>
		/// </listheader>
		/// <item>
		/// <term>DISABLE_MAX_PRIVILEGE 0x1</term>
		/// <term>
		/// Disables all privileges in the new token except the SeChangeNotifyPrivilege privilege. If this value is specified, the
		/// DeletePrivilegeCount and PrivilegesToDelete parameters are ignored.
		/// </term>
		/// </item>
		/// <item>
		/// <term>SANDBOX_INERT 0x2</term>
		/// <term>
		/// If this value is used, the system does not check AppLocker rules or apply Software Restriction Policies. For AppLocker, this flag
		/// disables checks for all four rule collections: Executable, Windows Installer, Script, and DLL. When creating a setup program that
		/// must run extracted DLLs during installation, use the flag SAFER_TOKEN_MAKE_INERT in the SaferComputeTokenFromLevel function. A
		/// token can be queried for existence of this flag by using GetTokenInformation. Windows Server 2008 R2, Windows 7, Windows Server
		/// 2008, Windows Vista, Windows Server 2003 and Windows XP: On systems with KB2532445 installed, the caller must be running as
		/// LocalSystem or TrustedInstaller or the system ignores this flag. For more information, see "You can circumvent AppLocker rules by
		/// using an Office macro on a computer that is running Windows 7 or Windows Server 2008 R2" in the Help and Support Knowledge Base
		/// at http://support.microsoft.com/kb/2532445. Windows Server 2008, Windows Vista, Windows Server 2003 and Windows XP: AppLocker is
		/// not supported. AppLocker was introduced in Windows 7 and Windows Server 2008 R2.
		/// </term>
		/// </item>
		/// <item>
		/// <term>LUA_TOKEN 0x4</term>
		/// <term>The new token is a LUA token. Windows Server 2003 and Windows XP: This value is not supported.</term>
		/// </item>
		/// <item>
		/// <term>WRITE_RESTRICTED 0x8</term>
		/// <term>
		/// The new token contains restricting SIDs that are considered only when evaluating write access. Windows XP with SP2 and later: The
		/// value of this constant is 0x4. For an application to be compatible with Windows XP with SP2 and later operating systems, the
		/// application should query the operating system by calling the GetVersionEx function to determine which value should be used.
		/// Windows Server 2003 and Windows XP with SP1 and earlier: This value is not supported.
		/// </term>
		/// </item>
		/// </list>
		/// </param>
		/// <param name="DisableSidCount">Specifies the number of entries in the SidsToDisable array.</param>
		/// <param name="SidsToDisable">
		/// <para>
		/// A pointer to an array of SID_AND_ATTRIBUTES structures that specify the deny-only SIDs in the restricted token. The system uses a
		/// deny-only SID to deny access to a securable object. The absence of a deny-only SID does not allow access.
		/// </para>
		/// <para>
		/// Disabling a SID turns on SE_GROUP_USE_FOR_DENY_ONLY and turns off SE_GROUP_ENABLED and SE_GROUP_ENABLED_BY_DEFAULT. All other
		/// attributes are ignored.
		/// </para>
		/// <para>
		/// Deny-only attributes apply to any combination of an existing token's SIDs, including the user SID and group SIDs that have the
		/// SE_GROUP_MANDATORY attribute. To get the SIDs associated with the existing token, use the GetTokenInformation function with the
		/// TokenUser and TokenGroups flags. The function ignores any SIDs in the array that are not also found in the existing token.
		/// </para>
		/// <para>The function ignores the <c>Attributes</c> member of the SID_AND_ATTRIBUTES structure.</para>
		/// <para>This parameter can be <c>NULL</c> if no SIDs are to be disabled.</para>
		/// </param>
		/// <param name="DeletePrivilegeCount">Specifies the number of entries in the PrivilegesToDelete array.</param>
		/// <param name="PrivilegesToDelete">
		/// <para>A pointer to an array of LUID_AND_ATTRIBUTES structures that specify the privileges to delete in the restricted token.</para>
		/// <para>
		/// The GetTokenInformation function can be used with the TokenPrivileges flag to retrieve the privileges held by the existing token.
		/// The function ignores any privileges in the array that are not held by the existing token.
		/// </para>
		/// <para>The function ignores the <c>Attributes</c> members of the LUID_AND_ATTRIBUTES structures.</para>
		/// <para>This parameter can be <c>NULL</c> if you do not want to delete any privileges.</para>
		/// <para>If the calling program passes too many privileges in this array, <c>CreateRestrictedToken</c> returns ERROR_INVALID_PARAMETER.</para>
		/// </param>
		/// <param name="RestrictedSidCount">Specifies the number of entries in the SidsToRestrict array.</param>
		/// <param name="SidsToRestrict">
		/// <para>
		/// A pointer to an array of SID_AND_ATTRIBUTES structures that specify a list of restricting SIDs for the new token. If the existing
		/// token is a restricted token, the list of restricting SIDs for the new token is the intersection of this array and the list of
		/// restricting SIDs for the existing token. No check is performed to remove duplicate SIDs that were placed on the SidsToRestrict
		/// parameter. Duplicate SIDs allow a restricted token to have redundant information in the restricting SID list.
		/// </para>
		/// <para>
		/// The <c>Attributes</c> member of the SID_AND_ATTRIBUTES structure must be zero. Restricting SIDs are always enabled for access checks.
		/// </para>
		/// <para>This parameter can be <c>NULL</c> if you do not want to specify any restricting SIDs.</para>
		/// </param>
		/// <param name="NewTokenHandle">
		/// A pointer to a variable that receives a handle to the new restricted token. This handle has the same access rights as
		/// ExistingTokenHandle. The new token is the same type, primary or impersonation, as the existing token. The handle returned in
		/// NewTokenHandle can be duplicated.
		/// </param>
		/// <returns>
		/// <para>If the function succeeds, the return value is nonzero.</para>
		/// <para>If the function fails, the return value is zero. To get extended error information, call GetLastError.</para>
		/// </returns>
		/// <remarks>
		/// <para>The <c>CreateRestrictedToken</c> function can restrict the token in the following ways:</para>
		/// <list type="bullet">
		/// <item>
		/// <term>
		/// Apply the deny-only attribute to SIDs in the token so they cannot be used to access secured objects. For more information about
		/// the deny-only attribute, see SID Attributes in an Access Token.
		/// </term>
		/// </item>
		/// <item>
		/// <term>Remove privileges from the token.</term>
		/// </item>
		/// <item>
		/// <term>
		/// Specify a list of restricting SIDs, which the system uses when it checks the token's access to a securable object. The system
		/// performs two access checks: one using the token's enabled SIDs, and another using the list of restricting SIDs. Access is granted
		/// only if both access checks allow the requested access rights.
		/// </term>
		/// </item>
		/// </list>
		/// <para>
		/// You can use the restricted token in the CreateProcessAsUser function to create a process that has restricted access rights and
		/// privileges. If a process calls <c>CreateProcessAsUser</c> using a restricted version of its own token, the calling process does
		/// not need to have the SE_ASSIGNPRIMARYTOKEN_NAME privilege.
		/// </para>
		/// <para>You can use the restricted token in the ImpersonateLoggedOnUser function.</para>
		/// <para>
		/// <c>Caution</c> Applications that use restricted tokens should run the restricted application on desktops other than the default
		/// desktop. This is necessary to prevent an attack by a restricted application, using <c>SendMessage</c> or <c>PostMessage</c>, to
		/// unrestricted applications on the default desktop. If necessary, switch between desktops for your application purposes.
		/// </para>
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows/desktop/api/securitybaseapi/nf-securitybaseapi-createrestrictedtoken BOOL
		// CreateRestrictedToken( HANDLE ExistingTokenHandle, DWORD Flags, DWORD DisableSidCount, PSID_AND_ATTRIBUTES SidsToDisable, DWORD
		// DeletePrivilegeCount, PLUID_AND_ATTRIBUTES PrivilegesToDelete, DWORD RestrictedSidCount, PSID_AND_ATTRIBUTES SidsToRestrict,
		// PHANDLE NewTokenHandle );
		[DllImport(Lib.AdvApi32, SetLastError = true, ExactSpelling = true)]
		[PInvokeData("securitybaseapi.h", MSDNShortId = "e087f360-5d1d-4846-b3d6-214a426e5222")]
		[return: MarshalAs(UnmanagedType.Bool)]
		public static extern bool CreateRestrictedToken(HTOKEN ExistingTokenHandle, [Optional] RestrictedPrivilegeOptions Flags,
			[Optional] uint DisableSidCount, [In, MarshalAs(UnmanagedType.LPArray), Optional] SID_AND_ATTRIBUTES[] SidsToDisable,
			[Optional] uint DeletePrivilegeCount, [In, MarshalAs(UnmanagedType.LPArray), Optional] LUID_AND_ATTRIBUTES[] PrivilegesToDelete,
			[Optional] uint RestrictedSidCount, [In, MarshalAs(UnmanagedType.LPArray), Optional] SID_AND_ATTRIBUTES[] SidsToRestrict, out SafeHTOKEN NewTokenHandle);

		/// <summary>
		/// A tracing function for publishing events when an attempted security vulnerability exploit is detected in your user-mode application.
		/// </summary>
		/// <param name="CveId">A pointer to the CVE ID associated with the vulnerability for which this event is being raised.</param>
		/// <param name="AdditionalDetails">
		/// A pointer to a string giving additional details that the event producer may want to provide to the consumer of this event.
		/// </param>
		/// <returns>
		/// <para>Returns ERROR_SUCCESS if successful or one of the following values on error.</para>
		/// <list type="table">
		/// <listheader>
		/// <term>Return code</term>
		/// <term>Description</term>
		/// </listheader>
		/// <item>
		/// <term>ERROR_INVALID_PARAMETER</term>
		/// <term>One or more of the parameters is not valid.</term>
		/// </item>
		/// <item>
		/// <term>ERROR_ARITHMETIC_OVERFLOW</term>
		/// <term>The event size is larger than the allowed maximum (64k - header).</term>
		/// </item>
		/// <item>
		/// <term>ERROR_MORE_DATA</term>
		/// <term>The session buffer size is too small for the event.</term>
		/// </item>
		/// <item>
		/// <term>ERROR_NOT_ENOUGH_MEMORY</term>
		/// <term>
		/// Occurs when filled buffers are trying to flush to disk, but disk IOs are not happening fast enough. This happens when the disk is
		/// slow and event traffic is heavy. Eventually, there are no more free (empty) buffers and the event is dropped.
		/// </term>
		/// </item>
		/// <item>
		/// <term>STATUS_LOG_FILE_FULL</term>
		/// <term>
		/// The real-time playback file is full. Events are not logged to the session until a real-time consumer consumes the events from the
		/// playback file. Do not stop logging events based on this error code.
		/// </term>
		/// </item>
		/// </list>
		/// </returns>
		/// <remarks>
		/// <para>
		/// The CveEventWrite function publishes a CVE-based event. This function should be called only in scenarios where an attempt to
		/// exploit a known, patched vulnerability is detected by the application. Ideally, this function call should be added as part of the
		/// fix (update) itself.
		/// </para>
		/// <para>
		/// The default consumer for this event is EventLog-Application. To enable another consumer, the provider can be added to the
		/// consumer session.
		/// </para>
		/// <para>Provider GUID: 85a62a0d-7e17-485f-9d4f-749a287193a6</para>
		/// <para>Source Name: Microsoft-Windows-Audit-CVE or Audit-CVE</para>
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows/desktop/api/securitybaseapi/nf-securitybaseapi-cveeventwrite LONG CveEventWrite( PCWSTR
		// CveId, PCWSTR AdditionalDetails );
		[DllImport(Lib.AdvApi32, SetLastError = false, ExactSpelling = true)]
		[PInvokeData("securitybaseapi.h", MSDNShortId = "81CDC4A8-67B3-40AE-B492-89EF47BC5C4D")]
		public static extern Win32Error CveEventWrite([MarshalAs(UnmanagedType.LPWStr)] string CveId, [Optional, MarshalAs(UnmanagedType.LPWStr)] string AdditionalDetails);

		/// <summary>The <c>DeleteAce</c> function deletes an access control entry (ACE) from an access control list (ACL).</summary>
		/// <param name="pAcl">A pointer to an ACL. The ACE specified by the dwAceIndex parameter is removed from this ACL.</param>
		/// <param name="dwAceIndex">
		/// The ACE to delete. A value of zero corresponds to the first ACE in the ACL, a value of one to the second ACE, and so on.
		/// </param>
		/// <returns>
		/// <para>If the function succeeds, the function returns nonzero.</para>
		/// <para>If the function fails, the return value is zero. To get extended error information, call GetLastError.</para>
		/// </returns>
		/// <remarks>
		/// An application can use the ACL_SIZE_INFORMATION structure retrieved by the GetAclInformation function to discover the size of the
		/// ACL and the number of ACEs it contains. The GetAce function retrieves information about an individual ACE.
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows/desktop/api/securitybaseapi/nf-securitybaseapi-deleteace BOOL DeleteAce( PACL pAcl, DWORD
		// dwAceIndex );
		[DllImport(Lib.AdvApi32, SetLastError = true, ExactSpelling = true)]
		[PInvokeData("securitybaseapi.h", MSDNShortId = "02ce45ad-3d51-4548-848e-a62bf4bf72a8")]
		[return: MarshalAs(UnmanagedType.Bool)]
		public static extern bool DeleteAce(PACL pAcl, uint dwAceIndex);

		/// <summary>
		/// This function constructs two arrays of SIDs out of a capability name. One is an array group SID with NT Authority, and the other
		/// is an array of capability SIDs with AppAuthority.
		/// </summary>
		/// <param name="CapName">Name of the capability in string form.</param>
		/// <param name="CapabilityGroupSids">The GroupSids with NTAuthority.</param>
		/// <param name="CapabilityGroupSidCount">The count of GroupSids in the array.</param>
		/// <param name="CapabilitySids">CapabilitySids with AppAuthority.</param>
		/// <param name="CapabilitySidCount">The count of CapabilitySid with AppAuthority.</param>
		/// <returns>
		/// <para>If the function succeeds, it returns <c>TRUE</c>.</para>
		/// <para>If the function fails, it returns <c>FALSE</c>. To get extended error information, call GetLastError.</para>
		/// </returns>
		/// <remarks>
		/// The caller is expected to free the individual SIDs returned in each array by calling LocalFree. as well as memory allocated for
		/// the array itself.
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows/win32/api/securitybaseapi/nf-securitybaseapi-derivecapabilitysidsfromname BOOL
		// DeriveCapabilitySidsFromName( LPCWSTR CapName, PSID **CapabilityGroupSids, DWORD *CapabilityGroupSidCount, PSID **CapabilitySids,
		// DWORD *CapabilitySidCount );
		[DllImport(Lib.KernelBase, SetLastError = true, ExactSpelling = true)]
		[PInvokeData("securitybaseapi.h", MSDNShortId = "1A911FCC-6D11-4185-B532-20FE6C7C4B0B")]
		[return: MarshalAs(UnmanagedType.Bool)]
		public static extern bool DeriveCapabilitySidsFromName([MarshalAs(UnmanagedType.LPWStr)] string CapName, out SafePSIDArray CapabilityGroupSids, out int CapabilityGroupSidCount, out SafePSIDArray CapabilitySids, out int CapabilitySidCount);

		/// <summary>
		/// The <c>DestroyPrivateObjectSecurity</c> function deletes a private object's security descriptor. For background information, see
		/// the Security Descriptors for Private Objects topic.
		/// </summary>
		/// <param name="ObjectDescriptor">
		/// A pointer to a pointer to the SECURITY_DESCRIPTOR structure to be deleted. This security descriptor must have been created by a
		/// call to the CreatePrivateObjectSecurity function.
		/// </param>
		/// <returns>
		/// <para>If the function succeeds, the return value is nonzero.</para>
		/// <para>If the function fails, the return value is zero. To get extended error information, call GetLastError.</para>
		/// </returns>
		// https://docs.microsoft.com/en-us/windows/desktop/api/securitybaseapi/nf-securitybaseapi-destroyprivateobjectsecurity BOOL
		// DestroyPrivateObjectSecurity( PSECURITY_DESCRIPTOR *ObjectDescriptor );
		[DllImport(Lib.AdvApi32, SetLastError = true, ExactSpelling = true)]
		[PInvokeData("securitybaseapi.h", MSDNShortId = "4ef10852-8229-41de-a4d7-d2845e4c92ce")]
		[return: MarshalAs(UnmanagedType.Bool)]
		public static extern bool DestroyPrivateObjectSecurity(in PSECURITY_DESCRIPTOR ObjectDescriptor);

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
		public static extern bool DuplicateTokenEx(HTOKEN hExistingToken, TokenAccess dwDesiredAccess, [In, Optional] SECURITY_ATTRIBUTES lpTokenAttributes,
			SECURITY_IMPERSONATION_LEVEL ImpersonationLevel, TOKEN_TYPE TokenType, out SafeHTOKEN phNewToken);

		/// <summary>The <c>FindFirstFreeAce</c> function retrieves a pointer to the first free byte in an access control list (ACL).</summary>
		/// <param name="pAcl">A pointer to an ACL.</param>
		/// <param name="pAce">
		/// The address of a pointer to the first free position in the ACL created when the function returns. If the ACL is not valid, this
		/// parameter is <c>NULL</c>. If the ACL is full, this parameter points to the byte immediately following the ACL.
		/// </param>
		/// <returns>
		/// <para>If the function succeeds, the function returns nonzero.</para>
		/// <para>If the function fails, it returns zero. To get extended error information, call GetLastError.</para>
		/// </returns>
		// https://docs.microsoft.com/en-us/windows/desktop/api/securitybaseapi/nf-securitybaseapi-findfirstfreeace BOOL FindFirstFreeAce(
		// PACL pAcl, LPVOID *pAce );
		[DllImport(Lib.AdvApi32, SetLastError = true, ExactSpelling = true)]
		[PInvokeData("securitybaseapi.h", MSDNShortId = "bf770761-008a-4a35-b31f-b781d5a8622b")]
		[return: MarshalAs(UnmanagedType.Bool)]
		public static extern bool FindFirstFreeAce(PACL pAcl, out PACE pAce);

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
		// https://docs.microsoft.com/en-us/windows/desktop/api/securitybaseapi/nf-securitybaseapi-getace BOOL GetAce( PACL pAcl, DWORD
		// dwAceIndex, LPVOID *pAce );
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
		public static extern bool GetAclInformation(PACL pAcl, out ACL_REVISION_INFORMATION pAclInformation, uint nAclInformationLength = 4, ACL_INFORMATION_CLASS dwAclInformationClass = ACL_INFORMATION_CLASS.AclRevisionInformation);

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
		public static extern bool GetAclInformation(PACL pAcl, out ACL_SIZE_INFORMATION pAclInformation, uint nAclInformationLength = 12, ACL_INFORMATION_CLASS dwAclInformationClass = ACL_INFORMATION_CLASS.AclSizeInformation);

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
				if (!GetAclInformation(pAcl, mem, (uint)Marshal.SizeOf(typeof(T)), c))
					throw new Win32Exception();
				return mem.ToStructure<T>();
			}
		}

		/// <summary>The <c>GetKernelObjectSecurity</c> function retrieves a copy of the security descriptor that protects a kernel object.</summary>
		/// <param name="Handle">A handle to a kernel object.</param>
		/// <param name="RequestedInformation">Specifies a SECURITY_INFORMATION value that identifies the security information being requested.</param>
		/// <param name="pSecurityDescriptor">
		/// A pointer to a buffer the function fills with a copy of the security descriptor of the specified object. The calling process must
		/// have the right to view the specified aspects of the object's security status. The SECURITY_DESCRIPTOR structure is returned in
		/// self-relative format.
		/// </param>
		/// <param name="nLength">Specifies the size, in bytes, of the buffer pointed to by the pSecurityDescriptor parameter.</param>
		/// <param name="lpnLengthNeeded">
		/// A pointer to a variable that receives the number of bytes required for the buffer pointed to by the pSecurityDescriptor
		/// parameter. If this variable's value is greater than the value of the nLength parameter when the function returns, none of the
		/// security descriptor is copied to the buffer.
		/// </param>
		/// <returns>
		/// <para>If the function succeeds, the return value is nonzero.</para>
		/// <para>If the function fails, the return value is zero. To get extended error information, call GetLastError.</para>
		/// </returns>
		/// <remarks>
		/// <para>
		/// To read the owner, group, or DACL from the kernel object's security descriptor, the calling process must have been granted
		/// READ_CONTROL access when the handle was opened. To get READ_CONTROL access, the caller must be the owner of the object or the
		/// object's DACL must grant the access.
		/// </para>
		/// <para>
		/// To read the SACL from the security descriptor, the calling process must have been granted ACCESS_SYSTEM_SECURITY access when the
		/// handle was opened. The proper way to get this access is to enable the SE_SECURITY_NAME privilege in the caller's current token,
		/// open the handle for ACCESS_SYSTEM_SECURITY access, and then disable the privilege.
		/// </para>
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows/desktop/api/securitybaseapi/nf-securitybaseapi-getkernelobjectsecurity BOOL
		// GetKernelObjectSecurity( HANDLE Handle, SECURITY_INFORMATION RequestedInformation, PSECURITY_DESCRIPTOR pSecurityDescriptor, DWORD
		// nLength, LPDWORD lpnLengthNeeded );
		[DllImport(Lib.AdvApi32, SetLastError = true, ExactSpelling = true)]
		[PInvokeData("securitybaseapi.h", MSDNShortId = "276e9657-5729-48cb-9531-14bfd08b7868")]
		[return: MarshalAs(UnmanagedType.Bool)]
		public static extern bool GetKernelObjectSecurity(HANDLE Handle, SECURITY_INFORMATION RequestedInformation, PSECURITY_DESCRIPTOR pSecurityDescriptor, uint nLength, out uint lpnLengthNeeded);

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
			SafePSECURITY_DESCRIPTOR ResultantDescriptor, uint DescriptorLength, out uint ReturnLength);

		/// <summary>The GetPrivateObjectSecurity function retrieves information from a private object's security descriptor.</summary>
		/// <param name="ObjectDescriptor">A pointer to a SECURITY_DESCRIPTOR structure. This is the security descriptor to be queried.</param>
		/// <param name="SecurityInformation">
		/// A set of bit flags that indicate the parts of the security descriptor to retrieve. This parameter can be a combination of the
		/// SECURITY_INFORMATION bit flags.
		/// </param>
		/// <returns>
		/// The requested information from the specified security descriptor. The SECURITY_DESCRIPTOR structure is returned in self-relative format.
		/// </returns>
		public static SafePSECURITY_DESCRIPTOR GetPrivateObjectSecurity(this PSECURITY_DESCRIPTOR ObjectDescriptor, SECURITY_INFORMATION SecurityInformation)
		{
			var pResSD = SafePSECURITY_DESCRIPTOR.Null;
			if (!GetPrivateObjectSecurity(ObjectDescriptor, SecurityInformation, pResSD, 0, out var ret) && ret == 0)
				Win32Error.ThrowLastError();
			pResSD = new SafePSECURITY_DESCRIPTOR((int)ret);
			if (!pResSD.IsInvalid && !GetPrivateObjectSecurity(ObjectDescriptor, SecurityInformation, pResSD, ret, out _))
				Win32Error.ThrowLastError();
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
		public static SafePSECURITY_DESCRIPTOR GetPrivateObjectSecurity(this SafePSECURITY_DESCRIPTOR ObjectDescriptor, SECURITY_INFORMATION SecurityInformation) =>
			GetPrivateObjectSecurity((PSECURITY_DESCRIPTOR)ObjectDescriptor, SecurityInformation);

		/// <summary>
		/// Gets the required size of an ACE of the type specified by <typeparamref name="TAceStruct"/> with the supplied security identifier (SID).
		/// </summary>
		/// <typeparam name="TAceStruct">The type of the ACE structure.</typeparam>
		/// <param name="pSid">The security identifier (SID) structure pointer.</param>
		/// <param name="sidOffset">On return, the offset within the structure where the SID should be copied.</param>
		/// <returns>The required size, in bytes, for this ACE.</returns>
		public static int GetRequiredAceSize<TAceStruct>(PSID pSid, out int sidOffset) where TAceStruct : struct
		{
			sidOffset = GetSize<TAceStruct>() - GetSize<uint>();
			return sidOffset + pSid.Length();
		}

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

		/// <summary>The <c>GetSecurityDescriptorRMControl</c> function retrieves the resource manager control bits.</summary>
		/// <param name="SecurityDescriptor">
		/// A pointer to a SECURITY_DESCRIPTOR structure that contains the resource manager control bits. The value of the <c>Control</c>
		/// member is set to SE_RM_CONTROL_VALID.
		/// </param>
		/// <param name="RMControl">A pointer to a buffer that receives the resource manager control bits.</param>
		/// <returns>
		/// <para>If the function succeeds, the return value is ERROR_SUCCESS.</para>
		/// <para>If the function fails, the following value is returned.</para>
		/// <list type="table">
		/// <listheader>
		/// <term>Return code</term>
		/// <term>Description</term>
		/// </listheader>
		/// <item>
		/// <term>ERROR_INVALID_DATA</term>
		/// <term>The SE_RM_CONTROL_VALID bit flag is not set in the specified SECURITY_DESCRIPTOR structure.</term>
		/// </item>
		/// </list>
		/// </returns>
		/// <remarks>
		/// The resource manager control bits are eight bits in the <c>Sbz1</c> member of the SECURITY_DESCRIPTOR structure that contains
		/// information specific to the resource manager accessing the structure. These bits should be accessed only through the
		/// <c>GetSecurityDescriptorRMControl</c> and SetSecurityDescriptorRMControl functions.
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows/desktop/api/securitybaseapi/nf-securitybaseapi-getsecuritydescriptorrmcontrol DWORD
		// GetSecurityDescriptorRMControl( PSECURITY_DESCRIPTOR SecurityDescriptor, PUCHAR RMControl );
		[DllImport(Lib.AdvApi32, SetLastError = false, ExactSpelling = true)]
		[PInvokeData("securitybaseapi.h", MSDNShortId = "a1e2ce12-586b-4011-a82d-e246d5544367")]
		public static extern uint GetSecurityDescriptorRMControl(PSECURITY_DESCRIPTOR SecurityDescriptor, out byte RMControl);

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
		public static extern bool GetTokenInformation(HTOKEN hObject, TOKEN_INFORMATION_CLASS tokenInfoClass, IntPtr pTokenInfo, int tokenInfoLength, out int returnLength);

		/// <summary>
		/// The <c>ImpersonateAnonymousToken</c> function enables the specified thread to impersonate the system's anonymous logon token. To
		/// ensure that a token matches the operating system's concept of anonymous access, this function should be called before attempting
		/// network access to generate an anonymous token on the remote server.
		/// </summary>
		/// <param name="ThreadHandle">A handle to the thread to impersonate the system's anonymous logon token.</param>
		/// <returns>
		/// <para>If the function succeeds, the return value is nonzero.</para>
		/// <para>If the function fails, the return value is zero. To get extended error information, call GetLastError.</para>
		/// <para>
		/// An error of ACCESS_DENIED may indicate that the token is for a restricted process. Use OpenProcessToken and IsTokenRestricted to
		/// check if the process is restricted.
		/// </para>
		/// </returns>
		/// <remarks>
		/// <para>
		/// Anonymous tokens do not include the Everyone Group SID unless the system default has been overridden by setting the
		/// HKEY_LOCAL_MACHINE\SYSTEM\CurrentControlSet\Control\Lsa\EveryoneIncludesAnonymous registry value to DWORD=1.
		/// </para>
		/// <para>To cancel the impersonation call RevertToSelf.</para>
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows/desktop/api/securitybaseapi/nf-securitybaseapi-impersonateanonymoustoken BOOL
		// ImpersonateAnonymousToken( HANDLE ThreadHandle );
		[DllImport(Lib.AdvApi32, SetLastError = true, ExactSpelling = true)]
		[PInvokeData("securitybaseapi.h", MSDNShortId = "98d1072e-f569-4c8c-9254-fa558054c7ec")]
		[return: MarshalAs(UnmanagedType.Bool)]
		public static extern bool ImpersonateAnonymousToken(HTHREAD ThreadHandle);

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
		/// The <c>ImpersonateSelf</c> function obtains an access token that impersonates the security context of the calling process. The
		/// token is assigned to the calling thread.
		/// </summary>
		/// <param name="ImpersonationLevel">
		/// Specifies a SECURITY_IMPERSONATION_LEVEL enumerated type that supplies the impersonation level of the new token.
		/// </param>
		/// <returns>
		/// <para>If the function succeeds, the return value is nonzero.</para>
		/// <para>If the function fails, the return value is zero. To get extended error information, call GetLastError.</para>
		/// </returns>
		/// <remarks>
		/// <para>
		/// The <c>ImpersonateSelf</c> function is used for tasks such as enabling a privilege for a single thread rather than for the entire
		/// process or for changing the default discretionary access control list (DACL) for a single thread.
		/// </para>
		/// <para>The server can call the RevertToSelf function when the impersonation is complete.</para>
		/// <para>For this function to succeed, the DACL protecting the process token must grant the TOKEN_DUPLICATE right to itself.</para>
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows/desktop/api/securitybaseapi/nf-securitybaseapi-impersonateself BOOL ImpersonateSelf(
		// SECURITY_IMPERSONATION_LEVEL ImpersonationLevel );
		[DllImport(Lib.AdvApi32, SetLastError = true, ExactSpelling = true)]
		[PInvokeData("securitybaseapi.h", MSDNShortId = "f909e3a7-6c7f-4c05-aa2e-e637113804c9")]
		[return: MarshalAs(UnmanagedType.Bool)]
		public static extern bool ImpersonateSelf(SECURITY_IMPERSONATION_LEVEL ImpersonationLevel);

		/// <summary>The <c>InitializeAcl</c> function initializes a new ACL structure.</summary>
		/// <param name="pAcl">
		/// A pointer to an ACL structure to be initialized by this function. Allocate memory for pAcl before calling this function.
		/// </param>
		/// <param name="nAclLength">
		/// The length, in bytes, of the buffer pointed to by the pAcl parameter. This value must be large enough to contain the ACL header
		/// and all of the access control entries (ACEs) to be stored in the <c>ACL</c>. In addition, this value must be
		/// <c>DWORD</c>-aligned. For more information about calculating the size of an <c>ACL</c>, see Remarks.
		/// </param>
		/// <param name="dwAclRevision">
		/// <para>The revision level of the ACL structure being created.</para>
		/// <para>
		/// This value can be ACL_REVISION or ACL_REVISION_DS. Use ACL_REVISION_DS if the access control list (ACL) supports object-specific ACEs.
		/// </para>
		/// </param>
		/// <returns>
		/// <para>If the function succeeds, the function returns nonzero.</para>
		/// <para>If the function fails, it returns zero. To get extended error information, call GetLastError.</para>
		/// </returns>
		/// <remarks>
		/// <para>
		/// The <c>InitializeAcl</c> function creates an empty ACL structure; the <c>ACL</c> contains no ACEs. Applying an empty <c>ACL</c>
		/// to an object denies all access to that object.
		/// </para>
		/// <para>
		/// The initial size of the ACL depends on the number of ACEs you plan to add to the <c>ACL</c> before you use it. For example, if
		/// the <c>ACL</c> is to contain an ACE for a user and group, you would initialize the <c>ACL</c> based on two ACEs. For details
		/// about modifying an existing <c>ACL</c>, see Modifying the ACLs of an Object.
		/// </para>
		/// <para>To calculate the initial size of an ACL, add the following together, and then align the result to the nearest <c>DWORD</c>:</para>
		/// <list type="bullet">
		/// <item>
		/// <term>Size of the ACL structure.</term>
		/// </item>
		/// <item>
		/// <term>Size of each ACE structure that the ACL is to contain minus the <c>SidStart</c> member ( <c>DWORD</c>) of the ACE.</term>
		/// </item>
		/// <item>
		/// <term>Length of the SID that each ACE is to contain.</term>
		/// </item>
		/// </list>
		/// <para>Examples</para>
		/// <para>
		/// The following example calls the <c>InitializeAcl</c> function. The size of the ACL is based on three allow-access ACEs. As an
		/// option, you can use security descriptor definition language (SDDL) to create the ACL. For details, see Creating a DACL.
		/// </para>
		/// <para>
		/// The example also omits a step for simplification. For more information, see the Taking Object Ownership example. You must call
		/// the FreeSid function at the end of the example code due to calling the AllocateAndInitializeSid function.
		/// </para>
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows/desktop/api/securitybaseapi/nf-securitybaseapi-initializeacl BOOL InitializeAcl( PACL
		// pAcl, DWORD nAclLength, DWORD dwAclRevision );
		[DllImport(Lib.AdvApi32, SetLastError = true, ExactSpelling = true)]
		[PInvokeData("securitybaseapi.h", MSDNShortId = "b990a7bd-7840-4c10-baf8-68b3862147f4")]
		[return: MarshalAs(UnmanagedType.Bool)]
		public static extern bool InitializeAcl(PACL pAcl, uint nAclLength, uint dwAclRevision);

		/// <summary>The <c>InitializeSecurityDescriptor</c> function initializes a new security descriptor.</summary>
		/// <param name="pSecurityDescriptor">A pointer to a SECURITY_DESCRIPTOR structure that the function initializes.</param>
		/// <param name="dwRevision">The revision level to assign to the security descriptor. This parameter must be SECURITY_DESCRIPTOR_REVISION.</param>
		/// <returns>
		/// <para>If the function succeeds, the function returns nonzero.</para>
		/// <para>If the function fails, it returns zero. To get extended error information, call GetLastError.</para>
		/// </returns>
		/// <remarks>
		/// <para>
		/// The <c>InitializeSecurityDescriptor</c> function initializes a security descriptor in absolute format, rather than self-relative format.
		/// </para>
		/// <para>
		/// The <c>InitializeSecurityDescriptor</c> function initializes a security descriptor to have no system access control list (SACL),
		/// no discretionary access control list (DACL), no owner, no primary group, and all control flags set to <c>FALSE</c> (
		/// <c>NULL</c>). Thus, except for its revision level, it is empty.
		/// </para>
		/// <para>Examples</para>
		/// <para>For an example that uses this function, see Creating a Security Descriptor for a New Object.</para>
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows/desktop/api/securitybaseapi/nf-securitybaseapi-initializesecuritydescriptor BOOL
		// InitializeSecurityDescriptor( PSECURITY_DESCRIPTOR pSecurityDescriptor, DWORD dwRevision );
		[DllImport(Lib.AdvApi32, SetLastError = true, ExactSpelling = true)]
		[PInvokeData("securitybaseapi.h", MSDNShortId = "234fcda4-7d30-4c3f-a036-7ace58ca8a3c")]
		[return: MarshalAs(UnmanagedType.Bool)]
		public static extern bool InitializeSecurityDescriptor(PSECURITY_DESCRIPTOR pSecurityDescriptor, uint dwRevision);

		/// <summary>
		/// The <c>InsertAccessAllowedAce</c> function inserts an access-allowed access control entry (ACE) into a discretionary access
		/// control list (DACL).
		/// </summary>
		/// <param name="pAcl">
		/// A pointer to a DACL. The <c>AddAccessAllowedAceEx</c> function adds an access-allowed ACE to the end of this DACL. The ACE is in
		/// the form of an ACCESS_ALLOWED_ACE structure.
		/// </param>
		/// <param name="dwAceRevision">
		/// Specifies the revision level of the DACL being modified. This value can be ACL_REVISION or ACL_REVISION_DS. Use ACL_REVISION_DS
		/// if the DACL contains object-specific ACEs.
		/// </param>
		/// <param name="dwStartingAceIndex">
		/// Specifies the position in the ACL's list of ACEs at which to add new ACEs. A value of zero inserts the ACEs at the beginning of
		/// the list. A value of MAXDWORD appends the ACEs to the end of the list.
		/// </param>
		/// <param name="AceFlags">
		/// <para>
		/// A set of bit flags that control ACE inheritance. The function sets these flags in the <c>AceFlags</c> member of the ACE_HEADER
		/// structure of the new ACE. This parameter can be a combination of the following values.
		/// </para>
		/// <list type="table">
		/// <listheader>
		/// <term>Value</term>
		/// <term>Meaning</term>
		/// </listheader>
		/// <item>
		/// <term>CONTAINER_INHERIT_ACE</term>
		/// <term>The ACE is inherited by container objects.</term>
		/// </item>
		/// <item>
		/// <term>INHERIT_ONLY_ACE</term>
		/// <term>
		/// The ACE does not apply to the object to which the access control list (ACL) is assigned, but it can be inherited by child objects.
		/// </term>
		/// </item>
		/// <item>
		/// <term>INHERITED_ACE</term>
		/// <term>
		/// Indicates an inherited ACE. This flag allows operations that change the security on a tree of objects to modify inherited ACEs
		/// while not changing ACEs that were directly applied to the object.
		/// </term>
		/// </item>
		/// <item>
		/// <term>NO_PROPAGATE_INHERIT_ACE</term>
		/// <term>The OBJECT_INHERIT_ACE and CONTAINER_INHERIT_ACE bits are not propagated to an inherited ACE.</term>
		/// </item>
		/// <item>
		/// <term>OBJECT_INHERIT_ACE</term>
		/// <term>The ACE is inherited by non-container objects.</term>
		/// </item>
		/// </list>
		/// </param>
		/// <param name="AccessMask">
		/// A set of bit flags that use the ACCESS_MASK format. These flags specify the access rights that the new ACE allows for the
		/// specified security identifier (SID).
		/// </param>
		/// <param name="pSid">A pointer to a SID that identifies the user, group, or logon session to which the new ACE allows access.</param>
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
		/// <term>ERROR_INVALID_FLAGS</term>
		/// <term>The AceFlags parameter is not valid.</term>
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
		/// The caller must ensure that ACEs are added to the DACL in the correct order. For more information, see Order of ACEs in a DACL.
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows/desktop/api/securitybaseapi/nf-securitybaseapi-addaccessallowedaceex BOOL
		// AddAccessAllowedAceEx( PACL pAcl, DWORD dwAceRevision, DWORD AceFlags, DWORD AccessMask, PSID pSid );
		[PInvokeData("securitybaseapi.h", MSDNShortId = "6ddec01f-237f-4b6a-8ea8-a126017b30c5")]
		public static bool InsertAccessAllowedAce(PACL pAcl, uint dwAceRevision, uint dwStartingAceIndex, AceFlags AceFlags, ACCESS_MASK AccessMask, PSID pSid)
		{
			using (var aceMem = new SafeHeapBlock(GetRequiredAceSize<ACCESS_ALLOWED_ACE>(pSid, out var offset)))
			{
				// Build ACE
				var ace = new ACCESS_ALLOWED_ACE
				{
					Header = new ACE_HEADER(AceType.AccessAllowed, AceFlags, aceMem.Size),
					Mask = AccessMask
				};
				Marshal.StructureToPtr(ace, aceMem, false);
				if (!CopySid(pSid.Length(), ((IntPtr)aceMem).Offset(offset), pSid))
					return false;
				// Insert
				if (!AddAce(pAcl, dwAceRevision, dwStartingAceIndex, aceMem, aceMem.Size))
					return false;
				return true;
			}
		}

		/// <summary>
		/// The <c>InsertAccessAllowedObjectAce</c> function inserts an access-allowed access control entry (ACE) intto a discretionary
		/// access control list (DACL). The new ACE can grant access to an object, or to a property set or property on an object. You can
		/// also use <c>InsertAccessAllowedObjectAce</c> to add an ACE that only a specified type of child object can inherit.
		/// </summary>
		/// <param name="pAcl">
		/// A pointer to a DACL. The <c>AddAccessAllowedObjectAce</c> function adds an access-allowed ACE to the end of this DACL. The ACE is
		/// in the form of an ACCESS_ALLOWED_OBJECT_ACE structure.
		/// </param>
		/// <param name="dwAceRevision">
		/// Specifies the revision level of the DACL being modified. This value must be ACL_REVISION_DS. If the DACL's revision level is
		/// lower than ACL_REVISION_DS, the function changes it to ACL_REVISION_DS.
		/// </param>
		/// <param name="dwStartingAceIndex">
		/// Specifies the position in the ACL's list of ACEs at which to add new ACEs. A value of zero inserts the ACEs at the beginning of
		/// the list. A value of MAXDWORD appends the ACEs to the end of the list.
		/// </param>
		/// <param name="AceFlags">
		/// <para>
		/// A set of bit flags that control ACE inheritance. The function sets these flags in the <c>AceFlags</c> member of the ACE_HEADER
		/// structure of the new ACE. This parameter can be a combination of the following values.
		/// </para>
		/// <list type="table">
		/// <listheader>
		/// <term>Value</term>
		/// <term>Meaning</term>
		/// </listheader>
		/// <item>
		/// <term>CONTAINER_INHERIT_ACE</term>
		/// <term>The ACE is inherited by container objects.</term>
		/// </item>
		/// <item>
		/// <term>INHERIT_ONLY_ACE</term>
		/// <term>
		/// The ACE does not apply to the object to which the access control list (ACL) is assigned, but it can be inherited by child objects.
		/// </term>
		/// </item>
		/// <item>
		/// <term>INHERITED_ACE</term>
		/// <term>
		/// Indicates an inherited ACE. This flag allows operations that change the security on a tree of objects to modify inherited ACEs,
		/// while not changing ACEs that were directly applied to the object.
		/// </term>
		/// </item>
		/// <item>
		/// <term>NO_PROPAGATE_INHERIT_ACE</term>
		/// <term>The OBJECT_INHERIT_ACE and CONTAINER_INHERIT_ACE bits are not propagated to an inherited ACE.</term>
		/// </item>
		/// <item>
		/// <term>OBJECT_INHERIT_ACE</term>
		/// <term>The ACE is inherited by non-container objects.</term>
		/// </item>
		/// </list>
		/// </param>
		/// <param name="AccessMask">
		/// A set of bit flags that use the ACCESS_MASK format. These flags specify the access rights that the new ACE allows for the
		/// specified security identifier (SID).
		/// </param>
		/// <param name="ObjectTypeGuid">
		/// A pointer to a GUID structure that identifies the type of object, property set, or property protected by the new ACE. If this
		/// parameter is <c>NULL</c>, the new ACE protects the object to which the DACL is assigned.
		/// </param>
		/// <param name="InheritedObjectTypeGuid">
		/// A pointer to a GUID structure that identifies the type of object that can inherit the new ACE. If this parameter is non-
		/// <c>NULL</c>, only the specified object type can inherit the ACE. If <c>NULL</c>, any type of child object can inherit the ACE. In
		/// either case, inheritance is also controlled by the value of the AceFlags parameter, as well as by any protection against
		/// inheritance placed on the child objects.
		/// </param>
		/// <param name="pSid">A pointer to a SID that identifies the user, group, or logon session to which the new ACE allows access.</param>
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
		/// <term>ERROR_INVALID_FLAGS</term>
		/// <term>The AceFlags parameter is not valid.</term>
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
		/// If both ObjectTypeGuid and InheritedObjectTypeGuid are <c>NULL</c>, use the AddAccessAllowedAceEx function rather than
		/// <c>AddAccessAllowedObjectAce</c>. This is suggested because an ACCESS_ALLOWED_ACE is smaller and more efficient than an ACCESS_ALLOWED_OBJECT_ACE.
		/// </para>
		/// <para>
		/// The caller must ensure that ACEs are added to the DACL in the correct order. For more information, see Order of ACEs in a DACL.
		/// </para>
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows/desktop/api/securitybaseapi/nf-securitybaseapi-addaccessallowedobjectace BOOL
		// AddAccessAllowedObjectAce( PACL pAcl, DWORD dwAceRevision, DWORD AceFlags, DWORD AccessMask, GUID *ObjectTypeGuid, GUID
		// *InheritedObjectTypeGuid, PSID pSid );
		[PInvokeData("securitybaseapi.h", MSDNShortId = "ccf83e95-ba6f-49f5-a312-52eac90f209a")]
		public static bool InsertAccessAllowedObjectAce(PACL pAcl, uint dwAceRevision, uint dwStartingAceIndex, AceFlags AceFlags, ACCESS_MASK AccessMask, Guid? ObjectTypeGuid, Guid? InheritedObjectTypeGuid, PSID pSid)
		{
			using (var aceMem = new SafeHeapBlock(GetRequiredAceSize<ACCESS_ALLOWED_OBJECT_ACE>(pSid, out var offset)))
			{
				// Build ACE
				var ace = new ACCESS_ALLOWED_OBJECT_ACE
				{
					Header = new ACE_HEADER(AceType.AccessAllowedObject, AceFlags, aceMem.Size),
					Mask = AccessMask,
					Flags = (ObjectTypeGuid.HasValue ? ObjectAceFlags.ACE_OBJECT_TYPE_PRESENT : 0) | (InheritedObjectTypeGuid.HasValue ? ObjectAceFlags.ACE_INHERITED_OBJECT_TYPE_PRESENT : 0),
					ObjectType = ObjectTypeGuid.GetValueOrDefault(),
					InheritedObjectType = InheritedObjectTypeGuid.GetValueOrDefault(),
				};
				Marshal.StructureToPtr(ace, aceMem, false);
				if (!CopySid(pSid.Length(), ((IntPtr)aceMem).Offset(offset), pSid))
					return false;
				// Insert
				if (!AddAce(pAcl, dwAceRevision, dwStartingAceIndex, aceMem, aceMem.Size))
					return false;
				return true;
			}
		}

		/// <summary>
		/// The <c>InsertAccessDeniedAce</c> function inserts an access-denied access control entry (ACE) into a discretionary access control
		/// list (DACL).
		/// </summary>
		/// <param name="pAcl">A pointer to a DACL. The ACE is in the form of an ACCESS_DENIED_ACE structure.</param>
		/// <param name="dwAceRevision">
		/// Specifies the revision level of the DACL being modified. This value can be ACL_REVISION or ACL_REVISION_DS. Use ACL_REVISION_DS
		/// if the DACL contains object-specific ACEs.
		/// </param>
		/// <param name="dwStartingAceIndex">
		/// Specifies the position in the ACL's list of ACEs at which to add new ACEs. A value of zero inserts the ACEs at the beginning of
		/// the list. A value of MAXDWORD appends the ACEs to the end of the list.
		/// </param>
		/// <param name="AceFlags">
		/// <para>
		/// A set of bit flags that control ACE inheritance. The function sets these flags in the <c>AceFlags</c> member of the ACE_HEADER
		/// structure of the new ACE. This parameter can be a combination of the following values.
		/// </para>
		/// <list type="table">
		/// <listheader>
		/// <term>Value</term>
		/// <term>Meaning</term>
		/// </listheader>
		/// <item>
		/// <term>CONTAINER_INHERIT_ACE</term>
		/// <term>The ACE is inherited by container objects.</term>
		/// </item>
		/// <item>
		/// <term>INHERIT_ONLY_ACE</term>
		/// <term>
		/// The ACE does not apply to the object to which the access control list (ACL) is assigned, but it can be inherited by child objects.
		/// </term>
		/// </item>
		/// <item>
		/// <term>INHERITED_ACE</term>
		/// <term>
		/// Indicates an inherited ACE. This flag allows operations that change the security on a tree of objects to modify inherited ACEs,
		/// while not changing ACEs that were directly applied to the object.
		/// </term>
		/// </item>
		/// <item>
		/// <term>NO_PROPAGATE_INHERIT_ACE</term>
		/// <term>The OBJECT_INHERIT_ACE and CONTAINER_INHERIT_ACE bits are not propagated to an inherited ACE.</term>
		/// </item>
		/// <item>
		/// <term>OBJECT_INHERIT_ACE</term>
		/// <term>The ACE is inherited by non-container objects.</term>
		/// </item>
		/// </list>
		/// </param>
		/// <param name="AccessMask">
		/// A set of bit flags that use the ACCESS_MASK format to specify the access rights that the new ACE denies to the specified security
		/// identifier (SID).
		/// </param>
		/// <param name="pSid">A pointer to a SID that identifies the user, group, or logon session to which the new ACE denies access.</param>
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
		/// <term>ERROR_INVALID_FLAGS</term>
		/// <term>The AceFlags parameter is not valid.</term>
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
		/// Although the <c>AddAccessDeniedAceEx</c> function adds the new ACE to the end of the DACL, access-denied ACEs should appear at
		/// the beginning of a DACL. The caller must ensure that ACEs are added to the DACL in the correct order. For more information, see
		/// Order of ACEs in a DACL.
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows/desktop/api/securitybaseapi/nf-securitybaseapi-addaccessdeniedaceex BOOL
		// AddAccessDeniedAceEx( PACL pAcl, DWORD dwAceRevision, DWORD AceFlags, DWORD AccessMask, PSID pSid );
		[PInvokeData("securitybaseapi.h", MSDNShortId = "e353c88c-f82e-40c0-b676-38f0060acc81")]
		public static bool InsertAccessDeniedAce(PACL pAcl, uint dwAceRevision, uint dwStartingAceIndex, AceFlags AceFlags, ACCESS_MASK AccessMask, PSID pSid)
		{
			using (var aceMem = new SafeHeapBlock(GetRequiredAceSize<ACCESS_DENIED_ACE>(pSid, out var offset)))
			{
				// Build ACE
				var ace = new ACCESS_DENIED_ACE
				{
					Header = new ACE_HEADER(AceType.AccessDenied, AceFlags, aceMem.Size),
					Mask = AccessMask,
				};
				Marshal.StructureToPtr(ace, aceMem, false);
				if (!CopySid(pSid.Length(), ((IntPtr)aceMem).Offset(offset), pSid))
					return false;
				// Insert
				if (!AddAce(pAcl, dwAceRevision, dwStartingAceIndex, aceMem, aceMem.Size))
					return false;
				return true;
			}
		}

		/// <summary>
		/// The <c>InsertAccessDeniedObjectAce</c> function inserts an access-denied access control entry (ACE) into a discretionary access
		/// control list (DACL). The new ACE can deny access to an object, or to a property set or property on an object. You can also use
		/// <c>AddAccessDeniedObjectAce</c> to add an ACE that only a specified type of child object can inherit.
		/// </summary>
		/// <param name="pAcl">
		/// A pointer to a DACL. The <c>AddAccessDeniedObjectAce</c> function adds an access-denied ACE to the end of this DACL. The ACE is
		/// in the form of an ACCESS_DENIED_OBJECT_ACE structure.
		/// </param>
		/// <param name="dwAceRevision">
		/// Specifies the revision level of the DACL being modified. This value must be ACL_REVISION_DS. If the DACL's revision level is
		/// lower than ACL_REVISION_DS, the function changes it to ACL_REVISION_DS.
		/// </param>
		/// <param name="dwStartingAceIndex">
		/// Specifies the position in the ACL's list of ACEs at which to add new ACEs. A value of zero inserts the ACEs at the beginning of
		/// the list. A value of MAXDWORD appends the ACEs to the end of the list.
		/// </param>
		/// <param name="AceFlags">
		/// <para>
		/// A set of bit flags that control ACE inheritance. The function sets these flags in the <c>AceFlags</c> member of the ACE_HEADER
		/// structure of the new ACE. This parameter can be a combination of the following values.
		/// </para>
		/// <list type="table">
		/// <listheader>
		/// <term>Value</term>
		/// <term>Meaning</term>
		/// </listheader>
		/// <item>
		/// <term>CONTAINER_INHERIT_ACE</term>
		/// <term>The ACE is inherited by container objects.</term>
		/// </item>
		/// <item>
		/// <term>INHERIT_ONLY_ACE</term>
		/// <term>
		/// The ACE does not apply to the object to which the access control list (ACL) is assigned, but it can be inherited by child objects.
		/// </term>
		/// </item>
		/// <item>
		/// <term>INHERITED_ACE</term>
		/// <term>
		/// Indicates an inherited ACE. This flag allows operations that change the security on a tree of objects to modify inherited ACEs,
		/// while not changing ACEs that were directly applied to the object.
		/// </term>
		/// </item>
		/// <item>
		/// <term>NO_PROPAGATE_INHERIT_ACE</term>
		/// <term>The OBJECT_INHERIT_ACE and CONTAINER_INHERIT_ACE bits are not propagated to an inherited ACE.</term>
		/// </item>
		/// <item>
		/// <term>OBJECT_INHERIT_ACE</term>
		/// <term>The ACE is inherited by non-container objects.</term>
		/// </item>
		/// </list>
		/// </param>
		/// <param name="AccessMask">
		/// A set of bit flags that use the ACCESS_MASK format to specify the access rights that the new ACE denies to the specified security
		/// identifier (SID).
		/// </param>
		/// <param name="ObjectTypeGuid">
		/// A pointer to a GUID structure that identifies the type of object, property set, or property protected by the new ACE. If this
		/// parameter is <c>NULL</c>, the new ACE protects the object to which the ACL is assigned.
		/// </param>
		/// <param name="InheritedObjectTypeGuid">
		/// A pointer to a GUID structure that identifies the type of object that can inherit the new ACE. If this parameter is non-
		/// <c>NULL</c>, only the specified object type can inherit the ACE. If <c>NULL</c>, any type of child object can inherit the ACE. In
		/// either case, inheritance is also controlled by the value of the AceFlags parameter, as well as by any protection against
		/// inheritance placed on the child objects.
		/// </param>
		/// <param name="pSid">A pointer to a SID that identifies the user, group, or logon session to which the new ACE allows access.</param>
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
		/// <term>ERROR_INVALID_FLAGS</term>
		/// <term>The AceFlags parameter is not valid.</term>
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
		/// If both ObjectTypeGuid and InheritedObjectTypeGuid are <c>NULL</c>, use the AddAccessDeniedAceEx function rather than
		/// <c>AddAccessDeniedObjectAce</c>. This is suggested because an ACCESS_DENIED_ACE is smaller and more efficient than an ACCESS_DENIED_OBJECT_ACE.
		/// </para>
		/// <para>
		/// Although the <c>AddAccessDeniedObjectAce</c> function adds the new ACE to the end of the ACL, access-denied ACEs should appear at
		/// the beginning of an ACL. The caller must ensure that ACEs are added to the DACL in the correct order. For more information, see
		/// Order of ACEs in a DACL.
		/// </para>
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows/desktop/api/securitybaseapi/nf-securitybaseapi-addaccessdeniedobjectace BOOL
		// AddAccessDeniedObjectAce( PACL pAcl, DWORD dwAceRevision, DWORD AceFlags, DWORD AccessMask, GUID *ObjectTypeGuid, GUID
		// *InheritedObjectTypeGuid, PSID pSid );
		[PInvokeData("securitybaseapi.h", MSDNShortId = "1427c908-92b6-46b2-9189-a2fd93c470b1")]
		public static bool InsertAccessDeniedObjectAce(PACL pAcl, uint dwAceRevision, uint dwStartingAceIndex, AceFlags AceFlags, ACCESS_MASK AccessMask, Guid? ObjectTypeGuid, Guid? InheritedObjectTypeGuid, PSID pSid)
		{
			using (var aceMem = new SafeHeapBlock(GetRequiredAceSize<ACCESS_DENIED_OBJECT_ACE>(pSid, out var offset)))
			{
				// Build ACE
				var ace = new ACCESS_DENIED_OBJECT_ACE
				{
					Header = new ACE_HEADER(AceType.AccessDeniedObject, AceFlags, aceMem.Size),
					Mask = AccessMask,
					Flags = (ObjectTypeGuid.HasValue ? ObjectAceFlags.ACE_OBJECT_TYPE_PRESENT : 0) | (InheritedObjectTypeGuid.HasValue ? ObjectAceFlags.ACE_INHERITED_OBJECT_TYPE_PRESENT : 0),
					ObjectType = ObjectTypeGuid.GetValueOrDefault(),
					InheritedObjectType = InheritedObjectTypeGuid.GetValueOrDefault(),
				};
				Marshal.StructureToPtr(ace, aceMem, false);
				if (!CopySid(pSid.Length(), ((IntPtr)aceMem).Offset(offset), pSid))
					return false;
				// Insert
				if (!AddAce(pAcl, dwAceRevision, dwStartingAceIndex, aceMem, aceMem.Size))
					return false;
				return true;
			}
		}

		/// <summary>
		/// The <c>IsTokenRestricted</c> function indicates whether a token contains a list of restricted security identifiers (SIDs).
		/// </summary>
		/// <param name="TokenHandle">A handle to an access token to test.</param>
		/// <returns>
		/// <para>If the token contains a list of restricting SIDs, the return value is nonzero.</para>
		/// <para>If the token does not contain a list of restricting SIDs, the return value is zero.</para>
		/// <para>If an error occurs, the return value is zero. To get extended error information, call GetLastError.</para>
		/// </returns>
		/// <remarks>
		/// The CreateRestrictedToken function can restrict a token by disabling SIDs, deleting privileges, and specifying a list of
		/// restricting SIDs. The <c>IsTokenRestricted</c> function checks only for the list of restricting SIDs. If a token does not have
		/// any restricting SIDs, <c>IsTokenRestricted</c> returns <c>FALSE</c>, even though the token was created by a call to <c>CreateRestrictedToken</c>.
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows/desktop/api/securitybaseapi/nf-securitybaseapi-istokenrestricted BOOL IsTokenRestricted(
		// HANDLE TokenHandle );
		[DllImport(Lib.AdvApi32, SetLastError = true, ExactSpelling = true)]
		[PInvokeData("securitybaseapi.h", MSDNShortId = "eaa63bb9-3084-4246-b2ab-f913bb7348fb")]
		[return: MarshalAs(UnmanagedType.Bool)]
		public static extern bool IsTokenRestricted(HTOKEN TokenHandle);

		/// <summary>The <c>IsValidAcl</c> function validates an access control list (ACL).</summary>
		/// <param name="pAcl">A pointer to an ACL structure validated by this function. This value must not be <c>NULL</c>.</param>
		/// <returns>
		/// <para>If the ACL is valid, the function returns nonzero.</para>
		/// <para>
		/// If the ACL is not valid, the function returns zero. There is no extended error information for this function; do not call GetLastError.
		/// </para>
		/// </returns>
		/// <remarks>
		/// <para>
		/// This function checks the revision level of the ACL and verifies that the number of access control entries (ACEs) specified in the
		/// <c>AceCount</c> member of the ACL structure fits the space specified by the <c>AclSize</c> member of the <c>ACL</c> structure.
		/// </para>
		/// <para>If pAcl is <c>NULL</c>, the application will fail with an access violation.</para>
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows/desktop/api/securitybaseapi/nf-securitybaseapi-isvalidacl BOOL IsValidAcl( PACL pAcl );
		[DllImport(Lib.AdvApi32, SetLastError = true, ExactSpelling = true)]
		[PInvokeData("securitybaseapi.h", MSDNShortId = "3ae9f147-4e90-44df-a1af-cf6ebad92aea")]
		[return: MarshalAs(UnmanagedType.Bool)]
		public static extern bool IsValidAcl(PACL pAcl);

		/// <summary>The <c>IsValidSecurityDescriptor</c> function determines whether the components of a security descriptor are valid.</summary>
		/// <param name="pSecurityDescriptor">A pointer to a SECURITY_DESCRIPTOR structure that the function validates.</param>
		/// <returns>
		/// <para>If the components of the security descriptor are valid, the return value is nonzero.</para>
		/// <para>
		/// If any of the components of the security descriptor are not valid, the return value is zero. There is no extended error
		/// information for this function; do not call GetLastError.
		/// </para>
		/// </returns>
		/// <remarks>
		/// The <c>IsValidSecurityDescriptor</c> function checks the validity of the components that are present in the security descriptor.
		/// It does not verify whether certain components are present nor does it verify the contents of the individual ACE or ACL.
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows/desktop/api/securitybaseapi/nf-securitybaseapi-isvalidsecuritydescriptor BOOL
		// IsValidSecurityDescriptor( PSECURITY_DESCRIPTOR pSecurityDescriptor );
		[DllImport(Lib.AdvApi32, SetLastError = true, ExactSpelling = true)]
		[PInvokeData("securitybaseapi.h", MSDNShortId = "24a98229-11e4-45ef-988b-c2cf831275e7")]
		[return: MarshalAs(UnmanagedType.Bool)]
		public static extern bool IsValidSecurityDescriptor(PSECURITY_DESCRIPTOR pSecurityDescriptor);

		/// <summary>
		/// The <c>MakeAbsoluteSD</c> function creates a security descriptor in absolute format by using a security descriptor in
		/// self-relative format as a template.
		/// </summary>
		/// <param name="pSelfRelativeSecurityDescriptor">
		/// A pointer to a SECURITY_DESCRIPTOR structure in self-relative format. The function creates an absolute-format version of this
		/// security descriptor without modifying the original security descriptor.
		/// </param>
		/// <param name="pAbsoluteSecurityDescriptor">
		/// A pointer to a buffer that the function fills with the main body of an absolute-format security descriptor. This information is
		/// formatted as a SECURITY_DESCRIPTOR structure.
		/// </param>
		/// <param name="lpdwAbsoluteSecurityDescriptorSize">
		/// A pointer to a variable that specifies the size of the buffer pointed to by the pAbsoluteSD parameter. If the buffer is not large
		/// enough for the security descriptor, the function fails and sets this variable to the minimum required size.
		/// </param>
		/// <param name="pDacl">
		/// A pointer to a buffer the function fills with the discretionary access control list (DACL) of the absolute-format security
		/// descriptor. The main body of the absolute-format security descriptor references this pointer.
		/// </param>
		/// <param name="lpdwDaclSize">
		/// A pointer to a variable that specifies the size of the buffer pointed to by the pDacl parameter. If the buffer is not large
		/// enough for the access control list (ACL), the function fails and sets this variable to the minimum required size.
		/// </param>
		/// <param name="pSacl">
		/// A pointer to a buffer the function fills with the system access control list (SACL) of the absolute-format security descriptor.
		/// The main body of the absolute-format security descriptor references this pointer.
		/// </param>
		/// <param name="lpdwSaclSize">
		/// A pointer to a variable that specifies the size of the buffer pointed to by the pSacl parameter. If the buffer is not large
		/// enough for the ACL, the function fails and sets this variable to the minimum required size.
		/// </param>
		/// <param name="pOwner">
		/// A pointer to a buffer the function fills with the security identifier (SID) of the owner of the absolute-format security
		/// descriptor. The main body of the absolute-format security descriptor references this pointer.
		/// </param>
		/// <param name="lpdwOwnerSize">
		/// A pointer to a variable that specifies the size of the buffer pointed to by the pOwner parameter. If the buffer is not large
		/// enough for the SID, the function fails and sets this variable to the minimum required size.
		/// </param>
		/// <param name="pPrimaryGroup">
		/// A pointer to a buffer the function fills with the SID of the absolute-format security descriptor's primary group. The main body
		/// of the absolute-format security descriptor references this pointer.
		/// </param>
		/// <param name="lpdwPrimaryGroupSize">
		/// A pointer to a variable that specifies the size of the buffer pointed to by the pPrimaryGroup parameter. If the buffer is not
		/// large enough for the SID, the function fails and sets this variable to the minimum required size.
		/// </param>
		/// <returns>
		/// <para>If the function succeeds, the function returns nonzero.</para>
		/// <para>
		/// If the function fails, it returns zero. To get extended error information, call GetLastError. Possible return codes include, but
		/// are not limited to, the following.
		/// </para>
		/// <list type="table">
		/// <listheader>
		/// <term>Return code/value</term>
		/// <term>Description</term>
		/// </listheader>
		/// <item>
		/// <term>ERROR_INSUFFICIENT_BUFFER 0x7A</term>
		/// <term>One or more of the buffers is too small.</term>
		/// </item>
		/// </list>
		/// </returns>
		/// <remarks>
		/// <para>
		/// A security descriptor in absolute format contains pointers to the information it contains, rather than the information itself. A
		/// security descriptor in self-relative format contains the information in a contiguous block of memory. In a self-relative security
		/// descriptor, a SECURITY_DESCRIPTOR structure always starts the information, but the security descriptor's other components can
		/// follow the structure in any order. Instead of using memory addresses, the components of the self-relative security descriptor are
		/// identified by offsets from the beginning of the security descriptor. This format is useful when a security descriptor must be
		/// stored on a floppy disk or transmitted by means of a communications protocol.
		/// </para>
		/// <para>
		/// A server that copies secured objects to various media can use the <c>MakeAbsoluteSD</c> function to create an absolute security
		/// descriptor from a self-relative security descriptor and the MakeSelfRelativeSD function to create a self-relative security
		/// descriptor from an absolute security descriptor.
		/// </para>
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows/desktop/api/securitybaseapi/nf-securitybaseapi-makeabsolutesd BOOL MakeAbsoluteSD(
		// PSECURITY_DESCRIPTOR pSelfRelativeSecurityDescriptor, PSECURITY_DESCRIPTOR pAbsoluteSecurityDescriptor, LPDWORD
		// lpdwAbsoluteSecurityDescriptorSize, PACL pDacl, LPDWORD lpdwDaclSize, PACL pSacl, LPDWORD lpdwSaclSize, PSID pOwner, LPDWORD
		// lpdwOwnerSize, PSID pPrimaryGroup, LPDWORD lpdwPrimaryGroupSize );
		[DllImport(Lib.AdvApi32, SetLastError = true, ExactSpelling = true)]
		[PInvokeData("securitybaseapi.h", MSDNShortId = "47c75071-f10d-43cf-a841-2dd49fc39afa")]
		[return: MarshalAs(UnmanagedType.Bool)]
		public static extern bool MakeAbsoluteSD([In] PSECURITY_DESCRIPTOR pSelfRelativeSecurityDescriptor, [In, Out] SafePSECURITY_DESCRIPTOR pAbsoluteSecurityDescriptor, ref uint lpdwAbsoluteSecurityDescriptorSize,
			SafePACL pDacl, ref uint lpdwDaclSize, SafePACL pSacl, ref uint lpdwSaclSize, SafePSID pOwner, ref uint lpdwOwnerSize, SafePSID pPrimaryGroup, ref uint lpdwPrimaryGroupSize);

		/// <summary>
		/// The <c>MakeSelfRelativeSD</c> function creates a security descriptor in self-relative format by using a security descriptor in
		/// absolute format as a template.
		/// </summary>
		/// <param name="pAbsoluteSecurityDescriptor">
		/// A pointer to a SECURITY_DESCRIPTOR structure in absolute format. The function creates a version of this security descriptor in
		/// self-relative format without modifying the original.
		/// </param>
		/// <param name="pSelfRelativeSecurityDescriptor">
		/// A pointer to a buffer the function fills with a security descriptor in self-relative format.
		/// </param>
		/// <param name="lpdwBufferLength">
		/// A pointer to a variable specifying the size of the buffer pointed to by the pSelfRelativeSD parameter. If the buffer is not large
		/// enough for the security descriptor, the function fails and sets this variable to the minimum required size.
		/// </param>
		/// <returns>
		/// <para>If the function succeeds, the return value is nonzero.</para>
		/// <para>
		/// If the function fails, the return value is zero. To get extended error information, call GetLastError. Possible return codes
		/// include, but are not limited to, the following.
		/// </para>
		/// <list type="table">
		/// <listheader>
		/// <term>Return code/value</term>
		/// <term>Description</term>
		/// </listheader>
		/// <item>
		/// <term>ERROR_INSUFFICIENT_BUFFER 0x7A</term>
		/// <term>One or more of the buffers is too small.</term>
		/// </item>
		/// </list>
		/// </returns>
		/// <remarks>
		/// <para>
		/// A security descriptor in absolute format contains pointers to the information it contains, rather than containing the information
		/// itself. A security descriptor in self-relative format contains the information in a contiguous block of memory. In a
		/// self-relative security descriptor, a SECURITY_DESCRIPTOR structure always starts the information, but the security descriptor's
		/// other components can follow the structure in any order. Instead of using memory addresses, the components of the security
		/// descriptor are identified by offsets from the beginning of the security descriptor. This format is useful when a security
		/// descriptor must be stored on a floppy disk or transmitted by means of a communications protocol.
		/// </para>
		/// <para>
		/// A server that copies secured objects to various media can use the <c>MakeSelfRelativeSD</c> function to create a self-relative
		/// security descriptor from an absolute security descriptor and the MakeAbsoluteSD function to create an absolute security
		/// descriptor from a self-relative security descriptor.
		/// </para>
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows/desktop/api/securitybaseapi/nf-securitybaseapi-makeselfrelativesd BOOL
		// MakeSelfRelativeSD( PSECURITY_DESCRIPTOR pAbsoluteSecurityDescriptor, PSECURITY_DESCRIPTOR pSelfRelativeSecurityDescriptor,
		// LPDWORD lpdwBufferLength );
		[DllImport(Lib.AdvApi32, SetLastError = true, ExactSpelling = true)]
		[PInvokeData("securitybaseapi.h", MSDNShortId = "497c7e2f-75b7-41b9-9693-37e041b7af58")]
		[return: MarshalAs(UnmanagedType.Bool)]
		public static extern bool MakeSelfRelativeSD(PSECURITY_DESCRIPTOR pAbsoluteSecurityDescriptor, SafePSECURITY_DESCRIPTOR pSelfRelativeSecurityDescriptor, ref uint lpdwBufferLength);

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
		public static extern void MapGenericMask(ref ACCESS_MASK AccessMask, in GENERIC_MAPPING GenericMapping);

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
			[In, Out, MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef = typeof(PRIVILEGE_SET.Marshaler))] PRIVILEGE_SET RequiredPrivileges,
			[MarshalAs(UnmanagedType.Bool)] out bool pfResult);

		/// <summary>
		/// The <c>QuerySecurityAccessMask</c> function creates an access mask that represents the access permissions necessary to query the
		/// specified object security information.
		/// </summary>
		/// <param name="SecurityInformation">A SECURITY_INFORMATION structure that specifies the security information to be queried.</param>
		/// <param name="DesiredAccess">A pointer to the access mask that this function creates.</param>
		// https://docs.microsoft.com/en-us/windows/desktop/api/securitybaseapi/nf-securitybaseapi-querysecurityaccessmask void
		// QuerySecurityAccessMask( SECURITY_INFORMATION SecurityInformation, LPDWORD DesiredAccess );
		[DllImport(Lib.AdvApi32, SetLastError = false, ExactSpelling = true)]
		[PInvokeData("securitybaseapi.h", MSDNShortId = "70379640-28b7-4503-9ba8-789786078d4a")]
		public static extern void QuerySecurityAccessMask(SECURITY_INFORMATION SecurityInformation, out ACCESS_MASK DesiredAccess);

		/// <summary>The RevertToSelf function terminates the impersonation of a client application.</summary>
		/// <returns>
		/// If the function succeeds, the function returns nonzero. If the function fails, it returns zero. To get extended error
		/// information, call GetLastError.
		/// </returns>
		[DllImport(Lib.AdvApi32, ExactSpelling = true, SetLastError = true)]
		[return: MarshalAs(UnmanagedType.Bool)]
		[PInvokeData("securitybaseapi.h", MSDNShortId = "aa379317")]
		public static extern bool RevertToSelf();

		/// <summary>The <c>SetAclInformation</c> function sets information about an access control list (ACL).</summary>
		/// <param name="pAcl">A pointer to an ACL. The function sets information in this ACL.</param>
		/// <param name="pAclInformation">
		/// A pointer to a buffer that contains the information to be set. This must be a pointer to an ACL_REVISION_INFORMATION structure.
		/// </param>
		/// <param name="nAclInformationLength">The size, in bytes, of the buffer pointed to by the pAclInfo parameter.</param>
		/// <param name="dwAclInformationClass">
		/// <para>An ACL_INFORMATION_CLASS enumerated type that gives the class of information requested.</para>
		/// <para>
		/// Currently, this parameter can be <c>AclRevisionInformation</c>. This means that the buffer pointed to by the pAclInformation
		/// parameter contains an ACL_REVISION_INFORMATION structure.
		/// </para>
		/// </param>
		/// <returns>
		/// <para>If the function succeeds, the function returns nonzero.</para>
		/// <para>If the function fails, it returns zero. To get extended error information, call GetLastError.</para>
		/// </returns>
		// https://docs.microsoft.com/en-us/windows/desktop/api/securitybaseapi/nf-securitybaseapi-setaclinformation BOOL SetAclInformation(
		// PACL pAcl, LPVOID pAclInformation, DWORD nAclInformationLength, ACL_INFORMATION_CLASS dwAclInformationClass );
		[DllImport(Lib.AdvApi32, SetLastError = true, ExactSpelling = true)]
		[PInvokeData("securitybaseapi.h", MSDNShortId = "bb4dd7f9-2f15-4a27-89c9-1675f4fb8d92")]
		[return: MarshalAs(UnmanagedType.Bool)]
		public static extern bool SetAclInformation(PACL pAcl, in ACL_REVISION_INFORMATION pAclInformation, uint nAclInformationLength = 4, ACL_INFORMATION_CLASS dwAclInformationClass = ACL_INFORMATION_CLASS.AclRevisionInformation);

		/// <summary>The <c>SetAclInformation</c> function sets information about an access control list (ACL).</summary>
		/// <param name="pAcl">A pointer to an ACL. The function sets information in this ACL.</param>
		/// <param name="pAclInformation">
		/// A pointer to a buffer that contains the information to be set. This must be a pointer to an ACL_REVISION_INFORMATION structure.
		/// </param>
		/// <param name="nAclInformationLength">The size, in bytes, of the buffer pointed to by the pAclInfo parameter.</param>
		/// <param name="dwAclInformationClass">
		/// <para>An ACL_INFORMATION_CLASS enumerated type that gives the class of information requested.</para>
		/// <para>
		/// Currently, this parameter can be <c>AclRevisionInformation</c>. This means that the buffer pointed to by the pAclInformation
		/// parameter contains an ACL_REVISION_INFORMATION structure.
		/// </para>
		/// </param>
		/// <returns>
		/// <para>If the function succeeds, the function returns nonzero.</para>
		/// <para>If the function fails, it returns zero. To get extended error information, call GetLastError.</para>
		/// </returns>
		// https://docs.microsoft.com/en-us/windows/desktop/api/securitybaseapi/nf-securitybaseapi-setaclinformation BOOL SetAclInformation(
		// PACL pAcl, LPVOID pAclInformation, DWORD nAclInformationLength, ACL_INFORMATION_CLASS dwAclInformationClass );
		[DllImport(Lib.AdvApi32, SetLastError = true, ExactSpelling = true)]
		[PInvokeData("securitybaseapi.h", MSDNShortId = "bb4dd7f9-2f15-4a27-89c9-1675f4fb8d92")]
		[return: MarshalAs(UnmanagedType.Bool)]
		public static extern bool SetAclInformation(PACL pAcl, IntPtr pAclInformation, uint nAclInformationLength, ACL_INFORMATION_CLASS dwAclInformationClass);

		/// <summary>
		/// The <c>SetKernelObjectSecurity</c> function sets the security of a kernel object. For example, this can be a process, thread, or event.
		/// </summary>
		/// <param name="Handle">A handle to a kernel object for which security information is set.</param>
		/// <param name="SecurityInformation">
		/// A set of bit flags that indicate the type of security information to set. This parameter can be a combination of the
		/// SECURITY_INFORMATION bit flags.
		/// </param>
		/// <param name="SecurityDescriptor">A pointer to a SECURITY_DESCRIPTOR structure that contains the new security information.</param>
		/// <returns>
		/// <para>If the function succeeds, the function returns nonzero.</para>
		/// <para>If the function fails, it returns zero. To get extended error information, call GetLastError.</para>
		/// </returns>
		// https://docs.microsoft.com/en-us/windows/desktop/api/securitybaseapi/nf-securitybaseapi-setkernelobjectsecurity BOOL
		// SetKernelObjectSecurity( HANDLE Handle, SECURITY_INFORMATION SecurityInformation, PSECURITY_DESCRIPTOR SecurityDescriptor );
		[DllImport(Lib.AdvApi32, SetLastError = true, ExactSpelling = true)]
		[PInvokeData("securitybaseapi.h", MSDNShortId = "2a70483e-245d-4bc7-b90a-58d143364ce1")]
		[return: MarshalAs(UnmanagedType.Bool)]
		public static extern bool SetKernelObjectSecurity(HANDLE Handle, SECURITY_INFORMATION SecurityInformation, PSECURITY_DESCRIPTOR SecurityDescriptor);

		/// <summary>
		/// <para>The <c>SetPrivateObjectSecurity</c> function modifies a private object's security descriptor.</para>
		/// <para>
		/// To specify whether the protected server supports automatic inheritance of access control entries (ACEs), use the
		/// SetPrivateObjectSecurityEx function.
		/// </para>
		/// </summary>
		/// <param name="SecurityInformation">
		/// Indicates the parts of the security descriptor to set. This value can be a combination of the SECURITY_INFORMATION bit flags.
		/// </param>
		/// <param name="ModificationDescriptor">
		/// A pointer to a SECURITY_DESCRIPTOR structure. The parts of this security descriptor indicated by the SecurityInformation
		/// parameter are applied to the ObjectsSecurityDescriptor security descriptor.
		/// </param>
		/// <param name="ObjectsSecurityDescriptor">
		/// <para>
		/// A pointer to a pointer to a SECURITY_DESCRIPTOR structure. This security descriptor must be in self-relative form. <c>The memory
		/// for the security descriptor must be allocated from the process heap (GetProcessHeap) with the HeapAlloc function.</c>
		/// </para>
		/// <para>
		/// On input, this is the current security descriptor of the private object. The function modifies it to produce the new security
		/// descriptor. If necessary, the <c>SetPrivateObjectSecurity</c> function allocates additional memory to produce a larger security descriptor.
		/// </para>
		/// </param>
		/// <param name="GenericMapping">
		/// A pointer to a GENERIC_MAPPING structure that specifies the specific and standard access rights that correspond to each of the
		/// generic access rights.
		/// </param>
		/// <param name="Token">
		/// A handle to the access token for the client on whose behalf the private object's security is being modified. This parameter is
		/// required to ensure that the client has provided a legitimate value for a new owner security identifier (SID). The token must be
		/// open for TOKEN_QUERY access.
		/// </param>
		/// <returns>
		/// <para>If the function succeeds, the function returns nonzero.</para>
		/// <para>If the function fails, it returns zero. To get extended error information, call GetLastError.</para>
		/// </returns>
		/// <remarks>
		/// <para>
		/// This function is intended for use by resource managers only. To implement the standard access control semantics for updating
		/// security descriptors, a resource manager should verify that the following conditions are met before calling <c>SetPrivateObjectSecurity</c>:
		/// </para>
		/// <list type="bullet">
		/// <item>
		/// <term>If the object's owner is being set, the calling process must have either WRITE_OWNER permission or be the object's owner.</term>
		/// </item>
		/// <item>
		/// <term>
		/// If the object's discretionary access control list (DACL) is being set, the calling process must have either WRITE_DAC permission
		/// or be the object's owner.
		/// </term>
		/// </item>
		/// <item>
		/// <term>
		/// If the object's system access control list (SACL) is being set, the SE_SECURITY_NAME privilege must be enabled for the calling process.
		/// </term>
		/// </item>
		/// </list>
		/// <para>
		/// If the preceding conditions are not met, a call to this function does not fail; however, standard access policy is not enforced.
		/// </para>
		/// <para>
		/// The process calling this function should not be impersonating a client because clients do not typically have appropriate
		/// privileges required for underlying token operations.
		/// </para>
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows/desktop/api/securitybaseapi/nf-securitybaseapi-setprivateobjectsecurity BOOL
		// SetPrivateObjectSecurity( SECURITY_INFORMATION SecurityInformation, PSECURITY_DESCRIPTOR ModificationDescriptor,
		// PSECURITY_DESCRIPTOR *ObjectsSecurityDescriptor, PGENERIC_MAPPING GenericMapping, HANDLE Token );
		[DllImport(Lib.AdvApi32, SetLastError = true, ExactSpelling = true)]
		[PInvokeData("securitybaseapi.h", MSDNShortId = "726994c8-7813-4f1a-b7d7-a25e79202c33")]
		[return: MarshalAs(UnmanagedType.Bool)]
		public static extern bool SetPrivateObjectSecurity(SECURITY_INFORMATION SecurityInformation, PSECURITY_DESCRIPTOR ModificationDescriptor, ref PSECURITY_DESCRIPTOR ObjectsSecurityDescriptor, in GENERIC_MAPPING GenericMapping, HTOKEN Token);

		/// <summary>
		/// <para>The <c>SetPrivateObjectSecurity</c> function modifies a private object's security descriptor.</para>
		/// <para>
		/// To specify whether the protected server supports automatic inheritance of access control entries (ACEs), use the
		/// SetPrivateObjectSecurityEx function.
		/// </para>
		/// </summary>
		/// <param name="SecurityInformation">
		/// Indicates the parts of the security descriptor to set. This value can be a combination of the SECURITY_INFORMATION bit flags.
		/// </param>
		/// <param name="ModificationDescriptor">
		/// A pointer to a SECURITY_DESCRIPTOR structure. The parts of this security descriptor indicated by the SecurityInformation
		/// parameter are applied to the ObjectsSecurityDescriptor security descriptor.
		/// </param>
		/// <param name="ObjectsSecurityDescriptor">
		/// <para>
		/// A pointer to a pointer to a SECURITY_DESCRIPTOR structure. This security descriptor must be in self-relative form. <c>The memory
		/// for the security descriptor must be allocated from the process heap (GetProcessHeap) with the HeapAlloc function.</c>
		/// </para>
		/// <para>
		/// On input, this is the current security descriptor of the private object. The function modifies it to produce the new security
		/// descriptor. If necessary, the <c>SetPrivateObjectSecurity</c> function allocates additional memory to produce a larger security descriptor.
		/// </para>
		/// </param>
		/// <param name="GenericMapping">
		/// A pointer to a GENERIC_MAPPING structure that specifies the specific and standard access rights that correspond to each of the
		/// generic access rights.
		/// </param>
		/// <param name="Token">
		/// A handle to the access token for the client on whose behalf the private object's security is being modified. This parameter is
		/// required to ensure that the client has provided a legitimate value for a new owner security identifier (SID). The token must be
		/// open for TOKEN_QUERY access.
		/// </param>
		/// <returns>
		/// <para>If the function succeeds, the function returns nonzero.</para>
		/// <para>If the function fails, it returns zero. To get extended error information, call GetLastError.</para>
		/// </returns>
		/// <remarks>
		/// <para>
		/// This function is intended for use by resource managers only. To implement the standard access control semantics for updating
		/// security descriptors, a resource manager should verify that the following conditions are met before calling <c>SetPrivateObjectSecurity</c>:
		/// </para>
		/// <list type="bullet">
		/// <item>
		/// <term>If the object's owner is being set, the calling process must have either WRITE_OWNER permission or be the object's owner.</term>
		/// </item>
		/// <item>
		/// <term>
		/// If the object's discretionary access control list (DACL) is being set, the calling process must have either WRITE_DAC permission
		/// or be the object's owner.
		/// </term>
		/// </item>
		/// <item>
		/// <term>
		/// If the object's system access control list (SACL) is being set, the SE_SECURITY_NAME privilege must be enabled for the calling process.
		/// </term>
		/// </item>
		/// </list>
		/// <para>
		/// If the preceding conditions are not met, a call to this function does not fail; however, standard access policy is not enforced.
		/// </para>
		/// <para>
		/// The process calling this function should not be impersonating a client because clients do not typically have appropriate
		/// privileges required for underlying token operations.
		/// </para>
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows/desktop/api/securitybaseapi/nf-securitybaseapi-setprivateobjectsecurity BOOL
		// SetPrivateObjectSecurity( SECURITY_INFORMATION SecurityInformation, PSECURITY_DESCRIPTOR ModificationDescriptor,
		// PSECURITY_DESCRIPTOR *ObjectsSecurityDescriptor, PGENERIC_MAPPING GenericMapping, HANDLE Token );
		[DllImport(Lib.AdvApi32, SetLastError = true, ExactSpelling = true)]
		[PInvokeData("securitybaseapi.h", MSDNShortId = "726994c8-7813-4f1a-b7d7-a25e79202c33")]
		[return: MarshalAs(UnmanagedType.Bool)]
		public static extern bool SetPrivateObjectSecurity(SECURITY_INFORMATION SecurityInformation, PSECURITY_DESCRIPTOR ModificationDescriptor, ref IntPtr ObjectsSecurityDescriptor, in GENERIC_MAPPING GenericMapping, HTOKEN Token);

		/// <summary>
		/// The <c>SetPrivateObjectSecurityEx</c> function modifies the security descriptor of a private object maintained by the resource
		/// manager calling this function. The <c>SetPrivateObjectSecurityEx</c> function has a flags parameter that specifies whether the
		/// resource manager supports automatic inheritance of access control entries (ACEs).
		/// </summary>
		/// <param name="SecurityInformation">
		/// The parts of the security descriptor to set. This value can be a combination of the SECURITY_INFORMATION bit flags.
		/// </param>
		/// <param name="ModificationDescriptor">
		/// A pointer to a SECURITY_DESCRIPTOR structure. The parts of this security descriptor indicated by the SecurityInformation
		/// parameter are applied to the ObjectsSecurityDescriptor security descriptor.
		/// </param>
		/// <param name="ObjectsSecurityDescriptor">
		/// <para>
		/// A pointer to a pointer to a SECURITY_DESCRIPTOR structure. This security descriptor must be in self-relative form. <c>The memory
		/// for the security descriptor must be allocated from the process heap (GetProcessHeap) with the HeapAlloc function.</c>
		/// </para>
		/// <para>
		/// On input, this is the current security descriptor of the private object. The function modifies it to produce the new security
		/// descriptor. If necessary, the <c>SetPrivateObjectSecurityEx</c> function allocates additional memory to produce a larger security descriptor.
		/// </para>
		/// </param>
		/// <param name="AutoInheritFlags">
		/// <para>
		/// Specifies automatic inheritance of ACEs. If the protected server does not implement automatic inheritance, it should specify
		/// zero; otherwise, it can specify a combination of the following values, defined in Winnt.h.
		/// </para>
		/// <list type="table">
		/// <listheader>
		/// <term>Value</term>
		/// <term>Meaning</term>
		/// </listheader>
		/// <item>
		/// <term>SEF_DACL_AUTO_INHERIT 0x01</term>
		/// <term>
		/// The new discretionary access control list (DACL) contains ACEs inherited from the DACL of the object's parent, as well as any
		/// explicit ACEs specified in the DACL of ModificationDescriptor. If this flag is not set, the new DACL does not inherit ACEs.
		/// </term>
		/// </item>
		/// <item>
		/// <term>SEF_SACL_AUTO_INHERIT 0x02</term>
		/// <term>
		/// The new system access control list (SACL) contains ACEs inherited from the SACL of the security descriptor associated with the
		/// object's parent, as well as any explicit ACEs specified in the SACL of ModificationDescriptor. If this flag is not set, the new
		/// SACL does not inherit ACEs.
		/// </term>
		/// </item>
		/// <item>
		/// <term>SEF_AVOID_PRIVILEGE_CHECK 0x08</term>
		/// <term>
		/// The function does not perform privilege checking. If the SEF_AVOID_OWNER_CHECK flag is also set, the Token parameter can be NULL.
		/// Use this flag when implementing automatic inheritance to avoid checking privileges on each child updated.
		/// </term>
		/// </item>
		/// <item>
		/// <term>SEF_AVOID_OWNER_CHECK 0x10</term>
		/// <term>
		/// The function does not check the validity of the owner in the resultant ObjectsSecurityDescriptor as described in Remarks. If the
		/// SEF_AVOID_PRIVILEGE_CHECK flag is also set, the Token parameter can be NULL.
		/// </term>
		/// </item>
		/// <item>
		/// <term>SEF_DEFAULT_OWNER_FROM_PARENT 0x20</term>
		/// <term>
		/// The owner of ObjectsSecurityDescriptor defaults to the owner of the object's parent. If this flag is not set, the owner of
		/// ObjectsSecurityDescriptor defaults to the owner of the token specified by the Token parameter. The owner of the token is
		/// specified in the token itself. In either case, if the ModificationDescriptor parameter is not NULL, the ObjectsSecurityDescriptor
		/// owner is set to the owner from ModificationDescriptor.
		/// </term>
		/// </item>
		/// <item>
		/// <term>SEF_DEFAULT_GROUP_FROM_PARENT 0x40</term>
		/// <term>
		/// The group of ObjectsSecurityDescriptor defaults to the group from the owner of the object's parent. If this flag is not set, the
		/// group of ObjectsSecurityDescriptor defaults to the group of the token specified by the Token parameter. The group of the token is
		/// specified in the token itself. In either case, if the ModificationDescriptor parameter is not NULL, the ObjectsSecurityDescriptor
		/// group is set to the group from ModificationDescriptor.
		/// </term>
		/// </item>
		/// <item>
		/// <term>SEF_MACL_NO_WRITE_UP 0x100</term>
		/// <term>A principal with a mandatory level lower than that of the object cannot write to the object.</term>
		/// </item>
		/// <item>
		/// <term>SEF_MACL_NO_READ_UP 0x200</term>
		/// <term>A principal with a mandatory level lower than that of the object cannot read the object.</term>
		/// </item>
		/// <item>
		/// <term>SEF_MACL_NO_EXECUTE_UP 0x400</term>
		/// <term>A principal with a mandatory level lower than that of the object cannot execute the object.</term>
		/// </item>
		/// <item>
		/// <term>SEF_AVOID_OWNER_RESTRICTION 0x1000</term>
		/// <term>
		/// Any restrictions specified by the owner of the object's parent that would limit the caller's ability to specify a DACL in the
		/// ObjectsSecurityDescriptor are ignored.
		/// </term>
		/// </item>
		/// </list>
		/// </param>
		/// <param name="GenericMapping">
		/// A pointer to a GENERIC_MAPPING structure that specifies the specific and standard access rights that correspond to each of the
		/// generic access rights.
		/// </param>
		/// <param name="Token">
		/// Identifies the access token for the client on whose behalf the private object's security is being modified. This parameter is
		/// required to ensure that the client has provided a legitimate value for a new owner security identifier (SID). The token must be
		/// open for TOKEN_QUERY access.
		/// </param>
		/// <returns>
		/// <para>If the function succeeds, the function returns nonzero.</para>
		/// <para>If the function fails, it returns zero. To get extended error information, call GetLastError.</para>
		/// </returns>
		/// <remarks>
		/// <para>
		/// If the AutoInheritFlags parameter is zero, <c>SetPrivateObjectSecurityEx</c> is identical to the SetPrivateObjectSecurity function.
		/// </para>
		/// <para>
		/// This function is intended for use by resource managers only. To implement the standard Windows access control semantics for
		/// updating security descriptors, a resource manager should verify that the following conditions are met before calling <c>SetPrivateObjectSecurityEx</c>:
		/// </para>
		/// <list type="bullet">
		/// <item>
		/// <term>If the object's owner is being set, the calling process must have either WRITE_OWNER permission or be the object's owner.</term>
		/// </item>
		/// <item>
		/// <term>If the object's DACL is being set, the calling process must have either WRITE_DAC permission or be the object's owner.</term>
		/// </item>
		/// <item>
		/// <term>If the object's SACL is being set, the SE_SECURITY_NAME privilege must be enabled for the calling process.</term>
		/// </item>
		/// </list>
		/// <para>
		/// If the preceding conditions are not met, a call to this function does not fail, however, standard Windows access policy is not enforced.
		/// </para>
		/// <para>
		/// The process calling this function should not be impersonating a client because clients do not typically have appropriate
		/// privileges required for underlying token operations.
		/// </para>
		/// <para>
		/// If AutoInheritFlags specifies the SEF_DACL_AUTO_INHERIT bit, the function applies the following rules to the DACL to create the
		/// new security descriptor from the current descriptor:
		/// </para>
		/// <list type="bullet">
		/// <item>
		/// <term>
		/// If the SE_DACL_PROTECTED flag is not set in the control bits of either the current security descriptor or the
		/// ModificationDescriptor, the function constructs the output security descriptor from the inherited ACEs of the current security
		/// descriptor and noninherited ACEs of ModificationDescriptor. That is, it is impossible to change an inherited ACE by changing the
		/// access control list (ACL) on an object. This behavior preserves the inherited ACEs as they were inherited from the parent container.
		/// </term>
		/// </item>
		/// <item>
		/// <term>
		/// If SE_DACL_PROTECTED is set in ModificationDescriptor, the current security descriptor is ignored. The output security descriptor
		/// is built as a copy of ModificationDescriptor with any INHERITED_ACE bits turned off.
		/// </term>
		/// </item>
		/// <item>
		/// <term>
		/// If SE_DACL_PROTECTED is set in the current security descriptor and not in ModificationDescriptor, the current security descriptor
		/// is ignored. The output security descriptor is built as a copy of ModificationDescriptor. It is the caller's responsibility to
		/// ensure that the correct ACEs have the INHERITED_ACE bit turned on.
		/// </term>
		/// </item>
		/// </list>
		/// <para>If AutoInheritFlags specifies the SEF_SACL_AUTO_INHERIT bit, the function applies similar rules to the new SACL.</para>
		/// <para>
		/// For both DACLs and SACLs, certain types of ACEs in the input ObjectsSecurityDescriptor and in ModificationDescriptor will be
		/// replaced by two ACEs in the output ObjectsSecurityDescriptor. Specifically, an inheritable ACE that contains at least one of the
		/// following mappable elements will result in two ACEs in the output ObjectsSecurityDescriptor. Mappable elements include:
		/// </para>
		/// <list type="bullet">
		/// <item>
		/// <term>Generic access rights in the ACCESS_MASK structure</term>
		/// </item>
		/// <item>
		/// <term>Creator Owner SID or Creator Group SID as the ACE subject identifier</term>
		/// </item>
		/// </list>
		/// <para>ACEs with any of these mappable elements will result in the following two ACEs in the output ObjectsSecurityDescriptor:</para>
		/// <list type="bullet">
		/// <item>
		/// <term>An ACE that is a copy of the original, but with the INHERIT_ONLY flag set</term>
		/// </item>
		/// <item>
		/// <term>An ACE in which the INHERITED_ACE bit is turned on and the generic elements are mapped to specific elements:</term>
		/// </item>
		/// </list>
		/// <para>
		/// If AutoInheritFlags does not specify the SEF_AVOID_PRIVILEGE_CHECK bit, owner validity checking is performed according to the
		/// following rules. The Owner in ModificationDescriptor:
		/// </para>
		/// <list type="bullet">
		/// <item>
		/// <term>Must be a legally formed SID</term>
		/// </item>
		/// <item>
		/// <term>Must match the TokenUser in Token</term>
		/// </item>
		/// </list>
		/// <para>Or</para>
		/// <list type="bullet">
		/// <item>
		/// <term>Must match a group in the TokenGroups in Token where the attributes on the group:</term>
		/// </item>
		/// </list>
		/// <para>
		/// A resource manager that is setting the Owner on a subtree of objects can avoid the overhead of redundant owner validity checking.
		/// If the Owner in ModificationDescriptor and Token remain the same for iterative calls to this function, the
		/// SEF_AVOID_PRIVILEGE_CHECK bit may be set in AutoInheritFlags for calls subsequent to an initial call in which owner validity
		/// checking is performed. Callers that do not have access to the token of the client that will ultimately be setting the owner
		/// should also choose to skip owner validation checking.
		/// </para>
		/// <para>
		/// <c>Note</c> The SEF_AVOID_PRIVILEGE_CHECK bit as used in the <c>SetPrivateObjectSecurityEx</c> function is equivalent to the
		/// SEF_AVOID_OWNER_CHECK bit used in the CreatePrivateObjectSecurityEx function.
		/// </para>
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows/desktop/api/securitybaseapi/nf-securitybaseapi-setprivateobjectsecurityex BOOL
		// SetPrivateObjectSecurityEx( SECURITY_INFORMATION SecurityInformation, PSECURITY_DESCRIPTOR ModificationDescriptor,
		// PSECURITY_DESCRIPTOR *ObjectsSecurityDescriptor, ULONG AutoInheritFlags, PGENERIC_MAPPING GenericMapping, HANDLE Token );
		[DllImport(Lib.AdvApi32, SetLastError = true, ExactSpelling = true)]
		[PInvokeData("securitybaseapi.h", MSDNShortId = "eb3a751f-741e-448f-b812-5f16a4040b5e")]
		[return: MarshalAs(UnmanagedType.Bool)]
		public static extern bool SetPrivateObjectSecurityEx(SECURITY_INFORMATION SecurityInformation, PSECURITY_DESCRIPTOR ModificationDescriptor, ref PSECURITY_DESCRIPTOR ObjectsSecurityDescriptor, SEF AutoInheritFlags, in GENERIC_MAPPING GenericMapping, HTOKEN Token);

		/// <summary>
		/// The <c>SetSecurityAccessMask</c> function creates an access mask that represents the access permissions necessary to set the
		/// specified object security information.
		/// </summary>
		/// <param name="SecurityInformation">A SECURITY_INFORMATION structure that specifies the security information to be set.</param>
		/// <param name="DesiredAccess">A pointer to the access mask that this function creates.</param>
		// https://docs.microsoft.com/en-us/windows/desktop/api/securitybaseapi/nf-securitybaseapi-setsecurityaccessmask void
		// SetSecurityAccessMask( SECURITY_INFORMATION SecurityInformation, LPDWORD DesiredAccess );
		[DllImport(Lib.AdvApi32, SetLastError = false, ExactSpelling = true)]
		[PInvokeData("securitybaseapi.h", MSDNShortId = "764a4e93-0865-49f8-9b3a-1a178073454d")]
		public static extern void SetSecurityAccessMask(SECURITY_INFORMATION SecurityInformation, out ACCESS_MASK DesiredAccess);

		/// <summary>
		/// The <c>SetSecurityDescriptorControl</c> function sets the control bits of a security descriptor. The function can set only the
		/// control bits that relate to automatic inheritance of ACEs. To set the other control bits of a security descriptor, use the
		/// functions, such as SetSecurityDescriptorDacl, for modifying the components of a security descriptor.
		/// </summary>
		/// <param name="pSecurityDescriptor">A pointer to a SECURITY_DESCRIPTOR structure whose control and revision information are set.</param>
		/// <param name="ControlBitsOfInterest">A SECURITY_DESCRIPTOR_CONTROL mask that indicates the control bits to set.</param>
		/// <param name="ControlBitsToSet">
		/// A SECURITY_DESCRIPTOR_CONTROL mask that indicates the new values for the control bits specified by the ControlBitsOfInterest mask.
		/// </param>
		/// <returns>
		/// <para>If the function succeeds, the return value is nonzero.</para>
		/// <para>If the function fails, the return value is zero. To get extended error information, call GetLastError.</para>
		/// </returns>
		/// <remarks>
		/// <para>
		/// The <c>SetSecurityDescriptorControl</c> function specifies the control bit or bits to modify, and whether the bits are on or off.
		/// </para>
		/// <para>Examples</para>
		/// <para>The following example marks the DACL on the security descriptor as protected.</para>
		/// <para>The following example marks the DACL as not protected.</para>
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows/desktop/api/securitybaseapi/nf-securitybaseapi-setsecuritydescriptorcontrol BOOL
		// SetSecurityDescriptorControl( PSECURITY_DESCRIPTOR pSecurityDescriptor, SECURITY_DESCRIPTOR_CONTROL ControlBitsOfInterest,
		// SECURITY_DESCRIPTOR_CONTROL ControlBitsToSet );
		[DllImport(Lib.AdvApi32, SetLastError = true, ExactSpelling = true)]
		[PInvokeData("securitybaseapi.h", MSDNShortId = "672406af-ae04-4939-82a4-069a91e61b3f")]
		[return: MarshalAs(UnmanagedType.Bool)]
		public static extern bool SetSecurityDescriptorControl(PSECURITY_DESCRIPTOR pSecurityDescriptor, SECURITY_DESCRIPTOR_CONTROL ControlBitsOfInterest, SECURITY_DESCRIPTOR_CONTROL ControlBitsToSet);

		/// <summary>
		/// The <c>SetSecurityDescriptorDacl</c> function sets information in a discretionary access control list (DACL). If a DACL is
		/// already present in the security descriptor, the DACL is replaced.
		/// </summary>
		/// <param name="pSecurityDescriptor">
		/// A pointer to the SECURITY_DESCRIPTOR structure to which the function adds the DACL. This security descriptor must be in absolute
		/// format, meaning that its members must be pointers to other structures, rather than offsets to contiguous data.
		/// </param>
		/// <param name="bDaclPresent">
		/// A flag that indicates the presence of a DACL in the security descriptor. If this parameter is <c>TRUE</c>, the function sets the
		/// SE_DACL_PRESENT flag in the SECURITY_DESCRIPTOR_CONTROL structure and uses the values in the pDacl and bDaclDefaulted parameters.
		/// If this parameter is <c>FALSE</c>, the function clears the SE_DACL_PRESENT flag, and pDacl and bDaclDefaulted are ignored.
		/// </param>
		/// <param name="pDacl">
		/// A pointer to an ACL structure that specifies the DACL for the security descriptor. If this parameter is <c>NULL</c>, a
		/// <c>NULL</c> DACL is assigned to the security descriptor, which allows all access to the object. The DACL is referenced by, not
		/// copied into, the security descriptor.
		/// </param>
		/// <param name="bDaclDefaulted">
		/// A flag that indicates the source of the DACL. If this flag is <c>TRUE</c>, the DACL has been retrieved by some default mechanism.
		/// If <c>FALSE</c>, the DACL has been explicitly specified by a user. The function stores this value in the SE_DACL_DEFAULTED flag
		/// of the SECURITY_DESCRIPTOR_CONTROL structure. If this parameter is not specified, the SE_DACL_DEFAULTED flag is cleared.
		/// </param>
		/// <returns>
		/// <para>If the function succeeds, the function returns nonzero.</para>
		/// <para>If the function fails, it returns zero. To get extended error information, call GetLastError.</para>
		/// </returns>
		/// <remarks>
		/// <para>
		/// There is an important difference between an empty and a nonexistent DACL. When a DACL is empty, it contains no access control
		/// entries (ACEs); therefore, no access rights are explicitly granted. As a result, access to the object is implicitly denied.
		/// </para>
		/// <para>
		/// When an object has no DACL (when the pDacl parameter is <c>NULL</c>), no protection is assigned to the object, and all access
		/// requests are granted. To help maintain security, restrict access by using a DACL.
		/// </para>
		/// <para>There are three possible outcomes in different configurations of the bDaclPresent flag and the pDacl parameter:</para>
		/// <list type="bullet">
		/// <item>
		/// <term>
		/// When the pDacl parameter points to a DACL and the bDaclPresent flag is <c>TRUE</c>, a DACL is specified and it must contain
		/// access-allowed ACEs to allow access to the object.
		/// </term>
		/// </item>
		/// <item>
		/// <term>
		/// When the pDacl parameter does not point to a DACL and the bDaclPresent flag is <c>TRUE</c>, a <c>NULL</c> DACL is specified. All
		/// access is allowed. You should not use a <c>NULL</c> DACL with an object because any user can change the DACL and owner of the
		/// security descriptor. This will interfere with use of the object.
		/// </term>
		/// </item>
		/// <item>
		/// <term>
		/// When the pDacl parameter does not point to a DACL and the bDaclPresent flag is <c>FALSE</c>, a DACL can be provided for the
		/// object through an inheritance or default mechanism.
		/// </term>
		/// </item>
		/// </list>
		/// <para>Examples</para>
		/// <para>For an example that uses this function, see Creating a Security Descriptor for a New Object.</para>
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows/desktop/api/securitybaseapi/nf-securitybaseapi-setsecuritydescriptordacl BOOL
		// SetSecurityDescriptorDacl( PSECURITY_DESCRIPTOR pSecurityDescriptor, BOOL bDaclPresent, PACL pDacl, BOOL bDaclDefaulted );
		[DllImport(Lib.AdvApi32, SetLastError = true, ExactSpelling = true)]
		[PInvokeData("securitybaseapi.h", MSDNShortId = "a873b803-391e-47e1-af7e-6dad7195968c")]
		[return: MarshalAs(UnmanagedType.Bool)]
		public static extern bool SetSecurityDescriptorDacl(PSECURITY_DESCRIPTOR pSecurityDescriptor, [MarshalAs(UnmanagedType.Bool)] bool bDaclPresent, PACL pDacl, [MarshalAs(UnmanagedType.Bool)] bool bDaclDefaulted);

		/// <summary>
		/// The <c>SetSecurityDescriptorGroup</c> function sets the primary group information of an absolute-format security descriptor,
		/// replacing any primary group information already present in the security descriptor.
		/// </summary>
		/// <param name="pSecurityDescriptor">
		/// A pointer to the SECURITY_DESCRIPTOR structure whose primary group is set by this function. The function replaces any existing
		/// primary group with the new primary group.
		/// </param>
		/// <param name="pGroup">
		/// A pointer to a SID structure for the security descriptor's new primary group. The <c>SID</c> structure is referenced by, not
		/// copied into, the security descriptor. If this parameter is <c>NULL</c>, the function clears the security descriptor's primary
		/// group information. This marks the security descriptor as having no primary group.
		/// </param>
		/// <param name="bGroupDefaulted">
		/// Indicates whether the primary group information was derived from a default mechanism. If this value is <c>TRUE</c>, it is default
		/// information, and the function stores this value as the SE_GROUP_DEFAULTED flag in the SECURITY_DESCRIPTOR_CONTROL structure. If
		/// this parameter is zero, the SE_GROUP_DEFAULTED flag is cleared.
		/// </param>
		/// <returns>
		/// <para>If the function succeeds, the return value is nonzero.</para>
		/// <para>If the function fails, the return value is zero. To get extended error information, call GetLastError.</para>
		/// </returns>
		// https://docs.microsoft.com/en-us/windows/desktop/api/securitybaseapi/nf-securitybaseapi-setsecuritydescriptorgroup BOOL
		// SetSecurityDescriptorGroup( PSECURITY_DESCRIPTOR pSecurityDescriptor, PSID pGroup, BOOL bGroupDefaulted );
		[DllImport(Lib.AdvApi32, SetLastError = true, ExactSpelling = true)]
		[PInvokeData("securitybaseapi.h", MSDNShortId = "060c375c-a313-4fa2-8d85-cee9369c26a8")]
		[return: MarshalAs(UnmanagedType.Bool)]
		public static extern bool SetSecurityDescriptorGroup(PSECURITY_DESCRIPTOR pSecurityDescriptor, PSID pGroup, [MarshalAs(UnmanagedType.Bool)] bool bGroupDefaulted);

		/// <summary>
		/// The <c>SetSecurityDescriptorOwner</c> function sets the owner information of an absolute-format security descriptor. It replaces
		/// any owner information already present in the security descriptor.
		/// </summary>
		/// <param name="pSecurityDescriptor">
		/// A pointer to the SECURITY_DESCRIPTOR structure whose owner is set by this function. The function replaces any existing owner with
		/// the new owner.
		/// </param>
		/// <param name="pOwner">
		/// A pointer to a SID structure for the security descriptor's new primary owner. The <c>SID</c> structure is referenced by, not
		/// copied into, the security descriptor. If this parameter is <c>NULL</c>, the function clears the security descriptor's owner
		/// information. This marks the security descriptor as having no owner.
		/// </param>
		/// <param name="bOwnerDefaulted">
		/// Indicates whether the owner information is derived from a default mechanism. If this value is <c>TRUE</c>, it is default
		/// information. The function stores this value as the SE_OWNER_DEFAULTED flag in the SECURITY_DESCRIPTOR_CONTROL structure. If this
		/// parameter is zero, the SE_OWNER_DEFAULTED flag is cleared.
		/// </param>
		/// <returns>
		/// <para>If the function succeeds, the return value is nonzero.</para>
		/// <para>If the function fails, the return value is zero. To get extended error information, call GetLastError.</para>
		/// </returns>
		// https://docs.microsoft.com/en-us/windows/desktop/api/securitybaseapi/nf-securitybaseapi-setsecuritydescriptorowner BOOL
		// SetSecurityDescriptorOwner( PSECURITY_DESCRIPTOR pSecurityDescriptor, PSID pOwner, BOOL bOwnerDefaulted );
		[DllImport(Lib.AdvApi32, SetLastError = true, ExactSpelling = true)]
		[PInvokeData("securitybaseapi.h", MSDNShortId = "cb3ba617-322a-4b8c-a9d5-32910315fb56")]
		[return: MarshalAs(UnmanagedType.Bool)]
		public static extern bool SetSecurityDescriptorOwner(PSECURITY_DESCRIPTOR pSecurityDescriptor, PSID pOwner, [MarshalAs(UnmanagedType.Bool)] bool bOwnerDefaulted);

		/// <summary>
		/// The <c>SetSecurityDescriptorRMControl</c> function sets the resource manager control bits in the SECURITY_DESCRIPTOR structure.
		/// </summary>
		/// <param name="SecurityDescriptor">A pointer to a SECURITY_DESCRIPTOR structure that contains the resource manager control bits.</param>
		/// <param name="RMControl">
		/// A pointer to the bitfield value that the resource manager control bits in the SECURITY_DESCRIPTOR structure will be set to. If
		/// the value of this parameter is <c>NULL</c>, the resource manager control bits will be cleared.
		/// </param>
		/// <returns>The return value is ERROR_SUCCESS.</returns>
		/// <remarks>
		/// The resource manager control bits are eight bits in the <c>Sbz1</c> member of the SECURITY_INFORMATION structure that contains
		/// information specific to the resource manager accessing the structure. These bits should be accessed only through the
		/// GetSecurityDescriptorRMControl and <c>SetSecurityDescriptorRMControl</c> functions.
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows/desktop/api/securitybaseapi/nf-securitybaseapi-setsecuritydescriptorrmcontrol DWORD
		// SetSecurityDescriptorRMControl( PSECURITY_DESCRIPTOR SecurityDescriptor, PUCHAR RMControl );
		[DllImport(Lib.AdvApi32, SetLastError = false, ExactSpelling = true)]
		[PInvokeData("securitybaseapi.h", MSDNShortId = "fe9c736b-e047-4aa3-a3de-d5f2f2cdab4f")]
		public static extern uint SetSecurityDescriptorRMControl(PSECURITY_DESCRIPTOR SecurityDescriptor, in byte RMControl);

		/// <summary>
		/// The <c>SetSecurityDescriptorSacl</c> function sets information in a system access control list (SACL). If there is already a SACL
		/// present in the security descriptor, it is replaced.
		/// </summary>
		/// <param name="pSecurityDescriptor">
		/// A pointer to the SECURITY_DESCRIPTOR structure to which the function adds the SACL. This security descriptor must be in absolute
		/// format, meaning that its members must be pointers to other structures, rather than offsets to contiguous data.
		/// </param>
		/// <param name="bSaclPresent">
		/// Indicates the presence of a SACL in the security descriptor. If this parameter is <c>TRUE</c>, the function sets the
		/// SE_SACL_PRESENT flag in the SECURITY_DESCRIPTOR_CONTROL structure and uses the values in the pSacl and bSaclDefaulted parameters.
		/// If it is <c>FALSE</c>, the function does not set the SE_SACL_PRESENT flag, and pSacl and bSaclDefaulted are ignored.
		/// </param>
		/// <param name="pSacl">
		/// A pointer to an ACL structure that specifies the SACL for the security descriptor. If this parameter is <c>NULL</c>, a
		/// <c>NULL</c> SACL is assigned to the security descriptor. The SACL is referenced by, not copied into, the security descriptor.
		/// </param>
		/// <param name="bSaclDefaulted">
		/// Indicates the source of the SACL. If this flag is <c>TRUE</c>, the SACL has been retrieved by some default mechanism. If it is
		/// <c>FALSE</c>, the SACL has been explicitly specified by a user. The function stores this value in the SE_SACL_DEFAULTED flag of
		/// the SECURITY_DESCRIPTOR_CONTROL structure. If this parameter is not specified, the SE_SACL_DEFAULTED flag is cleared.
		/// </param>
		/// <returns>
		/// <para>If the function succeeds, the function returns nonzero.</para>
		/// <para>If the function fails, it returns zero. To get extended error information, call GetLastError.</para>
		/// </returns>
		// https://docs.microsoft.com/en-us/windows/desktop/api/securitybaseapi/nf-securitybaseapi-setsecuritydescriptorsacl BOOL
		// SetSecurityDescriptorSacl( PSECURITY_DESCRIPTOR pSecurityDescriptor, BOOL bSaclPresent, PACL pSacl, BOOL bSaclDefaulted );
		[DllImport(Lib.AdvApi32, SetLastError = true, ExactSpelling = true)]
		[PInvokeData("securitybaseapi.h", MSDNShortId = "21615b63-0619-4c0c-a1b8-88ed09a1235c")]
		[return: MarshalAs(UnmanagedType.Bool)]
		public static extern bool SetSecurityDescriptorSacl(PSECURITY_DESCRIPTOR pSecurityDescriptor, [MarshalAs(UnmanagedType.Bool)] bool bSaclPresent, PACL pSacl, [MarshalAs(UnmanagedType.Bool)] bool bSaclDefaulted);

		/// <summary>
		/// The <c>SetTokenInformation</c> function sets various types of information for a specified access token. The information that this
		/// function sets replaces existing information. The calling process must have appropriate access rights to set the information.
		/// </summary>
		/// <param name="TokenHandle">A handle to the access token for which information is to be set.</param>
		/// <param name="TokenInformationClass">
		/// A value from the TOKEN_INFORMATION_CLASS enumerated type that identifies the type of information the function sets. The valid
		/// values from <c>TOKEN_INFORMATION_CLASS</c> are described in the TokenInformation parameter.
		/// </param>
		/// <param name="TokenInformation">
		/// A pointer to a buffer that contains the information set in the access token. The structure of this buffer depends on the type of
		/// information specified by the TokenInformationClass parameter.
		/// </param>
		/// <param name="TokenInformationLength">Specifies the length, in bytes, of the buffer pointed to by TokenInformation.</param>
		/// <returns>
		/// <para>If the function succeeds, the function returns nonzero.</para>
		/// <para>If the function fails, it returns zero. To get extended error information, call GetLastError.</para>
		/// </returns>
		/// <remarks>
		/// <para>
		/// To set privilege information, an application can call the AdjustTokenPrivileges function. To set a token's groups, an application
		/// can call the AdjustTokenGroups function.
		/// </para>
		/// <para>Token-type information can be set only when an access token is created.</para>
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows/desktop/api/securitybaseapi/nf-securitybaseapi-settokeninformation BOOL
		// SetTokenInformation( HANDLE TokenHandle, TOKEN_INFORMATION_CLASS TokenInformationClass, LPVOID TokenInformation, DWORD
		// TokenInformationLength );
		[DllImport(Lib.AdvApi32, SetLastError = true, ExactSpelling = true)]
		[PInvokeData("securitybaseapi.h", MSDNShortId = "cdb8af74-540d-4059-ac64-6243f6aabaa6")]
		[return: MarshalAs(UnmanagedType.Bool)]
		public static extern bool SetTokenInformation(HTOKEN TokenHandle, TOKEN_INFORMATION_CLASS TokenInformationClass, IntPtr TokenInformation, uint TokenInformationLength);

		/// <summary>
		/// The <c>SetTokenInformation</c> function sets various types of information for a specified access token. The information that this
		/// function sets replaces existing information. The calling process must have appropriate access rights to set the information.
		/// </summary>
		/// <param name="TokenHandle">A handle to the access token for which information is to be set.</param>
		/// <param name="TokenInformationClass">
		/// A value from the TOKEN_INFORMATION_CLASS enumerated type that identifies the type of information the function sets. The valid
		/// values from <c>TOKEN_INFORMATION_CLASS</c> are described in the TokenInformation parameter.
		/// </param>
		/// <param name="TokenInformation">
		/// A value that contains the information set in the access token. The structure of this buffer depends on the type of information
		/// specified by the TokenInformationClass parameter.
		/// </param>
		/// <returns>
		/// <para>If the function succeeds, the function returns nonzero.</para>
		/// <para>If the function fails, it returns zero. To get extended error information, call GetLastError.</para>
		/// </returns>
		/// <remarks>
		/// <para>
		/// To set privilege information, an application can call the AdjustTokenPrivileges function. To set a token's groups, an application
		/// can call the AdjustTokenGroups function.
		/// </para>
		/// <para>Token-type information can be set only when an access token is created.</para>
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows/desktop/api/securitybaseapi/nf-securitybaseapi-settokeninformation BOOL
		// SetTokenInformation( HANDLE TokenHandle, TOKEN_INFORMATION_CLASS TokenInformationClass, LPVOID TokenInformation, DWORD
		// TokenInformationLength );
		[PInvokeData("securitybaseapi.h", MSDNShortId = "cdb8af74-540d-4059-ac64-6243f6aabaa6")]
		public static bool SetTokenInformation<T>(HTOKEN TokenHandle, TOKEN_INFORMATION_CLASS TokenInformationClass, T TokenInformation)
		{
			if (!CorrespondingTypeAttribute.CanSet(TokenInformationClass, typeof(T))) throw new InvalidCastException();
			using (var mem = SafeHGlobalHandle.CreateFromStructure(TokenInformation))
				return SetTokenInformation(TokenHandle, TokenInformationClass, mem, mem.Size);
		}

		internal static int GetSize<T>() where T : struct
		{
			if (!StructSizes.TryGetValue(typeof(T), out var sz))
				StructSizes.Add(typeof(T), sz = Marshal.SizeOf(typeof(T)));
			return sz;
		}

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

#if NETSTANDARD2_0 || NETCOREAPP2_0 || NETCOREAPP2_1
			public static explicit operator Microsoft.Win32.SafeHandles.SafeAccessTokenHandle(SafeHTOKEN h)
			{
				var dup = h.DuplicatePrimary();
				var ret = new Microsoft.Win32.SafeHandles.SafeAccessTokenHandle(dup.DangerousGetHandle());
				dup.ReleaseHandle();
				return ret;
			}
#endif

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
				if (!CorrespondingTypeAttribute.CanGet(tokenInfoClass, typeof(T)))
					throw new InvalidCastException();
				using (var pType = GetInfo(tokenInfoClass))
				{
					if (tokenInfoClass == TOKEN_INFORMATION_CLASS.TokenPrivileges && typeof(T) == typeof(PTOKEN_PRIVILEGES))
						return (T)(object)PTOKEN_PRIVILEGES.FromPtr(pType);
					return ((IntPtr)pType).Convert<T>(pType.Size);
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
				if (!GetTokenInformation(this, tokenInfoClass, SafeCoTaskMemHandle.Null, 0, out var cbSize))
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

			/// <summary>
			/// The <c>SetInfo</c> function sets various types of information for a specified access token. The information that this
			/// function sets replaces existing information. The calling process must have appropriate access rights to set the information.
			/// </summary>
			/// <param name="TokenInformationClass">
			/// A value from the TOKEN_INFORMATION_CLASS enumerated type that identifies the type of information the function sets. The valid
			/// values from <c>TOKEN_INFORMATION_CLASS</c> are described in the TokenInformation parameter.
			/// </param>
			/// <param name="TokenInformation">
			/// A value that contains the information set in the access token. The structure of this buffer depends on the type of
			/// information specified by the TokenInformationClass parameter.
			/// </param>
			/// <returns>
			/// <para>If the function succeeds, the function returns nonzero.</para>
			/// <para>If the function fails, it returns zero. To get extended error information, call GetLastError.</para>
			/// </returns>
			/// <remarks>
			/// <para>
			/// To set privilege information, an application can call the AdjustTokenPrivileges function. To set a token's groups, an
			/// application can call the AdjustTokenGroups function.
			/// </para>
			/// <para>Token-type information can be set only when an access token is created.</para>
			/// </remarks>
			// https://docs.microsoft.com/en-us/windows/desktop/api/securitybaseapi/nf-securitybaseapi-settokeninformation BOOL
			// SetTokenInformation( HANDLE TokenHandle, TOKEN_INFORMATION_CLASS TokenInformationClass, LPVOID TokenInformation, DWORD
			// TokenInformationLength );
			public bool SetInfo<T>(TOKEN_INFORMATION_CLASS TokenInformationClass, T TokenInformation) => SetTokenInformation(this, TokenInformationClass, TokenInformation);
		}

		/// <summary>Provides a <see cref="SafeHandle"/> for <see cref="SECURITY_DESCRIPTOR"/> that is disposed using <see cref="DestroyPrivateObjectSecurity"/>.</summary>
		public class SafePrivateObjectSecurity : SafeHANDLE
		{
			/// <summary>Initializes a new instance of the <see cref="SafePrivateObjectSecurity"/> class and assigns an existing handle.</summary>
			/// <param name="preexistingHandle">An <see cref="IntPtr"/> object that represents the pre-existing handle to use.</param>
			/// <param name="ownsHandle">
			/// <see langword="true"/> to reliably release the handle during the finalization phase; otherwise, <see langword="false"/> (not recommended).
			/// </param>
			public SafePrivateObjectSecurity(IntPtr preexistingHandle, bool ownsHandle = true) : base(preexistingHandle, ownsHandle) { }

			/// <summary>Initializes a new instance of the <see cref="SafePrivateObjectSecurity"/> class.</summary>
			private SafePrivateObjectSecurity() : base() { }

			/// <summary>Performs an implicit conversion from <see cref="SafePrivateObjectSecurity"/> to <see cref="SECURITY_DESCRIPTOR"/>.</summary>
			/// <param name="h">The safe handle instance.</param>
			/// <returns>The result of the conversion.</returns>
			public static implicit operator PSECURITY_DESCRIPTOR(SafePrivateObjectSecurity h) => h.handle;

			/// <summary>Gets the raw handle instance for this SafeHandle. Be very careful!!. This should only be used with <see cref="SetPrivateObjectSecurity(SECURITY_INFORMATION, PSECURITY_DESCRIPTOR, ref IntPtr, in GENERIC_MAPPING, HTOKEN)"/>.</summary>
			/// <returns>The native handle, usually retrieved by <see cref="CreatePrivateObjectSecurity"/>.</returns>
			public ref IntPtr DangerousGetRefHandle() => ref handle;

			/// <inheritdoc/>
			protected override bool InternalReleaseHandle() => DestroyPrivateObjectSecurity(this);
		}
	}
}