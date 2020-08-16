using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using System.Text;

namespace Vanara.PInvoke
{
	/// <summary>Items from the DbgHelp.dll</summary>
	public static partial class DbgHelp
	{
		/// <summary>
		/// <para>
		/// An application-defined callback function used with the SymEnumSourceFileTokens function which enumerates the source server
		/// version control information stored in the PDB for a module.
		/// </para>
		/// <para>
		/// The <c>PENUMSOURCEFILETOKENSCALLBACK</c> type defines a pointer to this callback function. <c>SymEnumSourceFileTokensProc</c> is
		/// a placeholder for the application-defined function name.
		/// </para>
		/// </summary>
		/// <param name="token">
		/// A pointer to an opaque data structure that contains the version control information corresponding to a particular individual
		/// source file. The usage of this token is detailed below.
		/// </param>
		/// <param name="size">The size of the data in the token parameter.</param>
		/// <returns>
		/// <para>If the function returns <c>TRUE</c>, the enumeration will continue.</para>
		/// <para>If the function returns <c>FALSE</c>, the enumeration will stop.</para>
		/// </returns>
		/// <remarks>
		/// <para>An application can use this token to extract a source file from version control by calling SymGetSourceFileFromToken.</para>
		/// <para>
		/// To get individual variables from the token, call SymGetSourceVarFromToken. The names of the variables differ based on the
		/// scripts used to create the tokens. See Source Server for details.
		/// </para>
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows/win32/api/dbghelp/nc-dbghelp-penumsourcefiletokenscallback PENUMSOURCEFILETOKENSCALLBACK
		// Penumsourcefiletokenscallback; BOOL Penumsourcefiletokenscallback( PVOID token, size_t size ) {...}
		[UnmanagedFunctionPointer(CallingConvention.Winapi, CharSet = CharSet.Auto)]
		[PInvokeData("dbghelp.h", MSDNShortId = "NC:dbghelp.PENUMSOURCEFILETOKENSCALLBACK")]
		public delegate bool PENUMSOURCEFILETOKENSCALLBACK(IntPtr token, SizeT size);

		/// <summary>
		/// <para>An application-defined callback function used with the SymFindFileInPath function.</para>
		/// <para>
		/// The <c>PFINDFILEINPATHCALLBACK</c> and <c>PFINDFILEINPATHCALLBACKW</c> types define a pointer to this callback function.
		/// <c>SymFindFileInPathProc</c> is a placeholder for the application-defined function name.
		/// </para>
		/// </summary>
		/// <param name="filename"/>
		/// <param name="context">
		/// The user-defined value specified in SymFindFileInPath, or <c>NULL</c>. This parameter is typically used by an application to
		/// pass a pointer to a data structure that provides some context for the callback function.
		/// </param>
		/// <returns>
		/// <para>Return <c>TRUE</c> to continue searching.</para>
		/// <para>Return <c>FALSE</c> to end the search.</para>
		/// </returns>
		// https://docs.microsoft.com/en-us/windows/win32/api/dbghelp/nc-dbghelp-pfindfileinpathcallback PFINDFILEINPATHCALLBACK
		// Pfindfileinpathcallback; BOOL Pfindfileinpathcallback( PCSTR filename, PVOID context ) {...}
		[UnmanagedFunctionPointer(CallingConvention.Winapi, CharSet = CharSet.Auto)]
		[PInvokeData("dbghelp.h", MSDNShortId = "NC:dbghelp.PFINDFILEINPATHCALLBACK")]
		[return: MarshalAs(UnmanagedType.Bool)]
		public delegate bool PFINDFILEINPATHCALLBACK([MarshalAs(UnmanagedType.LPTStr)] string filename, [In, Optional] IntPtr context);

		/// <summary>
		/// <para>An application-defined callback function used with the SymEnumSymbols, SymEnumTypes, and SymEnumTypesByName functions.</para>
		/// <para>
		/// The <c>PSYM_ENUMERATESYMBOLS_CALLBACK</c> and <c>PSYM_ENUMERATESYMBOLS_CALLBACKW</c> types define a pointer to this callback
		/// function. <c>SymEnumSymbolsProc</c> is a placeholder for the application-defined function name.
		/// </para>
		/// </summary>
		/// <param name="pSymInfo">A pointer to a SYMBOL_INFO structure that provides information about the symbol.</param>
		/// <param name="SymbolSize">
		/// The size of the symbol, in bytes. The size is calculated and is actually a guess. In some cases, this value can be zero.
		/// </param>
		/// <param name="UserContext">
		/// The user-defined value passed from the SymEnumSymbols or SymEnumTypes function, or <c>NULL</c>. This parameter is typically used
		/// by an application to pass a pointer to a data structure that provides context information for the callback function.
		/// </param>
		/// <returns>
		/// <para>If the function returns <c>TRUE</c>, the enumeration will continue.</para>
		/// <para>If the function returns <c>FALSE</c>, the enumeration will stop.</para>
		/// </returns>
		// https://docs.microsoft.com/en-us/windows/win32/api/dbghelp/nc-dbghelp-psym_enumeratesymbols_callback
		// PSYM_ENUMERATESYMBOLS_CALLBACK PsymEnumeratesymbolsCallback; BOOL PsymEnumeratesymbolsCallback( PSYMBOL_INFO pSymInfo, ULONG
		// SymbolSize, PVOID UserContext ) {...}
		[UnmanagedFunctionPointer(CallingConvention.Winapi, CharSet = CharSet.Auto)]
		[PInvokeData("dbghelp.h", MSDNShortId = "NC:dbghelp.PSYM_ENUMERATESYMBOLS_CALLBACK")]
		public delegate bool PSYM_ENUMERATESYMBOLS_CALLBACK(in SYMBOL_INFO pSymInfo, uint SymbolSize, [In, Optional] IntPtr UserContext);

		/// <summary>
		/// <para>An application-defined callback function used with the SymEnumLines and SymEnumSourceLines functions.</para>
		/// <para>
		/// The <c>PSYM_ENUMLINES_CALLBACK</c> and <c>PSYM_ENUMLINES_CALLBACKW</c> types define a pointer to this callback function.
		/// <c>SymEnumLinesProc</c> is a placeholder for the application-defined function name.
		/// </para>
		/// </summary>
		/// <param name="LineInfo">A pointer to a SRCCODEINFO structure that provides information about the line.</param>
		/// <param name="UserContext">
		/// The user-defined value passed from the SymEnumLines function, or <c>NULL</c>. This parameter is typically used by an application
		/// to pass a pointer to a data structure that provides context information for the callback function.
		/// </param>
		/// <returns>
		/// <para>If the function returns <c>TRUE</c>, the enumeration will continue.</para>
		/// <para>If the function returns <c>FALSE</c>, the enumeration will stop.</para>
		/// </returns>
		// https://docs.microsoft.com/en-us/windows/win32/api/dbghelp/nc-dbghelp-psym_enumlines_callback PSYM_ENUMLINES_CALLBACK
		// PsymEnumlinesCallback; BOOL PsymEnumlinesCallback( PSRCCODEINFO LineInfo, PVOID UserContext ) {...}
		[UnmanagedFunctionPointer(CallingConvention.Winapi, CharSet = CharSet.Auto)]
		[PInvokeData("dbghelp.h", MSDNShortId = "NC:dbghelp.PSYM_ENUMLINES_CALLBACK")]
		[return: MarshalAs(UnmanagedType.Bool)]
		public delegate bool PSYM_ENUMLINES_CALLBACK(in SRCCODEINFO LineInfo, [In, Optional] IntPtr UserContext);

		/// <summary>
		/// <para>An application-defined function used with the SymEnumProcesses function.</para>
		/// <para>
		/// The <c>PSYM_ENUMPROCESSES_CALLBACK</c> type defines a pointer to this callback function. <c>SymEnumProcessesProc</c> is a
		/// placeholder for the application-defined function name.
		/// </para>
		/// </summary>
		/// <param name="hProcess">A handle to the process.</param>
		/// <param name="UserContext">
		/// The user-defined value passed from the SymEnumProcesses function, or <c>NULL</c>. This parameter is typically used by an
		/// application to pass a pointer to a data structure that provides context information for the callback function.
		/// </param>
		/// <returns>
		/// <para>If the function returns <c>TRUE</c>, the enumeration will continue.</para>
		/// <para>If the function returns <c>FALSE</c>, the enumeration will stop.</para>
		/// </returns>
		// https://docs.microsoft.com/en-us/windows/win32/api/dbghelp/nc-dbghelp-psym_enumprocesses_callback PSYM_ENUMPROCESSES_CALLBACK
		// PsymEnumprocessesCallback; BOOL PsymEnumprocessesCallback( HANDLE hProcess, PVOID UserContext ) {...}
		[UnmanagedFunctionPointer(CallingConvention.Winapi)]
		[PInvokeData("dbghelp.h", MSDNShortId = "NC:dbghelp.PSYM_ENUMPROCESSES_CALLBACK")]
		[return: MarshalAs(UnmanagedType.Bool)]
		public delegate bool PSYM_ENUMPROCESSES_CALLBACK(HPROCESS hProcess, [In, Optional] IntPtr UserContext);

		/// <summary>
		/// <para>An application-defined callback function used with the SymEnumSourceFiles function.</para>
		/// <para>
		/// The <c>PSYM_ENUMSOURCEFILES_CALLBACK</c> and <c>PSYM_ENUMSOURCEFILES_CALLBACKW</c> types define a pointer to this callback
		/// function. <c>SymEnumSourceFilesProc</c> is a placeholder for the application-defined function name.
		/// </para>
		/// </summary>
		/// <param name="pSourceFile">A pointer to a SOURCEFILE structure that provides information about the source file.</param>
		/// <param name="UserContext">
		/// The user-defined value passed from the SymEnumSourceFiles function, or <c>NULL</c>. This parameter is typically used by an
		/// application to pass a pointer to a data structure that provides context information for the callback function.
		/// </param>
		/// <returns>
		/// <para>If the function returns <c>TRUE</c>, the enumeration will continue.</para>
		/// <para>If the function returns <c>FALSE</c>, the enumeration will stop.</para>
		/// </returns>
		// https://docs.microsoft.com/en-us/windows/win32/api/dbghelp/nc-dbghelp-psym_enumsourcefiles_callback PSYM_ENUMSOURCEFILES_CALLBACK
		// PsymEnumsourcefilesCallback; BOOL PsymEnumsourcefilesCallback( PSOURCEFILE pSourceFile, PVOID UserContext ) {...}
		[UnmanagedFunctionPointer(CallingConvention.Winapi, CharSet = CharSet.Auto)]
		[PInvokeData("dbghelp.h", MSDNShortId = "NC:dbghelp.PSYM_ENUMSOURCEFILES_CALLBACK")]
		[return: MarshalAs(UnmanagedType.Bool)]
		public delegate bool PSYM_ENUMSOURCEFILES_CALLBACK(in SOURCEFILE pSourceFile, [In, Optional] IntPtr UserContext);

		/// <summary>Flags for <see cref="SymEnumSourceLines"/>.</summary>
		[PInvokeData("dbghelp.h", MSDNShortId = "NF:dbghelp.SymEnumSourceLines")]
		[Flags]
		public enum ESLFLAG
		{
			/// <summary>The function matches the full path in the File parameter.</summary>
			ESLFLAG_FULLPATH = 0x00000001,

			/// <summary/>
			ESLFLAG_NEAREST = 0x00000002,

			/// <summary/>
			ESLFLAG_PREV = 0x00000004,

			/// <summary/>
			ESLFLAG_NEXT = 0x00000008,

			/// <summary/>
			ESLFLAG_INLINE_SITE = 0x00000010,
		}

		/// <summary>The format of the id parameter. This parameter can be one of the following values.</summary>
		[PInvokeData("dbghelp.h", MSDNShortId = "NF:dbghelp.SymFindFileInPath")]
		[Flags]
		public enum SSRVOPT
		{
			/// <summary>
			/// Callback function. The data parameter contains a pointer to the callback function. If data is NULL, any previously-set
			/// callback function is ignored.
			/// </summary>
			SSRVOPT_CALLBACK = 0x00000001,

			/// <summary>The id parameter is a DWORD.</summary>
			SSRVOPT_DWORD = 0x00000002,

			/// <summary>The id parameter is a pointer to a DWORD.</summary>
			SSRVOPT_DWORDPTR = 0x00000004,

			/// <summary>The id parameter is a pointer to a GUID.</summary>
			SSRVOPT_GUIDPTR = 0x00000008,

			/// <summary/>
			SSRVOPT_OLDGUIDPTR = 0x00000010,

			/// <summary>
			/// If data is TRUE, SymSrv will not display dialog boxes or pop-ups. If data is FALSE, SymSrv will display these graphical
			/// features when making connections.
			/// </summary>
			SSRVOPT_UNATTENDED = 0x00000020,

			/// <summary>
			/// If data is TRUE, SymSrv will not verify that the path parameter passed by the SymbolServer function actually exists. In this
			/// case, SymbolServer will always return TRUE.
			/// </summary>
			SSRVOPT_NOCOPY = 0x00000040,

			/// <summary/>
			SSRVOPT_GETPATH = 0x00000040,

			/// <summary>
			/// The data parameter is an HWND value that specifies the handle to the parent window that should be used for all dialog boxes
			/// and pop-ups. If data is NULL, SymSrv will use the desktop window as the parent (this is the default).
			/// </summary>
			SSRVOPT_PARENTWIN = 0x00000080,

			/// <summary>
			/// Data type of the id parameter passed to the SymbolServer function. The data parameter is of type UINT_PTR and can be one of
			/// the following values: SSRVOPT_DWORD (default) SSRVOPT_DWORDPTR SSRVOPT_GUIDPTR
			/// </summary>
			SSRVOPT_PARAMTYPE = 0x00000100,

			/// <summary>
			/// If data is TRUE, SymSrv will not use the downstream store specified in _NT_SYMBOL_PATH. DbgHelp 6.0 and earlier: This value
			/// is not supported.
			/// </summary>
			SSRVOPT_SECURE = 0x00000200,

