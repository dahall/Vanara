using System.Diagnostics.CodeAnalysis;
using System.Linq;

namespace Vanara.PInvoke;

public static partial class AdvApi32
{
	/// <summary>Maximum number of attributes per credential</summary>
	public const int CRED_MAX_ATTRIBUTES = 64;

	/// <summary>Maximum length of the TargetName field for CRED_TYPE_DOMAIN_* (in characters). Largest one is DfsRoot\DfsShare</summary>
	public const int CRED_MAX_DOMAIN_TARGET_NAME_LENGTH = (256 + 1 + 80);

	/// <summary>Maximum length of the TargetName field for CRED_TYPE_GENERIC (in characters)</summary>
	public const int CRED_MAX_GENERIC_TARGET_NAME_LENGTH = 32767;

	/// <summary>Maximum length of the various credential string fields (in characters)</summary>
	public const int CRED_MAX_STRING_LENGTH = 256;

	/// <summary>Maximum length of a target attribute</summary>
	public const int CRED_MAX_TARGETNAME_ATTRIBUTE_LENGTH = (256);

	/// <summary>Maximum length of a target namespace</summary>
	public const int CRED_MAX_TARGETNAME_NAMESPACE_LENGTH = (256);

	/// <summary>Maximum length of the UserName field. The worst case is User@DnsDomain</summary>
	public const int CRED_MAX_USERNAME_LENGTH = (256 + 1 + 256);

	/// <summary>Maximum size of the Credential Attribute Value field (in bytes)</summary>
	public const int CRED_MAX_VALUE_SIZE = (256);

	/// <summary>Flags used by CredEnumerate.</summary>
	[PInvokeData("wincred.h", MSDNShortId = "ef0b7620-7b00-45f1-af16-141d2e940783")]
	public enum CRED_ENUM
	{
		/// <summary>No flags.</summary>
		NONE = 0,

		/// <summary>
		/// This function enumerates all of the credentials in the user's credential set. The target name of each credential is returned
		/// in the "namespace:attribute=target" format. If this flag is set and the Filter parameter is not NULL, the function fails and
		/// returns ERROR_INVALID_FLAGS.
		/// <para>Windows Server 2003 and Windows XP: This flag is not supported.</para>
		/// </summary>
		CRED_ENUMERATE_ALL_CREDENTIALS = 0x1,
	}

	/// <summary>A bit member that identifies characteristics of the credential.</summary>
	[PInvokeData("wincred.h")]
	[Flags]
	public enum CRED_FLAGS
	{
		/// <summary/>
		CRED_FLAGS_PASSWORD_FOR_CERT = 0x1,

		/// <summary>
		/// Bit set if the credential does not persist the CredentialBlob and the credential has not been written during this logon
		/// session. This bit is ignored on input and is set automatically when queried.
		/// <para>
		/// If Type is CRED_TYPE_DOMAIN_CERTIFICATE, the CredentialBlob is not persisted across logon sessions because the PIN of a
		/// certificate is very sensitive information. Indeed, when the credential is written to credential manager, the PIN is passed to
		/// the CSP associated with the certificate. The CSP will enforce a PIN retention policy appropriate to the certificate.
		/// </para>
		/// <para>
		/// If Type is CRED_TYPE_DOMAIN_PASSWORD or CRED_TYPE_DOMAIN_CERTIFICATE, an authentication package always fails an
		/// authentication attempt when using credentials marked as CRED_FLAGS_PROMPT_NOW. The application (typically through the key
		/// ring UI) prompts the user for the password. The application saves the credential and retries the authentication. Because the
		/// credential has been recently written, the authentication package now gets a credential that is not marked as CRED_FLAGS_PROMPT_NOW.
		/// </para>
		/// </summary>
		CRED_FLAGS_PROMPT_NOW = 0x2,

		/// <summary>
		/// Bit is set if this credential has a TargetName member set to the same value as the UserName member. Such a credential is one
		/// designed to store the CredentialBlob for a specific user. For more information, see the CredMarshalCredential function.
		/// <para>This bit can only be specified if Type is CRED_TYPE_DOMAIN_PASSWORD or CRED_TYPE_DOMAIN_CERTIFICATE.</para>
		/// </summary>
		CRED_FLAGS_USERNAME_TARGET = 0x4,

		/// <summary/>
		CRED_FLAGS_OWF_CRED_BLOB = 0x0008,
		/// <summary/>
		CRED_FLAGS_REQUIRE_CONFIRMATION = 0x0010,
		/// <summary/>
		CRED_FLAGS_WILDCARD_MATCH = 0x0020,
		/// <summary/>
		CRED_FLAGS_VSM_PROTECTED = 0x0040,
		/// <summary/>
		CRED_FLAGS_NGC_CERT = 0x0080,
		/// <summary/>
		CRED_FLAGS_VALID_FLAGS = 0xF0FF,
		/// <summary/>
		CRED_FLAGS_VALID_INPUT_FLAGS = 0xF09F,
	}

	/// <summary>
	/// <para>
	/// The <c>CRED_MARSHAL_TYPE</c> enumeration specifies the types of credential to be marshaled by CredMarshalCredential or
	/// unmarshaled by CredUnmarshalCredential.
	/// </para>
	/// </summary>
	// https://docs.microsoft.com/en-us/windows/desktop/api/wincred/ne-wincred-_cred_marshal_type typedef enum _CRED_MARSHAL_TYPE {
	// CertCredential , UsernameTargetCredential , BinaryBlobCredential , UsernameForPackedCredentials , BinaryBlobForSystem }
	// CRED_MARSHAL_TYPE, *PCRED_MARSHAL_TYPE;
	[PInvokeData("wincred.h", MSDNShortId = "612fdd6f-2b4c-4f41-a00b-250f90eb85d3")]
	public enum CRED_MARSHAL_TYPE
	{
		/// <summary>Specifies that the credential is a certificate reference described by a CERT_CREDENTIAL_INFO structure.</summary>
		[CorrespondingType(typeof(CERT_CREDENTIAL_INFO))]
		CertCredential = 1,

		/// <summary>
		/// Specifies that the credential is a reference to a CRED_FLAGS_USERNAME_TARGET credential described by a
		/// USERNAME_TARGET_CREDENTIAL_INFO structure.
		/// </summary>
		[CorrespondingType(typeof(USERNAME_TARGET_CREDENTIAL_INFO))]
		UsernameTargetCredential,

		/// <summary>Undocumented.</summary>
		[CorrespondingType(typeof(BINARY_BLOB_CREDENTIAL_INFO))]
		BinaryBlobCredential,
	}

	/// <summary>Specifies the maximum persistence supported by the corresponding credential type.</summary>
	[PInvokeData("wincred.h", MSDNShortId = "70f8d5e0-235b-4330-8add-566b41c91c17")]
	public enum CRED_PERSIST
	{
		/// <summary>
		/// No credential can be stored. This value will be returned if the credential type is not supported or has been disabled by policy.
		/// </summary>
		CRED_PERSIST_NONE = 0,

		/// <summary>
		/// The credential persists for the life of the logon session. It will not be visible to other logon sessions of this same user.
		/// It will not exist after this user logs off and back on.
		/// </summary>
		CRED_PERSIST_SESSION = 1,

		/// <summary>
		/// The credential persists for all subsequent logon sessions on this same computer. It is visible to other logon sessions of
		/// this same user on this same computer and not visible to logon sessions for this user on other computers.
		/// <para>
		/// Windows Vista Home Basic, Windows Vista Home Premium, Windows Vista Starter and Windows XP Home Edition: This value is not supported.
		/// </para>
		/// </summary>
		CRED_PERSIST_LOCAL_MACHINE = 2,

		/// <summary>
		/// The credential persists for all subsequent logon sessions on this same computer. It is visible to other logon sessions of
		/// this same user on this same computer and to logon sessions for this user on other computers.
		/// <para>
		/// This option can be implemented as locally persisted credential if the administrator or user configures the user account to
		/// not have roam-able state. For instance, if the user has no roaming profile, the credential will only persist locally.
		/// </para>
		/// <para>
		/// Windows Vista Home Basic, Windows Vista Home Premium, Windows Vista Starter and Windows XP Home Edition: This value is not supported.
		/// </para>
		/// </summary>
		CRED_PERSIST_ENTERPRISE = 3,
	}

	/// <summary>
	/// <para>
	/// The <c>CRED_PROTECTION_TYPE</c> enumeration specifies the security context in which credentials are encrypted when using the
	/// CredProtect function.
	/// </para>
	/// </summary>
	// https://docs.microsoft.com/en-us/windows/desktop/api/wincred/ne-wincred-_cred_protection_type typedef enum _CRED_PROTECTION_TYPE {
	// CredUnprotected , CredUserProtection , CredTrustedProtection , CredForSystemProtection } CRED_PROTECTION_TYPE, *PCRED_PROTECTION_TYPE;
	[PInvokeData("wincred.h", MSDNShortId = "6d8d8ad6-1b44-4482-a9a2-9c50d522b8d9")]
	public enum CRED_PROTECTION_TYPE
	{
		/// <summary>The credentials are not encrypted.</summary>
		CredUnprotected,

		/// <summary>
		/// The credentials are encrypted and can be decrypted only in the security context in which they were encrypted or in the
		/// security context of a trusted component.
		/// </summary>
		CredUserProtection,

		/// <summary>The credentials are encrypted and can only be decrypted by a trusted component.</summary>
		CredTrustedProtection,

		/// <summary/>
		CredForSystemProtection,
	}

	/// <summary>Flags used by <see cref="CREDENTIAL_TARGET_INFORMATION"/>.</summary>
	[PInvokeData("wincred.h", MSDNShortId = "92180f2c-ef7c-4481-9b6f-19234c114afb")]
	[Flags]
	public enum CRED_TI : uint
	{
		/// <summary>
		/// Set if the authentication package cannot determine whether the server name is a DNS name or a NetBIOS name. In that case, the
		/// NetbiosServerName member is set to NULL and the DnsServerName member is set to the server name of unknown format.
		/// </summary>
		CRED_TI_SERVER_FORMAT_UNKNOWN = 0x0001,

		/// <summary>
		/// Set if the authentication package cannot determine whether the domain name is a DNS name or a NetBIOS name. In that case, the
		/// NetbiosDomainName member is set to NULL and the DnsDomainName member is set to the domain name of unknown format.
		/// </summary>
		CRED_TI_DOMAIN_FORMAT_UNKNOWN = 0x0002,

		/// <summary>
		/// Set if the authentication package has determined that the server only needs a password to authenticate. The caller can use this
		/// flag to prompt only for a password and not a user name.
		/// </summary>
		CRED_TI_ONLY_PASSWORD_REQUIRED = 0x0004,

		/// <summary>TargetName is username</summary>
		CRED_TI_USERNAME_TARGET = 0x0008,

		/// <summary>When creating a cred, create one named TargetInfo-&gt;TargetName</summary>
		CRED_TI_CREATE_EXPLICIT_CRED = 0x0010,

		/// <summary>Indicates the machine is a member of a workgroup</summary>
		CRED_TI_WORKGROUP_MEMBER = 0x0020,

		/// <summary>used to tell credman that the DNSTreeName could be DFS server</summary>
		CRED_TI_DNSTREE_IS_DFS_SERVER = 0x0040,
	}

	/// <summary>Type of credential used by CREDENTIAL structure.</summary>
	[PInvokeData("wincred.h")]
	public enum CRED_TYPE
	{
		/// <summary>
		/// The credential is a generic credential. The credential will not be used by any particular authentication package. The
		/// credential will be stored securely but has no other significant characteristics.
		/// </summary>
		CRED_TYPE_GENERIC = 1,

		/// <summary>
		/// The credential is a password credential and is specific to Microsoft's authentication packages. The NTLM, Kerberos, and
		/// Negotiate authentication packages will automatically use this credential when connecting to the named target.
		/// </summary>
		CRED_TYPE_DOMAIN_PASSWORD = 2,

		/// <summary>
		/// The credential is a certificate credential and is specific to Microsoft's authentication packages. The Kerberos, Negotiate,
		/// and Schannel authentication packages automatically use this credential when connecting to the named target.
		/// </summary>
		CRED_TYPE_DOMAIN_CERTIFICATE = 3,

		/// <summary>
		/// This value is no longer supported.
		/// <para>
		/// <c>Windows Server 2003 and Windows XP:</c> The credential is a password credential and is specific to authentication packages
		/// from Microsoft. The Passport authentication package will automatically use this credential when connecting to the named target.
		/// </para>
		/// <para>
		/// Additional values will be defined in the future. Applications should be written to allow for credential types they do not understand.
		/// </para>
		/// </summary>
		CRED_TYPE_DOMAIN_VISIBLE_PASSWORD = 4,

