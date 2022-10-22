using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using Vanara.Extensions;
using Vanara.InteropServices;

namespace Vanara.PInvoke
{
	/// <summary>Methods and data types found in Crypt32.dll.</summary>
	public static partial class Crypt32
	{
		/// <summary>The <c>CRYPT_ENUM_KEYID_PROP</c> callback function is used with the CryptEnumKeyIdentifierProperties function.</summary>
		/// <param name="pKeyIdentifier"/>
		/// <param name="dwFlags">Reserved for future use and must be zero.</param>
		/// <param name="pvReserved"/>
		/// <param name="pvArg"/>
		/// <param name="cProp">Count of elements in the array of rgdwPropId</param>
		/// <param name="rgdwPropId"/>
		/// <param name="rgpvData"/>
		/// <param name="rgcbData"/>
		/// <returns>Returns <c>TRUE</c> if the function succeeds, <c>FALSE</c> if it fails.</returns>
		// https://docs.microsoft.com/en-us/windows/win32/api/wincrypt/nc-wincrypt-pfn_crypt_enum_keyid_prop PFN_CRYPT_ENUM_KEYID_PROP
		// PfnCryptEnumKeyidProp; BOOL PfnCryptEnumKeyidProp( const CRYPT_HASH_BLOB *pKeyIdentifier, DWORD dwFlags, void *pvReserved, void
		// *pvArg, DWORD cProp, DWORD *rgdwPropId, void **rgpvData, DWORD *rgcbData ) {...}
		[PInvokeData("wincrypt.h", MSDNShortId = "c4461b79-d216-4d4a-bd5d-9260ec897c14")]
		[return: MarshalAs(UnmanagedType.Bool)]
		public delegate bool PFN_CRYPT_ENUM_KEYID_PROP([In, Optional] IntPtr pKeyIdentifier, [Optional] uint dwFlags, [Optional] IntPtr pvReserved, [Optional] IntPtr pvArg, uint cProp, [In] uint[] rgdwPropId, [In] IntPtr[] rgpvData, [In] uint[] rgcbData);

		/// <summary>Blob type specifier for PUBLICKEYSTRUC.</summary>
		[PInvokeData("wincrypt.h", MSDNShortId = "99d41222-b4ca-40f3-a240-52b0a9b3a9aa")]
		public enum BlobType : uint
		{
			/// <summary>The BLOB is a key state BLOB.</summary>
			KEYSTATEBLOB = 0xC,

			/// <summary>The key is a session key.</summary>
			OPAQUEKEYBLOB = 0x9,

			/// <summary>The key is a session key.</summary>
			PLAINTEXTKEYBLOB = 0x8,

			/// <summary>The key is a public/private key pair.</summary>
			PRIVATEKEYBLOB = 0x7,

			/// <summary>The key is a public key.</summary>
			PUBLICKEYBLOB = 0x6,

			/// <summary>The key is a public key.</summary>
			PUBLICKEYBLOBEX = 0xA,

			/// <summary>The key is a session key.</summary>
			SIMPLEBLOB = 0x1,

			/// <summary>The key is a session key.</summary>
			SYMMETRICWRAPKEYBLOB = 0xB,
		}

		/// <summary>Flags for CertFindUsage functions.</summary>
		[PInvokeData("wincrypt.h", MSDNShortId = "eda6d875-df62-4f40-8734-a91666dba289")]
		[Flags]
		public enum CertFindUsageFlags : uint
		{
			/// <summary>
			/// When this flag is set, in addition to usual matches, any certificate that has neither the enhanced key usage extension nor
			/// the enhanced key usage property meets the search criteria.
			/// </summary>
			CERT_FIND_OPTIONAL_ENHKEY_USAGE_FLAG = 0x1,

			/// <summary>
			/// When this flag is set, the matching process involves only the extension usage identifiers. If pvFindPara is NULL or the
			/// cUsageIdentifier member of the CERT_ENHKEY_USAGE structure pointed to by pvFindPara is zero, any certificate having an
			/// enhanced key usage extension is a match. If CERT_FIND_OPTIONAL_ENHKEY_USAGE_FLAG is also set, any certificate without the
			/// enhanced key usage extension is also a match. If CERT_FIND_NO_ENHKEY_USAGE_FLAG is also set, only certificates without the
			/// enhanced key usage extension are matches.
			/// </summary>
			CERT_FIND_EXT_ONLY_ENHKEY_USAGE_FLAG = 0x2,

			/// <summary>
			/// When this flag is set, the matching process involves only usage identifiers that are properties. If pvFindPara is NULL or
			/// cUsageIdentifier is set to zero, any certificate having an enhanced key usage property is a match. If
			/// CERT_FIND_OPTIONAL_ENHKEY_USAGE_FLAG is also set, any certificate without the enhanced key usage property is also a match.
			/// If CERT_FIND_NO_ENHKEY_USAGE_FLAG is set, only certificates without the enhanced key usage property are matches.
			/// </summary>
			CERT_FIND_PROP_ONLY_ENHKEY_USAGE_FLAG = 0x4,

			/// <summary>
			/// When this flag is set, only those certificates that have neither an enhanced key usage nor the enhanced key usage property
			/// are matches. This flag setting takes precedence over pvFindPara being NULL.
			/// </summary>
			CERT_FIND_NO_ENHKEY_USAGE_FLAG = 0x8,

			/// <summary>
			/// The search criteria can be altered by setting one or more flags. By default, if the pszUsageIdentifier member of the
			/// CERT_ENHKEY_USAGE structure pointed to by pvFindPara is to be matched, each identifier must be matched to satisfy the search
			/// criteria. However, if CERT_FIND_OR_ENHKEY_USAGE_FLAG is set, a match can be made to all identifiers combined by using a
			/// bitwise-OR operation; thus, matching any one of the identifiers is sufficient.
			/// </summary>
			CERT_FIND_OR_ENHKEY_USAGE_FLAG = 0x10,

			/// <summary>
			/// When this flag is set, the function only matches those certificates that are valid for the specified usage. By default, in
			/// order to match, a certificate must be valid for all usages.
			/// <para>
			/// CERT_FIND_OR_ENHKEY_USAGE_FLAG can also be set if the certificate only needs to be valid for one of the specified usages.
			/// Note that CertGetValidUsages is called to get the list of valid uses for the certificate. Only
			/// CERT_FIND_OR_ENHKEY_USAGE_FLAG can also apply when CERT_FIND_VALID_ENHKEY_USAGE_FLAG is set.
			/// </para>
			/// </summary>
			CERT_FIND_VALID_ENHKEY_USAGE_FLAG = 0x20,
		}

		/// <summary>Flags for <see cref="CryptEnumKeyIdentifierProperties(IntPtr, uint, CryptKeyIdFlags, string, IntPtr, IntPtr, PFN_CRYPT_ENUM_KEYID_PROP)"/>.</summary>
		[PInvokeData("wincrypt.h", MSDNShortId = "6e57d935-4cfb-44af-b1c6-6c399c959452")]
		[Flags]
		public enum CryptKeyIdFlags
		{
			/// <summary>
			/// The list of key identifiers of the LocalMachine (if pwszComputerName is <c>NULL</c>) or of a remote computer (if
			/// pwszComputerName is not <c>NULL</c>) is searched.
			/// </summary>
			CRYPT_KEYID_MACHINE_FLAG = 0x00000020,

