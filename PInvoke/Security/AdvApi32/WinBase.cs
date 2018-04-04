using System;
using System.ComponentModel;
using System.Linq;
using System.Runtime.ConstrainedExecution;
using System.Runtime.InteropServices;
using System.Text;
using Vanara.InteropServices;

namespace Vanara.PInvoke
{
	public static partial class AdvApi32
	{
		/// <summary>Specifies the logon provider.</summary>
		public enum LogonUserProvider
		{
			/// <summary>
			/// Use the standard logon provider for the system. The default security provider is negotiate, unless you pass NULL for the domain name and the user
			/// name is not in UPN format. In this case, the default provider is NTLM.
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
			/// This logon type is intended for users who will be interactively using the computer, such as a user being logged on by a terminal server, remote
			/// shell, or similar process. This logon type has the additional expense of caching logon information for disconnected operations; therefore, it is
			/// inappropriate for some client/server applications, such as a mail server.
			/// </summary>
			LOGON32_LOGON_INTERACTIVE = 2,

			/// <summary>
			/// This logon type is intended for high performance servers to authenticate plaintext passwords. The LogonUser function does not cache credentials
			/// for this logon type.
			/// </summary>
			LOGON32_LOGON_NETWORK = 3,

			/// <summary>
			/// This logon type is intended for batch servers, where processes may be executing on behalf of a user without their direct intervention. This type
			/// is also for higher performance servers that process many plaintext authentication attempts at a time, such as mail or web servers.
			/// </summary>
			LOGON32_LOGON_BATCH = 4,

			/// <summary>Indicates a service-type logon. The account provided must have the service privilege enabled.</summary>
			LOGON32_LOGON_SERVICE = 5,

			/// <summary>
			/// GINAs are no longer supported.
			/// <para>
			/// <c>Windows Server 2003 and Windows XP:</c> This logon type is for GINA DLLs that log on users who will be interactively using the computer. This
			/// logon type can generate a unique audit record that shows when the workstation was unlocked.
			/// </para>
			/// </summary>
			LOGON32_LOGON_UNLOCK = 7,

			/// <summary>
			/// This logon type preserves the name and password in the authentication package, which allows the server to make connections to other network
			/// servers while impersonating the client. A server can accept plain-text credentials from a client, call LogonUser, verify that the user can access
			/// the system across the network, and still communicate with other servers.
			/// </summary>
			LOGON32_LOGON_NETWORK_CLEARTEXT = 8,

			/// <summary>
			/// This logon type allows the caller to clone its current token and specify new credentials for outbound connections. The new logon session has the
			/// same local identifier but uses different credentials for other network connections. This logon type is supported only by the
			/// LOGON32_PROVIDER_WINNT50 logon provider.
			/// </summary>
			LOGON32_LOGON_NEW_CREDENTIALS = 9
		}

		/// <summary>
		/// The AdjustTokenPrivileges function enables or disables privileges in the specified access token. Enabling or disabling privileges in an access token
		/// requires TOKEN_ADJUST_PRIVILEGES access.
		/// </summary>
		/// <param name="objectHandle">
		/// A handle to the access token that contains the privileges to be modified. The handle must have TOKEN_ADJUST_PRIVILEGES access to the token. If the
		/// PreviousState parameter is not NULL, the handle must also have TOKEN_QUERY access.
		/// </param>
		/// <param name="DisableAllPrivileges">
		/// Specifies whether the function disables all of the token's privileges. If this value is TRUE, the function disables all privileges and ignores the
		/// NewState parameter. If it is FALSE, the function modifies privileges based on the information pointed to by the NewState parameter.
		/// </param>
		/// <param name="NewState">
		/// A pointer to a TOKEN_PRIVILEGES structure that specifies an array of privileges and their attributes. If DisableAllPrivileges is TRUE, the function
		/// ignores this parameter. If the DisableAllPrivileges parameter is FALSE, the AdjustTokenPrivileges function enables, disables, or removes these
		/// privileges for the token. The following table describes the action taken by the AdjustTokenPrivileges function, based on the privilege attribute.
		/// </param>
		/// <param name="BufferLength">
		/// Specifies the size, in bytes, of the buffer pointed to by the PreviousState parameter. This parameter can be zero if the PreviousState parameter is NULL.
		/// </param>
		/// <param name="PreviousState">
		/// A pointer to a buffer that the function fills with a TOKEN_PRIVILEGES structure that contains the previous state of any privileges that the function
		/// modifies. That is, if a privilege has been modified by this function, the privilege and its previous state are contained in the TOKEN_PRIVILEGES
		/// structure referenced by PreviousState. If the PrivilegeCount member of TOKEN_PRIVILEGES is zero, then no privileges have been changed by this
		/// function. This parameter can be NULL.
		/// <para>
		/// If you specify a buffer that is too small to receive the complete list of modified privileges, the function fails and does not adjust any privileges.
		/// In this case, the function sets the variable pointed to by the ReturnLength parameter to the number of bytes required to hold the complete list of
		/// modified privileges.
		/// </para>
		/// </param>
		/// <param name="ReturnLength">
		/// A pointer to a variable that receives the required size, in bytes, of the buffer pointed to by the PreviousState parameter. This parameter can be
		/// NULL if PreviousState is NULL.
		/// </param>
		/// <returns>
		/// If the function succeeds, the return value is nonzero. To determine whether the function adjusted all of the specified privileges, call GetLastError,
		/// which returns either ERROR_SUCCESS, indicating that the function adjusted all specified privileges, or ERROR_NOT_ALL_ASSIGNED, indicating that the
		/// token does not have one or more of the privileges specified in the NewState parameter. The function may succeed with this error value even if no
		/// privileges were adjusted. The PreviousState parameter indicates the privileges that were adjusted.
		/// <para>If the function fails, the return value is zero. To get extended error information, call GetLastError.</para>
		/// </returns>
		[ReliabilityContract(Consistency.WillNotCorruptState, Cer.MayFail), DllImport(Lib.AdvApi32, ExactSpelling = true, SetLastError = true)]
		[return: MarshalAs(UnmanagedType.Bool)]
		[PInvokeData("winbase.h", MSDNShortId = "aa375202")]
		public static extern bool AdjustTokenPrivileges([In] SafeTokenHandle objectHandle,
			[In, MarshalAs(UnmanagedType.Bool)] bool DisableAllPrivileges,
			[MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef = typeof(PTOKEN_PRIVILEGES.Marshaler))] PTOKEN_PRIVILEGES NewState,
			[In] uint BufferLength,
			[In, Out] SafeCoTaskMemHandle PreviousState,
			//[MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef = typeof(PTOKEN_PRIVILEGES.Marshaler), MarshalCookie = "Out")] PTOKEN_PRIVILEGES PreviousState,
			[In, Out] ref uint ReturnLength);