		/// <summary>
		/// The credential is a certificate credential that is a generic authentication package.
		/// <para><c>Windows Server 2008, Windows Vista, Windows Server 2003 and Windows XP:</c> This value is not supported.</para>
		/// </summary>
		CRED_TYPE_GENERIC_CERTIFICATE = 5,

		/// <summary>
		/// The credential is supported by extended Negotiate packages.
		/// <para><c>Windows Server 2008, Windows Vista, Windows Server 2003 and Windows XP:</c> This value is not supported.</para>
		/// </summary>
		CRED_TYPE_DOMAIN_EXTENDED = 6,

		/// <summary>
		/// The maximum number of supported credential types. <note type="note">Windows Server 2008, Windows Vista, Windows Server 2003
		/// and Windows XP: This value is not supported.</note>
		/// </summary>
		CRED_TYPE_MAXIMUM = 7,

		/// <summary>
		/// The extended maximum number of supported credential types that now allow new applications to run on older operating systems.
		/// <note type="note">Windows Server 2008, Windows Vista, Windows Server 2003 and Windows XP: This value is not supported.</note>
		/// </summary>
		CRED_TYPE_MAXIMUM_EX = CRED_TYPE_MAXIMUM + 1000,
	}

	/// <summary>Flags for CredWrite.</summary>
	[PInvokeData("wincred.h", MSDNShortId = "9a590347-d610-4916-bf63-60fbec173ac2")]
	public enum CRED_WRITE
	{
		/// <summary>
		/// The credential BLOB from an existing credential is preserved with the same credential name and credential type. The
		/// CredentialBlobSize of the passed in Credential structure must be zero.
		/// </summary>
		CRED_PRESERVE_CREDENTIAL_BLOB = 0x01,
	}

	/// <summary>
	/// <para>
	/// The <c>CredDelete</c> function deletes a credential from the user's credential set. The credential set used is the one associated
	/// with the logon session of the current token. The token must not have the user's SID disabled.
	/// </para>
	/// </summary>
	/// <param name="TargetName">
	/// <para>Pointer to a null-terminated string that contains the name of the credential to delete.</para>
	/// </param>
	/// <param name="Type">
	/// <para>
	/// Type of the credential to delete. Must be one of the CRED_TYPE_* defined types. For a list of the defined types, see the
	/// <c>Type</c> member of the CREDENTIAL structure.
	/// </para>
	/// <para>
	/// If the value of this parameter is <c>CRED_TYPE_DOMAIN_EXTENDED</c>, this function can delete a credential that specifies a user
	/// name when there are multiple credentials for the same target. The value of the TargetName parameter must specify the user name as
	/// Target <c>|</c> UserName.
	/// </para>
	/// </param>
	/// <param name="Flags">
	/// <para>Reserved and must be zero.</para>
	/// </param>
	/// <returns>
	/// <para>
	/// The function returns <c>TRUE</c> on success and <c>FALSE</c> on failure. The GetLastError function can be called to get a more
	/// specific status code. The following status codes can be returned:
	/// </para>
	/// <list type="bullet">
	/// <item>
	/// <term>ERROR_NOT_FOUND</term>
	/// </item>
	/// <item>
	/// <term>ERROR_NO_SUCH_LOGON_SESSION</term>
	/// </item>
	/// <item>
	/// <term>ERROR_INVALID_FLAGS</term>
	/// </item>
	/// </list>
	/// </returns>
	// https://docs.microsoft.com/en-us/windows/desktop/api/wincred/nf-wincred-creddeletea BOOL CredDeleteA( LPCSTR TargetName, DWORD
	// Type, DWORD Flags );
	[DllImport(Lib.AdvApi32, SetLastError = true, CharSet = CharSet.Auto)]
	[PInvokeData("wincred.h", MSDNShortId = "154af9c8-18fd-412d-899d-7c6d2138380d")]
	[return: MarshalAs(UnmanagedType.Bool)]
	public static extern bool CredDelete(string TargetName, CRED_TYPE Type, uint Flags = 0);

	/// <summary>
	/// <para>
	/// The <c>CredEnumerate</c> function enumerates the credentials from the user's credential set. The credential set used is the one
	/// associated with the logon session of the current token. The token must not have the user's SID disabled.
	/// </para>
	/// </summary>
	/// <param name="Filter">
	/// <para>
	/// Pointer to a <c>null</c>-terminated string that contains the filter for the returned credentials. Only credentials with a
	/// TargetName matching the filter will be returned. The filter specifies a name prefix followed by an asterisk. For instance, the
	/// filter "FRED*" will return all credentials with a TargetName beginning with the string "FRED".
	/// </para>
	/// <para>If <c>NULL</c> is specified, all credentials will be returned.</para>
	/// </param>
	/// <param name="Flags">
	/// <para>The value of this parameter can be zero or more of the following values combined with a bitwise- <c>OR</c> operation.</para>
	/// <list type="table">
	/// <listheader>
	/// <term>Value</term>
	/// <term>Meaning</term>
	/// </listheader>
	/// <item>
	/// <term>CRED_ENUMERATE_ALL_CREDENTIALS 0x1</term>
	/// <term>
	/// This function enumerates all of the credentials in the user's credential set. The target name of each credential is returned in
	/// the "namespace:attribute=target" format. If this flag is set and the Filter parameter is not NULL, the function fails and returns
	/// ERROR_INVALID_FLAGS. Windows Server 2003 and Windows XP: This flag is not supported.
	/// </term>
	/// </item>
	/// </list>
	/// </param>
	/// <param name="Count">
	/// <para>Count of the credentials returned in the Credentials array.</para>
	/// </param>
	/// <param name="Credential">
	/// <para>
	/// Pointer to an array of pointers to credentials. The returned credential is a single allocated block. Any pointers contained
	/// within the buffer are pointers to locations within this single allocated block. The single returned buffer must be freed by
	/// calling CredFree.
	/// </para>
	/// </param>
	/// <returns>
	/// <para>
	/// The function returns <c>TRUE</c> on success and <c>FALSE</c> on failure. The GetLastError function can be called to get a more
	/// specific status code. The following status codes can be returned.
	/// </para>
	/// <list type="table">
	/// <listheader>
	/// <term>Return code/value</term>
	/// <term>Description</term>
	/// </listheader>
	/// <item>
	/// <term>ERROR_NOT_FOUND 1168 (0x490)</term>
	/// <term>No credential exists matching the specified Filter.</term>
	/// </item>
	/// <item>
	/// <term>ERROR_NO_SUCH_LOGON_SESSION 1312 (0x520)</term>
	/// <term>
	/// The logon session does not exist or there is no credential set associated with this logon session. Network logon sessions do not
	/// have an associated credential set.
	/// </term>
	/// </item>
	/// <item>
	/// <term>ERROR_INVALID_FLAGS 1004 (0x3EC)</term>
	/// <term>
	/// A flag that is not valid was specified for the Flags parameter, or CRED_ENUMERATE_ALL_CREDENTIALS is specified for the Flags
	/// parameter and the Filter parameter is not NULL.
	/// </term>
	/// </item>
	/// </list>
	/// </returns>
	// https://docs.microsoft.com/en-us/windows/desktop/api/wincred/nf-wincred-credenumeratea BOOL CredEnumerateA( LPCSTR Filter, DWORD
	// Flags, DWORD *Count, PCREDENTIALA **Credential );
	[DllImport(Lib.AdvApi32, SetLastError = true, CharSet = CharSet.Auto)]
	[PInvokeData("wincred.h", MSDNShortId = "ef0b7620-7b00-45f1-af16-141d2e940783")]
	[return: MarshalAs(UnmanagedType.Bool)]
	public static extern bool CredEnumerate(string? Filter, CRED_ENUM Flags, out uint Count, out SafeCredMemoryHandle Credential);

	/// <summary>
	/// The <c>CredEnumerate</c> function enumerates the credentials from the user's credential set. The credential set used is the one
	/// associated with the logon session of the current token. The token must not have the user's SID disabled.
	/// </summary>
	/// <param name="filter">
	/// <para>
	/// A string that contains the filter for the returned credentials. Only credentials with a TargetName matching the filter will be
	/// returned. The filter specifies a name prefix followed by an asterisk. For instance, the filter "FRED*" will return all
	/// credentials with a TargetName beginning with the string "FRED".
	/// </para>
	/// <para>
	/// If this value is <see langword="null"/>, this function enumerates all of the credentials in the user's credential set. The target
	/// name of each credential is returned in the "namespace:attribute=target" format.
	/// </para>
	/// </param>
	/// <returns>An array of credentials.</returns>
	public static CREDENTIAL_MGD[] CredEnumerate(string? filter = null)
	{
		if (!CredEnumerate(filter, filter is null ? CRED_ENUM.CRED_ENUMERATE_ALL_CREDENTIALS : CRED_ENUM.NONE, out var cnt, out var creds))
			Win32Error.ThrowLastError();
		using (creds)
			return creds.GetCredArray((int)cnt);
	}

	/// <summary>
	/// <para>
	/// The <c>CredFindBestCredential</c> function searches the Credentials Management (CredMan) database for the set of generic
	/// credentials that are associated with the current logon session and that best match the specified target resource.
	/// </para>
	/// </summary>
	/// <param name="TargetName">
	/// <para>A pointer to a null-terminated string that contains the name of the target resource for which to find credentials.</para>
	/// </param>
	/// <param name="Type">
	/// <para>The type of credentials to search for. Currently, this function supports only <c>CRED_TYPE_GENERIC</c>.</para>
	/// </param>
	/// <param name="Flags">
	/// <para>Reserved.</para>
	/// </param>
	/// <param name="Credential">
	/// <para>The address of a pointer to a CREDENTIAL structure that specifies the set of credentials this function finds.</para>
	/// <para>When you have finished using this structure, free it by calling the CredFree function.</para>
	/// </param>
	/// <returns>
	/// <para>If the function succeeds, it returns <c>TRUE</c>.</para>
	/// <para>If the function fails, it returns <c>FALSE</c>. To get extended error information, call GetLastError.</para>
	/// </returns>
	// https://docs.microsoft.com/en-us/windows/desktop/api/wincred/nf-wincred-credfindbestcredentiala BOOL CredFindBestCredentialA(
	// LPCSTR TargetName, DWORD Type, DWORD Flags, PCREDENTIALA *Credential );
	[DllImport(Lib.AdvApi32, SetLastError = true, CharSet = CharSet.Auto)]
	[PInvokeData("wincred.h", MSDNShortId = "b39e3167-dd63-4b81-b850-f3117be348a5")]
	[return: MarshalAs(UnmanagedType.Bool)]
	public static extern bool CredFindBestCredential(string TargetName, CRED_TYPE Type, [Optional] uint Flags, out SafeCredMemoryHandle Credential);

	/// <summary>
	/// The <c>CredFindBestCredential</c> function searches the Credentials Management (CredMan) database for the set of generic
	/// credentials that are associated with the current logon session and that best match the specified target resource.
	/// </summary>
	/// <param name="TargetName">
	/// A pointer to a null-terminated string that contains the name of the target resource for which to find credentials.
	/// </param>
	/// <param name="Type">The type of credentials to search for. Currently, this function supports only <c>CRED_TYPE_GENERIC</c>.</param>
	/// <param name="Credential">On success, gets a CREDENTIAL_MGD structure that specifies the set of credentials this function finds.</param>
	/// <returns>
	/// <para>If the function succeeds, it returns <c>TRUE</c>.</para>
	/// <para>If the function fails, it returns <c>FALSE</c>. To get extended error information, call GetLastError.</para>
	/// </returns>
	// https://docs.microsoft.com/en-us/windows/desktop/api/wincred/nf-wincred-credfindbestcredentiala BOOL CredFindBestCredentialA(
	// LPCSTR TargetName, DWORD Type, DWORD Flags, PCREDENTIALA *Credential );
	[PInvokeData("wincred.h", MSDNShortId = "b39e3167-dd63-4b81-b850-f3117be348a5")]
	public static bool CredFindBestCredential(string TargetName, CRED_TYPE Type, out CREDENTIAL_MGD Credential)
	{
		var b = CredFindBestCredential(TargetName, Type, 0, out SafeCredMemoryHandle cred);
		using (cred)
			Credential = b ? (CREDENTIAL_MGD)cred : default;
		return b;
	}

