using System.Collections.Generic;

namespace Vanara.PInvoke;

/// <summary>Methods and data types found in Crypt32.dll.</summary>
public static partial class Crypt32
{
	private const int CERT_COMPARE_SHIFT = 16;
	/// <summary/>
	public const uint CERT_V1 = 0;
	/// <summary/>
	public const uint CERT_V2 = 1;
	/// <summary/>
	public const uint CERT_V3 = 2;

	/// <summary>The class of an ALG_ID.</summary>
	[PInvokeData("wincrypt.h")]
	public enum ALG_CLASS
	{
		/// <summary/>
		ALG_CLASS_ANY = (0),
		/// <summary/>
		ALG_CLASS_SIGNATURE = (1 << 13),
		/// <summary/>
		ALG_CLASS_MSG_ENCRYPT = (2 << 13),
		/// <summary/>
		ALG_CLASS_DATA_ENCRYPT = (3 << 13),
		/// <summary/>
		ALG_CLASS_HASH = (4 << 13),
		/// <summary/>
		ALG_CLASS_KEY_EXCHANGE = (5 << 13),
		/// <summary/>
		ALG_CLASS_ALL = (7 << 13),
	}

	/// <summary>
	/// The ALG_ID data type specifies an algorithm identifier. Parameters of this data type are passed to most of the functions in CryptoAPI.
	/// </summary>
	public enum ALG_ID : uint
	{
		/// <summary>Triple DES encryption algorithm.</summary>
		CALG_3DES = 0x00006603,

		/// <summary>Two-key triple DES encryption with effective key length equal to 112 bits.</summary>
		CALG_3DES_112 = 0x00006609,

		/// <summary>Advanced Encryption Standard (AES). This algorithm is supported by the Microsoft AES Cryptographic Provider.</summary>
		CALG_AES = 0x00006611,

		/// <summary>128 bit AES. This algorithm is supported by the Microsoft AES Cryptographic Provider.</summary>
		CALG_AES_128 = 0x0000660e,

		/// <summary>192 bit AES. This algorithm is supported by the Microsoft AES Cryptographic Provider.</summary>
		CALG_AES_192 = 0x0000660f,

		/// <summary>256 bit AES. This algorithm is supported by the Microsoft AES Cryptographic Provider.</summary>
		CALG_AES_256 = 0x00006610,

		/// <summary>Temporary algorithm identifier for handles of Diffie-Hellman–agreed keys.</summary>
		CALG_AGREEDKEY_ANY = 0x0000aa03,

		/// <summary>
		/// An algorithm to create a 40-bit DES key that has parity bits and zeroed key bits to make its key length 64 bits. This
		/// algorithm is supported by the Microsoft Base Cryptographic Provider.
		/// </summary>
		CALG_CYLINK_MEK = 0x0000660c,

		/// <summary>DES encryption algorithm.</summary>
		CALG_DES = 0x00006601,

		/// <summary>DESX encryption algorithm.</summary>
		CALG_DESX = 0x00006604,

		/// <summary>Diffie-Hellman ephemeral key exchange algorithm.</summary>
		CALG_DH_EPHEM = 0x0000aa02,

		/// <summary>Diffie-Hellman store and forward key exchange algorithm.</summary>
		CALG_DH_SF = 0x0000aa01,

		/// <summary>DSA public key signature algorithm.</summary>
		CALG_DSS_SIGN = 0x00002200,

		/// <summary>
		/// Elliptic curve Diffie-Hellman key exchange algorithm.
		/// <para>[!Note]</para>
		/// <para>This algorithm is supported only through Cryptography API: Next Generation.</para>
		/// <para>Windows Server 2003 and Windows XP: This algorithm is not supported.</para>
		/// </summary>
		CALG_ECDH = 0x0000aa05,

		/// <summary>
		/// Ephemeral elliptic curve Diffie-Hellman key exchange algorithm.
		/// <para>[!Note]</para>
		/// <para>This algorithm is supported only through Cryptography API: Next Generation.</para>
		/// <para>Windows Server 2003 and Windows XP: This algorithm is not supported.</para>
		/// </summary>
		CALG_ECDH_EPHEM = 0x0000ae06,

		/// <summary>
		/// Elliptic curve digital signature algorithm.
		/// <para>[!Note]</para>
		/// <para>This algorithm is supported only through Cryptography API: Next Generation.</para>
		/// <para>Windows Server 2003 and Windows XP: This algorithm is not supported.</para>
		/// </summary>
		CALG_ECDSA = 0x00002203,

		/// <summary>Elliptic curve Menezes, Qu, and Vanstone (MQV) key exchange algorithm. This algorithm is not supported.</summary>
		CALG_ECMQV = 0x0000a001,

		/// <summary>One way function hashing algorithm.</summary>
		CALG_HASH_REPLACE_OWF = 0x0000800b,

		/// <summary>Hughes MD5 hashing algorithm.</summary>
		CALG_HUGHES_MD5 = 0x0000a003,

		/// <summary>HMAC keyed hash algorithm. This algorithm is supported by the Microsoft Base Cryptographic Provider.</summary>
		CALG_HMAC = 0x00008009,

		/// <summary>KEA key exchange algorithm (FORTEZZA). This algorithm is not supported.</summary>
		CALG_KEA_KEYX = 0x0000aa04,

		/// <summary>MAC keyed hash algorithm. This algorithm is supported by the Microsoft Base Cryptographic Provider.</summary>
		CALG_MAC = 0x00008005,

		/// <summary>MD2 hashing algorithm. This algorithm is supported by the Microsoft Base Cryptographic Provider.</summary>
		CALG_MD2 = 0x00008001,

		/// <summary>MD4 hashing algorithm.</summary>
		CALG_MD4 = 0x00008002,

		/// <summary>MD5 hashing algorithm. This algorithm is supported by the Microsoft Base Cryptographic Provider.</summary>
		CALG_MD5 = 0x00008003,

		/// <summary>No signature algorithm.</summary>
		CALG_NO_SIGN = 0x00002000,

		/// <summary>
		/// The algorithm is only implemented in CNG. The macro, IS_SPECIAL_OID_INFO_ALGID, can be used to determine whether a
		/// cryptography algorithm is only supported by using the CNG functions.
		/// </summary>
		CALG_OID_INFO_CNG_ONLY = 0xffffffff,

		/// <summary>
		/// The algorithm is defined in the encoded parameters. The algorithm is only supported by using CNG. The macro,
		/// IS_SPECIAL_OID_INFO_ALGID, can be used to determine whether a cryptography algorithm is only supported by using the CNG functions.
		/// </summary>
		CALG_OID_INFO_PARAMETERS = 0xfffffffe,

		/// <summary>Used by the Schannel.dll operations system. This ALG_ID should not be used by applications.</summary>
		CALG_PCT1_MASTER = 0x00004c04,

		/// <summary>RC2 block encryption algorithm. This algorithm is supported by the Microsoft Base Cryptographic Provider.</summary>
		CALG_RC2 = 0x00006602,

		/// <summary>RC4 stream encryption algorithm. This algorithm is supported by the Microsoft Base Cryptographic Provider.</summary>
		CALG_RC4 = 0x00006801,

		/// <summary>RC5 block encryption algorithm.</summary>
		CALG_RC5 = 0x0000660d,

		/// <summary>RSA public key exchange algorithm. This algorithm is supported by the Microsoft Base Cryptographic Provider.</summary>
		CALG_RSA_KEYX = 0x0000a400,

		/// <summary>RSA public key signature algorithm. This algorithm is supported by the Microsoft Base Cryptographic Provider.</summary>
		CALG_RSA_SIGN = 0x00002400,

		/// <summary>Used by the Schannel.dll operations system. This ALG_ID should not be used by applications.</summary>
		CALG_SCHANNEL_ENC_KEY = 0x00004c07,

		/// <summary>Used by the Schannel.dll operations system. This ALG_ID should not be used by applications.</summary>
		CALG_SCHANNEL_MAC_KEY = 0x00004c03,

		/// <summary>Used by the Schannel.dll operations system. This ALG_ID should not be used by applications.</summary>
		CALG_SCHANNEL_MASTER_HASH = 0x00004c02,

		/// <summary>SEAL encryption algorithm. This algorithm is not supported.</summary>
		CALG_SEAL = 0x00006802,

		/// <summary>SHA hashing algorithm. This algorithm is supported by the Microsoft Base Cryptographic Provider.</summary>
		CALG_SHA = 0x00008004,

		/// <summary>Same as CALG_SHA. This algorithm is supported by the Microsoft Base Cryptographic Provider.</summary>
		CALG_SHA1 = 0x00008004,

		/// <summary>
		/// 256 bit SHA hashing algorithm. This algorithm is supported by Microsoft Enhanced RSA and AES Cryptographic Provider..Windows
		/// XP with SP3: This algorithm is supported by the Microsoft Enhanced RSA and AES Cryptographic Provider (Prototype).
		/// <para>Windows XP with SP2, Windows XP with SP1 and Windows XP: This algorithm is not supported.</para>
		/// </summary>
		CALG_SHA_256 = 0x0000800c,

		/// <summary>
		/// 384 bit SHA hashing algorithm. This algorithm is supported by Microsoft Enhanced RSA and AES Cryptographic Provider.Windows
		/// XP with SP3: This algorithm is supported by the Microsoft Enhanced RSA and AES Cryptographic Provider (Prototype).
		/// <para>Windows XP with SP2, Windows XP with SP1 and Windows XP: This algorithm is not supported.</para>
		/// </summary>
		CALG_SHA_384 = 0x0000800d,

		/// <summary>
		/// 512 bit SHA hashing algorithm. This algorithm is supported by Microsoft Enhanced RSA and AES Cryptographic Provider.Windows
		/// XP with SP3: This algorithm is supported by the Microsoft Enhanced RSA and AES Cryptographic Provider (Prototype).
		/// <para>Windows XP with SP2, Windows XP with SP1 and Windows XP: This algorithm is not supported.</para>
		/// </summary>
		CALG_SHA_512 = 0x0000800e,

		/// <summary>Skipjack block encryption algorithm (FORTEZZA). This algorithm is not supported.</summary>
		CALG_SKIPJACK = 0x0000660a,

		/// <summary>Used by the Schannel.dll operations system. This ALG_ID should not be used by applications.</summary>
		CALG_SSL2_MASTER = 0x00004c05,

		/// <summary>Used by the Schannel.dll operations system. This ALG_ID should not be used by applications.</summary>
		CALG_SSL3_MASTER = 0x00004c01,

		/// <summary>Used by the Schannel.dll operations system. This ALG_ID should not be used by applications.</summary>
		CALG_SSL3_SHAMD5 = 0x00008008,

		/// <summary>TEK (FORTEZZA). This algorithm is not supported.</summary>
		CALG_TEK = 0x0000660b,

		/// <summary>Used by the Schannel.dll operations system. This ALG_ID should not be used by applications.</summary>
		CALG_TLS1_MASTER = 0x00004c06,

		/// <summary>Used by the Schannel.dll operations system. This ALG_ID should not be used by applications.</summary>
		CALG_TLS1PRF = 0x0000800a,
	}

	/// <summary>The type of an ALG_ID.</summary>
	[PInvokeData("wincrypt.h")]
	public enum ALG_TYPE
	{
		/// <summary/>
		ALG_TYPE_ANY = (0),
		/// <summary/>
		ALG_TYPE_DSS = (1 << 9),
		/// <summary/>
		ALG_TYPE_RSA = (2 << 9),
		/// <summary/>
		ALG_TYPE_BLOCK = (3 << 9),
		/// <summary/>
		ALG_TYPE_STREAM = (4 << 9),
		/// <summary/>
		ALG_TYPE_DH = (5 << 9),
		/// <summary/>
		ALG_TYPE_SECURECHANNEL = (6 << 9),
		/// <summary/>
		ALG_TYPE_ECDH = (7 << 9),
		/// <summary/>
		ALG_TYPE_THIRDPARTY = (8 << 9),
	}

	/// <summary>Indicates which nested union member of CERT_STRONG_SIGN_PARA points to the strong signature information.</summary>
	public enum CERT_INFO_CHOICE : uint
	{
		/// <summary>Specifies the pSerializedInfo member of CERT_STRONG_SIGN_PARA.</summary>
		CERT_STRONG_SIGN_SERIALIZED_INFO_CHOICE = 1,

		/// <summary>Specifies the pszOID member of CERT_STRONG_SIGN_PARA.</summary>
		CERT_STRONG_SIGN_OID_INFO_CHOICE = 2,
	}

	/// <summary>Values used by CertFindType.</summary>
	public enum CertCompareFunction : ushort
	{
		/// <summary>No search criteria used. Returns the next certificate in the store.</summary>
		CERT_COMPARE_ANY = 0,

		/// <summary>Searches for a certificate with a SHA1 hash that matches the hash in the CRYPT_HASH_BLOB structure.</summary>
		CERT_COMPARE_SHA1_HASH = 1,

		/// <summary>
		/// Searches for a certificate with an exact match of the entire subject name with the name in the CERT_NAME_BLOB structure. The
		/// search is restricted to certificates that match the value of dwCertEncodingType.
		/// </summary>
		CERT_COMPARE_NAME = 2,

		/// <summary>
		/// Searches for a certificate with specified subject attributes that match attributes in the CERT_RDN structure. If RDN values
		/// are set, the function compares attributes of the subject in a certificate with elements of the CERT_RDN_ATTR array in this
		/// CERT_RDN structure. Comparisons iterate through the CERT_RDN_ATTR attributes looking for a match with the certificate's
		/// subject's attributes.
		/// <para>If the pszObjId member of CERT_RDN_ATTR is NULL, the attribute object identifier is ignored.</para>
		/// <para>If the dwValueType member of CERT_RDN_ATTR is CERT_RDN_ANY_TYPE, the value type is ignored.</para>
		/// <para>If the pbData member of CERT_RDN_VALUE_BLOB is NULL, any value is a match.</para>
		/// <para>Currently only an exact, case-sensitive match is supported.</para>
		/// <para>
		/// For information about Unicode options, see Remarks. When these values are set, the search is restricted to certificates
		/// whose encoding type matches dwCertEncodingType.
		/// </para>
		/// </summary>
		CERT_COMPARE_ATTR = 3,

		/// <summary>Searches for a certificate with an MD5 hash that matches the hash in CRYPT_HASH_BLOB.</summary>
		CERT_COMPARE_MD5_HASH = 4,

		/// <summary>
		/// Searches for a certificate with a property that matches the property identifier specified by the DWORD value in pvFindPara.
		/// </summary>
		CERT_COMPARE_PROPERTY = 5,

		/// <summary>Searches for a certificate with a public key that matches the public key in the CERT_PUBLIC_KEY_INFO structure.</summary>
		CERT_COMPARE_PUBLIC_KEY = 6,

		/// <summary>Searches for a certificate with a SHA1 hash that matches the hash in the CRYPT_HASH_BLOB structure.</summary>
		CERT_COMPARE_HASH = CERT_COMPARE_SHA1_HASH,

		/// <summary>
		/// Searches for a certificate that contains the specified subject name string. The certificate's subject member is converted to
		/// a name string of the appropriate type using the appropriate form of CertNameToStr formatted as CERT_SIMPLE_NAME_STR. Then a
		/// case-insensitive substring-within-a-string match is performed. When this value is set, the search is restricted to
		/// certificates whose encoding type matches dwCertEncodingType.
		/// </summary>
		CERT_COMPARE_NAME_STR_A = 7,

		/// <summary>
		/// Searches for a certificate that contains the specified subject name string. The certificate's subject member is converted to
		/// a name string of the appropriate type using the appropriate form of CertNameToStr formatted as CERT_SIMPLE_NAME_STR. Then a
		/// case-insensitive substring-within-a-string match is performed. When this value is set, the search is restricted to
		/// certificates whose encoding type matches dwCertEncodingType.
		/// </summary>
		CERT_COMPARE_NAME_STR_W = 8,

		/// <summary>Searches for a certificate that has a CERT_KEY_SPEC_PROP_ID property that matches the key specification in pvFindPara.</summary>
		CERT_COMPARE_KEY_SPEC = 9,

		/// <summary>
		/// Searches for a certificate in the store that has either an enhanced key usage extension or an enhanced key usage property
		/// and a usage identifier that matches the cUsageIdentifier member in the CERT_ENHKEY_USAGE structure.
		/// <para>
		/// A certificate has an enhanced key usage extension if it has a CERT_EXTENSION structure with the pszObjId member set to szOID_ENHANCED_KEY_USAGE.
		/// </para>
		/// <para>A certificate has an enhanced key usage property if its CERT_ENHKEY_USAGE_PROP_ID identifier is set.</para>
		/// <para>
		/// If CERT_FIND_OPTIONAL_ENHKEY_USAGE_FLAG is set in dwFindFlags, certificates without the key usage extension or property are
		/// also matches. Setting this flag takes precedence over passing NULL in pvFindPara.
		/// </para>
		/// <para>If CERT_FIND_EXT_ONLY_ENHKEY_USAGE_FLAG is set, a match is done only on the key usage extension.</para>
		/// </summary>
		CERT_COMPARE_ENHKEY_USAGE = 10,

		/// <summary>
		/// Searches for a certificate in the store that has either an enhanced key usage extension or an enhanced key usage property
		/// and a usage identifier that matches the cUsageIdentifier member in the CERT_ENHKEY_USAGE structure.
		/// <para>
		/// A certificate has an enhanced key usage extension if it has a CERT_EXTENSION structure with the pszObjId member set to szOID_ENHANCED_KEY_USAGE.
		/// </para>
		/// <para>A certificate has an enhanced key usage property if its CERT_ENHKEY_USAGE_PROP_ID identifier is set.</para>
		/// <para>
		/// If CERT_FIND_OPTIONAL_ENHKEY_USAGE_FLAG is set in dwFindFlags, certificates without the key usage extension or property are
		/// also matches. Setting this flag takes precedence over passing NULL in pvFindPara.
		/// </para>
		/// <para>If CERT_FIND_EXT_ONLY_ENHKEY_USAGE_FLAG is set, a match is done only on the key usage extension.</para>
		/// </summary>
		CERT_COMPARE_CTL_USAGE = CERT_COMPARE_ENHKEY_USAGE,

		/// <summary>
		/// Searches for a certificate with both an issuer and a serial number that match the issuer and serial number in the CERT_INFO structure.
		/// </summary>
		CERT_COMPARE_SUBJECT_CERT = 11,

		/// <summary>
		/// Searches for a certificate with an subject that matches the issuer [In] PCCERT_CONTEXT. Instead of using
		/// CertFindCertificateInStore with this value, use the CertGetCertificateChain function.
		/// </summary>
		CERT_COMPARE_ISSUER_OF = 12,

		/// <summary>Searches for a certificate that is an exact match of the specified certificate context.</summary>
		CERT_COMPARE_EXISTING = 13,

		/// <summary>Searches for a certificate with a signature hash that matches the signature hash in the CRYPT_HASH_BLOB structure.</summary>
		CERT_COMPARE_SIGNATURE_HASH = 14,

		/// <summary>Searches for a certificate with a CERT_KEY_IDENTIFIER_PROP_ID property that matches the key identifier in CRYPT_HASH_BLOB.</summary>
		CERT_COMPARE_KEY_IDENTIFIER = 15,

		/// <summary>Find the certificate identified by the specified CERT_ID.</summary>
		CERT_COMPARE_CERT_ID = 16,

		/// <summary>Find a certificate that has either a cross certificate distribution point extension or property.</summary>
		CERT_COMPARE_CROSS_CERT_DIST_POINTS = 17,

		/// <summary>Find a certificate whose MD5-hashed public key matches the specified hash.</summary>
		CERT_COMPARE_PUBKEY_MD5_HASH = 18,

		/// <summary></summary>
		CERT_COMPARE_SUBJECT_INFO_ACCESS = 19,

		/// <summary></summary>
		CERT_COMPARE_HASH_STR = 20,

		/// <summary>
		/// Searches for a certificate that has a private key. The key can be ephemeral or saved on disk. The key can be a legacy
		/// Cryptography API (CAPI) key or a CNG key.
		/// </summary>
		CERT_COMPARE_HAS_PRIVATE_KEY = 21,
	}

	/// <summary>A certificate encoding type.</summary>
	[PInvokeData("wincrypt.h")]
	public enum CertEncodingType : uint
	{
		/// <summary/>
		CRYPT_ASN_ENCODING = 0x00000001,

		/// <summary/>
		CRYPT_NDR_ENCODING = 0x00000002,

		/// <summary/>
		X509_ASN_ENCODING = 0x00000001,

		/// <summary/>
		X509_NDR_ENCODING = 0x00000002,

		/// <summary/>
		PKCS_7_ASN_ENCODING = 0x00010000,

		/// <summary/>
		PKCS_7_NDR_ENCODING = 0x00020000,

		/// <summary>Matches any encoding type.</summary>
		CRYPT_MATCH_ANY_ENCODING_TYPE = unchecked((uint)-1),
	}

	/// <summary>Values used by <see cref="CertFindCertificateInStore(HCERTSTORE, CertEncodingType, CertFindUsageFlags, CertFindType, IntPtr, PCCERT_CONTEXT)"/>.</summary>
	[PInvokeData("wincrypt.h", MSDNShortId = "20b3fcfb-55df-46ff-80a5-70f31a3d03b2")]
	public enum CertFindType : uint
	{
		/// <summary>No search criteria used. Returns the next certificate in the store.</summary>
		CERT_FIND_ANY = (uint)CertCompareFunction.CERT_COMPARE_ANY << CERT_COMPARE_SHIFT,

		/// <summary>Searches for a certificate with a SHA1 hash that matches the hash in the CRYPT_HASH_BLOB structure.</summary>
		[CorrespondingType(typeof(CRYPTOAPI_BLOB))]
		CERT_FIND_SHA1_HASH = (uint)CertCompareFunction.CERT_COMPARE_SHA1_HASH << CERT_COMPARE_SHIFT,

		/// <summary>Searches for a certificate with an MD5 hash that matches the hash in CRYPT_HASH_BLOB.</summary>
		[CorrespondingType(typeof(CRYPTOAPI_BLOB))]
		CERT_FIND_MD5_HASH = (uint)CertCompareFunction.CERT_COMPARE_MD5_HASH << CERT_COMPARE_SHIFT,

		/// <summary>Searches for a certificate with a signature hash that matches the signature hash in the CRYPT_HASH_BLOB structure.</summary>
		[CorrespondingType(typeof(CRYPTOAPI_BLOB))]
		CERT_FIND_SIGNATURE_HASH = (uint)CertCompareFunction.CERT_COMPARE_SIGNATURE_HASH << CERT_COMPARE_SHIFT,

		/// <summary>Searches for a certificate with a CERT_KEY_IDENTIFIER_PROP_ID property that matches the key identifier in CRYPT_HASH_BLOB.</summary>
		[CorrespondingType(typeof(CRYPTOAPI_BLOB))]
		CERT_FIND_KEY_IDENTIFIER = (uint)CertCompareFunction.CERT_COMPARE_KEY_IDENTIFIER << CERT_COMPARE_SHIFT,

		/// <summary>Searches for a certificate with a SHA1 hash that matches the hash in the CRYPT_HASH_BLOB structure.</summary>
		[CorrespondingType(typeof(CRYPTOAPI_BLOB))]
		CERT_FIND_HASH = CERT_FIND_SHA1_HASH,

		/// <summary>
		/// Searches for a certificate with a property that matches the property identifier specified by the DWORD value in pvFindPara.
		/// </summary>
		[CorrespondingType(typeof(uint))]
		CERT_FIND_PROPERTY = (uint)CertCompareFunction.CERT_COMPARE_PROPERTY << CERT_COMPARE_SHIFT,

		/// <summary>Searches for a certificate with a public key that matches the public key in the CERT_PUBLIC_KEY_INFO structure.</summary>
		[CorrespondingType(typeof(CERT_PUBLIC_KEY_INFO))]
		CERT_FIND_PUBLIC_KEY = (uint)CertCompareFunction.CERT_COMPARE_PUBLIC_KEY << CERT_COMPARE_SHIFT,

		/// <summary>
		/// Searches for a certificate with an exact match of the entire subject name with the name in the CERT_NAME_BLOB structure. The
		/// search is restricted to certificates that match the value of dwCertEncodingType.
		/// </summary>
		[CorrespondingType(typeof(CRYPTOAPI_BLOB))]
		CERT_FIND_SUBJECT_NAME = (uint)CertCompareFunction.CERT_COMPARE_NAME << CERT_COMPARE_SHIFT | CertInfoFlags.CERT_INFO_SUBJECT_FLAG,

		/// <summary>
		/// Searches for a certificate with specified subject attributes that match attributes in the CERT_RDN structure. If RDN values
		/// are set, the function compares attributes of the subject in a certificate with elements of the CERT_RDN_ATTR array in this
		/// CERT_RDN structure. Comparisons iterate through the CERT_RDN_ATTR attributes looking for a match with the certificate's
		/// subject's attributes.
		/// <para>If the pszObjId member of CERT_RDN_ATTR is NULL, the attribute object identifier is ignored.</para>
		/// <para>If the dwValueType member of CERT_RDN_ATTR is CERT_RDN_ANY_TYPE, the value type is ignored.</para>
		/// <para>If the pbData member of CERT_RDN_VALUE_BLOB is NULL, any value is a match.</para>
		/// <para>Currently only an exact, case-sensitive match is supported.</para>
		/// <para>
		/// For information about Unicode options, see Remarks. When these values are set, the search is restricted to certificates
		/// whose encoding type matches dwCertEncodingType.
		/// </para>
		/// </summary>
		[CorrespondingType(typeof(CERT_RDN))]
		CERT_FIND_SUBJECT_ATTR = (uint)CertCompareFunction.CERT_COMPARE_ATTR << CERT_COMPARE_SHIFT | CertInfoFlags.CERT_INFO_SUBJECT_FLAG,