		/// <summary>
		/// The AdjustTokenPrivileges function enables or disables privileges in the specified access token. Enabling or disabling privileges in an access token
		/// requires TOKEN_ADJUST_PRIVILEGES access.
		/// </summary>
		/// <param name="objectHandle">
		/// A handle to the access token that contains the privileges to be modified. The handle must have TOKEN_ADJUST_PRIVILEGES access to the token. If the
		/// PreviousState parameter is not NULL, the handle must also have TOKEN_QUERY access.
		/// </param>
		/// <param name="DisableAllPrivileges">
		/// Specifies whether the function disables all of the token's privileges. If this value is TRUE, the function disables all privileges and ignores the
		/// NewState parameter. If it is FALSE, the function modifies privileges based on the information pointed to by the NewState parameter.
		/// </param>
		/// <param name="NewState">
		/// A pointer to a TOKEN_PRIVILEGES structure that specifies an array of privileges and their attributes. If DisableAllPrivileges is TRUE, the function
		/// ignores this parameter. If the DisableAllPrivileges parameter is FALSE, the AdjustTokenPrivileges function enables, disables, or removes these
		/// privileges for the token. The following table describes the action taken by the AdjustTokenPrivileges function, based on the privilege attribute.
		/// </param>
		/// <param name="BufferLength">
		/// Specifies the size, in bytes, of the buffer pointed to by the PreviousState parameter. This parameter can be zero if the PreviousState parameter is NULL.
		/// </param>
		/// <param name="PreviousState">
		/// A pointer to a buffer that the function fills with a TOKEN_PRIVILEGES structure that contains the previous state of any privileges that the function
		/// modifies. That is, if a privilege has been modified by this function, the privilege and its previous state are contained in the TOKEN_PRIVILEGES
		/// structure referenced by PreviousState. If the PrivilegeCount member of TOKEN_PRIVILEGES is zero, then no privileges have been changed by this
		/// function. This parameter can be NULL.
		/// <para>
		/// If you specify a buffer that is too small to receive the complete list of modified privileges, the function fails and does not adjust any privileges.
		/// In this case, the function sets the variable pointed to by the ReturnLength parameter to the number of bytes required to hold the complete list of
		/// modified privileges.
		/// </para>
		/// </param>
		/// <param name="ReturnLength">
		/// A pointer to a variable that receives the required size, in bytes, of the buffer pointed to by the PreviousState parameter. This parameter can be
		/// NULL if PreviousState is NULL.
		/// </param>
		/// <returns>
		/// If the function succeeds, the return value is nonzero. To determine whether the function adjusted all of the specified privileges, call GetLastError,
		/// which returns either ERROR_SUCCESS, indicating that the function adjusted all specified privileges, or ERROR_NOT_ALL_ASSIGNED, indicating that the
		/// token does not have one or more of the privileges specified in the NewState parameter. The function may succeed with this error value even if no
		/// privileges were adjusted. The PreviousState parameter indicates the privileges that were adjusted.
		/// <para>If the function fails, the return value is zero. To get extended error information, call GetLastError.</para>
		/// </returns>
		[ReliabilityContract(Consistency.WillNotCorruptState, Cer.MayFail), DllImport(Lib.AdvApi32, ExactSpelling = true, SetLastError = true)]
		[return: MarshalAs(UnmanagedType.Bool)]
		[PInvokeData("winbase.h", MSDNShortId = "aa375202")]
		public static extern bool AdjustTokenPrivileges([In] SafeTokenHandle objectHandle,
			[In, MarshalAs(UnmanagedType.Bool)] bool DisableAllPrivileges, [In] SafeCoTaskMemHandle NewState,
			[In] uint BufferLength, [In, Out] SafeCoTaskMemHandle PreviousState, [In, Out] ref uint ReturnLength);

		/// <summary>The AllocateLocallyUniqueId function allocates a locally unique identifier (LUID).</summary>
		/// <param name="Luid">A pointer to a LUID structure that receives the allocated LUID.</param>
		/// <para>If the function fails, the return value is zero. To get extended error information, call GetLastError.</para>
		[DllImport(Lib.AdvApi32, SetLastError = true, ExactSpelling = true)]
		[return: MarshalAs(UnmanagedType.Bool)]
		public static extern bool AllocateLocallyUniqueId(out LUID Luid);

		/// <summary>The DuplicateToken function creates a new access token that duplicates one already in existence.</summary>
		/// <param name="existingObjectHandle">A handle to an access token opened with TOKEN_DUPLICATE access.</param>
		/// <param name="ImpersonationLevel">Specifies a SECURITY_IMPERSONATION_LEVEL enumerated type that supplies the impersonation level of the new token.</param>
		/// <param name="duplicateObjectHandle">
		/// A pointer to a variable that receives a handle to the duplicate token. This handle has TOKEN_IMPERSONATE and TOKEN_QUERY access to the new token.
		/// When you have finished using the new token, call the CloseHandle function to close the token handle.
		/// </param>
		/// <returns>
		/// If the function succeeds, the return value is nonzero. If the function fails, the return value is zero. To get extended error information, call GetLastError.
		/// </returns>
		[DllImport(Lib.AdvApi32, ExactSpelling = true, SetLastError = true)]
		[return: MarshalAs(UnmanagedType.Bool)]
		public static extern bool DuplicateToken(SafeTokenHandle existingObjectHandle,
			SECURITY_IMPERSONATION_LEVEL ImpersonationLevel, out SafeTokenHandle duplicateObjectHandle);

		/// <summary>
		/// The DuplicateTokenEx function creates a new access token that duplicates an existing token. This function can create either a primary token or an
		/// impersonation token.
		/// </summary>
		/// <param name="hExistingToken">A handle to an access token opened with TOKEN_DUPLICATE access.</param>
		/// <param name="dwDesiredAccess">
		/// Specifies the requested access rights for the new token. The DuplicateTokenEx function compares the requested access rights with the existing token's
		/// discretionary access control list (DACL) to determine which rights are granted or denied. To request the same access rights as the existing token,
		/// specify zero. To request all access rights that are valid for the caller, specify MAXIMUM_ALLOWED.
		/// </param>
		/// <param name="lpTokenAttributes">
		/// A pointer to a SECURITY_ATTRIBUTES structure that specifies a security descriptor for the new token and determines whether child processes can
		/// inherit the token. If lpTokenAttributes is NULL, the token gets a default security descriptor and the handle cannot be inherited. If the security
		/// descriptor contains a system access control list (SACL), the token gets ACCESS_SYSTEM_SECURITY access right, even if it was not requested in dwDesiredAccess.
		/// <para>To set the owner in the security descriptor for the new token, the caller's process token must have the SE_RESTORE_NAME privilege set.</para>
		/// </param>
		/// <param name="ImpersonationLevel">
		/// Specifies a value from the SECURITY_IMPERSONATION_LEVEL enumeration that indicates the impersonation level of the new token.
		/// </param>
		/// <param name="TokenType">Specifies one of the values from the TOKEN_TYPE enumeration.</param>
		/// <param name="phNewToken">
		/// A pointer to a HANDLE variable that receives the new token. When you have finished using the new token, call the CloseHandle function to close the
		/// token handle.
		/// </param>
		/// <returns>
		/// If the function succeeds, the function returns nonzero. If the function fails, it returns zero. To get extended error information, call GetLastError.
		/// </returns>
		[ReliabilityContract(Consistency.WillNotCorruptState, Cer.MayFail), DllImport(Lib.AdvApi32, ExactSpelling = true, SetLastError = true)]
		[return: MarshalAs(UnmanagedType.Bool)]
		public static extern bool DuplicateTokenEx(SafeTokenHandle hExistingToken, TokenAccess dwDesiredAccess, SECURITY_ATTRIBUTES lpTokenAttributes,
			SECURITY_IMPERSONATION_LEVEL ImpersonationLevel, TOKEN_TYPE TokenType, out SafeTokenHandle phNewToken);

		/// <summary>The GetAce function obtains a pointer to an access control entry (ACE) in an access control list (ACL).</summary>
		/// <param name="pAcl">A pointer to an ACL that contains the ACE to be retrieved.</param>
		/// <param name="dwAceIndex">
		/// The index of the ACE to be retrieved. A value of zero corresponds to the first ACE in the ACL, a value of one to the second ACE, and so on.
		/// </param>
		/// <param name="pAce">A pointer to a pointer that the function sets to the address of the ACE.</param>
		/// <returns>
		/// If the function succeeds, the function returns nonzero. If the function fails, it returns zero. To get extended error information, call GetLastError.
		/// </returns>
		[DllImport(Lib.AdvApi32, ExactSpelling = true, SetLastError = true)]
		[return: MarshalAs(UnmanagedType.Bool)]
		[PInvokeData("Winbase.h", MSDNShortId = "aa446634")]
		public static extern bool GetAce(IntPtr pAcl, int dwAceIndex, out IntPtr pAce);