	/// <summary>
	/// <para>The <c>CredFree</c> function frees a buffer returned by any of the credentials management functions.</para>
	/// </summary>
	/// <param name="Buffer">
	/// <para>Pointer to the buffer to be freed.</para>
	/// </param>
	/// <returns>
	/// <para>This function does not return a value.</para>
	/// </returns>
	// https://docs.microsoft.com/en-us/windows/desktop/api/wincred/nf-wincred-credfree void CredFree( PVOID Buffer );
	[DllImport(Lib.AdvApi32, SetLastError = false, ExactSpelling = true)]
	[PInvokeData("wincred.h", MSDNShortId = "bc33ab1b-dd3f-4e1b-96d2-e32ceff89ada")]
	public static extern void CredFree(IntPtr Buffer);

	/// <summary>The <c>CredGetSessionTypes</c> function returns the maximum persistence supported by the current logon session. A separate maximum persistence is returned for each credential type.</summary>
	/// <param name="MaximumPersistCount">Number of elements in the <c>MaximumPersist</c> array. Use CRED_TYPE_MAXIMUM to return all of the currently defined credential types.</param>
	/// <param name="MaximumPersist">
	/// <para>Pointer to an array to return the persistence values in. The passed in array should be <c>MaximumPersistCount</c> elements long. On return, each element specifies the maximum persistence supported by the corresponding credential type.</para>
	/// <para>The caller should use one of the following defines to index into the array:</para>
	/// <list type="bullet">
	/// <item>
	/// <description>CRED_TYPE_GENERIC</description>
	/// </item>
	/// <item>
	/// <description>CRED_TYPE_DOMAIN_PASSWORD</description>
	/// </item>
	/// <item>
	/// <description>CRED_TYPE_DOMAIN_CERTIFICATE</description>
	/// </item>
	/// </list>
	/// <para>That is,</para>
	/// <para>MaximumPersist</para>
	/// <para>[CRED_TYPE_GENERIC] specifies the maximum persistence supported for generic credentials.</para>
	/// <para>The following values can be returned in each element of the array.</para>
	/// <list type="table">
	/// <listheader>
	/// <term>Value</term>
	/// <term>Meaning</term>
	/// </listheader>
	/// <item>
	/// <term><c>CRED_PERSIST_NONE</c></term>
	/// <term>No credential can be stored. This value will be returned if the credential type is not supported or has been disabled by policy.</term>
	/// </item>
	/// <item>
	/// <term><c>CRED_PERSIST_SESSION</c></term>
	/// <term>Only a session-specific credential can be stored.</term>
	/// </item>
	/// <item>
	/// <term><c>CRED_PERSIST_LOCAL_MACHINE</c></term>
	/// <term>Session-specific and computer-specific credentials can be stored. <c>Windows XP: </c>This credential cannot be stored for sessions in which the profile is not loaded.</term>
	/// </item>
	/// <item>
	/// <term><c>CRED_PERSIST_ENTERPRISE</c></term>
	/// <term>Any credential can be stored. <c>Windows XP: </c>This credential cannot be stored for sessions in which the profile is not loaded.</term>
	/// </item>
	/// </list>
	/// </param>
	/// <returns>
	/// <para>This function returns <c>TRUE</c> on success and <c>FALSE</c> on failure. The GetLastError function can be called to get a more specific status code. The following status code can be returned:</para>
	/// <para>ERROR_NO_SUCH_LOGON_SESSION</para>
	/// <para>The logon session does not exist or there is no credential set associated with this logon session. Network logon sessions do not have an associated credential set.</para>
	/// </returns>
	// https://learn.microsoft.com/en-us/windows/win32/api/wincred/nf-wincred-credgetsessiontypes
	// BOOL CredGetSessionTypes( [in] DWORD MaximumPersistCount, [out] LPDWORD MaximumPersist );
	[PInvokeData("wincred.h", MSDNShortId = "NF:wincred.CredGetSessionTypes")]
	[DllImport(Lib.AdvApi32, SetLastError = true, ExactSpelling = true)]
	[return: MarshalAs(UnmanagedType.Bool)]
	public static extern bool CredGetSessionTypes(uint MaximumPersistCount, [In, Out, MarshalAs(UnmanagedType.LPArray, SizeParamIndex = 0)] CRED_PERSIST[] MaximumPersist);

	/// <summary>
	/// <para>
	/// The <c>CredGetTargetInfo</c> function retrieves all known target name information for the named target computer. This executed
	/// locally and does not need any particular privilege. The information returned is expected to be passed to the
	/// CredReadDomainCredentials and CredWriteDomainCredentials functions. The information should not be used for any other purpose.
	/// </para>
	/// <para>
	/// Authentication packages compute TargetInfo when attempting to authenticate to a TargetName. The authentication packages cache
	/// this target information to make it available to <c>CredGetTargetInfo</c>. Therefore, the target information will only be
	/// available from a recent attempt to authenticate a TargetName.
	/// </para>
	/// <para>
	/// Authentication packages not in the LSA process can cache a TargetInfo for later retrieval by <c>CredGetTargetInfo</c> by calling
	/// CredReadDomainCredentials with the CRED_CACHE_TARGET_INFORMATION flag.
	/// </para>
	/// </summary>
	/// <param name="TargetName">
	/// <para>Pointer to a null-terminated string that contains the name of the target computer for which information is to be retrieved.</para>
	/// </param>
	/// <param name="Flags">
	/// <para>Flags controlling the operation of the function. The following flag can be used:</para>
	/// <para>CRED_ALLOW_NAME_RESOLUTION</para>
	/// <para>
	/// If no target information can be found for TargetName name resolution is done on TargetName to convert it to other forms. If
	/// target information exists for any of those other forms, it is returned. Currently only DNS name resolution is done.
	/// </para>
	/// <para>
	/// This is useful if the application does not call an authentication package directly. The application can pass the TargetName to
	/// another layer of software to authenticate to the server, and that layer of software might resolve the name and pass the resolved
	/// name to the authentication package. As such, there will be no target information for the original TargetName.
	/// </para>
	/// </param>
	/// <param name="TargetInfo">
	/// <para>
	/// Pointer to a single allocated block buffer to contain the target information. At least one of the returned members of TargetInfo
	/// will be non-NULL. Any pointers contained within the buffer are pointers to locations within this single allocated block. The
	/// single returned buffer must be freed by calling CredFree.
	/// </para>
	/// </param>
	/// <returns>
	/// <para>
	/// The function returns <c>TRUE</c> on success and <c>FALSE</c> on failure. The GetLastError function can be called to get a more
	/// specific status code. The following status code can be returned:
	/// </para>
	/// <list type="bullet">
	/// <item>
	/// <term>ERROR_NOT_FOUND</term>
	/// </item>
	/// </list>
	/// </returns>
	// https://docs.microsoft.com/en-us/windows/desktop/api/wincred/nf-wincred-credgettargetinfoa BOOL CredGetTargetInfoA( LPCSTR
	// TargetName, DWORD Flags, PCREDENTIAL_TARGET_INFORMATIONA *TargetInfo );
	[DllImport(Lib.AdvApi32, SetLastError = true, CharSet = CharSet.Auto)]
	[PInvokeData("wincred.h", MSDNShortId = "14dca0af-72d7-4ca8-84bb-c7040c5b5fb9")]
	[return: MarshalAs(UnmanagedType.Bool)]
	public static extern bool CredGetTargetInfo(string TargetName, uint Flags, out SafeCredMemoryHandle TargetInfo);

	/// <summary>
	/// <para>
	/// The <c>CredIsMarshaledCredential</c> function determines whether a specified user name string is a marshaled credential
	/// previously marshaled by CredMarshalCredential.
	/// </para>
	/// </summary>
	/// <param name="MarshaledCredential">
	/// <para>Pointer to a null-terminated string that contains the marshaled credential.</para>
	/// </param>
	/// <returns>
	/// <para>This function returns <c>TRUE</c> if MarshaledCredential is a marshaled credential and <c>FALSE</c> if it is not.</para>
	/// </returns>
	// https://docs.microsoft.com/en-us/windows/desktop/api/wincred/nf-wincred-credismarshaledcredentiala BOOL
	// CredIsMarshaledCredentialA( LPCSTR MarshaledCredential );
	[DllImport(Lib.AdvApi32, SetLastError = false, CharSet = CharSet.Auto)]
	[PInvokeData("wincred.h", MSDNShortId = "fc902c0c-41e0-4178-8ca0-227a1d218388")]
	[return: MarshalAs(UnmanagedType.Bool)]
	public static extern bool CredIsMarshaledCredential(string MarshaledCredential);

	/// <summary>
	/// <para>
	/// The <c>CredIsProtected</c> function specifies whether the specified credentials are encrypted by a previous call to the
	/// CredProtect function.
	/// </para>
	/// </summary>
	/// <param name="pszProtectedCredentials">
	/// <para>A pointer to a null-terminated string that specifies the credentials to test.</para>
	/// </param>
	/// <param name="pProtectionType">
	/// <para>
	/// A pointer to a value from the CRED_PROTECTION_TYPE enumeration that specifies whether the credentials specified in the
	/// pszProtectedCredentials parameter are protected.
	/// </para>
	/// </param>
	/// <returns>
	/// <para><c>TRUE</c> if the function succeeds; otherwise, <c>FALSE</c>.</para>
	/// <para>For extended error information, call the GetLastError function.</para>
	/// </returns>
	// https://docs.microsoft.com/en-us/windows/desktop/api/wincred/nf-wincred-credisprotecteda BOOL CredIsProtectedA( StrPtrAnsi
	// pszProtectedCredentials, CRED_PROTECTION_TYPE *pProtectionType );
	[DllImport(Lib.AdvApi32, SetLastError = true, CharSet = CharSet.Auto)]
	[PInvokeData("wincred.h", MSDNShortId = "3c38ecf5-1288-4a50-ad17-595e9ff4aaca")]
	[return: MarshalAs(UnmanagedType.Bool)]
	public static extern bool CredIsProtected(string pszProtectedCredentials, out CRED_PROTECTION_TYPE pProtectionType);

	/// <summary>
	/// <para>
	/// The <c>CredMarshalCredential</c> function transforms a credential into a text string. Historically, many functions, such as
	/// NetUseAdd, take a domain name, user name, and password as credentials. These functions do not accept certificates as credentials.
	/// The <c>CredMarshalCredential</c> function converts such credentials into a form that can be passed into these APIs.
	/// </para>
	/// <para>
	/// The marshaled credential should be passed as the user name string to any API that is currently passed credentials. The domain
	/// name, if applicable, passed to that API should be passed as <c>NULL</c> or empty. For certificate credentials, the PIN of the
	/// certificate should be passed to that API as the password.
	/// </para>
	/// <para>
	/// The caller should not modify or print marshaled credentials. The returned value can be freely converted between the Unicode,
	/// ANSI, and OEM characters sets. The string is case sensitive.
	/// </para>
	/// </summary>
	/// <param name="CredType">
	/// <para>Type of the credential to marshal.</para>
	/// </param>
	/// <param name="Credential">
	/// <para>Credential to marshal.</para>
	/// <para>This is one of the CRED_MARSHAL_TYPE values.</para>
	/// <para>If CredType is CertCredential, Credential points to a CERT_CREDENTIAL_INFO structure.</para>
	/// <para>If CredType is UsernameTargetCredential, Credential points to a USERNAME_TARGET_CREDENTIAL_INFO structure.</para>
	/// </param>
	/// <param name="MarshaledCredential">
	/// <para>
	/// Pointer to a <c>null</c>-terminated string that contains the marshaled credential. The caller should free the returned buffer
	/// using CredFree.
	/// </para>
	/// </param>
	/// <returns>
	/// <para>
	/// This function returns <c>TRUE</c> on success and <c>FALSE</c> on failure. The GetLastError function can be called to get a more
	/// specific status code. The following status code can be returned:
	/// </para>
	/// <para>ERROR_INVALID_PARAMETER</para>
	/// <para>CredType is not valid.</para>
	/// </returns>
	// https://docs.microsoft.com/en-us/windows/desktop/api/wincred/nf-wincred-credmarshalcredentiala BOOL CredMarshalCredentialA(
	// CRED_MARSHAL_TYPE CredType, PVOID Credential, StrPtrAnsi *MarshaledCredential );
	[DllImport(Lib.AdvApi32, SetLastError = true, CharSet = CharSet.Auto)]
	[PInvokeData("wincred.h", MSDNShortId = "20a1d54b-04a7-4b0a-88e4-1970d1f71502")]
	[return: MarshalAs(UnmanagedType.Bool)]
	public static extern bool CredMarshalCredential(CRED_MARSHAL_TYPE CredType, IntPtr Credential, out SafeCredMemoryHandle MarshaledCredential);

