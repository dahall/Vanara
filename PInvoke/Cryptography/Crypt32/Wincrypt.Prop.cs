using System;
using System.Runtime.InteropServices;
using Vanara.InteropServices;
using FILETIME = System.Runtime.InteropServices.ComTypes.FILETIME;

namespace Vanara.PInvoke
{
	/// <summary>Methods and data types found in Crypt32.dll.</summary>
	public static partial class Crypt32
	{
		/// <summary>Set this flag to ignore any store provider write errors and always update the cached context's property.</summary>
		[PInvokeData("wincrypt.h")]
		public const uint CERT_SET_PROPERTY_IGNORE_PERSIST_ERROR_FLAG = 0x80000000;

		/// <summary>Set this flag to inhibit the persisting of this property.</summary>
		[PInvokeData("wincrypt.h")]
		public const uint CERT_SET_PROPERTY_INHIBIT_PERSIST_FLAG = 0x40000000;

		/// <summary>Property identifiers.</summary>
		[PInvokeData("wincrypt.h")]
		public enum CertPropId : uint
		{
			/// <summary>
			/// Gets or sets a DWORD value indicating whether write operations to the certificate are persisted. The DWORD value is not set
			/// if the certificate is in a memory store or in a registry-based store that is opened as read-only.
			/// </summary>
			[CorrespondingType(typeof(uint), CorrespondingAction.GetSet)]
			CERT_ACCESS_STATE_PROP_ID = 14,

			/// <summary>Reserved.</summary>
			CERT_AIA_URL_RETRIEVED_PROP_ID = 67,

			/// <summary>This property saves an encrypted key hash for the certificate context.</summary>
			[CorrespondingType(typeof(CRYPTOAPI_BLOB), CorrespondingAction.GetSet)]
			CERT_ARCHIVED_KEY_HASH_PROP_ID = 65,

			/// <summary>
			/// Indicates the certificate is skipped during enumerations. A certificate with this property set is found with explicit search
			/// operations, such as those used to find a certificate with a specific hash or a serial number. No data in pvData is
			/// associated with this property. This property can be set to the empty BLOB, {0,NULL}.
			/// </summary>
			[CorrespondingType(typeof(CRYPTOAPI_BLOB), CorrespondingAction.GetSet)]
			CERT_ARCHIVED_PROP_ID = 19,

			/// <summary></summary>
			CERT_AUTH_ROOT_SHA256_HASH_PROP_ID = 98,

			/// <summary>Reserved.</summary>
			CERT_AUTHORITY_INFO_ACCESS_PROP_ID = 68,

			/// <summary>
			/// Gets or sets a null-terminated Unicode string naming the certificate type for which the certificate has been auto enrolled.
			/// </summary>
			[CorrespondingType(typeof(string), CorrespondingAction.GetSet)]
			CERT_AUTO_ENROLL_PROP_ID = 21,

			/// <summary>Reserved.</summary>
			CERT_AUTO_ENROLL_RETRY_PROP_ID = 66,

			/// <summary>Reserved.</summary>
			CERT_BACKED_UP_PROP_ID = 69,

			/// <summary>
			/// Disables certificate revocation list (CRL) retrieval for certificates used by the certification authority (CA). If the CA
			/// certificate contains this property, it must also include the CERT_CA_OCSP_AUTHORITY_INFO_ACCESS_PROP_ID property.
			/// </summary>
			[CorrespondingType(typeof(CRYPTOAPI_BLOB), CorrespondingAction.GetSet)]
			CERT_CA_DISABLE_CRL_PROP_ID = 82,

			/// <summary>
			/// Contains the list of online certificate status protocol (OCSP) URLs to use for certificates issued by the CA certificate.
			/// The array contents are the Abstract Syntax Notation One (ASN.1)-encoded bytes of an X509_AUTHORITY_INFO_ACCESS structure
			/// where pszAccessMethod is set to szOID_PKIX_OCSP.
			/// </summary>
			[CorrespondingType(typeof(byte[]), CorrespondingAction.GetSet)]
			CERT_CA_OCSP_AUTHORITY_INFO_ACCESS_PROP_ID = 81,

			/// <summary></summary>
			CERT_CEP_PROP_ID = 87,

			/// <summary></summary>
			CERT_CLR_DELETE_KEY_PROP_ID = 125,

			/// <summary>
			/// Location of the cross certificates. Currently, this identifier is only applicable to certificates and not to CRLs or
			/// certificate trust lists (CTLs). The BYTE array contains an ASN.1-encoded CROSS_CERT_DIST_POINTS_INFO structure decoded by
			/// using the CryptDecodeObject function with a X509_CROSS_CERT_DIST_POINTS value for the lpszStuctType parameter.
			/// </summary>
			[CorrespondingType(typeof(CRYPTOAPI_BLOB), CorrespondingAction.GetSet)]
			CERT_CROSS_CERT_DIST_POINTS_PROP_ID = 23,

			/// <summary>An array of bytes containing an Abstract Syntax Notation One (ASN.1) encoded CTL_USAGE structure.</summary>
			[CorrespondingType(typeof(byte[]), CorrespondingAction.GetSet)]
			CERT_CTL_USAGE_PROP_ID = CERT_ENHKEY_USAGE_PROP_ID,

			/// <summary>Time when the certificate was added to the store.</summary>
			[CorrespondingType(typeof(FILETIME), CorrespondingAction.GetSet)]
			CERT_DATE_STAMP_PROP_ID = 27,

			/// <summary>
			/// Gets or sets the property displayed by the certificate UI. This property allows the user to describe the certificate's use.
			/// </summary>
			[CorrespondingType(typeof(byte[]), CorrespondingAction.GetSet)]
			CERT_DESCRIPTION_PROP_ID = 13,

			/// <summary></summary>
			CERT_DISALLOWED_ENHKEY_USAGE_PROP_ID = 122,

			/// <summary></summary>
			CERT_DISALLOWED_FILETIME_PROP_ID = 104,

			/// <summary>Reserved</summary>
			CERT_EFS_PROP_ID = 17,

			/// <summary>An array of bytes containing an ASN.1 encoded CERT_ENHKEY_USAGE structure.</summary>
			[CorrespondingType(typeof(byte[]), CorrespondingAction.GetSet)]
			CERT_ENHKEY_USAGE_PROP_ID = 9,

			/// <summary>
			/// <para>
			/// Enrollment information of the pending request that contains RequestID, CADNSName, CAName, and DisplayName. The data format
			/// is defined as follows.
			/// </para>
			/// <list type="table">
			/// <listheader>
			/// <description>Bytes</description>
			/// <description>Contents</description>
			/// </listheader>
			/// <item>
			/// <description>First 4 bytes</description>
			/// <description>Pending request ID</description>
			/// </item>
			/// <item>
			/// <description>Next 4 bytes</description>
			/// <description>
			/// CADNSName size, in characters, including the terminating null character, followed by CADNSName string with terminating null character
			/// </description>
			/// </item>
			/// <item>
			/// <description>Next 4 bytes</description>
			/// <description>
			/// CAName size, in characters, including the terminating null character, followed by CAName string with terminating null character
			/// </description>
			/// </item>
			/// <item>
			/// <description>Next 4 bytes</description>
			/// <description>
			/// DisplayName size, in characters, including the terminating null character, followed by DisplayName string with terminating
			/// null character
			/// </description>
			/// </item>
			/// </list>
			/// </summary>
			[CorrespondingType(typeof(byte[]), CorrespondingAction.GetSet)]
			CERT_ENROLLMENT_PROP_ID = 26,

			/// <summary>
			/// Returns a null-terminated Unicode character string that contains extended error information for the certificate context.
			/// </summary>
			[CorrespondingType(typeof(byte[]), CorrespondingAction.GetSet)]
			CERT_EXTENDED_ERROR_INFO_PROP_ID = 30,

			/// <summary>Reserved</summary>
			CERT_FORTEZZA_DATA_PROP_ID = 18,

			/// <summary>A null-terminated Unicode character string that contains the display name for the CRL.</summary>
			[CorrespondingType(typeof(string), CorrespondingAction.GetSet)]
			CERT_FRIENDLY_NAME_PROP_ID = 11,

			/// <summary>Returns the SHA1 hash. If the hash does not exist, it is computed by using the CryptHashCertificate function.</summary>
			[CorrespondingType(typeof(byte[]), CorrespondingAction.GetSet)]
			CERT_HASH_PROP_ID = CERT_SHA1_HASH_PROP_ID,

			/// <summary>Returns either the HCRYPTPROV or NCRYPT_KEY_HANDLE choice.</summary>
			[CorrespondingType(typeof(HCRYPTPROV), CorrespondingAction.GetSet)]
			[CorrespondingType(typeof(NCrypt.NCRYPT_KEY_HANDLE), CorrespondingAction.GetSet)]
			CERT_HCRYPTPROV_OR_NCRYPT_KEY_HANDLE_PROP_ID = 79,

			/// <summary>
			/// The Cryptography API (CAPI) key handle associated with the certificate. The caller is responsible for freeing the handle. It
			/// will not be freed when the context is freed. The property value is removed after after it is returned. If you call this
			/// property on a context that has a CNG key, CRYPT_E_NOT_FOUND is returned.
			/// </summary>
			[CorrespondingType(typeof(HANDLE), CorrespondingAction.GetSet)]
			CERT_HCRYPTPROV_TRANSFER_PROP_ID = 100,

			/// <summary>Rerserved.</summary>
			CERT_IE30_RESERVED_PROP_ID = 7,

			/// <summary></summary>
			CERT_ISOLATED_KEY_PROP_ID = 118,

			/// <summary>
			/// <para>
			/// A string containing a set of L"&lt;PUBKEY&gt;/&lt;BITLENGTH&gt;" public key algorithm and bit length pairs. The semicolon,
			/// L";", is used as the delimiter.
			/// </para>
			/// <para>The &lt;PUBKEY&gt; value identifies the CNG public key algorithm. The following algorithms are supported:</para>
			/// <list type="bullet">
			/// <item>L"RSA" (BCRYPT_RSA_ALGORITHM)</item>
			/// <item>L"DSA" (BCRYPT_DSA_ALGORITHM)</item>
			/// <item>L"ECDSA" (SSL_ECDSA_ALGORITHM)</item>
			/// </list>
			/// <para>
			/// A &lt;PUBKEY&gt;/&lt;BITLENGTH&gt; pair is set for each certificate in the CRL issuer chain excluding the leaf. This
			/// property can be set when an OCSP response with an independent signer chain is converted to a CRL.
			/// </para>
			/// <note type="note">This property should not be set for a delegated OCSP signer certificate. A delegated signer certificate is
			/// signed with the same key used to sign the subject certificate and is checked there.</note>
			/// <para>The following is an example:</para>
			/// <para>: L"RSA/2048;RSA/4096"</para>
			/// </summary>
			[CorrespondingType(typeof(CRYPTOAPI_BLOB), CorrespondingAction.GetSet)]
			CERT_ISSUER_CHAIN_PUB_KEY_CNG_ALG_BIT_LENGTH_PROP_ID = 96,

			/// <summary>
			/// <para>
			/// A string that contains a set of L"&lt;SIGNATURE&gt;/&lt;HASH&gt;" algorithm pairs. The semicolon, L";", is used as the
			/// delimiter between pairs.
			/// </para>
			/// <para>
			/// This property is set only when an OCSP response is converted to a CRL. For a delegated OCSP signer certificate, only the
			/// algorithm pair for the signer certificate is returned. For an independent OCSP signer certificate chain, an algorithm pair
			/// is returned for each certificate in the chain excluding the root.
			/// </para>
			/// <para>The &lt;SIGNATURE&gt; value identifies the CNG public key algorithm. The following algorithms are supported:</para>
			/// <list type="bullet">
			/// <item>L"RSA" (BCRYPT_RSA_ALGORITHM)</item>
			/// <item>L"DSA" (BCRYPT_DSA_ALGORITHM)</item>
			/// <item>L"ECDSA" (SSL_ECDSA_ALGORITHM)</item>
			/// </list>
			/// <para>The &lt;HASH&gt; value identifies the CNG hash algorithm. The following algorithms are supported:</para>
			/// <list type="bullet">
			/// <item>L"MD5" (BCRYPT_MD5_ALGORITHM)</item>
			/// <item>L"SHA1" (BCRYPT_SHA1_ALGORITHM)</item>
			/// <item>L"SHA256" (BCRYPT_SHA256_ALGORITHM)</item>
			/// <item>L"SHA384" (BCRYPT_SHA384_ALGORITHM)</item>
			/// <item>L"SHA512" (BCRYPT_SHA512_ALGORITHM)</item>
			/// </list>
			/// <para>The following is an example:</para>
			/// <para>L"RSA/SHA256;RSA/SHA256"</para>
			/// <para>This property is explicitly set by the verify revocation functions.</para>
			/// </summary>
			[CorrespondingType(typeof(CRYPTOAPI_BLOB), CorrespondingAction.GetSet)]
			CERT_ISSUER_CHAIN_SIGN_HASH_CNG_ALG_PROP_ID = 95,

			/// <summary>
			/// <para>
			/// The length, in bits, of the public key in the CRL issuer certificate. This property is also applicable to an OCSP that has
			/// been converted to a CRL.
			/// </para>
			/// <para>This property is explicitly set by the verify revocation functions.</para>
			/// <para><strong>Windows 8 and Windows Server 2012:</strong> Support for this property begins.</para>
			/// </summary>
			[CorrespondingType(typeof(uint), CorrespondingAction.GetSet)]
			CERT_ISSUER_PUB_KEY_BIT_LENGTH_PROP_ID = 94,

			/// <summary>This property sets the MD5 hash of the public key associated with the private key used to sign this certificate.</summary>
			[CorrespondingType(typeof(CRYPTOAPI_BLOB), CorrespondingAction.GetSet)]
			CERT_ISSUER_PUBLIC_KEY_MD5_HASH_PROP_ID = 24,

			/// <summary>The CRYPT_DATA_BLOB structure contains the MD5 hash of the issuer name and serial number from this certificate.</summary>
			[CorrespondingType(typeof(CRYPTOAPI_BLOB), CorrespondingAction.GetSet)]
			CERT_ISSUER_SERIAL_NUMBER_MD5_HASH_PROP_ID = 28,

			/// <summary></summary>
			CERT_KEY_CLASSIFICATION_PROP_ID = 120,

			/// <summary>
			/// The structure specifies the certificate's private key. It contains both the HCRYPTPROV and key specification for the private
			/// key. For more information about the hCryptProv member and dwFlags settings, see CERT_KEY_PROV_HANDLE_PROP_ID, later in this topic.
			/// </summary>
			[CorrespondingType(typeof(CERT_KEY_CONTEXT), CorrespondingAction.GetSet)]
			CERT_KEY_CONTEXT_PROP_ID = 5,

			/// <summary>
			/// If nonexistent, searches for the szOID_SUBJECT_KEY_IDENTIFIER extension. If that fails, a SHA1 hash is done on the
			/// certificate's SubjectPublicKeyInfo member to produce the identifier values.
			/// </summary>
			[CorrespondingType(typeof(byte[]), CorrespondingAction.GetSet)]
			CERT_KEY_IDENTIFIER_PROP_ID = 20,

			/// <summary>
			/// The HCRYPTPROV handle for the certificate's private key is set. The hCryptProv member of the CERT_KEY_CONTEXT structure is
			/// updated if it exists. If it does not exist, it is created with dwKeySpec and initialized by CERT_KEY_PROV_INFO_PROP_ID. If
			/// CERT_STORE_NO_CRYPT_RELEASE_FLAG is not set, the hCryptProv value is implicitly released either when the property is set to
			/// NULL or on the final freeing of the CERT_CONTEXT structure.
			/// </summary>
			[CorrespondingType(typeof(HCRYPTPROV), CorrespondingAction.GetSet)]
			CERT_KEY_PROV_HANDLE_PROP_ID = 1,

			/// <summary>The structure specifies the certificate's private key.</summary>
			[CorrespondingType(typeof(CRYPT_KEY_PROV_INFO), CorrespondingAction.GetSet)]
			CERT_KEY_PROV_INFO_PROP_ID = 2,

			/// <summary></summary>
			CERT_KEY_REPAIR_ATTEMPTED_PROP_ID = 103,

			/// <summary>
			/// A DWORD value specifying the private key obtained from CERT_KEY_CONTEXT_PROP_ID property if it exists. Otherwise, if
			/// CERT_KEY_PROV_INFO_PROP_ID exists, it is the source of the dwKeySpec.
			/// </summary>
			[CorrespondingType(typeof(uint), CorrespondingAction.GetSet)]
			CERT_KEY_SPEC_PROP_ID = 6,