		/// <summary>The GetAclInformation function retrieves information about an access control list (ACL).</summary>
		/// <param name="pAcl">
		/// A pointer to an ACL. The function retrieves information about this ACL. If a null value is passed, the function causes an access violation.
		/// </param>
		/// <param name="pAclInformation">
		/// A pointer to a buffer to receive the requested information. The structure that is placed into the buffer depends on the information class requested
		/// in the dwAclInformationClass parameter.
		/// </param>
		/// <param name="nAclInformationLength">The size, in bytes, of the buffer pointed to by the pAclInformation parameter.</param>
		/// <param name="dwAclInformationClass">
		/// A value of the ACL_INFORMATION_CLASS enumeration that indicates the class of information requested. This parameter can be one of two values from this enumeration:
		/// <list type="bullet">
		/// <listItem>
		/// <para>
		/// If the value is AclRevisionInformation, the function fills the buffer pointed to by the pAclInformation parameter with an ACL_REVISION_INFORMATION structure.
		/// </para>
		/// </listItem><listItem>
		/// <para>
		/// If the value is AclSizeInformation, the function fills the buffer pointed to by the pAclInformation parameter with an ACL_SIZE_INFORMATION structure.
		/// </para>
		/// </listItem>
		/// </list>
		/// </param>
		/// <returns>
		/// If the function succeeds, the function returns nonzero. If the function fails, it returns zero. To get extended error information, call GetLastError.
		/// </returns>
		[DllImport(Lib.AdvApi32, ExactSpelling = true, SetLastError = true)]
		[PInvokeData("Winbase.h", MSDNShortId = "aa446635")]
		public static extern bool GetAclInformation(IntPtr pAcl, ref ACL_REVISION_INFORMATION pAclInformation, uint nAclInformationLength, ACL_INFORMATION_CLASS dwAclInformationClass);

		/// <summary>The GetAclInformation function retrieves information about an access control list (ACL).</summary>
		/// <param name="pAcl">
		/// A pointer to an ACL. The function retrieves information about this ACL. If a null value is passed, the function causes an access violation.
		/// </param>
		/// <param name="pAclInformation">
		/// A pointer to a buffer to receive the requested information. The structure that is placed into the buffer depends on the information class requested
		/// in the dwAclInformationClass parameter.
		/// </param>
		/// <param name="nAclInformationLength">The size, in bytes, of the buffer pointed to by the pAclInformation parameter.</param>
		/// <param name="dwAclInformationClass">
		/// A value of the ACL_INFORMATION_CLASS enumeration that indicates the class of information requested. This parameter can be one of two values from this enumeration:
		/// <list type="bullet">
		/// <listItem>
		/// <para>
		/// If the value is AclRevisionInformation, the function fills the buffer pointed to by the pAclInformation parameter with an ACL_REVISION_INFORMATION structure.
		/// </para>
		/// </listItem><listItem>
		/// <para>
		/// If the value is AclSizeInformation, the function fills the buffer pointed to by the pAclInformation parameter with an ACL_SIZE_INFORMATION structure.
		/// </para>
		/// </listItem>
		/// </list>
		/// </param>
		/// <returns>
		/// If the function succeeds, the function returns nonzero. If the function fails, it returns zero. To get extended error information, call GetLastError.
		/// </returns>
		[DllImport(Lib.AdvApi32, ExactSpelling = true, SetLastError = true)]
		[PInvokeData("Winbase.h", MSDNShortId = "aa446635")]
		public static extern bool GetAclInformation(IntPtr pAcl, ref ACL_SIZE_INFORMATION pAclInformation, uint nAclInformationLength, ACL_INFORMATION_CLASS dwAclInformationClass);

		/// <summary>The GetPrivateObjectSecurity function retrieves information from a private object's security descriptor.</summary>
		/// <param name="ObjectDescriptor">A pointer to a SECURITY_DESCRIPTOR structure. This is the security descriptor to be queried.</param>
		/// <param name="SecurityInformation">
		/// A set of bit flags that indicate the parts of the security descriptor to retrieve. This parameter can be a combination of the SECURITY_INFORMATION
		/// bit flags.
		/// </param>
		/// <param name="ResultantDescriptor">
		/// A pointer to a buffer that receives a copy of the requested information from the specified security descriptor. The SECURITY_DESCRIPTOR structure is
		/// returned in self-relative format.
		/// </param>
		/// <param name="DescriptorLength">Specifies the size, in bytes, of the buffer pointed to by the ResultantDescriptor parameter.</param>
		/// <param name="ReturnLength">
		/// A pointer to a variable the function sets to zero if the descriptor is copied successfully. If the buffer is too small for the security descriptor,
		/// this variable receives the number of bytes required. If this variable's value is greater than the value of the DescriptorLength parameter when the
		/// function returns, the function returns FALSE and none of the security descriptor is copied to the buffer.
		/// </param>
		/// <returns>
		/// If the function succeeds, the return value is nonzero. If the function fails, the return value is zero. To get extended error information, call GetLastError.
		/// </returns>
		[DllImport(Lib.AdvApi32, ExactSpelling = true, SetLastError = true)]
		[return: MarshalAs(UnmanagedType.Bool)]
		[PInvokeData("Winbase.h", MSDNShortId = "aa446646")]
		public static extern bool GetPrivateObjectSecurity(IntPtr ObjectDescriptor, SECURITY_INFORMATION SecurityInformation,
			IntPtr ResultantDescriptor, uint DescriptorLength, out uint ReturnLength);

		/// <summary>The GetSecurityDescriptorDacl function retrieves a pointer to the discretionary access control list (DACL) in a specified security descriptor.</summary>
		/// <param name="pSecurityDescriptor">A pointer to the SECURITY_DESCRIPTOR structure that contains the DACL. The function retrieves a pointer to it.</param>
		/// <param name="lpbDaclPresent">
		/// A pointer to a value that indicates the presence of a DACL in the specified security descriptor. If lpbDaclPresent is TRUE, the security descriptor
		/// contains a DACL, and the remaining output parameters in this function receive valid values. If lpbDaclPresent is FALSE, the security descriptor does
		/// not contain a DACL, and the remaining output parameters do not receive valid values.
		/// <para>
		/// A value of TRUE for lpbDaclPresent does not mean that pDacl is not NULL. That is, lpbDaclPresent can be TRUE while pDacl is NULL, meaning that a NULL
		/// DACL is in effect. A NULL DACL implicitly allows all access to an object and is not the same as an empty DACL. An empty DACL permits no access to an
		/// object. For information about creating a proper DACL, see Creating a DACL.
		/// </para>
		/// </param>
		/// <param name="pDacl">
		/// A pointer to a pointer to an access control list (ACL). If a DACL exists, the function sets the pointer pointed to by pDacl to the address of the
		/// security descriptor's DACL. If a DACL does not exist, no value is stored.
		/// <para>
		/// If the function stores a NULL value in the pointer pointed to by pDacl, the security descriptor has a NULL DACL. A NULL DACL implicitly allows all
		/// access to an object.
		/// </para>
		/// <para>If an application expects a non-NULL DACL but encounters a NULL DACL, the application should fail securely and not allow access.</para>
		/// </param>
		/// <param name="lpbDaclDefaulted">
		/// A pointer to a flag set to the value of the SE_DACL_DEFAULTED flag in the SECURITY_DESCRIPTOR_CONTROL structure if a DACL exists for the security
		/// descriptor. If this flag is TRUE, the DACL was retrieved by a default mechanism; if FALSE, the DACL was explicitly specified by a user.
		/// </param>
		/// <returns>
		/// If the function succeeds, the return value is nonzero. If the function fails, the return value is zero. To get extended error information, call GetLastError.
		/// </returns>
		[DllImport(Lib.AdvApi32, ExactSpelling = true, SetLastError = true)]
		[return: MarshalAs(UnmanagedType.Bool)]
		[PInvokeData("Winbase.h", MSDNShortId = "aa446648")]
		public static extern bool GetSecurityDescriptorDacl(IntPtr pSecurityDescriptor, [MarshalAs(UnmanagedType.Bool)] out bool lpbDaclPresent,
			out IntPtr pDacl, [MarshalAs(UnmanagedType.Bool)] out bool lpbDaclDefaulted);