	/// <summary>
	/// <para>
	/// The <c>CredMarshalCredential</c> function transforms a credential into a text string. Historically, many functions, such as
	/// NetUseAdd, take a domain name, user name, and password as credentials. These functions do not accept certificates as credentials.
	/// The <c>CredMarshalCredential</c> function converts such credentials into a form that can be passed into these APIs.
	/// </para>
	/// <para>
	/// The marshaled credential should be passed as the user name string to any API that is currently passed credentials. The domain
	/// name, if applicable, passed to that API should be passed as <c>NULL</c> or empty. For certificate credentials, the PIN of the
	/// certificate should be passed to that API as the password.
	/// </para>
	/// <para>
	/// The caller should not modify or print marshaled credentials. The returned value can be freely converted between the Unicode,
	/// ANSI, and OEM characters sets. The string is case sensitive.
	/// </para>
	/// </summary>
	/// <param name="CredType">
	/// <para>Type of the credential to marshal.</para>
	/// </param>
	/// <param name="Credential">
	/// <para>Credential to marshal.</para>
	/// <para>This is one of the CRED_MARSHAL_TYPE values.</para>
	/// <para>If CredType is CertCredential, Credential points to a CERT_CREDENTIAL_INFO structure.</para>
	/// <para>If CredType is UsernameTargetCredential, Credential points to a USERNAME_TARGET_CREDENTIAL_INFO structure.</para>
	/// </param>
	/// <param name="MarshaledCredential">
	/// <para>
	/// Pointer to a <c>null</c>-terminated string that contains the marshaled credential. The caller should free the returned buffer
	/// using CredFree.
	/// </para>
	/// </param>
	/// <returns>
	/// <para>
	/// This function returns <c>TRUE</c> on success and <c>FALSE</c> on failure. The GetLastError function can be called to get a more
	/// specific status code. The following status code can be returned:
	/// </para>
	/// <para>ERROR_INVALID_PARAMETER</para>
	/// <para>CredType is not valid.</para>
	/// </returns>
	[PInvokeData("wincred.h", MSDNShortId = "20a1d54b-04a7-4b0a-88e4-1970d1f71502")]
	public static bool CredMarshalCredential<T>(T Credential, [NotNullWhen(true)] out string? MarshaledCredential, CRED_MARSHAL_TYPE CredType = 0) where T : struct
	{
		if (CredType == 0 ? !CorrespondingTypeAttribute.CanGet<T, CRED_MARSHAL_TYPE>(out CredType) : !CorrespondingTypeAttribute.CanGet(CredType, typeof(T)))
			throw new InvalidCastException();
		using var mem = SafeHGlobalHandle.CreateFromStructure(Credential);
		var b = CredMarshalCredential(CredType, mem, out SafeCredMemoryHandle cred);
		MarshaledCredential = b ? (string?)cred : null;
		return b;
	}

	/// <summary>
	/// <para>
	/// The <c>CredProtect</c> function encrypts the specified credentials so that only the current security context can decrypt them.
	/// </para>
	/// </summary>
	/// <param name="fAsSelf">
	/// <para>
	/// Set to <c>TRUE</c> to specify that the credentials are encrypted in the security context of the current process. Set to
	/// <c>FALSE</c> to specify that credentials are encrypted in the security context of the calling thread security context.
	/// </para>
	/// </param>
	/// <param name="pszCredentials">
	/// <para>
	/// A pointer to a string that specifies the credentials to encrypt. The function encrypts the number of characters provided in the
	/// cchCredentials parameter.
	/// </para>
	/// </param>
	/// <param name="cchCredentials">
	/// <para>The size, in characters, of the pszCredentials buffer.</para>
	/// </param>
	/// <param name="pszProtectedCredentials">
	/// <para>A pointer to a string that, on output, receives the encrypted credentials.</para>
	/// </param>
	/// <param name="pcchMaxChars">
	/// <para>
	/// The size, in characters of the pszProtectedCredentials buffer. On output, if the pszProtectedCredentials is not of sufficient
	/// size to receive the encrypted credentials, this parameter specifies the required size, in characters, of the
	/// pszProtectedCredentials buffer.
	/// </para>
	/// </param>
	/// <param name="ProtectionType">
	/// <para>A pointer to a CRED_PROTECTION_TYPE enumeration type that, on output, specifies the type of protection provided.</para>
	/// </param>
	/// <returns>
	/// <para><c>TRUE</c> if the function succeeds; otherwise, <c>FALSE</c>.</para>
	/// <para>For extended error information, call the GetLastError function.</para>
	/// </returns>
	/// <remarks>
	/// <para>
	/// Note that the output of the <c>CredProtect</c> function is not integrity protected, so if the output is modified, the
	/// CredUnprotect function is not updated and may produce incorrect results.
	/// </para>
	/// </remarks>
	// https://docs.microsoft.com/en-us/windows/desktop/api/wincred/nf-wincred-credprotecta BOOL CredProtectA( BOOL fAsSelf, StrPtrAnsi
	// pszCredentials, DWORD cchCredentials, StrPtrAnsi pszProtectedCredentials, DWORD *pcchMaxChars, CRED_PROTECTION_TYPE *ProtectionType );
	[DllImport(Lib.AdvApi32, SetLastError = true, CharSet = CharSet.Auto)]
	[PInvokeData("wincred.h", MSDNShortId = "1e299dfb-2ffe-463c-9e2c-b7774a2216e3")]
	[return: MarshalAs(UnmanagedType.Bool)]
	public static extern bool CredProtect([MarshalAs(UnmanagedType.Bool)] bool fAsSelf, string pszCredentials, uint cchCredentials, StringBuilder pszProtectedCredentials, ref uint pcchMaxChars, out CRED_PROTECTION_TYPE ProtectionType);

	/// <summary>
	/// <para>
	/// The <c>CredRead</c> function reads a credential from the user's credential set. The credential set used is the one associated
	/// with the logon session of the current token. The token must not have the user's SID disabled.
	/// </para>
	/// </summary>
	/// <param name="TargetName">
	/// <para>Pointer to a null-terminated string that contains the name of the credential to read.</para>
	/// </param>
	/// <param name="Type">
	/// <para>Type of the credential to read. Type must be one of the CRED_TYPE_* defined types.</para>
	/// </param>
	/// <param name="Flags">
	/// <para>Currently reserved and must be zero.</para>
	/// </param>
	/// <param name="Credential">
	/// <para>
	/// Pointer to a single allocated block buffer to return the credential. Any pointers contained within the buffer are pointers to
	/// locations within this single allocated block. The single returned buffer must be freed by calling CredFree.
	/// </para>
	/// </param>
	/// <returns>
	/// <para>
	/// The function returns <c>TRUE</c> on success and <c>FALSE</c> on failure. The GetLastError function can be called to get a more
	/// specific status code. The following status codes can be returned:
	/// </para>
	/// <list type="bullet">
	/// <item>
	/// <term>ERROR_NOT_FOUND</term>
	/// </item>
	/// <item>
	/// <term>ERROR_NO_SUCH_LOGON_SESSION</term>
	/// </item>
	/// <item>
	/// <term>ERROR_INVALID_FLAGS</term>
	/// </item>
	/// </list>
	/// </returns>
	/// <remarks>
	/// <para>
	/// If the value of the <c>Type</c> member of the CREDENTIAL structure specified by the Credential parameter is
	/// <c>CRED_TYPE_DOMAIN_EXTENDED</c>, a namespace must be specified in the target name. This function can return only one credential
	/// of the specified type.
	/// </para>
	/// </remarks>
	// https://docs.microsoft.com/en-us/windows/desktop/api/wincred/nf-wincred-credreada BOOL CredReadA( LPCSTR TargetName, DWORD Type,
	// DWORD Flags, PCREDENTIALA *Credential );
	[DllImport(Lib.AdvApi32, SetLastError = true, CharSet = CharSet.Auto)]
	[PInvokeData("wincred.h", MSDNShortId = "3222de7b-5290-4e82-a382-b2db6afc78cc")]
	[return: MarshalAs(UnmanagedType.Bool)]
	public static extern bool CredRead(string TargetName, CRED_TYPE Type, [Optional] uint Flags, out SafeCredMemoryHandle Credential);

	/// <summary>
	/// <para>
	/// The <c>CredRead</c> function reads a credential from the user's credential set. The credential set used is the one associated
	/// with the logon session of the current token. The token must not have the user's SID disabled.
	/// </para>
	/// </summary>
	/// <param name="TargetName">
	/// <para>Pointer to a null-terminated string that contains the name of the credential to read.</para>
	/// </param>
	/// <param name="Type">
	/// <para>Type of the credential to read. Type must be one of the CRED_TYPE_* defined types.</para>
	/// </param>
	/// <param name="Credential">
	/// <para>The credential.</para>
	/// </param>
	/// <returns>
	/// <para>
	/// The function returns <c>TRUE</c> on success and <c>FALSE</c> on failure. The GetLastError function can be called to get a more
	/// specific status code. The following status codes can be returned:
	/// </para>
	/// <list type="bullet">
	/// <item>
	/// <term>ERROR_NOT_FOUND</term>
	/// </item>
	/// <item>
	/// <term>ERROR_NO_SUCH_LOGON_SESSION</term>
	/// </item>
	/// <item>
	/// <term>ERROR_INVALID_FLAGS</term>
	/// </item>
	/// </list>
	/// </returns>
	/// <remarks>
	/// <para>
	/// If the value of the <c>Type</c> member of the CREDENTIAL structure specified by the Credential parameter is
	/// <c>CRED_TYPE_DOMAIN_EXTENDED</c>, a namespace must be specified in the target name. This function can return only one credential
	/// of the specified type.
	/// </para>
	/// </remarks>
	[PInvokeData("wincred.h", MSDNShortId = "3222de7b-5290-4e82-a382-b2db6afc78cc")]
	public static bool CredRead(string TargetName, CRED_TYPE Type, out CREDENTIAL_MGD Credential)
	{
		var b = CredRead(TargetName, Type, 0, out var cred);
		using (cred)
			Credential = b ? cred : default(CREDENTIAL_MGD);
		return b;
	}

