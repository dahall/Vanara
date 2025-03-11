using System.Collections.Generic;
using static Vanara.PInvoke.Crypt32;

namespace Vanara.PInvoke;

public static partial class AdvApi32
{
	/// <summary>Supports both Diffie-Hellman and Schannel protocols.</summary>
	public const uint PROV_DH_SCHANNEL = 18;

	/// <summary>
	/// Supports hashes and digital signatures. The signature algorithm specified by the PROV_DSS provider type is the Digital Signature
	/// Algorithm (DSA).
	/// </summary>
	public const uint PROV_DSS = 3;

	/// <summary>A superset of the PROV_DSS provider type with Diffie-Hellman key exchange.</summary>
	public const uint PROV_DSS_DH = 13;

	/// <summary></summary>
	public const uint PROV_EC_ECDSA_FULL = 16;

	/// <summary></summary>
	public const uint PROV_EC_ECDSA_SIG = 14;

	/// <summary></summary>
	public const uint PROV_EC_ECNRA_FULL = 17;

	/// <summary></summary>
	public const uint PROV_EC_ECNRA_SIG = 15;

	/// <summary>
	/// The PROV_FORTEZZA provider type contains a set of cryptographic protocols and algorithms owned by the National Institute of Standards
	/// and Technology (NIST).
	/// </summary>
	public const uint PROV_FORTEZZA = 4;

	/// <summary></summary>
	public const uint PROV_INTEL_SEC = 22;

	/// <summary>
	/// Designed for the cryptographic needs of the Exchange mail application and other applications compatible with Microsoft Mail.
	/// </summary>
	public const uint PROV_MS_EXCHANGE = 5;

	/// <summary></summary>
	public const uint PROV_REPLACE_OWF = 23;

	/// <summary></summary>
	public const uint PROV_RNG = 21;

	/// <summary>Supports the same as PROV_RSA_FULL with additional AES encryption capability.</summary>
	public const uint PROV_RSA_AES = 24;

	/// <summary>
	/// The PROV_RSA_FULL provider type supports both digital signatures and data encryption. It is considered a general purpose CSP. The RSA
	/// public key algorithm is used for all public key operations.
	/// </summary>
	public const uint PROV_RSA_FULL = 1;

	/// <summary>Supports both RSA and Schannel protocols.</summary>
	public const uint PROV_RSA_SCHANNEL = 12;

	/// <summary>
	/// The PROV_RSA_SIG provider type is a subset of PROV_RSA_FULL. It supports only those functions and algorithms required for hashes and
	/// digital signatures.
	/// </summary>
	public const uint PROV_RSA_SIG = 2;

	/// <summary></summary>
	public const uint PROV_SPYRUS_LYNKS = 20;

	/// <summary>The PROV_SSL provider type supports the Secure Sockets Layer (SSL) protocol.</summary>
	public const uint PROV_SSL = 6;

	/// <summary></summary>
	public const uint PROV_STT_ACQ = 8;

	/// <summary></summary>
	public const uint PROV_STT_BRND = 9;

	/// <summary></summary>
	public const uint PROV_STT_ISS = 11;

	/// <summary></summary>
	public const uint PROV_STT_MER = 7;

	/// <summary></summary>
	public const uint PROV_STT_ROOT = 10;

	private delegate bool CryptGetValueMethod<THandle, TEnum>(THandle hKey, TEnum dwParam, IntPtr pbData, ref uint pdwDataLen, uint dwFlags) where THandle : struct where TEnum : Enum;
	/// <summary>Values for KP_MODE</summary>
	[PInvokeData("wincrypt.h", MSDNShortId = "07956d74-0e22-484b-9bf1-e0184a2ff32f")]
	public enum CRYPT_MODE
	{
		/// <summary>Cipher block chaining</summary>
		CRYPT_MODE_CBC = 1,
		/// <summary>Electronic code book</summary>
		CRYPT_MODE_ECB = 2,
		/// <summary>Output feedback mode</summary>
		CRYPT_MODE_OFB = 3,
		/// <summary>Cipher feedback mode</summary>
		CRYPT_MODE_CFB = 4,
		/// <summary>Ciphertext stealing mode</summary>
		CRYPT_MODE_CTS = 5,
	}

	/// <summary>Flag values for <see cref="CryptAcquireContext"/>.</summary>
	[PInvokeData("wincrypt.h", MSDNShortId = "57e13662-3189-4f8d-b90a-d1fbdc09b63c")]
	[Flags]
	public enum CryptAcquireContextFlags : uint
	{
		/// <summary>
		/// This option is intended for applications that are using ephemeral keys, or applications that do not require access to persisted
		/// private keys, such as applications that perform only hashing, encryption, and digital signature verification. Only applications
		/// that create signatures or decrypt messages need access to a private key. In most cases, this flag should be set. For file-based
		/// CSPs, when this flag is set, the pszContainer parameter must be set to NULL. The application has no access to the persisted
		/// private keys of public/private key pairs. When this flag is set, temporary public/private key pairs can be created, but they are
		/// not persisted. For hardware-based CSPs, such as a smart card CSP, if the pszContainer parameter is NULL or blank, this flag
		/// implies that no access to any keys is required, and that no UI should be presented to the user. This form is used to connect to
		/// the CSP to query its capabilities but not to actually use its keys. If the pszContainer parameter is not NULL and not blank, then
		/// this flag implies that access to only the publicly available information within the specified container is required. The CSP
		/// should not ask for a PIN. Attempts to access private information (for example, the CryptSignHash function) will fail. When
		/// CryptAcquireContext is called, many CSPs require input from the owning user before granting access to the private keys in the key
		/// container. For example, the private keys can be encrypted, requiring a password from the user before they can be used. However,
		/// if the CRYPT_VERIFYCONTEXT flag is specified, access to the private keys is not required and the user interface can be bypassed.
		/// </summary>
		CRYPT_VERIFYCONTEXT = 0xF0000000,

		/// <summary>
		/// Creates a new key container with the name specified by pszContainer. If pszContainer is NULL, a key container with the default
		/// name is created.
		/// </summary>
		CRYPT_NEWKEYSET = 0x00000008,

		/// <summary>
		/// Delete the key container specified by pszContainer. If pszContainer is NULL, the key container with the default name is deleted.
		/// All key pairs in the key container are also destroyed. When this flag is set, the value returned in phProv is undefined, and
		/// thus, the CryptReleaseContext function need not be called afterward.
		/// </summary>
		CRYPT_DELETEKEYSET = 0x00000010,

		/// <summary>
		/// By default, keys and key containers are stored as user keys. For Base Providers, this means that user key containers are stored
		/// in the user's profile. A key container created without this flag by an administrator can be accessed only by the user creating
		/// the key container and a user with administration privileges. Windows XP: A key container created without this flag by an
		/// administrator can be accessed only by the user creating the key container and the local system account. A key container created
		/// without this flag by a user that is not an administrator can be accessed only by the user creating the key container and the
		/// local system account. The CRYPT_MACHINE_KEYSET flag can be combined with all of the other flags to indicate that the key
		/// container of interest is a computer key container and the CSP treats it as such. For Base Providers, this means that the keys are
		/// stored locally on the computer that created the key container. If a key container is to be a computer container, the
		/// CRYPT_MACHINE_KEYSET flag must be used with all calls to CryptAcquireContext that reference the computer container. The key
		/// container created with CRYPT_MACHINE_KEYSET by an administrator can be accessed only by its creator and by a user with
		/// administrator privileges unless access rights to the container are granted using CryptSetProvParam. Windows XP: The key container
		/// created with CRYPT_MACHINE_KEYSET by an administrator can be accessed only by its creator and by the local system account unless
		/// access rights to the container are granted using CryptSetProvParam. The key container created with CRYPT_MACHINE_KEYSET by a user
		/// that is not an administrator can be accessed only by its creator and by the local system account unless access rights to the
		/// container are granted using CryptSetProvParam. The CRYPT_MACHINE_KEYSET flag is useful when the user is accessing from a service
		/// or user account that did not log on interactively. When key containers are created, most CSPs do not automatically create any
		/// public/private key pairs. These keys must be created as a separate step with the CryptGenKey function.
		/// </summary>
		CRYPT_MACHINE_KEYSET = 0x00000020,

		/// <summary>
		/// The application requests that the CSP not display any user interface (UI) for this context. If the CSP must display the UI to
		/// operate, the call fails and the NTE_SILENT_CONTEXT error code is set as the last error. In addition, if calls are made to
		/// CryptGenKey with the CRYPT_USER_PROTECTED flag with a context that has been acquired with the CRYPT_SILENT flag, the calls fail
		/// and the CSP sets NTE_SILENT_CONTEXT. CRYPT_SILENT is intended for use with applications for which the UI cannot be displayed by
		/// the CSP.
		/// </summary>
		CRYPT_SILENT = 0x00000040,

		/// <summary>
		/// Obtains a context for a smart card CSP that can be used for hashing and symmetric key operations but cannot be used for any
		/// operation that requires authentication to a smart card using a PIN. This type of context is most often used to perform operations
		/// on an empty smart card, such as setting the PIN by using CryptSetProvParam. This flag can only be used with smart card CSPs.
		/// Windows Server 2003 and Windows XP: This flag is not supported.
		/// </summary>
		CRYPT_DEFAULT_CONTAINER_OPTIONAL = 0x00000080,
	}

	/// <summary>Flags for CryptDecrypt.</summary>
	[PInvokeData("wincrypt.h", MSDNShortId = "7c3d2838-6fd1-4f6c-9586-8b94b459a31a")]
	[Flags]
	public enum CryptDecryptFlags
	{
		/// <summary>
		/// Use Optimal Asymmetric Encryption Padding (OAEP) (PKCS #1 version 2). This flag is only supported by the Microsoft Enhanced
		/// Cryptographic Provider with RSA encryption/decryption. This flag cannot be combined with the CRYPT_DECRYPT_RSA_NO_PADDING_CHECK flag.
		/// </summary>
		CRYPT_OAEP = 0x00000040,

		/// <summary>
		/// Perform the decryption on the BLOB without checking the padding. This flag is only supported by the Microsoft Enhanced
		/// Cryptographic Provider with RSA encryption/decryption. This flag cannot be combined with the CRYPT_OAEP flag.
		/// </summary>
		CRYPT_DECRYPT_RSA_NO_PADDING_CHECK = 0x00000020,
	}

	/// <summary>Flags for CryptEncrypt.</summary>
	[PInvokeData("wincrypt.h", MSDNShortId = "697c4960-552b-4c3a-95cf-4632af56945b")]
	[Flags]
	public enum CryptEncryptFlags
	{
		/// <summary>
		/// Use Optimal Asymmetric Encryption Padding (OAEP) (PKCS #1 version 2). This flag is only supported by the Microsoft Enhanced
		/// Cryptographic Provider with RSA encryption/decryption. This flag cannot be combined with the CRYPT_DECRYPT_RSA_NO_PADDING_CHECK flag.
		/// </summary>
		CRYPT_OAEP = 0x00000040,
	}

	/// <summary>Flags for <see cref="CryptExportKey(HCRYPTKEY, HCRYPTKEY, BlobType, CryptExportKeyFlags, IntPtr, ref uint)"/>.</summary>
	[PInvokeData("wincrypt.h", MSDNShortId = "8a7c7b46-3bea-4043-b568-6d91d6335737")]
	[Flags]
	public enum CryptExportKeyFlags
	{
		/// <summary>This flag causes this function to export version 3 of a BLOB type.</summary>
		CRYPT_BLOB_VER3 = 0x00000080,

		/// <summary>This flag destroys the original key in the OPAQUEKEYBLOB. This flag is available in Schannel CSPs only.</summary>
		CRYPT_DESTROYKEY = 0x00000004,

		/// <summary>
		/// This flag causes PKCS #1 version 2 formatting to be created with the RSA encryption and decryption when exporting SIMPLEBLOBs.
		/// </summary>
		CRYPT_OAEP = 0x00000040,

		/// <summary>
		/// The first eight bytes of the RSA encryption block padding must be set to 0x03 rather than to random data. This prevents version
		/// rollback attacks and is discussed in the SSL3 specification. This flag is available for Schannel CSPs only.
		/// </summary>
		CRYPT_SSL2_FALLBACK = 0x00000002,

		/// <summary>This flag is not used.</summary>
		CRYPT_Y_ONLY = 0x00000001,

		/// <summary></summary>
		CRYPT_IPSEC_HMAC_KEY = 0x00000100,
	}

	/// <summary>Flags for <see cref="CryptDeriveKey"/> and <see cref="CryptGenKey"/>.</summary>
	[PInvokeData("wincrypt.h", MSDNShortId = "b65dd856-2dfa-4cda-9b2f-b32f3c291470")]
	[Flags]
	public enum CryptGenKeyFlags : uint
	{
		/// <summary>
		/// If this flag is set, the session key can be transferred out of the CSP into a key BLOB through the CryptExportKey function.
		/// Because keys generally must be exportable, this flag should usually be set.
		/// <para>
		/// If this flag is not set, then the session key is not exportable. This means the key is available only within the current session
		/// and only the application that created it is able to use it.
		/// </para>
		/// <para>This flag does not apply to public/private key pairs.</para>
		/// </summary>
		CRYPT_EXPORTABLE = 0x00000001,

		/// <summary>
		/// If this flag is set, the user is notified through a dialog box or another method when certain actions are attempting to use this
		/// key. The precise behavior is specified by the CSP being used. If the provider context was opened with the CRYPT_SILENT flag set,
		/// using this flag causes a failure and the last error is set to NTE_SILENT_CONTEXT.
		/// </summary>
		CRYPT_USER_PROTECTED = 0x00000002,

		/// <summary>
		/// Typically, when a session key is made from a hash value, there are a number of leftover bits. For example, if the hash value is
		/// 128 bits and the session key is 40 bits, there will be 88 bits left over.
		/// <para>
		/// If this flag is set, then the key is assigned a salt value based on the unused hash value bits. You can retrieve this salt value
		/// by using the CryptGetKeyParam function with the dwParam parameter set to KP_SALT.
		/// </para>
		/// <para>If this flag is not set, then the key is given a salt value of zero.</para>
		/// <para>
		/// When keys with nonzero salt values are exported (by using CryptExportKey), the salt value must also be obtained and kept with the
		/// key BLOB.
		/// </para>
		/// </summary>
		CRYPT_CREATE_SALT = 0x00000004,

		/// <summary>
		/// Some CSPs use session keys that are derived from multiple hash values. When this is the case, CryptDeriveKey must be called
		/// multiple times.
		/// <para>
		/// If this flag is set, a new session key is not generated.Instead, the key specified by phKey is modified.The precise behavior of
		/// this flag is dependent on the type of key being generated and on the particular CSP being used.
		/// </para>
		/// <para>Microsoft cryptographic service providers ignore this flag.</para>
		/// </summary>
		CRYPT_UPDATE_KEY = 0x00000008,

		/// <summary>
		/// This flag specifies that a no salt value gets allocated for a 40-bit symmetric key. For more information, see Salt Value Functionality.
		/// </summary>
		CRYPT_NO_SALT = 0x00000010,

		/// <summary>
		/// This flag specifies an initial Diffie-Hellman or DSS key generation. This flag is useful only with Diffie-Hellman and DSS CSPs.
		/// When used, a default key length will be used unless a key length is specified in the upper 16 bits of the dwFlags parameter. If
		/// parameters that involve key lengths are set on a PREGEN Diffie-Hellman or DSS key using CryptSetKeyParam, the key lengths must be
		/// compatible with the key length set here.
		/// </summary>
		CRYPT_PREGEN = 0x00000040,

		/// <summary>This flag is not used.</summary>
		CRYPT_RECIPIENT = 0x00000010,

		/// <summary>This flag is not used.</summary>
		CRYPT_INITIATOR = 0x00000040,

		/// <summary>This flag is not used.</summary>
		CRYPT_ONLINE = 0x00000080,

		/// <summary>This flag is not used.</summary>
		CRYPT_SF = 0x00000100,

		/// <summary>This flag is not used.</summary>
		CRYPT_CREATE_IV = 0x00000200,

		/// <summary>This flag is not used.</summary>
		CRYPT_KEK = 0x00000400,

		/// <summary>This flag is not used.</summary>
		CRYPT_DATA_KEY = 0x00000800,

		/// <summary>This flag is not used.</summary>
		CRYPT_VOLATILE = 0x00001000,

		/// <summary>This flag is not used.</summary>
		CRYPT_SGCKEY = 0x00002000,

		/// <summary>This flag is not used.</summary>
		CRYPT_USER_PROTECTED_STRONG = 0x00100000,

		/// <summary>
		/// If this flag is set, the key can be exported until its handle is closed by a call to CryptDestroyKey. This allows newly generated
		/// keys to be exported upon creation for archiving or key recovery. After the handle is closed, the key is no longer exportable.
		/// </summary>
		CRYPT_ARCHIVABLE = 0x00004000,

		/// <summary>
		/// <para>
		/// This flag specifies strong key protection. When this flag is set, the user is prompted to enter a password for the key when the
		/// key is created. The user will be prompted to enter the password whenever this key is used.
		/// </para>
		/// <para>
		/// This flag is only used by the CSPs that are provided by Microsoft. Third party CSPs will define their own behavior for strong key protection.
		/// </para>
		/// <para>
		/// Specifying this flag causes the same result as calling this function with the CRYPT_USER_PROTECTED flag when strong key
		/// protection is specified in the system registry.
		/// </para>
		/// <para>
		/// If this flag is specified and the provider handle in the hProv parameter was created by using the CRYPT_VERIFYCONTEXT or
		/// CRYPT_SILENT flag, this function will set the last error to NTE_SILENT_CONTEXT and return zero.
		/// </para>
		/// <para>Windows Server 2003 and Windows XP: This flag is not supported.</para>
		/// </summary>
		CRYPT_FORCE_KEY_PROTECTION_HIGH = 0x00008000,

		/// <summary>
		/// This flag is used only with Schannel providers. If this flag is set, the key to be generated is a server-write key; otherwise, it
		/// is a client-write key.
		/// </summary>
		CRYPT_SERVER = 0x400,
	}

	/// <summary>Flags for <see cref="CryptHashSessionKey"/>.</summary>
	[Flags]
	public enum CryptHashSessionKeyFlags
	{
		/// <summary>
		/// When this flag is set, the bytes of the key are hashed in little-endian form. Note that by default (when dwFlags is zero), the
		/// bytes of the key are hashed in big-endian form.
		/// </summary>
		CRYPT_LITTLE_ENDIAN = 1
	}

	/// <summary>Flags for <see cref="CryptGetDefaultProvider"/> and <see cref="CryptSetProviderEx"/>.</summary>
	[PInvokeData("wincrypt.h", MSDNShortId = "5d15641e-1ad7-441d-9423-65fd51de9812")]
	[Flags]
	public enum CryptProviderFlags
	{
		/// <summary>Returns the user-context default CSP of the specified type.</summary>
		CRYPT_USER_DEFAULT = 0x00000002,

		/// <summary>Returns the computer default CSP of the specified type.</summary>
		CRYPT_MACHINE_DEFAULT = 0x00000001,

		/// <summary>Can be used in conjunction with CRYPT_MACHINE_DEFAULT or CRYPT_USER_DEFAULT to delete the default.</summary>
		CRYPT_DELETE_DEFAULT = 0x00000004,
	}

	/// <summary>Flags for <see cref="CryptSignHash"/> and <see cref="CryptVerifySignature"/>.</summary>
	[PInvokeData("wincrypt.h", MSDNShortId = "3119eabc-90ff-42c6-b3fa-e8be625f6d1e")]
	[Flags]
	public enum CryptSignFlags
	{
		/// <summary>
		/// This flag is used with RSA providers. When verifying the signature, the hash object identifier (OID) is not expected to be
		/// present or checked. If this flag is not set, the hash OID in the default signature is verified as specified in the definition of
		/// DigestInfo in PKCS #7.
		/// </summary>
		CRYPT_NOHASHOID = 0x00000001,

		/// <summary>This flag is not used.</summary>
		CRYPT_TYPE2_FORMAT = 0x00000002,

		/// <summary>Use X.931 support for the FIPS 186-2–compliant version of RSA (rDSA).</summary>
		CRYPT_X931_FORMAT = 0x00000004,
	}

	/// <summary>Query type.</summary>
	[PInvokeData("wincrypt.h", MSDNShortId = "ed008c07-1a40-4075-bdaa-eb7f7e12d9c3")]
	public enum HashParam
	{
		/// <summary>
		/// An ALG_ID that indicates the algorithm specified when the hash object was created. For a list of hash algorithms, see CryptCreateHash.
		/// </summary>
		[CorrespondingType(typeof(ALG_ID), CorrespondingAction.Get)]
		[CorrespondingType(typeof(uint))]
		HP_ALGID = 0x0001,

		/// <summary>
		/// The hash value or message hash for the hash object specified by hHash. This value is generated based on the data supplied to the
		/// hash object earlier through the CryptHashData and CryptHashSessionKey functions.
		/// <para>
		/// The CryptGetHashParam function completes the hash. After CryptGetHashParam has been called, no more data can be added to the
		/// hash. Additional calls to CryptHashData or CryptHashSessionKey fail. After the application is done with the hash,
		/// CryptDestroyHash should be called to destroy the hash object.
		/// </para>
		/// </summary>
		[CorrespondingType(typeof(byte[]))]
		[CorrespondingType(typeof(IntPtr))]
		HP_HASHVAL = 0x0002,

		/// <summary>
		/// DWORD value indicating the number of bytes in the hash value. This value will vary depending on the hash algorithm. Applications
		/// must retrieve this value just before the HP_HASHVAL value so the correct amount of memory can be allocated.
		/// </summary>
		[CorrespondingType(typeof(uint), CorrespondingAction.Get)]
		HP_HASHSIZE = 0x0004,

		/// <summary>
		/// A pointer to an HMAC_INFO structure that specifies the cryptographic hash algorithm and the inner and outer strings to be used.
		/// </summary>
		[CorrespondingType(typeof(HMAC_INFO), CorrespondingAction.Set)]
		HP_HMAC_INFO = 0x0005,

		/// <summary>
		/// Component of the function argument GOSTR3411_PRF. It takes various values ​​in client and server messages when implementing the
		/// TLS Handshake Protocol.
		/// </summary>
		[CorrespondingType(typeof(CRYPTOAPI_BLOB), CorrespondingAction.Set)]
		HP_TLS1PRF_LABEL = 0x0006,

		/// <summary>
		/// Component of the function argument GOSTR3411_PRF. It takes various values ​​in client and server messages when implementing the
		/// TLS Handshake Protocol.
		/// </summary>
		[CorrespondingType(typeof(CRYPTOAPI_BLOB), CorrespondingAction.Set)]
		HP_TLS1PRF_SEED = 0x0007,
	}

	/// <summary>Specifies the type of query being made.</summary>
	[PInvokeData("wincrypt.h", MSDNShortId = "07956d74-0e22-484b-9bf1-e0184a2ff32f")]
	public enum KeyParam
	{
		/// <summary>
		/// Retrieve the initialization vector of the key. The pbData parameter is a pointer to a BYTE array that receives the initialization
		/// vector. The size of this array is the block size, in bytes. For example, if the block length is 64 bits, the initialization
		/// vector consists of 8 bytes.
		/// </summary>
		[CorrespondingType(typeof(byte[]), CorrespondingAction.GetSet)]
		[CorrespondingType(typeof(IntPtr), CorrespondingAction.GetSet)]
		KP_IV = 1,

		/// <summary>
		/// Retrieve the salt value of the key. The pbData parameter is a pointer to a BYTE array that receives the salt value in
		/// little-endian form. The size of the salt value varies depending on the CSP and algorithm being used. Salt values do not apply to
		/// public/private key pairs.
		/// </summary>
		[CorrespondingType(typeof(byte[]), CorrespondingAction.GetSet)]
		[CorrespondingType(typeof(IntPtr), CorrespondingAction.GetSet)]
		KP_SALT = 2,

		/// <summary>
		/// <para>
		/// Retrieve the padding mode. The pbData parameter is a pointer to a DWORD value that receives a numeric identifier that identifies
		/// the padding method used by the cipher. This can be one of the following values.
		/// </para>
		/// <para>
		/// PKCS5_PADDING <br/> Specifies the PKCS 5 (sec 6.2) padding method. <br/> RANDOM_PADDING <br/> The padding uses random numbers.
		/// This padding method is not supported by the Microsoft supplied CSPs. <br/> ZERO_PADDING <br/> The padding uses zeros. This
		/// padding method is not supported by the Microsoft supplied CSPs.
		/// </para>
		/// </summary>
		[CorrespondingType(typeof(KP_PADDING), CorrespondingAction.GetSet)]
		KP_PADDING = 3,

		/// <summary>
		/// <para>
		/// Retrieve the cipher mode. The pbData parameter is a pointer to a DWORD value that receives a cipher mode identifier. For more
		/// information about cipher modes, see Data Encryption and Decryption.
		/// </para>
		/// <para>The following cipher mode identifiers are currently defined.</para>
		/// <para>
		/// CRYPT_MODE_CBC <br/> The cipher mode is cipher block chaining. <br/> CRYPT_MODE_CFB <br/> The cipher mode is cipher feedback
		/// (CFB). Microsoft CSPs currently support only 8-bit feedback in cipher feedback mode. <br/> CRYPT_MODE_ECB <br/> The cipher mode
		/// is electronic codebook. <br/> CRYPT_MODE_OFB <br/> The cipher mode is Output Feedback (OFB). Microsoft CSPs currently do not
		/// support Output Feedback Mode. <br/> CRYPT_MODE_CTS <br/> The cipher mode is ciphertext stealing mode.
		/// </para>
		/// </summary>
		[CorrespondingType(typeof(CRYPT_MODE), CorrespondingAction.GetSet)]
		KP_MODE = 4,

		/// <summary>
		/// Retrieve the number of bits to feed back. The pbData parameter is a pointer to a DWORD value that receives the number of bits
		/// that are processed per cycle when the OFB or CFB cipher modes are used.
		/// </summary>
		[CorrespondingType(typeof(uint), CorrespondingAction.GetSet)]
		KP_MODE_BITS = 5,

		/// <summary>
		/// <para>
		/// Retrieve the key permissions. The pbData parameter is a pointer to a DWORD value that receives the permission flags for the key.
		/// </para>
		/// <para>
		/// The following permission identifiers are currently defined. The key permissions can be zero or a combination of one or more of
		/// the following values.
		/// </para>
		/// <para>
		/// CRYPT_ARCHIVE <br/> Allow export during the lifetime of the handle of the key. This permission can be set only if it is already
		/// set in the internal permissions field of the key. Attempts to clear this permission are ignored. <br/> CRYPT_DECRYPT <br/> Allow
		/// decryption. <br/> CRYPT_ENCRYPT <br/> Allow encryption. <br/> CRYPT_EXPORT <br/> Allow the key to be exported. <br/>
		/// CRYPT_EXPORT_KEY <br/> Allow the key to be used for exporting keys. <br/> CRYPT_IMPORT_KEY <br/> Allow the key to be used for
		/// importing keys. <br/> CRYPT_MAC <br/> Allow Message Authentication Codes (MACs) to be used with key. <br/> CRYPT_READ <br/> Allow
		/// values to be read. <br/> CRYPT_WRITE <br/> Allow values to be set.
		/// </para>
		/// </summary>
		[CorrespondingType(typeof(KP_PERMISSIONS), CorrespondingAction.GetSet)]
		KP_PERMISSIONS = 6,

		/// <summary>
		/// Retrieve the key algorithm. The pbData parameter is a pointer to an ALG_ID value that receives the identifier of the algorithm
		/// that was specified when the key was created.
		/// <para>
		/// When AT_KEYEXCHANGE or AT_SIGNATURE is specified for the Algid parameter of the CryptGenKey function, the algorithm identifiers
		/// that are used to generate the key depend on the provider used. For more information, see ALG_ID.
		/// </para>
		/// </summary>
		[CorrespondingType(typeof(ALG_ID), CorrespondingAction.GetSet)]
		KP_ALGID = 7,

		/// <summary>
		/// If a session key is specified by the hKey parameter, retrieve the block length of the key cipher. The pbData parameter is a
		/// pointer to a DWORD value that receives the block length, in bits. For stream ciphers, this value is always zero.
		/// <para>
		/// If a public/private key pair is specified by hKey, retrieve the encryption granularity of the key pair.The pbData parameter is a
		/// pointer to a DWORD value that receives the encryption granularity, in bits.For example, the Microsoft Base Cryptographic Provider
		/// generates 512-bit RSA key pairs, so a value of 512 is returned for these keys. If the public key algorithm does not support
		/// encryption, the value retrieved is undefined.
		/// </para>
		/// </summary>
		[CorrespondingType(typeof(uint), CorrespondingAction.Get)]
		KP_BLOCKLEN = 8,

		/// <summary>
		/// Retrieve the actual length of the key. The pbData parameter is a pointer to a DWORD value that receives the key length, in bits.
		/// KP_KEYLEN can be used to get the length of any key type. Microsoft cryptographic service providers (CSPs) return a key length of
		/// 64 bits for CALG_DES, 128 bits for CALG_3DES_112, and 192 bits for CALG_3DES. These lengths are different from the lengths
		/// returned when you are enumerating algorithms with the dwParam value of the CryptGetProvParam function set to PP_ENUMALGS. The
		/// length returned by this call is the actual size of the key, including the parity bits included in the key.
		/// <para>
		/// Microsoft CSPs that support the CALG_CYLINK_MEK ALG_ID return 64 bits for that algorithm. CALG_CYLINK_MEK is a 40-bit key but has
		/// parity and zeroed key bits to make the key length 64 bits.
		/// </para>
		/// </summary>
		[CorrespondingType(typeof(uint), CorrespondingAction.Get)]
		KP_KEYLEN = 9,

		/// <summary>
		/// pbData points to a CRYPT_INTEGER_BLOB structure that contains the salt. For more information, see Specifying a Salt Value.
		/// </summary>
		[CorrespondingType(typeof(CRYPTOAPI_BLOB), CorrespondingAction.Set)]
		KP_SALT_EX = 10,

		/// <summary>
		/// Retrieve the modulus prime number P of the DSS key. The pbData parameter is a pointer to a buffer that receives the value in
		/// little-endian form. The pdwDataLen parameter contains the size of the buffer, in bytes.
		/// </summary>
		[CorrespondingType(typeof(CRYPTOAPI_BLOB), CorrespondingAction.GetSet)]
		KP_P = 11,

		/// <summary>
		/// Retrieve the generator G of the DSS key. The pbData parameter is a pointer to a buffer that receives the value in little-endian
		/// form. The pdwDataLen parameter contains the size of the buffer, in bytes.
		/// </summary>
		[CorrespondingType(typeof(CRYPTOAPI_BLOB), CorrespondingAction.GetSet)]
		KP_G = 12,

		/// <summary>
		/// Retrieve the modulus prime number Q of the DSS key. The pbData parameter is a pointer to a buffer that receives the value in
		/// little-endian form. The pdwDataLen parameter contains the size of the buffer, in bytes.
		/// </summary>
		[CorrespondingType(typeof(CRYPTOAPI_BLOB), CorrespondingAction.GetSet)]
		KP_Q = 13,

		/// <summary>
		/// After the P, Q, and G values have been set, a call that specifies the KP_X value for dwParam and NULL for the pbData parameter
		/// can be made to the CryptSetKeyParam function. This causes the X and Y values to be generated.
		/// </summary>
		[CorrespondingType(typeof(CRYPTOAPI_BLOB), CorrespondingAction.GetSet)]
		KP_X = 14,

		/// <summary></summary>
		KP_Y = 15,

		/// <summary></summary>
		KP_RA = 16,

		/// <summary></summary>
		KP_RB = 17,

		/// <summary></summary>
		KP_INFO = 18,

		/// <summary>
		/// Retrieve the effective key length of an RC2 key. The pbData parameter is a pointer to a DWORD value that receives the effective
		/// key length.
		/// </summary>
		[CorrespondingType(typeof(uint), CorrespondingAction.GetSet)]
		KP_EFFECTIVE_KEYLEN = 19,

		/// <summary></summary>
		KP_SCHANNEL_ALG = 20,

		/// <summary></summary>
		KP_CLIENT_RANDOM = 21,

		/// <summary></summary>
		KP_SERVER_RANDOM = 22,

		/// <summary></summary>
		KP_RP = 23,

		/// <summary></summary>
		KP_PRECOMP_MD5 = 24,

		/// <summary></summary>
		KP_PRECOMP_SHA = 25,

		/// <summary>
		/// pbData is the address of a buffer that receives the X.509 certificate that has been encoded by using Distinguished Encoding Rules
		/// (DER). The public key in the certificate must match the corresponding signature or exchange key.
		/// </summary>
		[CorrespondingType(typeof(byte[]), CorrespondingAction.GetSet)]
		[CorrespondingType(typeof(IntPtr), CorrespondingAction.GetSet)]
		KP_CERTIFICATE = 26,

		/// <summary></summary>
		KP_CLEAR_KEY = 27,

		/// <summary></summary>
		KP_PUB_EX_LEN = 28,

		/// <summary></summary>
		KP_PUB_EX_VAL = 29,

		/// <summary>
		/// This value is not used.
		/// <para>
		/// Windows Vista, Windows Server 2003 and Windows XP: Retrieve the secret agreement value from an imported Diffie-Hellman algorithm
		/// key of type CALG_AGREEDKEY_ANY. The pbData parameter is the address of a buffer that receives the secret agreement value, in
		/// little-endian format. This buffer must be the same length as the key. The dwFlags parameter must be set to 0xF42A19B6. This
		/// property can only be retrieved by a thread running under the local system account.This property is available for use in the
		/// operating systems listed above. It may be altered or unavailable in subsequent versions.
		/// </para>
		/// </summary>
		[CorrespondingType(typeof(byte[]), CorrespondingAction.GetSet)]
		[CorrespondingType(typeof(IntPtr), CorrespondingAction.GetSet)]
		KP_KEYVAL = 30,

		/// <summary></summary>
		KP_ADMIN_PIN = 31,

		/// <summary></summary>
		KP_KEYEXCHANGE_PIN = 32,

		/// <summary></summary>
		KP_SIGNATURE_PIN = 33,

		/// <summary></summary>
		KP_PREHASH = 34,

		/// <summary></summary>
		KP_ROUNDS = 35,

		/// <summary>
		/// Set the Optimal Asymmetric Encryption Padding (OAEP) (PKCS #1 version 2) parameters for the key. The pbData parameter is the
		/// address of a CRYPT_DATA_BLOB structure that contains the OAEP label. This property only applies to RSA keys.
		/// </summary>
		[CorrespondingType(typeof(CRYPTOAPI_BLOB), CorrespondingAction.Set)]
		KP_OAEP_PARAMS = 36,

		/// <summary></summary>
		KP_CMS_KEY_INFO = 37,

		/// <summary>
		/// Sets the information for an imported Diffie-Hellman key. The pbData parameter is the address of a CMS_DH_KEY_INFO structure that
		/// contains the key information to be set.
		/// </summary>
		[CorrespondingType(typeof(CMS_DH_KEY_INFO), CorrespondingAction.Set)]
		KP_CMS_DH_KEY_INFO = 38,

		/// <summary>
		/// Sets the public parameters (P, Q, G, and so on) of a DSS or Diffie-Hellman key. The key handle for this key must be in the PREGEN
		/// state, generated with the CRYPT_PREGEN flag. The pbData parameter must be a pointer to a DATA_BLOB structure where the data in
		/// this structure is a DHPUBKEY_VER3 or DSSPUBKEY_VER3 BLOB. The function copies the public parameters from this CRYPT_INTEGER_BLOB
		/// structure to the key handle. After this call is made, the KP_X parameter value should be used with CryptSetKeyParam to create the
		/// actual private key. The KP_PUB_PARAMS parameter is used as one call rather than multiple calls with the parameter values KP_P,
		/// KP_Q, and KP_G.
		/// </summary>
		[CorrespondingType(typeof(CRYPTOAPI_BLOB), CorrespondingAction.Set)]
		KP_PUB_PARAMS = 39,

		/// <summary>
		/// Verifies the parameters of a Diffie-Hellman algorithm or DSA key. The pbData parameter is not used, and the value pointed to by
		/// pdwDataLen receives zero.
		/// <para>This function returns a nonzero value if the key parameters are valid or zero otherwise.</para>
		/// </summary>
		[CorrespondingType(null, CorrespondingAction.Get)]
		KP_VERIFY_PARAMS = 40,

		/// <summary>
		/// Sets the highest Transport Layer Security (TLS) version allowed. This property only applies to SSL and TLS keys. The pbData
		/// parameter is the address of a DWORD variable that contains the highest TLS version number supported.
		/// </summary>
		[CorrespondingType(typeof(uint), CorrespondingAction.GetSet)]
		KP_HIGHEST_VERSION = 41,

		/// <summary>This value is not used.</summary>
		[CorrespondingType(typeof(uint), CorrespondingAction.Get)]
		KP_GET_USE_COUNT = 42,

		/// <summary></summary>
		KP_PIN_ID = 43,

		/// <summary></summary>
		KP_PIN_INFO = 44,
	}

	/// <summary>Values for KP_PADDING</summary>
	[PInvokeData("wincrypt.h", MSDNShortId = "07956d74-0e22-484b-9bf1-e0184a2ff32f")]
	public enum KP_PADDING
	{
		/// <summary>PKCS 5 (sec 6.2) padding method</summary>
		PKCS5_PADDING = 1,
		/// <summary></summary>
		RANDOM_PADDING = 2,
		/// <summary></summary>
		ZERO_PADDING = 3,
	}
	/// <summary>Values for KP_PERMISSIONS</summary>
	[PInvokeData("wincrypt.h", MSDNShortId = "07956d74-0e22-484b-9bf1-e0184a2ff32f")]
	[Flags]
	public enum KP_PERMISSIONS : uint
	{
		/// <summary>Allow encryption</summary>
		CRYPT_ENCRYPT = 0x0001,
		/// <summary>Allow decryption</summary>
		CRYPT_DECRYPT = 0x0002,
		/// <summary>Allow key to be exported</summary>
		CRYPT_EXPORT = 0x0004,
		/// <summary>Allow parameters to be read</summary>
		CRYPT_READ = 0x0008,
		/// <summary>Allow parameters to be set</summary>
		CRYPT_WRITE = 0x0010,
		/// <summary>Allow MACs to be used with key</summary>
		CRYPT_MAC = 0x0020,
		/// <summary>Allow key to be used for exporting keys</summary>
		CRYPT_EXPORT_KEY = 0x0040,
		/// <summary>Allow key to be used for importing keys</summary>
		CRYPT_IMPORT_KEY = 0x0080,
		/// <summary>Allow key to be exported at creation only</summary>
		CRYPT_ARCHIVE = 0x0100,
	}
	/// <summary>The nature of the query.</summary>
	[PInvokeData("wincrypt.h", MSDNShortId = "c0b7c1c8-aa42-4d40-a7f7-99c0821c8977")]
	public enum ProvParam
	{
		/// <summary>Returns the administrator personal identification number (PIN) in the pbData parameter as a LPSTR.</summary>
		PP_ADMIN_PIN = 0x1F,

		/// <summary>This constant is not used.</summary>
		PP_APPLI_CERT = 0x12,

		/// <summary>This constant is not used.</summary>
		PP_CHANGE_PASSWORD = 0x7,

		/// <summary>
		/// Returns the certificate chain associated with the hProv handle. The returned certificate chain is X509_ASN_ENCODING encoded.
		/// </summary>
		PP_CERTCHAIN = 0x9,

		/// <summary>
		/// The name of the current key container as a null-terminated CHAR string. This string is exactly the same as the one passed in the
		/// pszContainer parameter of the CryptAcquireContext function to specify the key container to use. The pszContainer parameter can be
		/// read to determine the name of the default key container.
		/// </summary>
		PP_CONTAINER = 0x6,

		/// <summary>
		/// Not implemented by Microsoft CSPs. This behavior may be implemented by other CSPs.
		/// <para>Windows XP: This parameter is not supported.</para>
		/// </summary>
		PP_CRYPT_COUNT_KEY_USE = 0x29,

		/// <summary>
		/// A PROV_ENUMALGS structure that contains information about one algorithm supported by the CSP being queried.
		/// <para>
		/// The first time this value is read, the dwFlags parameter must contain the CRYPT_FIRST flag. Doing so causes this function to
		/// retrieve the first element in the enumeration. The subsequent elements can then be retrieved by setting the CRYPT_NEXT flag in
		/// the dwFlags parameter. When this function fails with the ERROR_NO_MORE_ITEMS error code, the end of the enumeration has been reached.
		/// </para>
		/// <para>
		/// This function is not thread safe, and all of the available algorithms might not be enumerated if this function is used in a
		/// multithreaded context.
		/// </para>
		/// </summary>
		PP_ENUMALGS = 0x1,

		/// <summary>
		/// A PROV_ENUMALGS_EX structure that contains information about one algorithm supported by the CSP being queried. The structure
		/// returned contains more information about the algorithm than the structure returned for PP_ENUMALGS.
		/// <para>
		/// The first time this value is read, the dwFlags parameter must contain the CRYPT_FIRST flag. Doing so causes this function to
		/// retrieve the first element in the enumeration. The subsequent elements can then be retrieved by setting the CRYPT_NEXT flag in
		/// the dwFlags parameter. When this function fails with the ERROR_NO_MORE_ITEMS error code, the end of the enumeration has been reached.
		/// </para>
		/// <para>
		/// This function is not thread safe and all of the available algorithms might not be enumerated if this function is used in a
		/// multithreaded context.
		/// </para>
		/// </summary>
		PP_ENUMALGS_EX = 0x16,

		/// <summary>
		/// The name of one of the key containers maintained by the CSP in the form of a null-terminated CHAR string.
		/// <para>
		/// The first time this value is read, the dwFlags parameter must contain the CRYPT_FIRST flag. Doing so causes this function to
		/// retrieve the first element in the enumeration. The subsequent elements can then be retrieved by setting the CRYPT_NEXT flag in
		/// the dwFlags parameter. When this function fails with the ERROR_NO_MORE_ITEMS error code, the end of the enumeration has been reached.
		/// </para>
		/// <para>
		/// To enumerate key containers associated with a computer, first call CryptAcquireContext using the CRYPT_MACHINE_KEYSET flag, and
		/// then use the handle returned from CryptAcquireContext as the hProv parameter in the call to CryptGetProvParam.
		/// </para>
		/// <para>
		/// This function is not thread safe and all of the available algorithms might not be enumerated if this function is used in a
		/// multithreaded context.
		/// </para>
		/// </summary>
		PP_ENUMCONTAINERS = 0x2,

		/// <summary>This constant is not used.</summary>
		PP_ENUMELECTROOTS = 0x1A,

		/// <summary>
		/// Indicates that the current CSP supports the dwProtocols member of the PROV_ENUMALGS_EX structure. If this function succeeds, the
		/// CSP supports the dwProtocols member of the PROV_ENUMALGS_EX structure. If this function fails with an NTE_BAD_TYPE error code,
		/// the CSP does not support the dwProtocols member.
		/// </summary>
		PP_ENUMEX_SIGNING_PROT = 0x28,

		/// <summary>This constant is not used.</summary>
		PP_ENUMMANDROOTS = 0x19,

		/// <summary>A DWORD value that indicates how the CSP is implemented. For a table of possible values, see Remarks.</summary>
		PP_IMPTYPE = 0x3,

		/// <summary>This query is not used.</summary>
		PP_KEY_TYPE_SUBTYPE = 0xA,

		/// <summary>Specifies that the key exchange PIN is contained in pbData. The PIN is represented as a null-terminated ASCII string.</summary>
		PP_KEYEXCHANGE_PIN = 0x20,

		/// <summary>
		/// Retrieves the security descriptor for the key storage container. The pbData parameter is the address of a SECURITY_DESCRIPTOR
		/// structure that receives the security descriptor for the key storage container. The security descriptor is returned in
		/// self-relative format.
		/// </summary>
		PP_KEYSET_SEC_DESCR = 0x8,

		/// <summary>
		/// Determines whether the hProv parameter is a computer key set. The pbData parameter must be a DWORD; the DWORD will be set to the
		/// CRYPT_MACHINE_KEYSET flag if that flag was passed to the CryptAcquireContext function.
		/// </summary>
		PP_KEYSET_TYPE = 0x1B,

		/// <summary>
		/// Returns information about the key specifier values that the CSP supports. Key specifier values are joined in a logical OR and
		/// returned in the pbData parameter of the call as a DWORD. For example, the Microsoft Base Cryptographic Provider version 1.0
		/// returns a DWORD value of AT_SIGNATURE | AT_KEYEXCHANGE.
		/// </summary>
		PP_KEYSPEC = 0x27,

		/// <summary>Returns a DWORD value of CRYPT_SEC_DESCR.</summary>
		PP_KEYSTORAGE = 0x11,

		/// <summary>
		/// The number of bits for the increment length of AT_KEYEXCHANGE. This information is used with information returned in the
		/// PP_ENUMALGS_EX value. With the information returned when using PP_ENUMALGS_EX and PP_KEYX_KEYSIZE_INC, the valid key lengths for
		/// AT_KEYEXCHANGE can be determined. These key lengths can then be used with CryptGenKey. For example if a CSP enumerates
		/// CALG_RSA_KEYX (AT_KEYEXCHANGE) with a minimum key length of 512 bits and a maximum of 1024 bits, and returns the increment length
		/// as 64 bits, then valid key lengths are 512, 576, 640,… 1024.
		/// </summary>
		PP_KEYX_KEYSIZE_INC = 0x23,

		/// <summary>
		/// The name of the CSP in the form of a null-terminated CHAR string. This string is identical to the one passed in the pszProvider
		/// parameter of the CryptAcquireContext function to specify that the current CSP be used.
		/// </summary>
		PP_NAME = 0x4,

		/// <summary>A DWORD value that indicates the provider type of the CSP.</summary>
		PP_PROVTYPE = 0x10,

		/// <summary>
		/// Obtains the root certificate store for the smart card. This certificate store contains all of the root certificates that are
		/// stored on the smart card.
		/// <para>
		/// The pbData parameter is the address of an HCERTSTORE variable that receives the handle of the certificate store. When this handle
		/// is no longer needed, the caller must close it by using the CertCloseStore function.
		/// </para>
		/// <para>Windows Server 2003 and Windows XP: This parameter is not supported.</para>
		/// </summary>
		PP_ROOT_CERTSTORE = 0x2E,

		/// <summary>The size, in bits, of the session key.</summary>
		PP_SESSION_KEYSIZE = 0x14,

		/// <summary>Used with server gated cryptography.</summary>
		PP_SGC_INFO = 0x25,

		/// <summary>
		/// The number of bits for the increment length of AT_SIGNATURE. This information is used with information returned in the
		/// PP_ENUMALGS_EX value. With the information returned when using PP_ENUMALGS_EX and PP_SIG_KEYSIZE_INC, the valid key lengths for
		/// AT_SIGNATURE can be determined. These key lengths can then be used with CryptGenKey.
		/// <para>
		/// For example, if a CSP enumerates CALG_RSA_SIGN (AT_SIGNATURE) with a minimum key length of 512 bits and a maximum of 1024 bits,
		/// and returns the increment length as 64 bits, then valid key lengths are 512, 576, 640,… 1024.
		/// </para>
		/// </summary>
		PP_SIG_KEYSIZE_INC = 0x22,

		/// <summary>Specifies that the key signature PIN is contained in pbData. The PIN is represented as a null-terminated ASCII string.</summary>
		PP_SIGNATURE_PIN = 0x21,

		/// <summary>
		/// Obtains the identifier of the smart card. The pbData parameter is the address of a GUID structure that receives the identifier of
		/// the smart card.
		/// <para>Windows Server 2003 and Windows XP: This parameter is not supported.</para>
		/// </summary>
		PP_SMARTCARD_GUID = 0x2D,

		/// <summary>
		/// Obtains the name of the smart card reader. The pbData parameter is the address of an ANSI character array that receives a
		/// null-terminated ANSI string that contains the name of the smart card reader. The size of this buffer, contained in the variable
		/// pointed to by the pdwDataLen parameter, must include the NULL terminator.
		/// <para>Windows Server 2003 and Windows XP: This parameter is not supported.</para>
		/// </summary>
		PP_SMARTCARD_READER = 0x2B,

		/// <summary/>
		PP_SMARTCARD_READER_ICON = 47,

		/// <summary>The size of the symmetric key.</summary>
		PP_SYM_KEYSIZE = 0x13,

		/// <summary>This query is not used.</summary>
		PP_UI_PROMPT = 0x15,

		/// <summary>
		/// The unique container name of the current key container in the form of a null-terminated CHAR string. For many CSPs, this name is
		/// the same name returned when the PP_CONTAINER value is used. The CryptAcquireContext function must work with this container name.
		/// </summary>
		PP_UNIQUE_CONTAINER = 0x24,

		/// <summary>
		/// Indicates whether a hardware random number generator (RNG) is supported. When PP_USE_HARDWARE_RNG is specified, the function
		/// succeeds and returns TRUE if a hardware RNG is supported. The function fails and returns FALSE if a hardware RNG is not
		/// supported. If a RNG is supported, PP_USE_HARDWARE_RNG can be set in CryptSetProvParam to indicate that the CSP must exclusively
		/// use the hardware RNG for this provider context. When PP_USE_HARDWARE_RNG is used, the pbData parameter must be NULL and dwFlags
		/// must be zero.
		/// <para>None of the Microsoft CSPs currently support using a hardware RNG.</para>
		/// </summary>
		PP_USE_HARDWARE_RNG = 0x26,

		/// <summary>
		/// Obtains the user certificate store for the smart card. This certificate store contains all of the user certificates that are
		/// stored on the smart card. The certificates in this store are encoded by using PKCS_7_ASN_ENCODING or X509_ASN_ENCODING encoding
		/// and should contain the CERT_KEY_PROV_INFO_PROP_ID property.
		/// <para>
		/// The pbData parameter is the address of an HCERTSTORE variable that receives the handle of an in-memory certificate store. When
		/// this handle is no longer needed, the caller must close it by using the CertCloseStore function.
		/// </para>
		/// <para>Windows Server 2003 and Windows XP: This parameter is not supported.</para>
		/// </summary>
		PP_USER_CERTSTORE = 0x2A,

		/// <summary>
		/// The version number of the CSP. The least significant byte contains the minor version number and the next most significant byte
		/// the major version number. Version 2.0 is represented as 0x00000200. To maintain backward compatibility with earlier versions of
		/// the Microsoft Base Cryptographic Provider and the Microsoft Enhanced Cryptographic Provider, the provider names retain the "v1.0"
		/// designation in later versions.
		/// </summary>
		PP_VERSION = 0x5,
	}

	/// <summary>
	/// <para>
	/// The CryptAcquireContext function is used to acquire a handle to a particular key container within a particular cryptographic service
	/// provider (CSP). This returned handle is used in calls to CryptoAPI functions that use the selected CSP.
	/// </para>
	/// <para>
	/// This function first attempts to find a CSP with the characteristics described in the dwProvType and pszProvider parameters. If the
	/// CSP is found, the function attempts to find a key container within the CSP that matches the name specified by the pszContainer
	/// parameter. To acquire the context and the key container of a private key associated with the public key of a certificate, use CryptAcquireCertificatePrivateKey.
	/// </para>
	/// <para>
	/// With the appropriate setting of dwFlags, this function can also create and destroy key containers and can provide access to a CSP
	/// with a temporary key container if access to a private key is not required.
	/// </para>
	/// </summary>
	/// <param name="phProv">
	/// A pointer to a handle of a CSP. When you have finished using the CSP, release the handle by calling the CryptReleaseContext function.
	/// </param>
	/// <param name="szContainer">
	/// <para>
	/// The key container name. This is a null-terminated string that identifies the key container to the CSP. This name is independent of
	/// the method used to store the keys. Some CSPs store their key containers internally (in hardware), some use the system registry, and
	/// others use the file system. In most cases, when dwFlags is set to CRYPT_VERIFYCONTEXT, pszContainer must be set to <c>NULL</c>.
	/// However, for hardware-based CSPs, such as a smart card CSP, can be access publically available information in the specfied container.
	/// </para>
	/// <para>For more information about the usage of the pszContainer parameter, see Remarks.</para>
	/// </param>
	/// <param name="szProvider">
	/// <para>A null-terminated string that contains the name of the CSP to be used.</para>
	/// <para>
	/// If this parameter is <c>NULL</c>, the user default provider is used. For more information, see Cryptographic Service Provider
	/// Contexts. For a list of available cryptographic providers, see Cryptographic Provider Names.
	/// </para>
	/// <para>
	/// An application can obtain the name of the CSP in use by using the CryptGetProvParam function to read the PP_NAME CSP value in the
	/// dwParam parameter.
	/// </para>
	/// <para>
	/// The default CSP can change between operating system releases. To ensure interoperability on different operating system platforms, the
	/// CSP should be explicitly set by using this parameter instead of using the default CSP.
	/// </para>
	/// </param>
	/// <param name="dwProvType">
	/// Specifies the type of provider to acquire. Defined provider types are discussed in Cryptographic Provider Types.
	/// </param>
	/// <param name="dwFlags">
	/// <para>Flag values. This parameter is usually set to zero, but some applications set one or more of the following flags.</para>
	/// <list type="table">
	/// <listheader>
	/// <term>Value</term>
	/// <term>Meaning</term>
	/// </listheader>
	/// <item>
	/// <term>CRYPT_VERIFYCONTEXT</term>
	/// <term>
	/// This option is intended for applications that are using ephemeral keys, or applications that do not require access to persisted
	/// private keys, such as applications that perform only hashing, encryption, and digital signature verification. Only applications that
	/// create signatures or decrypt messages need access to a private key. In most cases, this flag should be set. For file-based CSPs, when
	/// this flag is set, the pszContainer parameter must be set to NULL. The application has no access to the persisted private keys of
	/// public/private key pairs. When this flag is set, temporary public/private key pairs can be created, but they are not persisted. For
	/// hardware-based CSPs, such as a smart card CSP, if the pszContainer parameter is NULL or blank, this flag implies that no access to
	/// any keys is required, and that no UI should be presented to the user. This form is used to connect to the CSP to query its
	/// capabilities but not to actually use its keys. If the pszContainer parameter is not NULL and not blank, then this flag implies that
	/// access to only the publicly available information within the specified container is required. The CSP should not ask for a PIN.
	/// Attempts to access private information (for example, the CryptSignHash function) will fail. When CryptAcquireContext is called, many
	/// CSPs require input from the owning user before granting access to the private keys in the key container. For example, the private
	/// keys can be encrypted, requiring a password from the user before they can be used. However, if the CRYPT_VERIFYCONTEXT flag is
	/// specified, access to the private keys is not required and the user interface can be bypassed.
	/// </term>
	/// </item>
	/// <item>
	/// <term>CRYPT_NEWKEYSET</term>
	/// <term>
	/// Creates a new key container with the name specified by pszContainer. If pszContainer is NULL, a key container with the default name
	/// is created.
	/// </term>
	/// </item>
	/// <item>
	/// <term>CRYPT_MACHINE_KEYSET</term>
	/// <term>
	/// By default, keys and key containers are stored as user keys. For Base Providers, this means that user key containers are stored in
	/// the user's profile. A key container created without this flag by an administrator can be accessed only by the user creating the key
	/// container and a user with administration privileges. Windows XP: A key container created without this flag by an administrator can be
	/// accessed only by the user creating the key container and the local system account. A key container created without this flag by a
	/// user that is not an administrator can be accessed only by the user creating the key container and the local system account. The
	/// CRYPT_MACHINE_KEYSET flag can be combined with all of the other flags to indicate that the key container of interest is a computer
	/// key container and the CSP treats it as such. For Base Providers, this means that the keys are stored locally on the computer that
	/// created the key container. If a key container is to be a computer container, the CRYPT_MACHINE_KEYSET flag must be used with all
	/// calls to CryptAcquireContext that reference the computer container. The key container created with CRYPT_MACHINE_KEYSET by an
	/// administrator can be accessed only by its creator and by a user with administrator privileges unless access rights to the container
	/// are granted using CryptSetProvParam. Windows XP: The key container created with CRYPT_MACHINE_KEYSET by an administrator can be
	/// accessed only by its creator and by the local system account unless access rights to the container are granted using
	/// CryptSetProvParam. The key container created with CRYPT_MACHINE_KEYSET by a user that is not an administrator can be accessed only by
	/// its creator and by the local system account unless access rights to the container are granted using CryptSetProvParam. The
	/// CRYPT_MACHINE_KEYSET flag is useful when the user is accessing from a service or user account that did not log on interactively. When
	/// key containers are created, most CSPs do not automatically create any public/private key pairs. These keys must be created as a
	/// separate step with the CryptGenKey function.
	/// </term>
	/// </item>
	/// <item>
	/// <term>CRYPT_DELETEKEYSET</term>
	/// <term>
	/// Delete the key container specified by pszContainer. If pszContainer is NULL, the key container with the default name is deleted. All
	/// key pairs in the key container are also destroyed. When this flag is set, the value returned in phProv is undefined, and thus, the
	/// CryptReleaseContext function need not be called afterward.
	/// </term>
	/// </item>
	/// <item>
	/// <term>CRYPT_SILENT</term>
	/// <term>
	/// The application requests that the CSP not display any user interface (UI) for this context. If the CSP must display the UI to
	/// operate, the call fails and the NTE_SILENT_CONTEXT error code is set as the last error. In addition, if calls are made to CryptGenKey
	/// with the CRYPT_USER_PROTECTED flag with a context that has been acquired with the CRYPT_SILENT flag, the calls fail and the CSP sets
	/// NTE_SILENT_CONTEXT. CRYPT_SILENT is intended for use with applications for which the UI cannot be displayed by the CSP.
	/// </term>
	/// </item>
	/// <item>
	/// <term>CRYPT_DEFAULT_CONTAINER_OPTIONAL</term>
	/// <term>
	/// Obtains a context for a smart card CSP that can be used for hashing and symmetric key operations but cannot be used for any operation
	/// that requires authentication to a smart card using a PIN. This type of context is most often used to perform operations on an empty
	/// smart card, such as setting the PIN by using CryptSetProvParam. This flag can only be used with smart card CSPs. Windows Server 2003
	/// and Windows XP: This flag is not supported.
	/// </term>
	/// </item>
	/// </list>
	/// </param>
	/// <returns>
	/// <para>If the function succeeds, the function returns nonzero ( <c>TRUE</c>).</para>
	/// <para>If the function fails, it returns zero ( <c>FALSE</c>). For extended error information, call GetLastError.</para>
	/// <para>
	/// The error codes prefaced by NTE are generated by the particular CSP being used. Some possible error codes defined in Winerror.h follow.
	/// </para>
	/// <list type="table">
	/// <listheader>
	/// <term>Return code/value</term>
	/// <term>Description</term>
	/// </listheader>
	/// <item>
	/// <term>ERROR_BUSY 107L</term>
	/// <term>Some CSPs set this error if the CRYPT_DELETEKEYSET flag value is set and another thread or process is using this key container.</term>
	/// </item>
	/// <item>
	/// <term>ERROR_FILE_NOT_FOUND 2L</term>
	/// <term>
	/// The profile of the user is not loaded and cannot be found. This happens when the application impersonates a user, for example, the
	/// IUSR_ComputerName account.
	/// </term>
	/// </item>
	/// <item>
	/// <term>ERROR_INVALID_PARAMETER 87L</term>
	/// <term>One of the parameters contains a value that is not valid. This is most often a pointer that is not valid.</term>
	/// </item>
	/// <item>
	/// <term>ERROR_NOT_ENOUGH_MEMORY 8L</term>
	/// <term>The operating system ran out of memory during the operation.</term>
	/// </item>
	/// <item>
	/// <term>NTE_BAD_FLAGS 0x80090009L</term>
	/// <term>The dwFlags parameter has a value that is not valid.</term>
	/// </item>
	/// <item>
	/// <term>NTE_BAD_KEY_STATE 0x8009000BL</term>
	/// <term>The user password has changed since the private keys were encrypted.</term>
	/// </item>
	/// <item>
	/// <term>NTE_BAD_KEYSET 0x80090016L</term>
	/// <term>
	/// The key container could not be opened. A common cause of this error is that the key container does not exist. To create a key
	/// container, call CryptAcquireContext using the CRYPT_NEWKEYSET flag. This error code can also indicate that access to an existing key
	/// container is denied. Access rights to the container can be granted by the key set creator by using CryptSetProvParam.
	/// </term>
	/// </item>
	/// <item>
	/// <term>NTE_BAD_KEYSET_PARAM 0x8009001FL</term>
	/// <term>The pszContainer or pszProvider parameter is set to a value that is not valid.</term>
	/// </item>
	/// <item>
	/// <term>NTE_BAD_PROV_TYPE 0x80090014L</term>
	/// <term>The value of the dwProvType parameter is out of range. All provider types must be from 1 through 999, inclusive.</term>
	/// </item>
	/// <item>
	/// <term>NTE_BAD_SIGNATURE 0x80090006L</term>
	/// <term>The provider DLL signature could not be verified. Either the DLL or the digital signature has been tampered with.</term>
	/// </item>
	/// <item>
	/// <term>NTE_EXISTS 0x8009000FL</term>
	/// <term>The dwFlags parameter is CRYPT_NEWKEYSET, but the key container already exists.</term>
	/// </item>
	/// <item>
	/// <term>NTE_KEYSET_ENTRY_BAD 0x8009001AL</term>
	/// <term>The pszContainer key container was found but is corrupt.</term>
	/// </item>
	/// <item>
	/// <term>NTE_KEYSET_NOT_DEF 0x80090019L</term>
	/// <term>The requested provider does not exist.</term>
	/// </item>
	/// <item>
	/// <term>NTE_NO_MEMORY 0x8009000EL</term>
	/// <term>The CSP ran out of memory during the operation.</term>
	/// </item>
	/// <item>
	/// <term>NTE_PROV_DLL_NOT_FOUND 0x8009001EL</term>
	/// <term>The provider DLL file does not exist or is not on the current path.</term>
	/// </item>
	/// <item>
	/// <term>NTE_PROV_TYPE_ENTRY_BAD 0x80090018L</term>
	/// <term>
	/// The provider type specified by dwProvType is corrupt. This error can relate to either the user default CSP list or the computer
	/// default CSP list.
	/// </term>
	/// </item>
	/// <item>
	/// <term>NTE_PROV_TYPE_NO_MATCH 0x8009001BL</term>
	/// <term>
	/// The provider type specified by dwProvType does not match the provider type found. Note that this error can only occur when
	/// pszProvider specifies an actual CSP name.
	/// </term>
	/// </item>
	/// <item>
	/// <term>NTE_PROV_TYPE_NOT_DEF 0x80090017L</term>
	/// <term>No entry exists for the provider type specified by dwProvType.</term>
	/// </item>
	/// <item>
	/// <term>NTE_PROVIDER_DLL_FAIL 0x8009001DL</term>
	/// <term>The provider DLL file could not be loaded or failed to initialize.</term>
	/// </item>
	/// <item>
	/// <term>NTE_SIGNATURE_FILE_BAD 0x8009001CL</term>
	/// <term>An error occurred while loading the DLL file image, prior to verifying its signature.</term>
	/// </item>
	/// </list>
	/// </returns>
	/// <remarks>
	/// <para>
	/// The pszContainer parameter specifies the name of the container that is used to hold the key. Each container can contain one key. If
	/// you specify the name of an existing container when creating keys, the new key will overwrite a previous one.
	/// </para>
	/// <para>
	/// The combination of the CSP name and the key container name uniquely identifies a single key on the system. If one application tries
	/// to modify a key container while another application is using it, unpredictable behavior may result.
	/// </para>
	/// <para>
	/// If you set the pszContainer parameter to <c>NULL</c>, the default key container name is used. When the Microsoft software CSPs are
	/// called in this manner, a new container is created each time the <c>CryptAcquireContext</c> function is called. However, different
	/// CSPs may behave differently in this regard. In particular, a CSP may have a single default container that is shared by all
	/// applications accessing the CSP. Therefore, applications must not use the default key container to store private keys. Instead, either
	/// prevent key storage by passing the <c>CRYPT_VERIFYCONTEXT</c> flag in the dwFlags parameter, or use an application-specific container
	/// that is unlikely to be used by another application.
	/// </para>
	/// <para>
	/// An application can obtain the name of the key container in use by using the CryptGetProvParam function to read the PP_CONTAINER value.
	/// </para>
	/// <para>
	/// For performance reasons, we recommend that you set the pszContainer parameter to <c>NULL</c> and the dwFlags parameter to
	/// <c>CRYPT_VERIFYCONTEXT</c> in all situations where you do not require a persisted key. In particular, consider setting the
	/// pszContainer parameter to <c>NULL</c> and the dwFlags parameter to <c>CRYPT_VERIFYCONTEXT</c> for the following scenarios:
	/// </para>
	/// <list type="bullet">
	/// <item>
	/// <term>You are creating a hash.</term>
	/// </item>
	/// <item>
	/// <term>You are generating a symmetric key to encrypt or decrypt data.</term>
	/// </item>
	/// <item>
	/// <term>You are deriving a symmetric key from a hash to encrypt or decrypt data.</term>
	/// </item>
	/// <item>
	/// <term>
	/// You are verifying a signature. It is possible to import a public key from a PUBLICKEYBLOB or from a certificate by using
	/// CryptImportKey or CryptImportPublicKeyInfo. A context can be acquired by using the <c>CRYPT_VERIFYCONTEXT</c> flag if you only plan
	/// to import the public key.
	/// </term>
	/// </item>
	/// <item>
	/// <term>
	/// You plan to export a symmetric key, but not import it within the crypto context's lifetime. A context can be acquired by using the
	/// <c>CRYPT_VERIFYCONTEXT</c> flag if you only plan to import the public key for the last two scenarios.
	/// </term>
	/// </item>
	/// <item>
	/// <term>You are performing private key operations, but you are not using a persisted private key that is stored in a key container.</term>
	/// </item>
	/// </list>
	/// <para>
	/// If you plan to perform private key operations, the best way to acquire a context is to try to open the container. If this attempt
	/// fails with NTE_BAD_KEYSET, then create the container by using the <c>CRYPT_NEWKEYSET</c> flag.
	/// </para>
	/// <para>Examples</para>
	/// <para>
	/// The following example shows acquiring a cryptographic context and access to public/private key pairs in a key container. If the
	/// requested key container does not exist, it is created.
	/// </para>
	/// <para>
	/// For an example that includes the complete context for this example, see Example C Program: Creating a Key Container and Generating
	/// Keys. For additional examples, see Example C Program: Using CryptAcquireContext.
	/// </para>
	/// </remarks>
	// https://docs.microsoft.com/en-us/windows/win32/api/wincrypt/nf-wincrypt-cryptacquirecontexta BOOL CryptAcquireContextA( HCRYPTPROV
	// *phProv, LPCSTR szContainer, LPCSTR szProvider, DWORD dwProvType, DWORD dwFlags );
	[DllImport(Lib.AdvApi32, SetLastError = true, CharSet = CharSet.Auto)]
	[PInvokeData("wincrypt.h", MSDNShortId = "57e13662-3189-4f8d-b90a-d1fbdc09b63c")]
	[return: MarshalAs(UnmanagedType.Bool)]
	public static extern bool CryptAcquireContext(out SafeHCRYPTPROV phProv, [Optional, MarshalAs(UnmanagedType.LPTStr)] string? szContainer, [Optional, MarshalAs(UnmanagedType.LPTStr)] string? szProvider, uint dwProvType, CryptAcquireContextFlags dwFlags);

	/// <summary>
	/// The CryptContextAddRef function adds one to the reference count of an HCRYPTPROV cryptographic service provider (CSP) handle. This
	/// function should be used if the CSP handle is included as a member of any structure passed to another function. The
	/// CryptReleaseContext function should be called when the CSP handle is no longer needed.
	/// </summary>
	/// <param name="hProv">
	/// HCRYPTPROV handle for which the reference count is being incremented. This handle must have already been created using CryptAcquireContext.
	/// </param>
	/// <param name="pdwReserved">Reserved for future use and must be <c>NULL</c>.</param>
	/// <param name="dwFlags">Reserved for future use and must be zero.</param>
	/// <returns>
	/// <para>If the function succeeds, the return value is nonzero (TRUE).</para>
	/// <para>
	/// If the function fails, the return value is zero (FALSE). For extended error information, call GetLastError. One possible error code
	/// is the following.
	/// </para>
	/// <list type="table">
	/// <listheader>
	/// <term>Return code</term>
	/// <term>Description</term>
	/// </listheader>
	/// <item>
	/// <term>ERROR_INVALID_PARAMETER</term>
	/// <term>One of the parameters contains a value that is not valid. This is most often a pointer that is not valid.</term>
	/// </item>
	/// </list>
	/// </returns>
	/// <remarks>
	/// <para>
	/// This function increases the reference count on a HCRYPTPROV handle so that multiple calls to CryptReleaseContext are required to
	/// actually release the handle.
	/// </para>
	/// <para>Examples</para>
	/// <para>The following example increments the reference count on an acquired CSP handle.</para>
	/// <para>For another example that uses this function, see Example C Program: Using CryptAcquireContext.</para>
	/// </remarks>
	// https://docs.microsoft.com/en-us/windows/win32/api/wincrypt/nf-wincrypt-cryptcontextaddref BOOL CryptContextAddRef( HCRYPTPROV hProv,
	// DWORD *pdwReserved, DWORD dwFlags );
	[DllImport(Lib.AdvApi32, SetLastError = true, ExactSpelling = true)]
	[PInvokeData("wincrypt.h", MSDNShortId = "074666a7-369c-43bc-97d9-3bcc9703976b")]
	[return: MarshalAs(UnmanagedType.Bool)]
	public static extern bool CryptContextAddRef(HCRYPTPROV hProv, IntPtr pdwReserved = default, uint dwFlags = 0);

	/// <summary>
	/// The CryptCreateHash function initiates the hashing of a stream of data. It creates and returns to the calling application a handle to
	/// a cryptographic service provider (CSP) hash object. This handle is used in subsequent calls to CryptHashData and CryptHashSessionKey
	/// to hash session keys and other streams of data.
	/// </summary>
	/// <param name="hProv">A handle to a CSP created by a call to CryptAcquireContext.</param>
	/// <param name="Algid">
	/// <para>An ALG_ID value that identifies the hash algorithm to use.</para>
	/// <para>Valid values for this parameter vary, depending on the CSP that is used. For a list of default algorithms, see Remarks.</para>
	/// </param>
	/// <param name="hKey">
	/// <para>
	/// If the type of hash algorithm is a keyed hash, such as the Hash-Based Message Authentication Code (HMAC) or Message Authentication
	/// Code (MAC) algorithm, the key for the hash is passed in this parameter. For nonkeyed algorithms, this parameter must be set to zero.
	/// </para>
	/// <para>For keyed algorithms, the key must be to a block cipher key, such as RC2, that has a cipher mode of Cipher Block Chaining (CBC).</para>
	/// </param>
	/// <param name="dwFlags">
	/// <para>The following flag value is defined.</para>
	/// <list type="table">
	/// <listheader>
	/// <term>Value</term>
	/// <term>Meaning</term>
	/// </listheader>
	/// <item>
	/// <term>CRYPT_SECRETDIGEST 0x00000001</term>
	/// <term>This flag is not used.</term>
	/// </item>
	/// </list>
	/// </param>
	/// <param name="phHash">
	/// The address to which the function copies a handle to the new hash object. When you have finished using the hash object, release the
	/// handle by calling the CryptDestroyHash function.
	/// </param>
	/// <returns>
	/// <para>If the function succeeds, the function returns <c>TRUE</c>.</para>
	/// <para>If the function fails, it returns <c>FALSE</c>. For extended error information, call GetLastError.</para>
	/// <para>
	/// The error codes prefaced by NTE are generated by the particular CSP you are using. The following table shows some of the possible
	/// error codes.
	/// </para>
	/// <list type="table">
	/// <listheader>
	/// <term>Return code</term>
	/// <term>Description</term>
	/// </listheader>
	/// <item>
	/// <term>ERROR_INVALID_HANDLE</term>
	/// <term>One of the parameters specifies a handle that is not valid.</term>
	/// </item>
	/// <item>
	/// <term>ERROR_INVALID_PARAMETER</term>
	/// <term>One of the parameters contains a value that is not valid. This is most often a pointer that is not valid.</term>
	/// </item>
	/// <item>
	/// <term>ERROR_NOT_ENOUGH_MEMORY</term>
	/// <term>The operating system ran out of memory during the operation.</term>
	/// </item>
	/// <item>
	/// <term>NTE_BAD_ALGID</term>
	/// <term>The Algid parameter specifies an algorithm that this CSP does not support.</term>
	/// </item>
	/// <item>
	/// <term>NTE_BAD_FLAGS</term>
	/// <term>The dwFlags parameter is nonzero.</term>
	/// </item>
	/// <item>
	/// <term>NTE_BAD_KEY</term>
	/// <term>
	/// A keyed hash algorithm, such as CALG_MAC, is specified by Algid, and the hKey parameter is either zero or it specifies a key handle
	/// that is not valid. This error code is also returned if the key is to a stream cipher or if the cipher mode is anything other than CBC.
	/// </term>
	/// </item>
	/// <item>
	/// <term>NTE_NO_MEMORY</term>
	/// <term>The CSP ran out of memory during the operation.</term>
	/// </item>
	/// </list>
	/// </returns>
	/// <remarks>
	/// <para>For a list of Microsoft service providers and the algorithms they implement, see Microsoft Cryptographic Service Providers.</para>
	/// <para>
	/// The computation of the actual hash is done with the CryptHashData and CryptHashSessionKey functions. These require a handle to the
	/// hash object. After all the data has been added to the hash object, any of the following operations can be performed:
	/// </para>
	/// <list type="bullet">
	/// <item>
	/// <term>The hash value can be retrieved by using CryptGetHashParam.</term>
	/// </item>
	/// <item>
	/// <term>A session key can be derived by using CryptDeriveKey.</term>
	/// </item>
	/// <item>
	/// <term>The hash can be signed by using CryptSignHash.</term>
	/// </item>
	/// <item>
	/// <term>A signature can be verified by using CryptVerifySignature.</term>
	/// </item>
	/// </list>
	/// <para>After one of the functions from this list has been called, CryptHashData and CryptHashSessionKey cannot be called.</para>
	/// <para>Examples</para>
	/// <para>
	/// The following example shows initiating the hashing of a stream of data. It creates and returns to the calling application a handle to
	/// a hash object. This handle is used in subsequent calls to CryptHashData and CryptHashSessionKey to hash any stream of data. For an
	/// example that includes the complete context for this example, see Example C Program: Creating and Hashing a Session Key. For another
	/// example that uses this function, see Example C Program: Signing a Hash and Verifying the Hash Signature.
	/// </para>
	/// </remarks>
	// https://docs.microsoft.com/en-us/windows/win32/api/wincrypt/nf-wincrypt-cryptcreatehash BOOL CryptCreateHash( HCRYPTPROV hProv, ALG_ID
	// Algid, HCRYPTKEY hKey, DWORD dwFlags, HCRYPTHASH *phHash );
	[DllImport(Lib.AdvApi32, SetLastError = true, ExactSpelling = true)]
	[PInvokeData("wincrypt.h", MSDNShortId = "05e3db57-8d83-48e2-8590-68039ea27253")]
	[return: MarshalAs(UnmanagedType.Bool)]
	public static extern bool CryptCreateHash(HCRYPTPROV hProv, ALG_ID Algid, HCRYPTKEY hKey, [Optional] uint dwFlags, out SafeHCRYPTHASH phHash);

	/// <summary>
	/// <para>The CryptDecrypt function decrypts data previously encrypted by using the CryptEncrypt function.</para>
	/// <para>
	/// Important changes to support Secure/Multipurpose Internet Mail Extensions (S/MIME) email interoperability have been made to CryptoAPI
	/// that affect the handling of enveloped messages. For more information, see the Remarks section of CryptMsgOpenToEncode.
	/// </para>
	/// </summary>
	/// <param name="hKey">
	/// <para>
	/// A handle to the key to use for the decryption. An application obtains this handle by using either the CryptGenKey or CryptImportKey function.
	/// </para>
	/// <para>This key specifies the decryption algorithm to be used.</para>
	/// </param>
	/// <param name="hHash">
	/// <para>
	/// A handle to a hash object. If data is to be decrypted and hashed simultaneously, a handle to a hash object is passed in this
	/// parameter. The hash value is updated with the decrypted plaintext. This option is useful when simultaneously decrypting and verifying
	/// a signature.
	/// </para>
	/// <para>
	/// Before calling <c>CryptDecrypt</c>, the application must obtain a handle to the hash object by calling the CryptCreateHash function.
	/// After the decryption is complete, the hash value can be obtained by using the CryptGetHashParam function, it can also be signed by
	/// using the CryptSignHash function, or it can be used to verify a digital signature by using the CryptVerifySignature function.
	/// </para>
	/// <para>If no hash is to be done, this parameter must be zero.</para>
	/// </param>
	/// <param name="Final">
	/// A Boolean value that specifies whether this is the last section in a series being decrypted. This value is <c>TRUE</c> if this is the
	/// last or only block. If this is not the last block, this value is <c>FALSE</c>. For more information, see Remarks.
	/// </param>
	/// <param name="dwFlags">
	/// <para>The following flag values are defined.</para>
	/// <list type="table">
	/// <listheader>
	/// <term>Value</term>
	/// <term>Meaning</term>
	/// </listheader>
	/// <item>
	/// <term>CRYPT_OAEP 0x00000040</term>
	/// <term>
	/// Use Optimal Asymmetric Encryption Padding (OAEP) (PKCS #1 version 2). This flag is only supported by the Microsoft Enhanced
	/// Cryptographic Provider with RSA encryption/decryption. This flag cannot be combined with the CRYPT_DECRYPT_RSA_NO_PADDING_CHECK flag.
	/// </term>
	/// </item>
	/// <item>
	/// <term>CRYPT_DECRYPT_RSA_NO_PADDING_CHECK 0x00000020</term>
	/// <term>
	/// Perform the decryption on the BLOB without checking the padding. This flag is only supported by the Microsoft Enhanced Cryptographic
	/// Provider with RSA encryption/decryption. This flag cannot be combined with the CRYPT_OAEP flag.
	/// </term>
	/// </item>
	/// </list>
	/// </param>
	/// <param name="pbData">
	/// <para>
	/// A pointer to a buffer that contains the data to be decrypted. After the decryption has been performed, the plaintext is placed back
	/// into this same buffer.
	/// </para>
	/// <para>The number of encrypted bytes in this buffer is specified by pdwDataLen.</para>
	/// </param>
	/// <param name="pdwDataLen">
	/// <para>
	/// A pointer to a <c>DWORD</c> value that indicates the length of the pbData buffer. Before calling this function, the calling
	/// application sets the <c>DWORD</c> value to the number of bytes to be decrypted. Upon return, the <c>DWORD</c> value contains the
	/// number of bytes of the decrypted plaintext.
	/// </para>
	/// <para>
	/// When a block cipher is used, this data length must be a multiple of the block size unless this is the final section of data to be
	/// decrypted and the Final parameter is <c>TRUE</c>.
	/// </para>
	/// </param>
	/// <returns>
	/// <para>If the function succeeds, the function returns nonzero ( <c>TRUE</c>).</para>
	/// <para>If the function fails, it returns zero ( <c>FALSE</c>). For extended error information, call GetLastError.</para>
	/// <para>The error codes prefaced by NTE are generated by the particular CSP being used. Some possible error codes follow.</para>
	/// <list type="table">
	/// <listheader>
	/// <term>Value</term>
	/// <term>Description</term>
	/// </listheader>
	/// <item>
	/// <term>ERROR_INVALID_HANDLE</term>
	/// <term>One of the parameters specifies a handle that is not valid.</term>
	/// </item>
	/// <item>
	/// <term>ERROR_INVALID_PARAMETER</term>
	/// <term>One of the parameters contains a value that is not valid. This is most often a pointer that is not valid.</term>
	/// </item>
	/// <item>
	/// <term>NTE_BAD_ALGID</term>
	/// <term>The hKey session key specifies an algorithm that this CSP does not support.</term>
	/// </item>
	/// <item>
	/// <term>NTE_BAD_DATA</term>
	/// <term>
	/// The data to be decrypted is not valid. For example, when a block cipher is used and the Final flag is FALSE, the value specified by
	/// pdwDataLen must be a multiple of the block size. This error can also be returned when the padding is found to be not valid.
	/// </term>
	/// </item>
	/// <item>
	/// <term>NTE_BAD_FLAGS</term>
	/// <term>The dwFlags parameter is nonzero.</term>
	/// </item>
	/// <item>
	/// <term>NTE_BAD_HASH</term>
	/// <term>The hHash parameter contains a handle that is not valid.</term>
	/// </item>
	/// <item>
	/// <term>NTE_BAD_KEY</term>
	/// <term>The hKey parameter does not contain a valid handle to a key.</term>
	/// </item>
	/// <item>
	/// <term>NTE_BAD_LEN</term>
	/// <term>The size of the output buffer is too small to hold the generated plaintext.</term>
	/// </item>
	/// <item>
	/// <term>NTE_BAD_UID</term>
	/// <term>The CSP context that was specified when the key was created cannot be found.</term>
	/// </item>
	/// <item>
	/// <term>NTE_DOUBLE_ENCRYPT</term>
	/// <term>The application attempted to decrypt the same data twice.</term>
	/// </item>
	/// <item>
	/// <term>NTE_FAIL</term>
	/// <term>The function failed in some unexpected way.</term>
	/// </item>
	/// </list>
	/// </returns>
	/// <remarks>
	/// <para>
	/// If a large amount of data is to be decrypted, it can be done in sections by calling <c>CryptDecrypt</c> repeatedly. The Final
	/// parameter must be set to <c>TRUE</c> only on the last call to <c>CryptDecrypt</c>, so that the decryption engine can properly finish
	/// the decryption process. The following extra actions are performed when Final is <c>TRUE</c>:
	/// </para>
	/// <list type="bullet">
	/// <item>
	/// <term>
	/// If the key is a block cipher key, the data is padded to a multiple of the block size of the cipher. To find the block size of a
	/// cipher, use CryptGetKeyParam to get the KP_BLOCKLEN value of the key.
	/// </term>
	/// </item>
	/// <item>
	/// <term>
	/// If the cipher is operating in a chaining mode, the next <c>CryptDecrypt</c> operation resets the cipher's feedback register to the
	/// KP_IV value of the key.
	/// </term>
	/// </item>
	/// <item>
	/// <term>If the cipher is a stream cipher, the next <c>CryptDecrypt</c> call resets the cipher to its initial state.</term>
	/// </item>
	/// </list>
	/// <para>
	/// There is no way to set the cipher's feedback register to the KP_IV value of the key without setting the Final parameter to
	/// <c>TRUE</c>. If this is necessary, as in the case where you do not want to add an additional padding block or change the size of each
	/// block, you can simulate this by creating a duplicate of the original key by using the CryptDuplicateKey function, and passing the
	/// duplicate key to the <c>CryptDecrypt</c> function. This causes the KP_IV of the original key to be placed in the duplicate key. After
	/// you create or import the original key, you cannot use the original key for encryption because the feedback register of the key will
	/// be changed. The following pseudocode shows how this can be done.
	/// </para>
	/// <para>
	/// The Microsoft Enhanced Cryptographic Provider supports direct encryption with RSA public keys and decryption with RSA private keys.
	/// The encryption uses PKCS #1 padding. On decryption, this padding is verified. The length of ciphertext data to be decrypted must be
	/// the same length as the modulus of the RSA key used to decrypt the data. If the ciphertext has zeros in the most significant bytes,
	/// these bytes must be included in the input data buffer and in the input buffer length. The ciphertext must be in little-endian format.
	/// </para>
	/// <para>Examples</para>
	/// <para>For an example that uses this function, see Example C Program: Decrypting a File.</para>
	/// </remarks>
	// https://docs.microsoft.com/en-us/windows/win32/api/wincrypt/nf-wincrypt-cryptdecrypt BOOL CryptDecrypt( HCRYPTKEY hKey, HCRYPTHASH
	// hHash, BOOL Final, DWORD dwFlags, BYTE *pbData, DWORD *pdwDataLen );
	[DllImport(Lib.AdvApi32, SetLastError = true, ExactSpelling = true)]
	[PInvokeData("wincrypt.h", MSDNShortId = "7c3d2838-6fd1-4f6c-9586-8b94b459a31a")]
	[return: MarshalAs(UnmanagedType.Bool)]
	public static extern bool CryptDecrypt(HCRYPTKEY hKey, [Optional] HCRYPTHASH hHash, [MarshalAs(UnmanagedType.Bool)] bool Final, CryptDecryptFlags dwFlags, [In, Out] IntPtr pbData, ref uint pdwDataLen);

	/// <summary>
	/// <para>The CryptDecrypt function decrypts data previously encrypted by using the CryptEncrypt function.</para>
	/// <para>
	/// Important changes to support Secure/Multipurpose Internet Mail Extensions (S/MIME) email interoperability have been made to CryptoAPI
	/// that affect the handling of enveloped messages. For more information, see the Remarks section of CryptMsgOpenToEncode.
	/// </para>
	/// </summary>
	/// <param name="hKey">
	/// <para>
	/// A handle to the key to use for the decryption. An application obtains this handle by using either the CryptGenKey or CryptImportKey function.
	/// </para>
	/// <para>This key specifies the decryption algorithm to be used.</para>
	/// </param>
	/// <param name="hHash">
	/// <para>
	/// A handle to a hash object. If data is to be decrypted and hashed simultaneously, a handle to a hash object is passed in this
	/// parameter. The hash value is updated with the decrypted plaintext. This option is useful when simultaneously decrypting and verifying
	/// a signature.
	/// </para>
	/// <para>
	/// Before calling <c>CryptDecrypt</c>, the application must obtain a handle to the hash object by calling the CryptCreateHash function.
	/// After the decryption is complete, the hash value can be obtained by using the CryptGetHashParam function, it can also be signed by
	/// using the CryptSignHash function, or it can be used to verify a digital signature by using the CryptVerifySignature function.
	/// </para>
	/// <para>If no hash is to be done, this parameter must be zero.</para>
	/// </param>
	/// <param name="Final">
	/// A Boolean value that specifies whether this is the last section in a series being decrypted. This value is <c>TRUE</c> if this is the
	/// last or only block. If this is not the last block, this value is <c>FALSE</c>. For more information, see Remarks.
	/// </param>
	/// <param name="dwFlags">
	/// <para>The following flag values are defined.</para>
	/// <list type="table">
	/// <listheader>
	/// <term>Value</term>
	/// <term>Meaning</term>
	/// </listheader>
	/// <item>
	/// <term>CRYPT_OAEP 0x00000040</term>
	/// <term>
	/// Use Optimal Asymmetric Encryption Padding (OAEP) (PKCS #1 version 2). This flag is only supported by the Microsoft Enhanced
	/// Cryptographic Provider with RSA encryption/decryption. This flag cannot be combined with the CRYPT_DECRYPT_RSA_NO_PADDING_CHECK flag.
	/// </term>
	/// </item>
	/// <item>
	/// <term>CRYPT_DECRYPT_RSA_NO_PADDING_CHECK 0x00000020</term>
	/// <term>
	/// Perform the decryption on the BLOB without checking the padding. This flag is only supported by the Microsoft Enhanced Cryptographic
	/// Provider with RSA encryption/decryption. This flag cannot be combined with the CRYPT_OAEP flag.
	/// </term>
	/// </item>
	/// </list>
	/// </param>
	/// <param name="pbData">
	/// <para>
	/// A pointer to a buffer that contains the data to be decrypted. After the decryption has been performed, the plaintext is placed back
	/// into this same buffer.
	/// </para>
	/// <para>The number of encrypted bytes in this buffer is specified by pdwDataLen.</para>
	/// </param>
	/// <param name="pdwDataLen">
	/// <para>
	/// A pointer to a <c>DWORD</c> value that indicates the length of the pbData buffer. Before calling this function, the calling
	/// application sets the <c>DWORD</c> value to the number of bytes to be decrypted. Upon return, the <c>DWORD</c> value contains the
	/// number of bytes of the decrypted plaintext.
	/// </para>
	/// <para>
	/// When a block cipher is used, this data length must be a multiple of the block size unless this is the final section of data to be
	/// decrypted and the Final parameter is <c>TRUE</c>.
	/// </para>
	/// </param>
	/// <returns>
	/// <para>If the function succeeds, the function returns nonzero ( <c>TRUE</c>).</para>
	/// <para>If the function fails, it returns zero ( <c>FALSE</c>). For extended error information, call GetLastError.</para>
	/// <para>The error codes prefaced by NTE are generated by the particular CSP being used. Some possible error codes follow.</para>
	/// <list type="table">
	/// <listheader>
	/// <term>Value</term>
	/// <term>Description</term>
	/// </listheader>
	/// <item>
	/// <term>ERROR_INVALID_HANDLE</term>
	/// <term>One of the parameters specifies a handle that is not valid.</term>
	/// </item>
	/// <item>
	/// <term>ERROR_INVALID_PARAMETER</term>
	/// <term>One of the parameters contains a value that is not valid. This is most often a pointer that is not valid.</term>
	/// </item>
	/// <item>
	/// <term>NTE_BAD_ALGID</term>
	/// <term>The hKey session key specifies an algorithm that this CSP does not support.</term>
	/// </item>
	/// <item>
	/// <term>NTE_BAD_DATA</term>
	/// <term>
	/// The data to be decrypted is not valid. For example, when a block cipher is used and the Final flag is FALSE, the value specified by
	/// pdwDataLen must be a multiple of the block size. This error can also be returned when the padding is found to be not valid.
	/// </term>
	/// </item>
	/// <item>
	/// <term>NTE_BAD_FLAGS</term>
	/// <term>The dwFlags parameter is nonzero.</term>
	/// </item>
	/// <item>
	/// <term>NTE_BAD_HASH</term>
	/// <term>The hHash parameter contains a handle that is not valid.</term>
	/// </item>
	/// <item>
	/// <term>NTE_BAD_KEY</term>
	/// <term>The hKey parameter does not contain a valid handle to a key.</term>
	/// </item>
	/// <item>
	/// <term>NTE_BAD_LEN</term>
	/// <term>The size of the output buffer is too small to hold the generated plaintext.</term>
	/// </item>
	/// <item>
	/// <term>NTE_BAD_UID</term>
	/// <term>The CSP context that was specified when the key was created cannot be found.</term>
	/// </item>
	/// <item>
	/// <term>NTE_DOUBLE_ENCRYPT</term>
	/// <term>The application attempted to decrypt the same data twice.</term>
	/// </item>
	/// <item>
	/// <term>NTE_FAIL</term>
	/// <term>The function failed in some unexpected way.</term>
	/// </item>
	/// </list>
	/// </returns>
	/// <remarks>
	/// <para>
	/// If a large amount of data is to be decrypted, it can be done in sections by calling <c>CryptDecrypt</c> repeatedly. The Final
	/// parameter must be set to <c>TRUE</c> only on the last call to <c>CryptDecrypt</c>, so that the decryption engine can properly finish
	/// the decryption process. The following extra actions are performed when Final is <c>TRUE</c>:
	/// </para>
	/// <list type="bullet">
	/// <item>
	/// <term>
	/// If the key is a block cipher key, the data is padded to a multiple of the block size of the cipher. To find the block size of a
	/// cipher, use CryptGetKeyParam to get the KP_BLOCKLEN value of the key.
	/// </term>
	/// </item>
	/// <item>
	/// <term>
	/// If the cipher is operating in a chaining mode, the next <c>CryptDecrypt</c> operation resets the cipher's feedback register to the
	/// KP_IV value of the key.
	/// </term>
	/// </item>
	/// <item>
	/// <term>If the cipher is a stream cipher, the next <c>CryptDecrypt</c> call resets the cipher to its initial state.</term>
	/// </item>
	/// </list>
	/// <para>
	/// There is no way to set the cipher's feedback register to the KP_IV value of the key without setting the Final parameter to
	/// <c>TRUE</c>. If this is necessary, as in the case where you do not want to add an additional padding block or change the size of each
	/// block, you can simulate this by creating a duplicate of the original key by using the CryptDuplicateKey function, and passing the
	/// duplicate key to the <c>CryptDecrypt</c> function. This causes the KP_IV of the original key to be placed in the duplicate key. After
	/// you create or import the original key, you cannot use the original key for encryption because the feedback register of the key will
	/// be changed. The following pseudocode shows how this can be done.
	/// </para>
	/// <para>
	/// The Microsoft Enhanced Cryptographic Provider supports direct encryption with RSA public keys and decryption with RSA private keys.
	/// The encryption uses PKCS #1 padding. On decryption, this padding is verified. The length of ciphertext data to be decrypted must be
	/// the same length as the modulus of the RSA key used to decrypt the data. If the ciphertext has zeros in the most significant bytes,
	/// these bytes must be included in the input data buffer and in the input buffer length. The ciphertext must be in little-endian format.
	/// </para>
	/// <para>Examples</para>
	/// <para>For an example that uses this function, see Example C Program: Decrypting a File.</para>
	/// </remarks>
	// https://docs.microsoft.com/en-us/windows/win32/api/wincrypt/nf-wincrypt-cryptdecrypt BOOL CryptDecrypt( HCRYPTKEY hKey, HCRYPTHASH
	// hHash, BOOL Final, DWORD dwFlags, BYTE *pbData, DWORD *pdwDataLen );
	[DllImport(Lib.AdvApi32, SetLastError = true, ExactSpelling = true)]
	[PInvokeData("wincrypt.h", MSDNShortId = "7c3d2838-6fd1-4f6c-9586-8b94b459a31a")]
	[return: MarshalAs(UnmanagedType.Bool)]
	public static extern bool CryptDecrypt(HCRYPTKEY hKey, [Optional] HCRYPTHASH hHash, [MarshalAs(UnmanagedType.Bool)] bool Final, CryptDecryptFlags dwFlags, [In, Out] byte[] pbData, ref int pdwDataLen);

	/// <summary>
	/// <para>
	/// The CryptDeriveKey function generates cryptographic session keys derived from a base data value. This function guarantees that when
	/// the same cryptographic service provider (CSP) and algorithms are used, the keys generated from the same base data are identical. The
	/// base data can be a password or any other user data.
	/// </para>
	/// <para>
	/// This function is the same as CryptGenKey, except that the generated session keys are derived from base data instead of being random.
	/// <c>CryptDeriveKey</c> can only be used to generate session keys. It cannot generate public/private key pairs.
	/// </para>
	/// <para>
	/// A handle to the session key is returned in the phKey parameter. This handle can be used with any CryptoAPI function that requires a
	/// key handle.
	/// </para>
	/// </summary>
	/// <param name="hProv">A HCRYPTPROV handle of a CSP created by a call to CryptAcquireContext.</param>
	/// <param name="Algid">
	/// <para>
	/// An ALG_ID structure that identifies the symmetric encryption algorithm for which the key is to be generated. The algorithms available
	/// will most likely be different for each CSP. For more information about which algorithm identifier is used by the different providers
	/// for the key specs AT_KEYEXCHANGE and AT_SIGNATURE, see <c>ALG_ID</c>.
	/// </para>
	/// <para>
	/// For more information about ALG_ID values to use with the Microsoft Base Cryptographic Provider, see Base Provider Algorithms. For
	/// more information about <c>ALG_ID</c> values to use with the Microsoft Strong Cryptographic Provider or the Microsoft Enhanced
	/// Cryptographic Provider, see Enhanced Provider Algorithms.
	/// </para>
	/// </param>
	/// <param name="hBaseData">
	/// <para>A handle to a hash object that has been fed the exact base data.</para>
	/// <para>
	/// To obtain this handle, an application must first create a hash object with CryptCreateHash and then add the base data to the hash
	/// object with CryptHashData. This process is described in detail in Hashes and Digital Signatures.
	/// </para>
	/// </param>
	/// <param name="dwFlags">
	/// <para>Specifies the type of key generated.</para>
	/// <para>
	/// The sizes of a session key can be set when the key is generated. The key size, representing the length of the key modulus in bits, is
	/// set with the upper 16 bits of this parameter. Thus, if a 128-bit RC4 session key is to be generated, the value 0x00800000 is combined
	/// with any other dwFlags predefined value with a bitwise- <c>OR</c> operation. Due to changing export control restrictions, the default
	/// CSP and default key length may change between operating system releases. It is important that both the encryption and decryption use
	/// the same CSP and that the key length be explicitly set using the dwFlags parameter to ensure interoperability on different operating
	/// system platforms.
	/// </para>
	/// <para>
	/// The lower 16 bits of this parameter can be zero or you can specify one or more of the following flags by using the bitwise- <c>OR</c>
	/// operator to combine them.
	/// </para>
	/// <list type="table">
	/// <listheader>
	/// <term>Value</term>
	/// <term>Meaning</term>
	/// </listheader>
	/// <item>
	/// <term>CRYPT_CREATE_SALT</term>
	/// <term>
	/// Typically, when a session key is made from a hash value, there are a number of leftover bits. For example, if the hash value is 128
	/// bits and the session key is 40 bits, there will be 88 bits left over. If this flag is set, then the key is assigned a salt value
	/// based on the unused hash value bits. You can retrieve this salt value by using the CryptGetKeyParam function with the dwParam
	/// parameter set to KP_SALT. If this flag is not set, then the key is given a salt value of zero. When keys with nonzero salt values are
	/// exported (by using CryptExportKey), the salt value must also be obtained and kept with the key BLOB.
	/// </term>
	/// </item>
	/// <item>
	/// <term>CRYPT_EXPORTABLE</term>
	/// <term>
	/// If this flag is set, the session key can be transferred out of the CSP into a key BLOB through the CryptExportKey function. Because
	/// keys generally must be exportable, this flag should usually be set. If this flag is not set, then the session key is not exportable.
	/// This means the key is available only within the current session and only the application that created it is able to use it. This flag
	/// does not apply to public/private key pairs.
	/// </term>
	/// </item>
	/// <item>
	/// <term>CRYPT_NO_SALT</term>
	/// <term>This flag specifies that a no salt value gets allocated for a 40-bit symmetric key. For more information, see Salt Value Functionality.</term>
	/// </item>
	/// <item>
	/// <term>CRYPT_UPDATE_KEY</term>
	/// <term>
	/// Some CSPs use session keys that are derived from multiple hash values. When this is the case, CryptDeriveKey must be called multiple
	/// times. If this flag is set, a new session key is not generated. Instead, the key specified by phKey is modified. The precise behavior
	/// of this flag is dependent on the type of key being generated and on the particular CSP being used. Microsoft cryptographic service
	/// providers ignore this flag.
	/// </term>
	/// </item>
	/// <item>
	/// <term>CRYPT_SERVER 1024 (0x400)</term>
	/// <term>
	/// This flag is used only with Schannel providers. If this flag is set, the key to be generated is a server-write key; otherwise, it is
	/// a client-write key.
	/// </term>
	/// </item>
	/// </list>
	/// </param>
	/// <param name="phKey">
	/// A pointer to a HCRYPTKEY variable to receive the address of the handle of the newly generated key. When you have finished using the
	/// key, release the handle by calling the CryptDestroyKey function.
	/// </param>
	/// <returns>
	/// <para>If the function succeeds, the function returns nonzero ( <c>TRUE</c>).</para>
	/// <para>If the function fails, it returns zero ( <c>FALSE</c>). For extended error information, call GetLastError.</para>
	/// <para>
	/// The error codes prefaced by "NTE" are generated by the particular CSP being used. Some possible error codes are listed in the
	/// following table.
	/// </para>
	/// <list type="table">
	/// <listheader>
	/// <term>Return code</term>
	/// <term>Description</term>
	/// </listheader>
	/// <item>
	/// <term>ERROR_INVALID_HANDLE</term>
	/// <term>One of the parameters specifies a handle that is not valid.</term>
	/// </item>
	/// <item>
	/// <term>ERROR_INVALID_PARAMETER</term>
	/// <term>One of the parameters contains a value that is not valid. This is most often a pointer that is not valid.</term>
	/// </item>
	/// <item>
	/// <term>NTE_BAD_ALGID</term>
	/// <term>The Algid parameter specifies an algorithm that this CSP does not support.</term>
	/// </item>
	/// <item>
	/// <term>NTE_BAD_FLAGS</term>
	/// <term>The dwFlags parameter contains a value that is not valid.</term>
	/// </item>
	/// <item>
	/// <term>NTE_BAD_HASH</term>
	/// <term>The hBaseData parameter does not contain a valid handle to a hash object.</term>
	/// </item>
	/// <item>
	/// <term>NTE_BAD_HASH_STATE</term>
	/// <term>An attempt was made to add data to a hash object that is already marked "finished."</term>
	/// </item>
	/// <item>
	/// <term>NTE_BAD_UID</term>
	/// <term>The hProv parameter does not contain a valid context handle.</term>
	/// </item>
	/// <item>
	/// <term>NTE_FAIL</term>
	/// <term>The function failed in some unexpected way.</term>
	/// </item>
	/// <item>
	/// <term>NTE_SILENT_CONTEXT</term>
	/// <term>The provider could not perform the action because the context was acquired as silent.</term>
	/// </item>
	/// </list>
	/// </returns>
	/// <remarks>
	/// <para>
	/// When keys are generated for symmetric block ciphers, the key by default is set up in cipher block chaining (CBC) mode with an
	/// initialization vector of zero. This cipher mode provides a good default method for bulk-encrypting data. To change these parameters,
	/// use the CryptSetKeyParam function.
	/// </para>
	/// <para>
	/// The <c>CryptDeriveKey</c> function completes the hash. After <c>CryptDeriveKey</c> has been called, no more data can be added to the
	/// hash. Additional calls to CryptHashData or CryptHashSessionKey fail. After the application is done with the hash, CryptDestroyHash
	/// must be called to destroy the hash object.
	/// </para>
	/// <para>To choose an appropriate key length, the following methods are recommended.</para>
	/// <list type="bullet">
	/// <item>
	/// <term>
	/// To enumerate the algorithms that the CSP supports and to get maximum and minimum key lengths for each algorithm, call
	/// CryptGetProvParam with PP_ENUMALGS_EX.
	/// </term>
	/// </item>
	/// <item>
	/// <term>
	/// Use the minimum and maximum lengths to choose an appropriate key length. It is not always advisable to choose the maximum length
	/// because this can lead to performance issues.
	/// </term>
	/// </item>
	/// <item>
	/// <term>After the desired key length has been chosen, use the upper 16 bits of the dwFlags parameter to specify the key length.</term>
	/// </item>
	/// </list>
	/// <para>
	/// Let <c>n</c> be the required derived key length, in bytes. The derived key is the first <c>n</c> bytes of the hash value after the
	/// hash computation has been completed by <c>CryptDeriveKey</c>. If the hash is not a member of the SHA-2 family and the required key is
	/// for either 3DES or AES, the key is derived as follows:
	/// </para>
	/// <list type="number">
	/// <item>
	/// <term>
	/// Form a 64-byte buffer by repeating the constant <c>0x36</c> 64 times. Let <c>k</c> be the length of the hash value that is
	/// represented by the input parameter hBaseData. Set the first <c>k</c> bytes of the buffer to the result of an <c>XOR</c> operation of
	/// the first <c>k</c> bytes of the buffer with the hash value that is represented by the input parameter hBaseData.
	/// </term>
	/// </item>
	/// <item>
	/// <term>
	/// Form a 64-byte buffer by repeating the constant <c>0x5C</c> 64 times. Set the first <c>k</c> bytes of the buffer to the result of an
	/// <c>XOR</c> operation of the first <c>k</c> bytes of the buffer with the hash value that is represented by the input parameter hBaseData.
	/// </term>
	/// </item>
	/// <item>
	/// <term>
	/// Hash the result of step 1 by using the same hash algorithm as that used to compute the hash value that is represented by the
	/// hBaseData parameter.
	/// </term>
	/// </item>
	/// <item>
	/// <term>
	/// Hash the result of step 2 by using the same hash algorithm as that used to compute the hash value that is represented by the
	/// hBaseData parameter.
	/// </term>
	/// </item>
	/// <item>
	/// <term>Concatenate the result of step 3 with the result of step 4.</term>
	/// </item>
	/// <item>
	/// <term>Use the first <c>n</c> bytes of the result of step 5 as the derived key.</term>
	/// </item>
	/// </list>
	/// <para>
	/// The default RSA Full Cryptographic Service Provider is the Microsoft RSA Strong Cryptographic Provider. The default DSS Signature
	/// Diffie-Hellman Cryptographic Service Provider is the Microsoft Enhanced DSS Diffie-Hellman Cryptographic Provider. Each of these CSPs
	/// has a default 128-bit symmetric key length for RC2 and RC4.
	/// </para>
	/// <para>The following table lists minimum, default, and maximum key lengths for session key by algorithm and provider.</para>
	/// <list type="table">
	/// <listheader>
	/// <term>Provider</term>
	/// <term>Algorithms</term>
	/// <term>Minimum key length</term>
	/// <term>Default key length</term>
	/// <term>Maximum key length</term>
	/// </listheader>
	/// <item>
	/// <term>MS Base</term>
	/// <term>RC4 and RC2</term>
	/// <term>40</term>
	/// <term>40</term>
	/// <term>56</term>
	/// </item>
	/// <item>
	/// <term>MS Base</term>
	/// <term>DES</term>
	/// <term>56</term>
	/// <term>56</term>
	/// <term>56</term>
	/// </item>
	/// <item>
	/// <term>MS Enhanced</term>
	/// <term>RC4 and RC2</term>
	/// <term>40</term>
	/// <term>128</term>
	/// <term>128</term>
	/// </item>
	/// <item>
	/// <term>MS Enhanced</term>
	/// <term>DES</term>
	/// <term>56</term>
	/// <term>56</term>
	/// <term>56</term>
	/// </item>
	/// <item>
	/// <term>MS Enhanced</term>
	/// <term>3DES 112</term>
	/// <term>112</term>
	/// <term>112</term>
	/// <term>112</term>
	/// </item>
	/// <item>
	/// <term>MS Enhanced</term>
	/// <term>3DES</term>
	/// <term>168</term>
	/// <term>168</term>
	/// <term>168</term>
	/// </item>
	/// <item>
	/// <term>MS Strong</term>
	/// <term>RC4 and RC2</term>
	/// <term>40</term>
	/// <term>128</term>
	/// <term>128</term>
	/// </item>
	/// <item>
	/// <term>MS Strong</term>
	/// <term>DES</term>
	/// <term>56</term>
	/// <term>56</term>
	/// <term>56</term>
	/// </item>
	/// <item>
	/// <term>MS Strong</term>
	/// <term>3DES 112</term>
	/// <term>112</term>
	/// <term>112</term>
	/// <term>112</term>
	/// </item>
	/// <item>
	/// <term>MS Strong</term>
	/// <term>3DES</term>
	/// <term>168</term>
	/// <term>168</term>
	/// <term>168</term>
	/// </item>
	/// <item>
	/// <term>DSS/DH Base</term>
	/// <term>RC4 and RC2</term>
	/// <term>40</term>
	/// <term>40</term>
	/// <term>56</term>
	/// </item>
	/// <item>
	/// <term>DSS/DH Base</term>
	/// <term>Cylink MEK</term>
	/// <term>40</term>
	/// <term>40</term>
	/// <term>40</term>
	/// </item>
	/// <item>
	/// <term>DSS/DH Base</term>
	/// <term>DES</term>
	/// <term>56</term>
	/// <term>56</term>
	/// <term>56</term>
	/// </item>
	/// <item>
	/// <term>DSS/DH Enh</term>
	/// <term>RC4 and RC2</term>
	/// <term>40</term>
	/// <term>128</term>
	/// <term>128</term>
	/// </item>
	/// <item>
	/// <term>DSS/DH Enh</term>
	/// <term>Cylink MEK</term>
	/// <term>40</term>
	/// <term>40</term>
	/// <term>40</term>
	/// </item>
	/// <item>
	/// <term>DSS/DH Enh</term>
	/// <term>DES</term>
	/// <term>56</term>
	/// <term>56</term>
	/// <term>56</term>
	/// </item>
	/// <item>
	/// <term>DSS/DH Enh</term>
	/// <term>3DES 112</term>
	/// <term>112</term>
	/// <term>112</term>
	/// <term>112</term>
	/// </item>
	/// <item>
	/// <term>DSS/DH Enh</term>
	/// <term>3DES</term>
	/// <term>168</term>
	/// <term>168</term>
	/// <term>168</term>
	/// </item>
	/// </list>
	/// <para>Examples</para>
	/// <para>For an example that uses this function, see Example C Program: Deriving a Session Key from a Password.</para>
	/// </remarks>
	// https://docs.microsoft.com/en-us/windows/win32/api/wincrypt/nf-wincrypt-cryptderivekey BOOL CryptDeriveKey( HCRYPTPROV hProv, ALG_ID
	// Algid, HCRYPTHASH hBaseData, DWORD dwFlags, HCRYPTKEY *phKey );
	[DllImport(Lib.AdvApi32, SetLastError = true, ExactSpelling = true)]
	[PInvokeData("wincrypt.h", MSDNShortId = "b031e3b4-0102-400e-96db-019d31402adc")]
	[return: MarshalAs(UnmanagedType.Bool)]
	public static extern bool CryptDeriveKey(HCRYPTPROV hProv, ALG_ID Algid, HCRYPTHASH hBaseData, CryptGenKeyFlags dwFlags, out SafeHCRYPTKEY phKey);

	/// <summary>
	/// The CryptDestroyHash function destroys the hash object referenced by the hHash parameter. After a hash object has been destroyed, it
	/// can no longer be used.
	/// <para>To help ensure security, we recommend that hash objects be destroyed after they have been used.</para>
	/// </summary>
	/// <param name="hHash">The handle of the hash object to be destroyed.</param>
	/// <returns>
	/// <para>If the function succeeds, the return value is nonzero.</para>
	/// <para>If the function fails, the return value is zero. For extended error information, call GetLastError.</para>
	/// <para>
	/// The error codes prefaced by "NTE" are generated by the particular cryptographic service provider (CSP) you are using. Some possible
	/// error codes follow.
	/// </para>
	/// <list type="table">
	/// <listheader>
	/// <term>Return code</term>
	/// <term>Description</term>
	/// </listheader>
	/// <item>
	/// <term>ERROR_BUSY</term>
	/// <term>The hash object specified by hHash is currently being used and cannot be destroyed.</term>
	/// </item>
	/// <item>
	/// <term>ERROR_INVALID_HANDLE</term>
	/// <term>The hHash parameter specifies a handle that is not valid.</term>
	/// </item>
	/// <item>
	/// <term>ERROR_INVALID_PARAMETER</term>
	/// <term>The hHash parameter contains a value that is not valid.</term>
	/// </item>
	/// <item>
	/// <term>NTE_BAD_ALGID</term>
	/// <term>The hHash handle specifies an algorithm that this CSP does not support.</term>
	/// </item>
	/// <item>
	/// <term>NTE_BAD_HASH</term>
	/// <term>The hash object specified by the hHash parameter is not valid.</term>
	/// </item>
	/// <item>
	/// <term>NTE_BAD_UID</term>
	/// <term>The CSP context that was specified when the hash object was created cannot be found.</term>
	/// </item>
	/// </list>
	/// </returns>
	/// <remarks>
	/// <para>
	/// When a hash object is destroyed, many CSPs overwrite the memory in the CSP where the hash object was held. The CSP memory is then freed.
	/// </para>
	/// <para>There should be a one-to-one correspondence between calls to CryptCreateHash and <c>CryptDestroyHash</c>.</para>
	/// <para>
	/// All hash objects that have been created by using a specific CSP must be destroyed before that CSP handle is released with the
	/// CryptReleaseContext function.
	/// </para>
	/// <para>Examples</para>
	/// <para>For an example that uses the <c>CryptDestroyHash</c> function, see Example C Program: Creating and Hashing a Session Key.</para>
	/// </remarks>
	// https://docs.microsoft.com/en-us/windows/win32/api/wincrypt/nf-wincrypt-cryptdestroyhash BOOL CryptDestroyHash( HCRYPTHASH hHash );
	[DllImport(Lib.AdvApi32, SetLastError = true, ExactSpelling = true)]
	[PInvokeData("wincrypt.h", MSDNShortId = "0a4d6086-5c4c-4e1e-9ab9-b35ee49ffcae")]
	[return: MarshalAs(UnmanagedType.Bool)]
	public static extern bool CryptDestroyHash(HCRYPTHASH hHash);

	/// <summary>
	/// The CryptDestroyKey function releases the handle referenced by the hKey parameter. After a key handle has been released, it is no
	/// longer valid and cannot be used again.
	/// <para>
	/// If the handle refers to a session key, or to a public key that has been imported into the cryptographic service provider (CSP)
	/// through CryptImportKey, this function destroys the key and frees the memory that the key used. Many CSPs overwrite the memory where
	/// the key was held before freeing it. However, the underlying public/private key pair is not destroyed by this function. Only the
	/// handle is destroyed.
	/// </para>
	/// </summary>
	/// <param name="hKey">The handle of the key to be destroyed.</param>
	/// <returns>
	/// <para>If the function succeeds, the return value is nonzero.</para>
	/// <para>If the function fails, the return value is zero. For extended error information, call GetLastError.</para>
	/// <para>
	/// The error codes prefaced by "NTE" are generated by the particular CSP being used. Some possible error codes are listed in the
	/// following table.
	/// </para>
	/// <list type="table">
	/// <listheader>
	/// <term>Return code</term>
	/// <term>Description</term>
	/// </listheader>
	/// <item>
	/// <term>ERROR_BUSY</term>
	/// <term>The key object specified by hKey is currently being used and cannot be destroyed.</term>
	/// </item>
	/// <item>
	/// <term>ERROR_INVALID_HANDLE</term>
	/// <term>The hKey parameter specifies a handle that is not valid.</term>
	/// </item>
	/// <item>
	/// <term>ERROR_INVALID_PARAMETER</term>
	/// <term>The hKey parameter contains a value that is not valid.</term>
	/// </item>
	/// <item>
	/// <term>NTE_BAD_KEY</term>
	/// <term>The hKey parameter does not contain a valid handle to a key.</term>
	/// </item>
	/// <item>
	/// <term>NTE_BAD_UID</term>
	/// <term>The CSP context that was specified when the key was created cannot be found.</term>
	/// </item>
	/// </list>
	/// </returns>
	/// <remarks>
	/// <para>
	/// Keys take up both operating system's memory space and the CSP's memory space. Some CSPs are implemented in hardware with limited
	/// memory resources. Applications must destroy all keys with the <c>CryptDestroyKey</c> function when they are finished with them.
	/// </para>
	/// <para>
	/// All key handles that have been created or imported by using a specific CSP must be destroyed before that CSP handle is released with
	/// the CryptReleaseContext function.
	/// </para>
	/// <para>Examples</para>
	/// <para>For an example that uses the <c>CryptDestroyKey</c> function, see Example C Program: Creating and Hashing a Session Key.</para>
	/// </remarks>
	// https://docs.microsoft.com/en-us/windows/win32/api/wincrypt/nf-wincrypt-cryptdestroykey BOOL CryptDestroyKey( HCRYPTKEY hKey );
	[DllImport(Lib.AdvApi32, SetLastError = true, ExactSpelling = true)]
	[PInvokeData("wincrypt.h", MSDNShortId = "ed5d8047-c9fd-4765-915f-a6a014004b30")]
	[return: MarshalAs(UnmanagedType.Bool)]
	public static extern bool CryptDestroyKey(HCRYPTKEY hKey);

	/// <summary>
	/// <para>
	/// The <c>CryptDuplicateHash</c> function makes an exact copy of a hash to the point when the duplication is done. The duplicate hash
	/// includes the state of the hash.
	/// </para>
	/// <para>
	/// A hash can be created in a piece-by-piece way. The <c>CryptDuplicateHash</c> function can be used to create separate hashes of two
	/// different contents that begin with the same content.
	/// </para>
	/// </summary>
	/// <param name="hHash">Handle of the hash to be duplicated.</param>
	/// <param name="pdwReserved">Reserved for future use and must be zero.</param>
	/// <param name="dwFlags">Reserved for future use and must be zero.</param>
	/// <param name="phHash">
	/// Address of the handle of the duplicated hash. When you have finished using the hash, release the handle by calling the
	/// CryptDestroyHash function.
	/// </param>
	/// <returns>
	/// <para>If the function succeeds, the function returns <c>TRUE</c>.</para>
	/// <para>If the function fails, it returns <c>FALSE</c>. For extended error information, call GetLastError.</para>
	/// <para>
	/// The error code prefaced by "NTE" is generated by the particular cryptographic service provider (CSP) that you are using. Some
	/// possible error codes follow.
	/// </para>
	/// <list type="table">
	/// <listheader>
	/// <term>Return code</term>
	/// <term>Description</term>
	/// </listheader>
	/// <item>
	/// <term>ERROR_CALL_NOT_IMPLEMENTED</term>
	/// <term>
	/// Because this is a new function, existing CSPs cannot implement it. This error is returned if the CSP does not support this function.
	/// </term>
	/// </item>
	/// <item>
	/// <term>ERROR_INVALID_PARAMETER</term>
	/// <term>One of the parameters contains a value that is not valid. This is most often a pointer that is not valid.</term>
	/// </item>
	/// <item>
	/// <term>NTE_BAD_HASH</term>
	/// <term>A handle to the original hash is not valid.</term>
	/// </item>
	/// </list>
	/// </returns>
	/// <remarks>
	/// <para>
	/// <c>CryptDuplicateHash</c> makes a copy of a hash and the exact state of the hash. This function might be used if a calling
	/// application needed to generate two hashes but both hashes had to start with some common data hashed. For example, a hash might be
	/// created, the common data hashed, a duplicate made with the <c>CryptDuplicateHash</c> function, and then the data unique to each hash
	/// would be added.
	/// </para>
	/// <para>
	/// The CryptDestroyHash function must be called to destroy any hashes that are created with <c>CryptDuplicateHash</c>. Destroying the
	/// original hash does not cause the duplicate hash to be destroyed. After a duplicate hash is made, it is separate from the original
	/// hash. There is no shared state between the two hashes.
	/// </para>
	/// <para>Examples</para>
	/// <para>
	/// The following example shows making an exact copy of a hash. For an example that includes the complete context for this example, see
	/// Example C Program: Duplicating a Hash.
	/// </para>
	/// </remarks>
	// https://docs.microsoft.com/en-us/windows/win32/api/wincrypt/nf-wincrypt-cryptduplicatehash BOOL CryptDuplicateHash( HCRYPTHASH hHash,
	// DWORD *pdwReserved, DWORD dwFlags, HCRYPTHASH *phHash );
	[DllImport(Lib.AdvApi32, SetLastError = true, ExactSpelling = true)]
	[PInvokeData("wincrypt.h", MSDNShortId = "527fce4d-8d42-437b-9692-42583092efbb")]
	[return: MarshalAs(UnmanagedType.Bool)]
	public static extern bool CryptDuplicateHash(HCRYPTHASH hHash, [Optional] IntPtr pdwReserved, [Optional] uint dwFlags, out SafeHCRYPTHASH phHash);

	/// <summary>The CryptDuplicateKey function makes an exact copy of a key and the state of the key.</summary>
	/// <param name="hKey">A handle to the key to be duplicated.</param>
	/// <param name="pdwReserved">Reserved for future use and must be <c>NULL</c>.</param>
	/// <param name="dwFlags">Reserved for future use and must be zero.</param>
	/// <param name="phKey">
	/// Address of the handle to the duplicated key. When you have finished using the key, release the handle by calling the CryptDestroyKey function.
	/// </param>
	/// <returns>
	/// <para>If the function succeeds, the return value is nonzero (TRUE).</para>
	/// <para>If the function fails, the return value is zero (FALSE). For extended error information, call GetLastError.</para>
	/// <para>
	/// The error code prefaced by "NTE" is generated by the particular CSP being used. Some possible error codes are listed in the following table.
	/// </para>
	/// <list type="table">
	/// <listheader>
	/// <term>Return code</term>
	/// <term>Description</term>
	/// </listheader>
	/// <item>
	/// <term>ERROR_CALL_NOT_IMPLEMENTED</term>
	/// <term>
	/// Because this is a new function, existing CSPs might not implement it. This error is returned if the CSP does not support this function.
	/// </term>
	/// </item>
	/// <item>
	/// <term>ERROR_INVALID_PARAMETER</term>
	/// <term>One of the parameters contains a value that is not valid. This is most often a pointer that is not valid.</term>
	/// </item>
	/// <item>
	/// <term>NTE_BAD_KEY</term>
	/// <term>A handle to the original key is not valid.</term>
	/// </item>
	/// </list>
	/// </returns>
	/// <remarks>
	/// <para>
	/// <c>CryptDuplicateKey</c> makes a copy of a key and the exact state of the key. One scenario when this function can be used is when an
	/// application needs to encrypt two separate messages with the same key but with different salt values. The original key is generated
	/// and then a duplicate key is made by using the <c>CryptDuplicateKey</c> function. The different salt values are then set on the
	/// original and duplicate keys with separate calls to the CryptSetKeyParam function.
	/// </para>
	/// <para>
	/// CryptDestroyKey must be called to destroy any keys that are created by using <c>CryptDuplicateKey</c>. Destroying the original key
	/// does not cause the duplicate key to be destroyed. After a duplicate key is made, it is separate from the original key. There is no
	/// shared state between the two keys.
	/// </para>
	/// <para>Examples</para>
	/// <para>
	/// The following example shows the creation of a session key that is a duplicate of an existing session key. For an example that
	/// includes the complete context for this example, see Example C Program: Duplicating a Session Key.
	/// </para>
	/// </remarks>
	// https://docs.microsoft.com/en-us/windows/win32/api/wincrypt/nf-wincrypt-cryptduplicatekey BOOL CryptDuplicateKey( HCRYPTKEY hKey,
	// DWORD *pdwReserved, DWORD dwFlags, HCRYPTKEY *phKey );
	[DllImport(Lib.AdvApi32, SetLastError = true, ExactSpelling = true)]
	[PInvokeData("wincrypt.h", MSDNShortId = "c5658008-7c92-4877-871a-a764884efd79")]
	[return: MarshalAs(UnmanagedType.Bool)]
	public static extern bool CryptDuplicateKey(HCRYPTKEY hKey, [Optional] IntPtr pdwReserved, [Optional] uint dwFlags, out SafeHCRYPTKEY phKey);

	/// <summary>
	/// <para>
	/// The CryptEncrypt function encrypts data. The algorithm used to encrypt the data is designated by the key held by the CSP module and
	/// is referenced by the hKey parameter.
	/// </para>
	/// <para>
	/// Important changes to support Secure/Multipurpose Internet Mail Extensions (S/MIME) email interoperability have been made to CryptoAPI
	/// that affect the handling of enveloped messages. For more information, see the Remarks section of CryptMsgOpenToEncode.
	/// </para>
	/// <para>
	/// <c>Important</c> The <c>CryptEncrypt</c> function is not guaranteed to be thread safe and may return incorrect results if invoked
	/// simultaneously by multiple callers.
	/// </para>
	/// </summary>
	/// <param name="hKey">
	/// <para>A handle to the encryption key. An application obtains this handle by using either the CryptGenKey or the CryptImportKey function.</para>
	/// <para>The key specifies the encryption algorithm used.</para>
	/// </param>
	/// <param name="hHash">
	/// <para>
	/// A handle to a hash object. If data is to be hashed and encrypted simultaneously, a handle to a hash object can be passed in the hHash
	/// parameter. The hash value is updated with the plaintext passed in. This option is useful when generating signed and encrypted text.
	/// </para>
	/// <para>
	/// Before calling <c>CryptEncrypt</c>, the application must obtain a handle to the hash object by calling the CryptCreateHash function.
	/// After the encryption is complete, the hash value can be obtained by using the CryptGetHashParam function, or the hash can be signed
	/// by using the CryptSignHash function.
	/// </para>
	/// <para>If no hash is to be done, this parameter must be <c>NULL</c>.</para>
	/// </param>
	/// <param name="Final">
	/// A Boolean value that specifies whether this is the last section in a series being encrypted. Final is set to <c>TRUE</c> for the last
	/// or only block and to <c>FALSE</c> if there are more blocks to be encrypted. For more information, see Remarks.
	/// </param>
	/// <param name="dwFlags">
	/// <para>The following dwFlags value is defined but reserved for future use.</para>
	/// <list type="table">
	/// <listheader>
	/// <term>Value</term>
	/// <term>Meaning</term>
	/// </listheader>
	/// <item>
	/// <term>CRYPT_OAEP</term>
	/// <term>
	/// Use Optimal Asymmetric Encryption Padding (OAEP) (PKCS #1 version 2). This flag is only supported by the Microsoft Enhanced
	/// Cryptographic Provider with RSA encryption/decryption.
	/// </term>
	/// </item>
	/// </list>
	/// </param>
	/// <param name="pbData">
	/// <para>
	/// A pointer to a buffer that contains the plaintext to be encrypted. The plaintext in this buffer is overwritten with the ciphertext
	/// created by this function.
	/// </para>
	/// <para>
	/// The pdwDataLen parameter points to a variable that contains the length, in bytes, of the plaintext. The dwBufLen parameter contains
	/// the total size, in bytes, of this buffer.
	/// </para>
	/// <para>
	/// If this parameter contains <c>NULL</c>, this function will calculate the required size for the ciphertext and place that in the value
	/// pointed to by the pdwDataLen parameter.
	/// </para>
	/// </param>
	/// <param name="pdwDataLen">
	/// <para>
	/// A pointer to a <c>DWORD</c> value that , on entry, contains the length, in bytes, of the plaintext in the pbData buffer. On exit,
	/// this <c>DWORD</c> contains the length, in bytes, of the ciphertext written to the pbData buffer.
	/// </para>
	/// <para>
	/// If the buffer allocated for pbData is not large enough to hold the encrypted data, GetLastError returns <c>ERROR_MORE_DATA</c> and
	/// stores the required buffer size, in bytes, in the <c>DWORD</c> value pointed to by pdwDataLen.
	/// </para>
	/// <para>
	/// If pbData is <c>NULL</c>, no error is returned, and the function stores the size of the encrypted data, in bytes, in the <c>DWORD</c>
	/// value pointed to by pdwDataLen. This allows an application to determine the correct buffer size.
	/// </para>
	/// <para>
	/// When a block cipher is used, this data length must be a multiple of the block size unless this is the final section of data to be
	/// encrypted and the Final parameter is <c>TRUE</c>.
	/// </para>
	/// </param>
	/// <param name="dwBufLen">
	/// <para>Specifies the total size, in bytes, of the input pbData buffer.</para>
	/// <para>
	/// Note that, depending on the algorithm used, the encrypted text can be larger than the original plaintext. In this case, the pbData
	/// buffer needs to be large enough to contain the encrypted text and any padding.
	/// </para>
	/// <para>
	/// As a rule, if a stream cipher is used, the ciphertext is the same size as the plaintext. If a block cipher is used, the ciphertext is
	/// up to a block length larger than the plaintext.
	/// </para>
	/// </param>
	/// <returns>
	/// <para>If the function succeeds, the function returns nonzero ( <c>TRUE</c>).</para>
	/// <para>If the function fails, it returns zero ( <c>FALSE</c>). For extended error information, call GetLastError.</para>
	/// <para>The error codes prefaced by NTE are generated by the particular CSP being used. Some possible error codes follow.</para>
	/// <list type="table">
	/// <listheader>
	/// <term>Value</term>
	/// <term>Description</term>
	/// </listheader>
	/// <item>
	/// <term>ERROR_INVALID_HANDLE</term>
	/// <term>One of the parameters specifies a handle that is not valid.</term>
	/// </item>
	/// <item>
	/// <term>ERROR_INVALID_PARAMETER</term>
	/// <term>One of the parameters contains a value that is not valid. This is most often a pointer that is not valid.</term>
	/// </item>
	/// <item>
	/// <term>NTE_BAD_ALGID</term>
	/// <term>The hKey session key specifies an algorithm that this CSP does not support.</term>
	/// </item>
	/// <item>
	/// <term>NTE_BAD_DATA</term>
	/// <term>
	/// The data to be encrypted is not valid. For example, when a block cipher is used and the Final flag is FALSE, the value specified by
	/// pdwDataLen must be a multiple of the block size.
	/// </term>
	/// </item>
	/// <item>
	/// <term>NTE_BAD_FLAGS</term>
	/// <term>The dwFlags parameter is nonzero.</term>
	/// </item>
	/// <item>
	/// <term>NTE_BAD_HASH</term>
	/// <term>The hHash parameter contains a handle that is not valid.</term>
	/// </item>
	/// <item>
	/// <term>NTE_BAD_HASH_STATE</term>
	/// <term>An attempt was made to add data to a hash object that is already marked "finished."</term>
	/// </item>
	/// <item>
	/// <term>NTE_BAD_KEY</term>
	/// <term>The hKey parameter does not contain a valid handle to a key.</term>
	/// </item>
	/// <item>
	/// <term>NTE_BAD_LEN</term>
	/// <term>The size of the output buffer is too small to hold the generated ciphertext.</term>
	/// </item>
	/// <item>
	/// <term>NTE_BAD_UID</term>
	/// <term>The CSP context that was specified when the key was created cannot be found.</term>
	/// </item>
	/// <item>
	/// <term>NTE_DOUBLE_ENCRYPT</term>
	/// <term>The application attempted to encrypt the same data twice.</term>
	/// </item>
	/// <item>
	/// <term>NTE_FAIL</term>
	/// <term>The function failed in some unexpected way.</term>
	/// </item>
	/// <item>
	/// <term>NTE_NO_MEMORY</term>
	/// <term>The CSP ran out of memory during the operation.</term>
	/// </item>
	/// </list>
	/// </returns>
	/// <remarks>
	/// <para>
	/// If a large amount of data is to be encrypted, it can be done in sections by calling <c>CryptEncrypt</c> repeatedly. The Final
	/// parameter must be set to <c>TRUE</c> on the last call to <c>CryptEncrypt</c>, so that the encryption engine can properly finish the
	/// encryption process. The following extra actions are performed when Final is <c>TRUE</c>:
	/// </para>
	/// <list type="bullet">
	/// <item>
	/// <term>
	/// If the key is a block cipher key, the data is padded to a multiple of the block size of the cipher. If the data length equals the
	/// block size of the cipher, one additional block of padding is appended to the data. To find the block size of a cipher, use
	/// CryptGetKeyParam to get the KP_BLOCKLEN value of the key.
	/// </term>
	/// </item>
	/// <item>
	/// <term>
	/// If the cipher is operating in a chaining mode, the next <c>CryptEncrypt</c> operation resets the cipher's feedback register to the
	/// KP_IV value of the key.
	/// </term>
	/// </item>
	/// <item>
	/// <term>If the cipher is a stream cipher, the next <c>CryptEncrypt</c> resets the cipher to its initial state.</term>
	/// </item>
	/// </list>
	/// <para>
	/// There is no way to set the cipher's feedback register to the KP_IV value of the key without setting the Final parameter to
	/// <c>TRUE</c>. If this is necessary, as in the case where you do not want to add an additional padding block or change the size of each
	/// block, you can simulate this by creating a duplicate of the original key by using the CryptDuplicateKey function, and passing the
	/// duplicate key to the <c>CryptEncrypt</c> function. This causes the KP_IV of the original key to be placed in the duplicate key. After
	/// you create or import the original key, you cannot use the original key for encryption because the feedback register of the key will
	/// be changed. The following pseudocode shows how this can be done.
	/// </para>
	/// <para>
	/// The Microsoft Enhanced Cryptographic Provider supports direct encryption with RSA public keys and decryption with RSA private keys.
	/// The encryption uses PKCS #1 padding. On decryption, this padding is verified. The length of plaintext data that can be encrypted with
	/// a call to <c>CryptEncrypt</c> with an RSA key is the length of the key modulus minus eleven bytes. The eleven bytes is the chosen
	/// minimum for PKCS #1 padding. The ciphertext is returned in little-endian format.
	/// </para>
	/// <para>Examples</para>
	/// <para>For examples that use this function, see Example C Program: Encrypting a File and Example C Program: Decrypting a File.</para>
	/// </remarks>
	// https://docs.microsoft.com/en-us/windows/win32/api/wincrypt/nf-wincrypt-cryptencrypt BOOL CryptEncrypt( HCRYPTKEY hKey, HCRYPTHASH
	// hHash, BOOL Final, DWORD dwFlags, BYTE *pbData, DWORD *pdwDataLen, DWORD dwBufLen );
	[DllImport(Lib.AdvApi32, SetLastError = true, ExactSpelling = true)]
	[PInvokeData("wincrypt.h", MSDNShortId = "697c4960-552b-4c3a-95cf-4632af56945b")]
	[return: MarshalAs(UnmanagedType.Bool)]
	public static extern bool CryptEncrypt(HCRYPTKEY hKey, [Optional] HCRYPTHASH hHash, [MarshalAs(UnmanagedType.Bool)] bool Final, CryptEncryptFlags dwFlags, [In, Out, Optional] IntPtr pbData, ref uint pdwDataLen, uint dwBufLen);

	/// <summary>
	/// <para>
	/// The CryptEncrypt function encrypts data. The algorithm used to encrypt the data is designated by the key held by the CSP module and
	/// is referenced by the hKey parameter.
	/// </para>
	/// <para>
	/// Important changes to support Secure/Multipurpose Internet Mail Extensions (S/MIME) email interoperability have been made to CryptoAPI
	/// that affect the handling of enveloped messages. For more information, see the Remarks section of CryptMsgOpenToEncode.
	/// </para>
	/// <para>
	/// <c>Important</c> The <c>CryptEncrypt</c> function is not guaranteed to be thread safe and may return incorrect results if invoked
	/// simultaneously by multiple callers.
	/// </para>
	/// </summary>
	/// <param name="hKey">
	/// <para>A handle to the encryption key. An application obtains this handle by using either the CryptGenKey or the CryptImportKey function.</para>
	/// <para>The key specifies the encryption algorithm used.</para>
	/// </param>
	/// <param name="hHash">
	/// <para>
	/// A handle to a hash object. If data is to be hashed and encrypted simultaneously, a handle to a hash object can be passed in the hHash
	/// parameter. The hash value is updated with the plaintext passed in. This option is useful when generating signed and encrypted text.
	/// </para>
	/// <para>
	/// Before calling <c>CryptEncrypt</c>, the application must obtain a handle to the hash object by calling the CryptCreateHash function.
	/// After the encryption is complete, the hash value can be obtained by using the CryptGetHashParam function, or the hash can be signed
	/// by using the CryptSignHash function.
	/// </para>
	/// <para>If no hash is to be done, this parameter must be <c>NULL</c>.</para>
	/// </param>
	/// <param name="Final">
	/// A Boolean value that specifies whether this is the last section in a series being encrypted. Final is set to <c>TRUE</c> for the last
	/// or only block and to <c>FALSE</c> if there are more blocks to be encrypted. For more information, see Remarks.
	/// </param>
	/// <param name="dwFlags">
	/// <para>The following dwFlags value is defined but reserved for future use.</para>
	/// <list type="table">
	/// <listheader>
	/// <term>Value</term>
	/// <term>Meaning</term>
	/// </listheader>
	/// <item>
	/// <term>CRYPT_OAEP</term>
	/// <term>
	/// Use Optimal Asymmetric Encryption Padding (OAEP) (PKCS #1 version 2). This flag is only supported by the Microsoft Enhanced
	/// Cryptographic Provider with RSA encryption/decryption.
	/// </term>
	/// </item>
	/// </list>
	/// </param>
	/// <param name="pbData">
	/// <para>
	/// A pointer to a buffer that contains the plaintext to be encrypted. The plaintext in this buffer is overwritten with the ciphertext
	/// created by this function.
	/// </para>
	/// <para>
	/// The pdwDataLen parameter points to a variable that contains the length, in bytes, of the plaintext. The dwBufLen parameter contains
	/// the total size, in bytes, of this buffer.
	/// </para>
	/// <para>
	/// If this parameter contains <c>NULL</c>, this function will calculate the required size for the ciphertext and place that in the value
	/// pointed to by the pdwDataLen parameter.
	/// </para>
	/// </param>
	/// <param name="pdwDataLen">
	/// <para>
	/// A pointer to a <c>DWORD</c> value that , on entry, contains the length, in bytes, of the plaintext in the pbData buffer. On exit,
	/// this <c>DWORD</c> contains the length, in bytes, of the ciphertext written to the pbData buffer.
	/// </para>
	/// <para>
	/// If the buffer allocated for pbData is not large enough to hold the encrypted data, GetLastError returns <c>ERROR_MORE_DATA</c> and
	/// stores the required buffer size, in bytes, in the <c>DWORD</c> value pointed to by pdwDataLen.
	/// </para>
	/// <para>
	/// If pbData is <c>NULL</c>, no error is returned, and the function stores the size of the encrypted data, in bytes, in the <c>DWORD</c>
	/// value pointed to by pdwDataLen. This allows an application to determine the correct buffer size.
	/// </para>
	/// <para>
	/// When a block cipher is used, this data length must be a multiple of the block size unless this is the final section of data to be
	/// encrypted and the Final parameter is <c>TRUE</c>.
	/// </para>
	/// </param>
	/// <param name="dwBufLen">
	/// <para>Specifies the total size, in bytes, of the input pbData buffer.</para>
	/// <para>
	/// Note that, depending on the algorithm used, the encrypted text can be larger than the original plaintext. In this case, the pbData
	/// buffer needs to be large enough to contain the encrypted text and any padding.
	/// </para>
	/// <para>
	/// As a rule, if a stream cipher is used, the ciphertext is the same size as the plaintext. If a block cipher is used, the ciphertext is
	/// up to a block length larger than the plaintext.
	/// </para>
	/// </param>
	/// <returns>
	/// <para>If the function succeeds, the function returns nonzero ( <c>TRUE</c>).</para>
	/// <para>If the function fails, it returns zero ( <c>FALSE</c>). For extended error information, call GetLastError.</para>
	/// <para>The error codes prefaced by NTE are generated by the particular CSP being used. Some possible error codes follow.</para>
	/// <list type="table">
	/// <listheader>
	/// <term>Value</term>
	/// <term>Description</term>
	/// </listheader>
	/// <item>
	/// <term>ERROR_INVALID_HANDLE</term>
	/// <term>One of the parameters specifies a handle that is not valid.</term>
	/// </item>
	/// <item>
	/// <term>ERROR_INVALID_PARAMETER</term>
	/// <term>One of the parameters contains a value that is not valid. This is most often a pointer that is not valid.</term>
	/// </item>
	/// <item>
	/// <term>NTE_BAD_ALGID</term>
	/// <term>The hKey session key specifies an algorithm that this CSP does not support.</term>
	/// </item>
	/// <item>
	/// <term>NTE_BAD_DATA</term>
	/// <term>
	/// The data to be encrypted is not valid. For example, when a block cipher is used and the Final flag is FALSE, the value specified by
	/// pdwDataLen must be a multiple of the block size.
	/// </term>
	/// </item>
	/// <item>
	/// <term>NTE_BAD_FLAGS</term>
	/// <term>The dwFlags parameter is nonzero.</term>
	/// </item>
	/// <item>
	/// <term>NTE_BAD_HASH</term>
	/// <term>The hHash parameter contains a handle that is not valid.</term>
	/// </item>
	/// <item>
	/// <term>NTE_BAD_HASH_STATE</term>
	/// <term>An attempt was made to add data to a hash object that is already marked "finished."</term>
	/// </item>
	/// <item>
	/// <term>NTE_BAD_KEY</term>
	/// <term>The hKey parameter does not contain a valid handle to a key.</term>
	/// </item>
	/// <item>
	/// <term>NTE_BAD_LEN</term>
	/// <term>The size of the output buffer is too small to hold the generated ciphertext.</term>
	/// </item>
	/// <item>
	/// <term>NTE_BAD_UID</term>
	/// <term>The CSP context that was specified when the key was created cannot be found.</term>
	/// </item>
	/// <item>
	/// <term>NTE_DOUBLE_ENCRYPT</term>
	/// <term>The application attempted to encrypt the same data twice.</term>
	/// </item>
	/// <item>
	/// <term>NTE_FAIL</term>
	/// <term>The function failed in some unexpected way.</term>
	/// </item>
	/// <item>
	/// <term>NTE_NO_MEMORY</term>
	/// <term>The CSP ran out of memory during the operation.</term>
	/// </item>
	/// </list>
	/// </returns>
	/// <remarks>
	/// <para>
	/// If a large amount of data is to be encrypted, it can be done in sections by calling <c>CryptEncrypt</c> repeatedly. The Final
	/// parameter must be set to <c>TRUE</c> on the last call to <c>CryptEncrypt</c>, so that the encryption engine can properly finish the
	/// encryption process. The following extra actions are performed when Final is <c>TRUE</c>:
	/// </para>
	/// <list type="bullet">
	/// <item>
	/// <term>
	/// If the key is a block cipher key, the data is padded to a multiple of the block size of the cipher. If the data length equals the
	/// block size of the cipher, one additional block of padding is appended to the data. To find the block size of a cipher, use
	/// CryptGetKeyParam to get the KP_BLOCKLEN value of the key.
	/// </term>
	/// </item>
	/// <item>
	/// <term>
	/// If the cipher is operating in a chaining mode, the next <c>CryptEncrypt</c> operation resets the cipher's feedback register to the
	/// KP_IV value of the key.
	/// </term>
	/// </item>
	/// <item>
	/// <term>If the cipher is a stream cipher, the next <c>CryptEncrypt</c> resets the cipher to its initial state.</term>
	/// </item>
	/// </list>
	/// <para>
	/// There is no way to set the cipher's feedback register to the KP_IV value of the key without setting the Final parameter to
	/// <c>TRUE</c>. If this is necessary, as in the case where you do not want to add an additional padding block or change the size of each
	/// block, you can simulate this by creating a duplicate of the original key by using the CryptDuplicateKey function, and passing the
	/// duplicate key to the <c>CryptEncrypt</c> function. This causes the KP_IV of the original key to be placed in the duplicate key. After
	/// you create or import the original key, you cannot use the original key for encryption because the feedback register of the key will
	/// be changed. The following pseudocode shows how this can be done.
	/// </para>
	/// <para>
	/// The Microsoft Enhanced Cryptographic Provider supports direct encryption with RSA public keys and decryption with RSA private keys.
	/// The encryption uses PKCS #1 padding. On decryption, this padding is verified. The length of plaintext data that can be encrypted with
	/// a call to <c>CryptEncrypt</c> with an RSA key is the length of the key modulus minus eleven bytes. The eleven bytes is the chosen
	/// minimum for PKCS #1 padding. The ciphertext is returned in little-endian format.
	/// </para>
	/// <para>Examples</para>
	/// <para>For examples that use this function, see Example C Program: Encrypting a File and Example C Program: Decrypting a File.</para>
	/// </remarks>
	// https://docs.microsoft.com/en-us/windows/win32/api/wincrypt/nf-wincrypt-cryptencrypt BOOL CryptEncrypt( HCRYPTKEY hKey, HCRYPTHASH
	// hHash, BOOL Final, DWORD dwFlags, BYTE *pbData, DWORD *pdwDataLen, DWORD dwBufLen );
	[DllImport(Lib.AdvApi32, SetLastError = true, ExactSpelling = true)]
	[PInvokeData("wincrypt.h", MSDNShortId = "697c4960-552b-4c3a-95cf-4632af56945b")]
	[return: MarshalAs(UnmanagedType.Bool)]
	public static extern bool CryptEncrypt(HCRYPTKEY hKey, [Optional] HCRYPTHASH hHash, [MarshalAs(UnmanagedType.Bool)] bool Final, CryptEncryptFlags dwFlags, [In, Out] byte[]? pbData, ref int pdwDataLen, int dwBufLen);

	/// <summary>
	/// Retrieves a dictionary of types of cryptographic service provider (CSP) supported on the computer and associated names.
	/// <para>Provider types include PROV_RSA_FULL, PROV_RSA_SCHANNEL, and PROV_DSS.</para>
	/// </summary>
	/// <returns>A dictionary of provider type names and types.</returns>
	public static IReadOnlyDictionary<uint, string> CryptEnumProviderDictionary()
	{
		Dictionary<uint, string> d = new();
		foreach ((uint provType, string typeName) in CryptEnumProviderTypes())
			d.Add(provType, typeName);
		return d;
	}

	/// <summary>
	/// The CryptEnumProviders function retrieves the first or next available cryptographic service providers (CSPs). Used in a loop, this
	/// function can retrieve in sequence all of the CSPs available on a computer.
	/// <para>
	/// Possible CSPs include Microsoft Base Cryptographic Provider version 1.0 and Microsoft Enhanced Cryptographic Provider version 1.0.
	/// </para>
	/// </summary>
	/// <param name="dwIndex">Index of the next provider to be enumerated.</param>
	/// <param name="pdwReserved">Reserved for future use and must be <c>NULL</c>.</param>
	/// <param name="dwFlags">Reserved for future use and must be zero.</param>
	/// <param name="pdwProvType">Address of the <c>DWORD</c> value designating the type of the enumerated provider.</param>
	/// <param name="szProvName">
	/// <para>
	/// A pointer to a buffer that receives the data from the enumerated provider. This is a string including the terminating null character.
	/// </para>
	/// <para>
	/// This parameter can be <c>NULL</c> to set the size of the name for memory allocation purposes. For more information, see Retrieving
	/// Data of Unknown Length.
	/// </para>
	/// </param>
	/// <param name="pcbProvName">
	/// <para>
	/// A pointer to a <c>DWORD</c> value specifying the size, in bytes, of the buffer pointed to by the pszProvName parameter. When the
	/// function returns, the <c>DWORD</c> value contains the number of bytes stored in the buffer.
	/// </para>
	/// <para>
	/// <c>Note</c> When processing the data returned in the buffer, applications must use the actual size of the data returned. The actual
	/// size can be slightly smaller than the size of the buffer specified on input. (On input, buffer sizes are usually specified large
	/// enough to ensure that the largest possible output data fits in the buffer.) On output, the variable pointed to by this parameter is
	/// updated to reflect the actual size of the data copied to the buffer.
	/// </para>
	/// </param>
	/// <returns>
	/// <para>If the function succeeds, the return value is nonzero ( <c>TRUE</c>).</para>
	/// <para>If the function fails, the return value is zero ( <c>FALSE</c>). For extended error information, call GetLastError.</para>
	/// <para>The error codes prefaced by NTE are generated by the particular CSP being used. Some possible error codes follow.</para>
	/// <list type="table">
	/// <listheader>
	/// <term>Return code</term>
	/// <term>Description</term>
	/// </listheader>
	/// <item>
	/// <term>ERROR_MORE_DATA</term>
	/// <term>The pszProvName buffer was not large enough to hold the provider name.</term>
	/// </item>
	/// <item>
	/// <term>ERROR_NO_MORE_ITEMS</term>
	/// <term>There are no more items to enumerate.</term>
	/// </item>
	/// <item>
	/// <term>ERROR_NOT_ENOUGH_MEMORY</term>
	/// <term>The operating system ran out of memory.</term>
	/// </item>
	/// <item>
	/// <term>NTE_BAD_FLAGS</term>
	/// <term>The dwFlags parameter has an unrecognized value.</term>
	/// </item>
	/// <item>
	/// <term>NTE_FAIL</term>
	/// <term>Something was wrong with the type registration.</term>
	/// </item>
	/// </list>
	/// </returns>
	/// <remarks>
	/// <para>This function enumerates the providers available on a computer. The provider types can be enumerated by using CryptEnumProviderTypes.</para>
	/// <para>Examples</para>
	/// <para>
	/// The following example shows a loop listing all available cryptographic service providers. For another example that uses the
	/// <c>CryptEnumProviders</c> function, see Example C Program: Enumerating CSP Providers and Provider Types.
	/// </para>
	/// </remarks>
	// https://docs.microsoft.com/en-us/windows/win32/api/wincrypt/nf-wincrypt-cryptenumprovidersa BOOL CryptEnumProvidersA( DWORD dwIndex,
	// DWORD *pdwReserved, DWORD dwFlags, DWORD *pdwProvType, LPSTR szProvName, DWORD *pcbProvName );
	[DllImport(Lib.AdvApi32, SetLastError = true, CharSet = CharSet.Auto)]
	[PInvokeData("wincrypt.h", MSDNShortId = "2d93ef0f-b48f-481b-ba62-c535476fde08")]
	[return: MarshalAs(UnmanagedType.Bool)]
	public static extern bool CryptEnumProviders(uint dwIndex, [Optional] IntPtr pdwReserved, [Optional] uint dwFlags, out uint pdwProvType,
		[Optional, MarshalAs(UnmanagedType.LPTStr)] StringBuilder? szProvName, ref uint pcbProvName);

	/// <summary>
	/// The CryptEnumProviders function retrieves the first or next available cryptographic service providers (CSPs). Used in a loop, this
	/// function can retrieve in sequence all of the CSPs available on a computer.
	/// <para>
	/// Possible CSPs include Microsoft Base Cryptographic Provider version 1.0 and Microsoft Enhanced Cryptographic Provider version 1.0.
	/// </para>
	/// </summary>
	/// <returns>A sequence of provider names and types.</returns>
	[PInvokeData("wincrypt.h", MSDNShortId = "2d93ef0f-b48f-481b-ba62-c535476fde08")]
	public static IEnumerable<(uint provType, string provName)> CryptEnumProviders()
	{
		var idx = 0U;
		uint sz = 1024U;
		var sb = new StringBuilder((int)sz);
		while (CryptEnumProviders(idx, default, 0, out _, null, ref sz))
		{
			sb.EnsureCapacity((int)sz / Marshal.SystemDefaultCharSize);
			if (CryptEnumProviders(idx, default, 0, out uint type, sb, ref sz))
			{
				yield return (type, sb.ToString());
				++idx;
			}
			else
				Win32Error.ThrowLastError();
		}
	}

	/// <summary>
	/// The CryptEnumProviderTypes function retrieves the first or next types of cryptographic service provider (CSP) supported on the
	/// computer. Used in a loop, this function retrieves in sequence all of the CSP types available on a computer.
	/// <para>Provider types include PROV_RSA_FULL, PROV_RSA_SCHANNEL, and PROV_DSS.</para>
	/// </summary>
	/// <param name="dwIndex">Index of the next provider type to be enumerated.</param>
	/// <param name="pdwReserved">Reserved for future use and must be <c>NULL</c>.</param>
	/// <param name="dwFlags">Reserved for future use and must be zero.</param>
	/// <param name="pdwProvType">Address of the <c>DWORD</c> value designating the enumerated provider type.</param>
	/// <param name="szTypeName">
	/// <para>
	/// A pointer to a buffer that receives the data from the enumerated provider type. This is a string including the terminating
	/// <c>NULL</c> character. Some provider types do not have display names, and in this case no name is returned and the returned value
	/// pointed to by pcbTypeName is zero.
	/// </para>
	/// <para>
	/// This parameter can be <c>NULL</c> to get the size of the name for memory allocation purposes. For more information, see Retrieving
	/// Data of Unknown Length.
	/// </para>
	/// </param>
	/// <param name="pcbTypeName">
	/// <para>
	/// A pointer to a <c>DWORD</c> value specifying the size, in bytes, of the buffer pointed to by the pszTypeName parameter. When the
	/// function returns, the <c>DWORD</c> value contains the number of bytes stored or to be stored in the buffer. Some provider types do
	/// not have display names, and in this case no name is returned and the returned value pointed to by pcbTypeName is zero.
	/// </para>
	/// <para>
	/// <c>Note</c> When processing the data returned in the buffer, applications must use the actual size of the data returned. The actual
	/// size can be slightly smaller than the size of the buffer specified on input. (On input, buffer sizes are usually specified large
	/// enough to ensure that the largest possible output data fits in the buffer.) On output, the variable pointed to by this parameter is
	/// updated to reflect the actual size of the data copied to the buffer.
	/// </para>
	/// </param>
	/// <returns>
	/// <para>If the function succeeds, the return value is nonzero ( <c>TRUE</c>).</para>
	/// <para>If the function fails, the return value is zero ( <c>FALSE</c>). For extended error information, call GetLastError.</para>
	/// <para>The error codes prefaced by NTE are generated by the particular CSP being used. Some possible error codes follow.</para>
	/// <list type="table">
	/// <listheader>
	/// <term>Return code</term>
	/// <term>Description</term>
	/// </listheader>
	/// <item>
	/// <term>ERROR_NO_MORE_ITEMS</term>
	/// <term>There are no more items to enumerate.</term>
	/// </item>
	/// <item>
	/// <term>ERROR_NOT_ENOUGH_MEMORY</term>
	/// <term>The operating system ran out of memory.</term>
	/// </item>
	/// <item>
	/// <term>NTE_BAD_FLAGS</term>
	/// <term>The dwFlags parameter has an unrecognized value.</term>
	/// </item>
	/// <item>
	/// <term>NTE_FAIL</term>
	/// <term>Something was wrong with the type registration.</term>
	/// </item>
	/// </list>
	/// </returns>
	/// <remarks>
	/// <para>
	/// This function enumerates the provider types available on a computer. Providers for any specific provider type can be enumerated using CryptEnumProviders.
	/// </para>
	/// <para>Examples</para>
	/// <para>The following example shows a loop listing all available cryptographic service provider types.</para>
	/// <para>
	/// For another example that uses the <c>CryptEnumProviderTypes</c> function, see Example C Program: Enumerating CSP Providers and
	/// Provider Types.
	/// </para>
	/// </remarks>
	// https://docs.microsoft.com/en-us/windows/win32/api/wincrypt/nf-wincrypt-cryptenumprovidertypesa BOOL CryptEnumProviderTypesA( DWORD
	// dwIndex, DWORD *pdwReserved, DWORD dwFlags, DWORD *pdwProvType, LPSTR szTypeName, DWORD *pcbTypeName );
	[DllImport(Lib.AdvApi32, SetLastError = true, CharSet = CharSet.Auto)]
	[PInvokeData("wincrypt.h", MSDNShortId = "7568c963-4d06-4af0-bd15-240402425046")]
	[return: MarshalAs(UnmanagedType.Bool)]
	public static extern bool CryptEnumProviderTypes(uint dwIndex, [Optional] IntPtr pdwReserved, [Optional] uint dwFlags, out uint pdwProvType,
		[Optional, MarshalAs(UnmanagedType.LPTStr)] StringBuilder? szTypeName, ref uint pcbTypeName);

	/// <summary>
	/// The CryptEnumProviderTypes function retrieves the first or next types of cryptographic service provider (CSP) supported on the
	/// computer. Used in a loop, this function retrieves in sequence all of the CSP types available on a computer.
	/// <para>Provider types include PROV_RSA_FULL, PROV_RSA_SCHANNEL, and PROV_DSS.</para>
	/// </summary>
	/// <returns>A sequence of provider type names and types.</returns>
	[PInvokeData("wincrypt.h", MSDNShortId = "7568c963-4d06-4af0-bd15-240402425046")]
	public static IEnumerable<(uint provType, string typeName)> CryptEnumProviderTypes()
	{
		var idx = 0U;
		var sb = new StringBuilder(1024);
		var sz = 0U;
		while (CryptEnumProviderTypes(idx, default, 0, out _, null, ref sz))
		{
			sb.EnsureCapacity((int)sz / Marshal.SystemDefaultCharSize);
			if (CryptEnumProviderTypes(idx, default, 0, out var type, sb, ref sz))
			{
				yield return (type, sb.ToString());
				++idx;
			}
			else
				Win32Error.ThrowLastError();
		}
	}

	/// <summary>
	/// A handle to the key to be exported is passed to the function, and the function returns a key BLOB. This key BLOB can be sent over a
	/// nonsecure transport or stored in a nonsecure storage location. This function can export an Schannel session key, regular session key,
	/// public key, or public/private key pair. The key BLOB to export is useless until the intended recipient uses the CryptImportKey
	/// function on it to import the key or key pair into a recipient's CSP.
	/// </summary>
	/// <param name="hKey">A handle to the key to be exported.</param>
	/// <param name="hExpKey">
	/// <para>
	/// A handle to a cryptographic key of the destination user. The key data within the exported key BLOB is encrypted using this key. This
	/// ensures that only the destination user is able to make use of the key BLOB. Both <c>hExpKey</c> and <c>hKey</c> must come from the
	/// same CSP.
	/// </para>
	/// <para>
	/// Most often, this is the key exchange public key of the destination user. However, certain protocols in some CSPs require that a
	/// session key belonging to the destination user be used for this purpose.
	/// </para>
	/// <para>If the key BLOB type specified by <c>dwBlobType</c> is <c>PUBLICKEYBLOB</c>, this parameter is unused and must be set to zero.</para>
	/// <para>
	/// If the key BLOB type specified by <c>dwBlobType</c> is <c>PRIVATEKEYBLOB</c>, this is typically a handle to a session key that is to
	/// be used to encrypt the key BLOB. Some CSPs allow this parameter to be zero, in which case the application must encrypt the private
	/// key BLOB manually so as to protect it.
	/// </para>
	/// <para>
	/// To determine how Microsoft cryptographic service providers respond to this parameter, see the private key BLOB sections of Microsoft
	/// Cryptographic Service Providers.
	/// </para>
	/// <para>
	/// <c>Note</c> Some CSPs may modify this parameter as a result of the operation. Applications that subsequently use this key for other
	/// purposes should call the CryptDuplicateKey function to create a duplicate key handle. When the application has finished using the
	/// handle, release it by calling the CryptDestroyKey function.
	/// </para>
	/// </param>
	/// <param name="dwBlobType">
	/// <para>
	/// Specifies the type of key BLOB to be exported in <c>pbData</c>. This must be one of the following constants as discussed in
	/// Cryptographic Key Storage and Exchange.
	/// </para>
	/// <list type="table">
	/// <listheader>
	/// <term>Value</term>
	/// <term>Meaning</term>
	/// </listheader>
	/// <item>
	/// <term><c>OPAQUEKEYBLOB</c></term>
	/// <term>
	/// Used to store session keys in an Schannel CSP or any other vendor-specific format. OPAQUEKEYBLOBs are nontransferable and must be
	/// used within the CSP that generated the BLOB.
	/// </term>
	/// </item>
	/// <item>
	/// <term><c>PRIVATEKEYBLOB</c></term>
	/// <term>Used to transport public/private key pairs.</term>
	/// </item>
	/// <item>
	/// <term><c>PUBLICKEYBLOB</c></term>
	/// <term>Used to transport public keys.</term>
	/// </item>
	/// <item>
	/// <term><c>SIMPLEBLOB</c></term>
	/// <term>Used to transport session keys.</term>
	/// </item>
	/// <item>
	/// <term><c>PLAINTEXTKEYBLOB</c></term>
	/// <term>A PLAINTEXTKEYBLOB used to export any key supported by the CSP in use.</term>
	/// </item>
	/// <item>
	/// <term><c>SYMMETRICWRAPKEYBLOB</c></term>
	/// <term>
	/// Used to export and import a symmetric key wrapped with another symmetric key. The actual wrapped key is in the format specified in
	/// the IETF RFC 3217 standard.
	/// </term>
	/// </item>
	/// </list>
	/// </param>
	/// <param name="dwFlags">
	/// <para>
	/// Specifies additional options for the function. This parameter can be zero or a combination of one or more of the following values.
	/// </para>
	/// <list type="table">
	/// <listheader>
	/// <term>Value</term>
	/// <term>Meaning</term>
	/// </listheader>
	/// <item>
	/// <term><c>CRYPT_BLOB_VER3</c> 0x00000080</term>
	/// <term>This flag causes this function to export version 3 of a BLOB type.</term>
	/// </item>
	/// <item>
	/// <term><c>CRYPT_DESTROYKEY</c> 0x00000004</term>
	/// <term>This flag destroys the original key in the OPAQUEKEYBLOB. This flag is available in Schannel CSPs only.</term>
	/// </item>
	/// <item>
	/// <term><c>CRYPT_OAEP</c> 0x00000040</term>
	/// <term>This flag causes PKCS #1 version 2 formatting to be created with the RSA encryption and decryption when exporting SIMPLEBLOBs.</term>
	/// </item>
	/// <item>
	/// <term><c>CRYPT_SSL2_FALLBACK</c> 0x00000002</term>
	/// <term>
	/// The first eight bytes of the RSA encryption block padding must be set to 0x03 rather than to random data. This prevents version
	/// rollback attacks and is discussed in the SSL3 specification. This flag is available for Schannel CSPs only.
	/// </term>
	/// </item>
	/// <item>
	/// <term><c>CRYPT_Y_ONLY</c> 0x00000001</term>
	/// <term>This flag is not used.</term>
	/// </item>
	/// </list>
	/// </param>
	/// <param name="pbData">
	/// <para>
	/// A pointer to a buffer that receives the key BLOB data. The format of this BLOB varies depending on the BLOB type requested in the
	/// <c>dwBlobType</c> parameter. For the format for PRIVATEKEYBLOBs, PUBLICKEYBLOBs, and SIMPLEBLOBs, see Base Provider Key BLOBs.
	/// </para>
	/// <para>
	/// If this parameter is <c>NULL</c>, the required buffer size is placed in the value pointed to by the <c>pdwDataLen</c> parameter. For
	/// more information, see Retrieving Data of Unknown Length.
	/// </para>
	/// </param>
	/// <param name="pdwDataLen">
	/// <para>
	/// A pointer to a <c>DWORD</c> value that, on entry, contains the size, in bytes, of the buffer pointed to by the <c>pbData</c>
	/// parameter. When the function returns, this value contains the number of bytes stored in the buffer.
	/// </para>
	/// <para>
	/// <c>Note</c> When processing the data returned in the buffer, applications must use the actual size of the data returned. The actual
	/// size can be slightly smaller than the size of the buffer specified on input. On input, buffer sizes are usually specified large
	/// enough to ensure that the largest possible output data fits in the buffer. On output, the variable pointed to by this parameter is
	/// updated to reflect the actual size of the data copied to the buffer.
	/// </para>
	/// <para>
	/// To retrieve the required size of the <c>pbData</c> buffer, pass <c>NULL</c> for <c>pbData</c>.The required buffer size will be placed
	/// in the value pointed to by this parameter.
	/// </para>
	/// </param>
	/// <returns>
	/// <para>If the function succeeds, the function returns nonzero ( <c>TRUE</c>).</para>
	/// <para>If the function fails, it returns zero ( <c>FALSE</c>). For extended error information, call GetLastError.</para>
	/// <para>
	/// The error codes prefaced by "NTE" are generated by the particular CSP being used. The following table shows some of the possible
	/// error codes.
	/// </para>
	/// <list type="table">
	/// <listheader>
	/// <term>Return code</term>
	/// <term>Description</term>
	/// </listheader>
	/// <item>
	/// <term><c>ERROR_INVALID_HANDLE</c></term>
	/// <term>One of the parameters specifies a handle that is not valid.</term>
	/// </item>
	/// <item>
	/// <term><c>ERROR_INVALID_PARAMETER</c></term>
	/// <term>One of the parameters contains a value that is not valid. This is most often a pointer that is not valid.</term>
	/// </item>
	/// <item>
	/// <term><c>ERROR_MORE_DATA</c></term>
	/// <term>
	/// If the buffer specified by the <c>pbData</c> parameter is not large enough to hold the returned data, the function sets the
	/// ERROR_MORE_DATA code and stores the required buffer size, in bytes, in the variable pointed to by <c>pdwDataLen</c>.
	/// </term>
	/// </item>
	/// <item>
	/// <term><c>NTE_BAD_DATA</c></term>
	/// <term>
	/// Either the algorithm that works with the public key to be exported is not supported by this CSP, or an attempt was made to export a
	/// session key that was encrypted with something other than one of your public keys.
	/// </term>
	/// </item>
	/// <item>
	/// <term><c>NTE_BAD_FLAGS</c></term>
	/// <term>The <c>dwFlags</c> parameter is nonzero.</term>
	/// </item>
	/// <item>
	/// <term><c>NTE_BAD_KEY</c></term>
	/// <term>One or both of the keys specified by <c>hKey</c> and <c>hExpKey</c> are not valid.</term>
	/// </item>
	/// <item>
	/// <term><c>NTE_BAD_KEY_STATE</c></term>
	/// <term>
	/// You do not have permission to export the key. That is, when the <c>hKey</c> key was created, the CRYPT_EXPORTABLE flag was not specified.
	/// </term>
	/// </item>
	/// <item>
	/// <term><c>NTE_BAD_PUBLIC_KEY</c></term>
	/// <term>The key BLOB type specified by <c>dwBlobType</c> is PUBLICKEYBLOB, but <c>hExpKey</c> does not contain a public key handle.</term>
	/// </item>
	/// <item>
	/// <term><c>NTE_BAD_TYPE</c></term>
	/// <term>The <c>dwBlobType</c> parameter specifies an unknown BLOB type.</term>
	/// </item>
	/// <item>
	/// <term><c>NTE_BAD_UID</c></term>
	/// <term>The CSP context that was specified when the <c>hKey</c> key was created cannot be found.</term>
	/// </item>
	/// <item>
	/// <term><c>NTE_NO_KEY</c></term>
	/// <term>A session key is being exported, and the <c>hExpKey</c> parameter does not specify a public key.</term>
	/// </item>
	/// </list>
	/// </returns>
	/// <remarks>
	/// <para>
	/// For any of the DES key permutations that use a PLAINTEXTKEYBLOB, only the full key size, including parity bit, may be exported. The
	/// following key sizes are supported.
	/// </para>
	/// <list type="table">
	/// <listheader>
	/// <term>Algorithm</term>
	/// <term>Supported key size</term>
	/// </listheader>
	/// <item>
	/// <term>CALG_DES</term>
	/// <term>64 bits</term>
	/// </item>
	/// <item>
	/// <term>CALG_3DES_112</term>
	/// <term>128 bits</term>
	/// </item>
	/// <item>
	/// <term>CALG_3DES</term>
	/// <term>192 bits</term>
	/// </item>
	/// </list>
	/// <para>Examples</para>
	/// <para>
	/// The following example shows how to export a cryptographic key or a key pair in a more secure manner. This example assumes that a
	/// cryptographic context has been acquired and that a public key is available for export. For an example that includes the complete
	/// context for using this function, see Example C Program: Signing a Hash and Verifying the Hash Signature. For another example that
	/// uses this function, see Example C Program: Exporting a Session Key.
	/// </para>
	/// <para>
	/// <code>
	/// #include &lt;windows.h&gt;
	/// #include &lt;stdio.h&gt;
	/// #include &lt;Wincrypt.h&gt;
	/// 
	/// BOOL GetExportedKey( HCRYPTKEY hKey, DWORD dwBlobType, LPBYTE *ppbKeyBlob, LPDWORD pdwBlobLen) {
	///   DWORD dwBlobLength;
	///   *ppbKeyBlob = NULL;
	///   *pdwBlobLen = 0;
	///   // Export the public key. Here the public key is exported to a
	///   // PUBLICKEYBLOB. This BLOB can be written to a file and
	///   // sent to another user.
	///   if(CryptExportKey( hKey, NULL, dwBlobType, 0, NULL, &amp;dwBlobLength)) {
	///     printf("Size of the BLOB for the public key determined. \n");
	///   } else {
	///     printf("Error computing BLOB length.\n");
	///     return FALSE;
	///   }
	///   // Allocate memory for the pbKeyBlob.
	///   if(*ppbKeyBlob = (LPBYTE)malloc(dwBlobLength)) {
	///     printf("Memory has been allocated for the BLOB. \n"); }
	///   else {
	///     printf("Out of memory. \n");
	///     return FALSE;
	///   }
	///   // Do the actual exporting into the key BLOB.
	///   if(CryptExportKey( hKey, NULL, dwBlobType, 0, *ppbKeyBlob, &amp;dwBlobLength)) {
	///     printf("Contents have been written to the BLOB. \n");
	///     *pdwBlobLen = dwBlobLength; }
	///   else {
	///     printf("Error exporting key.\n");
	///     free(*ppbKeyBlob);
	///     *ppbKeyBlob = NULL;
	///     return FALSE;
	///   }
	///   return TRUE;
	/// }
	/// </code>
	/// </para>
	/// </remarks>
	// https://docs.microsoft.com/en-us/windows/win32/api/wincrypt/nf-wincrypt-cryptexportkey BOOL CryptExportKey( [in] HCRYPTKEY hKey, [in]
	// HCRYPTKEY hExpKey, [in] DWORD dwBlobType, [in] DWORD dwFlags, [out] BYTE *pbData, [in, out] DWORD *pdwDataLen );
	[DllImport(Lib.AdvApi32, SetLastError = true, ExactSpelling = true)]
	[PInvokeData("wincrypt.h", MSDNShortId = "NF:wincrypt.CryptExportKey")]
	[return: MarshalAs(UnmanagedType.Bool)]
	public static extern bool CryptExportKey(HCRYPTKEY hKey, [Optional] HCRYPTKEY hExpKey, BlobType dwBlobType, CryptExportKeyFlags dwFlags, [Out, Optional] IntPtr pbData, ref uint pdwDataLen);

	/// <summary>
	/// A handle to the key to be exported is passed to the function, and the function returns a key BLOB. This key BLOB can be sent over a
	/// nonsecure transport or stored in a nonsecure storage location. This function can export an Schannel session key, regular session key,
	/// public key, or public/private key pair. The key BLOB to export is useless until the intended recipient uses the CryptImportKey
	/// function on it to import the key or key pair into a recipient's CSP.
	/// </summary>
	/// <param name="hKey">A handle to the key to be exported.</param>
	/// <param name="hExpKey">
	/// <para>
	/// A handle to a cryptographic key of the destination user. The key data within the exported key BLOB is encrypted using this key. This
	/// ensures that only the destination user is able to make use of the key BLOB. Both <c>hExpKey</c> and <c>hKey</c> must come from the
	/// same CSP.
	/// </para>
	/// <para>
	/// Most often, this is the key exchange public key of the destination user. However, certain protocols in some CSPs require that a
	/// session key belonging to the destination user be used for this purpose.
	/// </para>
	/// <para>If the key BLOB type specified by <c>dwBlobType</c> is <c>PUBLICKEYBLOB</c>, this parameter is unused and must be set to zero.</para>
	/// <para>
	/// If the key BLOB type specified by <c>dwBlobType</c> is <c>PRIVATEKEYBLOB</c>, this is typically a handle to a session key that is to
	/// be used to encrypt the key BLOB. Some CSPs allow this parameter to be zero, in which case the application must encrypt the private
	/// key BLOB manually so as to protect it.
	/// </para>
	/// <para>
	/// To determine how Microsoft cryptographic service providers respond to this parameter, see the private key BLOB sections of Microsoft
	/// Cryptographic Service Providers.
	/// </para>
	/// <para>
	/// <c>Note</c> Some CSPs may modify this parameter as a result of the operation. Applications that subsequently use this key for other
	/// purposes should call the CryptDuplicateKey function to create a duplicate key handle. When the application has finished using the
	/// handle, release it by calling the CryptDestroyKey function.
	/// </para>
	/// </param>
	/// <param name="dwBlobType">
	/// <para>
	/// Specifies the type of key BLOB to be exported in <c>pbData</c>. This must be one of the following constants as discussed in
	/// Cryptographic Key Storage and Exchange.
	/// </para>
	/// <list type="table">
	/// <listheader>
	/// <term>Value</term>
	/// <term>Meaning</term>
	/// </listheader>
	/// <item>
	/// <term><c>OPAQUEKEYBLOB</c></term>
	/// <term>
	/// Used to store session keys in an Schannel CSP or any other vendor-specific format. OPAQUEKEYBLOBs are nontransferable and must be
	/// used within the CSP that generated the BLOB.
	/// </term>
	/// </item>
	/// <item>
	/// <term><c>PRIVATEKEYBLOB</c></term>
	/// <term>Used to transport public/private key pairs.</term>
	/// </item>
	/// <item>
	/// <term><c>PUBLICKEYBLOB</c></term>
	/// <term>Used to transport public keys.</term>
	/// </item>
	/// <item>
	/// <term><c>SIMPLEBLOB</c></term>
	/// <term>Used to transport session keys.</term>
	/// </item>
	/// <item>
	/// <term><c>PLAINTEXTKEYBLOB</c></term>
	/// <term>A PLAINTEXTKEYBLOB used to export any key supported by the CSP in use.</term>
	/// </item>
	/// <item>
	/// <term><c>SYMMETRICWRAPKEYBLOB</c></term>
	/// <term>
	/// Used to export and import a symmetric key wrapped with another symmetric key. The actual wrapped key is in the format specified in
	/// the IETF RFC 3217 standard.
	/// </term>
	/// </item>
	/// </list>
	/// </param>
	/// <param name="dwFlags">
	/// <para>
	/// Specifies additional options for the function. This parameter can be zero or a combination of one or more of the following values.
	/// </para>
	/// <list type="table">
	/// <listheader>
	/// <term>Value</term>
	/// <term>Meaning</term>
	/// </listheader>
	/// <item>
	/// <term><c>CRYPT_BLOB_VER3</c> 0x00000080</term>
	/// <term>This flag causes this function to export version 3 of a BLOB type.</term>
	/// </item>
	/// <item>
	/// <term><c>CRYPT_DESTROYKEY</c> 0x00000004</term>
	/// <term>This flag destroys the original key in the OPAQUEKEYBLOB. This flag is available in Schannel CSPs only.</term>
	/// </item>
	/// <item>
	/// <term><c>CRYPT_OAEP</c> 0x00000040</term>
	/// <term>This flag causes PKCS #1 version 2 formatting to be created with the RSA encryption and decryption when exporting SIMPLEBLOBs.</term>
	/// </item>
	/// <item>
	/// <term><c>CRYPT_SSL2_FALLBACK</c> 0x00000002</term>
	/// <term>
	/// The first eight bytes of the RSA encryption block padding must be set to 0x03 rather than to random data. This prevents version
	/// rollback attacks and is discussed in the SSL3 specification. This flag is available for Schannel CSPs only.
	/// </term>
	/// </item>
	/// <item>
	/// <term><c>CRYPT_Y_ONLY</c> 0x00000001</term>
	/// <term>This flag is not used.</term>
	/// </item>
	/// </list>
	/// </param>
	/// <param name="pbData">
	/// <para>
	/// A pointer to a buffer that receives the key BLOB data. The format of this BLOB varies depending on the BLOB type requested in the
	/// <c>dwBlobType</c> parameter. For the format for PRIVATEKEYBLOBs, PUBLICKEYBLOBs, and SIMPLEBLOBs, see Base Provider Key BLOBs.
	/// </para>
	/// <para>
	/// If this parameter is <c>NULL</c>, the required buffer size is placed in the value pointed to by the <c>pdwDataLen</c> parameter. For
	/// more information, see Retrieving Data of Unknown Length.
	/// </para>
	/// </param>
	/// <param name="pdwDataLen">
	/// <para>
	/// A pointer to a <c>DWORD</c> value that, on entry, contains the size, in bytes, of the buffer pointed to by the <c>pbData</c>
	/// parameter. When the function returns, this value contains the number of bytes stored in the buffer.
	/// </para>
	/// <para>
	/// <c>Note</c> When processing the data returned in the buffer, applications must use the actual size of the data returned. The actual
	/// size can be slightly smaller than the size of the buffer specified on input. On input, buffer sizes are usually specified large
	/// enough to ensure that the largest possible output data fits in the buffer. On output, the variable pointed to by this parameter is
	/// updated to reflect the actual size of the data copied to the buffer.
	/// </para>
	/// <para>
	/// To retrieve the required size of the <c>pbData</c> buffer, pass <c>NULL</c> for <c>pbData</c>.The required buffer size will be placed
	/// in the value pointed to by this parameter.
	/// </para>
	/// </param>
	/// <returns>
	/// <para>If the function succeeds, the function returns nonzero ( <c>TRUE</c>).</para>
	/// <para>If the function fails, it returns zero ( <c>FALSE</c>). For extended error information, call GetLastError.</para>
	/// <para>
	/// The error codes prefaced by "NTE" are generated by the particular CSP being used. The following table shows some of the possible
	/// error codes.
	/// </para>
	/// <list type="table">
	/// <listheader>
	/// <term>Return code</term>
	/// <term>Description</term>
	/// </listheader>
	/// <item>
	/// <term><c>ERROR_INVALID_HANDLE</c></term>
	/// <term>One of the parameters specifies a handle that is not valid.</term>
	/// </item>
	/// <item>
	/// <term><c>ERROR_INVALID_PARAMETER</c></term>
	/// <term>One of the parameters contains a value that is not valid. This is most often a pointer that is not valid.</term>
	/// </item>
	/// <item>
	/// <term><c>ERROR_MORE_DATA</c></term>
	/// <term>
	/// If the buffer specified by the <c>pbData</c> parameter is not large enough to hold the returned data, the function sets the
	/// ERROR_MORE_DATA code and stores the required buffer size, in bytes, in the variable pointed to by <c>pdwDataLen</c>.
	/// </term>
	/// </item>
	/// <item>
	/// <term><c>NTE_BAD_DATA</c></term>
	/// <term>
	/// Either the algorithm that works with the public key to be exported is not supported by this CSP, or an attempt was made to export a
	/// session key that was encrypted with something other than one of your public keys.
	/// </term>
	/// </item>
	/// <item>
	/// <term><c>NTE_BAD_FLAGS</c></term>
	/// <term>The <c>dwFlags</c> parameter is nonzero.</term>
	/// </item>
	/// <item>
	/// <term><c>NTE_BAD_KEY</c></term>
	/// <term>One or both of the keys specified by <c>hKey</c> and <c>hExpKey</c> are not valid.</term>
	/// </item>
	/// <item>
	/// <term><c>NTE_BAD_KEY_STATE</c></term>
	/// <term>
	/// You do not have permission to export the key. That is, when the <c>hKey</c> key was created, the CRYPT_EXPORTABLE flag was not specified.
	/// </term>
	/// </item>
	/// <item>
	/// <term><c>NTE_BAD_PUBLIC_KEY</c></term>
	/// <term>The key BLOB type specified by <c>dwBlobType</c> is PUBLICKEYBLOB, but <c>hExpKey</c> does not contain a public key handle.</term>
	/// </item>
	/// <item>
	/// <term><c>NTE_BAD_TYPE</c></term>
	/// <term>The <c>dwBlobType</c> parameter specifies an unknown BLOB type.</term>
	/// </item>
	/// <item>
	/// <term><c>NTE_BAD_UID</c></term>
	/// <term>The CSP context that was specified when the <c>hKey</c> key was created cannot be found.</term>
	/// </item>
	/// <item>
	/// <term><c>NTE_NO_KEY</c></term>
	/// <term>A session key is being exported, and the <c>hExpKey</c> parameter does not specify a public key.</term>
	/// </item>
	/// </list>
	/// </returns>
	/// <remarks>
	/// <para>
	/// For any of the DES key permutations that use a PLAINTEXTKEYBLOB, only the full key size, including parity bit, may be exported. The
	/// following key sizes are supported.
	/// </para>
	/// <list type="table">
	/// <listheader>
	/// <term>Algorithm</term>
	/// <term>Supported key size</term>
	/// </listheader>
	/// <item>
	/// <term>CALG_DES</term>
	/// <term>64 bits</term>
	/// </item>
	/// <item>
	/// <term>CALG_3DES_112</term>
	/// <term>128 bits</term>
	/// </item>
	/// <item>
	/// <term>CALG_3DES</term>
	/// <term>192 bits</term>
	/// </item>
	/// </list>
	/// <para>Examples</para>
	/// <para>
	/// The following example shows how to export a cryptographic key or a key pair in a more secure manner. This example assumes that a
	/// cryptographic context has been acquired and that a public key is available for export. For an example that includes the complete
	/// context for using this function, see Example C Program: Signing a Hash and Verifying the Hash Signature. For another example that
	/// uses this function, see Example C Program: Exporting a Session Key.
	/// </para>
	/// <para>
	/// <code>
	/// #include &lt;windows.h&gt;
	/// #include &lt;stdio.h&gt;
	/// #include &lt;Wincrypt.h&gt;
	/// 
	/// BOOL GetExportedKey( HCRYPTKEY hKey, DWORD dwBlobType, LPBYTE *ppbKeyBlob, LPDWORD pdwBlobLen) {
	///   DWORD dwBlobLength;
	///   *ppbKeyBlob = NULL;
	///   *pdwBlobLen = 0;
	///   // Export the public key. Here the public key is exported to a
	///   // PUBLICKEYBLOB. This BLOB can be written to a file and
	///   // sent to another user.
	///   if(CryptExportKey( hKey, NULL, dwBlobType, 0, NULL, &amp;dwBlobLength)) {
	///     printf("Size of the BLOB for the public key determined. \n");
	///   } else {
	///     printf("Error computing BLOB length.\n");
	///     return FALSE;
	///   }
	///   // Allocate memory for the pbKeyBlob.
	///   if(*ppbKeyBlob = (LPBYTE)malloc(dwBlobLength)) {
	///     printf("Memory has been allocated for the BLOB. \n"); }
	///   else {
	///     printf("Out of memory. \n");
	///     return FALSE;
	///   }
	///   // Do the actual exporting into the key BLOB.
	///   if(CryptExportKey( hKey, NULL, dwBlobType, 0, *ppbKeyBlob, &amp;dwBlobLength)) {
	///     printf("Contents have been written to the BLOB. \n");
	///     *pdwBlobLen = dwBlobLength; }
	///   else {
	///     printf("Error exporting key.\n");
	///     free(*ppbKeyBlob);
	///     *ppbKeyBlob = NULL;
	///     return FALSE;
	///   }
	///   return TRUE;
	/// }
	/// </code>
	/// </para>
	/// </remarks>
	// https://docs.microsoft.com/en-us/windows/win32/api/wincrypt/nf-wincrypt-cryptexportkey BOOL CryptExportKey( [in] HCRYPTKEY hKey, [in]
	// HCRYPTKEY hExpKey, [in] DWORD dwBlobType, [in] DWORD dwFlags, [out] BYTE *pbData, [in, out] DWORD *pdwDataLen );
	[DllImport(Lib.AdvApi32, SetLastError = true, ExactSpelling = true)]
	[PInvokeData("wincrypt.h", MSDNShortId = "NF:wincrypt.CryptExportKey")]
	[return: MarshalAs(UnmanagedType.Bool)]
	public static extern bool CryptExportKey(HCRYPTKEY hKey, [Optional] HCRYPTKEY hExpKey, BlobType dwBlobType, CryptExportKeyFlags dwFlags, [Out, Optional] byte[]? pbData, ref uint pdwDataLen);

	/// <summary>
	/// <para>
	/// The CryptGenKey function generates a random cryptographic session key or a public/private key pair. A handle to the key or key pair
	/// is returned in phKey. This handle can then be used as needed with any CryptoAPI function that requires a key handle.
	/// </para>
	/// <para>
	/// The calling application must specify the algorithm when calling this function. Because this algorithm type is kept bundled with the
	/// key, the application does not need to specify the algorithm later when the actual cryptographic operations are performed.
	/// </para>
	/// </summary>
	/// <param name="hProv">A handle to a cryptographic service provider (CSP) created by a call to CryptAcquireContext.</param>
	/// <param name="Algid">
	/// <para>
	/// An ALG_ID value that identifies the algorithm for which the key is to be generated. Values for this parameter vary depending on the
	/// CSP used.
	/// </para>
	/// <para>For <c>ALG_ID</c> values to use with the Microsoft Base Cryptographic Provider, see Base Provider Algorithms.</para>
	/// <para>
	/// For <c>ALG_ID</c> values to use with the Microsoft Strong Cryptographic Provider or the Microsoft Enhanced Cryptographic Provider,
	/// see Enhanced Provider Algorithms.
	/// </para>
	/// <para>For a Diffie-Hellman CSP, use one of the following values.</para>
	/// <list type="table">
	/// <listheader>
	/// <term>Value</term>
	/// <term>Meaning</term>
	/// </listheader>
	/// <item>
	/// <term>CALG_DH_EPHEM</term>
	/// <term>Specifies an "Ephemeral" Diffie-Hellman key.</term>
	/// </item>
	/// <item>
	/// <term>CALG_DH_SF</term>
	/// <term>Specifies a "Store and Forward" Diffie-Hellman key.</term>
	/// </item>
	/// </list>
	/// <para>
	/// In addition to generating session keys for symmetric algorithms, this function can also generate public/private key pairs. Each
	/// CryptoAPI client generally possesses two public/private key pairs. To generate one of these key pairs, set the Algid parameter to one
	/// of the following values.
	/// </para>
	/// <list type="table">
	/// <listheader>
	/// <term>Value</term>
	/// <term>Meaning</term>
	/// </listheader>
	/// <item>
	/// <term>AT_KEYEXCHANGE</term>
	/// <term>Key exchange</term>
	/// </item>
	/// <item>
	/// <term>AT_SIGNATURE</term>
	/// <term>Digital signature</term>
	/// </item>
	/// </list>
	/// <para>
	/// <c>Note</c> When key specifications AT_KEYEXCHANGE and AT_SIGNATURE are specified, the algorithm identifiers that are used to
	/// generate the key depend on the provider used. As a result, for these key specifications, the values returned from CryptGetKeyParam
	/// (when the KP_ALGID parameter is specified) depend on the provider used. To determine which algorithm identifier is used by the
	/// different providers for the key specs AT_KEYEXCHANGE and AT_SIGNATURE, see ALG_ID.
	/// </para>
	/// </param>
	/// <param name="dwFlags">
	/// <para>
	/// Specifies the type of key generated. The sizes of a session key, RSA signature key, and RSA key exchange keys can be set when the key
	/// is generated. The key size, representing the length of the key modulus in bits, is set with the upper 16 bits of this parameter.
	/// Thus, if a 2,048-bit RSA signature key is to be generated, the value 0x08000000 is combined with any other dwFlags predefined value
	/// with a bitwise- <c>OR</c> operation. The upper 16 bits of 0x08000000 is 0x0800, or decimal 2,048. The <c>RSA1024BIT_KEY</c> value can
	/// be used to specify a 1024-bit RSA key.
	/// </para>
	/// <para>
	/// Due to changing export control restrictions, the default CSP and default key length may change between operating system versions. It
	/// is important that both the encryption and decryption use the same CSP and that the key length be explicitly set using the dwFlags
	/// parameter to ensure interoperability on different operating system platforms.
	/// </para>
	/// <para>
	/// In particular, the default RSA Full Cryptographic Service Provider is the Microsoft RSA Strong Cryptographic Provider. The default
	/// DSS Signature Diffie-Hellman Cryptographic Service Provider is the Microsoft Enhanced DSS Diffie-Hellman Cryptographic Provider. Each
	/// of these CSPs has a default 128-bit symmetric key length for RC2 and RC4 and a 1,024-bit default key length for public key algorithms.
	/// </para>
	/// <para>
	/// If the upper 16 bits is zero, the default key size is generated. If a key larger than the maximum or smaller than the minimum is
	/// specified, the call fails with the ERROR_INVALID_PARAMETER code.
	/// </para>
	/// <para>The following table lists minimum, default, and maximum signature and exchange key lengths beginning with Windows XP.</para>
	/// <list type="table">
	/// <listheader>
	/// <term>Key type and provider</term>
	/// <term>Minimum length</term>
	/// <term>Default length</term>
	/// <term>Maximum length</term>
	/// </listheader>
	/// <item>
	/// <term>RSA Base Provider Signature and ExchangeKeys</term>
	/// <term>384</term>
	/// <term>512</term>
	/// <term>16,384</term>
	/// </item>
	/// <item>
	/// <term>RSA Strong and Enhanced Providers Signature and Exchange Keys</term>
	/// <term>384</term>
	/// <term>1,024</term>
	/// <term>16,384</term>
	/// </item>
	/// <item>
	/// <term>DSS Base Providers Signature Keys</term>
	/// <term>512</term>
	/// <term>1,024</term>
	/// <term>1,024</term>
	/// </item>
	/// <item>
	/// <term>DSS Base Providers Exchange Keys</term>
	/// <term>Not applicable</term>
	/// <term>Not applicable</term>
	/// <term>Not applicable</term>
	/// </item>
	/// <item>
	/// <term>DSS/DH Base Providers Signature Keys</term>
	/// <term>512</term>
	/// <term>1,024</term>
	/// <term>1,024</term>
	/// </item>
	/// <item>
	/// <term>DSS/DH Base Providers Exchange Keys</term>
	/// <term>512</term>
	/// <term>512</term>
	/// <term>1,024</term>
	/// </item>
	/// <item>
	/// <term>DSS/DH Enhanced Providers Signature Keys</term>
	/// <term>512</term>
	/// <term>1,024</term>
	/// <term>1,024</term>
	/// </item>
	/// <item>
	/// <term>DSS/DH Enhanced Providers Exchange Keys</term>
	/// <term>512</term>
	/// <term>1,024</term>
	/// <term>4,096</term>
	/// </item>
	/// </list>
	/// <para>For session key lengths, see CryptDeriveKey.</para>
	/// <para>For more information about keys generated using Microsoft providers, see Microsoft Cryptographic Service Providers.</para>
	/// <para>The lower 16-bits of this parameter can be zero or a combination of one or more of the following values.</para>
	/// <list type="table">
	/// <listheader>
	/// <term>Value</term>
	/// <term>Meaning</term>
	/// </listheader>
	/// <item>
	/// <term>CRYPT_ARCHIVABLE</term>
	/// <term>
	/// If this flag is set, the key can be exported until its handle is closed by a call to CryptDestroyKey. This allows newly generated
	/// keys to be exported upon creation for archiving or key recovery. After the handle is closed, the key is no longer exportable.
	/// </term>
	/// </item>
	/// <item>
	/// <term>CRYPT_CREATE_IV</term>
	/// <term>This flag is not used.</term>
	/// </item>
	/// <item>
	/// <term>CRYPT_CREATE_SALT</term>
	/// <term>
	/// If this flag is set, then the key is assigned a random salt value automatically. You can retrieve this salt value by using the
	/// CryptGetKeyParam function with the dwParam parameter set to KP_SALT. If this flag is not set, then the key is given a salt value of
	/// zero. When keys with nonzero salt values are exported (through CryptExportKey), then the salt value must also be obtained and kept
	/// with the key BLOB.
	/// </term>
	/// </item>
	/// <item>
	/// <term>CRYPT_DATA_KEY</term>
	/// <term>This flag is not used.</term>
	/// </item>
	/// <item>
	/// <term>CRYPT_EXPORTABLE</term>
	/// <term>
	/// If this flag is set, then the key can be transferred out of the CSP into a key BLOB by using the CryptExportKey function. Because
	/// session keys generally must be exportable, this flag should usually be set when they are created. If this flag is not set, then the
	/// key is not exportable. For a session key, this means that the key is available only within the current session and only the
	/// application that created it will be able to use it. For a public/private key pair, this means that the private key cannot be
	/// transported or backed up. This flag applies only to session key and private key BLOBs. It does not apply to public keys, which are
	/// always exportable.
	/// </term>
	/// </item>
	/// <item>
	/// <term>CRYPT_FORCE_KEY_PROTECTION_HIGH</term>
	/// <term>
	/// This flag specifies strong key protection. When this flag is set, the user is prompted to enter a password for the key when the key
	/// is created. The user will be prompted to enter the password whenever this key is used. This flag is only used by the CSPs that are
	/// provided by Microsoft. Third party CSPs will define their own behavior for strong key protection. Specifying this flag causes the
	/// same result as calling this function with the CRYPT_USER_PROTECTED flag when strong key protection is specified in the system
	/// registry. If this flag is specified and the provider handle in the hProv parameter was created by using the CRYPT_VERIFYCONTEXT or
	/// CRYPT_SILENT flag, this function will set the last error to NTE_SILENT_CONTEXT and return zero. Windows Server 2003 and Windows XP:
	/// This flag is not supported.
	/// </term>
	/// </item>
	/// <item>
	/// <term>CRYPT_KEK</term>
	/// <term>This flag is not used.</term>
	/// </item>
	/// <item>
	/// <term>CRYPT_INITIATOR</term>
	/// <term>This flag is not used.</term>
	/// </item>
	/// <item>
	/// <term>CRYPT_NO_SALT</term>
	/// <term>
	/// This flag specifies that a no salt value gets allocated for a forty-bit symmetric key. For more information, see Salt Value Functionality.
	/// </term>
	/// </item>
	/// <item>
	/// <term>CRYPT_ONLINE</term>
	/// <term>This flag is not used.</term>
	/// </item>
	/// <item>
	/// <term>CRYPT_PREGEN</term>
	/// <term>
	/// This flag specifies an initial Diffie-Hellman or DSS key generation. This flag is useful only with Diffie-Hellman and DSS CSPs. When
	/// used, a default key length will be used unless a key length is specified in the upper 16 bits of the dwFlags parameter. If parameters
	/// that involve key lengths are set on a PREGEN Diffie-Hellman or DSS key using CryptSetKeyParam, the key lengths must be compatible
	/// with the key length set here.
	/// </term>
	/// </item>
	/// <item>
	/// <term>CRYPT_RECIPIENT</term>
	/// <term>This flag is not used.</term>
	/// </item>
	/// <item>
	/// <term>CRYPT_SF</term>
	/// <term>This flag is not used.</term>
	/// </item>
	/// <item>
	/// <term>CRYPT_SGCKEY</term>
	/// <term>This flag is not used.</term>
	/// </item>
	/// <item>
	/// <term>CRYPT_USER_PROTECTED</term>
	/// <term>
	/// If this flag is set, the user is notified through a dialog box or another method when certain actions are attempting to use this key.
	/// The precise behavior is specified by the CSP being used. If the provider context was opened with the CRYPT_SILENT flag set, using
	/// this flag causes a failure and the last error is set to NTE_SILENT_CONTEXT.
	/// </term>
	/// </item>
	/// <item>
	/// <term>CRYPT_VOLATILE</term>
	/// <term>This flag is not used.</term>
	/// </item>
	/// </list>
	/// </param>
	/// <param name="phKey">
	/// Address to which the function copies the handle of the newly generated key. When you have finished using the key, delete the handle
	/// to the key by calling the CryptDestroyKey function.
	/// </param>
	/// <returns>
	/// <para>Returns nonzero if successful or zero otherwise.</para>
	/// <para>For extended error information, call GetLastError.</para>
	/// <para>
	/// The error codes prefaced by "NTE" are generated by the particular CSP being used. Some possible error codes are listed in the
	/// following table.
	/// </para>
	/// <list type="table">
	/// <listheader>
	/// <term>Return code</term>
	/// <term>Description</term>
	/// </listheader>
	/// <item>
	/// <term>ERROR_INVALID_HANDLE</term>
	/// <term>One of the parameters specifies a handle that is not valid.</term>
	/// </item>
	/// <item>
	/// <term>ERROR_INVALID_PARAMETER</term>
	/// <term>One of the parameters contains a value that is not valid. This is most often a pointer that is not valid.</term>
	/// </item>
	/// <item>
	/// <term>NTE_BAD_ALGID</term>
	/// <term>The Algid parameter specifies an algorithm that this CSP does not support.</term>
	/// </item>
	/// <item>
	/// <term>NTE_BAD_FLAGS</term>
	/// <term>The dwFlags parameter contains a value that is not valid.</term>
	/// </item>
	/// <item>
	/// <term>NTE_BAD_UID</term>
	/// <term>The hProv parameter does not contain a valid context handle.</term>
	/// </item>
	/// <item>
	/// <term>NTE_FAIL</term>
	/// <term>The function failed in some unexpected way.</term>
	/// </item>
	/// <item>
	/// <term>NTE_SILENT_CONTEXT</term>
	/// <term>The provider could not perform the action because the context was acquired as silent.</term>
	/// </item>
	/// </list>
	/// </returns>
	/// <remarks>
	/// <para>
	/// If keys are generated for symmetric block ciphers, the key, by default, is set up in cipher block chaining (CBC) mode with an
	/// initialization vector of zero. This cipher mode provides a good default method for bulk encrypting data. To change these parameters,
	/// use the CryptSetKeyParam function.
	/// </para>
	/// <para>To choose an appropriate key length, the following methods are recommended:</para>
	/// <list type="bullet">
	/// <item>
	/// <term>
	/// Enumerate the algorithms that the CSP supports and get maximum and minimum key lengths for each algorithm. To do this, call
	/// CryptGetProvParam with PP_ENUMALGS_EX.
	/// </term>
	/// </item>
	/// <item>
	/// <term>
	/// Use the minimum and maximum lengths to choose an appropriate key length. It is not always advisable to choose the maximum length
	/// because this can lead to performance issues.
	/// </term>
	/// </item>
	/// <item>
	/// <term>After the desired key length has been chosen, use the upper 16 bits of the dwFlags parameter to specify the key length.</term>
	/// </item>
	/// </list>
	/// <para>Examples</para>
	/// <para>
	/// The following example shows the creation of a random session key. For an example that includes the complete context for this example,
	/// see Example C Program: Encrypting a File. For another example that uses this function, see Example C Program: Decrypting a File.
	/// </para>
	/// </remarks>
	// https://docs.microsoft.com/en-us/windows/win32/api/wincrypt/nf-wincrypt-cryptgenkey BOOL CryptGenKey( HCRYPTPROV hProv, ALG_ID Algid,
	// DWORD dwFlags, HCRYPTKEY *phKey );
	[DllImport(Lib.AdvApi32, SetLastError = true, ExactSpelling = true)]
	[PInvokeData("wincrypt.h", MSDNShortId = "b65dd856-2dfa-4cda-9b2f-b32f3c291470")]
	[return: MarshalAs(UnmanagedType.Bool)]
	public static extern bool CryptGenKey(HCRYPTPROV hProv, ALG_ID Algid, CryptGenKeyFlags dwFlags, out SafeHCRYPTKEY phKey);

	/// <summary>The CryptGenRandom function fills a buffer with cryptographically random bytes.</summary>
	/// <param name="hProv">Handle of a cryptographic service provider (CSP) created by a call to CryptAcquireContext.</param>
	/// <param name="dwLen">Number of bytes of random data to be generated.</param>
	/// <param name="pbBuffer">
	/// <para>Buffer to receive the returned data. This buffer must be at least dwLen bytes in length.</para>
	/// <para>Optionally, the application can fill this buffer with data to use as an auxiliary random seed.</para>
	/// </param>
	/// <returns>
	/// <para>If the function succeeds, the return value is nonzero (TRUE).</para>
	/// <para>If the function fails, the return value is zero (FALSE). For extended error information, call GetLastError.</para>
	/// <para>
	/// The error codes prefaced by "NTE" are generated by the particular CSP being used. Some possible error codes are listed in the
	/// following table.
	/// </para>
	/// <list type="table">
	/// <listheader>
	/// <term>Return code</term>
	/// <term>Description</term>
	/// </listheader>
	/// <item>
	/// <term>ERROR_INVALID_HANDLE</term>
	/// <term>One of the parameters specifies a handle that is not valid.</term>
	/// </item>
	/// <item>
	/// <term>ERROR_INVALID_PARAMETER</term>
	/// <term>One of the parameters contains a value that is not valid. This is most often a pointer that is not valid.</term>
	/// </item>
	/// <item>
	/// <term>NTE_BAD_UID</term>
	/// <term>The hProv parameter does not contain a valid context handle.</term>
	/// </item>
	/// <item>
	/// <term>NTE_FAIL</term>
	/// <term>The function failed in some unexpected way.</term>
	/// </item>
	/// </list>
	/// </returns>
	/// <remarks>
	/// <para>
	/// The data produced by this function is cryptographically random. It is far more random than the data generated by the typical random
	/// number generator such as the one shipped with your C compiler.
	/// </para>
	/// <para>This function is often used to generate random initialization vectors and salt values.</para>
	/// <para>
	/// Software random number generators work in fundamentally the same way. They start with a random number, known as the seed, and then
	/// use an algorithm to generate a pseudo-random sequence of bits based on it. The most difficult part of this process is to get a seed
	/// that is truly random. This is usually based on user input latency, or the jitter from one or more hardware components.
	/// </para>
	/// <para>
	/// With Microsoft CSPs, <c>CryptGenRandom</c> uses the same random number generator used by other security components. This allows
	/// numerous processes to contribute to a system-wide seed. CryptoAPI stores an intermediate random seed with every user. To form the
	/// seed for the random number generator, a calling application supplies bits it might have—for instance, mouse or keyboard timing
	/// input—that are then combined with both the stored seed and various system data and user data such as the process ID and thread ID,
	/// the system clock, the system time, the system counter, memory status, free disk clusters, the hashed user environment block. This
	/// result is used to seed the pseudorandom number generator (PRNG). In Windows Vista with Service Pack 1 (SP1) and later, an
	/// implementation of the AES counter-mode based PRNG specified in NIST Special Publication 800-90 is used. In Windows Vista, Windows
	/// Storage Server 2003, and Windows XP, the PRNG specified in Federal Information Processing Standard (FIPS) 186-2 is used. If an
	/// application has access to a good random source, it can fill the pbBuffer buffer with some random data before calling
	/// <c>CryptGenRandom</c>. The CSP then uses this data to further randomize its internal seed. It is acceptable to omit the step of
	/// initializing the pbBuffer buffer before calling <c>CryptGenRandom</c>.
	/// </para>
	/// <para>Examples</para>
	/// <para>
	/// The following example shows the generation of 8 random bytes. These can be used to create cryptographic keys or for any application
	/// that uses random numbers. For an example that includes the complete context for this example, see Example C Program: Duplicating a
	/// Session Key.
	/// </para>
	/// </remarks>
	// https://docs.microsoft.com/en-us/windows/win32/api/wincrypt/nf-wincrypt-cryptgenrandom BOOL CryptGenRandom( HCRYPTPROV hProv, DWORD
	// dwLen, BYTE *pbBuffer );
	[DllImport(Lib.AdvApi32, SetLastError = true, ExactSpelling = true)]
	[PInvokeData("wincrypt.h", MSDNShortId = "3e5a437f-7439-43c9-a191-2908d2df0eb6")]
	[return: MarshalAs(UnmanagedType.Bool)]
	public static extern bool CryptGenRandom(HCRYPTPROV hProv, uint dwLen, [In, Out] IntPtr pbBuffer);

	/// <summary>
	/// The CryptGetDefaultProvider function finds the default cryptographic service provider (CSP) of a specified provider type for the
	/// local computer or current user. The name of the default CSP for the provider type specified in the dwProvType parameter is returned
	/// in the pszProvName buffer.
	/// </summary>
	/// <param name="dwProvType">
	/// <para>The provider type for which the default CSP name is to be found.</para>
	/// <para>Defined provider types are as follows:</para>
	/// <list type="bullet">
	/// <item>
	/// <term>PROV_RSA_FULL</term>
	/// </item>
	/// <item>
	/// <term>PROV_RSA_SIG</term>
	/// </item>
	/// <item>
	/// <term>PROV_DSS</term>
	/// </item>
	/// <item>
	/// <term>PROV_DSS_DH</term>
	/// </item>
	/// <item>
	/// <term>PROV_DH_SCHANNEL</term>
	/// </item>
	/// <item>
	/// <term>PROV_FORTEZZA</term>
	/// </item>
	/// <item>
	/// <term>PROV_MS_EXCHANGE</term>
	/// </item>
	/// <item>
	/// <term>PROV_RSA_SCHANNEL</term>
	/// </item>
	/// <item>
	/// <term>PROV_SSL</term>
	/// </item>
	/// </list>
	/// </param>
	/// <param name="pdwReserved">This parameter is reserved for future use and must be <c>NULL</c>.</param>
	/// <param name="dwFlags">
	/// <para>The following flag values are defined.</para>
	/// <list type="table">
	/// <listheader>
	/// <term>Value</term>
	/// <term>Meaning</term>
	/// </listheader>
	/// <item>
	/// <term>CRYPT_USER_DEFAULT 0x00000002</term>
	/// <term>Returns the user-context default CSP of the specified type.</term>
	/// </item>
	/// <item>
	/// <term>CRYPT_MACHINE_DEFAULT 0x00000001</term>
	/// <term>Returns the computer default CSP of the specified type.</term>
	/// </item>
	/// </list>
	/// </param>
	/// <param name="pszProvName">
	/// <para>A pointer to a null-terminated character string buffer to receive the name of the default CSP.</para>
	/// <para>
	/// To find the size of the buffer for memory allocation purposes, this parameter can be <c>NULL</c>. For more information, see
	/// Retrieving Data of Unknown Length.
	/// </para>
	/// </param>
	/// <param name="pcbProvName">
	/// <para>
	/// A pointer to a <c>DWORD</c> value that specifies the size, in bytes, of the buffer pointed to by the pszProvName parameter. When the
	/// function returns, the <c>DWORD</c> value contains the number of bytes stored or to be stored in the buffer.
	/// </para>
	/// <para>
	/// <c>Note</c> When processing the data returned in the buffer, applications must use the actual size of the data returned. The actual
	/// size can be slightly smaller than the size of the buffer specified on input. (On input, buffer sizes are usually specified large
	/// enough to ensure that the largest possible output data fits in the buffer.) On output, the variable pointed to by this parameter is
	/// updated to reflect the actual size of the data copied to the buffer.
	/// </para>
	/// </param>
	/// <returns>
	/// <para>If the function succeeds, the return value is nonzero ( <c>TRUE</c>).</para>
	/// <para>If the function fails, the return value is zero ( <c>FALSE</c>). For extended error information, call GetLastError.</para>
	/// <para>The error code prefaced by NTE is generated by the particular CSP being used. Possible error codes include the following.</para>
	/// <list type="table">
	/// <listheader>
	/// <term>Return code</term>
	/// <term>Description</term>
	/// </listheader>
	/// <item>
	/// <term>ERROR_INVALID_PARAMETER</term>
	/// <term>One of the parameters contains a value that is not valid. This is most often a pointer that is not valid.</term>
	/// </item>
	/// <item>
	/// <term>ERROR_MORE_DATA</term>
	/// <term>The buffer for the name is not large enough.</term>
	/// </item>
	/// <item>
	/// <term>ERROR_NOT_ENOUGH_MEMORY</term>
	/// <term>The operating system ran out of memory.</term>
	/// </item>
	/// <item>
	/// <term>NTE_BAD_FLAGS</term>
	/// <term>The dwFlags parameter has an unrecognized value.</term>
	/// </item>
	/// </list>
	/// </returns>
	/// <remarks>
	/// <para>
	/// This function determines which installed CSP is currently set as the default for the local computer or current user. This information
	/// is often displayed to the user.
	/// </para>
	/// <para>Examples</para>
	/// <para>
	/// The following example retrieves the name of the default CSP for the PROV_RSA_FULL provider type. For another example that uses this
	/// function, see Example C Program: Enumerating CSP Providers and Provider Types.
	/// </para>
	/// </remarks>
	// https://docs.microsoft.com/en-us/windows/win32/api/wincrypt/nf-wincrypt-cryptgetdefaultprovidera BOOL CryptGetDefaultProviderA( DWORD
	// dwProvType, DWORD *pdwReserved, DWORD dwFlags, LPSTR pszProvName, DWORD *pcbProvName );
	[DllImport(Lib.AdvApi32, SetLastError = true, CharSet = CharSet.Auto)]
	[PInvokeData("wincrypt.h", MSDNShortId = "5d15641e-1ad7-441d-9423-65fd51de9812")]
	[return: MarshalAs(UnmanagedType.Bool)]
	public static extern bool CryptGetDefaultProvider(uint dwProvType, [Optional] IntPtr pdwReserved, CryptProviderFlags dwFlags, [MarshalAs(UnmanagedType.LPTStr)] StringBuilder? pszProvName, ref uint pcbProvName);

	/// <summary>
	/// The CryptGetHashParam function retrieves data that governs the operations of a hash object. The actual hash value can be retrieved by
	/// using this function.
	/// </summary>
	/// <param name="hHash">Handle of the hash object to be queried.</param>
	/// <param name="dwParam">
	/// <para>Query type. This parameter can be set to one of the following queries.</para>
	/// <list type="table">
	/// <listheader>
	/// <term>Value</term>
	/// <term>Meaning</term>
	/// </listheader>
	/// <item>
	/// <term>HP_ALGID Hash algorithm</term>
	/// <term>An ALG_ID that indicates the algorithm specified when the hash object was created. For a list of hash algorithms, see CryptCreateHash.</term>
	/// </item>
	/// <item>
	/// <term>HP_HASHSIZE Hash value size</term>
	/// <term>
	/// DWORD value indicating the number of bytes in the hash value. This value will vary depending on the hash algorithm. Applications must
	/// retrieve this value just before the HP_HASHVAL value so the correct amount of memory can be allocated.
	/// </term>
	/// </item>
	/// <item>
	/// <term>HP_HASHVAL Hash value</term>
	/// <term>
	/// The hash value or message hash for the hash object specified by hHash. This value is generated based on the data supplied to the hash
	/// object earlier through the CryptHashData and CryptHashSessionKey functions. The CryptGetHashParam function completes the hash. After
	/// CryptGetHashParam has been called, no more data can be added to the hash. Additional calls to CryptHashData or CryptHashSessionKey
	/// fail. After the application is done with the hash, CryptDestroyHash should be called to destroy the hash object.
	/// </term>
	/// </item>
	/// </list>
	/// <para><c>Note</c> CSPs can add more values that this function can query.</para>
	/// </param>
	/// <param name="pbData">
	/// <para>A pointer to a buffer that receives the specified value data. The form of this data varies, depending on the value number.</para>
	/// <para>This parameter can be <c>NULL</c> to determine the memory size required.</para>
	/// </param>
	/// <param name="pdwDataLen">
	/// <para>
	/// A pointer to a <c>DWORD</c> value specifying the size, in bytes, of the pbData buffer. When the function returns, the <c>DWORD</c>
	/// value contains the number of bytes stored in the buffer.
	/// </para>
	/// <para>If pbData is <c>NULL</c>, set the value of pdwDataLen to zero.</para>
	/// <para>
	/// <c>Note</c> When processing the data returned in the buffer, applications must use the actual size of the data returned. The actual
	/// size can be slightly smaller than the size of the buffer specified on input. (On input, buffer sizes are usually specified large
	/// enough to ensure that the largest possible output data fits in the buffer.) On output, the variable pointed to by this parameter is
	/// updated to reflect the actual size of the data copied to the buffer.
	/// </para>
	/// </param>
	/// <param name="dwFlags">Reserved for future use and must be zero.</param>
	/// <returns>
	/// <para>If the function succeeds, the return value is <c>TRUE</c>.</para>
	/// <para>If the function fails, the return value is <c>FALSE</c>. For extended error information, call GetLastError.</para>
	/// <para>The error codes prefaced by "NTE" are generated by the particular CSP you are using. Some possible error codes follow.</para>
	/// <list type="table">
	/// <listheader>
	/// <term>Return code</term>
	/// <term>Description</term>
	/// </listheader>
	/// <item>
	/// <term>ERROR_INVALID_HANDLE</term>
	/// <term>One of the parameters specifies a handle that is not valid.</term>
	/// </item>
	/// <item>
	/// <term>ERROR_INVALID_PARAMETER</term>
	/// <term>One of the parameters contains a value that is not valid. This is most often a pointer that is not valid.</term>
	/// </item>
	/// <item>
	/// <term>ERROR_MORE_DATA</term>
	/// <term>
	/// If the buffer specified by the pbData parameter is not large enough to hold the returned data, the function sets the ERROR_MORE_DATA
	/// code and stores the required buffer size, in bytes, in the variable pointed to by pdwDataLen.
	/// </term>
	/// </item>
	/// <item>
	/// <term>NTE_BAD_FLAGS</term>
	/// <term>The dwFlags parameter is nonzero.</term>
	/// </item>
	/// <item>
	/// <term>NTE_BAD_HASH</term>
	/// <term>The hash object specified by the hHash parameter is not valid.</term>
	/// </item>
	/// <item>
	/// <term>NTE_BAD_TYPE</term>
	/// <term>The dwParam parameter specifies an unknown value number.</term>
	/// </item>
	/// <item>
	/// <term>NTE_BAD_UID</term>
	/// <term>The CSP context that was specified when the hash was created cannot be found.</term>
	/// </item>
	/// </list>
	/// </returns>
	// https://docs.microsoft.com/en-us/windows/win32/api/wincrypt/nf-wincrypt-cryptgethashparam BOOL CryptGetHashParam( HCRYPTHASH hHash,
	// DWORD dwParam, BYTE *pbData, DWORD *pdwDataLen, DWORD dwFlags );
	[DllImport(Lib.AdvApi32, SetLastError = true, ExactSpelling = true)]
	[PInvokeData("wincrypt.h", MSDNShortId = "ed008c07-1a40-4075-bdaa-eb7f7e12d9c3")]
	[return: MarshalAs(UnmanagedType.Bool)]
	public static extern bool CryptGetHashParam(HCRYPTHASH hHash, HashParam dwParam, [Out, Optional] IntPtr pbData, ref uint pdwDataLen, uint dwFlags = 0);

	/// <summary>
	/// The CryptGetHashParam function retrieves data that governs the operations of a hash object. The actual hash value can be retrieved by
	/// using this function.
	/// </summary>
	/// <typeparam name="T">The expected return type.</typeparam>
	/// <param name="hHash">Handle of the hash object to be queried.</param>
	/// <param name="dwParam">
	/// <para>Query type. This parameter can be set to one of the following queries.</para>
	/// <list type="table">
	/// <listheader>
	/// <term>Value</term>
	/// <term>Meaning</term>
	/// </listheader>
	/// <item>
	/// <term>HP_ALGID Hash algorithm</term>
	/// <term>An ALG_ID that indicates the algorithm specified when the hash object was created. For a list of hash algorithms, see CryptCreateHash.</term>
	/// </item>
	/// <item>
	/// <term>HP_HASHSIZE Hash value size</term>
	/// <term>
	/// DWORD value indicating the number of bytes in the hash value. This value will vary depending on the hash algorithm. Applications must
	/// retrieve this value just before the HP_HASHVAL value so the correct amount of memory can be allocated.
	/// </term>
	/// </item>
	/// <item>
	/// <term>HP_HASHVAL Hash value</term>
	/// <term>
	/// The hash value or message hash for the hash object specified by hHash. This value is generated based on the data supplied to the hash
	/// object earlier through the CryptHashData and CryptHashSessionKey functions. The CryptGetHashParam function completes the hash. After
	/// CryptGetHashParam has been called, no more data can be added to the hash. Additional calls to CryptHashData or CryptHashSessionKey
	/// fail. After the application is done with the hash, CryptDestroyHash should be called to destroy the hash object.
	/// </term>
	/// </item>
	/// </list>
	/// <para><c>Note</c> CSPs can add more values that this function can query.</para>
	/// </param>
	/// <returns>The specified value data. The form of this data varies, depending on the value number.</returns>
	public static T? CryptGetHashParam<T>(HCRYPTHASH hHash, HashParam dwParam) => CryptGetValue<HCRYPTHASH, HashParam, T>(CryptGetHashParam, hHash, dwParam);

	/// <summary>
	/// The CryptGetKeyParam function retrieves data that governs the operations of a key. If the Microsoft Cryptographic Service Provider is
	/// used, the base symmetric keying material is not obtainable by this or any other function.
	/// </summary>
	/// <param name="hKey">The handle of the key being queried.</param>
	/// <param name="dwParam">
	/// <para>Specifies the type of query being made.</para>
	/// <para>For all key types, this parameter can contain one of the following values.</para>
	/// <list type="table">
	/// <listheader>
	/// <term>Value</term>
	/// <term>Meaning</term>
	/// </listheader>
	/// <item>
	/// <term>KP_ALGID</term>
	/// <term>
	/// Retrieve the key algorithm. The pbData parameter is a pointer to an ALG_ID value that receives the identifier of the algorithm that
	/// was specified when the key was created. When AT_KEYEXCHANGE or AT_SIGNATURE is specified for the Algid parameter of the CryptGenKey
	/// function, the algorithm identifiers that are used to generate the key depend on the provider used. For more information, see ALG_ID.
	/// </term>
	/// </item>
	/// <item>
	/// <term>KP_BLOCKLEN</term>
	/// <term>
	/// If a session key is specified by the hKey parameter, retrieve the block length of the key cipher. The pbData parameter is a pointer
	/// to a DWORD value that receives the block length, in bits. For stream ciphers, this value is always zero. If a public/private key pair
	/// is specified by hKey, retrieve the encryption granularity of the key pair. The pbData parameter is a pointer to a DWORD value that
	/// receives the encryption granularity, in bits. For example, the Microsoft Base Cryptographic Provider generates 512-bit RSA key pairs,
	/// so a value of 512 is returned for these keys. If the public key algorithm does not support encryption, the value retrieved is undefined.
	/// </term>
	/// </item>
	/// <item>
	/// <term>KP_CERTIFICATE</term>
	/// <term>
	/// pbData is the address of a buffer that receives the X.509 certificate that has been encoded by using Distinguished Encoding Rules
	/// (DER). The public key in the certificate must match the corresponding signature or exchange key.
	/// </term>
	/// </item>
	/// <item>
	/// <term>KP_GET_USE_COUNT</term>
	/// <term>This value is not used.</term>
	/// </item>
	/// <item>
	/// <term>KP_KEYLEN</term>
	/// <term>
	/// Retrieve the actual length of the key. The pbData parameter is a pointer to a DWORD value that receives the key length, in bits.
	/// KP_KEYLEN can be used to get the length of any key type. Microsoft cryptographic service providers (CSPs) return a key length of 64
	/// bits for CALG_DES, 128 bits for CALG_3DES_112, and 192 bits for CALG_3DES. These lengths are different from the lengths returned when
	/// you are enumerating algorithms with the dwParam value of the CryptGetProvParam function set to PP_ENUMALGS. The length returned by
	/// this call is the actual size of the key, including the parity bits included in the key. Microsoft CSPs that support the
	/// CALG_CYLINK_MEK ALG_ID return 64 bits for that algorithm. CALG_CYLINK_MEK is a 40-bit key but has parity and zeroed key bits to make
	/// the key length 64 bits.
	/// </term>
	/// </item>
	/// <item>
	/// <term>KP_SALT</term>
	/// <term>
	/// Retrieve the salt value of the key. The pbData parameter is a pointer to a BYTE array that receives the salt value in little-endian
	/// form. The size of the salt value varies depending on the CSP and algorithm being used. Salt values do not apply to public/private key pairs.
	/// </term>
	/// </item>
	/// <item>
	/// <term>KP_PERMISSIONS</term>
	/// <term>
	/// Retrieve the key permissions. The pbData parameter is a pointer to a DWORD value that receives the permission flags for the key. The
	/// following permission identifiers are currently defined. The key permissions can be zero or a combination of one or more of the
	/// following values. CRYPT_ARCHIVE Allow export during the lifetime of the handle of the key. This permission can be set only if it is
	/// already set in the internal permissions field of the key. Attempts to clear this permission are ignored. CRYPT_DECRYPT Allow
	/// decryption. CRYPT_ENCRYPT Allow encryption. CRYPT_EXPORT Allow the key to be exported. CRYPT_EXPORT_KEY Allow the key to be used for
	/// exporting keys. CRYPT_IMPORT_KEY Allow the key to be used for importing keys. CRYPT_MAC Allow Message Authentication Codes (MACs) to
	/// be used with key. CRYPT_READ Allow values to be read. CRYPT_WRITE Allow values to be set.
	/// </term>
	/// </item>
	/// </list>
	/// <para>
	/// If a Digital Signature Standard (DSS) key is specified by the hKey parameter, the dwParam value can also be set to one of the
	/// following values.
	/// </para>
	/// <list type="table">
	/// <listheader>
	/// <term>Value</term>
	/// <term>Meaning</term>
	/// </listheader>
	/// <item>
	/// <term>KP_P</term>
	/// <term>
	/// Retrieve the modulus prime number P of the DSS key. The pbData parameter is a pointer to a buffer that receives the value in
	/// little-endian form. The pdwDataLen parameter contains the size of the buffer, in bytes.
	/// </term>
	/// </item>
	/// <item>
	/// <term>KP_Q</term>
	/// <term>
	/// Retrieve the modulus prime number Q of the DSS key. The pbData parameter is a pointer to a buffer that receives the value in
	/// little-endian form. The pdwDataLen parameter contains the size of the buffer, in bytes.
	/// </term>
	/// </item>
	/// <item>
	/// <term>KP_G</term>
	/// <term>
	/// Retrieve the generator G of the DSS key. The pbData parameter is a pointer to a buffer that receives the value in little-endian form.
	/// The pdwDataLen parameter contains the size of the buffer, in bytes.
	/// </term>
	/// </item>
	/// </list>
	/// <para>
	/// If a block cipher session key is specified by the hKey parameter, the dwParam value can also be set to one of the following values.
	/// </para>
	/// <list type="table">
	/// <listheader>
	/// <term>Value</term>
	/// <term>Meaning</term>
	/// </listheader>
	/// <item>
	/// <term>KP_EFFECTIVE_KEYLEN</term>
	/// <term>
	/// Retrieve the effective key length of an RC2 key. The pbData parameter is a pointer to a DWORD value that receives the effective key length.
	/// </term>
	/// </item>
	/// <item>
	/// <term>KP_IV</term>
	/// <term>
	/// Retrieve the initialization vector of the key. The pbData parameter is a pointer to a BYTE array that receives the initialization
	/// vector. The size of this array is the block size, in bytes. For example, if the block length is 64 bits, the initialization vector
	/// consists of 8 bytes.
	/// </term>
	/// </item>
	/// <item>
	/// <term>KP_PADDING</term>
	/// <term>
	/// Retrieve the padding mode. The pbData parameter is a pointer to a DWORD value that receives a numeric identifier that identifies the
	/// padding method used by the cipher. This can be one of the following values. PKCS5_PADDING Specifies the PKCS 5 (sec 6.2) padding
	/// method. RANDOM_PADDING The padding uses random numbers. This padding method is not supported by the Microsoft supplied CSPs.
	/// ZERO_PADDING The padding uses zeros. This padding method is not supported by the Microsoft supplied CSPs.
	/// </term>
	/// </item>
	/// <item>
	/// <term>KP_MODE</term>
	/// <term>
	/// Retrieve the cipher mode. The pbData parameter is a pointer to a DWORD value that receives a cipher mode identifier. For more
	/// information about cipher modes, see Data Encryption and Decryption. The following cipher mode identifiers are currently defined.
	/// CRYPT_MODE_CBC The cipher mode is cipher block chaining. CRYPT_MODE_CFB The cipher mode is cipher feedback (CFB). Microsoft CSPs
	/// currently support only 8-bit feedback in cipher feedback mode. CRYPT_MODE_ECB The cipher mode is electronic codebook. CRYPT_MODE_OFB
	/// The cipher mode is Output Feedback (OFB). Microsoft CSPs currently do not support Output Feedback Mode. CRYPT_MODE_CTS The cipher
	/// mode is ciphertext stealing mode.
	/// </term>
	/// </item>
	/// <item>
	/// <term>KP_MODE_BITS</term>
	/// <term>
	/// Retrieve the number of bits to feed back. The pbData parameter is a pointer to a DWORD value that receives the number of bits that
	/// are processed per cycle when the OFB or CFB cipher modes are used.
	/// </term>
	/// </item>
	/// </list>
	/// <para>
	/// If a Diffie-Hellman algorithm or Digital Signature Algorithm (DSA) key is specified by hKey, the dwParam value can also be set to the
	/// following value.
	/// </para>
	/// <list type="table">
	/// <listheader>
	/// <term>Value</term>
	/// <term>Meaning</term>
	/// </listheader>
	/// <item>
	/// <term>KP_VERIFY_PARAMS</term>
	/// <term>
	/// Verifies the parameters of a Diffie-Hellman algorithm or DSA key. The pbData parameter is not used, and the value pointed to by
	/// pdwDataLen receives zero. This function returns a nonzero value if the key parameters are valid or zero otherwise.
	/// </term>
	/// </item>
	/// <item>
	/// <term>KP_KEYVAL</term>
	/// <term>
	/// This value is not used. Windows Vista, Windows Server 2003 and Windows XP: Retrieve the secret agreement value from an imported
	/// Diffie-Hellman algorithm key of type CALG_AGREEDKEY_ANY. The pbData parameter is the address of a buffer that receives the secret
	/// agreement value, in little-endian format. This buffer must be the same length as the key. The dwFlags parameter must be set to
	/// 0xF42A19B6. This property can only be retrieved by a thread running under the local system account.This property is available for use
	/// in the operating systems listed above. It may be altered or unavailable in subsequent versions.
	/// </term>
	/// </item>
	/// </list>
	/// <para>If a certificate is specified by hKey, the dwParam value can also be set to the following value.</para>
	/// <list type="table">
	/// <listheader>
	/// <term>Value</term>
	/// <term>Meaning</term>
	/// </listheader>
	/// <item>
	/// <term>KP_CERTIFICATE</term>
	/// <term>
	/// A buffer that contains the DER-encoded X.509 certificate. The pbData parameter is not used, and the value pointed to by pdwDataLen
	/// receives zero. This function returns a nonzero value if the key parameters are valid or zero otherwise.
	/// </term>
	/// </item>
	/// </list>
	/// </param>
	/// <param name="pbData">
	/// <para>A pointer to a buffer that receives the data. The form of this data depends on the value of dwParam.</para>
	/// <para>
	/// If the size of this buffer is not known, the required size can be retrieved at run time by passing <c>NULL</c> for this parameter and
	/// setting the value pointed to by pdwDataLen to zero. This function will place the required size of the buffer, in bytes, in the value
	/// pointed to by pdwDataLen. For more information, see Retrieving Data of Unknown Length.
	/// </para>
	/// </param>
	/// <param name="pdwDataLen">
	/// <para>
	/// A pointer to a <c>DWORD</c> value that, on entry, contains the size, in bytes, of the buffer pointed to by the pbData parameter. When
	/// the function returns, the <c>DWORD</c> value contains the number of bytes stored in the buffer.
	/// </para>
	/// <para>
	/// <c>Note</c> When processing the data returned in the buffer, applications must use the actual size of the data returned. The actual
	/// size may be slightly smaller than the size of the buffer specified on input. On input, buffer sizes are sometimes specified large
	/// enough to ensure that the largest possible output data fits in the buffer. On output, the variable pointed to by this parameter is
	/// updated to reflect the actual size of the data copied to the buffer.
	/// </para>
	/// </param>
	/// <param name="dwFlags">This parameter is reserved for future use and must be set to zero.</param>
	/// <returns>
	/// <para>If the function succeeds, the function returns nonzero.</para>
	/// <para>If the function fails, it returns zero. For extended error information, call GetLastError.</para>
	/// <para>The error codes prefaced by "NTE" are generated by the particular CSP being used. Some possible error codes include the following.</para>
	/// <list type="table">
	/// <listheader>
	/// <term>Return code</term>
	/// <term>Description</term>
	/// </listheader>
	/// <item>
	/// <term>ERROR_INVALID_HANDLE</term>
	/// <term>One of the parameters specifies a handle that is not valid.</term>
	/// </item>
	/// <item>
	/// <term>ERROR_INVALID_PARAMETER</term>
	/// <term>One of the parameters contains a value that is not valid. This is most often a pointer that is not valid.</term>
	/// </item>
	/// <item>
	/// <term>ERROR_MORE_DATA</term>
	/// <term>
	/// If the buffer specified by the pbData parameter is not large enough to hold the returned data, the function sets the ERROR_MORE_DATA
	/// code and stores the required buffer size, in bytes, in the variable pointed to by pdwDataLen.
	/// </term>
	/// </item>
	/// <item>
	/// <term>NTE_BAD_FLAGS</term>
	/// <term>The dwFlags parameter is nonzero.</term>
	/// </item>
	/// <item>
	/// <term>NTE_BAD_KEY or NTE_NO_KEY</term>
	/// <term>The key specified by the hKey parameter is not valid.</term>
	/// </item>
	/// <item>
	/// <term>NTE_BAD_TYPE</term>
	/// <term>The dwParam parameter specifies an unknown value number.</term>
	/// </item>
	/// <item>
	/// <term>NTE_BAD_UID</term>
	/// <term>The CSP context that was specified when the key was created cannot be found.</term>
	/// </item>
	/// </list>
	/// </returns>
	// https://docs.microsoft.com/en-us/windows/win32/api/wincrypt/nf-wincrypt-cryptgetkeyparam BOOL CryptGetKeyParam( HCRYPTKEY hKey, DWORD
	// dwParam, BYTE *pbData, DWORD *pdwDataLen, DWORD dwFlags );
	[DllImport(Lib.AdvApi32, SetLastError = true, ExactSpelling = true)]
	[PInvokeData("wincrypt.h", MSDNShortId = "07956d74-0e22-484b-9bf1-e0184a2ff32f")]
	[return: MarshalAs(UnmanagedType.Bool)]
	public static extern bool CryptGetKeyParam(HCRYPTKEY hKey, KeyParam dwParam, [Out, Optional] IntPtr pbData, ref uint pdwDataLen, uint dwFlags = 0);

	/// <summary>
	/// The CryptGetKeyParam function retrieves data that governs the operations of a key. If the Microsoft Cryptographic Service Provider is
	/// used, the base symmetric keying material is not obtainable by this or any other function.
	/// </summary>
	/// <typeparam name="T">The expected return type.</typeparam>
	/// <param name="hKey">The handle of the key being queried.</param>
	/// <param name="dwParam">
	/// <para>Specifies the type of query being made.</para>
	/// <para>For all key types, this parameter can contain one of the following values.</para>
	/// <list type="table">
	/// <listheader>
	/// <term>Value</term>
	/// <term>Meaning</term>
	/// </listheader>
	/// <item>
	/// <term>KP_ALGID</term>
	/// <term>
	/// Retrieve the key algorithm. The pbData parameter is a pointer to an ALG_ID value that receives the identifier of the algorithm that
	/// was specified when the key was created. When AT_KEYEXCHANGE or AT_SIGNATURE is specified for the Algid parameter of the CryptGenKey
	/// function, the algorithm identifiers that are used to generate the key depend on the provider used. For more information, see ALG_ID.
	/// </term>
	/// </item>
	/// <item>
	/// <term>KP_BLOCKLEN</term>
	/// <term>
	/// If a session key is specified by the hKey parameter, retrieve the block length of the key cipher. The pbData parameter is a pointer
	/// to a DWORD value that receives the block length, in bits. For stream ciphers, this value is always zero. If a public/private key pair
	/// is specified by hKey, retrieve the encryption granularity of the key pair. The pbData parameter is a pointer to a DWORD value that
	/// receives the encryption granularity, in bits. For example, the Microsoft Base Cryptographic Provider generates 512-bit RSA key pairs,
	/// so a value of 512 is returned for these keys. If the public key algorithm does not support encryption, the value retrieved is undefined.
	/// </term>
	/// </item>
	/// <item>
	/// <term>KP_CERTIFICATE</term>
	/// <term>
	/// pbData is the address of a buffer that receives the X.509 certificate that has been encoded by using Distinguished Encoding Rules
	/// (DER). The public key in the certificate must match the corresponding signature or exchange key.
	/// </term>
	/// </item>
	/// <item>
	/// <term>KP_GET_USE_COUNT</term>
	/// <term>This value is not used.</term>
	/// </item>
	/// <item>
	/// <term>KP_KEYLEN</term>
	/// <term>
	/// Retrieve the actual length of the key. The pbData parameter is a pointer to a DWORD value that receives the key length, in bits.
	/// KP_KEYLEN can be used to get the length of any key type. Microsoft cryptographic service providers (CSPs) return a key length of 64
	/// bits for CALG_DES, 128 bits for CALG_3DES_112, and 192 bits for CALG_3DES. These lengths are different from the lengths returned when
	/// you are enumerating algorithms with the dwParam value of the CryptGetProvParam function set to PP_ENUMALGS. The length returned by
	/// this call is the actual size of the key, including the parity bits included in the key. Microsoft CSPs that support the
	/// CALG_CYLINK_MEK ALG_ID return 64 bits for that algorithm. CALG_CYLINK_MEK is a 40-bit key but has parity and zeroed key bits to make
	/// the key length 64 bits.
	/// </term>
	/// </item>
	/// <item>
	/// <term>KP_SALT</term>
	/// <term>
	/// Retrieve the salt value of the key. The pbData parameter is a pointer to a BYTE array that receives the salt value in little-endian
	/// form. The size of the salt value varies depending on the CSP and algorithm being used. Salt values do not apply to public/private key pairs.
	/// </term>
	/// </item>
	/// <item>
	/// <term>KP_PERMISSIONS</term>
	/// <term>
	/// Retrieve the key permissions. The pbData parameter is a pointer to a DWORD value that receives the permission flags for the key. The
	/// following permission identifiers are currently defined. The key permissions can be zero or a combination of one or more of the
	/// following values. CRYPT_ARCHIVE Allow export during the lifetime of the handle of the key. This permission can be set only if it is
	/// already set in the internal permissions field of the key. Attempts to clear this permission are ignored. CRYPT_DECRYPT Allow
	/// decryption. CRYPT_ENCRYPT Allow encryption. CRYPT_EXPORT Allow the key to be exported. CRYPT_EXPORT_KEY Allow the key to be used for
	/// exporting keys. CRYPT_IMPORT_KEY Allow the key to be used for importing keys. CRYPT_MAC Allow Message Authentication Codes (MACs) to
	/// be used with key. CRYPT_READ Allow values to be read. CRYPT_WRITE Allow values to be set.
	/// </term>
	/// </item>
	/// </list>
	/// <para>
	/// If a Digital Signature Standard (DSS) key is specified by the hKey parameter, the dwParam value can also be set to one of the
	/// following values.
	/// </para>
	/// <list type="table">
	/// <listheader>
	/// <term>Value</term>
	/// <term>Meaning</term>
	/// </listheader>
	/// <item>
	/// <term>KP_P</term>
	/// <term>
	/// Retrieve the modulus prime number P of the DSS key. The pbData parameter is a pointer to a buffer that receives the value in
	/// little-endian form. The pdwDataLen parameter contains the size of the buffer, in bytes.
	/// </term>
	/// </item>
	/// <item>
	/// <term>KP_Q</term>
	/// <term>
	/// Retrieve the modulus prime number Q of the DSS key. The pbData parameter is a pointer to a buffer that receives the value in
	/// little-endian form. The pdwDataLen parameter contains the size of the buffer, in bytes.
	/// </term>
	/// </item>
	/// <item>
	/// <term>KP_G</term>
	/// <term>
	/// Retrieve the generator G of the DSS key. The pbData parameter is a pointer to a buffer that receives the value in little-endian form.
	/// The pdwDataLen parameter contains the size of the buffer, in bytes.
	/// </term>
	/// </item>
	/// </list>
	/// <para>
	/// If a block cipher session key is specified by the hKey parameter, the dwParam value can also be set to one of the following values.
	/// </para>
	/// <list type="table">
	/// <listheader>
	/// <term>Value</term>
	/// <term>Meaning</term>
	/// </listheader>
	/// <item>
	/// <term>KP_EFFECTIVE_KEYLEN</term>
	/// <term>
	/// Retrieve the effective key length of an RC2 key. The pbData parameter is a pointer to a DWORD value that receives the effective key length.
	/// </term>
	/// </item>
	/// <item>
	/// <term>KP_IV</term>
	/// <term>
	/// Retrieve the initialization vector of the key. The pbData parameter is a pointer to a BYTE array that receives the initialization
	/// vector. The size of this array is the block size, in bytes. For example, if the block length is 64 bits, the initialization vector
	/// consists of 8 bytes.
	/// </term>
	/// </item>
	/// <item>
	/// <term>KP_PADDING</term>
	/// <term>
	/// Retrieve the padding mode. The pbData parameter is a pointer to a DWORD value that receives a numeric identifier that identifies the
	/// padding method used by the cipher. This can be one of the following values. PKCS5_PADDING Specifies the PKCS 5 (sec 6.2) padding
	/// method. RANDOM_PADDING The padding uses random numbers. This padding method is not supported by the Microsoft supplied CSPs.
	/// ZERO_PADDING The padding uses zeros. This padding method is not supported by the Microsoft supplied CSPs.
	/// </term>
	/// </item>
	/// <item>
	/// <term>KP_MODE</term>
	/// <term>
	/// Retrieve the cipher mode. The pbData parameter is a pointer to a DWORD value that receives a cipher mode identifier. For more
	/// information about cipher modes, see Data Encryption and Decryption. The following cipher mode identifiers are currently defined.
	/// CRYPT_MODE_CBC The cipher mode is cipher block chaining. CRYPT_MODE_CFB The cipher mode is cipher feedback (CFB). Microsoft CSPs
	/// currently support only 8-bit feedback in cipher feedback mode. CRYPT_MODE_ECB The cipher mode is electronic codebook. CRYPT_MODE_OFB
	/// The cipher mode is Output Feedback (OFB). Microsoft CSPs currently do not support Output Feedback Mode. CRYPT_MODE_CTS The cipher
	/// mode is ciphertext stealing mode.
	/// </term>
	/// </item>
	/// <item>
	/// <term>KP_MODE_BITS</term>
	/// <term>
	/// Retrieve the number of bits to feed back. The pbData parameter is a pointer to a DWORD value that receives the number of bits that
	/// are processed per cycle when the OFB or CFB cipher modes are used.
	/// </term>
	/// </item>
	/// </list>
	/// <para>
	/// If a Diffie-Hellman algorithm or Digital Signature Algorithm (DSA) key is specified by hKey, the dwParam value can also be set to the
	/// following value.
	/// </para>
	/// <list type="table">
	/// <listheader>
	/// <term>Value</term>
	/// <term>Meaning</term>
	/// </listheader>
	/// <item>
	/// <term>KP_VERIFY_PARAMS</term>
	/// <term>
	/// Verifies the parameters of a Diffie-Hellman algorithm or DSA key. The pbData parameter is not used, and the value pointed to by
	/// pdwDataLen receives zero. This function returns a nonzero value if the key parameters are valid or zero otherwise.
	/// </term>
	/// </item>
	/// <item>
	/// <term>KP_KEYVAL</term>
	/// <term>
	/// This value is not used. Windows Vista, Windows Server 2003 and Windows XP: Retrieve the secret agreement value from an imported
	/// Diffie-Hellman algorithm key of type CALG_AGREEDKEY_ANY. The pbData parameter is the address of a buffer that receives the secret
	/// agreement value, in little-endian format. This buffer must be the same length as the key. The dwFlags parameter must be set to
	/// 0xF42A19B6. This property can only be retrieved by a thread running under the local system account.This property is available for use
	/// in the operating systems listed above. It may be altered or unavailable in subsequent versions.
	/// </term>
	/// </item>
	/// </list>
	/// <para>If a certificate is specified by hKey, the dwParam value can also be set to the following value.</para>
	/// <list type="table">
	/// <listheader>
	/// <term>Value</term>
	/// <term>Meaning</term>
	/// </listheader>
	/// <item>
	/// <term>KP_CERTIFICATE</term>
	/// <term>
	/// A buffer that contains the DER-encoded X.509 certificate. The pbData parameter is not used, and the value pointed to by pdwDataLen
	/// receives zero. This function returns a nonzero value if the key parameters are valid or zero otherwise.
	/// </term>
	/// </item>
	/// </list>
	/// </param>
	/// <returns>The specified value data. The form of this data varies, depending on the value number.</returns>
	public static T? CryptGetKeyParam<T>(HCRYPTKEY hKey, KeyParam dwParam) => CryptGetValue<HCRYPTKEY, KeyParam, T>(CryptGetKeyParam, hKey, dwParam);

	/// <summary>The CryptGetProvParam function retrieves parameters that govern the operations of a cryptographic service provider (CSP).</summary>
	/// <param name="hProv">
	/// A handle of the CSP target of the query. This handle must have been created by using the CryptAcquireContext function.
	/// </param>
	/// <param name="dwParam">
	/// <para>The nature of the query. The following queries are defined.</para>
	/// <list type="table">
	/// <listheader>
	/// <term>Value</term>
	/// <term>Meaning</term>
	/// </listheader>
	/// <item>
	/// <term>PP_ADMIN_PIN 31 (0x1F)</term>
	/// <term>Returns the administrator personal identification number (PIN) in the pbData parameter as a LPSTR.</term>
	/// </item>
	/// <item>
	/// <term>PP_APPLI_CERT 18 (0x12)</term>
	/// <term>This constant is not used.</term>
	/// </item>
	/// <item>
	/// <term>PP_CHANGE_PASSWORD 7 (0x7)</term>
	/// <term>This constant is not used.</term>
	/// </item>
	/// <item>
	/// <term>PP_CERTCHAIN 9 (0x9)</term>
	/// <term>Returns the certificate chain associated with the hProv handle. The returned certificate chain is X509_ASN_ENCODING encoded.</term>
	/// </item>
	/// <item>
	/// <term>PP_CONTAINER 6 (0x6)</term>
	/// <term>
	/// The name of the current key container as a null-terminated CHAR string. This string is exactly the same as the one passed in the
	/// pszContainer parameter of the CryptAcquireContext function to specify the key container to use. The pszContainer parameter can be
	/// read to determine the name of the default key container.
	/// </term>
	/// </item>
	/// <item>
	/// <term>PP_CRYPT_COUNT_KEY_USE 41 (0x29)</term>
	/// <term>Not implemented by Microsoft CSPs. This behavior may be implemented by other CSPs. Windows XP: This parameter is not supported.</term>
	/// </item>
	/// <item>
	/// <term>PP_ENUMALGS 1 (0x1)</term>
	/// <term>
	/// A PROV_ENUMALGS structure that contains information about one algorithm supported by the CSP being queried. The first time this value
	/// is read, the dwFlags parameter must contain the CRYPT_FIRST flag. Doing so causes this function to retrieve the first element in the
	/// enumeration. The subsequent elements can then be retrieved by setting the CRYPT_NEXT flag in the dwFlags parameter. When this
	/// function fails with the ERROR_NO_MORE_ITEMS error code, the end of the enumeration has been reached. This function is not thread
	/// safe, and all of the available algorithms might not be enumerated if this function is used in a multithreaded context.
	/// </term>
	/// </item>
	/// <item>
	/// <term>PP_ENUMALGS_EX 22 (0x16)</term>
	/// <term>
	/// A PROV_ENUMALGS_EX structure that contains information about one algorithm supported by the CSP being queried. The structure returned
	/// contains more information about the algorithm than the structure returned for PP_ENUMALGS. The first time this value is read, the
	/// dwFlags parameter must contain the CRYPT_FIRST flag. Doing so causes this function to retrieve the first element in the enumeration.
	/// The subsequent elements can then be retrieved by setting the CRYPT_NEXT flag in the dwFlags parameter. When this function fails with
	/// the ERROR_NO_MORE_ITEMS error code, the end of the enumeration has been reached. This function is not thread safe and all of the
	/// available algorithms might not be enumerated if this function is used in a multithreaded context.
	/// </term>
	/// </item>
	/// <item>
	/// <term>PP_ENUMCONTAINERS 2 (0x2)</term>
	/// <term>
	/// The name of one of the key containers maintained by the CSP in the form of a null-terminated CHAR string. The first time this value
	/// is read, the dwFlags parameter must contain the CRYPT_FIRST flag. Doing so causes this function to retrieve the first element in the
	/// enumeration. The subsequent elements can then be retrieved by setting the CRYPT_NEXT flag in the dwFlags parameter. When this
	/// function fails with the ERROR_NO_MORE_ITEMS error code, the end of the enumeration has been reached. To enumerate key containers
	/// associated with a computer, first call CryptAcquireContext using the CRYPT_MACHINE_KEYSET flag, and then use the handle returned from
	/// CryptAcquireContext as the hProv parameter in the call to CryptGetProvParam. This function is not thread safe and all of the
	/// available algorithms might not be enumerated if this function is used in a multithreaded context.
	/// </term>
	/// </item>
	/// <item>
	/// <term>PP_ENUMELECTROOTS 26 (0x1A)</term>
	/// <term>This constant is not used.</term>
	/// </item>
	/// <item>
	/// <term>PP_ENUMEX_SIGNING_PROT 40 (0x28)</term>
	/// <term>
	/// Indicates that the current CSP supports the dwProtocols member of the PROV_ENUMALGS_EX structure. If this function succeeds, the CSP
	/// supports the dwProtocols member of the PROV_ENUMALGS_EX structure. If this function fails with an NTE_BAD_TYPE error code, the CSP
	/// does not support the dwProtocols member.
	/// </term>
	/// </item>
	/// <item>
	/// <term>PP_ENUMMANDROOTS 25 (0x19)</term>
	/// <term>This constant is not used.</term>
	/// </item>
	/// <item>
	/// <term>PP_IMPTYPE 3 (0x3)</term>
	/// <term>A DWORD value that indicates how the CSP is implemented. For a table of possible values, see Remarks.</term>
	/// </item>
	/// <item>
	/// <term>PP_KEY_TYPE_SUBTYPE 10 (0xA)</term>
	/// <term>This query is not used.</term>
	/// </item>
	/// <item>
	/// <term>PP_KEYEXCHANGE_PIN 32 (0x20)</term>
	/// <term>Specifies that the key exchange PIN is contained in pbData. The PIN is represented as a null-terminated ASCII string.</term>
	/// </item>
	/// <item>
	/// <term>PP_KEYSET_SEC_DESCR 8 (0x8)</term>
	/// <term>
	/// Retrieves the security descriptor for the key storage container. The pbData parameter is the address of a SECURITY_DESCRIPTOR
	/// structure that receives the security descriptor for the key storage container. The security descriptor is returned in self-relative format.
	/// </term>
	/// </item>
	/// <item>
	/// <term>PP_KEYSET_TYPE 27 (0x1B)</term>
	/// <term>
	/// Determines whether the hProv parameter is a computer key set. The pbData parameter must be a DWORD; the DWORD will be set to the
	/// CRYPT_MACHINE_KEYSET flag if that flag was passed to the CryptAcquireContext function.
	/// </term>
	/// </item>
	/// <item>
	/// <term>PP_KEYSPEC 39 (0x27)</term>
	/// <term>
	/// Returns information about the key specifier values that the CSP supports. Key specifier values are joined in a logical OR and
	/// returned in the pbData parameter of the call as a DWORD. For example, the Microsoft Base Cryptographic Provider version 1.0 returns a
	/// DWORD value of AT_SIGNATURE | AT_KEYEXCHANGE.
	/// </term>
	/// </item>
	/// <item>
	/// <term>PP_KEYSTORAGE 17 (0x11)</term>
	/// <term>Returns a DWORD value of CRYPT_SEC_DESCR.</term>
	/// </item>
	/// <item>
	/// <term>PP_KEYX_KEYSIZE_INC 35 (0x23)</term>
	/// <term>
	/// The number of bits for the increment length of AT_KEYEXCHANGE. This information is used with information returned in the
	/// PP_ENUMALGS_EX value. With the information returned when using PP_ENUMALGS_EX and PP_KEYX_KEYSIZE_INC, the valid key lengths for
	/// AT_KEYEXCHANGE can be determined. These key lengths can then be used with CryptGenKey. For example if a CSP enumerates CALG_RSA_KEYX
	/// (AT_KEYEXCHANGE) with a minimum key length of 512 bits and a maximum of 1024 bits, and returns the increment length as 64 bits, then
	/// valid key lengths are 512, 576, 640,… 1024.
	/// </term>
	/// </item>
	/// <item>
	/// <term>PP_NAME 4 (0x4)</term>
	/// <term>
	/// The name of the CSP in the form of a null-terminated CHAR string. This string is identical to the one passed in the pszProvider
	/// parameter of the CryptAcquireContext function to specify that the current CSP be used.
	/// </term>
	/// </item>
	/// <item>
	/// <term>PP_PROVTYPE 16 (0x10)</term>
	/// <term>A DWORD value that indicates the provider type of the CSP.</term>
	/// </item>
	/// <item>
	/// <term>PP_ROOT_CERTSTORE 46 (0x2E)</term>
	/// <term>
	/// Obtains the root certificate store for the smart card. This certificate store contains all of the root certificates that are stored
	/// on the smart card. The pbData parameter is the address of an HCERTSTORE variable that receives the handle of the certificate store.
	/// When this handle is no longer needed, the caller must close it by using the CertCloseStore function. Windows Server 2003 and Windows
	/// XP: This parameter is not supported.
	/// </term>
	/// </item>
	/// <item>
	/// <term>PP_SESSION_KEYSIZE 20 (0x14)</term>
	/// <term>The size, in bits, of the session key.</term>
	/// </item>
	/// <item>
	/// <term>PP_SGC_INFO 37 (0x25)</term>
	/// <term>Used with server gated cryptography.</term>
	/// </item>
	/// <item>
	/// <term>PP_SIG_KEYSIZE_INC 34 (0x22)</term>
	/// <term>
	/// The number of bits for the increment length of AT_SIGNATURE. This information is used with information returned in the PP_ENUMALGS_EX
	/// value. With the information returned when using PP_ENUMALGS_EX and PP_SIG_KEYSIZE_INC, the valid key lengths for AT_SIGNATURE can be
	/// determined. These key lengths can then be used with CryptGenKey. For example, if a CSP enumerates CALG_RSA_SIGN (AT_SIGNATURE) with a
	/// minimum key length of 512 bits and a maximum of 1024 bits, and returns the increment length as 64 bits, then valid key lengths are
	/// 512, 576, 640,… 1024.
	/// </term>
	/// </item>
	/// <item>
	/// <term>PP_SIGNATURE_PIN 33 (0x21)</term>
	/// <term>Specifies that the key signature PIN is contained in pbData. The PIN is represented as a null-terminated ASCII string.</term>
	/// </item>
	/// <item>
	/// <term>PP_SMARTCARD_GUID 45 (0x2D)</term>
	/// <term>
	/// Obtains the identifier of the smart card. The pbData parameter is the address of a GUID structure that receives the identifier of the
	/// smart card. Windows Server 2003 and Windows XP: This parameter is not supported.
	/// </term>
	/// </item>
	/// <item>
	/// <term>PP_SMARTCARD_READER 43 (0x2B)</term>
	/// <term>
	/// Obtains the name of the smart card reader. The pbData parameter is the address of an ANSI character array that receives a
	/// null-terminated ANSI string that contains the name of the smart card reader. The size of this buffer, contained in the variable
	/// pointed to by the pdwDataLen parameter, must include the NULL terminator. Windows Server 2003 and Windows XP: This parameter is not supported.
	/// </term>
	/// </item>
	/// <item>
	/// <term>PP_SYM_KEYSIZE 19 (0x13)</term>
	/// <term>The size of the symmetric key.</term>
	/// </item>
	/// <item>
	/// <term>PP_UI_PROMPT 21 (0x15)</term>
	/// <term>This query is not used.</term>
	/// </item>
	/// <item>
	/// <term>PP_UNIQUE_CONTAINER 36 (0x24)</term>
	/// <term>
	/// The unique container name of the current key container in the form of a null-terminated CHAR string. For many CSPs, this name is the
	/// same name returned when the PP_CONTAINER value is used. The CryptAcquireContext function must work with this container name.
	/// </term>
	/// </item>
	/// <item>
	/// <term>PP_USE_HARDWARE_RNG 38 (0x26)</term>
	/// <term>
	/// Indicates whether a hardware random number generator (RNG) is supported. When PP_USE_HARDWARE_RNG is specified, the function succeeds
	/// and returns TRUE if a hardware RNG is supported. The function fails and returns FALSE if a hardware RNG is not supported. If a RNG is
	/// supported, PP_USE_HARDWARE_RNG can be set in CryptSetProvParam to indicate that the CSP must exclusively use the hardware RNG for
	/// this provider context. When PP_USE_HARDWARE_RNG is used, the pbData parameter must be NULL and dwFlags must be zero. None of the
	/// Microsoft CSPs currently support using a hardware RNG.
	/// </term>
	/// </item>
	/// <item>
	/// <term>PP_USER_CERTSTORE 42 (0x2A)</term>
	/// <term>
	/// Obtains the user certificate store for the smart card. This certificate store contains all of the user certificates that are stored
	/// on the smart card. The certificates in this store are encoded by using PKCS_7_ASN_ENCODING or X509_ASN_ENCODING encoding and should
	/// contain the CERT_KEY_PROV_INFO_PROP_ID property. The pbData parameter is the address of an HCERTSTORE variable that receives the
	/// handle of an in-memory certificate store. When this handle is no longer needed, the caller must close it by using the CertCloseStore
	/// function. Windows Server 2003 and Windows XP: This parameter is not supported.
	/// </term>
	/// </item>
	/// <item>
	/// <term>PP_VERSION 5 (0x5)</term>
	/// <term>
	/// The version number of the CSP. The least significant byte contains the minor version number and the next most significant byte the
	/// major version number. Version 2.0 is represented as 0x00000200. To maintain backward compatibility with earlier versions of the
	/// Microsoft Base Cryptographic Provider and the Microsoft Enhanced Cryptographic Provider, the provider names retain the "v1.0"
	/// designation in later versions.
	/// </term>
	/// </item>
	/// </list>
	/// </param>
	/// <param name="pbData">
	/// <para>
	/// A pointer to a buffer to receive the data. The form of this data varies depending on the value of dwParam. When dwParam is set to
	/// PP_USE_HARDWARE_RNG, pbData must be set to <c>NULL</c>.
	/// </para>
	/// <para>
	/// This parameter can be <c>NULL</c> to set the size of this information for memory allocation purposes. For more information, see
	/// Retrieving Data of Unknown Length.
	/// </para>
	/// </param>
	/// <param name="pdwDataLen">
	/// <para>
	/// A pointer to a <c>DWORD</c> value that specifies the size, in bytes, of the buffer pointed to by the pbData parameter. When the
	/// function returns, the <c>DWORD</c> value contains the number of bytes stored or to be stored in the buffer.
	/// </para>
	/// <para>
	/// <c>Note</c> When processing the data returned in the buffer, applications must use the actual size of the data returned. The actual
	/// size can be slightly smaller than the size of the buffer specified on input. (On input, buffer sizes are usually specified large
	/// enough to ensure that the largest possible output data fits in the buffer.) On output, the variable pointed to by this parameter is
	/// updated to reflect the actual size of the data copied to the buffer. If PP_ENUMALGS, or PP_ENUMALGS_EX is set, the pdwDataLen
	/// parameter works somewhat differently. If pbData is <c>NULL</c> or the value pointed to by pdwDataLen is too small, the value returned
	/// in this parameter is the size of the largest item in the enumeration list instead of the size of the item currently being read. If
	/// PP_ENUMCONTAINERS is set, the first call to the function returns the size of the maximum key-container allowed by the current
	/// provider. This is in contrast to other possible behaviors, like returning the length of the longest existing container, or the length
	/// of the current container. Subsequent enumerating calls will not change the dwLen parameter. For each enumerated container, the caller
	/// can determine the length of the <c>null</c>-terminated string programmatically, if desired. If one of the enumeration values is read
	/// and the pbData parameter is <c>NULL</c>, the CRYPT_FIRST flag must be specified for the size information to be correctly retrieved.
	/// </para>
	/// </param>
	/// <param name="dwFlags">
	/// <para>
	/// If dwParam is <c>PP_KEYSET_SEC_DESCR</c>, the security descriptor on the key container where the keys are stored is retrieved. For
	/// this case, dwFlags is used to pass in the <c>SECURITY_INFORMATION</c> bit flags that indicate the requested security information, as
	/// defined in the Platform SDK. <c>SECURITY_INFORMATION</c> bit flags can be combined with a bitwise- <c>OR</c> operation.
	/// </para>
	/// <para>The following values are defined for use with <c>PP_KEYSET_SEC_DESCR</c>.</para>
	/// <list type="table">
	/// <listheader>
	/// <term>Value</term>
	/// <term>Meaning</term>
	/// </listheader>
	/// <item>
	/// <term>OWNER_SECURITY_INFORMATION</term>
	/// <term>Owner identifier of the object is being referenced.</term>
	/// </item>
	/// <item>
	/// <term>GROUP_SECURITY_INFORMATION</term>
	/// <term>Primary group identifier of the object is being referenced.</term>
	/// </item>
	/// <item>
	/// <term>DACL_SECURITY_INFORMATION</term>
	/// <term>Discretionary ACL of the object is being referenced.</term>
	/// </item>
	/// <item>
	/// <term>SACL_SECURITY_INFORMATION</term>
	/// <term>System ACL of the object is being referenced.</term>
	/// </item>
	/// </list>
	/// <para>The following values are defined for use with <c>PP_ENUMALGS</c>, <c>PP_ENUMALGS_EX</c>, and <c>PP_ENUMCONTAINERS</c>.</para>
	/// <list type="table">
	/// <listheader>
	/// <term>Value</term>
	/// <term>Meaning</term>
	/// </listheader>
	/// <item>
	/// <term>CRYPT_FIRST 1 (0x1)</term>
	/// <term>Retrieve the first element in the enumeration. This has the same effect as resetting the enumerator.</term>
	/// </item>
	/// <item>
	/// <term>CRYPT_NEXT 2 (0x2)</term>
	/// <term>
	/// Retrieve the next element in the enumeration. When there are no more elements to retrieve, this function will fail and set the last
	/// error to ERROR_NO_MORE_ITEMS.
	/// </term>
	/// </item>
	/// <item>
	/// <term>CRYPT_SGC_ENUM 4 (0x4)</term>
	/// <term>
	/// Retrieve server-gated cryptography (SGC) enabled certificates. SGC enabled certificates are no longer supported. For more
	/// information, see Microsoft Support Article 875450.
	/// </term>
	/// </item>
	/// <item>
	/// <term>CRYPT_SGC</term>
	/// <term>This flag is not used.</term>
	/// </item>
	/// <item>
	/// <term>CRYPT_FASTSGC</term>
	/// <term>This flag is not used.</term>
	/// </item>
	/// </list>
	/// </param>
	/// <returns>
	/// <para>If the function succeeds, the return value is nonzero ( <c>TRUE</c>).</para>
	/// <para>If the function fails, the return value is zero ( <c>FALSE</c>). For extended error information, call GetLastError.</para>
	/// <para>The error codes prefaced by NTE are generated by the particular CSP being used. Some possible error codes follow.</para>
	/// <list type="table">
	/// <listheader>
	/// <term>Return code</term>
	/// <term>Description</term>
	/// </listheader>
	/// <item>
	/// <term>ERROR_INVALID_HANDLE</term>
	/// <term>One of the parameters specifies a handle that is not valid.</term>
	/// </item>
	/// <item>
	/// <term>ERROR_INVALID_PARAMETER</term>
	/// <term>One of the parameters contains a value that is not valid. This is most often a pointer that is not valid.</term>
	/// </item>
	/// <item>
	/// <term>ERROR_MORE_DATA</term>
	/// <term>
	/// If the buffer specified by the pbData parameter is not large enough to hold the returned data, the function sets the ERROR_MORE_DATA
	/// code and stores the required buffer size, in bytes, in the variable pointed to by pdwDataLen.
	/// </term>
	/// </item>
	/// <item>
	/// <term>ERROR_NO_MORE_ITEMS</term>
	/// <term>
	/// The end of the enumeration list has been reached. No valid data has been placed in the pbData buffer. This error code is returned
	/// only when dwParam equals PP_ENUMALGS or PP_ENUMCONTAINERS.
	/// </term>
	/// </item>
	/// <item>
	/// <term>NTE_BAD_FLAGS</term>
	/// <term>The dwFlags parameter specifies a flag that is not valid.</term>
	/// </item>
	/// <item>
	/// <term>NTE_BAD_TYPE</term>
	/// <term>The dwParam parameter specifies an unknown value number.</term>
	/// </item>
	/// <item>
	/// <term>NTE_BAD_UID</term>
	/// <term>The CSP context specified by hProv is not valid.</term>
	/// </item>
	/// </list>
	/// </returns>
	/// <remarks>
	/// <para>This function must not be used on a thread of a multithreaded program.</para>
	/// <para>The following values are returned in pbData if dwParam is PP_IMPTYPE.</para>
	/// <list type="table">
	/// <listheader>
	/// <term>Value</term>
	/// <term>Meaning</term>
	/// </listheader>
	/// <item>
	/// <term>CRYPT_IMPL_HARDWARE1</term>
	/// <term>Implementation is in hardware.</term>
	/// </item>
	/// <item>
	/// <term>CRYPT_IMPL_SOFTWARE2</term>
	/// <term>Implementation is in software.</term>
	/// </item>
	/// <item>
	/// <term>CRYPT_IMPL_MIXED3</term>
	/// <term>Implementation involves both hardware and software.</term>
	/// </item>
	/// <item>
	/// <term>CRYPT_IMPL_UNKNOWN4</term>
	/// <term>Implementation type is unknown.</term>
	/// </item>
	/// <item>
	/// <term>CRYPT_IMPL_REMOVABLE8</term>
	/// <term>Implementation is in removable media.</term>
	/// </item>
	/// </list>
	/// <para>
	/// The dwFlags parameter is used to pass in the <c>SECURITY_INFORMATION</c> bit flags that indicate the requested security information.
	/// The pointer to the security descriptor is returned in the pbData parameter and the length of the security descriptor is returned in
	/// the pdwDataLen parameter. Key-container security is handled with SetFileSecurity and GetFileSecurity.
	/// </para>
	/// <para>
	/// The class of an algorithm enumerated with dwParam set to PP_ENUMALGS or PP_ENUMALGS_EX can be determined. This might be done to
	/// display a list of encryption algorithms supported and to disregard the rest. The <c>GET_ALG_CLASS(</c> x <c>)</c> macro takes an
	/// algorithm identifier as an argument and returns a code indicating the general class of that algorithm. Possible return values include:
	/// </para>
	/// <list type="bullet">
	/// <item>
	/// <term>ALG_CLASS_DATA_ENCRYPT</term>
	/// </item>
	/// <item>
	/// <term>ALG_CLASS_HASH</term>
	/// </item>
	/// <item>
	/// <term>ALG_CLASS_KEY_EXCHANGE</term>
	/// </item>
	/// <item>
	/// <term>ALG_CLASS_SIGNATURE</term>
	/// </item>
	/// </list>
	/// <para>
	/// The following table lists the algorithms supported by the Microsoft Base Cryptographic Provider along with the class of each algorithm.
	/// </para>
	/// <list type="table">
	/// <listheader>
	/// <term>Name</term>
	/// <term>Identifier</term>
	/// <term>Class</term>
	/// </listheader>
	/// <item>
	/// <term>"MD2"</term>
	/// <term>CALG_MD2</term>
	/// <term>ALG_CLASS_HASH</term>
	/// </item>
	/// <item>
	/// <term>"MD5"</term>
	/// <term>CALG_MD5</term>
	/// <term>ALG_CLASS_HASH</term>
	/// </item>
	/// <item>
	/// <term>"SHA"</term>
	/// <term>CALG_SHA</term>
	/// <term>ALG_CLASS_HASH</term>
	/// </item>
	/// <item>
	/// <term>"MAC"</term>
	/// <term>CALG_MAC</term>
	/// <term>ALG_CLASS_HASH</term>
	/// </item>
	/// <item>
	/// <term>"RSA_SIGN"</term>
	/// <term>CALG_RSA_SIGN</term>
	/// <term>ALG_CLASS_SIGNATURE</term>
	/// </item>
	/// <item>
	/// <term>"RSA_KEYX"</term>
	/// <term>CALG_RSA_KEYX</term>
	/// <term>ALG_CLASS_KEY_EXCHANGE</term>
	/// </item>
	/// <item>
	/// <term>"RC2"</term>
	/// <term>CALG_RC2</term>
	/// <term>ALG_CLASS_DATA_ENCRYPT</term>
	/// </item>
	/// <item>
	/// <term>"RC4"</term>
	/// <term>CALG_RC4</term>
	/// <term>ALG_CLASS_DATA_ENCRYPT</term>
	/// </item>
	/// </list>
	/// <para>
	/// Applications must not use an algorithm with an algorithm identifier that is not recognized. Using an unknown cryptographic algorithm
	/// can produce unpredictable results.
	/// </para>
	/// <para>Examples</para>
	/// <para>
	/// The following example shows finding the name of the CSP associated with a cryptographic service provider handle and the name of the
	/// key container associated with the handle. For the complete context for this example, see Example C Program: Using CryptAcquireContext.
	/// </para>
	/// <para>For another example that uses this function, see Example C Program: Enumerating CSP Providers and Provider Types.</para>
	/// </remarks>
	// https://docs.microsoft.com/en-us/windows/win32/api/wincrypt/nf-wincrypt-cryptgetprovparam BOOL CryptGetProvParam( HCRYPTPROV hProv,
	// DWORD dwParam, BYTE *pbData, DWORD *pdwDataLen, DWORD dwFlags );
	[DllImport(Lib.AdvApi32, SetLastError = true, ExactSpelling = true)]
	[PInvokeData("wincrypt.h", MSDNShortId = "c0b7c1c8-aa42-4d40-a7f7-99c0821c8977")]
	[return: MarshalAs(UnmanagedType.Bool)]
	public static extern bool CryptGetProvParam(HCRYPTPROV hProv, ProvParam dwParam, [Out, Optional] IntPtr pbData, ref uint pdwDataLen, uint dwFlags);

	/// <summary>The CryptGetProvParam function retrieves parameters that govern the operations of a cryptographic service provider (CSP).</summary>
	/// <typeparam name="T">The expected return type.</typeparam>
	/// <param name="hProv">
	/// A handle of the CSP target of the query. This handle must have been created by using the CryptAcquireContext function.
	/// </param>
	/// <param name="dwParam">
	/// <para>The nature of the query. The following queries are defined.</para>
	/// <list type="table">
	/// <listheader>
	/// <term>Value</term>
	/// <term>Meaning</term>
	/// </listheader>
	/// <item>
	/// <term>PP_ADMIN_PIN 31 (0x1F)</term>
	/// <term>Returns the administrator personal identification number (PIN) in the pbData parameter as a LPSTR.</term>
	/// </item>
	/// <item>
	/// <term>PP_APPLI_CERT 18 (0x12)</term>
	/// <term>This constant is not used.</term>
	/// </item>
	/// <item>
	/// <term>PP_CHANGE_PASSWORD 7 (0x7)</term>
	/// <term>This constant is not used.</term>
	/// </item>
	/// <item>
	/// <term>PP_CERTCHAIN 9 (0x9)</term>
	/// <term>Returns the certificate chain associated with the hProv handle. The returned certificate chain is X509_ASN_ENCODING encoded.</term>
	/// </item>
	/// <item>
	/// <term>PP_CONTAINER 6 (0x6)</term>
	/// <term>
	/// The name of the current key container as a null-terminated CHAR string. This string is exactly the same as the one passed in the
	/// pszContainer parameter of the CryptAcquireContext function to specify the key container to use. The pszContainer parameter can be
	/// read to determine the name of the default key container.
	/// </term>
	/// </item>
	/// <item>
	/// <term>PP_CRYPT_COUNT_KEY_USE 41 (0x29)</term>
	/// <term>Not implemented by Microsoft CSPs. This behavior may be implemented by other CSPs. Windows XP: This parameter is not supported.</term>
	/// </item>
	/// <item>
	/// <term>PP_ENUMALGS 1 (0x1)</term>
	/// <term>
	/// A PROV_ENUMALGS structure that contains information about one algorithm supported by the CSP being queried. The first time this value
	/// is read, the dwFlags parameter must contain the CRYPT_FIRST flag. Doing so causes this function to retrieve the first element in the
	/// enumeration. The subsequent elements can then be retrieved by setting the CRYPT_NEXT flag in the dwFlags parameter. When this
	/// function fails with the ERROR_NO_MORE_ITEMS error code, the end of the enumeration has been reached. This function is not thread
	/// safe, and all of the available algorithms might not be enumerated if this function is used in a multithreaded context.
	/// </term>
	/// </item>
	/// <item>
	/// <term>PP_ENUMALGS_EX 22 (0x16)</term>
	/// <term>
	/// A PROV_ENUMALGS_EX structure that contains information about one algorithm supported by the CSP being queried. The structure returned
	/// contains more information about the algorithm than the structure returned for PP_ENUMALGS. The first time this value is read, the
	/// dwFlags parameter must contain the CRYPT_FIRST flag. Doing so causes this function to retrieve the first element in the enumeration.
	/// The subsequent elements can then be retrieved by setting the CRYPT_NEXT flag in the dwFlags parameter. When this function fails with
	/// the ERROR_NO_MORE_ITEMS error code, the end of the enumeration has been reached. This function is not thread safe and all of the
	/// available algorithms might not be enumerated if this function is used in a multithreaded context.
	/// </term>
	/// </item>
	/// <item>
	/// <term>PP_ENUMCONTAINERS 2 (0x2)</term>
	/// <term>
	/// The name of one of the key containers maintained by the CSP in the form of a null-terminated CHAR string. The first time this value
	/// is read, the dwFlags parameter must contain the CRYPT_FIRST flag. Doing so causes this function to retrieve the first element in the
	/// enumeration. The subsequent elements can then be retrieved by setting the CRYPT_NEXT flag in the dwFlags parameter. When this
	/// function fails with the ERROR_NO_MORE_ITEMS error code, the end of the enumeration has been reached. To enumerate key containers
	/// associated with a computer, first call CryptAcquireContext using the CRYPT_MACHINE_KEYSET flag, and then use the handle returned from
	/// CryptAcquireContext as the hProv parameter in the call to CryptGetProvParam. This function is not thread safe and all of the
	/// available algorithms might not be enumerated if this function is used in a multithreaded context.
	/// </term>
	/// </item>
	/// <item>
	/// <term>PP_ENUMELECTROOTS 26 (0x1A)</term>
	/// <term>This constant is not used.</term>
	/// </item>
	/// <item>
	/// <term>PP_ENUMEX_SIGNING_PROT 40 (0x28)</term>
	/// <term>
	/// Indicates that the current CSP supports the dwProtocols member of the PROV_ENUMALGS_EX structure. If this function succeeds, the CSP
	/// supports the dwProtocols member of the PROV_ENUMALGS_EX structure. If this function fails with an NTE_BAD_TYPE error code, the CSP
	/// does not support the dwProtocols member.
	/// </term>
	/// </item>
	/// <item>
	/// <term>PP_ENUMMANDROOTS 25 (0x19)</term>
	/// <term>This constant is not used.</term>
	/// </item>
	/// <item>
	/// <term>PP_IMPTYPE 3 (0x3)</term>
	/// <term>A DWORD value that indicates how the CSP is implemented. For a table of possible values, see Remarks.</term>
	/// </item>
	/// <item>
	/// <term>PP_KEY_TYPE_SUBTYPE 10 (0xA)</term>
	/// <term>This query is not used.</term>
	/// </item>
	/// <item>
	/// <term>PP_KEYEXCHANGE_PIN 32 (0x20)</term>
	/// <term>Specifies that the key exchange PIN is contained in pbData. The PIN is represented as a null-terminated ASCII string.</term>
	/// </item>
	/// <item>
	/// <term>PP_KEYSET_SEC_DESCR 8 (0x8)</term>
	/// <term>
	/// Retrieves the security descriptor for the key storage container. The pbData parameter is the address of a SECURITY_DESCRIPTOR
	/// structure that receives the security descriptor for the key storage container. The security descriptor is returned in self-relative format.
	/// </term>
	/// </item>
	/// <item>
	/// <term>PP_KEYSET_TYPE 27 (0x1B)</term>
	/// <term>
	/// Determines whether the hProv parameter is a computer key set. The pbData parameter must be a DWORD; the DWORD will be set to the
	/// CRYPT_MACHINE_KEYSET flag if that flag was passed to the CryptAcquireContext function.
	/// </term>
	/// </item>
	/// <item>
	/// <term>PP_KEYSPEC 39 (0x27)</term>
	/// <term>
	/// Returns information about the key specifier values that the CSP supports. Key specifier values are joined in a logical OR and
	/// returned in the pbData parameter of the call as a DWORD. For example, the Microsoft Base Cryptographic Provider version 1.0 returns a
	/// DWORD value of AT_SIGNATURE | AT_KEYEXCHANGE.
	/// </term>
	/// </item>
	/// <item>
	/// <term>PP_KEYSTORAGE 17 (0x11)</term>
	/// <term>Returns a DWORD value of CRYPT_SEC_DESCR.</term>
	/// </item>
	/// <item>
	/// <term>PP_KEYX_KEYSIZE_INC 35 (0x23)</term>
	/// <term>
	/// The number of bits for the increment length of AT_KEYEXCHANGE. This information is used with information returned in the
	/// PP_ENUMALGS_EX value. With the information returned when using PP_ENUMALGS_EX and PP_KEYX_KEYSIZE_INC, the valid key lengths for
	/// AT_KEYEXCHANGE can be determined. These key lengths can then be used with CryptGenKey. For example if a CSP enumerates CALG_RSA_KEYX
	/// (AT_KEYEXCHANGE) with a minimum key length of 512 bits and a maximum of 1024 bits, and returns the increment length as 64 bits, then
	/// valid key lengths are 512, 576, 640,… 1024.
	/// </term>
	/// </item>
	/// <item>
	/// <term>PP_NAME 4 (0x4)</term>
	/// <term>
	/// The name of the CSP in the form of a null-terminated CHAR string. This string is identical to the one passed in the pszProvider
	/// parameter of the CryptAcquireContext function to specify that the current CSP be used.
	/// </term>
	/// </item>
	/// <item>
	/// <term>PP_PROVTYPE 16 (0x10)</term>
	/// <term>A DWORD value that indicates the provider type of the CSP.</term>
	/// </item>
	/// <item>
	/// <term>PP_ROOT_CERTSTORE 46 (0x2E)</term>
	/// <term>
	/// Obtains the root certificate store for the smart card. This certificate store contains all of the root certificates that are stored
	/// on the smart card. The pbData parameter is the address of an HCERTSTORE variable that receives the handle of the certificate store.
	/// When this handle is no longer needed, the caller must close it by using the CertCloseStore function. Windows Server 2003 and Windows
	/// XP: This parameter is not supported.
	/// </term>
	/// </item>
	/// <item>
	/// <term>PP_SESSION_KEYSIZE 20 (0x14)</term>
	/// <term>The size, in bits, of the session key.</term>
	/// </item>
	/// <item>
	/// <term>PP_SGC_INFO 37 (0x25)</term>
	/// <term>Used with server gated cryptography.</term>
	/// </item>
	/// <item>
	/// <term>PP_SIG_KEYSIZE_INC 34 (0x22)</term>
	/// <term>
	/// The number of bits for the increment length of AT_SIGNATURE. This information is used with information returned in the PP_ENUMALGS_EX
	/// value. With the information returned when using PP_ENUMALGS_EX and PP_SIG_KEYSIZE_INC, the valid key lengths for AT_SIGNATURE can be
	/// determined. These key lengths can then be used with CryptGenKey. For example, if a CSP enumerates CALG_RSA_SIGN (AT_SIGNATURE) with a
	/// minimum key length of 512 bits and a maximum of 1024 bits, and returns the increment length as 64 bits, then valid key lengths are
	/// 512, 576, 640,… 1024.
	/// </term>
	/// </item>
	/// <item>
	/// <term>PP_SIGNATURE_PIN 33 (0x21)</term>
	/// <term>Specifies that the key signature PIN is contained in pbData. The PIN is represented as a null-terminated ASCII string.</term>
	/// </item>
	/// <item>
	/// <term>PP_SMARTCARD_GUID 45 (0x2D)</term>
	/// <term>
	/// Obtains the identifier of the smart card. The pbData parameter is the address of a GUID structure that receives the identifier of the
	/// smart card. Windows Server 2003 and Windows XP: This parameter is not supported.
	/// </term>
	/// </item>
	/// <item>
	/// <term>PP_SMARTCARD_READER 43 (0x2B)</term>
	/// <term>
	/// Obtains the name of the smart card reader. The pbData parameter is the address of an ANSI character array that receives a
	/// null-terminated ANSI string that contains the name of the smart card reader. The size of this buffer, contained in the variable
	/// pointed to by the pdwDataLen parameter, must include the NULL terminator. Windows Server 2003 and Windows XP: This parameter is not supported.
	/// </term>
	/// </item>
	/// <item>
	/// <term>PP_SYM_KEYSIZE 19 (0x13)</term>
	/// <term>The size of the symmetric key.</term>
	/// </item>
	/// <item>
	/// <term>PP_UI_PROMPT 21 (0x15)</term>
	/// <term>This query is not used.</term>
	/// </item>
	/// <item>
	/// <term>PP_UNIQUE_CONTAINER 36 (0x24)</term>
	/// <term>
	/// The unique container name of the current key container in the form of a null-terminated CHAR string. For many CSPs, this name is the
	/// same name returned when the PP_CONTAINER value is used. The CryptAcquireContext function must work with this container name.
	/// </term>
	/// </item>
	/// <item>
	/// <term>PP_USE_HARDWARE_RNG 38 (0x26)</term>
	/// <term>
	/// Indicates whether a hardware random number generator (RNG) is supported. When PP_USE_HARDWARE_RNG is specified, the function succeeds
	/// and returns TRUE if a hardware RNG is supported. The function fails and returns FALSE if a hardware RNG is not supported. If a RNG is
	/// supported, PP_USE_HARDWARE_RNG can be set in CryptSetProvParam to indicate that the CSP must exclusively use the hardware RNG for
	/// this provider context. When PP_USE_HARDWARE_RNG is used, the pbData parameter must be NULL and dwFlags must be zero. None of the
	/// Microsoft CSPs currently support using a hardware RNG.
	/// </term>
	/// </item>
	/// <item>
	/// <term>PP_USER_CERTSTORE 42 (0x2A)</term>
	/// <term>
	/// Obtains the user certificate store for the smart card. This certificate store contains all of the user certificates that are stored
	/// on the smart card. The certificates in this store are encoded by using PKCS_7_ASN_ENCODING or X509_ASN_ENCODING encoding and should
	/// contain the CERT_KEY_PROV_INFO_PROP_ID property. The pbData parameter is the address of an HCERTSTORE variable that receives the
	/// handle of an in-memory certificate store. When this handle is no longer needed, the caller must close it by using the CertCloseStore
	/// function. Windows Server 2003 and Windows XP: This parameter is not supported.
	/// </term>
	/// </item>
	/// <item>
	/// <term>PP_VERSION 5 (0x5)</term>
	/// <term>
	/// The version number of the CSP. The least significant byte contains the minor version number and the next most significant byte the
	/// major version number. Version 2.0 is represented as 0x00000200. To maintain backward compatibility with earlier versions of the
	/// Microsoft Base Cryptographic Provider and the Microsoft Enhanced Cryptographic Provider, the provider names retain the "v1.0"
	/// designation in later versions.
	/// </term>
	/// </item>
	/// </list>
	/// </param>
	/// <param name="dwFlags">
	/// <para>
	/// If dwParam is <c>PP_KEYSET_SEC_DESCR</c>, the security descriptor on the key container where the keys are stored is retrieved. For
	/// this case, dwFlags is used to pass in the <c>SECURITY_INFORMATION</c> bit flags that indicate the requested security information, as
	/// defined in the Platform SDK. <c>SECURITY_INFORMATION</c> bit flags can be combined with a bitwise- <c>OR</c> operation.
	/// </para>
	/// <para>The following values are defined for use with <c>PP_KEYSET_SEC_DESCR</c>.</para>
	/// <list type="table">
	/// <listheader>
	/// <term>Value</term>
	/// <term>Meaning</term>
	/// </listheader>
	/// <item>
	/// <term>OWNER_SECURITY_INFORMATION</term>
	/// <term>Owner identifier of the object is being referenced.</term>
	/// </item>
	/// <item>
	/// <term>GROUP_SECURITY_INFORMATION</term>
	/// <term>Primary group identifier of the object is being referenced.</term>
	/// </item>
	/// <item>
	/// <term>DACL_SECURITY_INFORMATION</term>
	/// <term>Discretionary ACL of the object is being referenced.</term>
	/// </item>
	/// <item>
	/// <term>SACL_SECURITY_INFORMATION</term>
	/// <term>System ACL of the object is being referenced.</term>
	/// </item>
	/// </list>
	/// <para>The following values are defined for use with <c>PP_ENUMALGS</c>, <c>PP_ENUMALGS_EX</c>, and <c>PP_ENUMCONTAINERS</c>.</para>
	/// <list type="table">
	/// <listheader>
	/// <term>Value</term>
	/// <term>Meaning</term>
	/// </listheader>
	/// <item>
	/// <term>CRYPT_FIRST 1 (0x1)</term>
	/// <term>Retrieve the first element in the enumeration. This has the same effect as resetting the enumerator.</term>
	/// </item>
	/// <item>
	/// <term>CRYPT_NEXT 2 (0x2)</term>
	/// <term>
	/// Retrieve the next element in the enumeration. When there are no more elements to retrieve, this function will fail and set the last
	/// error to ERROR_NO_MORE_ITEMS.
	/// </term>
	/// </item>
	/// <item>
	/// <term>CRYPT_SGC_ENUM 4 (0x4)</term>
	/// <term>
	/// Retrieve server-gated cryptography (SGC) enabled certificates. SGC enabled certificates are no longer supported. For more
	/// information, see Microsoft Support Article 875450.
	/// </term>
	/// </item>
	/// <item>
	/// <term>CRYPT_SGC</term>
	/// <term>This flag is not used.</term>
	/// </item>
	/// <item>
	/// <term>CRYPT_FASTSGC</term>
	/// <term>This flag is not used.</term>
	/// </item>
	/// </list>
	/// </param>
	/// <returns>The specified value data. The form of this data varies, depending on the value number.</returns>
	public static T? CryptGetProvParam<T>(HCRYPTPROV hProv, ProvParam dwParam, uint dwFlags) => CryptGetValue<HCRYPTPROV, ProvParam, T>(CryptGetProvParam, hProv, dwParam, dwFlags);

	/// <summary>
	/// The CryptGetUserKey function retrieves a handle of one of a user's two public/private key pairs. This function is used only by the
	/// owner of the public/private key pairs and only when the handle of a cryptographic service provider (CSP) and its associated key
	/// container is available. If the CSP handle is not available and the user's certificate is, use CryptAcquireCertificatePrivateKey.
	/// </summary>
	/// <param name="hProv"><c>HCRYPTPROV</c> handle of a cryptographic service provider (CSP) created by a call to CryptAcquireContext.</param>
	/// <param name="dwKeySpec">
	/// <para>Identifies the private key to use from the key container. It can be AT_KEYEXCHANGE or AT_SIGNATURE.</para>
	/// <para>
	/// Additionally, some providers allow access to other user-specific keys through this function. For details, see the documentation on
	/// the specific provider.
	/// </para>
	/// </param>
	/// <param name="phUserKey">
	/// A pointer to the HCRYPTKEY handle of the retrieved keys. When you have finished using the key, delete the handle by calling the
	/// CryptDestroyKey function.
	/// </param>
	/// <returns>
	/// <para>If the function succeeds, the return value is nonzero (TRUE).</para>
	/// <para>If the function fails, the return value is zero (FALSE). For extended error information, call GetLastError.</para>
	/// <para>The error codes prefaced by "NTE" are generated by the particular CSP being used. Some possible error codes follow.</para>
	/// <list type="table">
	/// <listheader>
	/// <term>Return code</term>
	/// <term>Description</term>
	/// </listheader>
	/// <item>
	/// <term>ERROR_INVALID_HANDLE</term>
	/// <term>One of the parameters specifies a handle that is not valid.</term>
	/// </item>
	/// <item>
	/// <term>ERROR_INVALID_PARAMETER</term>
	/// <term>One of the parameters contains a value that is not valid. This is most often a pointer that is not valid.</term>
	/// </item>
	/// <item>
	/// <term>NTE_BAD_KEY</term>
	/// <term>The dwKeySpec parameter contains a value that is not valid.</term>
	/// </item>
	/// <item>
	/// <term>NTE_BAD_UID</term>
	/// <term>The hProv parameter does not contain a valid context handle.</term>
	/// </item>
	/// <item>
	/// <term>NTE_NO_KEY</term>
	/// <term>The key requested by the dwKeySpec parameter does not exist.</term>
	/// </item>
	/// </list>
	/// </returns>
	// https://docs.microsoft.com/en-us/windows/win32/api/wincrypt/nf-wincrypt-cryptgetuserkey BOOL CryptGetUserKey( HCRYPTPROV hProv, DWORD
	// dwKeySpec, HCRYPTKEY *phUserKey );
	[DllImport(Lib.AdvApi32, SetLastError = true, ExactSpelling = true)]
	[PInvokeData("wincrypt.h", MSDNShortId = "d9166b98-e5f1-4e5c-b6f1-2a086b102e0f")]
	[return: MarshalAs(UnmanagedType.Bool)]
	public static extern bool CryptGetUserKey(HCRYPTPROV hProv, CertKeySpec dwKeySpec, out SafeHCRYPTKEY phUserKey);

	/// <summary>
	/// The CryptHashData function adds data to a specified hash object. This function and CryptHashSessionKey can be called multiple times
	/// to compute the hash of long or discontinuous data streams.
	/// <para>Before calling this function, CryptCreateHash must be called to create a handle of a hash object.</para>
	/// </summary>
	/// <param name="hHash">Handle of the hash object.</param>
	/// <param name="pbData">A pointer to a buffer that contains the data to be added to the hash object.</param>
	/// <param name="dwDataLen">Number of bytes of data to be added. This must be zero if the CRYPT_USERDATA flag is set.</param>
	/// <param name="dwFlags">
	/// <para>The following flag values are defined.</para>
	/// <list type="table">
	/// <listheader>
	/// <term>Value</term>
	/// <term>Meaning</term>
	/// </listheader>
	/// <item>
	/// <term>CRYPT_OWF_REPL_LM_HASH 0x00000001</term>
	/// <term>This flag is not used.</term>
	/// </item>
	/// <item>
	/// <term>CRYPT_USERDATA 1 (0x1)</term>
	/// <term>
	/// All Microsoft Cryptographic Providers ignore this parameter. For any CSP that does not ignore this parameter, if this flag is set,
	/// the CSP prompts the user to input data directly. This data is added to the hash. The application is not allowed access to the data.
	/// This flag can be used to allow the user to enter a PIN into the system.
	/// </term>
	/// </item>
	/// </list>
	/// </param>
	/// <returns>
	/// <para>If the function succeeds, the return value is <c>TRUE</c>.</para>
	/// <para>If the function fails, the return value is <c>FALSE</c>. For extended error information, call GetLastError.</para>
	/// <para>The error codes prefaced by "NTE" are generated by the particular CSP you are using. Some possible error codes follow.</para>
	/// <list type="table">
	/// <listheader>
	/// <term>Return code</term>
	/// <term>Description</term>
	/// </listheader>
	/// <item>
	/// <term>ERROR_INVALID_HANDLE</term>
	/// <term>One of the parameters specifies a handle that is not valid.</term>
	/// </item>
	/// <item>
	/// <term>ERROR_INVALID_PARAMETER</term>
	/// <term>One of the parameters contains a value that is not valid. This is most often a pointer that is not valid.</term>
	/// </item>
	/// <item>
	/// <term>NTE_BAD_ALGID</term>
	/// <term>The hHash handle specifies an algorithm that this CSP does not support.</term>
	/// </item>
	/// <item>
	/// <term>NTE_BAD_FLAGS</term>
	/// <term>The dwFlags parameter contains a value that is not valid.</term>
	/// </item>
	/// <item>
	/// <term>NTE_BAD_HASH</term>
	/// <term>The hash object specified by the hHash parameter is not valid.</term>
	/// </item>
	/// <item>
	/// <term>NTE_BAD_HASH_STATE</term>
	/// <term>An attempt was made to add data to a hash object that is already marked "finished."</term>
	/// </item>
	/// <item>
	/// <term>NTE_BAD_KEY</term>
	/// <term>
	/// A keyed hash algorithm is being used, but the session key is no longer valid. This error is generated if the session key is destroyed
	/// before the hashing operation is complete.
	/// </term>
	/// </item>
	/// <item>
	/// <term>NTE_BAD_LEN</term>
	/// <term>The CSP does not ignore the CRYPT_USERDATA flag, the flag is set, and the dwDataLen parameter has a nonzero value.</term>
	/// </item>
	/// <item>
	/// <term>NTE_BAD_UID</term>
	/// <term>The CSP context that was specified when the hash object was created cannot be found.</term>
	/// </item>
	/// <item>
	/// <term>NTE_FAIL</term>
	/// <term>The function failed in some unexpected way.</term>
	/// </item>
	/// <item>
	/// <term>NTE_NO_MEMORY</term>
	/// <term>The CSP ran out of memory during the operation.</term>
	/// </item>
	/// </list>
	/// </returns>
	// https://docs.microsoft.com/en-us/windows/win32/api/wincrypt/nf-wincrypt-crypthashdata BOOL CryptHashData( HCRYPTHASH hHash, const BYTE
	// *pbData, DWORD dwDataLen, DWORD dwFlags );
	[DllImport(Lib.AdvApi32, SetLastError = true, ExactSpelling = true)]
	[PInvokeData("wincrypt.h", MSDNShortId = "ec1482a2-c2cb-4c5f-af9c-d493134413d6")]
	[return: MarshalAs(UnmanagedType.Bool)]
	public static extern bool CryptHashData(HCRYPTHASH hHash, [In] IntPtr pbData, uint dwDataLen, uint dwFlags);

	/// <summary>
	/// The CryptHashSessionKey function computes the cryptographic hash of a session key object. This function can be called multiple times
	/// with the same hash handle to compute the hash of multiple keys. Calls to CryptHashSessionKey can be interspersed with calls to CryptHashData.
	/// <para>Before calling this function, CryptCreateHash must be called to create the handle of a hash object.</para>
	/// </summary>
	/// <param name="hHash">A handle to the hash object.</param>
	/// <param name="hKey">A handle to the key object to be hashed.</param>
	/// <param name="dwFlags">
	/// <para>The following flag value is defined.</para>
	/// <list type="table">
	/// <listheader>
	/// <term>Value</term>
	/// <term>Meaning</term>
	/// </listheader>
	/// <item>
	/// <term>CRYPT_LITTLE_ENDIAN 0x00000001</term>
	/// <term>
	/// When this flag is set, the bytes of the key are hashed in little-endian form. Note that by default (when dwFlags is zero), the bytes
	/// of the key are hashed in big-endian form.
	/// </term>
	/// </item>
	/// </list>
	/// </param>
	/// <returns>
	/// <para>If the function succeeds, the return value is <c>TRUE</c>.</para>
	/// <para>If the function fails, the return value is <c>FALSE</c>. For extended error information, call GetLastError.</para>
	/// <para>The error codes prefaced by "NTE" are generated by the particular CSP you are using. Some possible error codes follow.</para>
	/// <list type="table">
	/// <listheader>
	/// <term>Return code</term>
	/// <term>Description</term>
	/// </listheader>
	/// <item>
	/// <term>ERROR_INVALID_HANDLE</term>
	/// <term>One of the parameters specifies a handle that is not valid.</term>
	/// </item>
	/// <item>
	/// <term>ERROR_INVALID_PARAMETER</term>
	/// <term>One of the parameters contains a value that is not valid. This is most often a pointer that is not valid.</term>
	/// </item>
	/// <item>
	/// <term>NTE_BAD_ALGID</term>
	/// <term>The hHash handle specifies an algorithm that this CSP does not support.</term>
	/// </item>
	/// <item>
	/// <term>NTE_BAD_FLAGS</term>
	/// <term>The dwFlags parameter is nonzero.</term>
	/// </item>
	/// <item>
	/// <term>NTE_BAD_HASH</term>
	/// <term>The hash object specified by the hHash parameter is not valid.</term>
	/// </item>
	/// <item>
	/// <term>NTE_BAD_HASH_STATE</term>
	/// <term>An attempt was made to add data to a hash object that is already marked "finished."</term>
	/// </item>
	/// <item>
	/// <term>NTE_BAD_KEY</term>
	/// <term>
	/// A keyed hash algorithm is being used, but the session key is no longer valid. This error is generated if the session key is destroyed
	/// before the hashing operation is complete.
	/// </term>
	/// </item>
	/// <item>
	/// <term>NTE_BAD_UID</term>
	/// <term>The CSP context that was specified when the hash object was created cannot be found.</term>
	/// </item>
	/// <item>
	/// <term>NTE_FAIL</term>
	/// <term>The function failed in some unexpected way.</term>
	/// </item>
	/// </list>
	/// </returns>
	// https://docs.microsoft.com/en-us/windows/win32/api/wincrypt/nf-wincrypt-crypthashsessionkey BOOL CryptHashSessionKey( HCRYPTHASH
	// hHash, HCRYPTKEY hKey, DWORD dwFlags );
	[DllImport(Lib.AdvApi32, SetLastError = true, ExactSpelling = true)]
	[PInvokeData("wincrypt.h", MSDNShortId = "75781993-7faf-4149-80cc-ae50dbd4de2a")]
	[return: MarshalAs(UnmanagedType.Bool)]
	public static extern bool CryptHashSessionKey(HCRYPTHASH hHash, HCRYPTKEY hKey, CryptHashSessionKeyFlags dwFlags);

	/// <summary>
	/// The CryptImportKey function transfers a cryptographic key from a key BLOB into a cryptographic service provider (CSP). This function
	/// can be used to import an Schannel session key, regular session key, public key, or public/private key pair. For all but the public
	/// key, the key or key pair is encrypted.
	/// </summary>
	/// <param name="hProv">The handle of a CSP obtained with the CryptAcquireContext function.</param>
	/// <param name="pbData">
	/// A <c>BYTE</c> array that contains a PUBLICKEYSTRUC BLOB header followed by the encrypted key. This key BLOB is created by the
	/// CryptExportKey function, either in this application or by another application possibly running on a different computer.
	/// </param>
	/// <param name="dwDataLen">Contains the length, in bytes, of the key BLOB.</param>
	/// <param name="hPubKey">
	/// <para>
	/// A handle to the cryptographic key that decrypts the key stored in pbData. This key must come from the same CSP to which hProv refers.
	/// The meaning of this parameter differs depending on the CSP type and the type of key BLOB being imported:
	/// </para>
	/// <list type="bullet">
	/// <item>
	/// <term>
	/// If the key BLOB is encrypted with the key exchange key pair, for example, a <c>SIMPLEBLOB</c>, this parameter can be the handle to
	/// the key exchange key.
	/// </term>
	/// </item>
	/// <item>
	/// <term>
	/// If the key BLOB is encrypted with a session key, for example, an encrypted <c>PRIVATEKEYBLOB</c>, this parameter contains the handle
	/// of this session key.
	/// </term>
	/// </item>
	/// <item>
	/// <term>If the key BLOB is not encrypted, for example, a <c>PUBLICKEYBLOB</c>, this parameter is not used and must be zero.</term>
	/// </item>
	/// <item>
	/// <term>
	/// If the key BLOB is encrypted with a session key in an Schannel CSP, for example, an encrypted <c>OPAQUEKEYBLOB</c> or any other
	/// vendor-specific <c>OPAQUEKEYBLOB</c>, this parameter is not used and must be set to zero.
	/// </term>
	/// </item>
	/// </list>
	/// <para>
	/// <c>Note</c> Some CSPs may modify this parameter as a result of the operation. Applications that subsequently use this key for other
	/// purposes should call the CryptDuplicateKey function to create a duplicate key handle. When the application has finished using the
	/// handle, release it by calling the CryptDestroyKey function.
	/// </para>
	/// </param>
	/// <param name="dwFlags">
	/// Currently used only when a public/private key pair in the form of a <c>PRIVATEKEYBLOB</c> is imported into the CSP.
	/// <para>This parameter can be one of the following values.</para>
	/// <list type="table">
	/// <listheader>
	/// <term>Value</term>
	/// <term>Meaning</term>
	/// </listheader>
	/// <item>
	/// <term>CRYPT_EXPORTABLE</term>
	/// <term>
	/// The key being imported is eventually to be reexported. If this flag is not used, then calls to CryptExportKey with the key handle fail.
	/// </term>
	/// </item>
	/// <item>
	/// <term>CRYPT_OAEP</term>
	/// <term>This flag causes PKCS #1 version 2 formatting to be checked with RSA encryption and decryption when importing SIMPLEBLOBs.</term>
	/// </item>
	/// <item>
	/// <term>CRYPT_NO_SALT</term>
	/// <term>A no-salt value gets allocated for a 40-bit symmetric key. For more information, see Salt Value Functionality.</term>
	/// </item>
	/// <item>
	/// <term>CRYPT_USER_PROTECTED</term>
	/// <term>
	/// If this flag is set, the CSP notifies the user through a dialog box or some other method when certain actions are attempted using
	/// this key. The precise behavior is specified by the CSP or the CSP type used. If the provider context was acquired with CRYPT_SILENT
	/// set, using this flag causes a failure and the last error is set to NTE_SILENT_CONTEXT.
	/// </term>
	/// </item>
	/// <item>
	/// <term>CRYPT_IPSEC_HMAC_KEY</term>
	/// <term>
	/// Allows for the import of an RC2 key that is larger than 16 bytes. If this flag is not set, calls to the CryptImportKey function with
	/// RC2 keys that are greater than 16 bytes fail, and a call to GetLastError will return NTE_BAD_DATA.
	/// </term>
	/// </item>
	/// </list>
	/// </param>
	/// <param name="phKey">
	/// A pointer to a <c>HCRYPTKEY</c> value that receives the handle of the imported key. When you have finished using the key, release the
	/// handle by calling the CryptDestroyKey function.
	/// </param>
	/// <returns>
	/// <para>If the function succeeds, the function returns nonzero.</para>
	/// <para>If the function fails, it returns zero. For extended error information, call GetLastError.</para>
	/// <para>Error codes prefaced by "NTE" are generated by the particular CSP being used. Some possible error codes follow.</para>
	/// <list type="table">
	/// <listheader>
	/// <term>Return code</term>
	/// <term>Description</term>
	/// </listheader>
	/// <item>
	/// <term>ERROR_BUSY</term>
	/// <term>Some CSPs set this error if a private key is imported into a container while another thread or process is using this key.</term>
	/// </item>
	/// <item>
	/// <term>ERROR_INVALID_HANDLE</term>
	/// <term>One of the parameters specifies a handle that is not valid.</term>
	/// </item>
	/// <item>
	/// <term>ERROR_INVALID_PARAMETER</term>
	/// <term>One of the parameters contains a value that is not valid. This is most often a pointer that is not valid.</term>
	/// </item>
	/// <item>
	/// <term>NTE_BAD_ALGID</term>
	/// <term>The simple key BLOB to be imported is not encrypted with the expected key exchange algorithm.</term>
	/// </item>
	/// <item>
	/// <term>NTE_BAD_DATA</term>
	/// <term>
	/// Either the algorithm that works with the public key to be imported is not supported by this CSP, or an attempt was made to import a
	/// session key that was encrypted with something other than one of your public keys.
	/// </term>
	/// </item>
	/// <item>
	/// <term>NTE_BAD_FLAGS</term>
	/// <term>The dwFlags parameter specified is not valid.</term>
	/// </item>
	/// <item>
	/// <term>NTE_BAD_TYPE</term>
	/// <term>The key BLOB type is not supported by this CSP and is possibly not valid.</term>
	/// </item>
	/// <item>
	/// <term>NTE_BAD_UID</term>
	/// <term>The hProv parameter does not contain a valid context handle.</term>
	/// </item>
	/// <item>
	/// <term>NTE_BAD_VER</term>
	/// <term>The version number of the key BLOB does not match the CSP version. This usually indicates that the CSP needs to be upgraded.</term>
	/// </item>
	/// </list>
	/// </returns>
	/// <remarks>
	/// <para>
	/// When importing a Hash-Based Message Authentication Code (HMAC) key, the caller must identify the imported key as a
	/// <c>PLAINTEXTKEYBLOB</c> type and set the appropriate algorithm identifier in the <c>aiKeyAlg</c> field of the PUBLICKEYSTRUC BLOB header.
	/// </para>
	/// <para>
	/// The <c>CryptImportKey</c> function can be used to import a plaintext key for symmetric algorithms; however, we recommend that, for
	/// ease of use, you use the CryptGenKey function instead. When you import a plaintext key, the structure of the key BLOB that is passed
	/// in the pbData parameter is a PLAINTEXTKEYBLOB.
	/// </para>
	/// <para>You can use the <c>PLAINTEXTKEYBLOB</c> type with any algorithm or type of key combination supported by the CSP in use.</para>
	/// <para>For an example of importing a plaintext key, see Example C Program: Importing a Plaintext Key.</para>
	/// <para>The following example shows how you can set the header fields.</para>
	/// <para>The length of the key is specified in keyBlob.keyLength, which is followed by the actual key data.</para>
	/// <para>
	/// <c>Note</c> The HMAC algorithms do not have their own algorithm identifiers; use CALG_RC2 instead. <c>CRYPT_IPSEC_HMAC_KEY</c> allows
	/// the import of RC2 keys longer than 16 bytes.
	/// </para>
	/// <para>
	/// For any of the Data Encryption Standard (DES) key permutations that use <c>PLAINTEXTKEYBLOB</c>, only the full key size, including
	/// parity bit, can be imported.
	/// </para>
	/// <para>The following key sizes are supported.</para>
	/// <list type="table">
	/// <listheader>
	/// <term>Algorithm</term>
	/// <term>Supported key size</term>
	/// </listheader>
	/// <item>
	/// <term>CALG_DES</term>
	/// <term>64 bits</term>
	/// </item>
	/// <item>
	/// <term>CALG_3DES_112</term>
	/// <term>128 bits</term>
	/// </item>
	/// <item>
	/// <term>CALG_3DES</term>
	/// <term>192 bits</term>
	/// </item>
	/// </list>
	/// <para>Examples</para>
	/// <para>
	/// The following example shows how to import a key from a key BLOB. For a full example for this function, see Example C Program: Signing
	/// a Hash and Verifying the Hash Signature. For additional code that uses this function, see Example C Program: Decrypting a File.
	/// </para>
	/// </remarks>
	// https://docs.microsoft.com/en-us/windows/win32/api/wincrypt/nf-wincrypt-cryptimportkey BOOL CryptImportKey( HCRYPTPROV hProv, const
	// BYTE *pbData, DWORD dwDataLen, HCRYPTKEY hPubKey, DWORD dwFlags, HCRYPTKEY *phKey );
	[DllImport(Lib.AdvApi32, SetLastError = true, ExactSpelling = true)]
	[PInvokeData("wincrypt.h", MSDNShortId = "f48b6ec9-e03b-43b0-9f22-120ae93d934c")]
	[return: MarshalAs(UnmanagedType.Bool)]
	public static extern bool CryptImportKey(HCRYPTPROV hProv, [In] IntPtr pbData, uint dwDataLen, HCRYPTKEY hPubKey, uint dwFlags, out SafeHCRYPTKEY phKey);

	/// <summary>
	/// The CryptImportKey function transfers a cryptographic key from a key BLOB into a cryptographic service provider (CSP). This function
	/// can be used to import an Schannel session key, regular session key, public key, or public/private key pair. For all but the public
	/// key, the key or key pair is encrypted.
	/// </summary>
	/// <param name="hProv">The handle of a CSP obtained with the CryptAcquireContext function.</param>
	/// <param name="pbData">
	/// A <c>BYTE</c> array that contains a PUBLICKEYSTRUC BLOB header followed by the encrypted key. This key BLOB is created by the
	/// CryptExportKey function, either in this application or by another application possibly running on a different computer.
	/// </param>
	/// <param name="dwDataLen">Contains the length, in bytes, of the key BLOB.</param>
	/// <param name="hPubKey">
	/// <para>
	/// A handle to the cryptographic key that decrypts the key stored in pbData. This key must come from the same CSP to which hProv refers.
	/// The meaning of this parameter differs depending on the CSP type and the type of key BLOB being imported:
	/// </para>
	/// <list type="bullet">
	/// <item>
	/// <term>
	/// If the key BLOB is encrypted with the key exchange key pair, for example, a <c>SIMPLEBLOB</c>, this parameter can be the handle to
	/// the key exchange key.
	/// </term>
	/// </item>
	/// <item>
	/// <term>
	/// If the key BLOB is encrypted with a session key, for example, an encrypted <c>PRIVATEKEYBLOB</c>, this parameter contains the handle
	/// of this session key.
	/// </term>
	/// </item>
	/// <item>
	/// <term>If the key BLOB is not encrypted, for example, a <c>PUBLICKEYBLOB</c>, this parameter is not used and must be zero.</term>
	/// </item>
	/// <item>
	/// <term>
	/// If the key BLOB is encrypted with a session key in an Schannel CSP, for example, an encrypted <c>OPAQUEKEYBLOB</c> or any other
	/// vendor-specific <c>OPAQUEKEYBLOB</c>, this parameter is not used and must be set to zero.
	/// </term>
	/// </item>
	/// </list>
	/// <para>
	/// <c>Note</c> Some CSPs may modify this parameter as a result of the operation. Applications that subsequently use this key for other
	/// purposes should call the CryptDuplicateKey function to create a duplicate key handle. When the application has finished using the
	/// handle, release it by calling the CryptDestroyKey function.
	/// </para>
	/// </param>
	/// <param name="dwFlags">
	/// Currently used only when a public/private key pair in the form of a <c>PRIVATEKEYBLOB</c> is imported into the CSP.
	/// <para>This parameter can be one of the following values.</para>
	/// <list type="table">
	/// <listheader>
	/// <term>Value</term>
	/// <term>Meaning</term>
	/// </listheader>
	/// <item>
	/// <term>CRYPT_EXPORTABLE</term>
	/// <term>
	/// The key being imported is eventually to be reexported. If this flag is not used, then calls to CryptExportKey with the key handle fail.
	/// </term>
	/// </item>
	/// <item>
	/// <term>CRYPT_OAEP</term>
	/// <term>This flag causes PKCS #1 version 2 formatting to be checked with RSA encryption and decryption when importing SIMPLEBLOBs.</term>
	/// </item>
	/// <item>
	/// <term>CRYPT_NO_SALT</term>
	/// <term>A no-salt value gets allocated for a 40-bit symmetric key. For more information, see Salt Value Functionality.</term>
	/// </item>
	/// <item>
	/// <term>CRYPT_USER_PROTECTED</term>
	/// <term>
	/// If this flag is set, the CSP notifies the user through a dialog box or some other method when certain actions are attempted using
	/// this key. The precise behavior is specified by the CSP or the CSP type used. If the provider context was acquired with CRYPT_SILENT
	/// set, using this flag causes a failure and the last error is set to NTE_SILENT_CONTEXT.
	/// </term>
	/// </item>
	/// <item>
	/// <term>CRYPT_IPSEC_HMAC_KEY</term>
	/// <term>
	/// Allows for the import of an RC2 key that is larger than 16 bytes. If this flag is not set, calls to the CryptImportKey function with
	/// RC2 keys that are greater than 16 bytes fail, and a call to GetLastError will return NTE_BAD_DATA.
	/// </term>
	/// </item>
	/// </list>
	/// </param>
	/// <param name="phKey">
	/// A pointer to a <c>HCRYPTKEY</c> value that receives the handle of the imported key. When you have finished using the key, release the
	/// handle by calling the CryptDestroyKey function.
	/// </param>
	/// <returns>
	/// <para>If the function succeeds, the function returns nonzero.</para>
	/// <para>If the function fails, it returns zero. For extended error information, call GetLastError.</para>
	/// <para>Error codes prefaced by "NTE" are generated by the particular CSP being used. Some possible error codes follow.</para>
	/// <list type="table">
	/// <listheader>
	/// <term>Return code</term>
	/// <term>Description</term>
	/// </listheader>
	/// <item>
	/// <term>ERROR_BUSY</term>
	/// <term>Some CSPs set this error if a private key is imported into a container while another thread or process is using this key.</term>
	/// </item>
	/// <item>
	/// <term>ERROR_INVALID_HANDLE</term>
	/// <term>One of the parameters specifies a handle that is not valid.</term>
	/// </item>
	/// <item>
	/// <term>ERROR_INVALID_PARAMETER</term>
	/// <term>One of the parameters contains a value that is not valid. This is most often a pointer that is not valid.</term>
	/// </item>
	/// <item>
	/// <term>NTE_BAD_ALGID</term>
	/// <term>The simple key BLOB to be imported is not encrypted with the expected key exchange algorithm.</term>
	/// </item>
	/// <item>
	/// <term>NTE_BAD_DATA</term>
	/// <term>
	/// Either the algorithm that works with the public key to be imported is not supported by this CSP, or an attempt was made to import a
	/// session key that was encrypted with something other than one of your public keys.
	/// </term>
	/// </item>
	/// <item>
	/// <term>NTE_BAD_FLAGS</term>
	/// <term>The dwFlags parameter specified is not valid.</term>
	/// </item>
	/// <item>
	/// <term>NTE_BAD_TYPE</term>
	/// <term>The key BLOB type is not supported by this CSP and is possibly not valid.</term>
	/// </item>
	/// <item>
	/// <term>NTE_BAD_UID</term>
	/// <term>The hProv parameter does not contain a valid context handle.</term>
	/// </item>
	/// <item>
	/// <term>NTE_BAD_VER</term>
	/// <term>The version number of the key BLOB does not match the CSP version. This usually indicates that the CSP needs to be upgraded.</term>
	/// </item>
	/// </list>
	/// </returns>
	/// <remarks>
	/// <para>
	/// When importing a Hash-Based Message Authentication Code (HMAC) key, the caller must identify the imported key as a
	/// <c>PLAINTEXTKEYBLOB</c> type and set the appropriate algorithm identifier in the <c>aiKeyAlg</c> field of the PUBLICKEYSTRUC BLOB header.
	/// </para>
	/// <para>
	/// The <c>CryptImportKey</c> function can be used to import a plaintext key for symmetric algorithms; however, we recommend that, for
	/// ease of use, you use the CryptGenKey function instead. When you import a plaintext key, the structure of the key BLOB that is passed
	/// in the pbData parameter is a PLAINTEXTKEYBLOB.
	/// </para>
	/// <para>You can use the <c>PLAINTEXTKEYBLOB</c> type with any algorithm or type of key combination supported by the CSP in use.</para>
	/// <para>For an example of importing a plaintext key, see Example C Program: Importing a Plaintext Key.</para>
	/// <para>The following example shows how you can set the header fields.</para>
	/// <para>The length of the key is specified in keyBlob.keyLength, which is followed by the actual key data.</para>
	/// <para>
	/// <c>Note</c> The HMAC algorithms do not have their own algorithm identifiers; use CALG_RC2 instead. <c>CRYPT_IPSEC_HMAC_KEY</c> allows
	/// the import of RC2 keys longer than 16 bytes.
	/// </para>
	/// <para>
	/// For any of the Data Encryption Standard (DES) key permutations that use <c>PLAINTEXTKEYBLOB</c>, only the full key size, including
	/// parity bit, can be imported.
	/// </para>
	/// <para>The following key sizes are supported.</para>
	/// <list type="table">
	/// <listheader>
	/// <term>Algorithm</term>
	/// <term>Supported key size</term>
	/// </listheader>
	/// <item>
	/// <term>CALG_DES</term>
	/// <term>64 bits</term>
	/// </item>
	/// <item>
	/// <term>CALG_3DES_112</term>
	/// <term>128 bits</term>
	/// </item>
	/// <item>
	/// <term>CALG_3DES</term>
	/// <term>192 bits</term>
	/// </item>
	/// </list>
	/// <para>Examples</para>
	/// <para>
	/// The following example shows how to import a key from a key BLOB. For a full example for this function, see Example C Program: Signing
	/// a Hash and Verifying the Hash Signature. For additional code that uses this function, see Example C Program: Decrypting a File.
	/// </para>
	/// </remarks>
	// https://docs.microsoft.com/en-us/windows/win32/api/wincrypt/nf-wincrypt-cryptimportkey BOOL CryptImportKey( HCRYPTPROV hProv, const
	// BYTE *pbData, DWORD dwDataLen, HCRYPTKEY hPubKey, DWORD dwFlags, HCRYPTKEY *phKey );
	[DllImport(Lib.AdvApi32, SetLastError = true, ExactSpelling = true)]
	[PInvokeData("wincrypt.h", MSDNShortId = "f48b6ec9-e03b-43b0-9f22-120ae93d934c")]
	[return: MarshalAs(UnmanagedType.Bool)]
	public static extern bool CryptImportKey(HCRYPTPROV hProv, [In] byte[] pbData, int dwDataLen, HCRYPTKEY hPubKey, uint dwFlags, out SafeHCRYPTKEY phKey);

	/// <summary>
	/// <para>
	/// The CryptReleaseContext function releases the handle of a cryptographic service provider (CSP) and a key container. At each call to
	/// this function, the reference count on the CSP is reduced by one. When the reference count reaches zero, the context is fully released
	/// and it can no longer be used by any function in the application.
	/// </para>
	/// <para>
	/// An application calls this function after finishing the use of the CSP. After this function is called, the released CSP handle is no
	/// longer valid. This function does not destroy key containers or key pairs.
	/// </para>
	/// </summary>
	/// <param name="hProv">Handle of a cryptographic service provider (CSP) created by a call to CryptAcquireContext.</param>
	/// <param name="dwFlags">
	/// Reserved for future use and must be zero. If dwFlags is not set to zero, this function returns <c>FALSE</c> but the CSP is released.
	/// </param>
	/// <returns>
	/// <para>If the function succeeds, the return value is nonzero ( <c>TRUE</c>).</para>
	/// <para>
	/// If the function fails, the return value is zero ( <c>FALSE</c>). For extended error information, call GetLastError. Some possible
	/// error codes are listed in the following table.
	/// </para>
	/// <list type="table">
	/// <listheader>
	/// <term>Return code</term>
	/// <term>Description</term>
	/// </listheader>
	/// <item>
	/// <term>ERROR_BUSY</term>
	/// <term>The CSP context specified by hProv is currently being used by another process.</term>
	/// </item>
	/// <item>
	/// <term>ERROR_INVALID_HANDLE</term>
	/// <term>One of the parameters specifies a handle that is not valid.</term>
	/// </item>
	/// <item>
	/// <term>ERROR_INVALID_PARAMETER</term>
	/// <term>One of the parameters contains a value that is not valid. This is most often a pointer that is not valid.</term>
	/// </item>
	/// <item>
	/// <term>NTE_BAD_FLAGS</term>
	/// <term>The dwFlags parameter is nonzero.</term>
	/// </item>
	/// <item>
	/// <term>NTE_BAD_UID</term>
	/// <term>The hProv parameter does not contain a valid context handle.</term>
	/// </item>
	/// </list>
	/// </returns>
	/// <remarks>
	/// <para>
	/// After this function has been called, the CSP session is finished and all existing session keys and hash objects created by using the
	/// hProv handle are no longer valid. In practice, all of these objects should be destroyed with calls to CryptDestroyKey and
	/// CryptDestroyHash before <c>CryptReleaseContext</c> is called.
	/// </para>
	/// <para>Examples</para>
	/// <para>For an example that uses this function, see Example C Program: Creating and Hashing a Session Key.</para>
	/// </remarks>
	// https://docs.microsoft.com/en-us/windows/win32/api/wincrypt/nf-wincrypt-cryptreleasecontext BOOL CryptReleaseContext( HCRYPTPROV
	// hProv, DWORD dwFlags );
	[DllImport(Lib.AdvApi32, SetLastError = true, ExactSpelling = true)]
	[PInvokeData("wincrypt.h", MSDNShortId = "c1e3e708-b543-4e87-8638-a9946a83e614")]
	[return: MarshalAs(UnmanagedType.Bool)]
	public static extern bool CryptReleaseContext(HCRYPTPROV hProv, uint dwFlags = 0);

	/// <summary>
	/// The CryptSetHashParam function customizes the operations of a hash object, including setting up initial hash contents and selecting a
	/// specific hashing algorithm.
	/// </summary>
	/// <param name="hHash">A handle to the hash object on which to set parameters.</param>
	/// <param name="dwParam">
	/// <para>This parameter can be one of the following values.</para>
	/// <list type="table">
	/// <listheader>
	/// <term>Value</term>
	/// <term>Meaning</term>
	/// </listheader>
	/// <item>
	/// <term>HP_HMAC_INFO.</term>
	/// <term>A pointer to an HMAC_INFO structure that specifies the cryptographic hash algorithm and the inner and outer strings to be used.</term>
	/// </item>
	/// <item>
	/// <term>HP_HASHVAL.</term>
	/// <term>
	/// A byte array that contains a hash value to place directly into the hash object. Before setting this value, the size of the hash value
	/// must be determined by using the CryptGetHashParam function to read the HP_HASHSIZE value. Some cryptographic service providers (CSPs)
	/// do not support this capability.
	/// </term>
	/// </item>
	/// </list>
	/// <para><c>Note</c> Some CSP types can add additional values that can be set by using this function.</para>
	/// </param>
	/// <param name="pbData">
	/// A value data buffer. Place the value data in this buffer before calling <c>CryptSetHashParam</c>. The form of this data varies,
	/// depending on the value number.
	/// </param>
	/// <param name="dwFlags">This parameter is reserved for future use and must be set to zero.</param>
	/// <returns>
	/// <para>If the function succeeds, the function returns <c>TRUE</c>.</para>
	/// <para>If the function fails, it returns <c>FALSE</c>. For extended error information, call GetLastError.</para>
	/// <para>The error codes prefaced by "NTE" are generated by the particular CSP you are using. Some possible error codes follow.</para>
	/// <list type="table">
	/// <listheader>
	/// <term>Return code</term>
	/// <term>Description</term>
	/// </listheader>
	/// <item>
	/// <term>ERROR_INVALID_HANDLE</term>
	/// <term>One of the parameters specifies a handle that is not valid.</term>
	/// </item>
	/// <item>
	/// <term>ERROR_BUSY</term>
	/// <term>The CSP context is currently being used by another process.</term>
	/// </item>
	/// <item>
	/// <term>ERROR_INVALID_PARAMETER</term>
	/// <term>One of the parameters contains a value that is not valid. This is most often a pointer that is not valid.</term>
	/// </item>
	/// <item>
	/// <term>NTE_BAD_FLAGS</term>
	/// <term>The dwFlags parameter is nonzero or the pbData buffer contains a value that is not valid.</term>
	/// </item>
	/// <item>
	/// <term>NTE_BAD_HASH</term>
	/// <term>The hash object specified by the hHash parameter is not valid.</term>
	/// </item>
	/// <item>
	/// <term>NTE_BAD_TYPE</term>
	/// <term>The dwParam parameter specifies an unknown value.</term>
	/// </item>
	/// <item>
	/// <term>NTE_BAD_UID</term>
	/// <term>The CSP context that was specified when the hKey key was created cannot be found.</term>
	/// </item>
	/// <item>
	/// <term>NTE_FAIL</term>
	/// <term>The function failed in some unexpected way.</term>
	/// </item>
	/// </list>
	/// </returns>
	/// <remarks>
	/// <para>
	/// Occasionally, a hash value that has been generated elsewhere must be signed. This can be done by using the following sequence of operations:
	/// </para>
	/// <list type="number">
	/// <item>
	/// <term>Create a hash object by using CryptCreateHash.</term>
	/// </item>
	/// <item>
	/// <term>Set the HP_HASHVAL value.</term>
	/// </item>
	/// <item>
	/// <term>Sign the hash value by using CryptSignHash and obtain a digital signature block.</term>
	/// </item>
	/// <item>
	/// <term>Destroy the hash object by using CryptDestroyHash.</term>
	/// </item>
	/// </list>
	/// </remarks>
	// https://docs.microsoft.com/en-us/windows/win32/api/wincrypt/nf-wincrypt-cryptsethashparam BOOL CryptSetHashParam( HCRYPTHASH hHash,
	// DWORD dwParam, const BYTE *pbData, DWORD dwFlags );
	[DllImport(Lib.AdvApi32, SetLastError = true, ExactSpelling = true)]
	[PInvokeData("wincrypt.h", MSDNShortId = "0c8d3ef9-e7b5-4e49-a2f8-9c85b16549da")]
	[return: MarshalAs(UnmanagedType.Bool)]
	public static extern bool CryptSetHashParam(HCRYPTHASH hHash, HashParam dwParam, [In] IntPtr pbData, uint dwFlags = 0);

	/// <summary>
	/// <para>A handle to the hash object on which to set parameters.</para>
	/// <para>This parameter can be one of the following values.</para>
	/// <list type="table">
	/// <listheader>
	/// <description>Value</description>
	/// <description>Meaning</description>
	/// </listheader>
	/// <item>
	/// <description><c>HP_HMAC_INFO.</c></description>
	/// <description>
	/// A pointer to an HMAC_INFO structure that specifies the cryptographic hash algorithm and the inner and outer strings to be used.
	/// </description>
	/// </item>
	/// <item>
	/// <description><c>HP_HASHVAL.</c></description>
	/// <description>
	/// A byte array that contains a hash value to place directly into the hash object. Before setting this value, the size of the hash value
	/// must be determined by using the CryptGetHashParam function to read the HP_HASHSIZE value. Some cryptographic service providers (CSPs)
	/// do not support this capability.
	/// </description>
	/// </item>
	/// </list>
	/// <para>Â</para>
	/// <para><c>Note</c> Â Â Some CSP types can add additional values that can be set by using this function.</para>
	/// <para>Â</para>
	/// <para>
	/// A value data buffer. Place the value data in this buffer before calling <c>CryptSetHashParam</c>. The form of this data varies,
	/// depending on the value number.
	/// </para>
	/// <para>This parameter is reserved for future use and must be set to zero.</para>
	/// </summary>
	/// <typeparam name="TIn">The type of the in.</typeparam>
	/// <param name="hHash">A handle to the hash object on which to set parameters.</param>
	/// <param name="dwParam">
	/// <para>This parameter can be one of the following values.</para>
	/// <list type="table">
	/// <listheader>
	/// <description>Value</description>
	/// <description>Meaning</description>
	/// </listheader>
	/// <item>
	/// <description><c>HP_HMAC_INFO.</c></description>
	/// <description>
	/// A pointer to an HMAC_INFO structure that specifies the cryptographic hash algorithm and the inner and outer strings to be used.
	/// </description>
	/// </item>
	/// <item>
	/// <description><c>HP_HASHVAL.</c></description>
	/// <description>
	/// A byte array that contains a hash value to place directly into the hash object. Before setting this value, the size of the hash value
	/// must be determined by using the CryptGetHashParam function to read the HP_HASHSIZE value. Some cryptographic service providers (CSPs)
	/// do not support this capability.
	/// </description>
	/// </item>
	/// </list>
	/// <para>Â</para>
	/// <para><c>Note</c> Â Â Some CSP types can add additional values that can be set by using this function.</para>
	/// <para>Â</para>
	/// </param>
	/// <param name="pbData">A value. The form of this data varies, depending on the value number.</param>
	/// <returns>
	/// <para>If the function succeeds, the function returns <c>TRUE</c>.</para>
	/// <para>If the function fails, it returns <c>FALSE</c>. For extended error information, call GetLastError.</para>
	/// <para>The error codes prefaced by "NTE" are generated by the particular CSP you are using. Some possible error codes follow.</para>
	/// <list type="table">
	/// <listheader>
	/// <description>Return code</description>
	/// <description>Description</description>
	/// </listheader>
	/// <item>
	/// <description><c>ERROR_INVALID_HANDLE</c></description>
	/// <description>One of the parameters specifies a handle that is not valid.</description>
	/// </item>
	/// <item>
	/// <description><c>ERROR_BUSY</c></description>
	/// <description>The CSP context is currently being used by another process.</description>
	/// </item>
	/// <item>
	/// <description><c>ERROR_INVALID_PARAMETER</c></description>
	/// <description>One of the parameters contains a value that is not valid. This is most often a pointer that is not valid.</description>
	/// </item>
	/// <item>
	/// <description><c>NTE_BAD_FLAGS</c></description>
	/// <description>The <c>dwFlags</c> parameter is nonzero or the <c>pbData</c> buffer contains a value that is not valid.</description>
	/// </item>
	/// <item>
	/// <description><c>NTE_BAD_HASH</c></description>
	/// <description>The hash object specified by the <c>hHash</c> parameter is not valid.</description>
	/// </item>
	/// <item>
	/// <description><c>NTE_BAD_TYPE</c></description>
	/// <description>The <c>dwParam</c> parameter specifies an unknown value.</description>
	/// </item>
	/// <item>
	/// <description><c>NTE_BAD_UID</c></description>
	/// <description>The CSP context that was specified when the <c>hKey</c> key was created cannot be found.</description>
	/// </item>
	/// <item>
	/// <description><c>NTE_FAIL</c></description>
	/// <description>The function failed in some unexpected way.</description>
	/// </item>
	/// </list>
	/// </returns>
	/// <remarks>
	/// <para>
	/// Occasionally, a hash value that has been generated elsewhere must be signed. This can be done by using the following sequence of operations:
	/// </para>
	/// <list type="number">
	/// <item>
	/// <description>Create a hash object by using CryptCreateHash.</description>
	/// </item>
	/// <item>
	/// <description>Set the HP_HASHVAL value.</description>
	/// </item>
	/// <item>
	/// <description>Sign the hash value by using CryptSignHash and obtain a digital signature block.</description>
	/// </item>
	/// <item>
	/// <description>Destroy the hash object by using CryptDestroyHash.</description>
	/// </item>
	/// </list>
	/// </remarks>
	// https://learn.microsoft.com/en-us/windows/win32/api/wincrypt/nf-wincrypt-cryptsethashparam BOOL CryptSetHashParam( [in] HCRYPTHASH
	// hHash, [in] DWORD dwParam, [in] const BYTE *pbData, [in] DWORD dwFlags );
	[PInvokeData("wincrypt.h", MSDNShortId = "NF:wincrypt.CryptSetHashParam")]
	public static bool CryptSetHashParam<TIn>(HCRYPTHASH hHash, HashParam dwParam, TIn pbData) => CryptSetValue(CryptSetHashParam, hHash, dwParam, pbData);

	/// <summary>
	/// The CryptSetKeyParam function customizes various aspects of a session key's operations. The values set by this function are not
	/// persisted to memory and can only be used with in a single session.
	/// <para>
	/// The Microsoft Base Cryptographic Provider does not permit setting values for key exchange or signature keys; however, custom
	/// providers can define values that can be set for its keys.
	/// </para>
	/// </summary>
	/// <param name="hKey">A handle to the key for which values are to be set.</param>
	/// <param name="dwParam">
	/// <para>The following tables contain predefined values that can be used.</para>
	/// <para>For all key types, this parameter can contain one of the following values.</para>
	/// <list type="table">
	/// <listheader>
	/// <term>Value</term>
	/// <term>Meaning</term>
	/// </listheader>
	/// <item>
	/// <term>KP_ALGID</term>
	/// <term>
	/// pbData points to an appropriate ALG_ID. This is used when exchanging session keys with the Microsoft Base Digital Signature Standard
	/// (DSS), Diffie-Hellman Cryptographic Provider, or compatible CSPs. After a key is agreed upon with the CryptImportKey function, the
	/// session key is enabled for use by setting its algorithm type.
	/// </term>
	/// </item>
	/// <item>
	/// <term>KP_CERTIFICATE</term>
	/// <term>
	/// pbData is the address of a buffer that contains the X.509 certificate that has been encoded by using Distinguished Encoding Rules
	/// (DER). The public key in the certificate must match the corresponding signature or exchange key.
	/// </term>
	/// </item>
	/// <item>
	/// <term>KP_PERMISSIONS</term>
	/// <term>pbData points to a DWORD value that specifies zero or more permission flags. For a description of these flags, see CryptGetKeyParam.</term>
	/// </item>
	/// <item>
	/// <term>KP_SALT</term>
	/// <term>
	/// pbData points to a BYTE array that specifies a new salt value to be made part of the session key. The size of the salt value varies
	/// depending on the CSP being used. Before setting this value, determine the size of the salt value by calling the CryptGetKeyParam
	/// function. Salt values are used to make the session keys more unique, which makes dictionary attacks more difficult. The salt value is
	/// zero by default for Microsoft Base Cryptographic Provider.
	/// </term>
	/// </item>
	/// <item>
	/// <term>KP_SALT_EX</term>
	/// <term>pbData points to a CRYPT_INTEGER_BLOB structure that contains the salt. For more information, see Specifying a Salt Value.</term>
	/// </item>
	/// </list>
	/// <para>
	/// If a Digital Signature Standard (DSS) key is specified by the hKey parameter, the dwParam value can also be set to one of the
	/// following values.
	/// </para>
	/// <list type="table">
	/// <listheader>
	/// <term>Value</term>
	/// <term>Meaning</term>
	/// </listheader>
	/// <item>
	/// <term>KP_G</term>
	/// <term>
	/// pbData points to the generator G from the DSS key BLOB. The data is in the form of a CRYPT_INTEGER_BLOB structure, where the pbData
	/// member is the value, and the cbData member is the length of the value. The value is expected with no header information and in
	/// little-endian form.
	/// </term>
	/// </item>
	/// <item>
	/// <term>KP_P</term>
	/// <term>
	/// pbData points to the prime modulus P of a DSS key BLOB. The data is in the form of a CRYPT_INTEGER_BLOB structure. The pbData member
	/// is the value, and the cbData member is the length of the value. The value is expected with no header information and in little-endian form.
	/// </term>
	/// </item>
	/// <item>
	/// <term>KP_Q</term>
	/// <term>
	/// pbData points to the prime Q of a DSS key BLOB. The data is in the form of a CRYPT_INTEGER_BLOB structure where the pbData member is
	/// the value, and the cbData member is the length of the value. The value is expected with no header information and in little-endian form.
	/// </term>
	/// </item>
	/// <item>
	/// <term>KP_X</term>
	/// <term>
	/// After the P, Q, and G values have been set, a call that specifies the KP_X value for dwParam and NULL for the pbData parameter can be
	/// made to the CryptSetKeyParam function. This causes the X and Y values to be generated.
	/// </term>
	/// </item>
	/// </list>
	/// <para>
	/// If a Diffie-Hellman algorithm or Digital Signature Algorithm (DSA) key is specified by hKey, the dwParam value can also be set to one
	/// of the following values.
	/// </para>
	/// <list type="table">
	/// <listheader>
	/// <term>Value</term>
	/// <term>Meaning</term>
	/// </listheader>
	/// <item>
	/// <term>KP_CMS_DH_KEY_INFO</term>
	/// <term>
	/// Sets the information for an imported Diffie-Hellman key. The pbData parameter is the address of a CMS_DH_KEY_INFO structure that
	/// contains the key information to be set.
	/// </term>
	/// </item>
	/// <item>
	/// <term>KP_PUB_PARAMS</term>
	/// <term>
	/// Sets the public parameters (P, Q, G, and so on) of a DSS or Diffie-Hellman key. The key handle for this key must be in the PREGEN
	/// state, generated with the CRYPT_PREGEN flag. The pbData parameter must be a pointer to a DATA_BLOB structure where the data in this
	/// structure is a DHPUBKEY_VER3 or DSSPUBKEY_VER3 BLOB. The function copies the public parameters from this CRYPT_INTEGER_BLOB structure
	/// to the key handle. After this call is made, the KP_X parameter value should be used with CryptSetKeyParam to create the actual
	/// private key. The KP_PUB_PARAMS parameter is used as one call rather than multiple calls with the parameter values KP_P, KP_Q, and KP_G.
	/// </term>
	/// </item>
	/// </list>
	/// <para>
	/// If a block cipher session key is specified by the hKey parameter, the dwParam value can also be set to one of the following values.
	/// </para>
	/// <list type="table">
	/// <listheader>
	/// <term>Value</term>
	/// <term>Meaning</term>
	/// </listheader>
	/// <item>
	/// <term>KP_EFFECTIVE_KEYLEN</term>
	/// <term>
	/// This value type can only be used with RC2 keys and has been added because of the implementation of the CryptSetKeyParam function in
	/// the Microsoft Enhanced Cryptographic Provider prior to Windows 2000. In the previous implementation, the RC2 keys in the Enhanced
	/// Provider were 128 bits in strength, but the effective key length used to expand keys into the key table was only 40 bits. This
	/// reduced the strength of the algorithm to 40 bits. To maintain backward compatibility, the previous implementation will remain as is.
	/// However, the effective key length can be set to be greater than 40 bits by using KP_EFFECTIVE_KEYLEN in the CryptSetKeyParam call.
	/// The effective key length is passed in the pbData parameter as a pointer to a DWORD value with the effective key length value. The
	/// minimum effective key length on the Microsoft Base Cryptographic Provider is one, and the maximum is 40. In the Microsoft Enhanced
	/// Cryptographic Provider, the minimum is one and the maximum is 1,024. The key length must be set prior to encrypting or decrypting
	/// with the key.
	/// </term>
	/// </item>
	/// <item>
	/// <term>KP_HIGHEST_VERSION</term>
	/// <term>
	/// Sets the highest Transport Layer Security (TLS) version allowed. This property only applies to SSL and TLS keys. The pbData parameter
	/// is the address of a DWORD variable that contains the highest TLS version number supported.
	/// </term>
	/// </item>
	/// <item>
	/// <term>KP_IV</term>
	/// <term>
	/// pbData points to a BYTE array that specifies the initialization vector. This array must contain BlockLength/8 elements. For example,
	/// if the block length is 64 bits, the initialization vector consists of 8 bytes. The initialization vector is set to zero by default
	/// for the Microsoft Base Cryptographic Provider.
	/// </term>
	/// </item>
	/// <item>
	/// <term>KP_KEYVAL</term>
	/// <term>
	/// Set the key value for a Data Encryption Standard (DES) key. The pbData parameter is the address of a buffer that contains the key.
	/// This buffer must be the same length as the key. This property only applies to DES keys.
	/// </term>
	/// </item>
	/// <item>
	/// <term>KP_PADDING</term>
	/// <term>
	/// Set the padding mode. The pbData parameter is a pointer to a DWORD value that receives a numeric identifier that identifies the
	/// padding method used by the cipher. This can be one of the following values. PKCS5_PADDING Specifies the PKCS 5 (sec 6.2) padding
	/// method. RANDOM_PADDING The padding uses a random number. This padding method is not supported by the Microsoft supplied CSPs.
	/// ZERO_PADDING The padding uses zeros. This padding method is not supported by the Microsoft supplied CSPs.
	/// </term>
	/// </item>
	/// <item>
	/// <term>KP_MODE</term>
	/// <term>
	/// pbData points to a DWORD value that specifies the cipher mode to be used. For a list of the defined cipher modes, see
	/// CryptGetKeyParam. The cipher mode is set to CRYPT_MODE_CBC by default for the Microsoft Base Cryptographic Provider.
	/// </term>
	/// </item>
	/// <item>
	/// <term>KP_MODE_BITS</term>
	/// <term>
	/// pbData points to a DWORD value that indicates the number of bits processed per cycle when the Output Feedback (OFB) or Cipher
	/// Feedback (CFB) cipher mode is used. The number of bits processed per cycle is set to 8 by default for the Microsoft Base
	/// Cryptographic Provider.
	/// </term>
	/// </item>
	/// </list>
	/// <para>If an RSA key is specified in the hKey parameter, the dwParam parameter value can be the following value.</para>
	/// <list type="table">
	/// <listheader>
	/// <term>Value</term>
	/// <term>Meaning</term>
	/// </listheader>
	/// <item>
	/// <term>KP_OAEP_PARAMS</term>
	/// <term>
	/// Set the Optimal Asymmetric Encryption Padding (OAEP) (PKCS #1 version 2) parameters for the key. The pbData parameter is the address
	/// of a CRYPT_DATA_BLOB structure that contains the OAEP label. This property only applies to RSA keys.
	/// </term>
	/// </item>
	/// </list>
	/// <para>Note that the following values are not used:</para>
	/// <list type="bullet">
	/// <item>
	/// <term>KP_ADMIN_PIN</term>
	/// </item>
	/// <item>
	/// <term>KP_CMS_KEY_INFO</term>
	/// </item>
	/// <item>
	/// <term>KP_INFO</term>
	/// </item>
	/// <item>
	/// <term>KP_KEYEXCHANGE_PIN</term>
	/// </item>
	/// <item>
	/// <term>KP_PRECOMP_MD5</term>
	/// </item>
	/// <item>
	/// <term>KP_PRECOMP_SHA</term>
	/// </item>
	/// <item>
	/// <term>KP_PREHASH</term>
	/// </item>
	/// <item>
	/// <term>KP_PUB_EX_LEN</term>
	/// </item>
	/// <item>
	/// <term>KP_PUB_EX_VAL</term>
	/// </item>
	/// <item>
	/// <term>KP_RA</term>
	/// </item>
	/// <item>
	/// <term>KP_RB</term>
	/// </item>
	/// <item>
	/// <term>KP_ROUNDS</term>
	/// </item>
	/// <item>
	/// <term>KP_RP</term>
	/// </item>
	/// <item>
	/// <term>KP_SIGNATURE_PIN</term>
	/// </item>
	/// <item>
	/// <term>KP_Y</term>
	/// </item>
	/// </list>
	/// </param>
	/// <param name="pbData">
	/// A pointer to a buffer initialized with the value to be set before calling <c>CryptSetKeyParam</c>. The form of this data varies
	/// depending on the value of dwParam.
	/// </param>
	/// <param name="dwFlags">
	/// Used only when dwParam is KP_ALGID. The dwFlags parameter is used to pass in flag values for the enabled key. The dwFlags parameter
	/// can hold values such as the key size and the other flag values allowed when generating the same type of key with CryptGenKey. For
	/// information about allowable flag values, see <c>CryptGenKey</c>.
	/// </param>
	/// <returns>
	/// <para>If the function succeeds, the return value is nonzero (TRUE).</para>
	/// <para>If the function fails, the return value is zero (FALSE). For extended error information, call GetLastError.</para>
	/// <para>The error codes prefaced by "NTE" are generated by the particular CSP being used. Some possible error codes follow.</para>
	/// <list type="table">
	/// <listheader>
	/// <term>Return code</term>
	/// <term>Description</term>
	/// </listheader>
	/// <item>
	/// <term>ERROR_BUSY</term>
	/// <term>The CSP context is currently being used by another process.</term>
	/// </item>
	/// <item>
	/// <term>ERROR_INVALID_HANDLE</term>
	/// <term>One of the parameters specifies a handle that is not valid.</term>
	/// </item>
	/// <item>
	/// <term>ERROR_INVALID_PARAMETER</term>
	/// <term>One of the parameters contains a value that is not valid. This is most often a pointer that is not valid.</term>
	/// </item>
	/// <item>
	/// <term>NTE_BAD_FLAGS</term>
	/// <term>The dwFlags parameter is nonzero, or the pbData buffer contains a value that is not valid.</term>
	/// </item>
	/// <item>
	/// <term>NTE_BAD_TYPE</term>
	/// <term>The dwParam parameter specifies an unknown parameter.</term>
	/// </item>
	/// <item>
	/// <term>NTE_BAD_UID</term>
	/// <term>The CSP context that was specified when the hKey key was created cannot be found.</term>
	/// </item>
	/// <item>
	/// <term>NTE_FAIL</term>
	/// <term>The function failed in some unexpected way.</term>
	/// </item>
	/// <item>
	/// <term>NTE_FIXEDPARAMETER</term>
	/// <term>
	/// Some CSPs have hard-coded P, Q, and G values. If this is the case, then using KP_P, KP_Q, and KP_G for the value of dwParam causes
	/// this error.
	/// </term>
	/// </item>
	/// </list>
	/// </returns>
	/// <remarks>
	/// <para>
	/// If the KP_Q, KP_P, or KP_X parameters are set on a PREGEN Diffie-Hellman or DSS key, the key lengths must be compatible with the key
	/// length set using the upper 16 bits of the dwFlags parameter when the key was created using CryptGenKey. If no key length was set in
	/// <c>CryptGenKey</c>, the default key length was used. This will create an error if a nondefault key length is used to set P, Q, or X.
	/// </para>
	/// <para>Examples</para>
	/// <para>
	/// For an example that uses this function, see Example C Program: Duplicating a Session Key. For more code that uses this function, see
	/// Example C Program: Setting and Getting Session Key Parameters .
	/// </para>
	/// </remarks>
	// https://docs.microsoft.com/en-us/windows/win32/api/wincrypt/nf-wincrypt-cryptsetkeyparam BOOL CryptSetKeyParam( HCRYPTKEY hKey, DWORD
	// dwParam, const BYTE *pbData, DWORD dwFlags );
	[DllImport(Lib.AdvApi32, SetLastError = true, ExactSpelling = true)]
	[PInvokeData("wincrypt.h", MSDNShortId = "e99a84a2-c23e-4251-8062-dd286ccc29b7")]
	[return: MarshalAs(UnmanagedType.Bool)]
	public static extern bool CryptSetKeyParam(HCRYPTKEY hKey, KeyParam dwParam, [In] IntPtr pbData, uint dwFlags);

	/// <summary>
	/// The Microsoft Base Cryptographic Provider does not permit setting values for key exchange or signature keys; however, custom
	/// providers can define values that can be set for its keys.
	/// </summary>
	/// <typeparam name="TIn">The type of the in.</typeparam>
	/// <param name="hKey">A handle to the key for which values are to be set.</param>
	/// <param name="dwParam">
	/// <para>The following tables contain predefined values that can be used.</para>
	/// <para>For all key types, this parameter can contain one of the following values.</para>
	/// <list type="table">
	/// <listheader>
	/// <description>Value</description>
	/// <description>Meaning</description>
	/// </listheader>
	/// <item>
	/// <description><c>KP_ALGID</c></description>
	/// <description>
	/// <c>pbData</c> points to an appropriate ALG_ID. This is used when exchanging session keys with the Microsoft Base Digital Signature
	/// Standard (DSS), Diffie-Hellman Cryptographic Provider, or compatible CSPs. After a key is agreed upon with the CryptImportKey
	/// function, the session key is enabled for use by setting its algorithm type.
	/// </description>
	/// </item>
	/// <item>
	/// <description><c>KP_CERTIFICATE</c></description>
	/// <description>
	/// <c>pbData</c> is the address of a buffer that contains the X.509 certificate that has been encoded by using Distinguished Encoding
	/// Rules (DER). The public key in the certificate must match the corresponding signature or exchange key.
	/// </description>
	/// </item>
	/// <item>
	/// <description><c>KP_PERMISSIONS</c></description>
	/// <description>
	/// <c>pbData</c> points to a <c>DWORD</c> value that specifies zero or more permission flags. For a description of these flags, see CryptGetKeyParam.
	/// </description>
	/// </item>
	/// <item>
	/// <description><c>KP_SALT</c></description>
	/// <description>
	/// <c>pbData</c> points to a <c>BYTE</c> array that specifies a new salt value to be made part of the session key. The size of the salt
	/// value varies depending on the CSP being used. Before setting this value, determine the size of the salt value by calling the
	/// CryptGetKeyParam function. Salt values are used to make the session keys more unique, which makes dictionary attacks more difficult.
	/// The salt value is zero by default for Microsoft Base Cryptographic Provider.
	/// </description>
	/// </item>
	/// <item>
	/// <description><c>KP_SALT_EX</c></description>
	/// <description>
	/// <c>pbData</c> points to a CRYPT_INTEGER_BLOB structure that contains the salt. For more information, see Specifying a Salt Value.
	/// </description>
	/// </item>
	/// </list>
	/// <para>Â</para>
	/// <para>
	/// If a Digital Signature Standard (DSS) key is specified by the <c>hKey</c> parameter, the <c>dwParam</c> value can also be set to one
	/// of the following values.
	/// </para>
	/// <list type="table">
	/// <listheader>
	/// <description>Value</description>
	/// <description>Meaning</description>
	/// </listheader>
	/// <item>
	/// <description><c>KP_G</c></description>
	/// <description>
	/// <c>pbData</c> points to the generator G from the DSS key BLOB. The data is in the form of a CRYPT_INTEGER_BLOB structure, where the
	/// <c>pbData</c> member is the value, and the <c>cbData</c> member is the length of the value. The value is expected with no header
	/// information and in little-endian form.
	/// </description>
	/// </item>
	/// <item>
	/// <description><c>KP_P</c></description>
	/// <description>
	/// <c>pbData</c> points to the prime modulus P of a DSS key BLOB. The data is in the form of a CRYPT_INTEGER_BLOB structure. The
	/// <c>pbData</c> member is the value, and the <c>cbData</c> member is the length of the value. The value is expected with no header
	/// information and in little-endian form.
	/// </description>
	/// </item>
	/// <item>
	/// <description><c>KP_Q</c></description>
	/// <description>
	/// <c>pbData</c> points to the prime Q of a DSS key BLOB. The data is in the form of a CRYPT_INTEGER_BLOB structure where the
	/// <c>pbData</c> member is the value, and the <c>cbData</c> member is the length of the value. The value is expected with no header
	/// information and in little-endian form.
	/// </description>
	/// </item>
	/// <item>
	/// <description><c>KP_X</c></description>
	/// <description>
	/// After the P, Q, and G values have been set, a call that specifies the KP_X value for <c>dwParam</c> and <c>NULL</c> for the
	/// <c>pbData</c> parameter can be made to the <c>CryptSetKeyParam</c> function. This causes the X and Y values to be generated.
	/// </description>
	/// </item>
	/// </list>
	/// <para>Â</para>
	/// <para>
	/// If a Diffie-Hellman algorithm or Digital Signature Algorithm (DSA) key is specified by <c>hKey</c>, the <c>dwParam</c> value can also
	/// be set to one of the following values.
	/// </para>
	/// <list type="table">
	/// <listheader>
	/// <description>Value</description>
	/// <description>Meaning</description>
	/// </listheader>
	/// <item>
	/// <description><c>KP_CMS_DH_KEY_INFO</c></description>
	/// <description>
	/// Sets the information for an imported Diffie-Hellman key. The <c>pbData</c> parameter is the address of a CMS_DH_KEY_INFO structure
	/// that contains the key information to be set.
	/// </description>
	/// </item>
	/// <item>
	/// <description><c>KP_PUB_PARAMS</c></description>
	/// <description>
	/// Sets the public parameters (P, Q, G, and so on) of a DSS or Diffie-Hellman key. The key handle for this key must be in the PREGEN
	/// state, generated with the CRYPT_PREGEN flag. The <c>pbData</c> parameter must be a pointer to a DATA_BLOB structure where the data in
	/// this structure is a DHPUBKEY_VER3 or DSSPUBKEY_VER3 BLOB. The function copies the public parameters from this
	/// <c>CRYPT_INTEGER_BLOB</c> structure to the key handle. After this call is made, the KP_X parameter value should be used with
	/// <c>CryptSetKeyParam</c> to create the actual private key. The KP_PUB_PARAMS parameter is used as one call rather than multiple calls
	/// with the parameter values KP_P, KP_Q, and KP_G.
	/// </description>
	/// </item>
	/// </list>
	/// <para>Â</para>
	/// <para>
	/// If a block cipher session key is specified by the <c>hKey</c> parameter, the <c>dwParam</c> value can also be set to one of the
	/// following values.
	/// </para>
	/// <list type="table">
	/// <listheader>
	/// <description>Value</description>
	/// <description>Meaning</description>
	/// </listheader>
	/// <item>
	/// <description><c>KP_EFFECTIVE_KEYLEN</c></description>
	/// <description>
	/// This value type can only be used with RC2 keys and has been added because of the implementation of the <c>CryptSetKeyParam</c>
	/// function in the Microsoft Enhanced Cryptographic Provider prior to WindowsÂ 2000. In the previous implementation, the RC2 keys in the
	/// Enhanced Provider were 128 bits in strength, but the effective key length used to expand keys into the key table was only 40 bits.
	/// This reduced the strength of the algorithm to 40 bits. To maintain backward compatibility, the previous implementation will remain as
	/// is. However, the effective key length can be set to be greater than 40 bits by using KP_EFFECTIVE_KEYLEN in the
	/// <c>CryptSetKeyParam</c> call. The effective key length is passed in the <c>pbData</c> parameter as a pointer to a <c>DWORD</c> value
	/// with the effective key length value. The minimum effective key length on the Microsoft Base Cryptographic Provider is one, and the
	/// maximum is 40. In the Microsoft Enhanced Cryptographic Provider, the minimum is one and the maximum is 1,024. The key length must be
	/// set prior to encrypting or decrypting with the key.
	/// </description>
	/// </item>
	/// <item>
	/// <description><c>KP_HIGHEST_VERSION</c></description>
	/// <description>
	/// Sets the highest Transport Layer Security (TLS) version allowed. This property only applies to SSL and TLS keys. The <c>pbData</c>
	/// parameter is the address of a <c>DWORD</c> variable that contains the highest TLS version number supported.
	/// </description>
	/// </item>
	/// <item>
	/// <description><c>KP_IV</c></description>
	/// <description>
	/// <c>pbData</c> points to a <c>BYTE</c> array that specifies the initialization vector. This array must contain <c>BlockLength</c>/8
	/// elements. For example, if the block length is 64 bits, the initialization vector consists of 8 bytes. The initialization vector is
	/// set to zero by default for the Microsoft Base Cryptographic Provider.
	/// </description>
	/// </item>
	/// <item>
	/// <description><c>KP_KEYVAL</c></description>
	/// <description>
	/// Set the key value for a Data Encryption Standard (DES) key. The <c>pbData</c> parameter is the address of a buffer that contains the
	/// key. This buffer must be the same length as the key. This property only applies to DES keys.
	/// </description>
	/// </item>
	/// <item>
	/// <description><c>KP_PADDING</c></description>
	/// <description>
	/// Set the padding mode. The <c>pbData</c> parameter is a pointer to a <c>DWORD</c> value that receives a numeric identifier that
	/// identifies the padding method used by the cipher. This can be one of the following values. PKCS5_PADDING Specifies the PKCS 5 (sec
	/// 6.2) padding method. RANDOM_PADDING The padding uses a random number. This padding method is not supported by the Microsoft supplied
	/// CSPs. ZERO_PADDING The padding uses zeros. This padding method is not supported by the Microsoft supplied CSPs.
	/// </description>
	/// </item>
	/// <item>
	/// <description><c>KP_MODE</c></description>
	/// <description>
	/// <c>pbData</c> points to a <c>DWORD</c> value that specifies the cipher mode to be used. For a list of the defined cipher modes, see
	/// CryptGetKeyParam. The cipher mode is set to CRYPT_MODE_CBC by default for the Microsoft Base Cryptographic Provider.
	/// </description>
	/// </item>
	/// <item>
	/// <description><c>KP_MODE_BITS</c></description>
	/// <description>
	/// <c>pbData</c> points to a <c>DWORD</c> value that indicates the number of bits processed per cycle when the Output Feedback (OFB) or
	/// Cipher Feedback (CFB) cipher mode is used. The number of bits processed per cycle is set to 8 by default for the Microsoft Base
	/// Cryptographic Provider.
	/// </description>
	/// </item>
	/// </list>
	/// <para>Â</para>
	/// <para>If an RSA key is specified in the <c>hKey</c> parameter, the <c>dwParam</c> parameter value can be the following value.</para>
	/// <list type="table">
	/// <listheader>
	/// <description>Value</description>
	/// <description>Meaning</description>
	/// </listheader>
	/// <item>
	/// <description><c>KP_OAEP_PARAMS</c></description>
	/// <description>
	/// Set the Optimal Asymmetric Encryption Padding (OAEP) (PKCS #1 version 2) parameters for the key. The <c>pbData</c> parameter is the
	/// address of a CRYPT_DATA_BLOB structure that contains the OAEP label. This property only applies to RSA keys.
	/// </description>
	/// </item>
	/// </list>
	/// <para>Â</para>
	/// <para>Note that the following values are not used:</para>
	/// <list type="bullet">
	/// <item>
	/// <description>KP_ADMIN_PIN</description>
	/// </item>
	/// <item>
	/// <description>KP_CMS_KEY_INFO</description>
	/// </item>
	/// <item>
	/// <description>KP_INFO</description>
	/// </item>
	/// <item>
	/// <description>KP_KEYEXCHANGE_PIN</description>
	/// </item>
	/// <item>
	/// <description>KP_PRECOMP_MD5</description>
	/// </item>
	/// <item>
	/// <description>KP_PRECOMP_SHA</description>
	/// </item>
	/// <item>
	/// <description>KP_PREHASH</description>
	/// </item>
	/// <item>
	/// <description>KP_PUB_EX_LEN</description>
	/// </item>
	/// <item>
	/// <description>KP_PUB_EX_VAL</description>
	/// </item>
	/// <item>
	/// <description>KP_RA</description>
	/// </item>
	/// <item>
	/// <description>KP_RB</description>
	/// </item>
	/// <item>
	/// <description>KP_ROUNDS</description>
	/// </item>
	/// <item>
	/// <description>KP_RP</description>
	/// </item>
	/// <item>
	/// <description>KP_SIGNATURE_PIN</description>
	/// </item>
	/// <item>
	/// <description>KP_Y</description>
	/// </item>
	/// </list>
	/// </param>
	/// <param name="pbData">
	/// A pointer to a buffer initialized with the value to be set before calling <c>CryptSetKeyParam</c>. The form of this data varies
	/// depending on the value of <c>dwParam</c>.
	/// </param>
	/// <param name="dwFlags">
	/// Used only when <c>dwParam</c> is KP_ALGID. The <c>dwFlags</c> parameter is used to pass in flag values for the enabled key. The
	/// <c>dwFlags</c> parameter can hold values such as the key size and the other flag values allowed when generating the same type of key
	/// with CryptGenKey. For information about allowable flag values, see <c>CryptGenKey</c>.
	/// </param>
	/// <returns>
	/// <para>If the function succeeds, the return value is nonzero (TRUE).</para>
	/// <para>If the function fails, the return value is zero (FALSE). For extended error information, call GetLastError.</para>
	/// <para>The error codes prefaced by "NTE" are generated by the particular CSP being used. Some possible error codes follow.</para>
	/// <list type="table">
	/// <listheader>
	/// <description>Return code</description>
	/// <description>Description</description>
	/// </listheader>
	/// <item>
	/// <description><c>ERROR_BUSY</c></description>
	/// <description>The CSP context is currently being used by another process.</description>
	/// </item>
	/// <item>
	/// <description><c>ERROR_INVALID_HANDLE</c></description>
	/// <description>One of the parameters specifies a handle that is not valid.</description>
	/// </item>
	/// <item>
	/// <description><c>ERROR_INVALID_PARAMETER</c></description>
	/// <description>One of the parameters contains a value that is not valid. This is most often a pointer that is not valid.</description>
	/// </item>
	/// <item>
	/// <description><c>NTE_BAD_FLAGS</c></description>
	/// <description>The <c>dwFlags</c> parameter is nonzero, or the <c>pbData</c> buffer contains a value that is not valid.</description>
	/// </item>
	/// <item>
	/// <description><c>NTE_BAD_TYPE</c></description>
	/// <description>The <c>dwParam</c> parameter specifies an unknown parameter.</description>
	/// </item>
	/// <item>
	/// <description><c>NTE_BAD_UID</c></description>
	/// <description>The CSP context that was specified when the <c>hKey</c> key was created cannot be found.</description>
	/// </item>
	/// <item>
	/// <description><c>NTE_FAIL</c></description>
	/// <description>The function failed in some unexpected way.</description>
	/// </item>
	/// <item>
	/// <description><c>NTE_FIXEDPARAMETER</c></description>
	/// <description>
	/// Some CSPs have hard-coded P, Q, and G values. If this is the case, then using KP_P, KP_Q, and KP_G for the value of <c>dwParam</c>
	/// causes this error.
	/// </description>
	/// </item>
	/// </list>
	/// </returns>
	/// <remarks>
	/// <para>
	/// If the KP_Q, KP_P, or KP_X parameters are set on a PREGEN Diffie-Hellman or DSS key, the key lengths must be compatible with the key
	/// length set using the upper 16 bits of the <c>dwFlags</c> parameter when the key was created using CryptGenKey. If no key length was
	/// set in <c>CryptGenKey</c>, the default key length was used. This will create an error if a nondefault key length is used to set P, Q,
	/// or X.
	/// </para>
	/// <para>Examples</para>
	/// <para>
	/// For an example that uses this function, see Example C Program: Duplicating a Session Key. For more code that uses this function, see
	/// Example C Program: Setting and Getting Session Key Parameters .
	/// </para>
	/// </remarks>
	// https://learn.microsoft.com/en-us/windows/win32/api/wincrypt/nf-wincrypt-cryptsetkeyparam BOOL CryptSetKeyParam( [in] HCRYPTKEY hKey,
	// [in] DWORD dwParam, [in] const BYTE *pbData, [in] DWORD dwFlags );
	[PInvokeData("wincrypt.h", MSDNShortId = "NF:wincrypt.CryptSetKeyParam")]
	public static bool CryptSetKeyParam<TIn>(HCRYPTKEY hKey, KeyParam dwParam, TIn pbData, uint dwFlags) => CryptSetValue(CryptSetKeyParam, hKey, dwParam, pbData, dwFlags);

	/// <summary>
	/// <para>The CryptSetProvider function specifies the current user's default cryptographic service provider (CSP).</para>
	/// <para>
	/// If a current user's default provider is set, that default provider is acquired by any call by that user to CryptAcquireContext
	/// specifying a dwProvType provider type but not a CSP name.
	/// </para>
	/// <para>An enhanced version of this function, CryptSetProviderEx, is also available.</para>
	/// <para><c>Note</c> Typical applications do not use this function. It is intended for use solely by administrative applications.</para>
	/// </summary>
	/// <param name="pszProvName">
	/// Name of the new default CSP. The named CSP must be installed on the computer. For a list of available cryptographic providers, see
	/// Cryptographic Provider Names.
	/// </param>
	/// <param name="dwProvType">Provider type of the CSP specified by pszProvName.</param>
	/// <returns>
	/// <para>If the function succeeds, the return value is nonzero (TRUE).</para>
	/// <para>
	/// If the function fails, the return value is zero (FALSE). For extended error information, call GetLastError. Some possible error codes
	/// are listed in the following table.
	/// </para>
	/// <list type="table">
	/// <listheader>
	/// <term>Return code</term>
	/// <term>Description</term>
	/// </listheader>
	/// <item>
	/// <term>ERROR_INVALID_HANDLE</term>
	/// <term>One of the parameters specifies a handle that is not valid.</term>
	/// </item>
	/// <item>
	/// <term>ERROR_INVALID_PARAMETER</term>
	/// <term>One of the parameters contains a value that is not valid. This is most often a pointer that is not valid.</term>
	/// </item>
	/// <item>
	/// <term>ERROR_NOT_ENOUGH_MEMORY</term>
	/// <term>The operating system ran out of memory during the operation.</term>
	/// </item>
	/// </list>
	/// <para>Errors can also be propagated from internal calls to RegCreateKeyEx and RegSetValueEx.</para>
	/// </returns>
	/// <remarks>
	/// <para>
	/// Typical applications do not specify a CSP name when calling CryptAcquireContext; however, an application does have the option of
	/// selecting a specific CSP. This gives a user the freedom to select a CSP with an appropriate level of security.
	/// </para>
	/// <para>
	/// Since calling <c>CryptSetProvider</c> determines the CSP of a specified type used by all applications that run from that point on,
	/// this function must not be called without users' consent.
	/// </para>
	/// </remarks>
	// https://docs.microsoft.com/en-us/windows/win32/api/wincrypt/nf-wincrypt-cryptsetprovidera BOOL CryptSetProviderA( LPCSTR pszProvName,
	// DWORD dwProvType );
	[DllImport(Lib.AdvApi32, SetLastError = true, CharSet = CharSet.Auto)]
	[PInvokeData("wincrypt.h", MSDNShortId = "44023a0c-3fb4-4746-a676-1671c3ad901b")]
	[return: MarshalAs(UnmanagedType.Bool)]
	public static extern bool CryptSetProvider([MarshalAs(UnmanagedType.LPTStr)] string pszProvName, uint dwProvType);

	/// <summary>
	/// <para>
	/// The CryptSetProviderEx function specifies the default cryptographic service provider (CSP) of a specified provider type for the local
	/// computer or current user.
	/// </para>
	/// <note>Typical applications do not use this function. It is intended for use solely by administrative applications.</note>
	/// </summary>
	/// <param name="pszProvName">
	/// The name of the new default CSP. This must be a CSP installed on the computer. For a list of available cryptographic providers, see
	/// Cryptographic Provider Names.
	/// </param>
	/// <param name="dwProvType">The provider type of the CSP specified by pszProvName.</param>
	/// <param name="pdwReserved">This parameter is reserved for future use and must be <c>NULL</c>.</param>
	/// <param name="dwFlags">
	/// <para>The following flag values are defined.</para>
	/// <list type="table">
	/// <listheader>
	/// <term>Value</term>
	/// <term>Meaning</term>
	/// </listheader>
	/// <item>
	/// <term>CRYPT_DELETE_DEFAULT 0x00000004</term>
	/// <term>Can be used in conjunction with CRYPT_MACHINE_DEFAULT or CRYPT_USER_DEFAULT to delete the default.</term>
	/// </item>
	/// <item>
	/// <term>CRYPT_USER_DEFAULT 0x00000002</term>
	/// <term>Causes the user-context default CSP of the specified type to be set.</term>
	/// </item>
	/// <item>
	/// <term>CRYPT_MACHINE_DEFAULT 0x00000001</term>
	/// <term>Causes the computer default CSP of the specified type to be set.</term>
	/// </item>
	/// </list>
	/// </param>
	/// <returns>
	/// <para>If the function succeeds, the return value is nonzero ( <c>TRUE</c>).</para>
	/// <para>
	/// If the function fails, the return value is zero ( <c>FALSE</c>). For extended error information, call GetLastError. Possible error
	/// codes include those shown in the following table.
	/// </para>
	/// <list type="table">
	/// <listheader>
	/// <term>Return code</term>
	/// <term>Description</term>
	/// </listheader>
	/// <item>
	/// <term>ERROR_INVALID_PARAMETER</term>
	/// <term>One of the parameters contains a value that is not valid. This is most often a pointer that is not valid.</term>
	/// </item>
	/// <item>
	/// <term>ERROR_NOT_ENOUGH_MEMORY</term>
	/// <term>The operating system ran out of memory.</term>
	/// </item>
	/// </list>
	/// </returns>
	/// <remarks>
	/// Most applications do not specify a CSP name when calling the CryptAcquireContext function; however, an application can specify a CSP
	/// name and thereby select a CSP with an appropriate level of security. Because calls to <c>CryptSetProviderEx</c> determine the CSP of
	/// a specified type used by all applications from that point on, <c>CryptSetProviderEx</c> must never be called without a user's consent.
	/// </remarks>
	// https://docs.microsoft.com/en-us/windows/win32/api/wincrypt/nf-wincrypt-cryptsetproviderexa BOOL CryptSetProviderExA( LPCSTR
	// pszProvName, DWORD dwProvType, DWORD *pdwReserved, DWORD dwFlags );
	[DllImport(Lib.AdvApi32, SetLastError = true, CharSet = CharSet.Auto)]
	[PInvokeData("wincrypt.h", MSDNShortId = "5f0c2724-5144-4a22-a7da-2a5162f06f5d")]
	[return: MarshalAs(UnmanagedType.Bool)]
	public static extern bool CryptSetProviderEx([MarshalAs(UnmanagedType.LPTStr)] string pszProvName, uint dwProvType, [Optional] IntPtr pdwReserved, CryptProviderFlags dwFlags);

	/// <summary>
	/// The CryptSetProvParam function customizes the operations of a cryptographic service provider (CSP). This function is commonly used to
	/// set a security descriptor on the key container associated with a CSP to control access to the private keys in that key container.
	/// </summary>
	/// <param name="hProv">
	/// The handle of a CSP for which to set values. This handle must have already been created by using the CryptAcquireContext function.
	/// </param>
	/// <param name="dwParam">
	/// <para>Specifies the parameter to set. This can be one of the following values.</para>
	/// <list type="table">
	/// <listheader>
	/// <term>Value</term>
	/// <term>Meaning</term>
	/// </listheader>
	/// <item>
	/// <term>PP_CLIENT_HWND 1 (0x1)</term>
	/// <term>
	/// Set the window handle that the provider uses as the parent of any dialog boxes it creates. pbData contains a pointer to an HWND that
	/// contains the parent window handle. This parameter must be set before calling CryptAcquireContext because many CSPs will display a
	/// user interface when CryptAcquireContext is called. You can pass NULL for the hProv parameter to set this window handle for all
	/// cryptographic contexts subsequently acquired within this process.
	/// </term>
	/// </item>
	/// <item>
	/// <term>PP_DELETEKEY 24 (0x18)</term>
	/// <term>
	/// Delete the ephemeral key associated with a hash, encryption, or verification context. This will free memory and clear registry
	/// settings associated with the key.
	/// </term>
	/// </item>
	/// <item>
	/// <term>PP_KEYEXCHANGE_ALG</term>
	/// <term>This constant is not used.</term>
	/// </item>
	/// <item>
	/// <term>PP_KEYEXCHANGE_PIN 32 (0x20)</term>
	/// <term>Specifies that the key exchange PIN is contained in pbData. The PIN is represented as a null-terminated ASCII string.</term>
	/// </item>
	/// <item>
	/// <term>PP_KEYEXCHANGE_KEYSIZE</term>
	/// <term>This constant is not used.</term>
	/// </item>
	/// <item>
	/// <term>PP_KEYSET_SEC_DESCR 8 (0x8)</term>
	/// <term>
	/// Sets the security descriptor on the key storage container. The pbData parameter is the address of a SECURITY_DESCRIPTOR structure
	/// that contains the new security descriptor for the key storage container.
	/// </term>
	/// </item>
	/// <item>
	/// <term>PP_PIN_PROMPT_STRING 44 (0x2C)</term>
	/// <term>
	/// Sets an alternate prompt string to display to the user when the user's PIN is requested. The pbData parameter is a pointer to a
	/// null-terminated Unicode string.
	/// </term>
	/// </item>
	/// <item>
	/// <term>PP_ROOT_CERTSTORE 46 (0x2E)</term>
	/// <term>
	/// Sets the root certificate store for the smart card. The provider will copy the root certificates from this store onto the smart card.
	/// The pbData parameter is an HCERTSTORE variable that contains the handle of the new certificate store. The provider will copy the
	/// certificates from the store during this call, so it is safe to close this store after this function is called. Windows XP and Windows
	/// Server 2003: This parameter is not supported.
	/// </term>
	/// </item>
	/// <item>
	/// <term>PP_SIGNATURE_ALG</term>
	/// <term>This constant is not used.</term>
	/// </item>
	/// <item>
	/// <term>PP_SIGNATURE_PIN 33 (0x21)</term>
	/// <term>Specifies the signature PIN. The pbData parameter is a null-terminated ASCII string that represents the PIN.</term>
	/// </item>
	/// <item>
	/// <term>PP_SIGNATURE_KEYSIZE</term>
	/// <term>This constant is not used.</term>
	/// </item>
	/// <item>
	/// <term>PP_UI_PROMPT 21 (0x15)</term>
	/// <term>
	/// For a smart card provider, sets the search string that is displayed to the user as a prompt to insert the smart card. This string is
	/// passed as the lpstrSearchDesc member of the OPENCARDNAME_EX structure that is passed to the SCardUIDlgSelectCard function. This
	/// string is used for the lifetime of the calling process. The pbData parameter is a pointer to a null-terminated Unicode string.
	/// </term>
	/// </item>
	/// <item>
	/// <term>PP_USE_HARDWARE_RNG 38 (0x26)</term>
	/// <term>
	/// Specifies that the CSP must exclusively use the hardware random number generator (RNG). When PP_USE_HARDWARE_RNG is set, random
	/// values are taken exclusively from the hardware RNG and no other sources are used. If a hardware RNG is supported by the CSP and it
	/// can be exclusively used, the function succeeds and returns TRUE; otherwise, the function fails and returns FALSE. The pbData
	/// parameter must be NULL and dwFlags must be zero when using this value. None of the Microsoft CSPs currently support using a hardware RNG.
	/// </term>
	/// </item>
	/// <item>
	/// <term>PP_USER_CERTSTORE 42 (0x2A)</term>
	/// <term>
	/// Specifies the user certificate store for the smart card. This certificate store contains all of the user certificates that are stored
	/// on the smart card. The certificates in this store are encoded by using PKCS_7_ASN_ENCODING or X509_ASN_ENCODING encoding and should
	/// contain the CERT_KEY_PROV_INFO_PROP_ID property. The pbData parameter is an HCERTSTORE variable that receives the handle of an
	/// in-memory certificate store. When this handle is no longer needed, the caller must close it by using the CertCloseStore function.
	/// Windows Server 2003 and Windows XP: This parameter is not supported.
	/// </term>
	/// </item>
	/// <item>
	/// <term>PP_SECURE_KEYEXCHANGE_PIN 47 (0x2F)</term>
	/// <term>Specifies that an encrypted key exchange PIN is contained in pbData. The pbData parameter contains a DATA_BLOB.</term>
	/// </item>
	/// <item>
	/// <term>PP_SECURE_SIGNATURE_PIN 48 (0x30)</term>
	/// <term>Specifies that an encrypted signature PIN is contained in pbData. The pbData parameter contains a DATA_BLOB.</term>
	/// </item>
	/// <item>
	/// <term>PP_SMARTCARD_READER 43 (0x2B)</term>
	/// <term>
	/// Specifies the name of the smart card reader. The pbData parameter is the address of an ANSI character array that contains a
	/// null-terminated ANSI string that contains the name of the smart card reader. Windows Server 2003 and Windows XP: This parameter is
	/// not supported.
	/// </term>
	/// </item>
	/// <item>
	/// <term>PP_SMARTCARD_GUID 45 (0x2D)</term>
	/// <term>
	/// Specifies the identifier of the smart card. The pbData parameter is the address of a GUID structure that contains the identifier of
	/// the smart card. Windows Server 2003 and Windows XP: This parameter is not supported.
	/// </term>
	/// </item>
	/// </list>
	/// </param>
	/// <param name="pbData">
	/// A pointer to a data buffer that contains the value to be set as a provider parameter. The form of this data varies depending on the
	/// dwParam value. If dwParam contains <c>PP_USE_HARDWARE_RNG</c>, this parameter must be <c>NULL</c>.
	/// </param>
	/// <param name="dwFlags">
	/// <para>
	/// If dwParam contains <c>PP_KEYSET_SEC_DESCR</c>, dwFlags contains the <c>SECURITY_INFORMATION</c> applicable bit flags, as defined in
	/// the Platform SDK. Key-container security is handled by using SetFileSecurity and GetFileSecurity.
	/// </para>
	/// <para>These bit flags can be combined by using a bitwise- <c>OR</c> operation. For more information, see CryptGetProvParam.</para>
	/// <para>If dwParam is <c>PP_USE_HARDWARE_RNG</c> or <c>PP_DELETEKEY</c>, dwFlags must be set to zero.</para>
	/// </param>
	/// <returns>
	/// <para>If the function succeeds, the return value is nonzero ( <c>TRUE</c>).</para>
	/// <para>If the function fails, the return value is zero ( <c>FALSE</c>). For extended error information, call GetLastError.</para>
	/// <para>The error codes prefaced by "NTE" are generated by the particular CSP being used. Error codes include the following.</para>
	/// <list type="table">
	/// <listheader>
	/// <term>Return code</term>
	/// <term>Description</term>
	/// </listheader>
	/// <item>
	/// <term>ERROR_BUSY</term>
	/// <term>The CSP context is currently being used by another process.</term>
	/// </item>
	/// <item>
	/// <term>ERROR_INVALID_HANDLE</term>
	/// <term>One of the parameters specifies a handle that is not valid.</term>
	/// </item>
	/// <item>
	/// <term>ERROR_INVALID_PARAMETER</term>
	/// <term>One of the parameters contains a value that is not valid. This is most often a pointer that is not valid.</term>
	/// </item>
	/// <item>
	/// <term>NTE_BAD_FLAGS</term>
	/// <term>The dwFlags parameter is nonzero or the pbData buffer contains a value that is not valid.</term>
	/// </item>
	/// <item>
	/// <term>NTE_BAD_TYPE</term>
	/// <term>The dwParam parameter specifies an unknown parameter.</term>
	/// </item>
	/// <item>
	/// <term>NTE_BAD_UID</term>
	/// <term>The CSP context that was specified when the hKey key was created cannot be found.</term>
	/// </item>
	/// <item>
	/// <term>NTE_FAIL</term>
	/// <term>The function failed in some unexpected way.</term>
	/// </item>
	/// </list>
	/// </returns>
	// https://docs.microsoft.com/en-us/windows/win32/api/wincrypt/nf-wincrypt-cryptsetprovparam BOOL CryptSetProvParam( HCRYPTPROV hProv,
	// DWORD dwParam, const BYTE *pbData, DWORD dwFlags );
	[DllImport(Lib.AdvApi32, SetLastError = true, ExactSpelling = true)]
	[PInvokeData("wincrypt.h", MSDNShortId = "98306a7b-b218-4eb4-99f0-0b5bcc632a13")]
	[return: MarshalAs(UnmanagedType.Bool)]
	public static extern bool CryptSetProvParam(HCRYPTPROV hProv, ProvParam dwParam, [In] IntPtr pbData, uint dwFlags);

	/// <summary>
	/// <para>The handle of a CSP for which to set values. This handle must have already been created by using the CryptAcquireContext function.</para>
	/// <para>Specifies the parameter to set. This can be one of the following values.</para>
	/// <list type="table">
	/// <listheader>
	/// <description>Value</description>
	/// <description>Meaning</description>
	/// </listheader>
	/// <item>
	/// <description><c>PP_CLIENT_HWND</c> 1 (0x1)</description>
	/// <description>
	/// Set the window handle that the provider uses as the parent of any dialog boxes it creates. <c>pbData</c> contains a pointer to an
	/// <c>HWND</c> that contains the parent window handle. This parameter must be set before calling CryptAcquireContext because many CSPs
	/// will display a user interface when <c>CryptAcquireContext</c> is called. You can pass <c>NULL</c> for the <c>hProv</c> parameter to
	/// set this window handle for all cryptographic contexts subsequently acquired within this process.
	/// </description>
	/// </item>
	/// <item>
	/// <description><c>PP_DELETEKEY</c> 24 (0x18)</description>
	/// <description>
	/// Delete the ephemeral key associated with a hash, encryption, or verification context. This will free memory and clear registry
	/// settings associated with the key.
	/// </description>
	/// </item>
	/// <item>
	/// <description><c>PP_KEYEXCHANGE_ALG</c></description>
	/// <description>This constant is not used.</description>
	/// </item>
	/// <item>
	/// <description><c>PP_KEYEXCHANGE_PIN</c> 32 (0x20)</description>
	/// <description>
	/// Specifies that the key exchange PIN is contained in <c>pbData</c>. The PIN is represented as a null-terminated ASCII string.
	/// </description>
	/// </item>
	/// <item>
	/// <description><c>PP_KEYEXCHANGE_KEYSIZE</c></description>
	/// <description>This constant is not used.</description>
	/// </item>
	/// <item>
	/// <description><c>PP_KEYSET_SEC_DESCR</c> 8 (0x8)</description>
	/// <description>
	/// Sets the security descriptor on the key storage container. The <c>pbData</c> parameter is the address of a SECURITY_DESCRIPTOR
	/// structure that contains the new security descriptor for the key storage container.
	/// </description>
	/// </item>
	/// <item>
	/// <description><c>PP_PIN_PROMPT_STRING</c> 44 (0x2C)</description>
	/// <description>
	/// Sets an alternate prompt string to display to the user when the user's PIN is requested. The <c>pbData</c> parameter is a pointer to
	/// a null-terminated Unicode string.
	/// </description>
	/// </item>
	/// <item>
	/// <description><c>PP_ROOT_CERTSTORE</c> 46 (0x2E)</description>
	/// <description>
	/// Sets the root certificate store for the smart card. The provider will copy the root certificates from this store onto the smart card.
	/// The <c>pbData</c> parameter is an <c>HCERTSTORE</c> variable that contains the handle of the new certificate store. The provider will
	/// copy the certificates from the store during this call, so it is safe to close this store after this function is called. <c>WindowsÂ
	/// XP and Windows ServerÂ 2003:Â Â</c> This parameter is not supported.
	/// </description>
	/// </item>
	/// <item>
	/// <description><c>PP_SIGNATURE_ALG</c></description>
	/// <description>This constant is not used.</description>
	/// </item>
	/// <item>
	/// <description><c>PP_SIGNATURE_PIN</c> 33 (0x21)</description>
	/// <description>
	/// Specifies the signature PIN. The <c>pbData</c> parameter is a null-terminated ASCII string that represents the PIN.
	/// </description>
	/// </item>
	/// <item>
	/// <description><c>PP_SIGNATURE_KEYSIZE</c></description>
	/// <description>This constant is not used.</description>
	/// </item>
	/// <item>
	/// <description><c>PP_UI_PROMPT</c> 21 (0x15)</description>
	/// <description>
	/// For a smart card provider, sets the search string that is displayed to the user as a prompt to insert the smart card. This string is
	/// passed as the <c>lpstrSearchDesc</c> member of the OPENCARDNAME_EX structure that is passed to the SCardUIDlgSelectCard function.
	/// This string is used for the lifetime of the calling process. The <c>pbData</c> parameter is a pointer to a null-terminated Unicode string.
	/// </description>
	/// </item>
	/// <item>
	/// <description><c>PP_USE_HARDWARE_RNG</c> 38 (0x26)</description>
	/// <description>
	/// Specifies that the CSP must exclusively use the hardware random number generator (RNG). When <c>PP_USE_HARDWARE_RNG</c> is set,
	/// random values are taken exclusively from the hardware RNG and no other sources are used. If a hardware RNG is supported by the CSP
	/// and it can be exclusively used, the function succeeds and returns <c>TRUE</c>; otherwise, the function fails and returns
	/// <c>FALSE</c>. The <c>pbData</c> parameter must be <c>NULL</c> and <c>dwFlags</c> must be zero when using this value. None of the
	/// Microsoft CSPs currently support using a hardware RNG.
	/// </description>
	/// </item>
	/// <item>
	/// <description><c>PP_USER_CERTSTORE</c> 42 (0x2A)</description>
	/// <description>
	/// Specifies the user certificate store for the smart card. This certificate store contains all of the user certificates that are stored
	/// on the smart card. The certificates in this store are encoded by using PKCS_7_ASN_ENCODING or X509_ASN_ENCODING encoding and should
	/// contain the <c>CERT_KEY_PROV_INFO_PROP_ID</c> property. The <c>pbData</c> parameter is an <c>HCERTSTORE</c> variable that receives
	/// the handle of an in-memory certificate store. When this handle is no longer needed, the caller must close it by using the
	/// CertCloseStore function. <c>Windows ServerÂ 2003 and WindowsÂ XP:Â Â</c> This parameter is not supported.
	/// </description>
	/// </item>
	/// <item>
	/// <description><c>PP_SECURE_KEYEXCHANGE_PIN</c> 47 (0x2F)</description>
	/// <description>
	/// Specifies that an encrypted key exchange PIN is contained in <c>pbData</c>. The <c>pbData</c> parameter contains a DATA_BLOB.
	/// </description>
	/// </item>
	/// <item>
	/// <description><c>PP_SECURE_SIGNATURE_PIN</c> 48 (0x30)</description>
	/// <description>
	/// Specifies that an encrypted signature PIN is contained in <c>pbData</c>. The <c>pbData</c> parameter contains a DATA_BLOB.
	/// </description>
	/// </item>
	/// <item>
	/// <description><c>PP_SMARTCARD_READER</c> 43 (0x2B)</description>
	/// <description>
	/// Specifies the name of the smart card reader. The <c>pbData</c> parameter is the address of an ANSI character array that contains a
	/// null-terminated ANSI string that contains the name of the smart card reader. <c>Windows ServerÂ 2003 and WindowsÂ XP:Â Â</c> This
	/// parameter is not supported.
	/// </description>
	/// </item>
	/// <item>
	/// <description><c>PP_SMARTCARD_GUID</c> 45 (0x2D)</description>
	/// <description>
	/// Specifies the identifier of the smart card. The <c>pbData</c> parameter is the address of a <c>GUID</c> structure that contains the
	/// identifier of the smart card. <c>Windows ServerÂ 2003 and WindowsÂ XP:Â Â</c> This parameter is not supported.
	/// </description>
	/// </item>
	/// </list>
	/// <para>
	/// A pointer to a data buffer that contains the value to be set as a provider parameter. The form of this data varies depending on the
	/// <c>dwParam</c> value. If <c>dwParam</c> contains <c>PP_USE_HARDWARE_RNG</c>, this parameter must be <c>NULL</c>.
	/// </para>
	/// <para>
	/// If <c>dwParam</c> contains <c>PP_KEYSET_SEC_DESCR</c>, <c>dwFlags</c> contains the <c>SECURITY_INFORMATION</c> applicable bit flags,
	/// as defined in the Platform SDK. Key-container security is handled by using SetFileSecurity and GetFileSecurity.
	/// </para>
	/// <para>These bit flags can be combined by using a bitwise- <c>OR</c> operation. For more information, see CryptGetProvParam.</para>
	/// <para>If <c>dwParam</c> is <c>PP_USE_HARDWARE_RNG</c> or <c>PP_DELETEKEY</c>, <c>dwFlags</c> must be set to zero.</para>
	/// </summary>
	/// <typeparam name="TIn">The type of the in.</typeparam>
	/// <param name="hProv">
	/// The handle of a CSP for which to set values. This handle must have already been created by using the CryptAcquireContext function.
	/// </param>
	/// <param name="dwParam">
	/// <para>Specifies the parameter to set. This can be one of the following values.</para>
	/// <list type="table">
	/// <listheader>
	/// <description>Value</description>
	/// <description>Meaning</description>
	/// </listheader>
	/// <item>
	/// <description><c>PP_CLIENT_HWND</c> 1 (0x1)</description>
	/// <description>
	/// Set the window handle that the provider uses as the parent of any dialog boxes it creates. <c>pbData</c> contains a pointer to an
	/// <c>HWND</c> that contains the parent window handle. This parameter must be set before calling CryptAcquireContext because many CSPs
	/// will display a user interface when <c>CryptAcquireContext</c> is called. You can pass <c>NULL</c> for the <c>hProv</c> parameter to
	/// set this window handle for all cryptographic contexts subsequently acquired within this process.
	/// </description>
	/// </item>
	/// <item>
	/// <description><c>PP_DELETEKEY</c> 24 (0x18)</description>
	/// <description>
	/// Delete the ephemeral key associated with a hash, encryption, or verification context. This will free memory and clear registry
	/// settings associated with the key.
	/// </description>
	/// </item>
	/// <item>
	/// <description><c>PP_KEYEXCHANGE_ALG</c></description>
	/// <description>This constant is not used.</description>
	/// </item>
	/// <item>
	/// <description><c>PP_KEYEXCHANGE_PIN</c> 32 (0x20)</description>
	/// <description>
	/// Specifies that the key exchange PIN is contained in <c>pbData</c>. The PIN is represented as a null-terminated ASCII string.
	/// </description>
	/// </item>
	/// <item>
	/// <description><c>PP_KEYEXCHANGE_KEYSIZE</c></description>
	/// <description>This constant is not used.</description>
	/// </item>
	/// <item>
	/// <description><c>PP_KEYSET_SEC_DESCR</c> 8 (0x8)</description>
	/// <description>
	/// Sets the security descriptor on the key storage container. The <c>pbData</c> parameter is the address of a SECURITY_DESCRIPTOR
	/// structure that contains the new security descriptor for the key storage container.
	/// </description>
	/// </item>
	/// <item>
	/// <description><c>PP_PIN_PROMPT_STRING</c> 44 (0x2C)</description>
	/// <description>
	/// Sets an alternate prompt string to display to the user when the user's PIN is requested. The <c>pbData</c> parameter is a pointer to
	/// a null-terminated Unicode string.
	/// </description>
	/// </item>
	/// <item>
	/// <description><c>PP_ROOT_CERTSTORE</c> 46 (0x2E)</description>
	/// <description>
	/// Sets the root certificate store for the smart card. The provider will copy the root certificates from this store onto the smart card.
	/// The <c>pbData</c> parameter is an <c>HCERTSTORE</c> variable that contains the handle of the new certificate store. The provider will
	/// copy the certificates from the store during this call, so it is safe to close this store after this function is called. <c>WindowsÂ
	/// XP and Windows ServerÂ 2003:Â Â</c> This parameter is not supported.
	/// </description>
	/// </item>
	/// <item>
	/// <description><c>PP_SIGNATURE_ALG</c></description>
	/// <description>This constant is not used.</description>
	/// </item>
	/// <item>
	/// <description><c>PP_SIGNATURE_PIN</c> 33 (0x21)</description>
	/// <description>
	/// Specifies the signature PIN. The <c>pbData</c> parameter is a null-terminated ASCII string that represents the PIN.
	/// </description>
	/// </item>
	/// <item>
	/// <description><c>PP_SIGNATURE_KEYSIZE</c></description>
	/// <description>This constant is not used.</description>
	/// </item>
	/// <item>
	/// <description><c>PP_UI_PROMPT</c> 21 (0x15)</description>
	/// <description>
	/// For a smart card provider, sets the search string that is displayed to the user as a prompt to insert the smart card. This string is
	/// passed as the <c>lpstrSearchDesc</c> member of the OPENCARDNAME_EX structure that is passed to the SCardUIDlgSelectCard function.
	/// This string is used for the lifetime of the calling process. The <c>pbData</c> parameter is a pointer to a null-terminated Unicode string.
	/// </description>
	/// </item>
	/// <item>
	/// <description><c>PP_USE_HARDWARE_RNG</c> 38 (0x26)</description>
	/// <description>
	/// Specifies that the CSP must exclusively use the hardware random number generator (RNG). When <c>PP_USE_HARDWARE_RNG</c> is set,
	/// random values are taken exclusively from the hardware RNG and no other sources are used. If a hardware RNG is supported by the CSP
	/// and it can be exclusively used, the function succeeds and returns <c>TRUE</c>; otherwise, the function fails and returns
	/// <c>FALSE</c>. The <c>pbData</c> parameter must be <c>NULL</c> and <c>dwFlags</c> must be zero when using this value. None of the
	/// Microsoft CSPs currently support using a hardware RNG.
	/// </description>
	/// </item>
	/// <item>
	/// <description><c>PP_USER_CERTSTORE</c> 42 (0x2A)</description>
	/// <description>
	/// Specifies the user certificate store for the smart card. This certificate store contains all of the user certificates that are stored
	/// on the smart card. The certificates in this store are encoded by using PKCS_7_ASN_ENCODING or X509_ASN_ENCODING encoding and should
	/// contain the <c>CERT_KEY_PROV_INFO_PROP_ID</c> property. The <c>pbData</c> parameter is an <c>HCERTSTORE</c> variable that receives
	/// the handle of an in-memory certificate store. When this handle is no longer needed, the caller must close it by using the
	/// CertCloseStore function. <c>Windows ServerÂ 2003 and WindowsÂ XP:Â Â</c> This parameter is not supported.
	/// </description>
	/// </item>
	/// <item>
	/// <description><c>PP_SECURE_KEYEXCHANGE_PIN</c> 47 (0x2F)</description>
	/// <description>
	/// Specifies that an encrypted key exchange PIN is contained in <c>pbData</c>. The <c>pbData</c> parameter contains a DATA_BLOB.
	/// </description>
	/// </item>
	/// <item>
	/// <description><c>PP_SECURE_SIGNATURE_PIN</c> 48 (0x30)</description>
	/// <description>
	/// Specifies that an encrypted signature PIN is contained in <c>pbData</c>. The <c>pbData</c> parameter contains a DATA_BLOB.
	/// </description>
	/// </item>
	/// <item>
	/// <description><c>PP_SMARTCARD_READER</c> 43 (0x2B)</description>
	/// <description>
	/// Specifies the name of the smart card reader. The <c>pbData</c> parameter is the address of an ANSI character array that contains a
	/// null-terminated ANSI string that contains the name of the smart card reader. <c>Windows ServerÂ 2003 and WindowsÂ XP:Â Â</c> This
	/// parameter is not supported.
	/// </description>
	/// </item>
	/// <item>
	/// <description><c>PP_SMARTCARD_GUID</c> 45 (0x2D)</description>
	/// <description>
	/// Specifies the identifier of the smart card. The <c>pbData</c> parameter is the address of a <c>GUID</c> structure that contains the
	/// identifier of the smart card. <c>Windows ServerÂ 2003 and WindowsÂ XP:Â Â</c> This parameter is not supported.
	/// </description>
	/// </item>
	/// </list>
	/// </param>
	/// <param name="pbData">
	/// A pointer to a data buffer that contains the value to be set as a provider parameter. The form of this data varies depending on the
	/// <c>dwParam</c> value. If <c>dwParam</c> contains <c>PP_USE_HARDWARE_RNG</c>, this parameter must be <c>NULL</c>.
	/// </param>
	/// <param name="dwFlags">
	/// <para>
	/// If <c>dwParam</c> contains <c>PP_KEYSET_SEC_DESCR</c>, <c>dwFlags</c> contains the <c>SECURITY_INFORMATION</c> applicable bit flags,
	/// as defined in the Platform SDK. Key-container security is handled by using SetFileSecurity and GetFileSecurity.
	/// </para>
	/// <para>These bit flags can be combined by using a bitwise- <c>OR</c> operation. For more information, see CryptGetProvParam.</para>
	/// <para>If <c>dwParam</c> is <c>PP_USE_HARDWARE_RNG</c> or <c>PP_DELETEKEY</c>, <c>dwFlags</c> must be set to zero.</para>
	/// </param>
	/// <returns>
	/// <para>If the function succeeds, the return value is nonzero ( <c>TRUE</c>).</para>
	/// <para>If the function fails, the return value is zero ( <c>FALSE</c>). For extended error information, call GetLastError.</para>
	/// <para>The error codes prefaced by "NTE" are generated by the particular CSP being used. Error codes include the following.</para>
	/// <list type="table">
	/// <listheader>
	/// <description>Return code</description>
	/// <description>Description</description>
	/// </listheader>
	/// <item>
	/// <description><c>ERROR_BUSY</c></description>
	/// <description>The CSP context is currently being used by another process.</description>
	/// </item>
	/// <item>
	/// <description><c>ERROR_INVALID_HANDLE</c></description>
	/// <description>One of the parameters specifies a handle that is not valid.</description>
	/// </item>
	/// <item>
	/// <description><c>ERROR_INVALID_PARAMETER</c></description>
	/// <description>One of the parameters contains a value that is not valid. This is most often a pointer that is not valid.</description>
	/// </item>
	/// <item>
	/// <description><c>NTE_BAD_FLAGS</c></description>
	/// <description>The <c>dwFlags</c> parameter is nonzero or the <c>pbData</c> buffer contains a value that is not valid.</description>
	/// </item>
	/// <item>
	/// <description><c>NTE_BAD_TYPE</c></description>
	/// <description>The <c>dwParam</c> parameter specifies an unknown parameter.</description>
	/// </item>
	/// <item>
	/// <description><c>NTE_BAD_UID</c></description>
	/// <description>The CSP context that was specified when the <c>hKey</c> key was created cannot be found.</description>
	/// </item>
	/// <item>
	/// <description><c>NTE_FAIL</c></description>
	/// <description>The function failed in some unexpected way.</description>
	/// </item>
	/// </list>
	/// </returns>
	// https://learn.microsoft.com/en-us/windows/win32/api/wincrypt/nf-wincrypt-cryptsetprovparam BOOL CryptSetProvParam( [in] HCRYPTPROV
	// hProv, [in] DWORD dwParam, [in] const BYTE *pbData, [in] DWORD dwFlags );
	[PInvokeData("wincrypt.h", MSDNShortId = "NF:wincrypt.CryptSetProvParam")]
	public static bool CryptSetProvParam<TIn>(HCRYPTPROV hProv, ProvParam dwParam, TIn pbData, uint dwFlags) => CryptSetValue(CryptSetProvParam, hProv, dwParam, pbData, dwFlags);

	/// <summary>
	/// The CryptSignHash function signs data. Because all signature algorithms are asymmetric and thus slow, CryptoAPI does not allow data
	/// to be signed directly. Instead, data is first hashed, and CryptSignHash is used to sign the hash.
	/// </summary>
	/// <param name="hHash">Handle of the hash object to be signed.</param>
	/// <param name="dwKeySpec">
	/// <para>Identifies the private key to use from the provider's container. It can be AT_KEYEXCHANGE or AT_SIGNATURE.</para>
	/// <para>The signature algorithm used is specified when the key pair is originally created.</para>
	/// <para>The only signature algorithm that the Microsoft Base Cryptographic Provider supports is the RSA Public Key algorithm.</para>
	/// </param>
	/// <param name="szDescription">
	/// This parameter is no longer used and must be set to <c>NULL</c> to prevent security vulnerabilities. However, it is still supported
	/// for backward compatibility in the Microsoft Base Cryptographic Provider.
	/// </param>
	/// <param name="dwFlags">
	/// <para>The following flag values are defined.</para>
	/// <list type="table">
	/// <listheader>
	/// <term>Value</term>
	/// <term>Meaning</term>
	/// </listheader>
	/// <item>
	/// <term>CRYPT_NOHASHOID 0x00000001</term>
	/// <term>
	/// Used with RSA providers. The hash object identifier (OID) is not placed in the RSA public key encryption. If this flag is not set,
	/// the hash OID in the default signature is as specified in the definition of DigestInfo in PKCS #1.
	/// </term>
	/// </item>
	/// <item>
	/// <term>CRYPT_TYPE2_FORMAT 0x00000002</term>
	/// <term>This flag is not used.</term>
	/// </item>
	/// <item>
	/// <term>CRYPT_X931_FORMAT 0x00000004</term>
	/// <term>Use the RSA signature padding method specified in the ANSI X9.31 standard.</term>
	/// </item>
	/// </list>
	/// </param>
	/// <param name="pbSignature">
	/// <para>A pointer to a buffer receiving the signature data.</para>
	/// <para>
	/// This parameter can be <c>NULL</c> to set the buffer size for memory allocation purposes. For more information, see Retrieving Data of
	/// Unknown Length.
	/// </para>
	/// </param>
	/// <param name="pdwSigLen">
	/// <para>
	/// A pointer to a <c>DWORD</c> value that specifies the size, in bytes, of the pbSignature buffer. When the function returns, the
	/// <c>DWORD</c> value contains the number of bytes stored in the buffer.
	/// </para>
	/// <para>
	/// <c>Note</c> When processing the data returned in the buffer, applications must use the actual size of the data returned. The actual
	/// size can be slightly smaller than the size of the buffer specified on input. (On input, buffer sizes are usually specified large
	/// enough to ensure that the largest possible output data fits in the buffer.) On output, the variable pointed to by this parameter is
	/// updated to reflect the actual size of the data copied to the buffer.
	/// </para>
	/// </param>
	/// <returns>
	/// <para>If the function succeeds, the function returns <c>TRUE</c>.</para>
	/// <para>If the function fails, it returns <c>FALSE</c>. For extended error information, call GetLastError.</para>
	/// <para>The error codes prefaced by "NTE" are generated by the particular CSP you are using. Some possible error codes follow.</para>
	/// <list type="table">
	/// <listheader>
	/// <term>Return code</term>
	/// <term>Description</term>
	/// </listheader>
	/// <item>
	/// <term>ERROR_INVALID_HANDLE</term>
	/// <term>One of the parameters specifies a handle that is not valid.</term>
	/// </item>
	/// <item>
	/// <term>ERROR_INVALID_PARAMETER</term>
	/// <term>One of the parameters contains a value that is not valid. This is most often a pointer that is not valid.</term>
	/// </item>
	/// <item>
	/// <term>ERROR_MORE_DATA</term>
	/// <term>
	/// The buffer specified by the pbSignature parameter is not large enough to hold the returned data. The required buffer size, in bytes,
	/// is in the pdwSigLenDWORD value.
	/// </term>
	/// </item>
	/// <item>
	/// <term>NTE_BAD_ALGID</term>
	/// <term>The hHash handle specifies an algorithm that this CSP does not support, or the dwKeySpec parameter has an incorrect value.</term>
	/// </item>
	/// <item>
	/// <term>NTE_BAD_FLAGS</term>
	/// <term>The dwFlags parameter is nonzero.</term>
	/// </item>
	/// <item>
	/// <term>NTE_BAD_HASH</term>
	/// <term>The hash object specified by the hHash parameter is not valid.</term>
	/// </item>
	/// <item>
	/// <term>NTE_BAD_UID</term>
	/// <term>The CSP context that was specified when the hash object was created cannot be found.</term>
	/// </item>
	/// <item>
	/// <term>NTE_NO_KEY</term>
	/// <term>The private key specified by dwKeySpec does not exist.</term>
	/// </item>
	/// <item>
	/// <term>NTE_NO_MEMORY</term>
	/// <term>The CSP ran out of memory during the operation.</term>
	/// </item>
	/// </list>
	/// </returns>
	/// <remarks>
	/// <para>
	/// Before calling this function, the CryptCreateHash function must be called to get a handle to a hash object. The CryptHashData or
	/// CryptHashSessionKey function is then used to add the data or session keys to the hash object. The <c>CryptSignHash</c> function
	/// completes the hash.
	/// </para>
	/// <para>While the DSS CSP supports hashing with both the MD5 and the SHA hash algorithms, the DSS CSP only supports signing SHA hashes.</para>
	/// <para>
	/// After this function is called, no more data can be added to the hash. Additional calls to CryptHashData or CryptHashSessionKey fail.
	/// </para>
	/// <para>After the application finishes using the hash, destroy the hash object by calling the CryptDestroyHash function.</para>
	/// <para>
	/// By default, the Microsoft RSA providers use the PKCS #1 padding method for the signature. The hash OID in the <c>DigestInfo</c>
	/// element of the signature is automatically set to the algorithm OID associated with the hash object. Using the <c>CRYPT_NOHASHOID</c>
	/// flag will cause this OID to be omitted from the signature.
	/// </para>
	/// <para>
	/// Occasionally, a hash value that has been generated elsewhere must be signed. This can be done by using the following sequence of operations:
	/// </para>
	/// <list type="number">
	/// <item>
	/// <term>Create a hash object by using CryptCreateHash.</term>
	/// </item>
	/// <item>
	/// <term>Set the hash value in the hash object by using the <c>HP_HASHVAL</c> value of the dwParam parameter in CryptSetHashParam.</term>
	/// </item>
	/// <item>
	/// <term>Sign the hash value by using <c>CryptSignHash</c> and obtain a digital signature block.</term>
	/// </item>
	/// <item>
	/// <term>Destroy the hash object by using CryptDestroyHash.</term>
	/// </item>
	/// </list>
	/// <para>Examples</para>
	/// <para>
	/// The following example shows signing data by first hashing the data to be signed and then signing the hash by using the
	/// <c>CryptSignHash</c> function.
	/// </para>
	/// <para>For a complete example including the context for this code, see Example C Program: Signing a Hash and Verifying the Hash Signature.</para>
	/// </remarks>
	// https://docs.microsoft.com/en-us/windows/win32/api/wincrypt/nf-wincrypt-cryptsignhasha BOOL CryptSignHashA( HCRYPTHASH hHash, DWORD
	// dwKeySpec, LPCSTR szDescription, DWORD dwFlags, BYTE *pbSignature, DWORD *pdwSigLen );
	[DllImport(Lib.AdvApi32, SetLastError = true, CharSet = CharSet.Auto)]
	[PInvokeData("wincrypt.h", MSDNShortId = "9cf0de04-fdad-457d-8137-16d98f915cd5")]
	[return: MarshalAs(UnmanagedType.Bool)]
	public static extern bool CryptSignHash(HCRYPTHASH hHash, CertKeySpec dwKeySpec, [Optional, MarshalAs(UnmanagedType.LPTStr)] string? szDescription, CryptSignFlags dwFlags, [Out, Optional] IntPtr pbSignature, ref uint pdwSigLen);

	/// <summary>
	/// <para>The CryptVerifySignature function verifies the signature of a hash object.</para>
	/// <para>
	/// Before calling this function, CryptCreateHash must be called to create the handle of a hash object. CryptHashData or
	/// CryptHashSessionKey is then used to add data or session keys to the hash object.
	/// </para>
	/// <para>After <c>CryptVerifySignature</c> completes, only CryptDestroyHash can be called by using the hHash handle.</para>
	/// </summary>
	/// <param name="hHash">A handle to the hash object to verify.</param>
	/// <param name="pbSignature">The address of the signature data to be verified.</param>
	/// <param name="dwSigLen">The number of bytes in the pbSignature signature data.</param>
	/// <param name="hPubKey">
	/// A handle to the public key to use to authenticate the signature. This public key must belong to the key pair that was originally used
	/// to create the digital signature.
	/// </param>
	/// <param name="szDescription">
	/// This parameter should no longer be used and must be set to <c>NULL</c> to prevent security vulnerabilities. However, it is still
	/// supported for backward compatibility in the Microsoft Base Cryptographic Provider.
	/// </param>
	/// <param name="dwFlags">
	/// <para>The following flag values are defined.</para>
	/// <list type="table">
	/// <listheader>
	/// <term>Value</term>
	/// <term>Meaning</term>
	/// </listheader>
	/// <item>
	/// <term>CRYPT_NOHASHOID 0x00000001</term>
	/// <term>
	/// This flag is used with RSA providers. When verifying the signature, the hash object identifier (OID) is not expected to be present or
	/// checked. If this flag is not set, the hash OID in the default signature is verified as specified in the definition of DigestInfo in
	/// PKCS #7.
	/// </term>
	/// </item>
	/// <item>
	/// <term>CRYPT_TYPE2_FORMAT 0x00000002</term>
	/// <term>This flag is not used.</term>
	/// </item>
	/// <item>
	/// <term>CRYPT_X931_FORMAT 0x00000004</term>
	/// <term>Use X.931 support for the FIPS 186-2–compliant version of RSA (rDSA).</term>
	/// </item>
	/// </list>
	/// </param>
	/// <returns>
	/// <para>If the function succeeds, the return value is <c>TRUE</c>.</para>
	/// <para>If the function fails, the return value is <c>FALSE</c>. For extended error information, call GetLastError.</para>
	/// <para>The error codes prefaced by "NTE" are generated by the particular CSP you are using. Some possible error codes follow.</para>
	/// <list type="table">
	/// <listheader>
	/// <term>Return code</term>
	/// <term>Description</term>
	/// </listheader>
	/// <item>
	/// <term>ERROR_INVALID_HANDLE</term>
	/// <term>One of the parameters specifies a handle that is not valid.</term>
	/// </item>
	/// <item>
	/// <term>ERROR_INVALID_PARAMETER</term>
	/// <term>One of the parameters contains a value that is not valid. This is most often a pointer that is not valid.</term>
	/// </item>
	/// <item>
	/// <term>NTE_BAD_FLAGS</term>
	/// <term>The dwFlags parameter is nonzero.</term>
	/// </item>
	/// <item>
	/// <term>NTE_BAD_HASH</term>
	/// <term>The hash object specified by the hHash parameter is not valid.</term>
	/// </item>
	/// <item>
	/// <term>NTE_BAD_KEY</term>
	/// <term>The hPubKey parameter does not contain a handle to a valid public key.</term>
	/// </item>
	/// <item>
	/// <term>NTE_BAD_SIGNATURE</term>
	/// <term>
	/// The signature was not valid. This might be because the data itself has changed, the description string did not match, or the wrong
	/// public key was specified by hPubKey. This error can also be returned if the hashing or signature algorithms do not match the ones
	/// used to create the signature.
	/// </term>
	/// </item>
	/// <item>
	/// <term>NTE_BAD_UID</term>
	/// <term>The cryptographic service provider (CSP) context that was specified when the hash object was created cannot be found.</term>
	/// </item>
	/// <item>
	/// <term>NTE_NO_MEMORY</term>
	/// <term>The CSP ran out of memory during the operation.</term>
	/// </item>
	/// </list>
	/// </returns>
	/// <remarks>
	/// <para>
	/// The <c>CryptVerifySignature</c> function completes the hash. After this call, no more data can be added to the hash. Additional calls
	/// to CryptHashData or CryptHashSessionKey fail. After the application is done with the hash, CryptDestroyHash should be called to
	/// destroy the hash object.
	/// </para>
	/// <para>
	/// If you generate a signature by using the .NET Framework APIs and try to verify it by using the <c>CryptVerifySignature</c> function,
	/// the function will fail and GetLastError will return <c>NTE_BAD_SIGNATURE</c>. This is due to the different byte orders between the
	/// native Win32 API and the .NET Framework API.
	/// </para>
	/// <para>
	/// The native cryptography API uses little-endian byte order while the .NET Framework API uses big-endian byte order. If you are
	/// verifying a signature generated by using a .NET Framework API, you must swap the order of signature bytes before calling the
	/// <c>CryptVerifySignature</c> function to verify the signature.
	/// </para>
	/// <para>Examples</para>
	/// <para>
	/// For an example that uses the <c>CryptVerifySignature</c> function, see Example C Program: Signing a Hash and Verifying the Hash Signature.
	/// </para>
	/// </remarks>
	// https://docs.microsoft.com/en-us/windows/win32/api/wincrypt/nf-wincrypt-cryptverifysignaturea BOOL CryptVerifySignatureA( HCRYPTHASH
	// hHash, const BYTE *pbSignature, DWORD dwSigLen, HCRYPTKEY hPubKey, LPCSTR szDescription, DWORD dwFlags );
	[DllImport(Lib.AdvApi32, SetLastError = true, CharSet = CharSet.Auto)]
	[PInvokeData("wincrypt.h", MSDNShortId = "3119eabc-90ff-42c6-b3fa-e8be625f6d1e")]
	[return: MarshalAs(UnmanagedType.Bool)]
	public static extern bool CryptVerifySignature(HCRYPTHASH hHash, [In] IntPtr pbSignature, uint dwSigLen, HCRYPTKEY hPubKey, [Optional, MarshalAs(UnmanagedType.LPTStr)] string? szDescription, CryptSignFlags dwFlags);

	private static TRet? CryptGetValue<THandle, TEnum, TRet>(CryptGetValueMethod<THandle, TEnum> func, THandle hKey, TEnum dwParam, uint dwFlags = 0) where THandle : struct where TEnum : Enum
	{
		var len = 0U;
		Win32Error.ThrowLastErrorIfFalse(func(hKey, dwParam, default, ref len, dwFlags));
		using var mem = new SafeHGlobalHandle(len);
		Win32Error.ThrowLastErrorIfFalse(func(hKey, dwParam, mem, ref len, dwFlags));
		return mem.DangerousGetHandle().Convert<TRet>(mem.Size);
	}

	private static bool CryptSetValue<THandle, TEnum, TIn>(Func<THandle, TEnum, IntPtr, uint, bool> func, THandle hKey, TEnum dwParam, TIn value, uint dwFlags = 0) where THandle : struct where TEnum : Enum
	{
		var ptr = value.MarshalToPtr(Marshal.AllocCoTaskMem, out var sz);
		using SafeCoTaskMemHandle mem = new(ptr, sz);
		return func(hKey, dwParam, mem, dwFlags);
	}

	/// <summary>
	/// The <c>CMS_DH_KEY_INFO</c> structure is used with the <c>KP_CMS_DH_KEY_INFO</c> parameter in the CryptSetKeyParam function to contain
	/// Diffie-Hellman key information.
	/// </summary>
	// https://learn.microsoft.com/en-us/windows/win32/api/wincrypt/ns-wincrypt-cms_dh_key_info typedef struct _CMS_DH_KEY_INFO { DWORD
	// dwVersion; ALG_ID Algid; LPSTR pszContentEncObjId; CRYPT_DATA_BLOB PubInfo; void *pReserved; } CMS_DH_KEY_INFO, *PCMS_DH_KEY_INFO;
	[PInvokeData("wincrypt.h", MSDNShortId = "NS:wincrypt._CMS_DH_KEY_INFO")]
	[StructLayout(LayoutKind.Sequential)]
	public struct CMS_DH_KEY_INFO
	{
		/// <summary>The size, in bytes, of this structure.</summary>
		public uint dwVersion;

		/// <summary>One of the ALG_ID values that identifies the algorithm for the key to be converted.</summary>
		public ALG_ID Algid;

		/// <summary>
		/// The address of a null-terminated ANSI string that contains the object identifier (OID) of the content encryption algorithm.
		/// </summary>
		[MarshalAs(UnmanagedType.LPStr)]
		public string pszContentEncObjId;

		/// <summary>
		/// A CRYPT_DATA_BLOB structure that contains additional public information. This member is optional and the <c>cbData</c> member of
		/// this structure can be zero if this is not needed.
		/// </summary>
		public CRYPTOAPI_BLOB PubInfo;

		/// <summary>Reserved for future use and must be <c>NULL</c>.</summary>
		public IntPtr pReserved;
	}

	/// <summary>
	/// The <c>DSSSEED</c> structure holds the seed and counter values that can be used to verify the primes of the DSS public key.
	/// </summary>
	// https://learn.microsoft.com/en-us/windows/win32/api/wincrypt/ns-wincrypt-dssseed typedef struct _DSSSEED { DWORD counter; BYTE
	// seed[20]; } DSSSEED;
	[PInvokeData("wincrypt.h", MSDNShortId = "NS:wincrypt._DSSSEED")]
	[StructLayout(LayoutKind.Sequential)]
	public struct DSSSEED
	{
		/// <summary>
		/// A <c>DWORD</c> containing the counter value. If the counter value is 0xFFFFFFFF, the seed and counter values are not available.
		/// </summary>
		public uint counter;

		/// <summary>A <c>BYTE</c> string containing the seed value.</summary>
		[MarshalAs(UnmanagedType.ByValArray, SizeConst = 20)]
		public byte[] seed;
	}

	/// <summary>
	/// The <c>HMAC_INFO</c> structure specifies the hash algorithm and the inner and outer strings that are to be used to calculate the HMAC hash.
	/// </summary>
	// https://docs.microsoft.com/en-us/windows/win32/api/wincrypt/ns-wincrypt-hmac_info typedef struct _HMAC_Info { ALG_ID HashAlgid; BYTE
	// *pbInnerString; DWORD cbInnerString; BYTE *pbOuterString; DWORD cbOuterString; } HMAC_INFO, *PHMAC_INFO;
	[PInvokeData("wincrypt.h", MSDNShortId = "0c9a9b60-077d-48c0-a5a6-01640cfc0c4e")]
	[StructLayout(LayoutKind.Sequential)]
	public struct HMAC_INFO
	{
		/// <summary>Specifies the hash algorithm to be used.</summary>
		public ALG_ID HashAlgid;

		/// <summary>
		/// A pointer to the inner string to be used in the HMAC calculation. The default inner string is defined as the byte 0x36 repeated
		/// 64 times.
		/// </summary>
		public IntPtr pbInnerString;

		/// <summary>
		/// The count of bytes in <c>pbInnerString</c>. The CSP uses the default inner string if <c>cbInnerString</c> is equal to zero.
		/// </summary>
		public uint cbInnerString;

		/// <summary>
		/// A pointer to the outer string to be used in the HMAC calculation. The default outer string is defined as the byte 0x5C repeated
		/// 64 times.
		/// </summary>
		public IntPtr pbOuterString;

		/// <summary>
		/// The count of bytes in <c>pbOuterString</c>. The CSP uses the default outer string if <c>cbOuterString</c> is equal to zero.
		/// </summary>
		public uint cbOuterString;
	}

	/// <summary>
	/// The <c>PROV_ENUMALGS</c> structure is used with the CryptGetProvParam function when the <c>PP_ENUMALGS</c> parameter is retrieved to
	/// contain information about an algorithm supported by a cryptographic service provider (CSP).
	/// </summary>
	// https://docs.microsoft.com/en-us/windows/win32/api/wincrypt/ns-wincrypt-prov_enumalgs typedef struct _PROV_ENUMALGS { ALG_ID aiAlgid;
	// DWORD dwBitLen; DWORD dwNameLen; CHAR szName[20]; } PROV_ENUMALGS;
	[PInvokeData("wincrypt.h", MSDNShortId = "8301d07f-88aa-49b4-9091-8f515b585c57")]
	[StructLayout(LayoutKind.Sequential, CharSet = CharSet.Ansi)]
	public struct PROV_ENUMALGS
	{
		/// <summary>One of the ALG_ID values that identifies the algorithm.</summary>
		public ALG_ID aiAlgid;

		/// <summary>The default key length, in bits, of the algorithm.</summary>
		public uint dwBitLen;

		/// <summary>The length, in <c>CHAR</c> s, of the <c>szName</c> string. This length includes the terminating null character.</summary>
		public uint dwNameLen;

		/// <summary>A null-terminated ANSI string that contains the name of the algorithm.</summary>
		[MarshalAs(UnmanagedType.ByValTStr, SizeConst = 20)]
		public string szName;
	}

	/// <summary>
	/// The <c>PROV_ENUMALGS_EX</c> structure is used with the CryptGetProvParam function when the <c>PP_ENUMALGS_EX</c> parameter is
	/// retrieved to contain information about an algorithm supported by a cryptographic service provider (CSP).
	/// </summary>
	// https://docs.microsoft.com/en-us/windows/win32/api/wincrypt/ns-wincrypt-prov_enumalgs_ex typedef struct _PROV_ENUMALGS_EX { ALG_ID
	// aiAlgid; DWORD dwDefaultLen; DWORD dwMinLen; DWORD dwMaxLen; DWORD dwProtocols; DWORD dwNameLen; CHAR szName[20]; DWORD dwLongNameLen;
	// CHAR szLongName[40]; } PROV_ENUMALGS_EX;
	[PInvokeData("wincrypt.h", MSDNShortId = "239dbc6f-c3fa-4f97-aa9a-4993fe726a98")]
	[StructLayout(LayoutKind.Sequential, CharSet = CharSet.Ansi)]
	public struct PROV_ENUMALGS_EX
	{
		/// <summary>One of the ALG_ID values that identifies the algorithm.</summary>
		public ALG_ID aiAlgid;
		/// <summary>The default key length, in bits, of the algorithm.</summary>
		public uint dwDefaultLen;
		/// <summary>The minimum key length, in bits, of the algorithm.</summary>
		public uint dwMinLen;
		/// <summary>The maximum key length, in bits, of the algorithm.</summary>
		public uint dwMaxLen;
		/// <summary>
		/// Zero or a combination of one or more of the Protocol Flags values that identifies the protocols supported by the algorithm.
		/// </summary>
		public uint dwProtocols;
		/// <summary>The length, in <c>CHAR</c> s, of the <c>szName</c> string. This length includes the terminating null character.</summary>
		public uint dwNameLen;
		/// <summary>A null-terminated ANSI string that contains the name of the algorithm.</summary>
		[MarshalAs(UnmanagedType.ByValTStr, SizeConst = 20)]
		public string szName;
		/// <summary>The length, in <c>CHAR</c> s, of the <c>szLongName</c> string. This length includes the terminating null character.</summary>
		public uint dwLongNameLen;
		/// <summary>A null-terminated ANSI string that contains the long name of the algorithm.</summary>
		[MarshalAs(UnmanagedType.ByValTStr, SizeConst = 40)]
		public string szLongName;
	}

	/// <summary>The <c>DHPUBKEY_VER3</c> structure contains information specific to the particular public key contained in the key BLOB.</summary>
	/// <remarks><c>DSSPUBKEY_VER3</c> is an alias for this structure.</remarks>
	// https://learn.microsoft.com/en-us/windows/win32/api/wincrypt/ns-wincrypt-dhpubkey_ver3 typedef struct _PUBKEYVER3 { DWORD magic; DWORD
	// bitlenP; DWORD bitlenQ; DWORD bitlenJ; DSSSEED DSSSeed; } DHPUBKEY_VER3, DSSPUBKEY_VER3;
	[PInvokeData("wincrypt.h", MSDNShortId = "NS:wincrypt._PUBKEYVER3")]
	[StructLayout(LayoutKind.Sequential)]
	public struct PUBKEYVER3
	{
		/// <summary>This must always be set to 0x33484400, the ASCII encoding of "DH3".</summary>
		public uint magic;

		/// <summary>Number of bits in the DH key BLOB's prime, P.</summary>
		public uint bitlenP;

		/// <summary>Number of bits in the DH key BLOB's prime, Q. If Q is not available, then this value should be 0.</summary>
		public uint bitlenQ;

		/// <summary>Number of bits in the DH key BLOB's prime, J. If J is not in the BLOB, then this value should be 0.</summary>
		public uint bitlenJ;

		/// <summary>
		/// Seed structure holding the seed and counter values used to generate the primes Q and P. If values in the DSSSEED structure are
		/// not available, then the counter element of the structure should be 0xFFFFFFFF.
		/// </summary>
		public DSSSEED DSSSeed;
	}
	/// <summary>
	/// The following cryptographic service provider (CSP) names are defined in Wincrypt.h. These constants are used with the
	/// <c>CryptAcquireContext</c> and <c>CryptSetProvider</c> functions.
	/// </summary>
	// https://docs.microsoft.com/en-us/windows/win32/seccrypto/cryptographic-provider-names
	[PInvokeData("wincrypt.h", MSDNShortId = "97e9a708-83b5-48b3-9d16-f7b54367dc4e")]
	public static class CryptProviderName
	{
		/// <summary>The Microsoft DSS and Diffie-Hellman/Schannel Cryptographic Provider.</summary>
		public const string MS_DEF_DH_SCHANNEL_PROV = "Microsoft DH Schannel Cryptographic Provider";

		/// <summary>The Microsoft Base DSS and Diffie-Hellman Cryptographic Provider.</summary>
		public const string MS_DEF_DSS_DH_PROV = "Microsoft Base DSS and Diffie-Hellman Cryptographic Provider";

		/// <summary>The Microsoft DSS Cryptographic Provider.</summary>
		public const string MS_DEF_DSS_PROV = "Microsoft Base DSS Cryptographic Provider";

		/// <summary>The Microsoft Base Cryptographic Provider.</summary>
		public const string MS_DEF_PROV = "Microsoft Base Cryptographic Provider v1.0";

		/// <summary>The Microsoft RSA/Schannel Cryptographic Provider.</summary>
		public const string MS_DEF_RSA_SCHANNEL_PROV = "Microsoft RSA Schannel Cryptographic Provider";

		/// <summary>The Microsoft RSA Signature Cryptographic Provider is not supported.</summary>
		public const string MS_DEF_RSA_SIG_PROV = "Microsoft RSA Signature Cryptographic Provider";

		/// <summary>The Microsoft Enhanced DSS and Diffie-Hellman Cryptographic Provider.</summary>
		public const string MS_ENH_DSS_DH_PROV = "Microsoft Enhanced DSS and Diffie-Hellman Cryptographic Provider";

		/// <summary>
		/// The Microsoft AES Cryptographic Provider.
		/// <para>**Windows XP: **"Microsoft Enhanced RSA and AES Cryptographic Provider (Prototype)"</para>
		/// </summary>
		public const string MS_ENH_RSA_AES_PROV = "Microsoft Enhanced RSA and AES Cryptographic Provider";

		/// <summary>The Microsoft Enhanced Cryptographic Provider.</summary>
		public const string MS_ENHANCED_PROV = "Microsoft Enhanced Cryptographic Provider v1.0";

		/// <summary>The Microsoft Base Smart Card Cryptographic Service Provider.</summary>
		public const string MS_SCARD_PROV = "Microsoft Base Smart Card Crypto Provider";

		/// <summary>The Microsoft Strong Cryptographic Provider.</summary>
		public const string MS_STRONG_PROV = "Microsoft Strong Cryptographic Provider";
	}

	/// <summary>Provides a <see cref="SafeHandle"/> for <see cref="HCRYPTHASH"/> that is disposed using <see cref="CryptDestroyHash"/>.</summary>
	[AutoSafeHandle("CryptDestroyHash(handle)", typeof(HCRYPTHASH))]
	public partial class SafeHCRYPTHASH { }

	/// <summary>Provides a <see cref="SafeHandle"/> for <see cref="HCRYPTPROV"/> that is disposed using <see cref="CryptReleaseContext"/>.</summary>
	[AutoSafeHandle("CryptReleaseContext(handle)", typeof(HCRYPTPROV))]
	public partial class SafeHCRYPTPROV { }
}