			/// <summary>SymSrv will provide debug trace information. DbgHelp 5.1: This value is not supported.</summary>
			SSRVOPT_TRACE = 0x00000400,

			/// <summary>
			/// The data parameter specifies the value passed to the SymbolServerCallback function in the context parameter. DbgHelp 6.0 and
			/// earlier: This value is not supported.
			/// </summary>
			SSRVOPT_SETCONTEXT = 0x00000800,

			/// <summary>
			/// If data is NULL, the default proxy server is used. Otherwise, data is a null-terminated string that specifies the name and
			/// port number of the proxy server. The name and port number are separated by a colon (:). For more information, see Symbol
			/// Servers and Internet Firewalls. DbgHelp 6.0 and earlier: This value is not supported.
			/// </summary>
			SSRVOPT_PROXY = 0x00001000,

			/// <summary>
			/// The data parameter contains a string that specifies the downstream store path. For more information, see Using SymSrv.
			/// DbgHelp 6.0 and earlier: This value is not supported.
			/// </summary>
			SSRVOPT_DOWNSTREAM_STORE = 0x00002000,

			/// <summary>
			/// If data is TRUE, SymSrv will overwrite the downlevel store from the symbol store. DbgHelp 6.1 and earlier: This value is not supported.
			/// </summary>
			SSRVOPT_OVERWRITE = 0x00004000,

			/// <summary/>
			SSRVOPT_RESETTOU = 0x00008000,

			/// <summary/>
			SSRVOPT_CALLBACKW = 0x00010000,

			/// <summary>
			/// If data is TRUE, SymSrv uses the default downstream store as a flat directory. DbgHelp 6.1 and earlier: This value is not supported.
			/// </summary>
			SSRVOPT_FLAT_DEFAULT_STORE = 0x00020000,

			/// <summary/>
			SSRVOPT_PROXYW = 0x00040000,

			/// <summary/>
			SSRVOPT_MESSAGE = 0x00080000,

			/// <summary/>
			SSRVOPT_SERVICE = 0x00100000,

			/// <summary>
			/// If data is TRUE, SymSrv uses symbols that do not have an address. By default, SymSrv filters out symbols that do not have an address.
			/// </summary>
			SSRVOPT_FAVOR_COMPRESSED = 0x00200000,

			/// <summary/>
			SSRVOPT_STRING = 0x00400000,

			/// <summary/>
			SSRVOPT_WINHTTP = 0x00800000,

			/// <summary/>
			SSRVOPT_WININET = 0x01000000,

			/// <summary/>
			SSRVOPT_DONT_UNCOMPRESS = 0x02000000,

			/// <summary/>
			SSRVOPT_DISABLE_PING_HOST = 0x04000000,

			/// <summary/>
			SSRVOPT_DISABLE_TIMEOUT = 0x08000000,

			/// <summary/>
			SSRVOPT_ENABLE_COMM_MSG = 0x10000000,

			/// <summary/>
			SSRVOPT_URI_FILTER = 0x20000000,

			/// <summary/>
			SSRVOPT_URI_TIERS = 0x40000000,

			/// <summary/>
			SSRVOPT_RETRY_APP_HANG = unchecked((int)0x80000000),

			/// <summary>Resets default options.</summary>
			SSRVOPT_RESET = -1,
		}

		/// <summary>Indicates possible options.</summary>
		[PInvokeData("dbghelp.h", MSDNShortId = "NF:dbghelp.SymEnumSymbolsEx")]
		[Flags]
		public enum SYMENUM
		{
			/// <summary>Use the default options.</summary>
			SYMENUM_OPTIONS_DEFAULT = 0x00000001,

			/// <summary>Enumerate inline symbols.</summary>
			SYMENUM_OPTIONS_INLINE = 0x00000002
		}

		/// <summary>The symbol options. Zero is a valid value and indicates that all options are turned off.</summary>
		[PInvokeData("dbghelp.h", MSDNShortId = "NF:dbghelp.SymSetOptions")]
		[Flags]
		public enum SYMOPT : uint
		{
			/// <summary>
			/// Enables the use of symbols that are stored with absolute addresses. Most symbols are stored as RVAs from the base of the
			/// module. DbgHelp translates them to absolute addresses. There are symbols that are stored as an absolute address. These have
			/// very specialized purposes and are typically not used.
			/// <para>DbgHelp 5.1 and earlier: This value is not supported.</para>
			/// </summary>
			SYMOPT_ALLOW_ABSOLUTE_SYMBOLS = 0x00000800,

			/// <summary>
			/// Enables the use of symbols that do not have an address. By default, DbgHelp filters out symbols that do not have an address.
			/// </summary>
			SYMOPT_ALLOW_ZERO_ADDRESS = 0x01000000,

			/// <summary>
			/// Do not search the public symbols when searching for symbols by address, or when enumerating symbols, unless they were not
			/// found in the global symbols or within the current scope. This option has no effect with SYMOPT_PUBLICS_ONLY.
			/// <para>DbgHelp 5.1 and earlier: This value is not supported.</para>
			/// </summary>
			SYMOPT_AUTO_PUBLICS = 0x00010000,

			/// <summary>All symbol searches are insensitive to case.</summary>
			SYMOPT_CASE_INSENSITIVE = 0x00000001,

			/// <summary>Pass debug output through OutputDebugString or the SymRegisterCallbackProc64 callback function.</summary>
			SYMOPT_DEBUG = 0x80000000,

			/// <summary>
			/// Symbols are not loaded until a reference is made requiring the symbols be loaded. This is the fastest, most efficient way to
			/// use the symbol handler.
			/// </summary>
			SYMOPT_DEFERRED_LOADS = 0x00000004,

			/// <summary>
			/// Disables the auto-detection of symbol server stores in the symbol path, even without the "SRV*" designation, maintaining
			/// compatibility with previous behavior.
			/// <para>DbgHelp 6.6 and earlier: This value is not supported.</para>
			/// </summary>
			SYMOPT_DISABLE_SYMSRV_AUTODETECT = 0x02000000,

			/// <summary>Do not load an unmatched .pdb file. Do not load export symbols if all else fails.</summary>
			SYMOPT_EXACT_SYMBOLS = 0x00000400,

			/// <summary>
			/// Do not display system dialog boxes when there is a media failure such as no media in a drive. Instead, the failure happens silently.
			/// </summary>
			SYMOPT_FAIL_CRITICAL_ERRORS = 0x00000200,

			/// <summary>
			/// If there is both an uncompressed and a compressed file available, favor the compressed file. This option is good for slow connections.
			/// </summary>
			SYMOPT_FAVOR_COMPRESSED = 0x00800000,

			/// <summary>
			/// Symbols are stored in the root directory of the default downstream store.
			/// <para>DbgHelp 6.1 and earlier: This value is not supported.</para>
			/// </summary>
			SYMOPT_FLAT_DIRECTORY = 0x00400000,

			/// <summary>Ignore path information in the CodeView record of the image header when loading a .pdb file.</summary>
			SYMOPT_IGNORE_CVREC = 0x00000080,

			/// <summary>
			/// Ignore the image directory.
			/// <para>DbgHelp 6.1 and earlier: This value is not supported.</para>
			/// </summary>
			SYMOPT_IGNORE_IMAGEDIR = 0x00200000,

			/// <summary>
			/// Do not use the path specified by _NT_SYMBOL_PATH if the user calls SymSetSearchPath without a valid path.
			/// <para>DbgHelp 5.1: This value is not supported.</para>
			/// </summary>
			SYMOPT_IGNORE_NT_SYMPATH = 0x00001000,

			/// <summary>When debugging on 64-bit Windows, include any 32-bit modules.</summary>
			SYMOPT_INCLUDE_32BIT_MODULES = 0x00002000,

			/// <summary>Disable checks to ensure a file (.exe, .dbg., or .pdb) is the correct file. Instead, load the first file located.</summary>
			SYMOPT_LOAD_ANYTHING = 0x00000040,

			/// <summary>Loads line number information.</summary>
			SYMOPT_LOAD_LINES = 0x00000010,

			/// <summary>
			/// All C++ decorated symbols containing the symbol separator "::" are replaced by "__". This option exists for debuggers that
			/// cannot handle parsing real C++ symbol names.
			/// </summary>
			SYMOPT_NO_CPP = 0x00000008,

			/// <summary>
			/// Do not search the image for the symbol path when loading the symbols for a module if the module header cannot be read.
			/// <para>DbgHelp 5.1: This value is not supported.</para>
			/// </summary>
			SYMOPT_NO_IMAGE_SEARCH = 0x00020000,

			/// <summary>Prevents prompting for validation from the symbol server.</summary>
			SYMOPT_NO_PROMPTS = 0x00080000,

			/// <summary>
			/// Do not search the publics table for symbols. This option should have little effect because there are copies of the public
			/// symbols in the globals table.
			/// <para>DbgHelp 5.1: This value is not supported.</para>
			/// </summary>
			SYMOPT_NO_PUBLICS = 0x00008000,

			/// <summary>
			/// Prevents symbols from being loaded when the caller examines symbols across multiple modules. Examine only the module whose
			/// symbols have already been loaded.
			/// </summary>
			SYMOPT_NO_UNQUALIFIED_LOADS = 0x00000100,

			/// <summary>
			/// Overwrite the downlevel store from the symbol store.
			/// <para>DbgHelp 6.1 and earlier: This value is not supported.</para>
			/// </summary>
			SYMOPT_OVERWRITE = 0x00100000,

			/// <summary>
			/// Do not use private symbols. The version of DbgHelp that shipped with earlier Windows release supported only public symbols;
			/// this option provides compatibility with this limitation.
			/// <para>DbgHelp 5.1: This value is not supported.</para>
			/// </summary>
			SYMOPT_PUBLICS_ONLY = 0x00004000,

			/// <summary>
			/// DbgHelp will not load any symbol server other than SymSrv. SymSrv will not use the downstream store specified in
			/// _NT_SYMBOL_PATH. After this flag has been set, it cannot be cleared.
			/// <para>DbgHelp 6.0 and 6.1: This flag can be cleared.</para>
			/// <para>DbgHelp 5.1: This value is not supported.</para>
			/// </summary>
			SYMOPT_SECURE = 0x00040000,

			/// <summary>
			/// All symbols are presented in undecorated form.
			/// <para>
			/// This option has no effect on global or local symbols because they are stored undecorated. This option applies only to public symbols.
			/// </para>
			/// </summary>
			SYMOPT_UNDNAME = 0x00000002,
		}

		/// <summary>Indicates whether the specified address is within an inline frame.</summary>
		/// <param name="hProcess">A handle to a process. This handle must have been previously passed to the SymInitialize function.</param>
		/// <param name="Address">The address.</param>
		/// <returns>Returns zero if the address is not within an inline frame.</returns>
		// https://docs.microsoft.com/en-us/windows/win32/api/dbghelp/nf-dbghelp-symaddrincludeinlinetrace DWORD IMAGEAPI
		// SymAddrIncludeInlineTrace( HANDLE hProcess, DWORD64 Address );
		[DllImport(Lib_DbgHelp, SetLastError = false, ExactSpelling = true)]
		[PInvokeData("dbghelp.h", MSDNShortId = "NF:dbghelp.SymAddrIncludeInlineTrace")]
		public static extern uint SymAddrIncludeInlineTrace(HPROCESS hProcess, ulong Address);