			/// <summary>The MD5 hash. You can compute the hash by using the CryptHashCertificate function.</summary>
			[CorrespondingType(typeof(CRYPTOAPI_BLOB), CorrespondingAction.GetSet)]
			CERT_MD5_HASH_PROP_ID = 4,

			/// <summary>This property sets the NCRYPT_KEY_HANDLE for the certificate private key and sets the dwKeySpec to CERT_NCRYPT_KEY_SPEC.</summary>
			[CorrespondingType(typeof(NCrypt.NCRYPT_KEY_HANDLE), CorrespondingAction.GetSet)]
			CERT_NCRYPT_KEY_HANDLE_PROP_ID = 78,

			/// <summary>Sets the handle of the CNG key associated with the certificate.</summary>
			[CorrespondingType(typeof(HANDLE), CorrespondingAction.GetSet)]
			CERT_NCRYPT_KEY_HANDLE_TRANSFER_PROP_ID = 99,

			/// <summary>Reserved</summary>
			CERT_NEW_KEY_PROP_ID = 74,

			/// <summary>The ASN.1 encoded CERT_ALT_NAME_INFO structure on a CTL.</summary>
			[CorrespondingType(typeof(CRYPTOAPI_BLOB), CorrespondingAction.GetSet)]
			CERT_NEXT_UPDATE_LOCATION_PROP_ID = 10,

			/// <summary>Reserved</summary>
			CERT_NO_AUTO_EXPIRE_CHECK_PROP_ID = 77,

			/// <summary></summary>
			CERT_NO_EXPIRE_NOTIFICATION_PROP_ID = 97,

			/// <summary></summary>
			CERT_NONCOMPLIANT_ROOT_URL_PROP_ID = 123,

			/// <summary></summary>
			CERT_NOT_BEFORE_ENHKEY_USAGE_PROP_ID = 127,

			/// <summary></summary>
			CERT_NOT_BEFORE_FILETIME_PROP_ID = 126,

			/// <summary>Reserved</summary>
			CERT_OCSP_CACHE_PREFIX_PROP_ID = 75,

			/// <summary></summary>
			CERT_OCSP_MUST_STAPLE_PROP_ID = 121,

			/// <summary>
			/// This property sets the encoded online certificate status protocol (OCSP) response from a CERT_SERVER_OCSP_RESPONSE_CONTEXT
			/// for this certificate.
			/// </summary>
			[CorrespondingType(typeof(CRYPTOAPI_BLOB), CorrespondingAction.GetSet)]
			CERT_OCSP_RESPONSE_PROP_ID = 70,

			/// <summary></summary>
			CERT_PIN_SHA256_HASH_PROP_ID = 124,

			/// <summary>
			/// This property is implicitly set by calling the CertGetCertificateContextProperty function.
			/// <para>
			/// Windows Server 2008 R2, Windows 7, Windows Server 2008, Windows Vista, Windows Server 2003 and Windows XP: This identifier
			/// is not supported.
			/// </para>
			/// </summary>
			[CorrespondingType(typeof(CRYPTOAPI_BLOB), CorrespondingAction.GetSet)]
			CERT_PUB_KEY_CNG_ALG_BIT_LENGTH_PROP_ID = 93,

			/// <summary>
			/// This property is used with public keys that support algorithm parameter inheritance. The data BLOB contains the
			/// ASN.1-encoded PublicKey Algorithm parameters. For DSS, these are parameters encoded by using the CryptEncodeObject function.
			/// This is used only if CMS_PKCS7 is defined.
			/// </summary>
			[CorrespondingType(typeof(CRYPTOAPI_BLOB), CorrespondingAction.GetSet)]
			CERT_PUBKEY_ALG_PARA_PROP_ID = 22,

			/// <summary>Reserved</summary>
			CERT_PUBKEY_HASH_RESERVED_PROP_ID = 8,

			/// <summary>
			/// The CRYPT_DATA_BLOB structure specifies the name of a file that contains the private key associated with the certificate's
			/// public key. Inside the CRYPT_DATA_BLOB structure, the pbData member is a pointer to a null-terminated Unicode wide-character
			/// string, and the cbData member indicates the length of the string.
			/// </summary>
			[CorrespondingType(typeof(CRYPTOAPI_BLOB), CorrespondingAction.GetSet)]
			CERT_PVK_FILE_PROP_ID = 12,

			/// <summary>This property specifies the hash of the renewed certificate.</summary>
			[CorrespondingType(typeof(CRYPTOAPI_BLOB), CorrespondingAction.GetSet)]
			CERT_RENEWAL_PROP_ID = 64,

			/// <summary>
			/// The CRYPT_DATA_BLOB structure contains a null-terminated Unicode string that contains the DNS computer name for the
			/// origination of the certificate context request.
			/// </summary>
			[CorrespondingType(typeof(CRYPTOAPI_BLOB), CorrespondingAction.GetSet)]
			CERT_REQUEST_ORIGINATOR_PROP_ID = 71,

			/// <summary>
			/// Returns a pointer to an encoded CERT_POLICIES_INFO structure that contains the application policies of the root certificate
			/// for the context. This property can be decoded by using the CryptDecodeObject function with the lpszStructType parameter set
			/// to X509_CERT_POLICIES and the dwCertEncodingType parameter set to a combination of X509_ASN_ENCODING bitwise OR PKCS_7_ASN_ENCODING.
			/// </summary>
			[CorrespondingType(typeof(CRYPTOAPI_BLOB), CorrespondingAction.GetSet)]
			CERT_ROOT_PROGRAM_CERT_POLICIES_PROP_ID = 83,

			/// <summary></summary>
			CERT_ROOT_PROGRAM_CHAIN_POLICIES_PROP_ID = 105,

			/// <summary>Reserved</summary>
			CERT_ROOT_PROGRAM_NAME_CONSTRAINTS_PROP_ID = 84,

			/// <summary></summary>
			CERT_SCARD_PIN_ID_PROP_ID = 90,

			/// <summary></summary>
			CERT_SCARD_PIN_INFO_PROP_ID = 91,

			/// <summary></summary>
			CERT_SCEP_CA_CERT_PROP_ID = 111,

			/// <summary></summary>
			CERT_SCEP_ENCRYPT_HASH_CNG_ALG_PROP_ID = 114,

			/// <summary></summary>
			CERT_SCEP_FLAGS_PROP_ID = 115,

			/// <summary></summary>
			CERT_SCEP_GUID_PROP_ID = 116,

			/// <summary></summary>
			CERT_SCEP_NONCE_PROP_ID = 113,

			/// <summary></summary>
			CERT_SCEP_RA_ENCRYPTION_CERT_PROP_ID = 110,

			/// <summary></summary>
			CERT_SCEP_RA_SIGNATURE_CERT_PROP_ID = 109,

			/// <summary></summary>
			CERT_SCEP_SERVER_CERTS_PROP_ID = 108,

			/// <summary></summary>
			CERT_SCEP_SIGNER_CERT_PROP_ID = 112,

			/// <summary></summary>
			CERT_SEND_AS_TRUSTED_ISSUER_PROP_ID = 102,

			/// <summary></summary>
			CERT_SERIAL_CHAIN_PROP_ID = 119,

			/// <summary></summary>
			CERT_SERIALIZABLE_KEY_CONTEXT_PROP_ID = 117,

			/// <summary>The SHA1 hash. You can compute the hash by using CryptHashCertificate.</summary>
			[CorrespondingType(typeof(CRYPTOAPI_BLOB), CorrespondingAction.GetSet)]
			CERT_SHA1_HASH_PROP_ID = 3,

			/// <summary></summary>
			CERT_SHA256_HASH_PROP_ID = 107,

			/// <summary>
			/// <para>
			/// The L”&lt;SIGNATURE&gt;/&lt;HASH&gt;” string representing the certificate signature. The &lt;SIGNATURE&gt; value identifies
			/// the CNG public key algorithm. The following algorithms are supported:
			/// </para>
			/// <list type="bullet">
			/// <item>L"RSA" (BCRYPT_RSA_ALGORITHM)</item>
			/// <item>L"DSA" (BCRYPT_DSA_ALGORITHM)</item>
			/// <item>L"ECDSA" (SSL_ECDSA_ALGORITHM)</item>
			/// </list>
			/// <para>The &lt;HASH&gt; value identifies the CNG hash algorithm. The following algorithms are supported:</para>
			/// <list type="bullet">
			/// <item>L"MD5" (BCRYPT_MD5_ALGORITHM)</item>
			/// <item>L"SHA1" (BCRYPT_SHA1_ALGORITHM)</item>
			/// <item>L"SHA256" (BCRYPT_SHA256_ALGORITHM)</item>
			/// <item>L"SHA384" (BCRYPT_SHA384_ALGORITHM)</item>
			/// <item>L"SHA512" (BCRYPT_SHA512_ALGORITHM)</item>
			/// </list>
			/// <para>The following are common examples:</para>
			/// <list type="bullet">
			/// <item>L”RSA/SHA1”</item>
			/// <item>L”RSA/SHA256”</item>
			/// <item>L”ECDSA/SHA256”</item>
			/// </list>
			/// <para>This property is also applicable to an OCSP response that has been converted to a CRL.</para>
			/// <para>This property is explicitly set by the verify revocation functions.</para>
			/// <para><strong>Windows 8 and Windows Server 2012</strong>: Support for this property begins.</para>
			/// </summary>
			[CorrespondingType(typeof(CRYPTOAPI_BLOB), CorrespondingAction.GetSet)]
			CERT_SIGN_HASH_CNG_ALG_PROP_ID = 89,

			/// <summary>
			/// The signature hash. If the hash does not exist, it is computed with CryptHashToBeSigned. The length of the hash is 20 bytes
			/// for SHA and 16 for MD5.
			/// </summary>
			[CorrespondingType(typeof(CRYPTOAPI_BLOB), CorrespondingAction.GetSet)]
			CERT_SIGNATURE_HASH_PROP_ID = 15,

			/// <summary>This property sets the smart card data property of a smart card certificate context.</summary>
			[CorrespondingType(typeof(CRYPTOAPI_BLOB), CorrespondingAction.GetSet)]
			CERT_SMART_CARD_DATA_PROP_ID = 16,

			/// <summary></summary>
			CERT_SMART_CARD_READER_NON_REMOVABLE_PROP_ID = 106,

			/// <summary></summary>
			CERT_SMART_CARD_READER_PROP_ID = 101,

			/// <summary>This property sets the information property of a smart card root certificate context.</summary>
			[CorrespondingType(typeof(CRYPTOAPI_BLOB), CorrespondingAction.GetSet)]
			CERT_SMART_CARD_ROOT_INFO_PROP_ID = 76,

			/// <summary>Reserved</summary>
			CERT_SOURCE_LOCATION_PROP_ID = 72,

			/// <summary>Reserved</summary>
			CERT_SOURCE_URL_PROP_ID = 73,

			/// <summary>Reserved</summary>
			CERT_SUBJECT_DISABLE_CRL_PROP_ID = 86,

			/// <summary>
			/// This property sets the subject information access extension of the certificate context as an encoded
			/// CERT_SUBJECT_INFO_ACCESS structure.
			/// </summary>
			[CorrespondingType(typeof(CRYPTOAPI_BLOB), CorrespondingAction.GetSet)]
			CERT_SUBJECT_INFO_ACCESS_PROP_ID = 80,

			/// <summary>Returns an MD5 hash of the encoded subject name of the certificate context.</summary>
			[CorrespondingType(typeof(CRYPTOAPI_BLOB), CorrespondingAction.GetSet)]
			CERT_SUBJECT_NAME_MD5_HASH_PROP_ID = 29,

			/// <summary>Reserved</summary>
			CERT_SUBJECT_OCSP_AUTHORITY_INFO_ACCESS_PROP_ID = 85,

			/// <summary>
			/// This property is implicitly set by calling the CertGetCertificateContextProperty function.
			/// <para>
			/// Windows Server 2008 R2, Windows 7, Windows Server 2008, Windows Vista, Windows Server 2003 and Windows XP: This identifier
			/// is not supported.
			/// </para>
			/// </summary>
			[CorrespondingType(typeof(CRYPTOAPI_BLOB), CorrespondingAction.GetSet)]
			CERT_SUBJECT_PUB_KEY_BIT_LENGTH_PROP_ID = 92,

			/// <summary>This property sets the MD5 hash of this certificate's public key.</summary>
			[CorrespondingType(typeof(CRYPTOAPI_BLOB), CorrespondingAction.GetSet)]
			CERT_SUBJECT_PUBLIC_KEY_MD5_HASH_PROP_ID = 25,
		}

		/// <summary>
		/// The <c>CertEnumCertificateContextProperties</c> function retrieves the first or next extended property associated with a
		/// certificate context. Used in a loop, this function can retrieve in sequence all of the extended properties associated with a
		/// certificate context.
		/// </summary>
		/// <param name="pCertContext">A pointer to the CERT_CONTEXT structure of the certificate containing the properties to be enumerated.</param>
		/// <param name="dwPropId">
		/// <para>
		/// Property number of the last property enumerated. To get the first property, dwPropId is zero. To retrieve subsequent properties,
		/// dwPropId is set to the property number returned by the last call to the function. To enumerate all the properties, function
		/// calls continue until the function returns zero.
		/// </para>
		/// <para>
		/// Applications can call CertGetCertificateContextProperty with the dwPropId returned by this function to retrieve that property's data.
		/// </para>
		/// </param>
		/// <returns>
		/// The return value is a <c>DWORD</c> value that identifies a certificate context's property. The <c>DWORD</c> value returned by
		/// one call of the function can be supplied as the dwPropId in a subsequent call to the function. If there are no more properties
		/// to be enumerated or if the function fails, zero is returned.
		/// </returns>
		/// <remarks>
		/// <para>
		/// CERT_KEY_PROV_HANDLE_PROP_ID and CERT_KEY_SPEC_PROP_ID properties are stored as members of the CERT_KEY_CONTEXT_PROP_ID
		/// property. They are not enumerated individually.
		/// </para>
		/// <para>Examples</para>
		/// <para>See Example C Program: Listing the Certificates in a Store.</para>
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows/win32/api/wincrypt/nf-wincrypt-certenumcertificatecontextproperties DWORD
		// CertEnumCertificateContextProperties( PCCERT_CONTEXT pCertContext, DWORD dwPropId );
		[DllImport(Lib.Crypt32, SetLastError = false, ExactSpelling = true)]
		[PInvokeData("wincrypt.h", MSDNShortId = "b7304ab2-432b-40c0-8014-7f8874fa36fa")]
		public static extern uint CertEnumCertificateContextProperties([In] PCCERT_CONTEXT pCertContext, CertPropId dwPropId);

		/// <summary>
		/// The <c>CertEnumCRLContextProperties</c> function retrieves the first or next extended property associated with a certificate
		/// revocation list (CRL) context. Used in a loop, this function can retrieve in sequence all extended properties associated with a
		/// CRL context.
		/// </summary>
		/// <param name="pCrlContext">A pointer to a CRL_CONTEXT structure.</param>
		/// <param name="dwPropId">
		/// <para>
		/// Property number of the last property enumerated. To get the first property, dwPropId is zero. To retrieve subsequent properties,
		/// dwPropId is set to the property number returned by the last call to the function. To enumerate all the properties, function
		/// calls continue until the function returns zero.
		/// </para>
		/// <para>
		/// Applications can call CertGetCRLContextProperty with the dwPropId returned by this function to retrieve that property's data.
		/// </para>
		/// </param>
		/// <returns>
		/// The return value is a <c>DWORD</c> value that identifies a CRL context's property. The <c>DWORD</c> value returned by one call
		/// of the function can be supplied as the dwPropId in a subsequent call to the function. If there are no more properties to be
		/// enumerated or if the function fails, zero is returned.
		/// </returns>
		// https://docs.microsoft.com/en-us/windows/win32/api/wincrypt/nf-wincrypt-certenumcrlcontextproperties DWORD
		// CertEnumCRLContextProperties( PCCRL_CONTEXT pCrlContext, DWORD dwPropId );
		[DllImport(Lib.Crypt32, SetLastError = false, ExactSpelling = true)]
		[PInvokeData("wincrypt.h", MSDNShortId = "330808ef-9b39-4bd4-ba0b-9e70ec516f33")]
		public static extern uint CertEnumCRLContextProperties([In] PCCRL_CONTEXT pCrlContext, CertPropId dwPropId);

