using System;
using System.Runtime.InteropServices;

namespace Vanara.PInvoke;

/// <summary>Methods and data types found in Crypt32.dll.</summary>
public static partial class Crypt32
{
	/// <summary>Flags for <see cref="PFXExportCertStore"/> and <see cref="PFXExportCertStoreEx"/></summary>
	[PInvokeData("wincrypt.h", MSDNShortId = "003602c6-d6c9-4695-9c60-ffaf0aa02266")]
	[Flags]
	public enum PFXExportFlags : uint
	{
		/// <summary>
		/// If a certificate is encountered that has no associated private key, the function returns FALSE with the last error set to
		/// either CRYPT_E_NOT_FOUND or NTE_NO_KEY.
		/// </summary>
		REPORT_NO_PRIVATE_KEY = 0x0001,

		/// <summary>
		/// If a certificate is encountered that has a non-exportable private key, the function returns FALSE and the last error set to
		/// NTE_BAD_KEY, NTE_BAD_KEY_STATE, or NTE_PERM.
		/// </summary>
		REPORT_NOT_ABLE_TO_EXPORT_PRIVATE_KEY = 0x0002,

		/// <summary>Private keys are exported as well as the certificates.</summary>
		EXPORT_PRIVATE_KEYS = 0x0004,

		/// <summary>
		/// Export all extended properties on the certificate.
		/// <para>Windows Server 2003 and Windows XP: This value is not supported.</para>
		/// </summary>
		PKCS12_INCLUDE_EXTENDED_PROPERTIES = 0x0010,

		/// <summary>
		/// The PFX BLOB contains an embedded password that will be protected to the Active Directory (AD) protection descriptor pointed
		/// to by the pvPara parameter. If the szPassword parameter is not NULL or empty, the specified password is protected. If,
		/// however, the szPassword parameter is NULL or an empty string, a random forty (40) character password is created and protected.
		/// <para>
		/// PFXImportCertStore uses the specified protection descriptor to decrypt the embedded password, whether specified by the user
		/// or randomly generated, and then uses the password to decrypt the PFX BLOB.
		/// </para>
		/// <para>Windows 8 and Windows Server 2012: Support for this flag begins.</para>
		/// </summary>
		PKCS12_PROTECT_TO_DOMAIN_SIDS = 0x0020,

		/// <summary/>
		PKCS12_EXPORT_SILENT = 0x0040,

		/// <summary/>
		PKCS12_EXPORT_PBES2_PARAMS = 0x0080,

		/// <summary/>
		PKCS12_DISABLE_ENCRYPT_CERTIFICATES = 0x0100,

		/// <summary/>
		PKCS12_ENCRYPT_CERTIFICATES = 0x0200,

		/// <summary/>
		PKCS12_EXPORT_ECC_CURVE_PARAMETERS = 0x1000,

		/// <summary/>
		PKCS12_EXPORT_ECC_CURVE_OID = 0x2000,

		/// <summary/>
		PKCS12_EXPORT_RESERVED_MASK = 0xffff0000,
	}

	/// <summary>Flags for <see cref="PFXImportCertStore"/>.</summary>
	[PInvokeData("wincrypt.h", MSDNShortId = "2c83774a-f2df-4d28-9abd-e39aa507ba88")]
	[Flags]
	public enum PFXImportFlags : uint
	{
		/// <summary>
		/// Imported keys are marked as exportable. If this flag is not used, calls to the CryptExportKey function with the key handle fail.
		/// </summary>
		CRYPT_EXPORTABLE = 0x00000001,

		/// <summary>
		/// The user is to be notified through a dialog box or other method when certain attempts to use this key are made. The precise
		/// behavior is specified by the cryptographic service provider (CSP) being used.
		/// <para>
		/// Prior to Internet Explorer 4.0, Microsoft cryptographic service providers ignored this flag. Starting with Internet Explorer
		/// 4.0, Microsoft providers support this flag.
		/// </para>
		/// <para>
		/// If the provider context was opened with the CRYPT_SILENT flag set, using this flag causes a failure and the last error is
		/// set to NTE_SILENT_CONTEXT.
		/// </para>
		/// </summary>
		CRYPT_USER_PROTECTED = 0x00000002,

		/// <summary>The private keys are stored under the local computer and not under the current user.</summary>
		CRYPT_MACHINE_KEYSET = 0x00000020,

