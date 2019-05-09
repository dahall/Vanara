using System;
using System.Runtime.InteropServices;
using System.Text;

namespace Vanara.PInvoke
{
	public static partial class AdvApi32
	{
		/// <summary>The <c>ImpersonateNamedPipeClient</c> function impersonates a named-pipe client application.</summary>
		/// <param name="hNamedPipe">A handle to a named pipe.</param>
		/// <returns>
		/// <para>If the function succeeds, the return value is nonzero.</para>
		/// <para>If the function fails, the return value is zero. To get extended error information, call <c>GetLastError</c>.</para>
		/// </returns>
		// BOOL WINAPI ImpersonateNamedPipeClient( _In_ HANDLE hNamedPipe); https://msdn.microsoft.com/en-us/library/windows/desktop/aa378618(v=vs.85).aspx
		[DllImport(Lib.AdvApi32, SetLastError = true, ExactSpelling = true)]
		[PInvokeData("winbase.h", MSDNShortId = "aa378618")]
		[return: MarshalAs(UnmanagedType.Bool)]
		public static extern bool ImpersonateNamedPipeClient(HFILE hNamedPipe);

		/// <summary>
		/// The LogonUser function attempts to log a user on to the local computer. The local computer is the computer from which LogonUser
		/// was called. You cannot use LogonUser to log on to a remote computer. You specify the user with a user name and domain and
		/// authenticate the user with a plain-text password. If the function succeeds, you receive a handle to a token that represents the
		/// logged-on user. You can then use this token handle to impersonate the specified user or, in most cases, to create a process that
		/// runs in the context of the specified user.
		/// </summary>
		/// <param name="lpszUserName">
		/// A pointer to a null-terminated string that specifies the name of the user. This is the name of the user account to log on to. If
		/// you use the user principal name (UPN) format, User@DNSDomainName, the lpszDomain parameter must be NULL.
		/// </param>
		/// <param name="lpszDomain">
		/// A pointer to a null-terminated string that specifies the name of the domain or server whose account database contains the
		/// lpszUsername account. If this parameter is NULL, the user name must be specified in UPN format. If this parameter is ".", the
		/// function validates the account by using only the local account database.
		/// </param>
		/// <param name="lpszPassword">
		/// A pointer to a null-terminated string that specifies the plain-text password for the user account specified by lpszUsername. When
		/// you have finished using the password, clear the password from memory by calling the SecureZeroMemory function. For more
		/// information about protecting passwords, see Handling Passwords.
		/// </param>
		/// <param name="dwLogonType">The type of logon operation to perform.</param>
		/// <param name="dwLogonProvider">Specifies the logon provider.</param>
		/// <param name="phObject">
		/// A pointer to a handle variable that receives a handle to a token that represents the specified user.
		/// <para>You can use the returned handle in calls to the ImpersonateLoggedOnUser function.</para>
		/// <para>
		/// In most cases, the returned handle is a primary token that you can use in calls to the CreateProcessAsUser function. However, if
		/// you specify the LOGON32_LOGON_NETWORK flag, LogonUser returns an impersonation token that you cannot use in CreateProcessAsUser
		/// unless you call DuplicateTokenEx to convert it to a primary token.
		/// </para>
		/// <para>When you no longer need this handle, close it by calling the CloseHandle function.</para>
		/// </param>
		/// <returns>
		/// If the function succeeds, the return value is nonzero. If the function fails, the return value is zero. To get extended error
		/// information, call GetLastError.
		/// </returns>
		[DllImport(Lib.AdvApi32, SetLastError = true, CharSet = CharSet.Auto, BestFitMapping = false, ThrowOnUnmappableChar = true)]
		[return: MarshalAs(UnmanagedType.Bool)]
		[PInvokeData("winbase.h", MSDNShortId = "aa378184")]
		public static extern bool LogonUser(string lpszUserName, string lpszDomain, string lpszPassword, LogonUserType dwLogonType, LogonUserProvider dwLogonProvider,
			out SafeHTOKEN phObject);

