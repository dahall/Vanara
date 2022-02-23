using System;
using System.Runtime.InteropServices;
using Vanara.Extensions;
using static Vanara.PInvoke.Crypt32;
using FILETIME = System.Runtime.InteropServices.ComTypes.FILETIME;

namespace Vanara.PInvoke
{
	/// <summary>Functions, structures and constants for schannel.dll</summary>
	public static partial class Schannel
	{
		/// <summary/>
		public const uint CF_CERT_FROM_FILE = 2;
		/// <summary/>
		public const string DEFAULT_TLS_SSP_NAME = "Default TLS SSP";
		/// <summary/>
		public const string PCT1SP_NAME = "Microsoft PCT 1.0";
		/// <summary/>
		public const string SCHANNEL_NAME = "Schannel";
		/// <summary/>
		public const string SSL2SP_NAME = "Microsoft SSL 2.0";
		/// <summary/>
		public const string SSL3SP_NAME = "Microsoft SSL 3.0";
		/// <summary/>
		public const string TLS1SP_NAME = "Microsoft TLS 1.0";
		/// <summary/>
		public const string UNISP_NAME = "Microsoft Unified Security Protocol Provider";

		private const int SECPKGCONTEXT_CONNECTION_INFO_EX_V1 = 1;
		private const int SZ_ALG_MAX_SIZE = 64;

		/// <summary>Protocol used to establish this connection.</summary>
		[PInvokeData("schannel.h")]
		[Flags]
		public enum SP_PROT : uint
		{
			/// <summary/>
			SP_PROT_NONE = 0,

			/// <summary>Transport Layer Security 1.0 client-side.</summary>
			SP_PROT_TLS1_CLIENT = 128,

			/// <summary>Transport Layer Security 1.0 server-side.</summary>
			SP_PROT_TLS1_SERVER = 64,

			/// <summary>Secure Sockets Layer 3.0 client-side.</summary>
			SP_PROT_SSL3_CLIENT = 32,

			/// <summary>Secure Sockets Layer 3.0 server-side.</summary>
			SP_PROT_SSL3_SERVER = 16,

			/// <summary>Transport Layer Security 1.1 client-side.</summary>
			SP_PROT_TLS1_1_CLIENT = 512,

			/// <summary>Transport Layer Security 1.1 server-side.</summary>
			SP_PROT_TLS1_1_SERVER = 256,

			/// <summary>Transport Layer Security 1.2 client-side.</summary>
			SP_PROT_TLS1_2_CLIENT = 2048,

			/// <summary>Transport Layer Security 1.2 server-side.</summary>
			SP_PROT_TLS1_2_SERVER = 1024,

			/// <summary>Private Communications Technology 1.0 client-side. Obsolete.</summary>
			SP_PROT_PCT1_CLIENT = 2,

			/// <summary>Private Communications Technology 1.0 server-side. Obsolete.</summary>
			SP_PROT_PCT1_SERVER = 1,

			/// <summary>Secure Sockets Layer 2.0 client-side. Superseded by SP_PROT_TLS1_CLIENT.</summary>
			SP_PROT_SSL2_CLIENT = 8,

			/// <summary>Secure Sockets Layer 2.0 server-side. Superseded by SP_PROT_TLS1_SERVER.</summary>
			SP_PROT_SSL2_SERVER = 4,

			/// <summary/>
			SP_PROT_PCT1 = (SP_PROT_PCT1_SERVER | SP_PROT_PCT1_CLIENT),

			/// <summary/>
			SP_PROT_SSL2 = (SP_PROT_SSL2_SERVER | SP_PROT_SSL2_CLIENT),

			/// <summary/>
			SP_PROT_SSL3 = (SP_PROT_SSL3_SERVER | SP_PROT_SSL3_CLIENT),

			/// <summary/>
			SP_PROT_TLS1 = (SP_PROT_TLS1_SERVER | SP_PROT_TLS1_CLIENT),

			/// <summary/>
			SP_PROT_SSL3TLS1_CLIENTS = (SP_PROT_TLS1_CLIENT | SP_PROT_SSL3_CLIENT),

			/// <summary/>
			SP_PROT_SSL3TLS1_SERVERS = (SP_PROT_TLS1_SERVER | SP_PROT_SSL3_SERVER),

			/// <summary/>
			SP_PROT_SSL3TLS1 = (SP_PROT_SSL3 | SP_PROT_TLS1),

			/// <summary/>
			SP_PROT_UNI_SERVER = 0x40000000,

			/// <summary/>
			SP_PROT_UNI_CLIENT = 0x80000000,

			/// <summary/>
			SP_PROT_UNI = (SP_PROT_UNI_SERVER | SP_PROT_UNI_CLIENT),

			/// <summary/>
			SP_PROT_ALL = 0xffffffff,

			/// <summary/>
			SP_PROT_CLIENTS = (SP_PROT_PCT1_CLIENT | SP_PROT_SSL2_CLIENT | SP_PROT_SSL3_CLIENT | SP_PROT_UNI_CLIENT | SP_PROT_TLS1_CLIENT),

			/// <summary/>
			SP_PROT_SERVERS = (SP_PROT_PCT1_SERVER | SP_PROT_SSL2_SERVER | SP_PROT_SSL3_SERVER | SP_PROT_UNI_SERVER | SP_PROT_TLS1_SERVER),

			/// <summary/>
			SP_PROT_TLS1_0_SERVER = SP_PROT_TLS1_SERVER,

			/// <summary/>
			SP_PROT_TLS1_0_CLIENT = SP_PROT_TLS1_CLIENT,

			/// <summary/>
			SP_PROT_TLS1_0 = (SP_PROT_TLS1_0_SERVER | SP_PROT_TLS1_0_CLIENT),

			/// <summary/>
			SP_PROT_TLS1_1 = (SP_PROT_TLS1_1_SERVER | SP_PROT_TLS1_1_CLIENT),

			/// <summary/>
			SP_PROT_TLS1_2 = (SP_PROT_TLS1_2_SERVER | SP_PROT_TLS1_2_CLIENT),

			/// <summary/>
			SP_PROT_TLS1_3_SERVER = 0x00001000,

			/// <summary/>
			SP_PROT_TLS1_3_CLIENT = 0x00002000,

			/// <summary/>
			SP_PROT_TLS1_3 = (SP_PROT_TLS1_3_SERVER | SP_PROT_TLS1_3_CLIENT),