			/// <summary>
			/// When set, pvData is updated with a pointer to allocated memory. LocalFree() must be called to free the allocated memory.
			/// </summary>
			CRYPT_KEYID_ALLOC_FLAG = 0x00008000,

			/// <summary>The key identifier and all of its properties are deleted.</summary>
			CRYPT_KEYID_DELETE_FLAG = 0x00000010,

			/// <summary>
			/// Sets a new key identifier property. If the property already exists, the attempt fails, and FALSE is returned with the last
			/// error code set to CRYPT_E_EXISTS.
			/// </summary>
			CRYPT_KEYID_SET_NEW_FLAG = 0x00002000,
		}

		/// <summary>
		/// The <c>CertAddEnhancedKeyUsageIdentifier</c> function adds a usage identifier object identifier (OID) to the enhanced key usage
		/// (EKU) extended property of the certificate.
		/// </summary>
		/// <param name="pCertContext">A pointer to the CERT_CONTEXT of the certificate for which the usage identifier is to be added.</param>
		/// <param name="pszUsageIdentifier">Specifies the usage identifier OID to add.</param>
		/// <returns>
		/// <para>If the function succeeds, the function returns nonzero ( <c>TRUE</c>).</para>
		/// <para>If the function fails, it returns zero ( <c>FALSE</c>). For extended error information, call GetLastError.</para>
		/// </returns>
		// https://docs.microsoft.com/en-us/windows/win32/api/wincrypt/nf-wincrypt-certaddenhancedkeyusageidentifier BOOL
		// CertAddEnhancedKeyUsageIdentifier( PCCERT_CONTEXT pCertContext, LPCSTR pszUsageIdentifier );
		[DllImport(Lib.Crypt32, SetLastError = true, ExactSpelling = true)]
		[PInvokeData("wincrypt.h", MSDNShortId = "1bec8d2f-aa43-4a8b-9414-c3a4e5fcb470")]
		[return: MarshalAs(UnmanagedType.Bool)]
		public static extern bool CertAddEnhancedKeyUsageIdentifier([In] PCCERT_CONTEXT pCertContext, SafeOID pszUsageIdentifier);

