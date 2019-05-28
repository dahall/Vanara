using System;
using System.Runtime.InteropServices;
using Vanara.InteropServices;
using FILETIME = System.Runtime.InteropServices.ComTypes.FILETIME;

namespace Vanara.PInvoke
{
	/// <summary>Methods and data types found in Crypt32.dll.</summary>
	public static partial class Crypt32
	{
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

		/// <summary>
		/// A certificate encoding type.
		/// </summary>
		[PInvokeData("wincrypt.h")]
		public enum CertEncodingType : uint
		{
			/// <summary>
			/// The crypt asn encoding
			/// </summary>
			CRYPT_ASN_ENCODING = 0x00000001,
			/// <summary>
			/// The crypt NDR encoding
			/// </summary>
			CRYPT_NDR_ENCODING = 0x00000002,
			/// <summary>
			/// The X509 asn encoding
			/// </summary>
			X509_ASN_ENCODING = 0x00000001,
			/// <summary>
			/// The X509 NDR encoding
			/// </summary>
			X509_NDR_ENCODING = 0x00000002,
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

		/// <summary>
		/// The CERT_CONTEXT structure contains both the encoded and decoded representations of a certificate. A certificate context returned
		/// by one of the functions defined in Wincrypt.h must be freed by calling the CertFreeCertificateContext function. The
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
			public uint dwCertEncodingType;

			/// <summary>A pointer to a buffer that contains the encoded certificate.</summary>
			public IntPtr pbCertEncoded;

			/// <summary>The size, in bytes, of the encoded certificate.</summary>
			public uint cbCertEncoded;

			/// <summary>The address of a CERT_INFO structure that contains the certificate information.</summary>
			public IntPtr pCertInfo;

			/// <summary>A handle to the certificate store that contains the certificate context.</summary>
			public IntPtr hCertStore;
		}

		/// <summary>
		/// The CERT_EXTENSION structure contains the extension information for a certificate, Certificate Revocation List (CRL) or
		/// Certificate Trust List (CTL).
		/// </summary>
		[PInvokeData("wincrypt.h")]
		[StructLayout(LayoutKind.Sequential, CharSet = CharSet.Ansi)]
		public struct CERT_EXTENSION
		{
			/// <summary>
			/// Object identifier (OID) that specifies the structure of the extension data contained in the Value member. For specifics on
			/// extension OIDs and their related structures, see X.509 Certificate Extension Structures.
			/// </summary>
			public StrPtrAnsi pszObjId;

			/// <summary>
			/// If TRUE, any limitations specified by the extension in the Value member of this structure are imperative. If FALSE,
			/// limitations set by this extension can be ignored.
			/// </summary>
			[MarshalAs(UnmanagedType.Bool)]
			public bool fCritical;

			/// <summary>
			/// A CRYPT_OBJID_BLOB structure that contains the encoded extension data. The cbData member of Value indicates the length in
			/// bytes of the pbData member. The pbData member byte string is the encoded extension.e
			/// </summary>
			public CRYPTOAPI_BLOB Value;
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
			/// and is precise to seconds. For dates before 1950 or after 2049, encoded generalized time is used. Encoded generalized time is
			/// in the form YYYYMMDDHHMMSSMMM, using a four-digit year, and is precise to milliseconds. Even though generalized time supports
			/// millisecond resolution, the NotBefore time is only precise to seconds.
			/// </summary>
			public FILETIME NotBefore;

			/// <summary>
			/// Date and time after which the certificate is not valid. For dates between 1950 and 2049 inclusive, the date and time is
			/// encoded Coordinated Universal Time format in the form YYMMDDHHMMSS. This member uses a two-digit year and is precise to
			/// seconds. For dates before 1950 or after 2049, encoded generalized time is used. Encoded generalized time is in the form
			/// YYYYMMDDHHMMSSMMM, using a four-digit year, and is precise to milliseconds. Even though generalized time supports millisecond
			/// resolution, the NotAfter time is only precise to seconds.
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
			public CRYPTOAPI_BLOB IssuerUniqueId;

			/// <summary>A BLOB that contains a unique identifier of the subject.</summary>
			public CRYPTOAPI_BLOB SubjectUniqueId;

			/// <summary>The number of elements in the rgExtension array.</summary>
			public uint cExtension;

			/// <summary>An array of pointers to CERT_EXTENSION structures, each of which contains extension information about the certificate.</summary>
			public IntPtr rgExtension;
		}

		/// <summary>The CERT_PUBLIC_KEY_INFO structure contains a public key and its algorithm.</summary>
		[PInvokeData("wincrypt.h")]
		[StructLayout(LayoutKind.Sequential, CharSet = CharSet.Ansi)]
		public struct CERT_PUBLIC_KEY_INFO
		{
			/// <summary>CRYPT_ALGORITHM_IDENTIFIER structure that contains the public key algorithm type and associated additional parameters.</summary>
			public CRYPT_ALGORITHM_IDENTIFIER Algorithm;

