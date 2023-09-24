using static Vanara.PInvoke.DbgHelp;

namespace Vanara.PInvoke;

/// <summary>Items from the ImageHlp.dll</summary>
public static partial class ImageHlp
{
	private const string Lib_ImageHlp = "imagehlp.dll";

	/// <summary>
	/// <para>An application-defined callback function used by the ImageGetDigestStream function to process data.</para>
	/// <para>
	/// The <c>DIGEST_FUNCTION</c> type defines a pointer to this callback function. <c>DigestFunction</c> is a placeholder for the
	/// application-defined function name.
	/// </para>
	/// </summary>
	/// <param name="refdata">
	/// A user-supplied handle to the digest. This value is passed as a parameter to the ImageGetDigestStream function.
	/// </param>
	/// <param name="pData">The data stream.</param>
	/// <param name="dwLength">The size of the data stream, in bytes.</param>
	/// <returns>
	/// If the function succeeds, the return value should be <c>TRUE</c>. If the function fails, the return value should be <c>FALSE</c>.
	/// </returns>
	/// <remarks>
	/// All ImageHlp functions, such as this one, are single threaded. Therefore, calls from more than one thread to this function will
	/// likely result in unexpected behavior or memory corruption. To avoid this, you must synchronize all concurrent calls from more
	/// than one thread to this function.
	/// </remarks>
	// https://docs.microsoft.com/en-us/windows/win32/api/imagehlp/nc-imagehlp-digest_function DIGEST_FUNCTION DigestFunction; BOOL
	// DigestFunction( DIGEST_HANDLE refdata, PBYTE pData, DWORD dwLength ) {...}
	[UnmanagedFunctionPointer(CallingConvention.Winapi, CharSet = CharSet.Ansi)]
	[PInvokeData("imagehlp.h", MSDNShortId = "NC:imagehlp.DIGEST_FUNCTION")]
	[return: MarshalAs(UnmanagedType.Bool)]
	public delegate bool DIGEST_FUNCTION(IntPtr refdata, IntPtr pData, uint dwLength);

	/// <summary>
	/// <para>
	/// An application-defined callback function used with the BindImageEx function. The status routine is called during the process of
	/// the image binding.
	/// </para>
	/// <para>
	/// The <c>PIMAGEHLP_STATUS_ROUTINE</c> type defines a pointer to this callback function. <c>StatusRoutine</c> is a placeholder for
	/// the application-defined function name.
	/// </para>
	/// </summary>
	/// <param name="Reason">
	/// <para>The current status of the bind operation. This parameter can be one of the following values.</para>
	/// <list type="table">
	/// <listheader>
	/// <term>Value</term>
	/// <term>Meaning</term>
	/// </listheader>
	/// <item>
	/// <term>BindOutOfMemory 0</term>
	/// <term>Out of memory. The Parameter value is the number of bytes in the allocation attempt.</term>
	/// </item>
	/// <item>
	/// <term>BindRvaToVaFailed 1</term>
	/// <term>The relative virtual address is invalid for the image. The Parameter value is not used.</term>
	/// </item>
	/// <item>
	/// <term>BindNoRoomInImage 2</term>
	/// <term>No room in the image for new format import table. The Parameter value is not used.</term>
	/// </item>
	/// <item>
	/// <term>BindImportModuleFailed 3</term>
	/// <term>Module import failed. The Parameter value is not used.</term>
	/// </item>
	/// <item>
	/// <term>BindImportProcedureFailed 4</term>
	/// <term>Procedure import failed. The Parameter value is the name of the function.</term>
	/// </item>
	/// <item>
	/// <term>BindImportModule 5</term>
	/// <term>Module import is starting. The Parameter value is not used.</term>
	/// </item>
	/// <item>
	/// <term>BindImportProcedure 6</term>
	/// <term>Procedure import is starting. The Parameter value is the name of the function.</term>
	/// </item>
	/// <item>
	/// <term>BindForwarder 7</term>
	/// <term>The Parameter value is the name of the function forwarded.</term>
	/// </item>
	/// <item>
	/// <term>BindForwarderNOT 8</term>
	/// <term>The Parameter value is the name of the function not forwarded.</term>
	/// </item>
	/// <item>
	/// <term>BindImageModified 9</term>
	/// <term>Image modified. The Parameter value is not used.</term>
	/// </item>
	/// <item>
	/// <term>BindExpandFileHeaders 10</term>
	/// <term>File headers expanded. The Parameter value is the number of bytes</term>
	/// </item>
	/// <item>
	/// <term>BindImageComplete 11</term>
	/// <term>Binding is complete. For more information on the Parameter value, see the following Remarks section.</term>
	/// </item>
	/// <item>
	/// <term>BindMismatchedSymbols 12</term>
	/// <term>Checksum did not match. The Parameter value is the name of the symbol file.</term>
	/// </item>
	/// <item>
	/// <term>BindSymbolsNotUpdated 13</term>
	/// <term>Symbol file was not updated. The Parameter value is the name of the symbol file not updated.</term>
	/// </item>
	/// </list>
	/// </param>
	/// <param name="ImageName">The name of the file to be bound. This value can be a file name, a partial path, or a full path.</param>
	/// <param name="DllName">The name of the DLL.</param>
	/// <param name="Va">The computed virtual address.</param>
	/// <param name="Parameter">
	/// Any additional status information. This value depends on the value of the Reason parameter. For more information, see the code
	/// fragment in the following Remarks section.
	/// </param>
	/// <returns>
	/// <para>If the function succeeds, the return value is <c>TRUE</c>.</para>
	/// <para>If the function fails, the return value is <c>FALSE</c>. To retrieve extended error information, call GetLastError.</para>
	/// </returns>
	/// <remarks>
	/// <para>
	/// All ImageHlp functions, such as this one, are single threaded. Therefore, calls from more than one thread to this function will
	/// likely result in unexpected behavior or memory corruption. To avoid this, you must synchronize all concurrent calls from more
	/// than one thread to this function.
	/// </para>
	/// <para>The following code fragment describes how to use the Va value when the status is BindImageComplete.</para>
	/// <para>
	/// <code>case BindImageComplete: if (fVerbose) { fprintf(stderr, "BIND: Details of binding %s\n", ImageName ); NewImports = (PIMAGE_BOUND_IMPORT_DESCRIPTOR)Va; NewImport = NewImports; while (NewImport-&gt;OffsetModuleName) { fprintf( stderr, " Import from %s [%x]", (LPSTR)NewImports + NewImport-&gt;OffsetModuleName, NewImport-&gt;TimeDateStamp ); if (NewImport-&gt;NumberOfModuleForwarderRefs != 0) { fprintf( stderr, " with %u forwarders", NewImport-&gt; NumberOfModuleForwarderRefs ); } fprintf( stderr, "\n" ); NewForwarder = (PIMAGE_BOUND_FORWARDER_REF)(NewImport+1); for (i=0; i&lt;NewImport-&gt;NumberOfModuleForwarderRefs; i++) { fprintf( stderr, " Forward to %s [%x]\n", (LPSTR)NewImports + NewForwarder-&gt;OffsetModuleName, NewForwarder-&gt;TimeDateStamp); NewForwarder += 1; } NewImport = (PIMAGE_BOUND_IMPORT_DESCRIPTOR)NewForwarder; } } break;</code>
	/// </para>
	/// </remarks>
	// https://docs.microsoft.com/en-us/windows/win32/api/imagehlp/nc-imagehlp-pimagehlp_status_routine PIMAGEHLP_STATUS_ROUTINE
	// PimagehlpStatusRoutine; BOOL PimagehlpStatusRoutine( IMAGEHLP_STATUS_REASON Reason, PCSTR ImageName, PCSTR DllName, ULONG_PTR Va,
	// ULONG_PTR Parameter ) {...}
	[UnmanagedFunctionPointer(CallingConvention.Winapi, CharSet = CharSet.Ansi)]
	[PInvokeData("imagehlp.h", MSDNShortId = "NC:imagehlp.PIMAGEHLP_STATUS_ROUTINE")]
	[return: MarshalAs(UnmanagedType.Bool)]
	public delegate bool PIMAGEHLP_STATUS_ROUTINE(IMAGEHLP_STATUS_REASON Reason, string ImageName, string DllName, IntPtr Va, IntPtr Parameter);