		/// <summary>
		/// The <c>CertEnumCTLContextProperties</c> function retrieves the first or next extended property associated with a certificate
		/// trust list (CTL) context. Used in a loop, this function can retrieve in sequence all extended properties associated with a CTL context.
		/// </summary>
		/// <param name="pCtlContext">A pointer to a CTL_CONTEXT structure.</param>
		/// <param name="dwPropId">
		/// <para>
		/// Property number of the last property enumerated. To get the first property, dwPropId is zero. To retrieve subsequent properties,
		/// dwPropId is set to the property number returned by the last call to the function. To enumerate all the properties, function
		/// calls continue until the function returns zero.
		/// </para>
		/// <para>
		/// Applications can call CertGetCTLContextProperty with the dwPropId returned by this function to retrieved that property's data.
		/// </para>
		/// </param>
		/// <returns>
		/// The return value is a <c>DWORD</c> value that identifies a CTL context's property. The <c>DWORD</c> value returned by one call
		/// of the function can be supplied as the dwPropId in a subsequent call to the function. If there are no more properties to be
		/// enumerated or if the function fails, zero is returned.
		/// </returns>
		// https://docs.microsoft.com/en-us/windows/win32/api/wincrypt/nf-wincrypt-certenumctlcontextproperties DWORD
		// CertEnumCTLContextProperties( PCCTL_CONTEXT pCtlContext, DWORD dwPropId );
		[DllImport(Lib.Crypt32, SetLastError = false, ExactSpelling = true)]
		[PInvokeData("wincrypt.h", MSDNShortId = "f5c9c4cd-bf99-41bf-b13e-f1921b011039")]
		public static extern uint CertEnumCTLContextProperties([In] PCCTL_CONTEXT pCtlContext, CertPropId dwPropId);

		/// <summary>
		/// The <c>CertGetCertificateContextProperty</c> function retrieves the information contained in an extended property of a
		/// certificate context.
		/// </summary>
		/// <param name="pCertContext">A pointer to the CERT_CONTEXT structure of the certificate that contains the property to be retrieved.</param>
		/// <param name="dwPropId">
		/// <para>
		/// The property to be retrieved. Currently defined identifiers and the data type to be returned in pvData are listed in the
		/// following table.
		/// </para>
		/// <para>CERT_ACCESS_STATE_PROP_ID</para>
		/// <para>Data type of pvData: A pointer to a <c>DWORD</c> value.</para>
		/// <para>
		/// Returns a <c>DWORD</c> value that indicates whether write operations to the certificate are persisted. The <c>DWORD</c> value is
		/// not set if the certificate is in a memory store or in a registry-based store that is opened as read-only.
		/// </para>
		/// <para>CERT_AIA_URL_RETRIEVED_PROP_ID</para>
		/// <para>This identifier is reserved.</para>
		/// <para>CERT_ARCHIVED_KEY_HASH_PROP_ID</para>
		/// <para>Data type of pvData: A pointer to an array of <c>BYTE</c> values. The size of this array is specified in the pcbData parameter.</para>
		/// <para>Returns a previously saved encrypted key hash for the certificate context.</para>
		/// <para>CERT_ARCHIVED_PROP_ID</para>
		/// <para>
		/// Data type of pvData: <c>NULL</c>. If the <c>CertGetCertificateContextProperty</c> function returns true, then the specified
		/// property ID exists for the CERT_CONTEXT.
		/// </para>
		/// <para>
		/// Indicates the certificate is skipped during enumerations. A certificate with this property set is found with explicit search
		/// operations, such as those used to find a certificate with a specific hash or a serial number. No data in pvData is associated
		/// with this property.
		/// </para>
		/// <para>CERT_AUTHORITY_INFO_ACCESS_PROP_ID</para>
		/// <para>This identifier is reserved.</para>
		/// <para>CERT_AUTO_ENROLL_PROP_ID</para>
		/// <para>Data type of pvData: A pointer to an array of <c>BYTE</c> values. The size of this array is specified in the pcbData parameter.</para>
		/// <para>Returns a null-terminated Unicode string that names the certificate type for which the certificate has been auto enrolled.</para>
		/// <para>CERT_AUTO_ENROLL_RETRY_PROP_ID</para>
		/// <para>This identifier is reserved.</para>
		/// <para>CERT_BACKED_UP_PROP_ID</para>
		/// <para>This identifier is reserved.</para>
		/// <para>CERT_CA_DISABLE_CRL_PROP_ID</para>
		/// <para>Data type of pvData: A pointer to an array of <c>BYTE</c> values. The size of this array is specified in the pcbData parameter.</para>
		/// <para>
		/// Disables certificate revocation list (CRL) retrieval for certificates used by the certification authority (CA). If the CA
		/// certificate contains this property, it must also include the <c>CERT_CA_OCSP_AUTHORITY_INFO_ACCESS_PROP_ID</c> property.
		/// </para>
		/// <para>CERT_CA_OCSP_AUTHORITY_INFO_ACCESS_PROP_ID</para>
		/// <para>Data type of pvData: A pointer to an array of <c>BYTE</c> values. The size of this array is specified in the pcbData parameter.</para>
		/// <para>
		/// Contains the list of online certificate status protocol (OCSP) URLs to use for certificates issued by the CA certificate. The
		/// array contents are the Abstract Syntax Notation One (ASN.1)-encoded bytes of an <c>X509_AUTHORITY_INFO_ACCESS</c> structure
		/// where <c>pszAccessMethod</c> is set to <c>szOID_PKIX_OCSP</c>.
		/// </para>
		/// <para>CERT_CROSS_CERT_DIST_POINTS_PROP_ID</para>
		/// <para>Data type of pvData: A pointer to an array of <c>BYTE</c> values. The size of this array is specified in the pcbData parameter.</para>
		/// <para>
		/// Location of the cross certificates. Currently, this identifier is only applicable to certificates and not to CRLs or certificate
		/// trust lists (CTLs). The <c>BYTE</c> array contains an ASN.1-encoded CROSS_CERT_DIST_POINTS_INFO structure decoded by using the
		/// CryptDecodeObject function with a X509_CROSS_CERT_DIST_POINTS value for the lpszStuctType parameter.
		/// </para>
		/// <para>CERT_CTL_USAGE_PROP_ID</para>
		/// <para>Data type of pvData: A pointer to an array of <c>BYTE</c> values. The size of this array is specified in the pcbData parameter.</para>
		/// <para>Returns an array of bytes that contain an</para>
		/// </param>
		/// <param name="&#x9;&#x9; ASN.1-encoded &amp;lt;a href=&amp;quot;https://docs.microsoft.com/windows/desktop/api/wincrypt/ns-wincrypt-ctl_usage&amp;quot;&amp;gt;CTL_USAGE&amp;lt;/a&amp;gt; structure.&#xA;">
		/// <para>CERT_DATE_STAMP_PROP_ID</para>
		/// <para>Data type of pvData: A pointer to a <c>FILETIME</c> structure.</para>
		/// <para>Time when the certificate was added to the store.</para>
		/// <para>CERT_DESCRIPTION_PROP_ID</para>
		/// <para>Data type of pvData: A pointer to an array of <c>BYTE</c> values. The size of this array is specified in the pcbData parameter.</para>
		/// <para>Returns the property displayed by the certificate UI. This property allows the user to describe the certificate's use.</para>
		/// <para>CERT_EFS_PROP_ID</para>
		/// <para>This identifier is reserved.</para>
		/// <para>CERT_ENHKEY_USAGE_PROP_ID</para>
		/// <para>Data type of pvData: A pointer to an array of <c>BYTE</c> values. The size of this array is specified in the pcbData parameter.</para>
		/// <para>
		/// Returns an array of bytes that contain an ASN.1-encoded CERT_ENHKEY_USAGE structure. This structure contains an array of
		/// Enhanced Key Usage object identifiers (OIDs), each of which specifies a valid use of the certificate.
		/// </para>
		/// <para>CERT_ENROLLMENT_PROP_ID</para>
		/// <para>Data type of pvData: A pointer to an array of <c>BYTE</c> values. The size of this array is specified in the pcbData parameter.</para>
		/// <para>
		/// Enrollment information of the pending request that contains RequestID, CADNSName, CAName, and DisplayName. The data format is
		/// defined as follows.
		/// </para>
		/// <list type="table">
		/// <listheader>
		/// <term>Bytes</term>
		/// <term>Contents</term>
		/// </listheader>
		/// <item>
		/// <term>First 4 bytes</term>
		/// <term>Pending request ID</term>
		/// </item>
		/// <item>
		/// <term>Next 4 bytes</term>
		/// <term>
		/// CADNSName size, in characters, including the terminating null character, followed by CADNSName string with terminating null character
		/// </term>
		/// </item>
		/// <item>
		/// <term>Next 4 bytes</term>
		/// <term>
		/// CAName size, in characters, including the terminating null character, followed by CAName string with terminating null character
		/// </term>
		/// </item>
		/// <item>
		/// <term>Next 4 bytes</term>
		/// <term>
		/// DisplayName size, in characters, including the terminating null character, followed by DisplayName string with terminating null character
		/// </term>
		/// </item>
		/// </list>
		/// <para>CERT_EXTENDED_ERROR_INFO_PROP_ID</para>
		/// <para>Data type of pvData: A pointer to an array of <c>BYTE</c> values. The size of this array is specified in the pcbData parameter.</para>
		/// <para>Returns a null-terminated Unicode character string that contains extended error information for the certificate context.</para>
		/// <para>CERT_FORTEZZA_DATA_PROP_ID</para>
		/// <para>This identifier is reserved.</para>
		/// <para>CERT_FRIENDLY_NAME_PROP_ID</para>
		/// <para>Data type of pvData: A pointer to an array of <c>BYTE</c> values. The size of this array is specified in the pcbData parameter.</para>
		/// <para>Returns a null-terminated Unicode character string that contains the display name for the certificate.</para>
		/// <para>CERT_HASH_PROP_ID</para>
		/// <para>Data type of pvData: A pointer to an array of <c>BYTE</c> values. The size of this array is specified in the pcbData parameter.</para>
		/// <para>Returns the SHA1 hash. If the hash does not exist, it is computed by using the CryptHashCertificate function.</para>
		/// <para>CERT_HCRYPTPROV_OR_NCRYPT_KEY_HANDLE_PROP_ID</para>
		/// <para>Data type of pvData: A pointer to an HCRYPTPROV_OR_NCRYPT_KEY_HANDLE data type.</para>
		/// <para>Returns either the <c>HCRYPTPROV</c> or <c>NCRYPT_KEY_HANDLE</c> choice.</para>
		/// <para>CERT_HCRYPTPROV_TRANSFER_PROP_ID</para>
		/// <para>
		/// Returns the Cryptography API (CAPI) key handle associated with the certificate. The caller is responsible for freeing the
		/// handle. It will not be freed when the context is freed. The property value is removed after after it is returned. If you call
		/// this property on a context that has a CNG key, <c>CRYPT_E_NOT_FOUND</c> is returned.
		/// </para>
		/// <para>CERT_IE30_RESERVED_PROP_ID</para>
		/// <para>This identifier is reserved.</para>
		/// <para>CERT_ISSUER_PUBLIC_KEY_MD5_HASH_PROP_ID</para>
		/// <para>Data type of pvData: A pointer to an array of <c>BYTE</c> values. The size of this array is specified in the pcbData parameter.</para>
		/// <para>MD5 hash of the public key associated with the private key used to sign this certificate.</para>
		/// <para>CERT_ISSUER_SERIAL_NUMBER_MD5_HASH_PROP_ID</para>
		/// <para>Data type of pvData: A pointer to an array of <c>BYTE</c> values. The size of this array is specified in the pcbData parameter.</para>
		/// <para>MD5 hash of the issuer name and serial number from this certificate.</para>
		/// <para>CERT_KEY_CONTEXT_PROP_ID</para>
		/// <para>Data type of pvData: A pointer to a CERT_KEY_CONTEXT structure.</para>
		/// <para>Returns a CERT_KEY_CONTEXT structure.</para>
		/// <para>CERT_KEY_IDENTIFIER_PROP_ID</para>
		/// <para>Data type of pvData: A pointer to an array of <c>BYTE</c> values. The size of this array is specified in the pcbData parameter.</para>
		/// <para>
		/// If nonexistent, searches for the szOID_SUBJECT_KEY_IDENTIFIER extension. If that fails, a SHA1 hash is done on the certificate's
		/// <c>SubjectPublicKeyInfo</c> member to produce the identifier values.
		/// </para>
		/// <para>CERT_KEY_PROV_HANDLE_PROP_ID</para>
		/// <para>Data type of pvData: A pointer to an HCRYPTPROV value.</para>
		/// <para>Returns the provider handle obtained from CERT_KEY_CONTEXT_PROP_ID.</para>
		/// <para>CERT_KEY_PROV_INFO_PROP_ID</para>
		/// <para>Data type of pvData: A pointer to a CRYPT_KEY_PROV_INFO structure.</para>
		/// <para>Returns a pointer to a CRYPT_KEY_PROV_INFO structure.</para>
		/// <para>CERT_KEY_SPEC_PROP_ID</para>
		/// <para>Data type of pvData: A pointer to a <c>DWORD</c> value.</para>
		/// <para>
		/// Returns a <c>DWORD</c> value that specifies the private key obtained from CERT_KEY_CONTEXT_PROP_ID if it exists. Otherwise, if
		/// CERT_KEY_PROV_INFO_PROP_ID exists, it is the source of the dwKeySpec.
		/// </para>
		/// <para>CERT_MD5_HASH_PROP_ID</para>
		/// <para>Data type of pvData: A pointer to an array of <c>BYTE</c> values. The size of this array is specified in the pcbData parameter.</para>
		/// <para>Returns the MD5 hash. If the hash does not exist, it is computed by using the CryptHashCertificate function.</para>
		/// <para>CERT_NCRYPT_KEY_HANDLE_PROP_ID</para>
		/// <para>Data type of pvData: A pointer to an <c>NCRYPT_KEY_HANDLE</c> data type.</para>
		/// <para>Returns a <c>CERT_NCRYPT_KEY_SPEC</c> choice where applicable.</para>
		/// <para>CERT_NCRYPT_KEY_HANDLE_TRANSFER_PROP_ID</para>
		/// <para>
		/// Returns the CNG key handle associated with the certificate. The caller is responsible for freeing the handle. It will not be
		/// freed when the context is freed. The property value is removed after after it is returned. If you call this property on a
		/// context that has a legacy (CAPI) key, <c>CRYPT_E_NOT_FOUND</c> is returned.
		/// </para>
		/// <para>CERT_NEW_KEY_PROP_ID</para>
		/// <para>This identifier is reserved.</para>
		/// <para>CERT_NEXT_UPDATE_LOCATION_PROP_ID</para>
		/// <para>Data type of pvData: A pointer to an array of <c>BYTE</c> values. The size of this array is specified in the pcbData parameter.</para>
		/// <para>Returns the ASN.1-encoded CERT_ALT_NAME_INFO structure.</para>
		/// <para>CERT_NEXT_UPDATE_LOCATION_PROP_ID is currently used only with CTLs.</para>
		/// <para>CERT_NO_AUTO_EXPIRE_CHECK_PROP_ID</para>
		/// <para>This identifier is reserved.</para>
		/// <para>CERT_OCSP_CACHE_PREFIX_PROP_ID</para>
		/// <para>This identifier is reserved.</para>
		/// <para>CERT_OCSP_RESPONSE_PROP_ID</para>
		/// <para>Data type of pvData: A pointer to an array of <c>BYTE</c> values. The size of this array is specified in the pcbData parameter.</para>
		/// <para>Returns an encoded OCSP response for this certificate.</para>
		/// <para>CERT_PUB_KEY_CNG_ALG_BIT_LENGTH_PROP_ID</para>
		/// <para>Data type of pvData: Pointer to a null-terminated Unicode string.</para>
		/// <para>
		/// Returns an L”&lt;PUBKEY&gt;/&lt;BITLENGTH&gt;” string representing the certificate’s public key algorithm and bit length. The
		/// following &lt;PUBKEY&gt; algorithms are supported:
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
		/// <para>Windows 8 and Windows Server 2012:</para>
		/// <para>Support for this property begins.</para>
		/// <para>CERT_PUBKEY_ALG_PARA_PROP_ID</para>
		/// <para>Data type of pvData: A pointer to an array of <c>BYTE</c> values. The size of this array is specified in the pcbData parameter.</para>
		/// <para>
		/// For public keys that support algorithm parameter inheritance, returns the ASN.1-encoded PublicKey Algorithm parameters. For
		/// Digital Signature Standard (DSS), returns the parameters encoded by using the CryptEncodeObject function. This property is used
		/// only if CMS_PKCS7 is defined.
		/// </para>
		/// <para>CERT_PUBKEY_HASH_RESERVED_PROP_ID</para>
		/// <para>This identifier is reserved.</para>
		/// <para>CERT_PVK_FILE_PROP_ID</para>
		/// <para>Data type of pvData: A pointer to an array of <c>BYTE</c> values. The size of this array is specified in the pcbData parameter.</para>
		/// <para>
		/// Returns a null-terminated Unicode wide character string that contains the file name that contains the private key associated
		/// with the certificate's public key.
		/// </para>
		/// <para>CERT_RENEWAL_PROP_ID</para>
		/// <para>Data type of pvData: A pointer to an array of <c>BYTE</c> values. The size of this array is specified in the pcbData parameter.</para>
		/// <para>Returns the hash of the renewed certificate.</para>
		/// <para>CERT_REQUEST_ORIGINATOR_PROP_ID</para>
		/// <para>Data type of pvData: A pointer to an array of <c>BYTE</c> values. The size of this array is specified in the pcbData parameter.</para>
		/// <para>
		/// Returns a null-terminated Unicode string that contains the DNS computer name for the origination of the certificate context request.
		/// </para>
		/// <para>CERT_ROOT_PROGRAM_CERT_POLICIES_PROP_ID</para>
		/// <para>Data type of pvData: A pointer to an array of <c>BYTE</c> values. The size of this array is specified in the pcbData parameter.</para>
		/// <para>
		/// Returns a pointer to an encoded CERT_POLICIES_INFO structure that contains the application policies of the root certificate for
		/// the context. This property can be decoded by using the CryptDecodeObject function with the lpszStructType parameter set to
		/// <c>X509_CERT_POLICIES</c> and the dwCertEncodingType parameter set to a combination of <c>X509_ASN_ENCODING</c> bitwise <c>OR</c><c>PKCS_7_ASN_ENCODING</c>.
		/// </para>
		/// <para>CERT_ROOT_PROGRAM_NAME_CONSTRAINTS_PROP_ID</para>
		/// <para>This identifier is reserved.</para>
		/// <para>CERT_SHA1_HASH_PROP_ID</para>
		/// <para>Data type of pvData: A pointer to an array of <c>BYTE</c> values. The size of this array is specified in the pcbData parameter.</para>
		/// <para>Returns the SHA1 hash. If the hash does not exist, it is computed by using the CryptHashCertificate function.</para>
		/// <para>CERT_SIGN_HASH_CNG_ALG_PROP_ID</para>
		/// <para>Data type of pvData: Pointer to a null-terminated Unicode string.</para>
		/// <para>
		/// Returns the L”&lt;SIGNATURE&gt;/&lt;HASH&gt;” string representing the certificate signature. The &lt;SIGNATURE&gt; value
		/// identifies the CNG public key algorithm. The following algorithms are supported:
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
		/// <para>The</para>
		/// <para>&lt;HASH&gt;</para>
		/// <para>value identifies the CNG hash algorithm. The following algorithms are supported:</para>
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
		/// <term>L"SHA384" (BCRYPT_SHA384_ALGORITHM)</term>
		/// </item>
		/// <item>
		/// <term>L"SHA512" (BCRYPT_SHA512_ALGORITHM)</term>
		/// </item>
		/// </list>
		/// <para>The following are common examples:</para>
		/// <list type="bullet">
		/// <item>
		/// <term>L"RSA/SHA1"</term>
		/// </item>
		/// <item>
		/// <term>L"RSA/SHA256"</term>
		/// </item>
		/// <item>
		/// <term>L"ECDSA/SHA256"</term>
		/// </item>
		/// </list>
		/// <para>Windows 7 and Windows Server 2008 R2:</para>
		/// <para>Support for this property begins.</para>
		/// <para>CERT_SIGNATURE_HASH_PROP_ID</para>
		/// <para>Data type of pvData: A pointer to an array of <c>BYTE</c> values. The size of this array is specified in the pcbData parameter.</para>
		/// <para>
		/// Returns the signature hash. If the hash does not exist, it is computed by using the CryptHashToBeSigned function. The length of
		/// the hash is 20 bytes for SHA and 16 for MD5.
		/// </para>
		/// <para>CERT_SMART_CARD_DATA_PROP_ID</para>
		/// <para>Data type of pvData: A pointer to an array of <c>BYTE</c> values. The size of this array is specified in the pcbData parameter.</para>
		/// <para>
		/// Returns a pointer to encoded smart card data. Prior to calling <c>CertGetCertificateContextProperty</c>, you can use this
		/// constant to retrieve a smart card certificate by using the CertFindCertificateInStore function with the pvFindPara parameter set
		/// to <c>CERT_SMART_CARD_DATA_PROP_ID</c> and the dwFindType parameter set to <c>CERT_FIND_PROPERTY</c>.
		/// </para>
		/// <para>CERT_SMART_CARD_ROOT_INFO_PROP_ID</para>
		/// <para>Data type of pvData: A pointer to an array of <c>BYTE</c> values. The size of this array is specified in the pcbData parameter.</para>
		/// <para>Returns a pointer to an encoded CRYPT_SMART_CARD_ROOT_INFO structure.</para>
		/// <para>CERT_SOURCE_LOCATION_PROP_ID</para>
		/// <para>This identifier is reserved.</para>
		/// <para>CERT_SOURCE_URL_PROP_ID</para>
		/// <para>This identifier is reserved.</para>
		/// <para>CERT_SUBJECT_DISABLE_CRL_PROP_ID</para>
		/// <para>This identifier is reserved.</para>
		/// <para>CERT_SUBJECT_INFO_ACCESS_PROP_ID</para>
		/// <para>Data type of pvData: A pointer to an array of <c>BYTE</c> values. The size of this array is specified in the pcbData parameter.</para>
		/// <para>Returns the subject information access extension of the certificate context as an encoded CERT_SUBJECT_INFO_ACCESS structure.</para>
		/// <para>CERT_SUBJECT_NAME_MD5_HASH_PROP_ID</para>
		/// <para>Data type of pvData: A pointer to an array of <c>BYTE</c> values. The size of this array is specified in the pcbData parameter.</para>
		/// <para>Returns an MD5 hash of the encoded subject name of the certificate context.</para>
		/// <para>CERT_SUBJECT_OCSP_AUTHORITY_INFO_ACCESS_PROP_ID</para>
		/// <para>This identifier is reserved.</para>
		/// <para>CERT_SUBJECT_PUB_KEY_BIT_LENGTH_PROP_ID</para>
		/// <para>Data type of pvData: Pointer to a <c>DWORD</c> value.</para>
		/// <para>Returns the length, in bits, of the public key in the certificate.</para>
		/// <para><c>Windows 8 and Windows Server 2012:</c> Support for this property begins.</para>
		/// <para>CERT_SUBJECT_PUBLIC_KEY_MD5_HASH_PROP_ID</para>
		/// <para>Data type of pvData: A pointer to an array of <c>BYTE</c> values. The size of this array is specified in the pcbData parameter.</para>
		/// <para>Returns the MD5 hash of this certificate's public key.</para>
		/// <para>For all user-defined property identifiers, pvData points to an array of <c>BYTE</c> values.</para>
		/// <para>For more information about each property identifier, see the documentation on the dwPropId parameter in CertSetCertificateContextProperty.</para>
		/// </param>
		/// <param name="pvData">
		/// <para>
		/// A pointer to a buffer to receive the data as determined by dwPropId. Structures pointed to by members of a structure returned
		/// are also returned following the base structure. Therefore, the size contained in pcbData often exceeds the size of the base structure.
		/// </para>
		/// <para>
		/// This parameter can be <c>NULL</c> to set the size of the information for memory allocation purposes. For more information, see
		/// Retrieving Data of Unknown Length.
		/// </para>
		/// </param>
		/// <param name="pcbData">
		/// <para>
		/// A pointer to a <c>DWORD</c> value that specifies the size, in bytes, of the buffer pointed to by the pvData parameter. When the
		/// function returns, the <c>DWORD</c> value contains the number of bytes to be stored in the buffer.
		/// </para>
		/// <para>
		/// To obtain the required size of a buffer at run time, pass <c>NULL</c> for the pvData parameter, and set the value pointed to by
		/// this parameter to zero. If the pvData parameter is not <c>NULL</c> and the size specified in pcbData is less than the number of
		/// bytes required to contain the data, the function fails, GetLastError returns <c>ERROR_MORE_DATA</c>, and the required size is
		/// placed in the variable pointed to by the pcbData parameter.
		/// </para>
		/// <para>
		/// <c>Note</c> When processing the data returned in the buffer, applications must use the actual size of the data returned. The
		/// actual size can be slightly smaller than the size of the buffer specified on input. (On input, buffer sizes are usually
		/// specified large enough to ensure that the largest possible output data fits in the buffer.) On output, the variable pointed to
		/// by this parameter is updated to reflect the actual size of the data copied to the buffer.
		/// </para>
		/// </param>
		/// <returns>
		/// <para>If the function succeeds, the function returns <c>TRUE</c>.</para>
		/// <para>If the function fails, it returns <c>FALSE</c>. For extended error information, call GetLastError.</para>
		/// <para>Some possible error codes follow.</para>
		/// <list type="table">
		/// <listheader>
		/// <term>Return code</term>
		/// <term>Description</term>
		/// </listheader>
		/// <item>
		/// <term>CRYPT_E_NOT_FOUND</term>
		/// <term>The certificate does not have the specified property.</term>
		/// </item>
		/// <item>
		/// <term>ERROR_MORE_DATA</term>
		/// <term>
		/// If the buffer specified by the pvData parameter is not large enough to hold the returned data, the function sets the
		/// ERROR_MORE_DATA code and stores the required buffer size, in bytes, in the variable pointed to by pcbData.
		/// </term>
		/// </item>
		/// </list>
		/// <para>Errors from the called function CryptHashCertificate can be propagated to this function.</para>
		/// </returns>
		/// <remarks>
		/// <para>
		/// Properties are not stored inside a certificate. Typically, they are associated with a certificate after the certificate response
		/// is received and then saved with the certificate in the store. For security reasons, we recommend that you validate property
		/// values before saving them and that you save only informational properties such as the <c>CERT_FRIENDLY_NAME_PROP_ID</c> value in
		/// user stores. All other property types should be saved in local computer stores.
		/// </para>
		/// <para>Your code can use a macro to evaluate the class of hash for a certificate context. For more information, see CertSetCertificateContextProperty.</para>
		/// <para>Examples</para>
		/// <para>
		/// For examples that use this function, see Example C Program: Getting and Setting Certificate Properties and Example C Program:
		/// Listing the Certificates in a Store.
		/// </para>
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows/win32/api/wincrypt/nf-wincrypt-certgetcertificatecontextproperty BOOL
		// CertGetCertificateContextProperty( PCCERT_CONTEXT pCertContext, DWORD dwPropId, void *pvData, DWORD *pcbData );
		[DllImport(Lib.Crypt32, SetLastError = true, ExactSpelling = true)]
		[PInvokeData("wincrypt.h", MSDNShortId = "f766db64-3121-4f70-ac83-ce25ee634efa")]
		[return: MarshalAs(UnmanagedType.Bool)]
		public static extern bool CertGetCertificateContextProperty([In] PCCERT_CONTEXT pCertContext, CertPropId dwPropId, [In, Out] IntPtr pvData, ref uint pcbData);