		/// <summary>Adds the stream to the specified module for use by the Source Server.</summary>
		/// <param name="hProcess">A handle to a process. This handle must have been previously passed to the SymInitialize function.</param>
		/// <param name="Base">The base address of the module.</param>
		/// <param name="StreamFile">
		/// A null-terminated string that contains the absolute or relative path to a file that contains the source indexing stream. Can be
		/// <c>NULL</c> if Buffer is not <c>NULL</c>.
		/// </param>
		/// <param name="Buffer">A buffer that contains the source indexing stream. Can be <c>NULL</c> if StreamFile is not <c>NULL</c>.</param>
		/// <param name="Size">Size, in bytes, of the Buffer buffer.</param>
		/// <returns>
		/// <para>If the function succeeds, the return value is <c>TRUE</c>.</para>
		/// <para>If the function fails, the return value is <c>FALSE</c>. To retrieve extended error information, call GetLastError.</para>
		/// </returns>
		/// <remarks>
		/// <para>
		/// <c>SymAddSourceStream</c> adds a stream of data formatted for use by the source Server to a designated module. The caller can
		/// pass the stream either as a buffer in the Buffer parameter or a file in the StreamFile parameter. If both parameters are filled,
		/// then the function uses the Buffer parameter. If both parameters are <c>NULL</c>, then the function returns <c>FALSE</c> and the
		/// last-error code is set to <c>ERROR_INVALID_PARAMETER</c>.
		/// </para>
		/// <para>
		/// It is important to note that <c>SymAddSourceStream</c> does not add the stream to any corresponding PDB in order to persist the
		/// data. This function is used by those programmatically implementing their own debuggers in scenarios in which a PDB is not available.
		/// </para>
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows/win32/api/dbghelp/nf-dbghelp-symaddsourcestream BOOL IMAGEAPI SymAddSourceStream( HANDLE
		// hProcess, ULONG64 Base, PCSTR StreamFile, PBYTE Buffer, size_t Size );
		[DllImport(Lib_DbgHelp, SetLastError = true, CharSet = CharSet.Auto)]
		[PInvokeData("dbghelp.h", MSDNShortId = "NF:dbghelp.SymAddSourceStream")]
		[return: MarshalAs(UnmanagedType.Bool)]
		public static extern bool SymAddSourceStream(HPROCESS hProcess, ulong Base, [Optional, MarshalAs(UnmanagedType.LPTStr)] string StreamFile, [In] IntPtr Buffer, SizeT Size);

		/// <summary>Adds a virtual symbol to the specified module.</summary>
		/// <param name="hProcess">A handle to a process. This handle must have been previously passed to the SymInitialize function.</param>
		/// <param name="BaseOfDll">The base address of the module.</param>
		/// <param name="Name">The name of the symbol. The maximum size of a symbol name is MAX_SYM_NAME characters.</param>
		/// <param name="Address">The address of the symbol. This address must be within the address range of the specified module.</param>
		/// <param name="Size">The size of the symbol, in bytes. This parameter is optional.</param>
		/// <param name="Flags">This parameter is unused.</param>
		/// <returns>
		/// <para>If the function succeeds, the return value is <c>TRUE</c>.</para>
		/// <para>If the function fails, the return value is <c>FALSE</c>. To retrieve extended error information, call GetLastError.</para>
		/// </returns>
		/// <remarks>
		/// <para>
		/// All DbgHelp functions, such as this one, are single threaded. Therefore, calls from more than one thread to this function will
		/// likely result in unexpected behavior or memory corruption. To avoid this, you must synchronize all concurrent calls from more
		/// than one thread to this function.
		/// </para>
		/// <para>To call the Unicode version of this function, define DBGHELP_TRANSLATE_TCHAR.</para>
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows/win32/api/dbghelp/nf-dbghelp-symaddsymbol BOOL IMAGEAPI SymAddSymbol( HANDLE hProcess,
		// ULONG64 BaseOfDll, PCSTR Name, DWORD64 Address, DWORD Size, DWORD Flags );
		[DllImport(Lib_DbgHelp, SetLastError = true, CharSet = CharSet.Auto)]
		[PInvokeData("dbghelp.h", MSDNShortId = "NF:dbghelp.SymAddSymbol")]
		[return: MarshalAs(UnmanagedType.Bool)]
		public static extern bool SymAddSymbol(HPROCESS hProcess, ulong BaseOfDll, [MarshalAs(UnmanagedType.LPTStr)] string Name, ulong Address, uint Size, uint Flags = 0);

		/// <summary>
		/// <para>An entry point to the symbol server DLL. It is used to set the symbol server options.</para>
		/// <para>
		/// The <c>PSYMBOLSERVERSETOPTIONSPROC</c> type defines a pointer to this callback function. <c>SymbolServerSetOptions</c> is a
		/// placeholder for the library-defined function name.
		/// </para>
		/// </summary>
		/// <param name="options">[in] The option to be set (see Remarks).</param>
		/// <param name="data">[in] The server-specific option data. The format of this data depends on the value of options (see Remarks).</param>
		/// <returns>
		/// The server can return <c>TRUE</c> to indicate success, or return <c>FALSE</c> and call the <c>SetLastError</c> function to
		/// indicate an error condition.
		/// </returns>
		/// <remarks>
		/// <para>
		/// To call this function, you must use the <c>LoadLibrary</c> function to load the DLL and the <c>GetProcAddress</c> function to
		/// get the address of the function. The default implementation is in Symsrv.dll.
		/// </para>
		/// <para>If you are using Symsrv.dll as your symbol server, the options parameter should be one of the following values.</para>
		/// <list type="table">
		/// <listheader>
		/// <term>id</term>
		/// <term>Meaning</term>
		/// </listheader>
		/// <item>
		/// <term>SSRVOPT_CALLBACK</term>
		/// <term>
		/// Callback function. The data parameter contains a pointer to the callback function. If data is NULL, any previously-set callback
		/// function is ignored.
		/// </term>
		/// </item>
		/// <item>
		/// <term>SSRVOPT_DOWNSTREAM_STORE</term>
		/// <term>
		/// The data parameter contains a string that specifies the downstream store path. For more information, see Using SymSrv. DbgHelp
		/// 6.0 and earlier: This value is not supported.
		/// </term>
		/// </item>
		/// <item>
		/// <term>SSRVOPT_FLAT_DEFAULT_STORE</term>
		/// <term>
		/// If data is TRUE, SymSrv uses the default downstream store as a flat directory. DbgHelp 6.1 and earlier: This value is not supported.
		/// </term>
		/// </item>
		/// <item>
		/// <term>SSRVOPT_FAVOR_COMPRESSED</term>
		/// <term>
		/// If data is TRUE, SymSrv uses symbols that do not have an address. By default, SymSrv filters out symbols that do not have an address.
		/// </term>
		/// </item>
		/// <item>
		/// <term>SSRVOPT_NOCOPY</term>
		/// <term>
		/// If data is TRUE, SymSrv will not verify that the path parameter passed by the SymbolServer function actually exists. In this
		/// case, SymbolServer will always return TRUE.
		/// </term>
		/// </item>
		/// <item>
		/// <term>SSRVOPT_OVERWRITE</term>
		/// <term>
		/// If data is TRUE, SymSrv will overwrite the downlevel store from the symbol store. DbgHelp 6.1 and earlier: This value is not supported.
		/// </term>
		/// </item>
		/// <item>
		/// <term>SSRVOPT_PARAMTYPE</term>
		/// <term>
		/// Data type of the id parameter passed to the SymbolServer function. The data parameter is of type UINT_PTR and can be one of the
		/// following values: SSRVOPT_DWORD (default) SSRVOPT_DWORDPTR SSRVOPT_GUIDPTR
		/// </term>
		/// </item>
		/// <item>
		/// <term>SSRVOPT_PARENTWIN</term>
		/// <term>
		/// The data parameter is an HWND value that specifies the handle to the parent window that should be used for all dialog boxes and
		/// pop-ups. If data is NULL, SymSrv will use the desktop window as the parent (this is the default).
		/// </term>
		/// </item>
		/// <item>
		/// <term>SSRVOPT_PROXY</term>
		/// <term>
		/// If data is NULL, the default proxy server is used. Otherwise, data is a null-terminated string that specifies the name and port
		/// number of the proxy server. The name and port number are separated by a colon (:). For more information, see Symbol Servers and
		/// Internet Firewalls. DbgHelp 6.0 and earlier: This value is not supported.
		/// </term>
		/// </item>
		/// <item>
		/// <term>SSRVOPT_RESET</term>
		/// <term>Resets default options.</term>
		/// </item>
		/// <item>
		/// <term>SSRVOPT_SECURE</term>
		/// <term>
		/// If data is TRUE, SymSrv will not use the downstream store specified in _NT_SYMBOL_PATH. DbgHelp 6.0 and earlier: This value is
		/// not supported.
		/// </term>
		/// </item>
		/// <item>
		/// <term>SSRVOPT_SETCONTEXT</term>
		/// <term>
		/// The data parameter specifies the value passed to the SymbolServerCallback function in the context parameter. DbgHelp 6.0 and
		/// earlier: This value is not supported.
		/// </term>
		/// </item>
		/// <item>
		/// <term>SSRVOPT_TRACE</term>
		/// <term>SymSrv will provide debug trace information. DbgHelp 5.1: This value is not supported.</term>
		/// </item>
		/// <item>
		/// <term>SSRVOPT_UNATTENDED</term>
		/// <term>
		/// If data is TRUE, SymSrv will not display dialog boxes or pop-ups. If data is FALSE, SymSrv will display these graphical features
		/// when making connections.
		/// </term>
		/// </item>
		/// </list>
		/// </remarks>
		// https://docs.microsoft.com/en-us/previous-versions/ff797954(v=vs.85) BOOL CALLBACK SymbolServerSetOptions( _In_ UINT_PTR options,
		// _In_ ULONG64 data );
		[DllImport("Symsrv.dll", SetLastError = false, CharSet = CharSet.Auto)]
		[PInvokeData("DbgHelp.h")]
		[return: MarshalAs(UnmanagedType.Bool)]
		public static extern bool SymbolServerSetOptions([In] IntPtr options, [In] long data);

		/// <summary>Deallocates all resources associated with the process handle.</summary>
		/// <param name="hProcess">A handle to the process that was originally passed to the SymInitialize function.</param>
		/// <returns>
		/// <para>If the function succeeds, the return value is <c>TRUE</c>.</para>
		/// <para>If the function fails, the return value is <c>FALSE</c>. To retrieve extended error information, call GetLastError.</para>
		/// </returns>
		/// <remarks>
		/// <para>
		/// This function frees all resources associated with the process handle. Failure to call this function causes memory and resource
		/// leaks in the calling application
		/// </para>
		/// <para>
		/// All DbgHelp functions, such as this one, are single threaded. Therefore, calls from more than one thread to this function will
		/// likely result in unexpected behavior or memory corruption. To avoid this, call SymInitialize only when your process starts and
		/// <c>SymCleanup</c> only when your process ends. It is not necessary for each thread in the process to call these functions.
		/// </para>
		/// <para>Examples</para>
		/// <para>For an example, see Terminating the Symbol Handler.</para>
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows/win32/api/dbghelp/nf-dbghelp-symcleanup BOOL IMAGEAPI SymCleanup( HANDLE hProcess );
		[DllImport(Lib_DbgHelp, SetLastError = true, ExactSpelling = true)]
		[PInvokeData("dbghelp.h", MSDNShortId = "NF:dbghelp.SymCleanup")]
		[return: MarshalAs(UnmanagedType.Bool)]
		public static extern bool SymCleanup(HPROCESS hProcess);

		/// <summary>Compares two inline traces.</summary>
		/// <param name="hProcess">A handle to a process. This handle must have been previously passed to the SymInitialize function.</param>
		/// <param name="Address1">The first address to be compared.</param>
		/// <param name="InlineContext1">The inline context for the first trace to be compared.</param>
		/// <param name="RetAddress1">The return address of the first trace to be compared.</param>
		/// <param name="Address2">The second address to be compared.</param>
		/// <param name="RetAddress2">The return address of the second trace to be compared.</param>
		/// <returns>
		/// <para>Indicates the result of the comparison.</para>
		/// <list type="table">
		/// <listheader>
		/// <term>Return code/value</term>
		/// <term>Description</term>
		/// </listheader>
		/// <item>
		/// <term>SYM_INLINE_COMP_ERROR 0</term>
		/// <term>An error occurred.</term>
		/// </item>
		/// <item>
		/// <term>SYM_INLINE_COMP_IDENTICAL 1</term>
		/// <term>The inline contexts are identical.</term>
		/// </item>
		/// <item>
		/// <term>SYM_INLINE_COMP_STEPIN 2</term>
		/// <term>The inline trace is a step-in of an inline function.</term>
		/// </item>
		/// <item>
		/// <term>SYM_INLINE_COMP_STEPOUT 3</term>
		/// <term>The inline trace is a step-out of an inline function.</term>
		/// </item>
		/// <item>
		/// <term>SYM_INLINE_COMP_STEPOVER 4</term>
		/// <term>The inline trace is a step-over of an inline function.</term>
		/// </item>
		/// <item>
		/// <term>SYM_INLINE_COMP_DIFFERENT 5</term>
		/// <term>The inline contexts are different.</term>
		/// </item>
		/// </list>
		/// </returns>
		// https://docs.microsoft.com/en-us/windows/win32/api/dbghelp/nf-dbghelp-symcompareinlinetrace DWORD IMAGEAPI SymCompareInlineTrace(
		// HANDLE hProcess, DWORD64 Address1, DWORD InlineContext1, DWORD64 RetAddress1, DWORD64 Address2, DWORD64 RetAddress2 );
		[DllImport(Lib_DbgHelp, SetLastError = false, ExactSpelling = true)]
		[PInvokeData("dbghelp.h", MSDNShortId = "NF:dbghelp.SymCompareInlineTrace")]
		public static extern SYM_INLINE_COMP SymCompareInlineTrace(HPROCESS hProcess, ulong Address1, uint InlineContext1, ulong RetAddress1, ulong Address2, ulong RetAddress2);

		/// <summary>Deletes a virtual symbol from the specified module.</summary>
		/// <param name="hProcess">A handle to a process. This handle must have been previously passed to the SymInitialize function.</param>
		/// <param name="BaseOfDll">The base address of the module.</param>
		/// <param name="Name">The name of the symbol.</param>
		/// <param name="Address">The address of the symbol. This address must be within the address range of the specified module.</param>
		/// <param name="Flags">This parameter is unused.</param>
		/// <returns>
		/// <para>If the function succeeds, the return value is <c>TRUE</c>.</para>
		/// <para>If the function fails, the return value is <c>FALSE</c>. To retrieve extended error information, call GetLastError.</para>
		/// </returns>
		/// <remarks>
		/// <para>
		/// All DbgHelp functions, such as this one, are single threaded. Therefore, calls from more than one thread to this function will
		/// likely result in unexpected behavior or memory corruption. To avoid this, you must synchronize all concurrent calls from more
		/// than one thread to this function.
		/// </para>
		/// <para>To call the Unicode version of this function, define DBGHELP_TRANSLATE_TCHAR.</para>
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows/win32/api/dbghelp/nf-dbghelp-symdeletesymbol BOOL IMAGEAPI SymDeleteSymbol( HANDLE
		// hProcess, ULONG64 BaseOfDll, PCSTR Name, DWORD64 Address, DWORD Flags );
		[DllImport(Lib_DbgHelp, SetLastError = true, CharSet = CharSet.Auto)]
		[PInvokeData("dbghelp.h", MSDNShortId = "NF:dbghelp.SymDeleteSymbol")]
		[return: MarshalAs(UnmanagedType.Bool)]
		public static extern bool SymDeleteSymbol(HPROCESS hProcess, ulong BaseOfDll, [MarshalAs(UnmanagedType.LPTStr)] string Name, ulong Address, uint Flags = 0);

		/// <summary>Enumerates all modules that have been loaded for the process by the SymLoadModule64 or SymLoadModuleEx function.</summary>
		/// <param name="hProcess">A handle to the process that was originally passed to the SymInitialize function.</param>
		/// <param name="EnumModulesCallback">
		/// The enumeration callback function. This function is called once per module. For more information, see SymEnumerateModulesProc64.
		/// </param>
		/// <param name="UserContext">
		/// A user-defined value or <c>NULL</c>. This value is simply passed to the callback function. Normally, this parameter is used by
		/// an application to pass a pointer to a data structure that lets the callback function establish some type of context.
		/// </param>
		/// <returns>
		/// <para>If the function succeeds, the return value is <c>TRUE</c>.</para>
		/// <para>If the function fails, the return value is <c>FALSE</c>. To retrieve extended error information, call GetLastError.</para>
		/// </returns>
		/// <remarks>
		/// <para>
		/// The <c>SymEnumerateModules64</c> function enumerates all modules that have been loaded for the process by SymLoadModule64, even
		/// if the symbol loading is deferred. The enumeration callback function is called once for each module and is passed the module information.
		/// </para>
		/// <para>
		/// All DbgHelp functions, such as this one, are single threaded. Therefore, calls from more than one thread to this function will
		/// likely result in unexpected behavior or memory corruption. To avoid this, you must synchronize all concurrent calls from more
		/// than one thread to this function.
		/// </para>
		/// <para>
		/// To call the Unicode version of this function, define DBGHELP_TRANSLATE_TCHAR. <c>SymEnumerateModulesW64</c> is defined as
		/// follows in Dbghelp.h.
		/// </para>
		/// <para>
		/// <code> BOOL IMAGEAPI SymEnumerateModulesW64( __in HANDLE hProcess, __in PSYM_ENUMMODULES_CALLBACKW64 EnumModulesCallback, __in_opt PVOID UserContext ); #ifdef DBGHELP_TRANSLATE_TCHAR #define SymEnumerateModules64 SymEnumerateModulesW64 #endif</code>
		/// </para>
		/// <para>
		/// This function supersedes the <c>SymEnumerateModules</c> function. For more information, see Updated Platform Support.
		/// <c>SymEnumerateModules</c> is defined as follows in Dbghelp.h.
		/// </para>
		/// <para>
		/// <code>#if !defined(_IMAGEHLP_SOURCE_) &amp;&amp; defined(_IMAGEHLP64) #define SymEnumerateModules SymEnumerateModules64 #else BOOL IMAGEAPI SymEnumerateModules( __in HANDLE hProcess, __in PSYM_ENUMMODULES_CALLBACK EnumModulesCallback, __in_opt PVOID UserContext ); #endif</code>
		/// </para>
		/// <para>Examples</para>
		/// <para>For an example, see Enumerating Symbol Modules.</para>
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows/win32/api/dbghelp/nf-dbghelp-symenumeratemodules BOOL IMAGEAPI SymEnumerateModules(
		// HANDLE hProcess, PSYM_ENUMMODULES_CALLBACK EnumModulesCallback, PVOID UserContext );
		[DllImport(Lib_DbgHelp, SetLastError = true, ExactSpelling = true, CharSet = CharSet.Ansi)]
		[PInvokeData("dbghelp.h", MSDNShortId = "NF:dbghelp.SymEnumerateModules")]
		[return: MarshalAs(UnmanagedType.Bool)]
		public static extern bool SymEnumerateModules(HPROCESS hProcess, PSYM_ENUMMODULES_CALLBACK EnumModulesCallback, [In, Optional] IntPtr UserContext);

		/// <summary>Enumerates all modules that have been loaded for the process by the SymLoadModule64 or SymLoadModuleEx function.</summary>
		/// <param name="hProcess">A handle to the process that was originally passed to the SymInitialize function.</param>
		/// <returns>A list of loaded module names and bases.</returns>
		/// <remarks>
		/// <para>
		/// The <c>SymEnumerateModules</c> function enumerates all modules that have been loaded for the process by SymLoadModule, even if
		/// the symbol loading is deferred.
		/// </para>
		/// <para>
		/// All DbgHelp functions, such as this one, are single threaded. Therefore, calls from more than one thread to this function will
		/// likely result in unexpected behavior or memory corruption. To avoid this, you must synchronize all concurrent calls from more
		/// than one thread to this function.
		/// </para>
		/// <para>This function supersedes the <c>SymEnumerateModules</c> function. For more information, see Updated Platform Support.</para>
		/// </remarks>
		[PInvokeData("dbghelp.h", MSDNShortId = "NF:dbghelp.SymEnumerateModules")]
		public static IList<(string ModuleName, IntPtr BaseOfDll)> SymEnumerateModules(HPROCESS hProcess)
		{
			var ret = new List<(string, IntPtr)>();
			bool success;
			if (Vanara.InteropServices.LibHelper.Is64BitProcess)
				success = SymEnumerateModulesW64(hProcess, Callback64);
			else
				success = SymEnumerateModules(hProcess, Callback);
			if (!success)
				Win32Error.ThrowLastErrorUnless(Win32Error.ERROR_NOT_FOUND);
			return ret;

			bool Callback64(string ModuleName, ulong BaseOfDll, IntPtr UserContext) { ret.Add((ModuleName, new IntPtr(unchecked((long)BaseOfDll)))); return true; }
			bool Callback(string ModuleName, uint BaseOfDll, IntPtr UserContext) { ret.Add((ModuleName, new IntPtr(unchecked((int)BaseOfDll)))); return true; }
		}

		/// <summary>Enumerates all modules that have been loaded for the process by the SymLoadModule64 or SymLoadModuleEx function.</summary>
		/// <param name="hProcess">A handle to the process that was originally passed to the SymInitialize function.</param>
		/// <param name="EnumModulesCallback">
		/// The enumeration callback function. This function is called once per module. For more information, see SymEnumerateModulesProc64.
		/// </param>
		/// <param name="UserContext">
		/// A user-defined value or <c>NULL</c>. This value is simply passed to the callback function. Normally, this parameter is used by
		/// an application to pass a pointer to a data structure that lets the callback function establish some type of context.
		/// </param>
		/// <returns>
		/// <para>If the function succeeds, the return value is <c>TRUE</c>.</para>
		/// <para>If the function fails, the return value is <c>FALSE</c>. To retrieve extended error information, call GetLastError.</para>
		/// </returns>
		/// <remarks>
		/// <para>
		/// The <c>SymEnumerateModules64</c> function enumerates all modules that have been loaded for the process by SymLoadModule64, even
		/// if the symbol loading is deferred. The enumeration callback function is called once for each module and is passed the module information.
		/// </para>
		/// <para>
		/// All DbgHelp functions, such as this one, are single threaded. Therefore, calls from more than one thread to this function will
		/// likely result in unexpected behavior or memory corruption. To avoid this, you must synchronize all concurrent calls from more
		/// than one thread to this function.
		/// </para>
		/// <para>
		/// To call the Unicode version of this function, define DBGHELP_TRANSLATE_TCHAR. <c>SymEnumerateModulesW64</c> is defined as
		/// follows in Dbghelp.h.
		/// </para>
		/// <para>
		/// <code> BOOL IMAGEAPI SymEnumerateModulesW64( __in HANDLE hProcess, __in PSYM_ENUMMODULES_CALLBACKW64 EnumModulesCallback, __in_opt PVOID UserContext ); #ifdef DBGHELP_TRANSLATE_TCHAR #define SymEnumerateModules64 SymEnumerateModulesW64 #endif</code>
		/// </para>
		/// <para>
		/// This function supersedes the <c>SymEnumerateModules</c> function. For more information, see Updated Platform Support.
		/// <c>SymEnumerateModules</c> is defined as follows in Dbghelp.h.
		/// </para>
		/// <para>
		/// <code>#if !defined(_IMAGEHLP_SOURCE_) &amp;&amp; defined(_IMAGEHLP64) #define SymEnumerateModules SymEnumerateModules64 #else BOOL IMAGEAPI SymEnumerateModules( __in HANDLE hProcess, __in PSYM_ENUMMODULES_CALLBACK EnumModulesCallback, __in_opt PVOID UserContext ); #endif</code>
		/// </para>
		/// <para>Examples</para>
		/// <para>For an example, see Enumerating Symbol Modules.</para>
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows/win32/api/dbghelp/nf-dbghelp-symenumeratemodules64 BOOL IMAGEAPI SymEnumerateModules64(
		// HANDLE hProcess, PSYM_ENUMMODULES_CALLBACK64 EnumModulesCallback, PVOID UserContext );
		[DllImport(Lib_DbgHelp, SetLastError = true, CharSet = CharSet.Ansi, ExactSpelling = true)]
		[PInvokeData("dbghelp.h", MSDNShortId = "NF:dbghelp.SymEnumerateModules64")]
		[return: MarshalAs(UnmanagedType.Bool)]
		public static extern bool SymEnumerateModules64(HPROCESS hProcess, PSYM_ENUMMODULES_CALLBACK64 EnumModulesCallback, [In, Optional] IntPtr UserContext);

		/// <summary>Enumerates all modules that have been loaded for the process by the SymLoadModule64 or SymLoadModuleEx function.</summary>
		/// <param name="hProcess">A handle to the process that was originally passed to the SymInitialize function.</param>
		/// <param name="EnumModulesCallback">
		/// The enumeration callback function. This function is called once per module. For more information, see SymEnumerateModulesProc64.
		/// </param>
		/// <param name="UserContext">
		/// A user-defined value or <c>NULL</c>. This value is simply passed to the callback function. Normally, this parameter is used by
		/// an application to pass a pointer to a data structure that lets the callback function establish some type of context.
		/// </param>
		/// <returns>
		/// <para>If the function succeeds, the return value is <c>TRUE</c>.</para>
		/// <para>If the function fails, the return value is <c>FALSE</c>. To retrieve extended error information, call GetLastError.</para>
		/// </returns>
		/// <remarks>
		/// <para>
		/// The <c>SymEnumerateModules64</c> function enumerates all modules that have been loaded for the process by SymLoadModule64, even
		/// if the symbol loading is deferred. The enumeration callback function is called once for each module and is passed the module information.
		/// </para>
		/// <para>
		/// All DbgHelp functions, such as this one, are single threaded. Therefore, calls from more than one thread to this function will
		/// likely result in unexpected behavior or memory corruption. To avoid this, you must synchronize all concurrent calls from more
		/// than one thread to this function.
		/// </para>
		/// <para>
		/// To call the Unicode version of this function, define DBGHELP_TRANSLATE_TCHAR. <c>SymEnumerateModulesW64</c> is defined as
		/// follows in Dbghelp.h.
		/// </para>
		/// <para>
		/// <code> BOOL IMAGEAPI SymEnumerateModulesW64( __in HANDLE hProcess, __in PSYM_ENUMMODULES_CALLBACKW64 EnumModulesCallback, __in_opt PVOID UserContext ); #ifdef DBGHELP_TRANSLATE_TCHAR #define SymEnumerateModules64 SymEnumerateModulesW64 #endif</code>
		/// </para>
		/// <para>
		/// This function supersedes the <c>SymEnumerateModules</c> function. For more information, see Updated Platform Support.
		/// <c>SymEnumerateModules</c> is defined as follows in Dbghelp.h.
		/// </para>
		/// <para>
		/// <code>#if !defined(_IMAGEHLP_SOURCE_) &amp;&amp; defined(_IMAGEHLP64) #define SymEnumerateModules SymEnumerateModules64 #else BOOL IMAGEAPI SymEnumerateModules( __in HANDLE hProcess, __in PSYM_ENUMMODULES_CALLBACK EnumModulesCallback, __in_opt PVOID UserContext ); #endif</code>
		/// </para>
		/// <para>Examples</para>
		/// <para>For an example, see Enumerating Symbol Modules.</para>
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows/win32/api/dbghelp/nf-dbghelp-symenumeratemodulesw64 BOOL IMAGEAPI
		// SymEnumerateModulesW64( HANDLE hProcess, PSYM_ENUMMODULES_CALLBACKW64 EnumModulesCallback, PVOID UserContext );
		[DllImport(Lib_DbgHelp, SetLastError = true, CharSet = CharSet.Unicode, ExactSpelling = true)]
		[PInvokeData("dbghelp.h", MSDNShortId = "NF:dbghelp.SymEnumerateModulesW64")]
		[return: MarshalAs(UnmanagedType.Bool)]
		public static extern bool SymEnumerateModulesW64(HPROCESS hProcess, PSYM_ENUMMODULES_CALLBACK64 EnumModulesCallback, [In, Optional] IntPtr UserContext);

		/// <summary>Enumerates all lines in the specified module.</summary>
		/// <param name="hProcess">A handle to a process. This handle must have been previously passed to the SymInitialize function.</param>
		/// <param name="Base">The base address of the module.</param>
		/// <param name="Obj">
		/// The name of an .obj file within the module. The scope of the enumeration is limited to this file. If this parameter is
		/// <c>NULL</c> or an empty string, all .obj files are searched.
		/// </param>
		/// <param name="File">
		/// A wildcard expression that indicates the names of the source files to be searched. If this parameter is <c>NULL</c> or an empty
		/// string, all files are searched.
		/// </param>
		/// <param name="EnumLinesCallback">A SymEnumLinesProc callback function that receives the line information.</param>
		/// <param name="UserContext">
		/// A user-defined value that is passed to the callback function, or <c>NULL</c>. This parameter is typically used by an application
		/// to pass a pointer to a data structure that provides context for the callback function.
		/// </param>
		/// <returns>
		/// <para>If the function succeeds, the return value is <c>TRUE</c>.</para>
		/// <para>If the function fails, the return value is <c>FALSE</c>. To retrieve extended error information, call GetLastError.</para>
		/// </returns>
		/// <remarks>
		/// <para>
		/// This function is supported for PDB information only. If you have COFF information, try using one of the <c>SymGetLineXXX</c> functions.
		/// </para>
		/// <para>
		/// All DbgHelp functions, such as this one, are single threaded. Therefore, calls from more than one thread to this function will
		/// likely result in unexpected behavior or memory corruption. To avoid this, you must synchronize all concurrent calls from more
		/// than one thread to this function.
		/// </para>
		/// <para>To call the Unicode version of this function, define DBGHELP_TRANSLATE_TCHAR.</para>
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows/win32/api/dbghelp/nf-dbghelp-symenumlines BOOL IMAGEAPI SymEnumLines( HANDLE hProcess,
		// ULONG64 Base, PCSTR Obj, PCSTR File, PSYM_ENUMLINES_CALLBACK EnumLinesCallback, PVOID UserContext );
		[DllImport(Lib_DbgHelp, SetLastError = true, CharSet = CharSet.Auto)]
		[PInvokeData("dbghelp.h", MSDNShortId = "NF:dbghelp.SymEnumLines")]
		[return: MarshalAs(UnmanagedType.Bool)]
		public static extern bool SymEnumLines(HPROCESS hProcess, ulong Base, [Optional, MarshalAs(UnmanagedType.LPTStr)] string Obj, [Optional, MarshalAs(UnmanagedType.LPTStr)] string File,
			PSYM_ENUMLINES_CALLBACK EnumLinesCallback, [In, Optional] IntPtr UserContext);

		/// <summary>Enumerates all lines in the specified module.</summary>
		/// <param name="hProcess">A handle to a process. This handle must have been previously passed to the SymInitialize function.</param>
		/// <param name="Base">The base address of the module.</param>
		/// <param name="Obj">
		/// The name of an .obj file within the module. The scope of the enumeration is limited to this file. If this parameter is
		/// <c>NULL</c> or an empty string, all .obj files are searched.
		/// </param>
		/// <param name="File">
		/// A wildcard expression that indicates the names of the source files to be searched. If this parameter is <c>NULL</c> or an empty
		/// string, all files are searched.
		/// </param>
		/// <returns>
		/// A list of the line information items (.obj file name, sourc file name, line number and the address of the first line).
		/// </returns>
		/// <remarks>
		/// <para>
		/// This function is supported for PDB information only. If you have COFF information, try using one of the <c>SymGetLineXXX</c> functions.
		/// </para>
		/// <para>
		/// All DbgHelp functions, such as this one, are single threaded. Therefore, calls from more than one thread to this function will
		/// likely result in unexpected behavior or memory corruption. To avoid this, you must synchronize all concurrent calls from more
		/// than one thread to this function.
		/// </para>
		/// </remarks>
		public static IList<(string Obj, string FileName, uint LineNumber, ulong Address)> SymEnumLines(HPROCESS hProcess, ulong Base, string Obj = null, string File = null)
		{
			var ret = new List<(string, string, uint, ulong)>();
			if (!SymEnumLines(hProcess, Base, Obj, File, Callback))
				Win32Error.ThrowLastErrorUnless(Win32Error.ERROR_NOT_FOUND);
			return ret;

			bool Callback(in SRCCODEINFO LineInfo, IntPtr UserContext) { ret.Add((LineInfo.Obj, LineInfo.FileName, LineInfo.LineNumber, LineInfo.Address)); return true; }
		}

		/// <summary>Enumerates each process that has called the SymInitialize function.</summary>
		/// <param name="EnumProcessesCallback">A SymEnumProcessesProc callback function that receives the process information.</param>
		/// <param name="UserContext">
		/// A user-defined value that is passed to the callback function, or <c>NULL</c>. This parameter is typically used by an application
		/// to pass a pointer to a data structure that provides context for the callback function.
		/// </param>
		/// <returns>
		/// <para>If the function succeeds, the return value is <c>TRUE</c>.</para>
		/// <para>If the function fails, the return value is <c>FALSE</c>. To retrieve extended error information, call GetLastError.</para>
		/// </returns>
		/// <remarks>
		/// All DbgHelp functions, such as this one, are single threaded. Therefore, calls from more than one thread to this function will
		/// likely result in unexpected behavior or memory corruption. To avoid this, you must synchronize all concurrent calls from more
		/// than one thread to this function.
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows/win32/api/dbghelp/nf-dbghelp-symenumprocesses BOOL IMAGEAPI SymEnumProcesses(
		// PSYM_ENUMPROCESSES_CALLBACK EnumProcessesCallback, PVOID UserContext );
		[DllImport(Lib_DbgHelp, SetLastError = true, ExactSpelling = true)]
		[PInvokeData("dbghelp.h", MSDNShortId = "NF:dbghelp.SymEnumProcesses")]
		[return: MarshalAs(UnmanagedType.Bool)]
		public static extern bool SymEnumProcesses(PSYM_ENUMPROCESSES_CALLBACK EnumProcessesCallback, [In, Optional] IntPtr UserContext);

		/// <summary>Enumerates each process that has called the SymInitialize function.</summary>
		/// <returns>A list of process handles.</returns>
		[PInvokeData("dbghelp.h", MSDNShortId = "NF:dbghelp.SymEnumProcesses")]
		public static IList<HPROCESS> SymEnumProcesses()
		{
			var ret = new List<HPROCESS>();
			if (!SymEnumProcesses(Callback))
				Win32Error.ThrowLastErrorUnless(Win32Error.ERROR_NOT_FOUND);
			return ret;

			bool Callback(HPROCESS hProcess, IntPtr UserContext) { ret.Add(hProcess); return true; }
		}

		/// <summary>Enumerates all source files in a process.</summary>
		/// <param name="hProcess">A handle to a process. This handle must have been previously passed to the SymInitialize function.</param>
		/// <param name="ModBase">
		/// The base address of the module. If this value is zero and Mask contains an exclamation point (!), the function looks across
		/// modules. If this value is zero and Mask does not contain an exclamation point, the function uses the scope established by the
		/// SymSetContext function.
		/// </param>
		/// <param name="Mask">
		/// <para>
		/// A wildcard expression that indicates the names of the source files to be enumerated. To specify a module name, use the !mod syntax.
		/// </para>
		/// <para>If this parameter is <c>NULL</c>, the function will enumerate all files.</para>
		/// </param>
		/// <param name="cbSrcFiles">Pointer to a SymEnumSourceFilesProc callback function that receives the source file information.</param>
		/// <param name="UserContext">
		/// User-defined value that is passed to the callback function, or <c>NULL</c>. This parameter is typically used by an application
		/// to pass a pointer to a data structure that provides context for the callback function.
		/// </param>
		/// <returns>
		/// <para>If the function succeeds, the return value is <c>TRUE</c>.</para>
		/// <para>If the function fails, the return value is <c>FALSE</c>. To retrieve extended error information, call GetLastError.</para>
		/// </returns>
		/// <remarks>
		/// All DbgHelp functions, such as this one, are single threaded. Therefore, calls from more than one thread to this function will
		/// likely result in unexpected behavior or memory corruption. To avoid this, you must synchronize all concurrent calls from more
		/// than one thread to this function.
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows/win32/api/dbghelp/nf-dbghelp-symenumsourcefiles BOOL IMAGEAPI SymEnumSourceFiles( HANDLE
		// hProcess, ULONG64 ModBase, PCSTR Mask, PSYM_ENUMSOURCEFILES_CALLBACK cbSrcFiles, PVOID UserContext );
		[DllImport(Lib_DbgHelp, SetLastError = true, CharSet = CharSet.Auto)]
		[PInvokeData("dbghelp.h", MSDNShortId = "NF:dbghelp.SymEnumSourceFiles")]
		[return: MarshalAs(UnmanagedType.Bool)]
		public static extern bool SymEnumSourceFiles(HPROCESS hProcess, ulong ModBase, [Optional, MarshalAs(UnmanagedType.LPTStr)] string Mask,
			PSYM_ENUMSOURCEFILES_CALLBACK cbSrcFiles, [In, Optional] IntPtr UserContext);

		/// <summary>Enumerates all individual entries in a module's source server data, if available.</summary>
		/// <param name="hProcess">A handle to a process. This handle must have been previously passed to the SymInitialize function.</param>
		/// <param name="Base">The base address of the module.</param>
		/// <param name="Callback">A SymEnumSourceFileTokensProc callback function that receives the symbol information.</param>
		/// <returns>
		/// <para>If the function succeeds, the return value is <c>TRUE</c>.</para>
		/// <para>If the function fails, the return value is <c>FALSE</c>. To retrieve extended error information, call GetLastError.</para>
		/// </returns>
		/// <remarks>
		/// <para>
		/// Some modules have PDB files with source server information detailing the version control information for each of the source
		/// files used to create each individual module. An application can use this function to enumerate the data for every source file
		/// that was "source indexed".
		/// </para>
		/// <para>
		/// All DbgHelp functions, such as this one, are single threaded. Therefore, calls from more than one thread to this function will
		/// likely result in unexpected behavior or memory corruption. To avoid this, you must synchronize all concurrent calls from more
		/// than one thread to this function.
		/// </para>
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows/win32/api/dbghelp/nf-dbghelp-symenumsourcefiletokens BOOL IMAGEAPI
		// SymEnumSourceFileTokens( HANDLE hProcess, ULONG64 Base, PENUMSOURCEFILETOKENSCALLBACK Callback );
		[DllImport(Lib_DbgHelp, SetLastError = true, ExactSpelling = true)]
		[PInvokeData("dbghelp.h", MSDNShortId = "NF:dbghelp.SymEnumSourceFileTokens")]
		[return: MarshalAs(UnmanagedType.Bool)]
		public static extern bool SymEnumSourceFileTokens(HPROCESS hProcess, ulong Base, PENUMSOURCEFILETOKENSCALLBACK Callback);

		/// <summary>Enumerates all source lines in a module.</summary>
		/// <param name="hProcess">A handle to a process. This handle must have been previously passed to the SymInitialize function.</param>
		/// <param name="Base">The base address of the module.</param>
		/// <param name="Obj">
		/// The name of an .obj file within the module. The scope of the enumeration is limited to this file. If this parameter is
		/// <c>NULL</c> or an empty string, all .obj files are searched.
		/// </param>
		/// <param name="File">
		/// A wildcard expression that indicates the names of the source files to be searched. If this parameter is <c>NULL</c> or an empty
		/// string, all files are searched.
		/// </param>
		/// <param name="Line">
		/// The line number of a line within the module. The scope of the enumeration is limited to this line. If this parameter is 0, all
		/// lines are searched.
		/// </param>
		/// <param name="Flags">If this parameter is ESLFLAG_FULLPATH, the function matches the full path in the File parameter.</param>
		/// <param name="EnumLinesCallback">A SymEnumLinesProc callback function that receives the line information.</param>
		/// <param name="UserContext">
		/// A user-defined value that is passed to the callback function, or <c>NULL</c>. This parameter is typically used by an application
		/// to pass a pointer to a data structure that provides context for the callback function.
		/// </param>
		/// <returns>
		/// <para>If the function succeeds, the return value is <c>TRUE</c>.</para>
		/// <para>If the function fails, the return value is <c>FALSE</c>. To retrieve extended error information, call GetLastError.</para>
		/// </returns>
		/// <remarks>
		/// All DbgHelp functions, such as this one, are single threaded. Therefore, calls from more than one thread to this function will
		/// likely result in unexpected behavior or memory corruption. To avoid this, you must synchronize all concurrent calls from more
		/// than one thread to this function.
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows/win32/api/dbghelp/nf-dbghelp-symenumsourcelines BOOL IMAGEAPI SymEnumSourceLines( HANDLE
		// hProcess, ULONG64 Base, PCSTR Obj, PCSTR File, DWORD Line, DWORD Flags, PSYM_ENUMLINES_CALLBACK EnumLinesCallback, PVOID
		// UserContext );
		[DllImport(Lib_DbgHelp, SetLastError = true, CharSet = CharSet.Auto)]
		[PInvokeData("dbghelp.h", MSDNShortId = "NF:dbghelp.SymEnumSourceLines")]
		[return: MarshalAs(UnmanagedType.Bool)]
		public static extern bool SymEnumSourceLines(HPROCESS hProcess, ulong Base, [Optional, MarshalAs(UnmanagedType.LPTStr)] string Obj,
			[Optional, MarshalAs(UnmanagedType.LPTStr)] string File, [Optional] uint Line, ESLFLAG Flags, PSYM_ENUMLINES_CALLBACK EnumLinesCallback,
			[In, Optional] IntPtr UserContext);

		/// <summary>Enumerates all symbols in a process.</summary>
		/// <param name="hProcess">A handle to a process. This handle must have been previously passed to the SymInitialize function.</param>
		/// <param name="BaseOfDll">
		/// The base address of the module. If this value is zero and Mask contains an exclamation point (!), the function looks across
		/// modules. If this value is zero and Mask does not contain an exclamation point, the function uses the scope established by the
		/// SymSetContext function.
		/// </param>
		/// <param name="Mask">
		/// <para>
		/// A wildcard string that indicates the names of the symbols to be enumerated. The text can optionally contain the wildcards, "*"
		/// and "?".
		/// </para>
		/// <para>
		/// To specify a specific module or set of modules, begin the text with a wildcard string specifying the module, followed by an
		/// exclamation point. When specifying a module, BaseOfDll is ignored.
		/// </para>
		/// <list type="table">
		/// <listheader>
		/// <term>Value</term>
		/// <term>Meaning</term>
		/// </listheader>
		/// <item>
		/// <term>foo</term>
		/// <term>
		/// If BaseOfDll is not zero, then SymEnumSymbols will look for a global symbol named "foo". If BaseOfDll is zero, then
		/// SymEnumSymbols will look for a local symbol named "foo" within the scope established by the most recent call to the
		/// SymSetContext function.
		/// </term>
		/// </item>
		/// <item>
		/// <term>foo?</term>
		/// <term>
		/// If BaseOfDll is not zero, then SymEnumSymbols will look for a global symbol that starts with "foo" and contains one extra
		/// character afterwards, such as "fool" and "foot". If BaseOfDll is zero, then SymEnumSymbols will look for a symbol that starts
		/// with "foo" and contains one extra character afterwards, such as "fool" and "foot". The search would be within the scope
		/// established by the most recent call to the SymSetContext function.
		/// </term>
		/// </item>
		/// <item>
		/// <term>foo*!bar</term>
		/// <term>
		/// SymEnumSymbols will look in every loaded module that starts with the text "foo" for a symbol called "bar". It could find matches
		/// such as these, "foot!bar", "footlocker!bar", and "fool!bar".
		/// </term>
		/// </item>
		/// <item>
		/// <term>*!*</term>
		/// <term>SymEnumSymbols will enumerate every symbol in every loaded module.</term>
		/// </item>
		/// </list>
		/// </param>
		/// <param name="EnumSymbolsCallback">A SymEnumSymbolsProc callback function that receives the symbol information.</param>
		/// <param name="UserContext">
		/// A user-defined value that is passed to the callback function, or <c>NULL</c>. This parameter is typically used by an application
		/// to pass a pointer to a data structure that provides context for the callback function.
		/// </param>
		/// <returns>
		/// <para>If the function succeeds, the return value is <c>TRUE</c>.</para>
		/// <para>If the function fails, the return value is <c>FALSE</c>. To retrieve extended error information, call GetLastError.</para>
		/// </returns>
		/// <remarks>
		/// <para>
		/// All DbgHelp functions, such as this one, are single threaded. Therefore, calls from more than one thread to this function will
		/// likely result in unexpected behavior or memory corruption. To avoid this, you must synchronize all concurrent calls from more
		/// than one thread to this function.
		/// </para>
		/// <para>To call the Unicode version of this function, define <c>DBGHELP_TRANSLATE_TCHAR</c>.</para>
		/// <para>Examples</para>
		/// <para>For an example, see Enumerating Symbols.</para>
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows/win32/api/dbghelp/nf-dbghelp-symenumsymbols BOOL IMAGEAPI SymEnumSymbols( HANDLE
		// hProcess, ULONG64 BaseOfDll, PCSTR Mask, PSYM_ENUMERATESYMBOLS_CALLBACK EnumSymbolsCallback, PVOID UserContext );
		[DllImport(Lib_DbgHelp, SetLastError = true, CharSet = CharSet.Auto)]
		[PInvokeData("dbghelp.h", MSDNShortId = "NF:dbghelp.SymEnumSymbols")]
		[return: MarshalAs(UnmanagedType.Bool)]
		public static extern bool SymEnumSymbols(HPROCESS hProcess, ulong BaseOfDll, [Optional, MarshalAs(UnmanagedType.LPTStr)] string Mask,
			PSYM_ENUMERATESYMBOLS_CALLBACK EnumSymbolsCallback, [In, Optional] IntPtr UserContext);

		/// <summary>Enumerates all symbols in a process.</summary>
		/// <param name="hProcess">A handle to a process. This handle must have been previously passed to the SymInitialize function.</param>
		/// <param name="BaseOfDll">
		/// The base address of the module. If this value is zero and Mask contains an exclamation point (!), the function looks across
		/// modules. If this value is zero and Mask does not contain an exclamation point, the function uses the scope established by the
		/// SymSetContext function.
		/// </param>
		/// <param name="Mask">
		/// <para>
		/// A wildcard string that indicates the names of the symbols to be enumerated. The text can optionally contain the wildcards, "*"
		/// and "?".
		/// </para>
		/// <para>
		/// To specify a specific module or set of modules, begin the text with a wildcard string specifying the module, followed by an
		/// exclamation point. When specifying a module, BaseOfDll is ignored.
		/// </para>
		/// <list type="table">
		/// <listheader>
		/// <term>Value</term>
		/// <term>Meaning</term>
		/// </listheader>
		/// <item>
		/// <term>foo</term>
		/// <term>
		/// If BaseOfDll is not zero, then SymEnumSymbols will look for a global symbol named "foo". If BaseOfDll is zero, then
		/// SymEnumSymbols will look for a local symbol named "foo" within the scope established by the most recent call to the
		/// SymSetContext function.
		/// </term>
		/// </item>
		/// <item>
		/// <term>foo?</term>
		/// <term>
		/// If BaseOfDll is not zero, then SymEnumSymbols will look for a global symbol that starts with "foo" and contains one extra
		/// character afterwards, such as "fool" and "foot". If BaseOfDll is zero, then SymEnumSymbols will look for a symbol that starts
		/// with "foo" and contains one extra character afterwards, such as "fool" and "foot". The search would be within the scope
		/// established by the most recent call to the SymSetContext function.
		/// </term>
		/// </item>
		/// <item>
		/// <term>foo*!bar</term>
		/// <term>
		/// SymEnumSymbols will look in every loaded module that starts with the text "foo" for a symbol called "bar". It could find matches
		/// such as these, "foot!bar", "footlocker!bar", and "fool!bar".
		/// </term>
		/// </item>
		/// <item>
		/// <term>*!*</term>
		/// <term>SymEnumSymbols will enumerate every symbol in every loaded module.</term>
		/// </item>
		/// </list>
		/// </param>
		/// <param name="EnumSymbolsCallback">A SymEnumSymbolsProc callback function that receives the symbol information.</param>
		/// <param name="UserContext">
		/// A user-defined value that is passed to the callback function, or <c>NULL</c>. This parameter is typically used by an application
		/// to pass a pointer to a data structure that provides context for the callback function.
		/// </param>
		/// <param name="Options">
		/// <para>Indicates possible options.</para>
		/// <list type="table">
		/// <listheader>
		/// <term>Value</term>
		/// <term>Meaning</term>
		/// </listheader>
		/// <item>
		/// <term>SYMENUM_OPTIONS_DEFAULT 1</term>
		/// <term>Use the default options.</term>
		/// </item>
		/// <item>
		/// <term>SYMENUM_OPTIONS_INLINE 2</term>
		/// <term>Enumerate inline symbols.</term>
		/// </item>
		/// </list>
		/// </param>
		/// <returns>
		/// <para>If the function succeeds, the return value is <c>TRUE</c>.</para>
		/// <para>If the function fails, the return value is <c>FALSE</c>. To retrieve extended error information, call GetLastError.</para>
		/// </returns>
		// https://docs.microsoft.com/en-us/windows/win32/api/dbghelp/nf-dbghelp-symenumsymbolsex BOOL IMAGEAPI SymEnumSymbolsEx( HANDLE
		// hProcess, ULONG64 BaseOfDll, PCSTR Mask, PSYM_ENUMERATESYMBOLS_CALLBACK EnumSymbolsCallback, PVOID UserContext, DWORD Options );
		[DllImport(Lib_DbgHelp, SetLastError = true, CharSet = CharSet.Auto)]
		[PInvokeData("dbghelp.h", MSDNShortId = "NF:dbghelp.SymEnumSymbolsEx")]
		[return: MarshalAs(UnmanagedType.Bool)]
		public static extern bool SymEnumSymbolsEx(HPROCESS hProcess, ulong BaseOfDll, [Optional, MarshalAs(UnmanagedType.LPTStr)] string Mask,
			PSYM_ENUMERATESYMBOLS_CALLBACK EnumSymbolsCallback, [In, Optional] IntPtr UserContext, SYMENUM Options);

		/// <summary>Enumerates the symbols for the specified address.</summary>
		/// <param name="hProcess">A handle to a process. This handle must have been previously passed to the SymInitialize function.</param>
		/// <param name="Address">
		/// The address for which symbols are to be located. The address does not have to be on a symbol boundary. If the address comes
		/// after the beginning of a symbol and before the end of the symbol (the beginning of the symbol plus the symbol size), the
		/// function will find the symbol.
		/// </param>
		/// <param name="EnumSymbolsCallback">
		/// An application-defined callback function. This function is called for every symbol found at Address. For more information, see SymEnumSymbolsProc.
		/// </param>
		/// <param name="UserContext">Optional user-defined data. This value is passed to the callback function.</param>
		/// <returns>
		/// <para>If the function succeeds, the return value is <c>TRUE</c>.</para>
		/// <para>If the function fails, the return value is <c>FALSE</c>. To retrieve extended error information, call GetLastError.</para>
		/// </returns>
		/// <remarks>
		/// <para>
		/// All DbgHelp functions, such as this one, are single threaded. Therefore, calls from more than one thread to this function will
		/// likely result in unexpected behavior or memory corruption. To avoid this, you must synchronize all concurrent calls from more
		/// than one thread to this function.
		/// </para>
		/// <para>To call the Unicode version of this function, define DBGHELP_TRANSLATE_TCHAR.</para>
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows/win32/api/dbghelp/nf-dbghelp-symenumsymbolsforaddr BOOL IMAGEAPI SymEnumSymbolsForAddr(
		// HANDLE hProcess, DWORD64 Address, PSYM_ENUMERATESYMBOLS_CALLBACK EnumSymbolsCallback, PVOID UserContext );
		[DllImport(Lib_DbgHelp, SetLastError = true, CharSet = CharSet.Auto)]
		[PInvokeData("dbghelp.h", MSDNShortId = "NF:dbghelp.SymEnumSymbolsForAddr")]
		[return: MarshalAs(UnmanagedType.Bool)]
		public static extern bool SymEnumSymbolsForAddr(HPROCESS hProcess, ulong Address, PSYM_ENUMERATESYMBOLS_CALLBACK EnumSymbolsCallback, [In, Optional] IntPtr UserContext);

		/// <summary>Enumerates all user-defined types.</summary>
		/// <param name="hProcess">A handle to a process. This handle must have been previously passed to the SymInitialize function.</param>
		/// <param name="BaseOfDll">The base address of the module.</param>
		/// <param name="EnumSymbolsCallback">A pointer to an SymEnumSymbolsProc callback function that receives the symbol information.</param>
		/// <param name="UserContext">
		/// A user-defined value to be passed to the callback function, or <c>NULL</c>. This parameter is typically used by an application
		/// to pass a pointer to a data structure that provides context information for the callback function.
		/// </param>
		/// <returns>
		/// <para>If the function succeeds, the return value is <c>TRUE</c>.</para>
		/// <para>If the function fails, the return value is <c>FALSE</c>. To retrieve extended error information, call GetLastError.</para>
		/// </returns>
		/// <remarks>
		/// <para>
		/// All DbgHelp functions, such as this one, are single threaded. Therefore, calls from more than one thread to this function will
		/// likely result in unexpected behavior or memory corruption. To avoid this, you must synchronize all concurrent calls from more
		/// than one thread to this function.
		/// </para>
		/// <para>To call the Unicode version of this function, define DBGHELP_TRANSLATE_TCHAR.</para>
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows/win32/api/dbghelp/nf-dbghelp-symenumtypes BOOL IMAGEAPI SymEnumTypes( HANDLE hProcess,
		// ULONG64 BaseOfDll, PSYM_ENUMERATESYMBOLS_CALLBACK EnumSymbolsCallback, PVOID UserContext );
		[DllImport(Lib_DbgHelp, SetLastError = true, CharSet = CharSet.Auto)]
		[PInvokeData("dbghelp.h", MSDNShortId = "NF:dbghelp.SymEnumTypes")]
		[return: MarshalAs(UnmanagedType.Bool)]
		public static extern bool SymEnumTypes(HPROCESS hProcess, ulong BaseOfDll, PSYM_ENUMERATESYMBOLS_CALLBACK EnumSymbolsCallback, [In, Optional] IntPtr UserContext);

		/// <summary>Enumerates all user-defined types.</summary>
		/// <param name="hProcess">A handle to a process. This handle must have been previously passed to the SymInitialize function.</param>
		/// <param name="BaseOfDll">The base address of the module.</param>
		/// <param name="mask">
		/// A wildcard expression that indicates the names of the symbols to be enumerated. To specify a module name, use the !mod syntax.
		/// </param>
		/// <param name="EnumSymbolsCallback">A pointer to an SymEnumSymbolsProc callback function that receives the symbol information.</param>
		/// <param name="UserContext">
		/// A user-defined value to be passed to the callback function, or <c>NULL</c>. This parameter is typically used by an application
		/// to pass a pointer to a data structure that provides context information for the callback function.
		/// </param>
		/// <returns>
		/// <para>If the function succeeds, the return value is <c>TRUE</c>.</para>
		/// <para>If the function fails, the return value is <c>FALSE</c>. To retrieve extended error information, call GetLastError.</para>
		/// </returns>
		/// <remarks>
		/// <para>
		/// All DbgHelp functions, such as this one, are single threaded. Therefore, calls from more than one thread to this function will
		/// likely result in unexpected behavior or memory corruption. To avoid this, you must synchronize all concurrent calls from more
		/// than one thread to this function.
		/// </para>
		/// <para>To call the Unicode version of this function, define DBGHELP_TRANSLATE_TCHAR.</para>
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows/win32/api/dbghelp/nf-dbghelp-symenumtypesbyname BOOL IMAGEAPI SymEnumTypesByName( HANDLE
		// hProcess, ULONG64 BaseOfDll, PCSTR mask, PSYM_ENUMERATESYMBOLS_CALLBACK EnumSymbolsCallback, PVOID UserContext );
		[DllImport(Lib_DbgHelp, SetLastError = true, CharSet = CharSet.Auto)]
		[PInvokeData("dbghelp.h", MSDNShortId = "NF:dbghelp.SymEnumTypesByName")]
		[return: MarshalAs(UnmanagedType.Bool)]
		public static extern bool SymEnumTypesByName(HPROCESS hProcess, ulong BaseOfDll, [Optional, MarshalAs(UnmanagedType.LPTStr)] string mask,
			PSYM_ENUMERATESYMBOLS_CALLBACK EnumSymbolsCallback, [In, Optional] IntPtr UserContext);

		/// <summary>Locates a .dbg file in the process search path.</summary>
		/// <param name="hProcess">A handle to the process that was originally passed to the SymInitialize function.</param>
		/// <param name="FileName">The name of the .dbg file. You can use a partial path.</param>
		/// <param name="DebugFilePath">The fully qualified path of the .dbg file. This buffer must be at least MAX_PATH characters.</param>
		/// <param name="Callback">
		/// <para>
		/// An application-defined callback function that verifies whether the correct file was found or the function should continue its
		/// search. For more information, see FindDebugInfoFileProc.
		/// </para>
		/// <para>This parameter can be <c>NULL</c>.</para>
		/// </param>
		/// <param name="CallerData">
		/// A user-defined value or <c>NULL</c>. This value is simply passed to the callback function. This parameter is typically used by
		/// an application to pass a pointer to a data structure that provides some context for the callback function.
		/// </param>
		/// <returns>
		/// <para>If the function succeeds, the return value is an open handle to the .dbg file.</para>
		/// <para>If the function fails, the return value is <c>NULL</c>. To retrieve extended error information, call GetLastError.</para>
		/// </returns>
		/// <remarks>
		/// <para>This function uses the search path set using the SymInitialize or SymSetSearchPath function.</para>
		/// <para>
		/// All DbgHelp functions, such as this one, are single threaded. Therefore, calls from more than one thread to this function will
		/// likely result in unexpected behavior or memory corruption. To avoid this, you must synchronize all concurrent calls from more
		/// than one thread to this function.
		/// </para>
		/// <para>To call the Unicode version of this function, define DBGHELP_TRANSLATE_TCHAR.</para>
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows/win32/api/dbghelp/nf-dbghelp-symfinddebuginfofile HANDLE IMAGEAPI SymFindDebugInfoFile(
		// HANDLE hProcess, PCSTR FileName, PSTR DebugFilePath, PFIND_DEBUG_FILE_CALLBACK Callback, PVOID CallerData );
		[DllImport(Lib_DbgHelp, SetLastError = true, CharSet = CharSet.Auto)]
		[PInvokeData("dbghelp.h", MSDNShortId = "NF:dbghelp.SymFindDebugInfoFile")]
		public static extern HFILE SymFindDebugInfoFile(HPROCESS hProcess, [MarshalAs(UnmanagedType.LPTStr)] string FileName,
			[MarshalAs(UnmanagedType.LPTStr)] StringBuilder DebugFilePath, [Optional] PFIND_DEBUG_FILE_CALLBACK Callback, [In, Optional] IntPtr CallerData);

		/// <summary>Locates an executable file in the process search path.</summary>
		/// <param name="hProcess">A handle to the process that was originally passed to the SymInitialize function.</param>
		/// <param name="FileName">The name of the executable file. You can use a partial path.</param>
		/// <param name="ImageFilePath">The fully qualified path of the executable file. This buffer must be at least MAX_PATH characters.</param>
		/// <param name="Callback">
		/// <para>
		/// An application-defined callback function that verifies whether the correct executable file was found, or whether the function
		/// should continue its search. For more information, see FindExecutableImageProc.
		/// </para>
		/// <para>This parameter can be <c>NULL</c>.</para>
		/// </param>
		/// <param name="CallerData">
		/// A user-defined value or <c>NULL</c>. This value is simply passed to the callback function. This parameter is typically used by
		/// an application to pass a pointer to a data structure that provides some context for the callback function.
		/// </param>
		/// <returns>
		/// <para>If the function succeeds, the return value is an open handle to the executable file.</para>
		/// <para>If the function fails, the return value is <c>NULL</c>. To retrieve extended error information, call GetLastError.</para>
		/// </returns>
		/// <remarks>
		/// <para>This function uses the search path set using the SymInitialize or SymSetSearchPath function.</para>
		/// <para>
		/// All DbgHelp functions, such as this one, are single threaded. Therefore, calls from more than one thread to this function will
		/// likely result in unexpected behavior or memory corruption. To avoid this, you must synchronize all concurrent calls from more
		/// than one thread to this function.
		/// </para>
		/// <para>To call the Unicode version of this function, define DBGHELP_TRANSLATE_TCHAR.</para>
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows/win32/api/dbghelp/nf-dbghelp-symfindexecutableimage HANDLE IMAGEAPI
		// SymFindExecutableImage( HANDLE hProcess, PCSTR FileName, PSTR ImageFilePath, PFIND_EXE_FILE_CALLBACK Callback, PVOID CallerData );
		[DllImport(Lib_DbgHelp, SetLastError = true, CharSet = CharSet.Auto)]
		[PInvokeData("dbghelp.h", MSDNShortId = "NF:dbghelp.SymFindExecutableImage")]
		public static extern HFILE SymFindExecutableImage(HPROCESS hProcess, [MarshalAs(UnmanagedType.LPTStr)] string FileName,
			[MarshalAs(UnmanagedType.LPTStr)] StringBuilder ImageFilePath, [Optional] PFIND_EXE_FILE_CALLBACK Callback, [In, Optional] IntPtr CallerData);

		/// <summary>Locates a symbol file or executable image.</summary>
		/// <param name="hprocess">A handle to the process that was originally passed to the SymInitialize function.</param>
		/// <param name="SearchPath">
		/// The search path. This can be multiple paths separated by semicolons. It can include both directories and symbol servers. If this
		/// parameter is <c>NULL</c>, the function uses the search path set using the SymSetSearchPath or SymInitialize function.
		/// </param>
		/// <param name="FileName">The name of the file. You can specify a path; however, only the file name is used.</param>
		/// <param name="id">The first of three identifying parameters (see Remarks).</param>
		/// <param name="two">The second of three identifying parameters (see Remarks).</param>
		/// <param name="three">The third of three identifying parameters (see Remarks).</param>
		/// <param name="flags">
		/// <para>The format of the id parameter. This parameter can be one of the following values.</para>
		/// <list type="table">
		/// <listheader>
		/// <term>Value</term>
		/// <term>Meaning</term>
		/// </listheader>
		/// <item>
		/// <term>SSRVOPT_DWORD 0x0002</term>
		/// <term>The id parameter is a DWORD.</term>
		/// </item>
		/// <item>
		/// <term>SSRVOPT_DWORDPTR 0x0004</term>
		/// <term>The id parameter is a pointer to a DWORD.</term>
		/// </item>
		/// <item>
		/// <term>SSRVOPT_GUIDPTR 0x0008</term>
		/// <term>The id parameter is a pointer to a GUID.</term>
		/// </item>
		/// </list>
		/// </param>
		/// <param name="FoundFile">
		/// A pointer to a buffer that receives the fully qualified path to the symbol file. This buffer must be at least MAX_PATH characters.
		/// </param>
		/// <param name="callback">A SymFindFileInPathProc callback function.</param>
		/// <param name="context">
		/// A user-defined value or <c>NULL</c>. This value is simply passed to the callback function. This parameter is typically used by
		/// an application to pass a pointer to a data structure that provides some context for the callback function.
		/// </param>
		/// <returns>
		/// If the server locates a valid symbol file, it returns <c>TRUE</c>; otherwise, it returns <c>FALSE</c> and GetLastError returns a
		/// value that indicates why the symbol file was not returned.
		/// </returns>
		/// <remarks>
		/// <para>The identifying parameters are filled in as follows:</para>
		/// <list type="bullet">
		/// <item>
		/// <term>
		/// If DbgHelp is looking for a .pdb file, the id parameter specifies the PDB signature as found in the codeview debug directory of
		/// the original image. Parameter two specifies the PDB age. Parameter three is unused and set to zero.
		/// </term>
		/// </item>
		/// <item>
		/// <term>
		/// If DbgHelp is looking for any other type of image, such as an executable file or .dbg file, the id parameter specifies the
		/// TimeDateStamp of the original image as found in its PE header. Parameter two specifies the SizeOfImage field, also extracted
		/// from the PE header. Parameter three is unused and set to zero.
		/// </term>
		/// </item>
		/// </list>
		/// <para>All of these values can be obtained by calling SymSrvGetFileIndexInfo.</para>
		/// <para>
		/// When searching a directory, this function does not verify that the symbol identifiers match by default. To ensure the matching
		/// symbol files are located, call the SymSetOptions function with SYMOPT_EXACT_SYMBOLS.
		/// </para>
		/// <para>
		/// All DbgHelp functions, such as this one, are single threaded. Therefore, calls from more than one thread to this function will
		/// likely result in unexpected behavior or memory corruption. To avoid this, you must synchronize all concurrent calls from more
		/// than one thread to this function.
		/// </para>
		/// <para>To call the Unicode version of this function, define DBGHELP_TRANSLATE_TCHAR.</para>
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows/win32/api/dbghelp/nf-dbghelp-symfindfileinpath BOOL IMAGEAPI SymFindFileInPath( HANDLE
		// hprocess, PCSTR SearchPath, PCSTR FileName, PVOID id, DWORD two, DWORD three, DWORD flags, PSTR FoundFile,
		// PFINDFILEINPATHCALLBACK callback, PVOID context );
		[DllImport(Lib_DbgHelp, SetLastError = true, CharSet = CharSet.Auto)]
		[PInvokeData("dbghelp.h", MSDNShortId = "NF:dbghelp.SymFindFileInPath")]
		[return: MarshalAs(UnmanagedType.Bool)]
		public static extern bool SymFindFileInPath(HPROCESS hprocess, [Optional, MarshalAs(UnmanagedType.LPTStr)] string SearchPath,
			[MarshalAs(UnmanagedType.LPTStr)] string FileName, [In, Optional] IntPtr id, uint two, uint three, SSRVOPT flags,
			[MarshalAs(UnmanagedType.LPTStr)] StringBuilder FoundFile, [In, Optional] PFINDFILEINPATHCALLBACK callback, [In, Optional] IntPtr context);

		/// <summary>Initializes the symbol handler for a process.</summary>
		/// <param name="hProcess">
		/// <para>
		/// A handle that identifies the caller. This value should be unique and nonzero, but need not be a process handle. However, if you
		/// do use a process handle, be sure to use the correct handle. If the application is a debugger, use the process handle for the
		/// process being debugged. Do not use the handle returned by GetCurrentProcess when debugging another process, because calling
		/// functions like SymLoadModuleEx can have unexpected results.
		/// </para>
		/// <para>This parameter cannot be <c>NULL</c>.</para>
		/// </param>
		/// <param name="UserSearchPath">
		/// <para>
		/// The path, or series of paths separated by a semicolon (;), that is used to search for symbol files. If this parameter is
		/// <c>NULL</c>, the library attempts to form a symbol path from the following sources:
		/// </para>
		/// <list type="bullet">
		/// <item>
		/// <term>The current working directory of the application</term>
		/// </item>
		/// <item>
		/// <term>The _NT_SYMBOL_PATH environment variable</term>
		/// </item>
		/// <item>
		/// <term>The _NT_ALTERNATE_SYMBOL_PATH environment variable</term>
		/// </item>
		/// </list>
		/// <para>Note that the search path can also be set using the</para>
		/// <para>SymSetSearchPath</para>
		/// <para>function.</para>
		/// </param>
		/// <param name="fInvadeProcess">
		/// If this value is <c>TRUE</c>, enumerates the loaded modules for the process and effectively calls the SymLoadModule64 function
		/// for each module.
		/// </param>
		/// <returns>
		/// <para>If the function succeeds, the return value is <c>TRUE</c>.</para>
		/// <para>If the function fails, the return value is <c>FALSE</c>. To retrieve extended error information, call GetLastError.</para>
		/// </returns>
		/// <remarks>
		/// <para>
		/// The <c>SymInitialize</c> function is used to initialize the symbol handler for a process. In the context of the symbol handler,
		/// a process is a convenient object to use when collecting symbol information. Usually, symbol handlers are used by debuggers and
		/// other tools that need to load symbols for a process being debugged.
		/// </para>
		/// <para>
		/// The handle passed to <c>SymInitialize</c> must be the same value passed to all other symbol handler functions called by the
		/// process. It is the handle that the functions use to identify the caller and locate the correct symbol information. When you have
		/// finished using the symbol information, call the SymCleanup function to deallocate all resources associated with the process for
		/// which symbols are loaded.
		/// </para>
		/// <para>
		/// The search for symbols files is performed recursively for all paths specified in the UserSearchPath parameter. Therefore, if you
		/// specify the root directory in a search, the whole drive is searched, which can take significant time. Note that the directory
		/// that contains the executable file for the process is not automatically part of the search path. To include this directory in the
		/// search path, call the GetModuleFileNameEx function, then add the path returned to UserSearchPath.
		/// </para>
		/// <para>
		/// A process that calls <c>SymInitialize</c> should not call it again unless it calls SymCleanup first. If the call to
		/// <c>SymInitialize</c> set fInvadeProcess to <c>TRUE</c> and you simply need to reload the module list, use the
		/// SymRefreshModuleList function.
		/// </para>
		/// <para>
		/// All DbgHelp functions, such as this one, are single threaded. Therefore, calls from more than one thread to this function will
		/// likely result in unexpected behavior or memory corruption. To avoid this, call <c>SymInitialize</c> only when your process
		/// starts and SymCleanup only when your process ends. It is not necessary for each thread in the process to call these functions.
		/// </para>
		/// <para>To call the Unicode version of this function, define DBGHELP_TRANSLATE_TCHAR.</para>
		/// <para>Examples</para>
		/// <para>For an example, see Initializing the Symbol Handler.</para>
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows/win32/api/dbghelp/nf-dbghelp-syminitialize BOOL IMAGEAPI SymInitialize( HANDLE hProcess,
		// PCSTR UserSearchPath, BOOL fInvadeProcess );
		[DllImport(Lib_DbgHelp, SetLastError = true, CharSet = CharSet.Auto)]
		[PInvokeData("dbghelp.h", MSDNShortId = "NF:dbghelp.SymInitialize")]
		[return: MarshalAs(UnmanagedType.Bool)]
		public static extern bool SymInitialize(HPROCESS hProcess, [Optional, MarshalAs(UnmanagedType.LPTStr)] string UserSearchPath, [MarshalAs(UnmanagedType.Bool)] bool fInvadeProcess);

		/// <summary>Refreshes the module list for the process.</summary>
		/// <param name="hProcess">A handle to a process. This handle must have been previously passed to the SymInitialize function.</param>
		/// <returns>
		/// <para>If the function succeeds, the return value is <c>TRUE</c>.</para>
		/// <para>If the function fails, the return value is <c>FALSE</c>. To retrieve extended error information, call GetLastError.</para>
		/// </returns>
		/// <remarks>
		/// <para>
		/// This function enumerates the loaded modules for the process and effectively calls the SymLoadModule64 function for each module.
		/// This same process is performed by SymInitialize if fInvadeProcess is <c>TRUE</c>.
		/// </para>
		/// <para>
		/// All DbgHelp functions, such as this one, are single threaded. Therefore, calls from more than one thread to this function will
		/// likely result in unexpected behavior or memory corruption. To avoid this, you must synchronize all concurrent calls from more
		/// than one thread to this function.
		/// </para>
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows/win32/api/dbghelp/nf-dbghelp-symrefreshmodulelist BOOL IMAGEAPI SymRefreshModuleList(
		// HANDLE hProcess );
		[DllImport(Lib_DbgHelp, SetLastError = true, ExactSpelling = true)]
		[PInvokeData("dbghelp.h", MSDNShortId = "NF:dbghelp.SymRefreshModuleList")]
		[return: MarshalAs(UnmanagedType.Bool)]
		public static extern bool SymRefreshModuleList(HPROCESS hProcess);

		/// <summary>Sets the options mask.</summary>
		/// <param name="SymOptions">
		/// <para>
		/// The symbol options. Zero is a valid value and indicates that all options are turned off. The options values are combined using
		/// the OR operator to form a valid options value. The following are valid values.
		/// </para>
		/// <list type="table">
		/// <listheader>
		/// <term>Value</term>
		/// <term>Meaning</term>
		/// </listheader>
		/// <item>
		/// <term>SYMOPT_ALLOW_ABSOLUTE_SYMBOLS 0x00000800</term>
		/// <term>
		/// Enables the use of symbols that are stored with absolute addresses. Most symbols are stored as RVAs from the base of the module.
		/// DbgHelp translates them to absolute addresses. There are symbols that are stored as an absolute address. These have very
		/// specialized purposes and are typically not used. DbgHelp 5.1 and earlier: This value is not supported.
		/// </term>
		/// </item>
		/// <item>
		/// <term>SYMOPT_ALLOW_ZERO_ADDRESS 0x01000000</term>
		/// <term>Enables the use of symbols that do not have an address. By default, DbgHelp filters out symbols that do not have an address.</term>
		/// </item>
		/// <item>
		/// <term>SYMOPT_AUTO_PUBLICS 0x00010000</term>
		/// <term>
		/// Do not search the public symbols when searching for symbols by address, or when enumerating symbols, unless they were not found
		/// in the global symbols or within the current scope. This option has no effect with SYMOPT_PUBLICS_ONLY. DbgHelp 5.1 and earlier:
		/// This value is not supported.
		/// </term>
		/// </item>
		/// <item>
		/// <term>SYMOPT_CASE_INSENSITIVE 0x00000001</term>
		/// <term>All symbol searches are insensitive to case.</term>
		/// </item>
		/// <item>
		/// <term>SYMOPT_DEBUG 0x80000000</term>
		/// <term>Pass debug output through OutputDebugString or the SymRegisterCallbackProc64 callback function.</term>
		/// </item>
		/// <item>
		/// <term>SYMOPT_DEFERRED_LOADS 0x00000004</term>
		/// <term>
		/// Symbols are not loaded until a reference is made requiring the symbols be loaded. This is the fastest, most efficient way to use
		/// the symbol handler.
		/// </term>
		/// </item>
		/// <item>
		/// <term>SYMOPT_DISABLE_SYMSRV_AUTODETECT 0x02000000</term>
		/// <term>
		/// Disables the auto-detection of symbol server stores in the symbol path, even without the "SRV*" designation, maintaining
		/// compatibility with previous behavior. DbgHelp 6.6 and earlier: This value is not supported.
		/// </term>
		/// </item>
		/// <item>
		/// <term>SYMOPT_EXACT_SYMBOLS 0x00000400</term>
		/// <term>Do not load an unmatched .pdb file. Do not load export symbols if all else fails.</term>
		/// </item>
		/// <item>
		/// <term>SYMOPT_FAIL_CRITICAL_ERRORS 0x00000200</term>
		/// <term>
		/// Do not display system dialog boxes when there is a media failure such as no media in a drive. Instead, the failure happens silently.
		/// </term>
		/// </item>
		/// <item>
		/// <term>SYMOPT_FAVOR_COMPRESSED 0x00800000</term>
		/// <term>
		/// If there is both an uncompressed and a compressed file available, favor the compressed file. This option is good for slow connections.
		/// </term>
		/// </item>
		/// <item>
		/// <term>SYMOPT_FLAT_DIRECTORY 0x00400000</term>
		/// <term>Symbols are stored in the root directory of the default downstream store. DbgHelp 6.1 and earlier: This value is not supported.</term>
		/// </item>
		/// <item>
		/// <term>SYMOPT_IGNORE_CVREC 0x00000080</term>
		/// <term>Ignore path information in the CodeView record of the image header when loading a .pdb file.</term>
		/// </item>
		/// <item>
		/// <term>SYMOPT_IGNORE_IMAGEDIR 0x00200000</term>
		/// <term>Ignore the image directory. DbgHelp 6.1 and earlier: This value is not supported.</term>
		/// </item>
		/// <item>
		/// <term>SYMOPT_IGNORE_NT_SYMPATH 0x00001000</term>
		/// <term>
		/// Do not use the path specified by _NT_SYMBOL_PATH if the user calls SymSetSearchPath without a valid path. DbgHelp 5.1: This
		/// value is not supported.
		/// </term>
		/// </item>
		/// <item>
		/// <term>SYMOPT_INCLUDE_32BIT_MODULES 0x00002000</term>
		/// <term>When debugging on 64-bit Windows, include any 32-bit modules.</term>
		/// </item>
		/// <item>
		/// <term>SYMOPT_LOAD_ANYTHING 0x00000040</term>
		/// <term>Disable checks to ensure a file (.exe, .dbg., or .pdb) is the correct file. Instead, load the first file located.</term>
		/// </item>
		/// <item>
		/// <term>SYMOPT_LOAD_LINES 0x00000010</term>
		/// <term>Loads line number information.</term>
		/// </item>
		/// <item>
		/// <term>SYMOPT_NO_CPP 0x00000008</term>
		/// <term>
		/// All C++ decorated symbols containing the symbol separator "::" are replaced by "__". This option exists for debuggers that
		/// cannot handle parsing real C++ symbol names.
		/// </term>
		/// </item>
		/// <item>
		/// <term>SYMOPT_NO_IMAGE_SEARCH 0x00020000</term>
		/// <term>
		/// Do not search the image for the symbol path when loading the symbols for a module if the module header cannot be read. DbgHelp
		/// 5.1: This value is not supported.
		/// </term>
		/// </item>
		/// <item>
		/// <term>SYMOPT_NO_PROMPTS 0x00080000</term>
		/// <term>Prevents prompting for validation from the symbol server.</term>
		/// </item>
		/// <item>
		/// <term>SYMOPT_NO_PUBLICS 0x00008000</term>
		/// <term>
		/// Do not search the publics table for symbols. This option should have little effect because there are copies of the public
		/// symbols in the globals table. DbgHelp 5.1: This value is not supported.
		/// </term>
		/// </item>
		/// <item>
		/// <term>SYMOPT_NO_UNQUALIFIED_LOADS 0x00000100</term>
		/// <term>
		/// Prevents symbols from being loaded when the caller examines symbols across multiple modules. Examine only the module whose
		/// symbols have already been loaded.
		/// </term>
		/// </item>
		/// <item>
		/// <term>SYMOPT_OVERWRITE 0x00100000</term>
		/// <term>Overwrite the downlevel store from the symbol store. DbgHelp 6.1 and earlier: This value is not supported.</term>
		/// </item>
		/// <item>
		/// <term>SYMOPT_PUBLICS_ONLY 0x00004000</term>
		/// <term>
		/// Do not use private symbols. The version of DbgHelp that shipped with earlier Windows release supported only public symbols; this
		/// option provides compatibility with this limitation. DbgHelp 5.1: This value is not supported.
		/// </term>
		/// </item>
		/// <item>
		/// <term>SYMOPT_SECURE 0x00040000</term>
		/// <term>
		/// DbgHelp will not load any symbol server other than SymSrv. SymSrv will not use the downstream store specified in
		/// _NT_SYMBOL_PATH. After this flag has been set, it cannot be cleared. DbgHelp 6.0 and 6.1: This flag can be cleared. DbgHelp 5.1:
		/// This value is not supported.
		/// </term>
		/// </item>
		/// <item>
		/// <term>SYMOPT_UNDNAME 0x00000002</term>
		/// <term>
		/// All symbols are presented in undecorated form. This option has no effect on global or local symbols because they are stored
		/// undecorated. This option applies only to public symbols.
		/// </term>
		/// </item>
		/// </list>
		/// </param>
		/// <returns>The function returns the current options mask.</returns>
		/// <remarks>
		/// <para>
		/// The options value can be changed any number of times while the library is in use by an application. The option change affects
		/// all future calls to the symbol handler.
		/// </para>
		/// <para>To get the current options mask, call the SymGetOptions function.</para>
		/// <para>
		/// All DbgHelp functions, such as this one, are single threaded. Therefore, calls from more than one thread to this function will
		/// likely result in unexpected behavior or memory corruption. To avoid this, you must synchronize all concurrent calls from more
		/// than one thread to this function.
		/// </para>
		/// <para>Examples</para>
		/// <para>For an example, see Initializing the Symbol Handler.</para>
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows/win32/api/dbghelp/nf-dbghelp-symsetoptions DWORD IMAGEAPI SymSetOptions( DWORD
		// SymOptions );
		[DllImport(Lib_DbgHelp, SetLastError = false, ExactSpelling = true)]
		[PInvokeData("dbghelp.h", MSDNShortId = "NF:dbghelp.SymSetOptions")]
		public static extern SYMOPT SymSetOptions(SYMOPT SymOptions);

		/// <summary>
		/// A managed life-cycle symbol handler for a process which calls <see cref="SymInitialize"/> at construction and
		/// <see cref="SymCleanup"/> at disposal.
		/// </summary>
		public class ProcessSymbolHandler : IDisposable
		{
			private HPROCESS hProc;

			/// <summary>Initializes the symbol handler for a process.</summary>
			/// <param name="hProcess">
			/// <para>
			/// A handle that identifies the caller. This value should be unique and nonzero, but need not be a process handle. However, if
			/// you do use a process handle, be sure to use the correct handle. If the application is a debugger, use the process handle for
			/// the process being debugged. Do not use the handle returned by GetCurrentProcess when debugging another process, because
			/// calling functions like SymLoadModuleEx can have unexpected results.
			/// </para>
			/// <para>This parameter cannot be <see cref="HPROCESS.NULL"/>.</para>
			/// </param>
			/// <param name="UserSearchPath">
			/// <para>
			/// The path, or series of paths separated by a semicolon (;), that is used to search for symbol files. If this parameter is
			/// <see langword="null"/>, the library attempts to form a symbol path from the following sources:
			/// </para>
			/// <list type="bullet">
			/// <item>
			/// <term>The current working directory of the application</term>
			/// </item>
			/// <item>
			/// <term>The _NT_SYMBOL_PATH environment variable</term>
			/// </item>
			/// <item>
			/// <term>The _NT_ALTERNATE_SYMBOL_PATH environment variable</term>
			/// </item>
			/// </list>
			/// <para>Note that the search path can also be set using the <see cref="SymSetSearchPath"/> function.</para>
			/// </param>
			/// <param name="fInvadeProcess">
			/// If this value is <see langword="true"/>, enumerates the loaded modules for the process and effectively calls the
			/// SymLoadModule64 function for each module.
			/// </param>
			public ProcessSymbolHandler(HPROCESS hProcess, string UserSearchPath = null, bool fInvadeProcess = true) =>
				SymInitialize(hProc = hProcess, UserSearchPath, fInvadeProcess);

			public static implicit operator HPROCESS(ProcessSymbolHandler h) => h.hProc;

			/// <summary>Deallocates all resources associated with this process handle.</summary>
			public void Clean() => SymCleanup(hProc);

			/// <summary>Deallocates all resources associated with this process handle.</summary>
			public void Dispose() => Clean();

			/// <summary>Refreshes the module list for the process.</summary>
			public void RefreshModuleList() => SymRefreshModuleList(hProc);
		}

		/*
		SymFindFileInPathProc
SymFromAddr
SymFromIndex
SymFromInlineContext
SymFromName
SymFromToken
SymFunctionTableAccess64
SymFunctionTableAccess64AccessRoutines
SymGetExtendedOption
SymGetFileLineOffsets64
SymGetHomeDirectory
SymGetLineFromAddr64
SymGetLineFromInlineContext
SymGetLineFromName64
SymGetLineNext64
SymGetLinePrev64
SymGetModuleBase64
SymGetModuleInfo64
SymGetOmaps
SymGetOptions
SymGetScope
SymGetSearchPath
SymGetSourceFile
SymGetSourceFileChecksum
SymGetSourceFileFromToken
SymGetSourceFileToken
SymGetSourceVarFromToken
SymGetSymbolFile
SymGetSymFromAddr64
SymGetSymFromName64
SymGetSymNext64
SymGetSymPrev64
SymGetTypeFromName
SymGetTypeInfo
SymGetTypeInfoEx
SymLoadModule64
SymLoadModuleEx
SymMatchFileName
SymMatchString
SymNext
SymPrev
SymQueryInlineTrace
SymRefreshModuleList
SymRegisterCallback64
SymRegisterCallbackProc64
SymRegisterFunctionEntryCallback64
SymRegisterFunctionEntryCallbackProc64
SymSearch
SymSetContext
SymSetExtendedOption
SymSetHomeDirectory
SymSetParentWindow
SymSetScopeFromAddr
SymSetScopeFromIndex
SymSetScopeFromInlineContext
SymSetSearchPath
SymSrvDeltaName
SymSrvGetFileIndexes
SymSrvGetFileIndexInfo
SymSrvGetFileIndexString
SymSrvGetSupplement
SymSrvIsStore
SymSrvStoreFile
SymSrvStoreSupplement
SymUnDName64
SymUnloadModule64
		*/
	}
}