			/// <summary/>
			SP_PROT_DTLS_SERVER = 0x00010000,

			/// <summary/>
			SP_PROT_DTLS_CLIENT = 0x00020000,

			/// <summary/>
			SP_PROT_DTLS = (SP_PROT_DTLS_SERVER | SP_PROT_DTLS_CLIENT),

			/// <summary/>
			SP_PROT_DTLS1_0_SERVER = SP_PROT_DTLS_SERVER,

			/// <summary/>
			SP_PROT_DTLS1_0_CLIENT = SP_PROT_DTLS_CLIENT,

			/// <summary/>
			SP_PROT_DTLS1_0 = (SP_PROT_DTLS1_0_SERVER | SP_PROT_DTLS1_0_CLIENT),

			/// <summary/>
			SP_PROT_DTLS1_2_SERVER = 0x00040000,

			/// <summary/>
			SP_PROT_DTLS1_2_CLIENT = 0x00080000,

			/// <summary/>
			SP_PROT_DTLS1_2 = (SP_PROT_DTLS1_2_SERVER | SP_PROT_DTLS1_2_CLIENT),

			/// <summary/>
			SP_PROT_DTLS1_X_SERVER = (SP_PROT_DTLS1_0_SERVER | SP_PROT_DTLS1_2_SERVER),

			/// <summary/>
			SP_PROT_DTLS1_X_CLIENT = (SP_PROT_DTLS1_0_CLIENT | SP_PROT_DTLS1_2_CLIENT),

			/// <summary/>
			SP_PROT_DTLS1_X = (SP_PROT_DTLS1_X_SERVER | SP_PROT_DTLS1_X_CLIENT),

			/// <summary/>
			SP_PROT_TLS1_1PLUS_SERVER = (SP_PROT_TLS1_1_SERVER | SP_PROT_TLS1_2_SERVER | SP_PROT_TLS1_3_SERVER),

			/// <summary/>
			SP_PROT_TLS1_1PLUS_CLIENT = (SP_PROT_TLS1_1_CLIENT | SP_PROT_TLS1_2_CLIENT | SP_PROT_TLS1_3_CLIENT),

			/// <summary/>
			SP_PROT_TLS1_1PLUS = (SP_PROT_TLS1_1PLUS_SERVER | SP_PROT_TLS1_1PLUS_CLIENT),

			/// <summary/>
			SP_PROT_TLS1_3PLUS_SERVER = SP_PROT_TLS1_3_SERVER,

			/// <summary/>
			SP_PROT_TLS1_3PLUS_CLIENT = SP_PROT_TLS1_3_CLIENT,

			/// <summary/>
			SP_PROT_TLS1_3PLUS = (SP_PROT_TLS1_3PLUS_SERVER | SP_PROT_TLS1_3PLUS_CLIENT),

			/// <summary/>
			SP_PROT_TLS1_X_SERVER = (SP_PROT_TLS1_0_SERVER | SP_PROT_TLS1_1_SERVER | SP_PROT_TLS1_2_SERVER | SP_PROT_TLS1_3_SERVER),

			/// <summary/>
			SP_PROT_TLS1_X_CLIENT = (SP_PROT_TLS1_0_CLIENT | SP_PROT_TLS1_1_CLIENT | SP_PROT_TLS1_2_CLIENT | SP_PROT_TLS1_3_CLIENT),

			/// <summary/>
			SP_PROT_TLS1_X = (SP_PROT_TLS1_X_SERVER | SP_PROT_TLS1_X_CLIENT),

			/// <summary/>
			SP_PROT_SSL3TLS1_X_CLIENTS = (SP_PROT_TLS1_X_CLIENT | SP_PROT_SSL3_CLIENT),

			/// <summary/>
			SP_PROT_SSL3TLS1_X_SERVERS = (SP_PROT_TLS1_X_SERVER | SP_PROT_SSL3_SERVER),

			/// <summary/>
			SP_PROT_SSL3TLS1_X = (SP_PROT_SSL3 | SP_PROT_TLS1_X),

			/// <summary/>
			SP_PROT_X_CLIENTS = (SP_PROT_CLIENTS | SP_PROT_TLS1_X_CLIENT | SP_PROT_DTLS1_X_CLIENT),

			/// <summary/>
			SP_PROT_X_SERVERS = (SP_PROT_SERVERS | SP_PROT_TLS1_X_SERVER | SP_PROT_DTLS1_X_SERVER)
		}

		/// <summary>
		/// <para>
		/// [The <c>SslCrackCertificate</c> function is available for use in the operating systems specified in the Requirements section. It
		/// may be altered or unavailable in subsequent versions. Instead, use the CertCreateCertificateContext function.]
		/// </para>
		/// <para>Returns an X509Certificate structure with the information contained in the specified certificate BLOB.</para>
		/// <para>
		/// This function has no associated import library. You must use the LoadLibrary and GetProcAddress functions to dynamically link to Schannel.dll.
		/// </para>
		/// </summary>
		/// <param name="pbCertificate">The certificate BLOB from which to create the new X509Certificate structure.</param>
		/// <param name="cbCertificate">The length, in bytes, of the BLOB contained in the pbCertificate parameter.</param>
		/// <param name="dwFlags">
		/// Set this value to <c>CF_CERT_FROM_FILE</c> to specify that the certificate BLOB contained in the pbCertificate parameter is from
		/// a file.
		/// </param>
		/// <param name="ppCertificate">
		/// <para>On return, receives the address of a pointer to the X509Certificate structure that this function creates.</para>
		/// <para>When you have finished using the X509Certificate structure, free it by calling SslFreeCertificate.</para>
		/// </param>
		/// <returns>Returns nonzero if this function successfully created an X509Certificate structure or zero otherwise.</returns>
		// https://docs.microsoft.com/en-us/windows/desktop/api/schannel/nf-schannel-sslcrackcertificate BOOL SslCrackCertificate( PUCHAR
		// pbCertificate, DWORD cbCertificate, DWORD dwFlags, PX509Certificate *ppCertificate );
		[DllImport(Lib.Schannel, SetLastError = false, ExactSpelling = true)]
		[PInvokeData("schannel.h", MSDNShortId = "e5ffeebb-0b09-4f0a-b2dc-75fb2a3af7ed")]
		[return: MarshalAs(UnmanagedType.Bool)]
		public static extern bool SslCrackCertificate(IntPtr pbCertificate, uint cbCertificate, uint dwFlags, out SafeSslCertificate ppCertificate);