		/// <summary>
		/// The <c>CertGetCRLContextProperty</c> function gets an extended property for the specified certificate revocation list (CRL) context.
		/// </summary>
		/// <param name="pCrlContext">A pointer to the CRL_CONTEXT structure.</param>
		/// <param name="dwPropId">
		/// <para>
		/// Identifies the property to be retrieved. Currently defined identifiers and the data type to be returned in pvData are listed in
		/// the following table.
		/// </para>
		/// <list type="table">
		/// <listheader>
		/// <term>Value</term>
		/// <term>Meaning</term>
		/// </listheader>
		/// <item>
		/// <term>CERT_ACCESS_STATE_PROP_ID</term>
		/// <term>
		/// Data type for pvData: pointer to a DWORD Returns a DWORD value indicating whether write operations to the certificate are
		/// persisted. The DWORD value is not set if the certificate is in a memory store or in a registry-based store that is opened as read-only.
		/// </term>
		/// </item>
		/// <item>
		/// <term>CERT_ARCHIVED_PROP_ID</term>
		/// <term>
		/// Data type for pvData: NULL Indicates the certificate is skipped during enumerations. A certificate with this property set is
		/// found with explicit search operations, such as those used to find a certificate with a specific hash or a serial number. No data
		/// in pvData is associated with this property.
		/// </term>
		/// </item>
		/// <item>
		/// <term>CERT_AUTO_ENROLL_PROP_ID</term>
		/// <term>
		/// Data type for pvData: pointer to a BYTE array Returns a null-terminated Unicode string naming the certificate type for which the
		/// certificate has been auto enrolled.
		/// </term>
		/// </item>
		/// <item>
		/// <term>CERT_CTL_USAGE_PROP_ID</term>
		/// <term>
		/// Data type for pvData: pointer to a BYTE array Returns an array of bytes containing an Abstract Syntax Notation One (ASN.1)
		/// encoded CTL_USAGE structure.
		/// </term>
		/// </item>
		/// <item>
		/// <term>CERT_DESCRIPTION_PROP_ID</term>
		/// <term>
		/// Data type for pvData: pointer to a BYTE array Returns the property displayed by the certificate UI. This property allows the
		/// user to describe the certificate's use.
		/// </term>
		/// </item>
		/// <item>
		/// <term>CERT_ENHKEY_USAGE_PROP_ID</term>
		/// <term>Data type for pvData: Returns an array of bytes containing an ASN.1 encoded CERT_ENHKEY_USAGE structure.</term>
		/// </item>
		/// <item>
		/// <term>CERT_FRIENDLY_NAME_PROP_ID</term>
		/// <term>
		/// Data type for pvData: pointer to a BYTE array Returns a null-terminated Unicode character string that contains the display name
		/// for the CRL.
		/// </term>
		/// </item>
		/// <item>
		/// <term>CERT_ISSUER_CHAIN_PUB_KEY_CNG_ALG_BIT_LENGTH_PROP_ID</term>
		/// <term>
		/// Data type for pvData: Pointer to a null-terminated Unicode string. Returns a string containing a set of
		/// L"&lt;PUBKEY&gt;/&lt;BITLENGTH&gt;" public key algorithm and bit length pairs. The semicolon, L";", is used as the delimiter.
		/// The &lt;PUBKEY&gt; value identifies the CNG public key algorithm. The following algorithms are supported: An
		/// &lt;PUBKEY&gt;/&lt;BITLENGTH&gt; pair is returned for each certificate in the CRL issuer chain excluding the leaf. This property
		/// is only set when an OCSP response with an independent signer chain is converted to a CRL. The following is an example: : L"RSA/2048;RSA/4096"
		/// </term>
		/// </item>
		/// <item>
		/// <term>CERT_ISSUER_CHAIN_SIGN_HASH_CNG_ALG_PROP_ID</term>
		/// <term>
		/// Data type for pvData: Pointer to a null-terminated Unicode string. Returns a string that contains a set of
		/// L"&lt;SIGNATURE&gt;/&lt;HASH&gt;" algorithm pairs. The semicolon, L";", is used as the delimiter between pairs. This property is
		/// set only when an OCSP response is converted to a CRL. For a delegated OCSP signer certificate, only the algorithm pair for the
		/// signer certificate is returned. For an independent OCSP signer certificate chain, an algorithm pair is returned for each
		/// certificate in the chain excluding the root. The &lt;SIGNATURE&gt; value identifies the CNG public key algorithm. The following
		/// algorithms are supported: The &lt;HASH&gt; value identifies the CNG hash algorithm. The following algorithms are supported: The
		/// following shows an example:
		/// </term>
		/// </item>
		/// <item>
		/// <term>CERT_ISSUER_PUB_KEY_BIT_LENGTH_PROP_ID</term>
		/// <term>
		/// Data type for pvData: Pointer to a DWORD value. Returns the length, in bits, of the public key in the CRL issuer certificate.
		/// This property is also applicable to an OCSP response that has been converted to a CRL. Windows 8 and Windows Server 2012:
		/// Support for this property begins.
		/// </term>
		/// </item>
		/// <item>
		/// <term>CERT_KEY_CONTEXT_PROP_ID</term>
		/// <term>Data type for pvData: pointer to a CERT_KEY_CONTEXT Returns a CERT_KEY_CONTEXT structure.</term>
		/// </item>
		/// <item>
		/// <term>CERT_KEY_IDENTIFIER_PROP_ID</term>
		/// <term>
		/// Data type for pvData: pointer to a BYTE array If nonexistent, searches for the szOID_SUBJECT_KEY_IDENTIFIER extension. If that
		/// fails, a SHA1 hash is done on the certificate's SubjectPublicKeyInfo member to produce the identifier values.
		/// </term>
		/// </item>
		/// <item>
		/// <term>CERT_KEY_PROV_HANDLE_PROP_ID</term>
		/// <term>Data type for pvData: pointer to an HCRYPTPROV Returns the provider handle obtained from the CERT_KEY_CONTEXT_PROP_ID.</term>
		/// </item>
		/// <item>
		/// <term>CERT_KEY_PROV_INFO_PROP_ID</term>
		/// <term>Data type for pvData: pointer to a CRYPT_KEY_PROV_INFO Returns a pointer to a CRYPT_KEY_PROV_INFO.</term>
		/// </item>
		/// <item>
		/// <term>CERT_KEY_SPEC_PROP_ID</term>
		/// <term>
		/// Data type for pvData: pointer to a DWORD Returns a DWORD value specifying the private key obtained from CERT_KEY_CONTEXT_PROP_ID
		/// property if it exists. Otherwise, if CERT_KEY_PROV_INFO_PROP_ID exists, it is the source of the dwKeySpec.
		/// </term>
		/// </item>
		/// <item>
		/// <term>CERT_MD5_HASH_PROP_ID</term>
		/// <term>Data type for pvData: pointer to a BYTE array Returns the MD5 hash. If the hash does not exist, it is computed using CryptHashCertificate.</term>
		/// </item>
		/// <item>
		/// <term>CERT_NEXT_UPDATE_LOCATION_PROP_ID</term>
		/// <term>
		/// Data type for pvData: pointer to a BYTE array Returns the ASN.1 encoded CERT_ALT_NAME_INFO structure.
		/// CERT_NEXT_UPDATE_LOCATION_PROP_ID is currently used only with CTLs.
		/// </term>
		/// </item>
		/// <item>
		/// <term>CERT_PVK_FILE_PROP_ID</term>
		/// <term>
		/// Data type for pvData: pointer to a BYTE array Returns a null-terminated Unicode, wide character string specifying the file name
		/// containing the private key associated with the certificate's public key.
		/// </term>
		/// </item>
		/// <item>
		/// <term>CERT_SHA1_HASH_PROP_ID</term>
		/// <term>
		/// Data type for pvData: pointer to a BYTE array Returns the SHA1 hash. If the hash does not exist, it is computed using CryptHashCertificate.
		/// </term>
		/// </item>
		/// <item>
		/// <term>CERT_SIGN_HASH_CNG_ALG_PROP_ID</term>
		/// <term>
		/// Data type of pvData: Pointer to a null-terminated Unicode string. Returns the L”&lt;SIGNATURE&gt;/&lt;HASH&gt;” string
		/// representing the certificate signature. The &lt;SIGNATURE&gt; value identifies the CNG public key algorithm. The following
		/// algorithms are supported: The &lt;HASH&gt; value identifies the CNG hash algorithm. The following algorithms are supported: The
		/// following are common examples: This property is also applicable to an OCSP response that has been converted to a CRL. Windows 8
		/// and Windows Server 2012: Support for this property begins.
		/// </term>
		/// </item>
		/// <item>
		/// <term>CERT_SIGNATURE_HASH_PROP_ID</term>
		/// <term>
		/// Data type for pvData: pointer to a BYTE array Returns the signature hash. If the hash does not exist, it is computed with
		/// CryptHashToBeSigned. The length of the hash is 20 bytes for SHA and 16 for MD5.
		/// </term>
		/// </item>
		/// </list>
		/// <para>
		/// For many property identifiers, pvData points to an array of bytes and not a CRYPT_DATA_BLOB as pointed to by the pvData
		/// parameter in CertSetCRLContextProperty.
		/// </para>
		/// <para>For more information about each property identifier, see the documentation on the dwPropId parameter in CertSetCertificateContextProperty.</para>
		/// </param>
		/// <param name="pvData">
		/// <para>
		/// A pointer to a buffer to receive the data as determined by dwPropId. Structures pointed to by members of a structure returned
		/// are also returned following the base structure. Therefore, the size contained in pcbData often exceed the size of the base structure.
		/// </para>
		/// <para>
		/// This parameter can be <c>NULL</c> to set the size of the information for memory allocation purposes. For more information, see
		/// Retrieving Data of Unknown Length.
		/// </para>
		/// </param>
		/// <param name="pcbData">
		/// <para>
		/// A pointer to a <c>DWORD</c> value specifying the size, in bytes, of the buffer pointed to by the pvData parameter. When the
		/// function returns, the <c>DWORD</c> value contains the number of bytes to be stored in the buffer.
		/// </para>
		/// <para>
		/// <c>Note</c> When processing the data returned in the buffer, applications must use the actual size of the data returned. The
		/// actual size can be slightly smaller than the size of the buffer specified on input. (On input, buffer sizes are usually
		/// specified large enough to ensure that the largest possible output data fits in the buffer.) On output, the variable pointed to
		/// by this parameter is updated to reflect the actual size of the data copied to the buffer.
		/// </para>
		/// </param>
		/// <returns>
		/// <para>If the function succeeds, the return value is <c>TRUE</c>.</para>
		/// <para>If the function fails, the return value is <c>FALSE</c>.</para>
		/// <para>
		/// Note that errors from the called function CryptHashCertificate can be propagated to this function. For extended error
		/// information, call GetLastError. Some possible error codes follow.
		/// </para>
		/// <list type="table">
		/// <listheader>
		/// <term>Return code</term>
		/// <term>Description</term>
		/// </listheader>
		/// <item>
		/// <term>CRYPT_E_NOT_FOUND</term>
		/// <term>The CRL does not have the specified property.</term>
		/// </item>
		/// <item>
		/// <term>ERROR_MORE_DATA</term>
		/// <term>
		/// If the buffer specified by the pvData parameter is not large enough to hold the returned data, the function sets the
		/// ERROR_MORE_DATA code and stores the required buffer size, in bytes, in the variable pointed to by pcbData.
		/// </term>
		/// </item>
		/// </list>
		/// </returns>
		// https://docs.microsoft.com/en-us/windows/win32/api/wincrypt/nf-wincrypt-certgetcrlcontextproperty BOOL CertGetCRLContextProperty(
		// PCCRL_CONTEXT pCrlContext, DWORD dwPropId, void *pvData, DWORD *pcbData );
		[DllImport(Lib.Crypt32, SetLastError = true, ExactSpelling = true)]
		[PInvokeData("wincrypt.h", MSDNShortId = "16c2cc06-28fd-42d9-a377-0df2eaeeae56")]
		[return: MarshalAs(UnmanagedType.Bool)]
		public static extern bool CertGetCRLContextProperty([In] PCCRL_CONTEXT pCrlContext, CertPropId dwPropId, [In, Out] IntPtr pvData, ref uint pcbData);

