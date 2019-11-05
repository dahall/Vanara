using System;
using System.Runtime.InteropServices;
using Vanara.InteropServices;
using FILETIME = System.Runtime.InteropServices.ComTypes.FILETIME;

namespace Vanara.PInvoke
{
	/// <summary>Methods and data types found in Crypt32.dll.</summary>
	public static partial class Crypt32
	{
		public const uint CERT_SYSTEM_STORE_LOCATION_MASK = 0x00FF0000;
		public const uint CERT_SYSTEM_STORE_RELOCATE_FLAG = 0x80000000;
		private const int CERT_COMPARE_SHIFT = 16;
		private const int CERT_SYSTEM_STORE_LOCATION_SHIFT = 16;

		/// <summary>
		/// The <c>CertEnumSystemStoreCallback</c> callback function formats and presents information on each system store found by a call to CertEnumSystemStore.
		/// </summary>
		/// <param name="pvSystemStore">
		/// A pointer to information on the system store found by a call to CertEnumSystemStore. Where appropriate, this argument will
		/// contain a leading computer name or service name prefix.
		/// </param>
		/// <param name="dwFlags">Flag used to call for an alteration of the presentation.</param>
		/// <param name="pStoreInfo">A pointer to a CERT_SYSTEM_STORE_INFO structure that contains information about the store.</param>
		/// <param name="pvReserved">Reserved for future use.</param>
		/// <param name="pvArg">A pointer to information passed to the callback function in the pvArg passed to CertEnumSystemStore.</param>
		/// <returns>If the function succeeds, the function returns TRUE. To stop the enumeration, the function must return FALSE.</returns>
		// https://docs.microsoft.com/en-us/windows/win32/api/wincrypt/nc-wincrypt-pfn_cert_enum_system_store PFN_CERT_ENUM_SYSTEM_STORE
		// PfnCertEnumSystemStore; BOOL PfnCertEnumSystemStore( const void *pvSystemStore, DWORD dwFlags, PCERT_SYSTEM_STORE_INFO pStoreInfo,
		// void *pvReserved, void *pvArg ) {...}
		[PInvokeData("wincrypt.h", MSDNShortId = "f070a9bd-be0b-49d0-9cab-a5d6f05d4e22")]
		[return: MarshalAs(UnmanagedType.Bool)]
		public delegate bool CertEnumSystemStoreCallback(IntPtr pvSystemStore, uint dwFlags, in CERT_SYSTEM_STORE_INFO pStoreInfo, [Optional] IntPtr pvReserved, [Optional] IntPtr pvArg);

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

		/// <summary>Flags for <see cref="CertCloseStore"/>.</summary>
		[Flags]
		public enum CertCloseStoreFlags
		{
			/// <summary>
			/// Forces the freeing of memory for all contexts associated with the store. This flag can be safely used only when the store is
			/// opened in a function and neither the store handle nor any of its contexts are passed to any called functions. For details,
			/// see Remarks.
			/// </summary>
			CERT_CLOSE_STORE_FORCE_FLAG = 0x00000001,

			/// <summary>
			/// Checks for nonfreed certificate, CRL, and CTL contexts. A returned error code indicates that one or more store elements is
			/// still in use. This flag should only be used as a diagnostic tool in the development of applications.
			/// </summary>
			CERT_CLOSE_STORE_CHECK_FLAG = 0x00000002
		}

		public enum CertCompareFunction : ushort
		{
			CERT_COMPARE_ANY = 0,
			CERT_COMPARE_SHA1_HASH = 1,
			CERT_COMPARE_NAME = 2,
			CERT_COMPARE_ATTR = 3,
			CERT_COMPARE_MD5_HASH = 4,
			CERT_COMPARE_PROPERTY = 5,
			CERT_COMPARE_PUBLIC_KEY = 6,
			CERT_COMPARE_HASH = CERT_COMPARE_SHA1_HASH,
			CERT_COMPARE_NAME_STR_A = 7,
			CERT_COMPARE_NAME_STR_W = 8,
			CERT_COMPARE_KEY_SPEC = 9,
			CERT_COMPARE_ENHKEY_USAGE = 10,
			CERT_COMPARE_CTL_USAGE = CERT_COMPARE_ENHKEY_USAGE,
			CERT_COMPARE_SUBJECT_CERT = 11,
			CERT_COMPARE_ISSUER_OF = 12,
			CERT_COMPARE_EXISTING = 13,
			CERT_COMPARE_SIGNATURE_HASH = 14,
			CERT_COMPARE_KEY_IDENTIFIER = 15,
			CERT_COMPARE_CERT_ID = 16,
			CERT_COMPARE_CROSS_CERT_DIST_POINTS = 17,
			CERT_COMPARE_PUBKEY_MD5_HASH = 18,
			CERT_COMPARE_SUBJECT_INFO_ACCESS = 19,
			CERT_COMPARE_HASH_STR = 20,
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
			PKCS_7_NDR_ENCODING = 0x00020000
		}

		[PInvokeData("wincrypt.h", MSDNShortId = "20b3fcfb-55df-46ff-80a5-70f31a3d03b2")]
		public enum CertFindType : uint
		{
			CERT_FIND_ANY = (uint)CertCompareFunction.CERT_COMPARE_ANY << CERT_COMPARE_SHIFT,

			[CorrespondingType(typeof(CRYPTOAPI_BLOB))]
			CERT_FIND_SHA1_HASH = (uint)CertCompareFunction.CERT_COMPARE_SHA1_HASH << CERT_COMPARE_SHIFT,

			[CorrespondingType(typeof(CRYPTOAPI_BLOB))]
			CERT_FIND_MD5_HASH = (uint)CertCompareFunction.CERT_COMPARE_MD5_HASH << CERT_COMPARE_SHIFT,

			[CorrespondingType(typeof(CRYPTOAPI_BLOB))]
			CERT_FIND_SIGNATURE_HASH = (uint)CertCompareFunction.CERT_COMPARE_SIGNATURE_HASH << CERT_COMPARE_SHIFT,

			[CorrespondingType(typeof(CRYPTOAPI_BLOB))]
			CERT_FIND_KEY_IDENTIFIER = (uint)CertCompareFunction.CERT_COMPARE_KEY_IDENTIFIER << CERT_COMPARE_SHIFT,

			[CorrespondingType(typeof(CRYPTOAPI_BLOB))]
			CERT_FIND_HASH = CERT_FIND_SHA1_HASH,

			[CorrespondingType(typeof(uint))]
			CERT_FIND_PROPERTY = (uint)CertCompareFunction.CERT_COMPARE_PROPERTY << CERT_COMPARE_SHIFT,

			[CorrespondingType(typeof(CERT_PUBLIC_KEY_INFO))]
			CERT_FIND_PUBLIC_KEY = (uint)CertCompareFunction.CERT_COMPARE_PUBLIC_KEY << CERT_COMPARE_SHIFT,

			[CorrespondingType(typeof(CRYPTOAPI_BLOB))]
			CERT_FIND_SUBJECT_NAME = (uint)CertCompareFunction.CERT_COMPARE_NAME << CERT_COMPARE_SHIFT | CertInfoFlags.CERT_INFO_SUBJECT_FLAG,

			[CorrespondingType(typeof(CERT_RDN))]
			CERT_FIND_SUBJECT_ATTR = (uint)CertCompareFunction.CERT_COMPARE_ATTR << CERT_COMPARE_SHIFT | CertInfoFlags.CERT_INFO_SUBJECT_FLAG,

			[CorrespondingType(typeof(CRYPTOAPI_BLOB))]
			CERT_FIND_ISSUER_NAME = (uint)CertCompareFunction.CERT_COMPARE_NAME << CERT_COMPARE_SHIFT | CertInfoFlags.CERT_INFO_ISSUER_FLAG,

