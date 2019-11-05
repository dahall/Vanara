using System;
using System.Runtime.InteropServices;
using static Vanara.PInvoke.Crypt32;

namespace Vanara.PInvoke
{
	public static partial class WinTrust
	{
		/// <summary>
		/// The <c>PFN_CDF_PARSE_ERROR_CALLBACK</c> function is called for Catalog Definition Function errors while parsing a catalog
		/// definition file (CDF).
		/// </summary>
		/// <param name="dwErrorArea">A value that indicates in which area of the CDF the error occurred.</param>
		/// <param name="dwLocalError">A value that indicates the type of error.</param>
		/// <param name="pwszLine"/>
		/// <returns>This callback function does not return a value.</returns>
		/// <remarks>
		/// <para>The dwErrorArea parameter can have the following possible values.</para>
		/// <list type="table">
		/// <listheader>
		/// <term>Value</term>
		/// <term>Description</term>
		/// </listheader>
		/// <item>
		/// <term>CRYPTCAT_E_AREA_HEADER</term>
		/// <term>The header section of the CDF</term>
		/// </item>
		/// <item>
		/// <term>CRYPTCAT_E_AREA_MEMBER</term>
		/// <term>A member file entry in the CatalogFiles section of the CDF</term>
		/// </item>
		/// <item>
		/// <term>CRYPTCAT_E_AREA_ATTRIBUTE</term>
		/// <term>An attribute entry in the CDF</term>
		/// </item>
		/// </list>
		/// <para>The dwLocalError parameter can have the following possible values.</para>
		/// <list type="table">
		/// <listheader>
		/// <term>Value</term>
		/// <term>Description</term>
		/// </listheader>
		/// <item>
		/// <term>CRYPTCAT_E_CDF_UNSUPPORTED</term>
		/// <term>The function does not support the attribute.</term>
		/// </item>
		/// <item>
		/// <term>CRYPTCAT_E_CDF_DUPLICATE</term>
		/// <term>The file member already exists.</term>
		/// </item>
		/// <item>
		/// <term>CRYPTCAT_E_CDF_TAGNOTFOUND</term>
		/// <term>The CatalogHeader or Name tag is missing.</term>
		/// </item>
		/// <item>
		/// <term>CRYPTCAT_E_CDF_MEMBER_FILE_PATH</term>
		/// <term>The member file name or path is missing.</term>
		/// </item>
		/// <item>
		/// <term>CRYPTCAT_E_CDF_MEMBER_INDIRECTDATA</term>
		/// <term>The function failed to create a hash of the member subject.</term>
		/// </item>
		/// <item>
		/// <term>CRYPTCAT_E_CDF_MEMBER_FILENOTFOUND</term>
		/// <term>The function failed to find the member file.</term>
		/// </item>
		/// <item>
		/// <term>CRYPTCAT_E_CDF_BAD_GUID_CONV</term>
		/// <term>The function failed to convert the subject string to a GUID.</term>
		/// </item>
		/// <item>
		/// <term>CRYPTCAT_E_CDF_ATTR_TOOFEWVALUES</term>
		/// <term>
		/// The attribute line is missing one or more elements of its composition including type, object identifier (OID) or name, or value.
		/// </term>
		/// </item>
		/// <item>
		/// <term>CRYPTCAT_E_CDF_ATTR_TYPECOMBO</term>
		/// <term>The attribute contains an invalid OID, or the combination of type, name or OID, and value is not valid.</term>
		/// </item>
		/// </list>
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows/win32/api/mscat/nc-mscat-pfn_cdf_parse_error_callback PFN_CDF_PARSE_ERROR_CALLBACK
		// PfnCdfParseErrorCallback; void PfnCdfParseErrorCallback( IN DWORD dwErrorArea, IN DWORD dwLocalError, IN WCHAR *pwszLine ) {...}
		[PInvokeData("mscat.h", MSDNShortId = "94c12ad7-dcb0-4099-8eba-da38367f0d79")]
		[UnmanagedFunctionPointer(CallingConvention.Winapi)]
		public delegate void PfnCdfParseErrorCallback(CRYPTCAT_E dwErrorArea, CRYPTCAT_E dwLocalError, [In, MarshalAs(UnmanagedType.LPWStr)] string pwszLine);

		/// <summary>CRYPTCATATTRIBUTE attributes and actions.</summary>
		[PInvokeData("mscat.h", MSDNShortId = "41b91303-f3eb-4288-9ad2-98f170680988")]
		[Flags]
		public enum CRYPTCAT_ATTR : uint
		{
			/// <summary>The attribute is authenticated.</summary>
			CRYPTCAT_ATTR_AUTHENTICATED = 0x10000000,

			/// <summary>The attribute is unauthenticated.</summary>
			CRYPTCAT_ATTR_UNAUTHENTICATED = 0x20000000,

			/// <summary>The attribute is an ASCII string.</summary>
			CRYPTCAT_ATTR_NAMEASCII = 0x00000001,

			/// <summary>The attribute is a cryptographic object identifier (OID).</summary>
			CRYPTCAT_ATTR_NAMEOBJID = 0x00000002,

			/// <summary>The attribute contains simple ASCII characters that should not be decoded.</summary>
			CRYPTCAT_ATTR_DATAASCII = 0x00010000,

			/// <summary>The attribute is in base 64 format.</summary>
			CRYPTCAT_ATTR_DATABASE64 = 0x00020000,

			/// <summary>The attribute replaces the value for an existing attribute.</summary>
			CRYPTCAT_ATTR_DATAREPLACE = 0x00040000,
		}

		/// <summary>Errors used by <see cref="PfnCdfParseErrorCallback"/>.</summary>
		[PInvokeData("mscat.h", MSDNShortId = "94c12ad7-dcb0-4099-8eba-da38367f0d79")]
		public enum CRYPTCAT_E
		{
			/// <summary>The header section of the CDF</summary>
			CRYPTCAT_E_AREA_HEADER = 0x00000000,

			/// <summary>A member file entry in the CatalogFiles section of the CDF</summary>
			CRYPTCAT_E_AREA_MEMBER = 0x00010000,

			/// <summary>An attribute entry in the CDF</summary>
			CRYPTCAT_E_AREA_ATTRIBUTE = 0x00020000,

			/// <summary>The function does not support the attribute.</summary>
			CRYPTCAT_E_CDF_UNSUPPORTED = 0x00000001,

			/// <summary>The file member already exists.</summary>
			CRYPTCAT_E_CDF_DUPLICATE = 0x00000002,

			/// <summary>The CatalogHeader or Name tag is missing.</summary>
			CRYPTCAT_E_CDF_TAGNOTFOUND = 0x00000004,

			/// <summary>The member file name or path is missing.</summary>
			CRYPTCAT_E_CDF_MEMBER_FILE_PATH = 0x00010001,

			/// <summary>The function failed to create a hash of the member subject.</summary>
			CRYPTCAT_E_CDF_MEMBER_INDIRECTDATA = 0x00010002,

			/// <summary>The function failed to find the member file.</summary>
			CRYPTCAT_E_CDF_MEMBER_FILENOTFOUND = 0x00010004,

			/// <summary>The function failed to convert the subject string to a GUID.</summary>
			CRYPTCAT_E_CDF_BAD_GUID_CONV = 0x00020001,

			/// <summary>
			/// The attribute line is missing one or more elements of its composition including type, object identifier (OID) or name, or value.
			/// </summary>
			CRYPTCAT_E_CDF_ATTR_TOOFEWVALUES = 0x00020002,