		/// <summary>The GetSecurityDescriptorOwner function retrieves the owner information from a security descriptor.</summary>
		/// <param name="pSecurityDescriptor">A pointer to a SECURITY_DESCRIPTOR structure whose owner information the function retrieves.</param>
		/// <param name="pOwner">A pointer to a pointer to a security identifier (SID) that identifies the owner when the function returns. If the security descriptor does not contain an owner, the function sets the pointer pointed to by pOwner to NULL and ignores the remaining output parameter, lpbOwnerDefaulted. If the security descriptor contains an owner, the function sets the pointer pointed to by pOwner to the address of the security descriptor's owner SID and provides a valid value for the variable pointed to by lpbOwnerDefaulted.</param>
		/// <param name="lpbOwnerDefaulted">A pointer to a flag that is set to the value of the SE_OWNER_DEFAULTED flag in the SECURITY_DESCRIPTOR_CONTROL structure when the function returns. If the value stored in the variable pointed to by the pOwner parameter is NULL, no value is set.</param>
		/// <returns>
		/// If the function succeeds, the return value is nonzero. If the function fails, the return value is zero. To get extended error information, call GetLastError.
		/// </returns>
		[DllImport(Lib.AdvApi32, ExactSpelling = true, SetLastError = true)]
		[return: MarshalAs(UnmanagedType.Bool)]
		[PInvokeData("Winbase.h", MSDNShortId = "aa446651")]
		public static extern bool GetSecurityDescriptorOwner(IntPtr pSecurityDescriptor,
			out IntPtr pOwner, [MarshalAs(UnmanagedType.Bool)] out bool lpbOwnerDefaulted);

		/// <summary>
		/// The GetTokenInformation function retrieves a specified type of information about an access token. The calling process must have appropriate access
		/// rights to obtain the information.
		/// </summary>
		/// <param name="hObject">
		/// A handle to an access token from which information is retrieved. If TokenInformationClass specifies TokenSource, the handle must have
		/// TOKEN_QUERY_SOURCE access. For all other TokenInformationClass values, the handle must have TOKEN_QUERY access.
		/// </param>
		/// <param name="tokenInfoClass">
		/// Specifies a value from the TOKEN_INFORMATION_CLASS enumerated type to identify the type of information the function retrieves. Any callers who check
		/// the TokenIsAppContainer and have it return 0 should also verify that the caller token is not an identify level impersonation token. If the current
		/// token is not an application container but is an identity level token, you should return AccessDenied.
		/// </param>
		/// <param name="pTokenInfo">
		/// A pointer to a buffer the function fills with the requested information. The structure put into this buffer depends upon the type of information
		/// specified by the TokenInformationClass parameter.
		/// </param>
		/// <param name="tokenInfoLength">
		/// Specifies the size, in bytes, of the buffer pointed to by the TokenInformation parameter. If TokenInformation is NULL, this parameter must be zero.
		/// </param>
		/// <param name="returnLength">
		/// A pointer to a variable that receives the number of bytes needed for the buffer pointed to by the TokenInformation parameter. If this value is larger
		/// than the value specified in the TokenInformationLength parameter, the function fails and stores no data in the buffer.
		/// <para>
		/// If the value of the TokenInformationClass parameter is TokenDefaultDacl and the token has no default DACL, the function sets the variable pointed to
		/// by ReturnLength to sizeof(TOKEN_DEFAULT_DACL) and sets the DefaultDacl member of the TOKEN_DEFAULT_DACL structure to NULL.
		/// </para>
		/// </param>
		/// <returns>
		/// If the function succeeds, the return value is nonzero. If the function fails, the return value is zero. To get extended error information, call GetLastError.
		/// </returns>
		[DllImport(Lib.AdvApi32, SetLastError = true, ExactSpelling = true)]
		[return: MarshalAs(UnmanagedType.Bool)]
		[PInvokeData("winbase.h", MSDNShortId = "aa446671")]
		public static extern bool GetTokenInformation(SafeTokenHandle hObject, TOKEN_INFORMATION_CLASS tokenInfoClass, SafeCoTaskMemHandle pTokenInfo, int tokenInfoLength, out int returnLength);

		/// <summary>
		/// The LogonUser function attempts to log a user on to the local computer. The local computer is the computer from which LogonUser was called. You
		/// cannot use LogonUser to log on to a remote computer. You specify the user with a user name and domain and authenticate the user with a plain-text
		/// password. If the function succeeds, you receive a handle to a token that represents the logged-on user. You can then use this token handle to
		/// impersonate the specified user or, in most cases, to create a process that runs in the context of the specified user.
		/// </summary>
		/// <param name="lpszUserName">
		/// A pointer to a null-terminated string that specifies the name of the user. This is the name of the user account to log on to. If you use the user
		/// principal name (UPN) format, User@DNSDomainName, the lpszDomain parameter must be NULL.
		/// </param>
		/// <param name="lpszDomain">
		/// A pointer to a null-terminated string that specifies the name of the domain or server whose account database contains the lpszUsername account. If
		/// this parameter is NULL, the user name must be specified in UPN format. If this parameter is ".", the function validates the account by using only the
		/// local account database.
		/// </param>
		/// <param name="lpszPassword">
		/// A pointer to a null-terminated string that specifies the plain-text password for the user account specified by lpszUsername. When you have finished
		/// using the password, clear the password from memory by calling the SecureZeroMemory function. For more information about protecting passwords, see
		/// Handling Passwords.
		/// </param>
		/// <param name="dwLogonType">The type of logon operation to perform.</param>
		/// <param name="dwLogonProvider">Specifies the logon provider.</param>
		/// <param name="phObject">
		/// A pointer to a handle variable that receives a handle to a token that represents the specified user.
		/// <para>You can use the returned handle in calls to the ImpersonateLoggedOnUser function.</para>
		/// <para>
		/// In most cases, the returned handle is a primary token that you can use in calls to the CreateProcessAsUser function. However, if you specify the
		/// LOGON32_LOGON_NETWORK flag, LogonUser returns an impersonation token that you cannot use in CreateProcessAsUser unless you call DuplicateTokenEx to
		/// convert it to a primary token.
		/// </para>
		/// <para>When you no longer need this handle, close it by calling the CloseHandle function.</para>
		/// </param>
		/// <returns>
		/// If the function succeeds, the return value is nonzero. If the function fails, the return value is zero. To get extended error information, call GetLastError.
		/// </returns>
		[DllImport(Lib.AdvApi32, SetLastError = true, CharSet = CharSet.Auto, BestFitMapping = false, ThrowOnUnmappableChar = true)]
		[return: MarshalAs(UnmanagedType.Bool)]
		[PInvokeData("Winbase.h", MSDNShortId = "aa378184")]
		public static extern bool LogonUser(string lpszUserName, string lpszDomain, string lpszPassword, LogonUserType dwLogonType, LogonUserProvider dwLogonProvider,
			out SafeTokenHandle phObject);