		/// <summary>
		/// <para>Removes the specified string from the Schannel cache.</para>
		/// <para>
		/// This function has no associated import library. You must use the LoadLibrary and GetProcAddress functions to dynamically link to Schannel.dll.
		/// </para>
		/// </summary>
		/// <param name="pszTargetName">
		/// A pointer to a null-terminated string that specifies the entry to remove from the cache. If the value of this parameter is
		/// <c>NULL</c>, all entries are removed from the cache.
		/// </param>
		/// <param name="dwFlags">This parameter is not used.</param>
		/// <returns>Returns nonzero if the specified entries are removed from the Schannel cache or zero otherwise.</returns>
		// https://docs.microsoft.com/en-us/windows/desktop/api/schannel/nf-schannel-sslemptycachea BOOL SslEmptyCacheA( LPSTR pszTargetName,
		// DWORD dwFlags );
		[DllImport(Lib.Schannel, SetLastError = false, CharSet = CharSet.Auto)]
		[PInvokeData("schannel.h", MSDNShortId = "c914d4e3-657e-45ef-ace8-2cea900a8a76")]
		[return: MarshalAs(UnmanagedType.Bool)]
		public static extern bool SslEmptyCache([Optional] string pszTargetName, uint dwFlags = 0);

		/// <summary>
		/// <para>
		/// [The <c>SslFreeCertificate</c> function is available for use in the operating systems specified in the Requirements section. It
		/// may be altered or unavailable in subsequent versions. Instead, use the CertFreeCertificateContext function.]
		/// </para>
		/// <para>Frees a certificate that was allocated by a previous call to the SslCrackCertificate function.</para>
		/// <para>
		/// This function has no associated import library. You must use the LoadLibrary and GetProcAddress functions to dynamically link to Schannel.dll.
		/// </para>
		/// </summary>
		/// <param name="pCertificate">The certificate to free.</param>
		// https://docs.microsoft.com/en-us/windows/desktop/api/schannel/nf-schannel-sslfreecertificate void SslFreeCertificate(
		// PX509Certificate pCertificate );
		[DllImport(Lib.Schannel, SetLastError = false, ExactSpelling = true)]
		[PInvokeData("schannel.h", MSDNShortId = "bf643ece-fe79-4f6e-a216-108fce6757a4")]
		public static extern void SslFreeCertificate(IntPtr pCertificate);

		/// <summary>
		/// The <c>SslGetServerIdentity</c> function gets the identity of the server. This function has no associated import library. You
		/// must use the LoadLibrary and GetProcAddress functions to dynamically link to Schannel.dll.
		/// </summary>
		/// <param name="ClientHello">The message from the client.</param>
		/// <param name="ClientHelloSize">The size of the client message.</param>
		/// <param name="ServerIdentity">The pointer inside the message where the server name starts.</param>
		/// <param name="ServerIdentitySize">The length of the server name.</param>
		/// <param name="Flags">This parameter is reserved and must be zero.</param>
		/// <returns>
		/// <para>The status of the call to the function.</para>
		/// <list type="table">
		/// <listheader>
		/// <term>Return code</term>
		/// <term>Description</term>
		/// </listheader>
		/// <item>
		/// <term>SEC_E_OK</term>
		/// <term>The function was successful.</term>
		/// </item>
		/// <item>
		/// <term>SEC_E_INVALID_PARAMETER</term>
		/// <term>One of the parameters ClientHello, ServerIdentity, or ServerIdentitySize is NULL.</term>
		/// </item>
		/// <item>
		/// <term>SEC_E_INCOMPLETE_MESSAGE</term>
		/// <term>The ServerIdentitySize parameter is smaller than the ClientHelloSize parameter.</term>
		/// </item>
		/// </list>
		/// </returns>
		// https://docs.microsoft.com/en-us/windows/desktop/api/schannel/nf-schannel-sslgetserveridentity SECURITY_STATUS
		// SslGetServerIdentity( PBYTE ClientHello, DWORD ClientHelloSize, PBYTE *ServerIdentity, PDWORD ServerIdentitySize, DWORD Flags );
		[DllImport(Lib.Schannel, SetLastError = false, ExactSpelling = true)]
		[PInvokeData("schannel.h", MSDNShortId = "5FA7A0F5-187F-4CE6-AD62-44B71A40568D")]
		public static extern HRESULT SslGetServerIdentity(IntPtr ClientHello, uint ClientHelloSize, out IntPtr ServerIdentity, out uint ServerIdentitySize, uint Flags = 0);

		/// <summary>
		/// <para>
		/// [Some information relates to pre-released product which may be substantially modified before it's commercially released.
		/// Microsoft makes no warranties, express or implied, with respect to the information provided here.]
		/// </para>
		/// <para>
		/// Cipher info structure. This is returned by SECPKG_ATTR_CIPHER_INFO ulAttribute from the QueryContextAttributes (Schannel) function.
		/// </para>
		/// </summary>
		// https://docs.microsoft.com/en-us/windows/desktop/api/schannel/ns-schannel-_secpkgcontext_cipherinfo typedef struct
		// _SecPkgContext_CipherInfo { DWORD dwVersion; DWORD dwProtocol; DWORD dwCipherSuite; DWORD dwBaseCipherSuite; WCHAR
		// szCipherSuite[SZ_ALG_MAX_SIZE]; WCHAR szCipher[SZ_ALG_MAX_SIZE]; DWORD dwCipherLen; DWORD dwCipherBlockLen; WCHAR
		// szHash[SZ_ALG_MAX_SIZE]; DWORD dwHashLen; WCHAR szExchange[SZ_ALG_MAX_SIZE]; DWORD dwMinExchangeLen; DWORD dwMaxExchangeLen; WCHAR
		// szCertificate[SZ_ALG_MAX_SIZE]; DWORD dwKeyType; } SecPkgContext_CipherInfo, *PSecPkgContext_CipherInfo;
		[PInvokeData("schannel.h", MSDNShortId = "204D3520-76B6-42C0-83A4-45769F66364A")]
		[StructLayout(LayoutKind.Sequential, CharSet = CharSet.Unicode)]
		public struct SecPkgContext_CipherInfo
		{
			/// <summary>The dw version.</summary>
			public uint dwVersion;

			/// <summary>The dw protocol.</summary>
			public uint dwProtocol;