		/// <summary>
		/// The <c>CertGetEnhancedKeyUsage</c> function returns information from the enhanced key usage (EKU) extension or the EKU extended
		/// property of a certificate. EKUs indicate valid uses of the certificate.
		/// </summary>
		/// <param name="pCertContext">A pointer to a CERT_CONTEXT certificate context.</param>
		/// <param name="dwFlags">
		/// <para>
		/// Indicates whether the function will report on extensions of a certificate, its extended properties, or both. If set to zero, the
		/// function returns the valid uses of a certificate based on both the EKU extension and the EKU extended property value of the certificate.
		/// </para>
		/// <para>To return only the EKU extension or EKU property value, set the following flags.</para>
		/// <list type="table">
		/// <listheader>
		/// <term>Value</term>
		/// <term>Meaning</term>
		/// </listheader>
		/// <item>
		/// <term>CERT_FIND_EXT_ONLY_ENHKEY_USAGE_FLAG</term>
		/// <term>Get only the extension.</term>
		/// </item>
		/// <item>
		/// <term>CERT_FIND_PROP_ONLY_ENHKEY_USAGE_FLAG</term>
		/// <term>Get only the extended property value.</term>
		/// </item>
		/// </list>
		/// </param>
		/// <param name="pUsage">
		/// <para>
		/// A pointer to a CERT_ENHKEY_USAGE structure ( <c>CERT_ENHKEY_USAGE</c> is an alternate typedef name for the <c>CTL_USAGE</c>
		/// structure) that receives the valid uses of the certificate.
		/// </para>
		/// <para>
		/// This parameter can be <c>NULL</c> to set the size of the key usage for memory allocation purposes. For more information, see
		/// Retrieving Data of Unknown Length.
		/// </para>
		/// </param>
		/// <param name="pcbUsage">
		/// A pointer to a <c>DWORD</c> that specifies the size, in bytes, of the structure pointed to by pUsage. When the function returns,
		/// the <c>DWORD</c> contains the size, in bytes, of the structure.
		/// </param>
		/// <returns>
		/// <para>If the function succeeds, the function returns nonzero ( <c>TRUE</c>).</para>
		/// <para>If the function fails, it returns zero ( <c>FALSE</c>).</para>
		/// </returns>
		/// <remarks>
		/// <para>
		/// If a certificate has an EKU extension, that extension lists object identifiers (OIDs) for valid uses of that certificate. In a
		/// Microsoft environment, a certificate might also have EKU extended properties that specify valid uses for the certificate.
		/// </para>
		/// <list type="bullet">
		/// <item>
		/// <term>If a certificate has neither an EKU extension nor EKU extended properties, it is assumed to be valid for all uses.</term>
		/// </item>
		/// <item>
		/// <term>
		/// If it has either an EKU extension or EKU extended properties but not both, it is valid only for the uses indicated in the
		/// extension or extended properties that it has.
		/// </term>
		/// </item>
		/// <item>
		/// <term>
		/// If a certificate has both an EKU extension and EKU extended properties, it is valid only for the uses that are on both lists.
		/// </term>
		/// </item>
		/// </list>
		/// <para>
		/// If dwFlags is set to zero, the <c>cUsageIdentifier</c> member of the <c>CERT_ENHKEY_USAGE</c> structure is set to the number of
		/// valid uses of the certificate determined by the value of both the EKU extension and the EKU extended property value.
		/// </para>
		/// <para>
		/// If the <c>cUsageIdentifier</c> member is zero, the certificate might be valid for all uses or the certificate might have no
		/// valid uses. The return from a call to GetLastError can be used to determine whether the certificate is good for all uses or for
		/// none. If <c>GetLastError</c> returns CRYPT_E_NOT_FOUND, the certificate is good for all uses. If it returns zero, the
		/// certificate has no valid uses.
		/// </para>
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows/win32/api/wincrypt/nf-wincrypt-certgetenhancedkeyusage BOOL CertGetEnhancedKeyUsage(
		// PCCERT_CONTEXT pCertContext, DWORD dwFlags, PCERT_ENHKEY_USAGE pUsage, DWORD *pcbUsage );
		[DllImport(Lib.Crypt32, SetLastError = true, ExactSpelling = true)]
		[PInvokeData("wincrypt.h", MSDNShortId = "eda6d875-df62-4f40-8734-a91666dba289")]
		[return: MarshalAs(UnmanagedType.Bool)]
		public static extern bool CertGetEnhancedKeyUsage(PCCERT_CONTEXT pCertContext, CertFindUsageFlags dwFlags, [Out] IntPtr pUsage, ref uint pcbUsage);

		/// <summary>
		/// The <c>CertRemoveEnhancedKeyUsageIdentifier</c> function removes a usage identifier object identifier (OID) from the enhanced
		/// key usage (EKU) extended property of the certificate.
		/// </summary>
		/// <param name="pCertContext">A pointer to a CERT_CONTEXT of the certificate for which the usage identifier OID is to be removed.</param>
		/// <param name="pszUsageIdentifier">A pointer to the usage identifier OID to remove.</param>
		/// <returns>
		/// <para>If the function succeeds, the function returns nonzero ( <c>TRUE</c>).</para>
		/// <para>If the function fails, it returns zero ( <c>FALSE</c>). For extended error information, call GetLastError.</para>
		/// </returns>
		// https://docs.microsoft.com/en-us/windows/win32/api/wincrypt/nf-wincrypt-certremoveenhancedkeyusageidentifier BOOL
		// CertRemoveEnhancedKeyUsageIdentifier( PCCERT_CONTEXT pCertContext, LPCSTR pszUsageIdentifier );
		[DllImport(Lib.Crypt32, SetLastError = true, ExactSpelling = true)]
		[PInvokeData("wincrypt.h", MSDNShortId = "4fb27073-674c-4bac-9a62-6e33e1a5785e")]
		[return: MarshalAs(UnmanagedType.Bool)]
		public static extern bool CertRemoveEnhancedKeyUsageIdentifier(PCCERT_CONTEXT pCertContext, SafeOID pszUsageIdentifier);

		/// <summary>
		/// The <c>CertSetEnhancedKeyUsage</c> function sets the enhanced key usage (EKU) property for the certificate. Use of this function
		/// replaces any EKUs associated with the certificate. To add a single EKU usage without changing existing usages, use
		/// CertAddEnhancedKeyUsageIdentifier. To delete a single EKU usage, use CertRemoveEnhancedKeyUsageIdentifier.
		/// </summary>
		/// <param name="pCertContext">A pointer to the CERT_CONTEXT of the specified certificate.</param>
		/// <param name="pUsage">
		/// Pointer to a CERT_ENHKEY_USAGE structure (equivalent to a <c>CTL_USAGE</c> structure) that contains an array of EKU object
		/// identifiers (OIDs) to be set as extended properties of the certificate.
		/// </param>
		/// <returns>
		/// <para>If the function succeeds, the function returns nonzero ( <c>TRUE</c>).</para>
		/// <para>If the function fails, it returns zero ( <c>FALSE</c>). For extended error information, call GetLastError.</para>
		/// </returns>
		// https://docs.microsoft.com/en-us/windows/win32/api/wincrypt/nf-wincrypt-certsetenhancedkeyusage BOOL CertSetEnhancedKeyUsage(
		// PCCERT_CONTEXT pCertContext, PCERT_ENHKEY_USAGE pUsage );
		[DllImport(Lib.Crypt32, SetLastError = true, ExactSpelling = true)]
		[PInvokeData("wincrypt.h", MSDNShortId = "423b0232-846e-4e40-bc42-d30c48c548da")]
		[return: MarshalAs(UnmanagedType.Bool)] public static extern bool CertSetEnhancedKeyUsage(PCCERT_CONTEXT pCertContext, in CTL_USAGE pUsage);

		/// <summary>
		/// This function converts a PUBLICKEYSTRUC of a CSP into an X.509 CERT_PUBLIC_KEY_INFO structure and encodes it. The encoded
		/// structure is then hashed with the SHA1 algorithm to obtain the key identifier.
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
		/// <param name="pszPubKeyOID">
		/// A pointer to the public key object identifier (OID). A value that is not <c>NULL</c> overrides the default OID obtained from the
		/// <c>aiKeyAlg</c> member of the structure pointed to by pPubKeyStruc. To use the default OID, set pszPubKeyOID to <c>NULL</c>.
		/// </param>
		/// <param name="pPubKeyStruc">
		/// A pointer to a PUBLICKEYSTRUC structure. In the default case, the <c>aiKeyAlg</c> member of the structure pointed to by
		/// pPubKeyStruc is used to find the public key OID. When the value of pszPubKeyOID is not <c>NULL</c>, it overrides the default.
		/// </param>
		/// <param name="cbPubKeyStruc">The size, in bytes, of the PUBLICKEYSTRUC.</param>
		/// <param name="dwFlags">Reserved for future use and must be zero.</param>
		/// <param name="pvReserved">Reserved for future use and must be <c>NULL</c>.</param>
		/// <param name="pbHash">
		/// <para>A pointer to a buffer to receive the hash of the public key and the key identifier.</para>
		/// <para>
		/// To get the size of this information for memory allocation purposes, set this parameter to <c>NULL</c>. For more information, see
		/// Retrieving Data of Unknown Length.
		/// </para>
		/// </param>
		/// <param name="pcbHash">
		/// A pointer to a <c>DWORD</c> that specifies the size, in bytes, of the buffer pointed to by the pbHash parameter. When the
		/// function returns, the <c>DWORD</c> contains the number of bytes stored in the buffer. Using SHA1 hashing, the length of the
		/// required buffer is twenty.
		/// </param>
		/// <returns>
		/// <para>If the function succeeds, the function returns nonzero ( <c>TRUE</c>).</para>
		/// <para>If the function fails, it returns zero ( <c>FALSE</c>). For extended error information, call GetLastError.</para>
		/// </returns>
		// https://docs.microsoft.com/en-us/windows/win32/api/wincrypt/nf-wincrypt-cryptcreatekeyidentifierfromcsp BOOL
		// CryptCreateKeyIdentifierFromCSP( DWORD dwCertEncodingType, LPCSTR pszPubKeyOID, const PUBLICKEYSTRUC *pPubKeyStruc, DWORD
		// cbPubKeyStruc, DWORD dwFlags, void *pvReserved, BYTE *pbHash, DWORD *pcbHash );
		[DllImport(Lib.Crypt32, SetLastError = true, ExactSpelling = true)]
		[PInvokeData("wincrypt.h", MSDNShortId = "628e1995-8207-4daa-a445-cb21a755ffa6")]
		[return: MarshalAs(UnmanagedType.Bool)]
		public static extern bool CryptCreateKeyIdentifierFromCSP(CertEncodingType dwCertEncodingType, [Optional] SafeOID pszPubKeyOID,
			in PUBLICKEYSTRUC pPubKeyStruc, uint cbPubKeyStruc, uint dwFlags, [Optional] IntPtr pvReserved, [Out] IntPtr pbHash, ref uint pcbHash);

		/// <summary>
		/// <para>A pointer to a CRYPT_HASH_BLOB structure that contains the key identifier.</para>
		/// <para>If pKeyIdentifier is <c>NULL</c>, the function enumerates all key identifiers.</para>
		/// <para>If pKeyIdentifier is not <c>NULL</c>, the callback function pfnEnum is only called for the specified key identifier.</para>
		/// <para>Indicates the property identifier to be listed.</para>
		/// <para>If dwPropId is set to zero, this function calls the callback function with all the properties.</para>
		/// <para>
		/// If dwPropId is not zero and pKeyIdentifier is <c>NULL</c>, the callback function is called only for those key identifiers that
		/// have the specified property (sets the cProp parameter of pfnEnum to one). All key identifiers that do not have the property are skipped.
		/// </para>
		/// <para>Any certificate property identifier can be used.</para>
		/// <para>
		/// By default, the list of key identifiers for the CurrentUser is searched. If CRYPT_KEYID_MACHINE_FLAG is set, the list of key
		/// identifiers of the LocalMachine (if pwszComputerName is <c>NULL</c>) or of a remote computer (if pwszComputerName is not
		/// <c>NULL</c>) is searched. For more information, see pwszComputerName.
		/// </para>
		/// <para>
		/// A pointer to the name of a remote computer to be searched. If CRYPT_KEYID_MACHINE_FLAG is set in dwFlags, the remote computer is
		/// searched for a list of key identifiers. If the local computer is to be searched and not a remote computer, pwszComputerName is
		/// set to <c>NULL</c>.
		/// </para>
		/// <para>Reserved for future use and must be <c>NULL</c>.</para>
		/// <para>
		/// A pointer to data to be passed to the callback function. The type is a void that allows the application to declare, define, and
		/// initialize a structure or argument to hold any information.
		/// </para>
		/// <para>
		/// A pointer to an application-defined callback function that is executed for each key identifier entry that matches the input
		/// parameters. For details about the callback functions parameters, see CRYPT_ENUM_KEYID_PROP.
		/// </para>
		/// </summary>
		/// <param name="pKeyIdentifier">
		/// <para>A pointer to a CRYPT_HASH_BLOB structure that contains the key identifier.</para>
		/// <para>If pKeyIdentifier is <c>NULL</c>, the function enumerates all key identifiers.</para>
		/// <para>If pKeyIdentifier is not <c>NULL</c>, the callback function pfnEnum is only called for the specified key identifier.</para>
		/// </param>
		/// <param name="dwPropId">
		/// <para>Indicates the property identifier to be listed.</para>
		/// <para>If dwPropId is set to zero, this function calls the callback function with all the properties.</para>
		/// <para>
		/// If dwPropId is not zero and pKeyIdentifier is <c>NULL</c>, the callback function is called only for those key identifiers that
		/// have the specified property (sets the cProp parameter of pfnEnum to one). All key identifiers that do not have the property are skipped.
		/// </para>
		/// <para>Any certificate property identifier can be used.</para>
		/// </param>
		/// <param name="dwFlags">
		/// By default, the list of key identifiers for the CurrentUser is searched. If CRYPT_KEYID_MACHINE_FLAG is set, the list of key
		/// identifiers of the LocalMachine (if pwszComputerName is <c>NULL</c>) or of a remote computer (if pwszComputerName is not
		/// <c>NULL</c>) is searched. For more information, see pwszComputerName.
		/// </param>
		/// <param name="pwszComputerName">
		/// A pointer to the name of a remote computer to be searched. If CRYPT_KEYID_MACHINE_FLAG is set in dwFlags, the remote computer is
		/// searched for a list of key identifiers. If the local computer is to be searched and not a remote computer, pwszComputerName is
		/// set to <c>NULL</c>.
		/// </param>
		/// <param name="pvReserved">Reserved for future use and must be <c>NULL</c>.</param>
		/// <param name="pvArg">
		/// A pointer to data to be passed to the callback function. The type is a void that allows the application to declare, define, and
		/// initialize a structure or argument to hold any information.
		/// </param>
		/// <param name="pfnEnum">
		/// A pointer to an application-defined callback function that is executed for each key identifier entry that matches the input
		/// parameters. For details about the callback functions parameters, see CRYPT_ENUM_KEYID_PROP.
		/// </param>
		/// <returns>
		/// <para>
		/// The <c>CryptEnumKeyIdentifierProperties</c> function repeatedly calls the CRYPT_ENUM_KEYID_PROP callback function until the last
		/// key identifier is enumerated or the callback function returns <c>FALSE</c>.
		/// </para>
		/// <para>If the main function succeeds, the function returns nonzero ( <c>TRUE</c>).</para>
		/// <para>If the function fails, it returns zero ( <c>FALSE</c>). For extended error information, call GetLastError.</para>
		/// <para>To continue enumeration, the function returns <c>TRUE</c>.</para>
		/// <para>To stop enumeration, the function returns <c>FALSE</c> and sets the last error code.</para>
		/// </returns>
		/// <remarks>
		/// <para>A key identifier can have the same properties as a certificate context.</para>
		/// <para>Examples</para>
		/// <para>For an example that uses this function, see Example C Program: Working with Key Identifiers.</para>
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows/win32/api/wincrypt/nf-wincrypt-cryptenumkeyidentifierproperties BOOL
		// CryptEnumKeyIdentifierProperties( const CRYPT_HASH_BLOB *pKeyIdentifier, DWORD dwPropId, DWORD dwFlags, LPCWSTR pwszComputerName,
		// void *pvReserved, void *pvArg, PFN_CRYPT_ENUM_KEYID_PROP pfnEnum );
		[DllImport(Lib.Crypt32, SetLastError = true, ExactSpelling = true)]
		[PInvokeData("wincrypt.h", MSDNShortId = "6e57d935-4cfb-44af-b1c6-6c399c959452")]
		[return: MarshalAs(UnmanagedType.Bool)]
		public static extern bool CryptEnumKeyIdentifierProperties(in CRYPTOAPI_BLOB pKeyIdentifier, [In, Optional] uint dwPropId, CryptKeyIdFlags dwFlags,
			[Optional, MarshalAs(UnmanagedType.LPWStr)] string pwszComputerName, [In, Optional] IntPtr pvReserved, [In, Optional] IntPtr pvArg,
			[MarshalAs(UnmanagedType.FunctionPtr)] PFN_CRYPT_ENUM_KEYID_PROP pfnEnum);

		/// <summary>
		/// <para>A pointer to a CRYPT_HASH_BLOB structure that contains the key identifier.</para>
		/// <para>If pKeyIdentifier is <c>NULL</c>, the function enumerates all key identifiers.</para>
		/// <para>If pKeyIdentifier is not <c>NULL</c>, the callback function pfnEnum is only called for the specified key identifier.</para>
		/// <para>Indicates the property identifier to be listed.</para>
		/// <para>If dwPropId is set to zero, this function calls the callback function with all the properties.</para>
		/// <para>
		/// If dwPropId is not zero and pKeyIdentifier is <c>NULL</c>, the callback function is called only for those key identifiers that
		/// have the specified property (sets the cProp parameter of pfnEnum to one). All key identifiers that do not have the property are skipped.
		/// </para>
		/// <para>Any certificate property identifier can be used.</para>
		/// <para>
		/// By default, the list of key identifiers for the CurrentUser is searched. If CRYPT_KEYID_MACHINE_FLAG is set, the list of key
		/// identifiers of the LocalMachine (if pwszComputerName is <c>NULL</c>) or of a remote computer (if pwszComputerName is not
		/// <c>NULL</c>) is searched. For more information, see pwszComputerName.
		/// </para>
		/// <para>
		/// A pointer to the name of a remote computer to be searched. If CRYPT_KEYID_MACHINE_FLAG is set in dwFlags, the remote computer is
		/// searched for a list of key identifiers. If the local computer is to be searched and not a remote computer, pwszComputerName is
		/// set to <c>NULL</c>.
		/// </para>
		/// <para>Reserved for future use and must be <c>NULL</c>.</para>
		/// <para>
		/// A pointer to data to be passed to the callback function. The type is a void that allows the application to declare, define, and
		/// initialize a structure or argument to hold any information.
		/// </para>
		/// <para>
		/// A pointer to an application-defined callback function that is executed for each key identifier entry that matches the input
		/// parameters. For details about the callback functions parameters, see CRYPT_ENUM_KEYID_PROP.
		/// </para>
		/// </summary>
		/// <param name="pKeyIdentifier">
		/// <para>A pointer to a CRYPT_HASH_BLOB structure that contains the key identifier.</para>
		/// <para>If pKeyIdentifier is <c>NULL</c>, the function enumerates all key identifiers.</para>
		/// <para>If pKeyIdentifier is not <c>NULL</c>, the callback function pfnEnum is only called for the specified key identifier.</para>
		/// </param>
		/// <param name="dwPropId">
		/// <para>Indicates the property identifier to be listed.</para>
		/// <para>If dwPropId is set to zero, this function calls the callback function with all the properties.</para>
		/// <para>
		/// If dwPropId is not zero and pKeyIdentifier is <c>NULL</c>, the callback function is called only for those key identifiers that
		/// have the specified property (sets the cProp parameter of pfnEnum to one). All key identifiers that do not have the property are skipped.
		/// </para>
		/// <para>Any certificate property identifier can be used.</para>
		/// </param>
		/// <param name="dwFlags">
		/// By default, the list of key identifiers for the CurrentUser is searched. If CRYPT_KEYID_MACHINE_FLAG is set, the list of key
		/// identifiers of the LocalMachine (if pwszComputerName is <c>NULL</c>) or of a remote computer (if pwszComputerName is not
		/// <c>NULL</c>) is searched. For more information, see pwszComputerName.
		/// </param>
		/// <param name="pwszComputerName">
		/// A pointer to the name of a remote computer to be searched. If CRYPT_KEYID_MACHINE_FLAG is set in dwFlags, the remote computer is
		/// searched for a list of key identifiers. If the local computer is to be searched and not a remote computer, pwszComputerName is
		/// set to <c>NULL</c>.
		/// </param>
		/// <param name="pvReserved">Reserved for future use and must be <c>NULL</c>.</param>
		/// <param name="pvArg">
		/// A pointer to data to be passed to the callback function. The type is a void that allows the application to declare, define, and
		/// initialize a structure or argument to hold any information.
		/// </param>
		/// <param name="pfnEnum">
		/// A pointer to an application-defined callback function that is executed for each key identifier entry that matches the input
		/// parameters. For details about the callback functions parameters, see CRYPT_ENUM_KEYID_PROP.
		/// </param>
		/// <returns>
		/// <para>
		/// The <c>CryptEnumKeyIdentifierProperties</c> function repeatedly calls the CRYPT_ENUM_KEYID_PROP callback function until the last
		/// key identifier is enumerated or the callback function returns <c>FALSE</c>.
		/// </para>
		/// <para>If the main function succeeds, the function returns nonzero ( <c>TRUE</c>).</para>
		/// <para>If the function fails, it returns zero ( <c>FALSE</c>). For extended error information, call GetLastError.</para>
		/// <para>To continue enumeration, the function returns <c>TRUE</c>.</para>
		/// <para>To stop enumeration, the function returns <c>FALSE</c> and sets the last error code.</para>
		/// </returns>
		/// <remarks>
		/// <para>A key identifier can have the same properties as a certificate context.</para>
		/// <para>Examples</para>
		/// <para>For an example that uses this function, see Example C Program: Working with Key Identifiers.</para>
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows/win32/api/wincrypt/nf-wincrypt-cryptenumkeyidentifierproperties BOOL
		// CryptEnumKeyIdentifierProperties( const CRYPT_HASH_BLOB *pKeyIdentifier, DWORD dwPropId, DWORD dwFlags, LPCWSTR pwszComputerName,
		// void *pvReserved, void *pvArg, PFN_CRYPT_ENUM_KEYID_PROP pfnEnum );
		[DllImport(Lib.Crypt32, SetLastError = true, ExactSpelling = true)]
		[PInvokeData("wincrypt.h", MSDNShortId = "6e57d935-4cfb-44af-b1c6-6c399c959452")]
		[return: MarshalAs(UnmanagedType.Bool)]
		public static extern bool CryptEnumKeyIdentifierProperties([In, Optional] IntPtr pKeyIdentifier, [In, Optional] uint dwPropId, CryptKeyIdFlags dwFlags,
			[Optional, MarshalAs(UnmanagedType.LPWStr)] string pwszComputerName, [In, Optional] IntPtr pvReserved, [In, Optional] IntPtr pvArg,
			[MarshalAs(UnmanagedType.FunctionPtr)] PFN_CRYPT_ENUM_KEYID_PROP pfnEnum);

		/// <summary>
		/// <para>A pointer to a CRYPT_HASH_BLOB structure that contains the key identifier.</para>
		/// <para>If pKeyIdentifier is <c>NULL</c>, the function enumerates all key identifiers.</para>
		/// <para>If pKeyIdentifier is not <c>NULL</c>, the callback function pfnEnum is only called for the specified key identifier.</para>
		/// <para>Indicates the property identifier to be listed.</para>
		/// <para>If dwPropId is set to zero, this function calls the callback function with all the properties.</para>
		/// <para>
		/// If dwPropId is not zero and pKeyIdentifier is <c>NULL</c>, the callback function is called only for those key identifiers that
		/// have the specified property (sets the cProp parameter of pfnEnum to one). All key identifiers that do not have the property are skipped.
		/// </para>
		/// <para>Any certificate property identifier can be used.</para>
		/// <para>
		/// By default, the list of key identifiers for the CurrentUser is searched. If CRYPT_KEYID_MACHINE_FLAG is set, the list of key
		/// identifiers of the LocalMachine (if pwszComputerName is <c>NULL</c>) or of a remote computer (if pwszComputerName is not
		/// <c>NULL</c>) is searched. For more information, see pwszComputerName.
		/// </para>
		/// <para>
		/// A pointer to the name of a remote computer to be searched. If CRYPT_KEYID_MACHINE_FLAG is set in dwFlags, the remote computer is
		/// searched for a list of key identifiers. If the local computer is to be searched and not a remote computer, pwszComputerName is
		/// set to <c>NULL</c>.
		/// </para>
		/// <para>Reserved for future use and must be <c>NULL</c>.</para>
		/// <para>
		/// A pointer to data to be passed to the callback function. The type is a void that allows the application to declare, define, and
		/// initialize a structure or argument to hold any information.
		/// </para>
		/// <para>
		/// A pointer to an application-defined callback function that is executed for each key identifier entry that matches the input
		/// parameters. For details about the callback functions parameters, see CRYPT_ENUM_KEYID_PROP.
		/// </para>
		/// </summary>
		/// <param name="pKeyIdentifier">
		/// <para>A pointer to a CRYPT_HASH_BLOB structure that contains the key identifier.</para>
		/// <para>If pKeyIdentifier is <c>NULL</c>, the function enumerates all key identifiers.</para>
		/// <para>If pKeyIdentifier is not <c>NULL</c>, the callback function pfnEnum is only called for the specified key identifier.</para>
		/// </param>
		/// <param name="dwPropId">
		/// <para>Indicates the property identifier to be listed.</para>
		/// <para>If dwPropId is set to zero, this function calls the callback function with all the properties.</para>
		/// <para>
		/// If dwPropId is not zero and pKeyIdentifier is <c>NULL</c>, the callback function is called only for those key identifiers that
		/// have the specified property (sets the cProp parameter of pfnEnum to one). All key identifiers that do not have the property are skipped.
		/// </para>
		/// <para>Any certificate property identifier can be used.</para>
		/// </param>
		/// <param name="dwFlags">
		/// By default, the list of key identifiers for the CurrentUser is searched. If CRYPT_KEYID_MACHINE_FLAG is set, the list of key
		/// identifiers of the LocalMachine (if pwszComputerName is <c>NULL</c>) or of a remote computer (if pwszComputerName is not
		/// <c>NULL</c>) is searched. For more information, see pwszComputerName.
		/// </param>
		/// <param name="pwszComputerName">
		/// A pointer to the name of a remote computer to be searched. If CRYPT_KEYID_MACHINE_FLAG is set in dwFlags, the remote computer is
		/// searched for a list of key identifiers. If the local computer is to be searched and not a remote computer, pwszComputerName is
		/// set to <c>NULL</c>.
		/// </param>
		/// <returns>A sequence of tuples containing the key identifier and an array of property identifiers and values as byte arrays.</returns>
		public static IEnumerable<(byte[] keyId, (uint propId, byte[] data)[] props)> CryptEnumKeyIdentifierProperties(CRYPTOAPI_BLOB? pKeyIdentifier = null,
			uint dwPropId = 0, CryptKeyIdFlags dwFlags = CryptKeyIdFlags.CRYPT_KEYID_MACHINE_FLAG, string pwszComputerName = null)
		{
			List<(byte[] keyId, (uint propId, byte[] data)[] props)> output = new();
			using SafeCoTaskMemStruct<CRYPTOAPI_BLOB> pKeyId = pKeyIdentifier.HasValue ? new(pKeyIdentifier.Value) : SafeCoTaskMemStruct<CRYPTOAPI_BLOB>.Null;
			Win32Error.ThrowLastErrorIfFalse(CryptEnumKeyIdentifierProperties(pKeyId, dwPropId, dwFlags, pwszComputerName, default, default, fn));
			return output;

			unsafe bool fn(IntPtr pKeyIdentifier, uint dwFlags, IntPtr pvReserved, IntPtr pvArg, uint cProp, uint[] rgdwPropId, IntPtr[] rgpvData, uint[] rgcbData)
			{
				try
				{
					var id = pKeyIdentifier == IntPtr.Zero ? null : ((CRYPTOAPI_BLOB*)(void*)pKeyIdentifier)->GetBytes();
					var props = new (uint propId, byte[] data)[(int)cProp];
					for (uint i = 0; i < cProp; i++)
						props[i] = (rgdwPropId[i], rgpvData[i].AsReadOnlySpan<byte>((int)rgcbData[i]).ToArray());
					output.Add((id, props));
					return true;
				}
				catch { }
				return false;
			}
		}

		/// <summary>
		/// <para>A pointer to the CRYPT_HASH_BLOB that contains the key identifier.</para>
		/// <para>
		/// Identifies the property to retrieve. The value of dwPropId determines the type and content of the pvData parameter. Any
		/// certificate property ID can be used.
		/// </para>
		/// <para>The following flags can be used. They can be combined with a bitwise- <c>OR</c> operation.</para>
		/// <list type="table">
		/// <listheader>
		/// <term>Value</term>
		/// <term>Meaning</term>
		/// </listheader>
		/// <item>
		/// <term>CRYPT_KEYID_MACHINE_FLAG</term>
		/// <term>
		/// Search the list of key identifiers of the LocalMachine (if pwszComputerName is NULL) or remote computer (if pwszComputerName is
		/// not NULL). For more information, see pwszComputerName.
		/// </term>
		/// </item>
		/// <item>
		/// <term>CRYPT_KEYID_ALLOC_FLAG</term>
		/// <term>
		/// The LocalAlloc() function is called to allocate memory for pvData. *pvData is updated with a pointer to the allocated memory.
		/// LocalFree() must be called to free the allocated memory.
		/// </term>
		/// </item>
		/// </list>
		/// <para>
		/// A pointer to the name of a remote computer to be searched. If CRYPT_KEYID_MACHINE_FLAG flag is set, searches the remote computer
		/// for a list of key identifiers. If the local computer is to be searched and not a remote computer, set pwszComputerName to <c>NULL</c>.
		/// </para>
		/// <para>Reserved for future use and must be <c>NULL</c>.</para>
		/// <para>
		/// A pointer to a buffer to receive the data as determined by dwPropId. Elements pointed to by fields in the pvData structure
		/// follow the structure. Therefore, the size contained in pcbData can exceed the size of the structure.
		/// </para>
		/// <para>
		/// If dwPropId is CERT_KEY_PROV_INFO_PROP_ID, pvData points to a CRYPT_KEY_PROV_INFO structure that contains the property of the
		/// key identifier.
		/// </para>
		/// <para>
		/// If dwPropId is not CERT_KEY_PROV_INFO_PROP_ID, pvData points to an array of bytes that contains the property of the key identifier.
		/// </para>
		/// <para>
		/// To get the size of this information for memory allocation purposes, this parameter can be <c>NULL</c> when the
		/// CRYPT_KEYID_ALLOC_FLAG is not set. For more information, see Retrieving Data of Unknown Length.
		/// </para>
		/// <para>
		/// When the CRYPT_KEYID_ALLOC_FLAG is set, pvData is the address of a pointer to the buffer that will be updated. Because memory is
		/// allocated and its pointer is stored at *pvData, pvData must not be <c>NULL</c>.
		/// </para>
		/// <para>
		/// A pointer to a <c>DWORD</c> that contains the size, in bytes, of the buffer pointed to by the pvData parameter. When the
		/// function returns, the <c>DWORD</c> contains the number of bytes stored in the buffer. The size contained in the variable pointed
		/// to by pcbData can indicate a size larger than the CRYPT_KEY_PROV_INFO structure because the structure can contain pointers to
		/// auxiliary data. This size is the sum of the size needed by the structure and all auxiliary data.
		/// </para>
		/// <para>When the CRYPT_KEYID_ALLOC_FLAG is set, pcbData is the address of a pointer to the <c>DWORD</c> that will be updated.</para>
		/// <para>
		/// <c>Note</c> When processing the data returned in the buffer, applications need to use the actual size of the data returned. The
		/// actual size can be slightly smaller than the size of the buffer specified on input. On input, buffer sizes are usually specified
		/// large enough to ensure that the largest possible output data fits in the buffer. On output, the variable pointed to by this
		/// parameter is updated to reflect the actual size of the data copied to the buffer.
		/// </para>
		/// </summary>
		/// <param name="pKeyIdentifier">A pointer to the CRYPT_HASH_BLOB that contains the key identifier.</param>
		/// <param name="dwPropId">
		/// Identifies the property to retrieve. The value of dwPropId determines the type and content of the pvData parameter. Any
		/// certificate property ID can be used.
		/// </param>
		/// <param name="dwFlags">
		/// <para>The following flags can be used. They can be combined with a bitwise- <c>OR</c> operation.</para>
		/// <list type="table">
		/// <listheader>
		/// <term>Value</term>
		/// <term>Meaning</term>
		/// </listheader>
		/// <item>
		/// <term>CRYPT_KEYID_MACHINE_FLAG</term>
		/// <term>
		/// Search the list of key identifiers of the LocalMachine (if pwszComputerName is NULL) or remote computer (if pwszComputerName is
		/// not NULL). For more information, see pwszComputerName.
		/// </term>
		/// </item>
		/// <item>
		/// <term>CRYPT_KEYID_ALLOC_FLAG</term>
		/// <term>
		/// The LocalAlloc() function is called to allocate memory for pvData. *pvData is updated with a pointer to the allocated memory.
		/// LocalFree() must be called to free the allocated memory.
		/// </term>
		/// </item>
		/// </list>
		/// </param>
		/// <param name="pwszComputerName">
		/// A pointer to the name of a remote computer to be searched. If CRYPT_KEYID_MACHINE_FLAG flag is set, searches the remote computer
		/// for a list of key identifiers. If the local computer is to be searched and not a remote computer, set pwszComputerName to <c>NULL</c>.
		/// </param>
		/// <param name="pvReserved">Reserved for future use and must be <c>NULL</c>.</param>
		/// <param name="pvData">
		/// <para>
		/// A pointer to a buffer to receive the data as determined by dwPropId. Elements pointed to by fields in the pvData structure
		/// follow the structure. Therefore, the size contained in pcbData can exceed the size of the structure.
		/// </para>
		/// <para>
		/// If dwPropId is CERT_KEY_PROV_INFO_PROP_ID, pvData points to a CRYPT_KEY_PROV_INFO structure that contains the property of the
		/// key identifier.
		/// </para>
		/// <para>
		/// If dwPropId is not CERT_KEY_PROV_INFO_PROP_ID, pvData points to an array of bytes that contains the property of the key identifier.
		/// </para>
		/// <para>
		/// To get the size of this information for memory allocation purposes, this parameter can be <c>NULL</c> when the
		/// CRYPT_KEYID_ALLOC_FLAG is not set. For more information, see Retrieving Data of Unknown Length.
		/// </para>
		/// <para>
		/// When the CRYPT_KEYID_ALLOC_FLAG is set, pvData is the address of a pointer to the buffer that will be updated. Because memory is
		/// allocated and its pointer is stored at *pvData, pvData must not be <c>NULL</c>.
		/// </para>
		/// </param>
		/// <param name="pcbData">
		/// <para>
		/// A pointer to a <c>DWORD</c> that contains the size, in bytes, of the buffer pointed to by the pvData parameter. When the
		/// function returns, the <c>DWORD</c> contains the number of bytes stored in the buffer. The size contained in the variable pointed
		/// to by pcbData can indicate a size larger than the CRYPT_KEY_PROV_INFO structure because the structure can contain pointers to
		/// auxiliary data. This size is the sum of the size needed by the structure and all auxiliary data.
		/// </para>
		/// <para>When the CRYPT_KEYID_ALLOC_FLAG is set, pcbData is the address of a pointer to the <c>DWORD</c> that will be updated.</para>
		/// <para>
		/// <c>Note</c> When processing the data returned in the buffer, applications need to use the actual size of the data returned. The
		/// actual size can be slightly smaller than the size of the buffer specified on input. On input, buffer sizes are usually specified
		/// large enough to ensure that the largest possible output data fits in the buffer. On output, the variable pointed to by this
		/// parameter is updated to reflect the actual size of the data copied to the buffer.
		/// </para>
		/// </param>
		/// <returns>
		/// <para>If the function succeeds, the function returns nonzero ( <c>TRUE</c>).</para>
		/// <para>If the function fails, it returns zero ( <c>FALSE</c>). For extended error information, call GetLastError.</para>
		/// </returns>
		// https://docs.microsoft.com/en-us/windows/win32/api/wincrypt/nf-wincrypt-cryptgetkeyidentifierproperty BOOL
		// CryptGetKeyIdentifierProperty( const CRYPT_HASH_BLOB *pKeyIdentifier, DWORD dwPropId, DWORD dwFlags, LPCWSTR pwszComputerName,
		// void *pvReserved, void *pvData, DWORD *pcbData );
		[DllImport(Lib.Crypt32, SetLastError = true, ExactSpelling = true)]
		[PInvokeData("wincrypt.h", MSDNShortId = "bc0511c1-0699-4959-afd7-a838c91c77d5")]
		[return: MarshalAs(UnmanagedType.Bool)]
		public static extern bool CryptGetKeyIdentifierProperty(in CRYPTOAPI_BLOB pKeyIdentifier, uint dwPropId, CryptKeyIdFlags dwFlags,
			[Optional, MarshalAs(UnmanagedType.LPWStr)] string pwszComputerName, [Optional] IntPtr pvReserved, [Out, Optional] IntPtr pvData, ref uint pcbData);

		/// <summary>
		/// <para>A pointer to a CRYPT_HASH_BLOB containing the key identifier.</para>
		/// <para>
		/// Identifies the property to be set. The value of dwPropId determines the type and content of the pvData parameter. Any
		/// certificate property ID can be used. CERT_KEY_PROV_INFO_PROP_ID is the property of most interest.
		/// </para>
		/// <para>The following flags can be set. They can be combined with a bitwise- <c>OR</c> operation.</para>
		/// <list type="table">
		/// <listheader>
		/// <term>Value</term>
		/// <term>Meaning</term>
		/// </listheader>
		/// <item>
		/// <term>CRYPT_KEYID_MACHINE_FLAG</term>
		/// <term>
		/// Sets the property of the LocalMachine (if pwszComputerName is NULL) or remote computer (if pwszComputerName is not NULL). For
		/// more information, see pwszComputerName.
		/// </term>
		/// </item>
		/// <item>
		/// <term>CRYPT_KEYID_DELETE_FLAG</term>
		/// <term>The key identifier and all of its properties are deleted.</term>
		/// </item>
		/// <item>
		/// <term>CRYPT_KEYID_SET_NEW_FLAG</term>
		/// <term>
		/// Sets a new key identifier property. If the property already exists, the attempt fails, and FALSE is returned with the last error
		/// code set to CRYPT_E_EXISTS.
		/// </term>
		/// </item>
		/// </list>
		/// <para>
		/// A pointer to a <c>null</c>-terminated string that contains the name of a remote computer that has the key identifier where the
		/// properties are set. If CRYPT_KEYID_MACHINE_FLAG flag is set, searches the remote computer for a list of key identifiers. If the
		/// local computer is to be set and not a remote computer, set pwszComputerName to <c>NULL</c>.
		/// </para>
		/// <para>Reserved for future use and must be <c>NULL</c>.</para>
		/// <para>
		/// If dwPropId is CERT_KEY_PROV_INFO_PROP_ID, pvData points to a CRYPT_KEY_PROV_INFO structure containing the property of the key identifier.
		/// </para>
		/// <para>
		/// If dwPropId is not CERT_KEY_PROV_INFO_PROP_ID, pvData points to a CRYPT_DATA_BLOB structure containing the property of the key identifier.
		/// </para>
		/// <para>Setting pvData to <c>NULL</c> deletes the property.</para>
		/// </summary>
		/// <param name="pKeyIdentifier">A pointer to a CRYPT_HASH_BLOB containing the key identifier.</param>
		/// <param name="dwPropId">
		/// Identifies the property to be set. The value of dwPropId determines the type and content of the pvData parameter. Any
		/// certificate property ID can be used. CERT_KEY_PROV_INFO_PROP_ID is the property of most interest.
		/// </param>
		/// <param name="dwFlags">
		/// <para>The following flags can be set. They can be combined with a bitwise- <c>OR</c> operation.</para>
		/// <list type="table">
		/// <listheader>
		/// <term>Value</term>
		/// <term>Meaning</term>
		/// </listheader>
		/// <item>
		/// <term>CRYPT_KEYID_MACHINE_FLAG</term>
		/// <term>
		/// Sets the property of the LocalMachine (if pwszComputerName is NULL) or remote computer (if pwszComputerName is not NULL). For
		/// more information, see pwszComputerName.
		/// </term>
		/// </item>
		/// <item>
		/// <term>CRYPT_KEYID_DELETE_FLAG</term>
		/// <term>The key identifier and all of its properties are deleted.</term>
		/// </item>
		/// <item>
		/// <term>CRYPT_KEYID_SET_NEW_FLAG</term>
		/// <term>
		/// Sets a new key identifier property. If the property already exists, the attempt fails, and FALSE is returned with the last error
		/// code set to CRYPT_E_EXISTS.
		/// </term>
		/// </item>
		/// </list>
		/// </param>
		/// <param name="pwszComputerName">
		/// A pointer to a <c>null</c>-terminated string that contains the name of a remote computer that has the key identifier where the
		/// properties are set. If CRYPT_KEYID_MACHINE_FLAG flag is set, searches the remote computer for a list of key identifiers. If the
		/// local computer is to be set and not a remote computer, set pwszComputerName to <c>NULL</c>.
		/// </param>
		/// <param name="pvReserved">Reserved for future use and must be <c>NULL</c>.</param>
		/// <param name="pvData">
		/// <para>
		/// If dwPropId is CERT_KEY_PROV_INFO_PROP_ID, pvData points to a CRYPT_KEY_PROV_INFO structure containing the property of the key identifier.
		/// </para>
		/// <para>
		/// If dwPropId is not CERT_KEY_PROV_INFO_PROP_ID, pvData points to a CRYPT_DATA_BLOB structure containing the property of the key identifier.
		/// </para>
		/// <para>Setting pvData to <c>NULL</c> deletes the property.</para>
		/// </param>
		/// <returns>
		/// <para>If the function succeeds, the return value is nonzero (TRUE).</para>
		/// <para>If the function fails, the return value is zero ( <c>FALSE</c>). For extended error information, call GetLastError.</para>
		/// <para>
		/// <c>Note</c> If CRYPT_KEYID_SET_NEW_FLAG is set and the property already exists, <c>FALSE</c> is returned with the last error
		/// code set to CRYPT_E_EXISTS.
		/// </para>
		/// </returns>
		// https://docs.microsoft.com/en-us/windows/win32/api/wincrypt/nf-wincrypt-cryptsetkeyidentifierproperty BOOL
		// CryptSetKeyIdentifierProperty( const CRYPT_HASH_BLOB *pKeyIdentifier, DWORD dwPropId, DWORD dwFlags, LPCWSTR pwszComputerName,
		// void *pvReserved, const void *pvData );
		[DllImport(Lib.Crypt32, SetLastError = true, ExactSpelling = true)]
		[PInvokeData("wincrypt.h", MSDNShortId = "0970aaaa-3f9a-4471-bd21-5de8746f94a2")]
		[return: MarshalAs(UnmanagedType.Bool)]
		public static extern bool CryptSetKeyIdentifierProperty(in CRYPTOAPI_BLOB pKeyIdentifier, uint dwPropId, CryptKeyIdFlags dwFlags,
			[Optional, MarshalAs(UnmanagedType.LPWStr)] string pwszComputerName, [Optional] IntPtr pvReserved, [In, Optional] IntPtr pvData);

		/// <summary>
		/// <para>
		/// The <c>PUBLICKEYSTRUC</c> structure, also known as the <c>BLOBHEADER</c> structure, indicates a key's BLOB type and the
		/// algorithm that the key uses. One of these structures is located at the beginning of the <c>pbData</c> member of every key BLOB.
		/// </para>
		/// <para>
		/// This structure is not limited to the key BLOBs generated by the PROV_RSA_BASE and PROV_RSA_SIG provider types. The <c>pbData</c>
		/// member of any new key BLOB type must begin with this structure.
		/// </para>
		/// </summary>
		// https://docs.microsoft.com/en-us/windows/win32/api/wincrypt/ns-wincrypt-publickeystruc typedef struct _PUBLICKEYSTRUC { BYTE
		// bType; BYTE bVersion; WORD reserved; ALG_ID aiKeyAlg; } BLOBHEADER, PUBLICKEYSTRUC;
		[PInvokeData("wincrypt.h", MSDNShortId = "99d41222-b4ca-40f3-a240-52b0a9b3a9aa")]
		[StructLayout(LayoutKind.Sequential)]
		public struct PUBLICKEYSTRUC
		{
			private byte _bType;

			/// <summary>
			/// <para>Contains the key BLOB type.</para>
			/// <para>
			/// The following are the predefined values for this member. Cryptographic service providers (CSPs) can use other type
			/// identifiers as needed.
			/// </para>
			/// <list type="table">
			/// <listheader>
			/// <term>Value</term>
			/// <term>Meaning</term>
			/// </listheader>
			/// <item>
			/// <term>KEYSTATEBLOB 0xC</term>
			/// <term>The BLOB is a key state BLOB.</term>
			/// </item>
			/// <item>
			/// <term>OPAQUEKEYBLOB 0x9</term>
			/// <term>The key is a session key.</term>
			/// </item>
			/// <item>
			/// <term>PLAINTEXTKEYBLOB 0x8</term>
			/// <term>The key is a session key.</term>
			/// </item>
			/// <item>
			/// <term>PRIVATEKEYBLOB 0x7</term>
			/// <term>The key is a public/private key pair.</term>
			/// </item>
			/// <item>
			/// <term>PUBLICKEYBLOB 0x6</term>
			/// <term>The key is a public key.</term>
			/// </item>
			/// <item>
			/// <term>PUBLICKEYBLOBEX 0xA</term>
			/// <term>The key is a public key.</term>
			/// </item>
			/// <item>
			/// <term>SIMPLEBLOB 0x1</term>
			/// <term>The key is a session key.</term>
			/// </item>
			/// <item>
			/// <term>SYMMETRICWRAPKEYBLOB 0xB</term>
			/// <term>The key is a symmetric key.</term>
			/// </item>
			/// </list>
			/// </summary>
			public BlobType bType { get => (BlobType)_bType; set => _bType = (byte)bType; }

			/// <summary>
			/// Contains the version number of the key BLOB format. For example, if the BLOB is a Digital Signature Standard (DSS) version 3
			/// key, this member will contain 3. The minimum value for this member is defined by the <c>CUR_BLOB_VERSION</c> (2) identifier.
			/// </summary>
			public byte bVersion;

			/// <summary>This member is reserved for future use and must be set to zero.</summary>
			public ushort reserved;

			/// <summary>
			/// <para>Contains one of the ALG_ID values that identifies the algorithm of the key contained by the key BLOB.</para>
			/// <para>
			/// Not all algorithm identifiers are valid with all BLOB types. For example, since an RC4 key is a session key, it cannot be
			/// exported into a PUBLICKEYBLOB.
			/// </para>
			/// <para>
			/// PLAINTEXTBLOBs can be used with any algorithm or type of key combination supported by the CSP in use. Note that a 3DES key
			/// cannot be imported when the Microsoft Base Provider is in use.
			/// </para>
			/// </summary>
			public ALG_ID aiKeyAlg;
		}
	}
}