		/// <summary>
		/// Search for a certificate with an exact match of the entire issuer name with the name in CERT_NAME_BLOB The search is
		/// restricted to certificates that match the dwCertEncodingType.
		/// </summary>
		[CorrespondingType(typeof(CRYPTOAPI_BLOB))]
		CERT_FIND_ISSUER_NAME = (uint)CertCompareFunction.CERT_COMPARE_NAME << CERT_COMPARE_SHIFT | CertInfoFlags.CERT_INFO_ISSUER_FLAG,

		/// <summary>
		/// Searches for a certificate with specified issuer attributes that match attributes in the CERT_RDN structure. If these values
		/// are set, the function compares attributes of the issuer in a certificate with elements of the CERT_RDN_ATTR array in this
		/// CERT_RDN structure. Comparisons iterate through the CERT_RDN_ATTR attributes looking for a match with the certificate's
		/// issuer attributes.
		/// <para>If the pszObjId member of CERT_RDN_ATTR is NULL, the attribute object identifier is ignored.</para>
		/// <para>If the dwValueType member of CERT_RDN_ATTR is CERT_RDN_ANY_TYPE, the value type is ignored.</para>
		/// <para>If the pbData member of CERT_RDN_VALUE_BLOB is NULL, any value is a match.</para>
		/// <para>
		/// Currently only an exact, case-sensitive match is supported.For information about Unicode options, see Remarks. When these
		/// values are set, the search is restricted to certificates whose encoding type matches dwCertEncodingType.
		/// </para>
		/// </summary>
		[CorrespondingType(typeof(CERT_RDN))]
		CERT_FIND_ISSUER_ATTR = (uint)CertCompareFunction.CERT_COMPARE_ATTR << CERT_COMPARE_SHIFT | CertInfoFlags.CERT_INFO_ISSUER_FLAG,

		/// <summary>
		/// Searches for a certificate that contains the specified subject name string. The certificate's subject member is converted to
		/// a name string of the appropriate type using the appropriate form of CertNameToStr formatted as CERT_SIMPLE_NAME_STR. Then a
		/// case-insensitive substring-within-a-string match is performed. When this value is set, the search is restricted to
		/// certificates whose encoding type matches dwCertEncodingType.
		/// </summary>
		[CorrespondingType(typeof(string))]
		CERT_FIND_SUBJECT_STR_A = (uint)CertCompareFunction.CERT_COMPARE_NAME_STR_A << CERT_COMPARE_SHIFT | CertInfoFlags.CERT_INFO_SUBJECT_FLAG,

		/// <summary>
		/// Searches for a certificate that contains the specified subject name string. The certificate's subject member is converted to
		/// a name string of the appropriate type using the appropriate form of CertNameToStr formatted as CERT_SIMPLE_NAME_STR. Then a
		/// case-insensitive substring-within-a-string match is performed. When this value is set, the search is restricted to
		/// certificates whose encoding type matches dwCertEncodingType.
		/// </summary>
		[CorrespondingType(typeof(string))]
		CERT_FIND_SUBJECT_STR_W = (uint)CertCompareFunction.CERT_COMPARE_NAME_STR_W << CERT_COMPARE_SHIFT | CertInfoFlags.CERT_INFO_SUBJECT_FLAG,

		/// <summary>
		/// Searches for a certificate that contains the specified subject name string. The certificate's subject member is converted to
		/// a name string of the appropriate type using the appropriate form of CertNameToStr formatted as CERT_SIMPLE_NAME_STR. Then a
		/// case-insensitive substring-within-a-string match is performed. When this value is set, the search is restricted to
		/// certificates whose encoding type matches dwCertEncodingType.
		/// </summary>
		[CorrespondingType(typeof(string))]
		CERT_FIND_SUBJECT_STR = CERT_FIND_SUBJECT_STR_W,

		/// <summary>
		/// Searches for a certificate that contains the specified subject name string. The certificate's subject member is converted to
		/// a name string of the appropriate type using the appropriate form of CertNameToStr formatted as CERT_SIMPLE_NAME_STR. Then a
		/// case-insensitive substring-within-a-string match is performed. When this value is set, the search is restricted to
		/// certificates whose encoding type matches dwCertEncodingType.
		/// </summary>
		[CorrespondingType(typeof(string))]
		CERT_FIND_ISSUER_STR_A = (uint)CertCompareFunction.CERT_COMPARE_NAME_STR_A << CERT_COMPARE_SHIFT | CertInfoFlags.CERT_INFO_ISSUER_FLAG,

		/// <summary>
		/// Searches for a certificate that contains the specified subject name string. The certificate's subject member is converted to
		/// a name string of the appropriate type using the appropriate form of CertNameToStr formatted as CERT_SIMPLE_NAME_STR. Then a
		/// case-insensitive substring-within-a-string match is performed. When this value is set, the search is restricted to
		/// certificates whose encoding type matches dwCertEncodingType.
		/// </summary>
		[CorrespondingType(typeof(string))]
		CERT_FIND_ISSUER_STR_W = (uint)CertCompareFunction.CERT_COMPARE_NAME_STR_W << CERT_COMPARE_SHIFT | CertInfoFlags.CERT_INFO_ISSUER_FLAG,

		/// <summary>
		/// Searches for a certificate that contains the specified issuer name string. The certificate's issuer member is converted to a
		/// name string of the appropriate type using the appropriate form of CertNameToStr formatted as CERT_SIMPLE_NAME_STR. Then a
		/// case-insensitive substring-within-a-string match is performed. When this value is set, the search is restricted to
		/// certificates whose encoding type matches dwCertEncodingType.
		/// <para>
		/// If the substring match fails and the subject contains an email RDN with Punycode encoded string,
		/// CERT_NAME_STR_ENABLE_PUNYCODE_FLAG is used to convert the subject to a Unicode string and the substring match is performed again.
		/// </para>
		/// </summary>
		[CorrespondingType(typeof(string))]
		CERT_FIND_ISSUER_STR = CERT_FIND_ISSUER_STR_W,

		/// <summary>Searches for a certificate that has a CERT_KEY_SPEC_PROP_ID property that matches the key specification in pvFindPara.</summary>
		[CorrespondingType(typeof(uint))]
		CERT_FIND_KEY_SPEC = (uint)CertCompareFunction.CERT_COMPARE_KEY_SPEC << CERT_COMPARE_SHIFT,

		/// <summary>
		/// Searches for a certificate in the store that has either an enhanced key usage extension or an enhanced key usage property
		/// and a usage identifier that matches the cUsageIdentifier member in the CERT_ENHKEY_USAGE structure.
		/// <para>
		/// A certificate has an enhanced key usage extension if it has a CERT_EXTENSION structure with the pszObjId member set to szOID_ENHANCED_KEY_USAGE.
		/// </para>
		/// <para>A certificate has an enhanced key usage property if its CERT_ENHKEY_USAGE_PROP_ID identifier is set.</para>
		/// <para>
		/// If CERT_FIND_OPTIONAL_ENHKEY_USAGE_FLAG is set in dwFindFlags, certificates without the key usage extension or property are
		/// also matches. Setting this flag takes precedence over passing NULL in pvFindPara.
		/// </para>
		/// <para>If CERT_FIND_EXT_ONLY_ENHKEY_USAGE_FLAG is set, a match is done only on the key usage extension.</para>
		/// </summary>
		[CorrespondingType(typeof(CTL_USAGE))]
		CERT_FIND_ENHKEY_USAGE = (uint)CertCompareFunction.CERT_COMPARE_ENHKEY_USAGE << CERT_COMPARE_SHIFT,

		/// <summary>
		/// Searches for a certificate that has a szOID_ENHANCED_KEY_USAGE extension or a CERT_CTL_PROP_ID that matches the
		/// pszUsageIdentifier member of the CTL_USAGE structure.
		/// </summary>
		[CorrespondingType(typeof(CTL_USAGE))]
		CERT_FIND_CTL_USAGE = CERT_FIND_ENHKEY_USAGE,

		/// <summary>
		/// Searches for a certificate with both an issuer and a serial number that match the issuer and serial number in the CERT_INFO structure.
		/// </summary>
		[CorrespondingType(typeof(CERT_INFO))]
		CERT_FIND_SUBJECT_CERT = (uint)CertCompareFunction.CERT_COMPARE_SUBJECT_CERT << CERT_COMPARE_SHIFT,

		/// <summary>
		/// Searches for a certificate with an subject that matches the issuer [In] PCCERT_CONTEXT. Instead of using
		/// CertFindCertificateInStore with this value, use the CertGetCertificateChain function.
		/// </summary>
		[CorrespondingType(typeof(CERT_CONTEXT))]
		CERT_FIND_ISSUER_OF = (uint)CertCompareFunction.CERT_COMPARE_ISSUER_OF << CERT_COMPARE_SHIFT,

		/// <summary>Searches for a certificate that is an exact match of the specified certificate context.</summary>
		[CorrespondingType(typeof(CERT_CONTEXT))]
		CERT_FIND_EXISTING = (uint)CertCompareFunction.CERT_COMPARE_EXISTING << CERT_COMPARE_SHIFT,

		/// <summary>Find the certificate identified by the specified CERT_ID.</summary>
		[CorrespondingType(typeof(CERT_ID))]
		CERT_FIND_CERT_ID = (uint)CertCompareFunction.CERT_COMPARE_CERT_ID << CERT_COMPARE_SHIFT,

		/// <summary>Find a certificate that has either a cross certificate distribution point extension or property.</summary>
		CERT_FIND_CROSS_CERT_DIST_POINTS = (uint)CertCompareFunction.CERT_COMPARE_CROSS_CERT_DIST_POINTS << CERT_COMPARE_SHIFT,

		/// <summary>Find a certificate whose MD5-hashed public key matches the specified hash.</summary>
		CERT_FIND_PUBKEY_MD5_HASH = (uint)CertCompareFunction.CERT_COMPARE_PUBKEY_MD5_HASH << CERT_COMPARE_SHIFT,

		/// <summary></summary>
		CERT_FIND_SUBJECT_INFO_ACCESS = (uint)CertCompareFunction.CERT_COMPARE_SUBJECT_INFO_ACCESS << CERT_COMPARE_SHIFT,

		/// <summary></summary>
		CERT_FIND_HASH_STR = (uint)CertCompareFunction.CERT_COMPARE_HASH_STR << CERT_COMPARE_SHIFT,

		/// <summary>
		/// Searches for a certificate that has a private key. The key can be ephemeral or saved on disk. The key can be a legacy
		/// Cryptography API (CAPI) key or a CNG key.
		/// </summary>
		CERT_FIND_HAS_PRIVATE_KEY = (uint)CertCompareFunction.CERT_COMPARE_HAS_PRIVATE_KEY << CERT_COMPARE_SHIFT
	}

	/// <summary>Flags used by <see cref="CertFindType"/>.</summary>
	public enum CertInfoFlags : uint
	{
		/// <summary>Gets the version.</summary>
		CERT_INFO_VERSION_FLAG = 1,

		/// <summary>Gets the serial number.</summary>
		CERT_INFO_SERIAL_NUMBER_FLAG = 2,

		/// <summary>Gets the signature.</summary>
		CERT_INFO_SIGNATURE_ALGORITHM_FLAG = 3,

		/// <summary>Gets the issuer.</summary>
		CERT_INFO_ISSUER_FLAG = 4,

		/// <summary>Gets values before.</summary>
		CERT_INFO_NOT_BEFORE_FLAG = 5,

		/// <summary>Gets values after.</summary>
		CERT_INFO_NOT_AFTER_FLAG = 6,

		/// <summary>Gets the subject.</summary>
		CERT_INFO_SUBJECT_FLAG = 7,

		/// <summary>Gets the subject's public key.</summary>
		CERT_INFO_SUBJECT_PUBLIC_KEY_INFO_FLAG = 8,

		/// <summary>Gets the issuer's UID.</summary>
		CERT_INFO_ISSUER_UNIQUE_ID_FLAG = 9,

		/// <summary>Gets the subject's UID.</summary>
		CERT_INFO_SUBJECT_UNIQUE_ID_FLAG = 10,

		/// <summary>Gets the extended info.</summary>
		CERT_INFO_EXTENSION_FLAG = 11,
	}

	/// <summary>The specification of the private key to retrieve.</summary>
	public enum CertKeySpec : uint
	{
		/// <summary>Keys used to encrypt/decrypt session keys. The handle to the CSP is contained in the hCryptProv member.</summary>
		AT_KEYEXCHANGE = 1,

		/// <summary>Keys used to create and verify digital signatures. The handle to the CSP is contained in the hCryptProv member.</summary>
		AT_SIGNATURE = 2,

		/// <summary>
		/// Keys associated with a CNG CSP. The handle to the CNG CSP is set in the hNCryptProv member. Windows Server 2003 and Windows
		/// XP: This value is not used.
		/// </summary>
		CERT_NCRYPT_KEY_SPEC = 0xFFFFFFFF
	}

	/// <summary>A set of flags that modify the behavior of <see cref="CryptAcquireCertificatePrivateKey"/>.</summary>
	[PInvokeData("wincrypt.h", MSDNShortId = "53c9aec9-701d-4c21-9814-d344a8dde0c1")]
	[Flags]
	public enum CryptAcquireFlags
	{
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

		/// <summary/>
		CRYPT_ACQUIRE_NCRYPT_KEY_FLAGS_MASK = 0x00070000,

		/// <summary>
		/// This function will attempt to obtain the key by using CryptoAPI. If that fails, this function will attempt to obtain the key
		/// by using the Cryptography API: Next Generation (CNG).
		/// <para>The pdwKeySpec variable receives the CERT_NCRYPT_KEY_SPEC flag if CNG is used to obtain the key.</para>
		/// </summary>
		CRYPT_ACQUIRE_ALLOW_NCRYPT_KEY_FLAG = 0x00010000,

		/// <summary>
		/// This function will attempt to obtain the key by using CNG. If that fails, this function will attempt to obtain the key by
		/// using CryptoAPI.
		/// <para>The pdwKeySpec variable receives the CERT_NCRYPT_KEY_SPEC flag if CNG is used to obtain the key.</para>
		/// <note>CryptoAPI does not support the CNG Diffie-Hellman or DSA asymmetric algorithms. CryptoAPI only supports Diffie-Hellman
		/// and DSA public keys through the legacy CSPs.If this flag is set for a certificate that contains a Diffie-Hellman or DSA
		/// public key, this function will implicitly change this flag to CRYPT_ACQUIRE_ALLOW_NCRYPT_KEY_FLAG to first attempt to use
		/// CryptoAPI to obtain the key.</note>
		/// </summary>
		CRYPT_ACQUIRE_PREFER_NCRYPT_KEY_FLAG = 0x00020000,

		/// <summary>
		/// This function will only attempt to obtain the key by using CNG and will not use CryptoAPI to obtain the key.
		/// <para>The pdwKeySpec variable receives the CERT_NCRYPT_KEY_SPEC flag if CNG is used to obtain the key.</para>
		/// </summary>
		CRYPT_ACQUIRE_ONLY_NCRYPT_KEY_FLAG = 0x00040000,
	}

	/// <summary>A set of flags that modify the behavior of <see cref="CryptInstallDefaultContext"/>.</summary>
	[PInvokeData("wincrypt.h", MSDNShortId = "79d121df-0699-424e-a8de-5fc2b396afc2")]
	[Flags]
	public enum CryptDefaultContextFlags
	{
		/// <summary>
		/// The provider handle specified by the hCryptProv parameter is released automatically when the process or thread ends. If this
		/// flag is not specified, it is the caller's responsibility to release the provider handle by using the CryptReleaseContext
		/// function when the handle is no longer needed. The provider handle is not released if the CryptUninstallDefaultContext
		/// function is called before the process or thread exits.
		/// </summary>
		CRYPT_DEFAULT_CONTEXT_AUTO_RELEASE_FLAG = 0x00000001,

		/// <summary>
		/// The provider applies to all threads in the process. If this flag is not specified, the provider only applies to the calling
		/// thread. The pvDefaultPara parameter cannot be NULL when this flag is set.
		/// </summary>
		CRYPT_DEFAULT_CONTEXT_PROCESS_FLAG = 0x00000002,
	}

	/// <summary>Specifies the type of context to install.</summary>
	[PInvokeData("wincrypt.h", MSDNShortId = "79d121df-0699-424e-a8de-5fc2b396afc2")]
	public enum CryptDefaultContextType
	{
		/// <summary>
		/// Installs the default provider used to verify a single certificate signature type.
		/// <para>
		/// The pvDefaultPara parameter is the address of a null-terminated ANSI string that contains the object identifier of the
		/// certificate signature algorithm to install the provider for, for example, szOID_OIWSEC_md5RSA.If the pvDefaultPara parameter
		/// is NULL, the specified provider is used to verify all certificate signatures.The pvDefaultPara parameter cannot be NULL when
		/// the CRYPT_DEFAULT_CONTEXT_PROCESS_FLAG flag is set.
		/// </para>
		/// </summary>
		CRYPT_DEFAULT_CONTEXT_CERT_SIGN_OID = 1,

		/// <summary>
		/// Installs the default provider used to verify multiple certificate signature types.
		/// <para>
		/// The pvDefaultPara parameter is the address of a CRYPT_DEFAULT_CONTEXT_MULTI_OID_PARA structure that contains an array of
		/// object identifiers that identify the certificate signature algorithms to install the specified provider for.
		/// </para>
		/// </summary>
		CRYPT_DEFAULT_CONTEXT_MULTI_CERT_SIGN_OID = 2,
	}

	/// <summary>Private key pair type.</summary>
	[PInvokeData("wincrypt.h")]
	public enum PrivateKeyType
	{
		/// <summary>Key exchange</summary>
		AT_KEYEXCHANGE = 1,

		/// <summary>Digital signature</summary>
		AT_SIGNATURE = 2
	}

	/// <summary>A set of flags that specify how the time stamp is retrieved.</summary>
	[PInvokeData("wincrypt.h", MSDNShortId = "68ba3d40-08b0-4261-ab2f-6deb1795f830")]
	[Flags]
	public enum TimeStampRetrivalFlags
	{
		/// <summary>Inhibit hash calculation on the array of bytes pointed to by the pbData parameter.</summary>
		TIMESTAMP_DONT_HASH_DATA = 0x00000001,

		/// <summary>
		/// Enforce signature validation on the retrieved time stamp. <note>The TIMESTAMP_VERIFY_CONTEXT_SIGNATURE flag is valid only if
		/// the fRequestCerts member of the CRYPT_TIMESTAMP_PARA pointed to by the pPara parameter is set to TRUE.</note>
		/// </summary>
		TIMESTAMP_VERIFY_CONTEXT_SIGNATURE = 0x00000020,

		/// <summary>Set this flag to inhibit automatic authentication handling.</summary>
		TIMESTAMP_NO_AUTH_RETRIEVAL = 0x00020000,
	}

	/// <summary>Gets the ALG_CLASS from an ALG_ID.</summary>
	/// <param name="algId">The ALG_ID.</param>
	/// <returns>The associated ALG_CLASS.</returns>
	public static ALG_CLASS GET_ALG_CLASS(ALG_ID algId) => (ALG_CLASS)((int)algId & (7 << 13));

	/// <summary>Gets the ALG_TYPE from an ALG_ID.</summary>
	/// <param name="algId">The ALG_ID.</param>
	/// <returns>The associated ALG_TYPE.</returns>
	public static ALG_TYPE GET_ALG_TYPE(ALG_ID algId) => (ALG_TYPE)((int)algId & (15 << 9));

	/// <summary>Gets the ALG_CLASS from an ALG_ID.</summary>
	/// <param name="algId">The ALG_ID.</param>
	/// <returns>The associated ALG_CLASS.</returns>
	public static ALG_CLASS GetClass(this ALG_ID algId) => GET_ALG_CLASS(algId);

	/// <summary>Gets the ALG_TYPE from an ALG_ID.</summary>
	/// <param name="algId">The ALG_ID.</param>
	/// <returns>The associated ALG_TYPE.</returns>
	public static ALG_TYPE GetType(this ALG_ID algId) => GET_ALG_TYPE(algId);

	/// <summary>
	/// The <c>CertAddEncodedCertificateToSystemStore</c> function opens the specified system store and adds the encoded certificate to it.
	/// </summary>
	/// <param name="szCertStoreName">A null-terminated string that contains the name of the system store for the encoded certificate.</param>
	/// <param name="pbCertEncoded">A pointer to a buffer that contains the encoded certificate to add.</param>
	/// <param name="cbCertEncoded">The size, in bytes, of the pbCertEncoded buffer.</param>
	/// <returns>
	/// <para>If the function succeeds, the return value is <c>TRUE</c>.</para>
	/// <para>
	/// If the function fails, the return value is <c>FALSE</c>. <c>CertAddEncodedCertificateToSystemStore</c> depends on the functions
	/// listed in the following remarks for error handling. Refer to those function topics for their respective error handling
	/// behaviors. For extended error information, call GetLastError.
	/// </para>
	/// </returns>
	/// <remarks>
	/// <para>
	/// Internally, <c>CertAddEncodedCertificateToSystemStore</c> calls CertOpenSystemStore and CertAddEncodedCertificateToStore with
	/// the following parameters.
	/// </para>
	/// <list type="table">
	/// <listheader>
	/// <term>CertOpenSystemStore Parameter</term>
	/// <term>Value</term>
	/// </listheader>
	/// <item>
	/// <term>szSubsystemProtocol</term>
	/// <term>szCertStoreName</term>
	/// </item>
	/// </list>
	/// <para>
	/// If <c>CertAddEncodedCertificateToSystemStore</c> obtains a handle to the specified system store, it calls CertCloseStore to
	/// close the handle before it returns.
	/// </para>
	/// <list type="table">
	/// <listheader>
	/// <term>CertAddEncodedCertificateToStore Parameter</term>
	/// <term>Value</term>
	/// </listheader>
	/// <item>
	/// <term>dwCertEncodingType</term>
	/// <term>X509_ASN_ENCODING</term>
	/// </item>
	/// <item>
	/// <term>dwAddDisposition</term>
	/// <term>CERT_STORE_ADD_USE_EXISTING</term>
	/// </item>
	/// <item>
	/// <term>ppCertContext</term>
	/// <term>NULL</term>
	/// </item>
	/// </list>
	/// </remarks>
	// https://docs.microsoft.com/en-us/windows/win32/api/wincrypt/nf-wincrypt-certaddencodedcertificatetosystemstorea BOOL
	// CertAddEncodedCertificateToSystemStoreA( LPCSTR szCertStoreName, const BYTE *pbCertEncoded, DWORD cbCertEncoded );
	[DllImport(Lib.Crypt32, SetLastError = true, CharSet = CharSet.Auto)]
	[PInvokeData("wincrypt.h", MSDNShortId = "72ff1bcc-eb94-4d97-89fa-d95ed9eb460e")]
	[return: MarshalAs(UnmanagedType.Bool)]
	public static extern bool CertAddEncodedCertificateToSystemStore([MarshalAs(UnmanagedType.LPTStr)] string szCertStoreName, [In] IntPtr pbCertEncoded, uint cbCertEncoded);

	/// <summary>
	/// <para>
	/// The <c>CertFreeCertificateContext</c> function frees a certificate context by decrementing its reference count. When the
	/// reference count goes to zero, <c>CertFreeCertificateContext</c> frees the memory used by a certificate context.
	/// </para>
	/// <para>
	/// To free a context obtained by a get, duplicate, or create function, call the appropriate free function. To free a context
	/// obtained by a find or enumerate function, either pass it in as the previous context parameter to a subsequent invocation of the
	/// function, or call the appropriate free function. For more information, see the reference topic for the function that obtains the context.
	/// </para>
	/// </summary>
	/// <param name="pCertContext">A pointer to the CERT_CONTEXT to be freed.</param>
	/// <returns>The function always returns nonzero.</returns>
	// https://docs.microsoft.com/en-us/windows/win32/api/wincrypt/nf-wincrypt-certfreecertificatecontext BOOL
	// CertFreeCertificateContext( PCCERT_CONTEXT pCertContext );
	[DllImport(Lib.Crypt32, SetLastError = false, ExactSpelling = true)]
	[PInvokeData("wincrypt.h", MSDNShortId = "7d2f3237-3f8b-4234-b6db-3057384cd89b")]
	[return: MarshalAs(UnmanagedType.Bool)]
	public static extern bool CertFreeCertificateContext(PCCERT_CONTEXT pCertContext);

	/// <summary>
	/// Resyncs the certificate chain engine, which resynchronizes the stores the store's engine and updates the engine caches.
	/// </summary>
	/// <param name="hChainEngine">The chain engine to resynchronize.</param>
	/// <returns>
	/// <para>If the function succeeds, the function returns nonzero.</para>
	/// <para>If the function fails, it returns zero. For extended error information, call GetLastError.</para>
	/// </returns>
	// https://docs.microsoft.com/en-us/windows/win32/api/wincrypt/nf-wincrypt-certresynccertificatechainengine BOOL
	// CertResyncCertificateChainEngine( HCERTCHAINENGINE hChainEngine );
	[DllImport(Lib.Crypt32, SetLastError = true, ExactSpelling = true)]
	[PInvokeData("wincrypt.h", MSDNShortId = "D8674AD1-0407-4D1E-9E21-60CAC6D01FC5")]
	[return: MarshalAs(UnmanagedType.Bool)]
	public static extern bool CertResyncCertificateChainEngine(HCERTCHAINENGINE hChainEngine);