			/// <summary>The dw cipher suite.</summary>
			public uint dwCipherSuite;

			/// <summary>The dw base cipher suite.</summary>
			public uint dwBaseCipherSuite;

			/// <summary>The sz cipher suite</summary>
			[MarshalAs(UnmanagedType.ByValTStr, SizeConst = SZ_ALG_MAX_SIZE)]
			public string szCipherSuite;

			/// <summary>The sz cipher</summary>
			[MarshalAs(UnmanagedType.ByValTStr, SizeConst = SZ_ALG_MAX_SIZE)]
			public string szCipher;

			/// <summary>The dw cipher length.</summary>
			public uint dwCipherLen;

			/// <summary>The dw cipher block length in bytes.</summary>
			public uint dwCipherBlockLen;

			/// <summary>The sz hash</summary>
			[MarshalAs(UnmanagedType.ByValTStr, SizeConst = SZ_ALG_MAX_SIZE)]
			public string szHash;

			/// <summary>The dw hash length.</summary>
			public uint dwHashLen;

			/// <summary>The sz exchange</summary>
			[MarshalAs(UnmanagedType.ByValTStr, SizeConst = SZ_ALG_MAX_SIZE)]
			public string szExchange;

			/// <summary>The dw min exchange length.</summary>
			public uint dwMinExchangeLen;

			/// <summary>The dw max exchange length.</summary>
			public uint dwMaxExchangeLen;

			/// <summary>The sz certificate</summary>
			[MarshalAs(UnmanagedType.ByValTStr, SizeConst = SZ_ALG_MAX_SIZE)]
			public string szCertificate;

			/// <summary>The dw key type.</summary>
			public uint dwKeyType;
		}

		/// <summary>
		/// <para>
		/// The <c>SecPkgContext_ConnectionInfo</c> structure contains protocol and cipher information. This structure is used by the
		/// InitializeSecurityContext (Schannel) function.
		/// </para>
		/// <para>This attribute is supported only by the Schannel security support provider (SSP).</para>
		/// </summary>
		// https://docs.microsoft.com/en-us/windows/desktop/api/schannel/ns-schannel-_secpkgcontext_connectioninfo typedef struct
		// _SecPkgContext_ConnectionInfo { DWORD dwProtocol; ALG_ID aiCipher; DWORD dwCipherStrength; ALG_ID aiHash; DWORD dwHashStrength;
		// ALG_ID aiExch; DWORD dwExchStrength; } SecPkgContext_ConnectionInfo, *PSecPkgContext_ConnectionInfo;
		[PInvokeData("schannel.h", MSDNShortId = "5380c03b-d2c5-4a0d-96a1-c39305b9c9ac")]
		[StructLayout(LayoutKind.Sequential)]
		public struct SecPkgContext_ConnectionInfo
		{
			/// <summary>
			/// <para>Protocol used to establish this connection. The following table describes the constants valid for this member.</para>
			/// <list type="table">
			/// <listheader>
			/// <term>Value</term>
			/// <term>Meaning</term>
			/// </listheader>
			/// <item>
			/// <term>SP_PROT_TLS1_CLIENT 128 (0x80)</term>
			/// <term>Transport Layer Security 1.0 client-side.</term>
			/// </item>
			/// <item>
			/// <term>SP_PROT_TLS1_SERVER 64 (0x40)</term>
			/// <term>Transport Layer Security 1.0 server-side.</term>
			/// </item>
			/// <item>
			/// <term>SP_PROT_SSL3_CLIENT 32 (0x20)</term>
			/// <term>Secure Sockets Layer 3.0 client-side.</term>
			/// </item>
			/// <item>
			/// <term>SP_PROT_SSL3_SERVER 16 (0x10)</term>
			/// <term>Secure Sockets Layer 3.0 server-side.</term>
			/// </item>
			/// <item>
			/// <term>SP_PROT_TLS1_1_CLIENT 512 (0x200)</term>
			/// <term>Transport Layer Security 1.1 client-side.</term>
			/// </item>
			/// <item>
			/// <term>SP_PROT_TLS1_1_SERVER 256 (0x100)</term>
			/// <term>Transport Layer Security 1.1 server-side.</term>
			/// </item>
			/// <item>
			/// <term>SP_PROT_TLS1_2_CLIENT 2048 (0x800)</term>
			/// <term>Transport Layer Security 1.2 client-side.</term>
			/// </item>
			/// <item>
			/// <term>SP_PROT_TLS1_2_SERVER 1024 (0x400)</term>
			/// <term>Transport Layer Security 1.2 server-side.</term>
			/// </item>
			/// <item>
			/// <term>SP_PROT_PCT1_CLIENT 2 (0x2)</term>
			/// <term>Private Communications Technology 1.0 client-side. Obsolete.</term>
			/// </item>
			/// <item>
			/// <term>SP_PROT_PCT1_SERVER 1 (0x1)</term>
			/// <term>Private Communications Technology 1.0 server-side. Obsolete.</term>
			/// </item>
			/// <item>
			/// <term>SP_PROT_SSL2_CLIENT 8 (0x8)</term>
			/// <term>Secure Sockets Layer 2.0 client-side. Superseded by SP_PROT_TLS1_CLIENT.</term>
			/// </item>
			/// <item>
			/// <term>SP_PROT_SSL2_SERVER 4 (0x4)</term>
			/// <term>Secure Sockets Layer 2.0 server-side. Superseded by SP_PROT_TLS1_SERVER.</term>
			/// </item>
			/// </list>
			/// </summary>
			public SP_PROT dwProtocol;

			/// <summary>
			/// <para>
			/// Algorithm identifier (ALG_ID) for the bulk encryption cipher used by this connection. The following table describes the
			/// constants valid for this member.
			/// </para>
			/// <list type="table">
			/// <listheader>
			/// <term>Value</term>
			/// <term>Meaning</term>
			/// </listheader>
			/// <item>
			/// <term>CALG_3DES</term>
			/// <term>3DES block encryption algorithm</term>
			/// </item>
			/// <item>
			/// <term>CALG_AES_128</term>
			/// <term>AES 128-bit encryption algorithm</term>
			/// </item>
			/// <item>
			/// <term>CALG_AES_256</term>
			/// <term>AES 256-bit encryption algorithm</term>
			/// </item>
			/// <item>
			/// <term>CALG_DES</term>
			/// <term>DES encryption algorithm</term>
			/// </item>
			/// <item>
			/// <term>CALG_RC2</term>
			/// <term>RC2 block encryption algorithm</term>
			/// </item>
			/// <item>
			/// <term>CALG_RC4</term>
			/// <term>RC4 stream encryption algorithm</term>
			/// </item>
			/// <item>
			/// <term>0 (Zero)</term>
			/// <term>No encryption</term>
			/// </item>
			/// </list>
			/// </summary>
			public ALG_ID aiCipher;