	/*
	public enum IMAGEHLP_SYMBOL_TYPE_INFO
	{
		TI_GET_SYMTAG,
		TI_GET_SYMNAME,
		TI_GET_LENGTH,
		TI_GET_TYPE,
		TI_GET_TYPEID,
		TI_GET_BASETYPE,
		TI_GET_ARRAYINDEXTYPEID,
		TI_FINDCHILDREN,
		TI_GET_DATAKIND,
		TI_GET_ADDRESSOFFSET,
		TI_GET_OFFSET,
		TI_GET_VALUE,
		TI_GET_COUNT,
		TI_GET_CHILDRENCOUNT,
		TI_GET_BITPOSITION,
		TI_GET_VIRTUALBASECLASS,
		TI_GET_VIRTUALTABLESHAPEID,
		TI_GET_VIRTUALBASEPOINTEROFFSET,
		TI_GET_CLASSPARENTID,
		TI_GET_NESTED,
		TI_GET_SYMINDEX,
		TI_GET_LEXICALPARENT,
		TI_GET_ADDRESS,
		TI_GET_THISADJUST,
		TI_GET_UDTKIND,
		TI_IS_EQUIV_TO,
		TI_GET_CALLING_CONVENTION,
		TI_IS_CLOSE_EQUIV_TO,
		TI_GTIEX_REQS_VALID,
		TI_GET_VIRTUALBASEOFFSET,
		TI_GET_VIRTUALBASEDISPINDEX,
		TI_GET_IS_REFERENCE,
		TI_GET_INDIRECTVIRTUALBASECLASS,
		TI_GET_VIRTUALBASETABLETYPE,
		IMAGEHLP_SYMBOL_TYPE_INFO_MAX,
	}
	public enum SYM_TYPE
	{
		SymNone = 0,
		SymCoff,
		SymCv,
		SymPdb,
		SymExport,
		SymDeferred,
		SymSym,       // .sym file
		SymDia,
		SymVirtual,
		NumSymTypes
	}

	public enum SymTagEnum
	{
		SymTagNull,
		SymTagExe,
		SymTagCompiland,
		SymTagCompilandDetails,
		SymTagCompilandEnv,
		SymTagFunction,
		SymTagBlock,
		SymTagData,
		SymTagAnnotation,
		SymTagLabel,
		SymTagPublicSymbol,
		SymTagUDT,
		SymTagEnum,
		SymTagFunctionType,
		SymTagPointerType,
		SymTagArrayType,
		SymTagBaseType,
		SymTagTypedef,
		SymTagBaseClass,
		SymTagFriend,
		SymTagFunctionArgType,
		SymTagFuncDebugStart,
		SymTagFuncDebugEnd,
		SymTagUsingNamespace,
		SymTagVTableShape,
		SymTagVTable,
		SymTagCustom,
		SymTagThunk,
		SymTagCustomType,
		SymTagManagedType,
		SymTagDimension,
		SymTagCallSite,
		SymTagInlineSite,
		SymTagBaseInterface,
		SymTagVectorType,
		SymTagMatrixType,
		SymTagHLSLType,
		SymTagCaller,
		SymTagCallee,
		SymTagExport,
		SymTagHeapAllocationSite,
		SymTagCoffGroup,
		SymTagMax
	}

	public enum ADDRESS_MODE
	{
		AddrMode1616,
		AddrMode1632,
		AddrModeReal,
		AddrModeFlat
	}
*/

	/// <summary>The bind options for <see cref="BindImageEx"/>.</summary>
	[PInvokeData("imagehlp.h", MSDNShortId = "NF:imagehlp.BindImageEx")]
	[Flags]
	public enum BINDOPTS
	{
		/// <term>Bind all images in the call tree for this file.</term>
		BIND_ALL_IMAGES = 0x00000004,

		/// <term>
		/// Do not discard DLL information in the cache between calls. This improves performance when binding a large number of images.
		/// </term>
		BIND_CACHE_IMPORT_DLLS = 0x00000008,

		/// <term>Do not generate a new import address table.</term>
		BIND_NO_BOUND_IMPORTS = 0x00000001,

		/// <term>Do not make changes to the file.</term>
		BIND_NO_UPDATE = 0x00000002,

		/// <summary/>
		BIND_REPORT_64BIT_VA = 0x00000010,
	}

	/// <summary>Return code from <see cref="MapFileAndCheckSum"/>.</summary>
	[PInvokeData("imagehlp.h", MSDNShortId = "NF:imagehlp.MapFileAndCheckSumA")]
	public enum CHECKSUM
	{
		/// <summary>Could not map a view of the file.</summary>
		CHECKSUM_MAPVIEW_FAILURE = 3,

		/// <summary>Could not map the file.</summary>
		CHECKSUM_MAP_FAILURE = 2,

		/// <summary>Could not open the file.</summary>
		CHECKSUM_OPEN_FAILURE = 1,

		/// <summary>The function succeeded.</summary>
		CHECKSUM_SUCCESS = 0,

		/// <summary>CHECKSUM_UNICODE_FAILURE 4</summary>
		CHECKSUM_UNICODE_FAILURE = 4,
	}

	/// <summary>The current status of the bind operation.</summary>
	[PInvokeData("imagehlp.h", MSDNShortId = "NC:imagehlp.PIMAGEHLP_STATUS_ROUTINE")]
	public enum IMAGEHLP_STATUS_REASON
	{
		/// <summary>Out of memory. The Parameter value is the number of bytes in the allocation attempt.</summary>
		BindOutOfMemory = 0,

		/// <summary>The relative virtual address is invalid for the image. The Parameter value is not used.</summary>
		BindRvaToVaFailed = 1,

		/// <summary>No room in the image for new format import table. The Parameter value is not used.</summary>
		BindNoRoomInImage = 2,

		/// <summary>Module import failed. The Parameter value is not used.</summary>
		BindImportModuleFailed = 3,

		/// <summary>Procedure import failed. The Parameter value is the name of the function.</summary>
		BindImportProcedureFailed = 4,

		/// <summary>Module import is starting. The Parameter value is not used.</summary>
		BindImportModule = 5,

		/// <summary>Procedure import is starting. The Parameter value is the name of the function.</summary>
		BindImportProcedure = 6,

		/// <summary>The Parameter value is the name of the function forwarded.</summary>
		BindForwarder = 7,

		/// <summary>The Parameter value is the name of the function not forwarded.</summary>
		BindForwarderNOT = 8,

		/// <summary>Image modified. The Parameter value is not used.</summary>
		BindImageModified = 9,

		/// <summary>File headers expanded. The Parameter value is the number of bytes</summary>
		BindExpandFileHeaders = 10,

		/// <summary>Binding is complete. For more information on the Parameter value, see the following Remarks section.</summary>
		BindImageComplete = 11,

		/// <summary>Checksum did not match. The Parameter value is the name of the symbol file.</summary>
		BindMismatchedSymbols = 12,

		/// <summary>Symbol file was not updated. The Parameter value is the name of the symbol file not updated.</summary>
		BindSymbolsNotUpdated = 13,
	}

	/// <summary>The information to be split from the image.</summary>
	[PInvokeData("imagehlp.h", MSDNShortId = "NF:imagehlp.SplitSymbols")]
	[Flags]
	public enum SPLITSYM
	{
		/// <summary>
		/// Usually, an image with the symbols split off will still contain a MISC debug directory with the name of the symbol file.
		/// Therefore, the debugger can still find the symbols. Using this flag removes this link. The end result is similar to using
		/// the -debug:none switch on the Microsoft linker.
		/// </summary>
		SPLITSYM_EXTRACT_ALL = 0x00000002,

		/// <summary>This strips off the private CodeView symbolic information when generating the symbol file.</summary>
		SPLITSYM_REMOVE_PRIVATE = 0x00000001,

		/// <summary>The symbol file path contains an alternate path to locate the .pdb file.</summary>
		SPLITSYM_SYMBOLPATH_IS_SRC = 0x00000004,
	}

	/// <summary>Computes the virtual address of each function that is imported.</summary>
	/// <param name="Flags">
	/// <para>The bind options. This parameter can be a combination of the following values.</para>
	/// <list type="table">
	/// <listheader>
	/// <term>Value</term>
	/// <term>Meaning</term>
	/// </listheader>
	/// <item>
	/// <term>BIND_ALL_IMAGES 0x00000004</term>
	/// <term>Bind all images in the call tree for this file.</term>
	/// </item>
	/// <item>
	/// <term>BIND_CACHE_IMPORT_DLLS 0x00000008</term>
	/// <term>Do not discard DLL information in the cache between calls. This improves performance when binding a large number of images.</term>
	/// </item>
	/// <item>
	/// <term>BIND_NO_BOUND_IMPORTS 0x00000001</term>
	/// <term>Do not generate a new import address table.</term>
	/// </item>
	/// <item>
	/// <term>BIND_NO_UPDATE 0x00000002</term>
	/// <term>Do not make changes to the file.</term>
	/// </item>
	/// </list>
	/// </param>
	/// <param name="ImageName">The name of the file to be bound. This value can be a file name, a partial path, or a full path.</param>
	/// <param name="DllPath">The root of the search path to use if the file specified by the ImageName parameter cannot be opened.</param>
	/// <param name="SymbolPath">The root of the path to search for the file's corresponding symbol file.</param>
	/// <param name="StatusRoutine">
	/// A pointer to a status routine. The status routine is called during the progress of the image binding. For more information, see StatusRoutine.
	/// </param>
	/// <returns>
	/// <para>If the function succeeds, the return value is <c>TRUE</c>.</para>
	/// <para>If the function fails, the return value is <c>FALSE</c>. To retrieve extended error information, call GetLastError.</para>
	/// </returns>
	/// <remarks>
	/// <para>
	/// The process of binding an image consists of computing the virtual address of each imported function. The computed virtual
	/// address is then saved in the importing image's Import Address Table (IAT). As a result, the image is loaded much faster,
	/// particularly if it uses many DLLs, because the system loader does not have to compute the address of each imported function.
	/// </para>
	/// <para>If a corresponding symbol file can be located, its time stamp and checksum are updated.</para>
	/// <para>
	/// All ImageHlp functions, such as this one, are single threaded. Therefore, calls from more than one thread to this function will
	/// likely result in unexpected behavior or memory corruption. To avoid this, you must synchronize all concurrent calls from more
	/// than one thread to this function.
	/// </para>
	/// </remarks>
	// https://docs.microsoft.com/en-us/windows/win32/api/imagehlp/nf-imagehlp-bindimageex BOOL IMAGEAPI BindImageEx( DWORD Flags, PCSTR
	// ImageName, PCSTR DllPath, PCSTR SymbolPath, PIMAGEHLP_STATUS_ROUTINE StatusRoutine );
	[DllImport(Lib_ImageHlp, SetLastError = true, ExactSpelling = true)]
	[PInvokeData("imagehlp.h", MSDNShortId = "NF:imagehlp.BindImageEx")]
	[return: MarshalAs(UnmanagedType.Bool)]
	public static extern bool BindImageEx(BINDOPTS Flags, [MarshalAs(UnmanagedType.LPStr)] string ImageName, [MarshalAs(UnmanagedType.LPStr)] string DllPath,
		[MarshalAs(UnmanagedType.LPStr)] string SymbolPath, PIMAGEHLP_STATUS_ROUTINE StatusRoutine);

