using System;
using System.Runtime.InteropServices;
using System.Text;

namespace Vanara.PInvoke
{
	/// <summary>Methods and data types found in NCrypt.dll.</summary>
	public static partial class NCrypt
	{
		/// <summary/>
		public const int NCRYPT_SSL_MAX_NAME_SIZE = 64;

		/// <summary>
		/// The content type that corresponds to this packet, which specifies the higher level protocol used to process the enclosed packet.
		/// </summary>
		[PInvokeData("Sslprovider.h", MSDNShortId = "1002158b-1a4f-4461-978f-b221ef6332e0")]
		public enum PacketContentType
		{
			/// <summary>Indicates a change in the ciphering strategy.</summary>
			CT_CHANGE_CIPHER_SPEC = 20,

			/// <summary>Indicates that the enclosed packet contains an alert.</summary>
			CT_ALERT = 21,

			/// <summary>Indicates that the enclosed packet is part of the handshake protocol.</summary>
			CT_HANDSHAKE = 22,

			/// <summary>Indicates that the packet contains application data.</summary>
			CT_APPLICATIONDATA = 23,
		}

		/// <summary>Specifies the type of host for the call.</summary>
		[PInvokeData("Sslprovider.h")]
		public enum SslHost
		{
			/// <summary>Specifies that this is a client call.</summary>
			NCRYPT_SSL_CLIENT_FLAG = 0x00000001,

			/// <summary>Specifies that this is a server call.</summary>
			NCRYPT_SSL_SERVER_FLAG = 0x00000002,
		}

		/// <summary>CNG SSL Provider Cipher Suite Identifiers</summary>
		[PInvokeData("Sslprovider.h")]
		public enum SslProviderCipherSuiteId
		{
			/// <summary/>
			TLS_RSA_WITH_NULL_MD5 = 0x0001,

			/// <summary/>
			TLS_RSA_WITH_NULL_SHA = 0x0002,

			/// <summary/>
			TLS_RSA_EXPORT_WITH_RC4_40_MD5 = 0x0003,

			/// <summary/>
			TLS_RSA_WITH_RC4_128_MD5 = 0x0004,

			/// <summary/>
			TLS_RSA_WITH_RC4_128_SHA = 0x0005,

			/// <summary/>
			TLS_RSA_WITH_DES_CBC_SHA = 0x0009,

			/// <summary/>
			TLS_RSA_WITH_3DES_EDE_CBC_SHA = 0x000A,

			/// <summary/>
			TLS_DHE_DSS_WITH_DES_CBC_SHA = 0x0012,

			/// <summary/>
			TLS_DHE_DSS_WITH_3DES_EDE_CBC_SHA = 0x0013,

			/// <summary/>
			TLS_DHE_RSA_WITH_3DES_EDE_CBC_SHA = 0x0016,

			/// <summary/>
			TLS_RSA_WITH_AES_128_CBC_SHA = 0x002F,

			/// <summary/>
			TLS_DHE_DSS_WITH_AES_128_CBC_SHA = 0x0032,

			/// <summary/>
			TLS_DHE_RSA_WITH_AES_128_CBC_SHA = 0x0033,

			/// <summary/>
			TLS_RSA_WITH_AES_256_CBC_SHA = 0x0035,

			/// <summary/>
			TLS_DHE_DSS_WITH_AES_256_CBC_SHA = 0x0038,

			/// <summary/>
			TLS_DHE_RSA_WITH_AES_256_CBC_SHA = 0x0039,

			/// <summary/>
			TLS_RSA_EXPORT1024_WITH_DES_CBC_SHA = 0x0062,

			/// <summary/>
			TLS_DHE_DSS_EXPORT1024_WITH_DES_CBC_SHA = 0x0063,

			/// <summary/>
			TLS_RSA_EXPORT1024_WITH_RC4_56_SHA = 0x0064,

			/// <summary/>
			TLS_RSA_WITH_NULL_SHA256 = 0x003B,

			/// <summary/>
			TLS_RSA_WITH_AES_128_CBC_SHA256 = 0x003C,

			/// <summary/>
			TLS_RSA_WITH_AES_256_CBC_SHA256 = 0x003D,

			/// <summary/>
			TLS_DHE_DSS_WITH_AES_128_CBC_SHA256 = 0x0040,

			/// <summary/>
			TLS_DHE_DSS_WITH_AES_256_CBC_SHA256 = 0x006A,

			/// <summary/>
			TLS_PSK_WITH_3DES_EDE_CBC_SHA = 0x008B,

			/// <summary/>
			TLS_PSK_WITH_AES_128_CBC_SHA = 0x008C,

			/// <summary/>
			TLS_PSK_WITH_AES_256_CBC_SHA = 0x008D,

			/// <summary/>
			TLS_RSA_PSK_WITH_3DES_EDE_CBC_SHA = 0x0093,

			/// <summary/>
			TLS_RSA_PSK_WITH_AES_128_CBC_SHA = 0x0094,

			/// <summary/>
			TLS_RSA_PSK_WITH_AES_256_CBC_SHA = 0x0095,

			/// <summary/>
			TLS_ECDHE_ECDSA_WITH_AES_128_CBC_SHA = 0xc009,

			/// <summary/>
			TLS_ECDHE_RSA_WITH_AES_128_CBC_SHA = 0xc013,

			/// <summary/>
			TLS_ECDHE_ECDSA_WITH_AES_256_CBC_SHA = 0xc00a,

			/// <summary/>
			TLS_ECDHE_RSA_WITH_AES_256_CBC_SHA = 0xc014,

			/// <summary/>
			TLS_ECDHE_ECDSA_WITH_AES_128_CBC_SHA256 = 0xC023,

			/// <summary/>
			TLS_ECDHE_ECDSA_WITH_AES_256_CBC_SHA384 = 0xC024,

			/// <summary/>
			TLS_ECDHE_ECDSA_WITH_AES_128_GCM_SHA256 = 0xC02B,

			/// <summary/>
			TLS_ECDHE_ECDSA_WITH_AES_256_GCM_SHA384 = 0xC02C,

			/// <summary/>
			TLS_ECDHE_RSA_WITH_AES_128_CBC_SHA256 = 0xC027,

			/// <summary/>
			TLS_ECDHE_RSA_WITH_AES_256_CBC_SHA384 = 0xC028,

			/// <summary/>
			SSL_CK_RC4_128_WITH_MD5 = 0x010080,

			/// <summary/>
			SSL_CK_RC4_128_EXPORT40_WITH_MD5 = 0x020080,

			/// <summary/>
			SSL_CK_RC2_128_CBC_WITH_MD5 = 0x030080,

			/// <summary/>
			SSL_CK_RC2_128_CBC_EXPORT40_WITH_MD5 = 0x040080,

			/// <summary/>
			SSL_CK_IDEA_128_CBC_WITH_MD5 = 0x050080,

			/// <summary/>
			SSL_CK_DES_64_CBC_WITH_MD5 = 0x060040,

			/// <summary/>
			SSL_CK_DES_192_EDE3_CBC_WITH_MD5 = 0x0700C0,
		}

		/// <summary>CNG SSL Provider Key Type Identifiers</summary>
		[PInvokeData("Sslprovider.h")]
		public enum SslProviderKeyTypeId
		{
			/// <summary/>
			TLS_ECC_P256_CURVE_KEY_TYPE = 23,

			/// <summary/>
			TLS_ECC_P384_CURVE_KEY_TYPE = 24,

			/// <summary/>
			TLS_ECC_P521_CURVE_KEY_TYPE = 25
		}

		/// <summary>CNG SSL Provider Protocol Identifiers</summary>
		[PInvokeData("Sslprovider.h")]
		public enum SslProviderProtocolId
		{
			/// <summary/>
			SSL2_PROTOCOL_VERSION = 0x0002,

			/// <summary/>
			SSL3_PROTOCOL_VERSION = 0x0300,

			/// <summary/>
			TLS1_PROTOCOL_VERSION = 0x0301,

			/// <summary/>
			TLS1_0_PROTOCOL_VERSION = TLS1_PROTOCOL_VERSION,

			/// <summary/>
			TLS1_1_PROTOCOL_VERSION = 0x0302,

			/// <summary/>
			TLS1_2_PROTOCOL_VERSION = 0x0303,

			/// <summary/>
			DTLS1_0_PROTOCOL_VERSION = 0xfeff,
		}