	/// <summary>
	/// <para>
	/// The <c>CryptAcquireCertificatePrivateKey</c> function obtains the private key for a certificate. This function is used to obtain
	/// access to a user's private key when the user's certificate is available, but the handle of the user's key container is not
	/// available. This function can only be used by the owner of a private key and not by any other user.
	/// </para>
	/// <para>
	/// If a CSP handle and the key container containing a user's private key are available, the CryptGetUserKey function should be used instead.
	/// </para>
	/// </summary>
	/// <param name="pCert">
	/// The address of a CERT_CONTEXT structure that contains the certificate context for which a private key will be obtained.
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
	/// <term>CRYPT_ACQUIRE_CACHE_FLAG</term>
	/// <term>
	/// If a handle is already acquired and cached, that same handle is returned. Otherwise, a new handle is acquired and cached by
	/// using the certificate's CERT_KEY_CONTEXT_PROP_ID property. When this flag is set, the pfCallerFreeProvOrNCryptKey parameter
	/// receives FALSE and the calling application must not release the handle. The handle is freed when the certificate context is
	/// freed; however, you must retain the certificate context referenced by the pCert parameter as long as the key is in use,
	/// otherwise operations that rely on the key will fail.
	/// </term>
	/// </item>
	/// <item>
	/// <term>CRYPT_ACQUIRE_COMPARE_KEY_FLAG</term>
	/// <term>
	/// The public key in the certificate is compared with the public key returned by the cryptographic service provider (CSP). If the
	/// keys do not match, the acquisition operation fails and the last error code is set to NTE_BAD_PUBLIC_KEY. If a cached handle is
	/// returned, no comparison is made.
	/// </term>
	/// </item>
	/// <item>
	/// <term>CRYPT_ACQUIRE_NO_HEALING</term>
	/// <term>
	/// This function will not attempt to re-create the CERT_KEY_PROV_INFO_PROP_ID property in the certificate context if this property
	/// cannot be retrieved.
	/// </term>
	/// </item>
	/// <item>
	/// <term>CRYPT_ACQUIRE_SILENT_FLAG</term>
	/// <term>
	/// The CSP should not display any user interface (UI) for this context. If the CSP must display UI to operate, the call fails and
	/// the NTE_SILENT_CONTEXT error code is set as the last error.
	/// </term>
	/// </item>
	/// <item>
	/// <term>CRYPT_ACQUIRE_USE_PROV_INFO_FLAG</term>
	/// <term>
	/// Uses the certificate's CERT_KEY_PROV_INFO_PROP_ID property to determine whether caching should be accomplished. For more
	/// information about the CERT_KEY_PROV_INFO_PROP_ID property, see CertSetCertificateContextProperty. This function will only use
	/// caching if during a previous call, the dwFlags member of the CRYPT_KEY_PROV_INFO structure contained CERT_SET_KEY_CONTEXT_PROP.
	/// </term>
	/// </item>
	/// <item>
	/// <term>CRYPT_ACQUIRE_ WINDOWS_HANDLE_FLAG</term>
	/// <term>
	/// Any UI that is needed by the CSP or KSP will be a child of the HWND that is supplied in the pvParameters parameter. For a CSP
	/// key, using this flag will cause the CryptSetProvParam function with the flag PP_CLIENT_HWND using this HWND to be called with
	/// NULL for HCRYPTPROV. For a KSP key, using this flag will cause the NCryptSetProperty function with the
	/// NCRYPT_WINDOW_HANDLE_PROPERTY flag to be called using the HWND. Do not use this flag with CRYPT_ACQUIRE_SILENT_FLAG.
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
	/// using the Cryptography API: Next Generation (CNG). The pdwKeySpec variable receives the CERT_NCRYPT_KEY_SPEC flag if CNG is used
	/// to obtain the key.
	/// </term>
	/// </item>
	/// <item>
	/// <term>CRYPT_ACQUIRE_ONLY_NCRYPT_KEY_FLAG</term>
	/// <term>
	/// This function will only attempt to obtain the key by using CNG and will not use CryptoAPI to obtain the key. The pdwKeySpec
	/// variable receives the CERT_NCRYPT_KEY_SPEC flag if CNG is used to obtain the key.
	/// </term>
	/// </item>
	/// <item>
	/// <term>CRYPT_ACQUIRE_PREFER_NCRYPT_KEY_FLAG</term>
	/// <term>
	/// This function will attempt to obtain the key by using CNG. If that fails, this function will attempt to obtain the key by using
	/// CryptoAPI. The pdwKeySpec variable receives the CERT_NCRYPT_KEY_SPEC flag if CNG is used to obtain the key.
	/// </term>
	/// </item>
	/// </list>
	/// </param>
	/// <param name="pvParameters">
	/// <para>
	/// If the <c>CRYPT_ACQUIRE_WINDOWS_HANDLE_FLAG</c> is set, then this is the address of an <c>HWND</c>. If the
	/// <c>CRYPT_ACQUIRE_WINDOWS_HANDLE_FLAG</c> is not set, then this parameter must be <c>NULL</c>.
	/// </para>
	/// <para>
	/// <c>Windows Server 2008 R2, Windows 7, Windows Server 2008, Windows Vista, Windows Server 2003 and Windows XP:</c> This parameter
	/// was named pvReserved and reserved for future use and must be <c>NULL</c>.
	/// </para>
	/// </param>
	/// <param name="phCryptProvOrNCryptKey">
	/// <para>
	/// The address of an HCRYPTPROV_OR_NCRYPT_KEY_HANDLE variable that receives the handle of either the CryptoAPI provider or the CNG
	/// key. If the pdwKeySpec variable receives the <c>CERT_NCRYPT_KEY_SPEC</c> flag, this is a CNG key handle of type
	/// <c>NCRYPT_KEY_HANDLE</c>; otherwise, this is a CryptoAPI provider handle of type HCRYPTPROV.
	/// </para>
	/// <para>
	/// For more information about when and how to release this handle, see the description of the pfCallerFreeProvOrNCryptKey parameter.
	/// </para>
	/// </param>
	/// <param name="pdwKeySpec">
	/// <para>
	/// The address of a <c>DWORD</c> variable that receives additional information about the key. This can be one of the following values.
	/// </para>
	/// <list type="table">
	/// <listheader>
	/// <term>Value</term>
	/// <term>Meaning</term>
	/// </listheader>
	/// <item>
	/// <term>AT_KEYEXCHANGE</term>
	/// <term>The key pair is a key exchange pair.</term>
	/// </item>
	/// <item>
	/// <term>AT_SIGNATURE</term>
	/// <term>The key pair is a signature pair.</term>
	/// </item>
	/// <item>
	/// <term>CERT_NCRYPT_KEY_SPEC</term>
	/// <term>The key is a CNG key. Windows Server 2003 and Windows XP: This value is not supported.</term>
	/// </item>
	/// </list>
	/// </param>
	/// <param name="pfCallerFreeProvOrNCryptKey">
	/// <para>
	/// The address of a <c>BOOL</c> variable that receives a value that indicates whether the caller must free the handle returned in
	/// the phCryptProvOrNCryptKey variable. This receives <c>FALSE</c> if any of the following is true:
	/// </para>
	/// <list type="bullet">
	/// <item>
	/// <term>Public key acquisition or comparison fails.</term>
	/// </item>
	/// <item>
	/// <term>The dwFlags parameter contains the <c>CRYPT_ACQUIRE_CACHE_FLAG</c> flag.</term>
	/// </item>
	/// <item>
	/// <term>
	/// The dwFlags parameter contains the <c>CRYPT_ACQUIRE_USE_PROV_INFO_FLAG</c> flag, the certificate context property is set to
	/// <c>CERT_KEY_PROV_INFO_PROP_ID</c> with the CRYPT_KEY_PROV_INFO structure, and the dwFlags member of the
	/// <c>CRYPT_KEY_PROV_INFO</c> structure is set to <c>CERT_SET_KEY_CONTEXT_PROP_ID</c>.
	/// </term>
	/// </item>
	/// </list>
	/// <para>If this variable receives</para>
	/// <para>FALSE</para>
	/// <para>, the calling application must not release the handle returned in the</para>
	/// <para>phCryptProvOrNCryptKey</para>
	/// <para>variable. The handle will be released on the last free action of the</para>
	/// <para>certificate context</para>
	/// <para>.</para>
	/// <para>
	/// If this variable receives <c>TRUE</c>, the caller is responsible for releasing the handle returned in the phCryptProvOrNCryptKey
	/// variable. If the pdwKeySpec variable receives the <c>CERT_NCRYPT_KEY_SPEC</c> flag, the handle must be released by passing it to
	/// the NCryptFreeObject function; otherwise, the handle is released by passing it to the CryptReleaseContext function.
	/// </para>
	/// </param>
	/// <returns>
	/// <para>If the function succeeds, the return value is nonzero ( <c>TRUE</c>).</para>
	/// <para>
	/// If the function fails, the return value is zero ( <c>FALSE</c>). For extended error information, call GetLastError. One possible
	/// error code is the following.
	/// </para>
	/// <list type="table">
	/// <listheader>
	/// <term>Return code</term>
	/// <term>Description</term>
	/// </listheader>
	/// <item>
	/// <term>NTE_BAD_PUBLIC_KEY</term>
	/// <term>
	/// The public key in the certificate does not match the public key returned by the CSP. This error code is returned if the
	/// CRYPT_ACQUIRE_COMPARE_KEY_FLAG is set and the public key in the certificate does not match the public key returned by the
	/// cryptographic provider.
	/// </term>
	/// </item>
	/// <item>
	/// <term>NTE_SILENT_CONTEXT</term>
	/// <term>
	/// The dwFlags parameter contained the CRYPT_ACQUIRE_SILENT_FLAG flag and the CSP could not continue an operation without
	/// displaying a user interface.
	/// </term>
	/// </item>
	/// </list>
	/// </returns>
	/// <remarks>
	/// <para>
	/// When <c>CRYPT_ACQUIRE_WINDOWS_HANDLE_FLAG</c> is set, the caller must ensure the <c>HWND</c> is valid. If the <c>HWND</c> is no
	/// longer valid, for CSP the caller should call CryptSetProvParam using flag PP_CLIENT_HWND with <c>NULL</c> for the <c>HWND</c>
	/// and <c>NULL</c> for the HCRYPTPROV. For KSP, the caller should set the NCRYPT_WINDOW_HANDLE_PROPERTY of the ncrypt key to be
	/// <c>NULL</c>. When <c>CRYPT_ACQUIRE_WINDOWS_HANDLE_FLAG</c> flag is set for KSP, the NCRYPT_WINDOW_HANDLE_PROPERTY is set on the
	/// storage provider and the key. If both calls fail, then the function fails. If only one fails, the function succeeds. Note that
	/// setting <c>HWND</c> to <c>NULL</c> effectively removes <c>HWND</c> from the HCRYPTPROV or ncrypt key.
	/// </para>
	/// <para>Examples</para>
	/// <para>For an example that uses this function, see Example C Program: Sending and Receiving a Signed and Encrypted Message.</para>
	/// </remarks>
	// https://docs.microsoft.com/en-us/windows/win32/api/wincrypt/nf-wincrypt-cryptacquirecertificateprivatekey BOOL
	// CryptAcquireCertificatePrivateKey( PCCERT_CONTEXT pCert, DWORD dwFlags, void *pvParameters, HCRYPTPROV_OR_NCRYPT_KEY_HANDLE
	// *phCryptProvOrNCryptKey, DWORD *pdwKeySpec, BOOL *pfCallerFreeProvOrNCryptKey );
	[DllImport(Lib.Crypt32, SetLastError = true, ExactSpelling = true)]
	[PInvokeData("wincrypt.h", MSDNShortId = "53c9aec9-701d-4c21-9814-d344a8dde0c1")]
	[return: MarshalAs(UnmanagedType.Bool)]
	public static extern bool CryptAcquireCertificatePrivateKey([In] PCCERT_CONTEXT pCert, CryptAcquireFlags dwFlags, [In, Optional] IntPtr pvParameters, out IntPtr phCryptProvOrNCryptKey,
		out CertKeySpec pdwKeySpec, [MarshalAs(UnmanagedType.Bool)] out bool pfCallerFreeProvOrNCryptKey);

	/// <summary>
	/// <para>
	/// The handle of the cryptographic service provider to be used as the default context. This handle is obtained by using the
	/// CryptAcquireContext function.
	/// </para>
	/// <para>Specifies the type of context to install. This must be one of the following values.</para>
	/// <list type="table">
	/// <listheader>
	/// <term>Value</term>
	/// <term>Meaning</term>
	/// </listheader>
	/// <item>
	/// <term>CRYPT_DEFAULT_CONTEXT_CERT_SIGN_OID</term>
	/// <term>
	/// Installs the default provider used to verify a single certificate signature type. The pvDefaultPara parameter is the address of
	/// a null-terminated ANSI string that contains the object identifier of the certificate signature algorithm to install the provider
	/// for, for example, szOID_OIWSEC_md5RSA. If the pvDefaultPara parameter is NULL, the specified provider is used to verify all
	/// certificate signatures. The pvDefaultPara parameter cannot be NULL when the CRYPT_DEFAULT_CONTEXT_PROCESS_FLAG flag is set.
	/// </term>
	/// </item>
	/// <item>
	/// <term>CRYPT_DEFAULT_CONTEXT_MULTI_CERT_SIGN_OID</term>
	/// <term>
	/// Installs the default provider used to verify multiple certificate signature types. The pvDefaultPara parameter is the address of
	/// a CRYPT_DEFAULT_CONTEXT_MULTI_OID_PARA structure that contains an array of object identifiers that identify the certificate
	/// signature algorithms to install the specified provider for.
	/// </term>
	/// </item>
	/// </list>
	/// <para>
	/// Specifies the object or objects to install the default context provider for. The format of this parameter depends on the
	/// contents of the dwDefaultType parameter.
	/// </para>
	/// <para>
	/// A set of flags that modify the behavior of this function. This can be zero or a combination of one or more of the following values.
	/// </para>
	/// <list type="table">
	/// <listheader>
	/// <term>Value</term>
	/// <term>Meaning</term>
	/// </listheader>
	/// <item>
	/// <term>CRYPT_DEFAULT_CONTEXT_AUTO_RELEASE_FLAG</term>
	/// <term>
	/// The provider handle specified by the hCryptProv parameter is released automatically when the process or thread ends. If this
	/// flag is not specified, it is the caller's responsibility to release the provider handle by using the CryptReleaseContext
	/// function when the handle is no longer needed. The provider handle is not released if the CryptUninstallDefaultContext function
	/// is called before the process or thread exits.
	/// </term>
	/// </item>
	/// <item>
	/// <term>CRYPT_DEFAULT_CONTEXT_PROCESS_FLAG</term>
	/// <term>
	/// The provider applies to all threads in the process. If this flag is not specified, the provider only applies to the calling
	/// thread. The pvDefaultPara parameter cannot be NULL when this flag is set.
	/// </term>
	/// </item>
	/// </list>
	/// <para>This parameter is reserved for future use.</para>
	/// <para>
	/// The address of an <c>HCRYPTDEFAULTCONTEXT</c> variable that receives the default context handle. This handle is passed to the
	/// CryptUninstallDefaultContext function to uninstall the default context provider.
	/// </para>
	/// </summary>
	/// <param name="hCryptProv">
	/// The handle of the cryptographic service provider to be used as the default context. This handle is obtained by using the
	/// CryptAcquireContext function.
	/// </param>
	/// <param name="dwDefaultType">
	/// <para>Specifies the type of context to install. This must be one of the following values.</para>
	/// <list type="table">
	/// <listheader>
	/// <term>Value</term>
	/// <term>Meaning</term>
	/// </listheader>
	/// <item>
	/// <term>CRYPT_DEFAULT_CONTEXT_CERT_SIGN_OID</term>
	/// <term>
	/// Installs the default provider used to verify a single certificate signature type. The pvDefaultPara parameter is the address of
	/// a null-terminated ANSI string that contains the object identifier of the certificate signature algorithm to install the provider
	/// for, for example, szOID_OIWSEC_md5RSA. If the pvDefaultPara parameter is NULL, the specified provider is used to verify all
	/// certificate signatures. The pvDefaultPara parameter cannot be NULL when the CRYPT_DEFAULT_CONTEXT_PROCESS_FLAG flag is set.
	/// </term>
	/// </item>
	/// <item>
	/// <term>CRYPT_DEFAULT_CONTEXT_MULTI_CERT_SIGN_OID</term>
	/// <term>
	/// Installs the default provider used to verify multiple certificate signature types. The pvDefaultPara parameter is the address of
	/// a CRYPT_DEFAULT_CONTEXT_MULTI_OID_PARA structure that contains an array of object identifiers that identify the certificate
	/// signature algorithms to install the specified provider for.
	/// </term>
	/// </item>
	/// </list>
	/// </param>
	/// <param name="pvDefaultPara">
	/// Specifies the object or objects to install the default context provider for. The format of this parameter depends on the
	/// contents of the dwDefaultType parameter.
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
	/// <term>CRYPT_DEFAULT_CONTEXT_AUTO_RELEASE_FLAG</term>
	/// <term>
	/// The provider handle specified by the hCryptProv parameter is released automatically when the process or thread ends. If this
	/// flag is not specified, it is the caller's responsibility to release the provider handle by using the CryptReleaseContext
	/// function when the handle is no longer needed. The provider handle is not released if the CryptUninstallDefaultContext function
	/// is called before the process or thread exits.
	/// </term>
	/// </item>
	/// <item>
	/// <term>CRYPT_DEFAULT_CONTEXT_PROCESS_FLAG</term>
	/// <term>
	/// The provider applies to all threads in the process. If this flag is not specified, the provider only applies to the calling
	/// thread. The pvDefaultPara parameter cannot be NULL when this flag is set.
	/// </term>
	/// </item>
	/// </list>
	/// </param>
	/// <param name="pvReserved">This parameter is reserved for future use.</param>
	/// <param name="phDefaultContext">
	/// The address of an <c>HCRYPTDEFAULTCONTEXT</c> variable that receives the default context handle. This handle is passed to the
	/// CryptUninstallDefaultContext function to uninstall the default context provider.
	/// </param>
	/// <returns>
	/// If the function succeeds, the return value is nonzero (TRUE). If the function fails, the return value is zero (FALSE). For
	/// extended error information, call GetLastError.
	/// </returns>
	/// <remarks>
	/// <para>
	/// The installed default context providers are stack ordered, thus when searching for a default context provider, the system starts
	/// with the most recently installed provider. The per-thread list of providers is searched before the per-process list of
	/// providers. After a match is found, the system does not continue to search for other matches.
	/// </para>
	/// <para>
	/// The installed provider handle must remain available for use until CryptUninstallDefaultContext is called, or the thread or
	/// process exits.
	/// </para>
	/// </remarks>
	// https://docs.microsoft.com/en-us/windows/win32/api/wincrypt/nf-wincrypt-cryptinstalldefaultcontext BOOL
	// CryptInstallDefaultContext( HCRYPTPROV hCryptProv, DWORD dwDefaultType, const void *pvDefaultPara, DWORD dwFlags, void
	// *pvReserved, HCRYPTDEFAULTCONTEXT *phDefaultContext );
	[DllImport(Lib.Crypt32, SetLastError = true, ExactSpelling = true)]
	[PInvokeData("wincrypt.h", MSDNShortId = "79d121df-0699-424e-a8de-5fc2b396afc2")]
	[return: MarshalAs(UnmanagedType.Bool)]
	public static extern bool CryptInstallDefaultContext(HCRYPTPROV hCryptProv, CryptDefaultContextType dwDefaultType, [In] IntPtr pvDefaultPara,
		CryptDefaultContextFlags dwFlags, [Optional] IntPtr pvReserved, out HCRYPTDEFAULTCONTEXT phDefaultContext);

	/// <summary>
	/// The <c>CryptRetrieveTimeStamp</c> function encodes a time stamp request and retrieves the time stamp token from a location
	/// specified by a URL to a Time Stamping Authority (TSA).
	/// </summary>
	/// <param name="wszUrl">
	/// A pointer to a null-terminated wide character string that contains the URL of the TSA to which to send the request.
	/// </param>
	/// <param name="dwRetrievalFlags">
	/// <para>A set of flags that specify how the time stamp is retrieved.</para>
	/// <list type="table">
	/// <listheader>
	/// <term>Value</term>
	/// <term>Meaning</term>
	/// </listheader>
	/// <item>
	/// <term>TIMESTAMP_DONT_HASH_DATA 0x00000001</term>
	/// <term>Inhibit hash calculation on the array of bytes pointed to by the pbData parameter.</term>
	/// </item>
	/// <item>
	/// <term>TIMESTAMP_VERIFY_CONTEXT_SIGNATURE 0x00000020</term>
	/// <term>Enforce signature validation on the retrieved time stamp.</term>
	/// </item>
	/// <item>
	/// <term>TIMESTAMP_NO_AUTH_RETRIEVAL 0x00020000</term>
	/// <term>Set this flag to inhibit automatic authentication handling.</term>
	/// </item>
	/// </list>
	/// </param>
	/// <param name="dwTimeout">
	/// A <c>DWORD</c> value that specifies the maximum number of milliseconds to wait for retrieval. If this parameter is set to zero,
	/// this function does not time out.
	/// </param>
	/// <param name="pszHashId">
	/// A pointer to a null-terminated character string that contains the hash algorithm object identifier (OID).
	/// </param>
	/// <param name="pPara">A pointer to a CRYPT_TIMESTAMP_PARA structure that contains additional parameters for the request.</param>
	/// <param name="pbData">A pointer to an array of bytes to be time stamped.</param>
	/// <param name="cbData">The size, in bytes, of the array pointed to by the pbData parameter.</param>
	/// <param name="ppTsContext">
	/// A pointer to a PCRYPT_TIMESTAMP_CONTEXT structure. When you have finished using the context, you must free it by calling the
	/// CryptMemFree function.
	/// </param>
	/// <param name="ppTsSigner">
	/// <para>
	/// A pointer to a PCERT_CONTEXT that receives the certificate of the signer. When you have finished using this structure, you must
	/// free it by passing this pointer to the CertFreeCertificateContext function.
	/// </para>
	/// <para>Set this parameter to <c>NULL</c> if the TSA signer's certificate is not needed.</para>
	/// </param>
	/// <param name="phStore">
	/// <para>
	/// The handle of a certificate store initialized with certificates from the time stamp response. This store can be used for
	/// validating the signer certificate of the time stamp response.
	/// </para>
	/// <para>
	/// This parameter can be <c>NULL</c> if the TSA supporting certificates are not needed. When you have finished using this handle,
	/// release it by passing it to the CertCloseStore function.
	/// </para>
	/// </param>
	/// <returns>
	/// If the function is unable to retrieve, decode, and validate the time stamp context, it returns <c>FALSE</c>. For extended error
	/// information, call the GetLastError function.
	/// </returns>
	// https://docs.microsoft.com/en-us/windows/win32/api/wincrypt/nf-wincrypt-cryptretrievetimestamp BOOL CryptRetrieveTimeStamp(
	// LPCWSTR wszUrl, DWORD dwRetrievalFlags, DWORD dwTimeout, LPCSTR pszHashId, const CRYPT_TIMESTAMP_PARA *pPara, const BYTE *pbData,
	// DWORD cbData, PCRYPT_TIMESTAMP_CONTEXT *ppTsContext, PCCERT_CONTEXT *ppTsSigner, HCERTSTORE *phStore );
	[DllImport(Lib.Crypt32, SetLastError = true, ExactSpelling = true)]
	[PInvokeData("wincrypt.h", MSDNShortId = "68ba3d40-08b0-4261-ab2f-6deb1795f830")]
	[return: MarshalAs(UnmanagedType.Bool)]
	public static extern bool CryptRetrieveTimeStamp([MarshalAs(UnmanagedType.LPWStr)] string wszUrl, TimeStampRetrivalFlags dwRetrievalFlags, uint dwTimeout, SafeOID pszHashId,
		in CRYPT_TIMESTAMP_PARA pPara, [In] IntPtr pbData, uint cbData, out SafeCryptMem ppTsContext, out SafePCCERT_CONTEXT ppTsSigner, out SafeHCERTSTORE phStore);

	/// <summary>
	/// <para>Handle of the context to be released.</para>
	/// <para>Reserved for future use.</para>
	/// <para>Reserved for future use.</para>
	/// </summary>
	/// <param name="hDefaultContext">Handle of the context to be released.</param>
	/// <param name="dwFlags">Reserved for future use.</param>
	/// <param name="pvReserved">Reserved for future use.</param>
	/// <returns>
	/// If the function succeeds, the return value is nonzero (TRUE) .If the function fails, the return value is zero (FALSE). For
	/// extended error information, call GetLastError.
	/// </returns>
	// https://docs.microsoft.com/en-us/windows/win32/api/wincrypt/nf-wincrypt-cryptuninstalldefaultcontext BOOL
	// CryptUninstallDefaultContext( HCRYPTDEFAULTCONTEXT hDefaultContext, DWORD dwFlags, void *pvReserved );
	[DllImport(Lib.Crypt32, SetLastError = true, ExactSpelling = true)]
	[PInvokeData("wincrypt.h", MSDNShortId = "ad7be5cf-f078-4a9f-81c4-959e4203dba8")]
	[return: MarshalAs(UnmanagedType.Bool)]
	public static extern bool CryptUninstallDefaultContext(HCRYPTDEFAULTCONTEXT hDefaultContext, uint dwFlags = 0, IntPtr pvReserved = default);