		/// <summary>
		/// The LogonUserEx function attempts to log a user on to the local computer. The local computer is the computer from which LogonUserEx was called. You
		/// cannot use LogonUserEx to log on to a remote computer. You specify the user with a user name and domain and authenticate the user with a plaintext
		/// password. If the function succeeds, you receive a handle to a token that represents the logged-on user. You can then use this token handle to
		/// impersonate the specified user or, in most cases, to create a process that runs in the context of the specified user.
		/// </summary>
		/// <param name="lpszUserName">
		/// A pointer to a null-terminated string that specifies the name of the user. This is the name of the user account to log on to. If you use the user
		/// principal name (UPN) format, user@DNS_domain_name, the lpszDomain parameter must be NULL.
		/// </param>
		/// <param name="lpszDomain">
		/// A pointer to a null-terminated string that specifies the name of the domain or server whose account database contains the lpszUsername account. If
		/// this parameter is NULL, the user name must be specified in UPN format. If this parameter is ".", the function validates the account by using only the
		/// local account database.
		/// </param>
		/// <param name="lpszPassword">
		/// A pointer to a null-terminated string that specifies the plaintext password for the user account specified by lpszUsername. When you have finished
		/// using the password, clear the password from memory by calling the SecureZeroMemory function. For more information about protecting passwords, see
		/// Handling Passwords.
		/// </param>
		/// <param name="dwLogonType">The type of logon operation to perform.</param>
		/// <param name="dwLogonProvider">The logon provider.</param>
		/// <param name="phObject">
		/// A pointer to a handle variable that receives a handle to a token that represents the specified user.
		/// <para>You can use the returned handle in calls to the ImpersonateLoggedOnUser function.</para>
		/// <para>
		/// In most cases, the returned handle is a primary token that you can use in calls to the CreateProcessAsUser function. However, if you specify the
		/// LOGON32_LOGON_NETWORK flag, LogonUser returns an impersonation token that you cannot use in CreateProcessAsUser unless you call DuplicateTokenEx to
		/// convert it to a primary token.
		/// </para>
		/// <para>When you no longer need this handle, close it by calling the CloseHandle function.</para>
		/// </param>
		/// <param name="ppLogonSid">
		/// A pointer to a pointer to a security identifier (SID) that receives the SID of the user logged on.
		/// <para>When you have finished using the SID, free it by calling the LocalFree function.</para>
		/// </param>
		/// <param name="ppProfileBuffer">A pointer to a pointer that receives the address of a buffer that contains the logged on user's profile.</param>
		/// <param name="pdwProfileLength">A pointer to a DWORD that receives the length of the profile buffer.</param>
		/// <param name="pQuotaLimits">A pointer to a QUOTA_LIMITS structure that receives information about the quotas for the logged on user.</param>
		/// <returns>
		/// If the function succeeds, the function returns nonzero. If the function fails, it returns zero. To get extended error information, call GetLastError.
		/// </returns>
		[DllImport(Lib.AdvApi32, SetLastError = true, CharSet = CharSet.Auto, BestFitMapping = false, ThrowOnUnmappableChar = true)]
		[return: MarshalAs(UnmanagedType.Bool)]
		[PInvokeData("Winbase.h", MSDNShortId = "aa378189")]
		public static extern bool LogonUserEx(string lpszUserName, string lpszDomain, string lpszPassword, LogonUserType dwLogonType, LogonUserProvider dwLogonProvider,
			out SafeTokenHandle phObject, out PSID ppLogonSid, out SafeLsaReturnBufferHandle ppProfileBuffer, out uint pdwProfileLength, out QUOTA_LIMITS pQuotaLimits);

		/// <summary>
		/// The LookupAccountName function accepts the name of a system and an account as input. It retrieves a security identifier (SID) for the account and the
		/// name of the domain on which the account was found.
		/// </summary>
		/// <param name="lpSystemName">
		/// A pointer to a null-terminated character string that specifies the name of the system. This string can be the name of a remote computer. If this
		/// string is NULL, the account name translation begins on the local system. If the name cannot be resolved on the local system, this function will try
		/// to resolve the name using domain controllers trusted by the local system. Generally, specify a value for lpSystemName only when the account is in an
		/// untrusted domain and the name of a computer in that domain is known.
		/// </param>
		/// <param name="lpAccountName">
		/// A pointer to a null-terminated string that specifies the account name.
		/// <para>Use a fully qualified string in the domain_name\user_name format to ensure that LookupAccountName finds the account in the desired domain.</para>
		/// </param>
		/// <param name="Sid">
		/// A pointer to a buffer that receives the SID structure that corresponds to the account name pointed to by the lpAccountName parameter. If this
		/// parameter is NULL, cbSid must be zero.
		/// </param>
		/// <param name="cbSid">
		/// A pointer to a variable. On input, this value specifies the size, in bytes, of the Sid buffer. If the function fails because the buffer is too small
		/// or if cbSid is zero, this variable receives the required buffer size.
		/// </param>
		/// <param name="ReferencedDomainName">
		/// A pointer to a buffer that receives the name of the domain where the account name is found. For computers that are not joined to a domain, this
		/// buffer receives the computer name. If this parameter is NULL, the function returns the required buffer size.
		/// </param>
		/// <param name="cchReferencedDomainName">
		/// A pointer to a variable. On input, this value specifies the size, in TCHARs, of the ReferencedDomainName buffer. If the function fails because the
		/// buffer is too small, this variable receives the required buffer size, including the terminating null character. If the ReferencedDomainName parameter
		/// is NULL, this parameter must be zero.
		/// </param>
		/// <param name="peUse">A pointer to a SID_NAME_USE enumerated type that indicates the type of the account when the function returns.</param>
		/// <returns>
		/// If the function succeeds, the function returns nonzero. If the function fails, it returns zero. For extended error information, call GetLastError.
		/// </returns>
		[DllImport(Lib.AdvApi32, CharSet = CharSet.Auto, SetLastError = true)]
		[return: MarshalAs(UnmanagedType.Bool)]
		[PInvokeData("Winbase.h", MSDNShortId = "aa379159")]
		public static extern bool LookupAccountName(string lpSystemName, string lpAccountName, PSID Sid, ref int cbSid,
			StringBuilder ReferencedDomainName, ref int cchReferencedDomainName, ref SID_NAME_USE peUse);

		/// <summary>
		/// The LookupAccountName function accepts the name of a system and an account as input. It retrieves a security identifier (SID) for the account and the
		/// name of the domain on which the account was found.
		/// </summary>
		/// <param name="systemName">
		/// A string that specifies the name of the system. This string can be the name of a remote computer. If this string is NULL, the account name
		/// translation begins on the local system. If the name cannot be resolved on the local system, this function will try to resolve the name using domain
		/// controllers trusted by the local system. Generally, specify a value for lpSystemName only when the account is in an untrusted domain and the name of
		/// a computer in that domain is known.
		/// </param>
		/// <param name="accountName">
		/// A string that specifies the account name.
		/// <para>Use a fully qualified string in the domain_name\user_name format to ensure that LookupAccountName finds the account in the desired domain.</para>
		/// </param>
		/// <param name="sid">A PSID class that corresponds to the account name pointed to by the lpAccountName parameter.</param>
		/// <param name="domainName">
		/// A string that receives the name of the domain where the account name is found. For computers that are not joined to a domain, this buffer receives
		/// the computer name.
		/// </param>
		/// <param name="snu">A SID_NAME_USE enumerated type that indicates the type of the account when the function returns.</param>
		/// <returns>
		/// If the function succeeds, the function returns nonzero. If the function fails, it returns zero. For extended error information, call GetLastError.
		/// </returns>
		[PInvokeData("Winbase.h", MSDNShortId = "aa379159")]
		public static bool LookupAccountName(string systemName, string accountName, out PSID sid, out string domainName, out SID_NAME_USE snu)
		{
			var sb = new StringBuilder(1024);
			var psid = new PSID(256);
			snu = 0;
			var sidSz = psid.Size;
			var sbSz = sb.Capacity;
			var ret = LookupAccountName(systemName, accountName, psid, ref sidSz, sb, ref sbSz, ref snu);
			sid = new PSID(psid);
			domainName = sb.ToString();
			return ret;
		}