			/// <summary>BLOB containing an encoded public key.</summary>
			public CRYPTOAPI_BLOB PublicKey;
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
			/// The certificate or one of the certificates in the certificate chain has a policy constraints extension, and one of the issued
			/// certificates has a disallowed policy mapping extension or does not have a required issuance policies extension.
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
			/// The certificate or one of the certificates in the certificate chain has a name constraints extension and a name constraint is
			/// missing for one of the name choices in the end certificate.
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
			/// CERT_CHAIN_ENGINE_CONFIG structure. The CA certificate is treated as a trust anchor for the certificate chain. This flag will
			/// only be set if the CERT_CHAIN_EXCLUSIVE_ENABLE_CA_FLAG value is set in the dwExclusiveFlags member of the
			/// CERT_CHAIN_ENGINE_CONFIG structure. If this flag is set, the CERT_TRUST_IS_SELF_SIGNED and the
			/// CERT_TRUST_IS_PARTIAL_CHAINdwErrorStatus flags will not be set. Windows 8 and Windows Server 2012: Support for this flag begins.
			/// </term>
			/// </item>
			/// </list>
			/// </summary>
			public uint dwInfoStatus;
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

		/// <summary>
		/// The BLOB structure contains an arbitrary array of bytes. The structure definition includes aliases appropriate to the various
		/// functions that use it.
		/// </summary>
		[PInvokeData("wincrypt.h")]
		[StructLayout(LayoutKind.Sequential, CharSet = CharSet.Ansi)]
		public struct CRYPTOAPI_BLOB
		{
			/// <summary>A DWORD variable that contains the count, in bytes, of data.</summary>
			public uint cbData;

			/// <summary>A pointer to the data buffer.</summary>
			public IntPtr pbData;
		}