		/// <summary>
		/// The LogonUserEx function attempts to log a user on to the local computer. The local computer is the computer from which
		/// LogonUserEx was called. You cannot use LogonUserEx to log on to a remote computer. You specify the user with a user name and
		/// domain and authenticate the user with a plaintext password. If the function succeeds, you receive a handle to a token that
		/// represents the logged-on user. You can then use this token handle to impersonate the specified user or, in most cases, to create
		/// a process that runs in the context of the specified user.
		/// </summary>
		/// <param name="lpszUserName">
		/// A pointer to a null-terminated string that specifies the name of the user. This is the name of the user account to log on to. If
		/// you use the user principal name (UPN) format, user@DNS_domain_name, the lpszDomain parameter must be NULL.
		/// </param>
		/// <param name="lpszDomain">
		/// A pointer to a null-terminated string that specifies the name of the domain or server whose account database contains the
		/// lpszUsername account. If this parameter is NULL, the user name must be specified in UPN format. If this parameter is ".", the
		/// function validates the account by using only the local account database.
		/// </param>
		/// <param name="lpszPassword">
		/// A pointer to a null-terminated string that specifies the plaintext password for the user account specified by lpszUsername. When
		/// you have finished using the password, clear the password from memory by calling the SecureZeroMemory function. For more
		/// information about protecting passwords, see Handling Passwords.
		/// </param>
		/// <param name="dwLogonType">The type of logon operation to perform.</param>
		/// <param name="dwLogonProvider">The logon provider.</param>
		/// <param name="phObject">
		/// A pointer to a handle variable that receives a handle to a token that represents the specified user.
		/// <para>You can use the returned handle in calls to the ImpersonateLoggedOnUser function.</para>
		/// <para>
		/// In most cases, the returned handle is a primary token that you can use in calls to the CreateProcessAsUser function. However, if
		/// you specify the LOGON32_LOGON_NETWORK flag, LogonUser returns an impersonation token that you cannot use in CreateProcessAsUser
		/// unless you call DuplicateTokenEx to convert it to a primary token.
		/// </para>
		/// <para>When you no longer need this handle, close it by calling the CloseHandle function.</para>
		/// </param>
		/// <param name="ppLogonSid">
		/// A pointer to a pointer to a security identifier (SID) that receives the SID of the user logged on.
		/// <para>When you have finished using the SID, free it by calling the LocalFree function.</para>
		/// </param>
		/// <param name="ppProfileBuffer">
		/// A pointer to a pointer that receives the address of a buffer that contains the logged on user's profile.
		/// </param>
		/// <param name="pdwProfileLength">A pointer to a DWORD that receives the length of the profile buffer.</param>
		/// <param name="pQuotaLimits">
		/// A pointer to a QUOTA_LIMITS structure that receives information about the quotas for the logged on user.
		/// </param>
		/// <returns>
		/// If the function succeeds, the function returns nonzero. If the function fails, it returns zero. To get extended error
		/// information, call GetLastError.
		/// </returns>
		[DllImport(Lib.AdvApi32, SetLastError = true, CharSet = CharSet.Auto, BestFitMapping = false, ThrowOnUnmappableChar = true)]
		[return: MarshalAs(UnmanagedType.Bool)]
		[PInvokeData("winbase.h", MSDNShortId = "aa378189")]
		public static extern bool LogonUserEx(string lpszUserName, string lpszDomain, string lpszPassword, LogonUserType dwLogonType, LogonUserProvider dwLogonProvider,
			out SafeHTOKEN phObject, out PSID ppLogonSid, out SafeLsaReturnBufferHandle ppProfileBuffer, out uint pdwProfileLength, out QUOTA_LIMITS pQuotaLimits);