			/// <summary>
			/// Strength of the bulk encryption cipher, in bits. Can be one of the following values: 0, 40, 56, 128, 168, or 256.
			/// </summary>
			public uint dwCipherStrength;

			/// <summary>
			/// <para>
			/// <c>ALG_ID</c> indicating the hash used for generating Message Authentication Codes (MACs). The following table describes the
			/// constants valid for this member.
			/// </para>
			/// <list type="table">
			/// <listheader>
			/// <term>Value</term>
			/// <term>Meaning</term>
			/// </listheader>
			/// <item>
			/// <term>CALG_MD5</term>
			/// <term>MD5 hashing algorithm.</term>
			/// </item>
			/// <item>
			/// <term>CALG_SHA</term>
			/// <term>SHA hashing algorithm.</term>
			/// </item>
			/// </list>
			/// </summary>
			public ALG_ID aiHash;

			/// <summary>Strength of the hash, in bits: 128 or 160.</summary>
			public uint dwHashStrength;

			/// <summary>
			/// <para>
			/// <c>ALG_ID</c> indicating the key exchange algorithm used to generate the shared master secret. The following table describes
			/// the constants valid for this member.
			/// </para>
			/// <list type="table">
			/// <listheader>
			/// <term>Value</term>
			/// <term>Meaning</term>
			/// </listheader>
			/// <item>
			/// <term>CALG_RSA_KEYX</term>
			/// <term>RSA key exchange.</term>
			/// </item>
			/// <item>
			/// <term>CALG_DH_EPHEM</term>
			/// <term>Diffie-Hellman key exchange.</term>
			/// </item>
			/// </list>
			/// </summary>
			public ALG_ID aiExch;

			/// <summary>
			/// Strength of the key exchange, in bits. Typically, this member contains one of the following values: 512, 768, 1024, or 2048.
			/// </summary>
			public uint dwExchStrength;
		}

		/// <summary>
		/// The <c>SecPkgContext_EapKeyBlock</c> structure contains key data used by the EAP TLS Authentication Protocol. For information
		/// about the EAP TLS Authentication Protocol, see http://www.ietf.org/rfc/rfc2716.txt.
		/// </summary>
		// https://docs.microsoft.com/en-us/windows/desktop/api/schannel/ns-schannel-_secpkgcontext_eapkeyblock typedef struct
		// _SecPkgContext_EapKeyBlock { BYTE rgbKeys[128]; BYTE rgbIVs[64]; } SecPkgContext_EapKeyBlock, *PSecPkgContext_EapKeyBlock;
		[PInvokeData("schannel.h", MSDNShortId = "c1b1f1d1-20f9-4a16-a279-b9cc95ff4e64")]
		[StructLayout(LayoutKind.Sequential)]
		public struct SecPkgContext_EapKeyBlock
		{
			/// <summary>An array of 128 bytes that contain key data used by the EAP TLS Authentication Protocol.</summary>
			[MarshalAs(UnmanagedType.ByValArray, SizeConst = 128)]
			public byte[] rgbKeys;

			/// <summary>An array of 64 bytes that contain initialization vector data used by the EAP TLS Authentication Protocol.</summary>
			[MarshalAs(UnmanagedType.ByValArray, SizeConst = 64)]
			public byte[] rgbIVs;
		}

		/// <summary>
		/// The <c>SecPkgContext_EapPrfInfo</c> structure specifies the pseudorandom function (PRF) and extracts key data used by the
		/// Extensible Authentication Protocol (EAP) Transport Layer Security protocol (TLS) Authentication Protocol. For information about
		/// the EAP TLS Authentication Protocol, see http://www.ietf.org/rfc/rfc2716.txt.
		/// </summary>
		// https://docs.microsoft.com/en-us/windows/desktop/api/schannel/ns-schannel-_secpkgcontext_eapprfinfo typedef struct
		// _SecPkgContext_EapPrfInfo { DWORD dwVersion; DWORD cbPrfData; PBYTE pbPrfData; } SecPkgContext_EapPrfInfo, *PSecPkgContext_EapPrfInfo;
		[PInvokeData("schannel.h", MSDNShortId = "2772b83b-d1d1-4a8e-83d5-1f3dec3d66ac")]
		[StructLayout(LayoutKind.Sequential)]
		public struct SecPkgContext_EapPrfInfo
		{
			/// <summary>Reserved. Must be set to zero.</summary>
			public uint dwVersion;

			/// <summary>
			/// <para>The size, in bytes, of the pbPrfData array.</para>
			/// <para>pbPrfData</para>
			/// <para>
			/// A <c>DWORD</c> value that specifies the pseudo-random function and key data used by the EAP protocol. The following are
			/// possible values.
			/// </para>
			/// <list type="table">
			/// <listheader>
			/// <term>Value</term>
			/// <term>Meaning</term>
			/// </listheader>
			/// <item>
			/// <term>PPP EAP TLS Key Data 0x00</term>
			/// <term>PRF(master secret, "client EAP encryption", client_random + server_random)</term>
			/// </item>
			/// <item>
			/// <term>EAP-TTLSv0 Keying Material 0x01</term>
			/// <term>PRF(master_secret, "ttls keying material", server_random + client_random)</term>
			/// </item>
			/// <item>
			/// <term>EAP-TTLSv0 Challenge Data 0x02</term>
			/// <term>PRF(master_secret, "ttls challenge", server_random + client_random)</term>
			/// </item>
			/// <item>
			/// <term>EAP-FAST Keying Material 0x03</term>
			/// <term>PRF(master_secret, "key expansion", server_random + client_random)</term>
			/// </item>
			/// </list>
			/// </summary>
			public uint cbPrfData;

			/// <summary>The pb PRF data</summary>
			public IntPtr pbPrfData;
		}