			[CorrespondingType(typeof(CERT_RDN))]
			CERT_FIND_ISSUER_ATTR = (uint)CertCompareFunction.CERT_COMPARE_ATTR << CERT_COMPARE_SHIFT | CertInfoFlags.CERT_INFO_ISSUER_FLAG,

			[CorrespondingType(typeof(string))]
			CERT_FIND_SUBJECT_STR_A = (uint)CertCompareFunction.CERT_COMPARE_NAME_STR_A << CERT_COMPARE_SHIFT | CertInfoFlags.CERT_INFO_SUBJECT_FLAG,

			[CorrespondingType(typeof(string))]
			CERT_FIND_SUBJECT_STR_W = (uint)CertCompareFunction.CERT_COMPARE_NAME_STR_W << CERT_COMPARE_SHIFT | CertInfoFlags.CERT_INFO_SUBJECT_FLAG,

			[CorrespondingType(typeof(string))]
			CERT_FIND_SUBJECT_STR = CERT_FIND_SUBJECT_STR_W,

			[CorrespondingType(typeof(string))]
			CERT_FIND_ISSUER_STR_A = (uint)CertCompareFunction.CERT_COMPARE_NAME_STR_A << CERT_COMPARE_SHIFT | CertInfoFlags.CERT_INFO_ISSUER_FLAG,

			[CorrespondingType(typeof(string))]
			CERT_FIND_ISSUER_STR_W = (uint)CertCompareFunction.CERT_COMPARE_NAME_STR_W << CERT_COMPARE_SHIFT | CertInfoFlags.CERT_INFO_ISSUER_FLAG,

			[CorrespondingType(typeof(string))]
			CERT_FIND_ISSUER_STR = CERT_FIND_ISSUER_STR_W,

			[CorrespondingType(typeof(uint))]
			CERT_FIND_KEY_SPEC = (uint)CertCompareFunction.CERT_COMPARE_KEY_SPEC << CERT_COMPARE_SHIFT,

			[CorrespondingType(typeof(CTL_USAGE))]
			CERT_FIND_ENHKEY_USAGE = (uint)CertCompareFunction.CERT_COMPARE_ENHKEY_USAGE << CERT_COMPARE_SHIFT,

			[CorrespondingType(typeof(CTL_USAGE))]
			CERT_FIND_CTL_USAGE = CERT_FIND_ENHKEY_USAGE,

			[CorrespondingType(typeof(CERT_INFO))]
			CERT_FIND_SUBJECT_CERT = (uint)CertCompareFunction.CERT_COMPARE_SUBJECT_CERT << CERT_COMPARE_SHIFT,

			[CorrespondingType(typeof(CERT_CONTEXT))]
			CERT_FIND_ISSUER_OF = (uint)CertCompareFunction.CERT_COMPARE_ISSUER_OF << CERT_COMPARE_SHIFT,

			[CorrespondingType(typeof(CERT_CONTEXT))]
			CERT_FIND_EXISTING = (uint)CertCompareFunction.CERT_COMPARE_EXISTING << CERT_COMPARE_SHIFT,

			[CorrespondingType(typeof(CERT_ID))]
			CERT_FIND_CERT_ID = (uint)CertCompareFunction.CERT_COMPARE_CERT_ID << CERT_COMPARE_SHIFT,

			CERT_FIND_CROSS_CERT_DIST_POINTS = (uint)CertCompareFunction.CERT_COMPARE_CROSS_CERT_DIST_POINTS << CERT_COMPARE_SHIFT,

			CERT_FIND_PUBKEY_MD5_HASH = (uint)CertCompareFunction.CERT_COMPARE_PUBKEY_MD5_HASH << CERT_COMPARE_SHIFT,

			CERT_FIND_SUBJECT_INFO_ACCESS = (uint)CertCompareFunction.CERT_COMPARE_SUBJECT_INFO_ACCESS << CERT_COMPARE_SHIFT,

			CERT_FIND_HASH_STR = (uint)CertCompareFunction.CERT_COMPARE_HASH_STR << CERT_COMPARE_SHIFT,

			CERT_FIND_HAS_PRIVATE_KEY = (uint)CertCompareFunction.CERT_COMPARE_HAS_PRIVATE_KEY << CERT_COMPARE_SHIFT
		}

		public enum CertInfoFlags : uint
		{
			CERT_INFO_VERSION_FLAG = 1,
			CERT_INFO_SERIAL_NUMBER_FLAG = 2,
			CERT_INFO_SIGNATURE_ALGORITHM_FLAG = 3,
			CERT_INFO_ISSUER_FLAG = 4,
			CERT_INFO_NOT_BEFORE_FLAG = 5,
			CERT_INFO_NOT_AFTER_FLAG = 6,
			CERT_INFO_SUBJECT_FLAG = 7,
			CERT_INFO_SUBJECT_PUBLIC_KEY_INFO_FLAG = 8,
			CERT_INFO_ISSUER_UNIQUE_ID_FLAG = 9,
			CERT_INFO_SUBJECT_UNIQUE_ID_FLAG = 10,
			CERT_INFO_EXTENSION_FLAG = 11,
		}

		[PInvokeData("wincrypt.h", MSDNShortId = "fd9cb23b-e4a3-41cb-8f0a-30f4e813c6ac")]
		public enum CertSystemStore : uint
		{
			CERT_SYSTEM_STORE_CURRENT_USER = CertSystemStoreId.CERT_SYSTEM_STORE_CURRENT_USER_ID << CERT_SYSTEM_STORE_LOCATION_SHIFT,
			CERT_SYSTEM_STORE_LOCAL_MACHINE = CertSystemStoreId.CERT_SYSTEM_STORE_LOCAL_MACHINE_ID << CERT_SYSTEM_STORE_LOCATION_SHIFT,
			CERT_SYSTEM_STORE_CURRENT_SERVICE = CertSystemStoreId.CERT_SYSTEM_STORE_CURRENT_SERVICE_ID << CERT_SYSTEM_STORE_LOCATION_SHIFT,
			CERT_SYSTEM_STORE_SERVICES = CertSystemStoreId.CERT_SYSTEM_STORE_SERVICES_ID << CERT_SYSTEM_STORE_LOCATION_SHIFT,
			CERT_SYSTEM_STORE_USERS = CertSystemStoreId.CERT_SYSTEM_STORE_USERS_ID << CERT_SYSTEM_STORE_LOCATION_SHIFT,
			CERT_SYSTEM_STORE_CURRENT_USER_GROUP_POLICY = CertSystemStoreId.CERT_SYSTEM_STORE_CURRENT_USER_GROUP_POLICY_ID << CERT_SYSTEM_STORE_LOCATION_SHIFT,
			CERT_SYSTEM_STORE_LOCAL_MACHINE_GROUP_POLICY = CertSystemStoreId.CERT_SYSTEM_STORE_LOCAL_MACHINE_GROUP_POLICY_ID << CERT_SYSTEM_STORE_LOCATION_SHIFT,
			CERT_SYSTEM_STORE_LOCAL_MACHINE_ENTERPRISE = CertSystemStoreId.CERT_SYSTEM_STORE_LOCAL_MACHINE_ENTERPRISE_ID << CERT_SYSTEM_STORE_LOCATION_SHIFT,
			CERT_SYSTEM_STORE_LOCAL_MACHINE_WCOS = CertSystemStoreId.CERT_SYSTEM_STORE_LOCAL_MACHINE_WCOS_ID << CERT_SYSTEM_STORE_LOCATION_SHIFT,
		}