		/// <summary>
		/// The private keys are stored under the current user and not under the local computer even if the PFX BLOB specifies that they
		/// should go into the local computer.
		/// </summary>
		CRYPT_USER_KEYSET = 0x00001000,

		/// <summary>
		/// Indicates that the CNG key storage provider (KSP) is preferred. If the CSP is specified in the PFX file, then the CSP is
		/// used, otherwise the KSP is preferred. If the CNG KSP is unavailable, the PFXImportCertStore function will fail.
		/// <para>Windows Server 2003 and Windows XP: This value is not supported.</para>
		/// </summary>
		PKCS12_PREFER_CNG_KSP = 0x00000100,

		/// <summary>
		/// Indicates that the CNG KSP is always used. When specified, PFXImportCertStore attempts to use the CNG KSP irrespective of
		/// provider information in the PFX file. If the CNG KSP is unavailable, the import will not fail.
		/// <para>Windows Server 2003 and Windows XP: This value is not supported.</para>
		/// </summary>
		PKCS12_ALWAYS_CNG_KSP = 0x00000200,

		/// <summary>
		/// Allow overwrite of the existing key. Specify this flag when you encounter a scenario in which you must import a PFX file
		/// that contains a key name that already exists. For example, when you import a PFX file, it is possible that a container of
		/// the same name is already present because there is no unique namespace for key containers. If you have created a "TestKey" on
		/// your computer, and then you import a PFX file that also has "TestKey" as the key container, the PKCS12_ALLOW_OVERWRITE_KEY
		/// setting allows the key to be overwritten.
		/// <para>Windows Server 2003 and Windows XP: This value is not supported.</para>
		/// </summary>
		PKCS12_ALLOW_OVERWRITE_KEY = 0x00004000,

		/// <summary>
		/// Do not persist the key. Specify this flag when you do not want to persist the key. For example, if it is not necessary to
		/// store the key after verification, then instead of creating a container and then deleting it, you can specify this flag to
		/// dispose of the key immediately.
		/// <para>
		/// Note If the PKCS12_NO_PERSIST_KEY flag is not set, keys are persisted on disk. If you do not want to persist the keys beyond
		/// their usage, you must delete them by calling the CryptAcquireContext function with the CRYPT_DELETEKEYSET flag set in the
		/// dwFlags parameter.
		/// </para>
		/// <para>Windows Server 2003 and Windows XP: This value is not supported.</para>
		/// </summary>
		PKCS12_NO_PERSIST_KEY = 0x00008000,

		/// <summary>
		/// Import all extended properties on the certificate that were saved on the certificate when it was exported.
		/// <para>Windows Server 2003 and Windows XP: This value is not supported.</para>
		/// </summary>
		PKCS12_INCLUDE_EXTENDED_PROPERTIES = 0x0010,

		/// <summary>Unpack but do not persist the results.</summary>
		PKCS12_UNPACK_RESULTS_ONLY = 0x10000000,

		/// <summary/>
		CRYPT_USER_PROTECTED_STRONG = 0x00100000,

		/// <summary/>
		PKCS12_IMPORT_SILENT = 0x00000040,

		/// <summary/>
		PKCS12_ONLY_CERTIFICATES = 0x00000400,

		/// <summary/>
		PKCS12_ONLY_NOT_ENCRYPTED_CERTIFICATES = 0x00000800,

		/// <summary/>
		PKCS12_VIRTUAL_ISOLATION_KEY = 0x00010000,

		/// <summary/>
		PKCS12_IMPORT_RESERVED_MASK = 0xffff0000,

		/// <summary/>
		PKCS12_OBJECT_LOCATOR_ALL_IMPORT_FLAGS = (PKCS12_ALWAYS_CNG_KSP | PKCS12_NO_PERSIST_KEY | PKCS12_IMPORT_SILENT | PKCS12_INCLUDE_EXTENDED_PROPERTIES),
	}