	/// <summary>Computes the checksum of the specified image file.</summary>
	/// <param name="BaseAddress">The base address of the mapped file. This value is obtained by calling the MapViewOfFile function.</param>
	/// <param name="FileLength">The size of the file, in bytes.</param>
	/// <param name="HeaderSum">
	/// A pointer to a variable that receives the original checksum from the image file, or zero if there is an error.
	/// </param>
	/// <param name="CheckSum">A pointer to the variable that receives the computed checksum.</param>
	/// <returns>
	/// <para>If the function succeeds, the return value is a pointer to the IMAGE_NT_HEADERS structure contained in the mapped image.</para>
	/// <para>If the function fails, the return value is <c>NULL</c>. To retrieve extended error information, call GetLastError.</para>
	/// </returns>
	/// <remarks>
	/// <para>
	/// The <c>CheckSumMappedFile</c> function computes a new checksum for the file and returns it in the CheckSum parameter. This
	/// function is used by any application that creates or modifies an executable image. Checksums are required for kernel-mode drivers
	/// and some system DLLs. The linker computes the original checksum at link time, if you use the appropriate linker switch. For more
	/// details, see your linker documentation.
	/// </para>
	/// <para>
	/// It is recommended that all images have valid checksums. It is the caller's responsibility to place the newly computed checksum
	/// into the mapped image and update the on-disk image of the file.
	/// </para>
	/// <para>
	/// All ImageHlp functions, such as this one, are single threaded. Therefore, calls from more than one thread to this function will
	/// likely result in unexpected behavior or memory corruption. To avoid this, you must synchronize all concurrent calls from more
	/// than one thread to this function.
	/// </para>
	/// </remarks>
	// https://docs.microsoft.com/en-us/windows/win32/api/imagehlp/nf-imagehlp-checksummappedfile PIMAGE_NT_HEADERS IMAGEAPI
	// CheckSumMappedFile( PVOID BaseAddress, DWORD FileLength, PDWORD HeaderSum, PDWORD CheckSum );
	[DllImport(Lib_ImageHlp, SetLastError = true, ExactSpelling = true)]
	[PInvokeData("imagehlp.h", MSDNShortId = "NF:imagehlp.CheckSumMappedFile")]
	public static extern IntPtr CheckSumMappedFile(IntPtr BaseAddress, uint FileLength, out uint HeaderSum, out uint CheckSum);

	/// <summary>Locates and returns the load configuration data of an image.</summary>
	/// <param name="LoadedImage">A pointer to a LOADED_IMAGE structure that is returned from a call to MapAndLoad or ImageLoad.</param>
	/// <param name="ImageConfigInformation">
	/// A pointer to an IMAGE_LOAD_CONFIG_DIRECTORY64 structure that receives the configuration information.
	/// </param>
	/// <returns>
	/// <para>If the function succeeds, the return value is <c>TRUE</c>.</para>
	/// <para>If the function fails, the return value is <c>FALSE</c>. To retrieve extended error information, call GetLastError.</para>
	/// </returns>
	/// <remarks>
	/// <para>The SetImageConfigInformation function locates and changes the load configuration data of an image.</para>
	/// <para>
	/// All ImageHlp functions, such as this one, are single threaded. Therefore, calls from more than one thread to this function will
	/// likely result in unexpected behavior or memory corruption. To avoid this, you must synchronize all concurrent calls from more
	/// than one thread to this function.
	/// </para>
	/// </remarks>
	// https://docs.microsoft.com/en-us/windows/win32/api/imagehlp/nf-imagehlp-getimageconfiginformation BOOL IMAGEAPI
	// GetImageConfigInformation( PLOADED_IMAGE LoadedImage, PIMAGE_LOAD_CONFIG_DIRECTORY ImageConfigInformation );
	[DllImport(Lib_ImageHlp, SetLastError = true, ExactSpelling = true)]
	[PInvokeData("imagehlp.h", MSDNShortId = "NF:imagehlp.GetImageConfigInformation")]
	[return: MarshalAs(UnmanagedType.Bool)]
	public static extern bool GetImageConfigInformation(in LOADED_IMAGE LoadedImage, out IMAGE_LOAD_CONFIG_DIRECTORY32 ImageConfigInformation);

	/// <summary>Retrieves the offset and size of the part of the PE header that is currently unused.</summary>
	/// <param name="LoadedImage">A pointer to a LOADED_IMAGE structure that is returned from a call to MapAndLoad or ImageLoad.</param>
	/// <param name="SizeUnusedHeaderBytes">
	/// A pointer to a variable to receive the size, in bytes, of the part of the image's header which is unused.
	/// </param>
	/// <returns>
	/// <para>If the function succeeds, the return value is the offset from the base address of the first unused header byte.</para>
	/// <para>If the function fails, the return value is zero. To retrieve extended error information, call GetLastError.</para>
	/// </returns>
	/// <remarks>
	/// All ImageHlp functions, such as this one, are single threaded. Therefore, calls from more than one thread to this function will
	/// likely result in unexpected behavior or memory corruption. To avoid this, you must synchronize all concurrent calls from more
	/// than one thread to this function.
	/// </remarks>
	// https://docs.microsoft.com/en-us/windows/win32/api/imagehlp/nf-imagehlp-getimageunusedheaderbytes DWORD IMAGEAPI
	// GetImageUnusedHeaderBytes( PLOADED_IMAGE LoadedImage, PDWORD SizeUnusedHeaderBytes );
	[DllImport(Lib_ImageHlp, SetLastError = true, ExactSpelling = true)]
	[PInvokeData("imagehlp.h", MSDNShortId = "NF:imagehlp.GetImageUnusedHeaderBytes")]
	public static extern uint GetImageUnusedHeaderBytes(in LOADED_IMAGE LoadedImage, out uint SizeUnusedHeaderBytes);

	/// <summary>Adds a certificate to the specified file.</summary>
	/// <param name="FileHandle">
	/// A handle to the image file to be modified. This handle must be opened for FILE_READ_DATA and FILE_WRITE_DATA access.
	/// </param>
	/// <param name="Certificate">
	/// A pointer to a <c>WIN_CERTIFICATE</c> header and all associated sections. The <c>Length</c> member in the certificate header
	/// will be used to determine the length of this buffer.
	/// </param>
	/// <param name="Index">A pointer to a variable that receives the index of the newly added certificate.</param>
	/// <returns>
	/// <para>If the function succeeds, the return value is <c>TRUE</c>.</para>
	/// <para>If the function fails, the return value is <c>FALSE</c>. To retrieve extended error information, call GetLastError.</para>
	/// </returns>
	/// <remarks>
	/// <para>The certificate is added at the end of the existing list of certificates and is assigned an index.</para>
	/// <para>
	/// All ImageHlp functions, such as this one, are single threaded. Therefore, calls from more than one thread to this function will
	/// likely result in unexpected behavior or memory corruption. To avoid this, you must synchronize all concurrent calls from more
	/// than one thread to this function.
	/// </para>
	/// </remarks>
	// https://docs.microsoft.com/en-us/windows/win32/api/imagehlp/nf-imagehlp-imageaddcertificate BOOL IMAGEAPI ImageAddCertificate(
	// HANDLE FileHandle, LPWIN_CERTIFICATE Certificate, PDWORD Index );
	[DllImport(Lib_ImageHlp, SetLastError = true, ExactSpelling = true)]
	[PInvokeData("imagehlp.h", MSDNShortId = "NF:imagehlp.ImageAddCertificate")]
	[return: MarshalAs(UnmanagedType.Bool)]
	public static extern bool ImageAddCertificate(HFILE FileHandle, [In] IntPtr Certificate, out uint Index);

