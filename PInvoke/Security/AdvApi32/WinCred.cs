using System;
using System.Runtime.InteropServices;
using Vanara.Extensions;
using Vanara.InteropServices;
using FILETIME = System.Runtime.InteropServices.ComTypes.FILETIME;

namespace Vanara.PInvoke
{
	public static partial class AdvApi32
	{
		/// <summary>Type of credential used by CREDENTIAL structure.</summary>
		public enum CredentialType
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
			CRED_TYPE_DOMAIN_EXTENDED = 6
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
		public static extern bool CredReadDomainCredentials(ref CREDENTIAL_TARGET_INFORMATION TargetInfo, uint Flags, out uint Count, out SafeCredMemoryHandle Credential);

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
		public static extern bool CredWriteDomainCredentials(ref CREDENTIAL_TARGET_INFORMATION TargetInfo, ref CREDENTIAL Credential, uint Flags);

		/// <summary>The CREDENTIAL structure contains an individual credential.</summary>
		[StructLayout(LayoutKind.Sequential, CharSet = CharSet.Auto)]
		[PInvokeData("wincred.h")]
		public struct CREDENTIAL
		{
			/// <summary>The flags</summary>
			public uint Flags;

			/// <summary>The type of the credential. This member cannot be changed after the credential is created.</summary>
			public CredentialType Type;

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

			/// <summary>
			/// A string comment from the user that describes this credential. This member cannot be longer than CRED_MAX_STRING_LENGTH (256) characters.
			/// </summary>
			public string Comment;

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
			public uint Persist;

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
			public string TargetAlias;

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
			public string UserName;
		}

		/// <summary>
		/// <para>The <c>CREDENTIAL_TARGET_INFORMATION</c> structure contains the target computer's name, domain, and tree.</para>
		/// </summary>
		// https://docs.microsoft.com/en-us/windows/desktop/api/wincred/ns-wincred-_credential_target_informationa typedef struct
		// _CREDENTIAL_TARGET_INFORMATIONA { LPSTR TargetName; LPSTR NetbiosServerName; LPSTR DnsServerName; LPSTR NetbiosDomainName; LPSTR
		// DnsDomainName; LPSTR DnsTreeName; LPSTR PackageName; ULONG Flags; DWORD CredTypeCount; LPDWORD CredTypes; }
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
			public string NetbiosServerName;

			/// <summary>DNS name of the target server. If the name is not known, this member can be NULL.</summary>
			public string DnsServerName;

			/// <summary>
			/// NetBIOS name of the target server's domain. If the name is not known, this member can be NULL. If the target server is a
			/// member of a workgroup, this member must be NULL.
			/// </summary>
			public string NetbiosDomainName;

			/// <summary>
			/// DNS name of the target server's domain. If the name is not known, this member can be NULL. If the target server is a member
			/// of a workgroup, this member must be NULL.
			/// </summary>
			public string DnsDomainName;

			/// <summary>
			/// DNS name of the target server's tree. If the tree name is not known, this member can be NULL. If the target server is a
			/// member of a workgroup, this member must be NULL.
			/// </summary>
			public string DnsTreeName;

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
			public uint Flags;

			/// <summary>Number of elements in the CredTypes array.</summary>
			public uint CredTypeCount;

			/// <summary>
			/// Array specifying the credential types acceptable by the authentication package used by the target server. Each element is one
			/// of the CRED_TYPE_* defines. The order of this array specifies the preference order of the authentication package. More
			/// preferable types are specified earlier in the list.
			/// </summary>
			public IntPtr CredTypes;

			/// <summary>Extracts array of <see cref="CredentialType"/> values from <see cref="CredTypes"/>.</summary>
			public CredentialType[] GetCredTypes() => CredTypes.ToArray<CredentialType>((int)CredTypeCount);
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
		}
	}
}