	/// <summary>
	/// <para>
	/// The <c>CredReadDomainCredentials</c> function reads the domain credentials from the user's credential set. The credential set
	/// used is the one associated with the logon session of the current token. The token must not have the user's SID disabled.
	/// </para>
	/// </summary>
	/// <param name="TargetInfo">
	/// <para>
	/// Target information that identifies the target server. At least one of the naming members must not be <c>NULL</c>:
	/// NetbiosServerName, DnsServerName, NetbiosDomainName, DnsDomainName or DnsTreeName.
	/// </para>
	/// </param>
	/// <param name="Flags">
	/// <para>Flags controlling the operation of the function.</para>
	/// <para>The following flag is defined:</para>
	/// <para>CRED_CACHE_TARGET_INFORMATION</para>
	/// <para>Cache the TargetInfo for a subsequent read using CredGetTargetInfo.</para>
	/// </param>
	/// <param name="Count">
	/// <para>Count of the credentials returned in the Credentials array.</para>
	/// </param>
	/// <param name="Credential">
	/// <para>
	/// Pointer to an array of pointers to credentials. The most specific existing credential matching the TargetInfo is returned. If
	/// credentials of various types (for example, CRED_TYPE_DOMAIN_PASSWORD and CRED_TYPE_DOMAIN_CERTIFICATE credentials) exist, one of
	/// each type is returned. If a connection were to be made to the named target, this most-specific credential would be used.
	/// </para>
	/// <para>
	/// Only those credential types specified by the TargetInfo.CredTypes array are returned. The returned Credentials array is sorted in
	/// the same order as the TargetInfo.CredTypes array. That is, authentication packages specify a preferred credential type by
	/// specifying it earlier in the TargetInfo.CredTypes array.If TargetInfo.CredTypeCount is zero, the Credentials array is returned in
	/// the following sorted order:
	/// </para>
	/// <list type="bullet">
	/// <item>
	/// <term>CRED_TYPE_DOMAIN_CERTIFICATE</term>
	/// </item>
	/// <item>
	/// <term>CRED_TYPE_DOMAIN_PASSWORD</term>
	/// </item>
	/// </list>
	/// <para>
	/// The returned buffer is a single allocated block. Any pointers contained within the buffer are pointers to locations within this
	/// single allocated block. The single returned buffer must be freed by calling CredFree.
	/// </para>
	/// </param>
	/// <returns>
	/// <para>
	/// The function returns <c>TRUE</c> on success and <c>FALSE</c> on failure. The GetLastError function can be called to get a more
	/// specific status code. The following status codes can be returned:
	/// </para>
	/// <list type="bullet">
	/// <item>
	/// <term>ERROR_INVALID_PARAMETER</term>
	/// </item>
	/// <item>
	/// <term>ERROR_NOT_FOUND</term>
	/// </item>
	/// <item>
	/// <term>ERROR_NO_SUCH_LOGON_SESSION</term>
	/// </item>
	/// <item>
	/// <term>ERROR_INVALID_FLAGS</term>
	/// </item>
	/// </list>
	/// </returns>
	/// <remarks>
	/// <para>
	/// This function returns the most specific credentials matching the naming parameters. For instance, if there is a credential that
	/// matches the target server name and a credential that matches the target domain name, only the server specific credential is
	/// returned. This is the credential that would be used.
	/// </para>
	/// <para>
	/// The following list specifies the order (from most specific to least specific) of what credential is returned if more than one matches:
	/// </para>
	/// <list type="bullet">
	/// <item>
	/// <term>The credential target name is of the form &lt;DfsRoot&gt;\&lt;DfsShare&gt;, and it is an exact match on the TargetName.</term>
	/// </item>
	/// <item>
	/// <term>An exact match on the DnsServerName.</term>
	/// </item>
	/// <item>
	/// <term>An exact match on the NetBIOSServerName.</term>
	/// </item>
	/// <item>
	/// <term>An exact match on TargetName.</term>
	/// </item>
	/// <item>
	/// <term>
	/// A match of the DnsServerName to a wildcard server credential. If more than one wildcard server credential matches, the credential
	/// with the longer TargetName is used. That is, a credential for *.example.microsoft.com is used instead of a credential for *.microsoft.com.
	/// </term>
	/// </item>
	/// <item>
	/// <term>An exact match of the DnsDomainName to a wildcard domain credential of the form &lt;DnsDomainName&gt;\*.</term>
	/// </item>
	/// <item>
	/// <term>An exact match of the NetBIOSDomainName to a wildcard domain credential of the form &lt;NetBIOSDomainName&gt;\*</term>
	/// </item>
	/// <item>
	/// <term>The credential named CRED_SESSION_WILDCARD_NAME.</term>
	/// </item>
	/// <item>
	/// <term>The credential named "*".</term>
	/// </item>
	/// </list>
	/// <para>
	/// <c>CredReadDomainCredentials</c> differs from CredRead in that it handles the idiosyncrasies of domain (CRED_TYPE_DOMAIN_PASSWORD
	/// or CRED_TYPE_DOMAIN_CERTIFICATE) credentials. Domain credentials contain more than one target member.
	/// </para>
	/// <para>
	/// If the value of the <c>Type</c> member of the CREDENTIAL structure specified by the Credentials parameter is
	/// <c>CRED_TYPE_DOMAIN_EXTENDED</c>, a namespace must be specified in the target name. This function can return only one credential
	/// of the specified type.
	/// </para>
	/// <para>
	/// This function can return multiple credentials of this type, but <c>CRED_TYPE_DOMAIN_EXTENDED</c> cannot be mixed with other types
	/// in the <c>CredTypes</c> member of the CREDENTIAL_TARGET_INFORMATION structure specified by the TargetInfo parameter.
	/// </para>
	/// </remarks>
	// https://docs.microsoft.com/en-us/windows/desktop/api/wincred/nf-wincred-credreaddomaincredentialsa BOOL
	// CredReadDomainCredentialsA( PCREDENTIAL_TARGET_INFORMATIONA TargetInfo, DWORD Flags, DWORD *Count, PCREDENTIALA **Credential );
	[DllImport(Lib.AdvApi32, SetLastError = true, CharSet = CharSet.Auto)]
	[PInvokeData("wincred.h", MSDNShortId = "b62cb9c9-2a64-4ef4-97f0-e1ea85976d3e")]
	[return: MarshalAs(UnmanagedType.Bool)]
	public static extern bool CredReadDomainCredentials(in CREDENTIAL_TARGET_INFORMATION TargetInfo, uint Flags, out uint Count, out SafeCredMemoryHandle Credential);

	/// <summary>
	/// <para>[ <c>CredRename</c> is no longer supported. Starting with Windows Vista, calls to <c>CredRename</c> always return ERROR_NOT_SUPPORTED.]</para>
	/// <para>
	/// The <c>CredRename</c> function renames a credential in the user's credential set. The credential set used is the one associated
	/// with the logon session of the current token. The token must not have the user's SID disabled.
	/// </para>
	/// </summary>
	/// <param name="OldTargetName">
	/// <para>Pointer to a null-terminated string that contains the current name of the credential to be renamed.</para>
	/// </param>
	/// <param name="NewTargetName">
	/// <para>Pointer to a null-terminated string that contains the new name for the credential.</para>
	/// </param>
	/// <param name="Type">
	/// <para>Type of the credential to rename. Must be one of the CRED_TYPE_* defines.</para>
	/// </param>
	/// <param name="Flags">
	/// <para>Flags to control the operation of the function. Currently reserved and must be zero.</para>
	/// </param>
	/// <returns>
	/// <para>
	/// The function returns <c>TRUE</c> on success and <c>FALSE</c> on failure. The GetLastError function can be called to get a more
	/// specific status code. The following status codes can be returned:
	/// </para>
	/// <list type="bullet">
	/// <item>
	/// <term>ERROR_NOT_FOUND</term>
	/// </item>
	/// <item>
	/// <term>ERROR_ALREADY_EXISTS</term>
	/// </item>
	/// <item>
	/// <term>ERROR_NO_SUCH_LOGON_SESSION</term>
	/// </item>
	/// <item>
	/// <term>ERROR_INVALID_FLAGS</term>
	/// </item>
	/// </list>
	/// </returns>
	// https://docs.microsoft.com/en-us/windows/desktop/api/wincred/nf-wincred-credrenamea BOOL CredRenameA( LPCSTR OldTargetName, LPCSTR
	// NewTargetName, DWORD Type, DWORD Flags );
	[DllImport(Lib.AdvApi32, SetLastError = true, CharSet = CharSet.Auto), Obsolete("CredRename is no longer supported as of Windows Vista.")]
	[PInvokeData("wincred.h", MSDNShortId = "e598f2ae-f975-4dd2-bf0b-e2fd96d4c940")]
	[return: MarshalAs(UnmanagedType.Bool)]
	public static extern bool CredRename(string OldTargetName, string NewTargetName, CRED_TYPE Type, uint Flags = 0);

	/// <summary>
	/// <para>The <c>CredUnmarshalCredential</c> function transforms a marshaled credential back into its original form.</para>
	/// </summary>
	/// <param name="MarshaledCredential">
	/// <para>Pointer to a null-terminated string that contains the marshaled credential.</para>
	/// </param>
	/// <param name="CredType">
	/// <para>Type of credential specified by MarshaledCredential.</para>
	/// <para>This is one of the CRED_MARSHAL_TYPE values.</para>
	/// </param>
	/// <param name="Credential">
	/// <para>
	/// Pointer to the unmarshaled credential. If CredType returns CertCredential, the returned pointer is to a CERT_CREDENTIAL_INFO
	/// structure. If CredType returns UsernameTargetCredential, the returned pointer is to a USERNAME_TARGET_CREDENTIAL_INFO structure.
	/// </para>
	/// <para>The caller should free the returned buffer using CredFree.</para>
	/// </param>
	/// <returns>
	/// <para>
	/// This function returns <c>TRUE</c> on success and <c>FALSE</c> on failure. The GetLastError function can be called to get a more
	/// specific status code. The following status code can be returned:
	/// </para>
	/// <para>ERROR_INVALID_PARAMETER</para>
	/// <para>MarshaledCredential is not valid.</para>
	/// </returns>
	// https://docs.microsoft.com/en-us/windows/desktop/api/wincred/nf-wincred-credunmarshalcredentiala BOOL CredUnmarshalCredentialA(
	// LPCSTR MarshaledCredential, PCRED_MARSHAL_TYPE CredType, PVOID *Credential );
	[DllImport(Lib.AdvApi32, SetLastError = true, CharSet = CharSet.Auto)]
	[PInvokeData("wincred.h", MSDNShortId = "65757235-d92c-479f-8e2b-1f8d8564792b")]
	[return: MarshalAs(UnmanagedType.Bool)]
	public static extern bool CredUnmarshalCredential(string MarshaledCredential, out CRED_MARSHAL_TYPE CredType, out SafeCredMemoryHandle Credential);

	/// <summary>
	/// <para>
	/// The <c>CredUnprotect</c> function decrypts credentials that were previously encrypted by using the CredProtect function. The
	/// credentials must have been encrypted in the same security context in which <c>CredUnprotect</c> is called.
	/// </para>
	/// </summary>
	/// <param name="fAsSelf">
	/// <para>
	/// Set to <c>TRUE</c> to specify that the credentials were encrypted in the security context of the current process. Set to
	/// <c>FALSE</c> to specify that credentials were encrypted in the security context of the calling thread security context.
	/// </para>
	/// </param>
	/// <param name="pszProtectedCredentials">
	/// <para>A pointer to a string that specifies the encrypted credentials.</para>
	/// </param>
	/// <param name="cchProtectedCredentials">
	/// <para>The size, in characters, of the pszProtectedCredentials buffer.</para>
	/// </param>
	/// <param name="pszCredentials">
	/// <para>A pointer to a string that, on output, receives the decrypted credentials.</para>
	/// </param>
	/// <param name="pcchMaxChars">
	/// <para>
	/// The size, in characters of the pszCredentials buffer. On output, if the pszCredentials is not of sufficient size to receive the
	/// encrypted credentials, this parameter specifies the required size, in characters, of the pszCredentials buffer.
	/// </para>
	/// </param>
	/// <returns>
	/// <para><c>TRUE</c> if the function succeeds; otherwise, <c>FALSE</c>.</para>
	/// <para>
	/// For extended error information, call the GetLastError function. The following table shows common values for the
	/// <c>GetLastError</c> function.
	/// </para>
	/// <list type="table">
	/// <listheader>
	/// <term>Return code/value</term>
	/// <term>Description</term>
	/// </listheader>
	/// <item>
	/// <term>ERROR_NOT_CAPABLE</term>
	/// <term>The security context used to encrypt the credentials is different from the security context used to decrypt the credentials.</term>
	/// </item>
	/// <item>
	/// <term>ERROR_INSUFFICIENT_BUFFER</term>
	/// <term>The pszCredentials buffer was of insufficient size.</term>
	/// </item>
	/// </list>
	/// </returns>
	// https://docs.microsoft.com/en-us/windows/desktop/api/wincred/nf-wincred-credunprotecta BOOL CredUnprotectA( BOOL fAsSelf, StrPtrAnsi
	// pszProtectedCredentials, DWORD cchProtectedCredentials, StrPtrAnsi pszCredentials, DWORD *pcchMaxChars );
	[DllImport(Lib.AdvApi32, SetLastError = true, CharSet = CharSet.Auto)]
	[PInvokeData("wincred.h", MSDNShortId = "7a22fb2b-edfc-45f2-b2d2-729f3761584d")]
	[return: MarshalAs(UnmanagedType.Bool)]
	public static extern bool CredUnprotect([MarshalAs(UnmanagedType.Bool)] bool fAsSelf, StringBuilder pszProtectedCredentials, uint cchProtectedCredentials, StringBuilder pszCredentials, ref uint pcchMaxChars);

