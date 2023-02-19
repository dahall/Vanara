using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using Vanara.Extensions;
using Vanara.InteropServices;
using static Vanara.PInvoke.AdvApi32;
using static Vanara.PInvoke.Crypt32;
using static Vanara.PInvoke.Schannel;
using TimeStamp = System.Runtime.InteropServices.ComTypes.FILETIME;

namespace Vanara.PInvoke
{
	/// <summary>Functions and definitions from Secur32.dll</summary>
	public static partial class Secur32
	{
		/// <summary>Undocumented.</summary>
		/// <param name="Arg">Argument passed in</param>
		/// <param name="Principal">Principal ID</param>
		/// <param name="KeyVer">Key Version</param>
		/// <param name="Key">Returned ptr to key.</param>
		/// <param name="Status">returned status.</param>
		[PInvokeData("sspi.h")]
		[UnmanagedFunctionPointer(CallingConvention.Winapi)]
		public delegate void SEC_GET_KEY_FN(IntPtr Arg, IntPtr Principal, uint KeyVer, out IntPtr Key, out int Status);

		/// <summary>Bit flags that specify the attributes required by the server to establish the context.</summary>
		[PInvokeData("sspi.h", MSDNShortId = "a53f733e-b646-4431-b021-a2c446308849")]
		[Flags]
		public enum ASC_REQ : uint
		{
			/// <summary>The server is allowed to impersonate the client. Ignore this flag for constrained delegation.</summary>
			ASC_REQ_DELEGATE = 0x00000001,

			/// <summary>The mutual authentication policy of the service will be satisfied.</summary>
			ASC_REQ_MUTUAL_AUTH = 0x00000002,

			/// <summary>Detect replayed packets.</summary>
			ASC_REQ_REPLAY_DETECT = 0x00000004,

			/// <summary>Detect messages received out of sequence.</summary>
			ASC_REQ_SEQUENCE_DETECT = 0x00000008,

			/// <summary>Encrypt messages by using the EncryptMessage function.</summary>
			ASC_REQ_CONFIDENTIALITY = 0x00000010,

			/// <summary>A new session key must be negotiated. This value is supported only by the Kerberos security package.</summary>
			ASC_REQ_USE_SESSION_KEY = 0x00000020,

			/// <summary/>
			ASC_REQ_SESSION_TICKET = 0x00000040,

			/// <summary>
			/// Credential Security Support Provider (CredSSP) will allocate output buffers. When you have finished using the output buffers,
			/// free them by calling the FreeContextBuffer function.
			/// </summary>
			ASC_REQ_ALLOCATE_MEMORY = 0x00000100,

			/// <summary/>
			ASC_REQ_USE_DCE_STYLE = 0x00000200,
			/// <summary/>
			ASC_REQ_DATAGRAM = 0x00000400,

			/// <summary>The security context will not handle formatting messages.</summary>
			ASC_REQ_CONNECTION = 0x00000800,

			/// <summary/>
			ASC_REQ_CALL_LEVEL = 0x00001000,
			/// <summary/>
			ASC_REQ_FRAGMENT_SUPPLIED = 0x00002000,

			/// <summary>When errors occur, the remote party will be notified.</summary>
			ASC_REQ_EXTENDED_ERROR = 0x00008000,

			/// <summary>Support a stream-oriented connection.</summary>
			ASC_REQ_STREAM = 0x00010000,

			/// <summary>Sign messages and verify signatures by using the EncryptMessage and MakeSignature functions.</summary>
			ASC_REQ_INTEGRITY = 0x00020000,

			/// <summary/>
			ASC_REQ_LICENSING = 0x00040000,
			/// <summary/>
			ASC_REQ_IDENTIFY = 0x00080000,
			/// <summary/>
			ASC_REQ_ALLOW_NULL_SESSION = 0x00100000,
			/// <summary/>
			ASC_REQ_ALLOW_NON_USER_LOGONS = 0x00200000,
			/// <summary/>
			ASC_REQ_ALLOW_CONTEXT_REPLAY = 0x00400000,
			/// <summary/>
			ASC_REQ_FRAGMENT_TO_FIT = 0x00800000,
			/// <summary/>
			ASC_REQ_NO_TOKEN = 0x01000000,
			/// <summary/>
			ASC_REQ_PROXY_BINDINGS = 0x04000000,
			/// <summary/>
			ASC_REQ_ALLOW_MISSING_BINDINGS = 0x10000000,
		}

		/// <summary>A set of bit flags that indicate the attributes of the established context.</summary>
		[PInvokeData("sspi.h", MSDNShortId = "a53f733e-b646-4431-b021-a2c446308849")]
		[Flags]
		public enum ASC_RET : uint
		{
			/// <summary>
			/// The server in the transport application can build new security contexts impersonating the client that will be accepted by
			/// other servers as the client's contexts. Delegate works only if MUTUAL_AUTH is set. DELEGATE is currently supported only by
			/// Kerberos. Further, Kerberos will delegate only to a server that has the flag TRUSTED_FOR_DELEGATION. Do not use this flag for
			/// constrained delegation.
			/// </summary>
			ASC_RET_DELEGATE = 0x00000001,

			/// <summary>
			/// The communicating parties must authenticate their identities to each other. Without MUTUAL_AUTH, the client authenticates its
			/// identity to the server. With MUTUAL_AUTH, the server also must authenticate its identity to the client.
			/// <para>
			/// When using the Schannel security package, the server sets the ASC_RET_MUTUAL_AUTH constant only in the last call to
			/// AcceptSecurityContext(Negotiate), after certificate mapping has successfully completed.
			/// </para>
			/// </summary>
			ASC_RET_MUTUAL_AUTH = 0x00000002,

			/// <summary>
			/// The security package detects replayed packets and notifies the caller if a packet has been replayed. The use of this flag
			/// implies all of the conditions specified by the INTEGRITY flag.
			/// </summary>
			ASC_RET_REPLAY_DETECT = 0x00000004,

			/// <summary>
			/// The context must be allowed to detect out-of-order delivery of packets later through the message support functions. Use of
			/// this flag implies all of the conditions specified by the INTEGRITY flag.
			/// </summary>
			ASC_RET_SEQUENCE_DETECT = 0x00000008,

			/// <summary>
			/// The context can protect data while in transit using the EncryptMessage (General) and DecryptMessage (General) functions. The
			/// CONFIDENTIALITY flag does not work if the generated context is for the Guest account.
			/// </summary>
			ASC_RET_CONFIDENTIALITY = 0x00000010,

			/// <summary>A new session key must be negotiated.</summary>
			ASC_RET_USE_SESSION_KEY = 0x00000020,

			/// <summary></summary>
			ASC_RET_SESSION_TICKET = 0x00000040,

			/// <summary>
			/// The security package must allocate memory. The caller must eventually call the FreeContextBuffer function to free memory
			/// allocated by the security package.
			/// </summary>
			ASC_RET_ALLOCATED_MEMORY = 0x00000100,

			/// <summary>The caller expects a three-leg authentication transaction.</summary>
			ASC_RET_USED_DCE_STYLE = 0x00000200,

			/// <summary>Datagram semantics must be used. For more information, see Datagram Contexts.</summary>
			ASC_RET_DATAGRAM = 0x00000400,

			/// <summary>Connection semantics must be used. For more information, see Connection-Oriented Contexts.</summary>
			ASC_RET_CONNECTION = 0x00000800,

			/// <summary></summary>
			ASC_RET_CALL_LEVEL = 0x00002000,

			/// <summary></summary>
			ASC_RET_THIRD_LEG_FAILED = 0x00004000,

			/// <summary>Error reply messages for the peer must be generated if the context fails.</summary>
			ASC_RET_EXTENDED_ERROR = 0x00008000,

			/// <summary>Stream semantics must be used. For more information, see Stream Contexts.</summary>
			ASC_RET_STREAM = 0x00010000,

			/// <summary>Buffer integrity can be verified but no sequencing or reply detection is enabled.</summary>
			ASC_RET_INTEGRITY = 0x00020000,

			/// <summary></summary>
			ASC_RET_LICENSING = 0x00040000,

			/// <summary>
			/// When a server impersonates a context that has this flag set, that impersonation yields extremely limited access.
			/// Impersonation with IDENTIFY set is used to verify the client's identity.
			/// </summary>
			ASC_RET_IDENTIFY = 0x00080000,

			/// <summary></summary>
			ASC_RET_NULL_SESSION = 0x00100000,

			/// <summary></summary>
			ASC_RET_ALLOW_NON_USER_LOGONS = 0x00200000,

			/// <summary></summary>
			ASC_RET_ALLOW_CONTEXT_REPLAY = 0x00400000,

			/// <summary></summary>
			ASC_RET_FRAGMENT_ONLY = 0x00800000,

			/// <summary></summary>
			ASC_RET_NO_TOKEN = 0x01000000,

			/// <summary></summary>
			ASC_RET_NO_ADDITIONAL_TOKEN = 0x02000000,
		}

		/// <summary>The data representation, such as byte ordering, on the target.</summary>
		[PInvokeData("sspi.h", MSDNShortId = "a53f733e-b646-4431-b021-a2c446308849")]
		[Flags]
		public enum DREP
		{
			/// <summary></summary>
			SECURITY_NATIVE_DREP = 0x00000010,

			/// <summary></summary>
			SECURITY_NETWORK_DREP = 0x00000000
		}

		/// <summary>Property to return from the SASL context.</summary>
		[PInvokeData("sspi.h", MSDNShortId = "c9c424d3-07e6-4ed0-9189-c932af0475d9")]
		public enum SASL_OPTION
		{
			/// <summary>
			/// Data type of buffer: ULONG
			/// <para>
			/// State of SASL processing of the Authz value provided by the SASL application. The valid states for processing are
			/// Sasl_AuthZIDForbidden and Sasl_AuthZIDProcessed.
			/// </para>
			/// </summary>
			SASL_OPTION_AUTHZ_PROCESSING = 4,

			/// <summary>
			/// Data type of buffer: Array of binary characters
			/// <para>
			/// String of characters passed from the SASL client to the server. If the AuthZ_Processing state is Sasl_AuthZIDForbidden, the
			/// return value SEC_E_UNSUPPORTED_FUNCTION is returned.
			/// </para>
			/// </summary>
			SASL_OPTION_AUTHZ_STRING = 3,

			/// <summary>
			/// Data type of buffer: ULONG
			/// <para>Maximum size of the receiving buffer on the local computer.</para>
			/// </summary>
			SASL_OPTION_RECV_SIZE = 2,

			/// <summary>
			/// Data type of buffer: ULONG
			/// <para>
			/// Maximum message data size that can be transmitted. This value is the maximum buffer size that can be transmitted to the
			/// remote SASL process minus the block size, the trailer size, and the maximum signature size.
			/// </para>
			/// </summary>
			SASL_OPTION_SEND_SIZE = 1,
		}

		/// <summary>En/Decryption options.</summary>
		[PInvokeData("sspi.h", MSDNShortId = "86598BAA-0E87-46A9-AA1A-BF04BF0CDAFA")]
		public enum SEC_WINNT_AUTH_IDENTITY_ENCRYPT
		{
			/// <summary>
			/// The encrypted structure can only be decrypted by a security context in the same logon session. This option is used to protect
			/// an identity buffer that is being sent over a local RPC.
			/// </summary>
			SEC_WINNT_AUTH_IDENTITY_ENCRYPT_SAME_LOGON = 0x1,

			/// <summary>
			/// The encrypted structure can only be decrypted by the same process. Calling the function with this option is equivalent to
			/// calling SspiEncryptAuthIdentity. This option is used to protect an identity buffer that is being persisted in a process's
			/// private memory for an extended period.
			/// </summary>
			SEC_WINNT_AUTH_IDENTITY_ENCRYPT_SAME_PROCESS = 0x2
		}

		/// <summary>The type used by negotiable security packages.</summary>
		[PInvokeData("sspi.h", MSDNShortId = "a6083d76-1774-428c-85ca-fea817827d6a")]
		[Flags]
		public enum SEC_WINNT_AUTH_IDENTITY_FLAGS
		{
			/// <summary>Credentials are in ANSI form.</summary>
			SEC_WINNT_AUTH_IDENTITY_ANSI = 0x1,

			/// <summary>Credentials are in Unicode form.</summary>
			SEC_WINNT_AUTH_IDENTITY_UNICODE = 0x2,

			/// <summary>All data is in one buffer.</summary>
			SEC_WINNT_AUTH_IDENTITY_MARSHALLED = 0x4,

			/// <summary>
			/// Used with the Kerberos security support provider (SSP). Credentials are for identity only. The Kerberos package is directed
			/// to not include authorization data in the ticket.
			/// </summary>
			SEC_WINNT_AUTH_IDENTITY_ONLY = 0x8,

			/// <summary>
			/// The structure is encrypted by the SspiEncryptAuthIdentity function or by the SspiEncryptAuthIdentityEx function with the
			/// SEC_WINNT_AUTH_IDENTITY_ENCRYPT_SAME_PROCESS option. It can only be decrypted by the same process.
			/// <para>Windows Server 2008 R2 and Windows 7: This flag is not supported.</para>
			/// </summary>
			SEC_WINNT_AUTH_IDENTITY_FLAGS_PROCESS_ENCRYPTED = 0x10,

			/// <summary>
			/// The structure is encrypted by the SspiEncryptAuthIdentityEx function with the SEC_WINNT_AUTH_IDENTITY_ENCRYPT_SAME_LOGON
			/// option under the SYSTEM security context. It can only be decrypted by a thread running as SYSTEM.
			/// <para>Windows Server 2008 R2 and Windows 7: This flag is not supported.</para>
			/// </summary>
			SEC_WINNT_AUTH_IDENTITY_FLAGS_SYSTEM_PROTECTED = 0x20,

			/// <summary>
			/// The structure is encrypted by the SspiEncryptAuthIdentityEx function with the SEC_WINNT_AUTH_IDENTITY_ENCRYPT_SAME_LOGON
			/// option under a non-SYSTEM security context. It can only be decrypted by a thread running in the same logon session in which
			/// it was encrypted.
			/// <para>Windows Server 2008 R2 and Windows 7: This flag is not supported.</para>
			/// </summary>
			SEC_WINNT_AUTH_IDENTITY_FLAGS_USER_PROTECTED = 0x40,

			/// <summary>
			/// The authentication identity buffer is cbStructureLength + 8 padding bytes that are necessary for in-place encryption or
			/// decryption of the identity.
			/// <para>
			/// The authentication identity buffer is cbStructureLength + 8 padding bytes that are necessary for in-place encryption or
			/// decryption of the identity.
			/// </para>
			/// </summary>
			SEC_WINNT_AUTH_IDENTITY_FLAGS_RESERVED = 0x10000,

			/// <summary>Undocumented.</summary>
			SEC_WINNT_AUTH_IDENTITY_FLAGS_NULL_USER = 0x20000,

			/// <summary>Undocumented.</summary>
			SEC_WINNT_AUTH_IDENTITY_FLAGS_NULL_DOMAIN = 0x40000,

			/// <summary>
			/// When the credential type is password, the presence of this flag specifies that the structure is an online ID credential. The
			/// DomainOffset and DomainLength members correspond to the online ID provider name.
			/// <para>Windows Server 2008 R2 and Windows 7: This flag is not supported.</para>
			/// </summary>
			SEC_WINNT_AUTH_IDENTITY_FLAGS_ID_PROVIDER = 0x80000,
		}

		/// <summary/>
		[Flags]
		public enum SecBufferType : uint
		{
			/// <summary>The buffer contains an alert message.</summary>
			SECBUFFER_ALERT = 0x11,

			/// <summary>The buffer contains a bitmask for a SECBUFFER_READONLY_WITH_CHECKSUM buffer.</summary>
			SECBUFFER_ATTRMASK = 0xF0000000,

			/// <summary>The buffer contains channel binding information.</summary>
			SECBUFFER_CHANNEL_BINDINGS = 0xE,

			/// <summary>The buffer contains a DOMAIN_PASSWORD_INFORMATION structure.</summary>
			//[CorrespondingType(typeof(DOMAIN_PASSWORD_INFORMATION))]
			SECBUFFER_CHANGE_PASS_RESPONSE = 0xF,

			/// <summary>
			/// The buffer contains common data. The security package can read and write this data, for example, to encrypt some or all of it.
			/// </summary>
			SECBUFFER_DATA = 0x1,

			/// <summary>
			/// The buffer contains the setting for the maximum transmission unit (MTU) size for DTLS only. The default value is 1096 and the
			/// valid configurable range is between 200 and 64*1024.
			/// </summary>
			SECBUFFER_DTLS_MTU = 0x18,

			/// <summary>
			/// This is a placeholder in the buffer array. The caller can supply several such entries in the array, and the security package
			/// can return information in them. For more information, see SSPI Context Semantics.
			/// </summary>
			SECBUFFER_EMPTY = 0x0,

			/// <summary>The security package uses this value to indicate the number of extra or unprocessed bytes in a message.</summary>
			SECBUFFER_EXTRA = 0x5,

			/// <summary>
			/// The buffer contains a protocol-specific list of object identifiers (OIDs). It is not usually of interest to callers.
			/// </summary>
			SECBUFFER_MECHLIST = 0xB,

			/// <summary>The buffer contains a signature of a SECBUFFER_MECHLIST buffer. It is not usually of interest to callers.</summary>
			SECBUFFER_MECHLIST_SIGNATURE = 0xC,

			/// <summary>
			/// The security package uses this value to indicate the number of missing bytes in a particular message. The pvBuffer member is
			/// ignored in this type.
			/// </summary>
			SECBUFFER_MISSING = 0x4,

			/// <summary>
			/// These are transport-to-package–specific parameters. For example, the NetWare redirector may supply the server object
			/// identifier, while DCE RPC can supply an association UUID, and so on.
			/// </summary>
			SECBUFFER_PKG_PARAMS = 0x3,

			/// <summary>The buffer contains the preshared key. The maximum allowed PSK buffer size is 256 bytes.</summary>
			SECBUFFER_PRESHARED_KEY = 0x16,

			/// <summary>The buffer contains the preshared key identity.</summary>
			SECBUFFER_PRESHARED_KEY_IDENTITY = 0x17,

			/// <summary>The buffer contains the SRTP master key identifier.</summary>
			SECBUFFER_SRTP_MASTER_KEY_IDENTIFIER = 0x14,

			/// <summary>The buffer contains the list of SRTP protection profiles, in descending order of preference.</summary>
			SECBUFFER_SRTP_PROTECTION_PROFILES = 0x13,

			/// <summary>The buffer contains a protocol-specific header for a particular record. It is not usually of interest to callers.</summary>
			SECBUFFER_STREAM_HEADER = 0x7,

			/// <summary>The buffer contains a protocol-specific trailer for a particular record. It is not usually of interest to callers.</summary>
			SECBUFFER_STREAM_TRAILER = 0x6,

			/// <summary>This flag is reserved. Do not use it.</summary>
			SECBUFFER_TARGET = 0xD,

			/// <summary>
			/// The buffer specifies the service principal name (SPN) of the target.
			/// <para>This value is supported by the Digest security package when used with channel bindings.</para>
			/// <para>Windows Server 2008, Windows Vista, Windows Server 2003 and Windows XP: This value is not supported.</para>
			/// </summary>
			SECBUFFER_TARGET_HOST = 0x10,

			/// <summary>
			/// The buffer contains the security token portion of the message. This is read-only for input parameters or read/write for
			/// output parameters.
			/// </summary>
			SECBUFFER_TOKEN = 0x2,

			/// <summary>
			/// The buffer contains the supported token binding protocol version and key parameters, in descending order of preference.
			/// </summary>
			SECBUFFER_TOKEN_BINDING = 0x15,

			/// <summary>
			/// The buffer contains a list of application protocol IDs, one list per application protocol negotiation extension type to be enabled.
			/// </summary>
			SECBUFFER_APPLICATION_PROTOCOLS = 18,

			/// <summary>Undocumented.</summary>
			SECBUFFER_NEGOTIATION_INFO = 8,

			/// <summary>Undocumented.</summary>
			SECBUFFER_PADDING = 9,

			/// <summary>
			/// The buffer is read-only with no checksum. This flag is intended for sending header information to the security package for
			/// computing the checksum. The package can read this buffer, but cannot modify it.
			/// </summary>
			SECBUFFER_READONLY = 0x80000000,

			/// <summary>The buffer is read-only with a checksum.</summary>
			SECBUFFER_READONLY_WITH_CHECKSUM = 0x10000000,

			/// <summary>Undocumented.</summary>
			SECBUFFER_RESERVED = 0x60000000,

			/// <summary>Undocumented.</summary>
			SECBUFFER_STREAM = 10,
		}

		/// <summary>Specifies the attribute of the context to be returned.</summary>
		[PInvokeData("sspi.h", MSDNShortId = "FD91EE99-F94E-44CE-9331-933D0CAA5F75")]
		public enum SECPKG_ATTR : uint
		{
			/// <summary>
			/// The pBuffer parameter contains a pointer to a SecPkgContext_AccessToken structure.
			/// <para>Returns a handle to the access token.</para>
			/// </summary>
			[CorrespondingType(typeof(SecPkgContext_AccessToken), CorrespondingAction.Get)]
			SECPKG_ATTR_ACCESS_TOKEN = 18,

			/// <summary>
			/// The pBuffer parameter contains a pointer to a SecPkgContext_SessionAppData structure.
			/// <para>Returns or specifies application data for the session.</para>
			/// <para>This attribute is supported only by the Schannel security package.</para>
			/// </summary>
			[CorrespondingType(typeof(SecPkgContext_SessionAppData), CorrespondingAction.GetSet)]
			SECPKG_ATTR_APP_DATA = 0x5e,

			/// <summary>
			/// The pBuffer parameter contains a pointer to a SecPkgContext_Authority structure.
			/// <para>Queries the name of the authenticating authority.</para>
			/// </summary>
			[CorrespondingType(typeof(SecPkgContext_Authority), CorrespondingAction.Get)]
			SECPKG_ATTR_AUTHORITY = 6,

			/// <summary>
			/// The pBuffer parameter contains a pointer to a SecPkgContext_ClientSpecifiedTarget structure that represents the service
			/// principal name (SPN) of the initial target supplied by the client.
			/// <para>Windows Server 2008, Windows Vista, Windows Server 2003 and Windows XP: This value is not supported.</para>
			/// </summary>
			[CorrespondingType(typeof(SecPkgContext_ClientSpecifiedTarget), CorrespondingAction.Get)]
			SECPKG_ATTR_CLIENT_SPECIFIED_TARGET = 27,

			/// <summary>
			/// The pBuffer parameter contains a pointer to a SecPkgContext_ConnectionInfo structure.
			/// <para>Returns detailed information on the established connection.</para>
			/// <para>This attribute is supported only by the Schannel security package.</para>
			/// </summary>
			[CorrespondingType(typeof(SecPkgContext_ConnectionInfo), CorrespondingAction.Get)]
			SECPKG_ATTR_CONNECTION_INFO = 0x5a,

			/// <summary>
			/// The pBuffer parameter contains a pointer to a SecPkgContext_ClientCreds structure that specifies client credentials.
			/// <para>If the client credential is user name and password, the buffer is a packed KERB_INTERACTIVE_LOGON structure.</para>
			/// <para>If the client credential is user name and smart card PIN, the buffer is a packed KERB_CERTIFICATE_LOGON structure.</para>
			/// <para>If the client credential is an online identity credential, the buffer is a marshaled SEC_WINNT_AUTH_IDENTITY_EX2 structure.</para>
			/// <para>This attribute is supported only on the CredSSP server.</para>
			/// <para>
			/// Windows Server 2008 R2, Windows 7, Windows Server 2008, Windows Vista, Windows Server 2003 and Windows XP: This value is not supported.
			/// </para>
			/// </summary>
			[CorrespondingType(typeof(SecPkgContext_ClientCreds), CorrespondingAction.Get)]
			SECPKG_ATTR_CREDS_2 = 0x80000086,

			/// <summary>
			/// The pBuffer parameter contains a pointer to a SecPkgContext_DceInfo structure.
			/// <para>Queries for authorization data used by DCE services.</para>
			/// </summary>
			[CorrespondingType(typeof(SecPkgContext_DceInfo), CorrespondingAction.Get)]
			SECPKG_ATTR_DCE_INFO = 3,

			/// <summary>
			/// The pBuffer parameter contains a pointer to a SecPkgContext_Bindings structure that specifies channel binding information.
			/// <para>This attribute is supported only by the Schannel security package.</para>
			/// <para>Windows Server 2008, Windows Vista, Windows Server 2003 and Windows XP: This value is not supported.</para>
			/// </summary>
			[CorrespondingType(typeof(SecPkgContext_Bindings), CorrespondingAction.Get)]
			SECPKG_ATTR_ENDPOINT_BINDINGS = 26,

			/// <summary>
			/// The pBuffer parameter contains a pointer to a SecPkgContext_EapKeyBlock structure.
			/// <para>Queries for key data used by the EAP TLS protocol.</para>
			/// <para>This attribute is supported only by the Schannel security package.</para>
			/// </summary>
			[CorrespondingType(typeof(SecPkgContext_EapKeyBlock), CorrespondingAction.Get)]
			SECPKG_ATTR_EAP_KEY_BLOCK = 0x5b,

			/// <summary>
			/// The pBuffer parameter contains a pointer to a SecPkgContext_Flags structure.
			/// <para>Returns information about the negotiated context flags.</para>
			/// </summary>
			[CorrespondingType(typeof(SecPkgContext_Flags), CorrespondingAction.Get)]
			SECPKG_ATTR_FLAGS = 14,

			/// <summary>
			/// The pBuffer parameter contains a pointer to a SecPkgContext_IssuerListInfoEx structure.
			/// <para>Returns a list of certificate issuers that are accepted by the server.</para>
			/// <para>This attribute is supported only by the Schannel security package.</para>
			/// </summary>
			[CorrespondingType(typeof(SecPkgContext_IssuerListInfoEx), CorrespondingAction.Get)]
			SECPKG_ATTR_ISSUER_LIST_EX = 0x59,

			/// <summary>
			/// The pBuffer parameter contains a pointer to a SecPkgContext_KeyInfo structure.
			/// <para>Queries information about the keys used in a security context.</para>
			/// </summary>
			[CorrespondingType(typeof(SecPkgContext_KeyInfo), CorrespondingAction.Get)]
			SECPKG_ATTR_KEY_INFO = 5,

			/// <summary>
			/// The pBuffer parameter contains a pointer to a SecPkgContext_LastClientTokenStatus structure that specifies whether the token
			/// from the most recent call to the InitializeSecurityContext function is the last token from the client.
			/// <para>This value is supported only by the Negotiate, Kerberos, and NTLM security packages.</para>
			/// <para>Windows Server 2008, Windows Vista, Windows Server 2003 and Windows XP: This value is not supported.</para>
			/// </summary>
			[CorrespondingType(typeof(SecPkgContext_LastClientTokenStatus), CorrespondingAction.Get)]
			SECPKG_ATTR_LAST_CLIENT_TOKEN_STATUS = 30,

			/// <summary>
			/// The pBuffer parameter contains a pointer to a SecPkgContext_Lifespan structure.
			/// <para>Queries the life span of the context.</para>
			/// </summary>
			[CorrespondingType(typeof(SecPkgContext_Lifespan), CorrespondingAction.Get)]
			SECPKG_ATTR_LIFESPAN = 2,

			/// <summary>
			/// The pBuffer parameter contains a pointer to a PCCERT_CONTEXTstructure.
			/// <para>Finds a certificate context that contains a local end certificate.</para>
			/// <para>This attribute is supported only by the Schannel security package.</para>
			/// </summary>
			SECPKG_ATTR_LOCAL_CERT_CONTEXT = 0x54,

			/// <summary>
			/// The pBuffer parameter contains a pointer to a SecPkgContext_Names structure.
			/// <para>Queries the name associated with the context.</para>
			/// </summary>
			[CorrespondingType(typeof(SecPkgContext_Names), CorrespondingAction.Get)]
			SECPKG_ATTR_NAMES = 1,

			/// <summary>
			/// The pBuffer parameter contains a pointer to a SecPkgContext_NativeNames structure.
			/// <para>Returns the principal name (CNAME) from the outbound ticket.</para>
			/// </summary>
			[CorrespondingType(typeof(SecPkgContext_NativeNames), CorrespondingAction.Get)]
			SECPKG_ATTR_NATIVE_NAMES = 13,

			/// <summary>
			/// The pBuffer parameter contains a pointer to a SecPkgContext_NegotiationInfo structure.
			/// <para>
			/// Returns information about the security package to be used with the negotiation process and the current state of the
			/// negotiation for the use of that package.
			/// </para>
			/// </summary>
			[CorrespondingType(typeof(SecPkgContext_NegotiationInfo), CorrespondingAction.Get)]
			SECPKG_ATTR_NEGOTIATION_INFO = 12,

			/// <summary>
			/// The pBuffer parameter contains a pointer to a SecPkgContext_PackageInfostructure.
			/// <para>Returns information on the SSP in use.</para>
			/// </summary>
			[CorrespondingType(typeof(SecPkgContext_PackageInfo), CorrespondingAction.Get)]
			SECPKG_ATTR_PACKAGE_INFO = 10,

			/// <summary>
			/// The pBuffer parameter contains a pointer to a SecPkgContext_PasswordExpiry structure.
			/// <para>Returns password expiration information.</para>
			/// </summary>
			[CorrespondingType(typeof(SecPkgContext_PasswordExpiry), CorrespondingAction.Get)]
			SECPKG_ATTR_PASSWORD_EXPIRY = 8,

			/// <summary>
			/// The pBuffer parameter contains a pointer to a PCCERT_CONTEXTstructure.
			/// <para>Finds a certificate context that contains the end certificate supplied by the server.</para>
			/// <para>This attribute is supported only by the Schannel security package.</para>
			/// </summary>
			[CorrespondingType(typeof(CERT_CONTEXT), CorrespondingAction.Get)]
			SECPKG_ATTR_REMOTE_CERT_CONTEXT = 0x53,

			/// <summary>
			/// The pBuffer parameter contains a pointer to a HCERTCONTEXT. Finds a certificate context that contains a certificate supplied
			/// by the Root store.
			/// </summary>
			SECPKG_ATTR_ROOT_STORE = 0x55,

			/// <summary>
			/// The pBuffer parameter contains a pointer to a SecPkgContext_SessionKey structure.
			/// <para>Returns information about the session keys.</para>
			/// </summary>
			[CorrespondingType(typeof(SecPkgContext_SessionKey), CorrespondingAction.Get)]
			SECPKG_ATTR_SESSION_KEY = 9,

			/// <summary>
			/// The pBuffer parameter contains a pointer to a SecPkgContext_SessionInfo structure.
			/// <para>Returns information about the session.</para>
			/// <para>Windows Server 2008, Windows Vista, Windows Server 2003 and Windows XP: This value is not supported.</para>
			/// <para>This attribute is supported only by the Schannel security package.</para>
			/// </summary>
			[CorrespondingType(typeof(SecPkgContext_SessionInfo), CorrespondingAction.Get)]
			SECPKG_ATTR_SESSION_INFO = 0x5d,

			/// <summary>
			/// The pBuffer parameter contains a pointer to a SecPkgContext_Sizes structure.
			/// <para>Queries the sizes of the structures used in the per-message functions.</para>
			/// </summary>
			[CorrespondingType(typeof(SecPkgContext_Sizes))]
			SECPKG_ATTR_SIZES = 0,

			/// <summary>
			/// The pBuffer parameter contains a pointer to a SecPkgContext_StreamSizes structure.
			/// <para>Queries the sizes of the various parts of a stream used in the per-message functions.</para>
			/// <para>This attribute is supported only by the Schannel security package.</para>
			/// </summary>
			[CorrespondingType(typeof(SecPkgContext_StreamSizes), CorrespondingAction.Get)]
			SECPKG_ATTR_STREAM_SIZES = 4,

			/// <summary>
			/// The pBuffer parameter contains a pointer to a SecPkgContext_SubjectAttributes structure.
			/// <para>This value returns information about the security attributes for the connection.</para>
			/// <para>This value is supported only on the CredSSP server.</para>
			/// <para>Windows Server 2008, Windows Vista, Windows Server 2003 and Windows XP: This value is not supported.</para>
			/// </summary>
			[CorrespondingType(typeof(SecPkgContext_SubjectAttributes), CorrespondingAction.Get)]
			SECPKG_ATTR_SUBJECT_SECURITY_ATTRIBUTES = 124,

			/// <summary>
			/// The pBuffer parameter contains a pointer to a SecPkgContext_SupportedSignatures structure.
			/// <para>This value returns information about the signature types that are supported for the connection.</para>
			/// <para>This value is supported only by the Schannel security package.</para>
			/// <para>Windows Server 2008, Windows Vista, Windows Server 2003 and Windows XP: This value is not supported.</para>
			/// </summary>
			[CorrespondingType(typeof(SecPkgContext_SupportedSignatures), CorrespondingAction.Get)]
			SECPKG_ATTR_SUPPORTED_SIGNATURES = 0x66,

			/// <summary>
			/// The pBuffer parameter contains a pointer to a SecPkgContext_TargetInformation structure.
			/// <para>Returns information about the name of the remote server.</para>
			/// </summary>
			[CorrespondingType(typeof(SecPkgContext_TargetInformation), CorrespondingAction.Get)]
			SECPKG_ATTR_TARGET_INFORMATION = 17,

			/// <summary>
			/// The pBuffer parameter contains a pointer to a SecPkgContext_Bindings structure that specifies channel binding information.
			/// <para>This value is supported only by the Schannel security package.</para>
			/// <para>Windows Server 2008, Windows Vista, Windows Server 2003 and Windows XP: This value is not supported.</para>
			/// </summary>
			[CorrespondingType(typeof(SecPkgContext_Bindings), CorrespondingAction.Get)]
			SECPKG_ATTR_UNIQUE_BINDINGS = 25,

			/// <summary>
			/// The pBuffer parameter contains a pointer to a SecPkgContext_AccessToken structure that specifies the access token for the
			/// current security context.
			/// <para>This attribute is supported only on the server.</para>
			/// </summary>
			[CorrespondingType(typeof(SecPkgContext_AccessToken), CorrespondingAction.Get)]
			SECPKG_ATTR_C_ACCESS_TOKEN = 0x80000012,

			/// <summary>
			/// The pBuffer parameter contains a pointer to a SecPkgContext_AccessToken structure that specifies the access token for the
			/// current security context.
			/// <para>This attribute is supported only on the server.</para>
			/// </summary>
			[CorrespondingType(typeof(SecPkgContext_AccessToken), CorrespondingAction.Get)]
			SECPKG_ATTR_C_FULL_ACCESS_TOKEN = 0x80000082,

			/// <summary>
			/// The pBuffer parameter contains a pointer to a CERT_TRUST_STATUS structure that specifies trust information about the certificate.
			/// <para>This attribute is supported only on the client.</para>
			/// </summary>
			[CorrespondingType(typeof(CERT_TRUST_STATUS), CorrespondingAction.Get)]
			SECPKG_ATTR_CERT_TRUST_STATUS = 0x80000084,

			/// <summary>
			/// The pBuffer parameter contains a pointer to a SecPkgContext_ClientCreds structure that specifies client credentials.
			/// <para>The client credentials can be either user name and password or user name and smart card PIN.</para>
			/// <para>This attribute is supported only on the server.</para>
			/// </summary>
			[CorrespondingType(typeof(SecPkgContext_ClientCreds), CorrespondingAction.Get)]
			SECPKG_ATTR_CREDS = 0x80000080,

			/// <summary>
			/// The pBuffer parameter contains a pointer to a SecPkgContext_PackageInfo structure that specifies the name of the
			/// authentication package negotiated by the Microsoft Negotiate provider.
			/// </summary>
			[CorrespondingType(typeof(SecPkgContext_PackageInfo), CorrespondingAction.Get)]
			SECPKG_ATTR_NEGOTIATION_PACKAGE = 0x80000081,

			/// <summary>
			/// The pBuffer parameter contains a pointer to a SecPkgContext_Flags structure that specifies information about the flags in the
			/// current security context.
			/// <para>This attribute is supported only on the client.</para>
			/// </summary>
			[CorrespondingType(typeof(SecPkgContext_Flags), CorrespondingAction.Get)]
			SECPKG_ATTR_SERVER_AUTH_FLAGS = 0x80000083,

			/// <summary>
			/// The pBuffer parameter contains a pointer to a SecPkgContext_EapPrfInfo structure.
			/// <para>
			/// Sets the pseudo-random function (PRF) used by the Extensible Authentication Protocol (EAP). This is the value that is
			/// returned by a call to the QueryContextAttributes (Schannel) function when SECPKG_ATTR_EAP_KEY_BLOCK is passed as the value of
			/// the ulAttribute parameter.
			/// </para>
			/// <para>This attribute is supported only by the Schannel security package.</para>
			/// </summary>
			[CorrespondingType(typeof(SecPkgContext_EapPrfInfo), CorrespondingAction.Set)]
			SECPKG_ATTR_EAP_PRF_INFO = 101,

			/// <summary>
			/// The pBuffer parameter contains a pointer to a SecPkgContext_EarlyStart structure.
			/// <para>Sets the False Start feature. See the Building a faster and more secure web blog post for information on this feature.</para>
			/// </summary>
			[CorrespondingType(typeof(SecPkgContext_EarlyStart), CorrespondingAction.Set)]
			SECPKG_ATTR_EARLY_START = 105,

			/// <summary>
			/// Sets and retrieves the MTU (maximum transmission unit) value for use with DTLS. If DTLS is not enabled in a security context,
			/// this attribute is not supported.
			/// <para>Valid values are between 200 bytes and 64 kilobytes. The default DTLS MTU value in Schannel is 1096 bytes.</para>
			/// </summary>
			[CorrespondingType(typeof(ushort), CorrespondingAction.Set)]
			SECPKG_ATTR_DTLS_MTU = 34,

			/// <summary>
			/// The pBuffer parameter contains a pointer to a SecPkgContext_KeyingMaterialInfo structure. The keying material export feature
			/// follows the RFC 5705 standard.
			/// <para>This attribute is supported only by the Schannel security package in Windows 10 and Windows Server 2016 or later versions.</para>
			/// </summary>
			[CorrespondingType(typeof(SecPkgContext_KeyingMaterialInfo), CorrespondingAction.Set)]
			SECPKG_ATTR_KEYING_MATERIAL_INFO = 106,
		}

		/// <summary>
		/// <para>
		/// Indicates whether the token from the most recent call to the InitializeSecurityContext function is the last token from the client.
		/// </para>
		/// <para>This enumeration is used in the SecPkgContext_LastClientTokenStatus structure.</para>
		/// </summary>
		// https://docs.microsoft.com/en-us/windows/desktop/api/sspi/ne-sspi-secpkg_attr_lct_status typedef enum _SECPKG_ATTR_LCT_STATUS {
		// SecPkgAttrLastClientTokenYes, SecPkgAttrLastClientTokenNo, SecPkgAttrLastClientTokenMaybe } SECPKG_ATTR_LCT_STATUS, *PSECPKG_ATTR_LCT_STATUS;
		[PInvokeData("sspi.h", MSDNShortId = "b9067862-2339-4543-a8cd-610e6f921bfd")]
		public enum SECPKG_ATTR_LCT_STATUS
		{
			/// <summary>The token is the last token from the client.</summary>
			SecPkgAttrLastClientTokenYes,

			/// <summary>The token is not the last token from the client.</summary>
			SecPkgAttrLastClientTokenNo,

			/// <summary>It is not known whether the token is the last token from the client.</summary>
			SecPkgAttrLastClientTokenMaybe,
		}

		/// <summary>Bit flags that describe the capabilities of the security package.</summary>
		[PInvokeData("sspi.h", MSDNShortId = "d0bff3d8-63f1-4a4e-851f-177040af6bd2")]
		[Flags]
		public enum SECPKG_CALLFLAGS
		{
			/// <summary>The caller is an app container.</summary>
			SECPKG_CALLFLAGS_APPCONTAINER = 0x00000001,

			/// <summary>The caller can use default credentials.</summary>
			SECPKG_CALLFLAGS_AUTHCAPABLE = 0x00000002,

			/// <summary>The caller can only use supplied credentials.</summary>
			SECPKG_CALLFLAGS_FORCE_SUPPLIED = 0x00000004,

			/// <summary/>
			SECPKG_CALLFLAGS_APPCONTAINER_UPNCAPABLE = 0x00000008,
		}

		/// <summary>Flags for <c>ExportSecurityContext</c>.</summary>
		[PInvokeData("sspi.h", MSDNShortId = "4ebc7f37-b948-4c78-973f-0a74e55c7ee2")]
		[Flags]
		public enum SECPKG_CONTEXT_EXPORT
		{
			/// <summary>The new security context is reset to its initial state.</summary>
			SECPKG_CONTEXT_EXPORT_RESET_NEW = 1,

			/// <summary>The old security context is deleted.</summary>
			SECPKG_CONTEXT_EXPORT_DELETE_OLD = 2,

			/// <summary>
			/// This value is not supported.
			/// <para>
			/// Windows Server 2003 and Windows XP/2000: The security context is to be exported to the kernel.This value is supported only in
			/// Schannel kernel mode.
			/// </para>
			/// </summary>
			SECPKG_CONTEXT_EXPORT_TO_KERNEL = 4,
		}

		/// <summary>A flag that indicates how credentials will be used.</summary>
		[PInvokeData("sspi.h", MSDNShortId = "3b73decf-75d4-4bc4-b7ca-5f16aaadff29")]
		public enum SECPKG_CRED
		{
			/// <summary>Allow a local client credential to prepare an outgoing token.</summary>
			SECPKG_CRED_OUTBOUND = 0x2,

			/// <summary>
			/// Validate an incoming server credential. Inbound credentials might be validated by using an authenticating authority when
			/// InitializeSecurityContext (CredSSP) or AcceptSecurityContext (CredSSP) is called. If such an authority is not available, the
			/// function will fail and return SEC_E_NO_AUTHENTICATING_AUTHORITY. Validation is package specific.
			/// </summary>
			SECPKG_CRED_INBOUND = 0x1,

			/// <summary/>
			SECPKG_CRED_BOTH = 0x3,

			/// <summary/>
			SECPKG_CRED_DEFAULT = 0x4
		}

		/// <summary>Specifies the attribute to query.</summary>
		[PInvokeData("sspi.h", MSDNShortId = "a8ba6f73-8469-431b-b185-183b45b2c533")]
		public enum SECPKG_CRED_ATTR
		{
			/// <summary>
			/// Returns the certificate thumbprint in a pbuffer of type SecPkgCredentials_Cert.
			/// <para>This attribute is only supported by Kerberos.</para>
			/// <para>
			/// Windows Server 2008 R2, Windows 7, Windows Server 2008, Windows Vista, Windows Server 2003 and Windows XP: This attribute is
			/// not available.
			/// </para>
			/// </summary>
			[CorrespondingType(typeof(SecPkgCredentials_Cert), CorrespondingAction.Get)]
			SECPKG_CRED_ATTR_CERT = 4,

			/// <summary>
			/// Returns the name of a credential in a pbuffer of type SecPkgCredentials_Names.
			/// <para>This attribute is not supported by Schannel in WOW64 mode.</para>
			/// </summary>
			[CorrespondingType(typeof(SecPkgCredentials_Names))]
			SECPKG_CRED_ATTR_NAMES = 1,

			/// <summary>
			/// Returns the supported algorithms in a pbuffer of type SecPkgCred_SupportedAlgs. All supported algorithms are included,
			/// regardless of whether they are supported by the provided certificate or enabled on the local computer.
			/// <para>This attribute is supported only by Schannel.</para>
			/// </summary>
			[CorrespondingType(typeof(SecPkgCred_SupportedAlgs))]
			SECPKG_ATTR_SUPPORTED_ALGS = 0x56,

			/// <summary>
			/// Returns the cipher strengths in a pbuffer of type SecPkgCred_CipherStrengths.
			/// <para>This attribute is supported only by Schannel.</para>
			/// </summary>
			[CorrespondingType(typeof(SecPkgCred_CipherStrengths))]
			SECPKG_ATTR_CIPHER_STRENGTHS = 0x57,

			/// <summary>
			/// Returns the supported algorithms in a pbuffer of type SecPkgCred_SupportedProtocols. All supported protocols are included,
			/// regardless of whether they are supported by the provided certificate or enabled on the local computer.
			/// <para>This attribute is supported only by Schannel.</para>
			/// </summary>
			[CorrespondingType(typeof(SecPkgCred_SupportedProtocols))]
			SECPKG_ATTR_SUPPORTED_PROTOCOLS = 0x58,
		}

		/// <summary>
		/// Indicates the type of credential used in a client context. The <c>SECPKG_CRED_CLASS</c> enumeration is used in the
		/// SecPkgContext_CredInfo structure.
		/// </summary>
		// https://docs.microsoft.com/en-us/windows/desktop/api/sspi/ne-sspi-_secpkg_cred_class typedef enum _SECPKG_CRED_CLASS {
		// SecPkgCredClass_None, SecPkgCredClass_Ephemeral, SecPkgCredClass_PersistedGeneric, SecPkgCredClass_PersistedSpecific,
		// SecPkgCredClass_Explicit } SECPKG_CRED_CLASS, *PSECPKG_CRED_CLASS;
		[PInvokeData("sspi.h", MSDNShortId = "2f5f9be2-e7b5-4d34-a2ad-89a99db78ad0")]
		public enum SECPKG_CRED_CLASS
		{
			/// <summary>No credentials are supplied.</summary>
			SecPkgCredClass_None = 0,

			/// <summary>Indicates the credentials used to log on to the system.</summary>
			SecPkgCredClass_Ephemeral = 10,

			/// <summary>Indicates saved credentials that are not target specific.</summary>
			SecPkgCredClass_PersistedGeneric = 20,

			/// <summary>Indicates saved credentials that are target specific.</summary>
			SecPkgCredClass_PersistedSpecific = 30,

			/// <summary>The sec PKG cred class explicit</summary>
			SecPkgCredClass_Explicit = 40,
		}

		/// <summary>Bit flags that describe the capabilities of the security package.</summary>
		[PInvokeData("sspi.h", MSDNShortId = "d0bff3d8-63f1-4a4e-851f-177040af6bd2")]
		[Flags]
		public enum SECPKG_FLAG : uint
		{
			/// <summary>The security package supports the MakeSignature and VerifySignature functions.</summary>
			SECPKG_FLAG_INTEGRITY = 0x1,

			/// <summary>The security package supports the EncryptMessage (General) and DecryptMessage (General) functions.</summary>
			SECPKG_FLAG_PRIVACY = 0x2,

			/// <summary>
			/// The package is interested only in the security-token portion of messages, and will ignore any other buffers. This is a
			/// performance-related issue.
			/// </summary>
			SECPKG_FLAG_TOKEN_ONLY = 0x4,

			/// <summary>
			/// Supports datagram-style authentication. For more information, see SSPI Context Semantics.
			/// <para>Important The Microsoft Kerberos package does not support datagram contexts in user-to-user mode.</para>
			/// </summary>
			SECPKG_FLAG_DATAGRAM = 0x8,

			/// <summary>Supports connection-oriented style authentication. For more information, see SSPI Context Semantics.</summary>
			SECPKG_FLAG_CONNECTION = 0x10,

			/// <summary>Multiple legs are required for authentication.</summary>
			SECPKG_FLAG_MULTI_REQUIRED = 0x20,

			/// <summary>Server authentication support is not provided.</summary>
			SECPKG_FLAG_CLIENT_ONLY = 0x40,

			/// <summary>Supports extended error handling. For more information, see Extended Error Information.</summary>
			SECPKG_FLAG_EXTENDED_ERROR = 0x80,

			/// <summary>Supports Windows impersonation in server contexts.</summary>
			SECPKG_FLAG_IMPERSONATION = 0x100,

			/// <summary>Understands Windows principal and target names.</summary>
			SECPKG_FLAG_ACCEPT_WIN32_NAME = 0x200,

			/// <summary>Supports stream semantics. For more information, see SSPI Context Semantics.</summary>
			SECPKG_FLAG_STREAM = 0x400,

			/// <summary>Can be used by the Microsoft Negotiate security package.</summary>
			SECPKG_FLAG_NEGOTIABLE = 0x800,

			/// <summary>Supports GSS compatibility.</summary>
			SECPKG_FLAG_GSS_COMPATIBLE = 0x1000,

			/// <summary>Supports LsaLogonUser.</summary>
			SECPKG_FLAG_LOGON = 0x2000,

			/// <summary>Token buffers are in ASCII characters format.</summary>
			SECPKG_FLAG_ASCII_BUFFERS = 0x4000,

			/// <summary>
			/// Supports separating large tokens into smaller buffers so that applications can make repeated calls to
			/// InitializeSecurityContext (General) and AcceptSecurityContext (General) with the smaller buffers to complete authentication.
			/// </summary>
			SECPKG_FLAG_FRAGMENT = 0x8000,

			/// <summary>Supports mutual authentication.</summary>
			SECPKG_FLAG_MUTUAL_AUTH = 0x10000,

			/// <summary>Supports delegation.</summary>
			SECPKG_FLAG_DELEGATION = 0x20000,

			/// <summary>
			/// The security package supports using a checksum instead of in-place encryption when calling the EncryptMessage function.
			/// </summary>
			SECPKG_FLAG_READONLY_WITH_CHECKSUM = 0x40000,

			/// <summary>Supports callers with restricted tokens.</summary>
			SECPKG_FLAG_RESTRICTED_TOKENS = 0x80000,

			/// <summary>
			/// The security package extends the Microsoft Negotiate security package. There can be at most one package of this type.
			/// </summary>
			SECPKG_FLAG_NEGO_EXTENDER = 0x00100000,

			/// <summary>This package is negotiated by the package of type SECPKG_FLAG_NEGO_EXTENDER.</summary>
			SECPKG_FLAG_NEGOTIABLE2 = 0x00200000,

			/// <summary>This package receives all calls from app container apps.</summary>
			SECPKG_FLAG_APPCONTAINER_PASSTHROUGH = 0x00400000,

			/// <summary>
			/// This package receives calls from app container apps if one of the following checks succeeds.
			/// <list type="bullet">
			/// <item>
			/// <term>Caller has default credentials capability.</term>
			/// </item>
			/// <item>
			/// <term>The target is a proxy server.</term>
			/// </item>
			/// <item>
			/// <term>The caller has supplied credentials.</term>
			/// </item>
			/// </list>
			/// </summary>
			SECPKG_FLAG_APPCONTAINER_CHECKS = 0x00800000,

			/// <summary>This package is running with Credential Guard enabled.</summary>
			SECPKG_FLAG_CREDENTIAL_ISOLATION_ENABLED = 0x01000000,

			/// <summary/>
			SECPKG_FLAG_UNDOCUMENTED1 = 0x02000000,
		}

		/// <summary>The type of security package.</summary>
		[PInvokeData("sspi.h", MSDNShortId = "2e9f65ec-72a5-4d6f-aa63-f83369f0dd07")]
		public enum SECPKG_OPTIONS_TYPE
		{
			/// <summary>The package type is not known.</summary>
			SECPKG_OPTIONS_TYPE_UNKNOWN = 0,

			/// <summary>The security package is an LSA authentication package.</summary>
			SECPKG_OPTIONS_TYPE_LSA = 1,

			/// <summary>The security package is a Security Support Provider Interface (SSPI) package.</summary>
			SECPKG_OPTIONS_TYPE_SSPI = 2,
		}

		/// <summary>Package-specific flags that indicate the quality of protection.</summary>
		[PInvokeData("Sspi.h", MSDNShortId = "aa375348")]
		[Flags]
		public enum SECQOP : uint
		{
			/// <summary>The message is not encrypted, but a header or trailer is present.</summary>
			SECQOP_WRAP_NO_ENCRYPT = 0x80000001,

			/// <summary>
			/// Send an Schannel alert message. In this case, the pMessage parameter must contain a standard two-byte SSL/TLS event code.
			/// This value is supported only by the Schannel SSP.
			/// </summary>
			SECQOP_WRAP_OOB_DATA = 0x40000000,
		}

		/// <summary>
		/// The <c>AcceptSecurityContext (CredSSP)</c> function lets the server component of a transport application establish a security
		/// context between the server and a remote client. The remote client calls the InitializeSecurityContext (CredSSP) function to start
		/// the process of establishing a security context. The server can require one or more reply tokens from the remote client to
		/// complete establishing the security context.
		/// </summary>
		/// <param name="phCredential">
		/// A handle to the server credentials. To retrieve this handle, the server calls the AcquireCredentialsHandle (CredSSP) function
		/// with either the SECPKG_CRED_INBOUND or SECPKG_CRED_BOTH flag set.
		/// </param>
		/// <param name="phContext">
		/// A pointer to a CtxtHandle structure. On the first call to <c>AcceptSecurityContext (CredSSP)</c>, this pointer is <c>NULL</c>. On
		/// subsequent calls, phContext specifies the partially formed context returned in the phNewContext parameter by the first call.
		/// </param>
		/// <param name="pInput">
		/// <para>
		/// A pointer to a SecBufferDesc structure generated by a client call to InitializeSecurityContext (CredSSP). The structure contains
		/// the input buffer descriptor.
		/// </para>
		/// <para>
		/// The first buffer must be of type <c>SECBUFFER_TOKEN</c> and contain the security token received from the client. The second
		/// buffer should be of type <c>SECBUFFER_EMPTY</c>.
		/// </para>
		/// </param>
		/// <param name="fContextReq">
		/// <para>
		/// -Bit flags that specify the attributes required by the server to establish the context. Bit flags can be combined by using
		/// bitwise- <c>OR</c> operations. This parameter can be one or more of the following values.
		/// </para>
		/// <list type="table">
		/// <listheader>
		/// <term>Value</term>
		/// <term>Meaning</term>
		/// </listheader>
		/// <item>
		/// <term>ASC_REQ_ALLOCATE_MEMORY</term>
		/// <term>
		/// Credential Security Support Provider (CredSSP) will allocate output buffers. When you have finished using the output buffers,
		/// free them by calling the FreeContextBuffer function.
		/// </term>
		/// </item>
		/// <item>
		/// <term>ASC_REQ_CONNECTION</term>
		/// <term>The security context will not handle formatting messages.</term>
		/// </item>
		/// <item>
		/// <term>ASC_REQ_DELEGATE</term>
		/// <term>The server is allowed to impersonate the client. Ignore this flag for constrained delegation.</term>
		/// </item>
		/// <item>
		/// <term>ASC_REQ_EXTENDED_ERROR</term>
		/// <term>When errors occur, the remote party will be notified.</term>
		/// </item>
		/// <item>
		/// <term>ASC_REQ_REPLAY_DETECT</term>
		/// <term>Detect replayed packets.</term>
		/// </item>
		/// <item>
		/// <term>ASC_REQ_SEQUENCE_DETECT</term>
		/// <term>Detect messages received out of sequence.</term>
		/// </item>
		/// <item>
		/// <term>ASC_REQ_STREAM</term>
		/// <term>Support a stream-oriented connection.</term>
		/// </item>
		/// </list>
		/// <para>
		/// For possible attribute flags and their meanings, see Context Requirements. Flags used for this parameter are prefixed with
		/// ASC_REQ, for example, ASC_REQ_DELEGATE.
		/// </para>
		/// <para>The requested attributes may not be supported by the client. For more information, see the pfContextAttr parameter.</para>
		/// </param>
		/// <param name="TargetDataRep">
		/// The data representation, such as byte ordering, on the target. This parameter can be either <c>SECURITY_NATIVE_DREP</c> or <c>SECURITY_NETWORK_DREP</c>.
		/// </param>
		/// <param name="phNewContext">
		/// A pointer to a CtxtHandle structure. On the first call to <c>AcceptSecurityContext (CredSSP)</c>, this pointer receives the new
		/// context handle. On subsequent calls, phNewContext can be the same as the handle specified in the phContext parameter.
		/// </param>
		/// <param name="pOutput">
		/// <para>
		/// A pointer to a SecBufferDesc structure that contains the output buffer descriptor. This buffer is sent to the client for input
		/// into additional calls to InitializeSecurityContext (CredSSP). An output buffer may be generated even if the function returns
		/// SEC_E_OK. Any buffer generated must be sent back to the client application.
		/// </para>
		/// <para>
		/// On output, this buffer receives a token for the security context. The token must be sent to the client. The function can also
		/// return a buffer of type SECBUFFER_EXTRA.
		/// </para>
		/// </param>
		/// <param name="pfContextAttr">
		/// <para>
		/// A pointer to a set of bit flags that indicate the attributes of the established context. For a description of the various
		/// attributes, see Context Requirements. Flags used for this parameter are prefixed with ASC_RET, for example, ASC_RET_DELEGATE.
		/// </para>
		/// <para>
		/// Do not check for security-related attributes until the final function call returns successfully. Attribute flags not related to
		/// security, such as the ASC_RET_ALLOCATED_MEMORY flag, can be checked before the final return.
		/// </para>
		/// </param>
		/// <param name="ptsTimeStamp">The PTS time stamp.</param>
		/// <returns>
		/// <para>This function returns one of the following values.</para>
		/// <list type="table">
		/// <listheader>
		/// <term>Return code/value</term>
		/// <term>Description</term>
		/// </listheader>
		/// <item>
		/// <term>SEC_E_INCOMPLETE_MESSAGE 0x80090318L</term>
		/// <term>
		/// The function succeeded. The data in the input buffer is incomplete. The application must read additional data from the client and
		/// call AcceptSecurityContext (CredSSP) again.
		/// </term>
		/// </item>
		/// <item>
		/// <term>SEC_E_INSUFFICIENT_MEMORY 0x80090300L</term>
		/// <term>The function failed. There is not enough memory available to complete the requested action.</term>
		/// </item>
		/// <item>
		/// <term>SEC_E_INTERNAL_ERROR 0x80090304L</term>
		/// <term>The function failed. An error occurred that did not map to an SSPI error code.</term>
		/// </item>
		/// <item>
		/// <term>SEC_E_INVALID_HANDLE 0x80100003L</term>
		/// <term>The function failed. The handle passed to the function is not valid.</term>
		/// </item>
		/// <item>
		/// <term>SEC_E_INVALID_TOKEN 0x80090308L</term>
		/// <term>The function failed. The token passed to the function is not valid.</term>
		/// </item>
		/// <item>
		/// <term>SEC_E_LOGON_DENIED 0x8009030CL</term>
		/// <term>The logon failed.</term>
		/// </item>
		/// <item>
		/// <term>SEC_E_NO_AUTHENTICATING_AUTHORITY 0x80090311L</term>
		/// <term>The function failed. No authority could be contacted for authentication. This could be due to the following conditions:</term>
		/// </item>
		/// <item>
		/// <term>SEC_E_NO_CREDENTIALS 0x8009030EL</term>
		/// <term>The function failed. The credentials handle specified in the phCredential parameter is not valid.</term>
		/// </item>
		/// <item>
		/// <term>SEC_E_OK 0x00000000L</term>
		/// <term>
		/// The function succeeded. The security context received from the client was accepted. If the function generated an output token,
		/// the token must be sent to the client process.
		/// </term>
		/// </item>
		/// <item>
		/// <term>SEC_E_UNSUPPORTED_FUNCTION 0x80090302L</term>
		/// <term>
		/// The function failed. The fContextReq parameter specified a context attribute flag (ASC_REQ_DELEGATE or ASC_REQ_PROMPT_FOR_CREDS)
		/// that was not valid.
		/// </term>
		/// </item>
		/// <item>
		/// <term>SEC_I_COMPLETE_AND_CONTINUE 0x00090314L</term>
		/// <term>
		/// The function succeeded. The server must call CompleteAuthToken and pass the output token to the client. The server must then wait
		/// for a return token from the client before making another call to AcceptSecurityContext (CredSSP).
		/// </term>
		/// </item>
		/// <item>
		/// <term>SEC_I_COMPLETE_NEEDED 0x00090313L</term>
		/// <term>The function succeeded. The server must finish building the message from the client before calling CompleteAuthToken.</term>
		/// </item>
		/// <item>
		/// <term>SEC_I_CONTINUE_NEEDED 0x00090312L</term>
		/// <term>
		/// The function succeeded. The server must send the output token to the client and wait for a returned token. The returned token
		/// should be passed in pInput for another call to AcceptSecurityContext (CredSSP).
		/// </term>
		/// </item>
		/// </list>
		/// </returns>
		/// <remarks>
		/// <para>
		/// The <c>AcceptSecurityContext (CredSSP)</c> function is the server counterpart to the InitializeSecurityContext (CredSSP) function.
		/// </para>
		/// <para>
		/// When the server receives a request from a client, it uses the fContextReq parameter to specify what it requires of the session.
		/// In this fashion, a server can require that clients be capable of using a confidential or integrity-checked session; it can reject
		/// clients that cannot meet that demand. Alternatively, a server can require nothing; whatever the client requires or can provide is
		/// returned in the pfContextAttr parameter.
		/// </para>
		/// <para>
		/// The fContextReq and pfContextAttr parameters are bitmasks that represent various context attributes. For a description of the
		/// various attributes, see Context Requirements.
		/// </para>
		/// <para>
		/// <c>Note</c> While the pfContextAttr parameter is valid on any successful return, you should examine the flags pertaining to
		/// security aspects of the context only on the final successful return. Intermediate returns can set, for example, the
		/// ISC_RET_ALLOCATED_MEMORY flag.
		/// </para>
		/// <para>
		/// The caller is responsible for determining whether the final context attributes are sufficient. For example, if confidentiality
		/// (encryption) was requested but could not be established, some applications may choose to shut down the connection immediately. If
		/// the security context cannot be established, the server must free the partially created context by calling the
		/// DeleteSecurityContext function. For information about when to call the <c>DeleteSecurityContext</c> function, see <c>DeleteSecurityContext</c>.\
		/// </para>
		/// <para>
		/// After the security context has been established, the server application can use the QuerySecurityContextToken function to
		/// retrieve a handle to the user account to which the client certificate was mapped. Also, the server can use the
		/// ImpersonateSecurityContext function to impersonate the user.
		/// </para>
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows/desktop/api/sspi/nf-sspi-acceptsecuritycontext KSECDDDECLSPEC SECURITY_STATUS SEC_ENTRY
		// AcceptSecurityContext( PCredHandle phCredential, PCtxtHandle phContext, PSecBufferDesc pInput, unsigned long fContextReq, unsigned
		// long TargetDataRep, PCtxtHandle phNewContext, PSecBufferDesc pOutput, unsigned long *pfContextAttr, PTimeStamp ptsExpiry );
		[DllImport(Lib.Secur32, SetLastError = false, ExactSpelling = true)]
		[PInvokeData("sspi.h", MSDNShortId = "a53f733e-b646-4431-b021-a2c446308849")]
		public static unsafe extern HRESULT AcceptSecurityContext([Optional] CredHandle* phCredential, CtxtHandle* phContext, [In, Optional] SecBufferDesc* pInput, ASC_REQ fContextReq, DREP TargetDataRep,
			out CtxtHandle phNewContext, [Optional] SecBufferDesc* pOutput, out ASC_RET pfContextAttr, out TimeStamp ptsTimeStamp);

		/// <summary>
		/// <para>
		/// The <c>AcquireCredentialsHandle (CredSSP)</c> function acquires a handle to preexisting credentials of a security principal. This
		/// handle is required by the InitializeSecurityContext (CredSSP) and AcceptSecurityContext (CredSSP) functions. These can be either
		/// preexisting credentials, which are established through a system logon that is not described here, or the caller can provide
		/// alternative credentials.
		/// </para>
		/// <para><c>Note</c> This is not a "log on to the network" and does not imply gathering of credentials.</para>
		/// </summary>
		/// <param name="pszPrincipal">
		/// <para>A pointer to a null-terminated string that specifies the name of the principal whose credentials the handle will reference.</para>
		/// <para>
		/// <c>Note</c> If the process that requests the handle does not have access to the credentials, the function returns an error. A
		/// null string indicates that the process requires a handle to the credentials of the user under whose security context it is executing.
		/// </para>
		/// </param>
		/// <param name="pszPackage">
		/// A pointer to a null-terminated string that specifies the name of the security package with which these credentials will be used.
		/// This is a security package name returned in the <c>Name</c> member of a SecPkgInfo structure returned by the
		/// EnumerateSecurityPackages function. After a context is established, QueryContextAttributes (CredSSP) can be called with
		/// ulAttribute set to <c>SECPKG_ATTR_PACKAGE_INFO</c> to return information on the security package in use.
		/// </param>
		/// <param name="fCredentialUse">
		/// <para>A flag that indicates how these credentials will be used. This parameter can be one of the following values.</para>
		/// <list type="table">
		/// <listheader>
		/// <term>Value</term>
		/// <term>Meaning</term>
		/// </listheader>
		/// <item>
		/// <term>SECPKG_CRED_INBOUND 0x1</term>
		/// <term>
		/// Validate an incoming server credential. Inbound credentials might be validated by using an authenticating authority when
		/// InitializeSecurityContext (CredSSP) or AcceptSecurityContext (CredSSP) is called. If such an authority is not available, the
		/// function will fail and return SEC_E_NO_AUTHENTICATING_AUTHORITY. Validation is package specific.
		/// </term>
		/// </item>
		/// <item>
		/// <term>SECPKG_CRED_OUTBOUND 0x0</term>
		/// <term>Allow a local client credential to prepare an outgoing token.</term>
		/// </item>
		/// </list>
		/// </param>
		/// <param name="pvLogonId">
		/// A pointer to a locally unique identifier (LUID) that identifies the user. This parameter is provided for file-system processes
		/// such as network redirectors. This parameter can be <c>NULL</c>.
		/// </param>
		/// <param name="pAuthData">
		/// A pointer to a CREDSSP_CRED structure that specifies authentication data for both Schannel and Negotiate packages.
		/// </param>
		/// <param name="pGetKeyFn">Reserved. This parameter is not used and should be set to <c>NULL</c>.</param>
		/// <param name="pvGetKeyArgument">Reserved. This parameter must be set to <c>NULL</c>.</param>
		/// <param name="phCredential">A pointer to the CredHandle structure that will receive the credential handle.</param>
		/// <param name="ptsExpiry">
		/// A pointer to a TimeStamp structure that receives the time at which the returned credentials expire. The structure value received
		/// depends on the security package, which must specify the value in local time.
		/// </param>
		/// <returns>
		/// <para>If the function succeeds, it returns <c>SEC_E_OK</c>.</para>
		/// <para>If the function fails, it returns one of the following error codes.</para>
		/// <list type="table">
		/// <listheader>
		/// <term>Return code</term>
		/// <term>Description</term>
		/// </listheader>
		/// <item>
		/// <term>SEC_E_INSUFFICIENT_MEMORY</term>
		/// <term>There is insufficient memory available to complete the requested action.</term>
		/// </item>
		/// <item>
		/// <term>SEC_E_INTERNAL_ERROR</term>
		/// <term>An error occurred that did not map to an SSPI error code.</term>
		/// </item>
		/// <item>
		/// <term>SEC_E_NO_CREDENTIALS</term>
		/// <term>No credentials are available in the security package.</term>
		/// </item>
		/// <item>
		/// <term>SEC_E_NOT_OWNER</term>
		/// <term>The caller of the function does not have the necessary credentials.</term>
		/// </item>
		/// <item>
		/// <term>SEC_E_SECPKG_NOT_FOUND</term>
		/// <term>The requested security package does not exist.</term>
		/// </item>
		/// <item>
		/// <term>SEC_E_UNKNOWN_CREDENTIALS</term>
		/// <term>The credentials supplied to the package were not recognized.</term>
		/// </item>
		/// </list>
		/// </returns>
		/// <remarks>
		/// <para>
		/// The <c>AcquireCredentialsHandle (CredSSP)</c> function returns a handle to the credentials of a principal, such as a user or
		/// client, as used by a specific security package. The function can return the handle to either preexisting credentials or newly
		/// created credentials and return it. This handle can be used in subsequent calls to the AcceptSecurityContext (CredSSP) and
		/// InitializeSecurityContext (CredSSP) functions.
		/// </para>
		/// <para>
		/// In general, <c>AcquireCredentialsHandle (CredSSP)</c> does not provide the credentials of other users logged on to the same
		/// computer. However, a caller with SE_TCB_NAME privilege can obtain the credentials of an existing logon session by specifying the
		/// logon identifier (LUID) of that session. Typically, this is used by kernel-mode modules that must act on behalf of a logged-on user.
		/// </para>
		/// <para>
		/// A package might call the function in pGetKeyFn provided by the RPC run-time transport. If the transport does not support the
		/// notion of callback to retrieve credentials, this parameter must be <c>NULL</c>.
		/// </para>
		/// <para>For kernel mode callers, the following differences must be noted:</para>
		/// <list type="bullet">
		/// <item>
		/// <term>The two string parameters must be Unicode strings.</term>
		/// </item>
		/// <item>
		/// <term>The buffer values must be allocated in process virtual memory, not from the pool.</term>
		/// </item>
		/// </list>
		/// <para>
		/// When you have finished using the returned credentials, free the memory used by the credentials by calling the
		/// FreeCredentialsHandle function.
		/// </para>
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows/desktop/api/sspi/nf-sspi-acquirecredentialshandlea SECURITY_STATUS SEC_ENTRY
		// AcquireCredentialsHandleA( LPSTR pszPrincipal, LPSTR pszPackage, unsigned long fCredentialUse, void *pvLogonId, void *pAuthData,
		// SEC_GET_KEY_FN pGetKeyFn, void *pvGetKeyArgument, PCredHandle phCredential, PTimeStamp ptsExpiry );
		[DllImport(Lib.Secur32, SetLastError = false, CharSet = CharSet.Auto)]
		[PInvokeData("sspi.h", MSDNShortId = "3b73decf-75d4-4bc4-b7ca-5f16aaadff29")]
		public static extern HRESULT AcquireCredentialsHandle([Optional] string pszPrincipal, string pszPackage, SECPKG_CRED fCredentialUse, [In, Optional] IntPtr pvLogonId, [In, Optional] IntPtr pAuthData, [In, Optional] IntPtr pGetKeyFn,
			[In, Optional] IntPtr pvGetKeyArgument, out CredHandle phCredential, out TimeStamp ptsExpiry);

		/// <summary>
		/// <para>
		/// The <c>AcquireCredentialsHandle (CredSSP)</c> function acquires a handle to preexisting credentials of a security principal. This
		/// handle is required by the InitializeSecurityContext (CredSSP) and AcceptSecurityContext (CredSSP) functions. These can be either
		/// preexisting credentials, which are established through a system logon that is not described here, or the caller can provide
		/// alternative credentials.
		/// </para>
		/// <para><c>Note</c> This is not a "log on to the network" and does not imply gathering of credentials.</para>
		/// </summary>
		/// <param name="pszPrincipal">
		/// <para>A pointer to a null-terminated string that specifies the name of the principal whose credentials the handle will reference.</para>
		/// <para>
		/// <c>Note</c> If the process that requests the handle does not have access to the credentials, the function returns an error. A
		/// null string indicates that the process requires a handle to the credentials of the user under whose security context it is executing.
		/// </para>
		/// </param>
		/// <param name="pszPackage">
		/// A pointer to a null-terminated string that specifies the name of the security package with which these credentials will be used.
		/// This is a security package name returned in the <c>Name</c> member of a SecPkgInfo structure returned by the
		/// EnumerateSecurityPackages function. After a context is established, QueryContextAttributes (CredSSP) can be called with
		/// ulAttribute set to <c>SECPKG_ATTR_PACKAGE_INFO</c> to return information on the security package in use.
		/// </param>
		/// <param name="fCredentialUse">
		/// <para>A flag that indicates how these credentials will be used. This parameter can be one of the following values.</para>
		/// <list type="table">
		/// <listheader>
		/// <term>Value</term>
		/// <term>Meaning</term>
		/// </listheader>
		/// <item>
		/// <term>SECPKG_CRED_INBOUND 0x1</term>
		/// <term>
		/// Validate an incoming server credential. Inbound credentials might be validated by using an authenticating authority when
		/// InitializeSecurityContext (CredSSP) or AcceptSecurityContext (CredSSP) is called. If such an authority is not available, the
		/// function will fail and return SEC_E_NO_AUTHENTICATING_AUTHORITY. Validation is package specific.
		/// </term>
		/// </item>
		/// <item>
		/// <term>SECPKG_CRED_OUTBOUND 0x0</term>
		/// <term>Allow a local client credential to prepare an outgoing token.</term>
		/// </item>
		/// </list>
		/// </param>
		/// <param name="pvLogonId">
		/// A pointer to a locally unique identifier (LUID) that identifies the user. This parameter is provided for file-system processes
		/// such as network redirectors. This parameter can be <c>NULL</c>.
		/// </param>
		/// <param name="pAuthData">
		/// A pointer to a CREDSSP_CRED structure that specifies authentication data for both Schannel and Negotiate packages.
		/// </param>
		/// <param name="pGetKeyFn">Reserved. This parameter is not used and should be set to <c>NULL</c>.</param>
		/// <param name="pvGetKeyArgument">Reserved. This parameter must be set to <c>NULL</c>.</param>
		/// <param name="phCredential">A pointer to the CredHandle structure that will receive the credential handle.</param>
		/// <param name="ptsExpiry">
		/// A pointer to a TimeStamp structure that receives the time at which the returned credentials expire. The structure value received
		/// depends on the security package, which must specify the value in local time.
		/// </param>
		/// <returns>
		/// <para>If the function succeeds, it returns <c>SEC_E_OK</c>.</para>
		/// <para>If the function fails, it returns one of the following error codes.</para>
		/// <list type="table">
		/// <listheader>
		/// <term>Return code</term>
		/// <term>Description</term>
		/// </listheader>
		/// <item>
		/// <term>SEC_E_INSUFFICIENT_MEMORY</term>
		/// <term>There is insufficient memory available to complete the requested action.</term>
		/// </item>
		/// <item>
		/// <term>SEC_E_INTERNAL_ERROR</term>
		/// <term>An error occurred that did not map to an SSPI error code.</term>
		/// </item>
		/// <item>
		/// <term>SEC_E_NO_CREDENTIALS</term>
		/// <term>No credentials are available in the security package.</term>
		/// </item>
		/// <item>
		/// <term>SEC_E_NOT_OWNER</term>
		/// <term>The caller of the function does not have the necessary credentials.</term>
		/// </item>
		/// <item>
		/// <term>SEC_E_SECPKG_NOT_FOUND</term>
		/// <term>The requested security package does not exist.</term>
		/// </item>
		/// <item>
		/// <term>SEC_E_UNKNOWN_CREDENTIALS</term>
		/// <term>The credentials supplied to the package were not recognized.</term>
		/// </item>
		/// </list>
		/// </returns>
		/// <remarks>
		/// <para>
		/// The <c>AcquireCredentialsHandle (CredSSP)</c> function returns a handle to the credentials of a principal, such as a user or
		/// client, as used by a specific security package. The function can return the handle to either preexisting credentials or newly
		/// created credentials and return it. This handle can be used in subsequent calls to the AcceptSecurityContext (CredSSP) and
		/// InitializeSecurityContext (CredSSP) functions.
		/// </para>
		/// <para>
		/// In general, <c>AcquireCredentialsHandle (CredSSP)</c> does not provide the credentials of other users logged on to the same
		/// computer. However, a caller with SE_TCB_NAME privilege can obtain the credentials of an existing logon session by specifying the
		/// logon identifier (LUID) of that session. Typically, this is used by kernel-mode modules that must act on behalf of a logged-on user.
		/// </para>
		/// <para>
		/// A package might call the function in pGetKeyFn provided by the RPC run-time transport. If the transport does not support the
		/// notion of callback to retrieve credentials, this parameter must be <c>NULL</c>.
		/// </para>
		/// <para>For kernel mode callers, the following differences must be noted:</para>
		/// <list type="bullet">
		/// <item>
		/// <term>The two string parameters must be Unicode strings.</term>
		/// </item>
		/// <item>
		/// <term>The buffer values must be allocated in process virtual memory, not from the pool.</term>
		/// </item>
		/// </list>
		/// <para>
		/// When you have finished using the returned credentials, free the memory used by the credentials by calling the
		/// FreeCredentialsHandle function.
		/// </para>
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows/desktop/api/sspi/nf-sspi-acquirecredentialshandlea SECURITY_STATUS SEC_ENTRY
		// AcquireCredentialsHandleA( LPSTR pszPrincipal, LPSTR pszPackage, unsigned long fCredentialUse, void *pvLogonId, void *pAuthData,
		// SEC_GET_KEY_FN pGetKeyFn, void *pvGetKeyArgument, PCredHandle phCredential, PTimeStamp ptsExpiry );
		[DllImport(Lib.Secur32, SetLastError = false, CharSet = CharSet.Auto)]
		[PInvokeData("sspi.h", MSDNShortId = "3b73decf-75d4-4bc4-b7ca-5f16aaadff29")]
		public static extern HRESULT AcquireCredentialsHandle([Optional] string pszPrincipal, string pszPackage, SECPKG_CRED fCredentialUse, in LUID pvLogonId, in CREDSSP_CRED pAuthData, [In, Optional] SEC_GET_KEY_FN pGetKeyFn,
			[In, Optional] IntPtr pvGetKeyArgument, out CredHandle phCredential, out TimeStamp ptsExpiry);

		/// <summary>Adds a security support provider to the list of providers supported by Microsoft Negotiate.</summary>
		/// <param name="pszPackageName">The name of the package to add.</param>
		/// <param name="pOptions">
		/// A pointer to a SECURITY_PACKAGE_OPTIONS structure that specifies additional information about the security package.
		/// </param>
		/// <returns>
		/// <para>If the function succeeds, it returns <c>SEC_E_OK</c>.</para>
		/// <para>If the function fails, it returns a nonzero error code.</para>
		/// </returns>
		// https://docs.microsoft.com/en-us/windows/desktop/api/sspi/nf-sspi-addsecuritypackagea SECURITY_STATUS SEC_ENTRY
		// AddSecurityPackageA( LPSTR pszPackageName, PSECURITY_PACKAGE_OPTIONS pOptions );
		[DllImport(Lib.Secur32, SetLastError = false, CharSet = CharSet.Auto)]
		[PInvokeData("sspi.h", MSDNShortId = "35b993d2-87a0-46d0-991f-88358b0cc5e6")]
		public static extern HRESULT AddSecurityPackage(string pszPackageName, in SECURITY_PACKAGE_OPTIONS pOptions);

		/// <summary>Adds a security support provider to the list of providers supported by Microsoft Negotiate.</summary>
		/// <param name="pszPackageName">The name of the package to add.</param>
		/// <param name="pOptions">
		/// A pointer to a SECURITY_PACKAGE_OPTIONS structure that specifies additional information about the security package.
		/// </param>
		/// <returns>
		/// <para>If the function succeeds, it returns <c>SEC_E_OK</c>.</para>
		/// <para>If the function fails, it returns a nonzero error code.</para>
		/// </returns>
		// https://docs.microsoft.com/en-us/windows/desktop/api/sspi/nf-sspi-addsecuritypackagea SECURITY_STATUS SEC_ENTRY
		// AddSecurityPackageA( LPSTR pszPackageName, PSECURITY_PACKAGE_OPTIONS pOptions );
		[DllImport(Lib.Secur32, SetLastError = false, CharSet = CharSet.Auto)]
		[PInvokeData("sspi.h", MSDNShortId = "35b993d2-87a0-46d0-991f-88358b0cc5e6")]
		public static extern HRESULT AddSecurityPackage(string pszPackageName, [Optional] IntPtr pOptions);

		/// <summary>
		/// <para>
		/// The <c>ApplyControlToken</c> function provides a way to apply a control token to a security context. A token can be received when
		/// the security context is being established by a call to the InitializeSecurityContext (Schannel) function or with a per-message
		/// security service, such as verify or unseal.
		/// </para>
		/// <para>This function is supported only by the Schannel security support provider (SSP).</para>
		/// <para>This function is not supported in kernel mode.</para>
		/// <para>This function allows additional or replacement tokens to be applied to a context.</para>
		/// </summary>
		/// <param name="phContext">
		/// <para>A handle to the context to which the token is applied.</para>
		/// <para>
		/// For information about the way the Schannel SSP notifies the remote party of the shutdown, see the Remarks section of
		/// DecryptMessage (Schannel). For additional information on the use of this function, see Shutting Down an Schannel Connection.
		/// </para>
		/// </param>
		/// <param name="pInput">
		/// A pointer to a SecBufferDesc structure that contains a pointer to a SecBuffer structure that contains the input token to apply to
		/// the context.
		/// </param>
		/// <returns>
		/// <para>If the function succeeds, the function returns SEC_E_OK.</para>
		/// <para>
		/// If the function fails, it returns a nonzero error code. The following error code is one of the possible error codes that can be returned.
		/// </para>
		/// <list type="table">
		/// <listheader>
		/// <term>Return code</term>
		/// <term>Description</term>
		/// </listheader>
		/// <item>
		/// <term>SEC_E_UNSUPPORTED_FUNCTION</term>
		/// <term>This value is returned by Schannel kernel mode to indicate that this function is not supported.</term>
		/// </item>
		/// </list>
		/// </returns>
		/// <remarks>
		/// <para>
		/// The <c>ApplyControlToken</c> function can modify the context based on this token. Among the tokens that this function can add to
		/// the client context are SCHANNEL_ALERT_TOKEN and SCHANNEL_SESSION_TOKEN.
		/// </para>
		/// <para>
		/// This function can be used to shut down the security context that underlies an existing Schannel connection. For information about
		/// how to do this, see Shutting Down an Schannel Connection.
		/// </para>
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows/desktop/api/sspi/nf-sspi-applycontroltoken KSECDDDECLSPEC SECURITY_STATUS SEC_ENTRY
		// ApplyControlToken( PCtxtHandle phContext, PSecBufferDesc pInput );
		[DllImport(Lib.Secur32, SetLastError = false, ExactSpelling = true)]
		[PInvokeData("sspi.h", MSDNShortId = "5ce13a05-874c-4e1a-9be8-aed98609791e")]
		public static extern HRESULT ApplyControlToken(in CtxtHandle phContext, in SecBufferDesc pInput);

		/// <summary>
		/// <para>
		/// The <c>ChangeAccountPassword</c> function changes the password for a Windows domain account by using the specified Security
		/// Support Provider.
		/// </para>
		/// <para>This function is supported only by the Microsoft Kerberos, Microsoft Negotiate, and Microsoft NTLM providers.</para>
		/// </summary>
		/// <param name="pszPackageName">
		/// The name of the provider to use. The value of this parameter must be either "Kerberos", "Negotiate", or "NTLM".
		/// </param>
		/// <param name="pszDomainName">The domain of the account for which to change the password.</param>
		/// <param name="pszAccountName">The user name of the account for which to change the password.</param>
		/// <param name="pszOldPassword">The old password to be changed.</param>
		/// <param name="pszNewPassword">The new password for the specified account.</param>
		/// <param name="bImpersonating"><c>TRUE</c> if the calling process is running as the client; otherwise, <c>FALSE</c>.</param>
		/// <param name="dwReserved">Reserved. Must be set to zero.</param>
		/// <param name="pOutput">
		/// On input, a pointer to a SecBufferDesc structure. The <c>SecBufferDesc</c> structure must contain a single buffer of type
		/// <c>SECBUFFER_CHANGE_PASS_RESPONSE</c>. On output, the <c>pvBuffer</c> member of that structure points to a
		/// DOMAIN_PASSWORD_INFORMATION structure.
		/// </param>
		/// <returns>
		/// <para>If the function succeeds, the function returns SEC_E_OK.</para>
		/// <para>If the function fails, it returns an error code.</para>
		/// </returns>
		// https://docs.microsoft.com/en-us/windows/desktop/api/sspi/nf-sspi-changeaccountpassworda SECURITY_STATUS SEC_ENTRY
		// ChangeAccountPasswordA( SEC_CHAR *pszPackageName, SEC_CHAR *pszDomainName, SEC_CHAR *pszAccountName, SEC_CHAR *pszOldPassword,
		// SEC_CHAR *pszNewPassword, BOOLEAN bImpersonating, unsigned long dwReserved, PSecBufferDesc pOutput );
		[DllImport(Lib.Secur32, SetLastError = false, CharSet = CharSet.Auto)]
		[PInvokeData("sspi.h", MSDNShortId = "a1d1e315-d1a2-499a-b552-83180508271f")]
		public static extern HRESULT ChangeAccountPassword(string pszPackageName, string pszDomainName, string pszAccountName, string pszOldPassword, string pszNewPassword, [MarshalAs(UnmanagedType.U1)] bool bImpersonating,
			[Optional] uint dwReserved, ref SecBufferDesc pOutput);

		/// <summary>
		/// <para>
		/// The <c>CompleteAuthToken</c> function completes an authentication token. This function is used by protocols, such as DCE, that
		/// need to revise the security information after the transport application has updated some message parameters.
		/// </para>
		/// <para>This function is supported only by the Digest security support provider (SSP).</para>
		/// <para><c>CompleteAuthToken</c> is used on the server side only.</para>
		/// </summary>
		/// <param name="phContext">A handle of the context that needs to be completed.</param>
		/// <param name="pToken">A pointer to a SecBufferDesc structure that contains the buffer descriptor for the entire message.</param>
		/// <returns>
		/// <para>If the function succeeds, the function returns SEC_E_OK.</para>
		/// <para>If the function fails, it returns one of the following error codes.</para>
		/// <list type="table">
		/// <listheader>
		/// <term>Return code</term>
		/// <term>Description</term>
		/// </listheader>
		/// <item>
		/// <term>SEC_E_INVALID_HANDLE</term>
		/// <term>The handle that was passed to the function is not valid.</term>
		/// </item>
		/// <item>
		/// <term>SEC_E_INVALID_TOKEN</term>
		/// <term>The token that was passed to the function is not valid.</term>
		/// </item>
		/// <item>
		/// <term>SEC_E_OUT_OF_SEQUENCE</term>
		/// <term>
		/// The client's security context was located, but the message number is incorrect. This return value is used with the Digest SSP.
		/// </term>
		/// </item>
		/// <item>
		/// <term>SEC_E_MESSAGE_ALTERED</term>
		/// <term>
		/// The client's security context was located, but the client's message has been tampered with. This return value is used with the
		/// Digest SSP.
		/// </term>
		/// </item>
		/// <item>
		/// <term>SEC_E_INTERNAL_ERROR</term>
		/// <term>An error occurred that did not map to an SSPI error code.</term>
		/// </item>
		/// </list>
		/// </returns>
		/// <remarks>
		/// The client of a transport application calls the <c>CompleteAuthToken</c> function to allow the security package to update a
		/// checksum or similar operation after all the protocol headers have been updated by the transport application. The client calls
		/// this function only if the InitializeSecurityContext (Digest) call returned SEC_I_COMPLETE_NEEDED or SEC_I_COMPLETE_AND_CONTINUE.
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows/desktop/api/sspi/nf-sspi-completeauthtoken SECURITY_STATUS SEC_ENTRY CompleteAuthToken(
		// PCtxtHandle phContext, PSecBufferDesc pToken );
		[DllImport(Lib.Secur32, SetLastError = false, ExactSpelling = true)]
		[PInvokeData("sspi.h", MSDNShortId = "a404d0a3-d1ea-4708-87d7-2d216e9a5f5f")]
		public static extern HRESULT CompleteAuthToken(in CtxtHandle phContext, in SecBufferDesc pToken);

		/// <summary>
		/// <para>
		/// The <c>DecryptMessage (Digest)</c> function decrypts a message. Some packages do not encrypt and decrypt messages but rather
		/// perform and check an integrity hash.
		/// </para>
		/// <para>
		/// The Digest security support provider (SSP) provides encryption and decryption confidentiality for messages exchanged between
		/// client and server as a SASL mechanism only.
		/// </para>
		/// <para>
		/// <c>Note</c> EncryptMessage (Digest) and <c>DecryptMessage (Digest)</c> can be called at the same time from two different threads
		/// in a single Security Support Provider Interface (SSPI) context if one thread is encrypting and the other is decrypting. If more
		/// than one thread is encrypting, or more than one thread is decrypting, each thread should obtain a unique context.
		/// </para>
		/// </summary>
		/// <param name="phContext">A handle to the security context to be used to decrypt the message.</param>
		/// <param name="pMessage">
		/// <para>
		/// A pointer to a SecBufferDesc structure. On input, the structure references one or more SecBuffer structures. At least one of
		/// these must be of type SECBUFFER_DATA. That buffer contains the encrypted message. The encrypted message is decrypted in place,
		/// overwriting the original contents of its buffer.
		/// </para>
		/// <para>
		/// When using the Digest SSP, on input, the structure references one or more SecBuffer structures. One of these must be of type
		/// SECBUFFER_DATA or SECBUFFER_STREAM, and it must contain the encrypted message.
		/// </para>
		/// </param>
		/// <param name="MessageSeqNo">
		/// <para>
		/// The sequence number expected by the transport application, if any. If the transport application does not maintain sequence
		/// numbers, this parameter must be set to zero.
		/// </para>
		/// <para>When using the Digest SSP, this parameter must be set to zero. The Digest SSP manages sequence numbering internally.</para>
		/// </param>
		/// <param name="pfQOP">
		/// <para>A pointer to a variable of type <c>ULONG</c> that receives package-specific flags that indicate the quality of protection.</para>
		/// <para>This parameter can be one of the following flags.</para>
		/// <list type="table">
		/// <listheader>
		/// <term>Value</term>
		/// <term>Meaning</term>
		/// </listheader>
		/// <item>
		/// <term>SECQOP_WRAP_NO_ENCRYPT</term>
		/// <term>The message was not encrypted, but a header or trailer was produced.</term>
		/// </item>
		/// <item>
		/// <term>SIGN_ONLY</term>
		/// <term>
		/// When using the Digest SSP, use this flag when the security context is set to verify the signature only. For more information, see
		/// Quality of Protection.
		/// </term>
		/// </item>
		/// </list>
		/// </param>
		/// <returns>
		/// <para>If the function verifies that the message was received in the correct sequence, the function returns SEC_E_OK.</para>
		/// <para>If the function fails to decrypt the message, it returns one of the following error codes.</para>
		/// <list type="table">
		/// <listheader>
		/// <term>Return code</term>
		/// <term>Description</term>
		/// </listheader>
		/// <item>
		/// <term>SEC_E_BUFFER_TOO_SMALL</term>
		/// <term>The message buffer is too small. Used with the Digest SSP.</term>
		/// </item>
		/// <item>
		/// <term>SEC_E_CRYPTO_SYSTEM_INVALID</term>
		/// <term>The cipher chosen for the security context is not supported. Used with the Digest SSP.</term>
		/// </item>
		/// <item>
		/// <term>SEC_E_INCOMPLETE_MESSAGE</term>
		/// <term>
		/// The data in the input buffer is incomplete. The application needs to read more data from the server and call DecryptMessage
		/// (Digest) again.
		/// </term>
		/// </item>
		/// <item>
		/// <term>SEC_E_INVALID_HANDLE</term>
		/// <term>A context handle that is not valid was specified in the phContext parameter. Used with the Digest SSP.</term>
		/// </item>
		/// <item>
		/// <term>SEC_E_MESSAGE_ALTERED</term>
		/// <term>The message has been altered. Used with the Digest SSP.</term>
		/// </item>
		/// <item>
		/// <term>SEC_E_OUT_OF_SEQUENCE</term>
		/// <term>The message was not received in the correct sequence.</term>
		/// </item>
		/// <item>
		/// <term>SEC_E_QOP_NOT_SUPPORTED</term>
		/// <term>Neither confidentiality nor integrity are supported by the security context. Used with the Digest SSP.</term>
		/// </item>
		/// </list>
		/// </returns>
		/// <remarks>
		/// <para>
		/// Sometimes an application will read data from the remote party, attempt to decrypt it by using <c>DecryptMessage (Digest)</c>, and
		/// discover that <c>DecryptMessage (Digest)</c> succeeded but the output buffers are empty. This is normal behavior, and
		/// applications must be able to deal with it.
		/// </para>
		/// <para>
		/// <c>Windows XP:</c> This function was also known as <c>UnsealMessage</c>. Applications should now use <c>DecryptMessage
		/// (Digest)</c> only.
		/// </para>
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows/desktop/api/sspi/nf-sspi-decryptmessage SECURITY_STATUS SEC_ENTRY DecryptMessage(
		// PCtxtHandle phContext, PSecBufferDesc pMessage, unsigned long MessageSeqNo, unsigned long *pfQOP );
		[DllImport(Lib.Secur32, SetLastError = false, ExactSpelling = true)]
		[PInvokeData("sspi.h", MSDNShortId = "46d45f59-33fa-434a-b329-20b6257c9a19")]
		public static extern HRESULT DecryptMessage(in CtxtHandle phContext, ref SecBufferDesc pMessage, uint MessageSeqNo, out SECQOP pfQOP);

		/// <summary>
		/// The <c>DeleteSecurityContext</c> function deletes the local data structures associated with the specified security context
		/// initiated by a previous call to the InitializeSecurityContext (General) function or the AcceptSecurityContext (General) function.
		/// </summary>
		/// <param name="phContext">Handle of the security context to delete.</param>
		/// <returns>
		/// <para>If the function succeeds or the handle has already been deleted, the return value is <c>SEC_E_OK</c>.</para>
		/// <para>If the function fails, the return value can be the following error code.</para>
		/// <list type="table">
		/// <listheader>
		/// <term>Return code</term>
		/// <term>Description</term>
		/// </listheader>
		/// <item>
		/// <term>SEC_E_INVALID_HANDLE</term>
		/// <term>The handle passed to the function is not valid.</term>
		/// </item>
		/// </list>
		/// </returns>
		/// <remarks>
		/// <para>The <c>DeleteSecurityContext</c> function terminates a security context and frees associated resources.</para>
		/// <para>
		/// The caller must call this function for a security context when that security context is no longer needed. This is true if the
		/// security context is partial, incomplete, rejected, or failed. After the security context is successfully deleted, further use of
		/// that security context is not permitted and the handle is no longer valid.
		/// </para>
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows/desktop/api/sspi/nf-sspi-deletesecuritycontext KSECDDDECLSPEC SECURITY_STATUS SEC_ENTRY
		// DeleteSecurityContext( PCtxtHandle phContext );
		[DllImport(Lib.Secur32, SetLastError = false, ExactSpelling = true)]
		[PInvokeData("sspi.h", MSDNShortId = "2a4dd697-ef90-4c37-ab74-0e5ab92794cd")]
		public static extern HRESULT DeleteSecurityContext(in CtxtHandle phContext);

		/// <summary>Deletes a security support provider from the list of providers supported by Microsoft Negotiate.</summary>
		/// <param name="pszPackageName">The name of the security provider to delete.</param>
		/// <returns>
		/// <para>If the function succeeds, it returns <c>SEC_E_OK</c>.</para>
		/// <para>If the function fails, it returns a nonzero error code.</para>
		/// </returns>
		// https://docs.microsoft.com/en-us/windows/desktop/api/sspi/nf-sspi-deletesecuritypackagea SECURITY_STATUS SEC_ENTRY
		// DeleteSecurityPackageA( LPSTR pszPackageName );
		[DllImport(Lib.Secur32, SetLastError = false, CharSet = CharSet.Auto)]
		[PInvokeData("sspi.h", MSDNShortId = "7a9a2c64-92a4-419b-8b20-d0f5cba64147")]
		public static extern HRESULT DeleteSecurityPackage(string pszPackageName);

		/// <summary>
		/// <para>
		/// The <c>EncryptMessage (Digest)</c> function encrypts a message to provide privacy. <c>EncryptMessage (Digest)</c> allows the
		/// application to choose among cryptographic algorithms supported by the chosen mechanism. The <c>EncryptMessage (Digest)</c>
		/// function uses the security context referenced by the context handle. Some packages do not have messages to be encrypted or
		/// decrypted but rather provide an integrity hash that can be checked.
		/// </para>
		/// <para>This function is available as a SASL mechanism only.</para>
		/// <para>
		/// <c>Note</c><c>EncryptMessage (Digest)</c> and DecryptMessage (Digest) can be called at the same time from two different threads
		/// in a single Security Support Provider Interface (SSPI) context if one thread is encrypting and the other is decrypting. If more
		/// than one thread is encrypting, or more than one thread is decrypting, each thread should obtain a unique context.
		/// </para>
		/// </summary>
		/// <param name="phContext">A handle to the security context to be used to encrypt the message.</param>
		/// <param name="fQOP">
		/// <para>
		/// Package-specific flags that indicate the quality of protection. A security package can use this parameter to enable the selection
		/// of cryptographic algorithms.
		/// </para>
		/// <para>When using the Digest SSP, this parameter must be set to zero.</para>
		/// </param>
		/// <param name="pMessage">
		/// <para>
		/// A pointer to a SecBufferDesc structure. On input, the structure references one or more SecBuffer structures that can be of type
		/// SECBUFFER_DATA. That buffer contains the message to be encrypted. The message is encrypted in place, overwriting the original
		/// contents of the structure.
		/// </para>
		/// <para>The function does not process buffers with the SECBUFFER_READONLY attribute.</para>
		/// <para>
		/// The length of the SecBuffer structure that contains the message must be no greater than <c>cbMaximumMessage</c>, which is
		/// obtained from the QueryContextAttributes (Digest) (SECPKG_ATTR_STREAM_SIZES) function.
		/// </para>
		/// <para>
		/// When using the Digest SSP, there must be a second buffer of type SECBUFFER_PADDING or SEC_BUFFER_DATA to hold signature
		/// information. To get the size of the output buffer, call the QueryContextAttributes (Digest) function and specify
		/// SECPKG_ATTR_SIZES. The function will return a SecPkgContext_Sizes structure. The size of the output buffer is the sum of the
		/// values in the <c>cbMaxSignature</c> and <c>cbBlockSize</c> members.
		/// </para>
		/// <para>Applications that do not use SSL must supply a SecBuffer of type SECBUFFER_PADDING.</para>
		/// </param>
		/// <param name="MessageSeqNo">
		/// <para>
		/// The sequence number that the transport application assigned to the message. If the transport application does not maintain
		/// sequence numbers, this parameter must be zero.
		/// </para>
		/// <para>When using the Digest SSP, this parameter must be set to zero. The Digest SSP manages sequence numbering internally.</para>
		/// </param>
		/// <returns>
		/// <para>If the function succeeds, the function returns SEC_E_OK.</para>
		/// <para>If the function fails, it returns one of the following error codes.</para>
		/// <list type="table">
		/// <listheader>
		/// <term>Return code</term>
		/// <term>Description</term>
		/// </listheader>
		/// <item>
		/// <term>SEC_E_BUFFER_TOO_SMALL</term>
		/// <term>The output buffer is too small. For more information, see Remarks.</term>
		/// </item>
		/// <item>
		/// <term>SEC_E_CONTEXT_EXPIRED</term>
		/// <term>
		/// The application is referencing a context that has already been closed. A properly written application should not receive this error.
		/// </term>
		/// </item>
		/// <item>
		/// <term>SEC_E_CRYPTO_SYSTEM_INVALID</term>
		/// <term>The cipher chosen for the security context is not supported.</term>
		/// </item>
		/// <item>
		/// <term>SEC_E_INSUFFICIENT_MEMORY</term>
		/// <term>There is not enough memory available to complete the requested action.</term>
		/// </item>
		/// <item>
		/// <term>SEC_E_INVALID_HANDLE</term>
		/// <term>A context handle that is not valid was specified in the phContext parameter.</term>
		/// </item>
		/// <item>
		/// <term>SEC_E_INVALID_TOKEN</term>
		/// <term>No SECBUFFER_DATA type buffer was found.</term>
		/// </item>
		/// <item>
		/// <term>SEC_E_QOP_NOT_SUPPORTED</term>
		/// <term>Neither confidentiality nor integrity are supported by the security context.</term>
		/// </item>
		/// </list>
		/// </returns>
		/// <remarks>
		/// <para>
		/// The <c>EncryptMessage (Digest)</c> function encrypts a message based on the message and the session key from a security context.
		/// </para>
		/// <para>
		/// If the transport application created the security context to support sequence detection and the caller provides a sequence
		/// number, the function includes this information with the encrypted message. Including this information protects against replay,
		/// insertion, and suppression of messages. The security package incorporates the sequence number passed down from the transport application.
		/// </para>
		/// <para>
		/// When you use the Digest SSP, get the size of the output buffer by calling the QueryContextAttributes (Digest) function and
		/// specifying SECPKG_ATTR_SIZES. The function will return a SecPkgContext_Sizes structure. The size of the output buffer is the sum
		/// of the values in the <c>cbMaxSignature</c> and <c>cbBlockSize</c> members.
		/// </para>
		/// <para><c>Note</c> These buffers must be supplied in the order shown.</para>
		/// <list type="table">
		/// <listheader>
		/// <term>Buffer type</term>
		/// <term>Description</term>
		/// </listheader>
		/// <item>
		/// <term>SECBUFFER_STREAM_HEADER</term>
		/// <term>Used internally. No initialization required.</term>
		/// </item>
		/// <item>
		/// <term>SECBUFFER_DATA</term>
		/// <term>Contains the plaintext message to be encrypted.</term>
		/// </item>
		/// <item>
		/// <term>SECBUFFER_STREAM_TRAILER</term>
		/// <term>Used internally. No initialization required.</term>
		/// </item>
		/// <item>
		/// <term>SECBUFFER_EMPTY</term>
		/// <term>Used internally. No initialization required. Size can be zero.</term>
		/// </item>
		/// </list>
		/// <para>For optimal performance, the pMessage structures should be allocated from contiguous memory.</para>
		/// <para>
		/// <c>Windows XP:</c> This function was also known as <c>SealMessage</c>. Applications should now use <c>EncryptMessage (Digest)</c> only.
		/// </para>
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows/desktop/api/sspi/nf-sspi-encryptmessage SECURITY_STATUS SEC_ENTRY EncryptMessage(
		// PCtxtHandle phContext, unsigned long fQOP, PSecBufferDesc pMessage, unsigned long MessageSeqNo );
		[DllImport(Lib.Secur32, SetLastError = false, ExactSpelling = true)]
		[PInvokeData("sspi.h", MSDNShortId = "0045e931-929b-40c4-a524-5664d2fc5170")]
		public static extern HRESULT EncryptMessage(in CtxtHandle phContext, SECQOP fQOP, ref SecBufferDesc pMessage, uint MessageSeqNo);

		/// <summary>
		/// The <c>EnumerateSecurityPackages</c> function returns an array of SecPkgInfo structures that provide information about the
		/// security packages available to the client.
		/// </summary>
		/// <param name="pcPackages">
		/// A pointer to a <c>ULONG</c> variable that receives the number of packages available on the system. This includes packages that
		/// are already loaded and packages available on demand.
		/// </param>
		/// <param name="ppPackageInfo">
		/// <para>
		/// A pointer to a variable that receives a pointer to an array of SecPkgInfo structures. Each structure contains information from
		/// the security support provider (SSP) that describes the capabilities of the security package available within that SSP.
		/// </para>
		/// <para>When you have finished using the array, free the memory by calling the FreeContextBuffer function.</para>
		/// </param>
		/// <returns>
		/// <para>If the function succeeds, the function returns <c>SEC_E_OK</c>.</para>
		/// <para>
		/// If the function fails, it returns a nonzero error code. Possible values include, but are not limited to, those in the following table.
		/// </para>
		/// <list type="table">
		/// <listheader>
		/// <term>Return code/value</term>
		/// <term>Description</term>
		/// </listheader>
		/// <item>
		/// <term>SEC_E_INSUFFICIENT_MEMORY 0x80090300L</term>
		/// <term>There was not sufficient memory to allocate one or more of the buffers.</term>
		/// </item>
		/// <item>
		/// <term>SEC_E_INVALID_HANDLE 0x80090301L</term>
		/// <term>An invalid handle was specified.</term>
		/// </item>
		/// <item>
		/// <term>SEC_E_SECPKG_NOT_FOUND 0x80090305L</term>
		/// <term>The specified package was not found.</term>
		/// </item>
		/// </list>
		/// </returns>
		/// <remarks>
		/// The caller can use the <c>Name</c> member of a SecPkgInfo structure to specify a security package in a call to the
		/// AcquireCredentialsHandle (General) function.
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows/desktop/api/sspi/nf-sspi-enumeratesecuritypackagesa SECURITY_STATUS SEC_ENTRY
		// EnumerateSecurityPackagesA( unsigned long *pcPackages, PSecPkgInfoA *ppPackageInfo );
		[DllImport(Lib.Secur32, SetLastError = false, CharSet = CharSet.Auto)]
		[PInvokeData("sspi.h", MSDNShortId = "900790a6-111d-43f5-9316-e85aab03a3bc")]
		public static extern HRESULT EnumerateSecurityPackages(out uint pcPackages, out SafeContextBuffer ppPackageInfo);

		/// <summary>
		/// The <c>ExportSecurityContext</c> function creates a serialized representation of a security context that can later be imported
		/// into a different process by calling ImportSecurityContext. The process that imports the security context must be running on the
		/// same computer as the process that called <c>ExportSecurityContext</c>.
		/// </summary>
		/// <param name="phContext">A handle of the security context to be exported.</param>
		/// <param name="fFlags">
		/// <para>This parameter can be a bitwise- <c>OR</c> combination of the following values.</para>
		/// <list type="table">
		/// <listheader>
		/// <term>Value</term>
		/// <term>Meaning</term>
		/// </listheader>
		/// <item>
		/// <term>SECPKG_CONTEXT_EXPORT_RESET_NEW 1 (0x1)</term>
		/// <term>The new security context is reset to its initial state.</term>
		/// </item>
		/// <item>
		/// <term>SECPKG_CONTEXT_EXPORT_DELETE_OLD 2 (0x2)</term>
		/// <term>The old security context is deleted.</term>
		/// </item>
		/// <item>
		/// <term>SECPKG_CONTEXT_EXPORT_TO_KERNEL 4 (0x4)</term>
		/// <term>
		/// This value is not supported. Windows Server 2003 and Windows XP/2000: The security context is to be exported to the kernel.This
		/// value is supported only in Schannel kernel mode.
		/// </term>
		/// </item>
		/// </list>
		/// </param>
		/// <param name="pPackedContext">
		/// A pointer to a buffer of type <c>SECBUFFER_EMPTY</c> that receives the serialized security context. When you have finished using
		/// this context, free it by calling the FreeContextBuffer function.
		/// </param>
		/// <param name="pToken">
		/// <para>A pointer to receive the handle of the context's token.</para>
		/// <para>When you have finished using the user token, release the handle by calling the CloseHandle function.</para>
		/// </param>
		/// <returns>
		/// <para>If the function succeeds, the function returns SEC_E_OK.</para>
		/// <para>If the function fails, it returns one of the following error codes.</para>
		/// <list type="table">
		/// <listheader>
		/// <term>Return code</term>
		/// <term>Description</term>
		/// </listheader>
		/// <item>
		/// <term>SEC_E_INSUFFICIENT_MEMORY</term>
		/// <term>There is not enough memory available to complete the requested action.</term>
		/// </item>
		/// <item>
		/// <term>SEC_E_INVALID_HANDLE</term>
		/// <term>The phContext parameter does not point to a valid handle.</term>
		/// </item>
		/// <item>
		/// <term>SEC_E_NOT_SUPPORTED</term>
		/// <term>Schannel kernel mode does not support this function.</term>
		/// </item>
		/// </list>
		/// </returns>
		// https://docs.microsoft.com/en-us/windows/desktop/api/sspi/nf-sspi-exportsecuritycontext KSECDDDECLSPEC SECURITY_STATUS SEC_ENTRY
		// ExportSecurityContext( PCtxtHandle phContext, ULONG fFlags, PSecBuffer pPackedContext, void **pToken );
		[DllImport(Lib.Secur32, SetLastError = false, ExactSpelling = true)]
		[PInvokeData("sspi.h", MSDNShortId = "4ebc7f37-b948-4c78-973f-0a74e55c7ee2")]
		public static extern HRESULT ExportSecurityContext(in CtxtHandle phContext, SECPKG_CONTEXT_EXPORT fFlags, ref SecBuffer pPackedContext, out SafeHTOKEN pToken);

		/// <summary>
		/// The <c>FreeContextBuffer</c> function enables callers of security package functions to free memory buffers allocated by the
		/// security package.
		/// </summary>
		/// <param name="pvContextBuffer">A pointer to memory to be freed.</param>
		/// <returns>
		/// <para>If the function succeeds, the function returns SEC_E_OK.</para>
		/// <para>If the function fails, it returns a nonzero error code.</para>
		/// </returns>
		/// <remarks>
		/// <para>
		/// Memory buffers are typically allocated by the InitializeSecurityContext (General) and AcceptSecurityContext (General) functions.
		/// </para>
		/// <para>The <c>FreeContextBuffer</c> function can free any memory allocated by a security package.</para>
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows/desktop/api/sspi/nf-sspi-freecontextbuffer SECURITY_STATUS SEC_ENTRY FreeContextBuffer(
		// PVOID pvContextBuffer );
		[DllImport(Lib.Secur32, SetLastError = false, ExactSpelling = true)]
		[PInvokeData("sspi.h", MSDNShortId = "3c3d27bb-4f9a-4979-b679-1e10fa1ff221")]
		public static extern HRESULT FreeContextBuffer(IntPtr pvContextBuffer);

		/// <summary>
		/// <para>
		/// The <c>FreeCredentialsHandle</c> function notifies the security system that the credentials are no longer needed. An application
		/// calls this function to free the credential handle acquired in the call to the AcquireCredentialsHandle (General) function after
		/// calling the DeleteSecurityContext function to free any context handles associated with the credential. When all references to
		/// this credential set have been removed, the credentials themselves can be removed.
		/// </para>
		/// <para>Failure to free credentials handles will result in memory leaks.</para>
		/// </summary>
		/// <param name="phCredential">A pointer to the CredHandle handle obtained by using the AcquireCredentialsHandle (General) function.</param>
		/// <returns>
		/// <para>If the function succeeds, the function returns SEC_E_OK.</para>
		/// <para>If the function fails, it returns the following error code.</para>
		/// <list type="table">
		/// <listheader>
		/// <term>Return code</term>
		/// <term>Description</term>
		/// </listheader>
		/// <item>
		/// <term>SEC_E_INVALID_HANDLE</term>
		/// <term>The handle passed to the function is not valid.</term>
		/// </item>
		/// </list>
		/// </returns>
		// https://docs.microsoft.com/en-us/windows/desktop/api/sspi/nf-sspi-freecredentialshandle KSECDDDECLSPEC SECURITY_STATUS SEC_ENTRY
		// FreeCredentialsHandle( PCredHandle phCredential );
		[DllImport(Lib.Secur32, SetLastError = false, ExactSpelling = true)]
		[PInvokeData("sspi.h", MSDNShortId = "e089618c-8233-475a-9725-39265c6427ab")]
		public static extern HRESULT FreeCredentialsHandle(ref CredHandle phCredential);

		/// <summary>
		/// The <c>ImpersonateSecurityContext</c> function allows a server to impersonate a client by using a token previously obtained by a
		/// call to AcceptSecurityContext (General) or QuerySecurityContextToken. This function allows the application server to act as the
		/// client, and thus all necessary access controls are enforced.
		/// </summary>
		/// <param name="phContext">
		/// The handle of the context to impersonate. This handle must have been obtained by a call to the AcceptSecurityContext (General) function.
		/// </param>
		/// <returns>
		/// <para>If the function succeeds, the function returns SEC_E_OK.</para>
		/// <para>If the function fails, it returns the following error code.</para>
		/// <list type="table">
		/// <listheader>
		/// <term>Return code</term>
		/// <term>Description</term>
		/// </listheader>
		/// <item>
		/// <term>SEC_E_INVALID_HANDLE</term>
		/// <term>The handle passed to the function is not valid.</term>
		/// </item>
		/// <item>
		/// <term>SEC_E_NO_IMPERSONATION</term>
		/// <term>The client could not be impersonated.</term>
		/// </item>
		/// <item>
		/// <term>SEC_E_UNSUPPORTED_FUNCTION</term>
		/// <term>This value is returned by Schannel kernel mode to indicate that this function is not supported.</term>
		/// </item>
		/// </list>
		/// </returns>
		/// <remarks>
		/// <para>
		/// The server application calls the <c>ImpersonateSecurityContext</c> function when it needs to impersonate the client. Before doing
		/// so, the server must have obtained a valid context handle. To obtain the context handle, the server must call
		/// AcceptSecurityContext (General) to submit the client's incoming security token to the security system. The server gets a context
		/// handle if the inbound context is validated. The function creates an impersonation token and allows the thread or process to run
		/// with the impersonation context.
		/// </para>
		/// <para>
		/// When using the Schannel security support provider (SSP), the server application must pass the <c>ASC_REQ_MUTUAL_AUTH</c> flag
		/// when calling AcceptSecurityContext (General). This ensures that the client is asked for a client certificate during the SSL/TLS
		/// handshake. When a client certificate is received, the Schannel package verifies the client certificate and attempts to map it to
		/// a user account. When this mapping is successful, then a client user token is created and this function succeeds.
		/// </para>
		/// <para>
		/// The application server must call the RevertSecurityContext function when it finishes or when it needs to restore its own security context.
		/// </para>
		/// <para>
		/// <c>ImpersonateSecurityContext</c> is not available with all security packages on all platforms. Typically, it is implemented only
		/// on platforms and with security packages that support impersonation. To learn whether a security package supports impersonation,
		/// call the QuerySecurityPackageInfo function.
		/// </para>
		/// <para>
		/// <c>Note</c> If the <c>ImpersonateSecurityContext</c> function fails, the client is not impersonated, and all subsequent client
		/// requests are made in the security context of the process that called the function. If the calling process is running as a
		/// privileged account, it can perform actions that the client would not be allowed to perform. To avoid security risks, the calling
		/// process should always check the return value. If the return value indicates that the function call failed, no client requests
		/// should be executed.
		/// </para>
		/// <para>
		/// All impersonate functions, including <c>ImpersonateSecurityContext</c> allow the requested impersonation if one of the following
		/// is true:
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
		/// <para><c>Windows XP:</c> The SeImpersonatePrivilege privilege is not supported until Windows XP with Service Pack 2 (SP2).</para>
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows/desktop/api/sspi/nf-sspi-impersonatesecuritycontext KSECDDDECLSPEC SECURITY_STATUS
		// SEC_ENTRY ImpersonateSecurityContext( PCtxtHandle phContext );
		[DllImport(Lib.Secur32, SetLastError = false, ExactSpelling = true)]
		[PInvokeData("sspi.h", MSDNShortId = "167eaf3b-b794-4587-946d-fa596f1f9411")]
		public static extern HRESULT ImpersonateSecurityContext(in CtxtHandle phContext);

		/// <summary>
		/// The <c>ImportSecurityContext</c> function imports a security context. The security context must have been exported to the process
		/// calling <c>ImportSecurityContext</c> by a previous call to ExportSecurityContext.
		/// </summary>
		/// <param name="pszPackage">A string that contains the name of the security package to which the security context was exported.</param>
		/// <param name="pPackedContext">A pointer to a buffer that contains the serialized security context created by ExportSecurityContext.</param>
		/// <param name="Token">A handle to the context's token.</param>
		/// <param name="phContext">
		/// A handle of the new security context created from pPackedContext. When you have finished using the context, delete it by calling
		/// the DeleteSecurityContext function.
		/// </param>
		/// <returns>
		/// <para>If the function succeeds, the function returns SEC_E_OK.</para>
		/// <para>If the function fails, it returns one of the following error codes.</para>
		/// <list type="table">
		/// <listheader>
		/// <term>Return code</term>
		/// <term>Description</term>
		/// </listheader>
		/// <item>
		/// <term>SEC_E_UNKNOWN_CREDENTIALS</term>
		/// <term>The credentials supplied to the package were not recognized.</term>
		/// </item>
		/// <item>
		/// <term>SEC_E_NO_CREDENTIALS</term>
		/// <term>No credentials are available in the security package.</term>
		/// </item>
		/// <item>
		/// <term>SEC_E_NOT_OWNER</term>
		/// <term>The caller of the function does not have the necessary credentials.</term>
		/// </item>
		/// <item>
		/// <term>SEC_E_INSUFFICIENT_MEMORY</term>
		/// <term>There is not enough memory available to complete the requested action.</term>
		/// </item>
		/// <item>
		/// <term>SEC_E_INTERNAL_ERROR</term>
		/// <term>An error occurred that did not map to an SSPI error code.</term>
		/// </item>
		/// </list>
		/// </returns>
		// https://docs.microsoft.com/en-us/windows/desktop/api/sspi/nf-sspi-importsecuritycontexta SECURITY_STATUS SEC_ENTRY
		// ImportSecurityContextA( LPSTR pszPackage, PSecBuffer pPackedContext, VOID *Token, PCtxtHandle phContext );
		[DllImport(Lib.Secur32, SetLastError = false, CharSet = CharSet.Auto)]
		[PInvokeData("sspi.h", MSDNShortId = "0f8e65d0-69cf-42ba-a903-1922d731e5ec")]
		public static extern HRESULT ImportSecurityContext(string pszPackage, ref SecBuffer pPackedContext, HTOKEN Token, out SafeCtxtHandle phContext);

		/// <summary>
		/// <para>
		/// The <c>InitializeSecurityContext (General)</c> function initiates the client side, outbound security context from a credential
		/// handle. The function is used to build a security context between the client application and a remote peer.
		/// <c>InitializeSecurityContext (General)</c> returns a token that the client must pass to the remote peer, which the peer in turn
		/// submits to the local security implementation through the AcceptSecurityContext (General) call. The token generated should be
		/// considered opaque by all callers.
		/// </para>
		/// <para>
		/// Typically, the <c>InitializeSecurityContext (General)</c> function is called in a loop until a sufficient security context is established.
		/// </para>
		/// <para>For information about using this function with a specific security support provider (SSP), see the following topics.</para>
		/// <list type="table">
		/// <listheader>
		/// <term>Topic</term>
		/// <term>Description</term>
		/// </listheader>
		/// <item>
		/// <term>InitializeSecurityContext (CredSSP)</term>
		/// <term>
		/// Initiates the client side, outbound security context from a credential handle by using the Credential Security Support Provider (CredSSP).
		/// </term>
		/// </item>
		/// <item>
		/// <term>InitializeSecurityContext (Digest)</term>
		/// <term>Initiates the client side, outbound security context from a credential handle by using the Digest security package.</term>
		/// </item>
		/// <item>
		/// <term>InitializeSecurityContext (Kerberos)</term>
		/// <term>Initiates the client side, outbound security context from a credential handle by using the Kerberos security package.</term>
		/// </item>
		/// <item>
		/// <term>InitializeSecurityContext (Negotiate)</term>
		/// <term>Initiates the client side, outbound security context from a credential handle by using the Negotiate security package.</term>
		/// </item>
		/// <item>
		/// <term>InitializeSecurityContext (NTLM)</term>
		/// <term>Initiates the client side, outbound security context from a credential handle by using the NTLM security package.</term>
		/// </item>
		/// <item>
		/// <term>InitializeSecurityContext (Schannel)</term>
		/// <term>Initiates the client side, outbound security context from a credential handle by using the Schannel security package.</term>
		/// </item>
		/// </list>
		/// </summary>
		/// <param name="phCredential">
		/// A handle to the credentials returned by AcquireCredentialsHandle (General). This handle is used to build the security context.
		/// The <c>InitializeSecurityContext (General)</c> function requires at least OUTBOUND credentials.
		/// </param>
		/// <param name="phContext">
		/// <para>
		/// A pointer to a CtxtHandle structure. On the first call to <c>InitializeSecurityContext (General)</c>, this pointer is
		/// <c>NULL</c>. On the second call, this parameter is a pointer to the handle to the partially formed context returned in the
		/// phNewContext parameter by the first call.
		/// </para>
		/// <para>This parameter is optional with the Microsoft Digest SSP and can be set to <c>NULL</c>.</para>
		/// <para>
		/// When using the Schannel SSP, on the first call to <c>InitializeSecurityContext (General)</c>, specify <c>NULL</c>. On future
		/// calls, specify the token received in the phNewContext parameter after the first call to this function.
		/// </para>
		/// </param>
		/// <param name="pszTargetName">TBD</param>
		/// <param name="fContextReq">
		/// <para>
		/// Bit flags that indicate requests for the context. Not all packages can support all requirements. Flags used for this parameter
		/// are prefixed with ISC_REQ_, for example, ISC_REQ_DELEGATE. This parameter can be one or more of the following attributes flags.
		/// </para>
		/// <list type="table">
		/// <listheader>
		/// <term>Value</term>
		/// <term>Meaning</term>
		/// </listheader>
		/// <item>
		/// <term>ISC_REQ_ALLOCATE_MEMORY</term>
		/// <term>
		/// The security package allocates output buffers for you. When you have finished using the output buffers, free them by calling the
		/// FreeContextBuffer function.
		/// </term>
		/// </item>
		/// <item>
		/// <term>ISC_REQ_CONFIDENTIALITY</term>
		/// <term>Encrypt messages by using the EncryptMessage function.</term>
		/// </item>
		/// <item>
		/// <term>ISC_REQ_CONNECTION</term>
		/// <term>
		/// The security context will not handle formatting messages. This value is the default for the Kerberos, Negotiate, and NTLM
		/// security packages.
		/// </term>
		/// </item>
		/// <item>
		/// <term>ISC_REQ_DELEGATE</term>
		/// <term>
		/// The server can use the context to authenticate to other servers as the client. The ISC_REQ_MUTUAL_AUTH flag must be set for this
		/// flag to work. Valid for Kerberos. Ignore this flag for constrained delegation.
		/// </term>
		/// </item>
		/// <item>
		/// <term>ISC_REQ_EXTENDED_ERROR</term>
		/// <term>When errors occur, the remote party will be notified.</term>
		/// </item>
		/// <item>
		/// <term>ISC_REQ_HTTP</term>
		/// <term>Use Digest for HTTP. Omit this flag to use Digest as a SASL mechanism.</term>
		/// </item>
		/// <item>
		/// <term>ISC_REQ_INTEGRITY</term>
		/// <term>Sign messages and verify signatures by using the EncryptMessage and MakeSignature functions.</term>
		/// </item>
		/// <item>
		/// <term>ISC_REQ_MANUAL_CRED_VALIDATION</term>
		/// <term>Schannel must not authenticate the server automatically.</term>
		/// </item>
		/// <item>
		/// <term>ISC_REQ_MUTUAL_AUTH</term>
		/// <term>The mutual authentication policy of the service will be satisfied.</term>
		/// </item>
		/// <item>
		/// <term>ISC_REQ_NO_INTEGRITY</term>
		/// <term>
		/// If this flag is set, the ISC_REQ_INTEGRITY flag is ignored. This value is supported only by the Negotiate and Kerberos security packages.
		/// </term>
		/// </item>
		/// <item>
		/// <term>ISC_REQ_REPLAY_DETECT</term>
		/// <term>Detect replayed messages that have been encoded by using the EncryptMessage or MakeSignature functions.</term>
		/// </item>
		/// <item>
		/// <term>ISC_REQ_SEQUENCE_DETECT</term>
		/// <term>Detect messages received out of sequence.</term>
		/// </item>
		/// <item>
		/// <term>ISC_REQ_STREAM</term>
		/// <term>Support a stream-oriented connection.</term>
		/// </item>
		/// <item>
		/// <term>ISC_REQ_USE_SESSION_KEY</term>
		/// <term>A new session key must be negotiated. This value is supported only by the Kerberos security package.</term>
		/// </item>
		/// <item>
		/// <term>ISC_REQ_USE_SUPPLIED_CREDS</term>
		/// <term>Schannel must not attempt to supply credentials for the client automatically.</term>
		/// </item>
		/// </list>
		/// <para>The requested attributes may not be supported by the client. For more information, see the pfContextAttr parameter.</para>
		/// <para>For further descriptions of the various attributes, see Context Requirements.</para>
		/// </param>
		/// <param name="Reserved1">This parameter is reserved and must be set to zero.</param>
		/// <param name="TargetDataRep">
		/// <para>The data representation, such as byte ordering, on the target. This parameter can be either SECURITY_NATIVE_DREP or SECURITY_NETWORK_DREP.</para>
		/// <para>This parameter is not used with Digest or Schannel. Set it to zero.</para>
		/// </param>
		/// <param name="pInput">
		/// A pointer to a SecBufferDesc structure that contains pointers to the buffers supplied as input to the package. Unless the client
		/// context was initiated by the server, the value of this parameter must be <c>NULL</c> on the first call to the function. On
		/// subsequent calls to the function or when the client context was initiated by the server, the value of this parameter is a pointer
		/// to a buffer allocated with enough memory to hold the token returned by the remote computer.
		/// </param>
		/// <param name="Reserved2">This parameter is reserved and must be set to zero.</param>
		/// <param name="phNewContext">
		/// <para>
		/// A pointer to a CtxtHandle structure. On the first call to <c>InitializeSecurityContext (General)</c>, this pointer receives the
		/// new context handle. On the second call, phNewContext can be the same as the handle specified in the phContext parameter.
		/// </para>
		/// <para>
		/// When using the Schannel SSP, on calls after the first call, pass the handle returned here as the phContext parameter and specify
		/// <c>NULL</c> for phNewContext.
		/// </para>
		/// </param>
		/// <param name="pOutput">
		/// <para>
		/// A pointer to a SecBufferDesc structure that contains pointers to the SecBuffer structure that receives the output data. If a
		/// buffer was typed as SEC_READWRITE in the input, it will be there on output. The system will allocate a buffer for the security
		/// token if requested (through ISC_REQ_ALLOCATE_MEMORY) and fill in the address in the buffer descriptor for the security token.
		/// </para>
		/// <para>When using the Microsoft Digest SSP, this parameter receives the challenge response that must be sent to the server.</para>
		/// <para>
		/// When using the Schannel SSP, if the ISC_REQ_ALLOCATE_MEMORY flag is specified, the Schannel SSP will allocate memory for the
		/// buffer and put the appropriate information in the SecBufferDesc. In addition, the caller must pass in a buffer of type
		/// <c>SECBUFFER_ALERT</c>. On output, if an alert is generated, this buffer contains information about that alert, and the function fails.
		/// </para>
		/// </param>
		/// <param name="pfContextAttr">
		/// <para>
		/// A pointer to a variable to receive a set of bit flags that indicate the attributes of the established context. For a description
		/// of the various attributes, see Context Requirements.
		/// </para>
		/// <para>Flags used for this parameter are prefixed with ISC_RET, such as ISC_RET_DELEGATE.</para>
		/// <para>For a list of valid values, see the fContextReq parameter.</para>
		/// <para>
		/// Do not check for security-related attributes until the final function call returns successfully. Attribute flags that are not
		/// related to security, such as the ASC_RET_ALLOCATED_MEMORY flag, can be checked before the final return.
		/// </para>
		/// <para><c>Note</c> Particular context attributes can change during negotiation with a remote peer.</para>
		/// </param>
		/// <param name="ptsExpiry">
		/// <para>
		/// A pointer to a TimeStamp structure that receives the expiration time of the context. It is recommended that the security package
		/// always return this value in local time. This parameter is optional and <c>NULL</c> should be passed for short-lived clients.
		/// </para>
		/// <para>There is no expiration time for Microsoft Digest SSP security contexts or credentials.</para>
		/// </param>
		/// <returns>
		/// <para>If the function succeeds, the function returns one of the following success codes.</para>
		/// <list type="table">
		/// <listheader>
		/// <term>Return code</term>
		/// <term>Description</term>
		/// </listheader>
		/// <item>
		/// <term>SEC_I_COMPLETE_AND_CONTINUE</term>
		/// <term>
		/// The client must call CompleteAuthToken and then pass the output to the server. The client then waits for a returned token and
		/// passes it, in another call, to InitializeSecurityContext (General).
		/// </term>
		/// </item>
		/// <item>
		/// <term>SEC_I_COMPLETE_NEEDED</term>
		/// <term>The client must finish building the message and then call the CompleteAuthToken function.</term>
		/// </item>
		/// <item>
		/// <term>SEC_I_CONTINUE_NEEDED</term>
		/// <term>
		/// The client must send the output token to the server and wait for a return token. The returned token is then passed in another
		/// call to InitializeSecurityContext (General). The output token can be empty.
		/// </term>
		/// </item>
		/// <item>
		/// <term>SEC_I_INCOMPLETE_CREDENTIALS</term>
		/// <term>
		/// Use with Schannel. The server has requested client authentication, and the supplied credentials either do not include a
		/// certificate or the certificate was not issued by a certification authority that is trusted by the server. For more information,
		/// see Remarks.
		/// </term>
		/// </item>
		/// <item>
		/// <term>SEC_E_INCOMPLETE_MESSAGE</term>
		/// <term>
		/// Use with Schannel. Data for the whole message was not read from the wire. When this value is returned, the pInput buffer contains
		/// a SecBuffer structure with a BufferType member of SECBUFFER_MISSING. The cbBuffer member of SecBuffer contains a value that
		/// indicates the number of additional bytes that the function must read from the client before this function succeeds. While this
		/// number is not always accurate, using it can help improve performance by avoiding multiple calls to this function.
		/// </term>
		/// </item>
		/// <item>
		/// <term>SEC_E_OK</term>
		/// <term>
		/// The security context was successfully initialized. There is no need for another InitializeSecurityContext (General) call. If the
		/// function returns an output token, that is, if the SECBUFFER_TOKEN in pOutput is of nonzero length, that token must be sent to the server.
		/// </term>
		/// </item>
		/// </list>
		/// <para>If the function fails, the function returns one of the following error codes.</para>
		/// <list type="table">
		/// <listheader>
		/// <term>Return code</term>
		/// <term>Description</term>
		/// </listheader>
		/// <item>
		/// <term>SEC_E_INSUFFICIENT_MEMORY</term>
		/// <term>There is not enough memory available to complete the requested action.</term>
		/// </item>
		/// <item>
		/// <term>SEC_E_INTERNAL_ERROR</term>
		/// <term>An error occurred that did not map to an SSPI error code.</term>
		/// </item>
		/// <item>
		/// <term>SEC_E_INVALID_HANDLE</term>
		/// <term>The handle passed to the function is not valid.</term>
		/// </item>
		/// <item>
		/// <term>SEC_E_INVALID_TOKEN</term>
		/// <term>
		/// The error is due to a malformed input token, such as a token corrupted in transit, a token of incorrect size, or a token passed
		/// into the wrong security package. Passing a token to the wrong package can happen if the client and server did not negotiate the
		/// proper security package.
		/// </term>
		/// </item>
		/// <item>
		/// <term>SEC_E_LOGON_DENIED</term>
		/// <term>The logon failed.</term>
		/// </item>
		/// <item>
		/// <term>SEC_E_NO_AUTHENTICATING_AUTHORITY</term>
		/// <term>
		/// No authority could be contacted for authentication. The domain name of the authenticating party could be wrong, the domain could
		/// be unreachable, or there might have been a trust relationship failure.
		/// </term>
		/// </item>
		/// <item>
		/// <term>SEC_E_NO_CREDENTIALS</term>
		/// <term>No credentials are available in the security package.</term>
		/// </item>
		/// <item>
		/// <term>SEC_E_TARGET_UNKNOWN</term>
		/// <term>The target was not recognized.</term>
		/// </item>
		/// <item>
		/// <term>SEC_E_UNSUPPORTED_FUNCTION</term>
		/// <term>
		/// A context attribute flag that is not valid (ISC_REQ_DELEGATE or ISC_REQ_PROMPT_FOR_CREDS) was specified in the fContextReq parameter.
		/// </term>
		/// </item>
		/// <item>
		/// <term>SEC_E_WRONG_PRINCIPAL</term>
		/// <term>
		/// The principal that received the authentication request is not the same as the one passed into the pszTargetName parameter. This
		/// indicates a failure in mutual authentication.
		/// </term>
		/// </item>
		/// </list>
		/// </returns>
		/// <remarks>
		/// <para>
		/// The caller is responsible for determining whether the final context attributes are sufficient. If, for example, confidentiality
		/// was requested, but could not be established, some applications may choose to shut down the connection immediately.
		/// </para>
		/// <para>
		/// If attributes of the security context are not sufficient, the client must free the partially created context by calling the
		/// DeleteSecurityContext function.
		/// </para>
		/// <para>The <c>InitializeSecurityContext (General)</c> function is used by a client to initialize an outbound context.</para>
		/// <para>For a two-leg security context, the calling sequence is as follows:</para>
		/// <list type="number">
		/// <item>
		/// <term>The client calls the function with phContext set to <c>NULL</c> and fills in the buffer descriptor with the input message.</term>
		/// </item>
		/// <item>
		/// <term>
		/// The security package examines the parameters and constructs an opaque token, placing it in the TOKEN element in the buffer array.
		/// If the fContextReq parameter includes the ISC_REQ_ALLOCATE_MEMORY flag, the security package allocates the memory and returns the
		/// pointer in the TOKEN element.
		/// </term>
		/// </item>
		/// <item>
		/// <term>
		/// The client sends the token returned in the pOutput buffer to the target server. The server then passes the token as an input
		/// argument in a call to the AcceptSecurityContext (General) function.
		/// </term>
		/// </item>
		/// <item>
		/// <term>
		/// AcceptSecurityContext (General) may return a token, which the server sends to the client for a second call to
		/// <c>InitializeSecurityContext (General)</c> if the first call returned SEC_I_CONTINUE_NEEDED.
		/// </term>
		/// </item>
		/// </list>
		/// <para>For multiple-leg security contexts, such as mutual authentication, the calling sequence is as follows:</para>
		/// <list type="number">
		/// <item>
		/// <term>The client calls the function as described earlier, but the package returns the SEC_I_CONTINUE_NEEDED success code.</term>
		/// </item>
		/// <item>
		/// <term>The client sends the output token to the server and waits for the server's reply.</term>
		/// </item>
		/// <item>
		/// <term>
		/// Upon receipt of the server's response, the client calls <c>InitializeSecurityContext (General)</c> again, with phContext set to
		/// the handle that was returned from the last call. The token received from the server is supplied in the pInput parameter.
		/// </term>
		/// </item>
		/// </list>
		/// <para>If the server has successfully responded, the security package returns SEC_E_OK and a secure session is established.</para>
		/// <para>If the function returns one of the error responses, the server's response is not accepted, and the session is not established.</para>
		/// <para>
		/// If the function returns SEC_I_CONTINUE_NEEDED, SEC_I_COMPLETE_NEEDED, or SEC_I_COMPLETE_AND_CONTINUE, steps 2 and 3 are repeated.
		/// </para>
		/// <para>
		/// To initialize a security context, more than one call to this function may be required, depending on the underlying authentication
		/// mechanism as well as the choices specified in the fContextReq parameter.
		/// </para>
		/// <para>
		/// The fContextReq and pfContextAttributes parameters are bitmasks that represent various context attributes. For a description of
		/// the various attributes, see Context Requirements. The pfContextAttributes parameter is valid on any successful return, but only
		/// on the final successful return should you examine the flags that pertain to security aspects of the context. Intermediate returns
		/// can set, for example, the ISC_RET_ALLOCATED_MEMORY flag.
		/// </para>
		/// <para>
		/// If the ISC_REQ_USE_SUPPLIED_CREDS flag is set, the security package must look for a SECBUFFER_PKG_PARAMS buffer type in the
		/// pInput input buffer. This is not a generic solution, but it allows for a strong pairing of security package and application when appropriate.
		/// </para>
		/// <para>If ISC_REQ_ALLOCATE_MEMORY was specified, the caller must free the memory by calling the FreeContextBuffer function.</para>
		/// <para>
		/// For example, the input token could be the challenge from a LAN Manager. In this case, the output token would be the
		/// NTLM-encrypted response to the challenge.
		/// </para>
		/// <para>
		/// The action the client takes depends on the return code from this function. If the return code is SEC_E_OK, there will be no
		/// second <c>InitializeSecurityContext (General)</c> call, and no response from the server is expected. If the return code is
		/// SEC_I_CONTINUE_NEEDED, the client expects a token in response from the server and passes it in a second call to
		/// <c>InitializeSecurityContext (General)</c>. The SEC_I_COMPLETE_NEEDED return code indicates that the client must finish building
		/// the message and call the CompleteAuthToken function. The SEC_I_COMPLETE_AND_CONTINUE code incorporates both of these actions.
		/// </para>
		/// <para>
		/// If <c>InitializeSecurityContext (General)</c> returns success on the first (or only) call, then the caller must eventually call
		/// the DeleteSecurityContext function on the returned handle, even if the call fails on a later leg of the authentication exchange.
		/// </para>
		/// <para>
		/// The client may call <c>InitializeSecurityContext (General)</c> again after it has completed successfully. This indicates to the
		/// security package that a reauthentication is wanted.
		/// </para>
		/// <para>
		/// Kernel mode callers have the following differences: the target name is a Unicode string that must be allocated in virtual memory
		/// by using VirtualAlloc; it must not be allocated from the pool. Buffers passed and supplied in pInput and pOutput must be in
		/// virtual memory, not in the pool.
		/// </para>
		/// <para>
		/// When using the Schannel SSP, if the function returns SEC_I_INCOMPLETE_CREDENTIALS, check that you specified a valid and trusted
		/// certificate in your credentials. The certificate is specified when calling the AcquireCredentialsHandle (General) function. The
		/// certificate must be a client authentication certificate issued by a certification authority (CA) trusted by the server. To obtain
		/// a list of the CAs trusted by the server, call the QueryContextAttributes (General) function and specify the
		/// SECPKG_ATTR_ISSUER_LIST_EX attribute.
		/// </para>
		/// <para>
		/// When using the Schannel SSP, after a client application receives an authentication certificate from a CA that is trusted by the
		/// server, the application creates a new credential by calling the AcquireCredentialsHandle (General) function and then calling
		/// <c>InitializeSecurityContext (General)</c> again, specifying the new credential in the phCredential parameter.
		/// </para>
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows/desktop/api/sspi/nf-sspi-initializesecuritycontexta SECURITY_STATUS SEC_ENTRY
		// InitializeSecurityContextA( PCredHandle phCredential, PCtxtHandle phContext, SEC_CHAR *pszTargetName, unsigned long fContextReq,
		// unsigned long Reserved1, unsigned long TargetDataRep, PSecBufferDesc pInput, unsigned long Reserved2, PCtxtHandle phNewContext,
		// PSecBufferDesc pOutput, unsigned long *pfContextAttr, PTimeStamp ptsExpiry );
		[DllImport(Lib.Secur32, SetLastError = false, CharSet = CharSet.Auto)]
		[PInvokeData("sspi.h", MSDNShortId = "21d965d4-3c03-4e29-a70d-4538c5c366b0")]
		public static unsafe extern HRESULT InitializeSecurityContext([In, Optional] CredHandle* phCredential, [In, Optional] CtxtHandle* phContext, [Optional] string pszTargetName, ASC_REQ fContextReq, [Optional] uint Reserved1, DREP TargetDataRep,
			[In, Optional] SecBufferDesc* pInput, [Optional] uint Reserved2, ref CtxtHandle phNewContext, [Optional] SecBufferDesc* pOutput, out ASC_RET pfContextAttr, out TimeStamp ptsExpiry);

		/// <summary>
		/// <para>
		/// The <c>InitializeSecurityContext (General)</c> function initiates the client side, outbound security context from a credential
		/// handle. The function is used to build a security context between the client application and a remote peer.
		/// <c>InitializeSecurityContext (General)</c> returns a token that the client must pass to the remote peer, which the peer in turn
		/// submits to the local security implementation through the AcceptSecurityContext (General) call. The token generated should be
		/// considered opaque by all callers.
		/// </para>
		/// <para>
		/// Typically, the <c>InitializeSecurityContext (General)</c> function is called in a loop until a sufficient security context is established.
		/// </para>
		/// <para>For information about using this function with a specific security support provider (SSP), see the following topics.</para>
		/// <list type="table">
		/// <listheader>
		/// <term>Topic</term>
		/// <term>Description</term>
		/// </listheader>
		/// <item>
		/// <term>InitializeSecurityContext (CredSSP)</term>
		/// <term>
		/// Initiates the client side, outbound security context from a credential handle by using the Credential Security Support Provider (CredSSP).
		/// </term>
		/// </item>
		/// <item>
		/// <term>InitializeSecurityContext (Digest)</term>
		/// <term>Initiates the client side, outbound security context from a credential handle by using the Digest security package.</term>
		/// </item>
		/// <item>
		/// <term>InitializeSecurityContext (Kerberos)</term>
		/// <term>Initiates the client side, outbound security context from a credential handle by using the Kerberos security package.</term>
		/// </item>
		/// <item>
		/// <term>InitializeSecurityContext (Negotiate)</term>
		/// <term>Initiates the client side, outbound security context from a credential handle by using the Negotiate security package.</term>
		/// </item>
		/// <item>
		/// <term>InitializeSecurityContext (NTLM)</term>
		/// <term>Initiates the client side, outbound security context from a credential handle by using the NTLM security package.</term>
		/// </item>
		/// <item>
		/// <term>InitializeSecurityContext (Schannel)</term>
		/// <term>Initiates the client side, outbound security context from a credential handle by using the Schannel security package.</term>
		/// </item>
		/// </list>
		/// </summary>
		/// <param name="phCredential">
		/// A handle to the credentials returned by AcquireCredentialsHandle (General). This handle is used to build the security context.
		/// The <c>InitializeSecurityContext (General)</c> function requires at least OUTBOUND credentials.
		/// </param>
		/// <param name="phContext">
		/// <para>
		/// A pointer to a CtxtHandle structure. On the first call to <c>InitializeSecurityContext (General)</c>, this pointer is
		/// <c>NULL</c>. On the second call, this parameter is a pointer to the handle to the partially formed context returned in the
		/// phNewContext parameter by the first call.
		/// </para>
		/// <para>This parameter is optional with the Microsoft Digest SSP and can be set to <c>NULL</c>.</para>
		/// <para>
		/// When using the Schannel SSP, on the first call to <c>InitializeSecurityContext (General)</c>, specify <c>NULL</c>. On future
		/// calls, specify the token received in the phNewContext parameter after the first call to this function.
		/// </para>
		/// </param>
		/// <param name="pszTargetName">TBD</param>
		/// <param name="fContextReq">
		/// <para>
		/// Bit flags that indicate requests for the context. Not all packages can support all requirements. Flags used for this parameter
		/// are prefixed with ISC_REQ_, for example, ISC_REQ_DELEGATE. This parameter can be one or more of the following attributes flags.
		/// </para>
		/// <list type="table">
		/// <listheader>
		/// <term>Value</term>
		/// <term>Meaning</term>
		/// </listheader>
		/// <item>
		/// <term>ISC_REQ_ALLOCATE_MEMORY</term>
		/// <term>
		/// The security package allocates output buffers for you. When you have finished using the output buffers, free them by calling the
		/// FreeContextBuffer function.
		/// </term>
		/// </item>
		/// <item>
		/// <term>ISC_REQ_CONFIDENTIALITY</term>
		/// <term>Encrypt messages by using the EncryptMessage function.</term>
		/// </item>
		/// <item>
		/// <term>ISC_REQ_CONNECTION</term>
		/// <term>
		/// The security context will not handle formatting messages. This value is the default for the Kerberos, Negotiate, and NTLM
		/// security packages.
		/// </term>
		/// </item>
		/// <item>
		/// <term>ISC_REQ_DELEGATE</term>
		/// <term>
		/// The server can use the context to authenticate to other servers as the client. The ISC_REQ_MUTUAL_AUTH flag must be set for this
		/// flag to work. Valid for Kerberos. Ignore this flag for constrained delegation.
		/// </term>
		/// </item>
		/// <item>
		/// <term>ISC_REQ_EXTENDED_ERROR</term>
		/// <term>When errors occur, the remote party will be notified.</term>
		/// </item>
		/// <item>
		/// <term>ISC_REQ_HTTP</term>
		/// <term>Use Digest for HTTP. Omit this flag to use Digest as a SASL mechanism.</term>
		/// </item>
		/// <item>
		/// <term>ISC_REQ_INTEGRITY</term>
		/// <term>Sign messages and verify signatures by using the EncryptMessage and MakeSignature functions.</term>
		/// </item>
		/// <item>
		/// <term>ISC_REQ_MANUAL_CRED_VALIDATION</term>
		/// <term>Schannel must not authenticate the server automatically.</term>
		/// </item>
		/// <item>
		/// <term>ISC_REQ_MUTUAL_AUTH</term>
		/// <term>The mutual authentication policy of the service will be satisfied.</term>
		/// </item>
		/// <item>
		/// <term>ISC_REQ_NO_INTEGRITY</term>
		/// <term>
		/// If this flag is set, the ISC_REQ_INTEGRITY flag is ignored. This value is supported only by the Negotiate and Kerberos security packages.
		/// </term>
		/// </item>
		/// <item>
		/// <term>ISC_REQ_REPLAY_DETECT</term>
		/// <term>Detect replayed messages that have been encoded by using the EncryptMessage or MakeSignature functions.</term>
		/// </item>
		/// <item>
		/// <term>ISC_REQ_SEQUENCE_DETECT</term>
		/// <term>Detect messages received out of sequence.</term>
		/// </item>
		/// <item>
		/// <term>ISC_REQ_STREAM</term>
		/// <term>Support a stream-oriented connection.</term>
		/// </item>
		/// <item>
		/// <term>ISC_REQ_USE_SESSION_KEY</term>
		/// <term>A new session key must be negotiated. This value is supported only by the Kerberos security package.</term>
		/// </item>
		/// <item>
		/// <term>ISC_REQ_USE_SUPPLIED_CREDS</term>
		/// <term>Schannel must not attempt to supply credentials for the client automatically.</term>
		/// </item>
		/// </list>
		/// <para>The requested attributes may not be supported by the client. For more information, see the pfContextAttr parameter.</para>
		/// <para>For further descriptions of the various attributes, see Context Requirements.</para>
		/// </param>
		/// <param name="Reserved1">This parameter is reserved and must be set to zero.</param>
		/// <param name="TargetDataRep">
		/// <para>The data representation, such as byte ordering, on the target. This parameter can be either SECURITY_NATIVE_DREP or SECURITY_NETWORK_DREP.</para>
		/// <para>This parameter is not used with Digest or Schannel. Set it to zero.</para>
		/// </param>
		/// <param name="pInput">
		/// A pointer to a SecBufferDesc structure that contains pointers to the buffers supplied as input to the package. Unless the client
		/// context was initiated by the server, the value of this parameter must be <c>NULL</c> on the first call to the function. On
		/// subsequent calls to the function or when the client context was initiated by the server, the value of this parameter is a pointer
		/// to a buffer allocated with enough memory to hold the token returned by the remote computer.
		/// </param>
		/// <param name="Reserved2">This parameter is reserved and must be set to zero.</param>
		/// <param name="phNewContext">
		/// <para>
		/// A pointer to a CtxtHandle structure. On the first call to <c>InitializeSecurityContext (General)</c>, this pointer receives the
		/// new context handle. On the second call, phNewContext can be the same as the handle specified in the phContext parameter.
		/// </para>
		/// <para>
		/// When using the Schannel SSP, on calls after the first call, pass the handle returned here as the phContext parameter and specify
		/// <c>NULL</c> for phNewContext.
		/// </para>
		/// </param>
		/// <param name="pOutput">
		/// <para>
		/// A pointer to a SecBufferDesc structure that contains pointers to the SecBuffer structure that receives the output data. If a
		/// buffer was typed as SEC_READWRITE in the input, it will be there on output. The system will allocate a buffer for the security
		/// token if requested (through ISC_REQ_ALLOCATE_MEMORY) and fill in the address in the buffer descriptor for the security token.
		/// </para>
		/// <para>When using the Microsoft Digest SSP, this parameter receives the challenge response that must be sent to the server.</para>
		/// <para>
		/// When using the Schannel SSP, if the ISC_REQ_ALLOCATE_MEMORY flag is specified, the Schannel SSP will allocate memory for the
		/// buffer and put the appropriate information in the SecBufferDesc. In addition, the caller must pass in a buffer of type
		/// <c>SECBUFFER_ALERT</c>. On output, if an alert is generated, this buffer contains information about that alert, and the function fails.
		/// </para>
		/// </param>
		/// <param name="pfContextAttr">
		/// <para>
		/// A pointer to a variable to receive a set of bit flags that indicate the attributes of the established context. For a description
		/// of the various attributes, see Context Requirements.
		/// </para>
		/// <para>Flags used for this parameter are prefixed with ISC_RET, such as ISC_RET_DELEGATE.</para>
		/// <para>For a list of valid values, see the fContextReq parameter.</para>
		/// <para>
		/// Do not check for security-related attributes until the final function call returns successfully. Attribute flags that are not
		/// related to security, such as the ASC_RET_ALLOCATED_MEMORY flag, can be checked before the final return.
		/// </para>
		/// <para><c>Note</c> Particular context attributes can change during negotiation with a remote peer.</para>
		/// </param>
		/// <param name="ptsExpiry">
		/// <para>
		/// A pointer to a TimeStamp structure that receives the expiration time of the context. It is recommended that the security package
		/// always return this value in local time. This parameter is optional and <c>NULL</c> should be passed for short-lived clients.
		/// </para>
		/// <para>There is no expiration time for Microsoft Digest SSP security contexts or credentials.</para>
		/// </param>
		/// <returns>
		/// <para>If the function succeeds, the function returns one of the following success codes.</para>
		/// <list type="table">
		/// <listheader>
		/// <term>Return code</term>
		/// <term>Description</term>
		/// </listheader>
		/// <item>
		/// <term>SEC_I_COMPLETE_AND_CONTINUE</term>
		/// <term>
		/// The client must call CompleteAuthToken and then pass the output to the server. The client then waits for a returned token and
		/// passes it, in another call, to InitializeSecurityContext (General).
		/// </term>
		/// </item>
		/// <item>
		/// <term>SEC_I_COMPLETE_NEEDED</term>
		/// <term>The client must finish building the message and then call the CompleteAuthToken function.</term>
		/// </item>
		/// <item>
		/// <term>SEC_I_CONTINUE_NEEDED</term>
		/// <term>
		/// The client must send the output token to the server and wait for a return token. The returned token is then passed in another
		/// call to InitializeSecurityContext (General). The output token can be empty.
		/// </term>
		/// </item>
		/// <item>
		/// <term>SEC_I_INCOMPLETE_CREDENTIALS</term>
		/// <term>
		/// Use with Schannel. The server has requested client authentication, and the supplied credentials either do not include a
		/// certificate or the certificate was not issued by a certification authority that is trusted by the server. For more information,
		/// see Remarks.
		/// </term>
		/// </item>
		/// <item>
		/// <term>SEC_E_INCOMPLETE_MESSAGE</term>
		/// <term>
		/// Use with Schannel. Data for the whole message was not read from the wire. When this value is returned, the pInput buffer contains
		/// a SecBuffer structure with a BufferType member of SECBUFFER_MISSING. The cbBuffer member of SecBuffer contains a value that
		/// indicates the number of additional bytes that the function must read from the client before this function succeeds. While this
		/// number is not always accurate, using it can help improve performance by avoiding multiple calls to this function.
		/// </term>
		/// </item>
		/// <item>
		/// <term>SEC_E_OK</term>
		/// <term>
		/// The security context was successfully initialized. There is no need for another InitializeSecurityContext (General) call. If the
		/// function returns an output token, that is, if the SECBUFFER_TOKEN in pOutput is of nonzero length, that token must be sent to the server.
		/// </term>
		/// </item>
		/// </list>
		/// <para>If the function fails, the function returns one of the following error codes.</para>
		/// <list type="table">
		/// <listheader>
		/// <term>Return code</term>
		/// <term>Description</term>
		/// </listheader>
		/// <item>
		/// <term>SEC_E_INSUFFICIENT_MEMORY</term>
		/// <term>There is not enough memory available to complete the requested action.</term>
		/// </item>
		/// <item>
		/// <term>SEC_E_INTERNAL_ERROR</term>
		/// <term>An error occurred that did not map to an SSPI error code.</term>
		/// </item>
		/// <item>
		/// <term>SEC_E_INVALID_HANDLE</term>
		/// <term>The handle passed to the function is not valid.</term>
		/// </item>
		/// <item>
		/// <term>SEC_E_INVALID_TOKEN</term>
		/// <term>
		/// The error is due to a malformed input token, such as a token corrupted in transit, a token of incorrect size, or a token passed
		/// into the wrong security package. Passing a token to the wrong package can happen if the client and server did not negotiate the
		/// proper security package.
		/// </term>
		/// </item>
		/// <item>
		/// <term>SEC_E_LOGON_DENIED</term>
		/// <term>The logon failed.</term>
		/// </item>
		/// <item>
		/// <term>SEC_E_NO_AUTHENTICATING_AUTHORITY</term>
		/// <term>
		/// No authority could be contacted for authentication. The domain name of the authenticating party could be wrong, the domain could
		/// be unreachable, or there might have been a trust relationship failure.
		/// </term>
		/// </item>
		/// <item>
		/// <term>SEC_E_NO_CREDENTIALS</term>
		/// <term>No credentials are available in the security package.</term>
		/// </item>
		/// <item>
		/// <term>SEC_E_TARGET_UNKNOWN</term>
		/// <term>The target was not recognized.</term>
		/// </item>
		/// <item>
		/// <term>SEC_E_UNSUPPORTED_FUNCTION</term>
		/// <term>
		/// A context attribute flag that is not valid (ISC_REQ_DELEGATE or ISC_REQ_PROMPT_FOR_CREDS) was specified in the fContextReq parameter.
		/// </term>
		/// </item>
		/// <item>
		/// <term>SEC_E_WRONG_PRINCIPAL</term>
		/// <term>
		/// The principal that received the authentication request is not the same as the one passed into the pszTargetName parameter. This
		/// indicates a failure in mutual authentication.
		/// </term>
		/// </item>
		/// </list>
		/// </returns>
		/// <remarks>
		/// <para>
		/// The caller is responsible for determining whether the final context attributes are sufficient. If, for example, confidentiality
		/// was requested, but could not be established, some applications may choose to shut down the connection immediately.
		/// </para>
		/// <para>
		/// If attributes of the security context are not sufficient, the client must free the partially created context by calling the
		/// DeleteSecurityContext function.
		/// </para>
		/// <para>The <c>InitializeSecurityContext (General)</c> function is used by a client to initialize an outbound context.</para>
		/// <para>For a two-leg security context, the calling sequence is as follows:</para>
		/// <list type="number">
		/// <item>
		/// <term>The client calls the function with phContext set to <c>NULL</c> and fills in the buffer descriptor with the input message.</term>
		/// </item>
		/// <item>
		/// <term>
		/// The security package examines the parameters and constructs an opaque token, placing it in the TOKEN element in the buffer array.
		/// If the fContextReq parameter includes the ISC_REQ_ALLOCATE_MEMORY flag, the security package allocates the memory and returns the
		/// pointer in the TOKEN element.
		/// </term>
		/// </item>
		/// <item>
		/// <term>
		/// The client sends the token returned in the pOutput buffer to the target server. The server then passes the token as an input
		/// argument in a call to the AcceptSecurityContext (General) function.
		/// </term>
		/// </item>
		/// <item>
		/// <term>
		/// AcceptSecurityContext (General) may return a token, which the server sends to the client for a second call to
		/// <c>InitializeSecurityContext (General)</c> if the first call returned SEC_I_CONTINUE_NEEDED.
		/// </term>
		/// </item>
		/// </list>
		/// <para>For multiple-leg security contexts, such as mutual authentication, the calling sequence is as follows:</para>
		/// <list type="number">
		/// <item>
		/// <term>The client calls the function as described earlier, but the package returns the SEC_I_CONTINUE_NEEDED success code.</term>
		/// </item>
		/// <item>
		/// <term>The client sends the output token to the server and waits for the server's reply.</term>
		/// </item>
		/// <item>
		/// <term>
		/// Upon receipt of the server's response, the client calls <c>InitializeSecurityContext (General)</c> again, with phContext set to
		/// the handle that was returned from the last call. The token received from the server is supplied in the pInput parameter.
		/// </term>
		/// </item>
		/// </list>
		/// <para>If the server has successfully responded, the security package returns SEC_E_OK and a secure session is established.</para>
		/// <para>If the function returns one of the error responses, the server's response is not accepted, and the session is not established.</para>
		/// <para>
		/// If the function returns SEC_I_CONTINUE_NEEDED, SEC_I_COMPLETE_NEEDED, or SEC_I_COMPLETE_AND_CONTINUE, steps 2 and 3 are repeated.
		/// </para>
		/// <para>
		/// To initialize a security context, more than one call to this function may be required, depending on the underlying authentication
		/// mechanism as well as the choices specified in the fContextReq parameter.
		/// </para>
		/// <para>
		/// The fContextReq and pfContextAttributes parameters are bitmasks that represent various context attributes. For a description of
		/// the various attributes, see Context Requirements. The pfContextAttributes parameter is valid on any successful return, but only
		/// on the final successful return should you examine the flags that pertain to security aspects of the context. Intermediate returns
		/// can set, for example, the ISC_RET_ALLOCATED_MEMORY flag.
		/// </para>
		/// <para>
		/// If the ISC_REQ_USE_SUPPLIED_CREDS flag is set, the security package must look for a SECBUFFER_PKG_PARAMS buffer type in the
		/// pInput input buffer. This is not a generic solution, but it allows for a strong pairing of security package and application when appropriate.
		/// </para>
		/// <para>If ISC_REQ_ALLOCATE_MEMORY was specified, the caller must free the memory by calling the FreeContextBuffer function.</para>
		/// <para>
		/// For example, the input token could be the challenge from a LAN Manager. In this case, the output token would be the
		/// NTLM-encrypted response to the challenge.
		/// </para>
		/// <para>
		/// The action the client takes depends on the return code from this function. If the return code is SEC_E_OK, there will be no
		/// second <c>InitializeSecurityContext (General)</c> call, and no response from the server is expected. If the return code is
		/// SEC_I_CONTINUE_NEEDED, the client expects a token in response from the server and passes it in a second call to
		/// <c>InitializeSecurityContext (General)</c>. The SEC_I_COMPLETE_NEEDED return code indicates that the client must finish building
		/// the message and call the CompleteAuthToken function. The SEC_I_COMPLETE_AND_CONTINUE code incorporates both of these actions.
		/// </para>
		/// <para>
		/// If <c>InitializeSecurityContext (General)</c> returns success on the first (or only) call, then the caller must eventually call
		/// the DeleteSecurityContext function on the returned handle, even if the call fails on a later leg of the authentication exchange.
		/// </para>
		/// <para>
		/// The client may call <c>InitializeSecurityContext (General)</c> again after it has completed successfully. This indicates to the
		/// security package that a reauthentication is wanted.
		/// </para>
		/// <para>
		/// Kernel mode callers have the following differences: the target name is a Unicode string that must be allocated in virtual memory
		/// by using VirtualAlloc; it must not be allocated from the pool. Buffers passed and supplied in pInput and pOutput must be in
		/// virtual memory, not in the pool.
		/// </para>
		/// <para>
		/// When using the Schannel SSP, if the function returns SEC_I_INCOMPLETE_CREDENTIALS, check that you specified a valid and trusted
		/// certificate in your credentials. The certificate is specified when calling the AcquireCredentialsHandle (General) function. The
		/// certificate must be a client authentication certificate issued by a certification authority (CA) trusted by the server. To obtain
		/// a list of the CAs trusted by the server, call the QueryContextAttributes (General) function and specify the
		/// SECPKG_ATTR_ISSUER_LIST_EX attribute.
		/// </para>
		/// <para>
		/// When using the Schannel SSP, after a client application receives an authentication certificate from a CA that is trusted by the
		/// server, the application creates a new credential by calling the AcquireCredentialsHandle (General) function and then calling
		/// <c>InitializeSecurityContext (General)</c> again, specifying the new credential in the phCredential parameter.
		/// </para>
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows/desktop/api/sspi/nf-sspi-initializesecuritycontexta SECURITY_STATUS SEC_ENTRY
		// InitializeSecurityContextA( PCredHandle phCredential, PCtxtHandle phContext, SEC_CHAR *pszTargetName, unsigned long fContextReq,
		// unsigned long Reserved1, unsigned long TargetDataRep, PSecBufferDesc pInput, unsigned long Reserved2, PCtxtHandle phNewContext,
		// PSecBufferDesc pOutput, unsigned long *pfContextAttr, PTimeStamp ptsExpiry );
		[DllImport(Lib.Secur32, SetLastError = false, CharSet = CharSet.Auto)]
		[PInvokeData("sspi.h", MSDNShortId = "21d965d4-3c03-4e29-a70d-4538c5c366b0")]
		public static extern HRESULT InitializeSecurityContext(in CredHandle phCredential, [In, Optional] IntPtr phContext, string pszTargetName, [In] ASC_REQ fContextReq, [Optional] int Reserved1, [In] DREP TargetDataRep,
			[In, Optional] IntPtr pInput, [Optional] int Reserved2, ref CtxtHandle phNewContext, ref SecBufferDesc pOutput, out ASC_RET pfContextAttr, out TimeStamp ptsExpiry);

		/// <summary>
		/// <para>
		/// The <c>InitializeSecurityContext (General)</c> function initiates the client side, outbound security context from a credential
		/// handle. The function is used to build a security context between the client application and a remote peer.
		/// <c>InitializeSecurityContext (General)</c> returns a token that the client must pass to the remote peer, which the peer in turn
		/// submits to the local security implementation through the AcceptSecurityContext (General) call. The token generated should be
		/// considered opaque by all callers.
		/// </para>
		/// <para>
		/// Typically, the <c>InitializeSecurityContext (General)</c> function is called in a loop until a sufficient security context is established.
		/// </para>
		/// <para>For information about using this function with a specific security support provider (SSP), see the following topics.</para>
		/// <list type="table">
		///   <listheader>
		///     <term>Topic</term>
		///     <term>Description</term>
		///   </listheader>
		///   <item>
		///     <term>InitializeSecurityContext (CredSSP)</term>
		///     <term>
		/// Initiates the client side, outbound security context from a credential handle by using the Credential Security Support Provider (CredSSP).
		/// </term>
		///   </item>
		///   <item>
		///     <term>InitializeSecurityContext (Digest)</term>
		///     <term>Initiates the client side, outbound security context from a credential handle by using the Digest security package.</term>
		///   </item>
		///   <item>
		///     <term>InitializeSecurityContext (Kerberos)</term>
		///     <term>Initiates the client side, outbound security context from a credential handle by using the Kerberos security package.</term>
		///   </item>
		///   <item>
		///     <term>InitializeSecurityContext (Negotiate)</term>
		///     <term>Initiates the client side, outbound security context from a credential handle by using the Negotiate security package.</term>
		///   </item>
		///   <item>
		///     <term>InitializeSecurityContext (NTLM)</term>
		///     <term>Initiates the client side, outbound security context from a credential handle by using the NTLM security package.</term>
		///   </item>
		///   <item>
		///     <term>InitializeSecurityContext (Schannel)</term>
		///     <term>Initiates the client side, outbound security context from a credential handle by using the Schannel security package.</term>
		///   </item>
		/// </list>
		/// </summary>
		/// <param name="phCredential">A handle to the credentials returned by AcquireCredentialsHandle (General). This handle is used to build the security context.
		/// The <c>InitializeSecurityContext (General)</c> function requires at least OUTBOUND credentials.</param>
		/// <param name="phContext"><para>
		/// A pointer to a CtxtHandle structure. On the first call to <c>InitializeSecurityContext (General)</c>, this pointer is
		/// <c>NULL</c>. On the second call, this parameter is a pointer to the handle to the partially formed context returned in the
		/// phNewContext parameter by the first call.
		/// </para>
		/// <para>This parameter is optional with the Microsoft Digest SSP and can be set to <c>NULL</c>.</para>
		/// <para>
		/// When using the Schannel SSP, on the first call to <c>InitializeSecurityContext (General)</c>, specify <c>NULL</c>. On future
		/// calls, specify the token received in the phNewContext parameter after the first call to this function.
		/// </para></param>
		/// <param name="pszTargetName">TBD</param>
		/// <param name="fContextReq"><para>
		/// Bit flags that indicate requests for the context. Not all packages can support all requirements. Flags used for this parameter
		/// are prefixed with ISC_REQ_, for example, ISC_REQ_DELEGATE. This parameter can be one or more of the following attributes flags.
		/// </para>
		/// <list type="table">
		///   <listheader>
		///     <term>Value</term>
		///     <term>Meaning</term>
		///   </listheader>
		///   <item>
		///     <term>ISC_REQ_ALLOCATE_MEMORY</term>
		///     <term>
		/// The security package allocates output buffers for you. When you have finished using the output buffers, free them by calling the
		/// FreeContextBuffer function.
		/// </term>
		///   </item>
		///   <item>
		///     <term>ISC_REQ_CONFIDENTIALITY</term>
		///     <term>Encrypt messages by using the EncryptMessage function.</term>
		///   </item>
		///   <item>
		///     <term>ISC_REQ_CONNECTION</term>
		///     <term>
		/// The security context will not handle formatting messages. This value is the default for the Kerberos, Negotiate, and NTLM
		/// security packages.
		/// </term>
		///   </item>
		///   <item>
		///     <term>ISC_REQ_DELEGATE</term>
		///     <term>
		/// The server can use the context to authenticate to other servers as the client. The ISC_REQ_MUTUAL_AUTH flag must be set for this
		/// flag to work. Valid for Kerberos. Ignore this flag for constrained delegation.
		/// </term>
		///   </item>
		///   <item>
		///     <term>ISC_REQ_EXTENDED_ERROR</term>
		///     <term>When errors occur, the remote party will be notified.</term>
		///   </item>
		///   <item>
		///     <term>ISC_REQ_HTTP</term>
		///     <term>Use Digest for HTTP. Omit this flag to use Digest as a SASL mechanism.</term>
		///   </item>
		///   <item>
		///     <term>ISC_REQ_INTEGRITY</term>
		///     <term>Sign messages and verify signatures by using the EncryptMessage and MakeSignature functions.</term>
		///   </item>
		///   <item>
		///     <term>ISC_REQ_MANUAL_CRED_VALIDATION</term>
		///     <term>Schannel must not authenticate the server automatically.</term>
		///   </item>
		///   <item>
		///     <term>ISC_REQ_MUTUAL_AUTH</term>
		///     <term>The mutual authentication policy of the service will be satisfied.</term>
		///   </item>
		///   <item>
		///     <term>ISC_REQ_NO_INTEGRITY</term>
		///     <term>
		/// If this flag is set, the ISC_REQ_INTEGRITY flag is ignored. This value is supported only by the Negotiate and Kerberos security packages.
		/// </term>
		///   </item>
		///   <item>
		///     <term>ISC_REQ_REPLAY_DETECT</term>
		///     <term>Detect replayed messages that have been encoded by using the EncryptMessage or MakeSignature functions.</term>
		///   </item>
		///   <item>
		///     <term>ISC_REQ_SEQUENCE_DETECT</term>
		///     <term>Detect messages received out of sequence.</term>
		///   </item>
		///   <item>
		///     <term>ISC_REQ_STREAM</term>
		///     <term>Support a stream-oriented connection.</term>
		///   </item>
		///   <item>
		///     <term>ISC_REQ_USE_SESSION_KEY</term>
		///     <term>A new session key must be negotiated. This value is supported only by the Kerberos security package.</term>
		///   </item>
		///   <item>
		///     <term>ISC_REQ_USE_SUPPLIED_CREDS</term>
		///     <term>Schannel must not attempt to supply credentials for the client automatically.</term>
		///   </item>
		/// </list>
		/// <para>The requested attributes may not be supported by the client. For more information, see the pfContextAttr parameter.</para>
		/// <para>For further descriptions of the various attributes, see Context Requirements.</para></param>
		/// <param name="TargetDataRep"><para>The data representation, such as byte ordering, on the target. This parameter can be either SECURITY_NATIVE_DREP or SECURITY_NETWORK_DREP.</para>
		/// <para>This parameter is not used with Digest or Schannel. Set it to zero.</para></param>
		/// <param name="pInput">A pointer to a SecBufferDesc structure that contains pointers to the buffers supplied as input to the package. Unless the client
		/// context was initiated by the server, the value of this parameter must be <c>NULL</c> on the first call to the function. On
		/// subsequent calls to the function or when the client context was initiated by the server, the value of this parameter is a pointer
		/// to a buffer allocated with enough memory to hold the token returned by the remote computer.</param>
		/// <param name="outputType">Type of the output.</param>
		/// <param name="pOutput"><para>
		/// A pointer to a SecBufferDesc structure that contains pointers to the SecBuffer structure that receives the output data. If a
		/// buffer was typed as SEC_READWRITE in the input, it will be there on output. The system will allocate a buffer for the security
		/// token if requested (through ISC_REQ_ALLOCATE_MEMORY) and fill in the address in the buffer descriptor for the security token.
		/// </para>
		/// <para>When using the Microsoft Digest SSP, this parameter receives the challenge response that must be sent to the server.</para>
		/// <para>
		/// When using the Schannel SSP, if the ISC_REQ_ALLOCATE_MEMORY flag is specified, the Schannel SSP will allocate memory for the
		/// buffer and put the appropriate information in the SecBufferDesc. In addition, the caller must pass in a buffer of type
		/// <c>SECBUFFER_ALERT</c>. On output, if an alert is generated, this buffer contains information about that alert, and the function fails.
		/// </para></param>
		/// <param name="pfContextAttr"><para>
		/// A pointer to a variable to receive a set of bit flags that indicate the attributes of the established context. For a description
		/// of the various attributes, see Context Requirements.
		/// </para>
		/// <para>Flags used for this parameter are prefixed with ISC_RET, such as ISC_RET_DELEGATE.</para>
		/// <para>For a list of valid values, see the fContextReq parameter.</para>
		/// <para>
		/// Do not check for security-related attributes until the final function call returns successfully. Attribute flags that are not
		/// related to security, such as the ASC_RET_ALLOCATED_MEMORY flag, can be checked before the final return.
		/// </para>
		/// <para>
		///   <c>Note</c> Particular context attributes can change during negotiation with a remote peer.</para></param>
		/// <param name="ptsExpiry"><para>
		/// A pointer to a TimeStamp structure that receives the expiration time of the context. It is recommended that the security package
		/// always return this value in local time. This parameter is optional and <c>NULL</c> should be passed for short-lived clients.
		/// </para>
		/// <para>There is no expiration time for Microsoft Digest SSP security contexts or credentials.</para></param>
		/// <returns>
		/// <para>If the function succeeds, the function returns one of the following success codes.</para>
		/// <list type="table">
		///   <listheader>
		///     <term>Return code</term>
		///     <term>Description</term>
		///   </listheader>
		///   <item>
		///     <term>SEC_I_COMPLETE_AND_CONTINUE</term>
		///     <term>
		/// The client must call CompleteAuthToken and then pass the output to the server. The client then waits for a returned token and
		/// passes it, in another call, to InitializeSecurityContext (General).
		/// </term>
		///   </item>
		///   <item>
		///     <term>SEC_I_COMPLETE_NEEDED</term>
		///     <term>The client must finish building the message and then call the CompleteAuthToken function.</term>
		///   </item>
		///   <item>
		///     <term>SEC_I_CONTINUE_NEEDED</term>
		///     <term>
		/// The client must send the output token to the server and wait for a return token. The returned token is then passed in another
		/// call to InitializeSecurityContext (General). The output token can be empty.
		/// </term>
		///   </item>
		///   <item>
		///     <term>SEC_I_INCOMPLETE_CREDENTIALS</term>
		///     <term>
		/// Use with Schannel. The server has requested client authentication, and the supplied credentials either do not include a
		/// certificate or the certificate was not issued by a certification authority that is trusted by the server. For more information,
		/// see Remarks.
		/// </term>
		///   </item>
		///   <item>
		///     <term>SEC_E_INCOMPLETE_MESSAGE</term>
		///     <term>
		/// Use with Schannel. Data for the whole message was not read from the wire. When this value is returned, the pInput buffer contains
		/// a SecBuffer structure with a BufferType member of SECBUFFER_MISSING. The cbBuffer member of SecBuffer contains a value that
		/// indicates the number of additional bytes that the function must read from the client before this function succeeds. While this
		/// number is not always accurate, using it can help improve performance by avoiding multiple calls to this function.
		/// </term>
		///   </item>
		///   <item>
		///     <term>SEC_E_OK</term>
		///     <term>
		/// The security context was successfully initialized. There is no need for another InitializeSecurityContext (General) call. If the
		/// function returns an output token, that is, if the SECBUFFER_TOKEN in pOutput is of nonzero length, that token must be sent to the server.
		/// </term>
		///   </item>
		/// </list>
		/// <para>If the function fails, the function returns one of the following error codes.</para>
		/// <list type="table">
		///   <listheader>
		///     <term>Return code</term>
		///     <term>Description</term>
		///   </listheader>
		///   <item>
		///     <term>SEC_E_INSUFFICIENT_MEMORY</term>
		///     <term>There is not enough memory available to complete the requested action.</term>
		///   </item>
		///   <item>
		///     <term>SEC_E_INTERNAL_ERROR</term>
		///     <term>An error occurred that did not map to an SSPI error code.</term>
		///   </item>
		///   <item>
		///     <term>SEC_E_INVALID_HANDLE</term>
		///     <term>The handle passed to the function is not valid.</term>
		///   </item>
		///   <item>
		///     <term>SEC_E_INVALID_TOKEN</term>
		///     <term>
		/// The error is due to a malformed input token, such as a token corrupted in transit, a token of incorrect size, or a token passed
		/// into the wrong security package. Passing a token to the wrong package can happen if the client and server did not negotiate the
		/// proper security package.
		/// </term>
		///   </item>
		///   <item>
		///     <term>SEC_E_LOGON_DENIED</term>
		///     <term>The logon failed.</term>
		///   </item>
		///   <item>
		///     <term>SEC_E_NO_AUTHENTICATING_AUTHORITY</term>
		///     <term>
		/// No authority could be contacted for authentication. The domain name of the authenticating party could be wrong, the domain could
		/// be unreachable, or there might have been a trust relationship failure.
		/// </term>
		///   </item>
		///   <item>
		///     <term>SEC_E_NO_CREDENTIALS</term>
		///     <term>No credentials are available in the security package.</term>
		///   </item>
		///   <item>
		///     <term>SEC_E_TARGET_UNKNOWN</term>
		///     <term>The target was not recognized.</term>
		///   </item>
		///   <item>
		///     <term>SEC_E_UNSUPPORTED_FUNCTION</term>
		///     <term>
		/// A context attribute flag that is not valid (ISC_REQ_DELEGATE or ISC_REQ_PROMPT_FOR_CREDS) was specified in the fContextReq parameter.
		/// </term>
		///   </item>
		///   <item>
		///     <term>SEC_E_WRONG_PRINCIPAL</term>
		///     <term>
		/// The principal that received the authentication request is not the same as the one passed into the pszTargetName parameter. This
		/// indicates a failure in mutual authentication.
		/// </term>
		///   </item>
		/// </list>
		/// </returns>
		/// <remarks>
		/// <para>
		/// The caller is responsible for determining whether the final context attributes are sufficient. If, for example, confidentiality
		/// was requested, but could not be established, some applications may choose to shut down the connection immediately.
		/// </para>
		/// <para>
		/// If attributes of the security context are not sufficient, the client must free the partially created context by calling the
		/// DeleteSecurityContext function.
		/// </para>
		/// <para>The <c>InitializeSecurityContext (General)</c> function is used by a client to initialize an outbound context.</para>
		/// <para>For a two-leg security context, the calling sequence is as follows:</para>
		/// <list type="number">
		///   <item>
		///     <term>The client calls the function with phContext set to <c>NULL</c> and fills in the buffer descriptor with the input message.</term>
		///   </item>
		///   <item>
		///     <term>
		/// The security package examines the parameters and constructs an opaque token, placing it in the TOKEN element in the buffer array.
		/// If the fContextReq parameter includes the ISC_REQ_ALLOCATE_MEMORY flag, the security package allocates the memory and returns the
		/// pointer in the TOKEN element.
		/// </term>
		///   </item>
		///   <item>
		///     <term>
		/// The client sends the token returned in the pOutput buffer to the target server. The server then passes the token as an input
		/// argument in a call to the AcceptSecurityContext (General) function.
		/// </term>
		///   </item>
		///   <item>
		///     <term>
		/// AcceptSecurityContext (General) may return a token, which the server sends to the client for a second call to
		/// <c>InitializeSecurityContext (General)</c> if the first call returned SEC_I_CONTINUE_NEEDED.
		/// </term>
		///   </item>
		/// </list>
		/// <para>For multiple-leg security contexts, such as mutual authentication, the calling sequence is as follows:</para>
		/// <list type="number">
		///   <item>
		///     <term>The client calls the function as described earlier, but the package returns the SEC_I_CONTINUE_NEEDED success code.</term>
		///   </item>
		///   <item>
		///     <term>The client sends the output token to the server and waits for the server's reply.</term>
		///   </item>
		///   <item>
		///     <term>
		/// Upon receipt of the server's response, the client calls <c>InitializeSecurityContext (General)</c> again, with phContext set to
		/// the handle that was returned from the last call. The token received from the server is supplied in the pInput parameter.
		/// </term>
		///   </item>
		/// </list>
		/// <para>If the server has successfully responded, the security package returns SEC_E_OK and a secure session is established.</para>
		/// <para>If the function returns one of the error responses, the server's response is not accepted, and the session is not established.</para>
		/// <para>
		/// If the function returns SEC_I_CONTINUE_NEEDED, SEC_I_COMPLETE_NEEDED, or SEC_I_COMPLETE_AND_CONTINUE, steps 2 and 3 are repeated.
		/// </para>
		/// <para>
		/// To initialize a security context, more than one call to this function may be required, depending on the underlying authentication
		/// mechanism as well as the choices specified in the fContextReq parameter.
		/// </para>
		/// <para>
		/// The fContextReq and pfContextAttributes parameters are bitmasks that represent various context attributes. For a description of
		/// the various attributes, see Context Requirements. The pfContextAttributes parameter is valid on any successful return, but only
		/// on the final successful return should you examine the flags that pertain to security aspects of the context. Intermediate returns
		/// can set, for example, the ISC_RET_ALLOCATED_MEMORY flag.
		/// </para>
		/// <para>
		/// If the ISC_REQ_USE_SUPPLIED_CREDS flag is set, the security package must look for a SECBUFFER_PKG_PARAMS buffer type in the
		/// pInput input buffer. This is not a generic solution, but it allows for a strong pairing of security package and application when appropriate.
		/// </para>
		/// <para>If ISC_REQ_ALLOCATE_MEMORY was specified, the caller must free the memory by calling the FreeContextBuffer function.</para>
		/// <para>
		/// For example, the input token could be the challenge from a LAN Manager. In this case, the output token would be the
		/// NTLM-encrypted response to the challenge.
		/// </para>
		/// <para>
		/// The action the client takes depends on the return code from this function. If the return code is SEC_E_OK, there will be no
		/// second <c>InitializeSecurityContext (General)</c> call, and no response from the server is expected. If the return code is
		/// SEC_I_CONTINUE_NEEDED, the client expects a token in response from the server and passes it in a second call to
		/// <c>InitializeSecurityContext (General)</c>. The SEC_I_COMPLETE_NEEDED return code indicates that the client must finish building
		/// the message and call the CompleteAuthToken function. The SEC_I_COMPLETE_AND_CONTINUE code incorporates both of these actions.
		/// </para>
		/// <para>
		/// If <c>InitializeSecurityContext (General)</c> returns success on the first (or only) call, then the caller must eventually call
		/// the DeleteSecurityContext function on the returned handle, even if the call fails on a later leg of the authentication exchange.
		/// </para>
		/// <para>
		/// The client may call <c>InitializeSecurityContext (General)</c> again after it has completed successfully. This indicates to the
		/// security package that a reauthentication is wanted.
		/// </para>
		/// <para>
		/// Kernel mode callers have the following differences: the target name is a Unicode string that must be allocated in virtual memory
		/// by using VirtualAlloc; it must not be allocated from the pool. Buffers passed and supplied in pInput and pOutput must be in
		/// virtual memory, not in the pool.
		/// </para>
		/// <para>
		/// When using the Schannel SSP, if the function returns SEC_I_INCOMPLETE_CREDENTIALS, check that you specified a valid and trusted
		/// certificate in your credentials. The certificate is specified when calling the AcquireCredentialsHandle (General) function. The
		/// certificate must be a client authentication certificate issued by a certification authority (CA) trusted by the server. To obtain
		/// a list of the CAs trusted by the server, call the QueryContextAttributes (General) function and specify the
		/// SECPKG_ATTR_ISSUER_LIST_EX attribute.
		/// </para>
		/// <para>
		/// When using the Schannel SSP, after a client application receives an authentication certificate from a CA that is trusted by the
		/// server, the application creates a new credential by calling the AcquireCredentialsHandle (General) function and then calling
		/// <c>InitializeSecurityContext (General)</c> again, specifying the new credential in the phCredential parameter.
		/// </para>
		/// </remarks>
		public static HRESULT InitializeSecurityContext(in CredHandle phCredential, [In, Out] SafeCtxtHandle phContext, string pszTargetName, ASC_REQ fContextReq, DREP TargetDataRep,
			[In, Optional] SecBufferDesc? pInput, SecBufferType outputType, out SafeSecBufferDesc pOutput, out ASC_RET pfContextAttr, out TimeStamp ptsExpiry)
		{
			pOutput = new SafeSecBufferDesc(outputType);
			return InitializeSecurityContext(phCredential, phContext, pszTargetName, fContextReq, TargetDataRep, pInput, pOutput, out pfContextAttr, out ptsExpiry);
		}

		/// <summary>
		/// <para>
		/// The <c>InitializeSecurityContext (General)</c> function initiates the client side, outbound security context from a credential
		/// handle. The function is used to build a security context between the client application and a remote peer.
		/// <c>InitializeSecurityContext (General)</c> returns a token that the client must pass to the remote peer, which the peer in turn
		/// submits to the local security implementation through the AcceptSecurityContext (General) call. The token generated should be
		/// considered opaque by all callers.
		/// </para>
		/// <para>
		/// Typically, the <c>InitializeSecurityContext (General)</c> function is called in a loop until a sufficient security context is established.
		/// </para>
		/// <para>For information about using this function with a specific security support provider (SSP), see the following topics.</para>
		/// <list type="table">
		///   <listheader>
		///     <term>Topic</term>
		///     <term>Description</term>
		///   </listheader>
		///   <item>
		///     <term>InitializeSecurityContext (CredSSP)</term>
		///     <term>
		/// Initiates the client side, outbound security context from a credential handle by using the Credential Security Support Provider (CredSSP).
		/// </term>
		///   </item>
		///   <item>
		///     <term>InitializeSecurityContext (Digest)</term>
		///     <term>Initiates the client side, outbound security context from a credential handle by using the Digest security package.</term>
		///   </item>
		///   <item>
		///     <term>InitializeSecurityContext (Kerberos)</term>
		///     <term>Initiates the client side, outbound security context from a credential handle by using the Kerberos security package.</term>
		///   </item>
		///   <item>
		///     <term>InitializeSecurityContext (Negotiate)</term>
		///     <term>Initiates the client side, outbound security context from a credential handle by using the Negotiate security package.</term>
		///   </item>
		///   <item>
		///     <term>InitializeSecurityContext (NTLM)</term>
		///     <term>Initiates the client side, outbound security context from a credential handle by using the NTLM security package.</term>
		///   </item>
		///   <item>
		///     <term>InitializeSecurityContext (Schannel)</term>
		///     <term>Initiates the client side, outbound security context from a credential handle by using the Schannel security package.</term>
		///   </item>
		/// </list>
		/// </summary>
		/// <param name="phCredential">A handle to the credentials returned by AcquireCredentialsHandle (General). This handle is used to build the security context.
		/// The <c>InitializeSecurityContext (General)</c> function requires at least OUTBOUND credentials.</param>
		/// <param name="phContext"><para>
		/// A pointer to a CtxtHandle structure. On the first call to <c>InitializeSecurityContext (General)</c>, this pointer is
		/// <c>NULL</c>. On the second call, this parameter is a pointer to the handle to the partially formed context returned in the
		/// phNewContext parameter by the first call.
		/// </para>
		/// <para>This parameter is optional with the Microsoft Digest SSP and can be set to <c>NULL</c>.</para>
		/// <para>
		/// When using the Schannel SSP, on the first call to <c>InitializeSecurityContext (General)</c>, specify <c>NULL</c>. On future
		/// calls, specify the token received in the phNewContext parameter after the first call to this function.
		/// </para></param>
		/// <param name="pszTargetName">TBD</param>
		/// <param name="fContextReq"><para>
		/// Bit flags that indicate requests for the context. Not all packages can support all requirements. Flags used for this parameter
		/// are prefixed with ISC_REQ_, for example, ISC_REQ_DELEGATE. This parameter can be one or more of the following attributes flags.
		/// </para>
		/// <list type="table">
		///   <listheader>
		///     <term>Value</term>
		///     <term>Meaning</term>
		///   </listheader>
		///   <item>
		///     <term>ISC_REQ_ALLOCATE_MEMORY</term>
		///     <term>
		/// The security package allocates output buffers for you. When you have finished using the output buffers, free them by calling the
		/// FreeContextBuffer function.
		/// </term>
		///   </item>
		///   <item>
		///     <term>ISC_REQ_CONFIDENTIALITY</term>
		///     <term>Encrypt messages by using the EncryptMessage function.</term>
		///   </item>
		///   <item>
		///     <term>ISC_REQ_CONNECTION</term>
		///     <term>
		/// The security context will not handle formatting messages. This value is the default for the Kerberos, Negotiate, and NTLM
		/// security packages.
		/// </term>
		///   </item>
		///   <item>
		///     <term>ISC_REQ_DELEGATE</term>
		///     <term>
		/// The server can use the context to authenticate to other servers as the client. The ISC_REQ_MUTUAL_AUTH flag must be set for this
		/// flag to work. Valid for Kerberos. Ignore this flag for constrained delegation.
		/// </term>
		///   </item>
		///   <item>
		///     <term>ISC_REQ_EXTENDED_ERROR</term>
		///     <term>When errors occur, the remote party will be notified.</term>
		///   </item>
		///   <item>
		///     <term>ISC_REQ_HTTP</term>
		///     <term>Use Digest for HTTP. Omit this flag to use Digest as a SASL mechanism.</term>
		///   </item>
		///   <item>
		///     <term>ISC_REQ_INTEGRITY</term>
		///     <term>Sign messages and verify signatures by using the EncryptMessage and MakeSignature functions.</term>
		///   </item>
		///   <item>
		///     <term>ISC_REQ_MANUAL_CRED_VALIDATION</term>
		///     <term>Schannel must not authenticate the server automatically.</term>
		///   </item>
		///   <item>
		///     <term>ISC_REQ_MUTUAL_AUTH</term>
		///     <term>The mutual authentication policy of the service will be satisfied.</term>
		///   </item>
		///   <item>
		///     <term>ISC_REQ_NO_INTEGRITY</term>
		///     <term>
		/// If this flag is set, the ISC_REQ_INTEGRITY flag is ignored. This value is supported only by the Negotiate and Kerberos security packages.
		/// </term>
		///   </item>
		///   <item>
		///     <term>ISC_REQ_REPLAY_DETECT</term>
		///     <term>Detect replayed messages that have been encoded by using the EncryptMessage or MakeSignature functions.</term>
		///   </item>
		///   <item>
		///     <term>ISC_REQ_SEQUENCE_DETECT</term>
		///     <term>Detect messages received out of sequence.</term>
		///   </item>
		///   <item>
		///     <term>ISC_REQ_STREAM</term>
		///     <term>Support a stream-oriented connection.</term>
		///   </item>
		///   <item>
		///     <term>ISC_REQ_USE_SESSION_KEY</term>
		///     <term>A new session key must be negotiated. This value is supported only by the Kerberos security package.</term>
		///   </item>
		///   <item>
		///     <term>ISC_REQ_USE_SUPPLIED_CREDS</term>
		///     <term>Schannel must not attempt to supply credentials for the client automatically.</term>
		///   </item>
		/// </list>
		/// <para>The requested attributes may not be supported by the client. For more information, see the pfContextAttr parameter.</para>
		/// <para>For further descriptions of the various attributes, see Context Requirements.</para></param>
		/// <param name="TargetDataRep"><para>The data representation, such as byte ordering, on the target. This parameter can be either SECURITY_NATIVE_DREP or SECURITY_NETWORK_DREP.</para>
		/// <para>This parameter is not used with Digest or Schannel. Set it to zero.</para></param>
		/// <param name="pInput">A pointer to a SecBufferDesc structure that contains pointers to the buffers supplied as input to the package. Unless the client
		/// context was initiated by the server, the value of this parameter must be <c>NULL</c> on the first call to the function. On
		/// subsequent calls to the function or when the client context was initiated by the server, the value of this parameter is a pointer
		/// to a buffer allocated with enough memory to hold the token returned by the remote computer.</param>
		/// <param name="pOutput"><para>
		/// A pointer to a SecBufferDesc structure that contains pointers to the SecBuffer structure that receives the output data. If a
		/// buffer was typed as SEC_READWRITE in the input, it will be there on output. The system will allocate a buffer for the security
		/// token if requested (through ISC_REQ_ALLOCATE_MEMORY) and fill in the address in the buffer descriptor for the security token.
		/// </para>
		/// <para>When using the Microsoft Digest SSP, this parameter receives the challenge response that must be sent to the server.</para>
		/// <para>
		/// When using the Schannel SSP, if the ISC_REQ_ALLOCATE_MEMORY flag is specified, the Schannel SSP will allocate memory for the
		/// buffer and put the appropriate information in the SecBufferDesc. In addition, the caller must pass in a buffer of type
		/// <c>SECBUFFER_ALERT</c>. On output, if an alert is generated, this buffer contains information about that alert, and the function fails.
		/// </para></param>
		/// <param name="pfContextAttr"><para>
		/// A pointer to a variable to receive a set of bit flags that indicate the attributes of the established context. For a description
		/// of the various attributes, see Context Requirements.
		/// </para>
		/// <para>Flags used for this parameter are prefixed with ISC_RET, such as ISC_RET_DELEGATE.</para>
		/// <para>For a list of valid values, see the fContextReq parameter.</para>
		/// <para>
		/// Do not check for security-related attributes until the final function call returns successfully. Attribute flags that are not
		/// related to security, such as the ASC_RET_ALLOCATED_MEMORY flag, can be checked before the final return.
		/// </para>
		/// <para>
		///   <c>Note</c> Particular context attributes can change during negotiation with a remote peer.</para></param>
		/// <param name="ptsExpiry"><para>
		/// A pointer to a TimeStamp structure that receives the expiration time of the context. It is recommended that the security package
		/// always return this value in local time. This parameter is optional and <c>NULL</c> should be passed for short-lived clients.
		/// </para>
		/// <para>There is no expiration time for Microsoft Digest SSP security contexts or credentials.</para></param>
		/// <returns>
		/// <para>If the function succeeds, the function returns one of the following success codes.</para>
		/// <list type="table">
		///   <listheader>
		///     <term>Return code</term>
		///     <term>Description</term>
		///   </listheader>
		///   <item>
		///     <term>SEC_I_COMPLETE_AND_CONTINUE</term>
		///     <term>
		/// The client must call CompleteAuthToken and then pass the output to the server. The client then waits for a returned token and
		/// passes it, in another call, to InitializeSecurityContext (General).
		/// </term>
		///   </item>
		///   <item>
		///     <term>SEC_I_COMPLETE_NEEDED</term>
		///     <term>The client must finish building the message and then call the CompleteAuthToken function.</term>
		///   </item>
		///   <item>
		///     <term>SEC_I_CONTINUE_NEEDED</term>
		///     <term>
		/// The client must send the output token to the server and wait for a return token. The returned token is then passed in another
		/// call to InitializeSecurityContext (General). The output token can be empty.
		/// </term>
		///   </item>
		///   <item>
		///     <term>SEC_I_INCOMPLETE_CREDENTIALS</term>
		///     <term>
		/// Use with Schannel. The server has requested client authentication, and the supplied credentials either do not include a
		/// certificate or the certificate was not issued by a certification authority that is trusted by the server. For more information,
		/// see Remarks.
		/// </term>
		///   </item>
		///   <item>
		///     <term>SEC_E_INCOMPLETE_MESSAGE</term>
		///     <term>
		/// Use with Schannel. Data for the whole message was not read from the wire. When this value is returned, the pInput buffer contains
		/// a SecBuffer structure with a BufferType member of SECBUFFER_MISSING. The cbBuffer member of SecBuffer contains a value that
		/// indicates the number of additional bytes that the function must read from the client before this function succeeds. While this
		/// number is not always accurate, using it can help improve performance by avoiding multiple calls to this function.
		/// </term>
		///   </item>
		///   <item>
		///     <term>SEC_E_OK</term>
		///     <term>
		/// The security context was successfully initialized. There is no need for another InitializeSecurityContext (General) call. If the
		/// function returns an output token, that is, if the SECBUFFER_TOKEN in pOutput is of nonzero length, that token must be sent to the server.
		/// </term>
		///   </item>
		/// </list>
		/// <para>If the function fails, the function returns one of the following error codes.</para>
		/// <list type="table">
		///   <listheader>
		///     <term>Return code</term>
		///     <term>Description</term>
		///   </listheader>
		///   <item>
		///     <term>SEC_E_INSUFFICIENT_MEMORY</term>
		///     <term>There is not enough memory available to complete the requested action.</term>
		///   </item>
		///   <item>
		///     <term>SEC_E_INTERNAL_ERROR</term>
		///     <term>An error occurred that did not map to an SSPI error code.</term>
		///   </item>
		///   <item>
		///     <term>SEC_E_INVALID_HANDLE</term>
		///     <term>The handle passed to the function is not valid.</term>
		///   </item>
		///   <item>
		///     <term>SEC_E_INVALID_TOKEN</term>
		///     <term>
		/// The error is due to a malformed input token, such as a token corrupted in transit, a token of incorrect size, or a token passed
		/// into the wrong security package. Passing a token to the wrong package can happen if the client and server did not negotiate the
		/// proper security package.
		/// </term>
		///   </item>
		///   <item>
		///     <term>SEC_E_LOGON_DENIED</term>
		///     <term>The logon failed.</term>
		///   </item>
		///   <item>
		///     <term>SEC_E_NO_AUTHENTICATING_AUTHORITY</term>
		///     <term>
		/// No authority could be contacted for authentication. The domain name of the authenticating party could be wrong, the domain could
		/// be unreachable, or there might have been a trust relationship failure.
		/// </term>
		///   </item>
		///   <item>
		///     <term>SEC_E_NO_CREDENTIALS</term>
		///     <term>No credentials are available in the security package.</term>
		///   </item>
		///   <item>
		///     <term>SEC_E_TARGET_UNKNOWN</term>
		///     <term>The target was not recognized.</term>
		///   </item>
		///   <item>
		///     <term>SEC_E_UNSUPPORTED_FUNCTION</term>
		///     <term>
		/// A context attribute flag that is not valid (ISC_REQ_DELEGATE or ISC_REQ_PROMPT_FOR_CREDS) was specified in the fContextReq parameter.
		/// </term>
		///   </item>
		///   <item>
		///     <term>SEC_E_WRONG_PRINCIPAL</term>
		///     <term>
		/// The principal that received the authentication request is not the same as the one passed into the pszTargetName parameter. This
		/// indicates a failure in mutual authentication.
		/// </term>
		///   </item>
		/// </list>
		/// </returns>
		/// <exception cref="System.ArgumentNullException">phContext</exception>
		/// <remarks>
		/// <para>
		/// The caller is responsible for determining whether the final context attributes are sufficient. If, for example, confidentiality
		/// was requested, but could not be established, some applications may choose to shut down the connection immediately.
		/// </para>
		/// <para>
		/// If attributes of the security context are not sufficient, the client must free the partially created context by calling the
		/// DeleteSecurityContext function.
		/// </para>
		/// <para>The <c>InitializeSecurityContext (General)</c> function is used by a client to initialize an outbound context.</para>
		/// <para>For a two-leg security context, the calling sequence is as follows:</para>
		/// <list type="number">
		///   <item>
		///     <term>The client calls the function with phContext set to <c>NULL</c> and fills in the buffer descriptor with the input message.</term>
		///   </item>
		///   <item>
		///     <term>
		/// The security package examines the parameters and constructs an opaque token, placing it in the TOKEN element in the buffer array.
		/// If the fContextReq parameter includes the ISC_REQ_ALLOCATE_MEMORY flag, the security package allocates the memory and returns the
		/// pointer in the TOKEN element.
		/// </term>
		///   </item>
		///   <item>
		///     <term>
		/// The client sends the token returned in the pOutput buffer to the target server. The server then passes the token as an input
		/// argument in a call to the AcceptSecurityContext (General) function.
		/// </term>
		///   </item>
		///   <item>
		///     <term>
		/// AcceptSecurityContext (General) may return a token, which the server sends to the client for a second call to
		/// <c>InitializeSecurityContext (General)</c> if the first call returned SEC_I_CONTINUE_NEEDED.
		/// </term>
		///   </item>
		/// </list>
		/// <para>For multiple-leg security contexts, such as mutual authentication, the calling sequence is as follows:</para>
		/// <list type="number">
		///   <item>
		///     <term>The client calls the function as described earlier, but the package returns the SEC_I_CONTINUE_NEEDED success code.</term>
		///   </item>
		///   <item>
		///     <term>The client sends the output token to the server and waits for the server's reply.</term>
		///   </item>
		///   <item>
		///     <term>
		/// Upon receipt of the server's response, the client calls <c>InitializeSecurityContext (General)</c> again, with phContext set to
		/// the handle that was returned from the last call. The token received from the server is supplied in the pInput parameter.
		/// </term>
		///   </item>
		/// </list>
		/// <para>If the server has successfully responded, the security package returns SEC_E_OK and a secure session is established.</para>
		/// <para>If the function returns one of the error responses, the server's response is not accepted, and the session is not established.</para>
		/// <para>
		/// If the function returns SEC_I_CONTINUE_NEEDED, SEC_I_COMPLETE_NEEDED, or SEC_I_COMPLETE_AND_CONTINUE, steps 2 and 3 are repeated.
		/// </para>
		/// <para>
		/// To initialize a security context, more than one call to this function may be required, depending on the underlying authentication
		/// mechanism as well as the choices specified in the fContextReq parameter.
		/// </para>
		/// <para>
		/// The fContextReq and pfContextAttributes parameters are bitmasks that represent various context attributes. For a description of
		/// the various attributes, see Context Requirements. The pfContextAttributes parameter is valid on any successful return, but only
		/// on the final successful return should you examine the flags that pertain to security aspects of the context. Intermediate returns
		/// can set, for example, the ISC_RET_ALLOCATED_MEMORY flag.
		/// </para>
		/// <para>
		/// If the ISC_REQ_USE_SUPPLIED_CREDS flag is set, the security package must look for a SECBUFFER_PKG_PARAMS buffer type in the
		/// pInput input buffer. This is not a generic solution, but it allows for a strong pairing of security package and application when appropriate.
		/// </para>
		/// <para>If ISC_REQ_ALLOCATE_MEMORY was specified, the caller must free the memory by calling the FreeContextBuffer function.</para>
		/// <para>
		/// For example, the input token could be the challenge from a LAN Manager. In this case, the output token would be the
		/// NTLM-encrypted response to the challenge.
		/// </para>
		/// <para>
		/// The action the client takes depends on the return code from this function. If the return code is SEC_E_OK, there will be no
		/// second <c>InitializeSecurityContext (General)</c> call, and no response from the server is expected. If the return code is
		/// SEC_I_CONTINUE_NEEDED, the client expects a token in response from the server and passes it in a second call to
		/// <c>InitializeSecurityContext (General)</c>. The SEC_I_COMPLETE_NEEDED return code indicates that the client must finish building
		/// the message and call the CompleteAuthToken function. The SEC_I_COMPLETE_AND_CONTINUE code incorporates both of these actions.
		/// </para>
		/// <para>
		/// If <c>InitializeSecurityContext (General)</c> returns success on the first (or only) call, then the caller must eventually call
		/// the DeleteSecurityContext function on the returned handle, even if the call fails on a later leg of the authentication exchange.
		/// </para>
		/// <para>
		/// The client may call <c>InitializeSecurityContext (General)</c> again after it has completed successfully. This indicates to the
		/// security package that a reauthentication is wanted.
		/// </para>
		/// <para>
		/// Kernel mode callers have the following differences: the target name is a Unicode string that must be allocated in virtual memory
		/// by using VirtualAlloc; it must not be allocated from the pool. Buffers passed and supplied in pInput and pOutput must be in
		/// virtual memory, not in the pool.
		/// </para>
		/// <para>
		/// When using the Schannel SSP, if the function returns SEC_I_INCOMPLETE_CREDENTIALS, check that you specified a valid and trusted
		/// certificate in your credentials. The certificate is specified when calling the AcquireCredentialsHandle (General) function. The
		/// certificate must be a client authentication certificate issued by a certification authority (CA) trusted by the server. To obtain
		/// a list of the CAs trusted by the server, call the QueryContextAttributes (General) function and specify the
		/// SECPKG_ATTR_ISSUER_LIST_EX attribute.
		/// </para>
		/// <para>
		/// When using the Schannel SSP, after a client application receives an authentication certificate from a CA that is trusted by the
		/// server, the application creates a new credential by calling the AcquireCredentialsHandle (General) function and then calling
		/// <c>InitializeSecurityContext (General)</c> again, specifying the new credential in the phCredential parameter.
		/// </para>
		/// </remarks>
		public static HRESULT InitializeSecurityContext(in CredHandle phCredential, [In, Out] SafeCtxtHandle phContext, string pszTargetName, ASC_REQ fContextReq, DREP TargetDataRep,
			SecBufferDesc? pInput, [In, Out] SafeSecBufferDesc pOutput, out ASC_RET pfContextAttr, out TimeStamp ptsExpiry)
		{
			if (phContext is null) throw new ArgumentNullException(nameof(phContext));
			unsafe
			{
				using (var pinnedInput = PinnedObject.FromNullable(pInput))
				{
					var hCtxt = CtxtHandle.Null;
					HRESULT hr = 0;
					fixed (CredHandle* pphCred = &phCredential)
						hr = InitializeSecurityContext(pphCred, phContext, pszTargetName, fContextReq | ASC_REQ.ASC_REQ_ALLOCATE_MEMORY, 0, TargetDataRep, (SecBufferDesc*)(IntPtr)pinnedInput, 0, ref hCtxt, pOutput, out pfContextAttr, out ptsExpiry);
					if (hr.Succeeded)
					{
						if (phContext.DangerousGetHandle().IsNull)
							phContext.SetHandle(hCtxt);
					}
					return hr;
				}
			}
		}

		/// <summary>
		/// The <c>InitSecurityInterface</c> function returns a pointer to an SSPI dispatch table. This function enables clients to use SSPI
		/// without binding directly to an implementation of the interface.
		/// </summary>
		/// <returns>
		/// <para>If the function succeeds, the return value is a pointer to a SecurityFunctionTable structure.</para>
		/// <para>If the function fails, the return value is <c>NULL</c>.</para>
		/// </returns>
		// https://docs.microsoft.com/en-us/windows/desktop/api/sspi/nf-sspi-initsecurityinterfacea PSecurityFunctionTableA SEC_ENTRY
		// InitSecurityInterfaceA( );
		[DllImport(Lib.Secur32, SetLastError = false, CharSet = CharSet.Auto)]
		[PInvokeData("sspi.h", MSDNShortId = "1026eeab-e2d6-45f2-9677-82d6cfbf4e12")]
		public static unsafe extern SecurityFunctionTable* InitSecurityInterface();

		/// <summary>
		/// <para>
		/// The <c>MakeSignature</c> function generates a cryptographic checksum of the message, and also includes sequencing information to
		/// prevent message loss or insertion. <c>MakeSignature</c> allows the application to choose between several cryptographic
		/// algorithms, if supported by the chosen mechanism. The <c>MakeSignature</c> function uses the security context referenced by the
		/// context handle.
		/// </para>
		/// <para>This function is not supported by the Schannel security support provider (SSP).</para>
		/// </summary>
		/// <param name="phContext">A handle to the security context to use to sign the message.</param>
		/// <param name="fQOP">
		/// <para>
		/// Package-specific flags that indicate the quality of protection. A security package can use this parameter to enable the selection
		/// of cryptographic algorithms.
		/// </para>
		/// <para>When using the Digest SSP, this parameter must be set to zero.</para>
		/// </param>
		/// <param name="pMessage">
		/// <para>
		/// A pointer to a SecBufferDesc structure. On input, the structure references one or more SecBuffer structures that contain the
		/// message to be signed. The function does not process buffers with the SECBUFFER_READONLY_WITH_CHECKSUM attribute.
		/// </para>
		/// <para>The SecBufferDesc structure also references a SecBuffer structure of type SECBUFFER_TOKEN that receives the signature.</para>
		/// <para>When the Digest SSP is used as an HTTP authentication protocol, the buffers should be configured as follows.</para>
		/// <list type="table">
		/// <listheader>
		/// <term>Buffer #/buffer type</term>
		/// <term>Meaning</term>
		/// </listheader>
		/// <item>
		/// <term>0 SECBUFFER_TOKEN</term>
		/// <term>Empty.</term>
		/// </item>
		/// <item>
		/// <term>1 SECBUFFER_PKG_PARAMS</term>
		/// <term>Method.</term>
		/// </item>
		/// <item>
		/// <term>2 SECBUFFER_PKG_PARAMS</term>
		/// <term>URL.</term>
		/// </item>
		/// <item>
		/// <term>3 SECBUFFER_PKG_PARAMS</term>
		/// <term>HEntity. For more information, see Input Buffers for the Digest Challenge Response.</term>
		/// </item>
		/// <item>
		/// <term>4 SECBUFFER_PADDING</term>
		/// <term>Empty. Receives the signature.</term>
		/// </item>
		/// </list>
		/// <para>When the Digest SSP is used as an SASL mechanism, the buffers should be configured as follows.</para>
		/// <list type="table">
		/// <listheader>
		/// <term>Buffer #/buffer type</term>
		/// <term>Meaning</term>
		/// </listheader>
		/// <item>
		/// <term>0 SECBUFFER_TOKEN</term>
		/// <term>
		/// Empty. Receives the signature. This buffer must be large enough to hold the largest possible signature. Determine the size
		/// required by calling the QueryContextAttributes (General) function and specifying SECPKG_ATTR_SIZES. Check the returned
		/// SecPkgContext_Sizes structure member cbMaxSignature.
		/// </term>
		/// </item>
		/// <item>
		/// <term>1 SECBUFFER_DATA</term>
		/// <term>Message to be signed.</term>
		/// </item>
		/// <item>
		/// <term>2 SECBUFFER_PADDING</term>
		/// <term>Empty.</term>
		/// </item>
		/// </list>
		/// </param>
		/// <param name="MessageSeqNo">
		/// <para>
		/// The sequence number that the transport application assigned to the message. If the transport application does not maintain
		/// sequence numbers, this parameter is zero.
		/// </para>
		/// <para>When using the Digest SSP, this parameter must be set to zero. The Digest SSP manages sequence numbering internally.</para>
		/// </param>
		/// <returns>
		/// <para>If the function succeeds, the function returns SEC_E_OK.</para>
		/// <para>If the function fails, it returns one of the following error codes.</para>
		/// <list type="table">
		/// <listheader>
		/// <term>Return code</term>
		/// <term>Description</term>
		/// </listheader>
		/// <item>
		/// <term>SEC_I_RENEGOTIATE</term>
		/// <term>
		/// The remote party requires a new handshake sequence or the application has just initiated a shutdown. Return to the negotiation
		/// loop and call AcceptSecurityContext (General) or InitializeSecurityContext (General) again. An empty input buffer is passed in
		/// the first call.
		/// </term>
		/// </item>
		/// <item>
		/// <term>SEC_E_INVALID_HANDLE</term>
		/// <term>The context handle specified by phContext is not valid.</term>
		/// </item>
		/// <item>
		/// <term>SEC_E_INVALID_TOKEN</term>
		/// <term>pMessage did not contain a valid SECBUFFER_TOKEN buffer or contained too few buffers.</term>
		/// </item>
		/// <item>
		/// <term>SEC_E_OUT_OF_SEQUENCE</term>
		/// <term>The nonce count is out of sequence.</term>
		/// </item>
		/// <item>
		/// <term>SEC_E_NO_AUTHENTICATING_AUTHORITY</term>
		/// <term>The security context (phContext) must be revalidated.</term>
		/// </item>
		/// <item>
		/// <term>STATUS_INVALID_PARAMETER</term>
		/// <term>The nonce count is not numeric.</term>
		/// </item>
		/// <item>
		/// <term>SEC_E_QOP_NOT_SUPPORTED</term>
		/// <term>The quality of protection negotiated between the client and server did not include integrity checking.</term>
		/// </item>
		/// </list>
		/// </returns>
		/// <remarks>
		/// <para>The <c>MakeSignature</c> function generates a signature that is based on the message and the session key for the context.</para>
		/// <para>The VerifySignature function verifies the messages signed by the <c>MakeSignature</c> function.</para>
		/// <para>
		/// If the transport application created the security context to support sequence detection and the caller provides a sequence
		/// number, the function includes this information in the signature. This protects against reply, insertion, and suppression of
		/// messages. The security package incorporates the sequence number passed down from the transport application.
		/// </para>
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows/desktop/api/sspi/nf-sspi-makesignature KSECDDDECLSPEC SECURITY_STATUS SEC_ENTRY
		// MakeSignature( PCtxtHandle phContext, unsigned long fQOP, PSecBufferDesc pMessage, unsigned long MessageSeqNo );
		[DllImport(Lib.Secur32, SetLastError = false, ExactSpelling = true)]
		[PInvokeData("sspi.h", MSDNShortId = "d17824b0-6121-48a3-b19b-d4fae3e1348e")]
		public static extern HRESULT MakeSignature(in CtxtHandle phContext, SECQOP fQOP, ref SecBufferDesc pMessage, uint MessageSeqNo);

		/// <summary>
		/// The <c>QueryContextAttributes (CredSSP)</c> function lets a transport application query the Credential Security Support Provider
		/// (CredSSP) security package for certain attributes of a security context.
		/// </summary>
		/// <param name="phContext">A handle to the security context to be queried.</param>
		/// <param name="ulAttribute">
		/// <para>
		/// The attribute of the context to be returned. This parameter can be one of the following values. Unless otherwise specified, the
		/// attributes are applicable to both client and server.
		/// </para>
		/// <list type="table">
		/// <listheader>
		/// <term>Value</term>
		/// <term>Meaning</term>
		/// </listheader>
		/// <item>
		/// <term>SECPKG_ATTR_C_ACCESS_TOKEN 0x80000012</term>
		/// <term>
		/// The pBuffer parameter contains a pointer to a SecPkgContext_AccessToken structure that specifies the access token for the current
		/// security context. This attribute is supported only on the server.
		/// </term>
		/// </item>
		/// <item>
		/// <term>SECPKG_ATTR_C_FULL_ACCESS_TOKEN 0x80000082</term>
		/// <term>
		/// The pBuffer parameter contains a pointer to a SecPkgContext_AccessToken structure that specifies the access token for the current
		/// security context. This attribute is supported only on the server.
		/// </term>
		/// </item>
		/// <item>
		/// <term>SECPKG_ATTR_CERT_TRUST_STATUS 0x80000084</term>
		/// <term>
		/// The pBuffer parameter contains a pointer to a CERT_TRUST_STATUS structure that specifies trust information about the certificate.
		/// This attribute is supported only on the client.
		/// </term>
		/// </item>
		/// <item>
		/// <term>SECPKG_ATTR_CREDS 0x80000080</term>
		/// <term>
		/// The pBuffer parameter contains a pointer to a SecPkgContext_ClientCreds structure that specifies client credentials. The client
		/// credentials can be either user name and password or user name and smart card PIN. This attribute is supported only on the server.
		/// </term>
		/// </item>
		/// <item>
		/// <term>SECPKG_ATTR_CREDS_2 0x80000086</term>
		/// <term>
		/// The pBuffer parameter contains a pointer to a SecPkgContext_ClientCreds structure that specifies client credentials. If the
		/// client credential is user name and password, the buffer is a packed KERB_INTERACTIVE_LOGON structure. If the client credential is
		/// user name and smart card PIN, the buffer is a packed KERB_CERTIFICATE_LOGON structure. If the client credential is an online
		/// identity credential, the buffer is a marshaled SEC_WINNT_AUTH_IDENTITY_EX2 structure. This attribute is supported only on the
		/// CredSSP server. Windows Server 2008 R2, Windows 7, Windows Server 2008, Windows Vista, Windows Server 2003 and Windows XP: This
		/// value is not supported.
		/// </term>
		/// </item>
		/// <item>
		/// <term>SECPKG_ATTR_NEGOTIATION_PACKAGE 0x80000081</term>
		/// <term>
		/// The pBuffer parameter contains a pointer to a SecPkgContext_PackageInfo structure that specifies the name of the authentication
		/// package negotiated by the Microsoft Negotiate provider.
		/// </term>
		/// </item>
		/// <item>
		/// <term>SECPKG_ATTR_PACKAGE_INFO 10</term>
		/// <term>The pBuffer parameter contains a pointer to a SecPkgContext_PackageInfostructure. Returns information on the SSP in use.</term>
		/// </item>
		/// <item>
		/// <term>SECPKG_ATTR_SERVER_AUTH_FLAGS 0x80000083</term>
		/// <term>
		/// The pBuffer parameter contains a pointer to a SecPkgContext_Flags structure that specifies information about the flags in the
		/// current security context. This attribute is supported only on the client.
		/// </term>
		/// </item>
		/// <item>
		/// <term>SECPKG_ATTR_SIZES 0x0</term>
		/// <term>
		/// The pBuffer parameter contains a pointer to a SecPkgContext_Sizes structure. Queries the sizes of the structures used in the
		/// per-message functions and authentication exchanges.
		/// </term>
		/// </item>
		/// <item>
		/// <term>SECPKG_ATTR_SUBJECT_SECURITY_ATTRIBUTES 124</term>
		/// <term>
		/// The pBuffer parameter contains a pointer to a SecPkgContext_SubjectAttributes structure. This value returns information about the
		/// security attributes for the connection. This value is supported only on the CredSSP server. Windows Server 2008, Windows Vista,
		/// Windows Server 2003 and Windows XP: This value is not supported.
		/// </term>
		/// </item>
		/// </list>
		/// </param>
		/// <param name="pBuffer">
		/// A pointer to a structure that receives the attributes. The structure type depends on the value of the ulAttribute parameter.
		/// </param>
		/// <returns>
		/// <para>If the function succeeds, it returns SEC_E_OK.</para>
		/// <para>If the function fails, it can return the following error codes.</para>
		/// <list type="table">
		/// <listheader>
		/// <term>Return code/value</term>
		/// <term>Description</term>
		/// </listheader>
		/// <item>
		/// <term>SEC_E_INVALID_HANDLE 0x80100003</term>
		/// <term>The function failed. The phContext parameter specifies a handle to an incomplete context.</term>
		/// </item>
		/// <item>
		/// <term>SEC_E_UNSUPPORTED_FUNCTION 0x80090302</term>
		/// <term>The function failed. The value of the ulAttribute parameter is not valid.</term>
		/// </item>
		/// </list>
		/// </returns>
		/// <remarks>
		/// <para>The structure pointed to by the pBuffer parameter varies depending on the attribute being queried.</para>
		/// <para>
		/// While the caller must allocate the pBuffer structure itself, the SSP allocates any memory required to hold variable-sized members
		/// of the pBuffer structure. Memory allocated by the SSP must be freed by calling the FreeContextBuffer function.
		/// </para>
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows/desktop/api/sspi/nf-sspi-querycontextattributesw KSECDDDECLSPEC SECURITY_STATUS SEC_ENTRY
		// QueryContextAttributesW( PCtxtHandle phContext, unsigned long ulAttribute, void *pBuffer );
		[DllImport(Lib.Secur32, SetLastError = false, CharSet = CharSet.Auto)]
		[PInvokeData("sspi.h", MSDNShortId = "4956c4ab-b71e-4960-b750-f3a79b87baac")]
		public static extern HRESULT QueryContextAttributes(in CtxtHandle phContext, SECPKG_ATTR ulAttribute, IntPtr pBuffer);

		/// <summary>
		/// The <c>QueryContextAttributes (CredSSP)</c> function lets a transport application query the Credential Security Support Provider
		/// (CredSSP) security package for certain attributes of a security context.
		/// </summary>
		/// <param name="phContext">A handle to the security context to be queried.</param>
		/// <param name="ulAttribute">
		/// <para>
		/// The attribute of the context to be returned. This parameter can be one of the following values. Unless otherwise specified, the
		/// attributes are applicable to both client and server.
		/// </para>
		/// <list type="table">
		/// <listheader>
		/// <term>Value</term>
		/// <term>Meaning</term>
		/// </listheader>
		/// <item>
		/// <term>SECPKG_ATTR_C_ACCESS_TOKEN 0x80000012</term>
		/// <term>
		/// The pBuffer parameter contains a pointer to a SecPkgContext_AccessToken structure that specifies the access token for the current
		/// security context. This attribute is supported only on the server.
		/// </term>
		/// </item>
		/// <item>
		/// <term>SECPKG_ATTR_C_FULL_ACCESS_TOKEN 0x80000082</term>
		/// <term>
		/// The pBuffer parameter contains a pointer to a SecPkgContext_AccessToken structure that specifies the access token for the current
		/// security context. This attribute is supported only on the server.
		/// </term>
		/// </item>
		/// <item>
		/// <term>SECPKG_ATTR_CERT_TRUST_STATUS 0x80000084</term>
		/// <term>
		/// The pBuffer parameter contains a pointer to a CERT_TRUST_STATUS structure that specifies trust information about the certificate.
		/// This attribute is supported only on the client.
		/// </term>
		/// </item>
		/// <item>
		/// <term>SECPKG_ATTR_CREDS 0x80000080</term>
		/// <term>
		/// The pBuffer parameter contains a pointer to a SecPkgContext_ClientCreds structure that specifies client credentials. The client
		/// credentials can be either user name and password or user name and smart card PIN. This attribute is supported only on the server.
		/// </term>
		/// </item>
		/// <item>
		/// <term>SECPKG_ATTR_CREDS_2 0x80000086</term>
		/// <term>
		/// The pBuffer parameter contains a pointer to a SecPkgContext_ClientCreds structure that specifies client credentials. If the
		/// client credential is user name and password, the buffer is a packed KERB_INTERACTIVE_LOGON structure. If the client credential is
		/// user name and smart card PIN, the buffer is a packed KERB_CERTIFICATE_LOGON structure. If the client credential is an online
		/// identity credential, the buffer is a marshaled SEC_WINNT_AUTH_IDENTITY_EX2 structure. This attribute is supported only on the
		/// CredSSP server. Windows Server 2008 R2, Windows 7, Windows Server 2008, Windows Vista, Windows Server 2003 and Windows XP: This
		/// value is not supported.
		/// </term>
		/// </item>
		/// <item>
		/// <term>SECPKG_ATTR_NEGOTIATION_PACKAGE 0x80000081</term>
		/// <term>
		/// The pBuffer parameter contains a pointer to a SecPkgContext_PackageInfo structure that specifies the name of the authentication
		/// package negotiated by the Microsoft Negotiate provider.
		/// </term>
		/// </item>
		/// <item>
		/// <term>SECPKG_ATTR_PACKAGE_INFO 10</term>
		/// <term>The pBuffer parameter contains a pointer to a SecPkgContext_PackageInfostructure. Returns information on the SSP in use.</term>
		/// </item>
		/// <item>
		/// <term>SECPKG_ATTR_SERVER_AUTH_FLAGS 0x80000083</term>
		/// <term>
		/// The pBuffer parameter contains a pointer to a SecPkgContext_Flags structure that specifies information about the flags in the
		/// current security context. This attribute is supported only on the client.
		/// </term>
		/// </item>
		/// <item>
		/// <term>SECPKG_ATTR_SIZES 0x0</term>
		/// <term>
		/// The pBuffer parameter contains a pointer to a SecPkgContext_Sizes structure. Queries the sizes of the structures used in the
		/// per-message functions and authentication exchanges.
		/// </term>
		/// </item>
		/// <item>
		/// <term>SECPKG_ATTR_SUBJECT_SECURITY_ATTRIBUTES 124</term>
		/// <term>
		/// The pBuffer parameter contains a pointer to a SecPkgContext_SubjectAttributes structure. This value returns information about the
		/// security attributes for the connection. This value is supported only on the CredSSP server. Windows Server 2008, Windows Vista,
		/// Windows Server 2003 and Windows XP: This value is not supported.
		/// </term>
		/// </item>
		/// </list>
		/// </param>
		/// <returns>A structure that receives the attributes. The structure type depends on the value of the ulAttribute parameter.</returns>
		/// <remarks>
		/// <para>The structure pointed to by the pBuffer parameter varies depending on the attribute being queried.</para>
		/// <para>
		/// While the caller must allocate the pBuffer structure itself, the SSP allocates any memory required to hold variable-sized members
		/// of the pBuffer structure. Memory allocated by the SSP must be freed by calling the FreeContextBuffer function.
		/// </para>
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows/desktop/api/sspi/nf-sspi-querycontextattributesw KSECDDDECLSPEC SECURITY_STATUS SEC_ENTRY
		// QueryContextAttributesW( PCtxtHandle phContext, unsigned long ulAttribute, void *pBuffer );
		[PInvokeData("sspi.h", MSDNShortId = "4956c4ab-b71e-4960-b750-f3a79b87baac")]
		public static T QueryContextAttributes<T>(in CtxtHandle phContext, SECPKG_ATTR ulAttribute) where T : struct
		{
			if (!CorrespondingTypeAttribute.CanGet(ulAttribute, typeof(T))) throw new ArgumentException($"{typeof(T).GetType().Name} cannot be retrieved using {ulAttribute}.");
			using (var mem = SafeHGlobalHandle.CreateFromStructure<T>())
			{
				if (Environment.OSVersion.Version > new Version(6, 0))
					QueryContextAttributesEx(phContext, ulAttribute, (IntPtr)mem, (uint)mem.Size).ThrowIfFailed();
				else
					QueryContextAttributes(phContext, ulAttribute, (IntPtr)mem).ThrowIfFailed();
				return mem.ToStructure<T>();
			}
		}

		/// <summary>Enables a transport application to query a security package for certain attributes of a security context.</summary>
		/// <param name="phContext">A handle to the security context to be queried.</param>
		/// <param name="ulAttribute">
		/// <para>Specifies the attribute of the context to be returned. This parameter can be one of the following values.</para>
		/// <list type="table">
		/// <listheader>
		/// <term>Value</term>
		/// <term>Meaning</term>
		/// </listheader>
		/// <item>
		/// <term>SECPKG_ATTR_ACCESS_TOKEN 18</term>
		/// <term>The pBuffer parameter contains a pointer to a SecPkgContext_AccessToken structure. Returns a handle to the access token.</term>
		/// </item>
		/// <item>
		/// <term>SECPKG_ATTR_APP_DATA 0x5e</term>
		/// <term>
		/// The pBuffer parameter contains a pointer to a SecPkgContext_SessionAppData structure. Returns or specifies application data for
		/// the session. This attribute is supported only by the Schannel security package.
		/// </term>
		/// </item>
		/// <item>
		/// <term>SECPKG_ATTR_AUTHORITY 6</term>
		/// <term>
		/// The pBuffer parameter contains a pointer to a SecPkgContext_Authority structure. Queries the name of the authenticating authority.
		/// </term>
		/// </item>
		/// <item>
		/// <term>SECPKG_ATTR_CLIENT_SPECIFIED_TARGET 27</term>
		/// <term>
		/// The pBuffer parameter contains a pointer to a SecPkgContext_ClientSpecifiedTarget structure that represents the service principal
		/// name (SPN) of the initial target supplied by the client. Windows Server 2008, Windows Vista, Windows Server 2003 and Windows XP:
		/// This value is not supported.
		/// </term>
		/// </item>
		/// <item>
		/// <term>SECPKG_ATTR_CONNECTION_INFO 0x5a</term>
		/// <term>
		/// The pBuffer parameter contains a pointer to a SecPkgContext_ConnectionInfo structure. Returns detailed information on the
		/// established connection. This attribute is supported only by the Schannel security package.
		/// </term>
		/// </item>
		/// <item>
		/// <term>SECPKG_ATTR_CREDS_2 0x80000086</term>
		/// <term>
		/// The pBuffer parameter contains a pointer to a SecPkgContext_ClientCreds structure that specifies client credentials. If the
		/// client credential is user name and password, the buffer is a packed KERB_INTERACTIVE_LOGON structure. If the client credential is
		/// user name and smart card PIN, the buffer is a packed KERB_CERTIFICATE_LOGON structure. If the client credential is an online
		/// identity credential, the buffer is a marshaled SEC_WINNT_AUTH_IDENTITY_EX2 structure. This attribute is supported only on the
		/// CredSSP server. Windows Server 2008 R2, Windows 7, Windows Server 2008, Windows Vista, Windows Server 2003 and Windows XP: This
		/// value is not supported.
		/// </term>
		/// </item>
		/// <item>
		/// <term>SECPKG_ATTR_DCE_INFO 3</term>
		/// <term>
		/// The pBuffer parameter contains a pointer to a SecPkgContext_DceInfo structure. Queries for authorization data used by DCE services.
		/// </term>
		/// </item>
		/// <item>
		/// <term>SECPKG_ATTR_ENDPOINT_BINDINGS 26</term>
		/// <term>
		/// The pBuffer parameter contains a pointer to a SecPkgContext_Bindings structure that specifies channel binding information. This
		/// attribute is supported only by the Schannel security package. Windows Server 2008, Windows Vista, Windows Server 2003 and Windows
		/// XP: This value is not supported.
		/// </term>
		/// </item>
		/// <item>
		/// <term>SECPKG_ATTR_EAP_KEY_BLOCK 0x5b</term>
		/// <term>
		/// The pBuffer parameter contains a pointer to a SecPkgContext_EapKeyBlock structure. Queries for key data used by the EAP TLS
		/// protocol. This attribute is supported only by the Schannel security package.
		/// </term>
		/// </item>
		/// <item>
		/// <term>SECPKG_ATTR_FLAGS 14</term>
		/// <term>
		/// The pBuffer parameter contains a pointer to a SecPkgContext_Flags structure. Returns information about the negotiated context flags.
		/// </term>
		/// </item>
		/// <item>
		/// <term>SECPKG_ATTR_ISSUER_LIST_EX 0x59</term>
		/// <term>
		/// The pBuffer parameter contains a pointer to a SecPkgContext_IssuerListInfoEx structure. Returns a list of certificate issuers
		/// that are accepted by the server. This attribute is supported only by the Schannel security package.
		/// </term>
		/// </item>
		/// <item>
		/// <term>SECPKG_ATTR_KEY_INFO 5</term>
		/// <term>
		/// The pBuffer parameter contains a pointer to a SecPkgContext_KeyInfo structure. Queries information about the keys used in a
		/// security context.
		/// </term>
		/// </item>
		/// <item>
		/// <term>SECPKG_ATTR_LAST_CLIENT_TOKEN_STATUS 30</term>
		/// <term>
		/// The pBuffer parameter contains a pointer to a SecPkgContext_LastClientTokenStatus structure that specifies whether the token from
		/// the most recent call to the InitializeSecurityContext function is the last token from the client. This value is supported only by
		/// the Negotiate, Kerberos, and NTLM security packages. Windows Server 2008, Windows Vista, Windows Server 2003 and Windows XP: This
		/// value is not supported.
		/// </term>
		/// </item>
		/// <item>
		/// <term>SECPKG_ATTR_LIFESPAN 2</term>
		/// <term>The pBuffer parameter contains a pointer to a SecPkgContext_Lifespan structure. Queries the life span of the context.</term>
		/// </item>
		/// <item>
		/// <term>SECPKG_ATTR_LOCAL_CERT_CONTEXT 0x54</term>
		/// <term>
		/// The pBuffer parameter contains a pointer to a PCCERT_CONTEXTstructure. Finds a certificate context that contains a local end
		/// certificate. This attribute is supported only by the Schannel security package.
		/// </term>
		/// </item>
		/// <item>
		/// <term>SECPKG_ATTR_LOCAL_CRED</term>
		/// <term>The pBuffer parameter contains a pointer to a SecPkgContext_LocalCredentialInfo structure. (obsolete) Superseded by SECPKG_ATTR_LOCAL_CERT_CONTEXT.</term>
		/// </item>
		/// <item>
		/// <term>SECPKG_ATTR_NAMES 1</term>
		/// <term>The pBuffer parameter contains a pointer to a SecPkgContext_Names structure. Queries the name associated with the context.</term>
		/// </item>
		/// <item>
		/// <term>SECPKG_ATTR_NATIVE_NAMES 13</term>
		/// <term>
		/// The pBuffer parameter contains a pointer to a SecPkgContext_NativeNames structure. Returns the principal name (CNAME) from the
		/// outbound ticket.
		/// </term>
		/// </item>
		/// <item>
		/// <term>SECPKG_ATTR_NEGOTIATION_INFO 12</term>
		/// <term>
		/// The pBuffer parameter contains a pointer to a SecPkgContext_NegotiationInfo structure. Returns information about the security
		/// package to be used with the negotiation process and the current state of the negotiation for the use of that package.
		/// </term>
		/// </item>
		/// <item>
		/// <term>SECPKG_ATTR_PACKAGE_INFO 10</term>
		/// <term>The pBuffer parameter contains a pointer to a SecPkgContext_PackageInfostructure. Returns information on the SSP in use.</term>
		/// </item>
		/// <item>
		/// <term>SECPKG_ATTR_PASSWORD_EXPIRY 8</term>
		/// <term>The pBuffer parameter contains a pointer to a SecPkgContext_PasswordExpiry structure. Returns password expiration information.</term>
		/// </item>
		/// <item>
		/// <term>SECPKG_ATTR_REMOTE_CERT_CONTEXT 0x53</term>
		/// <term>
		/// The pBuffer parameter contains a pointer to a PCCERT_CONTEXTstructure. Finds a certificate context that contains the end
		/// certificate supplied by the server. This attribute is supported only by the Schannel security package.
		/// </term>
		/// </item>
		/// <item>
		/// <term>SECPKG_ATTR_ROOT_STORE 0x55</term>
		/// <term>
		/// The pBuffer parameter contains a pointer to a HCERTCONTEXT. Finds a certificate context that contains a certificate supplied by
		/// the Root store.
		/// </term>
		/// </item>
		/// <item>
		/// <term>SECPKG_ATTR_SESSION_KEY 9</term>
		/// <term>
		/// The pBuffer parameter contains a pointer to a SecPkgContext_SessionKey structure. Returns information about the session keys.
		/// </term>
		/// </item>
		/// <item>
		/// <term>SECPKG_ATTR_SESSION_INFO 0x5d</term>
		/// <term>
		/// The pBuffer parameter contains a pointer to a SecPkgContext_SessionInfo structure. Returns information about the session. Windows
		/// Server 2008, Windows Vista, Windows Server 2003 and Windows XP: This value is not supported. This attribute is supported only by
		/// the Schannel security package.
		/// </term>
		/// </item>
		/// <item>
		/// <term>SECPKG_ATTR_SIZES 0</term>
		/// <term>
		/// The pBuffer parameter contains a pointer to a SecPkgContext_Sizes structure. Queries the sizes of the structures used in the
		/// per-message functions.
		/// </term>
		/// </item>
		/// <item>
		/// <term>SECPKG_ATTR_STREAM_SIZES 4</term>
		/// <term>
		/// The pBuffer parameter contains a pointer to a SecPkgContext_StreamSizes structure. Queries the sizes of the various parts of a
		/// stream used in the per-message functions. This attribute is supported only by the Schannel security package.
		/// </term>
		/// </item>
		/// <item>
		/// <term>SECPKG_ATTR_SUBJECT_SECURITY_ATTRIBUTES 124</term>
		/// <term>
		/// The pBuffer parameter contains a pointer to a SecPkgContext_SubjectAttributes structure. This value returns information about the
		/// security attributes for the connection. This value is supported only on the CredSSP server. Windows Server 2008, Windows Vista,
		/// Windows Server 2003 and Windows XP: This value is not supported.
		/// </term>
		/// </item>
		/// <item>
		/// <term>SECPKG_ATTR_SUPPORTED_SIGNATURES 0x66</term>
		/// <term>
		/// The pBuffer parameter contains a pointer to a SecPkgContext_SupportedSignatures structure. This value returns information about
		/// the signature types that are supported for the connection. This value is supported only by the Schannel security package. Windows
		/// Server 2008, Windows Vista, Windows Server 2003 and Windows XP: This value is not supported.
		/// </term>
		/// </item>
		/// <item>
		/// <term>SECPKG_ATTR_TARGET_INFORMATION 17</term>
		/// <term>
		/// The pBuffer parameter contains a pointer to a SecPkgContext_TargetInformation structure. Returns information about the name of
		/// the remote server.
		/// </term>
		/// </item>
		/// <item>
		/// <term>SECPKG_ATTR_UNIQUE_BINDINGS 25</term>
		/// <term>
		/// The pBuffer parameter contains a pointer to a SecPkgContext_Bindings structure that specifies channel binding information. This
		/// value is supported only by the Schannel security package. Windows Server 2008, Windows Vista, Windows Server 2003 and Windows XP:
		/// This value is not supported.
		/// </term>
		/// </item>
		/// </list>
		/// </param>
		/// <param name="pBuffer">
		/// A pointer to a structure that receives the attributes. The type of structure pointed to depends on the value specified in the
		/// ulAttribute parameter.
		/// </param>
		/// <param name="cbBuffer">The size, in bytes, of the pBuffer parameter.</param>
		/// <returns>
		/// <para>If the function succeeds, the return value is SEC_E_OK.</para>
		/// <para>If the function fails, the return value is a nonzero error code.</para>
		/// </returns>
		// https://docs.microsoft.com/en-us/windows/desktop/api/sspi/nf-sspi-querycontextattributesexw SECURITY_STATUS SEC_ENTRY
		// QueryContextAttributesExW( PCtxtHandle phContext, unsigned long ulAttribute, void *pBuffer, unsigned long cbBuffer );
		[DllImport(Lib.SspiCli, SetLastError = false, CharSet = CharSet.Auto)]
		[PInvokeData("sspi.h", MSDNShortId = "FD91EE99-F94E-44CE-9331-933D0CAA5F75", MinClient = PInvokeClient.Windows7)]
		public static extern HRESULT QueryContextAttributesEx(in CtxtHandle phContext, SECPKG_ATTR ulAttribute, IntPtr pBuffer, uint cbBuffer);

		/// <summary>
		/// Retrieves the attributes of a credential, such as the name associated with the credential. The information is valid for any
		/// security context created with the specified credential.
		/// </summary>
		/// <param name="phCredential">A handle of the credentials to be queried.</param>
		/// <param name="ulAttribute">
		/// <para>Specifies the attribute to query. This parameter can be any of the following attributes.</para>
		/// <list type="table">
		/// <listheader>
		/// <term>Value</term>
		/// <term>Meaning</term>
		/// </listheader>
		/// <item>
		/// <term>SECPKG_CRED_ATTR_CERT</term>
		/// <term>
		/// Returns the certificate thumbprint in a pbuffer of type SecPkgCredentials_Cert. This attribute is only supported by Kerberos.
		/// Windows Server 2008 R2, Windows 7, Windows Server 2008, Windows Vista, Windows Server 2003 and Windows XP: This attribute is not available.
		/// </term>
		/// </item>
		/// <item>
		/// <term>SECPKG_CRED_ATTR_NAMES</term>
		/// <term>
		/// Returns the name of a credential in a pbuffer of type SecPkgCredentials_Names. This attribute is not supported by Schannel in
		/// WOW64 mode.
		/// </term>
		/// </item>
		/// <item>
		/// <term>SECPKG_ATTR_SUPPORTED_ALGS</term>
		/// <term>
		/// Returns the supported algorithms in a pbuffer of type SecPkgCred_SupportedAlgs. All supported algorithms are included, regardless
		/// of whether they are supported by the provided certificate or enabled on the local computer. This attribute is supported only by Schannel.
		/// </term>
		/// </item>
		/// <item>
		/// <term>SECPKG_ATTR_CIPHER_STRENGTHS</term>
		/// <term>Returns the cipher strengths in a pbuffer of type SecPkgCred_CipherStrengths. This attribute is supported only by Schannel.</term>
		/// </item>
		/// <item>
		/// <term>SECPKG_ATTR_SUPPORTED_PROTOCOLS</term>
		/// <term>
		/// Returns the supported algorithms in a pbuffer of type SecPkgCred_SupportedProtocols. All supported protocols are included,
		/// regardless of whether they are supported by the provided certificate or enabled on the local computer. This attribute is
		/// supported only by Schannel.
		/// </term>
		/// </item>
		/// </list>
		/// </param>
		/// <param name="pBuffer">
		/// A pointer to a buffer that receives the requested attribute. The type of structure returned depends on the value of ulAttribute.
		/// </param>
		/// <returns>
		/// <para>If the function succeeds, the return value is SEC_E_OK.</para>
		/// <para>If the function fails, the return value may be one of the following error codes.</para>
		/// <list type="table">
		/// <listheader>
		/// <term>Return code</term>
		/// <term>Description</term>
		/// </listheader>
		/// <item>
		/// <term>SEC_E_INVALID_HANDLE</term>
		/// <term>The handle passed to the function is not valid.</term>
		/// </item>
		/// <item>
		/// <term>SEC_E_UNSUPPORTED_FUNCTION</term>
		/// <term>
		/// The specified attribute is not supported by Schannel. This return value will only be returned when the Schannel SSP is being used.
		/// </term>
		/// </item>
		/// <item>
		/// <term>SEC_E_INSUFFICIENT_MEMORY</term>
		/// <term>The memory that is available is not sufficient to complete the request.</term>
		/// </item>
		/// </list>
		/// </returns>
		/// <remarks>
		/// <para>
		/// The <c>QueryCredentialsAttributes</c> function allows an application to determine several characteristics of a credential,
		/// including the name associated with the specified credentials.
		/// </para>
		/// <para>
		/// Querying the SECPKG_ATTR_CIPHER_STRENGTHS attribute returns a SecPkgCred_CipherStrengths structure. The cipher strength in this
		/// structure is the same as the cipher strength in the SCHANNEL_CRED structure used when a credential was created.
		/// </para>
		/// <para>
		/// <c>Note</c> An application can find the system default cipher strength by querying this attribute with a default credential. A
		/// default credential is created by calling AcquireCredentialsHandle with a <c>NULL</c> pAuthData parameter.
		/// </para>
		/// <para>
		/// Querying the SECPKG_ATTR_SUPPORTED_ALGS attribute returns a SecPkgCred_SupportedAlgs structure. The algorithms in this structure
		/// are compatible with those indicated in the SCHANNEL_CRED structure used when a credential was created.
		/// </para>
		/// <para>
		/// Querying the SECPKG_ATTR_SUPPORTED_PROTOCOLS attribute returns a SecPkgCred_SupportedProtocols structure that contains a bit
		/// array compatible with the grbitEnabledProtocols field of the SCHANNEL_CRED structure.
		/// </para>
		/// <para>
		/// The caller must allocate the structure pointed to by the pBuffer parameter. The security package allocates the buffer for any
		/// pointer returned in the pBuffer structure. The caller can call the FreeContextBuffer function to free any pointers allocated by
		/// the security package.
		/// </para>
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows/desktop/api/sspi/nf-sspi-querycredentialsattributesa SECURITY_STATUS SEC_ENTRY
		// QueryCredentialsAttributesA( PCredHandle phCredential, unsigned long ulAttribute, void *pBuffer );
		[DllImport(Lib.Secur32, SetLastError = false, CharSet = CharSet.Auto)]
		[PInvokeData("sspi.h", MSDNShortId = "a8ba6f73-8469-431b-b185-183b45b2c533")]
		public static extern HRESULT QueryCredentialsAttributes(in CredHandle phCredential, SECPKG_CRED_ATTR ulAttribute, IntPtr pBuffer);

		/// <summary>
		/// Retrieves the attributes of a credential, such as the name associated with the credential. The information is valid for any
		/// security context created with the specified credential.
		/// </summary>
		/// <param name="phCredential">A handle of the credentials to be queried.</param>
		/// <param name="ulAttribute">
		/// <para>Specifies the attribute to query. This parameter can be any of the following attributes.</para>
		/// <list type="table">
		/// <listheader>
		/// <term>Value</term>
		/// <term>Meaning</term>
		/// </listheader>
		/// <item>
		/// <term>SECPKG_CRED_ATTR_CERT</term>
		/// <term>
		/// Returns the certificate thumbprint in a pbuffer of type SecPkgCredentials_Cert. This attribute is only supported by Kerberos.
		/// Windows Server 2008 R2, Windows 7, Windows Server 2008, Windows Vista, Windows Server 2003 and Windows XP: This attribute is not available.
		/// </term>
		/// </item>
		/// <item>
		/// <term>SECPKG_CRED_ATTR_NAMES</term>
		/// <term>
		/// Returns the name of a credential in a pbuffer of type SecPkgCredentials_Names. This attribute is not supported by Schannel in
		/// WOW64 mode.
		/// </term>
		/// </item>
		/// <item>
		/// <term>SECPKG_ATTR_SUPPORTED_ALGS</term>
		/// <term>
		/// Returns the supported algorithms in a pbuffer of type SecPkgCred_SupportedAlgs. All supported algorithms are included, regardless
		/// of whether they are supported by the provided certificate or enabled on the local computer. This attribute is supported only by Schannel.
		/// </term>
		/// </item>
		/// <item>
		/// <term>SECPKG_ATTR_CIPHER_STRENGTHS</term>
		/// <term>Returns the cipher strengths in a pbuffer of type SecPkgCred_CipherStrengths. This attribute is supported only by Schannel.</term>
		/// </item>
		/// <item>
		/// <term>SECPKG_ATTR_SUPPORTED_PROTOCOLS</term>
		/// <term>
		/// Returns the supported algorithms in a pbuffer of type SecPkgCred_SupportedProtocols. All supported protocols are included,
		/// regardless of whether they are supported by the provided certificate or enabled on the local computer. This attribute is
		/// supported only by Schannel.
		/// </term>
		/// </item>
		/// </list>
		/// </param>
		/// <param name="pBuffer">
		/// A pointer to a buffer that receives the requested attribute. The type of structure returned depends on the value of ulAttribute.
		/// </param>
		/// <param name="cbBuffer">The size, in bytes, of the pBuffer parameter.</param>
		/// <returns>
		/// <para>If the function succeeds, the return value is SEC_E_OK.</para>
		/// <para>If the function fails, the return value may be one of the following error codes.</para>
		/// <list type="table">
		/// <listheader>
		/// <term>Return code</term>
		/// <term>Description</term>
		/// </listheader>
		/// <item>
		/// <term>SEC_E_INVALID_HANDLE</term>
		/// <term>The handle passed to the function is not valid.</term>
		/// </item>
		/// <item>
		/// <term>SEC_E_UNSUPPORTED_FUNCTION</term>
		/// <term>
		/// The specified attribute is not supported by Schannel. This return value will only be returned when the Schannel SSP is being used.
		/// </term>
		/// </item>
		/// <item>
		/// <term>SEC_E_INSUFFICIENT_MEMORY</term>
		/// <term>The memory that is available is not sufficient to complete the request.</term>
		/// </item>
		/// </list>
		/// </returns>
		/// <remarks>
		/// <para>
		/// The <c>QueryCredentialsAttributes</c> function allows an application to determine several characteristics of a credential,
		/// including the name associated with the specified credentials.
		/// </para>
		/// <para>
		/// Querying the SECPKG_ATTR_CIPHER_STRENGTHS attribute returns a SecPkgCred_CipherStrengths structure. The cipher strength in this
		/// structure is the same as the cipher strength in the SCHANNEL_CRED structure used when a credential was created.
		/// </para>
		/// <para>
		/// <c>Note</c> An application can find the system default cipher strength by querying this attribute with a default credential. A
		/// default credential is created by calling AcquireCredentialsHandle with a <c>NULL</c> pAuthData parameter.
		/// </para>
		/// <para>
		/// Querying the SECPKG_ATTR_SUPPORTED_ALGS attribute returns a SecPkgCred_SupportedAlgs structure. The algorithms in this structure
		/// are compatible with those indicated in the SCHANNEL_CRED structure used when a credential was created.
		/// </para>
		/// <para>
		/// Querying the SECPKG_ATTR_SUPPORTED_PROTOCOLS attribute returns a SecPkgCred_SupportedProtocols structure that contains a bit
		/// array compatible with the grbitEnabledProtocols field of the SCHANNEL_CRED structure.
		/// </para>
		/// <para>
		/// The caller must allocate the structure pointed to by the pBuffer parameter. The security package allocates the buffer for any
		/// pointer returned in the pBuffer structure. The caller can call the FreeContextBuffer function to free any pointers allocated by
		/// the security package.
		/// </para>
		/// </remarks>
		[DllImport(Lib.SspiCli, SetLastError = false, CharSet = CharSet.Auto)]
		[PInvokeData("sspi.h", MinClient = PInvokeClient.Windows7)]
		public static extern HRESULT QueryCredentialsAttributesEx(in CredHandle phCredential, SECPKG_CRED_ATTR ulAttribute, IntPtr pBuffer, uint cbBuffer);

		/// <summary>Obtains the access token for a client security context and uses it directly.</summary>
		/// <param name="phContext">Handle of the context to query.</param>
		/// <param name="Token">Returned handle to the access token.</param>
		/// <returns>
		/// <para>If the function succeeds, the function returns SEC_E_OK.</para>
		/// <para>If the function fails, it returns a nonzero error code. One possible error code return is SEC_E_INVALID_HANDLE.</para>
		/// </returns>
		/// <remarks>
		/// This function is called by a server application to control impersonation outside the SSPI layer, such as when launching a child
		/// process. The handle returned must be closed with CloseHandle when the handle is no longer needed.
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows/desktop/api/sspi/nf-sspi-querysecuritycontexttoken KSECDDDECLSPEC SECURITY_STATUS
		// SEC_ENTRY QuerySecurityContextToken( PCtxtHandle phContext, void **Token );
		[DllImport(Lib.Secur32, SetLastError = false, ExactSpelling = true)]
		[PInvokeData("sspi.h", MSDNShortId = "5dc23608-9ce3-4fee-8161-2e409cef4063")]
		public static extern HRESULT QuerySecurityContextToken(in CtxtHandle phContext, out SafeHTOKEN Token);

		/// <summary>
		/// Retrieves information about a specified security package. This information includes the bounds on sizes of authentication
		/// information, credentials, and contexts.
		/// </summary>
		/// <param name="pszPackageName">Pointer to a null-terminated string that specifies the name of the security package.</param>
		/// <param name="ppPackageInfo">
		/// Pointer to a variable that receives a pointer to a SecPkgInfo structure containing information about the specified security package.
		/// </param>
		/// <returns>
		/// <para>If the function succeeds, the return value is SEC_E_OK.</para>
		/// <para>If the function fails, the return value is a nonzero error code.</para>
		/// </returns>
		/// <remarks>The caller must call the FreeContextBuffer function to free the buffer returned in ppPackageInfo.</remarks>
		// https://docs.microsoft.com/en-us/windows/desktop/api/sspi/nf-sspi-querysecuritypackageinfoa SECURITY_STATUS SEC_ENTRY
		// QuerySecurityPackageInfoA( LPSTR pszPackageName, PSecPkgInfoA *ppPackageInfo );
		[DllImport(Lib.Secur32, SetLastError = false, CharSet = CharSet.Auto)]
		[PInvokeData("sspi.h", MSDNShortId = "130ef0fe-bb13-4a65-b476-cd25ed234da1")]
		public static extern HRESULT QuerySecurityPackageInfo(string pszPackageName, out SafeContextBuffer ppPackageInfo);

		/// <summary>Allows a security package to discontinue the impersonation of the caller and restore its own security context.</summary>
		/// <param name="phContext">
		/// Handle of the security context being impersonated. This handle must have been obtained in the call to the AcceptSecurityContext
		/// (General) function and used in the call to the ImpersonateSecurityContext function.
		/// </param>
		/// <returns>
		/// <para>If the function succeeds, the return value is SEC_E_OK.</para>
		/// <para>If the function fails, the return value can be one of the following error codes.</para>
		/// <list type="table">
		/// <listheader>
		/// <term>Return code</term>
		/// <term>Description</term>
		/// </listheader>
		/// <item>
		/// <term>SEC_E_INVALID_HANDLE</term>
		/// <term>The handle passed to the function is not valid.</term>
		/// </item>
		/// </list>
		/// </returns>
		/// <remarks>
		/// <c>RevertSecurityContext</c> is not available with all security packages on all platforms. Typically, it is implemented only on
		/// platforms and with security packages for which a call to the QuerySecurityPackageInfo function indicates impersonation support.
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows/desktop/api/sspi/nf-sspi-revertsecuritycontext KSECDDDECLSPEC SECURITY_STATUS SEC_ENTRY
		// RevertSecurityContext( PCtxtHandle phContext );
		[DllImport(Lib.Secur32, SetLastError = false, ExactSpelling = true)]
		[PInvokeData("sspi.h", MSDNShortId = "d4ed1fe9-2e0a-4648-a010-1eae49ba03ee")]
		public static extern HRESULT RevertSecurityContext(in CtxtHandle phContext);

		/// <summary>
		/// The <c>SaslAcceptSecurityContext</c> function wraps a standard call to the Security Support Provider Interface
		/// AcceptSecurityContext (General) function and includes creation of SASL server cookies.
		/// </summary>
		/// <param name="phCredential">
		/// A handle to the server's credentials. The server calls the AcquireCredentialsHandle function with the INBOUND flag set to
		/// retrieve this handle.
		/// </param>
		/// <param name="phContext">
		/// Pointer to a CtxtHandle structure. On the first call to AcceptSecurityContext (General), this pointer is <c>NULL</c>. On
		/// subsequent calls, phContext is the handle to the partially formed context that was returned in the phNewContext parameter by the
		/// first call.
		/// </param>
		/// <param name="pInput">
		/// <para>
		/// Pointer to a SecBufferDesc structure generated by a client call to the InitializeSecurityContext (General) function that contains
		/// the input buffer descriptor.
		/// </para>
		/// <para>
		/// SASL requires a single buffer of type <c>SECBUFFER_TOKEN</c>. The buffer is empty for the first call to the AcceptSecurityContext
		/// (General) function and contains the challenge response received from the client for the second call.
		/// </para>
		/// </param>
		/// <param name="fContextReq">
		/// <para>
		/// Bit flags that specify the attributes required by the server to establish the context. Bit flags can be combined using bitwise-
		/// <c>OR</c> operations. The following table shows the possible values.
		/// </para>
		/// <list type="table">
		/// <listheader>
		/// <term>Value</term>
		/// <term>Meaning</term>
		/// </listheader>
		/// <item>
		/// <term>ASC_REQ_CONFIDENTIALITY</term>
		/// <term>Encrypt and decrypt messages. Valid with the Digest SSP for SASL only.</term>
		/// </item>
		/// <item>
		/// <term>ASC_REQ_HTTP</term>
		/// <term>Use Digest for HTTP. Omit this flag to use Digest as an SASL mechanism.</term>
		/// </item>
		/// </list>
		/// </param>
		/// <param name="TargetDataRep">
		/// Indicates the data representation, such as byte ordering, on the target. This value can be either SECURITY_NATIVE_DREP or SECURITY_NETWORK_DREP.
		/// </param>
		/// <param name="phNewContext">
		/// Pointer to a CtxtHandle structure. On the first call to AcceptSecurityContext (General), this pointer receives the new context
		/// handle. On subsequent calls, phNewContext can be the same as the handle specified in the phContext parameter.
		/// </param>
		/// <param name="pOutput">
		/// Pointer to a SecBufferDesc structure that contains the output buffer descriptor. This buffer is sent to the client for input into
		/// additional calls to InitializeSecurityContext (General). An output buffer may be generated even if the function returns SEC_E_OK.
		/// Any buffer generated must be sent back to the client application.
		/// </param>
		/// <param name="pfContextAttr">
		/// <para>
		/// Pointer to a variable that receives a set of bit flags indicating the attributes of the established context. For a description of
		/// the various attributes, see Context Requirements. Flags used for this parameter are prefixed with ASC_RET, such as ASC_RET_DELEGATE.
		/// </para>
		/// <para>
		/// Do not check for security-related attributes until the final function call returns successfully. Attribute flags not related to
		/// security, such as the ASC_RET_ALLOCATED_MEMORY flag, can be checked before the final return.
		/// </para>
		/// </param>
		/// <param name="ptsExpiry">
		/// <para>
		/// Pointer to a <c>TimeStamp</c> structure that receives the expiration time of the context. It is recommended that the security
		/// package always return this value in local time.
		/// </para>
		/// <para>
		/// <c>Note</c> Until the last call of the authentication process, the expiration time for the context can be incorrect because more
		/// information will be provided during later stages of the negotiation. Therefore, ptsTimeStamp must be <c>NULL</c> until the last
		/// call to the function.
		/// </para>
		/// </param>
		/// <returns>
		/// <para>
		/// If the call is completed successfully, this function returns SEC_E_OK. The following table shows some possible failure return values.
		/// </para>
		/// <list type="table">
		/// <listheader>
		/// <term>Return code</term>
		/// <term>Description</term>
		/// </listheader>
		/// <item>
		/// <term>SEC_E_ALGORITHM_MISMATCH</term>
		/// <term>Authz processing is not permitted.</term>
		/// </item>
		/// <item>
		/// <term>SEC_E_INSUFFICIENT_MEMORY</term>
		/// <term>Not enough memory is available to complete the request.</term>
		/// </item>
		/// <item>
		/// <term>SEC_E_INVALID_TOKEN</term>
		/// <term>No Token buffer is located in the pOutput parameter, or the message failed to decrypt.</term>
		/// </item>
		/// </list>
		/// </returns>
		/// <remarks>
		/// The final call of the AcceptSecurityContext (General) function that returns SEC_E_OK is identified. If a return token is
		/// produced, SASL processing is suspended for one round trip back to the client to allow the final token to be processed. After the
		/// exchange is completed, SEC_E_CONTINUE_NEEDED is returned to the application with an additional SASL server cookie encrypted with
		/// SSPI message functions. The initial server cookie indicates if INTEGRITY and PRIVACY are supported. This initial server cookie is
		/// processed by the client, and the client returns a client cookie to indicate which services the client requests. The client cookie
		/// is then decrypted by the server and the final services are determined for the following message traffic.
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows/desktop/api/sspi/nf-sspi-saslacceptsecuritycontext SECURITY_STATUS SEC_ENTRY
		// SaslAcceptSecurityContext( PCredHandle phCredential, PCtxtHandle phContext, PSecBufferDesc pInput, unsigned long fContextReq,
		// unsigned long TargetDataRep, PCtxtHandle phNewContext, PSecBufferDesc pOutput, unsigned long *pfContextAttr, PTimeStamp ptsExpiry );
		[DllImport(Lib.Secur32, SetLastError = false, ExactSpelling = true)]
		[PInvokeData("sspi.h", MSDNShortId = "39ef6522-ff70-4066-a34d-f2af2174f6ee")]
		public static unsafe extern HRESULT SaslAcceptSecurityContext([In, Optional] CredHandle* phCredential, [In, Optional] CtxtHandle* phContext, [In, Optional] SecBufferDesc* pInput, ASC_REQ fContextReq, DREP TargetDataRep,
			out CtxtHandle phNewContext, [Optional] SecBufferDesc* pOutput, out ASC_RET pfContextAttr, out TimeStamp ptsExpiry);

		/// <summary>The <c>SaslEnumerateProfiles</c> function lists the packages that provide a SASL interface.</summary>
		/// <param name="ProfileList">
		/// Pointer to a list of Unicode or ANSI strings that contain the names of the packages with SASL wrapper support.
		/// </param>
		/// <param name="ProfileCount">
		/// Pointer to an unsigned <c>LONG</c> value that contains the number of packages with SASL wrapper support.
		/// </param>
		/// <returns>
		/// <para>If the call is completed successfully, this function returns SEC_E_OK.</para>
		/// <para>If the function fails, the return value is a nonzero error code.</para>
		/// </returns>
		/// <remarks>
		/// <para>The current list is maintained in the registry under</para>
		/// <para>A terminating <c>NULL</c> character is appended to the end of the list.</para>
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows/desktop/api/sspi/nf-sspi-saslenumerateprofilesa SECURITY_STATUS SEC_ENTRY
		// SaslEnumerateProfilesA( LPSTR *ProfileList, ULONG *ProfileCount );
		[DllImport(Lib.Secur32, SetLastError = false, CharSet = CharSet.Auto)]
		[PInvokeData("sspi.h", MSDNShortId = "0c11e0e3-2538-4703-bc32-31c73d65a498")]
		public static extern HRESULT SaslEnumerateProfiles([MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef = typeof(NullTermStringArrayMarshaler), MarshalCookie = "Auto")] out string[] ProfileList, out uint ProfileCount);

		/// <summary>The <c>SaslGetContextOption</c> function retrieves the specified property of the specified SASL context.</summary>
		/// <param name="ContextHandle">Handle of the SASL context.</param>
		/// <param name="Option">
		/// <para>Property to return from the SASL context. The following table lists the possible values.</para>
		/// <list type="table">
		/// <listheader>
		/// <term>Value</term>
		/// <term>Meaning</term>
		/// </listheader>
		/// <item>
		/// <term>SASL_OPTION_AUTHZ_PROCESSING</term>
		/// <term>
		/// Data type of buffer: ULONG State of SASL processing of the Authz value provided by the SASL application. The valid states for
		/// processing are Sasl_AuthZIDForbidden and Sasl_AuthZIDProcessed.
		/// </term>
		/// </item>
		/// <item>
		/// <term>SASL_OPTION_AUTHZ_STRING</term>
		/// <term>
		/// Data type of buffer: Array of binary characters String of characters passed from the SASL client to the server. If the
		/// AuthZ_Processing state is Sasl_AuthZIDForbidden, the return value SEC_E_UNSUPPORTED_FUNCTION is returned.
		/// </term>
		/// </item>
		/// <item>
		/// <term>SASL_OPTION_RECV_SIZE</term>
		/// <term>Data type of buffer: ULONG Maximum size of the receiving buffer on the local computer.</term>
		/// </item>
		/// <item>
		/// <term>SASL_OPTION_SEND_SIZE</term>
		/// <term>
		/// Data type of buffer: ULONG Maximum message data size that can be transmitted. This value is the maximum buffer size that can be
		/// transmitted to the remote SASL process minus the block size, the trailer size, and the maximum signature size.
		/// </term>
		/// </item>
		/// </list>
		/// </param>
		/// <param name="Value">
		/// A pointer to a buffer that receives the requested property. For the data type of the buffer for each value of the Option
		/// parameter, see the Option parameter.
		/// </param>
		/// <param name="Size">The size, in bytes, of the buffer specified by the Value parameter.</param>
		/// <param name="Needed">
		/// A pointer to an unsigned <c>LONG</c> value that returns the value if the buffer specified by the Value parameter is not large
		/// enough to contain the data value of the property specified by the Option parameter.
		/// </param>
		/// <returns>
		/// <para>
		/// If the call is completed successfully, this function returns SEC_E_OK. The following table shows some possible error return values.
		/// </para>
		/// <list type="table">
		/// <listheader>
		/// <term>Return code</term>
		/// <term>Description</term>
		/// </listheader>
		/// <item>
		/// <term>SEC_E_BUFFER_TOO_SMALL</term>
		/// <term>
		/// The buffer specified by the Value parameter is not large enough to contain the data value of the property specified by the Option parameter.
		/// </term>
		/// </item>
		/// <item>
		/// <term>SEC_E_INVALID_HANDLE</term>
		/// <term>The SASL context handle specified by the ContextHandle parameter was not found in the SASL list.</term>
		/// </item>
		/// <item>
		/// <term>SEC_E_UNSUPPORTED_FUNCTION</term>
		/// <term>The option specified in the Option parameter is not valid.</term>
		/// </item>
		/// </list>
		/// </returns>
		// https://docs.microsoft.com/en-us/windows/desktop/api/sspi/nf-sspi-saslgetcontextoption SECURITY_STATUS SEC_ENTRY
		// SaslGetContextOption( PCtxtHandle ContextHandle, ULONG Option, PVOID Value, ULONG Size, PULONG Needed );
		[DllImport(Lib.Secur32, SetLastError = false, ExactSpelling = true)]
		[PInvokeData("sspi.h", MSDNShortId = "c9c424d3-07e6-4ed0-9189-c932af0475d9")]
		public static extern HRESULT SaslGetContextOption(in CtxtHandle ContextHandle, SASL_OPTION Option, [Out] IntPtr Value, uint Size, out uint Needed);

		/// <summary>The <c>SaslGetProfilePackage</c> function returns the package information for the specified package.</summary>
		/// <param name="ProfileName">Unicode or ANSI string that contains the name of the SASL package.</param>
		/// <param name="PackageInfo">
		/// Pointer to a pointer to a SecPkgInfo structure that returns the package information for the package specified by the ProfileName parameter.
		/// </param>
		/// <returns>
		/// <para>
		/// If the call is completed successfully, this function returns SEC_E_OK. The following table shows some possible failure return values.
		/// </para>
		/// <list type="table">
		/// <listheader>
		/// <term>Return code</term>
		/// <term>Description</term>
		/// </listheader>
		/// <item>
		/// <term>SEC_E_SECPKG_NOT_FOUND</term>
		/// <term>The SASL profile specified by the ProfileName parameter could not be found.</term>
		/// </item>
		/// <item>
		/// <term>SEC_E_INSUFFICIENT_MEMORY</term>
		/// <term>Memory could not be allocated for the SecPkgInfo structure.</term>
		/// </item>
		/// </list>
		/// </returns>
		// https://docs.microsoft.com/en-us/windows/desktop/api/sspi/nf-sspi-saslgetprofilepackagew SECURITY_STATUS SEC_ENTRY
		// SaslGetProfilePackageW( LPWSTR ProfileName, PSecPkgInfoW *PackageInfo );
		[DllImport(Lib.Secur32, SetLastError = false, CharSet = CharSet.Auto)]
		[PInvokeData("sspi.h", MSDNShortId = "b7cecc5f-775f-40ba-abfc-27d51b3f5395")]
		public static extern HRESULT SaslGetProfilePackage(string ProfileName, out SafeContextBuffer PackageInfo);

		/// <summary>
		/// The <c>SaslIdentifyPackage</c> function returns the negotiate prefix that matches the specified SASL negotiation buffer.
		/// </summary>
		/// <param name="pInput">
		/// Pointer to a SecBufferDesc structure that specifies the SASL negotiation buffer for which to find the negotiate prefix.
		/// </param>
		/// <param name="PackageInfo">
		/// Pointer to a pointer to a SecPkgInfo structure that returns the negotiate prefix for the negotiation buffer specified by the
		/// pInput parameter.
		/// </param>
		/// <returns>
		/// <para>If the call is completed successfully, this function returns SEC_E_OK.</para>
		/// <para>If the function fails, the return value is a nonzero error code.</para>
		/// </returns>
		// https://docs.microsoft.com/en-us/windows/desktop/api/sspi/nf-sspi-saslidentifypackagea SECURITY_STATUS SEC_ENTRY
		// SaslIdentifyPackageA( PSecBufferDesc pInput, PSecPkgInfoA *PackageInfo );
		[DllImport(Lib.Secur32, SetLastError = false, CharSet = CharSet.Auto)]
		[PInvokeData("sspi.h", MSDNShortId = "df6f4749-8f28-4ee5-8165-f7aeb3bea7ab")]
		public static extern HRESULT SaslIdentifyPackage(ref SecBufferDesc pInput, out SafeContextBuffer PackageInfo);

		/// <summary>
		/// The <c>SaslInitializeSecurityContext</c> function wraps a standard call to the Security Support Provider Interface
		/// InitializeSecurityContext (General) function and processes SASL server cookies from the server.
		/// </summary>
		/// <param name="phCredential">
		/// A handle to the credentials returned by the AcquireCredentialsHandle function used to build the security context. Using the
		/// <c>SaslInitializeSecurityContext</c> function requires at least OUTBOUND credentials.
		/// </param>
		/// <param name="phContext">
		/// Pointer to a <c>CtxtHandle</c> structure. On the first call to the <c>SaslInitializeSecurityContext</c> function, this pointer is
		/// <c>NULL</c>. On the second call, this parameter is a pointer to the handle to the partially formed context returned in the
		/// phNewContext parameter by the first call.
		/// </param>
		/// <param name="pszTargetName">Pointer to a Unicode or ANSI string that indicates the target of the context.</param>
		/// <param name="fContextReq">
		/// <para>
		/// Bit flags that indicate the requirements of the context. Flags used for this parameter are prefixed with ISC_REQ_; for example:
		/// ISC_REQ_DELEGATE. Specify combinations of the following attributes flags.
		/// </para>
		/// <list type="table">
		/// <listheader>
		/// <term>Value</term>
		/// <term>Meaning</term>
		/// </listheader>
		/// <item>
		/// <term>ISC_REQ_REPLAY_DETECT</term>
		/// <term>Detect replayed packets.</term>
		/// </item>
		/// <item>
		/// <term>ISC_REQ_SEQUENCE_DETECT</term>
		/// <term>Detect messages received out of sequence.</term>
		/// </item>
		/// <item>
		/// <term>ISC_REQ_CONFIDENTIALITY</term>
		/// <term>Encrypt messages.</term>
		/// </item>
		/// <item>
		/// <term>ISC_REQ_STREAM</term>
		/// <term>Support a stream-oriented connection.</term>
		/// </item>
		/// <item>
		/// <term>ISC_REQ_EXTENDED_ERROR</term>
		/// <term>When errors occur, the remote party will be notified.</term>
		/// </item>
		/// <item>
		/// <term>ISC_REQ_CONNECTION</term>
		/// <term>The security context will not handle formatting messages.</term>
		/// </item>
		/// <item>
		/// <term>ISC_REQ_MUTUAL_AUTH</term>
		/// <term>Client and server will be authenticated.</term>
		/// </item>
		/// <item>
		/// <term>ISC_REQ_INTEGRITY</term>
		/// <term>Sign messages and verify signatures.</term>
		/// </item>
		/// </list>
		/// <para>For further descriptions of the various attributes, see Context Requirements.</para>
		/// </param>
		/// <param name="Reserved1">Reserved value; must be zero.</param>
		/// <param name="TargetDataRep">
		/// Indicates the data representation, such as byte ordering, on the target. Can be either SECURITY_NATIVE_DREP or SECURITY_NETWORK_DREP.
		/// </param>
		/// <param name="pInput">
		/// <para>
		/// Pointer to a SecBufferDesc structure that contains pointers to the buffers supplied as input to the package. The pointer must be
		/// <c>NULL</c> on the first call to the function. On subsequent calls to the function, it is a pointer to a buffer allocated with
		/// enough memory to hold the token returned by the remote peer.
		/// </para>
		/// <para>SASL requires a single buffer of type <c>SECBUFFER_TOKEN</c> that contains the challenge received from the server.</para>
		/// </param>
		/// <param name="Reserved2">Reserved value; must be zero.</param>
		/// <param name="phNewContext">
		/// Pointer to a CtxtHandle structure. On the first call to the <c>SaslInitializeSecurityContext</c> function, this pointer receives
		/// the new context handle. On the second call, phNewContext can be the same as the handle specified in the phContext parameter.
		/// </param>
		/// <param name="pOutput">
		/// Pointer to a SecBufferDesc structure that contains pointers to the SecBuffer structure that receives the output data. If a buffer
		/// was typed as SEC_READWRITE in the input, it will be there on output. The system will allocate a buffer for the security token if
		/// requested (through ISC_REQ_ALLOCATE_MEMORY) and fill in the address in the buffer descriptor for the security token.
		/// </param>
		/// <param name="pfContextAttr">
		/// <para>
		/// Pointer to a variable to receive a set of bit flags that indicate the attributes of the established context. For a description of
		/// the various attributes, see Context Requirements.
		/// </para>
		/// <para>Flags used for this parameter are prefixed with ISC_RET_, such as ISC_RET_DELEGATE.</para>
		/// <para>For a list of valid values, see the fContextReq parameter.</para>
		/// <para>
		/// Do not check for security-related attributes until the final function call returns successfully. Attribute flags not related to
		/// security, such as the ASC_RET_ALLOCATED_MEMORY flag, can be checked before the final return.
		/// </para>
		/// <para><c>Note</c> Particular context attributes can change during a negotiation with a remote peer.</para>
		/// </param>
		/// <param name="ptsExpiry">
		/// Pointer to a <c>TimeStamp</c> structure that receives the expiration time of the context. It is recommended that the security
		/// package always return this value in local time. This parameter is optional and <c>NULL</c> should be passed for short-lived clients.
		/// </param>
		/// <returns>
		/// <para>
		/// If the call is completed successfully, this function returns SEC_E_OK. The following table shows some possible failure return values.
		/// </para>
		/// <list type="table">
		/// <listheader>
		/// <term>Return code</term>
		/// <term>Description</term>
		/// </listheader>
		/// <item>
		/// <term>SEC_E_ALGORITHM_MISMATCH</term>
		/// <term>Authz processing is not permitted.</term>
		/// </item>
		/// <item>
		/// <term>SEC_E_INSUFFICIENT_MEMORY</term>
		/// <term>Not enough memory is available to complete the request.</term>
		/// </item>
		/// <item>
		/// <term>SEC_E_INVALID_TOKEN</term>
		/// <term>No Token buffer is located in the pOutput parameter, or the message failed to decrypt.</term>
		/// </item>
		/// </list>
		/// </returns>
		// https://docs.microsoft.com/en-us/windows/desktop/api/sspi/nf-sspi-saslinitializesecuritycontextw SECURITY_STATUS SEC_ENTRY
		// SaslInitializeSecurityContextW( PCredHandle phCredential, PCtxtHandle phContext, LPWSTR pszTargetName, unsigned long fContextReq,
		// unsigned long Reserved1, unsigned long TargetDataRep, PSecBufferDesc pInput, unsigned long Reserved2, PCtxtHandle phNewContext,
		// PSecBufferDesc pOutput, unsigned long *pfContextAttr, PTimeStamp ptsExpiry );
		[DllImport(Lib.Secur32, SetLastError = false, CharSet = CharSet.Auto)]
		[PInvokeData("sspi.h", MSDNShortId = "9cc661b7-f1b0-4fb1-b799-5b318d87fd4d")]
		public static unsafe extern HRESULT SaslInitializeSecurityContext([In, Optional] CredHandle* phCredential, [In, Optional] CtxtHandle* phContext, [Optional] string pszTargetName, ASC_REQ fContextReq, [Optional] uint Reserved1, DREP TargetDataRep,
			[In, Optional] SecBufferDesc* pInput, [Optional] uint Reserved2, out SafeCtxtHandle phNewContext, [Optional] SecBufferDesc* pOutput, out ASC_RET pfContextAttr, out TimeStamp ptsExpiry);

		/// <summary>The <c>SaslSetContextOption</c> function sets the value of the specified property for the specified SASL context.</summary>
		/// <param name="ContextHandle">Handle of the SASL context.</param>
		/// <param name="Option">
		/// <para>Property to set for the SASL context. The following table lists the possible values.</para>
		/// <list type="table">
		/// <listheader>
		/// <term>Value</term>
		/// <term>Meaning</term>
		/// </listheader>
		/// <item>
		/// <term>SASL_OPTION_AUTHZ_PROCESSING</term>
		/// <term>
		/// Data type of buffer: ULONG State of SASL processing of the Authz value provided by the SASL application. The valid states for
		/// processing are Sasl_AuthZIDForbidden and Sasl_AuthZIDProcessed. The default value is Sasl_AuthZIDProcessed.
		/// </term>
		/// </item>
		/// <item>
		/// <term>SASL_OPTION_AUTHZ_STRING</term>
		/// <term>
		/// Data type of buffer: Array of binary characters String of characters passed from the SASL client to the server. If the
		/// AuthZ_Processing state is Sasl_AuthZIDForbidden, the return value SEC_E_UNSUPPORTED_FUNCTION is returned.
		/// </term>
		/// </item>
		/// <item>
		/// <term>SASL_OPTION_RECV_SIZE</term>
		/// <term>Data type of buffer: ULONG Maximum size of the receiving buffer on the local computer. The default value is 0x0FFFF bytes.</term>
		/// </item>
		/// <item>
		/// <term>SASL_OPTION_SEND_SIZE</term>
		/// <term>
		/// Data type of buffer: ULONG Maximum message data size that can be transmitted. This value is the maximum buffer size that can be
		/// transmitted to the remote SASL process minus the block size, the trailer size, and the maximum signature size. The default value
		/// is 0x0FFFF bytes.
		/// </term>
		/// </item>
		/// </list>
		/// </param>
		/// <param name="Value">
		/// A pointer to a buffer that contains the value to set to the requested property. For the data type of the buffer for each value of
		/// the Option parameter, see the Option parameter.
		/// </param>
		/// <param name="Size">The size, in bytes, of the buffer specified by the Value parameter.</param>
		/// <returns>
		/// <para>
		/// If the call is completed successfully, this function returns SEC_E_OK. The following table shows some possible error return values.
		/// </para>
		/// <list type="table">
		/// <listheader>
		/// <term>Return code</term>
		/// <term>Description</term>
		/// </listheader>
		/// <item>
		/// <term>SEC_E_BUFFER_TOO_SMALL</term>
		/// <term>
		/// The buffer specified by the Value parameter is not large enough to contain the data value of the property specified by the Option parameter.
		/// </term>
		/// </item>
		/// <item>
		/// <term>SEC_E_INVALID_HANDLE</term>
		/// <term>The SASL context handle specified by the ContextHandle parameter was not found in the SASL list.</term>
		/// </item>
		/// <item>
		/// <term>SEC_E_UNSUPPORTED_FUNCTION</term>
		/// <term>The option specified in the Option parameter is not valid.</term>
		/// </item>
		/// </list>
		/// </returns>
		// https://docs.microsoft.com/en-us/windows/desktop/api/sspi/nf-sspi-saslsetcontextoption SECURITY_STATUS SEC_ENTRY
		// SaslSetContextOption( PCtxtHandle ContextHandle, ULONG Option, PVOID Value, ULONG Size );
		[DllImport(Lib.Secur32, SetLastError = false, ExactSpelling = true)]
		[PInvokeData("sspi.h", MSDNShortId = "3c3b1209-b0de-4100-8dfe-53ea314b790b")]
		public static extern HRESULT SaslSetContextOption(in CtxtHandle ContextHandle, SASL_OPTION Option, [MarshalAs(UnmanagedType.LPWStr)] string Value, uint Size);

		/// <summary>The <c>SaslSetContextOption</c> function sets the value of the specified property for the specified SASL context.</summary>
		/// <param name="ContextHandle">Handle of the SASL context.</param>
		/// <param name="Option">
		/// <para>Property to set for the SASL context. The following table lists the possible values.</para>
		/// <list type="table">
		/// <listheader>
		/// <term>Value</term>
		/// <term>Meaning</term>
		/// </listheader>
		/// <item>
		/// <term>SASL_OPTION_AUTHZ_PROCESSING</term>
		/// <term>
		/// Data type of buffer: ULONG State of SASL processing of the Authz value provided by the SASL application. The valid states for
		/// processing are Sasl_AuthZIDForbidden and Sasl_AuthZIDProcessed. The default value is Sasl_AuthZIDProcessed.
		/// </term>
		/// </item>
		/// <item>
		/// <term>SASL_OPTION_AUTHZ_STRING</term>
		/// <term>
		/// Data type of buffer: Array of binary characters String of characters passed from the SASL client to the server. If the
		/// AuthZ_Processing state is Sasl_AuthZIDForbidden, the return value SEC_E_UNSUPPORTED_FUNCTION is returned.
		/// </term>
		/// </item>
		/// <item>
		/// <term>SASL_OPTION_RECV_SIZE</term>
		/// <term>Data type of buffer: ULONG Maximum size of the receiving buffer on the local computer. The default value is 0x0FFFF bytes.</term>
		/// </item>
		/// <item>
		/// <term>SASL_OPTION_SEND_SIZE</term>
		/// <term>
		/// Data type of buffer: ULONG Maximum message data size that can be transmitted. This value is the maximum buffer size that can be
		/// transmitted to the remote SASL process minus the block size, the trailer size, and the maximum signature size. The default value
		/// is 0x0FFFF bytes.
		/// </term>
		/// </item>
		/// </list>
		/// </param>
		/// <param name="Value">
		/// A pointer to a buffer that contains the value to set to the requested property. For the data type of the buffer for each value of
		/// the Option parameter, see the Option parameter.
		/// </param>
		/// <param name="Size">The size, in bytes, of the buffer specified by the Value parameter.</param>
		/// <returns>
		/// <para>
		/// If the call is completed successfully, this function returns SEC_E_OK. The following table shows some possible error return values.
		/// </para>
		/// <list type="table">
		/// <listheader>
		/// <term>Return code</term>
		/// <term>Description</term>
		/// </listheader>
		/// <item>
		/// <term>SEC_E_BUFFER_TOO_SMALL</term>
		/// <term>
		/// The buffer specified by the Value parameter is not large enough to contain the data value of the property specified by the Option parameter.
		/// </term>
		/// </item>
		/// <item>
		/// <term>SEC_E_INVALID_HANDLE</term>
		/// <term>The SASL context handle specified by the ContextHandle parameter was not found in the SASL list.</term>
		/// </item>
		/// <item>
		/// <term>SEC_E_UNSUPPORTED_FUNCTION</term>
		/// <term>The option specified in the Option parameter is not valid.</term>
		/// </item>
		/// </list>
		/// </returns>
		// https://docs.microsoft.com/en-us/windows/desktop/api/sspi/nf-sspi-saslsetcontextoption SECURITY_STATUS SEC_ENTRY
		// SaslSetContextOption( PCtxtHandle ContextHandle, ULONG Option, PVOID Value, ULONG Size );
		[DllImport(Lib.Secur32, SetLastError = false, ExactSpelling = true)]
		[PInvokeData("sspi.h", MSDNShortId = "3c3b1209-b0de-4100-8dfe-53ea314b790b")]
		public static extern HRESULT SaslSetContextOption(in CtxtHandle ContextHandle, SASL_OPTION Option, in uint Value, uint Size = 4);

		/// <summary>
		/// Enables a transport application to set attributes of a security context for a security package. This function is supported only
		/// by the Schannel security package.
		/// </summary>
		/// <param name="phContext">A handle to the security context to be set.</param>
		/// <param name="ulAttribute">
		/// <para>The attribute of the context to be set. This parameter can be one of the following values.</para>
		/// <list type="table">
		/// <listheader>
		/// <term>Value</term>
		/// <term>Meaning</term>
		/// </listheader>
		/// <item>
		/// <term>SECPKG_ATTR_APP_DATA 94</term>
		/// <term>
		/// The pBuffer parameter contains a pointer to a SecPkgContext_SessionAppData structure. Sets application data for the session. This
		/// attribute is supported only by the Schannel security package.
		/// </term>
		/// </item>
		/// <item>
		/// <term>SECPKG_ATTR_EAP_PRF_INFO 101</term>
		/// <term>
		/// The pBuffer parameter contains a pointer to a SecPkgContext_EapPrfInfo structure. Sets the pseudo-random function (PRF) used by
		/// the Extensible Authentication Protocol (EAP). This is the value that is returned by a call to the QueryContextAttributes
		/// (Schannel) function when SECPKG_ATTR_EAP_KEY_BLOCK is passed as the value of the ulAttribute parameter. This attribute is
		/// supported only by the Schannel security package.
		/// </term>
		/// </item>
		/// <item>
		/// <term>SECPKG_ATTR_EARLY_START 105</term>
		/// <term>
		/// The pBuffer parameter contains a pointer to a SecPkgContext_EarlyStart structure. Sets the False Start feature. See the Building
		/// a faster and more secure web blog post for information on this feature.
		/// </term>
		/// </item>
		/// <item>
		/// <term>SECPKG_ATTR_DTLS_MTU 34</term>
		/// <term>
		/// Sets and retrieves the MTU (maximum transmission unit) value for use with DTLS. If DTLS is not enabled in a security context,
		/// this attribute is not supported. Valid values are between 200 bytes and 64 kilobytes. The default DTLS MTU value in Schannel is
		/// 1096 bytes.
		/// </term>
		/// </item>
		/// <item>
		/// <term>SECPKG_ATTR_KEYING_MATERIAL_INFO 106</term>
		/// <term>
		/// The pBuffer parameter contains a pointer to a SecPkgContext_KeyingMaterialInfo structure. The keying material export feature
		/// follows the RFC 5705 standard. This attribute is supported only by the Schannel security package in Windows 10 and Windows Server
		/// 2016 or later versions.
		/// </term>
		/// </item>
		/// </list>
		/// </param>
		/// <param name="pBuffer">
		/// A pointer to a structure that contains values to set the attributes to. The type of structure pointed to depends on the value
		/// specified in the ulAttribute parameter.
		/// </param>
		/// <param name="cbBuffer">The size, in bytes, of the pBuffer parameter.</param>
		/// <returns>
		/// <para>If the function succeeds, the function returns SEC_E_OK.</para>
		/// <para>If the function fails, it returns a nonzero error code. The following error code is one of the possible error codes.</para>
		/// <list type="table">
		/// <listheader>
		/// <term>Return code</term>
		/// <term>Description</term>
		/// </listheader>
		/// <item>
		/// <term>SEC_E_UNSUPPORTED_FUNCTION</term>
		/// <term>This value is returned by Schannel kernel mode to indicate that this function is not supported.</term>
		/// </item>
		/// </list>
		/// </returns>
		// https://docs.microsoft.com/en-us/windows/desktop/api/sspi/nf-sspi-setcontextattributesa SECURITY_STATUS SEC_ENTRY
		// SetContextAttributesA( PCtxtHandle phContext, unsigned long ulAttribute, void *pBuffer, unsigned long cbBuffer );
		[DllImport(Lib.Secur32, SetLastError = false, CharSet = CharSet.Auto)]
		[PInvokeData("sspi.h", MSDNShortId = "e3246c3e-3e8c-49fe-99d8-dfff1a10ab83")]
		public static extern HRESULT SetContextAttributes(in CtxtHandle phContext, SECPKG_ATTR ulAttribute, IntPtr pBuffer, uint cbBuffer);

		/// <summary>
		/// Sets the attributes of a credential, such as the name associated with the credential. The information is valid for any security
		/// context created with the specified credential.
		/// </summary>
		/// <param name="phCredential">A handle of the credentials to be set.</param>
		/// <param name="ulAttribute">
		/// <para>Specifies the attribute to set. This parameter can be any of the following attributes.</para>
		/// <list type="table">
		/// <listheader>
		/// <term>Value</term>
		/// <term>Meaning</term>
		/// </listheader>
		/// <item>
		/// <term>SECPKG_CRED_ATTR_NAMES</term>
		/// <term>
		/// Sets the name of a credential in a pBuffer parameter of type SecPkgCredentials_Names. This attribute is not supported by Schannel
		/// in WOW64 mode.
		/// </term>
		/// </item>
		/// <item>
		/// <term>SECPKG_CRED_ATTR_KDC_PROXY_SETTINGS</term>
		/// <term>
		/// Sets the Kerberos proxy setting in a pBuffer parameter of type SecPkgCredentials_KdcProxySettings. This attribute is only
		/// supported by Kerberos.
		/// </term>
		/// </item>
		/// <item>
		/// <term>SECPKG_ATTR_SUPPORTED_ALGS</term>
		/// <term>
		/// Sets the supported algorithms in a pBuffer parameter of type SecPkgCred_SupportedAlgs. All supported algorithms are included,
		/// regardless of whether they are supported by the provided certificate or enabled on the local computer. This attribute is
		/// supported only by Schannel.
		/// </term>
		/// </item>
		/// <item>
		/// <term>SECPKG_ATTR_CIPHER_STRENGTHS</term>
		/// <term>
		/// Sets the cipher strengths in a pBuffer parameter of type SecPkgCred_CipherStrengths. This attribute is supported only by Schannel.
		/// </term>
		/// </item>
		/// <item>
		/// <term>SECPKG_ATTR_SUPPORTED_PROTOCOLS</term>
		/// <term>
		/// Sets the supported algorithms in a pBuffer parameter of type SecPkgCred_SupportedProtocols. All supported protocols are included,
		/// regardless of whether they are supported by the provided certificate or enabled on the local computer. This attribute is
		/// supported only by Schannel.
		/// </term>
		/// </item>
		/// </list>
		/// </param>
		/// <param name="pBuffer">
		/// A pointer to a buffer that contains the new attribute value. The type of structure returned depends on the value of ulAttribute.
		/// </param>
		/// <param name="cbBuffer">The size, in bytes, of the pBuffer buffer.</param>
		/// <returns>
		/// <para>If the function succeeds, the return value is SEC_E_OK.</para>
		/// <para>If the function fails, the return value may be one of the following error codes.</para>
		/// <list type="table">
		/// <listheader>
		/// <term>Return code</term>
		/// <term>Description</term>
		/// </listheader>
		/// <item>
		/// <term>SEC_E_INVALID_HANDLE</term>
		/// <term>The handle passed to the function is not valid.</term>
		/// </item>
		/// <item>
		/// <term>SEC_E_UNSUPPORTED_FUNCTION</term>
		/// <term>
		/// The specified attribute is not supported by Schannel. This return value will only be returned when the Schannel SSP is being used.
		/// </term>
		/// </item>
		/// <item>
		/// <term>SEC_E_INSUFFICIENT_MEMORY</term>
		/// <term>Not enough memory is available to complete the request.</term>
		/// </item>
		/// </list>
		/// </returns>
		// https://docs.microsoft.com/en-us/windows/desktop/api/sspi/nf-sspi-setcredentialsattributesa SECURITY_STATUS SEC_ENTRY
		// SetCredentialsAttributesA( PCredHandle phCredential, unsigned long ulAttribute, void *pBuffer, unsigned long cbBuffer );
		[DllImport(Lib.Secur32, SetLastError = false, CharSet = CharSet.Auto)]
		[PInvokeData("sspi.h", MSDNShortId = "419fb4f0-3dd1-4473-aeb2-8024355e0c1c")]
		public static extern HRESULT SetCredentialsAttributes(in CredHandle phCredential, SECPKG_CRED_ATTR ulAttribute, IntPtr pBuffer, uint cbBuffer);

		/// <summary>
		/// <para>Compares the two specified credentials.</para>
		/// </summary>
		/// <param name="AuthIdentity1">
		/// <para>A pointer to an opaque structure that specifies the first credential to compare.</para>
		/// </param>
		/// <param name="AuthIdentity2">
		/// <para>A pointer to an opaque structure that specifies the second credential to compare.</para>
		/// </param>
		/// <param name="SameSuppliedUser">
		/// <para>
		/// <c>TRUE</c> if the user account specified by the AuthIdentity1 parameter is the same as the user account specified by the
		/// AuthIdentity2 parameter; otherwise, <c>FALSE</c>.
		/// </para>
		/// </param>
		/// <param name="SameSuppliedIdentity">
		/// <para>
		/// <c>TRUE</c> if the identity specified by the AuthIdentity1 parameter is the same as the identity specified by the AuthIdentity2
		/// parameter; otherwise, <c>FALSE</c>.
		/// </para>
		/// </param>
		/// <returns>
		/// <para>If the function succeeds, it returns <c>SEC_E_OK</c>.</para>
		/// <para>If the function fails, it returns a nonzero error code.</para>
		/// </returns>
		// https://docs.microsoft.com/en-us/windows/desktop/api/sspi/nf-sspi-sspicompareauthidentities SECURITY_STATUS SEC_ENTRY
		// SspiCompareAuthIdentities( PSEC_WINNT_AUTH_IDENTITY_OPAQUE AuthIdentity1, PSEC_WINNT_AUTH_IDENTITY_OPAQUE AuthIdentity2, PBOOLEAN
		// SameSuppliedUser, PBOOLEAN SameSuppliedIdentity );
		[DllImport(Lib.Secur32, SetLastError = false, ExactSpelling = true)]
		[PInvokeData("sspi.h", MSDNShortId = "d2c4f363-3d86-48f0-bae1-4f9240d68bab")]
		public static extern Win32Error SspiCompareAuthIdentities(PSEC_WINNT_AUTH_IDENTITY_OPAQUE AuthIdentity1, PSEC_WINNT_AUTH_IDENTITY_OPAQUE AuthIdentity2,
			[MarshalAs(UnmanagedType.U1)] out bool SameSuppliedUser, [MarshalAs(UnmanagedType.U1)] out bool SameSuppliedIdentity);

		/// <summary>
		/// <para>Creates a copy of the specified opaque credential structure.</para>
		/// </summary>
		/// <param name="AuthData">
		/// <para>The credential structure to be copied.</para>
		/// </param>
		/// <param name="AuthDataCopy">
		/// <para>The structure that receives the copy of the structure specified by the AuthData parameter.</para>
		/// </param>
		/// <returns>
		/// <para>If the function succeeds, it returns <c>SEC_E_OK</c>.</para>
		/// <para>If the function fails, it returns a nonzero error code.</para>
		/// </returns>
		// https://docs.microsoft.com/en-us/windows/desktop/api/sspi/nf-sspi-sspicopyauthidentity SECURITY_STATUS SEC_ENTRY
		// SspiCopyAuthIdentity( PSEC_WINNT_AUTH_IDENTITY_OPAQUE AuthData, PSEC_WINNT_AUTH_IDENTITY_OPAQUE *AuthDataCopy );
		[DllImport(Lib.Secur32, SetLastError = false, ExactSpelling = true)]
		[PInvokeData("sspi.h", MSDNShortId = "e53807bf-b5a1-4479-a73b-dd85c5da173e")]
		public static extern Win32Error SspiCopyAuthIdentity(PSEC_WINNT_AUTH_IDENTITY_OPAQUE AuthData, out SafePSEC_WINNT_AUTH_IDENTITY_OPAQUE AuthDataCopy);

		/// <summary>
		/// <para>Decrypts the specified encrypted credential.</para>
		/// </summary>
		/// <param name="EncryptedAuthData">
		/// <para>
		/// On input, a pointer to the encrypted credential structure to be decrypted. On output, a pointer to the decrypted credential structure.
		/// </para>
		/// </param>
		/// <returns>
		/// <para>If the function succeeds, it returns <c>SEC_E_OK</c>.</para>
		/// <para>If the function fails, it returns a nonzero error code.</para>
		/// </returns>
		// https://docs.microsoft.com/en-us/windows/desktop/api/sspi/nf-sspi-sspidecryptauthidentity SECURITY_STATUS SEC_ENTRY
		// SspiDecryptAuthIdentity( PSEC_WINNT_AUTH_IDENTITY_OPAQUE EncryptedAuthData );
		[DllImport(Lib.Secur32, SetLastError = false, ExactSpelling = true)]
		[PInvokeData("sspi.h", MSDNShortId = "aef0206c-c376-4877-b1a6-5e86d2e35dea")]
		public static extern Win32Error SspiDecryptAuthIdentity(PSEC_WINNT_AUTH_IDENTITY_OPAQUE EncryptedAuthData);

		/// <summary>Decrypts a <c>SEC_WINNT_AUTH_IDENTITY_OPAQUE</c> structure.</summary>
		/// <param name="Options">
		/// <para>
		/// Decryption options. This parameter should be the same value as the value passed to the SspiEncryptAuthIdentityEx function, which
		/// can be one of the following values.
		/// </para>
		/// <list type="table">
		/// <listheader>
		/// <term>Value</term>
		/// <term>Meaning</term>
		/// </listheader>
		/// <item>
		/// <term>SEC_WINNT_AUTH_IDENTITY_ENCRYPT_SAME_LOGON</term>
		/// <term>
		/// The encrypted structure can only be decrypted by a security context in the same logon session. This option is used to protect an
		/// identity buffer that is being sent over a local RPC.
		/// </term>
		/// </item>
		/// <item>
		/// <term>SEC_WINNT_AUTH_IDENTITY_ENCRYPT_SAME_PROCESS</term>
		/// <term>
		/// The encrypted structure can only be decrypted by the same process. Calling the function with this option is equivalent to calling
		/// SspiEncryptAuthIdentity. This option is used to protect an identity buffer that is being persisted in a process's private memory
		/// for an extended period.
		/// </term>
		/// </item>
		/// </list>
		/// </param>
		/// <param name="EncryptedAuthData">This buffer is the output of the SspiEncryptAuthIdentityEx function.</param>
		/// <returns>
		/// <para>If the function succeeds, it returns SEC_E_OK.</para>
		/// <para>If the function fails, it returns a nonzero error code.</para>
		/// </returns>
		// https://docs.microsoft.com/en-us/windows/desktop/api/sspi/nf-sspi-sspidecryptauthidentityex SECURITY_STATUS SEC_ENTRY
		// SspiDecryptAuthIdentityEx( ULONG Options, PSEC_WINNT_AUTH_IDENTITY_OPAQUE EncryptedAuthData );
		[DllImport(Lib.SspiCli, SetLastError = false, ExactSpelling = true)]
		[PInvokeData("sspi.h", MSDNShortId = "86598BAA-0E87-46A9-AA1A-BF04BF0CDAFA")]
		public static extern HRESULT SspiDecryptAuthIdentityEx(SEC_WINNT_AUTH_IDENTITY_ENCRYPT Options, PSEC_WINNT_AUTH_IDENTITY_OPAQUE EncryptedAuthData);

		/// <summary>
		/// <para>Encodes the specified authentication identity as three strings.</para>
		/// </summary>
		/// <param name="pAuthIdentity">
		/// <para>The credential structure to be encoded.</para>
		/// </param>
		/// <param name="ppszUserName">
		/// <para>The marshaled user name of the identity specified by the pAuthIdentity parameter.</para>
		/// <para>When you have finished using this string, free it by calling the SspiFreeAuthIdentity function.</para>
		/// </param>
		/// <param name="ppszDomainName">
		/// <para>The marshaled domain name of the identity specified by the pAuthIdentity parameter.</para>
		/// <para>When you have finished using this string, free it by calling the SspiFreeAuthIdentity function.</para>
		/// </param>
		/// <param name="ppszPackedCredentialsString">
		/// <para>An encoded string version of a SEC_WINNT_AUTH_IDENTITY_EX2 structure that specifies the users credentials.</para>
		/// <para>When you have finished using this string, free it by calling the SspiFreeAuthIdentity function.</para>
		/// </param>
		/// <returns>
		/// <para>If the function succeeds, it returns <c>SEC_E_OK</c>.</para>
		/// <para>
		/// If the function fails, it returns a nonzero error code. Possible values include, but are not limited to, those in the following table.
		/// </para>
		/// <list type="table">
		/// <listheader>
		/// <term>Return code/value</term>
		/// <term>Description</term>
		/// </listheader>
		/// <item>
		/// <term>STATUS_INVALID_PARAMETER 0xC000000D</term>
		/// <term>
		/// The SEC_WINNT_AUTH_IDENTITY_FLAGS_PROCESS_ENCRYPTED flag is set in the identity structure specified by the pAuthIdentity parameter.
		/// </term>
		/// </item>
		/// </list>
		/// </returns>
		// https://docs.microsoft.com/en-us/windows/desktop/api/sspi/nf-sspi-sspiencodeauthidentityasstrings SECURITY_STATUS SEC_ENTRY
		// SspiEncodeAuthIdentityAsStrings( PSEC_WINNT_AUTH_IDENTITY_OPAQUE pAuthIdentity, PCWSTR *ppszUserName, PCWSTR *ppszDomainName,
		// PCWSTR *ppszPackedCredentialsString );
		[DllImport(Lib.Secur32, SetLastError = false, ExactSpelling = true)]
		[PInvokeData("sspi.h", MSDNShortId = "0610a7b8-67e9-4c01-893f-da579eeea2f8")]
		public static extern Win32Error SspiEncodeAuthIdentityAsStrings([In] PSEC_WINNT_AUTH_IDENTITY_OPAQUE pAuthIdentity,
			[Out, MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef = typeof(SspiStringMarshaler))] out string ppszUserName,
			[Out, MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef = typeof(SspiStringMarshaler))] out string ppszDomainName,
			[Out, MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef = typeof(SspiStringMarshaler))] out string ppszPackedCredentialsString);

		/// <summary>
		/// <para>Encodes a set of three credential strings as an authentication identity structure.</para>
		/// </summary>
		/// <param name="pszUserName">
		/// <para>The user name associated with the identity to encode.</para>
		/// </param>
		/// <param name="pszDomainName">
		/// <para>The domain name associated with the identity to encode.</para>
		/// </param>
		/// <param name="pszPackedCredentialsString">
		/// <para>An encoded string version of a SEC_WINNT_AUTH_IDENTITY_EX2 structure that specifies the user's credentials.</para>
		/// </param>
		/// <param name="ppAuthIdentity">
		/// <para>A pointer to the encoded identity structure.</para>
		/// <para>When you have finished using this structure, free it by calling the SspiFreeAuthIdentity function.</para>
		/// </param>
		/// <returns>
		/// <para>If the function succeeds, it returns <c>SEC_E_OK</c>.</para>
		/// <para>If the function fails, it returns a nonzero error code.</para>
		/// </returns>
		// https://docs.microsoft.com/en-us/windows/desktop/api/sspi/nf-sspi-sspiencodestringsasauthidentity SECURITY_STATUS SEC_ENTRY
		// SspiEncodeStringsAsAuthIdentity( PCWSTR pszUserName, PCWSTR pszDomainName, PCWSTR pszPackedCredentialsString,
		// PSEC_WINNT_AUTH_IDENTITY_OPAQUE *ppAuthIdentity );
		[DllImport(Lib.Secur32, SetLastError = false, ExactSpelling = true)]
		[PInvokeData("sspi.h", MSDNShortId = "0aea2f00-fcf1-4c4e-a22f-a669dd4fb294")]
		public static extern Win32Error SspiEncodeStringsAsAuthIdentity([MarshalAs(UnmanagedType.LPWStr)] string pszUserName, [MarshalAs(UnmanagedType.LPWStr)] string pszDomainName,
			[MarshalAs(UnmanagedType.LPWStr)] string pszPackedCredentialsString, out SafePSEC_WINNT_AUTH_IDENTITY_OPAQUE ppAuthIdentity);

		/// <summary>
		/// <para>Encrypts the specified identity structure.</para>
		/// </summary>
		/// <param name="AuthData">
		/// <para>On input, the identity structure to encrypt. On output, the encrypted identity structure.</para>
		/// </param>
		/// <returns>
		/// <para>If the function succeeds, it returns <c>SEC_E_OK</c>.</para>
		/// <para>If the function fails, it returns a nonzero error code.</para>
		/// </returns>
		// https://docs.microsoft.com/en-us/windows/desktop/api/sspi/nf-sspi-sspiencryptauthidentity SECURITY_STATUS SEC_ENTRY
		// SspiEncryptAuthIdentity( PSEC_WINNT_AUTH_IDENTITY_OPAQUE AuthData );
		[DllImport(Lib.Secur32, SetLastError = false, ExactSpelling = true)]
		[PInvokeData("sspi.h", MSDNShortId = "4460f7ec-35fd-4ad1-8c20-dda9f4d3477a")]
		public static extern Win32Error SspiEncryptAuthIdentity(PSEC_WINNT_AUTH_IDENTITY_OPAQUE AuthData);

		/// <summary>Encrypts a <c>SEC_WINNT_AUTH_IDENTITY_OPAQUE</c> structure.</summary>
		/// <param name="Options">
		/// <para>Encryption options. This can be one or more of the following values.</para>
		/// <list type="table">
		/// <listheader>
		/// <term>Value</term>
		/// <term>Meaning</term>
		/// </listheader>
		/// <item>
		/// <term>SEC_WINNT_AUTH_IDENTITY_ENCRYPT_SAME_LOGON</term>
		/// <term>
		/// The encrypted structure can only be decrypted by a security context in the same logon session. This option is used to protect an
		/// identity buffer that is being sent over a local RPC.
		/// </term>
		/// </item>
		/// <item>
		/// <term>SEC_WINNT_AUTH_IDENTITY_ENCRYPT_SAME_PROCESS</term>
		/// <term>
		/// The encrypted structure can only be decrypted by the same process. Calling the function with this option is equivalent to calling
		/// SspiEncryptAuthIdentity. This option is used to protect an identity buffer that is being persisted in a process's private memory
		/// for an extended period.
		/// </term>
		/// </item>
		/// </list>
		/// </param>
		/// <param name="AuthData">
		/// On input, a pointer to an identity buffer to encrypt. This buffer must be prepared for encryption prior to the call to this
		/// function. This can be done by calling the function SspiEncryptAuthIdentity. On output, the encrypted identity buffer.
		/// </param>
		/// <returns>
		/// <para>If the function succeeds, it returns SEC_E_OK.</para>
		/// <para>If the function fails, it returns a nonzero error code.</para>
		/// </returns>
		/// <remarks>
		/// To transfer credentials securely across processes, applications typically call this function with the
		/// SEC_WINNT_AUTH_IDENTITY_ENCRYPT_SAME_LOGON option, followed by SspiMarshalAuthIdentity to obtain a marshaled authentication
		/// buffer and its length. For example, Online Identity Credential Provider does this to return the authentication buffer from their
		/// ICredentialProviderCredential::GetSerialization method.
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows/desktop/api/sspi/nf-sspi-sspiencryptauthidentityex SECURITY_STATUS SEC_ENTRY
		// SspiEncryptAuthIdentityEx( ULONG Options, PSEC_WINNT_AUTH_IDENTITY_OPAQUE AuthData );
		[DllImport(Lib.SspiCli, SetLastError = false, ExactSpelling = true)]
		[PInvokeData("sspi.h", MSDNShortId = "9290BEF8-24C9-47F0-B258-56ED7D67620B")]
		public static extern HRESULT SspiEncryptAuthIdentityEx(SEC_WINNT_AUTH_IDENTITY_ENCRYPT Options, PSEC_WINNT_AUTH_IDENTITY_OPAQUE AuthData);

		/// <summary>
		/// <para>
		/// Creates a new identity structure that is a copy of the specified identity structure modified to exclude the specified security
		/// support provider (SSP).
		/// </para>
		/// </summary>
		/// <param name="AuthIdentity">
		/// <para>The identity structure to modify.</para>
		/// </param>
		/// <param name="pszPackageName">
		/// <para>The SSP to exclude.</para>
		/// </param>
		/// <param name="ppNewAuthIdentity">
		/// <para>The modified identity structure.</para>
		/// </param>
		/// <returns>
		/// <para>If the function succeeds, it returns <c>SEC_E_OK</c>.</para>
		/// <para>If the function fails, it returns a nonzero error code.</para>
		/// </returns>
		// https://docs.microsoft.com/en-us/windows/desktop/api/sspi/nf-sspi-sspiexcludepackage SECURITY_STATUS SEC_ENTRY SspiExcludePackage(
		// PSEC_WINNT_AUTH_IDENTITY_OPAQUE AuthIdentity, PCWSTR pszPackageName, PSEC_WINNT_AUTH_IDENTITY_OPAQUE *ppNewAuthIdentity );
		[DllImport(Lib.Secur32, SetLastError = false, ExactSpelling = true)]
		[PInvokeData("sspi.h", MSDNShortId = "2f85bb13-b72a-4c26-a328-9424a33a63b8")]
		public static extern Win32Error SspiExcludePackage(PSEC_WINNT_AUTH_IDENTITY_OPAQUE AuthIdentity, [MarshalAs(UnmanagedType.LPWStr)] string pszPackageName, out SafePSEC_WINNT_AUTH_IDENTITY_OPAQUE ppNewAuthIdentity);

		/// <summary>
		/// <para>Frees the memory allocated for the specified identity structure.</para>
		/// </summary>
		/// <param name="AuthData">
		/// <para>The identity structure to free.</para>
		/// </param>
		/// <returns>
		/// <para>If the function succeeds, it returns <c>SEC_E_OK</c>.</para>
		/// <para>If the function fails, it returns a nonzero error code.</para>
		/// </returns>
		// https://docs.microsoft.com/en-us/windows/desktop/api/sspi/nf-sspi-sspifreeauthidentity VOID SEC_ENTRY SspiFreeAuthIdentity(
		// PSEC_WINNT_AUTH_IDENTITY_OPAQUE AuthData );
		[DllImport(Lib.Secur32, SetLastError = false, ExactSpelling = true)]
		[PInvokeData("sspi.h", MSDNShortId = "6199f66e-7adb-4bb9-8e77-a735e31dd5f6")]
		public static extern void SspiFreeAuthIdentity(IntPtr AuthData);

		/// <summary>
		/// <para>Gets the host name associated with the specified target.</para>
		/// </summary>
		/// <param name="pszTargetName">
		/// <para>The target for which to get the host name.</para>
		/// </param>
		/// <param name="pszHostName">
		/// <para>The name of the host associated with the target specified by the pszTargetName parameter.</para>
		/// </param>
		/// <returns>
		/// <para>If the function succeeds, it returns <c>SEC_E_OK</c>.</para>
		/// <para>If the function fails, it returns a nonzero error code.</para>
		/// </returns>
		// https://docs.microsoft.com/en-us/windows/desktop/api/sspi/nf-sspi-sspigettargethostname SECURITY_STATUS SEC_ENTRY
		// SspiGetTargetHostName( PCWSTR pszTargetName, PWSTR *pszHostName );
		[DllImport(Lib.Secur32, SetLastError = false, ExactSpelling = true)]
		[PInvokeData("sspi.h", MSDNShortId = "84570dfc-1890-4b82-b411-1f9eaa75537b")]
		public static extern Win32Error SspiGetTargetHostName([MarshalAs(UnmanagedType.LPWStr)] string pszTargetName, [MarshalAs(UnmanagedType.LPWStr)] out string pszHostName);

		/// <summary>
		/// <para>Indicates whether the specified identity structure is encrypted.</para>
		/// </summary>
		/// <param name="EncryptedAuthData">
		/// <para>The identity structure to test.</para>
		/// </param>
		/// <returns>
		/// <para><c>TRUE</c> if the identity structure specified by the EncryptedAuthData parameter is encrypted; otherwise, <c>FALSE</c>.</para>
		/// </returns>
		// https://docs.microsoft.com/en-us/windows/desktop/api/sspi/nf-sspi-sspiisauthidentityencrypted BOOLEAN SEC_ENTRY
		// SspiIsAuthIdentityEncrypted( PSEC_WINNT_AUTH_IDENTITY_OPAQUE EncryptedAuthData );
		[DllImport(Lib.Secur32, SetLastError = false, ExactSpelling = true)]
		[PInvokeData("sspi.h", MSDNShortId = "b85095f5-0ca5-4d75-866d-9b756404c1d9")]
		[return: MarshalAs(UnmanagedType.U1)]
		public static extern bool SspiIsAuthIdentityEncrypted(PSEC_WINNT_AUTH_IDENTITY_OPAQUE EncryptedAuthData);

		/// <summary>
		/// <para>Frees the memory associated with the specified buffer.</para>
		/// </summary>
		/// <param name="DataBuffer">
		/// <para>The buffer to free.</para>
		/// </param>
		/// <returns>
		/// <para>This function does not return a value.</para>
		/// </returns>
		// https://docs.microsoft.com/en-us/windows/desktop/api/sspi/nf-sspi-sspilocalfree VOID SEC_ENTRY SspiLocalFree( PVOID DataBuffer );
		[DllImport(Lib.Secur32, SetLastError = false, ExactSpelling = true)]
		[PInvokeData("sspi.h", MSDNShortId = "afb890a8-a2c3-4c35-ba76-758b047ababb")]
		public static extern void SspiLocalFree(IntPtr DataBuffer);

		/// <summary>
		/// <para>Serializes the specified identity structure into a byte array.</para>
		/// </summary>
		/// <param name="AuthIdentity">
		/// <para>The identity structure to serialize.</para>
		/// </param>
		/// <param name="AuthIdentityLength">
		/// <para>The length, in bytes, of the AuthIdentityByteArray array.</para>
		/// </param>
		/// <param name="AuthIdentityByteArray">
		/// <para>A pointer to an array of byte values that represents the identity specified by the AuthIdentity parameter.</para>
		/// </param>
		/// <returns>
		/// <para>If the function succeeds, it returns <c>SEC_E_OK</c>.</para>
		/// <para>If the function fails, it returns a nonzero error code.</para>
		/// </returns>
		// https://docs.microsoft.com/en-us/windows/desktop/api/sspi/nf-sspi-sspimarshalauthidentity SECURITY_STATUS SEC_ENTRY
		// SspiMarshalAuthIdentity( PSEC_WINNT_AUTH_IDENTITY_OPAQUE AuthIdentity, unsigned long *AuthIdentityLength, char
		// **AuthIdentityByteArray );
		[DllImport(Lib.Secur32, SetLastError = false, ExactSpelling = true)]
		[PInvokeData("sspi.h", MSDNShortId = "e43135ad-7fcd-4da6-a4e4-c91c41eeb865")]
		public static extern Win32Error SspiMarshalAuthIdentity(PSEC_WINNT_AUTH_IDENTITY_OPAQUE AuthIdentity, out uint AuthIdentityLength, out SafeSspiLocalMem AuthIdentityByteArray);

		/// <summary>
		/// <para>Generates a target name and credential type from the specified identity structure.</para>
		/// <para>
		/// The values that this function generates can be passed as the values of the TargetName and Type parameters in a call to the
		/// CredRead function.
		/// </para>
		/// </summary>
		/// <param name="AuthIdentity">
		/// <para>The identity structure from which to generate the credentials to be passed to the CredRead function.</para>
		/// </param>
		/// <param name="pszTargetName">
		/// <para>A target name that can be modified by this function depending on the value of the AuthIdentity parameter.</para>
		/// </param>
		/// <param name="pCredmanCredentialType">
		/// <para>The credential type to pass to the CredRead function.</para>
		/// </param>
		/// <param name="ppszCredmanTargetName">
		/// <para>The target name to pass to the CredRead function.</para>
		/// </param>
		/// <returns>
		/// <para>If the function succeeds, it returns <c>SEC_E_OK</c>.</para>
		/// <para>If the function fails, it returns a nonzero error code.</para>
		/// </returns>
		// https://docs.microsoft.com/en-us/windows/desktop/api/sspi/nf-sspi-sspiprepareforcredread SECURITY_STATUS SEC_ENTRY
		// SspiPrepareForCredRead( PSEC_WINNT_AUTH_IDENTITY_OPAQUE AuthIdentity, PCWSTR pszTargetName, PULONG pCredmanCredentialType, PCWSTR
		// *ppszCredmanTargetName );
		[DllImport(Lib.Secur32, SetLastError = false, ExactSpelling = true, CharSet = CharSet.Unicode)]
		[PInvokeData("sspi.h", MSDNShortId = "f473fd7a-5c0f-4a77-829b-28a82ad0d28d")]
		public static extern Win32Error SspiPrepareForCredRead(PSEC_WINNT_AUTH_IDENTITY_OPAQUE AuthIdentity, string pszTargetName, out CRED_TYPE pCredmanCredentialType, out string ppszCredmanTargetName);

		/// <summary>
		/// <para>
		/// Generates values from an identity structure that can be passed as the values of parameters in a call to the CredWrite function.
		/// </para>
		/// </summary>
		/// <param name="AuthIdentity">
		/// <para>The identity structure from which to generate the credentials to be passed to the CredWrite function.</para>
		/// </param>
		/// <param name="pszTargetName">
		/// <para>A target name that can be modified by this function depending on the value of the AuthIdentity parameter.</para>
		/// <para>Set the value of this parameter to <c>NULL</c> to use the user name as the target.</para>
		/// </param>
		/// <param name="pCredmanCredentialType">
		/// <para>The credential type to pass to the CredWrite function.</para>
		/// </param>
		/// <param name="ppszCredmanTargetName">
		/// <para>The target name to pass to the CredWrite function.</para>
		/// </param>
		/// <param name="ppszCredmanUserName">
		/// <para>The user name to pass to the CredWrite function.</para>
		/// </param>
		/// <param name="ppCredentialBlob">
		/// <para>The credential BLOB to send to the CredWrite function.</para>
		/// </param>
		/// <param name="pCredentialBlobSize">
		/// <para>The size, in bytes, of the ppCredentialBlob buffer.</para>
		/// </param>
		/// <returns>
		/// <para>If the function succeeds, it returns <c>SEC_E_OK</c>.</para>
		/// <para>If the function fails, it returns a nonzero error code.</para>
		/// </returns>
		// https://docs.microsoft.com/en-us/windows/desktop/api/sspi/nf-sspi-sspiprepareforcredwrite SECURITY_STATUS SEC_ENTRY
		// SspiPrepareForCredWrite( PSEC_WINNT_AUTH_IDENTITY_OPAQUE AuthIdentity, PCWSTR pszTargetName, PULONG pCredmanCredentialType, PCWSTR
		// *ppszCredmanTargetName, PCWSTR *ppszCredmanUserName, PUCHAR *ppCredentialBlob, PULONG pCredentialBlobSize );
		[DllImport(Lib.Secur32, SetLastError = false, ExactSpelling = true, CharSet = CharSet.Unicode)]
		[PInvokeData("sspi.h", MSDNShortId = "4db92042-38f2-42c2-9c94-b24e0eaafdf9")]
		public static extern Win32Error SspiPrepareForCredWrite(PSEC_WINNT_AUTH_IDENTITY_OPAQUE AuthIdentity, string pszTargetName, out CRED_TYPE pCredmanCredentialType, out string ppszCredmanTargetName, out string ppszCredmanUserName,
			[Out, MarshalAs(UnmanagedType.LPArray, SizeParamIndex = 6)] out byte[] ppCredentialBlob, out uint pCredentialBlobSize);

		/// <summary>
		/// <para>Deserializes the specified array of byte values into an identity structure.</para>
		/// </summary>
		/// <param name="AuthIdentityLength">
		/// <para>The size, in bytes, of the AuthIdentityByteArray array.</para>
		/// </param>
		/// <param name="AuthIdentityByteArray">
		/// <para>The array of byte values to deserialize.</para>
		/// </param>
		/// <param name="ppAuthIdentity">
		/// <para>The deserialized identity structure.</para>
		/// </param>
		/// <returns>
		/// <para>If the function succeeds, it returns <c>SEC_E_OK</c>.</para>
		/// <para>If the function fails, it returns a nonzero error code.</para>
		/// </returns>
		// https://docs.microsoft.com/en-us/windows/desktop/api/sspi/nf-sspi-sspiunmarshalauthidentity SECURITY_STATUS SEC_ENTRY
		// SspiUnmarshalAuthIdentity( unsigned long AuthIdentityLength, char *AuthIdentityByteArray, PSEC_WINNT_AUTH_IDENTITY_OPAQUE
		// *ppAuthIdentity );
		[DllImport(Lib.Secur32, SetLastError = false, ExactSpelling = true)]
		[PInvokeData("sspi.h", MSDNShortId = "89798b37-808a-4174-8362-a2dc4ee1b460")]
		public static extern Win32Error SspiUnmarshalAuthIdentity(uint AuthIdentityLength, [In, MarshalAs(UnmanagedType.LPArray, SizeParamIndex = 0)] byte[] AuthIdentityByteArray, out SafePSEC_WINNT_AUTH_IDENTITY_OPAQUE ppAuthIdentity);

		/// <summary>
		/// <para>Indicates whether the specified identity structure is valid.</para>
		/// </summary>
		/// <param name="AuthData">
		/// <para>The identity structure to test.</para>
		/// </param>
		/// <returns>
		/// <para>
		/// If the function succeeds, it returns <c>SEC_E_OK</c>, which indicates that the identity structure specified by the AuthData
		/// parameter is valid.
		/// </para>
		/// <para>
		/// If the function fails, it returns a nonzero error code that indicates that the identity structure specified by the AuthData
		/// parameter is not valid.
		/// </para>
		/// </returns>
		// https://docs.microsoft.com/en-us/windows/desktop/api/sspi/nf-sspi-sspivalidateauthidentity SECURITY_STATUS SEC_ENTRY
		// SspiValidateAuthIdentity( PSEC_WINNT_AUTH_IDENTITY_OPAQUE AuthData );
		[DllImport(Lib.Secur32, SetLastError = false, ExactSpelling = true)]
		[PInvokeData("sspi.h", MSDNShortId = "82733abd-d984-4902-b6e4-c3809171ad51")]
		public static extern Win32Error SspiValidateAuthIdentity(PSEC_WINNT_AUTH_IDENTITY_OPAQUE AuthData);

		/// <summary>
		/// <para>Fills the block of memory associated with the specified identity structure with zeros.</para>
		/// </summary>
		/// <param name="AuthData">
		/// <para>The identity structure to fill with zeros.</para>
		/// </param>
		/// <returns>
		/// <para>If the function succeeds, it returns <c>SEC_E_OK</c>.</para>
		/// <para>If the function fails, it returns a nonzero error code.</para>
		/// </returns>
		// https://docs.microsoft.com/en-us/windows/desktop/api/sspi/nf-sspi-sspizeroauthidentity VOID SEC_ENTRY SspiZeroAuthIdentity(
		// PSEC_WINNT_AUTH_IDENTITY_OPAQUE AuthData );
		[DllImport(Lib.Secur32, SetLastError = false, ExactSpelling = true)]
		[PInvokeData("sspi.h", MSDNShortId = "50b1f24a-c802-4691-a450-316cb31bf44d")]
		public static extern void SspiZeroAuthIdentity(PSEC_WINNT_AUTH_IDENTITY_OPAQUE AuthData);

		/// <summary>
		/// Verifies that a message signed by using the MakeSignature function was received in the correct sequence and has not been modified.
		/// </summary>
		/// <param name="phContext">A handle to the security context to use for the message.</param>
		/// <param name="pMessage">
		/// Pointer to a SecBufferDesc structure that references a set of SecBuffer structures that contain the message and signature to
		/// verify. The signature is in a <c>SecBuffer</c> structure of type SECBUFFER_TOKEN.
		/// </param>
		/// <param name="MessageSeqNo">
		/// Specifies the sequence number expected by the transport application, if any. If the transport application does not maintain
		/// sequence numbers, this parameter is zero.
		/// </param>
		/// <param name="pfQOP">
		/// <para>Pointer to a <c>ULONG</c> variable that receives package-specific flags that indicate the quality of protection.</para>
		/// <para>Some security packages ignore this parameter.</para>
		/// </param>
		/// <returns>
		/// <para>
		/// If the function verifies that the message was received in the correct sequence and has not been modified, the return value is SEC_E_OK.
		/// </para>
		/// <para>
		/// If the function determines that the message is not correct according to the information in the signature, the return value can be
		/// one of the following error codes.
		/// </para>
		/// <list type="table">
		/// <listheader>
		/// <term>Return code</term>
		/// <term>Description</term>
		/// </listheader>
		/// <item>
		/// <term>SEC_E_OUT_OF_SEQUENCE</term>
		/// <term>The message was not received in the correct sequence.</term>
		/// </item>
		/// <item>
		/// <term>SEC_E_MESSAGE_ALTERED</term>
		/// <term>The message has been altered.</term>
		/// </item>
		/// <item>
		/// <term>SEC_E_INVALID_HANDLE</term>
		/// <term>The context handle specified by phContext is not valid.</term>
		/// </item>
		/// <item>
		/// <term>SEC_E_INVALID_TOKEN</term>
		/// <term>pMessage did not contain a valid SECBUFFER_TOKEN buffer, or contained too few buffers.</term>
		/// </item>
		/// <item>
		/// <term>SEC_E_QOP_NOT_SUPPORTED</term>
		/// <term>The quality of protection negotiated between the client and server did not include integrity checking.</term>
		/// </item>
		/// </list>
		/// </returns>
		/// <remarks>
		/// <c>Warning</c> The <c>VerifySignature</c> function will fail if the message was signed using the RsaSignPssSha512 algorithm on a
		/// different version of Windows. For example, a message that was signed by calling the MakeSignature function on Windows 8 will
		/// cause the <c>VerifySignature</c> function on Windows 8.1 to fail.
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows/desktop/api/sspi/nf-sspi-verifysignature KSECDDDECLSPEC SECURITY_STATUS SEC_ENTRY
		// VerifySignature( PCtxtHandle phContext, PSecBufferDesc pMessage, unsigned long MessageSeqNo, unsigned long *pfQOP );
		[DllImport(Lib.Secur32, SetLastError = false, ExactSpelling = true)]
		[PInvokeData("sspi.h", MSDNShortId = "bebeef92-1d6e-4879-846f-12d706db0653")]
		public static extern HRESULT VerifySignature(in CtxtHandle phContext, in SecBufferDesc pMessage, uint MessageSeqNo, out SECQOP pfQOP);

		/// <summary>Provides a handle to a auth identity.</summary>
		[StructLayout(LayoutKind.Sequential)]
		public struct PSEC_WINNT_AUTH_IDENTITY_OPAQUE : IHandle
		{
			private IntPtr handle;

			/// <summary>Initializes a new instance of the <see cref="PSEC_WINNT_AUTH_IDENTITY_OPAQUE"/> struct.</summary>
			/// <param name="preexistingHandle">An <see cref="IntPtr"/> object that represents the pre-existing handle to use.</param>
			public PSEC_WINNT_AUTH_IDENTITY_OPAQUE(IntPtr preexistingHandle) => handle = preexistingHandle;

			/// <summary>Returns an invalid handle by instantiating a <see cref="PSEC_WINNT_AUTH_IDENTITY_OPAQUE"/> object with <see cref="IntPtr.Zero"/>.</summary>
			public static PSEC_WINNT_AUTH_IDENTITY_OPAQUE NULL => new PSEC_WINNT_AUTH_IDENTITY_OPAQUE(IntPtr.Zero);

			/// <summary>Gets a value indicating whether this instance is a null handle.</summary>
			public bool IsNull => handle == IntPtr.Zero;

			/// <summary>Performs an explicit conversion from <see cref="PSEC_WINNT_AUTH_IDENTITY_OPAQUE"/> to <see cref="IntPtr"/>.</summary>
			/// <param name="h">The handle.</param>
			/// <returns>The result of the conversion.</returns>
			public static explicit operator IntPtr(PSEC_WINNT_AUTH_IDENTITY_OPAQUE h) => h.handle;

			/// <summary>Performs an implicit conversion from <see cref="IntPtr"/> to <see cref="PSEC_WINNT_AUTH_IDENTITY_OPAQUE"/>.</summary>
			/// <param name="h">The pointer to a handle.</param>
			/// <returns>The result of the conversion.</returns>
			public static implicit operator PSEC_WINNT_AUTH_IDENTITY_OPAQUE(IntPtr h) => new PSEC_WINNT_AUTH_IDENTITY_OPAQUE(h);

			/// <summary>Implements the operator !=.</summary>
			/// <param name="h1">The first handle.</param>
			/// <param name="h2">The second handle.</param>
			/// <returns>The result of the operator.</returns>
			public static bool operator !=(PSEC_WINNT_AUTH_IDENTITY_OPAQUE h1, PSEC_WINNT_AUTH_IDENTITY_OPAQUE h2) => !(h1 == h2);

			/// <summary>Implements the operator ==.</summary>
			/// <param name="h1">The first handle.</param>
			/// <param name="h2">The second handle.</param>
			/// <returns>The result of the operator.</returns>
			public static bool operator ==(PSEC_WINNT_AUTH_IDENTITY_OPAQUE h1, PSEC_WINNT_AUTH_IDENTITY_OPAQUE h2) => h1.Equals(h2);

			/// <inheritdoc/>
			public override bool Equals(object obj) => obj is PSEC_WINNT_AUTH_IDENTITY_OPAQUE h ? handle == h.handle : false;

			/// <inheritdoc/>
			public override int GetHashCode() => handle.GetHashCode();

			/// <inheritdoc/>
			public IntPtr DangerousGetHandle() => handle;
		}

		/// <summary>Allows you to pass a particular user name and password to the run-time library for the purpose of authentication.</summary>
		/// <remarks>
		/// <para>When this structure is used with RPC, the structure must remain valid for the lifetime of the binding handle.</para>
		/// <para>The strings may be ANSI or Unicode, depending on the value you assign to the <c>Flags</c> member.</para>
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows/desktop/api/sspi/ns-sspi-_sec_winnt_auth_identity_a typedef struct
		// _SEC_WINNT_AUTH_IDENTITY_A { unsigned char *User; unsigned long UserLength; unsigned char *Domain; unsigned long DomainLength;
		// unsigned char *Password; unsigned long PasswordLength; unsigned long Flags; } SEC_WINNT_AUTH_IDENTITY_A, *PSEC_WINNT_AUTH_IDENTITY_A;
		[PInvokeData("sspi.h", MSDNShortId = "a9c9471b-2134-4173-af86-18b277627d2a")]
		[StructLayout(LayoutKind.Sequential, CharSet = CharSet.Auto)]
		public struct SEC_WINNT_AUTH_IDENTITY
		{
			/// <summary>A string that contains the user name.</summary>
			[MarshalAs(UnmanagedType.LPTStr)]
			public string User;

			/// <summary>The length, in characters, of the user string, not including the terminating null character.</summary>
			public int UserLength;

			/// <summary>A string that contains the domain name or the workgroup name.</summary>
			[MarshalAs(UnmanagedType.LPTStr)]
			public string Domain;

			/// <summary>The length, in characters, of the domain string, not including the terminating null character.</summary>
			public int DomainLength;

			/// <summary>
			/// A string that contains the password of the user in the domain or workgroup. When you have finished using the password, remove
			/// the sensitive information from memory by calling SecureZeroMemory. For more information about protecting the password, see
			/// Handling Passwords.
			/// </summary>
			[MarshalAs(UnmanagedType.LPTStr)]
			public string Password;

			/// <summary>The length, in characters, of the password string, not including the terminating null character.</summary>
			public int PasswordLength;

			/// <summary>
			/// <para>This member can be one of the following values.</para>
			/// <list type="table">
			/// <listheader>
			/// <term>Value</term>
			/// <term>Meaning</term>
			/// </listheader>
			/// <item>
			/// <term>SEC_WINNT_AUTH_IDENTITY_ANSI</term>
			/// <term>The strings in this structure are in ANSI format.</term>
			/// </item>
			/// <item>
			/// <term>SEC_WINNT_AUTH_IDENTITY_UNICODE</term>
			/// <term>The strings in this structure are in Unicode format.</term>
			/// </item>
			/// </list>
			/// </summary>
			public int Flags;

			/// <summary>Initializes a new instance of the <see cref="SEC_WINNT_AUTH_IDENTITY"/> struct.</summary>
			/// <param name="user">The user name.</param>
			/// <param name="domain">The domain name or the workgroup name.</param>
			/// <param name="password">The password of the user in the domain or workgroup.</param>
			public SEC_WINNT_AUTH_IDENTITY(string user, string domain, string password)
			{
				User = user;
				UserLength = user?.Length ?? 0;
				Domain = domain;
				DomainLength = domain?.Length ?? 0;
				Password = password;
				PasswordLength = password?.Length ?? 0;
				Flags = StringHelper.GetCharSize();
			}
		}

		/// <summary>
		/// The <c>SEC_WINNT_AUTH_IDENTITY_EX</c> structure contains information about a user. Both an ANSI and Unicode form of this
		/// structure are provided.
		/// </summary>
		/// <remarks>
		/// Note that when this structure is used with RPC, the structure must remain valid for the lifetime of the binding handle.
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows/desktop/api/sspi/ns-sspi-_sec_winnt_auth_identity_exa typedef struct
		// _SEC_WINNT_AUTH_IDENTITY_EXA { unsigned long Version; unsigned long Length; unsigned char *User; unsigned long UserLength;
		// unsigned char *Domain; unsigned long DomainLength; unsigned char *Password; unsigned long PasswordLength; unsigned long Flags;
		// unsigned char *PackageList; unsigned long PackageListLength; } SEC_WINNT_AUTH_IDENTITY_EXA, *PSEC_WINNT_AUTH_IDENTITY_EXA;
		[PInvokeData("sspi.h", MSDNShortId = "6b95bce8-5613-4403-9bda-16262596bb1b")]
		[StructLayout(LayoutKind.Sequential, CharSet = CharSet.Auto)]
		public struct SEC_WINNT_AUTH_IDENTITY_EX
		{
			/// <summary>An unsigned long that indicates the version number of the structure.</summary>
			public uint Version;

			/// <summary>An unsigned long that indicates the length, in bytes, of the structure.</summary>
			public uint Length;

			/// <summary>A Unicode or ANSI string that contains the name of the user account.</summary>
			[MarshalAs(UnmanagedType.LPTStr)]
			public string User;

			/// <summary>The length, in characters, of the <c>User</c> string.</summary>
			public uint UserLength;

			/// <summary>A Unicode or ANSI string that contains the name of the domain for the user account.</summary>
			[MarshalAs(UnmanagedType.LPTStr)]
			public string Domain;

			/// <summary>The length, in characters, of the <c>Domain</c> string.</summary>
			public uint DomainLength;

			/// <summary>
			/// A Unicode or ANSI string that contains the user password in plaintext. When you have finished using the password, remove the
			/// sensitive information from memory by calling the SecureZeroMemory function. For more information about protecting the
			/// password, see Handling Passwords.
			/// </summary>
			[MarshalAs(UnmanagedType.LPTStr)]
			public string Password;

			/// <summary>The length, in characters, of the <c>Password</c> string.</summary>
			public uint PasswordLength;

			/// <summary>
			/// <para>An unsigned long flag that indicates the type used by negotiable security packages.</para>
			/// <list type="table">
			/// <listheader>
			/// <term>Value</term>
			/// <term>Meaning</term>
			/// </listheader>
			/// <item>
			/// <term>SEC_WINNT_AUTH_IDENTITY_MARSHALLED</term>
			/// <term>All data is in one buffer.</term>
			/// </item>
			/// <item>
			/// <term>SEC_WINNT_AUTH_IDENTITY_ONLY</term>
			/// <term>
			/// Used with the Kerberos security support provider (SSP). Credentials are for identity only. The Kerberos package is directed
			/// to not include authorization data in the ticket.
			/// </term>
			/// </item>
			/// <item>
			/// <term>SEC_WINNT_AUTH_IDENTITY_ANSI</term>
			/// <term>Credentials are in ANSI form.</term>
			/// </item>
			/// <item>
			/// <term>SEC_WINNT_AUTH_IDENTITY_UNICODE</term>
			/// <term>Credentials are in Unicode form.</term>
			/// </item>
			/// </list>
			/// </summary>
			public SEC_WINNT_AUTH_IDENTITY_FLAGS Flags;

			/// <summary>
			/// <para>
			/// A Unicode or ANSI string that contains a comma-separated list of names of security packages that are available when using the
			/// Microsoft Negotiate provider.
			/// </para>
			/// <para>Set this to "!ntlm" to specify that the NTLM package is not to be used.</para>
			/// </summary>
			[MarshalAs(UnmanagedType.LPTStr)]
			public string PackageList;

			/// <summary>The length, in characters, of the <c>PackageList</c> string.</summary>
			public uint PackageListLength;
		}

		/// <summary>
		/// Contains information about an authentication identity. The <c>SEC_WINNT_AUTH_IDENTITY_EX2</c> structure contains authentication
		/// data that is provided to the AcquireCredentialsHandle function.
		/// </summary>
		/// <remarks>
		/// <para>
		/// This authentication identity buffer can be returned from several credential APIs, for example, the GetSerialization method and
		/// the CredUIPromptForWindowsCredential and SspiPromptForCredentials functions.
		/// </para>
		/// <para>
		/// The structure describes a header of the authentication identity buffer and the data is appended at the end of the structure.
		/// Although the buffer size is specified by the <c>cbStructureLength</c> member, the actual buffer size can be larger or smaller
		/// than <c>cbStructureLength</c>. Some functions, such as SspiValidateAuthIdentity, take a pointer, but not the buffer size, to the
		/// identity structure as input. As a result, those functions can validate the internal buffer data but cannot verify the buffer
		/// size. This can result in reading or writing data outside of the buffer range. To avoid buffer overruns when handling an untrusted
		/// identity buffer, applications should call SspiUnmarshalAuthIdentity to obtain a pointer to an identity structure with a validated
		/// size and then pass that pointer to the functions.
		/// </para>
		/// <para>
		/// The <c>SEC_WINNT_AUTH_IDENTITY_EX2</c> structure can be returned by QueryContextAttributes(CredSSP) and consumed by
		/// AcquireCredentialsHandle(CredSSP), LsaLogonUser, and other identity provider interfaces.
		/// </para>
		/// <para>
		/// SEC_WINNT_AUTH_PACKED_CREDENTIALS can contain a password credential type, defined as SEC_WINNT_AUTH_DATA_TYPE_PASSWORD. This
		/// credential type describes password credentials of a domain user as well as other online identities. Applications must define
		/// _SEC_WINNT_AUTH_TYPES to compile code that references this credential type as well as other definitions of the
		/// <c>SEC_WINNT_AUTH_PACKED_CREDENTIALS</c> structure.
		/// </para>
		/// <para>
		/// Applications should not query or set the <c>Flags</c> member directly. Use the SspiIsAuthIdentityEncrypted,
		/// SspiEncryptAuthIdentityEx, and SspiDecryptAuthIdentityEx functions to manage the encryption and decryption of the
		/// <c>SEC_WINNT_AUTH_IDENTITY_EX2</c> structure.
		/// </para>
		/// <para>
		/// Identity providers must explicitly check or set SEC_WINNT_AUTH_IDENTITY_FLAGS_ID_PROVIDER and the domain name fields to
		/// differentiate their password credential from a domain password and another identity provider's password.
		/// </para>
		/// <para>
		/// The CredPackAuthenticationBuffer function can be called with the CRED_PACK_ID_PROVIDER_CREDENTIALS option to create a
		/// <c>SEC_WINNT_AUTH_IDENTITY_EX2</c> structure with the authentication data of SEC_WINNT_AUTH_DATA_TYPE_PASSWORD credential type, a
		/// <c>Flags</c> member that contains the SEC_WINNT_AUTH_IDENTITY_FLAGS_ID_PROVIDER value, and a <c>DomainOffset</c> member set to
		/// the provider name.
		/// </para>
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows/desktop/api/sspi/ns-sspi-sec_winnt_auth_identity_ex2 typedef struct
		// _SEC_WINNT_AUTH_IDENTITY_EX2 { unsigned long Version; unsigned short cbHeaderLength; unsigned long cbStructureLength; unsigned
		// long UserOffset; unsigned short UserLength; unsigned long DomainOffset; unsigned short DomainLength; unsigned long
		// PackedCredentialsOffset; unsigned short PackedCredentialsLength; unsigned long Flags; unsigned long PackageListOffset; unsigned
		// short PackageListLength; } SEC_WINNT_AUTH_IDENTITY_EX2, *PSEC_WINNT_AUTH_IDENTITY_EX2;
		[PInvokeData("sspi.h", MSDNShortId = "a6083d76-1774-428c-85ca-fea817827d6a")]
		[StructLayout(LayoutKind.Sequential, CharSet = CharSet.Auto)]
		public struct SEC_WINNT_AUTH_IDENTITY_EX2
		{
			/// <summary>The version number of the structure. This must be <c>SEC_WINNT_AUTH_IDENTITY_VERSION_2</c>.</summary>
			public uint Version;

			/// <summary>The size, in bytes, of the structure header.</summary>
			public ushort cbHeaderLength;

			/// <summary>The size, in bytes, of the structure.</summary>
			public uint cbStructureLength;

			/// <summary>The offset from the beginning of the structure to the beginning of the user name string.</summary>
			public uint UserOffset;

			/// <summary>The size, in bytes, of the user name string.</summary>
			public ushort UserLength;

			/// <summary>
			/// <para>The offset from the beginning of the structure to the beginning of the domain name string.</para>
			/// <para>An identity credential should contain the identity provider name instead of the domain name.</para>
			/// </summary>
			public uint DomainOffset;

			/// <summary>The size, in bytes, of the domain name string.</summary>
			public ushort DomainLength;

			/// <summary>
			/// <para>The offset from the beginning of the structure to the beginning of the packed credentials.</para>
			/// <para>
			/// The packed credential is a SEC_WINNT_AUTH_PACKED_CREDENTIALS structure that contains a credential type that uniquely
			/// specifies the credential type.
			/// </para>
			/// </summary>
			public uint PackedCredentialsOffset;

			/// <summary>The size, in bytes, of the packed credentials string.</summary>
			public ushort PackedCredentialsLength;

			/// <summary>
			/// <para>An <c>unsigned long</c> flag that indicates the type used by negotiable security packages.</para>
			/// <list type="table">
			/// <listheader>
			/// <term>Value</term>
			/// <term>Meaning</term>
			/// </listheader>
			/// <item>
			/// <term>SEC_WINNT_AUTH_IDENTITY_MARSHALLED 4 (0x4)</term>
			/// <term>All data is in one buffer.</term>
			/// </item>
			/// <item>
			/// <term>SEC_WINNT_AUTH_IDENTITY_ONLY 8 (0x8)</term>
			/// <term>
			/// Used with the Kerberos security support provider (SSP). Credentials are for identity only. The Kerberos package is directed
			/// to not include authorization data in the ticket.
			/// </term>
			/// </item>
			/// <item>
			/// <term>SEC_WINNT_AUTH_IDENTITY_ANSI 1 (0x1)</term>
			/// <term>Credentials are in ANSI form.</term>
			/// </item>
			/// <item>
			/// <term>SEC_WINNT_AUTH_IDENTITY_UNICODE 2 (0x2)</term>
			/// <term>Credentials are in Unicode form.</term>
			/// </item>
			/// <item>
			/// <term>SEC_WINNT_AUTH_IDENTITY_FLAGS_ID_PROVIDER 524288 (0x80000)</term>
			/// <term>
			/// When the credential type is password, the presence of this flag specifies that the structure is an online ID credential. The
			/// DomainOffset and DomainLength members correspond to the online ID provider name. Windows Server 2008 R2 and Windows 7: This
			/// flag is not supported.
			/// </term>
			/// </item>
			/// <item>
			/// <term>SEC_WINNT_AUTH_IDENTITY_FLAGS_PROCESS_ENCRYPTED 16 (0x10)</term>
			/// <term>
			/// The structure is encrypted by the SspiEncryptAuthIdentity function or by the SspiEncryptAuthIdentityEx function with the
			/// SEC_WINNT_AUTH_IDENTITY_ENCRYPT_SAME_PROCESS option. It can only be decrypted by the same process. Windows Server 2008 R2 and
			/// Windows 7: This flag is not supported.
			/// </term>
			/// </item>
			/// <item>
			/// <term>SEC_WINNT_AUTH_IDENTITY_FLAGS_SYSTEM_PROTECTED 32 (0x20)</term>
			/// <term>
			/// The structure is encrypted by the SspiEncryptAuthIdentityEx function with the SEC_WINNT_AUTH_IDENTITY_ENCRYPT_SAME_LOGON
			/// option under the SYSTEM security context. It can only be decrypted by a thread running as SYSTEM. Windows Server 2008 R2 and
			/// Windows 7: This flag is not supported.
			/// </term>
			/// </item>
			/// <item>
			/// <term>SEC_WINNT_AUTH_IDENTITY_FLAGS_USER_PROTECTED 64 (0x40)</term>
			/// <term>
			/// The structure is encrypted by the SspiEncryptAuthIdentityEx function with the SEC_WINNT_AUTH_IDENTITY_ENCRYPT_SAME_LOGON
			/// option under a non-SYSTEM security context. It can only be decrypted by a thread running in the same logon session in which
			/// it was encrypted. Windows Server 2008 R2 and Windows 7: This flag is not supported.
			/// </term>
			/// </item>
			/// <item>
			/// <term>SEC_WINNT_AUTH_IDENTITY_FLAGS_RESERVED 65536 (0x10000)</term>
			/// <term>
			/// The authentication identity buffer is cbStructureLength + 8 padding bytes that are necessary for in-place encryption or
			/// decryption of the identity.
			/// </term>
			/// </item>
			/// </list>
			/// </summary>
			public SEC_WINNT_AUTH_IDENTITY_FLAGS Flags;

			/// <summary>The offset from the beginning of the structure to the beginning of the list of supported packages.</summary>
			public uint PackageListOffset;

			/// <summary>The size, in bytes, of the supported package list.</summary>
			public ushort PackageListLength;
		}

		/// <summary>The SecBuffer structure describes a buffer allocated by a transport application to pass to a security package.</summary>
		[StructLayout(LayoutKind.Sequential)]
		public struct SecBuffer
		{
			/// <summary>Specifies the size, in bytes, of the buffer pointed to by the pvBuffer member.</summary>
			public int cbBuffer;

			/// <summary>Bit flags that indicate the type of buffer. Must be one of the values of the SecBufferType enumeration.</summary>
			public SecBufferType BufferType;

			/// <summary>A pointer to a buffer.</summary>
			public IntPtr pvBuffer;

			/// <summary>Initializes a new instance of the <see cref="SecBuffer"/> struct.</summary>
			/// <param name="type">The type of buffer.</param>
			/// <param name="buffer">A pointer to an allocated buffer.</param>
			/// <param name="bufferSize">Size of the allocated buffer.</param>
			public SecBuffer(SecBufferType type, IntPtr buffer = default, int bufferSize = 0)
			{
				cbBuffer = bufferSize;
				BufferType = type;
				pvBuffer = buffer;
			}
		}

		/// <summary>
		/// The <c>SecBufferDesc</c> structure describes an array of SecBuffer structures to pass from a transport application to a security package.
		/// </summary>
		// https://docs.microsoft.com/en-us/windows/desktop/api/sspi/ns-sspi-_secbufferdesc typedef struct _SecBufferDesc { unsigned long
		// ulVersion; unsigned long cBuffers; PSecBuffer pBuffers; } SecBufferDesc, *PSecBufferDesc;
		[PInvokeData("sspi.h", MSDNShortId = "fc6ef09c-3ba9-4bcb-a3c2-07422af8eaa9")]
		[StructLayout(LayoutKind.Sequential)]
		public struct SecBufferDesc
		{
			/// <summary>Current structure version.</summary>
			public const uint SECBUFFER_VERSION = 0;

			/// <summary>
			/// <para>Specifies the version number of this structure. This member must be SECBUFFER_VERSION.</para>
			/// </summary>
			public uint ulVersion;

			/// <summary>
			/// <para>Indicates the number of SecBuffer structures in the <c>pBuffers</c> array.</para>
			/// </summary>
			public uint cBuffers;

			/// <summary>
			/// <para>Pointer to an array of SecBuffer structures.</para>
			/// </summary>
			public IntPtr pBuffers;

			/// <summary>The default structure with the ulVersion field set correctly.</summary>
			public static readonly SecBufferDesc Default = new SecBufferDesc { ulVersion = SECBUFFER_VERSION };
		}

		/// <summary>A security handle.</summary>
		[PInvokeData("sspi.h")]
		[StructLayout(LayoutKind.Sequential)]
		public struct CredHandle : IEquatable<CredHandle>
		{
			/// <summary>Represents the invalid handle value.</summary>
			public static readonly CredHandle Invalid = new CredHandle() { dwLower = UIntPtr.Zero, dwUpper = MaxValue };

			/// <summary>Represents a NULL handle value.</summary>
			public static readonly CredHandle Null = new CredHandle();

			/// <summary>Lower value.</summary>
			public UIntPtr dwLower;

			/// <summary>Upper value.</summary>
			public UIntPtr dwUpper;

			private static readonly UIntPtr MaxValue = UIntPtr.Size == 4 ? new UIntPtr(uint.MaxValue) : new UIntPtr(ulong.MaxValue);

			/// <summary>Gets a value indicating whether this instance is invalid.</summary>
			/// <value><c>true</c> if this instance is invalid; otherwise, <c>false</c>.</value>
			public bool IsInvalid => dwLower == MaxValue || dwUpper == MaxValue;

			/// <summary>Gets a value indicating whether this instance is NULL.</summary>
			/// <value><c>true</c> if this instance is NULL; otherwise, <c>false</c>.</value>
			public bool IsNull => dwLower == UIntPtr.Zero && dwUpper == UIntPtr.Zero;

			/// <summary>Implements the operator !=.</summary>
			/// <param name="value1">The left value.</param>
			/// <param name="value2">The right value.</param>
			/// <returns>The result of the operator.</returns>
			public static bool operator !=(CredHandle value1, CredHandle value2) => !value1.Equals(value2);

			/// <summary>Implements the operator ==.</summary>
			/// <param name="value1">The left value.</param>
			/// <param name="value2">The right value.</param>
			/// <returns>The result of the operator.</returns>
			public static bool operator ==(CredHandle value1, CredHandle value2) => value1.Equals(value2);

			/// <summary>Indicates whether the current object is equal to another object of the same type.</summary>
			/// <param name="other">An object to compare with this object.</param>
			/// <returns>true if the current object is equal to the <paramref name="other"/> parameter; otherwise, false.</returns>
			public bool Equals(CredHandle other) => other.dwUpper == dwUpper && other.dwLower == dwLower;

			/// <summary>Determines whether the specified <see cref="object"/>, is equal to this instance.</summary>
			/// <param name="obj">The <see cref="object"/> to compare with this instance.</param>
			/// <returns><c>true</c> if the specified <see cref="object"/> is equal to this instance; otherwise, <c>false</c>.</returns>
			public override bool Equals(object obj) => obj is CredHandle h ? Equals(h) : base.Equals(obj);

			/// <summary>Returns a hash code for this instance.</summary>
			/// <returns>A hash code for this instance, suitable for use in hashing algorithms and data structures like a hash table.</returns>
			public override int GetHashCode() => base.GetHashCode();

			/// <summary>Invalidates this instance.</summary>
			public void Invalidate() { dwLower = UIntPtr.Zero; dwUpper = MaxValue; }
		}

		/// <summary>A security handle.</summary>
		[PInvokeData("sspi.h")]
		[StructLayout(LayoutKind.Sequential)]
		public struct CtxtHandle : IEquatable<CtxtHandle>
		{
			/// <summary>Represents the invalid handle value.</summary>
			public static readonly CtxtHandle Invalid = new CtxtHandle() { dwLower = UIntPtr.Zero, dwUpper = MaxValue };

			/// <summary>Represents a NULL handle value.</summary>
			public static readonly CtxtHandle Null = new CtxtHandle();

			/// <summary>Lower value.</summary>`
			public UIntPtr dwLower;

			/// <summary>Upper value.</summary>
			public UIntPtr dwUpper;

			private static readonly UIntPtr MaxValue = UIntPtr.Size == 4 ? new UIntPtr(uint.MaxValue) : new UIntPtr(ulong.MaxValue);

			/// <summary>Gets a value indicating whether this instance is invalid.</summary>
			/// <value><c>true</c> if this instance is invalid; otherwise, <c>false</c>.</value>
			public bool IsInvalid => dwLower == MaxValue || dwUpper == MaxValue;

			/// <summary>Gets a value indicating whether this instance is NULL.</summary>
			/// <value><c>true</c> if this instance is NULL; otherwise, <c>false</c>.</value>
			public bool IsNull => dwLower == UIntPtr.Zero && dwUpper == UIntPtr.Zero;

			/// <summary>Implements the operator !=.</summary>
			/// <param name="value1">The left value.</param>
			/// <param name="value2">The right value.</param>
			/// <returns>The result of the operator.</returns>
			public static bool operator !=(CtxtHandle value1, CtxtHandle value2) => !value1.Equals(value2);

			/// <summary>Implements the operator ==.</summary>
			/// <param name="value1">The left value.</param>
			/// <param name="value2">The right value.</param>
			/// <returns>The result of the operator.</returns>
			public static bool operator ==(CtxtHandle value1, CtxtHandle value2) => value1.Equals(value2);

			/// <summary>Indicates whether the current object is equal to another object of the same type.</summary>
			/// <param name="other">An object to compare with this object.</param>
			/// <returns>true if the current object is equal to the <paramref name="other"/> parameter; otherwise, false.</returns>
			public bool Equals(CtxtHandle other) => other.dwUpper == dwUpper && other.dwLower == dwLower;

			/// <summary>Determines whether the specified <see cref="object"/>, is equal to this instance.</summary>
			/// <param name="obj">The <see cref="object"/> to compare with this instance.</param>
			/// <returns><c>true</c> if the specified <see cref="object"/> is equal to this instance; otherwise, <c>false</c>.</returns>
			public override bool Equals(object obj) => obj is CtxtHandle h ? Equals(h) : base.Equals(obj);

			/// <summary>Returns a hash code for this instance.</summary>
			/// <returns>A hash code for this instance, suitable for use in hashing algorithms and data structures like a hash table.</returns>
			public override int GetHashCode() => base.GetHashCode();

			/// <summary>Invalidates this instance.</summary>
			public void Invalidate() { dwLower = UIntPtr.Zero; dwUpper = MaxValue; }
		}

		/// <summary>
		/// The <c>SecPkgContext_AccessToken</c> structure returns a handle to the access token for the current security context. The
		/// returned handle can be used by the ImpersonateLoggedOnUser and GetTokenInformation functions. This structure is returned by the
		/// QueryContextAttributes (General) function.
		/// </summary>
		// https://docs.microsoft.com/en-us/windows/desktop/api/sspi/ns-sspi-_secpkgcontext_accesstoken typedef struct
		// _SecPkgContext_AccessToken { void *AccessToken; } SecPkgContext_AccessToken, *PSecPkgContext_AccessToken;
		[PInvokeData("sspi.h", MSDNShortId = "4dc11cbd-7f28-4cb9-aaea-6e5a89ac91f0")]
		[StructLayout(LayoutKind.Sequential)]
		public struct SecPkgContext_AccessToken
		{
			/// <summary>
			/// <para>Pointer to a <c>void</c> that receives the handle to the access token that represents the authenticated user.</para>
			/// <para>The returned handle is not duplicated, so the calling process must not call CloseHandle on the returned handle.</para>
			/// <para>
			/// If the security context is for a server or is incomplete, the returned handle may be <c>NULL</c>. Depending on the security
			/// package, QueryContextAttributes (General) may return SEC_E_NO_IMPERSONATION for these cases.
			/// </para>
			/// </summary>
			public IntPtr AccessToken;
		}

		/// <summary>
		/// The <c>SecPkgContext_Authority</c> structure contains the name of the authenticating authority if one is available. It can be a
		/// certification authority (CA) or the name of a server or domain that authenticated the connection. The QueryContextAttributes
		/// (General) function uses this structure.
		/// </summary>
		// https://docs.microsoft.com/en-us/windows/desktop/api/sspi/ns-sspi-_secpkgcontext_authoritya typedef struct
		// _SecPkgContext_AuthorityA { SEC_CHAR *sAuthorityName; } SecPkgContext_AuthorityA, *PSecPkgContext_AuthorityA;
		[PInvokeData("sspi.h", MSDNShortId = "619bf16b-c439-48e7-b013-3622e2f3bbc4")]
		[StructLayout(LayoutKind.Sequential, CharSet = CharSet.Auto)]
		public struct SecPkgContext_Authority
		{
			/// <summary>Pointer to a null-terminated string containing the name of the authenticating authority, if available.</summary>
			[MarshalAs(UnmanagedType.LPTStr)]
			public string sAuthorityName;
		}

		/// <summary>Specifies a structure that contains channel binding information for a security context.</summary>
		// https://docs.microsoft.com/en-us/windows/desktop/api/sspi/ns-sspi-_secpkgcontext_bindings typedef struct _SecPkgContext_Bindings {
		// unsigned long BindingsLength; SEC_CHANNEL_BINDINGS *Bindings; } SecPkgContext_Bindings, *PSecPkgContext_Bindings;
		[PInvokeData("sspi.h", MSDNShortId = "6823cc31-acd3-4d67-92c6-65ff4d1c6aed")]
		[StructLayout(LayoutKind.Sequential)]
		public struct SecPkgContext_Bindings
		{
			/// <summary>The size, in bytes, of the structure specified by the <c>Bindings</c> member</summary>
			public uint BindingsLength;

			/// <summary>A pointer to a SEC_CHANNEL_BINDINGS structure that specifies channel binding information.</summary>
			public IntPtr Bindings;
		}

		/// <summary>
		/// The <c>SecPkgContext_ClientSpecifiedTarget</c> structure specifies the service principal name (SPN) of the initial target when
		/// calling the QueryContextAttributes (Digest) function.
		/// </summary>
		// https://docs.microsoft.com/en-us/windows/desktop/api/sspi/ns-sspi-_secpkgcontext_clientspecifiedtarget typedef struct
		// _SecPkgContext_ClientSpecifiedTarget { SEC_WCHAR *sTargetName; } SecPkgContext_ClientSpecifiedTarget, *PSecPkgContext_ClientSpecifiedTarget;
		[PInvokeData("sspi.h", MSDNShortId = "67536f69-a1fc-4f26-84dc-872635bafa3b")]
		[StructLayout(LayoutKind.Sequential)]
		public struct SecPkgContext_ClientSpecifiedTarget
		{
			/// <summary>The SPN of the initial target.</summary>
			[MarshalAs(UnmanagedType.LPWStr)]
			public string sTargetName;
		}

		/// <summary>Specifies the type of credentials used to create a client context.</summary>
		// https://docs.microsoft.com/en-us/windows/desktop/api/sspi/ns-sspi-_secpkgcontext_credinfo typedef struct _SecPkgContext_CredInfo {
		// SECPKG_CRED_CLASS CredClass; unsigned long IsPromptingNeeded; } SecPkgContext_CredInfo, *PSecPkgContext_CredInfo;
		[PInvokeData("sspi.h", MSDNShortId = "5c2c6d01-5de3-4dd1-9fa2-cce9eadd6902")]
		[StructLayout(LayoutKind.Sequential)]
		public struct SecPkgContext_CredInfo
		{
			/// <summary>A value of the SECPKG_CRED_CLASS enumeration that indicates the type of credentials.</summary>
			public SECPKG_CRED_CLASS CredClass;

			/// <summary>
			/// A nonzero value indicates that the application must prompt the user for credentials. All other values indicate that the
			/// application does not need to prompt the user.
			/// </summary>
			[MarshalAs(UnmanagedType.Bool)]
			public bool IsPromptingNeeded;
		}

		/// <summary>
		/// The <c>SecPkgContext_DceInfo</c> structure contains authorization data used by DCE services. The QueryContextAttributes (General)
		/// function uses this structure.
		/// </summary>
		// https://docs.microsoft.com/en-us/windows/desktop/api/sspi/ns-sspi-_secpkgcontext_dceinfo typedef struct _SecPkgContext_DceInfo {
		// unsigned long AuthzSvc; void *pPac; } SecPkgContext_DceInfo, *PSecPkgContext_DceInfo;
		[PInvokeData("sspi.h", MSDNShortId = "490688d0-efdd-4a40-88b9-eb53ff592d2a")]
		[StructLayout(LayoutKind.Sequential)]
		public struct SecPkgContext_DceInfo
		{
			/// <summary>Specifies the authorization service used. For DCE use only.</summary>
			public uint AuthzSvc;

			/// <summary>Pointer to package-specific authorization data.</summary>
			public IntPtr pPac;
		}

		/// <summary>
		/// The <c>SecPkgContext_Flags</c> structure contains information about the flags in the current security context. This structure is
		/// returned by QueryContextAttributes (General).
		/// </summary>
		// https://docs.microsoft.com/en-us/windows/desktop/api/sspi/ns-sspi-secpkgcontext_flags typedef struct _SecPkgContext_Flags {
		// unsigned long Flags; } SecPkgContext_Flags, *PSecPkgContext_Flags;
		[PInvokeData("sspi.h", MSDNShortId = "0be0e945-4048-4748-a9fd-15d08fb7ff3e")]
		[StructLayout(LayoutKind.Sequential)]
		public struct SecPkgContext_Flags
		{
			/// <summary>
			/// Flag values for the current security context. These values correspond to the flags negotiated by the
			/// InitializeSecurityContext (General) and AcceptSecurityContext (General) functions.
			/// </summary>
			public uint Flags;
		}

		/// <summary>
		/// <para>
		/// The <c>SecPkgContext_KeyInfo</c> structure contains information about the session keys used in a security context. The
		/// QueryContextAttributes (General) function uses this structure.
		/// </para>
		/// <para>
		/// Applications using the Schannel security support provider (SSP) should not use the <c>SecPkgContext_KeyInfo</c> structure.
		/// Instead, use the SecPkgContext_ConnectionInfo structure.
		/// </para>
		/// </summary>
		// https://docs.microsoft.com/en-us/windows/desktop/api/sspi/ns-sspi-_secpkgcontext_keyinfoa typedef struct _SecPkgContext_KeyInfoA {
		// SEC_CHAR *sSignatureAlgorithmName; SEC_CHAR *sEncryptAlgorithmName; unsigned long KeySize; unsigned long SignatureAlgorithm;
		// unsigned long EncryptAlgorithm; } SecPkgContext_KeyInfoA, *PSecPkgContext_KeyInfoA;
		[PInvokeData("sspi.h", MSDNShortId = "ec146329-6789-460c-ae62-629a1765a4c1")]
		[StructLayout(LayoutKind.Sequential, CharSet = CharSet.Auto)]
		public struct SecPkgContext_KeyInfo
		{
			/// <summary>
			/// Pointer to a null-terminated string that contains the name, if available, of the algorithm used for generating signatures,
			/// for example "MD5" or "SHA-2".
			/// </summary>
			[MarshalAs(UnmanagedType.LPTStr)]
			public string sSignatureAlgorithmName;

			/// <summary>
			/// Pointer to a null-terminated string that contains the name, if available, of the algorithm used for encrypting messages.
			/// Reserved for future use.
			/// </summary>
			[MarshalAs(UnmanagedType.LPTStr)]
			public string sEncryptAlgorithmName;

			/// <summary>Specifies the effective key length, in bits, for the session key. This is typically 40, 56, or 128 bits.</summary>
			public uint KeySize;

			/// <summary>Specifies the algorithm identifier (ALG_ID) used for generating signatures, if available.</summary>
			public ALG_ID SignatureAlgorithm;

			/// <summary>Specifies the algorithm identifier (ALG_ID) used for encrypting messages. Reserved for future use.</summary>
			public ALG_ID EncryptAlgorithm;
		}

		/// <summary>
		/// Specifies whether the token from the most recent call to the InitializeSecurityContext function is the last token from the client.
		/// </summary>
		// https://docs.microsoft.com/en-us/windows/desktop/api/sspi/ns-sspi-_secpkgcontext_lastclienttokenstatus typedef struct
		// _SecPkgContext_LastClientTokenStatus { SECPKG_ATTR_LCT_STATUS LastClientTokenStatus; } SecPkgContext_LastClientTokenStatus, *PSecPkgContext_LastClientTokenStatus;
		[PInvokeData("sspi.h", MSDNShortId = "ccb2bb4e-3c65-4305-95ad-b9111f3936b5")]
		[StructLayout(LayoutKind.Sequential)]
		public struct SecPkgContext_LastClientTokenStatus
		{
			/// <summary>
			/// A value of the SECPKG_ATTR_LCT_STATUS enumeration that indicates the status of the token returned by the most recent call to InitializeSecurityContext.
			/// </summary>
			public SECPKG_ATTR_LCT_STATUS LastClientTokenStatus;
		}

		/// <summary>
		/// The <c>SecPkgContext_Lifespan</c> structure indicates the life span of a security context. The QueryContextAttributes (General)
		/// function uses this structure.
		/// </summary>
		/// <remarks>It is recommended that the security package always return these values in local time.</remarks>
		// https://docs.microsoft.com/en-us/windows/desktop/api/sspi/ns-sspi-_secpkgcontext_lifespan typedef struct _SecPkgContext_Lifespan {
		// TimeStamp tsStart; TimeStamp tsExpiry; } SecPkgContext_Lifespan, *PSecPkgContext_Lifespan;
		[PInvokeData("sspi.h", MSDNShortId = "7ef45795-f6af-4dac-a498-c6f8c915a168")]
		[StructLayout(LayoutKind.Sequential)]
		public struct SecPkgContext_Lifespan
		{
			/// <summary>Time at which the context was established.</summary>
			public TimeStamp tsStart;

			/// <summary>Time at which the context will expire.</summary>
			public TimeStamp tsExpiry;
		}

		/// <summary>
		/// The <c>SecPkgContext_Names</c> structure indicates the name of the user associated with a security context. The
		/// QueryContextAttributes (General) function uses this structure.
		/// </summary>
		// https://docs.microsoft.com/en-us/windows/desktop/api/sspi/ns-sspi-_secpkgcontext_namesa typedef struct _SecPkgContext_NamesA {
		// SEC_CHAR *sUserName; } SecPkgContext_NamesA, *PSecPkgContext_NamesA;
		[PInvokeData("sspi.h", MSDNShortId = "9df0bf7c-ad5f-4cb8-8934-76062789735f")]
		[StructLayout(LayoutKind.Sequential, CharSet = CharSet.Auto)]
		public struct SecPkgContext_Names
		{
			/// <summary>
			/// Pointer to a null-terminated string containing the name of the user represented by the context. If the security package has
			/// set the SECPKG_FLAG_ACCEPT_WIN32_NAME flag, this name can be used in other Windows calls.
			/// </summary>
			[MarshalAs(UnmanagedType.LPTStr)]
			public string sUserName;
		}

		/// <summary>
		/// The <c>SecPkgContext_NativeNames</c> structure returns the client and server principal names from the outbound ticket. This
		/// structure is valid only for client outbound tickets. This structure is returned by QueryContextAttributes (General).
		/// </summary>
		// https://docs.microsoft.com/en-us/windows/desktop/api/sspi/ns-sspi-_secpkgcontext_nativenamesa typedef struct
		// _SecPkgContext_NativeNamesA { SEC_CHAR *sClientName; SEC_CHAR *sServerName; } SecPkgContext_NativeNamesA, *PSecPkgContext_NativeNamesA;
		[PInvokeData("sspi.h", MSDNShortId = "f935093f-5661-4ced-94f1-c4b21c3b9f69")]
		[StructLayout(LayoutKind.Sequential, CharSet = CharSet.Auto)]
		public struct SecPkgContext_NativeNames
		{
			/// <summary>
			/// Pointer to a null-terminated string that represents the principal name for the client in the outbound ticket. This string
			/// should never be <c>NULL</c> when querying a security context negotiated with Kerberos.
			/// </summary>
			[MarshalAs(UnmanagedType.LPTStr)]
			public string sClientName;

			/// <summary>
			/// Pointer to a null-terminated string that represents the principal name for the server in the outbound ticket. This string
			/// should never be <c>NULL</c> when querying a security context negotiated with Kerberos.
			/// </summary>
			[MarshalAs(UnmanagedType.LPTStr)]
			public string sServerName;
		}

		/// <summary>Specifies the error status of the last attempt to create a client context.</summary>
		// https://docs.microsoft.com/en-us/windows/desktop/api/sspi/ns-sspi-_secpkgcontext_negostatus typedef struct
		// _SecPkgContext_NegoStatus { unsigned long LastStatus; } SecPkgContext_NegoStatus, *PSecPkgContext_NegoStatus;
		[PInvokeData("sspi.h", MSDNShortId = "09201338-4743-44a2-b84f-35b26116976d")]
		[StructLayout(LayoutKind.Sequential)]
		public struct SecPkgContext_NegoStatus
		{
			/// <summary>The error status of the last attempt to create a client context.</summary>
			public uint LastStatus;
		}

		/// <summary>
		/// The <c>SecPkgContext_NegotiationInfo</c> structure contains information on the security package that is being set up or has been
		/// set up, and also gives the status on the negotiation to set up the security package.
		/// </summary>
		// https://docs.microsoft.com/en-us/windows/desktop/api/sspi/ns-sspi-_secpkgcontext_negotiationinfoa typedef struct
		// _SecPkgContext_NegotiationInfoA { PSecPkgInfoA PackageInfo; unsigned long NegotiationState; } SecPkgContext_NegotiationInfoA, *PSecPkgContext_NegotiationInfoA;
		[PInvokeData("sspi.h", MSDNShortId = "3af724b8-fbe5-4a75-b128-9efe65381f2f")]
		[StructLayout(LayoutKind.Sequential, CharSet = CharSet.Auto)]
		public struct SecPkgContext_NegotiationInfo
		{
			/// <summary>
			/// Pointer to a SecPkgInfo structure that provides general information about the security package chosen in the negotiate
			/// process, such as the name and capabilities of the package.
			/// </summary>
			public IntPtr PackageInfo;

			/// <summary>
			/// <para>
			/// Indicator of the state of the negotiation for the security package identified in the <c>PackageInfo</c> member. This
			/// attribute can be queried from the context handle before the setup is complete, such as when ISC returns SEC_I_CONTINUE_NEEDED.
			/// </para>
			/// <para>The following table shows values returned in this member.</para>
			/// <list type="table">
			/// <listheader>
			/// <term>Value</term>
			/// <term>Meaning</term>
			/// </listheader>
			/// <item>
			/// <term>SECPKG_NEGOTIATION_COMPLETE</term>
			/// <term>Negotiation has been completed.</term>
			/// </item>
			/// <item>
			/// <term>SECPKG_NEGOTIATION_OPTIMISTIC</term>
			/// <term>Negotiations not yet completed.</term>
			/// </item>
			/// <item>
			/// <term>SECPKG_NEGOTIATION_IN_PROGRESS</term>
			/// <term>Negotiations in progress.</term>
			/// </item>
			/// </list>
			/// </summary>
			public uint NegotiationState;
		}

		/// <summary>
		/// The <c>SecPkgContext_PackageInfo</c> structure contains the name of a security support provider (SSP). This structure is returned
		/// by the QueryContextAttributes (General) function. It would most often be used when the SSP in use was established using the
		/// Negotiate security package.
		/// </summary>
		// https://docs.microsoft.com/en-us/windows/desktop/api/sspi/ns-sspi-_secpkgcontext_packageinfoa typedef struct
		// _SecPkgContext_PackageInfoA { PSecPkgInfoA PackageInfo; } SecPkgContext_PackageInfoA, *PSecPkgContext_PackageInfoA;
		[PInvokeData("sspi.h", MSDNShortId = "94c21f22-d974-4ae5-beef-d4567e6ea7e1")]
		[StructLayout(LayoutKind.Sequential, CharSet = CharSet.Auto)]
		public struct SecPkgContext_PackageInfo
		{
			/// <summary>Pointer to a SecPkgInfo structure containing the name of the SSP in use.</summary>
			public IntPtr PackageInfo;
		}

		/// <summary>
		/// The <c>SecPkgContext_PasswordExpiry</c> structure contains information about the expiration of a password or other credential
		/// used for the security context. This structure is returned by QueryContextAttributes (General).
		/// </summary>
		// https://docs.microsoft.com/en-us/windows/desktop/api/sspi/ns-sspi-secpkgcontext_passwordexpiry typedef struct
		// _SecPkgContext_PasswordExpiry { TimeStamp tsPasswordExpires; } SecPkgContext_PasswordExpiry, *PSecPkgContext_PasswordExpiry;
		[PInvokeData("sspi.h", MSDNShortId = "f45dde88-1520-4e65-8fae-8407dfaa0850")]
		[StructLayout(LayoutKind.Sequential)]
		public struct SecPkgContext_PasswordExpiry
		{
			/// <summary>
			/// A TimeStamp variable that indicates when the credentials for the security context expire. For password-based packages, this
			/// variable indicates when the password expires. For Kerberos, this variable indicates when the ticket expires.
			/// </summary>
			public TimeStamp tsPasswordExpires;
		}

		/// <summary>
		/// <para>
		/// [The <c>SecPkgContext_ProtoInfo</c> structure is available for use in the operating systems specified in the Requirements
		/// section. It may be altered or unavailable in subsequent versions. Instead, use the SecPkgContext_ConnectionInfo structure.]
		/// </para>
		/// <para>The <c>SecPkgContext_ProtoInfo</c> structure holds information about the protocol in use.</para>
		/// <para>This attribute is supported only by the Schannel security support provider (SSP).</para>
		/// </summary>
		// https://docs.microsoft.com/en-us/windows/desktop/api/sspi/ns-sspi-secpkgcontext_protoinfoa typedef struct
		// _SecPkgContext_ProtoInfoA { SEC_CHAR *sProtocolName; unsigned long majorVersion; unsigned long minorVersion; }
		// SecPkgContext_ProtoInfoA, *PSecPkgContext_ProtoInfoA;
		[PInvokeData("sspi.h", MSDNShortId = "c10eb1fc-b957-4853-86c1-070749488bb9")]
		[StructLayout(LayoutKind.Sequential, CharSet = CharSet.Auto)]
		public struct SecPkgContext_ProtoInfo
		{
			/// <summary>Pointer to a string containing the name of the protocol.</summary>
			[MarshalAs(UnmanagedType.LPTStr)]
			public string sProtocolName;

			/// <summary>Major version number.</summary>
			public uint majorVersion;

			/// <summary>Minor version number.</summary>
			public uint minorVersion;
		}

		/// <summary>
		/// The <c>SecPkgContext_SessionKey</c> structure contains information about the session key used for the security context. This
		/// structure is returned by the QueryContextAttributes (General) function.
		/// </summary>
		// https://docs.microsoft.com/en-us/windows/desktop/api/sspi/ns-sspi-_secpkgcontext_sessionkey typedef struct
		// _SecPkgContext_SessionKey { unsigned long SessionKeyLength; unsigned char *SessionKey; } SecPkgContext_SessionKey, *PSecPkgContext_SessionKey;
		[PInvokeData("sspi.h", MSDNShortId = "88cf437e-3be0-4f12-9058-ad078deed6a1")]
		[StructLayout(LayoutKind.Sequential)]
		public struct SecPkgContext_SessionKey
		{
			/// <summary>Size, in bytes, of the session key.</summary>
			public uint SessionKeyLength;

			/// <summary>The session key for the security context.</summary>
			public IntPtr SessionKey;
		}

		/// <summary>
		/// The <c>SecPkgContext_Sizes</c> structure indicates the sizes of important structures used in the message support functions. The
		/// QueryContextAttributes (General) function uses this structure.
		/// </summary>
		// https://docs.microsoft.com/en-us/windows/desktop/api/sspi/ns-sspi-_secpkgcontext_sizes typedef struct _SecPkgContext_Sizes {
		// unsigned long cbMaxToken; unsigned long cbMaxSignature; unsigned long cbBlockSize; unsigned long cbSecurityTrailer; }
		// SecPkgContext_Sizes, *PSecPkgContext_Sizes;
		[PInvokeData("sspi.h", MSDNShortId = "46b6a155-8855-4aa0-a513-aa5b3760fcd4")]
		[StructLayout(LayoutKind.Sequential)]
		public struct SecPkgContext_Sizes
		{
			/// <summary>Specifies the maximum size of the security token used in the authentication exchanges.</summary>
			public uint cbMaxToken;

			/// <summary>
			/// Specifies the maximum size of the signature created by the MakeSignature function. This member must be zero if integrity
			/// services are not requested or available.
			/// </summary>
			public uint cbMaxSignature;

			/// <summary>
			/// Specifies the preferred integral size of the messages. For example, eight indicates that messages should be of size zero mod
			/// eight for optimal performance. Messages other than this block size can be padded.
			/// </summary>
			public uint cbBlockSize;

			/// <summary>
			/// Size of the security trailer to be appended to messages. This member should be zero if the relevant services are not
			/// requested or available.
			/// </summary>
			public uint cbSecurityTrailer;
		}

		/// <summary>
		/// The <c>SecPkgContext_StreamSizes</c> structure indicates the sizes of the various parts of a stream for use with the message
		/// support functions. The QueryContextAttributes (General) function uses this structure.
		/// </summary>
		/// <remarks>
		/// Applications calling EncryptMessage (General) should check the values of the <c>cbHeader</c>, <c>cbTrailer</c>, and
		/// <c>cbMaximumMessage</c> members to determine the size of the encrypted packet.
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows/desktop/api/sspi/ns-sspi-_secpkgcontext_streamsizes typedef struct
		// _SecPkgContext_StreamSizes { unsigned long cbHeader; unsigned long cbTrailer; unsigned long cbMaximumMessage; unsigned long
		// cBuffers; unsigned long cbBlockSize; } SecPkgContext_StreamSizes, *PSecPkgContext_StreamSizes;
		[PInvokeData("sspi.h", MSDNShortId = "75e5fc96-56cc-4713-a34f-fca687798ad6")]
		[StructLayout(LayoutKind.Sequential)]
		public struct SecPkgContext_StreamSizes
		{
			/// <summary>Specifies the size, in bytes, of the header portion. If zero, no header is used.</summary>
			public uint cbHeader;

			/// <summary>Specifies the maximum size, in bytes, of the trailer portion. If zero, no trailer is used.</summary>
			public uint cbTrailer;

			/// <summary>Specifies the size, in bytes, of the largest message that can be encapsulated.</summary>
			public uint cbMaximumMessage;

			/// <summary>Specifies the number of buffers to pass.</summary>
			public uint cBuffers;

			/// <summary>
			/// Specifies the preferred integral size of the messages. For example, eight indicates that messages should be of size zero mod
			/// eight for optimal performance. Messages other than this block size can be padded.
			/// </summary>
			public uint cbBlockSize;
		}

		/// <summary>The <c>SecPkgContext_SubjectAttributes</c> structure returns the security attribute information.</summary>
		// https://docs.microsoft.com/en-us/windows/desktop/api/sspi/ns-sspi-_secpkgcontext_subjectattributes typedef struct
		// _SecPkgContext_SubjectAttributes { void *AttributeInfo; } SecPkgContext_SubjectAttributes, *PSecPkgContext_SubjectAttributes;
		[PInvokeData("sspi.h", MSDNShortId = "548E972F-EB94-4BBD-94F2-FA38184D179A")]
		[StructLayout(LayoutKind.Sequential)]
		public struct SecPkgContext_SubjectAttributes
		{
			/// <summary>
			/// Pointer to a <c>void</c> that receives the attribute information stored in a AUTHZ_SECURITY_ATTRIBUTES_INFORMATION structure.
			/// </summary>
			public IntPtr AttributeInfo;
		}

		/// <summary>
		/// The <c>SecPkgContext_TargetInformation</c> structure returns information about the credential used for the security context. This
		/// structure is returned by the QueryContextAttributes (General) function.
		/// </summary>
		// https://docs.microsoft.com/en-us/windows/desktop/api/sspi/ns-sspi-secpkgcontext_targetinformation typedef struct
		// _SecPkgContext_TargetInformation { unsigned long MarshalledTargetInfoLength; unsigned char *MarshalledTargetInfo; }
		// SecPkgContext_TargetInformation, *PSecPkgContext_TargetInformation;
		[PInvokeData("sspi.h", MSDNShortId = "8a5a6bd6-8678-4544-a631-5ee4347bc685")]
		[StructLayout(LayoutKind.Sequential)]
		public struct SecPkgContext_TargetInformation
		{
			/// <summary>Size, in bytes, of <c>MarshalledTargetInfo</c>.</summary>
			public uint MarshalledTargetInfoLength;

			/// <summary>Array of bytes that represent the credential, if a credential is provided by a credential manager.</summary>
			public IntPtr MarshalledTargetInfo;
		}

		/// <summary>Specifies the certificate credentials. The QueryCredentialsAttributes function uses this structure.</summary>
		// https://docs.microsoft.com/en-us/windows/desktop/api/sspi/ns-sspi-_secpkgcredentials_cert typedef struct _SecPkgCredentials_Cert {
		// unsigned long EncodedCertSize; unsigned char *EncodedCert; } SecPkgCredentials_Cert, *PSecPkgCredentials_Cert;
		[PInvokeData("sspi.h", MSDNShortId = "9EEE6E98-D45C-4929-9C9C-F344972D186F")]
		[StructLayout(LayoutKind.Sequential)]
		public struct SecPkgCredentials_Cert
		{
			/// <summary>Size of the encoded certificate.</summary>
			public uint EncodedCertSize;

			/// <summary>The encoded certificate.</summary>
			public IntPtr EncodedCert;
		}

		/// <summary>Specifies the Kerberos proxy settings for the credentials.</summary>
		// https://docs.microsoft.com/en-us/windows/desktop/api/sspi/ns-sspi-_secpkgcredentials_kdcproxysettingsw typedef struct
		// _SecPkgCredentials_KdcProxySettingsW { ULONG Version; ULONG Flags; USHORT ProxyServerOffset; USHORT ProxyServerLength; USHORT
		// ClientTlsCredOffset; USHORT ClientTlsCredLength; } SecPkgCredentials_KdcProxySettingsW, *PSecPkgCredentials_KdcProxySettingsW;
		[PInvokeData("sspi.h", MSDNShortId = "42BC75B8-6392-4FD4-95BC-266B3AFDDC62")]
		[StructLayout(LayoutKind.Sequential, CharSet = CharSet.Unicode)]
		public struct SecPkgCredentials_KdcProxySettingsW
		{
			/// <summary>Version for the Kerberos proxy settings where KDC_PROXY_SETTINGS_V1 is defined as 1.</summary>
			public uint Version;

			/// <summary>Flags for the Kerberos proxy settings.</summary>
			public uint Flags;

			/// <summary>The offset of the proxy server. This member is optional.</summary>
			public ushort ProxyServerOffset;

			/// <summary>Length of the proxy server.</summary>
			public ushort ProxyServerLength;

			/// <summary>The offset of the client credentials. This member is optional.</summary>
			public ushort ClientTlsCredOffset;

			/// <summary>Length of the client credentials.</summary>
			public ushort ClientTlsCredLength;
		}

		/// <summary>
		/// The <c>SecPkgCredentials_Names</c> structure holds the name of the user associated with a context. The QueryCredentialsAttributes
		/// function uses this structure.
		/// </summary>
		// https://docs.microsoft.com/en-us/windows/desktop/api/sspi/ns-sspi-_secpkgcredentials_namesa typedef struct
		// _SecPkgCredentials_NamesA { SEC_CHAR *sUserName; } SecPkgCredentials_NamesA, *PSecPkgCredentials_NamesA;
		[PInvokeData("sspi.h", MSDNShortId = "38123a10-72a4-46eb-974b-3c01142dfc74")]
		[StructLayout(LayoutKind.Sequential, CharSet = CharSet.Auto)]
		public struct SecPkgCredentials_Names
		{
			/// <summary>
			/// Pointer to a null-terminated string containing the name of the user represented by the credential. If the security package
			/// sets the SECPKG_FLAG_ACCEPT_WIN32_NAME flag to indicate that it can process Windows names, this name can be used in other
			/// Windows calls.
			/// </summary>
			[MarshalAs(UnmanagedType.LPTStr)]
			public string sUserName;
		}

		/// <summary>
		/// The <c>SecPkgCredentials_SSIProvider</c> structure holds the SSI provider information associated with a context. The
		/// QueryCredentialsAttributes function uses this structure.
		/// </summary>
		// https://docs.microsoft.com/en-us/windows/desktop/api/sspi/ns-sspi-secpkgcredentials_ssiprovidera typedef struct
		// _SecPkgCredentials_SSIProviderA { SEC_CHAR *sProviderName; unsigned long ProviderInfoLength; char *ProviderInfo; }
		// SecPkgCredentials_SSIProviderA, *PSecPkgCredentials_SSIProviderA;
		[PInvokeData("sspi.h", MSDNShortId = "0C6D6217-3A97-40B5-A7FB-B9D49C5FBC7C")]
		[StructLayout(LayoutKind.Sequential, CharSet = CharSet.Auto)]
		public struct SecPkgCredentials_SSIProvider
		{
			/// <summary>Pointer to a null-terminated string that contains the name of the provider represented by the credential.</summary>
			[MarshalAs(UnmanagedType.LPTStr)]
			public string sProviderName;

			/// <summary>Length of the provider information.</summary>
			public uint ProviderInfoLength;

			/// <summary>The provider information.</summary>
			public IntPtr ProviderInfo;
		}

		/// <summary>The <c>SecPkgInfo</c> structure provides general information about a security package, such as its name and capabilities.</summary>
		// https://docs.microsoft.com/en-us/windows/desktop/api/sspi/ns-sspi-_secpkginfoa typedef struct _SecPkgInfoA { unsigned long
		// fCapabilities; unsigned short wVersion; unsigned short wRPCID; unsigned long cbMaxToken; SEC_CHAR *Name; SEC_CHAR *Comment; }
		// SecPkgInfoA, *PSecPkgInfoA;
		[PInvokeData("sspi.h", MSDNShortId = "d0bff3d8-63f1-4a4e-851f-177040af6bd2")]
		[StructLayout(LayoutKind.Sequential, CharSet = CharSet.Auto)]
		public struct SecPkgInfo
		{
			/// <summary>
			/// <para>
			/// Set of bit flags that describes the capabilities of the security package. This member can be a combination of the following flags.
			/// </para>
			/// <list type="table">
			/// <listheader>
			/// <term>Value</term>
			/// <term>Meaning</term>
			/// </listheader>
			/// <item>
			/// <term>SECPKG_FLAG_INTEGRITY 0x1</term>
			/// <term>The security package supports the MakeSignature and VerifySignature functions.</term>
			/// </item>
			/// <item>
			/// <term>SECPKG_FLAG_PRIVACY 0x2</term>
			/// <term>The security package supports the EncryptMessage (General) and DecryptMessage (General) functions.</term>
			/// </item>
			/// <item>
			/// <term>SECPKG_FLAG_TOKEN_ONLY 0x4</term>
			/// <term>
			/// The package is interested only in the security-token portion of messages, and will ignore any other buffers. This is a
			/// performance-related issue.
			/// </term>
			/// </item>
			/// <item>
			/// <term>SECPKG_FLAG_DATAGRAM 0x8</term>
			/// <term>Supports datagram-style authentication. For more information, see SSPI Context Semantics.</term>
			/// </item>
			/// <item>
			/// <term>SECPKG_FLAG_CONNECTION 0x10</term>
			/// <term>Supports connection-oriented style authentication. For more information, see SSPI Context Semantics.</term>
			/// </item>
			/// <item>
			/// <term>SECPKG_FLAG_MULTI_REQUIRED 0x20</term>
			/// <term>Multiple legs are required for authentication.</term>
			/// </item>
			/// <item>
			/// <term>SECPKG_FLAG_CLIENT_ONLY 0x40</term>
			/// <term>Server authentication support is not provided.</term>
			/// </item>
			/// <item>
			/// <term>SECPKG_FLAG_EXTENDED_ERROR 0x80</term>
			/// <term>Supports extended error handling. For more information, see Extended Error Information.</term>
			/// </item>
			/// <item>
			/// <term>SECPKG_FLAG_IMPERSONATION 0x100</term>
			/// <term>Supports Windows impersonation in server contexts.</term>
			/// </item>
			/// <item>
			/// <term>SECPKG_FLAG_ACCEPT_WIN32_NAME 0x200</term>
			/// <term>Understands Windows principal and target names.</term>
			/// </item>
			/// <item>
			/// <term>SECPKG_FLAG_STREAM 0x400</term>
			/// <term>Supports stream semantics. For more information, see SSPI Context Semantics.</term>
			/// </item>
			/// <item>
			/// <term>SECPKG_FLAG_NEGOTIABLE 0X800</term>
			/// <term>Can be used by the Microsoft Negotiate security package.</term>
			/// </item>
			/// <item>
			/// <term>SECPKG_FLAG_GSS_COMPATIBLE 0x1000</term>
			/// <term>Supports GSS compatibility.</term>
			/// </item>
			/// <item>
			/// <term>SECPKG_FLAG_LOGON 0x2000</term>
			/// <term>Supports LsaLogonUser.</term>
			/// </item>
			/// <item>
			/// <term>SECPKG_FLAG_ASCII_BUFFERS 0x4000</term>
			/// <term>Token buffers are in ASCII characters format.</term>
			/// </item>
			/// <item>
			/// <term>SECPKG_FLAG_FRAGMENT 0x8000</term>
			/// <term>
			/// Supports separating large tokens into smaller buffers so that applications can make repeated calls to
			/// InitializeSecurityContext (General) and AcceptSecurityContext (General) with the smaller buffers to complete authentication.
			/// </term>
			/// </item>
			/// <item>
			/// <term>SECPKG_FLAG_MUTUAL_AUTH 0x10000</term>
			/// <term>Supports mutual authentication.</term>
			/// </item>
			/// <item>
			/// <term>SECPKG_FLAG_DELEGATION 0x20000</term>
			/// <term>Supports delegation.</term>
			/// </item>
			/// <item>
			/// <term>SECPKG_FLAG_READONLY_WITH_CHECKSUM 0x40000</term>
			/// <term>The security package supports using a checksum instead of in-place encryption when calling the EncryptMessage function.</term>
			/// </item>
			/// <item>
			/// <term>SECPKG_FLAG_RESTRICTED_TOKENS 0x80000</term>
			/// <term>Supports callers with restricted tokens.</term>
			/// </item>
			/// <item>
			/// <term>SECPKG_FLAG_NEGO_EXTENDER 0x00100000</term>
			/// <term>The security package extends the Microsoft Negotiate security package. There can be at most one package of this type.</term>
			/// </item>
			/// <item>
			/// <term>SECPKG_FLAG_NEGOTIABLE2 0x00200000</term>
			/// <term>This package is negotiated by the package of type SECPKG_FLAG_NEGO_EXTENDER.</term>
			/// </item>
			/// <item>
			/// <term>SECPKG_FLAG_APPCONTAINER_PASSTHROUGH 0x00400000</term>
			/// <term>This package receives all calls from app container apps.</term>
			/// </item>
			/// <item>
			/// <term>SECPKG_FLAG_APPCONTAINER_CHECKS 0x00800000</term>
			/// <term>This package receives calls from app container apps if one of the following checks succeeds.</term>
			/// </item>
			/// <item>
			/// <term>SECPKG_CALLFLAGS_APPCONTAINER 0x00000001</term>
			/// <term>The caller is an app container.</term>
			/// </item>
			/// <item>
			/// <term>SECPKG_CALLFLAGS_AUTHCAPABLE 0x00000002</term>
			/// <term>The caller can use default credentials.</term>
			/// </item>
			/// <item>
			/// <term>SECPKG_CALLFLAGS_FORCE_SUPPLIED 0x00000004</term>
			/// <term>The caller can only use supplied credentials.</term>
			/// </item>
			/// </list>
			/// </summary>
			public SECPKG_FLAG fCapabilities;

			/// <summary>Specifies the version of the package protocol. Must be 1.</summary>
			public ushort wVersion;

			/// <summary>
			/// Specifies a DCE RPC identifier, if appropriate. If the package does not implement one of the DCE registered security systems,
			/// the reserved value SECPKG_ID_NONE is used.
			/// </summary>
			public ushort wRPCID;

			/// <summary>Specifies the maximum size, in bytes, of the token.</summary>
			public uint cbMaxToken;

			/// <summary>Pointer to a null-terminated string that contains the name of the security package.</summary>
			[MarshalAs(UnmanagedType.LPTStr)]
			public string Name;

			/// <summary>Pointer to a null-terminated string. This can be any additional string passed back by the package.</summary>
			[MarshalAs(UnmanagedType.LPTStr)]
			public string Comment;
		}

		/// <summary>Specifies information about a security package. This structure is used by the AddSecurityPackage function.</summary>
		// https://docs.microsoft.com/en-us/windows/desktop/api/sspi/ns-sspi-security_package_options typedef struct
		// _SECURITY_PACKAGE_OPTIONS { unsigned long Size; unsigned long Type; unsigned long Flags; unsigned long SignatureSize; void
		// *Signature; } SECURITY_PACKAGE_OPTIONS, *PSECURITY_PACKAGE_OPTIONS;
		[PInvokeData("sspi.h", MSDNShortId = "2e9f65ec-72a5-4d6f-aa63-f83369f0dd07")]
		[StructLayout(LayoutKind.Sequential, CharSet = CharSet.Auto)]
		public struct SECURITY_PACKAGE_OPTIONS
		{
			/// <summary>The size, in bytes, of this structure.</summary>
			public uint Size;

			/// <summary>
			/// <para>The type of security package. This can be one of the following values.</para>
			/// <list type="table">
			/// <listheader>
			/// <term>Value</term>
			/// <term>Meaning</term>
			/// </listheader>
			/// <item>
			/// <term>SECPKG_OPTIONS_TYPE_UNKNOWN 0</term>
			/// <term>The package type is not known.</term>
			/// </item>
			/// <item>
			/// <term>SECPKG_OPTIONS_TYPE_LSA 1</term>
			/// <term>The security package is an LSA authentication package.</term>
			/// </item>
			/// <item>
			/// <term>SECPKG_OPTIONS_TYPE_SSPI 2</term>
			/// <term>The security package is a Security Support Provider Interface (SSPI) package.</term>
			/// </item>
			/// </list>
			/// </summary>
			public SECPKG_OPTIONS_TYPE Type;

			/// <summary>This member is reserved. Do not use it.</summary>
			public uint Flags;

			/// <summary>The size, in bytes, of a digital signature for this security package.</summary>
			public uint SignatureSize;

			/// <summary>A digital signature for this security package.</summary>
			public IntPtr Signature;
		}

		/// <summary>
		/// The <c>SecurityFunctionTable</c> structure is a dispatch table that contains pointers to the functions defined in SSPI.
		/// </summary>
		// https://docs.microsoft.com/en-us/windows/desktop/api/sspi/ns-sspi-_security_function_table_w typedef struct
		// _SECURITY_FUNCTION_TABLE_W { unsigned long dwVersion; ENUMERATE_SECURITY_PACKAGES_FN_W EnumerateSecurityPackagesW;
		// QUERY_CREDENTIALS_ATTRIBUTES_FN_W QueryCredentialsAttributesW; ACQUIRE_CREDENTIALS_HANDLE_FN_W AcquireCredentialsHandleW;
		// FREE_CREDENTIALS_HANDLE_FN FreeCredentialsHandle; void *Reserved2; INITIALIZE_SECURITY_CONTEXT_FN_W InitializeSecurityContextW;
		// ACCEPT_SECURITY_CONTEXT_FN AcceptSecurityContext; COMPLETE_AUTH_TOKEN_FN CompleteAuthToken; DELETE_SECURITY_CONTEXT_FN
		// DeleteSecurityContext; APPLY_CONTROL_TOKEN_FN ApplyControlToken; QUERY_CONTEXT_ATTRIBUTES_FN_W QueryContextAttributesW;
		// IMPERSONATE_SECURITY_CONTEXT_FN ImpersonateSecurityContext; REVERT_SECURITY_CONTEXT_FN RevertSecurityContext; MAKE_SIGNATURE_FN
		// MakeSignature; VERIFY_SIGNATURE_FN VerifySignature; FREE_CONTEXT_BUFFER_FN FreeContextBuffer; QUERY_SECURITY_PACKAGE_INFO_FN_W
		// QuerySecurityPackageInfoW; void *Reserved3; void *Reserved4; EXPORT_SECURITY_CONTEXT_FN ExportSecurityContext;
		// IMPORT_SECURITY_CONTEXT_FN_W ImportSecurityContextW; ADD_CREDENTIALS_FN_W AddCredentialsW; void *Reserved8;
		// QUERY_SECURITY_CONTEXT_TOKEN_FN QuerySecurityContextToken; ENCRYPT_MESSAGE_FN EncryptMessage; DECRYPT_MESSAGE_FN DecryptMessage;
		// SET_CONTEXT_ATTRIBUTES_FN_W SetContextAttributesW; SET_CREDENTIALS_ATTRIBUTES_FN_W SetCredentialsAttributesW; CHANGE_PASSWORD_FN_W
		// ChangeAccountPasswordW; void *Reserved9; QUERY_CONTEXT_ATTRIBUTES_EX_FN_W QueryContextAttributesExW;
		// QUERY_CREDENTIALS_ATTRIBUTES_EX_FN_W QueryCredentialsAttributesExW; } SecurityFunctionTableW, *PSecurityFunctionTableW;
		[PInvokeData("sspi.h", MSDNShortId = "6315e8d6-b40a-4dd6-b6a6-598a965f93dc")]
		[StructLayout(LayoutKind.Sequential, CharSet = CharSet.Auto)]
		public struct SecurityFunctionTable
		{
			/// <summary>Version number of the table.</summary>
			public uint dwVersion;

			/// <summary>Pointer to the EnumerateSecurityPackages function.</summary>
			public IntPtr EnumerateSecurityPackages;

			/// <summary>Pointer to the QueryCredentialsAttributes function.</summary>
			public IntPtr QueryCredentialsAttributes;

			/// <summary>Pointer to the AcquireCredentialsHandle function.</summary>
			public IntPtr AcquireCredentialsHandle;

			/// <summary>Pointer to the FreeCredentialsHandle function.</summary>
			public IntPtr FreeCredentialHandl;

			/// <summary>Reserved for future use.</summary>
			public IntPtr Reserved1;

			/// <summary>Pointer to the InitializeSecurityContext (General) function.</summary>
			public IntPtr InitializeSecurityContext;

			/// <summary>Pointer to the AcceptSecurityContext (General) function.</summary>
			public IntPtr AcceptSecurityContex;

			/// <summary>Pointer to the CompleteAuthToken function.</summary>
			public IntPtr CompleteAuthToke;

			/// <summary>Pointer to the DeleteSecurityContext function.</summary>
			public IntPtr DeleteSecurityContex;

			/// <summary>Pointer to the ApplyControlToken function.</summary>
			public IntPtr ApplyControlToke;

			/// <summary>Pointer to the QueryContextAttributes (General) function.</summary>
			public IntPtr QueryContextAttributes;

			/// <summary>Pointer to the ImpersonateSecurityContext function.</summary>
			public IntPtr ImpersonateSecurityContex;

			/// <summary>Pointer to the RevertSecurityContext function.</summary>
			public IntPtr RevertSecurityContex;

			/// <summary>Pointer to the MakeSignature function.</summary>
			public IntPtr MakeSignatur;

			/// <summary>Pointer to the VerifySignature function.</summary>
			public IntPtr VerifySignatur;

			/// <summary>Pointer to the FreeContextBuffer function.</summary>
			public IntPtr FreeContextBuffe;

			/// <summary>Pointer to the QuerySecurityPackageInfo function.</summary>
			public IntPtr QuerySecurityPackageInfo;

			/// <summary>Reserved for future use.</summary>
			public IntPtr Reserved2;

			/// <summary>Reserved for future use.</summary>
			public IntPtr Reserved3;

			/// <summary>Pointer to the ExportSecurityContext function.</summary>
			public IntPtr ExportSecurityContex;

			/// <summary>Pointer to the ImportSecurityContext function.</summary>
			public IntPtr ImportSecurityContext;

			/// <summary>Pointer to the AddCredential function.</summary>
			public IntPtr AddCredentials;

			/// <summary>Reserved for future use.</summary>
			public IntPtr Reserved4;

			/// <summary>Pointer to the QuerySecurityContextToken function.</summary>
			public IntPtr QuerySecurityContextToke;

			/// <summary>Pointer to the EncryptMessage (General) function.</summary>
			public IntPtr EncryptMessag;

			/// <summary>Pointer to the DecryptMessage (General) function.</summary>
			public IntPtr DecryptMessag;

			/// <summary>Pointer to the SetContextAttributes function.</summary>
			public IntPtr SetContextAttributes;

			/// <summary>Pointer to the SetCredentialsAttributes function.</summary>
			public IntPtr SetCredentialsAttributes;

			/// <summary>Pointer to the ChangeAccountPassword function.</summary>
			public IntPtr ChangeAccountPassword;

			/// <summary>Pointer to the AddCredential function.</summary>
			public IntPtr Reserved5;

			/// <summary>Pointer to the QueryContextAttributesEx function.</summary>
			public IntPtr QueryContextAttributesEx;

			/// <summary>Pointer to the QueryCredentialsAttributesEx function.</summary>
			public IntPtr QueryCredentialsAttributesEx;
		}

		/// <summary>Provides a <see cref="SafeHandle"/> for a context buffer that is disposed using <see cref="FreeContextBuffer"/>.</summary>
		public class SafeContextBuffer : SafeHANDLE
		{
			/// <summary>Initializes a new instance of the <see cref="SafeContextBuffer"/> class and assigns an existing handle.</summary>
			/// <param name="preexistingHandle">An <see cref="IntPtr"/> object that represents the pre-existing handle to use.</param>
			/// <param name="ownsHandle">
			/// <see langword="true"/> to reliably release the handle during the finalization phase; otherwise, <see langword="false"/> (not recommended).
			/// </param>
			public SafeContextBuffer(IntPtr preexistingHandle, bool ownsHandle = true) : base(preexistingHandle, ownsHandle) { }

			/// <summary>Initializes a new instance of the <see cref="SafeContextBuffer"/> class.</summary>
			private SafeContextBuffer() : base() { }

			/// <summary>
			/// Extracts an array of structures of <typeparamref name="T"/> containing <paramref name="count"/> items. <note type="note">This
			/// call can cause memory exceptions if the pointer does not have sufficient allocated memory to retrieve all the structures.</note>
			/// </summary>
			/// <typeparam name="T">The type of the structures to retrieve.</typeparam>
			/// <param name="count">The number of structures to retrieve.</param>
			/// <param name="prefixBytes">The number of bytes to skip before reading the structures.</param>
			/// <returns>An array of structures of <typeparamref name="T"/>.</returns>
			public T[] ToArray<T>(int count, int prefixBytes = 0)
			{
				if (IsInvalid) return null;
				//if (Size < Marshal.SizeOf(typeof(T)) * count + prefixBytes)
				//	throw new InsufficientMemoryException("Requested array is larger than the memory allocated.");
				if (!typeof(T).IsBlittable()) throw new ArgumentException(@"Structure layout is not sequential or explicit.");
				return handle.ToArray<T>(count, prefixBytes);
			}

			/// <summary>
			/// Marshals data from this block of memory to a newly allocated managed object of the type specified by a generic type parameter.
			/// </summary>
			/// <typeparam name="T">The type of the object to which the data is to be copied. This must be a structure.</typeparam>
			/// <returns>A managed object that contains the data that this <see cref="SafeMemoryHandleExt{T}"/> holds.</returns>
			public T ToStructure<T>()
			{
				if (IsInvalid) return default;
				return handle.ToStructure<T>();
			}

			/// <inheritdoc/>
			protected override bool InternalReleaseHandle() => FreeContextBuffer(handle).Succeeded;
		}

		/// <summary>Provides a safe version of <see cref="CredHandle"/> that is disposed using <see cref="FreeCredentialsHandle"/>.</summary>
		[StructLayout(LayoutKind.Sequential)]
		public sealed class SafeCredHandle : IDisposable
		{
			private CredHandle handle;

			/// <summary>Initializes a new instance of the <see cref="SafeCredHandle"/> class and assigns an existing handle.</summary>
			/// <param name="preexistingHandle">An <see cref="IntPtr"/> object that represents the pre-existing handle to use.</param>
			public SafeCredHandle(CredHandle preexistingHandle) => handle = preexistingHandle;

			/// <summary>Initializes a new instance of the <see cref="SafeCredHandle"/> class.</summary>
			private SafeCredHandle() { }

			/// <summary>Performs an implicit conversion from <see cref="SafeCredHandle"/> to <see cref="CredHandle"/>.</summary>
			/// <param name="h">The safe handle instance.</param>
			/// <returns>The result of the conversion.</returns>
			public static implicit operator CredHandle(SafeCredHandle h) => h.handle;

			/// <summary>Performs an implicit conversion from <see cref="SafeCredHandle"/> to <see cref="CredHandle"/>.</summary>
			/// <param name="h">The safe handle.</param>
			/// <returns>The result of the conversion.</returns>
			public static unsafe implicit operator CredHandle* (SafeCredHandle h)
			{
				fixed (CredHandle* hp = &h.handle)
					return hp;
			}

			/// <summary>Get a NULL reference to CredHandle.</summary>
			public readonly static SafeCredHandle Null = new SafeCredHandle(CredHandle.Null);

			/// <summary>
			/// <para>
			/// The <c>AcquireCredentialsHandle (CredSSP)</c> function acquires a handle to preexisting credentials of a security principal.
			/// This handle is required by the InitializeSecurityContext (CredSSP) and AcceptSecurityContext (CredSSP) functions. These can
			/// be either preexisting credentials, which are established through a system logon that is not described here, or the caller
			/// can provide alternative credentials.
			/// </para>
			/// <note type="note">This is not a "log on to the network" and does not imply gathering of credentials.</note>
			/// </summary>
			/// <param name="pszPackage">
			/// A string that specifies the name of the security package with which these credentials will be used. This is a security
			/// package name returned in the <c>Name</c> member of a SecPkgInfo structure returned by the EnumerateSecurityPackages
			/// function. After a context is established, QueryContextAttributes (CredSSP) can be called with ulAttribute set to
			/// <c>SECPKG_ATTR_PACKAGE_INFO</c> to return information on the security package in use.
			/// </param>
			/// <param name="fCredentialUse">A flag that indicates how these credentials will be used.</param>
			/// <returns>On success, this function returns a credential handle.</returns>
			/// <remarks>
			/// <para>
			/// The <c>AcquireCredentialsHandle (CredSSP)</c> function returns a handle to the credentials of a principal, such as a user or
			/// client, as used by a specific security package. The function can return the handle to either preexisting credentials or
			/// newly created credentials and return it. This handle can be used in subsequent calls to the AcceptSecurityContext (CredSSP)
			/// and InitializeSecurityContext (CredSSP) functions.
			/// </para>
			/// <para>
			/// In general, <c>AcquireCredentialsHandle (CredSSP)</c> does not provide the credentials of other users logged on to the same
			/// computer. However, a caller with SE_TCB_NAME privilege can obtain the credentials of an existing logon session by specifying
			/// the logon identifier (LUID) of that session. Typically, this is used by kernel-mode modules that must act on behalf of a
			/// logged-on user.
			/// </para>
			/// </remarks>
			public static SafeCredHandle Acquire(string pszPackage, SECPKG_CRED fCredentialUse) => Acquire<int>(pszPackage, fCredentialUse, null, null, null, out _);

			/// <summary>
			/// <para>
			/// The <c>AcquireCredentialsHandle (CredSSP)</c> function acquires a handle to preexisting credentials of a security principal. This
			/// handle is required by the InitializeSecurityContext (CredSSP) and AcceptSecurityContext (CredSSP) functions. These can be either
			/// preexisting credentials, which are established through a system logon that is not described here, or the caller can provide
			/// alternative credentials.
			/// </para>
			/// <para>
			///   <c>Note</c> This is not a "log on to the network" and does not imply gathering of credentials.</para>
			/// </summary>
			/// <typeparam name="TAuthData">The type of the authentication data structure.</typeparam>
			/// <param name="pszPackage">A string that specifies the name of the security package with which these credentials will be used.
			/// This is a security package name returned in the <c>Name</c> member of a SecPkgInfo structure returned by the
			/// EnumerateSecurityPackages function. After a context is established, QueryContextAttributes (CredSSP) can be called with
			/// ulAttribute set to <c>SECPKG_ATTR_PACKAGE_INFO</c> to return information on the security package in use.</param>
			/// <param name="fCredentialUse">A flag that indicates how these credentials will be used.</param>
			/// <param name="pAuthData">The optional authentication data structure.</param>
			/// <returns>
			/// On success, this function returns a credential handle.
			/// </returns>
			/// <remarks>
			/// <para>
			/// The <c>AcquireCredentialsHandle (CredSSP)</c> function returns a handle to the credentials of a principal, such as a user or
			/// client, as used by a specific security package. The function can return the handle to either preexisting credentials or newly
			/// created credentials and return it. This handle can be used in subsequent calls to the AcceptSecurityContext (CredSSP) and
			/// InitializeSecurityContext (CredSSP) functions.
			/// </para>
			/// <para>
			/// In general, <c>AcquireCredentialsHandle (CredSSP)</c> does not provide the credentials of other users logged on to the same
			/// computer. However, a caller with SE_TCB_NAME privilege can obtain the credentials of an existing logon session by specifying the
			/// logon identifier (LUID) of that session. Typically, this is used by kernel-mode modules that must act on behalf of a logged-on user.
			/// </para>
			/// </remarks>
			public static SafeCredHandle Acquire<TAuthData>(string pszPackage, SECPKG_CRED fCredentialUse, TAuthData? pAuthData) where TAuthData : struct =>
				Acquire(pszPackage, fCredentialUse, pAuthData, null, null, out _);

			/// <summary>
			/// <para>
			/// The <c>AcquireCredentialsHandle (CredSSP)</c> function acquires a handle to preexisting credentials of a security principal. This
			/// handle is required by the InitializeSecurityContext (CredSSP) and AcceptSecurityContext (CredSSP) functions. These can be either
			/// preexisting credentials, which are established through a system logon that is not described here, or the caller can provide
			/// alternative credentials.
			/// </para>
			/// <para>
			///   <c>Note</c> This is not a "log on to the network" and does not imply gathering of credentials.</para>
			/// </summary>
			/// <typeparam name="TAuthData">The type of the authentication data.</typeparam>
			/// <param name="pszPackage">A string that specifies the name of the security package with which these credentials will be used.
			/// This is a security package name returned in the <c>Name</c> member of a SecPkgInfo structure returned by the
			/// EnumerateSecurityPackages function. After a context is established, QueryContextAttributes (CredSSP) can be called with
			/// ulAttribute set to <c>SECPKG_ATTR_PACKAGE_INFO</c> to return information on the security package in use.</param>
			/// <param name="fCredentialUse">A flag that indicates how these credentials will be used.</param>
			/// <param name="pAuthData">An optional structure that specifies authentication data. The structure allowed depends on the type of protocol.</param>
			/// <param name="pszPrincipal"><para>An optional string that specifies the name of the principal whose credentials the handle will reference.</para>
			/// <para>
			///   <c>Note</c> If the process that requests the handle does not have access to the credentials, the function returns an error. A
			/// null string indicates that the process requires a handle to the credentials of the user under whose security context it is executing.
			/// </para></param>
			/// <param name="pvLogonId">A locally unique identifier (LUID) that identifies the user. This parameter is provided for file-system processes
			/// such as network redirectors. This parameter can be <c>NULL</c>.</param>
			/// <param name="ptsExpiry">A TimeStamp structure that receives the time at which the returned credentials expire. The structure value received
			/// depends on the security package, which must specify the value in local time.</param>
			/// <returns>On success, this function returns a credential handle.</returns>
			/// <remarks>
			/// <para>
			/// The <c>AcquireCredentialsHandle (CredSSP)</c> function returns a handle to the credentials of a principal, such as a user or
			/// client, as used by a specific security package. The function can return the handle to either preexisting credentials or newly
			/// created credentials and return it. This handle can be used in subsequent calls to the AcceptSecurityContext (CredSSP) and
			/// InitializeSecurityContext (CredSSP) functions.
			/// </para>
			/// <para>
			/// In general, <c>AcquireCredentialsHandle (CredSSP)</c> does not provide the credentials of other users logged on to the same
			/// computer. However, a caller with SE_TCB_NAME privilege can obtain the credentials of an existing logon session by specifying the
			/// logon identifier (LUID) of that session. Typically, this is used by kernel-mode modules that must act on behalf of a logged-on user.
			/// </para>
			/// </remarks>
			public static SafeCredHandle Acquire<TAuthData>(string pszPackage, SECPKG_CRED fCredentialUse, TAuthData? pAuthData, string pszPrincipal,
				LUID? pvLogonId, out TimeStamp ptsExpiry) where TAuthData : struct
			{
				using (var pinnedLuid = new PinnedObject(pvLogonId))
				using (var pinnedAuthData = pAuthData.HasValue ? SafeHGlobalHandle.CreateFromStructure(pAuthData) : SafeHGlobalHandle.Null)
				{
					AcquireCredentialsHandle(pszPrincipal, pszPackage, fCredentialUse, pinnedLuid, (IntPtr)pinnedAuthData, IntPtr.Zero, IntPtr.Zero, out var hCred, out ptsExpiry).ThrowIfFailed();
					return new SafeCredHandle(hCred);
				}
			}

			/// <summary>
			/// Get a dangerous reference to the underlying CredHandle. This value is mutable and may be invalid after this
			/// <see cref="SafeCredHandle"/> instance is disposed.
			/// </summary>
			public CredHandle DangerousGetHandle() => handle;

			void IDisposable.Dispose()
			{
				if (handle.IsInvalid || handle.IsNull) return;
				FreeCredentialsHandle(ref handle);
				handle = CredHandle.Null;
			}
		}

		/// <summary>Provides a safe version of <see cref="CtxtHandle"/> that is disposed using <see cref="DeleteSecurityContext"/>.</summary>
		[StructLayout(LayoutKind.Sequential)]
		public sealed class SafeCtxtHandle : IDisposable
		{
			private CtxtHandle handle;

			/// <summary>Initializes a new instance of the <see cref="SafeCtxtHandle"/> class.</summary>
			public SafeCtxtHandle() => handle = CtxtHandle.Null;

			/// <summary>Initializes a new instance of the <see cref="SafeCtxtHandle"/> class and assigns an existing handle.</summary>
			/// <param name="preexistingHandle">An <see cref="IntPtr"/> object that represents the pre-existing handle to use.</param>
			public SafeCtxtHandle(CtxtHandle preexistingHandle) => handle = preexistingHandle;

			/// <summary>Performs an implicit conversion from <see cref="SafeCtxtHandle"/> to <see cref="CtxtHandle"/>.</summary>
			/// <param name="h">The safe handle instance.</param>
			/// <returns>The result of the conversion.</returns>
			public static implicit operator CtxtHandle(SafeCtxtHandle h) => h.handle;

			/// <summary>Performs an implicit conversion from <see cref="SafeCtxtHandle"/> to <see cref="CtxtHandle"/>.</summary>
			/// <param name="h">The safe handle.</param>
			/// <returns>The result of the conversion.</returns>
			public static unsafe implicit operator CtxtHandle* (SafeCtxtHandle h)
			{
				if (h.handle.IsNull)
					return null;
				fixed (CtxtHandle* hp = &h.handle)
					return hp;
			}

			/// <summary>Get a NULL reference to CredHandle.</summary>
			public readonly static SafeCtxtHandle Null = new SafeCtxtHandle(CtxtHandle.Null);

			/// <summary>
			/// Get a dangerous reference to the underlying CtxtHandle. This value is mutable and may be invalid after this
			/// <see cref="SafeCtxtHandle"/> instance is disposed.
			/// </summary>
			public CtxtHandle DangerousGetHandle() => handle;

			void IDisposable.Dispose()
			{
				if (!handle.IsInvalid && !handle.IsNull) DeleteSecurityContext(handle);
			}

			internal void SetHandle(CtxtHandle h)
			{
				if (handle.IsNull) handle = h; else throw new InvalidOperationException();
			}
		}

		/// <summary>Provides a <see cref="SafeHandle"/> for <see cref="PSEC_WINNT_AUTH_IDENTITY_OPAQUE"/> that is disposed using <see cref="SspiFreeAuthIdentity"/>.</summary>
		public class SafePSEC_WINNT_AUTH_IDENTITY_OPAQUE : SafeHANDLE
		{
			/// <summary>
			/// Represents a null instance.
			/// </summary>
			public static readonly SafePSEC_WINNT_AUTH_IDENTITY_OPAQUE Null = new SafePSEC_WINNT_AUTH_IDENTITY_OPAQUE();

			/// <summary>
			/// Initializes a new instance of the <see cref="SafePSEC_WINNT_AUTH_IDENTITY_OPAQUE"/> class and assigns an existing handle.
			/// </summary>
			/// <param name="preexistingHandle">An <see cref="IntPtr"/> object that represents the pre-existing handle to use.</param>
			/// <param name="ownsHandle">
			/// <see langword="true"/> to reliably release the handle during the finalization phase; otherwise, <see langword="false"/> (not recommended).
			/// </param>
			public SafePSEC_WINNT_AUTH_IDENTITY_OPAQUE(IntPtr preexistingHandle, bool ownsHandle = true) : base(preexistingHandle, ownsHandle) { }

			/// <summary>Initializes a new instance of the <see cref="SafePSEC_WINNT_AUTH_IDENTITY_OPAQUE"/> class.</summary>
			private SafePSEC_WINNT_AUTH_IDENTITY_OPAQUE() : base() { }

			/// <summary>Performs an implicit conversion from <see cref="SafePSEC_WINNT_AUTH_IDENTITY_OPAQUE"/> to <see cref="PSEC_WINNT_AUTH_IDENTITY_OPAQUE"/>.</summary>
			/// <param name="h">The safe handle instance.</param>
			/// <returns>The result of the conversion.</returns>
			public static implicit operator PSEC_WINNT_AUTH_IDENTITY_OPAQUE(SafePSEC_WINNT_AUTH_IDENTITY_OPAQUE h) => h.handle;

			/// <inheritdoc/>
			protected override bool InternalReleaseHandle() { SspiZeroAuthIdentity(handle); SspiFreeAuthIdentity(handle); return true; }
		}

		/// <summary>
		/// The <c>SafeSecBufferDesc</c> structure describes an array of SecBuffer structures to pass from a transport application to a
		/// security package. It handles cleaning up allocated memory.
		/// </summary>
		/// <remarks>
		/// This is a drop in replacement for anywhere a "SecBufferDesc*" or "ref SecBufferDesc" is required. This class will free all 
		/// allocated memory and will also free any memory created by Sspi methods that require a call to <see cref="FreeContextBuffer"/>.
		/// <para>Sample code:</para><code>using (var edesc = new SafeSecBufferDesc())
		/// {
		///   edesc.Add(SecBufferType.SECBUFFER_TOKEN); // Add SecBuffer with type, but no values
		///   edesc.Add(SecBufferType.SECBUFFER_EMPTY); // Add SecBuffer with empty type
		///   edesc.Add(SecBufferType.SECBUFFER_DATA, msgStruct); // Add SecBuffer with type set and buffer filled with value of 'msgStruct'
		///   edesc.Add(blockSize, SecBufferType.SECBUFFER_PADDING); // Add SecBuffer with type and allocated memory of size 'blockSize'
		///
		///   // Call method with ref
		///   EncryptMessage(hCtx, 0, ref edesc.GetRef(), 0); // Use GetRef() method to get a reference to the internal SecBufferDesc structure
		///
		///   // Call method with *
		///   unsafe
		///   {
		///      AcceptSecurityContext(hCred, hCtxt2, edesc, ...); // An implicit operator will cast to a SecBufferDesc*
		///   }
		/// }</code></remarks>
		[PInvokeData("sspi.h", MSDNShortId = "fc6ef09c-3ba9-4bcb-a3c2-07422af8eaa9")]
		public class SafeSecBufferDesc : SafeNativeArrayBase<SecBuffer, HGlobalMemoryMethods>
		{
			private static readonly uint HdrSize = (uint)Marshal.SizeOf(typeof(SecBufferDesc));

			private readonly List<SafeAllocatedMemoryHandle> items = new List<SafeAllocatedMemoryHandle>();
			private SecBufferDesc desc = SecBufferDesc.Default;

			/// <summary>Initializes a new instance of the <see cref="SafeSecBufferDesc"/> class.</summary>
			public SafeSecBufferDesc() : base(null, HdrSize) { }

			/// <summary>Initializes a new instance of the <see cref="SafeSecBufferDesc"/> class.</summary>
			public SafeSecBufferDesc(SecBufferType type) : base(new[] { new SecBuffer(type) }, HdrSize) { }

			/// <summary>Performs an implicit conversion from <see cref="SafeSecBufferDesc"/> to <see cref="SecBufferDesc"/>.</summary>
			/// <param name="sbd">The <see cref="SafeSecBufferDesc"/> instance.</param>
			/// <returns>The result of the conversion.</returns>
			public static unsafe implicit operator SecBufferDesc* (SafeSecBufferDesc sbd) => (SecBufferDesc*)sbd.handle;

			/// <summary>Performs an implicit conversion from <see cref="SafeSecBufferDesc"/> to <see cref="SecBufferDesc"/>.</summary>
			/// <param name="sbd">The <see cref="SafeSecBufferDesc"/> instance.</param>
			/// <returns>The result of the conversion.</returns>
			public static implicit operator SecBufferDesc? (SafeSecBufferDesc sbd) => (SecBufferDesc)sbd.handle.ToNullableStructure<SecBufferDesc>();

			/// <summary>Adds the specified type with an empty value as a new SecBuffer item.</summary>
			/// <param name="type">The type of the SecBuffer.</param>
			public virtual void Add(SecBufferType type) => Add(new SecBuffer(type));

			/// <summary>Adds the specified type and value as a new SecBuffer item.</summary>
			/// <typeparam name="T">The type of the value to add</typeparam>
			/// <param name="type">The type of the SecBuffer.</param>
			/// <param name="value">The value to add.</param>
			public virtual void Add<T>(SecBufferType type, T value = default) where T : struct
			{
				var mem = SafeHGlobalHandle.CreateFromStructure(value);
				items.Add(mem);
				Add(new SecBuffer(type, (IntPtr)mem, mem.Size));
			}

			/// <summary>Adds the specified type and value as a new SecBuffer item.</summary>
			/// <typeparam name="T">The type of the element to add</typeparam>
			/// <param name="type">The type of the SecBuffer.</param>
			/// <param name="value">The list to add.</param>
			public virtual void Add<T>(SecBufferType type, IEnumerable<T> value) where T : struct
			{
				var mem = SafeHGlobalHandle.CreateFromList(value);
				items.Add(mem);
				Add(new SecBuffer(type, (IntPtr)mem, mem.Size));
			}

			/// <summary>Adds the specified type and value as a new SecBuffer item.</summary>
			/// <param name="type">The type of the SecBuffer.</param>
			/// <param name="value">The list to add.</param>
			public virtual void Add(SecBufferType type, string value)
			{
				var mem = new SafeHGlobalHandle(value);
				items.Add(mem);
				Add(new SecBuffer(type, (IntPtr)mem, mem.Size));
			}

			/// <summary>Adds the specified type with an allocated buffer of the specified size as a new SecBuffer item.</summary>
			/// <param name="bufferSize">Size of the buffer.</param>
			/// <param name="type">The type of the SecBuffer.</param>
			public virtual void Add(int bufferSize, SecBufferType type)
			{
				var mem = new SafeHGlobalHandle(bufferSize);
				items.Add(mem);
				Add(new SecBuffer(type, (IntPtr)mem, mem.Size));
			}

			/// <summary>Performs an implicit conversion from <see cref="SafeSecBufferDesc"/> to <see cref="SecBufferDesc"/>.</summary>
			/// <returns>A reference to a <see cref="SecBufferDesc"/> struct.</returns>
			public ref SecBufferDesc GetRef() => ref desc;

			/// <inheritdoc/>
			protected override void OnCountChanged() => OnUpdateHeader();

			/// <inheritdoc/>
			protected override void OnUpdateHeader()
			{
				desc.cBuffers = (uint)Count;
				desc.pBuffers = handle.Offset((int)HdrSize);
				Marshal.StructureToPtr(desc, handle, false);
			}

			/// <inheritdoc/>
			protected override bool ReleaseHandle()
			{
				var hash = new HashSet<IntPtr>(items.Select(i => i.DangerousGetHandle()));
				foreach (var buf in this.Where(b => !hash.Contains(b.pvBuffer)))
					FreeContextBuffer(buf.pvBuffer);
				Clear();
				foreach (var i in items)
					i.Dispose();
				items.Clear();
				desc = SecBufferDesc.Default;
				return base.ReleaseHandle();
			}
		}

		/// <summary>Provides a <see cref="SafeHandle"/> for Sspi allocated memory that is disposed using <see cref="SspiLocalFree"/>.</summary>
		public class SafeSspiLocalMem : SafeHANDLE
		{
			/// <summary>Initializes a new instance of the <see cref="SafeSspiLocalMem"/> class and assigns an existing handle.</summary>
			/// <param name="preexistingHandle">An <see cref="IntPtr"/> object that represents the pre-existing handle to use.</param>
			/// <param name="ownsHandle"><see langword="true"/> to reliably release the handle during the finalization phase; otherwise, <see langword="false"/> (not recommended).</param>
			public SafeSspiLocalMem(IntPtr preexistingHandle, bool ownsHandle = true) : base(preexistingHandle, ownsHandle) { }

			/// <summary>Initializes a new instance of the <see cref="SafeSspiLocalMem"/> class.</summary>
			private SafeSspiLocalMem() : base() { }

			/// <summary>Gets the bytes associated with this memory.</summary>
			/// <param name="count">The count of bytes to get.</param>
			/// <returns>A byte array.</returns>
			public byte[] GetBytes(uint count) => handle.ToByteArray((int)count);

			/// <inheritdoc/>
			protected override bool InternalReleaseHandle() { SspiLocalFree(handle); return true; }
		}

		internal class SspiStringMarshaler : ICustomMarshaler
		{
			public static ICustomMarshaler GetInstance(string _) => new SspiStringMarshaler();

			public void CleanUpManagedData(object ManagedObj)
			{
			}

			public void CleanUpNativeData(IntPtr pNativeData)
			{
				if (pNativeData == IntPtr.Zero) return;
				SspiFreeAuthIdentity(pNativeData);
			}

			public int GetNativeDataSize() => -1;

			public IntPtr MarshalManagedToNative(object _) => IntPtr.Zero;

			public object MarshalNativeToManaged(IntPtr pNativeData)
			{
				var ret = StringHelper.GetString(pNativeData, CharSet.Unicode);
				System.Diagnostics.Debug.WriteLine($"SspiStringMarshaler: {ret ?? "null"}");
				return ret.Clone();
			}
		}
	}
}