		/*CertAddCertificateContextToStore
		CertAddCertificateLinkToStore
		CertAddCRLContextToStore
		CertAddCRLLinkToStore
		CertAddCTLContextToStore
		CertAddCTLLinkToStore
		CertAddEncodedCertificateToStore
		CertAddEncodedCertificateToSystemStore
		CertAddEncodedCRLToStore
		CertAddEncodedCTLToStore
		CertAddEnhancedKeyUsageIdentifier
		CertAddRefServerOcspResponse
		CertAddRefServerOcspResponseContext
		CertAddSerializedElementToStore
		CertAddStoreToCollection
		CertAlgIdToOID
		CertCloseServerOcspResponse
		CertCloseStore
		CertCompareCertificate
		CertCompareCertificateName
		CertCompareIntegerBlob
		CertComparePublicKeyInfo
		CertControlStore
		CertCreateCertificateChainEngine
		CertCreateCertificateContext
		CertCreateContext
		CertCreateCRLContext
		CertCreateCTLContext
		CertCreateCTLEntryFromCertificateContextProperties
		CertCreateSelfSignCertificate
		CertDeleteCertificateFromStore
		CertDeleteCRLFromStore
		CertDeleteCTLFromStore
		CertDuplicateCertificateChain
		CertDuplicateCertificateContext
		CertDuplicateCRLContext
		CertDuplicateCTLContext
		CertDuplicateStore
		CertEnumCertificateContextProperties
		CertEnumCertificatesInStore
		CertEnumCRLContextProperties
		CertEnumCRLsInStore
		CertEnumCTLContextProperties
		CertEnumCTLsInStore
		CertEnumPhysicalStore
		CertEnumSubjectInSortedCTL
		CertEnumSystemStore
		CertEnumSystemStoreLocation
		CertFindAttribute
		CertFindCertificateInCRL
		CertFindCertificateInStore
		CertFindChainInStore
		CertFindCRLInStore
		CertFindCTLInStore
		CertFindExtension
		CertFindRDNAttr
		CertFindSubjectInCTL
		CertFindSubjectInSortedCTL
		CertFreeCertificateChain
		CertFreeCertificateChainEngine
		CertFreeCertificateChainList
		CertFreeCertificateContext
		CertFreeCRLContext
		CertFreeCTLContext
		CertFreeServerOcspResponseContext
		CertGetCertificateChain
		CertGetCertificateContextProperty
		CertGetCRLContextProperty
		CertGetCRLFromStore
		CertGetCTLContextProperty
		CertGetEnhancedKeyUsage
		CertGetIntendedKeyUsage
		CertGetIssuerCertificateFromStore
		CertGetNameString
		CertGetPublicKeyLength
		CertGetServerOcspResponseContext
		CertGetStoreProperty
		CertGetSubjectCertificateFromStore
		CertGetValidUsages
		CertIsRDNAttrsInCertificateName
		CertIsStrongHashToSign
		CertIsValidCRLForCertificate
		CertNameToStr
		CertOIDToAlgId
		CertOpenServerOcspResponse
		CertOpenStore
		CertOpenSystemStore
		CertRDNValueToStr
		CertRegisterPhysicalStore
		CertRegisterSystemStore
		CertRemoveEnhancedKeyUsageIdentifier
		CertRemoveStoreFromCollection
		CertResyncCertificateChainEngine
		CertRetrieveLogoOrBiometricInfo
		CertSaveStore
		CertSelectCertificateChains
		CertSerializeCertificateStoreElement
		CertSerializeCRLStoreElement
		CertSerializeCTLStoreElement
		CertSetCertificateContextPropertiesFromCTLEntry
		CertSetCertificateContextProperty
		CertSetCRLContextProperty
		CertSetCTLContextProperty
		CertSetEnhancedKeyUsage
		CertSetStoreProperty
		CertStrToName
		CertUnregisterPhysicalStore
		CertUnregisterSystemStore
		CertVerifyCertificateChainPolicy
		CertVerifyCRLRevocation
		CertVerifyCRLTimeValidity
		CertVerifyCTLUsage
		CertVerifyRevocation
		CertVerifySubjectCertificateContext
		CertVerifyTimeValidity
		CertVerifyValidityNesting
		CryptAcquireCertificatePrivateKey
		CryptBinaryToString
		CryptCreateKeyIdentifierFromCSP
		CryptDecodeMessage
		CryptDecodeObject
		CryptDecodeObjectEx
		CryptDecryptAndVerifyMessageSignature
		CryptDecryptMessage
		CryptEncodeObject
		CryptEncodeObjectEx
		CryptEncryptMessage
		CryptEnumKeyIdentifierProperties
		CryptEnumOIDFunction
		CryptEnumOIDInfo
		CryptExportPublicKeyInfo
		CryptExportPublicKeyInfoEx
		CryptExportPublicKeyInfoFromBCryptKeyHandle
		CryptFindCertificateKeyProvInfo
		CryptFindLocalizedName
		CryptFindOIDInfo
		CryptFormatObject
		CryptFreeOIDFunctionAddress
		CryptGetDefaultOIDDllList
		CryptGetDefaultOIDFunctionAddress
		CryptGetKeyIdentifierProperty
		CryptGetMessageCertificates
		CryptGetMessageSignerCount
		CryptGetOIDFunctionAddress
		CryptGetOIDFunctionValue
		CryptHashCertificate
		CryptHashCertificate2
		CryptHashMessage
		CryptHashPublicKeyInfo
		CryptHashToBeSigned
		CryptImportPublicKeyInfo
		CryptImportPublicKeyInfoEx
		CryptImportPublicKeyInfoEx2
		CryptInitOIDFunctionSet
		CryptInstallDefaultContext
		CryptInstallOIDFunctionAddress
		CryptMemAlloc
		CryptMemFree
		CryptMemRealloc
		CryptMsgCalculateEncodedLength
		CryptMsgClose
		CryptMsgControl
		CryptMsgCountersign
		CryptMsgCountersignEncoded
		CryptMsgDuplicate
		CryptMsgEncodeAndSignCTL
		CryptMsgGetAndVerifySigner
		CryptMsgGetParam
		CryptMsgOpenToDecode
		CryptMsgOpenToEncode
		CryptMsgSignCTL
		CryptMsgUpdate
		CryptMsgVerifyCountersignatureEncoded
		CryptMsgVerifyCountersignatureEncodedEx
		CryptQueryObject
		CryptRegisterDefaultOIDFunction
		CryptRegisterOIDFunction
		CryptRegisterOIDInfo
		CryptRetrieveTimeStamp
		CryptSetKeyIdentifierProperty
		CryptSetOIDFunctionValue
		CryptSignAndEncodeCertificate
		CryptSignAndEncryptMessage
		CryptSignCertificate
		CryptSignMessage
		CryptSignMessageWithKey
		CryptStringToBinary
		CryptUninstallDefaultContext
		CryptUnregisterDefaultOIDFunction
		CryptUnregisterOIDFunction
		CryptUnregisterOIDInfo
		CryptVerifyCertificateSignature
		CryptVerifyCertificateSignatureEx
		CryptVerifyDetachedMessageHash
		CryptVerifyDetachedMessageSignature
		CryptVerifyMessageHash
		CryptVerifyMessageSignature
		CryptVerifyMessageSignatureWithKey
		CryptVerifyTimeStampSignature
		PFXExportCertStore
		PFXExportCertStoreEx
		PFXImportCertStore
		PFXIsPFXBlob
		PFXVerifyPassword*/
	}
}