	/// <summary>
	/// <para>
	/// The <c>CredWrite</c> function creates a new credential or modifies an existing credential in the user's credential set. The new
	/// credential is associated with the logon session of the current token. The token must not have the user's security identifier
	/// (SID) disabled.
	/// </para>
	/// </summary>
	/// <param name="Credential">
	/// <para>A pointer to the CREDENTIAL structure to be written.</para>
	/// </param>
	/// <param name="Flags">
	/// <para>Flags that control the function's operation. The following flag is defined.</para>
	/// <list type="table">
	/// <listheader>
	/// <term>Value</term>
	/// <term>Meaning</term>
	/// </listheader>
	/// <item>
	/// <term>CRED_PRESERVE_CREDENTIAL_BLOB</term>
	/// <term>
	/// The credential BLOB from an existing credential is preserved with the same credential name and credential type. The
	/// CredentialBlobSize of the passed in Credential structure must be zero.
	/// </term>
	/// </item>
	/// </list>
	/// </param>
	/// <returns>
	/// <para>If the function succeeds, the function returns <c>TRUE</c>.</para>
	/// <para>
	/// If the function fails, it returns <c>FALSE</c>. Call the GetLastError function to get a more specific status code. The following
	/// status codes can be returned.
	/// </para>
	/// <para>Other smart card errors can be returned when writing a CRED_TYPE_CERTIFICATE credential.</para>
	/// <list type="table">
	/// <listheader>
	/// <term>Return code/value</term>
	/// <term>Description</term>
	/// </listheader>
	/// <item>
	/// <term>ERROR_NO_SUCH_LOGON_SESSION</term>
	/// <term>
	/// The logon session does not exist or there is no credential set associated with this logon session. Network logon sessions do not
	/// have an associated credential set.
	/// </term>
	/// </item>
	/// <item>
	/// <term>ERROR_INVALID_PARAMETER</term>
	/// <term>
	/// Certain fields cannot be changed in an existing credential. This error is returned if a field does not match the value in a
	/// protected field of the existing credential.
	/// </term>
	/// </item>
	/// <item>
	/// <term>ERROR_INVALID_FLAGS</term>
	/// <term>A value that is not valid was specified for the Flags parameter.</term>
	/// </item>
	/// <item>
	/// <term>ERROR_BAD_USERNAME</term>
	/// <term>
	/// The UserName member of the passed in Credential structure is not valid. For a description of valid user name syntax, see the
	/// definition of that member.
	/// </term>
	/// </item>
	/// <item>
	/// <term>ERROR_NOT_FOUND</term>
	/// <term>CRED_PRESERVE_CREDENTIAL_BLOB was specified and there is no existing credential by the same TargetName and Type.</term>
	/// </item>
	/// <item>
	/// <term>SCARD_E_NO_READERS_AVAILABLE</term>
	/// <term>The CRED_TYPE_CERTIFICATE credential being written requires the smart card reader to be available.</term>
	/// </item>
	/// <item>
	/// <term>SCARD_E_NO_SMARTCARD or SCARD_W_REMOVED_CARD</term>
	/// <term>A CRED_TYPE_CERTIFICATE credential being written requires the smart card to be inserted.</term>
	/// </item>
	/// <item>
	/// <term>SCARD_W_WRONG_CHV</term>
	/// <term>The wrong PIN was supplied for the CRED_TYPE_CERTIFICATE credential being written.</term>
	/// </item>
	/// </list>
	/// </returns>
	/// <remarks>
	/// <para>
	/// This function creates a credential if a credential with the specified <c>TargetName</c> and <c>Type</c> does not exist. If a
	/// credential with the specified <c>TargetName</c> and <c>Type</c> exists, the new specified credential replaces the existing one.
	/// </para>
	/// <para>
	/// When this function writes a CRED_TYPE_CERTIFICATE credential, the Credential-&gt; <c>CredentialBlob</c> member specifies the PIN
	/// protecting the private key of the certificate specified by the Credential-&gt; <c>UserName</c> member. The credential manager
	/// does not maintain the PIN. Rather, the PIN is passed to the cryptographic service provider (CSP) indicated on the certificate for
	/// later use by the CSP and the authentication packages. The CSP defines the lifetime of the PIN. Most CSPs flush the PIN when the
	/// smart card removal from the smart card reader.
	/// </para>
	/// <para>
	/// If the value of the <c>Type</c> member of the CREDENTIAL structure specified by the Credential parameter is
	/// <c>CRED_TYPE_DOMAIN_EXTENDED</c>, a namespace must be specified in the target name. This function does not support writing to
	/// target names that contain wildcards.
	/// </para>
	/// </remarks>
	// https://docs.microsoft.com/en-us/windows/desktop/api/wincred/nf-wincred-credwritea BOOL CredWriteA( PCREDENTIALA Credential, DWORD
	// Flags );
	[DllImport(Lib.AdvApi32, SetLastError = true, CharSet = CharSet.Auto)]
	[PInvokeData("wincred.h", MSDNShortId = "9a590347-d610-4916-bf63-60fbec173ac2")]
	[return: MarshalAs(UnmanagedType.Bool)]
	public static extern bool CredWrite(in CREDENTIAL Credential, CRED_WRITE Flags);

	/// <summary>
	/// <para>
	/// The <c>CredWriteDomainCredentials</c> function writes domain credentials to the user's credential set. The credential set used is
	/// the one associated with the logon session of the current token. The token must not have the user's SID disabled.
	/// </para>
	/// </summary>
	/// <param name="TargetInfo">
	/// <para>
	/// Identifies the target server. At least one of the naming members must be non- <c>NULL</c> and can be <c>NetbiosServerName</c>,
	/// <c>DnsServerName</c>, <c>NetbiosDomainName</c>, <c>DnsDomainName</c>, or <c>DnsTreeName</c>.
	/// </para>
	/// </param>
	/// <param name="Credential">
	/// <para>Credential to be written.</para>
	/// <para>
	/// The credential must be one that matches TargetInfo For instance, if the <c>TargetName</c> is a wildcard DNS name, then the
	/// <c>TargetName</c> member of the credential must be a postfix of the <c>DnsServerName</c> member from the TargetInfo.
	/// </para>
	/// </param>
	/// <param name="Flags">
	/// <para>Flags to control the operation of the API. The following flag is defined.</para>
	/// <list type="table">
	/// <listheader>
	/// <term>Value</term>
	/// <term>Meaning</term>
	/// </listheader>
	/// <item>
	/// <term>CRED_PRESERVE_CREDENTIAL_BLOB</term>
	/// <term>
	/// The credential BLOB should be preserved from the already existing credential with the same credential name and credential type.
	/// The CredentialBlobSize of the passed in Credential structure must be zero.
	/// </term>
	/// </item>
	/// </list>
	/// </param>
	/// <returns>
	/// <para>If the function succeeds, the function returns <c>TRUE</c>.</para>
	/// <para>
	/// If the function fails, it returns <c>FALSE</c>. Call the GetLastError function to get a more specific status code. The following
	/// status codes can be returned.
	/// </para>
	/// <para>Other smart card errors can be returned when writing a CRED_TYPE_CERTIFICATE credential.</para>
	/// <list type="table">
	/// <listheader>
	/// <term>Return code</term>
	/// <term>Description</term>
	/// </listheader>
	/// <item>
	/// <term>ERROR_INVALID_PARAMETER</term>
	/// <term>
	/// One or more of the parameters are not valid. Either none of the naming parameters were specified, or the credential specified did
	/// not have the Type member set to CRED_TYPE_DOMAIN_PASSWORD or CRED_TYPE_DOMAIN_CERTIFICATE, or the Credential does not match the TargetInfo.
	/// </term>
	/// </item>
	/// <item>
	/// <term>ERROR_NO_SUCH_LOGON_SESSION</term>
	/// <term>
	/// The logon session does not exist or there is no credential set associated with this logon session. Network logon sessions do not
	/// have an associated credential set.
	/// </term>
	/// </item>
	/// <item>
	/// <term>ERROR_INVALID_FLAGS</term>
	/// <term>A value that is not valid was specified for the Flags parameter.</term>
	/// </item>
	/// <item>
	/// <term>ERROR_BAD_USERNAME</term>
	/// <term>
	/// The UserName member of the passed in Credential structure is not valid. For a description of valid syntaxes, see the definition
	/// of that member.
	/// </term>
	/// </item>
	/// <item>
	/// <term>ERROR_NOT_FOUND</term>
	/// <term>CRED_PRESERVE_CREDENTIAL_BLOB was specified and there is no existing credential by the same TargetName and Type.</term>
	/// </item>
	/// <item>
	/// <term>SCARD_E_NO_READERS_AVAILABLE</term>
	/// <term>The CRED_TYPE_CERTIFICATE credential being written requires the smart card reader to be available.</term>
	/// </item>
	/// <item>
	/// <term>SCARD_E_NO_SMARTCARD or SCARD_W_REMOVED_CARD: The CRED_TYPE_CERTIFICATE</term>
	/// <term>The credential being written requires the smart card to be inserted.</term>
	/// </item>
	/// <item>
	/// <term>SCARD_W_WRONG_CHV</term>
	/// <term>The wrong PIN was supplied for the CRED_TYPE_CERTIFICATE credential being written.</term>
	/// </item>
	/// </list>
	/// </returns>
	/// <remarks>
	/// <para>
	/// When this function writes a CRED_TYPE_CERTIFICATE credential, the Credential-&gt; <c>CredentialBlob</c> member specifies the PIN
	/// that protects the private key of the certificate specified by the Credential-&gt; <c>UserName</c>. The credential manager does
	/// not maintain the PIN. Rather, the PIN is passed to the CSP of the certificate for later use by the CSP and authentication
	/// packages. The CSP defines the lifetime of the PIN. For instance, most CSPs flush the PIN upon smart card removal.
	/// </para>
	/// <para>
	/// <c>CredWriteDomainCredentials</c> differs from CredWrite in that it handles the idiosyncrasies of domain
	/// (CRED_TYPE_DOMAIN_PASSWORD or CRED_TYPE_DOMAIN_CERTIFICATE) credentials. Domain credentials contain more than one target member.
	/// </para>
	/// <para>
	/// If the value of the <c>Type</c> member of the CREDENTIAL structure specified by the Credential parameter is
	/// <c>CRED_TYPE_DOMAIN_EXTENDED</c>, a namespace must be specified in the target name.
	/// </para>
	/// </remarks>
	// https://docs.microsoft.com/en-us/windows/desktop/api/wincred/nf-wincred-credwritedomaincredentialsa BOOL
	// CredWriteDomainCredentialsA( PCREDENTIAL_TARGET_INFORMATIONA TargetInfo, PCREDENTIALA Credential, DWORD Flags );
	[DllImport(Lib.AdvApi32, SetLastError = true, CharSet = CharSet.Auto)]
	[PInvokeData("wincred.h", MSDNShortId = "6b54c14f-a736-4fb0-b4e4-97765a792a5e")]
	[return: MarshalAs(UnmanagedType.Bool)]
	public static extern bool CredWriteDomainCredentials(in CREDENTIAL_TARGET_INFORMATION TargetInfo, in CREDENTIAL Credential, CRED_WRITE Flags);

	/// <summary>Undocumented.</summary>
	[PInvokeData("wincred.h", MSDNShortId = "20a1d54b-04a7-4b0a-88e4-1970d1f71502")]
	[StructLayout(LayoutKind.Sequential)]
	public struct BINARY_BLOB_CREDENTIAL_INFO
	{
		/// <summary>Undocumented.</summary>
		public uint cbBlob;

		/// <summary>Undocumented.</summary>
		public IntPtr pbBlob;
	}

	/// <summary>
	/// <para>The <c>CERT_CREDENTIAL_INFO</c> structure contains a reference to a certificate.</para>
	/// </summary>
	/// <remarks>
	/// <para><c>CERT_HASH_LENGTH</c> is defined as 20 in WinCred.h.</para>
	/// </remarks>
	// https://docs.microsoft.com/en-us/windows/desktop/api/wincred/ns-wincred-_cert_credential_info typedef struct _CERT_CREDENTIAL_INFO
	// { ULONG cbSize; UCHAR rgbHashOfCert[CERT_HASH_LENGTH]; } CERT_CREDENTIAL_INFO, *PCERT_CREDENTIAL_INFO;
	[PInvokeData("wincred.h", MSDNShortId = "acaa94c3-0562-420a-95c7-44a71374d5ea")]
	[StructLayout(LayoutKind.Sequential)]
	public struct CERT_CREDENTIAL_INFO
	{
		/// <summary>
		/// <para>
		/// Size of the structure in bytes. This member should be set to . This structure might be a larger value in the future,
		/// indicating a newer version of the structure.
		/// </para>
		/// </summary>
		public uint cbSize;

		/// <summary>
		/// <para>SHA-1 hash of the certificate referenced.</para>
		/// </summary>
		[MarshalAs(UnmanagedType.ByValArray, SizeConst = 20)]
		public byte[] rgbHashOfCert;
	}

	/// <summary>The CREDENTIAL structure contains an individual credential.</summary>
	[StructLayout(LayoutKind.Sequential, CharSet = CharSet.Auto)]
	[PInvokeData("wincred.h")]
	public struct CREDENTIAL
	{
		/// <summary>The flags</summary>
		public CRED_FLAGS Flags;

		/// <summary>The type of the credential. This member cannot be changed after the credential is created.</summary>
		public CRED_TYPE Type;