		/// <summary>
		/// <para>
		/// The <c>LogonUserExExW</c> function attempts to log a user on to the local computer. The local computer is the computer from which
		/// <c>LogonUserExExW</c> was called. You cannot use <c>LogonUserExExW</c> to log on to a remote computer. Specify the user by using
		/// a user name and domain and authenticate the user by using a plaintext password. If the function succeeds, it receives a handle to
		/// a token that represents the logged-on user. You can then use this token handle to impersonate the specified user or, in most
		/// cases, to create a process that runs in the context of the specified user.
		/// </para>
		/// <para>
		/// This function is similar to the <c>LogonUserEx</c> function, except that it takes the additional parameter, pTokenGroups, which
		/// is a set of one or more security identifiers (SIDs) that are added to the token returned to the caller when the logon is successful.
		/// </para>
		/// <para>
		/// This function is not declared in a public header and has no associated import library. You must use the <c>LoadLibrary</c> and
		/// <c>GetProcAddress</c> functions to dynamically link to Advapi32.dll.
		/// </para>
		/// </summary>
		/// <param name="lpszUserName">
		/// A pointer to a null-terminated string that specifies the name of the user. This is the name of the user account to log on to. If
		/// you use the user principal name (UPN) format, user@DNS_domain_name, the lpszDomain parameter must be NULL.
		/// </param>
		/// <param name="lpszDomain">
		/// A pointer to a null-terminated string that specifies the name of the domain or server whose account database contains the
		/// lpszUsername account. If this parameter is NULL, the user name must be specified in UPN format. If this parameter is ".", the
		/// function validates the account by using only the local account database.
		/// </param>
		/// <param name="lpszPassword">
		/// A pointer to a null-terminated string that specifies the plaintext password for the user account specified by lpszUsername. When
		/// you have finished using the password, clear the password from memory by calling the SecureZeroMemory function. For more
		/// information about protecting passwords, see Handling Passwords.
		/// </param>
		/// <param name="dwLogonType">The type of logon operation to perform.</param>
		/// <param name="dwLogonProvider">The logon provider.</param>
		/// <param name="pTokenGroups">A pointer to a TOKEN_GROUPS structure that specifies a list of group SIDs that are added to the token that this function receives upon successful logon. Any SIDs added to the token also effect group expansion. For example, if the added SIDs are members of local groups, those groups are also added to the received access token.
		/// <para>If this parameter is not NULL, the caller of this function must have the SE_TCB_PRIVILEGE privilege granted and enabled.</para></param>
		/// <param name="phToken">A pointer to a handle variable that receives a handle to a token that represents the specified user.
		/// <para>You can use the returned handle in calls to the ImpersonateLoggedOnUser function.</para>
		/// <para>In most cases, the returned handle is a primary token that you can use in calls to the CreateProcessAsUser function.However, if you specify the LOGON32_LOGON_NETWORK flag, LogonUserExExW returns an impersonation token that you cannot use in CreateProcessAsUser unless you call DuplicateTokenEx to convert the impersonation token to a primary token.</para>
		/// <para>When you no longer need this handle, close it by calling the CloseHandle function.</para></param>
		/// <param name="ppLogonSid">A pointer to a pointer to a SID that receives the SID of the user logged on.
		/// <para>When you have finished using the SID, free it by calling the LocalFree function.</para></param>
		/// <param name="ppProfileBuffer">A pointer to a pointer that receives the address of a buffer that contains the logged on user's profile.</param>
		/// <param name="pdwProfileLength">A pointer to a DWORD that receives the length of the profile buffer.</param>
		/// <param name="pQuotaLimits">A pointer to a QUOTA_LIMITS structure that receives information about the quotas for the logged on user.</param>
		/// <returns>
		/// <para>If the function succeeds, the function returns nonzero.</para>
		/// <para>If the function fails, it returns zero. To get extended error information, call <c>GetLastError</c>.</para>
		/// </returns>
		/// <remarks>
		/// <para>The <c>LOGON32_LOGON_NETWORK</c> logon type is fastest, but it has the following limitations:</para>
		/// <list type="bullet">
		///   <item>
		///     <term>
		/// The function returns an impersonation token, not a primary token. You cannot use this token directly in the
		/// <c>CreateProcessAsUser</c> function. However, you can call the <c>DuplicateTokenEx</c> function to convert the token to a primary
		/// token, and then use it in <c>CreateProcessAsUser</c>.
		/// </term>
		///   </item>
		///   <item>
		///     <term>
		/// If you convert the token to a primary token and use it in <c>CreateProcessAsUser</c> to start a process, the new process cannot
		/// access other network resources, such as remote servers or printers, through the redirector. An exception is that if the network
		/// resource is not access controlled, then the new process will be able to access it.
		/// </term>
		///   </item>
		/// </list>
		/// <para>
		/// The account specified by lpszUsername must have the necessary account rights. For example, to log on a user with the
		/// <c>LOGON32_LOGON_INTERACTIVE</c> flag, the user (or a group to which the user belongs) must have the
		/// <c>SE_INTERACTIVE_LOGON_NAME</c> account right. For a list of the account rights that affect the various logon operations, see
		/// Account Object Access Rights.
		/// </para>
		/// <para>
		/// A user is considered logged on if at least one token exists. If you call <c>CreateProcessAsUser</c> and then close the token, the
		/// user is still logged on until the process (and all child processes) have ended.
		/// </para>
		/// <para>If the optional pTokenGroups parameter is supplied, LSA will not add either the local SID or the logon SID automatically.</para>
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows/desktop/SecAuthN/logonuserexexw
		// BOOL WINAPI LogonUserExExW( _In_ LPTSTR lpszUsername, _In_opt_ LPTSTR lpszDomain, _In_opt_ LPTSTR lpszPassword, _In_ DWORD dwLogonType, _In_ DWORD dwLogonProvider, _In_opt_ PTOKEN_GROUPS pTokenGroups, _Out_opt_ PHANDLE phToken, _Out_opt_ PSID *ppLogonSid, _Out_opt_ PVOID *ppProfileBuffer, _Out_opt_ LPDWORD pdwProfileLength, _Out_opt_ PQUOTA_LIMITS pQuotaLimits );
		[DllImport(Lib.AdvApi32, SetLastError = true, ExactSpelling = true, CharSet = CharSet.Unicode)]
		[PInvokeData("", MSDNShortId = "d90db4c6-a711-4519-8b91-5069cee07738")]
		[return: MarshalAs(UnmanagedType.Bool)]
		public static extern bool LogonUserExExW(string lpszUsername, [Optional] string lpszDomain, [Optional] string lpszPassword, LogonUserType dwLogonType, LogonUserProvider dwLogonProvider,
			[In, Optional] in TOKEN_GROUPS pTokenGroups, out SafeHTOKEN phToken, out SafePSID ppLogonSid, out IntPtr ppProfileBuffer, out uint pdwProfileLength, out QUOTA_LIMITS pQuotaLimits);