	/// <summary>
	/// The <c>PFXExportCertStore</c> function exports the certificates and, if available, the associated private keys from the
	/// referenced certificate store. This is an old function kept for compatibility with Internet Explorer 4.0 clients. New
	/// applications should use the PfxExportCertStoreEx function that provides enhanced private key security.
	/// </summary>
	/// <param name="hStore">Handle of the certificate store containing the certificates to be exported.</param>
	/// <param name="pPFX">
	/// A pointer to a CRYPT_DATA_BLOB structure to contain the PFX packet with the exported certificates and keys. If pPFX-&gt;pbData
	/// is <c>NULL</c>, the function calculates the number of bytes needed for the encoded BLOB and returns this in pPFX-&gt;cbData.
	/// When the function is called with pPFX-&gt;pbData pointing to an allocated buffer of the needed size, the function copies the
	/// encoded bytes into the buffer and updates pPFX-&gt;cbData with the encode byte length.
	/// </param>
	/// <param name="szPassword">
	/// String password used to encrypt and verify the PFX packet. When you have finished using the password, clear the password from
	/// memory by calling the SecureZeroMemory function. For more information about protecting passwords, see Handling Passwords.
	/// </param>
	/// <param name="dwFlags">
	/// <para>Flag values can be set to any combination of the following.</para>
	/// <list type="table">
	/// <listheader>
	/// <term>Value</term>
	/// <term>Meaning</term>
	/// </listheader>
	/// <item>
	/// <term>EXPORT_PRIVATE_KEYS</term>
	/// <term>Private keys are exported as well as the certificates.</term>
	/// </item>
	/// <item>
	/// <term>REPORT_NO_PRIVATE_KEY</term>
	/// <term>
	/// If a certificate is encountered that has no associated private key, the function returns FALSE with the last error set to either
	/// CRYPT_E_NOT_FOUND or NTE_NO_KEY.
	/// </term>
	/// </item>
	/// <item>
	/// <term>REPORT_NOT_ABLE_TO_EXPORT_PRIVATE_KEY</term>
	/// <term>
	/// If a certificate is encountered that has a non-exportable private key, the function returns FALSE and the last error set to
	/// NTE_BAD_KEY, NTE_BAD_KEY_STATE, or NTE_PERM.
	/// </term>
	/// </item>
	/// </list>
	/// </param>
	/// <returns>
	/// Returns <c>TRUE</c> (nonzero) if the function succeeds, and <c>FALSE</c> (zero) if the function fails. For extended error
	/// information, call GetLastError.
	/// </returns>
	// https://docs.microsoft.com/en-us/windows/win32/api/wincrypt/nf-wincrypt-pfxexportcertstore BOOL PFXExportCertStore( HCERTSTORE
	// hStore, CRYPT_DATA_BLOB *pPFX, LPCWSTR szPassword, DWORD dwFlags );
	[DllImport(Lib.Crypt32, SetLastError = true, ExactSpelling = true)]
	[PInvokeData("wincrypt.h", MSDNShortId = "003602c6-d6c9-4695-9c60-ffaf0aa02266")]
	[return: MarshalAs(UnmanagedType.Bool)]
	public static extern bool PFXExportCertStore([In] HCERTSTORE hStore, ref CRYPTOAPI_BLOB pPFX, [MarshalAs(UnmanagedType.LPWStr)] string szPassword, PFXExportFlags dwFlags);