		/// <summary>The <c>CertGetCTLContextProperty</c> function retrieves an extended property of a certificate trust list (CTL) context.</summary>
		/// <param name="pCtlContext">A pointer to the CTL_CONTEXT structure.</param>
		/// <param name="dwPropId">
		/// <para>
		/// Identifies the property to be retrieved. Currently defined identifiers and the data type to be returned in pvData are listed in
		/// the following table.
		/// </para>
		/// <list type="table">
		/// <listheader>
		/// <term>Value</term>
		/// <term>Meaning</term>
		/// </listheader>
		/// <item>
		/// <term>CERT_ACCESS_STATE_PROP_ID</term>
		/// <term>
		/// Data type for pvData: pointer to a DWORD Returns a DWORD value indicating whether write operations to the certificate are
		/// persisted. The DWORD value is not set if the certificate is in a memory store or in a registry-based store that is opened as read-only.
		/// </term>
		/// </item>
		/// <item>
		/// <term>CERT_ARCHIVED_PROP_ID</term>
		/// <term>
		/// Data type for pvData: NULL Indicates the certificate is skipped during enumerations. A certificate with this property set is
		/// found with explicit search operations, such as those used to find a certificate with a specific hash or a serial number. No data
		/// in pvData is associated with this property.
		/// </term>
		/// </item>
		/// <item>
		/// <term>CERT_AUTO_ENROLL_PROP_ID</term>
		/// <term>
		/// Data type for pvData: pointer to a BYTE array Returns a null-terminated Unicode string naming the certificate type for which the
		/// certificate has been auto enrolled.
		/// </term>
		/// </item>
		/// <item>
		/// <term>CERT_CTL_USAGE_PROP_ID</term>
		/// <term>
		/// Data type for pvData: pointer to a BYTE array Returns an array of bytes containing an Abstract Syntax Notation One (ASN.1)
		/// encoded CTL_USAGE structure.
		/// </term>
		/// </item>
		/// <item>
		/// <term>CERT_DESCRIPTION_PROP_ID</term>
		/// <term>
		/// Data type for pvData: pointer to a BYTE array Returns the property displayed by the certificate UI. This property allows the
		/// user to describe the certificate's use.
		/// </term>
		/// </item>
		/// <item>
		/// <term>CERT_ENHKEY_USAGE_PROP_ID</term>
		/// <term>
		/// Data type for pvData: pointer to a BYTE array Returns an array of bytes containing an ASN.1 encoded CERT_ENHKEY_USAGE structure.
		/// </term>
		/// </item>
		/// <item>
		/// <term>CERT_FRIENDLY_NAME_PROP_ID</term>
		/// <term>
		/// Data type for pvData: pointer to a BYTE array Returns a null-terminated Unicode character string that contains the display name
		/// for the CTL.
		/// </term>
		/// </item>
		/// <item>
		/// <term>CERT_HASH_PROP_ID</term>
		/// <term>
		/// Data type for pvData: pointer to a BYTE array Returns the SHA1 hash. If the hash does not exist, it is computed using CryptHashCertificate.
		/// </term>
		/// </item>
		/// <item>
		/// <term>CERT_KEY_CONTEXT_PROP_ID</term>
		/// <term>Data type for pvData: pointer to a CERT_KEY_CONTEXT Returns a CERT_KEY_CONTEXT structure.</term>
		/// </item>
		/// <item>
		/// <term>CERT_KEY_IDENTIFIER_PROP_ID</term>
		/// <term>
		/// Data type for pvData: pointer to a BYTE array If nonexistent, searches for the szOID_SUBJECT_KEY_IDENTIFIER extension. If that
		/// fails, a SHA1 hash is done on the certificate's SubjectPublicKeyInfo member to produce the identifier values.
		/// </term>
		/// </item>
		/// <item>
		/// <term>CERT_KEY_PROV_HANDLE_PROP_ID</term>
		/// <term>Data type for pvData: pointer to an HCRYPTPROV Returns the provider handle obtained from the CERT_KEY_CONTEXT_PROP_ID.</term>
		/// </item>
		/// <item>
		/// <term>CERT_KEY_PROV_INFO_PROP_ID</term>
		/// <term>Data type for pvData: pointer to a CRYPT_KEY_PROV_INFO structure Returns a pointer to a CRYPT_KEY_PROV_INFO.</term>
		/// </item>
		/// <item>
		/// <term>CERT_KEY_SPEC_PROP_ID</term>
		/// <term>
		/// Data type for pvData: pointer to a DWORD Returns a DWORD value specifying the private key obtained from CERT_KEY_CONTEXT_PROP_ID
		/// property if it exists. Otherwise, if CERT_KEY_PROV_INFO_PROP_ID exists, it is the source of the dwKeySpec.
		/// </term>
		/// </item>
		/// <item>
		/// <term>CERT_MD5_HASH_PROP_ID</term>
		/// <term>Data type for pvData: pointer to a BYTE array Returns the MD5 hash. If the hash does not exist, it is computed using CryptHashCertificate.</term>
		/// </item>
		/// <item>
		/// <term>CERT_NEXT_UPDATE_LOCATION_PROP_ID</term>
		/// <term>
		/// Data type for pvData: pointer to a BYTE array Returns the ASN.1 encoded CERT_ALT_NAME_INFO structure.
		/// CERT_NEXT_UPDATE_LOCATION_PROP_ID is currently used only with CTLs.
		/// </term>
		/// </item>
		/// <item>
		/// <term>CERT_PVK_FILE_PROP_ID</term>
		/// <term>
		/// Data type for pvData: pointer to a BYTE array Returns a null-terminated Unicode, wide character string specifying the file name
		/// containing the private key associated with the certificate's public key.
		/// </term>
		/// </item>
		/// <item>
		/// <term>CERT_SHA1_HASH_PROP_ID</term>
		/// <term>
		/// Data type for pvData: pointer to a BYTE array Returns the SHA1 hash. If the hash does not exist, it is computed using CryptHashCertificate.
		/// </term>
		/// </item>
		/// <item>
		/// <term>CERT_SIGNATURE_HASH_PROP_ID</term>
		/// <term>
		/// Data type for pvData: pointer to a BYTE array Returns the signature hash. If the hash does not exist, it is computed with
		/// CryptHashToBeSigned. The length of the hash is 20 bytes for SHA and 16 for MD5.
		/// </term>
		/// </item>
		/// </list>
		/// <para>
		/// For all other property identifiers, pvData points to an array of bytes and not a CRYPT_DATA_BLOB as pointed to by the pvData
		/// parameter in CertSetCertificateContextProperty.
		/// </para>
		/// <para>
		/// For more information about each property identifier, see the documentation on the dwPropId parameter in
		/// CertSetCertificateContextProperty. CERT_SHA1_HASH_PROP_ID and CERT_NEXT_UPDATE_LOCATION_PROP_ID are the predefined properties of
		/// most interest.
		/// </para>
		/// </param>
		/// <param name="pvData">
		/// <para>
		/// A pointer to a buffer to receive the data as determined by dwPropId. Structures pointed to by members of a structure returned
		/// are also returned following the base structure. Therefore, the size contained in pcbData often exceed the size of the base structure.
		/// </para>
		/// <para>
		/// This parameter can be <c>NULL</c> to set the size of the information for memory allocation purposes. For more information, see
		/// Retrieving Data of Unknown Length.
		/// </para>
		/// </param>
		/// <param name="pcbData">
		/// <para>
		/// A pointer to a <c>DWORD</c> value specifying the size, in bytes, of the buffer pointed to by the pvData parameter. When the
		/// function returns, the <c>DWORD</c> value contains the number of bytes to be stored in the buffer.
		/// </para>
		/// <para>
		/// <c>Note</c> When processing the data returned in the buffer, applications must use the actual size of the data returned. The
		/// actual size can be slightly smaller than the size of the buffer specified on input. (On input, buffer sizes are usually
		/// specified large enough to ensure that the largest possible output data fits in the buffer.) On output, the variable pointed to
		/// by this parameter is updated to reflect the actual size of the data copied to the buffer.
		/// </para>
		/// </param>
		/// <returns>
		/// <para>If the function succeeds, the return value is <c>TRUE</c>.</para>
		/// <para>If the function fails, the return value is <c>FALSE</c>.</para>
		/// <para>
		/// Errors from the called function, CryptHashCertificate, can be propagated to this function. For extended error information, call GetLastError.
		/// </para>
		/// <para>Some possible error codes follow.</para>
		/// <list type="table">
		/// <listheader>
		/// <term>Return code</term>
		/// <term>Description</term>
		/// </listheader>
		/// <item>
		/// <term>CRYPT_E_NOT_FOUND</term>
		/// <term>The CTL does not have the specified property.</term>
		/// </item>
		/// <item>
		/// <term>ERROR_MORE_DATA</term>
		/// <term>
		/// If the buffer specified by the pvData parameter is not large enough to hold the returned data, the function sets the
		/// ERROR_MORE_DATA code and stores the required buffer size, in bytes, in the variable pointed to by pcbData.
		/// </term>
		/// </item>
		/// </list>
		/// </returns>
		// https://docs.microsoft.com/en-us/windows/win32/api/wincrypt/nf-wincrypt-certgetctlcontextproperty BOOL CertGetCTLContextProperty(
		// PCCTL_CONTEXT pCtlContext, DWORD dwPropId, void *pvData, DWORD *pcbData );
		[DllImport(Lib.Crypt32, SetLastError = true, ExactSpelling = true)]
		[PInvokeData("wincrypt.h", MSDNShortId = "16e45fe1-2710-4fa1-82da-c298645d7379")]
		[return: MarshalAs(UnmanagedType.Bool)]
		public static extern bool CertGetCTLContextProperty([In] PCCTL_CONTEXT pCtlContext, CertPropId dwPropId, [In, Out] IntPtr pvData, ref uint pcbData);