	/// <summary>The <c>CryptVerifyTimeStampSignature</c> function validates the time stamp signature on a specified array of bytes.</summary>
	/// <param name="pbTSContentInfo">A pointer to a buffer that contains time stamp content.</param>
	/// <param name="cbTSContentInfo">The size, in bytes, of the buffer pointed to by the pbTSContentInfo parameter.</param>
	/// <param name="pbData">A pointer to an array of bytes on which to validate the time stamp signature.</param>
	/// <param name="cbData">The size, in bytes, of the array pointed to by the pbData parameter.</param>
	/// <param name="hAdditionalStore">
	/// The handle of an additional store to search for supporting Time Stamping Authority (TSA) signing certificates and certificate
	/// trust lists (CTLs). This parameter can be <c>NULL</c> if no additional store is to be searched.
	/// </param>
	/// <param name="ppTsContext">
	/// A pointer to a PCRYPT_TIMESTAMP_CONTEXT structure. When you have finished using the context, you must free it by calling the
	/// CryptMemFree function.
	/// </param>
	/// <param name="ppTsSigner">
	/// <para>
	/// A pointer to a PCERT_CONTEXT that receives the certificate of the signer. When you have finished using this structure, you must
	/// free it by passing this pointer to the CertFreeCertificateContext function.
	/// </para>
	/// <para>Set this parameter to <c>NULL</c> if the TSA signer's certificate is not needed.</para>
	/// </param>
	/// <param name="phStore">
	/// <para>A pointer to a handle that receives the certificate store opened on CMS to search for supporting certificates.</para>
	/// <para>
	/// This parameter can be <c>NULL</c> if the TSA supporting certificates are not needed. When you have finished using this handle,
	/// you must release it by passing it to the CertCloseStore function.
	/// </para>
	/// </param>
	/// <returns>
	/// If the function succeeds, the function returns <c>TRUE</c>. For extended error information, call the GetLastError function.
	/// </returns>
	/// <remarks>
	/// The caller should validate the <c>pszTSAPolicyId</c> member of the CRYPT_TIMESTAMP_INFO structure when it is returned by the
	/// CryptRetrieveTimeStamp function. If a TSA policy was specified in the request and the <c>ftTime</c> member contains a valid
	/// value, the caller should build a certificate context chain with which to populate the ppTsSigner parameter and validate the trust.
	/// </remarks>
	// https://docs.microsoft.com/en-us/windows/win32/api/wincrypt/nf-wincrypt-cryptverifytimestampsignature BOOL
	// CryptVerifyTimeStampSignature( const BYTE *pbTSContentInfo, DWORD cbTSContentInfo, const BYTE *pbData, DWORD cbData, HCERTSTORE
	// hAdditionalStore, PCRYPT_TIMESTAMP_CONTEXT *ppTsContext, PCCERT_CONTEXT *ppTsSigner, HCERTSTORE *phStore );
	[DllImport(Lib.Crypt32, SetLastError = true, ExactSpelling = true)]
	[PInvokeData("wincrypt.h", MSDNShortId = "791b1500-98e3-49d5-97aa-be91f5edb7c2")]
	[return: MarshalAs(UnmanagedType.Bool)]
	public static extern bool CryptVerifyTimeStampSignature([In] IntPtr pbTSContentInfo, uint cbTSContentInfo, [In, Optional] IntPtr pbData, uint cbData,
		[In, Optional] HCERTSTORE hAdditionalStore, out SafeCryptMem ppTsContext, out SafePCCERT_CONTEXT ppTsSigner, out SafeHCERTSTORE phStore);

	/// <summary>Determines whether a cryptography algorithm is only supported by using the CNG functions.</summary>
	/// <param name="Algid">The cryptography algorithm.</param>
	/// <returns><see langword="true"/> if algorithm is only supported by using the CNG functions; otherwise, <see langword="false"/>.</returns>
	public static bool IS_SPECIAL_OID_INFO_ALGID(ALG_ID Algid) => Algid >= ALG_ID.CALG_OID_INFO_PARAMETERS;

	/// <summary>
	/// The CERT_CONTEXT structure contains both the encoded and decoded representations of a certificate. A certificate context
	/// returned by one of the functions defined in Wincrypt.h must be freed by calling the CertFreeCertificateContext function. The
	/// CertDuplicateCertificateContext function can be called to make a duplicate copy (which also must be freed by calling CertFreeCertificateContext).
	/// </summary>
	[PInvokeData("wincrypt.h")]
	[StructLayout(LayoutKind.Sequential)]
	public struct CERT_CONTEXT
	{
		/// <summary>
		/// Type of encoding used. It is always acceptable to specify both the certificate and message encoding types by combining them
		/// with a bitwise-OR operation.
		/// </summary>
		public CertEncodingType dwCertEncodingType;

		/// <summary>A pointer to a buffer that contains the encoded certificate.</summary>
		public IntPtr pbCertEncoded;

		/// <summary>The size, in bytes, of the encoded certificate.</summary>
		public uint cbCertEncoded;

		/// <summary>The address of a CERT_INFO structure that contains the certificate information.</summary>
		public IntPtr pCertInfo;

		/// <summary>A handle to the certificate store that contains the certificate context.</summary>
		public HCERTSTORE hCertStore;

		/// <summary>The address of a CERT_INFO structure that contains the certificate information.</summary>
		public unsafe CERT_INFO* pUnsafeCertInfo => (CERT_INFO*)(void*)pCertInfo;
	}

	/// <summary>
	/// The <c>CERT_EXTENSION</c> structure contains the extension information for a certificate, Certificate Revocation List (CRL) or
	/// Certificate Trust List (CTL).
	/// </summary>
	// https://docs.microsoft.com/en-us/windows/win32/api/wincrypt/ns-wincrypt-cert_extension typedef struct _CERT_EXTENSION { LPSTR
	// pszObjId; BOOL fCritical; CRYPT_OBJID_BLOB Value; } CERT_EXTENSION, *PCERT_EXTENSION;
	[PInvokeData("wincrypt.h", MSDNShortId = "787a4df0-c0e3-46b9-a7e6-eb3bee3ed717")]
	[StructLayout(LayoutKind.Sequential)]
	public struct CERT_EXTENSION
	{
		/// <summary>
		/// Object identifier (OID) that specifies the structure of the extension data contained in the <c>Value</c> member. For
		/// specifics on extension OIDs and their related structures, see X.509 Certificate Extension Structures.
		/// </summary>
		public StrPtrAnsi pszObjId;

		/// <summary>
		/// If <c>TRUE</c>, any limitations specified by the extension in the <c>Value</c> member of this structure are imperative. If
		/// <c>FALSE</c>, limitations set by this extension can be ignored.
		/// </summary>
		[MarshalAs(UnmanagedType.Bool)] public bool fCritical;

		/// <summary>
		/// A CRYPT_OBJID_BLOB structure that contains the encoded extension data. The <c>cbData</c> member of <c>Value</c> indicates
		/// the length in bytes of the <c>pbData</c> member. The <c>pbData</c> member byte string is the encoded extension.
		/// </summary>
		public CRYPTOAPI_BLOB Value;
	}

	/// <summary>The <c>CERT_EXTENSIONS</c> structure contains an array of extensions.</summary>
	// https://docs.microsoft.com/en-us/windows/win32/api/wincrypt/ns-wincrypt-cert_extensions typedef struct _CERT_EXTENSIONS { DWORD
	// cExtension; PCERT_EXTENSION rgExtension; } CERT_EXTENSIONS, *PCERT_EXTENSIONS;
	[PInvokeData("wincrypt.h", MSDNShortId = "b393ef08-cedb-4840-a427-10ead315d6ea")]
	[StructLayout(LayoutKind.Sequential)]
	public struct CERT_EXTENSIONS
	{
		/// <summary>Number of elements in the array <c>rgExtension</c>.</summary>
		public uint cExtension;

		/// <summary>Array of structures, each holding information of type CERT_EXTENSION about a certificate or CRL.</summary>
		public IntPtr rgExtension;
	}

	/// <summary>The <c>CERT_ID</c> structure is used as a flexible means of uniquely identifying a certificate.</summary>
	// https://docs.microsoft.com/en-us/windows/win32/api/wincrypt/ns-wincrypt-cert_id typedef struct _CERT_ID { DWORD dwIdChoice; union
	// { CERT_ISSUER_SERIAL_NUMBER IssuerSerialNumber; CRYPT_HASH_BLOB KeyId; CRYPT_HASH_BLOB HashId; } DUMMYUNIONNAME; } CERT_ID, *PCERT_ID;
	[PInvokeData("wincrypt.h", MSDNShortId = "9e33f661-c365-4725-8c3f-27b6cdd9a84e")]
	[StructLayout(LayoutKind.Explicit)]
	public struct CERT_ID
	{
		/// <summary>
		/// <para>A <c>DWORD</c> value that indicates which member of the union is being used. This can be one of the following values.</para>
		/// <list type="table">
		/// <listheader>
		/// <term>Value</term>
		/// <term>Meaning</term>
		/// </listheader>
		/// <item>
		/// <term>CERT_ID_ISSUER_SERIAL_NUMBER</term>
		/// <term>IssuerSerialNumber</term>
		/// </item>
		/// <item>
		/// <term>CERT_ID_KEY_IDENTIFIER</term>
		/// <term>KeyId</term>
		/// </item>
		/// <item>
		/// <term>CERT_ID_SHA1_HASH</term>
		/// <term>HashId</term>
		/// </item>
		/// </list>
		/// </summary>
		[FieldOffset(0)]
		public uint dwIdChoice;

		/// <summary>A CERT_ISSUER_SERIAL_NUMBER structure that uniquely identifies a certificate.</summary>
		[FieldOffset(4)]
		public CERT_ISSUER_SERIAL_NUMBER IssuerSerialNumber;

		/// <summary>A CRYPT_HASH_BLOB structure that contains a certificate key identifier.</summary>
		[FieldOffset(4)]
		public CRYPTOAPI_BLOB KeyId;

		/// <summary>A CRYPT_HASH_BLOB that contains a SHA1 hash of the certificate to be used as a unique identifier of the certificate.</summary>
		[FieldOffset(4)]
		public CRYPTOAPI_BLOB HashId;
	}

	/// <summary>The CERT_INFO structure contains the information of a certificate.</summary>
	[PInvokeData("wincrypt.h")]
	[StructLayout(LayoutKind.Sequential, CharSet = CharSet.Ansi)]
	public struct CERT_INFO
	{
		/// <summary>The version number of a certificate.</summary>
		public uint dwVersion;

		/// <summary>
		/// A BLOB that contains the serial number of a certificate. The least significant byte is the zero byte of the pbData member of
		/// SerialNumber. The index for the last byte of pbData, is one less than the value of the cbData member of SerialNumber. The
		/// most significant byte is the last byte of pbData. Leading 0x00 or 0xFF bytes are removed. For more information, see CertCompareIntegerBlob.
		/// </summary>
		public CRYPTOAPI_BLOB SerialNumber;

		/// <summary>
		/// A CRYPT_ALGORITHM_IDENTIFIER structure that contains the signature algorithm type and encoded additional encryption parameters.
		/// </summary>
		public CRYPT_ALGORITHM_IDENTIFIER SignatureAlgorithm;

		/// <summary>The name, in encoded form, of the issuer of the certificate.</summary>
		public CRYPTOAPI_BLOB Issuer;

		/// <summary>
		/// Date and time before which the certificate is not valid. For dates between 1950 and 2049 inclusive, the date and time is
		/// encoded Coordinated Universal Time (Greenwich Mean Time) format in the form YYMMDDHHMMSS. This member uses a two-digit year
		/// and is precise to seconds. For dates before 1950 or after 2049, encoded generalized time is used. Encoded generalized time
		/// is in the form YYYYMMDDHHMMSSMMM, using a four-digit year, and is precise to milliseconds. Even though generalized time
		/// supports millisecond resolution, the NotBefore time is only precise to seconds.
		/// </summary>
		public FILETIME NotBefore;

		/// <summary>
		/// Date and time after which the certificate is not valid. For dates between 1950 and 2049 inclusive, the date and time is
		/// encoded Coordinated Universal Time format in the form YYMMDDHHMMSS. This member uses a two-digit year and is precise to
		/// seconds. For dates before 1950 or after 2049, encoded generalized time is used. Encoded generalized time is in the form
		/// YYYYMMDDHHMMSSMMM, using a four-digit year, and is precise to milliseconds. Even though generalized time supports
		/// millisecond resolution, the NotAfter time is only precise to seconds.
		/// </summary>
		public FILETIME NotAfter;

		/// <summary>The encoded name of the subject of the certificate.</summary>
		public CRYPTOAPI_BLOB Subject;

		/// <summary>
		/// A CERT_PUBLIC_KEY_INFO structure that contains the encoded public key and its algorithm. The PublicKey member of the
		/// CERT_PUBLIC_KEY_INFO structure contains the encoded public key as a CRYPT_BIT_BLOB, and the Algorithm member contains the
		/// encoded algorithm as a CRYPT_ALGORITHM_IDENTIFIER.
		/// </summary>
		public CERT_PUBLIC_KEY_INFO SubjectPublicKeyInfo;

		/// <summary>A BLOB that contains a unique identifier of the issuer.</summary>
		public CRYPT_BIT_BLOB IssuerUniqueId;

		/// <summary>A BLOB that contains a unique identifier of the subject.</summary>
		public CRYPT_BIT_BLOB SubjectUniqueId;

		/// <summary>The number of elements in the rgExtension array.</summary>
		public uint cExtension;

		/// <summary>An array of pointers to CERT_EXTENSION structures, each of which contains extension information about the certificate.</summary>
		public IntPtr rgExtension;
	}

	/// <summary>
	/// The <c>CERT_ISSUER_SERIAL_NUMBER</c> structure acts as a unique identifier of a certificate containing the issuer and issuer's
	/// serial number for a certificate.
	/// </summary>
	// https://docs.microsoft.com/en-us/windows/win32/api/wincrypt/ns-wincrypt-cert_issuer_serial_number typedef struct
	// _CERT_ISSUER_SERIAL_NUMBER { CERT_NAME_BLOB Issuer; CRYPT_INTEGER_BLOB SerialNumber; } CERT_ISSUER_SERIAL_NUMBER, *PCERT_ISSUER_SERIAL_NUMBER;
	[PInvokeData("wincrypt.h", MSDNShortId = "4e44113f-81e7-4551-bf4d-50986d6d57bb")]
	[StructLayout(LayoutKind.Sequential)]
	public struct CERT_ISSUER_SERIAL_NUMBER
	{
		/// <summary>A BLOB structure that contains the name of the issuer.</summary>
		public CRYPTOAPI_BLOB Issuer;

		/// <summary>
		/// A CRYPT_INTEGER_BLOB structure that contains the serial number of the certificate. The combination of the issuer name and
		/// the serial number is a unique identifier of a certificate.
		/// </summary>
		public CRYPTOAPI_BLOB SerialNumber;
	}

	/// <summary>The <c>CERT_KEY_CONTEXT</c> structure contains data associated with a CERT_KEY_CONTEXT_PROP_ID property.</summary>
	// https://docs.microsoft.com/en-us/windows/win32/api/wincrypt/ns-wincrypt-cert_key_context typedef struct _CERT_KEY_CONTEXT { DWORD
	// cbSize; union { HCRYPTPROV hCryptProv; NCRYPT_KEY_HANDLE hNCryptKey; } DUMMYUNIONNAME; DWORD dwKeySpec; } CERT_KEY_CONTEXT, *PCERT_KEY_CONTEXT;
	[PInvokeData("wincrypt.h", MSDNShortId = "796adb9c-ec38-41d0-8f8b-ea1053e9f9f0")]
	[StructLayout(LayoutKind.Sequential)]
	public struct CERT_KEY_CONTEXT
	{
		/// <summary>The size, in bytes, of this structure.</summary>
		public uint cbSize;

		/// <summary>
		/// A cryptographic service provider (CSP) handle. This member is used when the <c>dwKeySpec</c> member contains
		/// <c>AT_KEYEXCHANGE</c> or <c>AT_SIGNATURE</c>.
		/// <para><strong>OR</strong></para>
		/// <para>A CNG CSP handle. This member is used when the <c>dwKeySpec</c> member contains <c>CERT_NCRYPT_KEY_SPEC</c>.</para>
		/// <para><c>Windows Server 2003 and Windows XP:</c> This member is not available.</para>
		/// </summary>
		public IntPtr hCryptProv_or_hNCryptKey;

		/// <summary>
		/// <para>The specification of the private key to retrieve.</para>
		/// </summary>
		public CertKeySpec dwKeySpec;
	}

	/// <summary>The CERT_PUBLIC_KEY_INFO structure contains a public key and its algorithm.</summary>
	[PInvokeData("wincrypt.h")]
	[StructLayout(LayoutKind.Sequential, CharSet = CharSet.Ansi)]
	public struct CERT_PUBLIC_KEY_INFO
	{
		/// <summary>CRYPT_ALGORITHM_IDENTIFIER structure that contains the public key algorithm type and associated additional parameters.</summary>
		public CRYPT_ALGORITHM_IDENTIFIER Algorithm;

		/// <summary>BLOB containing an encoded public key.</summary>
		public CRYPT_BIT_BLOB PublicKey;
	}

	/// <summary>
	/// The <c>CERT_RDN</c> structure contains a relative distinguished name (RDN) consisting of an array of CERT_RDN_ATTR structures.
	/// </summary>
	// https://docs.microsoft.com/en-us/windows/win32/api/wincrypt/ns-wincrypt-cert_rdn typedef struct _CERT_RDN { DWORD cRDNAttr;
	// PCERT_RDN_ATTR rgRDNAttr; } CERT_RDN, *PCERT_RDN;
	[PInvokeData("wincrypt.h", MSDNShortId = "e84254b9-e9a7-4689-a12f-2772282c5433")]
	[StructLayout(LayoutKind.Sequential)]
	public struct CERT_RDN
	{
		/// <summary>Number of elements in the <c>rgRDNAttr</c> array.</summary>
		public uint cRDNAttr;

		/// <summary>Array of CERT_RDN_ATTR structures.</summary>
		public IntPtr rgRDNAttr;
	}

	/// <summary>
	/// The <c>CERT_RDN_ATTR</c> structure contains a single attribute of a relative distinguished name (RDN). A whole RDN is expressed
	/// in a CERT_RDN structure that contains an array of <c>CERT_RDN_ATTR</c> structures.
	/// </summary>
	// https://docs.microsoft.com/en-us/windows/win32/api/wincrypt/ns-wincrypt-cert_rdn_attr
	// typedef struct _CERT_RDN_ATTR { LPSTR pszObjId; DWORD dwValueType; CERT_RDN_VALUE_BLOB Value; } CERT_RDN_ATTR, *PCERT_RDN_ATTR;
	[PInvokeData("wincrypt.h", MSDNShortId = "NS:wincrypt._CERT_RDN_ATTR")]
	[StructLayout(LayoutKind.Sequential)]
	public struct CERT_RDN_ATTR
	{
		/// <summary>
		/// <para>
		/// Object identifier (OID) for the type of the attribute defined in this structure. This member can be one of the <see cref="AttrOID"/> values.
		/// </para>
		/// <list type="table">
		/// <listheader>
		/// <term>Value</term>
		/// <term>Meaning</term>
		/// </listheader>
		/// <item>
		/// <term>szOID_AUTHORITY_REVOCATION_LIST</term>
		/// <term>Security attribute.</term>
		/// </item>
		/// <item>
		/// <term>szOID_BUSINESS_CATEGORY</term>
		/// <term>Case-insensitive string. Explanatory attribute.</term>
		/// </item>
		/// <item>
		/// <term>szOID_CA_CERTIFICATE</term>
		/// <term>Security attribute.</term>
		/// </item>
		/// <item>
		/// <term>szOID_CERTIFICATE_REVOCATION_LIST</term>
		/// <term>Security attribute.</term>
		/// </item>
		/// <item>
		/// <term>szOID_COMMON_NAME</term>
		/// <term>Case-insensitive string. Labeling attribute.</term>
		/// </item>
		/// <item>
		/// <term>szOID_COUNTRY_NAME</term>
		/// <term>Two-character printable string. Geographic attribute.</term>
		/// </item>
		/// <item>
		/// <term>szOID_CROSS_CERTIFICATE_PAIR</term>
		/// <term>Security attribute.</term>
		/// </item>
		/// <item>
		/// <term>szOID_DESCRIPTION</term>
		/// <term>Case-insensitive string. Explanatory attribute.</term>
		/// </item>
		/// <item>
		/// <term>szOID_DESTINATION_INDICATOR</term>
		/// <term>Printable string. Telecommunications addressing attribute.</term>
		/// </item>
		/// <item>
		/// <term>szOID_DEVICE_SERIAL_NUMBER</term>
		/// <term>Printable string. Labeling attribute.</term>
		/// </item>
		/// <item>
		/// <term>szOID_DOMAIN_COMPONENT</term>
		/// <term>IA5 string. DNS name component such as "com."</term>
		/// </item>
		/// <item>
		/// <term>szOID_FACSIMILE_TELEPHONE_NUMBER</term>
		/// <term>Telecommunications addressing attribute.</term>
		/// </item>
		/// <item>
		/// <term>szOID_GIVEN_NAME</term>
		/// <term>Case-insensitive string. Name attribute.</term>
		/// </item>
		/// <item>
		/// <term>szOID_INITIALS</term>
		/// <term>Case-insensitive string. Name attribute.</term>
		/// </item>
		/// <item>
		/// <term>szOID_INTERNATIONAL_ISDN_NUMBER</term>
		/// <term>Numeric string. Telecommunications addressing attribute.</term>
		/// </item>
		/// <item>
		/// <term>szOID_LOCALITY_NAME</term>
		/// <term>Case-insensitive string. Geographic attribute.</term>
		/// </item>
		/// <item>
		/// <term>szOID_MEMBER</term>
		/// <term>Relational application attribute.</term>
		/// </item>
		/// <item>
		/// <term>szOID_ORGANIZATION_NAME</term>
		/// <term>Case-insensitive string. Organizational attribute.</term>
		/// </item>
		/// <item>
		/// <term>szOID_ORGANIZATIONAL_UNIT_NAME</term>
		/// <term>Case-insensitive string. Organizational attribute.</term>
		/// </item>
		/// <item>
		/// <term>szOID_OWNER</term>
		/// <term>Relational application attribute.</term>
		/// </item>
		/// <item>
		/// <term>szOID_PHYSICAL_DELIVERY_OFFICE_NAME</term>
		/// <term>Case-insensitive string. Postal addressing attribute.</term>
		/// </item>
		/// <item>
		/// <term>szOID_PKCS_12_FRIENDLY_NAME_ATTR</term>
		/// <term>PKCS #12 attribute.</term>
		/// </item>
		/// <item>
		/// <term>szOID_PKCS_12_LOCAL_KEY_ID</term>
		/// <term>PKCS #12 attribute.</term>
		/// </item>
		/// <item>
		/// <term>szOID_POST_OFFICE_BOX</term>
		/// <term>Case-insensitive string. Postal addressing attribute.</term>
		/// </item>
		/// <item>
		/// <term>szOID_POSTAL_ADDRESS</term>
		/// <term>Printable string. Postal addressing attribute.</term>
		/// </item>
		/// <item>
		/// <term>szOID_POSTAL_CODE</term>
		/// <term>Case-insensitive string. Postal addressing attribute.</term>
		/// </item>
		/// <item>
		/// <term>szOID_PREFERRED_DELIVERY_METHOD</term>
		/// <term>Preference attribute.</term>
		/// </item>
		/// <item>
		/// <term>szOID_PRESENTATION_ADDRESS</term>
		/// <term>OSI application attribute.</term>
		/// </item>
		/// <item>
		/// <term>szOID_REGISTERED_ADDRESS</term>
		/// <term>Telecommunications addressing attribute.</term>
		/// </item>
		/// <item>
		/// <term>szOID_ROLE_OCCUPANT</term>
		/// <term>Relational application attribute.</term>
		/// </item>
		/// <item>
		/// <term>szOID_RSA_emailAddr</term>
		/// <term>IA5 string. Email attribute.</term>
		/// </item>
		/// <item>
		/// <term>szOID_SEARCH_GUIDE</term>
		/// <term>Explanatory attribute.</term>
		/// </item>
		/// <item>
		/// <term>szOID_SEE_ALSO</term>
		/// <term>Relational application attribute.</term>
		/// </item>
		/// <item>
		/// <term>szOID_STATE_OR_PROVINCE_NAME</term>
		/// <term>Case-insensitive string. Geographic attribute.</term>
		/// </item>
		/// <item>
		/// <term>szOID_STREET_ADDRESS</term>
		/// <term>Case-insensitive string. Geographic attribute.</term>
		/// </item>
		/// <item>
		/// <term>szOID_SUPPORTED_APPLICATION_CONTEXT</term>
		/// <term>OSI application attribute.</term>
		/// </item>
		/// <item>
		/// <term>szOID_SUR_NAME</term>
		/// <term>Case-insensitive string. Labeling attribute.</term>
		/// </item>
		/// <item>
		/// <term>szOID_TELEPHONE_NUMBER</term>
		/// <term>Telecommunications addressing attribute.</term>
		/// </item>
		/// <item>
		/// <term>szOID_TELETEXT_TERMINAL_IDENTIFIER</term>
		/// <term>Telecommunications addressing attribute.</term>
		/// </item>
		/// <item>
		/// <term>szOID_TELEX_NUMBER</term>
		/// <term>Telecommunications addressing attribute.</term>
		/// </item>
		/// <item>
		/// <term>szOID_TITLE</term>
		/// <term>Case-insensitive string. Organizational attribute.</term>
		/// </item>
		/// <item>
		/// <term>szOID_USER_CERTIFICATE</term>
		/// <term>Security attribute.</term>
		/// </item>
		/// <item>
		/// <term>szOID_USER_PASSWORD</term>
		/// <term>Security attribute.</term>
		/// </item>
		/// <item>
		/// <term>szOID_X21_ADDRESS</term>
		/// <term>Numeric string. Telecommunications addressing attribute.</term>
		/// </item>
		/// </list>
		/// </summary>
		[MarshalAs(UnmanagedType.LPStr)]
		public string pszObjId;

