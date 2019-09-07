using System;
using System.Linq;
using System.Runtime.InteropServices;
using Vanara.Extensions;
using Vanara.InteropServices;

namespace Vanara.PInvoke
{
	/// <summary>Methods and data types found in NCrypt.dll.</summary>
	public static partial class NCrypt
	{
		/// <summary>A custom function that can allocate memory.</summary>
		/// <param name="cbSize">Size of the memory to allocate.</param>
		/// <returns>Pointer to the allocated memory.</returns>
		[PInvokeData("ncrypt.h")]
		[UnmanagedFunctionPointer(CallingConvention.Winapi)]
		public delegate IntPtr PFN_NCRYPT_ALLOC(SizeT cbSize);

		/// <summary>A custom function that can free allocated memory.</summary>
		/// <param name="pv">Pointer to the allocated memory.</param>
		[PInvokeData("ncrypt.h")]
		[UnmanagedFunctionPointer(CallingConvention.Winapi)]
		public delegate void PFN_NCRYPT_FREE(IntPtr pv);

		/// <summary>Flags used with <c>NCryptCreatePersistedKey</c>.</summary>
		[PInvokeData("ncrypt.h")]
		[Flags]
		public enum CreatePersistedFlags
		{
			/// <summary>The key applies to the local computer. If this flag is not present, the key applies to the current user.</summary>
			NCRYPT_MACHINE_KEY_FLAG = 0x00000020,

			/// <summary>
			/// If a key already exists in the container with the specified name, the existing key will be overwritten. If this flag is not
			/// specified and a key with the specified name already exists, this function will return NTE_EXISTS.
			/// </summary>
			NCRYPT_OVERWRITE_KEY_FLAG = 0x00000080,
		}

		/// <summary>A set of flags that specify the export policy for a persisted key. This property only applies to keys.</summary>
		[PInvokeData("ncrypt.h")]
		[Flags]
		public enum ExportPolicy
		{
			/// <summary>The private key can be exported.</summary>
			NCRYPT_ALLOW_EXPORT_FLAG = 0x00000001,

			/// <summary>The private key can be exported in plaintext form.</summary>
			NCRYPT_ALLOW_PLAINTEXT_EXPORT_FLAG = 0x00000002,

			/// <summary>
			/// The private key can be exported once for archiving purposes. This flag only applies to the original key handle on which it is
			/// set. This policy can only be applied to the original key handle. After the key handle has been closed, the key can no longer
			/// be exported for archiving purposes.
			/// </summary>
			NCRYPT_ALLOW_ARCHIVING_FLAG = 0x00000004,

			/// <summary>
			/// The private key can be exported once in plaintext form for archiving purposes. This flag only applies to the original key
			/// handle on which it is set. This policy can only be applied to the original key handle. After the key handle has been closed,
			/// the key can no longer be exported for archiving purposes.
			/// </summary>
			NCRYPT_ALLOW_PLAINTEXT_ARCHIVING_FLAG = 0x00000008,
		}

		/// <summary>Flags for <c>NCryptFinalizeKey</c>.</summary>
		[PInvokeData("ncrypt.h", MSDNShortId = "4386030d-4ce6-4b2e-adc5-a15ddc869349")]
		[Flags]
		public enum FinalizeKeyFlags
		{
			/// <summary>
			/// Also save the key in legacy storage. This allows the key to be used with CryptoAPI. This flag only applies to RSA keys.
			/// </summary>
			NCRYPT_WRITE_KEY_TO_LEGACY_STORE_FLAG = 0x00000200,

			/// <summary>Do not validate the public portion of the key pair. This flag only applies to public/private key pairs.</summary>
			NCRYPT_NO_KEY_VALIDATION = 0x00000008,

			/// <summary>
			/// Requests that the key service provider (KSP) not display any user interface. If the provider must display the UI to operate,
			/// the call fails and the KSP should set the NTE_SILENT_CONTEXT error code as the last error.
			/// </summary>
			NCRYPT_SILENT_FLAG = 0x00000040,
		}

		/// <summary>Flags for <c>NCryptGetProperty</c>.</summary>
		[PInvokeData("ncrypt.h", MSDNShortId = "7b857ce0-8525-489b-9987-ef40081a5577")]
		[Flags]
		public enum GetPropertyFlags : uint
		{
			/// <summary>
			/// Ignore any built in values for this property and only retrieve the user-persisted properties of the key. The maximum size of
			/// the data for any persisted property is NCRYPT_MAX_PROPERTY_DATA bytes.
			/// </summary>
			NCRYPT_PERSIST_ONLY_FLAG = 0x40000000,

			/// <summary>
			/// Requests that the key service provider (KSP) not display any user interface. If the provider must display the UI to operate,
			/// the call fails and the KSP should set the NTE_SILENT_CONTEXT error code as the last error.
			/// </summary>
			NCRYPT_SILENT_FLAG = 0x00000040,

			/// <summary>
			/// Retrieve the security identifier (SID) of the object's owner. Use the GetSecurityDescriptorOwner function to obtain the owner
			/// SID from the SECURITY_DESCRIPTOR structure.
			/// </summary>
			OWNER_SECURITY_INFORMATION = SECURITY_INFORMATION.OWNER_SECURITY_INFORMATION,

			/// <summary>
			/// Retrieve the SID of the object's primary group. Use the GetSecurityDescriptorGroup function to obtain the group SID from the
			/// SECURITY_DESCRIPTOR structure.
			/// </summary>
			GROUP_SECURITY_INFORMATION = SECURITY_INFORMATION.GROUP_SECURITY_INFORMATION,

			/// <summary>
			/// Retrieve the discretionary access control list (DACL). Use the GetSecurityDescriptorSacl function to obtain the DACL from the
			/// SECURITY_DESCRIPTOR structure.
			/// </summary>
			DACL_SECURITY_INFORMATION = SECURITY_INFORMATION.DACL_SECURITY_INFORMATION,

			/// <summary>
			/// Retrieve the system access control list (SACL). Use the GetSecurityDescriptorDacl function to obtain the SACL from the
			/// SECURITY_DESCRIPTOR structure.
			/// </summary>
			SACL_SECURITY_INFORMATION = SECURITY_INFORMATION.SACL_SECURITY_INFORMATION,
		}

		/// <summary>A set of flags that define implementation details of the provider. This property only applies to key storage providers.</summary>
		[PInvokeData("ncrypt.h")]
		[Flags]
		public enum ImplType
		{
			/// <summary>The provider is hardware based.</summary>
			NCRYPT_IMPL_HARDWARE_FLAG = 0x00000001,

			/// <summary>The provider is software based.</summary>
			NCRYPT_IMPL_SOFTWARE_FLAG = 0x00000002,

			/// <summary>The provider is removable.</summary>
			NCRYPT_IMPL_REMOVABLE_FLAG = 0x00000008,

			/// <summary>The provider is a hardware based random number generator.</summary>
			NCRYPT_IMPL_HARDWARE_RNG_FLAG = 0x00000010,

			/// <summary>Undocumented.</summary>
			NCRYPT_IMPL_VIRTUAL_ISOLATION_FLAG = 0x00000020,
		}

		/// <summary>Key derivation function buffer types.</summary>
		[PInvokeData("bcrypt.h")]
		public enum KeyDerivationBufferType
		{
			/// <summary>
			/// The buffer is a key derivation function (KDF) parameter that contains a null-terminated Unicode string that identifies the
			/// hash algorithm. This can be one of the standard hash algorithm identifiers from CNG Algorithm Identifiers or the identifier
			/// for another registered hash algorithm.
			/// <para>The size specified by the cbBuffer member of this structure must include the terminating NULL character.</para>
			/// </summary>
			KDF_HASH_ALGORITHM = 0,

			/// <summary>
			/// The buffer is a KDF parameter that contains the value to add to the beginning of the message input to the hash function.
			/// </summary>
			KDF_SECRET_PREPEND = 1,

			/// <summary>The buffer is a KDF parameter that contains the value to add to the end of the message input to the hash function.</summary>
			KDF_SECRET_APPEND = 2,

			/// <summary>The buffer is a KDF parameter that contains the plain text value of the HMAC key.</summary>
			KDF_HMAC_KEY = 3,

			/// <summary>
			/// The buffer is a KDF parameter that contains an ANSI string that contains the transport layer security (TLS) pseudo-random
			/// function (PRF) label.
			/// </summary>
			KDF_TLS_PRF_LABEL = 4,

			/// <summary>The buffer is a KDF parameter that contains the PRF seed value. The seed must be 64 bytes long.</summary>
			KDF_TLS_PRF_SEED = 5,

			/// <summary>
			/// The buffer is a KDF parameter that contains the secret agreement handle. The pvBuffer member contains a BCRYPT_SECRET_HANDLE
			/// value and is not a pointer.
			/// </summary>
			KDF_SECRET_HANDLE = 6,

			/// <summary>
			/// The buffer is a KDF parameter that contains a DWORD value identifying the SSL/TLS protocol version whose PRF algorithm is to
			/// be used.
			/// </summary>
			KDF_TLS_PRF_PROTOCOL = 7,

			/// <summary>
			/// The buffer is a KDF parameter that contains the byte array to use as the AlgorithmID subfield of the OtherInfo parameter to
			/// the SP 800-56A KDF.
			/// </summary>
			KDF_ALGORITHMID = 8,

			/// <summary>
			/// The buffer is a KDF parameter that contains the byte array to use as the PartyUInfo subfield of the OtherInfo parameter to
			/// the SP 800-56A KDF.
			/// </summary>
			KDF_PARTYUINFO = 9,

			/// <summary>
			/// The buffer is a KDF parameter that contains the byte array to use as the PartyVInfo subfield of the OtherInfo parameter to
			/// the SP 800-56A KDF.
			/// </summary>
			KDF_PARTYVINFO = 10,

			/// <summary>
			/// The buffer is a KDF parameter that contains the byte array to use as the SuppPubInfo subfield of the OtherInfo parameter to
			/// the SP 800-56A KDF.
			/// </summary>
			KDF_SUPPPUBINFO = 11,

			/// <summary>
			/// The buffer is a KDF parameter that contains the byte array to use as the SuppPrivInfo subfield of the OtherInfo parameter to
			/// the SP 800-56A KDF.
			/// </summary>
			KDF_SUPPPRIVINFO = 12,

			/// <summary>Undocumented.</summary>
			KDF_LABEL = 0xD,

			/// <summary>Undocumented.</summary>
			KDF_CONTEXT = 0xE,

			/// <summary>Undocumented.</summary>
			KDF_SALT = 0xF,

			/// <summary>Undocumented.</summary>
			KDF_ITERATION_COUNT = 0x10,

			/// <summary>Undocumented.</summary>
			KDF_GENERIC_PARAMETER = 0x11,

			/// <summary>Undocumented.</summary>
			KDF_KEYBITLENGTH = 0x12,

			/// <summary>Undocumented.</summary>
			KDF_HKDF_SALT = 0x13,

			/// <summary>Undocumented.</summary>
			KDF_HKDF_INFO = 0x14,

			/// <summary>The buffer contains the random number of the SSL client.</summary>
			NCRYPTBUFFER_SSL_CLIENT_RANDOM = 20,

			/// <summary>The buffer contains the random number of the SSL server.</summary>
			NCRYPTBUFFER_SSL_SERVER_RANDOM = 21,

			/// <summary>The buffer contains the highest SSL version supported.</summary>
			NCRYPTBUFFER_SSL_HIGHEST_VERSION = 22,

			/// <summary>The buffer contains the clear portion of the SSL master key.</summary>
			NCRYPTBUFFER_SSL_CLEAR_KEY = 23,

			/// <summary>The buffer contains the SSL key argument data.</summary>
			NCRYPTBUFFER_SSL_KEY_ARG_DATA = 24,

			/// <summary>Undocumented.</summary>
			NCRYPTBUFFER_SSL_SESSION_HASH = 25,

			/// <summary>The buffer contains a null-terminated ANSI string that contains the PKCS object identifier.</summary>
			NCRYPTBUFFER_PKCS_OID = 40,

			/// <summary>The buffer contains a null-terminated ANSI string that contains the PKCS algorithm object identifier.</summary>
			NCRYPTBUFFER_PKCS_ALG_OID = 41,

			/// <summary>The buffer contains the PKCS algorithm parameters.</summary>
			NCRYPTBUFFER_PKCS_ALG_PARAM = 42,

			/// <summary>The buffer contains the PKCS algorithm identifier.</summary>
			NCRYPTBUFFER_PKCS_ALG_ID = 43,

			/// <summary>The buffer contains the PKCS attributes.</summary>
			NCRYPTBUFFER_PKCS_ATTRS = 44,

			/// <summary>The buffer contains a null-terminated Unicode string that contains the key name.</summary>
			NCRYPTBUFFER_PKCS_KEY_NAME = 45,

			/// <summary>
			/// The buffer contains a null-terminated Unicode string that contains the PKCS8 password. This parameter is optional and can be NULL.
			/// </summary>
			NCRYPTBUFFER_PKCS_SECRET = 46,

			/// <summary>
			/// The buffer contains a serialized certificate store that contains the PKCS certificate. This serialized store is obtained by
			/// using the CertSaveStore function with the CERT_STORE_SAVE_TO_MEMORY option. When this property is being retrieved, you can
			/// access the certificate store by passing this serialized store to the CertOpenStore function with the
			/// CERT_STORE_PROV_SERIALIZED option.
			/// </summary>
			NCRYPTBUFFER_CERT_BLOB = 47,

			/// <summary>Undocumented.</summary>
			NCRYPTBUFFER_CLAIM_IDBINDING_NONCE = 48,

			/// <summary>Undocumented.</summary>
			NCRYPTBUFFER_CLAIM_KEYATTESTATION_NONCE = 49,

			/// <summary>Undocumented.</summary>
			NCRYPTBUFFER_KEY_PROPERTY_FLAGS = 50,

			/// <summary>Undocumented.</summary>
			NCRYPTBUFFER_ATTESTATIONSTATEMENT_BLOB = 51,

			/// <summary>Undocumented.</summary>
			NCRYPTBUFFER_ATTESTATION_CLAIM_TYPE = 52,

			/// <summary>Undocumented.</summary>
			NCRYPTBUFFER_ATTESTATION_CLAIM_CHALLENGE_REQUIRED = 53,

			/// <summary>Undocumented.</summary>
			NCRYPTBUFFER_VSM_KEY_ATTESTATION_CLAIM_RESTRICTIONS = 54,

			/// <summary>Undocumented.</summary>
			NCRYPTBUFFER_ECC_CURVE_NAME = 60,

			/// <summary>Undocumented.</summary>
			NCRYPTBUFFER_ECC_PARAMETERS = 61,

			/// <summary>Undocumented.</summary>
			NCRYPTBUFFER_TPM_SEAL_PASSWORD = 70,

			/// <summary>Undocumented.</summary>
			NCRYPTBUFFER_TPM_SEAL_POLICYINFO = 71,

			/// <summary>Undocumented.</summary>
			NCRYPTBUFFER_TPM_SEAL_TICKET = 72,

			/// <summary>Undocumented.</summary>
			NCRYPTBUFFER_TPM_SEAL_NO_DA_PROTECTION = 73,

			/// <summary>Undocumented.</summary>
			NCRYPTBUFFER_TPM_PLATFORM_CLAIM_PCR_MASK = 80,

			/// <summary>Undocumented.</summary>
			NCRYPTBUFFER_TPM_PLATFORM_CLAIM_NONCE = 81,

			/// <summary>Undocumented.</summary>
			NCRYPTBUFFER_TPM_PLATFORM_CLAIM_STATIC_CREATE = 82,
		}

		/// <summary>Flags for <c>NCryptKeyDerivation</c>.</summary>
		[PInvokeData("ncrypt.h", MSDNShortId = "5D2D61B1-022E-412F-A19E-11057930A615")]
		[Flags]
		public enum KeyDerivationFlags
		{
			/// <summary>
			/// Specifies that the target algorithm is AES and that the key therefore must be double expanded. This flag is only valid with
			/// the CAPI_KDF algorithm.
			/// </summary>
			BCRYPT_CAPI_AES_FLAG = 0x00000010,

			/// <summary>
			/// Requests that the key service provider (KSP) not display any user interface. If the provider must display the UI to operate,
			/// the call fails and the KSP should set the NTE_SILENT_CONTEXT error code as the last error.
			/// </summary>
			NCRYPT_SILENT_FLAG = 0x00000040,
		}

		/// <summary>A set of flags that define the usage details for a key. This property only applies to keys.</summary>
		[PInvokeData("ncrypt.h")]
		[Flags]
		public enum KeyUsage
		{
			/// <summary>The key can be used for decryption.</summary>
			NCRYPT_ALLOW_DECRYPT_FLAG = 0x00000001,

			/// <summary>The key can be used for signing.</summary>
			NCRYPT_ALLOW_SIGNING_FLAG = 0x00000002,

			/// <summary>The key can be used for secret agreement encryption.</summary>
			NCRYPT_ALLOW_KEY_AGREEMENT_FLAG = 0x00000004,

			/// <summary>The key can be used for any purpose.</summary>
			NCRYPT_ALLOW_ALL_USAGES = 0x00ffffff,

			/// <summary>Undocumented.</summary>
			NCRYPT_ALLOW_KEY_IMPORT_FLAG = 0x00000008,
		}

		/// <summary>Flags that modify function behavior. The allowed set of flags depends on the type of key specified by the hKey parameter.</summary>
		[PInvokeData("ncrypt.h", MSDNShortId = "02c309bc-8c94-4c0f-901f-e024c83c824a")]
		[Flags]
		public enum NCryptDecryptFlag
		{
			/// <summary>No padding was used when the data was encrypted. The pPaddingInfo parameter is not used.</summary>
			NCRYPT_NO_PADDING_FLAG = 0x00000001,

			/// <summary>
			/// The data was padded with a random number to round out the block size when the data was encrypted. The pPaddingInfo parameter
			/// is not used.
			/// </summary>
			NCRYPT_PAD_PKCS1_FLAG = 0x00000002,

			/// <summary>
			/// The Optimal Asymmetric Encryption Padding (OAEP) scheme was used when the data was encrypted. The pPaddingInfo parameter is a
			/// pointer to a BCRYPT_OAEP_PADDING_INFO structure.
			/// </summary>
			NCRYPT_PAD_OAEP_FLAG = 0x00000004,

			/// <summary>
			/// The Probabilistic Signature Scheme (PSS) padding scheme was used when the signature was created. The pPaddingInfo parameter
			/// is a pointer to a BCRYPT_PSS_PADDING_INFO structure.
			/// </summary>
			NCRYPT_PAD_PSS_FLAG = 0x00000008,

			/// <summary/>
			NCRYPT_PAD_CIPHER_FLAG = 0x00000010,

			/// <summary/>
			NCRYPT_ATTESTATION_FLAG = 0x00000020,

			/// <summary>
			/// Requests that the key service provider (KSP) not display any user interface. If the provider must display the UI to operate,
			/// the call fails and the KSP should set the NTE_SILENT_CONTEXT error code as the last error.
			/// </summary>
			NCRYPT_SILENT_FLAG = 0x00000040,

			/// <summary/>
			NCRYPT_SEALING_FLAG = 0x00000100,
		}

		/// <summary>Flags for NCrypt functions that can show a UI.</summary>
		[PInvokeData("ncrypt.h")]
		[Flags]
		public enum NCryptUIFlags : uint
		{
			/// <summary>
			/// Requests that the key service provider (KSP) not display any user interface. If the provider must display the UI to operate,
			/// the call fails and the KSP should set the NTE_SILENT_CONTEXT error code as the last error.
			/// </summary>
			NCRYPT_SILENT_FLAG = 0x00000040,
		}

		/// <summary>Flags used with <c>NCryptOpenKey</c>.</summary>
		[Flags]
		public enum OpenKeyFlags
		{
			/// <summary>
			/// Requests that the key service provider (KSP) not display any user interface. If the provider must display the UI to operate,
			/// the call fails and the KSP should set the NTE_SILENT_CONTEXT error code as the last error.
			/// </summary>
			NCRYPT_SILENT_FLAG = 0x00000040,

			/// <summary>Open the key for the local computer. If this flag is not present, the current user key is opened.</summary>
			NCRYPT_MACHINE_KEY_FLAG = 0x00000020,
		}

		/// <summary>Used by <c>NCryptSetProperty</c>.</summary>
		[PInvokeData("ncrypt.h", MSDNShortId = "ad1148aa-5f64-4867-9e17-6b41cc0c20b7")]
		[Flags]
		public enum SetPropFlags : uint
		{
			/// <summary>
			/// Requests that the key service provider (KSP) not display any user interface. If the provider must display the UI to operate,
			/// the call fails and the KSP should set the NTE_SILENT_CONTEXT error code as the last error.
			/// </summary>
			NCRYPT_SILENT_FLAG = 0x00000040,

			/// <summary>
			/// Do not overwrite any built-in values for this property and only set the user-persisted properties of the key. The maximum
			/// size of the data for any persisted property is NCRYPT_MAX_PROPERTY_DATA bytes. This flag cannot be used with the
			/// NCRYPT_SECURITY_DESCR_PROPERTY property.
			/// </summary>
			NCRYPT_PERSIST_ONLY_FLAG = 0x40000000,

			/// <summary>
			/// The property should be stored in key storage along with the key material. This flag can only be used when the hObject
			/// parameter is the handle of a persisted key. The maximum size of the data for any persisted property is
			/// NCRYPT_MAX_PROPERTY_DATA bytes.
			/// </summary>
			NCRYPT_PERSIST_FLAG = 0x80000000,
		}

		/// <summary>A set of flags that provide additional user interface information or requirements.</summary>
		[PInvokeData("ncrypt.h")]
		[Flags]
		public enum UIPolicy
		{
			/// <summary>Display the strong key user interface as needed.</summary>
			NCRYPT_UI_PROTECT_KEY_FLAG = 0x00000001,

			/// <summary>Force high protection.</summary>
			NCRYPT_UI_FORCE_HIGH_PROTECTION_FLAG = 0x00000002,

			/// <summary>Undocumented.</summary>
			NCRYPT_UI_FINGERPRINT_PROTECTION_FLAG = 0x00000004,

			/// <summary>
			/// An app container has accessed a medium key that is not strongly protected. For example, a key that is for user consent only,
			/// or is password or fingerprint protected.
			/// </summary>
			NCRYPT_UI_APPCONTAINER_ACCESS_MEDIUM_FLAG = 0x00000008,
		}

		[Flags]
		private enum EncryptFlags : uint
		{
			NCRYPT_NO_PADDING_FLAG = 0x00000001,
			NCRYPT_PAD_PKCS1_FLAG = 0x00000002,
			NCRYPT_PAD_OAEP_FLAG = 0x00000004,
			NCRYPT_PAD_PSS_FLAG = 0x00000008,
			NCRYPT_PAD_CIPHER_FLAG = 0x00000010,
			NCRYPT_ATTESTATION_FLAG = 0x00000020,
			NCRYPT_SEALING_FLAG = 0x00000100,
		}

		[Flags]
		private enum NFlags : uint
		{
			NCRYPT_NAMED_DESCRIPTOR_FLAG = 0x00000001,
			NCRYPT_REGISTER_NOTIFY_FLAG = 0x00000001,
			NCRYPT_UNREGISTER_NOTIFY_FLAG = 0x00000002,
			NCRYPT_MACHINE_KEY_FLAG = 0x00000020,
			NCRYPT_OVERWRITE_KEY_FLAG = 0x00000080,
			NCRYPT_DO_NOT_FINALIZE_FLAG = 0x00000400,
			NCRYPT_EXPORT_LEGACY_FLAG = 0x00000800,
			NCRYPT_IGNORE_DEVICE_STATE_FLAG = 0x00001000,
			NCRYPT_TREAT_NIST_AS_GENERIC_ECC_FLAG = 0x00002000,
			NCRYPT_NO_CACHED_PASSWORD = 0x00004000,
			NCRYPT_PROTECT_TO_LOCAL_SYSTEM = 0x00008000,
			NCRYPT_WRITE_KEY_TO_LEGACY_STORE_FLAG = 0x00000200,
			NCRYPT_NO_KEY_VALIDATION = 0x00000008,
			NCRYPT_SILENT_FLAG = 0x00000040,
			NCRYPT_PERSIST_ONLY_FLAG = 0x40000000,
			NCRYPT_PERSIST_FLAG = 0x80000000,
			NCRYPT_PREFER_VIRTUAL_ISOLATION_FLAG = 0x00010000,
			NCRYPT_USE_VIRTUAL_ISOLATION_FLAG = 0x00020000,
			NCRYPT_USE_PER_BOOT_KEY_FLAG = 0x00040000,
		}

		/// <summary>
		/// <para>
		/// [Some information relates to pre-released product which may be substantially modified before it's commercially released.
		/// Microsoft makes no warranties, express or implied, with respect to the information provided here.]
		/// </para>
		/// <para>Creates a key attestation claim.</para>
		/// </summary>
		/// <param name="hSubjectKey">The subject key handle that the claim is created for.</param>
		/// <param name="hAuthorityKey">The authority key handle that the claim is based on.</param>
		/// <param name="dwClaimType">The type of claim.</param>
		/// <param name="pParameterList">An optional parameter list.</param>
		/// <param name="pbClaimBlob">Output of the created claim blob.</param>
		/// <param name="cbClaimBlob"/>
		/// <param name="pcbResult">The output of the created claim blob.</param>
		/// <param name="dwFlags">As of Windows 10, no flags are defined. This parameter should be set to 0.</param>
		/// <returns>Returns a status code that indicates the success or failure of the function.</returns>
		// https://docs.microsoft.com/en-us/windows/win32/api/ncrypt/nf-ncrypt-ncryptcreateclaim SECURITY_STATUS NCryptCreateClaim(
		// NCRYPT_KEY_HANDLE hSubjectKey, NCRYPT_KEY_HANDLE hAuthorityKey, DWORD dwClaimType, NCryptBufferDesc *pParameterList, PBYTE
		// pbClaimBlob, DWORD cbClaimBlob, DWORD *pcbResult, DWORD dwFlags );
		[DllImport(Lib.Ncrypt, SetLastError = false, ExactSpelling = true)]
		[PInvokeData("ncrypt.h", MSDNShortId = "EBEE3A67-0693-4B85-88B1-580CB2152703")]
		public static extern HRESULT NCryptCreateClaim(NCRYPT_KEY_HANDLE hSubjectKey, NCRYPT_KEY_HANDLE hAuthorityKey, uint dwClaimType, [Optional] NCryptBufferDesc[] pParameterList, IntPtr pbClaimBlob, uint cbClaimBlob, out uint pcbResult, uint dwFlags = 0);

