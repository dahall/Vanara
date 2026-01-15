using System.Collections.Generic;
using static Vanara.PInvoke.Crypt32;

namespace Vanara.PInvoke;

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

	/// <summary>Flags used by <see cref="CryptCATOpen"/> and <see cref="CRYPTCATSTORE"/>.</summary>
	[PInvokeData("mscat.h", MSDNShortId = "e81f3a3d-d5b7-4266-838d-b83e331c8594")]
	[Flags]
	public enum CRYPTCAT_OPEN : uint
	{
		/// <summary>Opens the file, if it exists, or creates a new file, if needed.</summary>
		CRYPTCAT_OPEN_ALWAYS = 0x00000002,

		/// <summary>A new catalog file is created. If a previously created file exists, it is overwritten.</summary>
		CRYPTCAT_OPEN_CREATENEW = 0x00000001,

		/// <summary>Opens the file, only if it exists.</summary>
		CRYPTCAT_OPEN_EXISTING = 0x00000004,

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

	/// <summary>Version values used by <see cref="CryptCATOpen"/>.</summary>
	[PInvokeData("mscat.h", MSDNShortId = "e81f3a3d-d5b7-4266-838d-b83e331c8594")]
	public enum CRYPTCAT_VERSION
	{
		/// <summary>Version 1 file format.</summary>
		CRYPTCAT_VERSION_1 = 0x100,

		/// <summary>
		/// Version 2 file format.
		/// <para>Windows 8 and Windows Server 2012: Support for this value begins.</para>
		/// </summary>
		CRYPTCAT_VERSION_2 = 0x200,
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
	public static extern bool CryptCATAdminAcquireContext2(out SafeHCATADMIN phCatAdmin, in Guid pgSubsystem,
		[MarshalAs(UnmanagedType.LPWStr), Optional] string? pwszHashAlgorithm, in CERT_STRONG_SIGN_PARA pStrongHashPolicy, uint dwFlags = 0);

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
	public static extern bool CryptCATAdminAcquireContext2(out SafeHCATADMIN phCatAdmin, [Optional] IntPtr pgSubsystem,
		[MarshalAs(UnmanagedType.LPWStr), Optional] string? pwszHashAlgorithm, [Optional] IntPtr pStrongHashPolicy, uint dwFlags = 0);

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
	public static SafeHCATINFO CryptCATAdminAddCatalog(SafeHCATADMIN hCatAdmin, [MarshalAs(UnmanagedType.LPWStr)] string pwszCatalogFile,
		[MarshalAs(UnmanagedType.LPWStr), Optional] string? pwszSelectBaseName, uint dwFlags) =>
		new(InternalCryptCATAdminAddCatalog(hCatAdmin, pwszCatalogFile, pwszSelectBaseName, dwFlags), hCatAdmin, true);

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
	public static extern bool CryptCATAdminCalcHashFromFileHandle(HFILE hFile, ref uint pcbHash, [Optional] IntPtr pbHash, uint dwFlags = 0);

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
	public static extern bool CryptCATAdminCalcHashFromFileHandle2(HCATADMIN hCatAdmin, HFILE hFile, ref uint pcbHash, [Optional] IntPtr pbHash, uint dwFlags = 0);

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
		new(InternalCryptCATAdminEnumCatalogFromHash(hCatAdmin, pbHash, cbHash, dwFlags, ref phPrevCatInfo), hCatAdmin, true);

	/// <summary>
	/// <para>
	/// [The <c>CryptCATAdminEnumCatalogFromHash</c> function is available for use in the operating systems specified in the Requirements
	/// section. It may be altered or unavailable in subsequent versions.]
	/// </para>
	/// <para>
	/// The <c>CryptCATAdminEnumCatalogFromHash</c> function enumerates the catalogs that contain a specified hash. The hash is typically
	/// returned from the CryptCATAdminCalcHashFromFileHandle function. This function has no associated import library. You must use the
	/// LoadLibrary and GetProcAddress functions to dynamically link to Wintrust.dll. After the final call to this function, call
	/// CryptCATAdminReleaseCatalogContext to release allocated memory.
	/// </para>
	/// </summary>
	/// <param name="hCatAdmin">A handle to a catalog administrator context previously assigned by the CryptCATAdminAcquireContext function.</param>
	/// <param name="pbHash">A pointer to the buffer that contains the hash retrieved by calling CryptCATAdminCalcHashFromFileHandle.</param>
	/// <param name="cbHash">Number of bytes in the buffer allocated for pbHash.</param>
	/// <param name="dwFlags">This parameter is reserved for future use and must be set to zero.</param>
	/// <param name="phPrevCatInfo">
	/// The safe handle to the previous catalog context or <c>NULL</c>, if an enumeration is re-queried. If <c>NULL</c> is passed in for
	/// this parameter, then the caller gets information only for the first catalog that contains the hash; an enumeration is not made.
	/// If phPrevCatInfo contains <c>NULL</c>, then an enumeration of the catalogs that contain the hash is started, and subsequent calls
	/// to <c>CryptCATAdminEnumCatalogFromHash</c> must set phPrevCatInfo to the return value from the previous call.
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
	public static SafeHCATINFO CryptCATAdminEnumCatalogFromHash(SafeHCATADMIN hCatAdmin, IntPtr pbHash, uint cbHash, [Optional] uint dwFlags, SafeHCATINFO? phPrevCatInfo = null)
	{
		HCATINFO hPrev = phPrevCatInfo is null ? default : (HCATINFO)phPrevCatInfo;
		return new SafeHCATINFO(InternalCryptCATAdminEnumCatalogFromHash(hCatAdmin, pbHash, cbHash, dwFlags, ref hPrev), hCatAdmin, true);
	}

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
	/// [The <c>CryptCATAdminRemoveCatalog</c> function is available for use in the operating systems specified in the Requirements
	/// section. It may be altered or unavailable in subsequent versions.]
	/// </para>
	/// <para>
	/// The <c>CryptCATAdminRemoveCatalog</c> function deletes a catalog file and removes that catalog's entry from the Windows catalog
	/// database. This function is the only supported way to remove catalogs from the database while ensuring the integrity of the
	/// database. The function has no associated import library. You must use the LoadLibrary and GetProcAddress functions to
	/// dynamically link to Wintrust.dll.
	/// </para>
	/// </summary>
	/// <param name="hCatAdmin">Handle previously assigned by the CryptCATAdminAcquireContext function.</param>
	/// <param name="pwszCatalogFile">
	/// A pointer to a null-terminated string for the name of the catalog to remove. This string must contain only the name, without any
	/// path information.
	/// </param>
	/// <param name="dwFlags">This parameter is reserved for future use and must be set to zero.</param>
	/// <returns>
	/// <para>The return value is <c>TRUE</c> if the function succeeds; <c>FALSE</c> if the function fails.</para>
	/// <para>
	/// For extended error information, call the GetLastError function. For a complete list of error codes provided by the operating
	/// system, see System Error Codes.
	/// </para>
	/// </returns>
	// https://docs.microsoft.com/en-us/windows/win32/api/mscat/nf-mscat-cryptcatadminremovecatalog BOOL CryptCATAdminRemoveCatalog( IN
	// HCATADMIN hCatAdmin, IN LPCWSTR pwszCatalogFile, IN DWORD dwFlags );
	[DllImport(Lib.Wintrust, SetLastError = true, ExactSpelling = true)]
	[PInvokeData("mscat.h", MSDNShortId = "e09fe991-0e7a-45da-910a-8cb148bdff9a")]
	[return: MarshalAs(UnmanagedType.Bool)]
	public static extern bool CryptCATAdminRemoveCatalog(HCATADMIN hCatAdmin, [MarshalAs(UnmanagedType.LPWStr)] string pwszCatalogFile, uint dwFlags = 0);

	/// <summary>
	/// <para>
	/// [The <c>CryptCATAdminResolveCatalogPath</c> function is available for use in the operating systems specified in the Requirements
	/// section. It may be altered or unavailable in subsequent versions.]
	/// </para>
	/// <para>The <c>CryptCATAdminResolveCatalogPath</c> function retrieves the fully qualified path of the specified catalog.</para>
	/// <para>
	/// <c>Note</c> This function has no associated import library. You must use the LoadLibrary and GetProcAddress functions to
	/// dynamically link to Wintrust.dll.
	/// </para>
	/// </summary>
	/// <param name="hCatAdmin">A handle that was previously assigned by the CryptCATAdminAcquireContext function.</param>
	/// <param name="pwszCatalogFile">The name of the catalog file for which to retrieve the fully qualified path.</param>
	/// <param name="psCatInfo">
	/// A pointer to the CATALOG_INFO structure. This value cannot be <c>NULL</c>. Upon return from this function, the wszCatalogFile
	/// member of the <c>CATALOG_INFO</c> structure contains the catalog file name.
	/// </param>
	/// <param name="dwFlags">This parameter is reserved and must be set to zero.</param>
	/// <returns>
	/// <para>Returns nonzero if successful or zero otherwise.</para>
	/// <para>
	/// For extended error information, call the GetLastError function. For a complete list of error codes provided by the operating
	/// system, see System Error Codes.
	/// </para>
	/// </returns>
	// https://docs.microsoft.com/en-us/windows/win32/api/mscat/nf-mscat-cryptcatadminresolvecatalogpath BOOL
	// CryptCATAdminResolveCatalogPath( HCATADMIN hCatAdmin, WCHAR *pwszCatalogFile, CATALOG_INFO *psCatInfo, DWORD dwFlags );
	[DllImport(Lib.Wintrust, SetLastError = true, ExactSpelling = true)]
	[PInvokeData("mscat.h", MSDNShortId = "bdbfa02d-8801-40d4-84f4-bc5a449bce50")]
	[return: MarshalAs(UnmanagedType.Bool)]
	public static extern bool CryptCATAdminResolveCatalogPath(HCATADMIN hCatAdmin, [MarshalAs(UnmanagedType.LPWStr)] string pwszCatalogFile, ref CATALOG_INFO psCatInfo, uint dwFlags = 0);

	/// <summary>
	/// <para>
	/// [The <c>CryptCATCatalogInfoFromContext</c> function is available for use in the operating systems specified in the Requirements
	/// section. It may be altered or unavailable in subsequent versions.]
	/// </para>
	/// <para>
	/// The <c>CryptCATCatalogInfoFromContext</c> function retrieves catalog information from a specified catalog context. This function
	/// has no associated import library. You must use the LoadLibrary and GetProcAddress functions to dynamically link to Wintrust.dll.
	/// </para>
	/// </summary>
	/// <param name="hCatInfo">A handle to the catalog context. This value cannot be <c>NULL</c>.</param>
	/// <param name="psCatInfo">
	/// A pointer to the CATALOG_INFO structure. This value cannot be <c>NULL</c>. Upon return from this function, the wszCatalogFile
	/// member of the CATALOG_INFO structure contains the catalog file name.
	/// </param>
	/// <param name="dwFlags">Unused; set to zero.</param>
	/// <returns>
	/// <para>The return value is <c>TRUE</c> if the function succeeds; <c>FALSE</c> if the function fails.</para>
	/// <para>
	/// For extended error information, call the GetLastError function. For a complete list of error codes provided by the operating
	/// system, see System Error Codes.
	/// </para>
	/// </returns>
	// https://docs.microsoft.com/en-us/windows/win32/api/mscat/nf-mscat-cryptcatcataloginfofromcontext BOOL
	// CryptCATCatalogInfoFromContext( HCATINFO hCatInfo, CATALOG_INFO *psCatInfo, DWORD dwFlags );
	[DllImport(Lib.Wintrust, SetLastError = true, ExactSpelling = true)]
	[PInvokeData("mscat.h", MSDNShortId = "ec195fcc-1cff-4dd6-9075-c4904b653da7")]
	[return: MarshalAs(UnmanagedType.Bool)]
	public static extern bool CryptCATCatalogInfoFromContext(HCATINFO hCatInfo, ref CATALOG_INFO psCatInfo, uint dwFlags = 0);

	/// <summary>
	/// <para>
	/// [The <c>CryptCATCDFClose</c> function is available for use in the operating systems specified in the Requirements section. It
	/// may be altered or unavailable in subsequent versions.]
	/// </para>
	/// <para>
	/// The <c>CryptCATCDFClose</c> function closes a catalog definition file (CDF) and frees the memory for the corresponding
	/// CRYPTCATCDF structure. <c>CryptCATCDFClose</c> is called by MakeCat.
	/// </para>
	/// </summary>
	/// <param name="pCDF">A pointer to a CRYPTCATCDF structure.</param>
	/// <returns>
	/// Upon success, this function returns <c>TRUE</c>. The <c>CryptCATCDFClose</c> function returns <c>FALSE</c> with an
	/// <c>ERROR_INVALID_PARAMETER</c> error if it fails.
	/// </returns>
	/// <remarks>
	/// Before closing the catalog output file specified in pCDF, the <c>CryptCATCDFClose</c> function signs and persists it to the file system.
	/// </remarks>
	// https://docs.microsoft.com/en-us/windows/win32/api/mscat/nf-mscat-cryptcatcdfclose BOOL CryptCATCDFClose( IN CRYPTCATCDF *pCDF );
	[DllImport(Lib.Wintrust, SetLastError = false, ExactSpelling = true)]
	[PInvokeData("mscat.h", MSDNShortId = "9f2a1175-f9fe-4f4d-bf6f-e4f4c59739ec")]
	[return: MarshalAs(UnmanagedType.Bool)]
	public static extern bool CryptCATCDFClose(IntPtr pCDF);

	/// <summary>
	/// <para>
	/// [The <c>CryptCATCDFEnumCatAttributes</c> function is available for use in the operating systems specified in the Requirements
	/// section. It may be altered or unavailable in subsequent versions.]
	/// </para>
	/// <para>
	/// The <c>CryptCATCDFEnumCatAttributes</c> function enumerates catalog-level attributes within the <c>CatalogHeader</c> section of
	/// a catalog definition file (CDF). <c>CryptCATCDFEnumCatAttributes</c> is called by MakeCat.
	/// </para>
	/// </summary>
	/// <param name="pCDF">A pointer to a CRYPTCATCDF structure.</param>
	/// <param name="pPrevAttr">A pointer to a CRYPTCATATTRIBUTE structure for a catalog attribute in the CDF pointed to by pCDF.</param>
	/// <param name="pfnParseError">A pointer to a user-defined function to handle file parse errors.</param>
	/// <returns>
	/// Upon success, this function returns a pointer to a CRYPTCATATTRIBUTE structure. The <c>CryptCATCDFEnumCatAttributes</c> function
	/// returns a <c>NULL</c> pointer if it fails.
	/// </returns>
	/// <remarks>
	/// <para>
	/// You typically call this function in a loop to enumerate all of the catalog header attributes in a CDF. Before entering the loop,
	/// set pPrevAttr to <c>NULL</c>. The function returns a pointer to the first attribute. Set pPrevAttr to the return value of the
	/// function for subsequent iterations of the loop.
	/// </para>
	/// <para>Examples</para>
	/// <para>The following example shows the correct sequence of assignments for the pPrevAttr parameter ().</para>
	/// </remarks>
	// https://docs.microsoft.com/en-us/windows/win32/api/mscat/nf-mscat-cryptcatcdfenumcatattributes CRYPTCATATTRIBUTE *
	// CryptCATCDFEnumCatAttributes( CRYPTCATCDF *pCDF, CRYPTCATATTRIBUTE *pPrevAttr, PFN_CDF_PARSE_ERROR_CALLBACK pfnParseError );
	[DllImport(Lib.Wintrust, SetLastError = false, ExactSpelling = true)]
	[PInvokeData("mscat.h", MSDNShortId = "01889cb9-7bf4-4591-9bb2-b263c4effe0c")]
	public static extern IntPtr CryptCATCDFEnumCatAttributes(SafeCRYPTCATCDF pCDF, IntPtr pPrevAttr, PfnCdfParseErrorCallback? pfnParseError);

	/// <summary>
	/// <para>
	/// [The <c>CryptCATCDFEnumCatAttributes</c> function is available for use in the operating systems specified in the Requirements
	/// section. It may be altered or unavailable in subsequent versions.]
	/// </para>
	/// <para>
	/// The <c>CryptCATCDFEnumCatAttributes</c> function enumerates catalog-level attributes within the <c>CatalogHeader</c> section of
	/// a catalog definition file (CDF). <c>CryptCATCDFEnumCatAttributes</c> is called by MakeCat.
	/// </para>
	/// </summary>
	/// <param name="pCDF">A pointer to a CRYPTCATCDF structure.</param>
	/// <param name="pfnParseError">A pointer to a user-defined function to handle file parse errors.</param>
	/// <returns>
	/// A sequence of CRYPTCATATTRIBUTE structures.
	/// </returns>
	// https://docs.microsoft.com/en-us/windows/win32/api/mscat/nf-mscat-cryptcatcdfenumcatattributes CRYPTCATATTRIBUTE *
	// CryptCATCDFEnumCatAttributes( CRYPTCATCDF *pCDF, CRYPTCATATTRIBUTE *pPrevAttr, PFN_CDF_PARSE_ERROR_CALLBACK pfnParseError );
	[PInvokeData("mscat.h", MSDNShortId = "01889cb9-7bf4-4591-9bb2-b263c4effe0c")]
	public static IEnumerable<CRYPTCATATTRIBUTE> CryptCATCDFEnumCatAttributes(SafeCRYPTCATCDF pCDF, PfnCdfParseErrorCallback? pfnParseError) =>
		EnumPrev<CRYPTCATATTRIBUTE>(p => CryptCATCDFEnumCatAttributes(pCDF, p, pfnParseError));

	private static IEnumerable<T> EnumPrev<T>(Func<IntPtr, IntPtr> f) where T : struct
	{
		IntPtr pPrevAttr = IntPtr.Zero;
		while ((pPrevAttr = f(pPrevAttr)) != IntPtr.Zero)
			yield return pPrevAttr.ToStructure<T>();
	}

	/// <summary>
	/// <para>
	/// [The <b>CryptCATCDFEnumMembersByCDFTagEx</b> function is available for use in the operating systems specified in the Requirements
	/// section. It may be altered or unavailable in subsequent versions.]
	/// </para>
	/// <para>
	/// The <b>CryptCATCDFEnumMembersByCDFTagEx</b> function enumerates the individual file members in the <b>CatalogFiles</b> section of a
	/// catalog definition file (CDF). <b>CryptCATCDFEnumMembersByCDFTagEx</b> is called by <c>MakeCat</c>.
	/// </para>
	/// <para>
	/// <para>Note</para>
	/// <para>
	/// This function has no associated header file or import library. To call this function, you must create a user-defined header file and
	/// use the <c><b>LoadLibrary</b></c> and <c><b>GetProcAddress</b></c> functions to dynamically link to Mssign32.dll.
	/// </para>
	/// </para>
	/// <para></para>
	/// </summary>
	/// <param name="pCDF">A pointer to a <c><b>CRYPTCATCDF</b></c> structure.</param>
	/// <param name="pwszPrevCDFTag">A pointer to a <b>null</b>-terminated string that identifies the catalog file member.</param>
	/// <param name="pfnParseError">A pointer to a user-defined function to handle file parse errors.</param>
	/// <param name="ppMember">A pointer to a <c><b>CRYPTCATMEMBER</b></c> structure that contains the file member information.</param>
	/// <param name="fContinueOnError">A value that specifies whether to keep in memory a reference to the last enumerated member.</param>
	/// <param name="pvReserved">This parameter is reserved; do not use it.</param>
	/// <returns>
	/// Upon success, this function returns a pointer to a <b>null</b>-terminated string that identifies a file member in the
	/// <b>CatalogFiles</b> section of a CDF. The <b>CryptCATCDFEnumMembersByCDFTagEx</b> function returns a <b>NULL</b> pointer if it fails.
	/// </returns>
	/// <remarks>
	/// You typically call this function in a loop to enumerate all of the catalog file members in a CDF. Before entering the loop, set
	/// pwszPrevCDFTag to <b>NULL</b>. The function returns a pointer to the first member. Set pwszPrevCDFTag to the return value of the
	/// function for subsequent iterations of the loop.
	/// </remarks>
	// https://learn.microsoft.com/en-us/windows/win32/seccrypto/cryptcatcdfenummembersbycdftagex PWSTR WINAPI
	// CryptCATCDFEnumMembersByCDFTagEx( _In_ CRYPTCATCDF *pCDF, _Inout_ PWSTR pwszPrevCDFTag, _In_ PFN_CDF_PARSE_ERROR_CALLBACK
	// pfnParseError, _In_ CRYPTCATMEMBER **ppMember, _In_ BOOL fContinueOnError, _In_ LPVOID pvReserved );
	[DllImport(Lib.Wintrust, SetLastError = false, ExactSpelling = true)]
	[return: MarshalAs(UnmanagedType.LPWStr)]
	public static extern string? CryptCATCDFEnumMembersByCDFTagEx(in CRYPTCATCDF pCDF, [MarshalAs(UnmanagedType.LPWStr)] string? pwszPrevCDFTag,
		[In, Optional, MarshalAs(UnmanagedType.FunctionPtr)] PfnCdfParseErrorCallback? pfnParseError, in ManagedStructPointer<CRYPTCATMEMBER> ppMember,
		[In, MarshalAs(UnmanagedType.Bool)] bool fContinueOnError, [In, Optional] IntPtr pvReserved);

	/// <summary>
	/// <para>
	/// [The <c>CryptCATCDFOpen</c> function is available for use in the operating systems specified in the Requirements section. It may
	/// be altered or unavailable in subsequent versions.]
	/// </para>
	/// <para>
	/// The <c>CryptCATCDFOpen</c> function opens an existing catalog definition file (CDF) for reading and initializes a CRYPTCATCDF
	/// structure. <c>CryptCATCDFOpen</c> is called by MakeCat.
	/// </para>
	/// </summary>
	/// <param name="pwszFilePath">A pointer to a null-terminated string that contains the path of the CDF file to open.</param>
	/// <param name="pfnParseError">A pointer to a user-defined function to handle file parse errors.</param>
	/// <returns>
	/// Upon success, this function returns a pointer to the newly created CRYPTCATCDF structure. The <c>CryptCATCDFOpen</c> function
	/// returns a <c>NULL</c> pointer if it fails.
	/// </returns>
	/// <remarks>
	/// <para>
	/// The following default values are used by the <c>CryptCATCDFOpen</c> function for given conditions in the CDF
	/// <c>CatalogHeader</c> section.
	/// </para>
	/// <list type="table">
	/// <listheader>
	/// <term>CatalogHeader condition</term>
	/// <term>Default value</term>
	/// </listheader>
	/// <item>
	/// <term>No Name value is specified.</term>
	/// <term>The file name in pwszFilePath is used for the catalog (.cat) output file.</term>
	/// </item>
	/// <item>
	/// <term>No PublicVersion value is specified.</term>
	/// <term>0x00000001</term>
	/// </item>
	/// <item>
	/// <term>No EncodingType value is specified.</term>
	/// <term>PKCS_7_ASN_ENCODING or X509_ASN_ENCODING (0x00010001)</term>
	/// </item>
	/// </list>
	/// <para>The following actions are performed by the <c>CryptCATCDFOpen</c> function for given error conditions.</para>
	/// <list type="table">
	/// <listheader>
	/// <term>Error condition</term>
	/// <term>Action performed</term>
	/// </listheader>
	/// <item>
	/// <term>No CatalogHeader or Name tags are found in CDF.</term>
	/// <term>
	/// If specified by the caller, the CryptCATCDFOpen function calls the function specified by pfnParseError and returns a NULL pointer.
	/// </term>
	/// </item>
	/// <item>
	/// <term>
	/// The CryptCATCDFOpen function calls the CryptCATOpen function to get a handle to the catalog (.cat) output file, but it gets an
	/// invalid or NULL handle.
	/// </term>
	/// <term>Calls the CryptCATCDFClose function and returns a NULL pointer.</term>
	/// </item>
	/// </list>
	/// <list type="table">
	/// <listheader>
	/// <term>Additional OIDs for the Catalog branch</term>
	/// <term>Definition</term>
	/// </listheader>
	/// <item>
	/// <term>szOID_CATALOG_LIST_MEMBER_V2</term>
	/// <term>1.3.6.1.4.1.311.12.1.3</term>
	/// </item>
	/// <item>
	/// <term>CAT_MEMBERINFO2_OBJID</term>
	/// <term>1.3.6.1.4.1.311.12.2.3</term>
	/// </item>
	/// </list>
	/// <para>
	/// <c>Windows Server 2008 R2, Windows 7, Windows Server 2008, Windows Vista, Windows Server 2003 and Windows XP:</c> The additional
	/// Catalog OIDs are not available.
	/// </para>
	/// </remarks>
	// https://docs.microsoft.com/en-us/windows/win32/api/mscat/nf-mscat-cryptcatcdfopen CRYPTCATCDF * CryptCATCDFOpen( PWSTR
	// pwszFilePath, PFN_CDF_PARSE_ERROR_CALLBACK pfnParseError );
	[DllImport(Lib.Wintrust, SetLastError = false, ExactSpelling = true)]
	[PInvokeData("mscat.h", MSDNShortId = "d400d8bd-c0a0-41dc-9093-8e4fc758d82f")]
	public static extern SafeCRYPTCATCDF CryptCATCDFOpen([MarshalAs(UnmanagedType.LPWStr)] string pwszFilePath, PfnCdfParseErrorCallback? pfnParseError);

	/// <summary>
	/// <para>
	/// [The <c>CryptCATClose</c> function is available for use in the operating systems specified in the Requirements section. It may
	/// be altered or unavailable in subsequent versions.]
	/// </para>
	/// <para>
	/// The <c>CryptCATClose</c> function closes a catalog handle opened previously by the CryptCATOpen function. This function has no
	/// associated import library. You must use the LoadLibrary and GetProcAddress functions to dynamically link to Wintrust.dll.
	/// </para>
	/// </summary>
	/// <param name="hCatalog">Handle opened previously by a call to the CryptCATOpen function.</param>
	/// <returns>The return value is <c>TRUE</c> if the function succeeds; <c>FALSE</c> if the function fails.</returns>
	// https://docs.microsoft.com/en-us/windows/win32/api/mscat/nf-mscat-cryptcatclose BOOL CryptCATClose( IN HANDLE hCatalog );
	[DllImport(Lib.Wintrust, SetLastError = false, ExactSpelling = true)]
	[PInvokeData("mscat.h", MSDNShortId = "f6fa2d10-0049-4d5e-9688-566e5c11d64e")]
	[return: MarshalAs(UnmanagedType.Bool)]
	public static extern bool CryptCATClose(HCATALOG hCatalog);

	/// <summary>
	/// <para>
	/// [The <c>CryptCATEnumerateAttr</c> function is available for use in the operating systems specified in the Requirements section.
	/// It may be altered or unavailable in subsequent versions.]
	/// </para>
	/// <para>
	/// The <c>CryptCATEnumerateAttr</c> function enumerates the attributes associated with a member of a catalog. This function has no
	/// associated import library. You must use the LoadLibrary and GetProcAddress functions to dynamically link to Wintrust.dll.
	/// </para>
	/// </summary>
	/// <param name="hCatalog">Handle for the catalog that contains the member identified by pCatMember. This value cannot be <c>NULL</c>.</param>
	/// <param name="pCatMember">A pointer to the CRYPTCATMEMBER structure that identifies which member of the catalog is being enumerated.</param>
	/// <param name="pPrevAttr">
	/// A pointer to the previously returned value from this function or pointer to <c>NULL</c> to start the enumeration.
	/// </param>
	/// <returns>
	/// The return value is a pointer to the CRYPTCATATTRIBUTE structure that contains the attribute information or <c>NULL</c>, if no
	/// more attributes are in the enumeration or if an error is encountered. The returned pointer is passed in as the pPrevAttr
	/// parameter for subsequent calls to this function.
	/// </returns>
	/// <remarks>Do not free the returned pointer nor any of the members pointed to by the returned pointer.</remarks>
	// https://docs.microsoft.com/en-us/windows/win32/api/mscat/nf-mscat-cryptcatenumerateattr CRYPTCATATTRIBUTE *
	// CryptCATEnumerateAttr( IN HANDLE hCatalog, IN CRYPTCATMEMBER *pCatMember, IN CRYPTCATATTRIBUTE *pPrevAttr );
	[DllImport(Lib.Wintrust, SetLastError = false, ExactSpelling = true)]
	[PInvokeData("mscat.h", MSDNShortId = "064e87db-4330-4b8b-9865-ba8b9714f6e4")]
	public static extern IntPtr CryptCATEnumerateAttr(HCATALOG hCatalog, in CRYPTCATMEMBER pCatMember, IntPtr pPrevAttr);

	/// <summary>
	/// <para>
	/// [The <c>CryptCATEnumerateAttr</c> function is available for use in the operating systems specified in the Requirements section. It
	/// may be altered or unavailable in subsequent versions.]
	/// </para>
	/// <para>
	/// The <c>CryptCATEnumerateAttr</c> function enumerates the attributes associated with a member of a catalog. This function has no
	/// associated import library. You must use the LoadLibrary and GetProcAddress functions to dynamically link to Wintrust.dll.
	/// </para>
	/// </summary>
	/// <param name="hCatalog">Handle for the catalog that contains the member identified by pCatMember. This value cannot be <c>NULL</c>.</param>
	/// <param name="pCatMember">A pointer to the CRYPTCATMEMBER structure that identifies which member of the catalog is being enumerated.</param>
	/// <returns>The return value is a sequence of CRYPTCATATTRIBUTE structures that contains the attribute information.</returns>
	// https://docs.microsoft.com/en-us/windows/win32/api/mscat/nf-mscat-cryptcatenumerateattr CRYPTCATATTRIBUTE *
	// CryptCATEnumerateAttr( IN HANDLE hCatalog, IN CRYPTCATMEMBER *pCatMember, IN CRYPTCATATTRIBUTE *pPrevAttr );
	[PInvokeData("mscat.h", MSDNShortId = "064e87db-4330-4b8b-9865-ba8b9714f6e4")]
	public static IEnumerable<CRYPTCATATTRIBUTE> CryptCATEnumerateAttr(HCATALOG hCatalog, CRYPTCATMEMBER pCatMember) =>
		EnumPrev<CRYPTCATATTRIBUTE>(p => CryptCATEnumerateAttr(hCatalog, pCatMember, p));

	/// <summary>
	/// <para>
	/// [The <c>CryptCATEnumerateCatAttr</c> function is available for use in the operating systems specified in the Requirements
	/// section. It may be altered or unavailable in subsequent versions.]
	/// </para>
	/// <para>
	/// The <c>CryptCATEnumerateCatAttr</c> function enumerates the attributes associated with a catalog. This function has no
	/// associated import library. You must use the LoadLibrary and GetProcAddress functions to dynamically link to Wintrust.dll.
	/// </para>
	/// </summary>
	/// <param name="hCatalog">Handle for the catalog whose attributes are being enumerated. This value cannot be <c>NULL</c>.</param>
	/// <param name="pPrevAttr">
	/// A pointer to the previously returned pointer to the CRYPTCATATTRIBUTE structure from this function or pointer to <c>NULL</c> to
	/// start the enumeration.
	/// </param>
	/// <returns>
	/// The return value is a pointer to the CRYPTCATATTRIBUTE structure that contains the attribute information or <c>NULL</c>, if no
	/// more attributes are in the enumeration or if an error is encountered. The returned pointer is passed in as the pPrevAttr
	/// parameter for subsequent calls to this function.
	/// </returns>
	/// <remarks>Do not free the returned pointer nor any of the members pointed to by the returned pointer.</remarks>
	// https://docs.microsoft.com/en-us/windows/win32/api/mscat/nf-mscat-cryptcatenumeratecatattr CRYPTCATATTRIBUTE *
	// CryptCATEnumerateCatAttr( IN HANDLE hCatalog, IN CRYPTCATATTRIBUTE *pPrevAttr );
	[DllImport(Lib.Wintrust, SetLastError = false, ExactSpelling = true)]
	[PInvokeData("mscat.h", MSDNShortId = "57b6ff5c-e47e-41ac-8ec8-01a47ea77acf")]
	public static extern IntPtr CryptCATEnumerateCatAttr(HCATALOG hCatalog, IntPtr pPrevAttr);

	/// <summary>
	/// <para>
	/// [The <c>CryptCATEnumerateCatAttr</c> function is available for use in the operating systems specified in the Requirements section. It
	/// may be altered or unavailable in subsequent versions.]
	/// </para>
	/// <para>
	/// The <c>CryptCATEnumerateCatAttr</c> function enumerates the attributes associated with a catalog. This function has no associated
	/// import library. You must use the LoadLibrary and GetProcAddress functions to dynamically link to Wintrust.dll.
	/// </para>
	/// </summary>
	/// <param name="hCatalog">Handle for the catalog whose attributes are being enumerated. This value cannot be <c>NULL</c>.</param>
	/// <returns>The return value is a sequence of CRYPTCATATTRIBUTE structures that contains the attribute information.</returns>
	// https://docs.microsoft.com/en-us/windows/win32/api/mscat/nf-mscat-cryptcatenumeratecatattr CRYPTCATATTRIBUTE *
	// CryptCATEnumerateCatAttr( IN HANDLE hCatalog, IN CRYPTCATATTRIBUTE *pPrevAttr );
	[PInvokeData("mscat.h", MSDNShortId = "57b6ff5c-e47e-41ac-8ec8-01a47ea77acf")]
	public static IEnumerable<CRYPTCATATTRIBUTE> CryptCATEnumerateCatAttr(HCATALOG hCatalog) =>
		EnumPrev<CRYPTCATATTRIBUTE>(p => CryptCATEnumerateCatAttr(hCatalog, p));

	/// <summary>
	/// <para>
	/// [The <c>CryptCATEnumerateMember</c> function is available for use in the operating systems specified in the Requirements
	/// section. It may be altered or unavailable in subsequent versions.]
	/// </para>
	/// <para>The <c>CryptCATEnumerateMember</c> function enumerates the members of a catalog.</para>
	/// </summary>
	/// <param name="hCatalog">The handle of the catalog that contains the members to enumerate. This value cannot be <c>NULL</c>.</param>
	/// <param name="pPrevMember">
	/// A pointer to a CRYPTCATMEMBER structure that identifies which member of the catalog was last retrieved. If this parameter is
	/// <c>NULL</c>, this function will retrieve the first member of the catalog.
	/// </param>
	/// <returns>
	/// This function returns a pointer to a CRYPTCATMEMBER structure that represents the next member of the catalog. If there are no
	/// more members in the catalog to enumerate, this function returns <c>NULL</c>.
	/// </returns>
	/// <remarks>
	/// <para>Do not free the returned pointer nor any of the members pointed to by the returned pointer.</para>
	/// <para>Examples</para>
	/// <para>The following pseudocode example shows how to use this function to enumerate all of the members of a catalog.</para>
	/// </remarks>
	// https://docs.microsoft.com/en-us/windows/win32/api/mscat/nf-mscat-cryptcatenumeratemember CRYPTCATMEMBER *
	// CryptCATEnumerateMember( IN HANDLE hCatalog, IN CRYPTCATMEMBER *pPrevMember );
	[DllImport(Lib.Wintrust, SetLastError = false, ExactSpelling = true)]
	[PInvokeData("mscat.h", MSDNShortId = "6bbfef11-a150-4255-8620-27c1b1587b48")]
	public static extern IntPtr CryptCATEnumerateMember(HCATALOG hCatalog, IntPtr pPrevMember);

	/// <summary>
	/// <para>
	/// [The <c>CryptCATEnumerateMember</c> function is available for use in the operating systems specified in the Requirements section. It
	/// may be altered or unavailable in subsequent versions.]
	/// </para>
	/// <para>The <c>CryptCATEnumerateMember</c> function enumerates the members of a catalog.</para>
	/// </summary>
	/// <param name="hCatalog">The handle of the catalog that contains the members to enumerate. This value cannot be <c>NULL</c>.</param>
	/// <returns>This function returns a sequence of CRYPTCATMEMBER structures that represents the next member of the catalog.</returns>
	// https://docs.microsoft.com/en-us/windows/win32/api/mscat/nf-mscat-cryptcatenumeratemember CRYPTCATMEMBER *
	// CryptCATEnumerateMember( IN HANDLE hCatalog, IN CRYPTCATMEMBER *pPrevMember );
	[PInvokeData("mscat.h", MSDNShortId = "6bbfef11-a150-4255-8620-27c1b1587b48")]
	public static IEnumerable<CRYPTCATMEMBER> CryptCATEnumerateMember(HCATALOG hCatalog) =>
		EnumPrev<CRYPTCATMEMBER>(p => CryptCATEnumerateMember(hCatalog, p));

	/// <summary>
	/// <para>
	/// [The <c>CryptCATGetAttrInfo</c> function is available for use in the operating systems specified in the Requirements section. It
	/// may be altered or unavailable in subsequent versions.]
	/// </para>
	/// <para>The <c>CryptCATGetAttrInfo</c> function retrieves information about an attribute of a member of a catalog.</para>
	/// </summary>
	/// <param name="hCatalog">
	/// The handle of the catalog that contains the member to retrieve the attribute information for. This handle is obtained by calling
	/// the CryptCATOpen function. This parameter is required and cannot be <c>NULL</c>.
	/// </param>
	/// <param name="pCatMember">
	/// A pointer to a CRYPTCATMEMBER structure that represents the member to retrieve the attribute information for. This can be
	/// obtained by calling the CryptCATGetMemberInfo function. This parameter is required and cannot be <c>NULL</c>.
	/// </param>
	/// <param name="pwszReferenceTag">
	/// A pointer to a null-terminated Unicode string that contains the name of the attribute to retrieve the information for. This
	/// parameter is required and cannot be <c>NULL</c>.
	/// </param>
	/// <returns>
	/// <para>
	/// This function returns a pointer to a CRYPTCATATTRIBUTE structure that contains the attribute information. If the function fails,
	/// it returns <c>NULL</c>.
	/// </para>
	/// <para><c>Important</c> Do not free the returned pointer nor any of the members pointed to by the returned pointer.</para>
	/// <para>
	/// If this function returns <c>NULL</c>, additional error information can be obtained by calling the GetLastError function.
	/// <c>GetLastError</c> will return one of the following error codes.
	/// </para>
	/// <list type="table">
	/// <listheader>
	/// <term>Return code</term>
	/// <term>Description</term>
	/// </listheader>
	/// <item>
	/// <term>CRYPT_E_NOT_FOUND</term>
	/// <term>The member or the attribute could not be found.</term>
	/// </item>
	/// <item>
	/// <term>ERROR_INVALID_PARAMETER</term>
	/// <term>One or more of the parameters are not valid.</term>
	/// </item>
	/// </list>
	/// </returns>
	// https://docs.microsoft.com/en-us/windows/win32/api/mscat/nf-mscat-cryptcatgetattrinfo CRYPTCATATTRIBUTE * CryptCATGetAttrInfo( IN
	// HANDLE hCatalog, IN CRYPTCATMEMBER *pCatMember, PWSTR pwszReferenceTag );
	[DllImport(Lib.Wintrust, SetLastError = true, ExactSpelling = true)]
	[PInvokeData("mscat.h", MSDNShortId = "e36966ea-741e-4380-85cd-5a3c9db38e6d")]
	public static extern ManagedStructPointer<CRYPTCATATTRIBUTE> CryptCATGetAttrInfo(HCATALOG hCatalog, in CRYPTCATMEMBER pCatMember, [MarshalAs(UnmanagedType.LPWStr)] string pwszReferenceTag);

	/// <summary>
	/// <para>
	/// [The <c>CryptCATGetMemberInfo</c> function is available for use in the operating systems specified in the Requirements section.
	/// It may be altered or unavailable in subsequent versions.]
	/// </para>
	/// <para>
	/// The <c>CryptCATGetMemberInfo</c> function retrieves member information from the catalog's PKCS #7. In addition to retrieving the
	/// member information for a specified reference tag, this function opens a member context. This function has no associated import
	/// library. You must use the LoadLibrary and GetProcAddress functions to dynamically link to Wintrust.dll.
	/// </para>
	/// </summary>
	/// <param name="hCatalog">A handle to the catalog. This parameter cannot be <c>NULL</c>.</param>
	/// <param name="pwszReferenceTag">
	/// A pointer to a <c>null</c>-terminated string that represents the reference tag for the member information being retrieved.
	/// </param>
	/// <returns>
	/// A pointer to the CRYPTCATMEMBER structure that contains the member information or <c>NULL</c>, if no information can be found.
	/// </returns>
	/// <remarks>Do not free the returned pointer nor any of the members pointed to by the returned pointer.</remarks>
	// https://docs.microsoft.com/en-us/windows/win32/api/mscat/nf-mscat-cryptcatgetmemberinfo CRYPTCATMEMBER * CryptCATGetMemberInfo(
	// IN HANDLE hCatalog, PWSTR pwszReferenceTag );
	[DllImport(Lib.Wintrust, SetLastError = false, ExactSpelling = true)]
	[PInvokeData("mscat.h", MSDNShortId = "ff265232-f57e-4ab0-ba07-05e6d6745ae3")]
	public static extern ManagedStructPointer<CRYPTCATMEMBER> CryptCATGetMemberInfo(HCATALOG hCatalog, [MarshalAs(UnmanagedType.LPWStr)] string pwszReferenceTag);

	/// <summary>
	/// <para>
	/// [The <c>CryptCATHandleFromStore</c> function is available for use in the operating systems specified in the Requirements
	/// section. It may be altered or unavailable in subsequent versions.]
	/// </para>
	/// <para>The <c>CryptCATHandleFromStore</c> function retrieves a catalog handle from memory.</para>
	/// </summary>
	/// <param name="pCatStore">A pointer to a CRYPTCATSTORE structure that contains the handle to retrieve.</param>
	/// <returns>A handle to the catalog.</returns>
	// https://docs.microsoft.com/en-us/windows/win32/api/mscat/nf-mscat-cryptcathandlefromstore HANDLE CryptCATHandleFromStore( IN
	// CRYPTCATSTORE *pCatStore );
	[DllImport(Lib.Wintrust, SetLastError = false, ExactSpelling = true)]
	[PInvokeData("mscat.h", MSDNShortId = "e9aedc2d-9492-4ed7-9f2d-891997f85f6f")]
	public static extern SafeHCATALOG CryptCATHandleFromStore(in CRYPTCATSTORE pCatStore);

	/// <summary>
	/// <para>
	/// [The <c>CryptCATOpen</c> function is available for use in the operating systems specified in the Requirements section. It may be
	/// altered or unavailable in subsequent versions.]
	/// </para>
	/// <para>The <c>CryptCATOpen</c> function opens a catalog and returns a context handle to the open catalog.</para>
	/// <para>
	/// <c>Note</c> Some older versions of Wintrust.lib do not contain the export information for this function. In this case, you must
	/// use the LoadLibrary and GetProcAddress functions to dynamically link to Wintrust.dll.
	/// </para>
	/// </summary>
	/// <param name="pwszFileName">A pointer to a null-terminated string for the catalog file name.</param>
	/// <param name="fdwOpenFlags">
	/// <para>Zero, to open an existing catalog file, or a bitwise combination of one or more of the following values.</para>
	/// <list type="table">
	/// <listheader>
	/// <term>Value</term>
	/// <term>Meaning</term>
	/// </listheader>
	/// <item>
	/// <term>CRYPTCAT_OPEN_ALWAYS</term>
	/// <term>Opens the file, if it exists, or creates a new file, if needed.</term>
	/// </item>
	/// <item>
	/// <term>CRYPTCAT_OPEN_CREATENEW</term>
	/// <term>A new catalog file is created. If a previously created file exists, it is overwritten.</term>
	/// </item>
	/// </list>
	/// </param>
	/// <param name="hProv">A handle to a cryptographic service provider (CSP).</param>
	/// <param name="dwPublicVersion">
	/// <para>Version of the file. This can be one of the following values.</para>
	/// <list type="table">
	/// <listheader>
	/// <term>Value</term>
	/// <term>Meaning</term>
	/// </listheader>
	/// <item>
	/// <term>CRYPTCAT_VERSION_1 0x100</term>
	/// <term>Version 1 file format.</term>
	/// </item>
	/// <item>
	/// <term>CRYPTCAT_VERSION_2 0x200</term>
	/// <term>Version 2 file format. Windows 8 and Windows Server 2012: Support for this value begins.</term>
	/// </item>
	/// </list>
	/// </param>
	/// <param name="dwEncodingType">
	/// Encoding type used for the file. If this value is 0, then the encoding type is set to PKCS_7_ASN_ENCODING | X509_ASN_ENCODING.
	/// </param>
	/// <returns>
	/// Upon success, this function returns a handle to the open catalog. When you have finished using the handle, close it by calling
	/// the CryptCATClose function. The <c>CryptCATOpen</c> function returns INVALID_HANDLE_VALUE if it fails.
	/// </returns>
	// https://docs.microsoft.com/en-us/windows/win32/api/mscat/nf-mscat-cryptcatopen HANDLE CryptCATOpen( PWSTR pwszFileName, IN DWORD
	// fdwOpenFlags, IN HCRYPTPROV hProv, IN DWORD dwPublicVersion, IN DWORD dwEncodingType );
	[DllImport(Lib.Wintrust, SetLastError = false, ExactSpelling = true)]
	[PInvokeData("mscat.h", MSDNShortId = "e81f3a3d-d5b7-4266-838d-b83e331c8594")]
	public static extern SafeHCATALOG CryptCATOpen([MarshalAs(UnmanagedType.LPWStr)] string pwszFileName, CRYPTCAT_OPEN fdwOpenFlags, [In] HCRYPTPROV hProv, [In] CRYPTCAT_VERSION dwPublicVersion, CertEncodingType dwEncodingType);

	/// <summary>
	/// <para>
	/// [The <c>CryptCATPersistStore</c> function is available for use in the operating systems specified in the Requirements section.
	/// It may be altered or unavailable in subsequent versions.]
	/// </para>
	/// <para>The <c>CryptCATPersistStore</c> function saves the information in the specified catalog store to an unsigned catalog file.</para>
	/// </summary>
	/// <param name="hCatalog">
	/// A handle to the catalog obtained from CryptCATHandleFromStore or CryptCATOpen function. Beginning with Windows 8 you must use
	/// only <c>CryptCATOpen</c> to retrieve a handle.
	/// </param>
	/// <returns>
	/// <para>The return value is <c>TRUE</c> if the function succeeds; otherwise, <c>FALSE</c>.</para>
	/// <para>
	/// If this function returns <c>FALSE</c>, additional error information can be obtained by calling the GetLastError function.
	/// <c>GetLastError</c> will return the following error code.
	/// </para>
	/// <list type="table">
	/// <listheader>
	/// <term>Return code</term>
	/// <term>Description</term>
	/// </listheader>
	/// <item>
	/// <term>ERROR_INVALID_PARAMETER</term>
	/// <term>One or more of the parameters are not valid.</term>
	/// </item>
	/// <item>
	/// <term>ERROR_NOT_SUPPORTED</term>
	/// <term>
	/// Beginning with Windows 8 and Windows Server 2012, you must retrieve a handle by calling the CryptCATOpen function with the
	/// dwPublicVersion parameter set to 0x100 or 0x200. For more information, see Remarks.
	/// </term>
	/// </item>
	/// </list>
	/// </returns>
	/// <remarks>
	/// <para>The <c>pwszP7File</c> member of the CRYPTCATSTORE structure must be initialized before you call <c>CryptCATPersistStore</c>.</para>
	/// <para>Beginning with Windows 8 and Windows Server 2012, the following changes apply to this function:</para>
	/// <list type="bullet">
	/// <item>
	/// <term>If CryptCATOpen was called with a dwPublicVersion parameter of 0x200, the catalog is written by using the v2 format.</term>
	/// </item>
	/// <item>
	/// <term>If CryptCATOpen was called with a dwPublicVersion parameter of 0x100, the catalog is written by using the v1 format.</term>
	/// </item>
	/// <item>
	/// <term>
	/// If CryptCATOpen was called with a dwPublicVersion parameter other than 0x200 or 0x100, the <c>CryptCATPersistStore</c> function
	/// returns <c>FALSE</c> and the error code is set to <c>ERROR_NOT_SUPPORTED</c>.
	/// </term>
	/// </item>
	/// </list>
	/// </remarks>
	// https://docs.microsoft.com/en-us/windows/win32/api/mscat/nf-mscat-cryptcatpersiststore BOOL CryptCATPersistStore( IN HANDLE
	// hCatalog );
	[DllImport(Lib.Wintrust, SetLastError = true, ExactSpelling = true)]
	[PInvokeData("mscat.h", MSDNShortId = "2a564b0e-fcc6-4702-8173-d18df7064e53")]
	[return: MarshalAs(UnmanagedType.Bool)]
	public static extern bool CryptCATPersistStore([In] HCATALOG hCatalog);

	/// <summary>
	/// <para>
	/// [The <c>CryptCATPutAttrInfo</c> function is available for use in the operating systems specified in the Requirements section. It
	/// may be altered or unavailable in subsequent versions.]
	/// </para>
	/// <para>The <c>CryptCATPutAttrInfo</c> function allocates memory for an attribute and adds it to a catalog member.</para>
	/// </summary>
	/// <param name="hCatalog">A handle to the catalog obtained from the CryptCATOpen or CryptCATHandleFromStore function.</param>
	/// <param name="pCatMember">A pointer to a CRYPTCATMEMBER structure that contains the catalog member.</param>
	/// <param name="pwszReferenceTag">A pointer to a null-terminated string that contains the name of the attribute.</param>
	/// <param name="dwAttrTypeAndAction">
	/// <para>
	/// A value that represents a bitwise combination of the following flags. The caller must at least specify
	/// <c>CRYPTCAT_ATTR_DATABASE64</c> or <c>CRYPTCAT_ATTR_DATAASCII</c>.
	/// </para>
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
	/// </param>
	/// <param name="cbData">A value that specifies the number of bytes in the pbData buffer.</param>
	/// <param name="pbData">A pointer to a memory buffer that contains the attribute value.</param>
	/// <returns>
	/// <para>
	/// Upon success, this function returns a pointer to a CRYPTCATATTRIBUTE structure that contains the assigned attribute. The caller
	/// must not free this pointer or any of its members.
	/// </para>
	/// <para>
	/// If this function returns <c>NULL</c>, additional error information can be obtained by calling the GetLastError function.
	/// <c>GetLastError</c> will return one of the following error codes.
	/// </para>
	/// <list type="table">
	/// <listheader>
	/// <term>Return code</term>
	/// <term>Description</term>
	/// </listheader>
	/// <item>
	/// <term>ERROR_INVALID_PARAMETER</term>
	/// <term>One or more of the parameters are not valid.</term>
	/// </item>
	/// <item>
	/// <term>ERROR_NOT_ENOUGH_MEMORY</term>
	/// <term>The operating system ran out of memory during the operation.</term>
	/// </item>
	/// </list>
	/// </returns>
	// https://docs.microsoft.com/en-us/windows/win32/api/mscat/nf-mscat-cryptcatputattrinfo CRYPTCATATTRIBUTE * CryptCATPutAttrInfo( IN
	// HANDLE hCatalog, IN CRYPTCATMEMBER *pCatMember, PWSTR pwszReferenceTag, IN DWORD dwAttrTypeAndAction, IN DWORD cbData, IN BYTE
	// *pbData );
	[DllImport(Lib.Wintrust, SetLastError = true, ExactSpelling = true)]
	[PInvokeData("mscat.h", MSDNShortId = "13d5cdb4-2a15-4442-9e11-c3f76ca03f7e")]
	public static extern IntPtr CryptCATPutAttrInfo([In] HCATALOG hCatalog, in CRYPTCATMEMBER pCatMember, [MarshalAs(UnmanagedType.LPWStr)] string pwszReferenceTag, [In] CRYPTCAT_ATTR dwAttrTypeAndAction, [In] uint cbData, [In] IntPtr pbData);

	/// <summary>
	/// <para>
	/// [The <c>CryptCATPutCatAttrInfo</c> function is available for use in the operating systems specified in the Requirements section.
	/// It may be altered or unavailable in subsequent versions.]
	/// </para>
	/// <para>The <c>CryptCATPutCatAttrInfo</c> function allocates memory for a catalog file attribute and adds it to the catalog.</para>
	/// </summary>
	/// <param name="hCatalog">A handle to the catalog obtained from the CryptCATOpen or CryptCATHandleFromStore functions.</param>
	/// <param name="pwszReferenceTag">A pointer to a null-terminated string for the name of the attribute.</param>
	/// <param name="dwAttrTypeAndAction">
	/// <para>
	/// A value that represents a bitwise combination of the following flags. The caller must at least specify
	/// <c>CRYPTCAT_ATTR_DATAASCII</c> or <c>CRYPTCAT_ATTR_DATABASE64</c>.
	/// </para>
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
	/// </param>
	/// <param name="cbData">A value that specifies the number of bytes in the pbData buffer.</param>
	/// <param name="pbData">A pointer to a memory buffer that contains the attribute value.</param>
	/// <returns>
	/// <para>
	/// A pointer to a CRYPTCATATTRIBUTE structure that contains the catalog attribute. The caller must not free this pointer or any of
	/// its members.
	/// </para>
	/// <para>
	/// If this function returns <c>NULL</c>, additional error information can be obtained by calling the GetLastError function.
	/// <c>GetLastError</c> will return one of the following error codes.
	/// </para>
	/// <list type="table">
	/// <listheader>
	/// <term>Return code</term>
	/// <term>Description</term>
	/// </listheader>
	/// <item>
	/// <term>ERROR_INVALID_PARAMETER</term>
	/// <term>One or more of the parameters are not valid.</term>
	/// </item>
	/// <item>
	/// <term>ERROR_NOT_ENOUGH_MEMORY</term>
	/// <term>The operating system ran out of memory during the operation.</term>
	/// </item>
	/// </list>
	/// </returns>
	// https://docs.microsoft.com/en-us/windows/win32/api/mscat/nf-mscat-cryptcatputcatattrinfo CRYPTCATATTRIBUTE *
	// CryptCATPutCatAttrInfo( IN HANDLE hCatalog, PWSTR pwszReferenceTag, IN DWORD dwAttrTypeAndAction, IN DWORD cbData, IN BYTE
	// *pbData );
	[DllImport(Lib.Wintrust, SetLastError = true, ExactSpelling = true)]
	[PInvokeData("mscat.h", MSDNShortId = "16bb8560-d4fc-4c81-8eed-21a2da7f396d")]
	public static extern IntPtr CryptCATPutCatAttrInfo(HCATALOG hCatalog, [MarshalAs(UnmanagedType.LPWStr)] string pwszReferenceTag, [In] CRYPTCAT_ATTR dwAttrTypeAndAction, [In] uint cbData, [In] IntPtr pbData);

	/// <summary>
	/// <para>
	/// [The <c>CryptCATPutMemberInfo</c> function is available for use in the operating systems specified in the Requirements section.
	/// It may be altered or unavailable in subsequent versions.]
	/// </para>
	/// <para>The <c>CryptCATPutMemberInfo</c> function allocates memory for a catalog member and adds it to the catalog.</para>
	/// </summary>
	/// <param name="hCatalog">A handle to the catalog obtained from the CryptCATOpen or CryptCATHandleFromStore function.</param>
	/// <param name="pwszFileName">A pointer to a null-terminated string for the catalog file name.</param>
	/// <param name="pwszReferenceTag">A pointer to a null-terminated string that contains the name of the member.</param>
	/// <param name="pgSubjectType">A GUID for the subject type of the member.</param>
	/// <param name="dwCertVersion">A value that specifies the certificate version.</param>
	/// <param name="cbSIPIndirectData">A value that specifies the number of bytes in the pbSIPIndirectData buffer.</param>
	/// <param name="pbSIPIndirectData">A pointer to a memory buffer for subject interface package (SIP)-indirect data.</param>
	/// <returns>
	/// <para>
	/// A pointer to a CRYPTCATMEMBER structure that contains the assigned member. The caller must not free this pointer or any of its members.
	/// </para>
	/// <para>
	/// If this function returns <c>NULL</c>, additional error information can be obtained by calling the GetLastError function.
	/// <c>GetLastError</c> will return one of the following error codes.
	/// </para>
	/// <list type="table">
	/// <listheader>
	/// <term>Return code</term>
	/// <term>Description</term>
	/// </listheader>
	/// <item>
	/// <term>ERROR_INVALID_PARAMETER</term>
	/// <term>One or more of the parameters are not valid.</term>
	/// </item>
	/// <item>
	/// <term>ERROR_NOT_ENOUGH_MEMORY</term>
	/// <term>The operating system ran out of memory during the operation.</term>
	/// </item>
	/// </list>
	/// </returns>
	// https://docs.microsoft.com/en-us/windows/win32/api/mscat/nf-mscat-cryptcatputmemberinfo CRYPTCATMEMBER * CryptCATPutMemberInfo(
	// IN HANDLE hCatalog, PWSTR pwszFileName, PWSTR pwszReferenceTag, IN GUID *pgSubjectType, IN DWORD dwCertVersion, IN DWORD
	// cbSIPIndirectData, IN BYTE *pbSIPIndirectData );
	[DllImport(Lib.Wintrust, SetLastError = true, ExactSpelling = true)]
	[PInvokeData("mscat.h", MSDNShortId = "bfc10577-e32e-4b2e-ad24-1d0a85c6730a")]
	public static extern IntPtr CryptCATPutMemberInfo([In] HCATALOG hCatalog, [MarshalAs(UnmanagedType.LPWStr)] string pwszFileName, [MarshalAs(UnmanagedType.LPWStr)] string pwszReferenceTag, in Guid pgSubjectType, [In] uint dwCertVersion, [In] uint cbSIPIndirectData, [In] IntPtr pbSIPIndirectData);

	/// <summary>
	/// <para>
	/// [The <c>CryptCATStoreFromHandle</c> function is available for use in the operating systems specified in the Requirements
	/// section. It may be altered or unavailable in subsequent versions.]
	/// </para>
	/// <para>The <c>CryptCATStoreFromHandle</c> function retrieves a CRYPTCATSTORE structure from a catalog handle.</para>
	/// </summary>
	/// <param name="hCatalog">A handle to the catalog obtained from the CryptCATOpen or CryptCATHandleFromStore function.</param>
	/// <returns>
	/// A pointer to a CRYPTCATSTORE structure that contains the catalog store. The caller must not free this pointer or any of its members.
	/// </returns>
	// https://docs.microsoft.com/en-us/windows/win32/api/mscat/nf-mscat-cryptcatstorefromhandle CRYPTCATSTORE *
	// CryptCATStoreFromHandle( IN HANDLE hCatalog );
	[DllImport(Lib.Wintrust, SetLastError = false, ExactSpelling = true)]
	[PInvokeData("mscat.h", MSDNShortId = "ce4fe972-0ed5-4b18-8ec5-9883af326335")]
	public static extern IntPtr CryptCATStoreFromHandle([In] HCATALOG hCatalog);

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
	public static extern bool IsCatalogFile([In, Optional] HFILE hFile, [MarshalAs(UnmanagedType.LPWStr), Optional] string? pwszFileName);

	[DllImport(Lib.Wintrust, SetLastError = true, EntryPoint = "CryptCATAdminAddCatalog")]
	private static extern IntPtr InternalCryptCATAdminAddCatalog(HCATADMIN hCatAdmin, [MarshalAs(UnmanagedType.LPWStr)] string pwszCatalogFile, [MarshalAs(UnmanagedType.LPWStr), Optional] string? pwszSelectBaseName, uint dwFlags);

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
	[StructLayout(LayoutKind.Sequential, CharSet = CharSet.Unicode)]
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
	// cbStruct; PWSTR pwszReferenceTag; DWORD dwAttrTypeAndAction; DWORD cbValue; BYTE *pbValue; DWORD dwReserved; } CRYPTCATATTRIBUTE;
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
	// HANDLE hFile; DWORD dwCurFilePos; DWORD dwLastMemberOffset; BOOL fEOF; PWSTR pwszResultDir; HANDLE hCATStore; } CRYPTCATCDF;
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
	/// <see cref="CryptCATGetMemberInfo"/> and <see cref="CryptCATEnumerateAttr(HCATALOG, CRYPTCATMEMBER)"/> functions.
	/// </para>
	/// </summary>
	// https://docs.microsoft.com/en-us/windows/win32/api/mscat/ns-mscat-cryptcatmember typedef struct CRYPTCATMEMBER_ { DWORD cbStruct;
	// PWSTR pwszReferenceTag; PWSTR pwszFileName; GUID gSubjectType; DWORD fdwMemberFlags; struct SIP_INDIRECT_DATA_ *pIndirectData;
	// DWORD dwCertVersion; DWORD dwReserved; HANDLE hReserved; CRYPT_ATTR_BLOB sEncodedIndirectData; CRYPT_ATTR_BLOB
	// sEncodedMemberInfo; } CRYPTCATMEMBER;
	[PInvokeData("mscat.h", MSDNShortId = "08f663d9-9dc2-4ac9-95c5-7f2ed972eb9b")]
	[StructLayout(LayoutKind.Sequential)]
	public struct CRYPTCATMEMBER
	{
		/// <summary>The size, in bytes, of this structure.</summary>
		public uint cbStruct;

		/// <summary>A pointer to a null-terminated string that contains the reference tag value.</summary>
		[MarshalAs(UnmanagedType.LPWStr)]
		public string pwszReferenceTag;

		/// <summary>A pointer to a null-terminated string that contains the file name.</summary>
		[MarshalAs(UnmanagedType.LPWStr)]
		public string pwszFileName;

		/// <summary><c>GUID</c> that identifies the subject type.</summary>
		public Guid gSubjectType;

		/// <summary>Value that specifies the member flags.</summary>
		public uint fdwMemberFlags;

		/// <summary>A pointer to a <c>SIP_INDIRECT_DATA</c> structure.</summary>
		public StructPointer<SIP_INDIRECT_DATA> pIndirectData;

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
	// DWORD dwPublicVersion; PWSTR pwszP7File; HCRYPTPROV hProv; DWORD dwEncodingType; DWORD fdwStoreFlags; HANDLE hReserved; HANDLE
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

	/// <summary>Provides a <see cref="SafeHandle"/> for <see cref="CRYPTCATCDF"/> that is disposed using <see cref="CryptCATCDFClose"/>.</summary>
	[AutoSafeHandle("CryptCATCDFClose(handle)")]
	public partial class SafeCRYPTCATCDF
	{
		/// <summary>
		/// Gets the structure with the data behind this handle. If the handle is invalid, this value is the default for the structure.
		/// </summary>
		public CRYPTCATCDF Value => IsInvalid ? default : handle.ToStructure<CRYPTCATCDF>();

		/// <summary>Performs an implicit conversion from <see cref="SafeCRYPTCATCDF"/> to <see cref="CRYPTCATCDF"/>.</summary>
		/// <param name="h">The safe handle instance.</param>
		/// <returns>The result of the conversion.</returns>
		public static implicit operator CRYPTCATCDF(SafeCRYPTCATCDF h) => h.Value;
	}

	/// <summary>Provides a <see cref="SafeHandle"/> for <see cref="HCATINFO"/> that is disposed using <see cref="CryptCATAdminReleaseCatalogContext"/>.</summary>
	/// <remarks>Initializes a new instance of the <see cref="SafeHCATINFO"/> class and assigns an existing handle.</remarks>
	/// <param name="preexistingHandle">An <see cref="IntPtr"/> object that represents the pre-existing handle to use.</param>
	/// <param name="hCatAdmin">A handle to Category Administrator context.</param>
	/// <param name="ownsHandle">
	/// <see langword="true"/> to reliably release the handle during the finalization phase; otherwise, <see langword="false"/> (not recommended).
	/// </param>
	public class SafeHCATINFO(IntPtr preexistingHandle, WinTrust.SafeHCATADMIN hCatAdmin, bool ownsHandle = true) : SafeHANDLE(preexistingHandle, ownsHandle)
	{
		private readonly SafeHCATADMIN hAdmin = hCatAdmin ?? throw new ArgumentNullException(nameof(hCatAdmin));

		/// <summary>Performs an implicit conversion from <see cref="SafeHCATINFO"/> to <see cref="HCATINFO"/>.</summary>
		/// <param name="h">The safe handle instance.</param>
		/// <returns>The result of the conversion.</returns>
		public static implicit operator HCATINFO(SafeHCATINFO h) => h.handle;

		/// <inheritdoc/>
		protected override bool InternalReleaseHandle() => CryptCATAdminReleaseCatalogContext(hAdmin, handle);
	}
}