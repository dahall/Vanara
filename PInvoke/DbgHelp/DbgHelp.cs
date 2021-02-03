using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using Vanara.Extensions;
using static Vanara.PInvoke.Kernel32;

namespace Vanara.PInvoke
{
	/// <summary>Items from the DbgHelp.dll</summary>
	public static partial class DbgHelp
	{
		private const string Lib_DbgHelp = "DbgHelp.dll";

		/// <summary>
		/// <para>An application-defined callback function used with the EnumDirTree function. It is called every time a match is found.</para>
		/// <para>
		/// The <c>PENUMDIRTREE_CALLBACK</c> and <c>PENUMDIRTREE_CALLBACKW</c> types define a pointer to this callback function.
		/// EnumDirTreeProc is a placeholder for the application-defined function name.
		/// </para>
		/// </summary>
		/// <param name="FilePath">A pointer to a buffer that receives the full path of the file that is found.</param>
		/// <param name="CallerData">
		/// A user-defined value specified in EnumDirTree, or <c>NULL</c>. Typically, this parameter is used by an application to pass a
		/// pointer to a data structure that enables the callback function to establish some context.
		/// </param>
		/// <returns>
		/// <para>To continue enumeration, the callback function must return <c>FALSE</c>.</para>
		/// <para>To stop enumeration, the callback function must return <c>TRUE</c>.</para>
		/// </returns>
		// https://docs.microsoft.com/en-us/windows/win32/api/dbghelp/nc-dbghelp-penumdirtree_callback PENUMDIRTREE_CALLBACK
		// PenumdirtreeCallback; BOOL PenumdirtreeCallback( PCSTR FilePath, PVOID CallerData ) {...}
		[UnmanagedFunctionPointer(CallingConvention.Winapi, CharSet = CharSet.Auto)]
		[PInvokeData("dbghelp.h", MSDNShortId = "NC:dbghelp.PENUMDIRTREE_CALLBACK")]
		[return: MarshalAs(UnmanagedType.Bool)]
		public delegate bool PENUMDIRTREE_CALLBACK([MarshalAs(UnmanagedType.LPTStr)] string FilePath, [In, Optional] IntPtr CallerData);

		/// <summary>
		/// <para>An application-defined callback function used with the EnumerateLoadedModules64 function.</para>
		/// <para>
		/// The <c>PENUMLOADED_MODULES_CALLBACK64</c> and <c>PENUMLOADED_MODULES_CALLBACKW64</c> types define a pointer to this callback
		/// function. EnumerateLoadedModulesProc64 is a placeholder for the application-defined function name.
		/// </para>
		/// </summary>
		/// <param name="ModuleName">The name of the enumerated module.</param>
		/// <param name="ModuleBase">
		/// The base address of the module. Note that it is possible for this address to become invalid (for example, the module may be
		/// unloaded). Use exception handling when accessing the address or passing the address to another function to prevent an access
		/// violation from occurring.
		/// </param>
		/// <param name="ModuleSize">The size of the module, in bytes.</param>
		/// <param name="UserContext">Optional user-defined data. This value is passed from EnumerateLoadedModules64.</param>
		/// <returns>
		/// <para>To continue enumeration, the callback function must return <c>TRUE</c>.</para>
		/// <para>To stop enumeration, the callback function must return <c>FALSE</c>.</para>
		/// </returns>
		/// <remarks>
		/// <para>
		/// This callback function supersedes the PENUMLOADED_MODULES_CALLBACK callback function. PENUMLOADED_MODULES_CALLBACK is defined as
		/// follows in DbgHelp.h.
		/// </para>
		/// <para>
		/// <code>#if !defined(_IMAGEHLP_SOURCE_) &amp;&amp; defined(_IMAGEHLP64) #define PENUMLOADED_MODULES_CALLBACK PENUMLOADED_MODULES_CALLBACK64 #else typedef BOOL (CALLBACK *PENUMLOADED_MODULES_CALLBACK)( __in PCSTR ModuleName, __in ULONG ModuleBase, __in ULONG ModuleSize, __in_opt PVOID UserContext ); #endif</code>
		/// </para>
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows/win32/api/dbghelp/nc-dbghelp-penumloaded_modules_callback PENUMLOADED_MODULES_CALLBACK
		// PenumloadedModulesCallback; BOOL PenumloadedModulesCallback( PCSTR ModuleName, ULONG ModuleBase, ULONG ModuleSize, PVOID
		// UserContext ) {...}
		[UnmanagedFunctionPointer(CallingConvention.Winapi, CharSet = CharSet.Ansi)]
		[PInvokeData("dbghelp.h", MSDNShortId = "NC:dbghelp.PENUMLOADED_MODULES_CALLBACK")]
		[return: MarshalAs(UnmanagedType.Bool)]
		public delegate bool PENUMLOADED_MODULES_CALLBACK([MarshalAs(UnmanagedType.LPStr)] string ModuleName, [In] uint ModuleBase, [In] uint ModuleSize, [In, Optional] IntPtr UserContext);

		/// <summary>
		/// <para>An application-defined callback function used with the EnumerateLoadedModules64 function.</para>
		/// <para>
		/// The <c>PENUMLOADED_MODULES_CALLBACK64</c> and <c>PENUMLOADED_MODULES_CALLBACKW64</c> types define a pointer to this callback
		/// function. EnumerateLoadedModulesProc64 is a placeholder for the application-defined function name.
		/// </para>
		/// </summary>
		/// <param name="ModuleName">The name of the enumerated module.</param>
		/// <param name="ModuleBase">
		/// The base address of the module. Note that it is possible for this address to become invalid (for example, the module may be
		/// unloaded). Use exception handling when accessing the address or passing the address to another function to prevent an access
		/// violation from occurring.
		/// </param>
		/// <param name="ModuleSize">The size of the module, in bytes.</param>
		/// <param name="UserContext">Optional user-defined data. This value is passed from EnumerateLoadedModules64.</param>
		/// <returns>
		/// <para>To continue enumeration, the callback function must return <c>TRUE</c>.</para>
		/// <para>To stop enumeration, the callback function must return <c>FALSE</c>.</para>
		/// </returns>
		/// <remarks>
		/// <para>
		/// This callback function supersedes the PENUMLOADED_MODULES_CALLBACK callback function. PENUMLOADED_MODULES_CALLBACK is defined as
		/// follows in DbgHelp.h.
		/// </para>
		/// <para>
		/// <code>#if !defined(_IMAGEHLP_SOURCE_) &amp;&amp; defined(_IMAGEHLP64) #define PENUMLOADED_MODULES_CALLBACK PENUMLOADED_MODULES_CALLBACK64 #else typedef BOOL (CALLBACK *PENUMLOADED_MODULES_CALLBACK)( __in PCSTR ModuleName, __in ULONG ModuleBase, __in ULONG ModuleSize, __in_opt PVOID UserContext ); #endif</code>
		/// </para>
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows/win32/api/dbghelp/nc-dbghelp-penumloaded_modules_callbackw64
		// PENUMLOADED_MODULES_CALLBACKW64 PenumloadedModulesCallbackw64; BOOL PenumloadedModulesCallbackw64( PCWSTR ModuleName, DWORD64 ModuleBase, ULONG ModuleSize, PVOID UserContext ) {...}
		[PInvokeData("dbghelp.h", MSDNShortId = "NC:dbghelp.PENUMLOADED_MODULES_CALLBACKW64")]
		[UnmanagedFunctionPointer(CallingConvention.Winapi, CharSet = CharSet.Unicode)]
		[return: MarshalAs(UnmanagedType.Bool)]
		public delegate bool PENUMLOADED_MODULES_CALLBACKW64([MarshalAs(UnmanagedType.LPWStr)] string ModuleName, ulong ModuleBase, uint ModuleSize, [In, Optional] IntPtr UserContext);

		/// <summary>
		/// <para>
		/// An application-defined callback function used with the FindDebugInfoFileEx function. It verifies whether the symbol file located
		/// by <c>FindDebugInfoFileEx</c> is the correct symbol file.
		/// </para>
		/// <para>
		/// The <c>PFIND_DEBUG_FILE_CALLBACK</c> and <c>PFIND_DEBUG_FILE_CALLBACKW</c> types define a pointer to this callback function.
		/// <c>FindDebugInfoFileProc</c> is a placeholder for the application-defined function name.
		/// </para>
		/// </summary>
		/// <param name="FileHandle">A handle to the symbol file.</param>
		/// <param name="FileName">The name of the symbol file.</param>
		/// <param name="CallerData">Optional user-defined data. This parameter can be <c>NULL</c>.</param>
		/// <returns>If the symbol file is valid, return <c>TRUE</c>. Otherwise, return <c>FALSE</c>.</returns>
		/// <remarks>
		/// One way to verify the symbol file is to compare its timestamp to the timestamp in the image. To retrieve the timestamp of the
		/// image, use the GetTimestampForLoadedLibrary function. To retrieve the timestamp of the symbol file, use the SymGetModuleInfo64 function.
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows/win32/api/dbghelp/nc-dbghelp-pfind_debug_file_callback PFIND_DEBUG_FILE_CALLBACK
		// PfindDebugFileCallback; BOOL PfindDebugFileCallback( HANDLE FileHandle, PCSTR FileName, PVOID CallerData ) {...}
		[UnmanagedFunctionPointer(CallingConvention.Winapi)]
		[PInvokeData("dbghelp.h", MSDNShortId = "NC:dbghelp.PFIND_DEBUG_FILE_CALLBACK")]
		[return: MarshalAs(UnmanagedType.Bool)]
		public delegate bool PFIND_DEBUG_FILE_CALLBACK(HFILE FileHandle, [MarshalAs(UnmanagedType.LPStr)] string FileName, [In, Optional] IntPtr CallerData);

		/// <summary>
		/// <para>
		/// An application-defined callback function used with the FindExecutableImageEx function. It verifies whether the executable file
		/// found by <c>FindExecutableImageEx</c> is the correct executable file.
		/// </para>
		/// <para>
		/// The <c>PFIND_EXE_FILE_CALLBACK</c> and <c>PFIND_EXE_FILE_CALLBACKW</c> types define a pointer to this callback function.
		/// <c>FindExecutableImageProc</c> is a placeholder for the application-defined function name.
		/// </para>
		/// </summary>
		/// <param name="FileHandle">A handle to the executable file.</param>
		/// <param name="FileName">The name of the executable file.</param>
		/// <param name="CallerData">Optional user-defined data. This parameter can be <c>NULL</c>.</param>
		/// <returns>If the executable file is valid, return <c>TRUE</c>. Otherwise, return <c>FALSE</c>.</returns>
		// https://docs.microsoft.com/en-us/windows/win32/api/dbghelp/nc-dbghelp-pfind_exe_file_callback PFIND_EXE_FILE_CALLBACK
		// PfindExeFileCallback; BOOL PfindExeFileCallback( HANDLE FileHandle, PCSTR FileName, PVOID CallerData ) {...}
		[UnmanagedFunctionPointer(CallingConvention.Winapi, CharSet = CharSet.Auto)]
		[PInvokeData("dbghelp.h", MSDNShortId = "NC:dbghelp.PFIND_EXE_FILE_CALLBACK")]
		[return: MarshalAs(UnmanagedType.Bool)]
		public delegate bool PFIND_EXE_FILE_CALLBACK(HFILE FileHandle, [MarshalAs(UnmanagedType.LPTStr)] string FileName, [In, Optional] IntPtr CallerData);

		/// <summary>
		/// <para>
		/// An application-defined callback function used with the StackWalk64 function. It provides access to the run-time function table
		/// for the process.
		/// </para>
		/// <para>
		/// The <c>PFUNCTION_TABLE_ACCESS_ROUTINE64</c> type defines a pointer to this callback function. <c>FunctionTableAccessProc64</c>
		/// is a placeholder for the application-defined function name.
		/// </para>
		/// </summary>
		/// <param name="hProcess">A handle to the process for which the stack trace is generated.</param>
		/// <param name="AddrBase">The address of the instruction to be located.</param>
		/// <returns>
		/// The function returns a pointer to the run-time function table. On an x86 computer, this is a pointer to an FPO_DATA structure.
		/// On an Alpha computer, this is a pointer to an IMAGE_FUNCTION_ENTRY structure.
		/// </returns>
		/// <remarks>
		/// <para>
		/// This callback function supersedes the PFUNCTION_TABLE_ACCESS_ROUTINE callback function. PFUNCTION_TABLE_ACCESS_ROUTINE is
		/// defined as follows in DbgHelp.h.
		/// </para>
		/// <para>
		/// <code>#if !defined(_IMAGEHLP_SOURCE_) &amp;&amp; defined(_IMAGEHLP64) #define PFUNCTION_TABLE_ACCESS_ROUTINE PFUNCTION_TABLE_ACCESS_ROUTINE64 #else typedef PVOID (__stdcall *PFUNCTION_TABLE_ACCESS_ROUTINE)( __in HANDLE hProcess, __in DWORD AddrBase ); #endif</code>
		/// </para>
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows/win32/api/dbghelp/nc-dbghelp-pfunction_table_access_routine
		// PFUNCTION_TABLE_ACCESS_ROUTINE PfunctionTableAccessRoutine; PVOID PfunctionTableAccessRoutine( HANDLE hProcess, DWORD AddrBase ) {...}
		[UnmanagedFunctionPointer(CallingConvention.Winapi)]
		[PInvokeData("dbghelp.h", MSDNShortId = "NC:dbghelp.PFUNCTION_TABLE_ACCESS_ROUTINE")]
		public delegate IntPtr PFUNCTION_TABLE_ACCESS_ROUTINE(HPROCESS hProcess, uint AddrBase);

		/// <summary>
		/// <para>
		/// An application-defined callback function used with the StackWalk64 function. It provides access to the run-time function table
		/// for the process.
		/// </para>
		/// <para>
		/// The <c>PFUNCTION_TABLE_ACCESS_ROUTINE64</c> type defines a pointer to this callback function. <c>FunctionTableAccessProc64</c>
		/// is a placeholder for the application-defined function name.
		/// </para>
		/// </summary>
		/// <param name="ahProcess"/>
		/// <param name="AddrBase">The address of the instruction to be located.</param>
		/// <returns>
		/// The function returns a pointer to the run-time function table. On an x86 computer, this is a pointer to an FPO_DATA structure.
		/// On an Alpha computer, this is a pointer to an IMAGE_FUNCTION_ENTRY structure.
		/// </returns>
		/// <remarks>
		/// <para>
		/// This callback function supersedes the PFUNCTION_TABLE_ACCESS_ROUTINE callback function. PFUNCTION_TABLE_ACCESS_ROUTINE is
		/// defined as follows in DbgHelp.h.
		/// </para>
		/// <para>
		/// <code>#if !defined(_IMAGEHLP_SOURCE_) &amp;&amp; defined(_IMAGEHLP64) #define PFUNCTION_TABLE_ACCESS_ROUTINE PFUNCTION_TABLE_ACCESS_ROUTINE64 #else typedef PVOID (__stdcall *PFUNCTION_TABLE_ACCESS_ROUTINE)( __in HANDLE hProcess, __in DWORD AddrBase ); #endif</code>
		/// </para>
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows/win32/api/dbghelp/nc-dbghelp-pfunction_table_access_routine64
		// PFUNCTION_TABLE_ACCESS_ROUTINE64 PfunctionTableAccessRoutine64; PVOID PfunctionTableAccessRoutine64( HANDLE ahProcess, DWORD64
		// AddrBase ) {...}
		[UnmanagedFunctionPointer(CallingConvention.Winapi)]
		[PInvokeData("dbghelp.h", MSDNShortId = "NC:dbghelp.PFUNCTION_TABLE_ACCESS_ROUTINE64")]
		public delegate IntPtr PFUNCTION_TABLE_ACCESS_ROUTINE64(HPROCESS ahProcess, ulong AddrBase);

		/// <summary>
		/// <para>
		/// An application-defined callback function used with the StackWalk64 function. It is called when <c>StackWalk64</c> needs a module
		/// base address for a given virtual address.
		/// </para>
		/// <para>
		/// The <c>PGET_MODULE_BASE_ROUTINE64</c> type defines a pointer to this callback function. <c>GetModuleBaseProc64</c> is a
		/// placeholder for the application-defined function name.
		/// </para>
		/// </summary>
		/// <param name="hProcess">A handle to the process for which the stack trace is generated.</param>
		/// <param name="Address">An address within the module image to be located.</param>
		/// <returns>The function returns the base address of the module.</returns>
		/// <remarks>
		/// <para>
		/// This callback function supersedes the PGET_MODULE_BASE_ROUTINE callback function. PGET_MODULE_BASE_ROUTINE is defined as follows
		/// in DbgHelp.h.
		/// </para>
		/// <para>
		/// <code>#if !defined(_IMAGEHLP_SOURCE_) &amp;&amp; defined(_IMAGEHLP64) #define PGET_MODULE_BASE_ROUTINE PGET_MODULE_BASE_ROUTINE64 #else typedef DWORD (__stdcall *PGET_MODULE_BASE_ROUTINE)( __in HANDLE hProcess, __in DWORD Address ); #endif</code>
		/// </para>
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows/win32/api/dbghelp/nc-dbghelp-pget_module_base_routine PGET_MODULE_BASE_ROUTINE
		// PgetModuleBaseRoutine; DWORD PgetModuleBaseRoutine( HANDLE hProcess, DWORD Address ) {...}
		[UnmanagedFunctionPointer(CallingConvention.Winapi)]
		[PInvokeData("dbghelp.h", MSDNShortId = "NC:dbghelp.PGET_MODULE_BASE_ROUTINE")]
		public delegate uint PGET_MODULE_BASE_ROUTINE(HPROCESS hProcess, uint Address);