		/// <summary>The <c>SslComputeClientAuthHash</c> function computes a hash to use during certificate authentication.</summary>
		/// <param name="hSslProvider">The handle of the Secure Sockets Layer protocol (SSL) protocol provider instance.</param>
		/// <param name="hMasterKey">The handle of the master key object.</param>
		/// <param name="hHandshakeHash">The handle of the hash of the handshake computed so far.</param>
		/// <param name="pszAlgId">
		/// A pointer to a null-terminated Unicode string that identifies the requested cryptographic algorithm. This can be one of the
		/// standard <c>CNG Algorithm Identifiers</c> or the identifier for another registered algorithm.
		/// </param>
		/// <param name="pbOutput">
		/// The address of a buffer that receives the key BLOB. The cbOutput parameter contains the size of this buffer. If this parameter is
		/// <c>NULL</c>, this function will place the required size, in bytes, in the <c>DWORD</c> pointed to by the pcbResult parameter.
		/// </param>
		/// <param name="cbOutput">The length, in bytes, of the pbOutput buffer.</param>
		/// <param name="pcbResult">
		/// A pointer to a <c>DWORD</c> value that specifies the length, in bytes, of the hash written to the pbOutput buffer.
		/// </param>
		/// <param name="dwFlags">This parameter is reserved for future use.</param>
		/// <returns>
		/// <para>If the function succeeds, it returns zero.</para>
		/// <para>If the function fails, it returns a nonzero error value.</para>
		/// <para>Possible return codes include, but are not limited to, the following.</para>
		/// <list type="table">
		/// <listheader>
		/// <term>Return code/value</term>
		/// <term>Description</term>
		/// </listheader>
		/// <item>
		/// <term>NTE_INVALID_HANDLE 0x80090026L</term>
		/// <term>One of the supplied handles is not valid.</term>
		/// </item>
		/// </list>
		/// </returns>
		/// <remarks>
		/// <para>
		/// The <c>SslComputeClientAuthHash</c> function computes the hash that is sent in the certificate verification message of the SSL
		/// handshake. The hash value is computed by creating a hash that contains the master secret with a hash of all previous handshake
		/// messages sent or received. For more information about the SSL handshake sequence, see Description of the Secure Sockets Layer
		/// (SSL) Handshake.
		/// </para>
		/// <para>
		/// The manner in which the hash is computed depends on the protocol and cipher suite used. In addition, the hash depends on the type
		/// of client authentication key used; the pszAlgId parameter indicates the type of key used for client authentication.
		/// </para>
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows/win32/seccng/sslcomputeclientauthhash SECURITY_STATUS WINAPI SslComputeClientAuthHash(
		// _In_ NCRYPT_PROV_HANDLE hSslProvider, _In_ NCRYPT_KEY_HANDLE hMasterKey, _In_ NCRYPT_HASH_HANDLE hHandshakeHash, _In_ LPCWSTR
		// pszAlgId, _Out_ PBYTE pbOutput, _In_ DWORD cbOutput, _Out_ DWORD *pcbResult, _In_ DWORD dwFlags );
		[DllImport(Lib.Ncrypt, SetLastError = false, ExactSpelling = true)]
		[PInvokeData("Sslprovider.h", MSDNShortId = "f4a12464-8ad6-4bf9-8b6e-49bdf5332b66")]
		public static extern HRESULT SslComputeClientAuthHash(NCRYPT_PROV_HANDLE hSslProvider, NCRYPT_KEY_HANDLE hMasterKey, NCRYPT_HASH_HANDLE hHandshakeHash, [MarshalAs(UnmanagedType.LPWStr)] string pszAlgId, [Out] IntPtr pbOutput, uint cbOutput, out uint pcbResult, uint dwFlags = 0);

		/// <summary>
		/// The <c>SslComputeEapKeyBlock</c> function computes the key block used by the Extensible Authentication Protocol (EAP).
		/// </summary>
		/// <param name="hSslProvider">The handle of the Secure Sockets Layer protocol (SSL) protocol provider instance.</param>
		/// <param name="hMasterKey">The handle of the master key object.</param>
		/// <param name="pbRandoms">
		/// A pointer to a buffer that contains a concatenation of the client_random and server_random values of the SSL session.
		/// </param>
		/// <param name="cbRandoms">The length, in bytes, of the pbRandoms buffer.</param>
		/// <param name="pbOutput">
		/// The address of a buffer that receives the key BLOB. The cbOutput parameter contains the size of this buffer. If this parameter is
		/// <c>NULL</c>, this function will place the required size, in bytes, in the <c>DWORD</c> pointed to by the pcbResult parameter.
		/// </param>
		/// <param name="cbOutput">The length, in bytes, of the pbOutput buffer.</param>
		/// <param name="pcbResult">
		/// A pointer to a <c>DWORD</c> value that specifies the length, in bytes, of the hash written to the pbOutput buffer.
		/// </param>
		/// <param name="dwFlags">Set to <c>NCRYPT_SSL_SERVER_FLAG</c> to indicate that this is a server call.</param>
		/// <returns>
		/// <para>If the function succeeds, it returns zero.</para>
		/// <para>If the function fails, it returns a nonzero error value.</para>
		/// <list type="table">
		/// <listheader>
		/// <term>Return code/value</term>
		/// <term>Description</term>
		/// </listheader>
		/// <item>
		/// <term>NTE_INVALID_HANDLE 0x80090026L</term>
		/// <term>One of the supplied handles is not valid.</term>
		/// </item>
		/// </list>
		/// </returns>
		// https://docs.microsoft.com/en-us/windows/win32/seccng/sslcomputeeapkeyblock SECURITY_STATUS WINAPI SslComputeEapKeyBlock( _In_
		// NCRYPT_PROV_HANDLE hSslProvider, _In_ NCRYPT_KEY_HANDLE hMasterKey, _In_ PBYTE pbRandoms, _In_ DWORD cbRandoms, _Out_opt_ PBYTE
		// pbOutput, _In_ DWORD cbOutput, _Out_ DWORD *pcbResult, _In_ DWORD dwFlags );
		[DllImport(Lib.Ncrypt, SetLastError = false, ExactSpelling = true)]
		[PInvokeData("Sslprovider.h", MSDNShortId = "0f382668-6fc6-440f-ba61-70b1db0f3987")]
		public static extern HRESULT SslComputeEapKeyBlock(NCRYPT_PROV_HANDLE hSslProvider, NCRYPT_KEY_HANDLE hMasterKey, [In] IntPtr pbRandoms, uint cbRandoms, [Optional] IntPtr pbOutput, uint cbOutput, out uint pcbResult, SslHost dwFlags);

		/// <summary>
		/// The <c>SslComputeFinishedHash</c> function computes the hash sent in the finished message of the Secure Sockets Layer protocol
		/// (SSL) handshake. For more information about the SSL handshake sequence, see Description of the Secure Sockets Layer (SSL) Handshake.
		/// </summary>
		/// <param name="hSslProvider">The handle of the SSL protocol provider instance.</param>
		/// <param name="hMasterKey">The handle of the master key object.</param>
		/// <param name="hHandshakeHash">The handle of the hash of the handshake messages.</param>
		/// <param name="pbOutput">A pointer to a buffer that receives the hash for the finish message.</param>
		/// <param name="cbOutput">The length, in bytes, of the pbOutput buffer.</param>
		/// <param name="dwFlags">
		/// <para>One of the following constants.</para>
		/// <list type="table">
		/// <listheader>
		/// <term>Value</term>
		/// <term>Meaning</term>
		/// </listheader>
		/// <item>
		/// <term>NCRYPT_SSL_CLIENT_FLAG 0x00000001</term>
		/// <term>Specifies that this is a client call.</term>
		/// </item>
		/// <item>
		/// <term>NCRYPT_SSL_SERVER_FLAG 0x00000002</term>
		/// <term>Specifies that this is a server call.</term>
		/// </item>
		/// </list>
		/// </param>
		/// <returns>
		/// <para>If the function succeeds, it returns zero.</para>
		/// <para>If the function fails, it returns a nonzero error value.</para>
		/// <list type="table">
		/// <listheader>
		/// <term>Return code/value</term>
		/// <term>Description</term>
		/// </listheader>
		/// <item>
		/// <term>NTE_INVALID_HANDLE 2148073510 (0x80090026)</term>
		/// <term>One of the supplied handles is not valid.</term>
		/// </item>
		/// </list>
		/// </returns>
		/// <remarks>
		/// <para>The <c>SslComputeFinishedHash</c> function is one of three functions used to generate a hash to use during the SSL handshake.</para>
		/// <list type="number">
		/// <item>
		/// <term>The <c>SslCreateHandshakeHash</c> function is called to obtain a hash handle.</term>
		/// </item>
		/// <item>
		/// <term>The <c>SslHashHandshake</c> function is called any number of times with the hash handle to add data to the hash.</term>
		/// </item>
		/// <item>
		/// <term>The <c>SslComputeFinishedHash</c> function is called with the hash handle to obtain the digest of the hashed data.</term>
		/// </item>
		/// </list>
		/// <para>The hash value is computed by hashing the master secret with a hash of all previous handshake messages sent or received.</para>
		/// <para>
		/// The value of cbOutput determines the length of the hash data. When the Transport Layer Security protocol (TLS) 1.0 protocol is
		/// used, this should always be 12 (bytes). For more information, see The TLS Protocol Version 1.0.
		/// </para>
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows/win32/seccng/sslcomputefinishedhash SECURITY_STATUS WINAPI SslComputeFinishedHash( _In_
		// NCRYPT_PROV_HANDLE hSslProvider, _In_ NCRYPT_KEY_HANDLE hMasterKey, _In_ NCRYPT_HASH_HANDLE hHandshakeHash, _Out_ PBYTE pbOutput,
		// _In_ DWORD cbOutput, _In_ DWORD dwFlags );
		[DllImport(Lib.Ncrypt, SetLastError = false, ExactSpelling = true)]
		[PInvokeData("Sslprovider.h", MSDNShortId = "82dfeb1d-c141-40c9-b692-daad78ab6d55")]
		public static extern HRESULT SslComputeFinishedHash(NCRYPT_PROV_HANDLE hSslProvider, NCRYPT_KEY_HANDLE hMasterKey, NCRYPT_HASH_HANDLE hHandshakeHash, [Out] IntPtr pbOutput, uint cbOutput, SslHost dwFlags);

		/// <summary>The <c>SslCreateClientAuthHash</c> function retrieves a handle to the handshake hash that is used for client authentication.</summary>
		/// <param name="hSslProvider">The handle of the Secure Sockets Layer protocol (SSL) protocol provider instance.</param>
		/// <param name="phHandshakeHash">A pointer to an <c>NCRYPT_HASH_HANDLE</c> variable to receive the hash handle.</param>
		/// <param name="dwProtocol">One of the <c>CNG SSL Provider Protocol Identifier</c> values.</param>
		/// <param name="dwCipherSuite">One of the <c>CNG SSL Provider Cipher Suite Identifier</c> values.</param>
		/// <param name="pszHashAlgId">One of the <c>CNG Algorithm Identifiers</c> values.</param>
		/// <param name="dwFlags">This parameter is reserved for future use and must be set to zero.</param>
		/// <returns>
		/// <para>If the function succeeds, it returns zero.</para>
		/// <para>If the function fails, it returns a nonzero error value.</para>
		/// <para>Possible return codes include, but are not limited to, the following.</para>
		/// <list type="table">
		/// <listheader>
		/// <term>Return code/value</term>
		/// <term>Description</term>
		/// </listheader>
		/// <item>
		/// <term>NTE_INVALID_HANDLE 0x80090026L</term>
		/// <term>The hSslProvider parameter contains a pointer that is not valid.</term>
		/// </item>
		/// <item>
		/// <term>NTE_INVALID_PARAMETER 0x80090027L</term>
		/// <term>The phHandshakeHash parameter is set to NULL.</term>
		/// </item>
		/// <item>
		/// <term>NTE_NOT_SUPPORTED 0x80090029L</term>
		/// <term>The selected function is not supported in the specified version of the interface.</term>
		/// </item>
		/// <item>
		/// <term>NTE_NO_MEMORY 0x8009000EL</term>
		/// <term>Insufficient memory to allocate buffers.</term>
		/// </item>
		/// <item>
		/// <term>NTE_BAD_FLAGS 0x80090009L</term>
		/// <term>The dwFlags parameter must be set to zero.</term>
		/// </item>
		/// </list>
		/// </returns>
		/// <remarks>
		/// The <c>SslCreateClientAuthHash</c> function is called for Transport Layer Security protocol (TLS) 1.2 or later conversations to
		/// create hash objects that are used to hash handshake messages. It is called once for each possible hashing algorithm that can be
		/// used in the client authentication signature.
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows/win32/seccng/sslcreateclientauthhash SECURITY_STATUS WINAPI SslCreateClientAuthHash( _In_
		// NCRYPT_PROV_HANDLE hSslProvider, _Out_ NCRYPT_HASH_HANDLE *phHandshakeHash, _In_ DWORD dwProtocol, _In_ DWORD dwCipherSuite, _In_
		// LPCWSTR pszHashAlgId, _In_ DWORD dwFlags );
		[DllImport(Lib.Ncrypt, SetLastError = false, ExactSpelling = true)]
		[PInvokeData("Sslprovider.h", MSDNShortId = "55007ce0-4bf1-4605-9b34-2931935762aa")]
		public static extern HRESULT SslCreateClientAuthHash(NCRYPT_PROV_HANDLE hSslProvider, out NCRYPT_HASH_HANDLE phHandshakeHash, SslProviderProtocolId dwProtocol, SslProviderCipherSuiteId dwCipherSuite, [MarshalAs(UnmanagedType.LPWStr)] string pszHashAlgId, uint dwFlags = 0);

		/// <summary>
		/// The <c>SslCreateEphemeralKey</c> function creates an ephemeral key for use during the authentication that occurs during the
		/// Secure Sockets Layer protocol (SSL) handshake.
		/// </summary>
		/// <param name="hSslProvider">The handle of the SSL protocol provider instance.</param>
		/// <param name="phEphemeralKey">The handle of the ephemeral key.</param>
		/// <param name="dwProtocol">One of the <c>CNG SSL Provider Protocol Identifier</c> values.</param>
		/// <param name="dwCipherSuite">One of the <c>CNG SSL Provider Cipher Suite Identifier</c> values.</param>
		/// <param name="dwKeyType">
		/// One of the <c>CNG SSL Provider Key Type Identifier</c> values. Set this parameter to zero for key types that are not elliptic
		/// curve cryptography (ECC).
		/// </param>
		/// <param name="dwKeyBitLen">The length, in bits, of the key.</param>
		/// <param name="pbParams">
		/// A pointer to a buffer to contain parameters for the key that is to be created. If a Diffie-Hellman (ephemeral) key-exchange
		/// algorithm (DHE) cipher suite is not used, set the pbParams parameter to <c>NULL</c> and the cbParams parameter to zero.
		/// </param>
		/// <param name="cbParams">The length, in bytes, of the data in the pbParams buffer.</param>
		/// <param name="dwFlags">This parameter is reserved for future use.</param>
		/// <returns>
		/// <para>If the function succeeds, it returns zero.</para>
		/// <para>If the function fails, it returns a nonzero error value.</para>
		/// <list type="table">
		/// <listheader>
		/// <term>Return code/value</term>
		/// <term>Description</term>
		/// </listheader>
		/// <item>
		/// <term>NTE_NO_MEMORY 0x8009000EL</term>
		/// <term>There is insufficient memory to allocate the buffer.</term>
		/// </item>
		/// <item>
		/// <term>NTE_INVALID_HANDLE 0x80090026L</term>
		/// <term>The hSslProvider handle is not valid.</term>
		/// </item>
		/// <item>
		/// <term>NTE_INVALID_PARAMETER 0x80090027L</term>
		/// <term>One of the supplied parameters is not valid.</term>
		/// </item>
		/// </list>
		/// </returns>
		/// <remarks>
		/// <para>
		/// When using a DHE cipher suite, the internal SSL implementation passes server p and g parameters to the
		/// <c>SslCreateEphemeralKey</c> function in the pbParams and cbParams parameters.
		/// </para>
		/// <para>
		/// The format of the data in the pbParams buffer is the same as that used when setting the <c>BCRYPT_DH_PARAMETERS</c> property, and
		/// it starts with a <c>BCRYPT_DH_PARAMETER_HEADER</c> structure.
		/// </para>
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows/win32/seccng/sslcreateephemeralkey SECURITY_STATUS WINAPI SslCreateEphemeralKey( _In_
		// NCRYPT_PROV_HANDLE hSslProvider, _Out_ NCRYPT_KEY_HANDLE *phEphemeralKey, _In_ DWORD dwProtocol, _In_ DWORD dwCipherSuite, _In_
		// DWORD dwKeyType, _In_ DWORD dwKeyBitLen, _In_ PBYTE pbParams, _In_ DWORD cbParams, _In_ DWORD dwFlags );
		[DllImport(Lib.Ncrypt, SetLastError = false, ExactSpelling = true)]
		[PInvokeData("Sslprovider.h", MSDNShortId = "faad9b3b-e476-4e61-b978-bcb517ecaeb7")]
		public static extern HRESULT SslCreateEphemeralKey(NCRYPT_PROV_HANDLE hSslProvider, out NCRYPT_KEY_HANDLE phEphemeralKey, SslProviderProtocolId dwProtocol, SslProviderCipherSuiteId dwCipherSuite, SslProviderKeyTypeId dwKeyType, uint dwKeyBitLen, [In] IntPtr pbParams, uint cbParams, uint dwFlags = 0);

		/// <summary>The <c>SslCreateHandshakeHash</c> function obtains a hash handle that is used to hash handshake messages.</summary>
		/// <param name="hSslProvider">The handle of the Secure Sockets Layer protocol (SSL) protocol provider instance.</param>
		/// <param name="phHandshakeHash">A hash handle that can be passed to other SSL provider functions.</param>
		/// <param name="dwProtocol">One of the <c>CNG SSL Provider Protocol Identifier</c> values.</param>
		/// <param name="dwCipherSuite">One of the <c>CNG SSL Provider Cipher Suite Identifier</c> values.</param>
		/// <param name="dwFlags">This parameter is reserved for future use.</param>
		/// <returns>
		/// <para>If the function succeeds, it returns zero.</para>
		/// <para>If the function fails, it returns a nonzero error value.</para>
		/// <para>Possible return codes include, but are not limited to, the following.</para>
		/// <list type="table">
		/// <listheader>
		/// <term>Return code/value</term>
		/// <term>Description</term>
		/// </listheader>
		/// <item>
		/// <term>NTE_NO_MEMORY 0x8009000EL</term>
		/// <term>There is insufficient memory to allocate the hash buffer.</term>
		/// </item>
		/// <item>
		/// <term>NTE_INVALID_HANDLE 0x80090026L</term>
		/// <term>The hSslProvider handle is not valid.</term>
		/// </item>
		/// <item>
		/// <term>NTE_INVALID_PARAMETER 0x80090027L</term>
		/// <term>The phHandshakeHash is null.</term>
		/// </item>
		/// </list>
		/// </returns>
		/// <remarks>
		/// <para>The <c>SslCreateHandshakeHash</c> function is one of three functions used to generate a hash to use during the SSL handshake.</para>
		/// <list type="number">
		/// <item>
		/// <term>The <c>SslCreateHandshakeHash</c> function is called to obtain a hash handle.</term>
		/// </item>
		/// <item>
		/// <term>The <c>SslHashHandshake</c> function is called any number of times with the hash handle to add data to the hash.</term>
		/// </item>
		/// <item>
		/// <term>The <c>SslComputeFinishedHash</c> function is called with the hash handle to obtain the digest of the hashed data.</term>
		/// </item>
		/// </list>
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows/win32/seccng/sslcreatehandshakehash SECURITY_STATUS WINAPI SslCreateHandshakeHash( _In_
		// NCRYPT_PROV_HANDLE hSslProvider, _Out_ NCRYPT_HASH_HANDLE *phHandshakeHash, _In_ DWORD dwProtocol, _In_ DWORD dwCipherSuite, _In_
		// DWORD dwFlags );
		[DllImport(Lib.Ncrypt, SetLastError = false, ExactSpelling = true)]
		[PInvokeData("Sslprovider.h", MSDNShortId = "31390584-9d23-41d1-8604-b84a5e52ecde")]
		public static extern HRESULT SslCreateHandshakeHash(NCRYPT_PROV_HANDLE hSslProvider, out NCRYPT_HASH_HANDLE phHandshakeHash, SslProviderProtocolId dwProtocol, SslProviderCipherSuiteId dwCipherSuite, uint dwFlags = 0);

		/// <summary>
		/// The <c>SslDecrementProviderReferenceCount</c> function decrements the references to the Secure Sockets Layer protocol (SSL) provider.
		/// </summary>
		/// <param name="hSslProvider">The handle of the SSL protocol provider instance.</param>
		/// <returns>
		/// <para>If the function succeeds, it returns zero.</para>
		/// <para>If the function fails, it returns a nonzero error value.</para>
		/// <para>Possible return codes include, but are not limited to, the following.</para>
		/// <list type="table">
		/// <listheader>
		/// <term>Return code/value</term>
		/// <term>Description</term>
		/// </listheader>
		/// <item>
		/// <term>STATUS_INVALID_HANDLE 0xC0000008L</term>
		/// <term>The SSL provider handle is not valid.</term>
		/// </item>
		/// </list>
		/// </returns>
		// https://docs.microsoft.com/en-us/windows/win32/seccng/ssldecrementproviderreferencecount SECURITY_STATUS WINAPI
		// SslDecrementProviderReferenceCount( _In_ NCRYPT_PROV_HANDLE hSslProvider );
		[DllImport(Lib.Ncrypt, SetLastError = false, ExactSpelling = true)]
		[PInvokeData("Sslprovider.h", MSDNShortId = "67bfa4b5-c02c-4a76-871d-93f3bf4e3602")]
		public static extern HRESULT SslDecrementProviderReferenceCount(NCRYPT_PROV_HANDLE hSslProvider);

		/// <summary>the <c>SslDecryptPacket</c> function decrypts a single Secure Sockets Layer protocol (SSL) packet.</summary>
		/// <param name="hSslProvider">The handle of the SSL protocol provider instance.</param>
		/// <param name="hKey">The handle to the key that is used to decrypt the packet.</param>
		/// <param name="pbInput">A pointer to the buffer that contains the packet to be decrypted.</param>
		/// <param name="cbInput">The length, in bytes, of the pbInput buffer.</param>
		/// <param name="pbOutput">A pointer to a buffer to contain the decrypted packet.</param>
		/// <param name="cbOutput">The length, bytes, of the pbOutput buffer.</param>
		/// <param name="pcbResult">The number of bytes written to the pbOutput buffer.</param>
		/// <param name="SequenceNumber">The sequence number that corresponds to this packet.</param>
		/// <param name="dwFlags">This parameter is reserved for future use.</param>
		/// <returns>
		/// <para>If the function succeeds, it returns zero.</para>
		/// <para>If the function fails, it returns a nonzero error value.</para>
		/// <para>Possible return codes include, but are not limited to, the following.</para>
		/// <list type="table">
		/// <listheader>
		/// <term>Return code/value</term>
		/// <term>Description</term>
		/// </listheader>
		/// <item>
		/// <term>NTE_INVALID_HANDLE 0x80090026L</term>
		/// <term>One of the provided handles is not valid.</term>
		/// </item>
		/// </list>
		/// </returns>
		/// <remarks>The length of the packet can be zero, such as when a "HelloRequest" message is decrypted.</remarks>
		// https://docs.microsoft.com/en-us/windows/win32/seccng/ssldecryptpacket SECURITY_STATUS WINAPI SslDecryptPacket( _In_
		// NCRYPT_PROV_HANDLE hSslProvider, _Inout_ NCRYPT_KEY_HANDLE hKey, _In_ PBYTE *pbInput, _In_ DWORD cbInput, _Out_ PBYTE pbOutput,
		// _In_ DWORD cbOutput, _Out_ DWORD *pcbResult, _In_ ULONGLONG SequenceNumber, _In_ DWORD dwFlags );
		[DllImport(Lib.Ncrypt, SetLastError = false, ExactSpelling = true)]
		[PInvokeData("Sslprovider.h", MSDNShortId = "22a7dd2b-d023-47b9-8f76-1c17c2dd6466")]
		public static extern HRESULT SslDecryptPacket(NCRYPT_PROV_HANDLE hSslProvider, NCRYPT_KEY_HANDLE hKey, ref IntPtr pbInput, uint cbInput, [Out] IntPtr pbOutput, uint cbOutput, out uint pcbResult, ulong SequenceNumber, uint dwFlags = 0);

		/// <summary>The <c>SslEncryptPacket</c> function encrypts a single Secure Sockets Layer protocol (SSL) packet.</summary>
		/// <param name="hSslProvider">The handle of the SSL protocol provider instance.</param>
		/// <param name="hKey">The handle to the key that is used to encrypt the packet.</param>
		/// <param name="pbInput">A pointer to the buffer that contains the packet to be encrypted.</param>
		/// <param name="cbInput">The length, in bytes, of the pbInput buffer.</param>
		/// <param name="pbOutput">A pointer to a buffer to receive the encrypted packet.</param>
		/// <param name="cbOutput">The length, bytes, of the pbOutput buffer.</param>
		/// <param name="pcbResult">The number of bytes written to the pbOutput buffer.</param>
		/// <param name="SequenceNumber">The sequence number that corresponds to this packet.</param>
		/// <param name="dwContentType">
		/// <para>
		/// The content type that corresponds to this packet, which specifies the higher level protocol used to process the enclosed packet.
		/// </para>
		/// <list type="table">
		/// <listheader>
		/// <term>Value</term>
		/// <term>Meaning</term>
		/// </listheader>
		/// <item>
		/// <term>CT_CHANGE_CIPHER_SPEC 20</term>
		/// <term>Indicates a change in the ciphering strategy.</term>
		/// </item>
		/// <item>
		/// <term>CT_ALERT 21</term>
		/// <term>Indicates that the enclosed packet contains an alert.</term>
		/// </item>
		/// <item>
		/// <term>CT_HANDSHAKE 22</term>
		/// <term>Indicates that the enclosed packet is part of the handshake protocol.</term>
		/// </item>
		/// <item>
		/// <term>CT_APPLICATIONDATA 23</term>
		/// <term>Indicates that the packet contains application data.</term>
		/// </item>
		/// </list>
		/// </param>
		/// <param name="dwFlags">This parameter is reserved for future use.</param>
		/// <returns>
		/// <para>If the function succeeds, it returns zero.</para>
		/// <para>If the function fails, it returns a nonzero error value.</para>
		/// <para>Possible return codes include, but are not limited to, the following.</para>
		/// <list type="table">
		/// <listheader>
		/// <term>Return code/value</term>
		/// <term>Description</term>
		/// </listheader>
		/// <item>
		/// <term>NTE_INVALID_HANDLE 0x80090026L</term>
		/// <term>One of the provided handles is not valid.</term>
		/// </item>
		/// </list>
		/// </returns>
		// https://docs.microsoft.com/en-us/windows/win32/seccng/sslencryptpacket SECURITY_STATUS WINAPI SslEncryptPacket( _In_
		// NCRYPT_PROV_HANDLE hSslProvider, _Inout_ NCRYPT_KEY_HANDLE hKey, _In_ PBYTE *pbInput, _In_ DWORD cbInput, _Out_ PBYTE pbOutput,
		// _In_ DWORD cbOutput, _Out_ DWORD *pcbResult, _In_ ULONGLONG SequenceNumber, _In_ DWORD dwContentType, _In_ DWORD dwFlags );
		[DllImport(Lib.Ncrypt, SetLastError = false, ExactSpelling = true)]
		[PInvokeData("Sslprovider.h", MSDNShortId = "1002158b-1a4f-4461-978f-b221ef6332e0")]
		public static extern HRESULT SslEncryptPacket(NCRYPT_PROV_HANDLE hSslProvider, NCRYPT_KEY_HANDLE hKey, ref IntPtr pbInput, uint cbInput, [Out] IntPtr pbOutput, uint cbOutput, out uint pcbResult, ulong SequenceNumber, PacketContentType dwContentType, uint dwFlags = 0);

		/// <summary>
		/// The <c>SslEnumCipherSuites</c> function enumerates the cipher suites supported by a Secure Sockets Layer protocol (SSL) protocol provider.
		/// </summary>
		/// <param name="hSslProvider">The handle of the SSL protocol provider instance.</param>
		/// <param name="hPrivateKey">
		/// <para>
		/// The handle of a private key. When a private key is specified, <c>SslEnumCipherSuites</c> enumerates the cipher suites that are
		/// compatible with the private key. For example, if the private key is a DSS key, then only the DSS_DHE cipher suites are returned.
		/// If the private key is an RSA key, but it does not support raw decryption operations, then the SSL2 cipher suites are not returned.
		/// </para>
		/// <para>Set this parameter to <c>NULL</c> when you are not specifying a private key.</para>
		/// </param>
		/// <param name="ppCipherSuite">
		/// A pointer to a <c>NCRYPT_SSL_CIPHER_SUITE</c> structure to receive the address of the next cipher suite in the list.
		/// </param>
		/// <param name="ppEnumState">
		/// <para>A pointer to a buffer that indicates the current position in the list of cipher suites.</para>
		/// <para>
		/// Set the pointer to <c>NULL</c> on the first call to <c>SslEnumCipherSuites</c>. On each subsequent call, pass the unmodified
		/// value back to <c>SslEnumCipherSuites</c>.
		/// </para>
		/// <para>When there are no more cipher suites available, you should free ppEnumState by calling the <c>SslFreeBuffer</c> function.</para>
		/// </param>
		/// <param name="dwFlags">This parameter is reserved for future use.</param>
		/// <returns>
		/// <para>If the function succeeds, it returns zero.</para>
		/// <para>If the function fails, it returns a nonzero error value.</para>
		/// <para>Possible return codes include, but are not limited to, the following.</para>
		/// <list type="table">
		/// <listheader>
		/// <term>Return code/value</term>
		/// <term>Description</term>
		/// </listheader>
		/// <item>
		/// <term>NTE_NO_MEMORY 0x8009000EL</term>
		/// <term>Not enough memory is available to allocate necessary buffers.</term>
		/// </item>
		/// <item>
		/// <term>NTE_INVALID_HANDLE 0x80090026L</term>
		/// <term>One of the provided handles is not valid.</term>
		/// </item>
		/// <item>
		/// <term>NTE_NO_MORE_ITEMS 0x8009002AL</term>
		/// <term>No additional cipher suites are supported.</term>
		/// </item>
		/// </list>
		/// </returns>
		/// <remarks>
		/// To enumerate all cipher suites supported by the SSL provider, call the <c>SslEnumCipherSuites</c> function in a loop until
		/// <c>NTE_NO_MORE_ITEMS</c> is returned.
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows/win32/seccng/sslenumciphersuites SECURITY_STATUS WINAPI SslEnumCipherSuites( _In_
		// NCRYPT_PROV_HANDLE hSslProvider, _In_opt_ NCRYPT_KEY_HANDLE hPrivateKey, _Out_ NCRYPT_SSL_CIPHER_SUITE **ppCipherSuite, _Inout_
		// PVOID *ppEnumState, _In_ DWORD dwFlags );
		[DllImport(Lib.Ncrypt, SetLastError = false, ExactSpelling = true)]
		[PInvokeData("Sslprovider.h", MSDNShortId = "c12bc422-71c9-44f4-abf7-76902b19d3bd")]
		public static extern HRESULT SslEnumCipherSuites(NCRYPT_PROV_HANDLE hSslProvider, [Optional] NCRYPT_KEY_HANDLE hPrivateKey, out IntPtr ppCipherSuite, ref IntPtr ppEnumState, uint dwFlags = 0);

		/// <summary>
		/// The <c>SslEnumProtocolProviders</c> function returns an array of installed Secure Sockets Layer protocol (SSL) protocol providers.
		/// </summary>
		/// <param name="pdwProviderCount">A pointer to a <c>DWORD</c> value to receive the number of protocol providers returned.</param>
		/// <param name="ppProviderList">A pointer to a buffer that receives the array of <c>NCryptProviderName</c> structures.</param>
		/// <param name="dwFlags">This parameter is reserved for future use.</param>
		/// <returns>
		/// <para>If the function succeeds, it returns zero.</para>
		/// <para>If the function fails, it returns a nonzero error value.</para>
		/// <para>Possible return codes include, but are not limited to, the following.</para>
		/// <list type="table">
		/// <listheader>
		/// <term>Return code/value</term>
		/// <term>Description</term>
		/// </listheader>
		/// <item>
		/// <term>NTE_BAD_FLAGS 0x80090009L</term>
		/// <term>The dwFlags parameter is not zero.</term>
		/// </item>
		/// <item>
		/// <term>NTE_NO_MEMORY 0x8009000EL</term>
		/// <term>Not enough memory is available to allocate necessary buffers.</term>
		/// </item>
		/// <item>
		/// <term>NTE_INVALID_PARAMETER 0x80090027L</term>
		/// <term>The pdwProviderCount or ppProviderList parameter is NULL.</term>
		/// </item>
		/// </list>
		/// </returns>
		/// <remarks>
		/// When you have finished using the array of <c>NCryptProviderName</c> structures, call the <c>SslFreeBuffer</c> function to free
		/// the array.
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows/win32/seccng/sslenumprotocolproviders SECURITY_STATUS WINAPI SslEnumProtocolProviders(
		// _Out_ DWORD *pdwProviderCount, _Out_ NCryptProviderName **ppProviderList, _In_ DWORD dwFlags );
		[DllImport(Lib.Ncrypt, SetLastError = false, ExactSpelling = true)]
		[PInvokeData("Sslprovider.h", MSDNShortId = "a61ddcf5-b7e3-40b2-82fc-1cf87eb963ec")]
		public static extern HRESULT SslEnumProtocolProviders(out uint pdwProviderCount, out SafeSslBuffer ppProviderList, uint dwFlags = 0);

		/// <summary>
		/// The <c>SslExportKey</c> function returns an Secure Sockets Layer protocol (SSL) session key or public ephemeral key into a
		/// serialized BLOB.
		/// </summary>
		/// <param name="hSslProvider">The handle of the SSL protocol provider instance.</param>
		/// <param name="hKey">
		/// <para>The handle of the key to export.</para>
		/// <para>When you are not specifying a key, set this parameter to <c>NULL</c>.</para>
		/// </param>
		/// <param name="pszBlobType">
		/// <para>
		/// A null-terminated Unicode string that contains an identifier that specifies the type of BLOB to export. This can be one of the
		/// following values.
		/// </para>
		/// <list type="table">
		/// <listheader>
		/// <term>Value</term>
		/// <term>Meaning</term>
		/// </listheader>
		/// <item>
		/// <term>BCRYPT_DH_PUBLIC_BLOB</term>
		/// <term>
		/// Export a Diffie-Hellman public key. The pbOutput buffer receives a BCRYPT_DH_KEY_BLOB structure immediately followed by the key data.
		/// </term>
		/// </item>
		/// <item>
		/// <term>BCRYPT_ECCPUBLIC_BLOB</term>
		/// <term>
		/// Export an elliptic curve cryptography (ECC) public key. The pbOutput buffer receives a BCRYPT_ECCKEY_BLOB structure immediately
		/// followed by the key data.
		/// </term>
		/// </item>
		/// <item>
		/// <term>BCRYPT_OPAQUE_KEY_BLOB</term>
		/// <term>
		/// Export a symmetric key in a format that is specific to a single cryptographic service provider (CSP). Opaque BLOBs are not
		/// transferable and must be imported by using the same cryptographic service provider (CSP) that generated the BLOB.
		/// </term>
		/// </item>
		/// <item>
		/// <term>BCRYPT_RSAPUBLIC_BLOB</term>
		/// <term>
		/// Export an RSA public key. The pbOutput buffer receives a BCRYPT_RSAKEY_BLOB structure immediately followed by the key data.
		/// </term>
		/// </item>
		/// </list>
		/// </param>
		/// <param name="pbOutput">
		/// The address of a buffer that receives the key BLOB. The cbOutput parameter contains the size of this buffer. If this parameter is
		/// <c>NULL</c>, this function will place the required size, in bytes, in the <c>DWORD</c> pointed to by the pcbResult parameter.
		/// </param>
		/// <param name="cbOutput">The size, in bytes, of the pbOutput buffer.</param>
		/// <param name="pcbResult">
		/// The address of a <c>DWORD</c> variable that receives the number of bytes copied to the pbOutput buffer. If the pbOutput parameter
		/// is set to <c>NULL</c> when the function is called, the required size for the pbOutput buffer, in bytes, is returned in the
		/// <c>DWORD</c> pointed to by this parameter.
		/// </param>
		/// <param name="dwFlags">Reserved for future use.</param>
		/// <returns>
		/// <para>If the function succeeds, it returns zero.</para>
		/// <para>If the function fails, it returns a nonzero error value.</para>
		/// <para>Possible return codes include, but are not limited to, the following.</para>
		/// <list type="table">
		/// <listheader>
		/// <term>Return code/value</term>
		/// <term>Description</term>
		/// </listheader>
		/// <item>
		/// <term>NTE_INVALID_HANDLE 0x80090026L</term>
		/// <term>One of the provided handles is not valid.</term>
		/// </item>
		/// </list>
		/// </returns>
		/// <remarks>
		/// <para>
		/// The <c>SslExportKey</c> function facilitates transporting session keys from one process to another as well as exporting the
		/// public portion an ephemeral key.
		/// </para>
		/// <para>
		/// When exporting session keys, the BLOB type is opaque, meaning that the format of the BLOB is irrelevant as long as both the
		/// <c>SslExportKey</c> and <c>SslImportKey</c> functions can interpret it.
		/// </para>
		/// <para>
		/// When exporting the public portion of an ephemeral key the BLOB type must be the appropriate type, such as
		/// <c>NCRYPT_DH_PUBLIC_BLOB</c> or <c>NCRYPT_ECCPUBLIC_BLOB</c>.
		/// </para>
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows/win32/seccng/sslexportkey SECURITY_STATUS WINAPI SslExportKey( _In_ NCRYPT_PROV_HANDLE
		// hSslProvider, _In_ NCRYPT_KEY_HANDLE hKey, _In_ LPCWSTR pszBlobType, _Out_opt_ PBYTE pbOutput, _In_ DWORD cbOutput, _Out_ DWORD
		// *pcbResult, _In_ DWORD dwFlags );
		[DllImport(Lib.Ncrypt, SetLastError = false, ExactSpelling = true)]
		[PInvokeData("Sslprovider.h", MSDNShortId = "c978e6ac-a535-4625-8598-4aa16484dcad")]
		public static extern HRESULT SslExportKey(NCRYPT_PROV_HANDLE hSslProvider, NCRYPT_KEY_HANDLE hKey, [MarshalAs(UnmanagedType.LPWStr)] string pszBlobType, [Out, Optional] IntPtr pbOutput, uint cbOutput, out uint pcbResult, uint dwFlags = 0);

		/// <summary>
		/// Exports keying material per the RFC 5705 standard. This function uses the TLS pseudorandom function to produce a byte buffer of
		/// keying material. It takes a reference to the master secret, the disambiguating ASCII label, client and server random values, and
		/// optionally the application context data.
		/// </summary>
		/// <param name="hSslProvider">The handle of the TLS protocol provider instance.</param>
		/// <param name="hMasterKey">The handle of the master key object that will be used to create the keying material to br exported.</param>
		/// <param name="sLabel">
		/// a NUL-terminated ASCII label string. Schannel will remove the terminating NUL character before passing it to the pseudorandom function.
		/// </param>
		/// <param name="pbRandoms">
		/// A pointer to a buffer that contains a concatenation of the client_random and server_random values of the TLS connection.
		/// </param>
		/// <param name="cbRandoms">The length, in bytes, of the pbRandoms buffer.</param>
		/// <param name="pbContextValue">
		/// A pointer to a buffer that contains the application context. If pbContextValue is <c>NULL</c>, cbContextValue must be zero.
		/// </param>
		/// <param name="cbContextValue">The length, in bytes, of the pbContextValue buffer.</param>
		/// <param name="pbOutput">
		/// The address of a buffer that receives the exported keying material. The cbOutput parameter contains the size of this buffer. This
		/// value cannot be <c>NULL</c>.
		/// </param>
		/// <param name="cbOutput">The length, in bytes, of the pbOutput buffer. Must be greater than zero.</param>
		/// <param name="dwFlags">Not used. Must be set to zero.</param>
		/// <returns>
		/// <para>If the function succeeds, it returns zero.</para>
		/// <para>If the function fails, it returns a nonzero error value.</para>
		/// <para>Possible return codes include, but are not limited to, the following.</para>
		/// <list type="table">
		/// <listheader>
		/// <term>Return code/value</term>
		/// <term>Description</term>
		/// </listheader>
		/// <item>
		/// <term>NTE_INVALID_HANDLE 0x80090026L</term>
		/// <term>One of the provided handles is not valid.</term>
		/// </item>
		/// </list>
		/// </returns>
		// https://docs.microsoft.com/en-us/windows/win32/seccng/sslexportkeyingmaterial SECURITY_STATUS WINAPI SslExportKeyingMaterial( _In_
		// NCRYPT_PROV_HANDLE hSslProvider, _In_ NCRYPT_KEY_HANDLE hMasterKey, _In_ PCHAR sLabel, _In_ PBYTE pbRandoms, _In_ DWORD cbRandoms,
		// _In_opt_ PBYTE pbContextValue, _In_ WORD cbContextValue, _Out_ PBYTE pbOutput, _In_ DWORD cbOutput, _In_ DWORD dwFlags );
		[DllImport(Lib.Ncrypt, SetLastError = false, ExactSpelling = true)]
		[PInvokeData("Sslprovider.h", MSDNShortId = "19624852-B1A6-4BB4-96AF-0457834DA294")]
		public static extern HRESULT SslExportKeyingMaterial(NCRYPT_PROV_HANDLE hSslProvider, NCRYPT_KEY_HANDLE hMasterKey, [MarshalAs(UnmanagedType.LPStr)] string sLabel, [In] IntPtr pbRandoms, uint cbRandoms, [In, Optional] IntPtr pbContextValue, ushort cbContextValue, [Out] IntPtr pbOutput, uint cbOutput, uint dwFlags = 0);

		/// <summary>
		/// The <c>SslFreeBuffer</c> function is used to free memory that was allocated by one of the Secure Sockets Layer protocol (SSL)
		/// provider functions.
		/// </summary>
		/// <param name="pvInput">A pointer to the memory buffer to be freed.</param>
		/// <returns>
		/// <para>If the function succeeds, it returns zero.</para>
		/// <para>If the function fails, it returns a nonzero error value.</para>
		/// <para>Possible return codes include, but are not limited to, the following.</para>
		/// <list type="table">
		/// <listheader>
		/// <term>Return code/value</term>
		/// <term>Description</term>
		/// </listheader>
		/// <item>
		/// <term>NTE_INVALID_PARAMETER 0x80090027L</term>
		/// <term>The pdwProviderCount or ppProviderList parameter is NULL.</term>
		/// </item>
		/// </list>
		/// </returns>
		// https://docs.microsoft.com/en-us/windows/win32/seccng/sslfreebuffer SECURITY_STATUS WINAPI SslFreeBuffer( _In_ PVOID pvInput );
		[DllImport(Lib.Ncrypt, SetLastError = false, ExactSpelling = true)]
		[PInvokeData("Sslprovider.h", MSDNShortId = "75a85013-c745-43cb-85b5-e13a2778ec1d")]
		public static extern HRESULT SslFreeBuffer(IntPtr pvInput);

		/// <summary>The <c>SslFreeObject</c> function frees a key, hash, or provider object.</summary>
		/// <param name="hObject">The handle of the object to free.</param>
		/// <param name="dwFlags">This parameter is reserved for future use.</param>
		/// <returns>
		/// <para>If the function succeeds, it returns zero.</para>
		/// <para>If the function fails, it returns a nonzero error value.</para>
		/// <para>Possible return codes include, but are not limited to, the following.</para>
		/// <list type="table">
		/// <listheader>
		/// <term>Return code/value</term>
		/// <term>Description</term>
		/// </listheader>
		/// <item>
		/// <term>NTE_INVALID_HANDLE 0x80090026L</term>
		/// <term>An internal handle is not valid.</term>
		/// </item>
		/// <item>
		/// <term>STATUS_INVALID_HANDLE 0xC0000008L</term>
		/// <term>The provided handle is not valid.</term>
		/// </item>
		/// </list>
		/// </returns>
		// https://docs.microsoft.com/en-us/windows/win32/seccng/sslfreeobject SECURITY_STATUS WINAPI SslFreeObject( _In_ NCRYPT_HANDLE
		// hObject, _In_ DWORD dwFlags );
		[DllImport(Lib.Ncrypt, SetLastError = false, ExactSpelling = true)]
		[PInvokeData("Sslprovider.h", MSDNShortId = "73fa0a08-4654-4515-bdb2-9951936b689a")]
		public static extern HRESULT SslFreeObject(NCRYPT_HANDLE hObject, uint dwFlags = 0);

		/// <summary>The <c>SslGenerateMasterKey</c> function computes the Secure Sockets Layer protocol (SSL) master secret key.</summary>
		/// <param name="hSslProvider">The handle to the SSL protocol provider instance.</param>
		/// <param name="hPrivateKey">The handle to the private key used in the exchange.</param>
		/// <param name="hPublicKey">The handle to the public key used in the exchange.</param>
		/// <param name="phMasterKey">A pointer to the handle to the generated master key.</param>
		/// <param name="dwProtocol">One of the <c>CNG SSL Provider Protocol Identifier</c> values.</param>
		/// <param name="dwCipherSuite">One of the <c>CNG SSL Provider Cipher Suite Identifier</c> values.</param>
		/// <param name="pParameterList">
		/// A pointer to an array of <c>NCryptBuffer</c> buffers that contain information used as part of the key exchange operation. The
		/// precise set of buffers is dependent on the protocol and cipher suite that is used. At the minimum, the list will contain buffers
		/// that contain the client and server supplied random values.
		/// </param>
		/// <param name="pbOutput">
		/// The address of a buffer that receives the premaster secret encrypted with the public key of the server. The cbOutput parameter
		/// contains the size of this buffer. If this parameter is <c>NULL</c>, this function returns the required size, in bytes, in the
		/// <c>DWORD</c> pointed to by the pcbResult parameter.
		/// </param>
		/// <param name="cbOutput">The size, in bytes, of the pbOutput buffer.</param>
		/// <param name="pcbResult">A pointer to a <c>DWORD</c> value in which to place number of bytes written to the pbOutput buffer.</param>
		/// <param name="dwFlags">
		/// <para>Specifies whether this function is being used for client-side or server-side key exchange.</para>
		/// <list type="table">
		/// <listheader>
		/// <term>Value</term>
		/// <term>Meaning</term>
		/// </listheader>
		/// <item>
		/// <term>NCRYPT_SSL_CLIENT_FLAG 0x00000001</term>
		/// <term>Specifies a client-side key exchange.</term>
		/// </item>
		/// <item>
		/// <term>NCRYPT_SSL_SERVER_FLAG 0x00000002</term>
		/// <term>Specifies a server-side key exchange.</term>
		/// </item>
		/// </list>
		/// </param>
		/// <returns>
		/// <para>If the function succeeds, it returns zero.</para>
		/// <para>If the function fails, it returns a nonzero error value.</para>
		/// <para>Possible return codes include, but are not limited to, the following.</para>
		/// <list type="table">
		/// <listheader>
		/// <term>Return code/value</term>
		/// <term>Description</term>
		/// </listheader>
		/// <item>
		/// <term>NTE_NO_MEMORY 0x8009000EL</term>
		/// <term>Not enough memory is available to allocate necessary buffers.</term>
		/// </item>
		/// <item>
		/// <term>NTE_INVALID_HANDLE 0x80090026L</term>
		/// <term>One of the provided handles is not valid.</term>
		/// </item>
		/// <item>
		/// <term>NTE_INVALID_PARAMETER 0x80090027L</term>
		/// <term>The phMasterKey or hPublicKey parameter is not valid.</term>
		/// </item>
		/// </list>
		/// </returns>
		// https://docs.microsoft.com/en-us/windows/win32/seccng/sslgeneratemasterkey SECURITY_STATUS WINAPI SslGenerateMasterKey( _In_
		// NCRYPT_PROV_HANDLE hSslProvider, _In_ NCRYPT_KEY_HANDLE hPrivateKey, _In_ NCRYPT_KEY_HANDLE hPublicKey, _Out_ NCRYPT_KEY_HANDLE
		// *phMasterKey, _In_ DWORD dwProtocol, _In_ DWORD dwCipherSuite, _In_ PNCryptBufferDesc pParameterList, _Out_ PBYTE pbOutput, _In_
		// DWORD cbOutput, _Out_ DWORD *pcbResult, _In_ DWORD dwFlags );
		[DllImport(Lib.Ncrypt, SetLastError = false, ExactSpelling = true)]
		[PInvokeData("Sslprovider.h", MSDNShortId = "c9408eb3-711d-42c3-a4ba-e388689da34e")]
		public static extern HRESULT SslGenerateMasterKey(NCRYPT_PROV_HANDLE hSslProvider, NCRYPT_KEY_HANDLE hPrivateKey, NCRYPT_KEY_HANDLE hPublicKey, out NCRYPT_KEY_HANDLE phMasterKey, SslProviderProtocolId dwProtocol, SslProviderCipherSuiteId dwCipherSuite, [In] NCryptBufferDesc pParameterList, [Out] IntPtr pbOutput, uint cbOutput, out uint pcbResult, SslHost dwFlags);

		/// <summary>The <c>SslGenerateSessionKeys</c> function generates a set of Secure Sockets Layer protocol (SSL) session keys.</summary>
		/// <param name="hSslProvider">The handle to the SSL protocol provider instance.</param>
		/// <param name="hMasterKey">The handle to the master key object.</param>
		/// <param name="phReadKey">A pointer to the returned read key handle.</param>
		/// <param name="phWriteKey">A pointer to the returned write key handle.</param>
		/// <param name="pParameterList">
		/// A pointer to an array of <c>NCryptBuffer</c> buffers that contain information used as part of the key exchange operation. The
		/// precise set of buffers is dependent on the protocol and cipher suite that is used. At the minimum, the list will contain buffers
		/// that contain the client and server supplied random values.
		/// </param>
		/// <param name="dwFlags">This parameter is reserved for future use.</param>
		/// <returns>
		/// <para>If the function succeeds, it returns zero.</para>
		/// <para>If the function fails, it returns a nonzero error value.</para>
		/// <para>Possible return codes include, but are not limited to, the following.</para>
		/// <list type="table">
		/// <listheader>
		/// <term>Return code/value</term>
		/// <term>Description</term>
		/// </listheader>
		/// <item>
		/// <term>NTE_NO_MEMORY 0x8009000EL</term>
		/// <term>Not enough memory is available to allocate necessary buffers.</term>
		/// </item>
		/// <item>
		/// <term>NTE_INVALID_HANDLE 0x80090026L</term>
		/// <term>One of the provided handles is not valid.</term>
		/// </item>
		/// <item>
		/// <term>NTE_INVALID_PARAMETER 0x80090027L</term>
		/// <term>The phReadKey or phWriteKey parameter is null.</term>
		/// </item>
		/// </list>
		/// </returns>
		// https://docs.microsoft.com/en-us/windows/win32/seccng/sslgeneratesessionkeys SECURITY_STATUS WINAPI SslGenerateSessionKeys( _In_
		// NCRYPT_PROV_HANDLE hSslProvider, _In_ NCRYPT_KEY_HANDLE hMasterKey, _Out_ NCRYPT_KEY_HANDLE *phReadKey, _Out_ NCRYPT_KEY_HANDLE
		// *phWriteKey, _In_ PNCryptBufferDesc pParameterList, _In_ DWORD dwFlags );
		[DllImport(Lib.Ncrypt, SetLastError = false, ExactSpelling = true)]
		[PInvokeData("Sslprovider.h", MSDNShortId = "88465f30-8591-411e-8618-8a381d4c22e9")]
		public static extern HRESULT SslGenerateSessionKeys(NCRYPT_PROV_HANDLE hSslProvider, NCRYPT_KEY_HANDLE hMasterKey, out NCRYPT_KEY_HANDLE phReadKey, out NCRYPT_KEY_HANDLE phWriteKey, [In] NCryptBufferDesc pParameterList, uint dwFlags = 0);

		/// <summary>
		/// The <c>SslGetCipherSuitePRFHashAlgorithm</c> function returns the Cryptography API: Next Generation (CNG) Algorithm Identifier of
		/// the hashing algorithm that is used for the Transport Layer Security protocol (TLS) pseudo-random function (PRF) for the input
		/// protocol, cipher suite, and key type.
		/// </summary>
		/// <param name="hSslProvider">The handle of the Secure Sockets Layer protocol (SSL) protocol provider instance.</param>
		/// <param name="dwProtocol">One of the <c>CNG SSL Provider Protocol Identifier</c> values.</param>
		/// <param name="dwCipherSuite">One of the <c>CNG SSL Provider Cipher Suite Identifier</c> values.</param>
		/// <param name="dwKeyType">
		/// One of the <c>CNG SSL Provider Key Type Identifier</c> values. For key types that are not elliptic curve cryptography (ECC), set
		/// this parameter to zero.
		/// </param>
		/// <param name="szPRFHash">One of the <c>CNG Algorithm Identifiers</c> for the hash that will be used for the TLS PRF.</param>
		/// <param name="dwFlags">This parameter is reserved for future use and must be set to zero.</param>
		/// <returns>
		/// <para>If the function succeeds, it returns zero.</para>
		/// <para>If the function fails, it returns a nonzero error value.</para>
		/// <para>Possible return codes include, but are not limited to, the following.</para>
		/// <list type="table">
		/// <listheader>
		/// <term>Return code/value</term>
		/// <term>Description</term>
		/// </listheader>
		/// <item>
		/// <term>NTE_INVALID_HANDLE 0x80090026L</term>
		/// <term>The hSslProvider parameter contains a pointer that is not valid.</term>
		/// </item>
		/// <item>
		/// <term>NTE_INVALID_PARAMETER 0x80090027L</term>
		/// <term>The szPRFHash parameter is set to NULL.</term>
		/// </item>
		/// <item>
		/// <term>NTE_NOT_SUPPORTED 0x80090029L</term>
		/// <term>The selected function is not supported in the specified version of the interface.</term>
		/// </item>
		/// <item>
		/// <term>NTE_BAD_FLAGS 0x80090009L</term>
		/// <term>The dwFlags parameter must be set to zero.</term>
		/// </item>
		/// </list>
		/// </returns>
		/// <remarks>
		/// This <c>SslGetCipherSuitePRFHashAlgorithm</c> function is called for TLS 1.2 or later conversations to query the hashing
		/// algorithm that will be used in the TLS PRF.
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows/win32/seccng/sslgetciphersuiteprfhashalgorithm SECURITY_STATUS WINAPI
		// SslGetCipherSuitePRFHashAlgorithm( _In_ NCRYPT_PROV_HANDLE hSslProvider, _In_ DWORD dwProtocol, _In_ DWORD dwCipherSuite, _In_
		// DWORD dwKeyType, _Out_ WCHAR szPRFHash[NCRYPT_SSL_MAX_NAME_SIZE], _In_ DWORD dwFlags );
		[DllImport(Lib.Ncrypt, SetLastError = false, ExactSpelling = true)]
		[PInvokeData("Sslprovider.h", MSDNShortId = "8d20b2da-390e-458e-b122-f5ef3722ad87")]
		public static extern HRESULT SslGetCipherSuitePRFHashAlgorithm(NCRYPT_PROV_HANDLE hSslProvider, SslProviderProtocolId dwProtocol, SslProviderCipherSuiteId dwCipherSuite, SslProviderKeyTypeId dwKeyType, [MarshalAs(UnmanagedType.LPWStr)] StringBuilder szPRFHash, uint dwFlags = 0);

		/// <summary>
		/// The <c>SslGetKeyProperty</c> function retrieves the value of a named property for a Secure Sockets Layer protocol (SSL) provider
		/// key object.
		/// </summary>
		/// <param name="hKey">The handle of the SSL provider.</param>
		/// <param name="pszProperty">
		/// A pointer to a null-terminated Unicode string that contains the name of the property to retrieve. This can be one of the
		/// predefined <c>Key Storage Property Identifiers</c> or a custom property identifier.
		/// </param>
		/// <param name="ppbOutput">
		/// A pointer to a buffer that receives the property value. The caller of the function must free this buffer by calling the
		/// <c>SslFreeBuffer</c> function.
		/// </param>
		/// <param name="pcbOutput">The size, in bytes, of the pbOutput buffer.</param>
		/// <param name="dwFlags">This parameter is reserved for future use.</param>
		/// <returns>
		/// <para>If the function succeeds, it returns zero.</para>
		/// <para>If the function fails, it returns a nonzero error value.</para>
		/// <para>Possible return codes include, but are not limited to, the following.</para>
		/// <list type="table">
		/// <listheader>
		/// <term>Return code/value</term>
		/// <term>Description</term>
		/// </listheader>
		/// <item>
		/// <term>NTE_INVALID_HANDLE 0x80090026L</term>
		/// <term>One of the provided handles is not valid.</term>
		/// </item>
		/// <item>
		/// <term>NTE_INVALID_PARAMETER 0x80090027L</term>
		/// <term>One of the supplied parameters is not valid.</term>
		/// </item>
		/// </list>
		/// </returns>
		// https://docs.microsoft.com/en-us/windows/win32/seccng/sslgetkeyproperty SECURITY_STATUS WINAPI SslGetKeyProperty( _In_
		// NCRYPT_KEY_HANDLE hKey, _In_ LPCWSTR pszProperty, _Out_ PBYTE ppbOutput, _Out_ DWORD *pcbOutput, _In_ DWORD dwFlags );
		[DllImport(Lib.Ncrypt, SetLastError = false, ExactSpelling = true)]
		[PInvokeData("Sslprovider.h", MSDNShortId = "01a7e82a-3888-4f96-85a2-e07811f1895e")]
		public static extern HRESULT SslGetKeyProperty(NCRYPT_KEY_HANDLE hKey, [MarshalAs(UnmanagedType.LPWStr)] string pszProperty, [Out] IntPtr ppbOutput, out uint pcbOutput, uint dwFlags = 0);

		/// <summary>The <c>SslGetProviderProperty</c> function retrieves the value of a specified provider property.</summary>
		/// <param name="hSslProvider">The handle of the Secure Sockets Layer protocol (SSL) provider for which to retrieve the property.</param>
		/// <param name="pszProperty">A pointer to a null-terminated Unicode string that contains the name of the property to retrieve.</param>
		/// <param name="ppbOutput">
		/// <para>The address of a buffer that receives the property value.</para>
		/// <para>The caller of the function must free this buffer by calling the <c>SslFreeBuffer</c> function.</para>
		/// </param>
		/// <param name="pcbOutput">The size, in bytes, of the pbOutput buffer.</param>
		/// <param name="ppEnumState">
		/// <para>
		/// The address of a <c>VOID</c> pointer that receives enumeration state information that is used in subsequent calls to this
		/// function. This information only has meaning to the SSL provider and is opaque to the caller. The SSL provider uses this
		/// information to determine which item is next in the enumeration. If the variable pointed to by this parameter contains
		/// <c>NULL</c>, the enumeration is started from the beginning.
		/// </para>
		/// <para>The caller of the function must free this memory by calling the <c>SslFreeBuffer</c> function.</para>
		/// </param>
		/// <param name="dwFlags">This parameter is reserved for future use.</param>
		/// <returns>
		/// <para>If the function succeeds, it returns zero.</para>
		/// <para>If the function fails, it returns a nonzero error value.</para>
		/// <para>Possible return codes include, but are not limited to, the following.</para>
		/// <list type="table">
		/// <listheader>
		/// <term>Return code/value</term>
		/// <term>Description</term>
		/// </listheader>
		/// <item>
		/// <term>NTE_NO_MEMORY 0x8009000EL</term>
		/// <term>Not enough memory is available to allocate necessary buffers.</term>
		/// </item>
		/// <item>
		/// <term>NTE_INVALID_HANDLE 0x80090026L</term>
		/// <term>The hSslProvider handle is not valid.</term>
		/// </item>
		/// <item>
		/// <term>NTE_INVALID_PARAMETER 0x80090027L</term>
		/// <term>One of the supplied parameters is not valid.</term>
		/// </item>
		/// </list>
		/// </returns>
		// https://docs.microsoft.com/en-us/windows/win32/seccng/sslgetproviderproperty SECURITY_STATUS WINAPI SslGetProviderProperty( _In_
		// NCRYPT_PROV_HANDLE hSslProvider, _In_ LPCWSTR pszProperty, _Out_ PBYTE ppbOutput, _Out_ DWORD *pcbOutput, _Inout_ PVOID
		// *ppEnumState, _In_ DWORD dwFlags );
		[DllImport(Lib.Ncrypt, SetLastError = false, ExactSpelling = true)]
		[PInvokeData("Sslprovider.h", MSDNShortId = "69235520-acaa-4ec4-9fd6-4b3297e14376")]
		public static extern HRESULT SslGetProviderProperty(NCRYPT_PROV_HANDLE hSslProvider, [MarshalAs(UnmanagedType.LPWStr)] string pszProperty, [Out] IntPtr ppbOutput, out uint pcbOutput, ref IntPtr ppEnumState, uint dwFlags = 0);

		/// <summary>The <c>SslHashHandshake</c> function returns a handle to the handshake hash.</summary>
		/// <param name="hSslProvider">The handle to the Secure Sockets Layer protocol (SSL) protocol provider instance.</param>
		/// <param name="hHandshakeHash">The handle to the hash object.</param>
		/// <param name="pbInput">The address of a buffer that contains the data to be hashed.</param>
		/// <param name="cbInput">The size, in bytes, of the pbInput buffer.</param>
		/// <param name="dwFlags">This parameter is reserved for future use.</param>
		/// <returns>If the function succeeds, it returns zero.</returns>
		/// <remarks>
		/// <para>The <c>SslHashHandshake</c> function is one of three functions used to generate a hash to use during the SSL handshake.</para>
		/// <list type="number">
		/// <item>
		/// <term>The <c>SslCreateHandshakeHash</c> function is called to obtain a hash handle.</term>
		/// </item>
		/// <item>
		/// <term>The <c>SslHashHandshake</c> function is called any number of times with the hash handle to add data to the hash.</term>
		/// </item>
		/// <item>
		/// <term>The <c>SslComputeFinishedHash</c> function is called with the hash handle to obtain the digest of the hashed data.</term>
		/// </item>
		/// </list>
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows/win32/seccng/sslhashhandshake SECURITY_STATUS WINAPI SslHashHandshake( _In_
		// NCRYPT_PROV_HANDLE hSslProvider, _Inout_ NCRYPT_HASH_HANDLE hHandshakeHash, _Out_ PBYTE pbInput, _In_ DWORD cbInput, _In_ DWORD
		// dwFlags );
		[DllImport(Lib.Ncrypt, SetLastError = false, ExactSpelling = true)]
		[PInvokeData("Sslprovider.h", MSDNShortId = "c0f20084-c863-42cf-afdf-298c5a96eed9")]
		public static extern HRESULT SslHashHandshake(NCRYPT_PROV_HANDLE hSslProvider, NCRYPT_HASH_HANDLE hHandshakeHash, [Out] IntPtr pbInput, uint cbInput, uint dwFlags = 0);

		/// <summary>The <c>SslImportKey</c> function imports a key into the Secure Sockets Layer protocol (SSL) protocol provider.</summary>
		/// <param name="hSslProvider">The handle to the SSL protocol provider instance.</param>
		/// <param name="phKey">A pointer to the handle of the cryptographic key to receive the imported key.</param>
		/// <param name="pszBlobType">
		/// <para>
		/// A null-terminated Unicode string that contains an identifier that specifies the type of BLOB that is contained in the pbInput
		/// buffer. This can be one of the following values.
		/// </para>
		/// <list type="table">
		/// <listheader>
		/// <term>Value</term>
		/// <term>Meaning</term>
		/// </listheader>
		/// <item>
		/// <term>BCRYPT_DH_PUBLIC_BLOB</term>
		/// <term>
		/// Export a Diffie-Hellman public key. The pbOutput buffer receives a BCRYPT_DH_KEY_BLOB structure immediately followed by the key data.
		/// </term>
		/// </item>
		/// <item>
		/// <term>BCRYPT_ECCPUBLIC_BLOB</term>
		/// <term>
		/// Export an elliptic curve cryptography (ECC) public key. The pbOutput buffer receives a BCRYPT_ECCKEY_BLOB structure immediately
		/// followed by the key data.
		/// </term>
		/// </item>
		/// <item>
		/// <term>BCRYPT_OPAQUE_KEY_BLOB</term>
		/// <term>
		/// Export a symmetric key in a format that is specific to a single cryptographic service provider (CSP). Opaque BLOBs are not
		/// transferable and must be imported by using the same CSP that generated the BLOB.
		/// </term>
		/// </item>
		/// <item>
		/// <term>BCRYPT_RSAPUBLIC_BLOB</term>
		/// <term>
		/// Export an RSA public key. The pbOutput buffer receives a BCRYPT_RSAKEY_BLOB structure immediately followed by the key data.
		/// </term>
		/// </item>
		/// </list>
		/// </param>
		/// <param name="pbKeyBlob">A pointer to the buffer that contains the key BLOB.</param>
		/// <param name="cbKeyBlob">The size, in bytes, of the pbKeyBlob buffer.</param>
		/// <param name="dwFlags">This parameter is reserved for future use.</param>
		/// <returns>
		/// <para>If the function succeeds, it returns zero.</para>
		/// <para>If the function fails, it returns a nonzero error value.</para>
		/// <para>Possible return codes include, but are not limited to, the following.</para>
		/// <list type="table">
		/// <listheader>
		/// <term>Return code/value</term>
		/// <term>Description</term>
		/// </listheader>
		/// <item>
		/// <term>NTE_NO_MEMORY 0x8009000EL</term>
		/// <term>Not enough memory is available to allocate necessary buffers.</term>
		/// </item>
		/// <item>
		/// <term>NTE_INVALID_HANDLE 0x80090026L</term>
		/// <term>The hSslProvider handle is not valid.</term>
		/// </item>
		/// <item>
		/// <term>NTE_INVALID_PARAMETER 0x80090027L</term>
		/// <term>The phKey parameter is NULL.</term>
		/// </item>
		/// </list>
		/// </returns>
		/// <remarks>
		/// You can use the <c>SslImportKey</c> function to import session keys as a part of the process of transferring session keys from
		/// one process to another.
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows/win32/seccng/sslimportkey SECURITY_STATUS WINAPI SslImportKey( _In_ NCRYPT_PROV_HANDLE
		// hSslProvider, _Out_ NCRYPT_KEY_HANDLE *phKey, _In_ LPCWSTR pszBlobType, _In_ PBYTE pbKeyBlob, _In_ DWORD cbKeyBlob, _In_ DWORD
		// dwFlags );
		[DllImport(Lib.Ncrypt, SetLastError = false, ExactSpelling = true)]
		[PInvokeData("Sslprovider.h", MSDNShortId = "42310799-384e-4396-a9d5-5f226ca25a86")]
		public static extern HRESULT SslImportKey(NCRYPT_PROV_HANDLE hSslProvider, out NCRYPT_KEY_HANDLE phKey, [MarshalAs(UnmanagedType.LPWStr)] string pszBlobType, [In] IntPtr pbKeyBlob, uint cbKeyBlob, uint dwFlags = 0);

		/// <summary>The <c>SslImportMasterKey</c> function performs a server-side Secure Sockets Layer protocol (SSL) key exchange operation.</summary>
		/// <param name="hSslProvider">The handle to the SSL protocol provider instance.</param>
		/// <param name="hPrivateKey">The handle to the private key used in the exchange.</param>
		/// <param name="phMasterKey">A pointer to the handle to receive the master key.</param>
		/// <param name="dwProtocol">One of the <c>CNG SSL Provider Protocol Identifier</c> values.</param>
		/// <param name="dwCipherSuite">One of the <c>CNG SSL Provider Cipher Suite Identifiers</c> values.</param>
		/// <param name="pParameterList">
		/// A pointer to an array of <c>NCryptBuffer</c> buffers that contain information used as part of the key exchange operation. The
		/// precise set of buffers is dependent on the protocol and cipher suite that is used. At the minimum, the list will contain buffers
		/// that contain the client and server supplied random values.
		/// </param>
		/// <param name="pbEncryptedKey">
		/// A pointer to a buffer that contains the encrypted premaster secret key encrypted with the public key of the server.
		/// </param>
		/// <param name="cbEncryptedKey">The size, in bytes, of the pbEncryptedKey buffer.</param>
		/// <param name="dwFlags">Set this parameter to <c>NCRYPT_SSL_SERVER_FLAG</c> to indicate that this is a server call.</param>
		/// <returns>
		/// <para>If the function succeeds, it returns zero.</para>
		/// <para>If the function fails, it returns a nonzero error value.</para>
		/// <para>Possible return codes include, but are not limited to, the following.</para>
		/// <list type="table">
		/// <listheader>
		/// <term>Return code/value</term>
		/// <term>Description</term>
		/// </listheader>
		/// <item>
		/// <term>NTE_NO_MEMORY 0x8009000EL</term>
		/// <term>Not enough memory is available to allocate necessary buffers.</term>
		/// </item>
		/// <item>
		/// <term>NTE_INVALID_HANDLE 0x80090026L</term>
		/// <term>One of the provided handles is not valid.</term>
		/// </item>
		/// <item>
		/// <term>NTE_INVALID_PARAMETER 0x80090027L</term>
		/// <term>The phMasterKey parameter is NULL.</term>
		/// </item>
		/// </list>
		/// </returns>
		/// <remarks>
		/// This function decrypts the premaster secret, computes the SSL master secret, and returns a handle to this object to the caller.
		/// This master key can then be used to derive the SSL session key and finish the SSL handshake.
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows/win32/seccng/sslimportmasterkey SECURITY_STATUS WINAPI SslImportMasterKey( _In_
		// NCRYPT_PROV_HANDLE hSslProvider, _In_ NCRYPT_KEY_HANDLE hPrivateKey, _Out_ NCRYPT_KEY_HANDLE *phMasterKey, _In_ DWORD dwProtocol,
		// _In_ DWORD dwCipherSuite, _In_ PNCryptBufferDesc pParameterList, _In_ PBYTE pbEncryptedKey, _In_ DWORD cbEncryptedKey, _In_ DWORD
		// dwFlags );
		[DllImport(Lib.Ncrypt, SetLastError = false, ExactSpelling = true)]
		[PInvokeData("Sslprovider.h", MSDNShortId = "052e38ee-658c-47dc-8098-c9a1fd359e1c")]
		public static extern HRESULT SslImportMasterKey(NCRYPT_PROV_HANDLE hSslProvider, NCRYPT_KEY_HANDLE hPrivateKey, out NCRYPT_KEY_HANDLE phMasterKey, SslProviderProtocolId dwProtocol, SslProviderCipherSuiteId dwCipherSuite, [In] NCryptBufferDesc pParameterList, [In] IntPtr pbEncryptedKey, uint cbEncryptedKey, SslHost dwFlags);

		/// <summary>
		/// The <c>SslIncrementProviderReferenceCount</c> function increments the reference count to a Secure Sockets Layer protocol (SSL)
		/// provider instance.
		/// </summary>
		/// <param name="hSslProvider">The handle to the SSL protocol provider instance.</param>
		/// <returns>
		/// <para>If the function succeeds, it returns zero.</para>
		/// <para>If the function fails, it returns a nonzero error value.</para>
		/// <para>Possible return codes include, but are not limited to, the following.</para>
		/// <list type="table">
		/// <listheader>
		/// <term>Return code/value</term>
		/// <term>Description</term>
		/// </listheader>
		/// <item>
		/// <term>NTE_INVALID_HANDLE 0x80090026L</term>
		/// <term>The hSslProvider handle is not valid.</term>
		/// </item>
		/// </list>
		/// </returns>
		// https://docs.microsoft.com/en-us/windows/win32/seccng/sslincrementproviderreferencecount SECURITY_STATUS WINAPI
		// SslIncrementProviderReferenceCount( _In_ NCRYPT_PROV_HANDLE hSslProvider );
		[DllImport(Lib.Ncrypt, SetLastError = false, ExactSpelling = true)]
		[PInvokeData("Sslprovider.h", MSDNShortId = "67e7b8b4-b073-4936-b1e0-3fc7c1c011a2")]
		public static extern HRESULT SslIncrementProviderReferenceCount(NCRYPT_PROV_HANDLE hSslProvider);

		/// <summary>
		/// The <c>SslLookupCipherLengths</c> function returns an <c>NCRYPT_SSL_CIPHER_LENGTHS</c> structure that contains the header and
		/// trailer lengths of the input protocol, cipher suite, and key type.
		/// </summary>
		/// <param name="hSslProvider">The handle of the Secure Sockets Layer protocol (SSL) protocol provider instance.</param>
		/// <param name="dwProtocol">One of the <c>CNG SSL Provider Protocol Identifier</c> values.</param>
		/// <param name="dwCipherSuite">One of the <c>CNG SSL Provider Cipher Suite Identifier</c> values.</param>
		/// <param name="dwKeyType">
		/// One of the <c>CNG SSL Provider Key Type Identifier</c> values. For key types that are not elliptic curve cryptography (ECC), set
		/// this parameter to zero.
		/// </param>
		/// <param name="pCipherLengths">A pointer to a buffer to receive the <c>NCRYPT_SSL_CIPHER_LENGTHS</c> structure.</param>
		/// <param name="cbCipherLengths">The length, in bytes, of the buffer pointed to by the pCipherLengths parameter.</param>
		/// <param name="dwFlags">This parameter is reserved for future use and must be set to zero.</param>
		/// <returns>
		/// <para>If the function succeeds, it returns zero.</para>
		/// <para>If the function fails, it returns a nonzero error value.</para>
		/// <para>Possible return codes include, but are not limited to, the following.</para>
		/// <list type="table">
		/// <listheader>
		/// <term>Return code/value</term>
		/// <term>Description</term>
		/// </listheader>
		/// <item>
		/// <term>NTE_INVALID_HANDLE 0x80090026L</term>
		/// <term>The hSslProvider parameter contains a pointer that is not valid.</term>
		/// </item>
		/// <item>
		/// <term>NTE_INVALID_PARAMETER 0x80090027L</term>
		/// <term>The pCipherLengths parameter is set to NULL or the buffer length specified by the cbCipherLengths is too short.</term>
		/// </item>
		/// <item>
		/// <term>NTE_BAD_FLAGS 0x80090009L</term>
		/// <term>The dwFlags parameter must be set to zero.</term>
		/// </item>
		/// </list>
		/// </returns>
		/// <remarks>
		/// The <c>SslLookupCipherLengths</c> function is called for Transport Layer Security protocol (TLS) 1.1 or later conversations to
		/// query the header and trailer lengths for the requested protocol, cipher suite, and key type.
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows/win32/seccng/ssllookupcipherlengths SECURITY_STATUS WINAPI SslLookupCipherLengths( _In_
		// NCRYPT_PROV_HANDLE hSslProvider, _In_ DWORD dwProtocol, _In_ DWORD dwCipherSuite, _In_ DWORD dwKeyType, _Out_
		// NCRYPT_SSL_CIPHER_LENGTHS *pCipherLengths, _In_ DWORD cbCipherLengths, _In_ DWORD dwFlags );
		[DllImport(Lib.Ncrypt, SetLastError = false, ExactSpelling = true)]
		[PInvokeData("Sslprovider.h", MSDNShortId = "44d0d803-16d7-4bdf-9638-afbdaf9e1802")]
		public static extern HRESULT SslLookupCipherLengths(NCRYPT_PROV_HANDLE hSslProvider, SslProviderProtocolId dwProtocol, SslProviderCipherSuiteId dwCipherSuite, SslProviderKeyTypeId dwKeyType, ref NCRYPT_SSL_CIPHER_LENGTHS pCipherLengths, uint cbCipherLengths, uint dwFlags = 0);

		/// <summary>
		/// The <c>SslLookupCipherSuiteInfo</c> function retrieves the cipher suite information for a specified protocol, cipher suite, and
		/// key type set.
		/// </summary>
		/// <param name="hSslProvider">The handle to the Secure Sockets Layer protocol (SSL) protocol provider instance.</param>
		/// <param name="dwProtocol">One of the <c>CNG SSL Provider Protocol Identifier</c> values.</param>
		/// <param name="dwCipherSuite">One of the <c>CNG SSL Provider Cipher Suite Identifiers</c> values.</param>
		/// <param name="dwKeyType">One of the <c>CNG SSL Provider Key Type Identifiers</c> values.</param>
		/// <param name="pCipherSuite">
		/// The address of a buffer that contains a <c>NCRYPT_SSL_CIPHER_SUITE</c> structure in which to write the cipher suite information.
		/// </param>
		/// <param name="dwFlags">This parameter is reserved for future use.</param>
		/// <returns>
		/// <para>If the function succeeds, it returns zero.</para>
		/// <para>If the function fails, it returns a nonzero error value.</para>
		/// <para>Possible return codes include, but are not limited to, the following.</para>
		/// <list type="table">
		/// <listheader>
		/// <term>Return code/value</term>
		/// <term>Description</term>
		/// </listheader>
		/// <item>
		/// <term>NTE_INVALID_HANDLE 0x80090026L</term>
		/// <term>The hSslProvider handle is not valid.</term>
		/// </item>
		/// </list>
		/// </returns>
		// https://docs.microsoft.com/en-us/windows/win32/seccng/ssllookupciphersuiteinfo SECURITY_STATUS WINAPI SslLookupCipherSuiteInfo(
		// _In_ NCRYPT_PROV_HANDLE hSslProvider, _In_ DWORD dwProtocol, _In_ DWORD dwCipherSuite, _In_ DWORD dwKeyType, _Out_
		// NCRYPT_SSL_CIPHER_SUITE *pCipherSuite, _In_ DWORD dwFlags );
		[DllImport(Lib.Ncrypt, SetLastError = false, ExactSpelling = true)]
		[PInvokeData("Sslprovider.h", MSDNShortId = "ab995d9a-48fa-491a-95b1-d15c5b92f1da")]
		public static extern HRESULT SslLookupCipherSuiteInfo(NCRYPT_PROV_HANDLE hSslProvider, SslProviderProtocolId dwProtocol, SslProviderCipherSuiteId dwCipherSuite, SslProviderKeyTypeId dwKeyType, out NCRYPT_SSL_CIPHER_SUITE pCipherSuite, uint dwFlags = 0);

		/// <summary>The <c>SslOpenPrivateKey</c> function opens a handle to a private key.</summary>
		/// <param name="hSslProvider">The handle to the Secure Sockets Layer protocol (SSL) protocol provider instance.</param>
		/// <param name="phPrivateKey">
		/// <para>The address of a buffer in which to write the handle to the private key.</para>
		/// <para>When you have finished using the key, you should free phPrivateKey by calling the <c>SslFreeObject</c> function.</para>
		/// </param>
		/// <param name="pCertContext">The address of the certificate from which to obtain the private key.</param>
		/// <param name="dwFlags">This parameter is reserved for future use.</param>
		/// <returns>
		/// <para>If the function succeeds, it returns zero.</para>
		/// <para>If the function fails, it returns a nonzero error value.</para>
		/// <para>Possible return codes include, but are not limited to, the following.</para>
		/// <list type="table">
		/// <listheader>
		/// <term>Return code/value</term>
		/// <term>Description</term>
		/// </listheader>
		/// <item>
		/// <term>NTE_NO_MEMORY 0x8009000EL</term>
		/// <term>Not enough memory is available to allocate necessary buffers.</term>
		/// </item>
		/// <item>
		/// <term>NTE_INVALID_HANDLE 0x80090026L</term>
		/// <term>The hSslProvider handle is not valid.</term>
		/// </item>
		/// <item>
		/// <term>NTE_INVALID_PARAMETER 0x80090027L</term>
		/// <term>The phPrivateKey or pCertContext parameter is NULL.</term>
		/// </item>
		/// </list>
		/// </returns>
		/// <remarks>
		/// The private key obtained is part of a public/private key pair within a certificate. This function merely extracts the private key
		/// from the certificate specified by the pCertContext parameter.
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows/win32/seccng/sslopenprivatekey SECURITY_STATUS WINAPI SslOpenPrivateKey( _In_
		// NCRYPT_PROV_HANDLE hSslProvider, _Out_ NCRYPT_KEY_HANDLE *phPrivateKey, _In_ PCCERT_CONTEXT pCertContext, _In_ DWORD dwFlags );
		[DllImport(Lib.Ncrypt, SetLastError = false, ExactSpelling = true)]
		[PInvokeData("Sslprovider.h", MSDNShortId = "2406be2c-121c-4475-b193-d370a88641da")]
		public static extern HRESULT SslOpenPrivateKey(NCRYPT_PROV_HANDLE hSslProvider, out NCRYPT_KEY_HANDLE phPrivateKey, in Crypt32.CERT_CONTEXT pCertContext, uint dwFlags = 0);

		/// <summary>
		/// The <c>SslOpenProvider</c> function opens a handle to the specified Secure Sockets Layer protocol (SSL) protocol provider.
		/// </summary>
		/// <param name="phSslProvider">
		/// <para>The address of an <c>NCRYPT_PROV_HANDLE</c> in which to write the provider handle.</para>
		/// <para>When you have finished using the handle, you should free it by calling the <c>SslFreeObject</c> function.</para>
		/// </param>
		/// <param name="pszProviderName">
		/// A pointer to a Unicode string that contains the provider name. If the value of this parameter is <c>NULL</c>, a handle to the
		/// <c>MS_SCHANNEL_PROVIDER</c> is returned.
		/// </param>
		/// <param name="dwFlags">This parameter is reserved for future use, and it must be set to zero.</param>
		/// <returns>
		/// <para>If the function succeeds, it returns zero.</para>
		/// <para>If the function fails, it returns a nonzero error value.</para>
		/// <para>Possible return codes include, but are not limited to, the following.</para>
		/// <list type="table">
		/// <listheader>
		/// <term>Return code/value</term>
		/// <term>Description</term>
		/// </listheader>
		/// <item>
		/// <term>NTE_INVALID_HANDLE 0x80090026L</term>
		/// <term>One of the provided handles is not valid.</term>
		/// </item>
		/// <item>
		/// <term>NTE_INVALID_PARAMETER 0x80090027L</term>
		/// <term>The phSslProvider or ppProviderList parameter is NULL.</term>
		/// </item>
		/// <item>
		/// <term>STATUS_NO_MEMORY 0xC0000017L</term>
		/// <term>Not enough memory is available to allocate necessary buffers.</term>
		/// </item>
		/// </list>
		/// </returns>
		// https://docs.microsoft.com/en-us/windows/win32/seccng/sslopenprovider SECURITY_STATUS WINAPI SslOpenProvider( _Out_
		// NCRYPT_PROV_HANDLE *phSslProvider, _In_ LPCWSTR pszProviderName, _In_ DWORD dwFlags );
		[DllImport(Lib.Ncrypt, SetLastError = false, ExactSpelling = true)]
		[PInvokeData("Sslprovider.h", MSDNShortId = "0d5c4da3-12d6-4a53-a4d0-f0f174a4c8d8")]
		public static extern HRESULT SslOpenProvider(out NCRYPT_PROV_HANDLE phSslProvider, [MarshalAs(UnmanagedType.LPWStr)] string pszProviderName, uint dwFlags = 0);

		/// <summary>
		/// The <c>SslSignHash</c> function signs a hash by using the specified private key. The signing process is performed on the server.
		/// </summary>
		/// <param name="hSslProvider">The handle to the Secure Sockets Layer protocol (SSL) protocol provider instance.</param>
		/// <param name="hPrivateKey">The handle to the private key to use to sign the hash.</param>
		/// <param name="pbHashValue">A pointer to a buffer that contains the hash to sign.</param>
		/// <param name="cbHashValue">The size, in bytes, of the pbHashValue buffer.</param>
		/// <param name="pbSignature">
		/// The address of a buffer that receives the signature of the hash. The cbSignature parameter contains the size of this buffer. To
		/// determine the required sized size of the buffer, set the pbSignature parameter to <c>NULL</c>. The required size of the buffer
		/// will be returned in the pcbResult parameter.
		/// </param>
		/// <param name="cbSignature">The size, in bytes, of the pbSignature buffer.</param>
		/// <param name="pcbResult">
		/// A pointer to a value that, upon completion, contains the actual number of bytes written to the pbSignature buffer.
		/// </param>
		/// <param name="dwFlags">This parameter is reserved for future use.</param>
		/// <returns>
		/// <para>If the function succeeds, it returns zero.</para>
		/// <para>If the function fails, it returns a nonzero error value.</para>
		/// <para>Possible return codes include, but are not limited to, the following.</para>
		/// <list type="table">
		/// <listheader>
		/// <term>Return code/value</term>
		/// <term>Description</term>
		/// </listheader>
		/// <item>
		/// <term>NTE_INVALID_HANDLE 0x80090026L</term>
		/// <term>One of the provided handles is not valid.</term>
		/// </item>
		/// </list>
		/// </returns>
		// https://docs.microsoft.com/en-us/windows/win32/seccng/sslsignhash SECURITY_STATUS WINAPI SslSignHash( _In_ NCRYPT_PROV_HANDLE
		// hSslProvider, _In_ NCRYPT_KEY_HANDLE hPrivateKey, _In_ PBYTE pbHashValue, _In_ DWORD cbHashValue, _Out_ PBYTE pbSignature, _In_
		// DWORD cbSignature, _Out_ DWORD *pcbResult, _In_ DWORD dwFlags );
		[DllImport(Lib.Ncrypt, SetLastError = false, ExactSpelling = true)]
		[PInvokeData("Sslprovider.h", MSDNShortId = "25e8ebc5-278d-4d1f-977a-c2fab07b790a")]
		public static extern HRESULT SslSignHash(NCRYPT_PROV_HANDLE hSslProvider, NCRYPT_KEY_HANDLE hPrivateKey, [In] IntPtr pbHashValue, uint cbHashValue, [Out] IntPtr pbSignature, uint cbSignature, out uint pcbResult, uint dwFlags = 0);

		/// <summary>
		/// The <c>SslVerifySignature</c> function verifies the specified signature by using the supplied hash and the public key.
		/// </summary>
		/// <param name="hSslProvider">The handle to the Secure Sockets Layer protocol (SSL) protocol provider instance.</param>
		/// <param name="hPublicKey">The handle to the public key.</param>
		/// <param name="pbHashValue">A pointer to a buffer that contains the hash to use to verify the signature.</param>
		/// <param name="cbHashValue">The size, in bytes, of the pbHashValue buffer.</param>
		/// <param name="pbSignature">A pointer to a buffer that contains the signature to verify.</param>
		/// <param name="cbSignature">The size, in bytes, of the pbSignature buffer.</param>
		/// <param name="dwFlags">This parameter is reserved for future use.</param>
		/// <returns>
		/// <para>If the function succeeds, it returns zero.</para>
		/// <para>If the function fails, it returns a nonzero error value.</para>
		/// <para>Possible return codes include, but are not limited to, the following.</para>
		/// <list type="table">
		/// <listheader>
		/// <term>Return code/value</term>
		/// <term>Description</term>
		/// </listheader>
		/// <item>
		/// <term>NTE_INVALID_HANDLE 0x80090026L</term>
		/// <term>One of the provided handles is not valid.</term>
		/// </item>
		/// </list>
		/// </returns>
		/// <remarks>
		/// <para>
		/// The <c>SslVerifySignature</c> function is not currently called by Windows. This function is a required part of the SSL Provider
		/// interface and should be fully implemented to ensure forward compatibility.
		/// </para>
		/// <para>
		/// Current implementations of the server side of the Transport Layer Security protocol (TLS) connection call the
		/// <c>NCryptVerifySignature</c> function during the client authentication to process the certificate verify message.
		/// </para>
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows/win32/seccng/sslverifysignature SECURITY_STATUS WINAPI SslVerifySignature( _In_
		// NCRYPT_PROV_HANDLE hSslProvider, _In_ NCRYPT_KEY_HANDLE hPublicKey, _In_ PBYTE pbHashValue, _In_ DWORD cbHashValue, _In_ PBYTE
		// pbSignature, _In_ DWORD cbSignature, _In_ DWORD dwFlags );
		[DllImport(Lib.Ncrypt, SetLastError = false, ExactSpelling = true)]
		[PInvokeData("Sslprovider.h", MSDNShortId = "fa274851-15f2-4be0-9e2f-4cdced36daff")]
		public static extern HRESULT SslVerifySignature(NCRYPT_PROV_HANDLE hSslProvider, NCRYPT_KEY_HANDLE hPublicKey, [In] IntPtr pbHashValue, uint cbHashValue, [In] IntPtr pbSignature, uint cbSignature, uint dwFlags = 0);

		/// <summary>Contains the header and trailer lengths of the input protocol, cipher suite, and key type.</summary>
		[PInvokeData("Sslprovider.h", MSDNShortId = "44d0d803-16d7-4bdf-9638-afbdaf9e1802")]
		[StructLayout(LayoutKind.Sequential)]
		public struct NCRYPT_SSL_CIPHER_LENGTHS
		{
			/// <summary/>
			public uint cbLength;

			/// <summary/>
			public uint dwHeaderLen;

			/// <summary/>
			public uint dwFixedTrailerLen;

			/// <summary/>
			public uint dwMaxVariableTrailerLen;

			/// <summary/>
			public uint dwFlags;
		}

		/// <summary>The cipher suite information for a specified protocol, cipher suite, and key type set.</summary>
		[PInvokeData("Sslprovider.h", MSDNShortId = "ab995d9a-48fa-491a-95b1-d15c5b92f1da")]
		[StructLayout(LayoutKind.Sequential, CharSet = CharSet.Unicode)]
		public struct NCRYPT_SSL_CIPHER_SUITE
		{
			/// <summary/>
			public SslProviderProtocolId dwProtocol;

			/// <summary/>
			public SslProviderCipherSuiteId dwCipherSuite;

			/// <summary/>
			public SslProviderCipherSuiteId dwBaseCipherSuite;

			/// <summary/>
			[MarshalAs(UnmanagedType.ByValTStr, SizeConst = NCRYPT_SSL_MAX_NAME_SIZE)]
			public string szCipherSuite;

			/// <summary/>
			[MarshalAs(UnmanagedType.ByValTStr, SizeConst = NCRYPT_SSL_MAX_NAME_SIZE)]
			public string szCipher;

			/// <summary/>
			public uint dwCipherLen;

			/// <summary/>
			public uint dwCipherBlockLen;

			/// <summary/>
			[MarshalAs(UnmanagedType.ByValTStr, SizeConst = NCRYPT_SSL_MAX_NAME_SIZE)]
			public string szHash;

			/// <summary/>
			public uint dwHashLen;

			/// <summary/>
			[MarshalAs(UnmanagedType.ByValTStr, SizeConst = NCRYPT_SSL_MAX_NAME_SIZE)]
			public string szExchange;

			/// <summary/>
			public uint dwMinExchangeLen;

			/// <summary/>
			public uint dwMaxExchangeLen;

			/// <summary/>
			[MarshalAs(UnmanagedType.ByValTStr, SizeConst = NCRYPT_SSL_MAX_NAME_SIZE)]
			public string szCertificate;

			/// <summary/>
			public SslProviderKeyTypeId dwKeyType;
		}

		/// <summary>Provides a <see cref="SafeHandle"/> for an SSL buffer that is disposed using <see cref="SslFreeBuffer"/>.</summary>
		public class SafeSslBuffer : SafeHANDLE
		{
			/// <summary>Initializes a new instance of the <see cref="SafeSslBuffer"/> class and assigns an existing handle.</summary>
			/// <param name="preexistingHandle">An <see cref="IntPtr"/> object that represents the pre-existing handle to use.</param>
			/// <param name="ownsHandle">
			/// <see langword="true"/> to reliably release the handle during the finalization phase; otherwise, <see langword="false"/> (not recommended).
			/// </param>
			public SafeSslBuffer(IntPtr preexistingHandle, bool ownsHandle = true) : base(preexistingHandle, ownsHandle) { }

			/// <summary>Initializes a new instance of the <see cref="SafeSslBuffer"/> class.</summary>
			private SafeSslBuffer() : base() { }

			/// <inheritdoc/>
			protected override bool InternalReleaseHandle() => SslFreeBuffer(handle).Succeeded;
		}
	}
}