		/// <summary>
		/// <para>Indicates the interpretation of the <c>Value</c> member.</para>
		/// <para>This member can be one of the following values.</para>
		/// <list type="table">
		/// <listheader>
		/// <term>Value</term>
		/// <term>Meaning</term>
		/// </listheader>
		/// <item>
		/// <term>CERT_RDN_ANY_TYPE</term>
		/// <term>The pszObjId member determines the assumed type and length.</term>
		/// </item>
		/// <item>
		/// <term>CERT_RDN_BMP_STRING</term>
		/// <term>An array of Unicode characters (16-bit).</term>
		/// </item>
		/// <item>
		/// <term>CERT_RDN_ENCODED_BLOB</term>
		/// <term>An encoded data BLOB.</term>
		/// </item>
		/// <item>
		/// <term>CERT_RDN_GENERAL_STRING</term>
		/// <term>Currently not used.</term>
		/// </item>
		/// <item>
		/// <term>CERT_RDN_GRAPHIC_STRING</term>
		/// <term>Currently not used.</term>
		/// </item>
		/// <item>
		/// <term>CERT_RDN_IA5_STRING</term>
		/// <term>An arbitrary string of IA5 (ASCII) characters.</term>
		/// </item>
		/// <item>
		/// <term>CERT_RDN_INT4_STRING</term>
		/// <term>An array of INT4 elements (32-bit).</term>
		/// </item>
		/// <item>
		/// <term>CERT_RDN_ISO646_STRING</term>
		/// <term>A 128-character set (8-bit).</term>
		/// </item>
		/// <item>
		/// <term>CERT_RDN_NUMERIC_STRING</term>
		/// <term>Only the characters 0 through 9 and the space character (8-bit).</term>
		/// </item>
		/// <item>
		/// <term>CERT_RDN_OCTET_STRING</term>
		/// <term>An arbitrary string of octets (8-bit).</term>
		/// </item>
		/// <item>
		/// <term>CERT_RDN_PRINTABLE_STRING</term>
		/// <term>An arbitrary string of printable characters (8-bit).</term>
		/// </item>
		/// <item>
		/// <term>CERT_RDN_T61_STRING</term>
		/// <term>An arbitrary string of T.61 characters (8-bit).</term>
		/// </item>
		/// <item>
		/// <term>CERT_RDN_TELETEX_STRING</term>
		/// <term>An arbitrary string of T.61 characters (8-bit)</term>
		/// </item>
		/// <item>
		/// <term>CERT_RDN_UNICODE_STRING</term>
		/// <term>An array of Unicode characters (16-bit).</term>
		/// </item>
		/// <item>
		/// <term>CERT_RDN_UNIVERSAL_STRING</term>
		/// <term>An array of INT4 elements (32-bit).</term>
		/// </item>
		/// <item>
		/// <term>CERT_RDN_UTF8_STRING</term>
		/// <term>An array of 16 bit Unicode characters UTF8 encoded on the wire as a sequence of one, two, or three, eight-bit characters.</term>
		/// </item>
		/// <item>
		/// <term>CERT_RDN_VIDEOTEX_STRING</term>
		/// <term>An arbitrary string of videotext characters.</term>
		/// </item>
		/// <item>
		/// <term>CERT_RDN_VISIBLE_STRING</term>
		/// <term>A 95-character set (8-bit).</term>
		/// </item>
		/// </list>
		/// <para>The following flags can be combined by using a bitwise- <c>OR</c> operation into the <c>dwValueType</c> member.</para>
		/// <list type="table">
		/// <listheader>
		/// <term>Value</term>
		/// <term>Meaning</term>
		/// </listheader>
		/// <item>
		/// <term>CERT_RDN_DISABLE_CHECK_TYPE_FLAG</term>
		/// <term>For encoding. When set, the characters are not checked to determine whether they are valid for the value type.</term>
		/// </item>
		/// <item>
		/// <term>CERT_RDN_DISABLE_IE4_UTF8_FLAG</term>
		/// <term>
		/// For decoding. By default, CERT_RDN_T61_STRING encoded values are initially decoded as UTF8. If the UTF8 decoding fails, the
		/// value is decoded as 8-bit characters. If this flag is set, it skips the initial attempt to decode as UTF8 and decodes the
		/// value as 8-bit characters.
		/// </term>
		/// </item>
		/// <item>
		/// <term>CERT_RDN_ENABLE_T61_UNICODE_FLAG</term>
		/// <term>
		/// For encoding. When set, if all the Unicode characters are &lt;= 0xFF, the CERT_RDN_T61_STRING value is selected instead of
		/// the CERT_RDN_UNICODE_STRING value.
		/// </term>
		/// </item>
		/// <item>
		/// <term>CERT_RDN_ENABLE_UTF8_UNICODE_FLAG</term>
		/// <term>
		/// For encoding. When set, strings are encoded with the CERT_RDN_UTF8_STRING value instead of the CERT_RDN_UNICODE_STRING value.
		/// </term>
		/// </item>
		/// <item>
		/// <term>CERT_RDN_FORCE_UTF8_UNICODE_FLAG</term>
		/// <term>
		/// For encoding. When set, strings are encoded with the CERT_RDN_UTF8_STRING value instead of CERT_RDN_PRINTABLE_STRING value
		/// for DirectoryString types. In addition, CERT_RDN_ENABLE_UTF8_UNICODE_FLAG is enabled. Windows Vista, Windows Server 2003 and
		/// Windows XP: This flag is not supported.
		/// </term>
		/// </item>
		/// <item>
		/// <term>CERT_RDN_ENABLE_PUNYCODE_FLAG</term>
		/// <term>
		/// For encoding. If the string contains an email RDN, and the email address is Punycode encoded, then the resultant email
		/// address is encoded as an IA5String. The Punycode encoding of the host name is performed on a label-by-label basis. For
		/// decoding. If the name contains an email RDN, and the local part or host name portion of the email address contains a
		/// Punycode encoded IA5String, the RDN string value is converted to its Unicode equivalent. Windows Server 2008, Windows Vista,
		/// Windows Server 2003 and Windows XP: This flag is not supported.
		/// </term>
		/// </item>
		/// </list>
		/// </summary>
		public CertRDNType dwValueType;

		/// <summary>
		/// <para>
		/// A CERT_RDN_VALUE_BLOB that contains the attribute value. The <c>cbData</c> member of <c>Value</c> is the length, in bytes,
		/// of the <c>pbData</c> member. It is not the number of elements in the <c>pbData</c> string.
		/// </para>
		/// <para>
		/// For example, a <c>DWORD</c> is 32 bits or 4 bytes long. If <c>pbData</c> is a <c>DWORD</c> array, <c>cbData</c> would be
		/// four times the number of <c>DWORD</c> elements in the array. A <c>SHORT</c> is 16 bits or 2 bytes long. If <c>pbData</c> is
		/// an array of <c>SHORT</c> elements, <c>cbData</c> must be two times the length of the array.
		/// </para>
		/// <para>
		/// The <c>pbData</c> member of <c>Value</c> can be a null-terminated array of 8-bit or 16-bit characters or a fixed-length
		/// array of elements. If <c>dwValueType</c> is set to CERT_RDN_ENCODED_BLOB, <c>pbData</c> is encoded.
		/// </para>
		/// </summary>
		public CRYPTOAPI_BLOB Value;
	}

	/// <summary>
	/// Contains parameters used to check for strong signatures on certificates, certificate revocation lists (CRLs), online certificate
	/// status protocol (OCSP) responses, and PKCS #7 messages.
	/// </summary>
	/// <remarks>
	/// <para>The parameters needed to check for a strong signature include the following:</para>
	/// <list type="bullet">
	/// <item>
	/// <term>Name of the public (asymmetric) algorithm</term>
	/// </item>
	/// <item>
	/// <term>Size, in bits, of the public key</term>
	/// </item>
	/// <item>
	/// <term>Name of the signature algorithm</term>
	/// </item>
	/// <item>
	/// <term>Name of the hashing algorithm</term>
	/// </item>
	/// </list>
	/// <para>
	/// The value you specify for the <c>dwInfoChoice</c> member of this structure chooses whether the parameters are transmitted as
	/// serialized strings or are predefined by using an object identifier.
	/// </para>
	/// <para>The <c>CERT_STRONG_SIGN_PARA</c> structure is directly referenced by the following functions:</para>
	/// <list type="bullet">
	/// <item>
	/// <term>CertIsStrongHashToSign</term>
	/// </item>
	/// <item>
	/// <term>CryptMsgControl</term>
	/// </item>
	/// <item>
	/// <term>CryptMsgVerifyCountersignatureEncodedEx</term>
	/// </item>
	/// </list>
	/// <para>
	/// The <c>CERT_STRONG_SIGN_PARA</c> structure is also directly referenced by the CRYPT_VERIFY_MESSAGE_PARA structure and is
	/// therefore available for use by the following functions:
	/// </para>
	/// <list type="bullet">
	/// <item>
	/// <term>CryptDecodeMessage</term>
	/// </item>
	/// <item>
	/// <term>CryptDecryptAndVerifyMessageSignature</term>
	/// </item>
	/// <item>
	/// <term>CryptVerifyDetachedMessageSignature</term>
	/// </item>
	/// <item>
	/// <term>CryptVerifyMessageSignature</term>
	/// </item>
	/// </list>
	/// <para>
	/// Finally, the <c>CERT_STRONG_SIGN_PARA</c> structure is directly referenced by the CERT_CHAIN_PARA structure and is therefore
	/// available for use by the following functions:
	/// </para>
	/// <list type="bullet">
	/// <item>
	/// <term>CertGetCertificateChain</term>
	/// </item>
	/// <item>
	/// <term>CertSelectCertificateChains</term>
	/// </item>
	/// </list>
	/// </remarks>
	// https://docs.microsoft.com/en-us/windows/win32/api/wincrypt/ns-wincrypt-cert_strong_sign_para typedef struct
	// _CERT_STRONG_SIGN_PARA { DWORD cbSize; DWORD dwInfoChoice; union { void *pvInfo; PCERT_STRONG_SIGN_SERIALIZED_INFO
	// pSerializedInfo; LPSTR pszOID; } DUMMYUNIONNAME; } CERT_STRONG_SIGN_PARA, *PCERT_STRONG_SIGN_PARA;
	[PInvokeData("wincrypt.h", MSDNShortId = "12D9F82C-F484-43B0-BD55-F07321058671")]
	[StructLayout(LayoutKind.Explicit, CharSet = CharSet.Ansi)]
	public struct CERT_STRONG_SIGN_PARA
	{
		/// <summary>Size, in bytes, of this structure.</summary>
		[FieldOffset(0)]
		public uint cbSize;

		/// <summary>
		/// <para>Indicates which nested union member points to the strong signature information. This can be one of the following values:</para>
		/// <list type="table">
		/// <listheader>
		/// <term>Value</term>
		/// <term>Description</term>
		/// </listheader>
		/// <item>
		/// <term>CERT_STRONG_SIGN_SERIALIZED_INFO_CHOICE</term>
		/// <term>Specifies the pSerializedInfo member.</term>
		/// </item>
		/// <item>
		/// <term>CERT_STRONG_SIGN_OID_INFO_CHOICE</term>
		/// <term>Specifies the pszOID member.</term>
		/// </item>
		/// </list>
		/// </summary>
		[FieldOffset(4)]
		public CERT_INFO_CHOICE dwInfoChoice;

		/// <summary>Reserved.</summary>
		[FieldOffset(8)]
		public IntPtr pvInfo;

		/// <summary>Pointer to a CERT_STRONG_SIGN_SERIALIZED_INFO structure that specifies the parameters.</summary>
		[FieldOffset(8)]
		public IntPtr pSerializedInfo;

		/// <summary>
		/// <para>
		/// Pointer to a string that contains an object identifier (OID) that represents predefined parameters that can be used for
		/// strong signature checking. This can be one of the following values:
		/// </para>
		/// <list type="table">
		/// <listheader>
		/// <term>Value</term>
		/// <term>Meaning</term>
		/// </listheader>
		/// <item>
		/// <term>szOID_CERT_STRONG_SIGN_OS_1 "1.3.6.1.4.1.311.72.1.1"</term>
		/// <term>
		/// The SHA2 hash algorithm is supported. MD2, MD4, MD5, and SSHA1 are not supported. The signing and public key algorithms can
		/// be RSA or ECDSA. The DSA algorithm is not supported. The key size for the RSA algorithm must equal or be greater than 2047
		/// bits. The key size for the ECDSA algorithm must equal or be greater than 256 bits. Strong signing of CRLs and OCSP responses
		/// are enabled.
		/// </term>
		/// </item>
		/// <item>
		/// <term>szOID_CERT_STRONG_KEY_OS_1 "1.3.6.1.4.1.311.72.2.1"</term>
		/// <term>
		/// SHA1 and SHA2 hashes are supported. MD2, MD4, and MD5 are not. The signing and public key algorithms can be RSA or ECDSA.
		/// The DSA algorithm is not supported. The key size for the RSA algorithm must equal or be greater than 2047 bits. The key size
		/// for the ECDSA algorithm must equal or be greater than 256 bits. Strong signing of CRLs and OCSP responses are enabled.
		/// </term>
		/// </item>
		/// </list>
		/// </summary>
		[FieldOffset(8)]
		public StrPtrAnsi pszOID;
	}

	/// <summary>
	/// The <c>CERT_TRUST_STATUS</c> structure contains trust information about a certificate in a certificate chain, summary trust
	/// information about a simple chain of certificates, or summary information about an array of simple chains.
	/// </summary>
	// https://docs.microsoft.com/en-us/windows/desktop/api/wincrypt/ns-wincrypt-_cert_trust_status typedef struct _CERT_TRUST_STATUS {
	// DWORD dwErrorStatus; DWORD dwInfoStatus; } CERT_TRUST_STATUS, *PCERT_TRUST_STATUS;
	[PInvokeData("wincrypt.h", MSDNShortId = "af1e1db2-7b53-4491-8317-4abf3568fb03")]
	[StructLayout(LayoutKind.Sequential)]
	public struct CERT_TRUST_STATUS
	{
		/// <summary>
		/// <para>The following error status codes are defined for certificates and chains.</para>
		/// <list type="table">
		/// <listheader>
		/// <term>Value</term>
		/// <term>Meaning</term>
		/// </listheader>
		/// <item>
		/// <term>CERT_TRUST_NO_ERROR 0x00000000</term>
		/// <term>No error found for this certificate or chain.</term>
		/// </item>
		/// <item>
		/// <term>CERT_TRUST_IS_NOT_TIME_VALID 0x00000001</term>
		/// <term>This certificate or one of the certificates in the certificate chain is not time valid.</term>
		/// </item>
		/// <item>
		/// <term>CERT_TRUST_IS_REVOKED 0x00000004</term>
		/// <term>Trust for this certificate or one of the certificates in the certificate chain has been revoked.</term>
		/// </item>
		/// <item>
		/// <term>CERT_TRUST_IS_NOT_SIGNATURE_VALID 0x00000008</term>
		/// <term>The certificate or one of the certificates in the certificate chain does not have a valid signature.</term>
		/// </item>
		/// <item>
		/// <term>CERT_TRUST_IS_NOT_VALID_FOR_USAGE 0x00000010</term>
		/// <term>The certificate or certificate chain is not valid for its proposed usage.</term>
		/// </item>
		/// <item>
		/// <term>CERT_TRUST_IS_UNTRUSTED_ROOT 0x00000020</term>
		/// <term>The certificate or certificate chain is based on an untrusted root.</term>
		/// </item>
		/// <item>
		/// <term>CERT_TRUST_REVOCATION_STATUS_UNKNOWN 0x00000040</term>
		/// <term>The revocation status of the certificate or one of the certificates in the certificate chain is unknown.</term>
		/// </item>
		/// <item>
		/// <term>CERT_TRUST_IS_CYCLIC 0x00000080</term>
		/// <term>One of the certificates in the chain was issued by a certification authority that the original certificate had certified.</term>
		/// </item>
		/// <item>
		/// <term>CERT_TRUST_INVALID_EXTENSION 0x00000100</term>
		/// <term>One of the certificates has an extension that is not valid.</term>
		/// </item>
		/// <item>
		/// <term>CERT_TRUST_INVALID_POLICY_CONSTRAINTS 0x00000200</term>
		/// <term>
		/// The certificate or one of the certificates in the certificate chain has a policy constraints extension, and one of the
		/// issued certificates has a disallowed policy mapping extension or does not have a required issuance policies extension.
		/// </term>
		/// </item>
		/// <item>
		/// <term>CERT_TRUST_INVALID_BASIC_CONSTRAINTS 0x00000400</term>
		/// <term>
		/// The certificate or one of the certificates in the certificate chain has a basic constraints extension, and either the
		/// certificate cannot be used to issue other certificates, or the chain path length has been exceeded.
		/// </term>
		/// </item>
		/// <item>
		/// <term>CERT_TRUST_INVALID_NAME_CONSTRAINTS 0x00000800</term>
		/// <term>The certificate or one of the certificates in the certificate chain has a name constraints extension that is not valid.</term>
		/// </item>
		/// <item>
		/// <term>CERT_TRUST_HAS_NOT_SUPPORTED_NAME_CONSTRAINT 0x00001000</term>
		/// <term>
		/// The certificate or one of the certificates in the certificate chain has a name constraints extension that contains
		/// unsupported fields. The minimum and maximum fields are not supported. Thus minimum must always be zero and maximum must
		/// always be absent. Only UPN is supported for an Other Name. The following alternative name choices are not supported:
		/// </term>
		/// </item>
		/// <item>
		/// <term>CERT_TRUST_HAS_NOT_DEFINED_NAME_CONSTRAINT 0x00002000</term>
		/// <term>
		/// The certificate or one of the certificates in the certificate chain has a name constraints extension and a name constraint
		/// is missing for one of the name choices in the end certificate.
		/// </term>
		/// </item>
		/// <item>
		/// <term>CERT_TRUST_HAS_NOT_PERMITTED_NAME_CONSTRAINT 0x00004000</term>
		/// <term>
		/// The certificate or one of the certificates in the certificate chain has a name constraints extension, and there is not a
		/// permitted name constraint for one of the name choices in the end certificate.
		/// </term>
		/// </item>
		/// <item>
		/// <term>CERT_TRUST_HAS_EXCLUDED_NAME_CONSTRAINT 0x00008000</term>
		/// <term>
		/// The certificate or one of the certificates in the certificate chain has a name constraints extension, and one of the name
		/// choices in the end certificate is explicitly excluded.
		/// </term>
		/// </item>
		/// <item>
		/// <term>CERT_TRUST_IS_OFFLINE_REVOCATION 0x01000000</term>
		/// <term>
		/// The revocation status of the certificate or one of the certificates in the certificate chain is either offline or stale.
		/// </term>
		/// </item>
		/// <item>
		/// <term>CERT_TRUST_NO_ISSUANCE_CHAIN_POLICY 0x02000000</term>
		/// <term>
		/// The end certificate does not have any resultant issuance policies, and one of the issuing certification authority
		/// certificates has a policy constraints extension requiring it.
		/// </term>
		/// </item>
		/// <item>
		/// <term>CERT_TRUST_IS_EXPLICIT_DISTRUST 0x04000000</term>
		/// <term>The certificate is explicitly distrusted. Windows Vista and Windows Server 2008: Support for this flag begins.</term>
		/// </item>
		/// <item>
		/// <term>CERT_TRUST_HAS_NOT_SUPPORTED_CRITICAL_EXT 0x08000000</term>
		/// <term>
		/// The certificate does not support a critical extension. Windows Vista and Windows Server 2008: Support for this flag begins.
		/// </term>
		/// </item>
		/// <item>
		/// <term>CERT_TRUST_HAS_WEAK_SIGNATURE 0x00100000</term>
		/// <term>
		/// The certificate has not been strong signed. Typically this indicates that the MD2 or MD5 hashing algorithms were used to
		/// create a hash of the certificate. Windows 8 and Windows Server 2012: Support for this flag begins.
		/// </term>
		/// </item>
		/// </list>
		/// <para>The following codes are defined for chains only.</para>
		/// <list type="table">
		/// <listheader>
		/// <term>Value</term>
		/// <term>Meaning</term>
		/// </listheader>
		/// <item>
		/// <term>CERT_TRUST_IS_PARTIAL_CHAIN 0x00010000</term>
		/// <term>The certificate chain is not complete.</term>
		/// </item>
		/// <item>
		/// <term>CERT_TRUST_CTL_IS_NOT_TIME_VALID 0x00020000</term>
		/// <term>A certificate trust list (CTL) used to create this chain was not time valid.</term>
		/// </item>
		/// <item>
		/// <term>CERT_TRUST_CTL_IS_NOT_SIGNATURE_VALID 0x00040000</term>
		/// <term>A CTL used to create this chain did not have a valid signature.</term>
		/// </item>
		/// <item>
		/// <term>CERT_TRUST_CTL_IS_NOT_VALID_FOR_USAGE 0x00080000</term>
		/// <term>A CTL used to create this chain is not valid for this usage.</term>
		/// </item>
		/// </list>
		/// </summary>
		public uint dwErrorStatus;

		/// <summary>
		/// <para>The following information status codes are defined.</para>
		/// <list type="table">
		/// <listheader>
		/// <term>Value</term>
		/// <term>Meaning</term>
		/// </listheader>
		/// <item>
		/// <term>CERT_TRUST_HAS_EXACT_MATCH_ISSUER 0x00000001</term>
		/// <term>An exact match issuer certificate has been found for this certificate. This status code applies to certificates only.</term>
		/// </item>
		/// <item>
		/// <term>CERT_TRUST_HAS_KEY_MATCH_ISSUER 0x00000002</term>
		/// <term>A key match issuer certificate has been found for this certificate. This status code applies to certificates only.</term>
		/// </item>
		/// <item>
		/// <term>CERT_TRUST_HAS_NAME_MATCH_ISSUER 0x00000004</term>
		/// <term>A name match issuer certificate has been found for this certificate. This status code applies to certificates only.</term>
		/// </item>
		/// <item>
		/// <term>CERT_TRUST_IS_SELF_SIGNED 0x00000008</term>
		/// <term>This certificate is self-signed. This status code applies to certificates only.</term>
		/// </item>
		/// <item>
		/// <term>CERT_TRUST_HAS_PREFERRED_ISSUER 0x00000100</term>
		/// <term>The certificate or chain has a preferred issuer. This status code applies to certificates and chains.</term>
		/// </item>
		/// <item>
		/// <term>CERT_TRUST_HAS_ISSUANCE_CHAIN_POLICY 0x00000400</term>
		/// <term>An issuance chain policy exists. This status code applies to certificates and chains.</term>
		/// </item>
		/// <item>
		/// <term>CERT_TRUST_HAS_VALID_NAME_CONSTRAINTS 0x00000400</term>
		/// <term>A valid name constraints for all namespaces, including UPN. This status code applies to certificates and chains.</term>
		/// </item>
		/// <item>
		/// <term>CERT_TRUST_IS_PEER_TRUSTED 0x00000800</term>
		/// <term>
		/// This certificate is peer trusted. This status code applies to certificates only. Windows Vista and Windows Server 2008:
		/// Support for this flag begins.
		/// </term>
		/// </item>
		/// <item>
		/// <term>CERT_TRUST_HAS_CRL_VALIDITY_EXTENDED 0x00001000</term>
		/// <term>
		/// This certificate's certificate revocation list (CRL) validity has been extended. This status code applies to certificates
		/// only. Windows Vista and Windows Server 2008: Support for this flag begins.
		/// </term>
		/// </item>
		/// <item>
		/// <term>CERT_TRUST_IS_FROM_EXCLUSIVE_TRUST_STORE 0x00002000</term>
		/// <term>
		/// The certificate was found in either a store pointed to by the hExclusiveRoot or hExclusiveTrustedPeople member of the
		/// CERT_CHAIN_ENGINE_CONFIG structure. Windows 7 and Windows Server 2008 R2: Support for this flag begins.
		/// </term>
		/// </item>
		/// <item>
		/// <term>CERT_TRUST_IS_COMPLEX_CHAIN 0x00010000</term>
		/// <term>The certificate chain created is a complex chain. This status code applies to chains only.</term>
		/// </item>
		/// <item>
		/// <term>CERT_TRUST_IS_CA_TRUSTED 0x00004000</term>
		/// <term>
		/// A non-self-signed intermediate CA certificate was found in the store pointed to by the hExclusiveRoot member of the
		/// CERT_CHAIN_ENGINE_CONFIG structure. The CA certificate is treated as a trust anchor for the certificate chain. This flag
		/// will only be set if the CERT_CHAIN_EXCLUSIVE_ENABLE_CA_FLAG value is set in the dwExclusiveFlags member of the
		/// CERT_CHAIN_ENGINE_CONFIG structure. If this flag is set, the CERT_TRUST_IS_SELF_SIGNED and the
		/// CERT_TRUST_IS_PARTIAL_CHAINdwErrorStatus flags will not be set. Windows 8 and Windows Server 2012: Support for this flag begins.
		/// </term>
		/// </item>
		/// </list>
		/// </summary>
		public uint dwInfoStatus;
	}

	/// <summary>
	/// The <c>CRL_CONTEXT</c> structure contains both the encoded and decoded representations of a certificate revocation list (CRL).
	/// CRL contexts returned by any CryptoAPI function must be freed by calling the CertFreeCRLContext function.
	/// </summary>
	// https://docs.microsoft.com/en-us/windows/win32/api/wincrypt/ns-wincrypt-crl_context typedef struct _CRL_CONTEXT { DWORD
	// dwCertEncodingType; BYTE *pbCrlEncoded; DWORD cbCrlEncoded; PCRL_INFO pCrlInfo; HCERTSTORE hCertStore; } CRL_CONTEXT, *PCRL_CONTEXT;
	[PInvokeData("wincrypt.h", MSDNShortId = "cf7cabcd-b469-492a-b855-8870465ea1cc")]
	[StructLayout(LayoutKind.Sequential)]
	public struct CRL_CONTEXT
	{
		/// <summary>
		/// <para>
		/// Type of encoding used. It is always acceptable to specify both the certificate and message encoding types by combining them
		/// with a bitwise- <c>OR</c> operation as shown in the following example:
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
		/// </summary>
		public CertEncodingType dwCertEncodingType;

		/// <summary>A pointer to the encoded CRL information.</summary>
		public IntPtr pbCrlEncoded;

		/// <summary>The size, in bytes, of the encoded CRL information.</summary>
		public uint cbCrlEncoded;

		/// <summary>A pointer to CRL_INFO structure containing the CRL information.</summary>
		public IntPtr pCrlInfo;