	/// <summary>Retrieves information about the certificates currently contained in an image file.</summary>
	/// <param name="FileHandle">A handle to the image file to be examined. This handle must be opened for FILE_READ_DATA access.</param>
	/// <param name="TypeFilter">
	/// The certificate section type to be used as a filter when returning certificate information. CERT_SECTION_TYPE_ANY should be
	/// passed for information on all section types present in the image.
	/// </param>
	/// <param name="CertificateCount">
	/// A pointer to a variable that receives the number of certificates in the image containing sections of the type specified by the
	/// TypeFilter parameter. If none are found, this parameter is zero.
	/// </param>
	/// <param name="Indices">
	/// Optionally provides a buffer to use to return an array of indices to the certificates containing sections of the specified type.
	/// No ordering should be assumed for the index values, nor are they guaranteed to be contiguous when CERT_SECTION_TYPE_ANY is queried.
	/// </param>
	/// <param name="IndexCount">
	/// The size of the Indices buffer, in <c>DWORDs</c>. This parameter will be examined whenever Indices is present. If
	/// CertificateCount is greater than IndexCount, Indices will be filled in with the first IndexCount sections found in the image;
	/// any others will not be returned.
	/// </param>
	/// <returns>
	/// <para>If the function succeeds, the return value is <c>TRUE</c>.</para>
	/// <para>If the function fails, the return value is <c>FALSE</c>. To retrieve extended error information, call GetLastError.</para>
	/// </returns>
	/// <remarks>
	/// <para>
	/// The <c>ImageEnumerateCertificates</c> function returns information about the certificates currently contained in an image file.
	/// It has filtering capabilities which allow certificates containing sections of any single type (or of any type) to be returned.
	/// </para>
	/// <para>
	/// After the indices of interesting certificates are discovered, they can be passed to the ImageGetCertificateData function to
	/// obtain the actual bodies of the certificates.
	/// </para>
	/// <para>
	/// All ImageHlp functions, such as this one, are single threaded. Therefore, calls from more than one thread to this function will
	/// likely result in unexpected behavior or memory corruption. To avoid this, you must synchronize all concurrent calls from more
	/// than one thread to this function.
	/// </para>
	/// </remarks>
	// https://docs.microsoft.com/en-us/windows/win32/api/imagehlp/nf-imagehlp-imageenumeratecertificates BOOL IMAGEAPI
	// ImageEnumerateCertificates( HANDLE FileHandle, WORD TypeFilter, PDWORD CertificateCount, PDWORD Indices, DWORD IndexCount );
	[DllImport(Lib_ImageHlp, SetLastError = true, ExactSpelling = true)]
	[PInvokeData("imagehlp.h", MSDNShortId = "NF:imagehlp.ImageEnumerateCertificates")]
	[return: MarshalAs(UnmanagedType.Bool)]
	public static extern bool ImageEnumerateCertificates(HFILE FileHandle, ushort TypeFilter, out uint CertificateCount,
		[Optional, In, Out, MarshalAs(UnmanagedType.LPArray, SizeParamIndex = 4)] uint[]? Indices, uint IndexCount);

	/// <summary>Retrieves a complete certificate from a file.</summary>
	/// <param name="FileHandle">A handle to the image file. This handle must be opened for <c>FILE_READ_DATA</c> access.</param>
	/// <param name="CertificateIndex">The index of the certificate to be returned.</param>
	/// <param name="Certificate">
	/// A pointer to a <c>WIN_CERTIFICATE</c> structure that receives the certificate data. If the buffer is not large enough to contain
	/// the structure, the function fails and the last error code is set to <c>ERROR_INSUFFICIENT_BUFFER</c>.
	/// </param>
	/// <param name="RequiredLength">
	/// On input, this parameter specifies the length of the Certificate buffer in bytes. On success, it receives the length of the certificate.
	/// </param>
	/// <returns>
	/// <para>If the function succeeds, the return value is <c>TRUE</c>.</para>
	/// <para>If the function fails, the return value is <c>FALSE</c>. To retrieve extended error information, call GetLastError.</para>
	/// </returns>
	/// <remarks>
	/// <para>The <c>WIN_CERTIFICATE</c> structure is defined as follows:</para>
	/// <para>
	/// <code>typedef struct _WIN_CERTIFICATE { DWORD dwLength; WORD wRevision; WORD wCertificateType; // WIN_CERT_TYPE_xxx BYTE bCertificate[ANYSIZE_ARRAY]; } WIN_CERTIFICATE, *LPWIN_CERTIFICATE;</code>
	/// </para>
	/// <para>
	/// All ImageHlp functions, such as this one, are single threaded. Therefore, calls from more than one thread to this function will
	/// likely result in unexpected behavior or memory corruption. To avoid this, you must synchronize all concurrent calls from more
	/// than one thread to this function.
	/// </para>
	/// </remarks>
	// https://docs.microsoft.com/en-us/windows/win32/api/imagehlp/nf-imagehlp-imagegetcertificatedata BOOL IMAGEAPI
	// ImageGetCertificateData( HANDLE FileHandle, DWORD CertificateIndex, LPWIN_CERTIFICATE Certificate, PDWORD RequiredLength );
	[DllImport(Lib_ImageHlp, SetLastError = true, ExactSpelling = true)]
	[PInvokeData("imagehlp.h", MSDNShortId = "NF:imagehlp.ImageGetCertificateData")]
	[return: MarshalAs(UnmanagedType.Bool)]
	public static extern bool ImageGetCertificateData(HFILE FileHandle, uint CertificateIndex, [Out] IntPtr Certificate, ref uint RequiredLength);

	/// <summary>Retrieves the header of the specified certificate, up to, but not including, the section offset array.</summary>
	/// <param name="FileHandle">A handle to the image file. This handle must be opened for FILE_READ_DATA access.</param>
	/// <param name="CertificateIndex">The index of the certificate whose header is to be returned.</param>
	/// <param name="Certificateheader">A pointer to the <c>WIN_CERTIFICATE</c> structure that receives the certificate header.</param>
	/// <returns>
	/// <para>If the function succeeds, the return value is <c>TRUE</c>.</para>
	/// <para>If the function fails, the return value is <c>FALSE</c>. To retrieve extended error information, call GetLastError.</para>
	/// </returns>
	/// <remarks>
	/// All ImageHlp functions, such as this one, are single threaded. Therefore, calls from more than one thread to this function will
	/// likely result in unexpected behavior or memory corruption. To avoid this, you must synchronize all concurrent calls from more
	/// than one thread to this function.
	/// </remarks>
	// https://docs.microsoft.com/en-us/windows/win32/api/imagehlp/nf-imagehlp-imagegetcertificateheader BOOL IMAGEAPI
	// ImageGetCertificateHeader( HANDLE FileHandle, DWORD CertificateIndex, LPWIN_CERTIFICATE Certificateheader );
	[DllImport(Lib_ImageHlp, SetLastError = true, ExactSpelling = true)]
	[PInvokeData("imagehlp.h", MSDNShortId = "NF:imagehlp.ImageGetCertificateHeader")]
	[return: MarshalAs(UnmanagedType.Bool)]
	public static extern bool ImageGetCertificateHeader(HFILE FileHandle, uint CertificateIndex, [In, Out] IntPtr Certificateheader);

	/// <summary>Retrieves the requested data from the specified image file.</summary>
	/// <param name="FileHandle">A handle to the image file. This handle must be opened for FILE_READ_DATA access.</param>
	/// <param name="DigestLevel">
	/// <para>
	/// The aspects of the image that are to be included in the returned data stream. This parameter can be one or more of the following values.
	/// </para>
	/// <list type="table">
	/// <listheader>
	/// <term>Value</term>
	/// <term>Meaning</term>
	/// </listheader>
	/// <item>
	/// <term>CERT_PE_IMAGE_DIGEST_ALL_IMPORT_INFO 0x04</term>
	/// <term>Include all import information.</term>
	/// </item>
	/// <item>
	/// <term>CERT_PE_IMAGE_DIGEST_DEBUG_INFO 0x01</term>
	/// <term>Include symbolic debugging information.</term>
	/// </item>
	/// <item>
	/// <term>CERT_PE_IMAGE_DIGEST_RESOURCES 0x02</term>
	/// <term>Include resource information.</term>
	/// </item>
	/// </list>
	/// </param>
	/// <param name="DigestFunction">A pointer to a callback routine to process the data. For more information, see DigestFunction.</param>
	/// <param name="DigestHandle">A user-supplied handle to the digest. This parameter is passed to DigestFunction as the first argument.</param>
	/// <returns>
	/// <para>If the function succeeds, the return value is <c>TRUE</c>.</para>
	/// <para>If the function fails, the return value is <c>FALSE</c>. To retrieve extended error information, call GetLastError.</para>
	/// </returns>
	/// <remarks>
	/// <para>
	/// The <c>ImageGetDigestStream</c> function returns the data to be digested from a specified image file, subject to the passed
	/// DigestLevel parameter. The order of the bytes will be consistent for different calls, which is required to ensure that the same
	/// message digest is always produced from the retrieved byte stream.
	/// </para>
	/// <para>
	/// To ensure cross-platform compatibility, all implementations of this function must behave in a consistent manner with respect to
	/// the order in which the various parts of the image file are returned.
	/// </para>
	/// <para>Data should be returned in the following order:</para>
	/// <list type="number">
	/// <item>
	/// <term>Image (executable and static data) information.</term>
	/// </item>
	/// <item>
	/// <term>Resource data.</term>
	/// </item>
	/// <item>
	/// <term>Debugging information.</term>
	/// </item>
	/// </list>
	/// <para>If any of these are not specified, the remaining parts must be returned in the same order.</para>
	/// <para>
	/// All ImageHlp functions, such as this one, are single threaded. Therefore, calls from more than one thread to this function will
	/// likely result in unexpected behavior or memory corruption. To avoid this, you must synchronize all concurrent calls from more
	/// than one thread to this function.
	/// </para>
	/// </remarks>
	// https://docs.microsoft.com/en-us/windows/win32/api/imagehlp/nf-imagehlp-imagegetdigeststream BOOL IMAGEAPI ImageGetDigestStream(
	// HANDLE FileHandle, DWORD DigestLevel, DIGEST_FUNCTION DigestFunction, DIGEST_HANDLE DigestHandle );
	[DllImport(Lib_ImageHlp, SetLastError = true, ExactSpelling = true)]
	[PInvokeData("imagehlp.h", MSDNShortId = "NF:imagehlp.ImageGetDigestStream")]
	[return: MarshalAs(UnmanagedType.Bool)]
	public static extern bool ImageGetDigestStream(HFILE FileHandle, uint DigestLevel, DIGEST_FUNCTION DigestFunction, IntPtr DigestHandle);