		/// <summary>
		/// The name of the credential. The TargetName and Type members uniquely identify the credential. This member cannot be changed
		/// after the credential is created. Instead, the credential with the old name should be deleted and the credential with the new
		/// name created.
		/// <para>
		/// If Type is CRED_TYPE_DOMAIN_PASSWORD or CRED_TYPE_DOMAIN_CERTIFICATE, this member identifies the server or servers that the
		/// credential is to be used for. The member is either a NetBIOS or DNS server name, a DNS host name suffix that contains a
		/// wildcard character, a NetBIOS or DNS domain name that contains a wildcard character sequence, or an asterisk.
		/// </para>
		/// <para>If TargetName is a DNS host name, the TargetAlias member can be the NetBIOS name of the host.</para>
		/// <para>
		/// If the TargetName is a DNS host name suffix that contains a wildcard character, the leftmost label of the DNS host name is an
		/// asterisk (*), which denotes that the target name is any server whose name ends in the specified name, for example, *.microsoft.com.
		/// </para>
		/// <para>
		/// If the TargetName is a domain name that contains a wildcard character sequence, the syntax is the domain name followed by a
		/// backslash and asterisk (\*), which denotes that the target name is any server that is a member of the named domain (or realm).
		/// </para>
		/// <para>
		/// If TargetName is a DNS domain name that contains a wildcard character sequence, the TargetAlias member can be a NetBIOS
		/// domain name that uses a wildcard sequence for the same domain.
		/// </para>
		/// <para>
		/// If TargetName specifies a DFS share, for example, DfsRoot\DfsShare, then this credential matches the specific DFS share and
		/// any servers reached through that DFS share.
		/// </para>
		/// <para>If TargetName is a single asterisk (*), this credential matches any server name.</para>
		/// <para>
		/// If TargetName is CRED_SESSION_WILDCARD_NAME, this credential matches any server name. This credential matches before a single
		/// asterisk and is only valid if Persist is CRED_PERSIST_SESSION. The credential can be set by applications that want to
		/// temporarily override the default credential.
		/// </para>
		/// <para>This member cannot be longer than CRED_MAX_DOMAIN_TARGET_NAME_LENGTH (337) characters.</para>
		/// <para>
		/// If the Type is CRED_TYPE_GENERIC, this member should identify the service that uses the credential in addition to the actual
		/// target. Microsoft suggests the name be prefixed by the name of the company implementing the service. Microsoft will use the
		/// prefix "Microsoft". Services written by Microsoft should append their service name, for example Microsoft_RAS_TargetName.
		/// This member cannot be longer than CRED_MAX_GENERIC_TARGET_NAME_LENGTH (32767) characters.
		/// </para>
		/// <para>This member is case-insensitive.</para>
		/// </summary>
		public StrPtrAuto TargetName;

		/// <summary>
		/// A string comment from the user that describes this credential. This member cannot be longer than CRED_MAX_STRING_LENGTH (256) characters.
		/// </summary>
		public StrPtrAuto Comment;

		/// <summary>
		/// The time, in Coordinated Universal Time (Greenwich Mean Time), of the last modification of the credential. For write
		/// operations, the value of this member is ignored.
		/// </summary>
		public FILETIME LastWritten;

		/// <summary>
		/// The size, in bytes, of the CredentialBlob member. This member cannot be larger than CRED_MAX_CREDENTIAL_BLOB_SIZE (512) bytes.
		/// </summary>
		public uint CredentialBlobSize;

		/// <summary>
		/// Secret data for the credential. The CredentialBlob member can be both read and written.
		/// <para>
		/// If the Type member is CRED_TYPE_DOMAIN_PASSWORD, this member contains the plaintext Unicode password for UserName. The
		/// CredentialBlob and CredentialBlobSize members do not include a trailing zero character. Also, for CRED_TYPE_DOMAIN_PASSWORD,
		/// this member can only be read by the authentication packages.
		/// </para>
		/// <para>
		/// If the Type member is CRED_TYPE_DOMAIN_CERTIFICATE, this member contains the clear test Unicode PIN for UserName. The
		/// CredentialBlob and CredentialBlobSize members do not include a trailing zero character. Also, this member can only be read by
		/// the authentication packages.
		/// </para>
		/// <para>If the Type member is CRED_TYPE_GENERIC, this member is defined by the application.</para>
		/// <para>
		/// Credentials are expected to be portable. Applications should ensure that the data in CredentialBlob is portable. The
		/// application defines the byte-endian and alignment of the data in CredentialBlob.
		/// </para>
		/// </summary>
		public IntPtr CredentialBlob;

		/// <summary>
		/// Defines the persistence of this credential. This member can be read and written.
		/// <list type="table">
		/// <listheader>
		/// <term>Value</term>
		/// <term>Meaning</term>
		/// </listheader>
		/// <item>
		/// <term>CRED_PERSIST_SESSION (0x1)</term>
		/// <description>
		/// The credential persists for the life of the logon session. It will not be visible to other logon sessions of this same user.
		/// It will not exist after this user logs off and back on.
		/// </description>
		/// </item>
		/// <item>
		/// <term>CRED_PERSIST_LOCAL_MACHINE (0x2)</term>
		/// <description>
		/// The credential persists for all subsequent logon sessions on this same computer. It is visible to other logon sessions of
		/// this same user on this same computer and not visible to logon sessions for this user on other computers.
		/// <para>
		/// <c>Windows Vista Home Basic, Windows Vista Home Premium, Windows Vista Starter and Windows XP Home Edition:</c> This value is
		/// not supported.
		/// </para>
		/// </description>
		/// </item>
		/// <item>
		/// <term>CRED_PERSIST_ENTERPRISE (0x3)</term>
		/// <description>
		/// The credential persists for all subsequent logon sessions on this same computer. It is visible to other logon sessions of
		/// this same user on this same computer and to logon sessions for this user on other computers.
		/// <para>
		/// This option can be implemented as locally persisted credential if the administrator or user configures the user account to
		/// not have roam-able state. For instance, if the user has no roaming profile, the credential will only persist locally.
		/// </para>
		/// <para>
		/// <c>Windows Vista Home Basic, Windows Vista Home Premium, Windows Vista Starter and Windows XP Home Edition:</c> This value is
		/// not supported.
		/// </para>
		/// </description>
		/// </item>
		/// </list>
		/// </summary>
		public CRED_PERSIST Persist;

		/// <summary>
		/// The number of application-defined attributes to be associated with the credential. This member can be read and written. Its
		/// value cannot be greater than CRED_MAX_ATTRIBUTES (64).
		/// </summary>
		public uint AttributeCount;

		/// <summary>Application-defined attributes that are associated with the credential. This member can be read and written.</summary>
		public IntPtr Attributes;

		/// <summary>
		/// Alias for the TargetName member. This member can be read and written. It cannot be longer than CRED_MAX_STRING_LENGTH (256) characters.
		/// <para>If the credential Type is CRED_TYPE_GENERIC, this member can be non-NULL, but the credential manager ignores the member.</para>
		/// </summary>
		public StrPtrAuto TargetAlias;

		/// <summary>
		/// The user name of the account used to connect to TargetName.
		/// <para>If the credential Type is CRED_TYPE_DOMAIN_PASSWORD, this member can be either a DomainName\UserName or a UPN.</para>
		/// <para>
		/// If the credential Type is CRED_TYPE_DOMAIN_CERTIFICATE, this member must be a marshaled certificate reference created by
		/// calling CredMarshalCredential with a CertCredential.
		/// </para>
		/// <para>If the credential Type is CRED_TYPE_GENERIC, this member can be non-NULL, but the credential manager ignores the member.</para>
		/// <para>This member cannot be longer than CRED_MAX_USERNAME_LENGTH (513) characters.</para>
		/// </summary>
		public StrPtrAuto UserName;
	}

	/// <summary>The CREDENTIAL structure contains an individual credential.</summary>
	[PInvokeData("wincred.h")]
	public struct CREDENTIAL_MGD
	{
		/// <summary>
		/// The number of application-defined attributes to be associated with the credential. This member can be read and written. Its
		/// value cannot be greater than CRED_MAX_ATTRIBUTES (64).
		/// </summary>
		public uint AttributeCount;

		/// <summary>Application-defined attributes that are associated with the credential. This member can be read and written.</summary>
		public byte[]? Attributes;

		/// <summary>
		/// A string comment from the user that describes this credential. This member cannot be longer than CRED_MAX_STRING_LENGTH (256) characters.
		/// </summary>
		public string Comment;

		/// <summary>
		/// Secret data for the credential. The CredentialBlob member can be both read and written.
		/// <para>
		/// If the Type member is CRED_TYPE_DOMAIN_PASSWORD, this member contains the plaintext Unicode password for UserName. The
		/// CredentialBlob and CredentialBlobSize members do not include a trailing zero character. Also, for CRED_TYPE_DOMAIN_PASSWORD,
		/// this member can only be read by the authentication packages.
		/// </para>
		/// <para>
		/// If the Type member is CRED_TYPE_DOMAIN_CERTIFICATE, this member contains the clear test Unicode PIN for UserName. The
		/// CredentialBlob and CredentialBlobSize members do not include a trailing zero character. Also, this member can only be read by
		/// the authentication packages.
		/// </para>
		/// <para>If the Type member is CRED_TYPE_GENERIC, this member is defined by the application.</para>
		/// <para>
		/// Credentials are expected to be portable. Applications should ensure that the data in CredentialBlob is portable. The
		/// application defines the byte-endian and alignment of the data in CredentialBlob.
		/// </para>
		/// </summary>
		public byte[]? CredentialBlob;

		/// <summary>The flags</summary>
		public CRED_FLAGS Flags;

		/// <summary>
		/// The time, in Coordinated Universal Time (Greenwich Mean Time), of the last modification of the credential. For write
		/// operations, the value of this member is ignored.
		/// </summary>
		public FILETIME LastWritten;

		/// <summary>
		/// Defines the persistence of this credential. This member can be read and written.
		/// <list type="table">
		/// <listheader>
		/// <term>Value</term>
		/// <term>Meaning</term>
		/// </listheader>
		/// <item>
		/// <term>CRED_PERSIST_SESSION (0x1)</term>
		/// <description>
		/// The credential persists for the life of the logon session. It will not be visible to other logon sessions of this same user.
		/// It will not exist after this user logs off and back on.
		/// </description>
		/// </item>
		/// <item>
		/// <term>CRED_PERSIST_LOCAL_MACHINE (0x2)</term>
		/// <description>
		/// The credential persists for all subsequent logon sessions on this same computer. It is visible to other logon sessions of
		/// this same user on this same computer and not visible to logon sessions for this user on other computers.
		/// <para>
		/// <c>Windows Vista Home Basic, Windows Vista Home Premium, Windows Vista Starter and Windows XP Home Edition:</c> This value is
		/// not supported.
		/// </para>
		/// </description>
		/// </item>
		/// <item>
		/// <term>CRED_PERSIST_ENTERPRISE (0x3)</term>
		/// <description>
		/// The credential persists for all subsequent logon sessions on this same computer. It is visible to other logon sessions of
		/// this same user on this same computer and to logon sessions for this user on other computers.
		/// <para>
		/// This option can be implemented as locally persisted credential if the administrator or user configures the user account to
		/// not have roam-able state. For instance, if the user has no roaming profile, the credential will only persist locally.
		/// </para>
		/// <para>
		/// <c>Windows Vista Home Basic, Windows Vista Home Premium, Windows Vista Starter and Windows XP Home Edition:</c> This value is
		/// not supported.
		/// </para>
		/// </description>
		/// </item>
		/// </list>
		/// </summary>
		public CRED_PERSIST Persist;

		/// <summary>
		/// Alias for the TargetName member. This member can be read and written. It cannot be longer than CRED_MAX_STRING_LENGTH (256) characters.
		/// <para>If the credential Type is CRED_TYPE_GENERIC, this member can be non-NULL, but the credential manager ignores the member.</para>
		/// </summary>
		public string? TargetAlias;