		/// <summary>
		/// The LookupAccountSid function accepts a security identifier (SID) as input. It retrieves the name of the account for this SID and the name of the
		/// first domain on which this SID is found.
		/// </summary>
		/// <param name="lpSystemName">
		/// A pointer to a null-terminated character string that specifies the target computer. This string can be the name of a remote computer. If this
		/// parameter is NULL, the account name translation begins on the local system. If the name cannot be resolved on the local system, this function will
		/// try to resolve the name using domain controllers trusted by the local system. Generally, specify a value for lpSystemName only when the account is in
		/// an untrusted domain and the name of a computer in that domain is known.
		/// </param>
		/// <param name="lpSid">A pointer to the SID to look up.</param>
		/// <param name="lpName">
		/// A pointer to a buffer that receives a null-terminated string that contains the account name that corresponds to the lpSid parameter.
		/// </param>
		/// <param name="cchName">
		/// On input, specifies the size, in TCHARs, of the lpName buffer. If the function fails because the buffer is too small or if cchName is zero, cchName
		/// receives the required buffer size, including the terminating null character.
		/// </param>
		/// <param name="lpReferencedDomainName">
		/// A pointer to a buffer that receives a null-terminated string that contains the name of the domain where the account name was found.
		/// <para>
		/// On a server, the domain name returned for most accounts in the security database of the local computer is the name of the domain for which the server
		/// is a domain controller.
		/// </para>
		/// <para>
		/// On a workstation, the domain name returned for most accounts in the security database of the local computer is the name of the computer as of the
		/// last start of the system (backslashes are excluded). If the name of the computer changes, the old name continues to be returned as the domain name
		/// until the system is restarted.
		/// </para>
		/// <para>Some accounts are predefined by the system. The domain name returned for these accounts is BUILTIN.</para>
		/// </param>
		/// <param name="cchReferencedDomainName">
		/// On input, specifies the size, in TCHARs, of the lpReferencedDomainName buffer. If the function fails because the buffer is too small or if
		/// cchReferencedDomainName is zero, cchReferencedDomainName receives the required buffer size, including the terminating null character.
		/// </param>
		/// <param name="peUse">A pointer to a variable that receives a SID_NAME_USE value that indicates the type of the account.</param>
		/// <returns>
		/// If the function succeeds, the function returns nonzero. If the function fails, it returns zero. To get extended error information, call GetLastError.
		/// </returns>
		[DllImport(Lib.AdvApi32, CharSet = CharSet.Auto, SetLastError = true, BestFitMapping = false, ThrowOnUnmappableChar = true)]
		[return: MarshalAs(UnmanagedType.Bool)]
		[PInvokeData("Winbase.h", MSDNShortId = "aa379166")]
		public static extern bool LookupAccountSid(string lpSystemName, byte[] lpSid, StringBuilder lpName, ref int cchName,
			StringBuilder lpReferencedDomainName, ref int cchReferencedDomainName, out SID_NAME_USE peUse);

		/// <summary>
		/// The LookupAccountSid function accepts a security identifier (SID) as input. It retrieves the name of the account for this SID and the name of the
		/// first domain on which this SID is found.
		/// </summary>
		/// <param name="lpSystemName">
		/// A pointer to a null-terminated character string that specifies the target computer. This string can be the name of a remote computer. If this
		/// parameter is NULL, the account name translation begins on the local system. If the name cannot be resolved on the local system, this function will
		/// try to resolve the name using domain controllers trusted by the local system. Generally, specify a value for lpSystemName only when the account is in
		/// an untrusted domain and the name of a computer in that domain is known.
		/// </param>
		/// <param name="lpSid">A pointer to the SID to look up.</param>
		/// <param name="lpName">
		/// A pointer to a buffer that receives a null-terminated string that contains the account name that corresponds to the lpSid parameter.
		/// </param>
		/// <param name="cchName">
		/// On input, specifies the size, in TCHARs, of the lpName buffer. If the function fails because the buffer is too small or if cchName is zero, cchName
		/// receives the required buffer size, including the terminating null character.
		/// </param>
		/// <param name="lpReferencedDomainName">
		/// A pointer to a buffer that receives a null-terminated string that contains the name of the domain where the account name was found.
		/// <para>
		/// On a server, the domain name returned for most accounts in the security database of the local computer is the name of the domain for which the server
		/// is a domain controller.
		/// </para>
		/// <para>
		/// On a workstation, the domain name returned for most accounts in the security database of the local computer is the name of the computer as of the
		/// last start of the system (backslashes are excluded). If the name of the computer changes, the old name continues to be returned as the domain name
		/// until the system is restarted.
		/// </para>
		/// <para>Some accounts are predefined by the system. The domain name returned for these accounts is BUILTIN.</para>
		/// </param>
		/// <param name="cchReferencedDomainName">
		/// On input, specifies the size, in TCHARs, of the lpReferencedDomainName buffer. If the function fails because the buffer is too small or if
		/// cchReferencedDomainName is zero, cchReferencedDomainName receives the required buffer size, including the terminating null character.
		/// </param>
		/// <param name="peUse">A pointer to a variable that receives a SID_NAME_USE value that indicates the type of the account.</param>
		/// <returns>
		/// If the function succeeds, the function returns nonzero. If the function fails, it returns zero. To get extended error information, call GetLastError.
		/// </returns>
		[DllImport(Lib.AdvApi32, CharSet = CharSet.Auto, SetLastError = true, BestFitMapping = false, ThrowOnUnmappableChar = true)]
		[return: MarshalAs(UnmanagedType.Bool)]
		[PInvokeData("Winbase.h", MSDNShortId = "aa379166")]
		public static extern bool LookupAccountSid(string lpSystemName, PSID lpSid, StringBuilder lpName, ref int cchName,
			StringBuilder lpReferencedDomainName, ref int cchReferencedDomainName, out SID_NAME_USE peUse);

		/// <summary>
		/// The LookupPrivilegeName function retrieves the name that corresponds to the privilege represented on a specific system by a specified locally unique
		/// identifier (LUID).
		/// </summary>
		/// <param name="lpSystemName">
		/// A pointer to a null-terminated string that specifies the name of the system on which the privilege name is retrieved. If a null string is specified,
		/// the function attempts to find the privilege name on the local system.
		/// </param>
		/// <param name="lpLuid">A pointer to the LUID by which the privilege is known on the target system.</param>
		/// <param name="lpName">
		/// A pointer to a buffer that receives a null-terminated string that represents the privilege name. For example, this string could be "SeSecurityPrivilege".
		/// </param>
		/// <param name="cchName">
		/// A pointer to a variable that specifies the size, in a TCHAR value, of the lpName buffer. When the function returns, this parameter contains the
		/// length of the privilege name, not including the terminating null character. If the buffer pointed to by the lpName parameter is too small, this
		/// variable contains the required size.
		/// </param>
		/// <returns>
		/// If the function succeeds, the function returns nonzero. If the function fails, it returns zero.To get extended error information, call GetLastError.
		/// </returns>
		[DllImport(Lib.AdvApi32, CharSet = CharSet.Auto, SetLastError = true, BestFitMapping = false, ThrowOnUnmappableChar = true)]
		[return: MarshalAs(UnmanagedType.Bool)]
		public static extern bool LookupPrivilegeName(string lpSystemName, ref LUID lpLuid, StringBuilder lpName, ref int cchName);

		/// <summary>
		/// The LookupPrivilegeValue function retrieves the locally unique identifier (LUID) used on a specified system to locally represent the specified
		/// privilege name.
		/// </summary>
		/// <param name="lpSystemName">
		/// A pointer to a null-terminated string that specifies the name of the system on which the privilege name is retrieved. If a null string is specified,
		/// the function attempts to find the privilege name on the local system.
		/// </param>
		/// <param name="lpName">
		/// A pointer to a null-terminated string that specifies the name of the privilege, as defined in the Winnt.h header file. For example, this parameter
		/// could specify the constant, SE_SECURITY_NAME, or its corresponding string, "SeSecurityPrivilege".
		/// </param>
		/// <param name="lpLuid">
		/// A pointer to a variable that receives the LUID by which the privilege is known on the system specified by the lpSystemName parameter.
		/// </param>
		/// <returns>
		/// If the function succeeds, the function returns nonzero. If the function fails, it returns zero. To get extended error information, call GetLastError.
		/// </returns>
		[DllImport(Lib.AdvApi32, CharSet = CharSet.Auto, SetLastError = true, BestFitMapping = false, ThrowOnUnmappableChar = true)]
		[return: MarshalAs(UnmanagedType.Bool)]
		public static extern bool LookupPrivilegeValue(string lpSystemName, string lpName, out LUID lpLuid);