		/// <summary>
		/// The <c>NCryptCreatePersistedKey</c> function creates a new key and stores it in the specified key storage provider. After you
		/// create a key by using this function, you can use the NCryptSetProperty function to set its properties; however, the key cannot be
		/// used until the NCryptFinalizeKey function is called.
		/// </summary>
		/// <param name="hProvider">
		/// The handle of the key storage provider to create the key in. This handle is obtained by using the NCryptOpenStorageProvider function.
		/// </param>
		/// <param name="phKey">
		/// The address of an <c>NCRYPT_KEY_HANDLE</c> variable that receives the handle of the key. When you have finished using this
		/// handle, release it by passing it to the NCryptFreeObject function.
		/// </param>
		/// <param name="pszAlgId">
		/// A pointer to a null-terminated Unicode string that contains the identifier of the cryptographic algorithm to create the key. This
		/// can be one of the standard CNG Algorithm Identifiers or the identifier for another registered algorithm.
		/// </param>
		/// <param name="pszKeyName">
		/// A pointer to a null-terminated Unicode string that contains the name of the key. If this parameter is <c>NULL</c>, this function
		/// will create an ephemeral key that is not persisted.
		/// </param>
		/// <param name="dwLegacyKeySpec">
		/// <para>A legacy identifier that specifies the type of key. This can be one of the following values.</para>
		/// <list type="table">
		/// <listheader>
		/// <term>Value</term>
		/// <term>Meaning</term>
		/// </listheader>
		/// <item>
		/// <term>AT_KEYEXCHANGE</term>
		/// <term>The key is a key exchange key.</term>
		/// </item>
		/// <item>
		/// <term>AT_SIGNATURE</term>
		/// <term>The key is a signature key.</term>
		/// </item>
		/// <item>
		/// <term>0</term>
		/// <term>The key is none of the above types.</term>
		/// </item>
		/// </list>
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
		/// <term>NCRYPT_MACHINE_KEY_FLAG</term>
		/// <term>The key applies to the local computer. If this flag is not present, the key applies to the current user.</term>
		/// </item>
		/// <item>
		/// <term>NCRYPT_OVERWRITE_KEY_FLAG</term>
		/// <term>
		/// If a key already exists in the container with the specified name, the existing key will be overwritten. If this flag is not
		/// specified and a key with the specified name already exists, this function will return NTE_EXISTS.
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
		/// <term>ERROR_SUCCESS</term>
		/// <term>The function was successful.</term>
		/// </item>
		/// <item>
		/// <term>NTE_BAD_FLAGS</term>
		/// <term>The dwFlags parameter contains a value that is not valid.</term>
		/// </item>
		/// <item>
		/// <term>NTE_EXISTS</term>
		/// <term>A key with the specified name already exists and the NCRYPT_OVERWRITE_KEY_FLAG was not specified.</term>
		/// </item>
		/// <item>
		/// <term>NTE_INVALID_HANDLE</term>
		/// <term>The hProvider parameter is not valid.</term>
		/// </item>
		/// <item>
		/// <term>NTE_INVALID_PARAMETER</term>
		/// <term>One or more parameters are not valid.</term>
		/// </item>
		/// <item>
		/// <term>NTE_NO_MEMORY</term>
		/// <term>A memory allocation failure occurred.</term>
		/// </item>
		/// </list>
		/// </returns>
		/// <remarks>
		/// <para>
		/// If you are creating an RSA key pair, you can also have the key stored in legacy storage so that it can be used with the CryptoAPI
		/// by passing the <c>NCRYPT_WRITE_KEY_TO_LEGACY_STORE_FLAG</c> flag to the NCryptFinalizeKey function when the key is finalized.
		/// </para>
		/// <para>
		/// A service must not call this function from its StartService Function. If a service calls this function from its StartService
		/// function, a deadlock can occur, and the service may stop responding.
		/// </para>
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows/desktop/api/ncrypt/nf-ncrypt-ncryptcreatepersistedkey SECURITY_STATUS
		// NCryptCreatePersistedKey( NCRYPT_PROV_HANDLE hProvider, NCRYPT_KEY_HANDLE *phKey, LPCWSTR pszAlgId, LPCWSTR pszKeyName, DWORD
		// dwLegacyKeySpec, DWORD dwFlags );
		[DllImport(Lib.Ncrypt, SetLastError = false, ExactSpelling = true, CharSet = CharSet.Unicode)]
		[PInvokeData("ncrypt.h", MSDNShortId = "eeb1842f-fd9e-4edf-9db8-7b4e91760e9b")]
		public static extern HRESULT NCryptCreatePersistedKey(NCRYPT_PROV_HANDLE hProvider, out SafeNCRYPT_KEY_HANDLE phKey, string pszAlgId, [Optional] string pszKeyName, Crypt32.PrivateKeyType dwLegacyKeySpec = 0, CreatePersistedFlags dwFlags = 0);