	/// <summary>
	/// The <c>PFXExportCertStoreEx</c> function exports the certificates and, if available, their associated private keys from the
	/// referenced certificate store. This function replaces the older PfxExportCertStore function. It should be used for its enhanced
	/// private key security. The PFX BLOB created by this function is protected by a password.
	/// </summary>
	/// <param name="hStore">Handle of the certificate store containing the certificates to be exported.</param>
	/// <param name="pPFX">
	/// A pointer to a CRYPT_DATA_BLOB structure to contain the PFX packet with the exported certificates and keys. If pPFX-&gt;pbData
	/// is <c>NULL</c>, the function calculates the number of bytes needed for the encoded BLOB and returns this in pPFX-&gt;cbData.
	/// When the function is called with pPFX-&gt;pbData pointing to an allocated buffer of the needed size, the function copies the
	/// encoded bytes into the buffer and updates pPFX-&gt;cbData with the encode byte length.
	/// </param>
	/// <param name="szPassword">
	/// String password used to encrypt and verify the PFX packet. When you have finished using the password, clear the password from
	/// memory by calling the SecureZeroMemory function. For more information about protecting passwords, see Handling Passwords.
	/// </param>
	/// <param name="pvPara">
	/// <para>
	/// This parameter must be <c>NULL</c> if the dwFlags parameter does not contain <c>PKCS12_PROTECT_TO_DOMAIN_SIDS</c>. Prior to
	/// Windows 8 and Windows Server 2012, therefore, this parameter must be <c>NULL</c>.
	/// </para>
	/// <para>
	/// Beginning with Windows 8 and Windows Server 2012, if the dwFlags parameter contains <c>PKCS12_PROTECT_TO_DOMAIN_SIDS</c>, you
	/// can set the pvPara parameter to point to an <c>NCRYPT_DESCRIPTOR_HANDLE</c> value to identify which Active Directory principal
	/// the PFX password will be protected to inside of the PFX BLOB. Currently, the password can be protected to an Active Directory
	/// user, computer, or group. For more information about protection descriptors, see NCryptCreateProtectionDescriptor.
	/// </para>
	/// </param>
	/// <param name="dwFlags">
	/// <para>Flag values can be set to any combination of the following.</para>
	/// <list type="table">
	/// <listheader>
	/// <term>Value</term>
	/// <term>Meaning</term>
	/// </listheader>
	/// <item>
	/// <term>EXPORT_PRIVATE_KEYS 0x0004</term>
	/// <term>Private keys are exported as well as the certificates.</term>
	/// </item>
	/// <item>
	/// <term>REPORT_NO_PRIVATE_KEY 0x0001</term>
	/// <term>
	/// If a certificate is encountered that has no associated private key, the function returns FALSE with the last error set to either
	/// CRYPT_E_NOT_FOUND or NTE_NO_KEY.
	/// </term>
	/// </item>
	/// <item>
	/// <term>REPORT_NOT_ABLE_TO_EXPORT_PRIVATE_KEY 0x0002</term>
	/// <term>
	/// If a certificate is encountered that has a non-exportable private key, the function returns FALSE and the last error set to
	/// NTE_BAD_KEY, NTE_BAD_KEY_STATE, or NTE_PERM.
	/// </term>
	/// </item>
	/// <item>
	/// <term>PKCS12_INCLUDE_EXTENDED_PROPERTIES 0x0010</term>
	/// <term>Export all extended properties on the certificate. Windows Server 2003 and Windows XP: This value is not supported.</term>
	/// </item>
	/// <item>
	/// <term>PKCS12_PROTECT_TO_DOMAIN_SIDS 0x0020</term>
	/// <term>
	/// The PFX BLOB contains an embedded password that will be protected to the Active Directory (AD) protection descriptor pointed to
	/// by the pvPara parameter. If the szPassword parameter is not NULL or empty, the specified password is protected. If, however, the
	/// szPassword parameter is NULL or an empty string, a random forty (40) character password is created and protected.
	/// PFXImportCertStore uses the specified protection descriptor to decrypt the embedded password, whether specified by the user or
	/// randomly generated, and then uses the password to decrypt the PFX BLOB. Windows 8 and Windows Server 2012: Support for this flag begins.
	/// </term>
	/// </item>
	/// </list>
	/// </param>
	/// <returns>
	/// Returns <c>TRUE</c> (nonzero) if the function succeeds, and <c>FALSE</c> (zero) if the function fails. For extended error
	/// information, call GetLastError.
	/// </returns>
	/// <remarks>
	/// Beginning with Windows 8 and Windows Server 2012, you can protect the PFX password to an Active Directory user, computer, or
	/// group. If you choose to do so but do not create a password, a temporary password will be randomly selected. The password is
	/// encrypted by using the Active Directory principal and then embedded in the PFX BLOB. For more information, see the pvPara
	/// parameter and the <c>PKCS12_PROTECT_TO_DOMAIN_SIDS</c> flag.
	/// </remarks>
	// https://docs.microsoft.com/en-us/windows/win32/api/wincrypt/nf-wincrypt-pfxexportcertstoreex BOOL PFXExportCertStoreEx(
	// HCERTSTORE hStore, CRYPT_DATA_BLOB *pPFX, LPCWSTR szPassword, void *pvPara, DWORD dwFlags );
	[DllImport(Lib.Crypt32, SetLastError = true, ExactSpelling = true)]
	[PInvokeData("wincrypt.h", MSDNShortId = "e8bd54b1-946f-4c65-8a86-96f0dbec07ff")]
	[return: MarshalAs(UnmanagedType.Bool)]
	public static extern bool PFXExportCertStoreEx([In] HCERTSTORE hStore, ref CRYPTOAPI_BLOB pPFX, [MarshalAs(UnmanagedType.LPWStr)] string szPassword, [In] IntPtr pvPara, PFXExportFlags dwFlags);