		/// <summary>A handle to the certificate store.</summary>
		public HCERTSTORE hCertStore;

		/// <summary>A pointer to CRL_INFO structure containing the CRL information.</summary>
		public unsafe CRL_INFO* pUnsafeCrlInfo => (CRL_INFO*)(void*)pCrlInfo;
	}

	/// <summary>
	/// The <c>CRL_ENTRY</c> structure contains information about a single revoked certificate. It is a member of a CRL_INFO structure.
	/// </summary>
	// https://docs.microsoft.com/en-us/windows/win32/api/wincrypt/ns-wincrypt-crl_entry typedef struct _CRL_ENTRY { CRYPT_INTEGER_BLOB
	// SerialNumber; FILETIME RevocationDate; DWORD cExtension; PCERT_EXTENSION rgExtension; } CRL_ENTRY, *PCRL_ENTRY;
	[PInvokeData("wincrypt.h", MSDNShortId = "30e7952a-a408-404f-9058-8197539387f6")]
	[StructLayout(LayoutKind.Sequential)]
	public struct CRL_ENTRY
	{
		/// <summary>
		/// <para>A BLOB that contains the serial number of a revoked certificate.</para>
		/// <para>Leading 0x00 or 0xFF bytes are removed. For more information, see CertCompareIntegerBlob.</para>
		/// </summary>
		public CRYPTOAPI_BLOB SerialNumber;

		/// <summary>
		/// Date that the certificate was revoked. Time is UTC-time encoded as an eight-byte date/time precise to seconds with a two
		/// digit year (that is, YYMMDDHHMMSS plus 2 bytes). The date is interpreted as a date between the years 1968 and 2067.
		/// </summary>
		public FILETIME RevocationDate;

		/// <summary>Number of elements in the <c>rgExtension</c> member array of extensions.</summary>
		public uint cExtension;

		/// <summary>Array of pointers to CERT_EXTENSION structures, each providing information about the revoked certificate.</summary>
		public IntPtr rgExtension;
	}

	/// <summary>The <c>CRL_INFO</c> structure contains the information of a certificate revocation list (CRL).</summary>
	// https://docs.microsoft.com/en-us/windows/win32/api/wincrypt/ns-wincrypt-crl_info typedef struct _CRL_INFO { DWORD dwVersion;
	// CRYPT_ALGORITHM_IDENTIFIER SignatureAlgorithm; CERT_NAME_BLOB Issuer; FILETIME ThisUpdate; FILETIME NextUpdate; DWORD cCRLEntry;
	// PCRL_ENTRY rgCRLEntry; DWORD cExtension; PCERT_EXTENSION rgExtension; } CRL_INFO, *PCRL_INFO;
	[PInvokeData("wincrypt.h", MSDNShortId = "06a28de3-dd7c-4efe-9baa-20aac69d63f3")]
	[StructLayout(LayoutKind.Sequential)]
	public struct CRL_INFO
	{
		/// <summary>
		/// <para>Version number of the CRL. Currently defined version numbers are shown in the following table.</para>
		/// <list type="table">
		/// <listheader>
		/// <term>Value</term>
		/// <term>Meaning</term>
		/// </listheader>
		/// <item>
		/// <term>CRL_V1</term>
		/// <term>version 1</term>
		/// </item>
		/// <item>
		/// <term>CRL_V2</term>
		/// <term>version 2</term>
		/// </item>
		/// </list>
		/// </summary>
		public uint dwVersion;

		/// <summary>
		/// CRYPT_ALGORITHM_IDENTIFIER structure that contains the object identifier (OID) of a signature algorithm and any associated
		/// additional parameters.
		/// </summary>
		public CRYPT_ALGORITHM_IDENTIFIER SignatureAlgorithm;

		/// <summary>A BLOB structure that contains an encoded certificate issuer's name.</summary>
		public CRYPTOAPI_BLOB Issuer;

		/// <summary>
		/// Indication of the date and time of the CRL's published. If the time is after 1950 and before 2050, it is UTC-time encoded as
		/// an 8-byte date/time precise to seconds with a 2-digit year (that is, YYMMDDHHMMSS plus 2 bytes). Otherwise, it is
		/// generalized-time encoded as an 8-byte year precise to milliseconds with a 4-byte year.
		/// </summary>
		public FILETIME ThisUpdate;

		/// <summary>
		/// Indication of the date and time for the CRL's next available scheduled update. If the time is after 1950 and before 2050, it
		/// is UTC-time encoded as an 8-byte date/time precise to seconds with a 2-digit year (that is, YYMMDDHHMMSS plus 2 bytes).
		/// Otherwise, it is generalized-time encoded as an 8-byte date time precise to milliseconds with a 4-byte year.
		/// </summary>
		public FILETIME NextUpdate;

		/// <summary>Number of elements in the <c>rgCRLEntry</c> array.</summary>
		public uint cCRLEntry;

		/// <summary>Array of pointers to CRL_ENTRY structures. Each of these structures represents a revoked certificate.</summary>
		public IntPtr rgCRLEntry;

		/// <summary>Number of elements in the <c>rgExtension</c> array.</summary>
		public uint cExtension;

		/// <summary>Array of pointers to CERT_EXTENSION structures, each holding information about the CRL.</summary>
		public IntPtr rgExtension;
	}

	/// <summary>
	/// The CRYPT_ALGORITHM_IDENTIFIER structure specifies an algorithm used to encrypt a private key. The structure includes the object
	/// identifier (OID) of the algorithm and any needed parameters for that algorithm. The parameters contained in its CRYPT_OBJID_BLOB
	/// are encoded.
	/// </summary>
	[PInvokeData("wincrypt.h")]
	[StructLayout(LayoutKind.Sequential, CharSet = CharSet.Ansi)]
	public struct CRYPT_ALGORITHM_IDENTIFIER
	{
		/// <summary>An OID of an algorithm.</summary>
		public StrPtrAnsi pszObjId;

		/// <summary>
		/// A BLOB that provides encoded algorithm-specific parameters. In many cases, there are no parameters. This is indicated by
		/// setting the cbData member of the Parameters BLOB to zero.
		/// </summary>
		public CRYPTOAPI_BLOB Parameters;
	}

	/// <summary>The <c>CRYPT_ATTRIBUTE</c> structure specifies an attribute that has one or more values.</summary>
	// https://docs.microsoft.com/en-us/windows/win32/api/wincrypt/ns-wincrypt-crypt_attribute typedef struct _CRYPT_ATTRIBUTE { LPSTR
	// pszObjId; DWORD cValue; PCRYPT_ATTR_BLOB rgValue; } CRYPT_ATTRIBUTE, *PCRYPT_ATTRIBUTE;
	[PInvokeData("wincrypt.h", MSDNShortId = "cdbaf38d-ddbe-4be0-afbc-f8bd76ef4847")]
	[StructLayout(LayoutKind.Sequential)]
	public struct CRYPT_ATTRIBUTE
	{
		/// <summary>An object identifier (OID) that specifies the type of data contained in the <c>rgValue</c> array.</summary>
		public StrPtrAnsi pszObjId;

		/// <summary>A <c>DWORD</c> value that indicates the number of elements in the <c>rgValue</c> array.</summary>
		public uint cValue;

		/// <summary>
		/// Pointer to an array of CRYPT_INTEGER_BLOB structures. The <c>cbData</c> member of the <c>CRYPT_INTEGER_BLOB</c> structure
		/// indicates the length of the <c>pbData</c> member. The <c>pbData</c> member contains the attribute information.
		/// </summary>
		public IntPtr rgValue;
	}

	/// <summary>
	/// The <c>CRYPT_ATTRIBUTE_TYPE_VALUE</c> structure contains a single attribute value. The <c>Value</c> member's CRYPT_OBJID_BLOB is encoded.
	/// </summary>
	// https://docs.microsoft.com/en-us/windows/desktop/api/wincrypt/ns-wincrypt-_crypt_attribute_type_value typedef struct
	// _CRYPT_ATTRIBUTE_TYPE_VALUE { LPSTR pszObjId; CRYPT_OBJID_BLOB Value; } CRYPT_ATTRIBUTE_TYPE_VALUE, *PCRYPT_ATTRIBUTE_TYPE_VALUE;
	[PInvokeData("wincrypt.h", MSDNShortId = "84057581-d0a9-464a-9399-ba806e37516f")]
	[StructLayout(LayoutKind.Sequential)]
	public struct CRYPT_ATTRIBUTE_TYPE_VALUE
	{
		/// <summary>Object identifier (OID) that specifies the attribute type data contained in the <c>Value</c> BLOB.</summary>
		public StrPtrAuto pszObjId;

		/// <summary>
		/// A CRYPT_OBJID_BLOB that contains the encoded attribute. The <c>cbData</c> member of the <c>CRYPT_OBJID_BLOB</c> structure
		/// indicates the length of the <c>pbData</c> member. The <c>pbData</c> member contains the attribute information.
		/// </summary>
		public CRYPTOAPI_BLOB Value;
	}

	/// <summary>The <c>CRYPT_BIT_BLOB</c> structure contains a set of bits represented by an array of bytes.</summary>
	/// <remarks>
	/// Because the smallest chunk of memory that can normally be allocated is a byte, the <c>CRYPT_BIT_BLOB</c> structure allows the
	/// last byte in the array to contain zero to seven unused bits. The number of unused bits in the array is contained in the
	/// <c>cUnusedBits</c> member of this structure. The number of meaningful bits in the <c>pbData</c> member is calculated with the
	/// formula (( <c>cbData</c> × 8) – <c>cUnusedBits</c>). For example, if you need to represent 10 bits, you would allocate an array
	/// of 2 bytes and set <c>cUnusedBits</c> to 6. If you view the array as contiguous bits from left to right, the left 10 bits would
	/// be meaningful, and the right 6 bits would be unused.
	/// </remarks>
	// https://docs.microsoft.com/en-us/windows/win32/api/wincrypt/ns-wincrypt-crypt_bit_blob typedef struct _CRYPT_BIT_BLOB { DWORD
	// cbData; BYTE *pbData; DWORD cUnusedBits; } CRYPT_BIT_BLOB, *PCRYPT_BIT_BLOB;
	[PInvokeData("wincrypt.h", MSDNShortId = "NS:wincrypt._CRYPT_BIT_BLOB")]
	[StructLayout(LayoutKind.Sequential)]
	public struct CRYPT_BIT_BLOB
	{
		/// <summary>The number of bytes in the <c>pbData</c> array.</summary>
		public uint cbData;

		/// <summary>A pointer to an array of bytes that represents the bits.</summary>
		public IntPtr pbData;

		/// <summary>
		/// The number of unused bits in the last byte of the array. The unused bits are always the least significant bits in the last
		/// byte of the array.
		/// </summary>
		public uint cUnusedBits;
	}

	/// <summary>
	/// The <c>CRYPT_KEY_PROV_INFO</c> structure contains information about a key container within a cryptographic service provider (CSP).
	/// </summary>
	// https://docs.microsoft.com/en-us/windows/win32/api/wincrypt/ns-wincrypt-crypt_key_prov_info typedef struct _CRYPT_KEY_PROV_INFO {
	// LPWSTR pwszContainerName; LPWSTR pwszProvName; DWORD dwProvType; DWORD dwFlags; DWORD cProvParam; PCRYPT_KEY_PROV_PARAM
	// rgProvParam; DWORD dwKeySpec; } CRYPT_KEY_PROV_INFO, *PCRYPT_KEY_PROV_INFO;
	[PInvokeData("wincrypt.h", MSDNShortId = "6aea2f47-9d4a-4069-ac6d-f28907df00be")]
	[StructLayout(LayoutKind.Sequential)]
	public struct CRYPT_KEY_PROV_INFO
	{
		/// <summary>
		/// <para>A pointer to a null-terminated Unicode string that contains the name of the key container.</para>
		/// <para>
		/// When the <c>dwProvType</c> member is zero, this string contains the name of a key within a CNG key storage provider. This
		/// string is passed as the pwszKeyName parameter to the NCryptOpenKey function.
		/// </para>
		/// </summary>
		[MarshalAs(UnmanagedType.LPWStr)]
		public string pwszContainerName;

		/// <summary>
		/// <para>A pointer to a null-terminated Unicode string that contains the name of the CSP.</para>
		/// <para>
		/// When the <c>dwProvType</c> member is zero, this string contains the name of a CNG key storage provider. This string is
		/// passed as the pwszProviderName parameter to the NCryptOpenStorageProvider function.
		/// </para>
		/// </summary>
		[MarshalAs(UnmanagedType.LPWStr)]
		public string? pwszProvName;

		/// <summary>
		/// <para>Specifies the CSP type. This can be zero or one of the Cryptographic Provider Types.</para>
		/// <para>If this member is zero, the key container is one of the CNG key storage providers.</para>
		/// </summary>
		public uint dwProvType;

		/// <summary>
		/// <para>A set of flags that indicate additional information about the provider. This can be zero or one of the following values.</para>
		/// <list type="table">
		/// <listheader>
		/// <term>Value</term>
		/// <term>Meaning</term>
		/// </listheader>
		/// <item>
		/// <term>CERT_SET_KEY_PROV_HANDLE_PROP_ID / CERT_SET_KEY_CONTEXT_PROP_ID</term>
		/// <term>Enables the handle to the key provider to be kept open for subsequent calls to the cryptographic functions.</term>
		/// </item>
		/// <item>
		/// <term>CRYPT_MACHINE_KEYSET / NCRYPT_MACHINE_KEY_FLAG</term>
		/// <term>The key container contains machine keys. If this flag is not present, the key container contains user keys.</term>
		/// </item>
		/// <item>
		/// <term>CRYPT_SILENT / NCRYPT_SILENT_FLAG</term>
		/// <term>The key container will attempt to open any keys silently without any user interface prompts.</term>
		/// </item>
		/// </list>
		/// <para>
		/// The cryptographic functions CryptDecryptMessage, CryptSignMessage, CryptDecryptAndVerifyMessageSignature, and
		/// CryptSignAndEncryptMessage internally perform CryptAcquireContext operations using the <c>CRYPT_KEY_PROV_INFO</c> from a
		/// certificate. When the <c>CERT_SET_KEY_CONTEXT_PROP_ID</c> or <c>CERT_SET_KEY_PROV_HANDLE_PROP_ID</c> flag is set, these
		/// cryptographic functions then can call CertSetCertificateContextProperty with <c>CERT_KEY_CONTEXT_PROP_ID</c>. This call
		/// enables the handle to the key provider to be kept open for subsequent calls to the cryptographic functions mentioned that
		/// use that same certificate, which eliminates the need to perform additional calls to <c>CryptAcquireContext</c>, improving
		/// efficiency. Also, because some providers can require that a password be entered for calls to <c>CryptAcquireContext</c>, it
		/// is desirable for applications to minimize the number of <c>CryptAcquireContext</c> calls made. Handles to key providers that
		/// were kept open are automatically released when the store is closed.
		/// </para>
		/// <para>
		/// For example, consider an email application where five encrypted messages have been received, all encrypted with the public
		/// key from the same certificate. If the handle to the key provider is kept open after the first message is processed, calls to
		/// CryptAcquireContext are not required for the four remaining messages.
		/// </para>
		/// </summary>
		public uint dwFlags;

		/// <summary>
		/// <para>The number of elements in the <c>rgProvParam</c> array.</para>
		/// <para>When the <c>dwProvType</c> member is zero, this member is not used and must be zero.</para>
		/// </summary>
		public uint cProvParam;

		/// <summary>
		/// <para>
		/// An array of CRYPT_KEY_PROV_PARAM structures that contain the parameters for the key container. The <c>cProvParam</c> member
		/// contains the number of elements in this array.
		/// </para>
		/// <para>When the <c>dwProvType</c> member is zero, this member is not used and must be <c>NULL</c>.</para>
		/// </summary>
		public IntPtr rgProvParam;

		/// <summary>
		/// <para>The specification of the private key to retrieve.</para>
		/// <para>The following values are defined for the default provider.</para>
		/// <para>
		/// When the <c>dwProvType</c> member is zero, this value is passed as the dwLegacyKeySpec parameter to the NCryptOpenKey function.
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
	}

	/// <summary>
	/// The <c>CRYPT_TIMESTAMP_ACCURACY</c> structure is used by the CRYPT_TIMESTAMP_INFO structure to represent the accuracy of the
	/// time deviation around the UTC time at which the time stamp token was created by the Time Stamp Authority (TSA).
	/// </summary>
	// https://docs.microsoft.com/en-us/windows/win32/api/wincrypt/ns-wincrypt-crypt_timestamp_accuracy typedef struct
	// _CRYPT_TIMESTAMP_ACCURACY { DWORD dwSeconds; DWORD dwMillis; DWORD dwMicros; } CRYPT_TIMESTAMP_ACCURACY, *PCRYPT_TIMESTAMP_ACCURACY;
	[PInvokeData("wincrypt.h", MSDNShortId = "9115db8a-7cc1-4360-b89b-6c33ddb67fe9")]
	[StructLayout(LayoutKind.Sequential)]
	public struct CRYPT_TIMESTAMP_ACCURACY
	{
		/// <summary>
		/// Optional. Specifies, in seconds, the accuracy of the upper limit of the time at which the time stamp token was created by
		/// the TSA.
		/// </summary>
		public uint dwSeconds;

		/// <summary>
		/// Optional. Specifies, in milliseconds, the accuracy of the upper limit of the time at which the time stamp token was created
		/// by the TSA.
		/// </summary>
		public uint dwMillis;

		/// <summary>
		/// Optional. Specifies, in microseconds, the accuracy of the upper limit of the time at which the time-stamp token was created
		/// by the TSA.
		/// </summary>
		public uint dwMicros;
	}

	/// <summary>
	/// The <c>CRYPT_TIMESTAMP_CONTEXT</c> structure contains both the encoded and decoded representations of a time stamp token.
	/// </summary>
	// https://docs.microsoft.com/en-us/windows/win32/api/wincrypt/ns-wincrypt-crypt_timestamp_context typedef struct
	// _CRYPT_TIMESTAMP_CONTEXT { DWORD cbEncoded; BYTE *pbEncoded; PCRYPT_TIMESTAMP_INFO pTimeStamp; } CRYPT_TIMESTAMP_CONTEXT, *PCRYPT_TIMESTAMP_CONTEXT;
	[PInvokeData("wincrypt.h", MSDNShortId = "2831b2a9-0f84-4e41-a666-5903fc882965")]
	[StructLayout(LayoutKind.Sequential)]
	public struct CRYPT_TIMESTAMP_CONTEXT
	{
		/// <summary>The size, in bytes, of the buffer pointed to by the <c>pbEncoded</c> member.</summary>
		public uint cbEncoded;

		/// <summary>
		/// A pointer to a buffer that contains an Abstract Syntax Notation One (ASN.1) encoded content information sequence. This value
		/// should be stored for future time stamp validations on the signature. Applications can use the CertOpenStore function with
		/// the <c>CERT_STORE_PROV_PKCS7</c> flag to find additional certificates or certificate revocation lists (CRLs) related to the
		/// TSA time stamp signature.
		/// </summary>
		public IntPtr pbEncoded;

		/// <summary>
		/// A pointer to a CRYPT_TIMESTAMP_INFO structure that contains a signed data content type in Cryptographic Message Syntax (CMS) format.
		/// </summary>
		public IntPtr pTimeStamp;
	}

	/// <summary>
	/// The <c>CRYPT_TIMESTAMP_INFO</c> structure contains a signed data content type in Cryptographic Message Syntax (CMS) format.
	/// </summary>
	// https://docs.microsoft.com/en-us/windows/win32/api/wincrypt/ns-wincrypt-crypt_timestamp_info typedef struct _CRYPT_TIMESTAMP_INFO
	// { DWORD dwVersion; LPSTR pszTSAPolicyId; CRYPT_ALGORITHM_IDENTIFIER HashAlgorithm; CRYPT_DER_BLOB HashedMessage;
	// CRYPT_INTEGER_BLOB SerialNumber; FILETIME ftTime; PCRYPT_TIMESTAMP_ACCURACY pvAccuracy; BOOL fOrdering; CRYPT_DER_BLOB Nonce;
	// CRYPT_DER_BLOB Tsa; DWORD cExtension; PCERT_EXTENSION rgExtension; } CRYPT_TIMESTAMP_INFO, *PCRYPT_TIMESTAMP_INFO;
	[PInvokeData("wincrypt.h", MSDNShortId = "05ca0877-5e9d-4b21-9fca-a1eef2cb4626")]
	[StructLayout(LayoutKind.Sequential)]
	public struct CRYPT_TIMESTAMP_INFO
	{
		/// <summary>
		/// <para>A <c>DWORD</c> value that specifies the version of the time stamp request.</para>
		/// <list type="table">
		/// <listheader>
		/// <term>Value</term>
		/// <term>Meaning</term>
		/// </listheader>
		/// <item>
		/// <term>TIMESTAMP_VERSION 1</term>
		/// <term>Specifies that this is a version 1 time stamp request.</term>
		/// </item>
		/// </list>
		/// </summary>
		public uint dwVersion;

		/// <summary>
		/// Optional. A pointer to a null-terminated string that specifies the Time Stamping Authority (TSA) policy under which the time
		/// stamp token was provided. This value must correspond with the value passed in the CRYPT_TIMESTAMP_REQUEST structure.
		/// </summary>
		public StrPtrAnsi pszTSAPolicyId;

		/// <summary>
		/// A CRYPT_ALGORITHM_IDENTIFIER structure that contains information about the algorithm used to calculate the hash. This value
		/// must correspond with the value passed in the CRYPT_TIMESTAMP_REQUEST structure.
		/// </summary>
		public CRYPT_ALGORITHM_IDENTIFIER HashAlgorithm;

		/// <summary>A CRYPT_DER_BLOB structure that specifies the hash values to be time stamped.</summary>
		public CRYPTOAPI_BLOB HashedMessage;

		/// <summary>A CRYPT_INTEGER_BLOB structure that contains the serial number assigned by the TSA to each time stamp token.</summary>
		public CRYPTOAPI_BLOB SerialNumber;

		/// <summary>A FILETIME value that specifies the time at which the time stamp token was produced by the TSA.</summary>
		public FILETIME ftTime;

		/// <summary>
		/// Optional. A pointer to a CRYPT_TIMESTAMP_ACCURACY structure that contains the time deviation around the UTC time at which
		/// the time stamp token was created by the TSA.
		/// </summary>
		public IntPtr pvAccuracy;

		/// <summary>This member is reserved.</summary>
		[MarshalAs(UnmanagedType.Bool)] public bool fOrdering;

		/// <summary>
		/// Optional. A CRYPT_DER_BLOB structure that contains the nonce value used by the client to verify the timeliness of the
		/// response when no local clock is available. This value must correspond with the value passed in the CRYPT_TIMESTAMP_REQUEST structure.
		/// </summary>
		public CRYPTOAPI_BLOB Nonce;

		/// <summary>Optional. A CRYPT_DER_BLOB structure that contains the subject name of the TSA certificate.</summary>
		public CRYPTOAPI_BLOB Tsa;

		/// <summary>The number of elements in the array pointed to by the <c>rgExtension</c> member.</summary>
		public uint cExtension;

		/// <summary>A pointer to an array of CERT_EXTENSION structures that contain extension information returned from the request.</summary>
		public IntPtr rgExtension;
	}

	/// <summary>The <c>CRYPT_TIMESTAMP_PARA</c> structure defines additional parameters for the time stamp request.</summary>
	// https://docs.microsoft.com/en-us/windows/win32/api/wincrypt/ns-wincrypt-crypt_timestamp_para typedef struct _CRYPT_TIMESTAMP_PARA
	// { LPCSTR pszTSAPolicyId; BOOL fRequestCerts; CRYPT_INTEGER_BLOB Nonce; DWORD cExtension; PCERT_EXTENSION rgExtension; }
	// CRYPT_TIMESTAMP_PARA, *PCRYPT_TIMESTAMP_PARA;
	[PInvokeData("wincrypt.h", MSDNShortId = "26a6e9d3-b35e-47ae-9cea-a37ca6297c28")]
	[StructLayout(LayoutKind.Sequential)]
	public struct CRYPT_TIMESTAMP_PARA
	{
		/// <summary>
		/// Optional. A pointer to a null-terminated character string that contains the Time Stamping Authority (TSA) policy under which
		/// the time stamp token should be provided.
		/// </summary>
		public StrPtrAnsi pszTSAPolicyId;

		/// <summary>
		/// A Boolean value that specifies whether the TSA must include the certificates used to sign the time stamp token in the
		/// response .
		/// </summary>
		[MarshalAs(UnmanagedType.Bool)] public bool fRequestCerts;

		/// <summary>
		/// Optional. A CRYPT_INTEGER_BLOB structure that contains the nonce value used by the client to verify the timeliness of the
		/// response when no local clock is available.
		/// </summary>
		public CRYPTOAPI_BLOB Nonce;

		/// <summary>The number of elements in the array pointed to by the <c>rgExtension</c> member.</summary>
		public uint cExtension;

		/// <summary>
		/// A pointer to an array of CERT_EXTENSION structures that contain extension information that is passed in the request.
		/// </summary>
		public IntPtr rgExtension;
	}

	/// <summary>
	/// The BLOB structure contains an arbitrary array of bytes. The structure definition includes aliases appropriate to the various
	/// functions that use it.
	/// </summary>
	[PInvokeData("wincrypt.h")]
	[StructLayout(LayoutKind.Sequential)]
	public struct CRYPTOAPI_BLOB
	{
		/// <summary>Initializes a new instance of the <see cref="CRYPTOAPI_BLOB"/> struct with default values.</summary>
		/// <param name="data">A pointer to the data buffer.</param>
		/// <param name="size">The count, in bytes, of <paramref name="data"/>.</param>
		public CRYPTOAPI_BLOB(IntPtr data, SizeT size) { pbData = data; cbData = size; }

