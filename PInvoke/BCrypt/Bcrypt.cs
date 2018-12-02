using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using Vanara.Extensions;
using Vanara.InteropServices;

namespace Vanara.PInvoke
{
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
		public static extern NTStatus BCryptCreateHash(BCRYPT_ALG_HANDLE hAlgorithm, out SafeBCRYPT_HASH_HANDLE phHash, SafeAllocatedMemoryHandle pbHashObject, uint cbHashObject, SafeAllocatedMemoryHandle pbSecret, uint cbSecret, AlgProviderFlags dwFlags);

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
		public static extern NTStatus BCryptCreateHash(BCRYPT_ALG_HANDLE hAlgorithm, out SafeBCRYPT_HASH_HANDLE phHash, [Optional] IntPtr pbHashObject, [Optional] uint cbHashObject, SafeAllocatedMemoryHandle pbSecret, uint cbSecret, AlgProviderFlags dwFlags);

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
		public static extern NTStatus BCryptCreateMultiHash(BCRYPT_ALG_HANDLE hAlgorithm, out SafeBCRYPT_HASH_HANDLE phHash, uint nHashes, SafeAllocatedMemoryHandle pbHashObject, uint cbHashObject, SafeAllocatedMemoryHandle pbSecret, uint cbSecret, AlgProviderFlags dwFlags);

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
		public static extern NTStatus BCryptCreateMultiHash(BCRYPT_ALG_HANDLE hAlgorithm, out SafeBCRYPT_HASH_HANDLE phHash, uint nHashes, [Optional] IntPtr pbHashObject, [Optional] uint cbHashObject, SafeAllocatedMemoryHandle pbSecret, uint cbSecret, AlgProviderFlags dwFlags);

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
		public static extern NTStatus BCryptDecrypt(BCRYPT_KEY_HANDLE hKey, IntPtr pbInput, uint cbInput, IntPtr pPaddingInfo, IntPtr pbIV, uint cbIV, IntPtr pbOutput, uint cbOutput, out uint pcbResult, EncryptFlags dwFlags);

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
		public static extern NTStatus BCryptEncrypt(BCRYPT_KEY_HANDLE hKey, byte[] pbInput, uint cbInput, IntPtr pPaddingInfo, byte[] pbIV, uint cbIV, byte[] pbOutput, uint cbOutput, out uint pcbResult, EncryptFlags dwFlags);

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
		public static extern NTStatus BCryptEncrypt(BCRYPT_KEY_HANDLE hKey, byte[] pbInput, uint cbInput, IntPtr pPaddingInfo, IntPtr pbIV, uint cbIV, IntPtr pbOutput, uint cbOutput, out uint pcbResult, EncryptFlags dwFlags);

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
			return mem.DangerousGetHandle().ToArray<BCRYPT_ALGORITHM_IDENTIFIER>((int)sz);
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
		public static string[] BCryptEnumContextFunctionProviders(ContextConfigTable dwTable, string pszContext, InterfaceId dwInterface, string pszFunction)
		{
			BCryptEnumContextFunctionProviders(dwTable, pszContext, dwInterface, pszFunction, out var _, out var mem).ThrowIfFailed();
			return mem.DangerousGetHandle().ToStructure<CRYPT_CONTEXT_FUNCTION_PROVIDERS>()._rgpszProviders.ToArray();
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
		public static string[] BCryptEnumContextFunctions(ContextConfigTable dwTable, string pszContext, InterfaceId dwInterface)
		{
			BCryptEnumContextFunctions(dwTable, pszContext, dwInterface, out var sz, out var buf).ThrowIfFailed();
			return buf.DangerousGetHandle().ToStructure<CRYPT_CONTEXT_FUNCTIONS>()._rgpszFunctions.ToArray();
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
		public static string[] BCryptEnumContexts(ContextConfigTable dwTable)
		{
			BCryptEnumContexts(dwTable, out var sz, out var buf).ThrowIfFailed();
			return buf.DangerousGetHandle().ToStructure<CRYPT_CONTEXTS>()._rgpszContexts.ToArray();
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
			return buf.DangerousGetHandle().ToArray<BCRYPT_PROVIDER_NAME>((int)sz).Select(s => s.pszProviderName).ToArray();
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
		public static string[] BCryptEnumRegisteredProviders()
		{
			BCryptEnumRegisteredProviders(out var sz, out var buf).ThrowIfFailed();
			return buf.DangerousGetHandle().ToStructure<CRYPT_PROVIDERS>()._rgpszProviders.ToArray();
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
		public static extern NTStatus BCryptExportKey(BCRYPT_KEY_HANDLE hKey, BCRYPT_KEY_HANDLE hExportKey, [MarshalAs(UnmanagedType.LPWStr)] string pszBlobType, byte[] pbOutput, uint cbOutput, out uint pcbResult, uint dwFlags = 0);

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
		public static extern NTStatus BCryptExportKey(BCRYPT_KEY_HANDLE hKey, BCRYPT_KEY_HANDLE hExportKey, [MarshalAs(UnmanagedType.LPWStr)] string pszBlobType, IntPtr pbOutput, uint cbOutput, out uint pcbResult, uint dwFlags = 0);

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
		public static extern NTStatus BCryptGenerateSymmetricKey(BCRYPT_ALG_HANDLE hAlgorithm, out SafeBCRYPT_KEY_HANDLE phKey, byte[] pbKeyObject, uint cbKeyObject, byte[] pbSecret, uint cbSecret, uint dwFlags = 0);

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
		public static extern NTStatus BCryptGenerateSymmetricKey(BCRYPT_ALG_HANDLE hAlgorithm, out SafeBCRYPT_KEY_HANDLE phKey, IntPtr pbKeyObject, uint cbKeyObject, byte[] pbSecret, uint cbSecret, uint dwFlags = 0);

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
		public static extern NTStatus BCryptGenerateSymmetricKey(BCRYPT_ALG_HANDLE hAlgorithm, out SafeBCRYPT_KEY_HANDLE phKey, IntPtr pbKeyObject, uint cbKeyObject, IntPtr pbSecret, uint cbSecret, uint dwFlags = 0);

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
			using (var mem = SafeCoTaskMemHandle.CreateFromStructure<T>())
			{
				BCryptGetProperty(hObject, pszProperty, mem, (uint)mem.Size, out var sz).ThrowIfFailed();
				if (mem.Size != sz) throw new InvalidCastException("Requested type and system defined sizes do not match.");
				return mem.ToStructure<T>();
			}
		}

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
		public static extern NTStatus BCryptImportKey(BCRYPT_ALG_HANDLE hAlgorithm, BCRYPT_KEY_HANDLE hImportKey, [MarshalAs(UnmanagedType.LPWStr)] string pszBlobType, out SafeBCRYPT_KEY_HANDLE phKey, byte[] pbKeyObject, uint cbKeyObject, byte[] pbInput, uint cbInput, uint dwFlags = 0);

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
		public static extern NTStatus BCryptImportKey(BCRYPT_ALG_HANDLE hAlgorithm, BCRYPT_KEY_HANDLE hImportKey, [MarshalAs(UnmanagedType.LPWStr)] string pszBlobType, out SafeBCRYPT_KEY_HANDLE phKey, IntPtr pbKeyObject, uint cbKeyObject, IntPtr pbInput, uint cbInput, uint dwFlags = 0);

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
		public static extern NTStatus BCryptImportKeyPair(BCRYPT_ALG_HANDLE hAlgorithm, [Optional] BCRYPT_KEY_HANDLE hImportKey, [MarshalAs(UnmanagedType.LPWStr)] string pszBlobType, out SafeBCRYPT_KEY_HANDLE phKey, IntPtr pbInput, uint cbInput, ImportFlags dwFlags);

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
		public static extern NTStatus BCryptImportKeyPair(BCRYPT_ALG_HANDLE hAlgorithm, [Optional] BCRYPT_KEY_HANDLE hImportKey, [MarshalAs(UnmanagedType.LPWStr)] string pszBlobType, out SafeBCRYPT_KEY_HANDLE phKey, byte[] pbInput, uint cbInput, ImportFlags dwFlags);

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
		public static extern NTStatus BCryptOpenAlgorithmProvider(out SafeBCRYPT_ALG_HANDLE phAlgorithm, string pszAlgId, [Optional] string pszImplementation, AlgProviderFlags dwFlags = 0);

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

		/// <summary>Provides a handle to an algorithm provider.</summary>
		[StructLayout(LayoutKind.Sequential)]
		public struct BCRYPT_ALG_HANDLE : IHandle
		{
			private IntPtr handle;

			/// <summary>Initializes a new instance of the <see cref="BCRYPT_ALG_HANDLE"/> struct.</summary>
			/// <param name="preexistingHandle">An <see cref="IntPtr"/> object that represents the pre-existing handle to use.</param>
			public BCRYPT_ALG_HANDLE(IntPtr preexistingHandle) => handle = preexistingHandle;

			/// <summary>Returns an invalid handle by instantiating a <see cref="BCRYPT_ALG_HANDLE"/> object with <see cref="IntPtr.Zero"/>.</summary>
			public static BCRYPT_ALG_HANDLE NULL => new BCRYPT_ALG_HANDLE(IntPtr.Zero);

			/// <summary>Gets a value indicating whether this instance is a null handle.</summary>
			public bool IsNull => handle == IntPtr.Zero;

			/// <summary>Performs an explicit conversion from <see cref="BCRYPT_ALG_HANDLE"/> to <see cref="IntPtr"/>.</summary>
			/// <param name="h">The handle.</param>
			/// <returns>The result of the conversion.</returns>
			public static explicit operator IntPtr(BCRYPT_ALG_HANDLE h) => h.handle;

			/// <summary>Performs an implicit conversion from <see cref="IntPtr"/> to <see cref="BCRYPT_ALG_HANDLE"/>.</summary>
			/// <param name="h">The pointer to a handle.</param>
			/// <returns>The result of the conversion.</returns>
			public static implicit operator BCRYPT_ALG_HANDLE(IntPtr h) => new BCRYPT_ALG_HANDLE(h);

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
			public override bool Equals(object obj) => obj is BCRYPT_ALG_HANDLE h ? handle == h.handle : false;

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
		public struct BCRYPT_HANDLE : IHandle
		{
			private IntPtr handle;

			/// <summary>Initializes a new instance of the <see cref="BCRYPT_HANDLE"/> struct.</summary>
			/// <param name="preexistingHandle">An <see cref="IntPtr"/> object that represents the pre-existing handle to use.</param>
			public BCRYPT_HANDLE(IntPtr preexistingHandle) => handle = preexistingHandle;

			/// <summary>Returns an invalid handle by instantiating a <see cref="BCRYPT_HANDLE"/> object with <see cref="IntPtr.Zero"/>.</summary>
			public static BCRYPT_HANDLE NULL => new BCRYPT_HANDLE(IntPtr.Zero);

			/// <summary>Gets a value indicating whether this instance is a null handle.</summary>
			public bool IsNull => handle == IntPtr.Zero;

			/// <summary>Performs an explicit conversion from <see cref="BCRYPT_HANDLE"/> to <see cref="IntPtr"/>.</summary>
			/// <param name="h">The handle.</param>
			/// <returns>The result of the conversion.</returns>
			public static explicit operator IntPtr(BCRYPT_HANDLE h) => h.handle;

			/// <summary>Performs an implicit conversion from <see cref="IntPtr"/> to <see cref="BCRYPT_HANDLE"/>.</summary>
			/// <param name="h">The pointer to a handle.</param>
			/// <returns>The result of the conversion.</returns>
			public static implicit operator BCRYPT_HANDLE(IntPtr h) => new BCRYPT_HANDLE(h);

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
			public override bool Equals(object obj) => obj is BCRYPT_HANDLE h ? handle == h.handle : false;

			/// <inheritdoc/>
			public override int GetHashCode() => handle.GetHashCode();

			/// <inheritdoc/>
			public IntPtr DangerousGetHandle() => handle;
		}

		/// <summary>Provides a handle to a multi-hash state.</summary>
		[StructLayout(LayoutKind.Sequential)]
		public struct BCRYPT_HASH_HANDLE : IHandle
		{
			private IntPtr handle;

			/// <summary>Initializes a new instance of the <see cref="BCRYPT_HASH_HANDLE"/> struct.</summary>
			/// <param name="preexistingHandle">An <see cref="IntPtr"/> object that represents the pre-existing handle to use.</param>
			public BCRYPT_HASH_HANDLE(IntPtr preexistingHandle) => handle = preexistingHandle;

			/// <summary>Returns an invalid handle by instantiating a <see cref="BCRYPT_HASH_HANDLE"/> object with <see cref="IntPtr.Zero"/>.</summary>
			public static BCRYPT_HASH_HANDLE NULL => new BCRYPT_HASH_HANDLE(IntPtr.Zero);

			/// <summary>Gets a value indicating whether this instance is a null handle.</summary>
			public bool IsNull => handle == IntPtr.Zero;

			/// <summary>Performs an explicit conversion from <see cref="BCRYPT_HASH_HANDLE"/> to <see cref="IntPtr"/>.</summary>
			/// <param name="h">The handle.</param>
			/// <returns>The result of the conversion.</returns>
			public static explicit operator IntPtr(BCRYPT_HASH_HANDLE h) => h.handle;

			/// <summary>Performs an implicit conversion from <see cref="IntPtr"/> to <see cref="BCRYPT_HASH_HANDLE"/>.</summary>
			/// <param name="h">The pointer to a handle.</param>
			/// <returns>The result of the conversion.</returns>
			public static implicit operator BCRYPT_HASH_HANDLE(IntPtr h) => new BCRYPT_HASH_HANDLE(h);

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
			public override bool Equals(object obj) => obj is BCRYPT_HASH_HANDLE h ? handle == h.handle : false;

			/// <inheritdoc/>
			public override int GetHashCode() => handle.GetHashCode();

			/// <inheritdoc/>
			public IntPtr DangerousGetHandle() => handle;
		}

		/// <summary>Provides a handle to a key pair.</summary>
		[StructLayout(LayoutKind.Sequential)]
		public struct BCRYPT_KEY_HANDLE : IHandle
		{
			private IntPtr handle;

			/// <summary>Initializes a new instance of the <see cref="BCRYPT_KEY_HANDLE"/> struct.</summary>
			/// <param name="preexistingHandle">An <see cref="IntPtr"/> object that represents the pre-existing handle to use.</param>
			public BCRYPT_KEY_HANDLE(IntPtr preexistingHandle) => handle = preexistingHandle;

			/// <summary>Returns an invalid handle by instantiating a <see cref="BCRYPT_KEY_HANDLE"/> object with <see cref="IntPtr.Zero"/>.</summary>
			public static BCRYPT_KEY_HANDLE NULL => new BCRYPT_KEY_HANDLE(IntPtr.Zero);

			/// <summary>Gets a value indicating whether this instance is a null handle.</summary>
			public bool IsNull => handle == IntPtr.Zero;

			/// <summary>Performs an explicit conversion from <see cref="BCRYPT_KEY_HANDLE"/> to <see cref="IntPtr"/>.</summary>
			/// <param name="h">The handle.</param>
			/// <returns>The result of the conversion.</returns>
			public static explicit operator IntPtr(BCRYPT_KEY_HANDLE h) => h.handle;

			/// <summary>Performs an implicit conversion from <see cref="IntPtr"/> to <see cref="BCRYPT_KEY_HANDLE"/>.</summary>
			/// <param name="h">The pointer to a handle.</param>
			/// <returns>The result of the conversion.</returns>
			public static implicit operator BCRYPT_KEY_HANDLE(IntPtr h) => new BCRYPT_KEY_HANDLE(h);

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
			public override bool Equals(object obj) => obj is BCRYPT_KEY_HANDLE h ? handle == h.handle : false;

			/// <inheritdoc/>
			public override int GetHashCode() => handle.GetHashCode();

			/// <inheritdoc/>
			public IntPtr DangerousGetHandle() => handle;
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

			internal IEnumerable<string> _rgpszProviders => rgpszProviders.ToStringEnum((int)cProviders, CharSet.Unicode);
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

			internal IEnumerable<string> _rgpszFunctions => rgpszFunctions.ToStringEnum((int)cFunctions, CharSet.Unicode);
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

			internal IEnumerable<string> _rgpszContexts => rgpszContexts.ToStringEnum((int)cContexts, CharSet.Unicode);
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

			internal IEnumerable<string> _rgpszProviders => rgpszProviders.ToStringEnum((int)cProviders, CharSet.Unicode);
		}

		public static class BlobType
		{
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

			public const string BCRYPT_ECCFULLPRIVATE_BLOB = "ECCFULLPRIVATEBLOB";

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

			public const string BCRYPT_KEY_DATA_BLOB = "KeyDataBlob";

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

			public const string SSL_ECCPUBLIC_BLOB = "SSLECCPUBLICBLOB";
		}

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
		public static class PrimitivePropertyId
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
			// TODO [CorrespondingType(typeof(BCRYPT_OID_LIST))]
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
			// TODO [CorrespondingType(typeof(BCRYPT_KEY_LENGTHS_STRUCT))]
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
			// TODO [CorrespondingType(typeof(BCRYPT_MULTI_OBJECT_LENGTH_STRUCT))]
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
		public class SafeBCRYPT_ALG_HANDLE : HANDLE
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
		public class SafeBCRYPT_HASH_HANDLE : HANDLE
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

		/// <summary>Provides a <see cref="SafeHandle"/> for <see cref="BCRYPT_KEY_HANDLE"/> that is disposed using <see cref="BCryptDestroyKey."/>.</summary>
		public class SafeBCRYPT_KEY_HANDLE : HANDLE
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

		/// <summary>Provides a <see cref="SafeHandle"/> for <see cref="BCryptBuffer"/> that is disposed using <see cref="BCryptFreeBuffer"/>.</summary>
		public class SafeBCryptBuffer : HANDLE
		{
			/// <summary>Initializes a new instance of the <see cref="SafeBCryptBuffer"/> class and assigns an existing handle.</summary>
			/// <param name="preexistingHandle">An <see cref="IntPtr"/> object that represents the pre-existing handle to use.</param>
			/// <param name="ownsHandle">
			/// <see langword="true"/> to reliably release the handle during the finalization phase; otherwise, <see langword="false"/> (not recommended).
			/// </param>
			public SafeBCryptBuffer(IntPtr preexistingHandle, bool ownsHandle = true) : base(preexistingHandle, ownsHandle) { }

			/// <summary>Initializes a new instance of the <see cref="SafeBCryptBuffer"/> class.</summary>
			private SafeBCryptBuffer() : base() { }

			/// <inheritdoc/>
			protected override bool InternalReleaseHandle() { BCryptFreeBuffer(handle); return true; }
		}

		/*
		BCryptDeleteContext
		BCryptDeriveKey
		BCryptDeriveKeyCapi
		BCryptDeriveKeyPBKDF2
		BCryptDestroySecret
		BCryptDuplicateHash
		BCryptDuplicateKey
		BCryptFinalizeKeyPair
		BCryptGenRandom
		BCryptGetFipsAlgorithmMode
		BCryptHash
		BCryptKeyDerivation
		BCryptProcessMultiOperations
		BCryptQueryContextConfiguration
		BCryptQueryContextFunctionConfiguration
		BCryptQueryContextFunctionProperty
		BCryptQueryProviderRegistration
		BCryptRegisterConfigChangeNotify
		BCryptRemoveContextFunction
		BCryptResolveProviders
		BCryptSecretAgreement
		BCryptSetContextFunctionProperty
		BCryptSignHash
		BCryptUnregisterConfigChangeNotify
		BCryptVerifySignature
		*/
	}
}