		/// <summary>
		/// <para>
		/// The <c>SecPkgContext_EarlyStart</c> structure contains information about whether to attempt to use the False Start feature in a
		/// security context.
		/// </para>
		/// <para>See the Building a faster and more secure web blog post for information on this feature.</para>
		/// </summary>
		// https://docs.microsoft.com/en-us/windows/desktop/api/schannel/ns-schannel-_secpkgcontext_earlystart typedef struct
		// _SecPkgContext_EarlyStart { DWORD dwEarlyStartFlags; } SecPkgContext_EarlyStart, *PSecPkgContext_EarlyStart;
		[PInvokeData("schannel.h", MSDNShortId = "5DD5D0B9-CFFF-4743-94EC-A569D265D31F")]
		[StructLayout(LayoutKind.Sequential)]
		public struct SecPkgContext_EarlyStart
		{
			/// <summary>
			/// Determines whether to attempt client-side False Start. Set the value to <c>ENABLE_TLS_CLIENT_EARLY_START</c> (1) to use False Start.
			/// </summary>
			public uint dwEarlyStartFlags;
		}

		/// <summary>
		/// <para>
		/// The <c>SecPkgContext_IssuerListInfoEx</c> structure holds a list of trusted certification authorities (CAs). This structure is
		/// used by the Schannel security package <c>InitializeSecurityContext</c> (Schannel) function.
		/// </para>
		/// <para>This attribute is supported only by the Schannel security support provider (SSP).</para>
		/// <para>
		/// This attribute is available only to client applications and can be queried only after a call to the InitializeSecurityContext
		/// (Schannel) function returns the value <c>SEC_E_INCOMPLETE_CREDENTIALS</c>.
		/// </para>
		/// </summary>
		// https://docs.microsoft.com/en-us/windows/desktop/api/schannel/ns-schannel-_secpkgcontext_issuerlistinfoex typedef struct
		// _SecPkgContext_IssuerListInfoEx { PCERT_NAME_BLOB aIssuers; DWORD cIssuers; } SecPkgContext_IssuerListInfoEx, *PSecPkgContext_IssuerListInfoEx;
		[PInvokeData("schannel.h", MSDNShortId = "cf1ccd40-36bf-4597-b34f-d26cef63d800")]
		[StructLayout(LayoutKind.Sequential, Pack = 4)]
		public struct SecPkgContext_IssuerListInfoEx
		{
			/// <summary>
			/// <para>A pointer to an array of CERT_NAME_BLOB structures that contains a list of the names of CAs that the server trusts.</para>
			/// <para>When you have finished using the data in this array, free it by calling the <c>FreeContextBuffer</c> function.</para>
			/// </summary>
			public IntPtr aIssuers;

			/// <summary>The number of names in <c>aIssuers</c>.</summary>
			public uint cIssuers;

			/// <summary>An array of CERT_NAME_BLOB structures that contains a list of the names of CAs that the server trusts.</summary>
			public CRYPTOAPI_BLOB[] Issuers => aIssuers.ToArray<CRYPTOAPI_BLOB>((int)cIssuers);
		}

		/// <summary>The <c>SecPkgContext_KeyingMaterial</c> structure specifies the exportable keying material for the security context.</summary>
		// https://docs.microsoft.com/en-us/windows/desktop/api/schannel/ns-schannel-_secpkgcontext_keyingmaterial typedef struct
		// _SecPkgContext_KeyingMaterial { DWORD cbKeyingMaterial; PBYTE pbKeyingMaterial; } SecPkgContext_KeyingMaterial, *PSecPkgContext_KeyingMaterial;
		[PInvokeData("schannel.h", MSDNShortId = "2F8C4316-FC03-473C-8A97-83665B3271AC")]
		[StructLayout(LayoutKind.Sequential, CharSet = CharSet.Auto)]
		public struct SecPkgContext_KeyingMaterial
		{
			/// <summary>The length, in bytes, of the keying material to be exported. Must be greater than zero.</summary>
			public uint cbKeyingMaterial;

			/// <summary>
			/// A pointer to the buffer containing the exported keying material. After use, deallocate the buffer by calling FreeContextBuffer.
			/// </summary>
			public IntPtr pbKeyingMaterial;
		}

		/// <summary>The <c>SecPkgContext_KeyingMaterial</c> structure specifies the exportable keying material for the security context.</summary>
		// https://docs.microsoft.com/en-us/windows/desktop/api/schannel/ns-schannel-_secpkgcontext_keyingmaterialinfo typedef struct
		// _SecPkgContext_KeyingMaterialInfo { WORD cbLabel; LPSTR pszLabel; WORD cbContextValue; PBYTE pbContextValue; DWORD
		// cbKeyingMaterial; } SecPkgContext_KeyingMaterialInfo, *PSecPkgContext_KeyingMaterialInfo;
		[PInvokeData("schannel.h", MSDNShortId = "2F8C4316-FC03-473C-8A97-83665B3271AC")]
		[StructLayout(LayoutKind.Sequential, CharSet = CharSet.Ansi)]
		public struct SecPkgContext_KeyingMaterialInfo
		{
			/// <summary>The cb label</summary>
			public ushort cbLabel;

			/// <summary>The PSZ label</summary>
			[MarshalAs(UnmanagedType.LPStr)]
			public string pszLabel;

			/// <summary>The cb context value</summary>
			public ushort cbContextValue;

			/// <summary>The pb context value</summary>
			public IntPtr pbContextValue;

			/// <summary>The length, in bytes, of the keying material to be exported. Must be greater than zero.</summary>
			public uint cbKeyingMaterial;
		}

		/// <summary>
		/// <para>The <c>SecPkgContext_SessionAppData</c> structure stores application data for a session context.</para>
		/// <para>This attribute is supported only by the Schannel security support provider (SSP).</para>
		/// </summary>
		// https://docs.microsoft.com/en-us/windows/desktop/api/schannel/ns-schannel-_secpkgcontext_sessionappdata typedef struct
		// _SecPkgContext_SessionAppData { DWORD dwFlags; DWORD cbAppData; PBYTE pbAppData; } SecPkgContext_SessionAppData, *PSecPkgContext_SessionAppData;
		[PInvokeData("schannel.h", MSDNShortId = "7bda791a-dd60-4651-bfe8-13333017d6a3")]
		[StructLayout(LayoutKind.Sequential)]
		public struct SecPkgContext_SessionAppData
		{
			/// <summary>Reserved for future use.</summary>
			public uint dwFlags;

			/// <summary>Count of bytes used by <c>pbAppData</c>.</summary>
			public uint cbAppData;

			/// <summary>Pointer to a <c>BYTE</c> that represents the session application data.</summary>
			public IntPtr pbAppData;
		}

