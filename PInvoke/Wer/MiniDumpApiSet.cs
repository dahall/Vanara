using System;
using System.Collections.Generic;
using System.Text;

namespace Vanara.PInvoke;

/// <summary>Functions, structures and constants from minidumpapiset.h.</summary>
public static class DbgHelp
{
	/// <summary>
	/// <para>Identifies the type of information that will be written to the minidump file by the MiniDumpWriteDump function.</para>
	/// <para><c>Important</c></para>
	/// </summary>
	// https://docs.microsoft.com/en-us/windows/win32/api/minidumpapiset/ne-minidumpapiset-_minidump_type
	// typedef enum _MINIDUMP_TYPE { MiniDumpNormal, MiniDumpWithDataSegs, MiniDumpWithFullMemory, MiniDumpWithHandleData, MiniDumpFilterMemory, MiniDumpScanMemory, MiniDumpWithUnloadedModules, MiniDumpWithIndirectlyReferencedMemory, MiniDumpFilterModulePaths, MiniDumpWithProcessThreadData, MiniDumpWithPrivateReadWriteMemory, MiniDumpWithoutOptionalData, MiniDumpWithFullMemoryInfo, MiniDumpWithThreadInfo, MiniDumpWithCodeSegs, MiniDumpWithoutAuxiliaryState, MiniDumpWithFullAuxiliaryState, MiniDumpWithPrivateWriteCopyMemory, MiniDumpIgnoreInaccessibleMemory, MiniDumpWithTokenInformation, MiniDumpWithModuleHeaders, MiniDumpFilterTriage, MiniDumpWithAvxXStateContext, MiniDumpWithIptTrace, MiniDumpValidTypeFlags } MINIDUMP_TYPE;
	[PInvokeData("minidumpapiset.h", MSDNShortId = "89ae3a75-5f02-4c5e-9d72-95fb8ef94985")]
	public enum MINIDUMP_TYPE
	{
		/// <summary>Include just the information necessary to capture stack traces for all existing threads in a process.</summary>
		MiniDumpNormal,
		/// <summary>Include the data sections from all loaded modules. This results in the inclusion of global variables, which can make the minidump file significantly larger. For per-module control, use the ModuleWriteDataSeg enumeration value from MODULE_WRITE_FLAGS.</summary>
		MiniDumpWithDataSegs,
		/// <summary>Include all accessible memory in the process. The raw memory data is included at the end, so that the initial structures can be mapped directly without the raw memory information. This option can result in a very large file.</summary>
		MiniDumpWithFullMemory,
		/// <summary>Include high-level information about the operating system handles that are active when the minidump is made.</summary>
		MiniDumpWithHandleData,
		/// <summary>Stack and backing store memory written to the minidump file should be filtered to remove all but the pointer values necessary to reconstruct a stack trace.</summary>
		MiniDumpFilterMemory,
		/// <summary>Stack and backing store memory should be scanned for pointer references to modules in the module list. If a module is referenced by stack or backing store memory, the ModuleWriteFlags member of the MINIDUMP_CALLBACK_OUTPUT structure is set to ModuleReferencedByMemory.</summary>
		MiniDumpScanMemory,
		/// <summary>Include information from the list of modules that were recently unloaded, if this information is maintained by the operating system. Windows Server 2003 and Windows XP: The operating system does not maintain information for unloaded modules until Windows Server 2003 with SP1 and Windows XP with SP2. DbgHelp 5.1: This value is not supported.</summary>
		MiniDumpWithUnloadedModules,
		/// <summary>Include pages with data referenced by locals or other stack memory. This option can increase the size of the minidump file significantly. DbgHelp 5.1: This value is not supported.</summary>
		MiniDumpWithIndirectlyReferencedMemory,
		/// <summary>Filter module paths for information such as user names or important directories. This option may prevent the system from locating the image file and should be used only in special situations. DbgHelp 5.1: This value is not supported.</summary>
		MiniDumpFilterModulePaths,
		/// <summary>Scan the virtual address space for PAGE_READWRITE memory to be included. DbgHelp 5.1: This value is not supported.</summary>
		MiniDumpWithPrivateReadWriteMemory,
		/// <summary>Include memory region information. For more information, see MINIDUMP_MEMORY_INFO_LIST. DbgHelp 6.1 and earlier: This value is not supported.</summary>
		MiniDumpWithFullMemoryInfo,
		/// <summary>Include all code and code-related sections from loaded modules to capture executable content. For per-module control, use the ModuleWriteCodeSegs enumeration value from MODULE_WRITE_FLAGS. DbgHelp 6.1 and earlier: This value is not supported.</summary>
		MiniDumpWithCodeSegs,
		/// <summary>If you specify MiniDumpWithFullMemory, the MiniDumpWriteDump function will fail if the function cannot read the memory regions; however, if you include MiniDumpIgnoreInaccessibleMemory, the MiniDumpWriteDump function will ignore the memory read failures and continue to generate the dump. Note that the inaccessible memory regions are not included in the dump. Prior to DbgHelp 6.1: This value is not supported.</summary>
		MiniDumpIgnoreInaccessibleMemory,
		/// <summary>Adds module header related data. Prior to DbgHelp 6.1: This value is not supported.</summary>
		MiniDumpWithModuleHeaders,
		/// <summary />
		MiniDumpWithAvxXStateContext,
		/// <summary />
		MiniDumpWithIptTrace,
		/// <summary>Indicates which flags are valid.</summary>
		MiniDumpValidTypeFlags,
	}