		/// <summary>
		/// <para>
		/// An application-defined callback function used with the StackWalk64 function. It is called when <c>StackWalk64</c> needs a module
		/// base address for a given virtual address.
		/// </para>
		/// <para>
		/// The <c>PGET_MODULE_BASE_ROUTINE64</c> type defines a pointer to this callback function. <c>GetModuleBaseProc64</c> is a
		/// placeholder for the application-defined function name.
		/// </para>
		/// </summary>
		/// <param name="hProcess">A handle to the process for which the stack trace is generated.</param>
		/// <param name="Address">An address within the module image to be located.</param>
		/// <returns>The function returns the base address of the module.</returns>
		/// <remarks>
		/// <para>
		/// This callback function supersedes the PGET_MODULE_BASE_ROUTINE callback function. PGET_MODULE_BASE_ROUTINE is defined as follows
		/// in DbgHelp.h.
		/// </para>
		/// <para>
		/// <code>#if !defined(_IMAGEHLP_SOURCE_) &amp;&amp; defined(_IMAGEHLP64) #define PGET_MODULE_BASE_ROUTINE PGET_MODULE_BASE_ROUTINE64 #else typedef DWORD (__stdcall *PGET_MODULE_BASE_ROUTINE)( __in HANDLE hProcess, __in DWORD Address ); #endif</code>
		/// </para>
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows/win32/api/dbghelp/nc-dbghelp-pget_module_base_routine64 PGET_MODULE_BASE_ROUTINE64
		// PgetModuleBaseRoutine64; DWORD64 PgetModuleBaseRoutine64( HANDLE hProcess, DWORD64 Address ) {...}
		[UnmanagedFunctionPointer(CallingConvention.Winapi)]
		[PInvokeData("dbghelp.h", MSDNShortId = "NC:dbghelp.PGET_MODULE_BASE_ROUTINE64")]
		public delegate ulong PGET_MODULE_BASE_ROUTINE64(HPROCESS hProcess, ulong Address);

		/// <summary>
		/// <para>
		/// An application-defined callback function used with the StackWalk64 function. It is called when <c>StackWalk64</c> needs to read
		/// memory from the address space of the process.
		/// </para>
		/// <para>
		/// The <c>PREAD_PROCESS_MEMORY_ROUTINE64</c> type defines a pointer to this callback function. <c>ReadProcessMemoryProc64</c> is a
		/// placeholder for the application-defined function name.
		/// </para>
		/// </summary>
		/// <param name="hProcess">A handle to the process for which the stack trace is generated.</param>
		/// <param name="lpBaseAddress">The base address of the memory to be read.</param>
		/// <param name="lpBuffer">A pointer to a buffer that receives the memory to be read.</param>
		/// <param name="nSize">The size of the memory to be read, in bytes.</param>
		/// <param name="lpNumberOfBytesRead">A pointer to a variable that receives the number of bytes actually read.</param>
		/// <returns>
		/// If the function succeeds, the return value should be <c>TRUE</c>. If the function fails, the return value should be <c>FALSE</c>.
		/// </returns>
		/// <remarks>
		/// <para>In many cases, this function can best service the callback with a corresponding call to ReadProcessMemory.</para>
		/// <para>
		/// This function should read as much of the requested memory as possible. The StackWalk64 function handles the case where only part
		/// of the requested memory is read.
		/// </para>
		/// <para>
		/// This callback function supersedes the PREAD_PROCESS_MEMORY_ROUTINE callback function. PREAD_PROCESS_MEMORY_ROUTINE is defined as
		/// follows in Dbghelp.h.
		/// </para>
		/// <para>
		/// <code>#if !defined(_IMAGEHLP_SOURCE_) &amp;&amp; defined(_IMAGEHLP64) #define PREAD_PROCESS_MEMORY_ROUTINE PREAD_PROCESS_MEMORY_ROUTINE64 #else typedef BOOL (__stdcall *PREAD_PROCESS_MEMORY_ROUTINE)( __in HANDLE hProcess, __in DWORD lpBaseAddress, __out_bcount(nSize) PVOID lpBuffer, __in DWORD nSize, __out PDWORD lpNumberOfBytesRead ); #endif</code>
		/// </para>
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows/win32/api/dbghelp/nc-dbghelp-pread_process_memory_routine PREAD_PROCESS_MEMORY_ROUTINE
		// PreadProcessMemoryRoutine; BOOL PreadProcessMemoryRoutine( HANDLE hProcess, DWORD lpBaseAddress, PVOID lpBuffer, DWORD nSize,
		// PDWORD lpNumberOfBytesRead ) {...}
		[UnmanagedFunctionPointer(CallingConvention.Winapi)]
		[PInvokeData("dbghelp.h", MSDNShortId = "NC:dbghelp.PREAD_PROCESS_MEMORY_ROUTINE")]
		[return: MarshalAs(UnmanagedType.Bool)]
		public delegate bool PREAD_PROCESS_MEMORY_ROUTINE(HPROCESS hProcess, uint lpBaseAddress, [Out] IntPtr lpBuffer, uint nSize, out uint lpNumberOfBytesRead);

		/// <summary>
		/// <para>
		/// An application-defined callback function used with the StackWalk64 function. It is called when <c>StackWalk64</c> needs to read
		/// memory from the address space of the process.
		/// </para>
		/// <para>
		/// The <c>PREAD_PROCESS_MEMORY_ROUTINE64</c> type defines a pointer to this callback function. <c>ReadProcessMemoryProc64</c> is a
		/// placeholder for the application-defined function name.
		/// </para>
		/// </summary>
		/// <param name="hProcess">A handle to the process for which the stack trace is generated.</param>
		/// <param name="lpBaseAddress">The base address of the memory to be read.</param>
		/// <param name="lpBuffer">A pointer to a buffer that receives the memory to be read.</param>
		/// <param name="nSize">The size of the memory to be read, in bytes.</param>
		/// <param name="lpNumberOfBytesRead">A pointer to a variable that receives the number of bytes actually read.</param>
		/// <returns>
		/// If the function succeeds, the return value should be <c>TRUE</c>. If the function fails, the return value should be <c>FALSE</c>.
		/// </returns>
		/// <remarks>
		/// <para>In many cases, this function can best service the callback with a corresponding call to ReadProcessMemory.</para>
		/// <para>
		/// This function should read as much of the requested memory as possible. The StackWalk64 function handles the case where only part
		/// of the requested memory is read.
		/// </para>
		/// <para>
		/// This callback function supersedes the PREAD_PROCESS_MEMORY_ROUTINE callback function. PREAD_PROCESS_MEMORY_ROUTINE is defined as
		/// follows in Dbghelp.h.
		/// </para>
		/// <para>
		/// <code>#if !defined(_IMAGEHLP_SOURCE_) &amp;&amp; defined(_IMAGEHLP64) #define PREAD_PROCESS_MEMORY_ROUTINE PREAD_PROCESS_MEMORY_ROUTINE64 #else typedef BOOL (__stdcall *PREAD_PROCESS_MEMORY_ROUTINE)( __in HANDLE hProcess, __in DWORD lpBaseAddress, __out_bcount(nSize) PVOID lpBuffer, __in DWORD nSize, __out PDWORD lpNumberOfBytesRead ); #endif</code>
		/// </para>
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows/win32/api/dbghelp/nc-dbghelp-pread_process_memory_routine PREAD_PROCESS_MEMORY_ROUTINE
		// PreadProcessMemoryRoutine; BOOL PreadProcessMemoryRoutine( HANDLE hProcess, DWORD lpBaseAddress, PVOID lpBuffer, DWORD nSize,
		// PDWORD lpNumberOfBytesRead ) {...}
		[UnmanagedFunctionPointer(CallingConvention.Winapi)]
		[PInvokeData("dbghelp.h", MSDNShortId = "NC:dbghelp.PREAD_PROCESS_MEMORY_ROUTINE")]
		[return: MarshalAs(UnmanagedType.Bool)]
		public delegate bool PREAD_PROCESS_MEMORY_ROUTINE64(HPROCESS hProcess, ulong lpBaseAddress, [Out] IntPtr lpBuffer, uint nSize, out uint lpNumberOfBytesRead);

		/// <summary>
		/// <para>
		/// An application-defined callback function used with the SymEnumerateModules64 function. It is called once for each enumerated
		/// module, and receives the module information.
		/// </para>
		/// <para>
		/// The <c>PSYM_ENUMMODULES_CALLBACK64</c> and <c>PSYM_ENUMMODULES_CALLBACKW64</c> types define a pointer to this callback function.
		/// <c>SymEnumerateModulesProc64</c> is a placeholder for the application-defined function name.
		/// </para>
		/// </summary>
		/// <param name="ModuleName">The name of the module.</param>
		/// <param name="BaseOfDll">The base address where the module is loaded into memory.</param>
		/// <param name="UserContext">
		/// The user-defined value specified in SymEnumerateModules64, or <c>NULL</c>. Typically, this parameter is used by an application
		/// to pass a pointer to a data structure that lets the callback function establish some type of context.
		/// </param>
		/// <returns>
		/// <para>If the return value is <c>TRUE</c>, the enumeration will continue.</para>
		/// <para>If the return value is <c>FALSE</c>, the enumeration will stop.</para>
		/// </returns>
		/// <remarks>
		/// <para>
		/// The calling application is called once per module until all modules are enumerated, or until the enumeration callback function
		/// returns <c>FALSE</c>.
		/// </para>
		/// <para>
		/// This callback function supersedes the PSYM_ENUMMODULES_CALLBACK callback function. PSYM_ENUMMODULES_CALLBACK is defined as
		/// follows in DbgHelp.h.
		/// </para>
		/// <para>
		/// <code>#if !defined(_IMAGEHLP_SOURCE_) &amp;&amp; defined(_IMAGEHLP64) #define PSYM_ENUMMODULES_CALLBACK PSYM_ENUMMODULES_CALLBACK64 #else typedef BOOL (CALLBACK *PSYM_ENUMMODULES_CALLBACK)( __in PCSTR ModuleName, __in ULONG BaseOfDll, __in_opt PVOID UserContext ); #endif</code>
		/// </para>
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows/win32/api/dbghelp/nc-dbghelp-psym_enummodules_callback PSYM_ENUMMODULES_CALLBACK
		// PsymEnummodulesCallback; BOOL PsymEnummodulesCallback( PCSTR ModuleName, ULONG BaseOfDll, PVOID UserContext ) {...}
		[UnmanagedFunctionPointer(CallingConvention.Winapi, CharSet = CharSet.Ansi)]
		[PInvokeData("dbghelp.h", MSDNShortId = "NC:dbghelp.PSYM_ENUMMODULES_CALLBACK")]
		[return: MarshalAs(UnmanagedType.Bool)]
		public delegate bool PSYM_ENUMMODULES_CALLBACK([MarshalAs(UnmanagedType.LPStr)] string ModuleName, uint BaseOfDll, [In, Optional] IntPtr UserContext);

		/// <summary>
		/// <para>
		/// An application-defined callback function used with the SymEnumerateModules64 function. It is called once for each enumerated
		/// module, and receives the module information.
		/// </para>
		/// <para>
		/// The <c>PSYM_ENUMMODULES_CALLBACK64</c> and <c>PSYM_ENUMMODULES_CALLBACKW64</c> types define a pointer to this callback function.
		/// <c>SymEnumerateModulesProc64</c> is a placeholder for the application-defined function name.
		/// </para>
		/// </summary>
		/// <param name="ModuleName">The name of the module.</param>
		/// <param name="BaseOfDll">The base address where the module is loaded into memory.</param>
		/// <param name="UserContext">
		/// The user-defined value specified in SymEnumerateModules64, or <c>NULL</c>. Typically, this parameter is used by an application
		/// to pass a pointer to a data structure that lets the callback function establish some type of context.
		/// </param>
		/// <returns>
		/// <para>If the return value is <c>TRUE</c>, the enumeration will continue.</para>
		/// <para>If the return value is <c>FALSE</c>, the enumeration will stop.</para>
		/// </returns>
		/// <remarks>
		/// <para>
		/// The calling application is called once per module until all modules are enumerated, or until the enumeration callback function
		/// returns <c>FALSE</c>.
		/// </para>
		/// <para>
		/// This callback function supersedes the PSYM_ENUMMODULES_CALLBACK callback function. PSYM_ENUMMODULES_CALLBACK is defined as
		/// follows in DbgHelp.h.
		/// </para>
		/// <para>
		/// <code>#if !defined(_IMAGEHLP_SOURCE_) &amp;&amp; defined(_IMAGEHLP64) #define PSYM_ENUMMODULES_CALLBACK PSYM_ENUMMODULES_CALLBACK64 #else typedef BOOL (CALLBACK *PSYM_ENUMMODULES_CALLBACK)( __in PCSTR ModuleName, __in ULONG BaseOfDll, __in_opt PVOID UserContext ); #endif</code>
		/// </para>
		/// </remarks>
		// https://docs.microsoft.com/id-id/windows/win32/api/dbghelp/nc-dbghelp-psym_enummodules_callback64 PSYM_ENUMMODULES_CALLBACK64
		// PsymEnummodulesCallback64; BOOL PsymEnummodulesCallback64( PCSTR ModuleName, DWORD64 BaseOfDll, PVOID UserContext ) {...}
		[UnmanagedFunctionPointer(CallingConvention.Winapi, CharSet = CharSet.Auto)]
		[PInvokeData("dbghelp.h", MSDNShortId = "NC:dbghelp.PSYM_ENUMMODULES_CALLBACK64")]
		[return: MarshalAs(UnmanagedType.Bool)]
		public delegate bool PSYM_ENUMMODULES_CALLBACK64([MarshalAs(UnmanagedType.LPTStr)] string ModuleName, ulong BaseOfDll, [In, Optional] IntPtr UserContext);

		/// <summary>
		/// <para>
		/// An application-defined callback function used with the StackWalk64 function. It provides address translation for 16-bit addresses.
		/// </para>
		/// <para>
		/// The <c>PTRANSLATE_ADDRESS_ROUTINE64</c> type defines a pointer to this callback function. <c>TranslateAddressProc64</c> is a
		/// placeholder for the application-defined function name.
		/// </para>
		/// </summary>
		/// <param name="hProcess">A handle to the process for which the stack trace is generated.</param>
		/// <param name="hThread">A handle to the thread for which the stack trace is generated.</param>
		/// <param name="lpaddr">An address to be translated.</param>
		/// <returns>The function returns the translated address.</returns>
		/// <remarks>
		/// <para>
		/// This callback function supersedes the PTRANSLATE_ADDRESS_ROUTINE callback function. PTRANSLATE_ADDRESS_ROUTINE is defined as
		/// follows in Dbghelp.h.
		/// </para>
		/// <para>
		/// <code>#if !defined(_IMAGEHLP_SOURCE_) &amp;&amp; defined(_IMAGEHLP64) #define PTRANSLATE_ADDRESS_ROUTINE PTRANSLATE_ADDRESS_ROUTINE64 #else typedef DWORD (__stdcall *PTRANSLATE_ADDRESS_ROUTINE)( __in HANDLE hProcess, __in HANDLE hThread, __out LPADDRESS lpaddr ); #endif</code>
		/// </para>
		/// </remarks>
		// https://docs.microsoft.com/vi-vn/windows/win32/api/dbghelp/nc-dbghelp-ptranslate_address_routine64 PTRANSLATE_ADDRESS_ROUTINE64
		// PtranslateAddressRoutine64; DWORD64 PtranslateAddressRoutine64( HANDLE hProcess, HANDLE hThread, LPADDRESS64 lpaddr ) {...}
		[UnmanagedFunctionPointer(CallingConvention.Winapi)]
		[PInvokeData("dbghelp.h", MSDNShortId = "NC:dbghelp.PTRANSLATE_ADDRESS_ROUTINE64")]
		public delegate ulong PTRANSLATE_ADDRESS_ROUTINE64(HPROCESS hProcess, HTHREAD hThread, in ADDRESS64 lpaddr);

