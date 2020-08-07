using System;
using System.Runtime.InteropServices;
using System.Text;
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
		[UnmanagedFunctionPointer(CallingConvention.Winapi, CharSet = CharSet.Auto)]
		[PInvokeData("dbghelp.h", MSDNShortId = "NC:dbghelp.PENUMLOADED_MODULES_CALLBACK")]
		[return: MarshalAs(UnmanagedType.Bool)]
		public delegate bool PENUMLOADED_MODULES_CALLBACK([MarshalAs(UnmanagedType.LPTStr)] string ModuleName, [In] IntPtr ModuleBase, [In] IntPtr ModuleSize, [In, Optional] IntPtr UserContext);

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

		/// <summary>
		/// Identifies the type of information returned by the MiniDumpCallback function. Not all memory failures will cause a callback; for
		/// example if the failure is within a stack then the failure is considered to be unrecoverable and the minidump will fail.
		/// </summary>
		// https://docs.microsoft.com/en-us/windows/win32/api/minidumpapiset/ne-minidumpapiset-minidump_callback_type typedef enum
		// _MINIDUMP_CALLBACK_TYPE { ModuleCallback, ThreadCallback, ThreadExCallback, IncludeThreadCallback, IncludeModuleCallback,
		// MemoryCallback, CancelCallback, WriteKernelMinidumpCallback, KernelMinidumpStatusCallback, RemoveMemoryCallback,
		// IncludeVmRegionCallback, IoStartCallback, IoWriteAllCallback, IoFinishCallback, ReadMemoryFailureCallback,
		// SecondaryFlagsCallback, IsProcessSnapshotCallback, VmStartCallback, VmQueryCallback, VmPreReadCallback, VmPostReadCallback } MINIDUMP_CALLBACK_TYPE;
		[PInvokeData("minidumpapiset.h", MSDNShortId = "NE:minidumpapiset._MINIDUMP_CALLBACK_TYPE")]
		public enum MINIDUMP_CALLBACK_TYPE
		{
			/// <summary>The callback function returns module information.</summary>
			ModuleCallback,

			/// <summary>The callback function returns thread information.</summary>
			ThreadCallback,

			/// <summary>The callback function returns extended thread information.</summary>
			ThreadExCallback,

			/// <summary>
			/// The callback function indicates which threads are to be included. It is called as the minidump library is enumerating the
			/// threads in a process, rather than after the information gathered, as it is with ThreadCallback or ThreadExCallback. It is
			/// called for each thread. If the callback function returns FALSE, the current thread is excluded. This allows the caller to
			/// obtain information for a subset of the threads in a process, without suspending threads that are not of interest.
			/// Alternately, you can modify the ThreadWriteFlags member of the MINIDUMP_CALLBACK_OUTPUT structure and return TRUE to avoid
			/// gathering unnecessary information for the thread.
			/// </summary>
			IncludeThreadCallback,

			/// <summary>
			/// The callback function indicates which modules are to be included. The callback function is called as the minidump library is
			/// enumerating the modules in a process, rather than after the information is gathered, as it is with ModuleCallback. It is
			/// called for each module. If the callback function returns FALSE, the current module is excluded. Alternatively, you can
			/// modify the ModuleWriteFlags member of the MINIDUMP_CALLBACK_OUTPUT structure and return TRUE to avoid gathering unnecessary
			/// information for the module.
			/// </summary>
			IncludeModuleCallback,

			/// <summary>
			/// The callback function returns a region of memory to be included in the dump. The callback is called only for dumps generated
			/// without the MiniDumpWithFullMemory flag. If the callback function returns FALSE or a region of size 0, the callback will not
			/// be called again. DbgHelp 6.1 and earlier: This value is not supported.
			/// </summary>
			MemoryCallback,

			/// <summary>The callback function returns cancellation information. DbgHelp 6.1 and earlier: This value is not supported.</summary>
			CancelCallback,

			/// <summary>
			/// The user-mode minidump has been successfully completed. To initiate a kernel-mode minidump, the callback should return TRUE
			/// and set the Handle member of the MINIDUMP_CALLBACK_OUTPUT structure. DbgHelp 6.1 and earlier: This value is not supported.
			/// </summary>
			WriteKernelMinidumpCallback,

			/// <summary>
			/// The callback function returns status information for the kernel minidump. DbgHelp 6.1 and earlier: This value is not supported.
			/// </summary>
			KernelMinidumpStatusCallback,

			/// <summary>
			/// The callback function returns a region of memory to be excluded from the dump. The callback is called only for dumps
			/// generated without the MiniDumpWithFullMemory flag. If the callback function returns FALSE or a region of size 0, the
			/// callback will not be called again. DbgHelp 6.3 and earlier: This value is not supported.
			/// </summary>
			RemoveMemoryCallback,

			/// <summary>
			/// The callback function returns information about the virtual memory region. It is called twice for each region during the
			/// full-memory writing pass. The VmRegion member of the MINIDUMP_CALLBACK_OUTPUT structure contains the current memory region.
			/// You can modify the base address and size of the region, as long as the new region remains a subset of the original region;
			/// changes to other members are ignored. If the callback returns TRUE and sets the Continue member of MINIDUMP_CALLBACK_OUTPUT
			/// to TRUE, the minidump library will use the region specified by VmRegion as the region to be written. If the callback returns
			/// FALSE or if Continue is FALSE, the callback will not be called for additional memory regions. DbgHelp 6.4 and earlier: This
			/// value is not supported.
			/// </summary>
			IncludeVmRegionCallback,

			/// <summary>
			/// The callback function indicates that the caller will be providing an alternate I/O routine. If the callback returns TRUE and
			/// sets the Status member of MINIDUMP_CALLBACK_OUTPUT to S_FALSE, the minidump library will send all I/O through callbacks. The
			/// caller will receive an IoWriteAllCallback callback for each piece of data. DbgHelp 6.4 and earlier: This value is not supported.
			/// </summary>
			IoStartCallback,

			/// <summary>
			/// The callback must write all requested bytes or fail. The Io member of the MINIDUMP_CALLBACK_INPUT structure contains the
			/// request. If the write operation fails, the callback should return FALSE. If the write operation succeeds, the callback
			/// should return TRUE and set the Status member of MINIDUMP_CALLBACK_OUTPUT to S_OK. The caller will receive an
			/// IoFinishCallback callback when the I/O has completed. DbgHelp 6.4 and earlier: This value is not supported.
			/// </summary>
			IoWriteAllCallback,

			/// <summary>
			/// The callback returns I/O completion information. If the callback returns FALSE or does not set the Status member of
			/// MINIDUMP_CALLBACK_OUTPUT to S_OK, the minidump library assumes the minidump write operation has failed. DbgHelp 6.4 and
			/// earlier: This value is not supported.
			/// </summary>
			IoFinishCallback,

			/// <summary>
			/// There has been a failure to read memory. If the callback returns TRUE and sets the Status member of MINIDUMP_CALLBACK_OUTPUT
			/// to S_OK, the memory failure is ignored and the block is omitted from the minidump. Otherwise, this failure results in a
			/// failure to write to the minidump. DbgHelp 6.4 and earlier: This value is not supported.
			/// </summary>
			ReadMemoryFailureCallback,

			/// <summary>The callback returns secondary information. DbgHelp 6.5 and earlier: This value is not supported.</summary>
			SecondaryFlagsCallback,

			/// <summary>
			/// The callback function indicates whether the target is a process or a snapshot.DbgHelp 6.2 and earlier: This value is not supported.
			/// </summary>
			IsProcessSnapshotCallback,

			/// <summary>
			/// The callback function indicates whether the callee supports and accepts virtual memory callbacks, such as VmQueryCallback,
			/// VmPreReadCallback, and VmPostReadCallback. A return value of S_FALSE means that virtual memory callbacks are supported. A
			/// value of S_OK means that virtual memory callbacks are not supported.DbgHelp 6.2 and earlier: This value is not supported.
			/// </summary>
			VmStartCallback,

			/// <summary>
			/// The callback function is invoked for snapshot targets to collect virtual address memory information from the target.The
			/// callback is only called if VmStartCallback returned a value of S_FALSE.DbgHelp 6.2 and earlier: This value is not supported.
			/// </summary>
			VmQueryCallback,

			/// <summary>
			/// The callback function is sent for every ReadVirtual operation. These reads are not limited to the memory blocks that are
			/// added to the dump. The engine also accesses the Process Environment Block (PEB), the Thread Environment Block (TEB), the
			/// loader data, the unloaded module traces, and other blocks. Even if those blocks do not end up in the dump, they are read
			/// from the target, and virtual memory callbacks are initiated for each. The callback is only called if VmStartCallback
			/// returned S_FALSE.DbgHelp 6.2 and earlier: This value is not supported.
			/// </summary>
			VmPreReadCallback,

			/// <summary>
			/// The callback function allows the callee to alter the buffer contents with data from other sources, such as a cache, or
			/// perform obfuscation. The buffer at this point is fully or partially filled by VmPreReadCallback and by ReadProcessMemory.
			/// The callback is only called if VmStartCallback returned S_FALSE.DbgHelp 6.2 and earlier: This value is not supported.
			/// </summary>
			VmPostReadCallback,
		}

		/// <summary>Identifies the type of object-specific information.</summary>
		/// <remarks>
		/// The information represented by each of these values can vary by operating system and procesor architecture. Per-handle
		/// object-specific information is automatically gathered when minidump type is MiniDumpWithHandleData. For more information, see MINIDUMP_TYPE.
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows/win32/api/minidumpapiset/ne-minidumpapiset-minidump_handle_object_information_type
		// typedef enum _MINIDUMP_HANDLE_OBJECT_INFORMATION_TYPE { MiniHandleObjectInformationNone, MiniThreadInformation1,
		// MiniMutantInformation1, MiniMutantInformation2, MiniProcessInformation1, MiniProcessInformation2, MiniEventInformation1,
		// MiniSectionInformation1, MiniSemaphoreInformation1, MiniHandleObjectInformationTypeMax } MINIDUMP_HANDLE_OBJECT_INFORMATION_TYPE;
		[PInvokeData("minidumpapiset.h", MSDNShortId = "NE:minidumpapiset._MINIDUMP_HANDLE_OBJECT_INFORMATION_TYPE")]
		public enum MINIDUMP_HANDLE_OBJECT_INFORMATION_TYPE
		{
			/// <summary>There is no object-specific information for this handle type.</summary>
			MiniHandleObjectInformationNone,

			/// <summary>The information is specific to thread objects.</summary>
			MiniThreadInformation1,

			/// <summary>The information is specific to mutant objects.</summary>
			MiniMutantInformation1,

			/// <summary>The information is specific to mutant objects.</summary>
			MiniMutantInformation2,

			/// <summary>The information is specific to process objects.</summary>
			MiniProcessInformation1,

			/// <summary>The information is specific to process objects.</summary>
			MiniProcessInformation2,

			/// <summary/>
			MiniEventInformation1,

			/// <summary/>
			MiniSectionInformation1,

			/// <summary/>
			MiniSemaphoreInformation1,

			/// <summary/>
			MiniHandleObjectInformationTypeMax,
		}

		/// <summary>Specifies the secondary flags for the minidump.</summary>
		// https://docs.microsoft.com/en-us/windows/win32/api/minidumpapiset/ne-minidumpapiset-minidump_secondary_flags typedef enum
		// _MINIDUMP_SECONDARY_FLAGS { MiniSecondaryWithoutPowerInfo, MiniSecondaryValidFlags } MINIDUMP_SECONDARY_FLAGS;
		[PInvokeData("minidumpapiset.h", MSDNShortId = "NE:minidumpapiset._MINIDUMP_SECONDARY_FLAGS")]
		[Flags]
		public enum MINIDUMP_SECONDARY_FLAGS
		{
			/// <summary>
			/// The minidump information does not retrieve the processor power information contained in the MINIDUMP_MISC_INFO_2 structure.
			/// </summary>
			MiniSecondaryWithoutPowerInfo = 1,

			/// <summary/>
			MiniSecondaryValidFlags = 1,
		}

		/// <summary>Represents the type of a minidump data stream.</summary>
		/// <remarks>
		/// <para>In this context, a data stream is a set of data in a minidump file.</para>
		/// <para>
		/// The <c>StreamType</c> member of the MINIDUMP_DIRECTORY structure can be one of these types. Additional types may be added in the
		/// future, so if a program reading the minidump header encounters a stream type it does not recognize, it should ignore the stream altogether.
		/// </para>
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows/win32/api/minidumpapiset/ne-minidumpapiset-minidump_stream_type typedef enum
		// _MINIDUMP_STREAM_TYPE { UnusedStream, ReservedStream0, ReservedStream1, ThreadListStream, ModuleListStream, MemoryListStream,
		// ExceptionStream, SystemInfoStream, ThreadExListStream, Memory64ListStream, CommentStreamA, CommentStreamW, HandleDataStream,
		// FunctionTableStream, UnloadedModuleListStream, MiscInfoStream, MemoryInfoListStream, ThreadInfoListStream,
		// HandleOperationListStream, TokenStream, JavaScriptDataStream, SystemMemoryInfoStream, ProcessVmCountersStream, IptTraceStream,
		// ThreadNamesStream, ceStreamNull, ceStreamSystemInfo, ceStreamException, ceStreamModuleList, ceStreamProcessList,
		// ceStreamThreadList, ceStreamThreadContextList, ceStreamThreadCallStackList, ceStreamMemoryVirtualList,
		// ceStreamMemoryPhysicalList, ceStreamBucketParameters, ceStreamProcessModuleMap, ceStreamDiagnosisList, LastReservedStream } MINIDUMP_STREAM_TYPE;
		[PInvokeData("minidumpapiset.h", MSDNShortId = "NE:minidumpapiset._MINIDUMP_STREAM_TYPE")]
		public enum MINIDUMP_STREAM_TYPE
		{
			/// <summary>Reserved. Do not use this enumeration value.</summary>
			UnusedStream,

			/// <summary>Reserved. Do not use this enumeration value.</summary>
			ReservedStream0,

			/// <summary>Reserved. Do not use this enumeration value.</summary>
			ReservedStream1,

			/// <summary>The stream contains thread information. For more information, see MINIDUMP_THREAD_LIST.</summary>
			ThreadListStream,

			/// <summary>The stream contains module information. For more information, see MINIDUMP_MODULE_LIST.</summary>
			ModuleListStream,

			/// <summary>The stream contains memory allocation information. For more information, see MINIDUMP_MEMORY_LIST.</summary>
			MemoryListStream,

			/// <summary>The stream contains exception information. For more information, see MINIDUMP_EXCEPTION_STREAM.</summary>
			ExceptionStream,

			/// <summary>The stream contains general system information. For more information, see MINIDUMP_SYSTEM_INFO.</summary>
			SystemInfoStream,

			/// <summary>The stream contains extended thread information. For more information, see MINIDUMP_THREAD_EX_LIST.</summary>
			ThreadExListStream,

			/// <summary>The stream contains memory allocation information. For more information, see MINIDUMP_MEMORY64_LIST.</summary>
			Memory64ListStream,

			/// <summary>The stream contains an ANSI string used for documentation purposes.</summary>
			CommentStreamA,

			/// <summary>The stream contains a Unicode string used for documentation purposes.</summary>
			CommentStreamW,

			/// <summary>
			/// The stream contains high-level information about the active operating system handles. For more information, see MINIDUMP_HANDLE_DATA_STREAM.
			/// </summary>
			HandleDataStream,

			/// <summary>The stream contains function table information. For more information, see MINIDUMP_FUNCTION_TABLE_STREAM.</summary>
			FunctionTableStream,

			/// <summary>
			/// The stream contains module information for the unloaded modules. For more information, see
			/// MINIDUMP_UNLOADED_MODULE_LIST.DbgHelp 5.1: This value is not supported.
			/// </summary>
			UnloadedModuleListStream,

			/// <summary>
			/// The stream contains miscellaneous information. For more information, see MINIDUMP_MISC_INFO or MINIDUMP_MISC_INFO_2.DbgHelp
			/// 5.1: This value is not supported.
			/// </summary>
			MiscInfoStream,

			/// <summary>
			/// The stream contains memory region description information. It corresponds to the information that would be returned for the
			/// process from the VirtualQuery function. For more information, see MINIDUMP_MEMORY_INFO_LIST.DbgHelp 6.1 and earlier: This
			/// value is not supported.
			/// </summary>
			MemoryInfoListStream,

			/// <summary>
			/// The stream contains thread state information. For more information, see MINIDUMP_THREAD_INFO_LIST.DbgHelp 6.1 and earlier:
			/// This value is not supported.
			/// </summary>
			ThreadInfoListStream,

			/// <summary>
			/// This stream contains operation list information. For more information, see MINIDUMP_HANDLE_OPERATION_LIST.DbgHelp 6.4 and
			/// earlier: This value is not supported.
			/// </summary>
			HandleOperationListStream,

			/// <summary/>
			TokenStream,

			/// <summary/>
			JavaScriptDataStream,

			/// <summary/>
			SystemMemoryInfoStream,

			/// <summary/>
			ProcessVmCountersStream,

			/// <summary/>
			IptTraceStream,

			/// <summary/>
			ThreadNamesStream,

			/// <summary/>
			ceStreamNull = 0x8000,

			/// <summary/>
			ceStreamSystemInfo,

			/// <summary/>
			ceStreamException,

			/// <summary/>
			ceStreamModuleList,

			/// <summary/>
			ceStreamProcessList,

			/// <summary/>
			ceStreamThreadList,

			/// <summary/>
			ceStreamThreadContextList,

			/// <summary/>
			ceStreamThreadCallStackList,

			/// <summary/>
			ceStreamMemoryVirtualList,

			/// <summary/>
			ceStreamMemoryPhysicalList,

			/// <summary/>
			ceStreamBucketParameters,

			/// <summary/>
			ceStreamProcessModuleMap,

			/// <summary/>
			ceStreamDiagnosisList,

			/// <summary>
			/// Any value greater than this value will not be used by the system and can be used to represent application-defined data
			/// streams. For more information, see MINIDUMP_USER_STREAM.
			/// </summary>
			LastReservedStream = 0xffff,
		}

		/// <summary>
		/// <para>Identifies the type of information that will be written to the minidump file by the MiniDumpWriteDump function.</para>
		/// <para><c>Important</c></para>
		/// </summary>
		// https://docs.microsoft.com/en-us/windows/win32/api/minidumpapiset/ne-minidumpapiset-minidump_type typedef enum _MINIDUMP_TYPE {
		// MiniDumpNormal, MiniDumpWithDataSegs, MiniDumpWithFullMemory, MiniDumpWithHandleData, MiniDumpFilterMemory, MiniDumpScanMemory,
		// MiniDumpWithUnloadedModules, MiniDumpWithIndirectlyReferencedMemory, MiniDumpFilterModulePaths, MiniDumpWithProcessThreadData,
		// MiniDumpWithPrivateReadWriteMemory, MiniDumpWithoutOptionalData, MiniDumpWithFullMemoryInfo, MiniDumpWithThreadInfo,
		// MiniDumpWithCodeSegs, MiniDumpWithoutAuxiliaryState, MiniDumpWithFullAuxiliaryState, MiniDumpWithPrivateWriteCopyMemory,
		// MiniDumpIgnoreInaccessibleMemory, MiniDumpWithTokenInformation, MiniDumpWithModuleHeaders, MiniDumpFilterTriage,
		// MiniDumpWithAvxXStateContext, MiniDumpWithIptTrace, MiniDumpScanInaccessiblePartialPages, MiniDumpValidTypeFlags } MINIDUMP_TYPE;
		[PInvokeData("minidumpapiset.h", MSDNShortId = "NE:minidumpapiset._MINIDUMP_TYPE")]
		[Flags]
		public enum MINIDUMP_TYPE
		{
			/// <summary>Include just the information necessary to capture stack traces for all existing threads in a process.</summary>
			MiniDumpNormal = 0x00000000,

			/// <summary>
			/// Include the data sections from all loaded modules. This results in the inclusion of global variables, which can make the
			/// minidump file significantly larger. For per-module control, use the ModuleWriteDataSeg enumeration value from MODULE_WRITE_FLAGS.
			/// </summary>
			MiniDumpWithDataSegs = 0x00000001,

			/// <summary>
			/// Include all accessible memory in the process. The raw memory data is included at the end, so that the initial structures can
			/// be mapped directly without the raw memory information. This option can result in a very large file.
			/// </summary>
			MiniDumpWithFullMemory = 0x00000002,

			/// <summary>Include high-level information about the operating system handles that are active when the minidump is made.</summary>
			MiniDumpWithHandleData = 0x00000004,

			/// <summary>
			/// Stack and backing store memory written to the minidump file should be filtered to remove all but the pointer values
			/// necessary to reconstruct a stack trace.
			/// </summary>
			MiniDumpFilterMemory = 0x00000008,

			/// <summary>
			/// Stack and backing store memory should be scanned for pointer references to modules in the module list. If a module is
			/// referenced by stack or backing store memory, the ModuleWriteFlags member of the MINIDUMP_CALLBACK_OUTPUT structure is set to ModuleReferencedByMemory.
			/// </summary>
			MiniDumpScanMemory = 0x00000010,

			/// <summary>
			/// Include information from the list of modules that were recently unloaded, if this information is maintained by the operating
			/// system. Windows Server 2003 and Windows XP: The operating system does not maintain information for unloaded modules until
			/// Windows Server 2003 with SP1 and Windows XP with SP2.DbgHelp 5.1: This value is not supported.
			/// </summary>
			MiniDumpWithUnloadedModules = 0x00000020,

			/// <summary>
			/// Include pages with data referenced by locals or other stack memory. This option can increase the size of the minidump file
			/// significantly. DbgHelp 5.1: This value is not supported.
			/// </summary>
			MiniDumpWithIndirectlyReferencedMemory = 0x00000040,

			/// <summary>
			/// Filter module paths for information such as user names or important directories. This option may prevent the system from
			/// locating the image file and should be used only in special situations. DbgHelp 5.1: This value is not supported.
			/// </summary>
			MiniDumpFilterModulePaths = 0x00000080,

			/// <summary>
			/// Include complete per-process and per-thread information from the operating system. DbgHelp 5.1: This value is not supported.
			/// </summary>
			MiniDumpWithProcessThreadData = 0x00000100,

			/// <summary>Scan the virtual address space for PAGE_READWRITE memory to be included. DbgHelp 5.1: This value is not supported.</summary>
			MiniDumpWithPrivateReadWriteMemory = 0x00000200,

			/// <summary>
			/// Reduce the data that is dumped by eliminating memory regions that are not essential to meet criteria specified for the dump.
			/// This can avoid dumping memory that may contain data that is private to the user. However, it is not a guarantee that no
			/// private information will be present. DbgHelp 6.1 and earlier: This value is not supported.
			/// </summary>
			MiniDumpWithoutOptionalData = 0x00000400,

			/// <summary>
			/// Include memory region information. For more information, see MINIDUMP_MEMORY_INFO_LIST. DbgHelp 6.1 and earlier: This value
			/// is not supported.
			/// </summary>
			MiniDumpWithFullMemoryInfo = 0x00000800,

			/// <summary>
			/// Include thread state information. For more information, see MINIDUMP_THREAD_INFO_LIST. DbgHelp 6.1 and earlier: This value
			/// is not supported.
			/// </summary>
			MiniDumpWithThreadInfo = 0x00001000,

			/// <summary>
			/// Include all code and code-related sections from loaded modules to capture executable content. For per-module control, use
			/// the ModuleWriteCodeSegs enumeration value from MODULE_WRITE_FLAGS. DbgHelp 6.1 and earlier: This value is not supported.
			/// </summary>
			MiniDumpWithCodeSegs = 0x00002000,

			/// <summary>Turns off secondary auxiliary-supported memory gathering.</summary>
			MiniDumpWithoutAuxiliaryState = 0x00004000,

			/// <summary>
			/// Requests that auxiliary data providers include their state in the dump image; the state data that is included is provider
			/// dependent. This option can result in a large dump image.
			/// </summary>
			MiniDumpWithFullAuxiliaryState = 0x00008000,

			/// <summary>
			/// Scans the virtual address space for PAGE_WRITECOPY memory to be included. Prior to DbgHelp 6.1: This value is not supported.
			/// </summary>
			MiniDumpWithPrivateWriteCopyMemory = 0x00010000,

			/// <summary>
			/// If you specify MiniDumpWithFullMemory, the MiniDumpWriteDump function will fail if the function cannot read the memory
			/// regions; however, if you include MiniDumpIgnoreInaccessibleMemory, the MiniDumpWriteDump function will ignore the memory
			/// read failures and continue to generate the dump. Note that the inaccessible memory regions are not included in the
			/// dump.Prior to DbgHelp 6.1: This value is not supported.
			/// </summary>
			MiniDumpIgnoreInaccessibleMemory = 0x00020000,

			/// <summary>
			/// Adds security token related data. This will make the "!token" extension work when processing a user-mode dump. Prior to
			/// DbgHelp 6.1: This value is not supported.
			/// </summary>
			MiniDumpWithTokenInformation = 0x00040000,

			/// <summary>Adds module header related data. Prior to DbgHelp 6.1: This value is not supported.</summary>
			MiniDumpWithModuleHeaders = 0x00080000,

			/// <summary>Adds filter triage related data. Prior to DbgHelp 6.1: This value is not supported.</summary>
			MiniDumpFilterTriage = 0x00100000,

			/// <summary/>
			MiniDumpWithAvxXStateContext = 0x00200000,

			/// <summary/>
			MiniDumpWithIptTrace = 0x00400000,

			/// <summary>Indicates which flags are valid.</summary>
			MiniDumpValidTypeFlags = 0x00800000,
		}

		/// <summary>Identifies the type of module information that will be written to the minidump file by the MiniDumpWriteDump function.</summary>
		// https://docs.microsoft.com/en-us/windows/win32/api/minidumpapiset/ne-minidumpapiset-module_write_flags typedef enum
		// _MODULE_WRITE_FLAGS { ModuleWriteModule, ModuleWriteDataSeg, ModuleWriteMiscRecord, ModuleWriteCvRecord,
		// ModuleReferencedByMemory, ModuleWriteTlsData, ModuleWriteCodeSegs } MODULE_WRITE_FLAGS;
		[PInvokeData("minidumpapiset.h", MSDNShortId = "NE:minidumpapiset._MODULE_WRITE_FLAGS")]
		[Flags]
		public enum MODULE_WRITE_FLAGS
		{
			/// <summary>Only module information will be written to the minidump file.</summary>
			ModuleWriteModule = 0x0001,

			/// <summary>
			/// Module and data segment information will be written to the minidump file. This value will only be set if the
			/// MiniDumpWithDataSegs enumeration value from MINIDUMP_TYPE is set.
			/// </summary>
			ModuleWriteDataSeg = 0x0002,

			/// <summary>Module, data segment, and miscellaneous record information will be written to the minidump file.</summary>
			ModuleWriteMiscRecord = 0x0004,

			/// <summary>
			/// CodeView information will be written to the minidump file. Some debuggers need the CodeView information to properly locate symbols.
			/// </summary>
			ModuleWriteCvRecord = 0x0008,

			/// <summary>
			/// Indicates that a module was referenced by a pointer on the stack or backing store of a thread in the minidump. This value is
			/// valid only if the DumpType parameter of the MiniDumpWriteDump function includes MiniDumpScanMemory.
			/// </summary>
			ModuleReferencedByMemory = 0x0010,

			/// <summary>
			/// Per-module automatic TLS data is written to the minidump file. (Note that automatic TLS data is created using
			/// __declspec(thread) while TlsAlloc creates dynamic TLS data). This value is valid only if the DumpType parameter of the
			/// MiniDumpWriteDump function includes MiniDumpWithProcessThreadData.DbgHelp 6.1 and earlier: This value is not supported.
			/// </summary>
			ModuleWriteTlsData = 0x0020,

			/// <summary>
			/// Code segment information will be written to the minidump file. This value will only be set if the MiniDumpWithCodeSegs
			/// enumeration value from MINIDUMP_TYPE is set.DbgHelp 6.1 and earlier: This value is not supported.
			/// </summary>
			ModuleWriteCodeSegs = 0x0040,
		}

		/// <summary>Identifies the type of thread information that will be written to the minidump file by the MiniDumpWriteDump function.</summary>
		// https://docs.microsoft.com/en-us/windows/win32/api/minidumpapiset/ne-minidumpapiset-thread_write_flags typedef enum
		// _THREAD_WRITE_FLAGS { ThreadWriteThread, ThreadWriteStack, ThreadWriteContext, ThreadWriteBackingStore,
		// ThreadWriteInstructionWindow, ThreadWriteThreadData, ThreadWriteThreadInfo } THREAD_WRITE_FLAGS;
		[PInvokeData("minidumpapiset.h", MSDNShortId = "NE:minidumpapiset._THREAD_WRITE_FLAGS")]
		public enum THREAD_WRITE_FLAGS
		{
			/// <summary>Only basic thread information will be written to the minidump file.</summary>
			ThreadWriteThread,

			/// <summary>Basic thread and thread stack information will be written to the minidump file.</summary>
			ThreadWriteStack,

			/// <summary>The entire thread context will be written to the minidump file.</summary>
			ThreadWriteContext,

			/// <summary>Intel Itanium: The backing store memory of every thread will be written to the minidump file.</summary>
			ThreadWriteBackingStore,

			/// <summary>
			/// A small amount of memory surrounding each thread's instruction pointer will be written to the minidump file. This allows
			/// instructions near a thread's instruction pointer to be disassembled even if an executable image matching the module cannot
			/// be found.
			/// </summary>
			ThreadWriteInstructionWindow,

			/// <summary>
			/// When the minidump type includes MiniDumpWithProcessThreadData, this flag is set. The callback function can clear this flag
			/// to control which threads provide complete thread data in the minidump file.DbgHelp 5.1: This value is not supported.
			/// </summary>
			ThreadWriteThreadData,

			/// <summary>
			/// When the minidump type includes MiniDumpWithThreadInfo, this flag is set. The callback function can clear this flag to
			/// control which threads provide thread state information in the minidump file. For more information, see
			/// MINIDUMP_THREAD_INFO.DbgHelp 6.1 and earlier: This value is not supported.
			/// </summary>
			ThreadWriteThreadInfo,
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
			[MarshalAs(UnmanagedType.LPTStr)] StringBuilder OutputPathBuffer, [Optional] PENUMDIRTREE_CALLBACK cb, [In, Optional] IntPtr data);

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
		[DllImport(Lib_DbgHelp, SetLastError = true, CharSet = CharSet.Auto)]
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
		/// <para>
		/// All DbgHelp functions, such as this one, are single threaded. Therefore, calls from more than one thread to this function will
		/// likely result in unexpected behavior or memory corruption. To avoid this, you must synchronize all concurrent calls from more
		/// than one thread to this function.
		/// </para>
		/// <para>To call the Unicode version of this function, define DBGHELP_TRANSLATE_TCHAR.</para>
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows/win32/api/dbghelp/nf-dbghelp-enumerateloadedmodulesexw BOOL IMAGEAPI
		// EnumerateLoadedModulesExW( HANDLE hProcess, PENUMLOADED_MODULES_CALLBACKW64 EnumLoadedModulesCallback, PVOID UserContext );
		[DllImport(Lib_DbgHelp, SetLastError = true, CharSet = CharSet.Auto)]
		[PInvokeData("dbghelp.h", MSDNShortId = "NF:dbghelp.EnumerateLoadedModulesExW")]
		[return: MarshalAs(UnmanagedType.Bool)]
		public static extern bool EnumerateLoadedModulesEx(HPROCESS hProcess, PENUMLOADED_MODULES_CALLBACK EnumLoadedModulesCallback, [In, Optional] IntPtr UserContext);

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
		public static extern SafeHFILE FindDebugInfoFile([MarshalAs(UnmanagedType.LPStr)] string FileName, [MarshalAs(UnmanagedType.LPStr)] string SymbolPath, [Out, MarshalAs(UnmanagedType.LPStr)] StringBuilder DebugFilePath);

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

		/// <summary>
		/// <para>An application-defined callback function used with the StackWalk64 function. It is called when <c>StackWalk64</c> needs a module base address for a given virtual address.</para>
		/// <para>The <c>PGET_MODULE_BASE_ROUTINE64</c> type defines a pointer to this callback function. <c>GetModuleBaseProc64</c> is a placeholder for the application-defined function name.</para>
		/// </summary>
		/// <param name="hProcess">A handle to the process for which the stack trace is generated.</param>
		/// <param name="Address">An address within the module image to be located.</param>
		/// <returns>The function returns the base address of the module.</returns>
		/// <remarks>
		/// <para>This callback function supersedes the PGET_MODULE_BASE_ROUTINE callback function. PGET_MODULE_BASE_ROUTINE is defined as follows in DbgHelp.h.</para>
		/// <para><code>#if !defined(_IMAGEHLP_SOURCE_) &amp;&amp; defined(_IMAGEHLP64) #define PGET_MODULE_BASE_ROUTINE PGET_MODULE_BASE_ROUTINE64 #else typedef DWORD (__stdcall *PGET_MODULE_BASE_ROUTINE)( __in HANDLE hProcess, __in DWORD Address ); #endif </code></para>
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows/win32/api/dbghelp/nc-dbghelp-pget_module_base_routine64
		// PGET_MODULE_BASE_ROUTINE64 PgetModuleBaseRoutine64; DWORD64 PgetModuleBaseRoutine64( HANDLE hProcess, DWORD64 Address ) {...}
		[UnmanagedFunctionPointer(CallingConvention.Winapi)]
		[PInvokeData("dbghelp.h", MSDNShortId = "NC:dbghelp.PGET_MODULE_BASE_ROUTINE64")]
		public delegate ulong PGET_MODULE_BASE_ROUTINE64(HPROCESS hProcess, ulong Address);

		/// <summary>
		/// <para>An application-defined callback function used with the StackWalk64 function. It is called when <c>StackWalk64</c> needs a module base address for a given virtual address.</para>
		/// <para>The <c>PGET_MODULE_BASE_ROUTINE64</c> type defines a pointer to this callback function. <c>GetModuleBaseProc64</c> is a placeholder for the application-defined function name.</para>
		/// </summary>
		/// <param name="hProcess">A handle to the process for which the stack trace is generated.</param>
		/// <param name="Address">An address within the module image to be located.</param>
		/// <returns>The function returns the base address of the module.</returns>
		/// <remarks>
		/// <para>This callback function supersedes the PGET_MODULE_BASE_ROUTINE callback function. PGET_MODULE_BASE_ROUTINE is defined as follows in DbgHelp.h.</para>
		/// <para><code>#if !defined(_IMAGEHLP_SOURCE_) &amp;&amp; defined(_IMAGEHLP64) #define PGET_MODULE_BASE_ROUTINE PGET_MODULE_BASE_ROUTINE64 #else typedef DWORD (__stdcall *PGET_MODULE_BASE_ROUTINE)( __in HANDLE hProcess, __in DWORD Address ); #endif </code></para>
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows/win32/api/dbghelp/nc-dbghelp-pget_module_base_routine
		// PGET_MODULE_BASE_ROUTINE PgetModuleBaseRoutine; DWORD PgetModuleBaseRoutine( HANDLE hProcess, DWORD Address ) {...}
		[UnmanagedFunctionPointer(CallingConvention.Winapi)]
		[PInvokeData("dbghelp.h", MSDNShortId = "NC:dbghelp.PGET_MODULE_BASE_ROUTINE")]
		public delegate uint PGET_MODULE_BASE_ROUTINE(HPROCESS hProcess, uint Address);

		/// <summary>Gets the last symbol load error.</summary>
		/// <returns>The last symbol load error.</returns>
		// https://docs.microsoft.com/en-us/windows/win32/api/dbghelp/nf-dbghelp-getsymloaderror
		// DWORD IMAGEAPI GetSymLoadError();
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
		/// <para>The time stamp for an image is initially set by the linker, but it can be modified by operations such as rebasing. The value is represented in the number of seconds elapsed since midnight (00:00:00), January 1, 1970, Universal Coordinated Time, according to the system clock. The time stamp can be printed using the C run-time (CRT) function ctime.</para>
		/// <para>All DbgHelp Functions, such as this one, are single threaded. Therefore, calls from more than one thread to this function will likely result in unexpected behavior or memory corruption. To avoid this, you must synchronize all concurrent calls from more than one thread to this function.</para>
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows/win32/api/dbghelp/nf-dbghelp-gettimestampforloadedlibrary
		// DWORD IMAGEAPI GetTimestampForLoadedLibrary( HMODULE Module );
		[DllImport(Lib_DbgHelp, SetLastError = true, ExactSpelling = true)]
		[PInvokeData("dbghelp.h", MSDNShortId = "NF:dbghelp.GetTimestampForLoadedLibrary")]
		public static extern uint GetTimestampForLoadedLibrary(HINSTANCE Module);

		/// <summary>Locates a directory entry within the image header and returns the address of the data for the directory entry. This function returns the section header for the data located, if one exists.</summary>
		/// <param name="Base">The base address of the image or data file.</param>
		/// <param name="MappedAsImage">If the flag is <c>TRUE</c>, the file is mapped by the system as an image. If this flag is <c>FALSE</c>, the file is mapped as a data file by the MapViewOfFile function.</param>
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
		/// <param name="FoundHeader">A pointer to an IMAGE_SECTION_HEADER structure that receives the data. If the section header does not exist, this parameter is <c>NULL</c>.</param>
		/// <returns>
		/// <para>If the function succeeds, the return value is a pointer to the data for the directory entry.</para>
		/// <para>If the function fails, the return value is <c>NULL</c>. To retrieve extended error information, call GetLastError.</para>
		/// <para>All DbgHelp functions, such as this one, are single threaded. Therefore, calls from more than one thread to this function will likely result in unexpected behavior or memory corruption. To avoid this, you must synchronize all concurrent calls from more than one thread to this function.</para>
		/// </returns>
		// https://docs.microsoft.com/en-us/windows/win32/api/dbghelp/nf-dbghelp-imagedirectoryentrytodataex
		// PVOID IMAGEAPI ImageDirectoryEntryToDataEx( PVOID Base, BOOLEAN MappedAsImage, USHORT DirectoryEntry, PULONG Size, PIMAGE_SECTION_HEADER *FoundHeader );
		[DllImport(Lib_DbgHelp, SetLastError = true, ExactSpelling = true)]
		[PInvokeData("dbghelp.h", MSDNShortId = "NF:dbghelp.ImageDirectoryEntryToDataEx")]
		public static extern IntPtr ImageDirectoryEntryToDataEx(IntPtr Base, [MarshalAs(UnmanagedType.U1)] bool MappedAsImage, IMAGE_DIRECTORY_ENTRY DirectoryEntry, out uint Size, out IntPtr FoundHeader);

		/// <summary>
		/// <para>Retrieves the version information of the DbgHelp library installed on the system.</para>
		/// <para>To indicate the version of the library with which the application was built, use the ImagehlpApiVersionEx function.</para>
		/// </summary>
		/// <returns>The return value is a pointer to an API_VERSION structure.</returns>
		/// <remarks>
		/// <para>Use the information in the API_VERSION structure to determine whether the version of the library installed on the system is compatible with the version of the library used by the application. Although the library functions are backward compatible, functions introduced in one version are obviously not available in earlier versions.</para>
		/// <para>All DbgHelp functions, such as this one, are single threaded. Therefore, calls from more than one thread to this function will likely result in unexpected behavior or memory corruption. To avoid this, you must synchronize all concurrent calls from more than one thread to this function.</para>
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows/win32/api/dbghelp/nf-dbghelp-imagehlpapiversion
		// LPAPI_VERSION IMAGEAPI ImagehlpApiVersion();
		[DllImport(Lib_DbgHelp, SetLastError = false, ExactSpelling = true)]
		[PInvokeData("dbghelp.h", MSDNShortId = "NF:dbghelp.ImagehlpApiVersion")]
		public static extern IntPtr ImagehlpApiVersion();

		/// <summary>Modifies the version information of the library used by the application.</summary>
		/// <param name="AppVersion">A pointer to an API_VERSION structure that contains valid version information for your application.</param>
		/// <returns>The return value is a pointer to an API_VERSION structure.</returns>
		/// <remarks>
		/// <para>Use the <c>ImagehlpApiVersionEx</c> function to indicate the version of the library with which the application was built. The library uses this information to ensure compatibility. For example, consider walking through kernel-mode callback stack frames (User and GDI exist in kernel mode). If you call <c>ImagehlpApiVersionEx</c> to set the <c>Revision</c> member to version 4 or later, the StackWalk64 function will continue through a callback stack frame. Otherwise, if you set <c>Revision</c> to a version earlier than 4, <c>StackWalk64</c> will stop at the kernel transition.</para>
		/// <para>All DbgHelp functions, such as this one, are single threaded. Therefore, calls from more than one thread to this function will likely result in unexpected behavior or memory corruption. To avoid this, you must synchronize all concurrent calls from more than one thread to this function.</para>
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows/win32/api/dbghelp/nf-dbghelp-imagehlpapiversionex
		// LPAPI_VERSION IMAGEAPI ImagehlpApiVersionEx( LPAPI_VERSION AppVersion );
		[DllImport(Lib_DbgHelp, SetLastError = false, ExactSpelling = true)]
		[PInvokeData("dbghelp.h", MSDNShortId = "NF:dbghelp.ImagehlpApiVersionEx")]
		public static extern IntPtr ImagehlpApiVersionEx(in API_VERSION AppVersion);

		/// <summary>Locates the IMAGE_NT_HEADERS structure in a PE image and returns a pointer to the data.</summary>
		/// <param name="Base">The base address of an image that is mapped into memory by a call to the MapViewOfFile function.</param>
		/// <returns>
		/// <para>If the function succeeds, the return value is a pointer to an IMAGE_NT_HEADERS structure.</para>
		/// <para>If the function fails, the return value is <c>NULL</c>. To retrieve extended error information, call GetLastError.</para>
		/// </returns>
		/// <remarks>All DbgHelp functions, such as this one, are single threaded. Therefore, calls from more than one thread to this function will likely result in unexpected behavior or memory corruption. To avoid this, you must synchronize all concurrent calls from more than one thread to this function.</remarks>
		// https://docs.microsoft.com/en-us/windows/win32/api/dbghelp/nf-dbghelp-imagentheader
		// PIMAGE_NT_HEADERS IMAGEAPI ImageNtHeader( PVOID Base );
		[DllImport(Lib_DbgHelp, SetLastError = true, ExactSpelling = true)]
		[PInvokeData("dbghelp.h", MSDNShortId = "NF:dbghelp.ImageNtHeader")]
		public static extern IntPtr ImageNtHeader(IntPtr Base);

		/// <summary>Locates a relative virtual address (RVA) within the image header of a file that is mapped as a file and returns a pointer to the section table entry for that RVA.</summary>
		/// <param name="NtHeaders">A pointer to an IMAGE_NT_HEADERS structure. This structure can be obtained by calling the ImageNtHeader function.</param>
		/// <param name="Base">This parameter is reserved.</param>
		/// <param name="Rva">The relative virtual address to be located.</param>
		/// <returns>
		/// <para>If the function succeeds, the return value is a pointer to an IMAGE_SECTION_HEADER structure.</para>
		/// <para>If the function fails, the return value is <c>NULL</c>. To retrieve extended error information, call GetLastError.</para>
		/// </returns>
		/// <remarks>All DbgHelp functions, such as this one, are single threaded. Therefore, calls from more than one thread to this function will likely result in unexpected behavior or memory corruption. To avoid this, you must synchronize all concurrent calls from more than one thread to this function.</remarks>
		// https://docs.microsoft.com/en-us/windows/win32/api/dbghelp/nf-dbghelp-imagervatosection
		// PIMAGE_SECTION_HEADER IMAGEAPI ImageRvaToSection( PIMAGE_NT_HEADERS NtHeaders, PVOID Base, ULONG Rva );
		[DllImport(Lib_DbgHelp, SetLastError = true, ExactSpelling = true)]
		[PInvokeData("dbghelp.h", MSDNShortId = "NF:dbghelp.ImageRvaToSection")]
		public static extern IntPtr ImageRvaToSection(in IMAGE_NT_HEADERS NtHeaders, IntPtr Base, uint Rva);

		/// <summary>Locates a relative virtual address (RVA) within the image header of a file that is mapped as a file and returns a pointer to the section table entry for that RVA.</summary>
		/// <param name="NtHeaders">A pointer to an IMAGE_NT_HEADERS structure. This structure can be obtained by calling the ImageNtHeader function.</param>
		/// <param name="Base">This parameter is reserved.</param>
		/// <param name="Rva">The relative virtual address to be located.</param>
		/// <returns>
		/// <para>If the function succeeds, the return value is a pointer to an IMAGE_SECTION_HEADER structure.</para>
		/// <para>If the function fails, the return value is <c>NULL</c>. To retrieve extended error information, call GetLastError.</para>
		/// </returns>
		/// <remarks>All DbgHelp functions, such as this one, are single threaded. Therefore, calls from more than one thread to this function will likely result in unexpected behavior or memory corruption. To avoid this, you must synchronize all concurrent calls from more than one thread to this function.</remarks>
		// https://docs.microsoft.com/en-us/windows/win32/api/dbghelp/nf-dbghelp-imagervatosection
		// PIMAGE_SECTION_HEADER IMAGEAPI ImageRvaToSection( PIMAGE_NT_HEADERS NtHeaders, PVOID Base, ULONG Rva );
		[DllImport(Lib_DbgHelp, SetLastError = true, ExactSpelling = true)]
		[PInvokeData("dbghelp.h", MSDNShortId = "NF:dbghelp.ImageRvaToSection")]
		public static extern IntPtr ImageRvaToSection([In] IntPtr NtHeaders, IntPtr Base, uint Rva);

		/// <summary>Creates all the directories in the specified path, beginning with the root.</summary>
		/// <param name="DirPath">A valid path name. If the final component of the path is a directory, not a file name, the string must end with a backslash () character.</param>
		/// <returns>
		/// <para>If the function succeeds, the return value is <c>TRUE</c>.</para>
		/// <para>If the function fails, the return value is <c>FALSE</c>. To retrieve extended error information, call GetLastError.</para>
		/// </returns>
		/// <remarks>
		/// <para>Each directory specified is created, if it does not already exist. If only some of the directories are created, the function will return <c>FALSE</c>.</para>
		/// <para>This function does not support Unicode strings. To specify a Unicode path, use the SHCreateDirectoryEx function.</para>
		/// <para>All DbgHelp functions, such as this one, are single threaded. Therefore, calls from more than one thread to this function will likely result in unexpected behavior or memory corruption. To avoid this, you must synchronize all concurrent calls from more than one thread to this function.</para>
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows/win32/api/dbghelp/nf-dbghelp-makesuredirectorypathexists
		// BOOL IMAGEAPI MakeSureDirectoryPathExists( PCSTR DirPath );
		[DllImport(Lib_DbgHelp, SetLastError = true, ExactSpelling = true)]
		[PInvokeData("dbghelp.h", MSDNShortId = "NF:dbghelp.MakeSureDirectoryPathExists")]
		[return: MarshalAs(UnmanagedType.Bool)]
		public static extern bool MakeSureDirectoryPathExists([MarshalAs(UnmanagedType.LPStr)] string DirPath);

		/// <summary>
		/// <para>Obtains access to the debugging information for an image.</para>
		/// <para><c>Note</c> This function is provided only for backward compatibility. It does not return reliable information. New applications should use the SymGetModuleInfo64 and SymLoadModule64 functions.</para>
		/// </summary>
		/// <param name="FileHandle">A handle to an open executable image or <c>NULL</c>.</param>
		/// <param name="FileName">The name of an executable image file or <c>NULL</c>.</param>
		/// <param name="SymbolPath">The path where symbol files are located. The path can be multiple paths separated by semicolons. To retrieve the symbol path, use the SymGetSearchPath function.</param>
		/// <param name="ImageBase">The base address for the image or zero.</param>
		/// <returns>
		/// <para>If the function succeeds, the return value is a pointer to an IMAGE_DEBUG_INFORMATION structure.</para>
		/// <para>If the function fails, the return value is <c>NULL</c>. To retrieve extended error information, call GetLastError.</para>
		/// </returns>
		/// <remarks>
		/// <para>The <c>MapDebugInformation</c> function is used to obtain access to an image's debugging information. The debugging information is extracted from the image or the symbol file and placed into the IMAGE_DEBUG_INFORMATION structure. This structure is allocated by the library and must be deallocated by using the UnmapDebugInformation function. The memory for the structure is not in the process's default heap, so attempts to free it with a memory deallocation routine will fail.</para>
		/// <para>All DbgHelp functions, such as this one, are single threaded. Therefore, calls from more than one thread to this function will likely result in unexpected behavior or memory corruption. To avoid this, you must synchronize all concurrent calls from more than one thread to this function.</para>
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows/win32/api/dbghelp/nf-dbghelp-mapdebuginformation
		// PIMAGE_DEBUG_INFORMATION IMAGEAPI MapDebugInformation( HANDLE FileHandle, PCSTR FileName, PCSTR SymbolPath, ULONG ImageBase );
		[DllImport(Lib_DbgHelp, SetLastError = true, ExactSpelling = true)]
		[PInvokeData("dbghelp.h", MSDNShortId = "NF:dbghelp.MapDebugInformation")]
		public static extern IntPtr MapDebugInformation([Optional] HFILE FileHandle, [MarshalAs(UnmanagedType.LPStr)] string FileName, [Optional, MarshalAs(UnmanagedType.LPStr)] string SymbolPath, uint ImageBase);

		/// <summary>
		/// <para>An application-defined callback function used with the StackWalk64 function. It is called when <c>StackWalk64</c> needs to read memory from the address space of the process.</para>
		/// <para>The <c>PREAD_PROCESS_MEMORY_ROUTINE64</c> type defines a pointer to this callback function. <c>ReadProcessMemoryProc64</c> is a placeholder for the application-defined function name.</para>
		/// </summary>
		/// <param name="hProcess">A handle to the process for which the stack trace is generated.</param>
		/// <param name="lpBaseAddress">The base address of the memory to be read.</param>
		/// <param name="lpBuffer">A pointer to a buffer that receives the memory to be read.</param>
		/// <param name="nSize">The size of the memory to be read, in bytes.</param>
		/// <param name="lpNumberOfBytesRead">A pointer to a variable that receives the number of bytes actually read.</param>
		/// <returns>If the function succeeds, the return value should be <c>TRUE</c>. If the function fails, the return value should be <c>FALSE</c>.</returns>
		/// <remarks>
		/// <para>In many cases, this function can best service the callback with a corresponding call to ReadProcessMemory.</para>
		/// <para>This function should read as much of the requested memory as possible. The StackWalk64 function handles the case where only part of the requested memory is read.</para>
		/// <para>This callback function supersedes the PREAD_PROCESS_MEMORY_ROUTINE callback function. PREAD_PROCESS_MEMORY_ROUTINE is defined as follows in Dbghelp.h.</para>
		/// <para><code>#if !defined(_IMAGEHLP_SOURCE_) &amp;&amp; defined(_IMAGEHLP64) #define PREAD_PROCESS_MEMORY_ROUTINE PREAD_PROCESS_MEMORY_ROUTINE64 #else typedef BOOL (__stdcall *PREAD_PROCESS_MEMORY_ROUTINE)( __in HANDLE hProcess, __in DWORD lpBaseAddress, __out_bcount(nSize) PVOID lpBuffer, __in DWORD nSize, __out PDWORD lpNumberOfBytesRead ); #endif </code></para>
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows/win32/api/dbghelp/nc-dbghelp-pread_process_memory_routine
		// PREAD_PROCESS_MEMORY_ROUTINE PreadProcessMemoryRoutine; BOOL PreadProcessMemoryRoutine( HANDLE hProcess, DWORD lpBaseAddress, PVOID lpBuffer, DWORD nSize, PDWORD lpNumberOfBytesRead ) {...}
		[UnmanagedFunctionPointer(CallingConvention.Winapi)]
		[PInvokeData("dbghelp.h", MSDNShortId = "NC:dbghelp.PREAD_PROCESS_MEMORY_ROUTINE")]
		[return: MarshalAs(UnmanagedType.Bool)]
		public delegate bool PREAD_PROCESS_MEMORY_ROUTINE(HPROCESS hProcess, uint lpBaseAddress, [Out] IntPtr lpBuffer, uint nSize, out uint lpNumberOfBytesRead);

		/// <summary>
		/// <para>An application-defined callback function used with the StackWalk64 function. It is called when <c>StackWalk64</c> needs to read memory from the address space of the process.</para>
		/// <para>The <c>PREAD_PROCESS_MEMORY_ROUTINE64</c> type defines a pointer to this callback function. <c>ReadProcessMemoryProc64</c> is a placeholder for the application-defined function name.</para>
		/// </summary>
		/// <param name="hProcess">A handle to the process for which the stack trace is generated.</param>
		/// <param name="lpBaseAddress">The base address of the memory to be read.</param>
		/// <param name="lpBuffer">A pointer to a buffer that receives the memory to be read.</param>
		/// <param name="nSize">The size of the memory to be read, in bytes.</param>
		/// <param name="lpNumberOfBytesRead">A pointer to a variable that receives the number of bytes actually read.</param>
		/// <returns>If the function succeeds, the return value should be <c>TRUE</c>. If the function fails, the return value should be <c>FALSE</c>.</returns>
		/// <remarks>
		/// <para>In many cases, this function can best service the callback with a corresponding call to ReadProcessMemory.</para>
		/// <para>This function should read as much of the requested memory as possible. The StackWalk64 function handles the case where only part of the requested memory is read.</para>
		/// <para>This callback function supersedes the PREAD_PROCESS_MEMORY_ROUTINE callback function. PREAD_PROCESS_MEMORY_ROUTINE is defined as follows in Dbghelp.h.</para>
		/// <para><code>#if !defined(_IMAGEHLP_SOURCE_) &amp;&amp; defined(_IMAGEHLP64) #define PREAD_PROCESS_MEMORY_ROUTINE PREAD_PROCESS_MEMORY_ROUTINE64 #else typedef BOOL (__stdcall *PREAD_PROCESS_MEMORY_ROUTINE)( __in HANDLE hProcess, __in DWORD lpBaseAddress, __out_bcount(nSize) PVOID lpBuffer, __in DWORD nSize, __out PDWORD lpNumberOfBytesRead ); #endif </code></para>
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows/win32/api/dbghelp/nc-dbghelp-pread_process_memory_routine
		// PREAD_PROCESS_MEMORY_ROUTINE PreadProcessMemoryRoutine; BOOL PreadProcessMemoryRoutine( HANDLE hProcess, DWORD lpBaseAddress, PVOID lpBuffer, DWORD nSize, PDWORD lpNumberOfBytesRead ) {...}
		[UnmanagedFunctionPointer(CallingConvention.Winapi)]
		[PInvokeData("dbghelp.h", MSDNShortId = "NC:dbghelp.PREAD_PROCESS_MEMORY_ROUTINE")]
		[return: MarshalAs(UnmanagedType.Bool)]
		public delegate bool PREAD_PROCESS_MEMORY_ROUTINE64(HPROCESS hProcess, ulong lpBaseAddress, [Out] IntPtr lpBuffer, uint nSize, out uint lpNumberOfBytesRead);

		/// <summary>Searches a directory tree for a specified file.</summary>
		/// <param name="RootPath">The path where the function should begin searching for the file.</param>
		/// <param name="InputPathName">The file for which the function will search. You can use a partial path.</param>
		/// <param name="OutputPathBuffer">A pointer to a buffer that receives the full path to the file that is found. This string is not modified if the return value is <c>FALSE</c>.</param>
		/// <returns>
		/// <para>If the function succeeds, the return value is <c>TRUE</c>.</para>
		/// <para>If the function fails, the return value is <c>FALSE</c>. To retrieve extended error information, call GetLastError.</para>
		/// </returns>
		/// <remarks>
		/// <para>The function searches for the file specified by the InputPathName parameter beginning at the path specified in the RootPath parameter. The maximum path depth that is allowed in the RootPath is 32 directories. When the function finds the file in the directory tree, it places the full path to the file in the buffer specified by the OutputPathBuffer parameter. The underlying file system specifies the order of the subdirectory search.</para>
		/// <para>The search can be canceled if you register a SymRegisterCallbackProc64 callback function. For every directory searched, <c>SearchTreeForFile</c> calls this callback function with CBA_DEFERRED_SYMBOL_LOAD_CANCEL. If the callback function returns <c>TRUE</c>, <c>SearchTreeForFile</c> cancels the search.</para>
		/// <para>This function triggers one CBA_DEFERRED_SYMBOL_LOAD_CANCEL event per directory searched. This allows the caller to cancel the search.</para>
		/// <para>All DbgHelp functions, such as this one, are single threaded. Therefore, calls from more than one thread to this function will likely result in unexpected behavior or memory corruption. To avoid this, you must synchronize all concurrent calls from more than one thread to this function.</para>
		/// <para>To call the Unicode version of this function, define DBGHELP_TRANSLATE_TCHAR.</para>
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows/win32/api/dbghelp/nf-dbghelp-searchtreeforfile
		// BOOL IMAGEAPI SearchTreeForFile( PCSTR RootPath, PCSTR InputPathName, PSTR OutputPathBuffer );
		[DllImport(Lib_DbgHelp, SetLastError = true, CharSet = CharSet.Auto)]
		[PInvokeData("dbghelp.h", MSDNShortId = "NF:dbghelp.SearchTreeForFile")]
		[return: MarshalAs(UnmanagedType.Bool)]
		public static extern bool SearchTreeForFile([MarshalAs(UnmanagedType.LPTStr)] string RootPath, [MarshalAs(UnmanagedType.LPTStr)] string InputPathName, [MarshalAs(UnmanagedType.LPTStr)] StringBuilder OutputPathBuffer);

		/// <summary>Sets a symbol load error.</summary>
		/// <param name="error">A symbol load error.</param>
		/// <returns>This function does not return a value.</returns>
		// https://docs.microsoft.com/en-us/windows/win32/api/dbghelp/nf-dbghelp-setsymloaderror
		// void IMAGEAPI SetSymLoadError( DWORD error );
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
		// https://docs.microsoft.com/en-us/windows/win32/api/dbghelp/nf-dbghelp-stackwalk64
		// BOOL IMAGEAPI StackWalk64( DWORD MachineType, HANDLE hProcess, HANDLE hThread, LPSTACKFRAME64 StackFrame, PVOID ContextRecord, PREAD_PROCESS_MEMORY_ROUTINE64 ReadMemoryRoutine, PFUNCTION_TABLE_ACCESS_ROUTINE64 FunctionTableAccessRoutine, PGET_MODULE_BASE_ROUTINE64 GetModuleBaseRoutine, PTRANSLATE_ADDRESS_ROUTINE64 TranslateAddress );
		[DllImport(Lib_DbgHelp, SetLastError = false, CharSet = CharSet.Auto)]
		[PInvokeData("dbghelp.h", MSDNShortId = "NF:dbghelp.StackWalk64")]
		[return: MarshalAs(UnmanagedType.Bool)]
		public static extern bool StackWalk64(IMAGE_FILE_MACHINE MachineType, HPROCESS hProcess, HTHREAD hThread, ref STACKFRAME64 StackFrame, [In, Out] IntPtr ContextRecord,
			[Optional] PREAD_PROCESS_MEMORY_ROUTINE64 ReadMemoryRoutine, [Optional] PFUNCTION_TABLE_ACCESS_ROUTINE64 FunctionTableAccessRoutine,
			[Optional] PGET_MODULE_BASE_ROUTINE64 GetModuleBaseRoutine, [Optional] PTRANSLATE_ADDRESS_ROUTINE64 TranslateAddress);

		/// <summary>
		/// <para>An application-defined callback function used with the StackWalk64 function. It provides address translation for 16-bit addresses.</para>
		/// <para>The <c>PTRANSLATE_ADDRESS_ROUTINE64</c> type defines a pointer to this callback function. <c>TranslateAddressProc64</c> is a placeholder for the application-defined function name.</para>
		/// </summary>
		/// <param name="hProcess">A handle to the process for which the stack trace is generated.</param>
		/// <param name="hThread">A handle to the thread for which the stack trace is generated.</param>
		/// <param name="lpaddr">An address to be translated.</param>
		/// <returns>The function returns the translated address.</returns>
		/// <remarks>
		/// <para>This callback function supersedes the PTRANSLATE_ADDRESS_ROUTINE callback function. PTRANSLATE_ADDRESS_ROUTINE is defined as follows in Dbghelp.h.</para>
		/// <para><code>#if !defined(_IMAGEHLP_SOURCE_) &amp;&amp; defined(_IMAGEHLP64) #define PTRANSLATE_ADDRESS_ROUTINE PTRANSLATE_ADDRESS_ROUTINE64 #else typedef DWORD (__stdcall *PTRANSLATE_ADDRESS_ROUTINE)( __in HANDLE hProcess, __in HANDLE hThread, __out LPADDRESS lpaddr ); #endif </code></para>
		/// </remarks>
		// https://docs.microsoft.com/vi-vn/windows/win32/api/dbghelp/nc-dbghelp-ptranslate_address_routine64
		// PTRANSLATE_ADDRESS_ROUTINE64 PtranslateAddressRoutine64; DWORD64 PtranslateAddressRoutine64( HANDLE hProcess, HANDLE hThread, LPADDRESS64 lpaddr ) {...}
		[UnmanagedFunctionPointer(CallingConvention.Winapi)]
		[PInvokeData("dbghelp.h", MSDNShortId = "NC:dbghelp.PTRANSLATE_ADDRESS_ROUTINE64")]
		public delegate ulong PTRANSLATE_ADDRESS_ROUTINE64(HPROCESS hProcess, HTHREAD hThread, in ADDRESS64 lpaddr);


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
		/// <param name="hProcess">A handle to the process for which the stack trace is generated. If the caller supplies a valid callback pointer for the ReadMemoryRoutine parameter, then this value does not have to be a valid process handle. It can be a token that is unique and consistently the same for all calls to the <c>StackWalkEx</c> function. If the symbol handler is used with <c>StackWalkEx</c>, use the same process handles for the calls to each function.</param>
		/// <param name="hThread">A handle to the thread for which the stack trace is generated. If the caller supplies a valid callback pointer for the ReadMemoryRoutine parameter, then this value does not have to be a valid thread handle. It can be a token that is unique and consistently the same for all calls to the <c>StackWalkEx</c> function.</param>
		/// <param name="StackFrame">A pointer to a STACKFRAME_EX structure. This structure receives information for the next frame, if the function call succeeds.</param>
		/// <param name="ContextRecord">
		/// <para>A pointer to a CONTEXT structure. This parameter is required only when the MachineType parameter is not <c>IMAGE_FILE_MACHINE_I386</c>. However, it is recommended that this parameter contain a valid context record. This allows <c>StackWalkEx</c> to handle a greater variety of situations.</para>
		/// <para>This context may be modified, so do not pass a context record that should not be modified.</para>
		/// </param>
		/// <param name="ReadMemoryRoutine">
		/// <para>A callback routine that provides memory read services. When the <c>StackWalkEx</c> function needs to read memory from the process's address space, the ReadProcessMemoryProc64 callback is used.</para>
		/// <para>If this parameter is <c>NULL</c>, then the function uses a default routine. In this case, the hProcess parameter must be a valid process handle.</para>
		/// <para>If this parameter is not <c>NULL</c>, the application should implement and register a symbol handler callback function that handles <c>CBA_READ_MEMORY</c>.</para>
		/// </param>
		/// <param name="FunctionTableAccessRoutine">
		/// <para>A callback routine that provides access to the run-time function table for the process. This parameter is required because the <c>StackWalkEx</c> function does not have access to the process's run-time function table. For more information, see FunctionTableAccessProc64.</para>
		/// <para>The symbol handler provides functions that load and access the run-time table. If these functions are used, then SymFunctionTableAccess64 can be passed as a valid parameter.</para>
		/// </param>
		/// <param name="GetModuleBaseRoutine">
		/// <para>A callback routine that provides a module base for any given virtual address. This parameter is required. For more information, see GetModuleBaseProc64.</para>
		/// <para>The symbol handler provides functions that load and maintain module information. If these functions are used, then SymGetModuleBase64 can be passed as a valid parameter.</para>
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
		/// <para>If the function fails, the return value is <c>FALSE</c>. Note that <c>StackWalkEx</c> generally does not set the last error code.</para>
		/// </returns>
		/// <remarks>
		/// <para>The <c>StackWalkEx</c> function provides a portable method for obtaining a stack trace. Using the <c>StackWalkEx</c> function is recommended over writing your own function because of all the complexities associated with stack walking on platforms. In addition, there are compiler options that cause the stack to appear differently, depending on how the module is compiled. By using this function, your application has a portable stack trace that continues to work as the compiler and operating system change.</para>
		/// <para>The first call to this function will fail if the <c>AddrPC</c>, <c>AddrFrame</c>, and <c>AddrStack</c> members of the STACKFRAME64 structure passed in the StackFrame parameter are not initialized.</para>
		/// <para>All DbgHelp functions, such as this one, are single threaded. Therefore, calls from more than one thread to this function will likely result in unexpected behavior or memory corruption. To avoid this, you must synchronize all concurrent calls from more than one thread to this function.</para>
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows/win32/api/dbghelp/nf-dbghelp-stackwalkex
		// BOOL IMAGEAPI StackWalkEx( DWORD MachineType, HANDLE hProcess, HANDLE hThread, LPSTACKFRAME_EX StackFrame, PVOID ContextRecord, PREAD_PROCESS_MEMORY_ROUTINE64 ReadMemoryRoutine, PFUNCTION_TABLE_ACCESS_ROUTINE64 FunctionTableAccessRoutine, PGET_MODULE_BASE_ROUTINE64 GetModuleBaseRoutine, PTRANSLATE_ADDRESS_ROUTINE64 TranslateAddress, DWORD Flags );
		[DllImport(Lib_DbgHelp, SetLastError = false, ExactSpelling = true)]
		[PInvokeData("dbghelp.h", MSDNShortId = "NF:dbghelp.StackWalkEx")]
		[return: MarshalAs(UnmanagedType.Bool)]
		public static extern bool StackWalkEx(IMAGE_FILE_MACHINE MachineType, HPROCESS hProcess, HTHREAD hThread, ref STACKFRAME_EX StackFrame, [In, Out] IntPtr ContextRecord,
			[Optional] PREAD_PROCESS_MEMORY_ROUTINE64 ReadMemoryRoutine, [Optional] PFUNCTION_TABLE_ACCESS_ROUTINE64 FunctionTableAccessRoutine,
			[Optional] PGET_MODULE_BASE_ROUTINE64 GetModuleBaseRoutine, [Optional] PTRANSLATE_ADDRESS_ROUTINE64 TranslateAddress, SYM_STKWALK Flags);

		/// <summary>
		/// Flags for <see cref="StackWalkEx"/>.
		/// </summary>
		[PInvokeData("dbghelp.h", MSDNShortId = "NF:dbghelp.StackWalkEx")]
		[Flags]
		public enum SYM_STKWALK
		{
			/// <summary/>
			SYM_STKWALK_DEFAULT = 0x00000000,
			/// <summary/>
			SYM_STKWALK_FORCE_FRAMEPTR = 0x00000001
		}

		/// <summary>Indicates whether the specified address is within an inline frame.</summary>
		/// <param name="hProcess">A handle to a process. This handle must have been previously passed to the SymInitialize function.</param>
		/// <param name="Address">The address.</param>
		/// <returns>Returns zero if the address is not within an inline frame.</returns>
		// https://docs.microsoft.com/en-us/windows/win32/api/dbghelp/nf-dbghelp-symaddrincludeinlinetrace
		// DWORD IMAGEAPI SymAddrIncludeInlineTrace( HANDLE hProcess, DWORD64 Address );
		[DllImport(Lib_DbgHelp, SetLastError = false, ExactSpelling = true)]
		[PInvokeData("dbghelp.h", MSDNShortId = "NF:dbghelp.SymAddrIncludeInlineTrace")]
		public static extern uint SymAddrIncludeInlineTrace(HPROCESS hProcess, ulong Address);

		/// <summary>Adds the stream to the specified module for use by the Source Server.</summary>
		/// <param name="hProcess">A handle to a process. This handle must have been previously passed to the SymInitialize function.</param>
		/// <param name="Base">The base address of the module.</param>
		/// <param name="StreamFile">A null-terminated string that contains the absolute or relative path to a file that contains the source indexing stream. Can be <c>NULL</c> if Buffer is not <c>NULL</c>.</param>
		/// <param name="Buffer">A buffer that contains the source indexing stream. Can be <c>NULL</c> if StreamFile is not <c>NULL</c>.</param>
		/// <param name="Size">Size, in bytes, of the Buffer buffer.</param>
		/// <returns>
		/// <para>If the function succeeds, the return value is <c>TRUE</c>.</para>
		/// <para>If the function fails, the return value is <c>FALSE</c>. To retrieve extended error information, call GetLastError.</para>
		/// </returns>
		/// <remarks>
		/// <para><c>SymAddSourceStream</c> adds a stream of data formatted for use by the source Server to a designated module. The caller can pass the stream either as a buffer in the Buffer parameter or a file in the StreamFile parameter. If both parameters are filled, then the function uses the Buffer parameter. If both parameters are <c>NULL</c>, then the function returns <c>FALSE</c> and the last-error code is set to <c>ERROR_INVALID_PARAMETER</c>.</para>
		/// <para>It is important to note that <c>SymAddSourceStream</c> does not add the stream to any corresponding PDB in order to persist the data. This function is used by those programmatically implementing their own debuggers in scenarios in which a PDB is not available.</para>
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows/win32/api/dbghelp/nf-dbghelp-symaddsourcestream
		// BOOL IMAGEAPI SymAddSourceStream( HANDLE hProcess, ULONG64 Base, PCSTR StreamFile, PBYTE Buffer, size_t Size );
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
		/// <para>All DbgHelp functions, such as this one, are single threaded. Therefore, calls from more than one thread to this function will likely result in unexpected behavior or memory corruption. To avoid this, you must synchronize all concurrent calls from more than one thread to this function.</para>
		/// <para>To call the Unicode version of this function, define DBGHELP_TRANSLATE_TCHAR.</para>
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows/win32/api/dbghelp/nf-dbghelp-symaddsymbol
		// BOOL IMAGEAPI SymAddSymbol( HANDLE hProcess, ULONG64 BaseOfDll, PCSTR Name, DWORD64 Address, DWORD Size, DWORD Flags );
		[DllImport(Lib_DbgHelp, SetLastError = true, CharSet = CharSet.Auto)]
		[PInvokeData("dbghelp.h", MSDNShortId = "NF:dbghelp.SymAddSymbol")]
		[return: MarshalAs(UnmanagedType.Bool)]
		public static extern bool SymAddSymbol(HPROCESS hProcess, ulong BaseOfDll, [MarshalAs(UnmanagedType.LPTStr)] string Name, ulong Address, uint Size, uint Flags = 0);

		/// <summary>Deallocates all resources associated with the process handle.</summary>
		/// <param name="hProcess">A handle to the process that was originally passed to the SymInitialize function.</param>
		/// <returns>
		/// <para>If the function succeeds, the return value is <c>TRUE</c>.</para>
		/// <para>If the function fails, the return value is <c>FALSE</c>. To retrieve extended error information, call GetLastError.</para>
		/// </returns>
		/// <remarks>
		/// <para>This function frees all resources associated with the process handle. Failure to call this function causes memory and resource leaks in the calling application</para>
		/// <para>All DbgHelp functions, such as this one, are single threaded. Therefore, calls from more than one thread to this function will likely result in unexpected behavior or memory corruption. To avoid this, call SymInitialize only when your process starts and <c>SymCleanup</c> only when your process ends. It is not necessary for each thread in the process to call these functions.</para>
		/// <para>Examples</para>
		/// <para>For an example, see Terminating the Symbol Handler.</para>
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows/win32/api/dbghelp/nf-dbghelp-symcleanup
		// BOOL IMAGEAPI SymCleanup( HANDLE hProcess );
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
		// https://docs.microsoft.com/en-us/windows/win32/api/dbghelp/nf-dbghelp-symcompareinlinetrace
		// DWORD IMAGEAPI SymCompareInlineTrace( HANDLE hProcess, DWORD64 Address1, DWORD InlineContext1, DWORD64 RetAddress1, DWORD64 Address2, DWORD64 RetAddress2 );
		[DllImport(Lib_DbgHelp, SetLastError = false, ExactSpelling = true)]
		[PInvokeData("dbghelp.h", MSDNShortId = "NF:dbghelp.SymCompareInlineTrace")]
		public static extern SYM_INLINE_COMP SymCompareInlineTrace(HPROCESS hProcess, ulong Address1, uint InlineContext1, ulong RetAddress1, ulong Address2, ulong RetAddress2);

		/// <summary>
		/// Indicates the result of the comparison.
		/// </summary>
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
		/// <para>All DbgHelp functions, such as this one, are single threaded. Therefore, calls from more than one thread to this function will likely result in unexpected behavior or memory corruption. To avoid this, you must synchronize all concurrent calls from more than one thread to this function.</para>
		/// <para>To call the Unicode version of this function, define DBGHELP_TRANSLATE_TCHAR.</para>
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows/win32/api/dbghelp/nf-dbghelp-symdeletesymbol
		// BOOL IMAGEAPI SymDeleteSymbol( HANDLE hProcess, ULONG64 BaseOfDll, PCSTR Name, DWORD64 Address, DWORD Flags );
		[DllImport(Lib.Dbghelp, SetLastError = true, CharSet = CharSet.Auto)]
		[PInvokeData("dbghelp.h", MSDNShortId = "NF:dbghelp.SymDeleteSymbol")]
		[return: MarshalAs(UnmanagedType.Bool)]
		public static extern bool SymDeleteSymbol(HPROCESS hProcess, ulong BaseOfDll, [MarshalAs(UnmanagedType.LPTStr)] string Name, ulong Address, uint Flags = 0);

		/// <summary>Enumerates all modules that have been loaded for the process by the SymLoadModule64 or SymLoadModuleEx function.</summary>
		/// <param name="hProcess">A handle to the process that was originally passed to the SymInitialize function.</param>
		/// <param name="EnumModulesCallback">The enumeration callback function. This function is called once per module. For more information, see SymEnumerateModulesProc64.</param>
		/// <param name="UserContext">A user-defined value or <c>NULL</c>. This value is simply passed to the callback function. Normally, this parameter is used by an application to pass a pointer to a data structure that lets the callback function establish some type of context.</param>
		/// <returns>
		/// <para>If the function succeeds, the return value is <c>TRUE</c>.</para>
		/// <para>If the function fails, the return value is <c>FALSE</c>. To retrieve extended error information, call GetLastError.</para>
		/// </returns>
		/// <remarks>
		/// <para>The <c>SymEnumerateModules64</c> function enumerates all modules that have been loaded for the process by SymLoadModule64, even if the symbol loading is deferred. The enumeration callback function is called once for each module and is passed the module information.</para>
		/// <para>All DbgHelp functions, such as this one, are single threaded. Therefore, calls from more than one thread to this function will likely result in unexpected behavior or memory corruption. To avoid this, you must synchronize all concurrent calls from more than one thread to this function.</para>
		/// <para>To call the Unicode version of this function, define DBGHELP_TRANSLATE_TCHAR. <c>SymEnumerateModulesW64</c> is defined as follows in Dbghelp.h.</para>
		/// <para><code> BOOL IMAGEAPI SymEnumerateModulesW64( __in HANDLE hProcess, __in PSYM_ENUMMODULES_CALLBACKW64 EnumModulesCallback, __in_opt PVOID UserContext ); #ifdef DBGHELP_TRANSLATE_TCHAR #define SymEnumerateModules64 SymEnumerateModulesW64 #endif </code></para>
		/// <para>This function supersedes the <c>SymEnumerateModules</c> function. For more information, see Updated Platform Support. <c>SymEnumerateModules</c> is defined as follows in Dbghelp.h.</para>
		/// <para><code>#if !defined(_IMAGEHLP_SOURCE_) &amp;&amp; defined(_IMAGEHLP64) #define SymEnumerateModules SymEnumerateModules64 #else BOOL IMAGEAPI SymEnumerateModules( __in HANDLE hProcess, __in PSYM_ENUMMODULES_CALLBACK EnumModulesCallback, __in_opt PVOID UserContext ); #endif </code></para>
		/// <para>Examples</para>
		/// <para>For an example, see Enumerating Symbol Modules.</para>
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows/win32/api/dbghelp/nf-dbghelp-symenumeratemodules
		// BOOL IMAGEAPI SymEnumerateModules( HANDLE hProcess, PSYM_ENUMMODULES_CALLBACK EnumModulesCallback, PVOID UserContext );
		[DllImport(Lib.Dbghelp, SetLastError = true, ExactSpelling = true, CharSet = CharSet.Ansi)]
		[PInvokeData("dbghelp.h", MSDNShortId = "NF:dbghelp.SymEnumerateModules")]
		[return: MarshalAs(UnmanagedType.Bool)]
		public static extern bool SymEnumerateModules(HPROCESS hProcess, PSYM_ENUMMODULES_CALLBACK EnumModulesCallback, [In, Optional] IntPtr UserContext);

		/// <summary>Enumerates all modules that have been loaded for the process by the SymLoadModule64 or SymLoadModuleEx function.</summary>
		/// <param name="hProcess">A handle to the process that was originally passed to the SymInitialize function.</param>
		/// <param name="EnumModulesCallback">The enumeration callback function. This function is called once per module. For more information, see SymEnumerateModulesProc64.</param>
		/// <param name="UserContext">A user-defined value or <c>NULL</c>. This value is simply passed to the callback function. Normally, this parameter is used by an application to pass a pointer to a data structure that lets the callback function establish some type of context.</param>
		/// <returns>
		/// <para>If the function succeeds, the return value is <c>TRUE</c>.</para>
		/// <para>If the function fails, the return value is <c>FALSE</c>. To retrieve extended error information, call GetLastError.</para>
		/// </returns>
		/// <remarks>
		/// <para>The <c>SymEnumerateModules64</c> function enumerates all modules that have been loaded for the process by SymLoadModule64, even if the symbol loading is deferred. The enumeration callback function is called once for each module and is passed the module information.</para>
		/// <para>All DbgHelp functions, such as this one, are single threaded. Therefore, calls from more than one thread to this function will likely result in unexpected behavior or memory corruption. To avoid this, you must synchronize all concurrent calls from more than one thread to this function.</para>
		/// <para>To call the Unicode version of this function, define DBGHELP_TRANSLATE_TCHAR. <c>SymEnumerateModulesW64</c> is defined as follows in Dbghelp.h.</para>
		/// <para><code> BOOL IMAGEAPI SymEnumerateModulesW64( __in HANDLE hProcess, __in PSYM_ENUMMODULES_CALLBACKW64 EnumModulesCallback, __in_opt PVOID UserContext ); #ifdef DBGHELP_TRANSLATE_TCHAR #define SymEnumerateModules64 SymEnumerateModulesW64 #endif </code></para>
		/// <para>This function supersedes the <c>SymEnumerateModules</c> function. For more information, see Updated Platform Support. <c>SymEnumerateModules</c> is defined as follows in Dbghelp.h.</para>
		/// <para><code>#if !defined(_IMAGEHLP_SOURCE_) &amp;&amp; defined(_IMAGEHLP64) #define SymEnumerateModules SymEnumerateModules64 #else BOOL IMAGEAPI SymEnumerateModules( __in HANDLE hProcess, __in PSYM_ENUMMODULES_CALLBACK EnumModulesCallback, __in_opt PVOID UserContext ); #endif </code></para>
		/// <para>Examples</para>
		/// <para>For an example, see Enumerating Symbol Modules.</para>
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows/win32/api/dbghelp/nf-dbghelp-symenumeratemodules64
		// BOOL IMAGEAPI SymEnumerateModules64( HANDLE hProcess, PSYM_ENUMMODULES_CALLBACK64 EnumModulesCallback, PVOID UserContext );
		[DllImport(Lib.Dbghelp, SetLastError = true, CharSet = CharSet.Ansi, ExactSpelling = true)]
		[PInvokeData("dbghelp.h", MSDNShortId = "NF:dbghelp.SymEnumerateModules64")]
		[return: MarshalAs(UnmanagedType.Bool)] 
		public static extern bool SymEnumerateModules64(HANDLE hProcess, PSYM_ENUMMODULES_CALLBACK64 EnumModulesCallback, [In, Optional] IntPtr UserContext);

		/// <summary>Enumerates all modules that have been loaded for the process by the SymLoadModule64 or SymLoadModuleEx function.</summary>
		/// <param name="hProcess">A handle to the process that was originally passed to the SymInitialize function.</param>
		/// <param name="EnumModulesCallback">The enumeration callback function. This function is called once per module. For more information, see SymEnumerateModulesProc64.</param>
		/// <param name="UserContext">A user-defined value or <c>NULL</c>. This value is simply passed to the callback function. Normally, this parameter is used by an application to pass a pointer to a data structure that lets the callback function establish some type of context.</param>
		/// <returns>
		/// <para>If the function succeeds, the return value is <c>TRUE</c>.</para>
		/// <para>If the function fails, the return value is <c>FALSE</c>. To retrieve extended error information, call GetLastError.</para>
		/// </returns>
		/// <remarks>
		/// <para>The <c>SymEnumerateModules64</c> function enumerates all modules that have been loaded for the process by SymLoadModule64, even if the symbol loading is deferred. The enumeration callback function is called once for each module and is passed the module information.</para>
		/// <para>All DbgHelp functions, such as this one, are single threaded. Therefore, calls from more than one thread to this function will likely result in unexpected behavior or memory corruption. To avoid this, you must synchronize all concurrent calls from more than one thread to this function.</para>
		/// <para>To call the Unicode version of this function, define DBGHELP_TRANSLATE_TCHAR. <c>SymEnumerateModulesW64</c> is defined as follows in Dbghelp.h.</para>
		/// <para><code> BOOL IMAGEAPI SymEnumerateModulesW64( __in HANDLE hProcess, __in PSYM_ENUMMODULES_CALLBACKW64 EnumModulesCallback, __in_opt PVOID UserContext ); #ifdef DBGHELP_TRANSLATE_TCHAR #define SymEnumerateModules64 SymEnumerateModulesW64 #endif </code></para>
		/// <para>This function supersedes the <c>SymEnumerateModules</c> function. For more information, see Updated Platform Support. <c>SymEnumerateModules</c> is defined as follows in Dbghelp.h.</para>
		/// <para><code>#if !defined(_IMAGEHLP_SOURCE_) &amp;&amp; defined(_IMAGEHLP64) #define SymEnumerateModules SymEnumerateModules64 #else BOOL IMAGEAPI SymEnumerateModules( __in HANDLE hProcess, __in PSYM_ENUMMODULES_CALLBACK EnumModulesCallback, __in_opt PVOID UserContext ); #endif </code></para>
		/// <para>Examples</para>
		/// <para>For an example, see Enumerating Symbol Modules.</para>
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows/win32/api/dbghelp/nf-dbghelp-symenumeratemodulesw64
		// BOOL IMAGEAPI SymEnumerateModulesW64( HANDLE hProcess, PSYM_ENUMMODULES_CALLBACKW64 EnumModulesCallback, PVOID UserContext );
		[DllImport(Lib.Dbghelp, SetLastError = true, CharSet = CharSet.Unicode, ExactSpelling = true)]
		[PInvokeData("dbghelp.h", MSDNShortId = "NF:dbghelp.SymEnumerateModulesW64")]
		[return: MarshalAs(UnmanagedType.Bool)]
		public static extern bool SymEnumerateModulesW64(HANDLE hProcess, PSYM_ENUMMODULES_CALLBACK64 EnumModulesCallback, [In, Optional] IntPtr UserContext);

		/// <summary>
		/// <para>An application-defined callback function used with the SymEnumerateModules64 function. It is called once for each enumerated module, and receives the module information.</para>
		/// <para>The <c>PSYM_ENUMMODULES_CALLBACK64</c> and <c>PSYM_ENUMMODULES_CALLBACKW64</c> types define a pointer to this callback function. <c>SymEnumerateModulesProc64</c> is a placeholder for the application-defined function name.</para>
		/// </summary>
		/// <param name="ModuleName">The name of the module.</param>
		/// <param name="BaseOfDll">The base address where the module is loaded into memory.</param>
		/// <param name="UserContext">The user-defined value specified in SymEnumerateModules64, or <c>NULL</c>. Typically, this parameter is used by an application to pass a pointer to a data structure that lets the callback function establish some type of context.</param>
		/// <returns>
		/// <para>If the return value is <c>TRUE</c>, the enumeration will continue.</para>
		/// <para>If the return value is <c>FALSE</c>, the enumeration will stop.</para>
		/// </returns>
		/// <remarks>
		/// <para>The calling application is called once per module until all modules are enumerated, or until the enumeration callback function returns <c>FALSE</c>.</para>
		/// <para>This callback function supersedes the PSYM_ENUMMODULES_CALLBACK callback function. PSYM_ENUMMODULES_CALLBACK is defined as follows in DbgHelp.h.</para>
		/// <para><code>#if !defined(_IMAGEHLP_SOURCE_) &amp;&amp; defined(_IMAGEHLP64) #define PSYM_ENUMMODULES_CALLBACK PSYM_ENUMMODULES_CALLBACK64 #else typedef BOOL (CALLBACK *PSYM_ENUMMODULES_CALLBACK)( __in PCSTR ModuleName, __in ULONG BaseOfDll, __in_opt PVOID UserContext ); #endif </code></para>
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows/win32/api/dbghelp/nc-dbghelp-psym_enummodules_callback
		// PSYM_ENUMMODULES_CALLBACK PsymEnummodulesCallback; BOOL PsymEnummodulesCallback( PCSTR ModuleName, ULONG BaseOfDll, PVOID UserContext ) {...}
		[UnmanagedFunctionPointer(CallingConvention.Winapi, CharSet = CharSet.Ansi)]
		[PInvokeData("dbghelp.h", MSDNShortId = "NC:dbghelp.PSYM_ENUMMODULES_CALLBACK")]
		[return: MarshalAs(UnmanagedType.Bool)]
		public delegate bool PSYM_ENUMMODULES_CALLBACK([MarshalAs(UnmanagedType.LPStr)] string ModuleName, uint BaseOfDll, [In, Optional] IntPtr UserContext);

		/// <summary>
		/// <para>An application-defined callback function used with the SymEnumerateModules64 function. It is called once for each enumerated module, and receives the module information.</para>
		/// <para>The <c>PSYM_ENUMMODULES_CALLBACK64</c> and <c>PSYM_ENUMMODULES_CALLBACKW64</c> types define a pointer to this callback function. <c>SymEnumerateModulesProc64</c> is a placeholder for the application-defined function name.</para>
		/// </summary>
		/// <param name="ModuleName">The name of the module.</param>
		/// <param name="BaseOfDll">The base address where the module is loaded into memory.</param>
		/// <param name="UserContext">The user-defined value specified in SymEnumerateModules64, or <c>NULL</c>. Typically, this parameter is used by an application to pass a pointer to a data structure that lets the callback function establish some type of context.</param>
		/// <returns>
		/// <para>If the return value is <c>TRUE</c>, the enumeration will continue.</para>
		/// <para>If the return value is <c>FALSE</c>, the enumeration will stop.</para>
		/// </returns>
		/// <remarks>
		/// <para>The calling application is called once per module until all modules are enumerated, or until the enumeration callback function returns <c>FALSE</c>.</para>
		/// <para>This callback function supersedes the PSYM_ENUMMODULES_CALLBACK callback function. PSYM_ENUMMODULES_CALLBACK is defined as follows in DbgHelp.h.</para>
		/// <para><code>#if !defined(_IMAGEHLP_SOURCE_) &amp;&amp; defined(_IMAGEHLP64) #define PSYM_ENUMMODULES_CALLBACK PSYM_ENUMMODULES_CALLBACK64 #else typedef BOOL (CALLBACK *PSYM_ENUMMODULES_CALLBACK)( __in PCSTR ModuleName, __in ULONG BaseOfDll, __in_opt PVOID UserContext ); #endif </code></para>
		/// </remarks>
		// https://docs.microsoft.com/id-id/windows/win32/api/dbghelp/nc-dbghelp-psym_enummodules_callback64
		// PSYM_ENUMMODULES_CALLBACK64 PsymEnummodulesCallback64; BOOL PsymEnummodulesCallback64( PCSTR ModuleName, DWORD64 BaseOfDll, PVOID UserContext ) {...}
		[UnmanagedFunctionPointer(CallingConvention.Winapi, CharSet = CharSet.Auto)]
		[PInvokeData("dbghelp.h", MSDNShortId = "NC:dbghelp.PSYM_ENUMMODULES_CALLBACK64")]
		[return: MarshalAs(UnmanagedType.Bool)]
		public delegate bool PSYM_ENUMMODULES_CALLBACK64([MarshalAs(UnmanagedType.LPTStr)] string ModuleName, ulong BaseOfDll, [In, Optional] IntPtr UserContext);
		
		/*
				SymEnumerateSymbols64
SymEnumerateSymbolsProc64
SymEnumLines
SymEnumLinesProc
SymEnumProcesses
SymEnumProcessesProc
SymEnumSourceFiles
SymEnumSourceFilesProc
SymEnumSourceFileTokens
PENUMSOURCEFILETOKENSCALLBACK
SymEnumSourceLines
SymEnumSymbols
SymEnumSymbolsEx
SymEnumSymbolsForAddr
SymEnumSymbolsProc
SymEnumTypes
SymEnumTypesByName
SymFindDebugInfoFile
SymFindExecutableImage
SymFindFileInPath
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
SymInitialize
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
SymSetOptions
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
TranslateAddressProc64
UnDecorateSymbolName
UnmapDebugInformation
		*/
	}
}