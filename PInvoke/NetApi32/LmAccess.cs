using System;
using System.Runtime.InteropServices;
using Vanara.InteropServices;
using static Vanara.PInvoke.AdvApi32;
using FILETIME = System.Runtime.InteropServices.ComTypes.FILETIME;

namespace Vanara.PInvoke
{
	public static partial class NetApi32
	{
		public const uint UNITS_PER_DAY = 24;
		public const uint UNITS_PER_WEEK = UNITS_PER_DAY * 7;
		private const int ENCRYPTED_PWLEN = 16;

		/// <summary>A bitmask of flags that affect the operation.</summary>
		[PInvokeData("lmaccess.h", MSDNShortId = "cc5c1c15-cad7-4103-a2c9-1a8adf742703")]
		[Flags]
		public enum GetLocalGroupFlags
		{
			/// <summary>
			/// The function also returns the names of the local groups in which the user is indirectly a member (that is, the user has
			/// membership in a global group that is itself a member of one or more local groups).
			/// </summary>
			LG_INCLUDE_INDIRECT = 1
		}

		/// <summary>Specifies the role of the logon server.</summary>
		[PInvokeData("lmaccess.h", MSDNShortId = "2cb7f310-c76e-42fd-892c-fead374af16c")]
		public enum LogonServerRole
		{
			/// <summary>The logon server is a stand-alone server.</summary>
			UAS_ROLE_STANDALONE = 0,

			/// <summary>The logon server is a member.</summary>
			UAS_ROLE_MEMBER = 1,

			/// <summary>The logon server is a backup.</summary>
			UAS_ROLE_BACKUP = 2,

			/// <summary>The logon server is a domain controller.</summary>
			UAS_ROLE_PRIMARY = 3,
		}

		/// <summary>The type of password validation to perform.</summary>
		[PInvokeData("lmaccess.h", MSDNShortId = "be5ce51b-6568-49c8-954d-7b0d4bcb8611")]
		public enum NET_VALIDATE_PASSWORD_TYPE
		{
			/// <summary>
			/// The application is requesting password validation during authentication. The InputArg parameter points to a
			/// NET_VALIDATE_AUTHENTICATION_INPUT_ARG structure. This type of validation enforces password expiration and account lockout policy.
			/// </summary>
			[CorrespondingType(typeof(NET_VALIDATE_AUTHENTICATION_INPUT_ARG))]
			NetValidateAuthentication = 1,

			/// <summary>
			/// The application is requesting password validation during a password change operation. The InputArg parameter points to a
			/// NET_VALIDATE_PASSWORD_CHANGE_INPUT_ARG structure.
			/// </summary>
			[CorrespondingType(typeof(NET_VALIDATE_PASSWORD_CHANGE_INPUT_ARG))]
			NetValidatePasswordChange,

			/// <summary>
			/// The application is requesting password validation during a password reset operation. The InputArg parameter points to a
			/// NET_VALIDATE_PASSWORD_RESET_INPUT_ARG structure. You can also reset the "lockout state" of a user account by specifying this structure.
			/// </summary>
			[CorrespondingType(typeof(NET_VALIDATE_PASSWORD_RESET_INPUT_ARG))]
			NetValidatePasswordReset,
		}

		/// <summary>Flags for <see cref="NetAddServiceAccount"/>.</summary>
		[PInvokeData("lmaccess.h", MSDNShortId = "004bd392-8837-4d98-905a-cd19ed02817d")]
		[Flags]
		public enum SvcAcctAddFlag
		{
			/// <summary>
			/// No standalone managed service account is created. If a service account with the specified name exists, it is linked to the
			/// local computer. This flag is ignored if the account name is an existing gMSA.
			/// </summary>
			SERVICE_ACCOUNT_FLAG_LINK_TO_HOST_ONLY = 0x00000001,
		}

		/// <summary>Flags for <see cref="NetRemoveServiceAccount"/>.</summary>
		[PInvokeData("lmaccess.h", MSDNShortId = "f67745b7-bdfd-44bc-83e0-2ad24b78e137")]
		public enum SvcAcctRemFlag
		{
			/// <summary>
			/// For sMSAs, the service account object is unlinked from the local computer and the secret stored in the LSA is deleted. The
			/// service account object is not deleted from the Active Directory database. This flag has no meaning for gMSAs.
			/// </summary>
			SERVICE_ACCOUNT_FLAG_UNLINK_FROM_HOST_ONLY = 0x00000001,
		}

		/// <summary>User account control flags.</summary>
		[PInvokeData("lmaccess.h", MSDNShortId = "bdb1bef0-51f1-41d7-97fb-bda4ad24e386")]
		[Flags]
		public enum UserAcctCtrlFlags
		{
			/// <summary>The logon script executed. This value must be set.</summary>
			UF_SCRIPT = 0x0001,

			/// <summary>The user's account is disabled.</summary>
			UF_ACCOUNTDISABLE = 0x0002,

			/// <summary>The uf homedir required</summary>
			UF_HOMEDIR_REQUIRED = 0x0008,

			/// <summary>
			/// The account is currently locked out (blocked). For the NetUserSetInfo function, this value can be cleared to unlock a
			/// previously locked account. This value cannot be used to lock a previously unlocked account.
			/// </summary>
			UF_LOCKOUT = 0x0010,

			/// <summary>No password is required.</summary>
			UF_PASSWD_NOTREQD = 0x0020,

			/// <summary>The user cannot change the password.</summary>
			UF_PASSWD_CANT_CHANGE = 0x0040,

			/// <summary>The user's password is stored under reversible encryption in the Active Directory.</summary>
			UF_ENCRYPTED_TEXT_PASSWORD_ALLOWED = 0x0080,

			/// <summary>
			/// An account for users whose primary account is in another domain. This account provides user access to this domain, but not to
			/// any domain that trusts this domain. The User Manager refers to this account type as a local user account.
			/// </summary>
			UF_TEMP_DUPLICATE_ACCOUNT = 0x0100,

			/// <summary>A default account type that represents a typical user.</summary>
			UF_NORMAL_ACCOUNT = 0x0200,

			/// <summary>A permit to trust account for a domain that trusts other domains.</summary>
			UF_INTERDOMAIN_TRUST_ACCOUNT = 0x0800,

			/// <summary>A computer account for a workstation or a server that is a member of this domain.</summary>
			UF_WORKSTATION_TRUST_ACCOUNT = 0x1000,

			/// <summary>A computer account for a backup domain controller that is a member of this domain.</summary>
			UF_SERVER_TRUST_ACCOUNT = 0x2000,

			/// <summary>Mask for machine account flags.</summary>
			UF_MACHINE_ACCOUNT_MASK = (UF_INTERDOMAIN_TRUST_ACCOUNT | UF_WORKSTATION_TRUST_ACCOUNT | UF_SERVER_TRUST_ACCOUNT),

			/// <summary>Mask for account type flags</summary>
			UF_ACCOUNT_TYPE_MASK = (UF_TEMP_DUPLICATE_ACCOUNT | UF_NORMAL_ACCOUNT | UF_INTERDOMAIN_TRUST_ACCOUNT | UF_WORKSTATION_TRUST_ACCOUNT | UF_SERVER_TRUST_ACCOUNT),

			/// <summary>Represents the password, which will never expire on the account.</summary>
			UF_DONT_EXPIRE_PASSWD = 0x10000,

			/// <summary>This bit is ignored by clients and servers.</summary>
			UF_MNS_LOGON_ACCOUNT = 0x20000,

			/// <summary>Requires the user to log on to the user account with a smart card.</summary>
			UF_SMARTCARD_REQUIRED = 0x40000,

			/// <summary>
			/// The account is enabled for delegation. This is a security-sensitive setting; accounts with this option enabled should be
			/// tightly controlled. This setting allows a service running under the account to assume a client's identity and authenticate as
			/// that user to other remote servers on the network.
			/// </summary>
			UF_TRUSTED_FOR_DELEGATION = 0x80000,

			/// <summary>Marks the account as "sensitive"; other users cannot act as delegates of this user account.</summary>
			UF_NOT_DELEGATED = 0x100000,

			/// <summary>Restrict this principal to use only Data Encryption Standard (DES) encryption types for keys.</summary>
			UF_USE_DES_KEY_ONLY = 0x200000,

			/// <summary>This account does not require Kerberos preauthentication for logon.</summary>
			UF_DONT_REQUIRE_PREAUTH = 0x400000,

			/// <summary>
			/// The user's password has expired.
			/// <para>Windows 2000: This value is not supported.</para>
			/// </summary>
			UF_PASSWORD_EXPIRED = 0x800000,

			/// <summary>
			/// The account is trusted to authenticate a user outside of the Kerberos security package and delegate that user through
			/// constrained delegation. This is a security-sensitive setting; accounts with this option enabled should be tightly controlled.
			/// This setting allows a service running under the account to assert a client's identity and authenticate as that user to
			/// specifically configured services on the network.
			/// <para>Windows XP/2000: This value is not supported.</para>
			/// </summary>
			UF_TRUSTED_TO_AUTHENTICATE_FOR_DELEGATION = 0x1000000,

			/// <summary>
			/// This bit is used by the Kerberos protocol. It indicates that when the key distribution center (KDC) is issuing a service
			/// ticket for this account, the privilege attribute certificate (PAC) is not to be included. For more information, see [RFC4120].
			/// </summary>
			UF_NO_AUTH_DATA_REQUIRED = 0x2000000,

			/// <summary>Specifies that the object is a read-only domain controller (RODC).</summary>
			UF_PARTIAL_SECRETS_ACCOUNT = 0x4000000,

			/// <summary>This bit is ignored by clients and servers.</summary>
			UF_USE_AES_KEYS = 0x8000000,

			/// <summary>Mask for settable flags.</summary>
			UF_SETTABLE_BITS = (UF_SCRIPT | UF_ACCOUNTDISABLE | UF_LOCKOUT | UF_HOMEDIR_REQUIRED | UF_PASSWD_NOTREQD | UF_PASSWD_CANT_CHANGE | UF_ACCOUNT_TYPE_MASK | UF_DONT_EXPIRE_PASSWD | UF_MNS_LOGON_ACCOUNT | UF_ENCRYPTED_TEXT_PASSWORD_ALLOWED | UF_SMARTCARD_REQUIRED | UF_TRUSTED_FOR_DELEGATION | UF_NOT_DELEGATED | UF_USE_DES_KEY_ONLY | UF_DONT_REQUIRE_PREAUTH | UF_PASSWORD_EXPIRED | UF_TRUSTED_TO_AUTHENTICATE_FOR_DELEGATION | UF_NO_AUTH_DATA_REQUIRED | UF_USE_AES_KEYS | UF_PARTIAL_SECRETS_ACCOUNT)
		}

		/// <summary>
		/// A value that specifies the user account types to be included in the enumeration. A value of zero indicates that all normal user,
		/// trust data, and machine account data should be included.
		/// </summary>
		[PInvokeData("lmaccess.h", MSDNShortId = "b26ef3c0-934a-4840-8c06-4eaff5c9ff86")]
		[Flags]
		public enum UserEnumFilter
		{
			/// <summary>
			/// Enumerates account data for users whose primary account is in another domain. This account type provides user access to this
			/// domain, but not to any domain that trusts this domain. The User Manager refers to this account type as a local user account.
			/// </summary>
			FILTER_TEMP_DUPLICATE_ACCOUNT = 0x0001,

			/// <summary>Enumerates normal user account data. This account type is associated with a typical user.</summary>
			FILTER_NORMAL_ACCOUNT = 0x0002,

			/// <summary>Undocumented</summary>
			FILTER_PROXY_ACCOUNT = 0x0004,

			/// <summary>
			/// Enumerates interdomain trust account data. This account type is associated with a trust account for a domain that trusts
			/// other domains.
			/// </summary>
			FILTER_INTERDOMAIN_TRUST_ACCOUNT = 0x0008,

			/// <summary>
			/// Enumerates workstation or member server trust account data. This account type is associated with a machine account for a
			/// computer that is a member of the domain.
			/// </summary>
			FILTER_WORKSTATION_TRUST_ACCOUNT = 0x0010,

			/// <summary>
			/// Enumerates member server machine account data. This account type is associated with a computer account for a backup domain
			/// controller that is a member of the domain.
			/// </summary>
			FILTER_SERVER_TRUST_ACCOUNT = 0x0020,
		}

		/// <summary>A set of bit flags that specify the user's operator privileges.</summary>
		[PInvokeData("lmaccess.h", MSDNShortId = "6760729a-1d59-430e-8412-1257977af169")]
		[Flags]
		public enum UserOpPriv
		{
			/// <summary>The print operator privilege is enabled.</summary>
			AF_OP_PRINT = 0x1,

			/// <summary>The communications operator privilege is enabled.</summary>
			AF_OP_COMM = 0x2,

			/// <summary>The server operator privilege is enabled.</summary>
			AF_OP_SERVER = 0x4,

			/// <summary>The accounts operator privilege is enabled.</summary>
			AF_OP_ACCOUNTS = 0x8,
		}

		/// <summary>
		/// The level of privilege assigned to the usri[n]_name member. When you call the NetUserAdd function, this member must be
		/// USER_PRIV_USER. When you call the NetUserSetInfo function, this member must be the value returned by the NetUserGetInfo function
		/// or the NetUserEnum function.
		/// </summary>
		[PInvokeData("lmaccess.h", MSDNShortId = "f17a1aef-45f1-461f-975d-75221d08277c")]
		public enum UserPrivilege
		{
			/// <summary>Guest</summary>
			USER_PRIV_GUEST = 0,

			/// <summary>User</summary>
			USER_PRIV_USER = 1,

			/// <summary>Administrator</summary>
			USER_PRIV_ADMIN = 2,
		}

		/// <summary>
		/// <para>
		/// The <c>NetAddServiceAccount</c> function creates a standalone managed service account (sMSA) or retrieves the credentials for a
		/// group managed service account (gMSA) and stores the account information on the local computer.
		/// </para>
		/// <para>
		/// This function has no associated import library. You must use the LoadLibrary and GetProcAddress functions to dynamically link to Logoncli.dll.
		/// </para>
		/// <para>
		/// <c>Windows Server 2008 R2:</c> Installing a managed service account by using the PowerShell command line interface cmdlet to call
		/// this function fails with error code 0xC0000225 when the value of the AccountName parameter does not match the corresponding
		/// Security Accounts Manager (SAM) name of the account.
		/// </para>
		/// </summary>
		/// <param name="ServerName">The value of this parameter must be <c>NULL</c>.</param>
		/// <param name="AccountName">The name of the account to be created.</param>
		/// <param name="Password">This parameter is reserved. Do not use it.</param>
		/// <param name="Flags">
		/// <para>This parameter can be the following value.</para>
		/// <list type="table">
		/// <listheader>
		/// <term>Value</term>
		/// <term>Meaning</term>
		/// </listheader>
		/// <item>
		/// <term>SERVICE_ACCOUNT_FLAG_LINK_TO_HOST_ONLY 0x00000001</term>
		/// <term>
		/// No standalone managed service account is created. If a service account with the specified name exists, it is linked to the local
		/// computer. This flag is ignored if the account name is an existing gMSA.
		/// </term>
		/// </item>
		/// </list>
		/// </param>
		/// <returns>
		/// <para>If the function succeeds, it returns <c>STATUS_SUCCESS</c>.</para>
		/// <para>If the function fails, it returns an error code.</para>
		/// </returns>
		// https://docs.microsoft.com/en-us/windows/desktop/api/lmaccess/nf-lmaccess-netaddserviceaccount NTSTATUS NetAddServiceAccount(
		// LPWSTR ServerName, LPWSTR AccountName, LPWSTR Password, DWORD Flags );
		[DllImport(Lib.NetApi32, SetLastError = false, ExactSpelling = true, CharSet = CharSet.Unicode)]
		[PInvokeData("lmaccess.h", MSDNShortId = "004bd392-8837-4d98-905a-cd19ed02817d")]
		public static extern NTStatus NetAddServiceAccount([Optional] string ServerName, string AccountName, [Optional] string Password, SvcAcctAddFlag Flags);

		/// <summary>
		/// <para>
		/// The <c>NetEnumerateServiceAccounts</c> function enumerates the standalone managed service accounts (sMSA) on the specified
		/// server. This function only enumerates sMSAs and not group managed service accounts (gMSA).
		/// </para>
		/// <para>
		/// This function has no associated import library. You must use the LoadLibrary and GetProcAddress functions to dynamically link to Logoncli.dll.
		/// </para>
		/// </summary>
		/// <param name="ServerName">The value of this parameter must be <c>NULL</c>.</param>
		/// <param name="Flags">This parameter is reserved. Do not use it.</param>
		/// <param name="AccountsCount">The number of elements in the Accounts array.</param>
		/// <param name="Accounts">
		/// <para>A pointer to an array of the names of the service accounts on the specified server.</para>
		/// <para>When you have finished using the names, free the array by calling the NetApiBufferFree function.</para>
		/// </param>
		/// <returns>
		/// <para>If the function succeeds, it returns <c>STATUS_SUCCESS</c>.</para>
		/// <para>If the function fails, it returns an error code.</para>
		/// </returns>
		// https://docs.microsoft.com/en-us/windows/desktop/api/lmaccess/nf-lmaccess-netenumerateserviceaccounts NTSTATUS
		// NetEnumerateServiceAccounts( LPWSTR ServerName, DWORD Flags, DWORD *AccountsCount, PZPWSTR *Accounts );
		[DllImport(Lib.NetApi32, SetLastError = false, ExactSpelling = true, CharSet = CharSet.Unicode)]
		[PInvokeData("lmaccess.h", MSDNShortId = "048116b6-1bae-4dcc-9bd0-a466c395e5d8")]
		public static extern NTStatus NetEnumerateServiceAccounts([Optional] string ServerName, [Optional] uint Flags, ref uint AccountsCount, [MarshalAs(UnmanagedType.LPArray)] string[] Accounts);

		/// <summary>
		/// <para>
		/// The <c>NetGetAnyDCName</c> function returns the name of any domain controller (DC) for a domain that is directly trusted by the
		/// specified server.
		/// </para>
		/// <para>
		/// Applications that support DNS-style names should call the DsGetDcName function. This function can locate any DC in any domain,
		/// whether or not the domain is directly trusted by the specified server.
		/// </para>
		/// </summary>
		/// <param name="servername">
		/// Pointer to a constant string that specifies the DNS or NetBIOS name of the remote server on which the function is to execute. If
		/// this parameter is <c>NULL</c>, the local computer is used. For more information, see the following Remarks section.
		/// </param>
		/// <param name="domainname">
		/// Pointer to a constant string that specifies the name of the domain. If this parameter is <c>NULL</c>, the name of the domain
		/// controller for the primary domain is used. For more information, see the following Remarks section.
		/// </param>
		/// <param name="bufptr">
		/// Pointer to an allocated buffer that receives a string that specifies the server name of a domain controller for the domain. The
		/// server name is prefixed by \. This buffer is allocated by the system and must be freed using the NetApiBufferFree function. For
		/// more information, see Network Management Function Buffers and Network Management Function Buffer Lengths.
		/// </param>
		/// <returns>
		/// <para>If the function succeeds, the return value is NERR_Success.</para>
		/// <para>If the function fails, the return value can be one of the following error codes.</para>
		/// <list type="table">
		/// <listheader>
		/// <term>Return code</term>
		/// <term>Description</term>
		/// </listheader>
		/// <item>
		/// <term>ERROR_NO_LOGON_SERVERS</term>
		/// <term>No domain controllers could be found.</term>
		/// </item>
		/// <item>
		/// <term>ERROR_NO_SUCH_DOMAIN</term>
		/// <term>The specified domain is not a trusted domain.</term>
		/// </item>
		/// <item>
		/// <term>ERROR_NO_TRUST_LSA_SECRET</term>
		/// <term>The client side of the trust relationship is broken.</term>
		/// </item>
		/// <item>
		/// <term>ERROR_NO_TRUST_SAM_ACCOUNT</term>
		/// <term>The server side of the trust relationship is broken or the password is broken.</term>
		/// </item>
		/// <item>
		/// <term>ERROR_DOMAIN_TRUST_INCONSISTENT</term>
		/// <term>The server that responded is not a proper domain controller of the specified domain.</term>
		/// </item>
		/// </list>
		/// </returns>
		/// <remarks>
		/// <para>No special group membership is required to successfully execute the <c>NetGetAnyDCName</c> function.</para>
		/// <para>If servername specifies a stand-alone workstation or a stand-alone server, no domainname is valid.</para>
		/// <para>
		/// If servername specifies a workstation that is a member of a domain, or a server that is a member of a domain, the domainname must
		/// be in the same domain as servername.
		/// </para>
		/// <para>
		/// If servername specifies a domain controller, the domainname must be one of the domains trusted by the domain for which the server
		/// is a controller. The domain controller that this call finds has been operational at least once during this call.
		/// </para>
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows/desktop/api/lmaccess/nf-lmaccess-netgetanydcname NET_API_STATUS NET_API_FUNCTION
		// NetGetAnyDCName( IN LPCWSTR servername, IN LPCWSTR domainname, LPBYTE *bufptr );
		[DllImport(Lib.NetApi32, SetLastError = false, ExactSpelling = true, CharSet = CharSet.Unicode)]
		[PInvokeData("lmaccess.h", MSDNShortId = "64dacbf4-46c2-4f82-b250-b7d338535e7c")]
		public static extern Win32Error NetGetAnyDCName([In, Optional] string servername, [In, Optional] string domainname,
			[MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef = typeof(NetApiBufferUnicodeStringMarshaler))] out string bufptr);

		/// <summary>
		/// <para>
		/// The <c>NetGetDCName</c> function returns the name of the primary domain controller (PDC). It does not return the name of the
		/// backup domain controller (BDC) for the specified domain. Also, you cannot remote this function to a non-PDC server.
		/// </para>
		/// <para>
		/// Applications that support DNS-style names should call the DsGetDcName function. Domain controllers in this type of environment
		/// have a multi-master directory replication relationship. Therefore, it may be advantageous for your application to use a DC that
		/// is not the PDC. You can call the <c>DsGetDcName</c> function to locate any DC in the domain; <c>NetGetDCName</c> returns only the
		/// name of the PDC.
		/// </para>
		/// </summary>
		/// <param name="servername">
		/// A pointer to a constant string that specifies the DNS or NetBIOS name of the remote server on which the function is to execute.
		/// If this parameter is <c>NULL</c>, the local computer is used.
		/// </param>
		/// <param name="domainname">
		/// A pointer to a constant string that specifies the name of the domain. The domain name must be a NetBIOS domain name (for example,
		/// microsoft). <c>NetGetDCName</c> does not support DNS-style names (for example, microsoft.com). If this parameter is <c>NULL</c>,
		/// the function returns the name of the domain controller for the primary domain.
		/// </param>
		/// <param name="bufptr">
		/// A pointer to an allocated buffer that receives a string that specifies the server name of the PDC of the domain. The server name
		/// is returned as Unicode string prefixed by \. This buffer is allocated by the system and must be freed using the NetApiBufferFree
		/// function. For more information, see Network Management Function Buffers and Network Management Function Buffer Lengths.
		/// </param>
		/// <returns>
		/// <para>If the function succeeds, the return value is NERR_Success.</para>
		/// <para>If the function fails, the return value can be one of the following error codes.</para>
		/// <list type="table">
		/// <listheader>
		/// <term>Return code</term>
		/// <term>Description</term>
		/// </listheader>
		/// <item>
		/// <term>NERR_DCNotFound</term>
		/// <term>Could not find the domain controller for the domain specified in the domainname parameter.</term>
		/// </item>
		/// <item>
		/// <term>ERROR_BAD_NETPATH</term>
		/// <term>
		/// The network path was not found. This error is returned if the computer specified in the servername parameter could not be found.
		/// </term>
		/// </item>
		/// <item>
		/// <term>ERROR_INVALID_NAME</term>
		/// <term>
		/// The name syntax is incorrect. This error is returned if the name specified in the servername parameter contains illegal characters.
		/// </term>
		/// </item>
		/// <item>
		/// <term>ERROR_NOT_SUPPORTED</term>
		/// <term>The request is not supported.</term>
		/// </item>
		/// </list>
		/// </returns>
		/// <remarks>
		/// <para>No special group membership is required to successfully execute the <c>NetGetDCName</c> function.</para>
		/// <para>Examples</para>
		/// <para>
		/// The following code sample demonstrates how to retrieve the primary domain controller using the <c>NetGetDCName</c> function. The
		/// sample calls <c>NetGetDCName</c> specifying the servername and domainname parameters. If the call succeeds, the code prints
		/// information out the name of the primary domain controller. Finally, the sample frees the memory allocated for the buffer where
		/// the domain controller name was returned.
		/// </para>
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows/desktop/api/lmaccess/nf-lmaccess-netgetdcname NET_API_STATUS NET_API_FUNCTION
		// NetGetDCName( IN LPCWSTR servername, IN LPCWSTR domainname, LPBYTE *bufptr );
		[DllImport(Lib.NetApi32, SetLastError = false, ExactSpelling = true, CharSet = CharSet.Unicode)]
		[PInvokeData("lmaccess.h", MSDNShortId = "3e32aacc-088e-455a-bc1b-92274e98d2e5")]
		public static extern Win32Error NetGetDCName([In, Optional] string servername, [In, Optional] string domainname,
			[MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef = typeof(NetApiBufferUnicodeStringMarshaler))] out string bufptr);

		/// <summary>
		/// The <c>NetGetDisplayInformationIndex</c> function returns the index of the first display information entry whose name begins with
		/// a specified string or whose name alphabetically follows the string. You can use this function to determine a starting index for
		/// subsequent calls to the <c>NetQueryDisplayInformation</c> function.
		/// </summary>
		/// <param name="ServerName">
		/// Pointer to a constant string that specifies the DNS or NetBIOS name of the remote server on which the function is to execute. If
		/// this parameter is <c>NULL</c>, the local computer is used.
		/// </param>
		/// <param name="Level">
		/// <para>Specifies the level of accounts to query. This parameter can be one of the following values.</para>
		/// <para>
		/// <list type="table">
		/// <listheader>
		/// <term>Value</term>
		/// <term>Meaning</term>
		/// </listheader>
		/// <item>
		/// <term>1</term>
		/// <term>Query all local and global (normal) user accounts.</term>
		/// </item>
		/// <item>
		/// <term>2</term>
		/// <term>Query all workstation and server user accounts.</term>
		/// </item>
		/// <item>
		/// <term>3</term>
		/// <term>Query all global groups.</term>
		/// </item>
		/// </list>
		/// </para>
		/// </param>
		/// <param name="Prefix">Pointer to a string that specifies the prefix for which to search.</param>
		/// <param name="Index">Pointer to a value that receives the index of the requested entry.</param>
		/// <returns>
		/// <para>If the function succeeds, the return value is NERR_Success.</para>
		/// <para>If the function fails, the return value can be one of the following error codes.</para>
		/// <para>
		/// <list type="table">
		/// <listheader>
		/// <term>Return code</term>
		/// <term>Description</term>
		/// </listheader>
		/// <item>
		/// <term>ERROR_ACCESS_DENIED</term>
		/// <term>The user does not have access to the requested information.</term>
		/// </item>
		/// <item>
		/// <term>ERROR_INVALID_LEVEL</term>
		/// <term>The value specified for the Level parameter is invalid.</term>
		/// </item>
		/// <item>
		/// <term>ERROR_NO_MORE_ITEMS</term>
		/// <term>There were no more items on which to operate.</term>
		/// </item>
		/// <item>
		/// <term>NERR_InvalidComputer</term>
		/// <term>The computer name is invalid.</term>
		/// </item>
		/// </list>
		/// </para>
		/// </returns>
		// NET_API_STATUS NetGetDisplayInformationIndex( _In_ LPCWSTR ServerName, _In_ DWORD Level, _In_ LPCWSTR Prefix, _Out_ LPDWORD
		// Index); https://msdn.microsoft.com/en-us/library/windows/desktop/aa370421(v=vs.85).aspx
		[DllImport(Lib.NetApi32, SetLastError = false, ExactSpelling = true, CharSet = CharSet.Unicode)]
		[PInvokeData("Lmaccess.h", MSDNShortId = "aa370421")]
		public static extern Win32Error NetGetDisplayInformationIndex([In, Optional] string ServerName, uint Level, [In] string Prefix, out uint Index);

		/// <summary>
		/// The <c>NetGroupAdd</c> function creates a global group in the security database, which is the security accounts manager (SAM)
		/// database or, in the case of domain controllers, the Active Directory.
		/// </summary>
		/// <param name="servername">
		/// Pointer to a constant string that specifies the DNS or NetBIOS name of the remote server on which the function is to execute. If
		/// this parameter is <c>NULL</c>, the local computer is used.
		/// </param>
		/// <param name="level">
		/// <para>Specifies the information level of the data. This parameter can be one of the following values.</para>
		/// <list type="table">
		/// <listheader>
		/// <term>Value</term>
		/// <term>Meaning</term>
		/// </listheader>
		/// <item>
		/// <term>0</term>
		/// <term>Specifies a global group name. The buf parameter contains a pointer to a GROUP_INFO_0 structure.</term>
		/// </item>
		/// <item>
		/// <term>1</term>
		/// <term>Specifies a global group name and a comment. The buf parameter contains a pointer to a GROUP_INFO_1 structure.</term>
		/// </item>
		/// <item>
		/// <term>2</term>
		/// <term>
		/// Specifies detailed information about the global group. The buf parameter contains a pointer to a GROUP_INFO_2 structure. Note
		/// that on Windows XP and later, it is recommended that you use GROUP_INFO_3 instead.
		/// </term>
		/// </item>
		/// <item>
		/// <term>3</term>
		/// <term>
		/// Specifies detailed information about the global group. The buf parameter contains a pointer to a GROUP_INFO_3 structure. Windows
		/// 2000: This level is not supported.
		/// </term>
		/// </item>
		/// </list>
		/// </param>
		/// <param name="buf">
		/// Pointer to a buffer that contains the data. The format of this data depends on the value of the level parameter. For more
		/// information, see Network Management Function Buffers.
		/// </param>
		/// <param name="parm_err">
		/// Pointer to a value that receives the index of the first member of the global group information structure in error when
		/// ERROR_INVALID_PARAMETER is returned. If this parameter is <c>NULL</c>, the index is not returned on error. For more information,
		/// see the NetGroupSetInfo function.
		/// </param>
		/// <returns>
		/// <para>If the function succeeds, the return value is NERR_Success.</para>
		/// <para>If the function fails, the return value can be one of the following error codes.</para>
		/// <list type="table">
		/// <listheader>
		/// <term>Return code</term>
		/// <term>Description</term>
		/// </listheader>
		/// <item>
		/// <term>ERROR_ACCESS_DENIED</term>
		/// <term>The user does not have access to the requested information.</term>
		/// </item>
		/// <item>
		/// <term>NERR_InvalidComputer</term>
		/// <term>The computer name is invalid.</term>
		/// </item>
		/// <item>
		/// <term>NERR_GroupExists</term>
		/// <term>The global group already exists.</term>
		/// </item>
		/// <item>
		/// <term>NERR_NotPrimary</term>
		/// <term>The operation is allowed only on the primary domain controller of the domain.</term>
		/// </item>
		/// <item>
		/// <term>ERROR_INVALID_LEVEL</term>
		/// <term>The value specified for the level parameter is invalid.</term>
		/// </item>
		/// <item>
		/// <term>NERR_SpeGroupOp</term>
		/// <term>
		/// The operation is not allowed on certain special groups. These groups include user groups, admin groups, local groups, and guest groups.
		/// </term>
		/// </item>
		/// </list>
		/// </returns>
		/// <remarks>
		/// <para>
		/// If you are programming for Active Directory, you may be able to call certain Active Directory Service Interface (ADSI) methods to
		/// achieve the same functionality you can achieve by calling the network management group functions. For more information, see IADsGroup.
		/// </para>
		/// <para>
		/// If you call this function on a domain controller that is running Active Directory, access is allowed or denied based on the
		/// access control list (ACL) for the securable object. The default ACL permits only Domain Admins and Account Operators to call this
		/// function. On a member server or workstation, only Administrators and Power Users can call this function. For more information,
		/// see Security Requirements for the Network Management Functions. For more information on ACLs, ACEs, and access tokens, see Access
		/// Control Model.
		/// </para>
		/// <para>
		/// The security descriptor of the user container is used to perform the access check for this function. The caller must be able to
		/// create child objects of the group class. Typically, callers must also have write access to the entire object for calls to this
		/// function to succeed.
		/// </para>
		/// <para>
		/// User account names are limited to 20 characters and group names are limited to 256 characters. In addition, account names cannot
		/// be terminated by a period and they cannot include commas or any of the following printable characters: ", /, , [, ], :, |, &lt;,
		/// &gt;, +, =, ;, ?, *. Names also cannot include characters in the range 1-31, which are non-printable.
		/// </para>
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows/desktop/api/lmaccess/nf-lmaccess-netgroupadd NET_API_STATUS NET_API_FUNCTION NetGroupAdd(
		// LPCWSTR servername, DWORD level, LPBYTE buf, LPDWORD parm_err );
		[DllImport(Lib.NetApi32, SetLastError = false, ExactSpelling = true, CharSet = CharSet.Unicode)]
		[PInvokeData("lmaccess.h", MSDNShortId = "fbf90758-79fd-4959-b6d0-ad3872e77242")]
		public static extern Win32Error NetGroupAdd([In, Optional] string servername, uint level, IntPtr buf, out uint parm_err);

		/// <summary>
		/// The <c>NetGroupAddUser</c> function gives an existing user account membership in an existing global group in the security
		/// database, which is the security accounts manager (SAM) database or, in the case of domain controllers, the Active Directory.
		/// </summary>
		/// <param name="servername">
		/// Pointer to a constant string that specifies the DNS or NetBIOS name of the remote server on which the function is to execute. If
		/// this parameter is <c>NULL</c>, the local computer is used.
		/// </param>
		/// <param name="GroupName">
		/// Pointer to a constant string that specifies the name of the global group in which the user is to be given membership. For more
		/// information, see the following Remarks section.
		/// </param>
		/// <param name="username">
		/// Pointer to a constant string that specifies the name of the user to be given membership in the global group. For more
		/// information, see the following Remarks section.
		/// </param>
		/// <returns>
		/// <para>If the function succeeds, the return value is NERR_Success.</para>
		/// <para>If the function fails, the return value can be one of the following error codes.</para>
		/// <list type="table">
		/// <listheader>
		/// <term>Return code</term>
		/// <term>Description</term>
		/// </listheader>
		/// <item>
		/// <term>ERROR_ACCESS_DENIED</term>
		/// <term>The user does not have access to the requested information.</term>
		/// </item>
		/// <item>
		/// <term>NERR_InvalidComputer</term>
		/// <term>The computer name is invalid.</term>
		/// </item>
		/// <item>
		/// <term>NERR_NotPrimary</term>
		/// <term>The operation is allowed only on the primary domain controller of the domain.</term>
		/// </item>
		/// <item>
		/// <term>NERR_SpeGroupOp</term>
		/// <term>
		/// The operation is not allowed on certain special groups. These groups include user groups, admin groups, local groups, and guest groups.
		/// </term>
		/// </item>
		/// <item>
		/// <term>NERR_UserNotFound</term>
		/// <term>The user name could not be found.</term>
		/// </item>
		/// <item>
		/// <term>NERR_GroupNotFound</term>
		/// <term>The global group name could not be found.</term>
		/// </item>
		/// </list>
		/// </returns>
		/// <remarks>
		/// <para>
		/// If you call this function on a domain controller that is running Active Directory, access is allowed or denied based on the
		/// access control list (ACL) for the securable object. The default ACL permits only Domain Admins and Account Operators to call this
		/// function. On a member server or workstation, only Administrators and Power Users can call this function. For more information,
		/// see Security Requirements for the Network Management Functions. For more information on ACLs, ACEs, and access tokens, see Access
		/// Control Model.
		/// </para>
		/// <para>The security descriptor of the Group object is used to perform the access check for this function.</para>
		/// <para>
		/// User account names are limited to 20 characters and group names are limited to 256 characters. In addition, account names cannot
		/// be terminated by a period and they cannot include commas or any of the following printable characters: ", /, , [, ], :, |, &lt;,
		/// &gt;, +, =, ;, ?, *. Names also cannot include characters in the range 1-31, which are non-printable.
		/// </para>
		/// <para>
		/// If you are programming for Active Directory, you may be able to call certain Active Directory Service Interface (ADSI) methods to
		/// achieve the same functionality you can achieve by calling the network management group functions. For more information, see IADsGroup.
		/// </para>
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows/desktop/api/lmaccess/nf-lmaccess-netgroupadduser NET_API_STATUS NET_API_FUNCTION
		// NetGroupAddUser( LPCWSTR servername, LPCWSTR GroupName, LPCWSTR username );
		[DllImport(Lib.NetApi32, SetLastError = false, ExactSpelling = true, CharSet = CharSet.Unicode)]
		[PInvokeData("lmaccess.h", MSDNShortId = "a2eefde8-29e3-4fa1-87db-c7f6d24b699d")]
		public static extern Win32Error NetGroupAddUser([Optional] string servername, string GroupName, string username);

		/// <summary>
		/// The <c>NetGroupDel</c> function deletes a global group from the security database, which is the security accounts manager (SAM)
		/// database or, in the case of domain controllers, the Active Directory.
		/// </summary>
		/// <param name="servername">
		/// Pointer to a constant string that specifies the DNS or NetBIOS name of the remote server on which the function is to execute. If
		/// this parameter is <c>NULL</c>, the local computer is used.
		/// </param>
		/// <param name="groupname">
		/// Pointer to a constant string that specifies the name of the global group account to delete. For more information, see the
		/// following Remarks section.
		/// </param>
		/// <returns>
		/// <para>If the function succeeds, the return value is NERR_Success.</para>
		/// <para>If the function fails, the return value can be one of the following error codes.</para>
		/// <list type="table">
		/// <listheader>
		/// <term>Return code</term>
		/// <term>Description</term>
		/// </listheader>
		/// <item>
		/// <term>ERROR_ACCESS_DENIED</term>
		/// <term>The user does not have access to the requested information.</term>
		/// </item>
		/// <item>
		/// <term>NERR_InvalidComputer</term>
		/// <term>The computer name is invalid.</term>
		/// </item>
		/// <item>
		/// <term>NERR_NotPrimary</term>
		/// <term>The operation is allowed only on the primary domain controller of the domain.</term>
		/// </item>
		/// <item>
		/// <term>NERR_SpeGroupOp</term>
		/// <term>
		/// The operation is not allowed on certain special groups. These groups include user groups, admin groups, local groups, and guest groups.
		/// </term>
		/// </item>
		/// <item>
		/// <term>NERR_GroupNotFound</term>
		/// <term>The global group name could not be found.</term>
		/// </item>
		/// </list>
		/// </returns>
		/// <remarks>
		/// <para>
		/// If you call this function on a domain controller that is running Active Directory, access is allowed or denied based on the
		/// access control list (ACL) for the securable object. The default ACL permits only Domain Admins and Account Operators to call this
		/// function. On a member server or workstation, only Administrators and Power Users can call this function. For more information,
		/// see Security Requirements for the Network Management Functions. For more information on ACLs, ACEs, and access tokens, see Access
		/// Control Model.
		/// </para>
		/// <para>The security descriptor of the Group object is used to perform the access check for this function.</para>
		/// <para>
		/// User account names are limited to 20 characters and group names are limited to 256 characters. In addition, account names cannot
		/// be terminated by a period and they cannot include commas or any of the following printable characters: ", /, , [, ], :, |, &lt;,
		/// &gt;, +, =, ;, ?, *. Names also cannot include characters in the range 1-31, which are non-printable.
		/// </para>
		/// <para>
		/// If you are programming for Active Directory, you may be able to call certain Active Directory Service Interface (ADSI) methods to
		/// achieve the same functionality you can achieve by calling the network management group functions. For more information, see IADsGroup.
		/// </para>
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows/desktop/api/lmaccess/nf-lmaccess-netgroupdel NET_API_STATUS NET_API_FUNCTION NetGroupDel(
		// LPCWSTR servername, LPCWSTR groupname );
		[DllImport(Lib.NetApi32, SetLastError = false, ExactSpelling = true, CharSet = CharSet.Unicode)]
		[PInvokeData("lmaccess.h", MSDNShortId = "e637d1af-c900-4c91-a771-1428f9cfac8b")]
		public static extern Win32Error NetGroupDel([Optional] string servername, string groupname);

		/// <summary>
		/// The <c>NetGroupDelUser</c> function removes a user from a particular global group in the security database, which is the security
		/// accounts manager (SAM) database or, in the case of domain controllers, the Active Directory.
		/// </summary>
		/// <param name="servername">
		/// Pointer to a constant string that specifies the DNS or NetBIOS name of the remote server on which the function is to execute. If
		/// this parameter is <c>NULL</c>, the local computer is used.
		/// </param>
		/// <param name="GroupName">
		/// Pointer to a constant string that specifies the name of the global group from which the user's membership should be removed. For
		/// more information, see the following Remarks section.
		/// </param>
		/// <param name="Username">
		/// Pointer to a constant string that specifies the name of the user to remove from the global group. For more information, see the
		/// following Remarks section.
		/// </param>
		/// <returns>
		/// <para>If the function succeeds, the return value is NERR_Success.</para>
		/// <para>If the function fails, the return value can be one of the following error codes.</para>
		/// <list type="table">
		/// <listheader>
		/// <term>Return code</term>
		/// <term>Description</term>
		/// </listheader>
		/// <item>
		/// <term>ERROR_ACCESS_DENIED</term>
		/// <term>The user does not have access to the requested information.</term>
		/// </item>
		/// <item>
		/// <term>NERR_InvalidComputer</term>
		/// <term>The computer name is invalid.</term>
		/// </item>
		/// <item>
		/// <term>NERR_NotPrimary</term>
		/// <term>The operation is allowed only on the primary domain controller of the domain.</term>
		/// </item>
		/// <item>
		/// <term>NERR_SpeGroupOp</term>
		/// <term>
		/// The operation is not allowed on certain special groups. These groups include user groups, admin groups, local groups, and guest groups.
		/// </term>
		/// </item>
		/// <item>
		/// <term>NERR_UserNotFound</term>
		/// <term>The user name could not be found.</term>
		/// </item>
		/// <item>
		/// <term>NERR_GroupNotFound</term>
		/// <term>The global group name could not be found.</term>
		/// </item>
		/// <item>
		/// <term>NERR_UserNotInGroup</term>
		/// <term>The user does not belong to this global group.</term>
		/// </item>
		/// </list>
		/// </returns>
		/// <remarks>
		/// <para>
		/// If you call this function on a domain controller that is running Active Directory, access is allowed or denied based on the
		/// access control list (ACL) for the securable object. The default ACL permits only Domain Admins and Account Operators to call this
		/// function. On a member server or workstation, only Administrators and Power Users can call this function. For more information,
		/// see Security Requirements for the Network Management Functions. For more information on ACLs, ACEs, and access tokens, see Access
		/// Control Model.
		/// </para>
		/// <para>The security descriptor of the Group object is used to perform the access check for this function.</para>
		/// <para>
		/// User account names are limited to 20 characters and group names are limited to 256 characters. In addition, account names cannot
		/// be terminated by a period and they cannot include commas or any of the following printable characters: ", /, , [, ], :, |, &lt;,
		/// &gt;, +, =, ;, ?, *. Names also cannot include characters in the range 1-31, which are non-printable.
		/// </para>
		/// <para>
		/// If you are programming for Active Directory, you may be able to call certain Active Directory Service Interface (ADSI) methods to
		/// achieve the same functionality you can achieve by calling the network management group functions. For more information, see IADsGroup.
		/// </para>
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows/desktop/api/lmaccess/nf-lmaccess-netgroupdeluser NET_API_STATUS NET_API_FUNCTION
		// NetGroupDelUser( LPCWSTR servername, LPCWSTR GroupName, LPCWSTR Username );
		[DllImport(Lib.NetApi32, SetLastError = false, ExactSpelling = true, CharSet = CharSet.Unicode)]
		[PInvokeData("lmaccess.h", MSDNShortId = "ab8ce12a-60c0-4d79-8894-4537c6568e15")]
		public static extern Win32Error NetGroupDelUser([Optional] string servername, string GroupName, string Username);

		/// <summary>
		/// <para>
		/// The <c>NetGroupEnum</c> function retrieves information about each global group in the security database, which is the security
		/// accounts manager (SAM) database or, in the case of domain controllers, the Active Directory.
		/// </para>
		/// <para>
		/// The NetQueryDisplayInformation function provides an efficient mechanism for enumerating global groups. When possible, it is
		/// recommended that you use <c>NetQueryDisplayInformation</c> instead of the <c>NetGroupEnum</c> function.
		/// </para>
		/// </summary>
		/// <param name="servername">
		/// Pointer to a constant string that specifies the DNS or NetBIOS name of the remote server on which the function is to execute. If
		/// this parameter is <c>NULL</c>, the local computer is used.
		/// </param>
		/// <param name="level">
		/// <para>Specifies the information level of the data. This parameter can be one of the following values.</para>
		/// <list type="table">
		/// <listheader>
		/// <term>Value</term>
		/// <term>Meaning</term>
		/// </listheader>
		/// <item>
		/// <term>0</term>
		/// <term>Return the global group name. The bufptr parameter points to an array of GROUP_INFO_0 structures.</term>
		/// </item>
		/// <item>
		/// <term>1</term>
		/// <term>Return the global group name and a comment. The bufptr parameter points to an array of GROUP_INFO_1 structures.</term>
		/// </item>
		/// <item>
		/// <term>2</term>
		/// <term>
		/// Return detailed information about the global group. The bufptr parameter points to an array of GROUP_INFO_2 structures. Note that
		/// on Windows XP and later, it is recommended that you use GROUP_INFO_3 instead.
		/// </term>
		/// </item>
		/// <item>
		/// <term>3</term>
		/// <term>
		/// Return detailed information about the global group. The bufptr parameter points to an array of GROUP_INFO_3 structures. Windows
		/// 2000: This level is not supported.
		/// </term>
		/// </item>
		/// </list>
		/// </param>
		/// <param name="bufptr">
		/// <para>
		/// Pointer to the buffer to receive the global group information structure. The format of this data depends on the value of the
		/// level parameter.
		/// </para>
		/// <para>
		/// The system allocates the memory for this buffer. You must call the NetApiBufferFree function to deallocate the memory. Note that
		/// you must free the buffer even if the function fails with ERROR_MORE_DATA.
		/// </para>
		/// </param>
		/// <param name="prefmaxlen">
		/// Specifies the preferred maximum length of the returned data, in bytes. If you specify MAX_PREFERRED_LENGTH, the function
		/// allocates the amount of memory required to hold the data. If you specify another value in this parameter, it can restrict the
		/// number of bytes that the function returns. If the buffer size is insufficient to hold all entries, the function returns
		/// ERROR_MORE_DATA. For more information, see Network Management Function Buffers and Network Management Function Buffer Lengths.
		/// </param>
		/// <param name="entriesread">Pointer to a value that receives the count of elements actually enumerated.</param>
		/// <param name="totalentries">
		/// Pointer to a value that receives the total number of entries that could have been enumerated from the current resume position.
		/// The total number of entries is only a hint. For more information about determining the exact number of entries, see the following
		/// Remarks section.
		/// </param>
		/// <param name="resume_handle">
		/// Pointer to a variable that contains a resume handle that is used to continue the global group enumeration. The handle should be
		/// zero on the first call and left unchanged for subsequent calls. If this parameter is <c>NULL</c>, no resume handle is stored.
		/// </param>
		/// <returns>
		/// <para>If the function succeeds, the return value is NERR_Success.</para>
		/// <para>If the function fails, the return value can be one of the following error codes.</para>
		/// <list type="table">
		/// <listheader>
		/// <term>Return code</term>
		/// <term>Description</term>
		/// </listheader>
		/// <item>
		/// <term>ERROR_ACCESS_DENIED</term>
		/// <term>The user does not have access to the requested information.</term>
		/// </item>
		/// <item>
		/// <term>NERR_InvalidComputer</term>
		/// <term>The computer name is invalid.</term>
		/// </item>
		/// <item>
		/// <term>ERROR_MORE_DATA</term>
		/// <term>More entries are available. Specify a large enough buffer to receive all entries.</term>
		/// </item>
		/// </list>
		/// </returns>
		/// <remarks>
		/// <para>
		/// If you are programming for Active Directory, you may be able to call certain Active Directory Service Interface (ADSI) methods to
		/// achieve the same functionality you can achieve by calling the network management group functions. For more information, see IADsGroup.
		/// </para>
		/// <para>
		/// If you call this function on a domain controller that is running Active Directory, access is allowed or denied based on the
		/// access control list (ACL) for the securable object. The default ACL permits all authenticated users and members of the
		/// "Pre-Windows 2000 compatible access" group to view the information. If you call this function on a member server or workstation,
		/// all authenticated users can view the information. For information about anonymous access and restricting anonymous access on
		/// these platforms, see Security Requirements for the Network Management Functions. For more information on ACLs, ACEs, and access
		/// tokens, see Access Control Model.
		/// </para>
		/// <para>
		/// The function only returns information to which the caller has Read access. The caller must have List Contents access to the
		/// Domain object, and Enumerate Entire SAM Domain access on the SAM Server object located in the System container.
		/// </para>
		/// <para>
		/// To determine the exact total number of groups, you must enumerate the entire tree, which can be a costly operation. To enumerate
		/// the entire tree, use the resume_handle parameter to continue the enumeration for consecutive calls, and use the entriesread
		/// parameter to accumulate the total number of groups. If your application is communicating with a domain controller, you should
		/// consider using the ADSI LDAP Provider to retrieve this type of data more efficiently. The ADSI LDAP Provider implements a set of
		/// ADSI objects that support various ADSI interfaces. For more information, see ADSI Service Providers.
		/// </para>
		/// <para>
		/// User account names are limited to 20 characters and group names are limited to 256 characters. In addition, account names cannot
		/// be terminated by a period and they cannot include commas or any of the following printable characters: ", /, , [, ], :, |, &lt;,
		/// &gt;, +, =, ;, ?, *. Names also cannot include characters in the range 1-31, which are non-printable.
		/// </para>
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows/desktop/api/lmaccess/nf-lmaccess-netgroupenum NET_API_STATUS NET_API_FUNCTION
		// NetGroupEnum( LPCWSTR servername, DWORD level, LPBYTE *bufptr, DWORD prefmaxlen, LPDWORD entriesread, LPDWORD totalentries,
		// PDWORD_PTR resume_handle );
		[DllImport(Lib.NetApi32, SetLastError = false, ExactSpelling = true, CharSet = CharSet.Unicode)]
		[PInvokeData("lmaccess.h", MSDNShortId = "3f8fabce-94cb-41f5-9af1-04585ac3f16e")]
		public static extern Win32Error NetGroupEnum([Optional] string servername, uint level, out SafeNetApiBuffer bufptr, uint prefmaxlen, out uint entriesread, out uint totalentries, ref IntPtr resume_handle);

		/// <summary>
		/// The <c>NetGroupGetInfo</c> function retrieves information about a particular global group in the security database, which is the
		/// security accounts manager (SAM) database or, in the case of domain controllers, the Active Directory.
		/// </summary>
		/// <param name="servername">
		/// Pointer to a constant string that specifies the DNS or NetBIOS name of the remote server on which the function is to execute. If
		/// this parameter is <c>NULL</c>, the local computer is used.
		/// </param>
		/// <param name="groupname">
		/// Pointer to a constant string that specifies the name of the global group for which to retrieve information. For more information,
		/// see the following Remarks section.
		/// </param>
		/// <param name="level">
		/// <para>Specifies the information level of the data. This parameter can be one of the following values.</para>
		/// <list type="table">
		/// <listheader>
		/// <term>Value</term>
		/// <term>Meaning</term>
		/// </listheader>
		/// <item>
		/// <term>0</term>
		/// <term>Return the global group name. The bufptr parameter points to a GROUP_INFO_0 structure.</term>
		/// </item>
		/// <item>
		/// <term>1</term>
		/// <term>Return the global group name and a comment. The bufptr parameter points to a GROUP_INFO_1 structure.</term>
		/// </item>
		/// <item>
		/// <term>2</term>
		/// <term>
		/// Return detailed information about the global group. The bufptr parameter points to a GROUP_INFO_2 structure. Note that on Windows
		/// XP and later, it is recommended that you use GROUP_INFO_3 instead.
		/// </term>
		/// </item>
		/// <item>
		/// <term>3</term>
		/// <term>
		/// Return detailed information about the global group. The bufptr parameter points to a GROUP_INFO_3 structure. Windows 2000: This
		/// level is not supported.
		/// </term>
		/// </item>
		/// </list>
		/// </param>
		/// <param name="bufptr">
		/// Pointer to the address of the buffer that receives the global group information structure. The format of this data depends on the
		/// value of the level parameter. The system allocates the memory for this buffer. You must call the NetApiBufferFree function to
		/// deallocate the memory. For more information, see Network Management Function Buffers and Network Management Function Buffer Lengths.
		/// </param>
		/// <returns>
		/// <para>If the function succeeds, the return value is NERR_Success.</para>
		/// <para>If the function fails, the return value can be one of the following error codes.</para>
		/// <list type="table">
		/// <listheader>
		/// <term>Return code</term>
		/// <term>Description</term>
		/// </listheader>
		/// <item>
		/// <term>ERROR_ACCESS_DENIED</term>
		/// <term>The user does not have access to the requested information.</term>
		/// </item>
		/// <item>
		/// <term>NERR_InvalidComputer</term>
		/// <term>The computer name is invalid.</term>
		/// </item>
		/// <item>
		/// <term>NERR_GroupNotFound</term>
		/// <term>The global group name could not be found.</term>
		/// </item>
		/// </list>
		/// </returns>
		/// <remarks>
		/// <para>
		/// If you are programming for Active Directory, you may be able to call certain Active Directory Service Interface (ADSI) methods to
		/// achieve the same functionality you can achieve by calling the network management group functions. For more information, see IADsGroup.
		/// </para>
		/// <para>
		/// If you call this function on a domain controller that is running Active Directory, access is allowed or denied based on the
		/// access control list (ACL) for the securable object. The default ACL permits all authenticated users and members of the
		/// "Pre-Windows 2000 compatible access" group to view the information. If you call this function on a member server or workstation,
		/// all authenticated users can view the information. For information about anonymous access and restricting anonymous access on
		/// these platforms, see Security Requirements for the Network Management Functions. For more information on ACLs, ACEs, and access
		/// tokens, see Access Control Model.
		/// </para>
		/// <para>The security descriptor of the Group object is used to perform the access check for this function.</para>
		/// <para>
		/// User account names are limited to 20 characters and group names are limited to 256 characters. In addition, account names cannot
		/// be terminated by a period and they cannot include commas or any of the following printable characters: ", /, , [, ], :, |, &lt;,
		/// &gt;, +, =, ;, ?, *. Names also cannot include characters in the range 1-31, which are non-printable.
		/// </para>
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows/desktop/api/lmaccess/nf-lmaccess-netgroupgetinfo NET_API_STATUS NET_API_FUNCTION
		// NetGroupGetInfo( LPCWSTR servername, LPCWSTR groupname, DWORD level, LPBYTE *bufptr );
		[DllImport(Lib.NetApi32, SetLastError = false, ExactSpelling = true, CharSet = CharSet.Unicode)]
		[PInvokeData("lmaccess.h", MSDNShortId = "f9957c15-9a49-4b53-ae31-efd6a03417a6")]
		public static extern Win32Error NetGroupGetInfo([Optional] string servername, string groupname, uint level, out SafeNetApiBuffer bufptr);

		/// <summary>
		/// The <c>NetGroupGetUsers</c> function retrieves a list of the members in a particular global group in the security database, which
		/// is the security accounts manager (SAM) database or, in the case of domain controllers, the Active Directory.
		/// </summary>
		/// <param name="servername">
		/// A pointer to a constant string that specifies the DNS or NetBIOS name of the remote server on which the function is to execute.
		/// If this parameter is <c>NULL</c>, the local computer is used.
		/// </param>
		/// <param name="groupname">
		/// A pointer to a constant string that specifies the name of the global group whose members are to be listed. For more information,
		/// see the following Remarks section.
		/// </param>
		/// <param name="level">
		/// <para>The information level of the data requested. This parameter can be one of the following values.</para>
		/// <list type="table">
		/// <listheader>
		/// <term>Value</term>
		/// <term>Meaning</term>
		/// </listheader>
		/// <item>
		/// <term>0</term>
		/// <term>Return the global group's member names. The bufptr parameter points to an array of GROUP_USERS_INFO_0 structures.</term>
		/// </item>
		/// <item>
		/// <term>1</term>
		/// <term>Return the global group's member names and attributes. The bufptr parameter points to an array of GROUP_USERS_INFO_1 structures.</term>
		/// </item>
		/// </list>
		/// </param>
		/// <param name="bufptr">
		/// A pointer to the address of the buffer that receives the information structure. The system allocates the memory for this buffer.
		/// You must call the NetApiBufferFree function to deallocate the memory. Note that you must free the buffer even if the function
		/// fails with ERROR_MORE_DATA.
		/// </param>
		/// <param name="prefmaxlen">
		/// The preferred maximum length of the returned data, in bytes. If you specify MAX_PREFERRED_LENGTH, the function allocates the
		/// amount of memory required to hold the data. If you specify another value in this parameter, it can restrict the number of bytes
		/// that the function returns. If the buffer size is insufficient to hold all entries, the function returns ERROR_MORE_DATA. For more
		/// information, see Network Management Function Buffers and Network Management Function Buffer Lengths.
		/// </param>
		/// <param name="entriesread">A pointer to a value that receives the count of elements actually enumerated.</param>
		/// <param name="totalentries">
		/// A pointer to a value that receives the total number of entries that could have been enumerated from the current resume position.
		/// </param>
		/// <param name="ResumeHandle">
		/// A pointer to a variable that contains a resume handle that is used to continue an existing user enumeration. The handle should be
		/// zero on the first call and left unchanged for subsequent calls. If ResumeHandle parameter is <c>NULL</c>, no resume handle is stored.
		/// </param>
		/// <returns>
		/// <para>If the function succeeds, the return value is NERR_Success.</para>
		/// <para>If the function fails, the return value can be one of the following error codes.</para>
		/// <list type="table">
		/// <listheader>
		/// <term>Return code</term>
		/// <term>Description</term>
		/// </listheader>
		/// <item>
		/// <term>ERROR_ACCESS_DENIED</term>
		/// <term>The user does not have access to the requested information.</term>
		/// </item>
		/// <item>
		/// <term>ERROR_INVALID_LEVEL</term>
		/// <term>
		/// The system call level is not correct. This error is returned if the level parameter was specified as a value other than 0 or 1.
		/// </term>
		/// </item>
		/// <item>
		/// <term>ERROR_MORE_DATA</term>
		/// <term>More entries are available. Specify a large enough buffer to receive all entries.</term>
		/// </item>
		/// <item>
		/// <term>ERROR_NOT_ENOUGH_MEMORY</term>
		/// <term>Insufficient memory was available to complete the operation.</term>
		/// </item>
		/// <item>
		/// <term>NERR_InvalidComputer</term>
		/// <term>The computer name is invalid.</term>
		/// </item>
		/// <item>
		/// <term>NERR_GroupNotFound</term>
		/// <term>The global group name in the structure pointed to by bufptr parameter could not be found.</term>
		/// </item>
		/// <item>
		/// <term>NERR_InternalError</term>
		/// <term>An internal error occurred.</term>
		/// </item>
		/// </list>
		/// </returns>
		/// <remarks>
		/// <para>
		/// If you call this function on a domain controller that is running Active Directory, access is allowed or denied based on the
		/// access control list (ACL) for the securable object. The default ACL permits all authenticated users and members of the
		/// "Pre-Windows 2000 compatible access" group to view the information. If you call this function on a member server or workstation,
		/// all authenticated users can view the information. For information about anonymous access and restricting anonymous access on
		/// these platforms, see Security Requirements for the Network Management Functions. For more information on ACLs, ACEs, and access
		/// tokens, see Access Control Model.
		/// </para>
		/// <para>The security descriptor of the Group object is used to perform the access check for this function.</para>
		/// <para>
		/// To grant one user membership in an existing global group, you can call the NetGroupAddUser function. To remove a user from a
		/// global group, call the NetGroupDelUser function. For information about replacing the membership of a global group, see NetGroupSetUsers.
		/// </para>
		/// <para>
		/// User account names are limited to 20 characters and group names are limited to 256 characters. In addition, account names cannot
		/// be terminated by a period and they cannot include commas or any of the following printable characters: ", /, , [, ], :, |, &lt;,
		/// &gt;, +, =, ;, ?, *. Names also cannot include characters in the range 1-31, which are non-printable.
		/// </para>
		/// <para>
		/// If you are programming for Active Directory, you may be able to call certain Active Directory Service Interface (ADSI) methods to
		/// achieve the same functionality you can achieve by calling the network management group functions. For more information, see IADsGroup.
		/// </para>
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows/desktop/api/lmaccess/nf-lmaccess-netgroupgetusers NET_API_STATUS NET_API_FUNCTION
		// NetGroupGetUsers( LPCWSTR servername, LPCWSTR groupname, DWORD level, LPBYTE *bufptr, DWORD prefmaxlen, LPDWORD entriesread,
		// LPDWORD totalentries, PDWORD_PTR ResumeHandle );
		[DllImport(Lib.NetApi32, SetLastError = false, ExactSpelling = true, CharSet = CharSet.Unicode)]
		[PInvokeData("lmaccess.h", MSDNShortId = "a9bcb806-f44c-4db2-9644-06687b31405d")]
		public static extern Win32Error NetGroupGetUsers([Optional] string servername, string groupname, uint level, out SafeNetApiBuffer bufptr, uint prefmaxlen, out uint entriesread, out uint totalentries, ref IntPtr ResumeHandle);

		/// <summary>
		/// The <c>NetGroupSetInfo</c> function sets the parameters of a global group in the security database, which is the security
		/// accounts manager (SAM) database or, in the case of domain controllers, the Active Directory.
		/// </summary>
		/// <param name="servername">
		/// Pointer to a constant string that specifies the DNS or NetBIOS name of the remote server on which the function is to execute. If
		/// this parameter is <c>NULL</c>, the local computer is used.
		/// </param>
		/// <param name="groupname">
		/// Pointer to a constant string that specifies the name of the global group for which to set information. For more information, see
		/// the following Remarks section.
		/// </param>
		/// <param name="level">
		/// <para>Specifies the information level of the data. This parameter can be one of the following values.</para>
		/// <list type="table">
		/// <listheader>
		/// <term>Value</term>
		/// <term>Meaning</term>
		/// </listheader>
		/// <item>
		/// <term>0</term>
		/// <term>Specifies a global group name. The buf parameter points to a GROUP_INFO_0 structure.</term>
		/// </item>
		/// <item>
		/// <term>1</term>
		/// <term>Specifies a global group name and a comment. The buf parameter points to a GROUP_INFO_1 structure.</term>
		/// </item>
		/// <item>
		/// <term>2</term>
		/// <term>
		/// Specifies detailed information about the global group. The buf parameter points to a GROUP_INFO_2 structure. Note that on Windows
		/// XP and later, it is recommended that you use GROUP_INFO_3 instead.
		/// </term>
		/// </item>
		/// <item>
		/// <term>3</term>
		/// <term>
		/// Specifies detailed information about the global group. The buf parameter points to a GROUP_INFO_3 structure. Windows 2000: This
		/// level is not supported.
		/// </term>
		/// </item>
		/// <item>
		/// <term>1002</term>
		/// <term>Specifies a comment only about the global group. The buf parameter points to a GROUP_INFO_1002 structure.</term>
		/// </item>
		/// <item>
		/// <term>1005</term>
		/// <term>Specifies global group attributes. The buf parameter points to a GROUP_INFO_1005 structure.</term>
		/// </item>
		/// </list>
		/// <para>For more information, see the following Remarks section.</para>
		/// </param>
		/// <param name="buf">
		/// Pointer to a buffer that contains the data. The format of this data depends on the value of the level parameter. For more
		/// information, see Network Management Function Buffers.
		/// </param>
		/// <param name="parm_err">
		/// Pointer to a value that receives the index of the first member of the group information structure in error following an
		/// ERROR_INVALID_PARAMETER error code. If this parameter is <c>NULL</c>, the index is not returned on error. For more information,
		/// see the following Remarks section.
		/// </param>
		/// <returns>
		/// <para>If the function succeeds, the return value is NERR_Success.</para>
		/// <para>If the function fails, the return value can be one of the following error codes.</para>
		/// <list type="table">
		/// <listheader>
		/// <term>Return code</term>
		/// <term>Description</term>
		/// </listheader>
		/// <item>
		/// <term>ERROR_ACCESS_DENIED</term>
		/// <term>The user does not have access to the requested information.</term>
		/// </item>
		/// <item>
		/// <term>ERROR_INVALID_PARAMETER</term>
		/// <term>One of the function parameters is invalid. For more information, see the following Remarks section.</term>
		/// </item>
		/// <item>
		/// <term>NERR_InvalidComputer</term>
		/// <term>The computer name is invalid.</term>
		/// </item>
		/// <item>
		/// <term>NERR_NotPrimary</term>
		/// <term>The operation is allowed only on the primary domain controller of the domain.</term>
		/// </item>
		/// <item>
		/// <term>NERR_GroupNotFound</term>
		/// <term>The global group name could not be found.</term>
		/// </item>
		/// <item>
		/// <term>NERR_SpeGroupOp</term>
		/// <term>
		/// The operation is not allowed on certain special groups. These groups include user groups, admin groups, local groups, and guest groups.
		/// </term>
		/// </item>
		/// </list>
		/// </returns>
		/// <remarks>
		/// <para>
		/// If you are programming for Active Directory, you may be able to call certain Active Directory Service Interface (ADSI) methods to
		/// achieve the same functionality you can achieve by calling the network management group functions. For more information, see IADsGroup.
		/// </para>
		/// <para>
		/// If you call this function on a domain controller that is running Active Directory, access is allowed or denied based on the
		/// access control list (ACL) for the securable object. The default ACL permits only Domain Admins and Account Operators to call this
		/// function. On a member server or workstation, only Administrators and Power Users can call this function. For more information,
		/// see Security Requirements for the Network Management Functions. For more information on ACLs, ACEs, and access tokens, see Access
		/// Control Model.
		/// </para>
		/// <para>
		/// The security descriptor of the Group object is used to perform the access check for this function. Typically, callers must have
		/// write access to the entire object for calls to this function to succeed.
		/// </para>
		/// <para>
		/// The correct way to set the new name of a global group is to call the <c>NetGroupSetInfo</c> function, using a GROUP_INFO_0
		/// structure. Specify the new value in the <c>grpi0_name</c> member. If you use a GROUP_INFO_1 structure and specify the value in
		/// the <c>grpi1_name</c> member, the new name value is ignored.
		/// </para>
		/// <para>
		/// If the <c>NetGroupSetInfo</c> function returns ERROR_INVALID_PARAMETER, you can use the parm_err parameter to indicate the first
		/// member of the group information structure that is invalid. (A group information structure begins with GROUP_INFO_ and its format
		/// is specified by the level parameter.) The following table lists the values that can be returned in the parm_err parameter and the
		/// corresponding structure member that is in error. (The prefix grpi*_ indicates that the member can begin with multiple prefixes,
		/// for example, grpi1_ or grpi2_.)
		/// </para>
		/// <list type="table">
		/// <listheader>
		/// <term>Value</term>
		/// <term>Member</term>
		/// </listheader>
		/// <item>
		/// <term>GROUP_NAME_PARMNUM</term>
		/// <term>grpi*_name</term>
		/// </item>
		/// <item>
		/// <term>GROUP_COMMENT_PARMNUM</term>
		/// <term>grpi*_comment</term>
		/// </item>
		/// <item>
		/// <term>GROUP_ATTRIBUTES_PARMNUM</term>
		/// <term>grpi*_attributes</term>
		/// </item>
		/// </list>
		/// <para>
		/// User account names are limited to 20 characters and group names are limited to 256 characters. In addition, account names cannot
		/// be terminated by a period and they cannot include commas or any of the following printable characters: ", /, , [, ], :, |, &lt;,
		/// &gt;, +, =, ;, ?, *. Names also cannot include characters in the range 1-31, which are non-printable.
		/// </para>
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows/desktop/api/lmaccess/nf-lmaccess-netgroupsetinfo NET_API_STATUS NET_API_FUNCTION
		// NetGroupSetInfo( LPCWSTR servername, LPCWSTR groupname, DWORD level, LPBYTE buf, LPDWORD parm_err );
		[DllImport(Lib.NetApi32, SetLastError = false, ExactSpelling = true, CharSet = CharSet.Unicode)]
		[PInvokeData("lmaccess.h", MSDNShortId = "8c235f9a-095e-4108-9b93-008ffe9bc776")]
		public static extern Win32Error NetGroupSetInfo([Optional] string servername, string groupname, uint level, IntPtr buf, out uint parm_err);

		/// <summary>
		/// The <c>NetGroupSetUsers</c> function sets the membership for the specified global group. Each user you specify is enrolled as a
		/// member of the global group. Users you do not specify, but who are currently members of the global group, will have their
		/// membership revoked.
		/// </summary>
		/// <param name="servername">
		/// A pointer to a constant string that specifies the DNS or NetBIOS name of the remote server on which the function is to execute.
		/// If this parameter is <c>NULL</c>, the local computer is used.
		/// </param>
		/// <param name="groupname">
		/// A pointer to a constant string that specifies the name of the global group of interest. For more information, see the Remarks section.
		/// </param>
		/// <param name="level">
		/// <para>The information level of the data. This parameter can be one of the following values.</para>
		/// <list type="table">
		/// <listheader>
		/// <term>Value</term>
		/// <term>Meaning</term>
		/// </listheader>
		/// <item>
		/// <term>0</term>
		/// <term>The buf parameter points to an array of GROUP_USERS_INFO_0 structures that specify user names.</term>
		/// </item>
		/// <item>
		/// <term>1</term>
		/// <term>
		/// The buf parameter points to an array of GROUP_USERS_INFO_1 structures that specifies user names and the attributes of the group.
		/// </term>
		/// </item>
		/// </list>
		/// </param>
		/// <param name="buf">A pointer to the buffer that contains the data. For more information, see Network Management Function Buffers.</param>
		/// <param name="totalentries">The number of entries in the buffer pointed to by the buf parameter.</param>
		/// <returns>
		/// <para>If the function succeeds, the return value is NERR_Success.</para>
		/// <para>If the function fails, the return value can be one of the following error codes.</para>
		/// <list type="table">
		/// <listheader>
		/// <term>Return code</term>
		/// <term>Description</term>
		/// </listheader>
		/// <item>
		/// <term>ERROR_ACCESS_DENIED</term>
		/// <term>The user does not have access to the requested information.</term>
		/// </item>
		/// <item>
		/// <term>ERROR_INVALID_LEVEL</term>
		/// <term>
		/// The system call level is not correct. This error is returned if the level parameter was specified as a value other than 0 or 1.
		/// </term>
		/// </item>
		/// <item>
		/// <term>ERROR_INVALID_PARAMETER</term>
		/// <term>A parameter passed was not valid. This error is returned if the totalentries parameter was not valid.</term>
		/// </item>
		/// <item>
		/// <term>ERROR_NOT_ENOUGH_MEMORY</term>
		/// <term>Insufficient memory was available to complete the operation.</term>
		/// </item>
		/// <item>
		/// <term>NERR_InvalidComputer</term>
		/// <term>The computer name is invalid.</term>
		/// </item>
		/// <item>
		/// <term>NERR_NotPrimary</term>
		/// <term>The operation is allowed only on the primary domain controller of the domain.</term>
		/// </item>
		/// <item>
		/// <term>NERR_GroupNotFound</term>
		/// <term>The global group name could not be found.</term>
		/// </item>
		/// <item>
		/// <term>NERR_InternalError</term>
		/// <term>An internal error occurred.</term>
		/// </item>
		/// <item>
		/// <term>NERR_SpeGroupOp</term>
		/// <term>
		/// The operation is not allowed on certain special groups. These groups include user groups, admin groups, local groups, and guest groups.
		/// </term>
		/// </item>
		/// <item>
		/// <term>NERR_UserNotFound</term>
		/// <term>The user name could not be found.</term>
		/// </item>
		/// </list>
		/// </returns>
		/// <remarks>
		/// <para>
		/// If you call this function on a domain controller that is running Active Directory, access is allowed or denied based on the
		/// access control list (ACL) for the securable object. The default ACL permits only Domain Admins and Account Operators to call this
		/// function. On a member server or workstation, only Administrators and Power Users can call this function. For more information,
		/// see Security Requirements for the Network Management Functions. For more information on ACLs, ACEs, and access tokens, see Access
		/// Control Model.
		/// </para>
		/// <para>The security descriptor of the Group object is used to perform the access check for this function.</para>
		/// <para>
		/// You can replace the global group membership with an entirely new list of members by calling the <c>NetGroupSetUsers</c> function.
		/// The typical sequence of steps to perform this follows.
		/// </para>
		/// <para><c>To replace the global group membership</c></para>
		/// <list type="number">
		/// <item>
		/// <term>Call the NetGroupGetUsers function to retrieve the current membership list.</term>
		/// </item>
		/// <item>
		/// <term>Modify the returned membership list to reflect the new membership.</term>
		/// </item>
		/// <item>
		/// <term>Call the <c>NetGroupSetUsers</c> function to replace the old membership list with the new membership list.</term>
		/// </item>
		/// </list>
		/// <para>
		/// To grant one user membership in an existing global group, you can call the NetGroupAddUser function. To remove a user from a
		/// global group, call the NetGroupDelUser function.
		/// </para>
		/// <para>
		/// User account names are limited to 20 characters and group names are limited to 256 characters. In addition, account names cannot
		/// be terminated by a period and they cannot include commas or any of the following printable characters: ", /, , [, ], :, |, &lt;,
		/// &gt;, +, =, ;, ?, *. Names also cannot include characters in the range 1-31, which are non-printable.
		/// </para>
		/// <para>
		/// If you are programming for Active Directory, you may be able to call certain Active Directory Service Interface (ADSI) methods to
		/// achieve the same functionality you can achieve by calling the network management group functions. For more information, see IADsGroup.
		/// </para>
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows/desktop/api/lmaccess/nf-lmaccess-netgroupsetusers NET_API_STATUS NET_API_FUNCTION
		// NetGroupSetUsers( LPCWSTR servername, LPCWSTR groupname, DWORD level, LPBYTE buf, DWORD totalentries );
		[DllImport(Lib.NetApi32, SetLastError = false, ExactSpelling = true, CharSet = CharSet.Unicode)]
		[PInvokeData("lmaccess.h", MSDNShortId = "4221f5c8-a71c-4368-9be4-9562063b6cfd")]
		public static extern Win32Error NetGroupSetUsers([Optional] string servername, string groupname, uint level, IntPtr buf, uint totalentries);

		/// <summary>
		/// <para>
		/// The <c>NetIsServiceAccount</c> function tests whether the specified standalone managed service account (sMSA) or group managed
		/// service account (gMSA) exists in the Netlogon store on the specified server.
		/// </para>
		/// <para>
		/// This function has no associated import library. You must use the LoadLibrary and GetProcAddress functions to dynamically link to Logoncli.dll.
		/// </para>
		/// </summary>
		/// <param name="ServerName">The value of this parameter must be <c>NULL</c>.</param>
		/// <param name="AccountName">The name of the account to be tested.</param>
		/// <param name="IsService"><c>TRUE</c> if the specified service account exists on the specified server; otherwise, <c>FALSE</c>.</param>
		/// <returns>
		/// <para>If the function succeeds, it returns <c>STATUS_SUCCESS</c>.</para>
		/// <para>If the function fails, it returns an error code.</para>
		/// </returns>
		// https://docs.microsoft.com/en-us/windows/desktop/api/lmaccess/nf-lmaccess-netisserviceaccount NTSTATUS NetIsServiceAccount( LPWSTR
		// ServerName, LPWSTR AccountName, BOOL *IsService );
		[DllImport(Lib.NetApi32, SetLastError = false, ExactSpelling = true, CharSet = CharSet.Unicode)]
		[PInvokeData("lmaccess.h", MSDNShortId = "975e7c0d-d803-4d78-99ed-d07369341674")]
		public static extern NTStatus NetIsServiceAccount([Optional] string ServerName, string AccountName, [MarshalAs(UnmanagedType.Bool)] out bool IsService);

		/// <summary>
		/// The <c>NetLocalGroupAdd</c> function creates a local group in the security database, which is the security accounts manager (SAM)
		/// database or, in the case of domain controllers, the Active Directory.
		/// </summary>
		/// <param name="servername">
		/// A pointer to a string that specifies the DNS or NetBIOS name of the remote server on which the function is to execute. If this
		/// parameter is <c>NULL</c>, the local computer is used.
		/// </param>
		/// <param name="level">
		/// <para>The information level of the data. This parameter can be one of the following values.</para>
		/// <list type="table">
		/// <listheader>
		/// <term>Value</term>
		/// <term>Meaning</term>
		/// </listheader>
		/// <item>
		/// <term>0</term>
		/// <term>A local group name. The buf parameter points to a LOCALGROUP_INFO_0 structure.</term>
		/// </item>
		/// <item>
		/// <term>1</term>
		/// <term>A local group name and a comment to associate with the group. The buf parameter points to a LOCALGROUP_INFO_1 structure.</term>
		/// </item>
		/// </list>
		/// </param>
		/// <param name="buf">
		/// A pointer to a buffer that contains the local group information structure. The format of this data depends on the value of the
		/// level parameter. For more information, see Network Management Function Buffers.
		/// </param>
		/// <param name="parm_err">
		/// A pointer to a value that receives the index of the first member of the local group information structure to cause the
		/// ERROR_INVALID_PARAMETER error. If this parameter is <c>NULL</c>, the index is not returned on error. For more information, see
		/// the Remarks section in the NetLocalGroupSetInfo topic.
		/// </param>
		/// <returns>
		/// <para>If the function succeeds, the return value is NERR_Success.</para>
		/// <para>If the function fails, the return value can be one of the following error codes.</para>
		/// <list type="table">
		/// <listheader>
		/// <term>Return code</term>
		/// <term>Description</term>
		/// </listheader>
		/// <item>
		/// <term>ERROR_ACCESS_DENIED</term>
		/// <term>The caller does not have the appropriate access to complete the operation.</term>
		/// </item>
		/// <item>
		/// <term>ERROR_ALIAS_EXISTS</term>
		/// <term>
		/// The specified local group already exists. This error is returned if the group name member in the structure pointed to by the buf
		/// parameter is already in use as an alias.
		/// </term>
		/// </item>
		/// <item>
		/// <term>ERROR_INVALID_LEVEL</term>
		/// <term>A level parameter is invalid.</term>
		/// </item>
		/// <item>
		/// <term>ERROR_INVALID_PARAMETER</term>
		/// <term>
		/// A parameter is incorrect. This error is returned if one or more of the members in the structure pointed to by the buf parameter
		/// is invalid.
		/// </term>
		/// </item>
		/// <item>
		/// <term>NERR_GroupExists</term>
		/// <term>
		/// The group name exists. This error is returned if the group name member in the structure pointed to by the buf parameter is
		/// already in use as a group name.
		/// </term>
		/// </item>
		/// <item>
		/// <term>NERR_InvalidComputer</term>
		/// <term>The computer name is invalid.</term>
		/// </item>
		/// <item>
		/// <term>NERR_NotPrimary</term>
		/// <term>The operation is allowed only on the primary domain controller of the domain.</term>
		/// </item>
		/// <item>
		/// <term>NERR_UserExists</term>
		/// <term>
		/// The user name exists. This error is returned if the group name member in the structure pointed to by the buf parameter is already
		/// in use as a user name.
		/// </term>
		/// </item>
		/// </list>
		/// </returns>
		/// <remarks>
		/// <para>
		/// If you call this function on a domain controller that is running Active Directory, access is allowed or denied based on the
		/// access control list (ACL) for the securable object. The default ACL permits only Domain Admins and Account Operators to call this
		/// function. On a member server or workstation, only Administrators and Power Users can call this function. For more information,
		/// see Security Requirements for the Network Management Functions. For more information on ACLs, ACEs, and access tokens, see Access
		/// Control Model.
		/// </para>
		/// <para>
		/// The security descriptor of the user container is used to perform the access check for this function. The caller must be able to
		/// create child objects of the group class.
		/// </para>
		/// <para>
		/// User account names are limited to 20 characters and group names are limited to 256 characters. In addition, account names cannot
		/// be terminated by a period and they cannot include commas or any of the following printable characters: ", /, , [, ], :, |, &lt;,
		/// &gt;, +, =, ;, ?, *. Names also cannot include characters in the range 1-31, which are non-printable.
		/// </para>
		/// <para>
		/// If the <c>NetLocalGroupAdd</c> function returns <c>ERROR_INVALID_PARAMETER</c> and a <c>NULL</c> pointer was not passed in
		/// parm_err parameter, on return the parm_err parameter indicates the first member of the local group information structure that is
		/// invalid. The format of the local group information structure is specified in the level parameter. A pointer to the local group
		/// information structure is passed in buf parameter. The following table lists the values that can be returned in the parm_err
		/// parameter and the corresponding structure member that is in error.
		/// </para>
		/// <list type="table">
		/// <listheader>
		/// <term>Value</term>
		/// <term>Member</term>
		/// </listheader>
		/// <item>
		/// <term>LOCALGROUP_NAME_PARMNUM</term>
		/// <term>
		/// If the level parameter was 0, the lgrpi0_name member of the LOCALGROUP_INFO_0 structure was invalid. If the level parameter was
		/// 1, the lgrpi1_name member of the LOCALGROUP_INFO_1 structure was invalid.
		/// </term>
		/// </item>
		/// <item>
		/// <term>LOCALGROUP_COMMENT_PARMNUM</term>
		/// <term>If the level parameter was 1, the lgrpi1_comment member of the LOCALGROUP_INFO_1 structure was invalid.</term>
		/// </item>
		/// </list>
		/// <para>
		/// When making requests to a domain controller and Active Directory, you may be able to call certain Active Directory Service
		/// Interface (ADSI) methods to achieve the same results as the network management local group functions. For more information, see IADsGroup.
		/// </para>
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows/desktop/api/lmaccess/nf-lmaccess-netlocalgroupadd NET_API_STATUS NET_API_FUNCTION
		// NetLocalGroupAdd( LPCWSTR servername, DWORD level, LPBYTE buf, LPDWORD parm_err );
		[DllImport(Lib.NetApi32, SetLastError = false, ExactSpelling = true, CharSet = CharSet.Unicode)]
		[PInvokeData("lmaccess.h", MSDNShortId = "5028c1bc-8fed-4f02-8e69-d0d122b08d9f")]
		public static extern Win32Error NetLocalGroupAdd([Optional] string servername, uint level, IntPtr buf, out uint parm_err);

		/// <summary>The <c>NetLocalGroupAddMember</c> function is obsolete. You should use the NetLocalGroupAddMembers function instead.</summary>
		/// <param name="servername">TBD</param>
		/// <param name="groupname">TBD</param>
		/// <param name="membersid">TBD</param>
		/// <returns>None</returns>
		// https://docs.microsoft.com/en-us/windows/desktop/api/lmaccess/nf-lmaccess-netlocalgroupaddmember NET_API_STATUS NET_API_FUNCTION
		// NetLocalGroupAddMember( IN LPCWSTR servername, IN LPCWSTR groupname, IN PSID membersid );
		[DllImport(Lib.NetApi32, SetLastError = false, ExactSpelling = true, CharSet = CharSet.Unicode)]
		[PInvokeData("lmaccess.h", MSDNShortId = "df249dfd-2509-4e67-af4d-b152b95d0eae")]
		public static extern Win32Error NetLocalGroupAddMember([Optional] string servername, string groupname, [In] PSID membersid);

		/// <summary>
		/// The <c>NetLocalGroupAddMembers</c> function adds membership of one or more existing user accounts or global group accounts to an
		/// existing local group. The function does not change the membership status of users or global groups that are currently members of
		/// the local group.
		/// </summary>
		/// <param name="servername">
		/// Pointer to a constant string that specifies the DNS or NetBIOS name of the remote server on which the function is to execute. If
		/// this parameter is <c>NULL</c>, the local computer is used.
		/// </param>
		/// <param name="groupname">
		/// Pointer to a constant string that specifies the name of the local group to which the specified users or global groups will be
		/// added. For more information, see the following Remarks section.
		/// </param>
		/// <param name="level">
		/// <para>Specifies the information level of the data. This parameter can be one of the following values.</para>
		/// <list type="table">
		/// <listheader>
		/// <term>Value</term>
		/// <term>Meaning</term>
		/// </listheader>
		/// <item>
		/// <term>0</term>
		/// <term>
		/// Specifies the security identifier (SID) of the new local group member. The buf parameter points to an array of
		/// LOCALGROUP_MEMBERS_INFO_0 structures.
		/// </term>
		/// </item>
		/// <item>
		/// <term>3</term>
		/// <term>
		/// Specifies the domain and name of the new local group member. The buf parameter points to an array of LOCALGROUP_MEMBERS_INFO_3 structures.
		/// </term>
		/// </item>
		/// </list>
		/// </param>
		/// <param name="buf">
		/// Pointer to a buffer that contains the data for the new local group members. The format of this data depends on the value of the
		/// level parameter. For more information, see Network Management Function Buffers.
		/// </param>
		/// <param name="totalentries">Specifies the number of entries in the buffer pointed to by the buf parameter.</param>
		/// <returns>
		/// <para>If the function succeeds, the return value is NERR_Success.</para>
		/// <para>If the function fails, the return value can be one of the following error codes.</para>
		/// <list type="table">
		/// <listheader>
		/// <term>Return code</term>
		/// <term>Description</term>
		/// </listheader>
		/// <item>
		/// <term>NERR_GroupNotFound</term>
		/// <term>The local group specified by the groupname parameter does not exist.</term>
		/// </item>
		/// <item>
		/// <term>ERROR_ACCESS_DENIED</term>
		/// <term>The user does not have access to the requested information.</term>
		/// </item>
		/// <item>
		/// <term>ERROR_NO_SUCH_MEMBER</term>
		/// <term>One or more of the members specified do not exist. Therefore, no new members were added.</term>
		/// </item>
		/// <item>
		/// <term>ERROR_MEMBER_IN_ALIAS</term>
		/// <term>One or more of the members specified were already members of the local group. No new members were added.</term>
		/// </item>
		/// <item>
		/// <term>ERROR_INVALID_MEMBER</term>
		/// <term>One or more of the members cannot be added because their account type is invalid. No new members were added.</term>
		/// </item>
		/// </list>
		/// </returns>
		/// <remarks>
		/// <para>
		/// If you call this function on a domain controller that is running Active Directory, access is allowed or denied based on the
		/// access control list (ACL) for the securable object. The default ACL permits only Domain Admins and Account Operators to call this
		/// function. On a member server or workstation, only Administrators and Power Users can call this function. For more information,
		/// see Security Requirements for the Network Management Functions. For more information on ACLs, ACEs, and access tokens, see Access
		/// Control Model.
		/// </para>
		/// <para>The security descriptor of the LocalGroup object is used to perform the access check for this function.</para>
		/// <para>
		/// User account names are limited to 20 characters and group names are limited to 256 characters. In addition, account names cannot
		/// be terminated by a period and they cannot include commas or any of the following printable characters: ", /, , [, ], :, |, &lt;,
		/// &gt;, +, =, ;, ?, *. Names also cannot include characters in the range 1-31, which are non-printable.
		/// </para>
		/// <para>
		/// If you are programming for Active Directory, you may be able to call certain Active Directory Service Interface (ADSI) methods to
		/// achieve the same functionality you can achieve by calling the network management local group functions. For more information, see IADsGroup.
		/// </para>
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows/desktop/api/lmaccess/nf-lmaccess-netlocalgroupaddmembers NET_API_STATUS NET_API_FUNCTION
		// NetLocalGroupAddMembers( LPCWSTR servername, LPCWSTR groupname, DWORD level, LPBYTE buf, DWORD totalentries );
		[DllImport(Lib.NetApi32, SetLastError = false, ExactSpelling = true, CharSet = CharSet.Unicode)]
		[PInvokeData("lmaccess.h", MSDNShortId = "3b2d3e4a-742e-4e67-8b28-3cd6d7e6a857")]
		public static extern Win32Error NetLocalGroupAddMembers([Optional] string servername, string groupname, uint level, IntPtr buf, uint totalentries);

		/// <summary>
		/// The <c>NetLocalGroupDel</c> function deletes a local group account and all its members from the security database, which is the
		/// security accounts manager (SAM) database or, in the case of domain controllers, the Active Directory.
		/// </summary>
		/// <param name="servername">
		/// Pointer to a constant string that specifies the DNS or NetBIOS name of the remote server on which the function is to execute. If
		/// this parameter is <c>NULL</c>, the local computer is used.
		/// </param>
		/// <param name="groupname">
		/// Pointer to a constant string that specifies the name of the local group account to delete. For more information, see the
		/// following Remarks section.
		/// </param>
		/// <returns>
		/// <para>If the function succeeds, the return value is NERR_Success.</para>
		/// <para>If the function fails, the return value can be one of the following error codes.</para>
		/// <list type="table">
		/// <listheader>
		/// <term>Return code</term>
		/// <term>Description</term>
		/// </listheader>
		/// <item>
		/// <term>ERROR_ACCESS_DENIED</term>
		/// <term>The user does not have access to the requested information.</term>
		/// </item>
		/// <item>
		/// <term>NERR_InvalidComputer</term>
		/// <term>The computer name is invalid.</term>
		/// </item>
		/// <item>
		/// <term>NERR_NotPrimary</term>
		/// <term>The operation is allowed only on the primary domain controller of the domain.</term>
		/// </item>
		/// <item>
		/// <term>NERR_GroupNotFound</term>
		/// <term>The local group specified by the groupname parameter does not exist.</term>
		/// </item>
		/// <item>
		/// <term>ERROR_NO_SUCH_ALIAS</term>
		/// <term>The specified local group does not exist.</term>
		/// </item>
		/// </list>
		/// </returns>
		/// <remarks>
		/// <para>
		/// If you call this function on a domain controller that is running Active Directory, access is allowed or denied based on the
		/// access control list (ACL) for the securable object. The default ACL permits only Domain Admins and Account Operators to call this
		/// function. On a member server or workstation, only Administrators and Power Users can call this function. For more information,
		/// see Security Requirements for the Network Management Functions. For more information on ACLs, ACEs, and access tokens, see Access
		/// Control Model.
		/// </para>
		/// <para>The security descriptor of the LocalGroup object is used to perform the access check for this function.</para>
		/// <para>
		/// User account names are limited to 20 characters and group names are limited to 256 characters. In addition, account names cannot
		/// be terminated by a period and they cannot include commas or any of the following printable characters: ", /, , [, ], :, |, &lt;,
		/// &gt;, +, =, ;, ?, *. Names also cannot include characters in the range 1-31, which are non-printable.
		/// </para>
		/// <para>
		/// If you are programming for Active Directory, you may be able to call certain Active Directory Service Interface (ADSI) methods to
		/// achieve the same functionality you can achieve by calling the network management local group functions. For more information, see IADsGroup.
		/// </para>
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows/desktop/api/lmaccess/nf-lmaccess-netlocalgroupdel NET_API_STATUS NET_API_FUNCTION
		// NetLocalGroupDel( LPCWSTR servername, LPCWSTR groupname );
		[DllImport(Lib.NetApi32, SetLastError = false, ExactSpelling = true, CharSet = CharSet.Unicode)]
		[PInvokeData("lmaccess.h", MSDNShortId = "b26bfd52-c20a-4f6f-9503-87cac5168362")]
		public static extern Win32Error NetLocalGroupDel([Optional] string servername, string groupname);

		/// <summary>The <c>NetLocalGroupDelMember</c> function is obsolete. You should use the NetLocalGroupDelMembers function instead.</summary>
		/// <param name="servername">TBD</param>
		/// <param name="groupname">TBD</param>
		/// <param name="membersid">TBD</param>
		/// <returns>None</returns>
		// https://docs.microsoft.com/en-us/windows/desktop/api/lmaccess/nf-lmaccess-netlocalgroupdelmember NET_API_STATUS NET_API_FUNCTION
		// NetLocalGroupDelMember( LPCWSTR servername, LPCWSTR groupname, PSID membersid );
		[DllImport(Lib.NetApi32, SetLastError = false, ExactSpelling = true, CharSet = CharSet.Unicode)]
		[PInvokeData("lmaccess.h", MSDNShortId = "4a231da6-904e-4b49-9855-03e004a0b695")]
		public static extern Win32Error NetLocalGroupDelMember([Optional] string servername, string groupname, PSID membersid);

		/// <summary>
		/// The <c>NetLocalGroupDelMembers</c> function removes one or more members from an existing local group. Local group members can be
		/// users or global groups.
		/// </summary>
		/// <param name="servername">
		/// Pointer to a constant string that specifies the DNS or NetBIOS name of the remote server on which the function is to execute. If
		/// this parameter is <c>NULL</c>, the local computer is used.
		/// </param>
		/// <param name="groupname">
		/// Pointer to a constant string that specifies the name of the local group from which the specified users or global groups will be
		/// removed. For more information, see the following Remarks section.
		/// </param>
		/// <param name="level">
		/// <para>Specifies the information level of the data. This parameter can be one of the following values.</para>
		/// <list type="table">
		/// <listheader>
		/// <term>Value</term>
		/// <term>Meaning</term>
		/// </listheader>
		/// <item>
		/// <term>0</term>
		/// <term>
		/// Specifies the security identifier (SID) of a local group member to remove. The buf parameter points to an array of
		/// LOCALGROUP_MEMBERS_INFO_0 structures.
		/// </term>
		/// </item>
		/// <item>
		/// <term>3</term>
		/// <term>
		/// Specifies the domain and name of a local group member to remove. The buf parameter points to an array of
		/// LOCALGROUP_MEMBERS_INFO_3 structures.
		/// </term>
		/// </item>
		/// </list>
		/// </param>
		/// <param name="buf">
		/// Pointer to a buffer that specifies the members to be removed. The format of this data depends on the value of the level
		/// parameter. For more information, see Network Management Function Buffers.
		/// </param>
		/// <param name="totalentries">Specifies the number of entries in the array pointed to by the buf parameter.</param>
		/// <returns>
		/// <para>If the function succeeds, the return value is NERR_Success.</para>
		/// <para>If the function fails, the return value can be one of the following error codes.</para>
		/// <list type="table">
		/// <listheader>
		/// <term>Return code</term>
		/// <term>Description</term>
		/// </listheader>
		/// <item>
		/// <term>ERROR_ACCESS_DENIED</term>
		/// <term>The user does not have access to the requested information.</term>
		/// </item>
		/// <item>
		/// <term>NERR_GroupNotFound</term>
		/// <term>The local group specified by the groupname parameter does not exist.</term>
		/// </item>
		/// <item>
		/// <term>ERROR_NO_SUCH_MEMBER</term>
		/// <term>One or more of the specified members do not exist. No members were deleted.</term>
		/// </item>
		/// <item>
		/// <term>ERROR_MEMBER_NOT_IN_ALIAS</term>
		/// <term>One or more of the members specified were not members of the local group. No members were deleted.</term>
		/// </item>
		/// </list>
		/// </returns>
		/// <remarks>
		/// <para>
		/// If you call this function on a domain controller that is running Active Directory, access is allowed or denied based on the
		/// access control list (ACL) for the securable object. The default ACL permits only Domain Admins and Account Operators to call this
		/// function. On a member server or workstation, only Administrators and Power Users can call this function. For more information,
		/// see Security Requirements for the Network Management Functions. For more information on ACLs, ACEs, and access tokens, see Access
		/// Control Model.
		/// </para>
		/// <para>The security descriptor of the LocalGroup object is used to perform the access check for this function.</para>
		/// <para>
		/// User account names are limited to 20 characters and group names are limited to 256 characters. In addition, account names cannot
		/// be terminated by a period and they cannot include commas or any of the following printable characters: ", /, , [, ], :, |, &lt;,
		/// &gt;, +, =, ;, ?, *. Names also cannot include characters in the range 1-31, which are non-printable.
		/// </para>
		/// <para>
		/// If you are programming for Active Directory, you may be able to call certain Active Directory Service Interface (ADSI) methods to
		/// achieve the same functionality you can achieve by calling the network management local group functions. For more information, see IADsGroup.
		/// </para>
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows/desktop/api/lmaccess/nf-lmaccess-netlocalgroupdelmembers NET_API_STATUS NET_API_FUNCTION
		// NetLocalGroupDelMembers( LPCWSTR servername, LPCWSTR groupname, DWORD level, LPBYTE buf, DWORD totalentries );
		[DllImport(Lib.NetApi32, SetLastError = false, ExactSpelling = true, CharSet = CharSet.Unicode)]
		[PInvokeData("lmaccess.h", MSDNShortId = "85ae796b-c94a-46a8-9fa8-6c612db38671")]
		public static extern Win32Error NetLocalGroupDelMembers([Optional] string servername, string groupname, uint level, IntPtr buf, uint totalentries);

		/// <summary>The <c>NetLocalGroupEnum</c> function returns information about each local group account on the specified server.</summary>
		/// <param name="servername">
		/// Pointer to a constant string that specifies the DNS or NetBIOS name of the remote server on which the function is to execute. If
		/// this parameter is <c>NULL</c>, the local computer is used.
		/// </param>
		/// <param name="level">
		/// <para>Specifies the information level of the data. This parameter can be one of the following values.</para>
		/// <list type="table">
		/// <listheader>
		/// <term>Value</term>
		/// <term>Meaning</term>
		/// </listheader>
		/// <item>
		/// <term>0</term>
		/// <term>Return local group names. The bufptr parameter points to an array of LOCALGROUP_INFO_0 structures.</term>
		/// </item>
		/// <item>
		/// <term>1</term>
		/// <term>
		/// Return local group names and the comment associated with each group. The bufptr parameter points to an array of LOCALGROUP_INFO_1 structures.
		/// </term>
		/// </item>
		/// </list>
		/// </param>
		/// <param name="bufptr">
		/// Pointer to the address of the buffer that receives the information structure. The format of this data depends on the value of the
		/// level parameter. This buffer is allocated by the system and must be freed using the NetApiBufferFree function. Note that you must
		/// free the buffer even if the function fails with ERROR_MORE_DATA.
		/// </param>
		/// <param name="prefmaxlen">
		/// Specifies the preferred maximum length of returned data, in bytes. If you specify MAX_PREFERRED_LENGTH, the function allocates
		/// the amount of memory required for the data. If you specify another value in this parameter, it can restrict the number of bytes
		/// that the function returns. If the buffer size is insufficient to hold all entries, the function returns ERROR_MORE_DATA. For more
		/// information, see Network Management Function Buffers and Network Management Function Buffer Lengths.
		/// </param>
		/// <param name="entriesread">Pointer to a value that receives the count of elements actually enumerated.</param>
		/// <param name="totalentries">
		/// Pointer to a value that receives the approximate total number of entries that could have been enumerated from the current resume
		/// position. The total number of entries is only a hint. For more information about determining the exact number of entries, see the
		/// following Remarks section.
		/// </param>
		/// <param name="resumehandle">
		/// Pointer to a value that contains a resume handle that is used to continue an existing local group search. The handle should be
		/// zero on the first call and left unchanged for subsequent calls. If this parameter is <c>NULL</c>, then no resume handle is
		/// stored. For more information, see the following Remarks section.
		/// </param>
		/// <returns>
		/// <para>If the function succeeds, the return value is NERR_Success.</para>
		/// <para>If the function fails, the return value can be one of the following error codes.</para>
		/// <list type="table">
		/// <listheader>
		/// <term>Return code</term>
		/// <term>Description</term>
		/// </listheader>
		/// <item>
		/// <term>ERROR_ACCESS_DENIED</term>
		/// <term>The user does not have access to the requested information.</term>
		/// </item>
		/// <item>
		/// <term>ERROR_MORE_DATA</term>
		/// <term>More entries are available. Specify a large enough buffer to receive all entries.</term>
		/// </item>
		/// <item>
		/// <term>NERR_InvalidComputer</term>
		/// <term>The computer name is invalid.</term>
		/// </item>
		/// <item>
		/// <term>NERR_BufTooSmall</term>
		/// <term>The return buffer is too small.</term>
		/// </item>
		/// </list>
		/// </returns>
		/// <remarks>
		/// <para>
		/// If you call this function on a domain controller that is running Active Directory, access is allowed or denied based on the
		/// access control list (ACL) for the securable object. The default ACL permits all authenticated users and members of the
		/// "Pre-Windows 2000 compatible access" group to view the information. If you call this function on a member server or workstation,
		/// all authenticated users can view the information. For information about anonymous access and restricting anonymous access on
		/// these platforms, see Security Requirements for the Network Management Functions. For more information on ACLs, ACEs, and access
		/// tokens, see Access Control Model.
		/// </para>
		/// <para>
		/// The function only returns information to which the caller has Read access. The caller must have List Contents access to the
		/// Domain object, and Enumerate Entire SAM Domain access on the SAM Server object located in the System container.
		/// </para>
		/// <para>
		/// To determine the exact total number of local groups, you must enumerate the entire tree, which can be a costly operation. To
		/// enumerate the entire tree, use the resumehandle parameter to continue the enumeration for consecutive calls, and use the
		/// entriesread parameter to accumulate the total number of local groups. If your application is communicating with a domain
		/// controller, you should consider using the ADSI LDAP Provider to retrieve this type of data more efficiently. The ADSI LDAP
		/// Provider implements a set of ADSI objects that support various ADSI interfaces. For more information, see ADSI Service Providers.
		/// </para>
		/// <para>
		/// User account names are limited to 20 characters and group names are limited to 256 characters. In addition, account names cannot
		/// be terminated by a period and they cannot include commas or any of the following printable characters: ", /, , [, ], :, |, &lt;,
		/// &gt;, +, =, ;, ?, *. Names also cannot include characters in the range 1-31, which are non-printable.
		/// </para>
		/// <para>
		/// If you are programming for Active Directory, you may be able to call certain Active Directory Service Interface (ADSI) methods to
		/// achieve the same functionality you can achieve by calling the network management local group functions. For more information, see IADsGroup.
		/// </para>
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows/desktop/api/lmaccess/nf-lmaccess-netlocalgroupenum NET_API_STATUS NET_API_FUNCTION
		// NetLocalGroupEnum( LPCWSTR servername, DWORD level, LPBYTE *bufptr, DWORD prefmaxlen, LPDWORD entriesread, LPDWORD totalentries,
		// PDWORD_PTR resumehandle );
		[DllImport(Lib.NetApi32, SetLastError = false, ExactSpelling = true, CharSet = CharSet.Unicode)]
		[PInvokeData("lmaccess.h", MSDNShortId = "fc27d7f1-bfbe-46d7-a154-f04eb9249248")]
		public static extern Win32Error NetLocalGroupEnum([Optional] string servername, uint level, out SafeNetApiBuffer bufptr, uint prefmaxlen, out uint entriesread, out uint totalentries, ref IntPtr resumehandle);

		/// <summary>The <c>NetLocalGroupGetInfo</c> function retrieves information about a particular local group account on a server.</summary>
		/// <param name="servername">
		/// Pointer to a constant string that specifies the DNS or NetBIOS name of the remote server on which the function is to execute. If
		/// this parameter is <c>NULL</c>, the local computer is used.
		/// </param>
		/// <param name="groupname">
		/// Pointer to a constant string that specifies the name of the local group account for which the information will be retrieved. For
		/// more information, see the following Remarks section.
		/// </param>
		/// <param name="level">
		/// <para>Specifies the information level of the data. This parameter can be the following value.</para>
		/// <list type="table">
		/// <listheader>
		/// <term>Value</term>
		/// <term>Meaning</term>
		/// </listheader>
		/// <item>
		/// <term>1</term>
		/// <term>Return the comment associated with the local group. The bufptr parameter points to a LOCALGROUP_INFO_1 structure.</term>
		/// </item>
		/// </list>
		/// </param>
		/// <param name="bufptr">
		/// Pointer to the address of the buffer that receives the return information structure. This buffer is allocated by the system and
		/// must be freed using the NetApiBufferFree function. For more information, see Network Management Function Buffers and Network
		/// Management Function Buffer Lengths.
		/// </param>
		/// <returns>
		/// <para>If the function succeeds, the return value is NERR_Success.</para>
		/// <para>If the function fails, the return value can be one of the following error codes.</para>
		/// <list type="table">
		/// <listheader>
		/// <term>Return code</term>
		/// <term>Description</term>
		/// </listheader>
		/// <item>
		/// <term>ERROR_ACCESS_DENIED</term>
		/// <term>The user does not have access to the requested information.</term>
		/// </item>
		/// <item>
		/// <term>NERR_InvalidComputer</term>
		/// <term>The computer name is invalid.</term>
		/// </item>
		/// <item>
		/// <term>NERR_GroupNotFound</term>
		/// <term>The specified local group does not exist.</term>
		/// </item>
		/// </list>
		/// </returns>
		/// <remarks>
		/// <para>
		/// If you call this function on a domain controller that is running Active Directory, access is allowed or denied based on the
		/// access control list (ACL) for the securable object. The default ACL permits all authenticated users and members of the
		/// "Pre-Windows 2000 compatible access" group to view the information. If you call this function on a member server or workstation,
		/// all authenticated users can view the information. For information about anonymous access and restricting anonymous access on
		/// these platforms, see Security Requirements for the Network Management Functions. For more information on ACLs, ACEs, and access
		/// tokens, see Access Control Model.
		/// </para>
		/// <para>The security descriptor of the LocalGroup object is used to perform the access check for this function.</para>
		/// <para>
		/// User account names are limited to 20 characters and group names are limited to 256 characters. In addition, account names cannot
		/// be terminated by a period and they cannot include commas or any of the following printable characters: ", /, , [, ], :, |, &lt;,
		/// &gt;, +, =, ;, ?, *. Names also cannot include characters in the range 1-31, which are non-printable.
		/// </para>
		/// <para>
		/// If you are programming for Active Directory, you may be able to call certain Active Directory Service Interface (ADSI) methods to
		/// achieve the same functionality you can achieve by calling the network management local group functions. For more information, see IADsGroup.
		/// </para>
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows/desktop/api/lmaccess/nf-lmaccess-netlocalgroupgetinfo NET_API_STATUS NET_API_FUNCTION
		// NetLocalGroupGetInfo( LPCWSTR servername, LPCWSTR groupname, DWORD level, LPBYTE *bufptr );
		[DllImport(Lib.NetApi32, SetLastError = false, ExactSpelling = true, CharSet = CharSet.Unicode)]
		[PInvokeData("lmaccess.h", MSDNShortId = "ee2f0be9-8d52-439b-ab65-f9e11a2872c5")]
		public static extern Win32Error NetLocalGroupGetInfo([Optional] string servername, string groupname, uint level, out SafeNetApiBuffer bufptr);

		/// <summary>
		/// The <c>NetLocalGroupGetMembers</c> function retrieves a list of the members of a particular local group in the security database,
		/// which is the security accounts manager (SAM) database or, in the case of domain controllers, the Active Directory. Local group
		/// members can be users or global groups.
		/// </summary>
		/// <param name="servername">
		/// Pointer to a constant string that specifies the DNS or NetBIOS name of the remote server on which the function is to execute. If
		/// this parameter is <c>NULL</c>, the local computer is used.
		/// </param>
		/// <param name="localgroupname">
		/// Pointer to a constant string that specifies the name of the local group whose members are to be listed. For more information, see
		/// the following Remarks section.
		/// </param>
		/// <param name="level">
		/// <para>Specifies the information level of the data. This parameter can be one of the following values.</para>
		/// <list type="table">
		/// <listheader>
		/// <term>Value</term>
		/// <term>Meaning</term>
		/// </listheader>
		/// <item>
		/// <term>0</term>
		/// <term>
		/// Return the security identifier (SID) associated with the local group member. The bufptr parameter points to an array of
		/// LOCALGROUP_MEMBERS_INFO_0 structures.
		/// </term>
		/// </item>
		/// <item>
		/// <term>1</term>
		/// <term>
		/// Return the SID and account information associated with the local group member. The bufptr parameter points to an array of
		/// LOCALGROUP_MEMBERS_INFO_1 structures.
		/// </term>
		/// </item>
		/// <item>
		/// <term>2</term>
		/// <term>
		/// Return the SID, account information, and the domain name associated with the local group member. The bufptr parameter points to
		/// an array of LOCALGROUP_MEMBERS_INFO_2 structures.
		/// </term>
		/// </item>
		/// <item>
		/// <term>3</term>
		/// <term>
		/// Return the account and domain names of the local group member. The bufptr parameter points to an array of
		/// LOCALGROUP_MEMBERS_INFO_3 structures.
		/// </term>
		/// </item>
		/// </list>
		/// </param>
		/// <param name="bufptr">
		/// Pointer to the address that receives the return information structure. The format of this data depends on the value of the level
		/// parameter. This buffer is allocated by the system and must be freed using the NetApiBufferFree function. Note that you must free
		/// the buffer even if the function fails with ERROR_MORE_DATA.
		/// </param>
		/// <param name="prefmaxlen">
		/// Specifies the preferred maximum length of returned data, in bytes. If you specify MAX_PREFERRED_LENGTH, the function allocates
		/// the amount of memory required for the data. If you specify another value in this parameter, it can restrict the number of bytes
		/// that the function returns. If the buffer size is insufficient to hold all entries, the function returns ERROR_MORE_DATA. For more
		/// information, see Network Management Function Buffers and Network Management Function Buffer Lengths.
		/// </param>
		/// <param name="entriesread">Pointer to a value that receives the count of elements actually enumerated.</param>
		/// <param name="totalentries">
		/// Pointer to a value that receives the total number of entries that could have been enumerated from the current resume position.
		/// </param>
		/// <param name="resumehandle">
		/// Pointer to a value that contains a resume handle which is used to continue an existing group member search. The handle should be
		/// zero on the first call and left unchanged for subsequent calls. If this parameter is <c>NULL</c>, then no resume handle is stored.
		/// </param>
		/// <returns>
		/// <para>If the function succeeds, the return value is NERR_Success.</para>
		/// <para>If the function fails, the return value can be one of the following error codes.</para>
		/// <list type="table">
		/// <listheader>
		/// <term>Return code</term>
		/// <term>Description</term>
		/// </listheader>
		/// <item>
		/// <term>ERROR_ACCESS_DENIED</term>
		/// <term>The user does not have access to the requested information.</term>
		/// </item>
		/// <item>
		/// <term>NERR_InvalidComputer</term>
		/// <term>The computer name is invalid.</term>
		/// </item>
		/// <item>
		/// <term>ERROR_MORE_DATA</term>
		/// <term>More entries are available. Specify a large enough buffer to receive all entries.</term>
		/// </item>
		/// <item>
		/// <term>ERROR_NO_SUCH_ALIAS</term>
		/// <term>The specified local group does not exist.</term>
		/// </item>
		/// </list>
		/// </returns>
		/// <remarks>
		/// <para>
		/// If you call this function on a domain controller that is running Active Directory, access is allowed or denied based on the
		/// access control list (ACL) for the securable object. The default ACL permits all authenticated users and members of the
		/// "Pre-Windows 2000 compatible access" group to view the information. If you call this function on a member server or workstation,
		/// all authenticated users can view the information. For information about anonymous access and restricting anonymous access on
		/// these platforms, see Security Requirements for the Network Management Functions. For more information on ACLs, ACEs, and access
		/// tokens, see Access Control Model.
		/// </para>
		/// <para>The security descriptor of the LocalGroup object is used to perform the access check for this function.</para>
		/// <para>
		/// User account names are limited to 20 characters and group names are limited to 256 characters. In addition, account names cannot
		/// be terminated by a period and they cannot include commas or any of the following printable characters: ", /, , [, ], :, |, &lt;,
		/// &gt;, +, =, ;, ?, *. Names also cannot include characters in the range 1-31, which are non-printable.
		/// </para>
		/// <para>
		/// If you are programming for Active Directory, you may be able to call certain Active Directory Service Interface (ADSI) methods to
		/// achieve the same functionality you can achieve by calling the network management local group functions. For more information, see IADsGroup.
		/// </para>
		/// <para>
		/// If this function returns <c>ERROR_MORE_DATA</c>, then it must be repeatedly called until <c>ERROR_SUCCESS</c> or
		/// <c>NERR_success</c> is returned. Failure to do so can result in an RPC connection leak.
		/// </para>
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows/desktop/api/lmaccess/nf-lmaccess-netlocalgroupgetmembers NET_API_STATUS NET_API_FUNCTION
		// NetLocalGroupGetMembers( LPCWSTR servername, LPCWSTR localgroupname, DWORD level, LPBYTE *bufptr, DWORD prefmaxlen, LPDWORD
		// entriesread, LPDWORD totalentries, PDWORD_PTR resumehandle );
		[DllImport(Lib.NetApi32, SetLastError = false, ExactSpelling = true, CharSet = CharSet.Unicode)]
		[PInvokeData("lmaccess.h", MSDNShortId = "35770b32-dae9-46f5-84e3-1c31ca22f708")]
		public static extern Win32Error NetLocalGroupGetMembers([Optional] string servername, string localgroupname, uint level, out SafeNetApiBuffer bufptr, uint prefmaxlen, out uint entriesread, out uint totalentries, ref IntPtr resumehandle);

		/// <summary>
		/// The <c>NetLocalGroupSetInfo</c> function changes the name of an existing local group. The function also associates a comment with
		/// a local group.
		/// </summary>
		/// <param name="servername">
		/// Pointer to a constant string that specifies the DNS or NetBIOS name of the remote server on which the function is to execute. If
		/// this parameter is <c>NULL</c>, the local computer is used.
		/// </param>
		/// <param name="groupname">
		/// Pointer to a constant string that specifies the name of the local group account to modify. For more information, see the
		/// following Remarks section.
		/// </param>
		/// <param name="level">
		/// <para>Specifies the information level of the data. This parameter can be one of the following values.</para>
		/// <list type="table">
		/// <listheader>
		/// <term>Value</term>
		/// <term>Meaning</term>
		/// </listheader>
		/// <item>
		/// <term>0</term>
		/// <term>
		/// Specifies the local group name. The buf parameter points to a LOCALGROUP_INFO_0 structure. Use this level to change the name of
		/// an existing local group.
		/// </term>
		/// </item>
		/// <item>
		/// <term>1</term>
		/// <term>
		/// Specifies the local group name and a comment to associate with the group. The buf parameter points to a LOCALGROUP_INFO_1 structure.
		/// </term>
		/// </item>
		/// <item>
		/// <term>1002</term>
		/// <term>Specifies a comment to associate with the local group. The buf parameter points to a LOCALGROUP_INFO_1002 structure.</term>
		/// </item>
		/// </list>
		/// </param>
		/// <param name="buf">
		/// Pointer to a buffer that contains the local group information. The format of this data depends on the value of the level
		/// parameter. For more information, see Network Management Function Buffers.
		/// </param>
		/// <param name="parm_err">
		/// Pointer to a value that receives the index of the first member of the local group information structure that caused the
		/// ERROR_INVALID_PARAMETER error. If this parameter is <c>NULL</c>, the index is not returned on error. For more information, see
		/// the following Remarks section.
		/// </param>
		/// <returns>
		/// <para>If the function succeeds, the return value is NERR_Success.</para>
		/// <para>If the function fails, the return value can be one of the following error codes.</para>
		/// <list type="table">
		/// <listheader>
		/// <term>Return code</term>
		/// <term>Description</term>
		/// </listheader>
		/// <item>
		/// <term>ERROR_ACCESS_DENIED</term>
		/// <term>The user does not have access to the requested information.</term>
		/// </item>
		/// <item>
		/// <term>ERROR_INVALID_PARAMETER</term>
		/// <term>One of the function parameters is invalid. For more information, see the following Remarks section.</term>
		/// </item>
		/// <item>
		/// <term>ERROR_NO_SUCH_ALIAS</term>
		/// <term>The specified local group does not exist.</term>
		/// </item>
		/// <item>
		/// <term>NERR_NotPrimary</term>
		/// <term>The operation is allowed only on the primary domain controller of the domain.</term>
		/// </item>
		/// <item>
		/// <term>NERR_InvalidComputer</term>
		/// <term>The computer name is invalid.</term>
		/// </item>
		/// </list>
		/// </returns>
		/// <remarks>
		/// <para>
		/// If you call this function on a domain controller that is running Active Directory, access is allowed or denied based on the
		/// access control list (ACL) for the securable object. The default ACL permits only Domain Admins and Account Operators to call this
		/// function. On a member server or workstation, only Administrators and Power Users can call this function. For more information,
		/// see Security Requirements for the Network Management Functions. For more information on ACLs, ACEs, and access tokens, see Access
		/// Control Model.
		/// </para>
		/// <para>
		/// The security descriptor of the LocalGroup object is used to perform the access check for this function. Typically, callers must
		/// have write access to the entire object for calls to this function to succeed.
		/// </para>
		/// <para>
		/// To specify the new name of an existing local group, call <c>NetLocalGroupSetInfo</c> with LOCALGROUP_INFO_0 and specify a value
		/// using the <c>lgrpi0_name</c> member. If you call the <c>NetLocalGroupSetInfo</c> function with LOCALGROUP_INFO_1 and specify a
		/// new value using the <c>lgrpi1_name</c> member, that value will be ignored.
		/// </para>
		/// <para>
		/// If the <c>NetLocalGroupSetInfo</c> function returns ERROR_INVALID_PARAMETER, you can use the parm_err parameter to indicate the
		/// first member of the local group information structure that is invalid. (A local group information structure begins with
		/// LOCALGROUP_INFO_ and its format is specified by the level parameter.) The following table lists the values that can be returned
		/// in the parm_err parameter and the corresponding structure member that is in error. (The prefix lgrpi*_ indicates that the member
		/// can begin with multiple prefixes, for example, lgrpi0_ or lgrpi1_.)
		/// </para>
		/// <list type="table">
		/// <listheader>
		/// <term>Value</term>
		/// <term>Member</term>
		/// </listheader>
		/// <item>
		/// <term>LOCALGROUP_NAME_PARMNUM</term>
		/// <term>lgrpi*_name</term>
		/// </item>
		/// <item>
		/// <term>LOCALGROUP_COMMENT_PARMNUM</term>
		/// <term>lgrpi*_comment</term>
		/// </item>
		/// </list>
		/// <para>
		/// User account names are limited to 20 characters and group names are limited to 256 characters. In addition, account names cannot
		/// be terminated by a period and they cannot include commas or any of the following printable characters: ", /, , [, ], :, |, &lt;,
		/// &gt;, +, =, ;, ?, *. Names also cannot include characters in the range 1-31, which are non-printable.
		/// </para>
		/// <para>
		/// If you are programming for Active Directory, you may be able to call certain Active Directory Service Interface (ADSI) methods to
		/// achieve the same functionality you can achieve by calling the network management local group functions. For more information, see IADsGroup.
		/// </para>
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows/desktop/api/lmaccess/nf-lmaccess-netlocalgroupsetinfo NET_API_STATUS NET_API_FUNCTION
		// NetLocalGroupSetInfo( LPCWSTR servername, LPCWSTR groupname, DWORD level, LPBYTE buf, LPDWORD parm_err );
		[DllImport(Lib.NetApi32, SetLastError = false, ExactSpelling = true, CharSet = CharSet.Unicode)]
		[PInvokeData("lmaccess.h", MSDNShortId = "c1d2a68b-0910-4815-9547-0f0f3c983164")]
		public static extern Win32Error NetLocalGroupSetInfo([Optional] string servername, string groupname, uint level, IntPtr buf, out uint parm_err);

		/// <summary>
		/// The <c>NetLocalGroupSetMembers</c> function sets the membership for the specified local group. Each user or global group
		/// specified is made a member of the local group. Users or global groups that are not specified but who are currently members of the
		/// local group will have their membership revoked.
		/// </summary>
		/// <param name="servername">
		/// Pointer to a constant string that specifies the DNS or NetBIOS name of the remote server on which the function is to execute. If
		/// this parameter is <c>NULL</c>, the local computer is used.
		/// </param>
		/// <param name="groupname">
		/// Pointer to a constant string that specifies the name of the local group in which the specified users or global groups should be
		/// granted membership. For more information, see the following Remarks section.
		/// </param>
		/// <param name="level">
		/// <para>Specifies the information level of the data. This parameter can be one of the following values.</para>
		/// <list type="table">
		/// <listheader>
		/// <term>Value</term>
		/// <term>Meaning</term>
		/// </listheader>
		/// <item>
		/// <term>0</term>
		/// <term>
		/// Specifies the security identifier (SID) associated with a local group member. The buf parameter points to an array of
		/// LOCALGROUP_MEMBERS_INFO_0 structures.
		/// </term>
		/// </item>
		/// <item>
		/// <term>3</term>
		/// <term>
		/// Specifies the account and domain names of the local group member. The buf parameter points to an array of
		/// LOCALGROUP_MEMBERS_INFO_3 structures.
		/// </term>
		/// </item>
		/// </list>
		/// </param>
		/// <param name="buf">
		/// Pointer to the buffer that contains the member information. The format of this data depends on the value of the level parameter.
		/// For more information, see Network Management Function Buffers.
		/// </param>
		/// <param name="totalentries">
		/// Specifies a value that contains the total number of entries in the buffer pointed to by the buf parameter.
		/// </param>
		/// <returns>
		/// <para>If the function succeeds, the return value is NERR_Success.</para>
		/// <para>If the function fails, the return value can be one of the following error codes.</para>
		/// <list type="table">
		/// <listheader>
		/// <term>Return code</term>
		/// <term>Description</term>
		/// </listheader>
		/// <item>
		/// <term>NERR_GroupNotFound</term>
		/// <term>The group specified by the groupname parameter does not exist.</term>
		/// </item>
		/// <item>
		/// <term>ERROR_ACCESS_DENIED</term>
		/// <term>The user does not have access to the requested information.</term>
		/// </item>
		/// <item>
		/// <term>ERROR_NO_SUCH_MEMBER</term>
		/// <term>One or more of the members doesn't exist. The local group membership was not changed.</term>
		/// </item>
		/// <item>
		/// <term>ERROR_INVALID_MEMBER</term>
		/// <term>
		/// One or more of the members cannot be added because it has an invalid account type. The local group membership was not changed.
		/// </term>
		/// </item>
		/// </list>
		/// </returns>
		/// <remarks>
		/// <para>
		/// If you call this function on a domain controller that is running Active Directory, access is allowed or denied based on the
		/// access control list (ACL) for the securable object. The default ACL permits only Domain Admins and Account Operators to call this
		/// function. On a member server or workstation, only Administrators and Power Users can call this function. For more information,
		/// see Security Requirements for the Network Management Functions. For more information on ACLs, ACEs, and access tokens, see Access
		/// Control Model.
		/// </para>
		/// <para>The security descriptor of the LocalGroup object is used to perform the access check for this function.</para>
		/// <para>
		/// You can replace the local group membership with an entirely new list of members by calling the <c>NetLocalGroupSetMembers</c>
		/// function. The typical sequence of steps to perform this follows.
		/// </para>
		/// <para><c>To replace the local group membership</c></para>
		/// <list type="number">
		/// <item>
		/// <term>Call the NetLocalGroupGetMembers function to retrieve the current membership list.</term>
		/// </item>
		/// <item>
		/// <term>Modify the returned membership list to reflect the new membership.</term>
		/// </item>
		/// <item>
		/// <term>Call the <c>NetLocalGroupSetMembers</c> function to replace the old membership list with the new membership list.</term>
		/// </item>
		/// </list>
		/// <para>
		/// To add one or more existing user accounts or global group accounts to an existing local group, you can call the
		/// NetLocalGroupAddMembers function. To remove one or more members from an existing local group, call the NetLocalGroupDelMembers function.
		/// </para>
		/// <para>
		/// User account names are limited to 20 characters and group names are limited to 256 characters. In addition, account names cannot
		/// be terminated by a period and they cannot include commas or any of the following printable characters: ", /, , [, ], :, |, &lt;,
		/// &gt;, +, =, ;, ?, *. Names also cannot include characters in the range 1-31, which are non-printable.
		/// </para>
		/// <para>
		/// If you are programming for Active Directory, you may be able to call certain Active Directory Service Interface (ADSI) methods to
		/// achieve the same functionality you can achieve by calling the network management local group functions. For more information, see IADsGroup.
		/// </para>
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows/desktop/api/lmaccess/nf-lmaccess-netlocalgroupsetmembers NET_API_STATUS NET_API_FUNCTION
		// NetLocalGroupSetMembers( LPCWSTR servername, LPCWSTR groupname, DWORD level, LPBYTE buf, DWORD totalentries );
		[DllImport(Lib.NetApi32, SetLastError = false, ExactSpelling = true, CharSet = CharSet.Unicode)]
		[PInvokeData("lmaccess.h", MSDNShortId = "4dce1e10-b74d-4d69-ac5a-12e7d9d84e5c")]
		public static extern Win32Error NetLocalGroupSetMembers([Optional] string servername, string groupname, uint level, IntPtr buf, uint totalentries);

		/// <summary>
		/// The <c>NetQueryDisplayInformation</c> function returns user account, computer, or group account information. Call this function
		/// to quickly enumerate account information for display in user interfaces.
		/// </summary>
		/// <param name="ServerName">
		/// Pointer to a constant string that specifies the DNS or NetBIOS name of the remote server on which the function is to execute. If
		/// this parameter is <c>NULL</c>, the local computer is used.
		/// </param>
		/// <param name="Level">
		/// <para>Specifies the information level of the data. This parameter can be one of the following values.</para>
		/// <list type="table">
		/// <listheader>
		/// <term>Value</term>
		/// <term>Meaning</term>
		/// </listheader>
		/// <item>
		/// <term>1</term>
		/// <term>Return user account information. The SortedBuffer parameter points to an array of NET_DISPLAY_USER structures.</term>
		/// </item>
		/// <item>
		/// <term>2</term>
		/// <term>Return individual computer information. The SortedBuffer parameter points to an array of NET_DISPLAY_MACHINE structures.</term>
		/// </item>
		/// <item>
		/// <term>3</term>
		/// <term>Return group account information. The SortedBuffer parameter points to an array of NET_DISPLAY_GROUP structures.</term>
		/// </item>
		/// </list>
		/// </param>
		/// <param name="Index">
		/// Specifies the index of the first entry for which to retrieve information. Specify zero to retrieve account information beginning
		/// with the first display information entry. For more information, see the following Remarks section.
		/// </param>
		/// <param name="EntriesRequested">
		/// Specifies the maximum number of entries for which to retrieve information. On Windows 2000 and later, each call to
		/// <c>NetQueryDisplayInformation</c> returns a maximum of 100 objects.
		/// </param>
		/// <param name="PreferredMaximumLength">
		/// Specifies the preferred maximum size, in bytes, of the system-allocated buffer returned in the SortedBuffer parameter. It is
		/// recommended that you set this parameter to MAX_PREFERRED_LENGTH.
		/// </param>
		/// <param name="ReturnedEntryCount">
		/// Pointer to a value that receives the number of entries in the buffer returned in the SortedBuffer parameter. If this parameter is
		/// zero, there are no entries with an index as large as that specified. Entries may be returned when the function's return value is
		/// either NERR_Success or ERROR_MORE_DATA.
		/// </param>
		/// <param name="SortedBuffer">
		/// Pointer to a buffer that receives a pointer to a system-allocated buffer that specifies a sorted list of the requested
		/// information. The format of this data depends on the value of the Level parameter. Because this buffer is allocated by the system,
		/// it must be freed using the NetApiBufferFree function. Note that you must free the buffer even if the function fails with
		/// ERROR_MORE_DATA. For more information, see the following Return Values section, and the topics Network Management Function
		/// Buffers and Network Management Function Buffer Lengths.
		/// </param>
		/// <returns>
		/// <para>If the function succeeds, the return value is NERR_Success.</para>
		/// <para>If the function fails, the return value is one of the following error codes.</para>
		/// <list type="table">
		/// <listheader>
		/// <term>Return code</term>
		/// <term>Description</term>
		/// </listheader>
		/// <item>
		/// <term>ERROR_ACCESS_DENIED</term>
		/// <term>The user does not have access to the requested information.</term>
		/// </item>
		/// <item>
		/// <term>ERROR_INVALID_LEVEL</term>
		/// <term>The Level parameter specifies an invalid value.</term>
		/// </item>
		/// <item>
		/// <term>ERROR_MORE_DATA</term>
		/// <term>
		/// More entries are available. That is, the last entry returned in the SortedBuffer parameter is not the last entry available. To
		/// retrieve additional entries, call NetQueryDisplayInformation again with the Index parameter set to the value returned in the
		/// next_index member of the last entry in SortedBuffer. Note that you should not use the value of the next_index member for any
		/// purpose except to retrieve more data with additional calls to NetQueryDisplayInformation.
		/// </term>
		/// </item>
		/// </list>
		/// </returns>
		/// <remarks>
		/// <para>
		/// If you call this function on a domain controller that is running Active Directory, access is allowed or denied based on the
		/// access control list (ACL) for the securable object. The default ACL permits all authenticated users and members of the
		/// "Pre-Windows 2000 compatible access" group to view the information. If you call this function on a member server or workstation,
		/// all authenticated users can view the information. For information about anonymous access and restricting anonymous access on
		/// these platforms, see Security Requirements for the Network Management Functions. For more information on ACLs, ACEs, and access
		/// tokens, see Access Control Model.
		/// </para>
		/// <para>
		/// The <c>NetQueryDisplayInformation</c> function only returns information to which the caller has Read access. The caller must have
		/// List Contents access to the Domain object, and Enumerate Entire SAM Domain access on the SAM Server object located in the System container.
		/// </para>
		/// <para>
		/// The <c>NetQueryDisplayInformation</c> and NetGetDisplayInformationIndex functions provide an efficient mechanism for enumerating
		/// user and group accounts. When possible, use these functions instead of the NetUserEnum function or the NetGroupEnum function.
		/// </para>
		/// <para>
		/// To enumerate trusting domains or member computer accounts, call NetUserEnum, specifying the appropriate filter value to obtain
		/// the account information you require. To enumerate trusted domains, call the LsaEnumerateTrustedDomains or
		/// LsaEnumerateTrustedDomainsEx function.
		/// </para>
		/// <para>
		/// The number of entries returned by this function depends on the security descriptor located on the root domain object. The API
		/// will return either the first 100 entries or the entire set of entries in the domain, depending on the access privileges of the
		/// user. The ACE used to control this behavior is "SAM-Enumerate-Entire-Domain", and is granted to Authenticated Users by default.
		/// Administrators can modify this setting to allow users to enumerate the entire domain.
		/// </para>
		/// <para>
		/// Each call to <c>NetQueryDisplayInformation</c> returns a maximum of 100 objects. Calling the <c>NetQueryDisplayInformation</c>
		/// function to enumerate domain account information can be costly in terms of performance. If you are programming for Active
		/// Directory, you may be able to use methods on the IDirectorySearch interface to make paged queries against the domain. For more
		/// information, see IDirectorySearch::SetSearchPreference and IDirectorySearch::ExecuteSearch. To enumerate trusted domains, call
		/// the LsaEnumerateTrustedDomainsEx function.
		/// </para>
		/// <para>Examples</para>
		/// <para>
		/// The following code sample demonstrates how to return group account information using a call to the
		/// <c>NetQueryDisplayInformation</c> function. If the user specifies a server name, the sample first calls the MultiByteToWideChar
		/// function to convert the name to Unicode. The sample calls <c>NetQueryDisplayInformation</c>, specifying information level 3
		/// (NET_DISPLAY_GROUP) to retrieve group account information. If there are entries to return, the sample returns the data and prints
		/// the group information. Finally, the code sample frees the memory allocated for the information buffer.
		/// </para>
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows/desktop/api/lmaccess/nf-lmaccess-netquerydisplayinformation NET_API_STATUS
		// NET_API_FUNCTION NetQueryDisplayInformation( IN LPCWSTR ServerName, IN DWORD Level, IN DWORD Index, IN DWORD EntriesRequested, IN
		// DWORD PreferredMaximumLength, OUT LPDWORD ReturnedEntryCount, OUT PVOID *SortedBuffer );
		[DllImport(Lib.NetApi32, SetLastError = false, ExactSpelling = true, CharSet = CharSet.Unicode)]
		[PInvokeData("lmaccess.h", MSDNShortId = "049f1ea3-4d23-4b35-8b08-7256859aed45")]
		public static extern Win32Error NetQueryDisplayInformation([Optional] string ServerName, uint Level, uint Index, uint EntriesRequested, uint PreferredMaximumLength, out uint ReturnedEntryCount, out SafeNetApiBuffer SortedBuffer);

		/// <summary>Gets information about the specified managed service account.</summary>
		/// <param name="ServerName">The value of this parameter must be <c>NULL</c>.</param>
		/// <param name="AccountName">The name of the account to be created.</param>
		/// <param name="InfoLevel">
		/// <para>Specifies the format of the data returned in the Buffer parameter. This can be the following value.</para>
		/// <list type="table">
		/// <listheader>
		/// <term>Value</term>
		/// <term>Meaning</term>
		/// </listheader>
		/// <item>
		/// <term>0</term>
		/// <term>The Buffer parameter contains an MSA_INFO_0 structure.</term>
		/// </item>
		/// </list>
		/// </param>
		/// <param name="Buffer">
		/// <para>Information about the specified service account.</para>
		/// <para>When you have finished using this buffer, free it by calling the NetApiBufferFree function.</para>
		/// </param>
		/// <returns>
		/// <para>If the function succeeds, it returns <c>STATUS_SUCCESS</c>.</para>
		/// <para>If the function fails, it returns an error code.</para>
		/// </returns>
		// https://docs.microsoft.com/en-us/windows/desktop/api/lmaccess/nf-lmaccess-netqueryserviceaccount NTSTATUS NetQueryServiceAccount(
		// LPWSTR ServerName, LPWSTR AccountName, DWORD InfoLevel, PBYTE *Buffer );
		[DllImport(Lib.NetApi32, SetLastError = false, ExactSpelling = true, CharSet = CharSet.Unicode)]
		[PInvokeData("lmaccess.h", MSDNShortId = "ee253cab-bd53-426e-809a-12a1ccdc010b")]
		public static extern NTStatus NetQueryServiceAccount([Optional] string ServerName, string AccountName, uint InfoLevel, out SafeNetApiBuffer Buffer);

		/// <summary>
		/// <para>
		/// The <c>NetRemoveServiceAccount</c> function deletes the specified service account from the Active Directory database if the
		/// account is a standalone managed service account (sMSA). For group managed service accounts (gMSAs), this function does not delete
		/// the account from the Active Directory database. The secret stored in the Local Security Authority (LSA) is deleted for both sMSAs
		/// and gMSAs, and the state is stored in the Netlogon registry store.
		/// </para>
		/// <para>
		/// This function has no associated import library. You must use the LoadLibrary and GetProcAddress functions to dynamically link to Logoncli.dll.
		/// </para>
		/// </summary>
		/// <param name="ServerName">The value of this parameter must be <c>NULL</c>.</param>
		/// <param name="AccountName">The name of the account to be deleted.</param>
		/// <param name="Flags">
		/// <para>This parameter can have the following value.</para>
		/// <list type="table">
		/// <listheader>
		/// <term>Value</term>
		/// <term>Meaning</term>
		/// </listheader>
		/// <item>
		/// <term>SERVICE_ACCOUNT_FLAG_UNLINK_FROM_HOST_ONLY 0x00000001</term>
		/// <term>
		/// For sMSAs, the service account object is unlinked from the local computer and the secret stored in the LSA is deleted. The
		/// service account object is not deleted from the Active Directory database. This flag has no meaning for gMSAs.
		/// </term>
		/// </item>
		/// </list>
		/// </param>
		/// <returns>
		/// <para>If the function succeeds, it returns <c>STATUS_SUCCESS</c>.</para>
		/// <para>If the function fails, it returns an error code.</para>
		/// </returns>
		// https://docs.microsoft.com/en-us/windows/desktop/api/lmaccess/nf-lmaccess-netremoveserviceaccount NTSTATUS
		// NetRemoveServiceAccount( LPWSTR ServerName, LPWSTR AccountName, DWORD Flags );
		[DllImport(Lib.NetApi32, SetLastError = false, ExactSpelling = true, CharSet = CharSet.Unicode)]
		[PInvokeData("lmaccess.h", MSDNShortId = "f67745b7-bdfd-44bc-83e0-2ad24b78e137")]
		public static extern NTStatus NetRemoveServiceAccount([Optional] string ServerName, string AccountName, SvcAcctRemFlag Flags);

		/// <summary>The <c>NetUserAdd</c> function adds a user account and assigns a password and privilege level.</summary>
		/// <param name="servername">
		/// <para>
		/// Pointer to a constant string that specifies the DNS or NetBIOS name of the remote server on which the function is to execute. If
		/// this parameter is <c>NULL</c>, the local computer is used.
		/// </para>
		/// <para>This string is Unicode if <c>_WIN32_WINNT</c> or <c>FORCE_UNICODE</c> are defined.</para>
		/// </param>
		/// <param name="level">
		/// <para>Specifies the information level of the data. This parameter can be one of the following values.</para>
		/// <list type="table">
		/// <listheader>
		/// <term>Value</term>
		/// <term>Meaning</term>
		/// </listheader>
		/// <item>
		/// <term>1</term>
		/// <term>
		/// Specifies information about the user account. The buf parameter points to a USER_INFO_1 structure. When you specify this level,
		/// the call initializes certain attributes to their default values. For more information, see the following Remarks section.
		/// </term>
		/// </item>
		/// <item>
		/// <term>2</term>
		/// <term>
		/// Specifies level one information and additional attributes about the user account. The buf parameter points to a USER_INFO_2 structure.
		/// </term>
		/// </item>
		/// <item>
		/// <term>3</term>
		/// <term>
		/// Specifies level two information and additional attributes about the user account. This level is valid only on servers. The buf
		/// parameter points to a USER_INFO_3 structure. Note that it is recommended that you use USER_INFO_4 instead.
		/// </term>
		/// </item>
		/// <item>
		/// <term>4</term>
		/// <term>
		/// Specifies level two information and additional attributes about the user account. This level is valid only on servers. The buf
		/// parameter points to a USER_INFO_4 structure. Windows 2000: This level is not supported.
		/// </term>
		/// </item>
		/// </list>
		/// </param>
		/// <param name="buf">
		/// Pointer to the buffer that specifies the data. The format of this data depends on the value of the level parameter. For more
		/// information, see Network Management Function Buffers.
		/// </param>
		/// <param name="parm_err">
		/// Pointer to a value that receives the index of the first member of the user information structure that causes
		/// ERROR_INVALID_PARAMETER. If this parameter is <c>NULL</c>, the index is not returned on error. For more information, see the
		/// NetUserSetInfo function.
		/// </param>
		/// <returns>
		/// <para>If the function succeeds, the return value is NERR_Success.</para>
		/// <para>If the function fails, the return value can be one of the following error codes.</para>
		/// <list type="table">
		/// <listheader>
		/// <term>Return code</term>
		/// <term>Description</term>
		/// </listheader>
		/// <item>
		/// <term>ERROR_ACCESS_DENIED</term>
		/// <term>The user does not have access to the requested information.</term>
		/// </item>
		/// <item>
		/// <term>NERR_InvalidComputer</term>
		/// <term>The computer name is invalid.</term>
		/// </item>
		/// <item>
		/// <term>NERR_NotPrimary</term>
		/// <term>The operation is allowed only on the primary domain controller of the domain.</term>
		/// </item>
		/// <item>
		/// <term>NERR_GroupExists</term>
		/// <term>The group already exists.</term>
		/// </item>
		/// <item>
		/// <term>NERR_UserExists</term>
		/// <term>The user account already exists.</term>
		/// </item>
		/// <item>
		/// <term>NERR_PasswordTooShort</term>
		/// <term>
		/// The password is shorter than required. (The password could also be too long, be too recent in its change history, not have enough
		/// unique characters, or not meet another password policy requirement.)
		/// </term>
		/// </item>
		/// </list>
		/// </returns>
		/// <remarks>
		/// <para>
		/// If you are programming for Active Directory, you may be able to call certain Active Directory Service Interface (ADSI) methods to
		/// achieve the same functionality you can achieve by calling the network management user functions. For more information, see
		/// IADsUser and IADsComputer.
		/// </para>
		/// <para>
		/// If you call this function on a domain controller that is running Active Directory, access is allowed or denied based on the
		/// access control list (ACL) for the securable object. The default ACL permits only Domain Admins and Account Operators to call this
		/// function. On a member server or workstation, only Administrators and Power Users can call this function. For more information,
		/// see Security Requirements for the Network Management Functions. For more information on ACLs, ACEs, and access tokens, see Access
		/// Control Model.
		/// </para>
		/// <para>
		/// The security descriptor of the user container is used to perform the access check for this function. The caller must be able to
		/// create child objects of the user class.
		/// </para>
		/// <para>
		/// Server users must use a system in which the server creates a system account for the new user. The creation of this account is
		/// controlled by several parameters in the server's LanMan.ini file.
		/// </para>
		/// <para>
		/// If the newly added user already exists as a system user, the <c>usri1_home_dir</c> member of the USER_INFO_1 structure is ignored.
		/// </para>
		/// <para>
		/// When you call the <c>NetUserAdd</c> function and specify information level 1, the call initializes the additional members in the
		/// USER_INFO_2, USER_INFO_3, and USER_INFO_4 structures to their default values. You can change the default values by making
		/// subsequent calls to the NetUserSetInfo function. The default values supplied are listed following. (The prefix usriX indicates
		/// that the member can begin with multiple prefixes, for example, usri2_ or usri4_.)
		/// </para>
		/// <list type="table">
		/// <listheader>
		/// <term>Member</term>
		/// <term>Default Value</term>
		/// </listheader>
		/// <item>
		/// <term>usriX_auth_flags</term>
		/// <term>None (0)</term>
		/// </item>
		/// <item>
		/// <term>usriX_full_name</term>
		/// <term>None (null string)</term>
		/// </item>
		/// <item>
		/// <term>usriX_usr_comment</term>
		/// <term>None (null string)</term>
		/// </item>
		/// <item>
		/// <term>usriX_parms</term>
		/// <term>None (null string)</term>
		/// </item>
		/// <item>
		/// <term>usriX_workstations</term>
		/// <term>All (null string)</term>
		/// </item>
		/// <item>
		/// <term>usriX_acct_expires</term>
		/// <term>Never (TIMEQ_FOREVER)</term>
		/// </item>
		/// <item>
		/// <term>usriX_max_storage</term>
		/// <term>Unlimited (USER_MAXSTORAGE_UNLIMITED)</term>
		/// </item>
		/// <item>
		/// <term>usriX_logon_hours</term>
		/// <term>Logon allowed at any time (each element 0xFF; all bits set to 1)</term>
		/// </item>
		/// <item>
		/// <term>usriX_logon_server</term>
		/// <term>Any domain controller (\\*)</term>
		/// </item>
		/// <item>
		/// <term>usriX_country_code</term>
		/// <term>0</term>
		/// </item>
		/// <item>
		/// <term>usriX_code_page</term>
		/// <term>0</term>
		/// </item>
		/// </list>
		/// <para>
		/// User account names are limited to 20 characters and group names are limited to 256 characters. In addition, account names cannot
		/// be terminated by a period and they cannot include commas or any of the following printable characters: ", /, , [, ], :, |, &lt;,
		/// &gt;, +, =, ;, ?, *. Names also cannot include characters in the range 1-31, which are non-printable.
		/// </para>
		/// <para>Examples</para>
		/// <para>
		/// The following code sample demonstrates how to add a user account and assign a privilege level using a call to the
		/// <c>NetUserAdd</c> function. The code sample fills in the members of the USER_INFO_1 structure and calls <c>NetUserAdd</c>,
		/// specifying information level 1.
		/// </para>
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows/desktop/api/lmaccess/nf-lmaccess-netuseradd NET_API_STATUS NET_API_FUNCTION NetUserAdd(
		// LPCWSTR servername, DWORD level, LPBYTE buf, LPDWORD parm_err );
		[DllImport(Lib.NetApi32, SetLastError = false, ExactSpelling = true, CharSet = CharSet.Unicode)]
		[PInvokeData("lmaccess.h", MSDNShortId = "b5ca5f76-d40b-4abf-925a-0de54fc476e4")]
		public static extern Win32Error NetUserAdd([Optional] string servername, uint level, IntPtr buf, out uint parm_err);

		/// <summary>The <c>NetUserChangePassword</c> function changes a user's password for a specified network server or domain.</summary>
		/// <param name="domainname">
		/// A pointer to a constant string that specifies the DNS or NetBIOS name of a remote server or domain on which the function is to
		/// execute. If this parameter is <c>NULL</c>, the logon domain of the caller is used.
		/// </param>
		/// <param name="username">
		/// <para>
		/// A pointer to a constant string that specifies a user name. The <c>NetUserChangePassword</c> function changes the password for the
		/// specified user.
		/// </para>
		/// <para>
		/// If this parameter is <c>NULL</c>, the logon name of the caller is used. For more information, see the following Remarks section.
		/// </para>
		/// </param>
		/// <param name="oldpassword">A pointer to a constant string that specifies the user's old password.</param>
		/// <param name="newpassword">A pointer to a constant string that specifies the user's new password.</param>
		/// <returns>
		/// <para>If the function succeeds, the return value is NERR_Success.</para>
		/// <para>If the function fails, the return value can be one of the following error codes.</para>
		/// <list type="table">
		/// <listheader>
		/// <term>Return code</term>
		/// <term>Description</term>
		/// </listheader>
		/// <item>
		/// <term>ERROR_ACCESS_DENIED</term>
		/// <term>The user does not have access to the requested information.</term>
		/// </item>
		/// <item>
		/// <term>ERROR_INVALID_PASSWORD</term>
		/// <term>The user has entered an invalid password.</term>
		/// </item>
		/// <item>
		/// <term>NERR_InvalidComputer</term>
		/// <term>The computer name is invalid.</term>
		/// </item>
		/// <item>
		/// <term>NERR_NotPrimary</term>
		/// <term>The operation is allowed only on the primary domain controller of the domain.</term>
		/// </item>
		/// <item>
		/// <term>NERR_UserNotFound</term>
		/// <term>The user name could not be found.</term>
		/// </item>
		/// <item>
		/// <term>NERR_PasswordTooShort</term>
		/// <term>
		/// The password is shorter than required. (The password could also be too long, be too recent in its change history, not have enough
		/// unique characters, or not meet another password policy requirement.)
		/// </term>
		/// </item>
		/// </list>
		/// </returns>
		/// <remarks>
		/// <para>
		/// If you are programming for Active Directory, you may be able to call certain Active Directory Service Interface (ADSI) methods to
		/// achieve the same result you can achieve by calling the network management user functions. For more information, see IADsUser and IADsComputer.
		/// </para>
		/// <para>
		/// If an application calls the <c>NetUserChangePassword</c> function on a domain controller that is running Active Directory, access
		/// is allowed or denied based on the access control list (ACL) for the securable object. The default ACL permits only Domain Admins
		/// and Account Operators to call this function. On a member server or workstation, only Administrators and Power Users can call this
		/// function. A user can change his or her own password. For more information, see Security Requirements for the Network Management
		/// Functions. For more information on ACLs, ACEs, and access tokens, see Access Control Model.
		/// </para>
		/// <para>
		/// The security descriptor of the User object is used to perform the access check for this function. In addition, the caller must
		/// have the "Change password" control access right on the User object. This right is granted to Anonymous Logon and Everyone by default.
		/// </para>
		/// <para>Note that for the function to succeed, the oldpassword parameter must match the password as it currently exists.</para>
		/// <para>
		/// In some cases, the process that calls the <c>NetUserChangePassword</c> function must also have the SE_CHANGE_NOTIFY_NAME
		/// privilege enabled; otherwise, <c>NetUserChangePassword</c> fails and GetLastError returns ERROR_ACCESS_DENIED. This privilege is
		/// not required for the LocalSystem account or for accounts that are members of the administrators group. By default,
		/// SE_CHANGE_NOTIFY_NAME is enabled for all users, but some administrators may disable the privilege for everyone. For more
		/// information about account privileges, see Privileges and Authorization Constants.
		/// </para>
		/// <para>
		/// See Forcing a User to Change the Logon Password for a code sample that demonstrates how to force a user to change the logon
		/// password on the next logon using the NetUserGetInfo and NetUserSetInfo functions.
		/// </para>
		/// <para>
		/// User account names are limited to 20 characters and group names are limited to 256 characters. In addition, account names cannot
		/// be terminated by a period and they cannot include commas or any of the following printable characters: ", /, , [, ], :, |, &lt;,
		/// &gt;, +, =, ;, ?, *. Names also cannot include characters in the range 1-31, which are non-printable.
		/// </para>
		/// <para>
		/// The <c>NetUserChangePassword</c> function does not control how the oldpassword and newpassword parameters are secured when sent
		/// over the network to a remote server. Any encryption of these parameters is handled by the Remote Procedure Call (RPC) mechanism
		/// supported by the network redirector that provides the network transport. Encryption is also controlled by the security mechanisms
		/// supported by the local computer and the security mechanisms supported by remote network server or domain specified in the
		/// domainname parameter. For more details on security when the Microsoft network redirector is used and the remote network server is
		/// running Microsoft Windows, see the protocol documentation for MS-RPCE, MS-SAMR, MS-SPNG, and MS-NLMP.
		/// </para>
		/// <para>Examples</para>
		/// <para>
		/// The following code sample demonstrates how to change a user's password with a call to the <c>NetUserChangePassword</c> function.
		/// All parameters to the function are required.
		/// </para>
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows/desktop/api/lmaccess/nf-lmaccess-netuserchangepassword NET_API_STATUS NET_API_FUNCTION
		// NetUserChangePassword( IN LPCWSTR domainname, IN LPCWSTR username, IN LPCWSTR oldpassword, IN LPCWSTR newpassword );
		[DllImport(Lib.NetApi32, SetLastError = true, ExactSpelling = true, CharSet = CharSet.Unicode)]
		[PInvokeData("lmaccess.h", MSDNShortId = "e3791756-3bd4-490b-983a-9687373d846b")]
		public static extern Win32Error NetUserChangePassword([Optional] string domainname, [Optional] string username, string oldpassword, string newpassword);

		/// <summary>The <c>NetUserDel</c> function deletes a user account from a server.</summary>
		/// <param name="servername">
		/// Pointer to a constant string that specifies the DNS or NetBIOS name of the remote server on which the function is to execute. If
		/// this parameter is <c>NULL</c>, the local computer is used.
		/// </param>
		/// <param name="username">
		/// Pointer to a constant string that specifies the name of the user account to delete. For more information, see the following
		/// Remarks section.
		/// </param>
		/// <returns>
		/// <para>If the function succeeds, the return value is NERR_Success.</para>
		/// <para>If the function fails, the return value can be one of the following error codes.</para>
		/// <list type="table">
		/// <listheader>
		/// <term>Return code</term>
		/// <term>Description</term>
		/// </listheader>
		/// <item>
		/// <term>ERROR_ACCESS_DENIED</term>
		/// <term>The user does not have access to the requested information.</term>
		/// </item>
		/// <item>
		/// <term>NERR_InvalidComputer</term>
		/// <term>The computer name is invalid.</term>
		/// </item>
		/// <item>
		/// <term>NERR_NotPrimary</term>
		/// <term>The operation is allowed only on the primary domain controller of the domain.</term>
		/// </item>
		/// <item>
		/// <term>NERR_UserNotFound</term>
		/// <term>The user name could not be found.</term>
		/// </item>
		/// </list>
		/// </returns>
		/// <remarks>
		/// <para>
		/// If you are programming for Active Directory, you may be able to call certain Active Directory Service Interface (ADSI) methods to
		/// achieve the same functionality you can achieve by calling the network management user functions. For more information, see
		/// IADsUser and IADsComputer.
		/// </para>
		/// <para>
		/// If you call this function on a domain controller that is running Active Directory, access is allowed or denied based on the
		/// access control list (ACL) for the securable object. The default ACL permits only Domain Admins and Account Operators to call this
		/// function. On a member server or workstation, only Administrators and Power Users can call this function. For more information,
		/// see Security Requirements for the Network Management Functions. For more information on ACLs, ACEs, and access tokens, see Access
		/// Control Model.
		/// </para>
		/// <para>The security descriptor of the User object is used to perform the access check for this function.</para>
		/// <para>
		/// An account cannot be deleted while a user or application is accessing a server resource. If the user was added to the system with
		/// a call to the NetUserAdd function, deleting the user also deletes the user's system account.
		/// </para>
		/// <para>
		/// User account names are limited to 20 characters and group names are limited to 256 characters. In addition, account names cannot
		/// be terminated by a period and they cannot include commas or any of the following printable characters: ", /, , [, ], :, |, &lt;,
		/// &gt;, +, =, ;, ?, *. Names also cannot include characters in the range 1-31, which are non-printable.
		/// </para>
		/// <para>Examples</para>
		/// <para>The following code sample demonstrates how to delete a user account with a call to the <c>NetUserDel</c> function.</para>
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows/desktop/api/lmaccess/nf-lmaccess-netuserdel NET_API_STATUS NET_API_FUNCTION NetUserDel(
		// LPCWSTR servername, LPCWSTR username );
		[DllImport(Lib.NetApi32, SetLastError = false, ExactSpelling = true, CharSet = CharSet.Unicode)]
		[PInvokeData("lmaccess.h", MSDNShortId = "c1429b82-4fd1-48b6-8957-04dee0426077")]
		public static extern Win32Error NetUserDel([Optional] string servername, string username);

		/// <summary>The <c>NetUserEnum</c> function retrieves information about all user accounts on a server.</summary>
		/// <param name="servername">
		/// A pointer to a constant string that specifies the DNS or NetBIOS name of the remote server on which the function is to execute.
		/// If this parameter is <c>NULL</c>, the local computer is used.
		/// </param>
		/// <param name="level">
		/// <para>Specifies the information level of the data. This parameter can be one of the following values.</para>
		/// <list type="table">
		/// <listheader>
		/// <term>Value</term>
		/// <term>Meaning</term>
		/// </listheader>
		/// <item>
		/// <term>0</term>
		/// <term>Return user account names. The bufptr parameter points to an array of USER_INFO_0 structures.</term>
		/// </item>
		/// <item>
		/// <term>1</term>
		/// <term>Return detailed information about user accounts. The bufptr parameter points to an array of USER_INFO_1 structures.</term>
		/// </item>
		/// <item>
		/// <term>2</term>
		/// <term>
		/// Return detailed information about user accounts, including authorization levels and logon information. The bufptr parameter
		/// points to an array of USER_INFO_2 structures.
		/// </term>
		/// </item>
		/// <item>
		/// <term>3</term>
		/// <term>
		/// Return detailed information about user accounts, including authorization levels, logon information, RIDs for the user and the
		/// primary group, and profile information. The bufptr parameter points to an array of USER_INFO_3 structures.
		/// </term>
		/// </item>
		/// <item>
		/// <term>10</term>
		/// <term>Return user and account names and comments. The bufptr parameter points to an array of USER_INFO_10 structures.</term>
		/// </item>
		/// <item>
		/// <term>11</term>
		/// <term>Return detailed information about user accounts. The bufptr parameter points to an array of USER_INFO_11 structures.</term>
		/// </item>
		/// <item>
		/// <term>20</term>
		/// <term>
		/// Return the user's name and identifier and various account attributes. The bufptr parameter points to an array of USER_INFO_20
		/// structures. Note that on Windows XP and later, it is recommended that you use USER_INFO_23 instead.
		/// </term>
		/// </item>
		/// </list>
		/// </param>
		/// <param name="filter">
		/// <para>
		/// A value that specifies the user account types to be included in the enumeration. A value of zero indicates that all normal user,
		/// trust data, and machine account data should be included.
		/// </para>
		/// <para>This parameter can also be a combination of the following values.</para>
		/// <list type="table">
		/// <listheader>
		/// <term>Value</term>
		/// <term>Meaning</term>
		/// </listheader>
		/// <item>
		/// <term>FILTER_TEMP_DUPLICATE_ACCOUNT</term>
		/// <term>
		/// Enumerates account data for users whose primary account is in another domain. This account type provides user access to this
		/// domain, but not to any domain that trusts this domain. The User Manager refers to this account type as a local user account.
		/// </term>
		/// </item>
		/// <item>
		/// <term>FILTER_NORMAL_ACCOUNT</term>
		/// <term>Enumerates normal user account data. This account type is associated with a typical user.</term>
		/// </item>
		/// <item>
		/// <term>FILTER_INTERDOMAIN_TRUST_ACCOUNT</term>
		/// <term>
		/// Enumerates interdomain trust account data. This account type is associated with a trust account for a domain that trusts other domains.
		/// </term>
		/// </item>
		/// <item>
		/// <term>FILTER_WORKSTATION_TRUST_ACCOUNT</term>
		/// <term>
		/// Enumerates workstation or member server trust account data. This account type is associated with a machine account for a computer
		/// that is a member of the domain.
		/// </term>
		/// </item>
		/// <item>
		/// <term>FILTER_SERVER_TRUST_ACCOUNT</term>
		/// <term>
		/// Enumerates member server machine account data. This account type is associated with a computer account for a backup domain
		/// controller that is a member of the domain.
		/// </term>
		/// </item>
		/// </list>
		/// </param>
		/// <param name="bufptr">
		/// <para>A pointer to the buffer that receives the data. The format of this data depends on the value of the level parameter.</para>
		/// <para>
		/// The buffer for this data is allocated by the system and the application must call the NetApiBufferFree function to free the
		/// allocated memory when the data returned is no longer needed. Note that you must free the buffer even if the <c>NetUserEnum</c>
		/// function fails with ERROR_MORE_DATA.
		/// </para>
		/// </param>
		/// <param name="prefmaxlen">
		/// The preferred maximum length, in bytes, of the returned data. If you specify MAX_PREFERRED_LENGTH, the <c>NetUserEnum</c>
		/// function allocates the amount of memory required for the data. If you specify another value in this parameter, it can restrict
		/// the number of bytes that the function returns. If the buffer size is insufficient to hold all entries, the function returns
		/// ERROR_MORE_DATA. For more information, see Network Management Function Buffers and Network Management Function Buffer Lengths.
		/// </param>
		/// <param name="entriesread">A pointer to a value that receives the count of elements actually enumerated.</param>
		/// <param name="totalentries">
		/// <para>
		/// A pointer to a value that receives the total number of entries that could have been enumerated from the current resume position.
		/// Note that applications should consider this value only as a hint. If your application is communicating with a Windows 2000 or
		/// later domain controller, you should consider using the ADSI LDAP Provider to retrieve this type of data more efficiently. The
		/// ADSI LDAP Provider implements a set of ADSI objects that support various ADSI interfaces. For more information, see ADSI Service Providers.
		/// </para>
		/// <para>
		/// <c>LAN Manager:</c> If the call is to a computer that is running LAN Manager 2.x, the totalentries parameter will always reflect
		/// the total number of entries in the database no matter where it is in the resume sequence.
		/// </para>
		/// </param>
		/// <param name="resume_handle">
		/// A pointer to a value that contains a resume handle which is used to continue an existing user search. The handle should be zero
		/// on the first call and left unchanged for subsequent calls. If this parameter is <c>NULL</c>, then no resume handle is stored.
		/// </param>
		/// <returns>
		/// <para>If the function succeeds, the return value is NERR_Success.</para>
		/// <para>If the function fails, the return value can be one of the following error codes.</para>
		/// <list type="table">
		/// <listheader>
		/// <term>Return code</term>
		/// <term>Description</term>
		/// </listheader>
		/// <item>
		/// <term>ERROR_ACCESS_DENIED</term>
		/// <term>The user does not have access to the requested information.</term>
		/// </item>
		/// <item>
		/// <term>ERROR_INVALID_LEVEL</term>
		/// <term>The system call level is not correct. This error is returned if the level parameter is set to a value not supported.</term>
		/// </item>
		/// <item>
		/// <term>NERR_BufTooSmall</term>
		/// <term>The buffer is too small to contain an entry. No information has been written to the buffer.</term>
		/// </item>
		/// <item>
		/// <term>NERR_InvalidComputer</term>
		/// <term>The computer name is invalid.</term>
		/// </item>
		/// <item>
		/// <term>ERROR_MORE_DATA</term>
		/// <term>More entries are available. Specify a large enough buffer to receive all entries.</term>
		/// </item>
		/// </list>
		/// </returns>
		/// <remarks>
		/// <para>
		/// The <c>NetUserEnum</c> function retrieves information about all user accounts on a specified remote server or the local computer.
		/// </para>
		/// <para>
		/// The NetQueryDisplayInformation function can be used to quickly enumerate user, computer, or global group account information for
		/// display in user interfaces .
		/// </para>
		/// <para>
		/// If you are programming for Active Directory, you may be able to call certain Active Directory Service Interface (ADSI) methods to
		/// achieve the same functionality you can achieve by calling the network management user functions. For more information, see
		/// IADsUser and IADsComputer.
		/// </para>
		/// <para>
		/// If you call the <c>NetUserEnum</c> function on a domain controller that is running Active Directory, access is allowed or denied
		/// based on the access control list (ACL) for the securable object. The default ACL permits all authenticated users and members of
		/// the "Pre-Windows 2000 compatible access" group to view the information. If you call this function on a member server or
		/// workstation, all authenticated users can view the information. For information about anonymous access and restricting anonymous
		/// access on these platforms, see Security Requirements for the Network Management Functions. For more information on ACLs, ACEs,
		/// and access tokens, see Access Control Model.
		/// </para>
		/// <para>
		/// The <c>NetUserEnum</c> function only returns information to which the caller has Read access. The caller must have List Contents
		/// access to the Domain object, and Enumerate Entire SAM Domain access on the SAM Server object located in the System container.
		/// </para>
		/// <para>
		/// The LsaEnumerateTrustedDomains or LsaEnumerateTrustedDomainsEx function can be used to retrieve the names and SIDs of domains
		/// trusted by a Local Security Authority (LSA) policy object.
		/// </para>
		/// <para>
		/// The <c>NetUserEnum</c> function does not return all system users. It returns only those users who have been added with a call to
		/// the NetUserAdd function. There is no guarantee that the list of users will be returned in sorted order.
		/// </para>
		/// <para>
		/// If you call the <c>NetUserEnum</c> function and specify information level 1, 2, or 3, for the level parameter, the password
		/// member of each structure retrieved is set to <c>NULL</c> to maintain password security.
		/// </para>
		/// <para>
		/// User account names are limited to 20 characters and group names are limited to 256 characters. In addition, account names cannot
		/// be terminated by a period and they cannot include commas or any of the following printable characters: ", /, , [, ], :, |, &lt;,
		/// &gt;, +, =, ;, ?, *. Names also cannot include characters in the range 1-31, which are non-printable.
		/// </para>
		/// <para>
		/// The <c>NetUserEnum</c> function does not support a level parameter of 4 and the USER_INFO_4 structure. The NetUserGetInfo
		/// function supports a level parameter of 4 and the <c>USER_INFO_4</c> structure.
		/// </para>
		/// <para>Examples</para>
		/// <para>
		/// The following code sample demonstrates how to retrieve information about the user accounts on a server with a call to the
		/// <c>NetUserEnum</c> function. The sample calls <c>NetUserEnum</c>, specifying information level 0 (USER_INFO_0) to enumerate only
		/// global user accounts. If the call succeeds, the code loops through the entries and prints the name of each user account. Finally,
		/// the code sample frees the memory allocated for the information buffer and prints a total of the users enumerated.
		/// </para>
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows/desktop/api/lmaccess/nf-lmaccess-netuserenum NET_API_STATUS NET_API_FUNCTION NetUserEnum(
		// LPCWSTR servername, DWORD level, DWORD filter, LPBYTE *bufptr, DWORD prefmaxlen, LPDWORD entriesread, LPDWORD totalentries, PDWORD
		// resume_handle );
		[DllImport(Lib.NetApi32, SetLastError = false, ExactSpelling = true, CharSet = CharSet.Unicode)]
		[PInvokeData("lmaccess.h", MSDNShortId = "b26ef3c0-934a-4840-8c06-4eaff5c9ff86")]
		public static extern Win32Error NetUserEnum([Optional] string servername, uint level, UserEnumFilter filter, out SafeNetApiBuffer bufptr, uint prefmaxlen, out uint entriesread, out uint totalentries, ref uint resume_handle);

		/// <summary>The <c>NetUserGetGroups</c> function retrieves a list of global groups to which a specified user belongs.</summary>
		/// <param name="servername">
		/// A pointer to a constant string that specifies the DNS or NetBIOS name of the remote server on which the function is to execute.
		/// If this parameter is <c>NULL</c>, the local computer is used.
		/// </param>
		/// <param name="username">
		/// A pointer to a constant string that specifies the name of the user to search for in each group account. For more information, see
		/// the following Remarks section.
		/// </param>
		/// <param name="level">
		/// <para>The information level of the data requested. This parameter can be one of the following values.</para>
		/// <list type="table">
		/// <listheader>
		/// <term>Value</term>
		/// <term>Meaning</term>
		/// </listheader>
		/// <item>
		/// <term>0</term>
		/// <term>
		/// Return the names of the global groups to which the user belongs. The bufptr parameter points to an array of GROUP_USERS_INFO_0 structures.
		/// </term>
		/// </item>
		/// <item>
		/// <term>1</term>
		/// <term>
		/// Return the names of the global groups to which the user belongs with attributes. The bufptr parameter points to an array of
		/// GROUP_USERS_INFO_1 structures.
		/// </term>
		/// </item>
		/// </list>
		/// </param>
		/// <param name="bufptr">
		/// A pointer to the buffer that receives the data. This buffer is allocated by the system and must be freed using the
		/// NetApiBufferFree function. Note that you must free the buffer even if the function fails with ERROR_MORE_DATA.
		/// </param>
		/// <param name="prefmaxlen">
		/// The preferred maximum length, in bytes, of returned data. If MAX_PREFERRED_LENGTH is specified, the function allocates the amount
		/// of memory required for the data. If another value is specified in this parameter, it can restrict the number of bytes that the
		/// function returns. If the buffer size is insufficient to hold all entries, the function returns ERROR_MORE_DATA. For more
		/// information, see Network Management Function Buffers and Network Management Function Buffer Lengths.
		/// </param>
		/// <param name="entriesread">A pointer to a value that receives the count of elements actually retrieved.</param>
		/// <param name="totalentries">A pointer to a value that receives the total number of entries that could have been retrieved.</param>
		/// <returns>
		/// <para>If the function succeeds, the return value is NERR_Success.</para>
		/// <para>If the function fails, the return value can be one of the following error codes.</para>
		/// <list type="table">
		/// <listheader>
		/// <term>Return code</term>
		/// <term>Description</term>
		/// </listheader>
		/// <item>
		/// <term>ERROR_ACCESS_DENIED</term>
		/// <term>The user does not have access rights to the requested information.</term>
		/// </item>
		/// <item>
		/// <term>ERROR_BAD_NETPATH</term>
		/// <term>The network path was not found. This error is returned if the servername parameter could not be found.</term>
		/// </item>
		/// <item>
		/// <term>ERROR_INVALID_LEVEL</term>
		/// <term>
		/// The system call level is not correct. This error is returned if the level parameter was specified as a value other than 0 or 1.
		/// </term>
		/// </item>
		/// <item>
		/// <term>ERROR_INVALID_NAME</term>
		/// <term>
		/// The name syntax is incorrect. This error is returned if the servername parameter has leading or trailing blanks or contains an
		/// illegal character.
		/// </term>
		/// </item>
		/// <item>
		/// <term>ERROR_MORE_DATA</term>
		/// <term>More entries are available. Specify a large enough buffer to receive all entries.</term>
		/// </item>
		/// <item>
		/// <term>ERROR_NOT_ENOUGH_MEMORY</term>
		/// <term>Insufficient memory was available to complete the operation.</term>
		/// </item>
		/// <item>
		/// <term>NERR_InternalError</term>
		/// <term>An internal error occurred.</term>
		/// </item>
		/// <item>
		/// <term>NERR_UserNotFound</term>
		/// <term>The user could not be found. This error is returned if the username could not be found.</term>
		/// </item>
		/// </list>
		/// </returns>
		/// <remarks>
		/// <para>
		/// If you are programming for Active Directory, you may be able to call certain Active Directory Service Interface (ADSI) methods to
		/// achieve the same functionality you can achieve by calling the network management user functions. For more information, see
		/// IADsUser and IADsComputer.
		/// </para>
		/// <para>
		/// If you call this function on a domain controller that is running Active Directory, access is allowed or denied based on the
		/// access control list (ACL) for the securable object. The default ACL permits all authenticated users and members of the
		/// "Pre-Windows 2000 compatible access" group to view the information. If you call this function on a member server or workstation,
		/// all authenticated users can view the information. For information about anonymous access and restricting anonymous access on
		/// these platforms, see Security Requirements for the Network Management Functions. For more information on ACLs, ACEs, and access
		/// tokens, see Access Control Model.
		/// </para>
		/// <para>The security descriptor of the User object is used to perform the access check for this function.</para>
		/// <para>
		/// To retrieve a list of the local groups to which a user belongs, you can call the NetUserGetLocalGroups function. Network groups
		/// are separate and distinct from Windows NT system groups.
		/// </para>
		/// <para>
		/// User account names are limited to 20 characters and group names are limited to 256 characters. In addition, account names cannot
		/// be terminated by a period and they cannot include commas or any of the following printable characters: ", /, , [, ], :, |, &lt;,
		/// &gt;, +, =, ;, ?, *. Names also cannot include characters in the range 1-31, which are non-printable.
		/// </para>
		/// <para>Examples</para>
		/// <para>
		/// The following code sample demonstrates how to retrieve a list of global groups to which a user belongs with a call to the
		/// <c>NetUserGetGroups</c> function. The sample calls <c>NetUserGetGroups</c>, specifying information level 0 ( GROUP_USERS_INFO_0).
		/// The code loops through the entries and prints the name of the global groups in which the user has membership. The sample also
		/// prints the total number of entries that are available and the number of entries actually enumerated if they do not match.
		/// Finally, the code sample frees the memory allocated for the buffer.
		/// </para>
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows/desktop/api/lmaccess/nf-lmaccess-netusergetgroups NET_API_STATUS NET_API_FUNCTION
		// NetUserGetGroups( LPCWSTR servername, LPCWSTR username, DWORD level, LPBYTE *bufptr, DWORD prefmaxlen, LPDWORD entriesread,
		// LPDWORD totalentries );
		[DllImport(Lib.NetApi32, SetLastError = false, ExactSpelling = true, CharSet = CharSet.Unicode)]
		[PInvokeData("lmaccess.h", MSDNShortId = "ecf1a94c-5dda-4f49-81bd-93e551e089f1")]
		public static extern Win32Error NetUserGetGroups([Optional] string servername, string username, uint level, out SafeNetApiBuffer bufptr, uint prefmaxlen, out uint entriesread, out uint totalentries);

		/// <summary>The <c>NetUserGetInfo</c> function retrieves information about a particular user account on a server.</summary>
		/// <param name="servername">
		/// A pointer to a constant string that specifies the DNS or NetBIOS name of the remote server on which the function is to execute.
		/// If this parameter is <c>NULL</c>, the local computer is used.
		/// </param>
		/// <param name="username">
		/// A pointer to a constant string that specifies the name of the user account for which to return information. For more information,
		/// see the following Remarks section.
		/// </param>
		/// <param name="level">
		/// <para>The information level of the data. This parameter can be one of the following values.</para>
		/// <list type="table">
		/// <listheader>
		/// <term>Value</term>
		/// <term>Meaning</term>
		/// </listheader>
		/// <item>
		/// <term>0</term>
		/// <term>Return the user account name. The bufptr parameter points to a USER_INFO_0 structure.</term>
		/// </item>
		/// <item>
		/// <term>1</term>
		/// <term>Return detailed information about the user account. The bufptr parameter points to a USER_INFO_1 structure.</term>
		/// </item>
		/// <item>
		/// <term>2</term>
		/// <term>
		/// Return detailed information and additional attributes about the user account. The bufptr parameter points to a USER_INFO_2 structure.
		/// </term>
		/// </item>
		/// <item>
		/// <term>3</term>
		/// <term>
		/// Return detailed information and additional attributes about the user account. This level is valid only on servers. The bufptr
		/// parameter points to a USER_INFO_3 structure. Note that it is recommended that you use USER_INFO_4 instead.
		/// </term>
		/// </item>
		/// <item>
		/// <term>4</term>
		/// <term>
		/// Return detailed information and additional attributes about the user account. This level is valid only on servers. The bufptr
		/// parameter points to a USER_INFO_4 structure.
		/// </term>
		/// </item>
		/// <item>
		/// <term>10</term>
		/// <term>Return user and account names and comments. The bufptr parameter points to a USER_INFO_10 structure.</term>
		/// </item>
		/// <item>
		/// <term>11</term>
		/// <term>Return detailed information about the user account. The bufptr parameter points to a USER_INFO_11 structure.</term>
		/// </item>
		/// <item>
		/// <term>20</term>
		/// <term>
		/// Return the user's name and identifier and various account attributes. The bufptr parameter points to a USER_INFO_20 structure.
		/// Note that on Windows XP and later, it is recommended that you use USER_INFO_23 instead.
		/// </term>
		/// </item>
		/// <item>
		/// <term>23</term>
		/// <term>Return the user's name and identifier and various account attributes. The bufptr parameter points to a USER_INFO_23 structure.</term>
		/// </item>
		/// <item>
		/// <term>24</term>
		/// <term>
		/// Return user account information for accounts which are connected to an Internet identity. The bufptr parameter points to a
		/// USER_INFO_24 structure.
		/// </term>
		/// </item>
		/// </list>
		/// </param>
		/// <param name="bufptr">
		/// A pointer to the buffer that receives the data. The format of this data depends on the value of the level parameter. This buffer
		/// is allocated by the system and must be freed using the NetApiBufferFree function. For more information, see Network Management
		/// Function Buffers and Network Management Function Buffer Lengths.
		/// </param>
		/// <returns>
		/// <para>If the function succeeds, the return value is NERR_Success.</para>
		/// <para>If the function fails, the return value can be one of the following error codes.</para>
		/// <list type="table">
		/// <listheader>
		/// <term>Return code</term>
		/// <term>Description</term>
		/// </listheader>
		/// <item>
		/// <term>ERROR_ACCESS_DENIED</term>
		/// <term>The user does not have access to the requested information.</term>
		/// </item>
		/// <item>
		/// <term>ERROR_BAD_NETPATH</term>
		/// <term>The network path specified in the servername parameter was not found.</term>
		/// </item>
		/// <item>
		/// <term>ERROR_INVALID_LEVEL</term>
		/// <term>The value specified for the level parameter is invalid.</term>
		/// </item>
		/// <item>
		/// <term>NERR_InvalidComputer</term>
		/// <term>The computer name is invalid.</term>
		/// </item>
		/// <item>
		/// <term>NERR_UserNotFound</term>
		/// <term>The user name could not be found.</term>
		/// </item>
		/// </list>
		/// </returns>
		/// <remarks>
		/// <para>
		/// If you are programming for Active Directory, you may be able to call certain Active Directory Service Interface (ADSI) methods to
		/// achieve the same functionality you can achieve by calling the network management user functions. For more information, see
		/// IADsUser and IADsComputer.
		/// </para>
		/// <para>
		/// If you call this function on a domain controller that is running Active Directory, access is allowed or denied based on the
		/// access control list (ACL) for the securable object. The default ACL permits all authenticated users and members of the
		/// "Pre-Windows 2000 compatible access" group to view the information. If you call this function on a member server or workstation,
		/// all authenticated users can view the information. For information about anonymous access and restricting anonymous access on
		/// these platforms, see Security Requirements for the Network Management Functions. For more information on ACLs, ACEs, and access
		/// tokens, see Access Control Model.
		/// </para>
		/// <para>The security descriptor of the User object is used to perform the access check for this function.</para>
		/// <para>
		/// User account names are limited to 20 characters and group names are limited to 256 characters. In addition, account names cannot
		/// be terminated by a period and they cannot include commas or any of the following printable characters: ", /, , [, ], :, |, &lt;,
		/// &gt;, +, =, ;, ?, *. Names also cannot include characters in the range 1-31, which are non-printable.
		/// </para>
		/// <para>
		/// If the information level specified in the level parameter is set to 24, the servername parameter specified must resolve to the
		/// local computer. If the servername resolves to a remote computer or to a domain controller, the <c>NetUserGetInfo</c> function
		/// will fail.
		/// </para>
		/// <para>Examples</para>
		/// <para>
		/// The following code sample demonstrates how to retrieve information about a particular user account with a call to the
		/// <c>NetUserGetInfo</c> function. The sample calls <c>NetUserGetInfo</c>, specifying various information levels . If the call
		/// succeeds, the code prints information about the user account. Finally, the sample frees the memory allocated for the information buffer.
		/// </para>
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows/desktop/api/lmaccess/nf-lmaccess-netusergetinfo NET_API_STATUS NET_API_FUNCTION
		// NetUserGetInfo( LPCWSTR servername, LPCWSTR username, DWORD level, LPBYTE *bufptr );
		[DllImport(Lib.NetApi32, SetLastError = true, ExactSpelling = true, CharSet = CharSet.Unicode)]
		[PInvokeData("lmaccess.h", MSDNShortId = "5bd13bed-938a-4273-840e-99fca99f7139")]
		public static extern Win32Error NetUserGetInfo([Optional] string servername, string username, uint level, out SafeNetApiBuffer bufptr);

		/// <summary>The <c>NetUserGetLocalGroups</c> function retrieves a list of local groups to which a specified user belongs.</summary>
		/// <param name="servername">
		/// A pointer to a constant string that specifies the DNS or NetBIOS name of the remote server on which the function is to execute.
		/// If this parameter is <c>NULL</c>, the local computer is used.
		/// </param>
		/// <param name="username">
		/// A pointer to a constant string that specifies the name of the user for which to return local group membership information. If the
		/// string is of the form DomainName&lt;i&gt;UserName the user name is expected to be found on that domain. If the string is of the
		/// form UserName, the user name is expected to be found on the server specified by the servername parameter. For more information,
		/// see the Remarks section.
		/// </param>
		/// <param name="level">
		/// <para>The information level of the data. This parameter can be the following value.</para>
		/// <list type="table">
		/// <listheader>
		/// <term>Value</term>
		/// <term>Meaning</term>
		/// </listheader>
		/// <item>
		/// <term>0</term>
		/// <term>
		/// Return the names of the local groups to which the user belongs. The bufptr parameter points to an array of
		/// LOCALGROUP_USERS_INFO_0 structures.
		/// </term>
		/// </item>
		/// </list>
		/// </param>
		/// <param name="flags">
		/// A bitmask of flags that affect the operation. Currently, only the value defined is <c>LG_INCLUDE_INDIRECT</c>. If this bit is
		/// set, the function also returns the names of the local groups in which the user is indirectly a member (that is, the user has
		/// membership in a global group that is itself a member of one or more local groups).
		/// </param>
		/// <param name="bufptr">
		/// A pointer to the buffer that receives the data. The format of this data depends on the value of the level parameter. This buffer
		/// is allocated by the system and must be freed using the NetApiBufferFree function. Note that you must free the buffer even if the
		/// function fails with <c>ERROR_MORE_DATA</c>.
		/// </param>
		/// <param name="prefmaxlen">
		/// The preferred maximum length, in bytes, of the returned data. If <c>MAX_PREFERRED_LENGTH</c> is specified in this parameter, the
		/// function allocates the amount of memory required for the data. If another value is specified in this parameter, it can restrict
		/// the number of bytes that the function returns. If the buffer size is insufficient to hold all entries, the function returns
		/// <c>ERROR_MORE_DATA</c>. For more information, see Network Management Function Buffers and Network Management Function Buffer Lengths.
		/// </param>
		/// <param name="entriesread">A pointer to a value that receives the count of elements actually enumerated.</param>
		/// <param name="totalentries">A pointer to a value that receives the total number of entries that could have been enumerated.</param>
		/// <returns>
		/// <para>If the function succeeds, the return value is NERR_Success.</para>
		/// <para>If the function fails, the return value can be one of the following error codes.</para>
		/// <list type="table">
		/// <listheader>
		/// <term>Return code</term>
		/// <term>Description</term>
		/// </listheader>
		/// <item>
		/// <term>ERROR_ACCESS_DENIED</term>
		/// <term>
		/// The user does not have access rights to the requested information. This error is also returned if the servername parameter has a
		/// trailing blank.
		/// </term>
		/// </item>
		/// <item>
		/// <term>ERROR_INVALID_LEVEL</term>
		/// <term>The system call level is not correct. This error is returned if the level parameter was not specified as 0.</term>
		/// </item>
		/// <item>
		/// <term>ERROR_INVALID_PARAMETER</term>
		/// <term>A parameter is incorrect. This error is returned if the flags parameter contains a value other than LG_INCLUDE_INDIRECT.</term>
		/// </item>
		/// <item>
		/// <term>ERROR_MORE_DATA</term>
		/// <term>More entries are available. Specify a large enough buffer to receive all entries.</term>
		/// </item>
		/// <item>
		/// <term>ERROR_NOT_ENOUGH_MEMORY</term>
		/// <term>Insufficient memory was available to complete the operation.</term>
		/// </item>
		/// <item>
		/// <term>NERR_DCNotFound</term>
		/// <term>The domain controller could not be found.</term>
		/// </item>
		/// <item>
		/// <term>NERR_UserNotFound</term>
		/// <term>The user could not be found. This error is returned if the username could not be found.</term>
		/// </item>
		/// <item>
		/// <term>RPC_S_SERVER_UNAVAILABLE</term>
		/// <term>The RPC server is unavailable. This error is returned if the servername parameter could not be found.</term>
		/// </item>
		/// </list>
		/// </returns>
		/// <remarks>
		/// <para>
		/// If you are programming for Active Directory, you may be able to call certain Active Directory Service Interface (ADSI) methods to
		/// achieve the same functionality you can achieve by calling the network management user functions. For more information, see
		/// IADsUser and IADsComputer.
		/// </para>
		/// <para>
		/// If you call this function on a domain controller that is running Active Directory, access is allowed or denied based on the
		/// access control list (ACL) for the securable object. The default ACL permits all authenticated users and members of the
		/// "Pre-Windows 2000 compatible access" group to view the information. If you call this function on a member server or workstation,
		/// all authenticated users can view the information. For information about anonymous access and restricting anonymous access on
		/// these platforms, see Security Requirements for the Network Management Functions. For more information on ACLs, ACEs, and access
		/// tokens, see Access Control Model.
		/// </para>
		/// <para>
		/// The security descriptor of the Domain object is used to perform the access check for this function. The caller must have Read
		/// Property permission on the Domain object.
		/// </para>
		/// <para>To retrieve a list of global groups to which a specified user belongs, you can call the NetUserGetGroups function.</para>
		/// <para>
		/// User account names are limited to 20 characters and group names are limited to 256 characters. In addition, account names cannot
		/// be terminated by a period and they cannot include commas or any of the following printable characters: ", /, , [, ], :, |, &lt;,
		/// &gt;, +, =, ;, ?, *. Names also cannot include characters in the range 1-31, which are non-printable.
		/// </para>
		/// <para>Examples</para>
		/// <para>
		/// The following code sample demonstrates how to retrieve a list of the local groups to which a user belongs with a call to the
		/// <c>NetUserGetLocalGroups</c> function. The sample calls <c>NetUserGetLocalGroups</c>, specifying information level 0
		/// (LOCALGROUP_USERS_INFO_0). The sample loops through the entries and prints the name of each local group in which the user has
		/// membership. If all available entries are not enumerated, it also prints the number of entries actually enumerated and the total
		/// number of entries available. Finally, the code sample frees the memory allocated for the information buffer.
		/// </para>
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows/desktop/api/lmaccess/nf-lmaccess-netusergetlocalgroups NET_API_STATUS NET_API_FUNCTION
		// NetUserGetLocalGroups( LPCWSTR servername, LPCWSTR username, DWORD level, DWORD flags, LPBYTE *bufptr, DWORD prefmaxlen, LPDWORD
		// entriesread, LPDWORD totalentries );
		[DllImport(Lib.NetApi32, SetLastError = false, ExactSpelling = true, CharSet = CharSet.Unicode)]
		[PInvokeData("lmaccess.h", MSDNShortId = "cc5c1c15-cad7-4103-a2c9-1a8adf742703")]
		public static extern Win32Error NetUserGetLocalGroups([Optional] string servername, string username, uint level, GetLocalGroupFlags flags, out SafeNetApiBuffer bufptr, uint prefmaxlen, out uint entriesread, out uint totalentries);

		/// <summary>
		/// The <c>NetUserModalsGet</c> function retrieves global information for all users and global groups in the security database, which
		/// is the security accounts manager (SAM) database or, in the case of domain controllers, the Active Directory.
		/// </summary>
		/// <param name="servername">
		/// A pointer to a constant string that specifies the DNS or NetBIOS name of the remote server on which the function is to execute.
		/// If this parameter is <c>NULL</c>, the local computer is used. For more information, see the following Remarks section.
		/// </param>
		/// <param name="level">
		/// <para>The information level of the data requested. This parameter can be one of the following values.</para>
		/// <list type="table">
		/// <listheader>
		/// <term>Value</term>
		/// <term>Meaning</term>
		/// </listheader>
		/// <item>
		/// <term>0</term>
		/// <term>Return global password parameters. The bufptr parameter points to a USER_MODALS_INFO_0 structure.</term>
		/// </item>
		/// <item>
		/// <term>1</term>
		/// <term>Return logon server and domain controller information. The bufptr parameter points to a USER_MODALS_INFO_1 structure.</term>
		/// </item>
		/// <item>
		/// <term>2</term>
		/// <term>
		/// Return domain name and identifier. The bufptr parameter points to a USER_MODALS_INFO_2 structure. For more information, see the
		/// following Remarks section.
		/// </term>
		/// </item>
		/// <item>
		/// <term>3</term>
		/// <term>Return lockout information. The bufptr parameter points to a USER_MODALS_INFO_3 structure.</term>
		/// </item>
		/// </list>
		/// <para>A null session logon can call <c>NetUserModalsGet</c> anonymously at information levels 0 and 3.</para>
		/// </param>
		/// <param name="bufptr">
		/// <para>A pointer to the buffer that receives the data. The format of this data depends on the value of the level parameter.</para>
		/// <para>
		/// The buffer for this data is allocated by the system and the application must call the NetApiBufferFree function to free the
		/// allocated memory when the data returned is no longer needed. For more information, see Network Management Function Buffers and
		/// Network Management Function Buffer Lengths.
		/// </para>
		/// </param>
		/// <returns>
		/// <para>If the function succeeds, the return value is NERR_Success.</para>
		/// <para>If the function fails, the return value can be one of the following error codes.</para>
		/// <list type="table">
		/// <listheader>
		/// <term>Return code</term>
		/// <term>Description</term>
		/// </listheader>
		/// <item>
		/// <term>ERROR_ACCESS_DENIED</term>
		/// <term>The user does not have access to the requested information.</term>
		/// </item>
		/// <item>
		/// <term>ERROR_BAD_NETPATH</term>
		/// <term>The network path was not found. This error is returned if the servername parameter could not be found.</term>
		/// </item>
		/// <item>
		/// <term>ERROR_INVALID_LEVEL</term>
		/// <term>The system call level is not correct. This error is returned if the level parameter is not one of the supported values.</term>
		/// </item>
		/// <item>
		/// <term>ERROR_INVALID_NAME</term>
		/// <term>
		/// The file name, directory name, or volume label syntax is incorrect. This error is returned if the servername parameter syntax is incorrect.
		/// </term>
		/// </item>
		/// <item>
		/// <term>ERROR_WRONG_TARGET_NAME</term>
		/// <term>
		/// The target account name is incorrect. This error is returned for a logon failure to a remote servername parameter running on
		/// Windows Vista.
		/// </term>
		/// </item>
		/// <item>
		/// <term>NERR_InvalidComputer</term>
		/// <term>The computer name is invalid.</term>
		/// </item>
		/// </list>
		/// </returns>
		/// <remarks>
		/// <para>
		/// If you are programming for Active Directory, you may be able to call certain Active Directory Service Interface (ADSI) methods to
		/// achieve the same functionality you can achieve by calling the network management user modal functions. For more information, see IADsDomain.
		/// </para>
		/// <para>
		/// If you call this function on a domain controller that is running Active Directory, access is allowed or denied based on the
		/// access control list (ACL) for the securable object. The default ACL permits all authenticated users and members of the
		/// "Pre-Windows 2000 compatible access" group to view the information. If you call this function on a member server or workstation,
		/// all authenticated users can view the information. For information about anonymous access and restricting anonymous access on
		/// these platforms, see Security Requirements for the Network Management Functions. For more information on ACLs, ACEs, and access
		/// tokens, see Access Control Model.
		/// </para>
		/// <para>The security descriptor of the Domain object is used to perform the access check for this function.</para>
		/// <para>
		/// To retrieve the security identifier (SID) of the domain to which the computer belongs, call the <c>NetUserModalsGet</c> function
		/// specifying a USER_MODALS_INFO_2 structure and <c>NULL</c> in the servername parameter. If the computer isn't a member of a
		/// domain, the function returns a <c>NULL</c> pointer.
		/// </para>
		/// <para>Examples</para>
		/// <para>
		/// The following code sample demonstrates how to retrieve global information for all users and global groups with a call to the
		/// <c>NetUserModalsGet</c> function. The sample calls <c>NetUserModalsGet</c>, specifying information level 0 (USER_MODALS_INFO_0).
		/// If the call succeeds, the sample prints global password information. Finally, the code sample frees the memory allocated for the
		/// information buffer.
		/// </para>
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows/desktop/api/lmaccess/nf-lmaccess-netusermodalsget NET_API_STATUS NET_API_FUNCTION
		// NetUserModalsGet( LPCWSTR servername, DWORD level, LPBYTE *bufptr );
		[DllImport(Lib.NetApi32, SetLastError = false, ExactSpelling = true, CharSet = CharSet.Unicode)]
		[PInvokeData("lmaccess.h", MSDNShortId = "5bb18144-82a6-4e9b-8321-c06a667bdd03")]
		public static extern Win32Error NetUserModalsGet([Optional] string servername, uint level, out SafeNetApiBuffer bufptr);

		/// <summary>
		/// The <c>NetUserModalsSet</c> function sets global information for all users and global groups in the security database, which is
		/// the security accounts manager (SAM) database or, in the case of domain controllers, the Active Directory.
		/// </summary>
		/// <param name="servername">
		/// Pointer to a constant string that specifies the DNS or NetBIOS name of the remote server on which the function is to execute. If
		/// this parameter is <c>NULL</c>, the local computer is used.
		/// </param>
		/// <param name="level">
		/// <para>Specifies the information level of the data. This parameter can be one of the following values.</para>
		/// <list type="table">
		/// <listheader>
		/// <term>Value</term>
		/// <term>Meaning</term>
		/// </listheader>
		/// <item>
		/// <term>0</term>
		/// <term>Specifies global password parameters. The buf parameter points to a USER_MODALS_INFO_0 structure.</term>
		/// </item>
		/// <item>
		/// <term>1</term>
		/// <term>Specifies logon server and domain controller information. The buf parameter points to a USER_MODALS_INFO_1 structure.</term>
		/// </item>
		/// <item>
		/// <term>2</term>
		/// <term>Specifies the domain name and identifier. The buf parameter points to a USER_MODALS_INFO_2 structure.</term>
		/// </item>
		/// <item>
		/// <term>3</term>
		/// <term>Specifies lockout information. The buf parameter points to a USER_MODALS_INFO_3 structure.</term>
		/// </item>
		/// <item>
		/// <term>1001</term>
		/// <term>Specifies the minimum allowable password length. The buf parameter points to a USER_MODALS_INFO_1001 structure.</term>
		/// </item>
		/// <item>
		/// <term>1002</term>
		/// <term>Specifies the maximum allowable password age. The buf parameter points to a USER_MODALS_INFO_1002 structure.</term>
		/// </item>
		/// <item>
		/// <term>1003</term>
		/// <term>Specifies the minimum allowable password age. The buf parameter points to a USER_MODALS_INFO_1003 structure.</term>
		/// </item>
		/// <item>
		/// <term>1004</term>
		/// <term>Specifies forced logoff information. The buf parameter points to a USER_MODALS_INFO_1004 structure.</term>
		/// </item>
		/// <item>
		/// <term>1005</term>
		/// <term>Specifies the length of the password history. The buf parameter points to a USER_MODALS_INFO_1005 structure.</term>
		/// </item>
		/// <item>
		/// <term>1006</term>
		/// <term>Specifies the role of the logon server. The buf parameter points to a USER_MODALS_INFO_1006 structure.</term>
		/// </item>
		/// <item>
		/// <term>1007</term>
		/// <term>Specifies domain controller information. The buf parameter points to a USER_MODALS_INFO_1007 structure.</term>
		/// </item>
		/// </list>
		/// </param>
		/// <param name="buf">
		/// Pointer to the buffer that specifies the data. The format of this data depends on the value of the level parameter. For more
		/// information, see Network Management Function Buffers.
		/// </param>
		/// <param name="parm_err">
		/// Pointer to a value that receives the index of the first member of the information structure that causes ERROR_INVALID_PARAMETER.
		/// If this parameter is <c>NULL</c>, the index is not returned on error. For more information, see the following Remarks section.
		/// </param>
		/// <returns>
		/// <para>If the function succeeds, the return value is NERR_Success.</para>
		/// <para>If the function fails, the return value can be one of the following error codes.</para>
		/// <list type="table">
		/// <listheader>
		/// <term>Return code</term>
		/// <term>Description</term>
		/// </listheader>
		/// <item>
		/// <term>ERROR_ACCESS_DENIED</term>
		/// <term>The user does not have access to the requested information.</term>
		/// </item>
		/// <item>
		/// <term>ERROR_INVALID_PARAMETER</term>
		/// <term>The specified parameter is invalid. For more information, see the following Remarks section.</term>
		/// </item>
		/// <item>
		/// <term>NERR_InvalidComputer</term>
		/// <term>The computer name is invalid.</term>
		/// </item>
		/// <item>
		/// <term>NERR_UserNotFound</term>
		/// <term>The user name could not be found.</term>
		/// </item>
		/// </list>
		/// </returns>
		/// <remarks>
		/// <para>
		/// If you are programming for Active Directory, you may be able to call certain Active Directory Service Interface (ADSI) methods to
		/// achieve the same functionality you can achieve by calling the network management user modal functions. For more information, see IADsDomain.
		/// </para>
		/// <para>
		/// If you call this function on a domain controller that is running Active Directory, access is allowed or denied based on the
		/// access control list (ACL) for the securable object. The default ACL permits only Domain Admins and Account Operators to call this
		/// function. On a member server or workstation, only Administrators and Power Users can call this function. For more information,
		/// see Security Requirements for the Network Management Functions. For more information on ACLs, ACEs, and access tokens, see Access
		/// Control Model.
		/// </para>
		/// <para>
		/// The security descriptor of the Domain object is used to perform the access check for this function. Typically, callers must have
		/// write access to the entire object for calls to this function to succeed.
		/// </para>
		/// <para>
		/// If the <c>NetUserModalsSet</c> function returns ERROR_INVALID_PARAMETER, you can use the parm_err parameter to indicate the first
		/// member of the information structure that is invalid. (The information structure begins with USER_MODALS_INFO_ and its format is
		/// specified by the level parameter.) The following table lists the values that can be returned in the parm_err parameter and the
		/// corresponding structure member that is in error. (The prefix usrmod*_ indicates that the member can begin with multiple prefixes,
		/// for example, usrmod2_ or usrmod1002_.)
		/// </para>
		/// <list type="table">
		/// <listheader>
		/// <term>Value</term>
		/// <term>Member</term>
		/// </listheader>
		/// <item>
		/// <term>MODALS_MIN_PASSWD_LEN_PARMNUM</term>
		/// <term>usrmod*_min_passwd_len</term>
		/// </item>
		/// <item>
		/// <term>MODALS_MAX_PASSWD_AGE_PARMNUM</term>
		/// <term>usrmod*_max_passwd_age</term>
		/// </item>
		/// <item>
		/// <term>MODALS_MIN_PASSWD_AGE_PARMNUM</term>
		/// <term>usrmod*_min_passwd_age</term>
		/// </item>
		/// <item>
		/// <term>MODALS_FORCE_LOGOFF_PARMNUM</term>
		/// <term>usrmod*_force_logoff</term>
		/// </item>
		/// <item>
		/// <term>MODALS_PASSWD_HIST_LEN_PARMNUM</term>
		/// <term>usrmod*_password_hist_len</term>
		/// </item>
		/// <item>
		/// <term>MODALS_ROLE_PARMNUM</term>
		/// <term>usrmod*_role</term>
		/// </item>
		/// <item>
		/// <term>MODALS_PRIMARY_PARMNUM</term>
		/// <term>usrmod*_primary</term>
		/// </item>
		/// <item>
		/// <term>MODALS_DOMAIN_NAME_PARMNUM</term>
		/// <term>usrmod*_domain_name</term>
		/// </item>
		/// <item>
		/// <term>MODALS_DOMAIN_ID_PARMNUM</term>
		/// <term>usrmod*_domain_id</term>
		/// </item>
		/// <item>
		/// <term>MODALS_LOCKOUT_DURATION_PARMNUM</term>
		/// <term>usrmod*_lockout_duration</term>
		/// </item>
		/// <item>
		/// <term>MODALS_LOCKOUT_OBSERVATION_WINDOW_PARMNUM</term>
		/// <term>usrmod*_lockout_observation_window</term>
		/// </item>
		/// <item>
		/// <term>MODALS_LOCKOUT_THRESHOLD_PARMNUM</term>
		/// <term>usrmod*_lockout_threshold</term>
		/// </item>
		/// </list>
		/// <para>Examples</para>
		/// <para>
		/// The following code sample demonstrates how to set the global information for all users and global groups with a call to the
		/// <c>NetUserModalsSet</c> function. The sample fills in the members of the USER_MODALS_INFO_0 structure and calls
		/// <c>NetUserModalsSet</c>, specifying information level 0.
		/// </para>
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows/desktop/api/lmaccess/nf-lmaccess-netusermodalsset NET_API_STATUS NET_API_FUNCTION
		// NetUserModalsSet( LPCWSTR servername, DWORD level, LPBYTE buf, LPDWORD parm_err );
		[DllImport(Lib.NetApi32, SetLastError = false, ExactSpelling = true, CharSet = CharSet.Unicode)]
		[PInvokeData("lmaccess.h", MSDNShortId = "9884e076-ee6a-4aca-abe6-a79754667759")]
		public static extern Win32Error NetUserModalsSet([Optional] string servername, uint level, IntPtr buf, out uint parm_err);

		/// <summary>The <c>NetUserSetGroups</c> function sets global group memberships for a specified user account.</summary>
		/// <param name="servername">
		/// A pointer to a constant string that specifies the DNS or NetBIOS name of the remote server on which the function is to execute.
		/// If this parameter is <c>NULL</c>, the local computer is used.
		/// </param>
		/// <param name="username">
		/// A pointer to a constant string that specifies the name of the user for which to set global group memberships. For more
		/// information, see the Remarks section.
		/// </param>
		/// <param name="level">
		/// <para>The information level of the data. This parameter can be one of the following values.</para>
		/// <list type="table">
		/// <listheader>
		/// <term>Value</term>
		/// <term>Meaning</term>
		/// </listheader>
		/// <item>
		/// <term>0</term>
		/// <term>The buf parameter points to an array of GROUP_USERS_INFO_0 structures that specifies global group names.</term>
		/// </item>
		/// <item>
		/// <term>1</term>
		/// <term>The buf parameter points to an array of GROUP_USERS_INFO_1 structures that specifies global group names with attributes.</term>
		/// </item>
		/// </list>
		/// </param>
		/// <param name="buf">A pointer to the buffer that specifies the data. For more information, see Network Management Function Buffers.</param>
		/// <param name="num_entries">The number of entries contained in the array pointed to by the buf parameter.</param>
		/// <returns>
		/// <para>If the function succeeds, the return value is NERR_Success.</para>
		/// <para>If the function fails, the return value can be one of the following error codes.</para>
		/// <list type="table">
		/// <listheader>
		/// <term>Return code</term>
		/// <term>Description</term>
		/// </listheader>
		/// <item>
		/// <term>ERROR_ACCESS_DENIED</term>
		/// <term>The user does not have access to the requested information.</term>
		/// </item>
		/// <item>
		/// <term>ERROR_INVALID_LEVEL</term>
		/// <term>
		/// The system call level is not correct. This error is returned if the level parameter was specified as a value other than 0 or 1.
		/// </term>
		/// </item>
		/// <item>
		/// <term>ERROR_INVALID_PARAMETER</term>
		/// <term>A parameter passed was not valid. This error is returned if the num_entries parameter was not valid.</term>
		/// </item>
		/// <item>
		/// <term>ERROR_NOT_ENOUGH_MEMORY</term>
		/// <term>Insufficient memory was available to complete the operation.</term>
		/// </item>
		/// <item>
		/// <term>NERR_InvalidComputer</term>
		/// <term>The computer name is invalid.</term>
		/// </item>
		/// <item>
		/// <term>NERR_NotPrimary</term>
		/// <term>The operation is allowed only on the primary domain controller of the domain.</term>
		/// </item>
		/// <item>
		/// <term>NERR_GroupNotFound</term>
		/// <term>
		/// The group group name specified by the grui0_name in the GROUP_USERS_INFO_0 structure or grui1_name member in the
		/// GROUP_USERS_INFO_1 structure pointed to by the buf parameter does not exist.
		/// </term>
		/// </item>
		/// <item>
		/// <term>NERR_InternalError</term>
		/// <term>An internal error occurred.</term>
		/// </item>
		/// <item>
		/// <term>NERR_UserNotFound</term>
		/// <term>The user name could not be found.</term>
		/// </item>
		/// </list>
		/// </returns>
		/// <remarks>
		/// <para>
		/// If you are programming for Active Directory, you may be able to call certain Active Directory Service Interface (ADSI) methods to
		/// achieve the same functionality you can achieve by calling the network management user functions. For more information, see
		/// IADsUser and IADsComputer.
		/// </para>
		/// <para>
		/// If you call this function on a domain controller that is running Active Directory, access is allowed or denied based on the
		/// access control list (ACL) for the securable object. The default ACL permits only Domain Admins and Account Operators to call this
		/// function. On a member server or workstation, only Administrators and Power Users can call this function. For more information,
		/// see Security Requirements for the Network Management Functions. For more information on ACLs, ACEs, and access tokens, see Access
		/// Control Model.
		/// </para>
		/// <para>The security descriptor of the User object is used to perform the access check for this function.</para>
		/// <para>To grant a user membership in one existing global group, you can call the NetGroupAddUser function.</para>
		/// <para>
		/// User account names are limited to 20 characters and group names are limited to 256 characters. In addition, account names cannot
		/// be terminated by a period and they cannot include commas or any of the following printable characters: ", /, , [, ], :, |, &lt;,
		/// &gt;, +, =, ;, ?, *. Names also cannot include characters in the range 1-31, which are non-printable.
		/// </para>
		/// <para>Examples</para>
		/// <para>
		/// The following code sample demonstrates how to set global group memberships for a user account with a call to the
		/// <c>NetUserSetGroups</c> function. The code sample fills in the <c>grui0_name</c> member of the GROUP_USERS_INFO_0 structure and
		/// calls <c>NetUserSetGroups</c>, specifying information level 0.
		/// </para>
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows/desktop/api/lmaccess/nf-lmaccess-netusersetgroups NET_API_STATUS NET_API_FUNCTION
		// NetUserSetGroups( LPCWSTR servername, LPCWSTR username, DWORD level, LPBYTE buf, DWORD num_entries );
		[DllImport(Lib.NetApi32, SetLastError = false, ExactSpelling = true, CharSet = CharSet.Unicode)]
		[PInvokeData("lmaccess.h", MSDNShortId = "7042c43a-09d1-4179-8074-eb055dc279a6")]
		public static extern Win32Error NetUserSetGroups([Optional] string servername, string username, uint level, IntPtr buf, uint num_entries);

		/// <summary>The <c>NetUserSetInfo</c> function sets the parameters of a user account.</summary>
		/// <param name="servername">
		/// A pointer to a constant string that specifies the DNS or NetBIOS name of the remote server on which the function is to execute.
		/// If this parameter is <c>NULL</c>, the local computer is used.
		/// </param>
		/// <param name="username">
		/// A pointer to a constant string that specifies the name of the user account for which to set information. For more information,
		/// see the following Remarks section.
		/// </param>
		/// <param name="level">
		/// <para>The information level of the data. This parameter can be one of the following values.</para>
		/// <list type="table">
		/// <listheader>
		/// <term>Value</term>
		/// <term>Meaning</term>
		/// </listheader>
		/// <item>
		/// <term>0</term>
		/// <term>
		/// Specifies the user account name. The buf parameter points to a USER_INFO_0 structure. Use this structure to specify a new group
		/// name. For more information, see the following Remarks section.
		/// </term>
		/// </item>
		/// <item>
		/// <term>1</term>
		/// <term>Specifies detailed information about the user account. The buf parameter points to a USER_INFO_1 structure.</term>
		/// </item>
		/// <item>
		/// <term>2</term>
		/// <term>
		/// Specifies level one information and additional attributes about the user account. The buf parameter points to a USER_INFO_2 structure.
		/// </term>
		/// </item>
		/// <item>
		/// <term>3</term>
		/// <term>
		/// Specifies level two information and additional attributes about the user account. This level is valid only on servers. The buf
		/// parameter points to a USER_INFO_3 structure. Note that it is recommended that you use USER_INFO_4 instead.
		/// </term>
		/// </item>
		/// <item>
		/// <term>4</term>
		/// <term>
		/// Specifies level two information and additional attributes about the user account. This level is valid only on servers. The buf
		/// parameter points to a USER_INFO_4 structure.
		/// </term>
		/// </item>
		/// <item>
		/// <term>21</term>
		/// <term>Specifies a one-way encrypted LAN Manager 2.x-compatible password. The buf parameter points to a USER_INFO_21 structure.</term>
		/// </item>
		/// <item>
		/// <term>22</term>
		/// <term>Specifies detailed information about the user account. The buf parameter points to a USER_INFO_22 structure.</term>
		/// </item>
		/// <item>
		/// <term>1003</term>
		/// <term>Specifies a user password. The buf parameter points to a USER_INFO_1003 structure.</term>
		/// </item>
		/// <item>
		/// <term>1005</term>
		/// <term>Specifies a user privilege level. The buf parameter points to a USER_INFO_1005 structure.</term>
		/// </item>
		/// <item>
		/// <term>1006</term>
		/// <term>Specifies the path of the home directory for the user. The buf parameter points to a USER_INFO_1006 structure.</term>
		/// </item>
		/// <item>
		/// <term>1007</term>
		/// <term>Specifies a comment to associate with the user account. The buf parameter points to a USER_INFO_1007 structure.</term>
		/// </item>
		/// <item>
		/// <term>1008</term>
		/// <term>Specifies user account attributes. The buf parameter points to a USER_INFO_1008 structure.</term>
		/// </item>
		/// <item>
		/// <term>1009</term>
		/// <term>Specifies the path for the user's logon script file. The buf parameter points to a USER_INFO_1009 structure.</term>
		/// </item>
		/// <item>
		/// <term>1010</term>
		/// <term>Specifies the user's operator privileges. The buf parameter points to a USER_INFO_1010 structure.</term>
		/// </item>
		/// <item>
		/// <term>1011</term>
		/// <term>Specifies the full name of the user. The buf parameter points to a USER_INFO_1011 structure.</term>
		/// </item>
		/// <item>
		/// <term>1012</term>
		/// <term>Specifies a comment to associate with the user. The buf parameter points to a USER_INFO_1012 structure.</term>
		/// </item>
		/// <item>
		/// <term>1014</term>
		/// <term>Specifies the names of workstations from which the user can log on. The buf parameter points to a USER_INFO_1014 structure.</term>
		/// </item>
		/// <item>
		/// <term>1017</term>
		/// <term>Specifies when the user account expires. The buf parameter points to a USER_INFO_1017 structure.</term>
		/// </item>
		/// <item>
		/// <term>1020</term>
		/// <term>Specifies the times during which the user can log on. The buf parameter points to a USER_INFO_1020 structure.</term>
		/// </item>
		/// <item>
		/// <term>1024</term>
		/// <term>Specifies the user's country/region code. The buf parameter points to a USER_INFO_1024 structure.</term>
		/// </item>
		/// <item>
		/// <term>1051</term>
		/// <term>
		/// Specifies the relative identifier of a global group that represents the enrolled user. The buf parameter points to a
		/// USER_INFO_1051 structure.
		/// </term>
		/// </item>
		/// <item>
		/// <term>1052</term>
		/// <term>Specifies the path to a network user's profile. The buf parameter points to a USER_INFO_1052 structure.</term>
		/// </item>
		/// <item>
		/// <term>1053</term>
		/// <term>Specifies the drive letter assigned to the user's home directory. The buf parameter points to a USER_INFO_1053 structure.</term>
		/// </item>
		/// </list>
		/// </param>
		/// <param name="buf">
		/// A pointer to the buffer that specifies the data. The format of this data depends on the value of the level parameter. For more
		/// information, see Network Management Function Buffers.
		/// </param>
		/// <param name="parm_err">
		/// A pointer to a value that receives the index of the first member of the user information structure that causes
		/// ERROR_INVALID_PARAMETER. If this parameter is <c>NULL</c>, the index is not returned on error. For more information, see the
		/// following Remarks section.
		/// </param>
		/// <returns>
		/// <para>If the function succeeds, the return value is NERR_Success.</para>
		/// <para>If the function fails, the return value can be one of the following error codes.</para>
		/// <list type="table">
		/// <listheader>
		/// <term>Return code</term>
		/// <term>Description</term>
		/// </listheader>
		/// <item>
		/// <term>ERROR_ACCESS_DENIED</term>
		/// <term>The user does not have access to the requested information.</term>
		/// </item>
		/// <item>
		/// <term>ERROR_INVALID_PARAMETER</term>
		/// <term>One of the function parameters is invalid. For more information, see the following Remarks section.</term>
		/// </item>
		/// <item>
		/// <term>NERR_InvalidComputer</term>
		/// <term>The computer name is invalid.</term>
		/// </item>
		/// <item>
		/// <term>NERR_NotPrimary</term>
		/// <term>The operation is allowed only on the primary domain controller of the domain.</term>
		/// </item>
		/// <item>
		/// <term>NERR_SpeGroupOp</term>
		/// <term>
		/// The operation is not allowed on specified special groups, which are user groups, admin groups, local groups, or guest groups.
		/// </term>
		/// </item>
		/// <item>
		/// <term>NERR_LastAdmin</term>
		/// <term>The operation is not allowed on the last administrative account.</term>
		/// </item>
		/// <item>
		/// <term>NERR_BadPassword</term>
		/// <term>The share name or password is invalid.</term>
		/// </item>
		/// <item>
		/// <term>NERR_PasswordTooShort</term>
		/// <term>
		/// The password is shorter than required. (The password could also be too long, be too recent in its change history, not have enough
		/// unique characters, or not meet another password policy requirement.)
		/// </term>
		/// </item>
		/// <item>
		/// <term>NERR_UserNotFound</term>
		/// <term>The user name could not be found.</term>
		/// </item>
		/// </list>
		/// </returns>
		/// <remarks>
		/// <para>
		/// If you are programming for Active Directory, you may be able to call certain Active Directory Service Interface (ADSI) methods to
		/// achieve the same functionality you can achieve by calling the network management user functions. For more information, see
		/// IADsUser and IADsComputer.
		/// </para>
		/// <para>
		/// If you call this function on a domain controller that is running Active Directory, access is allowed or denied based on the
		/// access control list (ACL) for the securable object. The default ACL permits only Domain Admins and Account Operators to call this
		/// function. On a member server or workstation, only Administrators and Power Users can call this function. For more information,
		/// see Security Requirements for the Network Management Functions. For more information on ACLs, ACEs, and access tokens, see Access
		/// Control Model.
		/// </para>
		/// <para>The security descriptor of the User object is used to perform the access check for this function.</para>
		/// <para>
		/// Only users or applications having administrative privileges can call the <c>NetUserSetInfo</c> function to change a user's
		/// password. When an administrator calls <c>NetUserSetInfo</c>, the only restriction applied is that the new password length must be
		/// consistent with system modals. A user or application that knows a user's current password can call the NetUserChangePassword
		/// function to change the password. For more information about calling functions that require administrator privileges, see Running
		/// with Special Privileges.
		/// </para>
		/// <para>
		/// Members of the Administrators local group can set any modifiable user account elements. All users can set the
		/// <c>usri2_country_code</c> member of the USER_INFO_2 structure (and the <c>usri1024_country_code</c> member of the USER_INFO_1024
		/// structure) for their own accounts.
		/// </para>
		/// <para>
		/// A member of the Account Operator's local group cannot set details for an Administrators class account, give an existing account
		/// Administrator privilege, or change the operator privilege of any account. If you attempt to change the privilege level or disable
		/// the last account with Administrator privilege in the security database, (the security accounts manager (SAM) database or, in the
		/// case of domain controllers, the Active Directory), the <c>NetUserSetInfo</c> function fails and returns NERR_LastAdmin.
		/// </para>
		/// <para>To set the following user account control flags, the following privileges and control access rights are required.</para>
		/// <list type="table">
		/// <listheader>
		/// <term>Account control flag</term>
		/// <term>Privilege or right required</term>
		/// </listheader>
		/// <item>
		/// <term>UF_TRUSTED_TO_AUTHENTICATE_FOR_DELEGATION</term>
		/// <term>SeEnableDelegationPrivilege privilege, which is granted to Administrators by default.</term>
		/// </item>
		/// <item>
		/// <term>UF_TRUSTED_FOR_DELEGATION</term>
		/// <term>SeEnableDelegationPrivilege.</term>
		/// </item>
		/// <item>
		/// <term>UF_PASSWD_NOTREQD</term>
		/// <term>"Update password not required" control access right on the Domain object, which is granted to authenticated users by default.</term>
		/// </item>
		/// <item>
		/// <term>UF_DONT_EXPIRE_PASSWD</term>
		/// <term>"Unexpire password" control access right on the Domain object, which is granted to authenticated users by default.</term>
		/// </item>
		/// <item>
		/// <term>UF_ENCRYPTED_TEXT_PASSWORD_ALLOWED</term>
		/// <term>
		/// "Enable per user reversibly encrypted password" control access right on the Domain object, which is granted to authenticated
		/// users by default.
		/// </term>
		/// </item>
		/// <item>
		/// <term>UF_SERVER_TRUST_ACCOUNT</term>
		/// <term>"Add/remove replica in domain" control access right on the Domain object, which is granted to Administrators by default.</term>
		/// </item>
		/// </list>
		/// <para>For a list of privilege constants, see Authorization Constants.</para>
		/// <para>
		/// The correct way to specify the new name for an account is to call <c>NetUserSetInfo</c> with USER_INFO_0 and to specify the new
		/// value using the <c>usri0_name</c> member. If you call <c>NetUserSetInfo</c> with other information levels and specify a value
		/// using a <c>usriX_name</c> member, the value is ignored.
		/// </para>
		/// <para>
		/// Note that calls to <c>NetUserSetInfo</c> can change the home directory only for user accounts that the network server creates.
		/// </para>
		/// <para>
		/// If the <c>NetUserSetInfo</c> function returns ERROR_INVALID_PARAMETER, you can use the parm_err parameter to indicate the first
		/// member of the user information structure that is invalid. (A user information structure begins with USER_INFO_ and its format is
		/// specified by the level parameter.) The following table lists the values that can be returned in the parm_err parameter and the
		/// corresponding structure member that is in error. (The prefix usri*_ indicates that the member can begin with multiple prefixes,
		/// for example, usri10_ or usri1003_.)
		/// </para>
		/// <list type="table">
		/// <listheader>
		/// <term>Value</term>
		/// <term>Member</term>
		/// </listheader>
		/// <item>
		/// <term>USER_NAME_PARMNUM</term>
		/// <term>usri*_name</term>
		/// </item>
		/// <item>
		/// <term>USER_PASSWORD_PARMNUM</term>
		/// <term>usri*_password</term>
		/// </item>
		/// <item>
		/// <term>USER_PASSWORD_AGE_PARMNUM</term>
		/// <term>usri*_password_age</term>
		/// </item>
		/// <item>
		/// <term>USER_PRIV_PARMNUM</term>
		/// <term>usri*_priv</term>
		/// </item>
		/// <item>
		/// <term>USER_HOME_DIR_PARMNUM</term>
		/// <term>usri*_home_dir</term>
		/// </item>
		/// <item>
		/// <term>USER_COMMENT_PARMNUM</term>
		/// <term>usri*_comment</term>
		/// </item>
		/// <item>
		/// <term>USER_FLAGS_PARMNUM</term>
		/// <term>usri*_flags</term>
		/// </item>
		/// <item>
		/// <term>USER_SCRIPT_PATH_PARMNUM</term>
		/// <term>usri*_script_path</term>
		/// </item>
		/// <item>
		/// <term>USER_AUTH_FLAGS_PARMNUM</term>
		/// <term>usri*_auth_flags</term>
		/// </item>
		/// <item>
		/// <term>USER_FULL_NAME_PARMNUM</term>
		/// <term>usri*_full_name</term>
		/// </item>
		/// <item>
		/// <term>USER_USR_COMMENT_PARMNUM</term>
		/// <term>usri*_usr_comment</term>
		/// </item>
		/// <item>
		/// <term>USER_PARMS_PARMNUM</term>
		/// <term>usri*_parms</term>
		/// </item>
		/// <item>
		/// <term>USER_WORKSTATIONS_PARMNUM</term>
		/// <term>usri*_workstations</term>
		/// </item>
		/// <item>
		/// <term>USER_LAST_LOGON_PARMNUM</term>
		/// <term>usri*_last_logon</term>
		/// </item>
		/// <item>
		/// <term>USER_LAST_LOGOFF_PARMNUM</term>
		/// <term>usri*_last_logoff</term>
		/// </item>
		/// <item>
		/// <term>USER_ACCT_EXPIRES_PARMNUM</term>
		/// <term>usri*_acct_expires</term>
		/// </item>
		/// <item>
		/// <term>USER_MAX_STORAGE_PARMNUM</term>
		/// <term>usri*_max_storage</term>
		/// </item>
		/// <item>
		/// <term>USER_UNITS_PER_WEEK_PARMNUM</term>
		/// <term>usri*_units_per_week</term>
		/// </item>
		/// <item>
		/// <term>USER_LOGON_HOURS_PARMNUM</term>
		/// <term>usri*_logon_hours</term>
		/// </item>
		/// <item>
		/// <term>USER_PAD_PW_COUNT_PARMNUM</term>
		/// <term>usri*_bad_pw_count</term>
		/// </item>
		/// <item>
		/// <term>USER_NUM_LOGONS_PARMNUM</term>
		/// <term>usri*_num_logons</term>
		/// </item>
		/// <item>
		/// <term>USER_LOGON_SERVER_PARMNUM</term>
		/// <term>usri*_logon_server</term>
		/// </item>
		/// <item>
		/// <term>USER_COUNTRY_CODE_PARMNUM</term>
		/// <term>usri*_country_code</term>
		/// </item>
		/// <item>
		/// <term>USER_CODE_PAGE_PARMNUM</term>
		/// <term>usri*_code_page</term>
		/// </item>
		/// <item>
		/// <term>USER_PRIMARY_GROUP_PARMNUM</term>
		/// <term>usri*_primary_group_id</term>
		/// </item>
		/// <item>
		/// <term>USER_PROFILE_PARMNUM</term>
		/// <term>usri*_profile</term>
		/// </item>
		/// <item>
		/// <term>USER_HOME_DIR_DRIVE_PARMNUM</term>
		/// <term>usri*_home_dir_drive</term>
		/// </item>
		/// </list>
		/// <para>
		/// User account names are limited to 20 characters and group names are limited to 256 characters. In addition, account names cannot
		/// be terminated by a period and they cannot include commas or any of the following printable characters: ", /, , [, ], :, |, &lt;,
		/// &gt;, +, =, ;, ?, *. Names also cannot include characters in the range 1-31, which are non-printable.
		/// </para>
		/// <para>
		/// The <c>NetUserSetInfo</c> function does not control how the password parameters are secured when sent over the network to a
		/// remote server to change a user password. Any encryption of these parameters is handled by the Remote Procedure Call (RPC)
		/// mechanism supported by the network redirector that provides the network transport. Encryption is also controlled by the security
		/// mechanisms supported by the local computer and the security mechanisms supported by remote network server specified in the
		/// servername parameter. For more details on security when the Microsoft network redirector is used and the remote network server is
		/// running Microsoft Windows, see the protocol documentation for MS-RPCE and MS-SAMR.
		/// </para>
		/// <para>Examples</para>
		/// <para>
		/// The following code sample demonstrates how to disable a user account with a call to the <c>NetUserSetInfo</c> function. The code
		/// sample fills in the <c>usri1008_flags</c> member of the USER_INFO_1008 structure, specifying the value UF_ACCOUNTDISABLE. Then
		/// the sample calls <c>NetUserSetInfo</c>, specifying information level 0.
		/// </para>
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows/desktop/api/lmaccess/nf-lmaccess-netusersetinfo NET_API_STATUS NET_API_FUNCTION
		// NetUserSetInfo( LPCWSTR servername, LPCWSTR username, DWORD level, LPBYTE buf, LPDWORD parm_err );
		[DllImport(Lib.NetApi32, SetLastError = false, ExactSpelling = true, CharSet = CharSet.Unicode)]
		[PInvokeData("lmaccess.h", MSDNShortId = "ffe49d4b-e7e8-4982-8087-59bb7534b257")]
		public static extern Win32Error NetUserSetInfo([Optional] string servername, string username, uint level, IntPtr buf, out uint parm_err);

		/// <summary>
		/// The <c>NetValidatePasswordPolicy</c> function allows an application to check password compliance against an application-provided
		/// account database and verify that passwords meet the complexity, aging, minimum length, and history reuse requirements of a
		/// password policy.
		/// </summary>
		/// <param name="ServerName">
		/// A pointer to a constant Unicode string specifying the name of the remote server on which the function is to execute. This string
		/// must begin with \ followed by the remote server name. If this parameter is <c>NULL</c>, the local computer is used.
		/// </param>
		/// <param name="Qualifier">Reserved for future use. This parameter must be <c>NULL</c>.</param>
		/// <param name="ValidationType">
		/// The type of password validation to perform. This parameter must be one of the following enumerated constant values.
		/// </param>
		/// <param name="InputArg">
		/// A pointer to a structure that depends on the type of password validation to perform. The type of structure depends on the value
		/// of the ValidationType parameter. For more information, see the description of the ValidationType parameter.
		/// </param>
		/// <param name="OutputArg">
		/// <para>
		/// If the <c>NetValidatePasswordPolicy</c> function succeeds (the return value is <c>Nerr_Success</c>), then the function allocates
		/// an buffer that contains the results of the operation. The OutputArg parameter contains a pointer to a NET_VALIDATE_OUTPUT_ARG
		/// structure. The application must examine <c>ValidationStatus</c> member in the <c>NET_VALIDATE_OUTPUT_ARG</c> structure pointed to
		/// by the OutputArg parameter to determine the results of the password policy validation check. The <c>NET_VALIDATE_OUTPUT_ARG</c>
		/// structure contains a NET_VALIDATE_PERSISTED_FIELDS structure with changes to persistent password-related information, and the
		/// results of the password validation. The application must plan to persist all persisted the fields in the
		/// <c>NET_VALIDATE_PERSISTED_FIELDS</c> structure aside from the <c>ValidationStatus</c> member as information along with the user
		/// object information and provide the required fields from the persisted information when calling this function in the future on the
		/// same user object.
		/// </para>
		/// <para>
		/// If the <c>NetValidatePasswordPolicy</c> function fails (the return value is nonzero), then OutputArg parameter is set to a
		/// <c>NULL</c> pointer and password policy could not be examined.
		/// </para>
		/// <para>For more information, see the Return Values and Remarks sections.</para>
		/// </param>
		/// <returns>
		/// <para>
		/// If the function succeeds, and the password is authenticated, changed, or reset, the return value is NERR_Success and the function
		/// allocates an OutputArg parameter.
		/// </para>
		/// <para>
		/// If the function fails, the OutputArg parameter is <c>NULL</c> and the return value is a system error code that can be one of the
		/// following error codes. For a list of all possible error codes, see System Error Codes.
		/// </para>
		/// <list type="table">
		/// <listheader>
		/// <term>Return code</term>
		/// <term>Description</term>
		/// </listheader>
		/// <item>
		/// <term>ERROR_INVALID_PARAMETER</term>
		/// <term>
		/// A parameter is incorrect. This error is returned if the InputArg or OutputArg parameters are NULL. This error is also returned if
		/// the Qualifier parameter is not NULL or if the ValidationType parameter is not one of the allowed values.
		/// </term>
		/// </item>
		/// <item>
		/// <term>ERROR_NOT_ENOUGH_MEMORY</term>
		/// <term>Not enough memory is available to complete the operation.</term>
		/// </item>
		/// </list>
		/// </returns>
		/// <remarks>
		/// <para>
		/// The <c>NetValidatePasswordPolicy</c> function is designed to allow applications to validate passwords for users that are in an
		/// account database provided by the application. This function can also be used to verify that passwords meet the complexity, aging,
		/// minimum length, and history reuse requirements of a password policy. This function also provides the means for an application to
		/// implement an account-lockout mechanism.
		/// </para>
		/// <para>
		/// The <c>NetValidatePasswordPolicy</c> function does not validate passwords in Active Directory accounts and cannot be used for
		/// this purpose. The only policy that this function checks a password against in Active Directory accounts is the password
		/// complexity (the password strength).
		/// </para>
		/// <para>
		/// A typical scenario for the use of the <c>NetValidatePasswordPolicy</c> function would be enforcing the choice of strong passwords
		/// by users for web applications and applications that allow password-protected documents. Another use of this function could be
		/// checking password complexity in a situation in which a password is attached to a functional operation rather than to a user
		/// account; for example, passwords that are used with Secure Multipurpose Internet Mail Extensions (S/MIME) certificate-based public keys.
		/// </para>
		/// <para>
		/// If the <c>NetValidatePasswordPolicy</c> function is called on a domain controller that is running Active Directory, access is
		/// allowed or denied based on the ACL for the securable object. The default ACL permits all authenticated users and members of the
		/// "Pre-Windows 2000 compatible access" group to view the information. If you call this function on a member server or workstation,
		/// all authenticated users can view the information. For information about anonymous access and restricting anonymous access on
		/// these platforms, see Security Requirements for the Network Management Functions. For more information on ACLs, ACEs, and access
		/// tokens, see Access Control Model.
		/// </para>
		/// <para>
		/// The security descriptor of the Domain object is used to perform the access check for the <c>NetValidatePasswordPolicy</c> function.
		/// </para>
		/// <para>
		/// To call <c>NetValidatePasswordPolicy</c> in a security context that is not the default, first call the LogonUser function,
		/// specifying LOGON32_LOGON_NEW_CREDENTIALS in the dwLogonType parameter, and then call <c>NetValidatePasswordPolicy</c> under
		/// impersonation. For more information about impersonation, see Client Impersonation.
		/// </para>
		/// <para>
		/// If the return code of the <c>NetValidatePasswordPolicy</c> function is <c>Nerr_Success</c> then the function allocates a buffer
		/// pointed to by the OutputArg parameter that contains a NET_VALIDATE_OUTPUT_ARG structure with the results of the operation. The
		/// application must examine <c>ValidationStatus</c> member in the <c>NET_VALIDATE_OUTPUT_ARG</c> structure to determine the results
		/// of the password policy validation check. For more information, see <c>NET_VALIDATE_OUTPUT_ARG</c>.
		/// </para>
		/// <para>
		/// Note that it is the application's responsibility to save all the data in the <c>ChangedPersistedFields</c> member of the
		/// <c>NET_VALIDATE_OUTPUT_ARG</c> structure as well as any User object information. The next time the application calls
		/// <c>NetValidatePasswordPolicy</c> on the same instance of the User object, the application must provide the required fields from
		/// the persistent information.
		/// </para>
		/// <para>
		/// When you call <c>NetValidatePasswordPolicy</c> and specify NET_VALIDATE_PASSWORD_CHANGE_INPUT_ARG or
		/// NET_VALIDATE_PASSWORD_RESET_INPUT_ARG in InputArg parameter, the call also validates the password by passing it through the
		/// password filter DLL that the computer is configured to use. For more information about password filters, see Using Password Filters.
		/// </para>
		/// <para>
		/// If the return value from the <c>NetValidatePasswordPolicy</c> function is nonzero then OutputArg parameter is set to <c>NULL</c>
		/// and password policy could not be examined.
		/// </para>
		/// <para>
		/// The NetValidatePasswordPolicyFree function should be called after calling <c>NetValidatePasswordPolicy</c> to free the memory
		/// allocated for the OutputArg parameter that is returned by the call to the <c>NetValidatePasswordPolicy</c> function.
		/// </para>
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows/desktop/api/lmaccess/nf-lmaccess-netvalidatepasswordpolicy NET_API_STATUS
		// NET_API_FUNCTION NetValidatePasswordPolicy( IN LPCWSTR ServerName, IN LPVOID Qualifier, IN NET_VALIDATE_PASSWORD_TYPE
		// ValidationType, IN LPVOID InputArg, OUT LPVOID *OutputArg );
		[DllImport(Lib.NetApi32, SetLastError = false, ExactSpelling = true, CharSet = CharSet.Unicode)]
		[PInvokeData("lmaccess.h", MSDNShortId = "be5ce51b-6568-49c8-954d-7b0d4bcb8611")]
		public static extern Win32Error NetValidatePasswordPolicy([Optional] string ServerName, [Optional] IntPtr Qualifier, NET_VALIDATE_PASSWORD_TYPE ValidationType, IntPtr InputArg, out SafePwdPolicy OutputArg);

		/// <summary>
		/// The <c>NetValidatePasswordPolicyFree</c> function frees the memory that the NetValidatePasswordPolicy function allocates for the
		/// OutputArg parameter, which is a NET_VALIDATE_OUTPUT_ARG structure.
		/// </summary>
		/// <param name="OutputArg">
		/// Pointer to the memory allocated for the OutputArg parameter by a call to the <c>NetValidatePasswordPolicy</c> function.
		/// </param>
		/// <returns>
		/// <para>
		/// If the function frees the memory, or if there is no memory to free from a previous call to <c>NetValidatePasswordPolicy</c>, the
		/// return value is NERR_Success.
		/// </para>
		/// <para>If the function fails, the return value is a system error code. For a list of error codes, see System Error Codes.</para>
		/// </returns>
		/// <remarks>No special group membership is required to successfully execute this function.</remarks>
		// https://docs.microsoft.com/en-us/windows/desktop/api/lmaccess/nf-lmaccess-netvalidatepasswordpolicyfree NET_API_STATUS
		// NET_API_FUNCTION NetValidatePasswordPolicyFree( IN LPVOID *OutputArg );
		[DllImport(Lib.NetApi32, SetLastError = false, ExactSpelling = true, CharSet = CharSet.Unicode)]
		[PInvokeData("lmaccess.h", MSDNShortId = "263834cd-a0e2-4ec0-9cb1-c03eb198de3a")]
		public static extern Win32Error NetValidatePasswordPolicyFree(in IntPtr OutputArg);

		/// <summary>
		/// The <c>GROUP_INFO_0</c> structure contains the name of a global group in the security database, which is the security accounts
		/// manager (SAM) database or, in the case of domain controllers, the Active Directory.
		/// </summary>
		/// <remarks>
		/// User account names are limited to 20 characters and group names are limited to 256 characters. In addition, account names cannot
		/// be terminated by a period and they cannot include commas or any of the following printable characters: ", /, , [, ], :, |, &lt;,
		/// &gt;, +, =, ;, ?, *. Names also cannot include characters in the range 1-31, which are non-printable.
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows/desktop/api/lmaccess/ns-lmaccess-group_info_0 typedef struct _GROUP_INFO_0 { LPWSTR
		// grpi0_name; } GROUP_INFO_0, *PGROUP_INFO_0, *LPGROUP_INFO_0;
		[PInvokeData("lmaccess.h", MSDNShortId = "019796d1-b987-45d2-90df-1d3b484217a9")]
		[StructLayout(LayoutKind.Sequential, CharSet = CharSet.Unicode)]
		public struct GROUP_INFO_0
		{
			/// <summary>
			/// <para>
			/// Pointer to a null-terminated Unicode character string that specifies the name of the global group. For more information, see
			/// the following Remarks section.
			/// </para>
			/// <para>When you call the NetGroupSetInfo function this member specifies the new name of the global group.</para>
			/// </summary>
			public string grpi0_name;
		}

		/// <summary>The <c>GROUP_INFO_1</c> structure contains a global group name and a comment to associate with the group.</summary>
		/// <remarks>
		/// User account names are limited to 20 characters and group names are limited to 256 characters. In addition, account names cannot
		/// be terminated by a period and they cannot include commas or any of the following printable characters: ", /, , [, ], :, |, &lt;,
		/// &gt;, +, =, ;, ?, *. Names also cannot include characters in the range 1-31, which are non-printable.
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows/desktop/api/lmaccess/ns-lmaccess-_group_info_1 typedef struct _GROUP_INFO_1 { LPWSTR
		// grpi1_name; LPWSTR grpi1_comment; } GROUP_INFO_1, *PGROUP_INFO_1, *LPGROUP_INFO_1;
		[PInvokeData("lmaccess.h", MSDNShortId = "0b42a438-64fd-4f37-98b8-77e10c09548c")]
		[StructLayout(LayoutKind.Sequential, CharSet = CharSet.Unicode)]
		public struct GROUP_INFO_1
		{
			/// <summary>
			/// <para>
			/// Pointer to a null-terminated Unicode character string that specifies the name of the global group. For more information, see
			/// the following Remarks section.
			/// </para>
			/// <para>When you call the NetGroupSetInfo function this member is ignored.</para>
			/// </summary>
			public string grpi1_name;

			/// <summary>
			/// Pointer to a null-terminated Unicode character string that specifies a remark associated with the global group. This member
			/// can be a null string. The comment can contain MAXCOMMENTSZ characters.
			/// </summary>
			public string grpi1_comment;
		}

		/// <summary>The <c>GROUP_INFO_1002</c> structure contains a comment to associate with a global group.</summary>
		// https://docs.microsoft.com/en-us/windows/desktop/api/lmaccess/ns-lmaccess-_group_info_1002 typedef struct _GROUP_INFO_1002 {
		// LPWSTR grpi1002_comment; } GROUP_INFO_1002, *PGROUP_INFO_1002, *LPGROUP_INFO_1002;
		[PInvokeData("lmaccess.h", MSDNShortId = "9c322ef5-4f98-44ad-8b57-40f8533eb9c1")]
		[StructLayout(LayoutKind.Sequential, CharSet = CharSet.Unicode)]
		public struct GROUP_INFO_1002
		{
			/// <summary>
			/// Pointer to a null-terminated Unicode character string that contains a remark to associate with the global group. This member
			/// can be a null string. The comment can contain MAXCOMMENTSZ characters.
			/// </summary>
			public string grpi1002_comment;
		}

		/// <summary>The <c>GROUP_INFO_1005</c> structure contains the resource attributes associated with a global group.</summary>
		// https://docs.microsoft.com/en-us/windows/desktop/api/lmaccess/ns-lmaccess-_group_info_1005 typedef struct _GROUP_INFO_1005 { DWORD
		// grpi1005_attributes; } GROUP_INFO_1005, *PGROUP_INFO_1005, *LPGROUP_INFO_1005;
		[PInvokeData("lmaccess.h", MSDNShortId = "bd93820a-e019-45f4-88c7-011a517955ad")]
		[StructLayout(LayoutKind.Sequential, CharSet = CharSet.Unicode)]
		public struct GROUP_INFO_1005
		{
			/// <summary>
			/// These attributes are hard-coded to SE_GROUP_MANDATORY, SE_GROUP_ENABLED, and SE_GROUP_ENABLED_BY_DEFAULT. For more
			/// information, see TOKEN_GROUPS.
			/// </summary>
			public GroupAttributes grpi1005_attributes;
		}

		/// <summary>
		/// <para>
		/// The <c>GROUP_INFO_2</c> structure contains information about a global group, including name, identifier, and resource attributes.
		/// </para>
		/// <para>It is recommended that you use the GROUP_INFO_3 structure instead.</para>
		/// </summary>
		/// <remarks>
		/// User account names are limited to 20 characters and group names are limited to 256 characters. In addition, account names cannot
		/// be terminated by a period and they cannot include commas or any of the following printable characters: ", /, , [, ], :, |, &lt;,
		/// &gt;, +, =, ;, ?, *. Names also cannot include characters in the range 1-31, which are non-printable.
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows/desktop/api/lmaccess/ns-lmaccess-_group_info_2 typedef struct _GROUP_INFO_2 { LPWSTR
		// grpi2_name; LPWSTR grpi2_comment; DWORD grpi2_group_id; DWORD grpi2_attributes; } GROUP_INFO_2, *PGROUP_INFO_2;
		[PInvokeData("lmaccess.h", MSDNShortId = "2c17a70c-7b62-4dcc-9dc6-2f4b8c41d6ec")]
		[StructLayout(LayoutKind.Sequential, CharSet = CharSet.Unicode)]
		public struct GROUP_INFO_2
		{
			/// <summary>
			/// <para>
			/// Pointer to a null-terminated Unicode character string that specifies the name of the global group. For more information, see
			/// the following Remarks section.
			/// </para>
			/// <para>When you call the NetGroupSetInfo function this member is ignored.</para>
			/// </summary>
			public string grpi2_name;

			/// <summary>
			/// Pointer to a null-terminated Unicode character string that contains a remark associated with the global group. This member
			/// can be a null string. The comment can contain MAXCOMMENTSZ characters.
			/// </summary>
			public string grpi2_comment;

			/// <summary>
			/// The relative identifier (RID) of the global group. The NetUserAdd and NetUserSetInfo functions ignore this member. For more
			/// information about RIDs, see SID Components.
			/// </summary>
			public uint grpi2_group_id;

			/// <summary>
			/// These attributes are hard-coded to SE_GROUP_MANDATORY, SE_GROUP_ENABLED, and SE_GROUP_ENABLED_BY_DEFAULT. For more
			/// information, see TOKEN_GROUPS.
			/// </summary>
			public GroupAttributes grpi2_attributes;
		}

		/// <summary>
		/// The <c>GROUP_INFO_3</c> structure contains information about a global group, including name, security identifier (SID), and
		/// resource attributes.
		/// </summary>
		// https://docs.microsoft.com/en-us/windows/desktop/api/lmaccess/ns-lmaccess-_group_info_3 typedef struct _GROUP_INFO_3 { LPWSTR
		// grpi3_name; LPWSTR grpi3_comment; PSID grpi3_group_sid; DWORD grpi3_attributes; } GROUP_INFO_3, *PGROUP_INFO_3;
		[PInvokeData("lmaccess.h", MSDNShortId = "aa0c3b6e-ab27-48b9-a37f-5cceb63c70fd")]
		[StructLayout(LayoutKind.Sequential, CharSet = CharSet.Unicode)]
		public struct GROUP_INFO_3
		{
			/// <summary>
			/// <para>Pointer to a null-terminated Unicode character string that specifies the name of the global group.</para>
			/// <para>When you call the NetGroupSetInfo function this member is ignored.</para>
			/// </summary>
			public string grpi3_name;

			/// <summary>
			/// Pointer to a null-terminated Unicode character string that contains a remark associated with the global group. This member
			/// can be a null string. The comment can contain MAXCOMMENTSZ characters.
			/// </summary>
			public string grpi3_comment;

			/// <summary>
			/// Pointer to a SID structure that contains the security identifier (SID) that uniquely identifies the global group. The
			/// NetUserAdd and NetUserSetInfo functions ignore this member.
			/// </summary>
			public PSID grpi3_group_sid;

			/// <summary>
			/// These attributes are hard-coded to SE_GROUP_MANDATORY, SE_GROUP_ENABLED, and SE_GROUP_ENABLED_BY_DEFAULT. For more
			/// information, see TOKEN_GROUPS.
			/// </summary>
			public GroupAttributes grpi3_attributes;
		}

		/// <summary>The <c>GROUP_USERS_INFO_0</c> structure contains global group member information.</summary>
		/// <remarks>
		/// <para>
		/// If you are calling the NetGroupGetUsers function or the NetGroupSetUsers function, the <c>grui0_name</c> member contains the name
		/// of a user that is a member of the specified group.
		/// </para>
		/// <para>
		/// If you are calling the NetUserGetGroups function or the NetUserSetGroups function, the <c>grui0_name</c> member contains the name
		/// of a global group to which the specified user belongs.
		/// </para>
		/// <para>
		/// User account names are limited to 20 characters and group names are limited to 256 characters. In addition, account names cannot
		/// be terminated by a period and they cannot include commas or any of the following printable characters: ", /, , [, ], :, |, &lt;,
		/// &gt;, +, =, ;, ?, *. Names also cannot include characters in the range 1-31, which are non-printable.
		/// </para>
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows/desktop/api/lmaccess/ns-lmaccess-_group_users_info_0 typedef struct _GROUP_USERS_INFO_0 {
		// LPWSTR grui0_name; } GROUP_USERS_INFO_0, *PGROUP_USERS_INFO_0, *LPGROUP_USERS_INFO_0;
		[PInvokeData("lmaccess.h", MSDNShortId = "cc0e5d27-91f1-4640-bb80-e73899fabba9")]
		[StructLayout(LayoutKind.Sequential, CharSet = CharSet.Unicode)]
		public struct GROUP_USERS_INFO_0
		{
			/// <summary>
			/// A pointer to a null-terminated Unicode character string that specifies a name. For more information, see the Remarks section.
			/// </summary>
			public string grui0_name;
		}

		/// <summary>The <c>GROUP_USERS_INFO_1</c> structure contains global group member information.</summary>
		/// <remarks>
		/// <para>
		/// If you are calling the NetGroupGetUsers function or the NetGroupSetUsers function, the <c>grui1_name</c> member contains the name
		/// of a user that is a member of the specified group.
		/// </para>
		/// <para>
		/// If you are calling the NetUserGetGroups function or the NetUserSetGroups function, the <c>grui1_name</c> member contains the name
		/// of a global group to which the specified user belongs.
		/// </para>
		/// <para>
		/// User account names are limited to 20 characters and group names are limited to 256 characters. In addition, account names cannot
		/// be terminated by a period and they cannot include commas or any of the following printable characters: ", /, , [, ], :, |, &lt;,
		/// &gt;, +, =, ;, ?, *. Names also cannot include characters in the range 1-31, which are non-printable.
		/// </para>
		/// <para>
		/// Windows Vista and later include an addition to the access control security mechanism of Windows that labels processes and other
		/// securable objects with an integrity level. Internet-facing programs are at higher risk for exploits than other programs because
		/// they download untrustworthy content from unknown sources. Running these programs with fewer permissions, or at a lower integrity
		/// level, than other programs reduces the ability of an exploit to modify the system or harm user data files. The SE_GROUP_INTEGRITY
		/// and SE_GROUP_INTEGRITY_ENABLED attributes of the <c>grui1_attributes</c> member are used for this purpose.
		/// </para>
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows/desktop/api/lmaccess/ns-lmaccess-_group_users_info_1 typedef struct _GROUP_USERS_INFO_1 {
		// LPWSTR grui1_name; DWORD grui1_attributes; } GROUP_USERS_INFO_1, *PGROUP_USERS_INFO_1, *LPGROUP_USERS_INFO_1;
		[PInvokeData("lmaccess.h", MSDNShortId = "d92e7c18-f2c7-4ea5-8bb6-fec023272dbb")]
		[StructLayout(LayoutKind.Sequential, CharSet = CharSet.Unicode)]
		public struct GROUP_USERS_INFO_1
		{
			/// <summary>
			/// <para>Type: <c>LPWSTR</c></para>
			/// <para>
			/// A pointer to a null-terminated Unicode character string that specifies a name. For more information, see the Remarks section.
			/// </para>
			/// </summary>
			public string grui1_name;

			/// <summary>
			/// <para>Type: <c>DWORD</c></para>
			/// <para>
			/// A set of attributes for this entry. This member can be a combination of the security group attributes defined in the Winnt.h
			/// header file.
			/// </para>
			/// <list type="table">
			/// <listheader>
			/// <term>Value</term>
			/// <term>Meaning</term>
			/// </listheader>
			/// <item>
			/// <term>SE_GROUP_MANDATORY 0x00000001</term>
			/// <term>The group is mandatory.</term>
			/// </item>
			/// <item>
			/// <term>SE_GROUP_ENABLED_BY_DEFAULT 0x00000002</term>
			/// <term>The group is enabled for access checks by default.</term>
			/// </item>
			/// <item>
			/// <term>SE_GROUP_ENABLED 0x00000004</term>
			/// <term>The group is enabled for access checks.</term>
			/// </item>
			/// <item>
			/// <term>SE_GROUP_OWNER 0x00000008</term>
			/// <term>The group identifies a group account for which the user of the token is the owner of the group.</term>
			/// </item>
			/// <item>
			/// <term>SE_GROUP_USE_FOR_DENY_ONLY 0x00000010</term>
			/// <term>The group is used for deny only purposes. When this attribute is set, the SE_GROUP_ENABLED attribute must not be set.</term>
			/// </item>
			/// <item>
			/// <term>SE_GROUP_INTEGRITY 0x00000020</term>
			/// <term>The group is used for integrity. This attribute is available on Windows Vista and later.</term>
			/// </item>
			/// <item>
			/// <term>SE_GROUP_INTEGRITY_ENABLED 0x00000040</term>
			/// <term>The group is enabled for integrity level. This attribute is available on Windows Vista and later.</term>
			/// </item>
			/// <item>
			/// <term>SE_GROUP_LOGON_ID 0xC0000000</term>
			/// <term>The group is used to identify a logon session associated with an access token.</term>
			/// </item>
			/// <item>
			/// <term>SE_GROUP_RESOURCE 0x20000000</term>
			/// <term>The group identifies a domain-local group.</term>
			/// </item>
			/// </list>
			/// </summary>
			public GroupAttributes grui1_attributes;
		}

		/// <summary>The <c>LOCALGROUP_INFO_0</c> structure contains a local group name.</summary>
		/// <remarks>
		/// <para>
		/// When you call the NetLocalGroupAdd function, this member specifies the name of a new local group. When you call the
		/// NetLocalGroupSetInfo function, this member specifies the new name of an existing local group.
		/// </para>
		/// <para>
		/// User account names are limited to 20 characters and group names are limited to 256 characters. In addition, account names cannot
		/// be terminated by a period and they cannot include commas or any of the following printable characters: ", /, , [, ], :, |, &lt;,
		/// &gt;, +, =, ;, ?, *. Names also cannot include characters in the range 1-31, which are non-printable.
		/// </para>
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows/desktop/api/lmaccess/ns-lmaccess-_localgroup_info_0 typedef struct _LOCALGROUP_INFO_0 {
		// LPWSTR lgrpi0_name; } LOCALGROUP_INFO_0, *PLOCALGROUP_INFO_0, *LPLOCALGROUP_INFO_0;
		[PInvokeData("lmaccess.h", MSDNShortId = "dfdb4c20-ea4a-45c9-b4f3-d6a844f89bb6")]
		[StructLayout(LayoutKind.Sequential, CharSet = CharSet.Unicode)]
		public struct LOCALGROUP_INFO_0
		{
			/// <summary>
			/// Pointer to a Unicode string that specifies a local group name. For more information, see the following Remarks section.
			/// </summary>
			public string lgrpi0_name;
		}

		/// <summary>The <c>LOCALGROUP_INFO_1</c> structure contains a local group name and a comment describing the local group.</summary>
		/// <remarks>
		/// User account names are limited to 20 characters and group names are limited to 256 characters. In addition, account names cannot
		/// be terminated by a period and they cannot include commas or any of the following printable characters: ", /, , [, ], :, |, &lt;,
		/// &gt;, +, =, ;, ?, *. Names also cannot include characters in the range 1-31, which are non-printable.
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows/desktop/api/lmaccess/ns-lmaccess-_localgroup_info_1 typedef struct _LOCALGROUP_INFO_1 {
		// LPWSTR lgrpi1_name; LPWSTR lgrpi1_comment; } LOCALGROUP_INFO_1, *PLOCALGROUP_INFO_1, *LPLOCALGROUP_INFO_1;
		[PInvokeData("lmaccess.h", MSDNShortId = "b96d7ddc-3ffb-4203-88b1-4aa123051695")]
		[StructLayout(LayoutKind.Sequential, CharSet = CharSet.Unicode)]
		public struct LOCALGROUP_INFO_1
		{
			/// <summary>
			/// <para>Pointer to a Unicode string that specifies a local group name. For more information, see the following Remarks section.</para>
			/// <para>This member is ignored when you call the NetLocalGroupSetInfo function.</para>
			/// </summary>
			public string lgrpi1_name;

			/// <summary>
			/// Pointer to a Unicode string that contains a remark associated with the local group. This member can be a null string. The
			/// comment can have as many as MAXCOMMENTSZ characters.
			/// </summary>
			public string lgrpi1_comment;
		}

		/// <summary>The <c>LOCALGROUP_INFO_1002</c> structure contains a comment describing a local group.</summary>
		// https://docs.microsoft.com/en-us/windows/desktop/api/lmaccess/ns-lmaccess-_localgroup_info_1002 typedef struct
		// _LOCALGROUP_INFO_1002 { LPWSTR lgrpi1002_comment; } LOCALGROUP_INFO_1002, *PLOCALGROUP_INFO_1002, *LPLOCALGROUP_INFO_1002;
		[PInvokeData("lmaccess.h", MSDNShortId = "027db4a3-6722-46e8-a204-922ed97cb3f5")]
		[StructLayout(LayoutKind.Sequential, CharSet = CharSet.Unicode)]
		public struct LOCALGROUP_INFO_1002
		{
			/// <summary>
			/// Pointer to a Unicode string that specifies a remark associated with the local group. This member can be a null string. The
			/// comment can have as many as MAXCOMMENTSZ characters.
			/// </summary>
			public string lgrpi1002_comment;
		}

		/// <summary>
		/// The <c>LOCALGROUP_MEMBERS_INFO_0</c> structure contains the security identifier (SID) associated with a local group member. The
		/// member can be a user account or a global group account.
		/// </summary>
		// https://docs.microsoft.com/en-us/windows/desktop/api/lmaccess/ns-lmaccess-_localgroup_members_info_0 typedef struct
		// _LOCALGROUP_MEMBERS_INFO_0 { PSID lgrmi0_sid; } LOCALGROUP_MEMBERS_INFO_0, *PLOCALGROUP_MEMBERS_INFO_0, *LPLOCALGROUP_MEMBERS_INFO_0;
		[PInvokeData("lmaccess.h", MSDNShortId = "e559cd90-942c-442a-b57f-7d2024523455")]
		[StructLayout(LayoutKind.Sequential, CharSet = CharSet.Unicode)]
		public struct LOCALGROUP_MEMBERS_INFO_0
		{
			/// <summary>Pointer to a SID structure that contains the security identifier (SID) of the local group member.</summary>
			public PSID lgrmi0_sid;
		}

		/// <summary>
		/// The <c>LOCALGROUP_MEMBERS_INFO_1</c> structure contains the security identifier (SID) and account information associated with the
		/// member of a local group.
		/// </summary>
		/// <remarks>
		/// User account names are limited to 20 characters and group names are limited to 256 characters. In addition, account names cannot
		/// be terminated by a period and they cannot include commas or any of the following printable characters: ", /, , [, ], :, |, &lt;,
		/// &gt;, +, =, ;, ?, *. Names also cannot include characters in the range 1-31, which are non-printable.
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows/desktop/api/lmaccess/ns-lmaccess-localgroup_members_info_1 typedef struct
		// _LOCALGROUP_MEMBERS_INFO_1 { PSID lgrmi1_sid; SID_NAME_USE lgrmi1_sidusage; LPWSTR lgrmi1_name; } LOCALGROUP_MEMBERS_INFO_1,
		// *PLOCALGROUP_MEMBERS_INFO_1, *LPLOCALGROUP_MEMBERS_INFO_1;
		[PInvokeData("lmaccess.h", MSDNShortId = "d6b1b729-cdd5-4ed3-a5a1-cf3a8b6cecf2")]
		[StructLayout(LayoutKind.Sequential, CharSet = CharSet.Unicode)]
		public struct LOCALGROUP_MEMBERS_INFO_1
		{
			/// <summary>
			/// <para>Type: <c>PSID</c></para>
			/// <para>
			/// A pointer to a SID structure that contains the security identifier (SID) of an account that is a member of this local group
			/// member. The account can be a user account or a global group account.
			/// </para>
			/// </summary>
			public PSID lgrmi1_sid;

			/// <summary>
			/// <para>Type: <c>SID_NAME_USE</c></para>
			/// <para>
			/// The account type associated with the security identifier specified in the <c>lgrmi1_sid</c> member. The following values are valid.
			/// </para>
			/// <list type="table">
			/// <listheader>
			/// <term>Value</term>
			/// <term>Meaning</term>
			/// </listheader>
			/// <item>
			/// <term>SidTypeUser</term>
			/// <term>The account is a user account.</term>
			/// </item>
			/// <item>
			/// <term>SidTypeGroup</term>
			/// <term>The account is a global group account.</term>
			/// </item>
			/// <item>
			/// <term>SidTypeWellKnownGroup</term>
			/// <term>The account is a well-known group account (such as Everyone). For more information, see Well-Known SIDs.</term>
			/// </item>
			/// <item>
			/// <term>SidTypeDeletedAccount</term>
			/// <term>The account has been deleted.</term>
			/// </item>
			/// <item>
			/// <term>SidTypeUnknown</term>
			/// <term>The account type cannot be determined.</term>
			/// </item>
			/// </list>
			/// </summary>
			public SID_NAME_USE lgrmi1_sidusage;

			/// <summary>
			/// <para>Type: <c>LPWSTR</c></para>
			/// <para>
			/// A pointer to the account name of the local group member identified by the <c>lgrmi1_sid</c> member. The <c>lgrmi1_name</c>
			/// member does not include the domain name. For more information, see the following Remarks section.
			/// </para>
			/// </summary>
			public string lgrmi1_name;
		}

		/// <summary>
		/// The <c>LOCALGROUP_MEMBERS_INFO_2</c> structure contains the security identifier (SID) and account information associated with a
		/// local group member.
		/// </summary>
		/// <remarks>
		/// User account names are limited to 20 characters and group names are limited to 256 characters. In addition, account names cannot
		/// be terminated by a period and they cannot include commas or any of the following printable characters: ", /, , [, ], :, |, &lt;,
		/// &gt;, +, =, ;, ?, *. Names also cannot include characters in the range 1-31, which are non-printable.
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows/desktop/api/lmaccess/ns-lmaccess-localgroup_members_info_2 typedef struct
		// _LOCALGROUP_MEMBERS_INFO_2 { PSID lgrmi2_sid; SID_NAME_USE lgrmi2_sidusage; LPWSTR lgrmi2_domainandname; }
		// LOCALGROUP_MEMBERS_INFO_2, *PLOCALGROUP_MEMBERS_INFO_2, *LPLOCALGROUP_MEMBERS_INFO_2;
		[PInvokeData("lmaccess.h", MSDNShortId = "f5cd6e84-1111-4558-bec4-26af13f21b61")]
		[StructLayout(LayoutKind.Sequential, CharSet = CharSet.Unicode)]
		public struct LOCALGROUP_MEMBERS_INFO_2
		{
			/// <summary>
			/// <para>Type: <c>PSID</c></para>
			/// <para>
			/// A pointer to a SID structure that contains the security identifier (SID) of a local group member. The local group member can
			/// be a user account or a global group account.
			/// </para>
			/// </summary>
			public PSID lgrmi2_sid;

			/// <summary>
			/// <para>Type: <c>SID_NAME_USE</c></para>
			/// <para>
			/// The account type associated with the security identifier specified in the <c>lgrmi2_sid</c> member. The following values are valid.
			/// </para>
			/// <list type="table">
			/// <listheader>
			/// <term>Value</term>
			/// <term>Meaning</term>
			/// </listheader>
			/// <item>
			/// <term>SidTypeUser</term>
			/// <term>The account is a user account.</term>
			/// </item>
			/// <item>
			/// <term>SidTypeGroup</term>
			/// <term>The account is a global group account.</term>
			/// </item>
			/// <item>
			/// <term>SidTypeWellKnownGroup</term>
			/// <term>The account is a well-known group account (such as Everyone). For more information, see Well-Known SIDs.</term>
			/// </item>
			/// <item>
			/// <term>SidTypeDeletedAccount</term>
			/// <term>The account has been deleted.</term>
			/// </item>
			/// <item>
			/// <term>SidTypeUnknown</term>
			/// <term>The account type cannot be determined.</term>
			/// </item>
			/// </list>
			/// </summary>
			public SID_NAME_USE lgrmi2_sidusage;

			/// <summary>
			/// <para>Type: <c>LPWSTR</c></para>
			/// <para>
			/// A pointer to the account name of the local group member identified by <c>lgrmi2_sid</c>. The <c>lgrmi2_domainandname</c>
			/// member includes the domain name and has the form:
			/// </para>
			/// <para>
			/// <code>
			/// &lt;DomainName&gt;\&lt;AccountName&gt;
			/// </code>
			/// </para>
			/// </summary>
			public string lgrmi2_domainandname;
		}

		/// <summary>
		/// The <c>LOCALGROUP_MEMBERS_INFO_3</c> structure contains the account name and domain name associated with a local group member.
		/// </summary>
		/// <remarks>
		/// User account names are limited to 20 characters and group names are limited to 256 characters. In addition, account names cannot
		/// be terminated by a period and they cannot include commas or any of the following printable characters: ", /, , [, ], :, |, &lt;,
		/// &gt;, +, =, ;, ?, *. Names also cannot include characters in the range 1-31, which are non-printable.
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows/desktop/api/lmaccess/ns-lmaccess-_localgroup_members_info_3 typedef struct
		// _LOCALGROUP_MEMBERS_INFO_3 { LPWSTR lgrmi3_domainandname; } LOCALGROUP_MEMBERS_INFO_3, *PLOCALGROUP_MEMBERS_INFO_3, *LPLOCALGROUP_MEMBERS_INFO_3;
		[PInvokeData("lmaccess.h", MSDNShortId = "e8d1d884-c955-4706-bc3e-142469b02545")]
		[StructLayout(LayoutKind.Sequential, CharSet = CharSet.Unicode)]
		public struct LOCALGROUP_MEMBERS_INFO_3
		{
			/// <summary>
			/// <para>Type: <c>LPWSTR</c></para>
			/// <para>
			/// Pointer to a null-terminated Unicode string specifying the account name of the local group member prefixed by the domain name
			/// and the "" separator character. For example:
			/// </para>
			/// <para>
			/// <code>
			/// &lt;DomainName&gt;\&lt;AccountName&gt;
			/// </code>
			/// </para>
			/// </summary>
			public string lgrmi3_domainandname;
		}

		/// <summary>The <c>LOCALGROUP_USERS_INFO_0</c> structure contains local group member information.</summary>
		/// <remarks>
		/// User account names are limited to 20 characters and group names are limited to 256 characters. In addition, account names cannot
		/// be terminated by a period and they cannot include commas or any of the following printable characters: ", /, , [, ], :, |, &lt;,
		/// &gt;, +, =, ;, ?, *. Names also cannot include characters in the range 1-31, which are non-printable.
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows/desktop/api/lmaccess/ns-lmaccess-_localgroup_users_info_0 typedef struct
		// _LOCALGROUP_USERS_INFO_0 { LPWSTR lgrui0_name; } LOCALGROUP_USERS_INFO_0, *PLOCALGROUP_USERS_INFO_0, *LPLOCALGROUP_USERS_INFO_0;
		[PInvokeData("lmaccess.h", MSDNShortId = "e9358f19-ec8f-4454-896c-c9fadb848378")]
		[StructLayout(LayoutKind.Sequential, CharSet = CharSet.Unicode)]
		public struct LOCALGROUP_USERS_INFO_0
		{
			/// <summary>Pointer to a Unicode string specifying the name of a local group to which the user belongs.</summary>
			public string lgrui0_name;
		}

		/// <summary>
		/// The <c>NET_DISPLAY_GROUP</c> structure contains information that an account manager can access to determine information about
		/// group accounts.
		/// </summary>
		// https://docs.microsoft.com/en-us/windows/desktop/api/lmaccess/ns-lmaccess-_net_display_group typedef struct _NET_DISPLAY_GROUP {
		// LPWSTR grpi3_name; LPWSTR grpi3_comment; DWORD grpi3_group_id; DWORD grpi3_attributes; DWORD grpi3_next_index; }
		// NET_DISPLAY_GROUP, *PNET_DISPLAY_GROUP;
		[PInvokeData("lmaccess.h", MSDNShortId = "8e467f20-2cfb-40ae-a8b2-a5350d736eed")]
		[StructLayout(LayoutKind.Sequential, CharSet = CharSet.Unicode)]
		public struct NET_DISPLAY_GROUP
		{
			/// <summary>
			/// <para>Type: <c>LPWSTR</c></para>
			/// <para>A pointer to a Unicode string that specifies the name of the group.</para>
			/// </summary>
			public string grpi3_name;

			/// <summary>
			/// <para>Type: <c>LPWSTR</c></para>
			/// <para>
			/// A pointer to a Unicode string that contains a comment associated with the group. This string can be a null string, or it can
			/// have any number of characters before the terminating null character.
			/// </para>
			/// </summary>
			public string grpi3_comment;

			/// <summary>
			/// <para>Type: <c>DWORD</c></para>
			/// <para>
			/// The relative identifier (RID) of the group. The relative identifier is determined by the accounts database when the group is
			/// created. It uniquely identifies the group to the account manager within the domain. The NetUserAdd and NetUserSetInfo
			/// functions ignore this member. For more information about RIDs, see SID Components.
			/// </para>
			/// </summary>
			public uint grpi3_group_id;

			/// <summary>
			/// <para>Type: <c>DWORD</c></para>
			/// <para>
			/// These attributes are hard-coded to SE_GROUP_MANDATORY, SE_GROUP_ENABLED, and SE_GROUP_ENABLED_BY_DEFAULT. For more
			/// information, see TOKEN_GROUPS.
			/// </para>
			/// </summary>
			public GroupAttributes grpi3_attributes;

			/// <summary>
			/// <para>Type: <c>DWORD</c></para>
			/// <para>
			/// The index of the last entry returned by the NetQueryDisplayInformation function. Pass this value as the Index parameter to
			/// <c>NetQueryDisplayInformation</c> to return the next logical entry. Note that you should not use the value of this member for
			/// any purpose except to retrieve more data with additional calls to <c>NetQueryDisplayInformation</c>.
			/// </para>
			/// </summary>
			public uint grpi3_next_index;
		}

		/// <summary>
		/// The <c>NET_DISPLAY_MACHINE</c> structure contains information that an account manager can access to determine information about
		/// computers and their attributes.
		/// </summary>
		// https://docs.microsoft.com/en-us/windows/desktop/api/lmaccess/ns-lmaccess-_net_display_machine typedef struct _NET_DISPLAY_MACHINE
		// { LPWSTR usri2_name; LPWSTR usri2_comment; DWORD usri2_flags; DWORD usri2_user_id; DWORD usri2_next_index; } NET_DISPLAY_MACHINE, *PNET_DISPLAY_MACHINE;
		[PInvokeData("lmaccess.h", MSDNShortId = "bdb1bef0-51f1-41d7-97fb-bda4ad24e386")]
		[StructLayout(LayoutKind.Sequential, CharSet = CharSet.Unicode)]
		public struct NET_DISPLAY_MACHINE
		{
			/// <summary>
			/// <para>Type: <c>LPWSTR</c></para>
			/// <para>A pointer to a Unicode string that specifies the name of the computer to access.</para>
			/// </summary>
			public string usri2_name;

			/// <summary>
			/// <para>Type: <c>LPWSTR</c></para>
			/// <para>
			/// A pointer to a Unicode string that contains a comment associated with the computer. This string can be a null string, or it
			/// can have any number of characters before the terminating null character.
			/// </para>
			/// </summary>
			public string usri2_comment;

			/// <summary>
			/// <para>Type: <c>DWORD</c></para>
			/// <para>
			/// A set of flags that contains values that determine several features. This member can be one or more of the following values.
			/// </para>
			/// <para>
			/// Note that setting user account control flags may require certain privileges and control access rights. For more information,
			/// see the Remarks section of the NetUserSetInfo function.
			/// </para>
			/// <list type="table">
			/// <listheader>
			/// <term>Value</term>
			/// <term>Meaning</term>
			/// </listheader>
			/// <item>
			/// <term>UF_SCRIPT</term>
			/// <term>The logon script executed. This value must be set.</term>
			/// </item>
			/// <item>
			/// <term>UF_ACCOUNTDISABLE</term>
			/// <term>The user's account is disabled.</term>
			/// </item>
			/// <item>
			/// <term>UF_PASSWD_NOTREQD</term>
			/// <term>No password is required.</term>
			/// </item>
			/// <item>
			/// <term>UF_PASSWD_CANT_CHANGE</term>
			/// <term>The user cannot change the password.</term>
			/// </item>
			/// <item>
			/// <term>UF_LOCKOUT</term>
			/// <term>
			/// The account is currently locked out (blocked). For the NetUserSetInfo function, this value can be cleared to unlock a
			/// previously locked account. This value cannot be used to lock a previously unlocked account.
			/// </term>
			/// </item>
			/// <item>
			/// <term>UF_DONT_EXPIRE_PASSWD</term>
			/// <term>Represents the password, which will never expire on the account.</term>
			/// </item>
			/// <item>
			/// <term>UF_TRUSTED_FOR_DELEGATION</term>
			/// <term>
			/// The account is enabled for delegation. This is a security-sensitive setting; accounts with this option enabled should be
			/// tightly controlled. This setting allows a service running under the account to assume a client's identity and authenticate as
			/// that user to other remote servers on the network.
			/// </term>
			/// </item>
			/// <item>
			/// <term>UF_ENCRYPTED_TEXT_PASSWORD_ALLOWED</term>
			/// <term>The user's password is stored under reversible encryption in the Active Directory.</term>
			/// </item>
			/// <item>
			/// <term>UF_NOT_DELEGATED</term>
			/// <term>Marks the account as "sensitive"; other users cannot act as delegates of this user account.</term>
			/// </item>
			/// <item>
			/// <term>UF_SMARTCARD_REQUIRED</term>
			/// <term>Requires the user to log on to the user account with a smart card.</term>
			/// </item>
			/// <item>
			/// <term>UF_USE_DES_KEY_ONLY</term>
			/// <term>Restrict this principal to use only Data Encryption Standard (DES) encryption types for keys.</term>
			/// </item>
			/// <item>
			/// <term>UF_DONT_REQUIRE_PREAUTH</term>
			/// <term>This account does not require Kerberos preauthentication for logon.</term>
			/// </item>
			/// <item>
			/// <term>UF_PASSWORD_EXPIRED</term>
			/// <term>The user's password has expired. Windows 2000: This value is not supported.</term>
			/// </item>
			/// <item>
			/// <term>UF_TRUSTED_TO_AUTHENTICATE_FOR_DELEGATION</term>
			/// <term>
			/// The account is trusted to authenticate a user outside of the Kerberos security package and delegate that user through
			/// constrained delegation. This is a security-sensitive setting; accounts with this option enabled should be tightly controlled.
			/// This setting allows a service running under the account to assert a client's identity and authenticate as that user to
			/// specifically configured services on the network. Windows XP/2000: This value is not supported.
			/// </term>
			/// </item>
			/// </list>
			/// <para>
			/// The following values describe the account type. Only one value can be set. You cannot change the account type using the
			/// NetUserSetInfo function.
			/// </para>
			/// <list type="table">
			/// <listheader>
			/// <term>Value</term>
			/// <term>Meaning</term>
			/// </listheader>
			/// <item>
			/// <term>UF_NORMAL_ACCOUNT</term>
			/// <term>A default account type that represents a typical user.</term>
			/// </item>
			/// <item>
			/// <term>UF_TEMP_DUPLICATE_ACCOUNT</term>
			/// <term>
			/// An account for users whose primary account is in another domain. This account provides user access to this domain, but not to
			/// any domain that trusts this domain. The User Manager refers to this account type as a local user account.
			/// </term>
			/// </item>
			/// <item>
			/// <term>UF_WORKSTATION_TRUST_ACCOUNT</term>
			/// <term>A computer account for a workstation or a server that is a member of this domain.</term>
			/// </item>
			/// <item>
			/// <term>UF_SERVER_TRUST_ACCOUNT</term>
			/// <term>A computer account for a backup domain controller that is a member of this domain.</term>
			/// </item>
			/// <item>
			/// <term>UF_INTERDOMAIN_TRUST_ACCOUNT</term>
			/// <term>A permit to trust account for a domain that trusts other domains.</term>
			/// </item>
			/// </list>
			/// </summary>
			public UserAcctCtrlFlags usri2_flags;

			/// <summary>
			/// <para>Type: <c>DWORD</c></para>
			/// <para>
			/// The relative identifier (RID) of the computer. The relative identifier is determined by the accounts database when the
			/// computer is defined. For more information about RIDS, see SID Components.
			/// </para>
			/// </summary>
			public uint usri2_user_id;

			/// <summary>
			/// <para>Type: <c>DWORD</c></para>
			/// <para>
			/// The index of the last entry returned by the NetQueryDisplayInformation function. Pass this value as the Index parameter to
			/// <c>NetQueryDisplayInformation</c> to return the next logical entry. Note that you should not use the value of this member for
			/// any purpose except to retrieve more data with additional calls to <c>NetQueryDisplayInformation</c>.
			/// </para>
			/// </summary>
			public uint usri2_next_index;
		}

		/// <summary>
		/// The <c>NET_DISPLAY_USER</c> structure contains information that an account manager can access to determine information about user accounts.
		/// </summary>
		// https://docs.microsoft.com/en-us/windows/desktop/api/lmaccess/ns-lmaccess-_net_display_user typedef struct _NET_DISPLAY_USER {
		// LPWSTR usri1_name; LPWSTR usri1_comment; DWORD usri1_flags; LPWSTR usri1_full_name; DWORD usri1_user_id; DWORD usri1_next_index; }
		// NET_DISPLAY_USER, *PNET_DISPLAY_USER;
		[PInvokeData("lmaccess.h", MSDNShortId = "308966f7-448c-4748-bbe7-9ac63afae1d9")]
		[StructLayout(LayoutKind.Sequential, CharSet = CharSet.Unicode)]
		public struct NET_DISPLAY_USER
		{
			/// <summary>
			/// <para>Type: <c>LPWSTR</c></para>
			/// <para>A pointer to a Unicode string that specifies the name of the user account.</para>
			/// </summary>
			public string usri1_name;

			/// <summary>
			/// <para>Type: <c>LPWSTR</c></para>
			/// <para>
			/// A pointer to a Unicode string that contains a comment associated with the user. This string can be a null string, or it can
			/// have any number of characters before the terminating null character (MAXCOMMENTSZ).
			/// </para>
			/// </summary>
			public string usri1_comment;

			/// <summary>
			/// <para>Type: <c>DWORD</c></para>
			/// <para>A set of user account flags. This member can be one or more of the following values.</para>
			/// <para>
			/// Note that setting user account control flags may require certain privileges and control access rights. For more information,
			/// see the Remarks section of the NetUserSetInfo function.
			/// </para>
			/// <list type="table">
			/// <listheader>
			/// <term>Value</term>
			/// <term>Meaning</term>
			/// </listheader>
			/// <item>
			/// <term>UF_SCRIPT</term>
			/// <term>The logon script executed. This value must be set.</term>
			/// </item>
			/// <item>
			/// <term>UF_ACCOUNTDISABLE</term>
			/// <term>The user's account is disabled.</term>
			/// </item>
			/// <item>
			/// <term>UF_PASSWD_NOTREQD</term>
			/// <term>No password is required.</term>
			/// </item>
			/// <item>
			/// <term>UF_PASSWD_CANT_CHANGE</term>
			/// <term>The user cannot change the password.</term>
			/// </item>
			/// <item>
			/// <term>UF_LOCKOUT</term>
			/// <term>
			/// The account is currently locked out (blocked). For the NetUserSetInfo function, this value can be cleared to unlock a
			/// previously locked account. This value cannot be used to lock a previously unlocked account.
			/// </term>
			/// </item>
			/// <item>
			/// <term>UF_DONT_EXPIRE_PASSWD</term>
			/// <term>The password will never expire on the account.</term>
			/// </item>
			/// <item>
			/// <term>UF_TRUSTED_FOR_DELEGATION</term>
			/// <term>
			/// The account is enabled for delegation. This is a security-sensitive setting; accounts with this option enabled should be
			/// tightly controlled. This setting allows a service running under the account to assume a client's identity and authenticate as
			/// that user to other remote servers on the network.
			/// </term>
			/// </item>
			/// <item>
			/// <term>UF_ENCRYPTED_TEXT_PASSWORD_ALLOWED</term>
			/// <term>The user's password is stored under reversible encryption in the Active Directory.</term>
			/// </item>
			/// <item>
			/// <term>UF_NOT_DELEGATED</term>
			/// <term>The account is marked as "sensitive"; other users cannot act as delegates of this user account.</term>
			/// </item>
			/// <item>
			/// <term>UF_SMARTCARD_REQUIRED</term>
			/// <term>The user is required to log on to the user account with a smart card.</term>
			/// </item>
			/// <item>
			/// <term>UF_USE_DES_KEY_ONLY</term>
			/// <term>This principal is restricted to use only Data Encryption Standard (DES) encryption types for keys.</term>
			/// </item>
			/// <item>
			/// <term>UF_DONT_REQUIRE_PREAUTH</term>
			/// <term>This account does not require Kerberos preauthentication for logon.</term>
			/// </item>
			/// <item>
			/// <term>UF_PASSWORD_EXPIRED</term>
			/// <term>The user's password has expired. Windows 2000: This value is not supported.</term>
			/// </item>
			/// <item>
			/// <term>UF_TRUSTED_TO_AUTHENTICATE_FOR_DELEGATION</term>
			/// <term>
			/// The account is trusted to authenticate a user outside of the Kerberos security package and delegate that user through
			/// constrained delegation. This is a security-sensitive setting; accounts with this option enabled should be tightly controlled.
			/// This setting allows a service running under the account to assert a client's identity and authenticate as that user to
			/// specifically configured services on the network. Windows XP/2000: This value is not supported.
			/// </term>
			/// </item>
			/// </list>
			/// <para>
			/// The following values describe the account type. Only one value can be set. You cannot change the account type using the
			/// NetUserSetInfo function.
			/// </para>
			/// <list type="table">
			/// <listheader>
			/// <term>Value</term>
			/// <term>Meaning</term>
			/// </listheader>
			/// <item>
			/// <term>UF_NORMAL_ACCOUNT</term>
			/// <term>This is a default account type that represents a typical user.</term>
			/// </item>
			/// <item>
			/// <term>UF_TEMP_DUPLICATE_ACCOUNT</term>
			/// <term>
			/// This is an account for users whose primary account is in another domain. This account provides user access to this domain,
			/// but not to any domain that trusts this domain. The User Manager refers to this account type as a local user account.
			/// </term>
			/// </item>
			/// <item>
			/// <term>UF_WORKSTATION_TRUST_ACCOUNT</term>
			/// <term>This is a computer account for a workstation or a server that is a member of this domain.</term>
			/// </item>
			/// <item>
			/// <term>UF_SERVER_TRUST_ACCOUNT</term>
			/// <term>This is a computer account for a backup domain controller that is a member of this domain.</term>
			/// </item>
			/// <item>
			/// <term>UF_INTERDOMAIN_TRUST_ACCOUNT</term>
			/// <term>This is a permit to trust account for a domain that trusts other domains.</term>
			/// </item>
			/// </list>
			/// </summary>
			public UserAcctCtrlFlags usri1_flags;

			/// <summary>
			/// <para>Type: <c>LPWSTR</c></para>
			/// <para>
			/// A pointer to a Unicode string that contains the full name of the user. This string can be a null string, or it can have any
			/// number of characters before the terminating null character.
			/// </para>
			/// </summary>
			public string usri1_full_name;

			/// <summary>
			/// <para>Type: <c>DWORD</c></para>
			/// <para>
			/// The relative identifier (RID) of the user. The relative identifier is determined by the accounts database when the user is
			/// created. It uniquely defines this user account to the account manager within the domain. For more information about relative
			/// identifiers, see SID Components.
			/// </para>
			/// </summary>
			public uint usri1_user_id;

			/// <summary>
			/// <para>Type: <c>DWORD</c></para>
			/// <para>
			/// The index of the last entry returned by the NetQueryDisplayInformation function. Pass this value as the Index parameter to
			/// <c>NetQueryDisplayInformation</c> to return the next logical entry. Note that you should not use the value of this member for
			/// any purpose except to retrieve more data with additional calls to <c>NetQueryDisplayInformation</c>.
			/// </para>
			/// </summary>
			public uint usri1_next_index;
		}

		/// <summary>
		/// A client application passes the <c>NET_VALIDATE_AUTHENTICATION_INPUT_ARG</c> structure to the NetValidatePasswordPolicy function
		/// when the application requests an authentication validation.
		/// </summary>
		// https://docs.microsoft.com/en-us/windows/desktop/api/lmaccess/ns-lmaccess-net_validate_authentication_input_arg typedef struct
		// _NET_VALIDATE_AUTHENTICATION_INPUT_ARG { NET_VALIDATE_PERSISTED_FIELDS InputPersistedFields; BOOLEAN PasswordMatched; }
		// NET_VALIDATE_AUTHENTICATION_INPUT_ARG, *PNET_VALIDATE_AUTHENTICATION_INPUT_ARG;
		[PInvokeData("lmaccess.h", MSDNShortId = "b7466e8a-81d8-4552-adff-47fc2f3ed3ad")]
		[StructLayout(LayoutKind.Sequential, CharSet = CharSet.Unicode)]
		public struct NET_VALIDATE_AUTHENTICATION_INPUT_ARG
		{
			/// <summary>
			/// Specifies a NET_VALIDATE_PERSISTED_FIELDS structure that contains persistent password-related information about the account
			/// being logged on.
			/// </summary>
			public NET_VALIDATE_PERSISTED_FIELDS InputPersistedFields;

			/// <summary>
			/// BOOLEAN value that indicates the result of the client application's authentication of the password supplied by the user. If
			/// this parameter is <c>FALSE</c>, the password has not been authenticated.
			/// </summary>
			[MarshalAs(UnmanagedType.U1)] public bool PasswordMatched;
		}

		/// <summary>
		/// The <c>NET_VALIDATE_OUTPUT_ARG</c> structure contains information about persistent password-related data that has changed since
		/// the user's last logon as well as the result of the function's password validation check.
		/// </summary>
		/// <remarks>
		/// <para>The NetValidatePasswordPolicy function outputs the <c>NET_VALIDATE_OUTPUT_ARG</c> structure.</para>
		/// <para>
		/// Note that it is the application's responsibility to save all the data in the <c>ChangedPersistedFields</c> member of the
		/// <c>NET_VALIDATE_OUTPUT_ARG</c> structure as well as any User object information. The next time the application calls
		/// NetValidatePasswordPolicy on the same instance of the User object, the application must provide the required fields from the
		/// persistent information.
		/// </para>
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows/desktop/api/lmaccess/ns-lmaccess-_net_validate_output_arg typedef struct
		// _NET_VALIDATE_OUTPUT_ARG { NET_VALIDATE_PERSISTED_FIELDS ChangedPersistedFields; NET_API_STATUS ValidationStatus; }
		// NET_VALIDATE_OUTPUT_ARG, *PNET_VALIDATE_OUTPUT_ARG;
		[PInvokeData("lmaccess.h", MSDNShortId = "833c89c3-34ba-485b-a310-1d709aa618cd")]
		[StructLayout(LayoutKind.Sequential, CharSet = CharSet.Unicode)]
		public struct NET_VALIDATE_OUTPUT_ARG
		{
			/// <summary>
			/// A structure that contains changes to persistent information about the account being logged on. For more information, see the
			/// following Remarks section.
			/// </summary>
			public NET_VALIDATE_PERSISTED_FIELDS ChangedPersistedFields;

			/// <summary>
			/// <para>
			/// The result of the password validation check performed by the NetValidatePasswordPolicy function. The status depends on the
			/// value specified in the ValidationType parameter to that function.
			/// </para>
			/// <para>
			/// <c>Authentication.</c> When you call NetValidatePasswordPolicy and specify the ValidationType parameter as
			/// NetValidateAuthentication, this member can be one of the following values.
			/// </para>
			/// <list type="table">
			/// <listheader>
			/// <term>Value</term>
			/// <term>Meaning</term>
			/// </listheader>
			/// <item>
			/// <term>NERR_AccountLockedOut</term>
			/// <term>Validation failed. The account is locked out.</term>
			/// </item>
			/// <item>
			/// <term>NERR_PasswordMustChange</term>
			/// <term>Validation failed. The password must change at the next logon.</term>
			/// </item>
			/// <item>
			/// <term>NERR_PasswordExpired</term>
			/// <term>Validation failed. The password has expired.</term>
			/// </item>
			/// <item>
			/// <term>NERR_BadPassword</term>
			/// <term>Validation failed. The password is invalid.</term>
			/// </item>
			/// <item>
			/// <term>NERR_Success</term>
			/// <term>The password passes the validation check.</term>
			/// </item>
			/// </list>
			/// <para>
			/// <c>Password change.</c> When you call NetValidatePasswordPolicy and specify the ValidationType parameter as
			/// NetValidatePasswordChange, this member can be one of the following values.
			/// </para>
			/// <list type="table">
			/// <listheader>
			/// <term>Value</term>
			/// <term>Meaning</term>
			/// </listheader>
			/// <item>
			/// <term>NERR_AccountLockedOut</term>
			/// <term>Validation failed. The account is locked out.</term>
			/// </item>
			/// <item>
			/// <term>NERR_PasswordTooRecent</term>
			/// <term>Validation failed. The password for the user is too recent to change.</term>
			/// </item>
			/// <item>
			/// <term>NERR_BadPassword</term>
			/// <term>Validation failed. The password is invalid.</term>
			/// </item>
			/// <item>
			/// <term>NERR_PasswordHistConflict</term>
			/// <term>Validation failed. The password cannot be used at this time.</term>
			/// </item>
			/// <item>
			/// <term>NERR_PasswordTooShort</term>
			/// <term>Validation failed. The password does not meet policy requirements because it is too short.</term>
			/// </item>
			/// <item>
			/// <term>NERR_PasswordTooLong</term>
			/// <term>Validation failed. The password does not meet policy requirements because it is too long.</term>
			/// </item>
			/// <item>
			/// <term>NERR_PasswordNotComplexEnough</term>
			/// <term>Validation failed. The password does not meet policy requirements because it is not complex enough.</term>
			/// </item>
			/// <item>
			/// <term>NERR_PasswordFilterError</term>
			/// <term>Validation failed. The password does not meet the requirements of the password filter DLL.</term>
			/// </item>
			/// <item>
			/// <term>NERR_Success</term>
			/// <term>The password passes the validation check.</term>
			/// </item>
			/// </list>
			/// <para>
			/// <c>Password reset.</c> When you call <c>NetValidatePasswordPolicy</c> and specify the ValidationType parameter as
			/// NetValidatePasswordReset, this member can be one of the following values.
			/// </para>
			/// <list type="table">
			/// <listheader>
			/// <term>Value</term>
			/// <term>Meaning</term>
			/// </listheader>
			/// <item>
			/// <term>NERR_PasswordTooShort</term>
			/// <term>Validation failed. The password does not meet policy requirements because it is too short.</term>
			/// </item>
			/// <item>
			/// <term>NERR_PasswordTooLong</term>
			/// <term>Validation failed. The password does not meet policy requirements because it is too long.</term>
			/// </item>
			/// <item>
			/// <term>NERR_PasswordNotComplexEnough</term>
			/// <term>Validation failed. The password does not meet policy requirements because it is not complex enough.</term>
			/// </item>
			/// <item>
			/// <term>NERR_PasswordFilterError</term>
			/// <term>Validation failed. The password does not meet the requirements of the password filter DLL.</term>
			/// </item>
			/// <item>
			/// <term>NERR_Success</term>
			/// <term>The password passes the validation check.</term>
			/// </item>
			/// </list>
			/// </summary>
			public Win32Error ValidationStatus;
		}

		/// <summary>
		/// A client application passes the <c>NET_VALIDATE_PASSWORD_CHANGE_INPUT_ARG</c> structure to the NetValidatePasswordPolicy function
		/// when the application requests a password change validation.
		/// </summary>
		// https://docs.microsoft.com/en-us/windows/desktop/api/lmaccess/ns-lmaccess-net_validate_password_change_input_arg typedef struct
		// _NET_VALIDATE_PASSWORD_CHANGE_INPUT_ARG { NET_VALIDATE_PERSISTED_FIELDS InputPersistedFields; LPWSTR ClearPassword; LPWSTR
		// UserAccountName; NET_VALIDATE_PASSWORD_HASH HashedPassword; BOOLEAN PasswordMatch; } NET_VALIDATE_PASSWORD_CHANGE_INPUT_ARG, *PNET_VALIDATE_PASSWORD_CHANGE_INPUT_ARG;
		[PInvokeData("lmaccess.h", MSDNShortId = "09404998-81c5-400c-9d99-a0a4bb4095bf")]
		[StructLayout(LayoutKind.Sequential, CharSet = CharSet.Unicode)]
		public struct NET_VALIDATE_PASSWORD_CHANGE_INPUT_ARG
		{
			/// <summary>
			/// Specifies a NET_VALIDATE_PERSISTED_FIELDS structure that contains persistent password-related information about the account
			/// being logged on.
			/// </summary>
			public NET_VALIDATE_PERSISTED_FIELDS InputPersistedFields;

			/// <summary>Pointer to a Unicode string specifying the new password, in plaintext format.</summary>
			public string ClearPassword;

			/// <summary>Pointer to a Unicode string specifying the name of the user account.</summary>
			public string UserAccountName;

			/// <summary>Specifies a NET_VALIDATE_PASSWORD_HASH structure that contains a hash of the new password.</summary>
			public NET_VALIDATE_PASSWORD_HASH HashedPassword;

			/// <summary>
			/// BOOLEAN value that indicates the result of the client application's authentication of the password supplied by the user. If
			/// this parameter is <c>FALSE</c>, the password has not been authenticated.
			/// </summary>
			[MarshalAs(UnmanagedType.U1)] public bool PasswordMatch;
		}

		/// <summary>The <c>NET_VALIDATE_PASSWORD_HASH</c> structure contains a password hash.</summary>
		/// <remarks>
		/// The NET_VALIDATE_PASSWORD_RESET_INPUT_ARG and NET_VALIDATE_PASSWORD_CHANGE_INPUT_ARG structures contain a
		/// <c>NET_VALIDATE_PASSWORD_HASH</c> structure. The NET_VALIDATE_PERSISTED_FIELDS structure contains a pointer to this structure.
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows/desktop/api/lmaccess/ns-lmaccess-_net_validate_password_hash typedef struct
		// _NET_VALIDATE_PASSWORD_HASH { ULONG Length; LPBYTE Hash; } NET_VALIDATE_PASSWORD_HASH, *PNET_VALIDATE_PASSWORD_HASH;
		[PInvokeData("lmaccess.h", MSDNShortId = "884e5b8c-1288-454e-862d-323d79123356")]
		[StructLayout(LayoutKind.Sequential, CharSet = CharSet.Unicode)]
		public struct NET_VALIDATE_PASSWORD_HASH
		{
			/// <summary>Specifies the length of this structure.</summary>
			public uint Length;

			/// <summary>Password hash.</summary>
			public IntPtr Hash;
		}

		/// <summary>
		/// A client application passes the <c>NET_VALIDATE_PASSWORD_RESET_INPUT_ARG</c> structure to the NetValidatePasswordPolicy function
		/// when the application requests a password reset validation.
		/// </summary>
		// https://docs.microsoft.com/en-us/windows/desktop/api/lmaccess/ns-lmaccess-net_validate_password_reset_input_arg typedef struct
		// _NET_VALIDATE_PASSWORD_RESET_INPUT_ARG { NET_VALIDATE_PERSISTED_FIELDS InputPersistedFields; LPWSTR ClearPassword; LPWSTR
		// UserAccountName; NET_VALIDATE_PASSWORD_HASH HashedPassword; BOOLEAN PasswordMustChangeAtNextLogon; BOOLEAN ClearLockout; }
		// NET_VALIDATE_PASSWORD_RESET_INPUT_ARG, *PNET_VALIDATE_PASSWORD_RESET_INPUT_ARG;
		[PInvokeData("lmaccess.h", MSDNShortId = "3a6d4c2d-0d90-48bf-9dfa-2ba587538350")]
		[StructLayout(LayoutKind.Sequential, CharSet = CharSet.Unicode)]
		public struct NET_VALIDATE_PASSWORD_RESET_INPUT_ARG
		{
			/// <summary>
			/// Specifies a NET_VALIDATE_PERSISTED_FIELDS structure that contains persistent password-related information about the account
			/// being logged on.
			/// </summary>
			public NET_VALIDATE_PERSISTED_FIELDS InputPersistedFields;

			/// <summary>Pointer to a Unicode string specifying the new password, in plaintext format.</summary>
			public string ClearPassword;

			/// <summary>Pointer to a Unicode string specifying the name of the user account.</summary>
			public string UserAccountName;

			/// <summary>Specifies a NET_VALIDATE_PASSWORD_HASH structure that contains a hash of the new password.</summary>
			public NET_VALIDATE_PASSWORD_HASH HashedPassword;

			/// <summary>
			/// BOOLEAN value that indicates whether the user must change his or her password at the next logon. If this parameter is
			/// <c>TRUE</c>, the user must change the password at the next logon.
			/// </summary>
			[MarshalAs(UnmanagedType.U1)] public bool PasswordMustChangeAtNextLogon;

			/// <summary>
			/// BOOLEAN value that can reset the "lockout state" of the user account. If this member is <c>TRUE</c>, the account will no
			/// longer be locked out. Note that an application cannot directly lock out an account. An account can be locked out only as a
			/// result of exceeding the maximum number of invalid password authentications allowed for the account.
			/// </summary>
			[MarshalAs(UnmanagedType.U1)] public bool ClearLockout;
		}

		/// <summary>
		/// The <c>NET_VALIDATE_PERSISTED_FIELDS</c> structure contains information about a user's password properties. Input to and output
		/// from the NetValidatePasswordPolicy function contain persistent password-related data. When the function outputs this structure,
		/// it identifies the persistent data that has changed in this call.
		/// </summary>
		/// <remarks>
		/// <para>
		/// Note that it is the application's responsibility to save all changed persistent data as well as any user object information. The
		/// next time the application calls NetValidatePasswordPolicy on the same instance of the user object, the application must provide
		/// the required fields from the persistent information.
		/// </para>
		/// <para>
		/// The NET_VALIDATE_AUTHENTICATION_INPUT_ARG, NET_VALIDATE_PASSWORD_CHANGE_INPUT_ARG, NET_VALIDATE_PASSWORD_RESET_INPUT_ARG, and
		/// NET_VALIDATE_OUTPUT_ARG structures contain a <c>NET_VALIDATE_PERSISTED_FIELDS</c> structure.
		/// </para>
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows/desktop/api/lmaccess/ns-lmaccess-_net_validate_persisted_fields typedef struct
		// _NET_VALIDATE_PERSISTED_FIELDS { ULONG PresentFields; FILETIME PasswordLastSet; FILETIME BadPasswordTime; FILETIME LockoutTime;
		// ULONG BadPasswordCount; ULONG PasswordHistoryLength; PNET_VALIDATE_PASSWORD_HASH PasswordHistory; } NET_VALIDATE_PERSISTED_FIELDS, *PNET_VALIDATE_PERSISTED_FIELDS;
		[PInvokeData("lmaccess.h", MSDNShortId = "1e6ea28a-a007-4cd1-b5d6-686bcf019fa1")]
		[StructLayout(LayoutKind.Sequential, CharSet = CharSet.Unicode)]
		public struct NET_VALIDATE_PERSISTED_FIELDS
		{
			/// <summary>
			/// <para>Type: <c>ULONG</c></para>
			/// <para>
			/// A set of bit flags identifying the persistent password-related data that has changed. This member is valid only when this
			/// structure is output from the <c>NetValidatePasswordPolicy</c> function. This member is ignored when this structure is input
			/// to the function. For more information, see the following Remarks section.
			/// </para>
			/// <list type="table">
			/// <listheader>
			/// <term>Value</term>
			/// <term>Meaning</term>
			/// </listheader>
			/// <item>
			/// <term>NET_VALIDATE_PASSWORD_LAST_SET</term>
			/// <term>The PasswordLastSet member contains a new value.</term>
			/// </item>
			/// <item>
			/// <term>NET_VALIDATE_BAD_PASSWORD_TIME</term>
			/// <term>The BadPasswordTime member contains a new value.</term>
			/// </item>
			/// <item>
			/// <term>NET_VALIDATE_LOCKOUT_TIME</term>
			/// <term>The LockoutTime member contains a new value.</term>
			/// </item>
			/// <item>
			/// <term>NET_VALIDATE_BAD_PASSWORD_COUNT</term>
			/// <term>The BadPasswordCount member contains a new value.</term>
			/// </item>
			/// <item>
			/// <term>NET_VALIDATE_PASSWORD_HISTORY_LENGTH</term>
			/// <term>The PasswordHistoryLength member contains a new value.</term>
			/// </item>
			/// <item>
			/// <term>NET_VALIDATE_PASSWORD_HISTORY</term>
			/// <term>The PasswordHistory member contains a new value.</term>
			/// </item>
			/// </list>
			/// </summary>
			public uint PresentFields;

			/// <summary>
			/// <para>Type: <c>FILETIME</c></para>
			/// <para>The date and time (in GMT) when the password for the account was set or last changed.</para>
			/// </summary>
			public FILETIME PasswordLastSet;

			/// <summary>
			/// <para>Type: <c>FILETIME</c></para>
			/// <para>The date and time (in GMT) when the user tried to log on to the account using an incorrect password.</para>
			/// </summary>
			public FILETIME BadPasswordTime;

			/// <summary>
			/// <para>Type: <c>FILETIME</c></para>
			/// <para>
			/// The date and time (in GMT) when the account was last locked out. If the account has not been locked out, this member is zero.
			/// A lockout occurs when the number of bad password logins exceeds the number allowed.
			/// </para>
			/// </summary>
			public FILETIME LockoutTime;

			/// <summary>
			/// <para>Type: <c>ULONG</c></para>
			/// <para>The number of times the user tried to log on to the account using an incorrect password.</para>
			/// </summary>
			public uint BadPasswordCount;

			/// <summary>
			/// <para>Type: <c>ULONG</c></para>
			/// <para>
			/// The number of previous passwords saved in the history list for the account. The user cannot reuse a password in the history list.
			/// </para>
			/// </summary>
			public uint PasswordHistoryLength;

			/// <summary>
			/// <para>Type: <c>PNET_VALIDATE_PASSWORD_HASH</c></para>
			/// <para>A pointer to a NET_VALIDATE_PASSWORD_HASH structure that contains the password hashes in the history list.</para>
			/// </summary>
			public IntPtr PasswordHistory;
		}

		/// <summary>The <c>USER_INFO_0</c> structure contains a user account name.</summary>
		/// <remarks>
		/// User account names are limited to 20 characters and group names are limited to 256 characters. In addition, account names cannot
		/// be terminated by a period and they cannot include commas or any of the following printable characters: ", /, , [, ], :, |, &lt;,
		/// &gt;, +, =, ;, ?, *. Names also cannot include characters in the range 1-31, which are non-printable.
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows/desktop/api/lmaccess/ns-lmaccess-_user_info_0 typedef struct _USER_INFO_0 { LPWSTR
		// usri0_name; } USER_INFO_0, *PUSER_INFO_0, *LPUSER_INFO_0;
		[PInvokeData("lmaccess.h", MSDNShortId = "5d24a2dd-d1ee-4c97-8fbc-0b336313b60c")]
		[StructLayout(LayoutKind.Sequential, CharSet = CharSet.Unicode)]
		public struct USER_INFO_0
		{
			/// <summary>
			/// Pointer to a Unicode string that specifies the name of the user account. For the NetUserSetInfo function, this member
			/// specifies the name of the user.
			/// </summary>
			public string usri0_name;
		}

		/// <summary>
		/// The <c>USER_INFO_1</c> structure contains information about a user account, including account name, password data, privilege
		/// level, and the path to the user's home directory.
		/// </summary>
		/// <remarks>
		/// User account names are limited to 20 characters and group names are limited to 256 characters. In addition, account names cannot
		/// be terminated by a period and they cannot include commas or any of the following printable characters: ", /, , [, ], :, |, &lt;,
		/// &gt;, +, =, ;, ?, *. Names also cannot include characters in the range 1-31, which are non-printable.
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows/desktop/api/lmaccess/ns-lmaccess-_user_info_1 typedef struct _USER_INFO_1 { LPWSTR
		// usri1_name; LPWSTR usri1_password; DWORD usri1_password_age; DWORD usri1_priv; LPWSTR usri1_home_dir; LPWSTR usri1_comment; DWORD
		// usri1_flags; LPWSTR usri1_script_path; } USER_INFO_1, *PUSER_INFO_1, *LPUSER_INFO_1;
		[PInvokeData("lmaccess.h", MSDNShortId = "f17a1aef-45f1-461f-975d-75221d08277c")]
		[StructLayout(LayoutKind.Sequential, CharSet = CharSet.Unicode)]
		public struct USER_INFO_1
		{
			/// <summary>
			/// <para>Type: <c>LPWSTR</c></para>
			/// <para>
			/// A pointer to a Unicode string that specifies the name of the user account. For the NetUserSetInfo function, this member is
			/// ignored. For more information, see the following Remarks section.
			/// </para>
			/// </summary>
			public string usri1_name;

			/// <summary>
			/// <para>Type: <c>LPWSTR</c></para>
			/// <para>
			/// A pointer to a Unicode string that specifies the password of the user indicated by the <c>usri1_name</c> member. The length
			/// cannot exceed PWLEN bytes. The NetUserEnum and NetUserGetInfo functions return a <c>NULL</c> pointer to maintain password security.
			/// </para>
			/// <para>By convention, the length of passwords is limited to LM20_PWLEN characters.</para>
			/// </summary>
			public string usri1_password;

			/// <summary>
			/// <para>Type: <c>DWORD</c></para>
			/// <para>
			/// The number of seconds that have elapsed since the <c>usri1_password</c> member was last changed. The NetUserAdd and
			/// NetUserSetInfo functions ignore this member.
			/// </para>
			/// </summary>
			public uint usri1_password_age;

			/// <summary>
			/// <para>Type: <c>DWORD</c></para>
			/// <para>
			/// The level of privilege assigned to the <c>usri1_name</c> member. When you call the NetUserAdd function, this member must be
			/// USER_PRIV_USER. When you call the NetUserSetInfo function, this member must be the value returned by the
			/// <c>NetUserGetInfo</c> function or the <c>NetUserEnum</c> function. This member can be one of the following values. For more
			/// information about user and group account rights, see Privileges.
			/// </para>
			/// <list type="table">
			/// <listheader>
			/// <term>Value</term>
			/// <term>Meaning</term>
			/// </listheader>
			/// <item>
			/// <term>USER_PRIV_GUEST</term>
			/// <term>Guest</term>
			/// </item>
			/// <item>
			/// <term>USER_PRIV_USER</term>
			/// <term>User</term>
			/// </item>
			/// <item>
			/// <term>USER_PRIV_ADMIN</term>
			/// <term>Administrator</term>
			/// </item>
			/// </list>
			/// </summary>
			public UserPrivilege usri1_priv;

			/// <summary>
			/// <para>Type: <c>LPWSTR</c></para>
			/// <para>
			/// A pointer to a Unicode string specifying the path of the home directory for the user specified in the <c>usri1_name</c>
			/// member. The string can be <c>NULL</c>.
			/// </para>
			/// </summary>
			public string usri1_home_dir;

			/// <summary>
			/// <para>Type: <c>LPWSTR</c></para>
			/// <para>
			/// A pointer to a Unicode string that contains a comment to associate with the user account. This string can be a <c>NULL</c>
			/// string, or it can have any number of characters before the terminating null character.
			/// </para>
			/// </summary>
			public string usri1_comment;

			/// <summary>
			/// <para>Type: <c>DWORD</c></para>
			/// <para>This member can be one or more of the following values.</para>
			/// <para>
			/// Note that setting user account control flags may require certain privileges and control access rights. For more information,
			/// see the Remarks section of the NetUserSetInfo function.
			/// </para>
			/// <list type="table">
			/// <listheader>
			/// <term>Value</term>
			/// <term>Meaning</term>
			/// </listheader>
			/// <item>
			/// <term>UF_SCRIPT</term>
			/// <term>The logon script executed. This value must be set.</term>
			/// </item>
			/// <item>
			/// <term>UF_ACCOUNTDISABLE</term>
			/// <term>The user's account is disabled.</term>
			/// </item>
			/// <item>
			/// <term>UF_HOMEDIR_REQUIRED</term>
			/// <term>The home directory is required. This value is ignored.</term>
			/// </item>
			/// <item>
			/// <term>UF_PASSWD_NOTREQD</term>
			/// <term>No password is required.</term>
			/// </item>
			/// <item>
			/// <term>UF_PASSWD_CANT_CHANGE</term>
			/// <term>The user cannot change the password.</term>
			/// </item>
			/// <item>
			/// <term>UF_LOCKOUT</term>
			/// <term>
			/// The account is currently locked out. You can call the NetUserSetInfo function and clear this value to unlock a previously
			/// locked account. You cannot use this value to lock a previously unlocked account.
			/// </term>
			/// </item>
			/// <item>
			/// <term>UF_DONT_EXPIRE_PASSWD</term>
			/// <term>The password should never expire on the account.</term>
			/// </item>
			/// <item>
			/// <term>UF_ENCRYPTED_TEXT_PASSWORD_ALLOWED</term>
			/// <term>The user's password is stored under reversible encryption in the Active Directory.</term>
			/// </item>
			/// <item>
			/// <term>UF_NOT_DELEGATED</term>
			/// <term>Marks the account as "sensitive"; other users cannot act as delegates of this user account.</term>
			/// </item>
			/// <item>
			/// <term>UF_SMARTCARD_REQUIRED</term>
			/// <term>Requires the user to log on to the user account with a smart card.</term>
			/// </item>
			/// <item>
			/// <term>UF_USE_DES_KEY_ONLY</term>
			/// <term>Restrict this principal to use only Data Encryption Standard (DES) encryption types for keys.</term>
			/// </item>
			/// <item>
			/// <term>UF_DONT_REQUIRE_PREAUTH</term>
			/// <term>This account does not require Kerberos preauthentication for logon.</term>
			/// </item>
			/// <item>
			/// <term>UF_TRUSTED_FOR_DELEGATION</term>
			/// <term>
			/// The account is enabled for delegation. This is a security-sensitive setting; accounts with this option enabled should be
			/// tightly controlled. This setting allows a service running under the account to assume a client's identity and authenticate as
			/// that user to other remote servers on the network.
			/// </term>
			/// </item>
			/// <item>
			/// <term>UF_PASSWORD_EXPIRED</term>
			/// <term>The user's password has expired. Windows 2000: This value is not supported.</term>
			/// </item>
			/// <item>
			/// <term>UF_TRUSTED_TO_AUTHENTICATE_FOR_DELEGATION</term>
			/// <term>
			/// The account is trusted to authenticate a user outside of the Kerberos security package and delegate that user through
			/// constrained delegation. This is a security-sensitive setting; accounts with this option enabled should be tightly controlled.
			/// This setting allows a service running under the account to assert a client's identity and authenticate as that user to
			/// specifically configured services on the network. Windows 2000: This value is not supported.
			/// </term>
			/// </item>
			/// </list>
			/// <para>
			/// The following values describe the account type. Only one value can be set. You cannot change the account type using the
			/// NetUserSetInfo function.
			/// </para>
			/// <list type="table">
			/// <listheader>
			/// <term>Value</term>
			/// <term>Meaning</term>
			/// </listheader>
			/// <item>
			/// <term>UF_NORMAL_ACCOUNT</term>
			/// <term>This is a default account type that represents a typical user.</term>
			/// </item>
			/// <item>
			/// <term>UF_TEMP_DUPLICATE_ACCOUNT</term>
			/// <term>
			/// This is an account for users whose primary account is in another domain. This account provides user access to this domain,
			/// but not to any domain that trusts this domain. The User Manager refers to this account type as a local user account.
			/// </term>
			/// </item>
			/// <item>
			/// <term>UF_WORKSTATION_TRUST_ACCOUNT</term>
			/// <term>This is a computer account for a computer that is a member of this domain.</term>
			/// </item>
			/// <item>
			/// <term>UF_SERVER_TRUST_ACCOUNT</term>
			/// <term>This is a computer account for a backup domain controller that is a member of this domain.</term>
			/// </item>
			/// <item>
			/// <term>UF_INTERDOMAIN_TRUST_ACCOUNT</term>
			/// <term>This is a permit to trust account for a domain that trusts other domains.</term>
			/// </item>
			/// </list>
			/// </summary>
			public UserAcctCtrlFlags usri1_flags;

			/// <summary>
			/// <para>Type: <c>LPWSTR</c></para>
			/// <para>
			/// A pointer to a Unicode string specifying the path for the user's logon script file. The script file can be a .CMD file, an
			/// .EXE file, or a .BAT file. The string can also be <c>NULL</c>.
			/// </para>
			/// </summary>
			public string usri1_script_path;
		}

		/// <summary>
		/// The <c>USER_INFO_10</c> structure contains information about a user account, including the account name, comments associated with
		/// the account, and the user's full name.
		/// </summary>
		/// <remarks>
		/// User account names are limited to 20 characters and group names are limited to 256 characters. In addition, account names cannot
		/// be terminated by a period and they cannot include commas or any of the following printable characters: ", /, , [, ], :, |, &lt;,
		/// &gt;, +, =, ;, ?, *. Names also cannot include characters in the range 1-31, which are non-printable.
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows/desktop/api/lmaccess/ns-lmaccess-_user_info_10 typedef struct _USER_INFO_10 { LPWSTR
		// usri10_name; LPWSTR usri10_comment; LPWSTR usri10_usr_comment; LPWSTR usri10_full_name; } USER_INFO_10, *PUSER_INFO_10, *LPUSER_INFO_10;
		[PInvokeData("lmaccess.h", MSDNShortId = "f85e3e92-02b2-4ee8-8a82-38e4ef5b4072")]
		[StructLayout(LayoutKind.Sequential, CharSet = CharSet.Unicode)]
		public struct USER_INFO_10
		{
			/// <summary>
			/// Pointer to a Unicode string that specifies the name of the user account. Calls to the NetUserSetInfo function ignore this
			/// member. For more information, see the following Remarks section.
			/// </summary>
			public string usri10_name;

			/// <summary>
			/// Pointer to a Unicode string that contains a comment associated with the user account. The string can be a null string, or can
			/// have any number of characters before the terminating null character.
			/// </summary>
			public string usri10_comment;

			/// <summary>
			/// Pointer to a Unicode string that contains a user comment. This string can be a null string, or it can have any number of
			/// characters before the terminating null character.
			/// </summary>
			public string usri10_usr_comment;

			/// <summary>
			/// Pointer to a Unicode string that contains the full name of the user. This string can be a null string, or it can have any
			/// number of characters before the terminating null character.
			/// </summary>
			public string usri10_full_name;
		}

		/// <summary>
		/// The <c>USER_INFO_1003</c> structure contains a user password. This information level is valid only when you call the
		/// NetUserSetInfo function.
		/// </summary>
		/// <remarks>By convention, the length of passwords is limited to LM20_PWLEN characters.</remarks>
		// https://docs.microsoft.com/en-us/windows/desktop/api/lmaccess/ns-lmaccess-_user_info_1003 typedef struct _USER_INFO_1003 { LPWSTR
		// usri1003_password; } USER_INFO_1003, *PUSER_INFO_1003, *LPUSER_INFO_1003;
		[PInvokeData("lmaccess.h", MSDNShortId = "ef1d1ecd-7226-4e4e-a0b3-ec096d3b1207")]
		[StructLayout(LayoutKind.Sequential, CharSet = CharSet.Unicode)]
		public struct USER_INFO_1003
		{
			/// <summary>
			/// Specifies a Unicode string that contains the password for the user account specified in the username parameter to the
			/// <c>NetUserSetInfo</c> function. The length cannot exceed PWLEN bytes.
			/// </summary>
			public string usri1003_password;
		}

		/// <summary>
		/// The <c>USER_INFO_1005</c> structure contains a privilege level to assign to a user network account. This information level is
		/// valid only when you call the NetUserSetInfo function.
		/// </summary>
		// https://docs.microsoft.com/en-us/windows/desktop/api/lmaccess/ns-lmaccess-_user_info_1005 typedef struct _USER_INFO_1005 { DWORD
		// usri1005_priv; } USER_INFO_1005, *PUSER_INFO_1005, *LPUSER_INFO_1005;
		[PInvokeData("lmaccess.h", MSDNShortId = "a953b48f-bda0-4dce-a153-d4db912de533")]
		[StructLayout(LayoutKind.Sequential, CharSet = CharSet.Unicode)]
		public struct USER_INFO_1005
		{
			/// <summary>
			/// <para>
			/// Specifies a <c>DWORD</c> value that indicates the level of privilege to assign for the user account specified in the username
			/// parameter to the <c>NetUserSetInfo</c> function. This member can be one of the following values. For more information about
			/// user and group account rights, see Privileges.
			/// </para>
			/// <list type="table">
			/// <listheader>
			/// <term>Value</term>
			/// <term>Meaning</term>
			/// </listheader>
			/// <item>
			/// <term>USER_PRIV_GUEST</term>
			/// <term>Guest</term>
			/// </item>
			/// <item>
			/// <term>USER_PRIV_USER</term>
			/// <term>User</term>
			/// </item>
			/// <item>
			/// <term>USER_PRIV_ADMIN</term>
			/// <term>Administrator</term>
			/// </item>
			/// </list>
			/// </summary>
			public UserPrivilege usri1005_priv;
		}

		/// <summary>
		/// The <c>USER_INFO_1006</c> structure contains the user's home directory path. This information level is valid only when you call
		/// the NetUserSetInfo function.
		/// </summary>
		// https://docs.microsoft.com/en-us/windows/desktop/api/lmaccess/ns-lmaccess-_user_info_1006 typedef struct _USER_INFO_1006 { LPWSTR
		// usri1006_home_dir; } USER_INFO_1006, *PUSER_INFO_1006, *LPUSER_INFO_1006;
		[PInvokeData("lmaccess.h", MSDNShortId = "9eb4973b-cda5-4862-b558-3af90b7de19f")]
		[StructLayout(LayoutKind.Sequential, CharSet = CharSet.Unicode)]
		public struct USER_INFO_1006
		{
			/// <summary>
			/// Pointer to a Unicode string specifying the path of the home directory for the user account specified in the username
			/// parameter to the <c>NetUserSetInfo</c> function. The string can be null.
			/// </summary>
			public string usri1006_home_dir;
		}

		/// <summary>
		/// The <c>USER_INFO_1007</c> structure contains a comment associated with a user network account. This information level is valid
		/// only when you call the NetUserSetInfo function.
		/// </summary>
		// https://docs.microsoft.com/en-us/windows/desktop/api/lmaccess/ns-lmaccess-_user_info_1007 typedef struct _USER_INFO_1007 { LPWSTR
		// usri1007_comment; } USER_INFO_1007, *PUSER_INFO_1007, *LPUSER_INFO_1007;
		[PInvokeData("lmaccess.h", MSDNShortId = "a2e49802-799d-4f98-aa6d-5cb1478cb4d4")]
		[StructLayout(LayoutKind.Sequential, CharSet = CharSet.Unicode)]
		public struct USER_INFO_1007
		{
			/// <summary>
			/// Pointer to a Unicode string that contains a comment to associate with the user account specified in the username parameter to
			/// the <c>NetUserSetInfo</c> function. This string can be a null string, or it can have any number of characters before the
			/// terminating null character.
			/// </summary>
			public string usri1007_comment;
		}

		/// <summary>
		/// The <c>USER_INFO_1008</c> structure contains a set of bit flags defining several user network account parameters. This
		/// information level is valid only when you call the NetUserSetInfo function.
		/// </summary>
		// https://docs.microsoft.com/en-us/windows/desktop/api/lmaccess/ns-lmaccess-_user_info_1008 typedef struct _USER_INFO_1008 { DWORD
		// usri1008_flags; } USER_INFO_1008, *PUSER_INFO_1008, *LPUSER_INFO_1008;
		[PInvokeData("lmaccess.h", MSDNShortId = "142408ef-ed8e-4af3-8fc2-ffdd40ce4f1e")]
		[StructLayout(LayoutKind.Sequential, CharSet = CharSet.Unicode)]
		public struct USER_INFO_1008
		{
			/// <summary>
			/// <para>
			/// The features to associate with the user account specified in the username parameter to the <c>NetUserSetInfo</c> function.
			/// This member can be one or more of the following values.
			/// </para>
			/// <para>
			/// Note that setting user account control flags may require certain privileges and control access rights. For more information,
			/// see the Remarks section of the NetUserSetInfo function.
			/// </para>
			/// <list type="table">
			/// <listheader>
			/// <term>Value</term>
			/// <term>Meaning</term>
			/// </listheader>
			/// <item>
			/// <term>UF_SCRIPT</term>
			/// <term>The logon script executed. This value must be set.</term>
			/// </item>
			/// <item>
			/// <term>UF_ACCOUNTDISABLE</term>
			/// <term>The user's account is disabled.</term>
			/// </item>
			/// <item>
			/// <term>UF_HOMEDIR_REQUIRED</term>
			/// <term>The home directory is required. This value is ignored.</term>
			/// </item>
			/// <item>
			/// <term>UF_PASSWD_NOTREQD</term>
			/// <term>No password is required.</term>
			/// </item>
			/// <item>
			/// <term>UF_PASSWD_CANT_CHANGE</term>
			/// <term>The user cannot change the password.</term>
			/// </item>
			/// <item>
			/// <term>UF_LOCKOUT</term>
			/// <term>
			/// The account is currently locked out. You can call the NetUserSetInfo function to clear this value and unlock a previously
			/// locked account. You cannot use this value to lock a previously unlocked account.
			/// </term>
			/// </item>
			/// <item>
			/// <term>UF_DONT_EXPIRE_PASSWD</term>
			/// <term>The password should never expire on the account.</term>
			/// </item>
			/// <item>
			/// <term>UF_ENCRYPTED_TEXT_PASSWORD_ALLOWED</term>
			/// <term>The user's password is stored under reversible encryption in the Active Directory.</term>
			/// </item>
			/// <item>
			/// <term>UF_NOT_DELEGATED</term>
			/// <term>Marks the account as "sensitive"; other users cannot act as delegates of this user account.</term>
			/// </item>
			/// <item>
			/// <term>UF_SMARTCARD_REQUIRED</term>
			/// <term>Requires the user to log on to the user account with a smart card.</term>
			/// </item>
			/// <item>
			/// <term>UF_USE_DES_KEY_ONLY</term>
			/// <term>Restrict this principal to use only Data Encryption Standard (DES) encryption types for keys.</term>
			/// </item>
			/// <item>
			/// <term>UF_DONT_REQUIRE_PREAUTH</term>
			/// <term>This account does not require Kerberos preauthentication for logon.</term>
			/// </item>
			/// <item>
			/// <term>UF_TRUSTED_FOR_DELEGATION</term>
			/// <term>
			/// The account is enabled for delegation. This is a security-sensitive setting; accounts with this option enabled should be
			/// tightly controlled. This setting allows a service running under the account to assume a client's identity and authenticate as
			/// that user to other remote servers on the network.
			/// </term>
			/// </item>
			/// <item>
			/// <term>UF_PASSWORD_EXPIRED</term>
			/// <term>The user's password has expired. Windows 2000: This value is not supported.</term>
			/// </item>
			/// <item>
			/// <term>UF_TRUSTED_TO_AUTHENTICATE_FOR_DELEGATION</term>
			/// <term>
			/// The account is trusted to authenticate a user outside of the Kerberos security package and delegate that user through
			/// constrained delegation. This is a security-sensitive setting; accounts with this option enabled should be tightly controlled.
			/// This setting allows a service running under the account to assert a client's identity and authenticate as that user to
			/// specifically configured services on the network. Windows XP/2000: This value is not supported.
			/// </term>
			/// </item>
			/// </list>
			/// <para>
			/// The following values describe the account type. Only one value can be set. You cannot change the account type using the
			/// NetUserSetInfo function.
			/// </para>
			/// <list type="table">
			/// <listheader>
			/// <term>Value</term>
			/// <term>Meaning</term>
			/// </listheader>
			/// <item>
			/// <term>UF_NORMAL_ACCOUNT</term>
			/// <term>This is a default account type that represents a typical user.</term>
			/// </item>
			/// <item>
			/// <term>UF_TEMP_DUPLICATE_ACCOUNT</term>
			/// <term>
			/// This is an account for users whose primary account is in another domain. This account provides user access to this domain,
			/// but not to any domain that trusts this domain. The User Manager refers to this account type as a local user account.
			/// </term>
			/// </item>
			/// <item>
			/// <term>UF_WORKSTATION_TRUST_ACCOUNT</term>
			/// <term>This is a computer account for a computer that is a member of this domain.</term>
			/// </item>
			/// <item>
			/// <term>UF_SERVER_TRUST_ACCOUNT</term>
			/// <term>This is a computer account for a backup domain controller that is a member of this domain.</term>
			/// </item>
			/// <item>
			/// <term>UF_INTERDOMAIN_TRUST_ACCOUNT</term>
			/// <term>This is a permit to trust account for a domain that trusts other domains.</term>
			/// </item>
			/// </list>
			/// </summary>
			public UserAcctCtrlFlags usri1008_flags;
		}

		/// <summary>
		/// The <c>USER_INFO_1009</c> structure contains the path for a user's logon script file. This information level is valid only when
		/// you call the NetUserSetInfo function.
		/// </summary>
		// https://docs.microsoft.com/en-us/windows/desktop/api/lmaccess/ns-lmaccess-_user_info_1009 typedef struct _USER_INFO_1009 { LPWSTR
		// usri1009_script_path; } USER_INFO_1009, *PUSER_INFO_1009, *LPUSER_INFO_1009;
		[PInvokeData("lmaccess.h", MSDNShortId = "baaabbf9-9571-49db-bf38-a3fc2d0a200a")]
		[StructLayout(LayoutKind.Sequential, CharSet = CharSet.Unicode)]
		public struct USER_INFO_1009
		{
			/// <summary>
			/// Pointer to a Unicode string specifying the path for the user's logon script file. The user is specified in the username
			/// parameter to the <c>NetUserSetInfo</c> function. The script file can be a .CMD file, an .EXE file, or a .BAT file. The string
			/// can also be null.
			/// </summary>
			public string usri1009_script_path;
		}

		/// <summary>
		/// The <c>USER_INFO_1010</c> structure contains a set of bit flags defining the operator privileges assigned to a user network
		/// account. This information level is valid only when you call the NetUserSetInfo function.
		/// </summary>
		/// <remarks>
		/// For more information about controlling access to securable objects, see Access Control, Privileges, and Securable Objects.
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows/desktop/api/lmaccess/ns-lmaccess-_user_info_1010 typedef struct _USER_INFO_1010 { DWORD
		// usri1010_auth_flags; } USER_INFO_1010, *PUSER_INFO_1010, *LPUSER_INFO_1010;
		[PInvokeData("lmaccess.h", MSDNShortId = "6760729a-1d59-430e-8412-1257977af169")]
		[StructLayout(LayoutKind.Sequential, CharSet = CharSet.Unicode)]
		public struct USER_INFO_1010
		{
			/// <summary>
			/// <para>
			/// Specifies a <c>DWORD</c> value that contains a set of bit flags that specify the user's operator privileges. The user is
			/// specified in the username parameter to the <c>NetUserSetInfo</c> function.
			/// </para>
			/// <para>This member can be one or more of the following values.</para>
			/// <list type="table">
			/// <listheader>
			/// <term>Value</term>
			/// <term>Meaning</term>
			/// </listheader>
			/// <item>
			/// <term>AF_OP_PRINT</term>
			/// <term>The print operator privilege is enabled.</term>
			/// </item>
			/// <item>
			/// <term>AF_OP_COMM</term>
			/// <term>The communications operator privilege is enabled.</term>
			/// </item>
			/// <item>
			/// <term>AF_OP_SERVER</term>
			/// <term>The server operator privilege is enabled.</term>
			/// </item>
			/// <item>
			/// <term>AF_OP_ACCOUNTS</term>
			/// <term>The accounts operator privilege is enabled.</term>
			/// </item>
			/// </list>
			/// </summary>
			public UserOpPriv usri1010_auth_flags;
		}

		/// <summary>
		/// The <c>USER_INFO_1011</c> structure contains the full name of a network user. This information level is valid only when you call
		/// the NetUserSetInfo function.
		/// </summary>
		// https://docs.microsoft.com/en-us/windows/desktop/api/lmaccess/ns-lmaccess-_user_info_1011 typedef struct _USER_INFO_1011 { LPWSTR
		// usri1011_full_name; } USER_INFO_1011, *PUSER_INFO_1011, *LPUSER_INFO_1011;
		[PInvokeData("lmaccess.h", MSDNShortId = "f60075b4-19c5-4998-b8c3-61e960e76035")]
		[StructLayout(LayoutKind.Sequential, CharSet = CharSet.Unicode)]
		public struct USER_INFO_1011
		{
			/// <summary>
			/// Pointer to a Unicode string that contains the full name of the user. The user is specified in the username parameter to the
			/// <c>NetUserSetInfo</c> function. This string can be a null string, or it can have any number of characters before the
			/// terminating null character.
			/// </summary>
			public string usri1011_full_name;
		}

		/// <summary>
		/// The <c>USER_INFO_1012</c> structure contains a user comment. This information level is valid only when you call the
		/// NetUserSetInfo function.
		/// </summary>
		// https://docs.microsoft.com/en-us/windows/desktop/api/lmaccess/ns-lmaccess-_user_info_1012 typedef struct _USER_INFO_1012 { LPWSTR
		// usri1012_usr_comment; } USER_INFO_1012, *PUSER_INFO_1012, *LPUSER_INFO_1012;
		[PInvokeData("lmaccess.h", MSDNShortId = "92501552-7afe-4a95-980a-576254a122a9")]
		[StructLayout(LayoutKind.Sequential, CharSet = CharSet.Unicode)]
		public struct USER_INFO_1012
		{
			/// <summary>
			/// Pointer to a Unicode string that contains a user comment. The user is specified in the username parameter to the
			/// <c>NetUserSetInfo</c> function. This string can be a null string, or it can have any number of characters before the
			/// terminating null character.
			/// </summary>
			public string usri1012_usr_comment;
		}

		/// <summary>
		/// The <c>USER_INFO_1013</c> structure contains reserved information for network accounts. This information level is valid only when
		/// you call the NetUserSetInfo function.
		/// </summary>
		// https://docs.microsoft.com/en-us/windows/desktop/api/lmaccess/ns-lmaccess-_user_info_1013 typedef struct _USER_INFO_1013 { LPWSTR
		// usri1013_parms; } USER_INFO_1013, *PUSER_INFO_1013, *LPUSER_INFO_1013;
		[PInvokeData("lmaccess.h", MSDNShortId = "7166201d-57e3-4288-ad15-392cc3733dc6")]
		[StructLayout(LayoutKind.Sequential, CharSet = CharSet.Unicode)]
		public struct USER_INFO_1013
		{
			/// <summary>
			/// <para>
			/// Pointer to a Unicode string that is reserved for use by applications. The string can be a null string, or it can have any
			/// number of characters before the terminating null character. Microsoft products use this member to store user configuration
			/// information. Do not modify this information.
			/// </para>
			/// <para>
			/// The system components that use this member are services for Macintosh, file and print services for NetWare, and the Remote
			/// Access Server (RAS).
			/// </para>
			/// </summary>
			public string usri1013_parms;
		}

		/// <summary>
		/// The <c>USER_INFO_1014</c> structure contains the names of workstations from which the user can log on. This information level is
		/// valid only when you call the NetUserSetInfo function.
		/// </summary>
		// https://docs.microsoft.com/en-us/windows/desktop/api/lmaccess/ns-lmaccess-_user_info_1014 typedef struct _USER_INFO_1014 { LPWSTR
		// usri1014_workstations; } USER_INFO_1014, *PUSER_INFO_1014, *LPUSER_INFO_1014;
		[PInvokeData("lmaccess.h", MSDNShortId = "ff7f385d-bcda-4560-b22f-d1fc94e7ae41")]
		[StructLayout(LayoutKind.Sequential, CharSet = CharSet.Unicode)]
		public struct USER_INFO_1014
		{
			/// <summary>
			/// <para>
			/// Pointer to a Unicode string that contains the names of workstations from which the user can log on. The user is specified in
			/// the username parameter to the <c>NetUserSetInfo</c> function.
			/// </para>
			/// <para>
			/// As many as eight workstations can be specified; the names must be separated by commas. A null string indicates that there is
			/// no restriction.
			/// </para>
			/// </summary>
			public string usri1014_workstations;
		}

		/// <summary>
		/// The <c>USER_INFO_1017</c> structure contains expiration information for network user accounts. This information level is valid
		/// only when you call the NetUserSetInfo function.
		/// </summary>
		// https://docs.microsoft.com/en-us/windows/desktop/api/lmaccess/ns-lmaccess-_user_info_1017 typedef struct _USER_INFO_1017 { DWORD
		// usri1017_acct_expires; } USER_INFO_1017, *PUSER_INFO_1017, *LPUSER_INFO_1017;
		[PInvokeData("lmaccess.h", MSDNShortId = "67ded50e-ab9a-4202-9496-1a39d1af0f58")]
		[StructLayout(LayoutKind.Sequential, CharSet = CharSet.Unicode)]
		public struct USER_INFO_1017
		{
			/// <summary>
			/// <para>
			/// Specifies a <c>DWORD</c> value that indicates when the user account expires. The user account is specified in the username
			/// parameter to the <c>NetUserSetInfo</c> function.
			/// </para>
			/// <para>
			/// The value is stored as the number of seconds that have elapsed since 00:00:00, January 1, 1970, GMT. Specify TIMEQ_FOREVER to
			/// indicate that the account never expires.
			/// </para>
			/// </summary>
			public uint usri1017_acct_expires;
		}

		/// <summary>
		/// The <c>USER_INFO_1018</c> structure contains the maximum amount of disk space available to a network user account. This
		/// information level is valid only when you call the NetUserSetInfo function.
		/// </summary>
		// https://docs.microsoft.com/en-us/windows/desktop/api/lmaccess/ns-lmaccess-_user_info_1018 typedef struct _USER_INFO_1018 { DWORD
		// usri1018_max_storage; } USER_INFO_1018, *PUSER_INFO_1018, *LPUSER_INFO_1018;
		[PInvokeData("lmaccess.h", MSDNShortId = "15bdff5c-a360-4519-8e0b-c73ddd01298c")]
		[StructLayout(LayoutKind.Sequential, CharSet = CharSet.Unicode)]
		public struct USER_INFO_1018
		{
			/// <summary>
			/// <para>
			/// Specifies a <c>DWORD</c> value that indicates the maximum amount of disk space the user can use. The user is specified in the
			/// username parameter to the <c>NetUserSetInfo</c> function.
			/// </para>
			/// <para>You must specify USER_MAXSTORAGE_UNLIMITED to indicate that there is no restriction on disk space.</para>
			/// </summary>
			public uint usri1018_max_storage;
		}

		/// <summary>
		/// The <c>USER_INFO_1020</c> structure contains the times during which a user can log on to the network. This information level is
		/// valid only when you call the NetUserSetInfo function.
		/// </summary>
		// https://docs.microsoft.com/en-us/windows/desktop/api/lmaccess/ns-lmaccess-_user_info_1020 typedef struct _USER_INFO_1020 { DWORD
		// usri1020_units_per_week; LPBYTE usri1020_logon_hours; } USER_INFO_1020, *PUSER_INFO_1020, *LPUSER_INFO_1020;
		[PInvokeData("lmaccess.h", MSDNShortId = "959ed1f4-d5ee-4d77-abd7-bb681778f0b1")]
		[StructLayout(LayoutKind.Sequential, CharSet = CharSet.Unicode)]
		public struct USER_INFO_1020
		{
			/// <summary>
			/// <para>
			/// Specifies a <c>DWORD</c> value that indicates the number of equal-length time units into which the week is divided. This
			/// value is required to compute the length of the bit string in the <c>usri1020_logon_hours</c> member.
			/// </para>
			/// <para>
			/// This value must be UNITS_PER_WEEK for LAN Manager 2.0. Calls to the NetUserAdd and NetUserSetInfo functions ignore this member.
			/// </para>
			/// <para>
			/// For service applications, the units must be one of the following values: SAM_DAYS_PER_WEEK, SAM_HOURS_PER_WEEK, or SAM_MINUTES_PER_WEEK.
			/// </para>
			/// </summary>
			public uint usri1020_units_per_week;

			/// <summary>
			/// <para>
			/// Pointer to a 21-byte (168 bits) bit string that specifies the times during which the user can log on. The user is specified
			/// in the username parameter to the <c>NetUserSetInfo</c> function.
			/// </para>
			/// <para>
			/// Each bit in the string represents a unique hour in the week, in Greenwich Mean Time (GMT). The first bit (bit 0, word 0) is
			/// Sunday, 0:00 to 0:59; the second bit (bit 1, word 0) is Sunday, 1:00 to 1:59; and so on. Note that bit 0 in word 0 represents
			/// Sunday from 0:00 to 0:59 only if you are in the GMT time zone. In all other cases you must adjust the bits according to your
			/// time zone offset (for example, GMT minus 8 hours for Pacific Standard Time).
			/// </para>
			/// </summary>
			public IntPtr usri1020_logon_hours;
		}

		/// <summary>
		/// The <c>USER_INFO_1023</c> structure contains the name of the server to which network logon requests should be sent. This
		/// information level is valid only when you call the NetUserSetInfo function.
		/// </summary>
		// https://docs.microsoft.com/en-us/windows/desktop/api/lmaccess/ns-lmaccess-_user_info_1023 typedef struct _USER_INFO_1023 { LPWSTR
		// usri1023_logon_server; } USER_INFO_1023, *PUSER_INFO_1023, *LPUSER_INFO_1023;
		[PInvokeData("lmaccess.h", MSDNShortId = "44985bbe-48d2-4fe9-9247-2800089269cb")]
		[StructLayout(LayoutKind.Sequential, CharSet = CharSet.Unicode)]
		public struct USER_INFO_1023
		{
			/// <summary>
			/// <para>
			/// Pointer to a Unicode string that contains the name of the server to which logon requests for the user account should be sent.
			/// The user account is specified in the username parameter to the <c>NetUserSetInfo</c> function.
			/// </para>
			/// <para>
			/// Server names should be preceded by two backslashes (\). To indicate that the logon request can be handled by any logon
			/// server, specify an asterisk (\*) for the server name. A null string indicates that requests should be sent to the domain controller.
			/// </para>
			/// </summary>
			public string usri1023_logon_server;
		}

		/// <summary>
		/// The <c>USER_INFO_1024</c> structure contains the country/region code for a network user's language of choice. This information
		/// level is valid only when you call the NetUserSetInfo function.
		/// </summary>
		// https://docs.microsoft.com/en-us/windows/desktop/api/lmaccess/ns-lmaccess-_user_info_1024 typedef struct _USER_INFO_1024 { DWORD
		// usri1024_country_code; } USER_INFO_1024, *PUSER_INFO_1024, *LPUSER_INFO_1024;
		[PInvokeData("lmaccess.h", MSDNShortId = "8133238f-c968-4a65-a8dd-7b9a61a193f5")]
		[StructLayout(LayoutKind.Sequential, CharSet = CharSet.Unicode)]
		public struct USER_INFO_1024
		{
			/// <summary>
			/// <para>
			/// Specifies a <c>DWORD</c> value that indicates the country/region code for the user's language of choice. The user is
			/// specified in the username parameter to the <c>NetUserSetInfo</c> function.
			/// </para>
			/// <para>This value is ignored.</para>
			/// </summary>
			public uint usri1024_country_code;
		}

		/// <summary>
		/// The <c>USER_INFO_1025</c> structure contains the code page for a network user's language of choice. This information level is
		/// valid only when you call the NetUserSetInfo function.
		/// </summary>
		// https://docs.microsoft.com/en-us/windows/desktop/api/lmaccess/ns-lmaccess-_user_info_1025 typedef struct _USER_INFO_1025 { DWORD
		// usri1025_code_page; } USER_INFO_1025, *PUSER_INFO_1025, *LPUSER_INFO_1025;
		[PInvokeData("lmaccess.h", MSDNShortId = "85e3584f-8245-47e3-9e48-5c43db51be0f")]
		[StructLayout(LayoutKind.Sequential, CharSet = CharSet.Unicode)]
		public struct USER_INFO_1025
		{
			/// <summary>
			/// <para>
			/// Specifies a <c>DWORD</c> value that indicates the code page for the user's language of choice. The user is specified in the
			/// username parameter to the <c>NetUserSetInfo</c> function.
			/// </para>
			/// <para>This value is ignored.</para>
			/// </summary>
			public uint usri1025_code_page;
		}

		/// <summary>
		/// The <c>USER_INFO_1051</c> structure contains the relative ID (RID) associated with the user account. This information level is
		/// valid only when you call the NetUserSetInfo function.
		/// </summary>
		// https://docs.microsoft.com/en-us/windows/desktop/api/lmaccess/ns-lmaccess-_user_info_1051 typedef struct _USER_INFO_1051 { DWORD
		// usri1051_primary_group_id; } USER_INFO_1051, *PUSER_INFO_1051, *LPUSER_INFO_1051;
		[PInvokeData("lmaccess.h", MSDNShortId = "dbd7c63b-c383-48dd-98f2-087f2b41fc52")]
		[StructLayout(LayoutKind.Sequential, CharSet = CharSet.Unicode)]
		public struct USER_INFO_1051
		{
			/// <summary>
			/// Specifies a <c>DWORD</c> value that contains the RID of the Primary Global Group for the user specified in the username
			/// parameter to the <c>NetUserSetInfo</c> function. This member must be the RID of a global group that represents the enrolled
			/// user. For more information about RIDs, see SID Components.
			/// </summary>
			public uint usri1051_primary_group_id;
		}

		/// <summary>
		/// The <c>USER_INFO_1052</c> structure contains the path to a network user's profile. This information level is valid only when you
		/// call the NetUserSetInfo function.
		/// </summary>
		// https://docs.microsoft.com/en-us/windows/desktop/api/lmaccess/ns-lmaccess-_user_info_1052 typedef struct _USER_INFO_1052 { LPWSTR
		// usri1052_profile; } USER_INFO_1052, *PUSER_INFO_1052, *LPUSER_INFO_1052;
		[PInvokeData("lmaccess.h", MSDNShortId = "55ec6819-8558-413a-9a79-c2d59993163d")]
		[StructLayout(LayoutKind.Sequential, CharSet = CharSet.Unicode)]
		public struct USER_INFO_1052
		{
			/// <summary>
			/// Specifies a Unicode string that contains the path to the user's profile. The user is specified in the username parameter to
			/// the <c>NetUserSetInfo</c> function. This value can be a null string, a local absolute path, or a UNC path.
			/// </summary>
			public string usri1052_profile;
		}

		/// <summary>
		/// The <c>USER_INFO_1053</c> structure contains user information for network accounts. This information level is valid only when you
		/// call the NetUserSetInfo function.
		/// </summary>
		// https://docs.microsoft.com/en-us/windows/desktop/api/lmaccess/ns-lmaccess-_user_info_1053 typedef struct _USER_INFO_1053 { LPWSTR
		// usri1053_home_dir_drive; } USER_INFO_1053, *PUSER_INFO_1053, *LPUSER_INFO_1053;
		[PInvokeData("lmaccess.h", MSDNShortId = "687b2c35-344d-49db-a1e2-fb5c2b5db2d6")]
		[StructLayout(LayoutKind.Sequential, CharSet = CharSet.Unicode)]
		public struct USER_INFO_1053
		{
			/// <summary>
			/// Specifies the drive letter to assign to the user's home directory for logon purposes. The user is specified in the username
			/// parameter to the <c>NetUserSetInfo</c> function.
			/// </summary>
			public string usri1053_home_dir_drive;
		}

		/// <summary>
		/// The <c>USER_INFO_11</c> structure contains information about a user account, including the account name, privilege level, the
		/// path to the user's home directory, and other user-related network statistics.
		/// </summary>
		/// <remarks>
		/// User account names are limited to 20 characters and group names are limited to 256 characters. In addition, account names cannot
		/// be terminated by a period and they cannot include commas or any of the following printable characters: ", /, , [, ], :, |, &lt;,
		/// &gt;, +, =, ;, ?, *. Names also cannot include characters in the range 1-31, which are non-printable.
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows/desktop/api/lmaccess/ns-lmaccess-_user_info_11 typedef struct _USER_INFO_11 { LPWSTR
		// usri11_name; LPWSTR usri11_comment; LPWSTR usri11_usr_comment; LPWSTR usri11_full_name; DWORD usri11_priv; DWORD
		// usri11_auth_flags; DWORD usri11_password_age; LPWSTR usri11_home_dir; LPWSTR usri11_parms; DWORD usri11_last_logon; DWORD
		// usri11_last_logoff; DWORD usri11_bad_pw_count; DWORD usri11_num_logons; LPWSTR usri11_logon_server; DWORD usri11_country_code;
		// LPWSTR usri11_workstations; DWORD usri11_max_storage; DWORD usri11_units_per_week; PBYTE usri11_logon_hours; DWORD
		// usri11_code_page; } USER_INFO_11, *PUSER_INFO_11, *LPUSER_INFO_11;
		[PInvokeData("lmaccess.h", MSDNShortId = "718e7143-a6df-4912-954c-cc63bb490044")]
		[StructLayout(LayoutKind.Sequential, CharSet = CharSet.Unicode)]
		public struct USER_INFO_11
		{
			/// <summary>
			/// <para>Type: <c>LPWSTR</c></para>
			/// <para>
			/// A pointer to a Unicode character that specifies the name of the user account. Calls to the NetUserSetInfo function ignore
			/// this member. For more information, see the following Remarks section.
			/// </para>
			/// </summary>
			public string usri11_name;

			/// <summary>
			/// <para>Type: <c>LPWSTR</c></para>
			/// <para>
			/// A pointer to a Unicode string that contains a comment associated with the user account. This string can be a <c>NULL</c>
			/// string, or it can have any number of characters before the terminating null character.
			/// </para>
			/// </summary>
			public string usri11_comment;

			/// <summary>
			/// <para>Type: <c>LPWSTR</c></para>
			/// <para>
			/// A pointer to a Unicode string that contains a user comment. This string can be a <c>NULL</c> string, or it can have any
			/// number of characters before the terminating null character.
			/// </para>
			/// </summary>
			public string usri11_usr_comment;

			/// <summary>
			/// <para>Type: <c>LPWSTR</c></para>
			/// <para>
			/// A pointer to a Unicode string that contains the full name of the user. This string can be a <c>NULL</c> string, or it can
			/// have any number of characters before the terminating null character.
			/// </para>
			/// </summary>
			public string usri11_full_name;

			/// <summary>
			/// <para>Type: <c>DWORD</c></para>
			/// <para>
			/// The level of privilege assigned to the <c>usri11_name</c> member. For calls to the NetUserAdd function, this member must be
			/// USER_PRIV_USER. For calls to NetUserSetInfo, this member must be the value returned from the NetUserGetInfo function or the
			/// NetUserEnum function. This member can be one of the following values. For more information about user and group account
			/// rights, see Privileges.
			/// </para>
			/// <list type="table">
			/// <listheader>
			/// <term>Value</term>
			/// <term>Meaning</term>
			/// </listheader>
			/// <item>
			/// <term>USER_PRIV_GUEST</term>
			/// <term>Guest</term>
			/// </item>
			/// <item>
			/// <term>USER_PRIV_USER</term>
			/// <term>User</term>
			/// </item>
			/// <item>
			/// <term>USER_PRIV_ADMIN</term>
			/// <term>Administrator</term>
			/// </item>
			/// </list>
			/// </summary>
			public UserPrivilege usri11_priv;

			/// <summary>
			/// <para>Type: <c>DWORD</c></para>
			/// <para>A set of bit flags defining the user's operator privileges.</para>
			/// <para>
			/// Calls to the NetUserGetInfo function and the NetUserEnum function return a value based on the user's local group membership.
			/// If the user is a member of Print Operators, AF_OP_PRINT is set. If the user is a member of Server Operators, AF_OP_SERVER is
			/// set. If the user is a member of the Account Operators, AF_OP_ACCOUNTS is set. AF_OP_COMM is never set.
			/// </para>
			/// <para>The NetUserAdd and NetUserSetInfo functions ignore this member.</para>
			/// <para>The following restrictions apply:</para>
			/// <list type="bullet">
			/// <item>
			/// <term>When you call the NetUserAdd function, this member must be zero.</term>
			/// </item>
			/// <item>
			/// <term>
			/// When you call the NetUserSetInfo function, this member must be the value returned from a call to NetUserGetInfo or to NetUserEnum.
			/// </term>
			/// </item>
			/// </list>
			/// <para>This member can be one or more of the following values.</para>
			/// <list type="table">
			/// <listheader>
			/// <term>Value</term>
			/// <term>Meaning</term>
			/// </listheader>
			/// <item>
			/// <term>AF_OP_PRINT</term>
			/// <term>The print operator privilege is enabled.</term>
			/// </item>
			/// <item>
			/// <term>AF_OP_COMM</term>
			/// <term>The communications operator privilege is enabled.</term>
			/// </item>
			/// <item>
			/// <term>AF_OP_SERVER</term>
			/// <term>The server operator privilege is enabled.</term>
			/// </item>
			/// <item>
			/// <term>AF_OP_ACCOUNTS</term>
			/// <term>The accounts operator privilege is enabled.</term>
			/// </item>
			/// </list>
			/// </summary>
			public UserOpPriv usri11_auth_flags;

			/// <summary>
			/// <para>Type: <c>DWORD</c></para>
			/// <para>
			/// The number of seconds that have elapsed since the <c>usri11_password</c> member was last changed. The NetUserAdd and
			/// NetUserSetInfo functions ignore this member.
			/// </para>
			/// </summary>
			public uint usri11_password_age;

			/// <summary>
			/// <para>Type: <c>LPWSTR</c></para>
			/// <para>
			/// A pointer to a Unicode string specifying the path of the home directory for the user specified in the <c>usri11_name</c>
			/// member. The string can be <c>NULL</c>.
			/// </para>
			/// </summary>
			public string usri11_home_dir;

			/// <summary>
			/// <para>Type: <c>LPWSTR</c></para>
			/// <para>
			/// A pointer to a Unicode string that is reserved for use by applications. This string can be a <c>NULL</c> string, or it can
			/// have any number of characters before the terminating null character. Microsoft products use this member to store user
			/// configuration information. Do not modify this information.
			/// </para>
			/// </summary>
			public string usri11_parms;

			/// <summary>
			/// <para>Type: <c>DWORD</c></para>
			/// <para>
			/// The date and time when the last logon occurred. This value is stored as the number of seconds that have elapsed since
			/// 00:00:00, January 1, 1970, GMT. The NetUserAdd and NetUserSetInfo functions ignore this member.
			/// </para>
			/// <para>
			/// This member is maintained separately on each backup domain controller (BDC) in the domain. To obtain an accurate value, you
			/// must query each BDC in the domain. The last logon occurred at the time indicated by the largest retrieved value.
			/// </para>
			/// </summary>
			public uint usri11_last_logon;

			/// <summary>
			/// <para>Type: <c>DWORD</c></para>
			/// <para>This member is currently not used.</para>
			/// <para>
			/// The date and time when the last logoff occurred. This value is stored as the number of seconds that have elapsed since
			/// 00:00:00, January 1, 1970, GMT. A value of zero indicates that the last logoff time is unknown. The <c>NetUserAdd</c>
			/// function and the <c>NetUserSetInfo</c> function ignore this member.
			/// </para>
			/// <para>
			/// This member is maintained separately on each backup domain controller (BDC) in the domain. To obtain an accurate value, you
			/// must query each BDC in the domain. The last logoff occurred at the time indicated by the largest retrieved value.
			/// </para>
			/// </summary>
			public uint usri11_last_logoff;

			/// <summary>
			/// <para>Type: <c>DWORD</c></para>
			/// <para>
			/// The number of times the user tried to log on to this account using an incorrect password. A value of – 1 indicates that the
			/// value is unknown. The NetUserAdd and NetUserSetInfo functions ignore this member.
			/// </para>
			/// <para>
			/// This member is replicated from the primary domain controller (PDC); it is also maintained on each backup domain controller
			/// (BDC) in the domain. To obtain an accurate value, you must query each BDC in the domain. The number of times the user tried
			/// to log on using an incorrect password is the largest value retrieved.
			/// </para>
			/// </summary>
			public uint usri11_bad_pw_count;

			/// <summary>
			/// <para>Type: <c>DWORD</c></para>
			/// <para>
			/// The number of times the user has logged on successfully to this account. A value of – 1 indicates that the value is unknown.
			/// Calls to the <c>NetUserAdd</c> and <c>NetUserSetInfo</c> functions ignore this member.
			/// </para>
			/// <para>
			/// This member is maintained separately on each backup domain controller (BDC) in the domain. To obtain an accurate value, you
			/// must query each BDC in the domain. The number of times the user logged on successfully is the sum of the retrieved values.
			/// </para>
			/// </summary>
			public uint usri11_num_logons;

			/// <summary>
			/// <para>Type: <c>LPWSTR</c></para>
			/// <para>
			/// A pointer to a Unicode string that contains the name of the server to which logon requests are sent. Server names should be
			/// preceded by two backslashes (\). To indicate that the logon request can be handled by any logon server, specify an asterisk
			/// (\*) for the server name. A <c>NULL</c> string indicates that requests should be sent to the domain controller.
			/// </para>
			/// <para>
			/// For Windows servers, NetUserGetInfo and NetUserEnum return \*. The NetUserAdd and NetUserSetInfo functions ignore this member.
			/// </para>
			/// </summary>
			public string usri11_logon_server;

			/// <summary>
			/// <para>Type: <c>DWORD</c></para>
			/// <para>The country/region code for the user's language of choice.</para>
			/// </summary>
			public uint usri11_country_code;

			/// <summary>
			/// <para>Type: <c>LPWSTR</c></para>
			/// <para>
			/// A pointer to a Unicode string that contains the names of workstations from which the user can log on. As many as eight
			/// workstations can be specified; the names must be separated by commas. A <c>NULL</c> string indicates that there is no
			/// restriction. To disable logons from all workstations to this account, set the UF_ACCOUNTDISABLE value in the
			/// <c>usri11_flags</c> member.
			/// </para>
			/// </summary>
			public string usri11_workstations;

			/// <summary>
			/// <para>Type: <c>DWORD</c></para>
			/// <para>The maximum amount of disk space the user can use. Specify USER_MAXSTORAGE_UNLIMITED to use all available disk space.</para>
			/// </summary>
			public uint usri11_max_storage;

			/// <summary>
			/// <para>Type: <c>DWORD</c></para>
			/// <para>
			/// The number of equal-length time units into which the week is divided. This value is required to compute the length of the bit
			/// string in the <c>usri11_logon_hours</c> member.
			/// </para>
			/// <para>
			/// This member must be UNITS_PER_WEEK for LAN Manager 2.0. This element is ignored by the NetUserAdd and NetUserSetInfo functions.
			/// </para>
			/// <para>
			/// For service applications, the units must be one of the following values: SAM_DAYS_PER_WEEK, SAM_HOURS_PER_WEEK, or SAM_MINUTES_PER_WEEK.
			/// </para>
			/// </summary>
			public uint usri11_units_per_week;

			/// <summary>
			/// <para>Type: <c>PBYTE</c></para>
			/// <para>
			/// A pointer to a 21-byte (168 bits) bit string that specifies the times during which the user can log on. Each bit represents a
			/// unique hour in the week, in Greenwich Mean Time (GMT).
			/// </para>
			/// <para>
			/// The first bit (bit 0, word 0) is Sunday, 0:00 to 0:59; the second bit (bit 1, word 0) is Sunday, 1:00 to 1:59; and so on.
			/// Note that bit 0 in word 0 represents Sunday from 0:00 to 0:59 only if you are in the GMT time zone. In all other cases you
			/// must adjust the bits according to your time zone offset (for example, GMT minus 8 hours for Pacific Standard Time).
			/// </para>
			/// <para>
			/// Specify a <c>NULL</c> pointer in this member when calling the NetUserAdd function to indicate no time restriction. Specify a
			/// <c>NULL</c> pointer when calling the NetUserSetInfo function to indicate that no change is to be made to the times during
			/// which the user can log on.
			/// </para>
			/// </summary>
			public IntPtr usri11_logon_hours;

			/// <summary>
			/// <para>Type: <c>DWORD</c></para>
			/// <para>The code page for the user's language of choice.</para>
			/// </summary>
			public uint usri11_code_page;
		}

		/// <summary>
		/// The <c>USER_INFO_2</c> structure contains information about a user account, including the account name, password data, privilege
		/// level, the path to the user's home directory, and other user-related network statistics.
		/// </summary>
		/// <remarks>
		/// <para>For more information about user and group account rights, see Privileges.</para>
		/// <para>
		/// User account names are limited to 20 characters and group names are limited to 256 characters. In addition, account names cannot
		/// be terminated by a period and they cannot include commas or any of the following printable characters: ", /, , [, ], :, |, &lt;,
		/// &gt;, +, =, ;, ?, *. Names also cannot include characters in the range 1-31, which are non-printable.
		/// </para>
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows/desktop/api/lmaccess/ns-lmaccess-_user_info_2 typedef struct _USER_INFO_2 { LPWSTR
		// usri2_name; LPWSTR usri2_password; DWORD usri2_password_age; DWORD usri2_priv; LPWSTR usri2_home_dir; LPWSTR usri2_comment; DWORD
		// usri2_flags; LPWSTR usri2_script_path; DWORD usri2_auth_flags; LPWSTR usri2_full_name; LPWSTR usri2_usr_comment; LPWSTR
		// usri2_parms; LPWSTR usri2_workstations; DWORD usri2_last_logon; DWORD usri2_last_logoff; DWORD usri2_acct_expires; DWORD
		// usri2_max_storage; DWORD usri2_units_per_week; PBYTE usri2_logon_hours; DWORD usri2_bad_pw_count; DWORD usri2_num_logons; LPWSTR
		// usri2_logon_server; DWORD usri2_country_code; DWORD usri2_code_page; } USER_INFO_2, *PUSER_INFO_2, *LPUSER_INFO_2;
		[PInvokeData("lmaccess.h", MSDNShortId = "50c78c6a-a08f-473b-929a-9528e618165f")]
		[StructLayout(LayoutKind.Sequential, CharSet = CharSet.Unicode)]
		public struct USER_INFO_2
		{
			/// <summary>
			/// <para>Type: <c>LPWSTR</c></para>
			/// <para>
			/// A pointer to a Unicode string that specifies the name of the user account. Calls to the NetUserSetInfo function ignore this
			/// member. For more information, see the following Remarks section.
			/// </para>
			/// </summary>
			public string usri2_name;

			/// <summary>
			/// <para>Type: <c>LPWSTR</c></para>
			/// <para>
			/// A pointer to a Unicode string that specifies the password for the user identified by the <c>usri2_name</c> member. The length
			/// cannot exceed PWLEN bytes. The NetUserEnum and NetUserGetInfo functions return a <c>NULL</c> pointer to maintain password security.
			/// </para>
			/// <para>By convention, the length of passwords is limited to LM20_PWLEN characters.</para>
			/// </summary>
			public string usri2_password;

			/// <summary>
			/// <para>Type: <c>DWORD</c></para>
			/// <para>
			/// The number of seconds that have elapsed since the <c>usri2_password</c> member was last changed. The NetUserAdd and
			/// NetUserSetInfo functions ignore this member.
			/// </para>
			/// </summary>
			public uint usri2_password_age;

			/// <summary>
			/// <para>Type: <c>DWORD</c></para>
			/// <para>
			/// The level of privilege assigned to the <c>usri2_name</c> member. For calls to the NetUserAdd function, this member must be
			/// USER_PRIV_USER. For the NetUserSetInfo function, this member must be the value returned by the <c>NetUserGetInfo</c> function
			/// or the <c>NetUserEnum</c> function. This member can be one of the following values. For more information about user and group
			/// account rights, see Privileges.
			/// </para>
			/// <list type="table">
			/// <listheader>
			/// <term>Value</term>
			/// <term>Meaning</term>
			/// </listheader>
			/// <item>
			/// <term>USER_PRIV_GUEST</term>
			/// <term>Guest</term>
			/// </item>
			/// <item>
			/// <term>USER_PRIV_USER</term>
			/// <term>User</term>
			/// </item>
			/// <item>
			/// <term>USER_PRIV_ADMIN</term>
			/// <term>Administrator</term>
			/// </item>
			/// </list>
			/// </summary>
			public UserPrivilege usri2_priv;

			/// <summary>
			/// <para>Type: <c>LPWSTR</c></para>
			/// <para>
			/// A pointer to a Unicode string specifying the path of the home directory for the user specified by the <c>usri2_name</c>
			/// member. The string can be <c>NULL</c>.
			/// </para>
			/// </summary>
			public string usri2_home_dir;

			/// <summary>
			/// <para>Type: <c>LPWSTR</c></para>
			/// <para>
			/// A pointer to a Unicode string that contains a comment to associate with the user account. The string can be a <c>NULL</c>
			/// string, or it can have any number of characters before the terminating null character.
			/// </para>
			/// </summary>
			public string usri2_comment;

			/// <summary>
			/// <para>Type: <c>DWORD</c></para>
			/// <para>This member can be one or more of the following values.</para>
			/// <para>
			/// Note that setting user account control flags may require certain privileges and control access rights. For more information,
			/// see the Remarks section of the NetUserSetInfo function.
			/// </para>
			/// <list type="table">
			/// <listheader>
			/// <term>Value</term>
			/// <term>Meaning</term>
			/// </listheader>
			/// <item>
			/// <term>UF_SCRIPT</term>
			/// <term>The logon script executed. This value must be set.</term>
			/// </item>
			/// <item>
			/// <term>UF_ACCOUNTDISABLE</term>
			/// <term>The user's account is disabled.</term>
			/// </item>
			/// <item>
			/// <term>UF_HOMEDIR_REQUIRED</term>
			/// <term>The home directory is required. This value is ignored.</term>
			/// </item>
			/// <item>
			/// <term>UF_PASSWD_NOTREQD</term>
			/// <term>No password is required.</term>
			/// </item>
			/// <item>
			/// <term>UF_PASSWD_CANT_CHANGE</term>
			/// <term>The user cannot change the password.</term>
			/// </item>
			/// <item>
			/// <term>UF_LOCKOUT</term>
			/// <term>
			/// The account is currently locked out. You can call the NetUserSetInfo function to clear this value and unlock a previously
			/// locked account. You cannot use this value to lock a previously unlocked account.
			/// </term>
			/// </item>
			/// <item>
			/// <term>UF_DONT_EXPIRE_PASSWD</term>
			/// <term>The password should never expire on the account.</term>
			/// </item>
			/// <item>
			/// <term>UF_ENCRYPTED_TEXT_PASSWORD_ALLOWED</term>
			/// <term>The user's password is stored under reversible encryption in the Active Directory.</term>
			/// </item>
			/// <item>
			/// <term>UF_NOT_DELEGATED</term>
			/// <term>Marks the account as "sensitive"; other users cannot act as delegates of this user account.</term>
			/// </item>
			/// <item>
			/// <term>UF_SMARTCARD_REQUIRED</term>
			/// <term>Requires the user to log on to the user account with a smart card.</term>
			/// </item>
			/// <item>
			/// <term>UF_USE_DES_KEY_ONLY</term>
			/// <term>Restrict this principal to use only Data Encryption Standard (DES) encryption types for keys.</term>
			/// </item>
			/// <item>
			/// <term>UF_DONT_REQUIRE_PREAUTH</term>
			/// <term>This account does not require Kerberos preauthentication for logon.</term>
			/// </item>
			/// <item>
			/// <term>UF_TRUSTED_FOR_DELEGATION</term>
			/// <term>
			/// The account is enabled for delegation. This is a security-sensitive setting; accounts with this option enabled should be
			/// tightly controlled. This setting allows a service running under the account to assume a client's identity and authenticate as
			/// that user to other remote servers on the network.
			/// </term>
			/// </item>
			/// <item>
			/// <term>UF_PASSWORD_EXPIRED</term>
			/// <term>The user's password has expired. Windows 2000: This value is not supported.</term>
			/// </item>
			/// <item>
			/// <term>UF_TRUSTED_TO_AUTHENTICATE_FOR_DELEGATION</term>
			/// <term>
			/// The account is trusted to authenticate a user outside of the Kerberos security package and delegate that user through
			/// constrained delegation. This is a security-sensitive setting; accounts with this option enabled should be tightly controlled.
			/// This setting allows a service running under the account to assert a client's identity and authenticate as that user to
			/// specifically configured services on the network. Windows XP/2000: This value is not supported.
			/// </term>
			/// </item>
			/// </list>
			/// <para>
			/// The following values describe the account type. Only one value can be set. You cannot change the account type using the
			/// NetUserSetInfo function.
			/// </para>
			/// <list type="table">
			/// <listheader>
			/// <term>Value</term>
			/// <term>Meaning</term>
			/// </listheader>
			/// <item>
			/// <term>UF_NORMAL_ACCOUNT</term>
			/// <term>This is a default account type that represents a typical user.</term>
			/// </item>
			/// <item>
			/// <term>UF_TEMP_DUPLICATE_ACCOUNT</term>
			/// <term>
			/// This is an account for users whose primary account is in another domain. This account provides user access to this domain,
			/// but not to any domain that trusts this domain. The User Manager refers to this account type as a local user account.
			/// </term>
			/// </item>
			/// <item>
			/// <term>UF_WORKSTATION_TRUST_ACCOUNT</term>
			/// <term>This is a computer account for a computer that is a member of this domain.</term>
			/// </item>
			/// <item>
			/// <term>UF_SERVER_TRUST_ACCOUNT</term>
			/// <term>This is a computer account for a backup domain controller that is a member of this domain.</term>
			/// </item>
			/// <item>
			/// <term>UF_INTERDOMAIN_TRUST_ACCOUNT</term>
			/// <term>This is a permit to trust account for a domain that trusts other domains.</term>
			/// </item>
			/// </list>
			/// </summary>
			public UserAcctCtrlFlags usri2_flags;

			/// <summary>
			/// <para>Type: <c>LPWSTR</c></para>
			/// <para>
			/// A pointer to a Unicode string specifying the path for the user's logon script file. The script file can be a .CMD file, an
			/// .EXE file, or a .BAT file. The string can also be <c>NULL</c>.
			/// </para>
			/// </summary>
			public string usri2_script_path;

			/// <summary>
			/// <para>Type: <c>DWORD</c></para>
			/// <para>The user's operator privileges.</para>
			/// <para>
			/// Calls to the <c>NetUserGetInfo</c> and <c>NetUserEnum</c> functions return a value based on the user's local group
			/// membership. If the user is a member of Print Operators, AF_OP_PRINT is set. If the user is a member of Server Operators,
			/// AF_OP_SERVER is set. If the user is a member of the Account Operators, AF_OP_ACCOUNTS is set. AF_OP_COMM is never set. For
			/// more information about user and group account rights, see Privileges.
			/// </para>
			/// <para>The following restrictions apply:</para>
			/// <list type="bullet">
			/// <item>
			/// <term>When you call the NetUserAdd function, this member must be zero.</term>
			/// </item>
			/// <item>
			/// <term>
			/// When you call the NetUserSetInfo function, this member must be the value returned from a call to NetUserGetInfo or to NetUserEnum.
			/// </term>
			/// </item>
			/// </list>
			/// <para>This member can be one or more of the following values.</para>
			/// <list type="table">
			/// <listheader>
			/// <term>Value</term>
			/// <term>Meaning</term>
			/// </listheader>
			/// <item>
			/// <term>AF_OP_PRINT</term>
			/// <term>The print operator privilege is enabled.</term>
			/// </item>
			/// <item>
			/// <term>AF_OP_COMM</term>
			/// <term>The communications operator privilege is enabled.</term>
			/// </item>
			/// <item>
			/// <term>AF_OP_SERVER</term>
			/// <term>The server operator privilege is enabled.</term>
			/// </item>
			/// <item>
			/// <term>AF_OP_ACCOUNTS</term>
			/// <term>The accounts operator privilege is enabled.</term>
			/// </item>
			/// </list>
			/// </summary>
			public UserOpPriv usri2_auth_flags;

			/// <summary>
			/// <para>Type: <c>LPWSTR</c></para>
			/// <para>
			/// A pointer to a Unicode string that contains the full name of the user. This string can be a <c>NULL</c> string, or it can
			/// have any number of characters before the terminating null character.
			/// </para>
			/// </summary>
			public string usri2_full_name;

			/// <summary>
			/// <para>Type: <c>LPWSTR</c></para>
			/// <para>
			/// A pointer to a Unicode string that contains a user comment. This string can be a <c>NULL</c> string, or it can have any
			/// number of characters before the terminating null character.
			/// </para>
			/// </summary>
			public string usri2_usr_comment;

			/// <summary>
			/// <para>Type: <c>LPWSTR</c></para>
			/// <para>
			/// A pointer to a Unicode string that is reserved for use by applications. This string can be a <c>NULL</c> string, or it can
			/// have any number of characters before the terminating null character. Microsoft products use this member to store user
			/// configuration information. Do not modify this information.
			/// </para>
			/// </summary>
			public string usri2_parms;

			/// <summary>
			/// <para>Type: <c>LPWSTR</c></para>
			/// <para>
			/// A pointer to a Unicode string that contains the names of workstations from which the user can log on. As many as eight
			/// workstations can be specified; the names must be separated by commas. A <c>NULL</c> string indicates that there is no
			/// restriction. To disable logons from all workstations to this account, set the UF_ACCOUNTDISABLE value in the
			/// <c>usri2_flags</c> member.
			/// </para>
			/// </summary>
			public string usri2_workstations;

			/// <summary>
			/// <para>Type: <c>DWORD</c></para>
			/// <para>
			/// The date and time when the last logon occurred. This value is stored as the number of seconds that have elapsed since
			/// 00:00:00, January 1, 1970, GMT. This member is ignored by the NetUserAdd and NetUserSetInfo functions.
			/// </para>
			/// <para>
			/// This member is maintained separately on each backup domain controller (BDC) in the domain. To obtain an accurate value, you
			/// must query each BDC in the domain. The last logon occurred at the time indicated by the largest retrieved value.
			/// </para>
			/// </summary>
			public uint usri2_last_logon;

			/// <summary>
			/// <para>Type: <c>DWORD</c></para>
			/// <para>This member is currently not used.</para>
			/// <para>
			/// Indicates when the last logoff occurred. This value is stored as the number of seconds that have elapsed since 00:00:00,
			/// January 1, 1970, GMT. A value of zero indicates that the last logoff time is unknown.
			/// </para>
			/// <para>
			/// This member is maintained separately on each backup domain controller (BDC) in the domain. To obtain an accurate value, you
			/// must query each BDC in the domain. The last logoff occurred at the time indicated by the largest retrieved value.
			/// </para>
			/// </summary>
			public uint usri2_last_logoff;

			/// <summary>
			/// <para>Type: <c>DWORD</c></para>
			/// <para>
			/// The date and time when the account expires. This value is stored as the number of seconds elapsed since 00:00:00, January 1,
			/// 1970, GMT. A value of TIMEQ_FOREVER indicates that the account never expires.
			/// </para>
			/// </summary>
			public uint usri2_acct_expires;

			/// <summary>
			/// <para>Type: <c>DWORD</c></para>
			/// <para>The maximum amount of disk space the user can use. Specify USER_MAXSTORAGE_UNLIMITED to use all available disk space.</para>
			/// </summary>
			public uint usri2_max_storage;

			/// <summary>
			/// <para>Type: <c>DWORD</c></para>
			/// <para>
			/// The number of equal-length time units into which the week is divided. This value is required to compute the length of the bit
			/// string in the <c>usri2_logon_hours</c> member.
			/// </para>
			/// <para>
			/// This value must be UNITS_PER_WEEK for LAN Manager 2.0. This element is ignored by the NetUserAdd and NetUserSetInfo functions.
			/// </para>
			/// <para>
			/// For service applications, the units must be one of the following values: SAM_DAYS_PER_WEEK, SAM_HOURS_PER_WEEK, or SAM_MINUTES_PER_WEEK.
			/// </para>
			/// </summary>
			public uint usri2_units_per_week;

			/// <summary>
			/// <para>Type: <c>PBYTE</c></para>
			/// <para>
			/// A pointer to a 21-byte (168 bits) bit string that specifies the times during which the user can log on. Each bit represents a
			/// unique hour in the week, in Greenwich Mean Time (GMT).
			/// </para>
			/// <para>
			/// The first bit (bit 0, word 0) is Sunday, 0:00 to 0:59; the second bit (bit 1, word 0) is Sunday, 1:00 to 1:59; and so on.
			/// Note that bit 0 in word 0 represents Sunday from 0:00 to 0:59 only if you are in the GMT time zone. In all other cases you
			/// must adjust the bits according to your time zone offset (for example, GMT minus 8 hours for Pacific Standard Time).
			/// </para>
			/// <para>
			/// Specify a <c>NULL</c> pointer in this member when calling the NetUserAdd function to indicate no time restriction. Specify a
			/// <c>NULL</c> pointer when calling the NetUserSetInfo function to indicate that no change is to be made to the times during
			/// which the user can log on.
			/// </para>
			/// </summary>
			public IntPtr usri2_logon_hours;

			/// <summary>
			/// <para>Type: <c>DWORD</c></para>
			/// <para>
			/// The number of times the user tried to log on to the account using an incorrect password. A value of – 1 indicates that the
			/// value is unknown. Calls to the NetUserAdd and NetUserSetInfo functions ignore this member.
			/// </para>
			/// <para>
			/// This member is replicated from the primary domain controller (PDC); it is also maintained on each backup domain controller
			/// (BDC) in the domain. To obtain an accurate value, you must query each BDC in the domain. The number of times the user tried
			/// to log on using an incorrect password is the largest value retrieved.
			/// </para>
			/// </summary>
			public uint usri2_bad_pw_count;

			/// <summary>
			/// <para>Type: <c>DWORD</c></para>
			/// <para>
			/// The number of times the user logged on successfully to this account. A value of – 1 indicates that the value is unknown.
			/// Calls to the <c>NetUserAdd</c> and <c>NetUserSetInfo</c> functions ignore this member.
			/// </para>
			/// <para>
			/// This member is maintained separately on each backup domain controller (BDC) in the domain. To obtain an accurate value, you
			/// must query each BDC in the domain. The number of times the user logged on successfully is the sum of the retrieved values.
			/// </para>
			/// </summary>
			public uint usri2_num_logons;

			/// <summary>
			/// <para>Type: <c>LPWSTR</c></para>
			/// <para>
			/// A pointer to a Unicode string that contains the name of the server to which logon requests are sent. Server names should be
			/// preceded by two backslashes (\). To indicate that the logon request can be handled by any logon server, specify an asterisk
			/// (\*) for the server name. A <c>NULL</c> string indicates that requests should be sent to the domain controller.
			/// </para>
			/// <para>
			/// For Windows servers, NetUserGetInfo and NetUserEnum return \*. The NetUserAdd and NetUserSetInfo functions ignore this member.
			/// </para>
			/// </summary>
			public string usri2_logon_server;

			/// <summary>
			/// <para>Type: <c>DWORD</c></para>
			/// <para>The country/region code for the user's language of choice.</para>
			/// </summary>
			public uint usri2_country_code;

			/// <summary>
			/// <para>Type: <c>DWORD</c></para>
			/// <para>The code page for the user's language of choice.</para>
			/// </summary>
			public uint usri2_code_page;
		}

		/// <summary>
		/// <para>
		/// The <c>USER_INFO_20</c> structure contains information about a user account, including the account name, the user's full name, a
		/// comment associated with the account, and the user's relative ID (RID).
		/// </para>
		/// <para>
		/// <c>Note</c> The USER_INFO_23 structure supersedes the <c>USER_INFO_20</c> structure. It is recommended that applications use the
		/// <c>USER_INFO_23</c> structure instead of the <c>USER_INFO_20</c> structure.
		/// </para>
		/// </summary>
		/// <remarks>
		/// User account names are limited to 20 characters and group names are limited to 256 characters. In addition, account names cannot
		/// be terminated by a period and they cannot include commas or any of the following printable characters: ", /, , [, ], :, |, &lt;,
		/// &gt;, +, =, ;, ?, *. Names also cannot include characters in the range 1-31, which are non-printable.
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows/desktop/api/lmaccess/ns-lmaccess-_user_info_20 typedef struct _USER_INFO_20 { LPWSTR
		// usri20_name; LPWSTR usri20_full_name; LPWSTR usri20_comment; DWORD usri20_flags; DWORD usri20_user_id; } USER_INFO_20,
		// *PUSER_INFO_20, *LPUSER_INFO_20;
		[PInvokeData("lmaccess.h", MSDNShortId = "67f58d6b-488b-4a88-808f-edb9c3464d85")]
		[StructLayout(LayoutKind.Sequential, CharSet = CharSet.Unicode)]
		public struct USER_INFO_20
		{
			/// <summary>
			/// <para>Type: <c>LPWSTR</c></para>
			/// <para>
			/// A pointer to a Unicode string that specifies the name of the user account. Calls to the NetUserSetInfo function ignore this
			/// member. For more information, see the following Remarks section.
			/// </para>
			/// </summary>
			public string usri20_name;

			/// <summary>
			/// <para>Type: <c>LPWSTR</c></para>
			/// <para>
			/// A pointer to a Unicode string that contains the full name of the user. This string can be a null string, or it can have any
			/// number of characters before the terminating null character.
			/// </para>
			/// </summary>
			public string usri20_full_name;

			/// <summary>
			/// <para>Type: <c>LPWSTR</c></para>
			/// <para>
			/// A pointer to a Unicode string that contains a comment associated with the user account. This string can be a null string, or
			/// it can have any number of characters before the terminating null character.
			/// </para>
			/// </summary>
			public string usri20_comment;

			/// <summary>
			/// <para>Type: <c>DWORD</c></para>
			/// <para>This member can be one or more of the following values.</para>
			/// <para>
			/// Note that setting user account control flags may require certain privileges and control access rights. For more information,
			/// see the Remarks section of the NetUserSetInfo function.
			/// </para>
			/// <list type="table">
			/// <listheader>
			/// <term>Value</term>
			/// <term>Meaning</term>
			/// </listheader>
			/// <item>
			/// <term>UF_SCRIPT</term>
			/// <term>The logon script executed. This value must be set.</term>
			/// </item>
			/// <item>
			/// <term>UF_ACCOUNTDISABLE</term>
			/// <term>The user's account is disabled.</term>
			/// </item>
			/// <item>
			/// <term>UF_HOMEDIR_REQUIRED</term>
			/// <term>The home directory is required. This value is ignored.</term>
			/// </item>
			/// <item>
			/// <term>UF_PASSWD_NOTREQD</term>
			/// <term>No password is required.</term>
			/// </item>
			/// <item>
			/// <term>UF_PASSWD_CANT_CHANGE</term>
			/// <term>The user cannot change the password.</term>
			/// </item>
			/// <item>
			/// <term>UF_LOCKOUT</term>
			/// <term>
			/// The account is currently locked out. You can call the NetUserSetInfo function to clear this value and unlock a previously
			/// locked account. You cannot use this value to lock a previously unlocked account.
			/// </term>
			/// </item>
			/// <item>
			/// <term>UF_DONT_EXPIRE_PASSWD</term>
			/// <term>The password should never expire on the account.</term>
			/// </item>
			/// <item>
			/// <term>UF_ENCRYPTED_TEXT_PASSWORD_ALLOWED</term>
			/// <term>The user's password is stored under reversible encryption in the Active Directory.</term>
			/// </item>
			/// <item>
			/// <term>UF_NOT_DELEGATED</term>
			/// <term>Marks the account as "sensitive"; other users cannot act as delegates of this user account.</term>
			/// </item>
			/// <item>
			/// <term>UF_SMARTCARD_REQUIRED</term>
			/// <term>Requires the user to log on to the user account with a smart card.</term>
			/// </item>
			/// <item>
			/// <term>UF_USE_DES_KEY_ONLY</term>
			/// <term>Restrict this principal to use only Data Encryption Standard (DES) encryption types for keys.</term>
			/// </item>
			/// <item>
			/// <term>UF_DONT_REQUIRE_PREAUTH</term>
			/// <term>This account does not require Kerberos preauthentication for logon.</term>
			/// </item>
			/// <item>
			/// <term>UF_TRUSTED_FOR_DELEGATION</term>
			/// <term>
			/// The account is enabled for delegation. This is a security-sensitive setting; accounts with this option enabled should be
			/// tightly controlled. This setting allows a service running under the account to assume a client's identity and authenticate as
			/// that user to other remote servers on the network.
			/// </term>
			/// </item>
			/// <item>
			/// <term>UF_PASSWORD_EXPIRED</term>
			/// <term>The user's password has expired. Windows 2000: This value is not supported.</term>
			/// </item>
			/// <item>
			/// <term>UF_TRUSTED_TO_AUTHENTICATE_FOR_DELEGATION</term>
			/// <term>
			/// The account is trusted to authenticate a user outside of the Kerberos security package and delegate that user through
			/// constrained delegation. This is a security-sensitive setting; accounts with this option enabled should be tightly controlled.
			/// This setting allows a service running under the account to assert a client's identity and authenticate as that user to
			/// specifically configured services on the network. Windows XP/2000: This value is not supported.
			/// </term>
			/// </item>
			/// </list>
			/// <para>
			/// The following values describe the account type. Only one value can be set. You cannot change the account type using the
			/// NetUserSetInfo function.
			/// </para>
			/// <list type="table">
			/// <listheader>
			/// <term>Value</term>
			/// <term>Meaning</term>
			/// </listheader>
			/// <item>
			/// <term>UF_NORMAL_ACCOUNT</term>
			/// <term>This is a default account type that represents a typical user.</term>
			/// </item>
			/// <item>
			/// <term>UF_TEMP_DUPLICATE_ACCOUNT</term>
			/// <term>
			/// This is an account for users whose primary account is in another domain. This account provides user access to this domain,
			/// but not to any domain that trusts this domain. The User Manager refers to this account type as a local user account.
			/// </term>
			/// </item>
			/// <item>
			/// <term>UF_WORKSTATION_TRUST_ACCOUNT</term>
			/// <term>This is a computer account for a computer that is a member of this domain.</term>
			/// </item>
			/// <item>
			/// <term>UF_SERVER_TRUST_ACCOUNT</term>
			/// <term>This is a computer account for a backup domain controller that is a member of this domain.</term>
			/// </item>
			/// <item>
			/// <term>UF_INTERDOMAIN_TRUST_ACCOUNT</term>
			/// <term>This is a permit to trust account for a domain that trusts other domains.</term>
			/// </item>
			/// </list>
			/// </summary>
			public UserAcctCtrlFlags usri20_flags;

			/// <summary>
			/// <para>Type: <c>DWORD</c></para>
			/// <para>
			/// The user's relative identifier (RID). The RID is determined by the Security Account Manager (SAM) when the user is created.
			/// It uniquely defines this user account to SAM within the domain. The NetUserAdd and NetUserSetInfo functions ignore this
			/// member. For more information about RIDs, see SID Components.
			/// </para>
			/// </summary>
			public uint usri20_user_id;
		}

		/// <summary>The <c>USER_INFO_21</c> structure contains a one-way encrypted LAN Manager 2.x-compatible password.</summary>
		// https://docs.microsoft.com/en-us/windows/desktop/api/lmaccess/ns-lmaccess-_user_info_21 typedef struct _USER_INFO_21 { BYTE
		// usri21_password[ENCRYPTED_PWLEN]; } USER_INFO_21, *PUSER_INFO_21, *LPUSER_INFO_21;
		[PInvokeData("lmaccess.h", MSDNShortId = "227e97c5-972e-4d4a-9609-53e60e76d43e")]
		[StructLayout(LayoutKind.Sequential, CharSet = CharSet.Unicode)]
		public struct USER_INFO_21
		{
			/// <summary>Specifies a one-way encrypted LAN Manager 2.x-compatible password.</summary>
			[MarshalAs(UnmanagedType.ByValArray, SizeConst = ENCRYPTED_PWLEN)]
			public byte[] usri21_password;
		}

		/// <summary>
		/// The <c>USER_INFO_22</c> structure contains information about a user account, including the account name, privilege level, the
		/// path to the user's home directory, a one-way encrypted LAN Manager 2.x-compatible password, and other user-related network statistics.
		/// </summary>
		/// <remarks>
		/// User account names are limited to 20 characters and group names are limited to 256 characters. In addition, account names cannot
		/// be terminated by a period and they cannot include commas or any of the following printable characters: ", /, , [, ], :, |, &lt;,
		/// &gt;, +, =, ;, ?, *. Names also cannot include characters in the range 1-31, which are non-printable.
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows/desktop/api/lmaccess/ns-lmaccess-_user_info_22 typedef struct _USER_INFO_22 { LPWSTR
		// usri22_name; BYTE usri22_password[ENCRYPTED_PWLEN]; DWORD usri22_password_age; DWORD usri22_priv; LPWSTR usri22_home_dir; LPWSTR
		// usri22_comment; DWORD usri22_flags; LPWSTR usri22_script_path; DWORD usri22_auth_flags; LPWSTR usri22_full_name; LPWSTR
		// usri22_usr_comment; LPWSTR usri22_parms; LPWSTR usri22_workstations; DWORD usri22_last_logon; DWORD usri22_last_logoff; DWORD
		// usri22_acct_expires; DWORD usri22_max_storage; DWORD usri22_units_per_week; PBYTE usri22_logon_hours; DWORD usri22_bad_pw_count;
		// DWORD usri22_num_logons; LPWSTR usri22_logon_server; DWORD usri22_country_code; DWORD usri22_code_page; } USER_INFO_22,
		// *PUSER_INFO_22, *LPUSER_INFO_22;
		[PInvokeData("lmaccess.h", MSDNShortId = "ff8d2088-953b-4a8a-bdcb-86148dc66a7a")]
		[StructLayout(LayoutKind.Sequential, CharSet = CharSet.Unicode)]
		public struct USER_INFO_22
		{
			/// <summary>
			/// <para>Type: <c>LPWSTR</c></para>
			/// <para>
			/// A pointer to a Unicode string that specifies the name of the user account. Calls to the NetUserSetInfo function ignore this
			/// member. For more information, see the following Remarks section.
			/// </para>
			/// </summary>
			public string usri22_name;

			/// <summary>
			/// <para>Type: <c>BYTE[ENCRYPTED_PWLEN]</c></para>
			/// <para>A one-way encrypted LAN Manager 2.x-compatible password.</para>
			/// </summary>
			[MarshalAs(UnmanagedType.ByValArray, SizeConst = ENCRYPTED_PWLEN)]
			public byte[] usri22_password;

			/// <summary>
			/// <para>Type: <c>DWORD</c></para>
			/// <para>
			/// The number of seconds that have elapsed since the <c>usri22_password</c> member was last changed. The NetUserAdd and
			/// NetUserSetInfo functions ignore this member.
			/// </para>
			/// </summary>
			public uint usri22_password_age;

			/// <summary>
			/// <para>Type: <c>DWORD</c></para>
			/// <para>
			/// The level of privilege assigned to the <c>usri22_name</c> member. Calls to the <c>NetUserAdd</c> function must specify
			/// USER_PRIV_USER. When you call the <c>NetUserSetInfo</c> function this member must be the value returned from the
			/// NetUserGetInfo or the NetUserEnum function. This member can be one of the following values. For more information about user
			/// and group account rights, see Privileges.
			/// </para>
			/// <list type="table">
			/// <listheader>
			/// <term>Value</term>
			/// <term>Meaning</term>
			/// </listheader>
			/// <item>
			/// <term>USER_PRIV_GUEST</term>
			/// <term>Guest</term>
			/// </item>
			/// <item>
			/// <term>USER_PRIV_USER</term>
			/// <term>User</term>
			/// </item>
			/// <item>
			/// <term>USER_PRIV_ADMIN</term>
			/// <term>Administrator</term>
			/// </item>
			/// </list>
			/// </summary>
			public UserPrivilege usri22_priv;

			/// <summary>
			/// <para>Type: <c>LPWSTR</c></para>
			/// <para>
			/// A pointer to a Unicode string specifying the path of the home directory for the user specified by the <c>usri22_name</c>
			/// member. The string can be null.
			/// </para>
			/// </summary>
			public string usri22_home_dir;

			/// <summary>
			/// <para>Type: <c>LPWSTR</c></para>
			/// <para>
			/// A pointer to a Unicode string that contains a comment associated with the user account. This string can be a null string, or
			/// it can have any number of characters before the terminating null character.
			/// </para>
			/// </summary>
			public string usri22_comment;

			/// <summary>
			/// <para>Type: <c>DWORD</c></para>
			/// <para>This member can be one or more of the following values.</para>
			/// <para>
			/// Note that setting user account control flags may require certain privileges and control access rights. For more information,
			/// see the Remarks section of the NetUserSetInfo function.
			/// </para>
			/// <list type="table">
			/// <listheader>
			/// <term>Value</term>
			/// <term>Meaning</term>
			/// </listheader>
			/// <item>
			/// <term>UF_SCRIPT</term>
			/// <term>The logon script executed. This value must be set.</term>
			/// </item>
			/// <item>
			/// <term>UF_ACCOUNTDISABLE</term>
			/// <term>The user's account is disabled.</term>
			/// </item>
			/// <item>
			/// <term>UF_HOMEDIR_REQUIRED</term>
			/// <term>The home directory is required. This value is ignored.</term>
			/// </item>
			/// <item>
			/// <term>UF_PASSWD_NOTREQD</term>
			/// <term>No password is required.</term>
			/// </item>
			/// <item>
			/// <term>UF_PASSWD_CANT_CHANGE</term>
			/// <term>The user cannot change the password.</term>
			/// </item>
			/// <item>
			/// <term>UF_LOCKOUT</term>
			/// <term>
			/// The account is currently locked out. You can call the NetUserSetInfo function to clear this value and unlock a previously
			/// locked account. You cannot use this value to lock a previously unlocked account.
			/// </term>
			/// </item>
			/// <item>
			/// <term>UF_DONT_EXPIRE_PASSWD</term>
			/// <term>The password should never expire on the account.</term>
			/// </item>
			/// <item>
			/// <term>UF_ENCRYPTED_TEXT_PASSWORD_ALLOWED</term>
			/// <term>The user's password is stored under reversible encryption in the Active Directory.</term>
			/// </item>
			/// <item>
			/// <term>UF_NOT_DELEGATED</term>
			/// <term>Marks the account as "sensitive"; other users cannot act as delegates of this user account.</term>
			/// </item>
			/// <item>
			/// <term>UF_SMARTCARD_REQUIRED</term>
			/// <term>Requires the user to log on to the user account with a smart card.</term>
			/// </item>
			/// <item>
			/// <term>UF_USE_DES_KEY_ONLY</term>
			/// <term>Restrict this principal to use only Data Encryption Standard (DES) encryption types for keys.</term>
			/// </item>
			/// <item>
			/// <term>UF_DONT_REQUIRE_PREAUTH</term>
			/// <term>This account does not require Kerberos preauthentication for logon.</term>
			/// </item>
			/// <item>
			/// <term>UF_TRUSTED_FOR_DELEGATION</term>
			/// <term>
			/// The account is enabled for delegation. This is a security-sensitive setting; accounts with this option enabled should be
			/// tightly controlled. This setting allows a service running under the account to assume a client's identity and authenticate as
			/// that user to other remote servers on the network.
			/// </term>
			/// </item>
			/// <item>
			/// <term>UF_PASSWORD_EXPIRED</term>
			/// <term>The user's password has expired. Windows 2000: This value is not supported.</term>
			/// </item>
			/// <item>
			/// <term>UF_TRUSTED_TO_AUTHENTICATE_FOR_DELEGATION</term>
			/// <term>
			/// The account is trusted to authenticate a user outside of the Kerberos security package and delegate that user through
			/// constrained delegation. This is a security-sensitive setting; accounts with this option enabled should be tightly controlled.
			/// This setting allows a service running under the account to assert a client's identity and authenticate as that user to
			/// specifically configured services on the network. Windows XP/2000: This value is not supported.
			/// </term>
			/// </item>
			/// </list>
			/// <para>
			/// The following values describe the account type. Only one value can be set. You cannot change the account type using the
			/// NetUserSetInfo function.
			/// </para>
			/// <list type="table">
			/// <listheader>
			/// <term>Value</term>
			/// <term>Meaning</term>
			/// </listheader>
			/// <item>
			/// <term>UF_NORMAL_ACCOUNT</term>
			/// <term>This is a default account type that represents a typical user.</term>
			/// </item>
			/// <item>
			/// <term>UF_TEMP_DUPLICATE_ACCOUNT</term>
			/// <term>
			/// This is an account for users whose primary account is in another domain. This account provides user access to this domain,
			/// but not to any domain that trusts this domain. The User Manager refers to this account type as a local user account.
			/// </term>
			/// </item>
			/// <item>
			/// <term>UF_WORKSTATION_TRUST_ACCOUNT</term>
			/// <term>This is a computer account for a computer that is a member of this domain.</term>
			/// </item>
			/// <item>
			/// <term>UF_SERVER_TRUST_ACCOUNT</term>
			/// <term>This is a computer account for a backup domain controller that is a member of this domain.</term>
			/// </item>
			/// <item>
			/// <term>UF_INTERDOMAIN_TRUST_ACCOUNT</term>
			/// <term>This is a permit to trust account for a domain that trusts other domains.</term>
			/// </item>
			/// </list>
			/// </summary>
			public UserAcctCtrlFlags usri22_flags;

			/// <summary>
			/// <para>Type: <c>LPWSTR</c></para>
			/// <para>
			/// A pointer to a Unicode string specifying the path for the user's logon script file. The script file can be a .CMD file, an
			/// .EXE file, or a .BAT file. The string can also be null.
			/// </para>
			/// </summary>
			public string usri22_script_path;

			/// <summary>
			/// <para>Type: <c>DWORD</c></para>
			/// <para>The user's operator privileges.</para>
			/// <para>
			/// Calls to the <c>NetUserGetInfo</c> function and the <c>NetUserEnum</c> function return a value based on the user's local
			/// group membership. If the user is a member of Print Operators, AF_OP_PRINT, is set. If the user is a member of Server
			/// Operators, AF_OP_SERVER, is set. If the user is a member of the Account Operators, AF_OP_ACCOUNTS, is set. AF_OP_COMM is
			/// never set.
			/// </para>
			/// <para>The following restrictions apply:</para>
			/// <list type="bullet">
			/// <item>
			/// <term>When you call the NetUserAdd function, this member must be zero.</term>
			/// </item>
			/// <item>
			/// <term>
			/// When you call the NetUserSetInfo function, this member must be the value returned from a call to NetUserGetInfo or to NetUserEnum.
			/// </term>
			/// </item>
			/// </list>
			/// <para>This member can be one or more of the following values.</para>
			/// <list type="table">
			/// <listheader>
			/// <term>Value</term>
			/// <term>Meaning</term>
			/// </listheader>
			/// <item>
			/// <term>AF_OP_PRINT</term>
			/// <term>The print operator privilege is enabled.</term>
			/// </item>
			/// <item>
			/// <term>AF_OP_COMM</term>
			/// <term>The communications operator privilege is enabled.</term>
			/// </item>
			/// <item>
			/// <term>AF_OP_SERVER</term>
			/// <term>The server operator privilege is enabled.</term>
			/// </item>
			/// <item>
			/// <term>AF_OP_ACCOUNTS</term>
			/// <term>The accounts operator privilege is enabled.</term>
			/// </item>
			/// </list>
			/// </summary>
			public UserOpPriv usri22_auth_flags;

			/// <summary>
			/// <para>Type: <c>LPWSTR</c></para>
			/// <para>
			/// A pointer to a Unicode string that contains the full name of the user. This string can be a null string, or it can have any
			/// number of characters before the terminating null character.
			/// </para>
			/// </summary>
			public string usri22_full_name;

			/// <summary>
			/// <para>Type: <c>LPWSTR</c></para>
			/// <para>
			/// A pointer to a Unicode string that contains a user comment. This string can be a null string, or it can have any number of
			/// characters before the terminating null character.
			/// </para>
			/// </summary>
			public string usri22_usr_comment;

			/// <summary>
			/// <para>Type: <c>LPWSTR</c></para>
			/// <para>
			/// A pointer to a Unicode string that is reserved for use by applications. This string can be a null string, or it can have any
			/// number of characters before the terminating null character. Microsoft products use this member to store user configuration
			/// information. Do not modify this information.
			/// </para>
			/// </summary>
			public string usri22_parms;

			/// <summary>
			/// <para>Type: <c>LPWSTR</c></para>
			/// <para>
			/// A pointer to a Unicode string that contains the names of workstations from which the user can log on. As many as eight
			/// workstations can be specified; the names must be separated by commas. A null string indicates that there is no restriction.
			/// To disable logons from all workstations to this account, set the UF_ACCOUNTDISABLE value in the <c>usri22_flags</c> member.
			/// </para>
			/// </summary>
			public string usri22_workstations;

			/// <summary>
			/// <para>Type: <c>DWORD</c></para>
			/// <para>
			/// The date and time when the last logon occurred. This value is stored as the number of seconds that have elapsed since
			/// 00:00:00, January 1, 1970, GMT. Calls to the NetUserAdd and the NetUserSetInfo functions ignore this member.
			/// </para>
			/// <para>
			/// This member is maintained separately on each backup domain controller (BDC) in the domain. To obtain an accurate value, you
			/// must query each BDC in the domain. The last logon occurred at the time indicated by the largest retrieved value.
			/// </para>
			/// </summary>
			public uint usri22_last_logon;

			/// <summary>
			/// <para>Type: <c>DWORD</c></para>
			/// <para>This member is currently not used.</para>
			/// <para>
			/// The date and time when the last logoff occurred. This value is stored as the number of seconds that have elapsed since
			/// 00:00:00, January 1, 1970, GMT. A value of zero means that the last logoff time is unknown. This element is ignored by calls
			/// to <c>NetUserAdd</c> and <c>NetUserSetInfo</c>.
			/// </para>
			/// <para>
			/// This member is maintained separately on each backup domain controller (BDC) in the domain. To obtain an accurate value, you
			/// must query each BDC in the domain. The last logoff occurred at the time indicated by the largest retrieved value.
			/// </para>
			/// </summary>
			public uint usri22_last_logoff;

			/// <summary>
			/// <para>Type: <c>DWORD</c></para>
			/// <para>
			/// The date and time when the account expires. This value is stored as the number of seconds that have elapsed since 00:00:00,
			/// January 1, 1970, GMT. A value of TIMEQ_FOREVER indicates that the account never expires.
			/// </para>
			/// </summary>
			public uint usri22_acct_expires;

			/// <summary>
			/// <para>Type: <c>DWORD</c></para>
			/// <para>The maximum amount of disk space the user can use. Specify USER_MAXSTORAGE_UNLIMITED to use all available disk space.</para>
			/// </summary>
			public uint usri22_max_storage;

			/// <summary>
			/// <para>Type: <c>DWORD</c></para>
			/// <para>
			/// The number of equal-length time units into which the week is divided. This value is required to compute the length of the bit
			/// string in the <c>usri22_logon_hours</c> member.
			/// </para>
			/// <para>
			/// This value must be UNITS_PER_WEEK for LAN Manager 2.0. Calls to the NetUserAdd and NetUserSetInfo functions ignore this member.
			/// </para>
			/// <para>For service applications, the units must be one of the following: SAM_DAYS_PER_WEEK, SAM_HOURS_PER_WEEK, or SAM_MINUTES_PER_WEEK.</para>
			/// </summary>
			public uint usri22_units_per_week;

			/// <summary>
			/// <para>Type: <c>PBYTE</c></para>
			/// <para>
			/// A pointer to a 21-byte (168 bits) bit string that specifies the times during which the user can log on. Each bit represents a
			/// unique hour in the week, in Greenwich Mean Time (GMT).
			/// </para>
			/// <para>
			/// The first bit (bit 0, word 0) is Sunday, 0:00 to 0:59; the second bit (bit 1, word 0) is Sunday, 1:00 to 1:59; and so on.
			/// Note that bit 0 in word 0 represents Sunday from 0:00 to 0:59 only if you are in the GMT time zone. In all other cases you
			/// must adjust the bits according to your time zone offset (for example, GMT minus 8 hours for Pacific Standard Time).
			/// </para>
			/// <para>
			/// Specify a null pointer in this member when calling the NetUserAdd function to indicate no time restriction. Specify a null
			/// pointer when calling the NetUserSetInfo function to indicate that no change is to be made to the times during which the user
			/// can log on.
			/// </para>
			/// </summary>
			public IntPtr usri22_logon_hours;

			/// <summary>
			/// <para>Type: <c>DWORD</c></para>
			/// <para>
			/// The number of times the user tried to log on to this account using an incorrect password. A value of – 1 indicates that the
			/// value is unknown. Calls to the NetUserAdd and NetUserSetInfo functions ignore this member.
			/// </para>
			/// <para>
			/// This member is replicated from the primary domain controller (PDC); it is also maintained on each backup domain controller
			/// (BDC) in the domain. To obtain an accurate value, you must query each BDC in the domain. The number of times the user tried
			/// to log on using an incorrect password is the largest value retrieved.
			/// </para>
			/// </summary>
			public uint usri22_bad_pw_count;

			/// <summary>
			/// <para>Type: <c>DWORD</c></para>
			/// <para>
			/// The number of times the user logged on successfully to this account. A value of – 1 indicates that the value is unknown.
			/// Calls to the <c>NetUserAdd</c> and <c>NetUserSetInfo</c> functions ignore this member.
			/// </para>
			/// <para>
			/// This member is maintained separately on each backup domain controller (BDC) in the domain. To obtain an accurate value, you
			/// must query each BDC in the domain. The number of times the user logged on successfully is the sum of the retrieved values.
			/// </para>
			/// </summary>
			public uint usri22_num_logons;

			/// <summary>
			/// <para>Type: <c>LPWSTR</c></para>
			/// <para>
			/// A pointer to a Unicode string that contains the name of the server to which logon requests are sent. Server names should be
			/// preceded by two backslashes (\). To indicate that the logon request can be handled by any logon server, specify an asterisk
			/// (\*) for the server name. A null string indicates that requests should be sent to the domain controller.
			/// </para>
			/// <para>
			/// For Windows servers, the NetUserGetInfo and NetUserEnum functions return \*. Calls to the NetUserAdd and NetUserSetInfo
			/// functions ignore this member.
			/// </para>
			/// </summary>
			public string usri22_logon_server;

			/// <summary>
			/// <para>Type: <c>DWORD</c></para>
			/// <para>The country/region code for the user's language of choice.</para>
			/// <para>This value is ignored.</para>
			/// </summary>
			public uint usri22_country_code;

			/// <summary>
			/// <para>Type: <c>DWORD</c></para>
			/// <para>The code page for the user's language of choice.</para>
			/// <para>This value is ignored.</para>
			/// </summary>
			public uint usri22_code_page;
		}

		/// <summary>
		/// <para>
		/// The <c>USER_INFO_23</c> structure contains information about a user account, including the account name, the user's full name, a
		/// comment associated with the account, and the user's security identifier (SID).
		/// </para>
		/// <para>
		/// <c>Note</c> The <c>USER_INFO_23</c> structure supersedes the USER_INFO_20 structure. It is recommended that applications use the
		/// <c>USER_INFO_23</c> structure instead of the <c>USER_INFO_20</c> structure.
		/// </para>
		/// </summary>
		// https://docs.microsoft.com/en-us/windows/desktop/api/lmaccess/ns-lmaccess-_user_info_23 typedef struct _USER_INFO_23 { LPWSTR
		// usri23_name; LPWSTR usri23_full_name; LPWSTR usri23_comment; DWORD usri23_flags; PSID usri23_user_sid; } USER_INFO_23,
		// *PUSER_INFO_23, *LPUSER_INFO_23;
		[PInvokeData("lmaccess.h", MSDNShortId = "1af3ff6d-bc9f-44ad-9981-124ac1961298")]
		[StructLayout(LayoutKind.Sequential, CharSet = CharSet.Unicode)]
		public struct USER_INFO_23
		{
			/// <summary>
			/// <para>Type: <c>LPWSTR</c></para>
			/// <para>
			/// A pointer to a Unicode string that specifies the name of the user account. Calls to the NetUserSetInfo function ignore this member.
			/// </para>
			/// </summary>
			public string usri23_name;

			/// <summary>
			/// <para>Type: <c>LPWSTR</c></para>
			/// <para>
			/// A pointer to a Unicode string that contains the full name of the user. This string can be a null string, or it can have any
			/// number of characters before the terminating null character.
			/// </para>
			/// </summary>
			public string usri23_full_name;

			/// <summary>
			/// <para>Type: <c>LPWSTR</c></para>
			/// <para>
			/// A pointer to a Unicode string that contains a comment associated with the user account. This string can be a null string, or
			/// it can have any number of characters before the terminating null character.
			/// </para>
			/// </summary>
			public string usri23_comment;

			/// <summary>
			/// <para>Type: <c>DWORD</c></para>
			/// <para>This member can be one or more of the following values.</para>
			/// <para>
			/// Note that setting user account control flags may require certain privileges and control access rights. For more information,
			/// see the Remarks section of the NetUserSetInfo function.
			/// </para>
			/// <list type="table">
			/// <listheader>
			/// <term>Value</term>
			/// <term>Meaning</term>
			/// </listheader>
			/// <item>
			/// <term>UF_SCRIPT</term>
			/// <term>The logon script executed. This value must be set.</term>
			/// </item>
			/// <item>
			/// <term>UF_ACCOUNTDISABLE</term>
			/// <term>The user's account is disabled.</term>
			/// </item>
			/// <item>
			/// <term>UF_HOMEDIR_REQUIRED</term>
			/// <term>The home directory is required. This value is ignored.</term>
			/// </item>
			/// <item>
			/// <term>UF_PASSWD_NOTREQD</term>
			/// <term>No password is required.</term>
			/// </item>
			/// <item>
			/// <term>UF_PASSWD_CANT_CHANGE</term>
			/// <term>The user cannot change the password.</term>
			/// </item>
			/// <item>
			/// <term>UF_LOCKOUT</term>
			/// <term>
			/// The account is currently locked out. You can call the NetUserSetInfo function to clear this value and unlock a previously
			/// locked account. You cannot use this value to lock a previously unlocked account.
			/// </term>
			/// </item>
			/// <item>
			/// <term>UF_DONT_EXPIRE_PASSWD</term>
			/// <term>The password should never expire on the account.</term>
			/// </item>
			/// <item>
			/// <term>UF_ENCRYPTED_TEXT_PASSWORD_ALLOWED</term>
			/// <term>The user's password is stored under reversible encryption in the Active Directory.</term>
			/// </item>
			/// <item>
			/// <term>UF_NOT_DELEGATED</term>
			/// <term>Marks the account as "sensitive"; other users cannot act as delegates of this user account.</term>
			/// </item>
			/// <item>
			/// <term>UF_SMARTCARD_REQUIRED</term>
			/// <term>Requires the user to log on to the user account with a smart card.</term>
			/// </item>
			/// <item>
			/// <term>UF_USE_DES_KEY_ONLY</term>
			/// <term>Restrict this principal to use only Data Encryption Standard (DES) encryption types for keys.</term>
			/// </item>
			/// <item>
			/// <term>UF_DONT_REQUIRE_PREAUTH</term>
			/// <term>This account does not require Kerberos preauthentication for logon.</term>
			/// </item>
			/// <item>
			/// <term>UF_TRUSTED_FOR_DELEGATION</term>
			/// <term>
			/// The account is enabled for delegation. This is a security-sensitive setting; accounts with this option enabled should be
			/// tightly controlled. This setting allows a service running under the account to assume a client's identity and authenticate as
			/// that user to other remote servers on the network.
			/// </term>
			/// </item>
			/// <item>
			/// <term>UF_PASSWORD_EXPIRED</term>
			/// <term>The user's password has expired. Windows 2000: This value is not supported.</term>
			/// </item>
			/// <item>
			/// <term>UF_TRUSTED_TO_AUTHENTICATE_FOR_DELEGATION</term>
			/// <term>
			/// The account is trusted to authenticate a user outside of the Kerberos security package and delegate that user through
			/// constrained delegation. This is a security-sensitive setting; accounts with this option enabled should be tightly controlled.
			/// This setting allows a service running under the account to assert a client's identity and authenticate as that user to
			/// specifically configured services on the network. Windows XP/2000: This value is not supported.
			/// </term>
			/// </item>
			/// </list>
			/// <para>
			/// The following values describe the account type. Only one value can be set. You cannot change the account type using the
			/// NetUserSetInfo function.
			/// </para>
			/// <list type="table">
			/// <listheader>
			/// <term>Value</term>
			/// <term>Meaning</term>
			/// </listheader>
			/// <item>
			/// <term>UF_NORMAL_ACCOUNT</term>
			/// <term>This is a default account type that represents a typical user.</term>
			/// </item>
			/// <item>
			/// <term>UF_TEMP_DUPLICATE_ACCOUNT</term>
			/// <term>
			/// This is an account for users whose primary account is in another domain. This account provides user access to this domain,
			/// but not to any domain that trusts this domain. The User Manager refers to this account type as a local user account.
			/// </term>
			/// </item>
			/// <item>
			/// <term>UF_WORKSTATION_TRUST_ACCOUNT</term>
			/// <term>This is a computer account for a computer that is a member of this domain.</term>
			/// </item>
			/// <item>
			/// <term>UF_SERVER_TRUST_ACCOUNT</term>
			/// <term>This is a computer account for a backup domain controller that is a member of this domain.</term>
			/// </item>
			/// <item>
			/// <term>UF_INTERDOMAIN_TRUST_ACCOUNT</term>
			/// <term>This is a permit to trust account for a domain that trusts other domains.</term>
			/// </item>
			/// </list>
			/// </summary>
			public UserAcctCtrlFlags usri23_flags;

			/// <summary>
			/// <para>Type: <c>PSID</c></para>
			/// <para>
			/// A pointer to a SID structure that contains the security identifier (SID) that uniquely identifies the user. The NetUserAdd
			/// and NetUserSetInfo functions ignore this member.
			/// </para>
			/// </summary>
			public PSID usri23_user_sid;
		}

		/// <summary>
		/// The <c>USER_INFO_24</c> structure contains user account information on an account which is connected to an Internet identity.
		/// This information includes the Internet provider name for the user, the user's Internet name, and the user's security identifier (SID).
		/// </summary>
		/// <remarks>
		/// <para>
		/// A user's account for logging onto Windows can be connected to an Internet identity. The user account can be a local account on a
		/// computer or a domain account for computers joined to a domain. The <c>USER_INFO_24</c> structure is used to provide information
		/// on an account which is connected to an Internet identity.
		/// </para>
		/// <para>
		/// On Windows 8 and Windows Server 2012, the Internet identity for a connected account can often be used instead of the computer account.
		/// </para>
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows/desktop/api/lmaccess/ns-lmaccess-_user_info_24 typedef struct _USER_INFO_24 { BOOL
		// usri24_internet_identity; DWORD usri24_flags; LPWSTR usri24_internet_provider_name; LPWSTR usri24_internet_principal_name; PSID
		// usri24_user_sid; } USER_INFO_24, *PUSER_INFO_24, *LPUSER_INFO_24;
		[PInvokeData("lmaccess.h", MSDNShortId = "CE65EDE0-F4AE-4582-9D7F-6667BBA98C75")]
		[StructLayout(LayoutKind.Sequential, CharSet = CharSet.Unicode)]
		public struct USER_INFO_24
		{
			/// <summary>
			/// <para>A boolean value that indicates whether an account is connected to an Internet identity.</para>
			/// <para>
			/// This member is true if the account is connected to an Internet identity. The other members in this structure can be used.
			/// </para>
			/// <para>
			/// If this member is false, then the account is not connected to an Internet identity and other members in this structure should
			/// be ignored.
			/// </para>
			/// </summary>
			[MarshalAs(UnmanagedType.Bool)] public bool usri24_internet_identity;

			/// <summary>A set of flags. This member must be zero.</summary>
			public UserAcctCtrlFlags usri24_flags;

			/// <summary>A pointer to a Unicode string that specifies the Internet provider name.</summary>
			public string usri24_internet_provider_name;

			/// <summary>A pointer to a Unicode string that specifies the user's Internet name.</summary>
			public string usri24_internet_principal_name;

			/// <summary>The local account SID of the user.</summary>
			public PSID usri24_user_sid;
		}

		/// <summary>
		/// The <c>USER_INFO_3</c> structure contains information about a user account, including the account name, password data, privilege
		/// level, the path to the user's home directory, relative identifiers (RIDs), and other user-related network statistics.
		/// </summary>
		/// <remarks>
		/// <para>The <c>USER_INFO_3</c> structure can be used with the NetUserAdd, NetUserEnum, NetUserSetInfo, and NetUserGetInfofunctions.</para>
		/// <para>
		/// User account names are limited to 20 characters and group names are limited to 256 characters. In addition, account names cannot
		/// be terminated by a period and they cannot include commas or any of the following printable characters: ", /, , [, ], :, |, &lt;,
		/// &gt;, +, =, ;, ?, *. Names also cannot include characters in the range 1-31, which are non-printable.
		/// </para>
		/// <para>
		/// Note that the USER_INFO_4 structure supersedes the <c>USER_INFO_3</c> structure on Windows XP and later. It is recommended that
		/// applications use the <c>USER_INFO_4</c> structure instead of the <c>USER_INFO_3</c> structure with the NetUserAdd,
		/// NetUserSetInfo, and NetUserGetInfofunctions on Windows XP and later.
		/// </para>
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows/desktop/api/lmaccess/ns-lmaccess-_user_info_3 typedef struct _USER_INFO_3 { LPWSTR
		// usri3_name; LPWSTR usri3_password; DWORD usri3_password_age; DWORD usri3_priv; LPWSTR usri3_home_dir; LPWSTR usri3_comment; DWORD
		// usri3_flags; LPWSTR usri3_script_path; DWORD usri3_auth_flags; LPWSTR usri3_full_name; LPWSTR usri3_usr_comment; LPWSTR
		// usri3_parms; LPWSTR usri3_workstations; DWORD usri3_last_logon; DWORD usri3_last_logoff; DWORD usri3_acct_expires; DWORD
		// usri3_max_storage; DWORD usri3_units_per_week; PBYTE usri3_logon_hours; DWORD usri3_bad_pw_count; DWORD usri3_num_logons; LPWSTR
		// usri3_logon_server; DWORD usri3_country_code; DWORD usri3_code_page; DWORD usri3_user_id; DWORD usri3_primary_group_id; LPWSTR
		// usri3_profile; LPWSTR usri3_home_dir_drive; DWORD usri3_password_expired; } USER_INFO_3, *PUSER_INFO_3, *LPUSER_INFO_3;
		[PInvokeData("lmaccess.h", MSDNShortId = "39ed05f5-165d-4cb8-98af-e4120a1634f6")]
		[StructLayout(LayoutKind.Sequential, CharSet = CharSet.Unicode)]
		public struct USER_INFO_3
		{
			/// <summary>
			/// <para>Type: <c>LPWSTR</c></para>
			/// <para>
			/// A pointer to a Unicode string that specifies the name of the user account. For the NetUserSetInfo function, this member is
			/// ignored. For more information, see the following Remarks section.
			/// </para>
			/// </summary>
			public string usri3_name;

			/// <summary>
			/// <para>Type: <c>LPWSTR</c></para>
			/// <para>
			/// A pointer to a Unicode string that specifies the password for the user identified by the <c>usri3_name</c> member. The length
			/// cannot exceed PWLEN bytes. The NetUserEnum and NetUserGetInfo functions return a <c>NULL</c> pointer to maintain password security.
			/// </para>
			/// <para>By convention, the length of passwords is limited to LM20_PWLEN characters.</para>
			/// </summary>
			public string usri3_password;

			/// <summary>
			/// <para>Type: <c>DWORD</c></para>
			/// <para>
			/// The number of seconds that have elapsed since the <c>usri3_password</c> member was last changed. The NetUserAdd and
			/// NetUserSetInfo functions ignore this member.
			/// </para>
			/// </summary>
			public uint usri3_password_age;

			/// <summary>
			/// <para>Type: <c>DWORD</c></para>
			/// <para>
			/// The level of privilege assigned to the <c>usri3_name</c> member. The NetUserAdd and NetUserSetInfo functions ignore this
			/// member. This member can be one of the following values. For more information about user and group account rights, see Privileges.
			/// </para>
			/// <list type="table">
			/// <listheader>
			/// <term>Value</term>
			/// <term>Meaning</term>
			/// </listheader>
			/// <item>
			/// <term>USER_PRIV_GUEST</term>
			/// <term>Guest</term>
			/// </item>
			/// <item>
			/// <term>USER_PRIV_USER</term>
			/// <term>User</term>
			/// </item>
			/// <item>
			/// <term>USER_PRIV_ADMIN</term>
			/// <term>Administrator</term>
			/// </item>
			/// </list>
			/// </summary>
			public UserPrivilege usri3_priv;

			/// <summary>
			/// <para>Type: <c>LPWSTR</c></para>
			/// <para>
			/// A pointer to a Unicode string specifying the path of the home directory of the user specified by the <c>usri3_name</c>
			/// member. The string can be <c>NULL</c>.
			/// </para>
			/// </summary>
			public string usri3_home_dir;

			/// <summary>
			/// <para>Type: <c>LPWSTR</c></para>
			/// <para>
			/// A pointer to a Unicode string that contains a comment to associate with the user account. The string can be a <c>NULL</c>
			/// string, or it can have any number of characters before the terminating null character.
			/// </para>
			/// </summary>
			public string usri3_comment;

			/// <summary>
			/// <para>Type: <c>DWORD</c></para>
			/// <para>This member can be one or more of the following values.</para>
			/// <para>
			/// Note that setting user account control flags may require certain privileges and control access rights. For more information,
			/// see the Remarks section of the NetUserSetInfo function.
			/// </para>
			/// <list type="table">
			/// <listheader>
			/// <term>Value</term>
			/// <term>Meaning</term>
			/// </listheader>
			/// <item>
			/// <term>UF_SCRIPT</term>
			/// <term>The logon script executed. This value must be set.</term>
			/// </item>
			/// <item>
			/// <term>UF_ACCOUNTDISABLE</term>
			/// <term>The user's account is disabled.</term>
			/// </item>
			/// <item>
			/// <term>UF_HOMEDIR_REQUIRED</term>
			/// <term>The home directory is required. This value is ignored.</term>
			/// </item>
			/// <item>
			/// <term>UF_PASSWD_NOTREQD</term>
			/// <term>No password is required.</term>
			/// </item>
			/// <item>
			/// <term>UF_PASSWD_CANT_CHANGE</term>
			/// <term>The user cannot change the password.</term>
			/// </item>
			/// <item>
			/// <term>UF_LOCKOUT</term>
			/// <term>
			/// The account is currently locked out. You can call the NetUserSetInfo function to clear this value and unlock a previously
			/// locked account. You cannot use this value to lock a previously unlocked account.
			/// </term>
			/// </item>
			/// <item>
			/// <term>UF_DONT_EXPIRE_PASSWD</term>
			/// <term>The password should never expire on the account.</term>
			/// </item>
			/// <item>
			/// <term>UF_ENCRYPTED_TEXT_PASSWORD_ALLOWED</term>
			/// <term>The user's password is stored under reversible encryption in the Active Directory.</term>
			/// </item>
			/// <item>
			/// <term>UF_NOT_DELEGATED</term>
			/// <term>Marks the account as "sensitive"; other users cannot act as delegates of this user account.</term>
			/// </item>
			/// <item>
			/// <term>UF_SMARTCARD_REQUIRED</term>
			/// <term>Requires the user to log on to the user account with a smart card.</term>
			/// </item>
			/// <item>
			/// <term>UF_USE_DES_KEY_ONLY</term>
			/// <term>Restrict this principal to use only Data Encryption Standard (DES) encryption types for keys.</term>
			/// </item>
			/// <item>
			/// <term>UF_DONT_REQUIRE_PREAUTH</term>
			/// <term>This account does not require Kerberos preauthentication for logon.</term>
			/// </item>
			/// <item>
			/// <term>UF_TRUSTED_FOR_DELEGATION</term>
			/// <term>
			/// The account is enabled for delegation. This is a security-sensitive setting; accounts with this option enabled should be
			/// tightly controlled. This setting allows a service running under the account to assume a client's identity and authenticate as
			/// that user to other remote servers on the network.
			/// </term>
			/// </item>
			/// <item>
			/// <term>UF_PASSWORD_EXPIRED</term>
			/// <term>The user's password has expired. Windows 2000: This value is not supported.</term>
			/// </item>
			/// <item>
			/// <term>UF_TRUSTED_TO_AUTHENTICATE_FOR_DELEGATION</term>
			/// <term>
			/// The account is trusted to authenticate a user outside of the Kerberos security package and delegate that user through
			/// constrained delegation. This is a security-sensitive setting; accounts with this option enabled should be tightly controlled.
			/// This setting allows a service running under the account to assert a client's identity and authenticate as that user to
			/// specifically configured services on the network. Windows XP/2000: This value is not supported.
			/// </term>
			/// </item>
			/// </list>
			/// <para>
			/// The following values describe the account type. Only one value can be set. You cannot change the account type using the
			/// NetUserSetInfo function.
			/// </para>
			/// <list type="table">
			/// <listheader>
			/// <term>Value</term>
			/// <term>Meaning</term>
			/// </listheader>
			/// <item>
			/// <term>UF_NORMAL_ACCOUNT</term>
			/// <term>This is a default account type that represents a typical user.</term>
			/// </item>
			/// <item>
			/// <term>UF_TEMP_DUPLICATE_ACCOUNT</term>
			/// <term>
			/// This is an account for users whose primary account is in another domain. This account provides user access to this domain,
			/// but not to any domain that trusts this domain. The User Manager refers to this account type as a local user account.
			/// </term>
			/// </item>
			/// <item>
			/// <term>UF_WORKSTATION_TRUST_ACCOUNT</term>
			/// <term>This is a computer account for a computer that is a member of this domain.</term>
			/// </item>
			/// <item>
			/// <term>UF_SERVER_TRUST_ACCOUNT</term>
			/// <term>This is a computer account for a backup domain controller that is a member of this domain.</term>
			/// </item>
			/// <item>
			/// <term>UF_INTERDOMAIN_TRUST_ACCOUNT</term>
			/// <term>This is a permit to trust account for a domain that trusts other domains.</term>
			/// </item>
			/// </list>
			/// </summary>
			public UserAcctCtrlFlags usri3_flags;

			/// <summary>
			/// <para>Type: <c>LPWSTR</c></para>
			/// <para>
			/// A pointer to a Unicode string specifying the path for the user's logon script file. The script file can be a .CMD file, an
			/// .EXE file, or a .BAT file. The string can also be <c>NULL</c>.
			/// </para>
			/// </summary>
			public string usri3_script_path;

			/// <summary>
			/// <para>Type: <c>DWORD</c></para>
			/// <para>The user's operator privileges.</para>
			/// <para>
			/// For the NetUserGetInfo and NetUserEnum functions, the appropriate value is returned based on the local group membership. If
			/// the user is a member of Print Operators, AF_OP_PRINT is set. If the user is a member of Server Operators, AF_OP_SERVER is
			/// set. If the user is a member of the Account Operators, AF_OP_ACCOUNTS is set. AF_OP_COMM is never set.
			/// </para>
			/// <para>The NetUserAdd and NetUserSetInfo functions ignore this member.</para>
			/// <para>This member can be one or more of the following values.</para>
			/// <list type="table">
			/// <listheader>
			/// <term>Value</term>
			/// <term>Meaning</term>
			/// </listheader>
			/// <item>
			/// <term>AF_OP_PRINT</term>
			/// <term>The print operator privilege is enabled.</term>
			/// </item>
			/// <item>
			/// <term>AF_OP_COMM</term>
			/// <term>The communications operator privilege is enabled.</term>
			/// </item>
			/// <item>
			/// <term>AF_OP_SERVER</term>
			/// <term>The server operator privilege is enabled.</term>
			/// </item>
			/// <item>
			/// <term>AF_OP_ACCOUNTS</term>
			/// <term>The accounts operator privilege is enabled.</term>
			/// </item>
			/// </list>
			/// </summary>
			public UserOpPriv usri3_auth_flags;

			/// <summary>
			/// <para>Type: <c>LPWSTR</c></para>
			/// <para>
			/// A pointer to a Unicode string that contains the full name of the user. This string can be a <c>NULL</c> string, or it can
			/// have any number of characters before the terminating null character.
			/// </para>
			/// </summary>
			public string usri3_full_name;

			/// <summary>
			/// <para>Type: <c>LPWSTR</c></para>
			/// <para>
			/// A pointer to a Unicode string that contains a user comment. This string can be a <c>NULL</c> string, or it can have any
			/// number of characters before the terminating null character.
			/// </para>
			/// </summary>
			public string usri3_usr_comment;

			/// <summary>
			/// <para>Type: <c>LPWSTR</c></para>
			/// <para>
			/// A pointer to a Unicode string that is reserved for use by applications. This string can be a <c>NULL</c> string, or it can
			/// have any number of characters before the terminating null character. Microsoft products use this member to store user
			/// configuration information. Do not modify this information.
			/// </para>
			/// </summary>
			public string usri3_parms;

			/// <summary>
			/// <para>Type: <c>LPWSTR</c></para>
			/// <para>
			/// A pointer to a Unicode string that contains the names of workstations from which the user can log on. As many as eight
			/// workstations can be specified; the names must be separated by commas. If you do not want to restrict the number of
			/// workstations, use a <c>NULL</c> string. To disable logons from all workstations to this account, set the UF_ACCOUNTDISABLE
			/// value in the <c>usri3_flags</c> member.
			/// </para>
			/// </summary>
			public string usri3_workstations;

			/// <summary>
			/// <para>Type: <c>DWORD</c></para>
			/// <para>
			/// The date and time when the last logon occurred. This value is stored as the number of seconds that have elapsed since
			/// 00:00:00, January 1, 1970, GMT. This member is ignored by the NetUserAdd and NetUserSetInfo functions.
			/// </para>
			/// <para>
			/// This member is maintained separately on each backup domain controller (BDC) in the domain. To obtain an accurate value, you
			/// must query each BDC in the domain. The last logon occurred at the time indicated by the largest retrieved value.
			/// </para>
			/// </summary>
			public uint usri3_last_logon;

			/// <summary>
			/// <para>Type: <c>DWORD</c></para>
			/// <para>This member is currently not used.</para>
			/// <para>
			/// The date and time when the last logoff occurred. This value is stored as the number of seconds that have elapsed since
			/// 00:00:00, January 1, 1970, GMT. A value of zero indicates that the last logoff time is unknown.
			/// </para>
			/// <para>
			/// This member is maintained separately on each backup domain controller (BDC) in the domain. To obtain an accurate value, you
			/// must query each BDC in the domain. The last logoff occurred at the time indicated by the largest retrieved value.
			/// </para>
			/// </summary>
			public uint usri3_last_logoff;

			/// <summary>
			/// <para>Type: <c>DWORD</c></para>
			/// <para>
			/// The date and time when the account expires. This value is stored as the number of seconds elapsed since 00:00:00, January 1,
			/// 1970, GMT. A value of TIMEQ_FOREVER indicates that the account never expires.
			/// </para>
			/// </summary>
			public uint usri3_acct_expires;

			/// <summary>
			/// <para>Type: <c>DWORD</c></para>
			/// <para>The maximum amount of disk space the user can use. Specify USER_MAXSTORAGE_UNLIMITED to use all available disk space.</para>
			/// </summary>
			public uint usri3_max_storage;

			/// <summary>
			/// <para>Type: <c>DWORD</c></para>
			/// <para>
			/// The number of equal-length time units into which the week is divided. This value is required to compute the length of the bit
			/// string in the <c>usri3_logon_hours</c> member.
			/// </para>
			/// <para>
			/// This value must be UNITS_PER_WEEK for LAN Manager 2.0. This element is ignored by the NetUserAdd and NetUserSetInfo functions.
			/// </para>
			/// <para>
			/// For service applications, the units must be one of the following values: SAM_DAYS_PER_WEEK, SAM_HOURS_PER_WEEK, or SAM_MINUTES_PER_WEEK.
			/// </para>
			/// </summary>
			public uint usri3_units_per_week;

			/// <summary>
			/// <para>Type: <c>PBYTE</c></para>
			/// <para>
			/// A pointer to a 21-byte (168 bits) bit string that specifies the times during which the user can log on. Each bit represents a
			/// unique hour in the week, in Greenwich Mean Time (GMT).
			/// </para>
			/// <para>
			/// The first bit (bit 0, word 0) is Sunday, 0:00 to 0:59; the second bit (bit 1, word 0) is Sunday, 1:00 to 1:59; and so on.
			/// Note that bit 0 in word 0 represents Sunday from 0:00 to 0:59 only if you are in the GMT time zone. In all other cases you
			/// must adjust the bits according to your time zone offset (for example, GMT minus 8 hours for Pacific Standard Time).
			/// </para>
			/// <para>
			/// Specify a <c>NULL</c> pointer in this member when calling the NetUserAdd function to indicate no time restriction. Specify a
			/// <c>NULL</c> pointer when calling the NetUserSetInfo function to indicate that no change is to be made to the times during
			/// which the user can log on.
			/// </para>
			/// </summary>
			public IntPtr usri3_logon_hours;

			/// <summary>
			/// <para>Type: <c>DWORD</c></para>
			/// <para>
			/// The number of times the user tried to log on to the account using an incorrect password. A value of – 1 indicates that the
			/// value is unknown. Calls to the NetUserAdd and NetUserSetInfo functions ignore this member.
			/// </para>
			/// <para>
			/// This member is replicated from the primary domain controller (PDC); it is also maintained on each backup domain controller
			/// (BDC) in the domain. To obtain an accurate value, you must query each BDC in the domain. The number of times the user tried
			/// to log on using an incorrect password is the largest value retrieved.
			/// </para>
			/// </summary>
			public uint usri3_bad_pw_count;

			/// <summary>
			/// <para>Type: <c>DWORD</c></para>
			/// <para>
			/// The number of times the user logged on successfully to this account. A value of – 1 indicates that the value is unknown.
			/// Calls to the <c>NetUserAdd</c> and <c>NetUserSetInfo</c> functions ignore this member.
			/// </para>
			/// <para>
			/// This member is maintained separately on each backup domain controller (BDC) in the domain. To obtain an accurate value, you
			/// must query each BDC in the domain. The number of times the user logged on successfully is the sum of the retrieved values.
			/// </para>
			/// </summary>
			public uint usri3_num_logons;

			/// <summary>
			/// <para>Type: <c>LPWSTR</c></para>
			/// <para>
			/// A pointer to a Unicode string that contains the name of the server to which logon requests are sent. Server names should be
			/// preceded by two backslashes (\). To indicate that the logon request can be handled by any logon server, specify an asterisk
			/// (\*) for the server name. A <c>NULL</c> string indicates that requests should be sent to the domain controller.
			/// </para>
			/// <para>
			/// For Windows servers, NetUserGetInfo and NetUserEnum return \*. The NetUserAdd and NetUserSetInfo functions ignore this member.
			/// </para>
			/// </summary>
			public string usri3_logon_server;

			/// <summary>
			/// <para>Type: <c>DWORD</c></para>
			/// <para>The country/region code for the user's language of choice.</para>
			/// </summary>
			public uint usri3_country_code;

			/// <summary>
			/// <para>Type: <c>DWORD</c></para>
			/// <para>The code page for the user's language of choice.</para>
			/// </summary>
			public uint usri3_code_page;

			/// <summary>
			/// <para>Type: <c>DWORD</c></para>
			/// <para>
			/// The relative ID (RID) of the user. The RID is determined by the Security Account Manager (SAM) when the user is created. It
			/// uniquely defines the user account to SAM within the domain. The NetUserAdd and NetUserSetInfo functions ignore this member.
			/// For more information about RIDs, see SID Components.
			/// </para>
			/// </summary>
			public uint usri3_user_id;

			/// <summary>
			/// <para>Type: <c>DWORD</c></para>
			/// <para>
			/// The RID of the Primary Global Group for the user. When you call the <c>NetUserAdd</c> function, this member must be
			/// DOMAIN_GROUP_RID_USERS (defined in WinNT.h). When you call <c>NetUserSetInfo</c>, this member must be the RID of a global
			/// group in which the user is enrolled. For more information, see Well-Known SIDs.
			/// </para>
			/// </summary>
			public uint usri3_primary_group_id;

			/// <summary>
			/// <para>Type: <c>LPWSTR</c></para>
			/// <para>
			/// A pointer to a Unicode string that specifies a path to the user's profile. This value can be a <c>NULL</c> string, a local
			/// absolute path, or a UNC path.
			/// </para>
			/// </summary>
			public string usri3_profile;

			/// <summary>
			/// <para>Type: <c>LPWSTR</c></para>
			/// <para>A pointer to a Unicode string that specifies the drive letter assigned to the user's home directory for logon purposes.</para>
			/// </summary>
			public string usri3_home_dir_drive;

			/// <summary>
			/// <para>Type: <c>DWORD</c></para>
			/// <para>The password expiration information.</para>
			/// <para>The NetUserGetInfo and NetUserEnum functions return zero if the password has not expired (and nonzero if it has).</para>
			/// <para>
			/// When you call NetUserAdd or NetUserSetInfo, specify a nonzero value in this member to inform users that they must change
			/// their password at the next logon. To turn off this message, call <c>NetUserSetInfo</c> and specify zero in this member. Note
			/// that you cannot specify zero to negate the expiration of a password that has already expired.
			/// </para>
			/// </summary>
			public uint usri3_password_expired;
		}

		/// <summary>
		/// The <c>USER_INFO_4</c> structure contains information about a user account, including the account name, password data, privilege
		/// level, the path to the user's home directory, security identifier (SID), and other user-related network statistics.
		/// </summary>
		/// <remarks>
		/// <para>The <c>USER_INFO_4</c> structure can be used with the NetUserAdd, NetUserSetInfo, and NetUserGetInfofunctions.</para>
		/// <para>
		/// User account names are limited to 20 characters and group names are limited to 256 characters. In addition, account names cannot
		/// be terminated by a period and they cannot include commas or any of the following printable characters: ", /, , [, ], :, |, &lt;,
		/// &gt;, +, =, ;, ?, *. Names also cannot include characters in the range 1-31, which are non-printable.
		/// </para>
		/// <para>
		/// Note that the <c>USER_INFO_4</c> structure supersedes the USER_INFO_3 structure on Windows XP and later. It is recommended that
		/// applications use the <c>USER_INFO_4</c> structure instead of the <c>USER_INFO_3</c> structure with the above functions on Windows
		/// XP and later.
		/// </para>
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows/desktop/api/lmaccess/ns-lmaccess-_user_info_4 typedef struct _USER_INFO_4 { LPWSTR
		// usri4_name; LPWSTR usri4_password; DWORD usri4_password_age; DWORD usri4_priv; LPWSTR usri4_home_dir; LPWSTR usri4_comment; DWORD
		// usri4_flags; LPWSTR usri4_script_path; DWORD usri4_auth_flags; LPWSTR usri4_full_name; LPWSTR usri4_usr_comment; LPWSTR
		// usri4_parms; LPWSTR usri4_workstations; DWORD usri4_last_logon; DWORD usri4_last_logoff; DWORD usri4_acct_expires; DWORD
		// usri4_max_storage; DWORD usri4_units_per_week; PBYTE usri4_logon_hours; DWORD usri4_bad_pw_count; DWORD usri4_num_logons; LPWSTR
		// usri4_logon_server; DWORD usri4_country_code; DWORD usri4_code_page; PSID usri4_user_sid; DWORD usri4_primary_group_id; LPWSTR
		// usri4_profile; LPWSTR usri4_home_dir_drive; DWORD usri4_password_expired; } USER_INFO_4, *PUSER_INFO_4, *LPUSER_INFO_4;
		[PInvokeData("lmaccess.h", MSDNShortId = "66b11a5f-1c2d-4564-8845-9e2fa1f40f3e")]
		[StructLayout(LayoutKind.Sequential, CharSet = CharSet.Unicode)]
		public struct USER_INFO_4
		{
			/// <summary>
			/// <para>Type: <c>LPWSTR</c></para>
			/// <para>
			/// A pointer to a Unicode string that specifies the name of the user account. For the NetUserSetInfo function, this member is ignored.
			/// </para>
			/// </summary>
			public string usri4_name;

			/// <summary>
			/// <para>Type: <c>LPWSTR</c></para>
			/// <para>
			/// A pointer to a Unicode string that specifies the password for the user identified by the <c>usri4_name</c> member. The length
			/// cannot exceed PWLEN bytes. The NetUserGetInfo function returns a <c>NULL</c> pointer to maintain password security.
			/// </para>
			/// <para>By convention, the length of passwords is limited to LM20_PWLEN characters.</para>
			/// </summary>
			public string usri4_password;

			/// <summary>
			/// <para>Type: <c>DWORD</c></para>
			/// <para>
			/// The number of seconds that have elapsed since the <c>usri4_password</c> member was last changed. The NetUserAdd and
			/// NetUserSetInfo functions ignore this member.
			/// </para>
			/// </summary>
			public uint usri4_password_age;

			/// <summary>
			/// <para>Type: <c>DWORD</c></para>
			/// <para>
			/// The level of privilege assigned to the <c>usri4_name</c> member. The NetUserAdd and NetUserSetInfo functions ignore this
			/// member. This member can be one of the following values. For more information about user and group account rights, see Privileges.
			/// </para>
			/// <list type="table">
			/// <listheader>
			/// <term>Value</term>
			/// <term>Meaning</term>
			/// </listheader>
			/// <item>
			/// <term>USER_PRIV_GUEST</term>
			/// <term>Guest</term>
			/// </item>
			/// <item>
			/// <term>USER_PRIV_USER</term>
			/// <term>User</term>
			/// </item>
			/// <item>
			/// <term>USER_PRIV_ADMIN</term>
			/// <term>Administrator</term>
			/// </item>
			/// </list>
			/// </summary>
			public UserPrivilege usri4_priv;

			/// <summary>
			/// <para>Type: <c>LPWSTR</c></para>
			/// <para>
			/// A pointer to a Unicode string specifying the path of the home directory of the user specified by the <c>usri4_name</c>
			/// member. The string can be <c>NULL</c>.
			/// </para>
			/// </summary>
			public string usri4_home_dir;

			/// <summary>
			/// <para>Type: <c>LPWSTR</c></para>
			/// <para>
			/// A pointer to a Unicode string that contains a comment to associate with the user account. The string can be a <c>NULL</c>
			/// string, or it can have any number of characters before the terminating null character.
			/// </para>
			/// </summary>
			public string usri4_comment;

			/// <summary>
			/// <para>Type: <c>DWORD</c></para>
			/// <para>This member can be one or more of the following values.</para>
			/// <para>
			/// Note that setting user account control flags may require certain privileges and control access rights. For more information,
			/// see the Remarks section of the NetUserSetInfo function.
			/// </para>
			/// <list type="table">
			/// <listheader>
			/// <term>Value</term>
			/// <term>Meaning</term>
			/// </listheader>
			/// <item>
			/// <term>UF_SCRIPT</term>
			/// <term>The logon script executed. This value must be set.</term>
			/// </item>
			/// <item>
			/// <term>UF_ACCOUNTDISABLE</term>
			/// <term>The user's account is disabled.</term>
			/// </item>
			/// <item>
			/// <term>UF_HOMEDIR_REQUIRED</term>
			/// <term>The home directory is required. This value is ignored.</term>
			/// </item>
			/// <item>
			/// <term>UF_PASSWD_NOTREQD</term>
			/// <term>No password is required.</term>
			/// </item>
			/// <item>
			/// <term>UF_PASSWD_CANT_CHANGE</term>
			/// <term>The user cannot change the password.</term>
			/// </item>
			/// <item>
			/// <term>UF_LOCKOUT</term>
			/// <term>
			/// The account is currently locked out. You can call the NetUserSetInfo function to clear this value and unlock a previously
			/// locked account. You cannot use this value to lock a previously unlocked account.
			/// </term>
			/// </item>
			/// <item>
			/// <term>UF_DONT_EXPIRE_PASSWD</term>
			/// <term>The password should never expire on the account.</term>
			/// </item>
			/// <item>
			/// <term>UF_ENCRYPTED_TEXT_PASSWORD_ALLOWED</term>
			/// <term>The user's password is stored under reversible encryption in the Active Directory.</term>
			/// </item>
			/// <item>
			/// <term>UF_NOT_DELEGATED</term>
			/// <term>Marks the account as "sensitive"; other users cannot act as delegates of this user account.</term>
			/// </item>
			/// <item>
			/// <term>UF_SMARTCARD_REQUIRED</term>
			/// <term>Requires the user to log on to the user account with a smart card.</term>
			/// </item>
			/// <item>
			/// <term>UF_USE_DES_KEY_ONLY</term>
			/// <term>Restrict this principal to use only Data Encryption Standard (DES) encryption types for keys.</term>
			/// </item>
			/// <item>
			/// <term>UF_DONT_REQUIRE_PREAUTH</term>
			/// <term>This account does not require Kerberos preauthentication for logon.</term>
			/// </item>
			/// <item>
			/// <term>UF_TRUSTED_FOR_DELEGATION</term>
			/// <term>
			/// The account is enabled for delegation. This is a security-sensitive setting; accounts with this option enabled should be
			/// tightly controlled. This setting allows a service running under the account to assume a client's identity and authenticate as
			/// that user to other remote servers on the network.
			/// </term>
			/// </item>
			/// <item>
			/// <term>UF_PASSWORD_EXPIRED</term>
			/// <term>The user's password has expired. Windows 2000: This value is ignored.</term>
			/// </item>
			/// <item>
			/// <term>UF_TRUSTED_TO_AUTHENTICATE_FOR_DELEGATION</term>
			/// <term>
			/// The account is trusted to authenticate a user outside of the Kerberos security package and delegate that user through
			/// constrained delegation. This is a security-sensitive setting; accounts with this option enabled should be tightly controlled.
			/// This setting allows a service running under the account to assert a client's identity and authenticate as that user to
			/// specifically configured services on the network. Windows XP/2000: This value is ignored.
			/// </term>
			/// </item>
			/// </list>
			/// <para>
			/// The following values describe the account type. Only one value can be set. You cannot change the account type using the
			/// NetUserSetInfo function.
			/// </para>
			/// <list type="table">
			/// <listheader>
			/// <term>Value</term>
			/// <term>Meaning</term>
			/// </listheader>
			/// <item>
			/// <term>UF_NORMAL_ACCOUNT</term>
			/// <term>This is a default account type that represents a typical user.</term>
			/// </item>
			/// <item>
			/// <term>UF_TEMP_DUPLICATE_ACCOUNT</term>
			/// <term>
			/// This is an account for users whose primary account is in another domain. This account provides user access to this domain,
			/// but not to any domain that trusts this domain. The User Manager refers to this account type as a local user account.
			/// </term>
			/// </item>
			/// <item>
			/// <term>UF_WORKSTATION_TRUST_ACCOUNT</term>
			/// <term>This is a computer account for a computer that is a member of this domain.</term>
			/// </item>
			/// <item>
			/// <term>UF_SERVER_TRUST_ACCOUNT</term>
			/// <term>This is a computer account for a backup domain controller that is a member of this domain.</term>
			/// </item>
			/// <item>
			/// <term>UF_INTERDOMAIN_TRUST_ACCOUNT</term>
			/// <term>This is a permit to trust account for a domain that trusts other domains.</term>
			/// </item>
			/// </list>
			/// </summary>
			public UserAcctCtrlFlags usri4_flags;

			/// <summary>
			/// <para>Type: <c>LPWSTR</c></para>
			/// <para>
			/// A pointer to a Unicode string specifying the path for the user's logon script file. The script file can be a .CMD file, an
			/// .EXE file, or a .BAT file. The string can also be <c>NULL</c>.
			/// </para>
			/// </summary>
			public string usri4_script_path;

			/// <summary>
			/// <para>Type: <c>DWORD</c></para>
			/// <para>The user's operator privileges.</para>
			/// <para>
			/// For the NetUserGetInfo function, the appropriate value is returned based on the local group membership. If the user is a
			/// member of Print Operators, AF_OP_PRINT is set. If the user is a member of Server Operators, AF_OP_SERVER is set. If the user
			/// is a member of the Account Operators, AF_OP_ACCOUNTS is set. AF_OP_COMM is never set.
			/// </para>
			/// <para>The NetUserAdd and NetUserSetInfo functions ignore this member.</para>
			/// <para>This member can be one or more of the following values.</para>
			/// <list type="table">
			/// <listheader>
			/// <term>Value</term>
			/// <term>Meaning</term>
			/// </listheader>
			/// <item>
			/// <term>AF_OP_PRINT</term>
			/// <term>The print operator privilege is enabled.</term>
			/// </item>
			/// <item>
			/// <term>AF_OP_COMM</term>
			/// <term>The communications operator privilege is enabled.</term>
			/// </item>
			/// <item>
			/// <term>AF_OP_SERVER</term>
			/// <term>The server operator privilege is enabled.</term>
			/// </item>
			/// <item>
			/// <term>AF_OP_ACCOUNTS</term>
			/// <term>The accounts operator privilege is enabled.</term>
			/// </item>
			/// </list>
			/// </summary>
			public UserOpPriv usri4_auth_flags;

			/// <summary>
			/// <para>Type: <c>LPWSTR</c></para>
			/// <para>
			/// A pointer to a Unicode string that contains the full name of the user. This string can be a <c>NULL</c> string, or it can
			/// have any number of characters before the terminating null character.
			/// </para>
			/// </summary>
			public string usri4_full_name;

			/// <summary>
			/// <para>Type: <c>LPWSTR</c></para>
			/// <para>
			/// A pointer to a Unicode string that contains a user comment. This string can be a <c>NULL</c> string, or it can have any
			/// number of characters before the terminating null character.
			/// </para>
			/// </summary>
			public string usri4_usr_comment;

			/// <summary>
			/// <para>Type: <c>LPWSTR</c></para>
			/// <para>
			/// A pointer to a Unicode string that is reserved for use by applications. This string can be a <c>NULL</c> string, or it can
			/// have any number of characters before the terminating null character. Microsoft products use this member to store user
			/// configuration information. Do not modify this information.
			/// </para>
			/// </summary>
			public string usri4_parms;

			/// <summary>
			/// <para>Type: <c>LPWSTR</c></para>
			/// <para>
			/// A pointer to a Unicode string that contains the names of workstations from which the user can log on. As many as eight
			/// workstations can be specified; the names must be separated by commas. If you do not want to restrict the number of
			/// workstations, use a <c>NULL</c> string. To disable logons from all workstations to this account, set the UF_ACCOUNTDISABLE
			/// value in the <c>usri4_flags</c> member.
			/// </para>
			/// </summary>
			public string usri4_workstations;

			/// <summary>
			/// <para>Type: <c>DWORD</c></para>
			/// <para>
			/// The date and time when the last logon occurred. This value is stored as the number of seconds that have elapsed since
			/// 00:00:00, January 1, 1970, GMT. This member is ignored by the NetUserAdd and NetUserSetInfo functions.
			/// </para>
			/// <para>
			/// This member is maintained separately on each backup domain controller (BDC) in the domain. To obtain an accurate value, you
			/// must query each BDC in the domain. The last logon occurred at the time indicated by the largest retrieved value.
			/// </para>
			/// </summary>
			public uint usri4_last_logon;

			/// <summary>
			/// <para>Type: <c>DWORD</c></para>
			/// <para>This member is currently not used.</para>
			/// <para>
			/// The date and time when the last logoff occurred. This value is stored as the number of seconds that have elapsed since
			/// 00:00:00, January 1, 1970, GMT. A value of zero indicates that the last logoff time is unknown.
			/// </para>
			/// <para>
			/// This member is maintained separately on each backup domain controller (BDC) in the domain. To obtain an accurate value, you
			/// must query each BDC in the domain. The last logoff occurred at the time indicated by the largest retrieved value.
			/// </para>
			/// </summary>
			public uint usri4_last_logoff;

			/// <summary>
			/// <para>Type: <c>DWORD</c></para>
			/// <para>
			/// The date and time when the account expires. This value is stored as the number of seconds elapsed since 00:00:00, January 1,
			/// 1970, GMT. A value of TIMEQ_FOREVER indicates that the account never expires.
			/// </para>
			/// </summary>
			public uint usri4_acct_expires;

			/// <summary>
			/// <para>Type: <c>DWORD</c></para>
			/// <para>The maximum amount of disk space the user can use. Specify USER_MAXSTORAGE_UNLIMITED to use all available disk space.</para>
			/// </summary>
			public uint usri4_max_storage;

			/// <summary>
			/// <para>Type: <c>DWORD</c></para>
			/// <para>
			/// The number of equal-length time units into which the week is divided. This value is required to compute the length of the bit
			/// string in the <c>usri4_logon_hours</c> member.
			/// </para>
			/// <para>
			/// This value must be UNITS_PER_WEEK for LAN Manager 2.0. This element is ignored by the NetUserAdd and NetUserSetInfo functions.
			/// </para>
			/// <para>
			/// For service applications, the units must be one of the following values: SAM_DAYS_PER_WEEK, SAM_HOURS_PER_WEEK, or SAM_MINUTES_PER_WEEK.
			/// </para>
			/// </summary>
			public uint usri4_units_per_week;

			/// <summary>
			/// <para>Type: <c>PBYTE</c></para>
			/// <para>
			/// A pointer to a 21-byte (168 bits) bit string that specifies the times during which the user can log on. Each bit represents a
			/// unique hour in the week, in Greenwich Mean Time (GMT).
			/// </para>
			/// <para>
			/// The first bit (bit 0, word 0) is Sunday, 0:00 to 0:59; the second bit (bit 1, word 0) is Sunday, 1:00 to 1:59; and so on.
			/// Note that bit 0 in word 0 represents Sunday from 0:00 to 0:59 only if you are in the GMT time zone. In all other cases you
			/// must adjust the bits according to your time zone offset (for example, GMT minus 8 hours for Pacific Standard Time).
			/// </para>
			/// <para>
			/// Specify a <c>NULL</c> pointer in this member when calling the NetUserAdd function to indicate no time restriction. Specify a
			/// <c>NULL</c> pointer when calling the NetUserSetInfo function to indicate that no change is to be made to the times during
			/// which the user can log on.
			/// </para>
			/// </summary>
			public IntPtr usri4_logon_hours;

			/// <summary>
			/// <para>Type: <c>DWORD</c></para>
			/// <para>
			/// The number of times the user tried to log on to the account using an incorrect password. A value of – 1 indicates that the
			/// value is unknown. Calls to the NetUserAdd and NetUserSetInfo functions ignore this member.
			/// </para>
			/// <para>
			/// This member is replicated from the primary domain controller (PDC); it is also maintained on each backup domain controller
			/// (BDC) in the domain. To obtain an accurate value, you must query each BDC in the domain. The number of times the user tried
			/// to log on using an incorrect password is the largest value retrieved.
			/// </para>
			/// </summary>
			public uint usri4_bad_pw_count;

			/// <summary>
			/// <para>Type: <c>DWORD</c></para>
			/// <para>
			/// The number of times the user logged on successfully to this account. A value of – 1 indicates that the value is unknown.
			/// Calls to the <c>NetUserAdd</c> and <c>NetUserSetInfo</c> functions ignore this member.
			/// </para>
			/// <para>
			/// This member is maintained separately on each backup domain controller (BDC) in the domain. To obtain an accurate value, you
			/// must query each BDC in the domain. The number of times the user logged on successfully is the sum of the retrieved values.
			/// </para>
			/// </summary>
			public uint usri4_num_logons;

			/// <summary>
			/// <para>Type: <c>LPWSTR</c></para>
			/// <para>
			/// A pointer to a Unicode string that contains the name of the server to which logon requests are sent. Server names should be
			/// preceded by two backslashes (\). To indicate that the logon request can be handled by any logon server, specify an asterisk
			/// (\*) for the server name. A <c>NULL</c> string indicates that requests should be sent to the domain controller.
			/// </para>
			/// <para>For Windows servers, the NetUserGetInfo function returns \*.</para>
			/// <para>The NetUserAdd and NetUserSetInfo functions ignore this member.</para>
			/// </summary>
			public string usri4_logon_server;

			/// <summary>
			/// <para>Type: <c>DWORD</c></para>
			/// <para>The country/region code for the user's language of choice.</para>
			/// </summary>
			public uint usri4_country_code;

			/// <summary>
			/// <para>Type: <c>DWORD</c></para>
			/// <para>The code page for the user's language of choice.</para>
			/// </summary>
			public uint usri4_code_page;

			/// <summary>
			/// <para>Type: <c>PSID</c></para>
			/// <para>
			/// A pointer to a SID structure that contains the security identifier (SID) that uniquely identifies the user. The NetUserAdd
			/// and NetUserSetInfo functions ignore this member.
			/// </para>
			/// </summary>
			public PSID usri4_user_sid;

			/// <summary>
			/// <para>Type: <c>DWORD</c></para>
			/// <para>
			/// The relative identifier (RID) of the Primary Global Group for the user. When you call the <c>NetUserAdd</c> function, this
			/// member must be DOMAIN_GROUP_RID_USERS (defined in WinNT.h). When you call <c>NetUserSetInfo</c>, this member must be the RID
			/// of a global group in which the user is enrolled. For more information, see Well-Known SIDs and SID Components.
			/// </para>
			/// </summary>
			public uint usri4_primary_group_id;

			/// <summary>
			/// <para>Type: <c>LPWSTR</c></para>
			/// <para>
			/// A pointer to a Unicode string that specifies a path to the user's profile. This value can be a <c>NULL</c> string, a local
			/// absolute path, or a UNC path.
			/// </para>
			/// </summary>
			public string usri4_profile;

			/// <summary>
			/// <para>Type: <c>LPWSTR</c></para>
			/// <para>A pointer to a Unicode string that specifies the drive letter assigned to the user's home directory for logon purposes.</para>
			/// </summary>
			public string usri4_home_dir_drive;

			/// <summary>
			/// <para>Type: <c>DWORD</c></para>
			/// <para>The password expiration information.</para>
			/// <para>The NetUserGetInfo function return zero if the password has not expired (and nonzero if it has).</para>
			/// <para>
			/// When you call NetUserAdd or NetUserSetInfo, specify a nonzero value in this member to inform users that they must change
			/// their password at the next logon. To turn off this message, call <c>NetUserSetInfo</c> and specify zero in this member. Note
			/// that you cannot specify zero to negate the expiration of a password that has already expired.
			/// </para>
			/// </summary>
			public uint usri4_password_expired;
		}

		/// <summary>
		/// The <c>USER_MODALS_INFO_0</c> structure contains global password information for users and global groups in the security
		/// database, which is the security accounts manager (SAM) database or, in the case of domain controllers, the Active Directory.
		/// </summary>
		// https://docs.microsoft.com/en-us/windows/desktop/api/lmaccess/ns-lmaccess-_user_modals_info_0 typedef struct _USER_MODALS_INFO_0 {
		// DWORD usrmod0_min_passwd_len; DWORD usrmod0_max_passwd_age; DWORD usrmod0_min_passwd_age; DWORD usrmod0_force_logoff; DWORD
		// usrmod0_password_hist_len; } USER_MODALS_INFO_0, *PUSER_MODALS_INFO_0, *LPUSER_MODALS_INFO_0;
		[PInvokeData("lmaccess.h", MSDNShortId = "cf3dd091-106e-4a0d-b4db-62bd11fd65cf")]
		[StructLayout(LayoutKind.Sequential, CharSet = CharSet.Unicode)]
		public struct USER_MODALS_INFO_0
		{
			/// <summary>Specifies the minimum allowable password length. Valid values for this element are zero through LM20_PWLEN.</summary>
			public uint usrmod0_min_passwd_len;

			/// <summary>
			/// Specifies, in seconds, the maximum allowable password age. A value of TIMEQ_FOREVER indicates that the password never
			/// expires. The minimum valid value for this element is ONE_DAY. The value specified must be greater than or equal to the value
			/// for the <c>usrmod0_min_passwd_age</c> member.
			/// </summary>
			public uint usrmod0_max_passwd_age;

			/// <summary>
			/// Specifies the minimum number of seconds that can elapse between the time a password changes and when it can be changed again.
			/// A value of zero indicates that no delay is required between password updates. The value specified must be less than or equal
			/// to the value for the <c>usrmod0_max_passwd_age</c> member.
			/// </summary>
			public uint usrmod0_min_passwd_age;

			/// <summary>
			/// Specifies, in seconds, the amount of time between the end of the valid logon time and the time when the user is forced to log
			/// off the network. A value of TIMEQ_FOREVER indicates that the user is never forced to log off. A value of zero indicates that
			/// the user will be forced to log off immediately when the valid logon time expires.
			/// </summary>
			public uint usrmod0_force_logoff;

			/// <summary>
			/// Specifies the length of password history maintained. A new password cannot match any of the previous
			/// <c>usrmod0_password_hist_len</c> passwords. Valid values for this element are zero through DEF_MAX_PWHIST.
			/// </summary>
			public uint usrmod0_password_hist_len;
		}

		/// <summary>The <c>USER_MODALS_INFO_1</c> structure contains logon server and domain controller information.</summary>
		// https://docs.microsoft.com/en-us/windows/desktop/api/lmaccess/ns-lmaccess-_user_modals_info_1 typedef struct _USER_MODALS_INFO_1 {
		// DWORD usrmod1_role; LPWSTR usrmod1_primary; } USER_MODALS_INFO_1, *PUSER_MODALS_INFO_1, *LPUSER_MODALS_INFO_1;
		[PInvokeData("lmaccess.h", MSDNShortId = "2cb7f310-c76e-42fd-892c-fead374af16c")]
		[StructLayout(LayoutKind.Sequential, CharSet = CharSet.Unicode)]
		public struct USER_MODALS_INFO_1
		{
			/// <summary>
			/// <para>Specifies the role of the logon server. The following values are defined.</para>
			/// <list type="table">
			/// <listheader>
			/// <term>Value</term>
			/// <term>Meaning</term>
			/// </listheader>
			/// <item>
			/// <term>UAS_ROLE_STANDALONE</term>
			/// <term>The logon server is a stand-alone server.</term>
			/// </item>
			/// <item>
			/// <term>UAS_ROLE_MEMBER</term>
			/// <term>The logon server is a member.</term>
			/// </item>
			/// <item>
			/// <term>UAS_ROLE_BACKUP</term>
			/// <term>The logon server is a backup.</term>
			/// </item>
			/// <item>
			/// <term>UAS_ROLE_PRIMARY</term>
			/// <term>The logon server is a domain controller.</term>
			/// </item>
			/// </list>
			/// <para>If the Netlogon service is not being used, the element should be set to UAS_ROLE_STANDALONE.</para>
			/// </summary>
			public LogonServerRole usrmod1_role;

			/// <summary>
			/// Pointer to a Unicode string that specifies the name of the domain controller that stores the primary copy of the database for
			/// the user account manager.
			/// </summary>
			public string usrmod1_primary;
		}

		/// <summary>
		/// The <c>USER_MODALS_INFO_1001</c> structure contains the minimum length for passwords in the security database, which is the
		/// security accounts manager (SAM) database or, in the case of domain controllers, the Active Directory.
		/// </summary>
		// https://docs.microsoft.com/en-us/windows/desktop/api/lmaccess/ns-lmaccess-_user_modals_info_1001 typedef struct
		// _USER_MODALS_INFO_1001 { DWORD usrmod1001_min_passwd_len; } USER_MODALS_INFO_1001, *PUSER_MODALS_INFO_1001, *LPUSER_MODALS_INFO_1001;
		[PInvokeData("lmaccess.h", MSDNShortId = "ef6e63da-f092-4435-93f0-e50d2fdd5664")]
		[StructLayout(LayoutKind.Sequential, CharSet = CharSet.Unicode)]
		public struct USER_MODALS_INFO_1001
		{
			/// <summary>Specifies the minimum allowable password length. Valid values for this element are zero through PWLEN.</summary>
			public uint usrmod1001_min_passwd_len;
		}

		/// <summary>
		/// The <c>USER_MODALS_INFO_1002</c> structure contains the maximum duration for passwords in the security database, which is the
		/// security accounts manager (SAM) database or, in the case of domain controllers, the Active Directory.
		/// </summary>
		// https://docs.microsoft.com/en-us/windows/desktop/api/lmaccess/ns-lmaccess-_user_modals_info_1002 typedef struct
		// _USER_MODALS_INFO_1002 { DWORD usrmod1002_max_passwd_age; } USER_MODALS_INFO_1002, *PUSER_MODALS_INFO_1002, *LPUSER_MODALS_INFO_1002;
		[PInvokeData("lmaccess.h", MSDNShortId = "d4899deb-6250-4cdc-9820-56d24e3acfc1")]
		[StructLayout(LayoutKind.Sequential, CharSet = CharSet.Unicode)]
		public struct USER_MODALS_INFO_1002
		{
			/// <summary>
			/// Specifies, in seconds, the maximum allowable password age. A value of TIMEQ_FOREVER indicates that the password never
			/// expires. The minimum valid value for this element is ONE_DAY. The value specified must be greater than or equal to the value
			/// for the usrmodX_min_passwd_age member.
			/// </summary>
			public uint usrmod1002_max_passwd_age;
		}

		/// <summary>
		/// The <c>USER_MODALS_INFO_1003</c> structure contains the minimum duration for passwords in the security database, which is the
		/// security accounts manager (SAM) database or, in the case of domain controllers, the Active Directory.
		/// </summary>
		// https://docs.microsoft.com/en-us/windows/desktop/api/lmaccess/ns-lmaccess-_user_modals_info_1003 typedef struct
		// _USER_MODALS_INFO_1003 { DWORD usrmod1003_min_passwd_age; } USER_MODALS_INFO_1003, *PUSER_MODALS_INFO_1003, *LPUSER_MODALS_INFO_1003;
		[PInvokeData("lmaccess.h", MSDNShortId = "5efbba0f-b871-4ffa-8e83-abeab6b70a52")]
		[StructLayout(LayoutKind.Sequential, CharSet = CharSet.Unicode)]
		public struct USER_MODALS_INFO_1003
		{
			/// <summary>
			/// Specifies the minimum number of seconds that can elapse between the time a password changes and when it can be changed again.
			/// A value of zero indicates that no delay is required between password updates. The value specified must be less than or equal
			/// to the value for the usrmodX_max_passwd_age member.
			/// </summary>
			public uint usrmod1003_min_passwd_age;
		}

		/// <summary>
		/// The <c>USER_MODALS_INFO_1004</c> structure contains forced logoff information for users and global groups in the security
		/// database, which is the security accounts manager (SAM) database or, in the case of domain controllers, the Active Directory.
		/// </summary>
		// https://docs.microsoft.com/en-us/windows/desktop/api/lmaccess/ns-lmaccess-_user_modals_info_1004 typedef struct
		// _USER_MODALS_INFO_1004 { DWORD usrmod1004_force_logoff; } USER_MODALS_INFO_1004, *PUSER_MODALS_INFO_1004, *LPUSER_MODALS_INFO_1004;
		[PInvokeData("lmaccess.h", MSDNShortId = "c11a3c94-940e-474f-9251-a32ea098788d")]
		[StructLayout(LayoutKind.Sequential, CharSet = CharSet.Unicode)]
		public struct USER_MODALS_INFO_1004
		{
			/// <summary>
			/// Specifies, in seconds, the amount of time between the end of the valid logon time and the time when the user is forced to log
			/// off the network. A value of TIMEQ_FOREVER indicates that the user is never forced to log off. A value of zero indicates that
			/// the user will be forced to log off immediately when the valid logon time expires.
			/// </summary>
			public uint usrmod1004_force_logoff;
		}

		/// <summary>
		/// The <c>USER_MODALS_INFO_1005</c> structure contains password history information for users and global groups in the security
		/// database, which is the security accounts manager (SAM) database or, in the case of domain controllers, the Active Directory.
		/// </summary>
		// https://docs.microsoft.com/en-us/windows/desktop/api/lmaccess/ns-lmaccess-_user_modals_info_1005 typedef struct
		// _USER_MODALS_INFO_1005 { DWORD usrmod1005_password_hist_len; } USER_MODALS_INFO_1005, *PUSER_MODALS_INFO_1005, *LPUSER_MODALS_INFO_1005;
		[PInvokeData("lmaccess.h", MSDNShortId = "0156443a-e126-4aa5-a248-9ff55ff53771")]
		[StructLayout(LayoutKind.Sequential, CharSet = CharSet.Unicode)]
		public struct USER_MODALS_INFO_1005
		{
			/// <summary>
			/// Specifies the length of password history that the system maintains. A new password cannot match any of the previous
			/// usrmodX_password_hist_len passwords. Valid values for this element are zero through DEF_MAX_PWHIST.
			/// </summary>
			public uint usrmod1005_password_hist_len;
		}

		/// <summary>The <c>USER_MODALS_INFO_1006</c> structure contains logon server information.</summary>
		// https://docs.microsoft.com/en-us/windows/desktop/api/lmaccess/ns-lmaccess-_user_modals_info_1006 typedef struct
		// _USER_MODALS_INFO_1006 { DWORD usrmod1006_role; } USER_MODALS_INFO_1006, *PUSER_MODALS_INFO_1006, *LPUSER_MODALS_INFO_1006;
		[PInvokeData("lmaccess.h", MSDNShortId = "ca5c0819-b4a0-4d07-90fc-54c86ac5ecf5")]
		[StructLayout(LayoutKind.Sequential, CharSet = CharSet.Unicode)]
		public struct USER_MODALS_INFO_1006
		{
			/// <summary>
			/// <para>Specifies the role of the logon server. This member can be one of the following values.</para>
			/// <list type="table">
			/// <listheader>
			/// <term>Value</term>
			/// <term>Meaning</term>
			/// </listheader>
			/// <item>
			/// <term>UAS_ROLE_STANDALONE</term>
			/// <term>Logon server is a stand-alone. Use this value if no logon services are available.</term>
			/// </item>
			/// <item>
			/// <term>UAS_ROLE_MEMBER</term>
			/// <term>Logon server is a member.</term>
			/// </item>
			/// <item>
			/// <term>UAS_ROLE_BACKUP</term>
			/// <term>Logon server is a backup.</term>
			/// </item>
			/// <item>
			/// <term>UAS_ROLE_PRIMARY</term>
			/// <term>Logon server is a domain controller.</term>
			/// </item>
			/// </list>
			/// </summary>
			public LogonServerRole usrmod1006_role;
		}

		/// <summary>The <c>USER_MODALS_INFO_1007</c> structure contains domain controller information.</summary>
		// https://docs.microsoft.com/en-us/windows/desktop/api/lmaccess/ns-lmaccess-_user_modals_info_1007 typedef struct
		// _USER_MODALS_INFO_1007 { LPWSTR usrmod1007_primary; } USER_MODALS_INFO_1007, *PUSER_MODALS_INFO_1007, *LPUSER_MODALS_INFO_1007;
		[PInvokeData("lmaccess.h", MSDNShortId = "aa6425eb-576c-4f6f-b9c9-96d9535bc7d6")]
		[StructLayout(LayoutKind.Sequential, CharSet = CharSet.Unicode)]
		public struct USER_MODALS_INFO_1007
		{
			/// <summary>
			/// Pointer to a Unicode string that specifies the name of the domain controller that stores the primary copy of the database for
			/// the user account manager.
			/// </summary>
			public string usrmod1007_primary;
		}

		/// <summary>The <c>USER_MODALS_INFO_2</c> structure contains the Security Account Manager (SAM) domain name and identifier.</summary>
		// https://docs.microsoft.com/en-us/windows/desktop/api/lmaccess/ns-lmaccess-_user_modals_info_2 typedef struct _USER_MODALS_INFO_2 {
		// LPWSTR usrmod2_domain_name; PSID usrmod2_domain_id; } USER_MODALS_INFO_2, *PUSER_MODALS_INFO_2, *LPUSER_MODALS_INFO_2;
		[PInvokeData("lmaccess.h", MSDNShortId = "9a4b3fc1-03b5-4ba7-948f-e455c34fa234")]
		[StructLayout(LayoutKind.Sequential, CharSet = CharSet.Unicode)]
		public struct USER_MODALS_INFO_2
		{
			/// <summary>
			/// Specifies the name of the Security Account Manager (SAM) domain. For a domain controller, this is the name of the domain that
			/// the controller is a member of. For workstations, this is the name of the computer.
			/// </summary>
			public string usrmod2_domain_name;

			/// <summary>
			/// Pointer to a SID structure that contains the security identifier (SID) of the domain named by the <c>usrmod2_domain_name</c> member.
			/// </summary>
			public IntPtr usrmod2_domain_id;
		}

		/// <summary>
		/// The <c>USER_MODALS_INFO_3</c> structure contains lockout information for users and global groups in the security database, which
		/// is the security accounts manager (SAM) database or, in the case of domain controllers, the Active Directory.
		/// </summary>
		// https://docs.microsoft.com/en-us/windows/desktop/api/lmaccess/ns-lmaccess-_user_modals_info_3 typedef struct _USER_MODALS_INFO_3 {
		// DWORD usrmod3_lockout_duration; DWORD usrmod3_lockout_observation_window; DWORD usrmod3_lockout_threshold; } USER_MODALS_INFO_3,
		// *PUSER_MODALS_INFO_3, *LPUSER_MODALS_INFO_3;
		[PInvokeData("lmaccess.h", MSDNShortId = "39f85712-1afd-4e34-8e7b-0938a7a48234")]
		[StructLayout(LayoutKind.Sequential, CharSet = CharSet.Unicode)]
		public struct USER_MODALS_INFO_3
		{
			/// <summary>Specifies, in seconds, how long a locked account remains locked before it is automatically unlocked.</summary>
			public uint usrmod3_lockout_duration;

			/// <summary>
			/// Specifies the maximum time, in seconds, that can elapse between any two failed logon attempts before lockout occurs.
			/// </summary>
			public uint usrmod3_lockout_observation_window;

			/// <summary>
			/// Specifies the number of invalid password authentications that can occur before an account is marked "locked out."
			/// </summary>
			public uint usrmod3_lockout_threshold;
		}

		/// <summary>Provides a <see cref="SafeHandle"/> for password policy that is disposed using <see cref="NetValidatePasswordPolicyFree"/>.</summary>
		/// <seealso cref="Vanara.PInvoke.SafeHANDLE"/>
		public class SafePwdPolicy : SafeHANDLE
		{
			/// <summary>Initializes a new instance of the <see cref="SafePwdPolicy"/> class and assigns an existing handle.</summary>
			/// <param name="preexistingHandle">An <see cref="IntPtr"/> object that represents the pre-existing handle to use.</param>
			/// <param name="ownsHandle">
			/// <see langword="true"/> to reliably release the handle during the finalization phase; otherwise, <see langword="false"/> (not recommended).
			/// </param>
			public SafePwdPolicy(IntPtr preexistingHandle, bool ownsHandle = true) : base(preexistingHandle, ownsHandle) { }

			/// <summary>Initializes a new instance of the <see cref="SafePwdPolicy"/> class.</summary>
			private SafePwdPolicy() : base() { }

			/// <summary>
			/// Internal method that actually releases the handle. This is called by <see cref="M:Vanara.PInvoke.SafeHANDLE.ReleaseHandle"/>
			/// for valid handles and afterwards zeros the handle.
			/// </summary>
			/// <returns><c>true</c> to indicate successful release of the handle; <c>false</c> otherwise.</returns>
			/// <inheritdoc/>
			protected override bool InternalReleaseHandle() => NetValidatePasswordPolicyFree(handle).Succeeded;
		}
	}
}