	/// <summary>
	/// The <c>PFXImportCertStore</c> function imports a PFX BLOB and returns the handle of a store that contains certificates and any
	/// associated private keys.
	/// </summary>
	/// <param name="pPFX">
	/// A pointer to a CRYPT_DATA_BLOB structure that contains a PFX packet with the exported and encrypted certificates and keys.
	/// </param>
	/// <param name="szPassword">
	/// <para>
	/// A string password used to decrypt and verify the PFX packet. Whether set to a string of length greater than zero or set to an
	/// empty string or to <c>NULL</c>, this value must be exactly the same as the value that was used to encrypt the packet.
	/// </para>
	/// <para>
	/// Beginning with Windows 8 and Windows Server 2012, if the PFX packet was created in the PFXExportCertStoreEx function by using
	/// the <c>PKCS12_PROTECT_TO_DOMAIN_SIDS</c> flag, the <c>PFXImportCertStore</c> function attempts to decrypt the password by using
	/// the Active Directory (AD) principal that was used to encrypt it. The AD principal is specified in the pvPara parameter. If the
	/// szPassword parameter in the <c>PFXExportCertStoreEx</c> function was an empty string or <c>NULL</c> and the dwFlags parameter
	/// was set to <c>PKCS12_PROTECT_TO_DOMAIN_SIDS</c>, that function randomly generated a password and encrypted it to the AD
	/// principal specified in the pvPara parameter. In that case you should set the password to the value, empty string or <c>NULL</c>,
	/// that was used when the PFX packet was created. The <c>PFXImportCertStore</c> function will use the AD principal to decrypt the
	/// random password, and the randomly generated password will be used to decrypt the PFX certificate.
	/// </para>
	/// <para>
	/// When you have finished using the password, clear it from memory by calling the SecureZeroMemory function. For more information
	/// about protecting passwords, see Handling Passwords.
	/// </para>
	/// </param>
	/// <param name="dwFlags">
	/// <para>This parameter can be one of the following values.</para>
	/// <list type="table">
	/// <listheader>
	/// <term>Value</term>
	/// <term>Meaning</term>
	/// </listheader>
	/// <item>
	/// <term>CRYPT_EXPORTABLE 0x00000001</term>
	/// <term>
	/// Imported keys are marked as exportable. If this flag is not used, calls to the CryptExportKey function with the key handle fail.
	/// </term>
	/// </item>
	/// <item>
	/// <term>CRYPT_USER_PROTECTED 0x00000002</term>
	/// <term>
	/// The user is to be notified through a dialog box or other method when certain attempts to use this key are made. The precise
	/// behavior is specified by the cryptographic service provider (CSP) being used. Prior to Internet Explorer 4.0, Microsoft
	/// cryptographic service providers ignored this flag. Starting with Internet Explorer 4.0, Microsoft providers support this flag.
	/// If the provider context was opened with the CRYPT_SILENT flag set, using this flag causes a failure and the last error is set to NTE_SILENT_CONTEXT.
	/// </term>
	/// </item>
	/// <item>
	/// <term>CRYPT_MACHINE_KEYSET 0x00000020</term>
	/// <term>The private keys are stored under the local computer and not under the current user.</term>
	/// </item>
	/// <item>
	/// <term>CRYPT_USER_KEYSET 0x00001000</term>
	/// <term>
	/// The private keys are stored under the current user and not under the local computer even if the PFX BLOB specifies that they
	/// should go into the local computer.
	/// </term>
	/// </item>
	/// <item>
	/// <term>PKCS12_PREFER_CNG_KSP 0x00000100</term>
	/// <term>
	/// Indicates that the CNG key storage provider (KSP) is preferred. If the CSP is specified in the PFX file, then the CSP is used,
	/// otherwise the KSP is preferred. If the CNG KSP is unavailable, the PFXImportCertStore function will fail. Windows Server 2003
	/// and Windows XP: This value is not supported.
	/// </term>
	/// </item>
	/// <item>
	/// <term>PKCS12_ALWAYS_CNG_KSP 0x00000200</term>
	/// <term>
	/// Indicates that the CNG KSP is always used. When specified, PFXImportCertStore attempts to use the CNG KSP irrespective of
	/// provider information in the PFX file. If the CNG KSP is unavailable, the import will not fail. Windows Server 2003 and Windows
	/// XP: This value is not supported.
	/// </term>
	/// </item>
	/// <item>
	/// <term>PKCS12_ALLOW_OVERWRITE_KEY 0x00004000</term>
	/// <term>
	/// Allow overwrite of the existing key. Specify this flag when you encounter a scenario in which you must import a PFX file that
	/// contains a key name that already exists. For example, when you import a PFX file, it is possible that a container of the same
	/// name is already present because there is no unique namespace for key containers. If you have created a "TestKey" on your
	/// computer, and then you import a PFX file that also has "TestKey" as the key container, the PKCS12_ALLOW_OVERWRITE_KEY setting
	/// allows the key to be overwritten. Windows Server 2003 and Windows XP: This value is not supported.
	/// </term>
	/// </item>
	/// <item>
	/// <term>PKCS12_NO_PERSIST_KEY 0x00008000</term>
	/// <term>
	/// Do not persist the key. Specify this flag when you do not want to persist the key. For example, if it is not necessary to store
	/// the key after verification, then instead of creating a container and then deleting it, you can specify this flag to dispose of
	/// the key immediately. Windows Server 2003 and Windows XP: This value is not supported.
	/// </term>
	/// </item>
	/// <item>
	/// <term>PKCS12_INCLUDE_EXTENDED_PROPERTIES 0x0010</term>
	/// <term>
	/// Import all extended properties on the certificate that were saved on the certificate when it was exported. Windows Server 2003
	/// and Windows XP: This value is not supported.
	/// </term>
	/// </item>
	/// <item>
	/// <term>0x10000000</term>
	/// <term>Unpack but do not persist the results.</term>
	/// </item>
	/// </list>
	/// </param>
	/// <returns>
	/// <para>
	/// If the function succeeds, the function returns a handle to a certificate store that contains the imported certificates,
	/// including available private keys.
	/// </para>
	/// <para>
	/// If the function fails, that is, if the password parameter does not contain an exact match with the password used to encrypt the
	/// exported packet or if there were any other problems decoding the PFX BLOB, the function returns <c>NULL</c>, and an error code
	/// can be found by calling the GetLastError function.
	/// </para>
	/// </returns>
	/// <remarks>
	/// <para>
	/// The <c>PFXImportCertStore</c> function opens a temporary store. If the function succeeds, you should close the handle to the
	/// store by calling the CertCloseStore function.
	/// </para>
	/// <para>
	/// When you import a certificate from the PFX packet, the CSP/KSP container name is determined by using the AttributeId with OID
	/// 1.3.6.1.4.1.311.17.1 of the PKCS8ShroudedKeyBag SafeBag [bagId: 1.2.840.113549.1.12.10.1.2] (see PKCS #12 for details about the
	/// ASN.1 structure of this).
	/// </para>
	/// <para>
	/// If the AttributeId is not present and the PREFER_CNG flag is passed, MS_KEY_STORAGE_PROVIDER is picked. If the AttributeId is
	/// not present and the PREFER_CNG flag is not passed, the provider name is determined based on the public key algorithm (that is,
	/// the public key algorithm is determined by the AlgorithmIdentifier in PKCS #8):
	/// </para>
	/// <para>Similarly, the key specification is determined by using the AttributeId with OID 2.5.29.15 (szOID_KEY_USAGE) as follows:</para>
	/// <para>
	/// If the AttributeId is not present, then the CAPI key value is set to AT_KEYEXCHANGE for RSA or DH and the algorithm is
	/// determined by the AlgorithmIdentifier in PKCS #8; otherwise, the algorithm is set to AT_SIGNATURE. For the CNG key value, all
	/// ncrypt key usage is set.
	/// </para>
	/// <para>
	/// <c>Note</c> If an invalid provider name is present in the PFX packet, or the base or enhanced cryptography provider is not
	/// present in this registry key: <c>HKEY_LOCAL_MACHINE</c>\ <c>SOFTWARE</c>\ <c>Microsoft</c>\ <c>Cryptography</c>\
	/// <c>Defaults</c>\ <c>Provider</c>, then a provider lookup is performed by the provider type using this registry subkey:
	/// <c>HKEY_LOCAL_MACHINE</c>\ <c>SOFTWARE</c>\ <c>Microsoft</c>\ <c>Cryptography</c>\ <c>Defaults</c>\ <c>Provider Types</c>.
	/// </para>
	/// </remarks>
	// https://docs.microsoft.com/en-us/windows/win32/api/wincrypt/nf-wincrypt-pfximportcertstore HCERTSTORE PFXImportCertStore(
	// CRYPT_DATA_BLOB *pPFX, LPCWSTR szPassword, DWORD dwFlags );
	[DllImport(Lib.Crypt32, SetLastError = true, ExactSpelling = true)]
	[PInvokeData("wincrypt.h", MSDNShortId = "2c83774a-f2df-4d28-9abd-e39aa507ba88")]
	public static extern HCERTSTORE PFXImportCertStore(in CRYPTOAPI_BLOB pPFX, [MarshalAs(UnmanagedType.LPWStr)] string szPassword, PFXImportFlags dwFlags);