		/// <summary>The <c>CertSetCertificateContextProperty</c> function sets an extended property for a specified certificate context.</summary>
		/// <param name="pCertContext">A pointer to a CERT_CONTEXT structure.</param>
		/// <param name="dwPropId">
		/// <para>
		/// The property to be set. The value of dwPropId determines the type and content of the pvData parameter. Currently defined
		/// identifiers and their related pvData types are as follows.
		/// </para>
		/// <para><c>Note</c> CRYPT_HASH_BLOB and CRYPT_DATA_BLOB are described in the CRYPT_INTEGER_BLOB topic.</para>
		/// <para>CERT_ACCESS_STATE_PROP_ID</para>
		/// <para>Data type of pvData: A pointer to a <c>DWORD</c> value.</para>
		/// <para>
		/// Returns a <c>DWORD</c> value that indicates whether write operations to the certificate are persisted. The <c>DWORD</c> value is
		/// not set if the certificate is in a memory store or in a registry-based store that is opened as read-only.
		/// </para>
		/// <para>CERT_AIA_URL_RETRIEVED_PROP_ID</para>
		/// <para>This identifier is reserved.</para>
		/// <para>CERT_ARCHIVED_KEY_HASH_PROP_ID</para>
		/// <para>Data type of pvData: A pointer to a CRYPT_HASH_BLOB structure.</para>
		/// <para>This property saves an encrypted key hash for the certificate context.</para>
		/// <para>CERT_ARCHIVED_PROP_ID</para>
		/// <para>Data type of pvData: A pointer to a CRYPT_DATA_BLOB structure.</para>
		/// <para>
		/// Indicates that the certificate is skipped during enumerations. A certificate with this property set is still found with explicit
		/// search operations, such as finding a certificate with a specific hash or a specific serial number. This property can be set to
		/// the empty BLOB, .
		/// </para>
		/// <para>CERT_AUTHORITY_INFO_ACCESS_PROP_ID</para>
		/// <para>This identifier is reserved.</para>
		/// <para>CERT_AUTO_ENROLL_PROP_ID</para>
		/// <para>Data type of pvData: A pointer to a CRYPT_DATA_BLOB structure.</para>
		/// <para>
		/// A property that is set after a certificate has been enrolled by using Auto Enroll. The CRYPT_DATA_BLOB structure pointed to by
		/// pvData includes a null-terminated Unicode name of the certificate type for which the certificate has been auto enrolled. Any
		/// subsequent calls to Auto Enroll for the certificate checks for this property to determine whether the certificate has been enrolled.
		/// </para>
		/// <para>CERT_AUTO_ENROLL_RETRY_PROP_ID</para>
		/// <para>This identifier is reserved.</para>
		/// <para>CERT_BACKED_UP_PROP_ID</para>
		/// <para>This identifier is reserved.</para>
		/// <para>CERT_CA_DISABLE_CRL_PROP_ID</para>
		/// <para>Data type of pvData: A pointer to a CRYPT_DATA_BLOB structure.</para>
		/// <para>
		/// Disables certificate revocation list (CRL) retrieval for certificates used by the certification authority (CA). If the CA
		/// certificate contains this property, it must also include the <c>CERT_CA_OCSP_AUTHORITY_INFO_ACCESS_PROP_ID</c> property.
		/// </para>
		/// <para>CERT_CA_OCSP_AUTHORITY_INFO_ACCESS_PROP_ID</para>
		/// <para>Data type of pvData: A pointer to a CRYPT_DATA_BLOB structure.</para>
		/// <para>
		/// Contains the list of online certificate status protocol (OCSP) URLs to use for certificates issued by the CA certificate. The
		/// array contents are the Abstract Syntax Notation One (ASN.1)-encoded bytes of an <c>X509_AUTHORITY_INFO_ACCESS</c> structure
		/// where <c>pszAccessMethod</c> is set to <c>szOID_PKIX_OCSP</c>.
		/// </para>
		/// <para>CERT_CROSS_CERT_DIST_POINTS_PROP_ID</para>
		/// <para>Data type of pvData: A pointer to a CRYPT_DATA_BLOB structure.</para>
		/// <para>
		/// Sets the location of the cross certificates. This value is only applicable to certificates and not to certificate revocation
		/// lists (CRLs) or certificate trust lists (CTLs). The CRYPT_DATA_BLOB structure contains an Abstract Syntax Notation One
		/// (ASN.1)-encoded CROSS_CERT_DIST_POINTS_INFO structure that is encoded by using the CryptEncodeObject function with a
		/// X509_CROSS_CERT_DIST_POINTS value for the lpszStuctType parameter.
		/// </para>
		/// <para>CERT_CTL_USAGE_PROP_ID</para>
		/// <para>Data type of pvData: A pointer to a CRYPT_DATA_BLOB structure.</para>
		/// <para>
		/// The CRYPT_DATA_BLOB structure contains an ASN.1-encoded CTL_USAGE structure. This structure is encoded by using the
		/// CryptEncodeObject function with the X509_ENHANCED_KEY_USAGE value set.
		/// </para>
		/// <para>CERT_DATE_STAMP_PROP_ID</para>
		/// <para>Data type of pvData: A pointer to a <c>FILETIME</c> structure.</para>
		/// <para>This property sets the time that the certificate was added to the store.</para>
		/// <para>CERT_DESCRIPTION_PROP_ID</para>
		/// <para>Data type of pvData: A pointer to a CRYPT_DATA_BLOB structure.</para>
		/// <para>
		/// A property that is set and displayed by the certificate UI. This property allows the user to describe the certificate's use.
		/// </para>
		/// <para>CERT_EFS_PROP_ID</para>
		/// <para>This identifier is reserved.</para>
		/// <para>CERT_ENHKEY_USAGE_PROP_ID</para>
		/// <para>Data type of pvData: A pointer to a CRYPT_DATA_BLOB structure.</para>
		/// <para>
		/// A property that indicates that the pvData parameter points to a CRYPT_DATA_BLOB structure that contains an ASN.1-encoded
		/// CERT_ENHKEY_USAGE structure. This structure is encoded by using the CryptEncodeObject function with the X509_ENHANCED_KEY_USAGE
		/// value set.
		/// </para>
		/// <para>CERT_ENROLLMENT_PROP_ID</para>
		/// <para>Data type of pvData: A pointer to a CRYPT_DATA_BLOB structure.</para>
		/// <para>
		/// Enrollment information of the pending request that contains RequestID, CADNSName, CAName, and DisplayName. The data format is
		/// defined as follows.
		/// </para>
		/// <list type="table">
		/// <listheader>
		/// <term>Bytes</term>
		/// <term>Contents</term>
		/// </listheader>
		/// <item>
		/// <term>First 4 bytes</term>
		/// <term>Pending request ID</term>
		/// </item>
		/// <item>
		/// <term>Next 4 bytes</term>
		/// <term>
		/// CADNSName size, in characters, including the terminating null character, followed by CADNSName string with terminating null character
		/// </term>
		/// </item>
		/// <item>
		/// <term>Next 4 bytes</term>
		/// <term>
		/// CAName size, in characters, including the terminating null character, followed by CAName string with terminating null character
		/// </term>
		/// </item>
		/// <item>
		/// <term>Next 4 bytes</term>
		/// <term>
		/// DisplayName size, in characters, including the terminating null character, followed by DisplayName string with terminating null character
		/// </term>
		/// </item>
		/// </list>
		/// <para>CERT_EXTENDED_ERROR_INFO_PROP_ID</para>
		/// <para>Data type of pvData: A pointer to a CRYPT_DATA_BLOB structure.</para>
		/// <para>This property sets a string that contains extended error information for the certificate context.</para>
		/// <para>CERT_FORTEZZA_DATA_PROP_ID</para>
		/// <para>This identifier is reserved.</para>
		/// <para>CERT_FRIENDLY_NAME_PROP_ID</para>
		/// <para>Data type of pvData: A pointer to a CRYPT_DATA_BLOB structure.</para>
		/// <para>The CRYPT_DATA_BLOB structure contains the display name of the certificate.</para>
		/// <para>CERT_HASH_PROP_ID</para>
		/// <para>Data type of pvData: A pointer to a CRYPT_DATA_BLOB structure.</para>
		/// <para>This property is implicitly set by a call to the CertGetCertificateContextProperty function.</para>
		/// <para>CERT_HCRYPTPROV_OR_NCRYPT_KEY_HANDLE_PROP_ID</para>
		/// <para>Data type of pvData: A pointer to an HCRYPTPROV_OR_NCRYPT_KEY_HANDLE data type.</para>
		/// <para>
		/// This property calls NCryptIsKeyHandle to determine whether this is an <c>NCRYPT_KEY_HANDLE</c>. For an <c>NCRYPT_KEY_HANDLE</c>,
		/// sets <c>CERT_NCRYPT_KEY_HANDLE_PROP_ID</c>; otherwise, it sets <c>CERT_KEY_PROV_HANDLE_PROP_ID</c>.
		/// </para>
		/// <para>CERT_HCRYPTPROV_TRANSFER_PROP_ID</para>
		/// <para>Sets the handle of the CAPI key associated with the certificate.</para>
		/// <para>CERT_IE30_RESERVED_PROP_ID</para>
		/// <para>This identifier is reserved.</para>
		/// <para>CERT_ISSUER_PUBLIC_KEY_MD5_HASH_PROP_ID</para>
		/// <para>Data type of pvData: A pointer to a CRYPT_DATA_BLOB structure.</para>
		/// <para>This property sets the MD5 hash of the public key associated with the private key used to sign this certificate.</para>
		/// <para>CERT_ISSUER_SERIAL_NUMBER_MD5_HASH_PROP_ID</para>
		/// <para>Data type of pvData: A pointer to a CRYPT_DATA_BLOB structure.</para>
		/// <para>The CRYPT_DATA_BLOB structure contains the MD5 hash of the issuer name and serial number from this certificate.</para>
		/// <para>CERT_KEY_CONTEXT_PROP_ID</para>
		/// <para>Data type of pvData: A pointer to a CERT_KEY_CONTEXT structure.</para>
		/// <para>
		/// The structure specifies the certificate's private key. It contains both the HCRYPTPROV and key specification for the private
		/// key. For more information about the <c>hCryptProv</c> member and dwFlags settings, see CERT_KEY_PROV_HANDLE_PROP_ID, later in
		/// this topic.
		/// </para>
		/// <para>
		/// <c>Note</c> More CERT_KEY_CONTEXT structure members can be added for this property. If so, the <c>cbSize</c> member value will
		/// be adjusted accordingly. The <c>cbSize</c> member must be set to the size of the <c>CERT_KEY_CONTEXT</c> structure.
		/// </para>
		/// <para>CERT_KEY_IDENTIFIER_PROP_ID</para>
		/// <para>Data type of pvData: A pointer to a CRYPT_DATA_BLOB structure.</para>
		/// <para>This property is typically implicitly set by a call to the CertGetCertificateContextProperty function.</para>
		/// <para>CERT_KEY_PROV_HANDLE_PROP_ID</para>
		/// <para>Data type of pvData: A HCRYPTPROV value.</para>
		/// <para>
		/// The HCRYPTPROV handle for the certificate's private key is set. The <c>hCryptProv</c> member of the CERT_KEY_CONTEXT structure
		/// is updated if it exists. If it does not exist, it is created with <c>dwKeySpec</c> and initialized by
		/// CERT_KEY_PROV_INFO_PROP_ID. If CERT_STORE_NO_CRYPT_RELEASE_FLAG is not set, the <c>hCryptProv</c> value is implicitly released
		/// either when the property is set to <c>NULL</c> or on the final freeing of the CERT_CONTEXT structure.
		/// </para>
		/// <para>CERT_KEY_PROV_INFO_PROP_ID</para>
		/// <para>Data type of pvData: A pointer to a CRYPT_KEY_PROV_INFO structure.</para>
		/// <para>The structure specifies the certificate's private key.</para>
		/// <para>CERT_KEY_SPEC_PROP_ID</para>
		/// <para>Data type of pvData: A pointer to a <c>DWORD</c> value.</para>
		/// <para>
		/// The <c>DWORD</c> value that specifies the private key. The <c>dwKeySpec</c> member of the CERT_KEY_CONTEXT structure is updated
		/// if it exists. If it does not, it is created with <c>hCryptProv</c> set to zero.
		/// </para>
		/// <para>CERT_MD5_HASH_PROP_ID</para>
		/// <para>Data type of pvData: A pointer to a CRYPT_HASH_BLOB structure.</para>
		/// <para>This property is implicitly set by a call to the CertGetCertificateContextProperty function.</para>
		/// <para>CERT_NCRYPT_KEY_HANDLE_PROP_ID</para>
		/// <para>Data type of pvData: A pointer to an <c>NCRYPT_KEY_HANDLE</c> data type.</para>
		/// <para>This property sets the <c>NCRYPT_KEY_HANDLE</c> for the certificate private key and sets the dwKeySpec to <c>CERT_NCRYPT_KEY_SPEC</c>.</para>
		/// <para>CERT_NCRYPT_KEY_HANDLE_TRANSFER_PROP_ID</para>
		/// <para>Sets the handle of the CNG key associated with the certificate.</para>
		/// <para>CERT_NEW_KEY_PROP_ID</para>
		/// <para>This identifier is reserved.</para>
		/// <para>CERT_NEXT_UPDATE_LOCATION_PROP_ID</para>
		/// <para>Data type of pvData: A pointer to a CRYPT_DATA_BLOB structure.</para>
		/// <para>
		/// The CRYPT_DATA_BLOB structure contains an ASN.1-encoded CERT_ALT_NAME_INFO structure that is encoded by using the
		/// CryptEncodeObject function with the X509_ALTERNATE_NAME value set.
		/// </para>
		/// <para>CERT_NEXT_UPDATE_LOCATION_PROP_ID is currently used only with CTLs.</para>
		/// <para>CERT_NO_AUTO_EXPIRE_CHECK_PROP_ID</para>
		/// <para>This identifier is reserved.</para>
		/// <para>CERT_OCSP_CACHE_PREFIX_PROP_ID</para>
		/// <para>This identifier is reserved.</para>
		/// <para>CERT_OCSP_RESPONSE_PROP_ID</para>
		/// <para>Data type of pvData: A pointer to a CRYPT_DATA_BLOB structure.</para>
		/// <para>
		/// This property sets the encoded online certificate status protocol (OCSP) response from a CERT_SERVER_OCSP_RESPONSE_CONTEXT for
		/// this certificate.
		/// </para>
		/// <para>CERT_PUB_KEY_CNG_ALG_BIT_LENGTH_PROP_ID</para>
		/// <para>Data type of pvData: Pointer to a CRYPT_DATA_BLOB structure.</para>
		/// <para>This property is implicitly set by calling the CertGetCertificateContextProperty function.</para>
		/// <para>
		/// <c>Windows Server 2008 R2, Windows 7, Windows Server 2008, Windows Vista, Windows Server 2003 and Windows XP:</c> This
		/// identifier is not supported.
		/// </para>
		/// <para>CERT_PUBKEY_ALG_PARA_PROP_ID</para>
		/// <para>Data type of pvData: A pointer to a CRYPT_DATA_BLOB structure.</para>
		/// <para>
		/// This property is used with public keys that support algorithm parameter inheritance. The data BLOB contains the ASN.1-encoded
		/// PublicKey Algorithm parameters. For DSS, these are parameters encoded by using the CryptEncodeObject function. This is used only
		/// if CMS_PKCS7 is defined.
		/// </para>
		/// <para>CERT_PUBKEY_HASH_RESERVED_PROP_ID</para>
		/// <para>This identifier is reserved.</para>
		/// <para>CERT_PVK_FILE_PROP_ID</para>
		/// <para>Data type of pvData: A pointer to a CRYPT_DATA_BLOB structure.</para>
		/// <para>
		/// The CRYPT_DATA_BLOB structure specifies the name of a file that contains the private key associated with the certificate's
		/// public key. Inside the <c>CRYPT_DATA_BLOB</c> structure, the <c>pbData</c> member is a pointer to a null-terminated Unicode
		/// wide-character string, and the <c>cbData</c> member indicates the length of the string.
		/// </para>
		/// <para>CERT_RENEWAL_PROP_ID</para>
		/// <para>Data type of pvData: A pointer to a CRYPT_DATA_BLOB structure.</para>
		/// <para>This property specifies the hash of the renewed certificate.</para>
		/// <para>CERT_REQUEST_ORIGINATOR_PROP_ID</para>
		/// <para>Data type of pvData: A pointer to a CRYPT_DATA_BLOB structure.</para>
		/// <para>
		/// The CRYPT_DATA_BLOB structure contains a null-terminated Unicode string that contains the DNS computer name for the origination
		/// of the certificate context request.
		/// </para>
		/// <para>CERT_ROOT_PROGRAM_CERT_POLICIES_PROP_ID</para>
		/// <para>Data type of pvData: A pointer to a CRYPT_DATA_BLOB structure.</para>
		/// <para>
		/// Returns a pointer to an encoded CERT_POLICIES_INFO structure that contains the application policies of the root certificate for
		/// the context. This property can be decoded by using the CryptDecodeObject function with the lpszStructType parameter set to
		/// <c>X509_CERT_POLICIES</c> and the dwCertEncodingType parameter set to a combination of <c>X509_ASN_ENCODING</c> bitwise <c>OR</c><c>PKCS_7_ASN_ENCODING</c>.
		/// </para>
		/// <para>CERT_ROOT_PROGRAM_NAME_CONSTRAINTS_PROP_ID</para>
		/// <para>This identifier is reserved.</para>
		/// <para>CERT_SIGN_HASH_CNG_ALG_PROP_ID</para>
		/// <para>Data type of pvData: Pointer to a CRYPT_DATA_BLOB structure.</para>
		/// <para>This property is implicitly set by calling the CertGetCertificateContextProperty function.</para>
		/// <para>
		/// <c>Windows Server 2008 R2, Windows 7, Windows Server 2008, Windows Vista, Windows Server 2003 and Windows XP:</c> This
		/// identifier is not supported.
		/// </para>
		/// <para>CERT_SHA1_HASH_PROP_ID</para>
		/// <para>Data type of pvData: A pointer to a CRYPT_HASH_BLOB structure.</para>
		/// <para>This property is implicitly set by a call to the CertGetCertificateContextProperty function.</para>
		/// <para>CERT_SIGNATURE_HASH_PROP_ID</para>
		/// <para>Data type of pvData: A pointer to a CRYPT_HASH_BLOB structure.</para>
		/// <para>
		/// If a signature hash does not exist, it is computed by using the CryptHashToBeSigned function. pvData points to an existing or
		/// computed hash. Usually, the length of the hash is 20 bytes for SHA and 16 for MD5.
		/// </para>
		/// <para>CERT_SMART_CARD_DATA_PROP_ID</para>
		/// <para>Data type of pvData: A pointer to a CRYPT_DATA_BLOB structure.</para>
		/// <para>This property sets the smart card data property of a smart card certificate context.</para>
		/// <para>CERT_SMART_CARD_ROOT_INFO_PROP_ID</para>
		/// <para>Data type of pvData: A pointer to a CRYPT_DATA_BLOB structure.</para>
		/// <para>This property sets the information property of a smart card root certificate context.</para>
		/// <para>CERT_SOURCE_LOCATION_PROP_ID</para>
		/// <para>This identifier is reserved.</para>
		/// <para>CERT_SOURCE_URL_PROP_ID</para>
		/// <para>This identifier is reserved.</para>
		/// <para>CERT_SUBJECT_DISABLE_CRL_PROP_ID</para>
		/// <para>This identifier is reserved.</para>
		/// <para>CERT_SUBJECT_INFO_ACCESS_PROP_ID</para>
		/// <para>Data type of pvData: A pointer to a CRYPT_DATA_BLOB structure.</para>
		/// <para>
		/// This property sets the subject information access extension of the certificate context as an encoded CERT_SUBJECT_INFO_ACCESS structure.
		/// </para>
		/// <para>CERT_SUBJECT_NAME_MD5_HASH_PROP_ID</para>
		/// <para>Data type of pvData: A pointer to a CRYPT_DATA_BLOB structure.</para>
		/// <para>Returns an MD5 hash of the encoded subject name of the certificate context.</para>
		/// <para>CERT_SUBJECT_OCSP_AUTHORITY_INFO_ACCESS_PROP_ID</para>
		/// <para>This identifier is reserved.</para>
		/// <para>CERT_SUBJECT_PUB_KEY_BIT_LENGTH_PROP_ID</para>
		/// <para>Data type of pvData: Pointer to a CRYPT_DATA_BLOB structure.</para>
		/// <para>This property is implicitly set by calling the CertGetCertificateContextProperty function.</para>
		/// <para>
		/// <c>Windows Server 2008 R2, Windows 7, Windows Server 2008, Windows Vista, Windows Server 2003 and Windows XP:</c> This
		/// identifier is not supported.
		/// </para>
		/// <para>CERT_SUBJECT_PUBLIC_KEY_MD5_HASH_PROP_ID</para>
		/// <para>Data type of pvData: A pointer to a CRYPT_DATA_BLOB structure.</para>
		/// <para>This property sets the MD5 hash of this certificate's public key.</para>
		/// <para>pvData is a pointer to a CRYPT_DATA_BLOB structure.</para>
		/// <para>
		/// The user can define additional dwPropId types by using <c>DWORD</c> values from <c>CERT_FIRST_USER_PROP_ID</c> to
		/// <c>CERT_LAST_USER_PROP_ID</c>. For all user-defined dwPropId types, pvData points to an encoded CRYPT_DATA_BLOB structure.
		/// </para>
		/// </param>
		/// <param name="dwFlags">
		/// <para>
		/// CERT_STORE_NO_CRYPT_RELEASE_FLAG can be set for the CERT_KEY_PROV_HANDLE_PROP_ID or CERT_KEY_CONTEXT_PROP_ID dwPropId properties.
		/// </para>
		/// <para>
		/// If the CERT_SET_PROPERTY_IGNORE_PERSIST_ERROR_FLAG value is set, any provider-write errors are ignored and the cached context's
		/// properties are always set.
		/// </para>
		/// <para>If CERT_SET_PROPERTY_INHIBIT_PERSIST_FLAG is set, any context property set is not persisted.</para>
		/// </param>
		/// <param name="pvData">
		/// <para>A pointer to a data type determined by the value of dwPropId.</para>
		/// <para><c>Note</c> For any dwPropId, setting pvData to <c>NULL</c> deletes the property.</para>
		/// </param>
		/// <returns>
		/// <para>If the function succeeds, the function returns <c>TRUE</c>.</para>
		/// <para>
		/// If the function fails, the function returns <c>FALSE</c>. For extended error information, call GetLastError. One possible error
		/// code is the following.
		/// </para>
		/// <list type="table">
		/// <listheader>
		/// <term>Return code</term>
		/// <term>Description</term>
		/// </listheader>
		/// <item>
		/// <term>E_INVALIDARG</term>
		/// <term>
		/// The property is not valid. The identifier specified was greater than 0x0000FFFF, or, for the CERT_KEY_CONTEXT_PROP_ID property,
		/// a cbSize member that is not valid was specified in the CERT_KEY_CONTEXT structure.
		/// </term>
		/// </item>
		/// </list>
		/// </returns>
		/// <remarks>
		/// <para>If a property already exists, its old value is replaced.</para>
		/// <para>
		/// Your code can use a macro to evaluate the class of hash for a certificate context. The Wincrypt.h header defines the following
		/// macros for this purpose. These macros are used internally by the <c>CertSetCertificateContextProperty</c> function.
		/// </para>
		/// <para>
		/// <c>IS_CERT_HASH_PROP_ID(X)</c><c>IS_PUBKEY_HASH_PROP_ID(X)</c><c>IS_CHAIN_HASH_PROP_ID(X)</c> Each macro takes the dwPropId (X)
		/// value as input and evaluates to a Boolean value. The following table shows the dwPropId values that evaluate to <c>TRUE</c> for
		/// each macro.
		/// </para>
		/// <list type="table">
		/// <listheader>
		/// <term>Macro</term>
		/// <term>Evaluates to TRUE if dwPropId is</term>
		/// </listheader>
		/// <item>
		/// <term>IS_CERT_HASH_PROP_ID(dwPropId)</term>
		/// <term>CERT_SHA1_HASH_PROP_ID, CERT_MD5_HASH_PROP_ID, or CERT_SIGNATURE_HASH_PROP_ID</term>
		/// </item>
		/// <item>
		/// <term>IS_PUBKEY_HASH_PROP_ID(dwPropId)</term>
		/// <term>CERT_ISSUER_PUBLIC_KEY_MD5_HASH_PROP_ID or CERT_SUBJECT_PUBLIC_KEY_MD5_HASH_PROP_ID</term>
		/// </item>
		/// <item>
		/// <term>IS_CHAIN_HASH_PROP_ID(dwPropId)</term>
		/// <term>
		/// CERT_ISSUER_PUBLIC_KEY_MD5_HASH_PROP_ID, CERT_SUBJECT_PUBLIC_KEY_MD5_HASH_PROP_ID, CERT_ISSUER_SERIAL_NUMBER_MD5_HASH_PROP_ID,
		/// or CERT_SUBJECT_NAME_MD5_HASH_PROP_ID
		/// </term>
		/// </item>
		/// </list>
		/// <para>
		/// The <c>IS_STRONG_SIGN_PROP_ID(x)</c> macro evaluates to <c>TRUE</c> if the <c>CERT_SIGN_HASH_CNG_ALG_PROP_ID</c>,
		/// <c>CERT_SUBJECT_PUB_KEY_BIT_LENGTH_PROP_ID</c>, or <c>CERT_PUB_KEY_CNG_ALG_BIT_LENGTH_PROP_ID</c> properties are set in the
		/// dwPropId parameter.
		/// </para>
		/// <para>Examples</para>
		/// <para>For an example that uses this function, see Example C Program: Getting and Setting Certificate Properties.</para>
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows/win32/api/wincrypt/nf-wincrypt-certsetcertificatecontextproperty BOOL
		// CertSetCertificateContextProperty( PCCERT_CONTEXT pCertContext, DWORD dwPropId, DWORD dwFlags, const void *pvData );
		[DllImport(Lib.Crypt32, SetLastError = true, ExactSpelling = true)]
		[PInvokeData("wincrypt.h", MSDNShortId = "b4a0c66d-997f-49cb-935a-9187320037f1")]
		[return: MarshalAs(UnmanagedType.Bool)]
		public static extern bool CertSetCertificateContextProperty([In] PCCERT_CONTEXT pCertContext, CertPropId dwPropId, uint dwFlags, [In, Optional] IntPtr pvData);