		/// <summary>
		/// The LookupAccountName function accepts the name of a system and an account as input. It retrieves a security identifier (SID) for
		/// the account and the name of the domain on which the account was found.
		/// </summary>
		/// <param name="lpSystemName">
		/// A pointer to a null-terminated character string that specifies the name of the system. This string can be the name of a remote
		/// computer. If this string is NULL, the account name translation begins on the local system. If the name cannot be resolved on the
		/// local system, this function will try to resolve the name using domain controllers trusted by the local system. Generally, specify
		/// a value for lpSystemName only when the account is in an untrusted domain and the name of a computer in that domain is known.
		/// </param>
		/// <param name="lpAccountName">
		/// A pointer to a null-terminated string that specifies the account name.
		/// <para>
		/// Use a fully qualified string in the domain_name\user_name format to ensure that LookupAccountName finds the account in the
		/// desired domain.
		/// </para>
		/// </param>
		/// <param name="Sid">
		/// A pointer to a buffer that receives the SID structure that corresponds to the account name pointed to by the lpAccountName
		/// parameter. If this parameter is NULL, cbSid must be zero.
		/// </param>
		/// <param name="cbSid">
		/// A pointer to a variable. On input, this value specifies the size, in bytes, of the Sid buffer. If the function fails because the
		/// buffer is too small or if cbSid is zero, this variable receives the required buffer size.
		/// </param>
		/// <param name="ReferencedDomainName">
		/// A pointer to a buffer that receives the name of the domain where the account name is found. For computers that are not joined to
		/// a domain, this buffer receives the computer name. If this parameter is NULL, the function returns the required buffer size.
		/// </param>
		/// <param name="cchReferencedDomainName">
		/// A pointer to a variable. On input, this value specifies the size, in TCHARs, of the ReferencedDomainName buffer. If the function
		/// fails because the buffer is too small, this variable receives the required buffer size, including the terminating null character.
		/// If the ReferencedDomainName parameter is NULL, this parameter must be zero.
		/// </param>
		/// <param name="peUse">A pointer to a SID_NAME_USE enumerated type that indicates the type of the account when the function returns.</param>
		/// <returns>
		/// If the function succeeds, the function returns nonzero. If the function fails, it returns zero. For extended error information,
		/// call GetLastError.
		/// </returns>
		[DllImport(Lib.AdvApi32, CharSet = CharSet.Auto, SetLastError = true)]
		[return: MarshalAs(UnmanagedType.Bool)]
		[PInvokeData("winbase.h", MSDNShortId = "aa379159")]
		public static extern bool LookupAccountName(string lpSystemName, string lpAccountName, SafePSID Sid, ref int cbSid,
			StringBuilder ReferencedDomainName, ref int cchReferencedDomainName, out SID_NAME_USE peUse);