	/// <summary>Maintains a list of loaded DLLs.</summary>
	/// <param name="DllName">The name of the image.</param>
	/// <param name="DllPath">
	/// The path used to locate the image if the name provided cannot be found. If <c>NULL</c> is used, then the search path rules set
	/// forth in the SearchPath function apply.
	/// </param>
	/// <returns>
	/// <para>If the function succeeds, the return value is a pointer to a LOADED_IMAGE structure.</para>
	/// <para>If the function fails, the return value is <c>NULL</c>. To retrieve extended error information, call GetLastError.</para>
	/// </returns>
	/// <remarks>
	/// <para>
	/// The <c>ImageLoad</c> function is used to maintain a list of loaded DLLs. If the image has already been loaded, the prior
	/// LOADED_IMAGE is returned. Otherwise, the new image is added to the list.
	/// </para>
	/// <para>The LOADED_IMAGE structure must be deallocated by the ImageUnload function.</para>
	/// <para>
	/// All ImageHlp functions, such as this one, are single threaded. Therefore, calls from more than one thread to this function will
	/// likely result in unexpected behavior or memory corruption. To avoid this, you must synchronize all concurrent calls from more
	/// than one thread to this function.
	/// </para>
	/// </remarks>
	// https://docs.microsoft.com/en-us/windows/win32/api/imagehlp/nf-imagehlp-imageload PLOADED_IMAGE IMAGEAPI ImageLoad( PCSTR
	// DllName, PCSTR DllPath );
	[DllImport(Lib_ImageHlp, SetLastError = true, ExactSpelling = true)]
	[PInvokeData("imagehlp.h", MSDNShortId = "NF:imagehlp.ImageLoad")]
	public static extern SafeLOADED_IMAGE ImageLoad([MarshalAs(UnmanagedType.LPStr)] string DllName, [MarshalAs(UnmanagedType.LPStr)] string DllPath);

	/// <summary>Removes the specified certificate from the given file.</summary>
	/// <param name="FileHandle">
	/// A handle to the image file to be modified. This handle must be opened for FILE_READ_DATA and FILE_WRITE_DATA access.
	/// </param>
	/// <param name="Index">The index of the certificate to be removed.</param>
	/// <returns>
	/// <para>If the function succeeds, the return value is <c>TRUE</c>.</para>
	/// <para>If the function fails, the return value is <c>FALSE</c>. To retrieve extended error information, call GetLastError.</para>
	/// </returns>
	/// <remarks>
	/// All ImageHlp functions, such as this one, are single threaded. Therefore, calls from more than one thread to this function will
	/// likely result in unexpected behavior or memory corruption. To avoid this, you must synchronize all concurrent calls from more
	/// than one thread to this function.
	/// </remarks>
	// https://docs.microsoft.com/en-us/windows/win32/api/imagehlp/nf-imagehlp-imageremovecertificate BOOL IMAGEAPI
	// ImageRemoveCertificate( HANDLE FileHandle, DWORD Index );
	[DllImport(Lib_ImageHlp, SetLastError = true, ExactSpelling = true)]
	[PInvokeData("imagehlp.h", MSDNShortId = "NF:imagehlp.ImageRemoveCertificate")]
	[return: MarshalAs(UnmanagedType.Bool)]
	public static extern bool ImageRemoveCertificate(HFILE FileHandle, uint Index);

	/// <summary>Deallocates resources from a previous call to the ImageLoad function.</summary>
	/// <param name="LoadedImage">A pointer to a LOADED_IMAGE structure that is returned from a call to the ImageLoad function.</param>
	/// <returns>
	/// <para>If the function succeeds, the return value is <c>TRUE</c>.</para>
	/// <para>If the function fails, the return value is <c>FALSE</c>. To retrieve extended error information, call GetLastError.</para>
	/// <para>
	/// ImageLoad and <c>ImageUnload</c> share internal data that can be corrupted if multiple consecutive calls to <c>ImageLoad</c> are
	/// performed. Therefore, make sure that you have called <c>ImageLoad</c> only once before calling <c>ImageUnload</c>.
	/// </para>
	/// </returns>
	/// <remarks>
	/// All ImageHlp functions, such as this one, are single threaded. Therefore, calls from more than one thread to this function will
	/// likely result in unexpected behavior or memory corruption. To avoid this, you must synchronize all concurrent calls from more
	/// than one thread to this function.
	/// </remarks>
	// https://docs.microsoft.com/en-us/windows/win32/api/imagehlp/nf-imagehlp-imageunload BOOL IMAGEAPI ImageUnload( PLOADED_IMAGE
	// LoadedImage );
	[DllImport(Lib_ImageHlp, SetLastError = true, ExactSpelling = true)]
	[PInvokeData("imagehlp.h", MSDNShortId = "NF:imagehlp.ImageUnload")]
	[return: MarshalAs(UnmanagedType.Bool)]
	public static extern bool ImageUnload(IntPtr LoadedImage);

	/// <summary>Maps an image and preloads data from the mapped file.</summary>
	/// <param name="ImageName">The file name of the image (executable file or DLL) that is loaded.</param>
	/// <param name="DllPath">
	/// The path used to locate the image if the name provided cannot be found. If this parameter is <c>NULL</c>, then the search path
	/// rules set using the SearchPath function apply.
	/// </param>
	/// <param name="LoadedImage">A pointer to a LOADED_IMAGE structure that receives information about the image after it is loaded.</param>
	/// <param name="DotDll">
	/// The default extension to be used if the image name does not contain a file name extension. If the value is <c>TRUE</c>, a .DLL
	/// extension is used. If the value is <c>FALSE</c>, then an .EXE extension is used.
	/// </param>
	/// <param name="ReadOnly">
	/// The access mode. If this value is <c>TRUE</c>, the file is mapped for read-access only. If the value is <c>FALSE</c>, the file
	/// is mapped for read and write access.
	/// </param>
	/// <returns>
	/// <para>If the function succeeds, the return value is <c>TRUE</c>.</para>
	/// <para>If the function fails, the return value is <c>FALSE</c>. To retrieve extended error information, call GetLastError.</para>
	/// </returns>
	/// <remarks>
	/// <para>
	/// The <c>MapAndLoad</c> function maps an image and preloads data from the mapped file. The corresponding function, UnMapAndLoad,
	/// must be used to deallocate all resources that are allocated by the <c>MapAndLoad</c> function.
	/// </para>
	/// <para>
	/// All ImageHlp functions, such as this one, are single threaded. Therefore, calls from more than one thread to this function will
	/// likely result in unexpected behavior or memory corruption. To avoid this, you must synchronize all concurrent calls from more
	/// than one thread to this function.
	/// </para>
	/// </remarks>
	// https://docs.microsoft.com/en-us/windows/win32/api/imagehlp/nf-imagehlp-mapandload BOOL IMAGEAPI MapAndLoad( PCSTR ImageName,
	// PCSTR DllPath, PLOADED_IMAGE LoadedImage, BOOL DotDll, BOOL ReadOnly );
	[DllImport(Lib_ImageHlp, SetLastError = true, ExactSpelling = true, CharSet = CharSet.Ansi)]
	[PInvokeData("imagehlp.h", MSDNShortId = "NF:imagehlp.MapAndLoad")]
	[return: MarshalAs(UnmanagedType.Bool)]
	public static extern bool MapAndLoad(string ImageName, [Optional] string? DllPath, out LOADED_IMAGE LoadedImage, [MarshalAs(UnmanagedType.Bool)] bool DotDll, [MarshalAs(UnmanagedType.Bool)] bool ReadOnly);

	/// <summary>Computes the checksum of the specified file.</summary>
	/// <param name="Filename">The file name of the file for which the checksum is to be computed.</param>
	/// <param name="HeaderSum">
	/// A pointer to a variable that receives the original checksum from the image file, or zero if there is an error.
	/// </param>
	/// <param name="CheckSum">A pointer to a variable that receives the computed checksum.</param>
	/// <returns>
	/// <para>If the function succeeds, the return value is CHECKSUM_SUCCESS (0).</para>
	/// <para>If the function fails, the return value is one of the following.</para>
	/// <list type="table">
	/// <listheader>
	/// <term>Return code/value</term>
	/// <term>Description</term>
	/// </listheader>
	/// <item>
	/// <term>CHECKSUM_MAP_FAILURE 2</term>
	/// <term>Could not map the file.</term>
	/// </item>
	/// <item>
	/// <term>CHECKSUM_MAPVIEW_FAILURE 3</term>
	/// <term>Could not map a view of the file.</term>
	/// </item>
	/// <item>
	/// <term>CHECKSUM_OPEN_FAILURE 1</term>
	/// <term>Could not open the file.</term>
	/// </item>
	/// <item>
	/// <term>CHECKSUM_UNICODE_FAILURE 4</term>
	/// <term>Could not convert the file name to Unicode.</term>
	/// </item>
	/// </list>
	/// </returns>
	/// <remarks>
	/// <para>
	/// The <c>MapFileAndCheckSum</c> function computes a new checksum for the file and returns it in the CheckSum parameter. This
	/// function is used by any application that creates or modifies an executable image. Checksums are required for kernel-mode drivers
	/// and some system DLLs. The linker computes the original checksum at link time, if you use the appropriate linker switch. For more
	/// details, see your linker documentation.
	/// </para>
	/// <para>
	/// It is recommended that all images have valid checksums. It is the caller's responsibility to place the newly computed checksum
	/// into the mapped image and update the on-disk image of the file.
	/// </para>
	/// <para>
	/// Passing a Filename parameter that does not point to a valid executable image will produce unpredictable results. Any user of
	/// this function is encouraged to make sure that a valid executable image is being passed.
	/// </para>
	/// <para>
	/// All ImageHlp functions, such as this one, are single threaded. Therefore, calls from more than one thread to this function will
	/// likely result in unexpected behavior or memory corruption. To avoid this, you must synchronize all concurrent calls from more
	/// than one thread to this function.
	/// </para>
	/// <para>
	/// <c>Note</c> The Unicode implementation of this function calls the ASCII implementation and as a result, the function can fail if
	/// the codepage does not support the characters in the path. For example, if you pass a non-English Unicode file path, and the
	/// default codepage is English, the unrecognized non-English wide chars are converted to "??" and the file cannot be opened (the
	/// function returns CHECKSUM_OPEN_FAILURE).
	/// </para>
	/// </remarks>
	// https://docs.microsoft.com/en-us/windows/win32/api/imagehlp/nf-imagehlp-mapfileandchecksuma DWORD IMAGEAPI MapFileAndCheckSumA(
	// PCSTR Filename, PDWORD HeaderSum, PDWORD CheckSum );
	[DllImport(Lib_ImageHlp, SetLastError = false, CharSet = CharSet.Auto)]
	[PInvokeData("imagehlp.h", MSDNShortId = "NF:imagehlp.MapFileAndCheckSumA")]
	public static extern CHECKSUM MapFileAndCheckSum([MarshalAs(UnmanagedType.LPTStr)] string Filename, out uint HeaderSum, out uint CheckSum);