		/// <summary>Specifies whether the session is a reconnection and retrieves a value that identifies the session.</summary>
		// https://docs.microsoft.com/en-us/windows/desktop/api/schannel/ns-schannel-_secpkgcontext_sessioninfo typedef struct
		// _SecPkgContext_SessionInfo { DWORD dwFlags; DWORD cbSessionId; BYTE rgbSessionId[32]; } SecPkgContext_SessionInfo, *PSecPkgContext_SessionInfo;
		[PInvokeData("schannel.h", MSDNShortId = "d7725803-1f4c-4d5d-8c53-81ec24d5a9d8")]
		[StructLayout(LayoutKind.Sequential, CharSet = CharSet.Auto)]
		public struct SecPkgContext_SessionInfo
		{
			/// <summary>
			/// <para>Bit flags that specify the type of session. The following value is defined.</para>
			/// <list type="table">
			/// <listheader>
			/// <term>Value</term>
			/// <term>Meaning</term>
			/// </listheader>
			/// <item>
			/// <term>SSL_SESSION_RECONNECT 1</term>
			/// <term>The session is a reconnection.</term>
			/// </item>
			/// </list>
			/// </summary>
			public uint dwFlags;

			/// <summary>The size, in bytes, of the <c>rgbSessionId</c> array.</summary>
			public uint cbSessionId;

			/// <summary>An array of up to 32 bytes that identifies the session.</summary>
			[MarshalAs(UnmanagedType.ByValArray, SizeConst = 32)]
			public byte[] rgbSessionId;
		}

		/// <summary>Specifies the signature algorithms supported by an Schannel connection.</summary>
		// https://docs.microsoft.com/en-us/windows/desktop/api/schannel/ns-schannel-secpkgcontext_supportedsignatures typedef struct
		// _SecPkgContext_SupportedSignatures { WORD cSignatureAndHashAlgorithms; WORD *pSignatureAndHashAlgorithms; }
		// SecPkgContext_SupportedSignatures, *PSecPkgContext_SupportedSignatures;
		[PInvokeData("schannel.h", MSDNShortId = "b4b58175-1367-4c91-8680-523a4b125c76")]
		[StructLayout(LayoutKind.Sequential)]
		public struct SecPkgContext_SupportedSignatures
		{
			/// <summary>The number of elements in the pSignatureAndHashAlgorithms array.</summary>
			public ushort cSignatureAndHashAlgorithms;

			/// <summary>
			/// <para>An array of values that specify supported algorithms. These values are in the following format.</para>
			/// <para>The upper byte can be one of the following values that specifies a signature algorithm.</para>
			/// <list type="table">
			/// <listheader>
			/// <term>Value</term>
			/// <term>Meaning</term>
			/// </listheader>
			/// <item>
			/// <term>0</term>
			/// <term>Anonymous signature algorithm.</term>
			/// </item>
			/// <item>
			/// <term>1</term>
			/// <term>The RSA signature algorithm.</term>
			/// </item>
			/// <item>
			/// <term>2</term>
			/// <term>The DSA signature algorithm.</term>
			/// </item>
			/// <item>
			/// <term>3</term>
			/// <term>The ECDSA signature algorithm.</term>
			/// </item>
			/// <item>
			/// <term>255</term>
			/// <term>Reserved.</term>
			/// </item>
			/// </list>
			/// <para>The lower byte can be one of the following values that specifies a hash algorithm.</para>
			/// <list type="table">
			/// <listheader>
			/// <term>Value</term>
			/// <term>Meaning</term>
			/// </listheader>
			/// <item>
			/// <term>0</term>
			/// <term>None.</term>
			/// </item>
			/// <item>
			/// <term>1</term>
			/// <term>The MD5 hash algorithm.</term>
			/// </item>
			/// <item>
			/// <term>2</term>
			/// <term>The SHA1 hash algorithm.</term>
			/// </item>
			/// <item>
			/// <term>3</term>
			/// <term>The SHA-224 hash algorithm.</term>
			/// </item>
			/// <item>
			/// <term>4</term>
			/// <term>The SHA-256 hash algorithm.</term>
			/// </item>
			/// <item>
			/// <term>5</term>
			/// <term>The SHA-384 hash algorithm.</term>
			/// </item>
			/// <item>
			/// <term>6</term>
			/// <term>The SHA-512 hash algorithm.</term>
			/// </item>
			/// <item>
			/// <term>255</term>
			/// <term>Reserved.</term>
			/// </item>
			/// </list>
			/// </summary>
			public IntPtr pSignatureAndHashAlgorithms;
		}

		/// <summary>
		/// The <c>SecPkgCred_CipherStrengths</c> structure holds the minimum and maximum strength permitted for the cipher used by the
		/// specified Schannel credential. This structure is used by the <c>QueryCredentialsAttributes</c> function.
		/// </summary>
		// typedef struct _SecPkgCred_CipherStrengths { DWORD dwMinimumCipherStrength; DWORD dwMaximumCipherStrength;}
		// SecPkgCred_CipherStrengths, *PSecPkgCred_CipherStrengths; https://msdn.microsoft.com/en-us/library/windows/desktop/aa380101(v=vs.85).aspx
		[PInvokeData("Schannel.h", MSDNShortId = "aa380101")]
		[StructLayout(LayoutKind.Sequential)]
		public struct SecPkgCred_CipherStrengths
		{
			/// <summary>Minimum cipher strength allowed.</summary>
			public uint dwMinimumCipherStrength;

			/// <summary>Maximum cipher strength allowed.</summary>
			public uint dwMaximumCipherStrength;
		}

		/// <summary>
		/// The <c>SecPkgCred_SupportedAlgs</c> structure contains identifiers for algorithms permitted with a specified Schannel credential.
		/// This structure is used by the <c>QueryCredentialsAttributes</c> function.
		/// </summary>
		// typedef struct _SecPkgCred_SupportedAlgs { DWORD cSupportedAlgs; ALG_ID *palgSupportedAlgs;} SecPkgCred_SupportedAlgs,
		// *PSecPkgCred_SupportedAlgs; https://msdn.microsoft.com/en-us/library/windows/desktop/aa380102(v=vs.85).aspx
		[PInvokeData("Schannel.h", MSDNShortId = "aa380102")]
		[StructLayout(LayoutKind.Sequential)]
		public struct SecPkgCred_SupportedAlgs
		{
			/// <summary>Number of elements in the <c>palgSupportedAlgs</c> array.</summary>
			public uint cSupportedAlgs;