		/// <summary>
		/// The <c>CertSetCRLContextProperty</c> function sets an extended property for the specified certificate revocation list (CRL) context.
		/// </summary>
		/// <param name="pCrlContext">A pointer to the CRL_CONTEXT structure.</param>
		/// <param name="dwPropId">
		/// <para>
		/// Identifies the property to be set. The value of dwPropId determines the type and content of the pvData parameter. Currently
		/// defined identifiers and the data type to be returned in pvData are listed in the following table.
		/// </para>
		/// <para>Usually, only the following properties are set:</para>
		/// <list type="bullet">
		/// <item>
		/// <term>CERT_HASH_PROP_ID</term>
		/// </item>
		/// <item>
		/// <term>CERT_SHA1_HASH_PROP_ID</term>
		/// </item>
		/// <item>
		/// <term>CERT_MD5_HASH_PROP_ID</term>
		/// </item>
		/// <item>
		/// <term>CERT_SIGNATURE_HASH_PROP_ID</term>
		/// </item>
		/// </list>
		/// <list type="table">
		/// <listheader>
		/// <term>Value</term>
		/// <term>Meaning</term>
		/// </listheader>
		/// <item>
		/// <term>CERT_ACCESS_STATE_PROP_ID</term>
		/// <term>
		/// Data type for pvData: pointer to a DWORD Sets a DWORD value indicating whether write operations to the certificate are
		/// persisted. The DWORD value is not set if the certificate is in a memory store or in a registry-based store that is opened as read-only.
		/// </term>
		/// </item>
		/// <item>
		/// <term>CERT_ARCHIVED_PROP_ID</term>
		/// <term>
		/// Data type for pvData: NULL Indicates the certificate is skipped during enumerations. A certificate with this property set is
		/// found with explicit search operations, such as those used to find a certificate with a specific hash or a serial number. No data
		/// in pvData is associated with this property.
		/// </term>
		/// </item>
		/// <item>
		/// <term>CERT_AUTO_ENROLL_PROP_ID</term>
		/// <term>
		/// Data type for pvData: pointer to a BYTE array Sets a null-terminated Unicode string naming the certificate type for which the
		/// certificate has been auto enrolled.
		/// </term>
		/// </item>
		/// <item>
		/// <term>CERT_CTL_USAGE_PROP_ID</term>
		/// <term>
		/// Data type for pvData: pointer to a BYTE array Sets an array of bytes containing an Abstract Syntax Notation One (ASN.1) encoded
		/// CTL_USAGE structure.
		/// </term>
		/// </item>
		/// <item>
		/// <term>CERT_DESCRIPTION_PROP_ID</term>
		/// <term>
		/// Data type for pvData: pointer to a BYTE array Sets the property displayed by the certificate UI. This property allows the user
		/// to describe the certificate's use.
		/// </term>
		/// </item>
		/// <item>
		/// <term>CERT_ENHKEY_USAGE_PROP_ID</term>
		/// <term>Data type for pvData: Sets an array of bytes containing an ASN.1 encoded CERT_ENHKEY_USAGE structure.</term>
		/// </item>
		/// <item>
		/// <term>CERT_FRIENDLY_NAME_PROP_ID</term>
		/// <term>
		/// Data type for pvData: pointer to a BYTE array Sets a null-terminated Unicode character string that contains the display name for
		/// the CRL.
		/// </term>
		/// </item>
		/// <item>
		/// <term>CERT_ISSUER_CHAIN_PUB_KEY_CNG_ALG_BIT_LENGTH_PROP_ID</term>
		/// <term>
		/// Data type for pvData: Pointer to a CRYPT_DATA_BLOB structure. Sets a string containing a set of
		/// L"&lt;PUBKEY&gt;/&lt;BITLENGTH&gt;" public key algorithm and bit length pairs. The semicolon, L";", is used as the delimiter.
		/// The &lt;PUBKEY&gt; value identifies the CNG public key algorithm. The following algorithms are supported: A
		/// &lt;PUBKEY&gt;/&lt;BITLENGTH&gt; pair is set for each certificate in the CRL issuer chain excluding the leaf. This property can
		/// be set when an OCSP response with an independent signer chain is converted to a CRL. The following is an example: : L"RSA/2048;RSA/4096"
		/// </term>
		/// </item>
		/// <item>
		/// <term>CERT_ISSUER_CHAIN_SIGN_HASH_CNG_ALG_PROP_ID</term>
		/// <term>
		/// Data type for pvData: Pointer to a CRYPT_DATA_BLOB structure. Sets a string that contains a set of
		/// L"&lt;SIGNATURE&gt;/&lt;HASH&gt;" algorithm pairs. The semicolon, L";", is used as the delimiter between pairs. This property is
		/// set only when an OCSP response is converted to a CRL. For a delegated OCSP signer certificate, only the algorithm pair for the
		/// signer certificate is returned. For an independent OCSP signer certificate chain, an algorithm pair is returned for each
		/// certificate in the chain excluding the root. The &lt;SIGNATURE&gt; value identifies the CNG public key algorithm. The following
		/// algorithms are supported: The &lt;HASH&gt; value identifies the CNG hash algorithm. The following algorithms are supported: The
		/// following is an example: This property is explicitly set by the verify revocation functions.
		/// </term>
		/// </item>
		/// <item>
		/// <term>CERT_ISSUER_PUB_KEY_BIT_LENGTH_PROP_ID</term>
		/// <term>
		/// Data type for pvData: Pointer to a CRYPT_DATA_BLOB structure. Sets the length, in bits, of the public key in the CRL issuer
		/// certificate. This property is also applicable to an OCSP that has been converted to a CRL. This property is explicitly set by
		/// the verify revocation functions. Windows 8 and Windows Server 2012: Support for this property begins.
		/// </term>
		/// </item>
		/// <item>
		/// <term>CERT_KEY_CONTEXT_PROP_ID</term>
		/// <term>Data type for pvData: pointer to a CERT_KEY_CONTEXT Sets a CERT_KEY_CONTEXT structure.</term>
		/// </item>
		/// <item>
		/// <term>CERT_KEY_IDENTIFIER_PROP_ID</term>
		/// <term>Data type for pvData: pointer to a BYTE array</term>
		/// </item>
		/// <item>
		/// <term>CERT_KEY_PROV_HANDLE_PROP_ID</term>
		/// <term>Data type for pvData: pointer to an HCRYPTPROV Sets the provider handle obtained from the CERT_KEY_CONTEXT_PROP_ID.</term>
		/// </item>
		/// <item>
		/// <term>CERT_KEY_PROV_INFO_PROP_ID</term>
		/// <term>Data type for pvData: pointer to a CRYPT_KEY_PROV_INFO Sets a pointer to a CRYPT_KEY_PROV_INFO structure.</term>
		/// </item>
		/// <item>
		/// <term>CERT_KEY_SPEC_PROP_ID</term>
		/// <term>
		/// Data type for pvData: pointer to a DWORD Sets a DWORD value specifying the private key obtained from CERT_KEY_CONTEXT_PROP_ID
		/// property if it exists. Otherwise, if CERT_KEY_PROV_INFO_PROP_ID exists, it is the source of the dwKeySpec.
		/// </term>
		/// </item>
		/// <item>
		/// <term>CERT_MD5_HASH_PROP_ID</term>
		/// <term>
		/// Data type for pvData: pointer to a BYTE array Sets the MD5 hash. You can compute the hash by using the CryptHashCertificate function.
		/// </term>
		/// </item>
		/// <item>
		/// <term>CERT_NEXT_UPDATE_LOCATION_PROP_ID</term>
		/// <term>Data type for pvData: pointer to a BYTE array Sets the ASN.1 encoded CERT_ALT_NAME_INFO structure on a CTL.</term>
		/// </item>
		/// <item>
		/// <term>CERT_PVK_FILE_PROP_ID</term>
		/// <term>
		/// Data type for pvData: pointer to a BYTE array Sets a null-terminated Unicode, wide character string specifying the name of the
		/// file that contains the private key associated with the certificate's public key.
		/// </term>
		/// </item>
		/// <item>
		/// <term>CERT_SHA1_HASH_PROP_ID</term>
		/// <term>Data type for pvData: pointer to a BYTE array Sets the SHA1 hash. You can compute the hash by using CryptHashCertificate.</term>
		/// </item>
		/// <item>
		/// <term>CERT_SIGN_HASH_CNG_ALG_PROP_ID</term>
		/// <term>
		/// Data type of pvData: Pointer to a CRYPT_DATA_BLOB structure. Sets the L”&lt;SIGNATURE&gt;/&lt;HASH&gt;” string representing the
		/// certificate signature. The &lt;SIGNATURE&gt; value identifies the CNG public key algorithm. The following algorithms are
		/// supported: The &lt;HASH&gt; value identifies the CNG hash algorithm. The following algorithms are supported: The following are
		/// common examples: This property is also applicable to an OCSP response that has been converted to a CRL. This property is
		/// explicitly set by the verify revocation functions. Windows 8 and Windows Server 2012: Support for this property begins.
		/// </term>
		/// </item>
		/// <item>
		/// <term>CERT_SIGNATURE_HASH_PROP_ID</term>
		/// <term>
		/// Data type for pvData: pointer to a BYTE array Sets the signature hash. If the hash does not exist, it is computed with
		/// CryptHashToBeSigned. The length of the hash is 20 bytes for SHA and 16 for MD5.
		/// </term>
		/// </item>
		/// </list>
		/// <para>
		/// The user can define additional dwPropId types by using <c>DWORD</c> values from CERT_FIRST_USER_PROP_ID to
		/// CERT_LAST_USER_PROP_ID. For all user-defined dwPropId types, pvData points to an encoded CRYPT_DATA_BLOB.
		/// </para>
		/// <para>For all the other property identifiers, pvData points to an encoded CRYPT_DATA_BLOB structure.</para>
		/// </param>
		/// <param name="dwFlags">
		/// <para>
		/// CERT_STORE_NO_CRYPT_RELEASE_FLAG can be set for the CERT_KEY_PROV_HANDLE_PROP_ID or CERT_KEY_CONTEXT_PROP_ID dwPropId properties.
		/// </para>
		/// <para>
		/// If the CERT_SET_PROPERTY_IGNORE_PERSIST_ERROR_FLAG value is set, any provider-write errors are ignored and the cached context's
		/// properties are always set.
		/// </para>
		/// <para>If the CERT_SET_PROPERTY_INHIBIT_PERSIST_FLAG is set, any property set is not persisted.</para>
		/// </param>
		/// <param name="pvData">
		/// <para>A pointer to a data type that is determined by the value passed in dwPropId.</para>
		/// <para><c>Note</c> For any dwPropId, setting pvData to <c>NULL</c> deletes the property.</para>
		/// </param>
		/// <returns>
		/// <para>If the function succeeds, the return value is <c>TRUE</c>.</para>
		/// <para>
		/// If the function fails, the return value is <c>FALSE</c>. For extended error information, call GetLastError. One possible error
		/// code is the following.
		/// </para>
		/// <list type="table">
		/// <listheader>
		/// <term>Return code</term>
		/// <term>Description</term>
		/// </listheader>
		/// <item>
		/// <term>E_INVALIDARG</term>
		/// <term>
		/// The property is not valid. The identifier specified was greater than 0x0000FFFF, or, for the CERT_KEY_CONTEXT_PROP_ID property,
		/// a cbSize member that is not valid was specified in the CERT_KEY_CONTEXT structure.
		/// </term>
		/// </item>
		/// </list>
		/// </returns>
		/// <remarks>
		/// <para>If a property already exists, its old value is replaced.</para>
		/// <para>Examples</para>
		/// <para>For an example that uses this function, see Example C Program: Getting and Setting Certificate Properties.</para>
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows/win32/api/wincrypt/nf-wincrypt-certsetcrlcontextproperty BOOL CertSetCRLContextProperty(
		// PCCRL_CONTEXT pCrlContext, DWORD dwPropId, DWORD dwFlags, const void *pvData );
		[DllImport(Lib.Crypt32, SetLastError = true, ExactSpelling = true)]
		[PInvokeData("wincrypt.h", MSDNShortId = "7e4a0a39-ce55-4171-9b66-31c1c28d895f")]
		[return: MarshalAs(UnmanagedType.Bool)]
		public static extern bool CertSetCRLContextProperty([In] PCCRL_CONTEXT pCrlContext, CertPropId dwPropId, uint dwFlags, [In, Optional] IntPtr pvData);

		/// <summary>
		/// The <c>CertSetCTLContextProperty</c> function sets an extended property for the specified certificate trust list (CTL) context.
		/// </summary>
		/// <param name="pCtlContext">A pointer to the CTL_CONTEXT structure.</param>
		/// <param name="dwPropId">
		/// <para>
		/// Identifies the property to be set. The value of dwPropId determines the type and content of the pvData parameter. Currently
		/// defined identifiers and their related pvData types are as follows.
		/// </para>
		/// <list type="table">
		/// <listheader>
		/// <term>Value</term>
		/// <term>Meaning</term>
		/// </listheader>
		/// <item>
		/// <term>CERT_ARCHIVED_PROP_ID</term>
		/// <term>
		/// Data type of pvData: NULL Indicates the certificate is skipped during enumerations. A certificate with this property set is
		/// still found with explicit search operations—such as finding a certificate with a specific hash or a specific serial number.
		/// </term>
		/// </item>
		/// <item>
		/// <term>CERT_AUTO_ENROLL_PROP_ID</term>
		/// <term>
		/// Data type of pvData: pointer to a CRYPT_DATA_BLOB Property set after a certificate has been enrolled using Auto Enroll. The
		/// CRYPT_DATA_BLOB structure pointed to by pvData includes a null-terminated, Unicode name of the certificate type for which the
		/// certificates has been auto enrolled. Any subsequent calls to Auto Enroll for the certificate checks for this property to
		/// determine whether the certificate has been enrolled.
		/// </term>
		/// </item>
		/// <item>
		/// <term>CERT_CTL_USAGE_PROP_ID</term>
		/// <term>
		/// Data type of pvData: pointer to a CRYPT_DATA_BLOB pvData points to a CRYPT_DATA_BLOB structure containing an Abstract Syntax
		/// Notation One (ASN.1) encoded CTL_USAGE structure. This structure was encoded using CryptEncodeObject with
		/// X509_ENHANCED_KEY_USAGE value set.
		/// </term>
		/// </item>
		/// <item>
		/// <term>CERT_DESCRIPTION_PROP_ID</term>
		/// <term>
		/// Data type of pvData: pointer to a CRYPT_DATA_BLOB Property set and displayed by the certificate UI. This property allows the
		/// user to describe the certificate's use.
		/// </term>
		/// </item>
		/// <item>
		/// <term>CERT_ENHKEY_USAGE_PROP_ID</term>
		/// <term>
		/// Data type of pvData: pointer to a CRYPT_DATA_BLOB The CRYPT_DATA_BLOB structure containing an ASN.1 encoded CERT_ENHKEY_USAGE
		/// structure. This structure was encoded using CryptEncodeObject with X509_ENHANCED_KEY_USAGE value set.
		/// </term>
		/// </item>
		/// <item>
		/// <term>CERT_FRIENDLY_NAME_PROP_ID</term>
		/// <term>Data type of pvData: pointer to a CRYPT_DATA_BLOB The CRYPT_DATA_BLOB structure specifies the display name of the certificate.</term>
		/// </item>
		/// <item>
		/// <term>CERT_HASH_PROP_ID</term>
		/// <term>Data type of pvData: pointer to a CRYPT_HASH_BLOB This property is implicitly set by a call to CertGetCertificateContextProperty.</term>
		/// </item>
		/// <item>
		/// <term>CERT_KEY_CONTEXT_PROP_ID</term>
		/// <term>
		/// Data type of pvData: pointer to a CERT_KEY_CONTEXT The CERT_KEY_CONTEXT structure contains both the HCRYPTPROV value and the key
		/// specification for the private key. For more information about the hCryptProv member and dwFlags settings, see
		/// CERT_KEY_PROV_HANDLE_PROP_ID, following. Note that more CERT_KEY_CONTEXT structure members can be added for this property. If
		/// so, the cbSize member value will be adjusted accordingly. The cbSize member must be set to the size of the CERT_KEY_CONTEXT structure
		/// </term>
		/// </item>
		/// <item>
		/// <term>CERT_KEY_IDENTIFIER_PROP_ID</term>
		/// <term>Data type of pvData: pointer to a CRYPT_DATA_BLOB This property is typically implicitly set by a call to CertGetCertificateContextProperty.</term>
		/// </item>
		/// <item>
		/// <term>CERT_KEY_PROV_HANDLE_PROP_ID</term>
		/// <term>
		/// Data type of pvData: pointer to a HCRYPTPROV An HCRYPTPROV handle for the certificate's private key is passed. The hCryptProv
		/// member of the CERT_KEY_CONTEXT structure is updated if it exists. If it does not exist, it is created with dwKeySpec initialized
		/// by CERT_KEY_PROV_INFO_PROP_ID. If CERT_STORE_NO_CRYPT_RELEASE_FLAG is not set, the hCryptProv value is implicitly released
		/// either when the property is set to NULL or on the final freeing of the CERT_CONTEXT structure.
		/// </term>
		/// </item>
		/// <item>
		/// <term>CERT_KEY_PROV_INFO_PROP_ID</term>
		/// <term>
		/// Data type of pvData: pointer to a CRYPT_KEY_PROV_INFO The CRYPT_KEY_PROV_INFO structure specifies the certificate's private key.
		/// </term>
		/// </item>
		/// <item>
		/// <term>CERT_KEY_SPEC_PROP_ID</term>
		/// <term>
		/// Data type of pvData: pointer to a DWORD The DWORD value specifies the private key. The dwKeySpec member of the CERT_KEY_CONTEXT
		/// structure is updated if it exists. If it does not, it is created with hCryptProv set to zero.
		/// </term>
		/// </item>
		/// <item>
		/// <term>CERT_MD5_HASH_PROP_ID</term>
		/// <term>Data type of pvData: pointer to a CRYPT_HASH_BLOB This property is implicitly set by a call to CertGetCertificateContextProperty.</term>
		/// </item>
		/// <item>
		/// <term>CERT_NEXT_UPDATE_LOCATION_PROP_ID</term>
		/// <term>
		/// Data type of pvData: pointer to a CRYPT_DATA_BLOB The CRYPT_DATA_BLOB structure contains an ASN.1 encoded CERT_ALT_NAME_INFO
		/// structure encoded using CryptEncodeObject with the X509_ALTERNATE_NAME value set. CERT_NEXT_UPDATE_LOCATION_PROP_ID is currently
		/// used only with CTLs.
		/// </term>
		/// </item>
		/// <item>
		/// <term>CERT_PVK_FILE_PROP_ID</term>
		/// <term>
		/// Data type of pvData: pointer to a CRYPT_DATA_BLOB The CRYPT_DATA_BLOB structure specifies the name of a file containing the
		/// private key associated with the certificate's public key. Inside the CRYPT_DATA_BLOB structure, the pbData member is a pointer
		/// to a null-terminated Unicode, wide-character string, and the cbData member indicates the length of the string.
		/// </term>
		/// </item>
		/// <item>
		/// <term>CERT_SHA1_HASH_PROP_ID</term>
		/// <term>Data type of pvData: pointer to a CRYPT_HASH_BLOB This property is implicitly set by a call to CertGetCertificateContextProperty.</term>
		/// </item>
		/// <item>
		/// <term>CERT_SIGNATURE_HASH_PROP_ID CRYPT_HASH_BLOB</term>
		/// <term>
		/// Data type of pvData: pointer to a CRYPT_HASH_BLOB If a signature hash does not exist, it is computed with CryptHashToBeSigned.
		/// pvData points to an existing or computed hash. Usually, the length of the hash is 20 bytes for SHA and 16 for MD5.
		/// </term>
		/// </item>
		/// </list>
		/// <para>Typically, only the CERT_NEXT_UPDATE_LOCATION_PROP_ID property is set.</para>
		/// <para>
		/// Additional dwPropId types can be defined by the user using <c>DWORD</c> values from CERT_FIRST_USER_PROP_ID to
		/// CERT_LAST_USER_PROP_ID. For all user-defined dwPropId types, pvData points to an encoded CRYPT_DATA_BLOB structure.
		/// </para>
		/// </param>
		/// <param name="dwFlags">
		/// <para>
		/// CERT_STORE_NO_CRYPT_RELEASE_FLAG can be set for the CERT_KEY_PROV_HANDLE_PROP_ID or CERT_KEY_CONTEXT_PROP_ID dwPropId properties.
		/// </para>
		/// <para>
		/// If the CERT_SET_PROPERTY_IGNORE_PERSIST_ERROR_FLAG value is set, any provider-write errors are ignored and the cached context's
		/// properties are always set.
		/// </para>
		/// <para>If CERT_SET_PROPERTY_INHIBIT_PERSIST_FLAG is set, any property set is not persisted.</para>
		/// </param>
		/// <param name="pvData">
		/// <para>A pointer to a data type that is determined by the value passed in dwPropId.</para>
		/// <para><c>Note</c> For any dwPropId, setting pvData to <c>NULL</c> deletes the property.</para>
		/// </param>
		/// <returns>
		/// <para>If the function succeeds, the return value is <c>TRUE</c>.</para>
		/// <para>
		/// If the function fails, the return value is <c>FALSE</c>. For extended error information, call GetLastError. One possible error
		/// code is the following.
		/// </para>
		/// <list type="table">
		/// <listheader>
		/// <term>Return code</term>
		/// <term>Description</term>
		/// </listheader>
		/// <item>
		/// <term>E_INVALIDARG</term>
		/// <term>Invalid property identifier. For details, see CertSetCertificateContextProperty.</term>
		/// </item>
		/// </list>
		/// </returns>
		/// <remarks>
		/// <para>If a property already exists, its old value is replaced.</para>
		/// <para>Examples</para>
		/// <para>See Example C Program: Getting and Setting Certificate Properties.</para>
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows/win32/api/wincrypt/nf-wincrypt-certsetctlcontextproperty BOOL CertSetCTLContextProperty(
		// PCCTL_CONTEXT pCtlContext, DWORD dwPropId, DWORD dwFlags, const void *pvData );
		[DllImport(Lib.Crypt32, SetLastError = true, ExactSpelling = true)]
		[PInvokeData("wincrypt.h", MSDNShortId = "3af01ca6-6fa1-4510-872a-b5e13e07f49f")]
		[return: MarshalAs(UnmanagedType.Bool)]
		public static extern bool CertSetCTLContextProperty([In] PCCTL_CONTEXT pCtlContext, CertPropId dwPropId, uint dwFlags, [In, Optional] IntPtr pvData);
	}
}