	/// <summary>
	/// <para>Changes the load address for the specified image, which reduces the required load time for a DLL.</para>
	/// <para>Alternatively, you can use the Rebase tool. This tool is available in Visual Studio and the Windows SDK.</para>
	/// <para>Note that this function is implemented as a call to the ReBaseImage64 function.</para>
	/// </summary>
	/// <param name="CurrentImageName">
	/// The name of the file to be rebased. You must specify the full path to the file unless the module is in the current working
	/// directory of the calling process.
	/// </param>
	/// <param name="SymbolPath">
	/// The path used to find the corresponding symbol file. Specify this path for executable images that have symbolic information
	/// because when image addresses change, the corresponding symbol database file (PDB) may also need to be changed. Note that even if
	/// the symbol path is not valid, the function will succeed if it is able to rebases your image.
	/// </param>
	/// <param name="fReBase">If this value is <c>TRUE</c>, the image is rebased. Otherwise, the image is not rebased.</param>
	/// <param name="fRebaseSysfileOk">
	/// If this value is <c>TRUE</c>, the system image is rebased. Otherwise, the system image is not rebased.
	/// </param>
	/// <param name="fGoingDown">If this value is <c>TRUE</c>, the image can be rebased below the given base; otherwise, it cannot.</param>
	/// <param name="CheckImageSize">The maximum size that the image can grow to, in bytes, or zero if there is no limit.</param>
	/// <param name="OldImageSize">A pointer to a variable that receives the original image size, in bytes.</param>
	/// <param name="OldImageBase">A pointer to a variable that receives the original image base.</param>
	/// <param name="NewImageSize">A pointer to a variable that receives the new image size after the rebase operation, in bytes.</param>
	/// <param name="NewImageBase">
	/// The base address to use for rebasing the image. If the address is not available and the fGoingDown parameter is set to
	/// <c>TRUE</c>, the function finds a new base address and sets this parameter to the new base address. If fGoingDown is
	/// <c>FALSE</c>, the function finds a new base address but does not set this parameter to the new base address.
	/// </param>
	/// <param name="TimeStamp">
	/// <para>
	/// The new time date stamp for the image file header. The value must be represented in the number of seconds elapsed since midnight
	/// (00:00:00), January 1, 1970, Universal Coordinated Time, according to the system clock.
	/// </para>
	/// <para>If this parameter is 0, the current file header time date stamp is incremented by 1 second.</para>
	/// </param>
	/// <returns>
	/// <para>If the function succeeds, the return value is <c>TRUE</c>.</para>
	/// <para>If the function fails, the return value is <c>FALSE</c>. To retrieve extended error information, call GetLastError.</para>
	/// </returns>
	/// <remarks>
	/// <para>
	/// The <c>ReBaseImage</c> function changes the desired load address for the specified image. This operation involves reading the
	/// entire image and updating all fixups, debugging information, and checksum. You can rebase an image to reduce the required load
	/// time for its DLLs. If an application can rely on a DLL being loaded at the desired load address, then the system loader does not
	/// have to relocate the image. The image is simply loaded into the application's virtual address space and the DllMain function is
	/// called, if one is present.
	/// </para>
	/// <para>
	/// All ImageHlp functions, such as this one, are single threaded. Therefore, calls from more than one thread to this function will
	/// likely result in unexpected behavior or memory corruption. To avoid this, you must synchronize all concurrent calls from more
	/// than one thread to this function.
	/// </para>
	/// <para>You cannot rebase DLLs that link with /DYNAMICBASE or that reside in protected directories, such as the System32 folder.</para>
	/// <para>As an alternative to using this function, see the /BASE linker option.</para>
	/// </remarks>
	// https://docs.microsoft.com/en-us/windows/win32/api/imagehlp/nf-imagehlp-rebaseimage BOOL IMAGEAPI ReBaseImage( PCSTR
	// CurrentImageName, PCSTR SymbolPath, BOOL fReBase, BOOL fRebaseSysfileOk, BOOL fGoingDown, ULONG CheckImageSize, ULONG
	// *OldImageSize, ULONG_PTR *OldImageBase, ULONG *NewImageSize, ULONG_PTR *NewImageBase, ULONG TimeStamp );
	[DllImport(Lib_ImageHlp, SetLastError = true, ExactSpelling = true, CharSet = CharSet.Ansi)]
	[PInvokeData("imagehlp.h", MSDNShortId = "NF:imagehlp.ReBaseImage")]
	[return: MarshalAs(UnmanagedType.Bool)]
	public static extern bool ReBaseImage(string CurrentImageName, string SymbolPath, [MarshalAs(UnmanagedType.Bool)] bool fReBase, [MarshalAs(UnmanagedType.Bool)] bool fRebaseSysfileOk,
		[MarshalAs(UnmanagedType.Bool)] bool fGoingDown, uint CheckImageSize, out uint OldImageSize, out IntPtr OldImageBase, out uint NewImageSize, ref IntPtr NewImageBase, uint TimeStamp);

	/// <summary>
	/// <para>Changes the load address for the specified image, which reduces the required load time for a DLL.</para>
	/// <para>Alternatively, you can use the Rebase tool. This tool is available in Visual Studio and the Windows SDK.</para>
	/// </summary>
	/// <param name="CurrentImageName">
	/// The name of the file to be rebased. You must specify the full path to the file unless the module is in the current working
	/// directory of the calling process.
	/// </param>
	/// <param name="SymbolPath">
	/// The path used to find the corresponding symbol file. Specify this path for executable images that have symbolic information
	/// because when image addresses change, the corresponding symbol database file (PDB) may also need to be changed. Note that even if
	/// the symbol path is not valid, the function will succeed if it is able to rebases your image.
	/// </param>
	/// <param name="fReBase">If this value is <c>TRUE</c>, the image is rebased. Otherwise, the image is not rebased.</param>
	/// <param name="fRebaseSysfileOk">
	/// If this value is <c>TRUE</c>, the system image is rebased. Otherwise, the system image is not rebased.
	/// </param>
	/// <param name="fGoingDown">If this value is <c>TRUE</c>, the image can be rebased below the given base; otherwise, it cannot.</param>
	/// <param name="CheckImageSize">The maximum size that the image can grow to, in bytes, or zero if there is no limit.</param>
	/// <param name="OldImageSize">A pointer to a variable that receives the original image size, in bytes.</param>
	/// <param name="OldImageBase">A pointer to a variable that receives the original image base.</param>
	/// <param name="NewImageSize">A pointer to a variable that receives the new image size after the rebase operation, in bytes.</param>
	/// <param name="NewImageBase">
	/// The base address to use for rebasing the image. If the address is not available and the fGoingDown parameter is set to
	/// <c>TRUE</c>, the function finds a new base address and sets this parameter to the new base address. If fGoingDown is
	/// <c>FALSE</c>, the function finds a new base address but does not set this parameter to the new base address.
	/// </param>
	/// <param name="TimeStamp">
	/// <para>
	/// The new time date stamp for the image file header. The value must be represented in the number of seconds elapsed since midnight
	/// (00:00:00), January 1, 1970, Universal Coordinated Time, according to the system clock.
	/// </para>
	/// <para>If this parameter is 0, the current file header time date stamp is incremented by 1 second.</para>
	/// </param>
	/// <returns>
	/// <para>If the function succeeds, the return value is <c>TRUE</c>.</para>
	/// <para>If the function fails, the return value is <c>FALSE</c>. To retrieve extended error information, call GetLastError.</para>
	/// </returns>
	/// <remarks>
	/// <para>
	/// The <c>ReBaseImage64</c> function changes the desired load address for the specified image. This operation involves reading the
	/// entire image and updating all fixups, debugging information, and checksum. You can rebase an image to reduce the required load
	/// time for its DLLs. If an application can rely on a DLL being loaded at the desired load address, then the system loader does not
	/// have to relocate the image. The image is simply loaded into the application's virtual address space and the DllMain function is
	/// called, if one is present.
	/// </para>
	/// <para>
	/// All ImageHlp functions, such as this one, are single threaded. Therefore, calls from more than one thread to this function will
	/// likely result in unexpected behavior or memory corruption. To avoid this, you must synchronize all concurrent calls from more
	/// than one thread to this function.
	/// </para>
	/// <para>You cannot rebase DLLs that link with /DYNAMICBASE or that reside in protected directories, such as the System32 folder.</para>
	/// <para>As an alternative to using this function, see the /BASE linker option.</para>
	/// </remarks>
	// https://docs.microsoft.com/en-us/windows/win32/api/imagehlp/nf-imagehlp-rebaseimage64 BOOL IMAGEAPI ReBaseImage64( PCSTR
	// CurrentImageName, PCSTR SymbolPath, BOOL fReBase, BOOL fRebaseSysfileOk, BOOL fGoingDown, ULONG CheckImageSize, ULONG
	// *OldImageSize, ULONG64 *OldImageBase, ULONG *NewImageSize, ULONG64 *NewImageBase, ULONG TimeStamp );
	[DllImport(Lib_ImageHlp, SetLastError = true, ExactSpelling = true, CharSet = CharSet.Ansi)]
	[PInvokeData("imagehlp.h", MSDNShortId = "NF:imagehlp.ReBaseImage64")]
	[return: MarshalAs(UnmanagedType.Bool)]
	public static extern bool ReBaseImage64(string CurrentImageName, string SymbolPath, [MarshalAs(UnmanagedType.Bool)] bool fReBase, [MarshalAs(UnmanagedType.Bool)] bool fRebaseSysfileOk,
		[MarshalAs(UnmanagedType.Bool)] bool fGoingDown, uint CheckImageSize, out uint OldImageSize, out ulong OldImageBase, out uint NewImageSize, ref ulong NewImageBase, uint TimeStamp);