		/// <summary>
		/// Initializes a new instance of the <see cref="CRYPTOAPI_BLOB"/> struct from a <see cref="SafeAllocatedMemoryHandle"/> instance.
		/// </summary>
		/// <param name="mem">The allocated memory instance.</param>
		public CRYPTOAPI_BLOB(SafeAllocatedMemoryHandle? mem) { pbData = mem?.DangerousGetHandle() ?? default; cbData = mem?.Size ?? 0; }

		/// <summary>A DWORD variable that contains the count, in bytes, of data.</summary>
		public uint cbData;

		/// <summary>A pointer to the data buffer.</summary>
		public IntPtr pbData;

		/// <summary>Gets the bytes associated with this blob.</summary>
		public byte[]? GetBytes() => pbData.ToByteArray((int)cbData);
	}

	/// <summary>
	/// <para>
	/// The <c>CTL_CONTEXT</c> structure contains both the encoded and decoded representations of a CTL. It also contains an opened
	/// <c>HCRYPTMSG</c> handle to the decoded, cryptographically signed message containing the CTL_INFO as its inner content.
	/// </para>
	/// <para>CryptoAPI low-level message functions can be used to extract additional signer information.</para>
	/// <para>A <c>CTL_CONTEXT</c> returned by any CryptoAPI function must be freed by calling the CertFreeCTLContext function.</para>
	/// </summary>
	// https://docs.microsoft.com/en-us/windows/win32/api/wincrypt/ns-wincrypt-ctl_context typedef struct _CTL_CONTEXT { DWORD
	// dwMsgAndCertEncodingType; BYTE *pbCtlEncoded; DWORD cbCtlEncoded; PCTL_INFO pCtlInfo; HCERTSTORE hCertStore; HCRYPTMSG hCryptMsg;
	// BYTE *pbCtlContent; DWORD cbCtlContent; } CTL_CONTEXT, *PCTL_CONTEXT;
	[PInvokeData("wincrypt.h", MSDNShortId = "780edddf-1b44-4292-9156-4dfd5100adb8")]
	[StructLayout(LayoutKind.Sequential)]
	public struct CTL_CONTEXT
	{
		/// <summary>
		/// <para>
		/// Type of encoding used. It is always acceptable to specify both the certificate and message encoding types by combining them
		/// with a bitwise- <c>OR</c> operation as shown in the following example:
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
		/// </summary>
		public CertEncodingType dwMsgAndCertEncodingType;

		/// <summary>A pointer to the encoded CTL.</summary>
		public IntPtr pbCtlEncoded;

		/// <summary>The size, in bytes, of the encoded CTL.</summary>
		public uint cbCtlEncoded;

		/// <summary>A pointer to CTL_INFO structure contain the CTL information.</summary>
		public IntPtr pCtlInfo;

		/// <summary>A handle to the certificate store.</summary>
		public HCERTSTORE hCertStore;

		/// <summary>
		/// Open <c>HCRYPTMSG</c> handle to a decoded, cryptographic-signed message containing the CTL_INFO as its inner content.
		/// </summary>
		public HCRYPTMSG hCryptMsg;

		/// <summary>The encoded inner content of the signed message.</summary>
		public IntPtr pbCtlContent;

		/// <summary>Count, in bytes, of <c>pbCtlContent</c>.</summary>
		public uint cbCtlContent;

		/// <summary>A pointer to CTL_INFO structure contain the CTL information.</summary>
		public unsafe CTL_INFO* pUnsafeCtlInfo => (CTL_INFO*)(void*)pCtlInfo;
	}

	/// <summary>The <c>CTL_ENTRY</c> structure is an element of a certificate trust list (CTL).</summary>
	// https://docs.microsoft.com/en-us/windows/win32/api/wincrypt/ns-wincrypt-ctl_entry typedef struct _CTL_ENTRY { CRYPT_DATA_BLOB
	// SubjectIdentifier; DWORD cAttribute; PCRYPT_ATTRIBUTE rgAttribute; } CTL_ENTRY, *PCTL_ENTRY;
	[PInvokeData("wincrypt.h", MSDNShortId = "ebc63847-b641-4205-b15c-7b32c1426c21")]
	[StructLayout(LayoutKind.Sequential)]
	public struct CTL_ENTRY
	{
		/// <summary>BLOB containing a unique identifier of a subject. It can be a hash or any unique byte sequence.</summary>
		public CRYPTOAPI_BLOB SubjectIdentifier;

		/// <summary>Count of elements in the <c>rgAttribute</c> member array.</summary>
		public uint cAttribute;

		/// <summary>Array of CRYPT_ATTRIBUTE structures, each holding information about the subject.</summary>
		public IntPtr rgAttribute;
	}

	/// <summary>The <c>CTL_INFO</c> structure contains the information stored in a Certificate Trust List (CTL).</summary>
	// https://docs.microsoft.com/en-us/windows/win32/api/wincrypt/ns-wincrypt-ctl_info typedef struct _CTL_INFO { DWORD dwVersion;
	// CTL_USAGE SubjectUsage; CRYPT_DATA_BLOB ListIdentifier; CRYPT_INTEGER_BLOB SequenceNumber; FILETIME ThisUpdate; FILETIME
	// NextUpdate; CRYPT_ALGORITHM_IDENTIFIER SubjectAlgorithm; DWORD cCTLEntry; PCTL_ENTRY rgCTLEntry; DWORD cExtension;
	// PCERT_EXTENSION rgExtension; } CTL_INFO, *PCTL_INFO;
	[PInvokeData("wincrypt.h", MSDNShortId = "83b015b5-a650-4a81-a9f0-c3e8a9805c81")]
	[StructLayout(LayoutKind.Sequential)]
	public struct CTL_INFO
	{
		/// <summary>
		/// <para>The CTL's version number. Currently defined version numbers are shown in the following table.</para>
		/// <list type="table">
		/// <listheader>
		/// <term>Value</term>
		/// <term>Meaning</term>
		/// </listheader>
		/// <item>
		/// <term>CTL_V1</term>
		/// <term>Version 1</term>
		/// </item>
		/// </list>
		/// </summary>
		public uint dwVersion;

		/// <summary>
		/// CTL_USAGE structure identifying the intended usage of the list as a sequence of object identifiers. This is the same as in
		/// the Enhanced Key Usage extension.
		/// </summary>
		public CTL_USAGE SubjectUsage;

		/// <summary>
		/// A CRYPT_DATA_BLOB structure that includes a byte string that uniquely identifies the list. This member is used to augment
		/// the <c>SubjectUsage</c> and further specifies the list when desired.
		/// </summary>
		public CRYPTOAPI_BLOB ListIdentifier;

		/// <summary>A BLOB that contains a monotonically increasing number for each update of the CTL.</summary>
		public CRYPTOAPI_BLOB SequenceNumber;

		/// <summary>
		/// Indication of the date and time of the certificate revocation lists (CRLs) published. If the time is after 1950 and before
		/// 2050, it is UTC-time encoded as an 8-byte date/time precise to seconds with a 2-digit year (that is, YYMMDDHHMMSS plus 2
		/// bytes). Otherwise, it is generalized-time encoded as an 8-byte year precise to milliseconds with a 4-byte year.
		/// </summary>
		public FILETIME ThisUpdate;

		/// <summary>
		/// Indication of the date and time for the CRL's next available scheduled update. If the time is after 1950 and before 2050, it
		/// is UTC-time encoded as an 8-byte date/time precise to seconds with a 2-digit year (that is, YYMMDDHHMMSS plus 2 bytes).
		/// Otherwise, it is generalized-time encoded as an 8-byte date time precise to milliseconds with a 4-byte year.
		/// </summary>
		public FILETIME NextUpdate;

		/// <summary>
		/// CRYPT_ALGORITHM_IDENTIFIER structure that contains the algorithm type of the <c>SubjectIdentifier</c> in CTL_ENTRY members
		/// of the <c>rgCTLEntry</c> member array. The structure also includes additional parameters used by the algorithm.
		/// </summary>
		public CRYPT_ALGORITHM_IDENTIFIER SubjectAlgorithm;

		/// <summary>Number of elements in the <c>rgCTLEntry</c> member array.</summary>
		public uint cCTLEntry;

		/// <summary>Array of CTL_ENTRY structures.</summary>
		public IntPtr rgCTLEntry;

		/// <summary>Number of elements in the <c>rgExtension</c> array.</summary>
		public uint cExtension;

		/// <summary>Array of CERT_EXTENSION structures.</summary>
		public IntPtr rgExtension;
	}

	/// <summary>
	/// The <c>CTL_USAGE</c> structure contains an array of object identifiers (OIDs) for Certificate Trust List (CTL) extensions.
	/// <c>CTL_USAGE</c> structures are used in functions that search for CTLs for specific uses.
	/// </summary>
	// https://docs.microsoft.com/en-us/windows/win32/api/wincrypt/ns-wincrypt-ctl_usage typedef struct _CTL_USAGE { DWORD
	// cUsageIdentifier; LPSTR *rgpszUsageIdentifier; } CTL_USAGE, *PCTL_USAGE, CERT_ENHKEY_USAGE, *PCERT_ENHKEY_USAGE;
	[PInvokeData("wincrypt.h", MSDNShortId = "70ee138a-df94-4fc4-9de5-0d8b7704b890")]
	[StructLayout(LayoutKind.Sequential)]
	public struct CTL_USAGE
	{
		/// <summary>Number of elements in the <c>rgpszUsageIdentifier</c> member array.</summary>
		public uint cUsageIdentifier;

		/// <summary>Array of object identifiers (OIDs) of CTL extensions.</summary>
		public IntPtr rgpszUsageIdentifier;
	}

	/// <summary>Provides a handle to a cryptographic default context.</summary>
	[StructLayout(LayoutKind.Sequential)]
	public readonly struct HCRYPTDEFAULTCONTEXT : IHandle
	{
		private readonly IntPtr handle;

		/// <summary>Initializes a new instance of the <see cref="HCRYPTDEFAULTCONTEXT"/> struct.</summary>
		/// <param name="preexistingHandle">An <see cref="IntPtr"/> object that represents the pre-existing handle to use.</param>
		public HCRYPTDEFAULTCONTEXT(IntPtr preexistingHandle) => handle = preexistingHandle;

		/// <summary>Returns an invalid handle by instantiating a <see cref="HCRYPTDEFAULTCONTEXT"/> object with <see cref="IntPtr.Zero"/>.</summary>
		public static HCRYPTDEFAULTCONTEXT NULL => new(IntPtr.Zero);

		/// <summary>Gets a value indicating whether this instance is a null handle.</summary>
		public bool IsNull => handle == IntPtr.Zero;

		/// <summary>Performs an explicit conversion from <see cref="HCRYPTDEFAULTCONTEXT"/> to <see cref="IntPtr"/>.</summary>
		/// <param name="h">The handle.</param>
		/// <returns>The result of the conversion.</returns>
		public static explicit operator IntPtr(HCRYPTDEFAULTCONTEXT h) => h.handle;

		/// <summary>Performs an implicit conversion from <see cref="IntPtr"/> to <see cref="HCRYPTDEFAULTCONTEXT"/>.</summary>
		/// <param name="h">The pointer to a handle.</param>
		/// <returns>The result of the conversion.</returns>
		public static implicit operator HCRYPTDEFAULTCONTEXT(IntPtr h) => new(h);

		/// <summary>Implements the operator !=.</summary>
		/// <param name="h1">The first handle.</param>
		/// <param name="h2">The second handle.</param>
		/// <returns>The result of the operator.</returns>
		public static bool operator !=(HCRYPTDEFAULTCONTEXT h1, HCRYPTDEFAULTCONTEXT h2) => !(h1 == h2);

		/// <summary>Implements the operator ==.</summary>
		/// <param name="h1">The first handle.</param>
		/// <param name="h2">The second handle.</param>
		/// <returns>The result of the operator.</returns>
		public static bool operator ==(HCRYPTDEFAULTCONTEXT h1, HCRYPTDEFAULTCONTEXT h2) => h1.Equals(h2);

		/// <inheritdoc/>
		public override bool Equals(object? obj) => obj is HCRYPTDEFAULTCONTEXT h && handle == h.handle;

		/// <inheritdoc/>
		public override int GetHashCode() => handle.GetHashCode();

		/// <inheritdoc/>
		public IntPtr DangerousGetHandle() => handle;
	}

	/// <summary>Provides a handle to a CryptoApi hash.</summary>
	[StructLayout(LayoutKind.Sequential)]
	public readonly struct HCRYPTHASH : IHandle
	{
		private readonly IntPtr handle;

		/// <summary>Initializes a new instance of the <see cref="HCRYPTHASH"/> struct.</summary>
		/// <param name="preexistingHandle">An <see cref="IntPtr"/> object that represents the pre-existing handle to use.</param>
		public HCRYPTHASH(IntPtr preexistingHandle) => handle = preexistingHandle;

		/// <summary>Returns an invalid handle by instantiating a <see cref="HCRYPTHASH"/> object with <see cref="IntPtr.Zero"/>.</summary>
		public static HCRYPTHASH NULL => new(IntPtr.Zero);

		/// <summary>Gets a value indicating whether this instance is a null handle.</summary>
		public bool IsNull => handle == IntPtr.Zero;

		/// <summary>Performs an explicit conversion from <see cref="HCRYPTHASH"/> to <see cref="IntPtr"/>.</summary>
		/// <param name="h">The handle.</param>
		/// <returns>The result of the conversion.</returns>
		public static explicit operator IntPtr(HCRYPTHASH h) => h.handle;

		/// <summary>Performs an implicit conversion from <see cref="IntPtr"/> to <see cref="HCRYPTHASH"/>.</summary>
		/// <param name="h">The pointer to a handle.</param>
		/// <returns>The result of the conversion.</returns>
		public static implicit operator HCRYPTHASH(IntPtr h) => new(h);

		/// <summary>Implements the operator !=.</summary>
		/// <param name="h1">The first handle.</param>
		/// <param name="h2">The second handle.</param>
		/// <returns>The result of the operator.</returns>
		public static bool operator !=(HCRYPTHASH h1, HCRYPTHASH h2) => !(h1 == h2);

		/// <summary>Implements the operator ==.</summary>
		/// <param name="h1">The first handle.</param>
		/// <param name="h2">The second handle.</param>
		/// <returns>The result of the operator.</returns>
		public static bool operator ==(HCRYPTHASH h1, HCRYPTHASH h2) => h1.Equals(h2);

		/// <inheritdoc/>
		public override bool Equals(object? obj) => obj is HCRYPTHASH h && handle == h.handle;

		/// <inheritdoc/>
		public override int GetHashCode() => handle.GetHashCode();

		/// <inheritdoc/>
		public IntPtr DangerousGetHandle() => handle;
	}

	/// <summary>Provides a handle to a CryptoApi key.</summary>
	[StructLayout(LayoutKind.Sequential)]
	public readonly struct HCRYPTKEY : IHandle
	{
		private readonly IntPtr handle;

		/// <summary>Initializes a new instance of the <see cref="HCRYPTKEY"/> struct.</summary>
		/// <param name="preexistingHandle">An <see cref="IntPtr"/> object that represents the pre-existing handle to use.</param>
		public HCRYPTKEY(IntPtr preexistingHandle) => handle = preexistingHandle;

		/// <summary>Returns an invalid handle by instantiating a <see cref="HCRYPTKEY"/> object with <see cref="IntPtr.Zero"/>.</summary>
		public static HCRYPTKEY NULL => new(IntPtr.Zero);

		/// <summary>Gets a value indicating whether this instance is a null handle.</summary>
		public bool IsNull => handle == IntPtr.Zero;

		/// <summary>Performs an explicit conversion from <see cref="HCRYPTKEY"/> to <see cref="IntPtr"/>.</summary>
		/// <param name="h">The handle.</param>
		/// <returns>The result of the conversion.</returns>
		public static explicit operator IntPtr(HCRYPTKEY h) => h.handle;

		/// <summary>Performs an implicit conversion from <see cref="IntPtr"/> to <see cref="HCRYPTKEY"/>.</summary>
		/// <param name="h">The pointer to a handle.</param>
		/// <returns>The result of the conversion.</returns>
		public static implicit operator HCRYPTKEY(IntPtr h) => new(h);

		/// <summary>Implements the operator !=.</summary>
		/// <param name="h1">The first handle.</param>
		/// <param name="h2">The second handle.</param>
		/// <returns>The result of the operator.</returns>
		public static bool operator !=(HCRYPTKEY h1, HCRYPTKEY h2) => !(h1 == h2);

		/// <summary>Implements the operator ==.</summary>
		/// <param name="h1">The first handle.</param>
		/// <param name="h2">The second handle.</param>
		/// <returns>The result of the operator.</returns>
		public static bool operator ==(HCRYPTKEY h1, HCRYPTKEY h2) => h1.Equals(h2);

		/// <inheritdoc/>
		public override bool Equals(object? obj) => obj is HCRYPTKEY h && handle == h.handle;

		/// <inheritdoc/>
		public override int GetHashCode() => handle.GetHashCode();

		/// <inheritdoc/>
		public IntPtr DangerousGetHandle() => handle;
	}

	/// <summary>Provides a handle to a CryptoAPI provider.</summary>
	[StructLayout(LayoutKind.Sequential)]
	public readonly struct HCRYPTPROV : IHandle
	{
		private readonly IntPtr handle;

		/// <summary>Initializes a new instance of the <see cref="HCRYPTPROV"/> struct.</summary>
		/// <param name="preexistingHandle">An <see cref="IntPtr"/> object that represents the pre-existing handle to use.</param>
		public HCRYPTPROV(IntPtr preexistingHandle) => handle = preexistingHandle;

		/// <summary>Returns an invalid handle by instantiating a <see cref="HCRYPTPROV"/> object with <see cref="IntPtr.Zero"/>.</summary>
		public static HCRYPTPROV NULL => new(IntPtr.Zero);

		/// <summary>Gets a value indicating whether this instance is a null handle.</summary>
		public bool IsNull => handle == IntPtr.Zero;

		/// <summary>Performs an explicit conversion from <see cref="HCRYPTPROV"/> to <see cref="IntPtr"/>.</summary>
		/// <param name="h">The handle.</param>
		/// <returns>The result of the conversion.</returns>
		public static explicit operator IntPtr(HCRYPTPROV h) => h.handle;

		/// <summary>Performs an implicit conversion from <see cref="IntPtr"/> to <see cref="HCRYPTPROV"/>.</summary>
		/// <param name="h">The pointer to a handle.</param>
		/// <returns>The result of the conversion.</returns>
		public static implicit operator HCRYPTPROV(IntPtr h) => new(h);

		/// <summary>Implements the operator !=.</summary>
		/// <param name="h1">The first handle.</param>
		/// <param name="h2">The second handle.</param>
		/// <returns>The result of the operator.</returns>
		public static bool operator !=(HCRYPTPROV h1, HCRYPTPROV h2) => !(h1 == h2);

		/// <summary>Implements the operator ==.</summary>
		/// <param name="h1">The first handle.</param>
		/// <param name="h2">The second handle.</param>
		/// <returns>The result of the operator.</returns>
		public static bool operator ==(HCRYPTPROV h1, HCRYPTPROV h2) => h1.Equals(h2);

		/// <inheritdoc/>
		public override bool Equals(object? obj) => obj is HCRYPTPROV h && handle == h.handle;

		/// <inheritdoc/>
		public override int GetHashCode() => handle.GetHashCode();

		/// <inheritdoc/>
		public IntPtr DangerousGetHandle() => handle;
	}

	/// <summary>Provides a handle to a CERT_CONTEXT.</summary>
	[StructLayout(LayoutKind.Sequential)]
	public readonly struct PCCERT_CONTEXT : IHandle
	{
		private readonly IntPtr handle;

		/// <summary>Initializes a new instance of the <see cref="PCCERT_CONTEXT"/> struct.</summary>
		/// <param name="preexistingHandle">An <see cref="IntPtr"/> object that represents the pre-existing handle to use.</param>
		public PCCERT_CONTEXT(IntPtr preexistingHandle) => handle = preexistingHandle;

		/// <summary>Returns an invalid handle by instantiating a <see cref="PCCERT_CONTEXT"/> object with <see cref="IntPtr.Zero"/>.</summary>
		public static PCCERT_CONTEXT NULL => new(IntPtr.Zero);

		/// <summary>Gets a value indicating whether this instance is a null handle.</summary>
		public bool IsNull => handle == IntPtr.Zero;

		/// <summary>Performs an explicit conversion from <see cref="PCCERT_CONTEXT"/> to <see cref="IntPtr"/>.</summary>
		/// <param name="h">The handle.</param>
		/// <returns>The result of the conversion.</returns>
		public static explicit operator IntPtr(PCCERT_CONTEXT h) => h.handle;

		/// <summary>Performs an implicit conversion from <see cref="IntPtr"/> to <see cref="PCCERT_CONTEXT"/>.</summary>
		/// <param name="h">The pointer to a handle.</param>
		/// <returns>The result of the conversion.</returns>
		public static implicit operator PCCERT_CONTEXT(IntPtr h) => new(h);

		/// <summary>Performs an explicit conversion from <see cref="PCCERT_CONTEXT"/> to <see cref="CERT_CONTEXT"/>.</summary>
		/// <param name="h">The <see cref="PCCERT_CONTEXT"/> instance.</param>
		/// <returns>The resulting <see cref="CERT_CONTEXT"/> instance from the conversion.</returns>
		public static unsafe explicit operator CERT_CONTEXT*(PCCERT_CONTEXT h) => (CERT_CONTEXT*)(void*)h.handle;

		/// <summary>Implements the operator !=.</summary>
		/// <param name="h1">The first handle.</param>
		/// <param name="h2">The second handle.</param>
		/// <returns>The result of the operator.</returns>
		public static bool operator !=(PCCERT_CONTEXT h1, PCCERT_CONTEXT h2) => !(h1 == h2);

		/// <summary>Implements the operator ==.</summary>
		/// <param name="h1">The first handle.</param>
		/// <param name="h2">The second handle.</param>
		/// <returns>The result of the operator.</returns>
		public static bool operator ==(PCCERT_CONTEXT h1, PCCERT_CONTEXT h2) => h1.Equals(h2);

		/// <inheritdoc/>
		public override bool Equals(object? obj) => obj is PCCERT_CONTEXT h && handle == h.handle;

		/// <inheritdoc/>
		public override int GetHashCode() => handle.GetHashCode();

		/// <inheritdoc/>
		public IntPtr DangerousGetHandle() => handle;
	}

	/// <summary>Provides a handle to a CLR_CONTEXT.</summary>
	[StructLayout(LayoutKind.Sequential)]
	public readonly struct PCCRL_CONTEXT : IHandle
	{
		private readonly IntPtr handle;

		/// <summary>Initializes a new instance of the <see cref="PCCRL_CONTEXT"/> struct.</summary>
		/// <param name="preexistingHandle">An <see cref="IntPtr"/> object that represents the pre-existing handle to use.</param>
		public PCCRL_CONTEXT(IntPtr preexistingHandle) => handle = preexistingHandle;

		/// <summary>Returns an invalid handle by instantiating a <see cref="PCCRL_CONTEXT"/> object with <see cref="IntPtr.Zero"/>.</summary>
		public static PCCRL_CONTEXT NULL => new(IntPtr.Zero);

		/// <summary>Gets a value indicating whether this instance is a null handle.</summary>
		public bool IsNull => handle == IntPtr.Zero;

		/// <summary>Performs an explicit conversion from <see cref="PCCRL_CONTEXT"/> to <see cref="IntPtr"/>.</summary>
		/// <param name="h">The handle.</param>
		/// <returns>The result of the conversion.</returns>
		public static explicit operator IntPtr(PCCRL_CONTEXT h) => h.handle;

		/// <summary>Performs an implicit conversion from <see cref="IntPtr"/> to <see cref="PCCRL_CONTEXT"/>.</summary>
		/// <param name="h">The pointer to a handle.</param>
		/// <returns>The result of the conversion.</returns>
		public static implicit operator PCCRL_CONTEXT(IntPtr h) => new(h);

		/// <summary>Performs an implicit conversion from <see cref="PCCRL_CONTEXT"/> to <see cref="CRL_CONTEXT"/>.</summary>
		/// <param name="h">The <see cref="PCCRL_CONTEXT"/> instance.</param>
		/// <returns>The resulting <see cref="CRL_CONTEXT"/> instance from the conversion.</returns>
		public static unsafe explicit operator CRL_CONTEXT*(PCCRL_CONTEXT h) => (CRL_CONTEXT*)(void*)h.handle;

		/// <summary>Implements the operator !=.</summary>
		/// <param name="h1">The first handle.</param>
		/// <param name="h2">The second handle.</param>
		/// <returns>The result of the operator.</returns>
		public static bool operator !=(PCCRL_CONTEXT h1, PCCRL_CONTEXT h2) => !(h1 == h2);

		/// <summary>Implements the operator ==.</summary>
		/// <param name="h1">The first handle.</param>
		/// <param name="h2">The second handle.</param>
		/// <returns>The result of the operator.</returns>
		public static bool operator ==(PCCRL_CONTEXT h1, PCCRL_CONTEXT h2) => h1.Equals(h2);

		/// <inheritdoc/>
		public override bool Equals(object? obj) => obj is PCCRL_CONTEXT h && handle == h.handle;

		/// <inheritdoc/>
		public override int GetHashCode() => handle.GetHashCode();

		/// <inheritdoc/>
		public IntPtr DangerousGetHandle() => handle;
	}