			/// <summary>The attribute contains an invalid OID, or the combination of type, name or OID, and value is not valid.</summary>
			CRYPTCAT_E_CDF_ATTR_TYPECOMBO = 0x00020004,
		}

		/// <summary>Flags used by CRYPTCATSTORE.</summary>
		[PInvokeData("mscat.h", MSDNShortId = "65a15797-453c-4f47-8ea1-c92e616b50aa")]
		[Flags]
		public enum CRYPTCAT_OPEN : uint
		{
			/// <summary>Exclude page hashes in SPC_INDIRECT_DATA.</summary>
			CRYPTCAT_OPEN_EXCLUDE_PAGE_HASHES = 0x00010000,

			/// <summary>For all flags with a value in the upper word, set or clear the flag.</summary>
			CRYPTCAT_OPEN_FLAGS_MASK = 0xffff0000,

			/// <summary>
			/// Include page hashes in SPC_INDIRECT_DATA. The CRYPTCAT_OPEN_EXCLUDE_PAGE_HASHES flag takes precedence if it is also set.
			/// </summary>
			CRYPTCAT_OPEN_INCLUDE_PAGE_HASHES = 0x00020000,

			/// <summary>Open the file for decoding without detached content.</summary>
			CRYPTCAT_OPEN_NO_CONTENT_HCRYPTMSG = 0x20000000,

			/// <summary>Open the catalog with the entries sorted alphabetically by subject.</summary>
			CRYPTCAT_OPEN_SORTED = 0x40000000,

			/// <summary>Verify the signature hash but not the certificate chain.</summary>
			CRYPTCAT_OPEN_VERIFYSIGHASH = 0x10000000,
		}

		/// <summary>
		/// <para>
		/// [The <c>CryptCATAdminAcquireContext</c> function is available for use in the operating systems specified in the Requirements
		/// section. It may be altered or unavailable in subsequent versions.]
		/// </para>
		/// <para>
		/// The <c>CryptCATAdminAcquireContext</c> function acquires a handle to a catalog administrator context. This handle can be used by
		/// subsequent calls to the CryptCATAdminAddCatalog, CryptCATAdminEnumCatalogFromHash, and CryptCATAdminRemoveCatalog functions.
		/// This function has no associated import library. You must use the LoadLibrary and GetProcAddress functions to dynamically link to Wintrust.dll.
		/// </para>
		/// </summary>
		/// <param name="phCatAdmin">
		/// A pointer to the catalog administrator context handle that is assigned by this function. When you have finished using the
		/// handle, close it by calling the CryptCATAdminReleaseContext function.
		/// </param>
		/// <param name="pgSubsystem">
		/// A pointer to the GUID that identifies the subsystem. DRIVER_ACTION_VERIFY represents the subsystem for operating system
		/// components and third party drivers. This is the subsystem used by most implementations.
		/// </param>
		/// <param name="dwFlags">Not used; set to zero.</param>
		/// <returns>
		/// <para>The return value is <c>TRUE</c> if the function succeeds; <c>FALSE</c> if the function fails.</para>
		/// <para>
		/// For extended error information, call the GetLastError function. For a complete list of error codes provided by the operating
		/// system, see System Error Codes.
		/// </para>
		/// </returns>
		// https://docs.microsoft.com/en-us/windows/win32/api/mscat/nf-mscat-cryptcatadminacquirecontext BOOL CryptCATAdminAcquireContext(
		// HCATADMIN *phCatAdmin, const GUID *pgSubsystem, DWORD dwFlags );
		[DllImport(Lib.Wintrust, SetLastError = true, ExactSpelling = true)]
		[PInvokeData("mscat.h", MSDNShortId = "693af055-fa93-4526-aa9c-3a659f8ff78f")]
		[return: MarshalAs(UnmanagedType.Bool)]
		public static extern bool CryptCATAdminAcquireContext(out SafeHCATADMIN phCatAdmin, in Guid pgSubsystem, uint dwFlags = 0);