	/// <summary>Locates and changes the load configuration data of an image.</summary>
	/// <param name="LoadedImage">A pointer to a LOADED_IMAGE structure that is returned from a call to MapAndLoad or <c>LoadImage</c>.</param>
	/// <param name="ImageConfigInformation">A pointer to an IMAGE_LOAD_CONFIG_DIRECTORY64 structure.</param>
	/// <returns>
	/// <para>If the function succeeds, the return value is <c>TRUE</c>.</para>
	/// <para>If the function fails, the return value is <c>FALSE</c>. To retrieve extended error information, call GetLastError.</para>
	/// </returns>
	/// <remarks>
	/// <para>The <c>SetImageConfigInformation</c> function locates and returns the load configuration data of an image.</para>
	/// <para>
	/// All ImageHlp functions, such as this one, are single threaded. Therefore, calls from more than one thread to this function will
	/// likely result in unexpected behavior or memory corruption. To avoid this, you must synchronize all concurrent calls from more
	/// than one thread to this function.
	/// </para>
	/// </remarks>
	// https://docs.microsoft.com/en-us/windows/win32/api/imagehlp/nf-imagehlp-setimageconfiginformation BOOL IMAGEAPI
	// SetImageConfigInformation( PLOADED_IMAGE LoadedImage, PIMAGE_LOAD_CONFIG_DIRECTORY ImageConfigInformation );
	[DllImport(Lib_ImageHlp, SetLastError = true, ExactSpelling = true)]
	[PInvokeData("imagehlp.h", MSDNShortId = "NF:imagehlp.SetImageConfigInformation")]
	[return: MarshalAs(UnmanagedType.Bool)]
	public static extern bool SetImageConfigInformation(ref LOADED_IMAGE LoadedImage, in IMAGE_LOAD_CONFIG_DIRECTORY32 ImageConfigInformation);

	/// <summary>Locates and changes the load configuration data of an image.</summary>
	/// <param name="LoadedImage">A pointer to a LOADED_IMAGE structure that is returned from a call to MapAndLoad or <c>LoadImage</c>.</param>
	/// <param name="ImageConfigInformation">A pointer to an IMAGE_LOAD_CONFIG_DIRECTORY64 structure.</param>
	/// <returns>
	/// <para>If the function succeeds, the return value is <c>TRUE</c>.</para>
	/// <para>If the function fails, the return value is <c>FALSE</c>. To retrieve extended error information, call GetLastError.</para>
	/// </returns>
	/// <remarks>
	/// <para>The <c>SetImageConfigInformation</c> function locates and returns the load configuration data of an image.</para>
	/// <para>
	/// All ImageHlp functions, such as this one, are single threaded. Therefore, calls from more than one thread to this function will
	/// likely result in unexpected behavior or memory corruption. To avoid this, you must synchronize all concurrent calls from more
	/// than one thread to this function.
	/// </para>
	/// </remarks>
	// https://docs.microsoft.com/en-us/windows/win32/api/imagehlp/nf-imagehlp-setimageconfiginformation BOOL IMAGEAPI
	// SetImageConfigInformation( PLOADED_IMAGE LoadedImage, PIMAGE_LOAD_CONFIG_DIRECTORY ImageConfigInformation );
	[DllImport(Lib_ImageHlp, SetLastError = true, ExactSpelling = true)]
	[PInvokeData("imagehlp.h", MSDNShortId = "NF:imagehlp.SetImageConfigInformation")]
	[return: MarshalAs(UnmanagedType.Bool)]
	public static extern bool SetImageConfigInformation(ref LOADED_IMAGE LoadedImage, in IMAGE_LOAD_CONFIG_DIRECTORY64 ImageConfigInformation);

	/// <summary>Strips symbols from the specified image.</summary>
	/// <param name="ImageName">The name of the image from which to split symbols.</param>
	/// <param name="SymbolsPath">The subdirectory for storing symbols. This parameter is optional.</param>
	/// <param name="SymbolFilePath">The name of the generated symbol file. This file typically has a .dbg extension.</param>
	/// <param name="Flags">
	/// <para>The information to be split from the image. This parameter can be zero or a combination of the following values.</para>
	/// <list type="table">
	/// <listheader>
	/// <term>Value</term>
	/// <term>Meaning</term>
	/// </listheader>
	/// <item>
	/// <term>SPLITSYM_EXTRACT_ALL 0x00000002</term>
	/// <term>
	/// Usually, an image with the symbols split off will still contain a MISC debug directory with the name of the symbol file.
	/// Therefore, the debugger can still find the symbols. Using this flag removes this link. The end result is similar to using the
	/// -debug:none switch on the Microsoft linker.
	/// </term>
	/// </item>
	/// <item>
	/// <term>SPLITSYM_REMOVE_PRIVATE 0x00000001</term>
	/// <term>This strips off the private CodeView symbolic information when generating the symbol file.</term>
	/// </item>
	/// <item>
	/// <term>SPLITSYM_SYMBOLPATH_IS_SRC 0x00000004</term>
	/// <term>The symbol file path contains an alternate path to locate the .pdb file.</term>
	/// </item>
	/// </list>
	/// </param>
	/// <returns>
	/// <para>If the function succeeds, the return value is <c>TRUE</c>.</para>
	/// <para>If the function fails, the return value is <c>FALSE</c>. To retrieve extended error information, call GetLastError.</para>
	/// </returns>
	/// <remarks>
	/// <para>
	/// The <c>SplitSymbols</c> function should be used when stripping symbols from an image. It will create a symbol file that all
	/// compatible debuggers understand. The format is defined in WinNT.h and consists of an image header, followed by the array of
	/// section headers, the FPO information, and all debugging symbolic information from the image.
	/// </para>
	/// <para>
	/// If the SymbolsPath parameter is <c>NULL</c>, the symbol file is stored in the directory where the image exists. Otherwise, it is
	/// stored in the subdirectory below SymbolsPath that matches the extension of the image. Using this method reduces the chances of
	/// symbol file collision. For example, the symbols for myapp.exe will be in the SymbolsPath\exe directory and the symbols for
	/// myapp.dll will be in the SymbolsPath\dll directory.
	/// </para>
	/// <para>
	/// All ImageHlp functions, such as this one, are single threaded. Therefore, calls from more than one thread to this function will
	/// likely result in unexpected behavior or memory corruption. To avoid this, you must synchronize all concurrent calls from more
	/// than one thread to this function.
	/// </para>
	/// </remarks>
	// https://docs.microsoft.com/en-us/windows/win32/api/imagehlp/nf-imagehlp-splitsymbols BOOL IMAGEAPI SplitSymbols( PSTR ImageName,
	// PCSTR SymbolsPath, PSTR SymbolFilePath, ULONG Flags );
	[DllImport(Lib_ImageHlp, SetLastError = true, ExactSpelling = true, CharSet = CharSet.Ansi)]
	[PInvokeData("imagehlp.h", MSDNShortId = "NF:imagehlp.SplitSymbols")]
	[return: MarshalAs(UnmanagedType.Bool)]
	public static extern bool SplitSymbols(StringBuilder ImageName, [Optional] string? SymbolsPath, StringBuilder SymbolFilePath, SPLITSYM Flags);