	/// <summary>Identifies the type of thread information that will be written to the minidump file by the MiniDumpWriteDump function.</summary>
	// https://docs.microsoft.com/en-us/windows/win32/api/minidumpapiset/ne-minidumpapiset-_thread_write_flags
	// typedef enum _THREAD_WRITE_FLAGS { ThreadWriteThread, ThreadWriteStack, ThreadWriteContext, ThreadWriteBackingStore, ThreadWriteInstructionWindow, ThreadWriteThreadData, ThreadWriteThreadInfo } THREAD_WRITE_FLAGS;
	[PInvokeData("minidumpapiset.h", MSDNShortId = "b2d933c0-5e52-4078-82ea-844c2415eb45")]
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
		/// <summary>A small amount of memory surrounding each thread&#39;s instruction pointer will be written to the minidump file. This allows instructions near a thread&#39;s instruction pointer to be disassembled even if an executable image matching the module cannot be found.</summary>
		ThreadWriteInstructionWindow,
		/// <summary>When the minidump type includes MiniDumpWithProcessThreadData, this flag is set. The callback function can clear this flag to control which threads provide complete thread data in the minidump file. DbgHelp 5.1: This value is not supported.</summary>
		ThreadWriteThreadData,
		/// <summary>When the minidump type includes MiniDumpWithThreadInfo, this flag is set. The callback function can clear this flag to control which threads provide thread state information in the minidump file. For more information, see MINIDUMP_THREAD_INFO. DbgHelp 6.1 and earlier: This value is not supported.</summary>
		ThreadWriteThreadInfo,
	}

	/// <summary>Identifies the type of module information that will be written to the minidump file by the MiniDumpWriteDump function.</summary>
	// https://docs.microsoft.com/en-us/windows/win32/api/minidumpapiset/ne-minidumpapiset-_module_write_flags
	// typedef enum _MODULE_WRITE_FLAGS { ModuleWriteModule, ModuleWriteDataSeg, ModuleWriteMiscRecord, ModuleWriteCvRecord, ModuleReferencedByMemory, ModuleWriteTlsData, ModuleWriteCodeSegs } MODULE_WRITE_FLAGS;
	[PInvokeData("minidumpapiset.h", MSDNShortId = "f074edb2-2cd7-44f6-994b-c649201c1e9d")]
	public enum MODULE_WRITE_FLAGS
	{
		/// <summary>Only module information will be written to the minidump file.</summary>
		ModuleWriteModule,
		/// <summary>Module and data segment information will be written to the minidump file. This value will only be set if the MiniDumpWithDataSegs enumeration value from MINIDUMP_TYPE is set.</summary>
		ModuleWriteDataSeg,
		/// <summary>Module, data segment, and miscellaneous record information will be written to the minidump file.</summary>
		ModuleWriteMiscRecord,
		/// <summary>CodeView information will be written to the minidump file. Some debuggers need the CodeView information to properly locate symbols.</summary>
		ModuleWriteCvRecord,
		/// <summary>Indicates that a module was referenced by a pointer on the stack or backing store of a thread in the minidump. This value is valid only if the DumpType parameter of the MiniDumpWriteDump function includes MiniDumpScanMemory.</summary>
		ModuleReferencedByMemory,
		/// <summary>Per-module automatic TLS data is written to the minidump file. (Note that automatic TLS data is created using __declspec(thread) while TlsAlloc creates dynamic TLS data). This value is valid only if the DumpType parameter of the MiniDumpWriteDump function includes MiniDumpWithProcessThreadData. DbgHelp 6.1 and earlier: This value is not supported.</summary>
		ModuleWriteTlsData,
		/// <summary>Code segment information will be written to the minidump file. This value will only be set if the MiniDumpWithCodeSegs enumeration value from MINIDUMP_TYPE is set. DbgHelp 6.1 and earlier: This value is not supported.</summary>
		ModuleWriteCodeSegs,
	}
}