		/// <summary>
		/// <para>
		/// The <c>CryptCATAdminAcquireContext2</c> function acquires a handle to a catalog administrator context for a given hash algorithm
		/// and hash policy.
		/// </para>
		/// <para>You can use this handle in subsequent calls to the following functions:</para>
		/// <list type="bullet">
		/// <item>
		/// <term>CryptCATAdminAddCatalog</term>
		/// </item>
		/// <item>
		/// <term>CryptCATAdminEnumCatalogFromHash</term>
		/// </item>
		/// <item>
		/// <term>CryptCATAdminRemoveCatalog</term>
		/// </item>
		/// </list>
		/// <para>
		/// This function has no associated import library. You must use the LoadLibrary and GetProcAddress functions to dynamically link to Wintrust.dll.
		/// </para>
		/// </summary>
		/// <param name="phCatAdmin">
		/// A pointer to the catalog administrator context handle that is assigned by this function. When you have finished using the
		/// handle, close it by calling the CryptCATAdminReleaseContext function.
		/// </param>
		/// <param name="pgSubsystem">
		/// A pointer to the <c>GUID</c> that identifies the subsystem. DRIVER_ACTION_VERIFY represents the subsystem for operating system
		/// components and third party drivers. This is the subsystem used by most implementations.
		/// </param>
		/// <param name="pwszHashAlgorithm">
		/// Optional null-terminated Unicode string that specifies the name of the hash algorithm to use when calculating and verifying
		/// hashes. This value can be <c>NULL</c>. If it is <c>NULL</c>, the default hashing algorithm may be chosen, depending on the value
		/// you set for the pStrongHashPolicy parameter. The default algorithm in Windows 8 is SHA1. The default may change in future
		/// Windows versions. For more information, see Remarks.
		/// </param>
		/// <param name="pStrongHashPolicy">
		/// Pointer to a CERT_STRONG_SIGN_PARA structure that contains the parameters used to check for strong signatures. The function
		/// chooses the lowest common hashing algorithm that satisfies the specified policy and the algorithm specified by the
		/// pwszHashAlgorithm parameter or the system default algorithm (if no algorithm is specified).
		/// </param>
		/// <param name="dwFlags">Reserved. This value must be zero.</param>
		/// <returns>
		/// <para>If the function succeeds, the return value is nonzero ( <c>TRUE</c>).</para>
		/// <para>If the function fails, the return value is zero ( <c>FALSE</c>). For extended error information, call GetLastError.</para>
		/// <para>The following table lists the error codes most commonly returned by the GetLastError function.</para>
		/// <list type="table">
		/// <listheader>
		/// <term>Return code</term>
		/// <term>Description</term>
		/// </listheader>
		/// <item>
		/// <term>ERROR_INVALID_PARAMETER</term>
		/// <term>The phCatAdmin parameter cannot be NULL. The dwFlags parameter must be zero (0).</term>
		/// </item>
		/// <item>
		/// <term>ERROR_NOT_ENOUGH_MEMORY</term>
		/// <term>There was insufficient memory to create a new catalog administrator object.</term>
		/// </item>
		/// <item>
		/// <term>NTE_BAD_ALGID</term>
		/// <term>The hash algorithm specified by the pwszHashAlgorithm parameter cannot be found.</term>
		/// </item>
		/// </list>
		/// </returns>
		/// <remarks>
		/// This function enables you to choose, or chooses for you, the hash algorithm to be used in functions that require the catalog
		/// administrator context. Although you can set the name of the hashing algorithm, we recommend that you let the function determine
		/// the algorithm. Doing so protects your application from hard coding algorithms that may become untrusted in the future.
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows/win32/api/mscat/nf-mscat-cryptcatadminacquirecontext2 BOOL CryptCATAdminAcquireContext2(
		// HCATADMIN *phCatAdmin, const GUID *pgSubsystem, PCWSTR pwszHashAlgorithm, PCCERT_STRONG_SIGN_PARA pStrongHashPolicy, DWORD
		// dwFlags );
		[DllImport(Lib.Wintrust, SetLastError = true, ExactSpelling = true)]
		[PInvokeData("mscat.h", MSDNShortId = "B089217A-5C12-4C51-8E46-3A9243347B21")]
		[return: MarshalAs(UnmanagedType.Bool)]
		public static extern bool CryptCATAdminAcquireContext2(out SafeHCATADMIN phCatAdmin, in Guid pgSubsystem, [MarshalAs(UnmanagedType.LPWStr), Optional] string pwszHashAlgorithm, in CERT_STRONG_SIGN_PARA pStrongHashPolicy, uint dwFlags = 0);

		/// <summary>
		/// <para>
		/// The <c>CryptCATAdminAcquireContext2</c> function acquires a handle to a catalog administrator context for a given hash algorithm
		/// and hash policy.
		/// </para>
		/// <para>You can use this handle in subsequent calls to the following functions:</para>
		/// <list type="bullet">
		/// <item>
		/// <term>CryptCATAdminAddCatalog</term>
		/// </item>
		/// <item>
		/// <term>CryptCATAdminEnumCatalogFromHash</term>
		/// </item>
		/// <item>
		/// <term>CryptCATAdminRemoveCatalog</term>
		/// </item>
		/// </list>
		/// <para>
		/// This function has no associated import library. You must use the LoadLibrary and GetProcAddress functions to dynamically link to Wintrust.dll.
		/// </para>
		/// </summary>
		/// <param name="phCatAdmin">
		/// A pointer to the catalog administrator context handle that is assigned by this function. When you have finished using the
		/// handle, close it by calling the CryptCATAdminReleaseContext function.
		/// </param>
		/// <param name="pgSubsystem">
		/// A pointer to the <c>GUID</c> that identifies the subsystem. DRIVER_ACTION_VERIFY represents the subsystem for operating system
		/// components and third party drivers. This is the subsystem used by most implementations.
		/// </param>
		/// <param name="pwszHashAlgorithm">
		/// Optional null-terminated Unicode string that specifies the name of the hash algorithm to use when calculating and verifying
		/// hashes. This value can be <c>NULL</c>. If it is <c>NULL</c>, the default hashing algorithm may be chosen, depending on the value
		/// you set for the pStrongHashPolicy parameter. The default algorithm in Windows 8 is SHA1. The default may change in future
		/// Windows versions. For more information, see Remarks.
		/// </param>
		/// <param name="pStrongHashPolicy">
		/// Pointer to a CERT_STRONG_SIGN_PARA structure that contains the parameters used to check for strong signatures. The function
		/// chooses the lowest common hashing algorithm that satisfies the specified policy and the algorithm specified by the
		/// pwszHashAlgorithm parameter or the system default algorithm (if no algorithm is specified).
		/// </param>
		/// <param name="dwFlags">Reserved. This value must be zero.</param>
		/// <returns>
		/// <para>If the function succeeds, the return value is nonzero ( <c>TRUE</c>).</para>
		/// <para>If the function fails, the return value is zero ( <c>FALSE</c>). For extended error information, call GetLastError.</para>
		/// <para>The following table lists the error codes most commonly returned by the GetLastError function.</para>
		/// <list type="table">
		/// <listheader>
		/// <term>Return code</term>
		/// <term>Description</term>
		/// </listheader>
		/// <item>
		/// <term>ERROR_INVALID_PARAMETER</term>
		/// <term>The phCatAdmin parameter cannot be NULL. The dwFlags parameter must be zero (0).</term>
		/// </item>
		/// <item>
		/// <term>ERROR_NOT_ENOUGH_MEMORY</term>
		/// <term>There was insufficient memory to create a new catalog administrator object.</term>
		/// </item>
		/// <item>
		/// <term>NTE_BAD_ALGID</term>
		/// <term>The hash algorithm specified by the pwszHashAlgorithm parameter cannot be found.</term>
		/// </item>
		/// </list>
		/// </returns>
		/// <remarks>
		/// This function enables you to choose, or chooses for you, the hash algorithm to be used in functions that require the catalog
		/// administrator context. Although you can set the name of the hashing algorithm, we recommend that you let the function determine
		/// the algorithm. Doing so protects your application from hard coding algorithms that may become untrusted in the future.
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows/win32/api/mscat/nf-mscat-cryptcatadminacquirecontext2 BOOL CryptCATAdminAcquireContext2(
		// HCATADMIN *phCatAdmin, const GUID *pgSubsystem, PCWSTR pwszHashAlgorithm, PCCERT_STRONG_SIGN_PARA pStrongHashPolicy, DWORD
		// dwFlags );
		[DllImport(Lib.Wintrust, SetLastError = true, ExactSpelling = true)]
		[PInvokeData("mscat.h", MSDNShortId = "B089217A-5C12-4C51-8E46-3A9243347B21")]
		[return: MarshalAs(UnmanagedType.Bool)]
		public static extern bool CryptCATAdminAcquireContext2(out SafeHCATADMIN phCatAdmin, [Optional] IntPtr pgSubsystem, [MarshalAs(UnmanagedType.LPWStr), Optional] string pwszHashAlgorithm, [Optional] IntPtr pStrongHashPolicy, uint dwFlags = 0);

		/// <summary>
		/// <para>
		/// [The <c>CryptCATAdminAddCatalog</c> function is available for use in the operating systems specified in the Requirements
		/// section. It may be altered or unavailable in subsequent versions.]
		/// </para>
		/// <para>
		/// The <c>CryptCATAdminAddCatalog</c> function adds a catalog to the catalog database. The catalog database is an index that
		/// associates file hashes with the catalogs that contain them. It is used to speed the identification of the catalogs when
		/// verifying the file signature. This function is the only supported way to programmatically add catalogs to the Windows catalog
		/// database. The function has no associated import library. You must use the LoadLibrary and GetProcAddress functions to
		/// dynamically link to Wintrust.dll.
		/// </para>
		/// </summary>
		/// <param name="hCatAdmin">Handle previously assigned by the CryptCATAdminAcquireContext function.</param>
		/// <param name="pwszCatalogFile">
		/// A pointer to a <c>null</c>-terminated string for the fully qualified path of the catalog to be added.
		/// </param>
		/// <param name="pwszSelectBaseName">
		/// A pointer to a <c>null</c>-terminated string for the name of the catalog when it is stored. If the parameter is <c>NULL</c>,
		/// then a unique name will be generated for the catalog.
		/// </param>
		/// <param name="dwFlags">
		/// If the CRYPTCAT_ADDCATALOG_HARDLINK (0x00000001) flag is specified, the catalog specified in the call will be hard-linked to
		/// rather than copied. Hard-linking instead of copying a catalog reduces the amount of disk space required by Windows.
		/// </param>
		/// <returns>
		/// <para>
		/// If the function succeeds, the return value is a handle to the catalog information context. If the function fails, the return
		/// value is <c>NULL</c>. After you have finished using the returned handle, free it by calling the
		/// CryptCATAdminReleaseCatalogContext function.
		/// </para>
		/// <para>
		/// For extended error information, call the GetLastError function. For a complete list of error codes provided by the operating
		/// system, see System Error Codes.
		/// </para>
		/// </returns>
		// https://docs.microsoft.com/en-us/windows/win32/api/mscat/nf-mscat-cryptcatadminaddcatalog HCATINFO CryptCATAdminAddCatalog(
		// HCATADMIN hCatAdmin, PWSTR pwszCatalogFile, PWSTR pwszSelectBaseName, DWORD dwFlags );
		[PInvokeData("mscat.h", MSDNShortId = "a227597c-a0af-4b86-bd29-03f478aef244")]
		public static SafeHCATINFO CryptCATAdminAddCatalog(SafeHCATADMIN hCatAdmin, [MarshalAs(UnmanagedType.LPWStr)] string pwszCatalogFile, [MarshalAs(UnmanagedType.LPWStr), Optional] string pwszSelectBaseName, uint dwFlags) =>
			new SafeHCATINFO(InternalCryptCATAdminAddCatalog(hCatAdmin, pwszCatalogFile, pwszSelectBaseName, dwFlags), hCatAdmin, true);

		/// <summary>
		/// <para>
		/// [The <c>CryptCATAdminCalcHashFromFileHandle</c> function is available for use in the operating systems specified in the
		/// Requirements section. It may be altered or unavailable in subsequent versions.]
		/// </para>
		/// <para>
		/// The <c>CryptCATAdminCalcHashFromFileHandle</c> function calculates the hash for a file. This function has no associated import
		/// library. You must use the LoadLibrary and GetProcAddress functions to dynamically link to Wintrust.dll.
		/// </para>
		/// </summary>
		/// <param name="hFile">
		/// A handle to the file whose hash is being calculated. This parameter cannot be <c>NULL</c> and must be a valid file handle.
		/// </param>
		/// <param name="pcbHash">
		/// A pointer to a <c>DWORD</c> variable that contains the number of bytes in pbHash. Upon input, set pcbHash to the number of bytes
		/// allocated for pbHash. Upon return, pcbHash contains the number of returned bytes in pbHash. If pbHash is passed as <c>NULL</c>,
		/// then pcbHash contains the number of bytes to allocate for pbHash.
		/// </param>
		/// <param name="pbHash">
		/// A pointer to a <c>BYTE</c> buffer that receives the hash. If this parameter is passed in as <c>NULL</c>, then pcbHash contains
		/// the number of bytes to allocate for pbHash, and a subsequent call can be made to retrieve the hash.
		/// </param>
		/// <param name="dwFlags">This parameter is reserved for future use and must be set to zero.</param>
		/// <returns>
		/// The return value is <c>TRUE</c> if the function succeeds; <c>FALSE</c> if the function fails. If <c>FALSE</c> is returned, call
		/// the <c>GetLastError</c> function to determine the reason for failure. If not enough memory has been allocated for pbHash, the
		/// <c>CryptCATAdminCalcHashFromFileHandle</c> function will set the last error to ERROR_INSUFFICIENT_BUFFER.
		/// </returns>
		// https://docs.microsoft.com/en-us/windows/win32/api/mscat/nf-mscat-cryptcatadmincalchashfromfilehandle BOOL
		// CryptCATAdminCalcHashFromFileHandle( HANDLE hFile, DWORD *pcbHash, BYTE *pbHash, DWORD dwFlags );
		[DllImport(Lib.Wintrust, SetLastError = true, ExactSpelling = true)]
		[PInvokeData("mscat.h", MSDNShortId = "4dc5688f-4b7a-4baf-9671-868cac7f1896")]
		[return: MarshalAs(UnmanagedType.Bool)]
		public static extern bool CryptCATAdminCalcHashFromFileHandle(HFILE hFile, ref uint pcbHash, IntPtr pbHash, uint dwFlags = 0);

		/// <summary>
		/// <para>The <c>CryptCATAdminCalcHashFromFileHandle2</c> function calculates the hash for a file by using the specified algorithm.</para>
		/// <para>
		/// This function has no associated import library. You must use the LoadLibrary and GetProcAddress functions to dynamically link to Wintrust.dll.
		/// </para>
		/// </summary>
		/// <param name="hCatAdmin">Handle of an open catalog administrator context. For more information, see CryptCATAdminAcquireContext2.</param>
		/// <param name="hFile">
		/// A handle to the file whose hash is being calculated. This parameter cannot be <c>NULL</c> and must be a valid file handle.
		/// </param>
		/// <param name="pcbHash">
		/// Pointer to a <c>DWORD</c> variable that contains the number of bytes in the pbHash parameter. Upon input, set pcbHash to the
		/// number of bytes allocated for pbHash. Upon return, pcbHash contains the number of returned bytes in pbHash. If pbHash is set to
		/// <c>NULL</c>, then pcbHash contains the number of bytes to allocate for pbHash.
		/// </param>
		/// <param name="pbHash">
		/// Pointer to a <c>BYTE</c> buffer that receives the hash. If you set this parameter to <c>NULL</c>, then pcbHash will contain the
		/// number of bytes to allocate for pbHash, and a subsequent call can be made to retrieve the hash.
		/// </param>
		/// <param name="dwFlags">Reserved. This value must be zero.</param>
		/// <returns>
		/// <para>If the function succeeds, the return value is nonzero ( <c>TRUE</c>).</para>
		/// <para>If the function fails, the return value is zero ( <c>FALSE</c>). For extended error information, call GetLastError.</para>
		/// <para>The following table lists the error codes most commonly returned by the GetLastError function.</para>
		/// <list type="table">
		/// <listheader>
		/// <term>Return code</term>
		/// <term>Description</term>
		/// </listheader>
		/// <item>
		/// <term>ERROR_INVALID_PARAMETER</term>
		/// <term>
		/// The hFile parameter must not be NULL. The hFile parameter must be a valid file handle. The pcbHash parameter must not be NULL.
		/// The dwFlags parameter must be zero (0).
		/// </term>
		/// </item>
		/// <item>
		/// <term>ERROR_INSUFFICIENT_BUFFER</term>
		/// <term>
		/// The buffer pointed to by the pbHash parameter was not NULL but was not large enough to be written. The correct size of the
		/// required buffer is contained in the value pointed to by the pcbHash parameter.
		/// </term>
		/// </item>
		/// <item>
		/// <term>NTE_BAD_ALGID</term>
		/// <term>The hash algorithm specified by the pwszHashAlgorithm parameter cannot be found.</term>
		/// </item>
		/// </list>
		/// </returns>
		/// <remarks>
		/// The amount of time this function takes to execute depends on the length of the file being hashed, the algorithm being used, and
		/// the file location. For example, it takes several seconds to calculate the hash of a local file that is very large (a few hundred megabytes).
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows/win32/api/mscat/nf-mscat-cryptcatadmincalchashfromfilehandle2 BOOL
		// CryptCATAdminCalcHashFromFileHandle2( HCATADMIN hCatAdmin, HANDLE hFile, DWORD *pcbHash, BYTE *pbHash, DWORD dwFlags );
		[DllImport(Lib.Wintrust, SetLastError = true, ExactSpelling = true)]
		[PInvokeData("mscat.h", MSDNShortId = "CBFA60A8-5E5A-4FAD-8AD3-26539802CD53")]
		[return: MarshalAs(UnmanagedType.Bool)]
		public static extern bool CryptCATAdminCalcHashFromFileHandle2(HCATADMIN hCatAdmin, HFILE hFile, ref uint pcbHash, IntPtr pbHash, uint dwFlags = 0);

		/// <summary>
		/// <para>
		/// [The <c>CryptCATAdminEnumCatalogFromHash</c> function is available for use in the operating systems specified in the
		/// Requirements section. It may be altered or unavailable in subsequent versions.]
		/// </para>
		/// <para>
		/// The <c>CryptCATAdminEnumCatalogFromHash</c> function enumerates the catalogs that contain a specified hash. The hash is
		/// typically returned from the CryptCATAdminCalcHashFromFileHandle function. This function has no associated import library. You
		/// must use the LoadLibrary and GetProcAddress functions to dynamically link to Wintrust.dll. After the final call to this
		/// function, call CryptCATAdminReleaseCatalogContext to release allocated memory.
		/// </para>
		/// </summary>
		/// <param name="hCatAdmin">
		/// A handle to a catalog administrator context previously assigned by the CryptCATAdminAcquireContext function.
		/// </param>
		/// <param name="pbHash">A pointer to the buffer that contains the hash retrieved by calling CryptCATAdminCalcHashFromFileHandle.</param>
		/// <param name="cbHash">Number of bytes in the buffer allocated for pbHash.</param>
		/// <param name="dwFlags">This parameter is reserved for future use and must be set to zero.</param>
		/// <param name="phPrevCatInfo">
		/// A pointer to the handle to the previous catalog context or <c>NULL</c>, if an enumeration is re-queried. If <c>NULL</c> is
		/// passed in for this parameter, then the caller gets information only for the first catalog that contains the hash; an enumeration
		/// is not made. If phPrevCatInfo contains <c>NULL</c>, then an enumeration of the catalogs that contain the hash is started, and
		/// subsequent calls to <c>CryptCATAdminEnumCatalogFromHash</c> must set phPrevCatInfo to the return value from the previous call.
		/// </param>
		/// <returns>
		/// <para>The return value is a handle to the catalog context or <c>NULL</c>, if there are no more catalogs to enumerate or retrieve.</para>
		/// <para>
		/// For extended error information, call the GetLastError function. For a complete list of error codes provided by the operating
		/// system, see System Error Codes.
		/// </para>
		/// </returns>
		// https://docs.microsoft.com/en-us/windows/win32/api/mscat/nf-mscat-cryptcatadminenumcatalogfromhash HCATINFO
		// CryptCATAdminEnumCatalogFromHash( HCATADMIN hCatAdmin, BYTE *pbHash, DWORD cbHash, DWORD dwFlags, HCATINFO *phPrevCatInfo );
		[PInvokeData("mscat.h", MSDNShortId = "33ab2d01-94ab-4d23-a054-9da0731485d6")]
		public static SafeHCATINFO CryptCATAdminEnumCatalogFromHash(SafeHCATADMIN hCatAdmin, IntPtr pbHash, uint cbHash, [Optional] uint dwFlags, ref HCATINFO phPrevCatInfo) =>
			new SafeHCATINFO(InternalCryptCATAdminEnumCatalogFromHash(hCatAdmin, pbHash, cbHash, dwFlags, ref phPrevCatInfo), hCatAdmin, true);

		/// <summary>
		/// <para>
		/// [The <c>CryptCATAdminReleaseCatalogContext</c> function is available for use in the operating systems specified in the
		/// Requirements section. It may be altered or unavailable in subsequent versions.]
		/// </para>
		/// <para>
		/// The <c>CryptCATAdminReleaseCatalogContext</c> function releases a handle to a catalog context previously returned by the
		/// CryptCATAdminAddCatalog function. This function has no associated import library. You must use the LoadLibrary and
		/// GetProcAddress functions to dynamically link to Wintrust.dll.
		/// </para>
		/// </summary>
		/// <param name="hCatAdmin">Handle previously assigned by the CryptCATAdminAcquireContext function.</param>
		/// <param name="hCatInfo">
		/// Handle previously assigned by the CryptCATAdminAddCatalog function or the CryptCATAdminEnumCatalogFromHash function.
		/// </param>
		/// <param name="dwFlags">This parameter is reserved for future use and must be set to zero.</param>
		/// <returns>The return value is <c>TRUE</c> if the function succeeds; <c>FALSE</c> if the function fails.</returns>
		// https://docs.microsoft.com/en-us/windows/win32/api/mscat/nf-mscat-cryptcatadminreleasecatalogcontext BOOL
		// CryptCATAdminReleaseCatalogContext( IN HCATADMIN hCatAdmin, IN HCATINFO hCatInfo, IN DWORD dwFlags );
		[DllImport(Lib.Wintrust, SetLastError = false, ExactSpelling = true)]
		[PInvokeData("mscat.h", MSDNShortId = "6cc13013-2c0a-4934-a866-30b69cbcf934")]
		[return: MarshalAs(UnmanagedType.Bool)]
		public static extern bool CryptCATAdminReleaseCatalogContext(HCATADMIN hCatAdmin, HCATINFO hCatInfo, uint dwFlags = 0);

		/// <summary>
		/// <para>
		/// [The <c>CryptCATAdminReleaseContext</c> function is available for use in the operating systems specified in the Requirements
		/// section. It may be altered or unavailable in subsequent versions.]
		/// </para>
		/// <para>
		/// The <c>CryptCATAdminReleaseContext</c> function releases the handle previously assigned by the CryptCATAdminAcquireContext
		/// function. This function has no associated import library. You must use the LoadLibrary and GetProcAddress functions to
		/// dynamically link to Wintrust.dll.
		/// </para>
		/// </summary>
		/// <param name="hCatAdmin">
		/// Catalog administrator context handle previously assigned by a call to the CryptCATAdminAcquireContext function.
		/// </param>
		/// <param name="dwFlags">Not used; set to zero.</param>
		/// <returns>The return value is <c>TRUE</c> if the function succeeds; <c>FALSE</c> if the function fails.</returns>
		// https://docs.microsoft.com/en-us/windows/win32/api/mscat/nf-mscat-cryptcatadminreleasecontext BOOL CryptCATAdminReleaseContext(
		// IN HCATADMIN hCatAdmin, IN DWORD dwFlags );
		[DllImport(Lib.Wintrust, SetLastError = false, ExactSpelling = true)]
		[PInvokeData("mscat.h", MSDNShortId = "dff253dc-c444-46be-a383-41340d634cce")]
		[return: MarshalAs(UnmanagedType.Bool)]
		public static extern bool CryptCATAdminReleaseContext([In] HCATADMIN hCatAdmin, [In] uint dwFlags = 0);

		/// <summary>
		/// <para>
		/// [The <c>IsCatalogFile</c> function is available for use in the operating systems specified in the Requirements section. It may
		/// be altered or unavailable in subsequent versions.]
		/// </para>
		/// <para>The <c>IsCatalogFile</c> function retrieves a Boolean value that indicates whether the specified file is a catalog file.</para>
		/// <para>
		/// <c>Note</c> This function has no associated import library. You must use the LoadLibrary and GetProcAddress functions to
		/// dynamically link to Wintrust.dll.
		/// </para>
		/// </summary>
		/// <param name="hFile">
		/// A handle to the file to check. This parameter is optional, but it must contain a valid handle if the pwszFileName parameter is <c>NULL</c>.
		/// </param>
		/// <param name="pwszFileName">
		/// A pointer to a null-terminated wide character string that contains the name of the file to check. This parameter is optional,
		/// but it must contain a valid file name if the hFile parameter is <c>NULL</c>.
		/// </param>
		/// <returns>Returns nonzero if the specified file is a catalog file or zero otherwise.</returns>
		// https://docs.microsoft.com/en-us/windows/win32/api/mscat/nf-mscat-iscatalogfile BOOL IsCatalogFile( IN HANDLE hFile, WCHAR
		// *pwszFileName );
		[DllImport(Lib.Wintrust, SetLastError = false, ExactSpelling = true)]
		[PInvokeData("mscat.h", MSDNShortId = "eeba34d4-08aa-456a-8fdc-16795cbce36a")]
		[return: MarshalAs(UnmanagedType.Bool)]
		public static extern bool IsCatalogFile([In] HFILE hFile, [MarshalAs(UnmanagedType.LPWStr)] string pwszFileName);

		[DllImport(Lib.Wintrust, SetLastError = true, EntryPoint = "CryptCATAdminAddCatalog")]
		private static extern IntPtr InternalCryptCATAdminAddCatalog(HCATADMIN hCatAdmin, [MarshalAs(UnmanagedType.LPWStr)] string pwszCatalogFile, [MarshalAs(UnmanagedType.LPWStr), Optional] string pwszSelectBaseName, uint dwFlags);

		[DllImport(Lib.Wintrust, SetLastError = true, EntryPoint = "CryptCATAdminEnumCatalogFromHash")]
		private static extern IntPtr InternalCryptCATAdminEnumCatalogFromHash(HCATADMIN hCatAdmin, IntPtr pbHash, uint cbHash, [Optional] uint dwFlags, ref HCATINFO phPrevCatInfo);

		/// <summary>
		/// <para>
		/// [The <c>CATALOG_INFO</c> structure is available for use in the operating systems specified in the Requirements section. It may
		/// be altered or unavailable in subsequent versions.]
		/// </para>
		/// <para>
		/// The <c>CATALOG_INFO</c> structure contains the name of a catalog file. This structure is used by the
		/// CryptCATCatalogInfoFromContext function.
		/// </para>
		/// </summary>
		// https://docs.microsoft.com/en-us/windows/win32/api/mscat/ns-mscat-catalog_info typedef struct CATALOG_INFO_ { DWORD cbStruct;
		// WCHAR wszCatalogFile[MAX_PATH]; } CATALOG_INFO;
		[PInvokeData("mscat.h", MSDNShortId = "f6e66412-3ed2-48d9-a377-5df11500db59")]
		[StructLayout(LayoutKind.Sequential)]
		public struct CATALOG_INFO
		{
			/// <summary>Specifies the size, in bytes, of this structure.</summary>
			public uint cbStruct;

			/// <summary>Name of the catalog file.</summary>
			[MarshalAs(UnmanagedType.ByValTStr, SizeConst = 260)]
			public string wszCatalogFile;
		}

		/// <summary>
		/// <para>
		/// [The <c>CRYPTCATATTRIBUTE</c> structure is available for use in the operating systems specified in the Requirements section. It
		/// may be altered or unavailable in subsequent versions.]
		/// </para>
		/// <para>
		/// The <c>CRYPTCATATTRIBUTE</c> structure defines a catalog attribute. This structure is used by the CryptCATEnumerateAttr and
		/// CryptCATEnumerateCatAttr functions.
		/// </para>
		/// </summary>
		// https://docs.microsoft.com/en-us/windows/win32/api/mscat/ns-mscat-cryptcatattribute typedef struct CRYPTCATATTRIBUTE_ { DWORD
		// cbStruct; LPWSTR pwszReferenceTag; DWORD dwAttrTypeAndAction; DWORD cbValue; BYTE *pbValue; DWORD dwReserved; } CRYPTCATATTRIBUTE;
		[PInvokeData("mscat.h", MSDNShortId = "41b91303-f3eb-4288-9ad2-98f170680988")]
		[StructLayout(LayoutKind.Sequential)]
		public struct CRYPTCATATTRIBUTE
		{
			/// <summary>The size, in bytes, of this structure.</summary>
			public uint cbStruct;

			/// <summary>A pointer to a null-terminated string that contains the reference tag value.</summary>
			[MarshalAs(UnmanagedType.LPWStr)] public string pwszReferenceTag;

			/// <summary>
			/// <para>Bitwise combination of the following flags.</para>
			/// <list type="table">
			/// <listheader>
			/// <term>Value</term>
			/// <term>Meaning</term>
			/// </listheader>
			/// <item>
			/// <term>CRYPTCAT_ATTR_AUTHENTICATED 0x10000000</term>
			/// <term>The attribute is authenticated.</term>
			/// </item>
			/// <item>
			/// <term>CRYPTCAT_ATTR_UNAUTHENTICATED 0x20000000</term>
			/// <term>The attribute is unauthenticated.</term>
			/// </item>
			/// <item>
			/// <term>CRYPTCAT_ATTR_NAMEASCII 0x00000001</term>
			/// <term>The attribute is an ASCII string.</term>
			/// </item>
			/// <item>
			/// <term>CRYPTCAT_ATTR_NAMEOBJID 0x00000002</term>
			/// <term>The attribute is a cryptographic object identifier (OID).</term>
			/// </item>
			/// <item>
			/// <term>CRYPTCAT_ATTR_DATAASCII 0x00010000</term>
			/// <term>The attribute contains simple ASCII characters that should not be decoded.</term>
			/// </item>
			/// <item>
			/// <term>CRYPTCAT_ATTR_DATABASE64 0x00020000</term>
			/// <term>The attribute is in base 64 format.</term>
			/// </item>
			/// <item>
			/// <term>CRYPTCAT_ATTR_DATAREPLACE 0x00040000</term>
			/// <term>The attribute replaces the value for an existing attribute.</term>
			/// </item>
			/// </list>
			/// </summary>
			public CRYPTCAT_ATTR dwAttrTypeAndAction;

			/// <summary>Number of bytes used by <c>pbValue</c>.</summary>
			public uint cbValue;

			/// <summary>A pointer to the encoded bytes.</summary>
			public IntPtr pbValue;

			/// <summary>Reserved; do not use.</summary>
			public uint dwReserved;
		}

		/// <summary>
		/// <para>
		/// [The <c>CRYPTCATCDF</c> structure is available for use in the operating systems specified in the Requirements section. It may be
		/// altered or unavailable in subsequent versions.]
		/// </para>
		/// <para>
		/// The <c>CRYPTCATCDF</c> structure contains information used to create a signed catalog file (.cat) from a catalog definition file
		/// (CDF). This structure is used by the MakeCat tool.
		/// </para>
		/// </summary>
		/// <remarks>
		/// A parser can update dwCurFilePos and dwLastMemberOffset as it reads the CDF. A user-defined callback function can use this
		/// information for recoverable parse errors in the CDF.
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows/win32/api/mscat/ns-mscat-cryptcatcdf typedef struct CRYPTCATCDF_ { DWORD cbStruct;
		// HANDLE hFile; DWORD dwCurFilePos; DWORD dwLastMemberOffset; BOOL fEOF; LPWSTR pwszResultDir; HANDLE hCATStore; } CRYPTCATCDF;
		[PInvokeData("mscat.h", MSDNShortId = "15d5710a-d4df-4e45-b161-5d4f7509ba29")]
		[StructLayout(LayoutKind.Sequential)]
		public struct CRYPTCATCDF
		{
			/// <summary>The size, in bytes, of this structure.</summary>
			public uint cbStruct;

			/// <summary>A handle to the catalog definition file (.cdf).</summary>
			public HFILE hFile;

			/// <summary>
			/// A value that specifies the current position of the parser measured in bytes from the beginning of the catalog definition file.
			/// </summary>
			public uint dwCurFilePos;

			/// <summary>
			/// A value that specifies the number of bytes to the position of the last member parsed in the catalog definition file.
			/// </summary>
			public uint dwLastMemberOffset;

			/// <summary>
			/// An integer that indicates whether the parser finished reading the file. <c>TRUE</c> indicates that the last read operation
			/// returned zero bytes.
			/// </summary>
			[MarshalAs(UnmanagedType.Bool)] public bool fEOF;

			/// <summary>
			/// A pointer to a null-terminated string that contains the name of a directory where the catalog file (.cat) will be written.
			/// </summary>
			[MarshalAs(UnmanagedType.LPWStr)] public string pwszResultDir;

			/// <summary>A handle to the catalog file (.cat).</summary>
			public HANDLE hCATStore;
		}

		/// <summary>
		/// <para>
		/// [The <c>CRYPTCATMEMBER</c> structure is available for use in the operating systems specified in the Requirements section. It may
		/// be altered or unavailable in subsequent versions.]
		/// </para>
		/// <para>
		/// The <c>CRYPTCATMEMBER</c> structure provides information about a catalog member. This structure is used by the
		/// CryptCATGetMemberInfo and CryptCATEnumerateAttr functions.
		/// </para>
		/// </summary>
		// https://docs.microsoft.com/en-us/windows/win32/api/mscat/ns-mscat-cryptcatmember typedef struct CRYPTCATMEMBER_ { DWORD cbStruct;
		// LPWSTR pwszReferenceTag; LPWSTR pwszFileName; GUID gSubjectType; DWORD fdwMemberFlags; struct SIP_INDIRECT_DATA_ *pIndirectData;
		// DWORD dwCertVersion; DWORD dwReserved; HANDLE hReserved; CRYPT_ATTR_BLOB sEncodedIndirectData; CRYPT_ATTR_BLOB
		// sEncodedMemberInfo; } CRYPTCATMEMBER;
		[PInvokeData("mscat.h", MSDNShortId = "08f663d9-9dc2-4ac9-95c5-7f2ed972eb9b")]
		[StructLayout(LayoutKind.Sequential)]
		public struct CRYPTCATMEMBER
		{
			/// <summary>The size, in bytes, of this structure.</summary>
			public uint cbStruct;

			/// <summary>A pointer to a null-terminated string that contains the reference tag value.</summary>
			[MarshalAs(UnmanagedType.LPWStr)] public string pwszReferenceTag;

			/// <summary>A pointer to a null-terminated string that contains the file name.</summary>
			[MarshalAs(UnmanagedType.LPWStr)] public string pwszFileName;

			/// <summary><c>GUID</c> that identifies the subject type.</summary>
			public Guid gSubjectType;

			/// <summary>Value that specifies the member flags.</summary>
			public uint fdwMemberFlags;

			/// <summary>A pointer to a <c>SIP_INDIRECT_DATA</c> structure.</summary>
			public IntPtr pIndirectData;

			/// <summary>Value that specifies the certificate version.</summary>
			public uint dwCertVersion;

			/// <summary>Reserved; do not use.</summary>
			public uint dwReserved;

			/// <summary>Reserved; do not use.</summary>
			public HANDLE hReserved;

			/// <summary>A CRYPT_ATTR_BLOB structure that contains encoded indirect data.</summary>
			public CRYPTOAPI_BLOB sEncodedIndirectData;

			/// <summary>A CRYPT_ATTR_BLOB structure that contains encoded member information.</summary>
			public CRYPTOAPI_BLOB sEncodedMemberInfo;
		}

		/// <summary>
		/// <para>
		/// [The <c>CRYPTCATSTORE</c> structure is available for use in the operating systems specified in the Requirements section. It may
		/// be altered or unavailable in subsequent versions.]
		/// </para>
		/// <para>
		/// The <c>CRYPTCATSTORE</c> structure represents a catalog file. The CryptCATStoreFromHandle function populates this structure by
		/// using the handle returned by CryptCATOpen.
		/// </para>
		/// </summary>
		// https://docs.microsoft.com/en-us/windows/win32/api/mscat/ns-mscat-cryptcatstore typedef struct CRYPTCATSTORE_ { DWORD cbStruct;
		// DWORD dwPublicVersion; LPWSTR pwszP7File; HCRYPTPROV hProv; DWORD dwEncodingType; DWORD fdwStoreFlags; HANDLE hReserved; HANDLE
		// hAttrs; HCRYPTMSG hCryptMsg; HANDLE hSorted; } CRYPTCATSTORE;
		[PInvokeData("mscat.h", MSDNShortId = "65a15797-453c-4f47-8ea1-c92e616b50aa")]
		[StructLayout(LayoutKind.Sequential)]
		public struct CRYPTCATSTORE
		{
			/// <summary>The size, in bytes, of this structure.</summary>
			public uint cbStruct;

			/// <summary>A value that specifies the "PublicVersion" of the catalog file.</summary>
			public uint dwPublicVersion;

			/// <summary>
			/// A pointer to a null-terminated string that contains the name of the catalog file. This member must be initialized before a
			/// call to the CryptCATPersistStore function.
			/// </summary>
			[MarshalAs(UnmanagedType.LPWStr)] public string pwszP7File;

			/// <summary>A handle to the cryptographic service provider (CSP).</summary>
			public HCRYPTPROV hProv;

			/// <summary>
			/// A value that specifies the encoding type used for the file. Currently, only X509_ASN_ENCODING and PKCS_7_ASN_ENCODING are
			/// being used; however, additional encoding types may be added in the future. For either current encoding type, use:
			/// X509_ASN_ENCODING | PKCS_7_ASN_ENCODING.
			/// </summary>
			public CertEncodingType dwEncodingType;

			/// <summary>
			/// <para>A bitwise combination of the following values.</para>
			/// <list type="table">
			/// <listheader>
			/// <term>Value</term>
			/// <term>Meaning</term>
			/// </listheader>
			/// <item>
			/// <term>CRYPTCAT_OPEN_EXCLUDE_PAGE_HASHES 0x00010000</term>
			/// <term>Exclude page hashes in SPC_INDIRECT_DATA.</term>
			/// </item>
			/// <item>
			/// <term>CRYPTCAT_OPEN_FLAGS_MASK 0xffff0000</term>
			/// <term>For all flags with a value in the upper word, set or clear the flag.</term>
			/// </item>
			/// <item>
			/// <term>CRYPTCAT_OPEN_INCLUDE_PAGE_HASHES 0x00020000</term>
			/// <term>
			/// Include page hashes in SPC_INDIRECT_DATA. The CRYPTCAT_OPEN_EXCLUDE_PAGE_HASHES flag takes precedence if it is also set.
			/// </term>
			/// </item>
			/// <item>
			/// <term>CRYPTCAT_OPEN_NO_CONTENT_HCRYPTMSG 0x20000000</term>
			/// <term>Open the file for decoding without detached content.</term>
			/// </item>
			/// <item>
			/// <term>CRYPTCAT_OPEN_SORTED 0x40000000</term>
			/// <term>Open the catalog with the entries sorted alphabetically by subject.</term>
			/// </item>
			/// <item>
			/// <term>CRYPTCAT_OPEN_VERIFYSIGHASH 0x10000000</term>
			/// <term>Verify the signature hash but not the certificate chain.</term>
			/// </item>
			/// </list>
			/// </summary>
			public CRYPTCAT_OPEN fdwStoreFlags;

			/// <summary>This member is reserved and must be <c>NULL</c>.</summary>
			public HANDLE hReserved;

			/// <summary>This member is reserved and must be <c>NULL</c>.</summary>
			public HANDLE hAttrs;

			/// <summary>
			/// A handle to the decoded bytes. This member is only set if the file was opened with the
			/// <c>CRYPTCAT_OPEN_NO_CONTENT_HCRYPTMSG</c> flag set.
			/// </summary>
			public HCRYPTMSG hCryptMsg;

			/// <summary>This member is reserved and must be <c>NULL</c>.</summary>
			public HANDLE hSorted;
		}

		/// <summary>Provides a handle to a catalog information context.</summary>
		[StructLayout(LayoutKind.Sequential)]
		public struct HCATINFO : IHandle
		{
			private readonly IntPtr handle;

			/// <summary>Initializes a new instance of the <see cref="HCATINFO"/> struct.</summary>
			/// <param name="preexistingHandle">An <see cref="IntPtr"/> object that represents the pre-existing handle to use.</param>
			public HCATINFO(IntPtr preexistingHandle) => handle = preexistingHandle;

			/// <summary>Returns an invalid handle by instantiating a <see cref="HCATINFO"/> object with <see cref="IntPtr.Zero"/>.</summary>
			public static HCATINFO NULL => new HCATINFO(IntPtr.Zero);

			/// <summary>Gets a value indicating whether this instance is a null handle.</summary>
			public bool IsNull => handle == IntPtr.Zero;

			/// <summary>Performs an explicit conversion from <see cref="HCATINFO"/> to <see cref="IntPtr"/>.</summary>
			/// <param name="h">The handle.</param>
			/// <returns>The result of the conversion.</returns>
			public static explicit operator IntPtr(HCATINFO h) => h.handle;

			/// <summary>Performs an implicit conversion from <see cref="IntPtr"/> to <see cref="HCATINFO"/>.</summary>
			/// <param name="h">The pointer to a handle.</param>
			/// <returns>The result of the conversion.</returns>
			public static implicit operator HCATINFO(IntPtr h) => new HCATINFO(h);

			/// <summary>Implements the operator !=.</summary>
			/// <param name="h1">The first handle.</param>
			/// <param name="h2">The second handle.</param>
			/// <returns>The result of the operator.</returns>
			public static bool operator !=(HCATINFO h1, HCATINFO h2) => !(h1 == h2);

			/// <summary>Implements the operator ==.</summary>
			/// <param name="h1">The first handle.</param>
			/// <param name="h2">The second handle.</param>
			/// <returns>The result of the operator.</returns>
			public static bool operator ==(HCATINFO h1, HCATINFO h2) => h1.Equals(h2);

			/// <inheritdoc/>
			public override bool Equals(object obj) => obj is HCATINFO h ? handle == h.handle : false;

			/// <inheritdoc/>
			public override int GetHashCode() => handle.GetHashCode();

			/// <inheritdoc/>
			public IntPtr DangerousGetHandle() => handle;
		}

		/// <summary>Provides a <see cref="SafeHandle"/> for <see cref="HCATADMIN"/> that is disposed using <see cref="CryptCATAdminReleaseContext"/>.</summary>
		public class SafeHCATADMIN : SafeHANDLE
		{
			/// <summary>Initializes a new instance of the <see cref="SafeHCATADMIN"/> class and assigns an existing handle.</summary>
			/// <param name="preexistingHandle">An <see cref="IntPtr"/> object that represents the pre-existing handle to use.</param>
			/// <param name="ownsHandle">
			/// <see langword="true"/> to reliably release the handle during the finalization phase; otherwise, <see langword="false"/> (not recommended).
			/// </param>
			public SafeHCATADMIN(IntPtr preexistingHandle, bool ownsHandle = true) : base(preexistingHandle, ownsHandle) { }

			/// <summary>Initializes a new instance of the <see cref="SafeHCATADMIN"/> class.</summary>
			private SafeHCATADMIN() : base() { }

			/// <summary>Performs an implicit conversion from <see cref="SafeHCATADMIN"/> to <see cref="HCATADMIN"/>.</summary>
			/// <param name="h">The safe handle instance.</param>
			/// <returns>The result of the conversion.</returns>
			public static implicit operator HCATADMIN(SafeHCATADMIN h) => h.handle;

			/// <inheritdoc/>
			protected override bool InternalReleaseHandle() => CryptCATAdminReleaseContext(handle);
		}

		/// <summary>Provides a <see cref="SafeHandle"/> for <see cref="HCATINFO"/> that is disposed using <see cref="CryptCATAdminReleaseCatalogContext"/>.</summary>
		public class SafeHCATINFO : SafeHANDLE
		{
			private readonly SafeHCATADMIN hAdmin;

			/// <summary>Initializes a new instance of the <see cref="SafeHCATINFO"/> class and assigns an existing handle.</summary>
			/// <param name="preexistingHandle">An <see cref="IntPtr"/> object that represents the pre-existing handle to use.</param>
			/// <param name="ownsHandle">
			/// <see langword="true"/> to reliably release the handle during the finalization phase; otherwise, <see langword="false"/> (not recommended).
			/// </param>
			public SafeHCATINFO(IntPtr preexistingHandle, SafeHCATADMIN hCatAdmin, bool ownsHandle = true) : base(preexistingHandle, ownsHandle) =>
				hAdmin = hCatAdmin ?? throw new ArgumentNullException(nameof(hCatAdmin));

			/// <summary>Initializes a new instance of the <see cref="SafeHCATINFO"/> class.</summary>
			private SafeHCATINFO() : base() { }

			/// <summary>Performs an implicit conversion from <see cref="SafeHCATINFO"/> to <see cref="HCATINFO"/>.</summary>
			/// <param name="h">The safe handle instance.</param>
			/// <returns>The result of the conversion.</returns>
			public static implicit operator HCATINFO(SafeHCATINFO h) => h.handle;

			/// <inheritdoc/>
			protected override bool InternalReleaseHandle() => CryptCATAdminReleaseCatalogContext(hAdmin, handle);
		}

		/*
		CryptCATAdminRemoveCatalog	Deletes a catalog file and removes that catalog's entry from the Windows catalog database.
		CryptCATAdminResolveCatalogPath	Retrieves the fully qualified path of the specified catalog.
		CryptCATCatalogInfoFromContext	Retrieves catalog information from a specified catalog context.
		CryptCATCDFClose	Closes a catalog definition file (CDF) and frees the memory for the corresponding CRYPTCATCDF structure.
		CryptCATCDFEnumCatAttributes	Enumerates catalog-level attributes within the CatalogHeader section of a catalog definition file (CDF).
		CryptCATCDFOpen	Opens an existing catalog definition file (CDF) for reading and initializes a CRYPTCATCDF structure.
		CryptCATClose	Closes a catalog handle opened previously by the CryptCATOpen function.
		CryptCATEnumerateAttr	Enumerates the attributes associated with a member of a catalog. This function has no associated import library.
		CryptCATEnumerateCatAttr	Enumerates the attributes associated with a catalog. This function has no associated import library.
		CryptCATEnumerateMember	Enumerates the members of a catalog.
		CryptCATGetAttrInfo	Retrieves information about an attribute of a member of a catalog.
		CryptCATGetMemberInfo	Retrieves member information from the catalog's PKCS #7.
		CryptCATHandleFromStore	Retrieves a catalog handle from memory.
		CryptCATOpen	Opens a catalog and returns a context handle to the open catalog.
		CryptCATPersistStore	Saves the information in the specified catalog store to an unsigned catalog file.
		CryptCATPutAttrInfo	Allocates memory for an attribute and adds it to a catalog member.
		CryptCATPutCatAttrInfo	Allocates memory for a catalog file attribute and adds it to the catalog.
		CryptCATPutMemberInfo	Allocates memory for a catalog member and adds it to the catalog.
		CryptCATStoreFromHandle	Retrieves a CRYPTCATSTORE structure from a catalog handle.
		*/
	}
}