		/// <summary>
		/// The MapGenericMask function maps the generic access rights in an access mask to specific and standard access rights. The function applies a mapping
		/// supplied in a <see cref="GENERIC_MAPPING"/> structure.
		/// </summary>
		/// <param name="AccessMask">A pointer to an access mask.</param>
		/// <param name="GenericMapping">
		/// A pointer to a <see cref="GENERIC_MAPPING"/> structure specifying a mapping of generic access types to specific and standard access types.
		/// </param>
		[DllImport(Lib.AdvApi32, ExactSpelling = true)]
		[PInvokeData("Winbase.h", MSDNShortId = "aa379266")]
		public static extern void MapGenericMask(ref uint AccessMask, ref GENERIC_MAPPING GenericMapping);

		/// <summary>The OpenProcessToken function opens the access token associated with a process.</summary>
		/// <param name="ProcessHandle">A handle to the process whose access token is opened. The process must have the PROCESS_QUERY_INFORMATION access permission.</param>
		/// <param name="DesiredAccess">
		/// Specifies an access mask that specifies the requested types of access to the access token. These requested access types are compared with the
		/// discretionary access control list (DACL) of the token to determine which accesses are granted or denied.
		/// </param>
		/// <param name="TokenHandle">A pointer to a handle that identifies the newly opened access token when the function returns.</param>
		/// <returns>
		/// If the function succeeds, the function returns nonzero. If the function fails, it returns zero. To get extended error information, call GetLastError.
		/// </returns>
		[DllImport(Lib.AdvApi32, SetLastError = true, ExactSpelling = true)]
		[return: MarshalAs(UnmanagedType.Bool)]
		[PInvokeData("winbase.h", MSDNShortId = "aa379295")]
		public static extern bool OpenProcessToken([In] IntPtr ProcessHandle, TokenAccess DesiredAccess, out SafeTokenHandle TokenHandle);

		/// <summary>The OpenThreadToken function opens the access token associated with a thread.</summary>
		/// <param name="ThreadHandle">A handle to the thread whose access token is opened.</param>
		/// <param name="DesiredAccess">
		/// Specifies an access mask that specifies the requested types of access to the access token. These requested access types are reconciled against the
		/// token's discretionary access control list (DACL) to determine which accesses are granted or denied.
		/// <para>For a list of access rights for access tokens, see Access Rights for Access-Token Objects.</para>
		/// </param>
		/// <param name="OpenAsSelf">
		/// TRUE if the access check is to be made against the process-level security context.
		/// <para>FALSE if the access check is to be made against the current security context of the thread calling the OpenThreadToken function.</para>
		/// <para>
		/// The OpenAsSelf parameter allows the caller of this function to open the access token of a specified thread when the caller is impersonating a token
		/// at SecurityIdentification level. Without this parameter, the calling thread cannot open the access token on the specified thread because it is
		/// impossible to open executive-level objects by using the SecurityIdentification impersonation level.
		/// </para>
		/// </param>
		/// <param name="TokenHandle">A pointer to a variable that receives the handle to the newly opened access token.</param>
		/// <returns>
		/// If the function succeeds, the function returns nonzero. If the function fails, it returns zero. To get extended error information, call GetLastError.
		/// </returns>
		[DllImport(Lib.AdvApi32, SetLastError = true, ExactSpelling = true)]
		[return: MarshalAs(UnmanagedType.Bool)]
		public static extern bool OpenThreadToken([In] IntPtr ThreadHandle, TokenAccess DesiredAccess, [MarshalAs(UnmanagedType.Bool)] bool OpenAsSelf, out SafeTokenHandle TokenHandle);

