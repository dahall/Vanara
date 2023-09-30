using System.Collections.Generic;

namespace Vanara.PInvoke;

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
	public delegate bool PSYM_ENUMERATESYMBOLS_CALLBACK([In] IntPtr pSymInfo, uint SymbolSize, [In, Optional] IntPtr UserContext);

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

	/// <summary>
	/// <para>
	/// An application-defined callback function used with the SymRegisterFunctionEntryCallback64 function. It is called by the stack
	/// walking procedure.
	/// </para>
	/// <para>
	/// The <c>PSYMBOL_FUNCENTRY_CALLBACK64</c> type defines a pointer to this callback function.
	/// <c>SymRegisterFunctionEntryCallbackProc64</c> is a placeholder for the application-defined function name.
	/// </para>
	/// </summary>
	/// <param name="hProcess">A handle to the process that was originally passed to the StackWalk64 function.</param>
	/// <param name="AddrBase">The address of an instruction for which the callback function should return a function table entry.</param>
	/// <param name="UserContext">
	/// The user-defined value specified in SymRegisterFunctionEntryCallback64, or <c>NULL</c>. Typically, this parameter is used by an
	/// application to pass a pointer to a data structure that lets the callback function establish some context.
	/// </param>
	/// <returns>
	/// <para>Return the value <c>NULL</c> if no function table entry is available.</para>
	/// <para>
	/// On success, return a pointer to an <c>IMAGE_RUNTIME_FUNCTION_ENTRY</c> structure. Refer to the header file WinNT.h for the
	/// definition of this function.
	/// </para>
	/// </returns>
	/// <remarks>
	/// <para>
	/// The structure must be returned in exactly the form it exists in the process being debugged. Some members may be pointers to
	/// other locations in the process address space. The ReadProcessMemoryProc64 callback function may be called to retrieve the
	/// information at these locations.
	/// </para>
	/// <para>
	/// The calling application gets called through the registered callback function as a result of a call to the StackWalk64 function.
	/// The calling application must be prepared for the possible side effects that this can cause. If the application has only one
	/// callback function that is being used by multiple threads, then it may be necessary to synchronize some types of data access
	/// while in the context of the callback function.
	/// </para>
	/// <para>
	/// This function is similar to the FunctionTableAccessProc64 callback function. The difference is that
	/// <c>FunctionTableAccessProc64</c> returns an IMAGE_FUNCTION_ENTRY structure, while this function returns an
	/// <c>IMAGE_RUNTIME_FUNCTION_ENTRY</c> structure.
	/// </para>
	/// <para>
	/// This callback function supersedes the PSYMBOL_FUNCENTRY_CALLBACK callback function. PSYMBOL_FUNCENTRY_CALLBACK is defined as
	/// follows in Dbghelp.h.
	/// </para>
	/// <para>
	/// <code>#if !defined(_IMAGEHLP_SOURCE_) &amp;&amp; defined(_IMAGEHLP64) #define PSYMBOL_FUNCENTRY_CALLBACK PSYMBOL_FUNCENTRY_CALLBACK64 #endif typedef PVOID (CALLBACK *PSYMBOL_FUNCENTRY_CALLBACK)( __in HANDLE hProcess, __in DWORD AddrBase, __in_opt PVOID UserContext );</code>
	/// </para>
	/// </remarks>
	// https://docs.microsoft.com/en-us/windows/win32/api/dbghelp/nc-dbghelp-psymbol_funcentry_callback PSYMBOL_FUNCENTRY_CALLBACK
	// PsymbolFuncentryCallback; PVOID PsymbolFuncentryCallback( HANDLE hProcess, DWORD AddrBase, PVOID UserContext ) {...}
	[UnmanagedFunctionPointer(CallingConvention.Winapi)]
	[PInvokeData("dbghelp.h", MSDNShortId = "NC:dbghelp.PSYMBOL_FUNCENTRY_CALLBACK")]
	public delegate IntPtr PSYMBOL_FUNCENTRY_CALLBACK(HPROCESS hProcess, uint AddrBase, IntPtr UserContext);

	/// <summary>
	/// <para>
	/// An application-defined callback function used with the SymRegisterFunctionEntryCallback64 function. It is called by the stack
	/// walking procedure.
	/// </para>
	/// <para>
	/// The <c>PSYMBOL_FUNCENTRY_CALLBACK64</c> type defines a pointer to this callback function.
	/// <c>SymRegisterFunctionEntryCallbackProc64</c> is a placeholder for the application-defined function name.
	/// </para>
	/// </summary>
	/// <param name="hProcess">A handle to the process that was originally passed to the StackWalk64 function.</param>
	/// <param name="AddrBase">The address of an instruction for which the callback function should return a function table entry.</param>
	/// <param name="UserContext">
	/// The user-defined value specified in SymRegisterFunctionEntryCallback64, or <c>NULL</c>. Typically, this parameter is used by an
	/// application to pass a pointer to a data structure that lets the callback function establish some context.
	/// </param>
	/// <returns>
	/// <para>Return the value <c>NULL</c> if no function table entry is available.</para>
	/// <para>
	/// On success, return a pointer to an <c>IMAGE_RUNTIME_FUNCTION_ENTRY</c> structure. Refer to the header file WinNT.h for the
	/// definition of this function.
	/// </para>
	/// </returns>
	/// <remarks>
	/// <para>
	/// The structure must be returned in exactly the form it exists in the process being debugged. Some members may be pointers to
	/// other locations in the process address space. The ReadProcessMemoryProc64 callback function may be called to retrieve the
	/// information at these locations.
	/// </para>
	/// <para>
	/// The calling application gets called through the registered callback function as a result of a call to the StackWalk64 function.
	/// The calling application must be prepared for the possible side effects that this can cause. If the application has only one
	/// callback function that is being used by multiple threads, then it may be necessary to synchronize some types of data access
	/// while in the context of the callback function.
	/// </para>
	/// <para>
	/// This function is similar to the FunctionTableAccessProc64 callback function. The difference is that
	/// <c>FunctionTableAccessProc64</c> returns an IMAGE_FUNCTION_ENTRY structure, while this function returns an
	/// <c>IMAGE_RUNTIME_FUNCTION_ENTRY</c> structure.
	/// </para>
	/// <para>
	/// This callback function supersedes the PSYMBOL_FUNCENTRY_CALLBACK callback function. PSYMBOL_FUNCENTRY_CALLBACK is defined as
	/// follows in Dbghelp.h.
	/// </para>
	/// <para>
	/// <code>#if !defined(_IMAGEHLP_SOURCE_) &amp;&amp; defined(_IMAGEHLP64) #define PSYMBOL_FUNCENTRY_CALLBACK PSYMBOL_FUNCENTRY_CALLBACK64 #endif typedef PVOID (CALLBACK *PSYMBOL_FUNCENTRY_CALLBACK)( __in HANDLE hProcess, __in DWORD AddrBase, __in_opt PVOID UserContext );</code>
	/// </para>
	/// </remarks>
	// https://docs.microsoft.com/en-us/windows/win32/api/dbghelp/nc-dbghelp-psymbol_funcentry_callback64 PSYMBOL_FUNCENTRY_CALLBACK64
	// PsymbolFuncentryCallback64; PVOID PsymbolFuncentryCallback64( HANDLE hProcess, ULONG64 AddrBase, ULONG64 UserContext ) {...}
	[UnmanagedFunctionPointer(CallingConvention.Winapi)]
	[PInvokeData("dbghelp.h", MSDNShortId = "NC:dbghelp.PSYMBOL_FUNCENTRY_CALLBACK64")]
	public delegate IntPtr PSYMBOL_FUNCENTRY_CALLBACK64(HPROCESS hProcess, ulong AddrBase, [Optional] ulong UserContext);

	/// <summary>
	/// <para>An application-defined callback function used with the SymRegisterCallback64 function. It is called by the symbol handler.</para>
	/// <para>
	/// The <c>PSYMBOL_REGISTERED_CALLBACK64</c> type defines a pointer to this callback function. <c>SymRegisterCallbackProc64</c> is a
	/// placeholder for the application-defined function name.
	/// </para>
	/// </summary>
	/// <param name="hProcess">A handle to the process that was originally passed to the SymInitialize function.</param>
	/// <param name="ActionCode">
	/// <para>The callback code. This parameter can be one of the following values.</para>
	/// <list type="table">
	/// <listheader>
	/// <term>Value</term>
	/// <term>Meaning</term>
	/// </listheader>
	/// <item>
	/// <term>CBA_DEBUG_INFO 0x10000000</term>
	/// <term>Display verbose information. The CallbackData parameter is a pointer to a string.</term>
	/// </item>
	/// <item>
	/// <term>CBA_DEFERRED_SYMBOL_LOAD_CANCEL 0x00000007</term>
	/// <term>
	/// Deferred symbol loading has started. To cancel the symbol load, return TRUE. The CallbackData parameter is a pointer to a
	/// IMAGEHLP_DEFERRED_SYMBOL_LOAD64 structure.
	/// </term>
	/// </item>
	/// <item>
	/// <term>CBA_DEFERRED_SYMBOL_LOAD_COMPLETE 0x00000002</term>
	/// <term>Deferred symbol load has completed. The CallbackData parameter is a pointer to a IMAGEHLP_DEFERRED_SYMBOL_LOAD64 structure.</term>
	/// </item>
	/// <item>
	/// <term>CBA_DEFERRED_SYMBOL_LOAD_FAILURE 0x00000003</term>
	/// <term>
	/// Deferred symbol load has failed. The CallbackData parameter is a pointer to a IMAGEHLP_DEFERRED_SYMBOL_LOAD64 structure. The
	/// symbol handler will attempt to load the symbols again if the callback function sets the FileName member of this structure.
	/// </term>
	/// </item>
	/// <item>
	/// <term>CBA_DEFERRED_SYMBOL_LOAD_PARTIAL 0x00000020</term>
	/// <term>
	/// Deferred symbol load has partially completed. The symbol loader is unable to read the image header from either the image file or
	/// the specified module. The CallbackData parameter is a pointer to a IMAGEHLP_DEFERRED_SYMBOL_LOAD64 structure. The symbol handler
	/// will attempt to load the symbols again if the callback function sets the FileName member of this structure. DbgHelp 5.1: This
	/// value is not supported.
	/// </term>
	/// </item>
	/// <item>
	/// <term>CBA_DEFERRED_SYMBOL_LOAD_START 0x00000001</term>
	/// <term>Deferred symbol load has started. The CallbackData parameter is a pointer to a IMAGEHLP_DEFERRED_SYMBOL_LOAD64 structure.</term>
	/// </item>
	/// <item>
	/// <term>CBA_DUPLICATE_SYMBOL 0x00000005</term>
	/// <term>
	/// Duplicate symbols were found. This reason is used only in COFF or CodeView format. The CallbackData parameter is a pointer to a
	/// IMAGEHLP_DUPLICATE_SYMBOL64 structure. To specify which symbol to use, set the SelectedSymbol member of this structure.
	/// </term>
	/// </item>
	/// <item>
	/// <term>CBA_EVENT 0x00000010</term>
	/// <term>
	/// Display verbose information. If you do not handle this event, the information is resent through the CBA_DEBUG_INFO event. The
	/// CallbackData parameter is a pointer to a IMAGEHLP_CBA_EVENT structure.
	/// </term>
	/// </item>
	/// <item>
	/// <term>CBA_READ_MEMORY 0x00000006</term>
	/// <term>
	/// The loaded image has been read. The CallbackData parameter is a pointer to a IMAGEHLP_CBA_READ_MEMORY structure. The callback
	/// function should read the number of bytes specified by the bytes member into the buffer specified by the buf member, and update
	/// the bytesread member accordingly.
	/// </term>
	/// </item>
	/// <item>
	/// <term>CBA_SET_OPTIONS 0x00000008</term>
	/// <term>
	/// Symbol options have been updated. To retrieve the current options, call the SymGetOptions function. The CallbackData parameter
	/// should be ignored.
	/// </term>
	/// </item>
	/// <item>
	/// <term>CBA_SRCSRV_EVENT 0x40000000</term>
	/// <term>
	/// Display verbose information for source server. If you do not handle this event, the information is resent through the
	/// CBA_DEBUG_INFO event. The CallbackData parameter is a pointer to a IMAGEHLP_CBA_EVENT structure. DbgHelp 6.6 and earlier: This
	/// value is not supported.
	/// </term>
	/// </item>
	/// <item>
	/// <term>CBA_SRCSRV_INFO 0x20000000</term>
	/// <term>
	/// Display verbose information for source server. The CallbackData parameter is a pointer to a string. DbgHelp 6.6 and earlier:
	/// This value is not supported.
	/// </term>
	/// </item>
	/// <item>
	/// <term>CBA_SYMBOLS_UNLOADED 0x00000004</term>
	/// <term>Symbols have been unloaded. The CallbackData parameter should be ignored.</term>
	/// </item>
	/// </list>
	/// </param>
	/// <param name="CallbackData">
	/// <para>Data for the operation. The format of this data depends on the value of the ActionCode parameter.</para>
	/// <para>
	/// If the callback function was registered with SymRegisterCallbackW64, the data is a Unicode string or data structure. Otherwise,
	/// the data uses ANSI format.
	/// </para>
	/// </param>
	/// <param name="UserContext">
	/// User-defined value specified in SymRegisterCallback64, or <c>NULL</c>. Typically, this parameter is used by an application to
	/// pass a pointer to a data structure that lets the callback function establish some context.
	/// </param>
	/// <returns>
	/// <para>To indicate success handling the code, return <c>TRUE</c>.</para>
	/// <para>
	/// To indicate failure handling the code, return <c>FALSE</c>. If your code does not handle a particular code, you should also
	/// return <c>FALSE</c>. (Returning <c>TRUE</c> in this case may have unintended consequences.)
	/// </para>
	/// </returns>
	/// <remarks>
	/// <para>
	/// The calling application gets called through the registered callback function as a result of another call to one of the symbol
	/// handler functions. The calling application must be prepared for the possible side effects that this can cause. If the
	/// application has only one callback function that is being used by multiple threads, then care may be necessary to synchronize
	/// some types of data access while in the context of the callback function.
	/// </para>
	/// <para>
	/// This callback function supersedes the PSYMBOL_REGISTERED_CALLBACK callback function. PSYMBOL_REGISTERED_CALLBACK is defined as
	/// follows in Dbghelp.h.
	/// </para>
	/// <para>
	/// <code>#if !defined(_IMAGEHLP_SOURCE_) &amp;&amp; defined(_IMAGEHLP64) #define PSYMBOL_REGISTERED_CALLBACK PSYMBOL_REGISTERED_CALLBACK64 #else typedef BOOL (CALLBACK *PSYMBOL_REGISTERED_CALLBACK)( __in HANDLE hProcess, __in ULONG ActionCode, __in_opt PVOID CallbackData, __in_opt PVOID UserContext ); #endif</code>
	/// </para>
	/// <para>For a more extensive example, read Getting Notifications.</para>
	/// </remarks>
	// https://docs.microsoft.com/en-us/windows/win32/api/dbghelp/nc-dbghelp-psymbol_registered_callback PSYMBOL_REGISTERED_CALLBACK
	// PsymbolRegisteredCallback; BOOL PsymbolRegisteredCallback( HANDLE hProcess, ULONG ActionCode, PVOID CallbackData, PVOID
	// UserContext ) {...}
	[UnmanagedFunctionPointer(CallingConvention.Winapi)]
	[PInvokeData("dbghelp.h", MSDNShortId = "NC:dbghelp.PSYMBOL_REGISTERED_CALLBACK")]
	[return: MarshalAs(UnmanagedType.Bool)]
	public delegate bool PSYMBOL_REGISTERED_CALLBACK(HPROCESS hProcess, CBA ActionCode, [Optional] IntPtr CallbackData, [Optional] IntPtr UserContext);

	/// <summary>
	/// <para>An application-defined callback function used with the SymRegisterCallback64 function. It is called by the symbol handler.</para>
	/// <para>
	/// The <c>PSYMBOL_REGISTERED_CALLBACK64</c> type defines a pointer to this callback function. <c>SymRegisterCallbackProc64</c> is a
	/// placeholder for the application-defined function name.
	/// </para>
	/// </summary>
	/// <param name="hProcess">A handle to the process that was originally passed to the SymInitialize function.</param>
	/// <param name="ActionCode">
	/// <para>The callback code. This parameter can be one of the following values.</para>
	/// <list type="table">
	/// <listheader>
	/// <term>Value</term>
	/// <term>Meaning</term>
	/// </listheader>
	/// <item>
	/// <term>CBA_DEBUG_INFO 0x10000000</term>
	/// <term>Display verbose information. The CallbackData parameter is a pointer to a string.</term>
	/// </item>
	/// <item>
	/// <term>CBA_DEFERRED_SYMBOL_LOAD_CANCEL 0x00000007</term>
	/// <term>
	/// Deferred symbol loading has started. To cancel the symbol load, return TRUE. The CallbackData parameter is a pointer to a
	/// IMAGEHLP_DEFERRED_SYMBOL_LOAD64 structure.
	/// </term>
	/// </item>
	/// <item>
	/// <term>CBA_DEFERRED_SYMBOL_LOAD_COMPLETE 0x00000002</term>
	/// <term>Deferred symbol load has completed. The CallbackData parameter is a pointer to a IMAGEHLP_DEFERRED_SYMBOL_LOAD64 structure.</term>
	/// </item>
	/// <item>
	/// <term>CBA_DEFERRED_SYMBOL_LOAD_FAILURE 0x00000003</term>
	/// <term>
	/// Deferred symbol load has failed. The CallbackData parameter is a pointer to a IMAGEHLP_DEFERRED_SYMBOL_LOAD64 structure. The
	/// symbol handler will attempt to load the symbols again if the callback function sets the FileName member of this structure.
	/// </term>
	/// </item>
	/// <item>
	/// <term>CBA_DEFERRED_SYMBOL_LOAD_PARTIAL 0x00000020</term>
	/// <term>
	/// Deferred symbol load has partially completed. The symbol loader is unable to read the image header from either the image file or
	/// the specified module. The CallbackData parameter is a pointer to a IMAGEHLP_DEFERRED_SYMBOL_LOAD64 structure. The symbol handler
	/// will attempt to load the symbols again if the callback function sets the FileName member of this structure. DbgHelp 5.1: This
	/// value is not supported.
	/// </term>
	/// </item>
	/// <item>
	/// <term>CBA_DEFERRED_SYMBOL_LOAD_START 0x00000001</term>
	/// <term>Deferred symbol load has started. The CallbackData parameter is a pointer to a IMAGEHLP_DEFERRED_SYMBOL_LOAD64 structure.</term>
	/// </item>
	/// <item>
	/// <term>CBA_DUPLICATE_SYMBOL 0x00000005</term>
	/// <term>
	/// Duplicate symbols were found. This reason is used only in COFF or CodeView format. The CallbackData parameter is a pointer to a
	/// IMAGEHLP_DUPLICATE_SYMBOL64 structure. To specify which symbol to use, set the SelectedSymbol member of this structure.
	/// </term>
	/// </item>
	/// <item>
	/// <term>CBA_EVENT 0x00000010</term>
	/// <term>
	/// Display verbose information. If you do not handle this event, the information is resent through the CBA_DEBUG_INFO event. The
	/// CallbackData parameter is a pointer to a IMAGEHLP_CBA_EVENT structure.
	/// </term>
	/// </item>
	/// <item>
	/// <term>CBA_READ_MEMORY 0x00000006</term>
	/// <term>
	/// The loaded image has been read. The CallbackData parameter is a pointer to a IMAGEHLP_CBA_READ_MEMORY structure. The callback
	/// function should read the number of bytes specified by the bytes member into the buffer specified by the buf member, and update
	/// the bytesread member accordingly.
	/// </term>
	/// </item>
	/// <item>
	/// <term>CBA_SET_OPTIONS 0x00000008</term>
	/// <term>
	/// Symbol options have been updated. To retrieve the current options, call the SymGetOptions function. The CallbackData parameter
	/// should be ignored.
	/// </term>
	/// </item>
	/// <item>
	/// <term>CBA_SRCSRV_EVENT 0x40000000</term>
	/// <term>
	/// Display verbose information for source server. If you do not handle this event, the information is resent through the
	/// CBA_DEBUG_INFO event. The CallbackData parameter is a pointer to a IMAGEHLP_CBA_EVENT structure. DbgHelp 6.6 and earlier: This
	/// value is not supported.
	/// </term>
	/// </item>
	/// <item>
	/// <term>CBA_SRCSRV_INFO 0x20000000</term>
	/// <term>
	/// Display verbose information for source server. The CallbackData parameter is a pointer to a string. DbgHelp 6.6 and earlier:
	/// This value is not supported.
	/// </term>
	/// </item>
	/// <item>
	/// <term>CBA_SYMBOLS_UNLOADED 0x00000004</term>
	/// <term>Symbols have been unloaded. The CallbackData parameter should be ignored.</term>
	/// </item>
	/// </list>
	/// </param>
	/// <param name="CallbackData">
	/// <para>Data for the operation. The format of this data depends on the value of the ActionCode parameter.</para>
	/// <para>
	/// If the callback function was registered with SymRegisterCallbackW64, the data is a Unicode string or data structure. Otherwise,
	/// the data uses ANSI format.
	/// </para>
	/// </param>
	/// <param name="UserContext">
	/// User-defined value specified in SymRegisterCallback64, or <c>NULL</c>. Typically, this parameter is used by an application to
	/// pass a pointer to a data structure that lets the callback function establish some context.
	/// </param>
	/// <returns>
	/// <para>To indicate success handling the code, return <c>TRUE</c>.</para>
	/// <para>
	/// To indicate failure handling the code, return <c>FALSE</c>. If your code does not handle a particular code, you should also
	/// return <c>FALSE</c>. (Returning <c>TRUE</c> in this case may have unintended consequences.)
	/// </para>
	/// </returns>
	/// <remarks>
	/// <para>
	/// The calling application gets called through the registered callback function as a result of another call to one of the symbol
	/// handler functions. The calling application must be prepared for the possible side effects that this can cause. If the
	/// application has only one callback function that is being used by multiple threads, then care may be necessary to synchronize
	/// some types of data access while in the context of the callback function.
	/// </para>
	/// <para>
	/// This callback function supersedes the PSYMBOL_REGISTERED_CALLBACK callback function. PSYMBOL_REGISTERED_CALLBACK is defined as
	/// follows in Dbghelp.h.
	/// </para>
	/// <para>
	/// <code>#if !defined(_IMAGEHLP_SOURCE_) &amp;&amp; defined(_IMAGEHLP64) #define PSYMBOL_REGISTERED_CALLBACK PSYMBOL_REGISTERED_CALLBACK64 #else typedef BOOL (CALLBACK *PSYMBOL_REGISTERED_CALLBACK)( __in HANDLE hProcess, __in ULONG ActionCode, __in_opt PVOID CallbackData, __in_opt PVOID UserContext ); #endif</code>
	/// </para>
	/// <para>For a more extensive example, read Getting Notifications.</para>
	/// </remarks>
	// https://docs.microsoft.com/en-us/windows/win32/api/dbghelp/nc-dbghelp-psymbol_registered_callback64 PSYMBOL_REGISTERED_CALLBACK64
	// PsymbolRegisteredCallback64; BOOL PsymbolRegisteredCallback64( HANDLE hProcess, ULONG ActionCode, ULONG64 CallbackData, ULONG64
	// UserContext ) {...}
	[UnmanagedFunctionPointer(CallingConvention.Winapi)]
	[PInvokeData("dbghelp.h", MSDNShortId = "NC:dbghelp.PSYMBOL_REGISTERED_CALLBACK64")]
	[return: MarshalAs(UnmanagedType.Bool)]
	public delegate bool PSYMBOL_REGISTERED_CALLBACK64(HPROCESS hProcess, CBA ActionCode, [Optional] ulong CallbackData, [Optional] ulong UserContext);

	/// <summary>Callback code for PSYMBOL_REGISTERED_CALLBACK.</summary>
	[PInvokeData("dbghelp.h", MSDNShortId = "NC:dbghelp.PSYMBOL_REGISTERED_CALLBACK64")]
	[Flags]
	public enum CBA : uint
	{
		/// <summary/>
		CBA_CHECK_ARM_MACHINE_THUMB_TYPE_OVERRIDE = 0x80000000,

		/// <summary/>
		CBA_CHECK_ENGOPT_DISALLOW_NETWORK_PATHS = 0x70000000,

		/// <summary/>
		CBA_ENGINE_PRESENT = 0x60000000,

		/// <summary/>
		CBA_UPDATE_STATUS_BAR = 0x50000000,

		/// <summary/>
		CBA_XML_LOG = 0x90000000,

		/// <summary>
		/// Display verbose information.
		/// <para>The CallbackData parameter is a pointer to a string.</para>
		/// </summary>
		CBA_DEBUG_INFO = 0x10000000,

		/// <summary>
		/// Deferred symbol loading has started. To cancel the symbol load, return TRUE.
		/// <para>The CallbackData parameter is a pointer to a IMAGEHLP_DEFERRED_SYMBOL_LOAD64 structure.</para>
		/// </summary>
		CBA_DEFERRED_SYMBOL_LOAD_CANCEL = 0x00000007,

		/// <summary>
		/// Deferred symbol load has completed.
		/// <para>The CallbackData parameter is a pointer to a IMAGEHLP_DEFERRED_SYMBOL_LOAD64 structure.</para>
		/// </summary>
		CBA_DEFERRED_SYMBOL_LOAD_COMPLETE = 0x00000002,

		/// <summary>
		/// Deferred symbol load has failed.
		/// <para>
		/// The CallbackData parameter is a pointer to a IMAGEHLP_DEFERRED_SYMBOL_LOAD64 structure. The symbol handler will attempt to
		/// load the symbols again if the callback function sets the FileName member of this structure.
		/// </para>
		/// </summary>
		CBA_DEFERRED_SYMBOL_LOAD_FAILURE = 0x00000003,

		/// <summary>
		/// Deferred symbol load has partially completed. The symbol loader is unable to read the image header from either the image
		/// file or the specified module.
		/// <para>
		/// The CallbackData parameter is a pointer to a IMAGEHLP_DEFERRED_SYMBOL_LOAD64 structure. The symbol handler will attempt to
		/// load the symbols again if the callback function sets the FileName member of this structure.
		/// </para>
		/// <para>DbgHelp 5.1: This value is not supported.</para>
		/// </summary>
		CBA_DEFERRED_SYMBOL_LOAD_PARTIAL = 0x00000020,

		/// <summary>
		/// Deferred symbol load has started.
		/// <para>The CallbackData parameter is a pointer to a IMAGEHLP_DEFERRED_SYMBOL_LOAD64 structure.</para>
		/// </summary>
		CBA_DEFERRED_SYMBOL_LOAD_START = 0x00000001,

		/// <summary>
		/// Duplicate symbols were found. This reason is used only in COFF or CodeView format.
		/// <para>
		/// The CallbackData parameter is a pointer to a IMAGEHLP_DUPLICATE_SYMBOL64 structure. To specify which symbol to use, set the
		/// SelectedSymbol member of this structure.
		/// </para>
		/// </summary>
		CBA_DUPLICATE_SYMBOL = 0x00000005,

		/// <summary>
		/// Display verbose information. If you do not handle this event, the information is resent through the CBA_DEBUG_INFO event.
		/// <para>The CallbackData parameter is a pointer to a IMAGEHLP_CBA_EVENT structure.</para>
		/// </summary>
		CBA_EVENT = 0x00000010,

		/// <summary>
		/// The loaded image has been read.
		/// <para>
		/// The CallbackData parameter is a pointer to a IMAGEHLP_CBA_READ_MEMORY structure. The callback function should read the
		/// number of bytes specified by the bytes member into the buffer specified by the buf member, and update the bytesread member accordingly.
		/// </para>
		/// </summary>
		CBA_READ_MEMORY = 0x00000006,

		/// <summary>
		/// Symbol options have been updated. To retrieve the current options, call the SymGetOptions function.
		/// <para>The CallbackData parameter should be ignored.</para>
		/// </summary>
		CBA_SET_OPTIONS = 0x00000008,

		/// <summary>
		/// Display verbose information for source server. If you do not handle this event, the information is resent through the
		/// CBA_DEBUG_INFO event.
		/// <para>The CallbackData parameter is a pointer to a IMAGEHLP_CBA_EVENT structure.</para>
		/// <para>DbgHelp 6.6 and earlier: This value is not supported.</para>
		/// </summary>
		CBA_SRCSRV_EVENT = 0x40000000,

		/// <summary>
		/// Display verbose information for source server.
		/// <para>The CallbackData parameter is a pointer to a string.</para>
		/// <para>DbgHelp 6.6 and earlier: This value is not supported.</para>
		/// </summary>
		CBA_SRCSRV_INFO = 0x20000000,

		/// <summary>
		/// Symbols have been unloaded.
		/// <para>The CallbackData parameter should be ignored.</para>
		/// </summary>
		CBA_SYMBOLS_UNLOADED = 0x00000004,
	}

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

	/// <summary>The directory to be retrieved.</summary>
	[PInvokeData("dbghelp.h", MSDNShortId = "NF:dbghelp.SymGetHomeDirectory")]
	public enum IMAGEHLP_HD_TYPE
	{
		/// <summary>The home directory.</summary>
		hdBase = 0,

		/// <summary>The symbol directory.</summary>
		hdSym,

		/// <summary>The source directory.</summary>
		hdSrc,
	}

	/// <summary>The type of symbol file.</summary>
	[PInvokeData("dbghelp.h", MSDNShortId = "NF:dbghelp.SymGetSymbolFile")]
	public enum IMAGEHLP_SF_TYPE
	{
		/// <summary>A .exe or .dll file.</summary>
		sfImage = 0,

		/// <summary>A .dbg file.</summary>
		sfDbg,

		/// <summary>A .pdb file.</summary>
		sfPdb,

		/// <summary>Reserved.</summary>
		sfMpd,
	}

	/// <summary>Flags for <see cref="SymLoadModuleEx(HPROCESS, HFILE, string, string, ulong, uint, in MODLOAD_DATA, SLMFLAG)"/>.</summary>
	[Flags]
	public enum SLMFLAG
	{
		/// <summary>
		/// Creates a virtual module named ModuleName at the address specified in BaseOfDll. To add symbols to this module, call the
		/// SymAddSymbol function.
		/// </summary>
		SLMFLAG_VIRTUAL = 0x1,

		/// <summary/>
		SLMFLAG_ALT_INDEX = 0x2,

		/// <summary>Loads the module but not the symbols for the module.</summary>
		SLMFLAG_NO_SYMBOLS = 0x4
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

	/// <summary>The options that control the behavior of <see cref="SymSearch"/>.</summary>
	[PInvokeData("dbghelp.h", MSDNShortId = "NF:dbghelp.SymSearch")]
	[Flags]
	public enum SYMSEARCH
	{
		/// <summary>Include all symbols and other data in the .pdb files. DbgHelp 6.6 and earlier: This value is not supported.</summary>
		SYMSEARCH_ALLITEMS = 0X08,

		/// <summary>Search only for global symbols.</summary>
		SYMSEARCH_GLOBALSONLY = 0X04,

		/// <summary>For internal use only.</summary>
		SYMSEARCH_MASKOBJS = 0x01,

		/// <summary>Recurse from the top to find all symbols.</summary>
		SYMSEARCH_RECURSE = 0X02,
	}

	/// <summary>The flags that control <see cref="SymSrvStoreFile"/>.</summary>
	[PInvokeData("dbghelp.h", MSDNShortId = "NF:dbghelp.SymSrvStoreFile")]
	[Flags]
	public enum SYMSTOREOPT
	{
		/// <summary/>
		SYMSTOREOPT_ALT_INDEX = 0x10,

		/// <summary>Compress the file.</summary>
		SYMSTOREOPT_COMPRESS = 0x01,

		/// <summary>Overwrite the file if it exists.</summary>
		SYMSTOREOPT_OVERWRITE = 0x02,

		/// <summary>Do not report an error if the file already exists in the symbol store.</summary>
		SYMSTOREOPT_PASS_IF_EXISTS = 0x40,

		/// <summary>Store in File.ptr.</summary>
		SYMSTOREOPT_POINTER = 0x08,

		/// <summary>Return the index only.</summary>
		SYMSTOREOPT_RETURNINDEX = 0x04,

		/// <summary/>
		SYMSTOREOPT_UNICODE = 0x20,
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
	public static extern bool SymAddSourceStream(HPROCESS hProcess, ulong Base, [Optional, MarshalAs(UnmanagedType.LPTStr)] string? StreamFile, [In, Optional] IntPtr Buffer, SizeT Size);

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
	/// <param name="force32bit">If set to <see langword="true"/>, force loading a 32-bit module, even on 64-bit systems.</param>
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
	public static IList<(string ModuleName, IntPtr BaseOfDll)> SymEnumerateModules(HPROCESS hProcess, bool force32bit = false)
	{
		var ret = new List<(string, IntPtr)>();
		bool success;
		if (!LibHelper.Is64BitProcess || force32bit)
			success = SymEnumerateModules(hProcess, Callback);
		else
			success = SymEnumerateModulesW64(hProcess, Callback64);
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
	public static extern bool SymEnumLines(HPROCESS hProcess, ulong Base, [Optional, MarshalAs(UnmanagedType.LPTStr)] string? Obj, [Optional, MarshalAs(UnmanagedType.LPTStr)] string? File,
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
	public static IList<(string Obj, string FileName, uint LineNumber, ulong Address)> SymEnumLines(HPROCESS hProcess, ulong Base, string? Obj = null, string? File = null)
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
	public static extern bool SymEnumSourceFiles(HPROCESS hProcess, ulong ModBase, [Optional, MarshalAs(UnmanagedType.LPTStr)] string? Mask,
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
	public static extern bool SymEnumSourceLines(HPROCESS hProcess, ulong Base, [Optional, MarshalAs(UnmanagedType.LPTStr)] string? Obj,
		[Optional, MarshalAs(UnmanagedType.LPTStr)] string? File, [Optional] uint Line, ESLFLAG Flags, PSYM_ENUMLINES_CALLBACK EnumLinesCallback,
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
	public static extern bool SymEnumSymbols(HPROCESS hProcess, [Optional] ulong BaseOfDll, [Optional, MarshalAs(UnmanagedType.LPTStr)] string? Mask,
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
	/// SymEnumSymbols will look for a local symbol named "foo" within the scope established by the most recent call to the SymSetContext function.
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
	/// <param name="UserContext">
	/// A user-defined value that is passed to the callback function, or <c>NULL</c>. This parameter is typically used by an application
	/// to pass a pointer to a data structure that provides context for the callback function.
	/// </param>
	/// <returns>A list of <see cref="SYMBOL_INFO"/> structures.</returns>
	/// <remarks>
	/// <para>
	/// All DbgHelp functions, such as this one, are single threaded. Therefore, calls from more than one thread to this function will
	/// likely result in unexpected behavior or memory corruption. To avoid this, you must synchronize all concurrent calls from more
	/// than one thread to this function.
	/// </para>
	/// <para>Examples</para>
	/// <para>For an example, see Enumerating Symbols.</para>
	/// </remarks>
	public static IList<SYMBOL_INFO> SymEnumSymbolsEx(HPROCESS hProcess, [Optional] ulong BaseOfDll, [Optional] string? Mask,
		SYMENUM Options = SYMENUM.SYMENUM_OPTIONS_DEFAULT, [In] IntPtr UserContext = default)
	{
		List<SYMBOL_INFO> list = new();
		Win32Error.ThrowLastErrorIfFalse(SymEnumSymbolsEx(hProcess, BaseOfDll, Mask, EnumProc, UserContext, Options));
		return list;

		bool EnumProc(IntPtr pSymInfo, uint SymbolSize, IntPtr UserContext)
		{
			try { list.Add(pSymInfo.ToStructure<SYMBOL_INFO_V>(SymbolSize)); return true; }
			catch { }
			return false;
		}
	}

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
	public static extern bool SymEnumSymbolsEx(HPROCESS hProcess, [Optional] ulong BaseOfDll, [Optional, MarshalAs(UnmanagedType.LPTStr)] string? Mask,
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
	public static extern bool SymEnumTypesByName(HPROCESS hProcess, ulong BaseOfDll, [Optional, MarshalAs(UnmanagedType.LPTStr)] string? mask,
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
		[MarshalAs(UnmanagedType.LPTStr)] StringBuilder DebugFilePath, [Optional] PFIND_DEBUG_FILE_CALLBACK? Callback, [In, Optional] IntPtr CallerData);

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
		[MarshalAs(UnmanagedType.LPTStr)] StringBuilder ImageFilePath, [Optional] PFIND_EXE_FILE_CALLBACK? Callback, [In, Optional] IntPtr CallerData);

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
	public static extern bool SymFindFileInPath(HPROCESS hprocess, [Optional, MarshalAs(UnmanagedType.LPTStr)] string? SearchPath,
		[MarshalAs(UnmanagedType.LPTStr)] string FileName, [In, Optional] IntPtr id, uint two, uint three, SSRVOPT flags,
		[MarshalAs(UnmanagedType.LPTStr)] StringBuilder FoundFile, [In, Optional] PFINDFILEINPATHCALLBACK? callback, [In, Optional] IntPtr context);

	/// <summary>Retrieves symbol information for the specified address.</summary>
	/// <param name="hProcess">A handle to a process. This handle must have been previously passed to the SymInitialize function.</param>
	/// <param name="Address">
	/// The address for which a symbol should be located. The address does not have to be on a symbol boundary. If the address comes
	/// after the beginning of a symbol and before the end of the symbol, the symbol is found.
	/// </param>
	/// <param name="Displacement">The displacement from the beginning of the symbol, or zero.</param>
	/// <param name="Symbol">
	/// A pointer to a SYMBOL_INFO structure that provides information about the symbol. The symbol name is variable in length;
	/// therefore this buffer must be large enough to hold the name stored at the end of the <c>SYMBOL_INFO</c> structure. Be sure to
	/// set the <c>MaxNameLen</c> member to the number of bytes reserved for the name.
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
	/// <para>Examples</para>
	/// <para>For an example, see Retrieving Symbol Information by Address.</para>
	/// </remarks>
	// https://docs.microsoft.com/en-us/windows/win32/api/dbghelp/nf-dbghelp-symfromaddr BOOL IMAGEAPI SymFromAddr( HANDLE hProcess,
	// DWORD64 Address, PDWORD64 Displacement, PSYMBOL_INFO Symbol );
	[DllImport(Lib_DbgHelp, SetLastError = true, CharSet = CharSet.Auto)]
	[PInvokeData("dbghelp.h", MSDNShortId = "NF:dbghelp.SymFromAddr")]
	[return: MarshalAs(UnmanagedType.Bool)]
	public static extern bool SymFromAddr(HPROCESS hProcess, ulong Address, out ulong Displacement, ref SYMBOL_INFO Symbol);

	/// <summary>Retrieves symbol information for the specified index.</summary>
	/// <param name="hProcess">A handle to a process. This handle must have been previously passed to the SymInitialize function.</param>
	/// <param name="BaseOfDll">The base address of the module.</param>
	/// <param name="Index">A unique value for the symbol.</param>
	/// <param name="Symbol">A pointer to a SYMBOL_INFO structure that provides information about the symbol.</param>
	/// <returns>
	/// <para>If the function succeeds, the return value is <c>TRUE</c>.</para>
	/// <para>If the function fails, the return value is <c>FALSE</c>. To retrieve extended error information, call GetLastError.</para>
	/// </returns>
	/// <remarks>
	/// All DbgHelp functions, such as this one, are single threaded. Therefore, calls from more than one thread to this function will
	/// likely result in unexpected behavior or memory corruption. To avoid this, you must synchronize all concurrent calls from more
	/// than one thread to this function.
	/// </remarks>
	// https://docs.microsoft.com/en-us/windows/win32/api/dbghelp/nf-dbghelp-symfromindex BOOL IMAGEAPI SymFromIndex( HANDLE hProcess,
	// ULONG64 BaseOfDll, DWORD Index, PSYMBOL_INFO Symbol );
	[DllImport(Lib_DbgHelp, SetLastError = true, CharSet = CharSet.Auto)]
	[PInvokeData("dbghelp.h", MSDNShortId = "NF:dbghelp.SymFromIndex")]
	[return: MarshalAs(UnmanagedType.Bool)]
	public static extern bool SymFromIndex(HPROCESS hProcess, ulong BaseOfDll, uint Index, ref SYMBOL_INFO Symbol);

	/// <summary>Retrieves symbol information for the specified address and inline context.</summary>
	/// <param name="hProcess">A handle to a process. This handle must have been previously passed to the SymInitialize function.</param>
	/// <param name="Address">
	/// The address for which a symbol should be located. The address does not have to be on a symbol boundary. If the address comes
	/// after the beginning of a symbol and before the end of the symbol, the symbol is found.
	/// </param>
	/// <param name="InlineContext">The inline context for which a symbol should be located.</param>
	/// <param name="Displacement">The displacement from the beginning of the symbol, or zero.</param>
	/// <param name="Symbol">
	/// A pointer to a SYMBOL_INFO structure that provides information about the symbol. The symbol name is variable in length;
	/// therefore this buffer must be large enough to hold the name stored at the end of the <c>SYMBOL_INFO</c> structure. Be sure to
	/// set the <c>MaxNameLen</c> member to the number of bytes reserved for the name.
	/// </param>
	/// <returns>
	/// <para>If the function succeeds, the return value is <c>TRUE</c>.</para>
	/// <para>If the function fails, the return value is <c>FALSE</c>. To retrieve extended error information, call GetLastError.</para>
	/// </returns>
	/// <remarks/>
	// https://docs.microsoft.com/en-us/windows/win32/api/dbghelp/nf-dbghelp-symfrominlinecontextw BOOL IMAGEAPI SymFromInlineContextW(
	// HANDLE hProcess, DWORD64 Address, ULONG InlineContext, PDWORD64 Displacement, PSYMBOL_INFOW Symbol );
	[DllImport(Lib_DbgHelp, SetLastError = true, CharSet = CharSet.Auto)]
	[PInvokeData("dbghelp.h", MSDNShortId = "NF:dbghelp.SymFromInlineContextW")]
	[return: MarshalAs(UnmanagedType.Bool)]
	public static extern bool SymFromInlineContext(HPROCESS hProcess, ulong Address, uint InlineContext, out ulong Displacement, ref SYMBOL_INFO Symbol);

	/// <summary>Retrieves symbol information for the specified name.</summary>
	/// <param name="hProcess">A handle to a process. This handle must have been previously passed to the SymInitialize function.</param>
	/// <param name="Name">The name of the symbol to be located.</param>
	/// <param name="Symbol">A pointer to a SYMBOL_INFO structure that provides information about the symbol.</param>
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
	/// <para>Examples</para>
	/// <para>For an example, see Retrieving Symbol Information by Name.</para>
	/// </remarks>
	// https://docs.microsoft.com/en-us/windows/win32/api/dbghelp/nf-dbghelp-symfromname BOOL IMAGEAPI SymFromName( HANDLE hProcess,
	// PCSTR Name, PSYMBOL_INFO Symbol );
	[DllImport(Lib_DbgHelp, SetLastError = true, CharSet = CharSet.Auto)]
	[PInvokeData("dbghelp.h", MSDNShortId = "NF:dbghelp.SymFromName")]
	[return: MarshalAs(UnmanagedType.Bool)]
	public static extern bool SymFromName(HPROCESS hProcess, [MarshalAs(UnmanagedType.LPTStr)] string Name, ref SYMBOL_INFO Symbol);

	/// <summary>Retrieves symbol information for the specified managed code token.</summary>
	/// <param name="hProcess">A handle to a process. This handle must have been previously passed to the SymInitialize function.</param>
	/// <param name="Base">The base address of the managed code module.</param>
	/// <param name="Token">The managed code token.</param>
	/// <param name="Symbol">A pointer to a SYMBOL_INFO structure that provides information about the symbol.</param>
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
	// https://docs.microsoft.com/en-us/windows/win32/api/dbghelp/nf-dbghelp-symfromtokenw BOOL IMAGEAPI SymFromTokenW( HANDLE hProcess,
	// DWORD64 Base, DWORD Token, PSYMBOL_INFOW Symbol );
	[DllImport(Lib_DbgHelp, SetLastError = true, CharSet = CharSet.Auto)]
	[PInvokeData("dbghelp.h", MSDNShortId = "NF:dbghelp.SymFromTokenW")]
	[return: MarshalAs(UnmanagedType.Bool)]
	public static extern bool SymFromToken(HPROCESS hProcess, ulong Base, uint Token, ref SYMBOL_INFO Symbol);

	/// <summary>Retrieves the function table entry for the specified address.</summary>
	/// <param name="hProcess">A handle to the process that was originally passed to the SymInitialize function.</param>
	/// <param name="AddrBase">The base address for which function table information is required.</param>
	/// <returns>
	/// <para>If the function succeeds, the return value is a pointer to the function table entry.</para>
	/// <para>If the function fails, the return value is <c>NULL</c>. To retrieve extended error information, call GetLastError.</para>
	/// </returns>
	/// <remarks>
	/// <para>The type of pointer returned is specific to the image from which symbols are loaded.</para>
	/// <para><c>x86:</c> If the image is for an x86 system, this is a pointer to an FPO_DATA structure.</para>
	/// <para><c>x64:</c> If the image is for an x64 system, this is a pointer to an _IMAGE_RUNTIME_FUNCTION_ENTRY structure.</para>
	/// <para>
	/// All DbgHelp functions, such as this one, are single threaded. Therefore, calls from more than one thread to this function will
	/// likely result in unexpected behavior or memory corruption. To avoid this, you must synchronize all concurrent calls from more
	/// than one thread to this function.
	/// </para>
	/// <para>
	/// This function supersedes the <c>SymFunctionTableAccess</c> function. For more information, see Updated Platform Support.
	/// <c>SymFunctionTableAccess</c> is defined as follows in Dbghelp.h.
	/// </para>
	/// <para>
	/// <code>#if !defined(_IMAGEHLP_SOURCE_) &amp;&amp; defined(_IMAGEHLP64) #define SymFunctionTableAccess SymFunctionTableAccess64 #else PVOID IMAGEAPI SymFunctionTableAccess( __in HANDLE hProcess, __in DWORD AddrBase ); #endif</code>
	/// </para>
	/// </remarks>
	// https://docs.microsoft.com/en-us/windows/win32/api/dbghelp/nf-dbghelp-symfunctiontableaccess PVOID IMAGEAPI
	// SymFunctionTableAccess( HANDLE hProcess, DWORD AddrBase );
	[DllImport(Lib_DbgHelp, SetLastError = true, ExactSpelling = true)]
	[PInvokeData("dbghelp.h", MSDNShortId = "NF:dbghelp.SymFunctionTableAccess")]
	public static extern IntPtr SymFunctionTableAccess(HPROCESS hProcess, uint AddrBase);

	/// <summary>Retrieves the function table entry for the specified address.</summary>
	/// <param name="hProcess">A handle to the process that was originally passed to the SymInitialize function.</param>
	/// <param name="AddrBase">The base address for which function table information is required.</param>
	/// <returns>
	/// <para>If the function succeeds, the return value is a pointer to the function table entry.</para>
	/// <para>If the function fails, the return value is <c>NULL</c>. To retrieve extended error information, call GetLastError.</para>
	/// </returns>
	/// <remarks>
	/// <para>The type of pointer returned is specific to the image from which symbols are loaded.</para>
	/// <para><c>x86:</c> If the image is for an x86 system, this is a pointer to an FPO_DATA structure.</para>
	/// <para><c>x64:</c> If the image is for an x64 system, this is a pointer to an _IMAGE_RUNTIME_FUNCTION_ENTRY structure.</para>
	/// <para>
	/// All DbgHelp functions, such as this one, are single threaded. Therefore, calls from more than one thread to this function will
	/// likely result in unexpected behavior or memory corruption. To avoid this, you must synchronize all concurrent calls from more
	/// than one thread to this function.
	/// </para>
	/// <para>
	/// This function supersedes the <c>SymFunctionTableAccess</c> function. For more information, see Updated Platform Support.
	/// <c>SymFunctionTableAccess</c> is defined as follows in Dbghelp.h.
	/// </para>
	/// <para>
	/// <code>#if !defined(_IMAGEHLP_SOURCE_) &amp;&amp; defined(_IMAGEHLP64) #define SymFunctionTableAccess SymFunctionTableAccess64 #else PVOID IMAGEAPI SymFunctionTableAccess( __in HANDLE hProcess, __in DWORD AddrBase ); #endif</code>
	/// </para>
	/// </remarks>
	// https://docs.microsoft.com/en-us/windows/win32/api/dbghelp/nf-dbghelp-symfunctiontableaccess64 PVOID IMAGEAPI
	// SymFunctionTableAccess64( HANDLE hProcess, DWORD64 AddrBase );
	[DllImport(Lib_DbgHelp, SetLastError = true, ExactSpelling = true)]
	[PInvokeData("dbghelp.h", MSDNShortId = "NF:dbghelp.SymFunctionTableAccess64")]
	public static extern IntPtr SymFunctionTableAccess64(HPROCESS hProcess, ulong AddrBase);

	/// <summary>
	/// <para>Finds a function table entry or frame pointer omission (FPO) record for an address.</para>
	/// <para>Use SymFunctionTableAccess64 instead.</para>
	/// </summary>
	/// <param name="hProcess">A handle to the process that was originally passed to the SymInitialize function.</param>
	/// <param name="AddrBase">The base address for which function table information is required.</param>
	/// <param name="ReadMemoryRoutine">Pointer to a read memory callback function.</param>
	/// <param name="GetModuleBaseRoutine">Pointer to a get module base callback function.</param>
	/// <returns>None</returns>
	// https://docs.microsoft.com/en-us/windows/win32/api/dbghelp/nf-dbghelp-symfunctiontableaccess64accessroutines PVOID IMAGEAPI
	// SymFunctionTableAccess64AccessRoutines( HANDLE hProcess, DWORD64 AddrBase, PREAD_PROCESS_MEMORY_ROUTINE64 ReadMemoryRoutine,
	// PGET_MODULE_BASE_ROUTINE64 GetModuleBaseRoutine );
	[DllImport(Lib_DbgHelp, SetLastError = false, ExactSpelling = true)]
	[PInvokeData("dbghelp.h", MSDNShortId = "NF:dbghelp.SymFunctionTableAccess64AccessRoutines")]
	public static extern IntPtr SymFunctionTableAccess64AccessRoutines(HPROCESS hProcess, ulong AddrBase, [Optional] PREAD_PROCESS_MEMORY_ROUTINE64? ReadMemoryRoutine,
		[Optional] PGET_MODULE_BASE_ROUTINE64? GetModuleBaseRoutine);

	/// <summary>Gets whether the specified extended symbol option on or off.</summary>
	/// <param name="option">
	/// <para>The extended symbol option to check. The following are valid values.</para>
	/// <list type="table">
	/// <listheader>
	/// <term>Value</term>
	/// <term>Meaning</term>
	/// </listheader>
	/// <item>
	/// <term>SYMOPT_EX_DISABLEACCESSTIMEUPDATE 0</term>
	/// <term>
	/// Turns off explicit updates to the last access time of a symbol that is loaded. By default, DbgHelp updates the last access time
	/// of a symbol file that is consumed so that a symbol cache can be maintained by using a least recently used mechanism.
	/// </term>
	/// </item>
	/// </list>
	/// </param>
	/// <returns>The value of the specified symbol option.</returns>
	// https://docs.microsoft.com/en-us/windows/win32/api/dbghelp/nf-dbghelp-symgetextendedoption BOOL IMAGEAPI SymGetExtendedOption(
	// IMAGEHLP_EXTENDED_OPTIONS option );
	[DllImport(Lib_DbgHelp, SetLastError = false, ExactSpelling = true)]
	[PInvokeData("dbghelp.h", MSDNShortId = "NF:dbghelp.SymGetExtendedOption")]
	[return: MarshalAs(UnmanagedType.Bool)]
	public static extern bool SymGetExtendedOption(IMAGEHLP_EXTENDED_OPTIONS option);

	/// <summary>Locates line information for the specified module and file name.</summary>
	/// <param name="hProcess">A handle to the process that was originally passed to the SymInitialize function.</param>
	/// <param name="ModuleName">
	/// The name of the module in which lines are to be located. If this parameter is <c>NULL</c>, the function searches all modules.
	/// </param>
	/// <param name="FileName">The name of the file in which lines are to be located.</param>
	/// <param name="Buffer">
	/// An array of offsets for each line. The offset for the line n is stored in element n-1. Array elements for lines that do not have
	/// line information are left unchanged.
	/// </param>
	/// <param name="BufferLines">The size of the Buffer array, in elements.</param>
	/// <returns>
	/// <para>
	/// If the function succeeds, the return value is the highest line number found. This value is zero if no line information was found.
	/// </para>
	/// <para>If the function fails, the return value is LINE_ERROR. To retrieve extended error information, call GetLastError.</para>
	/// </returns>
	/// <remarks>
	/// All DbgHelp functions, such as this one, are single threaded. Therefore, calls from more than one thread to this function will
	/// likely result in unexpected behavior or memory corruption. To avoid this, you must synchronize all concurrent calls from more
	/// than one thread to this function.
	/// </remarks>
	// https://docs.microsoft.com/en-us/windows/win32/api/dbghelp/nf-dbghelp-symgetfilelineoffsets64 ULONG IMAGEAPI
	// SymGetFileLineOffsets64( HANDLE hProcess, PCSTR ModuleName, PCSTR FileName, PDWORD64 Buffer, ULONG BufferLines );
	[DllImport(Lib_DbgHelp, SetLastError = true, ExactSpelling = true)]
	[PInvokeData("dbghelp.h", MSDNShortId = "NF:dbghelp.SymGetFileLineOffsets64")]
	public static extern uint SymGetFileLineOffsets64(HPROCESS hProcess, [Optional, MarshalAs(UnmanagedType.LPStr)] string? ModuleName,
		[MarshalAs(UnmanagedType.LPStr)] string FileName, out ulong Buffer, uint BufferLines);

	/// <summary>Retrieves the home directory used by Dbghelp.</summary>
	/// <param name="type">
	/// <para>The directory to be retrieved. This parameter can be one of the following values.</para>
	/// <list type="table">
	/// <listheader>
	/// <term>Value</term>
	/// <term>Meaning</term>
	/// </listheader>
	/// <item>
	/// <term>hdBase 0</term>
	/// <term>The home directory.</term>
	/// </item>
	/// <item>
	/// <term>hdSrc 2</term>
	/// <term>The source directory.</term>
	/// </item>
	/// <item>
	/// <term>hdSym 1</term>
	/// <term>The symbol directory.</term>
	/// </item>
	/// </list>
	/// </param>
	/// <param name="dir">A pointer to a string that receives the directory.</param>
	/// <param name="size">The size of the output buffer, in characters.</param>
	/// <returns>
	/// <para>If the function succeeds, the return value is a pointer to the dir parameter.</para>
	/// <para>If the function fails, the return value is <c>NULL</c>. To retrieve extended error information, call GetLastError.</para>
	/// </returns>
	/// <remarks>
	/// <para>
	/// All DbgHelp functions, such as this one, are single threaded. Therefore, calls from more than one thread to this function will
	/// likely result in unexpected behavior or memory corruption. To avoid this, you must synchronize all concurrent calls from more
	/// than one thread to this function.
	/// </para>
	/// <para>To call the Unicode version of this function, define DBGHELP_TRANSLATE_TCHAR.</para>
	/// </remarks>
	// https://docs.microsoft.com/en-us/windows/win32/api/dbghelp/nf-dbghelp-symgethomedirectory PCHAR IMAGEAPI SymGetHomeDirectory(
	// DWORD type, PSTR dir, size_t size );
	[DllImport(Lib_DbgHelp, SetLastError = true, CharSet = CharSet.Auto)]
	[PInvokeData("dbghelp.h", MSDNShortId = "NF:dbghelp.SymGetHomeDirectory")]
	[return: MarshalAs(UnmanagedType.LPTStr)]
	public static extern StrPtrAuto SymGetHomeDirectory(IMAGEHLP_HD_TYPE type, [Out, MarshalAs(UnmanagedType.LPTStr)] StringBuilder dir, SizeT size);

	/// <summary>Locates the source line for the specified address.</summary>
	/// <param name="hProcess">A handle to the process that was originally passed to the SymInitialize function.</param>
	/// <param name="dwAddr">
	/// The address for which a line should be located. It is not necessary for the address to be on a line boundary. If the address
	/// appears after the beginning of a line and before the end of the line, the line is found.
	/// </param>
	/// <param name="pdwDisplacement">The displacement in bytes from the beginning of the line, or zero.</param>
	/// <param name="Line">A pointer to an IMAGEHLP_LINE64 structure.</param>
	/// <returns>
	/// <para>If the function succeeds, the return value is <c>TRUE</c>.</para>
	/// <para>If the function fails, the return value is <c>FALSE</c>. To retrieve extended error information, call GetLastError.</para>
	/// </returns>
	/// <remarks>
	/// <para>
	/// The caller must allocate the Line buffer properly and fill in the required members of the IMAGEHLP_LINE64 structure before
	/// calling <c>SymGetLineFromAddr64</c>.
	/// </para>
	/// <para>
	/// This function returns a pointer to a buffer that may be reused by another function. Therefore, be sure to copy the data returned
	/// to another buffer immediately.
	/// </para>
	/// <para>
	/// All DbgHelp functions, such as this one, are single threaded. Therefore, calls from more than one thread to this function will
	/// likely result in unexpected behavior or memory corruption. To avoid this, you must synchronize all concurrent calls from more
	/// than one thread to this function.
	/// </para>
	/// <para>
	/// To call the Unicode version of this function, define <c>DBGHELP_TRANSLATE_TCHAR</c>. <c>SymGetLineFromAddrW64</c> is defined as
	/// follows in Dbghelp.h.
	/// </para>
	/// <para>
	/// <code>BOOL IMAGEAPI SymGetLineFromAddrW64( _In_ HANDLE hProcess, _In_ DWORD64 dwAddr, _Out_ PDWORD pdwDisplacement, _Out_ PIMAGEHLP_LINEW64 Line ); #ifdef DBGHELP_TRANSLATE_TCHAR #define SymGetLineFromAddr64 SymGetLineFromAddrW64 #endif</code>
	/// </para>
	/// <para>
	/// This function supersedes the <c>SymGetLineFromAddr</c> function. For more information, see Updated Platform Support.
	/// <c>SymGetLineFromAddr</c> is defined as follows in Dbghelp.h.
	/// </para>
	/// <para>
	/// <code>#if !defined(_IMAGEHLP_SOURCE_) &amp;&amp; defined(_IMAGEHLP64) #define SymGetLineFromAddr SymGetLineFromAddr64 #define SymGetLineFromAddrW SymGetLineFromAddrW64 #else BOOL IMAGEAPI SymGetLineFromAddr( _In_ HANDLE hProcess, _In_ DWORD dwAddr, _Out_ PDWORD pdwDisplacement, _Out_ PIMAGEHLP_LINE Line ); BOOL IMAGEAPI SymGetLineFromAddrW( _In_ HANDLE hProcess, _In_ DWORD dwAddr, _Out_ PDWORD pdwDisplacement, _Out_ PIMAGEHLP_LINEW Line ); #endif</code>
	/// </para>
	/// <para>Examples</para>
	/// <para>For an example, see Retrieving Symbol Information by Address.</para>
	/// </remarks>
	// https://docs.microsoft.com/en-us/windows/win32/api/dbghelp/nf-dbghelp-symgetlinefromaddr
	// BOOL IMAGEAPI SymGetLineFromAddr( HANDLE hProcess, DWORD dwAddr, PDWORD pdwDisplacement, PIMAGEHLP_LINE Line );
	[DllImport(Lib_DbgHelp, SetLastError = true, CharSet = CharSet.Auto)]
	[PInvokeData("dbghelp.h", MSDNShortId = "NF:dbghelp.SymGetLineFromAddr")]
	[return: MarshalAs(UnmanagedType.Bool)]
	public static extern bool SymGetLineFromAddr(HPROCESS hProcess, uint dwAddr, out uint pdwDisplacement, ref IMAGEHLP_LINE Line);

	/// <summary>Locates the source line for the specified address.</summary>
	/// <param name="hProcess">A handle to the process that was originally passed to the SymInitialize function.</param>
	/// <param name="qwAddr">TBD</param>
	/// <param name="pdwDisplacement">The displacement in bytes from the beginning of the line, or zero.</param>
	/// <param name="Line64">TBD</param>
	/// <returns>
	/// <para>If the function succeeds, the return value is <c>TRUE</c>.</para>
	/// <para>If the function fails, the return value is <c>FALSE</c>. To retrieve extended error information, call GetLastError.</para>
	/// </returns>
	/// <remarks>
	/// <para>
	/// The caller must allocate the Line buffer properly and fill in the required members of the IMAGEHLP_LINE64 structure before
	/// calling <c>SymGetLineFromAddr64</c>.
	/// </para>
	/// <para>
	/// This function returns a pointer to a buffer that may be reused by another function. Therefore, be sure to copy the data returned
	/// to another buffer immediately.
	/// </para>
	/// <para>
	/// All DbgHelp functions, such as this one, are single threaded. Therefore, calls from more than one thread to this function will
	/// likely result in unexpected behavior or memory corruption. To avoid this, you must synchronize all concurrent calls from more
	/// than one thread to this function.
	/// </para>
	/// <para>
	/// To call the Unicode version of this function, define <c>DBGHELP_TRANSLATE_TCHAR</c>. <c>SymGetLineFromAddrW64</c> is defined as
	/// follows in Dbghelp.h.
	/// </para>
	/// <para>
	/// <code>BOOL IMAGEAPI SymGetLineFromAddrW64( _In_ HANDLE hProcess, _In_ DWORD64 dwAddr, _Out_ PDWORD pdwDisplacement, _Out_ PIMAGEHLP_LINEW64 Line ); #ifdef DBGHELP_TRANSLATE_TCHAR #define SymGetLineFromAddr64 SymGetLineFromAddrW64 #endif</code>
	/// </para>
	/// <para>
	/// This function supersedes the <c>SymGetLineFromAddr</c> function. For more information, see Updated Platform Support.
	/// <c>SymGetLineFromAddr</c> is defined as follows in Dbghelp.h.
	/// </para>
	/// <para>
	/// <code>#if !defined(_IMAGEHLP_SOURCE_) &amp;&amp; defined(_IMAGEHLP64) #define SymGetLineFromAddr SymGetLineFromAddr64 #define SymGetLineFromAddrW SymGetLineFromAddrW64 #else BOOL IMAGEAPI SymGetLineFromAddr( _In_ HANDLE hProcess, _In_ DWORD dwAddr, _Out_ PDWORD pdwDisplacement, _Out_ PIMAGEHLP_LINE Line ); BOOL IMAGEAPI SymGetLineFromAddrW( _In_ HANDLE hProcess, _In_ DWORD dwAddr, _Out_ PDWORD pdwDisplacement, _Out_ PIMAGEHLP_LINEW Line ); #endif</code>
	/// </para>
	/// <para>Examples</para>
	/// <para>For an example, see Retrieving Symbol Information by Address.</para>
	/// </remarks>
	// https://docs.microsoft.com/en-us/windows/win32/api/dbghelp/nf-dbghelp-symgetlinefromaddr64 BOOL IMAGEAPI SymGetLineFromAddr64(
	// HANDLE hProcess, DWORD64 qwAddr, PDWORD pdwDisplacement, PIMAGEHLP_LINE64 Line64 );
	[DllImport(Lib_DbgHelp, SetLastError = true, CharSet = CharSet.Ansi, ExactSpelling = true)]
	[PInvokeData("dbghelp.h", MSDNShortId = "NF:dbghelp.SymGetLineFromAddr64")]
	[return: MarshalAs(UnmanagedType.Bool)]
	public static extern bool SymGetLineFromAddr64(HPROCESS hProcess, ulong qwAddr, out uint pdwDisplacement, ref IMAGEHLP_LINE64 Line64);

	/// <summary>Locates the source line for the specified address.</summary>
	/// <param name="hProcess">A handle to the process that was originally passed to the SymInitialize function.</param>
	/// <param name="qwAddr">TBD</param>
	/// <param name="pdwDisplacement">The displacement in bytes from the beginning of the line, or zero.</param>
	/// <param name="Line64">TBD</param>
	/// <returns>
	/// <para>If the function succeeds, the return value is <c>TRUE</c>.</para>
	/// <para>If the function fails, the return value is <c>FALSE</c>. To retrieve extended error information, call GetLastError.</para>
	/// </returns>
	/// <remarks>
	/// <para>
	/// The caller must allocate the Line buffer properly and fill in the required members of the IMAGEHLP_LINE64 structure before
	/// calling <c>SymGetLineFromAddr64</c>.
	/// </para>
	/// <para>
	/// This function returns a pointer to a buffer that may be reused by another function. Therefore, be sure to copy the data returned
	/// to another buffer immediately.
	/// </para>
	/// <para>
	/// All DbgHelp functions, such as this one, are single threaded. Therefore, calls from more than one thread to this function will
	/// likely result in unexpected behavior or memory corruption. To avoid this, you must synchronize all concurrent calls from more
	/// than one thread to this function.
	/// </para>
	/// <para>
	/// To call the Unicode version of this function, define <c>DBGHELP_TRANSLATE_TCHAR</c>. <c>SymGetLineFromAddrW64</c> is defined as
	/// follows in Dbghelp.h.
	/// </para>
	/// <para>
	/// <code>BOOL IMAGEAPI SymGetLineFromAddrW64( _In_ HANDLE hProcess, _In_ DWORD64 dwAddr, _Out_ PDWORD pdwDisplacement, _Out_ PIMAGEHLP_LINEW64 Line ); #ifdef DBGHELP_TRANSLATE_TCHAR #define SymGetLineFromAddr64 SymGetLineFromAddrW64 #endif</code>
	/// </para>
	/// <para>
	/// This function supersedes the <c>SymGetLineFromAddr</c> function. For more information, see Updated Platform Support.
	/// <c>SymGetLineFromAddr</c> is defined as follows in Dbghelp.h.
	/// </para>
	/// <para>
	/// <code>#if !defined(_IMAGEHLP_SOURCE_) &amp;&amp; defined(_IMAGEHLP64) #define SymGetLineFromAddr SymGetLineFromAddr64 #define SymGetLineFromAddrW SymGetLineFromAddrW64 #else BOOL IMAGEAPI SymGetLineFromAddr( _In_ HANDLE hProcess, _In_ DWORD dwAddr, _Out_ PDWORD pdwDisplacement, _Out_ PIMAGEHLP_LINE Line ); BOOL IMAGEAPI SymGetLineFromAddrW( _In_ HANDLE hProcess, _In_ DWORD dwAddr, _Out_ PDWORD pdwDisplacement, _Out_ PIMAGEHLP_LINEW Line ); #endif</code>
	/// </para>
	/// <para>Examples</para>
	/// <para>For an example, see Retrieving Symbol Information by Address.</para>
	/// </remarks>
	// https://docs.microsoft.com/en-us/windows/win32/api/dbghelp/nf-dbghelp-symgetlinefromaddr64 BOOL IMAGEAPI SymGetLineFromAddr64(
	// HANDLE hProcess, DWORD64 qwAddr, PDWORD pdwDisplacement, PIMAGEHLP_LINE64 Line64 );
	[DllImport(Lib_DbgHelp, SetLastError = true, CharSet = CharSet.Unicode, ExactSpelling = true)]
	[PInvokeData("dbghelp.h", MSDNShortId = "NF:dbghelp.SymGetLineFromAddr64")]
	[return: MarshalAs(UnmanagedType.Bool)]
	public static extern bool SymGetLineFromAddrW64(HPROCESS hProcess, ulong qwAddr, out uint pdwDisplacement, ref IMAGEHLP_LINE64 Line64);

	/// <summary>Locates the source line for the specified inline context.</summary>
	/// <param name="hProcess">A handle to the process that was originally passed to the SymInitialize function.</param>
	/// <param name="qwAddr">TBD</param>
	/// <param name="InlineContext">The inline context.</param>
	/// <param name="qwModuleBaseAddress">The base address of the module.</param>
	/// <param name="pdwDisplacement">The displacement in bytes from the beginning of the line, or zero.</param>
	/// <param name="Line64">TBD</param>
	/// <returns>
	/// <para>If the function succeeds, the return value is <c>TRUE</c>.</para>
	/// <para>If the function fails, the return value is <c>FALSE</c>. To retrieve extended error information, call GetLastError.</para>
	/// </returns>
	/// <remarks>
	/// <para>
	/// The caller must allocate the Line buffer properly and fill in the required members of the IMAGEHLP_LINE64 structure before
	/// calling <c>SymGetLineFromInlineContext</c>.
	/// </para>
	/// <para>
	/// This function returns a pointer to a buffer that may be reused by another function. Therefore, be sure to copy the data returned
	/// to another buffer immediately.
	/// </para>
	/// <para>
	/// All DbgHelp functions, such as this one, are single threaded. Therefore, calls from more than one thread to this function will
	/// likely result in unexpected behavior or memory corruption. To avoid this, you must synchronize all concurrent calls from more
	/// than one thread to this function.
	/// </para>
	/// <para>
	/// To call the Unicode version of this function, define <c>DBGHELP_TRANSLATE_TCHAR</c>. <c>SymGetLineFromInlineContext</c> is
	/// defined as follows in Dbghelp.h.
	/// </para>
	/// <para>
	/// <code>BOOL IMAGEAPI SymGetLineFromInlineContextW( _In_ HANDLE hProcess, _In_ DWORD64 dwAddr, _In_ ULONG InlineContext, _In_opt_ DWORD64 qwModuleBaseAddress, _Out_ PDWORD pdwDisplacement, _Out_ PIMAGEHLP_LINEW64 Line ); #ifdef DBGHELP_TRANSLATE_TCHAR #define SymGetLineFromInlineContext SymGetLineFromInlineContextW #endif</code>
	/// </para>
	/// </remarks>
	// https://docs.microsoft.com/en-us/windows/win32/api/dbghelp/nf-dbghelp-symgetlinefrominlinecontext BOOL IMAGEAPI
	// SymGetLineFromInlineContext( HANDLE hProcess, DWORD64 qwAddr, ULONG InlineContext, DWORD64 qwModuleBaseAddress, PDWORD
	// pdwDisplacement, PIMAGEHLP_LINE64 Line64 );
	[DllImport(Lib_DbgHelp, SetLastError = true, CharSet = CharSet.Auto)]
	[PInvokeData("dbghelp.h", MSDNShortId = "NF:dbghelp.SymGetLineFromInlineContext")]
	[return: MarshalAs(UnmanagedType.Bool)]
	public static extern bool SymGetLineFromInlineContext(HPROCESS hProcess, ulong qwAddr, uint InlineContext, [Optional] ulong qwModuleBaseAddress,
		out uint pdwDisplacement, ref IMAGEHLP_LINE64 Line64);

	/// <summary>Locates a source line for the specified module, file name, and line number.</summary>
	/// <param name="hProcess">A handle to the process that was originally passed to the SymInitialize function.</param>
	/// <param name="ModuleName">The name of the module in which a line is to be located.</param>
	/// <param name="FileName">
	/// The name of the file in which a line is to be located. If the application has more than one source file with this name, be sure
	/// to specify a full path.
	/// </param>
	/// <param name="dwLineNumber">The line number to be located.</param>
	/// <param name="plDisplacement">The displacement in bytes from the beginning of the line, or zero.</param>
	/// <param name="Line">A pointer to an IMAGEHLP_LINE64 structure.</param>
	/// <returns>
	/// <para>If the function succeeds, the return value is <c>TRUE</c>.</para>
	/// <para>If the function fails, the return value is <c>FALSE</c>. To retrieve extended error information, call GetLastError.</para>
	/// </returns>
	/// <remarks>
	/// <para>
	/// The caller must allocate the Line buffer properly and fill in the required members of the IMAGEHLP_LINE64 structure before
	/// calling <c>SymGetLineFromName64</c>.
	/// </para>
	/// <para>
	/// Before calling this function, ensure that the symbols are initialized correctly by first calling SymInitialize, SymSetOptions,
	/// and SymLoadModule64.
	/// </para>
	/// <para>
	/// This function returns a pointer to a buffer that may be reused by another function. Therefore, be sure to copy the data returned
	/// to another buffer immediately.
	/// </para>
	/// <para>
	/// All DbgHelp functions, such as this one, are single threaded. Therefore, calls from more than one thread to this function will
	/// likely result in unexpected behavior or memory corruption. To avoid this, you must synchronize all concurrent calls from more
	/// than one thread to this function.
	/// </para>
	/// <para>
	/// To call the Unicode version of this function, define DBGHELP_TRANSLATE_TCHAR. <c>SymGetLineFromNameW64</c> is defined as follows
	/// in Dbghelp.h.
	/// </para>
	/// <para>
	/// <code> BOOL IMAGEAPI SymGetLineFromNameW64( __in HANDLE hProcess, __in_opt PCWSTR ModuleName, __in_opt PCWSTR FileName, __in DWORD dwLineNumber, __out PLONG plDisplacement, __inout PIMAGEHLP_LINEW64 Line ); #ifdef DBGHELP_TRANSLATE_TCHAR #define SymGetLineFromName64 SymGetLineFromNameW64 #endif</code>
	/// </para>
	/// <para>
	/// This function supersedes the <c>SymGetLineFromName</c> function. For more information, see Updated Platform Support.
	/// <c>SymGetLineFromName</c> is defined as follows in Dbghelp.h.
	/// </para>
	/// <para>
	/// <code>#if !defined(_IMAGEHLP_SOURCE_) &amp;&amp; defined(_IMAGEHLP64) #define SymGetLineFromName SymGetLineFromName64 #else BOOL IMAGEAPI SymGetLineFromName( __in HANDLE hProcess, __in_opt PCSTR ModuleName, __in_opt PCSTR FileName, __in DWORD dwLineNumber, __out PLONG plDisplacement, __inout PIMAGEHLP_LINE Line ); #endif</code>
	/// </para>
	/// <para>Examples</para>
	/// <para>For an example, see Retrieving Symbol Information by Name.</para>
	/// </remarks>
	// https://docs.microsoft.com/en-us/windows/win32/api/dbghelp/nf-dbghelp-symgetlinefromname BOOL IMAGEAPI SymGetLineFromName( HANDLE
	// hProcess, PCSTR ModuleName, PCSTR FileName, DWORD dwLineNumber, PLONG plDisplacement, PIMAGEHLP_LINE Line );
	[DllImport(Lib_DbgHelp, SetLastError = true, CharSet = CharSet.Ansi, ExactSpelling = true)]
	[PInvokeData("dbghelp.h", MSDNShortId = "NF:dbghelp.SymGetLineFromName")]
	[return: MarshalAs(UnmanagedType.Bool)]
	public static extern bool SymGetLineFromName(HPROCESS hProcess, [MarshalAs(UnmanagedType.LPStr)] string? ModuleName,
		[MarshalAs(UnmanagedType.LPStr)] string? FileName, uint dwLineNumber, out int plDisplacement, ref IMAGEHLP_LINE Line);

	/// <summary>Locates a source line for the specified module, file name, and line number.</summary>
	/// <param name="hProcess">A handle to the process that was originally passed to the SymInitialize function.</param>
	/// <param name="ModuleName">The name of the module in which a line is to be located.</param>
	/// <param name="FileName">
	/// The name of the file in which a line is to be located. If the application has more than one source file with this name, be sure
	/// to specify a full path.
	/// </param>
	/// <param name="dwLineNumber">The line number to be located.</param>
	/// <param name="plDisplacement">The displacement in bytes from the beginning of the line, or zero.</param>
	/// <param name="Line">A pointer to an IMAGEHLP_LINE64 structure.</param>
	/// <returns>
	/// <para>If the function succeeds, the return value is <c>TRUE</c>.</para>
	/// <para>If the function fails, the return value is <c>FALSE</c>. To retrieve extended error information, call GetLastError.</para>
	/// </returns>
	/// <remarks>
	/// <para>
	/// The caller must allocate the Line buffer properly and fill in the required members of the IMAGEHLP_LINE64 structure before
	/// calling <c>SymGetLineFromName64</c>.
	/// </para>
	/// <para>
	/// Before calling this function, ensure that the symbols are initialized correctly by first calling SymInitialize, SymSetOptions,
	/// and SymLoadModule64.
	/// </para>
	/// <para>
	/// This function returns a pointer to a buffer that may be reused by another function. Therefore, be sure to copy the data returned
	/// to another buffer immediately.
	/// </para>
	/// <para>
	/// All DbgHelp functions, such as this one, are single threaded. Therefore, calls from more than one thread to this function will
	/// likely result in unexpected behavior or memory corruption. To avoid this, you must synchronize all concurrent calls from more
	/// than one thread to this function.
	/// </para>
	/// <para>
	/// To call the Unicode version of this function, define DBGHELP_TRANSLATE_TCHAR. <c>SymGetLineFromNameW64</c> is defined as follows
	/// in Dbghelp.h.
	/// </para>
	/// <para>
	/// <code> BOOL IMAGEAPI SymGetLineFromNameW64( __in HANDLE hProcess, __in_opt PCWSTR ModuleName, __in_opt PCWSTR FileName, __in DWORD dwLineNumber, __out PLONG plDisplacement, __inout PIMAGEHLP_LINEW64 Line ); #ifdef DBGHELP_TRANSLATE_TCHAR #define SymGetLineFromName64 SymGetLineFromNameW64 #endif</code>
	/// </para>
	/// <para>
	/// This function supersedes the <c>SymGetLineFromName</c> function. For more information, see Updated Platform Support.
	/// <c>SymGetLineFromName</c> is defined as follows in Dbghelp.h.
	/// </para>
	/// <para>
	/// <code>#if !defined(_IMAGEHLP_SOURCE_) &amp;&amp; defined(_IMAGEHLP64) #define SymGetLineFromName SymGetLineFromName64 #else BOOL IMAGEAPI SymGetLineFromName( __in HANDLE hProcess, __in_opt PCSTR ModuleName, __in_opt PCSTR FileName, __in DWORD dwLineNumber, __out PLONG plDisplacement, __inout PIMAGEHLP_LINE Line ); #endif</code>
	/// </para>
	/// <para>Examples</para>
	/// <para>For an example, see Retrieving Symbol Information by Name.</para>
	/// </remarks>
	// https://docs.microsoft.com/en-us/windows/win32/api/dbghelp/nf-dbghelp-symgetlinefromname64 BOOL IMAGEAPI SymGetLineFromName64(
	// HANDLE hProcess, PCSTR ModuleName, PCSTR FileName, DWORD dwLineNumber, PLONG plDisplacement, PIMAGEHLP_LINE64 Line );
	[DllImport(Lib_DbgHelp, SetLastError = true, CharSet = CharSet.Ansi, ExactSpelling = true)]
	[PInvokeData("dbghelp.h", MSDNShortId = "NF:dbghelp.SymGetLineFromName64")]
	[return: MarshalAs(UnmanagedType.Bool)]
	public static extern bool SymGetLineFromName64(HPROCESS hProcess, [MarshalAs(UnmanagedType.LPStr)] string? ModuleName,
		[MarshalAs(UnmanagedType.LPStr)] string? FileName, uint dwLineNumber, out int plDisplacement, ref IMAGEHLP_LINE64 Line);

	/// <summary>Locates a source line for the specified module, file name, and line number.</summary>
	/// <param name="hProcess">A handle to the process that was originally passed to the SymInitialize function.</param>
	/// <param name="ModuleName">The name of the module in which a line is to be located.</param>
	/// <param name="FileName">
	/// The name of the file in which a line is to be located. If the application has more than one source file with this name, be sure
	/// to specify a full path.
	/// </param>
	/// <param name="dwLineNumber">The line number to be located.</param>
	/// <param name="plDisplacement">The displacement in bytes from the beginning of the line, or zero.</param>
	/// <param name="Line">A pointer to an IMAGEHLP_LINE64 structure.</param>
	/// <returns>
	/// <para>If the function succeeds, the return value is <c>TRUE</c>.</para>
	/// <para>If the function fails, the return value is <c>FALSE</c>. To retrieve extended error information, call GetLastError.</para>
	/// </returns>
	/// <remarks>
	/// <para>
	/// The caller must allocate the Line buffer properly and fill in the required members of the IMAGEHLP_LINE64 structure before
	/// calling <c>SymGetLineFromName64</c>.
	/// </para>
	/// <para>
	/// Before calling this function, ensure that the symbols are initialized correctly by first calling SymInitialize, SymSetOptions,
	/// and SymLoadModule64.
	/// </para>
	/// <para>
	/// This function returns a pointer to a buffer that may be reused by another function. Therefore, be sure to copy the data returned
	/// to another buffer immediately.
	/// </para>
	/// <para>
	/// All DbgHelp functions, such as this one, are single threaded. Therefore, calls from more than one thread to this function will
	/// likely result in unexpected behavior or memory corruption. To avoid this, you must synchronize all concurrent calls from more
	/// than one thread to this function.
	/// </para>
	/// <para>
	/// To call the Unicode version of this function, define DBGHELP_TRANSLATE_TCHAR. <c>SymGetLineFromNameW64</c> is defined as follows
	/// in Dbghelp.h.
	/// </para>
	/// <para>
	/// <code> BOOL IMAGEAPI SymGetLineFromNameW64( __in HANDLE hProcess, __in_opt PCWSTR ModuleName, __in_opt PCWSTR FileName, __in DWORD dwLineNumber, __out PLONG plDisplacement, __inout PIMAGEHLP_LINEW64 Line ); #ifdef DBGHELP_TRANSLATE_TCHAR #define SymGetLineFromName64 SymGetLineFromNameW64 #endif</code>
	/// </para>
	/// <para>
	/// This function supersedes the <c>SymGetLineFromName</c> function. For more information, see Updated Platform Support.
	/// <c>SymGetLineFromName</c> is defined as follows in Dbghelp.h.
	/// </para>
	/// <para>
	/// <code>#if !defined(_IMAGEHLP_SOURCE_) &amp;&amp; defined(_IMAGEHLP64) #define SymGetLineFromName SymGetLineFromName64 #else BOOL IMAGEAPI SymGetLineFromName( __in HANDLE hProcess, __in_opt PCSTR ModuleName, __in_opt PCSTR FileName, __in DWORD dwLineNumber, __out PLONG plDisplacement, __inout PIMAGEHLP_LINE Line ); #endif</code>
	/// </para>
	/// <para>Examples</para>
	/// <para>For an example, see Retrieving Symbol Information by Name.</para>
	/// </remarks>
	// https://docs.microsoft.com/en-us/windows/win32/api/dbghelp/nf-dbghelp-symgetlinefromnamew64 BOOL IMAGEAPI SymGetLineFromNameW64(
	// HANDLE hProcess, PCWSTR ModuleName, PCWSTR FileName, DWORD dwLineNumber, PLONG plDisplacement, PIMAGEHLP_LINEW64 Line );
	[DllImport(Lib_DbgHelp, SetLastError = true, CharSet = CharSet.Unicode, ExactSpelling = true)]
	[PInvokeData("dbghelp.h", MSDNShortId = "NF:dbghelp.SymGetLineFromNameW64")]
	[return: MarshalAs(UnmanagedType.Bool)]
	public static extern bool SymGetLineFromNameW64(HPROCESS hProcess, [MarshalAs(UnmanagedType.LPWStr)] string? ModuleName,
		[MarshalAs(UnmanagedType.LPWStr)] string? FileName, uint dwLineNumber, out int plDisplacement, ref IMAGEHLP_LINE64 Line);

	/// <summary>Retrieves the line information for the next source line.</summary>
	/// <param name="hProcess">A handle to the process that was originally passed to the SymInitialize function.</param>
	/// <param name="Line">A pointer to an IMAGEHLP_LINE64 structure that contains the line information.</param>
	/// <returns>
	/// <para>If the function succeeds, the return value is <c>TRUE</c>.</para>
	/// <para>If the function fails, the return value is <c>FALSE</c>. To retrieve extended error information, call GetLastError.</para>
	/// </returns>
	/// <remarks>
	/// <para>
	/// The <c>SymGetLineNext64</c> function requires that the IMAGEHLP_LINE64 structure have valid data, presumably obtained from a
	/// call to the SymGetLineFromAddr64 or SymGetLineFromName64 function. This structure receives the line information for the next
	/// line in sequence.
	/// </para>
	/// <para>
	/// This function returns a pointer to a buffer that may be reused by another function. Therefore, be sure to copy the data returned
	/// to another buffer immediately.
	/// </para>
	/// <para>
	/// All DbgHelp functions, such as this one, are single threaded. Therefore, calls from more than one thread to this function will
	/// likely result in unexpected behavior or memory corruption. To avoid this, you must synchronize all concurrent calls from more
	/// than one thread to this function.
	/// </para>
	/// <para>
	/// To call the Unicode version of this function, define DBGHELP_TRANSLATE_TCHAR. <c>SymGetLineNextW64</c> is defined as follows in Dbghelp.h.
	/// </para>
	/// <para>
	/// <code> BOOL IMAGEAPI SymGetLineNextW64( __in HANDLE hProcess, __inout PIMAGEHLP_LINEW64 Line #ifdef DBGHELP_TRANSLATE_TCHAR #define SymGetLineNext64 SymGetLineNextW64 #endif</code>
	/// </para>
	/// <para>
	/// This function supersedes the <c>SymGetLineNext</c> function. For more information, see Updated Platform Support.
	/// <c>SymGetLineNext</c> is defined as follows in Dbghelp.h.
	/// </para>
	/// <para>
	/// <code>#if !defined(_IMAGEHLP_SOURCE_) &amp;&amp; defined(_IMAGEHLP64) #define SymGetLineNext SymGetLineNext64 #else BOOL IMAGEAPI SymGetLineNext( __in HANDLE hProcess, __inout PIMAGEHLP_LINE Line ); BOOL IMAGEAPI SymGetLineNextW( __in HANDLE hProcess, __inout PIMAGEHLP_LINEW Line ); #endif</code>
	/// </para>
	/// </remarks>
	// https://docs.microsoft.com/en-us/windows/win32/api/dbghelp/nf-dbghelp-symgetlinenext BOOL IMAGEAPI SymGetLineNext( HANDLE
	// hProcess, PIMAGEHLP_LINE Line );
	[DllImport(Lib_DbgHelp, SetLastError = true, CharSet = CharSet.Auto)]
	[PInvokeData("dbghelp.h", MSDNShortId = "NF:dbghelp.SymGetLineNext")]
	[return: MarshalAs(UnmanagedType.Bool)]
	public static extern bool SymGetLineNext(HPROCESS hProcess, ref IMAGEHLP_LINE Line);

	/// <summary>Retrieves the line information for the next source line.</summary>
	/// <param name="hProcess">A handle to the process that was originally passed to the SymInitialize function.</param>
	/// <param name="Line">A pointer to an IMAGEHLP_LINE64 structure that contains the line information.</param>
	/// <returns>
	/// <para>If the function succeeds, the return value is <c>TRUE</c>.</para>
	/// <para>If the function fails, the return value is <c>FALSE</c>. To retrieve extended error information, call GetLastError.</para>
	/// </returns>
	/// <remarks>
	/// <para>
	/// The <c>SymGetLineNext64</c> function requires that the IMAGEHLP_LINE64 structure have valid data, presumably obtained from a
	/// call to the SymGetLineFromAddr64 or SymGetLineFromName64 function. This structure receives the line information for the next
	/// line in sequence.
	/// </para>
	/// <para>
	/// This function returns a pointer to a buffer that may be reused by another function. Therefore, be sure to copy the data returned
	/// to another buffer immediately.
	/// </para>
	/// <para>
	/// All DbgHelp functions, such as this one, are single threaded. Therefore, calls from more than one thread to this function will
	/// likely result in unexpected behavior or memory corruption. To avoid this, you must synchronize all concurrent calls from more
	/// than one thread to this function.
	/// </para>
	/// <para>
	/// To call the Unicode version of this function, define DBGHELP_TRANSLATE_TCHAR. <c>SymGetLineNextW64</c> is defined as follows in Dbghelp.h.
	/// </para>
	/// <para>
	/// <code> BOOL IMAGEAPI SymGetLineNextW64( __in HANDLE hProcess, __inout PIMAGEHLP_LINEW64 Line #ifdef DBGHELP_TRANSLATE_TCHAR #define SymGetLineNext64 SymGetLineNextW64 #endif</code>
	/// </para>
	/// <para>
	/// This function supersedes the <c>SymGetLineNext</c> function. For more information, see Updated Platform Support.
	/// <c>SymGetLineNext</c> is defined as follows in Dbghelp.h.
	/// </para>
	/// <para>
	/// <code>#if !defined(_IMAGEHLP_SOURCE_) &amp;&amp; defined(_IMAGEHLP64) #define SymGetLineNext SymGetLineNext64 #else BOOL IMAGEAPI SymGetLineNext( __in HANDLE hProcess, __inout PIMAGEHLP_LINE Line ); BOOL IMAGEAPI SymGetLineNextW( __in HANDLE hProcess, __inout PIMAGEHLP_LINEW Line ); #endif</code>
	/// </para>
	/// </remarks>
	// https://docs.microsoft.com/en-us/windows/win32/api/dbghelp/nf-dbghelp-symgetlinenext64 BOOL IMAGEAPI SymGetLineNext64( HANDLE
	// hProcess, PIMAGEHLP_LINE64 Line );
	[DllImport(Lib_DbgHelp, SetLastError = true, CharSet = CharSet.Ansi, ExactSpelling = true)]
	[PInvokeData("dbghelp.h", MSDNShortId = "NF:dbghelp.SymGetLineNext64")]
	[return: MarshalAs(UnmanagedType.Bool)]
	public static extern bool SymGetLineNext64(HPROCESS hProcess, ref IMAGEHLP_LINE64 Line);

	/// <summary>Retrieves the line information for the next source line.</summary>
	/// <param name="hProcess">A handle to the process that was originally passed to the SymInitialize function.</param>
	/// <param name="Line">A pointer to an IMAGEHLP_LINE64 structure that contains the line information.</param>
	/// <returns>
	/// <para>If the function succeeds, the return value is <c>TRUE</c>.</para>
	/// <para>If the function fails, the return value is <c>FALSE</c>. To retrieve extended error information, call GetLastError.</para>
	/// </returns>
	/// <remarks>
	/// <para>
	/// The <c>SymGetLineNext64</c> function requires that the IMAGEHLP_LINE64 structure have valid data, presumably obtained from a
	/// call to the SymGetLineFromAddr64 or SymGetLineFromName64 function. This structure receives the line information for the next
	/// line in sequence.
	/// </para>
	/// <para>
	/// This function returns a pointer to a buffer that may be reused by another function. Therefore, be sure to copy the data returned
	/// to another buffer immediately.
	/// </para>
	/// <para>
	/// All DbgHelp functions, such as this one, are single threaded. Therefore, calls from more than one thread to this function will
	/// likely result in unexpected behavior or memory corruption. To avoid this, you must synchronize all concurrent calls from more
	/// than one thread to this function.
	/// </para>
	/// <para>
	/// To call the Unicode version of this function, define DBGHELP_TRANSLATE_TCHAR. <c>SymGetLineNextW64</c> is defined as follows in Dbghelp.h.
	/// </para>
	/// <para>
	/// <code> BOOL IMAGEAPI SymGetLineNextW64( __in HANDLE hProcess, __inout PIMAGEHLP_LINEW64 Line #ifdef DBGHELP_TRANSLATE_TCHAR #define SymGetLineNext64 SymGetLineNextW64 #endif</code>
	/// </para>
	/// <para>
	/// This function supersedes the <c>SymGetLineNext</c> function. For more information, see Updated Platform Support.
	/// <c>SymGetLineNext</c> is defined as follows in Dbghelp.h.
	/// </para>
	/// <para>
	/// <code>#if !defined(_IMAGEHLP_SOURCE_) &amp;&amp; defined(_IMAGEHLP64) #define SymGetLineNext SymGetLineNext64 #else BOOL IMAGEAPI SymGetLineNext( __in HANDLE hProcess, __inout PIMAGEHLP_LINE Line ); BOOL IMAGEAPI SymGetLineNextW( __in HANDLE hProcess, __inout PIMAGEHLP_LINEW Line ); #endif</code>
	/// </para>
	/// </remarks>
	// https://docs.microsoft.com/en-us/windows/win32/api/dbghelp/nf-dbghelp-symgetlinenextw64 BOOL IMAGEAPI SymGetLineNextW64( HANDLE
	// hProcess, PIMAGEHLP_LINEW64 Line );
	[DllImport(Lib_DbgHelp, SetLastError = true, CharSet = CharSet.Unicode, ExactSpelling = true)]
	[PInvokeData("dbghelp.h", MSDNShortId = "NF:dbghelp.SymGetLineNextW64")]
	[return: MarshalAs(UnmanagedType.Bool)]
	public static extern bool SymGetLineNextW64(HPROCESS hProcess, ref IMAGEHLP_LINE64 Line);

	/// <summary>Retrieves the line information for the previous source line.</summary>
	/// <param name="hProcess">A handle to the process that was originally passed to the SymInitialize function.</param>
	/// <param name="Line">A pointer to an IMAGEHLP_LINE64 structure.</param>
	/// <returns>
	/// <para>If the function succeeds, the return value is <c>TRUE</c>.</para>
	/// <para>If the function fails, the return value is <c>FALSE</c>. To retrieve extended error information, call GetLastError.</para>
	/// </returns>
	/// <remarks>
	/// <para>
	/// The <c>SymGetLinePrev64</c> function requires that the IMAGEHLP_LINE64 structure have valid data, presumably obtained from a
	/// call to the SymGetLineFromAddr64 or SymGetLineFromName64 function. This structure is filled with the line information for the
	/// previous line in sequence.
	/// </para>
	/// <para>
	/// This function returns a pointer to a buffer that may be reused by another function. Therefore, be sure to copy the data returned
	/// to another buffer immediately.
	/// </para>
	/// <para>
	/// All DbgHelp functions, such as this one, are single threaded. Therefore, calls from more than one thread to this function will
	/// likely result in unexpected behavior or memory corruption. To avoid this, you must synchronize all concurrent calls from more
	/// than one thread to this function.
	/// </para>
	/// <para>
	/// To call the Unicode version of this function, define DBGHELP_TRANSLATE_TCHAR. <c>SymGetLinePrevW64</c> is defined as follows in DbgHelp.h.
	/// </para>
	/// <para>
	/// <code>BOOL IMAGEAPI SymGetLinePrevW64( __in HANDLE hProcess, __inout PIMAGEHLP_LINEW64 Line ); #ifdef DBGHELP_TRANSLATE_TCHAR #define SymGetLinePrev64 SymGetLinePrevW64 #endif</code>
	/// </para>
	/// <para>
	/// This function supersedes the <c>SymGetLinePrev</c> function. For more information, see Updated Platform Support.
	/// <c>SymGetLinePrev</c> is defined as follows in DbgHelp.h.
	/// </para>
	/// <para>
	/// <code>#if !defined(_IMAGEHLP_SOURCE_) &amp;&amp; defined(_IMAGEHLP64) #define SymGetLinePrev SymGetLinePrev64 #else BOOL IMAGEAPI SymGetLinePrev( __in HANDLE hProcess, __inout PIMAGEHLP_LINE Line ); BOOL IMAGEAPI SymGetLinePrevW( __in HANDLE hProcess, __inout PIMAGEHLP_LINEW Line ); #endif</code>
	/// </para>
	/// </remarks>
	// https://docs.microsoft.com/en-us/windows/win32/api/dbghelp/nf-dbghelp-symgetlineprev BOOL IMAGEAPI SymGetLinePrev( HANDLE
	// hProcess, PIMAGEHLP_LINE Line );
	[DllImport(Lib_DbgHelp, SetLastError = true, CharSet = CharSet.Auto)]
	[PInvokeData("dbghelp.h", MSDNShortId = "NF:dbghelp.SymGetLinePrev")]
	[return: MarshalAs(UnmanagedType.Bool)]
	public static extern bool SymGetLinePrev(HPROCESS hProcess, ref IMAGEHLP_LINE Line);

	/// <summary>Retrieves the line information for the previous source line.</summary>
	/// <param name="hProcess">A handle to the process that was originally passed to the SymInitialize function.</param>
	/// <param name="Line">A pointer to an IMAGEHLP_LINE64 structure.</param>
	/// <returns>
	/// <para>If the function succeeds, the return value is <c>TRUE</c>.</para>
	/// <para>If the function fails, the return value is <c>FALSE</c>. To retrieve extended error information, call GetLastError.</para>
	/// </returns>
	/// <remarks>
	/// <para>
	/// The <c>SymGetLinePrev64</c> function requires that the IMAGEHLP_LINE64 structure have valid data, presumably obtained from a
	/// call to the SymGetLineFromAddr64 or SymGetLineFromName64 function. This structure is filled with the line information for the
	/// previous line in sequence.
	/// </para>
	/// <para>
	/// This function returns a pointer to a buffer that may be reused by another function. Therefore, be sure to copy the data returned
	/// to another buffer immediately.
	/// </para>
	/// <para>
	/// All DbgHelp functions, such as this one, are single threaded. Therefore, calls from more than one thread to this function will
	/// likely result in unexpected behavior or memory corruption. To avoid this, you must synchronize all concurrent calls from more
	/// than one thread to this function.
	/// </para>
	/// <para>
	/// To call the Unicode version of this function, define DBGHELP_TRANSLATE_TCHAR. <c>SymGetLinePrevW64</c> is defined as follows in DbgHelp.h.
	/// </para>
	/// <para>
	/// <code>BOOL IMAGEAPI SymGetLinePrevW64( __in HANDLE hProcess, __inout PIMAGEHLP_LINEW64 Line ); #ifdef DBGHELP_TRANSLATE_TCHAR #define SymGetLinePrev64 SymGetLinePrevW64 #endif</code>
	/// </para>
	/// <para>
	/// This function supersedes the <c>SymGetLinePrev</c> function. For more information, see Updated Platform Support.
	/// <c>SymGetLinePrev</c> is defined as follows in DbgHelp.h.
	/// </para>
	/// <para>
	/// <code>#if !defined(_IMAGEHLP_SOURCE_) &amp;&amp; defined(_IMAGEHLP64) #define SymGetLinePrev SymGetLinePrev64 #else BOOL IMAGEAPI SymGetLinePrev( __in HANDLE hProcess, __inout PIMAGEHLP_LINE Line ); BOOL IMAGEAPI SymGetLinePrevW( __in HANDLE hProcess, __inout PIMAGEHLP_LINEW Line ); #endif</code>
	/// </para>
	/// </remarks>
	// https://docs.microsoft.com/en-us/windows/win32/api/dbghelp/nf-dbghelp-symgetlineprev64 BOOL IMAGEAPI SymGetLinePrev64( HANDLE
	// hProcess, PIMAGEHLP_LINE64 Line );
	[DllImport(Lib_DbgHelp, SetLastError = true, CharSet = CharSet.Ansi, ExactSpelling = true)]
	[PInvokeData("dbghelp.h", MSDNShortId = "NF:dbghelp.SymGetLinePrev64")]
	[return: MarshalAs(UnmanagedType.Bool)]
	public static extern bool SymGetLinePrev64(HPROCESS hProcess, ref IMAGEHLP_LINE64 Line);

	/// <summary>Retrieves the line information for the previous source line.</summary>
	/// <param name="hProcess">A handle to the process that was originally passed to the SymInitialize function.</param>
	/// <param name="Line">A pointer to an IMAGEHLP_LINE64 structure.</param>
	/// <returns>
	/// <para>If the function succeeds, the return value is <c>TRUE</c>.</para>
	/// <para>If the function fails, the return value is <c>FALSE</c>. To retrieve extended error information, call GetLastError.</para>
	/// </returns>
	/// <remarks>
	/// <para>
	/// The <c>SymGetLinePrev64</c> function requires that the IMAGEHLP_LINE64 structure have valid data, presumably obtained from a
	/// call to the SymGetLineFromAddr64 or SymGetLineFromName64 function. This structure is filled with the line information for the
	/// previous line in sequence.
	/// </para>
	/// <para>
	/// This function returns a pointer to a buffer that may be reused by another function. Therefore, be sure to copy the data returned
	/// to another buffer immediately.
	/// </para>
	/// <para>
	/// All DbgHelp functions, such as this one, are single threaded. Therefore, calls from more than one thread to this function will
	/// likely result in unexpected behavior or memory corruption. To avoid this, you must synchronize all concurrent calls from more
	/// than one thread to this function.
	/// </para>
	/// <para>
	/// To call the Unicode version of this function, define DBGHELP_TRANSLATE_TCHAR. <c>SymGetLinePrevW64</c> is defined as follows in DbgHelp.h.
	/// </para>
	/// <para>
	/// <code>BOOL IMAGEAPI SymGetLinePrevW64( __in HANDLE hProcess, __inout PIMAGEHLP_LINEW64 Line ); #ifdef DBGHELP_TRANSLATE_TCHAR #define SymGetLinePrev64 SymGetLinePrevW64 #endif</code>
	/// </para>
	/// <para>
	/// This function supersedes the <c>SymGetLinePrev</c> function. For more information, see Updated Platform Support.
	/// <c>SymGetLinePrev</c> is defined as follows in DbgHelp.h.
	/// </para>
	/// <para>
	/// <code>#if !defined(_IMAGEHLP_SOURCE_) &amp;&amp; defined(_IMAGEHLP64) #define SymGetLinePrev SymGetLinePrev64 #else BOOL IMAGEAPI SymGetLinePrev( __in HANDLE hProcess, __inout PIMAGEHLP_LINE Line ); BOOL IMAGEAPI SymGetLinePrevW( __in HANDLE hProcess, __inout PIMAGEHLP_LINEW Line ); #endif</code>
	/// </para>
	/// </remarks>
	// https://docs.microsoft.com/en-us/windows/win32/api/dbghelp/nf-dbghelp-symgetlineprevw64 BOOL IMAGEAPI SymGetLinePrevW64( HANDLE
	// hProcess, PIMAGEHLP_LINEW64 Line );
	[DllImport(Lib_DbgHelp, SetLastError = true, CharSet = CharSet.Unicode, ExactSpelling = true)]
	[PInvokeData("dbghelp.h", MSDNShortId = "NF:dbghelp.SymGetLinePrevW64")]
	[return: MarshalAs(UnmanagedType.Bool)]
	public static extern bool SymGetLinePrevW64(HPROCESS hProcess, ref IMAGEHLP_LINE64 Line);

	/// <summary>Retrieves the base address of the module that contains the specified address.</summary>
	/// <param name="hProcess">A handle to the process that was originally passed to the SymInitialize function.</param>
	/// <param name="dwAddr">The virtual address that is contained in one of the modules loaded by the SymLoadModule64 function.</param>
	/// <returns>
	/// <para>
	/// If the function succeeds, the return value is a nonzero virtual address. The value is the base address of the module containing
	/// the address specified by the dwAddr parameter.
	/// </para>
	/// <para>If the function fails, the return value is zero. To retrieve extended error information, call GetLastError.</para>
	/// </returns>
	/// <remarks>
	/// <para>
	/// The module table is searched for a module that contains dwAddr. The module is located based on the load address and size of each module.
	/// </para>
	/// <para>
	/// All DbgHelp functions, such as this one, are single threaded. Therefore, calls from more than one thread to this function will
	/// likely result in unexpected behavior or memory corruption. To avoid this, you must synchronize all concurrent calls from more
	/// than one thread to this function.
	/// </para>
	/// <para>
	/// This function supersedes the <c>SymGetModuleBase</c> function. For more information, see Updated Platform Support.
	/// <c>SymGetModuleBase</c> is defined as follows in DbgHelp.h.
	/// </para>
	/// <para>
	/// <code>#if !defined(_IMAGEHLP_SOURCE_) &amp;&amp; defined(_IMAGEHLP64) #define SymGetModuleBase SymGetModuleBase64 #else DWORD IMAGEAPI SymGetModuleBase( __in HANDLE hProcess, __in DWORD dwAddr ); #endif</code>
	/// </para>
	/// </remarks>
	// https://docs.microsoft.com/en-us/windows/win32/api/dbghelp/nf-dbghelp-symgetmodulebase DWORD IMAGEAPI SymGetModuleBase( HANDLE
	// hProcess, DWORD dwAddr );
	[DllImport(Lib_DbgHelp, SetLastError = true, ExactSpelling = true)]
	[PInvokeData("dbghelp.h", MSDNShortId = "NF:dbghelp.SymGetModuleBase")]
	public static extern uint SymGetModuleBase(HPROCESS hProcess, uint dwAddr);

	/// <summary>Retrieves the base address of the module that contains the specified address.</summary>
	/// <param name="hProcess">A handle to the process that was originally passed to the SymInitialize function.</param>
	/// <param name="qwAddr">TBD</param>
	/// <returns>
	/// <para>
	/// If the function succeeds, the return value is a nonzero virtual address. The value is the base address of the module containing
	/// the address specified by the dwAddr parameter.
	/// </para>
	/// <para>If the function fails, the return value is zero. To retrieve extended error information, call GetLastError.</para>
	/// </returns>
	/// <remarks>
	/// <para>
	/// The module table is searched for a module that contains dwAddr. The module is located based on the load address and size of each module.
	/// </para>
	/// <para>
	/// All DbgHelp functions, such as this one, are single threaded. Therefore, calls from more than one thread to this function will
	/// likely result in unexpected behavior or memory corruption. To avoid this, you must synchronize all concurrent calls from more
	/// than one thread to this function.
	/// </para>
	/// <para>
	/// This function supersedes the <c>SymGetModuleBase</c> function. For more information, see Updated Platform Support.
	/// <c>SymGetModuleBase</c> is defined as follows in DbgHelp.h.
	/// </para>
	/// <para>
	/// <code>#if !defined(_IMAGEHLP_SOURCE_) &amp;&amp; defined(_IMAGEHLP64) #define SymGetModuleBase SymGetModuleBase64 #else DWORD IMAGEAPI SymGetModuleBase( __in HANDLE hProcess, __in DWORD dwAddr ); #endif</code>
	/// </para>
	/// </remarks>
	// https://docs.microsoft.com/en-us/windows/win32/api/dbghelp/nf-dbghelp-symgetmodulebase64 DWORD64 IMAGEAPI SymGetModuleBase64(
	// HANDLE hProcess, DWORD64 qwAddr );
	[DllImport(Lib_DbgHelp, SetLastError = true, ExactSpelling = true)]
	[PInvokeData("dbghelp.h", MSDNShortId = "NF:dbghelp.SymGetModuleBase64")]
	public static extern ulong SymGetModuleBase64(HPROCESS hProcess, ulong qwAddr);

	/// <summary>Retrieves the module information of the specified module.</summary>
	/// <param name="hProcess">A handle to the process that was originally passed to the SymInitialize function.</param>
	/// <param name="dwAddr">The virtual address that is contained in one of the modules loaded by the SymLoadModule64 function</param>
	/// <param name="ModuleInfo">
	/// A pointer to an IMAGEHLP_MODULE64 structure. The <c>SizeOfStruct</c> member must be set to the size of the
	/// <c>IMAGEHLP_MODULE64</c> structure. An invalid value will result in an error.
	/// </param>
	/// <returns>
	/// <para>If the function succeeds, the return value is <c>TRUE</c>.</para>
	/// <para>If the function fails, the return value is <c>FALSE</c>. To retrieve extended error information, call GetLastError.</para>
	/// </returns>
	/// <remarks>
	/// <para>
	/// The module table is searched for a module that contains the dwAddr. The module is located based on the load address and size of
	/// each module. If a valid module is found, the ModuleInfo parameter is filled with the information about the module.
	/// </para>
	/// <para>
	/// The size of the IMAGEHLP_MODULE64 structure used by this function has changed over the years. If a version of DbgHelp.dll is
	/// called that is older than the DbgHelp.h used to compile the calling code, then this function may fail with an error code of
	/// <c>ERROR_INVALID_PARAMETER</c>. This most commonly occurs when the system version (%WinDir%\System32\DbgHelp.dll) is called.
	/// Code that calls the system version of DbgHelp.dll must be compiled using the appropriate SDK for that Windows release or the SDK
	/// for a previous release.
	/// </para>
	/// <para>
	/// The recommended model is to redistribute the required version of DbgHelp.dll along with the calling software. This allows the
	/// caller to use the most robust versions of DbgHelp.dll as well as a simplifying upgrades. The most recent version of DbgHelp.dll
	/// can always be found in the Debugging Tools for Windows package. As a general rule, code that is compiled to work with older
	/// versions will always work with newer versions.
	/// </para>
	/// <para>
	/// All DbgHelp functions, such as this one, are single threaded. Therefore, calls from more than one thread to this function will
	/// likely result in unexpected behavior or memory corruption. To avoid this, you must synchronize all concurrent calls from more
	/// than one thread to this function.
	/// </para>
	/// <para>
	/// To call the Unicode version of this function, define <c>DBGHELP_TRANSLATE_TCHAR</c>. <c>SymGetModuleInfoW64</c> is defined as
	/// follows in DbgHelp.h.
	/// </para>
	/// <para>
	/// <code> BOOL IMAGEAPI SymGetModuleInfoW64( __in HANDLE hProcess, __in DWORD64 qwAddr, __out PIMAGEHLP_MODULEW64 ModuleInfo ); #ifdef DBGHELP_TRANSLATE_TCHAR #define SymGetModuleInfo64 SymGetModuleInfoW64 #endif</code>
	/// </para>
	/// <para>
	/// This function supersedes the <c>SymGetModuleInfo</c> function. For more information, see Updated Platform Support.
	/// <c>SymGetModuleInfo</c> is defined as follows in DbgHelp.h.
	/// </para>
	/// <para>
	/// <code>#if !defined(_IMAGEHLP_SOURCE_) &amp;&amp; defined(_IMAGEHLP64) #define SymGetModuleInfo SymGetModuleInfo64 #define SymGetModuleInfoW SymGetModuleInfoW64 #else BOOL IMAGEAPI SymGetModuleInfo( __in HANDLE hProcess, __in DWORD dwAddr, __out PIMAGEHLP_MODULE ModuleInfo ); BOOL IMAGEAPI SymGetModuleInfoW( __in HANDLE hProcess, __in DWORD dwAddr, __out PIMAGEHLP_MODULEW ModuleInfo ); #endif</code>
	/// </para>
	/// </remarks>
	// https://docs.microsoft.com/en-us/windows/win32/api/dbghelp/nf-dbghelp-symgetmoduleinfo BOOL IMAGEAPI SymGetModuleInfo( HANDLE
	// hProcess, DWORD dwAddr, PIMAGEHLP_MODULE ModuleInfo );
	[DllImport(Lib_DbgHelp, SetLastError = true, CharSet = CharSet.Auto)]
	[PInvokeData("dbghelp.h", MSDNShortId = "NF:dbghelp.SymGetModuleInfo")]
	[return: MarshalAs(UnmanagedType.Bool)]
	public static extern bool SymGetModuleInfo(HPROCESS hProcess, uint dwAddr, ref IMAGEHLP_MODULE ModuleInfo);

	/// <summary>Retrieves the module information of the specified module.</summary>
	/// <param name="hProcess">A handle to the process that was originally passed to the SymInitialize function.</param>
	/// <param name="qwAddr">TBD</param>
	/// <param name="ModuleInfo">
	/// A pointer to an IMAGEHLP_MODULE64 structure. The <c>SizeOfStruct</c> member must be set to the size of the
	/// <c>IMAGEHLP_MODULE64</c> structure. An invalid value will result in an error.
	/// </param>
	/// <returns>
	/// <para>If the function succeeds, the return value is <c>TRUE</c>.</para>
	/// <para>If the function fails, the return value is <c>FALSE</c>. To retrieve extended error information, call GetLastError.</para>
	/// </returns>
	/// <remarks>
	/// <para>
	/// The module table is searched for a module that contains the dwAddr. The module is located based on the load address and size of
	/// each module. If a valid module is found, the ModuleInfo parameter is filled with the information about the module.
	/// </para>
	/// <para>
	/// The size of the IMAGEHLP_MODULE64 structure used by this function has changed over the years. If a version of DbgHelp.dll is
	/// called that is older than the DbgHelp.h used to compile the calling code, then this function may fail with an error code of
	/// <c>ERROR_INVALID_PARAMETER</c>. This most commonly occurs when the system version (%WinDir%\System32\DbgHelp.dll) is called.
	/// Code that calls the system version of DbgHelp.dll must be compiled using the appropriate SDK for that Windows release or the SDK
	/// for a previous release.
	/// </para>
	/// <para>
	/// The recommended model is to redistribute the required version of DbgHelp.dll along with the calling software. This allows the
	/// caller to use the most robust versions of DbgHelp.dll as well as a simplifying upgrades. The most recent version of DbgHelp.dll
	/// can always be found in the Debugging Tools for Windows package. As a general rule, code that is compiled to work with older
	/// versions will always work with newer versions.
	/// </para>
	/// <para>
	/// All DbgHelp functions, such as this one, are single threaded. Therefore, calls from more than one thread to this function will
	/// likely result in unexpected behavior or memory corruption. To avoid this, you must synchronize all concurrent calls from more
	/// than one thread to this function.
	/// </para>
	/// <para>
	/// To call the Unicode version of this function, define <c>DBGHELP_TRANSLATE_TCHAR</c>. <c>SymGetModuleInfoW64</c> is defined as
	/// follows in DbgHelp.h.
	/// </para>
	/// <para>
	/// <code> BOOL IMAGEAPI SymGetModuleInfoW64( __in HANDLE hProcess, __in DWORD64 qwAddr, __out PIMAGEHLP_MODULEW64 ModuleInfo ); #ifdef DBGHELP_TRANSLATE_TCHAR #define SymGetModuleInfo64 SymGetModuleInfoW64 #endif</code>
	/// </para>
	/// <para>
	/// This function supersedes the <c>SymGetModuleInfo</c> function. For more information, see Updated Platform Support.
	/// <c>SymGetModuleInfo</c> is defined as follows in DbgHelp.h.
	/// </para>
	/// <para>
	/// <code>#if !defined(_IMAGEHLP_SOURCE_) &amp;&amp; defined(_IMAGEHLP64) #define SymGetModuleInfo SymGetModuleInfo64 #define SymGetModuleInfoW SymGetModuleInfoW64 #else BOOL IMAGEAPI SymGetModuleInfo( __in HANDLE hProcess, __in DWORD dwAddr, __out PIMAGEHLP_MODULE ModuleInfo ); BOOL IMAGEAPI SymGetModuleInfoW( __in HANDLE hProcess, __in DWORD dwAddr, __out PIMAGEHLP_MODULEW ModuleInfo ); #endif</code>
	/// </para>
	/// </remarks>
	// https://docs.microsoft.com/en-us/windows/win32/api/dbghelp/nf-dbghelp-symgetmoduleinfo64 BOOL IMAGEAPI SymGetModuleInfo64( HANDLE
	// hProcess, DWORD64 qwAddr, PIMAGEHLP_MODULE64 ModuleInfo );
	[DllImport(Lib_DbgHelp, SetLastError = true, CharSet = CharSet.Ansi, ExactSpelling = true)]
	[PInvokeData("dbghelp.h", MSDNShortId = "NF:dbghelp.SymGetModuleInfo64")]
	[return: MarshalAs(UnmanagedType.Bool)]
	public static extern bool SymGetModuleInfo64(HPROCESS hProcess, ulong qwAddr, ref IMAGEHLP_MODULE64 ModuleInfo);

	/// <summary>Retrieves the module information of the specified module.</summary>
	/// <param name="hProcess">A handle to the process that was originally passed to the SymInitialize function.</param>
	/// <param name="qwAddr">TBD</param>
	/// <param name="ModuleInfo">
	/// A pointer to an IMAGEHLP_MODULE64 structure. The <c>SizeOfStruct</c> member must be set to the size of the
	/// <c>IMAGEHLP_MODULE64</c> structure. An invalid value will result in an error.
	/// </param>
	/// <returns>
	/// <para>If the function succeeds, the return value is <c>TRUE</c>.</para>
	/// <para>If the function fails, the return value is <c>FALSE</c>. To retrieve extended error information, call GetLastError.</para>
	/// </returns>
	/// <remarks>
	/// <para>
	/// The module table is searched for a module that contains the dwAddr. The module is located based on the load address and size of
	/// each module. If a valid module is found, the ModuleInfo parameter is filled with the information about the module.
	/// </para>
	/// <para>
	/// The size of the IMAGEHLP_MODULE64 structure used by this function has changed over the years. If a version of DbgHelp.dll is
	/// called that is older than the DbgHelp.h used to compile the calling code, then this function may fail with an error code of
	/// <c>ERROR_INVALID_PARAMETER</c>. This most commonly occurs when the system version (%WinDir%\System32\DbgHelp.dll) is called.
	/// Code that calls the system version of DbgHelp.dll must be compiled using the appropriate SDK for that Windows release or the SDK
	/// for a previous release.
	/// </para>
	/// <para>
	/// The recommended model is to redistribute the required version of DbgHelp.dll along with the calling software. This allows the
	/// caller to use the most robust versions of DbgHelp.dll as well as a simplifying upgrades. The most recent version of DbgHelp.dll
	/// can always be found in the Debugging Tools for Windows package. As a general rule, code that is compiled to work with older
	/// versions will always work with newer versions.
	/// </para>
	/// <para>
	/// All DbgHelp functions, such as this one, are single threaded. Therefore, calls from more than one thread to this function will
	/// likely result in unexpected behavior or memory corruption. To avoid this, you must synchronize all concurrent calls from more
	/// than one thread to this function.
	/// </para>
	/// <para>
	/// To call the Unicode version of this function, define <c>DBGHELP_TRANSLATE_TCHAR</c>. <c>SymGetModuleInfoW64</c> is defined as
	/// follows in DbgHelp.h.
	/// </para>
	/// <para>
	/// <code> BOOL IMAGEAPI SymGetModuleInfoW64( __in HANDLE hProcess, __in DWORD64 qwAddr, __out PIMAGEHLP_MODULEW64 ModuleInfo ); #ifdef DBGHELP_TRANSLATE_TCHAR #define SymGetModuleInfo64 SymGetModuleInfoW64 #endif</code>
	/// </para>
	/// <para>
	/// This function supersedes the <c>SymGetModuleInfo</c> function. For more information, see Updated Platform Support.
	/// <c>SymGetModuleInfo</c> is defined as follows in DbgHelp.h.
	/// </para>
	/// <para>
	/// <code>#if !defined(_IMAGEHLP_SOURCE_) &amp;&amp; defined(_IMAGEHLP64) #define SymGetModuleInfo SymGetModuleInfo64 #define SymGetModuleInfoW SymGetModuleInfoW64 #else BOOL IMAGEAPI SymGetModuleInfo( __in HANDLE hProcess, __in DWORD dwAddr, __out PIMAGEHLP_MODULE ModuleInfo ); BOOL IMAGEAPI SymGetModuleInfoW( __in HANDLE hProcess, __in DWORD dwAddr, __out PIMAGEHLP_MODULEW ModuleInfo ); #endif</code>
	/// </para>
	/// </remarks>
	// https://docs.microsoft.com/en-us/windows/win32/api/dbghelp/nf-dbghelp-symgetmoduleinfo64 BOOL IMAGEAPI SymGetModuleInfo64( HANDLE
	// hProcess, DWORD64 qwAddr, PIMAGEHLP_MODULE64 ModuleInfo );
	[DllImport(Lib_DbgHelp, SetLastError = true, CharSet = CharSet.Unicode, ExactSpelling = true)]
	[PInvokeData("dbghelp.h", MSDNShortId = "NF:dbghelp.SymGetModuleInfo64")]
	[return: MarshalAs(UnmanagedType.Bool)]
	public static extern bool SymGetModuleInfoW64(HPROCESS hProcess, ulong qwAddr, ref IMAGEHLP_MODULE64 ModuleInfo);

	/// <summary>Retrieves the omap tables within a loaded module.</summary>
	/// <param name="hProcess">A handle to a process. This handle must have been previously passed to the SymInitialize function.</param>
	/// <param name="BaseOfDll">The base address of the module.</param>
	/// <param name="OmapTo">
	/// An array of address map entries to the new image layout taken from the original layout. For details on the map entries, see the
	/// OMAP structure.
	/// </param>
	/// <param name="cOmapTo">The number of entries in the OmapTo array.</param>
	/// <param name="OmapFrom">
	/// An array of address map entries from the new image layout to the original layout (as described by the debug symbols). For
	/// details on the map entries, see the OMAP structure.
	/// </param>
	/// <param name="cOmapFrom">The number of entries in the OmapFrom array.</param>
	/// <returns>
	/// <para>If the function succeeds, the return value is <c>TRUE</c>.</para>
	/// <para>
	/// If the function fails (the omap is not found), the return value is <c>FALSE</c>. To retrieve extended error information, call GetLastError.
	/// </para>
	/// </returns>
	/// <remarks>
	/// All DbgHelp functions, such as this one, are single threaded. Therefore, calls from more than one thread to this function will
	/// likely result in unexpected behavior or memory corruption. To avoid this, you must synchronize all concurrent calls from more
	/// than one thread to this function.
	/// </remarks>
	// https://docs.microsoft.com/en-us/windows/win32/api/dbghelp/nf-dbghelp-symgetomaps BOOL IMAGEAPI SymGetOmaps( HANDLE hProcess,
	// DWORD64 BaseOfDll, POMAP *OmapTo, PDWORD64 cOmapTo, POMAP *OmapFrom, PDWORD64 cOmapFrom );
	[DllImport(Lib_DbgHelp, SetLastError = true, ExactSpelling = true)]
	[PInvokeData("dbghelp.h", MSDNShortId = "NF:dbghelp.SymGetOmaps")]
	[return: MarshalAs(UnmanagedType.Bool)]
	public static unsafe extern bool SymGetOmaps(HPROCESS hProcess, ulong BaseOfDll,
		//[MarshalAs(UnmanagedType.LPArray, SizeParamIndex = 3)] out OMAP[] OmapTo, out ulong cOmapTo,
		//[MarshalAs(UnmanagedType.LPArray, SizeParamIndex = 5)] out OMAP[] OmapFrom, out ulong cOmapFrom);
		out OMAP* OmapTo, out ulong cOmapTo, out OMAP* OmapFrom, out ulong cOmapFrom);

	/// <summary>Retrieves the current option mask.</summary>
	/// <returns>
	/// The function returns the current options that have been set. Zero is a valid value and indicates that all options are turned off.
	/// </returns>
	/// <remarks>
	/// <para>
	/// These options can be changed several times while the library is in use by an application. Any option change affects all future
	/// calls to the symbol handler.
	/// </para>
	/// <para>The return value is the combination of the following values that have been set using the SymSetOptions function.</para>
	/// <list type="bullet">
	/// <item>
	/// <term>SYMOPT_ALLOW_ABSOLUTE_SYMBOLS</term>
	/// </item>
	/// <item>
	/// <term>SYMOPT_ALLOW_ZERO_ADDRESS</term>
	/// </item>
	/// <item>
	/// <term>SYMOPT_AUTO_PUBLICS</term>
	/// </item>
	/// <item>
	/// <term>SYMOPT_CASE_INSENSITIVE</term>
	/// </item>
	/// <item>
	/// <term>SYMOPT_DEBUG</term>
	/// </item>
	/// <item>
	/// <term>SYMOPT_DEFERRED_LOADS</term>
	/// </item>
	/// <item>
	/// <term>SYMOPT_EXACT_SYMBOLS</term>
	/// </item>
	/// <item>
	/// <term>SYMOPT_FAIL_CRITICAL_ERRORS</term>
	/// </item>
	/// <item>
	/// <term>SYMOPT_FAVOR_COMPRESSED</term>
	/// </item>
	/// <item>
	/// <term>SYMOPT_FLAT_DIRECTORY</term>
	/// </item>
	/// <item>
	/// <term>SYMOPT_IGNORE_CVREC</term>
	/// </item>
	/// <item>
	/// <term>SYMOPT_IGNORE_IMAGEDIR</term>
	/// </item>
	/// <item>
	/// <term>SYMOPT_IGNORE_NT_SYMPATH</term>
	/// </item>
	/// <item>
	/// <term>SYMOPT_INCLUDE_32BIT_MODULES</term>
	/// </item>
	/// <item>
	/// <term>SYMOPT_LOAD_ANYTHING</term>
	/// </item>
	/// <item>
	/// <term>SYMOPT_LOAD_LINES</term>
	/// </item>
	/// <item>
	/// <term>SYMOPT_NO_CPP</term>
	/// </item>
	/// <item>
	/// <term>SYMOPT_NO_IMAGE_SEARCH</term>
	/// </item>
	/// <item>
	/// <term>SYMOPT_NO_PROMPTS</term>
	/// </item>
	/// <item>
	/// <term>SYMOPT_NO_PUBLICS</term>
	/// </item>
	/// <item>
	/// <term>SYMOPT_NO_UNQUALIFIED_LOADS</term>
	/// </item>
	/// <item>
	/// <term>SYMOPT_OVERWRITE</term>
	/// </item>
	/// <item>
	/// <term>SYMOPT_PUBLICS_ONLY</term>
	/// </item>
	/// <item>
	/// <term>SYMOPT_SECURE</term>
	/// </item>
	/// <item>
	/// <term>SYMOPT_UNDNAME</term>
	/// </item>
	/// </list>
	/// <para>
	/// All DbgHelp functions, such as this one, are single threaded. Therefore, calls from more than one thread to this function will
	/// likely result in unexpected behavior or memory corruption. To avoid this, you must synchronize all concurrent calls from more
	/// than one thread to this function.
	/// </para>
	/// </remarks>
	// https://docs.microsoft.com/en-us/windows/win32/api/dbghelp/nf-dbghelp-symgetoptions DWORD IMAGEAPI SymGetOptions();
	[DllImport(Lib_DbgHelp, SetLastError = true, ExactSpelling = true)]
	[PInvokeData("dbghelp.h", MSDNShortId = "NF:dbghelp.SymGetOptions")]
	public static extern SYMOPT SymGetOptions();

	/// <summary>Retrieves the scope for the specified index.</summary>
	/// <param name="hProcess">A handle to a process. This handle must have been previously passed to the SymInitialize function.</param>
	/// <param name="BaseOfDll">The base address of the module.</param>
	/// <param name="Index">A unique value for the symbol.</param>
	/// <param name="Symbol">A pointer to a SYMBOL_INFO structure. The <c>Scope</c> member contains the scope.</param>
	/// <returns>
	/// <para>If the function succeeds, the return value is <c>TRUE</c>.</para>
	/// <para>If the function fails, the return value is <c>FALSE</c>. To retrieve extended error information, call GetLastError.</para>
	/// </returns>
	/// <remarks>
	/// All DbgHelp functions, such as this one, are single threaded. Therefore, calls from more than one thread to this function will
	/// likely result in unexpected behavior or memory corruption. To avoid this, you must synchronize all concurrent calls from more
	/// than one thread to this function.
	/// </remarks>
	// https://docs.microsoft.com/en-us/windows/win32/api/dbghelp/nf-dbghelp-symgetscope BOOL IMAGEAPI SymGetScope( HANDLE hProcess,
	// ULONG64 BaseOfDll, DWORD Index, PSYMBOL_INFO Symbol );
	[DllImport(Lib_DbgHelp, SetLastError = true, CharSet = CharSet.Auto)]
	[PInvokeData("dbghelp.h", MSDNShortId = "NF:dbghelp.SymGetScope")]
	[return: MarshalAs(UnmanagedType.Bool)]
	public static extern bool SymGetScope(HPROCESS hProcess, ulong BaseOfDll, uint Index, ref SYMBOL_INFO Symbol);

	/// <summary>Retrieves the symbol search path for the specified process.</summary>
	/// <param name="hProcess">A handle to the process that was originally passed to the SymInitialize function.</param>
	/// <param name="SearchPath">A pointer to the buffer that receives the symbol search path.</param>
	/// <param name="SearchPathLength">The size of the SearchPath buffer, in characters.</param>
	/// <returns>
	/// <para>If the function succeeds, the return value is <c>TRUE</c>.</para>
	/// <para>If the function fails, the return value is <c>FALSE</c>. To retrieve extended error information, call GetLastError.</para>
	/// </returns>
	/// <remarks>
	/// <para>
	/// The <c>SymGetSearchPath</c> function copies the symbol search path for the specified process into the SearchPath buffer. If the
	/// function fails, the contents of the buffer are undefined.
	/// </para>
	/// <para>To specify a symbol search path for the process, use the SymSetSearchPath function.</para>
	/// <para>
	/// All DbgHelp functions, such as this one, are single threaded. Therefore, calls from more than one thread to this function will
	/// likely result in unexpected behavior or memory corruption. To avoid this, you must synchronize all concurrent calls from more
	/// than one thread to this function.
	/// </para>
	/// <para>To call the Unicode version of this function, define DBGHELP_TRANSLATE_TCHAR.</para>
	/// </remarks>
	// https://docs.microsoft.com/en-us/windows/win32/api/dbghelp/nf-dbghelp-symgetsearchpath BOOL IMAGEAPI SymGetSearchPath( HANDLE
	// hProcess, PSTR SearchPath, DWORD SearchPathLength );
	[DllImport(Lib_DbgHelp, SetLastError = true, CharSet = CharSet.Auto)]
	[PInvokeData("dbghelp.h", MSDNShortId = "NF:dbghelp.SymGetSearchPath")]
	[return: MarshalAs(UnmanagedType.Bool)]
	public static extern bool SymGetSearchPath(HPROCESS hProcess, [Out, MarshalAs(UnmanagedType.LPTStr)] StringBuilder SearchPath, uint SearchPathLength);

	/// <summary>Retrieves the specified source file from the source server.</summary>
	/// <param name="hProcess">A handle to a process. This handle must have been previously passed to the SymInitialize function.</param>
	/// <param name="Base">The base address of the module.</param>
	/// <param name="Params">This parameter is unused.</param>
	/// <param name="FileSpec">The name of the source file.</param>
	/// <param name="FilePath">A pointer to a buffer that receives the fully qualified path of the source file.</param>
	/// <param name="Size">The size of the FilePath buffer, in characters.</param>
	/// <returns>
	/// <para>If the function succeeds, the return value is <c>TRUE</c>.</para>
	/// <para>If the function fails, the return value is <c>FALSE</c>. To retrieve extended error information, call GetLastError.</para>
	/// </returns>
	/// <remarks>
	/// <para>To control which directory receives the source files, use the SymSetHomeDirectory function.</para>
	/// <para>
	/// All DbgHelp functions, such as this one, are single threaded. Therefore, calls from more than one thread to this function will
	/// likely result in unexpected behavior or memory corruption. To avoid this, you must synchronize all concurrent calls from more
	/// than one thread to this function.
	/// </para>
	/// <para>To call the Unicode version of this function, define DBGHELP_TRANSLATE_TCHAR.</para>
	/// </remarks>
	// https://docs.microsoft.com/en-us/windows/win32/api/dbghelp/nf-dbghelp-symgetsourcefile BOOL IMAGEAPI SymGetSourceFile( HANDLE
	// hProcess, ULONG64 Base, PCSTR Params, PCSTR FileSpec, PSTR FilePath, DWORD Size );
	[DllImport(Lib_DbgHelp, SetLastError = true, CharSet = CharSet.Auto)]
	[PInvokeData("dbghelp.h", MSDNShortId = "NF:dbghelp.SymGetSourceFile")]
	[return: MarshalAs(UnmanagedType.Bool)]
	public static extern bool SymGetSourceFile(HPROCESS hProcess, ulong Base, [Optional, MarshalAs(UnmanagedType.LPTStr)] string? Params,
		[MarshalAs(UnmanagedType.LPTStr)] string FileSpec, [Out, MarshalAs(UnmanagedType.LPTStr)] StringBuilder FilePath, uint Size);

	/// <summary>Retrieves the specified source file checksum from the source server.</summary>
	/// <param name="hProcess">A handle to a process. This handle must have been previously passed to the SymInitialize function.</param>
	/// <param name="Base">The base address of the module.</param>
	/// <param name="FileSpec">The name of the source file.</param>
	/// <param name="pCheckSumType">On success, points to the checksum type.</param>
	/// <param name="pChecksum">
	/// pointer to a buffer that receives the checksum. If <c>NULL</c>, then when the call returns pActualBytesWritten returns the
	/// number of bytes required.
	/// </param>
	/// <param name="checksumSize">The size of the pChecksum buffer, in bytes.</param>
	/// <param name="pActualBytesWritten">Pointer to the actual bytes written in the buffer.</param>
	/// <returns>
	/// <para>If the function succeeds, the return value is <c>TRUE</c>.</para>
	/// <para>If the function fails, the return value is <c>FALSE</c>. To retrieve extended error information, call GetLastError.</para>
	/// </returns>
	// https://docs.microsoft.com/en-us/windows/win32/api/dbghelp/nf-dbghelp-symgetsourcefilechecksum BOOL IMAGEAPI
	// SymGetSourceFileChecksum( HANDLE hProcess, ULONG64 Base, PCSTR FileSpec, DWORD *pCheckSumType, BYTE *pChecksum, DWORD
	// checksumSize, DWORD *pActualBytesWritten );
	[DllImport(Lib_DbgHelp, SetLastError = true, CharSet = CharSet.Auto)]
	[PInvokeData("dbghelp.h", MSDNShortId = "NF:dbghelp.SymGetSourceFileChecksum")]
	[return: MarshalAs(UnmanagedType.Bool)]
	public static extern bool SymGetSourceFileChecksum(HPROCESS hProcess, ulong Base, [MarshalAs(UnmanagedType.LPTStr)] string FileSpec,
		out uint pCheckSumType, [Out] IntPtr pChecksum, uint checksumSize, out uint pActualBytesWritten);

	/// <summary>Retrieves the source file associated with the specified token from the source server.</summary>
	/// <param name="hProcess">A handle to a process. This handle must have been previously passed to the SymInitialize function.</param>
	/// <param name="Token">A pointer to the token.</param>
	/// <param name="Params">This parameter is unused.</param>
	/// <param name="FilePath">A pointer to a buffer that receives the fully qualified path of the source file.</param>
	/// <param name="Size">The size of the FilePath buffer, in characters.</param>
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
	// https://docs.microsoft.com/en-us/windows/win32/api/dbghelp/nf-dbghelp-symgetsourcefilefromtoken BOOL IMAGEAPI
	// SymGetSourceFileFromToken( HANDLE hProcess, PVOID Token, PCSTR Params, PSTR FilePath, DWORD Size );
	[DllImport(Lib_DbgHelp, SetLastError = true, CharSet = CharSet.Auto)]
	[PInvokeData("dbghelp.h", MSDNShortId = "NF:dbghelp.SymGetSourceFileFromToken")]
	[return: MarshalAs(UnmanagedType.Bool)]
	public static extern bool SymGetSourceFileFromToken(HPROCESS hProcess, [In] IntPtr Token, [Optional, MarshalAs(UnmanagedType.LPTStr)] string? Params,
		[Out, MarshalAs(UnmanagedType.LPTStr)] StringBuilder FilePath, uint Size);

	/// <summary>Retrieves token for the specified source file from the source server.</summary>
	/// <param name="hProcess">A handle to a process. This handle must have been previously passed to the SymInitialize function.</param>
	/// <param name="Base">The base address of the module.</param>
	/// <param name="FileSpec">The name of the source file.</param>
	/// <param name="Token">A pointer to a buffer that receives the token.</param>
	/// <param name="Size">The size of the Token buffer, in bytes.</param>
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
	// https://docs.microsoft.com/en-us/windows/win32/api/dbghelp/nf-dbghelp-symgetsourcefiletoken BOOL IMAGEAPI SymGetSourceFileToken(
	// HANDLE hProcess, ULONG64 Base, PCSTR FileSpec, PVOID *Token, DWORD *Size );
	[DllImport(Lib_DbgHelp, SetLastError = true, CharSet = CharSet.Auto)]
	[PInvokeData("dbghelp.h", MSDNShortId = "NF:dbghelp.SymGetSourceFileToken")]
	[return: MarshalAs(UnmanagedType.Bool)]
	public static extern bool SymGetSourceFileToken(HPROCESS hProcess, ulong Base, [MarshalAs(UnmanagedType.LPTStr)] string FileSpec, out IntPtr Token, out uint Size);

	/// <summary>Retrieves the value associated with the specified variable name from the Source Server token.</summary>
	/// <param name="hProcess">A handle to a process. This handle must have been previously passed to the SymInitialize function.</param>
	/// <param name="Token">A pointer to the token.</param>
	/// <param name="Params">This parameter is unused.</param>
	/// <param name="VarName">The name of the variable token whose value you want to retrieve.</param>
	/// <param name="Value">
	/// A pointer to a buffer that receives the value associated with the variable token specified in the VarName parameter.
	/// </param>
	/// <param name="Size">The size of the Value buffer, in characters.</param>
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
	// https://docs.microsoft.com/en-us/windows/win32/api/dbghelp/nf-dbghelp-symgetsourcevarfromtoken BOOL IMAGEAPI
	// SymGetSourceVarFromToken( HANDLE hProcess, PVOID Token, PCSTR Params, PCSTR VarName, PSTR Value, DWORD Size );
	[DllImport(Lib_DbgHelp, SetLastError = true, CharSet = CharSet.Auto)]
	[PInvokeData("dbghelp.h", MSDNShortId = "NF:dbghelp.SymGetSourceVarFromToken")]
	[return: MarshalAs(UnmanagedType.Bool)]
	public static extern bool SymGetSourceVarFromToken(HPROCESS hProcess, [In] IntPtr Token, [Optional, MarshalAs(UnmanagedType.LPTStr)] string? Params,
		[MarshalAs(UnmanagedType.LPTStr)] string VarName, [Out, MarshalAs(UnmanagedType.LPTStr)] StringBuilder Value, uint Size);

	/// <summary>Locates a symbol file in the specified symbol path.</summary>
	/// <param name="hProcess">
	/// <para>A handle to the process that was originally passed to the SymInitialize function.</para>
	/// <para>
	/// If this handle is 0, SymPath cannot be <c>NULL</c>. Use this option to load a symbol file without calling SymInitialize or SymCleanup.
	/// </para>
	/// </param>
	/// <param name="SymPath">
	/// The symbol path. If this parameter is <c>NULL</c> or an empty string, the function uses the symbol path set using the
	/// SymInitialize or SymSetSearchPath function.
	/// </param>
	/// <param name="ImageFile">The name of the image file.</param>
	/// <param name="Type">
	/// <para>The type of symbol file. This parameter can be one of the following values.</para>
	/// <list type="table">
	/// <listheader>
	/// <term>Value</term>
	/// <term>Meaning</term>
	/// </listheader>
	/// <item>
	/// <term>sfImage 0</term>
	/// <term>A .exe or .dll file.</term>
	/// </item>
	/// <item>
	/// <term>sfDbg 1</term>
	/// <term>A .dbg file.</term>
	/// </item>
	/// <item>
	/// <term>sfPdb 2</term>
	/// <term>A .pdb file.</term>
	/// </item>
	/// <item>
	/// <term>sfMpd 3</term>
	/// <term>Reserved.</term>
	/// </item>
	/// </list>
	/// </param>
	/// <param name="SymbolFile">A pointer to a null-terminated string that receives the name of the symbol file.</param>
	/// <param name="cSymbolFile">The size of the SymbolFile buffer, in characters.</param>
	/// <param name="DbgFile">
	/// A pointer to a buffer that receives the fully qualified path to the symbol file. This buffer must be at least MAX_PATH characters.
	/// </param>
	/// <param name="cDbgFile">The size of the DbgFile buffer, in characters.</param>
	/// <returns>
	/// If the server locates a valid symbol file, it returns <c>TRUE</c>; otherwise, it returns <c>FALSE</c> and GetLastError returns a
	/// value that indicates why the symbol file was not returned.
	/// </returns>
	/// <remarks>
	/// <para>
	/// All DbgHelp functions, such as this one, are single threaded. Therefore, calls from more than one thread to this function will
	/// likely result in unexpected behavior or memory corruption. To avoid this, you must synchronize all concurrent calls from more
	/// than one thread to this function.
	/// </para>
	/// <para>To call the Unicode version of this function, define DBGHELP_TRANSLATE_TCHAR.</para>
	/// </remarks>
	// https://docs.microsoft.com/en-us/windows/win32/api/dbghelp/nf-dbghelp-symgetsymbolfile BOOL IMAGEAPI SymGetSymbolFile( HANDLE
	// hProcess, PCSTR SymPath, PCSTR ImageFile, DWORD Type, PSTR SymbolFile, size_t cSymbolFile, PSTR DbgFile, size_t cDbgFile );
	[DllImport(Lib_DbgHelp, SetLastError = true, CharSet = CharSet.Auto)]
	[PInvokeData("dbghelp.h", MSDNShortId = "NF:dbghelp.SymGetSymbolFile")]
	[return: MarshalAs(UnmanagedType.Bool)]
	public static extern bool SymGetSymbolFile([Optional] HPROCESS hProcess, [Optional, MarshalAs(UnmanagedType.LPTStr)] string? SymPath,
		[MarshalAs(UnmanagedType.LPTStr)] string ImageFile, IMAGEHLP_SF_TYPE Type, [Out, MarshalAs(UnmanagedType.LPTStr)] StringBuilder SymbolFile,
		SizeT cSymbolFile, [Out, MarshalAs(UnmanagedType.LPTStr)] StringBuilder DbgFile, SizeT cDbgFile);

	/// <summary>
	/// <para>Locates the symbol for the specified address.</para>
	/// <para><c>Note</c> This function is provided only for compatibility. Applications should use SymFromAddr.</para>
	/// </summary>
	/// <param name="hProcess">A handle to the process that was originally passed to the SymInitialize function.</param>
	/// <param name="dwAddr">
	/// The address for which a symbol is to be located. The address does not have to be on a symbol boundary. If the address comes
	/// after the beginning of a symbol and before the end of the symbol (the beginning of the symbol plus the symbol size), the symbol
	/// is found.
	/// </param>
	/// <param name="pdwDisplacement">The displacement from the beginning of the symbol, or zero.</param>
	/// <param name="Symbol">A pointer to an IMAGEHLP_SYMBOL64 structure.</param>
	/// <returns>
	/// <para>If the function succeeds, the return value is <c>TRUE</c>.</para>
	/// <para>If the function fails, the return value is <c>FALSE</c>. To retrieve extended error information, call GetLastError.</para>
	/// </returns>
	/// <remarks>
	/// <para>
	/// The <c>SymGetSymFromAddr64</c> function locates the symbol for a specified address. The modules are searched for the one the
	/// address belongs to. When the module is found, its symbol table is searched for a match. When the symbol is found, the symbol
	/// information is copied into the Symbol buffer provided by the caller. The caller must allocate the Symbol buffer properly and
	/// fill in the required parameters in the IMAGEHLP_SYMBOL64 structure before calling <c>SymGetSymFromAddr64</c>.
	/// </para>
	/// <para>
	/// All DbgHelp functions, such as this one, are single threaded. Therefore, calls from more than one thread to this function will
	/// likely result in unexpected behavior or memory corruption. To avoid this, you must synchronize all concurrent calls from more
	/// than one thread to this function.
	/// </para>
	/// <para>
	/// This function supersedes the <c>SymGetSymFromAddr</c> function. For more information, see Updated Platform Support.
	/// <c>SymGetSymFromAddr</c> is defined as follows in Dbghelp.h.
	/// </para>
	/// <para>
	/// <code>#if !defined(_IMAGEHLP_SOURCE_) &amp;&amp; defined(_IMAGEHLP64) #define SymGetSymFromAddr SymGetSymFromAddr64 #else BOOL IMAGEAPI SymGetSymFromAddr( __in HANDLE hProcess, __in DWORD dwAddr, __out_opt PDWORD pdwDisplacement, __inout PIMAGEHLP_SYMBOL Symbol ); #endif</code>
	/// </para>
	/// </remarks>
	// https://docs.microsoft.com/en-us/windows/win32/api/dbghelp/nf-dbghelp-symgetsymfromaddr BOOL IMAGEAPI SymGetSymFromAddr( HANDLE
	// hProcess, DWORD dwAddr, PDWORD pdwDisplacement, PIMAGEHLP_SYMBOL Symbol );
	[DllImport(Lib_DbgHelp, SetLastError = true, ExactSpelling = true, CharSet = CharSet.Ansi)]
	[PInvokeData("dbghelp.h", MSDNShortId = "NF:dbghelp.SymGetSymFromAddr")]
	[return: MarshalAs(UnmanagedType.Bool)]
	public static extern bool SymGetSymFromAddr(HPROCESS hProcess, uint dwAddr, out uint pdwDisplacement, SafeIMAGEHLP_SYMBOL Symbol);

	/// <summary>
	/// <para>Locates the symbol for the specified address.</para>
	/// <para><c>Note</c> This function is provided only for compatibility. Applications should use SymFromAddr.</para>
	/// </summary>
	/// <param name="hProcess">A handle to the process that was originally passed to the SymInitialize function.</param>
	/// <param name="qwAddr">TBD</param>
	/// <param name="pdwDisplacement">The displacement from the beginning of the symbol, or zero.</param>
	/// <param name="Symbol">A pointer to an IMAGEHLP_SYMBOL64 structure.</param>
	/// <returns>
	/// <para>If the function succeeds, the return value is <c>TRUE</c>.</para>
	/// <para>If the function fails, the return value is <c>FALSE</c>. To retrieve extended error information, call GetLastError.</para>
	/// </returns>
	/// <remarks>
	/// <para>
	/// The <c>SymGetSymFromAddr64</c> function locates the symbol for a specified address. The modules are searched for the one the
	/// address belongs to. When the module is found, its symbol table is searched for a match. When the symbol is found, the symbol
	/// information is copied into the Symbol buffer provided by the caller. The caller must allocate the Symbol buffer properly and
	/// fill in the required parameters in the IMAGEHLP_SYMBOL64 structure before calling <c>SymGetSymFromAddr64</c>.
	/// </para>
	/// <para>
	/// All DbgHelp functions, such as this one, are single threaded. Therefore, calls from more than one thread to this function will
	/// likely result in unexpected behavior or memory corruption. To avoid this, you must synchronize all concurrent calls from more
	/// than one thread to this function.
	/// </para>
	/// <para>
	/// This function supersedes the <c>SymGetSymFromAddr</c> function. For more information, see Updated Platform Support.
	/// <c>SymGetSymFromAddr</c> is defined as follows in Dbghelp.h.
	/// </para>
	/// <para>
	/// <code>#if !defined(_IMAGEHLP_SOURCE_) &amp;&amp; defined(_IMAGEHLP64) #define SymGetSymFromAddr SymGetSymFromAddr64 #else BOOL IMAGEAPI SymGetSymFromAddr( __in HANDLE hProcess, __in DWORD dwAddr, __out_opt PDWORD pdwDisplacement, __inout PIMAGEHLP_SYMBOL Symbol ); #endif</code>
	/// </para>
	/// </remarks>
	// https://docs.microsoft.com/en-us/windows/win32/api/dbghelp/nf-dbghelp-symgetsymfromaddr64 BOOL IMAGEAPI SymGetSymFromAddr64(
	// HANDLE hProcess, DWORD64 qwAddr, PDWORD64 pdwDisplacement, PIMAGEHLP_SYMBOL64 Symbol );
	[DllImport(Lib_DbgHelp, SetLastError = true, ExactSpelling = true, CharSet = CharSet.Ansi)]
	[PInvokeData("dbghelp.h", MSDNShortId = "NF:dbghelp.SymGetSymFromAddr64")]
	[return: MarshalAs(UnmanagedType.Bool)]
	public static extern bool SymGetSymFromAddr64(HPROCESS hProcess, ulong qwAddr, out ulong pdwDisplacement, SafeIMAGEHLP_SYMBOL64 Symbol);

	/// <summary>
	/// <para>Locates a symbol for the specified name.</para>
	/// <para><c>Note</c> This function is provided only for compatibility. Applications should use SymFromName.</para>
	/// </summary>
	/// <param name="hProcess">A handle to the process that was originally passed to the SymInitialize function.</param>
	/// <param name="Name">The symbol name for which a symbol is to be located.</param>
	/// <param name="Symbol">A pointer to an IMAGEHLP_SYMBOL64 structure.</param>
	/// <returns>
	/// <para>If the function succeeds, the return value is <c>TRUE</c>.</para>
	/// <para>If the function fails, the return value is <c>FALSE</c>. To retrieve extended error information, call GetLastError.</para>
	/// </returns>
	/// <remarks>
	/// <para>
	/// The <c>SymGetSymFromName64</c> function is used to locate a symbol for a specified name. The name can contain a module prefix
	/// that isolates the symbol search to a single module's symbol table.
	/// </para>
	/// <para>
	/// The module prefix is in the form of "module!". The "!" character is the delimiter between the module name and the symbol name.
	/// If there is no module prefix, then the search is performed on each module's symbol table in a linear manner, beginning with the
	/// first module that is loaded.
	/// </para>
	/// <para>
	/// Using the module prefix is preferable for two reasons. First, the symbol search occurs much faster. Second, when deferred symbol
	/// loading is turned on, the search causes symbols to be loaded for each module that is searched. When the symbol is found, the
	/// symbol information is copied into the Symbol buffer provided by the caller. The caller must allocate the Symbol buffer properly
	/// and fill in the required parameters in the IMAGEHLP_SYMBOL64 structure before calling <c>SymGetSymFromName64</c>.
	/// </para>
	/// <para>
	/// All DbgHelp functions, such as this one, are single threaded. Therefore, calls from more than one thread to this function will
	/// likely result in unexpected behavior or memory corruption. To avoid this, you must synchronize all concurrent calls from more
	/// than one thread to this function.
	/// </para>
	/// <para>
	/// This function supersedes the <c>SymGetSymFromName</c> function. For more information, see Updated Platform Support.
	/// <c>SymGetSymFromName</c> is defined as follows in Dbghelp.h.
	/// </para>
	/// <para>
	/// <code>#if !defined(_IMAGEHLP_SOURCE_) &amp;&amp; defined(_IMAGEHLP64) #define SymGetSymFromName SymGetSymFromName64 #else BOOL IMAGEAPI SymGetSymFromName( __in HANDLE hProcess, __in PCSTR Name, __inout PIMAGEHLP_SYMBOL Symbol ); #endif</code>
	/// </para>
	/// </remarks>
	// https://docs.microsoft.com/en-us/windows/win32/api/dbghelp/nf-dbghelp-symgetsymfromname BOOL IMAGEAPI SymGetSymFromName( HANDLE
	// hProcess, PCSTR Name, PIMAGEHLP_SYMBOL Symbol );
	[DllImport(Lib_DbgHelp, SetLastError = true, ExactSpelling = true, CharSet = CharSet.Ansi)]
	[PInvokeData("dbghelp.h", MSDNShortId = "NF:dbghelp.SymGetSymFromName")]
	[return: MarshalAs(UnmanagedType.Bool)]
	public static extern bool SymGetSymFromName(HPROCESS hProcess, [MarshalAs(UnmanagedType.LPStr)] string Name, SafeIMAGEHLP_SYMBOL Symbol);

	/// <summary>
	/// <para>Locates a symbol for the specified name.</para>
	/// <para><c>Note</c> This function is provided only for compatibility. Applications should use SymFromName.</para>
	/// </summary>
	/// <param name="hProcess">A handle to the process that was originally passed to the SymInitialize function.</param>
	/// <param name="Name">The symbol name for which a symbol is to be located.</param>
	/// <param name="Symbol">A pointer to an IMAGEHLP_SYMBOL64 structure.</param>
	/// <returns>
	/// <para>If the function succeeds, the return value is <c>TRUE</c>.</para>
	/// <para>If the function fails, the return value is <c>FALSE</c>. To retrieve extended error information, call GetLastError.</para>
	/// </returns>
	/// <remarks>
	/// <para>
	/// The <c>SymGetSymFromName64</c> function is used to locate a symbol for a specified name. The name can contain a module prefix
	/// that isolates the symbol search to a single module's symbol table.
	/// </para>
	/// <para>
	/// The module prefix is in the form of "module!". The "!" character is the delimiter between the module name and the symbol name.
	/// If there is no module prefix, then the search is performed on each module's symbol table in a linear manner, beginning with the
	/// first module that is loaded.
	/// </para>
	/// <para>
	/// Using the module prefix is preferable for two reasons. First, the symbol search occurs much faster. Second, when deferred symbol
	/// loading is turned on, the search causes symbols to be loaded for each module that is searched. When the symbol is found, the
	/// symbol information is copied into the Symbol buffer provided by the caller. The caller must allocate the Symbol buffer properly
	/// and fill in the required parameters in the IMAGEHLP_SYMBOL64 structure before calling <c>SymGetSymFromName64</c>.
	/// </para>
	/// <para>
	/// All DbgHelp functions, such as this one, are single threaded. Therefore, calls from more than one thread to this function will
	/// likely result in unexpected behavior or memory corruption. To avoid this, you must synchronize all concurrent calls from more
	/// than one thread to this function.
	/// </para>
	/// <para>
	/// This function supersedes the <c>SymGetSymFromName</c> function. For more information, see Updated Platform Support.
	/// <c>SymGetSymFromName</c> is defined as follows in Dbghelp.h.
	/// </para>
	/// <para>
	/// <code>#if !defined(_IMAGEHLP_SOURCE_) &amp;&amp; defined(_IMAGEHLP64) #define SymGetSymFromName SymGetSymFromName64 #else BOOL IMAGEAPI SymGetSymFromName( __in HANDLE hProcess, __in PCSTR Name, __inout PIMAGEHLP_SYMBOL Symbol ); #endif</code>
	/// </para>
	/// </remarks>
	// https://docs.microsoft.com/en-us/windows/win32/api/dbghelp/nf-dbghelp-symgetsymfromname64 BOOL IMAGEAPI SymGetSymFromName64(
	// HANDLE hProcess, PCSTR Name, PIMAGEHLP_SYMBOL64 Symbol );
	[DllImport(Lib_DbgHelp, SetLastError = true, ExactSpelling = true, CharSet = CharSet.Ansi)]
	[PInvokeData("dbghelp.h", MSDNShortId = "NF:dbghelp.SymGetSymFromName64")]
	[return: MarshalAs(UnmanagedType.Bool)]
	public static extern bool SymGetSymFromName64(HPROCESS hProcess, [MarshalAs(UnmanagedType.LPStr)] string Name, SafeIMAGEHLP_SYMBOL64 Symbol);

	/// <summary>
	/// <para>Retrieves the symbol information for the next symbol.</para>
	/// <para><c>Note</c> This function is provided only for compatibility. Applications should use SymNext.</para>
	/// </summary>
	/// <param name="hProcess">A handle to the process that was originally passed to the SymInitialize function.</param>
	/// <param name="Symbol">A pointer to an IMAGEHLP_SYMBOL64 structure.</param>
	/// <returns>
	/// <para>If the function succeeds, the return value is <c>TRUE</c>.</para>
	/// <para>If the function fails, the return value is <c>FALSE</c>. To retrieve extended error information, call GetLastError.</para>
	/// </returns>
	/// <remarks>
	/// <para>
	/// The <c>SymGetSymNext64</c> function requires that the IMAGEHLP_SYMBOL64 structure have valid data, presumably obtained from a
	/// call to the SymGetSymFromAddr64 or SymGetSymFromName64 function. This structure is filled with the symbol information for the
	/// next symbol in sequence by virtual address.
	/// </para>
	/// <para>
	/// All DbgHelp functions, such as this one, are single threaded. Therefore, calls from more than one thread to this function will
	/// likely result in unexpected behavior or memory corruption. To avoid this, you must synchronize all concurrent calls from more
	/// than one thread to this function.
	/// </para>
	/// <para>
	/// To call the Unicode version of this function, define <c>DBGHELP_TRANSLATE_TCHAR</c>. <c>SymGetSymNextW64</c> is defined as
	/// follows in DbgHelp.h.
	/// </para>
	/// <para>
	/// <code>BOOL IMAGEAPI SymGetSymNextW64( __in HANDLE hProcess, __inout PIMAGEHLP_SYMBOLW64 Symbol );</code>
	/// </para>
	/// <para>
	/// This function supersedes the <c>SymGetSymNext</c> function. For more information, see Updated Platform Support.
	/// <c>SymGetSymNext</c> is defined as follows in DbgHelp.h.
	/// </para>
	/// <para>
	/// <code>#if !defined(_IMAGEHLP_SOURCE_) &amp;&amp; defined(_IMAGEHLP64) #define SymGetSymNext SymGetSymNext64 #define SymGetSymNextW SymGetSymNextW64 #else BOOL IMAGEAPI SymGetSymNext( __in HANDLE hProcess, __inout PIMAGEHLP_SYMBOL Symbol ); BOOL IMAGEAPI SymGetSymNextW( __in HANDLE hProcess, __inout PIMAGEHLP_SYMBOLW Symbol ); #endif</code>
	/// </para>
	/// </remarks>
	// https://docs.microsoft.com/en-us/windows/win32/api/dbghelp/nf-dbghelp-symgetsymnext BOOL IMAGEAPI SymGetSymNext( HANDLE hProcess,
	// PIMAGEHLP_SYMBOL Symbol );
	[DllImport(Lib_DbgHelp, SetLastError = true, CharSet = CharSet.Auto)]
	[PInvokeData("dbghelp.h", MSDNShortId = "NF:dbghelp.SymGetSymNext")]
	[return: MarshalAs(UnmanagedType.Bool)]
	public static extern bool SymGetSymNext(HPROCESS hProcess, SafeIMAGEHLP_SYMBOL Symbol);

	/// <summary>
	/// <para>Retrieves the symbol information for the next symbol.</para>
	/// <para><c>Note</c> This function is provided only for compatibility. Applications should use SymNext.</para>
	/// </summary>
	/// <param name="hProcess">A handle to the process that was originally passed to the SymInitialize function.</param>
	/// <param name="Symbol">A pointer to an IMAGEHLP_SYMBOL64 structure.</param>
	/// <returns>
	/// <para>If the function succeeds, the return value is <c>TRUE</c>.</para>
	/// <para>If the function fails, the return value is <c>FALSE</c>. To retrieve extended error information, call GetLastError.</para>
	/// </returns>
	/// <remarks>
	/// <para>
	/// The <c>SymGetSymNext64</c> function requires that the IMAGEHLP_SYMBOL64 structure have valid data, presumably obtained from a
	/// call to the SymGetSymFromAddr64 or SymGetSymFromName64 function. This structure is filled with the symbol information for the
	/// next symbol in sequence by virtual address.
	/// </para>
	/// <para>
	/// All DbgHelp functions, such as this one, are single threaded. Therefore, calls from more than one thread to this function will
	/// likely result in unexpected behavior or memory corruption. To avoid this, you must synchronize all concurrent calls from more
	/// than one thread to this function.
	/// </para>
	/// <para>
	/// To call the Unicode version of this function, define <c>DBGHELP_TRANSLATE_TCHAR</c>. <c>SymGetSymNextW64</c> is defined as
	/// follows in DbgHelp.h.
	/// </para>
	/// <para>
	/// <code>BOOL IMAGEAPI SymGetSymNextW64( __in HANDLE hProcess, __inout PIMAGEHLP_SYMBOLW64 Symbol );</code>
	/// </para>
	/// <para>
	/// This function supersedes the <c>SymGetSymNext</c> function. For more information, see Updated Platform Support.
	/// <c>SymGetSymNext</c> is defined as follows in DbgHelp.h.
	/// </para>
	/// <para>
	/// <code>#if !defined(_IMAGEHLP_SOURCE_) &amp;&amp; defined(_IMAGEHLP64) #define SymGetSymNext SymGetSymNext64 #define SymGetSymNextW SymGetSymNextW64 #else BOOL IMAGEAPI SymGetSymNext( __in HANDLE hProcess, __inout PIMAGEHLP_SYMBOL Symbol ); BOOL IMAGEAPI SymGetSymNextW( __in HANDLE hProcess, __inout PIMAGEHLP_SYMBOLW Symbol ); #endif</code>
	/// </para>
	/// </remarks>
	// https://docs.microsoft.com/en-us/windows/win32/api/dbghelp/nf-dbghelp-symgetsymnext64 BOOL IMAGEAPI SymGetSymNext64( HANDLE
	// hProcess, PIMAGEHLP_SYMBOL64 Symbol );
	[DllImport(Lib_DbgHelp, SetLastError = true, CharSet = CharSet.Ansi, ExactSpelling = true)]
	[PInvokeData("dbghelp.h", MSDNShortId = "NF:dbghelp.SymGetSymNext64")]
	[return: MarshalAs(UnmanagedType.Bool)]
	public static extern bool SymGetSymNext64(HPROCESS hProcess, SafeIMAGEHLP_SYMBOL64 Symbol);

	/// <summary>
	/// <para>Retrieves the symbol information for the next symbol.</para>
	/// <para><c>Note</c> This function is provided only for compatibility. Applications should use SymNext.</para>
	/// </summary>
	/// <param name="hProcess">A handle to the process that was originally passed to the SymInitialize function.</param>
	/// <param name="Symbol">A pointer to an IMAGEHLP_SYMBOL64 structure.</param>
	/// <returns>
	/// <para>If the function succeeds, the return value is <c>TRUE</c>.</para>
	/// <para>If the function fails, the return value is <c>FALSE</c>. To retrieve extended error information, call GetLastError.</para>
	/// </returns>
	/// <remarks>
	/// <para>
	/// The <c>SymGetSymNext64</c> function requires that the IMAGEHLP_SYMBOL64 structure have valid data, presumably obtained from a
	/// call to the SymGetSymFromAddr64 or SymGetSymFromName64 function. This structure is filled with the symbol information for the
	/// next symbol in sequence by virtual address.
	/// </para>
	/// <para>
	/// All DbgHelp functions, such as this one, are single threaded. Therefore, calls from more than one thread to this function will
	/// likely result in unexpected behavior or memory corruption. To avoid this, you must synchronize all concurrent calls from more
	/// than one thread to this function.
	/// </para>
	/// <para>
	/// To call the Unicode version of this function, define <c>DBGHELP_TRANSLATE_TCHAR</c>. <c>SymGetSymNextW64</c> is defined as
	/// follows in DbgHelp.h.
	/// </para>
	/// <para>
	/// <code>BOOL IMAGEAPI SymGetSymNextW64( __in HANDLE hProcess, __inout PIMAGEHLP_SYMBOLW64 Symbol );</code>
	/// </para>
	/// <para>
	/// This function supersedes the <c>SymGetSymNext</c> function. For more information, see Updated Platform Support.
	/// <c>SymGetSymNext</c> is defined as follows in DbgHelp.h.
	/// </para>
	/// <para>
	/// <code>#if !defined(_IMAGEHLP_SOURCE_) &amp;&amp; defined(_IMAGEHLP64) #define SymGetSymNext SymGetSymNext64 #define SymGetSymNextW SymGetSymNextW64 #else BOOL IMAGEAPI SymGetSymNext( __in HANDLE hProcess, __inout PIMAGEHLP_SYMBOL Symbol ); BOOL IMAGEAPI SymGetSymNextW( __in HANDLE hProcess, __inout PIMAGEHLP_SYMBOLW Symbol ); #endif</code>
	/// </para>
	/// </remarks>
	// https://docs.microsoft.com/en-us/windows/win32/api/dbghelp/nf-dbghelp-symgetsymnext64 BOOL IMAGEAPI SymGetSymNext64( HANDLE
	// hProcess, PIMAGEHLP_SYMBOL64 Symbol );
	[DllImport(Lib_DbgHelp, SetLastError = true, CharSet = CharSet.Unicode, ExactSpelling = true)]
	[PInvokeData("dbghelp.h", MSDNShortId = "NF:dbghelp.SymGetSymNext64")]
	[return: MarshalAs(UnmanagedType.Bool)]
	public static extern bool SymGetSymNextW64(HPROCESS hProcess, SafeIMAGEHLP_SYMBOL64 Symbol);

	/// <summary>
	/// <para>Retrieves the symbol information for the previous symbol.</para>
	/// <para><c>Note</c> This function is provided only for compatibility. Applications should use SymPrev.</para>
	/// </summary>
	/// <param name="hProcess">A handle to the process that was originally passed to the SymInitialize function.</param>
	/// <param name="Symbol">A pointer to an IMAGEHLP_SYMBOL64 structure.</param>
	/// <returns>
	/// <para>If the function succeeds, the return value is <c>TRUE</c>.</para>
	/// <para>If the function fails, the return value is <c>FALSE</c>. To retrieve extended error information, call GetLastError.</para>
	/// </returns>
	/// <remarks>
	/// <para>
	/// The <c>SymGetSymPrev64</c> function requires the IMAGEHLP_SYMBOL64 structure to have valid data, presumably obtained from a call
	/// to the SymGetSymFromAddr64 or SymGetSymFromName64 function. This structure is filled in with the symbol information for the
	/// previous symbol in sequence by virtual address.
	/// </para>
	/// <para>
	/// All DbgHelp functions, such as this one, are single threaded. Therefore, calls from more than one thread to this function will
	/// likely result in unexpected behavior or memory corruption. To avoid this, you must synchronize all concurrent calls from more
	/// than one thread to this function.
	/// </para>
	/// <para>
	/// To call the Unicode version of this function, define DBGHELP_TRANSLATE_TCHAR. <c>SymGetSymPrevW64</c> is defined as follows in DbgHelp.h.
	/// </para>
	/// <para>
	/// <code>BOOL IMAGEAPI SymGetSymPrevW64( __in HANDLE hProcess, __inout PIMAGEHLP_SYMBOLW64 Symbol );</code>
	/// </para>
	/// <para>
	/// This function supersedes the <c>SymGetSymPrev</c> function. For more information, see Updated Platform Support.
	/// <c>SymGetSymPrev</c> is defined as follows in Dbghelp.h.
	/// </para>
	/// <para>
	/// <code>#if !defined(_IMAGEHLP_SOURCE_) &amp;&amp; defined(_IMAGEHLP64) #define SymGetSymPrev SymGetSymPrev64 #define SymGetSymPrevW SymGetSymPrevW64 #else BOOL IMAGEAPI SymGetSymPrev( __in HANDLE hProcess, __inout PIMAGEHLP_SYMBOL Symbol ); BOOL IMAGEAPI SymGetSymPrevW( __in HANDLE hProcess, __inout PIMAGEHLP_SYMBOLW Symbol ); #endif</code>
	/// </para>
	/// </remarks>
	// https://docs.microsoft.com/en-us/windows/win32/api/dbghelp/nf-dbghelp-symgetsymprev BOOL IMAGEAPI SymGetSymPrev( HANDLE hProcess,
	// PIMAGEHLP_SYMBOL Symbol );
	[DllImport(Lib_DbgHelp, SetLastError = true, CharSet = CharSet.Unicode)]
	[PInvokeData("dbghelp.h", MSDNShortId = "NF:dbghelp.SymGetSymPrev")]
	[return: MarshalAs(UnmanagedType.Bool)]
	public static extern bool SymGetSymPrev(HPROCESS hProcess, SafeIMAGEHLP_SYMBOL Symbol);

	/// <summary>
	/// <para>Retrieves the symbol information for the previous symbol.</para>
	/// <para><c>Note</c> This function is provided only for compatibility. Applications should use SymPrev.</para>
	/// </summary>
	/// <param name="hProcess">A handle to the process that was originally passed to the SymInitialize function.</param>
	/// <param name="Symbol">A pointer to an IMAGEHLP_SYMBOL64 structure.</param>
	/// <returns>
	/// <para>If the function succeeds, the return value is <c>TRUE</c>.</para>
	/// <para>If the function fails, the return value is <c>FALSE</c>. To retrieve extended error information, call GetLastError.</para>
	/// </returns>
	/// <remarks>
	/// <para>
	/// The <c>SymGetSymPrev64</c> function requires the IMAGEHLP_SYMBOL64 structure to have valid data, presumably obtained from a call
	/// to the SymGetSymFromAddr64 or SymGetSymFromName64 function. This structure is filled in with the symbol information for the
	/// previous symbol in sequence by virtual address.
	/// </para>
	/// <para>
	/// All DbgHelp functions, such as this one, are single threaded. Therefore, calls from more than one thread to this function will
	/// likely result in unexpected behavior or memory corruption. To avoid this, you must synchronize all concurrent calls from more
	/// than one thread to this function.
	/// </para>
	/// <para>
	/// To call the Unicode version of this function, define DBGHELP_TRANSLATE_TCHAR. <c>SymGetSymPrevW64</c> is defined as follows in DbgHelp.h.
	/// </para>
	/// <para>
	/// <code>BOOL IMAGEAPI SymGetSymPrevW64( __in HANDLE hProcess, __inout PIMAGEHLP_SYMBOLW64 Symbol );</code>
	/// </para>
	/// <para>
	/// This function supersedes the <c>SymGetSymPrev</c> function. For more information, see Updated Platform Support.
	/// <c>SymGetSymPrev</c> is defined as follows in Dbghelp.h.
	/// </para>
	/// <para>
	/// <code>#if !defined(_IMAGEHLP_SOURCE_) &amp;&amp; defined(_IMAGEHLP64) #define SymGetSymPrev SymGetSymPrev64 #define SymGetSymPrevW SymGetSymPrevW64 #else BOOL IMAGEAPI SymGetSymPrev( __in HANDLE hProcess, __inout PIMAGEHLP_SYMBOL Symbol ); BOOL IMAGEAPI SymGetSymPrevW( __in HANDLE hProcess, __inout PIMAGEHLP_SYMBOLW Symbol ); #endif</code>
	/// </para>
	/// </remarks>
	// https://docs.microsoft.com/en-us/windows/win32/api/dbghelp/nf-dbghelp-symgetsymprev64 BOOL IMAGEAPI SymGetSymPrev64( HANDLE
	// hProcess, PIMAGEHLP_SYMBOL64 Symbol );
	[DllImport(Lib_DbgHelp, SetLastError = true, CharSet = CharSet.Ansi, ExactSpelling = true)]
	[PInvokeData("dbghelp.h", MSDNShortId = "NF:dbghelp.SymGetSymPrev64")]
	[return: MarshalAs(UnmanagedType.Bool)]
	public static extern bool SymGetSymPrev64(HPROCESS hProcess, SafeIMAGEHLP_SYMBOL64 Symbol);

	/// <summary>
	/// <para>Retrieves the symbol information for the previous symbol.</para>
	/// <para><c>Note</c> This function is provided only for compatibility. Applications should use SymPrev.</para>
	/// </summary>
	/// <param name="hProcess">A handle to the process that was originally passed to the SymInitialize function.</param>
	/// <param name="Symbol">A pointer to an IMAGEHLP_SYMBOL64 structure.</param>
	/// <returns>
	/// <para>If the function succeeds, the return value is <c>TRUE</c>.</para>
	/// <para>If the function fails, the return value is <c>FALSE</c>. To retrieve extended error information, call GetLastError.</para>
	/// </returns>
	/// <remarks>
	/// <para>
	/// The <c>SymGetSymPrev64</c> function requires the IMAGEHLP_SYMBOL64 structure to have valid data, presumably obtained from a call
	/// to the SymGetSymFromAddr64 or SymGetSymFromName64 function. This structure is filled in with the symbol information for the
	/// previous symbol in sequence by virtual address.
	/// </para>
	/// <para>
	/// All DbgHelp functions, such as this one, are single threaded. Therefore, calls from more than one thread to this function will
	/// likely result in unexpected behavior or memory corruption. To avoid this, you must synchronize all concurrent calls from more
	/// than one thread to this function.
	/// </para>
	/// <para>
	/// To call the Unicode version of this function, define DBGHELP_TRANSLATE_TCHAR. <c>SymGetSymPrevW64</c> is defined as follows in DbgHelp.h.
	/// </para>
	/// <para>
	/// <code>BOOL IMAGEAPI SymGetSymPrevW64( __in HANDLE hProcess, __inout PIMAGEHLP_SYMBOLW64 Symbol );</code>
	/// </para>
	/// <para>
	/// This function supersedes the <c>SymGetSymPrev</c> function. For more information, see Updated Platform Support.
	/// <c>SymGetSymPrev</c> is defined as follows in Dbghelp.h.
	/// </para>
	/// <para>
	/// <code>#if !defined(_IMAGEHLP_SOURCE_) &amp;&amp; defined(_IMAGEHLP64) #define SymGetSymPrev SymGetSymPrev64 #define SymGetSymPrevW SymGetSymPrevW64 #else BOOL IMAGEAPI SymGetSymPrev( __in HANDLE hProcess, __inout PIMAGEHLP_SYMBOL Symbol ); BOOL IMAGEAPI SymGetSymPrevW( __in HANDLE hProcess, __inout PIMAGEHLP_SYMBOLW Symbol ); #endif</code>
	/// </para>
	/// </remarks>
	// https://docs.microsoft.com/en-us/windows/win32/api/dbghelp/nf-dbghelp-symgetsymprev64 BOOL IMAGEAPI SymGetSymPrev64( HANDLE
	// hProcess, PIMAGEHLP_SYMBOL64 Symbol );
	[DllImport(Lib_DbgHelp, SetLastError = true, CharSet = CharSet.Unicode, ExactSpelling = true)]
	[PInvokeData("dbghelp.h", MSDNShortId = "NF:dbghelp.SymGetSymPrev64")]
	[return: MarshalAs(UnmanagedType.Bool)]
	public static extern bool SymGetSymPrevW64(HPROCESS hProcess, SafeIMAGEHLP_SYMBOL64 Symbol);

	/// <summary>Retrieves a type index for the specified type name.</summary>
	/// <param name="hProcess">A handle to a process. This handle must have been previously passed to the SymInitialize function.</param>
	/// <param name="BaseOfDll">The base address of the module.</param>
	/// <param name="Name">The name of the type.</param>
	/// <param name="Symbol">A pointer to a SYMBOL_INFO structure. The <c>TypeIndex</c> member contains the type index.</param>
	/// <returns>
	/// <para>If the function succeeds, the return value is <c>TRUE</c>.</para>
	/// <para>If the function fails, the return value is <c>FALSE</c>. To retrieve extended error information, call GetLastError.</para>
	/// </returns>
	/// <remarks>
	/// <para>To retrieve information about the type, pass the type index to the SymGetTypeInfo function.</para>
	/// <para>
	/// All DbgHelp functions, such as this one, are single threaded. Therefore, calls from more than one thread to this function will
	/// likely result in unexpected behavior or memory corruption. To avoid this, you must synchronize all concurrent calls from more
	/// than one thread to this function.
	/// </para>
	/// <para>To call the Unicode version of this function, define DBGHELP_TRANSLATE_TCHAR.</para>
	/// </remarks>
	// https://docs.microsoft.com/en-us/windows/win32/api/dbghelp/nf-dbghelp-symgettypefromname BOOL IMAGEAPI SymGetTypeFromName( HANDLE
	// hProcess, ULONG64 BaseOfDll, PCSTR Name, PSYMBOL_INFO Symbol );
	[DllImport(Lib_DbgHelp, SetLastError = true, CharSet = CharSet.Auto)]
	[PInvokeData("dbghelp.h", MSDNShortId = "NF:dbghelp.SymGetTypeFromName")]
	[return: MarshalAs(UnmanagedType.Bool)]
	public static extern bool SymGetTypeFromName(HPROCESS hProcess, ulong BaseOfDll, [MarshalAs(UnmanagedType.LPTStr)] string Name, ref SYMBOL_INFO Symbol);

	/// <summary>Retrieves type information for the specified type index. For larger queries, use the SymGetTypeInfoEx function.</summary>
	/// <param name="hProcess">A handle to a process. This handle must have been previously passed to the SymInitialize function.</param>
	/// <param name="ModBase">The base address of the module.</param>
	/// <param name="TypeId">
	/// The type index. (A number of functions return a type index in the <c>TypeIndex</c> member of the SYMBOL_INFO structure.)
	/// </param>
	/// <param name="GetType">
	/// The information type. This parameter can be one of more of the values from the IMAGEHLP_SYMBOL_TYPE_INFO enumeration type.
	/// </param>
	/// <param name="pInfo">The data. The format of the data depends on the value of the GetType parameter.</param>
	/// <returns>
	/// <para>If the function succeeds, the return value is <c>TRUE</c>.</para>
	/// <para>If the function fails, the return value is <c>FALSE</c>. To retrieve extended error information, call GetLastError.</para>
	/// </returns>
	/// <remarks>
	/// <para>For more details on the type information, see the documentation for the PDB format.</para>
	/// <para>
	/// All DbgHelp functions, such as this one, are single threaded. Therefore, calls from more than one thread to this function will
	/// likely result in unexpected behavior or memory corruption. To avoid this, you must synchronize all concurrent calls from more
	/// than one thread to this function.
	/// </para>
	/// </remarks>
	// https://docs.microsoft.com/en-us/windows/win32/api/dbghelp/nf-dbghelp-symgettypeinfo BOOL IMAGEAPI SymGetTypeInfo( HANDLE
	// hProcess, DWORD64 ModBase, ULONG TypeId, IMAGEHLP_SYMBOL_TYPE_INFO GetType, PVOID pInfo );
	[DllImport(Lib_DbgHelp, SetLastError = true, ExactSpelling = true)]
	[PInvokeData("dbghelp.h", MSDNShortId = "NF:dbghelp.SymGetTypeInfo")]
	[return: MarshalAs(UnmanagedType.Bool)]
	public static extern bool SymGetTypeInfo(HPROCESS hProcess, ulong ModBase, uint TypeId, IMAGEHLP_SYMBOL_TYPE_INFO GetType, [Out] IntPtr pInfo);

	/// <summary>Retrieves multiple pieces of type information.</summary>
	/// <param name="hProcess">A handle to a process. This handle must have been previously passed to the SymInitialize function.</param>
	/// <param name="ModBase">The base address of the module.</param>
	/// <param name="Params">
	/// A pointer to an IMAGEHLP_GET_TYPE_INFO_PARAMS structure that specifies input and output information for the query.
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
	// https://docs.microsoft.com/en-us/windows/win32/api/dbghelp/nf-dbghelp-symgettypeinfoex BOOL IMAGEAPI SymGetTypeInfoEx( HANDLE
	// hProcess, DWORD64 ModBase, PIMAGEHLP_GET_TYPE_INFO_PARAMS Params );
	[DllImport(Lib_DbgHelp, SetLastError = true, ExactSpelling = true)]
	[PInvokeData("dbghelp.h", MSDNShortId = "NF:dbghelp.SymGetTypeInfoEx")]
	[return: MarshalAs(UnmanagedType.Bool)]
	public static extern bool SymGetTypeInfoEx(HPROCESS hProcess, ulong ModBase, ref IMAGEHLP_GET_TYPE_INFO_PARAMS Params);

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
	public static extern bool SymInitialize(HPROCESS hProcess, [Optional, MarshalAs(UnmanagedType.LPTStr)] string? UserSearchPath, [MarshalAs(UnmanagedType.Bool)] bool fInvadeProcess);

	/// <summary>
	/// <para>Loads the symbol table.</para>
	/// <para>This function has been superseded by the SymLoadModuleEx function.</para>
	/// </summary>
	/// <param name="hProcess">A handle to the process. This handle must have been previously passed to the SymInitialize function.</param>
	/// <param name="hFile">
	/// A handle to the file for the executable image. This argument is used mostly by debuggers, where the debugger passes the file
	/// handle obtained from a debugging event. A value of <c>NULL</c> indicates that hFile is not used.
	/// </param>
	/// <param name="ImageName">
	/// The name of the executable image. This name can contain a partial path, a full path, or no path at all. If the file cannot be
	/// located by the name provided, the symbol search path is used.
	/// </param>
	/// <param name="ModuleName">
	/// A shortcut name for the module. If the pointer value is <c>NULL</c>, the library creates a name using the base name of the
	/// symbol file.
	/// </param>
	/// <param name="BaseOfDll">
	/// <para>
	/// The load address of the module. If the value is zero, the library obtains the load address from the symbol file. The load
	/// address contained in the symbol file is not necessarily the actual load address. Debuggers and other applications having an
	/// actual load address should use the real load address when calling this function.
	/// </para>
	/// <para>If the image is a .pdb file, this parameter cannot be zero.</para>
	/// </param>
	/// <param name="SizeOfDll">
	/// <para>
	/// The size of the module, in bytes. If the value is zero, the library obtains the size from the symbol file. The size contained in
	/// the symbol file is not necessarily the actual size. Debuggers and other applications having an actual size should use the real
	/// size when calling this function.
	/// </para>
	/// <para>If the image is a .pdb file, this parameter cannot be zero.</para>
	/// </param>
	/// <returns>
	/// <para>If the function succeeds, the return value is the base address of the loaded module.</para>
	/// <para>If the function fails, the return value is zero. To retrieve extended error information, call GetLastError.</para>
	/// <para>If the module is already loaded, the return value is zero and GetLastError returns <c>ERROR_SUCCESS</c>.</para>
	/// </returns>
	/// <remarks>
	/// <para>
	/// The symbol handler creates an entry for the module and if the deferred symbol loading option is turned off, an attempt is made
	/// to load the symbols. If deferred symbol loading is enabled, the module is marked as deferred and the symbols are not loaded
	/// until a reference is made to a symbol in the module.
	/// </para>
	/// <para>To unload the symbol table, use the SymUnloadModule64 function.</para>
	/// <para>
	/// All DbgHelp functions, such as this one, are single threaded. Therefore, calls from more than one thread to this function will
	/// likely result in unexpected behavior or memory corruption. To avoid this, you must synchronize all concurrent calls from more
	/// than one thread to this function.
	/// </para>
	/// <para>
	/// This function supersedes the <c>SymLoadModule</c> function. For more information, see Updated Platform Support.
	/// <c>SymLoadModule</c> is defined as follows in DbgHelp.h.
	/// </para>
	/// <para>
	/// <code>#if !defined(_IMAGEHLP_SOURCE_) &amp;&amp; defined(_IMAGEHLP64) #define SymLoadModule SymLoadModule64 #else DWORD IMAGEAPI SymLoadModule( __in HANDLE hProcess, __in_opt HANDLE hFile, __in_opt PCSTR ImageName, __in_opt PCSTR ModuleName, __in DWORD BaseOfDll, __in DWORD SizeOfDll ); #endif</code>
	/// </para>
	/// </remarks>
	// https://docs.microsoft.com/en-us/windows/win32/api/dbghelp/nf-dbghelp-symloadmodule DWORD IMAGEAPI SymLoadModule( HANDLE
	// hProcess, HANDLE hFile, PCSTR ImageName, PCSTR ModuleName, DWORD BaseOfDll, DWORD SizeOfDll );
	[DllImport(Lib_DbgHelp, SetLastError = true, ExactSpelling = true)]
	[PInvokeData("dbghelp.h", MSDNShortId = "NF:dbghelp.SymLoadModule")]
	public static extern uint SymLoadModule(HPROCESS hProcess, [Optional] HFILE hFile, [Optional, MarshalAs(UnmanagedType.LPStr)] string? ImageName,
		[Optional, MarshalAs(UnmanagedType.LPWStr)] string? ModuleName, uint BaseOfDll, uint SizeOfDll);

	/// <summary>
	/// <para>Loads the symbol table.</para>
	/// <para>This function has been superseded by the SymLoadModuleEx function.</para>
	/// </summary>
	/// <param name="hProcess">A handle to the process. This handle must have been previously passed to the SymInitialize function.</param>
	/// <param name="hFile">
	/// A handle to the file for the executable image. This argument is used mostly by debuggers, where the debugger passes the file
	/// handle obtained from a debugging event. A value of <c>NULL</c> indicates that hFile is not used.
	/// </param>
	/// <param name="ImageName">
	/// The name of the executable image. This name can contain a partial path, a full path, or no path at all. If the file cannot be
	/// located by the name provided, the symbol search path is used.
	/// </param>
	/// <param name="ModuleName">
	/// A shortcut name for the module. If the pointer value is <c>NULL</c>, the library creates a name using the base name of the
	/// symbol file.
	/// </param>
	/// <param name="BaseOfDll">
	/// <para>
	/// The load address of the module. If the value is zero, the library obtains the load address from the symbol file. The load
	/// address contained in the symbol file is not necessarily the actual load address. Debuggers and other applications having an
	/// actual load address should use the real load address when calling this function.
	/// </para>
	/// <para>If the image is a .pdb file, this parameter cannot be zero.</para>
	/// </param>
	/// <param name="SizeOfDll">
	/// <para>
	/// The size of the module, in bytes. If the value is zero, the library obtains the size from the symbol file. The size contained in
	/// the symbol file is not necessarily the actual size. Debuggers and other applications having an actual size should use the real
	/// size when calling this function.
	/// </para>
	/// <para>If the image is a .pdb file, this parameter cannot be zero.</para>
	/// </param>
	/// <returns>
	/// <para>If the function succeeds, the return value is the base address of the loaded module.</para>
	/// <para>If the function fails, the return value is zero. To retrieve extended error information, call GetLastError.</para>
	/// <para>If the module is already loaded, the return value is zero and GetLastError returns <c>ERROR_SUCCESS</c>.</para>
	/// </returns>
	/// <remarks>
	/// <para>
	/// The symbol handler creates an entry for the module and if the deferred symbol loading option is turned off, an attempt is made
	/// to load the symbols. If deferred symbol loading is enabled, the module is marked as deferred and the symbols are not loaded
	/// until a reference is made to a symbol in the module.
	/// </para>
	/// <para>To unload the symbol table, use the SymUnloadModule64 function.</para>
	/// <para>
	/// All DbgHelp functions, such as this one, are single threaded. Therefore, calls from more than one thread to this function will
	/// likely result in unexpected behavior or memory corruption. To avoid this, you must synchronize all concurrent calls from more
	/// than one thread to this function.
	/// </para>
	/// <para>
	/// This function supersedes the <c>SymLoadModule</c> function. For more information, see Updated Platform Support.
	/// <c>SymLoadModule</c> is defined as follows in DbgHelp.h.
	/// </para>
	/// <para>
	/// <code>#if !defined(_IMAGEHLP_SOURCE_) &amp;&amp; defined(_IMAGEHLP64) #define SymLoadModule SymLoadModule64 #else DWORD IMAGEAPI SymLoadModule( __in HANDLE hProcess, __in_opt HANDLE hFile, __in_opt PCSTR ImageName, __in_opt PCSTR ModuleName, __in DWORD BaseOfDll, __in DWORD SizeOfDll ); #endif</code>
	/// </para>
	/// </remarks>
	// https://docs.microsoft.com/en-us/windows/win32/api/dbghelp/nf-dbghelp-symloadmodule64 DWORD64 IMAGEAPI SymLoadModule64( HANDLE
	// hProcess, HANDLE hFile, PCSTR ImageName, PCSTR ModuleName, DWORD64 BaseOfDll, DWORD SizeOfDll );
	[DllImport(Lib_DbgHelp, SetLastError = true, ExactSpelling = true)]
	[PInvokeData("dbghelp.h", MSDNShortId = "NF:dbghelp.SymLoadModule64")]
	public static extern ulong SymLoadModule64(HPROCESS hProcess, [Optional] HFILE hFile, [Optional, MarshalAs(UnmanagedType.LPStr)] string? ImageName,
		[Optional, MarshalAs(UnmanagedType.LPStr)] string? ModuleName, ulong BaseOfDll, uint SizeOfDll);

	/// <summary>Loads the symbol table for the specified module.</summary>
	/// <param name="hProcess">A handle to the process that was originally passed to the SymInitialize function.</param>
	/// <param name="hFile">
	/// A handle to the file for the executable image. This argument is used mostly by debuggers, where the debugger passes the file
	/// handle obtained from a debugging event. A value of <c>NULL</c> indicates that hFile is not used.
	/// </param>
	/// <param name="ImageName">
	/// The name of the executable image. This name can contain a partial path, a full path, or no path at all. If the file cannot be
	/// located by the name provided, the symbol search path is used.
	/// </param>
	/// <param name="ModuleName">
	/// A shortcut name for the module. If the pointer value is <c>NULL</c>, the library creates a name using the base name of the
	/// symbol file.
	/// </param>
	/// <param name="BaseOfDll">
	/// <para>
	/// The load address of the module. If the value is zero, the library obtains the load address from the symbol file. The load
	/// address contained in the symbol file is not necessarily the actual load address. Debuggers and other applications having an
	/// actual load address should use the real load address when calling this function.
	/// </para>
	/// <para>If the image is a .pdb file, this parameter cannot be zero.</para>
	/// </param>
	/// <param name="DllSize">
	/// <para>
	/// The size of the module, in bytes. If the value is zero, the library obtains the size from the symbol file. The size contained in
	/// the symbol file is not necessarily the actual size. Debuggers and other applications having an actual size should use the real
	/// size when calling this function.
	/// </para>
	/// <para>If the image is a .pdb file, this parameter cannot be zero.</para>
	/// </param>
	/// <param name="Data">
	/// A pointer to a MODLOAD_DATA structure that represents headers other than the standard PE header. This parameter is optional and
	/// can be <c>NULL</c>.
	/// </param>
	/// <param name="Flags">
	/// <para>
	/// This parameter can be zero or one or more of the following values. If this parameter is zero, the function loads the modules and
	/// the symbols for the module.
	/// </para>
	/// <list type="table">
	/// <listheader>
	/// <term>Value</term>
	/// <term>Meaning</term>
	/// </listheader>
	/// <item>
	/// <term>SLMFLAG_NO_SYMBOLS 0x4</term>
	/// <term>Loads the module but not the symbols for the module.</term>
	/// </item>
	/// <item>
	/// <term>SLMFLAG_VIRTUAL 0x1</term>
	/// <term>
	/// Creates a virtual module named ModuleName at the address specified in BaseOfDll. To add symbols to this module, call the
	/// SymAddSymbol function.
	/// </term>
	/// </item>
	/// </list>
	/// </param>
	/// <returns>
	/// <para>If the function succeeds, the return value is the base address of the loaded module.</para>
	/// <para>If the function fails, the return value is zero. To retrieve extended error information, call GetLastError.</para>
	/// <para>If the module is already loaded, the return value is zero and GetLastError returns ERROR_SUCCESS.</para>
	/// </returns>
	/// <remarks>
	/// <para>
	/// The symbol handler creates an entry for the module and if the deferred symbol loading option is turned off, an attempt is made
	/// to load the symbols. If deferred symbol loading is enabled, the module is marked as deferred and the symbols are not loaded
	/// until a reference is made to a symbol in the module. Therefore, you should always call the SymGetModuleInfo64 function after
	/// calling <c>SymLoadModuleEx</c>.
	/// </para>
	/// <para>To unload the symbol table, use the SymUnloadModule64 function.</para>
	/// <para>
	/// All DbgHelp functions, such as this one, are single threaded. Therefore, calls from more than one thread to this function will
	/// likely result in unexpected behavior or memory corruption. To avoid this, you must synchronize all concurrent calls from more
	/// than one thread to this function.
	/// </para>
	/// <para>To call the Unicode version of this function, define DBGHELP_TRANSLATE_TCHAR.</para>
	/// <para>Examples</para>
	/// <para>For an example, see Loading a Symbol Module.</para>
	/// </remarks>
	// https://docs.microsoft.com/en-us/windows/win32/api/dbghelp/nf-dbghelp-symloadmoduleex DWORD64 IMAGEAPI SymLoadModuleEx( HANDLE
	// hProcess, HANDLE hFile, PCSTR ImageName, PCSTR ModuleName, DWORD64 BaseOfDll, DWORD DllSize, PMODLOAD_DATA Data, DWORD Flags );
	[DllImport(Lib_DbgHelp, SetLastError = true, CharSet = CharSet.Auto)]
	[PInvokeData("dbghelp.h", MSDNShortId = "NF:dbghelp.SymLoadModuleEx")]
	public static extern ulong SymLoadModuleEx(HPROCESS hProcess, [Optional] HFILE hFile, [Optional, MarshalAs(UnmanagedType.LPTStr)] string? ImageName,
		[Optional, MarshalAs(UnmanagedType.LPTStr)] string? ModuleName, ulong BaseOfDll, uint DllSize, in MODLOAD_DATA Data, [Optional] SLMFLAG Flags);

	/// <summary>Loads the symbol table for the specified module.</summary>
	/// <param name="hProcess">A handle to the process that was originally passed to the SymInitialize function.</param>
	/// <param name="hFile">
	/// A handle to the file for the executable image. This argument is used mostly by debuggers, where the debugger passes the file
	/// handle obtained from a debugging event. A value of <c>NULL</c> indicates that hFile is not used.
	/// </param>
	/// <param name="ImageName">
	/// The name of the executable image. This name can contain a partial path, a full path, or no path at all. If the file cannot be
	/// located by the name provided, the symbol search path is used.
	/// </param>
	/// <param name="ModuleName">
	/// A shortcut name for the module. If the pointer value is <c>NULL</c>, the library creates a name using the base name of the
	/// symbol file.
	/// </param>
	/// <param name="BaseOfDll">
	/// <para>
	/// The load address of the module. If the value is zero, the library obtains the load address from the symbol file. The load
	/// address contained in the symbol file is not necessarily the actual load address. Debuggers and other applications having an
	/// actual load address should use the real load address when calling this function.
	/// </para>
	/// <para>If the image is a .pdb file, this parameter cannot be zero.</para>
	/// </param>
	/// <param name="DllSize">
	/// <para>
	/// The size of the module, in bytes. If the value is zero, the library obtains the size from the symbol file. The size contained in
	/// the symbol file is not necessarily the actual size. Debuggers and other applications having an actual size should use the real
	/// size when calling this function.
	/// </para>
	/// <para>If the image is a .pdb file, this parameter cannot be zero.</para>
	/// </param>
	/// <param name="Data">
	/// A pointer to a MODLOAD_DATA structure that represents headers other than the standard PE header. This parameter is optional and
	/// can be <c>NULL</c>.
	/// </param>
	/// <param name="Flags">
	/// <para>
	/// This parameter can be zero or one or more of the following values. If this parameter is zero, the function loads the modules and
	/// the symbols for the module.
	/// </para>
	/// <list type="table">
	/// <listheader>
	/// <term>Value</term>
	/// <term>Meaning</term>
	/// </listheader>
	/// <item>
	/// <term>SLMFLAG_NO_SYMBOLS 0x4</term>
	/// <term>Loads the module but not the symbols for the module.</term>
	/// </item>
	/// <item>
	/// <term>SLMFLAG_VIRTUAL 0x1</term>
	/// <term>
	/// Creates a virtual module named ModuleName at the address specified in BaseOfDll. To add symbols to this module, call the
	/// SymAddSymbol function.
	/// </term>
	/// </item>
	/// </list>
	/// </param>
	/// <returns>
	/// <para>If the function succeeds, the return value is the base address of the loaded module.</para>
	/// <para>If the function fails, the return value is zero. To retrieve extended error information, call GetLastError.</para>
	/// <para>If the module is already loaded, the return value is zero and GetLastError returns ERROR_SUCCESS.</para>
	/// </returns>
	/// <remarks>
	/// <para>
	/// The symbol handler creates an entry for the module and if the deferred symbol loading option is turned off, an attempt is made
	/// to load the symbols. If deferred symbol loading is enabled, the module is marked as deferred and the symbols are not loaded
	/// until a reference is made to a symbol in the module. Therefore, you should always call the SymGetModuleInfo64 function after
	/// calling <c>SymLoadModuleEx</c>.
	/// </para>
	/// <para>To unload the symbol table, use the SymUnloadModule64 function.</para>
	/// <para>
	/// All DbgHelp functions, such as this one, are single threaded. Therefore, calls from more than one thread to this function will
	/// likely result in unexpected behavior or memory corruption. To avoid this, you must synchronize all concurrent calls from more
	/// than one thread to this function.
	/// </para>
	/// <para>To call the Unicode version of this function, define DBGHELP_TRANSLATE_TCHAR.</para>
	/// <para>Examples</para>
	/// <para>For an example, see Loading a Symbol Module.</para>
	/// </remarks>
	// https://docs.microsoft.com/en-us/windows/win32/api/dbghelp/nf-dbghelp-symloadmoduleex DWORD64 IMAGEAPI SymLoadModuleEx( HANDLE
	// hProcess, HANDLE hFile, PCSTR ImageName, PCSTR ModuleName, DWORD64 BaseOfDll, DWORD DllSize, PMODLOAD_DATA Data, DWORD Flags );
	[DllImport(Lib_DbgHelp, SetLastError = true, CharSet = CharSet.Auto)]
	[PInvokeData("dbghelp.h", MSDNShortId = "NF:dbghelp.SymLoadModuleEx")]
	public static extern ulong SymLoadModuleEx(HPROCESS hProcess, [Optional] HFILE hFile, [Optional, MarshalAs(UnmanagedType.LPTStr)] string? ImageName,
		[Optional, MarshalAs(UnmanagedType.LPTStr)] string? ModuleName, [Optional] ulong BaseOfDll, [Optional] uint DllSize, [In, Optional] IntPtr Data,
		[Optional] SLMFLAG Flags);

	/// <summary>Compares a string to a file name and path.</summary>
	/// <param name="FileName">The file name to be compared to the Match parameter.</param>
	/// <param name="Match">The string to be compared to the FileName parameter.</param>
	/// <param name="FileNameStop">
	/// A pointer to a string buffer that receives a pointer to the location in FileName where matching stopped. For a complete match,
	/// this value can be one character before FileName. This value can also be <c>NULL</c>.
	/// </param>
	/// <param name="MatchStop">
	/// A pointer to a string buffer that receives a pointer to the location in Match where matching stopped. For a complete match, this
	/// value may be one character before Match. This value may be <c>NULL</c>.
	/// </param>
	/// <returns>
	/// <para>If the function succeeds, the return value is <c>TRUE</c>.</para>
	/// <para>If the function fails, the return value is <c>FALSE</c>. To retrieve extended error information, call GetLastError.</para>
	/// </returns>
	/// <remarks>
	/// <para>
	/// Because the match string can be a suffix of the complete file name, this function can be used to match a plain file name to a
	/// fully qualified file name.
	/// </para>
	/// <para>
	/// Matching begins from the end of both strings and proceeds backward. Matching is case-insensitive and equates a backslash ('')
	/// with a forward slash ('/').
	/// </para>
	/// <para>
	/// All DbgHelp functions, such as this one, are single threaded. Therefore, calls from more than one thread to this function will
	/// likely result in unexpected behavior or memory corruption. To avoid this, you must synchronize all concurrent calls from more
	/// than one thread to this function.
	/// </para>
	/// <para>To call the Unicode version of this function, define DBGHELP_TRANSLATE_TCHAR.</para>
	/// </remarks>
	// https://docs.microsoft.com/en-us/windows/win32/api/dbghelp/nf-dbghelp-symmatchfilename BOOL IMAGEAPI SymMatchFileName( PCSTR
	// FileName, PCSTR Match, PSTR *FileNameStop, PSTR *MatchStop );
	[DllImport(Lib_DbgHelp, SetLastError = true, CharSet = CharSet.Auto)]
	[PInvokeData("dbghelp.h", MSDNShortId = "NF:dbghelp.SymMatchFileName")]
	[return: MarshalAs(UnmanagedType.Bool)]
	public static extern bool SymMatchFileName([MarshalAs(UnmanagedType.LPTStr)] string FileName, [MarshalAs(UnmanagedType.LPTStr)] string Match,
		out StrPtrAuto FileNameStop, out StrPtrAuto MatchStop);

	/// <summary>Compares the specified string to the specified wildcard expression.</summary>
	/// <param name="string">The string, such as a symbol name, to be compared to the expression parameter.</param>
	/// <param name="expression">
	/// The wildcard expression to compare to the string parameter. The wildcard expression supports the inclusion of the * and ?
	/// characters. * matches any string and ? matches any single character.
	/// </param>
	/// <param name="fCase">A variable that indicates whether or not the comparison is to be case sensitive.</param>
	/// <returns>
	/// <para>If the function succeeds, the return value is <c>TRUE</c>.</para>
	/// <para>If the function fails, the return value is <c>FALSE</c>. To retrieve extended error information, call GetLastError.</para>
	/// </returns>
	/// <remarks>
	/// All DbgHelp functions, such as this one, are single threaded. Therefore, calls from more than one thread to this function will
	/// likely result in unexpected behavior or memory corruption. To avoid this, you must synchronize all concurrent calls from more
	/// than one thread to this function.
	/// </remarks>
	// https://docs.microsoft.com/en-us/windows/win32/api/dbghelp/nf-dbghelp-symmatchstring BOOL IMAGEAPI SymMatchString( PCSTR string,
	// PCSTR expression, BOOL fCase );
	[DllImport(Lib_DbgHelp, SetLastError = true, CharSet = CharSet.Auto)]
	[PInvokeData("dbghelp.h", MSDNShortId = "NF:dbghelp.SymMatchString")]
	[return: MarshalAs(UnmanagedType.Bool)]
	public static extern bool SymMatchString([MarshalAs(UnmanagedType.LPTStr)] string @string, [MarshalAs(UnmanagedType.LPTStr)] string expression,
		[MarshalAs(UnmanagedType.Bool)] bool fCase);

	/// <summary>Retrieves symbol information for the next symbol.</summary>
	/// <param name="hProcess">A handle to a process. This handle must have been previously passed to the SymInitialize function.</param>
	/// <param name="si">
	/// A pointer to a SYMBOL_INFO structure that provides information about the current symbol. Upon return, the structure contains
	/// information about the next symbol.
	/// </param>
	/// <returns>
	/// <para>If the function succeeds, the return value is <c>TRUE</c>.</para>
	/// <para>If the function fails, the return value is <c>FALSE</c>. To retrieve extended error information, call GetLastError.</para>
	/// </returns>
	/// <remarks>
	/// <para>
	/// This function requires that the SYMBOL_INFO structure have valid data for the current symbol. The next symbol is the symbol with
	/// the virtual address that is next in the sequence.
	/// </para>
	/// <para>
	/// All DbgHelp functions, such as this one, are single threaded. Therefore, calls from more than one thread to this function will
	/// likely result in unexpected behavior or memory corruption. To avoid this, you must synchronize all concurrent calls from more
	/// than one thread to this function.
	/// </para>
	/// <para>To call the Unicode version of this function, define DBGHELP_TRANSLATE_TCHAR.</para>
	/// </remarks>
	// https://docs.microsoft.com/en-us/windows/win32/api/dbghelp/nf-dbghelp-symnext BOOL IMAGEAPI SymNext( HANDLE hProcess,
	// PSYMBOL_INFO si );
	[DllImport(Lib_DbgHelp, SetLastError = true, CharSet = CharSet.Auto)]
	[PInvokeData("dbghelp.h", MSDNShortId = "NF:dbghelp.SymNext")]
	[return: MarshalAs(UnmanagedType.Bool)]
	public static extern bool SymNext(HPROCESS hProcess, ref SYMBOL_INFO si);

	/// <summary>Retrieves symbol information for the previous symbol.</summary>
	/// <param name="hProcess">A handle to a process. This handle must have been previously passed to the SymInitialize function.</param>
	/// <param name="si">
	/// A pointer to a SYMBOL_INFO structure that provides information about the current symbol. Upon return, the structure contains
	/// information about the previous symbol.
	/// </param>
	/// <returns>
	/// <para>If the function succeeds, the return value is <c>TRUE</c>.</para>
	/// <para>If the function fails, the return value is <c>FALSE</c>. To retrieve extended error information, call GetLastError.</para>
	/// </returns>
	/// <remarks>
	/// <para>
	/// This function requires that the SYMBOL_INFO structure have valid data for the current symbol. The previous symbol is the symbol
	/// with a virtual address that immediately precedes this symbol.
	/// </para>
	/// <para>
	/// All DbgHelp functions, such as this one, are single threaded. Therefore, calls from more than one thread to this function will
	/// likely result in unexpected behavior or memory corruption. To avoid this, you must synchronize all concurrent calls from more
	/// than one thread to this function.
	/// </para>
	/// <para>To call the Unicode version of this function, define DBGHELP_TRANSLATE_TCHAR.</para>
	/// </remarks>
	// https://docs.microsoft.com/en-us/windows/win32/api/dbghelp/nf-dbghelp-symprev BOOL IMAGEAPI SymPrev( HANDLE hProcess,
	// PSYMBOL_INFO si );
	[DllImport(Lib_DbgHelp, SetLastError = true, CharSet = CharSet.Auto)]
	[PInvokeData("dbghelp.h", MSDNShortId = "NF:dbghelp.SymPrev")]
	[return: MarshalAs(UnmanagedType.Bool)]
	public static extern bool SymPrev(HPROCESS hProcess, ref SYMBOL_INFO si);

	/// <summary>Queries an inline trace.</summary>
	/// <param name="hProcess">A handle to a process. This handle must have been previously passed to the SymInitialize function.</param>
	/// <param name="StartAddress">The start address.</param>
	/// <param name="StartContext">Contains the context of the start of block.</param>
	/// <param name="StartRetAddress">Contains the return address of the start of the current block/</param>
	/// <param name="CurAddress">Contains the current address.</param>
	/// <param name="CurContext">Address of a <c>DWORD</c> that receives the current context.</param>
	/// <param name="CurFrameIndex">
	/// <para>If the function succeeds, the return value is <c>TRUE</c>.</para>
	/// <para>If the function fails, the return value is <c>FALSE</c>. To retrieve extended error information, call GetLastError.</para>
	/// </param>
	/// <returns>None</returns>
	/// <remarks>
	/// Either the StartAddress or StartRetAddress parameters must be within the same function scope as the CurAddress parameter. The
	/// former indicates a step-over within the same function and the latter indicates a step-over from StartAddress.
	/// </remarks>
	// https://docs.microsoft.com/en-us/windows/win32/api/dbghelp/nf-dbghelp-symqueryinlinetrace BOOL IMAGEAPI SymQueryInlineTrace(
	// HANDLE hProcess, DWORD64 StartAddress, DWORD StartContext, DWORD64 StartRetAddress, DWORD64 CurAddress, LPDWORD CurContext,
	// LPDWORD CurFrameIndex );
	[DllImport(Lib_DbgHelp, SetLastError = true, ExactSpelling = true)]
	[PInvokeData("dbghelp.h", MSDNShortId = "NF:dbghelp.SymQueryInlineTrace")]
	[return: MarshalAs(UnmanagedType.Bool)]
	public static extern bool SymQueryInlineTrace(HPROCESS hProcess, ulong StartAddress, uint StartContext, ulong StartRetAddress, ulong CurAddress,
		out uint CurContext, out uint CurFrameIndex);

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

	/// <summary>Registers a callback function for use by the symbol handler.</summary>
	/// <param name="hProcess">A handle to the process that was originally passed to the SymInitialize function.</param>
	/// <param name="CallbackFunction">A SymRegisterCallbackProc64 callback function.</param>
	/// <param name="UserContext">
	/// A user-defined value or <c>NULL</c>. This value is simply passed to the callback function. Normally, this parameter is used by
	/// an application to pass a pointer to a data structure that lets the callback function establish some context.
	/// </param>
	/// <returns>
	/// <para>If the function succeeds, the return value is <c>TRUE</c>.</para>
	/// <para>If the function fails, the return value is <c>FALSE</c>. To retrieve extended error information, call GetLastError.</para>
	/// </returns>
	/// <remarks>
	/// <para>
	/// The <c>SymRegisterCallback64</c> function lets an application register a callback function for use by the symbol handler. The
	/// symbol handler calls the registered callback function when there is status or progress information for the application.
	/// </para>
	/// <para>
	/// All DbgHelp functions, such as this one, are single threaded. Therefore, calls from more than one thread to this function will
	/// likely result in unexpected behavior or memory corruption. To avoid this, you must synchronize all concurrent calls from more
	/// than one thread to this function.
	/// </para>
	/// <para>
	/// To call the Unicode version of this function, define DBGHELP_TRANSLATE_TCHAR. <c>SymRegisterCallbackW64</c> is defined as
	/// follows in Dbghelp.h.
	/// </para>
	/// <para>
	/// <code>BOOL IMAGEAPI SymRegisterCallbackW64( __in HANDLE hProcess, __in PSYMBOL_REGISTERED_CALLBACK64 CallbackFunction, __in ULONG64 UserContext ); #ifdef DBGHELP_TRANSLATE_TCHAR #define SymRegisterCallback64 SymRegisterCallbackW64 #endif</code>
	/// </para>
	/// <para>
	/// This function supersedes the <c>SymRegisterCallback</c> function. For more information, see Updated Platform Support.
	/// <c>SymRegisterCallback</c> is defined as follows in Dbghelp.h.
	/// </para>
	/// <para>
	/// <code>#if !defined(_IMAGEHLP_SOURCE_) &amp;&amp; defined(_IMAGEHLP64) #define SymRegisterCallback SymRegisterCallback64 #else BOOL IMAGEAPI SymRegisterCallback( __in HANDLE hProcess, __in PSYMBOL_REGISTERED_CALLBACK CallbackFunction, __in_opt PVOID UserContext ); #endif</code>
	/// </para>
	/// <para>For a more extensive example, read Getting Notifications.</para>
	/// </remarks>
	// https://docs.microsoft.com/en-us/windows/win32/api/dbghelp/nf-dbghelp-symregistercallback BOOL IMAGEAPI SymRegisterCallback(
	// HANDLE hProcess, PSYMBOL_REGISTERED_CALLBACK CallbackFunction, PVOID UserContext );
	[DllImport(Lib_DbgHelp, SetLastError = true, CharSet = CharSet.Auto)]
	[PInvokeData("dbghelp.h", MSDNShortId = "NF:dbghelp.SymRegisterCallback")]
	[return: MarshalAs(UnmanagedType.Bool)]
	public static extern bool SymRegisterCallback(HPROCESS hProcess, PSYMBOL_REGISTERED_CALLBACK CallbackFunction, [In, Optional] IntPtr UserContext);

	/// <summary>Registers a callback function for use by the symbol handler.</summary>
	/// <param name="hProcess">A handle to the process that was originally passed to the SymInitialize function.</param>
	/// <param name="CallbackFunction">A SymRegisterCallbackProc64 callback function.</param>
	/// <param name="UserContext">
	/// A user-defined value or <c>NULL</c>. This value is simply passed to the callback function. Normally, this parameter is used by
	/// an application to pass a pointer to a data structure that lets the callback function establish some context.
	/// </param>
	/// <returns>
	/// <para>If the function succeeds, the return value is <c>TRUE</c>.</para>
	/// <para>If the function fails, the return value is <c>FALSE</c>. To retrieve extended error information, call GetLastError.</para>
	/// </returns>
	/// <remarks>
	/// <para>
	/// The <c>SymRegisterCallback64</c> function lets an application register a callback function for use by the symbol handler. The
	/// symbol handler calls the registered callback function when there is status or progress information for the application.
	/// </para>
	/// <para>
	/// All DbgHelp functions, such as this one, are single threaded. Therefore, calls from more than one thread to this function will
	/// likely result in unexpected behavior or memory corruption. To avoid this, you must synchronize all concurrent calls from more
	/// than one thread to this function.
	/// </para>
	/// <para>
	/// To call the Unicode version of this function, define DBGHELP_TRANSLATE_TCHAR. <c>SymRegisterCallbackW64</c> is defined as
	/// follows in Dbghelp.h.
	/// </para>
	/// <para>
	/// <code>BOOL IMAGEAPI SymRegisterCallbackW64( __in HANDLE hProcess, __in PSYMBOL_REGISTERED_CALLBACK64 CallbackFunction, __in ULONG64 UserContext ); #ifdef DBGHELP_TRANSLATE_TCHAR #define SymRegisterCallback64 SymRegisterCallbackW64 #endif</code>
	/// </para>
	/// <para>
	/// This function supersedes the <c>SymRegisterCallback</c> function. For more information, see Updated Platform Support.
	/// <c>SymRegisterCallback</c> is defined as follows in Dbghelp.h.
	/// </para>
	/// <para>
	/// <code>#if !defined(_IMAGEHLP_SOURCE_) &amp;&amp; defined(_IMAGEHLP64) #define SymRegisterCallback SymRegisterCallback64 #else BOOL IMAGEAPI SymRegisterCallback( __in HANDLE hProcess, __in PSYMBOL_REGISTERED_CALLBACK CallbackFunction, __in_opt PVOID UserContext ); #endif</code>
	/// </para>
	/// <para>For a more extensive example, read Getting Notifications.</para>
	/// </remarks>
	// https://docs.microsoft.com/en-us/windows/win32/api/dbghelp/nf-dbghelp-symregistercallback64 BOOL IMAGEAPI SymRegisterCallback64(
	// HANDLE hProcess, PSYMBOL_REGISTERED_CALLBACK64 CallbackFunction, ULONG64 UserContext );
	[DllImport(Lib_DbgHelp, SetLastError = true, CharSet = CharSet.Ansi, ExactSpelling = true)]
	[PInvokeData("dbghelp.h", MSDNShortId = "NF:dbghelp.SymRegisterCallback64")]
	[return: MarshalAs(UnmanagedType.Bool)]
	public static extern bool SymRegisterCallback64(HPROCESS hProcess, PSYMBOL_REGISTERED_CALLBACK64 CallbackFunction, [In, Optional] ulong UserContext);

	/// <summary>Registers a callback function for use by the symbol handler.</summary>
	/// <param name="hProcess">A handle to the process that was originally passed to the SymInitialize function.</param>
	/// <param name="CallbackFunction">A SymRegisterCallbackProc64 callback function.</param>
	/// <param name="UserContext">
	/// A user-defined value or <c>NULL</c>. This value is simply passed to the callback function. Normally, this parameter is used by
	/// an application to pass a pointer to a data structure that lets the callback function establish some context.
	/// </param>
	/// <returns>
	/// <para>If the function succeeds, the return value is <c>TRUE</c>.</para>
	/// <para>If the function fails, the return value is <c>FALSE</c>. To retrieve extended error information, call GetLastError.</para>
	/// </returns>
	/// <remarks>
	/// <para>
	/// The <c>SymRegisterCallback64</c> function lets an application register a callback function for use by the symbol handler. The
	/// symbol handler calls the registered callback function when there is status or progress information for the application.
	/// </para>
	/// <para>
	/// All DbgHelp functions, such as this one, are single threaded. Therefore, calls from more than one thread to this function will
	/// likely result in unexpected behavior or memory corruption. To avoid this, you must synchronize all concurrent calls from more
	/// than one thread to this function.
	/// </para>
	/// <para>
	/// To call the Unicode version of this function, define DBGHELP_TRANSLATE_TCHAR. <c>SymRegisterCallbackW64</c> is defined as
	/// follows in Dbghelp.h.
	/// </para>
	/// <para>
	/// <code>BOOL IMAGEAPI SymRegisterCallbackW64( __in HANDLE hProcess, __in PSYMBOL_REGISTERED_CALLBACK64 CallbackFunction, __in ULONG64 UserContext ); #ifdef DBGHELP_TRANSLATE_TCHAR #define SymRegisterCallback64 SymRegisterCallbackW64 #endif</code>
	/// </para>
	/// <para>
	/// This function supersedes the <c>SymRegisterCallback</c> function. For more information, see Updated Platform Support.
	/// <c>SymRegisterCallback</c> is defined as follows in Dbghelp.h.
	/// </para>
	/// <para>
	/// <code>#if !defined(_IMAGEHLP_SOURCE_) &amp;&amp; defined(_IMAGEHLP64) #define SymRegisterCallback SymRegisterCallback64 #else BOOL IMAGEAPI SymRegisterCallback( __in HANDLE hProcess, __in PSYMBOL_REGISTERED_CALLBACK CallbackFunction, __in_opt PVOID UserContext ); #endif</code>
	/// </para>
	/// <para>For a more extensive example, read Getting Notifications.</para>
	/// </remarks>
	// https://docs.microsoft.com/en-us/windows/win32/api/dbghelp/nf-dbghelp-symregistercallbackw64 BOOL IMAGEAPI
	// SymRegisterCallbackW64( HANDLE hProcess, PSYMBOL_REGISTERED_CALLBACK64 CallbackFunction, ULONG64 UserContext );
	[DllImport(Lib_DbgHelp, SetLastError = true, CharSet = CharSet.Unicode, ExactSpelling = true)]
	[PInvokeData("dbghelp.h", MSDNShortId = "NF:dbghelp.SymRegisterCallbackW64")]
	[return: MarshalAs(UnmanagedType.Bool)]
	public static extern bool SymRegisterCallbackW64(HPROCESS hProcess, PSYMBOL_REGISTERED_CALLBACK64 CallbackFunction, [In, Optional] ulong UserContext);

	/// <summary>Registers a callback function for use by the stack walking procedure on Alpha computers.</summary>
	/// <param name="hProcess">A handle to the process that was originally passed to the StackWalk64 function.</param>
	/// <param name="CallbackFunction">A SymRegisterFunctionEntryCallbackProc64 callback function.</param>
	/// <param name="UserContext">
	/// A user-defined value or <c>NULL</c>. This value is simply passed to the callback function. Normally, this parameter is used by
	/// an application to pass a pointer to a data structure that lets the callback function establish some context.
	/// </param>
	/// <returns>
	/// <para>If the function succeeds, the return value is <c>TRUE</c>.</para>
	/// <para>If the function fails, the return value is <c>FALSE</c>. To retrieve extended error information, call GetLastError.</para>
	/// </returns>
	/// <remarks>
	/// <para>
	/// The <c>SymRegisterFunctionEntryCallback64</c> function lets an application register a callback function for use by the stack
	/// walking procedure. The stack walking procedure calls the registered callback function when it is unable to locate a function
	/// table entry for an address. In most cases, the stack walking procedure locates the function table entries in the function table
	/// of the image containing the address. However, in situations where the function table entries are not in the image, this callback
	/// allows the debugger to provide the function table entry from another source. For example, run-time generated code on Alpha
	/// computers can define dynamic function tables to support exception handling and stack tracing.
	/// </para>
	/// <para>
	/// All DbgHelp functions, such as this one, are single threaded. Therefore, calls from more than one thread to this function will
	/// likely result in unexpected behavior or memory corruption. To avoid this, you must synchronize all concurrent calls from more
	/// than one thread to this function.
	/// </para>
	/// <para>
	/// This function supersedes the <c>SymRegisterFunctionEntryCallback</c> function. For more information, see Updated Platform
	/// Support. <c>SymRegisterFunctionEntryCallback</c> is defined as follows in Dbghelp.h.
	/// </para>
	/// <para>
	/// <code>#if !defined(_IMAGEHLP_SOURCE_) &amp;&amp; defined(_IMAGEHLP64) #define SymRegisterFunctionEntryCallback SymRegisterFunctionEntryCallback64 #else BOOL IMAGEAPI SymRegisterFunctionEntryCallback( __in HANDLE hProcess, __in PSYMBOL_FUNCENTRY_CALLBACK CallbackFunction, __in_opt PVOID UserContext ); #endif</code>
	/// </para>
	/// </remarks>
	// https://docs.microsoft.com/en-us/windows/win32/api/dbghelp/nf-dbghelp-symregisterfunctionentrycallback BOOL IMAGEAPI
	// SymRegisterFunctionEntryCallback( HANDLE hProcess, PSYMBOL_FUNCENTRY_CALLBACK CallbackFunction, PVOID UserContext );
	[DllImport(Lib_DbgHelp, SetLastError = true, ExactSpelling = true)]
	[PInvokeData("dbghelp.h", MSDNShortId = "NF:dbghelp.SymRegisterFunctionEntryCallback")]
	[return: MarshalAs(UnmanagedType.Bool)]
	public static extern bool SymRegisterFunctionEntryCallback(HPROCESS hProcess, PSYMBOL_FUNCENTRY_CALLBACK CallbackFunction, [In, Optional] IntPtr UserContext);

	/// <summary>Registers a callback function for use by the stack walking procedure on Alpha computers.</summary>
	/// <param name="hProcess">A handle to the process that was originally passed to the StackWalk64 function.</param>
	/// <param name="CallbackFunction">A SymRegisterFunctionEntryCallbackProc64 callback function.</param>
	/// <param name="UserContext">
	/// A user-defined value or <c>NULL</c>. This value is simply passed to the callback function. Normally, this parameter is used by
	/// an application to pass a pointer to a data structure that lets the callback function establish some context.
	/// </param>
	/// <returns>
	/// <para>If the function succeeds, the return value is <c>TRUE</c>.</para>
	/// <para>If the function fails, the return value is <c>FALSE</c>. To retrieve extended error information, call GetLastError.</para>
	/// </returns>
	/// <remarks>
	/// <para>
	/// The <c>SymRegisterFunctionEntryCallback64</c> function lets an application register a callback function for use by the stack
	/// walking procedure. The stack walking procedure calls the registered callback function when it is unable to locate a function
	/// table entry for an address. In most cases, the stack walking procedure locates the function table entries in the function table
	/// of the image containing the address. However, in situations where the function table entries are not in the image, this callback
	/// allows the debugger to provide the function table entry from another source. For example, run-time generated code on Alpha
	/// computers can define dynamic function tables to support exception handling and stack tracing.
	/// </para>
	/// <para>
	/// All DbgHelp functions, such as this one, are single threaded. Therefore, calls from more than one thread to this function will
	/// likely result in unexpected behavior or memory corruption. To avoid this, you must synchronize all concurrent calls from more
	/// than one thread to this function.
	/// </para>
	/// <para>
	/// This function supersedes the <c>SymRegisterFunctionEntryCallback</c> function. For more information, see Updated Platform
	/// Support. <c>SymRegisterFunctionEntryCallback</c> is defined as follows in Dbghelp.h.
	/// </para>
	/// <para>
	/// <code>#if !defined(_IMAGEHLP_SOURCE_) &amp;&amp; defined(_IMAGEHLP64) #define SymRegisterFunctionEntryCallback SymRegisterFunctionEntryCallback64 #else BOOL IMAGEAPI SymRegisterFunctionEntryCallback( __in HANDLE hProcess, __in PSYMBOL_FUNCENTRY_CALLBACK CallbackFunction, __in_opt PVOID UserContext ); #endif</code>
	/// </para>
	/// </remarks>
	// https://docs.microsoft.com/en-us/windows/win32/api/dbghelp/nf-dbghelp-symregisterfunctionentrycallback64 BOOL IMAGEAPI
	// SymRegisterFunctionEntryCallback64( HANDLE hProcess, PSYMBOL_FUNCENTRY_CALLBACK64 CallbackFunction, ULONG64 UserContext );
	[DllImport(Lib_DbgHelp, SetLastError = true, ExactSpelling = true)]
	[PInvokeData("dbghelp.h", MSDNShortId = "NF:dbghelp.SymRegisterFunctionEntryCallback64")]
	[return: MarshalAs(UnmanagedType.Bool)]
	public static extern bool SymRegisterFunctionEntryCallback64(HPROCESS hProcess, PSYMBOL_FUNCENTRY_CALLBACK64 CallbackFunction, [In, Optional] ulong UserContext);

	/// <summary>Searches for PDB symbols that meet the specified criteria.</summary>
	/// <param name="hProcess">A handle to a process. This handle must have been previously passed to the SymInitialize function.</param>
	/// <param name="BaseOfDll">
	/// The base address of the module. If this value is zero and Mask contains an exclamation point (!), the function looks across
	/// modules. If this value is zero and Mask does not contain an exclamation point, the function uses the scope established by the
	/// SymSetContext function.
	/// </param>
	/// <param name="Index">A unique value for the symbol.</param>
	/// <param name="SymTag">
	/// The PDB classification. These values are defined in Dbghelp.h in the <c>SymTagEnum</c> enumeration type. For descriptions, see
	/// the PDB documentation.
	/// </param>
	/// <param name="Mask">
	/// A wildcard expression that indicates the names of the symbols to be enumerated. To specify a module name, use the !mod syntax.
	/// </param>
	/// <param name="Address">The address of the symbol.</param>
	/// <param name="EnumSymbolsCallback">A SymEnumSymbolsProc callback function that receives the symbol information.</param>
	/// <param name="UserContext">
	/// A user-defined value that is passed to the callback function, or <c>NULL</c>. This parameter is typically used by an application
	/// to pass a pointer to a data structure that provides context for the callback function.
	/// </param>
	/// <param name="Options">
	/// <para>The options that control the behavior of this function.</para>
	/// <list type="table">
	/// <listheader>
	/// <term>Value</term>
	/// <term>Meaning</term>
	/// </listheader>
	/// <item>
	/// <term>SYMSEARCH_ALLITEMS 0x08</term>
	/// <term>Include all symbols and other data in the .pdb files. DbgHelp 6.6 and earlier: This value is not supported.</term>
	/// </item>
	/// <item>
	/// <term>SYMSEARCH_GLOBALSONLY 0x04</term>
	/// <term>Search only for global symbols.</term>
	/// </item>
	/// <item>
	/// <term>SYMSEARCH_MASKOBJS 0x01</term>
	/// <term>For internal use only.</term>
	/// </item>
	/// <item>
	/// <term>SYMSEARCH_RECURSE 0x02</term>
	/// <term>Recurse from the top to find all symbols.</term>
	/// </item>
	/// </list>
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
	// https://docs.microsoft.com/en-us/windows/win32/api/dbghelp/nf-dbghelp-symsearch BOOL IMAGEAPI SymSearch( HANDLE hProcess, ULONG64
	// BaseOfDll, DWORD Index, DWORD SymTag, PCSTR Mask, DWORD64 Address, PSYM_ENUMERATESYMBOLS_CALLBACK EnumSymbolsCallback, PVOID
	// UserContext, DWORD Options );
	[DllImport(Lib_DbgHelp, SetLastError = true, CharSet = CharSet.Auto)]
	[PInvokeData("dbghelp.h", MSDNShortId = "NF:dbghelp.SymSearch")]
	[return: MarshalAs(UnmanagedType.Bool)]
	public static extern bool SymSearch(HPROCESS hProcess, ulong BaseOfDll, [Optional] uint Index, [Optional] uint SymTag, [Optional, MarshalAs(UnmanagedType.LPTStr)] string? Mask,
		[Optional] ulong Address, PSYM_ENUMERATESYMBOLS_CALLBACK EnumSymbolsCallback, [In, Optional] IntPtr UserContext, SYMSEARCH Options);

	/// <summary>Sets context information used by the SymEnumSymbols function. This function only works with PDB symbols.</summary>
	/// <param name="hProcess">A handle to a process. This handle must have been previously passed to the SymInitialize function.</param>
	/// <param name="StackFrame">A pointer to an IMAGEHLP_STACK_FRAME structure that contains frame information.</param>
	/// <param name="Context">This parameter is ignored.</param>
	/// <returns>
	/// <para>If the function succeeds, the return value is <c>TRUE</c>.</para>
	/// <para>If the function fails, the return value is <c>FALSE</c>. To retrieve extended error information, call GetLastError.</para>
	/// </returns>
	/// <remarks>
	/// <para>
	/// If you call <c>SymSetContext</c> to set the context to its current value, the function fails but GetLastError returns <c>ERROR_SUCCESS</c>.
	/// </para>
	/// <para>
	/// All DbgHelp functions, such as this one, are single threaded. Therefore, calls from more than one thread to this function will
	/// likely result in unexpected behavior or memory corruption. To avoid this, you must synchronize all concurrent calls from more
	/// than one thread to this function.
	/// </para>
	/// </remarks>
	// https://docs.microsoft.com/en-us/windows/win32/api/dbghelp/nf-dbghelp-symsetcontext BOOL IMAGEAPI SymSetContext( HANDLE hProcess,
	// PIMAGEHLP_STACK_FRAME StackFrame, PIMAGEHLP_CONTEXT Context );
	[DllImport(Lib_DbgHelp, SetLastError = true, ExactSpelling = true)]
	[PInvokeData("dbghelp.h", MSDNShortId = "NF:dbghelp.SymSetContext")]
	[return: MarshalAs(UnmanagedType.Bool)]
	public static extern bool SymSetContext(HPROCESS hProcess, in IMAGEHLP_STACK_FRAME StackFrame, [In, Optional] IntPtr Context);

	/// <summary>Turns the specified extended symbol option on or off.</summary>
	/// <param name="option">
	/// <para>The extended symbol option to turn on or off. The following are valid values.</para>
	/// <list type="table">
	/// <listheader>
	/// <term>Value</term>
	/// <term>Meaning</term>
	/// </listheader>
	/// <item>
	/// <term>SYMOPT_EX_DISABLEACCESSTIMEUPDATE 0</term>
	/// <term>
	/// When set to TRUE, turns off explicitly updating the last access time of a symbol that is loaded. By default, DbgHelp updates the
	/// last access time of a symbol file that is consumed so that a symbol cache can be maintained by using a least recently used mechanism.
	/// </term>
	/// </item>
	/// </list>
	/// </param>
	/// <param name="value">The value to set for the specified option, either TRUE or FALSE.</param>
	/// <returns>The previous value of the specified extended option.</returns>
	// https://docs.microsoft.com/en-us/windows/win32/api/dbghelp/nf-dbghelp-symsetextendedoption BOOL IMAGEAPI SymSetExtendedOption(
	// IMAGEHLP_EXTENDED_OPTIONS option, BOOL value );
	[DllImport(Lib_DbgHelp, SetLastError = false, ExactSpelling = true)]
	[PInvokeData("dbghelp.h", MSDNShortId = "NF:dbghelp.SymSetExtendedOption")]
	[return: MarshalAs(UnmanagedType.Bool)]
	public static extern bool SymSetExtendedOption(IMAGEHLP_EXTENDED_OPTIONS option, [MarshalAs(UnmanagedType.Bool)] bool value);

	/// <summary>Sets the home directory used by Dbghelp.</summary>
	/// <param name="hProcess">A handle to a process. This handle must have been previously passed to the SymInitialize function.</param>
	/// <param name="dir">
	/// The home directory. This directory must be writable, otherwise the home directory is the common application directory specified
	/// with CSIDL_COMMON_APPDATA. If this parameter is <c>NULL</c>, the function uses the default directory.
	/// </param>
	/// <returns>
	/// <para>If the function succeeds, the return value is a pointer to the dir parameter.</para>
	/// <para>If the function fails, the return value is <c>NULL</c>. To retrieve extended error information, call GetLastError.</para>
	/// </returns>
	/// <remarks>
	/// <para>
	/// The default home directory is the directory in which Dbghelp.dll resides. Dbghelp uses this directory as a basis for other
	/// directories, such as the default downstream store directory (the sym subdirectory of the home directory).
	/// </para>
	/// <para>
	/// The home directory used for the default symbol store and the source server cache location is stored in the DBGHELP_HOMEDIR
	/// environment variable.
	/// </para>
	/// <para>
	/// All DbgHelp functions, such as this one, are single threaded. Therefore, calls from more than one thread to this function will
	/// likely result in unexpected behavior or memory corruption. To avoid this, you must synchronize all concurrent calls from more
	/// than one thread to this function.
	/// </para>
	/// <para>To call the Unicode version of this function, define DBGHELP_TRANSLATE_TCHAR.</para>
	/// </remarks>
	// https://docs.microsoft.com/en-us/windows/win32/api/dbghelp/nf-dbghelp-symsethomedirectory PCHAR IMAGEAPI SymSetHomeDirectory(
	// HANDLE hProcess, PCSTR dir );
	[DllImport(Lib_DbgHelp, SetLastError = true, CharSet = CharSet.Auto)]
	[PInvokeData("dbghelp.h", MSDNShortId = "NF:dbghelp.SymSetHomeDirectory")]
	public static extern StrPtrAuto SymSetHomeDirectory([Optional] HPROCESS hProcess, [Optional, MarshalAs(UnmanagedType.LPTStr)] string? dir);

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

	/// <summary>Sets the window that the caller will use to display a user interface.</summary>
	/// <param name="hwnd">A handle to the window.</param>
	/// <returns>
	/// <para>If the function succeeds, the return value is <c>TRUE</c>.</para>
	/// <para>If the function fails, the return value is <c>FALSE</c>. To retrieve extended error information, call GetLastError.</para>
	/// </returns>
	/// <remarks>
	/// All DbgHelp functions, such as this one, are single threaded. Therefore, calls from more than one thread to this function will
	/// likely result in unexpected behavior or memory corruption. To avoid this, you must synchronize all concurrent calls from more
	/// than one thread to this function.
	/// </remarks>
	// https://docs.microsoft.com/en-us/windows/win32/api/dbghelp/nf-dbghelp-symsetparentwindow BOOL IMAGEAPI SymSetParentWindow( HWND
	// hwnd );
	[DllImport(Lib_DbgHelp, SetLastError = true, ExactSpelling = true)]
	[PInvokeData("dbghelp.h", MSDNShortId = "NF:dbghelp.SymSetParentWindow")]
	[return: MarshalAs(UnmanagedType.Bool)]
	public static extern bool SymSetParentWindow(HWND hwnd);

	/// <summary>Sets the local scope to the symbol that matches the specified address.</summary>
	/// <param name="hProcess">A handle to a process. This handle must have been previously passed to the SymInitialize function.</param>
	/// <param name="Address">The address.</param>
	/// <returns>
	/// <para>If the function succeeds, the return value is <c>TRUE</c>.</para>
	/// <para>If the function fails, the return value is <c>FALSE</c>. To retrieve extended error information, call GetLastError.</para>
	/// </returns>
	/// <remarks>
	/// All DbgHelp functions, such as this one, are single threaded. Therefore, calls from more than one thread to this function will
	/// likely result in unexpected behavior or memory corruption. To avoid this, you must synchronize all concurrent calls from more
	/// than one thread to this function.
	/// </remarks>
	// https://docs.microsoft.com/en-us/windows/win32/api/dbghelp/nf-dbghelp-symsetscopefromaddr BOOL IMAGEAPI SymSetScopeFromAddr(
	// HANDLE hProcess, ULONG64 Address );
	[DllImport(Lib_DbgHelp, SetLastError = true, ExactSpelling = true)]
	[PInvokeData("dbghelp.h", MSDNShortId = "NF:dbghelp.SymSetScopeFromAddr")]
	[return: MarshalAs(UnmanagedType.Bool)]
	public static extern bool SymSetScopeFromAddr(HPROCESS hProcess, ulong Address);

	/// <summary>Sets the local scope to the symbol that matches the specified index.</summary>
	/// <param name="hProcess">A handle to a process. This handle must have been previously passed to the SymInitialize function.</param>
	/// <param name="BaseOfDll">The base address of the module.</param>
	/// <param name="Index">The unique value for the symbol.</param>
	/// <returns>
	/// <para>If the function succeeds, the return value is <c>TRUE</c>.</para>
	/// <para>If the function fails, the return value is <c>FALSE</c>. To retrieve extended error information, call GetLastError.</para>
	/// </returns>
	/// <remarks>
	/// All DbgHelp functions, such as this one, are single threaded. Therefore, calls from more than one thread to this function will
	/// likely result in unexpected behavior or memory corruption. To avoid this, you must synchronize all concurrent calls from more
	/// than one thread to this function.
	/// </remarks>
	// https://docs.microsoft.com/en-us/windows/win32/api/dbghelp/nf-dbghelp-symsetscopefromindex BOOL IMAGEAPI SymSetScopeFromIndex(
	// HANDLE hProcess, ULONG64 BaseOfDll, DWORD Index );
	[DllImport(Lib_DbgHelp, SetLastError = true, ExactSpelling = true)]
	[PInvokeData("dbghelp.h", MSDNShortId = "NF:dbghelp.SymSetScopeFromIndex")]
	[return: MarshalAs(UnmanagedType.Bool)]
	public static extern bool SymSetScopeFromIndex(HPROCESS hProcess, ulong BaseOfDll, uint Index);

	/// <summary>Sets the local scope to the symbol that matches the specified address and inline context.</summary>
	/// <param name="hProcess">A handle to a process. This handle must have been previously passed to the SymInitialize function.</param>
	/// <param name="Address">The address.</param>
	/// <param name="InlineContext">The inline context.</param>
	/// <returns>
	/// <para>If the function succeeds, the return value is <c>TRUE</c>.</para>
	/// <para>If the function fails, the return value is <c>FALSE</c>. To retrieve extended error information, call GetLastError.</para>
	/// </returns>
	// https://docs.microsoft.com/en-us/windows/win32/api/dbghelp/nf-dbghelp-symsetscopefrominlinecontext BOOL IMAGEAPI
	// SymSetScopeFromInlineContext( HANDLE hProcess, ULONG64 Address, ULONG InlineContext );
	[DllImport(Lib_DbgHelp, SetLastError = true, ExactSpelling = true)]
	[PInvokeData("dbghelp.h", MSDNShortId = "NF:dbghelp.SymSetScopeFromInlineContext")]
	[return: MarshalAs(UnmanagedType.Bool)]
	public static extern bool SymSetScopeFromInlineContext(HPROCESS hProcess, ulong Address, uint InlineContext);

	/// <summary>Sets the search path for the specified process.</summary>
	/// <param name="hProcess">A handle to the process that was originally passed to the SymInitialize function.</param>
	/// <param name="SearchPath">The symbol search path. The string can contain multiple paths separated by semicolons.</param>
	/// <returns>
	/// <para>If the function succeeds, the return value is <c>TRUE</c>.</para>
	/// <para>If the function fails, the return value is <c>FALSE</c>. To retrieve extended error information, call GetLastError.</para>
	/// </returns>
	/// <remarks>
	/// <para>
	/// The symbol search path can be changed any number of times while the library is in use by an application. The change affects all
	/// future calls to the symbol handler.
	/// </para>
	/// <para>To get the current search path, call the SymGetSearchPath function.</para>
	/// <para>
	/// All DbgHelp functions, such as this one, are single threaded. Therefore, calls from more than one thread to this function will
	/// likely result in unexpected behavior or memory corruption. To avoid this, you must synchronize all concurrent calls from more
	/// than one thread to this function.
	/// </para>
	/// <para>To call the Unicode version of this function, define DBGHELP_TRANSLATE_TCHAR.</para>
	/// </remarks>
	// https://docs.microsoft.com/en-us/windows/win32/api/dbghelp/nf-dbghelp-symsetsearchpath BOOL IMAGEAPI SymSetSearchPath( HANDLE
	// hProcess, PCSTR SearchPath );
	[DllImport(Lib_DbgHelp, SetLastError = true, CharSet = CharSet.Auto)]
	[PInvokeData("dbghelp.h", MSDNShortId = "NF:dbghelp.SymSetSearchPath")]
	[return: MarshalAs(UnmanagedType.Bool)]
	public static extern bool SymSetSearchPath(HPROCESS hProcess, [MarshalAs(UnmanagedType.LPTStr)] string SearchPath);

	/// <summary>
	/// Generates the name for a file that describes the relationship between two different versions of the same symbol or image file.
	/// Using this feature prevents applications from having to regenerate such information every time they analyze two files.
	/// </summary>
	/// <param name="hProcess">A handle to a process. This handle must have been previously passed to the SymInitialize function.</param>
	/// <param name="SymPath">
	/// The symbol path. The function uses only the symbol stores described in standard syntax for symbol stores. All other paths are
	/// ignored. If this parameter is <c>NULL</c>, the function uses the symbol path set using the SymInitialize or SymSetSearchPath function.
	/// </param>
	/// <param name="Type">The extension for the generated file name.</param>
	/// <param name="File1">The path of the first version of the symbol or image file.</param>
	/// <param name="File2">The path of the second version of the symbol or image file.</param>
	/// <returns>
	/// <para>If the function succeeds, the return value is the resulting file name.</para>
	/// <para>If the function fails, the return value is <c>NULL</c>. To retrieve extended error information, call GetLastError.</para>
	/// </returns>
	/// <remarks>
	/// <para>
	/// This function opens the two specified files, reads the indexing information from the header, and passes this information to the
	/// symbol server so it can create the file name. If you specify the Type parameter as "xml", the name is the index of File1,
	/// followed by a dash, followed by the index of File2, followed by an .xml extension. For example:
	/// </para>
	/// <para>3F3D5C755000-3F3D647621000.xml</para>
	/// <para>
	/// All DbgHelp functions, such as this one, are single threaded. Therefore, calls from more than one thread to this function will
	/// likely result in unexpected behavior or memory corruption. To avoid this, you must synchronize all concurrent calls from more
	/// than one thread to this function.
	/// </para>
	/// <para>To call the Unicode version of this function, define DBGHELP_TRANSLATE_TCHAR.</para>
	/// </remarks>
	// https://docs.microsoft.com/en-us/windows/win32/api/dbghelp/nf-dbghelp-symsrvdeltaname PCSTR IMAGEAPI SymSrvDeltaName( HANDLE
	// hProcess, PCSTR SymPath, PCSTR Type, PCSTR File1, PCSTR File2 );
	[DllImport(Lib_DbgHelp, SetLastError = true, CharSet = CharSet.Auto)]
	[PInvokeData("dbghelp.h", MSDNShortId = "NF:dbghelp.SymSrvDeltaName")]
	[return: MarshalAs(UnmanagedType.LPTStr)]
	public static extern string? SymSrvDeltaName(HPROCESS hProcess, [Optional, MarshalAs(UnmanagedType.LPTStr)] string? SymPath,
		[MarshalAs(UnmanagedType.LPTStr)] string Type, [MarshalAs(UnmanagedType.LPTStr)] string File1, [MarshalAs(UnmanagedType.LPTStr)] string File2);

	/// <summary>
	/// Retrieves the indexes for the specified .pdb, .dbg, or image file that would be used to store the file. The combination of these
	/// values uniquely identifies the file in the symbol server. They can be used when calling the SymFindFileInPath function to search
	/// for a file in a symbol store.
	/// </summary>
	/// <param name="File">The name of the file.</param>
	/// <param name="Id">The first of three identifying parameters.</param>
	/// <param name="Val1">The second of three identifying parameters.</param>
	/// <param name="Val2">The third of three identifying parameters.</param>
	/// <param name="Flags">This parameter is reserved for future use.</param>
	/// <returns>
	/// <para>If the function succeeds, the return value is nonzero.</para>
	/// <para>If the function fails, the return value is zero. To retrieve extended error information, call GetLastError.</para>
	/// </returns>
	/// <remarks>
	/// <para>
	/// All DbgHelp functions, such as this one, are single threaded. Therefore, calls from more than one thread to this function will
	/// likely result in unexpected behavior or memory corruption. To avoid this, you must synchronize all concurrent calls from more
	/// than one thread to this function.
	/// </para>
	/// <para>To call the Unicode version of this function, define DBGHELP_TRANSLATE_TCHAR.</para>
	/// </remarks>
	// https://docs.microsoft.com/en-us/windows/win32/api/dbghelp/nf-dbghelp-symsrvgetfileindexes BOOL IMAGEAPI SymSrvGetFileIndexes(
	// PCSTR File, GUID *Id, PDWORD Val1, PDWORD Val2, DWORD Flags );
	[DllImport(Lib_DbgHelp, SetLastError = true, CharSet = CharSet.Auto)]
	[PInvokeData("dbghelp.h", MSDNShortId = "NF:dbghelp.SymSrvGetFileIndexes")]
	[return: MarshalAs(UnmanagedType.Bool)]
	public static extern bool SymSrvGetFileIndexes([MarshalAs(UnmanagedType.LPTStr)] string File, out Guid Id, out uint Val1, out uint Val2, uint Flags = 0);

	/// <summary>Retrieves the index information for the specified .pdb, .dbg, or image file.</summary>
	/// <param name="File">The name of the file.</param>
	/// <param name="Info">A SYMSRV_INDEX_INFO structure that receives the index information.</param>
	/// <param name="Flags">This parameter is reserved for future use.</param>
	/// <returns>
	/// <para>If the function succeeds, the return value is <c>TRUE</c>.</para>
	/// <para>If the function fails, the return value is <c>FALSE</c>. To retrieve extended error information, call GetLastError.</para>
	/// </returns>
	/// <remarks>
	/// <para>
	/// This function is not for general use. Those writing utilities for the management of files in symbol server stores may use to
	/// this function to predict the relative path the symbol server will look for a file. It is used by srctool.exe to actually
	/// populate symbol server stores. It may also be of use to those looking to find the parameters to feed the SymFindFileInPath function.
	/// </para>
	/// <para>
	/// All DbgHelp functions, such as this one, are single threaded. Therefore, calls from more than one thread to this function will
	/// likely result in unexpected behavior or memory corruption. To avoid this, you must synchronize all concurrent calls from more
	/// than one thread to this function.
	/// </para>
	/// <para>To call the Unicode version of this function, define DBGHELP_TRANSLATE_TCHAR.</para>
	/// </remarks>
	// https://docs.microsoft.com/en-us/windows/win32/api/dbghelp/nf-dbghelp-symsrvgetfileindexinfo BOOL IMAGEAPI
	// SymSrvGetFileIndexInfo( PCSTR File, PSYMSRV_INDEX_INFO Info, DWORD Flags );
	[DllImport(Lib_DbgHelp, SetLastError = true, CharSet = CharSet.Auto)]
	[PInvokeData("dbghelp.h", MSDNShortId = "NF:dbghelp.SymSrvGetFileIndexInfo")]
	[return: MarshalAs(UnmanagedType.Bool)]
	public static extern bool SymSrvGetFileIndexInfo([MarshalAs(UnmanagedType.LPTStr)] string File, ref SYMSRV_INDEX_INFO Info, uint Flags = 0);

	/// <summary>Retrieves the index string for the specified .pdb, .dbg, or image file.</summary>
	/// <param name="hProcess">A handle to a process. This handle must have been previously passed to the SymInitialize function.</param>
	/// <param name="SrvPath">The path to the symbol server.</param>
	/// <param name="File">The name of the file.</param>
	/// <param name="Index">A pointer to a buffer that receives the index string.</param>
	/// <param name="Size">The size of the Index buffer, in characters.</param>
	/// <param name="Flags">This parameter is reserved for future use.</param>
	/// <returns>
	/// <para>If the function succeeds, the return value is <c>TRUE</c>.</para>
	/// <para>If the function fails, the return value is <c>FALSE</c>. To retrieve extended error information, call GetLastError.</para>
	/// </returns>
	/// <remarks>
	/// <para>
	/// This function is not for general use. Those writing utilities for the management of files in symbol server stores may use to
	/// this function to predict the relative path the symbol server will look for a file. It is used by srctool.exe to actually
	/// populate symbol server stores.
	/// </para>
	/// <para>
	/// All DbgHelp functions, such as this one, are single threaded. Therefore, calls from more than one thread to this function will
	/// likely result in unexpected behavior or memory corruption. To avoid this, you must synchronize all concurrent calls from more
	/// than one thread to this function.
	/// </para>
	/// <para>To call the Unicode version of this function, define DBGHELP_TRANSLATE_TCHAR.</para>
	/// </remarks>
	// https://docs.microsoft.com/en-us/windows/win32/api/dbghelp/nf-dbghelp-symsrvgetfileindexstring BOOL IMAGEAPI
	// SymSrvGetFileIndexString( HANDLE hProcess, PCSTR SrvPath, PCSTR File, PSTR Index, size_t Size, DWORD Flags );
	[DllImport(Lib_DbgHelp, SetLastError = true, CharSet = CharSet.Auto)]
	[PInvokeData("dbghelp.h", MSDNShortId = "NF:dbghelp.SymSrvGetFileIndexString")]
	[return: MarshalAs(UnmanagedType.Bool)]
	public static extern bool SymSrvGetFileIndexString(HPROCESS hProcess, [Optional, MarshalAs(UnmanagedType.LPTStr)] string? SrvPath,
		[MarshalAs(UnmanagedType.LPTStr)] string File, [Out, MarshalAs(UnmanagedType.LPTStr)] StringBuilder Index, SizeT Size, uint Flags = 0);

	/// <summary>Retrieves the specified file from the supplement for a symbol store.</summary>
	/// <param name="hProcess">A handle to a process. This handle must have been previously passed to the SymInitialize function.</param>
	/// <param name="SymPath">
	/// The symbol path. The function uses only the symbol stores described in standard syntax for symbol stores. All other paths are
	/// ignored. If this parameter is <c>NULL</c>, the function uses the symbol path set using the SymInitialize or SymSetSearchPath function.
	/// </param>
	/// <param name="Node">The symbol file associated with the supplemental file.</param>
	/// <param name="File">The name of the file.</param>
	/// <returns>
	/// <para>If the function succeeds, the return value is the fully qualified path for the supplemental file.</para>
	/// <para>If the function fails, the return value is <c>NULL</c>. To retrieve extended error information, call GetLastError.</para>
	/// </returns>
	/// <remarks>
	/// <para>For more information on supplemental files, see SymSrvStoreSupplement.</para>
	/// <para>
	/// This function returns a pointer to a buffer that may be reused by another function. Therefore, be sure to copy the data returned
	/// to another buffer immediately.
	/// </para>
	/// <para>
	/// All DbgHelp functions, such as this one, are single threaded. Therefore, calls from more than one thread to this function will
	/// likely result in unexpected behavior or memory corruption. To avoid this, you must synchronize all concurrent calls from more
	/// than one thread to this function.
	/// </para>
	/// <para>To call the Unicode version of this function, define DBGHELP_TRANSLATE_TCHAR.</para>
	/// </remarks>
	// https://docs.microsoft.com/en-us/windows/win32/api/dbghelp/nf-dbghelp-symsrvgetsupplement PCSTR IMAGEAPI SymSrvGetSupplement(
	// HANDLE hProcess, PCSTR SymPath, PCSTR Node, PCSTR File );
	[DllImport(Lib_DbgHelp, SetLastError = true, CharSet = CharSet.Auto)]
	[PInvokeData("dbghelp.h", MSDNShortId = "NF:dbghelp.SymSrvGetSupplement")]
	[return: MarshalAs(UnmanagedType.LPTStr)]
	public static extern string SymSrvGetSupplement(HPROCESS hProcess, [Optional, MarshalAs(UnmanagedType.LPTStr)] string? SymPath,
		[MarshalAs(UnmanagedType.LPTStr)] string Node, [MarshalAs(UnmanagedType.LPTStr)] string File);

	/// <summary>Determines whether the specified path points to a symbol store.</summary>
	/// <param name="hProcess">
	/// The handle of a process that you previously passed to the SymInitialize function. If this parameter is set to <c>NULL</c>, the
	/// function determines only whether the store exists; otherwise, the function determines whether the store exists and contains a
	/// process entry for the specified process handle.
	/// </param>
	/// <param name="path">
	/// The path to a symbol store. The path can specify the default symbol store (for example, SRV*), point to an HTTP or HTTPS symbol
	/// server, or specify a UNC, absolute, or relative path to the store.
	/// </param>
	/// <returns>
	/// If the path specifies a symbol store, the function returns <c>TRUE</c>. Otherwise, it returns <c>FALSE</c>. To get extended
	/// error information, call the GetLastError function.
	/// </returns>
	/// <remarks>
	/// <para>
	/// If the path points to the default symbol store (for example, SRV*) or to an HTTP or HTTPS symbol server, the function assumes
	/// the store exists.
	/// </para>
	/// <para>
	/// If there is a proxy computer between the client computer and the server, the version of the SymSrv.dll on the proxy cannot be
	/// less than the version that is on the client.
	/// </para>
	/// <para>
	/// All DbgHelp functions, such as this one, are single threaded. Therefore, calls from more than one thread to this function will
	/// likely result in unexpected behavior or memory corruption. To avoid this, you must synchronize all concurrent calls from more
	/// than one thread to this function.
	/// </para>
	/// <para>To call the Unicode version of this function, define DBGHELP_TRANSLATE_TCHAR.</para>
	/// </remarks>
	// https://docs.microsoft.com/en-us/windows/win32/api/dbghelp/nf-dbghelp-symsrvisstore BOOL IMAGEAPI SymSrvIsStore( HANDLE hProcess,
	// PCSTR path );
	[DllImport(Lib_DbgHelp, SetLastError = true, CharSet = CharSet.Auto)]
	[PInvokeData("dbghelp.h", MSDNShortId = "NF:dbghelp.SymSrvIsStore")]
	[return: MarshalAs(UnmanagedType.Bool)]
	public static extern bool SymSrvIsStore([Optional] HPROCESS hProcess, [MarshalAs(UnmanagedType.LPTStr)] string path);

	/// <summary>Stores a file in the specified symbol store.</summary>
	/// <param name="hProcess">A handle to a process. This handle must have been previously passed to the SymInitialize function.</param>
	/// <param name="SrvPath">The symbol store.</param>
	/// <param name="File">The name of the file.</param>
	/// <param name="Flags">
	/// <para>The flags that control the function. This parameter can be one of the following values.</para>
	/// <list type="table">
	/// <listheader>
	/// <term>Value</term>
	/// <term>Meaning</term>
	/// </listheader>
	/// <item>
	/// <term>SYMSTOREOPT_COMPRESS 0x01</term>
	/// <term>Compress the file.</term>
	/// </item>
	/// <item>
	/// <term>SYMSTOREOPT_OVERWRITE 0x02</term>
	/// <term>Overwrite the file if it exists.</term>
	/// </item>
	/// <item>
	/// <term>SYMSTOREOPT_PASS_IF_EXISTS 0x40</term>
	/// <term>Do not report an error if the file already exists in the symbol store.</term>
	/// </item>
	/// <item>
	/// <term>SYMSTOREOPT_POINTER 0x08</term>
	/// <term>Store in File.ptr.</term>
	/// </item>
	/// <item>
	/// <term>SYMSTOREOPT_RETURNINDEX 0x04</term>
	/// <term>Return the index only.</term>
	/// </item>
	/// </list>
	/// </param>
	/// <returns>
	/// <para>
	/// If the function succeeds, the return value is a pointer to a null-terminated string that specifies the full-qualified path to
	/// the stored file.
	/// </para>
	/// <para>If the function fails, the return value is <c>NULL</c>. To retrieve extended error information, call GetLastError.</para>
	/// </returns>
	/// <remarks>
	/// <para>
	/// All DbgHelp functions, such as this one, are single threaded. Therefore, calls from more than one thread to this function will
	/// likely result in unexpected behavior or memory corruption. To avoid this, you must synchronize all concurrent calls from more
	/// than one thread to this function.
	/// </para>
	/// <para>
	/// This function returns a pointer to a buffer that may be reused by another function. Therefore, be sure to copy the data returned
	/// to another buffer immediately.
	/// </para>
	/// <para>To call the Unicode version of this function, define DBGHELP_TRANSLATE_TCHAR.</para>
	/// </remarks>
	// https://docs.microsoft.com/en-us/windows/win32/api/dbghelp/nf-dbghelp-symsrvstorefile PCSTR IMAGEAPI SymSrvStoreFile( HANDLE
	// hProcess, PCSTR SrvPath, PCSTR File, DWORD Flags );
	[DllImport(Lib_DbgHelp, SetLastError = true, CharSet = CharSet.Auto)]
	[PInvokeData("dbghelp.h", MSDNShortId = "NF:dbghelp.SymSrvStoreFile")]
	[return: MarshalAs(UnmanagedType.LPTStr)]
	public static extern string? SymSrvStoreFile(HPROCESS hProcess, [Optional, MarshalAs(UnmanagedType.LPTStr)] string? SrvPath,
		[MarshalAs(UnmanagedType.LPTStr)] string File, SYMSTOREOPT Flags);

	/// <summary>
	/// Stores a file in the specified supplement to a symbol store. The file is typically associated with a file in the symbol server.
	/// </summary>
	/// <param name="hProcess">A handle to a process. This handle must have been previously passed to the SymInitialize function.</param>
	/// <param name="SrvPath">TBD</param>
	/// <param name="Node">The symbol file associated with the supplemental file.</param>
	/// <param name="File">The name of the file.</param>
	/// <param name="Flags">
	/// If this parameter is <c>SYMSTOREOPT_COMPRESS</c>, the file is compressed in the symbol store. Currently, there are no other
	/// supported values.
	/// </param>
	/// <returns>
	/// <para>If the function succeeds, the return value is the fully qualified path for the supplemental file.</para>
	/// <para>If the function fails, the return value is <c>NULL</c>. To retrieve extended error information, call GetLastError.</para>
	/// </returns>
	/// <remarks>
	/// <para>An important use for this function is to store delta files. For more information, see SymSrvDeltaName.</para>
	/// <para>
	/// This function returns a pointer to a buffer that may be reused by another function. Therefore, be sure to copy the data returned
	/// to another buffer immediately.
	/// </para>
	/// <para>
	/// The symbol server stores supplemental files with the same extension in a common directory. For example, Sup1.xml would be stored
	/// in the following directory: SymPath\supplement&lt;i&gt;Node\xml.
	/// </para>
	/// <para>
	/// The administrator of a store can prevent users from writing supplemental files by creating a read-only file in the root of the
	/// store named Supplement. Alternatively, the administrator can create the supplement directory and use ACLs to control access.
	/// </para>
	/// <para>
	/// All DbgHelp functions, such as this one, are single threaded. Therefore, calls from more than one thread to this function will
	/// likely result in unexpected behavior or memory corruption. To avoid this, you must synchronize all concurrent calls from more
	/// than one thread to this function.
	/// </para>
	/// <para>To call the Unicode version of this function, define DBGHELP_TRANSLATE_TCHAR.</para>
	/// </remarks>
	// https://docs.microsoft.com/en-us/windows/win32/api/dbghelp/nf-dbghelp-symsrvstoresupplement PCSTR IMAGEAPI SymSrvStoreSupplement(
	// HANDLE hProcess, PCSTR SrvPath, PCSTR Node, PCSTR File, DWORD Flags );
	[DllImport(Lib_DbgHelp, SetLastError = true, CharSet = CharSet.Auto)]
	[PInvokeData("dbghelp.h", MSDNShortId = "NF:dbghelp.SymSrvStoreSupplement")]
	[return: MarshalAs(UnmanagedType.LPTStr)]
	public static extern string? SymSrvStoreSupplement(HPROCESS hProcess, [Optional, MarshalAs(UnmanagedType.LPTStr)] string? SrvPath,
		[MarshalAs(UnmanagedType.LPTStr)] string Node, [MarshalAs(UnmanagedType.LPTStr)] string File, SYMSTOREOPT Flags);

	/// <summary>
	/// <para>Undecorates a decorated C++ symbol name.</para>
	/// <para>Applications can also use the UnDecorateSymbolName function.</para>
	/// </summary>
	/// <param name="sym">A pointer to an IMAGEHLP_SYMBOL64 structure that specifies the symbol to be undecorated.</param>
	/// <param name="UnDecName">A pointer to a buffer that receives the undecorated name.</param>
	/// <param name="UnDecNameLength">The size of the UnDecName buffer, in characters.</param>
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
	/// <para>
	/// This function supersedes the <c>SymUnDName</c> function. For more information, see Updated Platform Support. <c>SymUnDName</c>
	/// is defined as follows in Dbghelp.h.
	/// </para>
	/// <para>
	/// <code>#if !defined(_IMAGEHLP_SOURCE_) &amp;&amp; defined(_IMAGEHLP64) #define SymUnDName SymUnDName64 #else BOOL IMAGEAPI SymUnDName( __in PIMAGEHLP_SYMBOL sym, __out_ecount(UnDecNameLength) PSTR UnDecName, __in DWORD UnDecNameLength ); #endif</code>
	/// </para>
	/// </remarks>
	// https://docs.microsoft.com/en-us/windows/win32/api/dbghelp/nf-dbghelp-symundname BOOL IMAGEAPI SymUnDName( PIMAGEHLP_SYMBOL sym,
	// PSTR UnDecName, DWORD UnDecNameLength );
	[DllImport(Lib_DbgHelp, SetLastError = true, ExactSpelling = true)]
	[PInvokeData("dbghelp.h", MSDNShortId = "NF:dbghelp.SymUnDName")]
	[return: MarshalAs(UnmanagedType.Bool)]
	public static extern bool SymUnDName([In] SafeIMAGEHLP_SYMBOL sym, [Out, MarshalAs(UnmanagedType.LPStr)] StringBuilder UnDecName, uint UnDecNameLength);

	/// <summary>
	/// <para>Undecorates a decorated C++ symbol name.</para>
	/// <para>Applications can also use the UnDecorateSymbolName function.</para>
	/// </summary>
	/// <param name="sym">A pointer to an IMAGEHLP_SYMBOL64 structure that specifies the symbol to be undecorated.</param>
	/// <param name="UnDecName">A pointer to a buffer that receives the undecorated name.</param>
	/// <param name="UnDecNameLength">The size of the UnDecName buffer, in characters.</param>
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
	/// <para>
	/// This function supersedes the <c>SymUnDName</c> function. For more information, see Updated Platform Support. <c>SymUnDName</c>
	/// is defined as follows in Dbghelp.h.
	/// </para>
	/// <para>
	/// <code>#if !defined(_IMAGEHLP_SOURCE_) &amp;&amp; defined(_IMAGEHLP64) #define SymUnDName SymUnDName64 #else BOOL IMAGEAPI SymUnDName( __in PIMAGEHLP_SYMBOL sym, __out_ecount(UnDecNameLength) PSTR UnDecName, __in DWORD UnDecNameLength ); #endif</code>
	/// </para>
	/// </remarks>
	// https://docs.microsoft.com/en-us/windows/win32/api/dbghelp/nf-dbghelp-symundname64 BOOL IMAGEAPI SymUnDName64( PIMAGEHLP_SYMBOL64
	// sym, PSTR UnDecName, DWORD UnDecNameLength );
	[DllImport(Lib_DbgHelp, SetLastError = true, ExactSpelling = true)]
	[PInvokeData("dbghelp.h", MSDNShortId = "NF:dbghelp.SymUnDName64")]
	[return: MarshalAs(UnmanagedType.Bool)]
	public static extern bool SymUnDName64([In] SafeIMAGEHLP_SYMBOL64 sym, [Out, MarshalAs(UnmanagedType.LPStr)] StringBuilder UnDecName, uint UnDecNameLength);

	/// <summary>Unloads the symbol table.</summary>
	/// <param name="hProcess">A handle to the process that was originally passed to the SymInitialize function.</param>
	/// <param name="BaseOfDll">The base address of the module that is to be unloaded.</param>
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
	/// <para>
	/// This function supersedes the <c>SymUnloadedModule</c> function. For more information, see Updated Platform Support.
	/// <c>SymUnloadedModule</c> is defined as follows in Dbghelp.h.
	/// </para>
	/// <para>
	/// <code>#if !defined(_IMAGEHLP_SOURCE_) &amp;&amp; defined(_IMAGEHLP64) #define SymUnloadModule SymUnloadModule64 #else BOOL IMAGEAPI SymUnloadModule( __in HANDLE hProcess, __in DWORD BaseOfDll ); #endif</code>
	/// </para>
	/// <para>Examples</para>
	/// <para>For an example, see Unloading a Symbol Module.</para>
	/// </remarks>
	// https://docs.microsoft.com/en-us/windows/win32/api/dbghelp/nf-dbghelp-symunloadmodule BOOL IMAGEAPI SymUnloadModule( HANDLE
	// hProcess, DWORD BaseOfDll );
	[DllImport(Lib_DbgHelp, SetLastError = true, ExactSpelling = true)]
	[PInvokeData("dbghelp.h", MSDNShortId = "NF:dbghelp.SymUnloadModule")]
	[return: MarshalAs(UnmanagedType.Bool)]
	public static extern bool SymUnloadModule(HPROCESS hProcess, uint BaseOfDll);

	/// <summary>Unloads the symbol table.</summary>
	/// <param name="hProcess">A handle to the process that was originally passed to the SymInitialize function.</param>
	/// <param name="BaseOfDll">The base address of the module that is to be unloaded.</param>
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
	/// <para>
	/// This function supersedes the <c>SymUnloadedModule</c> function. For more information, see Updated Platform Support.
	/// <c>SymUnloadedModule</c> is defined as follows in Dbghelp.h.
	/// </para>
	/// <para>
	/// <code>#if !defined(_IMAGEHLP_SOURCE_) &amp;&amp; defined(_IMAGEHLP64) #define SymUnloadModule SymUnloadModule64 #else BOOL IMAGEAPI SymUnloadModule( __in HANDLE hProcess, __in DWORD BaseOfDll ); #endif</code>
	/// </para>
	/// <para>Examples</para>
	/// <para>For an example, see Unloading a Symbol Module.</para>
	/// </remarks>
	// https://docs.microsoft.com/en-us/windows/win32/api/dbghelp/nf-dbghelp-symunloadmodule64 BOOL IMAGEAPI SymUnloadModule64( HANDLE
	// hProcess, DWORD64 BaseOfDll );
	[DllImport(Lib_DbgHelp, SetLastError = true, ExactSpelling = true)]
	[PInvokeData("dbghelp.h", MSDNShortId = "NF:dbghelp.SymUnloadModule64")]
	[return: MarshalAs(UnmanagedType.Bool)]
	public static extern bool SymUnloadModule64(HPROCESS hProcess, ulong BaseOfDll);

	/// <summary>
	/// A managed life-cycle symbol handler for a process which calls <see cref="SymInitialize"/> at construction and <see
	/// cref="SymCleanup"/> at disposal.
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
		public ProcessSymbolHandler(HPROCESS hProcess, string? UserSearchPath = null, bool fInvadeProcess = true) =>
			SymInitialize(hProc = hProcess, UserSearchPath, fInvadeProcess);

		/// <summary>Performs an implicit conversion from <see cref="ProcessSymbolHandler"/> to <see cref="HPROCESS"/>.</summary>
		/// <param name="h">The <see cref="ProcessSymbolHandler"/> instance.</param>
		/// <returns>The resulting <see cref="HPROCESS"/> instance from the conversion.</returns>
		public static implicit operator HPROCESS(ProcessSymbolHandler h) => h.hProc;

		/// <summary>Deallocates all resources associated with this process handle.</summary>
		public void Dispose() => SymCleanup(hProc);

		/// <summary>Refreshes the module list for the process.</summary>
		public void RefreshModuleList() => SymRefreshModuleList(hProc);
	}
}