		public enum CertSystemStoreId : uint
		{
			CERT_SYSTEM_STORE_CURRENT_USER_ID = 1,
			CERT_SYSTEM_STORE_LOCAL_MACHINE_ID = 2,
			CERT_SYSTEM_STORE_CURRENT_SERVICE_ID = 4,
			CERT_SYSTEM_STORE_SERVICES_ID = 5,
			CERT_SYSTEM_STORE_USERS_ID = 6,
			CERT_SYSTEM_STORE_CURRENT_USER_GROUP_POLICY_ID = 7,
			CERT_SYSTEM_STORE_LOCAL_MACHINE_GROUP_POLICY_ID = 8,
			CERT_SYSTEM_STORE_LOCAL_MACHINE_ENTERPRISE_ID = 9,
			CERT_SYSTEM_STORE_LOCAL_MACHINE_WCOS_ID = 10,
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
		/// The <c>CertCloseStore</c> function closes a certificate store handle and reduces the reference count on the store. There needs to
		/// be a corresponding call to <c>CertCloseStore</c> for each successful call to the CertOpenStore or CertDuplicateStore functions.
		/// </summary>
		/// <param name="hCertStore">Handle of the certificate store to be closed.</param>
		/// <param name="dwFlags">
		/// <para>
		/// Typically, this parameter uses the default value zero. The default is to close the store with memory remaining allocated for
		/// contexts that have not been freed. In this case, no check is made to determine whether memory for contexts remains allocated.
		/// </para>
		/// <para>
		/// Set flags can force the freeing of memory for all of a store's certificate, certificate revocation list (CRL), and certificate
		/// trust list (CTL) contexts when the store is closed. Flags can also be set that check whether all of the store's certificate, CRL,
		/// and CTL contexts have been freed. The following values are defined.
		/// </para>
		/// <list type="table">
		/// <listheader>
		/// <term>Value</term>
		/// <term>Meaning</term>
		/// </listheader>
		/// <item>
		/// <term>CERT_CLOSE_STORE_CHECK_FLAG</term>
		/// <term>
		/// Checks for nonfreed certificate, CRL, and CTL contexts. A returned error code indicates that one or more store elements is still
		/// in use. This flag should only be used as a diagnostic tool in the development of applications.
		/// </term>
		/// </item>
		/// <item>
		/// <term>CERT_CLOSE_STORE_FORCE_FLAG</term>
		/// <term>
		/// Forces the freeing of memory for all contexts associated with the store. This flag can be safely used only when the store is
		/// opened in a function and neither the store handle nor any of its contexts are passed to any called functions. For details, see Remarks.
		/// </term>
		/// </item>
		/// </list>
		/// </param>
		/// <returns>
		/// <para>If the function succeeds, the return value is <c>TRUE</c>.</para>
		/// <para>If the function fails, the return value is <c>FALSE</c>. For extended error information, call GetLastError.</para>
		/// <para>
		/// If CERT_CLOSE_STORE_CHECK_FLAG is not set or if it is set and all contexts associated with the store have been freed, the return
		/// value is <c>TRUE</c>.
		/// </para>
		/// <para>
		/// If CERT_CLOSE_STORE_CHECK_FLAG is set and memory for one or more contexts associated with the store remains allocated, the return
		/// value is <c>FALSE</c>. The store is always closed even when the function returns <c>FALSE</c>. For details, see Remarks.
		/// </para>
		/// <para>
		/// GetLastError is set to CRYPT_E_PENDING_CLOSE if memory for contexts associated with the store remains allocated. Any existing
		/// value returned by <c>GetLastError</c> is preserved unless CERT_CLOSE_STORE_CHECK_FLAG is set.
		/// </para>
		/// </returns>
		/// <remarks>
		/// <para>
		/// While a certificate store is open, contexts from that store can be retrieved or duplicated. When a context is retrieved or
		/// duplicated, its reference count is incremented. When a context is freed by passing it to a search or enumeration function as a
		/// previous context or by using CertFreeCertificateContext, CertFreeCRLContext, or CertFreeCTLContext, its reference count is
		/// decremented. When a context's reference count reaches zero, memory allocated for that context is automatically freed. When the
		/// memory allocated for a context has been freed, any pointers to that context become not valid.
		/// </para>
		/// <para>
		/// By default, memory used to store contexts with reference count greater than zero is not freed when a certificate store is closed.
		/// References to those contexts remain valid; however, this can cause memory leaks. Also, any changes made to the properties of a
		/// context after the store has been closed are not persisted.
		/// </para>
		/// <para>
		/// To force the freeing of memory for all contexts associated with a store, set CERT_CLOSE_STORE_FORCE_FLAG. With this flag set,
		/// memory for all contexts associated with the store is freed and all pointers to certificate, CRL, or CTL contexts associated with
		/// the store become not valid. This flag should only be set when the store is opened in a function and neither the store handle nor
		/// any of its contexts were ever passed to any called functions.
		/// </para>
		/// <para>
		/// The status of reference counts on contexts associated with a store can be checked when the store is closed by using
		/// CERT_CLOSE_STORE_CHECK_FLAG. When this flag is set, and all certificate, CRL, or CTL contexts have not been released, the
		/// function returns <c>FALSE</c> and GetLastError returns CRYPT_E_PENDING_CLOSE. Note that the store is still closed when
		/// <c>FALSE</c> is returned and the memory for any active contexts is not freed.
		/// </para>
		/// <para>If CERT_STORE_NO_CRYPT_RELEASE_FLAG was not set when the store was opened, closing a store releases its CSP handle.</para>
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows/win32/api/wincrypt/nf-wincrypt-certclosestore BOOL CertCloseStore( HCERTSTORE hCertStore,
		// DWORD dwFlags );
		[DllImport(Lib.Crypt32, SetLastError = true, ExactSpelling = true)]
		[PInvokeData("wincrypt.h", MSDNShortId = "a93fdd65-359e-4046-910d-347c3af01280")]
		[return: MarshalAs(UnmanagedType.Bool)]
		public static extern bool CertCloseStore(HCERTSTORE hCertStore, CertCloseStoreFlags dwFlags);

		/// <summary>
		/// The <c>CertEnumSystemStore</c> function retrieves the system stores available. The function calls the provided callback function
		/// for each system store found.
		/// </summary>
		/// <param name="dwFlags">
		/// <para>Specifies the location of the system store. This parameter can be one of the following flags:</para>
		/// <list type="bullet">
		/// <item>
		/// <term>CERT_SYSTEM_STORE_CURRENT_USER</term>
		/// </item>
		/// <item>
		/// <term>CERT_SYSTEM_STORE_CURRENT_SERVICE</term>
		/// </item>
		/// <item>
		/// <term>CERT_SYSTEM_STORE_LOCAL_MACHINE</term>
		/// </item>
		/// <item>
		/// <term>CERT_SYSTEM_STORE_LOCAL_MACHINE_GROUP_POLICY</term>
		/// </item>
		/// <item>
		/// <term>CERT_SYSTEM_STORE_CURRENT_USER_GROUP_POLICY</term>
		/// </item>
		/// <item>
		/// <term>CERT_SYSTEM_STORE_SERVICES</term>
		/// </item>
		/// <item>
		/// <term>CERT_SYSTEM_STORE_USERS</term>
		/// </item>
		/// <item>
		/// <term>CERT_SYSTEM_STORE_LOCAL_MACHINE_ENTERPRISE</term>
		/// </item>
		/// </list>
		/// <para>In addition, the CERT_SYSTEM_STORE_RELOCATE_FLAG can be combined, by using a bitwise-</para>
		/// <para>OR</para>
		/// <para>operation, with any of the high-word location flags.</para>
		/// </param>
		/// <param name="pvSystemStoreLocationPara">
		/// <para>
		/// If CERT_SYSTEM_STORE_RELOCATE_FLAG is set in the dwFlags parameter, pvSystemStoreLocationPara points to a
		/// CERT_SYSTEM_STORE_RELOCATE_PARA structure that indicates both the name and the location of the system store. Otherwise,
		/// pvSystemStoreLocationPara is a pointer to a Unicode string that names the system store.
		/// </para>
		/// <para>
		/// For CERT_SYSTEM_STORE_LOCAL_MACHINE or CERT_SYSTEM_STORE_LOCAL_MACHINE_GROUP_POLICY, pvSystemStoreLocationPara can optionally be
		/// set to a Unicode computer name for enumerating local computer stores on a remote computer, for example "\computer_name" or
		/// "computer_name". The leading backslashes (\) are optional in the computer_name.
		/// </para>
		/// <para>
		/// For CERT_SYSTEM_STORE_SERVICES or CERT_SYSTEM_STORE_USERS, if pvSystemStoreLocationPara is <c>NULL</c>, the function enumerates
		/// both the service/user names and the stores for each service/user name. Otherwise, pvSystemStoreLocationPara is a Unicode string
		/// that contains a remote computer name and, if available, a service/user name, for example, "service_name", "\computer_name", or "computer_name".
		/// </para>
		/// <para>
		/// If only the computer_name is specified, it must have either the leading backslashes (\) or a trailing backslash (). Otherwise, it
		/// is interpreted as the service_name or user_name.
		/// </para>
		/// </param>
		/// <param name="pvArg">
		/// A pointer to a <c>void</c> that allows the application to declare, define, and initialize a structure to hold any information to
		/// be passed to the callback enumeration function.
		/// </param>
		/// <param name="pfnEnum">
		/// A pointer to the callback function used to show the details for each system store. This callback function determines the content
		/// and format for the presentation of information on each system store. The application must provide the CertEnumSystemStoreCallback
		/// callback function.
		/// </param>
		/// <returns>
		/// <para>If the function succeeds, the function returns <c>TRUE</c>.</para>
		/// <para>If the function fails, it returns <c>FALSE</c>.</para>
		/// </returns>
		/// <remarks>
		/// <para>
		/// To use <c>CertEnumSystemStore</c>, the application must declare and define the <c>ENUM_ARG</c> structure and the
		/// CertEnumSystemStoreCallback callback function.
		/// </para>
		/// <para>Examples</para>
		/// <para>For an example that uses this function, see Example C Program: Listing System and Physical Stores.</para>
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows/win32/api/wincrypt/nf-wincrypt-certenumsystemstore BOOL CertEnumSystemStore( DWORD
		// dwFlags, void *pvSystemStoreLocationPara, void *pvArg, PFN_CERT_ENUM_SYSTEM_STORE pfnEnum );
		[DllImport(Lib.Crypt32, SetLastError = false, ExactSpelling = true)]
		[PInvokeData("wincrypt.h", MSDNShortId = "fd9cb23b-e4a3-41cb-8f0a-30f4e813c6ac")]
		[return: MarshalAs(UnmanagedType.Bool)]
		public static extern bool CertEnumSystemStore(CertSystemStore dwFlags, IntPtr pvSystemStoreLocationPara, IntPtr pvArg, CertEnumSystemStoreCallback pfnEnum);

		/// <summary>
		/// The <c>CertEnumSystemStore</c> function retrieves the system stores available. The function calls the provided callback function
		/// for each system store found.
		/// </summary>
		/// <param name="dwFlags">
		/// <para>Specifies the location of the system store. This parameter can be one of the following flags:</para>
		/// <list type="bullet">
		/// <item>
		/// <term>CERT_SYSTEM_STORE_CURRENT_USER</term>
		/// </item>
		/// <item>
		/// <term>CERT_SYSTEM_STORE_CURRENT_SERVICE</term>
		/// </item>
		/// <item>
		/// <term>CERT_SYSTEM_STORE_LOCAL_MACHINE</term>
		/// </item>
		/// <item>
		/// <term>CERT_SYSTEM_STORE_LOCAL_MACHINE_GROUP_POLICY</term>
		/// </item>
		/// <item>
		/// <term>CERT_SYSTEM_STORE_CURRENT_USER_GROUP_POLICY</term>
		/// </item>
		/// <item>
		/// <term>CERT_SYSTEM_STORE_SERVICES</term>
		/// </item>
		/// <item>
		/// <term>CERT_SYSTEM_STORE_USERS</term>
		/// </item>
		/// <item>
		/// <term>CERT_SYSTEM_STORE_LOCAL_MACHINE_ENTERPRISE</term>
		/// </item>
		/// </list>
		/// <para>In addition, the CERT_SYSTEM_STORE_RELOCATE_FLAG can be combined, by using a bitwise-</para>
		/// <para>OR</para>
		/// <para>operation, with any of the high-word location flags.</para>
		/// </param>
		/// <param name="pvSystemStoreLocationPara">
		/// <para>
		/// If CERT_SYSTEM_STORE_RELOCATE_FLAG is set in the dwFlags parameter, pvSystemStoreLocationPara points to a
		/// CERT_SYSTEM_STORE_RELOCATE_PARA structure that indicates both the name and the location of the system store. Otherwise,
		/// pvSystemStoreLocationPara is a pointer to a Unicode string that names the system store.
		/// </para>
		/// <para>
		/// For CERT_SYSTEM_STORE_LOCAL_MACHINE or CERT_SYSTEM_STORE_LOCAL_MACHINE_GROUP_POLICY, pvSystemStoreLocationPara can optionally be
		/// set to a Unicode computer name for enumerating local computer stores on a remote computer, for example "\computer_name" or
		/// "computer_name". The leading backslashes (\) are optional in the computer_name.
		/// </para>
		/// <para>
		/// For CERT_SYSTEM_STORE_SERVICES or CERT_SYSTEM_STORE_USERS, if pvSystemStoreLocationPara is <c>NULL</c>, the function enumerates
		/// both the service/user names and the stores for each service/user name. Otherwise, pvSystemStoreLocationPara is a Unicode string
		/// that contains a remote computer name and, if available, a service/user name, for example, "service_name", "\computer_name", or "computer_name".
		/// </para>
		/// <para>
		/// If only the computer_name is specified, it must have either the leading backslashes (\) or a trailing backslash (). Otherwise, it
		/// is interpreted as the service_name or user_name.
		/// </para>
		/// </param>
		/// <param name="pvArg">
		/// A pointer to a <c>void</c> that allows the application to declare, define, and initialize a structure to hold any information to
		/// be passed to the callback enumeration function.
		/// </param>
		/// <param name="pfnEnum">
		/// A pointer to the callback function used to show the details for each system store. This callback function determines the content
		/// and format for the presentation of information on each system store. The application must provide the CertEnumSystemStoreCallback
		/// callback function.
		/// </param>
		/// <returns>
		/// <para>If the function succeeds, the function returns <c>TRUE</c>.</para>
		/// <para>If the function fails, it returns <c>FALSE</c>.</para>
		/// </returns>
		/// <remarks>
		/// <para>
		/// To use <c>CertEnumSystemStore</c>, the application must declare and define the <c>ENUM_ARG</c> structure and the
		/// CertEnumSystemStoreCallback callback function.
		/// </para>
		/// <para>Examples</para>
		/// <para>For an example that uses this function, see Example C Program: Listing System and Physical Stores.</para>
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows/win32/api/wincrypt/nf-wincrypt-certenumsystemstore BOOL CertEnumSystemStore( DWORD
		// dwFlags, void *pvSystemStoreLocationPara, void *pvArg, PFN_CERT_ENUM_SYSTEM_STORE pfnEnum );
		[DllImport(Lib.Crypt32, SetLastError = false, ExactSpelling = true)]
		[PInvokeData("wincrypt.h", MSDNShortId = "fd9cb23b-e4a3-41cb-8f0a-30f4e813c6ac")]
		[return: MarshalAs(UnmanagedType.Bool)]
		public static extern bool CertEnumSystemStore(CertSystemStore dwFlags, [MarshalAs(UnmanagedType.LPWStr)] string pvSystemStoreLocationPara, IntPtr pvArg, CertEnumSystemStoreCallback pfnEnum);

		/// <summary>
		/// The <c>CertFindCertificateInStore</c> function finds the first or next certificate context in a certificate store that matches a
		/// search criteria established by the dwFindType and its associated pvFindPara. This function can be used in a loop to find all of
		/// the certificates in a certificate store that match the specified find criteria.
		/// </summary>
		/// <param name="hCertStore">A handle of the certificate store to be searched.</param>
		/// <param name="dwCertEncodingType">
		/// <para>
		/// Specifies the type of encoding used. Both the certificate and message encoding types must be specified by combining them with a
		/// bitwise- <c>OR</c> operation as shown in the following example:
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
		/// <param name="dwFindFlags">
		/// Used with some dwFindType values to modify the search criteria. For most dwFindType values, dwFindFlags is not used and should be
		/// set to zero. For detailed information, see Remarks.
		/// </param>
		/// <param name="dwFindType">
		/// <para>
		/// Specifies the type of search being made. The search type determines the data type, contents, and the use of pvFindPara. This
		/// parameter can be one of the following values.
		/// </para>
		/// <list type="table">
		/// <listheader>
		/// <term>Value</term>
		/// <term>Meaning</term>
		/// </listheader>
		/// <item>
		/// <term>CERT_FIND_ANY</term>
		/// <term>Data type of pvFindPara: NULL, not used. No search criteria used. Returns the next certificate in the store.</term>
		/// </item>
		/// <item>
		/// <term>CERT_FIND_CERT_ID</term>
		/// <term>Data type of pvFindPara: CERT_ID structure. Find the certificate identified by the specified CERT_ID.</term>
		/// </item>
		/// <item>
		/// <term>CERT_FIND_CTL_USAGE</term>
		/// <term>
		/// Data type of pvFindPara: CTL_USAGE structure. Searches for a certificate that has a szOID_ENHANCED_KEY_USAGE extension or a
		/// CERT_CTL_PROP_ID that matches the pszUsageIdentifier member of the CTL_USAGE structure.
		/// </term>
		/// </item>
		/// <item>
		/// <term>CERT_FIND_ENHKEY_USAGE</term>
		/// <term>
		/// Data type of pvFindPara: CERT_ENHKEY_USAGE structure. Searches for a certificate in the store that has either an enhanced key
		/// usage extension or an enhanced key usage property and a usage identifier that matches the cUsageIdentifier member in the
		/// CERT_ENHKEY_USAGE structure. A certificate has an enhanced key usage extension if it has a CERT_EXTENSION structure with the
		/// pszObjId member set to szOID_ENHANCED_KEY_USAGE. A certificate has an enhanced key usage property if its
		/// CERT_ENHKEY_USAGE_PROP_ID identifier is set. If CERT_FIND_OPTIONAL_ENHKEY_USAGE_FLAG is set in dwFindFlags, certificates without
		/// the key usage extension or property are also matches. Setting this flag takes precedence over passing NULL in pvFindPara. If
		/// CERT_FIND_EXT_ONLY_ENHKEY_USAGE_FLAG is set, a match is done only on the key usage extension. For information about flag
		/// modifications to search criteria, see Remarks.
		/// </term>
		/// </item>
		/// <item>
		/// <term>CERT_FIND_EXISTING</term>
		/// <term>
		/// Data type of pvFindPara: CERT_CONTEXT structure. Searches for a certificate that is an exact match of the specified certificate context.
		/// </term>
		/// </item>
		/// <item>
		/// <term>CERT_FIND_HASH</term>
		/// <term>
		/// Data type of pvFindPara: CRYPT_HASH_BLOB structure. Searches for a certificate with a SHA1 hash that matches the hash in the
		/// CRYPT_HASH_BLOB structure.
		/// </term>
		/// </item>
		/// <item>
		/// <term>CERT_FIND_HAS_PRIVATE_KEY</term>
		/// <term>
		/// Data type of pvFindPara: NULL, not used. Searches for a certificate that has a private key. The key can be ephemeral or saved on
		/// disk. The key can be a legacy Cryptography API (CAPI) key or a CNG key. Windows 8 and Windows Server 2012: Support for this flag begins.
		/// </term>
		/// </item>
		/// <item>
		/// <term>CERT_FIND_ISSUER_ATTR</term>
		/// <term>
		/// Data type of pvFindPara: CERT_RDN structure. Searches for a certificate with specified issuer attributes that match attributes in
		/// the CERT_RDN structure. If these values are set, the function compares attributes of the issuer in a certificate with elements of
		/// the CERT_RDN_ATTR array in this CERT_RDN structure. Comparisons iterate through the CERT_RDN_ATTR attributes looking for a match
		/// with the certificate's issuer attributes. If the pszObjId member of CERT_RDN_ATTR is NULL, the attribute object identifier is
		/// ignored. If the dwValueType member of CERT_RDN_ATTR is CERT_RDN_ANY_TYPE, the value type is ignored. If the pbData member of
		/// CERT_RDN_VALUE_BLOB is NULL, any value is a match. Currently only an exact, case-sensitive match is supported. For information
		/// about Unicode options, see Remarks. When these values are set, the search is restricted to certificates whose encoding type
		/// matches dwCertEncodingType.
		/// </term>
		/// </item>
		/// <item>
		/// <term>CERT_FIND_ISSUER_NAME</term>
		/// <term>
		/// Data type of pvFindPara: CERT_NAME_BLOB structure. Search for a certificate with an exact match of the entire issuer name with
		/// the name in CERT_NAME_BLOB The search is restricted to certificates that match the dwCertEncodingType.
		/// </term>
		/// </item>
		/// <item>
		/// <term>CERT_FIND_ISSUER_OF</term>
		/// <term>
		/// Data type of pvFindPara: CERT_CONTEXT structure. Searches for a certificate with an subject that matches the issuer in
		/// CERT_CONTEXT. Instead of using CertFindCertificateInStore with this value, use the CertGetCertificateChain function.
		/// </term>
		/// </item>
		/// <item>
		/// <term>CERT_FIND_ISSUER_STR</term>
		/// <term>
		/// Data type of pvFindPara: Null-terminated Unicode string. Searches for a certificate that contains the specified issuer name
		/// string. The certificate's issuer member is converted to a name string of the appropriate type using the appropriate form of
		/// CertNameToStr formatted as CERT_SIMPLE_NAME_STR. Then a case-insensitive substring-within-a-string match is performed. When this
		/// value is set, the search is restricted to certificates whose encoding type matches dwCertEncodingType. If the substring match
		/// fails and the subject contains an email RDN with Punycode encoded string, CERT_NAME_STR_ENABLE_PUNYCODE_FLAG is used to convert
		/// the subject to a Unicode string and the substring match is performed again.
		/// </term>
		/// </item>
		/// <item>
		/// <term>CERT_FIND_KEY_IDENTIFIER</term>
		/// <term>
		/// Data type of pvFindPara: CRYPT_HASH_BLOB structure. Searches for a certificate with a CERT_KEY_IDENTIFIER_PROP_ID property that
		/// matches the key identifier in CRYPT_HASH_BLOB.
		/// </term>
		/// </item>
		/// <item>
		/// <term>CERT_FIND_KEY_SPEC</term>
		/// <term>
		/// Data type of pvFindPara: DWORD variable that contains a key specification. Searches for a certificate that has a
		/// CERT_KEY_SPEC_PROP_ID property that matches the key specification in pvFindPara.
		/// </term>
		/// </item>
		/// <item>
		/// <term>CERT_FIND_MD5_HASH</term>
		/// <term>
		/// Data type of pvFindPara: CRYPT_HASH_BLOB structure. Searches for a certificate with an MD5 hash that matches the hash in CRYPT_HASH_BLOB.
		/// </term>
		/// </item>
		/// <item>
		/// <term>CERT_FIND_PROPERTY</term>
		/// <term>
		/// Data type of pvFindPara: DWORD variable that contains a property identifier. Searches for a certificate with a property that
		/// matches the property identifier specified by the DWORD value in pvFindPara.
		/// </term>
		/// </item>
		/// <item>
		/// <term>CERT_FIND_PUBLIC_KEY</term>
		/// <term>
		/// Data type of pvFindPara: CERT_PUBLIC_KEY_INFO structure. Searches for a certificate with a public key that matches the public key
		/// in the CERT_PUBLIC_KEY_INFO structure.
		/// </term>
		/// </item>
		/// <item>
		/// <term>CERT_FIND_SHA1_HASH</term>
		/// <term>
		/// Data type of pvFindPara: CRYPT_HASH_BLOB structure. Searches for a certificate with a SHA1 hash that matches the hash in the
		/// CRYPT_HASH_BLOB structure.
		/// </term>
		/// </item>
		/// <item>
		/// <term>CERT_FIND_SIGNATURE_HASH</term>
		/// <term>
		/// Data type of pvFindPara: CRYPT_HASH_BLOB structure. Searches for a certificate with a signature hash that matches the signature
		/// hash in the CRYPT_HASH_BLOB structure.
		/// </term>
		/// </item>
		/// <item>
		/// <term>CERT_FIND_SUBJECT_ATTR</term>
		/// <term>
		/// Data type of pvFindPara: CERT_RDN structure. Searches for a certificate with specified subject attributes that match attributes
		/// in the CERT_RDN structure. If RDN values are set, the function compares attributes of the subject in a certificate with elements
		/// of the CERT_RDN_ATTR array in this CERT_RDN structure. Comparisons iterate through the CERT_RDN_ATTR attributes looking for a
		/// match with the certificate's subject's attributes. If the pszObjId member of CERT_RDN_ATTR is NULL, the attribute object
		/// identifier is ignored. If the dwValueType member of CERT_RDN_ATTR is CERT_RDN_ANY_TYPE, the value type is ignored. If the pbData
		/// member of CERT_RDN_VALUE_BLOB is NULL, any value is a match. Currently only an exact, case-sensitive match is supported. For
		/// information about Unicode options, see Remarks. When these values are set, the search is restricted to certificates whose
		/// encoding type matches dwCertEncodingType.
		/// </term>
		/// </item>
		/// <item>
		/// <term>CERT_FIND_SUBJECT_CERT</term>
		/// <term>
		/// Data type of pvFindPara: CERT_INFO structure. Searches for a certificate with both an issuer and a serial number that match the
		/// issuer and serial number in the CERT_INFO structure.
		/// </term>
		/// </item>
		/// <item>
		/// <term>CERT_FIND_SUBJECT_NAME</term>
		/// <term>
		/// Data type of pvFindPara: CERT_NAME_BLOB structure. Searches for a certificate with an exact match of the entire subject name with
		/// the name in the CERT_NAME_BLOB structure. The search is restricted to certificates that match the value of dwCertEncodingType.
		/// </term>
		/// </item>
		/// <item>
		/// <term>CERT_FIND_SUBJECT_STR</term>
		/// <term>
		/// Data type of pvFindPara: Null-terminated Unicode string. Searches for a certificate that contains the specified subject name
		/// string. The certificate's subject member is converted to a name string of the appropriate type using the appropriate form of
		/// CertNameToStr formatted as CERT_SIMPLE_NAME_STR. Then a case-insensitive substring-within-a-string match is performed. When this
		/// value is set, the search is restricted to certificates whose encoding type matches dwCertEncodingType.
		/// </term>
		/// </item>
		/// <item>
		/// <term>CERT_FIND_CROSS_CERT_DIST_POINTS</term>
		/// <term>
		/// Data type of pvFindPara: Not used. Find a certificate that has either a cross certificate distribution point extension or property.
		/// </term>
		/// </item>
		/// <item>
		/// <term>CERT_FIND_PUBKEY_MD5_HASH</term>
		/// <term>
		/// Data type of pvFindPara: CRYPT_HASH_BLOB structure. Find a certificate whose MD5-hashed public key matches the specified hash.
		/// </term>
		/// </item>
		/// </list>
		/// <para>
		/// <c>Note</c> There are alternate forms of the value of dwFindType that pass a string in pvFindPara. One form uses a Unicode
		/// string, and the other an ASCII string. Values that end in "_W" or without a suffix use Unicode. Values that end with "_A" use
		/// ASCII strings.
		/// </para>
		/// </param>
		/// <param name="pvFindPara">Points to a data item or structure used with dwFindType.</param>
		/// <param name="pPrevCertContext">
		/// A pointer to the last CERT_CONTEXT structure returned by this function. This parameter must be <c>NULL</c> on the first call of
		/// the function. To find successive certificates meeting the search criteria, set pPrevCertContext to the pointer returned by the
		/// previous call to the function. This function frees the <c>CERT_CONTEXT</c> referenced by non- <c>NULL</c> values of this parameter.
		/// </param>
		/// <returns>
		/// <para>If the function succeeds, the function returns a pointer to a read-only CERT_CONTEXT structure.</para>
		/// <para>If the function fails and a certificate that matches the search criteria is not found, the return value is <c>NULL</c>.</para>
		/// <para>
		/// A non- <c>NULL</c> CERT_CONTEXT that <c>CertFindCertificateInStore</c> returns must be freed by CertFreeCertificateContext or by
		/// being passed as the pPrevCertContext parameter on a subsequent call to <c>CertFindCertificateInStore</c>.
		/// </para>
		/// <para>For extended error information, call GetLastError. Some possible error codes follow.</para>
		/// <list type="table">
		/// <listheader>
		/// <term>Return code</term>
		/// <term>Description</term>
		/// </listheader>
		/// <item>
		/// <term>CRYPT_E_NOT_FOUND</term>
		/// <term>
		/// No certificate was found matching the search criteria. This can happen if the store is empty or the end of the store's list is reached.
		/// </term>
		/// </item>
		/// <item>
		/// <term>E_INVALIDARG</term>
		/// <term>
		/// The handle in the hCertStore parameter is not the same as that in the certificate context pointed to by the pPrevCertContext
		/// parameter, or a value that is not valid was specified in the dwFindType parameter.
		/// </term>
		/// </item>
		/// </list>
		/// </returns>
		/// <remarks>
		/// <para>The dwFindFlags parameter is used to modify the criteria of some search types.</para>
		/// <para>
		/// The CERT_UNICODE_IS_RDN_ATTRS_FLAG dwFindFlags value is used only with the CERT_FIND_SUBJECT_ATTR and CERT_FIND_ISSUER_ATTR
		/// values for dwFindType. CERT_UNICODE_IS_RDN_ATTRS_FLAG must be set if the CERT_RDN_ATTR structure pointed to by pvFindPara was
		/// initialized with Unicode strings. Before any comparison is made, the string to be matched is converted by using X509_UNICODE_NAME
		/// to provide for Unicode comparisons.
		/// </para>
		/// <para>The following dwFindFlags values are used only with the CERT_FIND_ENKEY_USAGE value for dwFindType:</para>
		/// <para>
		/// CertDuplicateCertificateContext can be called to make a duplicate of the returned context. The returned context can be added to a
		/// different certificate store by using CertAddCertificateContextToStore, or a link to that certificate context can be added to a
		/// store that is not a collection store by using CertAddCertificateLinkToStore.
		/// </para>
		/// <para>
		/// The returned pointer is freed when passed as the pPrevCertContext parameter on a subsequent call to the function. Otherwise, the
		/// pointer must be explicitly freed by calling CertFreeCertificateContext. A pPrevCertContext that is not <c>NULL</c> is always
		/// freed by <c>CertFindCertificateInStore</c> using a call to <c>CertFreeCertificateContext</c>, even if there is an error in the function.
		/// </para>
		/// <para>Examples</para>
		/// <para>
		/// The following example shows finding a certificate context in the certificate store meeting a search criterion. For a complete
		/// example that includes the context for this example, see Example C Program: Certificate Store Operations.
		/// </para>
		/// <para>For another example that uses this function, see Example C Program: Collection and Sibling Certificate Store Operations.</para>
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows/win32/api/wincrypt/nf-wincrypt-certfindcertificateinstore PCCERT_CONTEXT
		// CertFindCertificateInStore( HCERTSTORE hCertStore, DWORD dwCertEncodingType, DWORD dwFindFlags, DWORD dwFindType, const void
		// *pvFindPara, PCCERT_CONTEXT pPrevCertContext );
		[DllImport(Lib.Crypt32, SetLastError = true, ExactSpelling = true)]
		[PInvokeData("wincrypt.h", MSDNShortId = "20b3fcfb-55df-46ff-80a5-70f31a3d03b2")]
		public static extern IntPtr CertFindCertificateInStore(HCERTSTORE hCertStore, CertEncodingType dwCertEncodingType, uint dwFindFlags, CertFindType dwFindType, IntPtr pvFindPara, IntPtr pPrevCertContext);

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
		public static extern bool CertFreeCertificateContext(IntPtr pCertContext);

		/// <summary>
		/// The <c>CertOpenSystemStore</c> function is a simplified function that opens the most common system certificate store. To open
		/// certificate stores with more complex requirements, such as file-based or memory-based stores, use CertOpenStore.
		/// </summary>
		/// <param name="hProv">
		/// <para>This parameter is not used and should be set to <c>NULL</c>.</para>
		/// <para>
		/// <c>Windows Server 2003 and Windows XP:</c> A handle of a cryptographic service provider (CSP). Set hProv to <c>NULL</c> to use
		/// the default CSP. If hProv is not <c>NULL</c>, it must be a CSP handle created by using the CryptAcquireContext function.This
		/// parameter's data type is <c>HCRYPTPROV</c>.
		/// </para>
		/// </param>
		/// <param name="szSubsystemProtocol">
		/// <para>
		/// A string that names a system store. If the system store name provided in this parameter is not the name of an existing system
		/// store, a new system store will be created and used. CertEnumSystemStore can be used to list the names of existing system stores.
		/// Some example system stores are listed in the following table.
		/// </para>
		/// <list type="table">
		/// <listheader>
		/// <term>Value</term>
		/// <term>Meaning</term>
		/// </listheader>
		/// <item>
		/// <term>CA</term>
		/// <term>Certification authority certificates.</term>
		/// </item>
		/// <item>
		/// <term>MY</term>
		/// <term>A certificate store that holds certificates with associated private keys.</term>
		/// </item>
		/// <item>
		/// <term>ROOT</term>
		/// <term>Root certificates.</term>
		/// </item>
		/// <item>
		/// <term>SPC</term>
		/// <term>Software Publisher Certificate.</term>
		/// </item>
		/// </list>
		/// </param>
		/// <returns>
		/// <para>If the function succeeds, the function returns a handle to the certificate store.</para>
		/// <para>If the function fails, it returns <c>NULL</c>. For extended error information, call GetLastError.</para>
		/// <para><c>Note</c> Errors from the called function CertOpenStore are propagated to this function.</para>
		/// </returns>
		/// <remarks>
		/// <para>Only current user certificates are accessible using this method, not the local machine store.</para>
		/// <para>After the system store is opened, all the standard certificate store functions can be used to manipulate the certificates.</para>
		/// <para>After use, the store should be closed by using CertCloseStore.</para>
		/// <para>For more information about the stores that are automatically migrated, see Certificate Store Migration.</para>
		/// <para>Examples</para>
		/// <para>
		/// The following example shows a simplified method for opening the most common system certificate stores. For another example that
		/// uses this function, see Example C Program: Certificate Store Operations.
		/// </para>
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows/win32/api/wincrypt/nf-wincrypt-certopensystemstorea HCERTSTORE CertOpenSystemStoreA(
		// HCRYPTPROV_LEGACY hProv, LPCSTR szSubsystemProtocol );
		[DllImport(Lib.Crypt32, SetLastError = true, CharSet = CharSet.Auto)]
		[PInvokeData("wincrypt.h", MSDNShortId = "23699439-1a6c-4907-93fa-651024856be7")]
		public static extern SafeHCERTSTORE CertOpenSystemStore([Optional] IntPtr hProv, string szSubsystemProtocol);

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
			public CertEncodingType dwCertEncodingType;

			/// <summary>A pointer to a buffer that contains the encoded certificate.</summary>
			public IntPtr pbCertEncoded;

			/// <summary>The size, in bytes, of the encoded certificate.</summary>
			public uint cbCertEncoded;

			/// <summary>The address of a CERT_INFO structure that contains the certificate information.</summary>
			public IntPtr pCertInfo;

			/// <summary>A handle to the certificate store that contains the certificate context.</summary>
			public HCERTSTORE hCertStore;
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
			/// A CRYPT_INTEGER_BLOB structure that contains the serial number of the certificate. The combination of the issuer name and the
			/// serial number is a unique identifier of a certificate.
			/// </summary>
			public CRYPTOAPI_BLOB SerialNumber;
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
			public uint dwInfoChoice;

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
		/// The <c>CERT_SYSTEM_STORE_INFO</c> structure contains information used by functions that work with system stores. Currently, no
		/// essential information is contained in this structure.
		/// </summary>
		/// <remarks>Currently, no system store information is persisted.</remarks>
		// https://docs.microsoft.com/en-us/windows/win32/api/wincrypt/ns-wincrypt-cert_system_store_info typedef struct
		// _CERT_SYSTEM_STORE_INFO { DWORD cbSize; } CERT_SYSTEM_STORE_INFO, *PCERT_SYSTEM_STORE_INFO;
		[PInvokeData("wincrypt.h", MSDNShortId = "9c17ebd9-423b-4063-bdc3-6be70ceb8623")]
		[StructLayout(LayoutKind.Sequential)]
		public struct CERT_SYSTEM_STORE_INFO
		{
			/// <summary>Size of this structure in bytes.</summary>
			public uint cbSize;
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

		/// <summary>Provides a handle to a certificate store.</summary>
		[StructLayout(LayoutKind.Sequential)]
		public struct HCERTSTORE : IHandle
		{
			private readonly IntPtr handle;

			/// <summary>Initializes a new instance of the <see cref="HCERTSTORE"/> struct.</summary>
			/// <param name="preexistingHandle">An <see cref="IntPtr"/> object that represents the pre-existing handle to use.</param>
			public HCERTSTORE(IntPtr preexistingHandle) => handle = preexistingHandle;

			/// <summary>Returns an invalid handle by instantiating a <see cref="HCERTSTORE"/> object with <see cref="IntPtr.Zero"/>.</summary>
			public static HCERTSTORE NULL => new HCERTSTORE(IntPtr.Zero);

			/// <summary>Gets a value indicating whether this instance is a null handle.</summary>
			public bool IsNull => handle == IntPtr.Zero;

			/// <summary>Performs an explicit conversion from <see cref="HCERTSTORE"/> to <see cref="IntPtr"/>.</summary>
			/// <param name="h">The handle.</param>
			/// <returns>The result of the conversion.</returns>
			public static explicit operator IntPtr(HCERTSTORE h) => h.handle;

			/// <summary>Performs an implicit conversion from <see cref="IntPtr"/> to <see cref="HCERTSTORE"/>.</summary>
			/// <param name="h">The pointer to a handle.</param>
			/// <returns>The result of the conversion.</returns>
			public static implicit operator HCERTSTORE(IntPtr h) => new HCERTSTORE(h);

			/// <summary>Implements the operator !=.</summary>
			/// <param name="h1">The first handle.</param>
			/// <param name="h2">The second handle.</param>
			/// <returns>The result of the operator.</returns>
			public static bool operator !=(HCERTSTORE h1, HCERTSTORE h2) => !(h1 == h2);

			/// <summary>Implements the operator ==.</summary>
			/// <param name="h1">The first handle.</param>
			/// <param name="h2">The second handle.</param>
			/// <returns>The result of the operator.</returns>
			public static bool operator ==(HCERTSTORE h1, HCERTSTORE h2) => h1.Equals(h2);

			/// <inheritdoc/>
			public override bool Equals(object obj) => obj is HCERTSTORE h ? handle == h.handle : false;

			/// <inheritdoc/>
			public override int GetHashCode() => handle.GetHashCode();

			/// <inheritdoc/>
			public IntPtr DangerousGetHandle() => handle;
		}

		/// <summary>Provides a <see cref="SafeHandle"/> for <see cref="HCERTSTORE"/> that is disposed using <see cref="CertCloseStore"/>.</summary>
		public class SafeHCERTSTORE : SafeHANDLE
		{
			/// <summary>Initializes a new instance of the <see cref="SafeHCERTSTORE"/> class and assigns an existing handle.</summary>
			/// <param name="preexistingHandle">An <see cref="IntPtr"/> object that represents the pre-existing handle to use.</param>
			/// <param name="ownsHandle">
			/// <see langword="true"/> to reliably release the handle during the finalization phase; otherwise, <see langword="false"/> (not recommended).
			/// </param>
			public SafeHCERTSTORE(IntPtr preexistingHandle, bool ownsHandle = true) : base(preexistingHandle, ownsHandle) { }

			/// <summary>Initializes a new instance of the <see cref="SafeHCERTSTORE"/> class.</summary>
			private SafeHCERTSTORE() : base() { }

			/// <summary>
			/// Typically, this property uses the default value zero. The default is to close the store with memory remaining allocated for
			/// contexts that have not been freed. In this case, no check is made to determine whether memory for contexts remains allocated.
			/// <para>
			/// Set flags can force the freeing of memory for all of a store's certificate, certificate revocation list (CRL), and
			/// certificate trust list (CTL) contexts when the store is closed. Flags can also be set that check whether all of the store's
			/// certificate, CRL, and CTL contexts have been freed.The following values are defined.
			/// </para>
			/// </summary>
			public CertCloseStoreFlags Flag { get; set; } = 0;

			/// <summary>Performs an implicit conversion from <see cref="SafeHCERTSTORE"/> to <see cref="HCERTSTORE"/>.</summary>
			/// <param name="h">The safe handle instance.</param>
			/// <returns>The result of the conversion.</returns>
			public static implicit operator HCERTSTORE(SafeHCERTSTORE h) => h.handle;

			/// <inheritdoc/>
			protected override bool InternalReleaseHandle() => CertCloseStore(handle, Flag);
		}

		/// <summary>Provides a handle to a CryptoAPI provider.</summary>
		[StructLayout(LayoutKind.Sequential)]
		public struct HCRYPTPROV : IHandle
		{
			private IntPtr handle;

			/// <summary>Initializes a new instance of the <see cref="HCRYPTPROV"/> struct.</summary>
			/// <param name="preexistingHandle">An <see cref="IntPtr"/> object that represents the pre-existing handle to use.</param>
			public HCRYPTPROV(IntPtr preexistingHandle) => handle = preexistingHandle;

			/// <summary>Returns an invalid handle by instantiating a <see cref="HCRYPTPROV"/> object with <see cref="IntPtr.Zero"/>.</summary>
			public static HCRYPTPROV NULL => new HCRYPTPROV(IntPtr.Zero);

			/// <summary>Gets a value indicating whether this instance is a null handle.</summary>
			public bool IsNull => handle == IntPtr.Zero;

			/// <summary>Performs an explicit conversion from <see cref="HCRYPTPROV"/> to <see cref="IntPtr"/>.</summary>
			/// <param name="h">The handle.</param>
			/// <returns>The result of the conversion.</returns>
			public static explicit operator IntPtr(HCRYPTPROV h) => h.handle;

			/// <summary>Performs an implicit conversion from <see cref="IntPtr"/> to <see cref="HCRYPTPROV"/>.</summary>
			/// <param name="h">The pointer to a handle.</param>
			/// <returns>The result of the conversion.</returns>
			public static implicit operator HCRYPTPROV(IntPtr h) => new HCRYPTPROV(h);

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
			public override bool Equals(object obj) => obj is HCRYPTPROV h ? handle == h.handle : false;

			/// <inheritdoc/>
			public override int GetHashCode() => handle.GetHashCode();

			/// <inheritdoc/>
			public IntPtr DangerousGetHandle() => handle;
		}

		/// <summary>Provides a handle to a CryptoApi key.</summary>
		[StructLayout(LayoutKind.Sequential)]
		public struct HCRYPTKEY : IHandle
		{
			private IntPtr handle;

			/// <summary>Initializes a new instance of the <see cref="HCRYPTKEY"/> struct.</summary>
			/// <param name="preexistingHandle">An <see cref="IntPtr"/> object that represents the pre-existing handle to use.</param>
			public HCRYPTKEY(IntPtr preexistingHandle) => handle = preexistingHandle;

			/// <summary>Returns an invalid handle by instantiating a <see cref="HCRYPTKEY"/> object with <see cref="IntPtr.Zero"/>.</summary>
			public static HCRYPTKEY NULL => new HCRYPTKEY(IntPtr.Zero);

			/// <summary>Gets a value indicating whether this instance is a null handle.</summary>
			public bool IsNull => handle == IntPtr.Zero;

			/// <summary>Performs an explicit conversion from <see cref="HCRYPTKEY"/> to <see cref="IntPtr"/>.</summary>
			/// <param name="h">The handle.</param>
			/// <returns>The result of the conversion.</returns>
			public static explicit operator IntPtr(HCRYPTKEY h) => h.handle;

			/// <summary>Performs an implicit conversion from <see cref="IntPtr"/> to <see cref="HCRYPTKEY"/>.</summary>
			/// <param name="h">The pointer to a handle.</param>
			/// <returns>The result of the conversion.</returns>
			public static implicit operator HCRYPTKEY(IntPtr h) => new HCRYPTKEY(h);

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
			public override bool Equals(object obj) => obj is HCRYPTKEY h ? handle == h.handle : false;

			/// <inheritdoc/>
			public override int GetHashCode() => handle.GetHashCode();

			/// <inheritdoc/>
			public IntPtr DangerousGetHandle() => handle;
		}

		/// <summary>Provides a handle to a CryptoApi hash.</summary>
		[StructLayout(LayoutKind.Sequential)]
		public struct HCRYPTHASH : IHandle
		{
			private IntPtr handle;

			/// <summary>Initializes a new instance of the <see cref="HCRYPTHASH"/> struct.</summary>
			/// <param name="preexistingHandle">An <see cref="IntPtr"/> object that represents the pre-existing handle to use.</param>
			public HCRYPTHASH(IntPtr preexistingHandle) => handle = preexistingHandle;

			/// <summary>Returns an invalid handle by instantiating a <see cref="HCRYPTHASH"/> object with <see cref="IntPtr.Zero"/>.</summary>
			public static HCRYPTHASH NULL => new HCRYPTHASH(IntPtr.Zero);

			/// <summary>Gets a value indicating whether this instance is a null handle.</summary>
			public bool IsNull => handle == IntPtr.Zero;

			/// <summary>Performs an explicit conversion from <see cref="HCRYPTHASH"/> to <see cref="IntPtr"/>.</summary>
			/// <param name="h">The handle.</param>
			/// <returns>The result of the conversion.</returns>
			public static explicit operator IntPtr(HCRYPTHASH h) => h.handle;

			/// <summary>Performs an implicit conversion from <see cref="IntPtr"/> to <see cref="HCRYPTHASH"/>.</summary>
			/// <param name="h">The pointer to a handle.</param>
			/// <returns>The result of the conversion.</returns>
			public static implicit operator HCRYPTHASH(IntPtr h) => new HCRYPTHASH(h);

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
			public override bool Equals(object obj) => obj is HCRYPTHASH h ? handle == h.handle : false;

			/// <inheritdoc/>
			public override int GetHashCode() => handle.GetHashCode();

			/// <inheritdoc/>
			public IntPtr DangerousGetHandle() => handle;
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