		/// <summary>
		/// The PrivilegeCheck function determines whether a specified set of privileges are enabled in an access token. The PrivilegeCheck function is typically
		/// called by a server application to check the privileges of a client's access token.
		/// </summary>
		/// <param name="ClientToken">
		/// A handle to an access token representing a client process. This handle must have been obtained by opening the token of a thread impersonating the
		/// client. The token must be open for TOKEN_QUERY access.
		/// </param>
		/// <param name="RequiredPrivileges">
		/// A pointer to a PRIVILEGE_SET structure. The Privilege member of this structure is an array of LUID_AND_ATTRIBUTES structures. Before calling
		/// PrivilegeCheck, use the Privilege array to indicate the set of privileges to check. Set the Control member to PRIVILEGE_SET_ALL_NECESSARY if all of
		/// the privileges must be enabled; or set it to zero if it is sufficient that any one of the privileges be enabled.
		/// <para>
		/// When PrivilegeCheck returns, the Attributes member of each LUID_AND_ATTRIBUTES structure is set to SE_PRIVILEGE_USED_FOR_ACCESS if the corresponding
		/// privilege is enabled.
		/// </para>
		/// </param>
		/// <param name="pfResult">
		/// A pointer to a value the function sets to indicate whether any or all of the specified privileges are enabled in the access token. If the Control
		/// member of the PRIVILEGE_SET structure specifies PRIVILEGE_SET_ALL_NECESSARY, this value is TRUE only if all the privileges are enabled; otherwise,
		/// this value is TRUE if any of the privileges are enabled.
		/// </param>
		/// <returns>
		/// If the function succeeds, the function returns nonzero. If the function fails, it returns zero. To get extended error information, call GetLastError.
		/// </returns>
		[PInvokeData("Winbase.h", MSDNShortId = "aa379304")]
		[DllImport(Lib.AdvApi32, SetLastError = true, ExactSpelling = true)]
		[return: MarshalAs(UnmanagedType.Bool)]
		public static extern bool PrivilegeCheck(SafeTokenHandle ClientToken,
			[MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef = typeof(PRIVILEGE_SET.Marshaler))] PRIVILEGE_SET RequiredPrivileges,
			[MarshalAs(UnmanagedType.Bool)] out bool pfResult);

		/// <summary>The RevertToSelf function terminates the impersonation of a client application.</summary>
		/// <returns>
		/// If the function succeeds, the function returns nonzero. If the function fails, it returns zero. To get extended error information, call GetLastError.
		/// </returns>
		[DllImport(Lib.AdvApi32, ExactSpelling = true, SetLastError = true)]
		[return: MarshalAs(UnmanagedType.Bool)]
		[PInvokeData("Winbase.h", MSDNShortId = "aa379317")]
		public static extern bool RevertToSelf();

		/// <summary>
		/// The SetThreadToken function assigns an impersonation token to a thread. The function can also cause a thread to stop using an impersonation token.
		/// </summary>
		/// <param name="Thread">
		/// A pointer to a handle to the thread to which the function assigns the impersonation token. If Thread is NULL, the function assigns the impersonation
		/// token to the calling thread.
		/// </param>
		/// <param name="Token">
		/// A handle to the impersonation token to assign to the thread. This handle must have been opened with TOKEN_IMPERSONATE access rights. For more
		/// information, see Access Rights for Access-Token Objects. If Token is NULL, the function causes the thread to stop using an impersonation token.
		/// </param>
		/// <returns>
		/// If the function succeeds, the function returns nonzero. If the function fails, it returns zero. To get extended error information, call GetLastError.
		/// </returns>
		[DllImport(Lib.AdvApi32, SetLastError = true, ExactSpelling = true)]
		[return: MarshalAs(UnmanagedType.Bool)]
		public static extern bool SetThreadToken(IntPtr Thread, SafeTokenHandle Token);

		/// <summary>Closes an open object handle.</summary>
		/// <param name="hObject">A valid handle to an open object.</param>
		/// <returns>
		/// If the function succeeds, the return value is nonzero. If the function fails, the return value is zero.To get extended error information, call GetLastError.
		/// </returns>
		[PInvokeData("WinBase.h", MSDNShortId = "ms724211")]
		[ReliabilityContract(Consistency.WillNotCorruptState, Cer.Success), DllImport(Lib.Kernel32, ExactSpelling = true, SetLastError = true)]
		[return: MarshalAs(UnmanagedType.Bool)]
		private static extern bool CloseHandle(IntPtr hObject);

		/// <summary>Represents a safe handle for HTOKEN.</summary>
		public class SafeTokenHandle : GenericSafeHandle
		{
			/// <summary>Retrieves a pseudo-handle that you can use as a shorthand way to refer to the access token associated with a process.</summary>
			/// <remarks>A pseudo-handle is a special constant that can function as the access token for the current process. The calling process can use a pseudo-handle to specify the access token for that process whenever a token handle is required. Child processes do not inherit pseudo-handles.
			/// <para>Starting in Windows 8, this pseudo-handle has only TOKEN_QUERY and TOKEN_QUERY_SOURCE access rights.</para>
			/// <para>A process can create a standard handle that is valid in the context of other processes and can be inherited by other processes. To create this standard handle, call the DuplicateHandle function and specify the pseudo-handle as the source handle.</para>
			/// <para>You do not need to close the pseudo-handle when you no longer need it. If you call the CloseHandle function with a pseudo-handle, the function has no effect. If you call DuplicateHandle to duplicate the pseudo-handle, however, you must close the duplicate handle.</para>
			/// </remarks>
			public static readonly SafeTokenHandle CurrentProcessToken = new SafeTokenHandle((IntPtr)4, false);

			/// <summary>Retrieves a pseudo-handle that you can use as a shorthand way to refer to the token that is currently in effect for the thread, which is the thread token if one exists and the process token otherwise.</summary>
			/// <remarks>A pseudo-handle is a special constant that can function as the access token for the current thread. The calling thread can use a pseudo-handle to specify the access token for that thread whenever a token handle is required. Child threads do not inherit pseudo-handles.
			/// <para>Starting in Windows 8, this pseudo-handle has only TOKEN_QUERY and TOKEN_QUERY_SOURCE access rights.</para>
			/// <para>A thread can create a standard handle that is valid in the context of other threads and can be inherited by other threads. To create this standard handle, call the DuplicateHandle function and specify the pseudo-handle as the source handle.</para>
			/// <para>You do not need to close the pseudo-handle when you no longer need it. If you call the CloseHandle function with a pseudo-handle, the function has no effect. If you call DuplicateHandle to duplicate the pseudo-handle, however, you must close the duplicate handle.</para>
			/// </remarks>
			public static readonly SafeTokenHandle CurrentThreadEffectiveToken = new SafeTokenHandle((IntPtr)6, false);

			/// <summary>Retrieves a pseudo-handle that you can use as a shorthand way to refer to the impersonation token that was assigned to the current thread.</summary>
			/// <remarks>A pseudo-handle is a special constant that can function as the impersonation token for the current thread. The calling thread can use a pseudo-handle to specify the impersonation token for that thread whenever a token handle is required. Child threads do not inherit pseudo-handles.
			/// <para>Starting in Windows 8, this pseudo-handle has only TOKEN_QUERY and TOKEN_QUERY_SOURCE access rights.</para>
			/// <para>A thread can create a standard handle that is valid in the context of other threads and can be inherited by other threads. To create this standard handle, call the DuplicateHandle function and specify the pseudo-handle as the source handle.</para>
			/// <para>You do not need to close the pseudo-handle when you no longer need it. If you call the CloseHandle function with a pseudo-handle, the function has no effect. If you call DuplicateHandle to duplicate the pseudo-handle, however, you must close the duplicate handle.</para>
			/// </remarks>
			public static readonly SafeTokenHandle CurrentThreadToken = new SafeTokenHandle((IntPtr)5, false);

			/// <summary>Initializes a new instance of the <see cref="SafeTokenHandle"/> class.</summary>
			/// <param name="hToken">The h token.</param>
			/// <param name="own">if set to <c>true</c> [own].</param>
			public SafeTokenHandle(IntPtr hToken, bool own = true) : base(hToken, CloseHandle, own)
			{
			}

			/// <summary>Initializes a new instance of the <see cref="SafeTokenHandle"/> class.</summary>
			internal SafeTokenHandle() : base(CloseHandle) { }

			/// <summary>Gets an instance that is equivalent to NULL HTOKEN.</summary>
			public static SafeTokenHandle Null { get; } = new SafeTokenHandle(IntPtr.Zero, false);
			/// <summary>Gets a value indicating whether this token is elevated.</summary>
			/// <value><c>true</c> if this instance is elevated; otherwise, <c>false</c>.</value>
			public bool IsElevated => GetInfo<TOKEN_ELEVATION>(TOKEN_INFORMATION_CLASS.TokenElevation).TokenIsElevated;

			/// <summary>Get the token handle instance from a process handle.</summary>
			/// <param name="hProcess">The process handle.</param>
			/// <param name="desiredAccess">The desired access. TOKEN_DUPLICATE must usually be included.</param>
			/// <returns>Resulting token handle.</returns>
			public static SafeTokenHandle FromProcess(IntPtr hProcess, TokenAccess desiredAccess = TokenAccess.TOKEN_DUPLICATE) => 
				!OpenProcessToken(hProcess, desiredAccess, out SafeTokenHandle val) ? throw new Win32Exception() : val;

			/// <summary>Get the token handle instance from a process handle.</summary>
			/// <param name="hThread">The thread handle.</param>
			/// <param name="desiredAccess">The desired access. TOKEN_DUPLICATE must usually be included.</param>
			/// <param name="openAsSelf">if set to <c>true</c> open as self.</param>
			/// <returns>Resulting token handle.</returns>
			public static SafeTokenHandle FromThread(IntPtr hThread, TokenAccess desiredAccess = TokenAccess.TOKEN_DUPLICATE, bool openAsSelf = true)
			{
				if (!OpenThreadToken(hThread, desiredAccess, openAsSelf, out SafeTokenHandle val))
				{
					if (Marshal.GetLastWin32Error() == Win32Error.ERROR_NO_TOKEN)
					{
						var pval = FromProcess(System.Diagnostics.Process.GetCurrentProcess().Handle);
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

			/// <summary>
			/// Retrieves a specified type of information about an access token cast to supplied <typeparamref name="T"/> type. The calling process must have
			/// appropriate access rights to obtain the information. <note type="note">The caller is responsible for ensuring that the type requested by
			/// <typeparamref name="T"/> matches the type information requested by <paramref name="tokenInfoClass"/>.</note>
			/// </summary>
			/// <param name="tokenInfoClass">
			/// Specifies a value from the TOKEN_INFORMATION_CLASS enumerated type to identify the type of information the function retrieves. Any callers who
			/// check the TokenIsAppContainer and have it return 0 should also verify that the caller token is not an identify level impersonation token. If the
			/// current token is not an application container but is an identity level token, you should return AccessDenied.
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
							var i = Marshal.ReadInt32((IntPtr) pType);
							if (typeof(T).IsEnum)
								return (T) Enum.ToObject(typeof(T), i);
							return (T)Convert.ChangeType(i, typeof(T));

						case TOKEN_INFORMATION_CLASS.TokenLinkedToken:
							if (typeof(T) == typeof(IntPtr))
								return (T)Convert.ChangeType(Marshal.ReadIntPtr((IntPtr)pType), typeof(T));
							return default(T);

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
							return (T)Convert.ChangeType(PTOKEN_PRIVILEGES.FromPtr((IntPtr) pType), typeof(T));

						default:
							return default(T);
					}
				}
			}

			/// <summary>
			/// Retrieves a specified type of information about an access token. The calling process must have appropriate access rights to obtain the information.
			/// </summary>
			/// <param name="tokenInfoClass">
			/// Specifies a value from the TOKEN_INFORMATION_CLASS enumerated type to identify the type of information the function retrieves. Any callers who
			/// check the TokenIsAppContainer and have it return 0 should also verify that the caller token is not an identify level impersonation token. If the
			/// current token is not an application container but is an identity level token, you should return AccessDenied.
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
	}
}