		/// <summary>
		/// The LookupAccountName function accepts the name of a system and an account as input. It retrieves a security identifier (SID) for
		/// the account and the name of the domain on which the account was found.
		/// </summary>
		/// <param name="systemName">
		/// A string that specifies the name of the system. This string can be the name of a remote computer. If this string is NULL, the
		/// account name translation begins on the local system. If the name cannot be resolved on the local system, this function will try
		/// to resolve the name using domain controllers trusted by the local system. Generally, specify a value for lpSystemName only when
		/// the account is in an untrusted domain and the name of a computer in that domain is known.
		/// </param>
		/// <param name="accountName">
		/// A string that specifies the account name.
		/// <para>
		/// Use a fully qualified string in the domain_name\user_name format to ensure that LookupAccountName finds the account in the
		/// desired domain.
		/// </para>
		/// </param>
		/// <param name="sid">A PSID class that corresponds to the account name pointed to by the lpAccountName parameter.</param>
		/// <param name="domainName">
		/// A string that receives the name of the domain where the account name is found. For computers that are not joined to a domain,
		/// this buffer receives the computer name.
		/// </param>
		/// <param name="snu">A SID_NAME_USE enumerated type that indicates the type of the account when the function returns.</param>
		/// <returns>
		/// If the function succeeds, the function returns nonzero. If the function fails, it returns zero. For extended error information,
		/// call GetLastError.
		/// </returns>
		[PInvokeData("winbase.h", MSDNShortId = "aa379159")]
		public static bool LookupAccountName(string systemName, string accountName, out SafePSID sid, out string domainName, out SID_NAME_USE snu)
		{
			var sb = new StringBuilder(1024);
			sid = new SafePSID(256);
			var sidSz = sid.Size;
			var sbSz = sb.Capacity;
			var ret = LookupAccountName(systemName, accountName, sid, ref sidSz, sb, ref sbSz, out snu);
			domainName = sb.ToString();
			return ret;
		}

		/// <summary>
		/// The LookupAccountSid function accepts a security identifier (SID) as input. It retrieves the name of the account for this SID and
		/// the name of the first domain on which this SID is found.
		/// </summary>
		/// <param name="lpSystemName">
		/// A pointer to a null-terminated character string that specifies the target computer. This string can be the name of a remote
		/// computer. If this parameter is NULL, the account name translation begins on the local system. If the name cannot be resolved on
		/// the local system, this function will try to resolve the name using domain controllers trusted by the local system. Generally,
		/// specify a value for lpSystemName only when the account is in an untrusted domain and the name of a computer in that domain is known.
		/// </param>
		/// <param name="lpSid">A pointer to the SID to look up.</param>
		/// <param name="lpName">
		/// A pointer to a buffer that receives a null-terminated string that contains the account name that corresponds to the lpSid parameter.
		/// </param>
		/// <param name="cchName">
		/// On input, specifies the size, in TCHARs, of the lpName buffer. If the function fails because the buffer is too small or if
		/// cchName is zero, cchName receives the required buffer size, including the terminating null character.
		/// </param>
		/// <param name="lpReferencedDomainName">
		/// A pointer to a buffer that receives a null-terminated string that contains the name of the domain where the account name was found.
		/// <para>
		/// On a server, the domain name returned for most accounts in the security database of the local computer is the name of the domain
		/// for which the server is a domain controller.
		/// </para>
		/// <para>
		/// On a workstation, the domain name returned for most accounts in the security database of the local computer is the name of the
		/// computer as of the last start of the system (backslashes are excluded). If the name of the computer changes, the old name
		/// continues to be returned as the domain name until the system is restarted.
		/// </para>
		/// <para>Some accounts are predefined by the system. The domain name returned for these accounts is BUILTIN.</para>
		/// </param>
		/// <param name="cchReferencedDomainName">
		/// On input, specifies the size, in TCHARs, of the lpReferencedDomainName buffer. If the function fails because the buffer is too
		/// small or if cchReferencedDomainName is zero, cchReferencedDomainName receives the required buffer size, including the terminating
		/// null character.
		/// </param>
		/// <param name="peUse">A pointer to a variable that receives a SID_NAME_USE value that indicates the type of the account.</param>
		/// <returns>
		/// If the function succeeds, the function returns nonzero. If the function fails, it returns zero. To get extended error
		/// information, call GetLastError.
		/// </returns>
		[DllImport(Lib.AdvApi32, CharSet = CharSet.Auto, SetLastError = true, BestFitMapping = false, ThrowOnUnmappableChar = true)]
		[return: MarshalAs(UnmanagedType.Bool)]
		[PInvokeData("winbase.h", MSDNShortId = "aa379166")]
		public static extern bool LookupAccountSid(string lpSystemName, byte[] lpSid, StringBuilder lpName, ref int cchName,
			StringBuilder lpReferencedDomainName, ref int cchReferencedDomainName, out SID_NAME_USE peUse);