		/// <summary>
		/// The name of the credential. The TargetName and Type members uniquely identify the credential. This member cannot be changed
		/// after the credential is created. Instead, the credential with the old name should be deleted and the credential with the new
		/// name created.
		/// <para>
		/// If Type is CRED_TYPE_DOMAIN_PASSWORD or CRED_TYPE_DOMAIN_CERTIFICATE, this member identifies the server or servers that the
		/// credential is to be used for. The member is either a NetBIOS or DNS server name, a DNS host name suffix that contains a
		/// wildcard character, a NetBIOS or DNS domain name that contains a wildcard character sequence, or an asterisk.
		/// </para>
		/// <para>If TargetName is a DNS host name, the TargetAlias member can be the NetBIOS name of the host.</para>
		/// <para>
		/// If the TargetName is a DNS host name suffix that contains a wildcard character, the leftmost label of the DNS host name is an
		/// asterisk (*), which denotes that the target name is any server whose name ends in the specified name, for example, *.microsoft.com.
		/// </para>
		/// <para>
		/// If the TargetName is a domain name that contains a wildcard character sequence, the syntax is the domain name followed by a
		/// backslash and asterisk (\*), which denotes that the target name is any server that is a member of the named domain (or realm).
		/// </para>
		/// <para>
		/// If TargetName is a DNS domain name that contains a wildcard character sequence, the TargetAlias member can be a NetBIOS
		/// domain name that uses a wildcard sequence for the same domain.
		/// </para>
		/// <para>
		/// If TargetName specifies a DFS share, for example, DfsRoot\DfsShare, then this credential matches the specific DFS share and
		/// any servers reached through that DFS share.
		/// </para>
		/// <para>If TargetName is a single asterisk (*), this credential matches any server name.</para>
		/// <para>
		/// If TargetName is CRED_SESSION_WILDCARD_NAME, this credential matches any server name. This credential matches before a single
		/// asterisk and is only valid if Persist is CRED_PERSIST_SESSION. The credential can be set by applications that want to
		/// temporarily override the default credential.
		/// </para>
		/// <para>This member cannot be longer than CRED_MAX_DOMAIN_TARGET_NAME_LENGTH (337) characters.</para>
		/// <para>
		/// If the Type is CRED_TYPE_GENERIC, this member should identify the service that uses the credential in addition to the actual
		/// target. Microsoft suggests the name be prefixed by the name of the company implementing the service. Microsoft will use the
		/// prefix "Microsoft". Services written by Microsoft should append their service name, for example Microsoft_RAS_TargetName.
		/// This member cannot be longer than CRED_MAX_GENERIC_TARGET_NAME_LENGTH (32767) characters.
		/// </para>
		/// <para>This member is case-insensitive.</para>
		/// </summary>
		public string TargetName;

		/// <summary>The type of the credential. This member cannot be changed after the credential is created.</summary>
		public CRED_TYPE Type;

		/// <summary>
		/// The user name of the account used to connect to TargetName.
		/// <para>If the credential Type is CRED_TYPE_DOMAIN_PASSWORD, this member can be either a DomainName\UserName or a UPN.</para>
		/// <para>
		/// If the credential Type is CRED_TYPE_DOMAIN_CERTIFICATE, this member must be a marshaled certificate reference created by
		/// calling CredMarshalCredential with a CertCredential.
		/// </para>
		/// <para>If the credential Type is CRED_TYPE_GENERIC, this member can be non-NULL, but the credential manager ignores the member.</para>
		/// <para>This member cannot be longer than CRED_MAX_USERNAME_LENGTH (513) characters.</para>
		/// </summary>
		public string? UserName;

		/// <summary>Initializes a new instance of the <see cref="CREDENTIAL_MGD"/> struct.</summary>
		/// <param name="c">The c.</param>
		internal CREDENTIAL_MGD(in CREDENTIAL c)
		{
			Flags = c.Flags;
			Type = c.Type;
			TargetName = c.TargetName.ToString();
			Comment = c.Comment.ToString();
			LastWritten = c.LastWritten;
			CredentialBlob = c.CredentialBlob.ToByteArray((int)c.CredentialBlobSize);
			Persist = c.Persist;
			AttributeCount = c.AttributeCount;
			Attributes = c.Attributes.ToByteArray((int)c.AttributeCount);
			TargetAlias = c.TargetAlias;
			UserName = c.UserName;
		}
	}

	/// <summary>
	/// <para>The <c>CREDENTIAL_TARGET_INFORMATION</c> structure contains the target computer's name, domain, and tree.</para>
	/// </summary>
	// https://docs.microsoft.com/en-us/windows/desktop/api/wincred/ns-wincred-_credential_target_informationa typedef struct
	// _CREDENTIAL_TARGET_INFORMATIONA { StrPtrAnsi TargetName; StrPtrAnsi NetbiosServerName; StrPtrAnsi DnsServerName; StrPtrAnsi NetbiosDomainName; StrPtrAnsi
	// DnsDomainName; StrPtrAnsi DnsTreeName; StrPtrAnsi PackageName; ULONG Flags; DWORD CredTypeCount; LPDWORD CredTypes; }
	// CREDENTIAL_TARGET_INFORMATIONA, *PCREDENTIAL_TARGET_INFORMATIONA;
	[PInvokeData("wincred.h", MSDNShortId = "92180f2c-ef7c-4481-9b6f-19234c114afb")]
	[StructLayout(LayoutKind.Sequential, CharSet = CharSet.Auto)]
	public struct CREDENTIAL_TARGET_INFORMATION
	{
		/// <summary>
		/// Name of the target server as specified by the caller accessing the target. It is typically the NetBIOS or DNS name of the
		/// target server.
		/// </summary>
		public string TargetName;

		/// <summary>NetBIOS name of the target server. If the name is not known, this member can be NULL.</summary>
		public string? NetbiosServerName;

		/// <summary>DNS name of the target server. If the name is not known, this member can be NULL.</summary>
		public string? DnsServerName;

		/// <summary>
		/// NetBIOS name of the target server's domain. If the name is not known, this member can be NULL. If the target server is a
		/// member of a workgroup, this member must be NULL.
		/// </summary>
		public string? NetbiosDomainName;

		/// <summary>
		/// DNS name of the target server's domain. If the name is not known, this member can be NULL. If the target server is a member
		/// of a workgroup, this member must be NULL.
		/// </summary>
		public string? DnsDomainName;

		/// <summary>
		/// DNS name of the target server's tree. If the tree name is not known, this member can be NULL. If the target server is a
		/// member of a workgroup, this member must be NULL.
		/// </summary>
		public string? DnsTreeName;

		/// <summary>
		/// Name of the authentication package that determined the values NetbiosServerName, DnsServerName, NetbiosDomainName,
		/// DnsDomainName, and DnsTreeName as a function of TargetName. This member can be passed to AcquireCredentialsHandle as the
		/// package name.
		/// </summary>
		public string PackageName;

		/// <summary>
		/// Attributes of the target.
		/// <list type="bullet">
		/// <item>
		/// <term>CRED_TI_SERVER_FORMAT_UNKNOWN (0x1)</term>
		/// <description>
		/// Set if the authentication package cannot determine whether the server name is a DNS name or a NetBIOS name. In that case, the
		/// NetbiosServerName member is set to NULL and the DnsServerName member is set to the server name of unknown format.
		/// </description>
		/// </item>
		/// <item>
		/// <term>CRED_TI_DOMAIN_FORMAT_UNKNOWN (0x2)</term>
		/// <description>
		/// Set if the authentication package cannot determine whether the domain name is a DNS name or a NetBIOS name. In that case, the
		/// NetbiosDomainName member is set to NULL and the DnsDomainName member is set to the domain name of unknown format.
		/// </description>
		/// </item>
		/// <item>
		/// <term>CRED_TI_ONLY_PASSWORD_REQUIRED (0x4)</term>
		/// <description>
		/// Set if the authentication package has determined that the server only needs a password to authenticate. The caller can use
		/// this flag to prompt only for a password and not a user name.
		/// </description>
		/// </item>
		/// </list>
		/// <para>
		/// Stored credentials require a UserName member. A value of &lt;DnsServerName&gt;\Guest or &lt;NetbiosServerName&gt;\Guest
		/// should be used for these servers.
		/// </para>
		/// </summary>
		public CRED_TI Flags;

		/// <summary>Number of elements in the CredTypes array.</summary>
		public uint CredTypeCount;

		/// <summary>
		/// Array specifying the credential types acceptable by the authentication package used by the target server. Each element is one
		/// of the CRED_TYPE_* defines. The order of this array specifies the preference order of the authentication package. More
		/// preferable types are specified earlier in the list.
		/// </summary>
		public IntPtr CredTypes;

		/// <summary>Extracts array of <see cref="CRED_TYPE"/> values from <see cref="CredTypes"/>.</summary>
		public CRED_TYPE[] GetCredTypes() => CredTypes.ToArray<CRED_TYPE>((int)CredTypeCount) ?? new CRED_TYPE[0];
	}

	/// <summary>
	/// <para>
	/// The <c>USERNAME_TARGET_CREDENTIAL_INFO</c> structure contains a reference to a credential. This structure is used to pass a user
	/// name into the CredMarshalCredential function and out of the CredUnmarshalCredential. The resultant marshaled credential can be
	/// passed as the lpszUserName parameter of the LogonUser function to direct that API to get the password from the corresponding
	/// CRED_FLAGS_USERNAME_TARGET credential instead of from the lpszPassword parameter of the function.
	/// </para>
	/// </summary>
	// https://docs.microsoft.com/en-us/windows/desktop/api/wincred/ns-wincred-_username_target_credential_info typedef struct
	// _USERNAME_TARGET_CREDENTIAL_INFO { StrPtrUni UserName; } USERNAME_TARGET_CREDENTIAL_INFO, *PUSERNAME_TARGET_CREDENTIAL_INFO;
	[PInvokeData("wincred.h", MSDNShortId = "1cb56a85-fafd-4471-b0e9-660ac0dc0219")]
	[StructLayout(LayoutKind.Sequential, CharSet = CharSet.Unicode)]
	public struct USERNAME_TARGET_CREDENTIAL_INFO
	{
		/// <summary>
		/// <para>User name of the USERNAME_TARGET_CREDENTIAL_INFO credential.</para>
		/// </summary>
		public string UserName;
	}

	/// <summary>Safe handle for WinCred functions.</summary>
	public class SafeCredMemoryHandle : GenericSafeHandle
	{
		/// <summary>Initializes a new instance of the <see cref="SafeCredMemoryHandle"/> class.</summary>
		public SafeCredMemoryHandle() : this(IntPtr.Zero) { }

		/// <summary>Initializes a new instance of the <see cref="SafeCredMemoryHandle"/> class.</summary>
		/// <param name="ptr">The pointer to the memory allocated by an WinCred function.</param>
		/// <param name="own">if set to <c>true</c> release the memory when out of scope.</param>
		public SafeCredMemoryHandle(IntPtr ptr, bool own = true) : base(ptr, h => { CredFree(h); return true; }, own) { }

		/// <summary>Performs an implicit conversion from <see cref="SafeCredMemoryHandle"/> to <see cref="CREDENTIAL"/>.</summary>
		/// <param name="h">The handle.</param>
		/// <returns>The resulting <see cref="CREDENTIAL"/> instance from the conversion.</returns>
		public static implicit operator CREDENTIAL(SafeCredMemoryHandle h) => h.ToStructure<CREDENTIAL>();

		/// <summary>Performs an implicit conversion from <see cref="SafeCredMemoryHandle"/> to <see cref="CREDENTIAL_MGD"/>.</summary>
		/// <param name="h">The handle.</param>
		/// <returns>The resulting <see cref="CREDENTIAL_MGD"/> instance from the conversion.</returns>
		public static implicit operator CREDENTIAL_MGD(SafeCredMemoryHandle h) => new(h.ToStructure<CREDENTIAL>());

		/// <summary>Performs an implicit conversion from <see cref="SafeCredMemoryHandle"/> to <see cref="CREDENTIAL_TARGET_INFORMATION"/>.</summary>
		/// <param name="h">The handle.</param>
		/// <returns>The resulting <see cref="CREDENTIAL_TARGET_INFORMATION"/> instance from the conversion.</returns>
		public static implicit operator CREDENTIAL_TARGET_INFORMATION(SafeCredMemoryHandle h) => h.ToStructure<CREDENTIAL_TARGET_INFORMATION>();

		/// <summary>Performs an implicit conversion from <see cref="SafeCredMemoryHandle"/> to <see cref="System.String"/>.</summary>
		/// <param name="h">The handle.</param>
		/// <returns>The resulting <see cref="System.String"/> instance from the conversion.</returns>
		public static implicit operator string?(SafeCredMemoryHandle h) => Marshal.PtrToStringAuto(h.handle);

		/// <summary>Marshals data to the type specified by a generic type parameter.</summary>
		/// <typeparam name="T">The type of the object to which the data is to be copied. This must be a structure.</typeparam>
		/// <returns>A managed object that contains the data of type <typeparamref name="T"/>.</returns>
		/// <exception cref="InsufficientMemoryException"></exception>
		public T ToStructure<T>() where T : struct => handle.ToStructure<T>();

		internal CREDENTIAL_MGD[] GetCredArray(int count) => this.ToIEnum<IntPtr>(count).Select(p => new CREDENTIAL_MGD(p.ToStructure<CREDENTIAL>())).ToArray();
	}
}