		/// <summary>The <c>NCryptDecrypt</c> function decrypts a block of encrypted data.</summary>
		/// <param name="hKey">The handle of the key to use to decrypt the data.</param>
		/// <param name="pbInput">
		/// The address of a buffer that contains the data to be decrypted. The cbInput parameter contains the size of the data to decrypt.
		/// For more information, see Remarks.
		/// </param>
		/// <param name="cbInput">The number of bytes in the pbInput buffer to decrypt.</param>
		/// <param name="pPaddingInfo">
		/// A pointer to a structure that contains padding information. The actual type of structure this parameter points to depends on the
		/// value of the dwFlags parameter. This parameter is only used with asymmetric keys and must be <c>NULL</c> otherwise.
		/// </param>
		/// <param name="pbOutput">
		/// <para>
		/// The address of a buffer that will receive the decrypted data produced by this function. The cbOutput parameter contains the size
		/// of this buffer. For more information, see Remarks.
		/// </para>
		/// <para>
		/// If this parameter is <c>NULL</c>, this function will calculate the size needed for the decrypted data and return the size in the
		/// location pointed to by the pcbResult parameter.
		/// </para>
		/// </param>
		/// <param name="cbOutput">The size, in bytes, of the pbOutput buffer. This parameter is ignored if the pbOutput parameter is <c>NULL</c>.</param>
		/// <param name="pcbResult">
		/// A pointer to a <c>DWORD</c> variable that receives the number of bytes copied to the pbOutput buffer. If pbOutput is <c>NULL</c>,
		/// this receives the size, in bytes, required for the decrypted data.
		/// </param>
		/// <param name="dwFlags">
		/// <para>Flags that modify function behavior. The allowed set of flags depends on the type of key specified by the hKey parameter.</para>
		/// <para>If the key is an asymmetric key, this can be one of the following values.</para>
		/// <list type="table">
		/// <listheader>
		/// <term>Value</term>
		/// <term>Meaning</term>
		/// </listheader>
		/// <item>
		/// <term>NCRYPT_NO_PADDING_FLAG</term>
		/// <term>No padding was used when the data was encrypted. The pPaddingInfo parameter is not used.</term>
		/// </item>
		/// <item>
		/// <term>NCRYPT_PAD_OAEP_FLAG</term>
		/// <term>
		/// The Optimal Asymmetric Encryption Padding (OAEP) scheme was used when the data was encrypted. The pPaddingInfo parameter is a
		/// pointer to a BCRYPT_OAEP_PADDING_INFO structure.
		/// </term>
		/// </item>
		/// <item>
		/// <term>NCRYPT_PAD_PKCS1_FLAG</term>
		/// <term>
		/// The data was padded with a random number to round out the block size when the data was encrypted. The pPaddingInfo parameter is
		/// not used.
		/// </term>
		/// </item>
		/// </list>
		/// <para>The following value can be used for any key.</para>
		/// <list type="table">
		/// <listheader>
		/// <term>Value</term>
		/// <term>Meaning</term>
		/// </listheader>
		/// <item>
		/// <term>NCRYPT_SILENT_FLAG</term>
		/// <term>
		/// Requests that the key service provider (KSP) not display any user interface. If the provider must display the UI to operate, the
		/// call fails and the KSP should set the NTE_SILENT_CONTEXT error code as the last error.
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
		/// <term>ERROR_SUCCESS</term>
		/// <term>The function was successful.</term>
		/// </item>
		/// <item>
		/// <term>NTE_BAD_FLAGS</term>
		/// <term>The dwFlags parameter contains a value that is not valid.</term>
		/// </item>
		/// <item>
		/// <term>NTE_BUFFER_TOO_SMALL</term>
		/// <term>The size specified by the cbOutput parameter is not large enough to hold the decrypted data.</term>
		/// </item>
		/// <item>
		/// <term>NTE_INVALID_HANDLE</term>
		/// <term>The hKey parameter is not valid.</term>
		/// </item>
		/// <item>
		/// <term>NTE_INVALID_PARAMETER</term>
		/// <term>One or more parameters are not valid.</term>
		/// </item>
		/// <item>
		/// <term>NTE_PERM</term>
		/// <term>The key identified by the hKey parameter cannot be used for decryption.</term>
		/// </item>
		/// </list>
		/// </returns>
		/// <remarks>
		/// <para>
		/// The pbInput and pbOutput parameters can point to the same buffer. In this case, this function will perform the decryption in place.
		/// </para>
		/// <para>
		/// A service must not call this function from its StartService Function. If a service calls this function from its StartService
		/// function, a deadlock can occur, and the service may stop responding.
		/// </para>
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows/win32/api/ncrypt/nf-ncrypt-ncryptdecrypt SECURITY_STATUS NCryptDecrypt( NCRYPT_KEY_HANDLE
		// hKey, PBYTE pbInput, DWORD cbInput, VOID *pPaddingInfo, PBYTE pbOutput, DWORD cbOutput, DWORD *pcbResult, DWORD dwFlags );
		[DllImport(Lib.Ncrypt, SetLastError = false, ExactSpelling = true)]
		[PInvokeData("ncrypt.h", MSDNShortId = "02c309bc-8c94-4c0f-901f-e024c83c824a")]
		public static extern HRESULT NCryptDecrypt(NCRYPT_KEY_HANDLE hKey, IntPtr pbInput, uint cbInput, IntPtr pPaddingInfo, IntPtr pbOutput, uint cbOutput, out uint pcbResult, NCryptDecryptFlag dwFlags);

		/// <summary>The <c>NCryptDeleteKey</c> function deletes a CNG key.</summary>
		/// <param name="hKey">
		/// <para>The handle of the key to delete. This handle is obtained by using the NCryptOpenKey function.</para>
		/// <para>
		/// <c>Note</c> The <c>NCryptDeleteKey</c> function frees the handle. Applications must not use the handle or attempt to call the
		/// NCryptFreeObject function on it after calling the <c>NCryptDeleteKey</c> function.
		/// </para>
		/// </param>
		/// <param name="dwFlags">
		/// <para>
		/// Flags that modify function behavior. This can be zero or a combination of values that is specific to each key storage provider.
		/// </para>
		/// <list type="table">
		/// <listheader>
		/// <term>Value</term>
		/// <term>Meaning</term>
		/// </listheader>
		/// <item>
		/// <term>NCRYPT_SILENT_FLAG</term>
		/// <term>
		/// Requests that the key service provider (KSP) not display any user interface. If the provider must display the UI to operate, the
		/// call fails and the KSP should set the NTE_SILENT_CONTEXT error code as the last error.
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
		/// <term>ERROR_SUCCESS</term>
		/// <term>The function was successful.</term>
		/// </item>
		/// <item>
		/// <term>NTE_BAD_FLAGS</term>
		/// <term>The dwFlags parameter contains a value that is not valid.</term>
		/// </item>
		/// <item>
		/// <term>NTE_INVALID_HANDLE</term>
		/// <term>The hKey parameter is not valid.</term>
		/// </item>
		/// </list>
		/// </returns>
		/// <remarks>
		/// A service must not call this function from its StartService Function. If a service calls this function from its StartService
		/// function, a deadlock can occur, and the service may stop responding.
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows/desktop/api/ncrypt/nf-ncrypt-ncryptdeletekey SECURITY_STATUS NCryptDeleteKey(
		// NCRYPT_KEY_HANDLE hKey, DWORD dwFlags );
		[DllImport(Lib.Ncrypt, SetLastError = false, ExactSpelling = true)]
		[PInvokeData("ncrypt.h", MSDNShortId = "2e1958a7-51e0-4731-b4cf-a90d6c1f9ae0")]
		public static extern HRESULT NCryptDeleteKey(NCRYPT_KEY_HANDLE hKey, NCryptUIFlags dwFlags = 0);

		/// <summary>
		/// <para>
		/// The <c>NCryptDeriveKey</c> function derives a key from a secret agreement value. This function is intended to be used as part of
		/// a secret agreement procedure using persisted secret agreement keys. To derive key material by using a persisted secret instead,
		/// use the NCryptKeyDerivation function.
		/// </para>
		/// </summary>
		/// <param name="hSharedSecret">
		/// <para>The secret agreement handle to create the key from. This handle is obtained from the NCryptSecretAgreement function.</para>
		/// </param>
		/// <param name="pwszKDF">
		/// <para>
		/// A pointer to a null-terminated Unicode string that identifies the key derivation function (KDF) to use to derive the key. This
		/// can be one of the following strings.
		/// </para>
		/// <para>BCRYPT_KDF_HASH (L"HASH")</para>
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
		/// <para>BCRYPT_KDF_HMAC (L"HMAC")</para>
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
		/// <para>BCRYPT_KDF_TLS_PRF (L"TLS_PRF")</para>
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
		/// </list>
		/// <para>The call to the KDF is made as shown in the following pseudocode.</para>
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
		/// <para><c>Windows Server 2008, Windows Vista, Windows Server 2003 and Windows XP:</c> This value is not supported.</para>
		/// </param>
		/// <param name="pParameterList">
		/// <para>
		/// The address of a NCryptBufferDesc structure that contains the KDF parameters. This parameter is optional and can be <c>NULL</c>
		/// if it is not needed.
		/// </para>
		/// </param>
		/// <param name="pbDerivedKey">
		/// <para>
		/// The address of a buffer that receives the key. The cbDerivedKey parameter contains the size of this buffer. If this parameter is
		/// <c>NULL</c>, this function will place the required size, in bytes, in the <c>DWORD</c> pointed to by the pcbResult parameter.
		/// </para>
		/// </param>
		/// <param name="cbDerivedKey">
		/// <para>The size, in bytes, of the pbDerivedKey buffer.</para>
		/// </param>
		/// <param name="pcbResult">
		/// <para>
		/// A pointer to a <c>DWORD</c> that receives the number of bytes that were copied to the pbDerivedKey buffer. If the pbDerivedKey
		/// parameter is <c>NULL</c>, this function will place the required size, in bytes, in the <c>DWORD</c> pointed to by this parameter.
		/// </para>
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
		/// <term>ERROR_SUCCESS</term>
		/// <term>The function was successful.</term>
		/// </item>
		/// <item>
		/// <term>NTE_INVALID_HANDLE</term>
		/// <term>The hSharedSecret parameter is not valid.</term>
		/// </item>
		/// <item>
		/// <term>NTE_INVALID_PARAMETER</term>
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
		/// A service must not call this function from its StartService Function. If a service calls this function from its StartService
		/// function, a deadlock can occur, and the service may stop responding.
		/// </para>
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows/desktop/api/ncrypt/nf-ncrypt-ncryptderivekey SECURITY_STATUS NCryptDeriveKey(
		// NCRYPT_SECRET_HANDLE hSharedSecret, LPCWSTR pwszKDF, NCryptBufferDesc *pParameterList, PBYTE pbDerivedKey, DWORD cbDerivedKey,
		// DWORD *pcbResult, ULONG dwFlags );
		[DllImport(Lib.Ncrypt, SetLastError = false, ExactSpelling = true)]
		[PInvokeData("ncrypt.h", MSDNShortId = "0ff08c6a-5f30-43ca-9db8-cda3e0704b0a")]
		public static extern HRESULT NCryptDeriveKey(NCRYPT_SECRET_HANDLE hSharedSecret, [MarshalAs(UnmanagedType.LPWStr)] string pwszKDF, [Optional] NCryptBufferDesc pParameterList, SafeAllocatedMemoryHandle pbDerivedKey,
			uint cbDerivedKey, out uint pcbResult, BCrypt.DeriveKeyFlags dwFlags);

		/// <summary>
		/// <para>
		/// The <c>NCryptDeriveKey</c> function derives a key from a secret agreement value. This function is intended to be used as part of
		/// a secret agreement procedure using persisted secret agreement keys. To derive key material by using a persisted secret instead,
		/// use the NCryptKeyDerivation function.
		/// </para>
		/// </summary>
		/// <param name="hSharedSecret">
		/// <para>The secret agreement handle to create the key from. This handle is obtained from the NCryptSecretAgreement function.</para>
		/// </param>
		/// <param name="pwszKDF">
		/// <para>
		/// A pointer to a null-terminated Unicode string that identifies the key derivation function (KDF) to use to derive the key. This
		/// can be one of the following strings.
		/// </para>
		/// <para>BCRYPT_KDF_HASH (L"HASH")</para>
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
		/// <para>BCRYPT_KDF_HMAC (L"HMAC")</para>
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
		/// <para>BCRYPT_KDF_TLS_PRF (L"TLS_PRF")</para>
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
		/// </list>
		/// <para>The call to the KDF is made as shown in the following pseudocode.</para>
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
		/// <para><c>Windows Server 2008, Windows Vista, Windows Server 2003 and Windows XP:</c> This value is not supported.</para>
		/// </param>
		/// <param name="pParameterList">
		/// <para>
		/// The address of a NCryptBufferDesc structure that contains the KDF parameters. This parameter is optional and can be <c>NULL</c>
		/// if it is not needed.
		/// </para>
		/// </param>
		/// <param name="pbDerivedKey">
		/// <para>
		/// The address of a buffer that receives the key. The cbDerivedKey parameter contains the size of this buffer. If this parameter is
		/// <c>NULL</c>, this function will place the required size, in bytes, in the <c>DWORD</c> pointed to by the pcbResult parameter.
		/// </para>
		/// </param>
		/// <param name="cbDerivedKey">
		/// <para>The size, in bytes, of the pbDerivedKey buffer.</para>
		/// </param>
		/// <param name="pcbResult">
		/// <para>
		/// A pointer to a <c>DWORD</c> that receives the number of bytes that were copied to the pbDerivedKey buffer. If the pbDerivedKey
		/// parameter is <c>NULL</c>, this function will place the required size, in bytes, in the <c>DWORD</c> pointed to by this parameter.
		/// </para>
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
		/// <term>ERROR_SUCCESS</term>
		/// <term>The function was successful.</term>
		/// </item>
		/// <item>
		/// <term>NTE_INVALID_HANDLE</term>
		/// <term>The hSharedSecret parameter is not valid.</term>
		/// </item>
		/// <item>
		/// <term>NTE_INVALID_PARAMETER</term>
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
		/// A service must not call this function from its StartService Function. If a service calls this function from its StartService
		/// function, a deadlock can occur, and the service may stop responding.
		/// </para>
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows/desktop/api/ncrypt/nf-ncrypt-ncryptderivekey SECURITY_STATUS NCryptDeriveKey(
		// NCRYPT_SECRET_HANDLE hSharedSecret, LPCWSTR pwszKDF, NCryptBufferDesc *pParameterList, PBYTE pbDerivedKey, DWORD cbDerivedKey,
		// DWORD *pcbResult, ULONG dwFlags );
		[DllImport(Lib.Ncrypt, SetLastError = false, ExactSpelling = true)]
		[PInvokeData("ncrypt.h", MSDNShortId = "0ff08c6a-5f30-43ca-9db8-cda3e0704b0a")]
		public static extern HRESULT NCryptDeriveKey(NCRYPT_SECRET_HANDLE hSharedSecret, [MarshalAs(UnmanagedType.LPWStr)] string pwszKDF, [Optional] NCryptBufferDesc pParameterList, [Optional] IntPtr pbDerivedKey,
			[Optional] uint cbDerivedKey, out uint pcbResult, BCrypt.DeriveKeyFlags dwFlags);

		/// <summary>The <c>NCryptEncrypt</c> function encrypts a block of data.</summary>
		/// <param name="hKey">The handle of the key to use to encrypt the data.</param>
		/// <param name="pbInput">
		/// The address of a buffer that contains the data to be encrypted. The cbInput parameter contains the size of the data to encrypt.
		/// For more information, see Remarks.
		/// </param>
		/// <param name="cbInput">The number of bytes in the pbInput buffer to encrypt.</param>
		/// <param name="pPaddingInfo">
		/// A pointer to a structure that contains padding information. The actual type of structure this parameter points to depends on the
		/// value of the dwFlags parameter. This parameter is only used with asymmetric keys and must be <c>NULL</c> otherwise.
		/// </param>
		/// <param name="pbOutput">
		/// <para>
		/// The address of a buffer that will receive the encrypted data produced by this function. The cbOutput parameter contains the size
		/// of this buffer. For more information, see Remarks.
		/// </para>
		/// <para>
		/// If this parameter is <c>NULL</c>, this function will calculate the size needed for the encrypted data and return the size in the
		/// location pointed to by the pcbResult parameter.
		/// </para>
		/// </param>
		/// <param name="cbOutput">The size, in bytes, of the pbOutput buffer. This parameter is ignored if the pbOutput parameter is <c>NULL</c>.</param>
		/// <param name="pcbResult">
		/// A pointer to a <c>DWORD</c> variable that receives the number of bytes copied to the pbOutput buffer. If pbOutput is <c>NULL</c>,
		/// this receives the size, in bytes, required for the ciphertext.
		/// </param>
		/// <param name="dwFlags">
		/// <para>Flags that modify function behavior. The allowed set of flags depends on the type of key specified by the hKey parameter.</para>
		/// <para>If the key is an asymmetric key, this can be one of the following values.</para>
		/// <list type="table">
		/// <listheader>
		/// <term>Value</term>
		/// <term>Meaning</term>
		/// </listheader>
		/// <item>
		/// <term>NCRYPT_NO_PADDING_FLAG</term>
		/// <term>
		/// Do not use any padding. The pPaddingInfo parameter is not used. If you specify the NCRYPT_NO_PADDING_FLAG, then the NCryptEncrypt
		/// function only encrypts the first N bits, where N is the length of the key that was passed as the hKey parameter. Any bits after
		/// the first N bits are ignored.
		/// </term>
		/// </item>
		/// <item>
		/// <term>NCRYPT_PAD_OAEP_FLAG</term>
		/// <term>
		/// Use the Optimal Asymmetric Encryption Padding (OAEP) scheme. The pPaddingInfo parameter is a pointer to a
		/// BCRYPT_OAEP_PADDING_INFO structure.
		/// </term>
		/// </item>
		/// <item>
		/// <term>NCRYPT_PAD_PKCS1_FLAG</term>
		/// <term>The data will be padded with a random number to round out the block size. The pPaddingInfo parameter is not used.</term>
		/// </item>
		/// <item>
		/// <term>NCRYPT_SILENT_FLAG</term>
		/// <term>
		/// Requests that the key service provider (KSP) not display any user interface. If the provider must display the UI to operate, the
		/// call fails and the KSP should set the NTE_SILENT_CONTEXT error code as the last error.
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
		/// <term>ERROR_SUCCESS</term>
		/// <term>The function was successful.</term>
		/// </item>
		/// <item>
		/// <term>NTE_BAD_FLAGS</term>
		/// <term>The dwFlags parameter contains a value that is not valid.</term>
		/// </item>
		/// <item>
		/// <term>NTE_BAD_KEY_STATE</term>
		/// <term>The key identified by the hKey parameter has not been finalized or is incomplete.</term>
		/// </item>
		/// <item>
		/// <term>NTE_BUFFER_TOO_SMALL</term>
		/// <term>The size specified by the cbOutput parameter is not large enough to hold the encrypted data.</term>
		/// </item>
		/// <item>
		/// <term>NTE_INVALID_HANDLE</term>
		/// <term>The hKey parameter is not valid.</term>
		/// </item>
		/// <item>
		/// <term>NTE_INVALID_PARAMETER</term>
		/// <term>One or more parameters are not valid.</term>
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
		/// A service must not call this function from its StartService Function. If a service calls this function from its StartService
		/// function, a deadlock can occur, and the service may stop responding.
		/// </para>
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows/win32/api/ncrypt/nf-ncrypt-ncryptencrypt SECURITY_STATUS NCryptEncrypt( NCRYPT_KEY_HANDLE
		// hKey, PBYTE pbInput, DWORD cbInput, VOID *pPaddingInfo, PBYTE pbOutput, DWORD cbOutput, DWORD *pcbResult, DWORD dwFlags );
		[DllImport(Lib.Ncrypt, SetLastError = false, ExactSpelling = true)]
		[PInvokeData("ncrypt.h", MSDNShortId = "837fc720-2167-4ead-86ea-2c3d438f2530")]
		public static extern HRESULT NCryptEncrypt(NCRYPT_KEY_HANDLE hKey, IntPtr pbInput, uint cbInput, IntPtr pPaddingInfo, IntPtr pbOutput, uint cbOutput, out uint pcbResult, NCryptDecryptFlag dwFlags);

		/// <summary>
		/// The <c>NCryptEnumAlgorithms</c> function obtains the names of the algorithms that are supported by the specified key storage provider.
		/// </summary>
		/// <param name="hProvider">
		/// The handle of the key storage provider to enumerate the algorithms for. This handle is obtained with the
		/// NCryptOpenStorageProvider function.
		/// </param>
		/// <param name="dwAlgOperations">
		/// <para>
		/// A set of values that determine which algorithm classes to enumerate. This can be zero or a combination of one or more of the
		/// following values. If dwAlgOperations is zero, all algorithms are enumerated.
		/// </para>
		/// <list type="table">
		/// <listheader>
		/// <term>Value</term>
		/// <term>Meaning</term>
		/// </listheader>
		/// <item>
		/// <term>NCRYPT_CIPHER_OPERATION 0x00000001</term>
		/// <term>Enumerate the cipher (symmetric encryption) algorithms.</term>
		/// </item>
		/// <item>
		/// <term>NCRYPT_HASH_OPERATION 0x00000002</term>
		/// <term>Enumerate the hashing algorithms.</term>
		/// </item>
		/// <item>
		/// <term>NCRYPT_ASYMMETRIC_ENCRYPTION_OPERATION 0x00000004</term>
		/// <term>Enumerate the asymmetric encryption algorithms.</term>
		/// </item>
		/// <item>
		/// <term>NCRYPT_SECRET_AGREEMENT_OPERATION 0x00000008</term>
		/// <term>Enumerate the secret agreement algorithms.</term>
		/// </item>
		/// <item>
		/// <term>NCRYPT_SIGNATURE_OPERATION 0x00000010</term>
		/// <term>Enumerate the digital signature algorithms.</term>
		/// </item>
		/// </list>
		/// </param>
		/// <param name="pdwAlgCount">The address of a <c>DWORD</c> that receives the number of elements in the ppAlgList array.</param>
		/// <param name="ppAlgList">
		/// <para>
		/// The address of an NCryptAlgorithmName structure pointer that receives an array of the registered algorithm names. The variable
		/// pointed to by the pdwAlgCount parameter receives the number of elements in this array.
		/// </para>
		/// <para>When this memory is no longer needed, it must be freed by passing this pointer to the NCryptFreeBuffer function.</para>
		/// </param>
		/// <param name="dwFlags">
		/// <para>Flags that modify function behavior. This can be zero (0) or the following value.</para>
		/// <list type="table">
		/// <listheader>
		/// <term>Value</term>
		/// <term>Meaning</term>
		/// </listheader>
		/// <item>
		/// <term>NCRYPT_SILENT_FLAG</term>
		/// <term>
		/// Requests that the key service provider (KSP) not display any user interface. If the provider must display the UI to operate, the
		/// call fails and the KSP should set the NTE_SILENT_CONTEXT error code as the last error.
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
		/// <term>ERROR_SUCCESS</term>
		/// <term>The function was successful.</term>
		/// </item>
		/// <item>
		/// <term>NTE_BAD_FLAGS</term>
		/// <term>The dwFlags parameter contains a value that is not valid.</term>
		/// </item>
		/// <item>
		/// <term>NTE_INVALID_HANDLE</term>
		/// <term>The hProvider parameter is not valid.</term>
		/// </item>
		/// <item>
		/// <term>NTE_INVALID_PARAMETER</term>
		/// <term>One or more parameters are not valid.</term>
		/// </item>
		/// <item>
		/// <term>NTE_NO_MEMORY</term>
		/// <term>A memory allocation failure occurred.</term>
		/// </item>
		/// </list>
		/// </returns>
		/// <remarks>
		/// A service must not call this function from its StartService Function. If a service calls this function from its StartService
		/// function, a deadlock can occur, and the service may stop responding.
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows/win32/api/ncrypt/nf-ncrypt-ncryptenumalgorithms SECURITY_STATUS NCryptEnumAlgorithms(
		// NCRYPT_PROV_HANDLE hProvider, DWORD dwAlgOperations, DWORD *pdwAlgCount, NCryptAlgorithmName **ppAlgList, DWORD dwFlags );
		[DllImport(Lib.Ncrypt, SetLastError = false, ExactSpelling = true)]
		[PInvokeData("ncrypt.h", MSDNShortId = "ea4f270b-c556-4f52-892a-199c9cfced26")]
		public static extern HRESULT NCryptEnumAlgorithms(NCRYPT_PROV_HANDLE hProvider, BCrypt.AlgOperations dwAlgOperations, out uint pdwAlgCount, out SafeNCryptBuffer ppAlgList, NCryptDecryptFlag dwFlags);

		/// <summary>The <c>NCryptEnumKeys</c> function obtains the names of the keys that are stored by the provider.</summary>
		/// <param name="hProvider">
		/// The handle of the key storage provider to enumerate the keys for. This handle is obtained with the NCryptOpenStorageProvider function.
		/// </param>
		/// <param name="pszScope">This parameter is not currently used and must be <c>NULL</c>.</param>
		/// <param name="ppKeyName">
		/// The address of a pointer to an NCryptKeyName structure that receives the name of the retrieved key. When the application has
		/// finished using this memory, free it by calling the NCryptFreeBuffer function.
		/// </param>
		/// <param name="ppEnumState">
		/// <para>
		/// The address of a <c>VOID</c> pointer that receives enumeration state information that is used in subsequent calls to this
		/// function. This information only has meaning to the key storage provider and is opaque to the caller. The key storage provider
		/// uses this information to determine which item is next in the enumeration. If the variable pointed to by this parameter contains
		/// <c>NULL</c>, the enumeration is started from the beginning.
		/// </para>
		/// <para>When this memory is no longer needed, it must be freed by passing this pointer to the NCryptFreeBuffer function.</para>
		/// </param>
		/// <param name="dwFlags">
		/// <para>Flags that modify function behavior. This can be zero or a combination of one or more of the following values.</para>
		/// <list type="table">
		/// <listheader>
		/// <term>Value</term>
		/// <term>Meaning</term>
		/// </listheader>
		/// <item>
		/// <term>NCRYPT_MACHINE_KEY_FLAG</term>
		/// <term>Enumerate the keys for the local computer. If this flag is not present, the current user keys are enumerated.</term>
		/// </item>
		/// <item>
		/// <term>NCRYPT_SILENT_FLAG</term>
		/// <term>
		/// Requests that the key service provider (KSP) not display any user interface. If the provider must display the UI to operate, the
		/// call fails and the KSP should set the NTE_SILENT_CONTEXT error code as the last error.
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
		/// <term>ERROR_SUCCESS</term>
		/// <term>The function was successful.</term>
		/// </item>
		/// <item>
		/// <term>NTE_BAD_FLAGS</term>
		/// <term>The dwFlags parameter contains a value that is not valid.</term>
		/// </item>
		/// <item>
		/// <term>NTE_INVALID_HANDLE</term>
		/// <term>The hProvider parameter is not valid.</term>
		/// </item>
		/// <item>
		/// <term>NTE_INVALID_PARAMETER</term>
		/// <term>One or more parameters are not valid.</term>
		/// </item>
		/// <item>
		/// <term>NTE_NO_MEMORY</term>
		/// <term>A memory allocation failure occurred.</term>
		/// </item>
		/// <item>
		/// <term>NTE_NO_MORE_ITEMS</term>
		/// <term>The end of the enumeration has been reached.</term>
		/// </item>
		/// <item>
		/// <term>NTE_SILENT_CONTEXT</term>
		/// <term>The dwFlags parameter contains the NCRYPT_SILENT_FLAG flag, but the key being enumerated requires user interaction.</term>
		/// </item>
		/// </list>
		/// </returns>
		/// <remarks>
		/// <para>
		/// This function retrieves only one item each time it is called. The state of the enumeration is stored in the variable pointed to
		/// by the ppEnumState parameter, so this must be preserved between calls to this function. When the last key stored by the provider
		/// has been retrieved, this function will return <c>NTE_NO_MORE_ITEMS</c> the next time it is called. To start the enumeration over,
		/// set the variable pointed to by the ppEnumState parameter to <c>NULL</c>, free the memory pointed to by the ppKeyName parameter,
		/// if it is not <c>NULL</c>, and call this function again.
		/// </para>
		/// <para>
		/// A service must not call this function from its StartService Function. If a service calls this function from its StartService
		/// function, a deadlock can occur, and the service may stop responding.
		/// </para>
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows/win32/api/ncrypt/nf-ncrypt-ncryptenumkeys SECURITY_STATUS NCryptEnumKeys(
		// NCRYPT_PROV_HANDLE hProvider, LPCWSTR pszScope, NCryptKeyName **ppKeyName, PVOID *ppEnumState, DWORD dwFlags );
		[DllImport(Lib.Ncrypt, SetLastError = false, ExactSpelling = true)]
		[PInvokeData("ncrypt.h", MSDNShortId = "ca8c5b70-ea5e-4fb9-82d3-1de839f0d244")]
		public static extern HRESULT NCryptEnumKeys(NCRYPT_PROV_HANDLE hProvider, [MarshalAs(UnmanagedType.LPWStr), Optional] string pszScope, out SafeNCryptBuffer ppKeyName, ref IntPtr ppEnumState, OpenKeyFlags dwFlags);

		/// <summary>The <c>NCryptEnumStorageProviders</c> function obtains the names of the registered key storage providers.</summary>
		/// <param name="pdwProviderCount">The address of a <c>DWORD</c> to receive the number of elements in the ppProviderList array.</param>
		/// <param name="ppProviderList">
		/// <para>
		/// The address of an NCryptProviderName structure pointer to receive an array of the registered key storage provider names. The
		/// variable pointed to by the pdwProviderCount parameter receives the number of elements in this array.
		/// </para>
		/// <para>When this memory is no longer needed, free it by passing this pointer to the NCryptFreeBuffer function.</para>
		/// </param>
		/// <param name="dwFlags">
		/// <para>Flags that modify function behavior. This can be zero (0) or the following value.</para>
		/// <list type="table">
		/// <listheader>
		/// <term>Value</term>
		/// <term>Meaning</term>
		/// </listheader>
		/// <item>
		/// <term>NCRYPT_SILENT_FLAG</term>
		/// <term>
		/// Requests that the key service provider (KSP) not display any user interface. If the provider must display the UI to operate, the
		/// call fails and the KSP should set the NTE_SILENT_CONTEXT error code as the last error.
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
		/// <term>ERROR_SUCCESS</term>
		/// <term>The function was successful.</term>
		/// </item>
		/// <item>
		/// <term>NTE_BAD_FLAGS</term>
		/// <term>The dwFlags parameter contains a value that is not valid.</term>
		/// </item>
		/// <item>
		/// <term>NTE_INVALID_PARAMETER</term>
		/// <term>One or more parameters are not valid.</term>
		/// </item>
		/// <item>
		/// <term>NTE_NO_MEMORY</term>
		/// <term>A memory allocation failure occurred.</term>
		/// </item>
		/// </list>
		/// </returns>
		/// <remarks>
		/// A service must not call this function from its StartService Function. If a service calls this function from its StartService
		/// function, a deadlock can occur, and the service may stop responding.
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows/win32/api/ncrypt/nf-ncrypt-ncryptenumstorageproviders SECURITY_STATUS
		// NCryptEnumStorageProviders( DWORD *pdwProviderCount, NCryptProviderName **ppProviderList, DWORD dwFlags );
		[DllImport(Lib.Ncrypt, SetLastError = false, ExactSpelling = true)]
		[PInvokeData("ncrypt.h", MSDNShortId = "24a8ee01-b716-4f36-9df5-b6476b1df4f0")]
		public static extern HRESULT NCryptEnumStorageProviders(out uint pdwProviderCount, out SafeNCryptBuffer ppProviderList, NCryptUIFlags dwFlags);

		/// <summary>
		/// <para>The <c>NCryptExportKey</c> function exports a CNG key to a memory BLOB.</para>
		/// </summary>
		/// <param name="hKey">
		/// <para>A handle of the key to export.</para>
		/// </param>
		/// <param name="hExportKey">
		/// <para>
		/// A handle to a cryptographic key of the destination user. The key data within the exported key BLOB is encrypted by using this
		/// key. This ensures that only the destination user is able to make use of the key BLOB.
		/// </para>
		/// </param>
		/// <param name="pszBlobType">
		/// <para>
		/// A null-terminated Unicode string that contains an identifier that specifies the type of BLOB to export. This can be one of the
		/// following values.
		/// </para>
		/// <para>BCRYPT_DH_PRIVATE_BLOB</para>
		/// <para>
		/// Export a Diffie-Hellman public/private key pair. The pbOutput buffer receives a BCRYPT_DH_KEY_BLOB structure immediately followed
		/// by the key data.
		/// </para>
		/// <para>BCRYPT_DH_PUBLIC_BLOB</para>
		/// <para>
		/// Export a Diffie-Hellman public key. The pbOutput buffer receives a BCRYPT_DH_KEY_BLOB structure immediately followed by the key data.
		/// </para>
		/// <para>BCRYPT_DSA_PRIVATE_BLOB</para>
		/// <para>
		/// Export a DSA public/private key pair. The pbOutput buffer receives a BCRYPT_DSA_KEY_BLOB structure immediately followed by the
		/// key data.
		/// </para>
		/// <para>BCRYPT_DSA_PUBLIC_BLOB</para>
		/// <para>
		/// Export a DSA public key. The pbOutput buffer receives a BCRYPT_DSA_KEY_BLOB structure immediately followed by the key data.
		/// </para>
		/// <para>BCRYPT_ECCPRIVATE_BLOB</para>
		/// <para>
		/// Export an elliptic curve cryptography (ECC) private key. The pbOutput buffer receives a BCRYPT_ECCKEY_BLOB structure immediately
		/// followed by the key data.
		/// </para>
		/// <para>BCRYPT_ECCPUBLIC_BLOB</para>
		/// <para>
		/// Export an ECC public key. The pbOutput buffer receives a BCRYPT_ECCKEY_BLOB structure immediately followed by the key data.
		/// </para>
		/// <para>BCRYPT_PUBLIC_KEY_BLOB</para>
		/// <para>
		/// Export a generic public key of any type. The type of key in this BLOB is determined by the <c>Magic</c> member of the
		/// BCRYPT_KEY_BLOB structure.
		/// </para>
		/// <para>BCRYPT_PRIVATE_KEY_BLOB</para>
		/// <para>
		/// Export a generic private key of any type. The private key does not necessarily contain the public key. The type of key in this
		/// BLOB is determined by the <c>Magic</c> member of the BCRYPT_KEY_BLOB structure.
		/// </para>
		/// <para>BCRYPT_RSAFULLPRIVATE_BLOB</para>
		/// <para>
		/// Export a full RSA public/private key pair. The pbOutput buffer receives a BCRYPT_RSAKEY_BLOB structure immediately followed by
		/// the key data. This BLOB will include additional key material compared to the <c>BCRYPT_RSAPRIVATE_BLOB</c> type.
		/// </para>
		/// <para>BCRYPT_RSAPRIVATE_BLOB</para>
		/// <para>
		/// Export an RSA public/private key pair. The pbOutput buffer receives a BCRYPT_RSAKEY_BLOB structure immediately followed by the
		/// key data.
		/// </para>
		/// <para>BCRYPT_RSAPUBLIC_BLOB</para>
		/// <para>
		/// Export an RSA public key. The pbOutput buffer receives a BCRYPT_RSAKEY_BLOB structure immediately followed by the key data.
		/// </para>
		/// <para>LEGACY_DH_PRIVATE_BLOB</para>
		/// <para>
		/// Export a legacy Diffie-Hellman Version 3 Private Key BLOB that contains a Diffie-Hellman public/private key pair that can be
		/// imported by using CryptoAPI.
		/// </para>
		/// <para>LEGACY_DH_PUBLIC_BLOB</para>
		/// <para>
		/// Export a legacy Diffie-Hellman Version 3 Private Key BLOB that contains a Diffie-Hellman public key that can be imported by using CryptoAPI.
		/// </para>
		/// <para>LEGACY_DSA_PRIVATE_BLOB</para>
		/// <para>Export a DSA public/private key pair in a form that can be imported by using CryptoAPI.</para>
		/// <para>LEGACY_DSA_PUBLIC_BLOB</para>
		/// <para>Export a DSA public key in a form that can be imported by using CryptoAPI.</para>
		/// <para>LEGACY_RSAPRIVATE_BLOB</para>
		/// <para>Export an RSA public/private key pair in a form that can be imported by using CryptoAPI.</para>
		/// <para>LEGACY_RSAPUBLIC_BLOB</para>
		/// <para>Export an RSA public key in a form that can be imported by using CryptoAPI.</para>
		/// <para>NCRYPT_CIPHER_KEY_BLOB</para>
		/// <para>Export a cipher key in a NCRYPT_KEY_BLOB_HEADER structure.</para>
		/// <para><c>Windows 8 and Windows Server 2012:</c> Support for this value begins.</para>
		/// <para>NCRYPT_OPAQUETRANSPORT_BLOB</para>
		/// <para>
		/// Export a key in a format that is specific to a single CSP and is suitable for transport. Opaque BLOBs are not transferable and
		/// must be imported by using the same CSP that generated the BLOB.
		/// </para>
		/// <para>NCRYPT_PKCS7_ENVELOPE_BLOB</para>
		/// <para>
		/// Export a PKCS #7 envelope BLOB. The parameters identified by the pParameterList parameter either can or must contain the
		/// following parameters, as indicated by the Required or optional column.
		/// </para>
		/// <list type="table">
		/// <listheader>
		/// <term>Parameter</term>
		/// <term>Required or optional</term>
		/// </listheader>
		/// <item>
		/// <term>NCRYPTBUFFER_CERT_BLOB</term>
		/// <term>Required</term>
		/// </item>
		/// <item>
		/// <term>NCRYPTBUFFER_PKCS_ALG_OID</term>
		/// <term>Required</term>
		/// </item>
		/// <item>
		/// <term>NCRYPTBUFFER_PKCS_ALG_PARAM</term>
		/// <term>Optional</term>
		/// </item>
		/// </list>
		/// <para>NCRYPT_PKCS8_PRIVATE_KEY_BLOB</para>
		/// <para>
		/// Export a PKCS #8 private key BLOB. The parameters identified by the pParameterList parameter either can or must contain the
		/// following parameters, as indicated by the Required or optional column.
		/// </para>
		/// <list type="table">
		/// <listheader>
		/// <term>Parameter</term>
		/// <term>Required or optional</term>
		/// </listheader>
		/// <item>
		/// <term>NCRYPTBUFFER_PKCS_ALG_OID</term>
		/// <term>Optional</term>
		/// </item>
		/// <item>
		/// <term>NCRYPTBUFFER_PKCS_ALG_PARAM</term>
		/// <term>Optional</term>
		/// </item>
		/// <item>
		/// <term>NCRYPTBUFFER_PKCS_SECRET</term>
		/// <term>Optional</term>
		/// </item>
		/// </list>
		/// <para>NCRYPT_PROTECTED_KEY_BLOB</para>
		/// <para>Export a protected key in a NCRYPT_KEY_BLOB_HEADER structure.</para>
		/// <para><c>Windows 8 and Windows Server 2012:</c> Support for this value begins.</para>
		/// </param>
		/// <param name="pParameterList">
		/// <para>
		/// The address of an NCryptBufferDesc structure that receives parameter information for the key. This parameter can be <c>NULL</c>
		/// if this information is not needed.
		/// </para>
		/// </param>
		/// <param name="pbOutput">
		/// <para>
		/// The address of a buffer that receives the key BLOB. The cbOutput parameter contains the size of this buffer. If this parameter is
		/// <c>NULL</c>, this function will place the required size, in bytes, in the <c>DWORD</c> pointed to by the pcbResult parameter.
		/// </para>
		/// </param>
		/// <param name="cbOutput">
		/// <para>The size, in bytes, of the pbOutput buffer.</para>
		/// </param>
		/// <param name="pcbResult">
		/// <para>
		/// The address of a <c>DWORD</c> variable that receives the number of bytes copied to the pbOutput buffer. If the pbOutput parameter
		/// is <c>NULL</c>, this function will place the required size, in bytes, in the <c>DWORD</c> pointed to by this parameter.
		/// </para>
		/// </param>
		/// <param name="dwFlags">
		/// <para>
		/// Flags that modify function behavior. This can be zero or a combination of one or more of the following values. The set of valid
		/// flags is specific to each key storage provider. The following flag applies to all providers.
		/// </para>
		/// <list type="table">
		/// <listheader>
		/// <term>Value</term>
		/// <term>Meaning</term>
		/// </listheader>
		/// <item>
		/// <term>NCRYPT_SILENT_FLAG</term>
		/// <term>
		/// Requests that the key service provider (KSP) not display any user interface. If the provider must display the UI to operate, the
		/// call fails and the KSP should set the NTE_SILENT_CONTEXT error code as the last error.
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
		/// <term>ERROR_SUCCESS</term>
		/// <term>The function was successful.</term>
		/// </item>
		/// <item>
		/// <term>NTE_BAD_FLAGS</term>
		/// <term>The dwFlags parameter contains a value that is not valid.</term>
		/// </item>
		/// <item>
		/// <term>NTE_BAD_KEY_STATE</term>
		/// <term>
		/// The key specified by the hKey parameter is not valid. The most common cause of this error is that the key was not completed by
		/// using the NCryptFinalizeKey function.
		/// </term>
		/// </item>
		/// <item>
		/// <term>NTE_BAD_TYPE</term>
		/// <term>The key specified by the hKey parameter cannot be exported into the BLOB type specified by the pszBlobType parameter.</term>
		/// </item>
		/// <item>
		/// <term>NTE_INVALID_HANDLE</term>
		/// <term>The hKey or the hExportKey parameter is not valid.</term>
		/// </item>
		/// <item>
		/// <term>NTE_INVALID_PARAMETER</term>
		/// <term>One or more parameters are not valid.</term>
		/// </item>
		/// </list>
		/// </returns>
		/// <remarks>
		/// <para>
		/// A service must not call this function from its StartService Function. If a service calls this function from its StartService
		/// function, a deadlock can occur, and the service may stop responding.
		/// </para>
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows/desktop/api/ncrypt/nf-ncrypt-ncryptexportkey SECURITY_STATUS NCryptExportKey(
		// NCRYPT_KEY_HANDLE hKey, NCRYPT_KEY_HANDLE hExportKey, LPCWSTR pszBlobType, NCryptBufferDesc *pParameterList, PBYTE pbOutput, DWORD
		// cbOutput, DWORD *pcbResult, DWORD dwFlags );
		[DllImport(Lib.Ncrypt, SetLastError = false, ExactSpelling = true)]
		[PInvokeData("ncrypt.h", MSDNShortId = "1588eb29-4026-4d1c-8bee-a035df38444a")]
		public static extern HRESULT NCryptExportKey(NCRYPT_KEY_HANDLE hKey, NCRYPT_KEY_HANDLE hExportKey, [MarshalAs(UnmanagedType.LPWStr)] string pszBlobType, [Optional] NCryptBufferDesc pParameterList, SafeAllocatedMemoryHandle pbOutput, uint cbOutput, out uint pcbResult, NCryptUIFlags dwFlags = 0);

		/// <summary>
		/// <para>The <c>NCryptExportKey</c> function exports a CNG key to a memory BLOB.</para>
		/// </summary>
		/// <param name="hKey">
		/// <para>A handle of the key to export.</para>
		/// </param>
		/// <param name="hExportKey">
		/// <para>
		/// A handle to a cryptographic key of the destination user. The key data within the exported key BLOB is encrypted by using this
		/// key. This ensures that only the destination user is able to make use of the key BLOB.
		/// </para>
		/// </param>
		/// <param name="pszBlobType">
		/// <para>
		/// A null-terminated Unicode string that contains an identifier that specifies the type of BLOB to export. This can be one of the
		/// following values.
		/// </para>
		/// <para>BCRYPT_DH_PRIVATE_BLOB</para>
		/// <para>
		/// Export a Diffie-Hellman public/private key pair. The pbOutput buffer receives a BCRYPT_DH_KEY_BLOB structure immediately followed
		/// by the key data.
		/// </para>
		/// <para>BCRYPT_DH_PUBLIC_BLOB</para>
		/// <para>
		/// Export a Diffie-Hellman public key. The pbOutput buffer receives a BCRYPT_DH_KEY_BLOB structure immediately followed by the key data.
		/// </para>
		/// <para>BCRYPT_DSA_PRIVATE_BLOB</para>
		/// <para>
		/// Export a DSA public/private key pair. The pbOutput buffer receives a BCRYPT_DSA_KEY_BLOB structure immediately followed by the
		/// key data.
		/// </para>
		/// <para>BCRYPT_DSA_PUBLIC_BLOB</para>
		/// <para>
		/// Export a DSA public key. The pbOutput buffer receives a BCRYPT_DSA_KEY_BLOB structure immediately followed by the key data.
		/// </para>
		/// <para>BCRYPT_ECCPRIVATE_BLOB</para>
		/// <para>
		/// Export an elliptic curve cryptography (ECC) private key. The pbOutput buffer receives a BCRYPT_ECCKEY_BLOB structure immediately
		/// followed by the key data.
		/// </para>
		/// <para>BCRYPT_ECCPUBLIC_BLOB</para>
		/// <para>
		/// Export an ECC public key. The pbOutput buffer receives a BCRYPT_ECCKEY_BLOB structure immediately followed by the key data.
		/// </para>
		/// <para>BCRYPT_PUBLIC_KEY_BLOB</para>
		/// <para>
		/// Export a generic public key of any type. The type of key in this BLOB is determined by the <c>Magic</c> member of the
		/// BCRYPT_KEY_BLOB structure.
		/// </para>
		/// <para>BCRYPT_PRIVATE_KEY_BLOB</para>
		/// <para>
		/// Export a generic private key of any type. The private key does not necessarily contain the public key. The type of key in this
		/// BLOB is determined by the <c>Magic</c> member of the BCRYPT_KEY_BLOB structure.
		/// </para>
		/// <para>BCRYPT_RSAFULLPRIVATE_BLOB</para>
		/// <para>
		/// Export a full RSA public/private key pair. The pbOutput buffer receives a BCRYPT_RSAKEY_BLOB structure immediately followed by
		/// the key data. This BLOB will include additional key material compared to the <c>BCRYPT_RSAPRIVATE_BLOB</c> type.
		/// </para>
		/// <para>BCRYPT_RSAPRIVATE_BLOB</para>
		/// <para>
		/// Export an RSA public/private key pair. The pbOutput buffer receives a BCRYPT_RSAKEY_BLOB structure immediately followed by the
		/// key data.
		/// </para>
		/// <para>BCRYPT_RSAPUBLIC_BLOB</para>
		/// <para>
		/// Export an RSA public key. The pbOutput buffer receives a BCRYPT_RSAKEY_BLOB structure immediately followed by the key data.
		/// </para>
		/// <para>LEGACY_DH_PRIVATE_BLOB</para>
		/// <para>
		/// Export a legacy Diffie-Hellman Version 3 Private Key BLOB that contains a Diffie-Hellman public/private key pair that can be
		/// imported by using CryptoAPI.
		/// </para>
		/// <para>LEGACY_DH_PUBLIC_BLOB</para>
		/// <para>
		/// Export a legacy Diffie-Hellman Version 3 Private Key BLOB that contains a Diffie-Hellman public key that can be imported by using CryptoAPI.
		/// </para>
		/// <para>LEGACY_DSA_PRIVATE_BLOB</para>
		/// <para>Export a DSA public/private key pair in a form that can be imported by using CryptoAPI.</para>
		/// <para>LEGACY_DSA_PUBLIC_BLOB</para>
		/// <para>Export a DSA public key in a form that can be imported by using CryptoAPI.</para>
		/// <para>LEGACY_RSAPRIVATE_BLOB</para>
		/// <para>Export an RSA public/private key pair in a form that can be imported by using CryptoAPI.</para>
		/// <para>LEGACY_RSAPUBLIC_BLOB</para>
		/// <para>Export an RSA public key in a form that can be imported by using CryptoAPI.</para>
		/// <para>NCRYPT_CIPHER_KEY_BLOB</para>
		/// <para>Export a cipher key in a NCRYPT_KEY_BLOB_HEADER structure.</para>
		/// <para><c>Windows 8 and Windows Server 2012:</c> Support for this value begins.</para>
		/// <para>NCRYPT_OPAQUETRANSPORT_BLOB</para>
		/// <para>
		/// Export a key in a format that is specific to a single CSP and is suitable for transport. Opaque BLOBs are not transferable and
		/// must be imported by using the same CSP that generated the BLOB.
		/// </para>
		/// <para>NCRYPT_PKCS7_ENVELOPE_BLOB</para>
		/// <para>
		/// Export a PKCS #7 envelope BLOB. The parameters identified by the pParameterList parameter either can or must contain the
		/// following parameters, as indicated by the Required or optional column.
		/// </para>
		/// <list type="table">
		/// <listheader>
		/// <term>Parameter</term>
		/// <term>Required or optional</term>
		/// </listheader>
		/// <item>
		/// <term>NCRYPTBUFFER_CERT_BLOB</term>
		/// <term>Required</term>
		/// </item>
		/// <item>
		/// <term>NCRYPTBUFFER_PKCS_ALG_OID</term>
		/// <term>Required</term>
		/// </item>
		/// <item>
		/// <term>NCRYPTBUFFER_PKCS_ALG_PARAM</term>
		/// <term>Optional</term>
		/// </item>
		/// </list>
		/// <para>NCRYPT_PKCS8_PRIVATE_KEY_BLOB</para>
		/// <para>
		/// Export a PKCS #8 private key BLOB. The parameters identified by the pParameterList parameter either can or must contain the
		/// following parameters, as indicated by the Required or optional column.
		/// </para>
		/// <list type="table">
		/// <listheader>
		/// <term>Parameter</term>
		/// <term>Required or optional</term>
		/// </listheader>
		/// <item>
		/// <term>NCRYPTBUFFER_PKCS_ALG_OID</term>
		/// <term>Optional</term>
		/// </item>
		/// <item>
		/// <term>NCRYPTBUFFER_PKCS_ALG_PARAM</term>
		/// <term>Optional</term>
		/// </item>
		/// <item>
		/// <term>NCRYPTBUFFER_PKCS_SECRET</term>
		/// <term>Optional</term>
		/// </item>
		/// </list>
		/// <para>NCRYPT_PROTECTED_KEY_BLOB</para>
		/// <para>Export a protected key in a NCRYPT_KEY_BLOB_HEADER structure.</para>
		/// <para><c>Windows 8 and Windows Server 2012:</c> Support for this value begins.</para>
		/// </param>
		/// <param name="pParameterList">
		/// <para>
		/// The address of an NCryptBufferDesc structure that receives parameter information for the key. This parameter can be <c>NULL</c>
		/// if this information is not needed.
		/// </para>
		/// </param>
		/// <param name="pbOutput">
		/// <para>
		/// The address of a buffer that receives the key BLOB. The cbOutput parameter contains the size of this buffer. If this parameter is
		/// <c>NULL</c>, this function will place the required size, in bytes, in the <c>DWORD</c> pointed to by the pcbResult parameter.
		/// </para>
		/// </param>
		/// <param name="cbOutput">
		/// <para>The size, in bytes, of the pbOutput buffer.</para>
		/// </param>
		/// <param name="pcbResult">
		/// <para>
		/// The address of a <c>DWORD</c> variable that receives the number of bytes copied to the pbOutput buffer. If the pbOutput parameter
		/// is <c>NULL</c>, this function will place the required size, in bytes, in the <c>DWORD</c> pointed to by this parameter.
		/// </para>
		/// </param>
		/// <param name="dwFlags">
		/// <para>
		/// Flags that modify function behavior. This can be zero or a combination of one or more of the following values. The set of valid
		/// flags is specific to each key storage provider. The following flag applies to all providers.
		/// </para>
		/// <list type="table">
		/// <listheader>
		/// <term>Value</term>
		/// <term>Meaning</term>
		/// </listheader>
		/// <item>
		/// <term>NCRYPT_SILENT_FLAG</term>
		/// <term>
		/// Requests that the key service provider (KSP) not display any user interface. If the provider must display the UI to operate, the
		/// call fails and the KSP should set the NTE_SILENT_CONTEXT error code as the last error.
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
		/// <term>ERROR_SUCCESS</term>
		/// <term>The function was successful.</term>
		/// </item>
		/// <item>
		/// <term>NTE_BAD_FLAGS</term>
		/// <term>The dwFlags parameter contains a value that is not valid.</term>
		/// </item>
		/// <item>
		/// <term>NTE_BAD_KEY_STATE</term>
		/// <term>
		/// The key specified by the hKey parameter is not valid. The most common cause of this error is that the key was not completed by
		/// using the NCryptFinalizeKey function.
		/// </term>
		/// </item>
		/// <item>
		/// <term>NTE_BAD_TYPE</term>
		/// <term>The key specified by the hKey parameter cannot be exported into the BLOB type specified by the pszBlobType parameter.</term>
		/// </item>
		/// <item>
		/// <term>NTE_INVALID_HANDLE</term>
		/// <term>The hKey or the hExportKey parameter is not valid.</term>
		/// </item>
		/// <item>
		/// <term>NTE_INVALID_PARAMETER</term>
		/// <term>One or more parameters are not valid.</term>
		/// </item>
		/// </list>
		/// </returns>
		/// <remarks>
		/// <para>
		/// A service must not call this function from its StartService Function. If a service calls this function from its StartService
		/// function, a deadlock can occur, and the service may stop responding.
		/// </para>
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows/desktop/api/ncrypt/nf-ncrypt-ncryptexportkey SECURITY_STATUS NCryptExportKey(
		// NCRYPT_KEY_HANDLE hKey, NCRYPT_KEY_HANDLE hExportKey, LPCWSTR pszBlobType, NCryptBufferDesc *pParameterList, PBYTE pbOutput, DWORD
		// cbOutput, DWORD *pcbResult, DWORD dwFlags );
		[DllImport(Lib.Ncrypt, SetLastError = false, ExactSpelling = true)]
		[PInvokeData("ncrypt.h", MSDNShortId = "1588eb29-4026-4d1c-8bee-a035df38444a")]
		public static extern HRESULT NCryptExportKey(NCRYPT_KEY_HANDLE hKey, NCRYPT_KEY_HANDLE hExportKey, [MarshalAs(UnmanagedType.LPWStr)] string pszBlobType, [Optional] NCryptBufferDesc pParameterList, [Optional] IntPtr pbOutput, [Optional] uint cbOutput, out uint pcbResult, NCryptUIFlags dwFlags = 0);

		/// <summary>
		/// <para>
		/// The <c>NCryptFinalizeKey</c> function completes a CNG key storage key. The key cannot be used until this function has been called.
		/// </para>
		/// </summary>
		/// <param name="hKey">
		/// <para>The handle of the key to complete. This handle is obtained by calling the NCryptCreatePersistedKey function.</para>
		/// </param>
		/// <param name="dwFlags">
		/// <para>Flags that modify function behavior. This can be zero or a combination of one or more of the following values.</para>
		/// <list type="table">
		/// <listheader>
		/// <term>Value</term>
		/// <term>Meaning</term>
		/// </listheader>
		/// <item>
		/// <term>NCRYPT_NO_KEY_VALIDATION</term>
		/// <term>Do not validate the public portion of the key pair. This flag only applies to public/private key pairs.</term>
		/// </item>
		/// <item>
		/// <term>NCRYPT_WRITE_KEY_TO_LEGACY_STORE_FLAG</term>
		/// <term>Also save the key in legacy storage. This allows the key to be used with CryptoAPI. This flag only applies to RSA keys.</term>
		/// </item>
		/// <item>
		/// <term>NCRYPT_SILENT_FLAG</term>
		/// <term>
		/// Requests that the key service provider (KSP) not display any user interface. If the provider must display the UI to operate, the
		/// call fails and the KSP should set the NTE_SILENT_CONTEXT error code as the last error.
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
		/// <term>ERROR_SUCCESS</term>
		/// <term>The function was successful.</term>
		/// </item>
		/// <item>
		/// <term>NTE_BAD_FLAGS</term>
		/// <term>The dwFlags parameter contains a value that is not valid.</term>
		/// </item>
		/// <item>
		/// <term>NTE_INVALID_HANDLE</term>
		/// <term>The hKey parameter is not valid.</term>
		/// </item>
		/// </list>
		/// </returns>
		/// <remarks>
		/// <para>
		/// A service must not call this function from its StartService Function. If a service calls this function from its StartService
		/// function, a deadlock can occur, and the service may stop responding.
		/// </para>
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows/desktop/api/ncrypt/nf-ncrypt-ncryptfinalizekey SECURITY_STATUS NCryptFinalizeKey(
		// NCRYPT_KEY_HANDLE hKey, DWORD dwFlags );
		[DllImport(Lib.Ncrypt, SetLastError = false, ExactSpelling = true)]
		[PInvokeData("ncrypt.h", MSDNShortId = "4386030d-4ce6-4b2e-adc5-a15ddc869349")]
		public static extern HRESULT NCryptFinalizeKey(NCRYPT_KEY_HANDLE hKey, FinalizeKeyFlags dwFlags = 0);

		/// <summary>The <c>NCryptFreeBuffer</c> function releases a block of memory allocated by a CNG key storage provider.</summary>
		/// <param name="pvInput">The address of the memory to be released.</param>
		/// <returns>
		/// <para>Returns a status code that indicates the success or failure of the function.</para>
		/// <para>Possible return codes include, but are not limited to, the following.</para>
		/// <list type="table">
		/// <listheader>
		/// <term>Return code</term>
		/// <term>Description</term>
		/// </listheader>
		/// <item>
		/// <term>ERROR_SUCCESS</term>
		/// <term>The function was successful.</term>
		/// </item>
		/// <item>
		/// <term>NTE_INVALID_PARAMETER</term>
		/// <term>The pvInput parameter is not valid.</term>
		/// </item>
		/// </list>
		/// </returns>
		/// <remarks>
		/// A service must not call this function from its StartService Function. If a service calls this function from its StartService
		/// function, a deadlock can occur, and the service may stop responding.
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows/win32/api/ncrypt/nf-ncrypt-ncryptfreebuffer SECURITY_STATUS NCryptFreeBuffer( PVOID
		// pvInput );
		[DllImport(Lib.Ncrypt, SetLastError = false, ExactSpelling = true)]
		[PInvokeData("ncrypt.h", MSDNShortId = "15f19999-cf64-4a30-b38d-9372066add0a")]
		public static extern HRESULT NCryptFreeBuffer(IntPtr pvInput);

		/// <summary>
		/// <para>The <c>NCryptFreeObject</c> function frees a CNG key storage object.</para>
		/// </summary>
		/// <param name="hObject">
		/// <para>
		/// The handle of the object to free. This can be either a provider handle ( <c>NCRYPT_PROV_HANDLE</c>) or a key handle ( <c>NCRYPT_KEY_HANDLE</c>).
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
		/// <term>ERROR_SUCCESS</term>
		/// <term>The function was successful.</term>
		/// </item>
		/// <item>
		/// <term>NTE_INVALID_HANDLE</term>
		/// <term>The handle in the hObject parameter is not valid.</term>
		/// </item>
		/// </list>
		/// </returns>
		/// <remarks>
		/// <para>
		/// A service must not call this function from its StartService Function. If a service calls this function from its StartService
		/// function, a deadlock can occur, and the service may stop responding.
		/// </para>
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows/desktop/api/ncrypt/nf-ncrypt-ncryptfreeobject SECURITY_STATUS NCryptFreeObject(
		// NCRYPT_HANDLE hObject );
		[DllImport(Lib.Ncrypt, SetLastError = false, ExactSpelling = true)]
		[PInvokeData("ncrypt.h", MSDNShortId = "a5535cf9-ba8c-4212-badd-f1dc88903624")]
		public static extern HRESULT NCryptFreeObject(IntPtr hObject);

		/// <summary>The <c>NCryptGetProperty</c> function retrieves the value of a named property for a key storage object.</summary>
		/// <param name="hObject">
		/// The handle of the object to get the property for. This can be a provider handle ( <c>NCRYPT_PROV_HANDLE</c>) or a key handle ( <c>NCRYPT_KEY_HANDLE</c>).
		/// </param>
		/// <param name="pszProperty">
		/// A pointer to a null-terminated Unicode string that contains the name of the property to retrieve. This can be one of the
		/// predefined Key Storage Property Identifiers or a custom property identifier.
		/// </param>
		/// <param name="pbOutput">
		/// <para>The address of a buffer that receives the property value. The cbOutput parameter contains the size of this buffer.</para>
		/// <para>
		/// To calculate the size required for the buffer, set this parameter to <c>NULL</c>. The size, in bytes, required is returned in the
		/// location pointed to by the pcbResult parameter.
		/// </para>
		/// </param>
		/// <param name="cbOutput">The size, in bytes, of the pbOutput buffer.</param>
		/// <param name="pcbResult">
		/// <para>A pointer to a <c>DWORD</c> variable that receives the number of bytes that were copied to the pbOutput buffer.</para>
		/// <para>
		/// If the pbOutput parameter is <c>NULL</c>, the size, in bytes, required for the buffer is placed in the location pointed to by
		/// this parameter.
		/// </para>
		/// </param>
		/// <param name="dwFlags">
		/// <para>Flags that modify function behavior. This can be zero or the following value.</para>
		/// <list type="table">
		/// <listheader>
		/// <term>Value</term>
		/// <term>Meaning</term>
		/// </listheader>
		/// <item>
		/// <term>NCRYPT_PERSIST_ONLY_FLAG</term>
		/// <term>
		/// Ignore any built in values for this property and only retrieve the user-persisted properties of the key. The maximum size of the
		/// data for any persisted property is NCRYPT_MAX_PROPERTY_DATA bytes.
		/// </term>
		/// </item>
		/// <item>
		/// <term>NCRYPT_SILENT_FLAG</term>
		/// <term>
		/// Requests that the key service provider (KSP) not display any user interface. If the provider must display the UI to operate, the
		/// call fails and the KSP should set the NTE_SILENT_CONTEXT error code as the last error.
		/// </term>
		/// </item>
		/// </list>
		/// <para>
		/// For the <c>NCRYPT_SECURITY_DESCR_PROPERTY</c> property, this parameter must also contain one of the following values, which
		/// identifies the part of the security descriptor to retrieve.
		/// </para>
		/// <list type="table">
		/// <listheader>
		/// <term>Value</term>
		/// <term>Meaning</term>
		/// </listheader>
		/// <item>
		/// <term>OWNER_SECURITY_INFORMATION</term>
		/// <term>
		/// Retrieve the security identifier (SID) of the object's owner. Use the GetSecurityDescriptorOwner function to obtain the owner SID
		/// from the SECURITY_DESCRIPTOR structure.
		/// </term>
		/// </item>
		/// <item>
		/// <term>GROUP_SECURITY_INFORMATION</term>
		/// <term>
		/// Retrieve the SID of the object's primary group. Use the GetSecurityDescriptorGroup function to obtain the group SID from the
		/// SECURITY_DESCRIPTOR structure.
		/// </term>
		/// </item>
		/// <item>
		/// <term>DACL_SECURITY_INFORMATION</term>
		/// <term>
		/// Retrieve the discretionary access control list (DACL). Use the GetSecurityDescriptorSacl function to obtain the DACL from the
		/// SECURITY_DESCRIPTOR structure.
		/// </term>
		/// </item>
		/// <item>
		/// <term>SACL_SECURITY_INFORMATION</term>
		/// <term>
		/// Retrieve the system access control list (SACL). Use the GetSecurityDescriptorDacl function to obtain the SACL from the
		/// SECURITY_DESCRIPTOR structure.
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
		/// <term>ERROR_SUCCESS</term>
		/// <term>The function was successful.</term>
		/// </item>
		/// <item>
		/// <term>NTE_BAD_FLAGS</term>
		/// <term>The dwFlags parameter contains a value that is not valid.</term>
		/// </item>
		/// <item>
		/// <term>NTE_INVALID_HANDLE</term>
		/// <term>The hObject parameter is not valid.</term>
		/// </item>
		/// <item>
		/// <term>NTE_INVALID_PARAMETER</term>
		/// <term>One or more parameters are not valid.</term>
		/// </item>
		/// <item>
		/// <term>NTE_NO_MEMORY</term>
		/// <term>A memory allocation failure occurred.</term>
		/// </item>
		/// <item>
		/// <term>NTE_NOT_SUPPORTED</term>
		/// <term>The specified property is not supported for the object.</term>
		/// </item>
		/// </list>
		/// </returns>
		/// <remarks>
		/// A service must not call this function from its StartService Function. If a service calls this function from its StartService
		/// function, a deadlock can occur, and the service may stop responding.
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows/win32/api/ncrypt/nf-ncrypt-ncryptgetproperty SECURITY_STATUS NCryptGetProperty(
		// NCRYPT_HANDLE hObject, LPCWSTR pszProperty, PBYTE pbOutput, DWORD cbOutput, DWORD *pcbResult, DWORD dwFlags );
		[DllImport(Lib.Ncrypt, SetLastError = false, ExactSpelling = true)]
		[PInvokeData("ncrypt.h", MSDNShortId = "7b857ce0-8525-489b-9987-ef40081a5577")]
		public static extern HRESULT NCryptGetProperty(NCRYPT_HANDLE hObject, [MarshalAs(UnmanagedType.LPWStr)] string pszProperty, IntPtr pbOutput, uint cbOutput, out uint pcbResult, GetPropertyFlags dwFlags);

		/// <summary>
		/// <para>The <c>NCryptImportKey</c> function imports a Cryptography API: Next Generation (CNG) key from a memory BLOB.</para>
		/// </summary>
		/// <param name="hProvider">
		/// <para>The handle of the key storage provider.</para>
		/// </param>
		/// <param name="hImportKey">
		/// <para>
		/// The handle of the cryptographic key with which the key data within the imported key BLOB was encrypted. This must be a handle to
		/// the same key that was passed in the hExportKey parameter of the NCryptExportKey function. If this parameter is <c>NULL</c>, the
		/// key BLOB is assumed to not be encrypted.
		/// </para>
		/// </param>
		/// <param name="pszBlobType">
		/// <para>
		/// A null-terminated Unicode string that contains an identifier that specifies the format of the key BLOB. These formats are
		/// specific to a particular key storage provider. For the BLOB formats supported by Microsoft providers, see Remarks.
		/// </para>
		/// </param>
		/// <param name="pParameterList">
		/// <para>
		/// The address of an NCryptBufferDesc structure that points to an array of buffers that contain parameter information for the key.
		/// </para>
		/// </param>
		/// <param name="phKey">
		/// <para>
		/// The address of an <c>NCRYPT_KEY_HANDLE</c> variable that receives the handle of the key. When you have finished using this
		/// handle, release it by passing it to the NCryptFreeObject function.
		/// </para>
		/// </param>
		/// <param name="pbData">
		/// <para>The address of a buffer that contains the key BLOB to be imported. The cbData parameter contains the size of this buffer.</para>
		/// </param>
		/// <param name="cbData">
		/// <para>The size, in bytes, of the pbData buffer.</para>
		/// </param>
		/// <param name="dwFlags">
		/// <para>
		/// Flags that modify function behavior. This can be zero or a combination of one or more of the following values. The set of valid
		/// flags is specific to each key storage provider.
		/// </para>
		/// <list type="table">
		/// <listheader>
		/// <term>Value</term>
		/// <term>Meaning</term>
		/// </listheader>
		/// <item>
		/// <term>NCRYPT_SILENT_FLAG</term>
		/// <term>
		/// Requests that the key service provider (KSP) not display any user interface. If the provider must display the UI to operate, the
		/// call fails and the KSP should set the NTE_SILENT_CONTEXT error code as the last error.
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
		/// <term>ERROR_SUCCESS</term>
		/// <term>The function was successful.</term>
		/// </item>
		/// <item>
		/// <term>NTE_BAD_FLAGS</term>
		/// <term>The dwFlags parameter contains a value that is not valid.</term>
		/// </item>
		/// <item>
		/// <term>NTE_EXISTS</term>
		/// <term>A key with the specified name already exists and the NCRYPT_OVERWRITE_KEY_FLAG was not specified.</term>
		/// </item>
		/// <item>
		/// <term>NTE_INVALID_HANDLE</term>
		/// <term>The hProvider parameter is not valid.</term>
		/// </item>
		/// <item>
		/// <term>NTE_INVALID_PARAMETER</term>
		/// <term>One or more parameters are not valid.</term>
		/// </item>
		/// <item>
		/// <term>NTE_NO_MEMORY</term>
		/// <term>A memory allocation failure occurred.</term>
		/// </item>
		/// </list>
		/// </returns>
		/// <remarks>
		/// <para>
		/// A service must not call this function from its StartService Function. If a service calls this function from its StartService
		/// function, a deadlock can occur, and the service may stop responding.
		/// </para>
		/// <para>The following sections describe behaviors specific to the Microsoft key storage providers:</para>
		/// <list type="bullet">
		/// <item>
		/// <term><c>Microsoft Software KSP</c></term>
		/// </item>
		/// <item>
		/// <term><c>Microsoft Smart Card KSP</c></term>
		/// </item>
		/// </list>
		/// <para>Microsoft Software KSP</para>
		/// <para>The following constants are supported by the Microsoft software KSP for the pszBlobType parameter.</para>
		/// <para>
		/// If a key name is not supplied, the Microsoft Software KSP treats the key as ephemeral and does not store it persistently. For the
		/// <c>NCRYPT_OPAQUETRANSPORT_BLOB</c> type, the key name is stored within the BLOB when it is exported. For other BLOB formats, the
		/// name can be supplied in an <c>NCRYPTBUFFER_PKCS_KEY_NAME</c> buffer parameter within the pParameterList parameter.
		/// </para>
		/// <para>
		/// On Windows Server 2008 and Windows Vista, only keys imported as PKCS #7 envelope BLOBs ( <c>NCRYPT_PKCS7_ENVELOPE_BLOB</c>) or
		/// PKCS #8 private key BLOBs ( <c>NCRYPT_PKCS8_PRIVATE_KEY_BLOB</c>) can be persisted by using the above method. To persist keys
		/// imported through other BLOB types on these platforms, use the method documented in Key Import and Export.
		/// </para>
		/// <para>The following flags are supported by this KSP.</para>
		/// <list type="table">
		/// <listheader>
		/// <term>Term</term>
		/// <term>Description</term>
		/// </listheader>
		/// <item>
		/// <term>NCRYPT_NO_KEY_VALIDATION</term>
		/// <term>Do not validate the public portion of the key pair. This flag only applies to public/private key pairs.</term>
		/// </item>
		/// <item>
		/// <term>NCRYPT_DO_NOT_FINALIZE_FLAG</term>
		/// <term>
		/// Do not finalize the key. This option is useful when you need to add or modify properties of the key after importing it. You must
		/// finalize the key before it can be used by passing the key handle to the NCryptFinalizeKey function. This flag is supported for
		/// the private keys PKCS #7 and PKCS #8 but not public keys.
		/// </term>
		/// </item>
		/// <item>
		/// <term>NCRYPT_MACHINE_KEY_FLAG</term>
		/// <term>The key applies to the local computer. If this flag is not present, the key applies to the current user.</term>
		/// </item>
		/// <item>
		/// <term>NCRYPT_OVERWRITE_KEY_FLAG</term>
		/// <term>
		/// If a key already exists in the container with the specified name, the existing key will be overwritten. If this flag is not
		/// specified and a key with the specified name already exists, this function will return NTE_EXISTS.
		/// </term>
		/// </item>
		/// <item>
		/// <term>NCRYPT_WRITE_KEY_TO_LEGACY_STORE_FLAG</term>
		/// <term>
		/// Also save the key in legacy storage. This allows the key to be used with the CryptoAPI. This flag only applies to RSA keys.
		/// </term>
		/// </item>
		/// </list>
		/// <para>Microsoft Smart Card KSP</para>
		/// <para>
		/// The set of key BLOB formats and flags supported by this KSP is identical to the set supported by the Microsoft Software KSP.
		/// </para>
		/// <para>
		/// On Windows Server 2008 and Windows Vista, the Microsoft Smart Card KSP imports all keys into the Microsoft Software KSP. Thus,
		/// keys cannot be persisted on to a smart card by using this API, and the guidance in the above section applies when trying to
		/// persist keys within the Microsoft Software KSP.
		/// </para>
		/// <para>
		/// On Windows Server 2008 R2 and Windows 7, the Microsoft Smart Card Key Storage Provider can import a private key to a smart card,
		/// provided the following conditions are met:
		/// </para>
		/// <list type="bullet">
		/// <item>
		/// <term>The key container name on the card is valid.</term>
		/// </item>
		/// <item>
		/// <term>Importing private keys is supported by the smart card.</term>
		/// </item>
		/// <item>
		/// <term>The following two registry keys are set to a <c>DWORD</c> of 0x1:</term>
		/// </item>
		/// </list>
		/// <para>
		/// If the key container name is <c>NULL</c>, the Microsoft Smart Card KSP treats the key as ephemeral and imports it into the
		/// Microsoft Software KSP.
		/// </para>
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows/desktop/api/ncrypt/nf-ncrypt-ncryptimportkey SECURITY_STATUS NCryptImportKey(
		// NCRYPT_PROV_HANDLE hProvider, NCRYPT_KEY_HANDLE hImportKey, LPCWSTR pszBlobType, NCryptBufferDesc *pParameterList,
		// NCRYPT_KEY_HANDLE *phKey, PBYTE pbData, DWORD cbData, DWORD dwFlags );
		[DllImport(Lib.Ncrypt, SetLastError = false, ExactSpelling = true)]
		[PInvokeData("ncrypt.h", MSDNShortId = "ede0e7e0-cb2c-44c0-b724-58db3480b781")]
		public static extern HRESULT NCryptImportKey(NCRYPT_PROV_HANDLE hProvider, NCRYPT_KEY_HANDLE hImportKey, [MarshalAs(UnmanagedType.LPWStr)] string pszBlobType, NCryptBufferDesc pParameterList,
			out SafeNCRYPT_KEY_HANDLE phKey, SafeAllocatedMemoryHandle pbData, uint cbData, NCryptUIFlags dwFlags = 0);

		/// <summary>
		/// <para>The <c>NCryptImportKey</c> function imports a Cryptography API: Next Generation (CNG) key from a memory BLOB.</para>
		/// </summary>
		/// <param name="hProvider">
		/// <para>The handle of the key storage provider.</para>
		/// </param>
		/// <param name="hImportKey">
		/// <para>
		/// The handle of the cryptographic key with which the key data within the imported key BLOB was encrypted. This must be a handle to
		/// the same key that was passed in the hExportKey parameter of the NCryptExportKey function. If this parameter is <c>NULL</c>, the
		/// key BLOB is assumed to not be encrypted.
		/// </para>
		/// </param>
		/// <param name="pszBlobType">
		/// <para>
		/// A null-terminated Unicode string that contains an identifier that specifies the format of the key BLOB. These formats are
		/// specific to a particular key storage provider. For the BLOB formats supported by Microsoft providers, see Remarks.
		/// </para>
		/// </param>
		/// <param name="pParameterList">
		/// <para>
		/// The address of an NCryptBufferDesc structure that points to an array of buffers that contain parameter information for the key.
		/// </para>
		/// </param>
		/// <param name="phKey">
		/// <para>
		/// The address of an <c>NCRYPT_KEY_HANDLE</c> variable that receives the handle of the key. When you have finished using this
		/// handle, release it by passing it to the NCryptFreeObject function.
		/// </para>
		/// </param>
		/// <param name="pbData">
		/// <para>The address of a buffer that contains the key BLOB to be imported. The cbData parameter contains the size of this buffer.</para>
		/// </param>
		/// <param name="cbData">
		/// <para>The size, in bytes, of the pbData buffer.</para>
		/// </param>
		/// <param name="dwFlags">
		/// <para>
		/// Flags that modify function behavior. This can be zero or a combination of one or more of the following values. The set of valid
		/// flags is specific to each key storage provider.
		/// </para>
		/// <list type="table">
		/// <listheader>
		/// <term>Value</term>
		/// <term>Meaning</term>
		/// </listheader>
		/// <item>
		/// <term>NCRYPT_SILENT_FLAG</term>
		/// <term>
		/// Requests that the key service provider (KSP) not display any user interface. If the provider must display the UI to operate, the
		/// call fails and the KSP should set the NTE_SILENT_CONTEXT error code as the last error.
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
		/// <term>ERROR_SUCCESS</term>
		/// <term>The function was successful.</term>
		/// </item>
		/// <item>
		/// <term>NTE_BAD_FLAGS</term>
		/// <term>The dwFlags parameter contains a value that is not valid.</term>
		/// </item>
		/// <item>
		/// <term>NTE_EXISTS</term>
		/// <term>A key with the specified name already exists and the NCRYPT_OVERWRITE_KEY_FLAG was not specified.</term>
		/// </item>
		/// <item>
		/// <term>NTE_INVALID_HANDLE</term>
		/// <term>The hProvider parameter is not valid.</term>
		/// </item>
		/// <item>
		/// <term>NTE_INVALID_PARAMETER</term>
		/// <term>One or more parameters are not valid.</term>
		/// </item>
		/// <item>
		/// <term>NTE_NO_MEMORY</term>
		/// <term>A memory allocation failure occurred.</term>
		/// </item>
		/// </list>
		/// </returns>
		/// <remarks>
		/// <para>
		/// A service must not call this function from its StartService Function. If a service calls this function from its StartService
		/// function, a deadlock can occur, and the service may stop responding.
		/// </para>
		/// <para>The following sections describe behaviors specific to the Microsoft key storage providers:</para>
		/// <list type="bullet">
		/// <item>
		/// <term><c>Microsoft Software KSP</c></term>
		/// </item>
		/// <item>
		/// <term><c>Microsoft Smart Card KSP</c></term>
		/// </item>
		/// </list>
		/// <para>Microsoft Software KSP</para>
		/// <para>The following constants are supported by the Microsoft software KSP for the pszBlobType parameter.</para>
		/// <para>
		/// If a key name is not supplied, the Microsoft Software KSP treats the key as ephemeral and does not store it persistently. For the
		/// <c>NCRYPT_OPAQUETRANSPORT_BLOB</c> type, the key name is stored within the BLOB when it is exported. For other BLOB formats, the
		/// name can be supplied in an <c>NCRYPTBUFFER_PKCS_KEY_NAME</c> buffer parameter within the pParameterList parameter.
		/// </para>
		/// <para>
		/// On Windows Server 2008 and Windows Vista, only keys imported as PKCS #7 envelope BLOBs ( <c>NCRYPT_PKCS7_ENVELOPE_BLOB</c>) or
		/// PKCS #8 private key BLOBs ( <c>NCRYPT_PKCS8_PRIVATE_KEY_BLOB</c>) can be persisted by using the above method. To persist keys
		/// imported through other BLOB types on these platforms, use the method documented in Key Import and Export.
		/// </para>
		/// <para>The following flags are supported by this KSP.</para>
		/// <list type="table">
		/// <listheader>
		/// <term>Term</term>
		/// <term>Description</term>
		/// </listheader>
		/// <item>
		/// <term>NCRYPT_NO_KEY_VALIDATION</term>
		/// <term>Do not validate the public portion of the key pair. This flag only applies to public/private key pairs.</term>
		/// </item>
		/// <item>
		/// <term>NCRYPT_DO_NOT_FINALIZE_FLAG</term>
		/// <term>
		/// Do not finalize the key. This option is useful when you need to add or modify properties of the key after importing it. You must
		/// finalize the key before it can be used by passing the key handle to the NCryptFinalizeKey function. This flag is supported for
		/// the private keys PKCS #7 and PKCS #8 but not public keys.
		/// </term>
		/// </item>
		/// <item>
		/// <term>NCRYPT_MACHINE_KEY_FLAG</term>
		/// <term>The key applies to the local computer. If this flag is not present, the key applies to the current user.</term>
		/// </item>
		/// <item>
		/// <term>NCRYPT_OVERWRITE_KEY_FLAG</term>
		/// <term>
		/// If a key already exists in the container with the specified name, the existing key will be overwritten. If this flag is not
		/// specified and a key with the specified name already exists, this function will return NTE_EXISTS.
		/// </term>
		/// </item>
		/// <item>
		/// <term>NCRYPT_WRITE_KEY_TO_LEGACY_STORE_FLAG</term>
		/// <term>
		/// Also save the key in legacy storage. This allows the key to be used with the CryptoAPI. This flag only applies to RSA keys.
		/// </term>
		/// </item>
		/// </list>
		/// <para>Microsoft Smart Card KSP</para>
		/// <para>
		/// The set of key BLOB formats and flags supported by this KSP is identical to the set supported by the Microsoft Software KSP.
		/// </para>
		/// <para>
		/// On Windows Server 2008 and Windows Vista, the Microsoft Smart Card KSP imports all keys into the Microsoft Software KSP. Thus,
		/// keys cannot be persisted on to a smart card by using this API, and the guidance in the above section applies when trying to
		/// persist keys within the Microsoft Software KSP.
		/// </para>
		/// <para>
		/// On Windows Server 2008 R2 and Windows 7, the Microsoft Smart Card Key Storage Provider can import a private key to a smart card,
		/// provided the following conditions are met:
		/// </para>
		/// <list type="bullet">
		/// <item>
		/// <term>The key container name on the card is valid.</term>
		/// </item>
		/// <item>
		/// <term>Importing private keys is supported by the smart card.</term>
		/// </item>
		/// <item>
		/// <term>The following two registry keys are set to a <c>DWORD</c> of 0x1:</term>
		/// </item>
		/// </list>
		/// <para>
		/// If the key container name is <c>NULL</c>, the Microsoft Smart Card KSP treats the key as ephemeral and imports it into the
		/// Microsoft Software KSP.
		/// </para>
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows/desktop/api/ncrypt/nf-ncrypt-ncryptimportkey SECURITY_STATUS NCryptImportKey(
		// NCRYPT_PROV_HANDLE hProvider, NCRYPT_KEY_HANDLE hImportKey, LPCWSTR pszBlobType, NCryptBufferDesc *pParameterList,
		// NCRYPT_KEY_HANDLE *phKey, PBYTE pbData, DWORD cbData, DWORD dwFlags );
		[DllImport(Lib.Ncrypt, SetLastError = false, ExactSpelling = true)]
		[PInvokeData("ncrypt.h", MSDNShortId = "ede0e7e0-cb2c-44c0-b724-58db3480b781")]
		public static extern HRESULT NCryptImportKey(NCRYPT_PROV_HANDLE hProvider, NCRYPT_KEY_HANDLE hImportKey, [MarshalAs(UnmanagedType.LPWStr)] string pszBlobType, NCryptBufferDesc pParameterList,
			out SafeNCRYPT_KEY_HANDLE phKey, [Optional] IntPtr pbData, [Optional] uint cbData, NCryptUIFlags dwFlags = 0);

		/// <summary>
		/// The <c>NCryptIsAlgSupported</c> function determines if a CNG key storage provider supports a specific cryptographic algorithm.
		/// </summary>
		/// <param name="hProvider">
		/// The handle of the key storage provider. This handle is obtained with the NCryptOpenStorageProvider function.
		/// </param>
		/// <param name="pszAlgId">
		/// A pointer to a null-terminated Unicode string that identifies the cryptographic algorithm in question. This can be one of the
		/// standard CNG Algorithm Identifiers or the identifier for another registered algorithm.
		/// </param>
		/// <param name="dwFlags">
		/// <para>Flags that modify function behavior. This can be zero (0) or the following value.</para>
		/// <list type="table">
		/// <listheader>
		/// <term>Value</term>
		/// <term>Meaning</term>
		/// </listheader>
		/// <item>
		/// <term>NCRYPT_SILENT_FLAG</term>
		/// <term>
		/// Requests that the key service provider (KSP) not display any user interface. If the provider must display the UI to operate, the
		/// call fails and the KSP should set the NTE_SILENT_CONTEXT error code as the last error.
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
		/// <term>ERROR_SUCCESS</term>
		/// <term>The provider supports the specified algorithm.</term>
		/// </item>
		/// <item>
		/// <term>NTE_BAD_FLAGS</term>
		/// <term>The dwFlags parameter contains one or more flags that are not supported.</term>
		/// </item>
		/// <item>
		/// <term>NTE_INVALID_HANDLE</term>
		/// <term>The handle specified by the hProvider parameter is not valid.</term>
		/// </item>
		/// <item>
		/// <term>NTE_INVALID_PARAMETER</term>
		/// <term>One or more parameters are not valid.</term>
		/// </item>
		/// <item>
		/// <term>NTE_NOT_SUPPORTED</term>
		/// <term>The provider does not support the specified algorithm.</term>
		/// </item>
		/// </list>
		/// </returns>
		/// <remarks>
		/// <para>
		/// If the provider supports the algorithm, this function returns <c>ERROR_SUCCESS</c>. If the provider does not support the
		/// algorithm, and no other errors occurred, this function returns <c>NTE_NOT_SUPPORTED</c>.
		/// </para>
		/// <para>
		/// A service must not call this function from its StartService Function. If a service calls this function from its StartService
		/// function, a deadlock can occur, and the service may stop responding.
		/// </para>
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows/win32/api/ncrypt/nf-ncrypt-ncryptisalgsupported SECURITY_STATUS NCryptIsAlgSupported(
		// NCRYPT_PROV_HANDLE hProvider, LPCWSTR pszAlgId, DWORD dwFlags );
		[DllImport(Lib.Ncrypt, SetLastError = false, ExactSpelling = true)]
		[PInvokeData("ncrypt.h", MSDNShortId = "99563293-662f-4478-b8da-8526b832012d")]
		public static extern HRESULT NCryptIsAlgSupported(NCRYPT_PROV_HANDLE hProvider, [MarshalAs(UnmanagedType.LPWStr)] string pszAlgId, NCryptUIFlags dwFlags);

		/// <summary>The <c>NCryptIsKeyHandle</c> function determines if the specified handle is a CNG key handle.</summary>
		/// <param name="hKey">The handle of the key to test.</param>
		/// <returns>Returns a nonzero value if the handle is a key handle or zero otherwise.</returns>
		/// <remarks>
		/// A service must not call this function from its StartService Function. If a service calls this function from its StartService
		/// function, a deadlock can occur, and the service may stop responding.
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows/win32/api/ncrypt/nf-ncrypt-ncryptiskeyhandle BOOL NCryptIsKeyHandle( NCRYPT_KEY_HANDLE
		// hKey );
		[DllImport(Lib.Ncrypt, SetLastError = false, ExactSpelling = true)]
		[PInvokeData("ncrypt.h", MSDNShortId = "ad841c2e-8097-4b07-914e-8e7240d55585")]
		[return: MarshalAs(UnmanagedType.Bool)]
		public static extern bool NCryptIsKeyHandle(NCRYPT_KEY_HANDLE hKey);

		/// <summary>
		/// The <c>NCryptKeyDerivation</c> function creates a key from another key by using the specified key derivation function. The
		/// function returns the key in a byte array.
		/// </summary>
		/// <param name="hKey">Handle of the key derivation function (KDF) key.</param>
		/// <param name="pParameterList">
		/// <para>
		/// The address of a NCryptBufferDesc structure that contains the KDF parameters. The parameters can be specific to a KDF or generic.
		/// The following table shows the required and optional parameters for specific KDFs implemented by the Microsoft software key
		/// storage provider.
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
		/// Address of a buffer that receives the key. The cbDerivedKey parameter contains the size, in bytes, of the key buffer.
		/// </param>
		/// <param name="cbDerivedKey">Size, in bytes, of the buffer pointed to by the pbDerivedKey parameter.</param>
		/// <param name="pcbResult">
		/// Pointer to a <c>DWORD</c> that receives the number of bytes copied to the buffer pointed to by the pbDerivedKey parameter.
		/// </param>
		/// <param name="dwFlags">
		/// <para>Flags that modify function behavior. The following value can be used with the Microsoft software key storage provider.</para>
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
		/// <item>
		/// <term>NCRYPT_SILENT_FLAG</term>
		/// <term>
		/// Requests that the key service provider (KSP) not display any user interface. If the provider must display the UI to operate, the
		/// call fails and the KSP should set the NTE_SILENT_CONTEXT error code as the last error.
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
		/// <term>ERROR_SUCCESS</term>
		/// <term>The function was successful.</term>
		/// </item>
		/// <item>
		/// <term>NTE_INVALID_HANDLE</term>
		/// <term>The hProvider or hKey handles are not valid.</term>
		/// </item>
		/// <item>
		/// <term>NTE_INVALID_PARAMETER</term>
		/// <term>The pwszDerivedKeyAlg and pParameterList parameters cannot be NULL.</term>
		/// </item>
		/// <item>
		/// <term>NTE_NO_MEMORY</term>
		/// <term>There was not enough memory to create the key.</term>
		/// </item>
		/// <item>
		/// <term>NTE_NOT_SUPPORTED</term>
		/// <term>This function is not supported by the key storage provider.</term>
		/// </item>
		/// </list>
		/// </returns>
		/// <remarks>
		/// <para>You can use the following algorithm identifiers in the NCryptCreatePersistedKey function before calling <c>NCryptKeyDerivation</c>:</para>
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
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows/win32/api/ncrypt/nf-ncrypt-ncryptkeyderivation SECURITY_STATUS NCryptKeyDerivation(
		// NCRYPT_KEY_HANDLE hKey, NCryptBufferDesc *pParameterList, PUCHAR pbDerivedKey, DWORD cbDerivedKey, DWORD *pcbResult, ULONG dwFlags );
		[DllImport(Lib.Ncrypt, SetLastError = false, ExactSpelling = true)]
		[PInvokeData("ncrypt.h", MSDNShortId = "5D2D61B1-022E-412F-A19E-11057930A615")]
		public static extern HRESULT NCryptKeyDerivation(NCRYPT_KEY_HANDLE hKey, in NCryptBufferDesc pParameterList, IntPtr pbDerivedKey, uint cbDerivedKey, out uint pcbResult, KeyDerivationFlags dwFlags);

		/// <summary>
		/// The <c>NCryptKeyDerivation</c> function creates a key from another key by using the specified key derivation function. The
		/// function returns the key in a byte array.
		/// </summary>
		/// <param name="hKey">Handle of the key derivation function (KDF) key.</param>
		/// <param name="pParameterList">
		/// <para>
		/// The address of a NCryptBufferDesc structure that contains the KDF parameters. The parameters can be specific to a KDF or generic.
		/// The following table shows the required and optional parameters for specific KDFs implemented by the Microsoft software key
		/// storage provider.
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
		/// Address of a buffer that receives the key. The cbDerivedKey parameter contains the size, in bytes, of the key buffer.
		/// </param>
		/// <param name="cbDerivedKey">Size, in bytes, of the buffer pointed to by the pbDerivedKey parameter.</param>
		/// <param name="pcbResult">
		/// Pointer to a <c>DWORD</c> that receives the number of bytes copied to the buffer pointed to by the pbDerivedKey parameter.
		/// </param>
		/// <param name="dwFlags">
		/// <para>Flags that modify function behavior. The following value can be used with the Microsoft software key storage provider.</para>
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
		/// <item>
		/// <term>NCRYPT_SILENT_FLAG</term>
		/// <term>
		/// Requests that the key service provider (KSP) not display any user interface. If the provider must display the UI to operate, the
		/// call fails and the KSP should set the NTE_SILENT_CONTEXT error code as the last error.
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
		/// <term>ERROR_SUCCESS</term>
		/// <term>The function was successful.</term>
		/// </item>
		/// <item>
		/// <term>NTE_INVALID_HANDLE</term>
		/// <term>The hProvider or hKey handles are not valid.</term>
		/// </item>
		/// <item>
		/// <term>NTE_INVALID_PARAMETER</term>
		/// <term>The pwszDerivedKeyAlg and pParameterList parameters cannot be NULL.</term>
		/// </item>
		/// <item>
		/// <term>NTE_NO_MEMORY</term>
		/// <term>There was not enough memory to create the key.</term>
		/// </item>
		/// <item>
		/// <term>NTE_NOT_SUPPORTED</term>
		/// <term>This function is not supported by the key storage provider.</term>
		/// </item>
		/// </list>
		/// </returns>
		/// <remarks>
		/// <para>You can use the following algorithm identifiers in the NCryptCreatePersistedKey function before calling <c>NCryptKeyDerivation</c>:</para>
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
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows/win32/api/ncrypt/nf-ncrypt-ncryptkeyderivation SECURITY_STATUS NCryptKeyDerivation(
		// NCRYPT_KEY_HANDLE hKey, NCryptBufferDesc *pParameterList, PUCHAR pbDerivedKey, DWORD cbDerivedKey, DWORD *pcbResult, ULONG dwFlags );
		[DllImport(Lib.Ncrypt, SetLastError = false, ExactSpelling = true)]
		[PInvokeData("ncrypt.h", MSDNShortId = "5D2D61B1-022E-412F-A19E-11057930A615")]
		public static extern HRESULT NCryptKeyDerivation(NCRYPT_KEY_HANDLE hKey, [Optional] IntPtr pParameterList, IntPtr pbDerivedKey, uint cbDerivedKey, out uint pcbResult, KeyDerivationFlags dwFlags);

		/// <summary>
		/// <para>The <c>NCryptNotifyChangeKey</c> function creates or removes a key change notification.</para>
		/// <para>
		/// The handle provided by this function is the same handle that is returned by the FindFirstChangeNotification function. You use the
		/// wait functions to wait for the notification handle to be signaled.
		/// </para>
		/// </summary>
		/// <param name="hProvider">
		/// The handle of the key storage provider. This handle is obtained by using the NCryptOpenStorageProvider function.
		/// </param>
		/// <param name="phEvent">
		/// The address of a <c>HANDLE</c> variable that either receives or contains the key change notification event handle. This is the
		/// same handle that is returned by the FindFirstChangeNotification function. For more information, see the dwFlags parameter description.
		/// </param>
		/// <param name="dwFlags">
		/// <para>
		/// A set of flags that modify the behavior of this function. This parameter contains a combination of one or more of the following values.
		/// </para>
		/// <list type="table">
		/// <listheader>
		/// <term>Value</term>
		/// <term>Meaning</term>
		/// </listheader>
		/// <item>
		/// <term>NCRYPT_REGISTER_NOTIFY_FLAG 0x00000001</term>
		/// <term>Create a new change notification. The phEvent parameter will receive the key change notification handle.</term>
		/// </item>
		/// <item>
		/// <term>NCRYPT_UNREGISTER_NOTIFY_FLAG 0x00000002</term>
		/// <term>
		/// Remove an existing change notification. The phEvent parameter must contain a valid key change notification handle. This handle is
		/// no longer valid after this function is called with this flag and the INVALID_HANDLE_VALUE value is placed in this handle.
		/// </term>
		/// </item>
		/// <item>
		/// <term>NCRYPT_MACHINE_KEY_FLAG 0x00000020</term>
		/// <term>
		/// Receive change notifications for keys in the machine key store. If this flag is not specified, the change notification events
		/// will only occur for keys in the calling user's key store. This flag is only valid when combined with the
		/// NCRYPT_REGISTER_NOTIFY_FLAG flag.
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
		/// <term>ERROR_SUCCESS</term>
		/// <term>The function was successful.</term>
		/// </item>
		/// <item>
		/// <term>NTE_BAD_FLAGS</term>
		/// <term>The dwFlags parameter contains a value that is not valid.</term>
		/// </item>
		/// <item>
		/// <term>NTE_INVALID_HANDLE</term>
		/// <term>The hProvider parameter is not valid.</term>
		/// </item>
		/// <item>
		/// <term>NTE_INVALID_PARAMETER</term>
		/// <term>One or more parameters are not valid.</term>
		/// </item>
		/// </list>
		/// </returns>
		/// <remarks>
		/// A service must not call this function from its StartService Function. If a service calls this function from its StartService
		/// function, a deadlock can occur, and the service may stop responding.
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows/win32/api/ncrypt/nf-ncrypt-ncryptnotifychangekey SECURITY_STATUS NCryptNotifyChangeKey(
		// NCRYPT_PROV_HANDLE hProvider, HANDLE *phEvent, DWORD dwFlags );
		[DllImport(Lib.Ncrypt, SetLastError = false, ExactSpelling = true)]
		[PInvokeData("ncrypt.h", MSDNShortId = "2d2ddb55-ef32-4227-b901-ee11e961d0e6")]
		public static extern HRESULT NCryptNotifyChangeKey(NCRYPT_PROV_HANDLE hProvider, ref IntPtr phEvent, XXX dwFlags);

		/// <summary>
		/// <para>The <c>NCryptOpenKey</c> function opens a key that exists in the specified CNG key storage provider.</para>
		/// </summary>
		/// <param name="hProvider">
		/// <para>The handle of the key storage provider to open the key from.</para>
		/// </param>
		/// <param name="phKey">
		/// <para>
		/// A pointer to a <c>NCRYPT_KEY_HANDLE</c> variable that receives the key handle. When you have finished using this handle, release
		/// it by passing it to the NCryptFreeObject function.
		/// </para>
		/// </param>
		/// <param name="pszKeyName">
		/// <para>A pointer to a null-terminated Unicode string that contains the name of the key to retrieve.</para>
		/// </param>
		/// <param name="dwLegacyKeySpec">
		/// <para>A legacy identifier that specifies the type of key. This can be one of the following values.</para>
		/// <list type="table">
		/// <listheader>
		/// <term>Value</term>
		/// <term>Meaning</term>
		/// </listheader>
		/// <item>
		/// <term>AT_KEYEXCHANGE</term>
		/// <term>The key is a key exchange key.</term>
		/// </item>
		/// <item>
		/// <term>AT_SIGNATURE</term>
		/// <term>The key is a signature key.</term>
		/// </item>
		/// <item>
		/// <term>0</term>
		/// <term>The key is none of the above types.</term>
		/// </item>
		/// </list>
		/// </param>
		/// <param name="dwFlags">
		/// <para>Flags that modify function behavior. This can be zero or a combination of one or more of the following values.</para>
		/// <list type="table">
		/// <listheader>
		/// <term>Value</term>
		/// <term>Meaning</term>
		/// </listheader>
		/// <item>
		/// <term>NCRYPT_MACHINE_KEY_FLAG</term>
		/// <term>Open the key for the local computer. If this flag is not present, the current user key is opened.</term>
		/// </item>
		/// <item>
		/// <term>NCRYPT_SILENT_FLAG</term>
		/// <term>
		/// Requests that the key service provider (KSP) not display any user interface. If the provider must display the UI to operate, the
		/// call fails and the KSP should set the NTE_SILENT_CONTEXT error code as the last error.
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
		/// <term>ERROR_SUCCESS</term>
		/// <term>The function was successful.</term>
		/// </item>
		/// <item>
		/// <term>NTE_BAD_FLAGS</term>
		/// <term>The dwFlags parameter contains a value that is not valid.</term>
		/// </item>
		/// <item>
		/// <term>NTE_BAD_KEYSET</term>
		/// <term>The specified key was not found.</term>
		/// </item>
		/// <item>
		/// <term>NTE_INVALID_HANDLE</term>
		/// <term>The hProvider parameter is not valid.</term>
		/// </item>
		/// <item>
		/// <term>NTE_INVALID_PARAMETER</term>
		/// <term>One or more parameters are not valid.</term>
		/// </item>
		/// <item>
		/// <term>NTE_NO_MEMORY</term>
		/// <term>A memory allocation failure occurred.</term>
		/// </item>
		/// </list>
		/// </returns>
		/// <remarks>
		/// <para>
		/// A service must not call this function from its StartService Function. If a service calls this function from its StartService
		/// function, a deadlock can occur, and the service may stop responding.
		/// </para>
		/// <para>
		/// For performance reasons, Microsoft software-based KSPs cache private key material in the Local Security Authority (LSA) for as
		/// long as a handle to the key is open. The LSA is a privilidged system process. Therefore, other users cannot access this cached
		/// copy of the key unless the user possesses administrator privileges on the system. This behavior cannot be altered through configuration.
		/// </para>
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows/desktop/api/ncrypt/nf-ncrypt-ncryptopenkey SECURITY_STATUS NCryptOpenKey(
		// NCRYPT_PROV_HANDLE hProvider, NCRYPT_KEY_HANDLE *phKey, LPCWSTR pszKeyName, DWORD dwLegacyKeySpec, DWORD dwFlags );
		[DllImport(Lib.Ncrypt, SetLastError = false, ExactSpelling = true)]
		[PInvokeData("ncrypt.h", MSDNShortId = "581c5d89-730d-4d8c-b3bb-a28edec25910")]
		public static extern HRESULT NCryptOpenKey(NCRYPT_PROV_HANDLE hProvider, out SafeNCRYPT_KEY_HANDLE phKey, [MarshalAs(UnmanagedType.LPWStr)] string pszKeyName, Crypt32.PrivateKeyType dwLegacyKeySpec = 0, OpenKeyFlags dwFlags = 0);

		/// <summary>
		/// <para>The <c>NCryptOpenStorageProvider</c> function loads and initializes a CNG key storage provider.</para>
		/// </summary>
		/// <param name="phProvider">
		/// <para>
		/// A pointer to a <c>NCRYPT_PROV_HANDLE</c> variable that receives the provider handle. When you have finished using this handle,
		/// release it by passing it to the NCryptFreeObject function.
		/// </para>
		/// </param>
		/// <param name="pszProviderName">
		/// <para>
		/// A pointer to a null-terminated Unicode string that identifies the key storage provider to load. This is the registered alias of
		/// the key storage provider. This parameter is optional and can be <c>NULL</c>. If this parameter is <c>NULL</c>, the default key
		/// storage provider is loaded. The following values identify the built-in key storage providers.
		/// </para>
		/// <list type="table">
		/// <listheader>
		/// <term>Value</term>
		/// <term>Meaning</term>
		/// </listheader>
		/// <item>
		/// <term>MS_KEY_STORAGE_PROVIDER L"Microsoft Software Key Storage Provider"</term>
		/// <term>Identifies the software key storage provider that is provided by Microsoft.</term>
		/// </item>
		/// <item>
		/// <term>MS_SMART_CARD_KEY_STORAGE_PROVIDER L"Microsoft Smart Card Key Storage Provider"</term>
		/// <term>Identifies the smart card key storage provider that is provided by Microsoft.</term>
		/// </item>
		/// </list>
		/// </param>
		/// <param name="dwFlags">
		/// <para>Flags that modify the behavior of the function. No flags are defined for this function.</para>
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
		/// <term>ERROR_SUCCESS</term>
		/// <term>The function was successful.</term>
		/// </item>
		/// <item>
		/// <term>NTE_BAD_FLAGS</term>
		/// <term>The dwFlags parameter contains one or more flags that are not supported.</term>
		/// </item>
		/// <item>
		/// <term>NTE_INVALID_PARAMETER</term>
		/// <term>One or more parameters are not valid.</term>
		/// </item>
		/// <item>
		/// <term>NTE_NO_MEMORY</term>
		/// <term>A memory allocation failure occurred.</term>
		/// </item>
		/// </list>
		/// </returns>
		/// <remarks>
		/// <para>
		/// In the case that an error condition is returned, the provider will have been unloaded from memory. Functions within the provider
		/// must not be called after a failure error is returned.
		/// </para>
		/// <para>
		/// A service must not call this function from its StartService Function. If a service calls this function from its StartService
		/// function, a deadlock can occur, and the service may stop responding.
		/// </para>
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows/desktop/api/ncrypt/nf-ncrypt-ncryptopenstorageprovider SECURITY_STATUS
		// NCryptOpenStorageProvider( NCRYPT_PROV_HANDLE *phProvider, LPCWSTR pszProviderName, DWORD dwFlags );
		[DllImport(Lib.Ncrypt, SetLastError = false, ExactSpelling = true)]
		[PInvokeData("ncrypt.h", MSDNShortId = "febcf440-78b3-420b-b13d-030e8071cd50")]
		public static extern HRESULT NCryptOpenStorageProvider(out SafeNCRYPT_PROV_HANDLE phProvider, [MarshalAs(UnmanagedType.LPWStr)] string pszProviderName, uint dwFlags = 0);

		/// <summary>
		/// <para>The <c>NCryptSecretAgreement</c> function creates a secret agreement value from a private and a public key.</para>
		/// </summary>
		/// <param name="hPrivKey">
		/// <para>
		/// The handle of the private key to use to create the secret agreement value. This key and the hPubKey key must come from the same
		/// key storage provider.
		/// </para>
		/// </param>
		/// <param name="hPubKey">
		/// <para>
		/// The handle of the public key to use to create the secret agreement value. This key and the hPrivKey key must come from the same
		/// key storage provider.
		/// </para>
		/// </param>
		/// <param name="phAgreedSecret">
		/// <para>
		/// A pointer to an <c>NCRYPT_SECRET_HANDLE</c> variable that receives a handle that represents the secret agreement value. When this
		/// handle is no longer needed, release it by passing it to the NCryptFreeObject function.
		/// </para>
		/// </param>
		/// <param name="dwFlags">
		/// <para>
		/// Flags that modify function behavior. This can be zero or a combination of one or more of the following values. The set of valid
		/// flags is specific to each key storage provider. The following flag applies to all providers.
		/// </para>
		/// <list type="table">
		/// <listheader>
		/// <term>Value</term>
		/// <term>Meaning</term>
		/// </listheader>
		/// <item>
		/// <term>NCRYPT_SILENT_FLAG</term>
		/// <term>
		/// Requests that the key service provider (KSP) not display any user interface. If the provider must display the UI to operate, the
		/// call fails and the KSP should set the NTE_SILENT_CONTEXT error code as the last error.
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
		/// <term>ERROR_SUCCESS</term>
		/// <term>The function was successful.</term>
		/// </item>
		/// <item>
		/// <term>NTE_INVALID_HANDLE</term>
		/// <term>The hPrivKey or the hPubKey parameter is not valid.</term>
		/// </item>
		/// <item>
		/// <term>NTE_INVALID_PARAMETER</term>
		/// <term>One or more parameters are not valid.</term>
		/// </item>
		/// <item>
		/// <term>NTE_NO_MEMORY</term>
		/// <term>A memory allocation failure occurred.</term>
		/// </item>
		/// </list>
		/// </returns>
		/// <remarks>
		/// <para>
		/// A service must not call this function from its StartService Function. If a service calls this function from its StartService
		/// function, a deadlock can occur, and the service may stop responding.
		/// </para>
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows/desktop/api/ncrypt/nf-ncrypt-ncryptsecretagreement SECURITY_STATUS NCryptSecretAgreement(
		// NCRYPT_KEY_HANDLE hPrivKey, NCRYPT_KEY_HANDLE hPubKey, NCRYPT_SECRET_HANDLE *phAgreedSecret, DWORD dwFlags );
		[DllImport(Lib.Ncrypt, SetLastError = false, ExactSpelling = true)]
		[PInvokeData("ncrypt.h", MSDNShortId = "b5bf3eac-1fae-43e2-84b6-e8e5e255d7c5")]
		public static extern HRESULT NCryptSecretAgreement(NCRYPT_KEY_HANDLE hPrivKey, NCRYPT_KEY_HANDLE hPubKey, out SafeNCRYPT_SECRET_HANDLE phAgreedSecret, NCryptUIFlags dwFlags = 0);

		/// <summary>
		/// <para>The <c>NCryptSetProperty</c> function sets the value for a named property for a CNG key storage object.</para>
		/// </summary>
		/// <param name="hObject">
		/// <para>The handle of the key storage object to set the property for.</para>
		/// </param>
		/// <param name="pszProperty">
		/// <para>
		/// A pointer to a null-terminated Unicode string that contains the name of the property to set. This can be one of the predefined
		/// Key Storage Property Identifiers or a custom property identifier.
		/// </para>
		/// </param>
		/// <param name="pbInput">
		/// <para>The address of a buffer that contains the new property value. The cbInput parameter contains the size of this buffer.</para>
		/// </param>
		/// <param name="cbInput">
		/// <para>The size, in bytes, of the pbInput buffer.</para>
		/// </param>
		/// <param name="dwFlags">
		/// <para>Flags that modify function behavior. This can be zero or a combination of one or more of the following values.</para>
		/// <list type="table">
		/// <listheader>
		/// <term>Value</term>
		/// <term>Meaning</term>
		/// </listheader>
		/// <item>
		/// <term>NCRYPT_PERSIST_FLAG</term>
		/// <term>
		/// The property should be stored in key storage along with the key material. This flag can only be used when the hObject parameter
		/// is the handle of a persisted key. The maximum size of the data for any persisted property is NCRYPT_MAX_PROPERTY_DATA bytes.
		/// </term>
		/// </item>
		/// <item>
		/// <term>NCRYPT_PERSIST_ONLY_FLAG</term>
		/// <term>
		/// Do not overwrite any built-in values for this property and only set the user-persisted properties of the key. The maximum size of
		/// the data for any persisted property is NCRYPT_MAX_PROPERTY_DATA bytes. This flag cannot be used with the
		/// NCRYPT_SECURITY_DESCR_PROPERTY property.
		/// </term>
		/// </item>
		/// <item>
		/// <term>NCRYPT_SILENT_FLAG</term>
		/// <term>
		/// Requests that the key service provider (KSP) not display any user interface. If the provider must display the UI to operate, the
		/// call fails and the KSP should set the NTE_SILENT_CONTEXT error code as the last error.
		/// </term>
		/// </item>
		/// </list>
		/// <para>
		/// For the <c>NCRYPT_SECURITY_DESCR_PROPERTY</c> property, this parameter must also contain one of the following values, which
		/// identifies the part of the security descriptor to set.
		/// </para>
		/// <list type="table">
		/// <listheader>
		/// <term>Value</term>
		/// <term>Meaning</term>
		/// </listheader>
		/// <item>
		/// <term>OWNER_SECURITY_INFORMATION</term>
		/// <term>
		/// Set the security identifier (SID) of the object's owner. Use the SetSecurityDescriptorOwner function to set the owner SID in the
		/// SECURITY_DESCRIPTOR structure.
		/// </term>
		/// </item>
		/// <item>
		/// <term>GROUP_SECURITY_INFORMATION</term>
		/// <term>
		/// Set the SID of the object's primary group. Use the SetSecurityDescriptorGroup function to set the group SID in the
		/// SECURITY_DESCRIPTOR structure.
		/// </term>
		/// </item>
		/// <item>
		/// <term>DACL_SECURITY_INFORMATION</term>
		/// <term>
		/// Set the discretionary access control list (DACL). Use the SetSecurityDescriptorSacl function to set the DACL in the
		/// SECURITY_DESCRIPTOR structure.
		/// </term>
		/// </item>
		/// <item>
		/// <term>SACL_SECURITY_INFORMATION</term>
		/// <term>
		/// Set the system access control list (SACL). Use the SetSecurityDescriptorDacl function to set the SACL in the SECURITY_DESCRIPTOR structure.
		/// </term>
		/// </item>
		/// <item>
		/// <term>LABEL_SECURITY_INFORMATION</term>
		/// <term>
		/// Set the mandatory label access control entry in the SACL of the object. Use the SetSecurityDescriptorDacl function to set the
		/// SACL in the SECURITY_DESCRIPTOR structure. For more information about the mandatory label access control entry, see Windows
		/// Integrity Mechanism Design.
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
		/// <term>ERROR_SUCCESS</term>
		/// <term>The function was successful.</term>
		/// </item>
		/// <item>
		/// <term>NTE_BAD_FLAGS</term>
		/// <term>The dwFlags parameter contains a value that is not valid.</term>
		/// </item>
		/// <item>
		/// <term>NTE_INVALID_HANDLE</term>
		/// <term>The hObject parameter is not valid.</term>
		/// </item>
		/// <item>
		/// <term>NTE_INVALID_PARAMETER</term>
		/// <term>One or more parameters are not valid.</term>
		/// </item>
		/// <item>
		/// <term>NTE_NO_MEMORY</term>
		/// <term>A memory allocation failure occurred.</term>
		/// </item>
		/// <item>
		/// <term>NTE_NOT_SUPPORTED</term>
		/// <term>The specified property is not supported for the object.</term>
		/// </item>
		/// </list>
		/// </returns>
		/// <remarks>
		/// <para>
		/// A service must not call this function from its StartService Function. If a service calls this function from its StartService
		/// function, a deadlock can occur, and the service may stop responding.
		/// </para>
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows/desktop/api/ncrypt/nf-ncrypt-ncryptsetproperty SECURITY_STATUS NCryptSetProperty(
		// NCRYPT_HANDLE hObject, LPCWSTR pszProperty, PBYTE pbInput, DWORD cbInput, DWORD dwFlags );
		[DllImport(Lib.Ncrypt, SetLastError = false, ExactSpelling = true)]
		[PInvokeData("ncrypt.h", MSDNShortId = "ad1148aa-5f64-4867-9e17-6b41cc0c20b7")]
		public static extern HRESULT NCryptSetProperty(NCRYPT_HANDLE hObject, [MarshalAs(UnmanagedType.LPWStr)] string pszProperty, IntPtr pbInput, uint cbInput, SetPropFlags dwFlags);

		/// <summary>
		/// <para>The <c>NCryptSetProperty</c> function sets the value for a named property for a CNG key storage object.</para>
		/// </summary>
		/// <param name="hObject">
		/// <para>The handle of the key storage object to set the property for.</para>
		/// </param>
		/// <param name="pszProperty">
		/// <para>
		/// A pointer to a null-terminated Unicode string that contains the name of the property to set. This can be one of the predefined
		/// Key Storage Property Identifiers or a custom property identifier.
		/// </para>
		/// </param>
		/// <param name="pbInput">
		/// <para>The address of a buffer that contains the new property value. The cbInput parameter contains the size of this buffer.</para>
		/// </param>
		/// <param name="cbInput">
		/// <para>The size, in bytes, of the pbInput buffer.</para>
		/// </param>
		/// <param name="dwFlags">
		/// <para>Flags that modify function behavior. This can be zero or a combination of one or more of the following values.</para>
		/// <list type="table">
		/// <listheader>
		/// <term>Value</term>
		/// <term>Meaning</term>
		/// </listheader>
		/// <item>
		/// <term>NCRYPT_PERSIST_FLAG</term>
		/// <term>
		/// The property should be stored in key storage along with the key material. This flag can only be used when the hObject parameter
		/// is the handle of a persisted key. The maximum size of the data for any persisted property is NCRYPT_MAX_PROPERTY_DATA bytes.
		/// </term>
		/// </item>
		/// <item>
		/// <term>NCRYPT_PERSIST_ONLY_FLAG</term>
		/// <term>
		/// Do not overwrite any built-in values for this property and only set the user-persisted properties of the key. The maximum size of
		/// the data for any persisted property is NCRYPT_MAX_PROPERTY_DATA bytes. This flag cannot be used with the
		/// NCRYPT_SECURITY_DESCR_PROPERTY property.
		/// </term>
		/// </item>
		/// <item>
		/// <term>NCRYPT_SILENT_FLAG</term>
		/// <term>
		/// Requests that the key service provider (KSP) not display any user interface. If the provider must display the UI to operate, the
		/// call fails and the KSP should set the NTE_SILENT_CONTEXT error code as the last error.
		/// </term>
		/// </item>
		/// </list>
		/// <para>
		/// For the <c>NCRYPT_SECURITY_DESCR_PROPERTY</c> property, this parameter must also contain one of the following values, which
		/// identifies the part of the security descriptor to set.
		/// </para>
		/// <list type="table">
		/// <listheader>
		/// <term>Value</term>
		/// <term>Meaning</term>
		/// </listheader>
		/// <item>
		/// <term>OWNER_SECURITY_INFORMATION</term>
		/// <term>
		/// Set the security identifier (SID) of the object's owner. Use the SetSecurityDescriptorOwner function to set the owner SID in the
		/// SECURITY_DESCRIPTOR structure.
		/// </term>
		/// </item>
		/// <item>
		/// <term>GROUP_SECURITY_INFORMATION</term>
		/// <term>
		/// Set the SID of the object's primary group. Use the SetSecurityDescriptorGroup function to set the group SID in the
		/// SECURITY_DESCRIPTOR structure.
		/// </term>
		/// </item>
		/// <item>
		/// <term>DACL_SECURITY_INFORMATION</term>
		/// <term>
		/// Set the discretionary access control list (DACL). Use the SetSecurityDescriptorSacl function to set the DACL in the
		/// SECURITY_DESCRIPTOR structure.
		/// </term>
		/// </item>
		/// <item>
		/// <term>SACL_SECURITY_INFORMATION</term>
		/// <term>
		/// Set the system access control list (SACL). Use the SetSecurityDescriptorDacl function to set the SACL in the SECURITY_DESCRIPTOR structure.
		/// </term>
		/// </item>
		/// <item>
		/// <term>LABEL_SECURITY_INFORMATION</term>
		/// <term>
		/// Set the mandatory label access control entry in the SACL of the object. Use the SetSecurityDescriptorDacl function to set the
		/// SACL in the SECURITY_DESCRIPTOR structure. For more information about the mandatory label access control entry, see Windows
		/// Integrity Mechanism Design.
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
		/// <term>ERROR_SUCCESS</term>
		/// <term>The function was successful.</term>
		/// </item>
		/// <item>
		/// <term>NTE_BAD_FLAGS</term>
		/// <term>The dwFlags parameter contains a value that is not valid.</term>
		/// </item>
		/// <item>
		/// <term>NTE_INVALID_HANDLE</term>
		/// <term>The hObject parameter is not valid.</term>
		/// </item>
		/// <item>
		/// <term>NTE_INVALID_PARAMETER</term>
		/// <term>One or more parameters are not valid.</term>
		/// </item>
		/// <item>
		/// <term>NTE_NO_MEMORY</term>
		/// <term>A memory allocation failure occurred.</term>
		/// </item>
		/// <item>
		/// <term>NTE_NOT_SUPPORTED</term>
		/// <term>The specified property is not supported for the object.</term>
		/// </item>
		/// </list>
		/// </returns>
		/// <remarks>
		/// <para>
		/// A service must not call this function from its StartService Function. If a service calls this function from its StartService
		/// function, a deadlock can occur, and the service may stop responding.
		/// </para>
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows/desktop/api/ncrypt/nf-ncrypt-ncryptsetproperty SECURITY_STATUS NCryptSetProperty(
		// NCRYPT_HANDLE hObject, LPCWSTR pszProperty, PBYTE pbInput, DWORD cbInput, DWORD dwFlags );
		[DllImport(Lib.Ncrypt, SetLastError = false, ExactSpelling = true)]
		[PInvokeData("ncrypt.h", MSDNShortId = "ad1148aa-5f64-4867-9e17-6b41cc0c20b7")]
		public static extern HRESULT NCryptSetProperty(NCRYPT_HANDLE hObject, [MarshalAs(UnmanagedType.LPWStr)] string pszProperty, byte[] pbInput, uint cbInput, SetPropFlags dwFlags);

		/// <summary>The <c>NCryptSignHash</c> function creates a signature of a hash value.</summary>
		/// <param name="hKey">The handle of the key to use to sign the hash.</param>
		/// <param name="pPaddingInfo">
		/// A pointer to a structure that contains padding information. The actual type of structure this parameter points to depends on the
		/// value of the dwFlags parameter. This parameter is only used with asymmetric keys and must be <c>NULL</c> otherwise.
		/// </param>
		/// <param name="pbHashValue">
		/// A pointer to a buffer that contains the hash value to sign. The cbInput parameter contains the size of this buffer.
		/// </param>
		/// <param name="cbHashValue">The number of bytes in the pbHashValue buffer to sign.</param>
		/// <param name="pbSignature">
		/// <para>
		/// The address of a buffer to receive the signature produced by this function. The cbSignature parameter contains the size of this buffer.
		/// </para>
		/// <para>
		/// If this parameter is <c>NULL</c>, this function will calculate the size required for the signature and return the size in the
		/// location pointed to by the pcbResult parameter.
		/// </para>
		/// </param>
		/// <param name="cbSignature">
		/// The size, in bytes, of the pbSignature buffer. This parameter is ignored if the pbSignature parameter is <c>NULL</c>.
		/// </param>
		/// <param name="pcbResult">
		/// <para>A pointer to a <c>DWORD</c> variable that receives the number of bytes copied to the pbSignature buffer.</para>
		/// <para>If pbSignature is <c>NULL</c>, this receives the size, in bytes, required for the signature.</para>
		/// </param>
		/// <param name="dwFlags">
		/// <para>Flags that modify function behavior. The allowed set of flags depends on the type of key specified by the hKey parameter.</para>
		/// <para>If the key is a symmetric key, this parameter is not used and should be set to zero.</para>
		/// <para>If the key is an asymmetric key, this can be one of the following values.</para>
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
		/// <item>
		/// <term>NCRYPT_SILENT_FLAG</term>
		/// <term>
		/// Requests that the key service provider (KSP) not display any user interface. If the provider must display the UI to operate, the
		/// call fails and the KSP should set the NTE_SILENT_CONTEXT error code as the last error.
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
		/// <term>ERROR_SUCCESS</term>
		/// <term>The function was successful.</term>
		/// </item>
		/// <item>
		/// <term>NTE_BAD_ALGID</term>
		/// <term>The key represented by the hKey parameter does not support signing.</term>
		/// </item>
		/// <item>
		/// <term>NTE_BAD_FLAGS</term>
		/// <term>The dwFlags parameter contains a value that is not valid.</term>
		/// </item>
		/// <item>
		/// <term>NTE_INVALID_HANDLE</term>
		/// <term>The hKey parameter is not valid.</term>
		/// </item>
		/// <item>
		/// <term>NTE_INVALID_PARAMETER</term>
		/// <term>One or more parameters are not valid.</term>
		/// </item>
		/// <item>
		/// <term>NTE_NO_MEMORY</term>
		/// <term>A memory allocation failure occurred.</term>
		/// </item>
		/// </list>
		/// </returns>
		/// <remarks>
		/// A service must not call this function from its StartService Function. If a service calls this function from its StartService
		/// function, a deadlock can occur, and the service may stop responding.
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows/win32/api/ncrypt/nf-ncrypt-ncryptsignhash SECURITY_STATUS NCryptSignHash(
		// NCRYPT_KEY_HANDLE hKey, VOID *pPaddingInfo, PBYTE pbHashValue, DWORD cbHashValue, PBYTE pbSignature, DWORD cbSignature, DWORD
		// *pcbResult, DWORD dwFlags );
		[DllImport(Lib.Ncrypt, SetLastError = false, ExactSpelling = true)]
		[PInvokeData("ncrypt.h", MSDNShortId = "7404e37a-d7c6-49ed-b951-6081dd2b921a")]
		public static extern HRESULT NCryptSignHash(NCRYPT_KEY_HANDLE hKey, [In, Optional] IntPtr pPaddingInfo, [In] IntPtr pbHashValue, uint cbHashValue, [In, Out] IntPtr pbSignature, uint cbSignature, out uint pcbResult, NCryptDecryptFlag dwFlags);

		/// <summary>The <c>NCryptTranslateHandle</c> function translates a CryptoAPI handle into a CNG key handle.</summary>
		/// <param name="phProvider">
		/// A pointer to an <c>NCRYPT_PROV_HANDLE</c> variable that receives the handle of the CNG key storage provider that owns the CNG key
		/// placed in the phKey parameter. This parameter can be <c>NULL</c> if this handle is not needed.
		/// </param>
		/// <param name="phKey">A pointer to a <c>NCRYPT_KEY_HANDLE</c> variable that receives the CNG key handle.</param>
		/// <param name="hLegacyProv">
		/// The handle of the CryptoAPI provider that contains the key to translate. This function will translate the CryptoAPI key that is
		/// in the container in this provider.
		/// </param>
		/// <param name="hLegacyKey">
		/// <para>
		/// The handle of a CryptoAPI key to use to help determine the key specification for the returned key. This parameter is ignored if
		/// the dwLegacyKeySpec parameter contains a value other than zero.
		/// </para>
		/// <para>
		/// If hLegacyKey is <c>NULL</c> and dwLegacyKeySpec is zero, this function will attempt to determine the key specification from the
		/// hLegacyProv handle.
		/// </para>
		/// </param>
		/// <param name="dwLegacyKeySpec">
		/// <para>Specifies the key specification for the key. This can be one of the following values.</para>
		/// <list type="table">
		/// <listheader>
		/// <term>Value</term>
		/// <term>Meaning</term>
		/// </listheader>
		/// <item>
		/// <term>0</term>
		/// <term>The key is none of the types below.</term>
		/// </item>
		/// <item>
		/// <term>AT_KEYEXCHANGE 1</term>
		/// <term>The key is a key exchange key.</term>
		/// </item>
		/// <item>
		/// <term>AT_SIGNATURE 2</term>
		/// <term>The key is a signature key.</term>
		/// </item>
		/// </list>
		/// <para>
		/// If hLegacyKey is <c>NULL</c> and dwLegacyKeySpec is zero, this function will attempt to determine the key specification from the
		/// hLegacyProv handle.
		/// </para>
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
		/// <term>ERROR_SUCCESS</term>
		/// <term>The function was successful.</term>
		/// </item>
		/// <item>
		/// <term>NTE_BAD_FLAGS</term>
		/// <term>The dwFlags parameter contains a value that is not valid.</term>
		/// </item>
		/// <item>
		/// <term>NTE_INVALID_PARAMETER</term>
		/// <term>One or more parameters are not valid.</term>
		/// </item>
		/// <item>
		/// <term>NTE_NO_MEMORY</term>
		/// <term>A memory allocation failure occurred.</term>
		/// </item>
		/// </list>
		/// </returns>
		/// <remarks>
		/// <para>
		/// This is a helper function intended to help applications and system components that currently use the CryptoAPI to make a graceful
		/// transition to using CNG.
		/// </para>
		/// <para>
		/// This function will only be successful if a CNG key storage provider is registered with a name or alias that is identical to the
		/// name of the cryptographic service provider (CSP) referred to by the hLegacyProv parameter.
		/// </para>
		/// <para>This function will perform the following steps to translate the CSP handle into a CNG key handle:</para>
		/// <list type="number">
		/// <item>
		/// <term>Obtain the name of the CSP from the hLegacyProv handle.</term>
		/// </item>
		/// <item>
		/// <term>Open the CNG provider whose name or alias is identical to the CSP name.</term>
		/// </item>
		/// <item>
		/// <term>Obtain the name of the current key container in the CSP.</term>
		/// </item>
		/// <item>
		/// <term>Obtain the CryptoAPI key, translate it into a CNG key, and return it in the phKey parameter.</term>
		/// </item>
		/// </list>
		/// <para>
		/// A service must not call this function from its StartService Function. If a service calls this function from its StartService
		/// function, a deadlock can occur, and the service may stop responding.
		/// </para>
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows/win32/api/ncrypt/nf-ncrypt-ncrypttranslatehandle SECURITY_STATUS NCryptTranslateHandle(
		// NCRYPT_PROV_HANDLE *phProvider, NCRYPT_KEY_HANDLE *phKey, HCRYPTPROV hLegacyProv, HCRYPTKEY hLegacyKey, DWORD dwLegacyKeySpec,
		// DWORD dwFlags );
		[DllImport(Lib.Ncrypt, SetLastError = false, ExactSpelling = true)]
		[PInvokeData("ncrypt.h", MSDNShortId = "0c339864-b598-430c-a597-09d3571fdbb2")]
		public static extern HRESULT NCryptTranslateHandle(out SafeNCRYPT_PROV_HANDLE phProvider, out SafeNCRYPT_KEY_HANDLE phKey, Crypt32.HCRYPTPROV hLegacyProv, Crypt32.HCRYPTKEY hLegacyKey, Crypt32.PrivateKeyType dwLegacyKeySpec, uint dwFlags = 0);

		/// <summary>
		/// <para>
		/// [Some information relates to pre-released product which may be substantially modified before it's commercially released.
		/// Microsoft makes no warranties, express or implied, with respect to the information provided here.]
		/// </para>
		/// <para>Verifies a key attestation claim.</para>
		/// </summary>
		/// <param name="hSubjectKey">The subject key handle for the claim.</param>
		/// <param name="hAuthorityKey">
		/// The authority key handle to use when verifying the claim. This parameter is optional because the authority key is self-contained
		/// for certain claim types.
		/// </param>
		/// <param name="dwClaimType">The type of claim.</param>
		/// <param name="pParameterList">An optional parameter list.</param>
		/// <param name="pbClaimBlob">The input claim blob.</param>
		/// <param name="cbClaimBlob"/>
		/// <param name="pOutput">The output blob.</param>
		/// <param name="dwFlags">As of Windows 10, no flags are defined. This parameter should be set to 0.</param>
		/// <returns>Returns a status code that indicates the success or failure of the function.</returns>
		// https://docs.microsoft.com/en-us/windows/win32/api/ncrypt/nf-ncrypt-ncryptverifyclaim SECURITY_STATUS NCryptVerifyClaim(
		// NCRYPT_KEY_HANDLE hSubjectKey, NCRYPT_KEY_HANDLE hAuthorityKey, DWORD dwClaimType, NCryptBufferDesc *pParameterList, PBYTE
		// pbClaimBlob, DWORD cbClaimBlob, NCryptBufferDesc *pOutput, DWORD dwFlags );
		[DllImport(Lib.Ncrypt, SetLastError = false, ExactSpelling = true)]
		[PInvokeData("ncrypt.h", MSDNShortId = "D3C837A5-49D7-4099-B8FE-37364A275A73")]
		public static extern HRESULT NCryptVerifyClaim(NCRYPT_KEY_HANDLE hSubjectKey, [Optional] NCRYPT_KEY_HANDLE hAuthorityKey, uint dwClaimType, [Optional] NCryptBufferDesc[] pParameterList, [In] IntPtr pbClaimBlob, uint cbClaimBlob, out NCryptBufferDesc pOutput, uint dwFlags = 0);

		/// <summary>The <c>NCryptVerifySignature</c> function verifies that the specified signature matches the specified hash.</summary>
		/// <param name="hKey">
		/// The handle of the key to use to decrypt the signature. This must be an identical key or the public key portion of the key pair
		/// used to sign the data with the NCryptSignHash function.
		/// </param>
		/// <param name="pPaddingInfo">
		/// A pointer to a structure that contains padding information. The actual type of structure this parameter points to depends on the
		/// value of the dwFlags parameter. This parameter is only used with asymmetric keys and must be <c>NULL</c> otherwise.
		/// </param>
		/// <param name="pbHashValue">
		/// The address of a buffer that contains the hash of the data. The cbHash parameter contains the size of this buffer.
		/// </param>
		/// <param name="cbHashValue">The size, in bytes, of the pbHash buffer.</param>
		/// <param name="pbSignature">
		/// The address of a buffer that contains the signed hash of the data. The NCryptSignHash function is used to create the signature.
		/// The cbSignature parameter contains the size of this buffer.
		/// </param>
		/// <param name="cbSignature">
		/// The size, in bytes, of the pbSignature buffer. The NCryptSignHash function is used to create the signature.
		/// </param>
		/// <param name="dwFlags">
		/// <para>Flags that modify function behavior. The allowed set of flags depends on the type of key specified by the hKey parameter.</para>
		/// <para>If the key is a symmetric key, this parameter is not used and should be zero.</para>
		/// <para>If the key is an asymmetric key, this can be one of the following values.</para>
		/// <list type="table">
		/// <listheader>
		/// <term>Value</term>
		/// <term>Meaning</term>
		/// </listheader>
		/// <item>
		/// <term>NCRYPT_PAD_PKCS1_FLAG</term>
		/// <term>
		/// The PKCS1 padding scheme was used when the signature was created. The pPaddingInfo parameter is a pointer to a
		/// BCRYPT_PKCS1_PADDING_INFO structure.
		/// </term>
		/// </item>
		/// <item>
		/// <term>NCRYPT_PAD_PSS_FLAG</term>
		/// <term>
		/// The Probabilistic Signature Scheme (PSS) padding scheme was used when the signature was created. The pPaddingInfo parameter is a
		/// pointer to a BCRYPT_PSS_PADDING_INFO structure.
		/// </term>
		/// </item>
		/// <item>
		/// <term>NCRYPT_SILENT_FLAG</term>
		/// <term>
		/// Requests that the key service provider (KSP) not display any user interface. If the provider must display the UI to operate, the
		/// call fails and the KSP should set the NTE_SILENT_CONTEXT error code as the last error.
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
		/// <term>ERROR_SUCCESS</term>
		/// <term>The function was successful.</term>
		/// </item>
		/// <item>
		/// <term>NTE_BAD_SIGNATURE</term>
		/// <term>The signature was not verified.</term>
		/// </item>
		/// <item>
		/// <term>NTE_INVALID_HANDLE</term>
		/// <term>The hKey parameter is not valid.</term>
		/// </item>
		/// <item>
		/// <term>NTE_NO_MEMORY</term>
		/// <term>A memory allocation failure occurred.</term>
		/// </item>
		/// <item>
		/// <term>NTE_NOT_SUPPORTED</term>
		/// <term>The algorithm provider used to create the key handle specified by the hKey parameter is not a signing algorithm.</term>
		/// </item>
		/// </list>
		/// </returns>
		/// <remarks>
		/// A service must not call this function from its StartService Function. If a service calls this function from its StartService
		/// function, a deadlock can occur, and the service may stop responding.
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows/win32/api/ncrypt/nf-ncrypt-ncryptverifysignature SECURITY_STATUS NCryptVerifySignature(
		// NCRYPT_KEY_HANDLE hKey, VOID *pPaddingInfo, PBYTE pbHashValue, DWORD cbHashValue, PBYTE pbSignature, DWORD cbSignature, DWORD
		// dwFlags );
		[DllImport(Lib.Ncrypt, SetLastError = false, ExactSpelling = true)]
		[PInvokeData("ncrypt.h", MSDNShortId = "9a839d99-4e9a-4114-982c-51dee38d2949")]
		public static extern HRESULT NCryptVerifySignature(NCRYPT_KEY_HANDLE hKey, [In, Optional] IntPtr pPaddingInfo, [In] IntPtr pbHashValue, uint cbHashValue, [In] IntPtr pbSignature, uint cbSignature, NCryptDecryptFlag dwFlags);

		/// <summary>
		/// <para>
		/// The <c>NCRYPT_ALLOC_PARA</c> structure enables you to specify custom functions that can be used to allocate and free data. This
		/// structure is used in the following functions:
		/// </para>
		/// <list type="bullet">
		/// <item>
		/// <term>NCryptGetProtectionDescriptorInfo</term>
		/// </item>
		/// <item>
		/// <term>NCryptProtectSecret</term>
		/// </item>
		/// <item>
		/// <term>NCryptUnprotectSecret</term>
		/// </item>
		/// </list>
		/// </summary>
		// https://docs.microsoft.com/en-us/windows/desktop/api/ncrypt/ns-ncrypt-ncrypt_alloc_para typedef struct NCRYPT_ALLOC_PARA { DWORD
		// cbSize; PFN_NCRYPT_ALLOC pfnAlloc; PFN_NCRYPT_FREE pfnFree; } NCRYPT_ALLOC_PARA;
		[PInvokeData("ncrypt.h", MSDNShortId = "4F546F51-E4DE-4703-B1D1-F84165C3C31B")]
		[StructLayout(LayoutKind.Sequential, CharSet = CharSet.Auto)]
		public struct NCRYPT_ALLOC_PARA
		{
			/// <summary>The size, in bytes, of this structure.</summary>
			public uint cbSize;

			/// <summary>Address of a custom function that can allocate memory.</summary>
			public PFN_NCRYPT_ALLOC pfnAlloc;

			/// <summary>Address of a function that can free memory allocated by the function specified by the <c>pfnAlloc</c> member.</summary>
			public PFN_NCRYPT_FREE pfnFree;
		}

		/// <summary>Provides a handle to a hash handle.</summary>
		[StructLayout(LayoutKind.Sequential)]
		public struct NCRYPT_HASH_HANDLE : IHandle
		{
			private IntPtr handle;

			/// <summary>Initializes a new instance of the <see cref="NCRYPT_HASH_HANDLE"/> struct.</summary>
			/// <param name="preexistingHandle">An <see cref="IntPtr"/> object that represents the pre-existing handle to use.</param>
			public NCRYPT_HASH_HANDLE(IntPtr preexistingHandle) => handle = preexistingHandle;

			/// <summary>Returns an invalid handle by instantiating a <see cref="NCRYPT_HASH_HANDLE"/> object with <see cref="IntPtr.Zero"/>.</summary>
			public static NCRYPT_HASH_HANDLE NULL => new NCRYPT_HASH_HANDLE(IntPtr.Zero);

			/// <summary>Gets a value indicating whether this instance is a null handle.</summary>
			public bool IsNull => handle == IntPtr.Zero;

			/// <summary>Performs an explicit conversion from <see cref="NCRYPT_HASH_HANDLE"/> to <see cref="IntPtr"/>.</summary>
			/// <param name="h">The handle.</param>
			/// <returns>The result of the conversion.</returns>
			public static explicit operator IntPtr(NCRYPT_HASH_HANDLE h) => h.handle;

			/// <summary>Performs an implicit conversion from <see cref="IntPtr"/> to <see cref="NCRYPT_HASH_HANDLE"/>.</summary>
			/// <param name="h">The pointer to a handle.</param>
			/// <returns>The result of the conversion.</returns>
			public static implicit operator NCRYPT_HASH_HANDLE(IntPtr h) => new NCRYPT_HASH_HANDLE(h);

			/// <summary>Implements the operator !=.</summary>
			/// <param name="h1">The first handle.</param>
			/// <param name="h2">The second handle.</param>
			/// <returns>The result of the operator.</returns>
			public static bool operator !=(NCRYPT_HASH_HANDLE h1, NCRYPT_HASH_HANDLE h2) => !(h1 == h2);

			/// <summary>Implements the operator ==.</summary>
			/// <param name="h1">The first handle.</param>
			/// <param name="h2">The second handle.</param>
			/// <returns>The result of the operator.</returns>
			public static bool operator ==(NCRYPT_HASH_HANDLE h1, NCRYPT_HASH_HANDLE h2) => h1.Equals(h2);

			/// <inheritdoc/>
			public override bool Equals(object obj) => obj is NCRYPT_HASH_HANDLE h ? handle == h.handle : false;

			/// <inheritdoc/>
			public override int GetHashCode() => handle.GetHashCode();

			/// <inheritdoc/>
			public IntPtr DangerousGetHandle() => handle;
		}

		/// <summary>Provides a handle to a key storage object.</summary>
		[StructLayout(LayoutKind.Sequential)]
		public struct NCRYPT_HANDLE : IHandle
		{
			private IntPtr handle;

			/// <summary>Initializes a new instance of the <see cref="NCRYPT_HANDLE"/> struct.</summary>
			/// <param name="preexistingHandle">An <see cref="IntPtr"/> object that represents the pre-existing handle to use.</param>
			public NCRYPT_HANDLE(IntPtr preexistingHandle) => handle = preexistingHandle;

			/// <summary>Returns an invalid handle by instantiating a <see cref="NCRYPT_HANDLE"/> object with <see cref="IntPtr.Zero"/>.</summary>
			public static NCRYPT_HANDLE NULL => new NCRYPT_HANDLE(IntPtr.Zero);

			/// <summary>Gets a value indicating whether this instance is a null handle.</summary>
			public bool IsNull => handle == IntPtr.Zero;

			/// <summary>Performs an explicit conversion from <see cref="NCRYPT_HANDLE"/> to <see cref="IntPtr"/>.</summary>
			/// <param name="h">The handle.</param>
			/// <returns>The result of the conversion.</returns>
			public static explicit operator IntPtr(NCRYPT_HANDLE h) => h.handle;

			/// <summary>Performs an implicit conversion from <see cref="IntPtr"/> to <see cref="NCRYPT_HANDLE"/>.</summary>
			/// <param name="h">The pointer to a handle.</param>
			/// <returns>The result of the conversion.</returns>
			public static implicit operator NCRYPT_HANDLE(IntPtr h) => new NCRYPT_HANDLE(h);

			/// <summary>Implements the operator !=.</summary>
			/// <param name="h1">The first handle.</param>
			/// <param name="h2">The second handle.</param>
			/// <returns>The result of the operator.</returns>
			public static bool operator !=(NCRYPT_HANDLE h1, NCRYPT_HANDLE h2) => !(h1 == h2);

			/// <summary>Implements the operator ==.</summary>
			/// <param name="h1">The first handle.</param>
			/// <param name="h2">The second handle.</param>
			/// <returns>The result of the operator.</returns>
			public static bool operator ==(NCRYPT_HANDLE h1, NCRYPT_HANDLE h2) => h1.Equals(h2);

			/// <inheritdoc/>
			public override bool Equals(object obj) => obj is NCRYPT_HANDLE h ? handle == h.handle : false;

			/// <inheritdoc/>
			public override int GetHashCode() => handle.GetHashCode();

			/// <inheritdoc/>
			public IntPtr DangerousGetHandle() => handle;
		}

		/// <summary>Provides a handle to a key.</summary>
		[StructLayout(LayoutKind.Sequential)]
		public struct NCRYPT_KEY_HANDLE : IHandle
		{
			private IntPtr handle;

			/// <summary>Initializes a new instance of the <see cref="NCRYPT_KEY_HANDLE"/> struct.</summary>
			/// <param name="preexistingHandle">An <see cref="IntPtr"/> object that represents the pre-existing handle to use.</param>
			public NCRYPT_KEY_HANDLE(IntPtr preexistingHandle) => handle = preexistingHandle;

			/// <summary>Returns an invalid handle by instantiating a <see cref="NCRYPT_KEY_HANDLE"/> object with <see cref="IntPtr.Zero"/>.</summary>
			public static NCRYPT_KEY_HANDLE NULL => new NCRYPT_KEY_HANDLE(IntPtr.Zero);

			/// <summary>Gets a value indicating whether this instance is a null handle.</summary>
			public bool IsNull => handle == IntPtr.Zero;

			/// <summary>Performs an explicit conversion from <see cref="NCRYPT_KEY_HANDLE"/> to <see cref="IntPtr"/>.</summary>
			/// <param name="h">The handle.</param>
			/// <returns>The result of the conversion.</returns>
			public static explicit operator IntPtr(NCRYPT_KEY_HANDLE h) => h.handle;

			/// <summary>Performs an implicit conversion from <see cref="IntPtr"/> to <see cref="NCRYPT_KEY_HANDLE"/>.</summary>
			/// <param name="h">The pointer to a handle.</param>
			/// <returns>The result of the conversion.</returns>
			public static implicit operator NCRYPT_KEY_HANDLE(IntPtr h) => new NCRYPT_KEY_HANDLE(h);

			/// <summary>Implements the operator !=.</summary>
			/// <param name="h1">The first handle.</param>
			/// <param name="h2">The second handle.</param>
			/// <returns>The result of the operator.</returns>
			public static bool operator !=(NCRYPT_KEY_HANDLE h1, NCRYPT_KEY_HANDLE h2) => !(h1 == h2);

			/// <summary>Implements the operator ==.</summary>
			/// <param name="h1">The first handle.</param>
			/// <param name="h2">The second handle.</param>
			/// <returns>The result of the operator.</returns>
			public static bool operator ==(NCRYPT_KEY_HANDLE h1, NCRYPT_KEY_HANDLE h2) => h1.Equals(h2);

			/// <inheritdoc/>
			public override bool Equals(object obj) => obj is NCRYPT_KEY_HANDLE h ? handle == h.handle : false;

			/// <inheritdoc/>
			public override int GetHashCode() => handle.GetHashCode();

			/// <inheritdoc/>
			public IntPtr DangerousGetHandle() => handle;
		}

		/// <summary>Provides a handle to a provider handle.</summary>
		[StructLayout(LayoutKind.Sequential)]
		public struct NCRYPT_PROV_HANDLE : IHandle
		{
			private IntPtr handle;

			/// <summary>Initializes a new instance of the <see cref="NCRYPT_PROV_HANDLE"/> struct.</summary>
			/// <param name="preexistingHandle">An <see cref="IntPtr"/> object that represents the pre-existing handle to use.</param>
			public NCRYPT_PROV_HANDLE(IntPtr preexistingHandle) => handle = preexistingHandle;

			/// <summary>Returns an invalid handle by instantiating a <see cref="NCRYPT_PROV_HANDLE"/> object with <see cref="IntPtr.Zero"/>.</summary>
			public static NCRYPT_PROV_HANDLE NULL => new NCRYPT_PROV_HANDLE(IntPtr.Zero);

			/// <summary>Gets a value indicating whether this instance is a null handle.</summary>
			public bool IsNull => handle == IntPtr.Zero;

			/// <summary>Performs an explicit conversion from <see cref="NCRYPT_PROV_HANDLE"/> to <see cref="IntPtr"/>.</summary>
			/// <param name="h">The handle.</param>
			/// <returns>The result of the conversion.</returns>
			public static explicit operator IntPtr(NCRYPT_PROV_HANDLE h) => h.handle;

			/// <summary>Performs an implicit conversion from <see cref="IntPtr"/> to <see cref="NCRYPT_PROV_HANDLE"/>.</summary>
			/// <param name="h">The pointer to a handle.</param>
			/// <returns>The result of the conversion.</returns>
			public static implicit operator NCRYPT_PROV_HANDLE(IntPtr h) => new NCRYPT_PROV_HANDLE(h);

			/// <summary>Implements the operator !=.</summary>
			/// <param name="h1">The first handle.</param>
			/// <param name="h2">The second handle.</param>
			/// <returns>The result of the operator.</returns>
			public static bool operator !=(NCRYPT_PROV_HANDLE h1, NCRYPT_PROV_HANDLE h2) => !(h1 == h2);

			/// <summary>Implements the operator ==.</summary>
			/// <param name="h1">The first handle.</param>
			/// <param name="h2">The second handle.</param>
			/// <returns>The result of the operator.</returns>
			public static bool operator ==(NCRYPT_PROV_HANDLE h1, NCRYPT_PROV_HANDLE h2) => h1.Equals(h2);

			/// <inheritdoc/>
			public override bool Equals(object obj) => obj is NCRYPT_PROV_HANDLE h ? handle == h.handle : false;

			/// <inheritdoc/>
			public override int GetHashCode() => handle.GetHashCode();

			/// <inheritdoc/>
			public IntPtr DangerousGetHandle() => handle;
		}

		/// <summary>Provides a handle to a secret agreement value.</summary>
		[StructLayout(LayoutKind.Sequential)]
		public struct NCRYPT_SECRET_HANDLE : IHandle
		{
			private IntPtr handle;

			/// <summary>Initializes a new instance of the <see cref="NCRYPT_SECRET_HANDLE"/> struct.</summary>
			/// <param name="preexistingHandle">An <see cref="IntPtr"/> object that represents the pre-existing handle to use.</param>
			public NCRYPT_SECRET_HANDLE(IntPtr preexistingHandle) => handle = preexistingHandle;

			/// <summary>Returns an invalid handle by instantiating a <see cref="NCRYPT_SECRET_HANDLE"/> object with <see cref="IntPtr.Zero"/>.</summary>
			public static NCRYPT_SECRET_HANDLE NULL => new NCRYPT_SECRET_HANDLE(IntPtr.Zero);

			/// <summary>Gets a value indicating whether this instance is a null handle.</summary>
			public bool IsNull => handle == IntPtr.Zero;

			/// <summary>Performs an explicit conversion from <see cref="NCRYPT_SECRET_HANDLE"/> to <see cref="IntPtr"/>.</summary>
			/// <param name="h">The handle.</param>
			/// <returns>The result of the conversion.</returns>
			public static explicit operator IntPtr(NCRYPT_SECRET_HANDLE h) => h.handle;

			/// <summary>Performs an implicit conversion from <see cref="IntPtr"/> to <see cref="NCRYPT_SECRET_HANDLE"/>.</summary>
			/// <param name="h">The pointer to a handle.</param>
			/// <returns>The result of the conversion.</returns>
			public static implicit operator NCRYPT_SECRET_HANDLE(IntPtr h) => new NCRYPT_SECRET_HANDLE(h);

			/// <summary>Implements the operator !=.</summary>
			/// <param name="h1">The first handle.</param>
			/// <param name="h2">The second handle.</param>
			/// <returns>The result of the operator.</returns>
			public static bool operator !=(NCRYPT_SECRET_HANDLE h1, NCRYPT_SECRET_HANDLE h2) => !(h1 == h2);

			/// <summary>Implements the operator ==.</summary>
			/// <param name="h1">The first handle.</param>
			/// <param name="h2">The second handle.</param>
			/// <returns>The result of the operator.</returns>
			public static bool operator ==(NCRYPT_SECRET_HANDLE h1, NCRYPT_SECRET_HANDLE h2) => h1.Equals(h2);

			/// <inheritdoc/>
			public override bool Equals(object obj) => obj is NCRYPT_SECRET_HANDLE h ? handle == h.handle : false;

			/// <inheritdoc/>
			public override int GetHashCode() => handle.GetHashCode();

			/// <inheritdoc/>
			public IntPtr DangerousGetHandle() => handle;
		}

		/// <summary>The <c>NCryptAlgorithmName</c> structure is used to contain information about a CNG algorithm.</summary>
		// https://docs.microsoft.com/en-us/windows/win32/api/ncrypt/ns-ncrypt-ncryptalgorithmname typedef struct _NCryptAlgorithmName {
		// LPWSTR pszName; DWORD dwClass; DWORD dwAlgOperations; DWORD dwFlags; } NCryptAlgorithmName;
		[PInvokeData("ncrypt.h", MSDNShortId = "79b0193e-3be8-46ce-a422-40ed9698363f")]
		[StructLayout(LayoutKind.Sequential, CharSet = CharSet.Unicode)]
		public struct NCryptAlgorithmName
		{
			/// <summary>
			/// A pointer to a null-terminated Unicode string that contains the name of the algorithm. This can be one of the standard CNG
			/// Algorithm Identifiers or the identifier for another registered algorithm.
			/// </summary>
			[MarshalAs(UnmanagedType.LPWStr)]
			public string pszName;

			/// <summary>
			/// <para>
			/// A <c>DWORD</c> value that defines which algorithm class this algorithm belongs to. This can be one of the following values.
			/// </para>
			/// <list type="table">
			/// <listheader>
			/// <term>Value</term>
			/// <term>Meaning</term>
			/// </listheader>
			/// <item>
			/// <term>NCRYPT_ASYMMETRIC_ENCRYPTION_INTERFACE 0x00000003</term>
			/// <term>The algorithm belongs to the asymmetric encryption class of algorithms.</term>
			/// </item>
			/// <item>
			/// <term>NCRYPT_SECRET_AGREEMENT_INTERFACE 0x00000004</term>
			/// <term>The algorithm belongs to the secret agreement (Diffie-Hellman) class of algorithms.</term>
			/// </item>
			/// <item>
			/// <term>NCRYPT_SIGNATURE_INTERFACE 0x00000005</term>
			/// <term>The algorithm belongs to the signature class of algorithms.</term>
			/// </item>
			/// </list>
			/// </summary>
			public BCrypt.InterfaceId dwClass;

			/// <summary>
			/// <para>
			/// A <c>DWORD</c> value that defines which operational classes this algorithm belongs to. This can be a combination of one or
			/// more of the following values.
			/// </para>
			/// <list type="table">
			/// <listheader>
			/// <term>Value</term>
			/// <term>Meaning</term>
			/// </listheader>
			/// <item>
			/// <term>NCRYPT_ASYMMETRIC_ENCRYPTION_OPERATION 0x00000004</term>
			/// <term>The algorithm is an asymmetric encryption algorithm.</term>
			/// </item>
			/// <item>
			/// <term>NCRYPT_SECRET_AGREEMENT_OPERATION 0x00000008</term>
			/// <term>The algorithm is a secret agreement (Diffie-Hellman) algorithm.</term>
			/// </item>
			/// <item>
			/// <term>NCRYPT_SIGNATURE_OPERATION 0x00000010</term>
			/// <term>The algorithm is a digital signature algorithm.</term>
			/// </item>
			/// </list>
			/// </summary>
			public BCrypt.AlgOperations dwAlgOperations;

			/// <summary>A set of flags that provide more information about the algorithm.</summary>
			public uint dwFlags;
		}

		/// <summary>The <c>NCryptBuffer</c> structure is used to identify a variable-length memory buffer.</summary>
		/// <remarks>BCryptBuffer is an alias for this structure.</remarks>
		// https://docs.microsoft.com/en-us/windows/desktop/api/bcrypt/ns-bcrypt-_bcryptbuffer typedef struct _BCryptBuffer { ULONG cbBuffer;
		// ULONG BufferType; PVOID pvBuffer; } BCryptBuffer, *PBCryptBuffer;
		[PInvokeData("bcrypt.h", MSDNShortId = "474d3c0d-ae14-448a-a56d-25abc7e5de88")]
		public struct NCryptBuffer
		{
			/// <summary>
			/// <para>A value that identifies the type of data that is contained by the buffer. This can be one of the following values.</para>
			/// <list type="table">
			/// <listheader>
			/// <term>Value</term>
			/// <term>Meaning</term>
			/// </listheader>
			/// <item>
			/// <term>KDF_HASH_ALGORITHM 0</term>
			/// <term>
			/// The buffer is a key derivation function (KDF) parameter that contains a null-terminated Unicode string that identifies the
			/// hash algorithm. This can be one of the standard hash algorithm identifiers from CNG Algorithm Identifiers or the identifier
			/// for another registered hash algorithm. The size specified by the cbBuffer member of this structure must include the
			/// terminating NULL character.
			/// </term>
			/// </item>
			/// <item>
			/// <term>KDF_SECRET_PREPEND 1</term>
			/// <term>The buffer is a KDF parameter that contains the value to add to the beginning of the message input to the hash function.</term>
			/// </item>
			/// <item>
			/// <term>KDF_SECRET_APPEND 2</term>
			/// <term>The buffer is a KDF parameter that contains the value to add to the end of the message input to the hash function.</term>
			/// </item>
			/// <item>
			/// <term>KDF_HMAC_KEY 3</term>
			/// <term>The buffer is a KDF parameter that contains the plain text value of the HMAC key.</term>
			/// </item>
			/// <item>
			/// <term>KDF_TLS_PRF_LABEL 4</term>
			/// <term>
			/// The buffer is a KDF parameter that contains an ANSI string that contains the transport layer security (TLS) pseudo-random
			/// function (PRF) label.
			/// </term>
			/// </item>
			/// <item>
			/// <term>KDF_TLS_PRF_SEED 5</term>
			/// <term>The buffer is a KDF parameter that contains the PRF seed value. The seed must be 64 bytes long.</term>
			/// </item>
			/// <item>
			/// <term>KDF_SECRET_HANDLE 6</term>
			/// <term>
			/// The buffer is a KDF parameter that contains the secret agreement handle. The pvBuffer member contains a BCRYPT_SECRET_HANDLE
			/// value and is not a pointer.
			/// </term>
			/// </item>
			/// <item>
			/// <term>KDF_TLS_PRF_PROTOCOL 7</term>
			/// <term>
			/// The buffer is a KDF parameter that contains a DWORD value identifying the SSL/TLS protocol version whose PRF algorithm is to
			/// be used.
			/// </term>
			/// </item>
			/// <item>
			/// <term>KDF_ALGORITHMID 8</term>
			/// <term>
			/// The buffer is a KDF parameter that contains the byte array to use as the AlgorithmID subfield of the OtherInfo parameter to
			/// the SP 800-56A KDF.
			/// </term>
			/// </item>
			/// <item>
			/// <term>KDF_PARTYUINFO 9</term>
			/// <term>
			/// The buffer is a KDF parameter that contains the byte array to use as the PartyUInfo subfield of the OtherInfo parameter to
			/// the SP 800-56A KDF.
			/// </term>
			/// </item>
			/// <item>
			/// <term>KDF_PARTYVINFO 10</term>
			/// <term>
			/// The buffer is a KDF parameter that contains the byte array to use as the PartyVInfo subfield of the OtherInfo parameter to
			/// the SP 800-56A KDF.
			/// </term>
			/// </item>
			/// <item>
			/// <term>KDF_SUPPPUBINFO 11</term>
			/// <term>
			/// The buffer is a KDF parameter that contains the byte array to use as the SuppPubInfo subfield of the OtherInfo parameter to
			/// the SP 800-56A KDF.
			/// </term>
			/// </item>
			/// <item>
			/// <term>KDF_SUPPPRIVINFO 12</term>
			/// <term>
			/// The buffer is a KDF parameter that contains the byte array to use as the SuppPrivInfo subfield of the OtherInfo parameter to
			/// the SP 800-56A KDF.
			/// </term>
			/// </item>
			/// <item>
			/// <term>NCRYPTBUFFER_SSL_CLIENT_RANDOM 20</term>
			/// <term>The buffer contains the random number of the SSL client.</term>
			/// </item>
			/// <item>
			/// <term>NCRYPTBUFFER_SSL_SERVER_RANDOM 21</term>
			/// <term>The buffer contains the random number of the SSL server.</term>
			/// </item>
			/// <item>
			/// <term>NCRYPTBUFFER_SSL_HIGHEST_VERSION 22</term>
			/// <term>The buffer contains the highest SSL version supported.</term>
			/// </item>
			/// <item>
			/// <term>NCRYPTBUFFER_SSL_CLEAR_KEY 23</term>
			/// <term>The buffer contains the clear portion of the SSL master key.</term>
			/// </item>
			/// <item>
			/// <term>NCRYPTBUFFER_SSL_KEY_ARG_DATA 24</term>
			/// <term>The buffer contains the SSL key argument data.</term>
			/// </item>
			/// <item>
			/// <term>NCRYPTBUFFER_PKCS_OID 40</term>
			/// <term>The buffer contains a null-terminated ANSI string that contains the PKCS object identifier.</term>
			/// </item>
			/// <item>
			/// <term>NCRYPTBUFFER_PKCS_ALG_OID 41</term>
			/// <term>The buffer contains a null-terminated ANSI string that contains the PKCS algorithm object identifier.</term>
			/// </item>
			/// <item>
			/// <term>NCRYPTBUFFER_PKCS_ALG_PARAM 42</term>
			/// <term>The buffer contains the PKCS algorithm parameters.</term>
			/// </item>
			/// <item>
			/// <term>NCRYPTBUFFER_PKCS_ALG_ID 43</term>
			/// <term>The buffer contains the PKCS algorithm identifier.</term>
			/// </item>
			/// <item>
			/// <term>NCRYPTBUFFER_PKCS_ATTRS 44</term>
			/// <term>The buffer contains the PKCS attributes.</term>
			/// </item>
			/// <item>
			/// <term>NCRYPTBUFFER_PKCS_KEY_NAME 45</term>
			/// <term>The buffer contains a null-terminated Unicode string that contains the key name.</term>
			/// </item>
			/// <item>
			/// <term>NCRYPTBUFFER_PKCS_SECRET 46</term>
			/// <term>
			/// The buffer contains a null-terminated Unicode string that contains the PKCS8 password. This parameter is optional and can be NULL.
			/// </term>
			/// </item>
			/// <item>
			/// <term>NCRYPTBUFFER_CERT_BLOB 47</term>
			/// <term>
			/// The buffer contains a serialized certificate store that contains the PKCS certificate. This serialized store is obtained by
			/// using the CertSaveStore function with the CERT_STORE_SAVE_TO_MEMORY option. When this property is being retrieved, you can
			/// access the certificate store by passing this serialized store to the CertOpenStore function with the
			/// CERT_STORE_PROV_SERIALIZED option.
			/// </term>
			/// </item>
			/// </list>
			/// </summary>
			public KeyDerivationBufferType BufferType;

			/// <summary>
			/// <para>The buffer.</para>
			/// <para>The format and contents of this buffer are identified by the <c>BufferType</c> member.</para>
			/// </summary>
			public byte[] pvBuffer;

			/// <summary>Initializes a new instance of the <see cref="NCryptBuffer"/> struct.</summary>
			/// <param name="bufferType">Type of the buffer.</param>
			/// <param name="buffer">The buffer.</param>
			public NCryptBuffer(KeyDerivationBufferType bufferType, byte[] buffer)
			{
				BufferType = bufferType;
				pvBuffer = buffer;
			}

			/// <summary>Initializes a new instance of the <see cref="NCryptBuffer"/> struct.</summary>
			/// <param name="bufferType">Type of the buffer.</param>
			/// <param name="buffer">The buffer.</param>
			public NCryptBuffer(KeyDerivationBufferType bufferType, string buffer)
			{
				BufferType = bufferType;
				pvBuffer = System.Text.Encoding.Unicode.GetBytes(buffer);
			}
		}

		/// <summary>NCrypt known storage providers.</summary>
		public static class KnownStorageProvider
		{
			/// <summary>The Microsoft Software Key Storage Provider</summary>
			public const string MS_KEY_STORAGE_PROVIDER = "Microsoft Software Key Storage Provider";

			/// <summary>The Microsoft Passport Key Storage Provider</summary>
			public const string MS_NGC_KEY_STORAGE_PROVIDER = "Microsoft Passport Key Storage Provider";

			/// <summary>The Microsoft Platform Crypto Provider</summary>
			public const string MS_PLATFORM_KEY_STORAGE_PROVIDER = "Microsoft Platform Crypto Provider";

			/// <summary>The Microsoft Smart Card Key Storage Provider</summary>
			public const string MS_SMART_CARD_KEY_STORAGE_PROVIDER = "Microsoft Smart Card Key Storage Provider";
		}

		/// <summary>The following values are used with the NCryptGetProperty and NCryptSetProperty functions to identify a property.</summary>
		public static class PropertyName
		{
			/// <summary>Algorithm Group</summary>
			public const string NCRYPT_ALGORITHM_GROUP_PROPERTY = "Algorithm Group";
			/// <summary>Algorithm Name</summary>
			public const string NCRYPT_ALGORITHM_PROPERTY = "Algorithm Name";
			/// <summary>SmartCardAssociatedECDHKey</summary>
			public const string NCRYPT_ASSOCIATED_ECDH_KEY = "SmartCardAssociatedECDHKey";
			/// <summary>AuthTagLength</summary>
			public const string NCRYPT_AUTH_TAG_LENGTH = "AuthTagLength";
			/// <summary>Block Length</summary>
			public const string NCRYPT_BLOCK_LENGTH_PROPERTY = "Block Length";
			/// <summary>SmartCardKeyCertificate</summary>
			public const string NCRYPT_CERTIFICATE_PROPERTY = "SmartCardKeyCertificate";
			/// <summary>Chaining Mode</summary>
			public const string NCRYPT_CHAINING_MODE_PROPERTY = "Chaining Mode";
			/// <summary>SmartCardDismissUITimeoutSeconds</summary>
			public const string NCRYPT_DISMISS_UI_TIMEOUT_SEC_PROPERTY = "SmartCardDismissUITimeoutSeconds";
			/// <summaryBCrypt.PropertyName.BCRYPT_ECC_CURVE_NAME_LIS</summary>
			public const string NCRYPT_ECC_CURVE_NAME_LIST_PROPERTY = BCrypt.PropertyName.BCRYPT_ECC_CURVE_NAME_LIST;
			/// <summaryBCrypt.PropertyName.BCRYPT_ECC_CURVE_NAM</summary>
			public const string NCRYPT_ECC_CURVE_NAME_PROPERTY = BCrypt.PropertyName.BCRYPT_ECC_CURVE_NAME;
			/// <summaryBCrypt.PropertyName.BCRYPT_ECC_PARAMETER</summary>
			public const string NCRYPT_ECC_PARAMETERS_PROPERTY = BCrypt.PropertyName.BCRYPT_ECC_PARAMETERS;
			/// <summary>Export Policy</summary>
			public const string NCRYPT_EXPORT_POLICY_PROPERTY = "Export Policy";
			/// <summary>Impl Type</summary>
			public const string NCRYPT_IMPL_TYPE_PROPERTY = "Impl Type";
			/// <summary>KDFKeySecret</summary>
			public const string NCRYPT_KDF_SECRET_VALUE = "KDFKeySecret";
			/// <summary>Key Type</summary>
			public const string NCRYPT_KEY_TYPE_PROPERTY = "Key Type";
			/// <summary>Key Usage</summary>
			public const string NCRYPT_KEY_USAGE_PROPERTY = "Key Usage";
			/// <summary>Modified</summary>
			public const string NCRYPT_LAST_MODIFIED_PROPERTY = "Modified";
			/// <summary>Length</summary>
			public const string NCRYPT_LENGTH_PROPERTY = "Length";
			/// <summary>Lengths</summary>
			public const string NCRYPT_LENGTHS_PROPERTY = "Lengths";
			/// <summary>Max Name Length</summary>
			public const string NCRYPT_MAX_NAME_LENGTH_PROPERTY = "Max Name Length";
			/// <summary>Name</summary>
			public const string NCRYPT_NAME_PROPERTY = "Name";
			/// <summary>PCP_ALTERNATE_KEY_STORAGE_LOCATION</summary>
			public const string NCRYPT_PCP_ALTERNATE_KEY_STORAGE_LOCATION_PROPERTY = "PCP_ALTERNATE_KEY_STORAGE_LOCATION";
			/// <summary>PCP_CHANGEPASSWORD</summary>
			public const string NCRYPT_PCP_CHANGEPASSWORD_PROPERTY = "PCP_CHANGEPASSWORD";
			/// <summary>PCP_ECC_EKCERT</summary>
			public const string NCRYPT_PCP_ECC_EKCERT_PROPERTY = "PCP_ECC_EKCERT";
			/// <summary>PCP_ECC_EKNVCERT</summary>
			public const string NCRYPT_PCP_ECC_EKNVCERT_PROPERTY = "PCP_ECC_EKNVCERT";
			/// <summary>PCP_ECC_EKPUB</summary>
			public const string NCRYPT_PCP_ECC_EKPUB_PROPERTY = "PCP_ECC_EKPUB";
			/// <summary>PCP_EKCERT</summary>
			public const string NCRYPT_PCP_EKCERT_PROPERTY = "PCP_EKCERT";
			/// <summary>PCP_EKNVCERT</summary>
			public const string NCRYPT_PCP_EKNVCERT_PROPERTY = "PCP_EKNVCERT";
			/// <summary>PCP_EKPUB</summary>
			public const string NCRYPT_PCP_EKPUB_PROPERTY = "PCP_EKPUB";
			/// <summary>PCP_EXPORT_ALLOWED</summary>
			public const string NCRYPT_PCP_EXPORT_ALLOWED_PROPERTY = "PCP_EXPORT_ALLOWED";
			/// <summary>PCP_HMAC_AUTH_NONCE</summary>
			public const string NCRYPT_PCP_HMAC_AUTH_NONCE = "PCP_HMAC_AUTH_NONCE";
			/// <summary>PCP_HMAC_AUTH_POLICYINFO</summary>
			public const string NCRYPT_PCP_HMAC_AUTH_POLICYINFO = "PCP_HMAC_AUTH_POLICYINFO";
			/// <summary>PCP_HMAC_AUTH_POLICYREF</summary>
			public const string NCRYPT_PCP_HMAC_AUTH_POLICYREF = "PCP_HMAC_AUTH_POLICYREF";
			/// <summary>PCP_HMAC_AUTH_SIGNATURE</summary>
			public const string NCRYPT_PCP_HMAC_AUTH_SIGNATURE = "PCP_HMAC_AUTH_SIGNATURE";
			/// <summary>PCP_HMAC_AUTH_TICKET</summary>
			public const string NCRYPT_PCP_HMAC_AUTH_TICKET = "PCP_HMAC_AUTH_TICKET";
			/// <summary>PCP_KEY_CREATIONHASH</summary>
			public const string NCRYPT_PCP_KEY_CREATIONHASH_PROPERTY = "PCP_KEY_CREATIONHASH";
			/// <summary>PCP_KEY_CREATIONTICKET</summary>
			public const string NCRYPT_PCP_KEY_CREATIONTICKET_PROPERTY = "PCP_KEY_CREATIONTICKET";
			/// <summary>PCP_KEY_USAGE_POLICY</summary>
			public const string NCRYPT_PCP_KEY_USAGE_POLICY_PROPERTY = "PCP_KEY_USAGE_POLICY";
			/// <summary>PCP_TPM12_KEYATTESTATION</summary>
			public const string NCRYPT_PCP_KEYATTESTATION_PROPERTY = "PCP_TPM12_KEYATTESTATION";
			/// <summary>PCP_MIGRATIONPASSWORD</summary>
			public const string NCRYPT_PCP_MIGRATIONPASSWORD_PROPERTY = "PCP_MIGRATIONPASSWORD";
			/// <summary>PCP_NO_DA_PROTECTION</summary>
			public const string NCRYPT_PCP_NO_DA_PROTECTION_PROPERTY = "PCP_NO_DA_PROTECTION";
			/// <summary>PCP_PASSWORD_REQUIRED</summary>
			public const string NCRYPT_PCP_PASSWORD_REQUIRED_PROPERTY = "PCP_PASSWORD_REQUIRED";
			/// <summary>PCP_PCRTABLE</summary>
			public const string NCRYPT_PCP_PCRTABLE_PROPERTY = "PCP_PCRTABLE";
			/// <summary>PCP_PLATFORM_BINDING_PCRDIGEST</summary>
			public const string NCRYPT_PCP_PLATFORM_BINDING_PCRDIGEST_PROPERTY = "PCP_PLATFORM_BINDING_PCRDIGEST";
			/// <summary>PCP_PLATFORM_BINDING_PCRDIGESTLIST</summary>
			public const string NCRYPT_PCP_PLATFORM_BINDING_PCRDIGESTLIST_PROPERTY = "PCP_PLATFORM_BINDING_PCRDIGESTLIST";
			/// <summary>PCP_PLATFORM_BINDING_PCRMASK</summary>
			public const string NCRYPT_PCP_PLATFORM_BINDING_PCRMASK_PROPERTY = "PCP_PLATFORM_BINDING_PCRMASK";
			/// <summary>PCP_PLATFORM_TYPE</summary>
			public const string NCRYPT_PCP_PLATFORM_TYPE_PROPERTY = "PCP_PLATFORM_TYPE";
			/// <summary>PCP_PLATFORMHANDLE</summary>
			public const string NCRYPT_PCP_PLATFORMHANDLE_PROPERTY = "PCP_PLATFORMHANDLE";
			/// <summary>PCP_PROVIDER_VERSION</summary>
			public const string NCRYPT_PCP_PROVIDER_VERSION_PROPERTY = "PCP_PROVIDER_VERSION";
			/// <summary>PCP_PROVIDERMHANDLE</summary>
			public const string NCRYPT_PCP_PROVIDERHANDLE_PROPERTY = "PCP_PROVIDERMHANDLE";
			/// <summary>PCP_RAW_POLICYDIGEST</summary>
			public const string NCRYPT_PCP_RAW_POLICYDIGEST_PROPERTY = "PCP_RAW_POLICYDIGEST";
			/// <summary>PCP_RSA_EKCERT</summary>
			public const string NCRYPT_PCP_RSA_EKCERT_PROPERTY = "PCP_RSA_EKCERT";
			/// <summary>PCP_RSA_EKNVCERT</summary>
			public const string NCRYPT_PCP_RSA_EKNVCERT_PROPERTY = "PCP_RSA_EKNVCERT";
			/// <summary>PCP_RSA_EKPUB</summary>
			public const string NCRYPT_PCP_RSA_EKPUB_PROPERTY = "PCP_RSA_EKPUB";
			/// <summary>PCP_RSA_SCHEME_HASH_ALG</summary>
			public const string NCRYPT_PCP_RSA_SCHEME_HASH_ALG_PROPERTY = "PCP_RSA_SCHEME_HASH_ALG";
			/// <summary>PCP_RSA_SCHEME</summary>
			public const string NCRYPT_PCP_RSA_SCHEME_PROPERTY = "PCP_RSA_SCHEME";
			/// <summary>PCP_SESSIONID</summary>
			public const string NCRYPT_PCP_SESSIONID_PROPERTY = "PCP_SESSIONID";
			/// <summary>PCP_SRKPUB</summary>
			public const string NCRYPT_PCP_SRKPUB_PROPERTY = "PCP_SRKPUB";
			/// <summary>PCP_STORAGEPARENT</summary>
			public const string NCRYPT_PCP_STORAGEPARENT_PROPERTY = "PCP_STORAGEPARENT";
			/// <summary>PCP_TPM_FW_VERSION</summary>
			public const string NCRYPT_PCP_TPM_FW_VERSION_PROPERTY = "PCP_TPM_FW_VERSION";
			/// <summary>PCP_TPM_IFX_RSA_KEYGEN_PROHIBITED</summary>
			public const string NCRYPT_PCP_TPM_IFX_RSA_KEYGEN_PROHIBITED_PROPERTY = "PCP_TPM_IFX_RSA_KEYGEN_PROHIBITED";
			/// <summary>PCP_TPM_IFX_RSA_KEYGEN_VULNERABILITY</summary>
			public const string NCRYPT_PCP_TPM_IFX_RSA_KEYGEN_VULNERABILITY_PROPERTY = "PCP_TPM_IFX_RSA_KEYGEN_VULNERABILITY";
			/// <summary>PCP_TPM_MANUFACTURER_ID</summary>
			public const string NCRYPT_PCP_TPM_MANUFACTURER_ID_PROPERTY = "PCP_TPM_MANUFACTURER_ID";
			/// <summary>PCP_TPM_VERSION</summary>
			public const string NCRYPT_PCP_TPM_VERSION_PROPERTY = "PCP_TPM_VERSION";
			/// <summary>PCP_TPM12_IDACTIVATION</summary>
			public const string NCRYPT_PCP_TPM12_IDACTIVATION_PROPERTY = "PCP_TPM12_IDACTIVATION";
			/// <summary>PCP_TPM12_IDBINDING_DYNAMIC</summary>
			public const string NCRYPT_PCP_TPM12_IDBINDING_DYNAMIC_PROPERTY = "PCP_TPM12_IDBINDING_DYNAMIC";
			/// <summary>PCP_TPM12_IDBINDING</summary>
			public const string NCRYPT_PCP_TPM12_IDBINDING_PROPERTY = "PCP_TPM12_IDBINDING";
			/// <summary>PCP_TPM2BNAME</summary>
			public const string NCRYPT_PCP_TPM2BNAME_PROPERTY = "PCP_TPM2BNAME";
			/// <summary>PCP_USAGEAUTH</summary>
			public const string NCRYPT_PCP_USAGEAUTH_PROPERTY = "PCP_USAGEAUTH";
			/// <summary>SmartCardPinPrompt</summary>
			public const string NCRYPT_PIN_PROMPT_PROPERTY = "SmartCardPinPrompt";
			/// <summary>SmartCardPin</summary>
			public const string NCRYPT_PIN_PROPERTY = "SmartCardPin";
			/// <summary>Provider Handle</summary>
			public const string NCRYPT_PROVIDER_HANDLE_PROPERTY = "Provider Handle";
			/// <summaryBCrypt.PropertyName.BCRYPT_PUBLIC_KEY_LENGT</summary>
			public const string NCRYPT_PUBLIC_LENGTH_PROPERTY = BCrypt.PropertyName.BCRYPT_PUBLIC_KEY_LENGTH;
			/// <summary>SmartCardReaderIcon</summary>
			public const string NCRYPT_READER_ICON_PROPERTY = "SmartCardReaderIcon";
			/// <summary>SmartCardReader</summary>
			public const string NCRYPT_READER_PROPERTY = "SmartCardReader";
			/// <summary>SmartcardRootCertStore</summary>
			public const string NCRYPT_ROOT_CERTSTORE_PROPERTY = "SmartcardRootCertStore";
			/// <summary>SmartCardPinId</summary>
			public const string NCRYPT_SCARD_PIN_ID = "SmartCardPinId";
			/// <summary>SmartCardPinInfo</summary>
			public const string NCRYPT_SCARD_PIN_INFO = "SmartCardPinInfo";
			/// <summary>SmartCardSecurePin</summary>
			public const string NCRYPT_SECURE_PIN_PROPERTY = "SmartCardSecurePin";
			/// <summary>Security Descr</summary>
			public const string NCRYPT_SECURITY_DESCR_PROPERTY = "Security Descr";
			/// <summary>Security Descr Support</summary>
			public const string NCRYPT_SECURITY_DESCR_SUPPORT_PROPERTY = "Security Descr Support";
			/// <summaryBCrypt.PropertyName.BCRYPT_SIGNATURE_LENGT</summary>
			public const string NCRYPT_SIGNATURE_LENGTH_PROPERTY = BCrypt.PropertyName.BCRYPT_SIGNATURE_LENGTH;
			/// <summary>SmartCardGuid</summary>
			public const string NCRYPT_SMARTCARD_GUID_PROPERTY = "SmartCardGuid";
			/// <summary>UI Policy</summary>
			public const string NCRYPT_UI_POLICY_PROPERTY = "UI Policy";
			/// <summary>Unique Name</summary>
			public const string NCRYPT_UNIQUE_NAME_PROPERTY = "Unique Name";
			/// <summary>Use Context</summary>
			public const string NCRYPT_USE_CONTEXT_PROPERTY = "Use Context";
			/// <summary>Enabled Use Count</summary>
			public const string NCRYPT_USE_COUNT_ENABLED_PROPERTY = "Enabled Use Count";
			/// <summary>Use Count</summary>
			public const string NCRYPT_USE_COUNT_PROPERTY = "Use Count";
			/// <summary>Per Boot Key</summary>
			public const string NCRYPT_USE_PER_BOOT_KEY_PROPERTY = "Per Boot Key";
			/// <summary>Virtual Iso</summary>
			public const string NCRYPT_USE_VIRTUAL_ISOLATION_PROPERTY = "Virtual Iso";
			/// <summary>SmartCardUserCertStore</summary>
			public const string NCRYPT_USER_CERTSTORE_PROPERTY = "SmartCardUserCertStore";
			/// <summary>Version</summary>
			public const string NCRYPT_VERSION_PROPERTY = "Version";
			/// <summary>HWND Handle</summary>
			public const string NCRYPT_WINDOW_HANDLE_PROPERTY = "HWND Handle";
		}

		/// <summary>The <c>BCryptBufferDesc</c> structure is used to contain a set of generic CNG buffers.</summary>
		// typedef struct _BCryptBufferDesc { ULONG ulVersion; ULONG cBuffers; PBCryptBuffer pBuffers;} BCryptBufferDesc, *PBCryptBufferDesc; https://msdn.microsoft.com/en-us/library/windows/desktop/aa375370(v=vs.85).aspx
		[PInvokeData("Bcrypt.h", MSDNShortId = "aa375370")]
		[StructLayout(LayoutKind.Sequential, CharSet = CharSet.Auto)]
		public class NCryptBufferDesc : IDisposable
		{
			private const uint BCRYPTBUFFER_VERSION = 0;

			/// <summary>
			/// <para>The version of the structure. This must be the following value.</para>
			/// <para>
			/// <list type="table">
			/// <listheader>
			/// <term>Value</term>
			/// <term>Meaning</term>
			/// </listheader>
			/// <item>
			/// <term>BCRYPTBUFFER_VERSION</term>
			/// <term>The default version number.</term>
			/// </item>
			/// </list>
			/// </para>
			/// </summary>
			public uint ulVersion = BCRYPTBUFFER_VERSION;

			/// <summary>The number of elements in the <c>pBuffers</c> array.</summary>
			public uint cBuffers;

			/// <summary>
			/// The address of an array of <c>BCryptBuffer</c> structures that contain the buffers. The <c>cBuffers</c> member contains the
			/// number of elements in this array.
			/// </summary>
			private IntPtr _pBuffers;

			/// <summary>
			/// The address of an array of <c>BCryptBuffer</c> structures that contain the buffers. The <c>cBuffers</c> member contains the
			/// number of elements in this array.
			/// </summary>
			public NCryptBuffer[] pBuffers
			{
				get => _pBuffers.ToIEnum<_NCryptBuffer>((int)cBuffers).Cast<NCryptBuffer>().ToArray();
				set
				{
					((IDisposable)this).Dispose();
					if (value == null) return;
					_pBuffers = InteropExtensions.MarshalToPtr<_NCryptBuffer>(value.Select(b => new _NCryptBuffer(b)), Marshal.AllocCoTaskMem, out var _);
				}
			}

			/// <inheritdoc/>
			void IDisposable.Dispose()
			{
				if (_pBuffers == IntPtr.Zero) return;
				foreach (var b in _pBuffers.ToIEnum<_NCryptBuffer>((int)cBuffers))
					Marshal.FreeCoTaskMem(b.pvBuffer);
				Marshal.FreeCoTaskMem(_pBuffers);
				_pBuffers = IntPtr.Zero;
			}

			[StructLayout(LayoutKind.Sequential, CharSet = CharSet.Auto)]
			private struct _NCryptBuffer
			{
				/// <summary>
				/// <para>The size, in bytes, of the buffer.</para>
				/// </summary>
				public uint cbBuffer;

				/// <summary>A value that identifies the type of data that is contained by the buffer.</summary>
				public KeyDerivationBufferType BufferType;

				/// <summary>
				/// <para>The address of the buffer. The size of this buffer is contained in the <c>cbBuffer</c> member.</para>
				/// <para>The format and contents of this buffer are identified by the <c>BufferType</c> member.</para>
				/// </summary>
				public IntPtr pvBuffer;

				public _NCryptBuffer(in NCryptBuffer b)
				{
					cbBuffer = (uint)(b.pvBuffer?.Length ?? 0);
					BufferType = b.BufferType;
					pvBuffer = b.pvBuffer?.MarshalToPtr<byte>(Marshal.AllocCoTaskMem, out var _) ?? IntPtr.Zero;
				}

				public static implicit operator NCryptBuffer(_NCryptBuffer b) => new NCryptBuffer { BufferType = b.BufferType, pvBuffer = b.pvBuffer.ToArray<byte>((int)b.cbBuffer) };
			}
		}

		/// <summary>Provides a <see cref="SafeHandle"/> for <see cref="NCRYPT_KEY_HANDLE"/> that is disposed using <see cref="NCryptFreeObject"/>.</summary>
		public class SafeNCRYPT_KEY_HANDLE : SafeHANDLE
		{
			/// <summary>Initializes a new instance of the <see cref="SafeNCRYPT_KEY_HANDLE"/> class and assigns an existing handle.</summary>
			/// <param name="preexistingHandle">An <see cref="IntPtr"/> object that represents the pre-existing handle to use.</param>
			/// <param name="ownsHandle">
			/// <see langword="true"/> to reliably release the handle during the finalization phase; otherwise, <see langword="false"/> (not recommended).
			/// </param>
			public SafeNCRYPT_KEY_HANDLE(IntPtr preexistingHandle, bool ownsHandle = true) : base(preexistingHandle, ownsHandle) { }

			/// <summary>Initializes a new instance of the <see cref="SafeNCRYPT_KEY_HANDLE"/> class.</summary>
			private SafeNCRYPT_KEY_HANDLE() : base() { }

			/// <summary>Performs an implicit conversion from <see cref="SafeNCRYPT_KEY_HANDLE"/> to <see cref="NCRYPT_HANDLE"/>.</summary>
			/// <param name="h">The safe handle instance.</param>
			/// <returns>The result of the conversion.</returns>
			public static implicit operator NCRYPT_HANDLE(SafeNCRYPT_KEY_HANDLE h) => h.handle;

			/// <summary>Performs an implicit conversion from <see cref="SafeNCRYPT_KEY_HANDLE"/> to <see cref="NCRYPT_KEY_HANDLE"/>.</summary>
			/// <param name="h">The safe handle instance.</param>
			/// <returns>The result of the conversion.</returns>
			public static implicit operator NCRYPT_KEY_HANDLE(SafeNCRYPT_KEY_HANDLE h) => h.handle;

			/// <inheritdoc/>
			protected override bool InternalReleaseHandle() => NCryptFreeObject(handle).Succeeded;
		}

		/// <summary>Provides a <see cref="SafeHandle"/> for <see cref="NCRYPT_PROV_HANDLE"/> that is disposed using <see cref="NCryptFreeObject"/>.</summary>
		public class SafeNCRYPT_PROV_HANDLE : SafeHANDLE
		{
			/// <summary>Initializes a new instance of the <see cref="SafeNCRYPT_PROV_HANDLE"/> class and assigns an existing handle.</summary>
			/// <param name="preexistingHandle">An <see cref="IntPtr"/> object that represents the pre-existing handle to use.</param>
			/// <param name="ownsHandle">
			/// <see langword="true"/> to reliably release the handle during the finalization phase; otherwise, <see langword="false"/> (not recommended).
			/// </param>
			public SafeNCRYPT_PROV_HANDLE(IntPtr preexistingHandle, bool ownsHandle = true) : base(preexistingHandle, ownsHandle) { }

			/// <summary>Initializes a new instance of the <see cref="SafeNCRYPT_PROV_HANDLE"/> class.</summary>
			private SafeNCRYPT_PROV_HANDLE() : base() { }

			/// <summary>Performs an implicit conversion from <see cref="SafeNCRYPT_PROV_HANDLE"/> to <see cref="NCRYPT_HANDLE"/>.</summary>
			/// <param name="h">The safe handle instance.</param>
			/// <returns>The result of the conversion.</returns>
			public static implicit operator NCRYPT_HANDLE(SafeNCRYPT_PROV_HANDLE h) => h.handle;

			/// <summary>Performs an implicit conversion from <see cref="SafeNCRYPT_PROV_HANDLE"/> to <see cref="NCRYPT_PROV_HANDLE"/>.</summary>
			/// <param name="h">The safe handle instance.</param>
			/// <returns>The result of the conversion.</returns>
			public static implicit operator NCRYPT_PROV_HANDLE(SafeNCRYPT_PROV_HANDLE h) => h.handle;

			/// <inheritdoc/>
			protected override bool InternalReleaseHandle() => NCryptFreeObject(handle).Succeeded;
		}

		/// <summary>Provides a <see cref="SafeHandle"/> for <see cref="NCRYPT_SECRET_HANDLE"/> that is disposed using <see cref="NCryptFreeObject"/>.</summary>
		public class SafeNCRYPT_SECRET_HANDLE : SafeHANDLE
		{
			/// <summary>Initializes a new instance of the <see cref="SafeNCRYPT_SECRET_HANDLE"/> class and assigns an existing handle.</summary>
			/// <param name="preexistingHandle">An <see cref="IntPtr"/> object that represents the pre-existing handle to use.</param>
			/// <param name="ownsHandle">
			/// <see langword="true"/> to reliably release the handle during the finalization phase; otherwise, <see langword="false"/> (not recommended).
			/// </param>
			public SafeNCRYPT_SECRET_HANDLE(IntPtr preexistingHandle, bool ownsHandle = true) : base(preexistingHandle, ownsHandle) { }

			/// <summary>Initializes a new instance of the <see cref="SafeNCRYPT_SECRET_HANDLE"/> class.</summary>
			private SafeNCRYPT_SECRET_HANDLE() : base() { }

			/// <summary>Performs an implicit conversion from <see cref="SafeNCRYPT_SECRET_HANDLE"/> to <see cref="NCRYPT_SECRET_HANDLE"/>.</summary>
			/// <param name="h">The safe handle instance.</param>
			/// <returns>The result of the conversion.</returns>
			public static implicit operator NCRYPT_SECRET_HANDLE(SafeNCRYPT_SECRET_HANDLE h) => h.handle;

			/// <inheritdoc/>
			protected override bool InternalReleaseHandle() => NCryptFreeObject(handle).Succeeded;
		}

		/// <summary>Provides a <see cref="SafeHandle"/> for buffers allocated by the NCrypt library that is disposed using <see cref="NCryptFreeBuffer"/>.</summary>
		public class SafeNCryptBuffer : SafeHANDLE
		{
			/// <summary>Initializes a new instance of the <see cref="SafeNCryptBuffer"/> class and assigns an existing handle.</summary>
			/// <param name="preexistingHandle">An <see cref="IntPtr"/> object that represents the pre-existing handle to use.</param>
			/// <param name="ownsHandle">
			/// <see langword="true"/> to reliably release the handle during the finalization phase; otherwise, <see langword="false"/> (not recommended).
			/// </param>
			public SafeNCryptBuffer(IntPtr preexistingHandle, bool ownsHandle = true) : base(preexistingHandle, ownsHandle) { }

			/// <summary>Initializes a new instance of the <see cref="SafeNCryptBuffer"/> class.</summary>
			private SafeNCryptBuffer() : base() { }

			/// <summary>Converts an <see cref="IntPtr"/> that points to a C-style array into a CLI array.</summary>
			/// <typeparam name="T">Type of native structure used by the C-style array.</typeparam>
			/// <param name="count">The number of items in the native array.</param>
			/// <returns>An array of type <typeparamref name="T"/> containing the elements of the native array.</returns>
			public T[] ToArray<T>(uint count) => handle.ToArray<T>((int)count);

			/// <summary>Marshals data to a newly allocated managed object of the type specified by a generic type parameter.</summary>
			/// <typeparam name="T">The type of the object to which the data is to be copied. This must be a structure.</typeparam>
			/// <returns>A managed object that contains the data pointed to by this object.</returns>
			public T ToStructure<T>() => handle.ToStructure<T>();

			/// <inheritdoc/>
			protected override bool InternalReleaseHandle() => NCryptFreeBuffer(handle).Succeeded;
		}
	}
}