		/// <summary>
		/// The LookupAccountSid function accepts a security identifier (SID) as input. It retrieves the name of the account for this SID and
		/// the name of the first domain on which this SID is found.
		/// </summary>
		/// <param name="lpSystemName">
		/// A pointer to a null-terminated character string that specifies the target computer. This string can be the name of a remote
		/// computer. If this parameter is NULL, the account name translation begins on the local system. If the name cannot be resolved on
		/// the local system, this function will try to resolve the name using domain controllers trusted by the local system. Generally,
		/// specify a value for lpSystemName only when the account is in an untrusted domain and the name of a computer in that domain is known.
		/// </param>
		/// <param name="lpSid">A pointer to the SID to look up.</param>
		/// <param name="lpName">
		/// A pointer to a buffer that receives a null-terminated string that contains the account name that corresponds to the lpSid parameter.
		/// </param>
		/// <param name="cchName">
		/// On input, specifies the size, in TCHARs, of the lpName buffer. If the function fails because the buffer is too small or if
		/// cchName is zero, cchName receives the required buffer size, including the terminating null character.
		/// </param>
		/// <param name="lpReferencedDomainName">
		/// A pointer to a buffer that receives a null-terminated string that contains the name of the domain where the account name was found.
		/// <para>
		/// On a server, the domain name returned for most accounts in the security database of the local computer is the name of the domain
		/// for which the server is a domain controller.
		/// </para>
		/// <para>
		/// On a workstation, the domain name returned for most accounts in the security database of the local computer is the name of the
		/// computer as of the last start of the system (backslashes are excluded). If the name of the computer changes, the old name
		/// continues to be returned as the domain name until the system is restarted.
		/// </para>
		/// <para>Some accounts are predefined by the system. The domain name returned for these accounts is BUILTIN.</para>
		/// </param>
		/// <param name="cchReferencedDomainName">
		/// On input, specifies the size, in TCHARs, of the lpReferencedDomainName buffer. If the function fails because the buffer is too
		/// small or if cchReferencedDomainName is zero, cchReferencedDomainName receives the required buffer size, including the terminating
		/// null character.
		/// </param>
		/// <param name="peUse">A pointer to a variable that receives a SID_NAME_USE value that indicates the type of the account.</param>
		/// <returns>
		/// If the function succeeds, the function returns nonzero. If the function fails, it returns zero. To get extended error
		/// information, call GetLastError.
		/// </returns>
		[DllImport(Lib.AdvApi32, CharSet = CharSet.Auto, SetLastError = true, BestFitMapping = false, ThrowOnUnmappableChar = true)]
		[return: MarshalAs(UnmanagedType.Bool)]
		[PInvokeData("winbase.h", MSDNShortId = "aa379166")]
		public static extern bool LookupAccountSid(string lpSystemName, PSID lpSid, StringBuilder lpName, ref int cchName,
			StringBuilder lpReferencedDomainName, ref int cchReferencedDomainName, out SID_NAME_USE peUse);

		/// <summary>
		/// <para>The <c>LookupPrivilegeDisplayName</c> function retrieves the display name that represents a specified privilege.</para>
		/// </summary>
		/// <param name="lpSystemName">
		/// <para>
		/// A pointer to a null-terminated string that specifies the name of the system on which the privilege name is retrieved. If a null
		/// string is specified, the function attempts to find the display name on the local system.
		/// </para>
		/// </param>
		/// <param name="lpName">
		/// <para>
		/// A pointer to a null-terminated string that specifies the name of the privilege, as defined in Winnt.h. For example, this
		/// parameter could specify the constant, SE_REMOTE_SHUTDOWN_NAME, or its corresponding string, "SeRemoteShutdownPrivilege". For a
		/// list of values, see Privilege Constants.
		/// </para>
		/// </param>
		/// <param name="lpDisplayName">
		/// <para>
		/// A pointer to a buffer that receives a null-terminated string that specifies the privilege display name. For example, if the
		/// lpName parameter is SE_REMOTE_SHUTDOWN_NAME, the privilege display name is "Force shutdown from a remote system."
		/// </para>
		/// </param>
		/// <param name="cchDisplayName">
		/// <para>
		/// A pointer to a variable that specifies the size, in <c>TCHAR</c> s, of the lpDisplayName buffer. When the function returns, this
		/// parameter contains the length of the privilege display name, not including the terminating null character. If the buffer pointed
		/// to by the lpDisplayName parameter is too small, this variable contains the required size.
		/// </para>
		/// </param>
		/// <param name="lpLanguageId">
		/// <para>A pointer to a variable that receives the language identifier for the returned display name.</para>
		/// </param>
		/// <returns>
		/// <para>If the function succeeds, the return value is nonzero.</para>
		/// <para>If the function fails, the return value is zero. To get extended error information, call GetLastError.</para>
		/// </returns>
		/// <remarks>
		/// <para>
		/// The <c>LookupPrivilegeDisplayName</c> function retrieves display names only for the privileges specified in the Defined
		/// Privileges section of Winnt.h.
		/// </para>
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows/desktop/api/winbase/nf-winbase-lookupprivilegedisplaynamea BOOL
		// LookupPrivilegeDisplayNameA( LPCSTR lpSystemName, LPCSTR lpName, LPSTR lpDisplayName, LPDWORD cchDisplayName, LPDWORD lpLanguageId );
		[DllImport(Lib.AdvApi32, SetLastError = true, CharSet = CharSet.Auto)]
		[PInvokeData("winbase.h", MSDNShortId = "1fbb26b6-615e-4883-9f4b-3a1d05d9feaa")]
		[return: MarshalAs(UnmanagedType.Bool)]
		public static extern bool LookupPrivilegeDisplayName(string lpSystemName, string lpName, StringBuilder lpDisplayName, ref uint cchDisplayName, out uint lpLanguageId);