	/// <summary>Updates the date and time at which the specified file was last modified.</summary>
	/// <param name="FileHandle">A handle to the file of interest.</param>
	/// <param name="pSystemTime">
	/// A pointer to a SYSTEMTIME structure. If this parameter is <c>NULL</c>, the current system date and time is used.
	/// </param>
	/// <returns>
	/// <para>If the function succeeds, the return value is <c>TRUE</c>.</para>
	/// <para>If the function fails, the return value is <c>FALSE</c>. To retrieve extended error information, call GetLastError.</para>
	/// </returns>
	/// <remarks>
	/// All ImageHlp functions, such as this one, are single threaded. Therefore, calls from more than one thread to this function will
	/// likely result in unexpected behavior or memory corruption. To avoid this, you must synchronize all concurrent calls from more
	/// than one thread to this function.
	/// </remarks>
	// https://docs.microsoft.com/en-us/windows/win32/api/imagehlp/nf-imagehlp-touchfiletimes BOOL IMAGEAPI TouchFileTimes( HANDLE
	// FileHandle, PSYSTEMTIME pSystemTime );
	[DllImport(Lib_ImageHlp, SetLastError = true, ExactSpelling = true)]
	[PInvokeData("imagehlp.h", MSDNShortId = "NF:imagehlp.TouchFileTimes")]
	[return: MarshalAs(UnmanagedType.Bool)]
	public static extern bool TouchFileTimes(HFILE FileHandle, in SYSTEMTIME pSystemTime);

	/// <summary>Updates the date and time at which the specified file was last modified.</summary>
	/// <param name="FileHandle">A handle to the file of interest.</param>
	/// <param name="pSystemTime">
	/// A pointer to a SYSTEMTIME structure. If this parameter is <c>NULL</c>, the current system date and time is used.
	/// </param>
	/// <returns>
	/// <para>If the function succeeds, the return value is <c>TRUE</c>.</para>
	/// <para>If the function fails, the return value is <c>FALSE</c>. To retrieve extended error information, call GetLastError.</para>
	/// </returns>
	/// <remarks>
	/// All ImageHlp functions, such as this one, are single threaded. Therefore, calls from more than one thread to this function will
	/// likely result in unexpected behavior or memory corruption. To avoid this, you must synchronize all concurrent calls from more
	/// than one thread to this function.
	/// </remarks>
	// https://docs.microsoft.com/en-us/windows/win32/api/imagehlp/nf-imagehlp-touchfiletimes BOOL IMAGEAPI TouchFileTimes( HANDLE
	// FileHandle, PSYSTEMTIME pSystemTime );
	[DllImport(Lib_ImageHlp, SetLastError = true, ExactSpelling = true)]
	[PInvokeData("imagehlp.h", MSDNShortId = "NF:imagehlp.TouchFileTimes")]
	[return: MarshalAs(UnmanagedType.Bool)]
	public static extern bool TouchFileTimes(HFILE FileHandle, [In, Optional] IntPtr pSystemTime);

	/// <summary>Deallocate all resources that are allocated by a previous call to the MapAndLoad function.</summary>
	/// <param name="LoadedImage">
	/// A pointer to a LOADED_IMAGE structure. This structure is obtained through a call to the MapAndLoad function.
	/// </param>
	/// <returns>
	/// <para>If the function succeeds, the return value is <c>TRUE</c>.</para>
	/// <para>If the function fails, the return value is <c>FALSE</c>. To retrieve extended error information, call GetLastError.</para>
	/// </returns>
	/// <remarks>
	/// <para>
	/// The <c>UnMapAndLoad</c> function must be used to deallocate all resources that are allocated by a previous call to MapAndLoad.
	/// This function also writes a new checksum value into the image before the file is closed. This ensures that if a file is changed,
	/// it can be successfully loaded by the system loader.
	/// </para>
	/// <para>
	/// All ImageHlp functions, such as this one, are single threaded. Therefore, calls from more than one thread to this function will
	/// likely result in unexpected behavior or memory corruption. To avoid this, you must synchronize all concurrent calls from more
	/// than one thread to this function.
	/// </para>
	/// </remarks>
	// https://docs.microsoft.com/en-us/windows/win32/api/imagehlp/nf-imagehlp-unmapandload BOOL IMAGEAPI UnMapAndLoad( PLOADED_IMAGE
	// LoadedImage );
	[DllImport(Lib_ImageHlp, SetLastError = true, ExactSpelling = true)]
	[PInvokeData("imagehlp.h", MSDNShortId = "NF:imagehlp.UnMapAndLoad")]
	[return: MarshalAs(UnmanagedType.Bool)]
	public static extern bool UnMapAndLoad(ref LOADED_IMAGE LoadedImage);

	/// <summary>
	/// <para>Uses the specified information to update the corresponding fields in the symbol file.</para>
	/// <para><c>Note</c> This function works with .dbg files, not .pdb files.</para>
	/// <para>
	/// This function has been superseded by the UpdateDebugInfoFileEx function. Use <c>UpdateDebugInfoFileEx</c> to verify the checksum value.
	/// </para>
	/// </summary>
	/// <param name="ImageFileName">The name of the image that is now out of date with respect to its symbol file.</param>
	/// <param name="SymbolPath">The path in which to look for the symbol file.</param>
	/// <param name="DebugFilePath">A pointer to a buffer that receives the name of the symbol file that was updated.</param>
	/// <param name="NtHeaders">A pointer to an IMAGE_NT_HEADERS structure that specifies the new header information.</param>
	/// <returns>
	/// <para>If the function succeeds, the return value is <c>TRUE</c>.</para>
	/// <para>If the function fails, the return value is <c>FALSE</c>. To retrieve extended error information, call GetLastError.</para>
	/// </returns>
	/// <remarks>
	/// <para>
	/// The <c>UpdateDebugInfoFile</c> function takes the information stored in the IMAGE_NT_HEADERS structure and updates the
	/// corresponding fields in the symbol file. Any time an image file is modified, this function should be called to keep the numbers
	/// in sync. Specifically, whenever an image checksum changes, the symbol file should be updated to match.
	/// </para>
	/// <para>
	/// All ImageHlp functions, such as this one, are single threaded. Therefore, calls from more than one thread to this function will
	/// likely result in unexpected behavior or memory corruption. To avoid this, you must synchronize all concurrent calls from more
	/// than one thread to this function.
	/// </para>
	/// </remarks>
	// https://docs.microsoft.com/en-us/windows/win32/api/imagehlp/nf-imagehlp-updatedebuginfofile BOOL IMAGEAPI UpdateDebugInfoFile(
	// PCSTR ImageFileName, PCSTR SymbolPath, PSTR DebugFilePath, PIMAGE_NT_HEADERS32 NtHeaders );
	[DllImport(Lib_ImageHlp, SetLastError = true, ExactSpelling = true, CharSet = CharSet.Ansi)]
	[PInvokeData("imagehlp.h", MSDNShortId = "NF:imagehlp.UpdateDebugInfoFile")]
	[return: MarshalAs(UnmanagedType.Bool)]
	public static extern bool UpdateDebugInfoFile(string ImageFileName, string SymbolPath, StringBuilder DebugFilePath, in IMAGE_NT_HEADERS NtHeaders);

	/// <summary>
	/// <para>Uses the specified extended information to update the corresponding fields in the symbol file.</para>
	/// <para><c>Note</c> This function works with .dbg files, not .pdb files.</para>
	/// </summary>
	/// <param name="ImageFileName">The name of the image that is now out of date with respect to its symbol file.</param>
	/// <param name="SymbolPath">The path in which to look for the symbol file.</param>
	/// <param name="DebugFilePath">A pointer to a buffer that receives the name of the symbol file that was updated.</param>
	/// <param name="NtHeaders">A pointer to an IMAGE_NT_HEADERS structure that specifies the new header information.</param>
	/// <param name="OldCheckSum">
	/// The original checksum value. If this value does not match the checksum that is present in the mapped image, the flags in the
	/// symbol file contain IMAGE_SEPARATE_DEBUG_MISMATCH and the last error value is set to ERROR_INVALID_DATA.
	/// </param>
	/// <returns>
	/// <para>If the function succeeds, the return value is <c>TRUE</c>.</para>
	/// <para>If the function fails, the return value is <c>FALSE</c>.</para>
	/// </returns>
	/// <remarks>
	/// <para>
	/// The <c>UpdateDebugInfoFileEx</c> function takes the information stored in the IMAGE_NT_HEADERS structure and updates the
	/// corresponding fields in the symbol file. Any time an image file is modified, this function should be called to keep the numbers
	/// in sync. Specifically, whenever an image checksum changes, the symbol file should be updated to match.
	/// </para>
	/// <para>
	/// All ImageHlp functions, such as this one, are single threaded. Therefore, calls from more than one thread to this function will
	/// likely result in unexpected behavior or memory corruption. To avoid this, you must synchronize all concurrent calls from more
	/// than one thread to this function.
	/// </para>
	/// </remarks>
	// https://docs.microsoft.com/en-us/windows/win32/api/imagehlp/nf-imagehlp-updatedebuginfofileex BOOL IMAGEAPI
	// UpdateDebugInfoFileEx( PCSTR ImageFileName, PCSTR SymbolPath, PSTR DebugFilePath, PIMAGE_NT_HEADERS32 NtHeaders, DWORD
	// OldCheckSum );
	[DllImport(Lib_ImageHlp, SetLastError = false, ExactSpelling = true, CharSet = CharSet.Ansi)]
	[PInvokeData("imagehlp.h", MSDNShortId = "NF:imagehlp.UpdateDebugInfoFileEx")]
	[return: MarshalAs(UnmanagedType.Bool)]
	public static extern bool UpdateDebugInfoFileEx(string ImageFileName, string SymbolPath, StringBuilder DebugFilePath,
		in IMAGE_NT_HEADERS NtHeaders, uint OldCheckSum);
}