		/// <summary>
		/// <para>
		/// An application-defined callback function used with the StackWalk64 function. It provides address translation for 16-bit addresses.
		/// </para>
		/// <para>
		/// The <c>PTRANSLATE_ADDRESS_ROUTINE64</c> type defines a pointer to this callback function. <c>TranslateAddressProc64</c> is a
		/// placeholder for the application-defined function name.
		/// </para>
		/// </summary>
		/// <param name="hProcess">A handle to the process for which the stack trace is generated.</param>
		/// <param name="hThread">A handle to the thread for which the stack trace is generated.</param>
		/// <param name="lpaddr">An address to be translated.</param>
		/// <returns>The function returns the translated address.</returns>
		/// <remarks>
		/// <para>
		/// This callback function supersedes the PTRANSLATE_ADDRESS_ROUTINE callback function. PTRANSLATE_ADDRESS_ROUTINE is defined as
		/// follows in Dbghelp.h.
		/// </para>
		/// <para>
		/// <code>#if !defined(_IMAGEHLP_SOURCE_) &amp;&amp; defined(_IMAGEHLP64) #define PTRANSLATE_ADDRESS_ROUTINE PTRANSLATE_ADDRESS_ROUTINE64 #else typedef DWORD (__stdcall *PTRANSLATE_ADDRESS_ROUTINE)( __in HANDLE hProcess, __in HANDLE hThread, __out LPADDRESS lpaddr ); #endif</code>
		/// </para>
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows/win32/api/dbghelp/nc-dbghelp-ptranslate_address_routine
		// PTRANSLATE_ADDRESS_ROUTINE PtranslateAddressRoutine; DWORD PtranslateAddressRoutine( HANDLE hProcess, HANDLE hThread, LPADDRESS lpaddr ) {...}
		[UnmanagedFunctionPointer(CallingConvention.Winapi)]
		[PInvokeData("dbghelp.h", MSDNShortId = "NC:dbghelp.PTRANSLATE_ADDRESS_ROUTINE")]
		public delegate uint PTRANSLATE_ADDRESS_ROUTINE(HPROCESS hProcess, HTHREAD hThread, in ADDRESS lpaddr);

		/// <summary>The addressing mode.</summary>
		[PInvokeData("dbghelp.h", MSDNShortId = "NS:dbghelp._tagADDRESS64")]
		public enum ADDRESS_MODE
		{
			/// <summary>16:16 addressing. To support this addressing mode, you must supply a TranslateAddressProc64 callback function.</summary>
			AddrMode1616,

			/// <summary>16:32 addressing. To support this addressing mode, you must supply a TranslateAddressProc64 callback function.</summary>
			AddrMode1632,

			/// <summary>Real-mode addressing. To support this addressing mode, you must supply a TranslateAddressProc64 callback function.</summary>
			AddrModeReal,

			/// <summary>Flat addressing. This is the only addressing mode supported by the library.</summary>
			AddrModeFlat
		}

		/// <summary>The event severity.</summary>
		[PInvokeData("dbghelp.h", MSDNShortId = "NS:dbghelp._IMAGEHLP_CBA_EVENT")]
		public enum EVENT_SEVERITY
		{
			/// <summary>Informational event.</summary>
			sevInfo = 0,

			/// <summary>Reserved for future use.</summary>
			sevProblem,

			/// <summary>Reserved for future use.</summary>
			sevAttn,

			/// <summary>Reserved for future use.</summary>
			sevFatal,

			/// <summary>Unused</summary>
			sevMax
		}

		/// <summary>A variable that indicates the frame type.</summary>
		[PInvokeData("winnt.h", MSDNShortId = "NS:winnt._FPO_DATA")]
		public enum FRAME
		{
			/// <summary>FPO frame</summary>
			FRAME_FPO = 0,

			/// <summary>Trap frame</summary>
			FRAME_TRAP = 1,

			/// <summary>TSS frame</summary>
			FRAME_TSS = 2,

			/// <summary>Non-FPO frame</summary>
			FRAME_NONFPO = 3,
		}

		/// <summary>
		/// Lists the extended symbol options that you can get and set by using the SymGetExtendedOption and SymSetExtendedOption functions.
		/// </summary>
		// https://docs.microsoft.com/en-us/windows/win32/api/dbghelp/ne-dbghelp-imagehlp_extended_options typedef enum {
		// SYMOPT_EX_DISABLEACCESSTIMEUPDATE, SYMOPT_EX_LASTVALIDDEBUGDIRECTORY, SYMOPT_EX_MAX } IMAGEHLP_EXTENDED_OPTIONS;
		[PInvokeData("dbghelp.h", MSDNShortId = "NE:dbghelp.__unnamed_enum_4")]
		public enum IMAGEHLP_EXTENDED_OPTIONS
		{
			/// <summary>
			/// Turns off explicit updates to the last access time of a symbol that is loaded. By default, DbgHelp updates the last access
			/// time of a symbol file that is consumed so that a symbol cache can be maintained by using a least recently used mechanism.
			/// </summary>
			SYMOPT_EX_DISABLEACCESSTIMEUPDATE,

			/// <summary>Unused.</summary>
			SYMOPT_EX_MAX,
		}

		/// <summary>Identifies the type of symbol information to be retrieved.</summary>
		// https://docs.microsoft.com/en-us/windows/win32/api/dbghelp/ne-dbghelp-imagehlp_symbol_type_info typedef enum
		// _IMAGEHLP_SYMBOL_TYPE_INFO { TI_GET_SYMTAG, TI_GET_SYMNAME, TI_GET_LENGTH, TI_GET_TYPE, TI_GET_TYPEID, TI_GET_BASETYPE,
		// TI_GET_ARRAYINDEXTYPEID, TI_FINDCHILDREN, TI_GET_DATAKIND, TI_GET_ADDRESSOFFSET, TI_GET_OFFSET, TI_GET_VALUE, TI_GET_COUNT,
		// TI_GET_CHILDRENCOUNT, TI_GET_BITPOSITION, TI_GET_VIRTUALBASECLASS, TI_GET_VIRTUALTABLESHAPEID, TI_GET_VIRTUALBASEPOINTEROFFSET,
		// TI_GET_CLASSPARENTID, TI_GET_NESTED, TI_GET_SYMINDEX, TI_GET_LEXICALPARENT, TI_GET_ADDRESS, TI_GET_THISADJUST, TI_GET_UDTKIND,
		// TI_IS_EQUIV_TO, TI_GET_CALLING_CONVENTION, TI_IS_CLOSE_EQUIV_TO, TI_GTIEX_REQS_VALID, TI_GET_VIRTUALBASEOFFSET,
		// TI_GET_VIRTUALBASEDISPINDEX, TI_GET_IS_REFERENCE, TI_GET_INDIRECTVIRTUALBASECLASS, TI_GET_VIRTUALBASETABLETYPE,
		// IMAGEHLP_SYMBOL_TYPE_INFO_MAX } IMAGEHLP_SYMBOL_TYPE_INFO;
		[PInvokeData("dbghelp.h", MSDNShortId = "NE:dbghelp._IMAGEHLP_SYMBOL_TYPE_INFO")]
		public enum IMAGEHLP_SYMBOL_TYPE_INFO
		{
			/// <summary>The symbol tag.The data type is DWORD*.</summary>
			TI_GET_SYMTAG,

			/// <summary>The symbol name.The data type is WCHAR**. The caller must free the buffer.</summary>
			TI_GET_SYMNAME,

			/// <summary>The length of the type.The data type is ULONG64*.</summary>
			TI_GET_LENGTH,

			/// <summary>The type.The data type is DWORD*.</summary>
			TI_GET_TYPE,

			/// <summary>The type index.The data type is DWORD*.</summary>
			TI_GET_TYPEID,

			/// <summary>The base type for the type index.The data type is DWORD*.</summary>
			TI_GET_BASETYPE,

			/// <summary>The type index for index of an array type.The data type is DWORD*.</summary>
			TI_GET_ARRAYINDEXTYPEID,

			/// <summary>
			/// The type index of all children.The data type is a pointer to a TI_FINDCHILDREN_PARAMS structure. The Count member should be
			/// initialized with the number of children.
			/// </summary>
			TI_FINDCHILDREN,

			/// <summary>The data kind.The data type is DWORD*.</summary>
			TI_GET_DATAKIND,

			/// <summary>The address offset.The data type is DWORD*.</summary>
			TI_GET_ADDRESSOFFSET,

			/// <summary>
			/// The offset of the type in the parent. Members can use this to get their offset in a structure.The data type is DWORD*.
			/// </summary>
			TI_GET_OFFSET,

			/// <summary>The value of a constant or enumeration value.The data type is VARIANT*.</summary>
			TI_GET_VALUE,

			/// <summary>The count of array elements.The data type is DWORD*.</summary>
			TI_GET_COUNT,

			/// <summary>The number of children.The data type is DWORD*.</summary>
			TI_GET_CHILDRENCOUNT,

			/// <summary>The bit position of a bitfield.The data type is DWORD*.</summary>
			TI_GET_BITPOSITION,

			/// <summary>A value that indicates whether the base class is virtually inherited.The data type is BOOL.</summary>
			TI_GET_VIRTUALBASECLASS,

			/// <summary>The symbol interface of the type of virtual table, for a user-defined type.</summary>
			TI_GET_VIRTUALTABLESHAPEID,

			/// <summary>The offset of the virtual base pointer.The data type is DWORD*.</summary>
			TI_GET_VIRTUALBASEPOINTEROFFSET,

			/// <summary>The type index of the class parent.The data type is DWORD*.</summary>
			TI_GET_CLASSPARENTID,

			/// <summary>A value that indicates whether the type index is nested.The data type is DWORD*.</summary>
			TI_GET_NESTED,

			/// <summary>The symbol index for a type.The data type is DWORD*.</summary>
			TI_GET_SYMINDEX,

			/// <summary>The lexical parent of the type.The data type is DWORD*.</summary>
			TI_GET_LEXICALPARENT,

			/// <summary>The index address.The data type is ULONG64*.</summary>
			TI_GET_ADDRESS,

			/// <summary>The offset from the this pointer to its actual value.The data type is DWORD*.</summary>
			TI_GET_THISADJUST,

			/// <summary>The UDT kind.The data type is DWORD*.</summary>
			TI_GET_UDTKIND,

			/// <summary>
			/// The equivalency of two types.The data type is DWORD*. The value is S_OK is the two types are equivalent, and S_FALSE otherwise.
			/// </summary>
			TI_IS_EQUIV_TO,

			/// <summary>The calling convention.The data type is DWORD. The following are the valid values:</summary>
			TI_GET_CALLING_CONVENTION,

			/// <summary>
			/// The equivalency of two symbols. This is not guaranteed to be accurate.The data type is DWORD*. The value is S_OK is the two
			/// types are equivalent, and S_FALSE otherwise.
			/// </summary>
			TI_IS_CLOSE_EQUIV_TO,

			/// <summary>
			/// The element where the valid request bitfield should be stored.The data type is ULONG64*.This value is only used with the
			/// SymGetTypeInfoEx function.
			/// </summary>
			TI_GTIEX_REQS_VALID,

			/// <summary>The offset in the virtual function table of a virtual function.The data type is DWORD.</summary>
			TI_GET_VIRTUALBASEOFFSET,

			/// <summary>The index into the virtual base displacement table.The data type is DWORD.</summary>
			TI_GET_VIRTUALBASEDISPINDEX,

			/// <summary>Indicates whether a pointer type is a reference.The data type is Boolean.</summary>
			TI_GET_IS_REFERENCE,

			/// <summary>
			/// Indicates whether the user-defined data type is an indirect virtual base.The data type is BOOL.DbgHelp 6.6 and earlier: This
			/// value is not supported.
			/// </summary>
			TI_GET_INDIRECTVIRTUALBASECLASS,

			/// <summary/>
			TI_GET_VIRTUALBASETABLETYPE,

			/// <summary/>
			IMAGEHLP_SYMBOL_TYPE_INFO_MAX,
		}

		/// <summary>Indicates the result of the comparison.</summary>
		[PInvokeData("dbghelp.h", MSDNShortId = "NF:dbghelp.SymCompareInlineTrace")]
		public enum SYM_INLINE_COMP
		{
			/// <summary>An error occurred.</summary>
			SYM_INLINE_COMP_ERROR = 0,

			/// <summary>The inline contexts are identical.</summary>
			SYM_INLINE_COMP_IDENTICAL = 1,

			/// <summary>The inline trace is a step-in of an inline function.</summary>
			SYM_INLINE_COMP_STEPIN = 2,

			/// <summary>The inline trace is a step-out of an inline function.</summary>
			SYM_INLINE_COMP_STEPOUT = 3,

			/// <summary>The inline trace is a step-over of an inline function.</summary>
			SYM_INLINE_COMP_STEPOVER = 4,

			/// <summary>The inline contexts are different.</summary>
			SYM_INLINE_COMP_DIFFERENT = 5,
		}

		/// <summary>Flags for <see cref="StackWalkEx"/>.</summary>
		[PInvokeData("dbghelp.h", MSDNShortId = "NF:dbghelp.StackWalkEx")]
		[Flags]
		public enum SYM_STKWALK
		{
			/// <summary/>
			SYM_STKWALK_DEFAULT = 0x00000000,

			/// <summary/>
			SYM_STKWALK_FORCE_FRAMEPTR = 0x00000001
		}

		/// <summary>The options for how the decorated name is undecorated.</summary>
		[PInvokeData("dbghelp.h", MSDNShortId = "NF:dbghelp.UnDecorateSymbolName")]
		[Flags]
		public enum UNDNAME : uint
		{
			/// <summary>Undecorate 32-bit decorated names.</summary>
			UNDNAME_32_BIT_DECODE = 0x0800,

			/// <summary>Enable full undecoration.</summary>
			UNDNAME_COMPLETE = 0x0000,

			/// <summary>Undecorate only the name for primary declaration. Returns [scope::]name. Does expand template parameters.</summary>
			UNDNAME_NAME_ONLY = 0x1000,

			/// <summary>Disable expansion of access specifiers for members.</summary>
			UNDNAME_NO_ACCESS_SPECIFIERS = 0x0080,

			/// <summary>Disable expansion of the declaration language specifier.</summary>
			UNDNAME_NO_ALLOCATION_LANGUAGE = 0x0010,

			/// <summary>Disable expansion of the declaration model.</summary>
			UNDNAME_NO_ALLOCATION_MODEL = 0x0008,

			/// <summary>Do not undecorate function arguments.</summary>
			UNDNAME_NO_ARGUMENTS = 0x2000,

			/// <summary>Disable expansion of CodeView modifiers on the this type for primary declaration.</summary>
			UNDNAME_NO_CV_THISTYPE = 0x0040,

			/// <summary>Disable expansion of return types for primary declarations.</summary>
			UNDNAME_NO_FUNCTION_RETURNS = 0x0004,

			/// <summary>Remove leading underscores from Microsoft keywords.</summary>
			UNDNAME_NO_LEADING_UNDERSCORES = 0x0001,

			/// <summary>Disable expansion of the static or virtual attribute of members.</summary>
			UNDNAME_NO_MEMBER_TYPE = 0x0200,

			/// <summary>Disable expansion of Microsoft keywords.</summary>
			UNDNAME_NO_MS_KEYWORDS = 0x0002,

			/// <summary>Disable expansion of Microsoft keywords on the this type for primary declaration.</summary>
			UNDNAME_NO_MS_THISTYPE = 0x0020,

			/// <summary>Disable expansion of the Microsoft model for user-defined type returns.</summary>
			UNDNAME_NO_RETURN_UDT_MODEL = 0x0400,

			/// <summary>Do not undecorate special names, such as vtable, vcall, vector, metatype, and so on.</summary>
			UNDNAME_NO_SPECIAL_SYMS = 0x4000,

			/// <summary>Disable all modifiers on the this type.</summary>
			UNDNAME_NO_THISTYPE = 0x0060,

			/// <summary>Disable expansion of throw-signatures for functions and pointers to functions.</summary>
			UNDNAME_NO_THROW_SIGNATURES = 0x0100,
		}