	/// <summary>The <c>PFXIsPFXBlob</c> function attempts to decode the outer layer of a BLOB as a PFX packet.</summary>
	/// <param name="pPFX">A pointer to a CRYPT_DATA_BLOB structure that the function will attempt to decode as a PFX packet.</param>
	/// <returns>
	/// The function returns <c>TRUE</c> if the BLOB can be decoded as a PFX packet. If the outer layer of the BLOB cannot be decoded as
	/// a PFX packet, the function returns <c>FALSE</c>.
	/// </returns>
	// https://docs.microsoft.com/en-us/windows/win32/api/wincrypt/nf-wincrypt-pfxispfxblob BOOL PFXIsPFXBlob( CRYPT_DATA_BLOB *pPFX );
	[DllImport(Lib.Crypt32, SetLastError = false, ExactSpelling = true)]
	[PInvokeData("wincrypt.h", MSDNShortId = "28984407-0a28-48e1-9d67-37a6e9db7601")]
	[return: MarshalAs(UnmanagedType.Bool)]
	public static extern bool PFXIsPFXBlob(in CRYPTOAPI_BLOB pPFX);

	/// <summary>
	/// <para>
	/// The <c>PFXVerifyPassword</c> function attempts to decode the outer layer of a BLOB as a Personal Information Exchange (PFX)
	/// packet and to decrypt it with the given password. No data from the BLOB is imported.
	/// </para>
	/// <para>The PFX format is also known as the Public-Key Cryptography Standards #12 (PKCS #12) format.</para>
	/// </summary>
	/// <param name="pPFX">A pointer to a CRYPT_DATA_BLOB structure that the function will attempt to decode as a PFX packet.</param>
	/// <param name="szPassword">
	/// <para>
	/// String password to be checked. For this function to succeed, this password must be exactly the same as the password used to
	/// encrypt the packet.
	/// </para>
	/// <para>
	/// If you set this value to an empty string or <c>NULL</c>, this function typically attempts to decrypt the password embedded in
	/// the PFX BLOB by using the empty string or <c>NULL</c>.
	/// </para>
	/// <para>
	/// However, beginning with Windows 8 and Windows Server 2012, if a <c>NULL</c> or empty password was specified when the PFX BLOB
	/// was created and the application also specified that the password should be protected to an Active Directory (AD) principal, the
	/// Cryptography API (CAPI) randomly generates a password, encrypts it to the AD principal and embeds it in the PFX BLOB. The
	/// <c>PFXVerifyPassword</c> function will then try to use the specified AD principal (current user, computer, or AD group member)
	/// to decrypt the password. For more information about protecting PFX to an AD principal, see the pvPara parameter and the
	/// <c>PKCS12_PROTECT_TO_DOMAIN_SIDS</c> flag of the PFXExportCertStoreEx function.
	/// </para>
	/// <para>
	/// When you have finished using the password, clear the password from memory by calling the SecureZeroMemory function. For more
	/// information about protecting passwords, see Handling Passwords.
	/// </para>
	/// </param>
	/// <param name="dwFlags">Reserved for future use.</param>
	/// <returns>The function return <c>TRUE</c> if the password appears correct; otherwise, it returns <c>FALSE</c>.</returns>
	// https://docs.microsoft.com/en-us/windows/win32/api/wincrypt/nf-wincrypt-pfxverifypassword BOOL PFXVerifyPassword( CRYPT_DATA_BLOB
	// *pPFX, LPCWSTR szPassword, DWORD dwFlags );
	[DllImport(Lib.Crypt32, SetLastError = false, ExactSpelling = true)]
	[PInvokeData("wincrypt.h", MSDNShortId = "47560192-547e-4440-9f10-43327355e1a0")]
	[return: MarshalAs(UnmanagedType.Bool)]
	public static extern bool PFXVerifyPassword(in CRYPTOAPI_BLOB pPFX, [MarshalAs(UnmanagedType.LPWStr)] string szPassword, uint dwFlags = 0);
}