			/// <summary>Array of algorithm identifiers ( <c>ALG_ID</c>) allowed with a credential.</summary>
			public IntPtr palgSupportedAlgs;
		}

		/// <summary>
		/// The <c>SecPkgCred_SupportedProtocols</c> structure indicates the protocols permitted with a specified Schannel credential. This
		/// structure is used by the <c>QueryCredentialsAttributes</c> function.
		/// </summary>
		// typedef struct _SecPkgCred_SupportedProtocols { DWORD grbitProtocol;} SecPkgCred_SupportedProtocols,
		// *PSecPkgCred_SupportedProtocols; https://msdn.microsoft.com/en-us/library/windows/desktop/aa380103(v=vs.85).aspx
		[PInvokeData("Schannel.h", MSDNShortId = "aa380103")]
		[StructLayout(LayoutKind.Sequential)]
		public struct SecPkgCred_SupportedProtocols
		{
			/// <summary>
			/// <para>Flags representing the protocols supported with this credential. The following table lists the valid values.</para>
			/// <para>
			/// <list type="table">
			/// <listheader>
			/// <term>Value</term>
			/// <term>Meaning</term>
			/// </listheader>
			/// <item>
			/// <term>SP_PROT_TLS1_CLIENT</term>
			/// <term>Transport Layer Security 1.0 client-side.</term>
			/// </item>
			/// <item>
			/// <term>SP_PROT_TLS1_SERVER</term>
			/// <term>Transport Layer Security 1.0 server-side.</term>
			/// </item>
			/// <item>
			/// <term>SP_PROT_SSL3_CLIENT</term>
			/// <term>Secure Sockets Layer 3.0 client-side. Superseded by SP_PROT_TLS1_CLIENT.</term>
			/// </item>
			/// <item>
			/// <term>SP_PROT_SSL3_SERVER</term>
			/// <term>Secure Sockets Layer 3.0 server-side. Superseded by SP_PROT_TLS1_SERVER.</term>
			/// </item>
			/// <item>
			/// <term>SS_PROT_PCT1_CLIENT</term>
			/// <term>Private Communications Technology 1.0 client-side. Obsolete.</term>
			/// </item>
			/// <item>
			/// <term>SP_PROT_PCT1_SERVER</term>
			/// <term>Private Communications Technology 1.0 server-side. Obsolete.</term>
			/// </item>
			/// <item>
			/// <term>SP_PROT_SSL2_CLIENT</term>
			/// <term>Secure Sockets Layer 2.0 client-side. Superseded by SP_PROT_TLS1_CLIENT.</term>
			/// </item>
			/// <item>
			/// <term>SP_PROT_SSL2_SERVER</term>
			/// <term>Secure Sockets Layer 2.0 server-side. Superseded by SP_PROT_TLS1_SERVER.</term>
			/// </item>
			/// </list>
			/// </para>
			/// </summary>
			public SP_PROT grbitProtocol;
		}

		/// <summary>The <c>X509Certificate</c> structure represents an X.509 certificate.</summary>
		// https://docs.microsoft.com/en-us/windows/desktop/api/schannel/ns-schannel-_x509certificate typedef struct _X509Certificate { DWORD
		// Version; DWORD SerialNumber[4]; ALG_ID SignatureAlgorithm; FILETIME ValidFrom; FILETIME ValidUntil; PSTR pszIssuer; PSTR
		// pszSubject; PctPublicKey *pPublicKey; } X509Certificate, *PX509Certificate;
		[PInvokeData("schannel.h", MSDNShortId = "5a337f78-e5de-4ea2-9c15-1056d9e9e38c")]
		[StructLayout(LayoutKind.Sequential, CharSet = CharSet.Ansi)]
		public struct X509Certificate
		{
			/// <summary>The X.509 version number.</summary>
			public uint Version;

			/// <summary>The serial number of the certificate.</summary>
			[MarshalAs(UnmanagedType.ByValArray, SizeConst = 4)]
			public uint[] SerialNumber;

			/// <summary>The ID of the algorithm used to create the digital signature for the certificate.</summary>
			public ALG_ID SignatureAlgorithm;

			/// <summary>The beginning of the period of validity for the certificate.</summary>
			public FILETIME ValidFrom;

			/// <summary>The end of the period of validity for the certificate.</summary>
			public FILETIME ValidUntil;

			/// <summary>A pointer to a string that specifies the issuer of the certificate.</summary>
			[MarshalAs(UnmanagedType.LPStr)]
			public string pszIssuer;

			/// <summary>A pointer to a string that specifies the subject of the certificate.</summary>
			[MarshalAs(UnmanagedType.LPStr)]
			public string pszSubject;

			/// <summary>A pointer to the public key used to create the signature for the certificate.</summary>
			public IntPtr pPublicKey;
		}

		/// <summary>Provides a <see cref="SafeHandle"/> for an Ssl Certificate that is disposed using <see cref="SslFreeCertificate"/>.</summary>
		public class SafeSslCertificate : SafeHANDLE
		{
			/// <summary>Initializes a new instance of the <see cref="SafeSslCertificate"/> class and assigns an existing handle.</summary>
			/// <param name="preexistingHandle">An <see cref="IntPtr"/> object that represents the pre-existing handle to use.</param>
			/// <param name="ownsHandle">
			/// <see langword="true"/> to reliably release the handle during the finalization phase; otherwise, <see langword="false"/> (not recommended).
			/// </param>
			public SafeSslCertificate(IntPtr preexistingHandle, bool ownsHandle = true) : base(preexistingHandle, ownsHandle) { }

			/// <summary>Initializes a new instance of the <see cref="SafeSslCertificate"/> class.</summary>
			private SafeSslCertificate() : base() { }

			/// <summary>
			/// Marshals data from this block of memory to a newly allocated managed object of the type specified by a generic type parameter.
			/// </summary>
			/// <typeparam name="T">The type of the object to which the data is to be copied. This must be a structure.</typeparam>
			/// <returns>A managed object that contains the data that this handle holds.</returns>
			public T ToStructure<T>()
			{
				if (IsInvalid) return default;
				return handle.ToStructure<T>();
			}

			/// <inheritdoc/>
			protected override bool InternalReleaseHandle() { SslFreeCertificate(handle); return true; }
		}
	}
}