		/// <summary>
		/// <para>
		/// The <c>LookupPrivilegeName</c> function retrieves the name that corresponds to the privilege represented on a specific system by
		/// a specified locally unique identifier (LUID).
		/// </para>
		/// </summary>
		/// <param name="lpSystemName">
		/// <para>
		/// A pointer to a null-terminated string that specifies the name of the system on which the privilege name is retrieved. If a null
		/// string is specified, the function attempts to find the privilege name on the local system.
		/// </para>
		/// </param>
		/// <param name="lpLuid">
		/// <para>A pointer to the LUID by which the privilege is known on the target system.</para>
		/// </param>
		/// <param name="lpName">
		/// <para>
		/// A pointer to a buffer that receives a null-terminated string that represents the privilege name. For example, this string could
		/// be "SeSecurityPrivilege".
		/// </para>
		/// </param>
		/// <param name="cchName">
		/// <para>
		/// A pointer to a variable that specifies the size, in a <c>TCHAR</c> value, of the lpName buffer. When the function returns, this
		/// parameter contains the length of the privilege name, not including the terminating null character. If the buffer pointed to by
		/// the lpName parameter is too small, this variable contains the required size.
		/// </para>
		/// </param>
		/// <returns>
		/// <para>If the function succeeds, the function returns nonzero.</para>
		/// <para>If the function fails, it returns zero. To get extended error information, call GetLastError.</para>
		/// </returns>
		/// <remarks>
		/// <para>
		/// The <c>LookupPrivilegeName</c> function supports only the privileges specified in the Defined Privileges section of Winnt.h. For
		/// a list of values, see Privilege Constants.
		/// </para>
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows/desktop/api/winbase/nf-winbase-lookupprivilegenamea BOOL LookupPrivilegeNameA( LPCSTR
		// lpSystemName, PLUID lpLuid, LPSTR lpName, LPDWORD cchName );
		[DllImport(Lib.AdvApi32, CharSet = CharSet.Auto, SetLastError = true, BestFitMapping = false, ThrowOnUnmappableChar = true)]
		[PInvokeData("winbase.h", MSDNShortId = "580fb58f-1470-4389-9f07-8f37403e2bdf")]
		[return: MarshalAs(UnmanagedType.Bool)]
		public static extern bool LookupPrivilegeName(string lpSystemName, in LUID lpLuid, StringBuilder lpName, ref int cchName);

		/// <summary>
		/// <para>
		/// The <c>LookupPrivilegeValue</c> function retrieves the locally unique identifier (LUID) used on a specified system to locally
		/// represent the specified privilege name.
		/// </para>
		/// </summary>
		/// <param name="lpSystemName">
		/// <para>
		/// A pointer to a null-terminated string that specifies the name of the system on which the privilege name is retrieved. If a null
		/// string is specified, the function attempts to find the privilege name on the local system.
		/// </para>
		/// </param>
		/// <param name="lpName">
		/// <para>
		/// A pointer to a null-terminated string that specifies the name of the privilege, as defined in the Winnt.h header file. For
		/// example, this parameter could specify the constant, SE_SECURITY_NAME, or its corresponding string, "SeSecurityPrivilege".
		/// </para>
		/// </param>
		/// <param name="lpLuid">
		/// <para>
		/// A pointer to a variable that receives the LUID by which the privilege is known on the system specified by the lpSystemName parameter.
		/// </para>
		/// </param>
		/// <returns>
		/// <para>If the function succeeds, the function returns nonzero.</para>
		/// <para>If the function fails, it returns zero. To get extended error information, call GetLastError.</para>
		/// </returns>
		/// <remarks>
		/// <para>
		/// The <c>LookupPrivilegeValue</c> function supports only the privileges specified in the Defined Privileges section of Winnt.h. For
		/// a list of values, see Privilege Constants.
		/// </para>
		/// <para>Examples</para>
		/// <para>For an example that uses this function, see Enabling and Disabling Privileges.</para>
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows/desktop/api/winbase/nf-winbase-lookupprivilegevaluea BOOL LookupPrivilegeValueA( LPCSTR
		// lpSystemName, LPCSTR lpName, PLUID lpLuid );
		[DllImport(Lib.AdvApi32, CharSet = CharSet.Auto, SetLastError = true, BestFitMapping = false, ThrowOnUnmappableChar = true)]
		[PInvokeData("winbase.h", MSDNShortId = "334b8ba8-101d-43a1-a8bf-1c7e0448c272")]
		[return: MarshalAs(UnmanagedType.Bool)]
		public static extern bool LookupPrivilegeValue(string lpSystemName, string lpName, out LUID lpLuid);

		/*
		AccessCheck
		AccessCheckByType
		AccessCheckByTypeResultList
		AdjustTokenGroups
		AdjustTokenPrivileges
		AllocateAndInitializeSid
		AllocateLocallyUniqueId
		AuthzAccessCheck
		AuthzAccessCheckCallback
		AuthzAddSidsToContext
		AuthzCachedAccessCheck
		AuthzComputeGroupsCallback
		AuthzEnumerateSecurityEventSources
		AuthzFreeAuditEvent
		AuthzFreeContext
		AuthzFreeGroupsCallback
		AuthzFreeHandle
		AuthzFreeResourceManager
		AuthzGetInformationFromContext
		AuthzInitializeContextFromAuthzContext
		AuthzInitializeContextFromSid
		AuthzInitializeContextFromToken
		AuthzInitializeObjectAccessAuditEvent
		AuthzInitializeObjectAccessAuditEvent2
		AuthzInitializeResourceManager
		AuthzInstallSecurityEventSource
		AuthzOpenObjectAudit
		AuthzRegisterSecurityEventSource
		AuthzReportSecurityEvent
		AuthzReportSecurityEventFromParams
		AuthzUninstallSecurityEventSource
		AuthzUnregisterSecurityEventSource
		BuildExplicitAccessWithName
		BuildImpersonateExplicitAccessWithName
		BuildImpersonateTrustee
		BuildTrusteeWithName
		BuildTrusteeWithObjectsAndName
		BuildTrusteeWithObjectsAndSid
		BuildTrusteeWithSid
		CheckTokenMembership
		ConvertSecurityDescriptorToStringSecurityDescriptor
		ConvertSidToStringSid
		ConvertStringSecurityDescriptorToSecurityDescriptor
		ConvertStringSidToSid
		CopySid
		CreateRestrictedToken
		CreateWellKnownSid
		DuplicateToken
		DuplicateTokenEx
		EqualDomainSid
		EqualPrefixSid
		EqualSid
		FreeSid
		GetAuditedPermissionsFromAcl
		GetEffectiveRightsFromAcl
		GetExplicitEntriesFromAcl
		GetLengthSid
		GetMultipleTrustee
		GetMultipleTrusteeOperation
		GetNamedSecurityInfo
		GetSecurityDescriptorControl
		GetSecurityInfo
		GetSidIdentifierAuthority
		GetSidLengthRequired
		GetSidSubAuthority
		GetSidSubAuthorityCount
		GetTokenInformation
		GetTrusteeForm
		GetTrusteeName
		GetTrusteeType
		GetWindowsAccountDomainSid
		InitializeSid
		IsTokenRestricted
		IsValidSid
		IsWellKnownSid
		LookupAccountName
		LookupAccountSid
		LookupAccountSidLocal
		LookupPrivilegeDisplayName
		LookupPrivilegeName
		LookupPrivilegeValue
		NtCompareTokens
		OpenProcessToken
		OpenThreadToken
		QuerySecurityAccessMask
		RtlConvertSidToUnicodeString
		SetEntriesInAcl
		SetNamedSecurityInfo
		SetSecurityAccessMask
		SetSecurityDescriptorControl
		SetSecurityInfo
		SetThreadToken
		SetTokenInformation
		TreeResetNamedSecurityInfo
		TreeSetNamedSecurityInfo
		*/
	}
}