		/// <summary>Enumerates all occurrences of the specified file in the specified directory tree.</summary>
		/// <param name="hProcess">A handle to a process. This handle must have been previously passed to the SymInitialize function.</param>
		/// <param name="RootPath">The path where the function should begin searching for the file.</param>
		/// <param name="InputPathName">The name of the file to be found. You can specify a partial path.</param>
		/// <param name="OutputPathBuffer">
		/// <para>
		/// A pointer to a buffer that receives the full path of the file. If the function fails or does not find a matching file, this
		/// buffer will still contain the last full path that was found.
		/// </para>
		/// <para>This parameter is optional and can be <c>NULL</c>.</para>
		/// </param>
		/// <param name="cb">An application-defined callback function, or <c>NULL</c>. For more information, see EnumDirTreeProc.</param>
		/// <param name="data">The user-defined data or <c>NULL</c>. This value is passed to the callback function.</param>
		/// <returns>
		/// <para>If the function succeeds, the return value is <c>TRUE</c>.</para>
		/// <para>If the function fails, the return value is <c>FALSE</c>. To retrieve extended error information, call GetLastError.</para>
		/// </returns>
		/// <remarks>
		/// <para>
		/// The search can be canceled if you register a SymRegisterCallbackProc64 callback function. For every file operation, EnumDirTree
		/// calls this callback function with CBA_DEFERRED_SYMBOL_LOAD_CANCEL. If the callback function returns <c>TRUE</c>, EnumDirTree
		/// cancels the search.
		/// </para>
		/// <para>
		/// All DbgHelp functions, such as this one, are single threaded. Therefore, calls from more than one thread to this function will
		/// likely result in unexpected behavior or memory corruption. To avoid this, you must synchronize all concurrent calls from more
		/// than one thread to this function.
		/// </para>
		/// <para>To call the Unicode version of this function, define DBGHELP_TRANSLATE_TCHAR.</para>
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows/win32/api/dbghelp/nf-dbghelp-enumdirtree BOOL IMAGEAPI EnumDirTree( HANDLE hProcess,
		// PCSTR RootPath, PCSTR InputPathName, PSTR OutputPathBuffer, PENUMDIRTREE_CALLBACK cb, PVOID data );
		[DllImport(Lib_DbgHelp, SetLastError = true, CharSet = CharSet.Auto)]
		[PInvokeData("dbghelp.h", MSDNShortId = "NF:dbghelp.EnumDirTree")]
		[return: MarshalAs(UnmanagedType.Bool)]
		public static extern bool EnumDirTree([Optional] HPROCESS hProcess, [MarshalAs(UnmanagedType.LPTStr)] string RootPath, [MarshalAs(UnmanagedType.LPTStr)] string InputPathName,
			[Optional, MarshalAs(UnmanagedType.LPTStr)] StringBuilder OutputPathBuffer, [Optional] PENUMDIRTREE_CALLBACK cb, [In, Optional] IntPtr data);

		/// <summary>Enumerates all occurrences of the specified file in the specified directory tree.</summary>
		/// <param name="hProcess">A handle to a process. This handle must have been previously passed to the SymInitialize function.</param>
		/// <param name="RootPath">The path where the function should begin searching for the file.</param>
		/// <param name="InputPathName">The name of the file to be found. You can specify a partial path.</param>
		/// <returns>A list of files matching the <paramref name="InputPathName"/>.</returns>
		public static IList<string> EnumDirTree(HPROCESS hProcess, string RootPath, string InputPathName)
		{
			var paths = new List<string>();
			EnumDirTree(hProcess, RootPath, InputPathName, null, Callback);
			return paths;

			bool Callback(string FilePath, IntPtr CallerData)
			{
				paths.Add(FilePath);
				return false;
			}
		}

		/// <summary>Enumerates the loaded modules for the specified process.</summary>
		/// <param name="hProcess">A handle to the process whose modules will be enumerated.</param>
		/// <param name="EnumLoadedModulesCallback">An application-defined callback function. For more information, see EnumerateLoadedModulesProc64.</param>
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
		/// <para>
		/// To call the Unicode version of this function, EnumerateLoadedModulesW64, define <c>DBGHELP_TRANSLATE_TCHAR</c>.
		/// EnumerateLoadedModulesW64 is defined as follows in DbgHelp.h.
		/// </para>
		/// <para>
		/// <code>BOOL IMAGEAPI EnumerateLoadedModulesW64( __in HANDLE hProcess, __in PENUMLOADED_MODULES_CALLBACKW64 EnumLoadedModulesCallback, __in PVOID UserContext ); #ifdef DBGHELP_TRANSLATE_TCHAR #define EnumerateLoadedModules64 EnumerateLoadedModulesW64 #endif</code>
		/// </para>
		/// <para>
		/// This function supersedes the EnumerateLoadedModules function. For more information, see Updated Platform Support.
		/// EnumerateLoadedModules is defined as follows in DbgHelp.h.
		/// </para>
		/// <para>
		/// <code>#if !defined(_IMAGEHLP_SOURCE_) &amp;&amp; defined(_IMAGEHLP64) #define EnumerateLoadedModules EnumerateLoadedModules64 #else BOOL IMAGEAPI EnumerateLoadedModules( __in HANDLE hProcess, __in PENUMLOADED_MODULES_CALLBACK EnumLoadedModulesCallback, __in_opt PVOID UserContext ); #endif</code>
		/// </para>
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows/win32/api/dbghelp/nf-dbghelp-enumerateloadedmodules BOOL IMAGEAPI
		// EnumerateLoadedModules( HANDLE hProcess, PENUMLOADED_MODULES_CALLBACK EnumLoadedModulesCallback, PVOID UserContext );
		[DllImport(Lib_DbgHelp, SetLastError = true, CharSet = CharSet.Ansi, ExactSpelling = true)]
		[PInvokeData("dbghelp.h", MSDNShortId = "NF:dbghelp.EnumerateLoadedModules")]
		[return: MarshalAs(UnmanagedType.Bool)]
		public static extern bool EnumerateLoadedModules(HPROCESS hProcess, PENUMLOADED_MODULES_CALLBACK EnumLoadedModulesCallback, [In, Optional] IntPtr UserContext);

		/// <summary>Enumerates the loaded modules for the specified process.</summary>
		/// <param name="hProcess">A handle to the process whose modules will be enumerated.</param>
		/// <param name="EnumLoadedModulesCallback">An application-defined callback function. For more information, see EnumerateLoadedModulesProc64.</param>
		/// <param name="UserContext">Optional user-defined data. This value is passed to the callback function.</param>
		/// <returns>
		/// <para>If the function succeeds, the return value is <c>TRUE</c>.</para>
		/// <para>If the function fails, the return value is <c>FALSE</c>. To retrieve extended error information, call GetLastError.</para>
		/// </returns>
		/// <remarks>
		/// <para>All DbgHelp functions, such as this one, are single threaded. Therefore, calls from more than one thread to this function will likely result in unexpected behavior or memory corruption. To avoid this, you must synchronize all concurrent calls from more than one thread to this function.</para>
		/// <para>To call the Unicode version of this function, EnumerateLoadedModulesW64, define <c>DBGHELP_TRANSLATE_TCHAR</c>. EnumerateLoadedModulesW64 is defined as follows in DbgHelp.h.</para>
		/// <para><code>BOOL IMAGEAPI EnumerateLoadedModulesW64( __in HANDLE hProcess, __in PENUMLOADED_MODULES_CALLBACKW64 EnumLoadedModulesCallback, __in PVOID UserContext ); #ifdef DBGHELP_TRANSLATE_TCHAR #define EnumerateLoadedModules64 EnumerateLoadedModulesW64 #endif </code></para>
		/// <para>This function supersedes the EnumerateLoadedModules function. For more information, see Updated Platform Support. EnumerateLoadedModules is defined as follows in DbgHelp.h.</para>
		/// <para><code>#if !defined(_IMAGEHLP_SOURCE_) &amp;&amp; defined(_IMAGEHLP64) #define EnumerateLoadedModules EnumerateLoadedModules64 #else BOOL IMAGEAPI EnumerateLoadedModules( __in HANDLE hProcess, __in PENUMLOADED_MODULES_CALLBACK EnumLoadedModulesCallback, __in_opt PVOID UserContext ); #endif </code></para>
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows/win32/api/dbghelp/nf-dbghelp-enumerateloadedmodules64
		// BOOL IMAGEAPI EnumerateLoadedModules64( HANDLE hProcess, PENUMLOADED_MODULES_CALLBACK64 EnumLoadedModulesCallback, PVOID UserContext );
		[DllImport(Lib_DbgHelp, SetLastError = true, CharSet = CharSet.Unicode, EntryPoint = "EnumerateLoadedModulesW64")]
		[PInvokeData("dbghelp.h", MSDNShortId = "NF:dbghelp.EnumerateLoadedModules64")]
		[return: MarshalAs(UnmanagedType.Bool)]
		public static extern bool EnumerateLoadedModules64(HPROCESS hProcess, PENUMLOADED_MODULES_CALLBACKW64 EnumLoadedModulesCallback, [In, Optional] IntPtr UserContext);

		/// <summary>
		/// Enumerates the loaded modules for the specified process. This overload will call the 32 or 64-bit version of the function based
		/// on the calling process.
		/// </summary>
		/// <param name="hProcess">A handle to the process whose modules will be enumerated.</param>
		/// <returns>A list of all loaded module names, base addresses, and sizes.</returns>
		[PInvokeData("dbghelp.h", MSDNShortId = "NF:dbghelp.EnumerateLoadedModules")]
		public static IList<(string ModuleName, IntPtr ModuleBase, uint ModuleSize)> EnumerateLoadedModules(HPROCESS hProcess)
		{
			var mods = new List<(string, IntPtr, uint)>();
			if (Vanara.InteropServices.LibHelper.Is64BitProcess)
				EnumerateLoadedModules64(hProcess, Callback64);
			else
				EnumerateLoadedModules(hProcess, Callback);
			return mods;

			bool Callback(string ModuleName, uint ModuleBase, uint ModuleSize, IntPtr UserContext)
			{
				mods.Add((ModuleName, new IntPtr(unchecked((int)ModuleBase)), ModuleSize));
				return true;
			}

			bool Callback64(string ModuleName, ulong ModuleBase, uint ModuleSize, IntPtr UserContext)
			{
				mods.Add((ModuleName, new IntPtr(unchecked((long)ModuleBase)), ModuleSize));
				return true;
			}
		}

		/// <summary>Enumerates the loaded modules for the specified process.</summary>
		/// <param name="hProcess">A handle to the process whose modules will be enumerated.</param>
		/// <param name="EnumLoadedModulesCallback">An application-defined callback function. For more information, see EnumerateLoadedModulesProc64.</param>
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
		// https://docs.microsoft.com/en-us/windows/win32/api/dbghelp/nf-dbghelp-enumerateloadedmodulesexw BOOL IMAGEAPI
		// EnumerateLoadedModulesExW( HANDLE hProcess, PENUMLOADED_MODULES_CALLBACKW64 EnumLoadedModulesCallback, PVOID UserContext );
		[DllImport(Lib_DbgHelp, SetLastError = true, CharSet = CharSet.Unicode, EntryPoint = "EnumerateLoadedModulesExW")]
		[PInvokeData("dbghelp.h", MSDNShortId = "NF:dbghelp.EnumerateLoadedModulesExW")]
		[return: MarshalAs(UnmanagedType.Bool)]
		public static extern bool EnumerateLoadedModulesEx(HPROCESS hProcess, PENUMLOADED_MODULES_CALLBACKW64 EnumLoadedModulesCallback, [In, Optional] IntPtr UserContext);

		/// <summary>Enumerates the loaded modules for the specified process.</summary>
		/// <param name="hProcess">A handle to the process whose modules will be enumerated.</param>
		/// <returns>A list of all loaded module names, base addresses, and sizes.</returns>
		[PInvokeData("dbghelp.h", MSDNShortId = "NF:dbghelp.EnumerateLoadedModulesExW")]
		public static IList<(string ModuleName, IntPtr ModuleBase, uint ModuleSize)> EnumerateLoadedModulesEx(HPROCESS hProcess)
		{
			var mods = new List<(string, IntPtr, uint)>();
			EnumerateLoadedModulesEx(hProcess, Callback);
			return mods;

			bool Callback(string ModuleName, ulong ModuleBase, uint ModuleSize, IntPtr UserContext)
			{
				mods.Add((ModuleName, new IntPtr(unchecked((long)ModuleBase)), ModuleSize));
				return true;
			}
		}

		/// <summary>
		/// <para>Locates a debug (.dbg) file.</para>
		/// <para>To provide a callback function to verify the symbol file located, use the FindDebugInfoFileEx function.</para>
		/// </summary>
		/// <param name="FileName">The name of the .dbg file that is desired. You can use a partial path.</param>
		/// <param name="SymbolPath">
		/// The path where symbol files are located. This can be multiple paths separated by semicolons. To retrieve the symbol path, use
		/// the SymGetSearchPath function.
		/// </param>
		/// <param name="DebugFilePath">A pointer to a buffer that receives the full path of the .dbg file.</param>
		/// <returns>
		/// <para>If the function succeeds, the return value is an open handle to the .dbg file.</para>
		/// <para>If the function fails, the return value is <c>NULL</c>. To retrieve extended error information, call GetLastError.</para>
		/// </returns>
		/// <remarks>
		/// <para>
		/// The <c>FindDebugInfoFile</c> function is used to locate a .dbg file. This function is provided so the search can be conducted in
		/// several different directories through a single function call. The SymbolPath parameter can contain multiple paths, with each
		/// separated by a semicolon (;). When multiple paths are specified, the function searches each directory for the file.
		/// Subdirectories are not searched. When the file is located, the search stops. Thus, be sure to specify SymbolPath with the paths
		/// in the correct order.
		/// </para>
		/// <para>
		/// All DbgHelp functions, such as this one, are single threaded. Therefore, calls from more than one thread to this function will
		/// likely result in unexpected behavior or memory corruption. To avoid this, you must synchronize all concurrent calls from more
		/// than one thread to this function.
		/// </para>
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows/win32/api/dbghelp/nf-dbghelp-finddebuginfofile HANDLE IMAGEAPI FindDebugInfoFile( PCSTR
		// FileName, PCSTR SymbolPath, PSTR DebugFilePath );
		[DllImport(Lib_DbgHelp, SetLastError = true, ExactSpelling = true)]
		[PInvokeData("dbghelp.h", MSDNShortId = "NF:dbghelp.FindDebugInfoFile")]
		public static extern SafeHFILE FindDebugInfoFile([MarshalAs(UnmanagedType.LPStr)] string FileName, [MarshalAs(UnmanagedType.LPStr)] string SymbolPath,
			[Out, MarshalAs(UnmanagedType.LPStr)] StringBuilder DebugFilePath);

		/// <summary>Locates the specified debug (.dbg) file.</summary>
		/// <param name="FileName">The name of the .dbg file to locate. You can use a partial path.</param>
		/// <param name="SymbolPath">
		/// The path where symbol files are located. This can be multiple paths separated by semicolons. To retrieve the symbol path, use
		/// the SymGetSearchPath function.
		/// </param>
		/// <param name="DebugFilePath">A pointer to a buffer that receives the full path of the .dbg file.</param>
		/// <param name="Callback">
		/// <para>
		/// An application-defined callback function that verifies whether the correct file was found or the function should continue its
		/// search. For more information, see FindDebugInfoFileProc.
		/// </para>
		/// <para>This parameter may be <c>NULL</c>.</para>
		/// </param>
		/// <param name="CallerData">Optional user-defined data to pass to the callback function.</param>
		/// <returns>
		/// <para>If the function succeeds, the return value is an open handle to the .dbg file.</para>
		/// <para>If the function fails, the return value is <c>NULL</c>. To retrieve extended error information, call GetLastError.</para>
		/// </returns>
		/// <remarks>
		/// <para>
		/// The <c>FindDebugInfoFileEx</c> function is used to locate a .dbg file. This function is provided so the search can be conducted
		/// in several different directories through a single function call. The SymbolPath parameter can contain multiple paths, with each
		/// separated by a semicolon (;). When multiple paths are specified, the function searches each specified directory for the file.
		/// When the file is located, the search stops. Thus, be sure to specify SymbolPath with the paths in the correct order.
		/// </para>
		/// <para>
		/// If the file name specified does not include a .dbg extension, <c>FindDebugInfoFileEx</c> searches for the file in the following sequence:
		/// </para>
		/// <list type="number">
		/// <item>
		/// <term>SymbolPath\Symbols\ext\filename.dbg</term>
		/// </item>
		/// <item>
		/// <term>SymbolPath\ext\filename.dbg</term>
		/// </item>
		/// <item>
		/// <term>SymbolPath\filename.dbg</term>
		/// </item>
		/// <item>
		/// <term>FileNamePath\filename.dbg</term>
		/// </item>
		/// </list>
		/// <para>
		/// All DbgHelp functions, such as this one, are single threaded. Therefore, calls from more than one thread to this function will
		/// likely result in unexpected behavior or memory corruption. To avoid this, you must synchronize all concurrent calls from more
		/// than one thread to this function.
		/// </para>
		/// <para>To call the Unicode version of this function, define DBGHELP_TRANSLATE_TCHAR.</para>
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows/win32/api/dbghelp/nf-dbghelp-finddebuginfofileex HANDLE IMAGEAPI FindDebugInfoFileEx(
		// PCSTR FileName, PCSTR SymbolPath, PSTR DebugFilePath, PFIND_DEBUG_FILE_CALLBACK Callback, PVOID CallerData );
		[DllImport(Lib_DbgHelp, SetLastError = true, CharSet = CharSet.Auto)]
		[PInvokeData("dbghelp.h", MSDNShortId = "NF:dbghelp.FindDebugInfoFileEx")]
		public static extern SafeHFILE FindDebugInfoFileEx([MarshalAs(UnmanagedType.LPTStr)] string FileName, [MarshalAs(UnmanagedType.LPTStr)] string SymbolPath,
			[Out, MarshalAs(UnmanagedType.LPTStr)] StringBuilder DebugFilePath, [Optional] PFIND_DEBUG_FILE_CALLBACK Callback, [In, Optional] IntPtr CallerData);

		/// <summary>
		/// <para>Locates an executable file.</para>
		/// <para>To specify a callback function, use the FindExecutableImageEx function.</para>
		/// </summary>
		/// <param name="FileName">The name of the symbol file to be located. This parameter can be a partial path.</param>
		/// <param name="SymbolPath">
		/// The path where symbol files are located. This can be multiple paths separated by semicolons. To retrieve the symbol path, use
		/// the SymGetSearchPath function.
		/// </param>
		/// <param name="ImageFilePath">A pointer to a buffer that receives the full path of the executable file.</param>
		/// <returns>
		/// <para>If the function succeeds, the return value is an open handle to the executable file.</para>
		/// <para>If the function fails, the return value is <c>NULL</c>. To retrieve extended error information, call GetLastError.</para>
		/// </returns>
		/// <remarks>
		/// <para>
		/// The <c>FindExecutableImage</c> function is provided so executable files can be located in several different directories through
		/// a single function call. The SymbolPath parameter can contain multiple paths, with each separated by a semicolon (;). When
		/// multiple paths are specified, the function searches each directory tree for the executable file. When the file is located, the
		/// search stops. Thus, be sure to specify SymbolPath with the paths in the correct order.
		/// </para>
		/// <para>
		/// All DbgHelp functions, such as this one, are single threaded. Therefore, calls from more than one thread to this function will
		/// likely result in unexpected behavior or memory corruption. To avoid this, you must synchronize all concurrent calls from more
		/// than one thread to this function.
		/// </para>
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows/win32/api/dbghelp/nf-dbghelp-findexecutableimage HANDLE IMAGEAPI FindExecutableImage(
		// PCSTR FileName, PCSTR SymbolPath, PSTR ImageFilePath );
		[DllImport(Lib_DbgHelp, SetLastError = true, ExactSpelling = true)]
		[PInvokeData("dbghelp.h", MSDNShortId = "NF:dbghelp.FindExecutableImage")]
		public static extern SafeHFILE FindExecutableImage([MarshalAs(UnmanagedType.LPStr)] string FileName, [MarshalAs(UnmanagedType.LPStr)] string SymbolPath,
			[Out, MarshalAs(UnmanagedType.LPStr)] StringBuilder ImageFilePath);

		/// <summary>Locates the specified executable file.</summary>
		/// <param name="FileName">The name of the symbol file to be located. This parameter can be a partial path.</param>
		/// <param name="SymbolPath">
		/// The path where symbol files are located. This string can contain multiple paths separated by semicolons. To retrieve the symbol
		/// path, use the SymGetSearchPath function.
		/// </param>
		/// <param name="ImageFilePath">A pointer to a buffer that receives the full path of the executable file.</param>
		/// <param name="Callback">
		/// <para>
		/// An application-defined callback function that verifies whether the correct executable file was found, or whether the function
		/// should continue its search. For more information, see FindExecutableImageProc.
		/// </para>
		/// <para>This parameter can be <c>NULL</c>.</para>
		/// </param>
		/// <param name="CallerData">Optional user-defined data for the callback function. This parameter can be <c>NULL</c>.</param>
		/// <returns>
		/// <para>If the function succeeds, the return value is an open handle to the executable file.</para>
		/// <para>If the function fails, the return value is <c>NULL</c>. To retrieve extended error information, call GetLastError.</para>
		/// </returns>
		/// <remarks>
		/// <para>
		/// The <c>FindExecutableImageEx</c> function is provided so executable files can be found in several different directories by using
		/// a single function call. If the SymbolPath parameter contains multiple paths, the function searches each specified directory tree
		/// for the executable file. When the file is found, the search stops. Thus, be sure to specify SymbolPath with the paths in the
		/// correct order.
		/// </para>
		/// <para>
		/// All DbgHelp functions, such as this one, are single threaded. Therefore, calls from more than one thread to this function will
		/// likely result in unexpected behavior or memory corruption. To avoid this, you must synchronize all concurrent calls from more
		/// than one thread to this function.
		/// </para>
		/// <para>To call the Unicode version of this function, define DBGHELP_TRANSLATE_TCHAR.</para>
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows/win32/api/dbghelp/nf-dbghelp-findexecutableimageex HANDLE IMAGEAPI
		// FindExecutableImageEx( PCSTR FileName, PCSTR SymbolPath, PSTR ImageFilePath, PFIND_EXE_FILE_CALLBACK Callback, PVOID CallerData );
		[DllImport(Lib_DbgHelp, SetLastError = true, CharSet = CharSet.Auto)]
		[PInvokeData("dbghelp.h", MSDNShortId = "NF:dbghelp.FindExecutableImageEx")]
		public static extern SafeHFILE FindExecutableImageEx([MarshalAs(UnmanagedType.LPTStr)] string FileName, [MarshalAs(UnmanagedType.LPTStr)] string SymbolPath,
			[Out, MarshalAs(UnmanagedType.LPTStr)] StringBuilder ImageFilePath, [Optional] PFIND_EXE_FILE_CALLBACK Callback, [In, Optional] IntPtr CallerData);

		/// <summary>Locates the specified executable file.</summary>
		/// <param name="FileName">The name of the symbol file to be located. This parameter can be a partial path.</param>
		/// <param name="SymbolPaths">
		/// The paths where symbol files are located. To retrieve the symbol path, use the <see cref="SymGetSearchPath"/> function.
		/// </param>
		/// <param name="verifyFoundFile">
		/// <para>
		/// An application-defined callback function that verifies whether the correct executable file was found, or whether the function
		/// should continue its search.
		/// </para>
		/// <para>This parameter can be <see langword="null"/>.</para>
		/// </param>
		/// <returns>The full path of the executable file.</returns>
		/// <remarks>
		/// <para>
		/// The <c>FindExecutableImageEx</c> function is provided so executable files can be found in several different directories by using
		/// a single function call. If the <paramref name="SymbolPaths"/> parameter contains multiple paths, the function searches each
		/// specified directory tree for the executable file. When the file is found, the search stops. Thus, be sure to specify 
		/// <paramref name="SymbolPaths"/> with the paths in the correct order.
		/// </para>
		/// </remarks>
		public static string FindExecutableImageEx(string FileName, string[] SymbolPaths, Func<string, bool> verifyFoundFile = null)
		{
			var sb = new StringBuilder(261);
			if (verifyFoundFile is null)
				return FindExecutableImage(FileName, string.Join(";", SymbolPaths), sb).IsInvalid ? null : sb.ToString();
			else
				return FindExecutableImageEx(FileName, string.Join(";", SymbolPaths), sb, Callback).IsInvalid ? null : sb.ToString();

			bool Callback(HFILE FileHandle, string FileName, IntPtr CallerData) => verifyFoundFile(FileName);
		}

		/// <summary>Gets the last symbol load error.</summary>
		/// <returns>The last symbol load error.</returns>
		// https://docs.microsoft.com/en-us/windows/win32/api/dbghelp/nf-dbghelp-getsymloaderror DWORD IMAGEAPI GetSymLoadError();
		[DllImport(Lib_DbgHelp, SetLastError = false, ExactSpelling = true)]
		[PInvokeData("dbghelp.h", MSDNShortId = "NF:dbghelp.GetSymLoadError")]
		public static extern uint GetSymLoadError();

		/// <summary>Retrieves the time stamp of a loaded image.</summary>
		/// <param name="Module">The base address of an image that is mapped into memory by a call to the MapViewOfFile function.</param>
		/// <returns>
		/// <para>If the function succeeds, the return value is the time stamp from the image.</para>
		/// <para>If the function fails, the return value is zero. To retrieve extended error information, call GetLastError.</para>
		/// </returns>
		/// <remarks>
		/// <para>
		/// The time stamp for an image is initially set by the linker, but it can be modified by operations such as rebasing. The value is
		/// represented in the number of seconds elapsed since midnight (00:00:00), January 1, 1970, Universal Coordinated Time, according
		/// to the system clock. The time stamp can be printed using the C run-time (CRT) function ctime.
		/// </para>
		/// <para>
		/// All DbgHelp Functions, such as this one, are single threaded. Therefore, calls from more than one thread to this function will
		/// likely result in unexpected behavior or memory corruption. To avoid this, you must synchronize all concurrent calls from more
		/// than one thread to this function.
		/// </para>
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows/win32/api/dbghelp/nf-dbghelp-gettimestampforloadedlibrary DWORD IMAGEAPI
		// GetTimestampForLoadedLibrary( HMODULE Module );
		[DllImport(Lib_DbgHelp, SetLastError = true, ExactSpelling = true)]
		[PInvokeData("dbghelp.h", MSDNShortId = "NF:dbghelp.GetTimestampForLoadedLibrary")]
		public static extern uint GetTimestampForLoadedLibrary(HINSTANCE Module);

		/// <summary>
		/// <para>Obtains access to image-specific data.</para>
		/// <para>
		/// This function has been superseded by the ImageDirectoryEntryToDataEx function. Use <c>ImageDirectoryEntryToDataEx</c> to
		/// retrieve the section header.
		/// </para>
		/// </summary>
		/// <param name="Base">The base address of the image.</param>
		/// <param name="MappedAsImage">
		/// If this parameter is <c>TRUE</c>, the file is mapped by the system as an image. If the flag is <c>FALSE</c>, the file is mapped
		/// as a data file by the MapViewOfFile function.
		/// </param>
		/// <param name="DirectoryEntry">
		/// <para>The index number of the desired directory entry. This parameter can be one of the following values.</para>
		/// <list type="table">
		/// <listheader>
		/// <term>Value</term>
		/// <term>Meaning</term>
		/// </listheader>
		/// <item>
		/// <term>IMAGE_DIRECTORY_ENTRY_ARCHITECTURE 7</term>
		/// <term>Architecture-specific data</term>
		/// </item>
		/// <item>
		/// <term>IMAGE_DIRECTORY_ENTRY_BASERELOC 5</term>
		/// <term>Base relocation table</term>
		/// </item>
		/// <item>
		/// <term>IMAGE_DIRECTORY_ENTRY_BOUND_IMPORT 11</term>
		/// <term>Bound import directory</term>
		/// </item>
		/// <item>
		/// <term>IMAGE_DIRECTORY_ENTRY_COM_DESCRIPTOR 14</term>
		/// <term>COM descriptor table</term>
		/// </item>
		/// <item>
		/// <term>IMAGE_DIRECTORY_ENTRY_DEBUG 6</term>
		/// <term>Debug directory</term>
		/// </item>
		/// <item>
		/// <term>IMAGE_DIRECTORY_ENTRY_DELAY_IMPORT 13</term>
		/// <term>Delay import table</term>
		/// </item>
		/// <item>
		/// <term>IMAGE_DIRECTORY_ENTRY_EXCEPTION 3</term>
		/// <term>Exception directory</term>
		/// </item>
		/// <item>
		/// <term>IMAGE_DIRECTORY_ENTRY_EXPORT 0</term>
		/// <term>Export directory</term>
		/// </item>
		/// <item>
		/// <term>IMAGE_DIRECTORY_ENTRY_GLOBALPTR 8</term>
		/// <term>The relative virtual address of global pointer</term>
		/// </item>
		/// <item>
		/// <term>IMAGE_DIRECTORY_ENTRY_IAT 12</term>
		/// <term>Import address table</term>
		/// </item>
		/// <item>
		/// <term>IMAGE_DIRECTORY_ENTRY_IMPORT 1</term>
		/// <term>Import directory</term>
		/// </item>
		/// <item>
		/// <term>IMAGE_DIRECTORY_ENTRY_LOAD_CONFIG 10</term>
		/// <term>Load configuration directory</term>
		/// </item>
		/// <item>
		/// <term>IMAGE_DIRECTORY_ENTRY_RESOURCE 2</term>
		/// <term>Resource directory</term>
		/// </item>
		/// <item>
		/// <term>IMAGE_DIRECTORY_ENTRY_SECURITY 4</term>
		/// <term>Security directory</term>
		/// </item>
		/// <item>
		/// <term>IMAGE_DIRECTORY_ENTRY_TLS 9</term>
		/// <term>Thread local storage directory</term>
		/// </item>
		/// </list>
		/// </param>
		/// <param name="Size">A pointer to a variable that receives the size of the data for the directory entry, in bytes.</param>
		/// <returns>
		/// <para>If the function succeeds, the return value is a pointer to the directory entry's data.</para>
		/// <para>If the function fails, the return value is <c>NULL</c>. To retrieve extended error information, call GetLastError.</para>
		/// </returns>
		/// <remarks>
		/// <para>The <c>ImageDirectoryEntryToData</c> function is used to obtain access to image-specific data.</para>
		/// <para>
		/// All DbgHelp functions, such as this one, are single threaded. Therefore, calls from more than one thread to this function will
		/// likely result in unexpected behavior or memory corruption. To avoid this, you must synchronize all concurrent calls from more
		/// than one thread to this function.
		/// </para>
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows/win32/api/dbghelp/nf-dbghelp-imagedirectoryentrytodata PVOID IMAGEAPI
		// ImageDirectoryEntryToData( PVOID Base, BOOLEAN MappedAsImage, USHORT DirectoryEntry, PULONG Size );
		[DllImport(Lib_DbgHelp, SetLastError = true, ExactSpelling = true)]
		[PInvokeData("dbghelp.h", MSDNShortId = "NF:dbghelp.ImageDirectoryEntryToData")]
		public static extern IntPtr ImageDirectoryEntryToData(IntPtr Base, [MarshalAs(UnmanagedType.U1)] bool MappedAsImage, IMAGE_DIRECTORY_ENTRY DirectoryEntry, out uint Size);

		/// <summary>
		/// Locates a directory entry within the image header and returns the address of the data for the directory entry. This function
		/// returns the section header for the data located, if one exists.
		/// </summary>
		/// <param name="Base">The base address of the image or data file.</param>
		/// <param name="MappedAsImage">
		/// If the flag is <c>TRUE</c>, the file is mapped by the system as an image. If this flag is <c>FALSE</c>, the file is mapped as a
		/// data file by the MapViewOfFile function.
		/// </param>
		/// <param name="DirectoryEntry">
		/// <para>The directory entry to be located. The value must be one of the following values.</para>
		/// <list type="table">
		/// <listheader>
		/// <term>Value</term>
		/// <term>Meaning</term>
		/// </listheader>
		/// <item>
		/// <term>IMAGE_DIRECTORY_ENTRY_ARCHITECTURE 7</term>
		/// <term>Architecture-specific data</term>
		/// </item>
		/// <item>
		/// <term>IMAGE_DIRECTORY_ENTRY_BASERELOC 5</term>
		/// <term>Base relocation table</term>
		/// </item>
		/// <item>
		/// <term>IMAGE_DIRECTORY_ENTRY_BOUND_IMPORT 11</term>
		/// <term>Bound import directory</term>
		/// </item>
		/// <item>
		/// <term>IMAGE_DIRECTORY_ENTRY_COM_DESCRIPTOR 14</term>
		/// <term>COM descriptor table</term>
		/// </item>
		/// <item>
		/// <term>IMAGE_DIRECTORY_ENTRY_DEBUG 6</term>
		/// <term>Debug directory</term>
		/// </item>
		/// <item>
		/// <term>IMAGE_DIRECTORY_ENTRY_DELAY_IMPORT 13</term>
		/// <term>Delay import table</term>
		/// </item>
		/// <item>
		/// <term>IMAGE_DIRECTORY_ENTRY_EXCEPTION 3</term>
		/// <term>Exception directory</term>
		/// </item>
		/// <item>
		/// <term>IMAGE_DIRECTORY_ENTRY_EXPORT 0</term>
		/// <term>Export directory</term>
		/// </item>
		/// <item>
		/// <term>IMAGE_DIRECTORY_ENTRY_GLOBALPTR 8</term>
		/// <term>The relative virtual address of global pointer</term>
		/// </item>
		/// <item>
		/// <term>IMAGE_DIRECTORY_ENTRY_IAT 12</term>
		/// <term>Import address table</term>
		/// </item>
		/// <item>
		/// <term>IMAGE_DIRECTORY_ENTRY_IMPORT 1</term>
		/// <term>Import directory</term>
		/// </item>
		/// <item>
		/// <term>IMAGE_DIRECTORY_ENTRY_LOAD_CONFIG 10</term>
		/// <term>Load configuration directory</term>
		/// </item>
		/// <item>
		/// <term>IMAGE_DIRECTORY_ENTRY_RESOURCE 2</term>
		/// <term>Resource directory</term>
		/// </item>
		/// <item>
		/// <term>IMAGE_DIRECTORY_ENTRY_SECURITY 4</term>
		/// <term>Security directory</term>
		/// </item>
		/// <item>
		/// <term>IMAGE_DIRECTORY_ENTRY_TLS 9</term>
		/// <term>Thread local storage directory</term>
		/// </item>
		/// </list>
		/// </param>
		/// <param name="Size">A pointer to a variable that receives the size of the data for the directory entry that is located.</param>
		/// <param name="FoundHeader">
		/// A pointer to an IMAGE_SECTION_HEADER structure that receives the data. If the section header does not exist, this parameter is <c>NULL</c>.
		/// </param>
		/// <returns>
		/// <para>If the function succeeds, the return value is a pointer to the data for the directory entry.</para>
		/// <para>If the function fails, the return value is <c>NULL</c>. To retrieve extended error information, call GetLastError.</para>
		/// <para>
		/// All DbgHelp functions, such as this one, are single threaded. Therefore, calls from more than one thread to this function will
		/// likely result in unexpected behavior or memory corruption. To avoid this, you must synchronize all concurrent calls from more
		/// than one thread to this function.
		/// </para>
		/// </returns>
		// https://docs.microsoft.com/en-us/windows/win32/api/dbghelp/nf-dbghelp-imagedirectoryentrytodataex PVOID IMAGEAPI
		// ImageDirectoryEntryToDataEx( PVOID Base, BOOLEAN MappedAsImage, USHORT DirectoryEntry, PULONG Size, PIMAGE_SECTION_HEADER
		// *FoundHeader );
		[DllImport(Lib_DbgHelp, SetLastError = true, ExactSpelling = true)]
		[PInvokeData("dbghelp.h", MSDNShortId = "NF:dbghelp.ImageDirectoryEntryToDataEx")]
		public static extern IntPtr ImageDirectoryEntryToDataEx(IntPtr Base, [MarshalAs(UnmanagedType.U1)] bool MappedAsImage, IMAGE_DIRECTORY_ENTRY DirectoryEntry, out uint Size, out IntPtr FoundHeader);

		/// <summary>
		/// <para>Retrieves the version information of the DbgHelp library installed on the system.</para>
		/// <para>To indicate the version of the library with which the application was built, use the ImagehlpApiVersionEx function.</para>
		/// </summary>
		/// <returns>The return value is an API_VERSION structure.</returns>
		/// <remarks>
		/// <para>
		/// Use the information in the API_VERSION structure to determine whether the version of the library installed on the system is
		/// compatible with the version of the library used by the application. Although the library functions are backward compatible,
		/// functions introduced in one version are obviously not available in earlier versions.
		/// </para>
		/// <para>
		/// All DbgHelp functions, such as this one, are single threaded. Therefore, calls from more than one thread to this function will
		/// likely result in unexpected behavior or memory corruption. To avoid this, you must synchronize all concurrent calls from more
		/// than one thread to this function.
		/// </para>
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows/win32/api/dbghelp/nf-dbghelp-imagehlpapiversion LPAPI_VERSION IMAGEAPI ImagehlpApiVersion();
		[PInvokeData("dbghelp.h", MSDNShortId = "NF:dbghelp.ImagehlpApiVersion")]
		public static API_VERSION ImagehlpApiVersion() => ImagehlpApiVersionInternal().ToStructure<API_VERSION>();

		[DllImport(Lib_DbgHelp, SetLastError = false, EntryPoint = "ImagehlpApiVersion")]
		private static extern IntPtr ImagehlpApiVersionInternal();

		/// <summary>Modifies the version information of the library used by the application.</summary>
		/// <param name="AppVersion">A pointer to an API_VERSION structure that contains valid version information for your application.</param>
		/// <returns>The return value is an API_VERSION structure.</returns>
		/// <remarks>
		/// <para>
		/// Use the <c>ImagehlpApiVersionEx</c> function to indicate the version of the library with which the application was built. The
		/// library uses this information to ensure compatibility. For example, consider walking through kernel-mode callback stack frames
		/// (User and GDI exist in kernel mode). If you call <c>ImagehlpApiVersionEx</c> to set the <c>Revision</c> member to version 4 or
		/// later, the StackWalk64 function will continue through a callback stack frame. Otherwise, if you set <c>Revision</c> to a version
		/// earlier than 4, <c>StackWalk64</c> will stop at the kernel transition.
		/// </para>
		/// <para>
		/// All DbgHelp functions, such as this one, are single threaded. Therefore, calls from more than one thread to this function will
		/// likely result in unexpected behavior or memory corruption. To avoid this, you must synchronize all concurrent calls from more
		/// than one thread to this function.
		/// </para>
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows/win32/api/dbghelp/nf-dbghelp-imagehlpapiversionex LPAPI_VERSION IMAGEAPI
		// ImagehlpApiVersionEx( LPAPI_VERSION AppVersion );
		[PInvokeData("dbghelp.h", MSDNShortId = "NF:dbghelp.ImagehlpApiVersionEx")]
		public static API_VERSION ImagehlpApiVersionEx(in API_VERSION AppVersion) => ImagehlpApiVersionExInternal(AppVersion).ToStructure<API_VERSION>();

		[DllImport(Lib_DbgHelp, SetLastError = false, EntryPoint = "ImagehlpApiVersionEx")]
		private static extern IntPtr ImagehlpApiVersionExInternal(in API_VERSION AppVersion);

		/// <summary>Locates the <see cref="IMAGE_NT_HEADERS"/> structure in a PE image and returns a pointer to the data.</summary>
		/// <param name="Base">The base address of an image that is mapped into memory by a call to the MapViewOfFile function.</param>
		/// <returns>
		/// <para>If the function succeeds, the return value is a pointer to an <see cref="IMAGE_NT_HEADERS"/> structure.</para>
		/// <para>If the function fails, the return value is <c>NULL</c>. To retrieve extended error information, call GetLastError.</para>
		/// </returns>
		/// <remarks>
		/// All DbgHelp functions, such as this one, are single threaded. Therefore, calls from more than one thread to this function will
		/// likely result in unexpected behavior or memory corruption. To avoid this, you must synchronize all concurrent calls from more
		/// than one thread to this function.
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows/win32/api/dbghelp/nf-dbghelp-imagentheader PIMAGE_NT_HEADERS IMAGEAPI ImageNtHeader(
		// PVOID Base );
		[DllImport(Lib_DbgHelp, SetLastError = true, ExactSpelling = true)]
		[PInvokeData("dbghelp.h", MSDNShortId = "NF:dbghelp.ImageNtHeader")]
		public static unsafe extern IMAGE_NT_HEADERS* ImageNtHeader(IntPtr Base);

		/// <summary>
		/// Locates a relative virtual address (RVA) within the image header of a file that is mapped as a file and returns a pointer to the
		/// section table entry for that RVA.
		/// </summary>
		/// <param name="NtHeaders">
		/// A pointer to an IMAGE_NT_HEADERS structure. This structure can be obtained by calling the ImageNtHeader function.
		/// </param>
		/// <param name="Base">This parameter is reserved.</param>
		/// <param name="Rva">The relative virtual address to be located.</param>
		/// <returns>
		/// <para>If the function succeeds, the return value is a pointer to an IMAGE_SECTION_HEADER structure.</para>
		/// <para>If the function fails, the return value is <c>NULL</c>. To retrieve extended error information, call GetLastError.</para>
		/// </returns>
		/// <remarks>
		/// All DbgHelp functions, such as this one, are single threaded. Therefore, calls from more than one thread to this function will
		/// likely result in unexpected behavior or memory corruption. To avoid this, you must synchronize all concurrent calls from more
		/// than one thread to this function.
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows/win32/api/dbghelp/nf-dbghelp-imagervatosection PIMAGE_SECTION_HEADER IMAGEAPI
		// ImageRvaToSection( PIMAGE_NT_HEADERS NtHeaders, PVOID Base, ULONG Rva );
		[DllImport(Lib_DbgHelp, SetLastError = true, ExactSpelling = true)]
		[PInvokeData("dbghelp.h", MSDNShortId = "NF:dbghelp.ImageRvaToSection")]
		public static extern IntPtr ImageRvaToSection(in IMAGE_NT_HEADERS NtHeaders, IntPtr Base, uint Rva);

		/// <summary>
		/// Locates a relative virtual address (RVA) within the image header of a file that is mapped as a file and returns a pointer to the
		/// section table entry for that RVA.
		/// </summary>
		/// <param name="NtHeaders">
		/// A pointer to an IMAGE_NT_HEADERS structure. This structure can be obtained by calling the ImageNtHeader function.
		/// </param>
		/// <param name="Base">This parameter is reserved.</param>
		/// <param name="Rva">The relative virtual address to be located.</param>
		/// <returns>
		/// <para>If the function succeeds, the return value is a pointer to an IMAGE_SECTION_HEADER structure.</para>
		/// <para>If the function fails, the return value is <c>NULL</c>. To retrieve extended error information, call GetLastError.</para>
		/// </returns>
		/// <remarks>
		/// All DbgHelp functions, such as this one, are single threaded. Therefore, calls from more than one thread to this function will
		/// likely result in unexpected behavior or memory corruption. To avoid this, you must synchronize all concurrent calls from more
		/// than one thread to this function.
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows/win32/api/dbghelp/nf-dbghelp-imagervatosection PIMAGE_SECTION_HEADER IMAGEAPI
		// ImageRvaToSection( PIMAGE_NT_HEADERS NtHeaders, PVOID Base, ULONG Rva );
		[DllImport(Lib_DbgHelp, SetLastError = true, ExactSpelling = true)]
		[PInvokeData("dbghelp.h", MSDNShortId = "NF:dbghelp.ImageRvaToSection")]
		public static extern IntPtr ImageRvaToSection([In] IntPtr NtHeaders, IntPtr Base, uint Rva);

		/// <summary>
		/// Locates a relative virtual address (RVA) within the image header of a file that is mapped as a file and returns the virtual
		/// address of the corresponding byte in the file.
		/// </summary>
		/// <param name="NtHeaders">
		/// A pointer to an IMAGE_NT_HEADERS structure. This structure can be obtained by calling the ImageNtHeader function.
		/// </param>
		/// <param name="Base">The base address of an image that is mapped into memory through a call to the MapViewOfFile function.</param>
		/// <param name="Rva">The relative virtual address to be located.</param>
		/// <param name="LastRvaSection">
		/// A pointer to an IMAGE_SECTION_HEADER structure that specifies the last RVA section. This is an optional parameter. When
		/// specified, it points to a variable that contains the last section value used for the specified image to translate an RVA to a VA.
		/// </param>
		/// <returns>
		/// <para>If the function succeeds, the return value is the virtual address in the mapped file.</para>
		/// <para>If the function fails, the return value is <c>NULL</c>. To retrieve extended error information, call GetLastError.</para>
		/// </returns>
		/// <remarks>
		/// <para>
		/// The <c>ImageRvaToVa</c> function locates an RVA within the image header of a file that is mapped as a file and returns the
		/// virtual address of the corresponding byte in the file.
		/// </para>
		/// <para>
		/// All DbgHelp functions, such as this one, are single threaded. Therefore, calls from more than one thread to this function will
		/// likely result in unexpected behavior or memory corruption. To avoid this, you must synchronize all concurrent calls from more
		/// than one thread to this function.
		/// </para>
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows/win32/api/dbghelp/nf-dbghelp-imagervatova PVOID IMAGEAPI ImageRvaToVa( PIMAGE_NT_HEADERS
		// NtHeaders, PVOID Base, ULONG Rva, OUT PIMAGE_SECTION_HEADER *LastRvaSection );
		[DllImport(Lib_DbgHelp, SetLastError = true, ExactSpelling = true)]
		[PInvokeData("dbghelp.h", MSDNShortId = "NF:dbghelp.ImageRvaToVa")]
		public static extern IntPtr ImageRvaToVa(in IMAGE_NT_HEADERS NtHeaders, IntPtr Base, uint Rva, out IntPtr LastRvaSection);

		/// <summary>
		/// Locates a relative virtual address (RVA) within the image header of a file that is mapped as a file and returns the virtual
		/// address of the corresponding byte in the file.
		/// </summary>
		/// <param name="NtHeaders">
		/// A pointer to an IMAGE_NT_HEADERS structure. This structure can be obtained by calling the ImageNtHeader function.
		/// </param>
		/// <param name="Base">The base address of an image that is mapped into memory through a call to the MapViewOfFile function.</param>
		/// <param name="Rva">The relative virtual address to be located.</param>
		/// <param name="LastRvaSection">
		/// A pointer to an IMAGE_SECTION_HEADER structure that specifies the last RVA section. This is an optional parameter. When
		/// specified, it points to a variable that contains the last section value used for the specified image to translate an RVA to a VA.
		/// </param>
		/// <returns>
		/// <para>If the function succeeds, the return value is the virtual address in the mapped file.</para>
		/// <para>If the function fails, the return value is <c>NULL</c>. To retrieve extended error information, call GetLastError.</para>
		/// </returns>
		/// <remarks>
		/// <para>
		/// The <c>ImageRvaToVa</c> function locates an RVA within the image header of a file that is mapped as a file and returns the
		/// virtual address of the corresponding byte in the file.
		/// </para>
		/// <para>
		/// All DbgHelp functions, such as this one, are single threaded. Therefore, calls from more than one thread to this function will
		/// likely result in unexpected behavior or memory corruption. To avoid this, you must synchronize all concurrent calls from more
		/// than one thread to this function.
		/// </para>
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows/win32/api/dbghelp/nf-dbghelp-imagervatova PVOID IMAGEAPI ImageRvaToVa( PIMAGE_NT_HEADERS
		// NtHeaders, PVOID Base, ULONG Rva, OUT PIMAGE_SECTION_HEADER *LastRvaSection );
		[DllImport(Lib_DbgHelp, SetLastError = true, ExactSpelling = true)]
		[PInvokeData("dbghelp.h", MSDNShortId = "NF:dbghelp.ImageRvaToVa")]
		public static extern IntPtr ImageRvaToVa(IntPtr NtHeaders, IntPtr Base, uint Rva, out IntPtr LastRvaSection);

		/// <summary>Creates all the directories in the specified path, beginning with the root.</summary>
		/// <param name="DirPath">
		/// A valid path name. If the final component of the path is a directory, not a file name, the string must end with a backslash () character.
		/// </param>
		/// <returns>
		/// <para>If the function succeeds, the return value is <c>TRUE</c>.</para>
		/// <para>If the function fails, the return value is <c>FALSE</c>. To retrieve extended error information, call GetLastError.</para>
		/// </returns>
		/// <remarks>
		/// <para>
		/// Each directory specified is created, if it does not already exist. If only some of the directories are created, the function
		/// will return <c>FALSE</c>.
		/// </para>
		/// <para>This function does not support Unicode strings. To specify a Unicode path, use the SHCreateDirectoryEx function.</para>
		/// <para>
		/// All DbgHelp functions, such as this one, are single threaded. Therefore, calls from more than one thread to this function will
		/// likely result in unexpected behavior or memory corruption. To avoid this, you must synchronize all concurrent calls from more
		/// than one thread to this function.
		/// </para>
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows/win32/api/dbghelp/nf-dbghelp-makesuredirectorypathexists BOOL IMAGEAPI
		// MakeSureDirectoryPathExists( PCSTR DirPath );
		[DllImport(Lib_DbgHelp, SetLastError = true, ExactSpelling = true)]
		[PInvokeData("dbghelp.h", MSDNShortId = "NF:dbghelp.MakeSureDirectoryPathExists")]
		[return: MarshalAs(UnmanagedType.Bool)]
		public static extern bool MakeSureDirectoryPathExists([MarshalAs(UnmanagedType.LPStr)] string DirPath);

		/// <summary>
		/// <para>Obtains access to the debugging information for an image.</para>
		/// <para>
		/// <c>Note</c> This function is provided only for backward compatibility. It does not return reliable information. New applications
		/// should use the SymGetModuleInfo64 and SymLoadModule64 functions.
		/// </para>
		/// </summary>
		/// <param name="FileHandle">A handle to an open executable image or <c>NULL</c>.</param>
		/// <param name="FileName">The name of an executable image file or <c>NULL</c>.</param>
		/// <param name="SymbolPath">
		/// The path where symbol files are located. The path can be multiple paths separated by semicolons. To retrieve the symbol path,
		/// use the SymGetSearchPath function.
		/// </param>
		/// <param name="ImageBase">The base address for the image or zero.</param>
		/// <returns>
		/// <para>If the function succeeds, the return value is a pointer to an IMAGE_DEBUG_INFORMATION structure.</para>
		/// <para>If the function fails, the return value is <c>NULL</c>. To retrieve extended error information, call GetLastError.</para>
		/// </returns>
		/// <remarks>
		/// <para>
		/// The <c>MapDebugInformation</c> function is used to obtain access to an image's debugging information. The debugging information
		/// is extracted from the image or the symbol file and placed into the IMAGE_DEBUG_INFORMATION structure. This structure is
		/// allocated by the library and must be deallocated by using the UnmapDebugInformation function. The memory for the structure is
		/// not in the process's default heap, so attempts to free it with a memory deallocation routine will fail.
		/// </para>
		/// <para>
		/// All DbgHelp functions, such as this one, are single threaded. Therefore, calls from more than one thread to this function will
		/// likely result in unexpected behavior or memory corruption. To avoid this, you must synchronize all concurrent calls from more
		/// than one thread to this function.
		/// </para>
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows/win32/api/dbghelp/nf-dbghelp-mapdebuginformation PIMAGE_DEBUG_INFORMATION IMAGEAPI
		// MapDebugInformation( HANDLE FileHandle, PCSTR FileName, PCSTR SymbolPath, ULONG ImageBase );
		[DllImport(Lib_DbgHelp, SetLastError = true, ExactSpelling = true)]
		[PInvokeData("dbghelp.h", MSDNShortId = "NF:dbghelp.MapDebugInformation")]
		public static extern IntPtr MapDebugInformation([Optional] HFILE FileHandle, [MarshalAs(UnmanagedType.LPStr)] string FileName, [Optional, MarshalAs(UnmanagedType.LPStr)] string SymbolPath, uint ImageBase);

		/// <summary>Searches a directory tree for a specified file.</summary>
		/// <param name="RootPath">The path where the function should begin searching for the file.</param>
		/// <param name="InputPathName">The file for which the function will search. You can use a partial path.</param>
		/// <param name="OutputPathBuffer">
		/// A pointer to a buffer that receives the full path to the file that is found. This string is not modified if the return value is <c>FALSE</c>.
		/// </param>
		/// <returns>
		/// <para>If the function succeeds, the return value is <c>TRUE</c>.</para>
		/// <para>If the function fails, the return value is <c>FALSE</c>. To retrieve extended error information, call GetLastError.</para>
		/// </returns>
		/// <remarks>
		/// <para>
		/// The function searches for the file specified by the InputPathName parameter beginning at the path specified in the RootPath
		/// parameter. The maximum path depth that is allowed in the RootPath is 32 directories. When the function finds the file in the
		/// directory tree, it places the full path to the file in the buffer specified by the OutputPathBuffer parameter. The underlying
		/// file system specifies the order of the subdirectory search.
		/// </para>
		/// <para>
		/// The search can be canceled if you register a SymRegisterCallbackProc64 callback function. For every directory searched,
		/// <c>SearchTreeForFile</c> calls this callback function with CBA_DEFERRED_SYMBOL_LOAD_CANCEL. If the callback function returns
		/// <c>TRUE</c>, <c>SearchTreeForFile</c> cancels the search.
		/// </para>
		/// <para>
		/// This function triggers one CBA_DEFERRED_SYMBOL_LOAD_CANCEL event per directory searched. This allows the caller to cancel the search.
		/// </para>
		/// <para>
		/// All DbgHelp functions, such as this one, are single threaded. Therefore, calls from more than one thread to this function will
		/// likely result in unexpected behavior or memory corruption. To avoid this, you must synchronize all concurrent calls from more
		/// than one thread to this function.
		/// </para>
		/// <para>To call the Unicode version of this function, define DBGHELP_TRANSLATE_TCHAR.</para>
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows/win32/api/dbghelp/nf-dbghelp-searchtreeforfile BOOL IMAGEAPI SearchTreeForFile( PCSTR
		// RootPath, PCSTR InputPathName, PSTR OutputPathBuffer );
		[DllImport(Lib_DbgHelp, SetLastError = true, CharSet = CharSet.Auto)]
		[PInvokeData("dbghelp.h", MSDNShortId = "NF:dbghelp.SearchTreeForFile")]
		[return: MarshalAs(UnmanagedType.Bool)]
		public static extern bool SearchTreeForFile([MarshalAs(UnmanagedType.LPTStr)] string RootPath, [MarshalAs(UnmanagedType.LPTStr)] string InputPathName, [MarshalAs(UnmanagedType.LPTStr)] StringBuilder OutputPathBuffer);

		/// <summary>Sets a symbol load error.</summary>
		/// <param name="error">A symbol load error.</param>
		/// <returns>This function does not return a value.</returns>
		// https://docs.microsoft.com/en-us/windows/win32/api/dbghelp/nf-dbghelp-setsymloaderror void IMAGEAPI SetSymLoadError( DWORD error );
		[DllImport(Lib_DbgHelp, SetLastError = false, ExactSpelling = true)]
		[PInvokeData("dbghelp.h", MSDNShortId = "NF:dbghelp.SetSymLoadError")]
		public static extern void SetSymLoadError(uint error);

		/// <summary>Obtains a stack trace.</summary>
		/// <param name="MachineType">
		/// <para>The architecture type of the computer for which the stack trace is generated. This parameter can be one of the following values.</para>
		/// <list type="table">
		/// <listheader>
		/// <term>Value</term>
		/// <term>Meaning</term>
		/// </listheader>
		/// <item>
		/// <term>IMAGE_FILE_MACHINE_I386 0x014c</term>
		/// <term>Intel x86</term>
		/// </item>
		/// <item>
		/// <term>IMAGE_FILE_MACHINE_IA64 0x0200</term>
		/// <term>Intel Itanium</term>
		/// </item>
		/// <item>
		/// <term>IMAGE_FILE_MACHINE_AMD64 0x8664</term>
		/// <term>x64 (AMD64 or EM64T)</term>
		/// </item>
		/// </list>
		/// </param>
		/// <param name="hProcess">A handle to the process for which the stack trace is generated. If the caller supplies a valid callback pointer for the ReadMemoryRoutine parameter, then this value does not have to be a valid process handle. It can be a token that is unique and consistently the same for all calls to the <c>StackWalk64</c> function. If the symbol handler is used with <c>StackWalk64</c>, use the same process handles for the calls to each function.</param>
		/// <param name="hThread">A handle to the thread for which the stack trace is generated. If the caller supplies a valid callback pointer for the ReadMemoryRoutine parameter, then this value does not have to be a valid thread handle. It can be a token that is unique and consistently the same for all calls to the <c>StackWalk64</c> function.</param>
		/// <param name="StackFrame">A pointer to a STACKFRAME64 structure. This structure receives information for the next frame, if the function call succeeds.</param>
		/// <param name="ContextRecord">
		/// <para>A pointer to a CONTEXT structure. This parameter is required only when the MachineType parameter is not <c>IMAGE_FILE_MACHINE_I386</c>. However, it is recommended that this parameter contain a valid context record. This allows <c>StackWalk64</c> to handle a greater variety of situations.</para>
		/// <para>This context may be modified, so do not pass a context record that should not be modified.</para>
		/// </param>
		/// <param name="ReadMemoryRoutine">
		/// <para>A callback routine that provides memory read services. When the <c>StackWalk64</c> function needs to read memory from the process's address space, the ReadProcessMemoryProc64 callback is used.</para>
		/// <para>If this parameter is <c>NULL</c>, then the function uses a default routine. In this case, the hProcess parameter must be a valid process handle.</para>
		/// <para>If this parameter is not <c>NULL</c>, the application should implement and register a symbol handler callback function that handles <c>CBA_READ_MEMORY</c>.</para>
		/// </param>
		/// <param name="FunctionTableAccessRoutine">
		/// <para>A callback routine that provides access to the run-time function table for the process. This parameter is required because the <c>StackWalk64</c> function does not have access to the process's run-time function table. For more information, see FunctionTableAccessProc64.</para>
		/// <para>The symbol handler provides functions that load and access the run-time table. If these functions are used, then SymFunctionTableAccess64 can be passed as a valid parameter.</para>
		/// </param>
		/// <param name="GetModuleBaseRoutine">
		/// <para>A callback routine that provides a module base for any given virtual address. This parameter is required. For more information, see GetModuleBaseProc64.</para>
		/// <para>The symbol handler provides functions that load and maintain module information. If these functions are used, then SymGetModuleBase64 can be passed as a valid parameter.</para>
		/// </param>
		/// <param name="TranslateAddress">
		/// <para>A callback routine that provides address translation for 16-bit addresses. For more information, see TranslateAddressProc64.</para>
		/// <para>Most callers of <c>StackWalk64</c> can safely pass <c>NULL</c> for this parameter.</para>
		/// </param>
		/// <returns>
		/// <para>If the function succeeds, the return value is <c>TRUE</c>.</para>
		/// <para>If the function fails, the return value is <c>FALSE</c>. Note that <c>StackWalk64</c> generally does not set the last error code.</para>
		/// </returns>
		/// <remarks>
		/// <para>The <c>StackWalk64</c> function provides a portable method for obtaining a stack trace. Using the <c>StackWalk64</c> function is recommended over writing your own function because of all the complexities associated with stack walking on platforms. In addition, there are compiler options that cause the stack to appear differently, depending on how the module is compiled. By using this function, your application has a portable stack trace that continues to work as the compiler and operating system change.</para>
		/// <para>The first call to this function will fail if the <c>AddrPC</c>, <c>AddrFrame</c>, and <c>AddrStack</c> members of the STACKFRAME64 structure passed in the StackFrame parameter are not initialized.</para>
		/// <para>All DbgHelp functions, such as this one, are single threaded. Therefore, calls from more than one thread to this function will likely result in unexpected behavior or memory corruption. To avoid this, you must synchronize all concurrent calls from more than one thread to this function.</para>
		/// <para>This function supersedes the <c>StackWalk</c> function. For more information, see Updated Platform Support. <c>StackWalk</c> is defined as follows in DbgHelp.h.</para>
		/// <para><code>#if !defined(_IMAGEHLP_SOURCE_) &amp;&amp; defined(_IMAGEHLP64) #define StackWalk StackWalk64 #else BOOL IMAGEAPI StackWalk( DWORD MachineType, __in HANDLE hProcess, __in HANDLE hThread, __inout LPSTACKFRAME StackFrame, __inout PVOID ContextRecord, __in_opt PREAD_PROCESS_MEMORY_ROUTINE ReadMemoryRoutine, __in_opt PFUNCTION_TABLE_ACCESS_ROUTINE FunctionTableAccessRoutine, __in_opt PGET_MODULE_BASE_ROUTINE GetModuleBaseRoutine, __in_opt PTRANSLATE_ADDRESS_ROUTINE TranslateAddress ); #endif </code></para>
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows/win32/api/dbghelp/nf-dbghelp-stackwalk
		// BOOL IMAGEAPI StackWalk( DWORD MachineType, HANDLE hProcess, HANDLE hThread, LPSTACKFRAME StackFrame, PVOID ContextRecord, PREAD_PROCESS_MEMORY_ROUTINE ReadMemoryRoutine, PFUNCTION_TABLE_ACCESS_ROUTINE FunctionTableAccessRoutine, PGET_MODULE_BASE_ROUTINE GetModuleBaseRoutine, PTRANSLATE_ADDRESS_ROUTINE TranslateAddress );
		[DllImport(Lib_DbgHelp, SetLastError = false, ExactSpelling = true)]
		[PInvokeData("dbghelp.h", MSDNShortId = "NF:dbghelp.StackWalk")]
		[return: MarshalAs(UnmanagedType.Bool)]
		public static extern bool StackWalk(IMAGE_FILE_MACHINE MachineType, HPROCESS hProcess, HTHREAD hThread, ref STACKFRAME StackFrame, [In, Out] IntPtr ContextRecord,
			[Optional] PREAD_PROCESS_MEMORY_ROUTINE ReadMemoryRoutine, [Optional] PFUNCTION_TABLE_ACCESS_ROUTINE FunctionTableAccessRoutine,
			[Optional] PGET_MODULE_BASE_ROUTINE GetModuleBaseRoutine, [Optional] PTRANSLATE_ADDRESS_ROUTINE TranslateAddress);

		/// <summary>Obtains a stack trace.</summary>
		/// <param name="MachineType">
		/// <para>
		/// The architecture type of the computer for which the stack trace is generated. This parameter can be one of the following values.
		/// </para>
		/// <list type="table">
		/// <listheader>
		/// <term>Value</term>
		/// <term>Meaning</term>
		/// </listheader>
		/// <item>
		/// <term>IMAGE_FILE_MACHINE_I386 0x014c</term>
		/// <term>Intel x86</term>
		/// </item>
		/// <item>
		/// <term>IMAGE_FILE_MACHINE_IA64 0x0200</term>
		/// <term>Intel Itanium</term>
		/// </item>
		/// <item>
		/// <term>IMAGE_FILE_MACHINE_AMD64 0x8664</term>
		/// <term>x64 (AMD64 or EM64T)</term>
		/// </item>
		/// </list>
		/// </param>
		/// <param name="hProcess">
		/// A handle to the process for which the stack trace is generated. If the caller supplies a valid callback pointer for the
		/// ReadMemoryRoutine parameter, then this value does not have to be a valid process handle. It can be a token that is unique and
		/// consistently the same for all calls to the <c>StackWalk64</c> function. If the symbol handler is used with <c>StackWalk64</c>,
		/// use the same process handles for the calls to each function.
		/// </param>
		/// <param name="hThread">
		/// A handle to the thread for which the stack trace is generated. If the caller supplies a valid callback pointer for the
		/// ReadMemoryRoutine parameter, then this value does not have to be a valid thread handle. It can be a token that is unique and
		/// consistently the same for all calls to the <c>StackWalk64</c> function.
		/// </param>
		/// <param name="StackFrame">
		/// A pointer to a STACKFRAME64 structure. This structure receives information for the next frame, if the function call succeeds.
		/// </param>
		/// <param name="ContextRecord">
		/// <para>
		/// A pointer to a CONTEXT structure. This parameter is required only when the MachineType parameter is not
		/// <c>IMAGE_FILE_MACHINE_I386</c>. However, it is recommended that this parameter contain a valid context record. This allows
		/// <c>StackWalk64</c> to handle a greater variety of situations.
		/// </para>
		/// <para>This context may be modified, so do not pass a context record that should not be modified.</para>
		/// </param>
		/// <param name="ReadMemoryRoutine">
		/// <para>
		/// A callback routine that provides memory read services. When the <c>StackWalk64</c> function needs to read memory from the
		/// process's address space, the ReadProcessMemoryProc64 callback is used.
		/// </para>
		/// <para>
		/// If this parameter is <c>NULL</c>, then the function uses a default routine. In this case, the hProcess parameter must be a valid
		/// process handle.
		/// </para>
		/// <para>
		/// If this parameter is not <c>NULL</c>, the application should implement and register a symbol handler callback function that
		/// handles <c>CBA_READ_MEMORY</c>.
		/// </para>
		/// </param>
		/// <param name="FunctionTableAccessRoutine">
		/// <para>
		/// A callback routine that provides access to the run-time function table for the process. This parameter is required because the
		/// <c>StackWalk64</c> function does not have access to the process's run-time function table. For more information, see FunctionTableAccessProc64.
		/// </para>
		/// <para>
		/// The symbol handler provides functions that load and access the run-time table. If these functions are used, then
		/// SymFunctionTableAccess64 can be passed as a valid parameter.
		/// </para>
		/// </param>
		/// <param name="GetModuleBaseRoutine">
		/// <para>
		/// A callback routine that provides a module base for any given virtual address. This parameter is required. For more information,
		/// see GetModuleBaseProc64.
		/// </para>
		/// <para>
		/// The symbol handler provides functions that load and maintain module information. If these functions are used, then
		/// SymGetModuleBase64 can be passed as a valid parameter.
		/// </para>
		/// </param>
		/// <param name="TranslateAddress">
		/// <para>A callback routine that provides address translation for 16-bit addresses. For more information, see TranslateAddressProc64.</para>
		/// <para>Most callers of <c>StackWalk64</c> can safely pass <c>NULL</c> for this parameter.</para>
		/// </param>
		/// <returns>
		/// <para>If the function succeeds, the return value is <c>TRUE</c>.</para>
		/// <para>
		/// If the function fails, the return value is <c>FALSE</c>. Note that <c>StackWalk64</c> generally does not set the last error code.
		/// </para>
		/// </returns>
		/// <remarks>
		/// <para>
		/// The <c>StackWalk64</c> function provides a portable method for obtaining a stack trace. Using the <c>StackWalk64</c> function is
		/// recommended over writing your own function because of all the complexities associated with stack walking on platforms. In
		/// addition, there are compiler options that cause the stack to appear differently, depending on how the module is compiled. By
		/// using this function, your application has a portable stack trace that continues to work as the compiler and operating system change.
		/// </para>
		/// <para>
		/// The first call to this function will fail if the <c>AddrPC</c>, <c>AddrFrame</c>, and <c>AddrStack</c> members of the
		/// STACKFRAME64 structure passed in the StackFrame parameter are not initialized.
		/// </para>
		/// <para>
		/// All DbgHelp functions, such as this one, are single threaded. Therefore, calls from more than one thread to this function will
		/// likely result in unexpected behavior or memory corruption. To avoid this, you must synchronize all concurrent calls from more
		/// than one thread to this function.
		/// </para>
		/// <para>
		/// This function supersedes the <c>StackWalk</c> function. For more information, see Updated Platform Support. <c>StackWalk</c> is
		/// defined as follows in DbgHelp.h.
		/// </para>
		/// <para>
		/// <code>#if !defined(_IMAGEHLP_SOURCE_) &amp;&amp; defined(_IMAGEHLP64) #define StackWalk StackWalk64 #else BOOL IMAGEAPI StackWalk( DWORD MachineType, __in HANDLE hProcess, __in HANDLE hThread, __inout LPSTACKFRAME StackFrame, __inout PVOID ContextRecord, __in_opt PREAD_PROCESS_MEMORY_ROUTINE ReadMemoryRoutine, __in_opt PFUNCTION_TABLE_ACCESS_ROUTINE FunctionTableAccessRoutine, __in_opt PGET_MODULE_BASE_ROUTINE GetModuleBaseRoutine, __in_opt PTRANSLATE_ADDRESS_ROUTINE TranslateAddress ); #endif</code>
		/// </para>
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows/win32/api/dbghelp/nf-dbghelp-stackwalk64 BOOL IMAGEAPI StackWalk64( DWORD MachineType,
		// HANDLE hProcess, HANDLE hThread, LPSTACKFRAME64 StackFrame, PVOID ContextRecord, PREAD_PROCESS_MEMORY_ROUTINE64
		// ReadMemoryRoutine, PFUNCTION_TABLE_ACCESS_ROUTINE64 FunctionTableAccessRoutine, PGET_MODULE_BASE_ROUTINE64 GetModuleBaseRoutine,
		// PTRANSLATE_ADDRESS_ROUTINE64 TranslateAddress );
		[DllImport(Lib_DbgHelp, SetLastError = false, ExactSpelling = true)]
		[PInvokeData("dbghelp.h", MSDNShortId = "NF:dbghelp.StackWalk64")]
		[return: MarshalAs(UnmanagedType.Bool)]
		public static extern bool StackWalk64(IMAGE_FILE_MACHINE MachineType, HPROCESS hProcess, HTHREAD hThread, ref STACKFRAME64 StackFrame, [In, Out] IntPtr ContextRecord,
			[Optional] PREAD_PROCESS_MEMORY_ROUTINE64 ReadMemoryRoutine, [Optional] PFUNCTION_TABLE_ACCESS_ROUTINE64 FunctionTableAccessRoutine,
			[Optional] PGET_MODULE_BASE_ROUTINE64 GetModuleBaseRoutine, [Optional] PTRANSLATE_ADDRESS_ROUTINE64 TranslateAddress);

		/// <summary>Obtains a stack trace.</summary>
		/// <param name="MachineType">
		/// <para>
		/// The architecture type of the computer for which the stack trace is generated. This parameter can be one of the following values.
		/// </para>
		/// <list type="table">
		/// <listheader>
		/// <term>Value</term>
		/// <term>Meaning</term>
		/// </listheader>
		/// <item>
		/// <term>IMAGE_FILE_MACHINE_I386 0x014c</term>
		/// <term>Intel x86</term>
		/// </item>
		/// <item>
		/// <term>IMAGE_FILE_MACHINE_IA64 0x0200</term>
		/// <term>Intel Itanium</term>
		/// </item>
		/// <item>
		/// <term>IMAGE_FILE_MACHINE_AMD64 0x8664</term>
		/// <term>x64 (AMD64 or EM64T)</term>
		/// </item>
		/// </list>
		/// </param>
		/// <param name="hProcess">
		/// A handle to the process for which the stack trace is generated. If the caller supplies a valid callback pointer for the
		/// ReadMemoryRoutine parameter, then this value does not have to be a valid process handle. It can be a token that is unique and
		/// consistently the same for all calls to the <c>StackWalkEx</c> function. If the symbol handler is used with <c>StackWalkEx</c>,
		/// use the same process handles for the calls to each function.
		/// </param>
		/// <param name="hThread">
		/// A handle to the thread for which the stack trace is generated. If the caller supplies a valid callback pointer for the
		/// ReadMemoryRoutine parameter, then this value does not have to be a valid thread handle. It can be a token that is unique and
		/// consistently the same for all calls to the <c>StackWalkEx</c> function.
		/// </param>
		/// <param name="StackFrame">
		/// A pointer to a STACKFRAME_EX structure. This structure receives information for the next frame, if the function call succeeds.
		/// </param>
		/// <param name="ContextRecord">
		/// <para>
		/// A pointer to a CONTEXT structure. This parameter is required only when the MachineType parameter is not
		/// <c>IMAGE_FILE_MACHINE_I386</c>. However, it is recommended that this parameter contain a valid context record. This allows
		/// <c>StackWalkEx</c> to handle a greater variety of situations.
		/// </para>
		/// <para>This context may be modified, so do not pass a context record that should not be modified.</para>
		/// </param>
		/// <param name="ReadMemoryRoutine">
		/// <para>
		/// A callback routine that provides memory read services. When the <c>StackWalkEx</c> function needs to read memory from the
		/// process's address space, the ReadProcessMemoryProc64 callback is used.
		/// </para>
		/// <para>
		/// If this parameter is <c>NULL</c>, then the function uses a default routine. In this case, the hProcess parameter must be a valid
		/// process handle.
		/// </para>
		/// <para>
		/// If this parameter is not <c>NULL</c>, the application should implement and register a symbol handler callback function that
		/// handles <c>CBA_READ_MEMORY</c>.
		/// </para>
		/// </param>
		/// <param name="FunctionTableAccessRoutine">
		/// <para>
		/// A callback routine that provides access to the run-time function table for the process. This parameter is required because the
		/// <c>StackWalkEx</c> function does not have access to the process's run-time function table. For more information, see FunctionTableAccessProc64.
		/// </para>
		/// <para>
		/// The symbol handler provides functions that load and access the run-time table. If these functions are used, then
		/// SymFunctionTableAccess64 can be passed as a valid parameter.
		/// </para>
		/// </param>
		/// <param name="GetModuleBaseRoutine">
		/// <para>
		/// A callback routine that provides a module base for any given virtual address. This parameter is required. For more information,
		/// see GetModuleBaseProc64.
		/// </para>
		/// <para>
		/// The symbol handler provides functions that load and maintain module information. If these functions are used, then
		/// SymGetModuleBase64 can be passed as a valid parameter.
		/// </para>
		/// </param>
		/// <param name="TranslateAddress">
		/// <para>A callback routine that provides address translation for 16-bit addresses. For more information, see TranslateAddressProc64.</para>
		/// <para>Most callers of <c>StackWalkEx</c> can safely pass <c>NULL</c> for this parameter.</para>
		/// </param>
		/// <param name="Flags">
		/// <para>A combination of zero or more flags.</para>
		/// <para>SYM_STKWALK_DEFAULT (0)</para>
		/// <para>SYM_STKWALK_FORCE_FRAMEPTR (1)</para>
		/// </param>
		/// <returns>
		/// <para>If the function succeeds, the return value is <c>TRUE</c>.</para>
		/// <para>
		/// If the function fails, the return value is <c>FALSE</c>. Note that <c>StackWalkEx</c> generally does not set the last error code.
		/// </para>
		/// </returns>
		/// <remarks>
		/// <para>
		/// The <c>StackWalkEx</c> function provides a portable method for obtaining a stack trace. Using the <c>StackWalkEx</c> function is
		/// recommended over writing your own function because of all the complexities associated with stack walking on platforms. In
		/// addition, there are compiler options that cause the stack to appear differently, depending on how the module is compiled. By
		/// using this function, your application has a portable stack trace that continues to work as the compiler and operating system change.
		/// </para>
		/// <para>
		/// The first call to this function will fail if the <c>AddrPC</c>, <c>AddrFrame</c>, and <c>AddrStack</c> members of the
		/// STACKFRAME64 structure passed in the StackFrame parameter are not initialized.
		/// </para>
		/// <para>
		/// All DbgHelp functions, such as this one, are single threaded. Therefore, calls from more than one thread to this function will
		/// likely result in unexpected behavior or memory corruption. To avoid this, you must synchronize all concurrent calls from more
		/// than one thread to this function.
		/// </para>
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows/win32/api/dbghelp/nf-dbghelp-stackwalkex BOOL IMAGEAPI StackWalkEx( DWORD MachineType,
		// HANDLE hProcess, HANDLE hThread, LPSTACKFRAME_EX StackFrame, PVOID ContextRecord, PREAD_PROCESS_MEMORY_ROUTINE64
		// ReadMemoryRoutine, PFUNCTION_TABLE_ACCESS_ROUTINE64 FunctionTableAccessRoutine, PGET_MODULE_BASE_ROUTINE64 GetModuleBaseRoutine,
		// PTRANSLATE_ADDRESS_ROUTINE64 TranslateAddress, DWORD Flags );
		[DllImport(Lib_DbgHelp, SetLastError = false, ExactSpelling = true)]
		[PInvokeData("dbghelp.h", MSDNShortId = "NF:dbghelp.StackWalkEx")]
		[return: MarshalAs(UnmanagedType.Bool)]
		public static extern bool StackWalkEx(IMAGE_FILE_MACHINE MachineType, HPROCESS hProcess, HTHREAD hThread, ref STACKFRAME_EX StackFrame, [In, Out] IntPtr ContextRecord,
			[Optional] PREAD_PROCESS_MEMORY_ROUTINE64 ReadMemoryRoutine, [Optional] PFUNCTION_TABLE_ACCESS_ROUTINE64 FunctionTableAccessRoutine,
			[Optional] PGET_MODULE_BASE_ROUTINE64 GetModuleBaseRoutine, [Optional] PTRANSLATE_ADDRESS_ROUTINE64 TranslateAddress, SYM_STKWALK Flags);

		/// <summary>Undecorates the specified decorated C++ symbol name.</summary>
		/// <param name="name">
		/// The decorated C++ symbol name. This name can be identified by the first character of the name, which is always a question mark (?).
		/// </param>
		/// <param name="outputString">A pointer to a string buffer that receives the undecorated name.</param>
		/// <param name="maxStringLength">The size of the UnDecoratedName buffer, in characters.</param>
		/// <param name="flags">
		/// <para>The options for how the decorated name is undecorated. This parameter can be zero or more of the following values.</para>
		/// <list type="table">
		/// <listheader>
		/// <term>Value</term>
		/// <term>Meaning</term>
		/// </listheader>
		/// <item>
		/// <term>UNDNAME_32_BIT_DECODE 0x0800</term>
		/// <term>Undecorate 32-bit decorated names.</term>
		/// </item>
		/// <item>
		/// <term>UNDNAME_COMPLETE 0x0000</term>
		/// <term>Enable full undecoration.</term>
		/// </item>
		/// <item>
		/// <term>UNDNAME_NAME_ONLY 0x1000</term>
		/// <term>Undecorate only the name for primary declaration. Returns [scope::]name. Does expand template parameters.</term>
		/// </item>
		/// <item>
		/// <term>UNDNAME_NO_ACCESS_SPECIFIERS 0x0080</term>
		/// <term>Disable expansion of access specifiers for members.</term>
		/// </item>
		/// <item>
		/// <term>UNDNAME_NO_ALLOCATION_LANGUAGE 0x0010</term>
		/// <term>Disable expansion of the declaration language specifier.</term>
		/// </item>
		/// <item>
		/// <term>UNDNAME_NO_ALLOCATION_MODEL 0x0008</term>
		/// <term>Disable expansion of the declaration model.</term>
		/// </item>
		/// <item>
		/// <term>UNDNAME_NO_ARGUMENTS 0x2000</term>
		/// <term>Do not undecorate function arguments.</term>
		/// </item>
		/// <item>
		/// <term>UNDNAME_NO_CV_THISTYPE 0x0040</term>
		/// <term>Disable expansion of CodeView modifiers on the this type for primary declaration.</term>
		/// </item>
		/// <item>
		/// <term>UNDNAME_NO_FUNCTION_RETURNS 0x0004</term>
		/// <term>Disable expansion of return types for primary declarations.</term>
		/// </item>
		/// <item>
		/// <term>UNDNAME_NO_LEADING_UNDERSCORES 0x0001</term>
		/// <term>Remove leading underscores from Microsoft keywords.</term>
		/// </item>
		/// <item>
		/// <term>UNDNAME_NO_MEMBER_TYPE 0x0200</term>
		/// <term>Disable expansion of the static or virtual attribute of members.</term>
		/// </item>
		/// <item>
		/// <term>UNDNAME_NO_MS_KEYWORDS 0x0002</term>
		/// <term>Disable expansion of Microsoft keywords.</term>
		/// </item>
		/// <item>
		/// <term>UNDNAME_NO_MS_THISTYPE 0x0020</term>
		/// <term>Disable expansion of Microsoft keywords on the this type for primary declaration.</term>
		/// </item>
		/// <item>
		/// <term>UNDNAME_NO_RETURN_UDT_MODEL 0x0400</term>
		/// <term>Disable expansion of the Microsoft model for user-defined type returns.</term>
		/// </item>
		/// <item>
		/// <term>UNDNAME_NO_SPECIAL_SYMS 0x4000</term>
		/// <term>Do not undecorate special names, such as vtable, vcall, vector, metatype, and so on.</term>
		/// </item>
		/// <item>
		/// <term>UNDNAME_NO_THISTYPE 0x0060</term>
		/// <term>Disable all modifiers on the this type.</term>
		/// </item>
		/// <item>
		/// <term>UNDNAME_NO_THROW_SIGNATURES 0x0100</term>
		/// <term>Disable expansion of throw-signatures for functions and pointers to functions.</term>
		/// </item>
		/// </list>
		/// </param>
		/// <returns>
		/// <para>
		/// If the function succeeds, the return value is the number of characters in the UnDecoratedName buffer, not including the NULL terminator.
		/// </para>
		/// <para>If the function fails, the return value is zero. To retrieve extended error information, call GetLastError.</para>
		/// <para>If the function fails and returns zero, the content of the UnDecoratedName buffer is undetermined.</para>
		/// </returns>
		/// <remarks>
		/// <para>To use undecorated symbols, call the SymSetOptions function with the <c>SYMOPT_UNDNAME</c> option.</para>
		/// <para>
		/// All DbgHelp functions, such as this one, are single threaded. Therefore, calls from more than one thread to this function will
		/// likely result in unexpected behavior or memory corruption. To avoid this, you must synchronize all concurrent calls from more
		/// than one thread to this function.
		/// </para>
		/// <para>To call the Unicode version of this function, define <c>DBGHELP_TRANSLATE_TCHAR</c>.</para>
		/// <para>Examples</para>
		/// <para>For an example, see Retrieving Undecorated Symbol Names.</para>
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows/win32/api/dbghelp/nf-dbghelp-undecoratesymbolname DWORD IMAGEAPI UnDecorateSymbolName(
		// PCSTR name, PSTR outputString, DWORD maxStringLength, DWORD flags );
		[DllImport(Lib_DbgHelp, SetLastError = true, CharSet = CharSet.Auto)]
		[PInvokeData("dbghelp.h", MSDNShortId = "NF:dbghelp.UnDecorateSymbolName")]
		public static extern uint UnDecorateSymbolName([MarshalAs(UnmanagedType.LPTStr)] string name, [Out, MarshalAs(UnmanagedType.LPTStr)] StringBuilder outputString,
			uint maxStringLength, UNDNAME flags);

		/// <summary>
		/// <para>Deallocates the memory and resources allocated by a call to the MapDebugInformation function.</para>
		/// <para>
		/// <c>Note</c> This function is provided only for backward compatibility. New applications should use the SymUnloadModule64 function.
		/// </para>
		/// </summary>
		/// <param name="DebugInfo">A pointer to an IMAGE_DEBUG_INFORMATION structure that is returned from a call to MapDebugInformation.</param>
		/// <returns>
		/// <para>If the function succeeds, the return value is <c>TRUE</c>.</para>
		/// <para>If the function fails, the return value is <c>FALSE</c>. To retrieve extended error information, call GetLastError.</para>
		/// </returns>
		/// <remarks>
		/// <para>
		/// The <c>UnmapDebugInformation</c> function is the counterpart to the MapDebugInformation function and must be used to deallocate
		/// the memory and resources allocated by a call to the MapDebugInformation function.
		/// </para>
		/// <para>
		/// All DbgHelp functions, such as this one, are single threaded. Therefore, calls from more than one thread to this function will
		/// likely result in unexpected behavior or memory corruption. To avoid this, you must synchronize all concurrent calls from more
		/// than one thread to this function.
		/// </para>
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows/win32/api/dbghelp/nf-dbghelp-unmapdebuginformation BOOL IMAGEAPI UnmapDebugInformation(
		// PIMAGE_DEBUG_INFORMATION DebugInfo );
		[DllImport(Lib_DbgHelp, SetLastError = true, ExactSpelling = true)]
		[PInvokeData("dbghelp.h", MSDNShortId = "NF:dbghelp.UnmapDebugInformation")]
		[return: MarshalAs(UnmanagedType.Bool)]
		public static extern bool UnmapDebugInformation(IntPtr DebugInfo);
	}
}