	/// <summary>Provides a handle to a CTL_CONTEXT.</summary>
	[StructLayout(LayoutKind.Sequential)]
	public readonly struct PCCTL_CONTEXT : IHandle
	{
		private readonly IntPtr handle;

		/// <summary>Initializes a new instance of the <see cref="PCCTL_CONTEXT"/> struct.</summary>
		/// <param name="preexistingHandle">An <see cref="IntPtr"/> object that represents the pre-existing handle to use.</param>
		public PCCTL_CONTEXT(IntPtr preexistingHandle) => handle = preexistingHandle;

		/// <summary>Returns an invalid handle by instantiating a <see cref="PCCTL_CONTEXT"/> object with <see cref="IntPtr.Zero"/>.</summary>
		public static PCCTL_CONTEXT NULL => new(IntPtr.Zero);

		/// <summary>Gets a value indicating whether this instance is a null handle.</summary>
		public bool IsNull => handle == IntPtr.Zero;

		/// <summary>Performs an explicit conversion from <see cref="PCCTL_CONTEXT"/> to <see cref="IntPtr"/>.</summary>
		/// <param name="h">The handle.</param>
		/// <returns>The result of the conversion.</returns>
		public static explicit operator IntPtr(PCCTL_CONTEXT h) => h.handle;

		/// <summary>Performs an implicit conversion from <see cref="IntPtr"/> to <see cref="PCCTL_CONTEXT"/>.</summary>
		/// <param name="h">The pointer to a handle.</param>
		/// <returns>The result of the conversion.</returns>
		public static implicit operator PCCTL_CONTEXT(IntPtr h) => new(h);

		/// <summary>Performs an explicit conversion from <see cref="PCCTL_CONTEXT"/> to <see cref="CTL_CONTEXT"/>.</summary>
		/// <param name="h">The handle.</param>
		/// <returns>The resulting <see cref="CTL_CONTEXT"/> instance from the conversion.</returns>
		public static unsafe explicit operator CTL_CONTEXT*(PCCTL_CONTEXT h) => (CTL_CONTEXT*)(void*)h.handle;

		/// <summary>Implements the operator !=.</summary>
		/// <param name="h1">The first handle.</param>
		/// <param name="h2">The second handle.</param>
		/// <returns>The result of the operator.</returns>
		public static bool operator !=(PCCTL_CONTEXT h1, PCCTL_CONTEXT h2) => !(h1 == h2);

		/// <summary>Implements the operator ==.</summary>
		/// <param name="h1">The first handle.</param>
		/// <param name="h2">The second handle.</param>
		/// <returns>The result of the operator.</returns>
		public static bool operator ==(PCCTL_CONTEXT h1, PCCTL_CONTEXT h2) => h1.Equals(h2);

		/// <inheritdoc/>
		public override bool Equals(object? obj) => obj is PCCTL_CONTEXT h && handle == h.handle;

		/// <inheritdoc/>
		public override int GetHashCode() => handle.GetHashCode();

		/// <inheritdoc/>
		public IntPtr DangerousGetHandle() => handle;
	}

	/// <summary>
	/// The BLOB structure contains an arbitrary array of bytes. The structure definition includes aliases appropriate to the various
	/// functions that use it.
	/// </summary>
	[PInvokeData("wincrypt.h")]
	[StructLayout(LayoutKind.Sequential, CharSet = CharSet.Ansi)]
	public class SafeCRYPTOAPI_BLOB : IDisposable
	{
		/// <summary>A DWORD variable that contains the count, in bytes, of data.</summary>
		private uint cbData;

		/// <summary>A pointer to the data buffer.</summary>
		private IntPtr pbData;

		/// <summary>Initializes a new instance of the <see cref="SafeCRYPTOAPI_BLOB"/> class.</summary>
		/// <param name="size">The size, in bytes, to allocate.</param>
		public SafeCRYPTOAPI_BLOB(int size)
		{
			cbData = (uint)size;
			if (size > 0)
				pbData = MemMethods.AllocMem(size);
		}

		/// <summary>Initializes a new instance of the <see cref="SafeCRYPTOAPI_BLOB"/> class.</summary>
		/// <param name="bytes">The bytes to copy into the blob.</param>
		public SafeCRYPTOAPI_BLOB(byte[]? bytes) : this(bytes?.Length ?? 0)
		{
			if (bytes is not null)
				Marshal.Copy(bytes, 0, pbData, bytes.Length);
		}

		/// <summary>Initializes a new instance of the <see cref="SafeCRYPTOAPI_BLOB"/> class with a string.</summary>
		/// <param name="value">The string value.</param>
		/// <param name="charSet">The character set to use.</param>
		public SafeCRYPTOAPI_BLOB(string value, CharSet charSet = CharSet.Unicode) : this(StringHelper.GetBytes(value, true, charSet))
		{
		}

		private SafeCRYPTOAPI_BLOB(IntPtr handle, int size)
		{
			pbData = handle;
			cbData = (uint)size;
		}

		/// <summary>Represents an empty instance of a blob.</summary>
		public static readonly SafeCRYPTOAPI_BLOB Empty = new(IntPtr.Zero, 0);

		/// <summary>Performs application-defined tasks associated with freeing, releasing, or resetting unmanaged resources.</summary>
		public void Dispose()
		{
			MemMethods.FreeMem(pbData);
			pbData = IntPtr.Zero;
			cbData = 0;
		}

		/// <summary>Allocates from unmanaged memory sufficient memory to hold an object of type T.</summary>
		/// <typeparam name="T">Native type</typeparam>
		/// <param name="value">The value.</param>
		/// <returns><see cref="SafeCRYPTOAPI_BLOB"/> object to an native (unmanaged) memory block the size of T.</returns>
		public static SafeCRYPTOAPI_BLOB CreateFromStructure<T>(in T value = default) where T : struct => new(InteropExtensions.MarshalToPtr(value, MemMethods.AllocMem, out int s), s);

		/// <summary>
		/// Allocates from unmanaged memory to represent a structure with a variable length array at the end and marshal these structure
		/// elements. It is the callers responsibility to marshal what precedes the trailing array into the unmanaged memory. ONLY
		/// structures with attribute StructLayout of LayoutKind.Sequential are supported.
		/// </summary>
		/// <typeparam name="T">Type of the trailing array of structures</typeparam>
		/// <param name="values">Collection of structure objects</param>
		/// <param name="count">
		/// Number of items in <paramref name="values"/>. Setting this value to -1 will cause the method to get the count by iterating
		/// through <paramref name="values"/>.
		/// </param>
		/// <param name="prefixBytes">Number of bytes preceding the trailing array of structures</param>
		/// <returns><see cref="SafeCRYPTOAPI_BLOB"/> object to an native (unmanaged) structure with a trail array of structures</returns>
		public static SafeCRYPTOAPI_BLOB CreateFromList<T>(IEnumerable<T> values, int count = -1, int prefixBytes = 0) =>
			new(InteropExtensions.MarshalToPtr(values, MemMethods.AllocMem, out int s, prefixBytes), s);

		/// <summary>Allocates from unmanaged memory sufficient memory to hold an array of strings.</summary>
		/// <param name="values">The list of strings.</param>
		/// <param name="packing">The packing type for the strings.</param>
		/// <param name="charSet">The character set to use for the strings.</param>
		/// <param name="prefixBytes">Number of bytes preceding the trailing strings.</param>
		/// <returns>
		/// <see cref="SafeCRYPTOAPI_BLOB"/> object to an native (unmanaged) array of strings stored using the <paramref
		/// name="packing"/> model and the character set defined by <paramref name="charSet"/>.
		/// </returns>
		public static SafeCRYPTOAPI_BLOB CreateFromStringList(IEnumerable<string> values, StringListPackMethod packing = StringListPackMethod.Concatenated, CharSet charSet = CharSet.Auto, int prefixBytes = 0) =>
			new(InteropExtensions.MarshalToPtr(values, packing, MemMethods.AllocMem, out int s, charSet, prefixBytes), s);

		private static IMemoryMethods MemMethods => HGlobalMemoryMethods.Instance;
	}

	/// <summary>Provides a <see cref="SafeHandle"/> for an object identifier that can be either a string or an integer.</summary>
	public class SafeOID : SafeHANDLE
	{
		/// <summary>Initializes a new instance of the <see cref="SafeOID"/> class and assigns an existing handle.</summary>
		/// <param name="preexistingHandle">An <see cref="IntPtr"/> object that represents the pre-existing handle to use.</param>
		/// <param name="ownsHandle">
		/// <see langword="true"/> to reliably release the handle during the finalization phase; otherwise, <see langword="false"/> (not recommended).
		/// </param>
		public SafeOID(IntPtr preexistingHandle, bool ownsHandle = true) : base(preexistingHandle, ownsHandle) { }

		/// <summary>Initializes a new instance of the <see cref="SafeOID"/> class.</summary>
		/// <param name="value">The value.</param>
		public SafeOID(int value) => SetHandle((IntPtr)unchecked((ushort)value));

		/// <summary>Initializes a new instance of the <see cref="SafeOID"/> class.</summary>
		/// <param name="value">The value.</param>
		public SafeOID(uint value) => SetHandle((IntPtr)unchecked((ushort)value));

		/// <summary>Initializes a new instance of the <see cref="SafeOID"/> class.</summary>
		/// <param name="value">The value.</param>
		public SafeOID(string value) : base(Marshal.StringToCoTaskMemAnsi(value)) { }

		/// <summary>Initializes a new instance of the <see cref="SafeOID"/> class.</summary>
		private SafeOID() : base() { }

		/// <summary>Gets a value indicating whether this instance is string.</summary>
		/// <value><see langword="true"/> if this instance is string; otherwise, <see langword="false"/>.</value>
		private bool IsString => !Macros.IS_INTRESOURCE(handle);

		/// <summary>Performs an implicit conversion from <see cref="SafeOID"/> to <see cref="IntPtr"/>.</summary>
		/// <param name="value">The value.</param>
		/// <returns>The resulting <see cref="IntPtr"/> instance from the conversion.</returns>
		public static implicit operator IntPtr(SafeOID value) => value.handle;

		/// <summary>Performs an implicit conversion from <see cref="System.String"/> to <see cref="SafeOID"/>.</summary>
		/// <param name="value">The value.</param>
		/// <returns>The resulting <see cref="SafeOID"/> instance from the conversion.</returns>
		public static implicit operator SafeOID(string value) => new(value);

		/// <summary>Performs an implicit conversion from <see cref="System.Int32"/> to <see cref="SafeOID"/>.</summary>
		/// <param name="value">The value.</param>
		/// <returns>The resulting <see cref="SafeOID"/> instance from the conversion.</returns>
		public static implicit operator SafeOID(int value) => new(value);

		/// <summary>Performs an implicit conversion from <see cref="System.UInt32"/> to <see cref="SafeOID"/>.</summary>
		/// <param name="value">The value.</param>
		/// <returns>The resulting <see cref="SafeOID"/> instance from the conversion.</returns>
		public static implicit operator SafeOID(uint value) => new(value);

		/// <summary>Performs an implicit conversion from <see cref="SafeOID"/> to <see cref="StrPtrAnsi"/>.</summary>
		/// <param name="value">The value.</param>
		/// <returns>The resulting <see cref="StrPtrAnsi"/> instance from the conversion.</returns>
		public static implicit operator StrPtrAnsi(SafeOID value) => value.handle;

		/// <summary>Performs an implicit conversion from <see cref="IntPtr"/> to <see cref="SafeOID"/>.</summary>
		/// <param name="oidToDuplicate">The OID to duplicate into a new SafeOID.</param>
		/// <returns>The result of the conversion.</returns>
		public static implicit operator SafeOID(IntPtr oidToDuplicate) => Macros.IS_INTRESOURCE(oidToDuplicate) ? new(oidToDuplicate.ToInt32()) : new(Marshal.PtrToStringAnsi(oidToDuplicate)!);

		/// <summary>Gets the integer value, if possible.</summary>
		/// <returns>The integer value, if set; otherwise <see langword="null"/>.</returns>
		public int? GetInt32Value() => IsString ? null : (int?)handle.ToInt32();

		/// <summary>Gets the string value, if possible.</summary>
		/// <returns>The string value, if set; otherwise <see langword="null"/>.</returns>
		public string? GetStringValue() => IsString ? Marshal.PtrToStringAnsi(handle) : null;

		/// <summary>
		/// Internal method that actually releases the handle. This is called by <see cref="M:Vanara.PInvoke.SafeHANDLE.ReleaseHandle"/>
		/// for valid handles and afterwards zeros the handle.
		/// </summary>
		/// <returns><c>true</c> to indicate successful release of the handle; <c>false</c> otherwise.</returns>
		protected override bool InternalReleaseHandle()
		{
			if (IsString)
				Marshal.FreeCoTaskMem(handle);
			handle = IntPtr.Zero;
			return true;
		}

		/// <inheritdoc/>
		public override string? ToString() => !IsString ? $"#{handle.ToInt32()}" : Marshal.PtrToStringAnsi(handle) ?? "";

		/// <inheritdoc/>
		public override int GetHashCode() => handle.GetHashCode();

		/// <summary>NULL value.</summary>
		public static readonly SafeOID NULL = new(IntPtr.Zero, false);

		/// <summary/>
		public static readonly SafeOID CRYPT_ENCODE_DECODE_NONE = new(0);

		//+-------------------------------------------------------------------------
		//  Predefined X509 certificate data structures that can be encoded / decoded.
		//--------------------------------------------------------------------------
		/// <summary/>
		public static readonly SafeOID X509_CERT = new(1);
		/// <summary/>
		public static readonly SafeOID X509_CERT_TO_BE_SIGNED = new(2);
		/// <summary/>
		public static readonly SafeOID X509_CERT_CRL_TO_BE_SIGNED = new(3);
		/// <summary/>
		public static readonly SafeOID X509_CERT_REQUEST_TO_BE_SIGNED = new(4);
		/// <summary/>
		public static readonly SafeOID X509_EXTENSIONS = new(5);
		/// <summary/>
		public static readonly SafeOID X509_NAME_VALUE = new(6);
		/// <summary/>
		public static readonly SafeOID X509_NAME = new(7);
		/// <summary/>
		public static readonly SafeOID X509_PUBLIC_KEY_INFO = new(8);

		//+-------------------------------------------------------------------------
		//  Predefined X509 certificate extension data structures that can be
		//  encoded / decoded.
		//--------------------------------------------------------------------------
		/// <summary/>
		public static readonly SafeOID X509_AUTHORITY_KEY_ID = new(9);
		/// <summary/>
		public static readonly SafeOID X509_KEY_ATTRIBUTES = new(10);
		/// <summary/>
		public static readonly SafeOID X509_KEY_USAGE_RESTRICTION = new(11);
		/// <summary/>
		public static readonly SafeOID X509_ALTERNATE_NAME = new(12);
		/// <summary/>
		public static readonly SafeOID X509_BASIC_CONSTRAINTS = new(13);
		/// <summary/>
		public static readonly SafeOID X509_KEY_USAGE = new(14);
		/// <summary/>
		public static readonly SafeOID X509_BASIC_CONSTRAINTS2 = new(15);
		/// <summary/>
		public static readonly SafeOID X509_CERT_POLICIES = new(16);

		//+-------------------------------------------------------------------------
		//  Additional predefined data structures that can be encoded / decoded.
		//--------------------------------------------------------------------------
		/// <summary/>
		public static readonly SafeOID PKCS_UTC_TIME = new(17);
		/// <summary/>
		public static readonly SafeOID PKCS_TIME_REQUEST = new(18);
		/// <summary/>
		public static readonly SafeOID RSA_CSP_PUBLICKEYBLOB = new(19);
		/// <summary/>
		public static readonly SafeOID X509_UNICODE_NAME = new(20);
		/// <summary/>
		public static readonly SafeOID X509_KEYGEN_REQUEST_TO_BE_SIGNED = new(21);
		/// <summary/>
		public static readonly SafeOID PKCS_ATTRIBUTE = new(22);
		/// <summary/>
		public static readonly SafeOID PKCS_CONTENT_INFO_SEQUENCE_OF_ANY = new(23);

		//+-------------------------------------------------------------------------
		//  Predefined primitive data structures that can be encoded / decoded.
		//--------------------------------------------------------------------------
		/// <summary/>
		public static readonly SafeOID X509_UNICODE_NAME_VALUE = new(24);
		/// <summary/>
		public static readonly SafeOID X509_ANY_STRING = X509_NAME_VALUE;
		/// <summary/>
		public static readonly SafeOID X509_UNICODE_ANY_STRING = X509_UNICODE_NAME_VALUE;
		/// <summary/>
		public static readonly SafeOID X509_OCTET_STRING = new(25);
		/// <summary/>
		public static readonly SafeOID X509_BITS = new(26);
		/// <summary/>
		public static readonly SafeOID X509_INTEGER = new(27);
		/// <summary/>
		public static readonly SafeOID X509_MULTI_BYTE_INTEGER = new(28);
		/// <summary/>
		public static readonly SafeOID X509_ENUMERATED = new(29);
		/// <summary/>
		public static readonly SafeOID X509_CHOICE_OF_TIME = new(30);

		//+-------------------------------------------------------------------------
		//  More predefined X509 certificate extension data structures that can be
		//  encoded / decoded.
		//--------------------------------------------------------------------------
		/// <summary/>
		public static readonly SafeOID X509_AUTHORITY_KEY_ID2 = new(31);
		/// <summary/>
		public static readonly SafeOID X509_AUTHORITY_INFO_ACCESS = new(32);
		/// <summary/>
		public static readonly SafeOID PKCS_CONTENT_INFO = new(33);
		/// <summary/>
		public static readonly SafeOID X509_SEQUENCE_OF_ANY = new(34);
		/// <summary/>
		public static readonly SafeOID X509_CRL_DIST_POINTS = new(35);
		/// <summary/>
		public static readonly SafeOID X509_ENHANCED_KEY_USAGE = new(36);
		/// <summary/>
		public static readonly SafeOID PKCS_CTL = new(37);
		/// <summary/>
		public static readonly SafeOID X509_MULTI_BYTE_UINT = new(38);
		/// <summary/>
		public static readonly SafeOID X509_DSS_PARAMETERS = new(39);
		/// <summary/>
		public static readonly SafeOID X509_DSS_SIGNATURE = new(40);
		/// <summary/>
		public static readonly SafeOID PKCS_RC2_CBC_PARAMETERS = new(41);
		/// <summary/>
		public static readonly SafeOID PKCS_SMIME_CAPABILITIES = new(42);
		/// <summary/>
		public static readonly SafeOID X509_SUBJECT_INFO_ACCESS = X509_AUTHORITY_INFO_ACCESS;
		/// <summary/>
		public static readonly SafeOID X509_CRL_REASON_CODE = X509_ENUMERATED;
		/// <summary/>
		public static readonly SafeOID X509_DSS_PUBLICKEY = X509_MULTI_BYTE_UINT;

		// Qualified Certificate Statements Extension uses the same encode/decode
		// function as PKCS_SMIME_CAPABILITIES. Its data structures are identical
		// except for the names of the fields.
		/// <summary/>
		public static readonly SafeOID X509_QC_STATEMENTS_EXT = new(42);

		//+-------------------------------------------------------------------------
		//  data structures for private keys
		//--------------------------------------------------------------------------
		/// <summary/>
		public static readonly SafeOID PKCS_RSA_PRIVATE_KEY = new(43);
		/// <summary/>
		public static readonly SafeOID PKCS_PRIVATE_KEY_INFO = new(44);
		/// <summary/>
		public static readonly SafeOID PKCS_ENCRYPTED_PRIVATE_KEY_INFO = new(45);

		//+-------------------------------------------------------------------------
		//  certificate policy qualifier
		//--------------------------------------------------------------------------
		/// <summary/>
		public static readonly SafeOID X509_PKIX_POLICY_QUALIFIER_USERNOTICE = new(46);

		//+-------------------------------------------------------------------------
		//  Diffie-Hellman Key Exchange
		//--------------------------------------------------------------------------
		/// <summary/>
		public static readonly SafeOID X509_DH_PUBLICKEY = X509_MULTI_BYTE_UINT;
		/// <summary/>
		public static readonly SafeOID X509_DH_PARAMETERS = new(47);
		/// <summary/>
		public static readonly SafeOID PKCS_ATTRIBUTES = new(48);
		/// <summary/>
		public static readonly SafeOID PKCS_SORTED_CTL = new(49);

		//+-------------------------------------------------------------------------
		//  ECC Signature
		//--------------------------------------------------------------------------
		// Uses the same encode/decode function as X509_DH_PARAMETERS. Its data
		// structure is identical except for the names of the fields.
		/// <summary/>
		public static readonly SafeOID X509_ECC_SIGNATURE = new(47);

		//+-------------------------------------------------------------------------
		//  X942 Diffie-Hellman
		//--------------------------------------------------------------------------
		/// <summary/>
		public static readonly SafeOID X942_DH_PARAMETERS = new(50);

		//+-------------------------------------------------------------------------
		//  The following is the same as X509_BITS, except before encoding,
		//  the bit length is decremented to exclude trailing zero bits.
		//--------------------------------------------------------------------------
		/// <summary/>
		public static readonly SafeOID X509_BITS_WITHOUT_TRAILING_ZEROES = new(51);

		//+-------------------------------------------------------------------------
		//  X942 Diffie-Hellman Other Info
		//--------------------------------------------------------------------------
		/// <summary/>
		public static readonly SafeOID X942_OTHER_INFO = new(52);
		/// <summary/>
		public static readonly SafeOID X509_CERT_PAIR = new(53);
		/// <summary/>
		public static readonly SafeOID X509_ISSUING_DIST_POINT = new(54);
		/// <summary/>
		public static readonly SafeOID X509_NAME_CONSTRAINTS = new(55);
		/// <summary/>
		public static readonly SafeOID X509_POLICY_MAPPINGS = new(56);
		/// <summary/>
		public static readonly SafeOID X509_POLICY_CONSTRAINTS = new(57);
		/// <summary/>
		public static readonly SafeOID X509_CROSS_CERT_DIST_POINTS = new(58);

		//+-------------------------------------------------------------------------
		//  Certificate Management Messages over CMS (CMC) Data Structures
		//--------------------------------------------------------------------------
		/// <summary/>
		public static readonly SafeOID CMC_DATA = new(59);
		/// <summary/>
		public static readonly SafeOID CMC_RESPONSE = new(60);
		/// <summary/>
		public static readonly SafeOID CMC_STATUS = new(61);
		/// <summary/>
		public static readonly SafeOID CMC_ADD_EXTENSIONS = new(62);
		/// <summary/>
		public static readonly SafeOID CMC_ADD_ATTRIBUTES = new(63);

		//+-------------------------------------------------------------------------
		//  Certificate Template
		//--------------------------------------------------------------------------
		/// <summary/>
		public static readonly SafeOID X509_CERTIFICATE_TEMPLATE = new(64);

		//+-------------------------------------------------------------------------
		//  Online Certificate Status Protocol (OCSP) Data Structures
		//--------------------------------------------------------------------------
		/// <summary/>
		public static readonly SafeOID OCSP_SIGNED_REQUEST = new(65);
		/// <summary/>
		public static readonly SafeOID OCSP_REQUEST = new(66);
		/// <summary/>
		public static readonly SafeOID OCSP_RESPONSE = new(67);
		/// <summary/>
		public static readonly SafeOID OCSP_BASIC_SIGNED_RESPONSE = new(68);
		/// <summary/>
		public static readonly SafeOID OCSP_BASIC_RESPONSE = new(69);

		//+-------------------------------------------------------------------------
		//  Logotype and Biometric Extensions
		//--------------------------------------------------------------------------
		/// <summary/>
		public static readonly SafeOID X509_LOGOTYPE_EXT = new(70);
		/// <summary/>
		public static readonly SafeOID X509_BIOMETRIC_EXT = new(71);
		/// <summary/>
		public static readonly SafeOID CNG_RSA_PUBLIC_KEY_BLOB = new(72);
		/// <summary/>
		public static readonly SafeOID X509_OBJECT_IDENTIFIER = new(73);
		/// <summary/>
		public static readonly SafeOID X509_ALGORITHM_IDENTIFIER = new(74);
		/// <summary/>
		public static readonly SafeOID PKCS_RSA_SSA_PSS_PARAMETERS = new(75);
		/// <summary/>
		public static readonly SafeOID PKCS_RSAES_OAEP_PARAMETERS = new(76);
		/// <summary/>
		public static readonly SafeOID ECC_CMS_SHARED_INFO = new(77);

		//+-------------------------------------------------------------------------
		//  TIMESTAMP
		//--------------------------------------------------------------------------
		/// <summary/>
		public static readonly SafeOID TIMESTAMP_REQUEST = new(78);
		/// <summary/>
		public static readonly SafeOID TIMESTAMP_RESPONSE = new(79);
		/// <summary/>
		public static readonly SafeOID TIMESTAMP_INFO = new(80);

		//+-------------------------------------------------------------------------
		//  CertificateBundle
		//--------------------------------------------------------------------------
		/// <summary/>
		public static readonly SafeOID X509_CERT_BUNDLE = new(81);

		//+-------------------------------------------------------------------------
		//  ECC Keys
		//--------------------------------------------------------------------------
		/// <summary/>
		public static readonly SafeOID X509_ECC_PRIVATE_KEY = new(82);   // CRYPT_ECC_PRIVATE_KEY_INFO
		/// <summary/>
		public static readonly SafeOID CNG_RSA_PRIVATE_KEY_BLOB = new(83);   // BCRYPT_RSAKEY_BLOB

		//+-------------------------------------------------------------------------
		//  Subject Directory Attributes extension
		//--------------------------------------------------------------------------
		/// <summary/>
		public static readonly SafeOID X509_SUBJECT_DIR_ATTRS = new(84);

		//+-------------------------------------------------------------------------
		//  Generic ECC Parameters
		//--------------------------------------------------------------------------
		/// <summary/>
		public static readonly SafeOID X509_ECC_PARAMETERS = new(85);

		//+-------------------------------------------------------------------------
		//  Predefined PKCS #7 data structures that can be encoded / decoded.
		//--------------------------------------------------------------------------
		/// <summary/>
		public static readonly SafeOID PKCS7_SIGNER_INFO = new(500);

		//+-------------------------------------------------------------------------
		//  Predefined PKCS #7 data structures that can be encoded / decoded.
		//--------------------------------------------------------------------------
		/// <summary/>
		public static readonly SafeOID CMS_SIGNER_INFO = new(501);
	}
}