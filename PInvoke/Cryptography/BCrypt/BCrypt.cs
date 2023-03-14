using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using Vanara.Extensions;
using Vanara.InteropServices;
using static Vanara.PInvoke.NCrypt;

namespace Vanara.PInvoke;

/// <summary>Methods and data types found in BCrypt.dll.</summary>
public static partial class BCrypt
{
	/// <summary>A value that specifies the algorithm operation types to include in the enumeration.</summary>
	[PInvokeData("bcrypt.h", MSDNShortId = "7fa227c0-2b80-49ab-8a19-72f8444d5507")]
	[Flags]
	public enum AlgOperations
	{
		/// <summary>Include the cipher algorithms in the enumeration.</summary>
		BCRYPT_CIPHER_OPERATION = 0x00000001,

		/// <summary>Include the hash algorithms in the enumeration.</summary>
		BCRYPT_HASH_OPERATION = 0x00000002,

		/// <summary>Include the asymmetric encryption algorithms in the enumeration.</summary>
		BCRYPT_ASYMMETRIC_ENCRYPTION_OPERATION = 0x00000004,

		/// <summary>Include the secret agreement algorithms in the enumeration.</summary>
		BCRYPT_SECRET_AGREEMENT_OPERATION = 0x00000008,

		/// <summary>Include the signature algorithms in the enumeration.</summary>
		BCRYPT_SIGNATURE_OPERATION = 0x00000010,

		/// <summary>Include the random number generator (RNG) algorithms in the enumeration.</summary>
		BCRYPT_RNG_OPERATION = 0x00000020,

		/// <summary>Undocumented.</summary>
		BCRYPT_KEY_DERIVATION_OPERATION = 0x00000040,
	}

	/// <summary>Primitive algorithm provider functions.</summary>
	[PInvokeData("bcrypt.h", MSDNShortId = "aceba9c0-19e6-4f3c-972a-752feed4a9f8")]
	[Flags]
	public enum AlgProviderFlags
	{
		/// <summary>
		/// Loads the provider into the nonpaged memory pool. If this flag is not present, the provider is loaded into the paged memory
		/// pool. When this flag is specified, the handle returned must not be closed before all dependent objects have been freed. <note
		/// type="note">This flag is only supported in kernel mode and allows subsequent operations on the provider to be processed at
		/// the Dispatch level. If the provider does not support being called at dispatch level, then it will return an error when opened
		/// using this flag.</note>
		/// <para>
		/// Windows Server 2008 and Windows Vista: This flag is only supported by the Microsoft algorithm providers and only for hashing
		/// algorithms and symmetric key cryptographic algorithms.
		/// </para>
		/// </summary>
		BCRYPT_PROV_DISPATCH = 0x00000001,

		/// <summary>
		/// The provider will perform the Hash-Based Message Authentication Code (HMAC) algorithm with the specified hash algorithm. This
		/// flag is only used by hash algorithm providers.
		/// </summary>
		BCRYPT_ALG_HANDLE_HMAC_FLAG = 0x00000008,

		/// <summary>
		/// Creates a reusable hashing object. The object can be used for a new hashing operation immediately after calling
		/// BCryptFinishHash. For more information, see Creating a Hash with CNG.
		/// <para>Windows Server 2008 R2, Windows 7, Windows Server 2008 and Windows Vista: This flag is not supported.</para>
		/// </summary>
		BCRYPT_HASH_REUSABLE_FLAG = 0x00000020,

		/// <summary>
		/// Specifies that the target algorithm is AES and that the key therefore must be double expanded. This flag is only valid with
		/// the CAPI_KDF algorithm.
		/// </summary>
		BCRYPT_CAPI_AES_FLAG = 0x00000010,

		/// <summary>Undocumented</summary>
		BCRYPT_MULTI_FLAG = 0x00000040,
	}

	/// <summary>The BCRYPT_HASH_OPERATION_TYPE enumeration specifies the hash operation type.</summary>
	[PInvokeData("bcrypt.h")]
	public enum BCRYPT_HASH_OPERATION_TYPE
	{
		/// <summary>
		/// The operation performed is equivalent to calling the BCryptHashData function on the hash object array element with
		/// pbBuffer/cbBuffer pointing to the buffer to be hashed.
		/// </summary>
		BCRYPT_HASH_OPERATION_HASH_DATA = 1,

		/// <summary>
		/// The operation performed is equivalent to calling the BCryptFinishHash function on the hash object array element with
		/// pbBuffer/cbBuffer pointing to the output buffer that receives the result.
		/// </summary>
		BCRYPT_HASH_OPERATION_FINISH_HASH = 2,
	}

	/// <summary>
	/// The BCRYPT_MULTI_OPERATION_TYPE enumeration specifies type of multi-operation that is passed to the BCryptProcessMultiOperations function.
	/// </summary>
	[PInvokeData("bcrypt.h", MSDNShortId = "5FD28AC3-46D2-4F06-BF06-F5FEF8E531F5")]
	public enum BCRYPT_MULTI_OPERATION_TYPE
	{
		/// <summary>
		/// A hash operation. This value identifies the hObject parameter as a multi-hash object and the pOperations pointer as pointing
		/// to an array of BCRYPT_MULTI_HASH_OPERATION elements.
		/// </summary>
		BCRYPT_OPERATION_TYPE_HASH = 1,
	}

	/// <summary>Magic numbers for the various blobs.</summary>
	public enum BlobMagicNumber
	{
		/// <summary/>
		BCRYPT_DH_PARAMETERS_MAGIC = 0x4d504844,
		/// <summary/>
		BCRYPT_DH_PRIVATE_MAGIC = 0x56504844,
		/// <summary/>
		BCRYPT_DH_PUBLIC_MAGIC = 0x42504844,
		/// <summary/>
		BCRYPT_DSA_PARAMETERS_MAGIC_V2 = 0x324d5044,
		/// <summary/>
		BCRYPT_DSA_PRIVATE_MAGIC = 0x56505344,
		/// <summary/>
		BCRYPT_DSA_PRIVATE_MAGIC_V2 = 0x32565044,
		/// <summary/>
		BCRYPT_DSA_PUBLIC_MAGIC = 0x42505344,
		/// <summary/>
		BCRYPT_DSA_PUBLIC_MAGIC_V2 = 0x32425044,
		/// <summary/>
		BCRYPT_ECC_PARAMETERS_MAGIC = 0x50434345,
		/// <summary/>
		BCRYPT_ECDH_PRIVATE_GENERIC_MAGIC = 0x564B4345,
		/// <summary/>
		BCRYPT_ECDH_PRIVATE_P256_MAGIC = 0x324B4345,
		/// <summary/>
		BCRYPT_ECDH_PRIVATE_P384_MAGIC = 0x344B4345,
		/// <summary/>
		BCRYPT_ECDH_PRIVATE_P521_MAGIC = 0x364B4345,
		/// <summary/>
		BCRYPT_ECDH_PUBLIC_GENERIC_MAGIC = 0x504B4345,
		/// <summary/>
		BCRYPT_ECDH_PUBLIC_P256_MAGIC = 0x314B4345,
		/// <summary/>
		BCRYPT_ECDH_PUBLIC_P384_MAGIC = 0x334B4345,
		/// <summary/>
		BCRYPT_ECDH_PUBLIC_P521_MAGIC = 0x354B4345,
		/// <summary/>
		BCRYPT_ECDSA_PRIVATE_GENERIC_MAGIC = 0x56444345,
		/// <summary/>
		BCRYPT_ECDSA_PRIVATE_P256_MAGIC = 0x32534345,
		/// <summary/>
		BCRYPT_ECDSA_PRIVATE_P384_MAGIC = 0x34534345,
		/// <summary/>
		BCRYPT_ECDSA_PRIVATE_P521_MAGIC = 0x36534345,
		/// <summary/>
		BCRYPT_ECDSA_PUBLIC_GENERIC_MAGIC = 0x50444345,
		/// <summary/>
		BCRYPT_ECDSA_PUBLIC_P256_MAGIC = 0x31534345,
		/// <summary/>
		BCRYPT_ECDSA_PUBLIC_P384_MAGIC = 0x33534345,
		/// <summary/>
		BCRYPT_ECDSA_PUBLIC_P521_MAGIC = 0x35534345,
		/// <summary/>
		BCRYPT_KEY_DATA_BLOB_MAGIC = 0x4d42444b,
		/// <summary/>
		BCRYPT_RSAFULLPRIVATE_MAGIC = 0x33415352,
		/// <summary/>
		BCRYPT_RSAPRIVATE_MAGIC = 0x32415352,
		/// <summary/>
		BCRYPT_RSAPUBLIC_MAGIC = 0x31415352,
	}

	/// <summary>A set of flags that determine the options for the configuration context.</summary>
	[PInvokeData("bcrypt.h", MSDNShortId = "3e07b7ae-84ef-4b77-bd49-d96906eaa4f8")]
	[Flags]
	public enum ContextConfigFlags
	{
		/// <summary>
		/// <para>
		/// Restricts the set of cryptographic functions in an interface to those that the current CNG context is specifically registered
		/// to support. If this flag is set, then any attempts to resolve a given function will succeed only if one of the following is true:
		/// </para>
		/// <list type="bullet">
		/// <item>The function exists within the current CNG context.</item>
		/// <item>
		/// The function exists in some interface in the default context, and an instance of that same interface also exists within the
		/// current CNG context.
		/// </item>
		/// </list>
		/// </summary>
		CRYPT_EXCLUSIVE = 0x00000001,

		/// <summary>
		/// Indicates that this entry in the enterprise-wide configuration table should take precedence over any and all corresponding
		/// entries in the local-machine configuration table for this context. This flag only applies to entries in the enterprise-wide
		/// configuration table. Without this flag, local machine configuration entries take precedence.
		/// </summary>
		CRYPT_OVERRIDE = 0x00010000,
	}

	/// <summary>Configuration tables</summary>
	[PInvokeData("bcrypt.h", MSDNShortId = "4f5b6db0-775d-42de-b9d9-a99fb11c89f2")]
	public enum ContextConfigTable
	{
		/// <summary>The context exists in the local-machine configuration table.</summary>
		CRYPT_LOCAL = 0x00000001,

		/// <summary>This value is not available for use.</summary>
		CRYPT_DOMAIN = 0x00000002,
	}

	/// <summary>
	/// Specifies the position in the list at which to insert this function. The function is inserted at this position ahead of any
	/// existing functions.
	/// </summary>
	[PInvokeData("bcrypt.h", MSDNShortId = "4f5b6db0-775d-42de-b9d9-a99fb11c89f2")]
	public enum CryptPriority : uint
	{
		/// <summary>The crypt priority top</summary>
		CRYPT_PRIORITY_TOP = 0x00000000,

		/// <summary>The crypt priority bottom</summary>
		CRYPT_PRIORITY_BOTTOM = 0xFFFFFFFF
	}

	/// <summary>
	/// Flags used by <see cref="BCryptDeriveKey(BCRYPT_SECRET_HANDLE, string, NCryptBufferDesc, SafeAllocatedMemoryHandle, uint, out
	/// uint, DeriveKeyFlags)"/>.
	/// </summary>
	[PInvokeData("bcrypt.h", MSDNShortId = "33c3cbf7-6c08-42ed-ac3f-feb71f3a9cbf")]
	[Flags]
	public enum DeriveKeyFlags
	{
		/// <summary>
		/// The secret agreement value will also serve as the HMAC key. If this flag is specified, the KDF_HMAC_KEY parameter should not
		/// be included in the set of parameters in the pParameterList parameter. This flag is only used by the BCRYPT_KDF_HMAC key
		/// derivation function.
		/// </summary>
		KDF_USE_SECRET_AS_HMAC_KEY_FLAG = 1
	}

	/// <summary>Flags used by BCryptEncrypt.</summary>
	[PInvokeData("bcrypt.h", MSDNShortId = "69fe4530-4b7c-40db-a85c-f9dc458735e7")]
	public enum EncryptFlags
	{
		/// <summary>
		/// Allows the encryption algorithm to pad the data to the next block size. If this flag is not specified, the size of the
		/// plaintext specified in the cbInput parameter must be a multiple of the algorithm's block size. The block size can be obtained
		/// by calling the BCryptGetProperty function to get the BCRYPT_BLOCK_LENGTH property for the key. This will provide the size of
		/// a block for the algorithm. This flag must not be used with the authenticated encryption modes (AES-CCM and AES-GCM).
		/// </summary>
		BCRYPT_BLOCK_PADDING = 0x00000001,

		/// <summary>
		/// Do not use any padding. The pPaddingInfo parameter is not used. The size of the plaintext specified in the cbInput parameter
		/// must be a multiple of the algorithm's block size.
		/// </summary>
		BCRYPT_PAD_NONE = 0x00000001,

		/// <summary>
		/// The data will be padded with a random number to round out the block size. The pPaddingInfo parameter is not used.
		/// </summary>
		BCRYPT_PAD_PKCS1 = 0x00000002,

		/// <summary>
		/// Use the Optimal Asymmetric Encryption Padding (OAEP) scheme. The pPaddingInfo parameter is a pointer to a
		/// BCRYPT_OAEP_PADDING_INFO structure.
		/// </summary>
		BCRYPT_PAD_OAEP = 0x00000004,

		/// <summary>Undocumented</summary>
		BCRYPT_PAD_PSS = 0x00000008,

		/// <summary>Undocumented</summary>
		BCRYPT_PAD_PKCS1_OPTIONAL_HASH_OID = 0x00000010,
	}

	/// <summary>Flags used by <c>BCryptGenRandom</c>.</summary>
	[PInvokeData("bcrypt.h", MSDNShortId = "7c6cee3a-f2c5-46f3-8cfe-984316f323d9")]
	[Flags]
	public enum GenRandomFlags
	{
		/// <summary>
		/// This function will use the number in the pbBuffer buffer as additional entropy for the random number. If this flag is not
		/// specified, this function will use a random number for the entropy.
		/// <para>Windows 8 and later: This flag is ignored in Windows 8 and later.</para>
		/// </summary>
		BCRYPT_RNG_USE_ENTROPY_IN_BUFFER = 0x00000001,

		/// <summary>
		/// Use the system-preferred random number generator algorithm. The hAlgorithm parameter must be NULL.
		/// <para>BCRYPT_USE_SYSTEM_PREFERRED_RNG is only supported at PASSIVE_LEVEL IRQL. For more information, see Remarks.</para>
		/// <para>Windows Vista: This flag is not supported.</para>
		/// </summary>
		BCRYPT_USE_SYSTEM_PREFERRED_RNG = 0x00000002,
	}

	/// <summary>A set of flags that modify the behavior of this function</summary>
	[PInvokeData("bcrypt.h", MSDNShortId = "271fc084-6121-4666-b521-b849c7d7966c")]
	[Flags]
	public enum ImportFlags
	{
		/// <summary>Do not validate the public portion of the key pair.</summary>
		BCRYPT_NO_KEY_VALIDATION = 0x00000008,
	}

	/// <summary>Identifies the cryptographic interface to add the function to.</summary>
	[PInvokeData("bcrypt.h", MSDNShortId = "4f5b6db0-775d-42de-b9d9-a99fb11c89f2")]
	public enum InterfaceId
	{
		/// <summary>Add the function to the list of cipher functions.</summary>
		BCRYPT_CIPHER_INTERFACE = 0x00000001,

		/// <summary>Add the function to the list of hash functions.</summary>
		BCRYPT_HASH_INTERFACE = 0x00000002,

		/// <summary>Add the function to the list of asymmetric encryption functions.</summary>
		BCRYPT_ASYMMETRIC_ENCRYPTION_INTERFACE = 0x00000003,

		/// <summary>Add the function to the list of secret agreement functions.</summary>
		BCRYPT_SECRET_AGREEMENT_INTERFACE = 0x00000004,

		/// <summary>Add the function to the list of signature functions.</summary>
		BCRYPT_SIGNATURE_INTERFACE = 0x00000005,

		/// <summary>Add the function to the list of random number generator functions.</summary>
		BCRYPT_RNG_INTERFACE = 0x00000006,

		/// <summary>Undocumented</summary>
		BCRYPT_KEY_DERIVATION_INTERFACE = 0x00000007,

		/// <summary>Add the function to the list of key storage functions.</summary>
		NCRYPT_KEY_STORAGE_INTERFACE = 0x00010001,

		/// <summary>Add the function to the list of Schannel functions.</summary>
		NCRYPT_SCHANNEL_INTERFACE = 0x00010002,

		/// <summary>
		/// Add the function to the list of signature suites that Schannel will accept for TLS 1.2.
		/// <para>Windows Vista and Windows Server 2008: This value is not supported.</para>
		/// </summary>
		NCRYPT_SCHANNEL_SIGNATURE_INTERFACE = 0x00010003,

		/// <summary>Undocumented</summary>
		NCRYPT_KEY_PROTECTION_INTERFACE = 0x00010004,
	}

	/// <summary>Flags used with <c>BCryptKeyDerivation</c>.</summary>
	[PInvokeData("bcrypt.h", MSDNShortId = "D0B91FFE-2E72-4AE3-A84F-DC598C02CF53")]
	[Flags]
	public enum KeyDerivationFlags
	{
		/// <summary>
		/// Specifies that the target algorithm is AES and that the key therefore must be double expanded. This flag is only valid with
		/// the CAPI_KDF algorithm.
		/// </summary>
		BCRYPT_CAPI_AES_FLAG = 0,
	}

	/// <summary>The padding scheme.</summary>
	[Flags]
	public enum PaddingScheme : uint
	{
		/// <summary>The provider supports padding added by the router.</summary>
		BCRYPT_SUPPORTED_PAD_ROUTER = 0x00000001,

		/// <summary>The provider supports the PKCS1 encryption padding scheme.</summary>
		BCRYPT_SUPPORTED_PAD_PKCS1_ENC = 0x00000002,

		/// <summary>The provider supports the PKCS1 signature padding scheme.</summary>
		BCRYPT_SUPPORTED_PAD_PKCS1_SIG = 0x00000004,

		/// <summary>The provider supports the OAEP padding scheme.</summary>
		BCRYPT_SUPPORTED_PAD_OAEP = 0x00000008,

		/// <summary>The provider supports the PSS padding scheme.</summary>
		BCRYPT_SUPPORTED_PAD_PSS = 0x00000010,
	}

	/// <summary>Specifies the type of information to retrieve.</summary>
	public enum ProviderInfoType
	{
		/// <summary>Retrieve the user mode information for the provider.</summary>
		CRYPT_UM = 0x00000001,

		/// <summary>Retrieve the kernel mode information for the provider.</summary>
		CRYPT_KM = 0x00000002,

		/// <summary>Retrieve both the user mode and kernel mode information for the provider.</summary>
		CRYPT_MM = 0x00000003,

		/// <summary>Retrieve any information for the provider.</summary>
		CRYPT_ANY = 0x00000004,
	}

	/// <summary>A set of flags that modify the behavior of BCryptResolveProviders.</summary>
	[PInvokeData("bcrypt.h", MSDNShortId = "cf30f635-4918-4911-9db0-df90d26a2f1a")]
	[Flags]
	public enum ResolveProviderFlags
	{
		/// <summary>
		/// This function will retrieve all of the functions supported by each provider that meets the specified criteria. If this flag
		/// is not specified, this function will only retrieve the first function of the provider or providers that meet the specified criteria.
		/// </summary>
		CRYPT_ALL_FUNCTIONS = 1,

		/// <summary>
		/// This function will retrieve all of the providers that meet the specified criteria. If this flag is not specified, this
		/// function will only retrieve the first provider that is found that meets the specified criteria.
		/// </summary>
		CRYPT_ALL_PROVIDERS = 2,
	}

	/// <summary>
	/// <para>
	/// [ <c>BCryptAddContextFunction</c> is available for use in the operating systems specified in the Requirements section. It may be
	/// altered or unavailable in subsequent versions.]
	/// </para>
	/// <para>
	/// The <c>BCryptAddContextFunction</c> function adds a cryptographic function to the list of functions that are supported by an
	/// existing CNG context.
	/// </para>
	/// </summary>
	/// <param name="dwTable">
	/// <para>Identifies the configuration table that the context exists in. This can be one of the following values.</para>
	/// <list type="table">
	/// <listheader>
	/// <term>Value</term>
	/// <term>Meaning</term>
	/// </listheader>
	/// <item>
	/// <term>CRYPT_LOCAL</term>
	/// <term>The context exists in the local-machine configuration table.</term>
	/// </item>
	/// <item>
	/// <term>CRYPT_DOMAIN</term>
	/// <term>This value is not available for use.</term>
	/// </item>
	/// </list>
	/// </param>
	/// <param name="pszContext">
	/// <para>A pointer to a null-terminated Unicode string that contains the identifier of the context to add the function to.</para>
	/// </param>
	/// <param name="dwInterface">
	/// <para>Identifies the cryptographic interface to add the function to. This can be one of the following values.</para>
	/// <list type="table">
	/// <listheader>
	/// <term>Value</term>
	/// <term>Meaning</term>
	/// </listheader>
	/// <item>
	/// <term>BCRYPT_ASYMMETRIC_ENCRYPTION_INTERFACE</term>
	/// <term>Add the function to the list of asymmetric encryption functions.</term>
	/// </item>
	/// <item>
	/// <term>BCRYPT_CIPHER_INTERFACE</term>
	/// <term>Add the function to the list of cipher functions.</term>
	/// </item>
	/// <item>
	/// <term>BCRYPT_HASH_INTERFACE</term>
	/// <term>Add the function to the list of hash functions.</term>
	/// </item>
	/// <item>
	/// <term>BCRYPT_RNG_INTERFACE</term>
	/// <term>Add the function to the list of random number generator functions.</term>
	/// </item>
	/// <item>
	/// <term>BCRYPT_SECRET_AGREEMENT_INTERFACE</term>
	/// <term>Add the function to the list of secret agreement functions.</term>
	/// </item>
	/// <item>
	/// <term>BCRYPT_SIGNATURE_INTERFACE</term>
	/// <term>Add the function to the list of signature functions.</term>
	/// </item>
	/// <item>
	/// <term>NCRYPT_KEY_STORAGE_INTERFACE</term>
	/// <term>Add the function to the list of key storage functions.</term>
	/// </item>
	/// <item>
	/// <term>NCRYPT_SCHANNEL_INTERFACE</term>
	/// <term>Add the function to the list of Schannel functions.</term>
	/// </item>
	/// <item>
	/// <term>NCRYPT_SCHANNEL_SIGNATURE_INTERFACE</term>
	/// <term>
	/// Add the function to the list of signature suites that Schannel will accept for TLS 1.2. Windows Vista and Windows Server 2008:
	/// This value is not supported.
	/// </term>
	/// </item>
	/// </list>
	/// </param>
	/// <param name="pszFunction">
	/// <para>A pointer to a null-terminated Unicode string that contains the identifier of the cryptographic function to add.</para>
	/// </param>
	/// <param name="dwPosition">
	/// <para>
	/// Specifies the position in the list at which to insert this function. The function is inserted at this position ahead of any
	/// existing functions. The <c>CRYPT_PRIORITY_TOP</c> value is used to insert the function at the top of the list. The
	/// <c>CRYPT_PRIORITY_BOTTOM</c> value is used to insert the function at the end of the list.
	/// </para>
	/// </param>
	/// <returns>
	/// <para>Returns a status code that indicates the success or failure of the function.</para>
	/// <para>Possible return codes include, but are not limited to, the following.</para>
	/// <list type="table">
	/// <listheader>
	/// <term>Return code</term>
	/// <term>Description</term>
	/// </listheader>
	/// <item>
	/// <term>STATUS_SUCCESS</term>
	/// <term>The function was successful.</term>
	/// </item>
	/// <item>
	/// <term>STATUS_INVALID_PARAMETER</term>
	/// <term>One or more parameters are not valid.</term>
	/// </item>
	/// <item>
	/// <term>STATUS_NO_MEMORY</term>
	/// <term>A memory allocation failure occurred.</term>
	/// </item>
	/// <item>
	/// <term>STATUS_NOT_FOUND</term>
	/// <term>The context could not be found.</term>
	/// </item>
	/// </list>
	/// </returns>
	/// <remarks>
	/// <para>If the function added is already in the list, it will be removed and inserted at the new position.</para>
	/// <para><c>BCryptAddContextFunction</c> can be called only in user mode.</para>
	/// </remarks>
	// https://docs.microsoft.com/en-us/windows/desktop/api/bcrypt/nf-bcrypt-bcryptaddcontextfunction NTSTATUS BCryptAddContextFunction(
	// ULONG dwTable, LPCWSTR pszContext, ULONG dwInterface, LPCWSTR pszFunction, ULONG dwPosition );
	[DllImport(Lib.Bcrypt, SetLastError = false, ExactSpelling = true, CharSet = CharSet.Unicode)]
	[PInvokeData("bcrypt.h", MSDNShortId = "4f5b6db0-775d-42de-b9d9-a99fb11c89f2")]
	public static extern NTStatus BCryptAddContextFunction(ContextConfigTable dwTable, string pszContext, InterfaceId dwInterface, string pszFunction, CryptPriority dwPosition);

	/// <summary>
	/// <para>The <c>BCryptCloseAlgorithmProvider</c> function closes an algorithm provider.</para>
	/// </summary>
	/// <param name="hAlgorithm">
	/// <para>
	/// A handle that represents the algorithm provider to close. This handle is obtained by calling the BCryptOpenAlgorithmProvider function.
	/// </para>
	/// </param>
	/// <param name="dwFlags">
	/// <para>A set of flags that modify the behavior of this function. No flags are defined for this function.</para>
	/// </param>
	/// <returns>
	/// <para>Returns a status code that indicates the success or failure of the function.</para>
	/// <para>Possible return codes include, but are not limited to, the following.</para>
	/// <list type="table">
	/// <listheader>
	/// <term>Return code</term>
	/// <term>Description</term>
	/// </listheader>
	/// <item>
	/// <term>STATUS_SUCCESS</term>
	/// <term>The function was successful.</term>
	/// </item>
	/// <item>
	/// <term>STATUS_INVALID_HANDLE</term>
	/// <term>The algorithm handle in the hAlgorithm parameter is not valid.</term>
	/// </item>
	/// </list>
	/// </returns>
	/// <remarks>
	/// <para>
	/// <c>BCryptCloseAlgorithmProvider</c> can be called either from user mode or kernel mode. Kernel mode callers must be executing at
	/// <c>PASSIVE_LEVEL</c> IRQL.
	/// </para>
	/// <para>
	/// To call this function in kernel mode, use Cng.lib, which is part of the Driver Development Kit (DDK). For more information, see
	/// WDK and Developer Tools. <c>Windows Server 2008 and Windows Vista:</c> To call this function in kernel mode, use Ksecdd.lib.
	/// </para>
	/// </remarks>
	// https://docs.microsoft.com/en-us/windows/desktop/api/bcrypt/nf-bcrypt-bcryptclosealgorithmprovider NTSTATUS
	// BCryptCloseAlgorithmProvider( BCRYPT_ALG_HANDLE hAlgorithm, ULONG dwFlags );
	[DllImport(Lib.Bcrypt, SetLastError = false, ExactSpelling = true)]
	[PInvokeData("bcrypt.h", MSDNShortId = "def90d52-87e0-40e6-9c50-fd77177991d0")]
	public static extern NTStatus BCryptCloseAlgorithmProvider(BCRYPT_ALG_HANDLE hAlgorithm, uint dwFlags = 0);

	/// <summary>
	/// <para>
	/// [ <c>BCryptConfigureContext</c> is available for use in the operating systems specified in the Requirements section. It may be
	/// altered or unavailable in subsequent versions.]
	/// </para>
	/// <para>The <c>BCryptConfigureContext</c> function sets the configuration information for an existing CNG context.</para>
	/// </summary>
	/// <param name="dwTable">
	/// <para>Identifies the configuration table that the context exists in. This can be one of the following values.</para>
	/// <list type="table">
	/// <listheader>
	/// <term>Value</term>
	/// <term>Meaning</term>
	/// </listheader>
	/// <item>
	/// <term>CRYPT_LOCAL</term>
	/// <term>The context exists in the local-machine configuration table.</term>
	/// </item>
	/// <item>
	/// <term>CRYPT_DOMAIN</term>
	/// <term>This value is not available for use.</term>
	/// </item>
	/// </list>
	/// </param>
	/// <param name="pszContext">
	/// <para>
	/// A pointer to a null-terminated Unicode string that contains the identifier of the context to set the configuration information for.
	/// </para>
	/// </param>
	/// <param name="pConfig">
	/// <para>The address of a CRYPT_CONTEXT_CONFIG structure that contains the new context configuration information.</para>
	/// </param>
	/// <returns>
	/// <para>Returns a status code that indicates the success or failure of the function.</para>
	/// <para>Possible return codes include, but are not limited to, the following.</para>
	/// <list type="table">
	/// <listheader>
	/// <term>Return code</term>
	/// <term>Description</term>
	/// </listheader>
	/// <item>
	/// <term>STATUS_SUCCESS</term>
	/// <term>The function was successful.</term>
	/// </item>
	/// <item>
	/// <term>STATUS_INVALID_PARAMETER</term>
	/// <term>One or more parameters are not valid.</term>
	/// </item>
	/// <item>
	/// <term>STATUS_NO_MEMORY</term>
	/// <term>A memory allocation failure occurred.</term>
	/// </item>
	/// </list>
	/// </returns>
	/// <remarks>
	/// <para><c>BCryptConfigureContext</c> can be called only in user mode.</para>
	/// </remarks>
	// https://docs.microsoft.com/en-us/windows/desktop/api/bcrypt/nf-bcrypt-bcryptconfigurecontext NTSTATUS BCryptConfigureContext(
	// ULONG dwTable, LPCWSTR pszContext, PCRYPT_CONTEXT_CONFIG pConfig );
	[DllImport(Lib.Bcrypt, SetLastError = false, ExactSpelling = true)]
	[PInvokeData("bcrypt.h", MSDNShortId = "7989fefc-64fe-4ab3-9a48-7992edac171f")]
	public static extern NTStatus BCryptConfigureContext(ContextConfigTable dwTable, [MarshalAs(UnmanagedType.LPWStr)] string pszContext, in CRYPT_CONTEXT_CONFIG pConfig);

	/// <summary>
	/// <para>
	/// [ <c>BCryptConfigureContextFunction</c> is available for use in the operating systems specified in the Requirements section. It
	/// may be altered or unavailable in subsequent versions.]
	/// </para>
	/// <para>
	/// The <c>BCryptConfigureContextFunction</c> function sets the configuration information for the cryptographic function of an
	/// existing CNG context.
	/// </para>
	/// </summary>
	/// <param name="dwTable">
	/// <para>Identifies the configuration table that the context exists in. This can be one of the following values.</para>
	/// <list type="table">
	/// <listheader>
	/// <term>Value</term>
	/// <term>Meaning</term>
	/// </listheader>
	/// <item>
	/// <term>CRYPT_LOCAL</term>
	/// <term>The context exists in the local-machine configuration table.</term>
	/// </item>
	/// <item>
	/// <term>CRYPT_DOMAIN</term>
	/// <term>This value is not available for use.</term>
	/// </item>
	/// </list>
	/// </param>
	/// <param name="pszContext">
	/// <para>
	/// A pointer to a null-terminated Unicode string that contains the identifier of the context to set the cryptographic function
	/// configuration information for.
	/// </para>
	/// </param>
	/// <param name="dwInterface">
	/// <para>
	/// Identifies the cryptographic interface to set the function configuration information for. This can be one of the following values.
	/// </para>
	/// <list type="table">
	/// <listheader>
	/// <term>Value</term>
	/// <term>Meaning</term>
	/// </listheader>
	/// <item>
	/// <term>BCRYPT_ASYMMETRIC_ENCRYPTION_INTERFACE</term>
	/// <term>Set the function configuration information in the list of asymmetric encryption functions.</term>
	/// </item>
	/// <item>
	/// <term>BCRYPT_CIPHER_INTERFACE</term>
	/// <term>Set the function configuration information in the list of cipher functions.</term>
	/// </item>
	/// <item>
	/// <term>BCRYPT_HASH_INTERFACE</term>
	/// <term>Set the function configuration information in the list of hash functions.</term>
	/// </item>
	/// <item>
	/// <term>BCRYPT_RNG_INTERFACE</term>
	/// <term>Set the function configuration information in the list of random number generator functions.</term>
	/// </item>
	/// <item>
	/// <term>BCRYPT_SECRET_AGREEMENT_INTERFACE</term>
	/// <term>Set the function configuration information in the list of secret agreement functions.</term>
	/// </item>
	/// <item>
	/// <term>BCRYPT_SIGNATURE_INTERFACE</term>
	/// <term>Set the function configuration information in the list of signature functions.</term>
	/// </item>
	/// <item>
	/// <term>NCRYPT_KEY_STORAGE_INTERFACE</term>
	/// <term>Set the function configuration information in the list of key storage functions.</term>
	/// </item>
	/// <item>
	/// <term>NCRYPT_SCHANNEL_INTERFACE</term>
	/// <term>Set the function configuration information in the list of Schannel functions.</term>
	/// </item>
	/// <item>
	/// <term>NCRYPT_SCHANNEL_SIGNATURE_INTERFACE</term>
	/// <term>
	/// Set the function configuration information in the list of signature suites that Schannel accepts for TLS 1.2. Windows Vista and
	/// Windows Server 2008: This value is not supported.
	/// </term>
	/// </item>
	/// </list>
	/// </param>
	/// <param name="pszFunction">
	/// <para>
	/// A pointer to a null-terminated Unicode string that contains the identifier of the cryptographic function to set the configuration
	/// information for.
	/// </para>
	/// </param>
	/// <param name="pConfig">
	/// <para>The address of a CRYPT_CONTEXT_FUNCTION_CONFIG structure that contains the new function configuration information.</para>
	/// </param>
	/// <returns>
	/// <para>Returns a status code that indicates the success or failure of the function.</para>
	/// <para>Possible return codes include, but are not limited to, the following.</para>
	/// <list type="table">
	/// <listheader>
	/// <term>Return code</term>
	/// <term>Description</term>
	/// </listheader>
	/// <item>
	/// <term>STATUS_SUCCESS</term>
	/// <term>The function was successful.</term>
	/// </item>
	/// <item>
	/// <term>STATUS_INVALID_PARAMETER</term>
	/// <term>One or more parameters are not valid.</term>
	/// </item>
	/// <item>
	/// <term>STATUS_NO_MEMORY</term>
	/// <term>A memory allocation failure occurred.</term>
	/// </item>
	/// </list>
	/// </returns>
	/// <remarks>
	/// <para><c>BCryptConfigureContextFunction</c> can be called only in user mode.</para>
	/// </remarks>
	// https://docs.microsoft.com/en-us/windows/desktop/api/bcrypt/nf-bcrypt-bcryptconfigurecontextfunction NTSTATUS
	// BCryptConfigureContextFunction( ULONG dwTable, LPCWSTR pszContext, ULONG dwInterface, LPCWSTR pszFunction,
	// PCRYPT_CONTEXT_FUNCTION_CONFIG pConfig );
	[DllImport(Lib.Bcrypt, SetLastError = false, ExactSpelling = true, CharSet = CharSet.Unicode)]
	[PInvokeData("bcrypt.h", MSDNShortId = "e93c5e3e-3c63-49a3-8c8c-6510e10611ea")]
	public static extern NTStatus BCryptConfigureContextFunction(ContextConfigTable dwTable, string pszContext, InterfaceId dwInterface, string pszFunction, in CRYPT_CONTEXT_FUNCTION_CONFIG pConfig);

	/// <summary>
	/// <para>
	/// [ <c>BCryptCreateContext</c> is available for use in the operating systems specified in the Requirements section. It may be
	/// altered or unavailable in subsequent versions.]
	/// </para>
	/// <para>The <c>BCryptCreateContext</c> function creates a new CNG configuration context.</para>
	/// </summary>
	/// <param name="dwTable">
	/// <para>Identifies the configuration table to create the context in. This can be one of the following values.</para>
	/// <list type="table">
	/// <listheader>
	/// <term>Value</term>
	/// <term>Meaning</term>
	/// </listheader>
	/// <item>
	/// <term>CRYPT_LOCAL</term>
	/// <term>Create the context in the local-machine configuration table.</term>
	/// </item>
	/// <item>
	/// <term>CRYPT_DOMAIN</term>
	/// <term>This value is not available for use.</term>
	/// </item>
	/// </list>
	/// </param>
	/// <param name="pszContext">
	/// <para>A pointer to a null-terminated Unicode string that contains the identifier of the context to create.</para>
	/// </param>
	/// <param name="pConfig">
	/// <para>
	/// A pointer to a CRYPT_CONTEXT_CONFIG structure that contains additional configuration data for the new context. This parameter can
	/// be <c>NULL</c> if it is not needed.
	/// </para>
	/// </param>
	/// <returns>
	/// <para>Returns a status code that indicates the success or failure of the function.</para>
	/// <para>Possible return codes include, but are not limited to, the following.</para>
	/// <list type="table">
	/// <listheader>
	/// <term>Return code</term>
	/// <term>Description</term>
	/// </listheader>
	/// <item>
	/// <term>STATUS_SUCCESS</term>
	/// <term>The function was successful.</term>
	/// </item>
	/// <item>
	/// <term>STATUS_INVALID_PARAMETER</term>
	/// <term>One or more parameters are not valid.</term>
	/// </item>
	/// <item>
	/// <term>STATUS_NO_MEMORY</term>
	/// <term>A memory allocation failure occurred.</term>
	/// </item>
	/// </list>
	/// </returns>
	/// <remarks>
	/// <para><c>BCryptCreateContext</c> can be called only in user mode.</para>
	/// </remarks>
	// https://docs.microsoft.com/en-us/windows/desktop/api/bcrypt/nf-bcrypt-bcryptcreatecontext NTSTATUS BCryptCreateContext( ULONG
	// dwTable, LPCWSTR pszContext, PCRYPT_CONTEXT_CONFIG pConfig );
	[DllImport(Lib.Bcrypt, SetLastError = false, ExactSpelling = true)]
	[PInvokeData("bcrypt.h", MSDNShortId = "68f71010-0089-4433-bc89-f61f190e0bff")]
	public static extern NTStatus BCryptCreateContext(ContextConfigTable dwTable, [MarshalAs(UnmanagedType.LPWStr)] string pszContext, in CRYPT_CONTEXT_CONFIG pConfig);

	/// <summary>
	/// <para>
	/// [ <c>BCryptCreateContext</c> is available for use in the operating systems specified in the Requirements section. It may be
	/// altered or unavailable in subsequent versions.]
	/// </para>
	/// <para>The <c>BCryptCreateContext</c> function creates a new CNG configuration context.</para>
	/// </summary>
	/// <param name="dwTable">
	/// <para>Identifies the configuration table to create the context in. This can be one of the following values.</para>
	/// <list type="table">
	/// <listheader>
	/// <term>Value</term>
	/// <term>Meaning</term>
	/// </listheader>
	/// <item>
	/// <term>CRYPT_LOCAL</term>
	/// <term>Create the context in the local-machine configuration table.</term>
	/// </item>
	/// <item>
	/// <term>CRYPT_DOMAIN</term>
	/// <term>This value is not available for use.</term>
	/// </item>
	/// </list>
	/// </param>
	/// <param name="pszContext">
	/// <para>A pointer to a null-terminated Unicode string that contains the identifier of the context to create.</para>
	/// </param>
	/// <param name="pConfig">
	/// <para>
	/// A pointer to a CRYPT_CONTEXT_CONFIG structure that contains additional configuration data for the new context. This parameter can
	/// be <c>NULL</c> if it is not needed.
	/// </para>
	/// </param>
	/// <returns>
	/// <para>Returns a status code that indicates the success or failure of the function.</para>
	/// <para>Possible return codes include, but are not limited to, the following.</para>
	/// <list type="table">
	/// <listheader>
	/// <term>Return code</term>
	/// <term>Description</term>
	/// </listheader>
	/// <item>
	/// <term>STATUS_SUCCESS</term>
	/// <term>The function was successful.</term>
	/// </item>
	/// <item>
	/// <term>STATUS_INVALID_PARAMETER</term>
	/// <term>One or more parameters are not valid.</term>
	/// </item>
	/// <item>
	/// <term>STATUS_NO_MEMORY</term>
	/// <term>A memory allocation failure occurred.</term>
	/// </item>
	/// </list>
	/// </returns>
	/// <remarks>
	/// <para><c>BCryptCreateContext</c> can be called only in user mode.</para>
	/// </remarks>
	// https://docs.microsoft.com/en-us/windows/desktop/api/bcrypt/nf-bcrypt-bcryptcreatecontext NTSTATUS BCryptCreateContext( ULONG
	// dwTable, LPCWSTR pszContext, PCRYPT_CONTEXT_CONFIG pConfig );
	[DllImport(Lib.Bcrypt, SetLastError = false, ExactSpelling = true)]
	[PInvokeData("bcrypt.h", MSDNShortId = "68f71010-0089-4433-bc89-f61f190e0bff")]
	public static extern NTStatus BCryptCreateContext(ContextConfigTable dwTable, [MarshalAs(UnmanagedType.LPWStr)] string pszContext, IntPtr pConfig = default);

	/// <summary>
	/// <para>The <c>BCryptCreateHash</c> function is called to create a hash or Message Authentication Code (MAC) object.</para>
	/// </summary>
	/// <param name="hAlgorithm">
	/// <para>
	/// The handle of an algorithm provider created by using the BCryptOpenAlgorithmProvider function. The algorithm that was specified
	/// when the provider was created must support the hash interface.
	/// </para>
	/// </param>
	/// <param name="phHash">
	/// <para>
	/// A pointer to a <c>BCRYPT_HASH_HANDLE</c> value that receives a handle that represents the hash or MAC object. This handle is used
	/// in subsequent hashing or MAC functions, such as the BCryptHashData function. When you have finished using this handle, release it
	/// by passing it to the BCryptDestroyHash function.
	/// </para>
	/// </param>
	/// <param name="pbHashObject">
	/// <para>
	/// A pointer to a buffer that receives the hash or MAC object. The cbHashObject parameter contains the size of this buffer. The
	/// required size of this buffer can be obtained by calling the BCryptGetProperty function to get the <c>BCRYPT_OBJECT_LENGTH</c>
	/// property. This will provide the size of the hash or MAC object for the specified algorithm.
	/// </para>
	/// <para>This memory can only be freed after the handle pointed to by the phHash parameter is destroyed.</para>
	/// <para>
	/// If the value of this parameter is <c>NULL</c> and the value of the cbHashObject parameter is zero, the memory for the hash object
	/// is allocated and freed by this function. <c>Windows 7:</c> This memory management functionality is available beginning with
	/// Windows 7.
	/// </para>
	/// </param>
	/// <param name="cbHashObject">
	/// <para>The size, in bytes, of the pbHashObject buffer.</para>
	/// <para>
	/// If the value of this parameter is zero and the value of the pbHashObject parameter is <c>NULL</c>, the memory for the key object
	/// is allocated and freed by this function. <c>Windows 7:</c> This memory management functionality is available beginning with
	/// Windows 7.
	/// </para>
	/// <para>c</para>
	/// </param>
	/// <param name="pbSecret">
	/// <para>
	/// A pointer to a buffer that contains the key to use for the hash or MAC. The cbSecret parameter contains the size of this buffer.
	/// This key only applies to hash algorithms opened by the BCryptOpenAlgorithmProvider function by using the
	/// <c>BCRYPT_ALG_HANDLE_HMAC</c> flag. Otherwise, set this parameter to <c>NULL</c>.
	/// </para>
	/// </param>
	/// <param name="cbSecret">
	/// <para>The size, in bytes, of the pbSecret buffer. If no key is used, set this parameter to zero.</para>
	/// </param>
	/// <param name="dwFlags">
	/// <para>Flags that modify the behavior of the function. This can be zero or the following value.</para>
	/// <list type="table">
	/// <listheader>
	/// <term>Value</term>
	/// <term>Meaning</term>
	/// </listheader>
	/// <item>
	/// <term>BCRYPT_HASH_REUSABLE_FLAG</term>
	/// <term>
	/// Creates a reusable hashing object. The object can be used for a new hashing operation immediately after calling BCryptFinishHash.
	/// For more information, see Creating a Hash with CNG. Windows Server 2008 R2, Windows 7, Windows Server 2008 and Windows Vista:
	/// This flag is not supported.
	/// </term>
	/// </item>
	/// </list>
	/// </param>
	/// <returns>
	/// <para>Returns a status code that indicates the success or failure of the function.</para>
	/// <para>Possible return codes include, but are not limited to, the following.</para>
	/// <list type="table">
	/// <listheader>
	/// <term>Return code</term>
	/// <term>Description</term>
	/// </listheader>
	/// <item>
	/// <term>STATUS_SUCCESS</term>
	/// <term>The function was successful.</term>
	/// </item>
	/// <item>
	/// <term>STATUS_BUFFER_TOO_SMALL</term>
	/// <term>The size of the hash object specified by the cbHashObject parameter is not large enough to hold the hash object.</term>
	/// </item>
	/// <item>
	/// <term>STATUS_INVALID_HANDLE</term>
	/// <term>The algorithm handle in the hAlgorithm parameter is not valid.</term>
	/// </item>
	/// <item>
	/// <term>STATUS_INVALID_PARAMETER</term>
	/// <term>One or more parameters are not valid.</term>
	/// </item>
	/// <item>
	/// <term>STATUS_NOT_SUPPORTED</term>
	/// <term>The algorithm provider specified by the hAlgorithm parameter does not support the hash interface.</term>
	/// </item>
	/// </list>
	/// </returns>
	/// <remarks>
	/// <para>
	/// Depending on what processor modes a provider supports, <c>BCryptCreateHash</c> can be called either from user mode or kernel
	/// mode. Kernel mode callers can execute either at <c>PASSIVE_LEVEL</c> IRQL or <c>DISPATCH_LEVEL</c> IRQL. If the current IRQL
	/// level is <c>DISPATCH_LEVEL</c>, the handle provided in the hAlgorithm parameter must have been opened by using the
	/// <c>BCRYPT_PROV_DISPATCH</c> flag, and any pointers passed to the <c>BCryptCreateHash</c> function must refer to nonpaged (or
	/// locked) memory.
	/// </para>
	/// <para>
	/// To call this function in kernel mode, use Cng.lib, which is part of the Driver Development Kit (DDK). For more information, see
	/// WDK and Developer Tools. <c>Windows Server 2008 and Windows Vista:</c> To call this function in kernel mode, use Ksecdd.lib.
	/// </para>
	/// </remarks>
	// https://docs.microsoft.com/en-us/windows/desktop/api/bcrypt/nf-bcrypt-bcryptcreatehash NTSTATUS BCryptCreateHash(
	// BCRYPT_ALG_HANDLE hAlgorithm, BCRYPT_HASH_HANDLE *phHash, PUCHAR pbHashObject, ULONG cbHashObject, PUCHAR pbSecret, ULONG
	// cbSecret, ULONG dwFlags );
	[DllImport(Lib.Bcrypt, SetLastError = false, ExactSpelling = true)]
	[PInvokeData("bcrypt.h", MSDNShortId = "deb02f67-f3d3-4542-8245-fd4982c3190b")]
	public static extern NTStatus BCryptCreateHash(BCRYPT_ALG_HANDLE hAlgorithm, out SafeBCRYPT_HASH_HANDLE phHash, SafeAllocatedMemoryHandle pbHashObject,
		uint cbHashObject, SafeAllocatedMemoryHandle pbSecret, uint cbSecret, AlgProviderFlags dwFlags = 0);

	/// <summary>
	/// <para>The <c>BCryptCreateHash</c> function is called to create a hash or Message Authentication Code (MAC) object.</para>
	/// </summary>
	/// <param name="hAlgorithm">
	/// <para>
	/// The handle of an algorithm provider created by using the BCryptOpenAlgorithmProvider function. The algorithm that was specified
	/// when the provider was created must support the hash interface.
	/// </para>
	/// </param>
	/// <param name="phHash">
	/// <para>
	/// A pointer to a <c>BCRYPT_HASH_HANDLE</c> value that receives a handle that represents the hash or MAC object. This handle is used
	/// in subsequent hashing or MAC functions, such as the BCryptHashData function. When you have finished using this handle, release it
	/// by passing it to the BCryptDestroyHash function.
	/// </para>
	/// </param>
	/// <param name="pbHashObject">
	/// <para>
	/// A pointer to a buffer that receives the hash or MAC object. The cbHashObject parameter contains the size of this buffer. The
	/// required size of this buffer can be obtained by calling the BCryptGetProperty function to get the <c>BCRYPT_OBJECT_LENGTH</c>
	/// property. This will provide the size of the hash or MAC object for the specified algorithm.
	/// </para>
	/// <para>This memory can only be freed after the handle pointed to by the phHash parameter is destroyed.</para>
	/// <para>
	/// If the value of this parameter is <c>NULL</c> and the value of the cbHashObject parameter is zero, the memory for the hash object
	/// is allocated and freed by this function. <c>Windows 7:</c> This memory management functionality is available beginning with
	/// Windows 7.
	/// </para>
	/// </param>
	/// <param name="cbHashObject">
	/// <para>The size, in bytes, of the pbHashObject buffer.</para>
	/// <para>
	/// If the value of this parameter is zero and the value of the pbHashObject parameter is <c>NULL</c>, the memory for the key object
	/// is allocated and freed by this function. <c>Windows 7:</c> This memory management functionality is available beginning with
	/// Windows 7.
	/// </para>
	/// <para>c</para>
	/// </param>
	/// <param name="pbSecret">
	/// <para>
	/// A pointer to a buffer that contains the key to use for the hash or MAC. The cbSecret parameter contains the size of this buffer.
	/// This key only applies to hash algorithms opened by the BCryptOpenAlgorithmProvider function by using the
	/// <c>BCRYPT_ALG_HANDLE_HMAC</c> flag. Otherwise, set this parameter to <c>NULL</c>.
	/// </para>
	/// </param>
	/// <param name="cbSecret">
	/// <para>The size, in bytes, of the pbSecret buffer. If no key is used, set this parameter to zero.</para>
	/// </param>
	/// <param name="dwFlags">
	/// <para>Flags that modify the behavior of the function. This can be zero or the following value.</para>
	/// <list type="table">
	/// <listheader>
	/// <term>Value</term>
	/// <term>Meaning</term>
	/// </listheader>
	/// <item>
	/// <term>BCRYPT_HASH_REUSABLE_FLAG</term>
	/// <term>
	/// Creates a reusable hashing object. The object can be used for a new hashing operation immediately after calling BCryptFinishHash.
	/// For more information, see Creating a Hash with CNG. Windows Server 2008 R2, Windows 7, Windows Server 2008 and Windows Vista:
	/// This flag is not supported.
	/// </term>
	/// </item>
	/// </list>
	/// </param>
	/// <returns>
	/// <para>Returns a status code that indicates the success or failure of the function.</para>
	/// <para>Possible return codes include, but are not limited to, the following.</para>
	/// <list type="table">
	/// <listheader>
	/// <term>Return code</term>
	/// <term>Description</term>
	/// </listheader>
	/// <item>
	/// <term>STATUS_SUCCESS</term>
	/// <term>The function was successful.</term>
	/// </item>
	/// <item>
	/// <term>STATUS_BUFFER_TOO_SMALL</term>
	/// <term>The size of the hash object specified by the cbHashObject parameter is not large enough to hold the hash object.</term>
	/// </item>
	/// <item>
	/// <term>STATUS_INVALID_HANDLE</term>
	/// <term>The algorithm handle in the hAlgorithm parameter is not valid.</term>
	/// </item>
	/// <item>
	/// <term>STATUS_INVALID_PARAMETER</term>
	/// <term>One or more parameters are not valid.</term>
	/// </item>
	/// <item>
	/// <term>STATUS_NOT_SUPPORTED</term>
	/// <term>The algorithm provider specified by the hAlgorithm parameter does not support the hash interface.</term>
	/// </item>
	/// </list>
	/// </returns>
	/// <remarks>
	/// <para>
	/// Depending on what processor modes a provider supports, <c>BCryptCreateHash</c> can be called either from user mode or kernel
	/// mode. Kernel mode callers can execute either at <c>PASSIVE_LEVEL</c> IRQL or <c>DISPATCH_LEVEL</c> IRQL. If the current IRQL
	/// level is <c>DISPATCH_LEVEL</c>, the handle provided in the hAlgorithm parameter must have been opened by using the
	/// <c>BCRYPT_PROV_DISPATCH</c> flag, and any pointers passed to the <c>BCryptCreateHash</c> function must refer to nonpaged (or
	/// locked) memory.
	/// </para>
	/// <para>
	/// To call this function in kernel mode, use Cng.lib, which is part of the Driver Development Kit (DDK). For more information, see
	/// WDK and Developer Tools. <c>Windows Server 2008 and Windows Vista:</c> To call this function in kernel mode, use Ksecdd.lib.
	/// </para>
	/// </remarks>
	// https://docs.microsoft.com/en-us/windows/desktop/api/bcrypt/nf-bcrypt-bcryptcreatehash NTSTATUS BCryptCreateHash(
	// BCRYPT_ALG_HANDLE hAlgorithm, BCRYPT_HASH_HANDLE *phHash, PUCHAR pbHashObject, ULONG cbHashObject, PUCHAR pbSecret, ULONG
	// cbSecret, ULONG dwFlags );
	[DllImport(Lib.Bcrypt, SetLastError = false, ExactSpelling = true)]
	[PInvokeData("bcrypt.h", MSDNShortId = "deb02f67-f3d3-4542-8245-fd4982c3190b")]
	public static extern NTStatus BCryptCreateHash(BCRYPT_ALG_HANDLE hAlgorithm, out SafeBCRYPT_HASH_HANDLE phHash, SafeAllocatedMemoryHandle pbHashObject,
		uint cbHashObject, [Optional] IntPtr pbSecret, [Optional] uint cbSecret, AlgProviderFlags dwFlags = 0);

	/// <summary>
	/// <para>The <c>BCryptCreateHash</c> function is called to create a hash or Message Authentication Code (MAC) object.</para>
	/// </summary>
	/// <param name="hAlgorithm">
	/// <para>
	/// The handle of an algorithm provider created by using the BCryptOpenAlgorithmProvider function. The algorithm that was specified
	/// when the provider was created must support the hash interface.
	/// </para>
	/// </param>
	/// <param name="phHash">
	/// <para>
	/// A pointer to a <c>BCRYPT_HASH_HANDLE</c> value that receives a handle that represents the hash or MAC object. This handle is used
	/// in subsequent hashing or MAC functions, such as the BCryptHashData function. When you have finished using this handle, release it
	/// by passing it to the BCryptDestroyHash function.
	/// </para>
	/// </param>
	/// <param name="pbHashObject">
	/// <para>
	/// A pointer to a buffer that receives the hash or MAC object. The cbHashObject parameter contains the size of this buffer. The
	/// required size of this buffer can be obtained by calling the BCryptGetProperty function to get the <c>BCRYPT_OBJECT_LENGTH</c>
	/// property. This will provide the size of the hash or MAC object for the specified algorithm.
	/// </para>
	/// <para>This memory can only be freed after the handle pointed to by the phHash parameter is destroyed.</para>
	/// <para>
	/// If the value of this parameter is <c>NULL</c> and the value of the cbHashObject parameter is zero, the memory for the hash object
	/// is allocated and freed by this function. <c>Windows 7:</c> This memory management functionality is available beginning with
	/// Windows 7.
	/// </para>
	/// </param>
	/// <param name="cbHashObject">
	/// <para>The size, in bytes, of the pbHashObject buffer.</para>
	/// <para>
	/// If the value of this parameter is zero and the value of the pbHashObject parameter is <c>NULL</c>, the memory for the key object
	/// is allocated and freed by this function. <c>Windows 7:</c> This memory management functionality is available beginning with
	/// Windows 7.
	/// </para>
	/// <para>c</para>
	/// </param>
	/// <param name="pbSecret">
	/// <para>
	/// A pointer to a buffer that contains the key to use for the hash or MAC. The cbSecret parameter contains the size of this buffer.
	/// This key only applies to hash algorithms opened by the BCryptOpenAlgorithmProvider function by using the
	/// <c>BCRYPT_ALG_HANDLE_HMAC</c> flag. Otherwise, set this parameter to <c>NULL</c>.
	/// </para>
	/// </param>
	/// <param name="cbSecret">
	/// <para>The size, in bytes, of the pbSecret buffer. If no key is used, set this parameter to zero.</para>
	/// </param>
	/// <param name="dwFlags">
	/// <para>Flags that modify the behavior of the function. This can be zero or the following value.</para>
	/// <list type="table">
	/// <listheader>
	/// <term>Value</term>
	/// <term>Meaning</term>
	/// </listheader>
	/// <item>
	/// <term>BCRYPT_HASH_REUSABLE_FLAG</term>
	/// <term>
	/// Creates a reusable hashing object. The object can be used for a new hashing operation immediately after calling BCryptFinishHash.
	/// For more information, see Creating a Hash with CNG. Windows Server 2008 R2, Windows 7, Windows Server 2008 and Windows Vista:
	/// This flag is not supported.
	/// </term>
	/// </item>
	/// </list>
	/// </param>
	/// <returns>
	/// <para>Returns a status code that indicates the success or failure of the function.</para>
	/// <para>Possible return codes include, but are not limited to, the following.</para>
	/// <list type="table">
	/// <listheader>
	/// <term>Return code</term>
	/// <term>Description</term>
	/// </listheader>
	/// <item>
	/// <term>STATUS_SUCCESS</term>
	/// <term>The function was successful.</term>
	/// </item>
	/// <item>
	/// <term>STATUS_BUFFER_TOO_SMALL</term>
	/// <term>The size of the hash object specified by the cbHashObject parameter is not large enough to hold the hash object.</term>
	/// </item>
	/// <item>
	/// <term>STATUS_INVALID_HANDLE</term>
	/// <term>The algorithm handle in the hAlgorithm parameter is not valid.</term>
	/// </item>
	/// <item>
	/// <term>STATUS_INVALID_PARAMETER</term>
	/// <term>One or more parameters are not valid.</term>
	/// </item>
	/// <item>
	/// <term>STATUS_NOT_SUPPORTED</term>
	/// <term>The algorithm provider specified by the hAlgorithm parameter does not support the hash interface.</term>
	/// </item>
	/// </list>
	/// </returns>
	/// <remarks>
	/// <para>
	/// Depending on what processor modes a provider supports, <c>BCryptCreateHash</c> can be called either from user mode or kernel
	/// mode. Kernel mode callers can execute either at <c>PASSIVE_LEVEL</c> IRQL or <c>DISPATCH_LEVEL</c> IRQL. If the current IRQL
	/// level is <c>DISPATCH_LEVEL</c>, the handle provided in the hAlgorithm parameter must have been opened by using the
	/// <c>BCRYPT_PROV_DISPATCH</c> flag, and any pointers passed to the <c>BCryptCreateHash</c> function must refer to nonpaged (or
	/// locked) memory.
	/// </para>
	/// <para>
	/// To call this function in kernel mode, use Cng.lib, which is part of the Driver Development Kit (DDK). For more information, see
	/// WDK and Developer Tools. <c>Windows Server 2008 and Windows Vista:</c> To call this function in kernel mode, use Ksecdd.lib.
	/// </para>
	/// </remarks>
	// https://docs.microsoft.com/en-us/windows/desktop/api/bcrypt/nf-bcrypt-bcryptcreatehash NTSTATUS BCryptCreateHash(
	// BCRYPT_ALG_HANDLE hAlgorithm, BCRYPT_HASH_HANDLE *phHash, PUCHAR pbHashObject, ULONG cbHashObject, PUCHAR pbSecret, ULONG
	// cbSecret, ULONG dwFlags );
	[DllImport(Lib.Bcrypt, SetLastError = false, ExactSpelling = true)]
	[PInvokeData("bcrypt.h", MSDNShortId = "deb02f67-f3d3-4542-8245-fd4982c3190b", MinClient = PInvokeClient.Windows7)]
	public static extern NTStatus BCryptCreateHash(BCRYPT_ALG_HANDLE hAlgorithm, out SafeBCRYPT_HASH_HANDLE phHash, [Optional] IntPtr pbHashObject,
		[Optional] uint cbHashObject, [Optional] IntPtr pbSecret, [Optional] uint cbSecret, AlgProviderFlags dwFlags = 0);

	/// <summary>
	/// <para>
	/// The <c>BCryptCreateMultiHash</c> function creates a multi-hash state that allows for the parallel computation of multiple hash
	/// operations. This multi-hash state is used by the BCryptProcessMultiOperations function. The multi-hash state can be thought of as
	/// an array of hash objects, each of which is equivalent to one created by BCryptCreateHash.
	/// </para>
	/// <para>Parallel computations can greatly increase overall throughput, at the expense of increased latency for individual computations.</para>
	/// <para>
	/// Parallel hash computations are currently only implemented for SHA-256, SHA-384, and SHA-512. Other hash algorithms can be used
	/// with the parallel computation API but they run at the throughput of the sequential hash operations. The set of hash algorithms
	/// that can benefit from parallel computations might change in future updates.
	/// </para>
	/// </summary>
	/// <param name="hAlgorithm">
	/// <para>
	/// The algorithm handle used for all of the hash states in the multi-hash array. The algorithm handle must have been opened with the
	/// <c>BCYRPT_MULTI_FLAG</c> passed to the BCryptOpenAlgorithmProvider function. Alternatively, the caller can use the pseudo-handles.
	/// </para>
	/// </param>
	/// <param name="phHash">
	/// <para>
	/// A pointer to a <c>BCRYPT_HASH_HANDLE</c> value that receives a handle that represents the multi-hash state. This handle is used
	/// in subsequent operations such as BCryptProcessMultiOperations. When you have finished using this handle, release it by passing it
	/// to the BCryptDestroyHash function.
	/// </para>
	/// </param>
	/// <param name="nHashes">
	/// <para>
	/// The number of elements in the array. The multi-hash state that this function creates is able to perform parallel computations on
	/// nHashes different hash states.
	/// </para>
	/// </param>
	/// <param name="pbHashObject">
	/// <para>A pointer to a buffer that receives the multi-hash state.</para>
	/// <para>
	/// The size can be calculated from the <c>cbPerObject</c> and <c>cbPerElement</c> members of the BCRYPT_MULTI_OBJECT_LENGTH_STRUCT
	/// structure. The value is the following: .
	/// </para>
	/// <para>If pbHashObject is <c>NULL</c> and cbHashObject has a value of zero (0), the object buffer is automatically allocated.</para>
	/// </param>
	/// <param name="cbHashObject">
	/// <para>The size of the pbHashObject buffer, or zero if pbHashObject is <c>NULL</c>.</para>
	/// </param>
	/// <param name="pbSecret">
	/// <para>
	/// A pointer to a buffer that contains the key to use for the hash or MAC. The cbSecret parameter contains the size of this buffer.
	/// This key only applies to hash algorithms opened by the BCryptOpenAlgorithmProvider function by using the
	/// <c>BCRYPT_ALG_HANDLE_HMAC</c> flag. Otherwise, set this parameter to <c>NULL</c>.
	/// </para>
	/// <para>The same key is used for all elements of the array.</para>
	/// </param>
	/// <param name="cbSecret">
	/// <para>The size, in bytes, of the pbSecret buffer. If no key is used, set this parameter to zero.</para>
	/// </param>
	/// <param name="dwFlags">
	/// <para>
	/// Flags that modify the behavior of the function. This can be zero or the values below. Multi-hash objects are always reusable and
	/// always behave as if the <c>BCRYPT_HASH_REUSABLE_FLAG</c> was passed. This flag is supported here for consistency.
	/// </para>
	/// <list type="table">
	/// <listheader>
	/// <term>Value</term>
	/// <term>Meaning</term>
	/// </listheader>
	/// <item>
	/// <term>BCRYPT_HASH_REUSABLE_FLAG</term>
	/// <term>
	/// Creates a reusable hashing object. The object can be used for a new hashing operation immediately after calling BCryptFinishHash.
	/// For more information, see Creating a Hash with CNG.
	/// </term>
	/// </item>
	/// </list>
	/// </param>
	/// <returns>
	/// <para>None</para>
	/// </returns>
	/// <remarks>
	/// <para>
	/// Internally, parallel hash computations are done using single-instruction multiple-data (SIMD) instructions with up to 8 parallel
	/// computations at a time, depending on the hash algorithm and the CPU features available. To maximize performance, we recommend
	/// that the caller provide at least eight computations that can be processed in parallel.
	/// </para>
	/// <para>
	/// For computations of unequal length, providing more computations in parallel allows the implementation to schedule the
	/// computations better across the CPU registers. This can provide a throughput benefit. For optimal throughput, we recommend that
	/// the caller provide between eight and 100 computations. Select a lower value in that range only if all the hash computations are
	/// the same length.
	/// </para>
	/// <para>Multi-hashing is not supported for HMAC-MD2, HMAC-MD4, and GMAC.</para>
	/// </remarks>
	// https://docs.microsoft.com/en-us/windows/desktop/api/bcrypt/nf-bcrypt-bcryptcreatemultihash NTSTATUS BCryptCreateMultiHash(
	// BCRYPT_ALG_HANDLE hAlgorithm, BCRYPT_HASH_HANDLE *phHash, ULONG nHashes, PUCHAR pbHashObject, ULONG cbHashObject, PUCHAR pbSecret,
	// ULONG cbSecret, ULONG dwFlags );
	[DllImport(Lib.Bcrypt, SetLastError = false, ExactSpelling = true)]
	[PInvokeData("bcrypt.h", MSDNShortId = "AAF91460-AEFB-4E16-91EA-4A60272B3839")]
	public static extern NTStatus BCryptCreateMultiHash(BCRYPT_ALG_HANDLE hAlgorithm, out SafeBCRYPT_HASH_HANDLE phHash, uint nHashes,
		SafeAllocatedMemoryHandle pbHashObject, uint cbHashObject, SafeAllocatedMemoryHandle pbSecret, uint cbSecret, AlgProviderFlags dwFlags);

	/// <summary>
	/// <para>
	/// The <c>BCryptCreateMultiHash</c> function creates a multi-hash state that allows for the parallel computation of multiple hash
	/// operations. This multi-hash state is used by the BCryptProcessMultiOperations function. The multi-hash state can be thought of as
	/// an array of hash objects, each of which is equivalent to one created by BCryptCreateHash.
	/// </para>
	/// <para>Parallel computations can greatly increase overall throughput, at the expense of increased latency for individual computations.</para>
	/// <para>
	/// Parallel hash computations are currently only implemented for SHA-256, SHA-384, and SHA-512. Other hash algorithms can be used
	/// with the parallel computation API but they run at the throughput of the sequential hash operations. The set of hash algorithms
	/// that can benefit from parallel computations might change in future updates.
	/// </para>
	/// </summary>
	/// <param name="hAlgorithm">
	/// <para>
	/// The algorithm handle used for all of the hash states in the multi-hash array. The algorithm handle must have been opened with the
	/// <c>BCYRPT_MULTI_FLAG</c> passed to the BCryptOpenAlgorithmProvider function. Alternatively, the caller can use the pseudo-handles.
	/// </para>
	/// </param>
	/// <param name="phHash">
	/// <para>
	/// A pointer to a <c>BCRYPT_HASH_HANDLE</c> value that receives a handle that represents the multi-hash state. This handle is used
	/// in subsequent operations such as BCryptProcessMultiOperations. When you have finished using this handle, release it by passing it
	/// to the BCryptDestroyHash function.
	/// </para>
	/// </param>
	/// <param name="nHashes">
	/// <para>
	/// The number of elements in the array. The multi-hash state that this function creates is able to perform parallel computations on
	/// nHashes different hash states.
	/// </para>
	/// </param>
	/// <param name="pbHashObject">
	/// <para>A pointer to a buffer that receives the multi-hash state.</para>
	/// <para>
	/// The size can be calculated from the <c>cbPerObject</c> and <c>cbPerElement</c> members of the BCRYPT_MULTI_OBJECT_LENGTH_STRUCT
	/// structure. The value is the following: .
	/// </para>
	/// <para>If pbHashObject is <c>NULL</c> and cbHashObject has a value of zero (0), the object buffer is automatically allocated.</para>
	/// </param>
	/// <param name="cbHashObject">
	/// <para>The size of the pbHashObject buffer, or zero if pbHashObject is <c>NULL</c>.</para>
	/// </param>
	/// <param name="pbSecret">
	/// <para>
	/// A pointer to a buffer that contains the key to use for the hash or MAC. The cbSecret parameter contains the size of this buffer.
	/// This key only applies to hash algorithms opened by the BCryptOpenAlgorithmProvider function by using the
	/// <c>BCRYPT_ALG_HANDLE_HMAC</c> flag. Otherwise, set this parameter to <c>NULL</c>.
	/// </para>
	/// <para>The same key is used for all elements of the array.</para>
	/// </param>
	/// <param name="cbSecret">
	/// <para>The size, in bytes, of the pbSecret buffer. If no key is used, set this parameter to zero.</para>
	/// </param>
	/// <param name="dwFlags">
	/// <para>
	/// Flags that modify the behavior of the function. This can be zero or the values below. Multi-hash objects are always reusable and
	/// always behave as if the <c>BCRYPT_HASH_REUSABLE_FLAG</c> was passed. This flag is supported here for consistency.
	/// </para>
	/// <list type="table">
	/// <listheader>
	/// <term>Value</term>
	/// <term>Meaning</term>
	/// </listheader>
	/// <item>
	/// <term>BCRYPT_HASH_REUSABLE_FLAG</term>
	/// <term>
	/// Creates a reusable hashing object. The object can be used for a new hashing operation immediately after calling BCryptFinishHash.
	/// For more information, see Creating a Hash with CNG.
	/// </term>
	/// </item>
	/// </list>
	/// </param>
	/// <returns>
	/// <para>None</para>
	/// </returns>
	/// <remarks>
	/// <para>
	/// Internally, parallel hash computations are done using single-instruction multiple-data (SIMD) instructions with up to 8 parallel
	/// computations at a time, depending on the hash algorithm and the CPU features available. To maximize performance, we recommend
	/// that the caller provide at least eight computations that can be processed in parallel.
	/// </para>
	/// <para>
	/// For computations of unequal length, providing more computations in parallel allows the implementation to schedule the
	/// computations better across the CPU registers. This can provide a throughput benefit. For optimal throughput, we recommend that
	/// the caller provide between eight and 100 computations. Select a lower value in that range only if all the hash computations are
	/// the same length.
	/// </para>
	/// <para>Multi-hashing is not supported for HMAC-MD2, HMAC-MD4, and GMAC.</para>
	/// </remarks>
	// https://docs.microsoft.com/en-us/windows/desktop/api/bcrypt/nf-bcrypt-bcryptcreatemultihash NTSTATUS BCryptCreateMultiHash(
	// BCRYPT_ALG_HANDLE hAlgorithm, BCRYPT_HASH_HANDLE *phHash, ULONG nHashes, PUCHAR pbHashObject, ULONG cbHashObject, PUCHAR pbSecret,
	// ULONG cbSecret, ULONG dwFlags );
	[DllImport(Lib.Bcrypt, SetLastError = false, ExactSpelling = true)]
	[PInvokeData("bcrypt.h", MSDNShortId = "AAF91460-AEFB-4E16-91EA-4A60272B3839", MinClient = PInvokeClient.Windows7)]
	public static extern NTStatus BCryptCreateMultiHash(BCRYPT_ALG_HANDLE hAlgorithm, out SafeBCRYPT_HASH_HANDLE phHash, uint nHashes,
		[Optional] IntPtr pbHashObject, [Optional] uint cbHashObject, SafeAllocatedMemoryHandle pbSecret, uint cbSecret, AlgProviderFlags dwFlags);

	/// <summary>
	/// <para>The <c>BCryptDecrypt</c> function decrypts a block of data.</para>
	/// </summary>
	/// <param name="hKey">
	/// <para>
	/// The handle of the key to use to decrypt the data. This handle is obtained from one of the key creation functions, such as
	/// BCryptGenerateSymmetricKey, BCryptGenerateKeyPair, or BCryptImportKey.
	/// </para>
	/// </param>
	/// <param name="pbInput">
	/// <para>
	/// The address of a buffer that contains the ciphertext to be decrypted. The cbInput parameter contains the size of the ciphertext
	/// to decrypt. For more information, see Remarks.
	/// </para>
	/// </param>
	/// <param name="cbInput">
	/// <para>The number of bytes in the pbInput buffer to decrypt.</para>
	/// </param>
	/// <param name="pPaddingInfo">
	/// <para>
	/// A pointer to a structure that contains padding information. This parameter is only used with asymmetric keys and authenticated
	/// encryption modes. If an authenticated encryption mode is used, this parameter must point to a
	/// BCRYPT_AUTHENTICATED_CIPHER_MODE_INFO structure. If asymmetric keys are used, the type of structure this parameter points to is
	/// determined by the value of the dwFlags parameter. Otherwise, the parameter must be set to <c>NULL</c>.
	/// </para>
	/// </param>
	/// <param name="pbIV">
	/// <para>
	/// The address of a buffer that contains the initialization vector (IV) to use during decryption. The cbIV parameter contains the
	/// size of this buffer. This function will modify the contents of this buffer. If you need to reuse the IV later, make sure you make
	/// a copy of this buffer before calling this function.
	/// </para>
	/// <para>This parameter is optional and can be <c>NULL</c> if no IV is used.</para>
	/// <para>
	/// The required size of the IV can be obtained by calling the BCryptGetProperty function to get the <c>BCRYPT_BLOCK_LENGTH</c>
	/// property. This will provide the size of a block for the algorithm, which is also the size of the IV.
	/// </para>
	/// </param>
	/// <param name="cbIV">
	/// <para>The size, in bytes, of the pbIV buffer.</para>
	/// </param>
	/// <param name="pbOutput">
	/// <para>
	/// The address of a buffer to receive the plaintext produced by this function. The cbOutput parameter contains the size of this
	/// buffer. For more information, see Remarks.
	/// </para>
	/// <para>
	/// If this parameter is <c>NULL</c>, the <c>BCryptDecrypt</c> function calculates the size required for the plaintext of the
	/// encrypted data passed in the pbInput parameter. In this case, the location pointed to by the pcbResult parameter contains this
	/// size, and the function returns <c>STATUS_SUCCESS</c>.
	/// </para>
	/// <para>
	/// If the values of both the pbOutput and pbInput parameters are <c>NULL</c>, an error is returned unless an authenticated
	/// encryption algorithm is in use. In the latter case, the call is treated as an authenticated encryption call with zero length
	/// data, and the authentication tag, passed in the pPaddingInfo parameter, is verified.
	/// </para>
	/// </param>
	/// <param name="cbOutput">
	/// <para>The size, in bytes, of the pbOutput buffer. This parameter is ignored if the pbOutput parameter is <c>NULL</c>.</para>
	/// </param>
	/// <param name="pcbResult">
	/// <para>
	/// A pointer to a <c>ULONG</c> variable to receive the number of bytes copied to the pbOutput buffer. If pbOutput is <c>NULL</c>,
	/// this receives the size, in bytes, required for the plaintext.
	/// </para>
	/// </param>
	/// <param name="dwFlags">
	/// <para>
	/// A set of flags that modify the behavior of this function. The allowed set of flags depends on the type of key specified by the
	/// hKey parameter.
	/// </para>
	/// <para>If the key is a symmetric key, this can be zero or the following value.</para>
	/// <list type="table">
	/// <listheader>
	/// <term>Value</term>
	/// <term>Meaning</term>
	/// </listheader>
	/// <item>
	/// <term>BCRYPT_BLOCK_PADDING</term>
	/// <term>
	/// The data was padded to the next block size when it was encrypted. If this flag was used with the BCryptEncrypt function, it must
	/// also be specified in this function. This flag must not be used with the authenticated encryption modes (AES-CCM and AES-GCM).
	/// </term>
	/// </item>
	/// </list>
	/// <para>If the key is an asymmetric key, this can be one of the following values.</para>
	/// <list type="table">
	/// <listheader>
	/// <term>Value</term>
	/// <term>Meaning</term>
	/// </listheader>
	/// <item>
	/// <term>BCRYPT_PAD_NONE</term>
	/// <term>
	/// Do not use any padding. The pPaddingInfo parameter is not used. The cbInput parameter must be a multiple of the algorithm's block
	/// size. The block size can be obtained by calling the BCryptGetProperty function to get the BCRYPT_BLOCK_LENGTH property for the
	/// key. This will provide the size of a block for the algorithm.
	/// </term>
	/// </item>
	/// <item>
	/// <term>BCRYPT_PAD_OAEP</term>
	/// <term>
	/// The Optimal Asymmetric Encryption Padding (OAEP) scheme was used when the data was encrypted. The pPaddingInfo parameter is a
	/// pointer to a BCRYPT_OAEP_PADDING_INFO structure.
	/// </term>
	/// </item>
	/// <item>
	/// <term>BCRYPT_PAD_PKCS1</term>
	/// <term>The data was padded with a random number when the data was encrypted. The pPaddingInfo parameter is not used.</term>
	/// </item>
	/// </list>
	/// </param>
	/// <returns>
	/// <para>Returns a status code that indicates the success or failure of the function.</para>
	/// <para>Possible return codes include, but are not limited to, the following.</para>
	/// <list type="table">
	/// <listheader>
	/// <term>Return code</term>
	/// <term>Description</term>
	/// </listheader>
	/// <item>
	/// <term>STATUS_SUCCESS</term>
	/// <term>The function was successful.</term>
	/// </item>
	/// <item>
	/// <term>STATUS_AUTH_TAG_MISMATCH</term>
	/// <term>The computed authentication tag did not match the value supplied in the pPaddingInfo parameter.</term>
	/// </item>
	/// <item>
	/// <term>STATUS_BUFFER_TOO_SMALL</term>
	/// <term>The size specified by the cbOutput parameter is not large enough to hold the ciphertext.</term>
	/// </item>
	/// <item>
	/// <term>STATUS_INVALID_BUFFER_SIZE</term>
	/// <term>
	/// The cbInput parameter is not a multiple of the algorithm's block size, and the BCRYPT_BLOCK_PADDING flag was not specified in the
	/// dwFlags parameter.
	/// </term>
	/// </item>
	/// <item>
	/// <term>STATUS_INVALID_HANDLE</term>
	/// <term>The key handle in the hKey parameter is not valid.</term>
	/// </item>
	/// <item>
	/// <term>STATUS_INVALID_PARAMETER</term>
	/// <term>One or more parameters are not valid.</term>
	/// </item>
	/// <item>
	/// <term>STATUS_NOT_SUPPORTED</term>
	/// <term>The algorithm does not support decryption.</term>
	/// </item>
	/// </list>
	/// </returns>
	/// <remarks>
	/// <para>
	/// The pbInput and pbOutput parameters can point to the same buffer. In this case, this function will perform the decryption in place.
	/// </para>
	/// <para>
	/// Depending on what processor modes a provider supports, <c>BCryptDecrypt</c> can be called either from user mode or kernel mode.
	/// Kernel mode callers can execute either at <c>PASSIVE_LEVEL</c> IRQL or <c>DISPATCH_LEVEL</c> IRQL. If the current IRQL level is
	/// <c>DISPATCH_LEVEL</c>, the handle provided in the hKey parameter must be derived from an algorithm handle returned by a provider
	/// that was opened with the <c>BCRYPT_PROV_DISPATCH</c> flag, and any pointers passed to the <c>BCryptDecrypt</c> function must
	/// refer to nonpaged (or locked) memory.
	/// </para>
	/// <para>
	/// To call this function in kernel mode, use Cng.lib, which is part of the Driver Development Kit (DDK). For more information, see
	/// WDK and Developer Tools. <c>Windows Server 2008 and Windows Vista:</c> To call this function in kernel mode, use Ksecdd.lib.
	/// </para>
	/// </remarks>
	// https://docs.microsoft.com/en-us/windows/desktop/api/bcrypt/nf-bcrypt-bcryptdecrypt NTSTATUS BCryptDecrypt( BCRYPT_KEY_HANDLE
	// hKey, PUCHAR pbInput, ULONG cbInput, VOID *pPaddingInfo, PUCHAR pbIV, ULONG cbIV, PUCHAR pbOutput, ULONG cbOutput, ULONG
	// *pcbResult, ULONG dwFlags );
	[DllImport(Lib.Bcrypt, SetLastError = false, ExactSpelling = true)]
	[PInvokeData("bcrypt.h", MSDNShortId = "62286f6b-0d57-4691-83fc-2b9a9740af71")]
	public static extern NTStatus BCryptDecrypt(BCRYPT_KEY_HANDLE hKey, SafeAllocatedMemoryHandle pbInput, uint cbInput, IntPtr pPaddingInfo,
		SafeAllocatedMemoryHandle pbIV, uint cbIV, [Optional] IntPtr pbOutput, [Optional] uint cbOutput, out uint pcbResult, EncryptFlags dwFlags);

	/// <summary>
	/// <para>The <c>BCryptDecrypt</c> function decrypts a block of data.</para>
	/// </summary>
	/// <param name="hKey">
	/// <para>
	/// The handle of the key to use to decrypt the data. This handle is obtained from one of the key creation functions, such as
	/// BCryptGenerateSymmetricKey, BCryptGenerateKeyPair, or BCryptImportKey.
	/// </para>
	/// </param>
	/// <param name="pbInput">
	/// <para>
	/// The address of a buffer that contains the ciphertext to be decrypted. The cbInput parameter contains the size of the ciphertext
	/// to decrypt. For more information, see Remarks.
	/// </para>
	/// </param>
	/// <param name="cbInput">
	/// <para>The number of bytes in the pbInput buffer to decrypt.</para>
	/// </param>
	/// <param name="pPaddingInfo">
	/// <para>
	/// A pointer to a structure that contains padding information. This parameter is only used with asymmetric keys and authenticated
	/// encryption modes. If an authenticated encryption mode is used, this parameter must point to a
	/// BCRYPT_AUTHENTICATED_CIPHER_MODE_INFO structure. If asymmetric keys are used, the type of structure this parameter points to is
	/// determined by the value of the dwFlags parameter. Otherwise, the parameter must be set to <c>NULL</c>.
	/// </para>
	/// </param>
	/// <param name="pbIV">
	/// <para>
	/// The address of a buffer that contains the initialization vector (IV) to use during decryption. The cbIV parameter contains the
	/// size of this buffer. This function will modify the contents of this buffer. If you need to reuse the IV later, make sure you make
	/// a copy of this buffer before calling this function.
	/// </para>
	/// <para>This parameter is optional and can be <c>NULL</c> if no IV is used.</para>
	/// <para>
	/// The required size of the IV can be obtained by calling the BCryptGetProperty function to get the <c>BCRYPT_BLOCK_LENGTH</c>
	/// property. This will provide the size of a block for the algorithm, which is also the size of the IV.
	/// </para>
	/// </param>
	/// <param name="cbIV">
	/// <para>The size, in bytes, of the pbIV buffer.</para>
	/// </param>
	/// <param name="pbOutput">
	/// <para>
	/// The address of a buffer to receive the plaintext produced by this function. The cbOutput parameter contains the size of this
	/// buffer. For more information, see Remarks.
	/// </para>
	/// <para>
	/// If this parameter is <c>NULL</c>, the <c>BCryptDecrypt</c> function calculates the size required for the plaintext of the
	/// encrypted data passed in the pbInput parameter. In this case, the location pointed to by the pcbResult parameter contains this
	/// size, and the function returns <c>STATUS_SUCCESS</c>.
	/// </para>
	/// <para>
	/// If the values of both the pbOutput and pbInput parameters are <c>NULL</c>, an error is returned unless an authenticated
	/// encryption algorithm is in use. In the latter case, the call is treated as an authenticated encryption call with zero length
	/// data, and the authentication tag, passed in the pPaddingInfo parameter, is verified.
	/// </para>
	/// </param>
	/// <param name="cbOutput">
	/// <para>The size, in bytes, of the pbOutput buffer. This parameter is ignored if the pbOutput parameter is <c>NULL</c>.</para>
	/// </param>
	/// <param name="pcbResult">
	/// <para>
	/// A pointer to a <c>ULONG</c> variable to receive the number of bytes copied to the pbOutput buffer. If pbOutput is <c>NULL</c>,
	/// this receives the size, in bytes, required for the plaintext.
	/// </para>
	/// </param>
	/// <param name="dwFlags">
	/// <para>
	/// A set of flags that modify the behavior of this function. The allowed set of flags depends on the type of key specified by the
	/// hKey parameter.
	/// </para>
	/// <para>If the key is a symmetric key, this can be zero or the following value.</para>
	/// <list type="table">
	/// <listheader>
	/// <term>Value</term>
	/// <term>Meaning</term>
	/// </listheader>
	/// <item>
	/// <term>BCRYPT_BLOCK_PADDING</term>
	/// <term>
	/// The data was padded to the next block size when it was encrypted. If this flag was used with the BCryptEncrypt function, it must
	/// also be specified in this function. This flag must not be used with the authenticated encryption modes (AES-CCM and AES-GCM).
	/// </term>
	/// </item>
	/// </list>
	/// <para>If the key is an asymmetric key, this can be one of the following values.</para>
	/// <list type="table">
	/// <listheader>
	/// <term>Value</term>
	/// <term>Meaning</term>
	/// </listheader>
	/// <item>
	/// <term>BCRYPT_PAD_NONE</term>
	/// <term>
	/// Do not use any padding. The pPaddingInfo parameter is not used. The cbInput parameter must be a multiple of the algorithm's block
	/// size. The block size can be obtained by calling the BCryptGetProperty function to get the BCRYPT_BLOCK_LENGTH property for the
	/// key. This will provide the size of a block for the algorithm.
	/// </term>
	/// </item>
	/// <item>
	/// <term>BCRYPT_PAD_OAEP</term>
	/// <term>
	/// The Optimal Asymmetric Encryption Padding (OAEP) scheme was used when the data was encrypted. The pPaddingInfo parameter is a
	/// pointer to a BCRYPT_OAEP_PADDING_INFO structure.
	/// </term>
	/// </item>
	/// <item>
	/// <term>BCRYPT_PAD_PKCS1</term>
	/// <term>The data was padded with a random number when the data was encrypted. The pPaddingInfo parameter is not used.</term>
	/// </item>
	/// </list>
	/// </param>
	/// <returns>
	/// <para>Returns a status code that indicates the success or failure of the function.</para>
	/// <para>Possible return codes include, but are not limited to, the following.</para>
	/// <list type="table">
	/// <listheader>
	/// <term>Return code</term>
	/// <term>Description</term>
	/// </listheader>
	/// <item>
	/// <term>STATUS_SUCCESS</term>
	/// <term>The function was successful.</term>
	/// </item>
	/// <item>
	/// <term>STATUS_AUTH_TAG_MISMATCH</term>
	/// <term>The computed authentication tag did not match the value supplied in the pPaddingInfo parameter.</term>
	/// </item>
	/// <item>
	/// <term>STATUS_BUFFER_TOO_SMALL</term>
	/// <term>The size specified by the cbOutput parameter is not large enough to hold the ciphertext.</term>
	/// </item>
	/// <item>
	/// <term>STATUS_INVALID_BUFFER_SIZE</term>
	/// <term>
	/// The cbInput parameter is not a multiple of the algorithm's block size, and the BCRYPT_BLOCK_PADDING flag was not specified in the
	/// dwFlags parameter.
	/// </term>
	/// </item>
	/// <item>
	/// <term>STATUS_INVALID_HANDLE</term>
	/// <term>The key handle in the hKey parameter is not valid.</term>
	/// </item>
	/// <item>
	/// <term>STATUS_INVALID_PARAMETER</term>
	/// <term>One or more parameters are not valid.</term>
	/// </item>
	/// <item>
	/// <term>STATUS_NOT_SUPPORTED</term>
	/// <term>The algorithm does not support decryption.</term>
	/// </item>
	/// </list>
	/// </returns>
	/// <remarks>
	/// <para>
	/// The pbInput and pbOutput parameters can point to the same buffer. In this case, this function will perform the decryption in place.
	/// </para>
	/// <para>
	/// Depending on what processor modes a provider supports, <c>BCryptDecrypt</c> can be called either from user mode or kernel mode.
	/// Kernel mode callers can execute either at <c>PASSIVE_LEVEL</c> IRQL or <c>DISPATCH_LEVEL</c> IRQL. If the current IRQL level is
	/// <c>DISPATCH_LEVEL</c>, the handle provided in the hKey parameter must be derived from an algorithm handle returned by a provider
	/// that was opened with the <c>BCRYPT_PROV_DISPATCH</c> flag, and any pointers passed to the <c>BCryptDecrypt</c> function must
	/// refer to nonpaged (or locked) memory.
	/// </para>
	/// <para>
	/// To call this function in kernel mode, use Cng.lib, which is part of the Driver Development Kit (DDK). For more information, see
	/// WDK and Developer Tools. <c>Windows Server 2008 and Windows Vista:</c> To call this function in kernel mode, use Ksecdd.lib.
	/// </para>
	/// </remarks>
	// https://docs.microsoft.com/en-us/windows/desktop/api/bcrypt/nf-bcrypt-bcryptdecrypt NTSTATUS BCryptDecrypt( BCRYPT_KEY_HANDLE
	// hKey, PUCHAR pbInput, ULONG cbInput, VOID *pPaddingInfo, PUCHAR pbIV, ULONG cbIV, PUCHAR pbOutput, ULONG cbOutput, ULONG
	// *pcbResult, ULONG dwFlags );
	[DllImport(Lib.Bcrypt, SetLastError = false, ExactSpelling = true)]
	[PInvokeData("bcrypt.h", MSDNShortId = "62286f6b-0d57-4691-83fc-2b9a9740af71")]
	public static extern NTStatus BCryptDecrypt(BCRYPT_KEY_HANDLE hKey, SafeAllocatedMemoryHandle pbInput, uint cbInput, IntPtr pPaddingInfo,
		SafeAllocatedMemoryHandle pbIV, uint cbIV, SafeAllocatedMemoryHandle pbOutput, uint cbOutput, out uint pcbResult, EncryptFlags dwFlags);

	/// <summary>
	/// <para>
	/// [ <c>BCryptDeleteContext</c> is available for use in the operating systems specified in the Requirements section. It may be
	/// altered or unavailable in subsequent versions.]
	/// </para>
	/// <para>The <c>BCryptDeleteContext</c> function deletes an existing CNG configuration context.</para>
	/// </summary>
	/// <param name="dwTable">
	/// <para>Identifies the configuration table to delete the context from. This can be one of the following values.</para>
	/// <list type="table">
	/// <listheader>
	/// <term>Value</term>
	/// <term>Meaning</term>
	/// </listheader>
	/// <item>
	/// <term>CRYPT_LOCAL</term>
	/// <term>Delete the context from the local-machine configuration table.</term>
	/// </item>
	/// <item>
	/// <term>CRYPT_DOMAIN</term>
	/// <term>This value is not available for use.</term>
	/// </item>
	/// </list>
	/// </param>
	/// <param name="pszContext">
	/// <para>A pointer to a null-terminated Unicode string that contains the identifier of the context to delete.</para>
	/// </param>
	/// <returns>
	/// <para>Returns a status code that indicates the success or failure of the function.</para>
	/// <para>Possible return codes include, but are not limited to, the following.</para>
	/// <list type="table">
	/// <listheader>
	/// <term>Return code</term>
	/// <term>Description</term>
	/// </listheader>
	/// <item>
	/// <term>STATUS_SUCCESS</term>
	/// <term>The function was successful.</term>
	/// </item>
	/// <item>
	/// <term>STATUS_INVALID_PARAMETER</term>
	/// <term>One or more parameters are not valid.</term>
	/// </item>
	/// <item>
	/// <term>STATUS_NO_MEMORY</term>
	/// <term>A memory allocation failure occurred.</term>
	/// </item>
	/// </list>
	/// </returns>
	/// <remarks>
	/// <para><c>BCryptDeleteContext</c> can be called only in user mode.</para>
	/// </remarks>
	// https://docs.microsoft.com/en-us/windows/desktop/api/bcrypt/nf-bcrypt-bcryptdeletecontext NTSTATUS BCryptDeleteContext( ULONG
	// dwTable, LPCWSTR pszContext );
	[DllImport(Lib.Bcrypt, SetLastError = false, ExactSpelling = true)]
	[PInvokeData("bcrypt.h", MSDNShortId = "6a250bed-0ea4-4cae-86e6-f0cea95dc56e")]
	public static extern NTStatus BCryptDeleteContext(ContextConfigTable dwTable, [MarshalAs(UnmanagedType.LPWStr)] string pszContext);

	/// <summary>The <c>BCryptDeriveKey</c> function derives a key from a secret agreement value.</summary>
	/// <param name="hSharedSecret">
	/// The secret agreement handle to create the key from. This handle is obtained from the BCryptSecretAgreement function.
	/// </param>
	/// <param name="pwszKDF">
	/// <para>
	/// A pointer to a null-terminated Unicode string that identifies the key derivation function (KDF) to use to derive the key. This
	/// can be one of the following strings.
	/// </para>
	/// <para><b>BCRYPT_KDF_HASH (L"HASH")</b></para>
	/// <para>Use the hash key derivation function.</para>
	/// <para>
	/// If the cbDerivedKey parameter is less than the size of the derived key, this function will only copy the specified number of
	/// bytes to the pbDerivedKey buffer. If the cbDerivedKey parameter is greater than the size of the derived key, this function will
	/// copy the key to the pbDerivedKey buffer and set the variable pointed to by the pcbResult to the actual number of bytes copied.
	/// </para>
	/// <para>
	/// The parameters identified by the pParameterList parameter either can or must contain the following parameters, as indicated by
	/// the Required or optional column.
	/// </para>
	/// <list type="table">
	/// <listheader>
	/// <term>Parameter</term>
	/// <term>Description</term>
	/// <term>Required or optional</term>
	/// </listheader>
	/// <item>
	/// <term>KDF_HASH_ALGORITHM</term>
	/// <term>
	/// A null-terminated Unicode string that identifies the hash algorithm to use. This can be one of the standard hash algorithm
	/// identifiers from CNG Algorithm Identifiers or the identifier for another registered hash algorithm. If this parameter is not
	/// specified, the SHA1 hash algorithm is used.
	/// </term>
	/// <term>Optional</term>
	/// </item>
	/// <item>
	/// <term>KDF_SECRET_PREPEND</term>
	/// <term>A value to add to the beginning of the message input to the hash function. For more information, see Remarks.</term>
	/// <term>Optional</term>
	/// </item>
	/// <item>
	/// <term>KDF_SECRET_APPEND</term>
	/// <term>A value to add to the end of the message input to the hash function. For more information, see Remarks.</term>
	/// <term>Optional</term>
	/// </item>
	/// </list>
	/// <para>The call to the KDF is made as shown in the following pseudocode.</para>
	/// <code lang="none">
	/// KDF-Prepend = KDF_SECRET_PREPEND[0] +
	/// KDF_SECRET_PREPEND[1] +
	/// ... +
	/// KDF_SECRET_PREPEND[n]
	///
	/// KDF-Append = KDF_SECRET_APPEND[0] +
	/// KDF_SECRET_APPEND[1] +
	/// ... +
	/// KDF_SECRET_APPEND[n]
	///
	/// KDF-Output = Hash(
	/// KDF-Prepend +
	///
	/// hSharedSecret +
	///
	/// KDF-Append)
	/// </code>
	/// <para><b>BCRYPT_KDF_HMAC (L"HMAC")</b></para>
	/// <para>Use the Hash-Based Message Authentication Code (HMAC) key derivation function.</para>
	/// <para>
	/// If the cbDerivedKey parameter is less than the size of the derived key, this function will only copy the specified number of
	/// bytes to the pbDerivedKey buffer. If the cbDerivedKey parameter is greater than the size of the derived key, this function will
	/// copy the key to the pbDerivedKey buffer and set the variable pointed to by the pcbResult to the actual number of bytes copied.
	/// </para>
	/// <para>
	/// The parameters identified by the pParameterList parameter either can or must contain the following parameters, as indicated by
	/// the Required or optional column.
	/// </para>
	/// <list type="table">
	/// <listheader>
	/// <term>Parameter</term>
	/// <term>Description</term>
	/// <term>Required or optional</term>
	/// </listheader>
	/// <item>
	/// <term>KDF_HASH_ALGORITHM</term>
	/// <term>
	/// A null-terminated Unicode string that identifies the hash algorithm to use. This can be one of the standard hash algorithm
	/// identifiers from CNG Algorithm Identifiers or the identifier for another registered hash algorithm. If this parameter is not
	/// specified, the SHA1 hash algorithm is used.
	/// </term>
	/// <term>Optional</term>
	/// </item>
	/// <item>
	/// <term>KDF_HMAC_KEY</term>
	/// <term>The key to use for the pseudo-random function (PRF).</term>
	/// <term>Optional</term>
	/// </item>
	/// <item>
	/// <term>KDF_SECRET_PREPEND</term>
	/// <term>A value to add to the beginning of the message input to the hash function. For more information, see Remarks.</term>
	/// <term>Optional</term>
	/// </item>
	/// <item>
	/// <term>KDF_SECRET_APPEND</term>
	/// <term>A value to add to the end of the message input to the hash function. For more information, see Remarks.</term>
	/// <term>Optional</term>
	/// </item>
	/// </list>
	/// <para>The call to the KDF is made as shown in the following pseudocode.</para>
	/// <code lang="none">
	/// KDF-Prepend = KDF_SECRET_PREPEND[0] +
	/// KDF_SECRET_PREPEND[1] +
	/// ... +
	/// KDF_SECRET_PREPEND[n]
	///
	/// KDF-Append = KDF_SECRET_APPEND[0] +
	/// KDF_SECRET_APPEND[1] +
	/// ... +
	/// KDF_SECRET_APPEND[n]
	///
	/// KDF-Output = HMAC-Hash(
	/// KDF_HMAC_KEY,
	/// KDF-Prepend +
	/// hSharedSecret +
	/// KDF-Append)
	/// </code>
	/// <para><b>BCRYPT_KDF_TLS_PRF (L"TLS_PRF")</b></para>
	/// <para>
	/// Use the transport layer security (TLS) pseudo-random function (PRF) key derivation function. The size of the derived key is
	/// always 48 bytes, so the cbDerivedKey parameter must be 48.
	/// </para>
	/// <para>
	/// The parameters identified by the pParameterList parameter either can or must contain the following parameters, as indicated by
	/// the Required or optional column.
	/// </para>
	/// <list type="table">
	/// <listheader>
	/// <term>Parameter</term>
	/// <term>Description</term>
	/// <term>Required or optional</term>
	/// </listheader>
	/// <item>
	/// <term>KDF_TLS_PRF_LABEL</term>
	/// <term>An ANSI string that contains the PRF label.</term>
	/// <term>Required</term>
	/// </item>
	/// <item>
	/// <term>KDF_TLS_PRF_SEED</term>
	/// <term>The PRF seed. The seed must be 64 bytes long.</term>
	/// <term>Required</term>
	/// </item>
	/// <item>
	/// <term>KDF_TLS_PRF_PROTOCOL</term>
	/// <term>
	/// A DWORD value that specifies the TLS protocol version whose PRF algorithm is to be used. Valid values are: SSL2_PROTOCOL_VERSION
	/// (0x0002) SSL3_PROTOCOL_VERSION (0x0300) TLS1_PROTOCOL_VERSION (0x0301) TLS1_0_PROTOCOL_VERSION (0x0301) TLS1_1_PROTOCOL_VERSION
	/// (0x0302) TLS1_2_PROTOCOL_VERSION (0x0303) DTLS1_0_PROTOCOL_VERSION (0xfeff) Windows Server 2008 and Windows Vista:
	/// TLS1_1_PROTOCOL_VERSION, TLS1_2_PROTOCOL_VERSION and DTLS1_0_PROTOCOL_VERSION are not supported. Windows Server 2008 R2, Windows
	/// 7, Windows Server 2008 and Windows Vista: DTLS1_0_PROTOCOL_VERSION is not supported.
	/// </term>
	/// <term>Optional</term>
	/// </item>
	/// <item>
	/// <term>KDF_HASH_ALGORITHM</term>
	/// <term>
	/// The CNG algorithm ID of the hash to be used with the HMAC in the PRF, for the TLS 1.2 protocol version. Valid choices are SHA-256
	/// and SHA-384. If not specified, SHA-256 is used.
	/// </term>
	/// <term>Optional</term>
	/// </item>
	/// </list>
	/// <para>The call to the KDF is made as shown in the following pseudocode.</para>
	/// <code lang="none">
	/// KDF-Output = PRF(
	/// hSharedSecret,
	/// KDF_TLS_PRF_LABEL,
	/// KDF_TLS_PRF_SEED)
	/// </code>
	/// <para>BCRYPT_KDF_SP80056A_CONCAT (L"SP800_56A_CONCAT")</para>
	/// <para>Use the SP800-56A key derivation function.</para>
	/// <para>
	/// The parameters identified by the pParameterList parameter either can or must contain the following parameters, as indicated by
	/// the Required or optional column. All parameter values are treated as opaque byte arrays.
	/// </para>
	/// <list type="table">
	/// <listheader>
	/// <term>Parameter</term>
	/// <term>Description</term>
	/// <term>Required or optional</term>
	/// </listheader>
	/// <item>
	/// <term>KDF_ALGORITHMID</term>
	/// <term>
	/// Specifies the AlgorithmID subfield of the OtherInfo field in the SP800-56A key derivation function. Indicates the intended
	/// purpose of the derived key.
	/// </term>
	/// <term>Required</term>
	/// </item>
	/// <item>
	/// <term>KDF_PARTYUINFO</term>
	/// <term>
	/// Specifies the PartyUInfo subfield of the OtherInfo field in the SP800-56A key derivation function. The field contains public
	/// information contributed by the initiator.
	/// </term>
	/// <term>Required</term>
	/// </item>
	/// <item>
	/// <term>KDF_PARTYVINFO</term>
	/// <term>
	/// Specifies the PartyVInfo subfield of the OtherInfo field in the SP800-56A key derivation function. The field contains public
	/// information contributed by the responder.
	/// </term>
	/// <term>Required</term>
	/// </item>
	/// <item>
	/// <term>KDF_SUPPPUBINFO</term>
	/// <term>
	/// Specifies the SuppPubInfo subfield of the OtherInfo field in the SP800-56A key derivation function. The field contains public
	/// information known to both initiator and responder.
	/// </term>
	/// <term>Optional</term>
	/// </item>
	/// <item>
	/// <term>KDF_SUPPPRIVINFO</term>
	/// <term>
	/// Specifies the SuppPrivInfo subfield of the OtherInfo field in the SP800-56A key derivation function. It contains private
	/// information known to both initiator and responder, such as a shared secret.
	/// </term>
	/// <term>Optional</term>
	/// </item>
	/// </list>
	/// <para>The call to the KDF is made as shown in the following pseudocode.</para>
	/// <code lang="none">
	/// KDF-Output = SP_800-56A_KDF(
	/// hSharedSecret,
	/// KDF_ALGORITHMID,
	/// KDF_PARTYUINFO,
	/// KDF_PARTYVINFO,
	/// KDF_SUPPPUBINFO,
	/// KDF_SUPPPRIVINFO)
	/// </code>
	/// <para><c>Windows Server 2008, Windows Vista, Windows Server 2003 and Windows XP:</c> This value is not supported.</para>
	/// </param>
	/// <param name="pParameterList">
	/// The address of a BCryptBufferDesc structure that contains the KDF parameters. This parameter is optional and can be <c>NULL</c>
	/// if it is not needed.
	/// </param>
	/// <param name="pbDerivedKey">
	/// The address of a buffer that receives the key. The cbDerivedKey parameter contains the size of this buffer. If this parameter is
	/// <c>NULL</c>, this function will place the required size, in bytes, in the <c>ULONG</c> pointed to by the pcbResult parameter.
	/// </param>
	/// <param name="cbDerivedKey">The size, in bytes, of the pbDerivedKey buffer.</param>
	/// <param name="pcbResult">
	/// A pointer to a <c>ULONG</c> that receives the number of bytes that were copied to the pbDerivedKey buffer. If the pbDerivedKey
	/// parameter is <c>NULL</c>, this function will place the required size, in bytes, in the <c>ULONG</c> pointed to by this parameter.
	/// </param>
	/// <param name="dwFlags">
	/// <para>A set of flags that modify the behavior of this function. This can be zero or the following value.</para>
	/// <list type="table">
	/// <listheader>
	/// <term>Value</term>
	/// <term>Meaning</term>
	/// </listheader>
	/// <item>
	/// <term>KDF_USE_SECRET_AS_HMAC_KEY_FLAG</term>
	/// <term>
	/// The secret agreement value will also serve as the HMAC key. If this flag is specified, the KDF_HMAC_KEY parameter should not be
	/// included in the set of parameters in the pParameterList parameter. This flag is only used by the BCRYPT_KDF_HMAC key derivation function.
	/// </term>
	/// </item>
	/// </list>
	/// </param>
	/// <returns>
	/// <para>Returns a status code that indicates the success or failure of the function.</para>
	/// <para>Possible return codes include, but are not limited to, the following.</para>
	/// <list type="table">
	/// <listheader>
	/// <term>Return code</term>
	/// <term>Description</term>
	/// </listheader>
	/// <item>
	/// <term>STATUS_SUCCESS</term>
	/// <term>The function was successful.</term>
	/// </item>
	/// <item>
	/// <term>STATUS_INTERNAL_ERROR</term>
	/// <term>An internal error occurred.</term>
	/// </item>
	/// <item>
	/// <term>STATUS_INVALID_HANDLE</term>
	/// <term>The handle in the hSharedSecret parameter is not valid.</term>
	/// </item>
	/// <item>
	/// <term>STATUS_INVALID_PARAMETER</term>
	/// <term>One or more parameters are not valid.</term>
	/// </item>
	/// </list>
	/// </returns>
	/// <remarks>
	/// <para>
	/// The BCryptBufferDesc structure in the pParameterList parameter can contain more than one of the <c>KDF_SECRET_PREPEND</c> and
	/// <c>KDF_SECRET_APPEND</c> parameters. If more than one of these parameters is specified, the parameter values are concatenated in
	/// the order in which they are contained in the array before the KDF is called. For example, assume the following parameter values
	/// are specified.
	/// </para>
	/// <para>If the above parameter values are specified, the concatenated values to the actual KDF are as follows.</para>
	/// <para>
	/// Depending on what processor modes a provider supports, <c>BCryptDeriveKey</c> can be called either from user mode or kernel mode.
	/// Kernel mode callers can execute either at <c>PASSIVE_LEVEL</c> IRQL or <c>DISPATCH_LEVEL</c> IRQL. If the current IRQL level is
	/// <c>DISPATCH_LEVEL</c>, the handle provided in the hSharedSecret parameter must be located in nonpaged (or locked) memory and must
	/// be derived from an algorithm handle returned by a provider that was opened by using the <c>BCRYPT_PROV_DISPATCH</c> flag.
	/// </para>
	/// <para>
	/// To call this function in kernel mode, use Cng.lib, which is part of the Driver Development Kit (DDK). For more information, see
	/// WDK and Developer Tools. <c>Windows Server 2008 and Windows Vista:</c> To call this function in kernel mode, use Ksecdd.lib.
	/// </para>
	/// </remarks>
	// https://docs.microsoft.com/en-us/windows/desktop/api/bcrypt/nf-bcrypt-bcryptderivekey NTSTATUS BCryptDeriveKey(
	// BCRYPT_SECRET_HANDLE hSharedSecret, LPCWSTR pwszKDF, BCryptBufferDesc *pParameterList, PUCHAR pbDerivedKey, ULONG cbDerivedKey,
	// ULONG *pcbResult, ULONG dwFlags );
	[DllImport(Lib.Bcrypt, SetLastError = false, ExactSpelling = true)]
	[PInvokeData("bcrypt.h", MSDNShortId = "33c3cbf7-6c08-42ed-ac3f-feb71f3a9cbf")]
	public static extern NTStatus BCryptDeriveKey(BCRYPT_SECRET_HANDLE hSharedSecret, [MarshalAs(UnmanagedType.LPWStr)] string pwszKDF,
		[Optional] NCryptBufferDesc? pParameterList, SafeAllocatedMemoryHandle pbDerivedKey, uint cbDerivedKey, out uint pcbResult, DeriveKeyFlags dwFlags);

	/// <summary>The <c>BCryptDeriveKey</c> function derives a key from a secret agreement value.</summary>
	/// <param name="hSharedSecret">
	/// The secret agreement handle to create the key from. This handle is obtained from the BCryptSecretAgreement function.
	/// </param>
	/// <param name="pwszKDF">
	/// <para>
	/// A pointer to a null-terminated Unicode string that identifies the key derivation function (KDF) to use to derive the key. This
	/// can be one of the following strings.
	/// </para>
	/// <para><b>BCRYPT_KDF_HASH (L"HASH")</b></para>
	/// <para>Use the hash key derivation function.</para>
	/// <para>
	/// If the cbDerivedKey parameter is less than the size of the derived key, this function will only copy the specified number of
	/// bytes to the pbDerivedKey buffer. If the cbDerivedKey parameter is greater than the size of the derived key, this function will
	/// copy the key to the pbDerivedKey buffer and set the variable pointed to by the pcbResult to the actual number of bytes copied.
	/// </para>
	/// <para>
	/// The parameters identified by the pParameterList parameter either can or must contain the following parameters, as indicated by
	/// the Required or optional column.
	/// </para>
	/// <list type="table">
	/// <listheader>
	/// <term>Parameter</term>
	/// <term>Description</term>
	/// <term>Required or optional</term>
	/// </listheader>
	/// <item>
	/// <term>KDF_HASH_ALGORITHM</term>
	/// <term>
	/// A null-terminated Unicode string that identifies the hash algorithm to use. This can be one of the standard hash algorithm
	/// identifiers from CNG Algorithm Identifiers or the identifier for another registered hash algorithm. If this parameter is not
	/// specified, the SHA1 hash algorithm is used.
	/// </term>
	/// <term>Optional</term>
	/// </item>
	/// <item>
	/// <term>KDF_SECRET_PREPEND</term>
	/// <term>A value to add to the beginning of the message input to the hash function. For more information, see Remarks.</term>
	/// <term>Optional</term>
	/// </item>
	/// <item>
	/// <term>KDF_SECRET_APPEND</term>
	/// <term>A value to add to the end of the message input to the hash function. For more information, see Remarks.</term>
	/// <term>Optional</term>
	/// </item>
	/// </list>
	/// <para>The call to the KDF is made as shown in the following pseudocode.</para>
	/// <code lang="none">
	/// KDF-Prepend = KDF_SECRET_PREPEND[0] +
	/// KDF_SECRET_PREPEND[1] +
	/// ... +
	/// KDF_SECRET_PREPEND[n]
	///
	/// KDF-Append = KDF_SECRET_APPEND[0] +
	/// KDF_SECRET_APPEND[1] +
	/// ... +
	/// KDF_SECRET_APPEND[n]
	///
	/// KDF-Output = Hash(
	/// KDF-Prepend +
	///
	/// hSharedSecret +
	///
	/// KDF-Append)
	/// </code>
	/// <para><b>BCRYPT_KDF_HMAC (L"HMAC")</b></para>
	/// <para>Use the Hash-Based Message Authentication Code (HMAC) key derivation function.</para>
	/// <para>
	/// If the cbDerivedKey parameter is less than the size of the derived key, this function will only copy the specified number of
	/// bytes to the pbDerivedKey buffer. If the cbDerivedKey parameter is greater than the size of the derived key, this function will
	/// copy the key to the pbDerivedKey buffer and set the variable pointed to by the pcbResult to the actual number of bytes copied.
	/// </para>
	/// <para>
	/// The parameters identified by the pParameterList parameter either can or must contain the following parameters, as indicated by
	/// the Required or optional column.
	/// </para>
	/// <list type="table">
	/// <listheader>
	/// <term>Parameter</term>
	/// <term>Description</term>
	/// <term>Required or optional</term>
	/// </listheader>
	/// <item>
	/// <term>KDF_HASH_ALGORITHM</term>
	/// <term>
	/// A null-terminated Unicode string that identifies the hash algorithm to use. This can be one of the standard hash algorithm
	/// identifiers from CNG Algorithm Identifiers or the identifier for another registered hash algorithm. If this parameter is not
	/// specified, the SHA1 hash algorithm is used.
	/// </term>
	/// <term>Optional</term>
	/// </item>
	/// <item>
	/// <term>KDF_HMAC_KEY</term>
	/// <term>The key to use for the pseudo-random function (PRF).</term>
	/// <term>Optional</term>
	/// </item>
	/// <item>
	/// <term>KDF_SECRET_PREPEND</term>
	/// <term>A value to add to the beginning of the message input to the hash function. For more information, see Remarks.</term>
	/// <term>Optional</term>
	/// </item>
	/// <item>
	/// <term>KDF_SECRET_APPEND</term>
	/// <term>A value to add to the end of the message input to the hash function. For more information, see Remarks.</term>
	/// <term>Optional</term>
	/// </item>
	/// </list>
	/// <para>The call to the KDF is made as shown in the following pseudocode.</para>
	/// <code lang="none">
	/// KDF-Prepend = KDF_SECRET_PREPEND[0] +
	/// KDF_SECRET_PREPEND[1] +
	/// ... +
	/// KDF_SECRET_PREPEND[n]
	///
	/// KDF-Append = KDF_SECRET_APPEND[0] +
	/// KDF_SECRET_APPEND[1] +
	/// ... +
	/// KDF_SECRET_APPEND[n]
	///
	/// KDF-Output = HMAC-Hash(
	/// KDF_HMAC_KEY,
	/// KDF-Prepend +
	/// hSharedSecret +
	/// KDF-Append)
	/// </code>
	/// <para><b>BCRYPT_KDF_TLS_PRF (L"TLS_PRF")</b></para>
	/// <para>
	/// Use the transport layer security (TLS) pseudo-random function (PRF) key derivation function. The size of the derived key is
	/// always 48 bytes, so the cbDerivedKey parameter must be 48.
	/// </para>
	/// <para>
	/// The parameters identified by the pParameterList parameter either can or must contain the following parameters, as indicated by
	/// the Required or optional column.
	/// </para>
	/// <list type="table">
	/// <listheader>
	/// <term>Parameter</term>
	/// <term>Description</term>
	/// <term>Required or optional</term>
	/// </listheader>
	/// <item>
	/// <term>KDF_TLS_PRF_LABEL</term>
	/// <term>An ANSI string that contains the PRF label.</term>
	/// <term>Required</term>
	/// </item>
	/// <item>
	/// <term>KDF_TLS_PRF_SEED</term>
	/// <term>The PRF seed. The seed must be 64 bytes long.</term>
	/// <term>Required</term>
	/// </item>
	/// <item>
	/// <term>KDF_TLS_PRF_PROTOCOL</term>
	/// <term>
	/// A DWORD value that specifies the TLS protocol version whose PRF algorithm is to be used. Valid values are: SSL2_PROTOCOL_VERSION
	/// (0x0002) SSL3_PROTOCOL_VERSION (0x0300) TLS1_PROTOCOL_VERSION (0x0301) TLS1_0_PROTOCOL_VERSION (0x0301) TLS1_1_PROTOCOL_VERSION
	/// (0x0302) TLS1_2_PROTOCOL_VERSION (0x0303) DTLS1_0_PROTOCOL_VERSION (0xfeff) Windows Server 2008 and Windows Vista:
	/// TLS1_1_PROTOCOL_VERSION, TLS1_2_PROTOCOL_VERSION and DTLS1_0_PROTOCOL_VERSION are not supported. Windows Server 2008 R2, Windows
	/// 7, Windows Server 2008 and Windows Vista: DTLS1_0_PROTOCOL_VERSION is not supported.
	/// </term>
	/// <term>Optional</term>
	/// </item>
	/// <item>
	/// <term>KDF_HASH_ALGORITHM</term>
	/// <term>
	/// The CNG algorithm ID of the hash to be used with the HMAC in the PRF, for the TLS 1.2 protocol version. Valid choices are SHA-256
	/// and SHA-384. If not specified, SHA-256 is used.
	/// </term>
	/// <term>Optional</term>
	/// </item>
	/// </list>
	/// <para>The call to the KDF is made as shown in the following pseudocode.</para>
	/// <code lang="none">
	/// KDF-Output = PRF(
	/// hSharedSecret,
	/// KDF_TLS_PRF_LABEL,
	/// KDF_TLS_PRF_SEED)
	/// </code>
	/// <para>BCRYPT_KDF_SP80056A_CONCAT (L"SP800_56A_CONCAT")</para>
	/// <para>Use the SP800-56A key derivation function.</para>
	/// <para>
	/// The parameters identified by the pParameterList parameter either can or must contain the following parameters, as indicated by
	/// the Required or optional column. All parameter values are treated as opaque byte arrays.
	/// </para>
	/// <list type="table">
	/// <listheader>
	/// <term>Parameter</term>
	/// <term>Description</term>
	/// <term>Required or optional</term>
	/// </listheader>
	/// <item>
	/// <term>KDF_ALGORITHMID</term>
	/// <term>
	/// Specifies the AlgorithmID subfield of the OtherInfo field in the SP800-56A key derivation function. Indicates the intended
	/// purpose of the derived key.
	/// </term>
	/// <term>Required</term>
	/// </item>
	/// <item>
	/// <term>KDF_PARTYUINFO</term>
	/// <term>
	/// Specifies the PartyUInfo subfield of the OtherInfo field in the SP800-56A key derivation function. The field contains public
	/// information contributed by the initiator.
	/// </term>
	/// <term>Required</term>
	/// </item>
	/// <item>
	/// <term>KDF_PARTYVINFO</term>
	/// <term>
	/// Specifies the PartyVInfo subfield of the OtherInfo field in the SP800-56A key derivation function. The field contains public
	/// information contributed by the responder.
	/// </term>
	/// <term>Required</term>
	/// </item>
	/// <item>
	/// <term>KDF_SUPPPUBINFO</term>
	/// <term>
	/// Specifies the SuppPubInfo subfield of the OtherInfo field in the SP800-56A key derivation function. The field contains public
	/// information known to both initiator and responder.
	/// </term>
	/// <term>Optional</term>
	/// </item>
	/// <item>
	/// <term>KDF_SUPPPRIVINFO</term>
	/// <term>
	/// Specifies the SuppPrivInfo subfield of the OtherInfo field in the SP800-56A key derivation function. It contains private
	/// information known to both initiator and responder, such as a shared secret.
	/// </term>
	/// <term>Optional</term>
	/// </item>
	/// </list>
	/// <para>The call to the KDF is made as shown in the following pseudocode.</para>
	/// <code lang="none">
	/// KDF-Output = SP_800-56A_KDF(
	/// hSharedSecret,
	/// KDF_ALGORITHMID,
	/// KDF_PARTYUINFO,
	/// KDF_PARTYVINFO,
	/// KDF_SUPPPUBINFO,
	/// KDF_SUPPPRIVINFO)
	/// </code>
	/// <para><c>Windows Server 2008, Windows Vista, Windows Server 2003 and Windows XP:</c> This value is not supported.</para>
	/// </param>
	/// <param name="pParameterList">
	/// The address of a BCryptBufferDesc structure that contains the KDF parameters. This parameter is optional and can be <c>NULL</c>
	/// if it is not needed.
	/// </param>
	/// <param name="pbDerivedKey">
	/// The address of a buffer that receives the key. The cbDerivedKey parameter contains the size of this buffer. If this parameter is
	/// <c>NULL</c>, this function will place the required size, in bytes, in the <c>ULONG</c> pointed to by the pcbResult parameter.
	/// </param>
	/// <param name="cbDerivedKey">The size, in bytes, of the pbDerivedKey buffer.</param>
	/// <param name="pcbResult">
	/// A pointer to a <c>ULONG</c> that receives the number of bytes that were copied to the pbDerivedKey buffer. If the pbDerivedKey
	/// parameter is <c>NULL</c>, this function will place the required size, in bytes, in the <c>ULONG</c> pointed to by this parameter.
	/// </param>
	/// <param name="dwFlags">
	/// <para>A set of flags that modify the behavior of this function. This can be zero or the following value.</para>
	/// <list type="table">
	/// <listheader>
	/// <term>Value</term>
	/// <term>Meaning</term>
	/// </listheader>
	/// <item>
	/// <term>KDF_USE_SECRET_AS_HMAC_KEY_FLAG</term>
	/// <term>
	/// The secret agreement value will also serve as the HMAC key. If this flag is specified, the KDF_HMAC_KEY parameter should not be
	/// included in the set of parameters in the pParameterList parameter. This flag is only used by the BCRYPT_KDF_HMAC key derivation function.
	/// </term>
	/// </item>
	/// </list>
	/// </param>
	/// <returns>
	/// <para>Returns a status code that indicates the success or failure of the function.</para>
	/// <para>Possible return codes include, but are not limited to, the following.</para>
	/// <list type="table">
	/// <listheader>
	/// <term>Return code</term>
	/// <term>Description</term>
	/// </listheader>
	/// <item>
	/// <term>STATUS_SUCCESS</term>
	/// <term>The function was successful.</term>
	/// </item>
	/// <item>
	/// <term>STATUS_INTERNAL_ERROR</term>
	/// <term>An internal error occurred.</term>
	/// </item>
	/// <item>
	/// <term>STATUS_INVALID_HANDLE</term>
	/// <term>The handle in the hSharedSecret parameter is not valid.</term>
	/// </item>
	/// <item>
	/// <term>STATUS_INVALID_PARAMETER</term>
	/// <term>One or more parameters are not valid.</term>
	/// </item>
	/// </list>
	/// </returns>
	/// <remarks>
	/// <para>
	/// The BCryptBufferDesc structure in the pParameterList parameter can contain more than one of the <c>KDF_SECRET_PREPEND</c> and
	/// <c>KDF_SECRET_APPEND</c> parameters. If more than one of these parameters is specified, the parameter values are concatenated in
	/// the order in which they are contained in the array before the KDF is called. For example, assume the following parameter values
	/// are specified.
	/// </para>
	/// <para>If the above parameter values are specified, the concatenated values to the actual KDF are as follows.</para>
	/// <para>
	/// Depending on what processor modes a provider supports, <c>BCryptDeriveKey</c> can be called either from user mode or kernel mode.
	/// Kernel mode callers can execute either at <c>PASSIVE_LEVEL</c> IRQL or <c>DISPATCH_LEVEL</c> IRQL. If the current IRQL level is
	/// <c>DISPATCH_LEVEL</c>, the handle provided in the hSharedSecret parameter must be located in nonpaged (or locked) memory and must
	/// be derived from an algorithm handle returned by a provider that was opened by using the <c>BCRYPT_PROV_DISPATCH</c> flag.
	/// </para>
	/// <para>
	/// To call this function in kernel mode, use Cng.lib, which is part of the Driver Development Kit (DDK). For more information, see
	/// WDK and Developer Tools. <c>Windows Server 2008 and Windows Vista:</c> To call this function in kernel mode, use Ksecdd.lib.
	/// </para>
	/// </remarks>
	// https://docs.microsoft.com/en-us/windows/desktop/api/bcrypt/nf-bcrypt-bcryptderivekey NTSTATUS BCryptDeriveKey(
	// BCRYPT_SECRET_HANDLE hSharedSecret, LPCWSTR pwszKDF, BCryptBufferDesc *pParameterList, PUCHAR pbDerivedKey, ULONG cbDerivedKey,
	// ULONG *pcbResult, ULONG dwFlags );
	[DllImport(Lib.Bcrypt, SetLastError = false, ExactSpelling = true)]
	[PInvokeData("bcrypt.h", MSDNShortId = "33c3cbf7-6c08-42ed-ac3f-feb71f3a9cbf")]
	public static extern NTStatus BCryptDeriveKey(BCRYPT_SECRET_HANDLE hSharedSecret, [MarshalAs(UnmanagedType.LPWStr)] string pwszKDF,
		[Optional] NCryptBufferDesc? pParameterList, [Optional] IntPtr pbDerivedKey, [Optional] uint cbDerivedKey, out uint pcbResult, DeriveKeyFlags dwFlags);

	/// <summary>
	/// <para>The <c>BCryptDeriveKeyCapi</c> function derives a key from a hash value.</para>
	/// <para>
	/// This function is provided as a helper function to assist in migrating legacy Cryptography API (CAPI)–based applications to use
	/// Cryptography API: Next Generation (CNG). The <c>BCryptDeriveKeyCapi</c> function performs the key derivation in a manner that is
	/// compatible with the CAPI CryptDeriveKey function.
	/// </para>
	/// </summary>
	/// <param name="hHash">
	/// The handle of the hash object. The handle is obtained by calling the BCryptCreateHash function. When you have finished using the
	/// handle, you must free it by calling the BCryptDestroyHash function.
	/// </param>
	/// <param name="hTargetAlg">
	/// <para>The handle of the algorithm object. This can be an ALG_ID value that is compatible with the CryptDeriveKey function.</para>
	/// <para>
	/// <c>Note</c> Limitations in CAPI and key expansion prevent the use of any hash algorithm that generates an output that is larger
	/// than 512 bits.
	/// </para>
	/// </param>
	/// <param name="pbDerivedKey">A pointer to the buffer that receives the derived key.</param>
	/// <param name="cbDerivedKey">The size, in characters, of the derived key pointed to by the pbDerivedKey parameter.</param>
	/// <param name="dwFlags">This parameter is reserved and must be set to zero.</param>
	/// <returns>
	/// <para>Returns a status code that indicates the success or failure of the function.</para>
	/// <para>Possible return codes include, but are not limited to, the following.</para>
	/// <list type="table">
	/// <listheader>
	/// <term>Return code</term>
	/// <term>Description</term>
	/// </listheader>
	/// <item>
	/// <term>STATUS_SUCCESS</term>
	/// <term>The function was successful.</term>
	/// </item>
	/// <item>
	/// <term>STATUS_INVALID_HANDLE</term>
	/// <term>The handle in the hHash or hTargetAlg parameter is not valid.</term>
	/// </item>
	/// <item>
	/// <term>STATUS_INVALID_PARAMETER</term>
	/// <term>The value in the cbDerivedKey parameter is larger than twice the output size of the hash function.</term>
	/// </item>
	/// <item>
	/// <term>STATUS_NO_MEMORY</term>
	/// <term>A memory allocation failure occurred.</term>
	/// </item>
	/// </list>
	/// </returns>
	/// <remarks>This function does not support the PK salt functionality of the CAPI CryptDeriveKey function.</remarks>
	// https://docs.microsoft.com/en-us/windows/desktop/api/bcrypt/nf-bcrypt-bcryptderivekeycapi NTSTATUS BCryptDeriveKeyCapi(
	// BCRYPT_HASH_HANDLE hHash, BCRYPT_ALG_HANDLE hTargetAlg, PUCHAR pbDerivedKey, ULONG cbDerivedKey, ULONG dwFlags );
	[DllImport(Lib.Bcrypt, SetLastError = false, ExactSpelling = true)]
	[PInvokeData("bcrypt.h", MSDNShortId = "bebb0767-8c54-48b7-864c-f53caea7120d")]
	public static extern NTStatus BCryptDeriveKeyCapi(BCRYPT_HASH_HANDLE hHash, BCRYPT_ALG_HANDLE hTargetAlg, SafeAllocatedMemoryHandle pbDerivedKey, uint cbDerivedKey, uint dwFlags = 0);

	/// <summary>
	/// <para>The <c>BCryptDeriveKeyCapi</c> function derives a key from a hash value.</para>
	/// <para>
	/// This function is provided as a helper function to assist in migrating legacy Cryptography API (CAPI)–based applications to use
	/// Cryptography API: Next Generation (CNG). The <c>BCryptDeriveKeyCapi</c> function performs the key derivation in a manner that is
	/// compatible with the CAPI CryptDeriveKey function.
	/// </para>
	/// </summary>
	/// <param name="hHash">
	/// The handle of the hash object. The handle is obtained by calling the BCryptCreateHash function. When you have finished using the
	/// handle, you must free it by calling the BCryptDestroyHash function.
	/// </param>
	/// <param name="hTargetAlg">
	/// <para>The handle of the algorithm object. This can be an ALG_ID value that is compatible with the CryptDeriveKey function.</para>
	/// <para>
	/// <c>Note</c> Limitations in CAPI and key expansion prevent the use of any hash algorithm that generates an output that is larger
	/// than 512 bits.
	/// </para>
	/// </param>
	/// <param name="pbDerivedKey">A pointer to the buffer that receives the derived key.</param>
	/// <param name="cbDerivedKey">The size, in characters, of the derived key pointed to by the pbDerivedKey parameter.</param>
	/// <param name="dwFlags">This parameter is reserved and must be set to zero.</param>
	/// <returns>
	/// <para>Returns a status code that indicates the success or failure of the function.</para>
	/// <para>Possible return codes include, but are not limited to, the following.</para>
	/// <list type="table">
	/// <listheader>
	/// <term>Return code</term>
	/// <term>Description</term>
	/// </listheader>
	/// <item>
	/// <term>STATUS_SUCCESS</term>
	/// <term>The function was successful.</term>
	/// </item>
	/// <item>
	/// <term>STATUS_INVALID_HANDLE</term>
	/// <term>The handle in the hHash or hTargetAlg parameter is not valid.</term>
	/// </item>
	/// <item>
	/// <term>STATUS_INVALID_PARAMETER</term>
	/// <term>The value in the cbDerivedKey parameter is larger than twice the output size of the hash function.</term>
	/// </item>
	/// <item>
	/// <term>STATUS_NO_MEMORY</term>
	/// <term>A memory allocation failure occurred.</term>
	/// </item>
	/// </list>
	/// </returns>
	/// <remarks>This function does not support the PK salt functionality of the CAPI CryptDeriveKey function.</remarks>
	// https://docs.microsoft.com/en-us/windows/desktop/api/bcrypt/nf-bcrypt-bcryptderivekeycapi NTSTATUS BCryptDeriveKeyCapi(
	// BCRYPT_HASH_HANDLE hHash, BCRYPT_ALG_HANDLE hTargetAlg, PUCHAR pbDerivedKey, ULONG cbDerivedKey, ULONG dwFlags );
	[DllImport(Lib.Bcrypt, SetLastError = false, ExactSpelling = true)]
	[PInvokeData("bcrypt.h", MSDNShortId = "bebb0767-8c54-48b7-864c-f53caea7120d")]
	public static extern NTStatus BCryptDeriveKeyCapi(BCRYPT_HASH_HANDLE hHash, BCRYPT_ALG_HANDLE hTargetAlg, [Optional] IntPtr pbDerivedKey, uint cbDerivedKey, uint dwFlags = 0);

	/// <summary>
	/// The <c>BCryptDeriveKeyPBKDF2</c> function derives a key from a hash value by using the PBKDF2 key derivation algorithm as defined
	/// by RFC 2898.
	/// </summary>
	/// <param name="hPrf">
	/// <para>
	/// The handle of an algorithm provider that provides the pseudo-random function. This should be an algorithm provider that performs
	/// a Message Authentication Code computation. When you use the default Microsoft algorithm provider, any hashing algorithm opened by
	/// using the <c>BCRYPT_ALG_HANDLE_HMAC_FLAG</c> flag can be used.
	/// </para>
	/// <para><c>Note</c> Only algorithms that implement the BCRYPT_IS_KEYED_HASH property can be used to populate this parameter.</para>
	/// </param>
	/// <param name="pbPassword">A pointer to a buffer that contains the password parameter for the PBKDF2 key derivation algorithm.</param>
	/// <param name="cbPassword">The length, in bytes, of the data in the buffer pointed to by the pbPassword parameter.</param>
	/// <param name="pbSalt">
	/// <para>A pointer to a buffer that contains the salt argument for the PBKDF2 key derivation algorithm.</para>
	/// <para><c>Note</c> Any information that is not secret and that is used in the key derivation should be passed in this buffer.</para>
	/// </param>
	/// <param name="cbSalt">The length, in bytes, of the salt argument pointed to by the pbSalt parameter.</param>
	/// <param name="cIterations">The iteration count for the PBKDF2 key derivation algorithm.</param>
	/// <param name="pbDerivedKey">A pointer to a buffer that receives the derived key.</param>
	/// <param name="cbDerivedKey">The length, in bytes, of the derived key returned in the buffer pointed to by the pbDerivedKey parameter.</param>
	/// <param name="dwFlags">This parameter is reserved and must be set to zero.</param>
	/// <returns>
	/// <para>Returns a status code that indicates the success or failure of the function.</para>
	/// <para>Possible return codes include, but are not limited to, the following.</para>
	/// <list type="table">
	/// <listheader>
	/// <term>Return code</term>
	/// <term>Description</term>
	/// </listheader>
	/// <item>
	/// <term>STATUS_SUCCESS</term>
	/// <term>The function was successful.</term>
	/// </item>
	/// <item>
	/// <term>STATUS_INVALID_HANDLE</term>
	/// <term>The handle in the hPrf parameter is not valid.</term>
	/// </item>
	/// <item>
	/// <term>STATUS_INVALID_PARAMETER</term>
	/// <term>One or more parameters are not valid.</term>
	/// </item>
	/// <item>
	/// <term>STATUS_NO_MEMORY</term>
	/// <term>A memory allocation failure occurred.</term>
	/// </item>
	/// </list>
	/// </returns>
	// https://docs.microsoft.com/en-us/windows/desktop/api/bcrypt/nf-bcrypt-bcryptderivekeypbkdf2 NTSTATUS BCryptDeriveKeyPBKDF2(
	// BCRYPT_ALG_HANDLE hPrf, PUCHAR pbPassword, ULONG cbPassword, PUCHAR pbSalt, ULONG cbSalt, ULONGLONG cIterations, PUCHAR
	// pbDerivedKey, ULONG cbDerivedKey, ULONG dwFlags );
	[DllImport(Lib.Bcrypt, SetLastError = false, ExactSpelling = true)]
	[PInvokeData("bcrypt.h", MSDNShortId = "afdddfec-a3a5-410c-998b-9a5af8e051b6")]
	public static extern NTStatus BCryptDeriveKeyPBKDF2(BCRYPT_ALG_HANDLE hPrf, SafeAllocatedMemoryHandle pbPassword, uint cbPassword, SafeAllocatedMemoryHandle pbSalt,
		uint cbSalt, ulong cIterations, SafeAllocatedMemoryHandle pbDerivedKey, uint cbDerivedKey, uint dwFlags = 0);

	/// <summary>
	/// The <c>BCryptDeriveKeyPBKDF2</c> function derives a key from a hash value by using the PBKDF2 key derivation algorithm as defined
	/// by RFC 2898.
	/// </summary>
	/// <param name="hPrf">
	/// <para>
	/// The handle of an algorithm provider that provides the pseudo-random function. This should be an algorithm provider that performs
	/// a Message Authentication Code computation. When you use the default Microsoft algorithm provider, any hashing algorithm opened by
	/// using the <c>BCRYPT_ALG_HANDLE_HMAC_FLAG</c> flag can be used.
	/// </para>
	/// <para><c>Note</c> Only algorithms that implement the BCRYPT_IS_KEYED_HASH property can be used to populate this parameter.</para>
	/// </param>
	/// <param name="pbPassword">A pointer to a buffer that contains the password parameter for the PBKDF2 key derivation algorithm.</param>
	/// <param name="cbPassword">The length, in bytes, of the data in the buffer pointed to by the pbPassword parameter.</param>
	/// <param name="pbSalt">
	/// <para>A pointer to a buffer that contains the salt argument for the PBKDF2 key derivation algorithm.</para>
	/// <para><c>Note</c> Any information that is not secret and that is used in the key derivation should be passed in this buffer.</para>
	/// </param>
	/// <param name="cbSalt">The length, in bytes, of the salt argument pointed to by the pbSalt parameter.</param>
	/// <param name="cIterations">The iteration count for the PBKDF2 key derivation algorithm.</param>
	/// <param name="pbDerivedKey">A pointer to a buffer that receives the derived key.</param>
	/// <param name="cbDerivedKey">The length, in bytes, of the derived key returned in the buffer pointed to by the pbDerivedKey parameter.</param>
	/// <param name="dwFlags">This parameter is reserved and must be set to zero.</param>
	/// <returns>
	/// <para>Returns a status code that indicates the success or failure of the function.</para>
	/// <para>Possible return codes include, but are not limited to, the following.</para>
	/// <list type="table">
	/// <listheader>
	/// <term>Return code</term>
	/// <term>Description</term>
	/// </listheader>
	/// <item>
	/// <term>STATUS_SUCCESS</term>
	/// <term>The function was successful.</term>
	/// </item>
	/// <item>
	/// <term>STATUS_INVALID_HANDLE</term>
	/// <term>The handle in the hPrf parameter is not valid.</term>
	/// </item>
	/// <item>
	/// <term>STATUS_INVALID_PARAMETER</term>
	/// <term>One or more parameters are not valid.</term>
	/// </item>
	/// <item>
	/// <term>STATUS_NO_MEMORY</term>
	/// <term>A memory allocation failure occurred.</term>
	/// </item>
	/// </list>
	/// </returns>
	// https://docs.microsoft.com/en-us/windows/desktop/api/bcrypt/nf-bcrypt-bcryptderivekeypbkdf2 NTSTATUS BCryptDeriveKeyPBKDF2(
	// BCRYPT_ALG_HANDLE hPrf, PUCHAR pbPassword, ULONG cbPassword, PUCHAR pbSalt, ULONG cbSalt, ULONGLONG cIterations, PUCHAR
	// pbDerivedKey, ULONG cbDerivedKey, ULONG dwFlags );
	[DllImport(Lib.Bcrypt, SetLastError = false, ExactSpelling = true)]
	[PInvokeData("bcrypt.h", MSDNShortId = "afdddfec-a3a5-410c-998b-9a5af8e051b6")]
	public static extern NTStatus BCryptDeriveKeyPBKDF2(BCRYPT_ALG_HANDLE hPrf, IntPtr pbPassword, uint cbPassword, IntPtr pbSalt, uint cbSalt, ulong cIterations,
		IntPtr pbDerivedKey, uint cbDerivedKey, uint dwFlags = 0);

	/// <summary>
	/// <para>The <c>BCryptDestroyHash</c> function destroys a hash or Message Authentication Code (MAC) object.</para>
	/// </summary>
	/// <param name="hHash">
	/// <para>The handle of the hash or MAC object to destroy. This handle is obtained by using the BCryptCreateHash function.</para>
	/// </param>
	/// <returns>
	/// <para>Returns a status code that indicates the success or failure of the function.</para>
	/// <para>Possible return codes include, but are not limited to, the following.</para>
	/// <list type="table">
	/// <listheader>
	/// <term>Return code</term>
	/// <term>Description</term>
	/// </listheader>
	/// <item>
	/// <term>STATUS_SUCCESS</term>
	/// <term>The function was successful.</term>
	/// </item>
	/// <item>
	/// <term>STATUS_INVALID_HANDLE</term>
	/// <term>The algorithm handle in the hHash parameter is not valid.</term>
	/// </item>
	/// </list>
	/// </returns>
	/// <remarks>
	/// <para>
	/// Depending on what processor modes a provider supports, <c>BCryptDestroyHash</c> can be called either from user mode or kernel
	/// mode. Kernel mode callers can execute either at <c>PASSIVE_LEVEL</c> IRQL or <c>DISPATCH_LEVEL</c> IRQL. If the current IRQL
	/// level is <c>DISPATCH_LEVEL</c>, the handle provided in the hHash parameter must be derived from an algorithm handle returned by a
	/// provider that was opened by using the <c>BCRYPT_PROV_DISPATCH</c> flag.
	/// </para>
	/// <para>
	/// To call this function in kernel mode, use Cng.lib, which is part of the Driver Development Kit (DDK). For more information, see
	/// WDK and Developer Tools. <c>Windows Server 2008 and Windows Vista:</c> To call this function in kernel mode, use Ksecdd.lib.
	/// </para>
	/// </remarks>
	// https://docs.microsoft.com/en-us/windows/desktop/api/bcrypt/nf-bcrypt-bcryptdestroyhash NTSTATUS BCryptDestroyHash(
	// BCRYPT_HASH_HANDLE hHash );
	[DllImport(Lib.Bcrypt, SetLastError = false, ExactSpelling = true)]
	[PInvokeData("bcrypt.h", MSDNShortId = "067dac61-98b9-478c-ac4d-e141961865e9")]
	public static extern NTStatus BCryptDestroyHash(BCRYPT_HASH_HANDLE hHash);

	/// <summary>The <c>BCryptDestroyKey</c> function destroys a key.</summary>
	/// <param name="hKey">The handle of the key to destroy.</param>
	/// <returns>
	/// <para>Returns a status code that indicates the success or failure of the function.</para>
	/// <para>Possible return codes include, but are not limited to, the following.</para>
	/// <list type="table">
	/// <listheader>
	/// <term>Return code</term>
	/// <term>Description</term>
	/// </listheader>
	/// <item>
	/// <term>STATUS_SUCCESS</term>
	/// <term>The function was successful.</term>
	/// </item>
	/// <item>
	/// <term>STATUS_INVALID_HANDLE</term>
	/// <term>The key handle in the hKey parameter is not valid.</term>
	/// </item>
	/// </list>
	/// </returns>
	/// <remarks>
	/// <para>
	/// Depending on what processor modes a provider supports, <c>BCryptDestroyKey</c> can be called either from user mode or kernel
	/// mode. Kernel mode callers can execute either at <c>PASSIVE_LEVEL</c> IRQL or <c>DISPATCH_LEVEL</c> IRQL. If the current IRQL
	/// level is <c>DISPATCH_LEVEL</c>, the handle provided in the hKey parameter must be derived from an algorithm handle returned by a
	/// provider that was opened with the <c>BCRYPT_PROV_DISPATCH</c> flag.
	/// </para>
	/// <para>
	/// To call this function in kernel mode, use Cng.lib, which is part of the Driver Development Kit (DDK). For more information, see
	/// WDK and Developer Tools. <c>Windows Server 2008 and Windows Vista:</c> To call this function in kernel mode, use Ksecdd.lib.
	/// </para>
	/// </remarks>
	// https://docs.microsoft.com/en-us/windows/desktop/api/bcrypt/nf-bcrypt-bcryptdestroykey NTSTATUS BCryptDestroyKey(
	// BCRYPT_KEY_HANDLE hKey );
	[DllImport(Lib.Bcrypt, SetLastError = false, ExactSpelling = true)]
	[PInvokeData("bcrypt.h", MSDNShortId = "98c02e55-6489-4901-8a7a-021baac41965")]
	public static extern NTStatus BCryptDestroyKey(BCRYPT_KEY_HANDLE hKey);

	/// <summary>
	/// <para>
	/// The <c>BCryptDestroySecret</c> function destroys a secret agreement handle that was created by using the BCryptSecretAgreement function.
	/// </para>
	/// </summary>
	/// <param name="hSecret">
	/// <para>The <c>BCRYPT_SECRET_HANDLE</c> to be destroyed.</para>
	/// </param>
	/// <returns>
	/// <para>Returns a status code that indicates the success or failure of the function.</para>
	/// <para>Possible return codes include, but are not limited to, the following.</para>
	/// <list type="table">
	/// <listheader>
	/// <term>Return code</term>
	/// <term>Description</term>
	/// </listheader>
	/// <item>
	/// <term>STATUS_SUCCESS</term>
	/// <term>The function was successful.</term>
	/// </item>
	/// <item>
	/// <term>STATUS_INVALID_HANDLE</term>
	/// <term>The handle in the hSecret parameter is not valid.</term>
	/// </item>
	/// </list>
	/// </returns>
	/// <remarks>
	/// <para>
	/// Depending on what processor modes a provider supports, <c>BCryptDestroySecret</c> can be called either from user mode or kernel
	/// mode. Kernel mode callers can execute either at <c>PASSIVE_LEVEL</c> IRQL or <c>DISPATCH_LEVEL</c> IRQL. If the current IRQL
	/// level is <c>DISPATCH_LEVEL</c>, the handle provided in the hSecret parameter must be derived from an algorithm handle returned by
	/// a provider that was opened by using the <c>BCRYPT_PROV_DISPATCH</c> flag.
	/// </para>
	/// <para>
	/// To call this function in kernel mode, use Cng.lib, which is part of the Driver Development Kit (DDK). For more information, see
	/// WDK and Developer Tools. <c>Windows Server 2008 and Windows Vista:</c> To call this function in kernel mode, use Ksecdd.lib.
	/// </para>
	/// </remarks>
	// https://docs.microsoft.com/en-us/windows/desktop/api/bcrypt/nf-bcrypt-bcryptdestroysecret NTSTATUS BCryptDestroySecret(
	// BCRYPT_SECRET_HANDLE hSecret );
	[DllImport(Lib.Bcrypt, SetLastError = false, ExactSpelling = true)]
	[PInvokeData("bcrypt.h", MSDNShortId = "237743ff-ecb1-4c01-b4f9-192f27716f2c")]
	public static extern NTStatus BCryptDestroySecret(BCRYPT_SECRET_HANDLE hSecret);

	/// <summary>
	/// <para>
	/// The <c>BCryptDuplicateHash</c> function duplicates an existing hash or Message Authentication Code (MAC) object. The duplicate
	/// object contains all state and data contained in the original object at the point of duplication.
	/// </para>
	/// </summary>
	/// <param name="hHash">
	/// <para>The handle of the hash or MAC object to duplicate.</para>
	/// </param>
	/// <param name="phNewHash">
	/// <para>A pointer to a <c>BCRYPT_HASH_HANDLE</c> value that receives the handle that represents the duplicate hash or MAC object.</para>
	/// </param>
	/// <param name="pbHashObject">
	/// <para>
	/// A pointer to a buffer that receives the duplicate hash or MAC object. The cbHashObject parameter contains the size of this
	/// buffer. The required size of this buffer can be obtained by calling the BCryptGetProperty function to get the
	/// <c>BCRYPT_OBJECT_LENGTH</c> property. This will provide the size of the hash object for the specified algorithm.
	/// </para>
	/// <para>When the duplicate hash handle is released, free this memory.</para>
	/// </param>
	/// <param name="cbHashObject">
	/// <para>The size, in bytes, of the pbHashObject buffer.</para>
	/// </param>
	/// <param name="dwFlags">
	/// <para>
	/// A set of flags that modify the behavior of this function. No flags are currently defined, so this parameter should be zero.
	/// </para>
	/// </param>
	/// <returns>
	/// <para>Returns a status code that indicates the success or failure of the function.</para>
	/// <para>Possible return codes include, but are not limited to, the following.</para>
	/// <list type="table">
	/// <listheader>
	/// <term>Return code</term>
	/// <term>Description</term>
	/// </listheader>
	/// <item>
	/// <term>STATUS_SUCCESS</term>
	/// <term>The function was successful.</term>
	/// </item>
	/// <item>
	/// <term>STATUS_BUFFER_TOO_SMALL</term>
	/// <term>The size of the hash object specified by the cbHashObject parameter is not large enough to hold the hash object.</term>
	/// </item>
	/// <item>
	/// <term>STATUS_INVALID_HANDLE</term>
	/// <term>The hash handle in the hHash parameter is not valid.</term>
	/// </item>
	/// <item>
	/// <term>STATUS_INVALID_PARAMETER</term>
	/// <term>One or more parameters are not valid.</term>
	/// </item>
	/// </list>
	/// </returns>
	/// <remarks>
	/// <para>
	/// This function is useful when computing a hash or MAC over a block of common data. After the common data has been processed, the
	/// hash or MAC object can be duplicated, and then the unique data can be added to the individual objects.
	/// </para>
	/// <para>
	/// Depending on what processor modes a provider supports, <c>BCryptDuplicateHash</c> can be called either from user mode or kernel
	/// mode. Kernel mode callers can execute either at <c>PASSIVE_LEVEL</c> IRQL or <c>DISPATCH_LEVEL</c> IRQL. If the current IRQL
	/// level is <c>DISPATCH_LEVEL</c>, the handle provided in the hHash parameter must be derived from an algorithm handle returned by a
	/// provider that was opened by using the <c>BCRYPT_PROV_DISPATCH</c> flag, and any pointers passed to the BCryptDestroyKey function
	/// must refer to nonpaged (or locked) memory.
	/// </para>
	/// <para>
	/// To call this function in kernel mode, use Cng.lib, which is part of the Driver Development Kit (DDK). For more information, see
	/// WDK and Developer Tools. <c>Windows Server 2008 and Windows Vista:</c> To call this function in kernel mode, use Ksecdd.lib.
	/// </para>
	/// </remarks>
	// https://docs.microsoft.com/en-us/windows/desktop/api/bcrypt/nf-bcrypt-bcryptduplicatehash NTSTATUS BCryptDuplicateHash(
	// BCRYPT_HASH_HANDLE hHash, BCRYPT_HASH_HANDLE *phNewHash, PUCHAR pbHashObject, ULONG cbHashObject, ULONG dwFlags );
	[DllImport(Lib.Bcrypt, SetLastError = false, ExactSpelling = true)]
	[PInvokeData("bcrypt.h", MSDNShortId = "451ff5dc-b66a-4e8e-a327-28b4ee618b74")]
	public static extern NTStatus BCryptDuplicateHash(BCRYPT_HASH_HANDLE hHash, out SafeBCRYPT_HASH_HANDLE phNewHash, IntPtr pbHashObject, uint cbHashObject, uint dwFlags = 0);

	/// <summary>
	/// <para>
	/// The <c>BCryptDuplicateHash</c> function duplicates an existing hash or Message Authentication Code (MAC) object. The duplicate
	/// object contains all state and data contained in the original object at the point of duplication.
	/// </para>
	/// </summary>
	/// <param name="hHash">
	/// <para>The handle of the hash or MAC object to duplicate.</para>
	/// </param>
	/// <param name="phNewHash">
	/// <para>A pointer to a <c>BCRYPT_HASH_HANDLE</c> value that receives the handle that represents the duplicate hash or MAC object.</para>
	/// </param>
	/// <param name="pbHashObject">
	/// <para>
	/// A pointer to a buffer that receives the duplicate hash or MAC object. The cbHashObject parameter contains the size of this
	/// buffer. The required size of this buffer can be obtained by calling the BCryptGetProperty function to get the
	/// <c>BCRYPT_OBJECT_LENGTH</c> property. This will provide the size of the hash object for the specified algorithm.
	/// </para>
	/// <para>When the duplicate hash handle is released, free this memory.</para>
	/// </param>
	/// <param name="cbHashObject">
	/// <para>The size, in bytes, of the pbHashObject buffer.</para>
	/// </param>
	/// <param name="dwFlags">
	/// <para>
	/// A set of flags that modify the behavior of this function. No flags are currently defined, so this parameter should be zero.
	/// </para>
	/// </param>
	/// <returns>
	/// <para>Returns a status code that indicates the success or failure of the function.</para>
	/// <para>Possible return codes include, but are not limited to, the following.</para>
	/// <list type="table">
	/// <listheader>
	/// <term>Return code</term>
	/// <term>Description</term>
	/// </listheader>
	/// <item>
	/// <term>STATUS_SUCCESS</term>
	/// <term>The function was successful.</term>
	/// </item>
	/// <item>
	/// <term>STATUS_BUFFER_TOO_SMALL</term>
	/// <term>The size of the hash object specified by the cbHashObject parameter is not large enough to hold the hash object.</term>
	/// </item>
	/// <item>
	/// <term>STATUS_INVALID_HANDLE</term>
	/// <term>The hash handle in the hHash parameter is not valid.</term>
	/// </item>
	/// <item>
	/// <term>STATUS_INVALID_PARAMETER</term>
	/// <term>One or more parameters are not valid.</term>
	/// </item>
	/// </list>
	/// </returns>
	/// <remarks>
	/// <para>
	/// This function is useful when computing a hash or MAC over a block of common data. After the common data has been processed, the
	/// hash or MAC object can be duplicated, and then the unique data can be added to the individual objects.
	/// </para>
	/// <para>
	/// Depending on what processor modes a provider supports, <c>BCryptDuplicateHash</c> can be called either from user mode or kernel
	/// mode. Kernel mode callers can execute either at <c>PASSIVE_LEVEL</c> IRQL or <c>DISPATCH_LEVEL</c> IRQL. If the current IRQL
	/// level is <c>DISPATCH_LEVEL</c>, the handle provided in the hHash parameter must be derived from an algorithm handle returned by a
	/// provider that was opened by using the <c>BCRYPT_PROV_DISPATCH</c> flag, and any pointers passed to the BCryptDestroyKey function
	/// must refer to nonpaged (or locked) memory.
	/// </para>
	/// <para>
	/// To call this function in kernel mode, use Cng.lib, which is part of the Driver Development Kit (DDK). For more information, see
	/// WDK and Developer Tools. <c>Windows Server 2008 and Windows Vista:</c> To call this function in kernel mode, use Ksecdd.lib.
	/// </para>
	/// </remarks>
	// https://docs.microsoft.com/en-us/windows/desktop/api/bcrypt/nf-bcrypt-bcryptduplicatehash NTSTATUS BCryptDuplicateHash(
	// BCRYPT_HASH_HANDLE hHash, BCRYPT_HASH_HANDLE *phNewHash, PUCHAR pbHashObject, ULONG cbHashObject, ULONG dwFlags );
	[DllImport(Lib.Bcrypt, SetLastError = false, ExactSpelling = true)]
	[PInvokeData("bcrypt.h", MSDNShortId = "451ff5dc-b66a-4e8e-a327-28b4ee618b74")]
	public static extern NTStatus BCryptDuplicateHash(BCRYPT_HASH_HANDLE hHash, out SafeBCRYPT_HASH_HANDLE phNewHash, SafeAllocatedMemoryHandle pbHashObject, uint cbHashObject, uint dwFlags = 0);

	/// <summary>
	/// <para>The <c>BCryptDuplicateKey</c> function creates a duplicate of a symmetric key.</para>
	/// </summary>
	/// <param name="hKey">
	/// <para>The handle of the key to duplicate. This must be a handle to a symmetric key.</para>
	/// </param>
	/// <param name="phNewKey">
	/// <para>
	/// A pointer to a <c>BCRYPT_KEY_HANDLE</c> variable that receives the handle of the duplicate key. This handle is used in subsequent
	/// functions that require a key, such as BCryptEncrypt. This handle must be released when it is no longer needed by passing it to
	/// the BCryptDestroyKey function.
	/// </para>
	/// </param>
	/// <param name="pbKeyObject">
	/// <para>
	/// A pointer to a buffer that receives the duplicate key object. The cbKeyObject parameter contains the size of this buffer. The
	/// required size of this buffer can be obtained by calling the BCryptGetProperty function to get the <c>BCRYPT_OBJECT_LENGTH</c>
	/// property. This will provide the size of the key object for the specified algorithm.
	/// </para>
	/// <para>This memory can only be freed after the phNewKey key handle is destroyed.</para>
	/// </param>
	/// <param name="cbKeyObject">
	/// <para>The size, in bytes, of the pbKeyObject buffer.</para>
	/// </param>
	/// <param name="dwFlags">
	/// <para>
	/// A set of flags that modify the behavior of this function. No flags are currently defined, so this parameter should be zero.
	/// </para>
	/// </param>
	/// <returns>
	/// <para>Returns a status code that indicates the success or failure of the function.</para>
	/// <para>Possible return codes include, but are not limited to, the following.</para>
	/// <list type="table">
	/// <listheader>
	/// <term>Return code</term>
	/// <term>Description</term>
	/// </listheader>
	/// <item>
	/// <term>STATUS_SUCCESS</term>
	/// <term>The function was successful.</term>
	/// </item>
	/// <item>
	/// <term>STATUS_BUFFER_TOO_SMALL</term>
	/// <term>The size of the key object specified by the cbKeyObject parameter is not large enough to hold the key object.</term>
	/// </item>
	/// <item>
	/// <term>STATUS_INVALID_HANDLE</term>
	/// <term>
	/// The key handle in the hKey parameter is not valid. This value is also returned if the key to duplicate is not a symmetric key.
	/// </term>
	/// </item>
	/// <item>
	/// <term>STATUS_INVALID_PARAMETER</term>
	/// <term>One or more parameters are not valid.</term>
	/// </item>
	/// </list>
	/// </returns>
	/// <remarks>
	/// <para>
	/// Depending on what processor modes a provider supports, <c>BCryptDuplicateKey</c> can be called either from user mode or kernel
	/// mode. Kernel mode callers can execute either at <c>PASSIVE_LEVEL</c> IRQL or <c>DISPATCH_LEVEL</c> IRQL. If the current IRQL
	/// level is <c>DISPATCH_LEVEL</c>, the handle provided in the hKey parameter must be derived from an algorithm handle returned by a
	/// provider that was opened with the <c>BCRYPT_PROV_DISPATCH</c> flag, and any pointers passed to the <c>BCryptDuplicateKey</c>
	/// function must refer to nonpaged (or locked) memory.
	/// </para>
	/// <para>
	/// To call this function in kernel mode, use Cng.lib, which is part of the Driver Development Kit (DDK). For more information, see
	/// WDK and Developer Tools. <c>Windows Server 2008 and Windows Vista:</c> To call this function in kernel mode, use Ksecdd.lib.
	/// </para>
	/// </remarks>
	// https://docs.microsoft.com/en-us/windows/desktop/api/bcrypt/nf-bcrypt-bcryptduplicatekey NTSTATUS BCryptDuplicateKey(
	// BCRYPT_KEY_HANDLE hKey, BCRYPT_KEY_HANDLE *phNewKey, PUCHAR pbKeyObject, ULONG cbKeyObject, ULONG dwFlags );
	[DllImport(Lib.Bcrypt, SetLastError = false, ExactSpelling = true)]
	[PInvokeData("bcrypt.h", MSDNShortId = "13a0b904-353f-498a-bdc2-2fd4e51144ff")]
	public static extern NTStatus BCryptDuplicateKey(BCRYPT_KEY_HANDLE hKey, out SafeBCRYPT_KEY_HANDLE phNewKey, IntPtr pbKeyObject, uint cbKeyObject, uint dwFlags = 0);

	/// <summary>
	/// <para>The <c>BCryptDuplicateKey</c> function creates a duplicate of a symmetric key.</para>
	/// </summary>
	/// <param name="hKey">
	/// <para>The handle of the key to duplicate. This must be a handle to a symmetric key.</para>
	/// </param>
	/// <param name="phNewKey">
	/// <para>
	/// A pointer to a <c>BCRYPT_KEY_HANDLE</c> variable that receives the handle of the duplicate key. This handle is used in subsequent
	/// functions that require a key, such as BCryptEncrypt. This handle must be released when it is no longer needed by passing it to
	/// the BCryptDestroyKey function.
	/// </para>
	/// </param>
	/// <param name="pbKeyObject">
	/// <para>
	/// A pointer to a buffer that receives the duplicate key object. The cbKeyObject parameter contains the size of this buffer. The
	/// required size of this buffer can be obtained by calling the BCryptGetProperty function to get the <c>BCRYPT_OBJECT_LENGTH</c>
	/// property. This will provide the size of the key object for the specified algorithm.
	/// </para>
	/// <para>This memory can only be freed after the phNewKey key handle is destroyed.</para>
	/// </param>
	/// <param name="cbKeyObject">
	/// <para>The size, in bytes, of the pbKeyObject buffer.</para>
	/// </param>
	/// <param name="dwFlags">
	/// <para>
	/// A set of flags that modify the behavior of this function. No flags are currently defined, so this parameter should be zero.
	/// </para>
	/// </param>
	/// <returns>
	/// <para>Returns a status code that indicates the success or failure of the function.</para>
	/// <para>Possible return codes include, but are not limited to, the following.</para>
	/// <list type="table">
	/// <listheader>
	/// <term>Return code</term>
	/// <term>Description</term>
	/// </listheader>
	/// <item>
	/// <term>STATUS_SUCCESS</term>
	/// <term>The function was successful.</term>
	/// </item>
	/// <item>
	/// <term>STATUS_BUFFER_TOO_SMALL</term>
	/// <term>The size of the key object specified by the cbKeyObject parameter is not large enough to hold the key object.</term>
	/// </item>
	/// <item>
	/// <term>STATUS_INVALID_HANDLE</term>
	/// <term>
	/// The key handle in the hKey parameter is not valid. This value is also returned if the key to duplicate is not a symmetric key.
	/// </term>
	/// </item>
	/// <item>
	/// <term>STATUS_INVALID_PARAMETER</term>
	/// <term>One or more parameters are not valid.</term>
	/// </item>
	/// </list>
	/// </returns>
	/// <remarks>
	/// <para>
	/// Depending on what processor modes a provider supports, <c>BCryptDuplicateKey</c> can be called either from user mode or kernel
	/// mode. Kernel mode callers can execute either at <c>PASSIVE_LEVEL</c> IRQL or <c>DISPATCH_LEVEL</c> IRQL. If the current IRQL
	/// level is <c>DISPATCH_LEVEL</c>, the handle provided in the hKey parameter must be derived from an algorithm handle returned by a
	/// provider that was opened with the <c>BCRYPT_PROV_DISPATCH</c> flag, and any pointers passed to the <c>BCryptDuplicateKey</c>
	/// function must refer to nonpaged (or locked) memory.
	/// </para>
	/// <para>
	/// To call this function in kernel mode, use Cng.lib, which is part of the Driver Development Kit (DDK). For more information, see
	/// WDK and Developer Tools. <c>Windows Server 2008 and Windows Vista:</c> To call this function in kernel mode, use Ksecdd.lib.
	/// </para>
	/// </remarks>
	// https://docs.microsoft.com/en-us/windows/desktop/api/bcrypt/nf-bcrypt-bcryptduplicatekey NTSTATUS BCryptDuplicateKey(
	// BCRYPT_KEY_HANDLE hKey, BCRYPT_KEY_HANDLE *phNewKey, PUCHAR pbKeyObject, ULONG cbKeyObject, ULONG dwFlags );
	[DllImport(Lib.Bcrypt, SetLastError = false, ExactSpelling = true)]
	[PInvokeData("bcrypt.h", MSDNShortId = "13a0b904-353f-498a-bdc2-2fd4e51144ff")]
	public static extern NTStatus BCryptDuplicateKey(BCRYPT_KEY_HANDLE hKey, out SafeBCRYPT_KEY_HANDLE phNewKey, SafeAllocatedMemoryHandle pbKeyObject, uint cbKeyObject, uint dwFlags = 0);

	/// <summary>The <c>BCryptEncrypt</c> function encrypts a block of data.</summary>
	/// <param name="hKey">
	/// The handle of the key to use to encrypt the data. This handle is obtained from one of the key creation functions, such as
	/// BCryptGenerateSymmetricKey, BCryptGenerateKeyPair, or BCryptImportKey.
	/// </param>
	/// <param name="pbInput">
	/// The address of a buffer that contains the plaintext to be encrypted. The cbInput parameter contains the size of the plaintext to
	/// encrypt. For more information, see Remarks.
	/// </param>
	/// <param name="cbInput">The number of bytes in the pbInput buffer to encrypt.</param>
	/// <param name="pPaddingInfo">
	/// A pointer to a structure that contains padding information. This parameter is only used with asymmetric keys and authenticated
	/// encryption modes. If an authenticated encryption mode is used, this parameter must point to a
	/// BCRYPT_AUTHENTICATED_CIPHER_MODE_INFO structure. If asymmetric keys are used, the type of structure this parameter points to is
	/// determined by the value of the dwFlags parameter. Otherwise, the parameter must be set to <c>NULL</c>.
	/// </param>
	/// <param name="pbIV">
	/// <para>
	/// The address of a buffer that contains the initialization vector (IV) to use during encryption. The cbIV parameter contains the
	/// size of this buffer. This function will modify the contents of this buffer. If you need to reuse the IV later, make sure you make
	/// a copy of this buffer before calling this function.
	/// </para>
	/// <para>This parameter is optional and can be <c>NULL</c> if no IV is used.</para>
	/// <para>
	/// The required size of the IV can be obtained by calling the BCryptGetProperty function to get the <c>BCRYPT_BLOCK_LENGTH</c>
	/// property. This will provide the size of a block for the algorithm, which is also the size of the IV.
	/// </para>
	/// </param>
	/// <param name="cbIV">The size, in bytes, of the pbIV buffer.</param>
	/// <param name="pbOutput">
	/// <para>
	/// The address of the buffer that receives the ciphertext produced by this function. The cbOutput parameter contains the size of
	/// this buffer. For more information, see Remarks.
	/// </para>
	/// <para>
	/// If this parameter is <c>NULL</c>, the <c>BCryptEncrypt</c> function calculates the size needed for the ciphertext of the data
	/// passed in the pbInput parameter. In this case, the location pointed to by the pcbResult parameter contains this size, and the
	/// function returns <c>STATUS_SUCCESS</c>. The pPaddingInfo parameter is not modified.
	/// </para>
	/// <para>
	/// If the values of both the pbOutput and pbInput parameters are <c>NULL</c>, an error is returned unless an authenticated
	/// encryption algorithm is in use. In the latter case, the call is treated as an authenticated encryption call with zero length
	/// data, and the authentication tag is returned in the pPaddingInfo parameter.
	/// </para>
	/// </param>
	/// <param name="cbOutput">The size, in bytes, of the pbOutput buffer. This parameter is ignored if the pbOutput parameter is <c>NULL</c>.</param>
	/// <param name="pcbResult">
	/// A pointer to a <c>ULONG</c> variable that receives the number of bytes copied to the pbOutput buffer. If pbOutput is <c>NULL</c>,
	/// this receives the size, in bytes, required for the ciphertext.
	/// </param>
	/// <param name="dwFlags">
	/// <para>
	/// A set of flags that modify the behavior of this function. The allowed set of flags depends on the type of key specified by the
	/// hKey parameter.
	/// </para>
	/// <para>If the key is a symmetric key, this can be zero or the following value.</para>
	/// <list type="table">
	/// <listheader>
	/// <term>Value</term>
	/// <term>Meaning</term>
	/// </listheader>
	/// <item>
	/// <term>BCRYPT_BLOCK_PADDING</term>
	/// <term>
	/// Allows the encryption algorithm to pad the data to the next block size. If this flag is not specified, the size of the plaintext
	/// specified in the cbInput parameter must be a multiple of the algorithm's block size. The block size can be obtained by calling
	/// the BCryptGetProperty function to get the BCRYPT_BLOCK_LENGTH property for the key. This will provide the size of a block for the
	/// algorithm. This flag must not be used with the authenticated encryption modes (AES-CCM and AES-GCM).
	/// </term>
	/// </item>
	/// </list>
	/// <para>If the key is an asymmetric key, this can be one of the following values.</para>
	/// <list type="table">
	/// <listheader>
	/// <term>Value</term>
	/// <term>Meaning</term>
	/// </listheader>
	/// <item>
	/// <term>BCRYPT_PAD_NONE</term>
	/// <term>
	/// Do not use any padding. The pPaddingInfo parameter is not used. The size of the plaintext specified in the cbInput parameter must
	/// be a multiple of the algorithm's block size.
	/// </term>
	/// </item>
	/// <item>
	/// <term>BCRYPT_PAD_OAEP</term>
	/// <term>
	/// Use the Optimal Asymmetric Encryption Padding (OAEP) scheme. The pPaddingInfo parameter is a pointer to a
	/// BCRYPT_OAEP_PADDING_INFO structure.
	/// </term>
	/// </item>
	/// <item>
	/// <term>BCRYPT_PAD_PKCS1</term>
	/// <term>The data will be padded with a random number to round out the block size. The pPaddingInfo parameter is not used.</term>
	/// </item>
	/// </list>
	/// </param>
	/// <returns>
	/// <para>Returns a status code that indicates the success or failure of the function.</para>
	/// <para>Possible return codes include, but are not limited to, the following.</para>
	/// <list type="table">
	/// <listheader>
	/// <term>Return code</term>
	/// <term>Description</term>
	/// </listheader>
	/// <item>
	/// <term>STATUS_SUCCESS</term>
	/// <term>The function was successful.</term>
	/// </item>
	/// <item>
	/// <term>STATUS_BUFFER_TOO_SMALL</term>
	/// <term>The size specified by the cbOutput parameter is not large enough to hold the ciphertext.</term>
	/// </item>
	/// <item>
	/// <term>STATUS_INVALID_BUFFER_SIZE</term>
	/// <term>
	/// The cbInput parameter is not a multiple of the algorithm's block size and the BCRYPT_BLOCK_PADDING or the BCRYPT_PAD_NONE flag
	/// was not specified in the dwFlags parameter.
	/// </term>
	/// </item>
	/// <item>
	/// <term>STATUS_INVALID_HANDLE</term>
	/// <term>The key handle in the hKey parameter is not valid.</term>
	/// </item>
	/// <item>
	/// <term>STATUS_INVALID_PARAMETER</term>
	/// <term>One or more parameters are not valid.</term>
	/// </item>
	/// <item>
	/// <term>STATUS_NOT_SUPPORTED</term>
	/// <term>The algorithm does not support encryption.</term>
	/// </item>
	/// </list>
	/// </returns>
	/// <remarks>
	/// <para>
	/// The pbInput and pbOutput parameters can point to the same buffer. In this case, this function will perform the encryption in
	/// place. It is possible that the encrypted data size will be larger than the unencrypted data size, so the buffer must be large
	/// enough to hold the encrypted data.
	/// </para>
	/// <para>
	/// Depending on what processor modes a provider supports, <c>BCryptEncrypt</c> can be called either from user mode or kernel mode.
	/// Kernel mode callers can execute either at <c>PASSIVE_LEVEL</c> IRQL or <c>DISPATCH_LEVEL</c> IRQL. If the current IRQL level is
	/// <c>DISPATCH_LEVEL</c>, the handle provided in the hKey parameter must be derived from an algorithm handle returned by a provider
	/// that was opened with the <c>BCRYPT_PROV_DISPATCH</c> flag, and any pointers passed to the <c>BCryptEncrypt</c> function must
	/// refer to nonpaged (or locked) memory.
	/// </para>
	/// <para>
	/// To call this function in kernel mode, use Cng.lib, which is part of the Driver Development Kit (DDK). For more information, see
	/// WDK and Developer Tools. <c>Windows Server 2008 and Windows Vista:</c> To call this function in kernel mode, use Ksecdd.lib.
	/// </para>
	/// </remarks>
	// https://docs.microsoft.com/en-us/windows/desktop/api/bcrypt/nf-bcrypt-bcryptencrypt NTSTATUS BCryptEncrypt( BCRYPT_KEY_HANDLE
	// hKey, PUCHAR pbInput, ULONG cbInput, VOID *pPaddingInfo, PUCHAR pbIV, ULONG cbIV, PUCHAR pbOutput, ULONG cbOutput, ULONG
	// *pcbResult, ULONG dwFlags );
	[DllImport(Lib.Bcrypt, SetLastError = false, ExactSpelling = true)]
	[PInvokeData("bcrypt.h", MSDNShortId = "69fe4530-4b7c-40db-a85c-f9dc458735e7")]
	public static extern NTStatus BCryptEncrypt(BCRYPT_KEY_HANDLE hKey, byte[] pbInput, uint cbInput, [Optional] IntPtr pPaddingInfo,
		SafeAllocatedMemoryHandle pbIV, uint cbIV, SafeAllocatedMemoryHandle pbOutput, uint cbOutput, out uint pcbResult, EncryptFlags dwFlags);

	/// <summary>The <c>BCryptEncrypt</c> function encrypts a block of data.</summary>
	/// <param name="hKey">
	/// The handle of the key to use to encrypt the data. This handle is obtained from one of the key creation functions, such as
	/// BCryptGenerateSymmetricKey, BCryptGenerateKeyPair, or BCryptImportKey.
	/// </param>
	/// <param name="pbInput">
	/// The address of a buffer that contains the plaintext to be encrypted. The cbInput parameter contains the size of the plaintext to
	/// encrypt. For more information, see Remarks.
	/// </param>
	/// <param name="cbInput">The number of bytes in the pbInput buffer to encrypt.</param>
	/// <param name="pPaddingInfo">
	/// A pointer to a structure that contains padding information. This parameter is only used with asymmetric keys and authenticated
	/// encryption modes. If an authenticated encryption mode is used, this parameter must point to a
	/// BCRYPT_AUTHENTICATED_CIPHER_MODE_INFO structure. If asymmetric keys are used, the type of structure this parameter points to is
	/// determined by the value of the dwFlags parameter. Otherwise, the parameter must be set to <c>NULL</c>.
	/// </param>
	/// <param name="pbIV">
	/// <para>
	/// The address of a buffer that contains the initialization vector (IV) to use during encryption. The cbIV parameter contains the
	/// size of this buffer. This function will modify the contents of this buffer. If you need to reuse the IV later, make sure you make
	/// a copy of this buffer before calling this function.
	/// </para>
	/// <para>This parameter is optional and can be <c>NULL</c> if no IV is used.</para>
	/// <para>
	/// The required size of the IV can be obtained by calling the BCryptGetProperty function to get the <c>BCRYPT_BLOCK_LENGTH</c>
	/// property. This will provide the size of a block for the algorithm, which is also the size of the IV.
	/// </para>
	/// </param>
	/// <param name="cbIV">The size, in bytes, of the pbIV buffer.</param>
	/// <param name="pbOutput">
	/// <para>
	/// The address of the buffer that receives the ciphertext produced by this function. The cbOutput parameter contains the size of
	/// this buffer. For more information, see Remarks.
	/// </para>
	/// <para>
	/// If this parameter is <c>NULL</c>, the <c>BCryptEncrypt</c> function calculates the size needed for the ciphertext of the data
	/// passed in the pbInput parameter. In this case, the location pointed to by the pcbResult parameter contains this size, and the
	/// function returns <c>STATUS_SUCCESS</c>. The pPaddingInfo parameter is not modified.
	/// </para>
	/// <para>
	/// If the values of both the pbOutput and pbInput parameters are <c>NULL</c>, an error is returned unless an authenticated
	/// encryption algorithm is in use. In the latter case, the call is treated as an authenticated encryption call with zero length
	/// data, and the authentication tag is returned in the pPaddingInfo parameter.
	/// </para>
	/// </param>
	/// <param name="cbOutput">The size, in bytes, of the pbOutput buffer. This parameter is ignored if the pbOutput parameter is <c>NULL</c>.</param>
	/// <param name="pcbResult">
	/// A pointer to a <c>ULONG</c> variable that receives the number of bytes copied to the pbOutput buffer. If pbOutput is <c>NULL</c>,
	/// this receives the size, in bytes, required for the ciphertext.
	/// </param>
	/// <param name="dwFlags">
	/// <para>
	/// A set of flags that modify the behavior of this function. The allowed set of flags depends on the type of key specified by the
	/// hKey parameter.
	/// </para>
	/// <para>If the key is a symmetric key, this can be zero or the following value.</para>
	/// <list type="table">
	/// <listheader>
	/// <term>Value</term>
	/// <term>Meaning</term>
	/// </listheader>
	/// <item>
	/// <term>BCRYPT_BLOCK_PADDING</term>
	/// <term>
	/// Allows the encryption algorithm to pad the data to the next block size. If this flag is not specified, the size of the plaintext
	/// specified in the cbInput parameter must be a multiple of the algorithm's block size. The block size can be obtained by calling
	/// the BCryptGetProperty function to get the BCRYPT_BLOCK_LENGTH property for the key. This will provide the size of a block for the
	/// algorithm. This flag must not be used with the authenticated encryption modes (AES-CCM and AES-GCM).
	/// </term>
	/// </item>
	/// </list>
	/// <para>If the key is an asymmetric key, this can be one of the following values.</para>
	/// <list type="table">
	/// <listheader>
	/// <term>Value</term>
	/// <term>Meaning</term>
	/// </listheader>
	/// <item>
	/// <term>BCRYPT_PAD_NONE</term>
	/// <term>
	/// Do not use any padding. The pPaddingInfo parameter is not used. The size of the plaintext specified in the cbInput parameter must
	/// be a multiple of the algorithm's block size.
	/// </term>
	/// </item>
	/// <item>
	/// <term>BCRYPT_PAD_OAEP</term>
	/// <term>
	/// Use the Optimal Asymmetric Encryption Padding (OAEP) scheme. The pPaddingInfo parameter is a pointer to a
	/// BCRYPT_OAEP_PADDING_INFO structure.
	/// </term>
	/// </item>
	/// <item>
	/// <term>BCRYPT_PAD_PKCS1</term>
	/// <term>The data will be padded with a random number to round out the block size. The pPaddingInfo parameter is not used.</term>
	/// </item>
	/// </list>
	/// </param>
	/// <returns>
	/// <para>Returns a status code that indicates the success or failure of the function.</para>
	/// <para>Possible return codes include, but are not limited to, the following.</para>
	/// <list type="table">
	/// <listheader>
	/// <term>Return code</term>
	/// <term>Description</term>
	/// </listheader>
	/// <item>
	/// <term>STATUS_SUCCESS</term>
	/// <term>The function was successful.</term>
	/// </item>
	/// <item>
	/// <term>STATUS_BUFFER_TOO_SMALL</term>
	/// <term>The size specified by the cbOutput parameter is not large enough to hold the ciphertext.</term>
	/// </item>
	/// <item>
	/// <term>STATUS_INVALID_BUFFER_SIZE</term>
	/// <term>
	/// The cbInput parameter is not a multiple of the algorithm's block size and the BCRYPT_BLOCK_PADDING or the BCRYPT_PAD_NONE flag
	/// was not specified in the dwFlags parameter.
	/// </term>
	/// </item>
	/// <item>
	/// <term>STATUS_INVALID_HANDLE</term>
	/// <term>The key handle in the hKey parameter is not valid.</term>
	/// </item>
	/// <item>
	/// <term>STATUS_INVALID_PARAMETER</term>
	/// <term>One or more parameters are not valid.</term>
	/// </item>
	/// <item>
	/// <term>STATUS_NOT_SUPPORTED</term>
	/// <term>The algorithm does not support encryption.</term>
	/// </item>
	/// </list>
	/// </returns>
	/// <remarks>
	/// <para>
	/// The pbInput and pbOutput parameters can point to the same buffer. In this case, this function will perform the encryption in
	/// place. It is possible that the encrypted data size will be larger than the unencrypted data size, so the buffer must be large
	/// enough to hold the encrypted data.
	/// </para>
	/// <para>
	/// Depending on what processor modes a provider supports, <c>BCryptEncrypt</c> can be called either from user mode or kernel mode.
	/// Kernel mode callers can execute either at <c>PASSIVE_LEVEL</c> IRQL or <c>DISPATCH_LEVEL</c> IRQL. If the current IRQL level is
	/// <c>DISPATCH_LEVEL</c>, the handle provided in the hKey parameter must be derived from an algorithm handle returned by a provider
	/// that was opened with the <c>BCRYPT_PROV_DISPATCH</c> flag, and any pointers passed to the <c>BCryptEncrypt</c> function must
	/// refer to nonpaged (or locked) memory.
	/// </para>
	/// <para>
	/// To call this function in kernel mode, use Cng.lib, which is part of the Driver Development Kit (DDK). For more information, see
	/// WDK and Developer Tools. <c>Windows Server 2008 and Windows Vista:</c> To call this function in kernel mode, use Ksecdd.lib.
	/// </para>
	/// </remarks>
	// https://docs.microsoft.com/en-us/windows/desktop/api/bcrypt/nf-bcrypt-bcryptencrypt NTSTATUS BCryptEncrypt( BCRYPT_KEY_HANDLE
	// hKey, PUCHAR pbInput, ULONG cbInput, VOID *pPaddingInfo, PUCHAR pbIV, ULONG cbIV, PUCHAR pbOutput, ULONG cbOutput, ULONG
	// *pcbResult, ULONG dwFlags );
	[DllImport(Lib.Bcrypt, SetLastError = false, ExactSpelling = true)]
	[PInvokeData("bcrypt.h", MSDNShortId = "69fe4530-4b7c-40db-a85c-f9dc458735e7")]
	public static extern NTStatus BCryptEncrypt(BCRYPT_KEY_HANDLE hKey, byte[] pbInput, uint cbInput, [Optional] IntPtr pPaddingInfo,
		SafeAllocatedMemoryHandle pbIV, uint cbIV, [Optional] IntPtr pbOutput, [Optional] uint cbOutput, out uint pcbResult, EncryptFlags dwFlags);

	/// <summary>The <c>BCryptEncrypt</c> function encrypts a block of data.</summary>
	/// <param name="hKey">
	/// The handle of the key to use to encrypt the data. This handle is obtained from one of the key creation functions, such as
	/// BCryptGenerateSymmetricKey, BCryptGenerateKeyPair, or BCryptImportKey.
	/// </param>
	/// <param name="pbInput">
	/// The address of a buffer that contains the plaintext to be encrypted. The cbInput parameter contains the size of the plaintext to
	/// encrypt. For more information, see Remarks.
	/// </param>
	/// <param name="cbInput">The number of bytes in the pbInput buffer to encrypt.</param>
	/// <param name="pPaddingInfo">
	/// A pointer to a structure that contains padding information. This parameter is only used with asymmetric keys and authenticated
	/// encryption modes. If an authenticated encryption mode is used, this parameter must point to a
	/// BCRYPT_AUTHENTICATED_CIPHER_MODE_INFO structure. If asymmetric keys are used, the type of structure this parameter points to is
	/// determined by the value of the dwFlags parameter. Otherwise, the parameter must be set to <c>NULL</c>.
	/// </param>
	/// <param name="pbIV">
	/// <para>
	/// The address of a buffer that contains the initialization vector (IV) to use during encryption. The cbIV parameter contains the
	/// size of this buffer. This function will modify the contents of this buffer. If you need to reuse the IV later, make sure you make
	/// a copy of this buffer before calling this function.
	/// </para>
	/// <para>This parameter is optional and can be <c>NULL</c> if no IV is used.</para>
	/// <para>
	/// The required size of the IV can be obtained by calling the BCryptGetProperty function to get the <c>BCRYPT_BLOCK_LENGTH</c>
	/// property. This will provide the size of a block for the algorithm, which is also the size of the IV.
	/// </para>
	/// </param>
	/// <param name="cbIV">The size, in bytes, of the pbIV buffer.</param>
	/// <param name="pbOutput">
	/// <para>
	/// The address of the buffer that receives the ciphertext produced by this function. The cbOutput parameter contains the size of
	/// this buffer. For more information, see Remarks.
	/// </para>
	/// <para>
	/// If this parameter is <c>NULL</c>, the <c>BCryptEncrypt</c> function calculates the size needed for the ciphertext of the data
	/// passed in the pbInput parameter. In this case, the location pointed to by the pcbResult parameter contains this size, and the
	/// function returns <c>STATUS_SUCCESS</c>. The pPaddingInfo parameter is not modified.
	/// </para>
	/// <para>
	/// If the values of both the pbOutput and pbInput parameters are <c>NULL</c>, an error is returned unless an authenticated
	/// encryption algorithm is in use. In the latter case, the call is treated as an authenticated encryption call with zero length
	/// data, and the authentication tag is returned in the pPaddingInfo parameter.
	/// </para>
	/// </param>
	/// <param name="cbOutput">The size, in bytes, of the pbOutput buffer. This parameter is ignored if the pbOutput parameter is <c>NULL</c>.</param>
	/// <param name="pcbResult">
	/// A pointer to a <c>ULONG</c> variable that receives the number of bytes copied to the pbOutput buffer. If pbOutput is <c>NULL</c>,
	/// this receives the size, in bytes, required for the ciphertext.
	/// </param>
	/// <param name="dwFlags">
	/// <para>
	/// A set of flags that modify the behavior of this function. The allowed set of flags depends on the type of key specified by the
	/// hKey parameter.
	/// </para>
	/// <para>If the key is a symmetric key, this can be zero or the following value.</para>
	/// <list type="table">
	/// <listheader>
	/// <term>Value</term>
	/// <term>Meaning</term>
	/// </listheader>
	/// <item>
	/// <term>BCRYPT_BLOCK_PADDING</term>
	/// <term>
	/// Allows the encryption algorithm to pad the data to the next block size. If this flag is not specified, the size of the plaintext
	/// specified in the cbInput parameter must be a multiple of the algorithm's block size. The block size can be obtained by calling
	/// the BCryptGetProperty function to get the BCRYPT_BLOCK_LENGTH property for the key. This will provide the size of a block for the
	/// algorithm. This flag must not be used with the authenticated encryption modes (AES-CCM and AES-GCM).
	/// </term>
	/// </item>
	/// </list>
	/// <para>If the key is an asymmetric key, this can be one of the following values.</para>
	/// <list type="table">
	/// <listheader>
	/// <term>Value</term>
	/// <term>Meaning</term>
	/// </listheader>
	/// <item>
	/// <term>BCRYPT_PAD_NONE</term>
	/// <term>
	/// Do not use any padding. The pPaddingInfo parameter is not used. The size of the plaintext specified in the cbInput parameter must
	/// be a multiple of the algorithm's block size.
	/// </term>
	/// </item>
	/// <item>
	/// <term>BCRYPT_PAD_OAEP</term>
	/// <term>
	/// Use the Optimal Asymmetric Encryption Padding (OAEP) scheme. The pPaddingInfo parameter is a pointer to a
	/// BCRYPT_OAEP_PADDING_INFO structure.
	/// </term>
	/// </item>
	/// <item>
	/// <term>BCRYPT_PAD_PKCS1</term>
	/// <term>The data will be padded with a random number to round out the block size. The pPaddingInfo parameter is not used.</term>
	/// </item>
	/// </list>
	/// </param>
	/// <returns>
	/// <para>Returns a status code that indicates the success or failure of the function.</para>
	/// <para>Possible return codes include, but are not limited to, the following.</para>
	/// <list type="table">
	/// <listheader>
	/// <term>Return code</term>
	/// <term>Description</term>
	/// </listheader>
	/// <item>
	/// <term>STATUS_SUCCESS</term>
	/// <term>The function was successful.</term>
	/// </item>
	/// <item>
	/// <term>STATUS_BUFFER_TOO_SMALL</term>
	/// <term>The size specified by the cbOutput parameter is not large enough to hold the ciphertext.</term>
	/// </item>
	/// <item>
	/// <term>STATUS_INVALID_BUFFER_SIZE</term>
	/// <term>
	/// The cbInput parameter is not a multiple of the algorithm's block size and the BCRYPT_BLOCK_PADDING or the BCRYPT_PAD_NONE flag
	/// was not specified in the dwFlags parameter.
	/// </term>
	/// </item>
	/// <item>
	/// <term>STATUS_INVALID_HANDLE</term>
	/// <term>The key handle in the hKey parameter is not valid.</term>
	/// </item>
	/// <item>
	/// <term>STATUS_INVALID_PARAMETER</term>
	/// <term>One or more parameters are not valid.</term>
	/// </item>
	/// <item>
	/// <term>STATUS_NOT_SUPPORTED</term>
	/// <term>The algorithm does not support encryption.</term>
	/// </item>
	/// </list>
	/// </returns>
	/// <remarks>
	/// <para>
	/// The pbInput and pbOutput parameters can point to the same buffer. In this case, this function will perform the encryption in
	/// place. It is possible that the encrypted data size will be larger than the unencrypted data size, so the buffer must be large
	/// enough to hold the encrypted data.
	/// </para>
	/// <para>
	/// Depending on what processor modes a provider supports, <c>BCryptEncrypt</c> can be called either from user mode or kernel mode.
	/// Kernel mode callers can execute either at <c>PASSIVE_LEVEL</c> IRQL or <c>DISPATCH_LEVEL</c> IRQL. If the current IRQL level is
	/// <c>DISPATCH_LEVEL</c>, the handle provided in the hKey parameter must be derived from an algorithm handle returned by a provider
	/// that was opened with the <c>BCRYPT_PROV_DISPATCH</c> flag, and any pointers passed to the <c>BCryptEncrypt</c> function must
	/// refer to nonpaged (or locked) memory.
	/// </para>
	/// <para>
	/// To call this function in kernel mode, use Cng.lib, which is part of the Driver Development Kit (DDK). For more information, see
	/// WDK and Developer Tools. <c>Windows Server 2008 and Windows Vista:</c> To call this function in kernel mode, use Ksecdd.lib.
	/// </para>
	/// </remarks>
	// https://docs.microsoft.com/en-us/windows/desktop/api/bcrypt/nf-bcrypt-bcryptencrypt NTSTATUS BCryptEncrypt( BCRYPT_KEY_HANDLE
	// hKey, PUCHAR pbInput, ULONG cbInput, VOID *pPaddingInfo, PUCHAR pbIV, ULONG cbIV, PUCHAR pbOutput, ULONG cbOutput, ULONG
	// *pcbResult, ULONG dwFlags );
	[DllImport(Lib.Bcrypt, SetLastError = false, ExactSpelling = true)]
	[PInvokeData("bcrypt.h", MSDNShortId = "69fe4530-4b7c-40db-a85c-f9dc458735e7")]
	public static extern NTStatus BCryptEncrypt(BCRYPT_KEY_HANDLE hKey, byte[] pbInput, uint cbInput, [Optional] IntPtr pPaddingInfo,
		[Optional] IntPtr pbIV, [Optional] uint cbIV, [Optional] IntPtr pbOutput, [Optional] uint cbOutput, out uint pcbResult, EncryptFlags dwFlags);

	/// <summary>The <c>BCryptEnumAlgorithms</c> function gets a list of the registered algorithm identifiers.</summary>
	/// <param name="dwAlgOperations">
	/// <para>
	/// A value that specifies the algorithm operation types to include in the enumeration. This can be a combination of one or more of
	/// the following values.
	/// </para>
	/// <list type="table">
	/// <listheader>
	/// <term>Value</term>
	/// <term>Meaning</term>
	/// </listheader>
	/// <item>
	/// <term>BCRYPT_CIPHER_OPERATION 0x00000001</term>
	/// <term>Include the cipher algorithms in the enumeration.</term>
	/// </item>
	/// <item>
	/// <term>BCRYPT_HASH_OPERATION 0x00000002</term>
	/// <term>Include the hash algorithms in the enumeration.</term>
	/// </item>
	/// <item>
	/// <term>BCRYPT_ASYMMETRIC_ENCRYPTION_OPERATION 0x00000004</term>
	/// <term>Include the asymmetric encryption algorithms in the enumeration.</term>
	/// </item>
	/// <item>
	/// <term>BCRYPT_SECRET_AGREEMENT_OPERATION 0x00000008</term>
	/// <term>Include the secret agreement algorithms in the enumeration.</term>
	/// </item>
	/// <item>
	/// <term>BCRYPT_SIGNATURE_OPERATION 0x00000010</term>
	/// <term>Include the signature algorithms in the enumeration.</term>
	/// </item>
	/// <item>
	/// <term>BCRYPT_RNG_OPERATION 0x00000020</term>
	/// <term>Include the random number generator (RNG) algorithms in the enumeration.</term>
	/// </item>
	/// </list>
	/// </param>
	/// <param name="pAlgCount">A pointer to a <c>ULONG</c> variable to receive the number of elements in the ppAlgList array.</param>
	/// <param name="ppAlgList">
	/// The address of a BCRYPT_ALGORITHM_IDENTIFIER structure pointer to receive the array of registered algorithm identifiers. This
	/// pointer must be passed to the BCryptFreeBuffer function when it is no longer needed.
	/// </param>
	/// <param name="dwFlags">A set of flags that modify the behavior of this function. No flags are defined for this function.</param>
	/// <returns>
	/// <para>Returns a status code that indicates the success or failure of the function.</para>
	/// <para>Possible return codes include, but are not limited to, the following.</para>
	/// <list type="table">
	/// <listheader>
	/// <term>Return code</term>
	/// <term>Description</term>
	/// </listheader>
	/// <item>
	/// <term>STATUS_SUCCESS</term>
	/// <term>The function was successful.</term>
	/// </item>
	/// <item>
	/// <term>STATUS_INVALID_PARAMETER</term>
	/// <term>One or more parameters are not valid.</term>
	/// </item>
	/// <item>
	/// <term>STATUS_NO_MEMORY</term>
	/// <term>A memory allocation failure occurred.</term>
	/// </item>
	/// </list>
	/// </returns>
	/// <remarks>
	/// <c>BCryptEnumAlgorithms</c> can be called either from user mode or kernel mode. Kernel mode callers must be executing at
	/// <c>PASSIVE_LEVEL</c> IRQL.
	/// </remarks>
	// https://docs.microsoft.com/en-us/windows/desktop/api/bcrypt/nf-bcrypt-bcryptenumalgorithms NTSTATUS BCryptEnumAlgorithms( ULONG
	// dwAlgOperations, ULONG *pAlgCount, BCRYPT_ALGORITHM_IDENTIFIER **ppAlgList, ULONG dwFlags );
	[DllImport(Lib.Bcrypt, SetLastError = false, ExactSpelling = true)]
	[PInvokeData("bcrypt.h", MSDNShortId = "7fa227c0-2b80-49ab-8a19-72f8444d5507")]
	public static extern NTStatus BCryptEnumAlgorithms(AlgOperations dwAlgOperations, out uint pAlgCount, out SafeBCryptBuffer ppAlgList, uint dwFlags = 0);

	/// <summary>The <c>BCryptEnumAlgorithms</c> function gets a list of the registered algorithm identifiers.</summary>
	/// <param name="dwAlgOperations">
	/// <para>
	/// A value that specifies the algorithm operation types to include in the enumeration. This can be a combination of one or more of
	/// the following values.
	/// </para>
	/// <list type="table">
	/// <listheader>
	/// <term>Value</term>
	/// <term>Meaning</term>
	/// </listheader>
	/// <item>
	/// <term>BCRYPT_CIPHER_OPERATION 0x00000001</term>
	/// <term>Include the cipher algorithms in the enumeration.</term>
	/// </item>
	/// <item>
	/// <term>BCRYPT_HASH_OPERATION 0x00000002</term>
	/// <term>Include the hash algorithms in the enumeration.</term>
	/// </item>
	/// <item>
	/// <term>BCRYPT_ASYMMETRIC_ENCRYPTION_OPERATION 0x00000004</term>
	/// <term>Include the asymmetric encryption algorithms in the enumeration.</term>
	/// </item>
	/// <item>
	/// <term>BCRYPT_SECRET_AGREEMENT_OPERATION 0x00000008</term>
	/// <term>Include the secret agreement algorithms in the enumeration.</term>
	/// </item>
	/// <item>
	/// <term>BCRYPT_SIGNATURE_OPERATION 0x00000010</term>
	/// <term>Include the signature algorithms in the enumeration.</term>
	/// </item>
	/// <item>
	/// <term>BCRYPT_RNG_OPERATION 0x00000020</term>
	/// <term>Include the random number generator (RNG) algorithms in the enumeration.</term>
	/// </item>
	/// </list>
	/// </param>
	/// <returns>An array of BCRYPT_ALGORITHM_IDENTIFIER structures that contains the registered algorithm identifiers.</returns>
	[PInvokeData("bcrypt.h", MSDNShortId = "7fa227c0-2b80-49ab-8a19-72f8444d5507")]
	public static BCRYPT_ALGORITHM_IDENTIFIER[] BCryptEnumAlgorithms(AlgOperations dwAlgOperations)
	{
		BCryptEnumAlgorithms(dwAlgOperations, out var sz, out var mem).ThrowIfFailed();
		return mem.DangerousGetHandle().ToArray<BCRYPT_ALGORITHM_IDENTIFIER>((int)sz)!;
	}

	/// <summary>
	/// The <c>BCryptEnumContextFunctionProviders</c> function obtains the providers for the cryptographic functions for a context in the
	/// specified configuration table.
	/// </summary>
	/// <param name="dwTable">
	/// <para>
	/// Identifies the configuration table from which to retrieve the context function providers. This can be one of the following values.
	/// </para>
	/// <list type="table">
	/// <listheader>
	/// <term>Value</term>
	/// <term>Meaning</term>
	/// </listheader>
	/// <item>
	/// <term>CRYPT_LOCAL</term>
	/// <term>Retrieve the context functions from the local-machine configuration table.</term>
	/// </item>
	/// <item>
	/// <term>CRYPT_DOMAIN</term>
	/// <term>This value is not available for use.</term>
	/// </item>
	/// </list>
	/// </param>
	/// <param name="pszContext">
	/// A pointer to a null-terminated Unicode string that contains the identifier of the context to enumerate the function providers for.
	/// </param>
	/// <param name="dwInterface">
	/// <para>Identifies the cryptographic interface to retrieve the function providers for. This can be one of the following values.</para>
	/// <list type="table">
	/// <listheader>
	/// <term>Value</term>
	/// <term>Meaning</term>
	/// </listheader>
	/// <item>
	/// <term>BCRYPT_ASYMMETRIC_ENCRYPTION_INTERFACE</term>
	/// <term>Retrieve the asymmetric encryption function providers.</term>
	/// </item>
	/// <item>
	/// <term>BCRYPT_CIPHER_INTERFACE</term>
	/// <term>Retrieve the cipher function providers.</term>
	/// </item>
	/// <item>
	/// <term>BCRYPT_HASH_INTERFACE</term>
	/// <term>Retrieve the hash function providers.</term>
	/// </item>
	/// <item>
	/// <term>BCRYPT_RNG_INTERFACE</term>
	/// <term>Retrieve the random number generator function providers.</term>
	/// </item>
	/// <item>
	/// <term>BCRYPT_SECRET_AGREEMENT_INTERFACE</term>
	/// <term>Retrieve the secret agreement function providers.</term>
	/// </item>
	/// <item>
	/// <term>BCRYPT_SIGNATURE_INTERFACE</term>
	/// <term>Retrieve the signature function providers.</term>
	/// </item>
	/// <item>
	/// <term>NCRYPT_KEY_STORAGE_INTERFACE</term>
	/// <term>Retrieve the key storage function providers.</term>
	/// </item>
	/// <item>
	/// <term>NCRYPT_SCHANNEL_INTERFACE</term>
	/// <term>Retrieve the Schannel function providers.</term>
	/// </item>
	/// </list>
	/// </param>
	/// <param name="pszFunction">
	/// A pointer to a null-terminated Unicode string that contains the identifier of the function to enumerate the providers for.
	/// </param>
	/// <param name="pcbBuffer">
	/// <para>
	/// The address of a <c>ULONG</c> variable that, on entry, contains the size, in bytes, of the buffer pointed to by ppBuffer. If this
	/// size is not large enough to hold the set of context identifiers, this function will fail with <c>STATUS_BUFFER_TOO_SMALL</c>.
	/// </para>
	/// <para>After this function returns, this value contains the number of bytes that were copied to the ppBuffer buffer.</para>
	/// </param>
	/// <param name="ppBuffer">
	/// <para>
	/// The address of a pointer to a CRYPT_CONTEXT_FUNCTION_PROVIDERS structure that receives the set of context function providers
	/// retrieved by this function. The value pointed to by the pcbBuffer parameter contains the size of this buffer.
	/// </para>
	/// <para>
	/// If the value pointed to by this parameter is <c>NULL</c>, this function will allocate the required memory. This memory must be
	/// freed when it is no longer needed by passing this pointer to the BCryptFreeBuffer function.
	/// </para>
	/// <para>
	/// If this parameter is <c>NULL</c>, this function will place the required size, in bytes, in the variable pointed to by the
	/// pcbBuffer parameter and return <c>STATUS_BUFFER_TOO_SMALL</c>.
	/// </para>
	/// </param>
	/// <returns>
	/// <para>Returns a status code that indicates the success or failure of the function.</para>
	/// <para>Possible return codes include, but are not limited to, the following.</para>
	/// <list type="table">
	/// <listheader>
	/// <term>Return code</term>
	/// <term>Description</term>
	/// </listheader>
	/// <item>
	/// <term>STATUS_SUCCESS</term>
	/// <term>The function was successful.</term>
	/// </item>
	/// <item>
	/// <term>STATUS_BUFFER_TOO_SMALL</term>
	/// <term>
	/// The ppBuffer parameter is not NULL, and the value pointed to by the pcbBuffer parameter is not large enough to hold the set of contexts.
	/// </term>
	/// </item>
	/// <item>
	/// <term>STATUS_INVALID_PARAMETER</term>
	/// <term>One or more parameters are not valid.</term>
	/// </item>
	/// <item>
	/// <term>STATUS_NO_MEMORY</term>
	/// <term>A memory allocation failure occurred.</term>
	/// </item>
	/// <item>
	/// <term>STATUS_NOT_FOUND</term>
	/// <term>No context function providers that match the specified criteria were found.</term>
	/// </item>
	/// </list>
	/// </returns>
	/// <remarks>
	/// <para><c>BCryptEnumContextFunctionProviders</c> can be called only in user mode.</para>
	/// <para>Examples</para>
	/// <para>
	/// The following example shows how to use the <c>BCryptEnumContextFunctionProviders</c> function to enumerate the providers for all
	/// key storage functions for all contexts in the local-machine configuration table.
	/// </para>
	/// </remarks>
	// https://docs.microsoft.com/en-us/windows/desktop/api/bcrypt/nf-bcrypt-bcryptenumcontextfunctionproviders NTSTATUS
	// BCryptEnumContextFunctionProviders( ULONG dwTable, LPCWSTR pszContext, ULONG dwInterface, LPCWSTR pszFunction, ULONG *pcbBuffer,
	// PCRYPT_CONTEXT_FUNCTION_PROVIDERS *ppBuffer );
	[DllImport(Lib.Bcrypt, SetLastError = false, ExactSpelling = true, CharSet = CharSet.Unicode)]
	[PInvokeData("bcrypt.h", MSDNShortId = "82776e61-03bb-463b-8767-fa4f70fe1341")]
	public static extern NTStatus BCryptEnumContextFunctionProviders(ContextConfigTable dwTable, string pszContext, InterfaceId dwInterface, string pszFunction, out uint pcbBuffer, out SafeBCryptBuffer ppBuffer);

	/// <summary>
	/// The <c>BCryptEnumContextFunctionProviders</c> function obtains the providers for the cryptographic functions for a context in the
	/// specified configuration table.
	/// </summary>
	/// <param name="dwTable">
	/// <para>
	/// Identifies the configuration table from which to retrieve the context function providers. This can be one of the following values.
	/// </para>
	/// <list type="table">
	/// <listheader>
	/// <term>Value</term>
	/// <term>Meaning</term>
	/// </listheader>
	/// <item>
	/// <term>CRYPT_LOCAL</term>
	/// <term>Retrieve the context functions from the local-machine configuration table.</term>
	/// </item>
	/// <item>
	/// <term>CRYPT_DOMAIN</term>
	/// <term>This value is not available for use.</term>
	/// </item>
	/// </list>
	/// </param>
	/// <param name="pszContext">
	/// A pointer to a null-terminated Unicode string that contains the identifier of the context to enumerate the function providers for.
	/// </param>
	/// <param name="dwInterface">
	/// <para>Identifies the cryptographic interface to retrieve the function providers for. This can be one of the following values.</para>
	/// <list type="table">
	/// <listheader>
	/// <term>Value</term>
	/// <term>Meaning</term>
	/// </listheader>
	/// <item>
	/// <term>BCRYPT_ASYMMETRIC_ENCRYPTION_INTERFACE</term>
	/// <term>Retrieve the asymmetric encryption function providers.</term>
	/// </item>
	/// <item>
	/// <term>BCRYPT_CIPHER_INTERFACE</term>
	/// <term>Retrieve the cipher function providers.</term>
	/// </item>
	/// <item>
	/// <term>BCRYPT_HASH_INTERFACE</term>
	/// <term>Retrieve the hash function providers.</term>
	/// </item>
	/// <item>
	/// <term>BCRYPT_RNG_INTERFACE</term>
	/// <term>Retrieve the random number generator function providers.</term>
	/// </item>
	/// <item>
	/// <term>BCRYPT_SECRET_AGREEMENT_INTERFACE</term>
	/// <term>Retrieve the secret agreement function providers.</term>
	/// </item>
	/// <item>
	/// <term>BCRYPT_SIGNATURE_INTERFACE</term>
	/// <term>Retrieve the signature function providers.</term>
	/// </item>
	/// <item>
	/// <term>NCRYPT_KEY_STORAGE_INTERFACE</term>
	/// <term>Retrieve the key storage function providers.</term>
	/// </item>
	/// <item>
	/// <term>NCRYPT_SCHANNEL_INTERFACE</term>
	/// <term>Retrieve the Schannel function providers.</term>
	/// </item>
	/// </list>
	/// </param>
	/// <param name="pszFunction">
	/// A pointer to a null-terminated Unicode string that contains the identifier of the function to enumerate the providers for.
	/// </param>
	/// <returns>An array of strings that contains the identifiers of the function providers contained in this set.</returns>
	[PInvokeData("bcrypt.h", MSDNShortId = "82776e61-03bb-463b-8767-fa4f70fe1341")]
	public static string?[] BCryptEnumContextFunctionProviders(ContextConfigTable dwTable, string pszContext, InterfaceId dwInterface, string pszFunction)
	{
		BCryptEnumContextFunctionProviders(dwTable, pszContext, dwInterface, pszFunction, out var _, out var mem).ThrowIfFailed();
		return mem.ToStructure<CRYPT_CONTEXT_FUNCTION_PROVIDERS>()._rgpszProviders.ToArray();
	}

	/// <summary>
	/// The <c>BCryptEnumContextFunctions</c> function obtains the cryptographic functions for a context in the specified configuration table.
	/// </summary>
	/// <param name="dwTable">
	/// <para>Identifies the configuration table from which to retrieve the context functions. This can be one of the following values.</para>
	/// <list type="table">
	/// <listheader>
	/// <term>Value</term>
	/// <term>Meaning</term>
	/// </listheader>
	/// <item>
	/// <term>CRYPT_LOCAL</term>
	/// <term>Retrieve the context functions from the local-machine configuration table.</term>
	/// </item>
	/// <item>
	/// <term>CRYPT_DOMAIN</term>
	/// <term>This value is not available for use.</term>
	/// </item>
	/// </list>
	/// </param>
	/// <param name="pszContext">
	/// A pointer to a null-terminated Unicode string that contains the identifier of the context to enumerate the functions for.
	/// </param>
	/// <param name="dwInterface">
	/// <para>Identifies the cryptographic interface to retrieve the functions for. This can be one of the following values.</para>
	/// <list type="table">
	/// <listheader>
	/// <term>Value</term>
	/// <term>Meaning</term>
	/// </listheader>
	/// <item>
	/// <term>BCRYPT_ASYMMETRIC_ENCRYPTION_INTERFACE</term>
	/// <term>Retrieve the asymmetric encryption functions.</term>
	/// </item>
	/// <item>
	/// <term>BCRYPT_CIPHER_INTERFACE</term>
	/// <term>Retrieve the cipher functions.</term>
	/// </item>
	/// <item>
	/// <term>BCRYPT_HASH_INTERFACE</term>
	/// <term>Retrieve the hash functions.</term>
	/// </item>
	/// <item>
	/// <term>BCRYPT_RNG_INTERFACE</term>
	/// <term>Retrieve the random number generator functions.</term>
	/// </item>
	/// <item>
	/// <term>BCRYPT_SECRET_AGREEMENT_INTERFACE</term>
	/// <term>Retrieve the secret agreement functions.</term>
	/// </item>
	/// <item>
	/// <term>BCRYPT_SIGNATURE_INTERFACE</term>
	/// <term>Retrieve the signature functions.</term>
	/// </item>
	/// <item>
	/// <term>NCRYPT_KEY_STORAGE_INTERFACE</term>
	/// <term>Retrieve the key storage functions.</term>
	/// </item>
	/// <item>
	/// <term>NCRYPT_SCHANNEL_INTERFACE</term>
	/// <term>Retrieve the Schannel functions.</term>
	/// </item>
	/// </list>
	/// </param>
	/// <param name="pcbBuffer">
	/// <para>
	/// The address of a <c>ULONG</c> variable that, on entry, contains the size, in bytes, of the buffer pointed to by ppBuffer. If this
	/// size is not large enough to hold the set of context identifiers, this function will fail with <c>STATUS_BUFFER_TOO_SMALL</c>.
	/// </para>
	/// <para>After this function returns, this value contains the number of bytes that were copied to the ppBuffer buffer.</para>
	/// </param>
	/// <param name="ppBuffer">
	/// <para>
	/// The address of a pointer to a CRYPT_CONTEXT_FUNCTIONS structure that receives the set of context functions retrieved by this
	/// function. The value pointed to by the pcbBuffer parameter contains the size of this buffer.
	/// </para>
	/// <para>
	/// If the value pointed to by this parameter is <c>NULL</c>, this function will allocate the required memory. This memory must be
	/// freed when it is no longer needed by passing this pointer to the BCryptFreeBuffer function.
	/// </para>
	/// <para>
	/// If this parameter is <c>NULL</c>, this function will place the required size, in bytes, in the variable pointed to by the
	/// pcbBuffer parameter and return <c>STATUS_BUFFER_TOO_SMALL</c>.
	/// </para>
	/// </param>
	/// <returns>
	/// <para>Returns a status code that indicates the success or failure of the function.</para>
	/// <para>Possible return codes include, but are not limited to, the following.</para>
	/// <list type="table">
	/// <listheader>
	/// <term>Return code</term>
	/// <term>Description</term>
	/// </listheader>
	/// <item>
	/// <term>STATUS_SUCCESS</term>
	/// <term>The function was successful.</term>
	/// </item>
	/// <item>
	/// <term>STATUS_BUFFER_TOO_SMALL</term>
	/// <term>
	/// The ppBuffer parameter is not NULL, and the value pointed to by the pcbBuffer parameter is not large enough to hold the set of contexts.
	/// </term>
	/// </item>
	/// <item>
	/// <term>STATUS_INVALID_PARAMETER</term>
	/// <term>One or more parameters are not valid.</term>
	/// </item>
	/// <item>
	/// <term>STATUS_NO_MEMORY</term>
	/// <term>A memory allocation failure occurred.</term>
	/// </item>
	/// <item>
	/// <term>STATUS_NOT_FOUND</term>
	/// <term>No context functions that match the specified criteria were found.</term>
	/// </item>
	/// </list>
	/// </returns>
	/// <remarks>
	/// <para><c>BCryptEnumContextFunctions</c> can be called only in user mode.</para>
	/// <para>Examples</para>
	/// <para>
	/// The following example shows how to use the <c>BCryptEnumContextFunctions</c> function to enumerate the key storage functions for
	/// all contexts in the local-machine configuration table.
	/// </para>
	/// </remarks>
	// https://docs.microsoft.com/en-us/windows/desktop/api/bcrypt/nf-bcrypt-bcryptenumcontextfunctions NTSTATUS
	// BCryptEnumContextFunctions( ULONG dwTable, LPCWSTR pszContext, ULONG dwInterface, ULONG *pcbBuffer, PCRYPT_CONTEXT_FUNCTIONS
	// *ppBuffer );
	[DllImport(Lib.Bcrypt, SetLastError = false, ExactSpelling = true, CharSet = CharSet.Unicode)]
	[PInvokeData("bcrypt.h", MSDNShortId = "81bdfd47-7001-4e63-a8b3-33dae99f2c66")]
	public static extern NTStatus BCryptEnumContextFunctions(ContextConfigTable dwTable, string pszContext, InterfaceId dwInterface, out uint pcbBuffer, out SafeBCryptBuffer ppBuffer);

	/// <summary>
	/// The <c>BCryptEnumContextFunctions</c> function obtains the cryptographic functions for a context in the specified configuration table.
	/// </summary>
	/// <param name="dwTable">
	/// <para>Identifies the configuration table from which to retrieve the context functions. This can be one of the following values.</para>
	/// <list type="table">
	/// <listheader>
	/// <term>Value</term>
	/// <term>Meaning</term>
	/// </listheader>
	/// <item>
	/// <term>CRYPT_LOCAL</term>
	/// <term>Retrieve the context functions from the local-machine configuration table.</term>
	/// </item>
	/// <item>
	/// <term>CRYPT_DOMAIN</term>
	/// <term>This value is not available for use.</term>
	/// </item>
	/// </list>
	/// </param>
	/// <param name="pszContext">
	/// A pointer to a null-terminated Unicode string that contains the identifier of the context to enumerate the functions for.
	/// </param>
	/// <param name="dwInterface">
	/// <para>Identifies the cryptographic interface to retrieve the functions for. This can be one of the following values.</para>
	/// <list type="table">
	/// <listheader>
	/// <term>Value</term>
	/// <term>Meaning</term>
	/// </listheader>
	/// <item>
	/// <term>BCRYPT_ASYMMETRIC_ENCRYPTION_INTERFACE</term>
	/// <term>Retrieve the asymmetric encryption functions.</term>
	/// </item>
	/// <item>
	/// <term>BCRYPT_CIPHER_INTERFACE</term>
	/// <term>Retrieve the cipher functions.</term>
	/// </item>
	/// <item>
	/// <term>BCRYPT_HASH_INTERFACE</term>
	/// <term>Retrieve the hash functions.</term>
	/// </item>
	/// <item>
	/// <term>BCRYPT_RNG_INTERFACE</term>
	/// <term>Retrieve the random number generator functions.</term>
	/// </item>
	/// <item>
	/// <term>BCRYPT_SECRET_AGREEMENT_INTERFACE</term>
	/// <term>Retrieve the secret agreement functions.</term>
	/// </item>
	/// <item>
	/// <term>BCRYPT_SIGNATURE_INTERFACE</term>
	/// <term>Retrieve the signature functions.</term>
	/// </item>
	/// <item>
	/// <term>NCRYPT_KEY_STORAGE_INTERFACE</term>
	/// <term>Retrieve the key storage functions.</term>
	/// </item>
	/// <item>
	/// <term>NCRYPT_SCHANNEL_INTERFACE</term>
	/// <term>Retrieve the Schannel functions.</term>
	/// </item>
	/// </list>
	/// </param>
	/// <returns>An array of strings that contains the names of the identifiers of the cryptographic functions.</returns>
	[PInvokeData("bcrypt.h", MSDNShortId = "81bdfd47-7001-4e63-a8b3-33dae99f2c66")]
	public static string?[] BCryptEnumContextFunctions(ContextConfigTable dwTable, string pszContext, InterfaceId dwInterface)
	{
		BCryptEnumContextFunctions(dwTable, pszContext, dwInterface, out _, out var buf).ThrowIfFailed();
		return buf.ToStructure<CRYPT_CONTEXT_FUNCTIONS>()._rgpszFunctions.ToArray();
	}

	/// <summary>
	/// <para>
	/// [ <c>BCryptEnumContexts</c> is available for use in the operating systems specified in the Requirements section. It may be
	/// altered or unavailable in subsequent versions.]
	/// </para>
	/// <para>The <c>BCryptEnumContexts</c> function obtains the identifiers of the contexts in the specified configuration table.</para>
	/// </summary>
	/// <param name="dwTable">
	/// <para>Identifies the configuration table from which to retrieve the contexts. This can be one of the following values.</para>
	/// <list type="table">
	/// <listheader>
	/// <term>Value</term>
	/// <term>Meaning</term>
	/// </listheader>
	/// <item>
	/// <term>CRYPT_LOCAL</term>
	/// <term>Retrieve the contexts from the local-machine configuration table.</term>
	/// </item>
	/// <item>
	/// <term>CRYPT_DOMAIN</term>
	/// <term>This value is not available for use.</term>
	/// </item>
	/// </list>
	/// </param>
	/// <param name="pcbBuffer">
	/// <para>
	/// The address of a <c>ULONG</c> variable that, on entry, contains the size, in bytes, of the buffer pointed to by ppBuffer. If this
	/// size is not large enough to hold the set of context identifiers, this function will fail with <c>STATUS_BUFFER_TOO_SMALL</c>.
	/// </para>
	/// <para>After this function returns, this value contains the number of bytes that were copied to the ppBuffer buffer.</para>
	/// </param>
	/// <param name="ppBuffer">
	/// <para>
	/// The address of a pointer to a CRYPT_CONTEXTS structure that receives the set of contexts retrieved by this function. The value
	/// pointed to by the pcbBuffer parameter contains the size of this buffer.
	/// </para>
	/// <para>
	/// If the value pointed to by this parameter is <c>NULL</c>, this function will allocate the required memory. This memory must be
	/// freed when it is no longer needed by passing this pointer to the BCryptFreeBuffer function.
	/// </para>
	/// <para>
	/// If this parameter is <c>NULL</c>, this function will place the required size, in bytes, in the variable pointed to by the
	/// pcbBuffer parameter and return <c>STATUS_BUFFER_TOO_SMALL</c>.
	/// </para>
	/// </param>
	/// <returns>
	/// <para>Returns a status code that indicates the success or failure of the function.</para>
	/// <para>Possible return codes include, but are not limited to, the following.</para>
	/// <list type="table">
	/// <listheader>
	/// <term>Return code</term>
	/// <term>Description</term>
	/// </listheader>
	/// <item>
	/// <term>STATUS_SUCCESS</term>
	/// <term>The function was successful.</term>
	/// </item>
	/// <item>
	/// <term>STATUS_INVALID_PARAMETER</term>
	/// <term>One or more parameters are not valid.</term>
	/// </item>
	/// <item>
	/// <term>STATUS_NO_MEMORY</term>
	/// <term>A memory allocation failure occurred.</term>
	/// </item>
	/// <item>
	/// <term>STATUS_BUFFER_TOO_SMALL</term>
	/// <term>
	/// The ppBuffer parameter is not NULL, and the value pointed to by the pcbBuffer parameter is not large enough to hold the set of contexts.
	/// </term>
	/// </item>
	/// </list>
	/// </returns>
	/// <remarks>
	/// <para><c>BCryptEnumContexts</c> can be called only in user mode.</para>
	/// <para>Examples</para>
	/// <para>
	/// The following example shows how to use the <c>BCryptEnumContexts</c> function to allocate the memory for the ppBuffer buffer.
	/// </para>
	/// <para>
	/// The following example shows how to use the <c>BCryptEnumContexts</c> function to allocate your own memory for the ppBuffer buffer.
	/// </para>
	/// </remarks>
	// https://docs.microsoft.com/en-us/windows/desktop/api/bcrypt/nf-bcrypt-bcryptenumcontexts NTSTATUS BCryptEnumContexts( ULONG
	// dwTable, ULONG *pcbBuffer, PCRYPT_CONTEXTS *ppBuffer );
	[DllImport(Lib.Bcrypt, SetLastError = false, ExactSpelling = true)]
	[PInvokeData("bcrypt.h", MSDNShortId = "02646a80-6e93-4169-83da-0488ff3da56f")]
	public static extern NTStatus BCryptEnumContexts(ContextConfigTable dwTable, out uint pcbBuffer, out SafeBCryptBuffer ppBuffer);

	/// <summary>
	/// <para>
	/// [ <c>BCryptEnumContexts</c> is available for use in the operating systems specified in the Requirements section. It may be
	/// altered or unavailable in subsequent versions.]
	/// </para>
	/// <para>The <c>BCryptEnumContexts</c> function obtains the identifiers of the contexts in the specified configuration table.</para>
	/// </summary>
	/// <param name="dwTable">
	/// <para>Identifies the configuration table from which to retrieve the contexts. This can be one of the following values.</para>
	/// <list type="table">
	/// <listheader>
	/// <term>Value</term>
	/// <term>Meaning</term>
	/// </listheader>
	/// <item>
	/// <term>CRYPT_LOCAL</term>
	/// <term>Retrieve the contexts from the local-machine configuration table.</term>
	/// </item>
	/// <item>
	/// <term>CRYPT_DOMAIN</term>
	/// <term>This value is not available for use.</term>
	/// </item>
	/// </list>
	/// </param>
	/// <returns>An array of strings that contains the names of the identifiers of the contexts.</returns>
	[PInvokeData("bcrypt.h", MSDNShortId = "02646a80-6e93-4169-83da-0488ff3da56f")]
	public static string?[] BCryptEnumContexts(ContextConfigTable dwTable)
	{
		BCryptEnumContexts(dwTable, out _, out var buf).ThrowIfFailed();
		return buf.ToStructure<CRYPT_CONTEXTS>()._rgpszContexts.ToArray();
	}

	/// <summary>The <c>BCryptEnumProviders</c> function obtains all of the CNG providers that support a specified algorithm.</summary>
	/// <param name="pszAlgId">
	/// A pointer to a null-terminated Unicode string that identifies the algorithm to obtain the providers for. This can be one of the
	/// predefined CNG Algorithm Identifiers or another algorithm identifier.
	/// </param>
	/// <param name="pImplCount">A pointer to a <c>ULONG</c> variable to receive the number of elements in the ppImplList array.</param>
	/// <param name="ppImplList">
	/// The address of an array of BCRYPT_PROVIDER_NAME structures to receive the collection of providers that support the specified
	/// algorithm. The pImplCount parameter receives the number of elements in this array. This memory must be freed when it is no longer
	/// needed by passing this pointer to the BCryptFreeBuffer function.
	/// </param>
	/// <param name="dwFlags">
	/// A set of flags that modifies the behavior of this function. There are currently no flags defined, so this parameter must be zero.
	/// </param>
	/// <returns>
	/// <para>Returns a status code that indicates the success or failure of the function.</para>
	/// <para>Possible return codes include, but are not limited to, the following.</para>
	/// <list type="table">
	/// <listheader>
	/// <term>Return code</term>
	/// <term>Description</term>
	/// </listheader>
	/// <item>
	/// <term>STATUS_SUCCESS</term>
	/// <term>The function was successful.</term>
	/// </item>
	/// <item>
	/// <term>STATUS_INVALID_PARAMETER</term>
	/// <term>One or more parameters are not valid.</term>
	/// </item>
	/// <item>
	/// <term>STATUS_NO_MEMORY</term>
	/// <term>A memory allocation failure occurred.</term>
	/// </item>
	/// </list>
	/// </returns>
	/// <remarks>
	/// <c>BCryptEnumProviders</c> can be called either from user mode or kernel mode. Kernel mode callers must be executing at
	/// <c>PASSIVE_LEVEL</c> IRQL.
	/// </remarks>
	// https://docs.microsoft.com/en-us/windows/desktop/api/bcrypt/nf-bcrypt-bcryptenumproviders NTSTATUS BCryptEnumProviders( LPCWSTR
	// pszAlgId, ULONG *pImplCount, BCRYPT_PROVIDER_NAME **ppImplList, ULONG dwFlags );
	[DllImport(Lib.Bcrypt, SetLastError = false, ExactSpelling = true)]
	[PInvokeData("bcrypt.h", MSDNShortId = "0496f241-9530-47fb-89e2-15d7ab6da87a")]
	public static extern NTStatus BCryptEnumProviders([MarshalAs(UnmanagedType.LPWStr)] string pszAlgId, out uint pImplCount, out SafeBCryptBuffer ppImplList, uint dwFlags = 0);

	/// <summary>The <c>BCryptEnumProviders</c> function obtains all of the CNG providers that support a specified algorithm.</summary>
	/// <param name="pszAlgId">
	/// A pointer to a null-terminated Unicode string that identifies the algorithm to obtain the providers for. This can be one of the
	/// predefined CNG Algorithm Identifiers or another algorithm identifier.
	/// </param>
	/// <returns>An array of strings that contains the names of the providers.</returns>
	[PInvokeData("bcrypt.h", MSDNShortId = "0496f241-9530-47fb-89e2-15d7ab6da87a")]
	public static string[] BCryptEnumProviders(string pszAlgId)
	{
		BCryptEnumProviders(pszAlgId, out var sz, out var buf).ThrowIfFailed();
		return Array.ConvertAll(buf.DangerousGetHandle().ToArray<BCRYPT_PROVIDER_NAME>((int)sz)!, s => s.pszProviderName);
	}

	/// <summary>The <c>BCryptEnumRegisteredProviders</c> function retrieves information about the registered providers.</summary>
	/// <param name="pcbBuffer">
	/// <para>
	/// A pointer to a <c>ULONG</c> value that, on entry, contains the size, in bytes, of the buffer pointed to by the ppBuffer
	/// parameter. On exit, this value receives either the number of bytes copied to the buffer or the required size, in bytes, of the buffer.
	/// </para>
	/// <para>
	/// <c>Note</c> This is the total size, in bytes, of the entire buffer, not just the size of the CRYPT_PROVIDERS structure. The
	/// buffer must be able to hold other data for the providers in addition to the <c>CRYPT_PROVIDERS</c> structure.
	/// </para>
	/// </param>
	/// <param name="ppBuffer">
	/// <para>
	/// A pointer to a buffer pointer that receives a CRYPT_PROVIDERS structure and other data that describes the collection of
	/// registered providers.
	/// </para>
	/// <para>
	/// If this parameter is <c>NULL</c>, this function will return <c>STATUS_BUFFER_TOO_SMALL</c> and place in the value pointed to by
	/// the pcbBuffer parameter, the required size, in bytes, of all the data.
	/// </para>
	/// <para>
	/// If this parameter is the address of a <c>NULL</c> pointer, this function will allocate the required memory, fill the memory with
	/// the information about the providers, and place the pointer to this memory in this parameter. When you have finished using this
	/// memory, free it by passing this pointer to the BCryptFreeBuffer function.
	/// </para>
	/// <para>
	/// If this parameter is the address of a non- <c>NULL</c> pointer, this function will copy the provider information into this
	/// buffer. The pcbBuffer parameter must contain the size, in bytes, of the entire buffer. If the buffer is not large enough to hold
	/// all of the provider information, this function will return <c>STATUS_BUFFER_TOO_SMALL</c>.
	/// </para>
	/// </param>
	/// <returns>
	/// <para>Returns a status code that indicates the success or failure of the function.</para>
	/// <para>Possible return codes include, but are not limited to, the following.</para>
	/// <list type="table">
	/// <listheader>
	/// <term>Return code</term>
	/// <term>Description</term>
	/// </listheader>
	/// <item>
	/// <term>STATUS_SUCCESS</term>
	/// <term>The function was successful.</term>
	/// </item>
	/// <item>
	/// <term>STATUS_BUFFER_TOO_SMALL</term>
	/// <term>The size specified by the pcbBuffer parameter is not large enough to hold all of the data.</term>
	/// </item>
	/// <item>
	/// <term>STATUS_INVALID_PARAMETER</term>
	/// <term>One or more parameters are not valid.</term>
	/// </item>
	/// </list>
	/// </returns>
	/// <remarks>
	/// <para>The <c>BCryptEnumRegisteredProviders</c> function can be called in one of two ways:</para>
	/// <list type="bullet">
	/// <item>
	/// <term>
	/// The first is to have the <c>BCryptEnumRegisteredProviders</c> function allocate the memory. This is accomplished by passing the
	/// address of a <c>NULL</c> pointer for the ppBuffer parameter. This code will allocate the memory required for the CRYPT_PROVIDERS
	/// structure and the associated strings. When the <c>BCryptEnumRegisteredProviders</c> function is used in this manner, you must
	/// free the memory when it is no longer needed by passing ppBuffer to the BCryptFreeBuffer function.
	/// </term>
	/// </item>
	/// <item>
	/// <term>
	/// The second method is to allocate the required memory yourself. This is accomplished by calling the
	/// <c>BCryptEnumRegisteredProviders</c> function with <c>NULL</c> for the ppBuffer parameter. The
	/// <c>BCryptEnumRegisteredProviders</c> function will place in the value pointed to by the pcbBuffer parameter, the required size,
	/// in bytes, of the CRYPT_PROVIDERS structure and all strings. You then allocate the required memory and pass the address of this
	/// buffer pointer for the ppBuffer parameter in a second call to the <c>BCryptEnumRegisteredProviders</c> function.
	/// </term>
	/// </item>
	/// </list>
	/// <para><c>BCryptEnumRegisteredProviders</c> can be called only in user mode.</para>
	/// </remarks>
	// https://docs.microsoft.com/en-us/windows/desktop/api/bcrypt/nf-bcrypt-bcryptenumregisteredproviders NTSTATUS
	// BCryptEnumRegisteredProviders( ULONG *pcbBuffer, PCRYPT_PROVIDERS *ppBuffer );
	[DllImport(Lib.Bcrypt, SetLastError = false, ExactSpelling = true)]
	[PInvokeData("bcrypt.h", MSDNShortId = "a01adfec-dbe0-4817-af97-63163760fafc")]
	public static extern NTStatus BCryptEnumRegisteredProviders(out uint pcbBuffer, out SafeBCryptBuffer ppBuffer);

	/// <summary>The <c>BCryptEnumRegisteredProviders</c> function retrieves information about the registered providers.</summary>
	/// <returns>An array of strings that contains the names of the registered providers.</returns>
	[PInvokeData("bcrypt.h", MSDNShortId = "a01adfec-dbe0-4817-af97-63163760fafc")]
	public static string?[] BCryptEnumRegisteredProviders()
	{
		BCryptEnumRegisteredProviders(out _, out var buf).ThrowIfFailed();
		return buf.ToStructure<CRYPT_PROVIDERS>()._rgpszProviders.ToArray();
	}

	/// <summary>The <c>BCryptExportKey</c> function exports a key to a memory BLOB that can be persisted for later use.</summary>
	/// <param name="hKey">The handle of the key to export.</param>
	/// <param name="hExportKey">
	/// <para>
	/// The handle of the key with which to wrap the exported key. Use this parameter when exporting BLOBs of type
	/// <c>BCRYPT_AES_WRAP_KEY_BLOB</c>; otherwise, set it to <c>NULL</c>.
	/// </para>
	/// <para><c>Windows Server 2008 and Windows Vista:</c> This parameter is not used and should be set to <c>NULL</c>.</para>
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
	/// <term>BCRYPT_AES_WRAP_KEY_BLOB</term>
	/// <term>
	/// Export an AES key wrapped key. The hExportKey parameter must reference a valid BCRYPT_KEY_HANDLE pointer to the key encryption
	/// key, and the key represented by the hKey parameter must be a multiple of 8 bytes long. Windows Server 2008 and Windows Vista:
	/// This BLOB type is not supported.
	/// </term>
	/// </item>
	/// <item>
	/// <term>BCRYPT_DH_PRIVATE_BLOB</term>
	/// <term>
	/// Export a Diffie-Hellman public/private key pair. The pbOutput buffer receives a BCRYPT_DH_KEY_BLOB structure immediately followed
	/// by the key data.
	/// </term>
	/// </item>
	/// <item>
	/// <term>BCRYPT_DH_PUBLIC_BLOB</term>
	/// <term>
	/// Export a Diffie-Hellman public key. The pbOutput buffer receives a BCRYPT_DH_KEY_BLOB structure immediately followed by the key data.
	/// </term>
	/// </item>
	/// <item>
	/// <term>BCRYPT_DSA_PRIVATE_BLOB</term>
	/// <term>
	/// Export a DSA public/private key pair. The pbOutput buffer receives a BCRYPT_DSA_KEY_BLOB or BCRYPT_DSA_KEY_BLOB_V2 structure
	/// immediately followed by the key data. BCRYPT_DSA_KEY_BLOB is used for key lengths from 512 to 1024 bits. BCRYPT_DSA_KEY_BLOB_V2
	/// is used for key lengths that exceed 1024 bits but are less than or equal to 3072 bits. Windows 8: Support for
	/// BCRYPT_DSA_KEY_BLOB_V2 begins.
	/// </term>
	/// </item>
	/// <item>
	/// <term>BCRYPT_DSA_PUBLIC_BLOB</term>
	/// <term>
	/// Export a DSA public key. The pbOutput buffer receives a BCRYPT_DSA_KEY_BLOB or BCRYPT_DSA_KEY_BLOB_V2 structure immediately
	/// followed by the key data. BCRYPT_DSA_KEY_BLOB is used for key lengths from 512 to 1024 bits. BCRYPT_DSA_KEY_BLOB_V2 is used for
	/// key lengths that exceed 1024 bits but are less than or equal to 3072 bits. Windows 8: Support for BCRYPT_DSA_KEY_BLOB_V2 begins.
	/// </term>
	/// </item>
	/// <item>
	/// <term>BCRYPT_ECCPRIVATE_BLOB</term>
	/// <term>
	/// Export an elliptic curve cryptography (ECC) private key. The pbOutput buffer receives a BCRYPT_ECCKEY_BLOB structure immediately
	/// followed by the key data.
	/// </term>
	/// </item>
	/// <item>
	/// <term>BCRYPT_ECCPUBLIC_BLOB</term>
	/// <term>
	/// Export an ECC public key. The pbOutput buffer receives a BCRYPT_ECCKEY_BLOB structure immediately followed by the key data.
	/// </term>
	/// </item>
	/// <item>
	/// <term>BCRYPT_KEY_DATA_BLOB</term>
	/// <term>
	/// Export a symmetric key to a data BLOB. The pbOutput buffer receives a BCRYPT_KEY_DATA_BLOB_HEADER structure immediately followed
	/// by the key BLOB.
	/// </term>
	/// </item>
	/// <item>
	/// <term>BCRYPT_OPAQUE_KEY_BLOB</term>
	/// <term>
	/// Export a symmetric key in a format that is specific to a single cryptographic service provider (CSP). Opaque BLOBs are not
	/// transferable and must be imported by using the same CSP that generated the BLOB. Opaque BLOBs are only intended to be used for
	/// interprocess transfer of keys and are not suitable to be persisted and read across versions of a provider.
	/// </term>
	/// </item>
	/// <item>
	/// <term>BCRYPT_PUBLIC_KEY_BLOB</term>
	/// <term>
	/// Export a generic public key of any type. The type of key in this BLOB is determined by the Magic member of the BCRYPT_KEY_BLOB structure.
	/// </term>
	/// </item>
	/// <item>
	/// <term>BCRYPT_PRIVATE_KEY_BLOB</term>
	/// <term>
	/// Export a generic private key of any type. The private key does not necessarily contain the public key. The type of key in this
	/// BLOB is determined by the Magic member of the BCRYPT_KEY_BLOB structure.
	/// </term>
	/// </item>
	/// <item>
	/// <term>BCRYPT_RSAFULLPRIVATE_BLOB</term>
	/// <term>
	/// Export a full RSA public/private key pair. The pbOutput buffer receives a BCRYPT_RSAKEY_BLOB structure immediately followed by
	/// the key data. This BLOB will include additional key material compared to the BCRYPT_RSAPRIVATE_BLOB type.
	/// </term>
	/// </item>
	/// <item>
	/// <term>BCRYPT_RSAPRIVATE_BLOB</term>
	/// <term>
	/// Export an RSA public/private key pair. The pbOutput buffer receives a BCRYPT_RSAKEY_BLOB structure immediately followed by the
	/// key data.
	/// </term>
	/// </item>
	/// <item>
	/// <term>BCRYPT_RSAPUBLIC_BLOB</term>
	/// <term>
	/// Export an RSA public key. The pbOutput buffer receives a BCRYPT_RSAKEY_BLOB structure immediately followed by the key data.
	/// </term>
	/// </item>
	/// <item>
	/// <term>LEGACY_DH_PRIVATE_BLOB</term>
	/// <term>
	/// Export a legacy Diffie-Hellman Version 3 Private Key BLOB that contains a Diffie-Hellman public/private key pair that can be
	/// imported by using CryptoAPI.
	/// </term>
	/// </item>
	/// <item>
	/// <term>LEGACY_DH_PUBLIC_BLOB</term>
	/// <term>
	/// Export a legacy Diffie-Hellman Version 3 Public Key BLOB that contains a Diffie-Hellman public key that can be imported by using CryptoAPI.
	/// </term>
	/// </item>
	/// <item>
	/// <term>LEGACY_DSA_PRIVATE_BLOB</term>
	/// <term>Export a DSA public/private key pair in a form that can be imported by using CryptoAPI.</term>
	/// </item>
	/// <item>
	/// <term>LEGACY_DSA_PUBLIC_BLOB</term>
	/// <term>Export a DSA public key in a form that can be imported by using CryptoAPI.</term>
	/// </item>
	/// <item>
	/// <term>LEGACY_DSA_V2_PRIVATE_BLOB</term>
	/// <term>Export a DSA version 2 private key in a form that can be imported by using CryptoAPI.</term>
	/// </item>
	/// <item>
	/// <term>LEGACY_RSAPRIVATE_BLOB</term>
	/// <term>Export an RSA public/private key pair in a form that can be imported by using CryptoAPI.</term>
	/// </item>
	/// <item>
	/// <term>LEGACY_RSAPUBLIC_BLOB</term>
	/// <term>Export an RSA public key in a form that can be imported by using CryptoAPI.</term>
	/// </item>
	/// </list>
	/// </param>
	/// <param name="pbOutput">
	/// The address of a buffer that receives the key BLOB. The cbOutput parameter contains the size of this buffer. If this parameter is
	/// <c>NULL</c>, this function will place the required size, in bytes, in the <c>ULONG</c> pointed to by the pcbResult parameter.
	/// </param>
	/// <param name="cbOutput">Contains the size, in bytes, of the pbOutput buffer.</param>
	/// <param name="pcbResult">
	/// A pointer to a <c>ULONG</c> that receives the number of bytes that were copied to the pbOutput buffer. If the pbOutput parameter
	/// is <c>NULL</c>, this function will place the required size, in bytes, in the <c>ULONG</c> pointed to by this parameter.
	/// </param>
	/// <param name="dwFlags">A set of flags that modify the behavior of this function. No flags are defined for this function.</param>
	/// <returns>
	/// <para>Returns a status code that indicates the success or failure of the function.</para>
	/// <para>Possible return codes include, but are not limited to, the following.</para>
	/// <list type="table">
	/// <listheader>
	/// <term>Return code</term>
	/// <term>Description</term>
	/// </listheader>
	/// <item>
	/// <term>STATUS_SUCCESS</term>
	/// <term>The function was successful.</term>
	/// </item>
	/// <item>
	/// <term>STATUS_BUFFER_TOO_SMALL</term>
	/// <term>The size specified by the cbOutput parameter is not large enough to hold the ciphertext.</term>
	/// </item>
	/// <item>
	/// <term>STATUS_INVALID_HANDLE</term>
	/// <term>The key handle in the hKey parameter is not valid.</term>
	/// </item>
	/// <item>
	/// <term>STATUS_INVALID_PARAMETER</term>
	/// <term>One or more parameters are not valid.</term>
	/// </item>
	/// <item>
	/// <term>STATUS_NOT_SUPPORTED</term>
	/// <term>The specified BLOB type is not supported by the provider.</term>
	/// </item>
	/// </list>
	/// </returns>
	/// <remarks>
	/// <para>
	/// Depending on what processor modes a provider supports, <c>BCryptExportKey</c> can be called either from user mode or kernel mode.
	/// Kernel mode callers can execute either at <c>PASSIVE_LEVEL</c> IRQL or <c>DISPATCH_LEVEL</c> IRQL. If the current IRQL level is
	/// <c>DISPATCH_LEVEL</c>, the handle provided in the hKey parameter must be derived from an algorithm handle returned by a provider
	/// that was opened with the <c>BCRYPT_PROV_DISPATCH</c> flag, and any pointers passed to the <c>BCryptExportKey</c> function must
	/// refer to nonpaged (or locked) memory.
	/// </para>
	/// <para>
	/// To call this function in kernel mode, use Cng.lib, which is part of the Driver Development Kit (DDK). For more information, see
	/// WDK and Developer Tools. <c>Windows Server 2008 and Windows Vista:</c> To call this function in kernel mode, use Ksecdd.lib.
	/// </para>
	/// </remarks>
	// https://docs.microsoft.com/en-us/windows/desktop/api/bcrypt/nf-bcrypt-bcryptexportkey NTSTATUS BCryptExportKey( BCRYPT_KEY_HANDLE
	// hKey, BCRYPT_KEY_HANDLE hExportKey, LPCWSTR pszBlobType, PUCHAR pbOutput, ULONG cbOutput, ULONG *pcbResult, ULONG dwFlags );
	[DllImport(Lib.Bcrypt, SetLastError = false, ExactSpelling = true)]
	[PInvokeData("bcrypt.h", MSDNShortId = "a5d73143-c1d6-43b3-a724-7e27c68a5ade")]
	public static extern NTStatus BCryptExportKey(BCRYPT_KEY_HANDLE hKey, BCRYPT_KEY_HANDLE hExportKey, [MarshalAs(UnmanagedType.LPWStr)] string pszBlobType,
		SafeAllocatedMemoryHandle pbOutput, uint cbOutput, out uint pcbResult, uint dwFlags = 0);

	/// <summary>The <c>BCryptExportKey</c> function exports a key to a memory BLOB that can be persisted for later use.</summary>
	/// <param name="hKey">The handle of the key to export.</param>
	/// <param name="hExportKey">
	/// <para>
	/// The handle of the key with which to wrap the exported key. Use this parameter when exporting BLOBs of type
	/// <c>BCRYPT_AES_WRAP_KEY_BLOB</c>; otherwise, set it to <c>NULL</c>.
	/// </para>
	/// <para><c>Windows Server 2008 and Windows Vista:</c> This parameter is not used and should be set to <c>NULL</c>.</para>
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
	/// <term>BCRYPT_AES_WRAP_KEY_BLOB</term>
	/// <term>
	/// Export an AES key wrapped key. The hExportKey parameter must reference a valid BCRYPT_KEY_HANDLE pointer to the key encryption
	/// key, and the key represented by the hKey parameter must be a multiple of 8 bytes long. Windows Server 2008 and Windows Vista:
	/// This BLOB type is not supported.
	/// </term>
	/// </item>
	/// <item>
	/// <term>BCRYPT_DH_PRIVATE_BLOB</term>
	/// <term>
	/// Export a Diffie-Hellman public/private key pair. The pbOutput buffer receives a BCRYPT_DH_KEY_BLOB structure immediately followed
	/// by the key data.
	/// </term>
	/// </item>
	/// <item>
	/// <term>BCRYPT_DH_PUBLIC_BLOB</term>
	/// <term>
	/// Export a Diffie-Hellman public key. The pbOutput buffer receives a BCRYPT_DH_KEY_BLOB structure immediately followed by the key data.
	/// </term>
	/// </item>
	/// <item>
	/// <term>BCRYPT_DSA_PRIVATE_BLOB</term>
	/// <term>
	/// Export a DSA public/private key pair. The pbOutput buffer receives a BCRYPT_DSA_KEY_BLOB or BCRYPT_DSA_KEY_BLOB_V2 structure
	/// immediately followed by the key data. BCRYPT_DSA_KEY_BLOB is used for key lengths from 512 to 1024 bits. BCRYPT_DSA_KEY_BLOB_V2
	/// is used for key lengths that exceed 1024 bits but are less than or equal to 3072 bits. Windows 8: Support for
	/// BCRYPT_DSA_KEY_BLOB_V2 begins.
	/// </term>
	/// </item>
	/// <item>
	/// <term>BCRYPT_DSA_PUBLIC_BLOB</term>
	/// <term>
	/// Export a DSA public key. The pbOutput buffer receives a BCRYPT_DSA_KEY_BLOB or BCRYPT_DSA_KEY_BLOB_V2 structure immediately
	/// followed by the key data. BCRYPT_DSA_KEY_BLOB is used for key lengths from 512 to 1024 bits. BCRYPT_DSA_KEY_BLOB_V2 is used for
	/// key lengths that exceed 1024 bits but are less than or equal to 3072 bits. Windows 8: Support for BCRYPT_DSA_KEY_BLOB_V2 begins.
	/// </term>
	/// </item>
	/// <item>
	/// <term>BCRYPT_ECCPRIVATE_BLOB</term>
	/// <term>
	/// Export an elliptic curve cryptography (ECC) private key. The pbOutput buffer receives a BCRYPT_ECCKEY_BLOB structure immediately
	/// followed by the key data.
	/// </term>
	/// </item>
	/// <item>
	/// <term>BCRYPT_ECCPUBLIC_BLOB</term>
	/// <term>
	/// Export an ECC public key. The pbOutput buffer receives a BCRYPT_ECCKEY_BLOB structure immediately followed by the key data.
	/// </term>
	/// </item>
	/// <item>
	/// <term>BCRYPT_KEY_DATA_BLOB</term>
	/// <term>
	/// Export a symmetric key to a data BLOB. The pbOutput buffer receives a BCRYPT_KEY_DATA_BLOB_HEADER structure immediately followed
	/// by the key BLOB.
	/// </term>
	/// </item>
	/// <item>
	/// <term>BCRYPT_OPAQUE_KEY_BLOB</term>
	/// <term>
	/// Export a symmetric key in a format that is specific to a single cryptographic service provider (CSP). Opaque BLOBs are not
	/// transferable and must be imported by using the same CSP that generated the BLOB. Opaque BLOBs are only intended to be used for
	/// interprocess transfer of keys and are not suitable to be persisted and read across versions of a provider.
	/// </term>
	/// </item>
	/// <item>
	/// <term>BCRYPT_PUBLIC_KEY_BLOB</term>
	/// <term>
	/// Export a generic public key of any type. The type of key in this BLOB is determined by the Magic member of the BCRYPT_KEY_BLOB structure.
	/// </term>
	/// </item>
	/// <item>
	/// <term>BCRYPT_PRIVATE_KEY_BLOB</term>
	/// <term>
	/// Export a generic private key of any type. The private key does not necessarily contain the public key. The type of key in this
	/// BLOB is determined by the Magic member of the BCRYPT_KEY_BLOB structure.
	/// </term>
	/// </item>
	/// <item>
	/// <term>BCRYPT_RSAFULLPRIVATE_BLOB</term>
	/// <term>
	/// Export a full RSA public/private key pair. The pbOutput buffer receives a BCRYPT_RSAKEY_BLOB structure immediately followed by
	/// the key data. This BLOB will include additional key material compared to the BCRYPT_RSAPRIVATE_BLOB type.
	/// </term>
	/// </item>
	/// <item>
	/// <term>BCRYPT_RSAPRIVATE_BLOB</term>
	/// <term>
	/// Export an RSA public/private key pair. The pbOutput buffer receives a BCRYPT_RSAKEY_BLOB structure immediately followed by the
	/// key data.
	/// </term>
	/// </item>
	/// <item>
	/// <term>BCRYPT_RSAPUBLIC_BLOB</term>
	/// <term>
	/// Export an RSA public key. The pbOutput buffer receives a BCRYPT_RSAKEY_BLOB structure immediately followed by the key data.
	/// </term>
	/// </item>
	/// <item>
	/// <term>LEGACY_DH_PRIVATE_BLOB</term>
	/// <term>
	/// Export a legacy Diffie-Hellman Version 3 Private Key BLOB that contains a Diffie-Hellman public/private key pair that can be
	/// imported by using CryptoAPI.
	/// </term>
	/// </item>
	/// <item>
	/// <term>LEGACY_DH_PUBLIC_BLOB</term>
	/// <term>
	/// Export a legacy Diffie-Hellman Version 3 Public Key BLOB that contains a Diffie-Hellman public key that can be imported by using CryptoAPI.
	/// </term>
	/// </item>
	/// <item>
	/// <term>LEGACY_DSA_PRIVATE_BLOB</term>
	/// <term>Export a DSA public/private key pair in a form that can be imported by using CryptoAPI.</term>
	/// </item>
	/// <item>
	/// <term>LEGACY_DSA_PUBLIC_BLOB</term>
	/// <term>Export a DSA public key in a form that can be imported by using CryptoAPI.</term>
	/// </item>
	/// <item>
	/// <term>LEGACY_DSA_V2_PRIVATE_BLOB</term>
	/// <term>Export a DSA version 2 private key in a form that can be imported by using CryptoAPI.</term>
	/// </item>
	/// <item>
	/// <term>LEGACY_RSAPRIVATE_BLOB</term>
	/// <term>Export an RSA public/private key pair in a form that can be imported by using CryptoAPI.</term>
	/// </item>
	/// <item>
	/// <term>LEGACY_RSAPUBLIC_BLOB</term>
	/// <term>Export an RSA public key in a form that can be imported by using CryptoAPI.</term>
	/// </item>
	/// </list>
	/// </param>
	/// <param name="pbOutput">
	/// The address of a buffer that receives the key BLOB. The cbOutput parameter contains the size of this buffer. If this parameter is
	/// <c>NULL</c>, this function will place the required size, in bytes, in the <c>ULONG</c> pointed to by the pcbResult parameter.
	/// </param>
	/// <param name="cbOutput">Contains the size, in bytes, of the pbOutput buffer.</param>
	/// <param name="pcbResult">
	/// A pointer to a <c>ULONG</c> that receives the number of bytes that were copied to the pbOutput buffer. If the pbOutput parameter
	/// is <c>NULL</c>, this function will place the required size, in bytes, in the <c>ULONG</c> pointed to by this parameter.
	/// </param>
	/// <param name="dwFlags">A set of flags that modify the behavior of this function. No flags are defined for this function.</param>
	/// <returns>
	/// <para>Returns a status code that indicates the success or failure of the function.</para>
	/// <para>Possible return codes include, but are not limited to, the following.</para>
	/// <list type="table">
	/// <listheader>
	/// <term>Return code</term>
	/// <term>Description</term>
	/// </listheader>
	/// <item>
	/// <term>STATUS_SUCCESS</term>
	/// <term>The function was successful.</term>
	/// </item>
	/// <item>
	/// <term>STATUS_BUFFER_TOO_SMALL</term>
	/// <term>The size specified by the cbOutput parameter is not large enough to hold the ciphertext.</term>
	/// </item>
	/// <item>
	/// <term>STATUS_INVALID_HANDLE</term>
	/// <term>The key handle in the hKey parameter is not valid.</term>
	/// </item>
	/// <item>
	/// <term>STATUS_INVALID_PARAMETER</term>
	/// <term>One or more parameters are not valid.</term>
	/// </item>
	/// <item>
	/// <term>STATUS_NOT_SUPPORTED</term>
	/// <term>The specified BLOB type is not supported by the provider.</term>
	/// </item>
	/// </list>
	/// </returns>
	/// <remarks>
	/// <para>
	/// Depending on what processor modes a provider supports, <c>BCryptExportKey</c> can be called either from user mode or kernel mode.
	/// Kernel mode callers can execute either at <c>PASSIVE_LEVEL</c> IRQL or <c>DISPATCH_LEVEL</c> IRQL. If the current IRQL level is
	/// <c>DISPATCH_LEVEL</c>, the handle provided in the hKey parameter must be derived from an algorithm handle returned by a provider
	/// that was opened with the <c>BCRYPT_PROV_DISPATCH</c> flag, and any pointers passed to the <c>BCryptExportKey</c> function must
	/// refer to nonpaged (or locked) memory.
	/// </para>
	/// <para>
	/// To call this function in kernel mode, use Cng.lib, which is part of the Driver Development Kit (DDK). For more information, see
	/// WDK and Developer Tools. <c>Windows Server 2008 and Windows Vista:</c> To call this function in kernel mode, use Ksecdd.lib.
	/// </para>
	/// </remarks>
	// https://docs.microsoft.com/en-us/windows/desktop/api/bcrypt/nf-bcrypt-bcryptexportkey NTSTATUS BCryptExportKey( BCRYPT_KEY_HANDLE
	// hKey, BCRYPT_KEY_HANDLE hExportKey, LPCWSTR pszBlobType, PUCHAR pbOutput, ULONG cbOutput, ULONG *pcbResult, ULONG dwFlags );
	[DllImport(Lib.Bcrypt, SetLastError = false, ExactSpelling = true)]
	[PInvokeData("bcrypt.h", MSDNShortId = "a5d73143-c1d6-43b3-a724-7e27c68a5ade")]
	public static extern NTStatus BCryptExportKey(BCRYPT_KEY_HANDLE hKey, BCRYPT_KEY_HANDLE hExportKey, [MarshalAs(UnmanagedType.LPWStr)] string pszBlobType,
		[Optional] IntPtr pbOutput, [Optional] uint cbOutput, out uint pcbResult, uint dwFlags = 0);

	/// <summary>
	/// The <c>BCryptFinalizeKeyPair</c> function completes a public/private key pair. The key cannot be used until this function has
	/// been called. After this function has been called, the BCryptSetProperty function can no longer be used for this key.
	/// </summary>
	/// <param name="hKey">The handle of the key to complete. This handle is obtained by calling the BCryptGenerateKeyPair function.</param>
	/// <param name="dwFlags">
	/// A set of flags that modify the behavior of this function. No flags are currently defined, so this parameter should be zero.
	/// </param>
	/// <returns>
	/// <para>Returns a status code that indicates the success or failure of the function.</para>
	/// <para>Possible return codes include, but are not limited to, the following.</para>
	/// <list type="table">
	/// <listheader>
	/// <term>Return code</term>
	/// <term>Description</term>
	/// </listheader>
	/// <item>
	/// <term>STATUS_SUCCESS</term>
	/// <term>The function was successful.</term>
	/// </item>
	/// <item>
	/// <term>STATUS_INVALID_HANDLE</term>
	/// <term>The key handle in the hKey parameter is not valid.</term>
	/// </item>
	/// <item>
	/// <term>STATUS_INVALID_PARAMETER</term>
	/// <term>One or more parameters are not valid.</term>
	/// </item>
	/// <item>
	/// <term>STATUS_NOT_SUPPORTED</term>
	/// <term>The specified provider does not support asymmetric key encryption.</term>
	/// </item>
	/// </list>
	/// </returns>
	/// <remarks>
	/// <para>
	/// Depending on what processor modes a provider supports, <c>BCryptFinalizeKeyPair</c> can be called either from user mode or kernel
	/// mode. Kernel mode callers can execute either at <c>PASSIVE_LEVEL</c> IRQL or <c>DISPATCH_LEVEL</c> IRQL. If the current IRQL
	/// level is <c>DISPATCH_LEVEL</c>, the handle provided in the hKey parameter must be derived from an algorithm handle returned by a
	/// provider that was opened with the <c>BCRYPT_PROV_DISPATCH</c> flag.
	/// </para>
	/// <para>
	/// To call this function in kernel mode, use Cng.lib, which is part of the Driver Development Kit (DDK). For more information, see
	/// WDK and Developer Tools. <c>Windows Server 2008 and Windows Vista:</c> To call this function in kernel mode, use Ksecdd.lib.
	/// </para>
	/// </remarks>
	// https://docs.microsoft.com/en-us/windows/desktop/api/bcrypt/nf-bcrypt-bcryptfinalizekeypair NTSTATUS BCryptFinalizeKeyPair(
	// BCRYPT_KEY_HANDLE hKey, ULONG dwFlags );
	[DllImport(Lib.Bcrypt, SetLastError = false, ExactSpelling = true)]
	[PInvokeData("bcrypt.h", MSDNShortId = "bf0b90f1-6da8-464e-9271-ad60ea762653")]
	public static extern NTStatus BCryptFinalizeKeyPair(BCRYPT_KEY_HANDLE hKey, uint dwFlags = 0);

	/// <summary>
	/// <para>
	/// The <c>BCryptFinishHash</c> function retrieves the hash or Message Authentication Code (MAC) value for the data accumulated from
	/// prior calls to BCryptHashData.
	/// </para>
	/// </summary>
	/// <param name="hHash">
	/// <para>
	/// The handle of the hash or MAC object to use to compute the hash or MAC. This handle is obtained by calling the BCryptCreateHash
	/// function. After this function has been called, the hash handle passed to this function cannot be used again except in a call to BCryptDestroyHash.
	/// </para>
	/// </param>
	/// <param name="pbOutput">
	/// <para>A pointer to a buffer that receives the hash or MAC value. The cbOutput parameter contains the size of this buffer.</para>
	/// </param>
	/// <param name="cbOutput">
	/// <para>The size, in bytes, of the pbOutput buffer. This size must exactly match the size of the hash or MAC value.</para>
	/// <para>
	/// The size can be obtained by calling the BCryptGetProperty function to get the <c>BCRYPT_HASH_LENGTH</c> property. This will
	/// provide the size of the hash or MAC value for the specified algorithm.
	/// </para>
	/// </param>
	/// <param name="dwFlags">
	/// <para>
	/// A set of flags that modify the behavior of this function. No flags are currently defined, so this parameter should be zero.
	/// </para>
	/// </param>
	/// <returns>
	/// <para>Returns a status code that indicates the success or failure of the function.</para>
	/// <para>Possible return codes include, but are not limited to, the following.</para>
	/// <list type="table">
	/// <listheader>
	/// <term>Return code</term>
	/// <term>Description</term>
	/// </listheader>
	/// <item>
	/// <term>STATUS_SUCCESS</term>
	/// <term>The function was successful.</term>
	/// </item>
	/// <item>
	/// <term>STATUS_INVALID_HANDLE</term>
	/// <term>
	/// The hash handle in the hHash parameter is not valid. After the BCryptFinishHash function has been called for a hash handle, that
	/// handle cannot be reused.
	/// </term>
	/// </item>
	/// <item>
	/// <term>STATUS_INVALID_PARAMETER</term>
	/// <term>One or more parameters are not valid. This includes the case where cbOutput is not the same size as the hash.</term>
	/// </item>
	/// </list>
	/// </returns>
	/// <remarks>
	/// <para>
	/// Depending on what processor modes a provider supports, <c>BCryptFinishHash</c> can be called either from user mode or kernel
	/// mode. Kernel mode callers can execute either at <c>PASSIVE_LEVEL</c> IRQL or <c>DISPATCH_LEVEL</c> IRQL. If the current IRQL
	/// level is <c>DISPATCH_LEVEL</c>, the handle provided in the hHash parameter must be derived from an algorithm handle returned by a
	/// provider that was opened by using the <c>BCRYPT_PROV_DISPATCH</c> flag, and any pointers passed to the <c>BCryptFinishHash</c>
	/// function must refer to nonpaged (or locked) memory.
	/// </para>
	/// <para>
	/// To call this function in kernel mode, use Cng.lib, which is part of the Driver Development Kit (DDK). For more information, see
	/// WDK and Developer Tools. <c>Windows Server 2008 and Windows Vista:</c> To call this function in kernel mode, use Ksecdd.lib.
	/// </para>
	/// </remarks>
	// https://docs.microsoft.com/en-us/windows/desktop/api/bcrypt/nf-bcrypt-bcryptfinishhash NTSTATUS BCryptFinishHash(
	// BCRYPT_HASH_HANDLE hHash, PUCHAR pbOutput, ULONG cbOutput, ULONG dwFlags );
	[DllImport(Lib.Bcrypt, SetLastError = false, ExactSpelling = true)]
	[PInvokeData("bcrypt.h", MSDNShortId = "82a7c3d9-c01b-46d0-8b54-694dc0d8ffdd")]
	public static extern NTStatus BCryptFinishHash(BCRYPT_HASH_HANDLE hHash, SafeAllocatedMemoryHandle pbOutput, uint cbOutput, uint dwFlags = 0);

	/// <summary>
	/// <para>The <c>BCryptFreeBuffer</c> function is used to free memory that was allocated by one of the CNG functions.</para>
	/// </summary>
	/// <param name="pvBuffer">
	/// <para>A pointer to the memory buffer to be freed.</para>
	/// </param>
	/// <returns>
	/// <para>This function does not return a value.</para>
	/// </returns>
	/// <remarks>
	/// <para>
	/// <c>BCryptFreeBuffer</c> must be called in the same processor mode as the BCrypt API function that allocated the buffer. In
	/// addition, if the buffer was allocated at <c>PASSIVE_LEVEL</c> IRQL, it must be freed at that IRQL. If the buffer was allocated at
	/// <c>DISPATCH_LEVEL</c> IRQL, it can be freed at either <c>DISPATCH_LEVEL</c> IRQL or <c>PASSIVE_LEVEL</c> IRQL.
	/// </para>
	/// <para>
	/// To call this function in kernel mode, use Cng.lib, which is part of the Driver Development Kit (DDK). For more information, see
	/// WDK and Developer Tools. <c>Windows Server 2008 and Windows Vista:</c> To call this function in kernel mode, use Ksecdd.lib.
	/// </para>
	/// </remarks>
	// https://docs.microsoft.com/en-us/windows/desktop/api/bcrypt/nf-bcrypt-bcryptfreebuffer void BCryptFreeBuffer( PVOID pvBuffer );
	[DllImport(Lib.Bcrypt, SetLastError = false, ExactSpelling = true)]
	[PInvokeData("bcrypt.h", MSDNShortId = "0ee83ca1-2fe6-4ff2-823e-888b3e66f310")]
	public static extern void BCryptFreeBuffer(IntPtr pvBuffer);

	/// <summary>
	/// The <c>BCryptGenerateKeyPair</c> function creates an empty public/private key pair. After you create a key by using this
	/// function, you can use the BCryptSetProperty function to set its properties; however, the key cannot be used until the
	/// BCryptFinalizeKeyPair function is called.
	/// </summary>
	/// <param name="hAlgorithm">
	/// Handle of an algorithm provider that supports signing, asymmetric encryption, or key agreement. This handle must have been
	/// created by using the BCryptOpenAlgorithmProvider function.
	/// </param>
	/// <param name="phKey">
	/// A pointer to a <c>BCRYPT_KEY_HANDLE</c> that receives the handle of the key. This handle is used in subsequent functions that
	/// require a key, such as BCryptEncrypt. This handle must be released when it is no longer needed by passing it to the
	/// BCryptDestroyKey function.
	/// </param>
	/// <param name="dwLength">
	/// <para>
	/// The length, in bits, of the key. Algorithm providers have different key size restrictions for each standard asymmetric algorithm.
	/// </para>
	/// <list type="table">
	/// <listheader>
	/// <term>Algorithm identifier</term>
	/// <term>Meaning</term>
	/// </listheader>
	/// <item>
	/// <term>BCRYPT_DH_ALGORITHM</term>
	/// <term>The key size must be greater than or equal to 512 bits, less than or equal to 4096 bits, and must be a multiple of 64.</term>
	/// </item>
	/// <item>
	/// <term>BCRYPT_DSA_ALGORITHM</term>
	/// <term>
	/// Prior to Windows 8, the key size must be greater than or equal to 512 bits, less than or equal to 1024 bits, and must be a
	/// multiple of 64. Beginning with Windows 8, the key size must be greater than or equal to 512 bits, less than or equal to 3072
	/// bits, and must be a multiple of 64. Processing for key sizes less than or equal to 1024 bits adheres to FIPS-186-2. Processing
	/// for key sizes greater than 1024 and less than or equal to 3072 adheres to FIPS 186-3.
	/// </term>
	/// </item>
	/// <item>
	/// <term>BCRYPT_ECDH_P256_ALGORITHM</term>
	/// <term>The key size must be 256 bits.</term>
	/// </item>
	/// <item>
	/// <term>BCRYPT_ECDH_P384_ALGORITHM</term>
	/// <term>The key size must be 384 bits.</term>
	/// </item>
	/// <item>
	/// <term>BCRYPT_ECDH_P521_ALGORITHM</term>
	/// <term>The key size must be 521 bits.</term>
	/// </item>
	/// <item>
	/// <term>BCRYPT_ECDSA_P256_ALGORITHM</term>
	/// <term>The key size must be 256 bits.</term>
	/// </item>
	/// <item>
	/// <term>BCRYPT_ECDSA_P384_ALGORITHM</term>
	/// <term>The key size must be 384 bits.</term>
	/// </item>
	/// <item>
	/// <term>BCRYPT_ECDSA_P521_ALGORITHM</term>
	/// <term>The key size must be 521 bits.</term>
	/// </item>
	/// <item>
	/// <term>BCRYPT_RSA_ALGORITHM</term>
	/// <term>The key size must be greater than or equal to 512 bits, less than or equal to 16384 bits, and must be a multiple of 64.</term>
	/// </item>
	/// </list>
	/// </param>
	/// <param name="dwFlags">
	/// A set of flags that modify the behavior of this function. No flags are currently defined, so this parameter should be zero.
	/// </param>
	/// <returns>
	/// <para>Returns a status code that indicates the success or failure of the function.</para>
	/// <para>Possible return codes include, but are not limited to, the following.</para>
	/// <list type="table">
	/// <listheader>
	/// <term>Return code</term>
	/// <term>Description</term>
	/// </listheader>
	/// <item>
	/// <term>STATUS_SUCCESS</term>
	/// <term>The function was successful.</term>
	/// </item>
	/// <item>
	/// <term>STATUS_INVALID_HANDLE</term>
	/// <term>The algorithm handle in the hAlgorithm parameter is not valid.</term>
	/// </item>
	/// <item>
	/// <term>STATUS_INVALID_PARAMETER</term>
	/// <term>One or more parameters are not valid.</term>
	/// </item>
	/// <item>
	/// <term>STATUS_NOT_SUPPORTED</term>
	/// <term>The specified provider does not support asymmetric key encryption.</term>
	/// </item>
	/// </list>
	/// </returns>
	/// <remarks>
	/// <para>
	/// Depending on what processor modes a provider supports, <c>BCryptGenerateKeyPair</c> can be called either from user mode or kernel
	/// mode. Kernel mode callers can execute either at <c>PASSIVE_LEVEL</c> IRQL or <c>DISPATCH_LEVEL</c> IRQL. If the current IRQL
	/// level is <c>DISPATCH_LEVEL</c>, the handle provided in the hAlgorithm parameter must have been opened by using the
	/// <c>BCRYPT_PROV_DISPATCH</c> flag, and any pointers passed to the <c>BCryptGenerateKeyPair</c> function must refer to nonpaged (or
	/// locked) memory.
	/// </para>
	/// <para>
	/// To call this function in kernel mode, use Cng.lib, which is part of the Driver Development Kit (DDK). For more information, see
	/// WDK and Developer Tools. <c>Windows Server 2008 and Windows Vista:</c> To call this function in kernel mode, use Ksecdd.lib.
	/// </para>
	/// </remarks>
	// https://docs.microsoft.com/en-us/windows/desktop/api/bcrypt/nf-bcrypt-bcryptgeneratekeypair NTSTATUS BCryptGenerateKeyPair(
	// BCRYPT_ALG_HANDLE hAlgorithm, BCRYPT_KEY_HANDLE *phKey, ULONG dwLength, ULONG dwFlags );
	[DllImport(Lib.Bcrypt, SetLastError = false, ExactSpelling = true)]
	[PInvokeData("bcrypt.h", MSDNShortId = "cdf0de2e-2445-45e3-91ba-89791a0c0642")]
	public static extern NTStatus BCryptGenerateKeyPair(BCRYPT_ALG_HANDLE hAlgorithm, out SafeBCRYPT_KEY_HANDLE phKey, uint dwLength, uint dwFlags = 0);

	/// <summary>
	/// The <c>BCryptGenerateSymmetricKey</c> function creates a key object for use with a symmetrical key encryption algorithm from a
	/// supplied key.
	/// </summary>
	/// <param name="hAlgorithm">
	/// The handle of an algorithm provider created with the BCryptOpenAlgorithmProvider function. The algorithm specified when the
	/// provider was created must support symmetric key encryption.
	/// </param>
	/// <param name="phKey">
	/// A pointer to a <c>BCRYPT_KEY_HANDLE</c> that receives the handle of the key. This handle is used in subsequent functions that
	/// require a key, such as BCryptEncrypt. This handle must be released when it is no longer needed by passing it to the
	/// BCryptDestroyKey function.
	/// </param>
	/// <param name="pbKeyObject">
	/// <para>
	/// A pointer to a buffer that receives the key object. The cbKeyObject parameter contains the size of this buffer. The required size
	/// of this buffer can be obtained by calling the BCryptGetProperty function to get the <c>BCRYPT_OBJECT_LENGTH</c> property. This
	/// will provide the size of the key object for the specified algorithm.
	/// </para>
	/// <para>This memory can only be freed after the phKey key handle is destroyed.</para>
	/// <para>
	/// If the value of this parameter is <c>NULL</c> and the value of the cbKeyObject parameter is zero, the memory for the key object
	/// is allocated and freed by this function. <c>Windows 7:</c> This memory management functionality is available beginning with
	/// Windows 7.
	/// </para>
	/// </param>
	/// <param name="cbKeyObject">
	/// <para>The size, in bytes, of the pbKeyObject buffer.</para>
	/// <para>
	/// If the value of this parameter is zero and the value of the pbKeyObject parameter is <c>NULL</c>, the memory for the key object
	/// is allocated and freed by this function. <c>Windows 7:</c> This memory management functionality is available beginning with
	/// Windows 7.
	/// </para>
	/// </param>
	/// <param name="pbSecret">
	/// <para>
	/// Pointer to a buffer that contains the key from which to create the key object. The cbSecret parameter contains the size of this
	/// buffer. This is normally a hash of a password or some other reproducible data. If the data passed in exceeds the target key size,
	/// the data will be truncated and the excess will be ignored.
	/// </para>
	/// <para><c>Note</c> We strongly recommended that applications pass in the exact number of bytes required by the target key.</para>
	/// </param>
	/// <param name="cbSecret">The size, in bytes, of the pbSecret buffer.</param>
	/// <param name="dwFlags">
	/// A set of flags that modify the behavior of this function. No flags are currently defined, so this parameter should be zero.
	/// </param>
	/// <returns>
	/// <para>Returns a status code that indicates the success or failure of the function.</para>
	/// <para>Possible return codes include, but are not limited to, the following.</para>
	/// <list type="table">
	/// <listheader>
	/// <term>Return code</term>
	/// <term>Description</term>
	/// </listheader>
	/// <item>
	/// <term>STATUS_SUCCESS</term>
	/// <term>The function was successful.</term>
	/// </item>
	/// <item>
	/// <term>STATUS_BUFFER_TOO_SMALL</term>
	/// <term>The size of the key object specified by the cbKeyObject parameter is not large enough to hold the key object.</term>
	/// </item>
	/// <item>
	/// <term>STATUS_INVALID_HANDLE</term>
	/// <term>The algorithm handle in the hAlgorithm parameter is not valid.</term>
	/// </item>
	/// <item>
	/// <term>STATUS_INVALID_PARAMETER</term>
	/// <term>One or more parameters are not valid.</term>
	/// </item>
	/// </list>
	/// </returns>
	/// <remarks>
	/// <para>
	/// Depending on what processor modes a provider supports, <c>BCryptGenerateSymmetricKey</c> can be called either from user mode or
	/// kernel mode. Kernel mode callers can execute either at <c>PASSIVE_LEVEL</c> IRQL or <c>DISPATCH_LEVEL</c> IRQL. If the current
	/// IRQL level is <c>DISPATCH_LEVEL</c>, the handle provided in the hAlgorithm parameter must have been opened by using the
	/// <c>BCRYPT_PROV_DISPATCH</c> flag, and any pointers passed to the <c>BCryptGenerateSymmetricKey</c> function must refer to
	/// nonpaged (or locked) memory.
	/// </para>
	/// <para>
	/// To call this function in kernel mode, use Cng.lib, which is part of the Driver Development Kit (DDK). For more information, see
	/// WDK and Developer Tools. <c>Windows Server 2008 and Windows Vista:</c> To call this function in kernel mode, use Ksecdd.lib.
	/// </para>
	/// </remarks>
	// https://docs.microsoft.com/en-us/windows/desktop/api/bcrypt/nf-bcrypt-bcryptgeneratesymmetrickey NTSTATUS
	// BCryptGenerateSymmetricKey( BCRYPT_ALG_HANDLE hAlgorithm, BCRYPT_KEY_HANDLE *phKey, PUCHAR pbKeyObject, ULONG cbKeyObject, PUCHAR
	// pbSecret, ULONG cbSecret, ULONG dwFlags );
	[DllImport(Lib.Bcrypt, SetLastError = false, ExactSpelling = true)]
	[PInvokeData("bcrypt.h", MSDNShortId = "c55d714f-f47e-4ddf-97b9-985c0441bb2d")]
	public static extern NTStatus BCryptGenerateSymmetricKey(BCRYPT_ALG_HANDLE hAlgorithm, out SafeBCRYPT_KEY_HANDLE phKey,
		[Optional] SafeAllocatedMemoryHandle pbKeyObject, [Optional] uint cbKeyObject, byte[] pbSecret, uint cbSecret, uint dwFlags = 0);

	/// <summary>
	/// The <c>BCryptGenerateSymmetricKey</c> function creates a key object for use with a symmetrical key encryption algorithm from a
	/// supplied key.
	/// </summary>
	/// <param name="hAlgorithm">
	/// The handle of an algorithm provider created with the BCryptOpenAlgorithmProvider function. The algorithm specified when the
	/// provider was created must support symmetric key encryption.
	/// </param>
	/// <param name="phKey">
	/// A pointer to a <c>BCRYPT_KEY_HANDLE</c> that receives the handle of the key. This handle is used in subsequent functions that
	/// require a key, such as BCryptEncrypt. This handle must be released when it is no longer needed by passing it to the
	/// BCryptDestroyKey function.
	/// </param>
	/// <param name="pbKeyObject">
	/// <para>
	/// A pointer to a buffer that receives the key object. The cbKeyObject parameter contains the size of this buffer. The required size
	/// of this buffer can be obtained by calling the BCryptGetProperty function to get the <c>BCRYPT_OBJECT_LENGTH</c> property. This
	/// will provide the size of the key object for the specified algorithm.
	/// </para>
	/// <para>This memory can only be freed after the phKey key handle is destroyed.</para>
	/// <para>
	/// If the value of this parameter is <c>NULL</c> and the value of the cbKeyObject parameter is zero, the memory for the key object
	/// is allocated and freed by this function. <c>Windows 7:</c> This memory management functionality is available beginning with
	/// Windows 7.
	/// </para>
	/// </param>
	/// <param name="cbKeyObject">
	/// <para>The size, in bytes, of the pbKeyObject buffer.</para>
	/// <para>
	/// If the value of this parameter is zero and the value of the pbKeyObject parameter is <c>NULL</c>, the memory for the key object
	/// is allocated and freed by this function. <c>Windows 7:</c> This memory management functionality is available beginning with
	/// Windows 7.
	/// </para>
	/// </param>
	/// <param name="pbSecret">
	/// <para>
	/// Pointer to a buffer that contains the key from which to create the key object. The cbSecret parameter contains the size of this
	/// buffer. This is normally a hash of a password or some other reproducible data. If the data passed in exceeds the target key size,
	/// the data will be truncated and the excess will be ignored.
	/// </para>
	/// <para><c>Note</c> We strongly recommended that applications pass in the exact number of bytes required by the target key.</para>
	/// </param>
	/// <param name="cbSecret">The size, in bytes, of the pbSecret buffer.</param>
	/// <param name="dwFlags">
	/// A set of flags that modify the behavior of this function. No flags are currently defined, so this parameter should be zero.
	/// </param>
	/// <returns>
	/// <para>Returns a status code that indicates the success or failure of the function.</para>
	/// <para>Possible return codes include, but are not limited to, the following.</para>
	/// <list type="table">
	/// <listheader>
	/// <term>Return code</term>
	/// <term>Description</term>
	/// </listheader>
	/// <item>
	/// <term>STATUS_SUCCESS</term>
	/// <term>The function was successful.</term>
	/// </item>
	/// <item>
	/// <term>STATUS_BUFFER_TOO_SMALL</term>
	/// <term>The size of the key object specified by the cbKeyObject parameter is not large enough to hold the key object.</term>
	/// </item>
	/// <item>
	/// <term>STATUS_INVALID_HANDLE</term>
	/// <term>The algorithm handle in the hAlgorithm parameter is not valid.</term>
	/// </item>
	/// <item>
	/// <term>STATUS_INVALID_PARAMETER</term>
	/// <term>One or more parameters are not valid.</term>
	/// </item>
	/// </list>
	/// </returns>
	/// <remarks>
	/// <para>
	/// Depending on what processor modes a provider supports, <c>BCryptGenerateSymmetricKey</c> can be called either from user mode or
	/// kernel mode. Kernel mode callers can execute either at <c>PASSIVE_LEVEL</c> IRQL or <c>DISPATCH_LEVEL</c> IRQL. If the current
	/// IRQL level is <c>DISPATCH_LEVEL</c>, the handle provided in the hAlgorithm parameter must have been opened by using the
	/// <c>BCRYPT_PROV_DISPATCH</c> flag, and any pointers passed to the <c>BCryptGenerateSymmetricKey</c> function must refer to
	/// nonpaged (or locked) memory.
	/// </para>
	/// <para>
	/// To call this function in kernel mode, use Cng.lib, which is part of the Driver Development Kit (DDK). For more information, see
	/// WDK and Developer Tools. <c>Windows Server 2008 and Windows Vista:</c> To call this function in kernel mode, use Ksecdd.lib.
	/// </para>
	/// </remarks>
	// https://docs.microsoft.com/en-us/windows/desktop/api/bcrypt/nf-bcrypt-bcryptgeneratesymmetrickey NTSTATUS
	// BCryptGenerateSymmetricKey( BCRYPT_ALG_HANDLE hAlgorithm, BCRYPT_KEY_HANDLE *phKey, PUCHAR pbKeyObject, ULONG cbKeyObject, PUCHAR
	// pbSecret, ULONG cbSecret, ULONG dwFlags );
	[DllImport(Lib.Bcrypt, SetLastError = false, ExactSpelling = true)]
	[PInvokeData("bcrypt.h", MSDNShortId = "c55d714f-f47e-4ddf-97b9-985c0441bb2d")]
	public static extern NTStatus BCryptGenerateSymmetricKey(BCRYPT_ALG_HANDLE hAlgorithm, out SafeBCRYPT_KEY_HANDLE phKey, [Optional] IntPtr pbKeyObject,
		[Optional] uint cbKeyObject, byte[] pbSecret, uint cbSecret, uint dwFlags = 0);

	/// <summary>
	/// The <c>BCryptGenerateSymmetricKey</c> function creates a key object for use with a symmetrical key encryption algorithm from a
	/// supplied key.
	/// </summary>
	/// <param name="hAlgorithm">
	/// The handle of an algorithm provider created with the BCryptOpenAlgorithmProvider function. The algorithm specified when the
	/// provider was created must support symmetric key encryption.
	/// </param>
	/// <param name="phKey">
	/// A pointer to a <c>BCRYPT_KEY_HANDLE</c> that receives the handle of the key. This handle is used in subsequent functions that
	/// require a key, such as BCryptEncrypt. This handle must be released when it is no longer needed by passing it to the
	/// BCryptDestroyKey function.
	/// </param>
	/// <param name="pbKeyObject">
	/// <para>
	/// A pointer to a buffer that receives the key object. The cbKeyObject parameter contains the size of this buffer. The required size
	/// of this buffer can be obtained by calling the BCryptGetProperty function to get the <c>BCRYPT_OBJECT_LENGTH</c> property. This
	/// will provide the size of the key object for the specified algorithm.
	/// </para>
	/// <para>This memory can only be freed after the phKey key handle is destroyed.</para>
	/// <para>
	/// If the value of this parameter is <c>NULL</c> and the value of the cbKeyObject parameter is zero, the memory for the key object
	/// is allocated and freed by this function. <c>Windows 7:</c> This memory management functionality is available beginning with
	/// Windows 7.
	/// </para>
	/// </param>
	/// <param name="cbKeyObject">
	/// <para>The size, in bytes, of the pbKeyObject buffer.</para>
	/// <para>
	/// If the value of this parameter is zero and the value of the pbKeyObject parameter is <c>NULL</c>, the memory for the key object
	/// is allocated and freed by this function. <c>Windows 7:</c> This memory management functionality is available beginning with
	/// Windows 7.
	/// </para>
	/// </param>
	/// <param name="pbSecret">
	/// <para>
	/// Pointer to a buffer that contains the key from which to create the key object. The cbSecret parameter contains the size of this
	/// buffer. This is normally a hash of a password or some other reproducible data. If the data passed in exceeds the target key size,
	/// the data will be truncated and the excess will be ignored.
	/// </para>
	/// <para><c>Note</c> We strongly recommended that applications pass in the exact number of bytes required by the target key.</para>
	/// </param>
	/// <param name="cbSecret">The size, in bytes, of the pbSecret buffer.</param>
	/// <param name="dwFlags">
	/// A set of flags that modify the behavior of this function. No flags are currently defined, so this parameter should be zero.
	/// </param>
	/// <returns>
	/// <para>Returns a status code that indicates the success or failure of the function.</para>
	/// <para>Possible return codes include, but are not limited to, the following.</para>
	/// <list type="table">
	/// <listheader>
	/// <term>Return code</term>
	/// <term>Description</term>
	/// </listheader>
	/// <item>
	/// <term>STATUS_SUCCESS</term>
	/// <term>The function was successful.</term>
	/// </item>
	/// <item>
	/// <term>STATUS_BUFFER_TOO_SMALL</term>
	/// <term>The size of the key object specified by the cbKeyObject parameter is not large enough to hold the key object.</term>
	/// </item>
	/// <item>
	/// <term>STATUS_INVALID_HANDLE</term>
	/// <term>The algorithm handle in the hAlgorithm parameter is not valid.</term>
	/// </item>
	/// <item>
	/// <term>STATUS_INVALID_PARAMETER</term>
	/// <term>One or more parameters are not valid.</term>
	/// </item>
	/// </list>
	/// </returns>
	/// <remarks>
	/// <para>
	/// Depending on what processor modes a provider supports, <c>BCryptGenerateSymmetricKey</c> can be called either from user mode or
	/// kernel mode. Kernel mode callers can execute either at <c>PASSIVE_LEVEL</c> IRQL or <c>DISPATCH_LEVEL</c> IRQL. If the current
	/// IRQL level is <c>DISPATCH_LEVEL</c>, the handle provided in the hAlgorithm parameter must have been opened by using the
	/// <c>BCRYPT_PROV_DISPATCH</c> flag, and any pointers passed to the <c>BCryptGenerateSymmetricKey</c> function must refer to
	/// nonpaged (or locked) memory.
	/// </para>
	/// <para>
	/// To call this function in kernel mode, use Cng.lib, which is part of the Driver Development Kit (DDK). For more information, see
	/// WDK and Developer Tools. <c>Windows Server 2008 and Windows Vista:</c> To call this function in kernel mode, use Ksecdd.lib.
	/// </para>
	/// </remarks>
	// https://docs.microsoft.com/en-us/windows/desktop/api/bcrypt/nf-bcrypt-bcryptgeneratesymmetrickey NTSTATUS
	// BCryptGenerateSymmetricKey( BCRYPT_ALG_HANDLE hAlgorithm, BCRYPT_KEY_HANDLE *phKey, PUCHAR pbKeyObject, ULONG cbKeyObject, PUCHAR
	// pbSecret, ULONG cbSecret, ULONG dwFlags );
	[DllImport(Lib.Bcrypt, SetLastError = false, ExactSpelling = true)]
	[PInvokeData("bcrypt.h", MSDNShortId = "c55d714f-f47e-4ddf-97b9-985c0441bb2d")]
	public static extern NTStatus BCryptGenerateSymmetricKey(BCRYPT_ALG_HANDLE hAlgorithm, out SafeBCRYPT_KEY_HANDLE phKey, [Optional] IntPtr pbKeyObject,
		[Optional] uint cbKeyObject, IntPtr pbSecret, uint cbSecret, uint dwFlags = 0);

	/// <summary>The <c>BCryptGenRandom</c> function generates a random number.</summary>
	/// <param name="hAlgorithm">
	/// The handle of an algorithm provider created by using the BCryptOpenAlgorithmProvider function. The algorithm that was specified
	/// when the provider was created must support the random number generator interface.
	/// </param>
	/// <param name="pbBuffer">
	/// The address of a buffer that receives the random number. The size of this buffer is specified by the cbBuffer parameter.
	/// </param>
	/// <param name="cbBuffer">The size, in bytes, of the pbBuffer buffer.</param>
	/// <param name="dwFlags">
	/// <para>A set of flags that modify the behavior of this function. This parameter can be zero or the following value.</para>
	/// <list type="table">
	/// <listheader>
	/// <term>Value</term>
	/// <term>Meaning</term>
	/// </listheader>
	/// <item>
	/// <term>BCRYPT_RNG_USE_ENTROPY_IN_BUFFER 0x00000001</term>
	/// <term>
	/// This function will use the number in the pbBuffer buffer as additional entropy for the random number. If this flag is not
	/// specified, this function will use a random number for the entropy. Windows 8 and later: This flag is ignored in Windows 8 and later.
	/// </term>
	/// </item>
	/// <item>
	/// <term>BCRYPT_USE_SYSTEM_PREFERRED_RNG 0x00000002</term>
	/// <term>
	/// Use the system-preferred random number generator algorithm. The hAlgorithm parameter must be NULL.
	/// BCRYPT_USE_SYSTEM_PREFERRED_RNG is only supported at PASSIVE_LEVEL IRQL. For more information, see Remarks. Windows Vista: This
	/// flag is not supported.
	/// </term>
	/// </item>
	/// </list>
	/// </param>
	/// <returns>
	/// <para>Returns a status code that indicates the success or failure of the function.</para>
	/// <para>Possible return codes include, but are not limited to, the following.</para>
	/// <list type="table">
	/// <listheader>
	/// <term>Return code</term>
	/// <term>Description</term>
	/// </listheader>
	/// <item>
	/// <term>STATUS_SUCCESS</term>
	/// <term>The function was successful.</term>
	/// </item>
	/// <item>
	/// <term>STATUS_INVALID_HANDLE</term>
	/// <term>The handle in the hAlgorithm parameter is not valid.</term>
	/// </item>
	/// <item>
	/// <term>STATUS_INVALID_PARAMETER</term>
	/// <term>One or more parameters are not valid.</term>
	/// </item>
	/// </list>
	/// </returns>
	/// <remarks>
	/// <para>
	/// The default random number provider implements an algorithm for generating random numbers that complies with the NIST SP800-90
	/// standard, specifically the CTR_DRBG portion of that standard.
	/// </para>
	/// <para>
	/// <c>Windows Vista:</c> Prior to Windows Vista with Service Pack 1 (SP1) the default random number provider implements an algorithm
	/// for generating random numbers that complies with the FIPS 186-2 standard.
	/// </para>
	/// <para>
	/// Depending on what processor modes a provider supports, <c>BCryptGenRandom</c> can be called either from user mode or kernel mode.
	/// Kernel mode callers can execute either at <c>PASSIVE_LEVEL</c> IRQL or <c>DISPATCH_LEVEL</c> IRQL. If the current IRQL level is
	/// <c>DISPATCH_LEVEL</c>, the handle provided in the hAlgorithm parameter must have been opened by using the
	/// <c>BCRYPT_PROV_DISPATCH</c> flag, and any pointers passed to the <c>BCryptGenRandom</c> function must refer to nonpaged (or
	/// locked) memory. <c>Windows Vista:</c> The Microsoft provider does not support calling at <c>DISPATCH_LEVEL</c>.
	/// </para>
	/// <para>
	/// To call this function in kernel mode, use Cng.lib, which is part of the Driver Development Kit (DDK). For more information, see
	/// WDK and Developer Tools. <c>Windows Server 2008 and Windows Vista:</c> To call this function in kernel mode, use Ksecdd.lib.
	/// </para>
	/// </remarks>
	// https://docs.microsoft.com/en-us/windows/desktop/api/bcrypt/nf-bcrypt-bcryptgenrandom NTSTATUS BCryptGenRandom( BCRYPT_ALG_HANDLE
	// hAlgorithm, PUCHAR pbBuffer, ULONG cbBuffer, ULONG dwFlags );
	[DllImport(Lib.Bcrypt, SetLastError = false, ExactSpelling = true)]
	[PInvokeData("bcrypt.h", MSDNShortId = "7c6cee3a-f2c5-46f3-8cfe-984316f323d9")]
	public static extern NTStatus BCryptGenRandom(BCRYPT_ALG_HANDLE hAlgorithm, IntPtr pbBuffer, uint cbBuffer, GenRandomFlags dwFlags);

	/// <summary>The <c>BCryptGenRandom</c> function generates a random number.</summary>
	/// <param name="hAlgorithm">
	/// The handle of an algorithm provider created by using the BCryptOpenAlgorithmProvider function. The algorithm that was specified
	/// when the provider was created must support the random number generator interface.
	/// </param>
	/// <param name="pbBuffer">
	/// The address of a buffer that receives the random number. The size of this buffer is specified by the cbBuffer parameter.
	/// </param>
	/// <param name="cbBuffer">The size, in bytes, of the pbBuffer buffer.</param>
	/// <param name="dwFlags">
	/// <para>A set of flags that modify the behavior of this function. This parameter can be zero or the following value.</para>
	/// <list type="table">
	/// <listheader>
	/// <term>Value</term>
	/// <term>Meaning</term>
	/// </listheader>
	/// <item>
	/// <term>BCRYPT_RNG_USE_ENTROPY_IN_BUFFER 0x00000001</term>
	/// <term>
	/// This function will use the number in the pbBuffer buffer as additional entropy for the random number. If this flag is not
	/// specified, this function will use a random number for the entropy. Windows 8 and later: This flag is ignored in Windows 8 and later.
	/// </term>
	/// </item>
	/// <item>
	/// <term>BCRYPT_USE_SYSTEM_PREFERRED_RNG 0x00000002</term>
	/// <term>
	/// Use the system-preferred random number generator algorithm. The hAlgorithm parameter must be NULL.
	/// BCRYPT_USE_SYSTEM_PREFERRED_RNG is only supported at PASSIVE_LEVEL IRQL. For more information, see Remarks. Windows Vista: This
	/// flag is not supported.
	/// </term>
	/// </item>
	/// </list>
	/// </param>
	/// <returns>
	/// <para>Returns a status code that indicates the success or failure of the function.</para>
	/// <para>Possible return codes include, but are not limited to, the following.</para>
	/// <list type="table">
	/// <listheader>
	/// <term>Return code</term>
	/// <term>Description</term>
	/// </listheader>
	/// <item>
	/// <term>STATUS_SUCCESS</term>
	/// <term>The function was successful.</term>
	/// </item>
	/// <item>
	/// <term>STATUS_INVALID_HANDLE</term>
	/// <term>The handle in the hAlgorithm parameter is not valid.</term>
	/// </item>
	/// <item>
	/// <term>STATUS_INVALID_PARAMETER</term>
	/// <term>One or more parameters are not valid.</term>
	/// </item>
	/// </list>
	/// </returns>
	/// <remarks>
	/// <para>
	/// The default random number provider implements an algorithm for generating random numbers that complies with the NIST SP800-90
	/// standard, specifically the CTR_DRBG portion of that standard.
	/// </para>
	/// <para>
	/// <c>Windows Vista:</c> Prior to Windows Vista with Service Pack 1 (SP1) the default random number provider implements an algorithm
	/// for generating random numbers that complies with the FIPS 186-2 standard.
	/// </para>
	/// <para>
	/// Depending on what processor modes a provider supports, <c>BCryptGenRandom</c> can be called either from user mode or kernel mode.
	/// Kernel mode callers can execute either at <c>PASSIVE_LEVEL</c> IRQL or <c>DISPATCH_LEVEL</c> IRQL. If the current IRQL level is
	/// <c>DISPATCH_LEVEL</c>, the handle provided in the hAlgorithm parameter must have been opened by using the
	/// <c>BCRYPT_PROV_DISPATCH</c> flag, and any pointers passed to the <c>BCryptGenRandom</c> function must refer to nonpaged (or
	/// locked) memory. <c>Windows Vista:</c> The Microsoft provider does not support calling at <c>DISPATCH_LEVEL</c>.
	/// </para>
	/// <para>
	/// To call this function in kernel mode, use Cng.lib, which is part of the Driver Development Kit (DDK). For more information, see
	/// WDK and Developer Tools. <c>Windows Server 2008 and Windows Vista:</c> To call this function in kernel mode, use Ksecdd.lib.
	/// </para>
	/// </remarks>
	// https://docs.microsoft.com/en-us/windows/desktop/api/bcrypt/nf-bcrypt-bcryptgenrandom NTSTATUS BCryptGenRandom( BCRYPT_ALG_HANDLE
	// hAlgorithm, PUCHAR pbBuffer, ULONG cbBuffer, ULONG dwFlags );
	[DllImport(Lib.Bcrypt, SetLastError = false, ExactSpelling = true)]
	[PInvokeData("bcrypt.h", MSDNShortId = "7c6cee3a-f2c5-46f3-8cfe-984316f323d9")]
	public static extern NTStatus BCryptGenRandom(BCRYPT_ALG_HANDLE hAlgorithm, SafeAllocatedMemoryHandle pbBuffer, uint cbBuffer, GenRandomFlags dwFlags);

	/// <summary>
	/// <para>
	/// The <c>BCryptGetFipsAlgorithmMode</c> function determines whether Federal Information Processing Standard (FIPS) compliance is enabled.
	/// </para>
	/// </summary>
	/// <param name="pfEnabled">
	/// <para>
	/// The address of a <c>BOOLEAN</c> variable that receives zero if FIPS compliance is not enabled, or a nonzero value if FIPS
	/// compliance is enabled.
	/// </para>
	/// </param>
	/// <returns>
	/// <para>Returns a status code that indicates the success or failure of the function.</para>
	/// <para>Possible return codes include, but are not limited to, the following.</para>
	/// <list type="table">
	/// <listheader>
	/// <term>Return code</term>
	/// <term>Description</term>
	/// </listheader>
	/// <item>
	/// <term>STATUS_SUCCESS</term>
	/// <term>The function was successful.</term>
	/// </item>
	/// <item>
	/// <term>STATUS_INVALID_PARAMETER</term>
	/// <term>The pfEnabled parameter is not valid.</term>
	/// </item>
	/// </list>
	/// </returns>
	/// <remarks>
	/// <para>
	/// <c>BCryptGetFipsAlgorithmMode</c> can be called either from user mode or kernel mode. Kernel mode callers must be executing at
	/// <c>PASSIVE_LEVEL</c> IRQL.
	/// </para>
	/// </remarks>
	// https://docs.microsoft.com/en-us/windows/desktop/api/bcrypt/nf-bcrypt-bcryptgetfipsalgorithmmode NTSTATUS
	// BCryptGetFipsAlgorithmMode( BOOLEAN *pfEnabled );
	[DllImport(Lib.Bcrypt, SetLastError = false, ExactSpelling = true)]
	[PInvokeData("bcrypt.h", MSDNShortId = "eb7b758d-3466-49fe-8729-a8a059fadcde")]
	public static extern NTStatus BCryptGetFipsAlgorithmMode([MarshalAs(UnmanagedType.U1)] out bool pfEnabled);

	/// <summary>The <c>BCryptGetProperty</c> function retrieves the value of a named property for a CNG object.</summary>
	/// <param name="hObject">A handle that represents the CNG object to obtain the property value for.</param>
	/// <param name="pszProperty">
	/// A pointer to a null-terminated Unicode string that contains the name of the property to retrieve. This can be one of the
	/// predefined Cryptography Primitive Property Identifiers or a custom property identifier.
	/// </param>
	/// <param name="pbOutput">
	/// The address of a buffer that receives the property value. The cbOutput parameter contains the size of this buffer.
	/// </param>
	/// <param name="cbOutput">The size, in bytes, of the pbOutput buffer.</param>
	/// <param name="pcbResult">
	/// A pointer to a <c>ULONG</c> variable that receives the number of bytes that were copied to the pbOutput buffer. If the pbOutput
	/// parameter is <c>NULL</c>, this function will place the required size, in bytes, in the location pointed to by this parameter.
	/// </param>
	/// <param name="dwFlags">A set of flags that modify the behavior of this function. No flags are defined for this function.</param>
	/// <returns>
	/// <para>Returns a status code that indicates the success or failure of the function.</para>
	/// <para>Possible return codes include, but are not limited to, the following.</para>
	/// <list type="table">
	/// <listheader>
	/// <term>Return code</term>
	/// <term>Description</term>
	/// </listheader>
	/// <item>
	/// <term>STATUS_SUCCESS</term>
	/// <term>The function was successful.</term>
	/// </item>
	/// <item>
	/// <term>STATUS_BUFFER_TOO_SMALL</term>
	/// <term>The buffer size specified by the cbOutput parameter is not large enough to hold the property value.</term>
	/// </item>
	/// <item>
	/// <term>STATUS_INVALID_HANDLE</term>
	/// <term>The handle in the hObject parameter is not valid.</term>
	/// </item>
	/// <item>
	/// <term>STATUS_INVALID_PARAMETER</term>
	/// <term>One or more parameters are not valid.</term>
	/// </item>
	/// <item>
	/// <term>STATUS_NOT_SUPPORTED</term>
	/// <term>The named property specified by the pszProperty parameter is not supported.</term>
	/// </item>
	/// </list>
	/// </returns>
	/// <remarks>
	/// <para>
	/// To obtain the required size for a property, pass <c>NULL</c> for the pbOutput parameter. This function will place the required
	/// size, in bytes, in the value pointed to by the pcbResult parameter.
	/// </para>
	/// <para>
	/// Depending on what processor modes a provider supports, <c>BCryptGetProperty</c> can be called either from user mode or kernel
	/// mode. Kernel mode callers can execute either at <c>PASSIVE_LEVEL</c> IRQL or <c>DISPATCH_LEVEL</c> IRQL. If the current IRQL
	/// level is <c>DISPATCH_LEVEL</c>, any pointers passed to the <c>BCryptGetProperty</c> function must refer to nonpaged (or locked)
	/// memory. If the object specified in the hObject parameter is a handle, it must have been opened by using the
	/// <c>BCRYPT_PROV_DISPATCH</c> flag.
	/// </para>
	/// <para>
	/// To call this function in kernel mode, use Cng.lib, which is part of the Driver Development Kit (DDK). For more information, see
	/// WDK and Developer Tools. <c>Windows Server 2008 and Windows Vista:</c> To call this function in kernel mode, use Ksecdd.lib.
	/// </para>
	/// </remarks>
	// https://docs.microsoft.com/en-us/windows/desktop/api/bcrypt/nf-bcrypt-bcryptgetproperty NTSTATUS BCryptGetProperty( BCRYPT_HANDLE
	// hObject, LPCWSTR pszProperty, PUCHAR pbOutput, ULONG cbOutput, ULONG *pcbResult, ULONG dwFlags );
	[DllImport(Lib.Bcrypt, SetLastError = false, ExactSpelling = true)]
	[PInvokeData("bcrypt.h", MSDNShortId = "5c62ca3a-843e-41a7-9340-41785fbb15f4")]
	public static extern NTStatus BCryptGetProperty(BCRYPT_HANDLE hObject, [MarshalAs(UnmanagedType.LPWStr)] string pszProperty, SafeAllocatedMemoryHandle pbOutput, uint cbOutput, out uint pcbResult, uint dwFlags = 0);

	/// <summary>The <c>BCryptGetProperty</c> function retrieves the value of a named property for a CNG object.</summary>
	/// <typeparam name="T">The type of the expected return value.</typeparam>
	/// <param name="hObject">A handle that represents the CNG object to obtain the property value for.</param>
	/// <param name="pszProperty">
	/// A pointer to a null-terminated Unicode string that contains the name of the property to retrieve. This can be one of the
	/// predefined Cryptography Primitive Property Identifiers or a custom property identifier.
	/// </param>
	/// <returns>The value of the requested property from <paramref name="pszProperty"/> cast to type <typeparamref name="T"/>.</returns>
	/// <exception cref="System.InvalidCastException">Requested type and system defined sizes do not match.</exception>
	[PInvokeData("bcrypt.h", MSDNShortId = "5c62ca3a-843e-41a7-9340-41785fbb15f4")]
	public static T BCryptGetProperty<T>(BCRYPT_HANDLE hObject, string pszProperty)
	{
		using var mem = SafeCoTaskMemHandle.CreateFromStructure<T>();
		BCryptGetProperty(hObject, pszProperty, mem, (uint)mem.Size, out var sz).ThrowIfFailed();
		if (mem.Size != sz) throw new InvalidCastException("Requested type and system defined sizes do not match.");
		return mem.ToStructure<T>()!;
	}

	/// <summary>
	/// <para>
	/// Performs a single hash computation. This is a convenience function that wraps calls to BCryptCreateHash, BCryptHashData,
	/// BCryptFinishHash, and BCryptDestroyHash.
	/// </para>
	/// </summary>
	/// <param name="hAlgorithm">
	/// <para>
	/// The handle of an algorithm provider created by using the BCryptOpenAlgorithmProvider function. The algorithm that was specified
	/// when the provider was created must support the hash interface.
	/// </para>
	/// </param>
	/// <param name="pbSecret">
	/// <para>
	/// A pointer to a buffer that contains the key to use for the hash or MAC. The cbSecret parameter contains the size of this buffer.
	/// This key only applies to hash algorithms opened by the BCryptOpenAlgorithmProvider function by using the
	/// <c>BCRYPT_ALG_HANDLE_HMAC</c> flag. Otherwise, set this parameter to <c>NULL</c>
	/// </para>
	/// </param>
	/// <param name="cbSecret">
	/// <para>The size, in bytes, of the pbSecret buffer. If no key is used, set this parameter to zero.</para>
	/// </param>
	/// <param name="pbInput">
	/// <para>
	/// A pointer to a buffer that contains the data to process. The cbInput parameter contains the number of bytes in this buffer. This
	/// function does not modify the contents of this buffer.
	/// </para>
	/// </param>
	/// <param name="cbInput">
	/// <para>The number of bytes in the pbInput buffer.</para>
	/// </param>
	/// <param name="pbOutput">
	/// <para>A pointer to a buffer that receives the hash or MAC value. The cbOutput parameter contains the size of this buffer.</para>
	/// </param>
	/// <param name="cbOutput">
	/// <para>The size, in bytes, of the pbOutput buffer. This size must exactly match the size of the hash or MAC value.</para>
	/// <para>
	/// The size can be obtained by calling the BCryptGetProperty function to get the <c>BCRYPT_HASH_LENGTH</c> property. This will
	/// provide the size of the hash or MAC value for the specified algorithm.
	/// </para>
	/// </param>
	/// <returns>
	/// <para>A status code indicating success or failure.</para>
	/// </returns>
	// https://docs.microsoft.com/en-us/windows/desktop/api/bcrypt/nf-bcrypt-bcrypthash NTSTATUS BCryptHash( BCRYPT_ALG_HANDLE
	// hAlgorithm, PUCHAR pbSecret, ULONG cbSecret, PUCHAR pbInput, ULONG cbInput, PUCHAR pbOutput, ULONG cbOutput );
	[DllImport(Lib.Bcrypt, SetLastError = false, ExactSpelling = true)]
	[PInvokeData("bcrypt.h", MSDNShortId = "F0FF9B6D-1345-480A-BE13-BE90547407BF")]
	public static extern NTStatus BCryptHash(BCRYPT_ALG_HANDLE hAlgorithm, [Optional] IntPtr pbSecret, uint cbSecret, IntPtr pbInput, uint cbInput, IntPtr pbOutput, uint cbOutput);

	/// <summary>
	/// <para>
	/// Performs a single hash computation. This is a convenience function that wraps calls to BCryptCreateHash, BCryptHashData,
	/// BCryptFinishHash, and BCryptDestroyHash.
	/// </para>
	/// </summary>
	/// <param name="hAlgorithm">
	/// <para>
	/// The handle of an algorithm provider created by using the BCryptOpenAlgorithmProvider function. The algorithm that was specified
	/// when the provider was created must support the hash interface.
	/// </para>
	/// </param>
	/// <param name="pbSecret">
	/// <para>
	/// A pointer to a buffer that contains the key to use for the hash or MAC. The cbSecret parameter contains the size of this buffer.
	/// This key only applies to hash algorithms opened by the BCryptOpenAlgorithmProvider function by using the
	/// <c>BCRYPT_ALG_HANDLE_HMAC</c> flag. Otherwise, set this parameter to <c>NULL</c>
	/// </para>
	/// </param>
	/// <param name="cbSecret">
	/// <para>The size, in bytes, of the pbSecret buffer. If no key is used, set this parameter to zero.</para>
	/// </param>
	/// <param name="pbInput">
	/// <para>
	/// A pointer to a buffer that contains the data to process. The cbInput parameter contains the number of bytes in this buffer. This
	/// function does not modify the contents of this buffer.
	/// </para>
	/// </param>
	/// <param name="cbInput">
	/// <para>The number of bytes in the pbInput buffer.</para>
	/// </param>
	/// <param name="pbOutput">
	/// <para>A pointer to a buffer that receives the hash or MAC value. The cbOutput parameter contains the size of this buffer.</para>
	/// </param>
	/// <param name="cbOutput">
	/// <para>The size, in bytes, of the pbOutput buffer. This size must exactly match the size of the hash or MAC value.</para>
	/// <para>
	/// The size can be obtained by calling the BCryptGetProperty function to get the <c>BCRYPT_HASH_LENGTH</c> property. This will
	/// provide the size of the hash or MAC value for the specified algorithm.
	/// </para>
	/// </param>
	/// <returns>
	/// <para>A status code indicating success or failure.</para>
	/// </returns>
	// https://docs.microsoft.com/en-us/windows/desktop/api/bcrypt/nf-bcrypt-bcrypthash NTSTATUS BCryptHash( BCRYPT_ALG_HANDLE
	// hAlgorithm, PUCHAR pbSecret, ULONG cbSecret, PUCHAR pbInput, ULONG cbInput, PUCHAR pbOutput, ULONG cbOutput );
	[DllImport(Lib.Bcrypt, SetLastError = false, ExactSpelling = true)]
	[PInvokeData("bcrypt.h", MSDNShortId = "F0FF9B6D-1345-480A-BE13-BE90547407BF")]
	public static extern NTStatus BCryptHash(BCRYPT_ALG_HANDLE hAlgorithm, SafeAllocatedMemoryHandle pbSecret, uint cbSecret, SafeAllocatedMemoryHandle pbInput, uint cbInput, SafeAllocatedMemoryHandle pbOutput, uint cbOutput);

	/// <summary>
	/// <para>The <c>BCryptHashData</c> function performs a one way hash or Message Authentication Code (MAC) on a data buffer.</para>
	/// </summary>
	/// <param name="hHash">
	/// <para>
	/// The handle of the hash or MAC object to use to perform the operation. This handle is obtained by calling the BCryptCreateHash function.
	/// </para>
	/// </param>
	/// <param name="pbInput">
	/// <para>
	/// A pointer to a buffer that contains the data to process. The cbInput parameter contains the number of bytes in this buffer. This
	/// function does not modify the contents of this buffer.
	/// </para>
	/// </param>
	/// <param name="cbInput">
	/// <para>The number of bytes in the pbInput buffer.</para>
	/// </param>
	/// <param name="dwFlags">
	/// <para>
	/// A set of flags that modify the behavior of this function. No flags are currently defined, so this parameter should be zero.
	/// </para>
	/// </param>
	/// <returns>
	/// <para>Returns a status code that indicates the success or failure of the function.</para>
	/// <para>Possible return codes include, but are not limited to, the following.</para>
	/// <list type="table">
	/// <listheader>
	/// <term>Return code</term>
	/// <term>Description</term>
	/// </listheader>
	/// <item>
	/// <term>STATUS_SUCCESS</term>
	/// <term>The function was successful.</term>
	/// </item>
	/// <item>
	/// <term>STATUS_INVALID_PARAMETER</term>
	/// <term>One or more parameters are not valid.</term>
	/// </item>
	/// <item>
	/// <term>STATUS_INVALID_HANDLE</term>
	/// <term>
	/// The hash handle in the hHash parameter is not valid. After the BCryptFinishHash function has been called for a hash handle, that
	/// handle cannot be reused.
	/// </term>
	/// </item>
	/// </list>
	/// </returns>
	/// <remarks>
	/// <para>
	/// To combine more than one buffer into the hash or MAC, you can call this function multiple times, passing a different buffer each
	/// time. To obtain the hash or MAC value, call the BCryptFinishHash function. After the <c>BCryptFinishHash</c> function has been
	/// called for a specified handle, that handle cannot be reused.
	/// </para>
	/// <para>
	/// Depending on what processor modes a provider supports, <c>BCryptHashData</c> can be called either from user mode or kernel mode.
	/// Kernel mode callers can execute either at <c>PASSIVE_LEVEL</c> IRQL or <c>DISPATCH_LEVEL</c> IRQL. If the current IRQL level is
	/// <c>DISPATCH_LEVEL</c>, the handle provided in the hHash parameter must be derived from an algorithm handle returned by a provider
	/// that was opened by using the <c>BCRYPT_PROV_DISPATCH</c> flag, and any pointers passed to the <c>BCryptHashData</c> function must
	/// refer to nonpaged (or locked) memory.
	/// </para>
	/// <para>
	/// To call this function in kernel mode, use Cng.lib, which is part of the Driver Development Kit (DDK). For more information, see
	/// WDK and Developer Tools. <c>Windows Server 2008 and Windows Vista:</c> To call this function in kernel mode, use Ksecdd.lib.
	/// </para>
	/// </remarks>
	// https://docs.microsoft.com/en-us/windows/desktop/api/bcrypt/nf-bcrypt-bcrypthashdata NTSTATUS BCryptHashData( BCRYPT_HASH_HANDLE
	// hHash, PUCHAR pbInput, ULONG cbInput, ULONG dwFlags );
	[DllImport(Lib.Bcrypt, SetLastError = false, ExactSpelling = true)]
	[PInvokeData("bcrypt.h", MSDNShortId = "dab89dff-dc84-4f69-8b6b-de65704b0265")]
	public static extern NTStatus BCryptHashData(BCRYPT_HASH_HANDLE hHash, byte[] pbInput, uint cbInput, uint dwFlags = 0);

	/// <summary>
	/// <para>The <c>BCryptHashData</c> function performs a one way hash or Message Authentication Code (MAC) on a data buffer.</para>
	/// </summary>
	/// <param name="hHash">
	/// <para>
	/// The handle of the hash or MAC object to use to perform the operation. This handle is obtained by calling the BCryptCreateHash function.
	/// </para>
	/// </param>
	/// <param name="pbInput">
	/// <para>
	/// A pointer to a buffer that contains the data to process. The cbInput parameter contains the number of bytes in this buffer. This
	/// function does not modify the contents of this buffer.
	/// </para>
	/// </param>
	/// <param name="cbInput">
	/// <para>The number of bytes in the pbInput buffer.</para>
	/// </param>
	/// <param name="dwFlags">
	/// <para>
	/// A set of flags that modify the behavior of this function. No flags are currently defined, so this parameter should be zero.
	/// </para>
	/// </param>
	/// <returns>
	/// <para>Returns a status code that indicates the success or failure of the function.</para>
	/// <para>Possible return codes include, but are not limited to, the following.</para>
	/// <list type="table">
	/// <listheader>
	/// <term>Return code</term>
	/// <term>Description</term>
	/// </listheader>
	/// <item>
	/// <term>STATUS_SUCCESS</term>
	/// <term>The function was successful.</term>
	/// </item>
	/// <item>
	/// <term>STATUS_INVALID_PARAMETER</term>
	/// <term>One or more parameters are not valid.</term>
	/// </item>
	/// <item>
	/// <term>STATUS_INVALID_HANDLE</term>
	/// <term>
	/// The hash handle in the hHash parameter is not valid. After the BCryptFinishHash function has been called for a hash handle, that
	/// handle cannot be reused.
	/// </term>
	/// </item>
	/// </list>
	/// </returns>
	/// <remarks>
	/// <para>
	/// To combine more than one buffer into the hash or MAC, you can call this function multiple times, passing a different buffer each
	/// time. To obtain the hash or MAC value, call the BCryptFinishHash function. After the <c>BCryptFinishHash</c> function has been
	/// called for a specified handle, that handle cannot be reused.
	/// </para>
	/// <para>
	/// Depending on what processor modes a provider supports, <c>BCryptHashData</c> can be called either from user mode or kernel mode.
	/// Kernel mode callers can execute either at <c>PASSIVE_LEVEL</c> IRQL or <c>DISPATCH_LEVEL</c> IRQL. If the current IRQL level is
	/// <c>DISPATCH_LEVEL</c>, the handle provided in the hHash parameter must be derived from an algorithm handle returned by a provider
	/// that was opened by using the <c>BCRYPT_PROV_DISPATCH</c> flag, and any pointers passed to the <c>BCryptHashData</c> function must
	/// refer to nonpaged (or locked) memory.
	/// </para>
	/// <para>
	/// To call this function in kernel mode, use Cng.lib, which is part of the Driver Development Kit (DDK). For more information, see
	/// WDK and Developer Tools. <c>Windows Server 2008 and Windows Vista:</c> To call this function in kernel mode, use Ksecdd.lib.
	/// </para>
	/// </remarks>
	// https://docs.microsoft.com/en-us/windows/desktop/api/bcrypt/nf-bcrypt-bcrypthashdata NTSTATUS BCryptHashData( BCRYPT_HASH_HANDLE
	// hHash, PUCHAR pbInput, ULONG cbInput, ULONG dwFlags );
	[DllImport(Lib.Bcrypt, SetLastError = false, ExactSpelling = true)]
	[PInvokeData("bcrypt.h", MSDNShortId = "dab89dff-dc84-4f69-8b6b-de65704b0265")]
	public static extern NTStatus BCryptHashData(BCRYPT_HASH_HANDLE hHash, IntPtr pbInput, uint cbInput, uint dwFlags = 0);

	/// <summary>
	/// The <c>BCryptImportKey</c> function imports a symmetric key from a key BLOB. The BCryptImportKeyPair function is used to import a
	/// public/private key pair.
	/// </summary>
	/// <param name="hAlgorithm">
	/// The handle of the algorithm provider to import the key. This handle is obtained by calling the BCryptOpenAlgorithmProvider function.
	/// </param>
	/// <param name="hImportKey">
	/// <para>The handle of the key encryption key needed to unwrap the key BLOB in the pbInput parameter.</para>
	/// <para><c>Windows Server 2008 and Windows Vista:</c> This parameter is not used and should be set to <c>NULL</c>.</para>
	/// </param>
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
	/// <term>BCRYPT_AES_WRAP_KEY_BLOB</term>
	/// <term>
	/// Import a symmetric key from an AES key–wrapped key BLOB. The hImportKey parameter must reference a valid BCRYPT_KEY_HANDLE
	/// pointer to the key encryption key. Windows Server 2008 and Windows Vista: This BLOB type is not supported.
	/// </term>
	/// </item>
	/// <item>
	/// <term>BCRYPT_KEY_DATA_BLOB</term>
	/// <term>
	/// Import a symmetric key from a data BLOB. The pbInput parameter is a pointer to a BCRYPT_KEY_DATA_BLOB_HEADER structure
	/// immediately followed by the key BLOB.
	/// </term>
	/// </item>
	/// <item>
	/// <term>BCRYPT_OPAQUE_KEY_BLOB</term>
	/// <term>
	/// Import a symmetric key BLOB in a format that is specific to a single CSP. Opaque BLOBs are not transferable and must be imported
	/// by using the same CSP that generated the BLOB. Opaque BLOBs are only intended to be used for interprocess transfer of keys and
	/// are not suitable to be persisted and read in across versions of a provider.
	/// </term>
	/// </item>
	/// </list>
	/// </param>
	/// <param name="phKey">
	/// A pointer to a <c>BCRYPT_KEY_HANDLE</c> that receives the handle of the imported key. This handle is used in subsequent functions
	/// that require a key, such as BCryptEncrypt. This handle must be released when it is no longer needed by passing it to the
	/// BCryptDestroyKey function.
	/// </param>
	/// <param name="pbKeyObject">
	/// <para>
	/// A pointer to a buffer that receives the imported key object. The cbKeyObject parameter contains the size of this buffer. The
	/// required size of this buffer can be obtained by calling the BCryptGetProperty function to get the <c>BCRYPT_OBJECT_LENGTH</c>
	/// property. This will provide the size of the key object for the specified algorithm.
	/// </para>
	/// <para>This memory can only be freed after the phKey key handle is destroyed.</para>
	/// </param>
	/// <param name="cbKeyObject">The size, in bytes, of the pbKeyObject buffer.</param>
	/// <param name="pbInput">
	/// The address of a buffer that contains the key BLOB to import. The cbInput parameter contains the size of this buffer. The
	/// pszBlobType parameter specifies the type of key BLOB this buffer contains.
	/// </param>
	/// <param name="cbInput">The size, in bytes, of the pbInput buffer.</param>
	/// <param name="dwFlags">
	/// A set of flags that modify the behavior of this function. No flags are currently defined, so this parameter should be zero.
	/// </param>
	/// <returns>
	/// <para>Returns a status code that indicates the success or failure of the function.</para>
	/// <para>Possible return codes include, but are not limited to, the following.</para>
	/// <list type="table">
	/// <listheader>
	/// <term>Return code</term>
	/// <term>Description</term>
	/// </listheader>
	/// <item>
	/// <term>STATUS_SUCCESS</term>
	/// <term>The function was successful.</term>
	/// </item>
	/// <item>
	/// <term>STATUS_BUFFER_TOO_SMALL</term>
	/// <term>The size of the key object specified by the cbKeyObject parameter is not large enough to hold the key object.</term>
	/// </item>
	/// <item>
	/// <term>STATUS_INVALID_HANDLE</term>
	/// <term>The algorithm handle in the hAlgorithm parameter is not valid.</term>
	/// </item>
	/// <item>
	/// <term>STATUS_INVALID_PARAMETER</term>
	/// <term>One or more parameters are not valid.</term>
	/// </item>
	/// <item>
	/// <term>STATUS_NOT_SUPPORTED</term>
	/// <term>
	/// The algorithm provider specified by the hAlgorithm parameter does not support the BLOB type specified by the pszBlobType parameter.
	/// </term>
	/// </item>
	/// </list>
	/// </returns>
	/// <remarks>
	/// <para>
	/// Depending on what processor modes a provider supports, <c>BCryptImportKey</c> can be called either from user mode or kernel mode.
	/// Kernel mode callers can execute either at <c>PASSIVE_LEVEL</c> IRQL or <c>DISPATCH_LEVEL</c> IRQL. If the current IRQL level is
	/// <c>DISPATCH_LEVEL</c>, the handle provided in the hAlgorithm parameter must have been opened by using the
	/// <c>BCRYPT_PROV_DISPATCH</c> flag, and any pointers passed to the <c>BCryptImportKey</c> function must refer to nonpaged (or
	/// locked) memory.
	/// </para>
	/// <para>
	/// To call this function in kernel mode, use Cng.lib, which is part of the Driver Development Kit (DDK). For more information, see
	/// WDK and Developer Tools. <c>Windows Server 2008 and Windows Vista:</c> To call this function in kernel mode, use Ksecdd.lib.
	/// </para>
	/// </remarks>
	// https://docs.microsoft.com/en-us/windows/desktop/api/bcrypt/nf-bcrypt-bcryptimportkey NTSTATUS BCryptImportKey( BCRYPT_ALG_HANDLE
	// hAlgorithm, BCRYPT_KEY_HANDLE hImportKey, LPCWSTR pszBlobType, BCRYPT_KEY_HANDLE *phKey, PUCHAR pbKeyObject, ULONG cbKeyObject,
	// PUCHAR pbInput, ULONG cbInput, ULONG dwFlags );
	[DllImport(Lib.Bcrypt, SetLastError = false, ExactSpelling = true)]
	[PInvokeData("bcrypt.h", MSDNShortId = "6b9683f4-10f2-40e4-9757-a1f01991bef7")]
	public static extern NTStatus BCryptImportKey(BCRYPT_ALG_HANDLE hAlgorithm, BCRYPT_KEY_HANDLE hImportKey, [MarshalAs(UnmanagedType.LPWStr)] string pszBlobType,
		out SafeBCRYPT_KEY_HANDLE phKey, SafeAllocatedMemoryHandle pbKeyObject, uint cbKeyObject, SafeAllocatedMemoryHandle pbInput, uint cbInput, uint dwFlags = 0);

	/// <summary>
	/// The <c>BCryptImportKey</c> function imports a symmetric key from a key BLOB. The BCryptImportKeyPair function is used to import a
	/// public/private key pair.
	/// </summary>
	/// <param name="hAlgorithm">
	/// The handle of the algorithm provider to import the key. This handle is obtained by calling the BCryptOpenAlgorithmProvider function.
	/// </param>
	/// <param name="hImportKey">
	/// <para>The handle of the key encryption key needed to unwrap the key BLOB in the pbInput parameter.</para>
	/// <para><c>Windows Server 2008 and Windows Vista:</c> This parameter is not used and should be set to <c>NULL</c>.</para>
	/// </param>
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
	/// <term>BCRYPT_AES_WRAP_KEY_BLOB</term>
	/// <term>
	/// Import a symmetric key from an AES key–wrapped key BLOB. The hImportKey parameter must reference a valid BCRYPT_KEY_HANDLE
	/// pointer to the key encryption key. Windows Server 2008 and Windows Vista: This BLOB type is not supported.
	/// </term>
	/// </item>
	/// <item>
	/// <term>BCRYPT_KEY_DATA_BLOB</term>
	/// <term>
	/// Import a symmetric key from a data BLOB. The pbInput parameter is a pointer to a BCRYPT_KEY_DATA_BLOB_HEADER structure
	/// immediately followed by the key BLOB.
	/// </term>
	/// </item>
	/// <item>
	/// <term>BCRYPT_OPAQUE_KEY_BLOB</term>
	/// <term>
	/// Import a symmetric key BLOB in a format that is specific to a single CSP. Opaque BLOBs are not transferable and must be imported
	/// by using the same CSP that generated the BLOB. Opaque BLOBs are only intended to be used for interprocess transfer of keys and
	/// are not suitable to be persisted and read in across versions of a provider.
	/// </term>
	/// </item>
	/// </list>
	/// </param>
	/// <param name="phKey">
	/// A pointer to a <c>BCRYPT_KEY_HANDLE</c> that receives the handle of the imported key. This handle is used in subsequent functions
	/// that require a key, such as BCryptEncrypt. This handle must be released when it is no longer needed by passing it to the
	/// BCryptDestroyKey function.
	/// </param>
	/// <param name="pbKeyObject">
	/// <para>
	/// A pointer to a buffer that receives the imported key object. The cbKeyObject parameter contains the size of this buffer. The
	/// required size of this buffer can be obtained by calling the BCryptGetProperty function to get the <c>BCRYPT_OBJECT_LENGTH</c>
	/// property. This will provide the size of the key object for the specified algorithm.
	/// </para>
	/// <para>This memory can only be freed after the phKey key handle is destroyed.</para>
	/// </param>
	/// <param name="cbKeyObject">The size, in bytes, of the pbKeyObject buffer.</param>
	/// <param name="pbInput">
	/// The address of a buffer that contains the key BLOB to import. The cbInput parameter contains the size of this buffer. The
	/// pszBlobType parameter specifies the type of key BLOB this buffer contains.
	/// </param>
	/// <param name="cbInput">The size, in bytes, of the pbInput buffer.</param>
	/// <param name="dwFlags">
	/// A set of flags that modify the behavior of this function. No flags are currently defined, so this parameter should be zero.
	/// </param>
	/// <returns>
	/// <para>Returns a status code that indicates the success or failure of the function.</para>
	/// <para>Possible return codes include, but are not limited to, the following.</para>
	/// <list type="table">
	/// <listheader>
	/// <term>Return code</term>
	/// <term>Description</term>
	/// </listheader>
	/// <item>
	/// <term>STATUS_SUCCESS</term>
	/// <term>The function was successful.</term>
	/// </item>
	/// <item>
	/// <term>STATUS_BUFFER_TOO_SMALL</term>
	/// <term>The size of the key object specified by the cbKeyObject parameter is not large enough to hold the key object.</term>
	/// </item>
	/// <item>
	/// <term>STATUS_INVALID_HANDLE</term>
	/// <term>The algorithm handle in the hAlgorithm parameter is not valid.</term>
	/// </item>
	/// <item>
	/// <term>STATUS_INVALID_PARAMETER</term>
	/// <term>One or more parameters are not valid.</term>
	/// </item>
	/// <item>
	/// <term>STATUS_NOT_SUPPORTED</term>
	/// <term>
	/// The algorithm provider specified by the hAlgorithm parameter does not support the BLOB type specified by the pszBlobType parameter.
	/// </term>
	/// </item>
	/// </list>
	/// </returns>
	/// <remarks>
	/// <para>
	/// Depending on what processor modes a provider supports, <c>BCryptImportKey</c> can be called either from user mode or kernel mode.
	/// Kernel mode callers can execute either at <c>PASSIVE_LEVEL</c> IRQL or <c>DISPATCH_LEVEL</c> IRQL. If the current IRQL level is
	/// <c>DISPATCH_LEVEL</c>, the handle provided in the hAlgorithm parameter must have been opened by using the
	/// <c>BCRYPT_PROV_DISPATCH</c> flag, and any pointers passed to the <c>BCryptImportKey</c> function must refer to nonpaged (or
	/// locked) memory.
	/// </para>
	/// <para>
	/// To call this function in kernel mode, use Cng.lib, which is part of the Driver Development Kit (DDK). For more information, see
	/// WDK and Developer Tools. <c>Windows Server 2008 and Windows Vista:</c> To call this function in kernel mode, use Ksecdd.lib.
	/// </para>
	/// </remarks>
	// https://docs.microsoft.com/en-us/windows/desktop/api/bcrypt/nf-bcrypt-bcryptimportkey NTSTATUS BCryptImportKey( BCRYPT_ALG_HANDLE
	// hAlgorithm, BCRYPT_KEY_HANDLE hImportKey, LPCWSTR pszBlobType, BCRYPT_KEY_HANDLE *phKey, PUCHAR pbKeyObject, ULONG cbKeyObject,
	// PUCHAR pbInput, ULONG cbInput, ULONG dwFlags );
	[DllImport(Lib.Bcrypt, SetLastError = false, ExactSpelling = true)]
	[PInvokeData("bcrypt.h", MSDNShortId = "6b9683f4-10f2-40e4-9757-a1f01991bef7")]
	public static extern NTStatus BCryptImportKey(BCRYPT_ALG_HANDLE hAlgorithm, BCRYPT_KEY_HANDLE hImportKey, [MarshalAs(UnmanagedType.LPWStr)] string pszBlobType,
		out SafeBCRYPT_KEY_HANDLE phKey, [Optional] IntPtr pbKeyObject, [Optional] uint cbKeyObject, IntPtr pbInput, uint cbInput, uint dwFlags = 0);

	/// <summary>
	/// The <c>BCryptImportKeyPair</c> function imports a public/private key pair from a key BLOB. The BCryptImportKey function is used
	/// to import a symmetric key pair.
	/// </summary>
	/// <param name="hAlgorithm">
	/// The handle of the algorithm provider to import the key. This handle is obtained by calling the BCryptOpenAlgorithmProvider function.
	/// </param>
	/// <param name="hImportKey">This parameter is not currently used and should be <c>NULL</c>.</param>
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
	/// <term>BCRYPT_DH_PRIVATE_BLOB</term>
	/// <term>
	/// The BLOB is a Diffie-Hellman public/private key pair BLOB. The pbInput buffer must contain a BCRYPT_DH_KEY_BLOB structure
	/// immediately followed by the key data.
	/// </term>
	/// </item>
	/// <item>
	/// <term>BCRYPT_DH_PUBLIC_BLOB</term>
	/// <term>
	/// The BLOB is a Diffie-Hellman public key BLOB. The pbInput buffer must contain a BCRYPT_DH_KEY_BLOB structure immediately followed
	/// by the key data.
	/// </term>
	/// </item>
	/// <item>
	/// <term>BCRYPT_DSA_PRIVATE_BLOB</term>
	/// <term>
	/// The BLOB is a DSA public/private key pair BLOB. The pbInput buffer must contain a BCRYPT_DSA_KEY_BLOB or BCRYPT_DSA_KEY_BLOB_V2
	/// structure immediately followed by the key data. BCRYPT_DSA_KEY_BLOB is used for key lengths from 512 to 1024 bits.
	/// BCRYPT_DSA_KEY_BLOB_V2 is used for key lengths that exceed 1024 bits but are less than or equal to 3072 bits. Windows 8: Support
	/// for BCRYPT_DSA_KEY_BLOB_V2 begins.
	/// </term>
	/// </item>
	/// <item>
	/// <term>BCRYPT_DSA_PUBLIC_BLOB</term>
	/// <term>
	/// The BLOB is a DSA public key BLOB. The pbInput buffer must contain a BCRYPT_DSA_KEY_BLOB or BCRYPT_DSA_KEY_BLOB_V2 structure
	/// immediately followed by the key data. BCRYPT_DSA_KEY_BLOB is used for key lengths from 512 to 1024 bits. BCRYPT_DSA_KEY_BLOB_V2
	/// is used for key lengths that exceed 1024 bits but are less than or equal to 3072 bits. Windows 8: Support for
	/// BCRYPT_DSA_KEY_BLOB_V2 begins.
	/// </term>
	/// </item>
	/// <item>
	/// <term>BCRYPT_ECCPRIVATE_BLOB</term>
	/// <term>
	/// The BLOB is an elliptic curve cryptography (ECC) private key. The pbInput buffer must contain a BCRYPT_ECCKEY_BLOB structure
	/// immediately followed by the key data.
	/// </term>
	/// </item>
	/// <item>
	/// <term>BCRYPT_ECCPUBLIC_BLOB</term>
	/// <term>
	/// The BLOB is an ECC public key. The pbInput buffer must contain a BCRYPT_ECCKEY_BLOB structure immediately followed by the key data.
	/// </term>
	/// </item>
	/// <item>
	/// <term>BCRYPT_PUBLIC_KEY_BLOB</term>
	/// <term>
	/// The BLOB is a generic public key of any type. The type of key in this BLOB is determined by the Magic member of the
	/// BCRYPT_KEY_BLOB structure.
	/// </term>
	/// </item>
	/// <item>
	/// <term>BCRYPT_PRIVATE_KEY_BLOB</term>
	/// <term>
	/// The BLOB is a generic private key of any type. The private key does not necessarily contain the public key. The type of key in
	/// this BLOB is determined by the Magic member of the BCRYPT_KEY_BLOB structure.
	/// </term>
	/// </item>
	/// <item>
	/// <term>BCRYPT_RSAPRIVATE_BLOB</term>
	/// <term>
	/// The BLOB is an RSA public/private key pair BLOB. The pbInput buffer must contain a BCRYPT_RSAKEY_BLOB structure immediately
	/// followed by the key data.
	/// </term>
	/// </item>
	/// <item>
	/// <term>BCRYPT_RSAPUBLIC_BLOB</term>
	/// <term>
	/// The BLOB is an RSA public key BLOB. The pbInput buffer must contain a BCRYPT_RSAKEY_BLOB structure immediately followed by the
	/// key data.
	/// </term>
	/// </item>
	/// <item>
	/// <term>LEGACY_DH_PUBLIC_BLOB</term>
	/// <term>
	/// The BLOB is a Diffie-Hellman public key BLOB that was exported by using CryptoAPI. The Microsoft primitive provider does not
	/// support importing this BLOB type.
	/// </term>
	/// </item>
	/// <item>
	/// <term>LEGACY_DH_PRIVATE_BLOB</term>
	/// <term>
	/// The BLOB is a legacy Diffie-Hellman Version 3 Private Key BLOB that contains a Diffie-Hellman public/private key pair that was
	/// exported by using CryptoAPI.
	/// </term>
	/// </item>
	/// <item>
	/// <term>LEGACY_DSA_PRIVATE_BLOB</term>
	/// <term>The BLOB is a DSA public/private key pair BLOB that was exported by using CryptoAPI.</term>
	/// </item>
	/// <item>
	/// <term>LEGACY_DSA_PUBLIC_BLOB</term>
	/// <term>
	/// The BLOB is a DSA public key BLOB that was exported by using CryptoAPI. The Microsoft primitive provider does not support
	/// importing this BLOB type.
	/// </term>
	/// </item>
	/// <item>
	/// <term>LEGACY_DSA_V2_PRIVATE_BLOB</term>
	/// <term>The BLOB is a DSA version 2 private key in a form that can be imported by using CryptoAPI.</term>
	/// </item>
	/// <item>
	/// <term>LEGACY_RSAPRIVATE_BLOB</term>
	/// <term>The BLOB is an RSA public/private key pair BLOB that was exported by using CryptoAPI.</term>
	/// </item>
	/// <item>
	/// <term>LEGACY_RSAPUBLIC_BLOB</term>
	/// <term>
	/// The BLOB is an RSA public key BLOB that was exported by using CryptoAPI. The Microsoft primitive provider does not support
	/// importing this BLOB type.
	/// </term>
	/// </item>
	/// </list>
	/// </param>
	/// <param name="phKey">
	/// A pointer to a <c>BCRYPT_KEY_HANDLE</c> that receives the handle of the imported key. This handle is used in subsequent functions
	/// that require a key, such as BCryptSignHash. This handle must be released when it is no longer needed by passing it to the
	/// BCryptDestroyKey function.
	/// </param>
	/// <param name="pbInput">
	/// The address of a buffer that contains the key BLOB to import. The cbInput parameter contains the size of this buffer. The
	/// pszBlobType parameter specifies the type of key BLOB this buffer contains.
	/// </param>
	/// <param name="cbInput">The size, in bytes, of the pbInput buffer.</param>
	/// <param name="dwFlags">
	/// <para>A set of flags that modify the behavior of this function. This can be zero or the following value.</para>
	/// <list type="table">
	/// <listheader>
	/// <term>Value</term>
	/// <term>Meaning</term>
	/// </listheader>
	/// <item>
	/// <term>BCRYPT_NO_KEY_VALIDATION</term>
	/// <term>Do not validate the public portion of the key pair.</term>
	/// </item>
	/// </list>
	/// </param>
	/// <returns>
	/// <para>Returns a status code that indicates the success or failure of the function.</para>
	/// <para>Possible return codes include, but are not limited to, the following.</para>
	/// <list type="table">
	/// <listheader>
	/// <term>Return code</term>
	/// <term>Description</term>
	/// </listheader>
	/// <item>
	/// <term>STATUS_SUCCESS</term>
	/// <term>The function was successful.</term>
	/// </item>
	/// <item>
	/// <term>STATUS_INVALID_HANDLE</term>
	/// <term>The algorithm handle in the hAlgorithm parameter is not valid.</term>
	/// </item>
	/// <item>
	/// <term>STATUS_INVALID_PARAMETER</term>
	/// <term>One or more parameters are not valid.</term>
	/// </item>
	/// <item>
	/// <term>STATUS_NOT_SUPPORTED</term>
	/// <term>
	/// The algorithm provider specified by the hAlgorithm parameter does not support the BLOB type specified by the pszBlobType parameter.
	/// </term>
	/// </item>
	/// </list>
	/// </returns>
	/// <remarks>
	/// <para>
	/// Depending on what processor modes a provider supports, <c>BCryptImportKeyPair</c> can be called either from user mode or kernel
	/// mode. Kernel mode callers can execute either at <c>PASSIVE_LEVEL</c> IRQL or <c>DISPATCH_LEVEL</c> IRQL. If the current IRQL
	/// level is <c>DISPATCH_LEVEL</c>, the handle provided in the hAlgorithm parameter must have been opened by using the
	/// <c>BCRYPT_PROV_DISPATCH</c> flag, and any pointers passed to the <c>BCryptImportKeyPair</c> function must refer to nonpaged (or
	/// locked) memory.
	/// </para>
	/// <para>
	/// To call this function in kernel mode, use Cng.lib, which is part of the Driver Development Kit (DDK). For more information, see
	/// WDK and Developer Tools. <c>Windows Server 2008 and Windows Vista:</c> To call this function in kernel mode, use Ksecdd.lib.
	/// </para>
	/// </remarks>
	// https://docs.microsoft.com/en-us/windows/desktop/api/bcrypt/nf-bcrypt-bcryptimportkeypair NTSTATUS BCryptImportKeyPair(
	// BCRYPT_ALG_HANDLE hAlgorithm, BCRYPT_KEY_HANDLE hImportKey, LPCWSTR pszBlobType, BCRYPT_KEY_HANDLE *phKey, PUCHAR pbInput, ULONG
	// cbInput, ULONG dwFlags );
	[DllImport(Lib.Bcrypt, SetLastError = false, ExactSpelling = true)]
	[PInvokeData("bcrypt.h", MSDNShortId = "271fc084-6121-4666-b521-b849c7d7966c")]
	public static extern NTStatus BCryptImportKeyPair(BCRYPT_ALG_HANDLE hAlgorithm, [Optional] BCRYPT_KEY_HANDLE hImportKey,
		[MarshalAs(UnmanagedType.LPWStr)] string pszBlobType, out SafeBCRYPT_KEY_HANDLE phKey, [Optional] IntPtr pbInput, [Optional] uint cbInput, ImportFlags dwFlags = 0);

	/// <summary>
	/// The <c>BCryptImportKeyPair</c> function imports a public/private key pair from a key BLOB. The BCryptImportKey function is used
	/// to import a symmetric key pair.
	/// </summary>
	/// <param name="hAlgorithm">
	/// The handle of the algorithm provider to import the key. This handle is obtained by calling the BCryptOpenAlgorithmProvider function.
	/// </param>
	/// <param name="hImportKey">This parameter is not currently used and should be <c>NULL</c>.</param>
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
	/// <term>BCRYPT_DH_PRIVATE_BLOB</term>
	/// <term>
	/// The BLOB is a Diffie-Hellman public/private key pair BLOB. The pbInput buffer must contain a BCRYPT_DH_KEY_BLOB structure
	/// immediately followed by the key data.
	/// </term>
	/// </item>
	/// <item>
	/// <term>BCRYPT_DH_PUBLIC_BLOB</term>
	/// <term>
	/// The BLOB is a Diffie-Hellman public key BLOB. The pbInput buffer must contain a BCRYPT_DH_KEY_BLOB structure immediately followed
	/// by the key data.
	/// </term>
	/// </item>
	/// <item>
	/// <term>BCRYPT_DSA_PRIVATE_BLOB</term>
	/// <term>
	/// The BLOB is a DSA public/private key pair BLOB. The pbInput buffer must contain a BCRYPT_DSA_KEY_BLOB or BCRYPT_DSA_KEY_BLOB_V2
	/// structure immediately followed by the key data. BCRYPT_DSA_KEY_BLOB is used for key lengths from 512 to 1024 bits.
	/// BCRYPT_DSA_KEY_BLOB_V2 is used for key lengths that exceed 1024 bits but are less than or equal to 3072 bits. Windows 8: Support
	/// for BCRYPT_DSA_KEY_BLOB_V2 begins.
	/// </term>
	/// </item>
	/// <item>
	/// <term>BCRYPT_DSA_PUBLIC_BLOB</term>
	/// <term>
	/// The BLOB is a DSA public key BLOB. The pbInput buffer must contain a BCRYPT_DSA_KEY_BLOB or BCRYPT_DSA_KEY_BLOB_V2 structure
	/// immediately followed by the key data. BCRYPT_DSA_KEY_BLOB is used for key lengths from 512 to 1024 bits. BCRYPT_DSA_KEY_BLOB_V2
	/// is used for key lengths that exceed 1024 bits but are less than or equal to 3072 bits. Windows 8: Support for
	/// BCRYPT_DSA_KEY_BLOB_V2 begins.
	/// </term>
	/// </item>
	/// <item>
	/// <term>BCRYPT_ECCPRIVATE_BLOB</term>
	/// <term>
	/// The BLOB is an elliptic curve cryptography (ECC) private key. The pbInput buffer must contain a BCRYPT_ECCKEY_BLOB structure
	/// immediately followed by the key data.
	/// </term>
	/// </item>
	/// <item>
	/// <term>BCRYPT_ECCPUBLIC_BLOB</term>
	/// <term>
	/// The BLOB is an ECC public key. The pbInput buffer must contain a BCRYPT_ECCKEY_BLOB structure immediately followed by the key data.
	/// </term>
	/// </item>
	/// <item>
	/// <term>BCRYPT_PUBLIC_KEY_BLOB</term>
	/// <term>
	/// The BLOB is a generic public key of any type. The type of key in this BLOB is determined by the Magic member of the
	/// BCRYPT_KEY_BLOB structure.
	/// </term>
	/// </item>
	/// <item>
	/// <term>BCRYPT_PRIVATE_KEY_BLOB</term>
	/// <term>
	/// The BLOB is a generic private key of any type. The private key does not necessarily contain the public key. The type of key in
	/// this BLOB is determined by the Magic member of the BCRYPT_KEY_BLOB structure.
	/// </term>
	/// </item>
	/// <item>
	/// <term>BCRYPT_RSAPRIVATE_BLOB</term>
	/// <term>
	/// The BLOB is an RSA public/private key pair BLOB. The pbInput buffer must contain a BCRYPT_RSAKEY_BLOB structure immediately
	/// followed by the key data.
	/// </term>
	/// </item>
	/// <item>
	/// <term>BCRYPT_RSAPUBLIC_BLOB</term>
	/// <term>
	/// The BLOB is an RSA public key BLOB. The pbInput buffer must contain a BCRYPT_RSAKEY_BLOB structure immediately followed by the
	/// key data.
	/// </term>
	/// </item>
	/// <item>
	/// <term>LEGACY_DH_PUBLIC_BLOB</term>
	/// <term>
	/// The BLOB is a Diffie-Hellman public key BLOB that was exported by using CryptoAPI. The Microsoft primitive provider does not
	/// support importing this BLOB type.
	/// </term>
	/// </item>
	/// <item>
	/// <term>LEGACY_DH_PRIVATE_BLOB</term>
	/// <term>
	/// The BLOB is a legacy Diffie-Hellman Version 3 Private Key BLOB that contains a Diffie-Hellman public/private key pair that was
	/// exported by using CryptoAPI.
	/// </term>
	/// </item>
	/// <item>
	/// <term>LEGACY_DSA_PRIVATE_BLOB</term>
	/// <term>The BLOB is a DSA public/private key pair BLOB that was exported by using CryptoAPI.</term>
	/// </item>
	/// <item>
	/// <term>LEGACY_DSA_PUBLIC_BLOB</term>
	/// <term>
	/// The BLOB is a DSA public key BLOB that was exported by using CryptoAPI. The Microsoft primitive provider does not support
	/// importing this BLOB type.
	/// </term>
	/// </item>
	/// <item>
	/// <term>LEGACY_DSA_V2_PRIVATE_BLOB</term>
	/// <term>The BLOB is a DSA version 2 private key in a form that can be imported by using CryptoAPI.</term>
	/// </item>
	/// <item>
	/// <term>LEGACY_RSAPRIVATE_BLOB</term>
	/// <term>The BLOB is an RSA public/private key pair BLOB that was exported by using CryptoAPI.</term>
	/// </item>
	/// <item>
	/// <term>LEGACY_RSAPUBLIC_BLOB</term>
	/// <term>
	/// The BLOB is an RSA public key BLOB that was exported by using CryptoAPI. The Microsoft primitive provider does not support
	/// importing this BLOB type.
	/// </term>
	/// </item>
	/// </list>
	/// </param>
	/// <param name="phKey">
	/// A pointer to a <c>BCRYPT_KEY_HANDLE</c> that receives the handle of the imported key. This handle is used in subsequent functions
	/// that require a key, such as BCryptSignHash. This handle must be released when it is no longer needed by passing it to the
	/// BCryptDestroyKey function.
	/// </param>
	/// <param name="pbInput">
	/// The address of a buffer that contains the key BLOB to import. The cbInput parameter contains the size of this buffer. The
	/// pszBlobType parameter specifies the type of key BLOB this buffer contains.
	/// </param>
	/// <param name="cbInput">The size, in bytes, of the pbInput buffer.</param>
	/// <param name="dwFlags">
	/// <para>A set of flags that modify the behavior of this function. This can be zero or the following value.</para>
	/// <list type="table">
	/// <listheader>
	/// <term>Value</term>
	/// <term>Meaning</term>
	/// </listheader>
	/// <item>
	/// <term>BCRYPT_NO_KEY_VALIDATION</term>
	/// <term>Do not validate the public portion of the key pair.</term>
	/// </item>
	/// </list>
	/// </param>
	/// <returns>
	/// <para>Returns a status code that indicates the success or failure of the function.</para>
	/// <para>Possible return codes include, but are not limited to, the following.</para>
	/// <list type="table">
	/// <listheader>
	/// <term>Return code</term>
	/// <term>Description</term>
	/// </listheader>
	/// <item>
	/// <term>STATUS_SUCCESS</term>
	/// <term>The function was successful.</term>
	/// </item>
	/// <item>
	/// <term>STATUS_INVALID_HANDLE</term>
	/// <term>The algorithm handle in the hAlgorithm parameter is not valid.</term>
	/// </item>
	/// <item>
	/// <term>STATUS_INVALID_PARAMETER</term>
	/// <term>One or more parameters are not valid.</term>
	/// </item>
	/// <item>
	/// <term>STATUS_NOT_SUPPORTED</term>
	/// <term>
	/// The algorithm provider specified by the hAlgorithm parameter does not support the BLOB type specified by the pszBlobType parameter.
	/// </term>
	/// </item>
	/// </list>
	/// </returns>
	/// <remarks>
	/// <para>
	/// Depending on what processor modes a provider supports, <c>BCryptImportKeyPair</c> can be called either from user mode or kernel
	/// mode. Kernel mode callers can execute either at <c>PASSIVE_LEVEL</c> IRQL or <c>DISPATCH_LEVEL</c> IRQL. If the current IRQL
	/// level is <c>DISPATCH_LEVEL</c>, the handle provided in the hAlgorithm parameter must have been opened by using the
	/// <c>BCRYPT_PROV_DISPATCH</c> flag, and any pointers passed to the <c>BCryptImportKeyPair</c> function must refer to nonpaged (or
	/// locked) memory.
	/// </para>
	/// <para>
	/// To call this function in kernel mode, use Cng.lib, which is part of the Driver Development Kit (DDK). For more information, see
	/// WDK and Developer Tools. <c>Windows Server 2008 and Windows Vista:</c> To call this function in kernel mode, use Ksecdd.lib.
	/// </para>
	/// </remarks>
	// https://docs.microsoft.com/en-us/windows/desktop/api/bcrypt/nf-bcrypt-bcryptimportkeypair NTSTATUS BCryptImportKeyPair(
	// BCRYPT_ALG_HANDLE hAlgorithm, BCRYPT_KEY_HANDLE hImportKey, LPCWSTR pszBlobType, BCRYPT_KEY_HANDLE *phKey, PUCHAR pbInput, ULONG
	// cbInput, ULONG dwFlags );
	[DllImport(Lib.Bcrypt, SetLastError = false, ExactSpelling = true)]
	[PInvokeData("bcrypt.h", MSDNShortId = "271fc084-6121-4666-b521-b849c7d7966c")]
	public static extern NTStatus BCryptImportKeyPair(BCRYPT_ALG_HANDLE hAlgorithm, [Optional] BCRYPT_KEY_HANDLE hImportKey,
		[MarshalAs(UnmanagedType.LPWStr)] string pszBlobType, out SafeBCRYPT_KEY_HANDLE phKey, SafeAllocatedMemoryHandle pbInput, uint cbInput, ImportFlags dwFlags = 0);

	/// <summary>
	/// <para>
	/// The <c>BCryptKeyDerivation</c> function derives a key without requiring a secret agreement. It is similar in functionality to
	/// BCryptDeriveKey but does not require a BCRYPT_SECRET_HANDLE value as input.
	/// </para>
	/// </summary>
	/// <param name="hKey">
	/// <para>Handle of the input key.</para>
	/// </param>
	/// <param name="pParameterList">
	/// <para>
	/// Pointer to a <c>BCryptBufferDesc</c> structure that contains the KDF parameters. This parameter is optional and can be
	/// <c>NULL</c> if it is not needed. The parameters can be specific to a key derivation function (KDF) or generic. The following
	/// table shows the required and optional parameters for specific KDFs implemented by the Microsoft Primitive provider.
	/// </para>
	/// <list type="table">
	/// <listheader>
	/// <term>KDF</term>
	/// <term>Parameter</term>
	/// <term>Required</term>
	/// </listheader>
	/// <item>
	/// <term>SP800-108 HMAC in counter mode</term>
	/// <term>KDF_LABEL</term>
	/// <term>yes</term>
	/// </item>
	/// <item>
	/// <term/>
	/// <term>KDF_CONTEXT</term>
	/// <term>yes</term>
	/// </item>
	/// <item>
	/// <term/>
	/// <term>KDF_HASH_ALGORITHM</term>
	/// <term>yes</term>
	/// </item>
	/// <item>
	/// <term>SP800-56A</term>
	/// <term>KDF_ALGORITHMID</term>
	/// <term>yes</term>
	/// </item>
	/// <item>
	/// <term/>
	/// <term>KDF_PARTYUINFO</term>
	/// <term>yes</term>
	/// </item>
	/// <item>
	/// <term/>
	/// <term>KDF_PARTYVINFO</term>
	/// <term>yes</term>
	/// </item>
	/// <item>
	/// <term/>
	/// <term>KDF_HASH_ALGORITHM</term>
	/// <term>yes</term>
	/// </item>
	/// <item>
	/// <term/>
	/// <term>KDF_SUPPPUBINFO</term>
	/// <term>no</term>
	/// </item>
	/// <item>
	/// <term/>
	/// <term>KDF_SUPPPRIVINFO</term>
	/// <term>no</term>
	/// </item>
	/// <item>
	/// <term>PBKDF2</term>
	/// <term>KDF_HASH_ALGORITHM</term>
	/// <term>yes</term>
	/// </item>
	/// <item>
	/// <term/>
	/// <term>KDF_SALT</term>
	/// <term>yes</term>
	/// </item>
	/// <item>
	/// <term/>
	/// <term>KDF_ITERATION_COUNT</term>
	/// <term>no</term>
	/// </item>
	/// <item>
	/// <term>CAPI_KDF</term>
	/// <term>KDF_HASH_ALGORITHM</term>
	/// <term>yes</term>
	/// </item>
	/// </list>
	/// <para>The following generic parameter can be used:</para>
	/// <list type="bullet">
	/// <item>
	/// <term>KDF_GENERIC_PARAMETER</term>
	/// </item>
	/// </list>
	/// <para>Generic parameters map to KDF specific parameters in the following manner:</para>
	/// <para>SP800-108 HMAC in counter mode:</para>
	/// <list type="bullet">
	/// <item>
	/// <term>KDF_GENERIC_PARAMETER = KDF_LABEL||0x00||KDF_CONTEXT</term>
	/// </item>
	/// </list>
	/// <para>SP800-56A</para>
	/// <list type="bullet">
	/// <item>
	/// <term>
	/// KDF_GENERIC_PARAMETER = KDF_ALGORITHMID || KDF_PARTYUINFO || KDF_PARTYVINFO {|| KDF_SUPPPUBINFO } {|| KDF_SUPPPRIVINFO }
	/// </term>
	/// </item>
	/// </list>
	/// <para>PBKDF2</para>
	/// <list type="bullet">
	/// <item>
	/// <term>KDF_GENERIC_PARAMETER = KDF_SALT</term>
	/// </item>
	/// <item>
	/// <term>KDF_ITERATION_COUNT – defaults to 10000</term>
	/// </item>
	/// </list>
	/// <para>CAPI_KDF</para>
	/// <list type="bullet">
	/// <item>
	/// <term>KDF_GENERIC_PARAMETER = Not Used</term>
	/// </item>
	/// </list>
	/// </param>
	/// <param name="pbDerivedKey">
	/// <para>Address of a buffer that receives the key. The cbDerivedKey parameter contains the size of this buffer.</para>
	/// </param>
	/// <param name="cbDerivedKey">
	/// <para>Size, in bytes, of the buffer pointed to by the pbDerivedKey parameter.</para>
	/// </param>
	/// <param name="pcbResult">
	/// <para>
	/// Pointer to a variable that receives the number of bytes that were copied to the buffer pointed to by the pbDerivedKey parameter.
	/// </para>
	/// </param>
	/// <param name="dwFlags">
	/// <para>Flags that modify the behavior of this function. The following value can be used with the Microsoft Primitive provider.</para>
	/// <list type="table">
	/// <listheader>
	/// <term>Value</term>
	/// <term>Meaning</term>
	/// </listheader>
	/// <item>
	/// <term>BCRYPT_CAPI_AES_FLAG</term>
	/// <term>
	/// Specifies that the target algorithm is AES and that the key therefore must be double expanded. This flag is only valid with the
	/// CAPI_KDF algorithm.
	/// </term>
	/// </item>
	/// </list>
	/// </param>
	/// <returns>
	/// <para>Returns a status code that indicates the success or failure of the function.</para>
	/// </returns>
	/// <remarks>
	/// <para>You can use the following algorithm identifiers in the BCryptOpenAlgorithmProvider function before calling <c>BCryptKeyDerivation</c>:</para>
	/// <list type="bullet">
	/// <item>
	/// <term><c>BCRYPT_CAPI_KDF_ALGORITHM</c></term>
	/// </item>
	/// <item>
	/// <term><c>BCRYPT_SP800108_CTR_HMAC_ALGORITHM</c></term>
	/// </item>
	/// <item>
	/// <term><c>BCRYPT_SP80056A_CONCAT_ALGORITHM</c></term>
	/// </item>
	/// <item>
	/// <term><c>BCRYPT_PBKDF2_ALGORITHM</c></term>
	/// </item>
	/// </list>
	/// <para>
	/// To call this function in kernel mode, use Cng.lib, which is part of the Driver Development Kit (DDK). For more information, see
	/// WDK and Developer Tools. <c>Windows Server 2008 and Windows Vista:</c> To call this function in kernel mode, use Ksecdd.lib.
	/// </para>
	/// </remarks>
	// https://docs.microsoft.com/en-us/windows/desktop/api/bcrypt/nf-bcrypt-bcryptkeyderivation NTSTATUS BCryptKeyDerivation(
	// BCRYPT_KEY_HANDLE hKey, BCryptBufferDesc *pParameterList, PUCHAR pbDerivedKey, ULONG cbDerivedKey, ULONG *pcbResult, ULONG dwFlags );
	[DllImport(Lib.Bcrypt, SetLastError = false, ExactSpelling = true)]
	[PInvokeData("bcrypt.h", MSDNShortId = "D0B91FFE-2E72-4AE3-A84F-DC598C02CF53")]
	public static extern NTStatus BCryptKeyDerivation(BCRYPT_KEY_HANDLE hKey, [Optional] NCryptBufferDesc? pParameterList, IntPtr pbDerivedKey,
		uint cbDerivedKey, out uint pcbResult, KeyDerivationFlags dwFlags);

	/// <summary>
	/// <para>
	/// The <c>BCryptKeyDerivation</c> function derives a key without requiring a secret agreement. It is similar in functionality to
	/// BCryptDeriveKey but does not require a BCRYPT_SECRET_HANDLE value as input.
	/// </para>
	/// </summary>
	/// <param name="hKey">
	/// <para>Handle of the input key.</para>
	/// </param>
	/// <param name="pParameterList">
	/// <para>
	/// Pointer to a <c>BCryptBufferDesc</c> structure that contains the KDF parameters. This parameter is optional and can be
	/// <c>NULL</c> if it is not needed. The parameters can be specific to a key derivation function (KDF) or generic. The following
	/// table shows the required and optional parameters for specific KDFs implemented by the Microsoft Primitive provider.
	/// </para>
	/// <list type="table">
	/// <listheader>
	/// <term>KDF</term>
	/// <term>Parameter</term>
	/// <term>Required</term>
	/// </listheader>
	/// <item>
	/// <term>SP800-108 HMAC in counter mode</term>
	/// <term>KDF_LABEL</term>
	/// <term>yes</term>
	/// </item>
	/// <item>
	/// <term/>
	/// <term>KDF_CONTEXT</term>
	/// <term>yes</term>
	/// </item>
	/// <item>
	/// <term/>
	/// <term>KDF_HASH_ALGORITHM</term>
	/// <term>yes</term>
	/// </item>
	/// <item>
	/// <term>SP800-56A</term>
	/// <term>KDF_ALGORITHMID</term>
	/// <term>yes</term>
	/// </item>
	/// <item>
	/// <term/>
	/// <term>KDF_PARTYUINFO</term>
	/// <term>yes</term>
	/// </item>
	/// <item>
	/// <term/>
	/// <term>KDF_PARTYVINFO</term>
	/// <term>yes</term>
	/// </item>
	/// <item>
	/// <term/>
	/// <term>KDF_HASH_ALGORITHM</term>
	/// <term>yes</term>
	/// </item>
	/// <item>
	/// <term/>
	/// <term>KDF_SUPPPUBINFO</term>
	/// <term>no</term>
	/// </item>
	/// <item>
	/// <term/>
	/// <term>KDF_SUPPPRIVINFO</term>
	/// <term>no</term>
	/// </item>
	/// <item>
	/// <term>PBKDF2</term>
	/// <term>KDF_HASH_ALGORITHM</term>
	/// <term>yes</term>
	/// </item>
	/// <item>
	/// <term/>
	/// <term>KDF_SALT</term>
	/// <term>yes</term>
	/// </item>
	/// <item>
	/// <term/>
	/// <term>KDF_ITERATION_COUNT</term>
	/// <term>no</term>
	/// </item>
	/// <item>
	/// <term>CAPI_KDF</term>
	/// <term>KDF_HASH_ALGORITHM</term>
	/// <term>yes</term>
	/// </item>
	/// </list>
	/// <para>The following generic parameter can be used:</para>
	/// <list type="bullet">
	/// <item>
	/// <term>KDF_GENERIC_PARAMETER</term>
	/// </item>
	/// </list>
	/// <para>Generic parameters map to KDF specific parameters in the following manner:</para>
	/// <para>SP800-108 HMAC in counter mode:</para>
	/// <list type="bullet">
	/// <item>
	/// <term>KDF_GENERIC_PARAMETER = KDF_LABEL||0x00||KDF_CONTEXT</term>
	/// </item>
	/// </list>
	/// <para>SP800-56A</para>
	/// <list type="bullet">
	/// <item>
	/// <term>
	/// KDF_GENERIC_PARAMETER = KDF_ALGORITHMID || KDF_PARTYUINFO || KDF_PARTYVINFO {|| KDF_SUPPPUBINFO } {|| KDF_SUPPPRIVINFO }
	/// </term>
	/// </item>
	/// </list>
	/// <para>PBKDF2</para>
	/// <list type="bullet">
	/// <item>
	/// <term>KDF_GENERIC_PARAMETER = KDF_SALT</term>
	/// </item>
	/// <item>
	/// <term>KDF_ITERATION_COUNT – defaults to 10000</term>
	/// </item>
	/// </list>
	/// <para>CAPI_KDF</para>
	/// <list type="bullet">
	/// <item>
	/// <term>KDF_GENERIC_PARAMETER = Not Used</term>
	/// </item>
	/// </list>
	/// </param>
	/// <param name="pbDerivedKey">
	/// <para>Address of a buffer that receives the key. The cbDerivedKey parameter contains the size of this buffer.</para>
	/// </param>
	/// <param name="cbDerivedKey">
	/// <para>Size, in bytes, of the buffer pointed to by the pbDerivedKey parameter.</para>
	/// </param>
	/// <param name="pcbResult">
	/// <para>
	/// Pointer to a variable that receives the number of bytes that were copied to the buffer pointed to by the pbDerivedKey parameter.
	/// </para>
	/// </param>
	/// <param name="dwFlags">
	/// <para>Flags that modify the behavior of this function. The following value can be used with the Microsoft Primitive provider.</para>
	/// <list type="table">
	/// <listheader>
	/// <term>Value</term>
	/// <term>Meaning</term>
	/// </listheader>
	/// <item>
	/// <term>BCRYPT_CAPI_AES_FLAG</term>
	/// <term>
	/// Specifies that the target algorithm is AES and that the key therefore must be double expanded. This flag is only valid with the
	/// CAPI_KDF algorithm.
	/// </term>
	/// </item>
	/// </list>
	/// </param>
	/// <returns>
	/// <para>Returns a status code that indicates the success or failure of the function.</para>
	/// </returns>
	/// <remarks>
	/// <para>You can use the following algorithm identifiers in the BCryptOpenAlgorithmProvider function before calling <c>BCryptKeyDerivation</c>:</para>
	/// <list type="bullet">
	/// <item>
	/// <term><c>BCRYPT_CAPI_KDF_ALGORITHM</c></term>
	/// </item>
	/// <item>
	/// <term><c>BCRYPT_SP800108_CTR_HMAC_ALGORITHM</c></term>
	/// </item>
	/// <item>
	/// <term><c>BCRYPT_SP80056A_CONCAT_ALGORITHM</c></term>
	/// </item>
	/// <item>
	/// <term><c>BCRYPT_PBKDF2_ALGORITHM</c></term>
	/// </item>
	/// </list>
	/// <para>
	/// To call this function in kernel mode, use Cng.lib, which is part of the Driver Development Kit (DDK). For more information, see
	/// WDK and Developer Tools. <c>Windows Server 2008 and Windows Vista:</c> To call this function in kernel mode, use Ksecdd.lib.
	/// </para>
	/// </remarks>
	// https://docs.microsoft.com/en-us/windows/desktop/api/bcrypt/nf-bcrypt-bcryptkeyderivation NTSTATUS BCryptKeyDerivation(
	// BCRYPT_KEY_HANDLE hKey, BCryptBufferDesc *pParameterList, PUCHAR pbDerivedKey, ULONG cbDerivedKey, ULONG *pcbResult, ULONG dwFlags );
	[DllImport(Lib.Bcrypt, SetLastError = false, ExactSpelling = true)]
	[PInvokeData("bcrypt.h", MSDNShortId = "D0B91FFE-2E72-4AE3-A84F-DC598C02CF53")]
	public static extern NTStatus BCryptKeyDerivation(BCRYPT_KEY_HANDLE hKey, [Optional] NCryptBufferDesc? pParameterList,
		SafeAllocatedMemoryHandle pbDerivedKey, uint cbDerivedKey, out uint pcbResult, KeyDerivationFlags dwFlags);

	/// <summary>
	/// <para>The <c>BCryptOpenAlgorithmProvider</c> function loads and initializes a CNG provider.</para>
	/// </summary>
	/// <param name="phAlgorithm">
	/// <para>
	/// A pointer to a <c>BCRYPT_ALG_HANDLE</c> variable that receives the CNG provider handle. When you have finished using this handle,
	/// release it by passing it to the BCryptCloseAlgorithmProvider function.
	/// </para>
	/// </param>
	/// <param name="pszAlgId">
	/// <para>
	/// A pointer to a null-terminated Unicode string that identifies the requested cryptographic algorithm. This can be one of the
	/// standard CNG Algorithm Identifiers or the identifier for another registered algorithm.
	/// </para>
	/// </param>
	/// <param name="pszImplementation">
	/// <para>
	/// A pointer to a null-terminated Unicode string that identifies the specific provider to load. This is the registered alias of the
	/// cryptographic primitive provider. This parameter is optional and can be <c>NULL</c> if it is not needed. If this parameter is
	/// <c>NULL</c>, the default provider for the specified algorithm will be loaded.
	/// </para>
	/// <para>
	/// <c>Note</c> If the pszImplementation parameter value is <c>NULL</c>, CNG attempts to open each registered provider, in order of
	/// priority, for the algorithm specified by the pszAlgId parameter and returns the handle of the first provider that is successfully
	/// opened. For the lifetime of the handle, any BCrypt*** cryptographic APIs will use the provider that was successfully opened.
	/// </para>
	/// <para>Windows Server 2008 and Windows Vista:</para>
	/// <para>CNG attempts to fall back to the Microsoft CNG provider.</para>
	/// <para>The following are the predefined provider names.</para>
	/// <list type="table">
	/// <listheader>
	/// <term>Value</term>
	/// <term>Meaning</term>
	/// </listheader>
	/// <item>
	/// <term>MS_PRIMITIVE_PROVIDER "Microsoft Primitive Provider"</term>
	/// <term>Identifies the basic Microsoft CNG provider.</term>
	/// </item>
	/// </list>
	/// </param>
	/// <param name="dwFlags">
	/// <para>Flags that modify the behavior of the function. This can be zero or a combination of one or more of the following values.</para>
	/// <list type="table">
	/// <listheader>
	/// <term>Value</term>
	/// <term>Meaning</term>
	/// </listheader>
	/// <item>
	/// <term>BCRYPT_ALG_HANDLE_HMAC_FLAG</term>
	/// <term>
	/// The provider will perform the Hash-Based Message Authentication Code (HMAC) algorithm with the specified hash algorithm. This
	/// flag is only used by hash algorithm providers.
	/// </term>
	/// </item>
	/// <item>
	/// <term>BCRYPT_PROV_DISPATCH</term>
	/// <term>
	/// Loads the provider into the nonpaged memory pool. If this flag is not present, the provider is loaded into the paged memory pool.
	/// When this flag is specified, the handle returned must not be closed before all dependent objects have been freed. Windows Server
	/// 2008 and Windows Vista: This flag is only supported by the Microsoft algorithm providers and only for hashing algorithms and
	/// symmetric key cryptographic algorithms.
	/// </term>
	/// </item>
	/// <item>
	/// <term>BCRYPT_HASH_REUSABLE_FLAG</term>
	/// <term>
	/// Creates a reusable hashing object. The object can be used for a new hashing operation immediately after calling BCryptFinishHash.
	/// For more information, see Creating a Hash with CNG. Windows Server 2008 R2, Windows 7, Windows Server 2008 and Windows Vista:
	/// This flag is not supported.
	/// </term>
	/// </item>
	/// </list>
	/// </param>
	/// <returns>
	/// <para>Returns a status code that indicates the success or failure of the function.</para>
	/// <para>Possible return codes include, but are not limited to, the following.</para>
	/// <list type="table">
	/// <listheader>
	/// <term>Return code</term>
	/// <term>Description</term>
	/// </listheader>
	/// <item>
	/// <term>STATUS_SUCCESS</term>
	/// <term>The function was successful.</term>
	/// </item>
	/// <item>
	/// <term>STATUS_NOT_FOUND</term>
	/// <term>No provider was found for the specified algorithm ID.</term>
	/// </item>
	/// <item>
	/// <term>STATUS_INVALID_PARAMETER</term>
	/// <term>One or more parameters are not valid.</term>
	/// </item>
	/// <item>
	/// <term>STATUS_NO_MEMORY</term>
	/// <term>A memory allocation failure occurred.</term>
	/// </item>
	/// </list>
	/// </returns>
	/// <remarks>
	/// <para>
	/// Because of the number and type of operations that are required to find, load, and initialize an algorithm provider, the
	/// <c>BCryptOpenAlgorithmProvider</c> function is a relatively time intensive function. Because of this, we recommend that you cache
	/// any algorithm provider handles that you will use more than once, rather than opening and closing the algorithm providers over and over.
	/// </para>
	/// <para>
	/// <c>BCryptOpenAlgorithmProvider</c> can be called either from user mode or kernel mode. Kernel mode callers must be executing at
	/// <c>PASSIVE_LEVEL</c> IRQL.
	/// </para>
	/// <para>
	/// To call this function in kernel mode, use Cng.lib, which is part of the Driver Development Kit (DDK). For more information, see
	/// WDK and Developer Tools. <c>Windows Server 2008 and Windows Vista:</c> To call this function in kernel mode, use Ksecdd.lib.
	/// </para>
	/// <para>
	/// Starting in Windows 10, CNG no longer follows every update to the cryptography configuration. Certain changes, like adding a new
	/// default provider or changing the preference order of algorithm providers, may require a reboot. Because of this, you should
	/// reboot before calling <c>BCryptOpenAlgorithmProvider</c> with any newly configured provider.
	/// </para>
	/// </remarks>
	// https://docs.microsoft.com/en-us/windows/desktop/api/bcrypt/nf-bcrypt-bcryptopenalgorithmprovider NTSTATUS
	// BCryptOpenAlgorithmProvider( BCRYPT_ALG_HANDLE *phAlgorithm, LPCWSTR pszAlgId, LPCWSTR pszImplementation, ULONG dwFlags );
	[DllImport(Lib.Bcrypt, SetLastError = false, ExactSpelling = true, CharSet = CharSet.Unicode)]
	[PInvokeData("bcrypt.h", MSDNShortId = "aceba9c0-19e6-4f3c-972a-752feed4a9f8")]
	public static extern NTStatus BCryptOpenAlgorithmProvider(out SafeBCRYPT_ALG_HANDLE phAlgorithm, string pszAlgId, [Optional] string? pszImplementation, AlgProviderFlags dwFlags = 0);

	/// <summary>
	/// <para>The <c>BCryptProcessMultiOperations</c> function processes a sequence of operations on a multi-object state.</para>
	/// </summary>
	/// <param name="hObject">
	/// <para>A handle to a multi-object state, such as one created by the BCryptCreateMultiHash function.</para>
	/// </param>
	/// <param name="operationType">
	/// <para>
	/// A <c>BCRYPT_OPERATION_TYPE_*</c> value. Currently the only defined value is <c>BCRYPT_OPERATION_TYPE_HASH</c>. This value
	/// identifies the hObject parameter as a multi-hash object and the pOperations pointer as pointing to an array of
	/// BCRYPT_MULTI_HASH_OPERATION elements.
	/// </para>
	/// </param>
	/// <param name="pOperations">
	/// <para>
	/// A pointer to an array of operation command structures. For hashing, it is a pointer to an array of BCRYPT_MULTI_HASH_OPERATION structures.
	/// </para>
	/// </param>
	/// <param name="cbOperations">
	/// <para>The size, in bytes, of the pOperations array.</para>
	/// </param>
	/// <param name="dwFlags">
	/// <para>Specify a value of zero (0).</para>
	/// </param>
	/// <returns>
	/// <para>None</para>
	/// </returns>
	/// <remarks>
	/// <para>
	/// Each element of the pOperations array contains instructions for a particular computation to be performed on a single element of
	/// the multi-object state. The functional behavior of <c>BCryptProcessMultiOperations</c> is equivalent to performing, for each
	/// element in the multi-object state, the computations specified in the operations array for that element, one at a time, in order.
	/// </para>
	/// <para>
	/// The relative order of two operations that operate on different elements of the array is not guaranteed. If an output buffer
	/// overlaps an input or output buffer the result is not deterministic.
	/// </para>
	/// </remarks>
	// https://docs.microsoft.com/en-us/windows/desktop/api/bcrypt/nf-bcrypt-bcryptprocessmultioperations NTSTATUS
	// BCryptProcessMultiOperations( BCRYPT_HANDLE hObject, BCRYPT_MULTI_OPERATION_TYPE operationType, PVOID pOperations, ULONG
	// cbOperations, ULONG dwFlags );
	[DllImport(Lib.Bcrypt, SetLastError = false, ExactSpelling = true)]
	[PInvokeData("bcrypt.h", MSDNShortId = "5FD28AC3-46D2-4F06-BF06-F5FEF8E531F5")]
	public static extern NTStatus BCryptProcessMultiOperations(BCRYPT_HANDLE hObject, BCRYPT_MULTI_OPERATION_TYPE operationType, IntPtr pOperations, uint cbOperations, uint dwFlags = 0);

	/// <summary>
	/// <para>The <c>BCryptProcessMultiOperations</c> function processes a sequence of operations on a multi-object state.</para>
	/// </summary>
	/// <param name="hObject">
	/// <para>A handle to a multi-object state, such as one created by the BCryptCreateMultiHash function.</para>
	/// </param>
	/// <param name="operationType">
	/// <para>
	/// A <c>BCRYPT_OPERATION_TYPE_*</c> value. Currently the only defined value is <c>BCRYPT_OPERATION_TYPE_HASH</c>. This value
	/// identifies the hObject parameter as a multi-hash object and the pOperations pointer as pointing to an array of
	/// BCRYPT_MULTI_HASH_OPERATION elements.
	/// </para>
	/// </param>
	/// <param name="pOperations">
	/// <para>
	/// A pointer to an array of operation command structures. For hashing, it is a pointer to an array of BCRYPT_MULTI_HASH_OPERATION structures.
	/// </para>
	/// </param>
	/// <param name="cbOperations">
	/// <para>The size, in bytes, of the pOperations array.</para>
	/// </param>
	/// <param name="dwFlags">
	/// <para>Specify a value of zero (0).</para>
	/// </param>
	/// <returns>
	/// <para>None</para>
	/// </returns>
	/// <remarks>
	/// <para>
	/// Each element of the pOperations array contains instructions for a particular computation to be performed on a single element of
	/// the multi-object state. The functional behavior of <c>BCryptProcessMultiOperations</c> is equivalent to performing, for each
	/// element in the multi-object state, the computations specified in the operations array for that element, one at a time, in order.
	/// </para>
	/// <para>
	/// The relative order of two operations that operate on different elements of the array is not guaranteed. If an output buffer
	/// overlaps an input or output buffer the result is not deterministic.
	/// </para>
	/// </remarks>
	// https://docs.microsoft.com/en-us/windows/desktop/api/bcrypt/nf-bcrypt-bcryptprocessmultioperations NTSTATUS
	// BCryptProcessMultiOperations( BCRYPT_HANDLE hObject, BCRYPT_MULTI_OPERATION_TYPE operationType, PVOID pOperations, ULONG
	// cbOperations, ULONG dwFlags );
	[DllImport(Lib.Bcrypt, SetLastError = false, ExactSpelling = true)]
	[PInvokeData("bcrypt.h", MSDNShortId = "5FD28AC3-46D2-4F06-BF06-F5FEF8E531F5")]
	public static extern NTStatus BCryptProcessMultiOperations(BCRYPT_HANDLE hObject, BCRYPT_MULTI_OPERATION_TYPE operationType, [In] BCRYPT_MULTI_HASH_OPERATION[] pOperations, uint cbOperations, uint dwFlags = 0);

	/// <summary>
	/// <para>
	/// [ <c>BCryptQueryContextConfiguration</c> is available for use in the operating systems specified in the Requirements section. It
	/// may be altered or unavailable in subsequent versions.]
	/// </para>
	/// <para>The <c>BCryptQueryContextConfiguration</c> function retrieves the current configuration for the specified CNG context.</para>
	/// </summary>
	/// <param name="dwTable">
	/// <para>Identifies the configuration table that the context exists in. This can be one of the following values.</para>
	/// <list type="table">
	/// <listheader>
	/// <term>Value</term>
	/// <term>Meaning</term>
	/// </listheader>
	/// <item>
	/// <term>CRYPT_LOCAL</term>
	/// <term>The context exists in the local-machine configuration table.</term>
	/// </item>
	/// <item>
	/// <term>CRYPT_DOMAIN</term>
	/// <term>This value is not available for use.</term>
	/// </item>
	/// </list>
	/// </param>
	/// <param name="pszContext">
	/// <para>
	/// A pointer to a null-terminated Unicode string that contains the identifier of the context to obtain the configuration information for.
	/// </para>
	/// </param>
	/// <param name="pcbBuffer">
	/// <para>
	/// The address of a <c>ULONG</c> variable that, on entry, contains the size, in bytes, of the buffer pointed to by ppBuffer. If this
	/// size is not large enough to hold the context information, this function will fail with <c>STATUS_BUFFER_TOO_SMALL</c>.
	/// </para>
	/// <para>After this function returns, this variable contains the number of bytes that were copied to the ppBuffer buffer.</para>
	/// </param>
	/// <param name="ppBuffer">
	/// <para>
	/// The address of a pointer to a CRYPT_CONTEXT_CONFIG structure that receives the context configuration information retrieved by
	/// this function. The value pointed to by the pcbBuffer parameter contains the size of this buffer.
	/// </para>
	/// <para>
	/// If the value pointed to by this parameter is <c>NULL</c>, this function will allocate the required memory. This memory must be
	/// freed when it is no longer needed by passing this pointer to the BCryptFreeBuffer function.
	/// </para>
	/// <para>
	/// If this parameter is <c>NULL</c>, this function will place the required size, in bytes, in the variable pointed to by the
	/// pcbBuffer parameter and return <c>STATUS_BUFFER_TOO_SMALL</c>.
	/// </para>
	/// <para>For more information on the usage of this parameter, see Remarks.</para>
	/// </param>
	/// <returns>
	/// <para>Returns a status code that indicates the success or failure of the function.</para>
	/// <para>Possible return codes include, but are not limited to, the following.</para>
	/// <list type="table">
	/// <listheader>
	/// <term>Return code</term>
	/// <term>Description</term>
	/// </listheader>
	/// <item>
	/// <term>STATUS_SUCCESS</term>
	/// <term>The function was successful.</term>
	/// </item>
	/// <item>
	/// <term>STATUS_BUFFER_TOO_SMALL</term>
	/// <term>
	/// The ppBuffer parameter is not NULL, and the value pointed to by the pcbBuffer parameter is not large enough to hold the set of contexts.
	/// </term>
	/// </item>
	/// <item>
	/// <term>STATUS_INVALID_PARAMETER</term>
	/// <term>One or more parameters are not valid.</term>
	/// </item>
	/// <item>
	/// <term>STATUS_NO_MEMORY</term>
	/// <term>A memory allocation failure occurred.</term>
	/// </item>
	/// <item>
	/// <term>STATUS_NOT_FOUND</term>
	/// <term>The specified context could not be found.</term>
	/// </item>
	/// </list>
	/// </returns>
	/// <remarks>
	/// <para>
	/// Each context has only one set of configuration information, so although the ppBuffer parameter appears to be a used as an array,
	/// this function treats this as an array with only one element. The following example helps clarify how this parameter is used.
	/// </para>
	/// <para><c>BCryptQueryContextConfiguration</c> can be called only in user mode.</para>
	/// </remarks>
	// https://docs.microsoft.com/en-us/windows/desktop/api/bcrypt/nf-bcrypt-bcryptquerycontextconfiguration NTSTATUS
	// BCryptQueryContextConfiguration( ULONG dwTable, LPCWSTR pszContext, ULONG *pcbBuffer, PCRYPT_CONTEXT_CONFIG *ppBuffer );
	[DllImport(Lib.Bcrypt, SetLastError = false, ExactSpelling = true)]
	[PInvokeData("bcrypt.h", MSDNShortId = "3e2ae471-cad6-4bfe-9e30-7b2a7014bc08")]
	public static extern NTStatus BCryptQueryContextConfiguration(ContextConfigTable dwTable, [MarshalAs(UnmanagedType.LPWStr)] string pszContext, out uint pcbBuffer, out SafeBCryptBuffer ppBuffer);

	/// <summary>
	/// <para>
	/// [ <c>BCryptQueryContextFunctionConfiguration</c> is available for use in the operating systems specified in the Requirements
	/// section. It may be altered or unavailable in subsequent versions.]
	/// </para>
	/// <para>
	/// The <c>BCryptQueryContextFunctionConfiguration</c> function obtains the cryptographic function configuration information for an
	/// existing CNG context.
	/// </para>
	/// </summary>
	/// <param name="dwTable">
	/// <para>Identifies the configuration table that the context exists in. This can be one of the following values.</para>
	/// <list type="table">
	/// <listheader>
	/// <term>Value</term>
	/// <term>Meaning</term>
	/// </listheader>
	/// <item>
	/// <term>CRYPT_LOCAL</term>
	/// <term>The context exists in the local-machine configuration table.</term>
	/// </item>
	/// <item>
	/// <term>CRYPT_DOMAIN</term>
	/// <term>This value is not available for use.</term>
	/// </item>
	/// </list>
	/// </param>
	/// <param name="pszContext">
	/// <para>
	/// A pointer to a null-terminated Unicode string that contains the identifier of the context to obtain the function configuration
	/// information for.
	/// </para>
	/// </param>
	/// <param name="dwInterface">
	/// <para>
	/// Identifies the cryptographic interface to obtain the function configuration information for. This can be one of the following values.
	/// </para>
	/// <list type="table">
	/// <listheader>
	/// <term>Value</term>
	/// <term>Meaning</term>
	/// </listheader>
	/// <item>
	/// <term>BCRYPT_ASYMMETRIC_ENCRYPTION_INTERFACE</term>
	/// <term>Obtain the function configuration information from the list of asymmetric encryption functions.</term>
	/// </item>
	/// <item>
	/// <term>BCRYPT_CIPHER_INTERFACE</term>
	/// <term>Obtain the function configuration information from the list of cipher functions.</term>
	/// </item>
	/// <item>
	/// <term>BCRYPT_HASH_INTERFACE</term>
	/// <term>Obtain the function configuration information from the list of hash functions.</term>
	/// </item>
	/// <item>
	/// <term>BCRYPT_RNG_INTERFACE</term>
	/// <term>Obtain the function configuration information from the list of random number generator functions.</term>
	/// </item>
	/// <item>
	/// <term>BCRYPT_SECRET_AGREEMENT_INTERFACE</term>
	/// <term>Obtain the function configuration information from the list of secret agreement functions.</term>
	/// </item>
	/// <item>
	/// <term>BCRYPT_SIGNATURE_INTERFACE</term>
	/// <term>Obtain the function configuration information from the list of signature functions.</term>
	/// </item>
	/// <item>
	/// <term>NCRYPT_KEY_STORAGE_INTERFACE</term>
	/// <term>Obtain the function configuration information from the list of key storage functions.</term>
	/// </item>
	/// <item>
	/// <term>NCRYPT_SCHANNEL_INTERFACE</term>
	/// <term>Obtain the function configuration information from the list of Schannel functions.</term>
	/// </item>
	/// </list>
	/// </param>
	/// <param name="pszFunction">
	/// <para>
	/// A pointer to a null-terminated Unicode string that contains the identifier of the cryptographic function to obtain the
	/// configuration information for.
	/// </para>
	/// </param>
	/// <param name="pcbBuffer">
	/// <para>
	/// The address of a <c>ULONG</c> variable that, on entry, contains the size, in bytes, of the buffer pointed to by ppBuffer. If this
	/// size is not large enough to hold the context information, this function will fail with <c>STATUS_BUFFER_TOO_SMALL</c>.
	/// </para>
	/// <para>After this function returns, this variable contains the number of bytes that were copied to the ppBuffer buffer.</para>
	/// </param>
	/// <param name="ppBuffer">
	/// <para>
	/// The address of a pointer to a CRYPT_CONTEXT_FUNCTION_CONFIG structure that receives the function configuration information
	/// retrieved by this function. The value pointed to by the pcbBuffer parameter contains the size of this buffer.
	/// </para>
	/// <para>
	/// If the value pointed to by this parameter is <c>NULL</c>, this function will allocate the required memory. This memory must be
	/// freed when it is no longer needed by passing this pointer to the BCryptFreeBuffer function.
	/// </para>
	/// <para>
	/// If this parameter is <c>NULL</c>, this function will place the required size, in bytes, in the variable pointed to by the
	/// pcbBuffer parameter and return <c>STATUS_BUFFER_TOO_SMALL</c>.
	/// </para>
	/// <para>For more information about the usage of this parameter, see Remarks.</para>
	/// </param>
	/// <returns>
	/// <para>Returns a status code that indicates the success or failure of the function.</para>
	/// <para>Possible return codes include, but are not limited to, the following.</para>
	/// <list type="table">
	/// <listheader>
	/// <term>Return code</term>
	/// <term>Description</term>
	/// </listheader>
	/// <item>
	/// <term>STATUS_SUCCESS</term>
	/// <term>The function was successful.</term>
	/// </item>
	/// <item>
	/// <term>STATUS_BUFFER_TOO_SMALL</term>
	/// <term>
	/// The ppBuffer parameter is not NULL, and the value pointed to by the pcbBuffer parameter is not large enough to hold the set of contexts.
	/// </term>
	/// </item>
	/// <item>
	/// <term>STATUS_INVALID_PARAMETER</term>
	/// <term>One or more parameters are not valid.</term>
	/// </item>
	/// <item>
	/// <term>STATUS_NO_MEMORY</term>
	/// <term>A memory allocation failure occurred.</term>
	/// </item>
	/// <item>
	/// <term>STATUS_NOT_FOUND</term>
	/// <term>The specified context or function could not be found.</term>
	/// </item>
	/// </list>
	/// </returns>
	/// <remarks>
	/// <para>
	/// Each cryptographic function has only one set of configuration information, so although the ppBuffer parameter appears to be a
	/// used as an array, this function treats this as an array with only one element. The following example helps clarify how this
	/// parameter is used.
	/// </para>
	/// <para><c>BCryptQueryContextFunctionConfiguration</c> can be called only in user mode.</para>
	/// </remarks>
	// https://docs.microsoft.com/en-us/windows/desktop/api/bcrypt/nf-bcrypt-bcryptquerycontextfunctionconfiguration NTSTATUS
	// BCryptQueryContextFunctionConfiguration( ULONG dwTable, LPCWSTR pszContext, ULONG dwInterface, LPCWSTR pszFunction, ULONG
	// *pcbBuffer, PCRYPT_CONTEXT_FUNCTION_CONFIG *ppBuffer );
	[DllImport(Lib.Bcrypt, SetLastError = false, ExactSpelling = true, CharSet = CharSet.Unicode)]
	[PInvokeData("bcrypt.h", MSDNShortId = "4eea9efe-bf45-4926-86fc-9b12b6d292cd")]
	public static extern NTStatus BCryptQueryContextFunctionConfiguration(ContextConfigTable dwTable, string pszContext, InterfaceId dwInterface, string pszFunction, out uint pcbBuffer, out SafeBCryptBuffer ppBuffer);

	/// <summary>
	/// <para>
	/// The <c>BCryptQueryContextFunctionProperty</c> function obtains the value of a named property for a cryptographic function in an
	/// existing CNG context.
	/// </para>
	/// </summary>
	/// <param name="dwTable">
	/// <para>Identifies the configuration table that the context exists in. This can be one of the following values.</para>
	/// <list type="table">
	/// <listheader>
	/// <term>Value</term>
	/// <term>Meaning</term>
	/// </listheader>
	/// <item>
	/// <term>CRYPT_LOCAL</term>
	/// <term>The context exists in the local-machine configuration table.</term>
	/// </item>
	/// <item>
	/// <term>CRYPT_DOMAIN</term>
	/// <term>This value is not available for use.</term>
	/// </item>
	/// </list>
	/// </param>
	/// <param name="pszContext">
	/// <para>
	/// A pointer to a null-terminated Unicode string that contains the identifier of the context to obtain the function property from.
	/// </para>
	/// </param>
	/// <param name="dwInterface">
	/// <para>Identifies the cryptographic interface that the function exists in. This can be one of the following values.</para>
	/// <list type="table">
	/// <listheader>
	/// <term>Value</term>
	/// <term>Meaning</term>
	/// </listheader>
	/// <item>
	/// <term>BCRYPT_ASYMMETRIC_ENCRYPTION_INTERFACE</term>
	/// <term>The function exists in the list of asymmetric encryption functions.</term>
	/// </item>
	/// <item>
	/// <term>BCRYPT_CIPHER_INTERFACE</term>
	/// <term>The function exists in the list of cipher functions.</term>
	/// </item>
	/// <item>
	/// <term>BCRYPT_HASH_INTERFACE</term>
	/// <term>The function exists in the list of hash functions.</term>
	/// </item>
	/// <item>
	/// <term>BCRYPT_RNG_INTERFACE</term>
	/// <term>The function exists in the list of random number generator functions.</term>
	/// </item>
	/// <item>
	/// <term>BCRYPT_SECRET_AGREEMENT_INTERFACE</term>
	/// <term>The function exists in the list of secret agreement functions.</term>
	/// </item>
	/// <item>
	/// <term>BCRYPT_SIGNATURE_INTERFACE</term>
	/// <term>The function exists in the list of signature functions.</term>
	/// </item>
	/// <item>
	/// <term>NCRYPT_KEY_STORAGE_INTERFACE</term>
	/// <term>The function exists in the list of key storage functions.</term>
	/// </item>
	/// <item>
	/// <term>NCRYPT_SCHANNEL_INTERFACE</term>
	/// <term>The function exists in the list of Schannel functions.</term>
	/// </item>
	/// </list>
	/// </param>
	/// <param name="pszFunction">
	/// <para>
	/// A pointer to a null-terminated Unicode string that contains the identifier of the cryptographic function to obtain the property for.
	/// </para>
	/// </param>
	/// <param name="pszProperty">
	/// <para>A pointer to a null-terminated Unicode string that contains the identifier of the property to obtain.</para>
	/// </param>
	/// <param name="pcbValue">
	/// <para>
	/// The address of a <c>ULONG</c> variable that, on entry, contains the size, in bytes, of the buffer pointed to by ppbValue. If this
	/// size is not large enough to hold the property value, this function will fail with <c>STATUS_BUFFER_TOO_SMALL</c>.
	/// </para>
	/// <para>After this function returns, this variable contains the number of bytes that were copied to the ppbValue buffer.</para>
	/// </param>
	/// <param name="ppbValue">
	/// <para>
	/// The address of a pointer to a buffer that receives the property data. The size and format of this buffer depends on the format of
	/// the property being retrieved. The value pointed to by the pcbValue parameter contains the size of this buffer.
	/// </para>
	/// <para>
	/// If the value pointed to by this parameter is <c>NULL</c>, this function will allocate the required memory. This memory must be
	/// freed when it is no longer needed by passing this pointer to the BCryptFreeBuffer function.
	/// </para>
	/// <para>
	/// If this parameter is <c>NULL</c>, this function will place the required size, in bytes, in the variable pointed to by the
	/// pcbValue parameter and return <c>STATUS_BUFFER_TOO_SMALL</c>.
	/// </para>
	/// </param>
	/// <returns>
	/// <para>Returns a status code that indicates the success or failure of the function.</para>
	/// <para>Possible return codes include, but are not limited to, the following.</para>
	/// <list type="table">
	/// <listheader>
	/// <term>Return code</term>
	/// <term>Description</term>
	/// </listheader>
	/// <item>
	/// <term>STATUS_SUCCESS</term>
	/// <term>The function was successful.</term>
	/// </item>
	/// <item>
	/// <term>STATUS_BUFFER_TOO_SMALL</term>
	/// <term>
	/// The ppbValue parameter is not NULL, and the value pointed to by the pcbValue parameter is not large enough to hold the set of contexts.
	/// </term>
	/// </item>
	/// <item>
	/// <term>STATUS_INVALID_PARAMETER</term>
	/// <term>One or more parameters are not valid.</term>
	/// </item>
	/// <item>
	/// <term>STATUS_NO_MEMORY</term>
	/// <term>A memory allocation failure occurred.</term>
	/// </item>
	/// <item>
	/// <term>STATUS_NOT_FOUND</term>
	/// <term>The specified context, function, or property could not be found.</term>
	/// </item>
	/// </list>
	/// </returns>
	/// <remarks>
	/// <para><c>BCryptQueryContextFunctionProperty</c> can be called only in user mode.</para>
	/// </remarks>
	// https://docs.microsoft.com/en-us/windows/desktop/api/bcrypt/nf-bcrypt-bcryptquerycontextfunctionproperty NTSTATUS
	// BCryptQueryContextFunctionProperty( ULONG dwTable, LPCWSTR pszContext, ULONG dwInterface, LPCWSTR pszFunction, LPCWSTR
	// pszProperty, ULONG *pcbValue, PUCHAR *ppbValue );
	[DllImport(Lib.Bcrypt, SetLastError = false, ExactSpelling = true, CharSet = CharSet.Unicode)]
	[PInvokeData("bcrypt.h", MSDNShortId = "c8814a13-ac28-4583-927f-c787e0a25faf")]
	public static extern NTStatus BCryptQueryContextFunctionProperty(ContextConfigTable dwTable, string pszContext, InterfaceId dwInterface, string pszFunction, string pszProperty, out uint pcbValue, out SafeBCryptBuffer ppbValue);

	/// <summary>The <c>BCryptQueryProviderRegistration</c> function retrieves information about a CNG provider.</summary>
	/// <param name="pszProvider">
	/// A pointer to a null-terminated Unicode string that contains the name of the provider to obtain information about.
	/// </param>
	/// <param name="dwMode">
	/// <para>Specifies the type of information to retrieve. This can be one of the following values.</para>
	/// <list type="table">
	/// <listheader>
	/// <term>Value</term>
	/// <term>Meaning</term>
	/// </listheader>
	/// <item>
	/// <term>CRYPT_ANY</term>
	/// <term>Retrieve any information for the provider.</term>
	/// </item>
	/// <item>
	/// <term>CRYPT_UM</term>
	/// <term>Retrieve the user mode information for the provider.</term>
	/// </item>
	/// <item>
	/// <term>CRYPT_KM</term>
	/// <term>Retrieve the kernel mode information for the provider.</term>
	/// </item>
	/// <item>
	/// <term>CRYPT_MM</term>
	/// <term>Retrieve both the user mode and kernel mode information for the provider.</term>
	/// </item>
	/// </list>
	/// </param>
	/// <param name="dwInterface">
	/// <para>Specifies the interface to retrieve information for. This can be one of the following values.</para>
	/// <list type="table">
	/// <listheader>
	/// <term>Value</term>
	/// <term>Meaning</term>
	/// </listheader>
	/// <item>
	/// <term>BCRYPT_ASYMMETRIC_ENCRYPTION_INTERFACE</term>
	/// <term>Retrieve the asymmetric encryption interface.</term>
	/// </item>
	/// <item>
	/// <term>BCRYPT_CIPHER_INTERFACE</term>
	/// <term>Retrieve the cipher interface.</term>
	/// </item>
	/// <item>
	/// <term>BCRYPT_HASH_INTERFACE</term>
	/// <term>Retrieve the hash interface.</term>
	/// </item>
	/// <item>
	/// <term>NCRYPT_KEY_STORAGE_INTERFACE</term>
	/// <term>Retrieve the key storage interface.</term>
	/// </item>
	/// <item>
	/// <term>BCRYPT_RNG_INTERFACE</term>
	/// <term>Retrieve the random number generator interface.</term>
	/// </item>
	/// <item>
	/// <term>NCRYPT_SCHANNEL_INTERFACE</term>
	/// <term>Retrieve the Schannel interface.</term>
	/// </item>
	/// <item>
	/// <term>BCRYPT_SECRET_AGREEMENT_INTERFACE</term>
	/// <term>Retrieve the secret agreement interface.</term>
	/// </item>
	/// <item>
	/// <term>BCRYPT_SIGNATURE_INTERFACE</term>
	/// <term>Retrieve the signature interface.</term>
	/// </item>
	/// </list>
	/// </param>
	/// <param name="pcbBuffer">
	/// <para>
	/// A pointer to a <c>ULONG</c> value that, on entry, contains the size, in bytes, of the buffer pointed to by the ppBuffer
	/// parameter. On exit, this value receives either the number of bytes copied to the buffer or the required size, in bytes, of the buffer.
	/// </para>
	/// <para>
	/// <c>Note</c> This is the total size, in bytes, of the entire buffer, not just the size of the CRYPT_PROVIDER_REG structure. The
	/// buffer must be able to hold other data for the providers in addition to the <c>CRYPT_PROVIDER_REG</c> structure.
	/// </para>
	/// </param>
	/// <param name="ppBuffer">
	/// <para>A pointer to a buffer pointer that receives a CRYPT_PROVIDER_REG structure and other data that describes the provider.</para>
	/// <para>
	/// If this parameter is <c>NULL</c>, this function will return <c>STATUS_BUFFER_TOO_SMALL</c> and place in the value pointed to by
	/// the pcbBuffer parameter, the required size, in bytes, of all data.
	/// </para>
	/// <para>
	/// If this parameter is the address of a <c>NULL</c> pointer, this function will allocate the required memory, fill it in with the
	/// provider information, and place a pointer to this memory in this parameter. When you have finished using this memory, free it by
	/// passing this pointer to the BCryptFreeBuffer function.
	/// </para>
	/// <para>
	/// If this parameter is the address of a non- <c>NULL</c> pointer, this function will copy the provider information into this
	/// buffer. The pcbBuffer parameter must contain the size, in bytes, of the entire buffer. If the buffer is not large enough to hold
	/// all of the provider information, this function will return <c>STATUS_BUFFER_TOO_SMALL</c>.
	/// </para>
	/// </param>
	/// <returns>
	/// <para>Returns a status code that indicates the success or failure of the function.</para>
	/// <para>Possible return codes include, but are not limited to, the following.</para>
	/// <list type="table">
	/// <listheader>
	/// <term>Return code</term>
	/// <term>Description</term>
	/// </listheader>
	/// <item>
	/// <term>STATUS_SUCCESS</term>
	/// <term>The function was successful.</term>
	/// </item>
	/// <item>
	/// <term>STATUS_INVALID_PARAMETER</term>
	/// <term>One or more parameters are not valid.</term>
	/// </item>
	/// <item>
	/// <term>STATUS_BUFFER_TOO_SMALL</term>
	/// <term>The size specified by the pcbBuffer parameter is not large enough to hold all of the data.</term>
	/// </item>
	/// <item>
	/// <term>STATUS_NOT_FOUND</term>
	/// <term>No provider could be found that matches the specified criteria.</term>
	/// </item>
	/// </list>
	/// </returns>
	/// <remarks><c>BCryptQueryProviderRegistration</c> can be called only in user mode.</remarks>
	// https://docs.microsoft.com/en-us/windows/desktop/api/bcrypt/nf-bcrypt-bcryptqueryproviderregistration NTSTATUS
	// BCryptQueryProviderRegistration( LPCWSTR pszProvider, ULONG dwMode, ULONG dwInterface, ULONG *pcbBuffer, PCRYPT_PROVIDER_REG
	// *ppBuffer );
	[DllImport(Lib.Bcrypt, SetLastError = false, ExactSpelling = true)]
	[PInvokeData("bcrypt.h", MSDNShortId = "28b8bca9-442f-4d58-86aa-8aa274777ede")]
	public static extern NTStatus BCryptQueryProviderRegistration([MarshalAs(UnmanagedType.LPWStr)] string pszProvider, ProviderInfoType dwMode, InterfaceId dwInterface, out uint pcbBuffer, out SafeBCryptBuffer ppBuffer);

	/// <summary>
	/// <para>[ <c>BCryptRegisterConfigChangeNotify</c> is deprecated beginning with Windows 10.]</para>
	/// <para>The <c>BCryptRegisterConfigChangeNotify(PRKEVENT)</c> function creates a kernel mode CNG configuration change event handler.</para>
	/// </summary>
	/// <param name="phEvent">
	/// <para>
	/// The address of a <c>PRKEVENT</c> variable that receives the pointer to the event dispatcher object. You use the kernel wait
	/// functions, such as KeWaitForSingleObject, to determine when the event has been signaled. The event is signaled when the CNG
	/// configuration has changed.
	/// </para>
	/// <para>This handle must be passed to the <c>BCryptUnregisterConfigChangeNotify(PRKEVENT)</c> function to remove the event notification.</para>
	/// </param>
	/// <returns>
	/// <para>Returns a status code that indicates the success or failure of the function.</para>
	/// <para>Possible return codes include, but are not limited to, the following.</para>
	/// <para>
	/// <list type="table">
	/// <listheader>
	/// <term>Return code</term>
	/// <term>Description</term>
	/// </listheader>
	/// <item>
	/// <term>STATUS_SUCCESS</term>
	/// <term>The function was successful.</term>
	/// </item>
	/// <item>
	/// <term>STATUS_INVALID_PARAMETER</term>
	/// <term>The phEvent parameter is not valid.</term>
	/// </item>
	/// <item>
	/// <term>STATUS_NO_MEMORY</term>
	/// <term>A memory allocation failure occurred.</term>
	/// </item>
	/// </list>
	/// </para>
	/// </returns>
	// NTSTATUS WINAPI BCryptRegisterConfigChangeNotify( _In_ PRKEVENT phEvent); https://msdn.microsoft.com/en-us/library/windows/desktop/bb394681(v=vs.85).aspx
	[DllImport(Lib.Bcrypt, SetLastError = false, ExactSpelling = true)]
	[PInvokeData("Bcrypt.h", MSDNShortId = "bb394681")]
	public static extern NTStatus BCryptRegisterConfigChangeNotify(IntPtr phEvent);

	/// <summary>
	/// <para>
	/// [ <c>BCryptRemoveContextFunction</c> is available for use in the operating systems specified in the Requirements section. It may
	/// be altered or unavailable in subsequent versions.]
	/// </para>
	/// <para>
	/// The <c>BCryptRemoveContextFunction</c> function removes a cryptographic function from the list of functions that are supported by
	/// an existing CNG context.
	/// </para>
	/// </summary>
	/// <param name="dwTable">
	/// <para>Identifies the configuration table that the context exists in. This can be one of the following values.</para>
	/// <list type="table">
	/// <listheader>
	/// <term>Value</term>
	/// <term>Meaning</term>
	/// </listheader>
	/// <item>
	/// <term>CRYPT_LOCAL</term>
	/// <term>The context exists in the local-machine configuration table.</term>
	/// </item>
	/// <item>
	/// <term>CRYPT_DOMAIN</term>
	/// <term>This value is not available for use.</term>
	/// </item>
	/// </list>
	/// </param>
	/// <param name="pszContext">
	/// <para>A pointer to a null-terminated Unicode string that contains the identifier of the context to remove the function from.</para>
	/// </param>
	/// <param name="dwInterface">
	/// <para>Identifies the cryptographic interface to remove the function from. This can be one of the following values.</para>
	/// <list type="table">
	/// <listheader>
	/// <term>Value</term>
	/// <term>Meaning</term>
	/// </listheader>
	/// <item>
	/// <term>BCRYPT_ASYMMETRIC_ENCRYPTION_INTERFACE</term>
	/// <term>Remove the function from the list of asymmetric encryption functions.</term>
	/// </item>
	/// <item>
	/// <term>BCRYPT_CIPHER_INTERFACE</term>
	/// <term>Remove the function from the list of cipher functions.</term>
	/// </item>
	/// <item>
	/// <term>BCRYPT_HASH_INTERFACE</term>
	/// <term>Remove the function from the list of hash functions.</term>
	/// </item>
	/// <item>
	/// <term>BCRYPT_RNG_INTERFACE</term>
	/// <term>Remove the function from the list of random number generator functions.</term>
	/// </item>
	/// <item>
	/// <term>BCRYPT_SECRET_AGREEMENT_INTERFACE</term>
	/// <term>Remove the function from the list of secret agreement functions.</term>
	/// </item>
	/// <item>
	/// <term>BCRYPT_SIGNATURE_INTERFACE</term>
	/// <term>Remove the function from the list of signature functions.</term>
	/// </item>
	/// <item>
	/// <term>NCRYPT_KEY_STORAGE_INTERFACE</term>
	/// <term>Remove the function from the list of key storage functions.</term>
	/// </item>
	/// <item>
	/// <term>NCRYPT_SCHANNEL_INTERFACE</term>
	/// <term>Remove the function from the list of Schannel functions.</term>
	/// </item>
	/// <item>
	/// <term>NCRYPT_SCHANNEL_SIGNATURE_INTERFACE</term>
	/// <term>
	/// Remove the function from the list of signature suites that Schannel accepts for TLS 1.2. Windows Vista and Windows Server 2008:
	/// This value is not supported.
	/// </term>
	/// </item>
	/// </list>
	/// </param>
	/// <param name="pszFunction">
	/// <para>A pointer to a null-terminated Unicode string that contains the identifier of the cryptographic function to remove.</para>
	/// </param>
	/// <returns>
	/// <para>Returns a status code that indicates the success or failure of the function.</para>
	/// <para>Possible return codes include, but are not limited to, the following.</para>
	/// <list type="table">
	/// <listheader>
	/// <term>Return code</term>
	/// <term>Description</term>
	/// </listheader>
	/// <item>
	/// <term>STATUS_SUCCESS</term>
	/// <term>The function was successful.</term>
	/// </item>
	/// <item>
	/// <term>STATUS_INVALID_PARAMETER</term>
	/// <term>One or more parameters are not valid.</term>
	/// </item>
	/// <item>
	/// <term>STATUS_NOT_FOUND</term>
	/// <term>The specified context or function could not be found.</term>
	/// </item>
	/// </list>
	/// </returns>
	/// <remarks>
	/// <para><c>BCryptRemoveContextFunction</c> can be called only in user mode.</para>
	/// </remarks>
	// https://docs.microsoft.com/en-us/windows/desktop/api/bcrypt/nf-bcrypt-bcryptremovecontextfunction NTSTATUS
	// BCryptRemoveContextFunction( ULONG dwTable, LPCWSTR pszContext, ULONG dwInterface, LPCWSTR pszFunction );
	[DllImport(Lib.Bcrypt, SetLastError = false, ExactSpelling = true, CharSet = CharSet.Unicode)]
	[PInvokeData("bcrypt.h", MSDNShortId = "b8b1df66-f66f-4efc-9c8e-fca32e0278c5")]
	public static extern NTStatus BCryptRemoveContextFunction(ContextConfigTable dwTable, string pszContext, InterfaceId dwInterface, string pszFunction);

	/// <summary>
	/// <para>The <c>BCryptResolveProviders</c> function obtains a collection of all of the providers that meet the specified criteria.</para>
	/// </summary>
	/// <param name="pszContext">
	/// <para>
	/// A pointer to a null-terminated Unicode string that contains the identifier of the context for which to obtain the providers. If
	/// this is set to <c>NULL</c> or to an empty string, the default context is assumed.
	/// </para>
	/// </param>
	/// <param name="dwInterface">
	/// <para>
	/// The identifier of an interface that the provider must support. This must be one of the CNG Interface Identifiers. If the
	/// pszFunction parameter is not <c>NULL</c> or an empty string, you can set dwInterface to zero to force the function to infer the interface.
	/// </para>
	/// </param>
	/// <param name="pszFunction">
	/// <para>
	/// A pointer to a null-terminated Unicode string that contains the algorithm or function identifier that the provider must support.
	/// This can be one of the standard CNG Algorithm Identifiers or the identifier for another registered algorithm. If dwInterface is
	/// set to a nonzero value, then pszFunction can be <c>NULL</c> to include all algorithms and functions.
	/// </para>
	/// </param>
	/// <param name="pszProvider">
	/// <para>
	/// A pointer to a null-terminated Unicode string that contains the name of the provider to retrieve. If this parameter is
	/// <c>NULL</c>, then all providers will be included.
	/// </para>
	/// <para>
	/// This parameter allows you to specify a specific provider to retrieve in the event that more than one provider meets the other criteria.
	/// </para>
	/// </param>
	/// <param name="dwMode">
	/// <para>Specifies the type of provider to retrieve. This can be one of the following values.</para>
	/// <list type="table">
	/// <listheader>
	/// <term>Value</term>
	/// <term>Meaning</term>
	/// </listheader>
	/// <item>
	/// <term>CRYPT_UM</term>
	/// <term>Retrieve user mode providers.</term>
	/// </item>
	/// <item>
	/// <term>CRYPT_KM</term>
	/// <term>Retrieve kernel mode providers.</term>
	/// </item>
	/// <item>
	/// <term>CRYPT_MM</term>
	/// <term>Retrieve both user mode and kernel mode providers.</term>
	/// </item>
	/// </list>
	/// </param>
	/// <param name="dwFlags">
	/// <para>A set of flags that modify the behavior of this function.</para>
	/// <para>This can be a zero or a combination of one or more of the following values.</para>
	/// <list type="table">
	/// <listheader>
	/// <term>Value</term>
	/// <term>Meaning</term>
	/// </listheader>
	/// <item>
	/// <term>CRYPT_ALL_FUNCTIONS 1</term>
	/// <term>
	/// This function will retrieve all of the functions supported by each provider that meets the specified criteria. If this flag is
	/// not specified, this function will only retrieve the first function of the provider or providers that meet the specified criteria.
	/// </term>
	/// </item>
	/// <item>
	/// <term>CRYPT_ALL_PROVIDERS 2</term>
	/// <term>
	/// This function will retrieve all of the providers that meet the specified criteria. If this flag is not specified, this function
	/// will only retrieve the first provider that is found that meets the specified criteria.
	/// </term>
	/// </item>
	/// </list>
	/// </param>
	/// <param name="pcbBuffer">
	/// <para>
	/// A pointer to a <c>DWORD</c> value that, on entry, contains the size, in bytes, of the buffer pointed to by the ppBuffer
	/// parameter. On exit, this value receives either the number of bytes copied to the buffer or the required size, in bytes, of the buffer.
	/// </para>
	/// </param>
	/// <param name="ppBuffer">
	/// <para>The address of a CRYPT_PROVIDER_REFS pointer that receives the collection of providers that meet the specified criteria.</para>
	/// <para>
	/// If this parameter is <c>NULL</c>, this function will return <c>STATUS_SUCCESS</c> and place in the value pointed to by the
	/// pcbBuffer parameter, the required size, in bytes, of all the data.
	/// </para>
	/// <para>
	/// If this parameter is the address of a <c>NULL</c> pointer, this function will allocate the required memory, fill the memory with
	/// the information about the providers, and place the pointer to this memory in this parameter. When you have finished using this
	/// memory, free it by passing this pointer to the BCryptFreeBuffer function.
	/// </para>
	/// <para>
	/// If this parameter is the address of a non- <c>NULL</c> pointer, this function will copy the provider information into this
	/// buffer. The pcbBuffer parameter must contain the size, in bytes, of the entire buffer. If the buffer is not large enough to hold
	/// all of the provider information, this function will return <c>STATUS_BUFFER_TOO_SMALL</c>.
	/// </para>
	/// </param>
	/// <returns>
	/// <para>Returns a status code that indicates the success or failure of the function.</para>
	/// <para>Possible return codes include, but are not limited to, the following.</para>
	/// <list type="table">
	/// <listheader>
	/// <term>Return code</term>
	/// <term>Description</term>
	/// </listheader>
	/// <item>
	/// <term>STATUS_SUCCESS</term>
	/// <term>The function was successful.</term>
	/// </item>
	/// <item>
	/// <term>STATUS_BUFFER_TOO_SMALL</term>
	/// <term>The size specified by the pcbBuffer parameter is not large enough to hold all of the data.</term>
	/// </item>
	/// <item>
	/// <term>STATUS_INVALID_PARAMETER</term>
	/// <term>One or more parameters are not valid.</term>
	/// </item>
	/// <item>
	/// <term>STATUS_NOT_FOUND</term>
	/// <term>No provider could be found that meets all of the specified criteria.</term>
	/// </item>
	/// </list>
	/// </returns>
	/// <remarks>
	/// <para>
	/// <c>BCryptResolveProviders</c> can be called either from user mode or kernel mode. Kernel mode callers must be executing at
	/// <c>PASSIVE_LEVEL</c> IRQL.
	/// </para>
	/// </remarks>
	// https://docs.microsoft.com/en-us/windows/desktop/api/bcrypt/nf-bcrypt-bcryptresolveproviders NTSTATUS BCryptResolveProviders(
	// LPCWSTR pszContext, ULONG dwInterface, LPCWSTR pszFunction, LPCWSTR pszProvider, ULONG dwMode, ULONG dwFlags, ULONG *pcbBuffer,
	// PCRYPT_PROVIDER_REFS *ppBuffer );
	[DllImport(Lib.Bcrypt, SetLastError = false, ExactSpelling = true, CharSet = CharSet.Unicode)]
	[PInvokeData("bcrypt.h", MSDNShortId = "cf30f635-4918-4911-9db0-df90d26a2f1a")]
	public static extern NTStatus BCryptResolveProviders([Optional] string? pszContext, InterfaceId dwInterface, [Optional] string? pszFunction, [Optional] string? pszProvider, ProviderInfoType dwMode,
		ResolveProviderFlags dwFlags, out uint pcbBuffer, out SafeBCryptBuffer ppBuffer);

	/// <summary>
	/// <para>The <c>BCryptSecretAgreement</c> function creates a secret agreement value from a private and a public key.</para>
	/// </summary>
	/// <param name="hPrivKey">
	/// <para>
	/// The handle of the private key to use to create the secret agreement value. This key and the hPubKey key must come from the same
	/// CNG cryptographic algorithm provider.
	/// </para>
	/// </param>
	/// <param name="hPubKey">
	/// <para>
	/// The handle of the public key to use to create the secret agreement value. This key and the hPrivKey key must come from the same
	/// CNG cryptographic algorithm provider.
	/// </para>
	/// </param>
	/// <param name="phAgreedSecret">
	/// <para>
	/// A pointer to a <c>BCRYPT_SECRET_HANDLE</c> that receives a handle that represents the secret agreement value. This handle must be
	/// released by passing it to the BCryptDestroySecret function when it is no longer needed.
	/// </para>
	/// </param>
	/// <param name="dwFlags">
	/// <para>A set of flags that modify the behavior of this function. No flags are defined for this function.</para>
	/// </param>
	/// <returns>
	/// <para>Returns a status code that indicates the success or failure of the function.</para>
	/// <para>Possible return codes include, but are not limited to, the following.</para>
	/// <list type="table">
	/// <listheader>
	/// <term>Return code</term>
	/// <term>Description</term>
	/// </listheader>
	/// <item>
	/// <term>STATUS_SUCCESS</term>
	/// <term>The function was successful.</term>
	/// </item>
	/// <item>
	/// <term>STATUS_INVALID_HANDLE</term>
	/// <term>The key handle in the hPrivKey or hPubKey parameter is not valid.</term>
	/// </item>
	/// <item>
	/// <term>STATUS_INVALID_PARAMETER</term>
	/// <term>One or more parameters are not valid.</term>
	/// </item>
	/// <item>
	/// <term>STATUS_NOT_SUPPORTED</term>
	/// <term>The key handle in the hPrivKey parameter is not a Diffie-Hellman key.</term>
	/// </item>
	/// </list>
	/// </returns>
	/// <remarks>
	/// <para>
	/// Depending on what processor modes a provider supports, <c>BCryptSecretAgreement</c> can be called either from user mode or kernel
	/// mode. Kernel mode callers can execute either at <c>PASSIVE_LEVEL</c> IRQL or <c>DISPATCH_LEVEL</c> IRQL. If the current IRQL
	/// level is <c>DISPATCH_LEVEL</c>, the handles provided in the hPrivKey and hPubKey parameters must be derived from an algorithm
	/// handle returned by a provider that was opened by using the <c>BCRYPT_PROV_DISPATCH</c> flag, and any pointers passed to the
	/// <c>BCryptSecretAgreement</c> function must refer to nonpaged (or locked) memory.
	/// </para>
	/// <para>
	/// To call this function in kernel mode, use Cng.lib, which is part of the Driver Development Kit (DDK). For more information, see
	/// WDK and Developer Tools. <c>Windows Server 2008 and Windows Vista:</c> To call this function in kernel mode, use Ksecdd.lib.
	/// </para>
	/// </remarks>
	// https://docs.microsoft.com/en-us/windows/desktop/api/bcrypt/nf-bcrypt-bcryptsecretagreement NTSTATUS BCryptSecretAgreement(
	// BCRYPT_KEY_HANDLE hPrivKey, BCRYPT_KEY_HANDLE hPubKey, BCRYPT_SECRET_HANDLE *phAgreedSecret, ULONG dwFlags );
	[DllImport(Lib.Bcrypt, SetLastError = false, ExactSpelling = true)]
	[PInvokeData("bcrypt.h", MSDNShortId = "96863d81-3643-4962-8abf-db1cc2acde07")]
	public static extern NTStatus BCryptSecretAgreement(BCRYPT_KEY_HANDLE hPrivKey, BCRYPT_KEY_HANDLE hPubKey, out SafeBCRYPT_SECRET_HANDLE phAgreedSecret, uint dwFlags = 0);

	/// <summary>
	/// <para>
	/// The <c>BCryptSetContextFunctionProperty</c> function sets the value of a named property for a cryptographic function in an
	/// existing CNG context.
	/// </para>
	/// </summary>
	/// <param name="dwTable">
	/// <para>Identifies the configuration table that the context exists in. This can be one of the following values.</para>
	/// <list type="table">
	/// <listheader>
	/// <term>Value</term>
	/// <term>Meaning</term>
	/// </listheader>
	/// <item>
	/// <term>CRYPT_LOCAL</term>
	/// <term>The context exists in the local-machine configuration table.</term>
	/// </item>
	/// <item>
	/// <term>CRYPT_DOMAIN</term>
	/// <term>This value is not available for use.</term>
	/// </item>
	/// </list>
	/// </param>
	/// <param name="pszContext">
	/// <para>
	/// A pointer to a null-terminated Unicode string that contains the identifier of the context to set the function property in.
	/// </para>
	/// </param>
	/// <param name="dwInterface">
	/// <para>Identifies the cryptographic interface that the function exists in. This can be one of the following values.</para>
	/// <list type="table">
	/// <listheader>
	/// <term>Value</term>
	/// <term>Meaning</term>
	/// </listheader>
	/// <item>
	/// <term>BCRYPT_ASYMMETRIC_ENCRYPTION_INTERFACE</term>
	/// <term>The function exists in the list of asymmetric encryption functions.</term>
	/// </item>
	/// <item>
	/// <term>BCRYPT_CIPHER_INTERFACE</term>
	/// <term>The function exists in the list of cipher functions.</term>
	/// </item>
	/// <item>
	/// <term>BCRYPT_HASH_INTERFACE</term>
	/// <term>The function exists in the list of hash functions.</term>
	/// </item>
	/// <item>
	/// <term>BCRYPT_RNG_INTERFACE</term>
	/// <term>The function exists in the list of random number generator functions.</term>
	/// </item>
	/// <item>
	/// <term>BCRYPT_SECRET_AGREEMENT_INTERFACE</term>
	/// <term>The function exists in the list of secret agreement functions.</term>
	/// </item>
	/// <item>
	/// <term>BCRYPT_SIGNATURE_INTERFACE</term>
	/// <term>The function exists in the list of signature functions.</term>
	/// </item>
	/// <item>
	/// <term>NCRYPT_KEY_STORAGE_INTERFACE</term>
	/// <term>The function exists in the list of key storage functions.</term>
	/// </item>
	/// <item>
	/// <term>NCRYPT_SCHANNEL_INTERFACE</term>
	/// <term>The function exists in the list of Schannel functions.</term>
	/// </item>
	/// </list>
	/// </param>
	/// <param name="pszFunction">
	/// <para>
	/// A pointer to a null-terminated Unicode string that contains the identifier of the cryptographic function to set the property for.
	/// </para>
	/// </param>
	/// <param name="pszProperty">
	/// <para>A pointer to a null-terminated Unicode string that contains the identifier of the property to set.</para>
	/// </param>
	/// <param name="cbValue">
	/// <para>
	/// Contains the size, in bytes, of the pbValue buffer. This is the exact number of bytes that will be stored. If the property value
	/// is a string, you should add the size of one character to also store the terminating null character, if needed.
	/// </para>
	/// </param>
	/// <param name="pbValue">
	/// <para>The address of a buffer that contains the new property value.</para>
	/// </param>
	/// <returns>
	/// <para>Returns a status code that indicates the success or failure of the function.</para>
	/// <para>Possible return codes include, but are not limited to, the following.</para>
	/// <list type="table">
	/// <listheader>
	/// <term>Return code</term>
	/// <term>Description</term>
	/// </listheader>
	/// <item>
	/// <term>STATUS_SUCCESS</term>
	/// <term>The function was successful.</term>
	/// </item>
	/// <item>
	/// <term>STATUS_ACCESS_DENIED</term>
	/// <term>The caller does not have write access to the properties for the function.</term>
	/// </item>
	/// <item>
	/// <term>STATUS_INVALID_PARAMETER</term>
	/// <term>One or more parameters are not valid.</term>
	/// </item>
	/// <item>
	/// <term>STATUS_NO_MEMORY</term>
	/// <term>A memory allocation failure occurred.</term>
	/// </item>
	/// <item>
	/// <term>STATUS_NOT_FOUND</term>
	/// <term>The specified context or function could not be found.</term>
	/// </item>
	/// </list>
	/// </returns>
	/// <remarks>
	/// <para><c>BCryptSetContextFunctionProperty</c> can be called only in user mode.</para>
	/// </remarks>
	// https://docs.microsoft.com/en-us/windows/desktop/api/bcrypt/nf-bcrypt-bcryptsetcontextfunctionproperty NTSTATUS
	// BCryptSetContextFunctionProperty( ULONG dwTable, LPCWSTR pszContext, ULONG dwInterface, LPCWSTR pszFunction, LPCWSTR pszProperty,
	// ULONG cbValue, PUCHAR pbValue );
	[DllImport(Lib.Bcrypt, SetLastError = false, ExactSpelling = true, CharSet = CharSet.Unicode)]
	[PInvokeData("bcrypt.h", MSDNShortId = "1e02720b-5210-4127-ab9e-24532a764795")]
	public static extern NTStatus BCryptSetContextFunctionProperty(ContextConfigTable dwTable, string pszContext, InterfaceId dwInterface, string pszFunction, string pszProperty, uint cbValue, SafeAllocatedMemoryHandle pbValue);

	/// <summary>
	/// <para>
	/// The <c>BCryptSetContextFunctionProperty</c> function sets the value of a named property for a cryptographic function in an
	/// existing CNG context.
	/// </para>
	/// </summary>
	/// <param name="dwTable">
	/// <para>Identifies the configuration table that the context exists in. This can be one of the following values.</para>
	/// <list type="table">
	/// <listheader>
	/// <term>Value</term>
	/// <term>Meaning</term>
	/// </listheader>
	/// <item>
	/// <term>CRYPT_LOCAL</term>
	/// <term>The context exists in the local-machine configuration table.</term>
	/// </item>
	/// <item>
	/// <term>CRYPT_DOMAIN</term>
	/// <term>This value is not available for use.</term>
	/// </item>
	/// </list>
	/// </param>
	/// <param name="pszContext">
	/// <para>
	/// A pointer to a null-terminated Unicode string that contains the identifier of the context to set the function property in.
	/// </para>
	/// </param>
	/// <param name="dwInterface">
	/// <para>Identifies the cryptographic interface that the function exists in. This can be one of the following values.</para>
	/// <list type="table">
	/// <listheader>
	/// <term>Value</term>
	/// <term>Meaning</term>
	/// </listheader>
	/// <item>
	/// <term>BCRYPT_ASYMMETRIC_ENCRYPTION_INTERFACE</term>
	/// <term>The function exists in the list of asymmetric encryption functions.</term>
	/// </item>
	/// <item>
	/// <term>BCRYPT_CIPHER_INTERFACE</term>
	/// <term>The function exists in the list of cipher functions.</term>
	/// </item>
	/// <item>
	/// <term>BCRYPT_HASH_INTERFACE</term>
	/// <term>The function exists in the list of hash functions.</term>
	/// </item>
	/// <item>
	/// <term>BCRYPT_RNG_INTERFACE</term>
	/// <term>The function exists in the list of random number generator functions.</term>
	/// </item>
	/// <item>
	/// <term>BCRYPT_SECRET_AGREEMENT_INTERFACE</term>
	/// <term>The function exists in the list of secret agreement functions.</term>
	/// </item>
	/// <item>
	/// <term>BCRYPT_SIGNATURE_INTERFACE</term>
	/// <term>The function exists in the list of signature functions.</term>
	/// </item>
	/// <item>
	/// <term>NCRYPT_KEY_STORAGE_INTERFACE</term>
	/// <term>The function exists in the list of key storage functions.</term>
	/// </item>
	/// <item>
	/// <term>NCRYPT_SCHANNEL_INTERFACE</term>
	/// <term>The function exists in the list of Schannel functions.</term>
	/// </item>
	/// </list>
	/// </param>
	/// <param name="pszFunction">
	/// <para>
	/// A pointer to a null-terminated Unicode string that contains the identifier of the cryptographic function to set the property for.
	/// </para>
	/// </param>
	/// <param name="pszProperty">
	/// <para>A pointer to a null-terminated Unicode string that contains the identifier of the property to set.</para>
	/// </param>
	/// <param name="cbValue">
	/// <para>
	/// Contains the size, in bytes, of the pbValue buffer. This is the exact number of bytes that will be stored. If the property value
	/// is a string, you should add the size of one character to also store the terminating null character, if needed.
	/// </para>
	/// </param>
	/// <param name="pbValue">
	/// <para>The address of a buffer that contains the new property value.</para>
	/// </param>
	/// <returns>
	/// <para>Returns a status code that indicates the success or failure of the function.</para>
	/// <para>Possible return codes include, but are not limited to, the following.</para>
	/// <list type="table">
	/// <listheader>
	/// <term>Return code</term>
	/// <term>Description</term>
	/// </listheader>
	/// <item>
	/// <term>STATUS_SUCCESS</term>
	/// <term>The function was successful.</term>
	/// </item>
	/// <item>
	/// <term>STATUS_ACCESS_DENIED</term>
	/// <term>The caller does not have write access to the properties for the function.</term>
	/// </item>
	/// <item>
	/// <term>STATUS_INVALID_PARAMETER</term>
	/// <term>One or more parameters are not valid.</term>
	/// </item>
	/// <item>
	/// <term>STATUS_NO_MEMORY</term>
	/// <term>A memory allocation failure occurred.</term>
	/// </item>
	/// <item>
	/// <term>STATUS_NOT_FOUND</term>
	/// <term>The specified context or function could not be found.</term>
	/// </item>
	/// </list>
	/// </returns>
	/// <remarks>
	/// <para><c>BCryptSetContextFunctionProperty</c> can be called only in user mode.</para>
	/// </remarks>
	// https://docs.microsoft.com/en-us/windows/desktop/api/bcrypt/nf-bcrypt-bcryptsetcontextfunctionproperty NTSTATUS
	// BCryptSetContextFunctionProperty( ULONG dwTable, LPCWSTR pszContext, ULONG dwInterface, LPCWSTR pszFunction, LPCWSTR pszProperty,
	// ULONG cbValue, PUCHAR pbValue );
	[DllImport(Lib.Bcrypt, SetLastError = false, ExactSpelling = true, CharSet = CharSet.Unicode)]
	[PInvokeData("bcrypt.h", MSDNShortId = "1e02720b-5210-4127-ab9e-24532a764795")]
	public static extern NTStatus BCryptSetContextFunctionProperty(ContextConfigTable dwTable, string pszContext, InterfaceId dwInterface, string pszFunction, string pszProperty, uint cbValue, byte[] pbValue);

	/// <summary>The <c>BCryptSetProperty</c> function sets the value of a named property for a CNG object.</summary>
	/// <param name="hObject">A handle that represents the CNG object to set the property value for.</param>
	/// <param name="pszProperty">
	/// A pointer to a null-terminated Unicode string that contains the name of the property to set. This can be one of the predefined
	/// Cryptography Primitive Property Identifiers or a custom property identifier.
	/// </param>
	/// <param name="pbInput">
	/// The address of a buffer that contains the new property value. The cbInput parameter contains the size of this buffer.
	/// </param>
	/// <param name="cbInput">The size, in bytes, of the pbInput buffer.</param>
	/// <param name="dwFlags">A set of flags that modify the behavior of this function. No flags are defined for this function.</param>
	/// <returns>
	/// <para>Returns a status code that indicates the success or failure of the function.</para>
	/// <para>Possible return codes include, but are not limited to, the following.</para>
	/// <list type="table">
	/// <listheader>
	/// <term>Return code</term>
	/// <term>Description</term>
	/// </listheader>
	/// <item>
	/// <term>STATUS_SUCCESS</term>
	/// <term>The function was successful.</term>
	/// </item>
	/// <item>
	/// <term>STATUS_INVALID_HANDLE</term>
	/// <term>The handle in the hObject parameter is not valid.</term>
	/// </item>
	/// <item>
	/// <term>STATUS_INVALID_PARAMETER</term>
	/// <term>One or more parameters are not valid.</term>
	/// </item>
	/// <item>
	/// <term>STATUS_NOT_SUPPORTED</term>
	/// <term>The named property specified by the pszProperty parameter is not supported or is read-only.</term>
	/// </item>
	/// </list>
	/// </returns>
	/// <remarks>
	/// <para>
	/// Depending on what processor modes a provider supports, <c>BCryptSetProperty</c> can be called either from user mode or kernel
	/// mode. Kernel mode callers can execute either at <c>PASSIVE_LEVEL</c> IRQL or <c>DISPATCH_LEVEL</c> IRQL. If the current IRQL
	/// level is <c>DISPATCH_LEVEL</c>, any pointers passed to <c>BCryptSetProperty</c> must refer to nonpaged (or locked) memory. If the
	/// object specified in the hObject parameter is a handle, it must have been opened by using the <c>BCRYPT_PROV_DISPATCH</c> flag.
	/// </para>
	/// <para>
	/// To call this function in kernel mode, use Cng.lib, which is part of the Driver Development Kit (DDK). For more information, see
	/// WDK and Developer Tools. <c>Windows Server 2008 and Windows Vista:</c> To call this function in kernel mode, use Ksecdd.lib.
	/// </para>
	/// </remarks>
	// https://docs.microsoft.com/en-us/windows/desktop/api/bcrypt/nf-bcrypt-bcryptsetproperty NTSTATUS BCryptSetProperty( BCRYPT_HANDLE
	// hObject, LPCWSTR pszProperty, PUCHAR pbInput, ULONG cbInput, ULONG dwFlags );
	[DllImport(Lib.Bcrypt, SetLastError = false, ExactSpelling = true)]
	[PInvokeData("bcrypt.h", MSDNShortId = "687f3410-d28b-4ce2-a2a1-c564f757c668")]
	public static extern NTStatus BCryptSetProperty(BCRYPT_HANDLE hObject, [MarshalAs(UnmanagedType.LPWStr)] string pszProperty, byte[] pbInput, uint cbInput, uint dwFlags = 0);

	/// <summary>The <c>BCryptSetProperty</c> function sets the value of a named property for a CNG object.</summary>
	/// <param name="hObject">A handle that represents the CNG object to set the property value for.</param>
	/// <param name="pszProperty">
	/// A pointer to a null-terminated Unicode string that contains the name of the property to set. This can be one of the predefined
	/// Cryptography Primitive Property Identifiers or a custom property identifier.
	/// </param>
	/// <param name="pbInput">
	/// The address of a buffer that contains the new property value. The cbInput parameter contains the size of this buffer.
	/// </param>
	/// <param name="cbInput">The size, in bytes, of the pbInput buffer.</param>
	/// <param name="dwFlags">A set of flags that modify the behavior of this function. No flags are defined for this function.</param>
	/// <returns>
	/// <para>Returns a status code that indicates the success or failure of the function.</para>
	/// <para>Possible return codes include, but are not limited to, the following.</para>
	/// <list type="table">
	/// <listheader>
	/// <term>Return code</term>
	/// <term>Description</term>
	/// </listheader>
	/// <item>
	/// <term>STATUS_SUCCESS</term>
	/// <term>The function was successful.</term>
	/// </item>
	/// <item>
	/// <term>STATUS_INVALID_HANDLE</term>
	/// <term>The handle in the hObject parameter is not valid.</term>
	/// </item>
	/// <item>
	/// <term>STATUS_INVALID_PARAMETER</term>
	/// <term>One or more parameters are not valid.</term>
	/// </item>
	/// <item>
	/// <term>STATUS_NOT_SUPPORTED</term>
	/// <term>The named property specified by the pszProperty parameter is not supported or is read-only.</term>
	/// </item>
	/// </list>
	/// </returns>
	/// <remarks>
	/// <para>
	/// Depending on what processor modes a provider supports, <c>BCryptSetProperty</c> can be called either from user mode or kernel
	/// mode. Kernel mode callers can execute either at <c>PASSIVE_LEVEL</c> IRQL or <c>DISPATCH_LEVEL</c> IRQL. If the current IRQL
	/// level is <c>DISPATCH_LEVEL</c>, any pointers passed to <c>BCryptSetProperty</c> must refer to nonpaged (or locked) memory. If the
	/// object specified in the hObject parameter is a handle, it must have been opened by using the <c>BCRYPT_PROV_DISPATCH</c> flag.
	/// </para>
	/// <para>
	/// To call this function in kernel mode, use Cng.lib, which is part of the Driver Development Kit (DDK). For more information, see
	/// WDK and Developer Tools. <c>Windows Server 2008 and Windows Vista:</c> To call this function in kernel mode, use Ksecdd.lib.
	/// </para>
	/// </remarks>
	// https://docs.microsoft.com/en-us/windows/desktop/api/bcrypt/nf-bcrypt-bcryptsetproperty NTSTATUS BCryptSetProperty( BCRYPT_HANDLE
	// hObject, LPCWSTR pszProperty, PUCHAR pbInput, ULONG cbInput, ULONG dwFlags );
	[DllImport(Lib.Bcrypt, SetLastError = false, ExactSpelling = true)]
	[PInvokeData("bcrypt.h", MSDNShortId = "687f3410-d28b-4ce2-a2a1-c564f757c668")]
	public static extern NTStatus BCryptSetProperty(BCRYPT_HANDLE hObject, [MarshalAs(UnmanagedType.LPWStr)] string pszProperty, IntPtr pbInput, uint cbInput, uint dwFlags = 0);

	/// <summary>
	/// <para>The <c>BCryptSignHash</c> function creates a signature of a hash value.</para>
	/// </summary>
	/// <param name="hKey">
	/// <para>The handle of the key to use to sign the hash.</para>
	/// </param>
	/// <param name="pPaddingInfo">
	/// <para>
	/// A pointer to a structure that contains padding information. The actual type of structure this parameter points to depends on the
	/// value of the dwFlags parameter. This parameter is only used with asymmetric keys and must be <c>NULL</c> otherwise.
	/// </para>
	/// </param>
	/// <param name="pbInput">
	/// <para>A pointer to a buffer that contains the hash value to sign. The cbInput parameter contains the size of this buffer.</para>
	/// </param>
	/// <param name="cbInput">
	/// <para>The number of bytes in the pbInput buffer to sign.</para>
	/// </param>
	/// <param name="pbOutput">
	/// <para>
	/// The address of a buffer to receive the signature produced by this function. The cbOutput parameter contains the size of this buffer.
	/// </para>
	/// <para>
	/// If this parameter is <c>NULL</c>, this function will calculate the size required for the signature and return the size in the
	/// location pointed to by the pcbResult parameter.
	/// </para>
	/// </param>
	/// <param name="cbOutput">
	/// <para>The size, in bytes, of the pbOutput buffer. This parameter is ignored if the pbOutput parameter is <c>NULL</c>.</para>
	/// </param>
	/// <param name="pcbResult">
	/// <para>A pointer to a <c>ULONG</c> variable that receives the number of bytes copied to the pbOutput buffer.</para>
	/// <para>If pbOutput is <c>NULL</c>, this receives the size, in bytes, required for the signature.</para>
	/// </param>
	/// <param name="dwFlags">
	/// <para>
	/// A set of flags that modify the behavior of this function. The allowed set of flags depends on the type of key specified by the
	/// hKey parameter.
	/// </para>
	/// <para>This can be one of the following values.</para>
	/// <list type="table">
	/// <listheader>
	/// <term>Value</term>
	/// <term>Meaning</term>
	/// </listheader>
	/// <item>
	/// <term>BCRYPT_PAD_PKCS1</term>
	/// <term>Use the PKCS1 padding scheme. The pPaddingInfo parameter is a pointer to a BCRYPT_PKCS1_PADDING_INFO structure.</term>
	/// </item>
	/// <item>
	/// <term>BCRYPT_PAD_PSS</term>
	/// <term>
	/// Use the Probabilistic Signature Scheme (PSS) padding scheme. The pPaddingInfo parameter is a pointer to a BCRYPT_PSS_PADDING_INFO structure.
	/// </term>
	/// </item>
	/// </list>
	/// </param>
	/// <returns>
	/// <para>Returns a status code that indicates the success or failure of the function.</para>
	/// <para>Possible return codes include, but are not limited to, the following.</para>
	/// <list type="table">
	/// <listheader>
	/// <term>Return code</term>
	/// <term>Description</term>
	/// </listheader>
	/// <item>
	/// <term>STATUS_SUCCESS</term>
	/// <term>The function was successful.</term>
	/// </item>
	/// <item>
	/// <term>STATUS_INVALID_HANDLE</term>
	/// <term>The key handle specified by the hKey parameter is not valid.</term>
	/// </item>
	/// <item>
	/// <term>STATUS_NOT_SUPPORTED</term>
	/// <term>The algorithm provider used to create the key handle specified by the hKey parameter is not a signing algorithm.</term>
	/// </item>
	/// <item>
	/// <term>STATUS_NO_MEMORY</term>
	/// <term>A memory allocation failure occurred.</term>
	/// </item>
	/// <item>
	/// <term>STATUS_BUFFER_TOO_SMALL</term>
	/// <term>The memory size specified by the cbOutput parameter is not large enough to hold the signature.</term>
	/// </item>
	/// </list>
	/// </returns>
	/// <remarks>
	/// <para>This function will encrypt the hash value with the specified key to create the signature.</para>
	/// <para>
	/// To later verify that the signature is valid, call the BCryptVerifySignature function with an identical key and an identical hash
	/// of the original data.
	/// </para>
	/// <para>
	/// Depending on what processor modes a provider supports, <c>BCryptSignHash</c> can be called either from user mode or kernel mode.
	/// Kernel mode callers can execute either at <c>PASSIVE_LEVEL</c> IRQL or <c>DISPATCH_LEVEL</c> IRQL. If the current IRQL level is
	/// <c>DISPATCH_LEVEL</c>, the handle provided in the hKey parameter must be derived from an algorithm handle returned by a provider
	/// that was opened with the <c>BCRYPT_PROV_DISPATCH</c> flag, and any pointers passed to the <c>BCryptSignHash</c> function must
	/// refer to nonpaged (or locked) memory.
	/// </para>
	/// <para>
	/// To call this function in kernel mode, use Cng.lib, which is part of the Driver Development Kit (DDK). For more information, see
	/// WDK and Developer Tools. <c>Windows Server 2008 and Windows Vista:</c> To call this function in kernel mode, use Ksecdd.lib.
	/// </para>
	/// </remarks>
	// https://docs.microsoft.com/en-us/windows/desktop/api/bcrypt/nf-bcrypt-bcryptsignhash NTSTATUS BCryptSignHash( BCRYPT_KEY_HANDLE
	// hKey, VOID *pPaddingInfo, PUCHAR pbInput, ULONG cbInput, PUCHAR pbOutput, ULONG cbOutput, ULONG *pcbResult, ULONG dwFlags );
	[DllImport(Lib.Bcrypt, SetLastError = false, ExactSpelling = true)]
	[PInvokeData("bcrypt.h", MSDNShortId = "f402ea9e-89ae-4ccc-9591-aa2328287c0e")]
	public static extern NTStatus BCryptSignHash(BCRYPT_KEY_HANDLE hKey, [Optional] IntPtr pPaddingInfo, SafeAllocatedMemoryHandle pbInput,
		uint cbInput, SafeAllocatedMemoryHandle pbOutput, uint cbOutput, out uint pcbResult, EncryptFlags dwFlags);

	/// <summary>
	/// <para>The <c>BCryptSignHash</c> function creates a signature of a hash value.</para>
	/// </summary>
	/// <param name="hKey">
	/// <para>The handle of the key to use to sign the hash.</para>
	/// </param>
	/// <param name="pPaddingInfo">
	/// <para>
	/// A pointer to a structure that contains padding information. The actual type of structure this parameter points to depends on the
	/// value of the dwFlags parameter. This parameter is only used with asymmetric keys and must be <c>NULL</c> otherwise.
	/// </para>
	/// </param>
	/// <param name="pbInput">
	/// <para>A pointer to a buffer that contains the hash value to sign. The cbInput parameter contains the size of this buffer.</para>
	/// </param>
	/// <param name="cbInput">
	/// <para>The number of bytes in the pbInput buffer to sign.</para>
	/// </param>
	/// <param name="pbOutput">
	/// <para>
	/// The address of a buffer to receive the signature produced by this function. The cbOutput parameter contains the size of this buffer.
	/// </para>
	/// <para>
	/// If this parameter is <c>NULL</c>, this function will calculate the size required for the signature and return the size in the
	/// location pointed to by the pcbResult parameter.
	/// </para>
	/// </param>
	/// <param name="cbOutput">
	/// <para>The size, in bytes, of the pbOutput buffer. This parameter is ignored if the pbOutput parameter is <c>NULL</c>.</para>
	/// </param>
	/// <param name="pcbResult">
	/// <para>A pointer to a <c>ULONG</c> variable that receives the number of bytes copied to the pbOutput buffer.</para>
	/// <para>If pbOutput is <c>NULL</c>, this receives the size, in bytes, required for the signature.</para>
	/// </param>
	/// <param name="dwFlags">
	/// <para>
	/// A set of flags that modify the behavior of this function. The allowed set of flags depends on the type of key specified by the
	/// hKey parameter.
	/// </para>
	/// <para>This can be one of the following values.</para>
	/// <list type="table">
	/// <listheader>
	/// <term>Value</term>
	/// <term>Meaning</term>
	/// </listheader>
	/// <item>
	/// <term>BCRYPT_PAD_PKCS1</term>
	/// <term>Use the PKCS1 padding scheme. The pPaddingInfo parameter is a pointer to a BCRYPT_PKCS1_PADDING_INFO structure.</term>
	/// </item>
	/// <item>
	/// <term>BCRYPT_PAD_PSS</term>
	/// <term>
	/// Use the Probabilistic Signature Scheme (PSS) padding scheme. The pPaddingInfo parameter is a pointer to a BCRYPT_PSS_PADDING_INFO structure.
	/// </term>
	/// </item>
	/// </list>
	/// </param>
	/// <returns>
	/// <para>Returns a status code that indicates the success or failure of the function.</para>
	/// <para>Possible return codes include, but are not limited to, the following.</para>
	/// <list type="table">
	/// <listheader>
	/// <term>Return code</term>
	/// <term>Description</term>
	/// </listheader>
	/// <item>
	/// <term>STATUS_SUCCESS</term>
	/// <term>The function was successful.</term>
	/// </item>
	/// <item>
	/// <term>STATUS_INVALID_HANDLE</term>
	/// <term>The key handle specified by the hKey parameter is not valid.</term>
	/// </item>
	/// <item>
	/// <term>STATUS_NOT_SUPPORTED</term>
	/// <term>The algorithm provider used to create the key handle specified by the hKey parameter is not a signing algorithm.</term>
	/// </item>
	/// <item>
	/// <term>STATUS_NO_MEMORY</term>
	/// <term>A memory allocation failure occurred.</term>
	/// </item>
	/// <item>
	/// <term>STATUS_BUFFER_TOO_SMALL</term>
	/// <term>The memory size specified by the cbOutput parameter is not large enough to hold the signature.</term>
	/// </item>
	/// </list>
	/// </returns>
	/// <remarks>
	/// <para>This function will encrypt the hash value with the specified key to create the signature.</para>
	/// <para>
	/// To later verify that the signature is valid, call the BCryptVerifySignature function with an identical key and an identical hash
	/// of the original data.
	/// </para>
	/// <para>
	/// Depending on what processor modes a provider supports, <c>BCryptSignHash</c> can be called either from user mode or kernel mode.
	/// Kernel mode callers can execute either at <c>PASSIVE_LEVEL</c> IRQL or <c>DISPATCH_LEVEL</c> IRQL. If the current IRQL level is
	/// <c>DISPATCH_LEVEL</c>, the handle provided in the hKey parameter must be derived from an algorithm handle returned by a provider
	/// that was opened with the <c>BCRYPT_PROV_DISPATCH</c> flag, and any pointers passed to the <c>BCryptSignHash</c> function must
	/// refer to nonpaged (or locked) memory.
	/// </para>
	/// <para>
	/// To call this function in kernel mode, use Cng.lib, which is part of the Driver Development Kit (DDK). For more information, see
	/// WDK and Developer Tools. <c>Windows Server 2008 and Windows Vista:</c> To call this function in kernel mode, use Ksecdd.lib.
	/// </para>
	/// </remarks>
	// https://docs.microsoft.com/en-us/windows/desktop/api/bcrypt/nf-bcrypt-bcryptsignhash NTSTATUS BCryptSignHash( BCRYPT_KEY_HANDLE
	// hKey, VOID *pPaddingInfo, PUCHAR pbInput, ULONG cbInput, PUCHAR pbOutput, ULONG cbOutput, ULONG *pcbResult, ULONG dwFlags );
	[DllImport(Lib.Bcrypt, SetLastError = false, ExactSpelling = true)]
	[PInvokeData("bcrypt.h", MSDNShortId = "f402ea9e-89ae-4ccc-9591-aa2328287c0e")]
	public static extern NTStatus BCryptSignHash(BCRYPT_KEY_HANDLE hKey, [Optional] IntPtr pPaddingInfo, SafeAllocatedMemoryHandle pbInput,
		uint cbInput, [Optional] IntPtr pbOutput, uint cbOutput, out uint pcbResult, EncryptFlags dwFlags);

	/// <summary>
	/// The <c>BCryptUnregisterConfigChangeNotify(PRKEVENT)</c> function removes a kernel mode CNG configuration change event handler
	/// that was created by using the <c>BCryptRegisterConfigChangeNotify(PRKEVENT)</c> function.
	/// </summary>
	/// <param name="hEvent">
	/// The pointer to the event dispatcher object to remove. This is the pointer that was obtained by using the
	/// <c>BCryptRegisterConfigChangeNotify(PRKEVENT)</c> function.
	/// </param>
	/// <returns>
	/// <para>Returns a status code that indicates the success or failure of the function.</para>
	/// <para>Possible return codes include, but are not limited to, the following.</para>
	/// <para>
	/// <list type="table">
	/// <listheader>
	/// <term>Return code</term>
	/// <term>Description</term>
	/// </listheader>
	/// <item>
	/// <term>STATUS_SUCCESS</term>
	/// <term>The function was successful.</term>
	/// </item>
	/// <item>
	/// <term>STATUS_INVALID_PARAMETER</term>
	/// <term>The hEvent parameter is not valid.</term>
	/// </item>
	/// <item>
	/// <term>STATUS_NO_MEMORY</term>
	/// <term>A memory allocation failure occurred.</term>
	/// </item>
	/// </list>
	/// </para>
	/// </returns>
	// NTSTATUS WINAPI BCryptUnregisterConfigChangeNotify( _In_ PRKEVENT hEvent); https://msdn.microsoft.com/en-us/library/windows/desktop/bb394683(v=vs.85).aspx
	[DllImport(Lib.Bcrypt, SetLastError = false, ExactSpelling = true)]
	[PInvokeData("Bcrypt.h", MSDNShortId = "bb394683")]
	public static extern NTStatus BCryptUnregisterConfigChangeNotify(IntPtr hEvent);

	/// <summary>
	/// <para>The <c>BCryptVerifySignature</c> function verifies that the specified signature matches the specified hash.</para>
	/// </summary>
	/// <param name="hKey">
	/// <para>
	/// The handle of the key to use to decrypt the signature. This must be an identical key or the public key portion of the key pair
	/// used to sign the data with the BCryptSignHash function.
	/// </para>
	/// </param>
	/// <param name="pPaddingInfo">
	/// <para>
	/// A pointer to a structure that contains padding information. The actual type of structure this parameter points to depends on the
	/// value of the dwFlags parameter. This parameter is only used with asymmetric keys and must be <c>NULL</c> otherwise.
	/// </para>
	/// </param>
	/// <param name="pbHash">
	/// <para>The address of a buffer that contains the hash of the data. The cbHash parameter contains the size of this buffer.</para>
	/// </param>
	/// <param name="cbHash">
	/// <para>The size, in bytes, of the pbHash buffer.</para>
	/// </param>
	/// <param name="pbSignature">
	/// <para>
	/// The address of a buffer that contains the signed hash of the data. The BCryptSignHash function is used to create the signature.
	/// The cbSignature parameter contains the size of this buffer.
	/// </para>
	/// </param>
	/// <param name="cbSignature">
	/// <para>The size, in bytes, of the pbSignature buffer. The BCryptSignHash function is used to create the signature.</para>
	/// </param>
	/// <param name="dwFlags">
	/// <para>
	/// A set of flags that modify the behavior of this function. The allowed set of flags depends on the type of key specified by the
	/// hKey parameter.
	/// </para>
	/// <para>If the key is a symmetric key, this parameter is not used and should be zero.</para>
	/// <para>If the key is an asymmetric key, this can be one of the following values.</para>
	/// <list type="table">
	/// <listheader>
	/// <term>Value</term>
	/// <term>Meaning</term>
	/// </listheader>
	/// <item>
	/// <term>BCRYPT_PAD_PKCS1</term>
	/// <term>
	/// The PKCS1 padding scheme was used when the signature was created. The pPaddingInfo parameter is a pointer to a
	/// BCRYPT_PKCS1_PADDING_INFO structure.
	/// </term>
	/// </item>
	/// <item>
	/// <term>BCRYPT_PAD_PSS</term>
	/// <term>
	/// The Probabilistic Signature Scheme (PSS) padding scheme was used when the signature was created. The pPaddingInfo parameter is a
	/// pointer to a BCRYPT_PSS_PADDING_INFO structure.
	/// </term>
	/// </item>
	/// </list>
	/// </param>
	/// <returns>
	/// <para>Returns a status code that indicates the success or failure of the function.</para>
	/// <para>Possible return codes include, but are not limited to, the following.</para>
	/// <list type="table">
	/// <listheader>
	/// <term>Return code</term>
	/// <term>Description</term>
	/// </listheader>
	/// <item>
	/// <term>STATUS_SUCCESS</term>
	/// <term>The function was successful.</term>
	/// </item>
	/// <item>
	/// <term>STATUS_INVALID_SIGNATURE</term>
	/// <term>The signature was not verified.</term>
	/// </item>
	/// <item>
	/// <term>NTE_NO_MEMORY</term>
	/// <term>A memory allocation failure occurred.</term>
	/// </item>
	/// <item>
	/// <term>STATUS_INVALID_HANDLE</term>
	/// <term>The key handle specified by the hKey parameter is not valid.</term>
	/// </item>
	/// <item>
	/// <term>STATUS_NOT_SUPPORTED</term>
	/// <term>The algorithm provider used to create the key handle specified by the hKey parameter is not a signing algorithm.</term>
	/// </item>
	/// </list>
	/// </returns>
	/// <remarks>
	/// <para>
	/// This function decrypts the signature with the provided key and then compares the decrypted value to the specified hash value.
	/// </para>
	/// <para>
	/// To use this function, you must hash the data by using the same hashing algorithm that was used to create the hash value that was
	/// signed. If applicable, you must also specify the same padding scheme that was specified when the signature was created.
	/// </para>
	/// <para>
	/// Depending on what processor modes a provider supports, <c>BCryptVerifySignature</c> can be called either from user mode or kernel
	/// mode. Kernel mode callers can execute either at <c>PASSIVE_LEVEL</c> IRQL or <c>DISPATCH_LEVEL</c> IRQL. If the current IRQL
	/// level is <c>DISPATCH_LEVEL</c>, the handle provided in the hKey parameter must be derived from an algorithm handle returned by a
	/// provider that was opened by using the <c>BCRYPT_PROV_DISPATCH</c> flag, and any pointers passed to the
	/// <c>BCryptVerifySignature</c> function must refer to nonpaged (or locked) memory.
	/// </para>
	/// <para>
	/// To call this function in kernel mode, use Cng.lib, which is part of the Driver Development Kit (DDK). For more information, see
	/// WDK and Developer Tools. <c>Windows Server 2008 and Windows Vista:</c> To call this function in kernel mode, use Ksecdd.lib.
	/// </para>
	/// </remarks>
	// https://docs.microsoft.com/en-us/windows/desktop/api/bcrypt/nf-bcrypt-bcryptverifysignature NTSTATUS BCryptVerifySignature(
	// BCRYPT_KEY_HANDLE hKey, VOID *pPaddingInfo, PUCHAR pbHash, ULONG cbHash, PUCHAR pbSignature, ULONG cbSignature, ULONG dwFlags );
	[DllImport(Lib.Bcrypt, SetLastError = false, ExactSpelling = true)]
	[PInvokeData("bcrypt.h", MSDNShortId = "95c32056-e444-441c-bbc1-c5ae82aba964")]
	public static extern NTStatus BCryptVerifySignature(BCRYPT_KEY_HANDLE hKey, [Optional] IntPtr pPaddingInfo, SafeAllocatedMemoryHandle pbHash,
		uint cbHash, SafeAllocatedMemoryHandle pbSignature, uint cbSignature, EncryptFlags dwFlags);

	/// <summary>Provides a handle to an algorithm provider.</summary>
	[StructLayout(LayoutKind.Sequential)]
	public readonly struct BCRYPT_ALG_HANDLE : IHandle
	{
		private readonly IntPtr handle;

		/// <summary>Initializes a new instance of the <see cref="BCRYPT_ALG_HANDLE"/> struct.</summary>
		/// <param name="preexistingHandle">An <see cref="IntPtr"/> object that represents the pre-existing handle to use.</param>
		public BCRYPT_ALG_HANDLE(IntPtr preexistingHandle) => handle = preexistingHandle;

		/// <summary>Returns an invalid handle by instantiating a <see cref="BCRYPT_ALG_HANDLE"/> object with <see cref="IntPtr.Zero"/>.</summary>
		public static BCRYPT_ALG_HANDLE NULL => new(IntPtr.Zero);

		/// <summary>Gets a value indicating whether this instance is a null handle.</summary>
		public bool IsNull => handle == IntPtr.Zero;

		/// <summary>Performs an explicit conversion from <see cref="BCRYPT_ALG_HANDLE"/> to <see cref="IntPtr"/>.</summary>
		/// <param name="h">The handle.</param>
		/// <returns>The result of the conversion.</returns>
		public static explicit operator IntPtr(BCRYPT_ALG_HANDLE h) => h.handle;

		/// <summary>Performs an implicit conversion from <see cref="IntPtr"/> to <see cref="BCRYPT_ALG_HANDLE"/>.</summary>
		/// <param name="h">The pointer to a handle.</param>
		/// <returns>The result of the conversion.</returns>
		public static implicit operator BCRYPT_ALG_HANDLE(IntPtr h) => new(h);

		/// <summary>Implements the operator !=.</summary>
		/// <param name="h1">The first handle.</param>
		/// <param name="h2">The second handle.</param>
		/// <returns>The result of the operator.</returns>
		public static bool operator !=(BCRYPT_ALG_HANDLE h1, BCRYPT_ALG_HANDLE h2) => !(h1 == h2);

		/// <summary>Implements the operator ==.</summary>
		/// <param name="h1">The first handle.</param>
		/// <param name="h2">The second handle.</param>
		/// <returns>The result of the operator.</returns>
		public static bool operator ==(BCRYPT_ALG_HANDLE h1, BCRYPT_ALG_HANDLE h2) => h1.Equals(h2);

		/// <inheritdoc/>
		public override bool Equals(object? obj) => obj is BCRYPT_ALG_HANDLE h && handle == h.handle;

		/// <inheritdoc/>
		public override int GetHashCode() => handle.GetHashCode();

		/// <inheritdoc/>
		public IntPtr DangerousGetHandle() => handle;
	}

	/// <summary>
	/// <para>
	/// The <c>BCRYPT_ALGORITHM_IDENTIFIER</c> structure is used with the BCryptEnumAlgorithms function to contain a cryptographic
	/// algorithm identifier.
	/// </para>
	/// </summary>
	// https://docs.microsoft.com/en-us/windows/desktop/api/bcrypt/ns-bcrypt-_bcrypt_algorithm_identifier typedef struct
	// _BCRYPT_ALGORITHM_IDENTIFIER { LPWSTR pszName; ULONG dwClass; ULONG dwFlags; } BCRYPT_ALGORITHM_IDENTIFIER;
	[PInvokeData("bcrypt.h", MSDNShortId = "a49a21c9-5668-4709-b52a-f6cacd944845")]
	[StructLayout(LayoutKind.Sequential, CharSet = CharSet.Unicode)]
	public struct BCRYPT_ALGORITHM_IDENTIFIER
	{
		/// <summary>
		/// <para>
		/// A pointer to a null-terminated Unicode string that contains the string identifier of the algorithm. The CNG Algorithm
		/// Identifiers topic contains the predefined algorithm identifiers.
		/// </para>
		/// </summary>
		public string pszName;

		/// <summary>
		/// <para>Specifies the class of the algorithm. This can be one of the CNG Interface Identifiers.</para>
		/// </summary>
		public InterfaceId dwClass;

		/// <summary>
		/// <para>A set of flags that specify other information about the algorithm. There are currently no flags defined for this member.</para>
		/// </summary>
		public uint dwFlags;
	}

	/// <summary>Provides a handle to a CNG object.</summary>
	[StructLayout(LayoutKind.Sequential)]
	public readonly struct BCRYPT_HANDLE : IHandle
	{
		private readonly IntPtr handle;

		/// <summary>Initializes a new instance of the <see cref="BCRYPT_HANDLE"/> struct.</summary>
		/// <param name="preexistingHandle">An <see cref="IntPtr"/> object that represents the pre-existing handle to use.</param>
		public BCRYPT_HANDLE(IntPtr preexistingHandle) => handle = preexistingHandle;

		/// <summary>Returns an invalid handle by instantiating a <see cref="BCRYPT_HANDLE"/> object with <see cref="IntPtr.Zero"/>.</summary>
		public static BCRYPT_HANDLE NULL => new(IntPtr.Zero);

		/// <summary>Gets a value indicating whether this instance is a null handle.</summary>
		public bool IsNull => handle == IntPtr.Zero;

		/// <summary>Performs an explicit conversion from <see cref="BCRYPT_HANDLE"/> to <see cref="IntPtr"/>.</summary>
		/// <param name="h">The handle.</param>
		/// <returns>The result of the conversion.</returns>
		public static explicit operator IntPtr(BCRYPT_HANDLE h) => h.handle;

		/// <summary>Performs an implicit conversion from <see cref="IntPtr"/> to <see cref="BCRYPT_HANDLE"/>.</summary>
		/// <param name="h">The pointer to a handle.</param>
		/// <returns>The result of the conversion.</returns>
		public static implicit operator BCRYPT_HANDLE(IntPtr h) => new(h);

		/// <summary>Implements the operator !=.</summary>
		/// <param name="h1">The first handle.</param>
		/// <param name="h2">The second handle.</param>
		/// <returns>The result of the operator.</returns>
		public static bool operator !=(BCRYPT_HANDLE h1, BCRYPT_HANDLE h2) => !(h1 == h2);

		/// <summary>Implements the operator ==.</summary>
		/// <param name="h1">The first handle.</param>
		/// <param name="h2">The second handle.</param>
		/// <returns>The result of the operator.</returns>
		public static bool operator ==(BCRYPT_HANDLE h1, BCRYPT_HANDLE h2) => h1.Equals(h2);

		/// <inheritdoc/>
		public override bool Equals(object? obj) => obj is BCRYPT_HANDLE h && handle == h.handle;

		/// <inheritdoc/>
		public override int GetHashCode() => handle.GetHashCode();

		/// <inheritdoc/>
		public IntPtr DangerousGetHandle() => handle;
	}

	/// <summary>Provides a handle to a multi-hash state.</summary>
	[StructLayout(LayoutKind.Sequential)]
	public readonly struct BCRYPT_HASH_HANDLE : IHandle
	{
		private readonly IntPtr handle;

		/// <summary>Initializes a new instance of the <see cref="BCRYPT_HASH_HANDLE"/> struct.</summary>
		/// <param name="preexistingHandle">An <see cref="IntPtr"/> object that represents the pre-existing handle to use.</param>
		public BCRYPT_HASH_HANDLE(IntPtr preexistingHandle) => handle = preexistingHandle;

		/// <summary>Returns an invalid handle by instantiating a <see cref="BCRYPT_HASH_HANDLE"/> object with <see cref="IntPtr.Zero"/>.</summary>
		public static BCRYPT_HASH_HANDLE NULL => new(IntPtr.Zero);

		/// <summary>Gets a value indicating whether this instance is a null handle.</summary>
		public bool IsNull => handle == IntPtr.Zero;

		/// <summary>Performs an explicit conversion from <see cref="BCRYPT_HASH_HANDLE"/> to <see cref="IntPtr"/>.</summary>
		/// <param name="h">The handle.</param>
		/// <returns>The result of the conversion.</returns>
		public static explicit operator IntPtr(BCRYPT_HASH_HANDLE h) => h.handle;

		/// <summary>Performs an implicit conversion from <see cref="IntPtr"/> to <see cref="BCRYPT_HASH_HANDLE"/>.</summary>
		/// <param name="h">The pointer to a handle.</param>
		/// <returns>The result of the conversion.</returns>
		public static implicit operator BCRYPT_HASH_HANDLE(IntPtr h) => new(h);

		/// <summary>Implements the operator !=.</summary>
		/// <param name="h1">The first handle.</param>
		/// <param name="h2">The second handle.</param>
		/// <returns>The result of the operator.</returns>
		public static bool operator !=(BCRYPT_HASH_HANDLE h1, BCRYPT_HASH_HANDLE h2) => !(h1 == h2);

		/// <summary>Implements the operator ==.</summary>
		/// <param name="h1">The first handle.</param>
		/// <param name="h2">The second handle.</param>
		/// <returns>The result of the operator.</returns>
		public static bool operator ==(BCRYPT_HASH_HANDLE h1, BCRYPT_HASH_HANDLE h2) => h1.Equals(h2);

		/// <inheritdoc/>
		public override bool Equals(object? obj) => obj is BCRYPT_HASH_HANDLE h && handle == h.handle;

		/// <inheritdoc/>
		public override int GetHashCode() => handle.GetHashCode();

		/// <inheritdoc/>
		public IntPtr DangerousGetHandle() => handle;
	}

	/// <summary>Provides a handle to a key pair.</summary>
	[StructLayout(LayoutKind.Sequential)]
	public readonly struct BCRYPT_KEY_HANDLE : IHandle
	{
		private readonly IntPtr handle;

		/// <summary>Initializes a new instance of the <see cref="BCRYPT_KEY_HANDLE"/> struct.</summary>
		/// <param name="preexistingHandle">An <see cref="IntPtr"/> object that represents the pre-existing handle to use.</param>
		public BCRYPT_KEY_HANDLE(IntPtr preexistingHandle) => handle = preexistingHandle;

		/// <summary>Returns an invalid handle by instantiating a <see cref="BCRYPT_KEY_HANDLE"/> object with <see cref="IntPtr.Zero"/>.</summary>
		public static BCRYPT_KEY_HANDLE NULL => new(IntPtr.Zero);

		/// <summary>Gets a value indicating whether this instance is a null handle.</summary>
		public bool IsNull => handle == IntPtr.Zero;

		/// <summary>Performs an explicit conversion from <see cref="BCRYPT_KEY_HANDLE"/> to <see cref="IntPtr"/>.</summary>
		/// <param name="h">The handle.</param>
		/// <returns>The result of the conversion.</returns>
		public static explicit operator IntPtr(BCRYPT_KEY_HANDLE h) => h.handle;

		/// <summary>Performs an implicit conversion from <see cref="IntPtr"/> to <see cref="BCRYPT_KEY_HANDLE"/>.</summary>
		/// <param name="h">The pointer to a handle.</param>
		/// <returns>The result of the conversion.</returns>
		public static implicit operator BCRYPT_KEY_HANDLE(IntPtr h) => new(h);

		/// <summary>Implements the operator !=.</summary>
		/// <param name="h1">The first handle.</param>
		/// <param name="h2">The second handle.</param>
		/// <returns>The result of the operator.</returns>
		public static bool operator !=(BCRYPT_KEY_HANDLE h1, BCRYPT_KEY_HANDLE h2) => !(h1 == h2);

		/// <summary>Implements the operator ==.</summary>
		/// <param name="h1">The first handle.</param>
		/// <param name="h2">The second handle.</param>
		/// <returns>The result of the operator.</returns>
		public static bool operator ==(BCRYPT_KEY_HANDLE h1, BCRYPT_KEY_HANDLE h2) => h1.Equals(h2);

		/// <inheritdoc/>
		public override bool Equals(object? obj) => obj is BCRYPT_KEY_HANDLE h && handle == h.handle;

		/// <inheritdoc/>
		public override int GetHashCode() => handle.GetHashCode();

		/// <inheritdoc/>
		public IntPtr DangerousGetHandle() => handle;
	}

	/// <summary>
	/// <para>
	/// The <c>BCRYPT_KEY_LENGTHS_STRUCT</c> structure defines the range of key sizes that are supported by the provider. This structure
	/// is used with the <c>BCRYPT_KEY_LENGTHS</c> property.
	/// </para>
	/// <para>
	/// This structure is also used with the <c>BCRYPT_AUTH_TAG_LENGTH</c> property to contain the minimum, maximum, and increment size
	/// of an authentication tag.
	/// </para>
	/// </summary>
	/// <remarks>
	/// The key sizes are given in a range that is inclusive of the minimum and maximum values and are separated by the increment. For
	/// example, if the minimum key size is 8 bits, the maximum key size is 16 bits, and the increment is 2 bits, the provider would
	/// support key sizes of 8, 10, 12, 14, and 16 bits.
	/// </remarks>
	// https://docs.microsoft.com/en-us/windows/win32/api/bcrypt/ns-bcrypt-bcrypt_key_lengths_struct
	// typedef struct __BCRYPT_KEY_LENGTHS_STRUCT { ULONG dwMinLength; ULONG dwMaxLength; ULONG dwIncrement; } BCRYPT_KEY_LENGTHS_STRUCT;
	[PInvokeData("bcrypt.h", MSDNShortId = "NS:bcrypt.__BCRYPT_KEY_LENGTHS_STRUCT")]
	[StructLayout(LayoutKind.Sequential)]
	public struct BCRYPT_KEY_LENGTHS_STRUCT
	{
		/// <summary>The minimum length, in bits, of a key.</summary>
		public uint dwMinLength;

		/// <summary>The maximum length, in bits, of a key.</summary>
		public uint dwMaxLength;

		/// <summary>The number of bits that the key size can be incremented between <c>dwMinLength</c> and <c>dwMaxLength</c>.</summary>
		public uint dwIncrement;
	}

	/// <summary>A <c>BCRYPT_MULTI_HASH_OPERATION</c> structure defines a single operation in a multi-hash operation.</summary>
	// https://docs.microsoft.com/en-us/windows/desktop/api/bcrypt/ns-bcrypt-_bcrypt_multi_hash_operation typedef struct
	// _BCRYPT_MULTI_HASH_OPERATION { ULONG iHash; BCRYPT_HASH_OPERATION_TYPE hashOperation; PUCHAR pbBuffer; ULONG cbBuffer; } BCRYPT_MULTI_HASH_OPERATION;
	[PInvokeData("bcrypt.h", MSDNShortId = "B0418A07-D2EE-4346-9971-676C8FB08FAA")]
	[StructLayout(LayoutKind.Sequential, CharSet = CharSet.Auto)]
	public struct BCRYPT_MULTI_HASH_OPERATION
	{
		/// <summary>
		/// An index into the multi-object state array of the hash state on which this computation operates. The first element of the
		/// array corresponds to an iHash value of zero (0). Valid values are less than the value of the nHashes parameter of the
		/// BCryptCreateMultiHash function.
		/// </summary>
		public uint iHash;

		/// <summary>
		/// <para>A hash operation type, either <c>BCRYPT_HASH_OPERATION_HASH_DATA</c> or <c>BCRYPT_HASH_OPERATION_FINISH_HASH</c>.</para>
		/// <para>
		/// If the value is <c>BCRYPT_HASH_OPERATION_HASH_DATA</c>, the operation performed is equivalent to calling the BCryptHashData
		/// function on the hash object array element with pbBuffer/cbBuffer pointing to the buffer to be hashed.
		/// </para>
		/// <para>
		/// If the value is <c>BCRYPT_HASH_OPERATION_FINISH_HASH</c>, the operation performed is equivalent to calling the
		/// BCryptFinishHash function on the hash object array element with pbBuffer/cbBuffer pointing to the output buffer that receives
		/// the result.
		/// </para>
		/// </summary>
		public BCRYPT_HASH_OPERATION_TYPE hashOperation;

		/// <summary>The buffer on which the operation works.</summary>
		public IntPtr pbBuffer;

		/// <summary>The buffer on which the operation works.</summary>
		public uint cbBuffer;
	}

	/// <summary>
	/// The <c>BCRYPT_MULTI_OBJECT_LENGTH_STRUCT</c> structure contains information to determine the size of the pbHashObject buffer for
	/// the BCryptCreateMultiHash function.
	/// </summary>
	/// <remarks>
	/// The size of the pbHashObject buffer for the BCryptCreateMultiHash function is the following:
	/// <code>cbPerObject + (number of hash states) * cbPerElement</code>
	/// .
	/// </remarks>
	// https://docs.microsoft.com/en-us/windows/win32/api/bcrypt/ns-bcrypt-bcrypt_multi_object_length_struct
	// typedef struct _BCRYPT_MULTI_OBJECT_LENGTH_STRUCT { ULONG cbPerObject; ULONG cbPerElement; } BCRYPT_MULTI_OBJECT_LENGTH_STRUCT;
	[PInvokeData("bcrypt.h", MSDNShortId = "NS:bcrypt._BCRYPT_MULTI_OBJECT_LENGTH_STRUCT")]
	[StructLayout(LayoutKind.Sequential)]
	public struct BCRYPT_MULTI_OBJECT_LENGTH_STRUCT
	{
		/// <summary>The number of bytes needed for the object overhead.</summary>
		public uint cbPerObject;

		/// <summary>The number of bytes needed for each element of the object.</summary>
		public uint cbPerElement;
	}

	/// <summary>
	/// The <c>BCRYPT_OAEP_PADDING_INFO</c> structure is used to provide options for the Optimal Asymmetric Encryption Padding (OAEP) scheme.
	/// </summary>
	// https://docs.microsoft.com/en-us/windows/desktop/api/bcrypt/ns-bcrypt-_bcrypt_oaep_padding_info typedef struct
	// _BCRYPT_OAEP_PADDING_INFO { LPCWSTR pszAlgId; PUCHAR pbLabel; ULONG cbLabel; } BCRYPT_OAEP_PADDING_INFO;
	[PInvokeData("bcrypt.h", MSDNShortId = "19f48f2d-e952-4a01-8112-f298c79919b2")]
	[StructLayout(LayoutKind.Sequential, CharSet = CharSet.Unicode)]
	public struct BCRYPT_OAEP_PADDING_INFO
	{
		/// <summary>
		/// A pointer to a null-terminated Unicode string that identifies the cryptographic algorithm to use to create the padding. This
		/// algorithm must be a hashing algorithm.
		/// </summary>
		public string pszAlgId;

		/// <summary>
		/// The address of a buffer that contains the data to use to create the padding. The <c>cbLabel</c> member contains the size of
		/// this buffer.
		/// </summary>
		public IntPtr pbLabel;

		/// <summary>Contains the number of bytes in the <c>pbLabel</c> buffer to use to create the padding.</summary>
		public uint cbLabel;
	}

	/// <summary>
	/// The <c>BCRYPT_OID_LIST</c> structure is used to contain a collection of BCRYPT_OID structures. Use this structure with the
	/// BCRYPT_HASH_OID_LIST property to retrieve the list of hashing object identifiers (OIDs) that have been encoded by using
	/// Distinguished Encoding Rules (DER) encoding.
	/// </summary>
	/// <remarks>
	/// <para>
	/// The first OID in the <c>pOIDs</c> array is used to identify any hashes or signatures created by this algorithm provider. When
	/// verifying a hash or signature, all the OIDs in the array are treated as valid.
	/// </para>
	/// <para>
	/// In the Microsoft Primitive Provider implementation, <c>dwOIDCount</c> is 2, so that the <c>pOIDs</c> array contains two members:
	/// </para>
	/// <list type="bullet">
	/// <item>
	/// <term><c>pOIDs[0]</c> contains a DER-encoded <c>AlgorithmIdentifier</c> with a <c>NULL</c> parameter.</term>
	/// </item>
	/// <item>
	/// <term><c>pOIDs[1]</c> contains the DER-encoded <c>AlgorithmIdentifier</c> without a <c>NULL</c> parameter.</term>
	/// </item>
	/// </list>
	/// <para>For example, the SHA-1 encoding would be:</para>
	/// <list type="bullet">
	/// <item>
	/// <term><c>pOIDs[0]</c> --&gt; 06 05 2b 0e 03 02 1a 05 00</term>
	/// </item>
	/// <item>
	/// <term><c>pOIDs[1]</c> --&gt; 06 05 2b 0e 03 02 1a</term>
	/// </item>
	/// </list>
	/// <para>
	/// The following snippet describes an <c>AlgorithmIdentifier</c> in Abstract Syntax Notation One (ASN.1) notation. <c>SEQUENCE</c>,
	/// <c>OBJECT IDENTIFIER</c>, and <c>ANY</c> are DER encoded. The <c>ANY</c> BLOB is <c>NULL</c>.
	/// </para>
	/// <para>
	/// <code>AlgorithmIdentifier ::= SEQUENCE { algorithm OBJECT IDENTIFIER, algorithmParams ANY }</code>
	/// </para>
	/// </remarks>
	// https://docs.microsoft.com/en-us/windows/win32/api/bcrypt/ns-bcrypt-bcrypt_oid_list
	// typedef struct _BCRYPT_OID_LIST { ULONG dwOIDCount; BCRYPT_OID *pOIDs; } BCRYPT_OID_LIST;
	[PInvokeData("bcrypt.h", MSDNShortId = "NS:bcrypt._BCRYPT_OID_LIST")]
	[StructLayout(LayoutKind.Sequential)]
	public struct BCRYPT_OID_LIST
	{
		/// <summary>The number of elements in the <c>pOIDs</c> array.</summary>
		public uint dwOIDCount;

		/// <summary>The address of an array of BCRYPT_OID structures that contains OIDs.</summary>
		public IntPtr pOIDs;
	}

	/// <summary>The <c>BCRYPT_PKCS1_PADDING_INFO</c> structure is used to provide options for the PKCS #1 padding scheme.</summary>
	// https://docs.microsoft.com/en-us/windows/desktop/api/bcrypt/ns-bcrypt-_bcrypt_pkcs1_padding_info typedef struct
	// _BCRYPT_PKCS1_PADDING_INFO { LPCWSTR pszAlgId; } BCRYPT_PKCS1_PADDING_INFO;
	[PInvokeData("bcrypt.h", MSDNShortId = "920fa461-5b7e-4429-972d-e7c83fb62c64")]
	[StructLayout(LayoutKind.Sequential, CharSet = CharSet.Unicode)]
	public struct BCRYPT_PKCS1_PADDING_INFO
	{
		/// <summary>
		/// A pointer to a null-terminated Unicode string that identifies the cryptographic algorithm to use to create the padding. This
		/// algorithm must be a hashing algorithm. When creating a signature, the object identifier (OID) that corresponds to this
		/// algorithm is added to the <c>DigestInfo</c> element in the signature, and if this member is <c>NULL</c>, then the OID is not
		/// added. When verifying a signature, the verification fails if the OID that corresponds to this member is not the same as the
		/// OID in the signature. If there is no OID in the signature, then verification fails unless this member is <c>NULL</c>.
		/// </summary>
		public string pszAlgId;
	}

	/// <summary>The <c>BCRYPT_PROVIDER_NAME</c> structure contains the name of a CNG provider.</summary>
	// https://docs.microsoft.com/en-us/windows/desktop/api/bcrypt/ns-bcrypt-_bcrypt_provider_name typedef struct _BCRYPT_PROVIDER_NAME {
	// LPWSTR pszProviderName; } BCRYPT_PROVIDER_NAME;
	[PInvokeData("bcrypt.h", MSDNShortId = "0c57aa3f-1d9a-4bb2-b142-bce9c054e658")]
	[StructLayout(LayoutKind.Sequential, CharSet = CharSet.Unicode)]
	public struct BCRYPT_PROVIDER_NAME
	{
		/// <summary>A pointer to a null-terminated Unicode string that contains the name of the provider.</summary>
		public string pszProviderName;
	}

	/// <summary>
	/// The <c>BCRYPT_PSS_PADDING_INFO</c> structure is used to provide options for the Probabilistic Signature Scheme (PSS) padding scheme.
	/// </summary>
	// https://docs.microsoft.com/en-us/windows/desktop/api/bcrypt/ns-bcrypt-_bcrypt_pss_padding_info typedef struct
	// _BCRYPT_PSS_PADDING_INFO { LPCWSTR pszAlgId; ULONG cbSalt; } BCRYPT_PSS_PADDING_INFO;
	[PInvokeData("bcrypt.h", MSDNShortId = "28605b34-b1e1-4460-a8f0-b0fe9f9b94d4")]
	[StructLayout(LayoutKind.Sequential, CharSet = CharSet.Unicode)]
	public struct BCRYPT_PSS_PADDING_INFO
	{
		/// <summary>
		/// A pointer to a null-terminated Unicode string that identifies the cryptographic algorithm to use to create the padding. This
		/// algorithm must be a hashing algorithm.
		/// </summary>
		public string pszAlgId;

		/// <summary>The size, in bytes, of the random salt to use for the padding.</summary>
		public uint cbSalt;
	}

	/// <summary>Provides a handle to a secret agreement.</summary>
	[StructLayout(LayoutKind.Sequential)]
	public readonly struct BCRYPT_SECRET_HANDLE : IHandle
	{
		private readonly IntPtr handle;

		/// <summary>Initializes a new instance of the <see cref="BCRYPT_SECRET_HANDLE"/> struct.</summary>
		/// <param name="preexistingHandle">An <see cref="IntPtr"/> object that represents the pre-existing handle to use.</param>
		public BCRYPT_SECRET_HANDLE(IntPtr preexistingHandle) => handle = preexistingHandle;

		/// <summary>Returns an invalid handle by instantiating a <see cref="BCRYPT_SECRET_HANDLE"/> object with <see cref="IntPtr.Zero"/>.</summary>
		public static BCRYPT_SECRET_HANDLE NULL => new(IntPtr.Zero);

		/// <summary>Gets a value indicating whether this instance is a null handle.</summary>
		public bool IsNull => handle == IntPtr.Zero;

		/// <summary>Performs an explicit conversion from <see cref="BCRYPT_SECRET_HANDLE"/> to <see cref="IntPtr"/>.</summary>
		/// <param name="h">The handle.</param>
		/// <returns>The result of the conversion.</returns>
		public static explicit operator IntPtr(BCRYPT_SECRET_HANDLE h) => h.handle;

		/// <summary>Performs an implicit conversion from <see cref="IntPtr"/> to <see cref="BCRYPT_SECRET_HANDLE"/>.</summary>
		/// <param name="h">The pointer to a handle.</param>
		/// <returns>The result of the conversion.</returns>
		public static implicit operator BCRYPT_SECRET_HANDLE(IntPtr h) => new(h);

		/// <summary>Implements the operator !=.</summary>
		/// <param name="h1">The first handle.</param>
		/// <param name="h2">The second handle.</param>
		/// <returns>The result of the operator.</returns>
		public static bool operator !=(BCRYPT_SECRET_HANDLE h1, BCRYPT_SECRET_HANDLE h2) => !(h1 == h2);

		/// <summary>Implements the operator ==.</summary>
		/// <param name="h1">The first handle.</param>
		/// <param name="h2">The second handle.</param>
		/// <returns>The result of the operator.</returns>
		public static bool operator ==(BCRYPT_SECRET_HANDLE h1, BCRYPT_SECRET_HANDLE h2) => h1.Equals(h2);

		/// <inheritdoc/>
		public override bool Equals(object? obj) => obj is BCRYPT_SECRET_HANDLE h && handle == h.handle;

		/// <inheritdoc/>
		public override int GetHashCode() => handle.GetHashCode();

		/// <inheritdoc/>
		public IntPtr DangerousGetHandle() => handle;
	}

	/// <summary>
	/// <para>The <c>CRYPT_CONTEXT_CONFIG</c> structure contains configuration information for a CNG context.</para>
	/// </summary>
	// https://docs.microsoft.com/en-us/windows/desktop/api/bcrypt/ns-bcrypt-_crypt_context_config typedef struct _CRYPT_CONTEXT_CONFIG {
	// ULONG dwFlags; ULONG dwReserved; } CRYPT_CONTEXT_CONFIG, *PCRYPT_CONTEXT_CONFIG;
	[PInvokeData("bcrypt.h", MSDNShortId = "3e07b7ae-84ef-4b77-bd49-d96906eaa4f8")]
	[StructLayout(LayoutKind.Sequential)]
	public struct CRYPT_CONTEXT_CONFIG
	{
		/// <summary>
		/// <para>
		/// A set of flags that determine the options for the configuration context. This can be zero or a combination of one or more of
		/// the following values.
		/// </para>
		/// <list type="table">
		/// <listheader>
		/// <term>Value</term>
		/// <term>Meaning</term>
		/// </listheader>
		/// <item>
		/// <term>CRYPT_EXCLUSIVE</term>
		/// <term>
		/// Restricts the set of cryptographic functions in an interface to those that the current CNG context is specifically registered
		/// to support. If this flag is set, then any attempts to resolve a given function will succeed only if one of the following is true:
		/// </term>
		/// </item>
		/// <item>
		/// <term>CRYPT_OVERRIDE</term>
		/// <term>
		/// Indicates that this entry in the enterprise-wide configuration table should take precedence over any and all corresponding
		/// entries in the local-machine configuration table for this context. This flag only applies to entries in the enterprise-wide
		/// configuration table. Without this flag, local machine configuration entries take precedence.
		/// </term>
		/// </item>
		/// </list>
		/// </summary>
		public ContextConfigFlags dwFlags;

		/// <summary/>
		public uint dwReserved;
	}

	/// <summary>
	/// <para>
	/// The <c>CRYPT_CONTEXT_FUNCTION_CONFIG</c> structure contains configuration information for a cryptographic function of a CNG context.
	/// </para>
	/// </summary>
	// https://docs.microsoft.com/en-us/windows/desktop/api/bcrypt/ns-bcrypt-_crypt_context_function_config typedef struct
	// _CRYPT_CONTEXT_FUNCTION_CONFIG { ULONG dwFlags; ULONG dwReserved; } CRYPT_CONTEXT_FUNCTION_CONFIG, *PCRYPT_CONTEXT_FUNCTION_CONFIG;
	[PInvokeData("bcrypt.h", MSDNShortId = "53026095-c871-4027-ac7d-428f1cb4aafe")]
	[StructLayout(LayoutKind.Sequential)]
	public struct CRYPT_CONTEXT_FUNCTION_CONFIG
	{
		/// <summary>
		/// <para>
		/// A set of flags that determine the options for the context function configuration. This can be zero or the following value.
		/// </para>
		/// <list type="table">
		/// <listheader>
		/// <term>Value</term>
		/// <term>Meaning</term>
		/// </listheader>
		/// <item>
		/// <term>CRYPT_EXCLUSIVE</term>
		/// <term>
		/// Restricts the set of usable providers for this function to only those that this function is specifically registered to support.
		/// </term>
		/// </item>
		/// </list>
		/// </summary>
		public ContextConfigFlags dwFlags;

		/// <summary/>
		public uint dwReserved;
	}

	/// <summary>
	/// The <c>CRYPT_CONTEXT_FUNCTION_PROVIDERS</c> structure contains a set of cryptographic function providers for a CNG configuration context.
	/// </summary>
	// https://docs.microsoft.com/en-us/windows/desktop/api/bcrypt/ns-bcrypt-_crypt_context_function_providers typedef struct
	// _CRYPT_CONTEXT_FUNCTION_PROVIDERS { ULONG cProviders; PWSTR *rgpszProviders; } CRYPT_CONTEXT_FUNCTION_PROVIDERS, *PCRYPT_CONTEXT_FUNCTION_PROVIDERS;
	[PInvokeData("bcrypt.h", MSDNShortId = "5e175ac2-38eb-44c4-a01a-fb436e833546")]
	[StructLayout(LayoutKind.Sequential, CharSet = CharSet.Unicode)]
	public struct CRYPT_CONTEXT_FUNCTION_PROVIDERS
	{
		/// <summary>The number of elements in the <c>rgpszProviders</c> array.</summary>
		public uint cProviders;

		/// <summary>
		/// An array of pointers to null-terminated Unicode strings that contain the identifiers of the function providers contained in
		/// this set. The <c>cProviders</c> member contains the number of elements in this array.
		/// </summary>
		public IntPtr rgpszProviders;

		internal IEnumerable<string?> _rgpszProviders => rgpszProviders.ToStringEnum((int)cProviders, CharSet.Unicode);
	}

	/// <summary>
	/// <para>The <c>CRYPT_CONTEXT_FUNCTIONS</c> structure contains a set of cryptographic functions for a CNG configuration context.</para>
	/// </summary>
	// https://docs.microsoft.com/en-us/windows/desktop/api/bcrypt/ns-bcrypt-_crypt_context_functions typedef struct
	// _CRYPT_CONTEXT_FUNCTIONS { ULONG cFunctions; PWSTR *rgpszFunctions; } CRYPT_CONTEXT_FUNCTIONS, *PCRYPT_CONTEXT_FUNCTIONS;
	[PInvokeData("bcrypt.h", MSDNShortId = "c576f39c-a03a-47aa-90b7-500736070c6f")]
	[StructLayout(LayoutKind.Sequential, CharSet = CharSet.Unicode)]
	public struct CRYPT_CONTEXT_FUNCTIONS
	{
		/// <summary>
		/// <para>The number of elements in the <c>rgpszFunctions</c> array.</para>
		/// </summary>
		public uint cFunctions;

		/// <summary>
		/// <para>
		/// An array of pointers to null-terminated Unicode strings that contain the identifiers of the cryptographic functions contained
		/// in this set. The <c>cFunctions</c> member contains the number of elements in this array.
		/// </para>
		/// </summary>
		public IntPtr rgpszFunctions;

		internal IEnumerable<string?> _rgpszFunctions => rgpszFunctions.ToStringEnum((int)cFunctions, CharSet.Unicode);
	}

	/// <summary>
	/// <para>The <c>CRYPT_CONTEXTS</c> structure contains a set of CNG configuration context identifiers.</para>
	/// </summary>
	// https://docs.microsoft.com/en-us/windows/desktop/api/bcrypt/ns-bcrypt-_crypt_contexts typedef struct _CRYPT_CONTEXTS { ULONG
	// cContexts; PWSTR *rgpszContexts; } CRYPT_CONTEXTS, *PCRYPT_CONTEXTS;
	[PInvokeData("bcrypt.h", MSDNShortId = "a1b60660-a4c5-4880-8cd4-48d8717c77c3")]
	[StructLayout(LayoutKind.Sequential, CharSet = CharSet.Unicode)]
	public struct CRYPT_CONTEXTS
	{
		/// <summary>
		/// <para>Contains the number of elements in the <c>rgpszContexts</c> array.</para>
		/// </summary>
		public uint cContexts;

		/// <summary>
		/// <para>
		/// An array of pointers to null-terminated Unicode strings that contain the identifiers of the contexts contained in this set.
		/// The <c>cContext</c> member contains the number of elements in this array.
		/// </para>
		/// </summary>
		public IntPtr rgpszContexts;

		internal IEnumerable<string?> _rgpszContexts => rgpszContexts.ToStringEnum((int)cContexts, CharSet.Unicode);
	}

	/// <summary>
	/// <para>The <c>CRYPT_PROVIDERS</c> structure contains information about the registered CNG providers.</para>
	/// </summary>
	// https://docs.microsoft.com/en-us/windows/desktop/api/bcrypt/ns-bcrypt-_crypt_providers typedef struct _CRYPT_PROVIDERS { ULONG
	// cProviders; PWSTR *rgpszProviders; } CRYPT_PROVIDERS, *PCRYPT_PROVIDERS;
	[PInvokeData("bcrypt.h", MSDNShortId = "aef0e173-d3df-466e-ac2a-c686cae5edc9")]
	[StructLayout(LayoutKind.Sequential, CharSet = CharSet.Unicode)]
	public struct CRYPT_PROVIDERS
	{
		/// <summary>
		/// <para>Contains the number of elements in the <c>rgpszProviders</c> array.</para>
		/// </summary>
		public uint cProviders;

		/// <summary>
		/// <para>An array of null-terminated Unicode strings that contains the names of the registered providers.</para>
		/// </summary>
		public IntPtr rgpszProviders;

		internal IEnumerable<string?> _rgpszProviders => rgpszProviders.ToStringEnum((int)cProviders, CharSet.Unicode);
	}

	/// <summary>Blob type string references.</summary>
	public static class BlobType
	{
		/// <summary/>
		public const string BCRYPT_AES_WRAP_KEY_BLOB = "Rfc3565KeyWrapBlob";

		/// <summary>
		/// The BLOB is a Diffie-Hellman public/private key pair BLOB. The pbInput buffer must contain a BCRYPT_DH_KEY_BLOB structure
		/// immediately followed by the key data.
		/// </summary>
		public const string BCRYPT_DH_PRIVATE_BLOB = "DHPRIVATEBLOB";

		/// <summary>
		/// The BLOB is a Diffie-Hellman public key BLOB. The pbInput buffer must contain a BCRYPT_DH_KEY_BLOB structure immediately
		/// followed by the key data.
		/// </summary>
		public const string BCRYPT_DH_PUBLIC_BLOB = "DHPUBLICBLOB";

		/// <summary>
		/// The BLOB is a DSA public/private key pair BLOB. The pbInput buffer must contain a BCRYPT_DSA_KEY_BLOB or
		/// BCRYPT_DSA_KEY_BLOB_V2 structure immediately followed by the key data. BCRYPT_DSA_KEY_BLOB is used for key lengths from 512
		/// to 1024 bits. BCRYPT_DSA_KEY_BLOB_V2 is used for key lengths that exceed 1024 bits but are less than or equal to 3072 bits.
		/// <para>Windows 8: Support for BCRYPT_DSA_KEY_BLOB_V2 begins.</para>
		/// </summary>
		public const string BCRYPT_DSA_PRIVATE_BLOB = "DSAPRIVATEBLOB";

		/// <summary>
		/// The BLOB is a DSA public key BLOB. The pbInput buffer must contain a BCRYPT_DSA_KEY_BLOB or BCRYPT_DSA_KEY_BLOB_V2 structure
		/// immediately followed by the key data. BCRYPT_DSA_KEY_BLOB is used for key lengths from 512 to 1024 bits.
		/// BCRYPT_DSA_KEY_BLOB_V2 is used for key lengths that exceed 1024 bits but are less than or equal to 3072 bits.
		/// <para>Windows 8: Support for BCRYPT_DSA_KEY_BLOB_V2 begins.</para>
		/// </summary>
		public const string BCRYPT_DSA_PUBLIC_BLOB = "DSAPUBLICBLOB";

		/// <summary/>
		public const string BCRYPT_ECCFULLPRIVATE_BLOB = "ECCFULLPRIVATEBLOB";

		/// <summary/>
		public const string BCRYPT_ECCFULLPUBLIC_BLOB = "ECCFULLPUBLICBLOB";

		/// <summary>
		/// The BLOB is an elliptic curve cryptography (ECC) private key. The pbInput buffer must contain a BCRYPT_ECCKEY_BLOB structure
		/// immediately followed by the key data.
		/// </summary>
		public const string BCRYPT_ECCPRIVATE_BLOB = "ECCPRIVATEBLOB";

		/// <summary>
		/// The BLOB is an ECC public key. The pbInput buffer must contain a BCRYPT_ECCKEY_BLOB structure immediately followed by the key data.
		/// </summary>
		public const string BCRYPT_ECCPUBLIC_BLOB = "ECCPUBLICBLOB";

		/// <summary/>
		public const string BCRYPT_KEY_DATA_BLOB = "KeyDataBlob";

		/// <summary/>
		public const string BCRYPT_OPAQUE_KEY_BLOB = "OpaqueKeyBlob";

		/// <summary>
		/// The BLOB is a generic private key of any type. The private key does not necessarily contain the public key. The type of key
		/// in this BLOB is determined by the Magic member of the BCRYPT_KEY_BLOB structure.
		/// </summary>
		public const string BCRYPT_PRIVATE_KEY_BLOB = "PRIVATEBLOB";

		/// <summary>
		/// The BLOB is a generic public key of any type. The type of key in this BLOB is determined by the Magic member of the
		/// BCRYPT_KEY_BLOB structure.
		/// </summary>
		public const string BCRYPT_PUBLIC_KEY_BLOB = "PUBLICBLOB";

		/// <summary/>
		public const string BCRYPT_RSAFULLPRIVATE_BLOB = "RSAFULLPRIVATEBLOB";

		/// <summary>
		/// The BLOB is an RSA public/private key pair BLOB. The pbInput buffer must contain a BCRYPT_RSAKEY_BLOB structure immediately
		/// followed by the key data.
		/// </summary>
		public const string BCRYPT_RSAPRIVATE_BLOB = "RSAPRIVATEBLOB";

		/// <summary>
		/// The BLOB is an RSA public key BLOB. The pbInput buffer must contain a BCRYPT_RSAKEY_BLOB structure immediately followed by
		/// the key data.
		/// </summary>
		public const string BCRYPT_RSAPUBLIC_BLOB = "RSAPUBLICBLOB";

		/// <summary>
		/// The BLOB is a legacy Diffie-Hellman Version 3 Private Key BLOB that contains a Diffie-Hellman public/private key pair that
		/// was exported by using CryptoAPI.
		/// </summary>
		public const string LEGACY_DH_PRIVATE_BLOB = "CAPIDHPRIVATEBLOB";

		/// <summary>
		/// The BLOB is a Diffie-Hellman public key BLOB that was exported by using CryptoAPI. The Microsoft primitive provider does not
		/// support importing this BLOB type.
		/// </summary>
		public const string LEGACY_DH_PUBLIC_BLOB = "CAPIDHPUBLICBLOB";

		/// <summary>The BLOB is a DSA public/private key pair BLOB that was exported by using CryptoAPI.</summary>
		public const string LEGACY_DSA_PRIVATE_BLOB = "CAPIDSAPRIVATEBLOB";

		/// <summary>
		/// The BLOB is a DSA public key BLOB that was exported by using CryptoAPI. The Microsoft primitive provider does not support
		/// importing this BLOB type.
		/// </summary>
		public const string LEGACY_DSA_PUBLIC_BLOB = "CAPIDSAPUBLICBLOB";

		/// <summary>The BLOB is a DSA version 2 private key in a form that can be imported by using CryptoAPI.</summary>
		public const string LEGACY_DSA_V2_PRIVATE_BLOB = "V2CAPIDSAPRIVATEBLOB";

		/// <summary>The BLOB is a DSA version 2 public key in a form that can be imported by using CryptoAPI.</summary>
		public const string LEGACY_DSA_V2_PUBLIC_BLOB = "V2CAPIDSAPUBLICBLOB";

		/// <summary>The BLOB is an RSA public/private key pair BLOB that was exported by using CryptoAPI.</summary>
		public const string LEGACY_RSAPRIVATE_BLOB = "CAPIPRIVATEBLOB";

		/// <summary>
		/// The BLOB is an RSA public key BLOB that was exported by using CryptoAPI. The Microsoft primitive provider does not support
		/// importing this BLOB type.
		/// </summary>
		public const string LEGACY_RSAPUBLIC_BLOB = "CAPIPUBLICBLOB";

		/// <summary/>
		public const string SSL_ECCPUBLIC_BLOB = "SSLECCPUBLICBLOB";
	}

	/// <summary>Chain mode string references.</summary>
	public static class ChainingMode
	{
		/// <summary>Undocumented</summary>
		public const string BCRYPT_CHAIN_MODE_CBC = "ChainingModeCBC";

		/// <summary>Undocumented</summary>
		public const string BCRYPT_CHAIN_MODE_CCM = "ChainingModeCCM";

		/// <summary>Undocumented</summary>
		public const string BCRYPT_CHAIN_MODE_CFB = "ChainingModeCFB";

		/// <summary>Undocumented</summary>
		public const string BCRYPT_CHAIN_MODE_ECB = "ChainingModeECB";

		/// <summary>Undocumented</summary>
		public const string BCRYPT_CHAIN_MODE_GCM = "ChainingModeGCM";

		/// <summary>Undocumented</summary>
		public const string BCRYPT_CHAIN_MODE_NA = "ChainingModeN/A";
	}

	/// <summary>Known key derivation function identifiers.</summary>
	[PInvokeData("bcrypt.h", MSDNShortId = "33c3cbf7-6c08-42ed-ac3f-feb71f3a9cbf")]
	public static class KDF
	{
		/// <summary>The hash key derivation function.</summary>
		public const string BCRYPT_KDF_HASH = "HASH";

		/// <summary>Undocumented.</summary>
		public const string BCRYPT_KDF_HKDF = "HKDF";

		/// <summary>The Hash-Based Message Authentication Code (HMAC) key derivation function.</summary>
		public const string BCRYPT_KDF_HMAC = "HMAC";

		/// <summary>Undocumented.</summary>
		public const string BCRYPT_KDF_RAW_SECRET = "TRUNCATE";

		/// <summary>The SP800-56A key derivation function.</summary>
		public const string BCRYPT_KDF_SP80056A_CONCAT = "SP800_56A_CONCAT";

		/// <summary>
		/// The transport layer security (TLS) pseudo-random function (PRF) key derivation function. The size of the derived key is
		/// always 48 bytes.
		/// </summary>
		public const string BCRYPT_KDF_TLS_PRF = "TLS_PRF";
	}

	/// <summary>Well-known CNG providers.</summary>
	public static class KnownProvider
	{
		/// <summary>
		/// Generates and stores keys in Trusted Platform Modules. Supports Key Attestation to allow CA to ensure key is created in
		/// TPM/Virtual smart card
		/// </summary>
		public const string MS_PLATFORM_CRYPTO_PROVIDER = "Microsoft Platform Crypto Provider";

		/// <summary>Identifies the basic Microsoft CNG provider.</summary>
		public const string MS_PRIMITIVE_PROVIDER = "Microsoft Primitive Provider";
	}

	/// <summary>The following values are used with the BCryptGetProperty and BCryptSetProperty functions to identify a property.</summary>
	public static class PropertyName
	{
		/// <summary>A null-terminated Unicode string that contains the name of the algorithm.</summary>
		[CorrespondingType(typeof(string))]
		public const string BCRYPT_ALGORITHM_NAME = "AlgorithmName";

		/// <summary>
		/// The authentication tag lengths that are supported by the algorithm. This property is a BCRYPT_AUTH_TAG_LENGTHS_STRUCT
		/// structure. This property only applies to algorithms.
		/// </summary>
		[CorrespondingType(typeof(uint))]
		public const string BCRYPT_AUTH_TAG_LENGTH = "AuthTagLength";

		/// <summary>
		/// The size, in bytes, of a cipher block for the algorithm. This property only applies to block cipher algorithms. This data
		/// type is a DWORD.
		/// </summary>
		[CorrespondingType(typeof(uint))]
		public const string BCRYPT_BLOCK_LENGTH = "BlockLength";

		/// <summary>
		/// A list of the block lengths supported by an encryption algorithm. This data type is an array of DWORDs. The number of
		/// elements in the array can be determined by dividing the number of bytes retrieved by the size of a single DWORD.
		/// </summary>
		[CorrespondingType(typeof(uint))]
		public const string BCRYPT_BLOCK_SIZE_LIST = "BlockSizeList";

		/// <summary>
		/// A pointer to a null-terminated Unicode string that represents the chaining mode of the encryption algorithm. This property
		/// can be set on an algorithm handle or a key handle to one of the following values.
		/// </summary>
		[CorrespondingType(typeof(string))]
		public const string BCRYPT_CHAINING_MODE = "ChainingMode";

		/// <summary>
		/// Specifies parameters to use with a Diffie-Hellman key.This data type is a pointer to a BCRYPT_DH_PARAMETER_HEADER structure.
		/// This property can only be set and must be set for the key before the key is completed.
		/// </summary>
		[CorrespondingType(typeof(IntPtr))]
		public const string BCRYPT_DH_PARAMETERS = "DHParameters";

		/// <summary>
		/// Specifies parameters to use with a DSA key. This property is a BCRYPT_DSA_PARAMETER_HEADER or a
		/// BCRYPT_DSA_PARAMETER_HEADER_V2 structure. This property can only be set and must be set for the key before the key is completed.
		/// <para>
		/// Windows 8: Beginning with Windows 8, this property can be a BCRYPT_DSA_PARAMETER_HEADER_V2 structure.Use this structure if
		/// the key size exceeds 1024 bits and is less than or equal to 3072 bits.If the key size is greater than or equal to 512 but
		/// less than or equal to 1024 bits, use the BCRYPT_DSA_PARAMETER_HEADER structure.
		/// </para>
		/// </summary>
		[CorrespondingType(typeof(IntPtr))]
		public const string BCRYPT_DSA_PARAMETERS = "DSAParameters";

		/// <summary>Undocumented</summary>
		public const string BCRYPT_ECC_CURVE_NAME = "ECCCurveName";

		/// <summary>Undocumented</summary>
		public const string BCRYPT_ECC_CURVE_NAME_LIST = "ECCCurveNameList";

		/// <summary>Undocumented</summary>
		public const string BCRYPT_ECC_PARAMETERS = "ECCParameters";

		/// <summary>The size, in bits, of the effective length of an RC2 key. This data type is a DWORD.</summary>
		[CorrespondingType(typeof(uint))]
		public const string BCRYPT_EFFECTIVE_KEY_LENGTH = "EffectiveKeyLength";

		/// <summary>Undocumented</summary>
		public const string BCRYPT_GLOBAL_PARAMETERS = "SecretAgreementParam";

		/// <summary>
		/// The size, in bytes, of the block for a hash. This property only applies to hash algorithms. This data type is a DWORD.
		/// </summary>
		[CorrespondingType(typeof(uint))]
		public const string BCRYPT_HASH_BLOCK_LENGTH = "HashBlockLength";

		/// <summary>The size, in bytes, of the hash value of a hash provider. This data type is a DWORD.</summary>
		[CorrespondingType(typeof(uint))]
		public const string BCRYPT_HASH_LENGTH = "HashDigestLength";

		/// <summary>
		/// The list of DER-encoded hashing object identifiers (OIDs). This property is a BCRYPT_OID_LIST structure. This property can
		/// only be read.
		/// </summary>
		[CorrespondingType(typeof(BCRYPT_OID_LIST))]
		public const string BCRYPT_HASH_OID_LIST = "HashOIDList";

		/// <summary>Contains the initialization vector (IV) for a key. This property only applies to keys.</summary>
		public const string BCRYPT_INITIALIZATION_VECTOR = "IV";

		/// <summary>Undocumented</summary>
		public const string BCRYPT_IS_IFX_TPM_WEAK_KEY = "IsIfxTpmWeakKey";

		/// <summary>Undocumented.</summary>
		public const string BCRYPT_IS_KEYED_HASH = "IsKeyedHash";

		/// <summary>Undocumented.</summary>
		public const string BCRYPT_IS_REUSABLE_HASH = "IsReusableHash";

		/// <summary>The size, in bits, of the key value of a symmetric key provider. This data type is a DWORD.</summary>
		[CorrespondingType(typeof(uint))]
		public const string BCRYPT_KEY_LENGTH = "KeyLength";

		/// <summary>
		/// The key lengths that are supported by the algorithm. This property is a BCRYPT_KEY_LENGTHS_STRUCT structure. This property
		/// only applies to algorithms.
		/// </summary>
		[CorrespondingType(typeof(BCRYPT_KEY_LENGTHS_STRUCT))]
		public const string BCRYPT_KEY_LENGTHS = "KeyLengths";

		/// <summary>This property is not used. The BCRYPT_OBJECT_LENGTH property is used to obtain this information.</summary>
		[CorrespondingType(typeof(uint))]
		public const string BCRYPT_KEY_OBJECT_LENGTH = "KeyObjectLength";

		/// <summary>The number of bits in the key. This data type is a DWORD. This property only applies to keys.</summary>
		[CorrespondingType(typeof(uint))]
		public const string BCRYPT_KEY_STRENGTH = "KeyStrength";

		/// <summary>
		/// This can be set on any key handle that has the CFB chaining mode set. By default, this property is set to 1 for 8-bit CFB.
		/// Setting it to the block size in bytes causes full-block CFB to be used.
		/// </summary>
		[CorrespondingType(typeof(uint))]
		public const string BCRYPT_MESSAGE_BLOCK_LENGTH = "MessageBlockLength";

		/// <summary>
		/// This property returns a BCRYPT_MULTI_OBJECT_LENGTH_STRUCT, which contains information necessary to calculate the size of an
		/// object buffer.This property is only supported on operating system versions that support the BCryptCreateMultiHash function.
		/// </summary>
		[CorrespondingType(typeof(BCRYPT_MULTI_OBJECT_LENGTH_STRUCT))]
		public const string BCRYPT_MULTI_OBJECT_LENGTH = "MultiObjectLength";

		/// <summary>
		/// The size, in bytes, of the subobject of a provider. This data type is a DWORD. Currently, the hash and symmetric cipher
		/// algorithm providers use caller-allocated buffers to store their subobjects. For example, the hash provider requires you to
		/// allocate memory for the hash object obtained with the BCryptCreateHash function. This property provides the buffer size for a
		/// provider's object so you can allocate memory for the object created by the provider.
		/// </summary>
		[CorrespondingType(typeof(uint))]
		public const string BCRYPT_OBJECT_LENGTH = "ObjectLength";

		/// <summary>Represents the padding scheme of the RSA algorithm provider. This data type is a DWORD.</summary>
		[CorrespondingType(typeof(PaddingScheme))]
		public const string BCRYPT_PADDING_SCHEMES = "PaddingSchemes";

		/// <summary>Undocumented</summary>
		public const string BCRYPT_PCP_PLATFORM_TYPE_PROPERTY = "PCP_PLATFORM_TYPE";

		/// <summary>Undocumented</summary>
		public const string BCRYPT_PCP_PROVIDER_VERSION_PROPERTY = "PCP_PROVIDER_VERSION";

		/// <summary>Undocumented.</summary>
		public const string BCRYPT_PRIMITIVE_TYPE = "PrimitiveType";

		/// <summary>Undocumented</summary>
		public const string BCRYPT_PRIVATE_KEY = "PrivKeyVal";

		/// <summary>
		/// The handle of the CNG provider that created the object passed in the hObject parameter. This data type is a
		/// BCRYPT_ALG_HANDLE. This property can only be retrieved; it cannot be set.
		/// </summary>
		[CorrespondingType(typeof(BCRYPT_ALG_HANDLE))]
		public const string BCRYPT_PROVIDER_HANDLE = "ProviderHandle";

		/// <summary>Undocumented.</summary>
		public const string BCRYPT_PUBLIC_KEY_LENGTH = "PublicKeyLength";

		/// <summary>
		/// The size, in bytes, of the length of a signature for a key. This data type is a DWORD. This property only applies to keys.
		/// This property can only be retrieved; it cannot be set.
		/// </summary>
		[CorrespondingType(typeof(uint))]
		public const string BCRYPT_SIGNATURE_LENGTH = "SignatureLength";
	}

	/// <summary>
	/// The following identifiers are used to identify standard encryption algorithms in various CNG functions and structures, such as
	/// the CRYPT_INTERFACE_REG structure. Third party providers may have additional algorithms that they support.
	/// </summary>
	public static class StandardAlgorithmId
	{
		/// <summary>The 112-bit triple data encryption standard symmetric encryption algorithm. Standard: SP800-67, SP800-38A</summary>
		public const string BCRYPT_3DES_112_ALGORITHM = "3DES_112";

		/// <summary>The triple data encryption standard symmetric encryption algorithm. Standard: SP800-67, SP800-38A</summary>
		public const string BCRYPT_3DES_ALGORITHM = "3DES";

		/// <summary>The advanced encryption standard symmetric encryption algorithm. Standard: FIPS 197</summary>
		public const string BCRYPT_AES_ALGORITHM = "AES";

		/// <summary>
		/// The advanced encryption standard (AES) cipher based message authentication code (CMAC) symmetric encryption algorithm.
		/// Standard: SP 800-38B
		/// <para>Windows 8: Support for this algorithm begins.</para>
		/// </summary>
		public const string BCRYPT_AES_CMAC_ALGORITHM = "AES-CMAC";

		/// <summary>
		/// The advanced encryption standard (AES) Galois message authentication code (GMAC) symmetric encryption algorithm. Standard: SP800-38D
		/// <para>Windows Vista: This algorithm is supported beginning with Windows Vista with SP1.</para>
		/// </summary>
		public const string BCRYPT_AES_GMAC_ALGORITHM = "AES-GMAC";

		/// <summary>
		/// Crypto API (CAPI) key derivation function algorithm. Used by the BCryptKeyDerivation and NCryptKeyDerivation functions.
		/// </summary>
		public const string BCRYPT_CAPI_KDF_ALGORITHM = "CAPI_KDF";

		/// <summary>The data encryption standard symmetric encryption algorithm. Standard: FIPS 46-3, FIPS 81</summary>
		public const string BCRYPT_DES_ALGORITHM = "DES";

		/// <summary>The extended data encryption standard symmetric encryption algorithm. Standard: None</summary>
		public const string BCRYPT_DESX_ALGORITHM = "DESX";

		/// <summary>The Diffie-Hellman key exchange algorithm. Standard: PKCS #3</summary>
		public const string BCRYPT_DH_ALGORITHM = "DH";

		/// <summary>
		/// The digital signature algorithm. Standard: FIPS 186-2
		/// <para>
		/// Windows 8: Beginning with Windows 8, this algorithm supports FIPS 186-3. Keys less than or equal to 1024 bits adhere to FIPS
		/// 186-2 and keys greater than 1024 to FIPS 186-3.
		/// </para>
		/// </summary>
		public const string BCRYPT_DSA_ALGORITHM = "DSA";

		/// <summary>
		/// Generic prime elliptic curve Diffie-Hellman key exchange algorithm (see Remarks for more information). Standard: SP800-56A.
		/// </summary>
		public const string BCRYPT_ECDH_ALGORITHM = "ECDH";

		/// <summary>The 256-bit prime elliptic curve Diffie-Hellman key exchange algorithm. Standard: SP800-56A</summary>
		public const string BCRYPT_ECDH_P256_ALGORITHM = "ECDH_P256";

		/// <summary>The 384-bit prime elliptic curve Diffie-Hellman key exchange algorithm. Standard: SP800-56A</summary>
		public const string BCRYPT_ECDH_P384_ALGORITHM = "ECDH_P384";

		/// <summary>The 521-bit prime elliptic curve Diffie-Hellman key exchange algorithm. Standard: SP800-56A</summary>
		public const string BCRYPT_ECDH_P521_ALGORITHM = "ECDH_P521";

		/// <summary>
		/// Generic prime elliptic curve digital signature algorithm (see Remarks for more information). Standard: ANSI X9.62.
		/// </summary>
		public const string BCRYPT_ECDSA_ALGORITHM = "ECDSA";

		/// <summary>The 256-bit prime elliptic curve digital signature algorithm (FIPS 186-2). Standard: FIPS 186-2, X9.62</summary>
		public const string BCRYPT_ECDSA_P256_ALGORITHM = "ECDSA_P256";

		/// <summary>The 384-bit prime elliptic curve digital signature algorithm (FIPS 186-2). Standard: FIPS 186-2, X9.62</summary>
		public const string BCRYPT_ECDSA_P384_ALGORITHM = "ECDSA_P384";

		/// <summary>The 521-bit prime elliptic curve digital signature algorithm (FIPS 186-2). Standard: FIPS 186-2, X9.62</summary>
		public const string BCRYPT_ECDSA_P521_ALGORITHM = "ECDSA_P521";

		/// <summary>The bcrypt HKDF algorithm</summary>
		public const string BCRYPT_HKDF_ALGORITHM = "HKDF";

		/// <summary>The MD2 hash algorithm. Standard: RFC 1319</summary>
		public const string BCRYPT_MD2_ALGORITHM = "MD2";

		/// <summary>The MD4 hash algorithm. Standard: RFC 1320</summary>
		public const string BCRYPT_MD4_ALGORITHM = "MD4";

		/// <summary>The MD5 hash algorithm. Standard: RFC 1321</summary>
		public const string BCRYPT_MD5_ALGORITHM = "MD5";

		/// <summary>
		/// Password-based key derivation function 2 (PBKDF2) algorithm. Used by the BCryptKeyDerivation and NCryptKeyDerivation functions.
		/// </summary>
		public const string BCRYPT_PBKDF2_ALGORITHM = "PBKDF2";

		/// <summary>The RC2 block symmetric encryption algorithm. Standard: RFC 2268</summary>
		public const string BCRYPT_RC2_ALGORITHM = "RC2";

		/// <summary>The RC4 symmetric encryption algorithm. Standard: Various</summary>
		public const string BCRYPT_RC4_ALGORITHM = "RC4";

		/// <summary>
		/// The random-number generator algorithm. Standard: FIPS 186-2, FIPS 140-2, NIST SP 800-90 <note type="note">Beginning with
		/// Windows Vista with SP1 and Windows Server 2008, the random number generator is based on the AES counter mode specified in the
		/// NIST SP 800-90 standard.
		/// <para>
		/// Windows Vista: The random number generator is based on the hash-based random number generator specified in the FIPS 186-2 standard.
		/// </para>
		/// <para>
		/// Windows 8: Beginning with Windows 8, the RNG algorithm supports FIPS 186-3. Keys less than or equal to 1024 bits adhere to
		/// FIPS 186-2 and keys greater than 1024 to FIPS 186-3.
		/// </para>
		/// </note>
		/// </summary>
		public const string BCRYPT_RNG_ALGORITHM = "RNG";

		/// <summary>
		/// The dual elliptic curve random-number generator algorithm. Standard: SP800-90.
		/// <para>
		/// Windows 8: Beginning with Windows 8, the EC RNG algorithm supports FIPS 186-3. Keys less than or equal to 1024 bits adhere to
		/// FIPS 186-2 and keys greater than 1024 to FIPS 186-3.
		/// </para>
		/// <para>
		/// Windows 10: Beginning with Windows 10, the dual elliptic curve random number generator algorithm has been removed.Existing
		/// uses of this algorithm will continue to work; however, the random number generator is based on the AES counter mode specified
		/// in the NIST SP 800-90 standard.New code should use BCRYPT_RNG_ALGORITHM, and it is recommended that existing code be changed
		/// to use BCRYPT_RNG_ALGORITHM.
		/// </para>
		/// </summary>
		public const string BCRYPT_RNG_DUAL_EC_ALGORITHM = "DUALECRNG";

		/// <summary>
		/// The random-number generator algorithm suitable for DSA (Digital Signature Algorithm). Standard: FIPS 186-2.
		/// <para>Windows 8: Support for FIPS 186-3 begins.</para>
		/// </summary>
		public const string BCRYPT_RNG_FIPS186_DSA_ALGORITHM = "FIPS186DSARNG";

		/// <summary>The RSA public key algorithm. Standard: PKCS #1 v1.5 and v2.0.</summary>
		public const string BCRYPT_RSA_ALGORITHM = "RSA";

		/// <summary>
		/// The RSA signature algorithm. This algorithm is not currently supported. You can use the BCRYPT_RSA_ALGORITHM algorithm to
		/// perform RSA signing operations. Standard: PKCS #1 v1.5 and v2.0.
		/// </summary>
		public const string BCRYPT_RSA_SIGN_ALGORITHM = "RSA_SIGN";

		/// <summary>The 160-bit secure hash algorithm. Standard: FIPS 180-2, FIPS 198.</summary>
		public const string BCRYPT_SHA1_ALGORITHM = "SHA1";

		/// <summary>The 256-bit secure hash algorithm. Standard: FIPS 180-2, FIPS 198.</summary>
		public const string BCRYPT_SHA256_ALGORITHM = "SHA256";

		/// <summary>The 384-bit secure hash algorithm. Standard: FIPS 180-2, FIPS 198.</summary>
		public const string BCRYPT_SHA384_ALGORITHM = "SHA384";

		/// <summary>The 512-bit secure hash algorithm. Standard: FIPS 180-2, FIPS 198.</summary>
		public const string BCRYPT_SHA512_ALGORITHM = "SHA512";

		/// <summary>
		/// Counter mode, hash-based message authentication code (HMAC) key derivation function algorithm. Used by the
		/// BCryptKeyDerivation and NCryptKeyDerivation functions.
		/// </summary>
		public const string BCRYPT_SP800108_CTR_HMAC_ALGORITHM = "SP800_108_CTR_HMAC";

		/// <summary>SP800-56A key derivation function algorithm. Used by the BCryptKeyDerivation and NCryptKeyDerivation functions.</summary>
		public const string BCRYPT_SP80056A_CONCAT_ALGORITHM = "SP800_56A_CONCAT";

		/// <summary>The bcrypt tl s1 1 KDF algorithm</summary>
		public const string BCRYPT_TLS1_1_KDF_ALGORITHM = "TLS1_1_KDF";

		/// <summary>The bcrypt tl s1 2 KDF algorithm</summary>
		public const string BCRYPT_TLS1_2_KDF_ALGORITHM = "TLS1_2_KDF";

		/// <summary>
		/// The advanced encryption standard symmetric encryption algorithm in XTS mode. Standard: SP-800-38E, IEEE Std 1619-2007.
		/// <para>Windows 10: Support for this algorithm begins.</para>
		/// </summary>
		public const string BCRYPT_XTS_AES_ALGORITHM = "XTS-AES";
	}

	/// <summary>Provides a <see cref="SafeHandle"/> for <see cref="BCRYPT_ALG_HANDLE"/> that is disposed using <see cref="BCryptCloseAlgorithmProvider"/>.</summary>
	public class SafeBCRYPT_ALG_HANDLE : SafeHANDLE
	{
		/// <summary>Initializes a new instance of the <see cref="SafeBCRYPT_ALG_HANDLE"/> class and assigns an existing handle.</summary>
		/// <param name="preexistingHandle">An <see cref="IntPtr"/> object that represents the pre-existing handle to use.</param>
		/// <param name="ownsHandle">
		/// <see langword="true"/> to reliably release the handle during the finalization phase; otherwise, <see langword="false"/> (not recommended).
		/// </param>
		public SafeBCRYPT_ALG_HANDLE(IntPtr preexistingHandle, bool ownsHandle = true) : base(preexistingHandle, ownsHandle) { }

		/// <summary>Initializes a new instance of the <see cref="SafeBCRYPT_ALG_HANDLE"/> class.</summary>
		private SafeBCRYPT_ALG_HANDLE() : base() { }

		/// <summary>Performs an implicit conversion from <see cref="SafeBCRYPT_ALG_HANDLE"/> to <see cref="BCRYPT_ALG_HANDLE"/>.</summary>
		/// <param name="h">The safe handle instance.</param>
		/// <returns>The result of the conversion.</returns>
		public static implicit operator BCRYPT_ALG_HANDLE(SafeBCRYPT_ALG_HANDLE h) => h.handle;

		/// <summary>Performs an implicit conversion from <see cref="SafeBCRYPT_ALG_HANDLE"/> to <see cref="BCRYPT_HANDLE"/>.</summary>
		/// <param name="h">The safe handle instance.</param>
		/// <returns>The result of the conversion.</returns>
		public static implicit operator BCRYPT_HANDLE(SafeBCRYPT_ALG_HANDLE h) => h.handle;

		/// <inheritdoc/>
		protected override bool InternalReleaseHandle() => BCryptCloseAlgorithmProvider(this).Succeeded;
	}

	/// <summary>Provides a <see cref="SafeHandle"/> for <see cref="BCRYPT_HASH_HANDLE"/> that is disposed using <see cref="BCryptDestroyHash"/>.</summary>
	public class SafeBCRYPT_HASH_HANDLE : SafeHANDLE
	{
		/// <summary>Initializes a new instance of the <see cref="SafeBCRYPT_HASH_HANDLE"/> class and assigns an existing handle.</summary>
		/// <param name="preexistingHandle">An <see cref="IntPtr"/> object that represents the pre-existing handle to use.</param>
		/// <param name="ownsHandle">
		/// <see langword="true"/> to reliably release the handle during the finalization phase; otherwise, <see langword="false"/> (not recommended).
		/// </param>
		public SafeBCRYPT_HASH_HANDLE(IntPtr preexistingHandle, bool ownsHandle = true) : base(preexistingHandle, ownsHandle) { }

		/// <summary>Initializes a new instance of the <see cref="SafeBCRYPT_HASH_HANDLE"/> class.</summary>
		private SafeBCRYPT_HASH_HANDLE() : base() { }

		/// <summary>Performs an implicit conversion from <see cref="SafeBCRYPT_HASH_HANDLE"/> to <see cref="BCRYPT_HASH_HANDLE"/>.</summary>
		/// <param name="h">The safe handle instance.</param>
		/// <returns>The result of the conversion.</returns>
		public static implicit operator BCRYPT_HASH_HANDLE(SafeBCRYPT_HASH_HANDLE h) => h.handle;

		/// <inheritdoc/>
		protected override bool InternalReleaseHandle() => BCryptDestroyHash(this).Succeeded;
	}

	/// <summary>Provides a <see cref="SafeHandle"/> for <see cref="BCRYPT_KEY_HANDLE"/> that is disposed using <see cref="BCryptDestroyKey"/>.</summary>
	public class SafeBCRYPT_KEY_HANDLE : SafeHANDLE
	{
		/// <summary>Initializes a new instance of the <see cref="SafeBCRYPT_KEY_HANDLE"/> class and assigns an existing handle.</summary>
		/// <param name="preexistingHandle">An <see cref="IntPtr"/> object that represents the pre-existing handle to use.</param>
		/// <param name="ownsHandle">
		/// <see langword="true"/> to reliably release the handle during the finalization phase; otherwise, <see langword="false"/> (not recommended).
		/// </param>
		public SafeBCRYPT_KEY_HANDLE(IntPtr preexistingHandle, bool ownsHandle = true) : base(preexistingHandle, ownsHandle) { }

		/// <summary>Initializes a new instance of the <see cref="SafeBCRYPT_KEY_HANDLE"/> class.</summary>
		private SafeBCRYPT_KEY_HANDLE() : base() { }

		/// <summary>Performs an implicit conversion from <see cref="SafeBCRYPT_KEY_HANDLE"/> to <see cref="BCRYPT_KEY_HANDLE"/>.</summary>
		/// <param name="h">The safe handle instance.</param>
		/// <returns>The result of the conversion.</returns>
		public static implicit operator BCRYPT_KEY_HANDLE(SafeBCRYPT_KEY_HANDLE h) => h.handle;

		/// <inheritdoc/>
		protected override bool InternalReleaseHandle() => BCryptDestroyKey(this).Succeeded;
	}

	/// <summary>Provides a <see cref="SafeHandle"/> for <see cref="BCRYPT_SECRET_HANDLE"/> that is disposed using <see cref="BCryptDestroySecret"/>.</summary>
	public class SafeBCRYPT_SECRET_HANDLE : SafeHANDLE
	{
		/// <summary>Initializes a new instance of the <see cref="SafeBCRYPT_SECRET_HANDLE"/> class and assigns an existing handle.</summary>
		/// <param name="preexistingHandle">An <see cref="IntPtr"/> object that represents the pre-existing handle to use.</param>
		/// <param name="ownsHandle">
		/// <see langword="true"/> to reliably release the handle during the finalization phase; otherwise, <see langword="false"/> (not recommended).
		/// </param>
		public SafeBCRYPT_SECRET_HANDLE(IntPtr preexistingHandle, bool ownsHandle = true) : base(preexistingHandle, ownsHandle) { }

		/// <summary>Initializes a new instance of the <see cref="SafeBCRYPT_SECRET_HANDLE"/> class.</summary>
		private SafeBCRYPT_SECRET_HANDLE() : base() { }

		/// <summary>Performs an implicit conversion from <see cref="SafeBCRYPT_SECRET_HANDLE"/> to <see cref="BCRYPT_SECRET_HANDLE"/>.</summary>
		/// <param name="h">The safe handle instance.</param>
		/// <returns>The result of the conversion.</returns>
		public static implicit operator BCRYPT_SECRET_HANDLE(SafeBCRYPT_SECRET_HANDLE h) => h.handle;

		/// <inheritdoc/>
		protected override bool InternalReleaseHandle() => BCryptDestroySecret(this).Succeeded;
	}

	/// <summary>Provides a <see cref="SafeHandle"/> for <see cref="NCryptBuffer"/> that is disposed using <see cref="BCryptFreeBuffer"/>.</summary>
	public class SafeBCryptBuffer : SafeHANDLE
	{
		/// <summary>Initializes a new instance of the <see cref="SafeBCryptBuffer"/> class and assigns an existing handle.</summary>
		/// <param name="preexistingHandle">An <see cref="IntPtr"/> object that represents the pre-existing handle to use.</param>
		/// <param name="ownsHandle">
		/// <see langword="true"/> to reliably release the handle during the finalization phase; otherwise, <see langword="false"/> (not recommended).
		/// </param>
		public SafeBCryptBuffer(IntPtr preexistingHandle, bool ownsHandle = true) : base(preexistingHandle, ownsHandle) { }

		/// <summary>Initializes a new instance of the <see cref="SafeBCryptBuffer"/> class.</summary>
		private SafeBCryptBuffer() : base() { }

		/// <summary>Marshals data to a newly allocated managed object of the type specified by a generic type parameter.</summary>
		/// <typeparam name="T">The type of the object to which the data is to be copied. This must be a structure.</typeparam>
		/// <returns>A managed object that this buffer points to.</returns>
		public T? ToStructure<T>() => IsInvalid || IsClosed ? default : handle.ToStructure<T>();

		/// <inheritdoc/>
		protected override bool InternalReleaseHandle() { BCryptFreeBuffer(handle); return true; }
	}
}