namespace Vanara.PInvoke;

/// <summary>Methods and data types found in Crypt32.dll.</summary>
public static partial class Crypt32
{
	/// <summary>
	/// <para>
	/// [The <c>PCRYPT_DECRYPT_PRIVATE_KEY_FUNC</c> function is available for use in the operating systems specified in the Requirements
	/// section. It may be altered or unavailable in subsequent versions.]
	/// </para>
	/// <para>
	/// The <c>PCRYPT_DECRYPT_PRIVATE_KEY_FUNC</c> function decrypts the private key and returns the decrypted key in the pbClearTextKey
	/// parameter. <c>PCRYPT_DECRYPT_PRIVATE_KEY_FUNC</c> is a callback function specified in a CRYPT_PKCS8_IMPORT_PARAMS structure. It
	/// is used when a CRYPT_ENCRYPTED_PRIVATE_KEY_INFO structure contains a private key that needs to be decrypted. The
	/// CryptImportPKCS8 function uses this function. The function must be implemented by the developer to suit each application.
	/// </para>
	/// </summary>
	/// <param name="Algorithm">
	/// A CRYPT_ALGORITHM_IDENTIFIER structure that identifies the algorithm used to encrypt the PrivateKeyInfo ASN.1 type found in the
	/// PKCS #8 standard.
	/// </param>
	/// <param name="EncryptedPrivateKey">A CRYPT_DATA_BLOB value that identifies the encrypted private key BLOB.</param>
	/// <param name="pbClearTextKey">A buffer to receive the clear text.</param>
	/// <param name="pcbClearTextKey">
	/// The number of bytes of the pClearTextKey buffer. Note: if this is zero then this should be filled in with the size required to
	/// decrypt the key into, and pClearTextKey should be ignored.
	/// </param>
	/// <param name="pVoidDecryptFunc">
	/// An <c>LPVOID</c> value that provides data used in decryption, such as key, initialization vector, and password.
	/// </param>
	/// <returns>
	/// <para>If the function succeeds, the function returns nonzero ( <c>TRUE</c>).</para>
	/// <para>If the function fails, it returns zero ( <c>FALSE</c>).</para>
	/// </returns>
	// https://docs.microsoft.com/en-us/windows/win32/api/wincrypt/nc-wincrypt-pcrypt_decrypt_private_key_func
	// PCRYPT_DECRYPT_PRIVATE_KEY_FUNC PcryptDecryptPrivateKeyFunc; BOOL PcryptDecryptPrivateKeyFunc( CRYPT_ALGORITHM_IDENTIFIER
	// Algorithm, CRYPT_DATA_BLOB EncryptedPrivateKey, BYTE *pbClearTextKey, DWORD *pcbClearTextKey, LPVOID pVoidDecryptFunc ) {...}
	[PInvokeData("wincrypt.h", MSDNShortId = "f59fd46b-5430-4aa2-85ba-961b416dbaac")]
	[return: MarshalAs(UnmanagedType.Bool)]
	public delegate bool PCRYPT_DECRYPT_PRIVATE_KEY_FUNC(CRYPT_ALGORITHM_IDENTIFIER Algorithm, CRYPTOAPI_BLOB EncryptedPrivateKey, IntPtr pbClearTextKey, ref uint pcbClearTextKey, IntPtr pVoidDecryptFunc);

	/// <summary>
	/// <para>
	/// [The <c>PCRYPT_ENCRYPT_PRIVATE_KEY_FUNC</c> function is available for use in the operating systems specified in the Requirements
	/// section. It may be altered or unavailable in subsequent versions.]
	/// </para>
	/// <para>
	/// The <c>PCRYPT_ENCRYPT_PRIVATE_KEY_FUNC</c> function encrypts the private key and returns the encrypted contents in the
	/// pbEncryptedKey parameter. It is a callback function identified in a CRYPT_PKCS8_EXPORT_PARAMS structure that creates a PKCS #8
	/// CRYPT_ENCRYPTED_PRIVATE_KEY_INFO structure. The function must be implemented by the developer to suit each application.
	/// </para>
	/// </summary>
	/// <param name="pAlgorithm"/>
	/// <param name="pClearTextPrivateKey"/>
	/// <param name="pbEncryptedKey"/>
	/// <param name="pcbEncryptedKey"/>
	/// <param name="pVoidEncryptFunc">
	/// An <c>LPVOID</c> variable that contains data used for encryption, such as key, initialization vector, and password.
	/// </param>
	/// <returns>
	/// <para>If the function succeeds, the function returns nonzero ( <c>TRUE</c>).</para>
	/// <para>If the function fails, it returns zero ( <c>FALSE</c>).</para>
	/// </returns>
	// https://docs.microsoft.com/en-us/windows/win32/api/wincrypt/nc-wincrypt-pcrypt_encrypt_private_key_func
	// PCRYPT_ENCRYPT_PRIVATE_KEY_FUNC PcryptEncryptPrivateKeyFunc; BOOL PcryptEncryptPrivateKeyFunc( CRYPT_ALGORITHM_IDENTIFIER
	// *pAlgorithm, CRYPT_DATA_BLOB *pClearTextPrivateKey, BYTE *pbEncryptedKey, DWORD *pcbEncryptedKey, LPVOID pVoidEncryptFunc ) {...}
	[PInvokeData("wincrypt.h", MSDNShortId = "aa6b8bca-4f0d-491e-ab38-5c273a01ca05")]
	[return: MarshalAs(UnmanagedType.Bool)]
	public delegate bool PCRYPT_ENCRYPT_PRIVATE_KEY_FUNC(ref CRYPT_ALGORITHM_IDENTIFIER pAlgorithm, ref CRYPTOAPI_BLOB pClearTextPrivateKey, IntPtr pbEncryptedKey, ref uint pcbEncryptedKey, IntPtr pVoidEncryptFunc);

	/// <summary>
	/// <para>
	/// [The <c>PCRYPT_RESOLVE_HCRYPTPROV_FUNC</c> function is available for use in the operating systems specified in the Requirements
	/// section. It may be altered or unavailable in subsequent versions.]
	/// </para>
	/// <para>
	/// The <c>PCRYPT_RESOLVE_HCRYPTPROV_FUNC</c> function returns a handle to a cryptographic service provider (CSP) by using the
	/// phCryptProv parameter to receive the key being imported. It is a callback function called from the context of the
	/// CryptImportPKCS8 function. The function must be implemented by the developer to suit each application.
	/// </para>
	/// </summary>
	/// <param name="pPrivateKeyInfo">
	/// Pointer to a CRYPT_PRIVATE_KEY_INFO structure which describes the key being imported and whose PrivateKey field contains the
	/// encrypted private key blob.
	/// </param>
	/// <param name="phCryptProv">A pointer to a HCRRYPTPROV to be filled in.</param>
	/// <param name="pVoidResolveFunc">
	/// The <c>pVoidResolveFunc</c> member passed in by the caller in the CRYPT_PKCS8_IMPORT_PARAMS structure.
	/// </param>
	/// <returns>
	/// <para>If the function succeeds, the function returns nonzero ( <c>TRUE</c>).</para>
	/// <para>If the function fails, it returns zero ( <c>FALSE</c>).</para>
	/// </returns>
	// https://docs.microsoft.com/en-us/windows/win32/api/wincrypt/nc-wincrypt-pcrypt_resolve_hcryptprov_func BOOL
	// PCRYPT_RESOLVE_HCRYPTPROV_FUNC( CRYPT_PRIVATE_KEY_INFO *pPrivateKeyInfo, HCRYPTPROV *phCryptProv, LPVOID pVoidResolveFunc );
	[PInvokeData("wincrypt.h", MSDNShortId = "d3b2b942-bde5-4399-9412-95fe227cd546")]
	[return: MarshalAs(UnmanagedType.Bool)]
	public delegate bool PCRYPT_RESOLVE_HCRYPTPROV_FUNC(in CRYPT_PRIVATE_KEY_INFO pPrivateKeyInfo, ref HCRYPTPROV phCryptProv, IntPtr pVoidResolveFunc);

	/// <summary>The intended key usage.</summary>
	[PInvokeData("wincrypt.h", MSDNShortId = "d09c3626-f864-4774-8511-3e912f62e520")]
	[Flags]
	public enum CertKeyUsage : ushort
	{
		/// <summary/>
		CERT_DIGITAL_SIGNATURE_KEY_USAGE = 0x80,

		/// <summary/>
		CERT_NON_REPUDIATION_KEY_USAGE = 0x40,

		/// <summary/>
		CERT_KEY_ENCIPHERMENT_KEY_USAGE = 0x20,

		/// <summary/>
		CERT_DATA_ENCIPHERMENT_KEY_USAGE = 0x10,

		/// <summary/>
		CERT_KEY_AGREEMENT_KEY_USAGE = 0x08,

		/// <summary/>
		CERT_KEY_CERT_SIGN_KEY_USAGE = 0x04,

		/// <summary/>
		CERT_OFFLINE_CRL_SIGN_KEY_USAGE = 0x02,

		/// <summary/>
		CERT_CRL_SIGN_KEY_USAGE = 0x02,

		/// <summary/>
		CERT_ENCIPHER_ONLY_KEY_USAGE = 0x01,

		/// <summary/>
		CERT_DECIPHER_ONLY_KEY_USAGE = 0x8000,
	}

	/// <summary>Indicates the expected content type.</summary>
	[PInvokeData("wincrypt.h", MSDNShortId = "d882f2b0-0f0a-41c7-afca-a232dc00797b")]
	[Flags]
	public enum CertQueryContentFlags : uint
	{
		/// <summary>
		/// The content can be any type. This does not include the CERT_QUERY_CONTENT_FLAG_PFX_AND_LOAD flag.
		/// <para>
		/// If this flag is specified, this function will attempt to obtain information about the object, trying different content types
		/// until the proper content type is found or the content types are exhausted.This is obviously inefficient, so this flag should
		/// only be used if the content type is not known.
		/// </para>
		/// </summary>
		CERT_QUERY_CONTENT_FLAG_ALL = (CERT_QUERY_CONTENT_FLAG_CERT | CERT_QUERY_CONTENT_FLAG_CTL | CERT_QUERY_CONTENT_FLAG_CRL | CERT_QUERY_CONTENT_FLAG_SERIALIZED_STORE | CERT_QUERY_CONTENT_FLAG_SERIALIZED_CERT | CERT_QUERY_CONTENT_FLAG_SERIALIZED_CTL | CERT_QUERY_CONTENT_FLAG_SERIALIZED_CRL | CERT_QUERY_CONTENT_FLAG_PKCS7_SIGNED | CERT_QUERY_CONTENT_FLAG_PKCS7_UNSIGNED | CERT_QUERY_CONTENT_FLAG_PKCS7_SIGNED_EMBED | CERT_QUERY_CONTENT_FLAG_PKCS10 | CERT_QUERY_CONTENT_FLAG_PFX | CERT_QUERY_CONTENT_FLAG_CERT_PAIR),

		/// <summary/>
		CERT_QUERY_CONTENT_FLAG_ALL_ISSUER_CERT = (CERT_QUERY_CONTENT_FLAG_CERT | CERT_QUERY_CONTENT_FLAG_SERIALIZED_STORE | CERT_QUERY_CONTENT_FLAG_SERIALIZED_CERT | CERT_QUERY_CONTENT_FLAG_PKCS7_SIGNED | CERT_QUERY_CONTENT_FLAG_PKCS7_UNSIGNED),

		/// <summary>The content is a single certificate.</summary>
		CERT_QUERY_CONTENT_FLAG_CERT = (1 << CertQueryContentType.CERT_QUERY_CONTENT_CERT),

		/// <summary>
		/// The content is an Abstract Syntax Notation One (ASN.1) encoded X509_CERT_PAIR (an encoded certificate pair that contains
		/// either forward, reverse, or forward and reverse cross certificates).
		/// </summary>
		CERT_QUERY_CONTENT_FLAG_CERT_PAIR = (1 << CertQueryContentType.CERT_QUERY_CONTENT_CERT_PAIR),

		/// <summary>The content is a single CRL.</summary>
		CERT_QUERY_CONTENT_FLAG_CRL = (1 << CertQueryContentType.CERT_QUERY_CONTENT_CRL),

		/// <summary>The content is a single CTL.</summary>
		CERT_QUERY_CONTENT_FLAG_CTL = (1 << CertQueryContentType.CERT_QUERY_CONTENT_CTL),

		/// <summary>
		/// The content is a PFX (PKCS #12) packet, but it will not be loaded by this function. You can use the PFXImportCertStore
		/// function to load this into a store.
		/// </summary>
		CERT_QUERY_CONTENT_FLAG_PFX = (1 << CertQueryContentType.CERT_QUERY_CONTENT_PFX),

		/// <summary>
		/// The content is a PFX (PKCS #12) packet and will be loaded by this function subject to the conditions specified in the
		/// following note. <note>If the PFX packet contains an embedded password that is not an empty string or NULL, and the password
		/// was not protected to an Active Directory(AD) principal that includes the calling user, this function will not be able to
		/// decrypt the PFX packet.The packet can be decrypted, however, if the password used when the PFX packet was created was
		/// encrypted to an AD principal and the user, as part of that principal, has permission to decrypt the password. For more
		/// information, see the pvPara parameter and the PKCS12_PROTECT_TO_DOMAIN_SIDS flag of the PFXExportCertStoreEx function.
		/// <para>You can protect PFX passwords to an AD principal beginning in Windows 8 and Windows Server 2012.</para>
		/// </note>
		/// <para>Windows Server 2003 and Windows XP: This value is not supported.</para>
		/// </summary>
		CERT_QUERY_CONTENT_FLAG_PFX_AND_LOAD = (1 << CertQueryContentType.CERT_QUERY_CONTENT_PFX_AND_LOAD),

		/// <summary>The content is a PKCS #10 message.</summary>
		CERT_QUERY_CONTENT_FLAG_PKCS10 = (1 << CertQueryContentType.CERT_QUERY_CONTENT_PKCS10),

		/// <summary>The content is a PKCS #7 signed message.</summary>
		CERT_QUERY_CONTENT_FLAG_PKCS7_SIGNED = (1 << CertQueryContentType.CERT_QUERY_CONTENT_PKCS7_SIGNED),

		/// <summary>The content is an embedded PKCS #7 signed message.</summary>
		CERT_QUERY_CONTENT_FLAG_PKCS7_SIGNED_EMBED = (1 << CertQueryContentType.CERT_QUERY_CONTENT_PKCS7_SIGNED_EMBED),

		/// <summary>The content is a PKCS #7 unsigned message.</summary>
		CERT_QUERY_CONTENT_FLAG_PKCS7_UNSIGNED = (1 << CertQueryContentType.CERT_QUERY_CONTENT_PKCS7_UNSIGNED),

		/// <summary>The content is a serialized single certificate.</summary>
		CERT_QUERY_CONTENT_FLAG_SERIALIZED_CERT = (1 << CertQueryContentType.CERT_QUERY_CONTENT_SERIALIZED_CERT),

		/// <summary>The content is a serialized single CRL.</summary>
		CERT_QUERY_CONTENT_FLAG_SERIALIZED_CRL = (1 << CertQueryContentType.CERT_QUERY_CONTENT_SERIALIZED_CRL),

		/// <summary>The content is serialized single CTL.</summary>
		CERT_QUERY_CONTENT_FLAG_SERIALIZED_CTL = (1 << CertQueryContentType.CERT_QUERY_CONTENT_SERIALIZED_CTL),

		/// <summary>The content is a serialized store.</summary>
		CERT_QUERY_CONTENT_FLAG_SERIALIZED_STORE = (1 << CertQueryContentType.CERT_QUERY_CONTENT_SERIALIZED_STORE),
	}

	/// <summary>The actual type of the content.</summary>
	[PInvokeData("wincrypt.h", MSDNShortId = "d882f2b0-0f0a-41c7-afca-a232dc00797b")]
	public enum CertQueryContentType
	{
		/// <summary>The content is a single certificate.</summary>
		CERT_QUERY_CONTENT_CERT = 1,

		/// <summary>The content is a single CTL.</summary>
		CERT_QUERY_CONTENT_CTL = 2,

		/// <summary>The content is a single CRL.</summary>
		CERT_QUERY_CONTENT_CRL = 3,

		/// <summary>The content is a serialized store.</summary>
		CERT_QUERY_CONTENT_SERIALIZED_STORE = 4,

		/// <summary>The content is a serialized single certificate.</summary>
		CERT_QUERY_CONTENT_SERIALIZED_CERT = 5,

		/// <summary>The content is a serialized single CTL.</summary>
		CERT_QUERY_CONTENT_SERIALIZED_CTL = 6,

		/// <summary>The content is a serialized single CRL.</summary>
		CERT_QUERY_CONTENT_SERIALIZED_CRL = 7,

		/// <summary>The content is a PKCS #7 signed message.</summary>
		CERT_QUERY_CONTENT_PKCS7_SIGNED = 8,

		/// <summary>The content is a PKCS #7 unsigned message.</summary>
		CERT_QUERY_CONTENT_PKCS7_UNSIGNED = 9,

		/// <summary>The content is an embedded PKCS #7 signed message.</summary>
		CERT_QUERY_CONTENT_PKCS7_SIGNED_EMBED = 10,

		/// <summary>The content is a PKCS #10 message.</summary>
		CERT_QUERY_CONTENT_PKCS10 = 11,

		/// <summary>
		/// The content is a PFX (PKCS #12) packet. This function only verifies that the object is a PKCS #12 packet. The PKCS #12
		/// packet is not loaded into a certificate store.
		/// </summary>
		CERT_QUERY_CONTENT_PFX = 12,

		/// <summary>The content is an ASN.1 encoded X509_CERT_pair.</summary>
		CERT_QUERY_CONTENT_CERT_PAIR = 13,

		/// <summary>
		/// The content is a PFX (PKCS #12) packet, and it has been loaded into a certificate store.
		/// <para>Windows Server 2003 and Windows XP: This value is not supported.</para>
		/// </summary>
		CERT_QUERY_CONTENT_PFX_AND_LOAD = 14,
	}

	/// <summary>Indicates the expected format of the returned type.</summary>
	[PInvokeData("wincrypt.h", MSDNShortId = "d882f2b0-0f0a-41c7-afca-a232dc00797b")]
	public enum CertQueryFormatFlags : uint
	{
		/// <summary>The content should be returned in binary format.</summary>
		CERT_QUERY_FORMAT_FLAG_BINARY = (1 << CertQueryFormatType.CERT_QUERY_FORMAT_BINARY),

		/// <summary>The content should be returned in Base64 encoded format.</summary>
		CERT_QUERY_FORMAT_FLAG_BASE64_ENCODED = (1 << CertQueryFormatType.CERT_QUERY_FORMAT_BASE64_ENCODED),

		/// <summary>The content should be returned in ASCII hex-encoded format with a "{ASN}" prefix.</summary>
		CERT_QUERY_FORMAT_FLAG_ASN_ASCII_HEX_ENCODED = (1 << CertQueryFormatType.CERT_QUERY_FORMAT_ASN_ASCII_HEX_ENCODED),

		/// <summary>The content can be returned in any format.</summary>
		CERT_QUERY_FORMAT_FLAG_ALL = (CERT_QUERY_FORMAT_FLAG_BINARY | CERT_QUERY_FORMAT_FLAG_BASE64_ENCODED | CERT_QUERY_FORMAT_FLAG_ASN_ASCII_HEX_ENCODED),
	}

	/// <summary>The actual format type of the content.</summary>
	[PInvokeData("wincrypt.h", MSDNShortId = "d882f2b0-0f0a-41c7-afca-a232dc00797b")]
	public enum CertQueryFormatType
	{
		/// <summary>The content is in binary format.</summary>
		CERT_QUERY_FORMAT_BINARY = 1,

		/// <summary>The content is in Base64 encoded format.</summary>
		CERT_QUERY_FORMAT_BASE64_ENCODED = 2,

		/// <summary>The content is in ASCII hex-encoded format with an "{ASN}" prefix.</summary>
		CERT_QUERY_FORMAT_ASN_ASCII_HEX_ENCODED = 3,
	}

	/// <summary>Indicates the type of the object to be queried.</summary>
	[PInvokeData("wincrypt.h", MSDNShortId = "d882f2b0-0f0a-41c7-afca-a232dc00797b")]
	public enum CertQueryObjectType
	{
		/// <summary>The cert query object file</summary>
		CERT_QUERY_OBJECT_FILE = 0x00000001,

		/// <summary>The cert query object BLOB</summary>
		CERT_QUERY_OBJECT_BLOB = 0x00000002,
	}

	/// <summary>RDN attribute flags.</summary>
	[Flags]
	[PInvokeData("wincrypt.h", MSDNShortId = "e45b80a3-9269-4f21-8407-1c8303cb5f32")]
	public enum CertRDNAttrsFlag
	{
		/// <summary>The pRDN was initialized with Unicode strings</summary>
		CERT_UNICODE_IS_RDN_ATTRS_FLAG = 0x1,

		/// <summary>Do a case insensitive match.</summary>
		CERT_CASE_INSENSITIVE_IS_RDN_ATTRS_FLAG = 0x2
	}

	/// <summary>Indicates the type of the context structure.</summary>
	[PInvokeData("wincrypt.h", MSDNShortId = "2d6fb244-5273-4530-bec4-e5451fe26f2e")]
	public enum CertRevocationType
	{
		/// <summary>The revocation of certificates.</summary>
		CERT_CONTEXT_REVOCATION_TYPE = 1
	}

	/// <summary>Indicates any special processing needs.</summary>
	[PInvokeData("wincrypt.h", MSDNShortId = "2d6fb244-5273-4530-bec4-e5451fe26f2e")]
	[Flags]
	public enum CertVerifyFlags
	{
		/// <summary>
		/// Verification of the chain of certificates is done assuming each certificate except the first certificate is the issuer of
		/// the certificate that precedes it. If dwRevType is not CERT_CONTEXT_REVOCATION_TYPE, no assumptions are made about the order
		/// of the contexts.
		/// </summary>
		CERT_VERIFY_REV_CHAIN_FLAG = 0x00000001,

		/// <summary>Prevents the revocation handler from accessing any network-based resources for revocation checking.</summary>
		CERT_VERIFY_CACHE_ONLY_BASED_REVOCATION = 0x00000002,

		/// <summary>When set, dwUrlRetrievalTimeout is the cumulative time-out across all URL wire retrievals.</summary>
		CERT_VERIFY_REV_ACCUMULATIVE_TIMEOUT_FLAG = 0x00000004,

		/// <summary>
		/// When set, this function only uses online certificate status protocol (OCSP) for revocation checking. If the certificate does
		/// not have any OCSP AIA URLs, the dwError member of the pRevStatus parameter is set to CRYPT_E_NOT_IN_REVOCATION_DATABASE.
		/// </summary>
		CERT_VERIFY_REV_SERVER_OCSP_FLAG = 0x00000008,

		/// <summary>
		/// When set, only the OCSP AIA URL is used if present in the subject. If the subject doesn't have an OCSP AIA URL, then, the
		/// CDP URLs are used.
		/// </summary>
		CERT_VERIFY_REV_NO_OCSP_FAILOVER_TO_CRL_FLAG = 0x00000010,

		/// <summary>When set, only wire retrieval for OCSP responses.</summary>
		CERT_VERIFY_REV_SERVER_OCSP_WIRE_ONLY_FLAG = 0x00000020,
	}

	/// <summary>Specifies the cause of the error.</summary>
	[PInvokeData("wincrypt.h", MSDNShortId = "087ea37a-907a-4652-a5df-dd8e86755490")]
	public enum CRL_REASON
	{
		/// <summary>No reason was specified for revocation.</summary>
		CRL_REASON_UNSPECIFIED = 0,

		/// <summary>
		/// It is known or suspected that the subject's private key or other aspects of the subject validated in the certificate are compromised.
		/// </summary>
		CRL_REASON_KEY_COMPROMISE = 1,

		/// <summary>
		/// It is known or suspected that the CA's private key or other aspects of the CA validated in the certificate are compromised.
		/// </summary>
		CRL_REASON_CA_COMPROMISE = 2,

		/// <summary>
		/// The subject's name or other information in the certificate has been modified but there is no cause to suspect that the
		/// private key has been compromised.
		/// </summary>
		CRL_REASON_AFFILIATION_CHANGED = 3,

		/// <summary>The certificate has been superseded, but there is no cause to suspect that the private key has been compromised.</summary>
		CRL_REASON_SUPERSEDED = 4,

		/// <summary>
		/// The certificate is no longer needed for the purpose for which it was issued, but there is no cause to suspect that the
		/// private key has been compromised.
		/// </summary>
		CRL_REASON_CESSATION_OF_OPERATION = 5,

		/// <summary>The certificate has been placed on hold.</summary>
		CRL_REASON_CERTIFICATE_HOLD = 6,

		/// <summary/>
		CRL_REASON_REMOVE_FROM_CRL = 8,

		/// <summary/>
		CRL_REASON_PRIVILEGE_WITHDRAWN = 9,

		/// <summary/>
		CRL_REASON_AA_COMPROMISE = 10,
	}

	/// <summary>A set of flags that modify the behavior of this function.</summary>
	[PInvokeData("wincrypt.h", MSDNShortId = "9e63517d-a56e-45a9-972c-de9a297e9e25")]
	[Flags]
	public enum CryptFindFlags
	{
		/// <summary>Restricts the search to the user container. The default is to search both the user and machine containers.</summary>
		CRYPT_FIND_USER_KEYSET_FLAG = 0x00000001,

		/// <summary>Restricts the search to the machine container. The default is to search both the user and machine containers.</summary>
		CRYPT_FIND_MACHINE_KEYSET_FLAG = 0x00000002,

		/// <summary>
		/// The application requests that the CSP not display any user interface (UI) for this context. If the CSP must display the UI
		/// to operate, the call fails and the NTE_SILENT_CONTEXT error code is set as the last error.
		/// </summary>
		CRYPT_FIND_SILENT_KEYSET_FLAG = 0x00000040,

		/// <summary>
		/// If a handle is already acquired and cached, that same handle is returned. Otherwise, a new handle is acquired and cached by
		/// using the certificate's CERT_KEY_CONTEXT_PROP_ID property.
		/// <para>
		/// When this flag is set, the pfCallerFreeProvOrNCryptKey parameter receives FALSE and the calling application must not release
		/// the handle. The handle is freed when the certificate context is freed; however, you must retain the certificate context
		/// referenced by the pCert parameter as long as the key is in use, otherwise operations that rely on the key will fail.
		/// </para>
		/// </summary>
		CRYPT_ACQUIRE_CACHE_FLAG = 0x00000001,

		/// <summary>
		/// Uses the certificate's CERT_KEY_PROV_INFO_PROP_ID property to determine whether caching should be accomplished. For more
		/// information about the CERT_KEY_PROV_INFO_PROP_ID property, see CertSetCertificateContextProperty.
		/// <para>
		/// This function will only use caching if during a previous call, the dwFlags member of the CRYPT_KEY_PROV_INFO structure
		/// contained CERT_SET_KEY_CONTEXT_PROP.
		/// </para>
		/// </summary>
		CRYPT_ACQUIRE_USE_PROV_INFO_FLAG = 0x00000002,

		/// <summary>
		/// The public key in the certificate is compared with the public key returned by the cryptographic service provider (CSP). If
		/// the keys do not match, the acquisition operation fails and the last error code is set to NTE_BAD_PUBLIC_KEY. If a cached
		/// handle is returned, no comparison is made.
		/// </summary>
		CRYPT_ACQUIRE_COMPARE_KEY_FLAG = 0x00000004,

		/// <summary>
		/// This function will not attempt to re-create the CERT_KEY_PROV_INFO_PROP_ID property in the certificate context if this
		/// property cannot be retrieved.
		/// </summary>
		CRYPT_ACQUIRE_NO_HEALING = 0x00000008,

		/// <summary>
		/// The CSP should not display any user interface (UI) for this context. If the CSP must display UI to operate, the call fails
		/// and the NTE_SILENT_CONTEXT error code is set as the last error.
		/// </summary>
		CRYPT_ACQUIRE_SILENT_FLAG = 0x00000040,

		/// <summary>
		/// Any UI that is needed by the CSP or KSP will be a child of the HWND that is supplied in the pvParameters parameter. For a
		/// CSP key, using this flag will cause the CryptSetProvParam function with the flag PP_CLIENT_HWND using this HWND to be called
		/// with NULL for HCRYPTPROV. For a KSP key, using this flag will cause the NCryptSetProperty function with the
		/// NCRYPT_WINDOW_HANDLE_PROPERTY flag to be called using the HWND.
		/// <para>Do not use this flag with CRYPT_ACQUIRE_SILENT_FLAG.</para>
		/// </summary>
		CRYPT_ACQUIRE_WINDOW_HANDLE_FLAG = 0x00000080,

		/// <summary>The crypt acquire ncrypt key flags mask</summary>
		CRYPT_ACQUIRE_NCRYPT_KEY_FLAGS_MASK = 0x00070000,

		/// <summary>
		/// This function will attempt to obtain the key by using CryptoAPI. If that fails, this function will attempt to obtain the key
		/// by using the Cryptography API: Next Generation (CNG).
		/// <para>The CERT_KEY_PROV_INFO_PROP_ID property of the certificate is set to zero if CNG is used to obtain the key.</para>
		/// </summary>
		CRYPT_ACQUIRE_ALLOW_NCRYPT_KEY_FLAG = 0x00010000,

		/// <summary>
		/// This function will attempt to obtain the key by using CNG. If that fails, this function will attempt to obtain the key by
		/// using CryptoAPI.
		/// <para>The CERT_KEY_PROV_INFO_PROP_ID property of the certificate is set to zero if CNG is used to obtain the key.</para>
		/// </summary>
		CRYPT_ACQUIRE_PREFER_NCRYPT_KEY_FLAG = 0x00020000,

		/// <summary>
		/// This function will only attempt to obtain the key by using CNG and will not use CryptoAPI to obtain the key.
		/// <para>The CERT_KEY_PROV_INFO_PROP_ID property of the certificate is set to zero if CNG is used to obtain the key.</para>
		/// </summary>
		CRYPT_ACQUIRE_ONLY_NCRYPT_KEY_FLAG = 0x00040000,
	}

	/// <summary>
	/// Indicates how the public key information is exported. The flag value is passed directly to the CryptFindOIDInfo function when
	/// mapping the public key object identifier to the corresponding CNG public key algorithm Unicode string.
	/// </summary>
	[PInvokeData("wincrypt.h", MSDNShortId = "38274222-90b3-4038-86d3-6b2813100ce2")]
	[Flags]
	public enum CryptOIDInfoFlags : uint
	{
		/// <summary>pvKey is the address of a null-terminated ANSI string that contains the OID string to find.</summary>
		CRYPT_OID_INFO_OID_KEY = 1,

		/// <summary>pvKey is the address of a null-terminated Unicode string that contains the name to find.</summary>
		CRYPT_OID_INFO_NAME_KEY = 2,

		/// <summary>pvKey is the address of an ALG_IDvariable.</summary>
		CRYPT_OID_INFO_ALGID_KEY = 3,

		/// <summary>
		/// pvKey is the address of an array of two ALG_IDs where the first element contains the hash algorithm identifier and the
		/// second element contains the public key algorithm identifier.
		/// </summary>
		CRYPT_OID_INFO_SIGN_KEY = 4,

		/// <summary>
		/// pvKey is the address of a null-terminated Unicode string that contains the CNG algorithm identifier to find. This can be one
		/// of the predefined CNG Algorithm Identifiers or another registered algorithm identifier.
		/// </summary>
		CRYPT_OID_INFO_CNG_ALGID_KEY = 5,

		/// <summary>
		/// pvKey is the address of an array of two null-terminated Unicode string pointers where the first string contains the hash CNG
		/// algorithm identifier and the second string contains the public key CNG algorithm identifier. These can be from the
		/// predefined CNG Algorithm Identifiers or another registered algorithm identifier.
		/// </summary>
		CRYPT_OID_INFO_CNG_SIGN_KEY = 6,

		/// <summary>
		/// Skips public keys in the CRYPT_PUBKEY_ALG_OID_GROUP_ID group explicitly flagged with the CRYPT_OID_PUBKEY_ENCRYPT_ONLY_FLAG flag.
		/// </summary>
		CRYPT_OID_INFO_PUBKEY_SIGN_KEY_FLAG = 0x80000000,

		/// <summary>
		/// Skips public keys in the CRYPT_PUBKEY_ALG_OID_GROUP_ID group explicitly flagged with the CRYPT_OID_PUBKEY_SIGN_ONLY_FLAG flag.
		/// </summary>
		CRYPT_OID_INFO_PUBKEY_ENCRYPT_KEY_FLAG = 0x40000000
	}

	/// <summary>Flags that modify the function behavior.</summary>
	[PInvokeData("wincrypt.h", MSDNShortId = "8a84af66-b174-4a3e-b1d7-6f218a52d877")]
	[Flags]
	public enum CryptVerifyCertSignFlags
	{
		/// <summary>
		/// If you set this flag and CryptVerifyCertificateSignatureEx detects an MD2 or MD4 algorithm, the function returns FALSE and
		/// sets GetLastError to NTE_BAD_ALGID. The signature is still verified, but this combination of errors enables the caller, now
		/// knowing that an MD2 or MD4 algorithm was used, to decide whether to trust or reject the signature.
		/// <para>Windows 8 and Windows Server 2012: Support for this flag begins.</para>
		/// </summary>
		CRYPT_VERIFY_CERT_SIGN_DISABLE_MD2_MD4_FLAG = 0x00000001,

		/// <summary>
		/// Sets strong signature properties, after successful verification, on the subject pointed to by the pvSubject parameter.
		/// <para>The following property is set on the certificate context:</para>
		/// <para>CERT_SIGN_HASH_CNG_ALG_PROP_ID</para>
		/// <para>The following properties are set on the CRL context:</para>
		/// <para>CERT_SIGN_HASH_CNG_ALG_PROP_ID</para>
		/// <para>CERT_ISSUER_PUB_KEY_BIT_LENGTH_PROP_ID</para>
		/// <para>Note This flag is only applicable if CRYPT_VERIFY_CERT_SIGN_SUBJECT_CRL is specified in the dwSubjectType parameter.</para>
		/// <para>Windows 8 and Windows Server 2012: Support for this flag begins.</para>
		/// </summary>
		CRYPT_VERIFY_CERT_SIGN_SET_STRONG_PROPERTIES_FLAG = 0x00000002,

		/// <summary>
		/// Returns a pointer to a CRYPT_VERIFY_CERT_SIGN_STRONG_PROPERTIES_INFO structure in the pvExtra parameter. The structure
		/// contains the length, in bits, of the public key and the names of the signing and hashing algorithms used.
		/// <para>
		/// You must call CryptMemFree to free the structure. If memory cannot be allocated for the
		/// CRYPT_VERIFY_CERT_SIGN_STRONG_PROPERTIES_INFO structure, this function returns successfully but sets the pvExtra parameter
		/// to NULL.
		/// </para>
		/// <para>
		/// Note This flag is only applicable if CRYPT_VERIFY_CERT_SIGN_SUBJECT_OCSP_BASIC_SIGNED_RESPONSE is specified in the
		/// dwSubjectType parameter.
		/// </para>
		/// <para>Windows 8 and Windows Server 2012: Support for this flag begins.</para>
		/// </summary>
		CRYPT_VERIFY_CERT_SIGN_RETURN_STRONG_PROPERTIES_FLAG = 0x00000004,
	}

	/// <summary>The issuer type.</summary>
	[PInvokeData("wincrypt.h", MSDNShortId = "8a84af66-b174-4a3e-b1d7-6f218a52d877")]
	public enum CryptVerifyCertSignIssuer
	{
		/// <summary>pvIssuer is a pointer to a CERT_PUBLIC_KEY_INFOstructure.</summary>
		CRYPT_VERIFY_CERT_SIGN_ISSUER_PUBKEY = 1,

		/// <summary>pvIssuer is a pointer to a CCERT_CONTEXTstructure.</summary>
		CRYPT_VERIFY_CERT_SIGN_ISSUER_CERT = 2,

		/// <summary>pvIssuer is a pointer to a CCERT_CHAIN_CONTEXTstructure.</summary>
		CRYPT_VERIFY_CERT_SIGN_ISSUER_CHAIN = 3,

		/// <summary>pvIssuer must be NULL.</summary>
		CRYPT_VERIFY_CERT_SIGN_ISSUER_NULL = 4,
	}

	/// <summary>The subject type.</summary>
	[PInvokeData("wincrypt.h", MSDNShortId = "8a84af66-b174-4a3e-b1d7-6f218a52d877")]
	public enum CryptVerifyCertSignSubject
	{
		/// <summary>pvSubject is a pointer to a CRYPT_DATA_BLOBstructure.</summary>
		CRYPT_VERIFY_CERT_SIGN_SUBJECT_BLOB = 1,

		/// <summary>pvSubject is a pointer to a CCERT_CONTEXTstructure.</summary>
		CRYPT_VERIFY_CERT_SIGN_SUBJECT_CERT = 2,

		/// <summary>pvSubject is a pointer to a CCRL_CONTEXTstructure.</summary>
		CRYPT_VERIFY_CERT_SIGN_SUBJECT_CRL = 3,

		/// <summary>
		/// pvSubject is a pointer to an OCSP_BASIC_SIGNED_RESPONSE_INFO structure.
		/// <para>Windows Server 2003 and Windows XP: This subject type is not supported.</para>
		/// </summary>
		CRYPT_VERIFY_CERT_SIGN_SUBJECT_OCSP_BASIC_SIGNED_RESPONSE = 4,
	}

	/// <summary>
	/// <para>
	/// The <c>CertCompareCertificate</c> function determines whether two certificates are identical by comparing the issuer name and
	/// serial number of the certificates.
	/// </para>
	/// <para>
	/// <c>Caution</c> The <c>CertCompareCertificate</c> function must not be used for security assertions because it does not compare BLOBs.
	/// </para>
	/// </summary>
	/// <param name="dwCertEncodingType">
	/// <para>
	/// Specifies the encoding type used. It is always acceptable to specify both the certificate and message encoding types by
	/// combining them with a bitwise- <c>OR</c> operation as shown in the following example:
	/// </para>
	/// <para>X509_ASN_ENCODING | PKCS_7_ASN_ENCODING Currently defined encoding types are:</para>
	/// <list type="bullet">
	/// <item>
	/// <term>X509_ASN_ENCODING</term>
	/// </item>
	/// <item>
	/// <term>PKCS_7_ASN_ENCODING</term>
	/// </item>
	/// </list>
	/// </param>
	/// <param name="pCertId1">A pointer to the CERT_INFO for the first certificate in the comparison.</param>
	/// <param name="pCertId2">A pointer to the CERT_INFO for the second certificate in the comparison.</param>
	/// <returns>
	/// <para>If the certificates are identical and the function succeeds, the function returns nonzero ( <c>TRUE</c>).</para>
	/// <para>If the function fails, it returns zero ( <c>FALSE</c>).</para>
	/// </returns>
	// https://docs.microsoft.com/en-us/windows/win32/api/wincrypt/nf-wincrypt-certcomparecertificate BOOL CertCompareCertificate( DWORD
	// dwCertEncodingType, PCERT_INFO pCertId1, PCERT_INFO pCertId2 );
	[DllImport(Lib.Crypt32, SetLastError = false, ExactSpelling = true)]
	[PInvokeData("wincrypt.h", MSDNShortId = "b485fa81-b927-4f0c-bde1-075f36c76d9a")]
	[return: MarshalAs(UnmanagedType.Bool)]
	public static extern bool CertCompareCertificate(CertEncodingType dwCertEncodingType, in CERT_INFO pCertId1, in CERT_INFO pCertId2);

	/// <summary>
	/// The <c>CertCompareCertificateName</c> function compares two certificate CERT_NAME_BLOB structures to determine whether they are
	/// identical. The <c>CERT_NAME_BLOB</c> structures are used for the subject and the issuer of certificates.
	/// </summary>
	/// <param name="dwCertEncodingType">
	/// <para>
	/// Specifies the encoding type used. It is always acceptable to specify both the certificate and message encoding types by
	/// combining them with a bitwise- <c>OR</c> operation as shown in the following example:
	/// </para>
	/// <para>X509_ASN_ENCODING | PKCS_7_ASN_ENCODING Currently defined encoding types are:</para>
	/// <list type="bullet">
	/// <item>
	/// <term>X509_ASN_ENCODING</term>
	/// </item>
	/// <item>
	/// <term>PKCS_7_ASN_ENCODING</term>
	/// </item>
	/// </list>
	/// </param>
	/// <param name="pCertName1">A pointer to a CERT_NAME_BLOB for the first name in the comparison. For more information, see CRYPT_INTEGER_BLOB.</param>
	/// <param name="pCertName2">A pointer to a CERT_NAME_BLOB for the second name in the comparison.</param>
	/// <returns>
	/// <para>If the names are identical and the function succeeds, the function returns nonzero ( <c>TRUE</c>).</para>
	/// <para>If the function fails, it returns zero ( <c>FALSE</c>).</para>
	/// </returns>
	// https://docs.microsoft.com/en-us/windows/win32/api/wincrypt/nf-wincrypt-certcomparecertificatename BOOL
	// CertCompareCertificateName( DWORD dwCertEncodingType, PCERT_NAME_BLOB pCertName1, PCERT_NAME_BLOB pCertName2 );
	[DllImport(Lib.Crypt32, SetLastError = false, ExactSpelling = true)]
	[PInvokeData("wincrypt.h", MSDNShortId = "6249429d-0cb2-4209-9580-87185d44b967")]
	[return: MarshalAs(UnmanagedType.Bool)]
	public static extern bool CertCompareCertificateName(CertEncodingType dwCertEncodingType, in CRYPTOAPI_BLOB pCertName1, in CRYPTOAPI_BLOB pCertName2);

	/// <summary>
	/// The <c>CertCompareIntegerBlob</c> function compares two integer BLOBs to determine whether they represent equal numeric values.
	/// </summary>
	/// <param name="pInt1">A pointer to a CRYPT_INTEGER_BLOB structure that contains the first integer in the comparison.</param>
	/// <param name="pInt2">A pointer to a CRYPT_INTEGER_BLOB structure that contains the second integer in the comparison.</param>
	/// <returns>
	/// <para>If the representations of the integer BLOBs are identical and the function succeeds, the function returns nonzero ( <c>TRUE</c>).</para>
	/// <para>If the function fails, it returns zero ( <c>FALSE</c>). For extended error information, call GetLastError.</para>
	/// </returns>
	/// <remarks>
	/// <para>
	/// Before doing the comparison, most significant bytes with a value of 0x00 are removed from a positive number. Positive here means
	/// that the most significant bit in the next nonzero byte is not set.
	/// </para>
	/// <para>
	/// Most significant bytes with a value of 0xFF are removed from a negative number. Negative here means that the most significant
	/// bit in the next non-0xFF byte is set. This produces the unique representation of that integer, as shown in the following table.
	/// </para>
	/// <list type="table">
	/// <listheader>
	/// <term>Original bytes</term>
	/// <term>Reduced form</term>
	/// </listheader>
	/// <item>
	/// <term>0xFFFFFF88</term>
	/// <term>0xFF88</term>
	/// </item>
	/// <item>
	/// <term>0xFF23</term>
	/// <term>0xFF23</term>
	/// </item>
	/// <item>
	/// <term>0x007F</term>
	/// <term>0x7F</term>
	/// </item>
	/// <item>
	/// <term>0x00000080</term>
	/// <term>0x80</term>
	/// </item>
	/// </list>
	/// <para>
	/// Multiple-byte integers are treated as little-endian. The least significant byte is pbData[0]. The most significant byte is
	/// pbData[cbData - 1], that is, 0xFFFFFF88 is stored in four bytes as:
	/// </para>
	/// <para>{0x88, 0xFF, 0xFF, 0xFF}</para>
	/// <para>Examples</para>
	/// <para>For an example that uses this function, see Example C Program: Using CertOIDToAlgId and CertCompareIntegerBlob.</para>
	/// </remarks>
	// https://docs.microsoft.com/en-us/windows/win32/api/wincrypt/nf-wincrypt-certcompareintegerblob BOOL CertCompareIntegerBlob(
	// PCRYPT_INTEGER_BLOB pInt1, PCRYPT_INTEGER_BLOB pInt2 );
	[DllImport(Lib.Crypt32, SetLastError = true, ExactSpelling = true)]
	[PInvokeData("wincrypt.h", MSDNShortId = "467ce464-2f22-4583-a745-711ba3b05f4f")]
	[return: MarshalAs(UnmanagedType.Bool)]
	public static extern bool CertCompareIntegerBlob(in CRYPTOAPI_BLOB pInt1, in CRYPTOAPI_BLOB pInt2);

	/// <summary>The <c>CertComparePublicKeyInfo</c> function compares two encoded public keys to determine whether they are identical.</summary>
	/// <param name="dwCertEncodingType">
	/// <para>
	/// Specifies the encoding type used. It is always acceptable to specify both the certificate and message encoding types by
	/// combining them with a bitwise- <c>OR</c> operation as shown in the following example:
	/// </para>
	/// <para>X509_ASN_ENCODING | PKCS_7_ASN_ENCODING Currently defined encoding types are:</para>
	/// <list type="bullet">
	/// <item>
	/// <term>X509_ASN_ENCODING</term>
	/// </item>
	/// <item>
	/// <term>PKCS_7_ASN_ENCODING</term>
	/// </item>
	/// </list>
	/// </param>
	/// <param name="pPublicKey1">A pointer to the CERT_PUBLIC_KEY_INFO for the first public key in the comparison.</param>
	/// <param name="pPublicKey2">A pointer to the CERT_PUBLIC_KEY_INFO for the second public key in the comparison.</param>
	/// <returns>
	/// <para>If the public keys are identical and the function succeeds, the function returns nonzero ( <c>TRUE</c>).</para>
	/// <para>If the function fails, it returns zero ( <c>FALSE</c>).</para>
	/// </returns>
	// https://docs.microsoft.com/en-us/windows/win32/api/wincrypt/nf-wincrypt-certcomparepublickeyinfo BOOL CertComparePublicKeyInfo(
	// DWORD dwCertEncodingType, PCERT_PUBLIC_KEY_INFO pPublicKey1, PCERT_PUBLIC_KEY_INFO pPublicKey2 );
	[DllImport(Lib.Crypt32, SetLastError = false, ExactSpelling = true)]
	[PInvokeData("wincrypt.h", MSDNShortId = "079e4d5e-c8cb-4c3e-8094-13b9a140d564")]
	[return: MarshalAs(UnmanagedType.Bool)]
	public static extern bool CertComparePublicKeyInfo(CertEncodingType dwCertEncodingType, in CERT_PUBLIC_KEY_INFO pPublicKey1, in CERT_PUBLIC_KEY_INFO pPublicKey2);

	/// <summary>
	/// The <c>CertFindAttribute</c> function finds the first attribute in the CRYPT_ATTRIBUTE array, as identified by its object
	/// identifier (OID). This function can be used in the processing of a decoded certificate request. A CERT_REQUEST_INFO structure is
	/// derived from a decoded certificate request. The <c>rgAttribute</c> array is retrieved from that structure and passed to this
	/// function in the rgAttr parameter. This function determines whether a particular attribute is in the array, and if so, returns a
	/// pointer to it.
	/// </summary>
	/// <param name="pszObjId">A pointer to the object identifier (OID) to use in the search.</param>
	/// <param name="cAttr">Number of attributes in the rgAttr array.</param>
	/// <param name="rgAttr">Array of CRYPT_ATTRIBUTE structures.</param>
	/// <returns>Returns a pointer to the attribute, if one is found. Otherwise, <c>NULL</c> is returned.</returns>
	// https://docs.microsoft.com/en-us/windows/win32/api/wincrypt/nf-wincrypt-certfindattribute PCRYPT_ATTRIBUTE CertFindAttribute(
	// LPCSTR pszObjId, DWORD cAttr, CRYPT_ATTRIBUTE [] rgAttr );
	[DllImport(Lib.Crypt32, SetLastError = false, ExactSpelling = true)]
	[PInvokeData("wincrypt.h", MSDNShortId = "99d690fb-ea85-4cb1-9fb0-bdb02e4ac50a")]
	public static extern IntPtr CertFindAttribute(SafeOID pszObjId, uint cAttr, [MarshalAs(UnmanagedType.LPArray)] CRYPT_ATTRIBUTE[]? rgAttr);

	/// <summary>
	/// The <c>CertFindAttribute</c> function finds the first attribute in the CRYPT_ATTRIBUTE array, as identified by its object
	/// identifier (OID). This function can be used in the processing of a decoded certificate request. A CERT_REQUEST_INFO structure is
	/// derived from a decoded certificate request. The <c>rgAttribute</c> array is retrieved from that structure and passed to this
	/// function in the rgAttr parameter. This function determines whether a particular attribute is in the array, and if so, returns a
	/// reference to it.
	/// </summary>
	/// <param name="pszObjId">The object identifier (OID) to use in the search.</param>
	/// <param name="rgAttr">Array of CRYPT_ATTRIBUTE structures.</param>
	/// <returns>Returns a reference to the attribute, if one is found. Otherwise, <see langword="null"/> is returned.</returns>
	public static CRYPT_ATTRIBUTE? CertFindAttribute(string pszObjId, CRYPT_ATTRIBUTE[]? rgAttr) => CertFindAttribute(pszObjId, (uint)(rgAttr?.Length ?? 0), rgAttr).ToNullableStructure<CRYPT_ATTRIBUTE>();

	/// <summary>
	/// The <c>CertFindExtension</c> function finds the first extension in the CERT_EXTENSION array, as identified by its object
	/// identifier (OID). This function can be used in the processing of a decoded certificate. A CERT_INFO structure is derived from a
	/// decoded certificate. The <c>CERT_INFO</c> structure's <c>rgExtension</c> member is passed to <c>CertFindExtension</c> in the
	/// rgExtensions parameter. This function determines whether a particular extension is in the array, and if so, returns a pointer to it
	/// </summary>
	/// <param name="pszObjId">A pointer to the object identifier (OID) to use in the search.</param>
	/// <param name="cExtensions">Number of extensions in the rgExtensions array.</param>
	/// <param name="rgExtensions">Array of CERT_EXTENSION structures.</param>
	/// <returns>Returns a pointer to the extension, if one is found. Otherwise, <c>NULL</c> is returned.</returns>
	// https://docs.microsoft.com/en-us/windows/win32/api/wincrypt/nf-wincrypt-certfindextension PCERT_EXTENSION CertFindExtension(
	// LPCSTR pszObjId, DWORD cExtensions, CERT_EXTENSION [] rgExtensions );
	[DllImport(Lib.Crypt32, SetLastError = false, ExactSpelling = true)]
	[PInvokeData("wincrypt.h", MSDNShortId = "489c58b6-a704-4f54-bc64-34eacafc347c")]
	public static extern IntPtr CertFindExtension(SafeOID pszObjId, uint cExtensions, [MarshalAs(UnmanagedType.LPArray)] CERT_EXTENSION[]? rgExtensions);

	/// <summary>
	/// The <c>CertFindExtension</c> function finds the first extension in the CERT_EXTENSION array, as identified by its object
	/// identifier (OID). This function can be used in the processing of a decoded certificate. A CERT_INFO structure is derived from a
	/// decoded certificate. The <c>CERT_INFO</c> structure's <c>rgExtension</c> member is passed to <c>CertFindExtension</c> in the
	/// rgExtensions parameter. This function determines whether a particular extension is in the array, and if so, returns a reference
	/// to it
	/// </summary>
	/// <param name="pszObjId">A pointer to the object identifier (OID) to use in the search.</param>
	/// <param name="rgExtensions">Array of CERT_EXTENSION structures.</param>
	/// <returns>Returns a reference to the extension, if one is found. Otherwise, <see langword="null"/> is returned.</returns>
	public static CERT_EXTENSION? CertFindExtension(string pszObjId, CERT_EXTENSION[]? rgExtensions) => CertFindExtension(pszObjId, (uint)(rgExtensions?.Length ?? 0), rgExtensions).ToNullableStructure<CERT_EXTENSION>();

	/// <summary>
	/// The <c>CertFindRDNAttr</c> function finds the first RDN attribute identified by its object identifier (OID) in a list of the
	/// Relative Distinguished Names (RDN).
	/// </summary>
	/// <param name="pszObjId">A pointer to the object identifier (OID) to use In the search.</param>
	/// <param name="pName">A pointer to a CERT_NAME_INFO structure containing the list of the Relative Distinguished Names to be searched.</param>
	/// <returns>Returns a pointer to the attribute, if one is found. Otherwise, <c>NULL</c> is returned.</returns>
	// https://docs.microsoft.com/en-us/windows/win32/api/wincrypt/nf-wincrypt-certfindrdnattr PCERT_RDN_ATTR CertFindRDNAttr( LPCSTR
	// pszObjId, PCERT_NAME_INFO pName );
	[DllImport(Lib.Crypt32, SetLastError = false, ExactSpelling = true)]
	[PInvokeData("wincrypt.h", MSDNShortId = "31f82a02-e90a-48de-857a-9fbb03048b5c")]
	public static extern IntPtr CertFindRDNAttr(SafeOID pszObjId, in CERT_NAME_INFO pName);

	/// <summary>
	/// The <c>CertGetIntendedKeyUsage</c> function acquires the intended key usage bytes from a certificate. The intended key usage can
	/// be in either the szOID_KEY_USAGE ("2.5.29.15") or szOID_KEY_ATTRIBUTES ("2.5.29.2") extension.
	/// </summary>
	/// <param name="dwCertEncodingType">
	/// <para>
	/// Specifies the encoding type used. It is always acceptable to specify both the certificate and message encoding types by
	/// combining them with a bitwise- <c>OR</c> operation as shown in the following example:
	/// </para>
	/// <para>X509_ASN_ENCODING | PKCS_7_ASN_ENCODING Currently defined encoding types are:</para>
	/// <list type="bullet">
	/// <item>
	/// <term>X509_ASN_ENCODING</term>
	/// </item>
	/// <item>
	/// <term>PKCS_7_ASN_ENCODING</term>
	/// </item>
	/// </list>
	/// </param>
	/// <param name="pCertInfo">A pointer to CERT_INFO structure of the specified certificate.</param>
	/// <param name="pbKeyUsage">
	/// <para>
	/// A pointer to a buffer to receive the intended key usage. The following list shows currently defined values. These can be
	/// combined by using bitwise- <c>OR</c> operations.
	/// </para>
	/// <list type="bullet">
	/// <item>
	/// <term>CERT_DATA_ENCIPHERMENT_KEY_USAGE</term>
	/// </item>
	/// <item>
	/// <term>CERT_DIGITAL_SIGNATURE_KEY_USAGE</term>
	/// </item>
	/// <item>
	/// <term>CERT_KEY_AGREEMENT_KEY_USAGE</term>
	/// </item>
	/// <item>
	/// <term>CERT_KEY_CERT_SIGN_KEY_USAGE</term>
	/// </item>
	/// <item>
	/// <term>CERT_KEY_ENCIPHERMENT_KEY_USAGE</term>
	/// </item>
	/// <item>
	/// <term>CERT_NON_REPUDIATION_KEY_USAGE</term>
	/// </item>
	/// <item>
	/// <term>CERT_OFFLINE_CRL_SIGN_KEY_USAGE</term>
	/// </item>
	/// </list>
	/// </param>
	/// <param name="cbKeyUsage">
	/// The size, in bytes, of the buffer pointed to by pbKeyUsage. Currently, the intended key usage occupies 1 or 2 bytes of data.
	/// </param>
	/// <returns>
	/// <para>
	/// If the certificate does not have any intended key usage bytes, <c>FALSE</c> is returned and pbKeyUsage is zeroed. Otherwise,
	/// <c>TRUE</c> is returned and up to cbKeyUsage number of bytes are copied into pbKeyUsage. Any remaining bytes not copied are zeroed.
	/// </para>
	/// <para>GetLastError returns zero if none of the required extensions is found.</para>
	/// <para>
	/// If the function fails, GetLastError may return an Abstract Syntax Notation One (ASN.1) encoding/decoding error. For information
	/// about these errors, see ASN.1 Encoding/Decoding Return Values.
	/// </para>
	/// </returns>
	// https://docs.microsoft.com/en-us/windows/win32/api/wincrypt/nf-wincrypt-certgetintendedkeyusage BOOL CertGetIntendedKeyUsage(
	// DWORD dwCertEncodingType, PCERT_INFO pCertInfo, BYTE *pbKeyUsage, DWORD cbKeyUsage );
	[DllImport(Lib.Crypt32, SetLastError = true, ExactSpelling = true)]
	[PInvokeData("wincrypt.h", MSDNShortId = "d09c3626-f864-4774-8511-3e912f62e520")]
	[return: MarshalAs(UnmanagedType.Bool)]
	public static extern bool CertGetIntendedKeyUsage(CertEncodingType dwCertEncodingType, in CERT_INFO pCertInfo, out CertKeyUsage pbKeyUsage, uint cbKeyUsage = 2);

	/// <summary>The <c>CertGetPublicKeyLength</c> function acquires the bit length of public/private keys from a public key BLOB.</summary>
	/// <param name="dwCertEncodingType">
	/// <para>
	/// Specifies the encoding type used. It is always acceptable to specify both the certificate and message encoding types by
	/// combining them with a bitwise- <c>OR</c> operation as shown in the following example:
	/// </para>
	/// <para>X509_ASN_ENCODING | PKCS_7_ASN_ENCODING Currently defined encoding types are:</para>
	/// <list type="bullet">
	/// <item>
	/// <term>X509_ASN_ENCODING</term>
	/// </item>
	/// <item>
	/// <term>PKCS_7_ASN_ENCODING</term>
	/// </item>
	/// </list>
	/// </param>
	/// <param name="pPublicKey">A pointer to the public key BLOB containing the keys for which the length is being retrieved.</param>
	/// <returns>
	/// <para>Returns the length of the public/private keys in bits. If unable to determine the key's length, returns zero.</para>
	/// <para>Call GetLastError to see the reason for any failures.</para>
	/// </returns>
	// https://docs.microsoft.com/en-us/windows/win32/api/wincrypt/nf-wincrypt-certgetpublickeylength DWORD CertGetPublicKeyLength(
	// DWORD dwCertEncodingType, PCERT_PUBLIC_KEY_INFO pPublicKey );
	[DllImport(Lib.Crypt32, SetLastError = true, ExactSpelling = true)]
	[PInvokeData("wincrypt.h", MSDNShortId = "e67923f4-cd1f-4952-88f1-92ee26423f87")]
	public static extern uint CertGetPublicKeyLength(CertEncodingType dwCertEncodingType, in CERT_PUBLIC_KEY_INFO pPublicKey);

	/// <summary>
	/// The <c>CertIsRDNAttrsInCertificateName</c> function compares the attributes in the certificate name with the specified CERT_RDN
	/// to determine whether all attributes are included there. The comparison iterates through the <c>CERT_RDN</c> and looks for an
	/// attribute match in any of the <c>CERT_RDN</c> s of the certificate name.
	/// </summary>
	/// <param name="dwCertEncodingType">
	/// <para>
	/// Specifies the encoding type used. It is always acceptable to specify both the certificate and message encoding types by
	/// combining them with a bitwise- <c>OR</c> operation as shown in the following example:
	/// </para>
	/// <para>X509_ASN_ENCODING | PKCS_7_ASN_ENCODING</para>
	/// <para>Currently defined encoding types are:</para>
	/// <list type="bullet">
	/// <item>
	/// <term>X509_ASN_ENCODING</term>
	/// </item>
	/// <item>
	/// <term>PKCS_7_ASN_ENCODING</term>
	/// </item>
	/// </list>
	/// </param>
	/// <param name="dwFlags">
	/// <para>
	/// CERT_UNICODE_IS_RDN_ATTRS_FLAG must be set if the pRDN was initialized with Unicode strings as in CryptEncodeObject with
	/// lpszStructType set to X509_UNICODE_NAME.
	/// </para>
	/// <para>
	/// CERT_CASE_INSENSITIVE_IS_RDN_ATTRS_FLAG is set to do a case insensitive match. Otherwise, an exact, case sensitive match is done.
	/// </para>
	/// </param>
	/// <param name="pCertName">A pointer to a CRYPT_INTEGER_BLOB that contains the encoded subject or issuer name.</param>
	/// <param name="pRDN">
	/// <para>
	/// Array of CERT_RDN structures that contain the attributes to be found in the name. The CERT_RDN_ATTR member of the
	/// <c>CERT_RDN</c> structure behaves according to the following rules.
	/// </para>
	/// <list type="bullet">
	/// <item>
	/// <term>If <c>pszObjId</c> is <c>NULL</c>, the attribute object identifier (OID) is ignored.</term>
	/// </item>
	/// <item>
	/// <term>If <c>dwValueType</c> is CERT_RDN_ANY_TYPE, the value type is ignored.</term>
	/// </item>
	/// <item>
	/// <term>If the <c>pbData</c> member of <c>Value</c> is <c>NULL</c>, any value can be a match.</term>
	/// </item>
	/// </list>
	/// </param>
	/// <returns>
	/// <para>
	/// If the function succeeds and all of the RDN values in the specified CERT_RDN are in the certificate name, the return value is
	/// nonzero ( <c>TRUE</c>).
	/// </para>
	/// <para>
	/// If the function fails, or if there are RDN values in the specified CERT_RDN that are not in the certificate name, the return
	/// value is zero ( <c>FALSE</c>). For extended error information, call GetLastError.
	/// </para>
	/// <para>The following table lists some possible error codes.</para>
	/// <list type="table">
	/// <listheader>
	/// <term>Return code</term>
	/// <term>Description</term>
	/// </listheader>
	/// <item>
	/// <term>CRYPT_E_NO_MATCH</term>
	/// <term>Not all the attributes were found and matched.</term>
	/// </item>
	/// <item>
	/// <term>ERROR_FILE_NOT_FOUND</term>
	/// <term>Invalid certificate encoding type. Currently only X509_ASN_ENCODING is supported.</term>
	/// </item>
	/// </list>
	/// <para>
	/// If the function fails, GetLastError may return an Abstract Syntax Notation One (ASN.1) encoding/decoding error. For information
	/// about these errors, see ASN.1 Encoding/Decoding Return Values.
	/// </para>
	/// </returns>
	/// <remarks>Currently, only an exact, case-sensitive match is supported.</remarks>
	// https://docs.microsoft.com/en-us/windows/win32/api/wincrypt/nf-wincrypt-certisrdnattrsincertificatename BOOL
	// CertIsRDNAttrsInCertificateName( DWORD dwCertEncodingType, DWORD dwFlags, PCERT_NAME_BLOB pCertName, PCERT_RDN pRDN );
	[DllImport(Lib.Crypt32, SetLastError = true, ExactSpelling = true)]
	[PInvokeData("wincrypt.h", MSDNShortId = "e45b80a3-9269-4f21-8407-1c8303cb5f32")]
	[return: MarshalAs(UnmanagedType.Bool)]
	public static extern bool CertIsRDNAttrsInCertificateName(CertEncodingType dwCertEncodingType, CertRDNAttrsFlag dwFlags, in CRYPTOAPI_BLOB pCertName,
		[In, MarshalAs(UnmanagedType.LPArray)] CERT_RDN[] pRDN);

	/// <summary>
	/// Determines whether the specified hash algorithm and the public key in the signing certificate can be used to perform strong signing.
	/// </summary>
	/// <param name="pStrongSignPara">
	/// Pointer to a CERT_STRONG_SIGN_PARA structure that contains information about supported signing and hashing algorithms.
	/// </param>
	/// <param name="pwszCNGHashAlgid">
	/// <para>Pointer to a Unicode string that contains the name of the hashing algorithm. The following algorithms are supported:</para>
	/// <list type="bullet">
	/// <item>
	/// <term>L"MD5" (BCRYPT_MD5_ALGORITHM)</term>
	/// </item>
	/// <item>
	/// <term>L"SHA1" (BCRYPT_SHA1_ALGORITHM)</term>
	/// </item>
	/// <item>
	/// <term>L"SHA256" (BCRYPT_SHA256_ALGORITHM)</term>
	/// </item>
	/// <item>
	/// <term>L"SHA256" (BCRYPT_SHA256_ALGORITHM)</term>
	/// </item>
	/// <item>
	/// <term>L"SHA512" (BCRYPT_SHA512_ALGORITHM)</term>
	/// </item>
	/// </list>
	/// </param>
	/// <param name="pSigningCert">
	/// <para>
	/// Pointer to a CERT_CONTEXT structure that contains the signing certificate. The public key algorithm in the signing certificate
	/// is checked for strength. The public key (asymmetric) algorithm is used for signing. The following signature algorithms are supported:
	/// </para>
	/// <list type="bullet">
	/// <item>
	/// <term>L"RSA" (BCRYPT_RSA_ALGORITHM)</term>
	/// </item>
	/// <item>
	/// <term>L"DSA" (BCRYPT_DSA_ALGORITHM)</term>
	/// </item>
	/// <item>
	/// <term>L"ECDSA" (SSL_ECDSA_ALGORITHM)</term>
	/// </item>
	/// </list>
	/// <para>This parameter can be</para>
	/// <para>NULL</para>
	/// <para>if you want to check only whether the hashing algorithm is strong.</para>
	/// </param>
	/// <returns>
	/// <para>If the function succeeds, the function returns <c>TRUE</c>.</para>
	/// <para>
	/// If the function fails, it returns <c>FALSE</c>. For extended error information, call GetLastError. This function has the
	/// following error codes.
	/// </para>
	/// <list type="table">
	/// <listheader>
	/// <term>Return code</term>
	/// <term>Description</term>
	/// </listheader>
	/// <item>
	/// <term>E_INVALIDARG</term>
	/// <term>One or more of the input arguments is not correct.</term>
	/// </item>
	/// <item>
	/// <term>NTE_BAD_ALGID</term>
	/// <term>A specified algorithm is not supported.</term>
	/// </item>
	/// </list>
	/// </returns>
	// https://docs.microsoft.com/en-us/windows/win32/api/wincrypt/nf-wincrypt-certisstronghashtosign BOOL CertIsStrongHashToSign(
	// PCCERT_STRONG_SIGN_PARA pStrongSignPara, LPCWSTR pwszCNGHashAlgid, PCCERT_CONTEXT pSigningCert );
	[DllImport(Lib.Crypt32, SetLastError = true, ExactSpelling = true)]
	[PInvokeData("wincrypt.h", MSDNShortId = "B498C1F0-1EFF-49AF-9CD4-A447F79256F1")]
	[return: MarshalAs(UnmanagedType.Bool)]
	public static extern bool CertIsStrongHashToSign(in CERT_STRONG_SIGN_PARA pStrongSignPara, [MarshalAs(UnmanagedType.LPWStr)] string pwszCNGHashAlgid, [Optional] PCCERT_CONTEXT pSigningCert);

	/// <summary>
	/// The <c>CertVerifyCRLRevocation</c> function check a certificate revocation list (CRL) to determine whether a subject's
	/// certificate has or has not been revoked. The new Certificate Chain Verification Functions are recommended instead of the use of
	/// this function.
	/// </summary>
	/// <param name="dwCertEncodingType">
	/// <para>
	/// Specifies the encoding type used. It is always acceptable to specify both the certificate and message encoding types by
	/// combining them with a bitwise- <c>OR</c> operation as shown in the following example:
	/// </para>
	/// <para>X509_ASN_ENCODING | PKCS_7_ASN_ENCODING</para>
	/// <para>Currently defined encoding types are:</para>
	/// <list type="bullet">
	/// <item>
	/// <term>X509_ASN_ENCODING</term>
	/// </item>
	/// <item>
	/// <term>PKCS_7_ASN_ENCODING</term>
	/// </item>
	/// </list>
	/// </param>
	/// <param name="pCertId">A pointer to the CERT_INFO structure of the certificate to be checked against the CRL.</param>
	/// <param name="cCrlInfo">Number of CRL_INFO pointers in the rgpCrlInfo array.</param>
	/// <param name="rgpCrlInfo">Array of pointers to CRL_INFO structures.</param>
	/// <returns>
	/// <para>Returns <c>TRUE</c> if the certificate is not on the CRL and therefore is valid.</para>
	/// <para>It returns <c>FALSE</c> if the certificate is on the list and therefore has been revoked and is not valid.</para>
	/// </returns>
	// https://docs.microsoft.com/en-us/windows/win32/api/wincrypt/nf-wincrypt-certverifycrlrevocation BOOL CertVerifyCRLRevocation(
	// DWORD dwCertEncodingType, PCERT_INFO pCertId, DWORD cCrlInfo, PCRL_INFO [] rgpCrlInfo );
	[DllImport(Lib.Crypt32, SetLastError = false, ExactSpelling = true)]
	[PInvokeData("wincrypt.h", MSDNShortId = "a46ac5b5-bc44-4857-a7fb-4f35d438e3f7")]
	[return: MarshalAs(UnmanagedType.Bool)]
	public static extern bool CertVerifyCRLRevocation(CertEncodingType dwCertEncodingType, in CERT_INFO pCertId, uint cCrlInfo, [MarshalAs(UnmanagedType.LPArray)] IntPtr[] rgpCrlInfo);

	/// <summary>
	/// The <c>CertVerifyCRLRevocation</c> function check a certificate revocation list (CRL) to determine whether a subject's
	/// certificate has or has not been revoked. The new Certificate Chain Verification Functions are recommended instead of the use of
	/// this function.
	/// </summary>
	/// <param name="dwCertEncodingType">
	/// <para>
	/// Specifies the encoding type used. It is always acceptable to specify both the certificate and message encoding types by
	/// combining them with a bitwise- <c>OR</c> operation as shown in the following example:
	/// </para>
	/// <para>X509_ASN_ENCODING | PKCS_7_ASN_ENCODING</para>
	/// <para>Currently defined encoding types are:</para>
	/// <list type="bullet">
	/// <item>
	/// <term>X509_ASN_ENCODING</term>
	/// </item>
	/// <item>
	/// <term>PKCS_7_ASN_ENCODING</term>
	/// </item>
	/// </list>
	/// </param>
	/// <param name="pCertId">A pointer to the CERT_INFO structure of the certificate to be checked against the CRL.</param>
	/// <param name="cCrlInfo">Number of CRL_INFO pointers in the rgpCrlInfo array.</param>
	/// <param name="rgpCrlInfo">Array of pointers to CRL_INFO structures.</param>
	/// <returns>
	/// <para>Returns <c>TRUE</c> if the certificate is not on the CRL and therefore is valid.</para>
	/// <para>It returns <c>FALSE</c> if the certificate is on the list and therefore has been revoked and is not valid.</para>
	/// </returns>
	// https://docs.microsoft.com/en-us/windows/win32/api/wincrypt/nf-wincrypt-certverifycrlrevocation BOOL CertVerifyCRLRevocation(
	// DWORD dwCertEncodingType, PCERT_INFO pCertId, DWORD cCrlInfo, PCRL_INFO [] rgpCrlInfo );
	[DllImport(Lib.Crypt32, SetLastError = false, ExactSpelling = true)]
	[PInvokeData("wincrypt.h", MSDNShortId = "a46ac5b5-bc44-4857-a7fb-4f35d438e3f7")]
	[return: MarshalAs(UnmanagedType.Bool)]
	public static unsafe extern bool CertVerifyCRLRevocation(CertEncodingType dwCertEncodingType, [In] CERT_INFO* pCertId, uint cCrlInfo, [MarshalAs(UnmanagedType.LPArray)] CRL_INFO*[] rgpCrlInfo);

	/// <summary>The <c>CertVerifyCRLTimeValidity</c> function verifies the time validity of a CRL.</summary>
	/// <param name="pTimeToVerify">
	/// A pointer to FILETIME structure containing the time to be used in the verification. If set to <c>NULL</c>, the current time is used.
	/// </param>
	/// <param name="pCrlInfo">A pointer to a CRL_INFO structure containing the CRL for which the time is to be verified.</param>
	/// <returns>
	/// Returns a minus one (–1) if the comparison time is before the <c>ThisUpdate</c> member of the CRL_INFO pointed to by pCrlInfo.
	/// Returns a plus one (+1) if the comparison time is after the <c>NextUpdate</c> time. Returns zero for valid time for the CRL.
	/// </returns>
	// https://docs.microsoft.com/en-us/windows/win32/api/wincrypt/nf-wincrypt-certverifycrltimevalidity LONG CertVerifyCRLTimeValidity(
	// LPFILETIME pTimeToVerify, PCRL_INFO pCrlInfo );
	[DllImport(Lib.Crypt32, SetLastError = false, ExactSpelling = true)]
	[PInvokeData("wincrypt.h", MSDNShortId = "ff321fe8-df45-4a1d-b626-055fb0696438")]
	public static extern int CertVerifyCRLTimeValidity(in FILETIME pTimeToVerify, in CRL_INFO pCrlInfo);

	/// <summary>
	/// The <c>CertVerifyRevocation</c> function checks the revocation status of the certificates contained in the rgpvContext array. If
	/// a certificate in the list is found to be revoked, no further checking is done. This array can be a chain of certificates
	/// propagating upward from an end entity to the root authority, but this nature of the list of certificates is not required or assumed.
	/// </summary>
	/// <param name="dwEncodingType">
	/// Specifies the encoding type used. Currently, only X509_ASN_ENCODING and PKCS_7_ASN_ENCODING are being used; however, additional
	/// encoding types may be added in the future. For either current encoding type, use X509_ASN_ENCODING | PKCS_7_ASN_ENCODING.
	/// </param>
	/// <param name="dwRevType">
	/// Indicates the type of the context structure passed in rgpvContext. Currently only CERT_CONTEXT_REVOCATION_TYPE, the revocation
	/// of certificates, is defined.
	/// </param>
	/// <param name="cContext">Count of elements in the rgpvContext array.</param>
	/// <param name="rgpvContext">
	/// <para>
	/// When the dwRevType is CERT_CONTEXT_REVOCATION_TYPE, rgpvContext is an array of pointers to CERT_CONTEXT structures. These
	/// contexts must contain sufficient information to allow the installable or registered revocation DLLs to find the revocation
	/// server. This information would normally be conveyed in an extension such as the CRLDistributionsPoints extension defined by the
	/// Internet Engineering Task Force (IETF) in PKIX Part 1.
	/// </para>
	/// <para>For efficiency, the more contexts that are passed in at one time, the better.</para>
	/// </param>
	/// <param name="dwFlags">
	/// <para>Indicates any special processing needs. This parameter can be one of the following flags.</para>
	/// <list type="table">
	/// <listheader>
	/// <term>Value</term>
	/// <term>Meaning</term>
	/// </listheader>
	/// <item>
	/// <term>CERT_VERIFY_REV_CHAIN_FLAG</term>
	/// <term>
	/// Verification of the chain of certificates is done assuming each certificate except the first certificate is the issuer of the
	/// certificate that precedes it. If dwRevType is not CERT_CONTEXT_REVOCATION_TYPE, no assumptions are made about the order of the contexts.
	/// </term>
	/// </item>
	/// <item>
	/// <term>CERT_VERIFY_CACHE_ONLY_BASED_REVOCATION</term>
	/// <term>Prevents the revocation handler from accessing any network-based resources for revocation checking.</term>
	/// </item>
	/// <item>
	/// <term>CERT_VERIFY_REV_ACCUMULATIVE_TIMEOUT_FLAG</term>
	/// <term>When set, dwUrlRetrievalTimeout is the cumulative time-out across all URL wire retrievals.</term>
	/// </item>
	/// <item>
	/// <term>CERT_VERIFY_REV_SERVER_OCSP_FLAG</term>
	/// <term>
	/// When set, this function only uses online certificate status protocol (OCSP) for revocation checking. If the certificate does not
	/// have any OCSP AIA URLs, the dwError member of the pRevStatus parameter is set to CRYPT_E_NOT_IN_REVOCATION_DATABASE.
	/// </term>
	/// </item>
	/// </list>
	/// </param>
	/// <param name="pRevPara">Optionally set to assist in finding the issuer. For details, see the CERT_REVOCATION_PARA structure.</param>
	/// <param name="pRevStatus">
	/// <para>
	/// Only the <c>cbSize</c> member of the CERT_REVOCATION_STATUS pointed to by pRevStatus needs to be set before
	/// <c>CertVerifyRevocation</c> is called.
	/// </para>
	/// <para>
	/// If the function returns <c>FALSE</c>, this structure's members will contain error status information. For more information, see
	/// CERT_REVOCATION_STATUS. For a description of how pRevStatus is updated when a revocation verification problem is encountered,
	/// see Remarks.
	/// </para>
	/// </param>
	/// <returns>
	/// <para>
	/// If the function successfully checks all of the contexts and none were revoked, the function returns <c>TRUE</c>. If the function
	/// fails, it returns <c>FALSE</c> and updates the CERT_REVOCATION_STATUS structure pointed to by pRevStatus as described in <c>CERT_REVOCATION_STATUS</c>.
	/// </para>
	/// <para>
	/// When the revocation handler for any of the contexts returns <c>FALSE</c> due to an error, the <c>dwError</c> member in the
	/// structure pointed to by pRevStatus will be set by the handler to specify which error was encountered. GetLastError returns an
	/// error code equal to the error specified in the <c>dwError</c> member of the CERT_REVOCATION_STATUS structure.
	/// <c>GetLastError</c> can be one of the following values.
	/// </para>
	/// <list type="table">
	/// <listheader>
	/// <term>Value</term>
	/// <term>Description</term>
	/// </listheader>
	/// <item>
	/// <term>CRYPT_E_NO_REVOCATION_CHECK</term>
	/// <term>An installed or registered revocation function was not able to do a revocation check on the context.</term>
	/// </item>
	/// <item>
	/// <term>CRYPT_E_NO_REVOCATION_DLL</term>
	/// <term>No installed or registered DLL was found that was able to verify revocation.</term>
	/// </item>
	/// <item>
	/// <term>CRYPT_E_NOT_IN_REVOCATION_DATABASE</term>
	/// <term>The context to be checked was not found in the revocation server's database.</term>
	/// </item>
	/// <item>
	/// <term>CRYPT_E_REVOCATION_OFFLINE</term>
	/// <term>It was not possible to connect to the revocation server.</term>
	/// </item>
	/// <item>
	/// <term>CRYPT_E_REVOKED</term>
	/// <term>The context was revoked. dwReason in pRevStatus contains the reason for revocation.</term>
	/// </item>
	/// <item>
	/// <term>ERROR_SUCCESS</term>
	/// <term>The context was good.</term>
	/// </item>
	/// <item>
	/// <term>E_INVALIDARG</term>
	/// <term>
	/// cbSize in pRevStatus is less than sizeof(CERT_REVOCATION_STATUS). Note that dwError in pRevStatus is not updated for this error.
	/// </term>
	/// </item>
	/// </list>
	/// </returns>
	/// <remarks>
	/// <para>The following example shows how pRevStatus is updated when a revocation verification problem is encountered:</para>
	/// <para>Consider the case where cContext is four:</para>
	/// <para>
	/// If <c>CertVerifyRevocation</c> can verify that rgpvContext[0] and rgpvContext[1] are not revoked, but cannot check
	/// rgpvContext[2], the pRevStatus member <c>dwIndex</c> is set to two, indicating that the context at index two has the problem,
	/// the <c>dwError</c> member of pRevStatus is set to CRYPT_E_NO_REVOCATION_CHECK, and <c>FALSE</c> is returned.
	/// </para>
	/// <para>
	/// If rgpvContext[2] is found to be revoked, the <c>dwIndex</c> member of pRevStatus is set to two, and the <c>dwError</c> member
	/// of pRevStatus is set to CRYPT_E_REVOKED, <c>dwReason</c> is updated, and <c>FALSE</c> is returned.
	/// </para>
	/// <para>
	/// In either case, both rgpvContext[0] and rgpvContext[1] are verified not to be revoked, rgpvContext[2] is the last array index
	/// checked, and rgpvContext[3] has not been checked at all.
	/// </para>
	/// </remarks>
	// https://docs.microsoft.com/en-us/windows/win32/api/wincrypt/nf-wincrypt-certverifyrevocation BOOL CertVerifyRevocation( DWORD
	// dwEncodingType, DWORD dwRevType, DWORD cContext, PVOID [] rgpvContext, DWORD dwFlags, PCERT_REVOCATION_PARA pRevPara,
	// PCERT_REVOCATION_STATUS pRevStatus );
	[DllImport(Lib.Crypt32, SetLastError = true, ExactSpelling = true)]
	[PInvokeData("wincrypt.h", MSDNShortId = "2d6fb244-5273-4530-bec4-e5451fe26f2e")]
	[return: MarshalAs(UnmanagedType.Bool)]
	public static extern bool CertVerifyRevocation(CertEncodingType dwEncodingType, CertRevocationType dwRevType, uint cContext, [In, MarshalAs(UnmanagedType.LPArray)] IntPtr[] rgpvContext,
		CertVerifyFlags dwFlags, in CERT_REVOCATION_PARA pRevPara, ref CERT_REVOCATION_STATUS pRevStatus);

	/// <summary>
	/// The <c>CertVerifyRevocation</c> function checks the revocation status of the certificates contained in the rgpvContext array. If
	/// a certificate in the list is found to be revoked, no further checking is done. This array can be a chain of certificates
	/// propagating upward from an end entity to the root authority, but this nature of the list of certificates is not required or assumed.
	/// </summary>
	/// <param name="dwEncodingType">
	/// Specifies the encoding type used. Currently, only X509_ASN_ENCODING and PKCS_7_ASN_ENCODING are being used; however, additional
	/// encoding types may be added in the future. For either current encoding type, use X509_ASN_ENCODING | PKCS_7_ASN_ENCODING.
	/// </param>
	/// <param name="dwRevType">
	/// Indicates the type of the context structure passed in rgpvContext. Currently only CERT_CONTEXT_REVOCATION_TYPE, the revocation
	/// of certificates, is defined.
	/// </param>
	/// <param name="cContext">Count of elements in the rgpvContext array.</param>
	/// <param name="rgpvContext">
	/// <para>
	/// When the dwRevType is CERT_CONTEXT_REVOCATION_TYPE, rgpvContext is an array of pointers to CERT_CONTEXT structures. These
	/// contexts must contain sufficient information to allow the installable or registered revocation DLLs to find the revocation
	/// server. This information would normally be conveyed in an extension such as the CRLDistributionsPoints extension defined by the
	/// Internet Engineering Task Force (IETF) in PKIX Part 1.
	/// </para>
	/// <para>For efficiency, the more contexts that are passed in at one time, the better.</para>
	/// </param>
	/// <param name="dwFlags">
	/// <para>Indicates any special processing needs. This parameter can be one of the following flags.</para>
	/// <list type="table">
	/// <listheader>
	/// <term>Value</term>
	/// <term>Meaning</term>
	/// </listheader>
	/// <item>
	/// <term>CERT_VERIFY_REV_CHAIN_FLAG</term>
	/// <term>
	/// Verification of the chain of certificates is done assuming each certificate except the first certificate is the issuer of the
	/// certificate that precedes it. If dwRevType is not CERT_CONTEXT_REVOCATION_TYPE, no assumptions are made about the order of the contexts.
	/// </term>
	/// </item>
	/// <item>
	/// <term>CERT_VERIFY_CACHE_ONLY_BASED_REVOCATION</term>
	/// <term>Prevents the revocation handler from accessing any network-based resources for revocation checking.</term>
	/// </item>
	/// <item>
	/// <term>CERT_VERIFY_REV_ACCUMULATIVE_TIMEOUT_FLAG</term>
	/// <term>When set, dwUrlRetrievalTimeout is the cumulative time-out across all URL wire retrievals.</term>
	/// </item>
	/// <item>
	/// <term>CERT_VERIFY_REV_SERVER_OCSP_FLAG</term>
	/// <term>
	/// When set, this function only uses online certificate status protocol (OCSP) for revocation checking. If the certificate does not
	/// have any OCSP AIA URLs, the dwError member of the pRevStatus parameter is set to CRYPT_E_NOT_IN_REVOCATION_DATABASE.
	/// </term>
	/// </item>
	/// </list>
	/// </param>
	/// <param name="pRevPara">Optionally set to assist in finding the issuer. For details, see the CERT_REVOCATION_PARA structure.</param>
	/// <param name="pRevStatus">
	/// <para>
	/// Only the <c>cbSize</c> member of the CERT_REVOCATION_STATUS pointed to by pRevStatus needs to be set before
	/// <c>CertVerifyRevocation</c> is called.
	/// </para>
	/// <para>
	/// If the function returns <c>FALSE</c>, this structure's members will contain error status information. For more information, see
	/// CERT_REVOCATION_STATUS. For a description of how pRevStatus is updated when a revocation verification problem is encountered,
	/// see Remarks.
	/// </para>
	/// </param>
	/// <returns>
	/// <para>
	/// If the function successfully checks all of the contexts and none were revoked, the function returns <c>TRUE</c>. If the function
	/// fails, it returns <c>FALSE</c> and updates the CERT_REVOCATION_STATUS structure pointed to by pRevStatus as described in <c>CERT_REVOCATION_STATUS</c>.
	/// </para>
	/// <para>
	/// When the revocation handler for any of the contexts returns <c>FALSE</c> due to an error, the <c>dwError</c> member in the
	/// structure pointed to by pRevStatus will be set by the handler to specify which error was encountered. GetLastError returns an
	/// error code equal to the error specified in the <c>dwError</c> member of the CERT_REVOCATION_STATUS structure.
	/// <c>GetLastError</c> can be one of the following values.
	/// </para>
	/// <list type="table">
	/// <listheader>
	/// <term>Value</term>
	/// <term>Description</term>
	/// </listheader>
	/// <item>
	/// <term>CRYPT_E_NO_REVOCATION_CHECK</term>
	/// <term>An installed or registered revocation function was not able to do a revocation check on the context.</term>
	/// </item>
	/// <item>
	/// <term>CRYPT_E_NO_REVOCATION_DLL</term>
	/// <term>No installed or registered DLL was found that was able to verify revocation.</term>
	/// </item>
	/// <item>
	/// <term>CRYPT_E_NOT_IN_REVOCATION_DATABASE</term>
	/// <term>The context to be checked was not found in the revocation server's database.</term>
	/// </item>
	/// <item>
	/// <term>CRYPT_E_REVOCATION_OFFLINE</term>
	/// <term>It was not possible to connect to the revocation server.</term>
	/// </item>
	/// <item>
	/// <term>CRYPT_E_REVOKED</term>
	/// <term>The context was revoked. dwReason in pRevStatus contains the reason for revocation.</term>
	/// </item>
	/// <item>
	/// <term>ERROR_SUCCESS</term>
	/// <term>The context was good.</term>
	/// </item>
	/// <item>
	/// <term>E_INVALIDARG</term>
	/// <term>
	/// cbSize in pRevStatus is less than sizeof(CERT_REVOCATION_STATUS). Note that dwError in pRevStatus is not updated for this error.
	/// </term>
	/// </item>
	/// </list>
	/// </returns>
	/// <remarks>
	/// <para>The following example shows how pRevStatus is updated when a revocation verification problem is encountered:</para>
	/// <para>Consider the case where cContext is four:</para>
	/// <para>
	/// If <c>CertVerifyRevocation</c> can verify that rgpvContext[0] and rgpvContext[1] are not revoked, but cannot check
	/// rgpvContext[2], the pRevStatus member <c>dwIndex</c> is set to two, indicating that the context at index two has the problem,
	/// the <c>dwError</c> member of pRevStatus is set to CRYPT_E_NO_REVOCATION_CHECK, and <c>FALSE</c> is returned.
	/// </para>
	/// <para>
	/// If rgpvContext[2] is found to be revoked, the <c>dwIndex</c> member of pRevStatus is set to two, and the <c>dwError</c> member
	/// of pRevStatus is set to CRYPT_E_REVOKED, <c>dwReason</c> is updated, and <c>FALSE</c> is returned.
	/// </para>
	/// <para>
	/// In either case, both rgpvContext[0] and rgpvContext[1] are verified not to be revoked, rgpvContext[2] is the last array index
	/// checked, and rgpvContext[3] has not been checked at all.
	/// </para>
	/// </remarks>
	// https://docs.microsoft.com/en-us/windows/win32/api/wincrypt/nf-wincrypt-certverifyrevocation BOOL CertVerifyRevocation( DWORD
	// dwEncodingType, DWORD dwRevType, DWORD cContext, PVOID [] rgpvContext, DWORD dwFlags, PCERT_REVOCATION_PARA pRevPara,
	// PCERT_REVOCATION_STATUS pRevStatus );
	[DllImport(Lib.Crypt32, SetLastError = true, ExactSpelling = true)]
	[PInvokeData("wincrypt.h", MSDNShortId = "2d6fb244-5273-4530-bec4-e5451fe26f2e")]
	[return: MarshalAs(UnmanagedType.Bool)]
	public static unsafe extern bool CertVerifyRevocation(CertEncodingType dwEncodingType, CertRevocationType dwRevType, uint cContext, [In, MarshalAs(UnmanagedType.LPArray)] CERT_CONTEXT*[] rgpvContext,
		CertVerifyFlags dwFlags, in CERT_REVOCATION_PARA pRevPara, ref CERT_REVOCATION_STATUS pRevStatus);

	/// <summary>The <c>CertVerifyTimeValidity</c> function verifies the time validity of a certificate.</summary>
	/// <param name="pTimeToVerify">
	/// A pointer to a FILETIME structure containing the comparison time. If <c>NULL</c>, the current time is used.
	/// </param>
	/// <param name="pCertInfo">A pointer to the CERT_INFO structure of the certificate for which the time is being verified.</param>
	/// <returns>
	/// Returns a minus one if the comparison time is before the <c>NotBefore</c> member of the CERT_INFO structure. Returns a plus one
	/// if the comparison time is after the <c>NotAfter</c> member. Returns zero for valid time for the certificate.
	/// </returns>
	// https://docs.microsoft.com/en-us/windows/win32/api/wincrypt/nf-wincrypt-certverifytimevalidity LONG CertVerifyTimeValidity(
	// LPFILETIME pTimeToVerify, PCERT_INFO pCertInfo );
	[DllImport(Lib.Crypt32, SetLastError = false, ExactSpelling = true)]
	[PInvokeData("wincrypt.h", MSDNShortId = "9ccf9230-e998-4f82-9db0-6cbaa1c36850")]
	public static extern int CertVerifyTimeValidity(in FILETIME pTimeToVerify, in CERT_INFO pCertInfo);

	/// <summary>
	/// The <c>CertVerifyValidityNesting</c> function verifies that a subject certificate's time validity nests correctly within its
	/// issuer's time validity.
	/// </summary>
	/// <param name="pSubjectInfo">A pointer to the CERT_INFO structure of the subject certificate.</param>
	/// <param name="pIssuerInfo">A pointer to the CERT_INFO structure of the issuer certificate.</param>
	/// <returns>
	/// Returns <c>TRUE</c> if the <c>NotBefore</c> time of the subject's certificate is after the <c>NotBefore</c> time of the issuer's
	/// certificate and the <c>NotAfter</c> time of the subject's certificate is not after the <c>NotAfter</c> time of the issuer's
	/// certificate. Otherwise, returns <c>FALSE</c>.
	/// </returns>
	// https://docs.microsoft.com/en-us/windows/win32/api/wincrypt/nf-wincrypt-certverifyvaliditynesting BOOL CertVerifyValidityNesting(
	// PCERT_INFO pSubjectInfo, PCERT_INFO pIssuerInfo );
	[DllImport(Lib.Crypt32, SetLastError = false, ExactSpelling = true)]
	[PInvokeData("wincrypt.h", MSDNShortId = "dc73a21d-5b55-45c4-80d2-220508d9f762")]
	[return: MarshalAs(UnmanagedType.Bool)]
	public static extern bool CertVerifyValidityNesting(in CERT_INFO pSubjectInfo, in CERT_INFO pIssuerInfo);

	/// <summary>If the handle refers to a session key, or to a public key that has been imported into the <c>cryptographic service provider</c> (CSP) through <c>CryptImportKey</c>, this function destroys the key and frees the memory that the key used. Many CSPs overwrite the memory where the key was held before freeing it. However, the underlying <c>public/private key pair</c> is not destroyed by this function. Only the handle is destroyed.</summary>
	/// <param name="hKey">The handle of the key to be destroyed.</param>
	/// <returns>
	/// <para>If the function succeeds, the return value is nonzero.</para>
	/// <para>If the function fails, the return value is zero. For extended error information, call <c>GetLastError</c>.</para>
	/// <para>The error codes prefaced by "NTE" are generated by the particular CSP being used. Some possible error codes are listed in the following table.</para>
	/// <list type="table">
	/// <listheader>
	/// <description>Return code</description>
	/// <description>Description</description>
	/// </listheader>
	/// <item>
	/// <description><b>ERROR_BUSY</b></description>
	/// <description>The key object specified by <i>hKey</i> is currently being used and cannot be destroyed.</description>
	/// </item>
	/// <item>
	/// <description><b>ERROR_INVALID_HANDLE</b></description>
	/// <description>The <i>hKey</i> parameter specifies a handle that is not valid.</description>
	/// </item>
	/// <item>
	/// <description><b>ERROR_INVALID_PARAMETER</b></description>
	/// <description>The <i>hKey</i> parameter contains a value that is not valid.</description>
	/// </item>
	/// <item>
	/// <description><b>NTE_BAD_KEY</b></description>
	/// <description>The <i>hKey</i> parameter does not contain a valid handle to a key.</description>
	/// </item>
	/// <item>
	/// <description><b>NTE_BAD_UID</b></description>
	/// <description>The CSP context that was specified when the key was created cannot be found.</description>
	/// </item>
	/// </list>
	/// </returns>
	/// <remarks>
	/// <para>Keys take up both operating system's memory space and the CSP's memory space. Some CSPs are implemented in hardware with limited memory resources. Applications must destroy all keys with the <b>CryptDestroyKey</b> function when they are finished with them.</para>
	/// <para>All key handles that have been created or imported by using a specific CSP must be destroyed before that CSP handle is released with the <c>CryptReleaseContext</c> function.</para>
	/// <para>Examples</para>
	/// <para>For an example that uses the <b>CryptDestroyKey</b> function, see <c>Example C Program: Creating and Hashing a Session Key</c>.</para>
	/// </remarks>
	// https://learn.microsoft.com/en-us/windows/win32/api/wincrypt/nf-wincrypt-cryptdestroykey
	// BOOL CryptDestroyKey( [in] HCRYPTKEY hKey );
	[PInvokeData("wincrypt.h", MSDNShortId = "NF:wincrypt.CryptDestroyKey")]
	[DllImport(Lib.AdvApi32, SetLastError = true, ExactSpelling = true)]
	[return: MarshalAs(UnmanagedType.Bool)]
	public static extern bool CryptDestroyKey([In] HCRYPTKEY hKey);

	/// <summary>
	/// <para>
	/// [The <c>CryptExportPKCS8</c> function is no longer available for use as of Windows Server 2008 and Windows Vista. Instead, use
	/// the PFXExportCertStoreEx function.]
	/// </para>
	/// <para>
	/// The <c>CryptExportPKCS8</c> function exports the private key in PKCS #8 format. The function is superseded by
	/// CryptExportPKCS8Ex, which also may be altered or unavailable in subsequent versions.
	/// </para>
	/// </summary>
	/// <param name="hCryptProv">
	/// An HCRYPTPROV variable that contains the cryptographic service provider (CSP). This is a handle to the CSP obtained by calling CryptAcquireContext.
	/// </param>
	/// <param name="dwKeySpec">
	/// <para>
	/// A <c>DWORD</c> variable that contains the key specification. The following dwKeySpec values are defined for the default provider.
	/// </para>
	/// <list type="table">
	/// <listheader>
	/// <term>Value</term>
	/// <term>Meaning</term>
	/// </listheader>
	/// <item>
	/// <term>AT_KEYEXCHANGE</term>
	/// <term>Keys used to encrypt/decrypt session keys.</term>
	/// </item>
	/// <item>
	/// <term>AT_SIGNATURE</term>
	/// <term>Keys used to create and verify digital signatures.</term>
	/// </item>
	/// </list>
	/// </param>
	/// <param name="pszPrivateKeyObjId">An <c>LPSTR</c> variable that contains the private key object identifier (OID).</param>
	/// <param name="dwFlags">This parameter should be zero if pbPrivateKeyBlob is <c>NULL</c> and 0x8000 otherwise.</param>
	/// <param name="pvAuxInfo">This parameter must be set to <c>NULL</c>.</param>
	/// <param name="pbPrivateKeyBlob">
	/// <para>A pointer to an array of <c>BYTE</c> structures to receive the private key to be exported.</para>
	/// <para>
	/// The private key will contain the information in a PKCS #8 PrivateKeyInfo Abstract Syntax Notation One (ASN.1) type found in the
	/// PKCS #8 standard.
	/// </para>
	/// <para>
	/// For memory allocation purposes, you can get the size of the private key to be exported by setting this parameter to <c>NULL</c>.
	/// For more information, see Retrieving Data of Unknown Length.
	/// </para>
	/// </param>
	/// <param name="pcbPrivateKeyBlob">
	/// A pointer to a <c>DWORD</c> that may contain, on input, the size, in bytes, of the memory allocation needed to contain the
	/// pbPrivateKeyBlob. If pbPrivateKeyBlob is <c>NULL</c>, this parameter will return the size of the memory allocation needed for a
	/// second call to the function. For more information, see Retrieving Data of Unknown Length.
	/// </param>
	/// <returns>
	/// <para>If the function succeeds, the function returns nonzero.</para>
	/// <para>If the function fails, it returns zero. For extended error information, call GetLastError.</para>
	/// <para>The following error codes are specific to this function.</para>
	/// <list type="table">
	/// <listheader>
	/// <term>Return code</term>
	/// <term>Description</term>
	/// </listheader>
	/// <item>
	/// <term>ERROR_UNSUPPORTED_TYPE</term>
	/// <term>An export function that can be installed or registered could not be found.</term>
	/// </item>
	/// <item>
	/// <term>ERROR_MORE_DATA</term>
	/// <term>
	/// If the buffer specified by the pbPrivateKeyBlob parameter is not large enough to hold the returned data, the function sets the
	/// ERROR_MORE_DATA code and stores the required buffer size, in bytes, in the variable pointed to by the pcbPrivateKeyBlob parameter.
	/// </term>
	/// </item>
	/// </list>
	/// <para>
	/// If the function fails, GetLastError may return an ASN.1 encoding/decoding error. For information about these errors, see ASN.1
	/// Encoding/Decoding Return Values.
	/// </para>
	/// </returns>
	/// <remarks>This function is only supported for asymmetric keys.</remarks>
	// https://docs.microsoft.com/en-us/windows/win32/api/wincrypt/nf-wincrypt-cryptexportpkcs8 BOOL CryptExportPKCS8( HCRYPTPROV
	// hCryptProv, DWORD dwKeySpec, LPSTR pszPrivateKeyObjId, DWORD dwFlags, void *pvAuxInfo, BYTE *pbPrivateKeyBlob, DWORD
	// *pcbPrivateKeyBlob );
	[DllImport(Lib.Crypt32, SetLastError = true, ExactSpelling = true)]
	[Obsolete("The CryptExportPKCS8 function is no longer available for use as of Windows Server 2008 and Windows Vista. Instead, use the PFXExportCertStoreEx function.")]
	[PInvokeData("wincrypt.h", MSDNShortId = "defd0b23-d9c2-4b28-a6a6-1be7487ae656")]
	[return: MarshalAs(UnmanagedType.Bool)]
	public static extern bool CryptExportPKCS8(HCRYPTPROV hCryptProv, CertKeySpec dwKeySpec, SafeOID pszPrivateKeyObjId, uint dwFlags,
		[In, Optional] IntPtr pvAuxInfo, [Out, Optional] IntPtr pbPrivateKeyBlob, ref uint pcbPrivateKeyBlob);

	/// <summary>
	/// <para>
	/// [The <c>CryptExportPKCS8Ex</c> function is no longer available for use as of Windows Server 2008 and Windows Vista. Instead, use
	/// the PFXExportCertStoreEx function.]
	/// </para>
	/// <para>
	/// The <c>CryptExportPKCS8Ex</c> function exports the private key in PKCS #8 format.This function has no associated import library.
	/// You must use the LoadLibrary and GetProcAddress functions to dynamically link to Crypt32.dll.
	/// </para>
	/// </summary>
	/// <param name="psExportParams">
	/// A pointer to a CRYPT_PKCS8_EXPORT_PARAMS structure that contains information about the key to export.
	/// </param>
	/// <param name="dwFlags">This parameter should be zero if pbPrivateKeyBlob is <c>NULL</c> and 0x8000 otherwise.</param>
	/// <param name="pvAuxInfo">This parameter must be <c>NULL</c>.</param>
	/// <param name="pbPrivateKeyBlob">
	/// <para>A pointer to an array of <c>BYTE</c> structures to receive the private key to be exported.</para>
	/// <para>
	/// The private key will contain the information in a PKCS #8 PrivateKeyInfo Abstract Syntax Notation One (ASN.1) type found in the
	/// PKCS #8 standard.
	/// </para>
	/// <para>
	/// For memory allocation purposes, you can get the size of the private key to be exported by setting this parameter to <c>NULL</c>.
	/// For more information, see Retrieving Data of Unknown Length.
	/// </para>
	/// </param>
	/// <param name="pcbPrivateKeyBlob">
	/// A pointer to a <c>DWORD</c> that may contain, on input, the size, in bytes, of the memory allocation needed to contain the
	/// pbPrivateKeyBlob. If pbPrivateKeyBlob is <c>NULL</c>, this parameter will return the size of the memory allocation needed for a
	/// second call to the function. For more information, see Retrieving Data of Unknown Length.
	/// </param>
	/// <returns>
	/// <para>If the function succeeds, the function returns nonzero ( <c>TRUE</c>).</para>
	/// <para>If the function fails, it returns zero ( <c>FALSE</c>). For extended error information, call GetLastError.</para>
	/// <para>The following error codes are specific to this function.</para>
	/// <list type="table">
	/// <listheader>
	/// <term>Return code</term>
	/// <term>Description</term>
	/// </listheader>
	/// <item>
	/// <term>ERROR_UNSUPPORTED_TYPE</term>
	/// <term>An export function that can be installed or registered could not be found.</term>
	/// </item>
	/// <item>
	/// <term>ERROR_MORE_DATA</term>
	/// <term>
	/// If the buffer specified by the pbPrivateKeyBlob parameter is not large enough to hold the returned data, the function sets the
	/// ERROR_MORE_DATA code and stores the required buffer size, in bytes, in the variable pointed to by the pcbPrivateKeyBlob parameter.
	/// </term>
	/// </item>
	/// </list>
	/// <para>
	/// If the function fails, GetLastError returns an ASN.1 encoding/decoding error. For information about these errors, see ASN.1
	/// Encoding/Decoding Return Values.
	/// </para>
	/// </returns>
	/// <remarks>This function is only supported for asymmetric keys.</remarks>
	// https://docs.microsoft.com/en-us/windows/win32/api/wincrypt/nf-wincrypt-cryptexportpkcs8ex BOOL CryptExportPKCS8Ex(
	// CRYPT_PKCS8_EXPORT_PARAMS *psExportParams, DWORD dwFlags, void *pvAuxInfo, BYTE *pbPrivateKeyBlob, DWORD *pcbPrivateKeyBlob );
	[DllImport(Lib.Crypt32, SetLastError = true, ExactSpelling = true)]
	[Obsolete("The CryptExportPKCS8Ex function is no longer available for use as of Windows Server 2008 and Windows Vista. Instead, use the PFXExportCertStoreEx function.")]
	[PInvokeData("wincrypt.h", MSDNShortId = "82fee86a-8704-4f22-8f11-f89509c5a0aa")]
	[return: MarshalAs(UnmanagedType.Bool)]
	public static extern bool CryptExportPKCS8Ex(in CRYPT_PKCS8_EXPORT_PARAMS psExportParams, uint dwFlags, [In, Optional] IntPtr pvAuxInfo,
		[Optional, Out] IntPtr pbPrivateKeyBlob, ref uint pcbPrivateKeyBlob);

	/// <summary>
	/// The <c>CryptExportPublicKeyInfo</c> function exports the public key information associated with the corresponding private key of
	/// the provider. For an updated version of this function, see CryptExportPublicKeyInfoEx.
	/// </summary>
	/// <param name="hCryptProvOrNCryptKey">
	/// Handle of the cryptographic service provider (CSP) to use when exporting the public key information. This handle must be an
	/// HCRYPTPROV handle that has been created by using the CryptAcquireContext function or an <c>NCRYPT_KEY_HANDLE</c> handle that has
	/// been created by using the NCryptOpenKey function. New applications should always pass in the <c>NCRYPT_KEY_HANDLE</c> handle of
	/// a CNG CSP.
	/// </param>
	/// <param name="dwKeySpec">
	/// Identifies the private key to use from the container of the provider. It can be AT_KEYEXCHANGE or AT_SIGNATURE. This parameter
	/// is ignored if an <c>NCRYPT_KEY_HANDLE</c> is used in the hCryptProvOrNCryptKey parameter.
	/// </param>
	/// <param name="dwCertEncodingType">
	/// <para>
	/// Specifies the encoding type used. It is always acceptable to specify both the certificate and message encoding types by
	/// combining them with a bitwise- <c>OR</c> operation as shown in the following example:
	/// </para>
	/// <para>X509_ASN_ENCODING | PKCS_7_ASN_ENCODING</para>
	/// <para>Currently defined encoding types are:</para>
	/// <list type="bullet">
	/// <item>
	/// <term>X509_ASN_ENCODING</term>
	/// </item>
	/// <item>
	/// <term>PKCS_7_ASN_ENCODING</term>
	/// </item>
	/// </list>
	/// </param>
	/// <param name="pInfo">
	/// <para>A pointer to a CERT_PUBLIC_KEY_INFO structure to receive the public key information to be exported.</para>
	/// <para>
	/// To set the size of this information for memory allocation purposes, this parameter can be <c>NULL</c>. For more information, see
	/// Retrieving Data of Unknown Length.
	/// </para>
	/// </param>
	/// <param name="pcbInfo">
	/// <para>
	/// A pointer to a <c>DWORD</c> that contains the size, in bytes, of the buffer pointed to by the pInfo parameter. When the function
	/// returns, the <c>DWORD</c> contains the number of bytes needed for the return buffer.
	/// </para>
	/// <para>
	/// <c>Note</c> When processing the data returned in the buffer, applications need to use the actual size of the data returned. The
	/// actual size can be slightly smaller than the size of the buffer specified on input. (On input, buffer sizes are usually
	/// specified large enough to ensure that the largest possible output data will fit in the buffer.) On output, the variable pointed
	/// to by this parameter is updated to reflect the actual size of the data copied to the buffer.
	/// </para>
	/// </param>
	/// <returns>
	/// <para>If the function succeeds, the function returns nonzero ( <c>TRUE</c>).</para>
	/// <para>If the function fails, it returns zero ( <c>FALSE</c>). For extended error information, call GetLastError.</para>
	/// <para><c>Note</c> Errors from the called functions CryptGetUserKey and CryptExportKey might be propagated to this function.</para>
	/// <para>This function has the following error codes.</para>
	/// <list type="table">
	/// <listheader>
	/// <term>Return code</term>
	/// <term>Description</term>
	/// </listheader>
	/// <item>
	/// <term>ERROR_MORE_DATA</term>
	/// <term>
	/// If the buffer specified by the pInfo parameter is not large enough to hold the returned data, the function sets the
	/// ERROR_MORE_DATA code, and stores the required buffer size, in bytes, into the variable pointed to by pcbInfo.
	/// </term>
	/// </item>
	/// <item>
	/// <term>ERROR_FILE_NOT_FOUND</term>
	/// <term>Invalid certificate encoding type. Currently only X509_ASN_ENCODING is supported.</term>
	/// </item>
	/// </list>
	/// <para>
	/// If the function fails, GetLastError may return an Abstract Syntax Notation One (ASN.1) encoding/decoding error. For information
	/// about these errors, see ASN.1 Encoding/Decoding Return Values.
	/// </para>
	/// </returns>
	// https://docs.microsoft.com/en-us/windows/win32/api/wincrypt/nf-wincrypt-cryptexportpublickeyinfo BOOL CryptExportPublicKeyInfo(
	// HCRYPTPROV_OR_NCRYPT_KEY_HANDLE hCryptProvOrNCryptKey, DWORD dwKeySpec, DWORD dwCertEncodingType, PCERT_PUBLIC_KEY_INFO pInfo,
	// DWORD *pcbInfo );
	[DllImport(Lib.Crypt32, SetLastError = true, ExactSpelling = true)]
	[PInvokeData("wincrypt.h", MSDNShortId = "ad43a991-aaf5-4272-abab-0a981112e5e4")]
	[return: MarshalAs(UnmanagedType.Bool)]
	public static extern bool CryptExportPublicKeyInfo(HCRYPTPROV hCryptProvOrNCryptKey, CertKeySpec dwKeySpec, CertEncodingType dwCertEncodingType, [Optional] IntPtr pInfo, ref uint pcbInfo);

	/// <summary>
	/// The <c>CryptExportPublicKeyInfo</c> function exports the public key information associated with the corresponding private key of
	/// the provider. For an updated version of this function, see CryptExportPublicKeyInfoEx.
	/// </summary>
	/// <param name="hCryptProvOrNCryptKey">
	/// Handle of the cryptographic service provider (CSP) to use when exporting the public key information. This handle must be an
	/// HCRYPTPROV handle that has been created by using the CryptAcquireContext function or an <c>NCRYPT_KEY_HANDLE</c> handle that has
	/// been created by using the NCryptOpenKey function. New applications should always pass in the <c>NCRYPT_KEY_HANDLE</c> handle of
	/// a CNG CSP.
	/// </param>
	/// <param name="dwKeySpec">
	/// Identifies the private key to use from the container of the provider. It can be AT_KEYEXCHANGE or AT_SIGNATURE. This parameter
	/// is ignored if an <c>NCRYPT_KEY_HANDLE</c> is used in the hCryptProvOrNCryptKey parameter.
	/// </param>
	/// <param name="dwCertEncodingType">
	/// <para>
	/// Specifies the encoding type used. It is always acceptable to specify both the certificate and message encoding types by
	/// combining them with a bitwise- <c>OR</c> operation as shown in the following example:
	/// </para>
	/// <para>X509_ASN_ENCODING | PKCS_7_ASN_ENCODING</para>
	/// <para>Currently defined encoding types are:</para>
	/// <list type="bullet">
	/// <item>
	/// <term>X509_ASN_ENCODING</term>
	/// </item>
	/// <item>
	/// <term>PKCS_7_ASN_ENCODING</term>
	/// </item>
	/// </list>
	/// </param>
	/// <param name="pInfo">
	/// <para>A pointer to a CERT_PUBLIC_KEY_INFO structure to receive the public key information to be exported.</para>
	/// <para>
	/// To set the size of this information for memory allocation purposes, this parameter can be <c>NULL</c>. For more information, see
	/// Retrieving Data of Unknown Length.
	/// </para>
	/// </param>
	/// <param name="pcbInfo">
	/// <para>
	/// A pointer to a <c>DWORD</c> that contains the size, in bytes, of the buffer pointed to by the pInfo parameter. When the function
	/// returns, the <c>DWORD</c> contains the number of bytes needed for the return buffer.
	/// </para>
	/// <para>
	/// <c>Note</c> When processing the data returned in the buffer, applications need to use the actual size of the data returned. The
	/// actual size can be slightly smaller than the size of the buffer specified on input. (On input, buffer sizes are usually
	/// specified large enough to ensure that the largest possible output data will fit in the buffer.) On output, the variable pointed
	/// to by this parameter is updated to reflect the actual size of the data copied to the buffer.
	/// </para>
	/// </param>
	/// <returns>
	/// <para>If the function succeeds, the function returns nonzero ( <c>TRUE</c>).</para>
	/// <para>If the function fails, it returns zero ( <c>FALSE</c>). For extended error information, call GetLastError.</para>
	/// <para><c>Note</c> Errors from the called functions CryptGetUserKey and CryptExportKey might be propagated to this function.</para>
	/// <para>This function has the following error codes.</para>
	/// <list type="table">
	/// <listheader>
	/// <term>Return code</term>
	/// <term>Description</term>
	/// </listheader>
	/// <item>
	/// <term>ERROR_MORE_DATA</term>
	/// <term>
	/// If the buffer specified by the pInfo parameter is not large enough to hold the returned data, the function sets the
	/// ERROR_MORE_DATA code, and stores the required buffer size, in bytes, into the variable pointed to by pcbInfo.
	/// </term>
	/// </item>
	/// <item>
	/// <term>ERROR_FILE_NOT_FOUND</term>
	/// <term>Invalid certificate encoding type. Currently only X509_ASN_ENCODING is supported.</term>
	/// </item>
	/// </list>
	/// <para>
	/// If the function fails, GetLastError may return an Abstract Syntax Notation One (ASN.1) encoding/decoding error. For information
	/// about these errors, see ASN.1 Encoding/Decoding Return Values.
	/// </para>
	/// </returns>
	// https://docs.microsoft.com/en-us/windows/win32/api/wincrypt/nf-wincrypt-cryptexportpublickeyinfo BOOL CryptExportPublicKeyInfo(
	// HCRYPTPROV_OR_NCRYPT_KEY_HANDLE hCryptProvOrNCryptKey, DWORD dwKeySpec, DWORD dwCertEncodingType, PCERT_PUBLIC_KEY_INFO pInfo,
	// DWORD *pcbInfo );
	[DllImport(Lib.Crypt32, SetLastError = true, ExactSpelling = true)]
	[PInvokeData("wincrypt.h", MSDNShortId = "ad43a991-aaf5-4272-abab-0a981112e5e4")]
	[return: MarshalAs(UnmanagedType.Bool)]
	public static extern bool CryptExportPublicKeyInfo(NCrypt.NCRYPT_KEY_HANDLE hCryptProvOrNCryptKey, CertKeySpec dwKeySpec, CertEncodingType dwCertEncodingType, [Optional] IntPtr pInfo, ref uint pcbInfo);

	/// <summary>
	/// The <c>CryptExportPublicKeyInfoEx</c> function exports the public key information associated with the provider's corresponding
	/// private key. This function allows the application to specify the public key algorithm, overriding the default provided by the
	/// cryptographic service provider (CSP).
	/// </summary>
	/// <param name="hCryptProvOrNCryptKey">
	/// A handle of the CSP to use when exporting the public key information. This handle must be an HCRYPTPROV handle that has been
	/// created by using the CryptAcquireContext function or an <c>NCRYPT_KEY_HANDLE</c> handle that has been created by using the
	/// NCryptOpenKey function. New applications should always pass in the <c>NCRYPT_KEY_HANDLE</c> handle of a CNG CSP.
	/// </param>
	/// <param name="dwKeySpec">
	/// Identifies the private key to use from the provider's container. It can be AT_KEYEXCHANGE or AT_SIGNATURE. This parameter is
	/// ignored if an <c>NCRYPT_KEY_HANDLE</c> is used in the hCryptProvOrNCryptKey parameter.
	/// </param>
	/// <param name="dwCertEncodingType">
	/// <para>
	/// Specifies the encoding type used. It is always acceptable to specify both the certificate and message encoding types by
	/// combining them with a bitwise- <c>OR</c> operation as shown in the following example:
	/// </para>
	/// <para>X509_ASN_ENCODING | PKCS_7_ASN_ENCODING</para>
	/// <para>Currently defined encoding types are:</para>
	/// <list type="bullet">
	/// <item>
	/// <term>X509_ASN_ENCODING</term>
	/// </item>
	/// <item>
	/// <term>PKCS_7_ASN_ENCODING</term>
	/// </item>
	/// </list>
	/// </param>
	/// <param name="pszPublicKeyObjId">
	/// <para>Specifies the public key algorithm.</para>
	/// <para>
	/// <c>Note</c> pszPublicKeyObjId and dwCertEncodingType are used together to determine the installable
	/// <c>CRYPT_OID_EXPORT_PUBLIC_KEY_INFO_FUNC</c> to call. If an installable function was not found for the pszPublicKeyObjId
	/// parameter, an attempt is made to export the key as an RSA Public Key (szOID_RSA_RSA).
	/// </para>
	/// </param>
	/// <param name="dwFlags">
	/// <para>
	/// A <c>DWORD</c> flag value that indicates how the public key information is exported. The flag value is passed directly to the
	/// CryptFindOIDInfo function when mapping the public key object identifier to the corresponding CNG public key algorithm Unicode
	/// string. The following flag values can be set.
	/// </para>
	/// <list type="table">
	/// <listheader>
	/// <term>Value</term>
	/// <term>Meaning</term>
	/// </listheader>
	/// <item>
	/// <term>CRYPT_OID_INFO_PUBKEY_SIGN_KEY_FLAG</term>
	/// <term>
	/// Skips public keys in the CRYPT_PUBKEY_ALG_OID_GROUP_ID group explicitly flagged with the CRYPT_OID_PUBKEY_ENCRYPT_ONLY_FLAG flag.
	/// </term>
	/// </item>
	/// <item>
	/// <term>CRYPT_OID_INFO_PUBKEY_ENCRYPT_KEY_FLAG</term>
	/// <term>
	/// Skips public keys in the CRYPT_PUBKEY_ALG_OID_GROUP_ID group explicitly flagged with the CRYPT_OID_PUBKEY_SIGN_ONLY_FLAG flag.
	/// </term>
	/// </item>
	/// </list>
	/// </param>
	/// <param name="pvAuxInfo">This parameter is reserved for future use and must be set to <c>NULL</c>.</param>
	/// <param name="pInfo">
	/// <para>A pointer to a CERT_PUBLIC_KEY_INFO structure to receive the public key information to be exported.</para>
	/// <para>
	/// This parameter can be <c>NULL</c> to set the size of this information for memory allocation purposes. For more information, see
	/// Retrieving Data of Unknown Length.
	/// </para>
	/// </param>
	/// <param name="pcbInfo">
	/// <para>
	/// A pointer to a <c>DWORD</c> that contains the size, in bytes, of the buffer pointed to by the pInfo parameter. When the function
	/// returns, the <c>DWORD</c> contains the number of bytes stored in the buffer.
	/// </para>
	/// <para>
	/// <c>Note</c> When processing the data returned in the buffer, applications need to use the actual size of the data returned. The
	/// actual size can be slightly smaller than the size of the buffer specified on input. (On input, buffer sizes are usually
	/// specified large enough to ensure that the largest possible output data will fit in the buffer.) On output, the variable pointed
	/// to by this parameter is updated to reflect the actual size of the data copied to the buffer.
	/// </para>
	/// </param>
	/// <returns>
	/// <para>If the function succeeds, the return value is nonzero ( <c>TRUE</c>).</para>
	/// <para>If the function fails, the return value is zero ( <c>FALSE</c>). For extended error information, call GetLastError.</para>
	/// <para><c>Note</c> Errors from the called functions CryptGetUserKey and CryptExportKey can be propagated to this function.</para>
	/// <para>This function has the following error codes.</para>
	/// <list type="table">
	/// <listheader>
	/// <term>Return code</term>
	/// <term>Description</term>
	/// </listheader>
	/// <item>
	/// <term>ERROR_FILE_NOT_FOUND</term>
	/// <term>
	/// An export function that can be installed or registered could not be found for the specified dwCertEncodingType and
	/// pszPublicKeyObjId parameters.
	/// </term>
	/// </item>
	/// <item>
	/// <term>ERROR_MORE_DATA</term>
	/// <term>
	/// If the buffer specified by the pInfo parameter is not large enough to hold the returned data, the function sets the
	/// ERROR_MORE_DATA code and stores the required buffer size, in bytes, in the variable pointed to by the pcbInfo parameter.
	/// </term>
	/// </item>
	/// </list>
	/// <para>
	/// If the function fails, GetLastError may return an Abstract Syntax Notation One (ASN.1) encoding/decoding error. For information
	/// about these errors, see ASN.1 Encoding/Decoding Return Values.
	/// </para>
	/// </returns>
	// https://docs.microsoft.com/en-us/windows/win32/api/wincrypt/nf-wincrypt-cryptexportpublickeyinfoex BOOL
	// CryptExportPublicKeyInfoEx( HCRYPTPROV_OR_NCRYPT_KEY_HANDLE hCryptProvOrNCryptKey, DWORD dwKeySpec, DWORD dwCertEncodingType,
	// LPSTR pszPublicKeyObjId, DWORD dwFlags, void *pvAuxInfo, PCERT_PUBLIC_KEY_INFO pInfo, DWORD *pcbInfo );
	[DllImport(Lib.Crypt32, SetLastError = true, ExactSpelling = true)]
	[PInvokeData("wincrypt.h", MSDNShortId = "38274222-90b3-4038-86d3-6b2813100ce2")]
	[return: MarshalAs(UnmanagedType.Bool)]
	public static extern bool CryptExportPublicKeyInfoEx(HCRYPTPROV hCryptProvOrNCryptKey, CertKeySpec dwKeySpec, CertEncodingType dwCertEncodingType, SafeOID pszPublicKeyObjId,
		CryptOIDInfoFlags dwFlags, [In, Optional] IntPtr pvAuxInfo, [Out, Optional] IntPtr pInfo, ref uint pcbInfo);

	/// <summary>
	/// The <c>CryptExportPublicKeyInfoEx</c> function exports the public key information associated with the provider's corresponding
	/// private key. This function allows the application to specify the public key algorithm, overriding the default provided by the
	/// cryptographic service provider (CSP).
	/// </summary>
	/// <param name="hCryptProvOrNCryptKey">
	/// A handle of the CSP to use when exporting the public key information. This handle must be an HCRYPTPROV handle that has been
	/// created by using the CryptAcquireContext function or an <c>NCRYPT_KEY_HANDLE</c> handle that has been created by using the
	/// NCryptOpenKey function. New applications should always pass in the <c>NCRYPT_KEY_HANDLE</c> handle of a CNG CSP.
	/// </param>
	/// <param name="dwKeySpec">
	/// Identifies the private key to use from the provider's container. It can be AT_KEYEXCHANGE or AT_SIGNATURE. This parameter is
	/// ignored if an <c>NCRYPT_KEY_HANDLE</c> is used in the hCryptProvOrNCryptKey parameter.
	/// </param>
	/// <param name="dwCertEncodingType">
	/// <para>
	/// Specifies the encoding type used. It is always acceptable to specify both the certificate and message encoding types by
	/// combining them with a bitwise- <c>OR</c> operation as shown in the following example:
	/// </para>
	/// <para>X509_ASN_ENCODING | PKCS_7_ASN_ENCODING</para>
	/// <para>Currently defined encoding types are:</para>
	/// <list type="bullet">
	/// <item>
	/// <term>X509_ASN_ENCODING</term>
	/// </item>
	/// <item>
	/// <term>PKCS_7_ASN_ENCODING</term>
	/// </item>
	/// </list>
	/// </param>
	/// <param name="pszPublicKeyObjId">
	/// <para>Specifies the public key algorithm.</para>
	/// <para>
	/// <c>Note</c> pszPublicKeyObjId and dwCertEncodingType are used together to determine the installable
	/// <c>CRYPT_OID_EXPORT_PUBLIC_KEY_INFO_FUNC</c> to call. If an installable function was not found for the pszPublicKeyObjId
	/// parameter, an attempt is made to export the key as an RSA Public Key (szOID_RSA_RSA).
	/// </para>
	/// </param>
	/// <param name="dwFlags">
	/// <para>
	/// A <c>DWORD</c> flag value that indicates how the public key information is exported. The flag value is passed directly to the
	/// CryptFindOIDInfo function when mapping the public key object identifier to the corresponding CNG public key algorithm Unicode
	/// string. The following flag values can be set.
	/// </para>
	/// <list type="table">
	/// <listheader>
	/// <term>Value</term>
	/// <term>Meaning</term>
	/// </listheader>
	/// <item>
	/// <term>CRYPT_OID_INFO_PUBKEY_SIGN_KEY_FLAG</term>
	/// <term>
	/// Skips public keys in the CRYPT_PUBKEY_ALG_OID_GROUP_ID group explicitly flagged with the CRYPT_OID_PUBKEY_ENCRYPT_ONLY_FLAG flag.
	/// </term>
	/// </item>
	/// <item>
	/// <term>CRYPT_OID_INFO_PUBKEY_ENCRYPT_KEY_FLAG</term>
	/// <term>
	/// Skips public keys in the CRYPT_PUBKEY_ALG_OID_GROUP_ID group explicitly flagged with the CRYPT_OID_PUBKEY_SIGN_ONLY_FLAG flag.
	/// </term>
	/// </item>
	/// </list>
	/// </param>
	/// <param name="pvAuxInfo">This parameter is reserved for future use and must be set to <c>NULL</c>.</param>
	/// <param name="pInfo">
	/// <para>A pointer to a CERT_PUBLIC_KEY_INFO structure to receive the public key information to be exported.</para>
	/// <para>
	/// This parameter can be <c>NULL</c> to set the size of this information for memory allocation purposes. For more information, see
	/// Retrieving Data of Unknown Length.
	/// </para>
	/// </param>
	/// <param name="pcbInfo">
	/// <para>
	/// A pointer to a <c>DWORD</c> that contains the size, in bytes, of the buffer pointed to by the pInfo parameter. When the function
	/// returns, the <c>DWORD</c> contains the number of bytes stored in the buffer.
	/// </para>
	/// <para>
	/// <c>Note</c> When processing the data returned in the buffer, applications need to use the actual size of the data returned. The
	/// actual size can be slightly smaller than the size of the buffer specified on input. (On input, buffer sizes are usually
	/// specified large enough to ensure that the largest possible output data will fit in the buffer.) On output, the variable pointed
	/// to by this parameter is updated to reflect the actual size of the data copied to the buffer.
	/// </para>
	/// </param>
	/// <returns>
	/// <para>If the function succeeds, the return value is nonzero ( <c>TRUE</c>).</para>
	/// <para>If the function fails, the return value is zero ( <c>FALSE</c>). For extended error information, call GetLastError.</para>
	/// <para><c>Note</c> Errors from the called functions CryptGetUserKey and CryptExportKey can be propagated to this function.</para>
	/// <para>This function has the following error codes.</para>
	/// <list type="table">
	/// <listheader>
	/// <term>Return code</term>
	/// <term>Description</term>
	/// </listheader>
	/// <item>
	/// <term>ERROR_FILE_NOT_FOUND</term>
	/// <term>
	/// An export function that can be installed or registered could not be found for the specified dwCertEncodingType and
	/// pszPublicKeyObjId parameters.
	/// </term>
	/// </item>
	/// <item>
	/// <term>ERROR_MORE_DATA</term>
	/// <term>
	/// If the buffer specified by the pInfo parameter is not large enough to hold the returned data, the function sets the
	/// ERROR_MORE_DATA code and stores the required buffer size, in bytes, in the variable pointed to by the pcbInfo parameter.
	/// </term>
	/// </item>
	/// </list>
	/// <para>
	/// If the function fails, GetLastError may return an Abstract Syntax Notation One (ASN.1) encoding/decoding error. For information
	/// about these errors, see ASN.1 Encoding/Decoding Return Values.
	/// </para>
	/// </returns>
	// https://docs.microsoft.com/en-us/windows/win32/api/wincrypt/nf-wincrypt-cryptexportpublickeyinfoex BOOL
	// CryptExportPublicKeyInfoEx( HCRYPTPROV_OR_NCRYPT_KEY_HANDLE hCryptProvOrNCryptKey, DWORD dwKeySpec, DWORD dwCertEncodingType,
	// LPSTR pszPublicKeyObjId, DWORD dwFlags, void *pvAuxInfo, PCERT_PUBLIC_KEY_INFO pInfo, DWORD *pcbInfo );
	[DllImport(Lib.Crypt32, SetLastError = true, ExactSpelling = true)]
	[PInvokeData("wincrypt.h", MSDNShortId = "38274222-90b3-4038-86d3-6b2813100ce2")]
	[return: MarshalAs(UnmanagedType.Bool)]
	public static extern bool CryptExportPublicKeyInfoEx(NCrypt.NCRYPT_KEY_HANDLE hCryptProvOrNCryptKey, CertKeySpec dwKeySpec, CertEncodingType dwCertEncodingType, SafeOID pszPublicKeyObjId,
		CryptOIDInfoFlags dwFlags, [In, Optional] IntPtr pvAuxInfo, [Out, Optional] IntPtr pInfo, ref uint pcbInfo);

	/// <summary>
	/// The <c>CryptExportPublicKeyInfoFromBCryptKeyHandle</c> function exports the public key information associated with a provider's
	/// corresponding private key.
	/// </summary>
	/// <param name="hBCryptKey">The handle of the key from which to export the public key information.</param>
	/// <param name="dwCertEncodingType">
	/// <para>Specifies the encoding type to be matched.</para>
	/// <para>This value can be a bitwise combination of the currently defined encoding types:</para>
	/// <list type="bullet">
	/// <item>
	/// <term>X509_ASN_ENCODING</term>
	/// </item>
	/// <item>
	/// <term>PKCS_7_ASN_ENCODING</term>
	/// </item>
	/// </list>
	/// </param>
	/// <param name="pszPublicKeyObjId">
	/// A pointer to the object identifier (OID) that identifies the installable function to use to export the key. If the high-order
	/// word of the OID is nonzero, pszPublicKeyObjId is a pointer to either an OID string such as "2.5.29.1" or an ASCII string such as
	/// "file." If the high-order word of the OID is zero, the low-order word specifies the integer identifier to be used as the object identifier.
	/// </param>
	/// <param name="dwFlags">
	/// <para>A <c>DWORD</c> value that indicates how the public key information is exported.</para>
	/// <list type="table">
	/// <listheader>
	/// <term>Value</term>
	/// <term>Meaning</term>
	/// </listheader>
	/// <item>
	/// <term>CRYPT_OID_INFO_PUBKEY_SIGN_KEY_FLAG 0x80000000</term>
	/// <term>
	/// Skips public keys in the CRYPT_PUBKEY_ALG_OID_GROUP_ID group that are explicitly flagged with the
	/// CRYPT_OID_PUBKEY_ENCRYPT_ONLY_FLAG flag.
	/// </term>
	/// </item>
	/// <item>
	/// <term>CRYPT_OID_INFO_PUBKEY_ENCRYPT_KEY_FLAG 0x40000000</term>
	/// <term>
	/// Skips public keys in the CRYPT_PUBKEY_ALG_OID_GROUP_ID group that are explicitly flagged with the
	/// CRYPT_OID_PUBKEY_SIGN_ONLY_FLAG flag.
	/// </term>
	/// </item>
	/// </list>
	/// </param>
	/// <param name="pvAuxInfo">This parameter is reserved for future use and must be set to <c>NULL</c>.</param>
	/// <param name="pInfo">
	/// <para>A pointer to a CERT_PUBLIC_KEY_INFO structure to receive the public key information to be exported.</para>
	/// <para>
	/// This parameter can be <c>NULL</c> to set the size of this information for memory allocation purposes. For more information, see
	/// Retrieving Data of Unknown Length.
	/// </para>
	/// </param>
	/// <param name="pcbInfo">
	/// A pointer to a <c>DWORD</c> that contains the size, in bytes, of the buffer pointed to by the pInfo parameter. When the function
	/// returns, the <c>DWORD</c> contains the number of bytes stored in the buffer.
	/// </param>
	/// <returns>The function returns <c>TRUE</c> if it succeeds; otherwise, it returns <c>FALSE</c>.</returns>
	/// <remarks>
	/// If the <c>CryptExportPublicKeyInfoFromBCryptKeyHandle</c> function is unable to find an installable OID function for the OID
	/// specified by the pszPublicKeyObjId parameter, it attempts to export the key as a RSA Public Key ( <c>szOID_RSA_RSA</c>). If the
	/// key is exported as a RSA Public Key, the values of the dwFlags and pvAuxInfo parameters are not used.
	/// </remarks>
	// https://docs.microsoft.com/en-us/windows/win32/api/wincrypt/nf-wincrypt-cryptexportpublickeyinfofrombcryptkeyhandle BOOL
	// CryptExportPublicKeyInfoFromBCryptKeyHandle( BCRYPT_KEY_HANDLE hBCryptKey, DWORD dwCertEncodingType, LPSTR pszPublicKeyObjId,
	// DWORD dwFlags, void *pvAuxInfo, PCERT_PUBLIC_KEY_INFO pInfo, DWORD *pcbInfo );
	[DllImport(Lib.Crypt32, SetLastError = false, ExactSpelling = true)]
	[PInvokeData("wincrypt.h", MSDNShortId = "f96bff4a-d354-4231-907a-383aff5cfacc")]
	[return: MarshalAs(UnmanagedType.Bool)]
	public static extern bool CryptExportPublicKeyInfoFromBCryptKeyHandle(BCrypt.BCRYPT_KEY_HANDLE hBCryptKey, CertEncodingType dwCertEncodingType, SafeOID pszPublicKeyObjId,
		CryptOIDInfoFlags dwFlags, [In, Optional] IntPtr pvAuxInfo, [Out, Optional] IntPtr pInfo, ref uint pcbInfo);

	/// <summary>
	/// The <c>CryptFindCertificateKeyProvInfo</c> function enumerates the cryptographic providers and their containers to find the
	/// private key that corresponds to the certificate's public key.
	/// </summary>
	/// <param name="pCert">A pointer to the CERT_CONTEXT structure of the certificate to use when exporting public key information.</param>
	/// <param name="dwFlags">
	/// <para>A set of flags that modify the behavior of this function. This can be zero or one of the following values.</para>
	/// <list type="table">
	/// <listheader>
	/// <term>Value</term>
	/// <term>Meaning</term>
	/// </listheader>
	/// <item>
	/// <term>CRYPT_FIND_USER_KEYSET_FLAG</term>
	/// <term>Restricts the search to the user container. The default is to search both the user and machine containers.</term>
	/// </item>
	/// <item>
	/// <term>CRYPT_FIND_MACHINE_KEYSET_FLAG</term>
	/// <term>Restricts the search to the machine container. The default is to search both the user and machine containers.</term>
	/// </item>
	/// <item>
	/// <term>CRYPT_FIND_SILENT_KEYSET_FLAG</term>
	/// <term>
	/// The application requests that the CSP not display any user interface (UI) for this context. If the CSP must display the UI to
	/// operate, the call fails and the NTE_SILENT_CONTEXT error code is set as the last error.
	/// </term>
	/// </item>
	/// </list>
	/// <para>
	/// The following flags determine which technology is used to obtain the key. If none of these flags is present, this function will
	/// only attempt to obtain the key by using CryptoAPI.
	/// </para>
	/// <para><c>Windows Server 2003 and Windows XP:</c> These flags are not supported.</para>
	/// <list type="table">
	/// <listheader>
	/// <term>Value</term>
	/// <term>Meaning</term>
	/// </listheader>
	/// <item>
	/// <term>CRYPT_ACQUIRE_ALLOW_NCRYPT_KEY_FLAG</term>
	/// <term>
	/// This function will attempt to obtain the key by using CryptoAPI. If that fails, this function will attempt to obtain the key by
	/// using the Cryptography API: Next Generation (CNG). The CERT_KEY_PROV_INFO_PROP_ID property of the certificate is set to zero if
	/// CNG is used to obtain the key.
	/// </term>
	/// </item>
	/// <item>
	/// <term>CRYPT_ACQUIRE_ONLY_NCRYPT_KEY_FLAG</term>
	/// <term>
	/// This function will only attempt to obtain the key by using CNG and will not use CryptoAPI to obtain the key. The
	/// CERT_KEY_PROV_INFO_PROP_ID property of the certificate is set to zero if CNG is used to obtain the key.
	/// </term>
	/// </item>
	/// <item>
	/// <term>CRYPT_ACQUIRE_PREFER_NCRYPT_KEY_FLAG</term>
	/// <term>
	/// This function will attempt to obtain the key by using CNG. If that fails, this function will attempt to obtain the key by using
	/// CryptoAPI. The CERT_KEY_PROV_INFO_PROP_ID property of the certificate is set to zero if CNG is used to obtain the key.
	/// </term>
	/// </item>
	/// </list>
	/// </param>
	/// <param name="pvReserved">Reserved for future use and must be <c>NULL</c>.</param>
	/// <returns>
	/// <para>
	/// <c>TRUE</c> if the function finds a private key that corresponds to the certificate's public key within a searched container;
	/// <c>FALSE</c> if the function fails to find a container or a private key within a container.
	/// </para>
	/// <para>GetLastError returns the following error:</para>
	/// <list type="table">
	/// <listheader>
	/// <term>Return code</term>
	/// <term>Description</term>
	/// </listheader>
	/// <item>
	/// <term>NTE_NO_KEY</term>
	/// <term>No container found.</term>
	/// </item>
	/// </list>
	/// </returns>
	/// <remarks>
	/// This function enumerates the cryptographic providers and their containers to find the private key that corresponds to the
	/// certificate's public key. For a match, the function updates the certificate's <c>CERT_KEY_PROV_INFO_PROP_ID</c> property. If the
	/// <c>CERT_KEY_PROV_INFO_PROP_ID</c> is already set, it is checked to determine whether it matches the provider's public key. For a
	/// match, the function skips the previously mentioned enumeration.
	/// </remarks>
	// https://docs.microsoft.com/en-us/windows/win32/api/wincrypt/nf-wincrypt-cryptfindcertificatekeyprovinfo BOOL
	// CryptFindCertificateKeyProvInfo( PCCERT_CONTEXT pCert, DWORD dwFlags, void *pvReserved );
	[DllImport(Lib.Crypt32, SetLastError = true, ExactSpelling = true)]
	[PInvokeData("wincrypt.h", MSDNShortId = "9e63517d-a56e-45a9-972c-de9a297e9e25")]
	[return: MarshalAs(UnmanagedType.Bool)]
	public static extern bool CryptFindCertificateKeyProvInfo(PCCERT_CONTEXT pCert, CryptFindFlags dwFlags, IntPtr pvReserved = default);

	/// <summary>
	/// The <c>CryptFindLocalizedName</c> function finds the localized name for the specified name, such as the localize name of the
	/// "Root" system store. This function can be used before displaying any UI that included a name that might have a localized form.
	/// </summary>
	/// <param name="pwszCryptName">
	/// <para>
	/// A pointer to a specified name. An internal table is searched to compare a predefined localized name to the specified name. The
	/// search matches the localized name by using a case insensitive string comparison.
	/// </para>
	/// <para>
	/// <c>Note</c> Localized names for the predefined system stores ("Root", "My") and predefined physical stores (".Default",
	/// ".LocalMachine") are preinstalled as resource strings in Crypt32.dll.
	/// </para>
	/// </param>
	/// <returns>
	/// <para>If the specified name is found, a pointer to the localized name is returned. The returned pointer must not be freed.</para>
	/// <para>If the specified name is not found, <c>NULL</c> is returned.</para>
	/// </returns>
	/// <remarks>
	/// <para>CryptSetOIDFunctionValue can be called as follows to register additional localized strings.</para>
	/// <para>dwEncodingType = CRYPT_LOCALIZED_NAME_ENCODING_TYPE</para>
	/// <para>pszFuncName = CRYPT_OID_FIND_LOCALIZED_NAME_FUNC</para>
	/// <para>pszOID = CRYPT_LOCALIZED_NAME_OID</para>
	/// <para>pwszValueName = Name to be localized, for example, L"ApplicationStore"</para>
	/// <para>dwValueType = REG_SZ</para>
	/// <para>pbValueData = pointer to the Unicode localized string</para>
	/// <para>cbValueData = (wcslen(Unicode localized string) + 1) * sizeof(WCHAR)</para>
	/// <para>CryptSetOIDFunctionValue can be called as follows to unregister the localized strings.</para>
	/// <para>pbValueData = <c>NULL</c></para>
	/// <para>cbValueData = 0.</para>
	/// <para>The registered names are searched before the preinstalled names.</para>
	/// <list type="table">
	/// <listheader>
	/// <term>CRYPT_LOCALIZED_NAME_ ENCODING_TYPE</term>
	/// <term>0</term>
	/// </listheader>
	/// <item>
	/// <term>CRYPT_LOCALIZED_NAME_ OID</term>
	/// <term>"LocalizedNames"</term>
	/// </item>
	/// <item>
	/// <term>CRYPT_OID_FIND_LOCALIZED_ NAME_FUNC</term>
	/// <term>"CryptDLLFindLocalizedName"</term>
	/// </item>
	/// </list>
	/// <para>Examples</para>
	/// <para>For an example that uses this function, see Example C Program: Setting and Getting Certificate Store Properties.</para>
	/// </remarks>
	// https://docs.microsoft.com/en-us/windows/win32/api/wincrypt/nf-wincrypt-cryptfindlocalizedname LPCWSTR CryptFindLocalizedName(
	// LPCWSTR pwszCryptName );
	[DllImport(Lib.Crypt32, SetLastError = false, ExactSpelling = true)]
	[PInvokeData("wincrypt.h", MSDNShortId = "8f0006a9-0930-4b71-87ce-e72371095e4c")]
	[return: MarshalAs(UnmanagedType.LPWStr)]
	public static extern StrPtrUni CryptFindLocalizedName([MarshalAs(UnmanagedType.LPWStr)] string pwszCryptName);

	/// <summary>
	/// <note>Important: This API is deprecated. New and existing software should start using Cryptography Next Generation APIs.
	/// Microsoft may remove this API in future releases.</note>
	/// <para>The CryptHashCertificate function hashes the entire encoded content of a certificate including its signature.</para>
	/// </summary>
	/// <param name="hCryptProv">
	/// <para>This parameter is not used and should be set to <c>NULL</c>.</para>
	/// <para>
	/// <c>Windows Server 2003 and Windows XP:</c> A handle of the cryptographic service provider (CSP) to use to compute the hash.
	/// </para>
	/// <para>This parameter's data type is <c>HCRYPTPROV</c>.</para>
	/// <para>
	/// Unless there is a strong reason for passing in a specific CSP in hCryptProv, zero is passed in. Passing in zero causes the
	/// default RSA or Digital Signature Standard (DSS) provider to be acquired before doing hash, signature verification, or recipient
	/// encryption operations.
	/// </para>
	/// </param>
	/// <param name="Algid">
	/// An ALG_ID structure that specifies the hash algorithm to use. If Algid is zero, the default hash algorithm, SHA1, is used.
	/// </param>
	/// <param name="dwFlags">Value to be passed to the hash API. For details, see CryptCreateHash.</param>
	/// <param name="pbEncoded">Address of the encoded content to be hashed.</param>
	/// <param name="cbEncoded">The size, in bytes, of the encoded content.</param>
	/// <param name="pbComputedHash">
	/// <para>A pointer to a buffer to receive the computed hash.</para>
	/// <para>
	/// To set the size of this information for memory allocation purposes, this parameter can be <c>NULL</c>. For more information, see
	/// Retrieving Data of Unknown Length.
	/// </para>
	/// </param>
	/// <param name="pcbComputedHash">
	/// <para>
	/// A pointer to a <c>DWORD</c> that contains the size, in bytes, of the buffer pointed to by the pbComputedHash parameter. When the
	/// function returns, the <c>DWORD</c> contains the number of bytes stored in the buffer.
	/// </para>
	/// <para>
	/// <c>Note</c> When processing the data returned in the buffer, applications need to use the actual size of the data returned. The
	/// actual size can be slightly smaller than the size of the buffer specified on input. On input, buffer sizes are usually specified
	/// large enough to ensure that the largest possible output data will fit in the buffer. On output, the variable pointed to by this
	/// parameter is updated to reflect the actual size of the data copied to the buffer.
	/// </para>
	/// </param>
	/// <returns>
	/// <para>If the function succeeds, the function returns nonzero ( <c>TRUE</c>).</para>
	/// <para>If the function fails, it returns zero ( <c>FALSE</c>). For extended error information, call GetLastError.</para>
	/// <para>
	/// <c>Note</c> Errors from the called functions CryptCreateHash, CryptGetHashParam and CryptHashData might be propagated to this function.
	/// </para>
	/// </returns>
	// https://docs.microsoft.com/en-us/windows/win32/api/wincrypt/nf-wincrypt-crypthashcertificate BOOL CryptHashCertificate(
	// HCRYPTPROV_LEGACY hCryptProv, ALG_ID Algid, DWORD dwFlags, const BYTE *pbEncoded, DWORD cbEncoded, BYTE *pbComputedHash, DWORD
	// *pcbComputedHash );
	[DllImport(Lib.Crypt32, SetLastError = true, ExactSpelling = true)]
	[PInvokeData("wincrypt.h", MSDNShortId = "a5beba30-f32b-4d57-8a54-7d9096459c50")]
	[return: MarshalAs(UnmanagedType.Bool)]
	public static extern bool CryptHashCertificate([Optional] HCRYPTPROV hCryptProv, ALG_ID Algid, [Optional] uint dwFlags, [In] IntPtr pbEncoded,
		uint cbEncoded, [Out] IntPtr pbComputedHash, ref uint pcbComputedHash);

	/// <summary>The <c>CryptHashCertificate2</c> function hashes a block of data by using a CNG hash provider.</summary>
	/// <param name="pwszCNGHashAlgid">
	/// The address of a null-terminated Unicode string that contains the CNG hash algorithm identifier of the hash algorithm to use to
	/// hash the certificate. This can be one of the CNG Algorithm Identifiers that represents a hash algorithm or any other registered
	/// hash algorithm identifier.
	/// </param>
	/// <param name="dwFlags">A set of flags that modify the behavior of this function. No flags are defined for this function.</param>
	/// <param name="pvReserved">Reserved for future use and must be <c>NULL</c>.</param>
	/// <param name="pbEncoded">The address of an array of bytes to be hashed. The cbEncoded parameter contains the size of this array.</param>
	/// <param name="cbEncoded">The number of elements in the pbEncoded array.</param>
	/// <param name="pbComputedHash">
	/// The address of a buffer that receives the computed hash. The variable pointed to by the pcbComputedHash parameter contains the
	/// size of this buffer.
	/// </param>
	/// <param name="pcbComputedHash">
	/// The address of a <c>DWORD</c> variable that, on entry, contains the size, in bytes, of the pbComputedHash buffer. After this
	/// function returns, this variable contains the number of bytes copied to the pbComputedHash buffer.
	/// </param>
	/// <returns>
	/// <para>If the function succeeds, the function returns nonzero ( <c>TRUE</c>).</para>
	/// <para>
	/// If the function fails, it returns zero ( <c>FALSE</c>). For extended error information, call GetLastError. Some of the possible
	/// error codes are identified in the following topics.
	/// </para>
	/// </returns>
	// https://docs.microsoft.com/en-us/windows/win32/api/wincrypt/nf-wincrypt-crypthashcertificate2 BOOL CryptHashCertificate2( LPCWSTR
	// pwszCNGHashAlgid, DWORD dwFlags, void *pvReserved, const BYTE *pbEncoded, DWORD cbEncoded, BYTE *pbComputedHash, DWORD
	// *pcbComputedHash );
	[DllImport(Lib.Crypt32, SetLastError = true, ExactSpelling = true)]
	[PInvokeData("wincrypt.h", MSDNShortId = "9f315374-0002-499a-81ea-efcb3c19e68f")]
	[return: MarshalAs(UnmanagedType.Bool)]
	public static extern bool CryptHashCertificate2([MarshalAs(UnmanagedType.LPWStr)] string pwszCNGHashAlgid, [Optional] uint dwFlags,
		[Optional] IntPtr pvReserved, [In] IntPtr pbEncoded, uint cbEncoded, [Out] IntPtr pbComputedHash, ref uint pcbComputedHash);

	/// <summary>
	/// <note>Important: This API is deprecated. New and existing software should start using Cryptography Next Generation APIs.
	/// Microsoft may remove this API in future releases.</note>
	/// <para>
	/// The CryptHashPublicKeyInfo function encodes the public key information in a CERT_PUBLIC_KEY_INFO structure and computes the hash
	/// of the encoded bytes.The hash created is used with key identifier functions.
	/// </para>
	/// </summary>
	/// <param name="hCryptProv">
	/// <para>This parameter is not used and should be set to <c>NULL</c>.</para>
	/// <para>
	/// <c>Windows Server 2003 and Windows XP:</c> A handle of the cryptographic service provider (CSP) to use to compute the hash.This
	/// parameter's data type is <c>HCRYPTPROV</c>.
	/// </para>
	/// <para>
	/// Unless there is a strong reason for passing in a specific cryptographic provider in hCryptProv, zero is passed in. Passing in
	/// zero causes the default RSA or Digital Signature Standard (DSS) provider to be acquired before doing hash, signature
	/// verification, or recipient encryption operations.
	/// </para>
	/// </param>
	/// <param name="Algid">
	/// An ALG_ID structure that specifies the CryptoAPI hash algorithm to use. If Algid is zero, the default hash algorithm, SHA1, is used.
	/// </param>
	/// <param name="dwFlags">Values to be passed on to CryptCreateHash.</param>
	/// <param name="dwCertEncodingType">
	/// <para>
	/// Specifies the encoding type used. It is always acceptable to specify both the certificate and message encoding types by
	/// combining them with a bitwise- <c>OR</c> operation as shown in the following example:
	/// </para>
	/// <para>X509_ASN_ENCODING | PKCS_7_ASN_ENCODING</para>
	/// <para>Currently defined encoding types are:</para>
	/// <list type="bullet">
	/// <item>
	/// <term>X509_ASN_ENCODING</term>
	/// </item>
	/// <item>
	/// <term>PKCS_7_ASN_ENCODING</term>
	/// </item>
	/// </list>
	/// </param>
	/// <param name="pInfo">
	/// A pointer to a CERT_PUBLIC_KEY_INFO structure that contains the public key information to be encoded and hashed.
	/// </param>
	/// <param name="pbComputedHash">
	/// <para>A pointer to a buffer to receive the computed hash.</para>
	/// <para>
	/// To set the size of this information for memory allocation purposes, this parameter can be <c>NULL</c>. For more information, see
	/// Retrieving Data of Unknown Length.
	/// </para>
	/// </param>
	/// <param name="pcbComputedHash">
	/// <para>
	/// A pointer to a <c>DWORD</c> that contains the size, in bytes, of the buffer pointed to by the pbComputedHash parameter. When the
	/// function returns, the <c>DWORD</c> contains the number of bytes stored in the buffer.
	/// </para>
	/// <para>
	/// <c>Note</c> When processing the data returned in the buffer, applications need to use the actual size of the data returned. The
	/// actual size can be slightly smaller than the size of the buffer specified on input. On input, buffer sizes are usually specified
	/// large enough to ensure that the largest possible output data will fit in the buffer. On output, the variable pointed to by this
	/// parameter is updated to reflect the actual size of the data copied to the buffer.
	/// </para>
	/// </param>
	/// <returns>
	/// <para>If the function succeeds, the function returns nonzero ( <c>TRUE</c>).</para>
	/// <para>If the function fails, it returns zero ( <c>FALSE</c>). For extended error information, call GetLastError.</para>
	/// <para>
	/// <c>Note</c> Errors from the called functions CryptCreateHash, CryptGetHashParam, and CryptHashData can be propagated to this
	/// function. This function has the following error codes.
	/// </para>
	/// <list type="table">
	/// <listheader>
	/// <term>Return code</term>
	/// <term>Description</term>
	/// </listheader>
	/// <item>
	/// <term>ERROR_MORE_DATA</term>
	/// <term>
	/// If the buffer specified by the pbComputedHash parameter is not large enough to hold the returned data, the function sets the
	/// ERROR_MORE_DATA code, and stores the required buffer size, in bytes, in the variable pointed to by pcbComputedHash.
	/// </term>
	/// </item>
	/// <item>
	/// <term>ERROR_FILE_NOT_FOUND</term>
	/// <term>Invalid certificate encoding type. Currently only X509_ASN_ENCODING is supported.</term>
	/// </item>
	/// </list>
	/// <para>
	/// If the function fails, GetLastError may return an Abstract Syntax Notation One (ASN.1) encoding/decoding error. For information
	/// about these errors, see ASN.1 Encoding/Decoding Return Values.
	/// </para>
	/// </returns>
	// https://docs.microsoft.com/en-us/windows/win32/api/wincrypt/nf-wincrypt-crypthashpublickeyinfo BOOL CryptHashPublicKeyInfo(
	// HCRYPTPROV_LEGACY hCryptProv, ALG_ID Algid, DWORD dwFlags, DWORD dwCertEncodingType, PCERT_PUBLIC_KEY_INFO pInfo, BYTE
	// *pbComputedHash, DWORD *pcbComputedHash );
	[DllImport(Lib.Crypt32, SetLastError = true, ExactSpelling = true)]
	[PInvokeData("wincrypt.h", MSDNShortId = "b0c419b7-ebb3-42c6-9f6a-59b55a2db1b2")]
	[return: MarshalAs(UnmanagedType.Bool)]
	public static extern bool CryptHashPublicKeyInfo([Optional] HCRYPTPROV hCryptProv, ALG_ID Algid, [Optional] uint dwFlags, CertEncodingType dwCertEncodingType,
		in CERT_PUBLIC_KEY_INFO pInfo, [Out] IntPtr pbComputedHash, ref uint pcbComputedHash);

	/// <summary>
	/// <note>Important: This API is deprecated. New and existing software should start using Cryptography Next Generation APIs.
	/// Microsoft may remove this API in future releases.</note>
	/// <para>
	/// The CryptHashToBeSigned function computes the hash of the encoded content from a signed and encoded certificate. The hash is
	/// performed on only the "to be signed" encoded content and its signature.
	/// </para>
	/// </summary>
	/// <param name="hCryptProv">
	/// <para>This parameter is not used and should be set to <c>NULL</c>.</para>
	/// <para>
	/// <c>Windows Server 2003 and Windows XP:</c> A handle of the cryptographic service provider (CSP) to use to compute the hash.This
	/// parameter's data type is <c>HCRYPTPROV</c>.
	/// </para>
	/// <para>
	/// Unless there is a strong reason for passing in a specific cryptographic provider in hCryptProv, zero is passed in. Passing in
	/// zero causes the default RSA or Digital Signature Standard (DSS) provider to be acquired before doing hash, signature
	/// verification, or recipient encryption operations.
	/// </para>
	/// </param>
	/// <param name="dwCertEncodingType">
	/// <para>
	/// Specifies the encoding type used. It is always acceptable to specify both the certificate and message encoding types by
	/// combining them with a bitwise- <c>OR</c> operation as shown in the following example:
	/// </para>
	/// <para>X509_ASN_ENCODING | PKCS_7_ASN_ENCODING</para>
	/// <para>Currently defined encoding types are:</para>
	/// <list type="bullet">
	/// <item>
	/// <term>X509_ASN_ENCODING</term>
	/// </item>
	/// <item>
	/// <term>PKCS_7_ASN_ENCODING</term>
	/// </item>
	/// </list>
	/// </param>
	/// <param name="pbEncoded">Address of a buffer that contains the content to be hashed. This is the encoded form of a CERT_SIGNED_CONTENT_INFO.</param>
	/// <param name="cbEncoded">The size, in bytes, of the buffer.</param>
	/// <param name="pbComputedHash">
	/// <para>A pointer to a buffer to receive the computed hash.</para>
	/// <para>
	/// This parameter can be <c>NULL</c> to set the size of this information for memory allocation purposes. For more information, see
	/// Retrieving Data of Unknown Length.
	/// </para>
	/// </param>
	/// <param name="pcbComputedHash">
	/// <para>
	/// A pointer to a <c>DWORD</c> that contains the size, in bytes, of the buffer pointed to by the pbComputedHash parameter. When the
	/// function returns, the <c>DWORD</c> contains the number of bytes stored in the buffer.
	/// </para>
	/// <para>
	/// <c>Note</c> When processing the data returned in the buffer, applications need to use the actual size of the data returned. The
	/// actual size can be slightly smaller than the size of the buffer specified on input. On input, buffer sizes are usually specified
	/// large enough to ensure that the largest possible output data will fit in the buffer. On output, the variable pointed to by this
	/// parameter is updated to reflect the actual size of the data copied to the buffer.
	/// </para>
	/// </param>
	/// <returns>
	/// <para>If the function succeeds, the function returns nonzero ( <c>TRUE</c>).</para>
	/// <para>If the function fails, it returns zero ( <c>FALSE</c>). For extended error information, call GetLastError.</para>
	/// <para>
	/// <c>Note</c> Errors from the called functions CryptCreateHash, CryptGetHashParam, and CryptHashData might be propagated to this
	/// function. This function has the following error codes.
	/// </para>
	/// <list type="table">
	/// <listheader>
	/// <term>Return code</term>
	/// <term>Description</term>
	/// </listheader>
	/// <item>
	/// <term>ERROR_MORE_DATA</term>
	/// <term>
	/// If the buffer specified by the pbComputedHash parameter is not large enough to hold the returned data, the function sets the
	/// ERROR_MORE_DATA code, and stores the required buffer size, in bytes, into the variable pointed to by pcbComputedHash.
	/// </term>
	/// </item>
	/// <item>
	/// <term>ERROR_FILE_NOT_FOUND</term>
	/// <term>Invalid certificate encoding type. Currently only X509_ASN_ENCODING is supported.</term>
	/// </item>
	/// <item>
	/// <term>NTE_BAD_ALGID</term>
	/// <term>The object identifier (OID) of the signature algorithm does not map to a known or supported hash algorithm.</term>
	/// </item>
	/// </list>
	/// <para>
	/// If the function fails, GetLastError may return an Abstract Syntax Notation One (ASN.1) encoding/decoding error. For information
	/// about these errors, see ASN.1 Encoding/Decoding Return Values.
	/// </para>
	/// </returns>
	// https://docs.microsoft.com/en-us/windows/win32/api/wincrypt/nf-wincrypt-crypthashtobesigned BOOL CryptHashToBeSigned(
	// HCRYPTPROV_LEGACY hCryptProv, DWORD dwCertEncodingType, const BYTE *pbEncoded, DWORD cbEncoded, BYTE *pbComputedHash, DWORD
	// *pcbComputedHash );
	[DllImport(Lib.Crypt32, SetLastError = true, ExactSpelling = true)]
	[PInvokeData("wincrypt.h", MSDNShortId = "84477054-dd76-4dde-b465-9edeaf192714")]
	[return: MarshalAs(UnmanagedType.Bool)]
	public static extern bool CryptHashToBeSigned([Optional] HCRYPTPROV hCryptProv, CertEncodingType dwCertEncodingType, [In] IntPtr pbEncoded,
		uint cbEncoded, [Out] IntPtr pbComputedHash, ref uint pcbComputedHash);

	/// <summary>
	/// <para>
	/// [The <c>CryptImportPKCS8</c> function is no longer available for use as of Windows Server 2008 and Windows Vista. Instead, use
	/// the PFXImportCertStore function.]
	/// </para>
	/// <para>
	/// <c>Important</c> This API is deprecated. New and existing software should start using Cryptography Next Generation APIs.
	/// Microsoft may remove this API in future releases.
	/// </para>
	/// <para>
	/// The <c>CryptImportPKCS8</c> function imports the private key in PKCS #8 format to a cryptographic service provider (CSP).
	/// <c>CryptImportPKCS8</c> will return a handle to the provider and the import KeySpec used.
	/// </para>
	/// </summary>
	/// <param name="sPrivateKeyAndParams">
	/// A CRYPT_PKCS8_IMPORT_PARAMS structure that contains the private key BLOB and corresponding parameters.
	/// </param>
	/// <param name="dwFlags">
	/// <para>A <c>DWORD</c> value. This parameter can be one of the following values, a combination of them, or a null value.</para>
	/// <list type="table">
	/// <listheader>
	/// <term>Value</term>
	/// <term>Meaning</term>
	/// </listheader>
	/// <item>
	/// <term>CRYPT_EXPORTABLE</term>
	/// <term>
	/// The key being imported is eventually to be reexported. If this flag is not used, then calls to CryptExportKey with the key
	/// handle fail.
	/// </term>
	/// </item>
	/// <item>
	/// <term>CRYPT_USER_PROTECTED</term>
	/// <term>
	/// If this flag is set, the CSP notifies the user through a dialog box or some other method when certain actions are attempted
	/// using this key. The precise behavior is specified by the CSP or the CSP type used. If the provider context was acquired with
	/// CRYPT_SILENT set, using this flag causes a failure, and the last error is set to NTE_SILENT_CONTEXT.
	/// </term>
	/// </item>
	/// </list>
	/// </param>
	/// <param name="phCryptProv">
	/// <para>
	/// A pointer to the HCRYPTPROV to receive the handle of the provider into which the key is imported by calling the
	/// <c>CryptImportPKCS8</c> function.
	/// </para>
	/// <para>When you have finished using the handle, free the handle by calling CryptReleaseContext.</para>
	/// <para>This parameter can be <c>NULL</c>, in which case the handle of the provider is not returned.</para>
	/// </param>
	/// <param name="pvAuxInfo">This parameter must be <c>NULL</c>.</param>
	/// <returns>
	/// <para>If the function succeeds, the function returns nonzero ( <c>TRUE</c>).</para>
	/// <para>If the function fails, it returns zero ( <c>FALSE</c>). For extended error information, call GetLastError.</para>
	/// <para>The following error code is specific to this function.</para>
	/// <list type="table">
	/// <listheader>
	/// <term>Return code</term>
	/// <term>Description</term>
	/// </listheader>
	/// <item>
	/// <term>ERROR_UNSUPPORTED_TYPE</term>
	/// <term>The algorithm object identifier (OID) of the private key is not supported.</term>
	/// </item>
	/// </list>
	/// <para>
	/// If the function fails, GetLastError may return an Abstract Syntax Notation One (ASN.1) encoding/decoding error. For information
	/// about these errors, see ASN.1 Encoding/Decoding Return Values.
	/// </para>
	/// </returns>
	/// <remarks>
	/// <para>
	/// <c>CryptImportPKCS8</c> calls the PCRYPT_RESOLVE_HCRYPTPROV_FUNC function by using the CRYPT_PKCS8_IMPORT_PARAMS structure
	/// contained in the sPrivateKeyAndParams parameter to retrieve a handle of the provider to which to import the key. If
	/// <c>PCRYPT_RESOLVE_HCRYPTPROV_FUNC</c> is <c>NULL</c>, then the default provider is used.
	/// </para>
	/// <para>This function is only supported for asymmetric keys.</para>
	/// </remarks>
	// https://docs.microsoft.com/en-us/windows/win32/api/wincrypt/nf-wincrypt-cryptimportpkcs8 BOOL CryptImportPKCS8(
	// CRYPT_PKCS8_IMPORT_PARAMS sPrivateKeyAndParams, DWORD dwFlags, HCRYPTPROV *phCryptProv, void *pvAuxInfo );
	[DllImport(Lib.Crypt32, SetLastError = true, ExactSpelling = true)]
	[PInvokeData("wincrypt.h", MSDNShortId = "fa3deff9-b4c1-4b63-a59f-738f87e1a409")]
	[return: MarshalAs(UnmanagedType.Bool)]
	public static extern bool CryptImportPKCS8(CRYPT_PKCS8_IMPORT_PARAMS sPrivateKeyAndParams, uint dwFlags, out IntPtr phCryptProv, IntPtr pvAuxInfo = default);

	/// <summary>
	/// <para>
	/// The handle of the cryptographic service provider (CSP) to use when importing the public key. This handle must have already been
	/// created using CryptAcquireContext.
	/// </para>
	/// <para>
	/// Specifies the encoding type used. It is always acceptable to specify both the certificate and message encoding types by
	/// combining them with a bitwise- <c>OR</c> operation as shown in the following example:
	/// </para>
	/// <para>X509_ASN_ENCODING | PKCS_7_ASN_ENCODING</para>
	/// <para>Currently defined encoding types are:</para>
	/// <list type="bullet">
	/// <item>
	/// <term>X509_ASN_ENCODING</term>
	/// </item>
	/// <item>
	/// <term>PKCS_7_ASN_ENCODING</term>
	/// </item>
	/// </list>
	/// <para>The address of a CERT_PUBLIC_KEY_INFO structure that contains the public key to import into the provider.</para>
	/// <para>
	/// The address of an <c>HCRYPTKEY</c> variable that receives the handle of the imported public key. When you have finished using
	/// the public key, release the handle by calling the CryptDestroyKey function.
	/// </para>
	/// </summary>
	/// <param name="hCryptProv">
	/// The handle of the cryptographic service provider (CSP) to use when importing the public key. This handle must have already been
	/// created using CryptAcquireContext.
	/// </param>
	/// <param name="dwCertEncodingType">
	/// <para>
	/// Specifies the encoding type used. It is always acceptable to specify both the certificate and message encoding types by
	/// combining them with a bitwise- <c>OR</c> operation as shown in the following example:
	/// </para>
	/// <para>X509_ASN_ENCODING | PKCS_7_ASN_ENCODING</para>
	/// <para>Currently defined encoding types are:</para>
	/// <list type="bullet">
	/// <item>
	/// <term>X509_ASN_ENCODING</term>
	/// </item>
	/// <item>
	/// <term>PKCS_7_ASN_ENCODING</term>
	/// </item>
	/// </list>
	/// </param>
	/// <param name="pInfo">The address of a CERT_PUBLIC_KEY_INFO structure that contains the public key to import into the provider.</param>
	/// <param name="phKey">
	/// The address of an <c>HCRYPTKEY</c> variable that receives the handle of the imported public key. When you have finished using
	/// the public key, release the handle by calling the CryptDestroyKey function.
	/// </param>
	/// <returns>
	/// <para>If the function succeeds, the return value is nonzero ( <c>TRUE</c>).</para>
	/// <para>If the function fails, the return value is zero ( <c>FALSE</c>). For extended error information, call GetLastError.</para>
	/// <para>
	/// <c>Note</c> Errors from the called functions CryptGetUserKey and CryptExportKey might be propagated to this function. This
	/// function has the following error code.
	/// </para>
	/// <list type="table">
	/// <listheader>
	/// <term>Return code</term>
	/// <term>Description</term>
	/// </listheader>
	/// <item>
	/// <term>ERROR_FILE_NOT_FOUND</term>
	/// <term>
	/// An import function that can be installed or registered could not be found for the specified dwCertEncodingType and
	/// pInfo-&gt;Algorithm.pszObjId parameters.
	/// </term>
	/// </item>
	/// </list>
	/// <para>
	/// If the function fails, GetLastError may return an Abstract Syntax Notation One (ASN.1) encoding/decoding error. For information
	/// about these errors, see ASN.1 Encoding/Decoding Return Values.
	/// </para>
	/// </returns>
	/// <remarks>
	/// This function is normally used to retrieve the public key from a certificate. This is done by passing the CERT_PUBLIC_KEY_INFO
	/// structure from a filled-in certificate structure as shown in the following pseudocode.
	/// </remarks>
	// https://docs.microsoft.com/en-us/windows/win32/api/wincrypt/nf-wincrypt-cryptimportpublickeyinfo BOOL CryptImportPublicKeyInfo(
	// HCRYPTPROV hCryptProv, DWORD dwCertEncodingType, PCERT_PUBLIC_KEY_INFO pInfo, HCRYPTKEY *phKey );
	[DllImport(Lib.Crypt32, SetLastError = true, ExactSpelling = true)]
	[PInvokeData("wincrypt.h", MSDNShortId = "f5f8ebb6-c838-404b-9b61-3ec36fdaef01")]
	[return: MarshalAs(UnmanagedType.Bool)]
	public static extern bool CryptImportPublicKeyInfo(HCRYPTPROV hCryptProv, CertEncodingType dwCertEncodingType, in CERT_PUBLIC_KEY_INFO pInfo, out SafeHCRYPTKEY phKey);

	/// <summary>
	/// <para>The handle of the CSP to receive the imported public key. This handle must have already been created using CryptAcquireContext.</para>
	/// <para>
	/// Specifies the encoding type used. It is always acceptable to specify both the certificate and message encoding types by
	/// combining them with a bitwise- <c>OR</c> operation as shown in the following example:
	/// </para>
	/// <para>X509_ASN_ENCODING | PKCS_7_ASN_ENCODING</para>
	/// <para>Currently defined encoding types are:</para>
	/// <list type="bullet">
	/// <item>
	/// <term>X509_ASN_ENCODING</term>
	/// </item>
	/// <item>
	/// <term>PKCS_7_ASN_ENCODING</term>
	/// </item>
	/// </list>
	/// <para>the address of a CERT_PUBLIC_KEY_INFO structure that contains the public key to import into the provider.</para>
	/// <para>
	/// <c>Note</c> The <c>pzObjId</c> member of the <c>Algorithm</c> member pointed to by the pInfo and dwCertEncodingType parameters
	/// determine an installable <c>CRYPT_OID_IMPORT_PUBLIC_KEY_INFO_FUNC</c> callback function. If an installable function is not
	/// found, an attempt is made to import the key as an RSA Public Key (szOID_RSA_RSA).
	/// </para>
	/// <para>An ALG_ID structure that contains a CSP-specific algorithm to override the CALG_RSA_KEYX default algorithm.</para>
	/// <para>Reserved for future use and must be zero.</para>
	/// <para>Reserved for future use and must be <c>NULL</c>.</para>
	/// <para>
	/// The address of an <c>HCRYPTKEY</c> variable that receives the handle of the imported public key. When you have finished using
	/// the public key, release the handle by calling the CryptDestroyKey function.
	/// </para>
	/// </summary>
	/// <param name="hCryptProv">
	/// The handle of the CSP to receive the imported public key. This handle must have already been created using CryptAcquireContext.
	/// </param>
	/// <param name="dwCertEncodingType">
	/// <para>
	/// Specifies the encoding type used. It is always acceptable to specify both the certificate and message encoding types by
	/// combining them with a bitwise- <c>OR</c> operation as shown in the following example:
	/// </para>
	/// <para>X509_ASN_ENCODING | PKCS_7_ASN_ENCODING</para>
	/// <para>Currently defined encoding types are:</para>
	/// <list type="bullet">
	/// <item>
	/// <term>X509_ASN_ENCODING</term>
	/// </item>
	/// <item>
	/// <term>PKCS_7_ASN_ENCODING</term>
	/// </item>
	/// </list>
	/// </param>
	/// <param name="pInfo">
	/// <para>the address of a CERT_PUBLIC_KEY_INFO structure that contains the public key to import into the provider.</para>
	/// <para>
	/// <c>Note</c> The <c>pzObjId</c> member of the <c>Algorithm</c> member pointed to by the pInfo and dwCertEncodingType parameters
	/// determine an installable <c>CRYPT_OID_IMPORT_PUBLIC_KEY_INFO_FUNC</c> callback function. If an installable function is not
	/// found, an attempt is made to import the key as an RSA Public Key (szOID_RSA_RSA).
	/// </para>
	/// </param>
	/// <param name="aiKeyAlg">An ALG_ID structure that contains a CSP-specific algorithm to override the CALG_RSA_KEYX default algorithm.</param>
	/// <param name="dwFlags">Reserved for future use and must be zero.</param>
	/// <param name="pvAuxInfo">Reserved for future use and must be <c>NULL</c>.</param>
	/// <param name="phKey">
	/// The address of an <c>HCRYPTKEY</c> variable that receives the handle of the imported public key. When you have finished using
	/// the public key, release the handle by calling the CryptDestroyKey function.
	/// </param>
	/// <returns>
	/// <para>If the function succeeds, the function returns nonzero ( <c>TRUE</c>).</para>
	/// <para>If the function fails, it returns zero ( <c>FALSE</c>). For extended error information, call GetLastError.</para>
	/// <para>
	/// <c>Note</c> Errors from the called functions CryptGetUserKey and CryptExportKey might be propagated to this function. This
	/// function has the following error code.
	/// </para>
	/// <list type="table">
	/// <listheader>
	/// <term>Value</term>
	/// <term>Description</term>
	/// </listheader>
	/// <item>
	/// <term>ERROR_FILE_NOT_FOUND</term>
	/// <term>
	/// An import function that can be installed or registered could not be found for the specified dwCertEncodingType and pInfo parameters.
	/// </term>
	/// </item>
	/// </list>
	/// <para>
	/// If the function fails, GetLastError may return an Abstract Syntax Notation One (ASN.1) encoding/decoding error. For information
	/// about these errors, see ASN.1 Encoding/Decoding Return Values.
	/// </para>
	/// </returns>
	/// <remarks>
	/// This function is normally used to retrieve the public key from a certificate. This is done by passing the CERT_PUBLIC_KEY_INFO
	/// structure from a filled-in certificate structure as shown in the following pseudocode.
	/// </remarks>
	// https://docs.microsoft.com/en-us/windows/win32/api/wincrypt/nf-wincrypt-cryptimportpublickeyinfoex BOOL
	// CryptImportPublicKeyInfoEx( HCRYPTPROV hCryptProv, DWORD dwCertEncodingType, PCERT_PUBLIC_KEY_INFO pInfo, ALG_ID aiKeyAlg, DWORD
	// dwFlags, void *pvAuxInfo, HCRYPTKEY *phKey );
	[DllImport(Lib.Crypt32, SetLastError = true, ExactSpelling = true)]
	[PInvokeData("wincrypt.h", MSDNShortId = "d3a59f83-c761-46bb-ac4f-f42f689ea5f1")]
	[return: MarshalAs(UnmanagedType.Bool)]
	public static extern bool CryptImportPublicKeyInfoEx(HCRYPTPROV hCryptProv, uint dwCertEncodingType, in CERT_PUBLIC_KEY_INFO pInfo, ALG_ID aiKeyAlg,
		[Optional] uint dwFlags, [Optional] IntPtr pvAuxInfo, out SafeHCRYPTKEY phKey);

	/// <summary>
	/// The <c>CryptImportPublicKeyInfoEx2</c> function imports a public key into the CNG asymmetric provider that corresponds to the
	/// public key object identifier (OID) and returns a CNG handle to the key.
	/// </summary>
	/// <param name="dwCertEncodingType">
	/// <para>
	/// The certificate encoding type that was used to encrypt the subject. The message encoding type identifier, contained in the high
	/// <c>WORD</c> of this value, is ignored by this function.
	/// </para>
	/// <para>This parameter can be the following currently defined certificate encoding type.</para>
	/// <list type="table">
	/// <listheader>
	/// <term>Value</term>
	/// <term>Meaning</term>
	/// </listheader>
	/// <item>
	/// <term>X509_ASN_ENCODING 1 (0x1)</term>
	/// <term>Specifies X.509 certificate encoding.</term>
	/// </item>
	/// </list>
	/// </param>
	/// <param name="pInfo">
	/// The address of a CERT_PUBLIC_KEY_INFO structure that contains the public key information to import into the provider.
	/// </param>
	/// <param name="dwFlags">
	/// <para>
	/// A set of flags that modify the behavior of this function. This can be zero or a combination of one or more of the following values.
	/// </para>
	/// <list type="table">
	/// <listheader>
	/// <term>Value</term>
	/// <term>Meaning</term>
	/// </listheader>
	/// <item>
	/// <term>CRYPT_OID_INFO_PUBKEY_SIGN_KEY_FLAG</term>
	/// <term>
	/// Skips public keys in the CRYPT_PUBKEY_ALG_OID_GROUP_ID group that are explicitly flagged with the
	/// CRYPT_OID_PUBKEY_ENCRYPT_ONLY_FLAG flag.
	/// </term>
	/// </item>
	/// <item>
	/// <term>CRYPT_OID_INFO_PUBKEY_ENCRYPT_KEY_FLAG</term>
	/// <term>
	/// Skips public keys in the CRYPT_PUBKEY_ALG_OID_GROUP_ID group that are explicitly flagged with the
	/// CRYPT_OID_PUBKEY_SIGN_ONLY_FLAG flag.
	/// </term>
	/// </item>
	/// </list>
	/// <para>
	/// These flags are passed in the dwKeyType parameter of the CryptFindOIDInfo function when mapping the public key object identifier
	/// to the corresponding CNG public key algorithm identifier.
	/// </para>
	/// </param>
	/// <param name="pvAuxInfo">This parameter is reserved for future use and must be set to <c>NULL</c>.</param>
	/// <param name="phKey">
	/// <para>The address of a <c>BCRYPT_KEY_HANDLE</c> variable that receives the handle of the imported key.</para>
	/// <para>When this handle is no longer needed, you must release it by calling the BCryptDestroyKey function.</para>
	/// </param>
	/// <returns>
	/// <para>If the function succeeds, the function returns nonzero ( <c>TRUE</c>).</para>
	/// <para>
	/// If the function fails, it returns zero ( <c>FALSE</c>). For extended error information, call GetLastError. Possible error codes
	/// include, but are not limited to, the following.
	/// </para>
	/// <list type="table">
	/// <listheader>
	/// <term>Return code</term>
	/// <term>Description</term>
	/// </listheader>
	/// <item>
	/// <term>ERROR_FILE_NOT_FOUND</term>
	/// <term>
	/// An import function that can be installed or registered could not be found for the specified dwCertEncodingType and pInfo parameters.
	/// </term>
	/// </item>
	/// <item>
	/// <term>E_INVALIDARG</term>
	/// <term>One or more parameters are not valid.</term>
	/// </item>
	/// </list>
	/// </returns>
	// https://docs.microsoft.com/en-us/windows/win32/api/wincrypt/nf-wincrypt-cryptimportpublickeyinfoex2 BOOL
	// CryptImportPublicKeyInfoEx2( DWORD dwCertEncodingType, PCERT_PUBLIC_KEY_INFO pInfo, DWORD dwFlags, void *pvAuxInfo,
	// BCRYPT_KEY_HANDLE *phKey );
	[DllImport(Lib.Crypt32, SetLastError = true, ExactSpelling = true)]
	[PInvokeData("wincrypt.h", MSDNShortId = "c73f2499-75e9-4146-ae4c-0e949206ea37")]
	[return: MarshalAs(UnmanagedType.Bool)]
	public static extern bool CryptImportPublicKeyInfoEx2(CertEncodingType dwCertEncodingType, in CERT_PUBLIC_KEY_INFO pInfo, CryptOIDInfoFlags dwFlags,
		[Optional] IntPtr pvAuxInfo, out BCrypt.SafeBCRYPT_KEY_HANDLE phKey);

	/// <summary>
	/// The <c>CryptMemAlloc</c> function allocates memory for a buffer. It is used by all Crypt32.lib functions that return allocated buffers.
	/// </summary>
	/// <param name="cbSize">Number of bytes to be allocated.</param>
	/// <returns>
	/// Returns a pointer to the buffer allocated. If the function fails, <c>NULL</c> is returned. When you have finished using the
	/// buffer, free the memory by calling the CryptMemFree function.
	/// </returns>
	// https://docs.microsoft.com/en-us/windows/win32/api/wincrypt/nf-wincrypt-cryptmemalloc LPVOID CryptMemAlloc( ULONG cbSize );
	[DllImport(Lib.Crypt32, SetLastError = false, ExactSpelling = true)]
	[PInvokeData("wincrypt.h", MSDNShortId = "ac7588b1-ff8c-4f8d-a8ab-f0e8a18e5614")]
	public static extern IntPtr CryptMemAlloc(uint cbSize);

	/// <summary>The <c>CryptMemFree</c> function frees memory allocated by CryptMemAlloc or CryptMemRealloc.</summary>
	/// <param name="pv">A pointer to the buffer to be freed.</param>
	/// <returns>This function does not return a value.</returns>
	// https://docs.microsoft.com/en-us/windows/win32/api/wincrypt/nf-wincrypt-cryptmemfree void CryptMemFree( LPVOID pv );
	[DllImport(Lib.Crypt32, SetLastError = false, ExactSpelling = true)]
	[PInvokeData("wincrypt.h", MSDNShortId = "fb5c10ba-da8e-4a34-9302-67586a0a9624")]
	public static extern void CryptMemFree(IntPtr pv);

	/// <summary>
	/// The <c>CryptMemRealloc</c> function frees the memory currently allocated for a buffer and allocates memory for a new buffer.
	/// </summary>
	/// <param name="pv">A pointer to a currently allocated buffer.</param>
	/// <param name="cbSize">Number of bytes to be allocated.</param>
	/// <returns>
	/// Returns a pointer to the buffer allocated. If the function fails, <c>NULL</c> is returned. When you have finished using the
	/// buffer, free the memory by calling the CryptMemFree function.
	/// </returns>
	// https://docs.microsoft.com/en-us/windows/win32/api/wincrypt/nf-wincrypt-cryptmemrealloc LPVOID CryptMemRealloc( LPVOID pv, ULONG
	// cbSize );
	[DllImport(Lib.Crypt32, SetLastError = false, ExactSpelling = true)]
	[PInvokeData("wincrypt.h", MSDNShortId = "74bdd2dd-9f05-4d36-8323-79d547820068")]
	public static extern IntPtr CryptMemRealloc(IntPtr pv, uint cbSize);

	/// <summary>
	/// <para>Indicates the type of the object to be queried. This must be one of the following values.</para>
	/// <list type="table">
	/// <listheader>
	/// <term>Value</term>
	/// <term>Meaning</term>
	/// </listheader>
	/// <item>
	/// <term>CERT_QUERY_OBJECT_BLOB</term>
	/// <term>The object is stored in a structure in memory.</term>
	/// </item>
	/// <item>
	/// <term>CERT_QUERY_OBJECT_FILE</term>
	/// <term>The object is stored in a file.</term>
	/// </item>
	/// </list>
	/// <para>A pointer to the object to be queried. The type of data pointer depends on the contents of the dwObjectType parameter.</para>
	/// <list type="table">
	/// <listheader>
	/// <term>dwObjectType value</term>
	/// <term>Meaning</term>
	/// </listheader>
	/// <item>
	/// <term>CERT_QUERY_OBJECT_BLOB</term>
	/// <term>This parameter is a pointer to a CERT_BLOB, or similar, structure that contains the object to query.</term>
	/// </item>
	/// <item>
	/// <term>CERT_QUERY_OBJECT_FILE</term>
	/// <term>This parameter is a pointer to a null-terminated Unicode string that contains the path and name of the file to query.</term>
	/// </item>
	/// </list>
	/// <para>Indicates the expected content type. This can be one of the following values.</para>
	/// <list type="table">
	/// <listheader>
	/// <term>Value</term>
	/// <term>Meaning</term>
	/// </listheader>
	/// <item>
	/// <term>CERT_QUERY_CONTENT_FLAG_ALL</term>
	/// <term>
	/// The content can be any type. This does not include the CERT_QUERY_CONTENT_FLAG_PFX_AND_LOAD flag. If this flag is specified,
	/// this function will attempt to obtain information about the object, trying different content types until the proper content type
	/// is found or the content types are exhausted. This is obviously inefficient, so this flag should only be used if the content type
	/// is not known.
	/// </term>
	/// </item>
	/// <item>
	/// <term>CERT_QUERY_CONTENT_FLAG_CERT</term>
	/// <term>The content is a single certificate.</term>
	/// </item>
	/// <item>
	/// <term>CERT_QUERY_CONTENT_FLAG_CERT_PAIR</term>
	/// <term>
	/// The content is an Abstract Syntax Notation One (ASN.1) encoded X509_CERT_PAIR (an encoded certificate pair that contains either
	/// forward, reverse, or forward and reverse cross certificates).
	/// </term>
	/// </item>
	/// <item>
	/// <term>CERT_QUERY_CONTENT_FLAG_CRL</term>
	/// <term>The content is a single CRL.</term>
	/// </item>
	/// <item>
	/// <term>CERT_QUERY_CONTENT_FLAG_CTL</term>
	/// <term>The content is a single CTL.</term>
	/// </item>
	/// <item>
	/// <term>CERT_QUERY_CONTENT_FLAG_PFX</term>
	/// <term>
	/// The content is a PFX (PKCS #12) packet, but it will not be loaded by this function. You can use the PFXImportCertStore function
	/// to load this into a store.
	/// </term>
	/// </item>
	/// <item>
	/// <term>CERT_QUERY_CONTENT_FLAG_PFX_AND_LOAD</term>
	/// <term>
	/// The content is a PFX (PKCS #12) packet and will be loaded by this function subject to the conditions specified in the following
	/// note. Windows Server 2003 and Windows XP: This value is not supported.
	/// </term>
	/// </item>
	/// <item>
	/// <term>CERT_QUERY_CONTENT_FLAG_PKCS7_SIGNED</term>
	/// <term>The content is a PKCS #7 signed message.</term>
	/// </item>
	/// <item>
	/// <term>CERT_QUERY_CONTENT_FLAG_PKCS7_SIGNED_EMBED</term>
	/// <term>The content is an embedded PKCS #7 signed message.</term>
	/// </item>
	/// <item>
	/// <term>CERT_QUERY_CONTENT_FLAG_PKCS7_UNSIGNED</term>
	/// <term>The content is a PKCS #7 unsigned message.</term>
	/// </item>
	/// <item>
	/// <term>CERT_QUERY_CONTENT_FLAG_PKCS10</term>
	/// <term>The content is a PKCS #10 message.</term>
	/// </item>
	/// <item>
	/// <term>CERT_QUERY_CONTENT_FLAG_SERIALIZED_CERT</term>
	/// <term>The content is a serialized single certificate.</term>
	/// </item>
	/// <item>
	/// <term>CERT_QUERY_CONTENT_FLAG_SERIALIZED_CRL</term>
	/// <term>The content is a serialized single CRL.</term>
	/// </item>
	/// <item>
	/// <term>CERT_QUERY_CONTENT_FLAG_SERIALIZED_CTL</term>
	/// <term>The content is serialized single CTL.</term>
	/// </item>
	/// <item>
	/// <term>CERT_QUERY_CONTENT_FLAG_SERIALIZED_STORE</term>
	/// <term>The content is a serialized store.</term>
	/// </item>
	/// </list>
	/// <para>Indicates the expected format of the returned type. This can be one of the following values.</para>
	/// <list type="table">
	/// <listheader>
	/// <term>Value</term>
	/// <term>Meaning</term>
	/// </listheader>
	/// <item>
	/// <term>CERT_QUERY_FORMAT_FLAG_ALL</term>
	/// <term>The content can be returned in any format.</term>
	/// </item>
	/// <item>
	/// <term>CERT_QUERY_FORMAT_FLAG_ASN_ASCII_HEX_ENCODED</term>
	/// <term>The content should be returned in ASCII hex-encoded format with a "{ASN}" prefix.</term>
	/// </item>
	/// <item>
	/// <term>CERT_QUERY_FORMAT_FLAG_BASE64_ENCODED</term>
	/// <term>The content should be returned in Base64 encoded format.</term>
	/// </item>
	/// <item>
	/// <term>CERT_QUERY_FORMAT_FLAG_BINARY</term>
	/// <term>The content should be returned in binary format.</term>
	/// </item>
	/// </list>
	/// <para>This parameter is reserved for future use and must be set to zero.</para>
	/// <para>
	/// A pointer to a <c>DWORD</c> value that receives the type of encoding used in the message. If this information is not needed, set
	/// this parameter to <c>NULL</c>.
	/// </para>
	/// <para>This parameter can receives a combination of one or more of the following values.</para>
	/// <list type="table">
	/// <listheader>
	/// <term>Value</term>
	/// <term>Meaning</term>
	/// </listheader>
	/// <item>
	/// <term>PKCS_7_ASN_ENCODING 65536 (0x10000)</term>
	/// <term>Specifies PKCS 7 message encoding.</term>
	/// </item>
	/// <item>
	/// <term>X509_ASN_ENCODING 1 (0x1)</term>
	/// <term>Specifies X.509 certificate encoding.</term>
	/// </item>
	/// </list>
	/// <para>
	/// A pointer to a <c>DWORD</c> value that receives the actual type of the content. If this information is not needed, set this
	/// parameter to <c>NULL</c>. The returned content type can be one of the following values.
	/// </para>
	/// <list type="table">
	/// <listheader>
	/// <term>Value</term>
	/// <term>Meaning</term>
	/// </listheader>
	/// <item>
	/// <term>CERT_QUERY_CONTENT_CERT</term>
	/// <term>The content is a single certificate.</term>
	/// </item>
	/// <item>
	/// <term>CERT_QUERY_CONTENT_CERT_PAIR</term>
	/// <term>The content is an ASN.1 encoded X509_CERT_pair.</term>
	/// </item>
	/// <item>
	/// <term>CERT_QUERY_CONTENT_CRL</term>
	/// <term>The content is a single CRL.</term>
	/// </item>
	/// <item>
	/// <term>CERT_QUERY_CONTENT_CTL</term>
	/// <term>The content is a single CTL.</term>
	/// </item>
	/// <item>
	/// <term>CERT_QUERY_CONTENT_PFX</term>
	/// <term>
	/// The content is a PFX (PKCS #12) packet. This function only verifies that the object is a PKCS #12 packet. The PKCS #12 packet is
	/// not loaded into a certificate store.
	/// </term>
	/// </item>
	/// <item>
	/// <term>CERT_QUERY_CONTENT_PFX_AND_LOAD</term>
	/// <term>
	/// The content is a PFX (PKCS #12) packet, and it has been loaded into a certificate store. Windows Server 2003 and Windows XP:
	/// This value is not supported.
	/// </term>
	/// </item>
	/// <item>
	/// <term>CERT_QUERY_CONTENT_PKCS7_SIGNED</term>
	/// <term>The content is a PKCS #7 signed message.</term>
	/// </item>
	/// <item>
	/// <term>CERT_QUERY_CONTENT_PKCS7_SIGNED_EMBED</term>
	/// <term>The content is an embedded PKCS #7 signed message.</term>
	/// </item>
	/// <item>
	/// <term>CERT_QUERY_CONTENT_PKCS7_UNSIGNED</term>
	/// <term>The content is a PKCS #7 unsigned message.</term>
	/// </item>
	/// <item>
	/// <term>CERT_QUERY_CONTENT_PKCS10</term>
	/// <term>The content is a PKCS #10 message.</term>
	/// </item>
	/// <item>
	/// <term>CERT_QUERY_CONTENT_SERIALIZED_CERT</term>
	/// <term>The content is a serialized single certificate.</term>
	/// </item>
	/// <item>
	/// <term>CERT_QUERY_CONTENT_SERIALIZED_CRL</term>
	/// <term>The content is a serialized single CRL.</term>
	/// </item>
	/// <item>
	/// <term>CERT_QUERY_CONTENT_SERIALIZED_CTL</term>
	/// <term>The content is a serialized single CTL.</term>
	/// </item>
	/// <item>
	/// <term>CERT_QUERY_CONTENT_SERIALIZED_STORE</term>
	/// <term>The content is a serialized store.</term>
	/// </item>
	/// </list>
	/// <para>
	/// A pointer to a <c>DWORD</c> value that receives the actual format type of the content. If this information is not needed, set
	/// this parameter to <c>NULL</c>. The returned format type can be one of the following values.
	/// </para>
	/// <list type="table">
	/// <listheader>
	/// <term>Value</term>
	/// <term>Meaning</term>
	/// </listheader>
	/// <item>
	/// <term>CERT_QUERY_FORMAT_ASN_ASCII_HEX_ENCODED</term>
	/// <term>The content is in ASCII hex-encoded format with an "{ASN}" prefix.</term>
	/// </item>
	/// <item>
	/// <term>CERT_QUERY_FORMAT_BASE64_ENCODED</term>
	/// <term>The content is in Base64 encoded format.</term>
	/// </item>
	/// <item>
	/// <term>CERT_QUERY_FORMAT_BINARY</term>
	/// <term>The content is in binary format.</term>
	/// </item>
	/// </list>
	/// <para>
	/// A pointer to an <c>HCERTSTORE</c> value that receives a handle to a certificate store that includes all of the certificates,
	/// CRLs, and CTLs in the object.
	/// </para>
	/// <para>
	/// This parameter only receives a certificate store handle when the dwContentType parameter receives one of the following values.
	/// This parameter receives <c>NULL</c> for all other content types.
	/// </para>
	/// <para>CERT_QUERY_CONTENT_CERT</para>
	/// <para>CERT_QUERY_CONTENT_CRL</para>
	/// <para>CERT_QUERY_CONTENT_CTL</para>
	/// <para>CERT_QUERY_CONTENT_PFX_AND_LOAD</para>
	/// <para>CERT_QUERY_CONTENT_PKCS7_SIGNED</para>
	/// <para>CERT_QUERY_CONTENT_PKCS7_SIGNED_EMBED</para>
	/// <para>CERT_QUERY_CONTENT_SERIALIZED_CERT</para>
	/// <para>CERT_QUERY_CONTENT_SERIALIZED_CRL</para>
	/// <para>CERT_QUERY_CONTENT_SERIALIZED_CTL</para>
	/// <para>CERT_QUERY_CONTENT_SERIALIZED_STORE</para>
	/// <para>When you have finished using the handle, free it by passing the handle to the CertCloseStore function.</para>
	/// <para>If this information is not needed, set this parameter to <c>NULL</c>.</para>
	/// <para>A pointer to an <c>HCRYPTMSG</c> value that receives the handle of an opened message.</para>
	/// <para>
	/// This parameter only receives a message handle when the dwContentType parameter receives one of the following values. This
	/// parameter receives <c>NULL</c> for all other content types.
	/// </para>
	/// <para>CERT_QUERY_CONTENT_PKCS7_SIGNED</para>
	/// <para>CERT_QUERY_CONTENT_PKCS7_SIGNED_EMBED</para>
	/// <para>CERT_QUERY_CONTENT_PKCS7_UNSIGNED</para>
	/// <para>When you have finished using the handle, free it by passing the handle to the CryptMsgClose function.</para>
	/// <para>If this information is not needed, set this parameter to <c>NULL</c>.</para>
	/// <para>A pointer to a pointer that receives additional information about the object.</para>
	/// <para>
	/// The format of this data depends on the value received by the dwContentType parameter. The following table lists the format of
	/// the data for the specified dwContentType value.
	/// </para>
	/// <list type="table">
	/// <listheader>
	/// <term>dwContentType value</term>
	/// <term>Meaning</term>
	/// </listheader>
	/// <item>
	/// <term>CERT_QUERY_CONTENT_CERT</term>
	/// <term>
	/// This parameter receives a pointer to a CERT_CONTEXT structure. When you have finished using the structure, free it by passing
	/// this pointer to the CertFreeCertificateContext function.
	/// </term>
	/// </item>
	/// <item>
	/// <term>CERT_QUERY_CONTENT_CRL</term>
	/// <term>
	/// This parameter receives a pointer to a CRL_CONTEXT structure. When you have finished using the structure, free it by passing
	/// this pointer to the CertFreeCRLContext function.
	/// </term>
	/// </item>
	/// <item>
	/// <term>CERT_QUERY_CONTENT_CTL</term>
	/// <term>
	/// This parameter receives a pointer to a CTL_CONTEXT structure. When you have finished using the structure, free it by passing
	/// this pointer to the CertFreeCTLContext function.
	/// </term>
	/// </item>
	/// <item>
	/// <term>CERT_QUERY_CONTENT_SERIALIZED_CERT</term>
	/// <term>
	/// This parameter receives a pointer to a CERT_CONTEXT structure. When you have finished using the structure, free it by passing
	/// this pointer to the CertFreeCertificateContext function.
	/// </term>
	/// </item>
	/// <item>
	/// <term>CERT_QUERY_CONTENT_SERIALIZED_CRL</term>
	/// <term>
	/// This parameter receives a pointer to a CRL_CONTEXT structure. When you have finished using the structure, free it by passing
	/// this pointer to the CertFreeCRLContext function.
	/// </term>
	/// </item>
	/// <item>
	/// <term>CERT_QUERY_CONTENT_SERIALIZED_CTL</term>
	/// <term>
	/// This parameter receives a pointer to a CTL_CONTEXT structure. When you have finished using the structure, free it by passing
	/// this pointer to the CertFreeCTLContext function.
	/// </term>
	/// </item>
	/// </list>
	/// <para>If this information is not needed, set this parameter to <c>NULL</c>.</para>
	/// </summary>
	/// <param name="dwObjectType">
	/// <para>Indicates the type of the object to be queried. This must be one of the following values.</para>
	/// <list type="table">
	/// <listheader>
	/// <term>Value</term>
	/// <term>Meaning</term>
	/// </listheader>
	/// <item>
	/// <term>CERT_QUERY_OBJECT_BLOB</term>
	/// <term>The object is stored in a structure in memory.</term>
	/// </item>
	/// <item>
	/// <term>CERT_QUERY_OBJECT_FILE</term>
	/// <term>The object is stored in a file.</term>
	/// </item>
	/// </list>
	/// </param>
	/// <param name="pvObject">
	/// <para>A pointer to the object to be queried. The type of data pointer depends on the contents of the dwObjectType parameter.</para>
	/// <list type="table">
	/// <listheader>
	/// <term>dwObjectType value</term>
	/// <term>Meaning</term>
	/// </listheader>
	/// <item>
	/// <term>CERT_QUERY_OBJECT_BLOB</term>
	/// <term>This parameter is a pointer to a CERT_BLOB, or similar, structure that contains the object to query.</term>
	/// </item>
	/// <item>
	/// <term>CERT_QUERY_OBJECT_FILE</term>
	/// <term>This parameter is a pointer to a null-terminated Unicode string that contains the path and name of the file to query.</term>
	/// </item>
	/// </list>
	/// </param>
	/// <param name="dwExpectedContentTypeFlags">
	/// <para>Indicates the expected content type. This can be one of the following values.</para>
	/// <list type="table">
	/// <listheader>
	/// <term>Value</term>
	/// <term>Meaning</term>
	/// </listheader>
	/// <item>
	/// <term>CERT_QUERY_CONTENT_FLAG_ALL</term>
	/// <term>
	/// The content can be any type. This does not include the CERT_QUERY_CONTENT_FLAG_PFX_AND_LOAD flag. If this flag is specified,
	/// this function will attempt to obtain information about the object, trying different content types until the proper content type
	/// is found or the content types are exhausted. This is obviously inefficient, so this flag should only be used if the content type
	/// is not known.
	/// </term>
	/// </item>
	/// <item>
	/// <term>CERT_QUERY_CONTENT_FLAG_CERT</term>
	/// <term>The content is a single certificate.</term>
	/// </item>
	/// <item>
	/// <term>CERT_QUERY_CONTENT_FLAG_CERT_PAIR</term>
	/// <term>
	/// The content is an Abstract Syntax Notation One (ASN.1) encoded X509_CERT_PAIR (an encoded certificate pair that contains either
	/// forward, reverse, or forward and reverse cross certificates).
	/// </term>
	/// </item>
	/// <item>
	/// <term>CERT_QUERY_CONTENT_FLAG_CRL</term>
	/// <term>The content is a single CRL.</term>
	/// </item>
	/// <item>
	/// <term>CERT_QUERY_CONTENT_FLAG_CTL</term>
	/// <term>The content is a single CTL.</term>
	/// </item>
	/// <item>
	/// <term>CERT_QUERY_CONTENT_FLAG_PFX</term>
	/// <term>
	/// The content is a PFX (PKCS #12) packet, but it will not be loaded by this function. You can use the PFXImportCertStore function
	/// to load this into a store.
	/// </term>
	/// </item>
	/// <item>
	/// <term>CERT_QUERY_CONTENT_FLAG_PFX_AND_LOAD</term>
	/// <term>
	/// The content is a PFX (PKCS #12) packet and will be loaded by this function subject to the conditions specified in the following
	/// note. Windows Server 2003 and Windows XP: This value is not supported.
	/// </term>
	/// </item>
	/// <item>
	/// <term>CERT_QUERY_CONTENT_FLAG_PKCS7_SIGNED</term>
	/// <term>The content is a PKCS #7 signed message.</term>
	/// </item>
	/// <item>
	/// <term>CERT_QUERY_CONTENT_FLAG_PKCS7_SIGNED_EMBED</term>
	/// <term>The content is an embedded PKCS #7 signed message.</term>
	/// </item>
	/// <item>
	/// <term>CERT_QUERY_CONTENT_FLAG_PKCS7_UNSIGNED</term>
	/// <term>The content is a PKCS #7 unsigned message.</term>
	/// </item>
	/// <item>
	/// <term>CERT_QUERY_CONTENT_FLAG_PKCS10</term>
	/// <term>The content is a PKCS #10 message.</term>
	/// </item>
	/// <item>
	/// <term>CERT_QUERY_CONTENT_FLAG_SERIALIZED_CERT</term>
	/// <term>The content is a serialized single certificate.</term>
	/// </item>
	/// <item>
	/// <term>CERT_QUERY_CONTENT_FLAG_SERIALIZED_CRL</term>
	/// <term>The content is a serialized single CRL.</term>
	/// </item>
	/// <item>
	/// <term>CERT_QUERY_CONTENT_FLAG_SERIALIZED_CTL</term>
	/// <term>The content is serialized single CTL.</term>
	/// </item>
	/// <item>
	/// <term>CERT_QUERY_CONTENT_FLAG_SERIALIZED_STORE</term>
	/// <term>The content is a serialized store.</term>
	/// </item>
	/// </list>
	/// </param>
	/// <param name="dwExpectedFormatTypeFlags">
	/// <para>Indicates the expected format of the returned type. This can be one of the following values.</para>
	/// <list type="table">
	/// <listheader>
	/// <term>Value</term>
	/// <term>Meaning</term>
	/// </listheader>
	/// <item>
	/// <term>CERT_QUERY_FORMAT_FLAG_ALL</term>
	/// <term>The content can be returned in any format.</term>
	/// </item>
	/// <item>
	/// <term>CERT_QUERY_FORMAT_FLAG_ASN_ASCII_HEX_ENCODED</term>
	/// <term>The content should be returned in ASCII hex-encoded format with a "{ASN}" prefix.</term>
	/// </item>
	/// <item>
	/// <term>CERT_QUERY_FORMAT_FLAG_BASE64_ENCODED</term>
	/// <term>The content should be returned in Base64 encoded format.</term>
	/// </item>
	/// <item>
	/// <term>CERT_QUERY_FORMAT_FLAG_BINARY</term>
	/// <term>The content should be returned in binary format.</term>
	/// </item>
	/// </list>
	/// </param>
	/// <param name="dwFlags">This parameter is reserved for future use and must be set to zero.</param>
	/// <param name="pdwMsgAndCertEncodingType">
	/// <para>
	/// A pointer to a <c>DWORD</c> value that receives the type of encoding used in the message. If this information is not needed, set
	/// this parameter to <c>NULL</c>.
	/// </para>
	/// <para>This parameter can receives a combination of one or more of the following values.</para>
	/// <list type="table">
	/// <listheader>
	/// <term>Value</term>
	/// <term>Meaning</term>
	/// </listheader>
	/// <item>
	/// <term>PKCS_7_ASN_ENCODING 65536 (0x10000)</term>
	/// <term>Specifies PKCS 7 message encoding.</term>
	/// </item>
	/// <item>
	/// <term>X509_ASN_ENCODING 1 (0x1)</term>
	/// <term>Specifies X.509 certificate encoding.</term>
	/// </item>
	/// </list>
	/// </param>
	/// <param name="pdwContentType">
	/// <para>
	/// A pointer to a <c>DWORD</c> value that receives the actual type of the content. If this information is not needed, set this
	/// parameter to <c>NULL</c>. The returned content type can be one of the following values.
	/// </para>
	/// <list type="table">
	/// <listheader>
	/// <term>Value</term>
	/// <term>Meaning</term>
	/// </listheader>
	/// <item>
	/// <term>CERT_QUERY_CONTENT_CERT</term>
	/// <term>The content is a single certificate.</term>
	/// </item>
	/// <item>
	/// <term>CERT_QUERY_CONTENT_CERT_PAIR</term>
	/// <term>The content is an ASN.1 encoded X509_CERT_pair.</term>
	/// </item>
	/// <item>
	/// <term>CERT_QUERY_CONTENT_CRL</term>
	/// <term>The content is a single CRL.</term>
	/// </item>
	/// <item>
	/// <term>CERT_QUERY_CONTENT_CTL</term>
	/// <term>The content is a single CTL.</term>
	/// </item>
	/// <item>
	/// <term>CERT_QUERY_CONTENT_PFX</term>
	/// <term>
	/// The content is a PFX (PKCS #12) packet. This function only verifies that the object is a PKCS #12 packet. The PKCS #12 packet is
	/// not loaded into a certificate store.
	/// </term>
	/// </item>
	/// <item>
	/// <term>CERT_QUERY_CONTENT_PFX_AND_LOAD</term>
	/// <term>
	/// The content is a PFX (PKCS #12) packet, and it has been loaded into a certificate store. Windows Server 2003 and Windows XP:
	/// This value is not supported.
	/// </term>
	/// </item>
	/// <item>
	/// <term>CERT_QUERY_CONTENT_PKCS7_SIGNED</term>
	/// <term>The content is a PKCS #7 signed message.</term>
	/// </item>
	/// <item>
	/// <term>CERT_QUERY_CONTENT_PKCS7_SIGNED_EMBED</term>
	/// <term>The content is an embedded PKCS #7 signed message.</term>
	/// </item>
	/// <item>
	/// <term>CERT_QUERY_CONTENT_PKCS7_UNSIGNED</term>
	/// <term>The content is a PKCS #7 unsigned message.</term>
	/// </item>
	/// <item>
	/// <term>CERT_QUERY_CONTENT_PKCS10</term>
	/// <term>The content is a PKCS #10 message.</term>
	/// </item>
	/// <item>
	/// <term>CERT_QUERY_CONTENT_SERIALIZED_CERT</term>
	/// <term>The content is a serialized single certificate.</term>
	/// </item>
	/// <item>
	/// <term>CERT_QUERY_CONTENT_SERIALIZED_CRL</term>
	/// <term>The content is a serialized single CRL.</term>
	/// </item>
	/// <item>
	/// <term>CERT_QUERY_CONTENT_SERIALIZED_CTL</term>
	/// <term>The content is a serialized single CTL.</term>
	/// </item>
	/// <item>
	/// <term>CERT_QUERY_CONTENT_SERIALIZED_STORE</term>
	/// <term>The content is a serialized store.</term>
	/// </item>
	/// </list>
	/// </param>
	/// <param name="pdwFormatType">
	/// <para>
	/// A pointer to a <c>DWORD</c> value that receives the actual format type of the content. If this information is not needed, set
	/// this parameter to <c>NULL</c>. The returned format type can be one of the following values.
	/// </para>
	/// <list type="table">
	/// <listheader>
	/// <term>Value</term>
	/// <term>Meaning</term>
	/// </listheader>
	/// <item>
	/// <term>CERT_QUERY_FORMAT_ASN_ASCII_HEX_ENCODED</term>
	/// <term>The content is in ASCII hex-encoded format with an "{ASN}" prefix.</term>
	/// </item>
	/// <item>
	/// <term>CERT_QUERY_FORMAT_BASE64_ENCODED</term>
	/// <term>The content is in Base64 encoded format.</term>
	/// </item>
	/// <item>
	/// <term>CERT_QUERY_FORMAT_BINARY</term>
	/// <term>The content is in binary format.</term>
	/// </item>
	/// </list>
	/// </param>
	/// <param name="phCertStore">
	/// <para>
	/// A pointer to an <c>HCERTSTORE</c> value that receives a handle to a certificate store that includes all of the certificates,
	/// CRLs, and CTLs in the object.
	/// </para>
	/// <para>
	/// This parameter only receives a certificate store handle when the dwContentType parameter receives one of the following values.
	/// This parameter receives <c>NULL</c> for all other content types.
	/// </para>
	/// <para>CERT_QUERY_CONTENT_CERT</para>
	/// <para>CERT_QUERY_CONTENT_CRL</para>
	/// <para>CERT_QUERY_CONTENT_CTL</para>
	/// <para>CERT_QUERY_CONTENT_PFX_AND_LOAD</para>
	/// <para>CERT_QUERY_CONTENT_PKCS7_SIGNED</para>
	/// <para>CERT_QUERY_CONTENT_PKCS7_SIGNED_EMBED</para>
	/// <para>CERT_QUERY_CONTENT_SERIALIZED_CERT</para>
	/// <para>CERT_QUERY_CONTENT_SERIALIZED_CRL</para>
	/// <para>CERT_QUERY_CONTENT_SERIALIZED_CTL</para>
	/// <para>CERT_QUERY_CONTENT_SERIALIZED_STORE</para>
	/// <para>When you have finished using the handle, free it by passing the handle to the CertCloseStore function.</para>
	/// <para>If this information is not needed, set this parameter to <c>NULL</c>.</para>
	/// </param>
	/// <param name="phMsg">
	/// <para>A pointer to an <c>HCRYPTMSG</c> value that receives the handle of an opened message.</para>
	/// <para>
	/// This parameter only receives a message handle when the dwContentType parameter receives one of the following values. This
	/// parameter receives <c>NULL</c> for all other content types.
	/// </para>
	/// <para>CERT_QUERY_CONTENT_PKCS7_SIGNED</para>
	/// <para>CERT_QUERY_CONTENT_PKCS7_SIGNED_EMBED</para>
	/// <para>CERT_QUERY_CONTENT_PKCS7_UNSIGNED</para>
	/// <para>When you have finished using the handle, free it by passing the handle to the CryptMsgClose function.</para>
	/// <para>If this information is not needed, set this parameter to <c>NULL</c>.</para>
	/// </param>
	/// <param name="ppvContext">
	/// <para>A pointer to a pointer that receives additional information about the object.</para>
	/// <para>
	/// The format of this data depends on the value received by the dwContentType parameter. The following table lists the format of
	/// the data for the specified dwContentType value.
	/// </para>
	/// <list type="table">
	/// <listheader>
	/// <term>dwContentType value</term>
	/// <term>Meaning</term>
	/// </listheader>
	/// <item>
	/// <term>CERT_QUERY_CONTENT_CERT</term>
	/// <term>
	/// This parameter receives a pointer to a CERT_CONTEXT structure. When you have finished using the structure, free it by passing
	/// this pointer to the CertFreeCertificateContext function.
	/// </term>
	/// </item>
	/// <item>
	/// <term>CERT_QUERY_CONTENT_CRL</term>
	/// <term>
	/// This parameter receives a pointer to a CRL_CONTEXT structure. When you have finished using the structure, free it by passing
	/// this pointer to the CertFreeCRLContext function.
	/// </term>
	/// </item>
	/// <item>
	/// <term>CERT_QUERY_CONTENT_CTL</term>
	/// <term>
	/// This parameter receives a pointer to a CTL_CONTEXT structure. When you have finished using the structure, free it by passing
	/// this pointer to the CertFreeCTLContext function.
	/// </term>
	/// </item>
	/// <item>
	/// <term>CERT_QUERY_CONTENT_SERIALIZED_CERT</term>
	/// <term>
	/// This parameter receives a pointer to a CERT_CONTEXT structure. When you have finished using the structure, free it by passing
	/// this pointer to the CertFreeCertificateContext function.
	/// </term>
	/// </item>
	/// <item>
	/// <term>CERT_QUERY_CONTENT_SERIALIZED_CRL</term>
	/// <term>
	/// This parameter receives a pointer to a CRL_CONTEXT structure. When you have finished using the structure, free it by passing
	/// this pointer to the CertFreeCRLContext function.
	/// </term>
	/// </item>
	/// <item>
	/// <term>CERT_QUERY_CONTENT_SERIALIZED_CTL</term>
	/// <term>
	/// This parameter receives a pointer to a CTL_CONTEXT structure. When you have finished using the structure, free it by passing
	/// this pointer to the CertFreeCTLContext function.
	/// </term>
	/// </item>
	/// </list>
	/// <para>If this information is not needed, set this parameter to <c>NULL</c>.</para>
	/// </param>
	/// <returns>
	/// <para>If the function succeeds, the function returns nonzero.</para>
	/// <para>If the function fails, it returns zero. For extended error information, call GetLastError.</para>
	/// </returns>
	// https://docs.microsoft.com/en-us/windows/win32/api/wincrypt/nf-wincrypt-cryptqueryobject BOOL CryptQueryObject( DWORD
	// dwObjectType, const void *pvObject, DWORD dwExpectedContentTypeFlags, DWORD dwExpectedFormatTypeFlags, DWORD dwFlags, DWORD
	// *pdwMsgAndCertEncodingType, DWORD *pdwContentType, DWORD *pdwFormatType, HCERTSTORE *phCertStore, HCRYPTMSG *phMsg, const void
	// **ppvContext );
	[DllImport(Lib.Crypt32, SetLastError = true, ExactSpelling = true)]
	[PInvokeData("wincrypt.h", MSDNShortId = "d882f2b0-0f0a-41c7-afca-a232dc00797b")]
	[return: MarshalAs(UnmanagedType.Bool)]
	public static extern bool CryptQueryObject(CertQueryObjectType dwObjectType, [In] IntPtr pvObject, CertQueryContentFlags dwExpectedContentTypeFlags, CertQueryFormatFlags dwExpectedFormatTypeFlags,
		[Optional] uint dwFlags, out CertEncodingType pdwMsgAndCertEncodingType, out CertQueryContentType pdwContentType, out CertQueryFormatType pdwFormatType, out SafeHCERTSTORE phCertStore,
		out SafeHCRYPTMSG phMsg, out SafePCCERT_CONTEXT ppvContext);

	/// <summary>
	/// <para>Indicates the type of the object to be queried. This must be one of the following values.</para>
	/// <list type="table">
	/// <listheader>
	/// <term>Value</term>
	/// <term>Meaning</term>
	/// </listheader>
	/// <item>
	/// <term>CERT_QUERY_OBJECT_BLOB</term>
	/// <term>The object is stored in a structure in memory.</term>
	/// </item>
	/// <item>
	/// <term>CERT_QUERY_OBJECT_FILE</term>
	/// <term>The object is stored in a file.</term>
	/// </item>
	/// </list>
	/// <para>A pointer to the object to be queried. The type of data pointer depends on the contents of the dwObjectType parameter.</para>
	/// <list type="table">
	/// <listheader>
	/// <term>dwObjectType value</term>
	/// <term>Meaning</term>
	/// </listheader>
	/// <item>
	/// <term>CERT_QUERY_OBJECT_BLOB</term>
	/// <term>This parameter is a pointer to a CERT_BLOB, or similar, structure that contains the object to query.</term>
	/// </item>
	/// <item>
	/// <term>CERT_QUERY_OBJECT_FILE</term>
	/// <term>This parameter is a pointer to a null-terminated Unicode string that contains the path and name of the file to query.</term>
	/// </item>
	/// </list>
	/// <para>Indicates the expected content type. This can be one of the following values.</para>
	/// <list type="table">
	/// <listheader>
	/// <term>Value</term>
	/// <term>Meaning</term>
	/// </listheader>
	/// <item>
	/// <term>CERT_QUERY_CONTENT_FLAG_ALL</term>
	/// <term>
	/// The content can be any type. This does not include the CERT_QUERY_CONTENT_FLAG_PFX_AND_LOAD flag. If this flag is specified,
	/// this function will attempt to obtain information about the object, trying different content types until the proper content type
	/// is found or the content types are exhausted. This is obviously inefficient, so this flag should only be used if the content type
	/// is not known.
	/// </term>
	/// </item>
	/// <item>
	/// <term>CERT_QUERY_CONTENT_FLAG_CERT</term>
	/// <term>The content is a single certificate.</term>
	/// </item>
	/// <item>
	/// <term>CERT_QUERY_CONTENT_FLAG_CERT_PAIR</term>
	/// <term>
	/// The content is an Abstract Syntax Notation One (ASN.1) encoded X509_CERT_PAIR (an encoded certificate pair that contains either
	/// forward, reverse, or forward and reverse cross certificates).
	/// </term>
	/// </item>
	/// <item>
	/// <term>CERT_QUERY_CONTENT_FLAG_CRL</term>
	/// <term>The content is a single CRL.</term>
	/// </item>
	/// <item>
	/// <term>CERT_QUERY_CONTENT_FLAG_CTL</term>
	/// <term>The content is a single CTL.</term>
	/// </item>
	/// <item>
	/// <term>CERT_QUERY_CONTENT_FLAG_PFX</term>
	/// <term>
	/// The content is a PFX (PKCS #12) packet, but it will not be loaded by this function. You can use the PFXImportCertStore function
	/// to load this into a store.
	/// </term>
	/// </item>
	/// <item>
	/// <term>CERT_QUERY_CONTENT_FLAG_PFX_AND_LOAD</term>
	/// <term>
	/// The content is a PFX (PKCS #12) packet and will be loaded by this function subject to the conditions specified in the following
	/// note. Windows Server 2003 and Windows XP: This value is not supported.
	/// </term>
	/// </item>
	/// <item>
	/// <term>CERT_QUERY_CONTENT_FLAG_PKCS7_SIGNED</term>
	/// <term>The content is a PKCS #7 signed message.</term>
	/// </item>
	/// <item>
	/// <term>CERT_QUERY_CONTENT_FLAG_PKCS7_SIGNED_EMBED</term>
	/// <term>The content is an embedded PKCS #7 signed message.</term>
	/// </item>
	/// <item>
	/// <term>CERT_QUERY_CONTENT_FLAG_PKCS7_UNSIGNED</term>
	/// <term>The content is a PKCS #7 unsigned message.</term>
	/// </item>
	/// <item>
	/// <term>CERT_QUERY_CONTENT_FLAG_PKCS10</term>
	/// <term>The content is a PKCS #10 message.</term>
	/// </item>
	/// <item>
	/// <term>CERT_QUERY_CONTENT_FLAG_SERIALIZED_CERT</term>
	/// <term>The content is a serialized single certificate.</term>
	/// </item>
	/// <item>
	/// <term>CERT_QUERY_CONTENT_FLAG_SERIALIZED_CRL</term>
	/// <term>The content is a serialized single CRL.</term>
	/// </item>
	/// <item>
	/// <term>CERT_QUERY_CONTENT_FLAG_SERIALIZED_CTL</term>
	/// <term>The content is serialized single CTL.</term>
	/// </item>
	/// <item>
	/// <term>CERT_QUERY_CONTENT_FLAG_SERIALIZED_STORE</term>
	/// <term>The content is a serialized store.</term>
	/// </item>
	/// </list>
	/// <para>Indicates the expected format of the returned type. This can be one of the following values.</para>
	/// <list type="table">
	/// <listheader>
	/// <term>Value</term>
	/// <term>Meaning</term>
	/// </listheader>
	/// <item>
	/// <term>CERT_QUERY_FORMAT_FLAG_ALL</term>
	/// <term>The content can be returned in any format.</term>
	/// </item>
	/// <item>
	/// <term>CERT_QUERY_FORMAT_FLAG_ASN_ASCII_HEX_ENCODED</term>
	/// <term>The content should be returned in ASCII hex-encoded format with a "{ASN}" prefix.</term>
	/// </item>
	/// <item>
	/// <term>CERT_QUERY_FORMAT_FLAG_BASE64_ENCODED</term>
	/// <term>The content should be returned in Base64 encoded format.</term>
	/// </item>
	/// <item>
	/// <term>CERT_QUERY_FORMAT_FLAG_BINARY</term>
	/// <term>The content should be returned in binary format.</term>
	/// </item>
	/// </list>
	/// <para>This parameter is reserved for future use and must be set to zero.</para>
	/// <para>
	/// A pointer to a <c>DWORD</c> value that receives the type of encoding used in the message. If this information is not needed, set
	/// this parameter to <c>NULL</c>.
	/// </para>
	/// <para>This parameter can receives a combination of one or more of the following values.</para>
	/// <list type="table">
	/// <listheader>
	/// <term>Value</term>
	/// <term>Meaning</term>
	/// </listheader>
	/// <item>
	/// <term>PKCS_7_ASN_ENCODING 65536 (0x10000)</term>
	/// <term>Specifies PKCS 7 message encoding.</term>
	/// </item>
	/// <item>
	/// <term>X509_ASN_ENCODING 1 (0x1)</term>
	/// <term>Specifies X.509 certificate encoding.</term>
	/// </item>
	/// </list>
	/// <para>
	/// A pointer to a <c>DWORD</c> value that receives the actual type of the content. If this information is not needed, set this
	/// parameter to <c>NULL</c>. The returned content type can be one of the following values.
	/// </para>
	/// <list type="table">
	/// <listheader>
	/// <term>Value</term>
	/// <term>Meaning</term>
	/// </listheader>
	/// <item>
	/// <term>CERT_QUERY_CONTENT_CERT</term>
	/// <term>The content is a single certificate.</term>
	/// </item>
	/// <item>
	/// <term>CERT_QUERY_CONTENT_CERT_PAIR</term>
	/// <term>The content is an ASN.1 encoded X509_CERT_pair.</term>
	/// </item>
	/// <item>
	/// <term>CERT_QUERY_CONTENT_CRL</term>
	/// <term>The content is a single CRL.</term>
	/// </item>
	/// <item>
	/// <term>CERT_QUERY_CONTENT_CTL</term>
	/// <term>The content is a single CTL.</term>
	/// </item>
	/// <item>
	/// <term>CERT_QUERY_CONTENT_PFX</term>
	/// <term>
	/// The content is a PFX (PKCS #12) packet. This function only verifies that the object is a PKCS #12 packet. The PKCS #12 packet is
	/// not loaded into a certificate store.
	/// </term>
	/// </item>
	/// <item>
	/// <term>CERT_QUERY_CONTENT_PFX_AND_LOAD</term>
	/// <term>
	/// The content is a PFX (PKCS #12) packet, and it has been loaded into a certificate store. Windows Server 2003 and Windows XP:
	/// This value is not supported.
	/// </term>
	/// </item>
	/// <item>
	/// <term>CERT_QUERY_CONTENT_PKCS7_SIGNED</term>
	/// <term>The content is a PKCS #7 signed message.</term>
	/// </item>
	/// <item>
	/// <term>CERT_QUERY_CONTENT_PKCS7_SIGNED_EMBED</term>
	/// <term>The content is an embedded PKCS #7 signed message.</term>
	/// </item>
	/// <item>
	/// <term>CERT_QUERY_CONTENT_PKCS7_UNSIGNED</term>
	/// <term>The content is a PKCS #7 unsigned message.</term>
	/// </item>
	/// <item>
	/// <term>CERT_QUERY_CONTENT_PKCS10</term>
	/// <term>The content is a PKCS #10 message.</term>
	/// </item>
	/// <item>
	/// <term>CERT_QUERY_CONTENT_SERIALIZED_CERT</term>
	/// <term>The content is a serialized single certificate.</term>
	/// </item>
	/// <item>
	/// <term>CERT_QUERY_CONTENT_SERIALIZED_CRL</term>
	/// <term>The content is a serialized single CRL.</term>
	/// </item>
	/// <item>
	/// <term>CERT_QUERY_CONTENT_SERIALIZED_CTL</term>
	/// <term>The content is a serialized single CTL.</term>
	/// </item>
	/// <item>
	/// <term>CERT_QUERY_CONTENT_SERIALIZED_STORE</term>
	/// <term>The content is a serialized store.</term>
	/// </item>
	/// </list>
	/// <para>
	/// A pointer to a <c>DWORD</c> value that receives the actual format type of the content. If this information is not needed, set
	/// this parameter to <c>NULL</c>. The returned format type can be one of the following values.
	/// </para>
	/// <list type="table">
	/// <listheader>
	/// <term>Value</term>
	/// <term>Meaning</term>
	/// </listheader>
	/// <item>
	/// <term>CERT_QUERY_FORMAT_ASN_ASCII_HEX_ENCODED</term>
	/// <term>The content is in ASCII hex-encoded format with an "{ASN}" prefix.</term>
	/// </item>
	/// <item>
	/// <term>CERT_QUERY_FORMAT_BASE64_ENCODED</term>
	/// <term>The content is in Base64 encoded format.</term>
	/// </item>
	/// <item>
	/// <term>CERT_QUERY_FORMAT_BINARY</term>
	/// <term>The content is in binary format.</term>
	/// </item>
	/// </list>
	/// <para>
	/// A pointer to an <c>HCERTSTORE</c> value that receives a handle to a certificate store that includes all of the certificates,
	/// CRLs, and CTLs in the object.
	/// </para>
	/// <para>
	/// This parameter only receives a certificate store handle when the dwContentType parameter receives one of the following values.
	/// This parameter receives <c>NULL</c> for all other content types.
	/// </para>
	/// <para>CERT_QUERY_CONTENT_CERT</para>
	/// <para>CERT_QUERY_CONTENT_CRL</para>
	/// <para>CERT_QUERY_CONTENT_CTL</para>
	/// <para>CERT_QUERY_CONTENT_PFX_AND_LOAD</para>
	/// <para>CERT_QUERY_CONTENT_PKCS7_SIGNED</para>
	/// <para>CERT_QUERY_CONTENT_PKCS7_SIGNED_EMBED</para>
	/// <para>CERT_QUERY_CONTENT_SERIALIZED_CERT</para>
	/// <para>CERT_QUERY_CONTENT_SERIALIZED_CRL</para>
	/// <para>CERT_QUERY_CONTENT_SERIALIZED_CTL</para>
	/// <para>CERT_QUERY_CONTENT_SERIALIZED_STORE</para>
	/// <para>When you have finished using the handle, free it by passing the handle to the CertCloseStore function.</para>
	/// <para>If this information is not needed, set this parameter to <c>NULL</c>.</para>
	/// <para>A pointer to an <c>HCRYPTMSG</c> value that receives the handle of an opened message.</para>
	/// <para>
	/// This parameter only receives a message handle when the dwContentType parameter receives one of the following values. This
	/// parameter receives <c>NULL</c> for all other content types.
	/// </para>
	/// <para>CERT_QUERY_CONTENT_PKCS7_SIGNED</para>
	/// <para>CERT_QUERY_CONTENT_PKCS7_SIGNED_EMBED</para>
	/// <para>CERT_QUERY_CONTENT_PKCS7_UNSIGNED</para>
	/// <para>When you have finished using the handle, free it by passing the handle to the CryptMsgClose function.</para>
	/// <para>If this information is not needed, set this parameter to <c>NULL</c>.</para>
	/// <para>A pointer to a pointer that receives additional information about the object.</para>
	/// <para>
	/// The format of this data depends on the value received by the dwContentType parameter. The following table lists the format of
	/// the data for the specified dwContentType value.
	/// </para>
	/// <list type="table">
	/// <listheader>
	/// <term>dwContentType value</term>
	/// <term>Meaning</term>
	/// </listheader>
	/// <item>
	/// <term>CERT_QUERY_CONTENT_CERT</term>
	/// <term>
	/// This parameter receives a pointer to a CERT_CONTEXT structure. When you have finished using the structure, free it by passing
	/// this pointer to the CertFreeCertificateContext function.
	/// </term>
	/// </item>
	/// <item>
	/// <term>CERT_QUERY_CONTENT_CRL</term>
	/// <term>
	/// This parameter receives a pointer to a CRL_CONTEXT structure. When you have finished using the structure, free it by passing
	/// this pointer to the CertFreeCRLContext function.
	/// </term>
	/// </item>
	/// <item>
	/// <term>CERT_QUERY_CONTENT_CTL</term>
	/// <term>
	/// This parameter receives a pointer to a CTL_CONTEXT structure. When you have finished using the structure, free it by passing
	/// this pointer to the CertFreeCTLContext function.
	/// </term>
	/// </item>
	/// <item>
	/// <term>CERT_QUERY_CONTENT_SERIALIZED_CERT</term>
	/// <term>
	/// This parameter receives a pointer to a CERT_CONTEXT structure. When you have finished using the structure, free it by passing
	/// this pointer to the CertFreeCertificateContext function.
	/// </term>
	/// </item>
	/// <item>
	/// <term>CERT_QUERY_CONTENT_SERIALIZED_CRL</term>
	/// <term>
	/// This parameter receives a pointer to a CRL_CONTEXT structure. When you have finished using the structure, free it by passing
	/// this pointer to the CertFreeCRLContext function.
	/// </term>
	/// </item>
	/// <item>
	/// <term>CERT_QUERY_CONTENT_SERIALIZED_CTL</term>
	/// <term>
	/// This parameter receives a pointer to a CTL_CONTEXT structure. When you have finished using the structure, free it by passing
	/// this pointer to the CertFreeCTLContext function.
	/// </term>
	/// </item>
	/// </list>
	/// <para>If this information is not needed, set this parameter to <c>NULL</c>.</para>
	/// </summary>
	/// <param name="dwObjectType">
	/// <para>Indicates the type of the object to be queried. This must be one of the following values.</para>
	/// <list type="table">
	/// <listheader>
	/// <term>Value</term>
	/// <term>Meaning</term>
	/// </listheader>
	/// <item>
	/// <term>CERT_QUERY_OBJECT_BLOB</term>
	/// <term>The object is stored in a structure in memory.</term>
	/// </item>
	/// <item>
	/// <term>CERT_QUERY_OBJECT_FILE</term>
	/// <term>The object is stored in a file.</term>
	/// </item>
	/// </list>
	/// </param>
	/// <param name="pvObject">
	/// <para>A pointer to the object to be queried. The type of data pointer depends on the contents of the dwObjectType parameter.</para>
	/// <list type="table">
	/// <listheader>
	/// <term>dwObjectType value</term>
	/// <term>Meaning</term>
	/// </listheader>
	/// <item>
	/// <term>CERT_QUERY_OBJECT_BLOB</term>
	/// <term>This parameter is a pointer to a CERT_BLOB, or similar, structure that contains the object to query.</term>
	/// </item>
	/// <item>
	/// <term>CERT_QUERY_OBJECT_FILE</term>
	/// <term>This parameter is a pointer to a null-terminated Unicode string that contains the path and name of the file to query.</term>
	/// </item>
	/// </list>
	/// </param>
	/// <param name="dwExpectedContentTypeFlags">
	/// <para>Indicates the expected content type. This can be one of the following values.</para>
	/// <list type="table">
	/// <listheader>
	/// <term>Value</term>
	/// <term>Meaning</term>
	/// </listheader>
	/// <item>
	/// <term>CERT_QUERY_CONTENT_FLAG_ALL</term>
	/// <term>
	/// The content can be any type. This does not include the CERT_QUERY_CONTENT_FLAG_PFX_AND_LOAD flag. If this flag is specified,
	/// this function will attempt to obtain information about the object, trying different content types until the proper content type
	/// is found or the content types are exhausted. This is obviously inefficient, so this flag should only be used if the content type
	/// is not known.
	/// </term>
	/// </item>
	/// <item>
	/// <term>CERT_QUERY_CONTENT_FLAG_CERT</term>
	/// <term>The content is a single certificate.</term>
	/// </item>
	/// <item>
	/// <term>CERT_QUERY_CONTENT_FLAG_CERT_PAIR</term>
	/// <term>
	/// The content is an Abstract Syntax Notation One (ASN.1) encoded X509_CERT_PAIR (an encoded certificate pair that contains either
	/// forward, reverse, or forward and reverse cross certificates).
	/// </term>
	/// </item>
	/// <item>
	/// <term>CERT_QUERY_CONTENT_FLAG_CRL</term>
	/// <term>The content is a single CRL.</term>
	/// </item>
	/// <item>
	/// <term>CERT_QUERY_CONTENT_FLAG_CTL</term>
	/// <term>The content is a single CTL.</term>
	/// </item>
	/// <item>
	/// <term>CERT_QUERY_CONTENT_FLAG_PFX</term>
	/// <term>
	/// The content is a PFX (PKCS #12) packet, but it will not be loaded by this function. You can use the PFXImportCertStore function
	/// to load this into a store.
	/// </term>
	/// </item>
	/// <item>
	/// <term>CERT_QUERY_CONTENT_FLAG_PFX_AND_LOAD</term>
	/// <term>
	/// The content is a PFX (PKCS #12) packet and will be loaded by this function subject to the conditions specified in the following
	/// note. Windows Server 2003 and Windows XP: This value is not supported.
	/// </term>
	/// </item>
	/// <item>
	/// <term>CERT_QUERY_CONTENT_FLAG_PKCS7_SIGNED</term>
	/// <term>The content is a PKCS #7 signed message.</term>
	/// </item>
	/// <item>
	/// <term>CERT_QUERY_CONTENT_FLAG_PKCS7_SIGNED_EMBED</term>
	/// <term>The content is an embedded PKCS #7 signed message.</term>
	/// </item>
	/// <item>
	/// <term>CERT_QUERY_CONTENT_FLAG_PKCS7_UNSIGNED</term>
	/// <term>The content is a PKCS #7 unsigned message.</term>
	/// </item>
	/// <item>
	/// <term>CERT_QUERY_CONTENT_FLAG_PKCS10</term>
	/// <term>The content is a PKCS #10 message.</term>
	/// </item>
	/// <item>
	/// <term>CERT_QUERY_CONTENT_FLAG_SERIALIZED_CERT</term>
	/// <term>The content is a serialized single certificate.</term>
	/// </item>
	/// <item>
	/// <term>CERT_QUERY_CONTENT_FLAG_SERIALIZED_CRL</term>
	/// <term>The content is a serialized single CRL.</term>
	/// </item>
	/// <item>
	/// <term>CERT_QUERY_CONTENT_FLAG_SERIALIZED_CTL</term>
	/// <term>The content is serialized single CTL.</term>
	/// </item>
	/// <item>
	/// <term>CERT_QUERY_CONTENT_FLAG_SERIALIZED_STORE</term>
	/// <term>The content is a serialized store.</term>
	/// </item>
	/// </list>
	/// </param>
	/// <param name="dwExpectedFormatTypeFlags">
	/// <para>Indicates the expected format of the returned type. This can be one of the following values.</para>
	/// <list type="table">
	/// <listheader>
	/// <term>Value</term>
	/// <term>Meaning</term>
	/// </listheader>
	/// <item>
	/// <term>CERT_QUERY_FORMAT_FLAG_ALL</term>
	/// <term>The content can be returned in any format.</term>
	/// </item>
	/// <item>
	/// <term>CERT_QUERY_FORMAT_FLAG_ASN_ASCII_HEX_ENCODED</term>
	/// <term>The content should be returned in ASCII hex-encoded format with a "{ASN}" prefix.</term>
	/// </item>
	/// <item>
	/// <term>CERT_QUERY_FORMAT_FLAG_BASE64_ENCODED</term>
	/// <term>The content should be returned in Base64 encoded format.</term>
	/// </item>
	/// <item>
	/// <term>CERT_QUERY_FORMAT_FLAG_BINARY</term>
	/// <term>The content should be returned in binary format.</term>
	/// </item>
	/// </list>
	/// </param>
	/// <param name="dwFlags">This parameter is reserved for future use and must be set to zero.</param>
	/// <param name="pdwMsgAndCertEncodingType">
	/// <para>
	/// A pointer to a <c>DWORD</c> value that receives the type of encoding used in the message. If this information is not needed, set
	/// this parameter to <c>NULL</c>.
	/// </para>
	/// <para>This parameter can receives a combination of one or more of the following values.</para>
	/// <list type="table">
	/// <listheader>
	/// <term>Value</term>
	/// <term>Meaning</term>
	/// </listheader>
	/// <item>
	/// <term>PKCS_7_ASN_ENCODING 65536 (0x10000)</term>
	/// <term>Specifies PKCS 7 message encoding.</term>
	/// </item>
	/// <item>
	/// <term>X509_ASN_ENCODING 1 (0x1)</term>
	/// <term>Specifies X.509 certificate encoding.</term>
	/// </item>
	/// </list>
	/// </param>
	/// <param name="pdwContentType">
	/// <para>
	/// A pointer to a <c>DWORD</c> value that receives the actual type of the content. If this information is not needed, set this
	/// parameter to <c>NULL</c>. The returned content type can be one of the following values.
	/// </para>
	/// <list type="table">
	/// <listheader>
	/// <term>Value</term>
	/// <term>Meaning</term>
	/// </listheader>
	/// <item>
	/// <term>CERT_QUERY_CONTENT_CERT</term>
	/// <term>The content is a single certificate.</term>
	/// </item>
	/// <item>
	/// <term>CERT_QUERY_CONTENT_CERT_PAIR</term>
	/// <term>The content is an ASN.1 encoded X509_CERT_pair.</term>
	/// </item>
	/// <item>
	/// <term>CERT_QUERY_CONTENT_CRL</term>
	/// <term>The content is a single CRL.</term>
	/// </item>
	/// <item>
	/// <term>CERT_QUERY_CONTENT_CTL</term>
	/// <term>The content is a single CTL.</term>
	/// </item>
	/// <item>
	/// <term>CERT_QUERY_CONTENT_PFX</term>
	/// <term>
	/// The content is a PFX (PKCS #12) packet. This function only verifies that the object is a PKCS #12 packet. The PKCS #12 packet is
	/// not loaded into a certificate store.
	/// </term>
	/// </item>
	/// <item>
	/// <term>CERT_QUERY_CONTENT_PFX_AND_LOAD</term>
	/// <term>
	/// The content is a PFX (PKCS #12) packet, and it has been loaded into a certificate store. Windows Server 2003 and Windows XP:
	/// This value is not supported.
	/// </term>
	/// </item>
	/// <item>
	/// <term>CERT_QUERY_CONTENT_PKCS7_SIGNED</term>
	/// <term>The content is a PKCS #7 signed message.</term>
	/// </item>
	/// <item>
	/// <term>CERT_QUERY_CONTENT_PKCS7_SIGNED_EMBED</term>
	/// <term>The content is an embedded PKCS #7 signed message.</term>
	/// </item>
	/// <item>
	/// <term>CERT_QUERY_CONTENT_PKCS7_UNSIGNED</term>
	/// <term>The content is a PKCS #7 unsigned message.</term>
	/// </item>
	/// <item>
	/// <term>CERT_QUERY_CONTENT_PKCS10</term>
	/// <term>The content is a PKCS #10 message.</term>
	/// </item>
	/// <item>
	/// <term>CERT_QUERY_CONTENT_SERIALIZED_CERT</term>
	/// <term>The content is a serialized single certificate.</term>
	/// </item>
	/// <item>
	/// <term>CERT_QUERY_CONTENT_SERIALIZED_CRL</term>
	/// <term>The content is a serialized single CRL.</term>
	/// </item>
	/// <item>
	/// <term>CERT_QUERY_CONTENT_SERIALIZED_CTL</term>
	/// <term>The content is a serialized single CTL.</term>
	/// </item>
	/// <item>
	/// <term>CERT_QUERY_CONTENT_SERIALIZED_STORE</term>
	/// <term>The content is a serialized store.</term>
	/// </item>
	/// </list>
	/// </param>
	/// <param name="pdwFormatType">
	/// <para>
	/// A pointer to a <c>DWORD</c> value that receives the actual format type of the content. If this information is not needed, set
	/// this parameter to <c>NULL</c>. The returned format type can be one of the following values.
	/// </para>
	/// <list type="table">
	/// <listheader>
	/// <term>Value</term>
	/// <term>Meaning</term>
	/// </listheader>
	/// <item>
	/// <term>CERT_QUERY_FORMAT_ASN_ASCII_HEX_ENCODED</term>
	/// <term>The content is in ASCII hex-encoded format with an "{ASN}" prefix.</term>
	/// </item>
	/// <item>
	/// <term>CERT_QUERY_FORMAT_BASE64_ENCODED</term>
	/// <term>The content is in Base64 encoded format.</term>
	/// </item>
	/// <item>
	/// <term>CERT_QUERY_FORMAT_BINARY</term>
	/// <term>The content is in binary format.</term>
	/// </item>
	/// </list>
	/// </param>
	/// <param name="phCertStore">
	/// <para>
	/// A pointer to an <c>HCERTSTORE</c> value that receives a handle to a certificate store that includes all of the certificates,
	/// CRLs, and CTLs in the object.
	/// </para>
	/// <para>
	/// This parameter only receives a certificate store handle when the dwContentType parameter receives one of the following values.
	/// This parameter receives <c>NULL</c> for all other content types.
	/// </para>
	/// <para>CERT_QUERY_CONTENT_CERT</para>
	/// <para>CERT_QUERY_CONTENT_CRL</para>
	/// <para>CERT_QUERY_CONTENT_CTL</para>
	/// <para>CERT_QUERY_CONTENT_PFX_AND_LOAD</para>
	/// <para>CERT_QUERY_CONTENT_PKCS7_SIGNED</para>
	/// <para>CERT_QUERY_CONTENT_PKCS7_SIGNED_EMBED</para>
	/// <para>CERT_QUERY_CONTENT_SERIALIZED_CERT</para>
	/// <para>CERT_QUERY_CONTENT_SERIALIZED_CRL</para>
	/// <para>CERT_QUERY_CONTENT_SERIALIZED_CTL</para>
	/// <para>CERT_QUERY_CONTENT_SERIALIZED_STORE</para>
	/// <para>When you have finished using the handle, free it by passing the handle to the CertCloseStore function.</para>
	/// <para>If this information is not needed, set this parameter to <c>NULL</c>.</para>
	/// </param>
	/// <param name="phMsg">
	/// <para>A pointer to an <c>HCRYPTMSG</c> value that receives the handle of an opened message.</para>
	/// <para>
	/// This parameter only receives a message handle when the dwContentType parameter receives one of the following values. This
	/// parameter receives <c>NULL</c> for all other content types.
	/// </para>
	/// <para>CERT_QUERY_CONTENT_PKCS7_SIGNED</para>
	/// <para>CERT_QUERY_CONTENT_PKCS7_SIGNED_EMBED</para>
	/// <para>CERT_QUERY_CONTENT_PKCS7_UNSIGNED</para>
	/// <para>When you have finished using the handle, free it by passing the handle to the CryptMsgClose function.</para>
	/// <para>If this information is not needed, set this parameter to <c>NULL</c>.</para>
	/// </param>
	/// <param name="ppvContext">
	/// <para>A pointer to a pointer that receives additional information about the object.</para>
	/// <para>
	/// The format of this data depends on the value received by the dwContentType parameter. The following table lists the format of
	/// the data for the specified dwContentType value.
	/// </para>
	/// <list type="table">
	/// <listheader>
	/// <term>dwContentType value</term>
	/// <term>Meaning</term>
	/// </listheader>
	/// <item>
	/// <term>CERT_QUERY_CONTENT_CERT</term>
	/// <term>
	/// This parameter receives a pointer to a CERT_CONTEXT structure. When you have finished using the structure, free it by passing
	/// this pointer to the CertFreeCertificateContext function.
	/// </term>
	/// </item>
	/// <item>
	/// <term>CERT_QUERY_CONTENT_CRL</term>
	/// <term>
	/// This parameter receives a pointer to a CRL_CONTEXT structure. When you have finished using the structure, free it by passing
	/// this pointer to the CertFreeCRLContext function.
	/// </term>
	/// </item>
	/// <item>
	/// <term>CERT_QUERY_CONTENT_CTL</term>
	/// <term>
	/// This parameter receives a pointer to a CTL_CONTEXT structure. When you have finished using the structure, free it by passing
	/// this pointer to the CertFreeCTLContext function.
	/// </term>
	/// </item>
	/// <item>
	/// <term>CERT_QUERY_CONTENT_SERIALIZED_CERT</term>
	/// <term>
	/// This parameter receives a pointer to a CERT_CONTEXT structure. When you have finished using the structure, free it by passing
	/// this pointer to the CertFreeCertificateContext function.
	/// </term>
	/// </item>
	/// <item>
	/// <term>CERT_QUERY_CONTENT_SERIALIZED_CRL</term>
	/// <term>
	/// This parameter receives a pointer to a CRL_CONTEXT structure. When you have finished using the structure, free it by passing
	/// this pointer to the CertFreeCRLContext function.
	/// </term>
	/// </item>
	/// <item>
	/// <term>CERT_QUERY_CONTENT_SERIALIZED_CTL</term>
	/// <term>
	/// This parameter receives a pointer to a CTL_CONTEXT structure. When you have finished using the structure, free it by passing
	/// this pointer to the CertFreeCTLContext function.
	/// </term>
	/// </item>
	/// </list>
	/// <para>If this information is not needed, set this parameter to <c>NULL</c>.</para>
	/// </param>
	/// <returns>
	/// <para>If the function succeeds, the function returns nonzero.</para>
	/// <para>If the function fails, it returns zero. For extended error information, call GetLastError.</para>
	/// </returns>
	// https://docs.microsoft.com/en-us/windows/win32/api/wincrypt/nf-wincrypt-cryptqueryobject BOOL CryptQueryObject( DWORD
	// dwObjectType, const void *pvObject, DWORD dwExpectedContentTypeFlags, DWORD dwExpectedFormatTypeFlags, DWORD dwFlags, DWORD
	// *pdwMsgAndCertEncodingType, DWORD *pdwContentType, DWORD *pdwFormatType, HCERTSTORE *phCertStore, HCRYPTMSG *phMsg, const void
	// **ppvContext );
	[DllImport(Lib.Crypt32, SetLastError = true, ExactSpelling = true)]
	[PInvokeData("wincrypt.h", MSDNShortId = "d882f2b0-0f0a-41c7-afca-a232dc00797b")]
	[return: MarshalAs(UnmanagedType.Bool)]
	public static extern bool CryptQueryObject(CertQueryObjectType dwObjectType, [In] IntPtr pvObject, CertQueryContentFlags dwExpectedContentTypeFlags, CertQueryFormatFlags dwExpectedFormatTypeFlags,
		[Optional] uint dwFlags, out CertEncodingType pdwMsgAndCertEncodingType, out CertQueryContentType pdwContentType, out CertQueryFormatType pdwFormatType, out SafeHCERTSTORE phCertStore,
		out SafeHCRYPTMSG phMsg, out SafePCCRL_CONTEXT ppvContext);

	/// <summary>
	/// <para>Indicates the type of the object to be queried. This must be one of the following values.</para>
	/// <list type="table">
	/// <listheader>
	/// <term>Value</term>
	/// <term>Meaning</term>
	/// </listheader>
	/// <item>
	/// <term>CERT_QUERY_OBJECT_BLOB</term>
	/// <term>The object is stored in a structure in memory.</term>
	/// </item>
	/// <item>
	/// <term>CERT_QUERY_OBJECT_FILE</term>
	/// <term>The object is stored in a file.</term>
	/// </item>
	/// </list>
	/// <para>A pointer to the object to be queried. The type of data pointer depends on the contents of the dwObjectType parameter.</para>
	/// <list type="table">
	/// <listheader>
	/// <term>dwObjectType value</term>
	/// <term>Meaning</term>
	/// </listheader>
	/// <item>
	/// <term>CERT_QUERY_OBJECT_BLOB</term>
	/// <term>This parameter is a pointer to a CERT_BLOB, or similar, structure that contains the object to query.</term>
	/// </item>
	/// <item>
	/// <term>CERT_QUERY_OBJECT_FILE</term>
	/// <term>This parameter is a pointer to a null-terminated Unicode string that contains the path and name of the file to query.</term>
	/// </item>
	/// </list>
	/// <para>Indicates the expected content type. This can be one of the following values.</para>
	/// <list type="table">
	/// <listheader>
	/// <term>Value</term>
	/// <term>Meaning</term>
	/// </listheader>
	/// <item>
	/// <term>CERT_QUERY_CONTENT_FLAG_ALL</term>
	/// <term>
	/// The content can be any type. This does not include the CERT_QUERY_CONTENT_FLAG_PFX_AND_LOAD flag. If this flag is specified,
	/// this function will attempt to obtain information about the object, trying different content types until the proper content type
	/// is found or the content types are exhausted. This is obviously inefficient, so this flag should only be used if the content type
	/// is not known.
	/// </term>
	/// </item>
	/// <item>
	/// <term>CERT_QUERY_CONTENT_FLAG_CERT</term>
	/// <term>The content is a single certificate.</term>
	/// </item>
	/// <item>
	/// <term>CERT_QUERY_CONTENT_FLAG_CERT_PAIR</term>
	/// <term>
	/// The content is an Abstract Syntax Notation One (ASN.1) encoded X509_CERT_PAIR (an encoded certificate pair that contains either
	/// forward, reverse, or forward and reverse cross certificates).
	/// </term>
	/// </item>
	/// <item>
	/// <term>CERT_QUERY_CONTENT_FLAG_CRL</term>
	/// <term>The content is a single CRL.</term>
	/// </item>
	/// <item>
	/// <term>CERT_QUERY_CONTENT_FLAG_CTL</term>
	/// <term>The content is a single CTL.</term>
	/// </item>
	/// <item>
	/// <term>CERT_QUERY_CONTENT_FLAG_PFX</term>
	/// <term>
	/// The content is a PFX (PKCS #12) packet, but it will not be loaded by this function. You can use the PFXImportCertStore function
	/// to load this into a store.
	/// </term>
	/// </item>
	/// <item>
	/// <term>CERT_QUERY_CONTENT_FLAG_PFX_AND_LOAD</term>
	/// <term>
	/// The content is a PFX (PKCS #12) packet and will be loaded by this function subject to the conditions specified in the following
	/// note. Windows Server 2003 and Windows XP: This value is not supported.
	/// </term>
	/// </item>
	/// <item>
	/// <term>CERT_QUERY_CONTENT_FLAG_PKCS7_SIGNED</term>
	/// <term>The content is a PKCS #7 signed message.</term>
	/// </item>
	/// <item>
	/// <term>CERT_QUERY_CONTENT_FLAG_PKCS7_SIGNED_EMBED</term>
	/// <term>The content is an embedded PKCS #7 signed message.</term>
	/// </item>
	/// <item>
	/// <term>CERT_QUERY_CONTENT_FLAG_PKCS7_UNSIGNED</term>
	/// <term>The content is a PKCS #7 unsigned message.</term>
	/// </item>
	/// <item>
	/// <term>CERT_QUERY_CONTENT_FLAG_PKCS10</term>
	/// <term>The content is a PKCS #10 message.</term>
	/// </item>
	/// <item>
	/// <term>CERT_QUERY_CONTENT_FLAG_SERIALIZED_CERT</term>
	/// <term>The content is a serialized single certificate.</term>
	/// </item>
	/// <item>
	/// <term>CERT_QUERY_CONTENT_FLAG_SERIALIZED_CRL</term>
	/// <term>The content is a serialized single CRL.</term>
	/// </item>
	/// <item>
	/// <term>CERT_QUERY_CONTENT_FLAG_SERIALIZED_CTL</term>
	/// <term>The content is serialized single CTL.</term>
	/// </item>
	/// <item>
	/// <term>CERT_QUERY_CONTENT_FLAG_SERIALIZED_STORE</term>
	/// <term>The content is a serialized store.</term>
	/// </item>
	/// </list>
	/// <para>Indicates the expected format of the returned type. This can be one of the following values.</para>
	/// <list type="table">
	/// <listheader>
	/// <term>Value</term>
	/// <term>Meaning</term>
	/// </listheader>
	/// <item>
	/// <term>CERT_QUERY_FORMAT_FLAG_ALL</term>
	/// <term>The content can be returned in any format.</term>
	/// </item>
	/// <item>
	/// <term>CERT_QUERY_FORMAT_FLAG_ASN_ASCII_HEX_ENCODED</term>
	/// <term>The content should be returned in ASCII hex-encoded format with a "{ASN}" prefix.</term>
	/// </item>
	/// <item>
	/// <term>CERT_QUERY_FORMAT_FLAG_BASE64_ENCODED</term>
	/// <term>The content should be returned in Base64 encoded format.</term>
	/// </item>
	/// <item>
	/// <term>CERT_QUERY_FORMAT_FLAG_BINARY</term>
	/// <term>The content should be returned in binary format.</term>
	/// </item>
	/// </list>
	/// <para>This parameter is reserved for future use and must be set to zero.</para>
	/// <para>
	/// A pointer to a <c>DWORD</c> value that receives the type of encoding used in the message. If this information is not needed, set
	/// this parameter to <c>NULL</c>.
	/// </para>
	/// <para>This parameter can receives a combination of one or more of the following values.</para>
	/// <list type="table">
	/// <listheader>
	/// <term>Value</term>
	/// <term>Meaning</term>
	/// </listheader>
	/// <item>
	/// <term>PKCS_7_ASN_ENCODING 65536 (0x10000)</term>
	/// <term>Specifies PKCS 7 message encoding.</term>
	/// </item>
	/// <item>
	/// <term>X509_ASN_ENCODING 1 (0x1)</term>
	/// <term>Specifies X.509 certificate encoding.</term>
	/// </item>
	/// </list>
	/// <para>
	/// A pointer to a <c>DWORD</c> value that receives the actual type of the content. If this information is not needed, set this
	/// parameter to <c>NULL</c>. The returned content type can be one of the following values.
	/// </para>
	/// <list type="table">
	/// <listheader>
	/// <term>Value</term>
	/// <term>Meaning</term>
	/// </listheader>
	/// <item>
	/// <term>CERT_QUERY_CONTENT_CERT</term>
	/// <term>The content is a single certificate.</term>
	/// </item>
	/// <item>
	/// <term>CERT_QUERY_CONTENT_CERT_PAIR</term>
	/// <term>The content is an ASN.1 encoded X509_CERT_pair.</term>
	/// </item>
	/// <item>
	/// <term>CERT_QUERY_CONTENT_CRL</term>
	/// <term>The content is a single CRL.</term>
	/// </item>
	/// <item>
	/// <term>CERT_QUERY_CONTENT_CTL</term>
	/// <term>The content is a single CTL.</term>
	/// </item>
	/// <item>
	/// <term>CERT_QUERY_CONTENT_PFX</term>
	/// <term>
	/// The content is a PFX (PKCS #12) packet. This function only verifies that the object is a PKCS #12 packet. The PKCS #12 packet is
	/// not loaded into a certificate store.
	/// </term>
	/// </item>
	/// <item>
	/// <term>CERT_QUERY_CONTENT_PFX_AND_LOAD</term>
	/// <term>
	/// The content is a PFX (PKCS #12) packet, and it has been loaded into a certificate store. Windows Server 2003 and Windows XP:
	/// This value is not supported.
	/// </term>
	/// </item>
	/// <item>
	/// <term>CERT_QUERY_CONTENT_PKCS7_SIGNED</term>
	/// <term>The content is a PKCS #7 signed message.</term>
	/// </item>
	/// <item>
	/// <term>CERT_QUERY_CONTENT_PKCS7_SIGNED_EMBED</term>
	/// <term>The content is an embedded PKCS #7 signed message.</term>
	/// </item>
	/// <item>
	/// <term>CERT_QUERY_CONTENT_PKCS7_UNSIGNED</term>
	/// <term>The content is a PKCS #7 unsigned message.</term>
	/// </item>
	/// <item>
	/// <term>CERT_QUERY_CONTENT_PKCS10</term>
	/// <term>The content is a PKCS #10 message.</term>
	/// </item>
	/// <item>
	/// <term>CERT_QUERY_CONTENT_SERIALIZED_CERT</term>
	/// <term>The content is a serialized single certificate.</term>
	/// </item>
	/// <item>
	/// <term>CERT_QUERY_CONTENT_SERIALIZED_CRL</term>
	/// <term>The content is a serialized single CRL.</term>
	/// </item>
	/// <item>
	/// <term>CERT_QUERY_CONTENT_SERIALIZED_CTL</term>
	/// <term>The content is a serialized single CTL.</term>
	/// </item>
	/// <item>
	/// <term>CERT_QUERY_CONTENT_SERIALIZED_STORE</term>
	/// <term>The content is a serialized store.</term>
	/// </item>
	/// </list>
	/// <para>
	/// A pointer to a <c>DWORD</c> value that receives the actual format type of the content. If this information is not needed, set
	/// this parameter to <c>NULL</c>. The returned format type can be one of the following values.
	/// </para>
	/// <list type="table">
	/// <listheader>
	/// <term>Value</term>
	/// <term>Meaning</term>
	/// </listheader>
	/// <item>
	/// <term>CERT_QUERY_FORMAT_ASN_ASCII_HEX_ENCODED</term>
	/// <term>The content is in ASCII hex-encoded format with an "{ASN}" prefix.</term>
	/// </item>
	/// <item>
	/// <term>CERT_QUERY_FORMAT_BASE64_ENCODED</term>
	/// <term>The content is in Base64 encoded format.</term>
	/// </item>
	/// <item>
	/// <term>CERT_QUERY_FORMAT_BINARY</term>
	/// <term>The content is in binary format.</term>
	/// </item>
	/// </list>
	/// <para>
	/// A pointer to an <c>HCERTSTORE</c> value that receives a handle to a certificate store that includes all of the certificates,
	/// CRLs, and CTLs in the object.
	/// </para>
	/// <para>
	/// This parameter only receives a certificate store handle when the dwContentType parameter receives one of the following values.
	/// This parameter receives <c>NULL</c> for all other content types.
	/// </para>
	/// <para>CERT_QUERY_CONTENT_CERT</para>
	/// <para>CERT_QUERY_CONTENT_CRL</para>
	/// <para>CERT_QUERY_CONTENT_CTL</para>
	/// <para>CERT_QUERY_CONTENT_PFX_AND_LOAD</para>
	/// <para>CERT_QUERY_CONTENT_PKCS7_SIGNED</para>
	/// <para>CERT_QUERY_CONTENT_PKCS7_SIGNED_EMBED</para>
	/// <para>CERT_QUERY_CONTENT_SERIALIZED_CERT</para>
	/// <para>CERT_QUERY_CONTENT_SERIALIZED_CRL</para>
	/// <para>CERT_QUERY_CONTENT_SERIALIZED_CTL</para>
	/// <para>CERT_QUERY_CONTENT_SERIALIZED_STORE</para>
	/// <para>When you have finished using the handle, free it by passing the handle to the CertCloseStore function.</para>
	/// <para>If this information is not needed, set this parameter to <c>NULL</c>.</para>
	/// <para>A pointer to an <c>HCRYPTMSG</c> value that receives the handle of an opened message.</para>
	/// <para>
	/// This parameter only receives a message handle when the dwContentType parameter receives one of the following values. This
	/// parameter receives <c>NULL</c> for all other content types.
	/// </para>
	/// <para>CERT_QUERY_CONTENT_PKCS7_SIGNED</para>
	/// <para>CERT_QUERY_CONTENT_PKCS7_SIGNED_EMBED</para>
	/// <para>CERT_QUERY_CONTENT_PKCS7_UNSIGNED</para>
	/// <para>When you have finished using the handle, free it by passing the handle to the CryptMsgClose function.</para>
	/// <para>If this information is not needed, set this parameter to <c>NULL</c>.</para>
	/// <para>A pointer to a pointer that receives additional information about the object.</para>
	/// <para>
	/// The format of this data depends on the value received by the dwContentType parameter. The following table lists the format of
	/// the data for the specified dwContentType value.
	/// </para>
	/// <list type="table">
	/// <listheader>
	/// <term>dwContentType value</term>
	/// <term>Meaning</term>
	/// </listheader>
	/// <item>
	/// <term>CERT_QUERY_CONTENT_CERT</term>
	/// <term>
	/// This parameter receives a pointer to a CERT_CONTEXT structure. When you have finished using the structure, free it by passing
	/// this pointer to the CertFreeCertificateContext function.
	/// </term>
	/// </item>
	/// <item>
	/// <term>CERT_QUERY_CONTENT_CRL</term>
	/// <term>
	/// This parameter receives a pointer to a CRL_CONTEXT structure. When you have finished using the structure, free it by passing
	/// this pointer to the CertFreeCRLContext function.
	/// </term>
	/// </item>
	/// <item>
	/// <term>CERT_QUERY_CONTENT_CTL</term>
	/// <term>
	/// This parameter receives a pointer to a CTL_CONTEXT structure. When you have finished using the structure, free it by passing
	/// this pointer to the CertFreeCTLContext function.
	/// </term>
	/// </item>
	/// <item>
	/// <term>CERT_QUERY_CONTENT_SERIALIZED_CERT</term>
	/// <term>
	/// This parameter receives a pointer to a CERT_CONTEXT structure. When you have finished using the structure, free it by passing
	/// this pointer to the CertFreeCertificateContext function.
	/// </term>
	/// </item>
	/// <item>
	/// <term>CERT_QUERY_CONTENT_SERIALIZED_CRL</term>
	/// <term>
	/// This parameter receives a pointer to a CRL_CONTEXT structure. When you have finished using the structure, free it by passing
	/// this pointer to the CertFreeCRLContext function.
	/// </term>
	/// </item>
	/// <item>
	/// <term>CERT_QUERY_CONTENT_SERIALIZED_CTL</term>
	/// <term>
	/// This parameter receives a pointer to a CTL_CONTEXT structure. When you have finished using the structure, free it by passing
	/// this pointer to the CertFreeCTLContext function.
	/// </term>
	/// </item>
	/// </list>
	/// <para>If this information is not needed, set this parameter to <c>NULL</c>.</para>
	/// </summary>
	/// <param name="dwObjectType">
	/// <para>Indicates the type of the object to be queried. This must be one of the following values.</para>
	/// <list type="table">
	/// <listheader>
	/// <term>Value</term>
	/// <term>Meaning</term>
	/// </listheader>
	/// <item>
	/// <term>CERT_QUERY_OBJECT_BLOB</term>
	/// <term>The object is stored in a structure in memory.</term>
	/// </item>
	/// <item>
	/// <term>CERT_QUERY_OBJECT_FILE</term>
	/// <term>The object is stored in a file.</term>
	/// </item>
	/// </list>
	/// </param>
	/// <param name="pvObject">
	/// <para>A pointer to the object to be queried. The type of data pointer depends on the contents of the dwObjectType parameter.</para>
	/// <list type="table">
	/// <listheader>
	/// <term>dwObjectType value</term>
	/// <term>Meaning</term>
	/// </listheader>
	/// <item>
	/// <term>CERT_QUERY_OBJECT_BLOB</term>
	/// <term>This parameter is a pointer to a CERT_BLOB, or similar, structure that contains the object to query.</term>
	/// </item>
	/// <item>
	/// <term>CERT_QUERY_OBJECT_FILE</term>
	/// <term>This parameter is a pointer to a null-terminated Unicode string that contains the path and name of the file to query.</term>
	/// </item>
	/// </list>
	/// </param>
	/// <param name="dwExpectedContentTypeFlags">
	/// <para>Indicates the expected content type. This can be one of the following values.</para>
	/// <list type="table">
	/// <listheader>
	/// <term>Value</term>
	/// <term>Meaning</term>
	/// </listheader>
	/// <item>
	/// <term>CERT_QUERY_CONTENT_FLAG_ALL</term>
	/// <term>
	/// The content can be any type. This does not include the CERT_QUERY_CONTENT_FLAG_PFX_AND_LOAD flag. If this flag is specified,
	/// this function will attempt to obtain information about the object, trying different content types until the proper content type
	/// is found or the content types are exhausted. This is obviously inefficient, so this flag should only be used if the content type
	/// is not known.
	/// </term>
	/// </item>
	/// <item>
	/// <term>CERT_QUERY_CONTENT_FLAG_CERT</term>
	/// <term>The content is a single certificate.</term>
	/// </item>
	/// <item>
	/// <term>CERT_QUERY_CONTENT_FLAG_CERT_PAIR</term>
	/// <term>
	/// The content is an Abstract Syntax Notation One (ASN.1) encoded X509_CERT_PAIR (an encoded certificate pair that contains either
	/// forward, reverse, or forward and reverse cross certificates).
	/// </term>
	/// </item>
	/// <item>
	/// <term>CERT_QUERY_CONTENT_FLAG_CRL</term>
	/// <term>The content is a single CRL.</term>
	/// </item>
	/// <item>
	/// <term>CERT_QUERY_CONTENT_FLAG_CTL</term>
	/// <term>The content is a single CTL.</term>
	/// </item>
	/// <item>
	/// <term>CERT_QUERY_CONTENT_FLAG_PFX</term>
	/// <term>
	/// The content is a PFX (PKCS #12) packet, but it will not be loaded by this function. You can use the PFXImportCertStore function
	/// to load this into a store.
	/// </term>
	/// </item>
	/// <item>
	/// <term>CERT_QUERY_CONTENT_FLAG_PFX_AND_LOAD</term>
	/// <term>
	/// The content is a PFX (PKCS #12) packet and will be loaded by this function subject to the conditions specified in the following
	/// note. Windows Server 2003 and Windows XP: This value is not supported.
	/// </term>
	/// </item>
	/// <item>
	/// <term>CERT_QUERY_CONTENT_FLAG_PKCS7_SIGNED</term>
	/// <term>The content is a PKCS #7 signed message.</term>
	/// </item>
	/// <item>
	/// <term>CERT_QUERY_CONTENT_FLAG_PKCS7_SIGNED_EMBED</term>
	/// <term>The content is an embedded PKCS #7 signed message.</term>
	/// </item>
	/// <item>
	/// <term>CERT_QUERY_CONTENT_FLAG_PKCS7_UNSIGNED</term>
	/// <term>The content is a PKCS #7 unsigned message.</term>
	/// </item>
	/// <item>
	/// <term>CERT_QUERY_CONTENT_FLAG_PKCS10</term>
	/// <term>The content is a PKCS #10 message.</term>
	/// </item>
	/// <item>
	/// <term>CERT_QUERY_CONTENT_FLAG_SERIALIZED_CERT</term>
	/// <term>The content is a serialized single certificate.</term>
	/// </item>
	/// <item>
	/// <term>CERT_QUERY_CONTENT_FLAG_SERIALIZED_CRL</term>
	/// <term>The content is a serialized single CRL.</term>
	/// </item>
	/// <item>
	/// <term>CERT_QUERY_CONTENT_FLAG_SERIALIZED_CTL</term>
	/// <term>The content is serialized single CTL.</term>
	/// </item>
	/// <item>
	/// <term>CERT_QUERY_CONTENT_FLAG_SERIALIZED_STORE</term>
	/// <term>The content is a serialized store.</term>
	/// </item>
	/// </list>
	/// </param>
	/// <param name="dwExpectedFormatTypeFlags">
	/// <para>Indicates the expected format of the returned type. This can be one of the following values.</para>
	/// <list type="table">
	/// <listheader>
	/// <term>Value</term>
	/// <term>Meaning</term>
	/// </listheader>
	/// <item>
	/// <term>CERT_QUERY_FORMAT_FLAG_ALL</term>
	/// <term>The content can be returned in any format.</term>
	/// </item>
	/// <item>
	/// <term>CERT_QUERY_FORMAT_FLAG_ASN_ASCII_HEX_ENCODED</term>
	/// <term>The content should be returned in ASCII hex-encoded format with a "{ASN}" prefix.</term>
	/// </item>
	/// <item>
	/// <term>CERT_QUERY_FORMAT_FLAG_BASE64_ENCODED</term>
	/// <term>The content should be returned in Base64 encoded format.</term>
	/// </item>
	/// <item>
	/// <term>CERT_QUERY_FORMAT_FLAG_BINARY</term>
	/// <term>The content should be returned in binary format.</term>
	/// </item>
	/// </list>
	/// </param>
	/// <param name="dwFlags">This parameter is reserved for future use and must be set to zero.</param>
	/// <param name="pdwMsgAndCertEncodingType">
	/// <para>
	/// A pointer to a <c>DWORD</c> value that receives the type of encoding used in the message. If this information is not needed, set
	/// this parameter to <c>NULL</c>.
	/// </para>
	/// <para>This parameter can receives a combination of one or more of the following values.</para>
	/// <list type="table">
	/// <listheader>
	/// <term>Value</term>
	/// <term>Meaning</term>
	/// </listheader>
	/// <item>
	/// <term>PKCS_7_ASN_ENCODING 65536 (0x10000)</term>
	/// <term>Specifies PKCS 7 message encoding.</term>
	/// </item>
	/// <item>
	/// <term>X509_ASN_ENCODING 1 (0x1)</term>
	/// <term>Specifies X.509 certificate encoding.</term>
	/// </item>
	/// </list>
	/// </param>
	/// <param name="pdwContentType">
	/// <para>
	/// A pointer to a <c>DWORD</c> value that receives the actual type of the content. If this information is not needed, set this
	/// parameter to <c>NULL</c>. The returned content type can be one of the following values.
	/// </para>
	/// <list type="table">
	/// <listheader>
	/// <term>Value</term>
	/// <term>Meaning</term>
	/// </listheader>
	/// <item>
	/// <term>CERT_QUERY_CONTENT_CERT</term>
	/// <term>The content is a single certificate.</term>
	/// </item>
	/// <item>
	/// <term>CERT_QUERY_CONTENT_CERT_PAIR</term>
	/// <term>The content is an ASN.1 encoded X509_CERT_pair.</term>
	/// </item>
	/// <item>
	/// <term>CERT_QUERY_CONTENT_CRL</term>
	/// <term>The content is a single CRL.</term>
	/// </item>
	/// <item>
	/// <term>CERT_QUERY_CONTENT_CTL</term>
	/// <term>The content is a single CTL.</term>
	/// </item>
	/// <item>
	/// <term>CERT_QUERY_CONTENT_PFX</term>
	/// <term>
	/// The content is a PFX (PKCS #12) packet. This function only verifies that the object is a PKCS #12 packet. The PKCS #12 packet is
	/// not loaded into a certificate store.
	/// </term>
	/// </item>
	/// <item>
	/// <term>CERT_QUERY_CONTENT_PFX_AND_LOAD</term>
	/// <term>
	/// The content is a PFX (PKCS #12) packet, and it has been loaded into a certificate store. Windows Server 2003 and Windows XP:
	/// This value is not supported.
	/// </term>
	/// </item>
	/// <item>
	/// <term>CERT_QUERY_CONTENT_PKCS7_SIGNED</term>
	/// <term>The content is a PKCS #7 signed message.</term>
	/// </item>
	/// <item>
	/// <term>CERT_QUERY_CONTENT_PKCS7_SIGNED_EMBED</term>
	/// <term>The content is an embedded PKCS #7 signed message.</term>
	/// </item>
	/// <item>
	/// <term>CERT_QUERY_CONTENT_PKCS7_UNSIGNED</term>
	/// <term>The content is a PKCS #7 unsigned message.</term>
	/// </item>
	/// <item>
	/// <term>CERT_QUERY_CONTENT_PKCS10</term>
	/// <term>The content is a PKCS #10 message.</term>
	/// </item>
	/// <item>
	/// <term>CERT_QUERY_CONTENT_SERIALIZED_CERT</term>
	/// <term>The content is a serialized single certificate.</term>
	/// </item>
	/// <item>
	/// <term>CERT_QUERY_CONTENT_SERIALIZED_CRL</term>
	/// <term>The content is a serialized single CRL.</term>
	/// </item>
	/// <item>
	/// <term>CERT_QUERY_CONTENT_SERIALIZED_CTL</term>
	/// <term>The content is a serialized single CTL.</term>
	/// </item>
	/// <item>
	/// <term>CERT_QUERY_CONTENT_SERIALIZED_STORE</term>
	/// <term>The content is a serialized store.</term>
	/// </item>
	/// </list>
	/// </param>
	/// <param name="pdwFormatType">
	/// <para>
	/// A pointer to a <c>DWORD</c> value that receives the actual format type of the content. If this information is not needed, set
	/// this parameter to <c>NULL</c>. The returned format type can be one of the following values.
	/// </para>
	/// <list type="table">
	/// <listheader>
	/// <term>Value</term>
	/// <term>Meaning</term>
	/// </listheader>
	/// <item>
	/// <term>CERT_QUERY_FORMAT_ASN_ASCII_HEX_ENCODED</term>
	/// <term>The content is in ASCII hex-encoded format with an "{ASN}" prefix.</term>
	/// </item>
	/// <item>
	/// <term>CERT_QUERY_FORMAT_BASE64_ENCODED</term>
	/// <term>The content is in Base64 encoded format.</term>
	/// </item>
	/// <item>
	/// <term>CERT_QUERY_FORMAT_BINARY</term>
	/// <term>The content is in binary format.</term>
	/// </item>
	/// </list>
	/// </param>
	/// <param name="phCertStore">
	/// <para>
	/// A pointer to an <c>HCERTSTORE</c> value that receives a handle to a certificate store that includes all of the certificates,
	/// CRLs, and CTLs in the object.
	/// </para>
	/// <para>
	/// This parameter only receives a certificate store handle when the dwContentType parameter receives one of the following values.
	/// This parameter receives <c>NULL</c> for all other content types.
	/// </para>
	/// <para>CERT_QUERY_CONTENT_CERT</para>
	/// <para>CERT_QUERY_CONTENT_CRL</para>
	/// <para>CERT_QUERY_CONTENT_CTL</para>
	/// <para>CERT_QUERY_CONTENT_PFX_AND_LOAD</para>
	/// <para>CERT_QUERY_CONTENT_PKCS7_SIGNED</para>
	/// <para>CERT_QUERY_CONTENT_PKCS7_SIGNED_EMBED</para>
	/// <para>CERT_QUERY_CONTENT_SERIALIZED_CERT</para>
	/// <para>CERT_QUERY_CONTENT_SERIALIZED_CRL</para>
	/// <para>CERT_QUERY_CONTENT_SERIALIZED_CTL</para>
	/// <para>CERT_QUERY_CONTENT_SERIALIZED_STORE</para>
	/// <para>When you have finished using the handle, free it by passing the handle to the CertCloseStore function.</para>
	/// <para>If this information is not needed, set this parameter to <c>NULL</c>.</para>
	/// </param>
	/// <param name="phMsg">
	/// <para>A pointer to an <c>HCRYPTMSG</c> value that receives the handle of an opened message.</para>
	/// <para>
	/// This parameter only receives a message handle when the dwContentType parameter receives one of the following values. This
	/// parameter receives <c>NULL</c> for all other content types.
	/// </para>
	/// <para>CERT_QUERY_CONTENT_PKCS7_SIGNED</para>
	/// <para>CERT_QUERY_CONTENT_PKCS7_SIGNED_EMBED</para>
	/// <para>CERT_QUERY_CONTENT_PKCS7_UNSIGNED</para>
	/// <para>When you have finished using the handle, free it by passing the handle to the CryptMsgClose function.</para>
	/// <para>If this information is not needed, set this parameter to <c>NULL</c>.</para>
	/// </param>
	/// <param name="ppvContext">
	/// <para>A pointer to a pointer that receives additional information about the object.</para>
	/// <para>
	/// The format of this data depends on the value received by the dwContentType parameter. The following table lists the format of
	/// the data for the specified dwContentType value.
	/// </para>
	/// <list type="table">
	/// <listheader>
	/// <term>dwContentType value</term>
	/// <term>Meaning</term>
	/// </listheader>
	/// <item>
	/// <term>CERT_QUERY_CONTENT_CERT</term>
	/// <term>
	/// This parameter receives a pointer to a CERT_CONTEXT structure. When you have finished using the structure, free it by passing
	/// this pointer to the CertFreeCertificateContext function.
	/// </term>
	/// </item>
	/// <item>
	/// <term>CERT_QUERY_CONTENT_CRL</term>
	/// <term>
	/// This parameter receives a pointer to a CRL_CONTEXT structure. When you have finished using the structure, free it by passing
	/// this pointer to the CertFreeCRLContext function.
	/// </term>
	/// </item>
	/// <item>
	/// <term>CERT_QUERY_CONTENT_CTL</term>
	/// <term>
	/// This parameter receives a pointer to a CTL_CONTEXT structure. When you have finished using the structure, free it by passing
	/// this pointer to the CertFreeCTLContext function.
	/// </term>
	/// </item>
	/// <item>
	/// <term>CERT_QUERY_CONTENT_SERIALIZED_CERT</term>
	/// <term>
	/// This parameter receives a pointer to a CERT_CONTEXT structure. When you have finished using the structure, free it by passing
	/// this pointer to the CertFreeCertificateContext function.
	/// </term>
	/// </item>
	/// <item>
	/// <term>CERT_QUERY_CONTENT_SERIALIZED_CRL</term>
	/// <term>
	/// This parameter receives a pointer to a CRL_CONTEXT structure. When you have finished using the structure, free it by passing
	/// this pointer to the CertFreeCRLContext function.
	/// </term>
	/// </item>
	/// <item>
	/// <term>CERT_QUERY_CONTENT_SERIALIZED_CTL</term>
	/// <term>
	/// This parameter receives a pointer to a CTL_CONTEXT structure. When you have finished using the structure, free it by passing
	/// this pointer to the CertFreeCTLContext function.
	/// </term>
	/// </item>
	/// </list>
	/// <para>If this information is not needed, set this parameter to <c>NULL</c>.</para>
	/// </param>
	/// <returns>
	/// <para>If the function succeeds, the function returns nonzero.</para>
	/// <para>If the function fails, it returns zero. For extended error information, call GetLastError.</para>
	/// </returns>
	// https://docs.microsoft.com/en-us/windows/win32/api/wincrypt/nf-wincrypt-cryptqueryobject BOOL CryptQueryObject( DWORD
	// dwObjectType, const void *pvObject, DWORD dwExpectedContentTypeFlags, DWORD dwExpectedFormatTypeFlags, DWORD dwFlags, DWORD
	// *pdwMsgAndCertEncodingType, DWORD *pdwContentType, DWORD *pdwFormatType, HCERTSTORE *phCertStore, HCRYPTMSG *phMsg, const void
	// **ppvContext );
	[DllImport(Lib.Crypt32, SetLastError = true, ExactSpelling = true)]
	[PInvokeData("wincrypt.h", MSDNShortId = "d882f2b0-0f0a-41c7-afca-a232dc00797b")]
	[return: MarshalAs(UnmanagedType.Bool)]
	public static extern bool CryptQueryObject(CertQueryObjectType dwObjectType, [In] IntPtr pvObject, CertQueryContentFlags dwExpectedContentTypeFlags, CertQueryFormatFlags dwExpectedFormatTypeFlags,
		[Optional] uint dwFlags, out CertEncodingType pdwMsgAndCertEncodingType, out CertQueryContentType pdwContentType, out CertQueryFormatType pdwFormatType, out SafeHCERTSTORE phCertStore,
		out SafeHCRYPTMSG phMsg, out SafePCCTL_CONTEXT ppvContext);

	/// <summary>
	/// <para>
	/// The <c>CryptSignAndEncodeCertificate</c> function encodes and signs a certificate, certificate revocation list (CRL),
	/// certificate trust list (CTL), or certificate request.
	/// </para>
	/// <para>This function performs the following operations:</para>
	/// <list type="bullet">
	/// <item>
	/// <term>Calls CryptEncodeObject using lpszStructType to encode the "to be signed" information.</term>
	/// </item>
	/// <item>
	/// <term>Calls CryptSignCertificate to sign this encoded information.</term>
	/// </item>
	/// <item>
	/// <term>Calls CryptEncodeObject again, with lpszStructType set to X509_CERT, to further encode the resulting signed, encoded information.</term>
	/// </item>
	/// </list>
	/// </summary>
	/// <param name="hBCryptKey">
	/// A handle of the cryptographic service provider (CSP) to do the signature. This handle is an HCRYPTPROV handle that has been
	/// created by using the CryptAcquireContext function or an <c>NCRYPT_KEY_HANDLE</c> handle that has been created by using the
	/// NCryptOpenKey function. New applications should always pass in a <c>NCRYPT_KEY_HANDLE</c> handle of a CNG CSP.
	/// </param>
	/// <param name="dwKeySpec">
	/// <para>
	/// Identifies the private key to use from the provider's container. This must be one of the following values. This parameter is
	/// ignored if a CNG key is passed in the hCryptProvOrNCryptKey parameter.
	/// </para>
	/// <list type="table">
	/// <listheader>
	/// <term>Value</term>
	/// <term>Meaning</term>
	/// </listheader>
	/// <item>
	/// <term>AT_KEYEXCHANGE</term>
	/// <term>Use the key exchange key.</term>
	/// </item>
	/// <item>
	/// <term>AT_SIGNATURE</term>
	/// <term>Use the digital signature key.</term>
	/// </item>
	/// </list>
	/// </param>
	/// <param name="dwCertEncodingType">
	/// <para>Specifies the encoding type used. This can be the following value.</para>
	/// <list type="table">
	/// <listheader>
	/// <term>Value</term>
	/// <term>Meaning</term>
	/// </listheader>
	/// <item>
	/// <term>X509_ASN_ENCODING</term>
	/// <term>Specifies X.509 certificate encoding.</term>
	/// </item>
	/// </list>
	/// </param>
	/// <param name="lpszStructType">
	/// <para>
	/// A pointer to a null-terminated ANSI string that contains the type of data to be encoded and signed. The following predefined
	/// lpszStructType constants are used with encode operations.
	/// </para>
	/// <list type="table">
	/// <listheader>
	/// <term>Value</term>
	/// <term>Meaning</term>
	/// </listheader>
	/// <item>
	/// <term>X509_CERT_CRL_TO_BE_SIGNED</term>
	/// <term>pvStructInfo is the address of a CRL_INFO structure.</term>
	/// </item>
	/// <item>
	/// <term>X509_CERT_REQUEST_TO_BE_SIGNED</term>
	/// <term>pvStructInfo is the address of a CERT_REQUEST_INFO structure.</term>
	/// </item>
	/// <item>
	/// <term>X509_CERT_TO_BE_SIGNED</term>
	/// <term>pvStructInfo is the address of a CERT_INFO structure.</term>
	/// </item>
	/// <item>
	/// <term>X509_KEYGEN_REQUEST_TO_BE_SIGNED</term>
	/// <term>pvStructInfo is the address of a CERT_KEYGEN_REQUEST_INFO structure.</term>
	/// </item>
	/// </list>
	/// </param>
	/// <param name="pvStructInfo">
	/// The address of a structure that contains the data to be signed and encoded. The format of this structure is determined by the
	/// lpszStructType parameter.
	/// </param>
	/// <param name="pSignatureAlgorithm">
	/// <para>
	/// A pointer to a CRYPT_ALGORITHM_IDENTIFIER structure that contains the object identifier (OID) of the signature algorithm and any
	/// additional parameters needed. This function uses the following algorithm OIDs:
	/// </para>
	/// <list type="bullet">
	/// <item>
	/// <term>szOID_RSA_MD5RSA</term>
	/// </item>
	/// <item>
	/// <term>szOID_RSA_SHA1RSA</term>
	/// </item>
	/// <item>
	/// <term>szOID_X957_SHA1DSA</term>
	/// </item>
	/// </list>
	/// <para>If the signature algorithm is a</para>
	/// <para>hash</para>
	/// <para>algorithm, the signature contains only the unencrypted hash octets. A private key is not used to encrypt the hash.</para>
	/// <para>dwKeySpec</para>
	/// <para>is not used and</para>
	/// <para>hCryptProvOrNCryptKey</para>
	/// <para>can be</para>
	/// <para>NULL</para>
	/// <para>if an appropriate default CSP can be used for hashing.</para>
	/// </param>
	/// <param name="pvHashAuxInfo">Reserved. Must be <c>NULL</c>.</param>
	/// <param name="pbEncoded">
	/// <para>A pointer to a buffer to receive the signed and encoded output.</para>
	/// <para>
	/// This parameter can be <c>NULL</c> to set the size of this information for memory allocation purposes. For more information, see
	/// Retrieving Data of Unknown Length.
	/// </para>
	/// </param>
	/// <param name="pcbEncoded">
	/// <para>
	/// A pointer to a <c>DWORD</c> that contains the size, in bytes, of the buffer pointed to by the pbEncoded parameter. When the
	/// function returns, the <c>DWORD</c> contains the number of bytes stored or to be stored in the buffer.
	/// </para>
	/// <para>
	/// <c>Note</c> When processing the data returned in the buffer, applications need to use the actual size of the data returned. The
	/// actual size can be slightly smaller than the size of the buffer specified on input. (On input, buffer sizes are usually
	/// specified large enough to ensure that the largest possible output data will fit in the buffer.) On output, the variable pointed
	/// to by this parameter is updated to reflect the actual size of the data copied to the buffer.
	/// </para>
	/// </param>
	/// <returns>
	/// <para>If the function succeeds, the return value is nonzero ( <c>TRUE</c>).</para>
	/// <para>If the function fails, the return value is zero ( <c>FALSE</c>). For extended error information, call GetLastError.</para>
	/// <para>
	/// <c>Note</c> Errors from the called functions CryptCreateHash, CryptSignHash and CryptHashData might be propagated to this function.
	/// </para>
	/// <para>Possible error codes include, but are not limited to, the following.</para>
	/// <list type="table">
	/// <listheader>
	/// <term>Return code</term>
	/// <term>Description</term>
	/// </listheader>
	/// <item>
	/// <term>ERROR_MORE_DATA</term>
	/// <term>
	/// If the buffer specified by the pbEncoded parameter is not large enough to hold the returned data, the function sets the
	/// ERROR_MORE_DATA code and stores the required buffer size, in bytes, into the variable pointed to by pcbEncoded.
	/// </term>
	/// </item>
	/// <item>
	/// <term>ERROR_FILE_NOT_FOUND</term>
	/// <term>Invalid certificate encoding type. Currently only X509_ASN_ENCODING is supported.</term>
	/// </item>
	/// <item>
	/// <term>NTE_BAD_ALGID</term>
	/// <term>The signature algorithm's OID does not map to a known or supported hash algorithm.</term>
	/// </item>
	/// <item>
	/// <term>CRYPT_E_BAD_ENCODE</term>
	/// <term>
	/// An error was encountered while encoding or decoding. The most likely cause of this error is the improper initialization of the
	/// fields in the structure pointed to by pvStructInfo.
	/// </term>
	/// </item>
	/// </list>
	/// <para>
	/// If the function fails, GetLastError may return an Abstract Syntax Notation One (ASN.1) encoding/decoding error. For information
	/// about these errors, see ASN.1 Encoding/Decoding Return Values.
	/// </para>
	/// </returns>
	// https://docs.microsoft.com/en-us/windows/win32/api/wincrypt/nf-wincrypt-cryptsignandencodecertificate BOOL
	// CryptSignAndEncodeCertificate( BCRYPT_KEY_HANDLE hBCryptKey, DWORD dwKeySpec, DWORD dwCertEncodingType, LPCSTR lpszStructType,
	// const void *pvStructInfo, PCRYPT_ALGORITHM_IDENTIFIER pSignatureAlgorithm, const void *pvHashAuxInfo, BYTE *pbEncoded, DWORD
	// *pcbEncoded );
	[DllImport(Lib.Crypt32, SetLastError = true, ExactSpelling = true)]
	[PInvokeData("wincrypt.h", MSDNShortId = "ee138918-ed7c-4980-8b18-64004a0dd7df")]
	[return: MarshalAs(UnmanagedType.Bool)]
	public static extern bool CryptSignAndEncodeCertificate(NCrypt.NCRYPT_KEY_HANDLE hBCryptKey, CertKeySpec dwKeySpec, CertEncodingType dwCertEncodingType,
		[In] SafeOID lpszStructType, [In] IntPtr pvStructInfo, in CRYPT_ALGORITHM_IDENTIFIER pSignatureAlgorithm,
		[In, Optional] IntPtr pvHashAuxInfo, [Out] IntPtr pbEncoded, ref uint pcbEncoded);

	/// <summary>
	/// <para>
	/// The <c>CryptSignAndEncodeCertificate</c> function encodes and signs a certificate, certificate revocation list (CRL),
	/// certificate trust list (CTL), or certificate request.
	/// </para>
	/// <para>This function performs the following operations:</para>
	/// <list type="bullet">
	/// <item>
	/// <term>Calls CryptEncodeObject using lpszStructType to encode the "to be signed" information.</term>
	/// </item>
	/// <item>
	/// <term>Calls CryptSignCertificate to sign this encoded information.</term>
	/// </item>
	/// <item>
	/// <term>Calls CryptEncodeObject again, with lpszStructType set to X509_CERT, to further encode the resulting signed, encoded information.</term>
	/// </item>
	/// </list>
	/// </summary>
	/// <param name="hBCryptKey">
	/// A handle of the cryptographic service provider (CSP) to do the signature. This handle is an HCRYPTPROV handle that has been
	/// created by using the CryptAcquireContext function or an <c>NCRYPT_KEY_HANDLE</c> handle that has been created by using the
	/// NCryptOpenKey function. New applications should always pass in a <c>NCRYPT_KEY_HANDLE</c> handle of a CNG CSP.
	/// </param>
	/// <param name="dwKeySpec">
	/// <para>
	/// Identifies the private key to use from the provider's container. This must be one of the following values. This parameter is
	/// ignored if a CNG key is passed in the hCryptProvOrNCryptKey parameter.
	/// </para>
	/// <list type="table">
	/// <listheader>
	/// <term>Value</term>
	/// <term>Meaning</term>
	/// </listheader>
	/// <item>
	/// <term>AT_KEYEXCHANGE</term>
	/// <term>Use the key exchange key.</term>
	/// </item>
	/// <item>
	/// <term>AT_SIGNATURE</term>
	/// <term>Use the digital signature key.</term>
	/// </item>
	/// </list>
	/// </param>
	/// <param name="dwCertEncodingType">
	/// <para>Specifies the encoding type used. This can be the following value.</para>
	/// <list type="table">
	/// <listheader>
	/// <term>Value</term>
	/// <term>Meaning</term>
	/// </listheader>
	/// <item>
	/// <term>X509_ASN_ENCODING</term>
	/// <term>Specifies X.509 certificate encoding.</term>
	/// </item>
	/// </list>
	/// </param>
	/// <param name="lpszStructType">
	/// <para>
	/// A pointer to a null-terminated ANSI string that contains the type of data to be encoded and signed. The following predefined
	/// lpszStructType constants are used with encode operations.
	/// </para>
	/// <list type="table">
	/// <listheader>
	/// <term>Value</term>
	/// <term>Meaning</term>
	/// </listheader>
	/// <item>
	/// <term>X509_CERT_CRL_TO_BE_SIGNED</term>
	/// <term>pvStructInfo is the address of a CRL_INFO structure.</term>
	/// </item>
	/// <item>
	/// <term>X509_CERT_REQUEST_TO_BE_SIGNED</term>
	/// <term>pvStructInfo is the address of a CERT_REQUEST_INFO structure.</term>
	/// </item>
	/// <item>
	/// <term>X509_CERT_TO_BE_SIGNED</term>
	/// <term>pvStructInfo is the address of a CERT_INFO structure.</term>
	/// </item>
	/// <item>
	/// <term>X509_KEYGEN_REQUEST_TO_BE_SIGNED</term>
	/// <term>pvStructInfo is the address of a CERT_KEYGEN_REQUEST_INFO structure.</term>
	/// </item>
	/// </list>
	/// </param>
	/// <param name="pvStructInfo">
	/// The address of a structure that contains the data to be signed and encoded. The format of this structure is determined by the
	/// lpszStructType parameter.
	/// </param>
	/// <param name="pSignatureAlgorithm">
	/// <para>
	/// A pointer to a CRYPT_ALGORITHM_IDENTIFIER structure that contains the object identifier (OID) of the signature algorithm and any
	/// additional parameters needed. This function uses the following algorithm OIDs:
	/// </para>
	/// <list type="bullet">
	/// <item>
	/// <term>szOID_RSA_MD5RSA</term>
	/// </item>
	/// <item>
	/// <term>szOID_RSA_SHA1RSA</term>
	/// </item>
	/// <item>
	/// <term>szOID_X957_SHA1DSA</term>
	/// </item>
	/// </list>
	/// <para>If the signature algorithm is a</para>
	/// <para>hash</para>
	/// <para>algorithm, the signature contains only the unencrypted hash octets. A private key is not used to encrypt the hash.</para>
	/// <para>dwKeySpec</para>
	/// <para>is not used and</para>
	/// <para>hCryptProvOrNCryptKey</para>
	/// <para>can be</para>
	/// <para>NULL</para>
	/// <para>if an appropriate default CSP can be used for hashing.</para>
	/// </param>
	/// <param name="pvHashAuxInfo">Reserved. Must be <c>NULL</c>.</param>
	/// <param name="pbEncoded">
	/// <para>A pointer to a buffer to receive the signed and encoded output.</para>
	/// <para>
	/// This parameter can be <c>NULL</c> to set the size of this information for memory allocation purposes. For more information, see
	/// Retrieving Data of Unknown Length.
	/// </para>
	/// </param>
	/// <param name="pcbEncoded">
	/// <para>
	/// A pointer to a <c>DWORD</c> that contains the size, in bytes, of the buffer pointed to by the pbEncoded parameter. When the
	/// function returns, the <c>DWORD</c> contains the number of bytes stored or to be stored in the buffer.
	/// </para>
	/// <para>
	/// <c>Note</c> When processing the data returned in the buffer, applications need to use the actual size of the data returned. The
	/// actual size can be slightly smaller than the size of the buffer specified on input. (On input, buffer sizes are usually
	/// specified large enough to ensure that the largest possible output data will fit in the buffer.) On output, the variable pointed
	/// to by this parameter is updated to reflect the actual size of the data copied to the buffer.
	/// </para>
	/// </param>
	/// <returns>
	/// <para>If the function succeeds, the return value is nonzero ( <c>TRUE</c>).</para>
	/// <para>If the function fails, the return value is zero ( <c>FALSE</c>). For extended error information, call GetLastError.</para>
	/// <para>
	/// <c>Note</c> Errors from the called functions CryptCreateHash, CryptSignHash and CryptHashData might be propagated to this function.
	/// </para>
	/// <para>Possible error codes include, but are not limited to, the following.</para>
	/// <list type="table">
	/// <listheader>
	/// <term>Return code</term>
	/// <term>Description</term>
	/// </listheader>
	/// <item>
	/// <term>ERROR_MORE_DATA</term>
	/// <term>
	/// If the buffer specified by the pbEncoded parameter is not large enough to hold the returned data, the function sets the
	/// ERROR_MORE_DATA code and stores the required buffer size, in bytes, into the variable pointed to by pcbEncoded.
	/// </term>
	/// </item>
	/// <item>
	/// <term>ERROR_FILE_NOT_FOUND</term>
	/// <term>Invalid certificate encoding type. Currently only X509_ASN_ENCODING is supported.</term>
	/// </item>
	/// <item>
	/// <term>NTE_BAD_ALGID</term>
	/// <term>The signature algorithm's OID does not map to a known or supported hash algorithm.</term>
	/// </item>
	/// <item>
	/// <term>CRYPT_E_BAD_ENCODE</term>
	/// <term>
	/// An error was encountered while encoding or decoding. The most likely cause of this error is the improper initialization of the
	/// fields in the structure pointed to by pvStructInfo.
	/// </term>
	/// </item>
	/// </list>
	/// <para>
	/// If the function fails, GetLastError may return an Abstract Syntax Notation One (ASN.1) encoding/decoding error. For information
	/// about these errors, see ASN.1 Encoding/Decoding Return Values.
	/// </para>
	/// </returns>
	// https://docs.microsoft.com/en-us/windows/win32/api/wincrypt/nf-wincrypt-cryptsignandencodecertificate BOOL
	// CryptSignAndEncodeCertificate( BCRYPT_KEY_HANDLE hBCryptKey, DWORD dwKeySpec, DWORD dwCertEncodingType, LPCSTR lpszStructType,
	// const void *pvStructInfo, PCRYPT_ALGORITHM_IDENTIFIER pSignatureAlgorithm, const void *pvHashAuxInfo, BYTE *pbEncoded, DWORD
	// *pcbEncoded );
	[DllImport(Lib.Crypt32, SetLastError = true, ExactSpelling = true)]
	[PInvokeData("wincrypt.h", MSDNShortId = "ee138918-ed7c-4980-8b18-64004a0dd7df")]
	[return: MarshalAs(UnmanagedType.Bool)]
	public static extern bool CryptSignAndEncodeCertificate(HCRYPTPROV hBCryptKey, CertKeySpec dwKeySpec, CertEncodingType dwCertEncodingType,
		[In] SafeOID lpszStructType, [In] IntPtr pvStructInfo, in CRYPT_ALGORITHM_IDENTIFIER pSignatureAlgorithm,
		[In, Optional] IntPtr pvHashAuxInfo, [Out] IntPtr pbEncoded, ref uint pcbEncoded);

	/// <summary>The <c>CryptSignCertificate</c> function signs the "to be signed" information in the encoded signed content.</summary>
	/// <param name="hBCryptKey">
	/// Handle of the CSP that does the signature. This handle must be an HCRYPTPROV handle that has been created by using the
	/// CryptAcquireContext function or an <c>NCRYPT_KEY_HANDLE</c> handle that has been created by using the NCryptOpenKey function.
	/// New applications should always pass in the <c>NCRYPT_KEY_HANDLE</c> handle of a CNG CSP.
	/// </param>
	/// <param name="dwKeySpec">
	/// Identifies the private key to use from the provider's container. It can be AT_KEYEXCHANGE or AT_SIGNATURE. This parameter is
	/// ignored if an <c>NCRYPT_KEY_HANDLE</c> is used in the hCryptProvOrNCryptKey parameter.
	/// </param>
	/// <param name="dwCertEncodingType">
	/// <para>
	/// Specifies the encoding type used. It is always acceptable to specify both the certificate and message encoding types by
	/// combining them with a bitwise- <c>OR</c> operation as shown in the following example:
	/// </para>
	/// <para>X509_ASN_ENCODING | PKCS_7_ASN_ENCODING</para>
	/// <para>Currently defined encoding types are:</para>
	/// <list type="bullet">
	/// <item>
	/// <term>X509_ASN_ENCODING</term>
	/// </item>
	/// <item>
	/// <term>PKCS_7_ASN_ENCODING</term>
	/// </item>
	/// </list>
	/// </param>
	/// <param name="pbEncodedToBeSigned">A pointer to the encoded content to be signed.</param>
	/// <param name="cbEncodedToBeSigned">The size, in bytes, of the encoded content, pbEncodedToBeSigned.</param>
	/// <param name="pSignatureAlgorithm">
	/// <para>A pointer to a CRYPT_ALGORITHM_IDENTIFIER structure with a <c>pszObjId</c> member set to one of the following:</para>
	/// <list type="bullet">
	/// <item>
	/// <term>szOID_RSA_MD5RSA</term>
	/// </item>
	/// <item>
	/// <term>szOID_RSA_SHA1RSA</term>
	/// </item>
	/// <item>
	/// <term>szOID_X957_SHA1DSA</term>
	/// </item>
	/// <item>
	/// <term>szOID_RSA_SSA_PSS</term>
	/// </item>
	/// <item>
	/// <term>szOID_ECDSA_SPECIFIED</term>
	/// </item>
	/// </list>
	/// <para>
	/// If the signature algorithm is a hash algorithm, the signature contains only the un-encrypted hash octets. A private key is not
	/// used to encrypt the hash.
	/// </para>
	/// <para>dwKeySpec</para>
	/// <para>is not used and</para>
	/// <para>hCryptProvOrNCryptKey</para>
	/// <para>can be</para>
	/// <para>NULL</para>
	/// <para>if an appropriate default CSP can be used for hashing.</para>
	/// </param>
	/// <param name="pvHashAuxInfo">Not currently used. Must be <c>NULL</c>.</param>
	/// <param name="pbSignature">
	/// <para>A pointer to a buffer to receive the signed hash of the content.</para>
	/// <para>
	/// This parameter can be <c>NULL</c> to set the size of this information for memory allocation purposes. For more information, see
	/// Retrieving Data of Unknown Length.
	/// </para>
	/// </param>
	/// <param name="pcbSignature">
	/// <para>
	/// A pointer to a <c>DWORD</c> that contains the size, in bytes, of the buffer pointed to by the pbSignature parameter. When the
	/// function returns, the <c>DWORD</c> contains the number of bytes stored or to be stored in the buffer.
	/// </para>
	/// <para>
	/// <c>Note</c> When processing the data returned in the buffer, applications must use the actual size of the data returned. The
	/// actual size can be slightly smaller than the size of the buffer specified on input. (On input, buffer sizes are usually
	/// specified large enough to ensure that the largest possible output data will fit in the buffer.) On output, the variable pointed
	/// to by this parameter is updated to reflect the actual size of the data copied to the buffer.
	/// </para>
	/// </param>
	/// <returns>
	/// <para>If the function succeeds, the return value is nonzero ( <c>TRUE</c>).</para>
	/// <para>If the function fails, the return value is zero ( <c>FALSE</c>). For extended error information, call GetLastError.</para>
	/// <para>
	/// <c>Note</c> Errors from the called functions CryptCreateHash, CryptSignHash and CryptHashData might be propagated to this function.
	/// </para>
	/// <para>This function has the following error codes.</para>
	/// <list type="table">
	/// <listheader>
	/// <term>Return code</term>
	/// <term>Description</term>
	/// </listheader>
	/// <item>
	/// <term>ERROR_MORE_DATA</term>
	/// <term>
	/// If the buffer specified by the pbSignature parameter is not large enough to hold the returned data, the function sets the
	/// ERROR_MORE_DATA code, and stores the required buffer size, in bytes, into the variable pointed to by pcbSignature.
	/// </term>
	/// </item>
	/// <item>
	/// <term>NTE_BAD_ALGID</term>
	/// <term>The signature algorithm's object identifier (OID) does not map to a known or supported hash algorithm.</term>
	/// </item>
	/// </list>
	/// </returns>
	// https://docs.microsoft.com/en-us/windows/win32/api/wincrypt/nf-wincrypt-cryptsigncertificate BOOL CryptSignCertificate(
	// BCRYPT_KEY_HANDLE hBCryptKey, DWORD dwKeySpec, DWORD dwCertEncodingType, const BYTE *pbEncodedToBeSigned, DWORD
	// cbEncodedToBeSigned, PCRYPT_ALGORITHM_IDENTIFIER pSignatureAlgorithm, const void *pvHashAuxInfo, BYTE *pbSignature, DWORD
	// *pcbSignature );
	[DllImport(Lib.Crypt32, SetLastError = true, ExactSpelling = true)]
	[PInvokeData("wincrypt.h", MSDNShortId = "27578149-e5c0-47e5-8309-0d0ed7075d13")]
	[return: MarshalAs(UnmanagedType.Bool)]
	public static extern bool CryptSignCertificate(NCrypt.NCRYPT_KEY_HANDLE hBCryptKey, CertKeySpec dwKeySpec, CertEncodingType dwCertEncodingType,
		[In] IntPtr pbEncodedToBeSigned, uint cbEncodedToBeSigned, in CRYPT_ALGORITHM_IDENTIFIER pSignatureAlgorithm, [In, Optional] IntPtr pvHashAuxInfo,
		[Out] IntPtr pbSignature, ref uint pcbSignature);

	/// <summary>The <c>CryptSignCertificate</c> function signs the "to be signed" information in the encoded signed content.</summary>
	/// <param name="hBCryptKey">
	/// Handle of the CSP that does the signature. This handle must be an HCRYPTPROV handle that has been created by using the
	/// CryptAcquireContext function or an <c>NCRYPT_KEY_HANDLE</c> handle that has been created by using the NCryptOpenKey function.
	/// New applications should always pass in the <c>NCRYPT_KEY_HANDLE</c> handle of a CNG CSP.
	/// </param>
	/// <param name="dwKeySpec">
	/// Identifies the private key to use from the provider's container. It can be AT_KEYEXCHANGE or AT_SIGNATURE. This parameter is
	/// ignored if an <c>NCRYPT_KEY_HANDLE</c> is used in the hCryptProvOrNCryptKey parameter.
	/// </param>
	/// <param name="dwCertEncodingType">
	/// <para>
	/// Specifies the encoding type used. It is always acceptable to specify both the certificate and message encoding types by
	/// combining them with a bitwise- <c>OR</c> operation as shown in the following example:
	/// </para>
	/// <para>X509_ASN_ENCODING | PKCS_7_ASN_ENCODING</para>
	/// <para>Currently defined encoding types are:</para>
	/// <list type="bullet">
	/// <item>
	/// <term>X509_ASN_ENCODING</term>
	/// </item>
	/// <item>
	/// <term>PKCS_7_ASN_ENCODING</term>
	/// </item>
	/// </list>
	/// </param>
	/// <param name="pbEncodedToBeSigned">A pointer to the encoded content to be signed.</param>
	/// <param name="cbEncodedToBeSigned">The size, in bytes, of the encoded content, pbEncodedToBeSigned.</param>
	/// <param name="pSignatureAlgorithm">
	/// <para>A pointer to a CRYPT_ALGORITHM_IDENTIFIER structure with a <c>pszObjId</c> member set to one of the following:</para>
	/// <list type="bullet">
	/// <item>
	/// <term>szOID_RSA_MD5RSA</term>
	/// </item>
	/// <item>
	/// <term>szOID_RSA_SHA1RSA</term>
	/// </item>
	/// <item>
	/// <term>szOID_X957_SHA1DSA</term>
	/// </item>
	/// <item>
	/// <term>szOID_RSA_SSA_PSS</term>
	/// </item>
	/// <item>
	/// <term>szOID_ECDSA_SPECIFIED</term>
	/// </item>
	/// </list>
	/// <para>
	/// If the signature algorithm is a hash algorithm, the signature contains only the un-encrypted hash octets. A private key is not
	/// used to encrypt the hash.
	/// </para>
	/// <para>dwKeySpec</para>
	/// <para>is not used and</para>
	/// <para>hCryptProvOrNCryptKey</para>
	/// <para>can be</para>
	/// <para>NULL</para>
	/// <para>if an appropriate default CSP can be used for hashing.</para>
	/// </param>
	/// <param name="pvHashAuxInfo">Not currently used. Must be <c>NULL</c>.</param>
	/// <param name="pbSignature">
	/// <para>A pointer to a buffer to receive the signed hash of the content.</para>
	/// <para>
	/// This parameter can be <c>NULL</c> to set the size of this information for memory allocation purposes. For more information, see
	/// Retrieving Data of Unknown Length.
	/// </para>
	/// </param>
	/// <param name="pcbSignature">
	/// <para>
	/// A pointer to a <c>DWORD</c> that contains the size, in bytes, of the buffer pointed to by the pbSignature parameter. When the
	/// function returns, the <c>DWORD</c> contains the number of bytes stored or to be stored in the buffer.
	/// </para>
	/// <para>
	/// <c>Note</c> When processing the data returned in the buffer, applications must use the actual size of the data returned. The
	/// actual size can be slightly smaller than the size of the buffer specified on input. (On input, buffer sizes are usually
	/// specified large enough to ensure that the largest possible output data will fit in the buffer.) On output, the variable pointed
	/// to by this parameter is updated to reflect the actual size of the data copied to the buffer.
	/// </para>
	/// </param>
	/// <returns>
	/// <para>If the function succeeds, the return value is nonzero ( <c>TRUE</c>).</para>
	/// <para>If the function fails, the return value is zero ( <c>FALSE</c>). For extended error information, call GetLastError.</para>
	/// <para>
	/// <c>Note</c> Errors from the called functions CryptCreateHash, CryptSignHash and CryptHashData might be propagated to this function.
	/// </para>
	/// <para>This function has the following error codes.</para>
	/// <list type="table">
	/// <listheader>
	/// <term>Return code</term>
	/// <term>Description</term>
	/// </listheader>
	/// <item>
	/// <term>ERROR_MORE_DATA</term>
	/// <term>
	/// If the buffer specified by the pbSignature parameter is not large enough to hold the returned data, the function sets the
	/// ERROR_MORE_DATA code, and stores the required buffer size, in bytes, into the variable pointed to by pcbSignature.
	/// </term>
	/// </item>
	/// <item>
	/// <term>NTE_BAD_ALGID</term>
	/// <term>The signature algorithm's object identifier (OID) does not map to a known or supported hash algorithm.</term>
	/// </item>
	/// </list>
	/// </returns>
	// https://docs.microsoft.com/en-us/windows/win32/api/wincrypt/nf-wincrypt-cryptsigncertificate BOOL CryptSignCertificate(
	// BCRYPT_KEY_HANDLE hBCryptKey, DWORD dwKeySpec, DWORD dwCertEncodingType, const BYTE *pbEncodedToBeSigned, DWORD
	// cbEncodedToBeSigned, PCRYPT_ALGORITHM_IDENTIFIER pSignatureAlgorithm, const void *pvHashAuxInfo, BYTE *pbSignature, DWORD
	// *pcbSignature );
	[DllImport(Lib.Crypt32, SetLastError = true, ExactSpelling = true)]
	[PInvokeData("wincrypt.h", MSDNShortId = "27578149-e5c0-47e5-8309-0d0ed7075d13")]
	[return: MarshalAs(UnmanagedType.Bool)]
	public static extern bool CryptSignCertificate(HCRYPTPROV hBCryptKey, CertKeySpec dwKeySpec, CertEncodingType dwCertEncodingType,
		[In] IntPtr pbEncodedToBeSigned, uint cbEncodedToBeSigned, in CRYPT_ALGORITHM_IDENTIFIER pSignatureAlgorithm, [In, Optional] IntPtr pvHashAuxInfo,
		[Out] IntPtr pbSignature, ref uint pcbSignature);

	/// <summary>
	/// The <c>CryptVerifyCertificateSignature</c> function verifies the signature of a certificate, certificate revocation list (CRL),
	/// or certificate request by using the public key in a CERT_PUBLIC_KEY_INFO structure. The function does not require access to a
	/// private key.
	/// </summary>
	/// <param name="hCryptProv">
	/// <para>This parameter is not used and should be set to <c>NULL</c>.</para>
	/// <para>
	/// <c>Windows Server 2003 and Windows XP:</c> A handle to the cryptographic service provider (CSP) used to verify the
	/// signature.This parameter's data type is <c>HCRYPTPROV</c>.
	/// </para>
	/// <para>
	/// <c>NULL</c> is passed unless there is a strong reason for passing in a specific cryptographic provider. Passing in <c>NULL</c>
	/// causes the default RSA or DSS provider to be acquired.
	/// </para>
	/// </param>
	/// <param name="dwCertEncodingType">
	/// <para>
	/// The certificate encoding type that was used to encrypt the subject. The message encoding type identifier, contained in the high
	/// <c>WORD</c> of this value, is ignored by this function.
	/// </para>
	/// <para>This parameter can be the following currently defined certificate encoding type.</para>
	/// <list type="table">
	/// <listheader>
	/// <term>Value</term>
	/// <term>Meaning</term>
	/// </listheader>
	/// <item>
	/// <term>X509_ASN_ENCODING 1 (0x1)</term>
	/// <term>Specifies X.509 certificate encoding.</term>
	/// </item>
	/// </list>
	/// </param>
	/// <param name="pbEncoded">A pointer to an encoded BLOB of CERT_SIGNED_CONTENT_INFO content on which the signature is to be verified.</param>
	/// <param name="cbEncoded">The size, in bytes, of the encoded content in pbEncoded.</param>
	/// <param name="pPublicKey">
	/// A pointer to a CERT_PUBLIC_KEY_INFO structure that contains the public key to use when verifying the signature.
	/// </param>
	/// <returns>
	/// <para>Returns nonzero if successful or zero otherwise.</para>
	/// <para>For extended error information, call GetLastError.</para>
	/// <para>
	/// <c>Note</c> Errors from the called functions CryptCreateHash, CryptImportKey, CryptVerifySignature, and CryptHashData may be
	/// propagated to this function.
	/// </para>
	/// <para>On failure, this function will cause the following error codes to be returned from GetLastError.</para>
	/// <list type="table">
	/// <listheader>
	/// <term>Return code</term>
	/// <term>Description</term>
	/// </listheader>
	/// <item>
	/// <term>ERROR_FILE_NOT_FOUND</term>
	/// <term>Invalid certificate encoding type. Currently only X509_ASN_ENCODING is supported.</term>
	/// </item>
	/// <item>
	/// <term>NTE_BAD_ALGID</term>
	/// <term>The signature algorithm's object identifier (OID) does not map to a known or supported hash algorithm.</term>
	/// </item>
	/// <item>
	/// <term>NTE_BAD_SIGNATURE</term>
	/// <term>The signature was not valid.</term>
	/// </item>
	/// </list>
	/// <para>
	/// If the function fails, GetLastError may return an Abstract Syntax Notation One (ASN.1) encoding/decoding error. For information
	/// about these errors, see ASN.1 Encoding/Decoding Return Values.
	/// </para>
	/// </returns>
	/// <remarks>This function currently calls the CryptVerifyCertificateSignatureEx function to perform the verification.</remarks>
	// https://docs.microsoft.com/en-us/windows/win32/api/wincrypt/nf-wincrypt-cryptverifycertificatesignature BOOL
	// CryptVerifyCertificateSignature( HCRYPTPROV_LEGACY hCryptProv, DWORD dwCertEncodingType, const BYTE *pbEncoded, DWORD cbEncoded,
	// PCERT_PUBLIC_KEY_INFO pPublicKey );
	[DllImport(Lib.Crypt32, SetLastError = true, ExactSpelling = true)]
	[PInvokeData("wincrypt.h", MSDNShortId = "ac13a1dd-3ca9-470e-8d8f-d79d7d057f45")]
	[return: MarshalAs(UnmanagedType.Bool)]
	public static extern bool CryptVerifyCertificateSignature([Optional] HCRYPTPROV hCryptProv, CertEncodingType dwCertEncodingType, [In] IntPtr pbEncoded, uint cbEncoded, in CERT_PUBLIC_KEY_INFO pPublicKey);

	/// <summary>
	/// The <c>CryptVerifyCertificateSignatureEx</c> function verifies the signature of a subject certificate, certificate revocation
	/// list, certificate request, or keygen request by using the issuer's public key. The function does not require access to a private key.
	/// </summary>
	/// <param name="hCryptProv">
	/// <para>This parameter is not used and should be set to <c>NULL</c>.</para>
	/// <para>
	/// <c>Windows Server 2003 and Windows XP:</c> A handle to the cryptographic service provider used to verify the signature.This
	/// parameter's data type is <c>HCRYPTPROV</c>.
	/// </para>
	/// <para>
	/// <c>NULL</c> is passed unless there is a strong reason for passing in a specific cryptographic provider. Passing in <c>NULL</c>
	/// causes the default RSA or DSS provider to be acquired.
	/// </para>
	/// </param>
	/// <param name="dwCertEncodingType">
	/// <para>
	/// The certificate encoding type that was used to encrypt the subject. The message encoding type identifier, contained in the high
	/// <c>WORD</c> of this value, is ignored by this function.
	/// </para>
	/// <para>This parameter can be the following currently defined certificate encoding type.</para>
	/// <list type="table">
	/// <listheader>
	/// <term>Value</term>
	/// <term>Meaning</term>
	/// </listheader>
	/// <item>
	/// <term>X509_ASN_ENCODING 1 (0x1)</term>
	/// <term>Specifies X.509 certificate encoding.</term>
	/// </item>
	/// </list>
	/// </param>
	/// <param name="dwSubjectType">
	/// <para>The subject type. This parameter can be one of the following subject types.</para>
	/// <list type="table">
	/// <listheader>
	/// <term>Value</term>
	/// <term>Meaning</term>
	/// </listheader>
	/// <item>
	/// <term>CRYPT_VERIFY_CERT_SIGN_SUBJECT_BLOB 1 (0x1)</term>
	/// <term>pvSubject is a pointer to a CRYPT_DATA_BLOBstructure.</term>
	/// </item>
	/// <item>
	/// <term>CRYPT_VERIFY_CERT_SIGN_SUBJECT_CERT 2 (0x2)</term>
	/// <term>pvSubject is a pointer to a CCERT_CONTEXTstructure.</term>
	/// </item>
	/// <item>
	/// <term>CRYPT_VERIFY_CERT_SIGN_SUBJECT_CRL 3 (0x3)</term>
	/// <term>pvSubject is a pointer to a CCRL_CONTEXTstructure.</term>
	/// </item>
	/// <item>
	/// <term>CRYPT_VERIFY_CERT_SIGN_SUBJECT_OCSP_BASIC_SIGNED_RESPONSE 4 (0x4)</term>
	/// <term>
	/// pvSubject is a pointer to an OCSP_BASIC_SIGNED_RESPONSE_INFO structure. Windows Server 2003 and Windows XP: This subject type is
	/// not supported.
	/// </term>
	/// </item>
	/// </list>
	/// </param>
	/// <param name="pvSubject">A pointer to a structure of the type indicated by dwSubjectType that contains the signature to be verified.</param>
	/// <param name="dwIssuerType">
	/// <para>The issuer type. This parameter can be one of the following issuer types.</para>
	/// <list type="table">
	/// <listheader>
	/// <term>Value</term>
	/// <term>Meaning</term>
	/// </listheader>
	/// <item>
	/// <term>CRYPT_VERIFY_CERT_SIGN_ISSUER_PUBKEY 1 (0x1)</term>
	/// <term>pvIssuer is a pointer to a CERT_PUBLIC_KEY_INFOstructure.</term>
	/// </item>
	/// <item>
	/// <term>CRYPT_VERIFY_CERT_SIGN_ISSUER_CERT 2 (0x2)</term>
	/// <term>pvIssuer is a pointer to a CCERT_CONTEXTstructure.</term>
	/// </item>
	/// <item>
	/// <term>CRYPT_VERIFY_CERT_SIGN_ISSUER_CHAIN 3 (0x3)</term>
	/// <term>pvIssuer is a pointer to a CCERT_CHAIN_CONTEXTstructure.</term>
	/// </item>
	/// <item>
	/// <term>CRYPT_VERIFY_CERT_SIGN_ISSUER_NULL 4 (0x4)</term>
	/// <term>pvIssuer must be NULL.</term>
	/// </item>
	/// </list>
	/// <para>
	/// <c>Note</c> If dwIssuerType is <c>CRYPT_VERIFY_CERT_SIGN_ISSUER_NULL</c> and the signature algorithm is a hashing algorithm, the
	/// signature is expected to contain only unencrypted hash octets. Only <c>CRYPT_VERIFY_CERT_SIGN_ISSUER_NULL</c> can be specified
	/// in this nonencrypted signature case. If any other dwIssuerType is specified, verification fails and GetLastError returns E_INVALIDARG.
	/// </para>
	/// </param>
	/// <param name="pvIssuer">
	/// A pointer to a structure of the type indicated by the value of dwIssuerType. The structure contains access to the public key
	/// needed to verify the signature.
	/// </param>
	/// <param name="dwFlags">
	/// <para>Flags that modify the function behavior. This can be zero or a bitwise <c>OR</c> of the following values.</para>
	/// <list type="table">
	/// <listheader>
	/// <term>Value</term>
	/// <term>Meaning</term>
	/// </listheader>
	/// <item>
	/// <term>CRYPT_VERIFY_CERT_SIGN_DISABLE_MD2_MD4_FLAG 0x00000001</term>
	/// <term>
	/// If you set this flag and CryptVerifyCertificateSignatureEx detects an MD2 or MD4 algorithm, the function returns FALSE and sets
	/// GetLastError to NTE_BAD_ALGID. The signature is still verified, but this combination of errors enables the caller, now knowing
	/// that an MD2 or MD4 algorithm was used, to decide whether to trust or reject the signature. Windows 8 and Windows Server 2012:
	/// Support for this flag begins.
	/// </term>
	/// </item>
	/// <item>
	/// <term>CRYPT_VERIFY_CERT_SIGN_SET_STRONG_PROPERTIES_FLAG 0x00000002</term>
	/// <term>
	/// Sets strong signature properties, after successful verification, on the subject pointed to by the pvSubject parameter. The
	/// following property is set on the certificate context: The following properties are set on the CRL context: Windows 8 and Windows
	/// Server 2012: Support for this flag begins.
	/// </term>
	/// </item>
	/// <item>
	/// <term>CRYPT_VERIFY_CERT_SIGN_RETURN_STRONG_PROPERTIES_FLAG 0x00000004</term>
	/// <term>
	/// Returns a pointer to a CRYPT_VERIFY_CERT_SIGN_STRONG_PROPERTIES_INFO structure in the pvExtra parameter. The structure contains
	/// the length, in bits, of the public key and the names of the signing and hashing algorithms used. You must call CryptMemFree to
	/// free the structure. If memory cannot be allocated for the CRYPT_VERIFY_CERT_SIGN_STRONG_PROPERTIES_INFO structure, this function
	/// returns successfully but sets the pvExtra parameter to NULL. Windows 8 and Windows Server 2012: Support for this flag begins.
	/// </term>
	/// </item>
	/// </list>
	/// </param>
	/// <param name="pvExtra">
	/// <para>Pointer to a CRYPT_VERIFY_CERT_SIGN_STRONG_PROPERTIES_INFO structure if the dwFlags parameter is set to <c>CRYPT_VERIFY_CERT_SIGN_RETURN_STRONG_PROPERTIES_FLAG</c>.</para>
	/// <para>You must call CryptMemFree to free the structure.</para>
	/// </param>
	/// <returns>
	/// <para>Returns nonzero if successful or zero otherwise.</para>
	/// <para>For extended error information, call GetLastError.</para>
	/// <para>
	/// <c>Note</c> Errors from the called functions CryptCreateHash, CryptImportKey, CryptVerifySignature, and CryptHashData may be
	/// propagated to this function.
	/// </para>
	/// <para>On failure, this function will cause the following error codes to be returned from GetLastError.</para>
	/// <list type="table">
	/// <listheader>
	/// <term>Return code</term>
	/// <term>Description</term>
	/// </listheader>
	/// <item>
	/// <term>ERROR_FILE_NOT_FOUND</term>
	/// <term>Invalid certificate encoding type. Currently only X509_ASN_ENCODING is supported.</term>
	/// </item>
	/// <item>
	/// <term>NTE_BAD_ALGID</term>
	/// <term>The signature algorithm's object identifier (OID) does not map to a known or supported hash algorithm.</term>
	/// </item>
	/// <item>
	/// <term>NTE_BAD_SIGNATURE</term>
	/// <term>The signature was not valid.</term>
	/// </item>
	/// </list>
	/// <para>
	/// If the function fails, GetLastError may return an Abstract Syntax Notation One (ASN.1) encoding/decoding error. For information
	/// about these errors, see ASN.1 Encoding/Decoding Return Values.
	/// </para>
	/// </returns>
	/// <remarks>
	/// The subject buffer can contain an encoded BLOB or a context for a certificate or CRL. In the case of a certificate context, if
	/// the certificate's public key parameters are missing and if these parameters can be inherited from the certificate's issuer for
	/// example from the DSS public key parameter, the context's CERT_PUBKEY_ALG_PARA_PROP_ID property is updated with the issuer's
	/// public key algorithm parameters for a valid signature.
	/// </remarks>
	// https://docs.microsoft.com/en-us/windows/win32/api/wincrypt/nf-wincrypt-cryptverifycertificatesignatureex BOOL
	// CryptVerifyCertificateSignatureEx( HCRYPTPROV_LEGACY hCryptProv, DWORD dwCertEncodingType, DWORD dwSubjectType, void *pvSubject,
	// DWORD dwIssuerType, void *pvIssuer, DWORD dwFlags, void *pvExtra );
	[DllImport(Lib.Crypt32, SetLastError = true, ExactSpelling = true)]
	[PInvokeData("wincrypt.h", MSDNShortId = "8a84af66-b174-4a3e-b1d7-6f218a52d877")]
	[return: MarshalAs(UnmanagedType.Bool)]
	public static extern bool CryptVerifyCertificateSignatureEx([Optional] HCRYPTPROV hCryptProv, CertEncodingType dwCertEncodingType, CryptVerifyCertSignSubject dwSubjectType,
		IntPtr pvSubject, CryptVerifyCertSignIssuer dwIssuerType, [In, Optional] IntPtr pvIssuer, CryptVerifyCertSignFlags dwFlags, [In, Out, Optional] IntPtr pvExtra);

	/// <summary>
	/// The <c>CERT_NAME_INFO</c> structure contains subject or issuer names. The information is represented as an array of CERT_RDN structures.
	/// </summary>
	// https://docs.microsoft.com/en-us/windows/win32/api/wincrypt/ns-wincrypt-cert_name_info typedef struct _CERT_NAME_INFO { DWORD
	// cRDN; PCERT_RDN rgRDN; } CERT_NAME_INFO, *PCERT_NAME_INFO;
	[PInvokeData("wincrypt.h", MSDNShortId = "402d1051-d91a-4a79-96f6-10ed96a32d5c")]
	[StructLayout(LayoutKind.Sequential)]
	public struct CERT_NAME_INFO
	{
		/// <summary>Number of elements in the <c>rgRDN</c> array.</summary>
		public uint cRDN;

		/// <summary>Array of pointers to CERT_RDN structures.</summary>
		public IntPtr rgRDN;
	}

	/// <summary>
	/// The <c>CERT_REVOCATION_PARA</c> structure is passed in calls to the CertVerifyRevocation function to assist in finding the
	/// issuer of the context to be verified. The <c>CERT_REVOCATION_PARA</c> structure is an optional parameter in the
	/// CertVerifyRevocation function.
	/// </summary>
	/// <remarks>
	/// <para>
	/// The <c>CERT_REVOCATION_PARA</c> structure provides additional information that the CertVerifyRevocation function can use to
	/// determine the context issuer.
	/// </para>
	/// <para>
	/// If your application must check the freshness of the CRL or resynchronize the CRL cache, you can provide extra structure members
	/// to assist the CertVerifyRevocation function with this. To include the additional structure members, define the constant
	/// <c>CERT_REVOCATION_PARA_HAS_EXTRA_FIELDS</c> in your application before including Wincrypt.h
	/// </para>
	/// </remarks>
	// https://docs.microsoft.com/en-us/windows/win32/api/wincrypt/ns-wincrypt-cert_revocation_para typedef struct _CERT_REVOCATION_PARA
	// { DWORD cbSize; PCCERT_CONTEXT pIssuerCert; DWORD cCertStore; HCERTSTORE *rgCertStore; HCERTSTORE hCrlStore; LPFILETIME
	// pftTimeToUse; DWORD dwUrlRetrievalTimeout; BOOL fCheckFreshnessTime; DWORD dwFreshnessTime; LPFILETIME pftCurrentTime;
	// PCERT_REVOCATION_CRL_INFO pCrlInfo; LPFILETIME pftCacheResync; PCERT_REVOCATION_CHAIN_PARA pChainPara; } CERT_REVOCATION_PARA, *PCERT_REVOCATION_PARA;
	[PInvokeData("wincrypt.h", MSDNShortId = "730db593-c55f-4ecf-bcac-5de54ab90db6")]
	[StructLayout(LayoutKind.Sequential)]
	public struct CERT_REVOCATION_PARA
	{
		/// <summary>The size, in bytes, of this structure.</summary>
		public uint cbSize;

		/// <summary>
		/// A pointer to a CERT_CONTEXT structure that contains the certificate of the issuer of a certificate specified in the
		/// rgpvContext array in the CertVerifyRevocation parameter list.
		/// </summary>
		public PCCERT_CONTEXT pIssuerCert;

		/// <summary>
		/// When set, contains the number of elements in the <c>rgCertStore</c> array. Set to zero if you are not supplying a list of
		/// store handles in the rgCertStore parameter.
		/// </summary>
		public uint cCertStore;

		/// <summary>
		/// An array of certificate store handles. Specifies a set of stores that are searched for issuer certificates. If rgCertStore
		/// is not set, the default stores are searched.
		/// </summary>
		public IntPtr rgCertStore;

		/// <summary>
		/// Optional store handle. When specified, a handler that uses certificate revocation lists (CRLs) can search this store for CRLs.
		/// </summary>
		public HCERTSTORE hCrlStore;

		/// <summary>
		/// A pointer to a <c>FILETIME</c> version of UTC time. When specified, the handler must, if possible, determine revocation
		/// status relative to the time given. If <c>NULL</c> or the handler cannot determine the status relative to the
		/// <c>pftTimeToUse</c> value, revocation status can be determined independent of time or relative to current time.
		/// </summary>
		public IntPtr pftTimeToUse;

		/// <summary>
		/// This member is defined only if <c>CERT_REVOCATION_PARA_HAS_EXTRA_FIELDS</c> is defined. The time-out, in milliseconds, that
		/// the revocation handler will wait when attempting to retrieve revocation information. If it is set to zero, the revocation
		/// handler's default time-out is used. If <c>CERT_REVOCATION_PARA_HAS_EXTRA_FIELDS</c> is defined, this member must be set to
		/// zero if it is unused.
		/// </summary>
		public uint dwUrlRetrievalTimeout;

		/// <summary>
		/// This member is defined only if <c>CERT_REVOCATION_PARA_HAS_EXTRA_FIELDS</c> is defined. If <c>TRUE</c>, an attempt is made
		/// to retrieve a new CRL if the issue date of the CRL is less than or equal to the Current Time minus <c>dwFreshnessTime</c>.
		/// If this flag is not set, the CRL's NextUpdate time is used. If <c>CERT_REVOCATION_PARA_HAS_EXTRA_FIELDS</c> is defined, this
		/// member must be set to <c>FALSE</c> if it is unused.
		/// </summary>
		[MarshalAs(UnmanagedType.Bool)] public bool fCheckFreshnessTime;

		/// <summary>
		/// This member is defined only if <c>CERT_REVOCATION_PARA_HAS_EXTRA_FIELDS</c> is defined. The time, in seconds, is used to
		/// determine whether an attempt will be made to retrieve a new CRL. If <c>CERT_REVOCATION_PARA_HAS_EXTRA_FIELDS</c> is defined,
		/// this member must be set to zero if it is unused.
		/// </summary>
		public uint dwFreshnessTime;

		/// <summary>
		/// This member is defined only if <c>CERT_REVOCATION_PARA_HAS_EXTRA_FIELDS</c> is defined. A pointer to a <c>FILETIME</c>
		/// structure that is used in the freshness time check. If the value of this pointer is null, the revocation handler uses the
		/// current time. If <c>CERT_REVOCATION_PARA_HAS_EXTRA_FIELDS</c> is defined, this member must be set to null if it is unused.
		/// </summary>
		public IntPtr pftCurrentTime;

		/// <summary>
		/// This member is defined only if <c>CERT_REVOCATION_PARA_HAS_EXTRA_FIELDS</c> is defined. This member contains a pointer to a
		/// PCERT_REVOCATION_CRL_INFO structure that contains CRL context information. The CRL information is only applicable to the
		/// last context checked. To access the information in this CRL, call the CertVerifyRevocation function with cContext set to 1.
		/// If <c>CERT_REVOCATION_PARA_HAS_EXTRA_FIELDS</c> is defined, the member must be set to null if it is unused.
		/// </summary>
		public IntPtr pCrlInfo;

		/// <summary>
		/// <para>
		/// This member is defined only if <c>CERT_REVOCATION_PARA_HAS_EXTRA_FIELDS</c> is defined. This member contains a pointer to a
		/// <c>FILETIME</c> structure that specifies the use of cached information. Any information cached before the specified time is
		/// considered invalid and new information is retrieved. If <c>CERT_REVOCATION_PARA_HAS_EXTRA_FIELDS</c> is defined, this member
		/// must be set to null if it is unused.
		/// </para>
		/// <para><c>Windows Server 2003 and Windows XP:</c> This member is not used.</para>
		/// </summary>
		public IntPtr pftCacheResync;

		/// <summary>
		/// <para>
		/// This member is defined only if <c>CERT_REVOCATION_PARA_HAS_EXTRA_FIELDS</c> is defined. This member contains a pointer to a
		/// CERT_REVOCATION_CHAIN_PARA structure that contains parameters used for building a chain for an independent OCSP signer
		/// certificate. If <c>CERT_REVOCATION_PARA_HAS_EXTRA_FIELDS</c> is defined, this member must be set to null if it is unused.
		/// </para>
		/// <para>
		/// <c>Windows Vista, Windows Server 2003 and Windows XP:</c> This member is not used in the listed systems. The member is
		/// available beginning with Windows Vista with SP1.
		/// </para>
		/// </summary>
		public IntPtr pChainPara;
	}

	/// <summary>
	/// The <c>CERT_REVOCATION_STATUS</c> structure contains information on the revocation status of the certificate. It is passed to
	/// and returned by CertVerifyRevocation. On return from the function, it specifies the status of a revoked or unchecked context.
	/// </summary>
	// https://docs.microsoft.com/en-us/windows/win32/api/wincrypt/ns-wincrypt-cert_revocation_status typedef struct
	// _CERT_REVOCATION_STATUS { DWORD cbSize; DWORD dwIndex; DWORD dwError; DWORD dwReason; BOOL fHasFreshnessTime; DWORD
	// dwFreshnessTime; } CERT_REVOCATION_STATUS, *PCERT_REVOCATION_STATUS;
	[PInvokeData("wincrypt.h", MSDNShortId = "087ea37a-907a-4652-a5df-dd8e86755490")]
	[StructLayout(LayoutKind.Sequential)]
	public struct CERT_REVOCATION_STATUS
	{
		/// <summary>
		/// <para>Size of this structure in bytes.</para>
		/// <para>
		/// Upon input to <c>CERT_REVOCATION_STATUS</c>, <c>cbSize</c> must be set to a size greater than or equal to the size of a
		/// <c>CERT_REVOCATION_STATUS</c> structure. Otherwise, <c>CERT_REVOCATION_STATUS</c> returns <c>FALSE</c> and GetLastError
		/// returns E_INVALIDARG.
		/// </para>
		/// </summary>
		public uint cbSize;

		/// <summary>
		/// Specifies an index value for the rgpvContext array passed to CertVerifyRevocation. It is the index of the first context in
		/// that array that was revoked or that could not be checked for revocation. For information about the contexts that were not
		/// checked, <c>CertVerifyRevocation</c> is called again, specifying a rgpvContext array that contains the unchecked contexts
		/// from the original list.
		/// </summary>
		public uint dwIndex;

		/// <summary>
		/// Specifies the returned error status. This value matches the return value of GetLastError on return from the call to
		/// CertVerifyRevocation. For the list of these error values, see the table in the Return Values section of <c>CertVerifyRevocation</c>.
		/// </summary>
		public Win32Error dwError;

		/// <summary>
		/// <para>
		/// Specifies the cause of the error. This member is set only if <c>dwError</c> is CRYPT_E_REVOKED. It contains a code that
		/// indicates why the context was revoked. It can be one of the following values.
		/// </para>
		/// <list type="table">
		/// <listheader>
		/// <term>Value</term>
		/// <term>Meaning</term>
		/// </listheader>
		/// <item>
		/// <term>CRL_REASON_UNSPECIFIED</term>
		/// <term>No reason was specified for revocation.</term>
		/// </item>
		/// <item>
		/// <term>CRL_REASON_KEY_COMPROMISE</term>
		/// <term>
		/// It is known or suspected that the subject's private key or other aspects of the subject validated in the certificate are compromised.
		/// </term>
		/// </item>
		/// <item>
		/// <term>CRL_REASON_CA_COMPROMISE</term>
		/// <term>It is known or suspected that the CA's private key or other aspects of the CA validated in the certificate are compromised.</term>
		/// </item>
		/// <item>
		/// <term>CRL_REASON_AFFILIATION_CHANGED</term>
		/// <term>
		/// The subject's name or other information in the certificate has been modified but there is no cause to suspect that the
		/// private key has been compromised.
		/// </term>
		/// </item>
		/// <item>
		/// <term>CRL_REASON_SUPERSEDED</term>
		/// <term>The certificate has been superseded, but there is no cause to suspect that the private key has been compromised.</term>
		/// </item>
		/// <item>
		/// <term>CRL_REASON_CESSATION_OF_OPERATION</term>
		/// <term>
		/// The certificate is no longer needed for the purpose for which it was issued, but there is no cause to suspect that the
		/// private key has been compromised.
		/// </term>
		/// </item>
		/// <item>
		/// <term>CRL_REASON_CERTIFICATE_HOLD</term>
		/// <term>The certificate has been placed on hold.</term>
		/// </item>
		/// </list>
		/// </summary>
		public CRL_REASON dwReason;

		/// <summary>
		/// Depending on <c>cbSize</c>, this structure can contain this member. If this member is <c>TRUE</c>, the revocation freshness
		/// time returned by <c>dwFreshnessTime</c> is valid.
		/// </summary>
		[MarshalAs(UnmanagedType.Bool)] public bool fHasFreshnessTime;

		/// <summary>
		/// Depending on <c>cbSize</c>, this structure can contain this member. If present, this member gives the time in seconds
		/// between the current time and when the CRL was published.
		/// </summary>
		public uint dwFreshnessTime;
	}

	/// <summary>
	/// <para>
	/// [The <c>CRYPT_ATTRIBUTES</c> structure is available for use in the operating systems specified in the Requirements section. It
	/// may be altered or unavailable in subsequent versions.]
	/// </para>
	/// <para>The <c>CRYPT_ATTRIBUTES</c> structure contains an array of attributes.</para>
	/// </summary>
	// https://docs.microsoft.com/en-us/windows/win32/api/wincrypt/ns-wincrypt-crypt_attributes typedef struct _CRYPT_ATTRIBUTES { DWORD
	// cAttr; PCRYPT_ATTRIBUTE rgAttr; } CRYPT_ATTRIBUTES, *PCRYPT_ATTRIBUTES;
	[PInvokeData("wincrypt.h", MSDNShortId = "782f3022-d852-4ad7-8e0f-afbccc25928a")]
	[StructLayout(LayoutKind.Sequential)]
	public struct CRYPT_ATTRIBUTES
	{
		/// <summary>Number of elements in the <c>rgAttr</c> array.</summary>
		public uint cAttr;

		/// <summary>Array of CRYPT_ATTRIBUTE structures.</summary>
		public IntPtr rgAttr;
	}

	/// <summary>
	/// <para>
	/// [The <c>CRYPT_PKCS8_EXPORT_PARAMS</c> structure is available for use in the operating systems specified in the Requirements
	/// section. It may be altered or unavailable in subsequent versions.]
	/// </para>
	/// <para>
	/// The <c>CRYPT_PKCS8_EXPORT_PARAMS</c> structure identifies the private key and a callback function to encrypt the private key.
	/// <c>CRYPT_PKCS8_EXPORT_PARAMS</c> is used as a parameter to the CryptExportPKCS8Ex function, which exports a private key in PKCS
	/// #8 format.
	/// </para>
	/// </summary>
	// https://docs.microsoft.com/en-us/windows/win32/api/wincrypt/ns-wincrypt-crypt_pkcs8_export_params typedef struct
	// _CRYPT_PKCS8_EXPORT_PARAMS { HCRYPTPROV hCryptProv; DWORD dwKeySpec; LPSTR pszPrivateKeyObjId; PCRYPT_ENCRYPT_PRIVATE_KEY_FUNC
	// pEncryptPrivateKeyFunc; LPVOID pVoidEncryptFunc; } CRYPT_PKCS8_EXPORT_PARAMS, *PCRYPT_PKCS8_EXPORT_PARAMS;
	[PInvokeData("wincrypt.h", MSDNShortId = "5a60c96e-907a-409e-921c-59055452463f")]
	[StructLayout(LayoutKind.Sequential)]
	public struct CRYPT_PKCS8_EXPORT_PARAMS
	{
		/// <summary>
		/// An HCRYPTPROV variable that contains a handle to the cryptographic service provider (CSP) used to encrypt the private key.
		/// This is a handle to the CSP obtained by calling CryptAcquireContext.
		/// </summary>
		public HCRYPTPROV hCryptProv;

		/// <summary>
		/// <para>
		/// A <c>DWORD</c> variable that contains the key specification. The following <c>dwKeySpec</c> values are defined for the
		/// default provider.
		/// </para>
		/// <list type="table">
		/// <listheader>
		/// <term>Value</term>
		/// <term>Meaning</term>
		/// </listheader>
		/// <item>
		/// <term>AT_KEYEXCHANGE</term>
		/// <term>Keys used to encrypt/decrypt session keys.</term>
		/// </item>
		/// <item>
		/// <term>AT_SIGNATURE</term>
		/// <term>Keys used to create and verify digital signatures.</term>
		/// </item>
		/// </list>
		/// </summary>
		public CertKeySpec dwKeySpec;

		/// <summary>An <c>LPSTR</c> variable that contains the object identifier (OID) of the private key to be exported.</summary>
		public StrPtrAnsi pszPrivateKeyObjId;

		/// <summary>
		/// A PCRYPT_ENCRYPT_PRIVATE_KEY_FUNC pointer that points to a callback to a function that encrypts the private key. If this is
		/// <c>NULL</c>, the private key is not encrypted, and a PKCS #8 CRYPT_ENCRYPTED_PRIVATE_KEY_INFO structure will not be
		/// generated by CryptExportPKCS8Ex.
		/// </summary>
		[MarshalAs(UnmanagedType.FunctionPtr)] public PCRYPT_ENCRYPT_PRIVATE_KEY_FUNC pEncryptPrivateKeyFunc;

		/// <summary>A <c>LPVOID</c> value that provides data used for encryption, such as key, initialization vector, and password.</summary>
		public IntPtr pVoidEncryptFunc;
	}

	/// <summary>
	/// <para>
	/// [The <c>CRYPT_PKCS8_IMPORT_PARAMS</c> structure is available for use in the operating systems specified in the Requirements
	/// section. It may be altered or unavailable in subsequent versions.]
	/// </para>
	/// <para>
	/// The <c>CRYPT_PKCS8_IMPORT_PARAMS</c> structure contains a PKCS #8 private key and pointers to callback functions.
	/// <c>CRYPT_PKCS8_IMPORT_PARAMS</c> is used by the CryptImportPKCS8 function. The first callback supplies the algorithm object
	/// identifier (OID) and key length needed to specify the cryptographic service provider (CSP) into which the key will be imported.
	/// If the private key in PKCS #8 is encrypted, the <c>CRYPT_PKCS8_IMPORT_PARAMS</c> structure contains the encrypted private key,
	/// and the second callback is used to decrypt this private key.
	/// </para>
	/// </summary>
	// https://docs.microsoft.com/en-us/windows/win32/api/wincrypt/ns-wincrypt-crypt_pkcs8_import_params typedef struct
	// _CRYPT_PKCS8_IMPORT_PARAMS { CRYPT_DIGEST_BLOB PrivateKey; PCRYPT_RESOLVE_HCRYPTPROV_FUNC pResolvehCryptProvFunc; LPVOID
	// pVoidResolveFunc; PCRYPT_DECRYPT_PRIVATE_KEY_FUNC pDecryptPrivateKeyFunc; LPVOID pVoidDecryptFunc; } CRYPT_PKCS8_IMPORT_PARAMS,
	// *PCRYPT_PKCS8_IMPORT_PARAMS, CRYPT_PRIVATE_KEY_BLOB_AND_PARAMS, *PCRYPT_PRIVATE_KEY_BLOB_AND_PARAMS;
	[PInvokeData("wincrypt.h", MSDNShortId = "a016e807-60d3-4ae4-829b-43acea2ee8c1")]
	[StructLayout(LayoutKind.Sequential)]
	public struct CRYPT_PKCS8_IMPORT_PARAMS
	{
		/// <summary>A CRYPT_DIGEST_BLOB structure that contains the PKCS #8 data.</summary>
		public CRYPTOAPI_BLOB PrivateKey;

		/// <summary>
		/// A PCRYPT_RESOLVE_HCRYPTPROV_FUNC pointer that points to data used by a user-defined function that retrieves a handle to a CSP.
		/// </summary>
		[MarshalAs(UnmanagedType.FunctionPtr)]
		public PCRYPT_RESOLVE_HCRYPTPROV_FUNC pResolvehCryptProvFunc;

		/// <summary>An <c>LPVOID</c> value that identifies the function used to retrieve the CSP provider handle.</summary>
		public IntPtr pVoidResolveFunc;

		/// <summary>A PCRYPT_DECRYPT_PRIVATE_KEY_FUNC pointer that points to a callback function used to decrypt the private key.</summary>
		[MarshalAs(UnmanagedType.FunctionPtr)]
		public PCRYPT_DECRYPT_PRIVATE_KEY_FUNC pDecryptPrivateKeyFunc;

		/// <summary>An <c>LPVOID</c> value that provides data used for encryption, such as key, initialization vector, and password.</summary>
		public IntPtr pVoidDecryptFunc;
	}

	/// <summary>
	/// <para>
	/// [The <c>CRYPT_PRIVATE_KEY_INFO</c> structure is available for use in the operating systems specified in the Requirements
	/// section. It may be altered or unavailable in subsequent versions.]
	/// </para>
	/// <para>
	/// The <c>CRYPT_PRIVATE_KEY_INFO</c> structure contains a clear-text private key in the PrivateKey field (DER encoded).
	/// <c>CRYPT_PRIVATE_KEY_INFO</c> contains the information in a PKCS #8 PrivateKeyInfo ASN.1 type found in the PKCS #8 standard.
	/// </para>
	/// </summary>
	// https://docs.microsoft.com/en-us/windows/win32/api/wincrypt/ns-wincrypt-crypt_private_key_info typedef struct
	// _CRYPT_PRIVATE_KEY_INFO { DWORD Version; CRYPT_ALGORITHM_IDENTIFIER Algorithm; CRYPT_DER_BLOB PrivateKey; PCRYPT_ATTRIBUTES
	// pAttributes; } CRYPT_PRIVATE_KEY_INFO, *PCRYPT_PRIVATE_KEY_INFO;
	[PInvokeData("wincrypt.h", MSDNShortId = "63a5d1c2-88b3-45fa-94d3-2179cb8802c9")]
	[StructLayout(LayoutKind.Sequential)]
	public struct CRYPT_PRIVATE_KEY_INFO
	{
		/// <summary>A <c>DWORD</c> value that identifies the PKCS #8 version.</summary>
		public uint Version;

		/// <summary>
		/// A CRYPT_ALGORITHM_IDENTIFIER structure that indicates the algorithm in which the private key (RSA or DSA) is to be used.
		/// </summary>
		public CRYPT_ALGORITHM_IDENTIFIER Algorithm;

		/// <summary>A CRYPT_DER_BLOB structure that contains the key data.</summary>
		public CRYPTOAPI_BLOB PrivateKey;

		/// <summary>A CRYPT_ATTRIBUTES structure that identifies the PKCS #8 attributes.</summary>
		public IntPtr pAttributes;
	}

	/// <summary>Standard crypto memory allocation methods.</summary>
	/// <seealso cref="IMemoryMethods"/>
	public class CryptMemMethods : MemoryMethodsBase
	{
		/// <summary>Gets a static instance of this class.</summary>
		public static readonly CryptMemMethods Instance = new();

		/// <summary>Gets a handle to a memory allocation of the specified size.</summary>
		/// <param name="size">The size, in bytes, of memory to allocate.</param>
		/// <returns>A memory handle.</returns>
		/// <exception cref="NotImplementedException"></exception>
		public override IntPtr AllocMem(int size) => Win32Error.ThrowLastErrorIfNull(CryptMemAlloc((uint)size));

		/// <summary>Frees the memory associated with a handle.</summary>
		/// <param name="hMem">A memory handle.</param>
		/// <exception cref="NotImplementedException"></exception>
		public override void FreeMem(IntPtr hMem) => CryptMemFree(hMem);

		/// <summary>Gets the reallocation method.</summary>
		/// <param name="hMem">A memory handle.</param>
		/// <param name="size">The size, in bytes, of memory to allocate.</param>
		/// <returns>A memory handle.</returns>
		public override IntPtr ReAllocMem(IntPtr hMem, int size) => Win32Error.ThrowLastErrorIfNull(CryptMemRealloc(hMem, (uint)size));
	}

	/// <summary>Safe handle for crypto memory.</summary>
	/// <seealso cref="SafeMemoryHandle{T}"/>
	public partial class SafeCryptMem : SafeMemoryHandleExt<CryptMemMethods>, ISafeMemoryHandleFactory
	{
		/// <summary>Initializes a new instance of the <see cref="SafeMemoryHandle{T}"/> class.</summary>
		/// <param name="size">The size of memory to allocate, in bytes.</param>
		/// <exception cref="ArgumentOutOfRangeException">size - The value of this argument must be non-negative</exception>
		public SafeCryptMem(SizeT size = default) : base(size) { }

		/// <summary>Initializes a new instance of the <see cref="SafeMemoryHandle{T}"/> class.</summary>
		/// <param name="handle">The handle.</param>
		/// <param name="size">The size of memory allocated to the handle, in bytes.</param>
		/// <param name="ownsHandle">if set to <c>true</c> if this class is responsible for freeing the memory on disposal.</param>
		public SafeCryptMem(IntPtr handle, SizeT size, bool ownsHandle) : base(handle, size, ownsHandle) { }

		/// <summary>
		/// Allocates from unmanaged memory to represent an array of pointers and marshals the unmanaged pointers (IntPtr) to the native
		/// array equivalent.
		/// </summary>
		/// <param name="bytes">Array of unmanaged pointers</param>
		/// <returns>SafeHGlobalHandle object to an native (unmanaged) array of pointers</returns>
		public SafeCryptMem(byte[] bytes) : base(bytes) { }

		/// <summary>Allocates from unmanaged memory to represent a Unicode string (WSTR) and marshal this to a native PWSTR.</summary>
		/// <param name="s">The string value.</param>
		/// <param name="charSet">The character set of the string.</param>
		/// <returns>SafeMemoryHandleExt object to an native (unmanaged) string</returns>
		public SafeCryptMem(string s, CharSet charSet = CharSet.Unicode) : base(s, charSet) { }

		/// <inheritdoc/>
		public static ISafeMemoryHandle Create(IntPtr handle, SizeT size, bool ownsHandle = true) => new SafeCryptMem(handle, size, ownsHandle);

		/// <inheritdoc/>
		public static ISafeMemoryHandle Create(byte[] bytes) => new SafeCryptMem(bytes);

		/// <inheritdoc/>
		public static ISafeMemoryHandle Create(SizeT size) => new SafeCryptMem(size);
	}
}