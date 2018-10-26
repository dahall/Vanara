using System;
using System.Runtime.InteropServices;
using System.Text;

namespace Vanara.PInvoke
{
	public static partial class Kernel32
	{
		/// <summary>
		/// <para>An application-defined callback function used with the EnumPageFiles function.</para>
		/// <para>
		/// The <c>PENUM_PAGE_FILE_CALLBACK</c> type defines a pointer to this callback function. <c>EnumPageFilesProc</c> is a placeholder
		/// for the application-defined function name.
		/// </para>
		/// </summary>
		/// <param name="pContext">
		/// <para>The user-defined data passed from EnumPageFiles.</para>
		/// </param>
		/// <param name="pPageFileInfo">
		/// <para>A pointer to an ENUM_PAGE_FILE_INFORMATION structure.</para>
		/// </param>
		/// <param name="lpFilename">
		/// <para>The name of the pagefile.</para>
		/// </param>
		/// <returns>
		/// <para>To continue enumeration, the callback function must return TRUE.</para>
		/// <para>To stop enumeration, the callback function must return FALSE.</para>
		/// </returns>
		// https://docs.microsoft.com/en-us/windows/desktop/api/psapi/nc-psapi-penum_page_file_callbacka PENUM_PAGE_FILE_CALLBACKA
		// PenumPageFileCallbacka; BOOL PenumPageFileCallbacka( LPVOID pContext, PENUM_PAGE_FILE_INFORMATION pPageFileInfo, LPCSTR lpFilename
		// ) {...}
		[UnmanagedFunctionPointer(CallingConvention.Winapi, CharSet = CharSet.Auto)]
		[PInvokeData("psapi.h", MSDNShortId = "eb3610fb-2c95-4f7b-973d-8dc41d2829f1")]
		[return: MarshalAs(UnmanagedType.Bool)]
		public delegate bool PenumPageFileCallback(IntPtr pContext, ref ENUM_PAGE_FILE_INFORMATION pPageFileInfo, string lpFilename);

		/// <summary>Used by <see cref="EnumProcessModulesEx"/>.</summary>
		[PInvokeData("psapi.h", MSDNShortId = "0f982f32-31f4-47b6-85d2-d6e17aa4eeb9")]
		public enum LIST_MODULES
		{
			/// <summary>Use the default behavior.</summary>
			LIST_MODULES_DEFAULT = 0x0,

			/// <summary>List the 32-bit modules.</summary>
			LIST_MODULES_32BIT = 0x01,

			/// <summary>List the 64-bit modules.</summary>
			LIST_MODULES_64BIT = 0x02,

			/// <summary>List all modules.</summary>
			LIST_MODULES_ALL = 0x03,
		}

		/// <summary>
		/// <para>Removes as many pages as possible from the working set of the specified process.</para>
		/// </summary>
		/// <param name="hProcess">
		/// <para>
		/// A handle to the process. The handle must have the <c>PROCESS_QUERY_INFORMATION</c> or <c>PROCESS_QUERY_LIMITED_INFORMATION</c>
		/// access right and the <c>PROCESS_SET_QUOTA</c> access right. For more information, see Process Security and Access Rights.
		/// </para>
		/// </param>
		/// <returns>
		/// <para>If the function succeeds, the return value is nonzero.</para>
		/// <para>If the function fails, the return value is zero. To get extended error information, call GetLastError.</para>
		/// </returns>
		/// <remarks>
		/// <para>
		/// You can also empty the working set by calling the SetProcessWorkingSetSize or SetProcessWorkingSetSizeEx function with the
		/// dwMinimumWorkingSetSize and dwMaximumWorkingSetSize parameters set to the value .
		/// </para>
		/// <para>
		/// Starting with Windows 7 and Windows Server 2008 R2, Psapi.h establishes version numbers for the PSAPI functions. The PSAPI
		/// version number affects the name used to call the function and the library that a program must load.
		/// </para>
		/// <para>
		/// If <c>PSAPI_VERSION</c> is 2 or greater, this function is defined as <c>K32EmptyWorkingSet</c> in Psapi.h and exported in
		/// Kernel32.lib and Kernel32.dll. If <c>PSAPI_VERSION</c> is 1, this function is defined as K32EmptyWorkingSet in Psapi.h and
		/// exported in Psapi.lib and Psapi.dll as a wrapper that calls <c>K32EmptyWorkingSet</c>.
		/// </para>
		/// <para>
		/// Programs that must run on earlier versions of Windows as well as Windows 7 and later versions should always call this function as
		/// K32EmptyWorkingSet. To ensure correct resolution of symbols, add Psapi.lib to the <c>TARGETLIBS</c> macro and compile the program
		/// with <c>-DPSAPI_VERSION=1</c>. To use run-time dynamic linking, load Psapi.dll.
		/// </para>
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows/desktop/api/psapi/nf-psapi-emptyworkingset BOOL EmptyWorkingSet( HANDLE hProcess );
		[DllImport(Lib.Kernel32, SetLastError = true, ExactSpelling = true)]
		[PInvokeData("psapi.h", MSDNShortId = "76f2252e-7305-46b0-b1af-40ac084e6696")]
		[return: MarshalAs(UnmanagedType.Bool)]
		public static extern bool EmptyWorkingSet(HPROCESS hProcess);

		/// <summary>
		/// <para>Retrieves the load address for each device driver in the system.</para>
		/// </summary>
		/// <param name="lpImageBase">
		/// <para>An array that receives the list of load addresses for the device drivers.</para>
		/// </param>
		/// <param name="cb">
		/// <para>
		/// The size of the lpImageBase array, in bytes. If the array is not large enough to store the load addresses, the lpcbNeeded
		/// parameter receives the required size of the array.
		/// </para>
		/// </param>
		/// <param name="lpcbNeeded">
		/// <para>The number of bytes returned in the lpImageBase array.</para>
		/// </param>
		/// <returns>
		/// <para>If the function succeeds, the return value is nonzero.</para>
		/// <para>If the function fails, the return value is zero. To get extended error information, call GetLastError.</para>
		/// </returns>
		/// <remarks>
		/// <para>
		/// To determine how many device drivers were enumerated by the call to <c>EnumDeviceDrivers</c>, divide the resulting value in the
		/// lpcbNeeded parameter by .
		/// </para>
		/// <para>
		/// Starting with Windows 7 and Windows Server 2008 R2, Psapi.h establishes version numbers for the PSAPI functions. The PSAPI
		/// version number affects the name used to call the function and the library that a program must load.
		/// </para>
		/// <para>
		/// If PSAPI_VERSION is 2 or greater, this function is defined as <c>K32EnumDeviceDrivers</c> in Psapi.h and exported in Kernel32.lib
		/// and Kernel32.dll. If PSAPI_VERSION is 1, this function is defined as <c>EnumDeviceDrivers</c> in Psapi.h and exported in
		/// Psapi.lib and Psapi.dll as a wrapper that calls <c>K32EnumDeviceDrivers</c>.
		/// </para>
		/// <para>
		/// Programs that must run on earlier versions of Windows as well as Windows 7 and later versions should always call this function as
		/// <c>EnumDeviceDrivers</c>. To ensure correct resolution of symbols, add Psapi.lib to the TARGETLIBS macro and compile the program
		/// with –DPSAPI_VERSION=1. To use run-time dynamic linking, load Psapi.dll.
		/// </para>
		/// <para>Examples</para>
		/// <para>For an example, see Enumerating all Device Drivers in the System.</para>
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows/desktop/api/psapi/nf-psapi-enumdevicedrivers BOOL EnumDeviceDrivers( LPVOID *lpImageBase,
		// DWORD cb, LPDWORD lpcbNeeded );
		[DllImport(Lib.Kernel32, SetLastError = true, ExactSpelling = true)]
		[PInvokeData("psapi.h", MSDNShortId = "55925741-da23-44b1-93e8-0e9468434a61")]
		[return: MarshalAs(UnmanagedType.Bool)]
		public static extern bool EnumDeviceDrivers([In, Out, MarshalAs(UnmanagedType.LPArray)] IntPtr[] lpImageBase, uint cb, out uint lpcbNeeded);

		/// <summary>
		/// <para>Calls the callback routine for each installed pagefile in the system.</para>
		/// </summary>
		/// <param name="pCallBackRoutine">
		/// <para>A pointer to the routine called for each pagefile. For more information, see EnumPageFilesProc.</para>
		/// </param>
		/// <param name="pContext">
		/// <para>The user-defined data passed to the callback routine.</para>
		/// </param>
		/// <returns>
		/// <para>
		/// If the function succeeds, the return value is <c>TRUE</c>. If the function fails, the return value is <c>FALSE</c>. To get
		/// extended error information, call GetLastError.
		/// </para>
		/// </returns>
		/// <remarks>
		/// <para>
		/// Starting with Windows 7 and Windows Server 2008 R2, Psapi.h establishes version numbers for the PSAPI functions. The PSAPI
		/// version number affects the name used to call the function and the library that a program must load.
		/// </para>
		/// <para>
		/// If <c>PSAPI_VERSION</c> is 2 or greater, this function is defined as <c>K32EnumPageFiles</c> in Psapi.h and exported in
		/// Kernel32.lib and Kernel32.dll. If <c>PSAPI_VERSION</c> is 1, this function is defined as <c>EnumPageFiles</c> in Psapi.h and
		/// exported in Psapi.lib and Psapi.dll as a wrapper that calls <c>K32EnumPageFiles</c>.
		/// </para>
		/// <para>
		/// Programs that must run on earlier versions of Windows as well as Windows 7 and later versions should always call this function as
		/// <c>EnumPageFiles</c>. To ensure correct resolution of symbols, add Psapi.lib to the <c>TARGETLIBS</c> macro and compile the
		/// program with –DPSAPI_VERSION=1. To use run-time dynamic linking, load Psapi.dll.
		/// </para>
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows/desktop/api/psapi/nf-psapi-enumpagefilesa BOOL EnumPageFilesA( PENUM_PAGE_FILE_CALLBACKA
		// pCallBackRoutine, LPVOID pContext );
		[DllImport(Lib.Kernel32, SetLastError = true, CharSet = CharSet.Auto)]
		[PInvokeData("psapi.h", MSDNShortId = "9289fe3c-a7d9-4acb-aeb6-a50de65db0a2")]
		[return: MarshalAs(UnmanagedType.Bool)]
		public static extern bool EnumPageFiles(PenumPageFileCallback pCallBackRoutine, IntPtr pContext);

		/// <summary>
		/// <para>Retrieves the process identifier for each process object in the system.</para>
		/// </summary>
		/// <param name="lpidProcess">
		/// <para>A pointer to an array that receives the list of process identifiers.</para>
		/// </param>
		/// <param name="cb">
		/// <para>The size of the pProcessIds array, in bytes.</para>
		/// </param>
		/// <param name="lpcbNeeded">
		/// <para>The number of bytes returned in the pProcessIds array.</para>
		/// </param>
		/// <returns>
		/// <para>If the function succeeds, the return value is nonzero.</para>
		/// <para>If the function fails, the return value is zero. To get extended error information, call GetLastError.</para>
		/// </returns>
		/// <remarks>
		/// <para>
		/// It is a good idea to use a large array, because it is hard to predict how many processes there will be at the time you call <c>EnumProcesses</c>.
		/// </para>
		/// <para>
		/// To determine how many processes were enumerated, divide the pBytesReturned value by sizeof(DWORD). There is no indication given
		/// when the buffer is too small to store all process identifiers. Therefore, if pBytesReturned equals cb, consider retrying the call
		/// with a larger array.
		/// </para>
		/// <para>To obtain process handles for the processes whose identifiers you have just obtained, call the OpenProcess function.</para>
		/// <para>
		/// Starting with Windows 7 and Windows Server 2008 R2, Psapi.h establishes version numbers for the PSAPI functions. The PSAPI
		/// version number affects the name used to call the function and the library that a program must load.
		/// </para>
		/// <para>
		/// If PSAPI_VERSION is 2 or greater, this function is defined as <c>K32EnumProcesses</c> in Psapi.h and exported in Kernel32.lib and
		/// Kernel32.dll. If PSAPI_VERSION is 1, this function is defined as <c>EnumProcesses</c> in Psapi.h and exported in Psapi.lib and
		/// Psapi.dll as a wrapper that calls <c>K32EnumProcesses</c>.
		/// </para>
		/// <para>
		/// Programs that must run on earlier versions of Windows as well as Windows 7 and later versions should always call this function as
		/// <c>EnumProcesses</c>. To ensure correct resolution of symbols, add Psapi.lib to the TARGETLIBS macro and compile the program with
		/// –DPSAPI_VERSION=1. To use run-time dynamic linking, load Psapi.dll.
		/// </para>
		/// <para>Examples</para>
		/// <para>For an example, see Enumerating All Processes or Enumerating All Modules for a Process.</para>
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows/desktop/api/psapi/nf-psapi-enumprocesses BOOL EnumProcesses( DWORD *lpidProcess, DWORD
		// cb, LPDWORD lpcbNeeded );
		[DllImport(Lib.Kernel32, SetLastError = true, CharSet = CharSet.Auto)]
		[PInvokeData("psapi.h", MSDNShortId = "0c0445cb-27d2-4857-a4a5-7a4c180b068b")]
		[return: MarshalAs(UnmanagedType.Bool)]
		public static extern bool EnumProcesses([In, Out, MarshalAs(UnmanagedType.LPArray)] uint[] lpidProcess, uint cb, out uint lpcbNeeded);

		/// <summary>
		/// <para>Retrieves a handle for each module in the specified process.</para>
		/// <para>
		/// To control whether a 64-bit application enumerates 32-bit modules, 64-bit modules, or both types of modules, use the
		/// EnumProcessModulesEx function.
		/// </para>
		/// </summary>
		/// <param name="hProcess">
		/// <para>A handle to the process.</para>
		/// </param>
		/// <param name="lphModule">
		/// <para>An array that receives the list of module handles.</para>
		/// </param>
		/// <param name="cb">
		/// <para>The size of the lphModule array, in bytes.</para>
		/// </param>
		/// <param name="lpcbNeeded">
		/// <para>The number of bytes required to store all module handles in the lphModule array.</para>
		/// </param>
		/// <returns>
		/// <para>If the function succeeds, the return value is nonzero.</para>
		/// <para>If the function fails, the return value is zero. To get extended error information, call GetLastError.</para>
		/// </returns>
		/// <remarks>
		/// <para>
		/// The <c>EnumProcessModules</c> function is primarily designed for use by debuggers and similar applications that must extract
		/// module information from another process. If the module list in the target process is corrupted or not yet initialized, or if the
		/// module list changes during the function call as a result of DLLs being loaded or unloaded, <c>EnumProcessModules</c> may fail or
		/// return incorrect information.
		/// </para>
		/// <para>
		/// It is a good idea to specify a large array of <c>HMODULE</c> values, because it is hard to predict how many modules there will be
		/// in the process at the time you call <c>EnumProcessModules</c>. To determine if the lphModule array is too small to hold all
		/// module handles for the process, compare the value returned in lpcbNeeded with the value specified in cb. If lpcbNeeded is greater
		/// than cb, increase the size of the array and call <c>EnumProcessModules</c> again.
		/// </para>
		/// <para>
		/// To determine how many modules were enumerated by the call to <c>EnumProcessModules</c>, divide the resulting value in the
		/// lpcbNeeded parameter by .
		/// </para>
		/// <para>
		/// The <c>EnumProcessModules</c> function does not retrieve handles for modules that were loaded with the
		/// <c>LOAD_LIBRARY_AS_DATAFILE</c> or similar flags. For more information, see LoadLibraryEx.
		/// </para>
		/// <para>
		/// Do not call CloseHandle on any of the handles returned by this function. The information comes from a snapshot, so there are no
		/// resources to be freed.
		/// </para>
		/// <para>
		/// If this function is called from a 32-bit application running on WOW64, it can only enumerate the modules of a 32-bit process. If
		/// the process is a 64-bit process, this function fails and the last error code is <c>ERROR_PARTIAL_COPY</c> (299).
		/// </para>
		/// <para>
		/// To take a snapshot of specified processes and the heaps, modules, and threads used by these processes, use the
		/// CreateToolhelp32Snapshot function.
		/// </para>
		/// <para>
		/// Starting with Windows 7 and Windows Server 2008 R2, Psapi.h establishes version numbers for the PSAPI functions. The PSAPI
		/// version number affects the name used to call the function and the library that a program must load.
		/// </para>
		/// <para>
		/// If <c>PSAPI_VERSION</c> is 2 or greater, this function is defined as <c>K32EnumProcessModules</c> in Psapi.h and exported in
		/// Kernel32.lib and Kernel32.dll. If <c>PSAPI_VERSION</c> is 1, this function is defined as <c>EnumProcessModules</c> in Psapi.h and
		/// exported in Psapi.lib and Psapi.dll as a wrapper that calls <c>K32EnumProcessModules</c>.
		/// </para>
		/// <para>
		/// Programs that must run on earlier versions of Windows as well as Windows 7 and later versions should always call this function as
		/// <c>EnumProcessModules</c>. To ensure correct resolution of symbols, add Psapi.lib to the <c>TARGETLIBS</c> macro and compile the
		/// program with <c>-DPSAPI_VERSION=1</c>. To use run-time dynamic linking, load Psapi.dll.
		/// </para>
		/// <para>Examples</para>
		/// <para>For an example, see Enumerating All Processes or Enumerating All Modules for a Process.</para>
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows/desktop/api/psapi/nf-psapi-enumprocessmodules BOOL EnumProcessModules( HANDLE hProcess,
		// HMODULE *lphModule, DWORD cb, LPDWORD lpcbNeeded );
		[DllImport(Lib.Kernel32, SetLastError = true, ExactSpelling = true)]
		[PInvokeData("psapi.h", MSDNShortId = "b4088506-2f69-4cf0-9bab-3e6a7185f5b2")]
		[return: MarshalAs(UnmanagedType.Bool)]
		public static extern bool EnumProcessModules(HPROCESS hProcess, [In, Out, MarshalAs(UnmanagedType.LPArray)] IntPtr[] lphModule, uint cb, out uint lpcbNeeded);

		/// <summary>
		/// <para>Retrieves a handle for each module in the specified process that meets the specified filter criteria.</para>
		/// </summary>
		/// <param name="hProcess">
		/// <para>A handle to the process.</para>
		/// </param>
		/// <param name="lphModule">
		/// <para>An array that receives the list of module handles.</para>
		/// </param>
		/// <param name="cb">
		/// <para>The size of the lphModule array, in bytes.</para>
		/// </param>
		/// <param name="lpcbNeeded">
		/// <para>The number of bytes required to store all module handles in the lphModule array.</para>
		/// </param>
		/// <param name="dwFilterFlag">
		/// <para>The filter criteria. This parameter can be one of the following values.</para>
		/// <list type="table">
		/// <listheader>
		/// <term>Value</term>
		/// <term>Meaning</term>
		/// </listheader>
		/// <item>
		/// <term>LIST_MODULES_32BIT 0x01</term>
		/// <term>List the 32-bit modules.</term>
		/// </item>
		/// <item>
		/// <term>LIST_MODULES_64BIT 0x02</term>
		/// <term>List the 64-bit modules.</term>
		/// </item>
		/// <item>
		/// <term>LIST_MODULES_ALL 0x03</term>
		/// <term>List all modules.</term>
		/// </item>
		/// <item>
		/// <term>LIST_MODULES_DEFAULT 0x0</term>
		/// <term>Use the default behavior.</term>
		/// </item>
		/// </list>
		/// </param>
		/// <returns>
		/// <para>If the function succeeds, the return value is nonzero.</para>
		/// <para>If the function fails, the return value is zero. To get extended error information, call GetLastError.</para>
		/// </returns>
		/// <remarks>
		/// <para>
		/// The <c>EnumProcessModulesEx</c> function is primarily designed for use by debuggers and similar applications that must extract
		/// module information from another process. If the module list in the target process is corrupted or not yet initialized, or if the
		/// module list changes during the function call as a result of DLLs being loaded or unloaded, <c>EnumProcessModulesEx</c> may fail
		/// or return incorrect information.
		/// </para>
		/// <para>
		/// This function is intended primarily for 64-bit applications. If the function is called by a 32-bit application running under
		/// WOW64, the dwFilterFlag option is ignored and the function provides the same results as the EnumProcessModules function.
		/// </para>
		/// <para>
		/// It is a good idea to specify a large array of <c>HMODULE</c> values, because it is hard to predict how many modules there will be
		/// in the process at the time you call <c>EnumProcessModulesEx</c>. To determine if the lphModule array is too small to hold all
		/// module handles for the process, compare the value returned in lpcbNeeded with the value specified in cb. If lpcbNeeded is greater
		/// than cb, increase the size of the array and call <c>EnumProcessModulesEx</c> again.
		/// </para>
		/// <para>
		/// To determine how many modules were enumerated by the call to <c>EnumProcessModulesEx</c>, divide the resulting value in the
		/// lpcbNeeded parameter by .
		/// </para>
		/// <para>
		/// The <c>EnumProcessModulesEx</c> function does not retrieve handles for modules that were loaded with the
		/// <c>LOAD_LIBRARY_AS_DATAFILE</c> flag. For more information, see LoadLibraryEx.
		/// </para>
		/// <para>
		/// Do not call CloseHandle on any of the handles returned by this function. The information comes from a snapshot, so there are no
		/// resources to be freed.
		/// </para>
		/// <para>
		/// To take a snapshot of specified processes and the heaps, modules, and threads used by these processes, use the
		/// CreateToolhelp32Snapshot function.
		/// </para>
		/// <para>
		/// Starting with Windows 7 and Windows Server 2008 R2, Psapi.h establishes version numbers for the PSAPI functions. The PSAPI
		/// version number affects the name used to call the function and the library that a program must load.
		/// </para>
		/// <para>
		/// If PSAPI_VERSION is 2 or greater, this function is defined as <c>K32EnumProcessModulesEx</c> in Psapi.h and exported in
		/// Kernel32.lib and Kernel32.dll. If PSAPI_VERSION is 1, this function is defined as <c>EnumProcessModulesEx</c> in Psapi.h and
		/// exported in Psapi.lib and Psapi.dll as a wrapper that calls <c>K32EnumProcessModulesEx</c>.
		/// </para>
		/// <para>
		/// Programs that must run on earlier versions of Windows as well as Windows 7 and later versions should always call this function as
		/// <c>EnumProcessModulesEx</c>. To ensure correct resolution of symbols, add Psapi.lib to the TARGETLIBS macro and compile the
		/// program with –DPSAPI_VERSION=1. To use run-time dynamic linking, load Psapi.dll.
		/// </para>
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows/desktop/api/psapi/nf-psapi-enumprocessmodulesex BOOL EnumProcessModulesEx( HANDLE
		// hProcess, HMODULE *lphModule, DWORD cb, LPDWORD lpcbNeeded, DWORD dwFilterFlag );
		[DllImport(Lib.Kernel32, SetLastError = true, ExactSpelling = true)]
		[PInvokeData("psapi.h", MSDNShortId = "0f982f32-31f4-47b6-85d2-d6e17aa4eeb9")]
		[return: MarshalAs(UnmanagedType.Bool)]
		public static extern bool EnumProcessModulesEx(HPROCESS hProcess, [In, Out, MarshalAs(UnmanagedType.LPArray)] IntPtr[] lphModule, uint cb, out uint lpcbNeeded, LIST_MODULES dwFilterFlag);

		/// <summary>
		/// <para>Retrieves the base name of the specified device driver.</para>
		/// </summary>
		/// <param name="ImageBase">
		/// <para>The load address of the device driver. This value can be retrieved using the EnumDeviceDrivers function.</para>
		/// </param>
		/// <param name="lpFilename">
		/// <para>A pointer to the buffer that receives the base name of the device driver.</para>
		/// </param>
		/// <param name="nSize">
		/// <para>
		/// The size of the lpBaseName buffer, in characters. If the buffer is not large enough to store the base name plus the terminating
		/// null character, the string is truncated.
		/// </para>
		/// </param>
		/// <returns>
		/// <para>
		/// If the function succeeds, the return value specifies the length of the string copied to the buffer, not including any terminating
		/// null character.
		/// </para>
		/// <para>If the function fails, the return value is zero. To get extended error information, call GetLastError.</para>
		/// </returns>
		/// <remarks>
		/// <para>
		/// Starting with Windows 7 and Windows Server 2008 R2, Psapi.h establishes version numbers for the PSAPI functions. The PSAPI
		/// version number affects the name used to call the function and the library that a program must load.
		/// </para>
		/// <para>
		/// If PSAPI_VERSION is 2 or greater, this function is defined as <c>K32GetDeviceDriverBaseName</c> in Psapi.h and exported in
		/// Kernel32.lib and Kernel32.dll. If PSAPI_VERSION is 1, this function is defined as <c>GetDeviceDriverBaseName</c> in Psapi.h and
		/// exported in Psapi.lib and Psapi.dll as a wrapper that calls <c>K32GetDeviceDriverBaseName</c>.
		/// </para>
		/// <para>
		/// Programs that must run on earlier versions of Windows as well as Windows 7 and later versions should always call this function as
		/// <c>GetDeviceDriverBaseName</c>. To ensure correct resolution of symbols, add Psapi.lib to the TARGETLIBS macro and compile the
		/// program with –DPSAPI_VERSION=1. To use run-time dynamic linking, load Psapi.dll.
		/// </para>
		/// <para>Examples</para>
		/// <para>For an example, see Enumerating all Device Drivers in the System.</para>
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows/desktop/api/psapi/nf-psapi-getdevicedriverbasenamea DWORD GetDeviceDriverBaseNameA(
		// LPVOID ImageBase, LPSTR lpFilename, DWORD nSize );
		[DllImport(Lib.Kernel32, SetLastError = true, CharSet = CharSet.Auto)]
		[PInvokeData("psapi.h", MSDNShortId = "a19a927d-4669-4d4c-951e-43f294a8fb40")]
		public static extern uint GetDeviceDriverBaseName(IntPtr ImageBase, StringBuilder lpFilename, uint nSize);

		/// <summary>
		/// <para>Retrieves the path available for the specified device driver.</para>
		/// </summary>
		/// <param name="ImageBase">
		/// <para>The load address of the device driver.</para>
		/// </param>
		/// <param name="lpFilename">
		/// <para>A pointer to the buffer that receives the path to the device driver.</para>
		/// </param>
		/// <param name="nSize">
		/// <para>
		/// The size of the lpFilename buffer, in characters. If the buffer is not large enough to store the path plus the terminating null
		/// character, the string is truncated.
		/// </para>
		/// </param>
		/// <returns>
		/// <para>
		/// If the function succeeds, the return value specifies the length of the string copied to the buffer, not including any terminating
		/// null character.
		/// </para>
		/// <para>If the function fails, the return value is zero. To get extended error information, call GetLastError.</para>
		/// </returns>
		/// <remarks>
		/// <para>
		/// Starting with Windows 7 and Windows Server 2008 R2, Psapi.h establishes version numbers for the PSAPI functions. The PSAPI
		/// version number affects the name used to call the function and the library that a program must load.
		/// </para>
		/// <para>
		/// If PSAPI_VERSION is 2 or greater, this function is defined as <c>K32GetDeviceDriverFileName</c> in Psapi.h and exported in
		/// Kernel32.lib and Kernel32.dll. If PSAPI_VERSION is 1, this function is defined as <c>GetDeviceDriverFileName</c> in Psapi.h and
		/// exported in Psapi.lib and Psapi.dll as a wrapper that calls <c>K32GetDeviceDriverFileName</c>.
		/// </para>
		/// <para>
		/// Programs that must run on earlier versions of Windows as well as Windows 7 and later versions should always call this function as
		/// <c>GetDeviceDriverFileName</c>. To ensure correct resolution of symbols, add Psapi.lib to the TARGETLIBS macro and compile the
		/// program with –DPSAPI_VERSION=1. To use run-time dynamic linking, load Psapi.dll.
		/// </para>
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows/desktop/api/psapi/nf-psapi-getdevicedriverfilenamea DWORD GetDeviceDriverFileNameA(
		// LPVOID ImageBase, LPSTR lpFilename, DWORD nSize );
		[DllImport(Lib.Kernel32, SetLastError = true, CharSet = CharSet.Auto)]
		[PInvokeData("psapi.h", MSDNShortId = "6ddbcf7e-e41c-4ea7-b60a-01ed5c98c530")]
		public static extern uint GetDeviceDriverFileName(IntPtr ImageBase, StringBuilder lpFilename, uint nSize);

		/// <summary>
		/// <para>
		/// Checks whether the specified address is within a memory-mapped file in the address space of the specified process. If so, the
		/// function returns the name of the memory-mapped file.
		/// </para>
		/// </summary>
		/// <param name="hProcess">
		/// <para>
		/// A handle to the process. The handle must have the <c>PROCESS_QUERY_INFORMATION</c> and <c>PROCESS_VM_READ</c> access rights. For
		/// more information, see Process Security and Access Rights.
		/// </para>
		/// </param>
		/// <param name="lpv">
		/// <para>The address to be verified.</para>
		/// </param>
		/// <param name="lpFilename">
		/// <para>A pointer to the buffer that receives the name of the memory-mapped file to which the address specified by lpv belongs.</para>
		/// </param>
		/// <param name="nSize">
		/// <para>The size of the lpFilename buffer, in characters.</para>
		/// </param>
		/// <returns>
		/// <para>If the function succeeds, the return value specifies the length of the string copied to the buffer, in characters.</para>
		/// <para>If the function fails, the return value is zero. To get extended error information, call GetLastError.</para>
		/// </returns>
		/// <remarks>
		/// <para>
		/// Starting with Windows 7 and Windows Server 2008 R2, Psapi.h establishes version numbers for the PSAPI functions. The PSAPI
		/// version number affects the name used to call the function and the library that a program must load.
		/// </para>
		/// <para>
		/// If <c>PSAPI_VERSION</c> is 2 or greater, this function is defined as <c>K32GetMappedFileName</c> in Psapi.h and exported in
		/// Kernel32.lib and Kernel32.dll. If <c>PSAPI_VERSION</c> is 1, this function is defined as <c>GetMappedFileName</c> in Psapi.h and
		/// exported in Psapi.lib and Psapi.dll as a wrapper that calls <c>K32GetMappedFileName</c>.
		/// </para>
		/// <para>
		/// Programs that must run on earlier versions of Windows as well as Windows 7 and later versions should always call this function as
		/// <c>GetMappedFileName</c>. To ensure correct resolution of symbols, add Psapi.lib to the <c>TARGETLIBS</c> macro and compile the
		/// program with <c>-DPSAPI_VERSION=1</c>. To use run-time dynamic linking, load Psapi.dll.
		/// </para>
		/// <para>In Windows Server 2012, this function is supported by the following technologies.</para>
		/// <list type="table">
		/// <listheader>
		/// <term>Technology</term>
		/// <term>Supported</term>
		/// </listheader>
		/// <item>
		/// <term>Server Message Block (SMB) 3.0 protocol</term>
		/// <term>Yes</term>
		/// </item>
		/// <item>
		/// <term>SMB 3.0 Transparent Failover (TFO)</term>
		/// <term>Yes</term>
		/// </item>
		/// <item>
		/// <term>SMB 3.0 with Scale-out File Shares (SO)</term>
		/// <term>Yes</term>
		/// </item>
		/// <item>
		/// <term>Cluster Shared Volume File System (CsvFS)</term>
		/// <term>Yes</term>
		/// </item>
		/// <item>
		/// <term>Resilient File System (ReFS)</term>
		/// <term>Yes</term>
		/// </item>
		/// </list>
		/// <para>Examples</para>
		/// <para>For an example, see Obtaining a File Name From a File Handle.</para>
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows/desktop/api/psapi/nf-psapi-getmappedfilenamea DWORD GetMappedFileNameA( HANDLE hProcess,
		// LPVOID lpv, LPSTR lpFilename, DWORD nSize );
		[DllImport(Lib.Kernel32, SetLastError = true, CharSet = CharSet.Auto)]
		[PInvokeData("psapi.h", MSDNShortId = "10a2e5ab-f495-486d-8ef7-ef763716afd1")]
		public static extern uint GetMappedFileName(HPROCESS hProcess, IntPtr lpv, StringBuilder lpFilename, uint nSize);

		/// <summary>
		/// <para>Retrieves the base name of the specified module.</para>
		/// </summary>
		/// <param name="hProcess">
		/// <para>A handle to the process that contains the module.</para>
		/// <para>
		/// The handle must have the <c>PROCESS_QUERY_INFORMATION</c> and <c>PROCESS_VM_READ</c> access rights. For more information, see
		/// Process Security and Access Rights.
		/// </para>
		/// </param>
		/// <param name="hModule">
		/// <para>
		/// A handle to the module. If this parameter is NULL, this function returns the name of the file used to create the calling process.
		/// </para>
		/// </param>
		/// <param name="lpBaseName">
		/// <para>
		/// A pointer to the buffer that receives the base name of the module. If the base name is longer than maximum number of characters
		/// specified by the nSize parameter, the base name is truncated.
		/// </para>
		/// </param>
		/// <param name="nSize">
		/// <para>The size of the lpBaseName buffer, in characters.</para>
		/// </param>
		/// <returns>
		/// <para>If the function succeeds, the return value specifies the length of the string copied to the buffer, in characters.</para>
		/// <para>If the function fails, the return value is zero. To get extended error information, call GetLastError.</para>
		/// </returns>
		/// <remarks>
		/// <para>
		/// The <c>GetModuleBaseName</c> function is primarily designed for use by debuggers and similar applications that must extract
		/// module information from another process. If the module list in the target process is corrupted or is not yet initialized, or if
		/// the module list changes during the function call as a result of DLLs being loaded or unloaded, <c>GetModuleBaseName</c> may fail
		/// or return incorrect information.
		/// </para>
		/// <para>
		/// To retrieve the base name of a module in the current process, use the GetModuleFileName function to retrieve the full module name
		/// and then use a function call such as to scan to the beginning of the base name within the module name string. This is more
		/// efficient and more reliable than calling <c>GetModuleBaseName</c> with a handle to the current process.
		/// </para>
		/// <para>
		/// To retrieve the base name of the main executable module for a remote process, use the GetProcessImageFileName or
		/// QueryFullProcessImageName function to retrieve the module name and then use the function as described in the previous paragraph.
		/// This is more efficient and more reliable than calling <c>GetModuleBaseName</c> with a NULL module handle.
		/// </para>
		/// <para>
		/// The <c>GetModuleBaseName</c> function does not retrieve the base name for modules that were loaded with the
		/// <c>LOAD_LIBRARY_AS_DATAFILE</c> flag. For more information, see LoadLibraryEx.
		/// </para>
		/// <para>
		/// Starting with Windows 7 and Windows Server 2008 R2, Psapi.h establishes version numbers for the PSAPI functions. The PSAPI
		/// version number affects the name used to call the function and the library that a program must load.
		/// </para>
		/// <para>
		/// If <c>PSAPI_VERSION</c> is 2 or greater, this function is defined as <c>K32GetModuleBaseName</c> in Psapi.h and exported in
		/// Kernel32.lib and Kernel32.dll. If <c>PSAPI_VERSION</c> is 1, this function is defined as <c>GetModuleBaseName</c> in Psapi.h and
		/// exported in Psapi.lib and Psapi.dll as a wrapper that calls <c>K32GetModuleBaseName</c>.
		/// </para>
		/// <para>
		/// Programs that must run on earlier versions of Windows as well as Windows 7 and later versions should always call this function as
		/// <c>GetModuleBaseName</c>. To ensure correct resolution of symbols, add Psapi.lib to the <c>TARGETLIBS</c> macro and compile the
		/// program with <c>-DPSAPI_VERSION=1</c>. To use run-time dynamic linking, load Psapi.dll.
		/// </para>
		/// <para>Examples</para>
		/// <para>For an example, see Enumerating All Processes.</para>
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows/desktop/api/psapi/nf-psapi-getmodulebasenamea DWORD GetModuleBaseNameA( HANDLE hProcess,
		// HMODULE hModule, LPSTR lpBaseName, DWORD nSize );
		[DllImport(Lib.Kernel32, SetLastError = true, CharSet = CharSet.Auto)]
		[PInvokeData("psapi.h", MSDNShortId = "31a9eb69-95f0-4dd7-8fd5-296f2cff0b8a")]
		public static extern uint GetModuleBaseName(HPROCESS hProcess, [Optional] HINSTANCE hModule, StringBuilder lpBaseName, uint nSize);

		/// <summary>
		/// <para>Retrieves information about the specified module in the MODULEINFO structure.</para>
		/// </summary>
		/// <param name="hProcess">
		/// <para>A handle to the process that contains the module.</para>
		/// <para>
		/// The handle must have the <c>PROCESS_QUERY_INFORMATION</c> and <c>PROCESS_VM_READ</c> access rights. For more information, see
		/// Process Security and Access Rights.
		/// </para>
		/// </param>
		/// <param name="hModule">
		/// <para>A handle to the module.</para>
		/// </param>
		/// <param name="lpmodinfo">
		/// <para>A pointer to the MODULEINFO structure that receives information about the module.</para>
		/// </param>
		/// <param name="cb">
		/// <para>The size of the MODULEINFO structure, in bytes.</para>
		/// </param>
		/// <returns>
		/// <para>If the function succeeds, the return value is nonzero.</para>
		/// <para>If the function fails, the return value is zero. To get extended error information, call GetLastError.</para>
		/// </returns>
		/// <remarks>
		/// <para>To get information for the calling process, pass the handle returned by GetCurrentProcess.</para>
		/// <para>
		/// The <c>GetModuleInformation</c> function does not retrieve information for modules that were loaded with the
		/// <c>LOAD_LIBRARY_AS_DATAFILE</c> flag. For more information, see LoadLibraryEx.
		/// </para>
		/// <para>
		/// Starting with Windows 7 and Windows Server 2008 R2, Psapi.h establishes version numbers for the PSAPI functions. The PSAPI
		/// version number affects the name used to call the function and the library that a program must load.
		/// </para>
		/// <para>
		/// If <c>PSAPI_VERSION</c> is 2 or greater, this function is defined as <c>K32GetModuleInformation</c> in Psapi.h and exported in
		/// Kernel32.lib and Kernel32.dll. If <c>PSAPI_VERSION</c> is 1, this function is defined as K32GetModuleInformation in Psapi.h and
		/// exported in Psapi.lib and Psapi.dll as a wrapper that calls <c>K32GetModuleInformation</c>.
		/// </para>
		/// <para>
		/// Programs that must run on earlier versions of Windows as well as Windows 7 and later versions should always call this function as
		/// K32GetModuleInformation. To ensure correct resolution of symbols, add Psapi.lib to the <c>TARGETLIBS</c> macro and compile the
		/// program with <c>-DPSAPI_VERSION=1</c>. To use run-time dynamic linking, load Psapi.dll.
		/// </para>
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows/desktop/api/psapi/nf-psapi-getmoduleinformation BOOL GetModuleInformation( HANDLE
		// hProcess, HMODULE hModule, LPMODULEINFO lpmodinfo, DWORD cb );
		[DllImport(Lib.Kernel32, SetLastError = true, ExactSpelling = true)]
		[PInvokeData("psapi.h", MSDNShortId = "afb9f4c8-c8ae-4497-96c1-b559cfa2cedf")]
		[return: MarshalAs(UnmanagedType.Bool)]
		public static extern bool GetModuleInformation(HPROCESS hProcess, HINSTANCE hModule, out MODULEINFO lpmodinfo, uint cb);

		/// <summary>
		/// <para>Retrieves the performance values contained in the PERFORMANCE_INFORMATION structure.</para>
		/// </summary>
		/// <param name="pPerformanceInformation">
		/// <para>A pointer to a PERFORMANCE_INFORMATION structure that receives the performance information.</para>
		/// </param>
		/// <param name="cb">
		/// <para>The size of the PERFORMANCE_INFORMATION structure, in bytes.</para>
		/// </param>
		/// <returns>
		/// <para>
		/// If the function succeeds, the return value is TRUE. If the function fails, the return value is FALSE. To get extended error
		/// information, call GetLastError.
		/// </para>
		/// </returns>
		/// <remarks>
		/// <para>
		/// Starting with Windows 7 and Windows Server 2008 R2, Psapi.h establishes version numbers for the PSAPI functions. The PSAPI
		/// version number affects the name used to call the function and the library that a program must load.
		/// </para>
		/// <para>
		/// If PSAPI_VERSION is 2 or greater, this function is defined as <c>K32GetPerformanceInfo</c> in Psapi.h and exported in
		/// Kernel32.lib and Kernel32.dll. If PSAPI_VERSION is 1, this function is defined as <c>GetPerformanceInfo</c> in Psapi.h and
		/// exported in Psapi.lib and Psapi.dll as a wrapper that calls <c>K32GetPerformanceInfo</c>.
		/// </para>
		/// <para>
		/// Programs that must run on earlier versions of Windows as well as Windows 7 and later versions should always call this function as
		/// <c>GetPerformanceInfo</c>. To ensure correct resolution of symbols, add Psapi.lib to the TARGETLIBS macro and compile the program
		/// with –DPSAPI_VERSION=1. To use run-time dynamic linking, load Psapi.dll.
		/// </para>
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows/desktop/api/psapi/nf-psapi-getperformanceinfo BOOL GetPerformanceInfo(
		// PPERFORMANCE_INFORMATION pPerformanceInformation, DWORD cb );
		[DllImport(Lib.Kernel32, SetLastError = true, ExactSpelling = true)]
		[PInvokeData("psapi.h", MSDNShortId = "21655278-49da-4e63-a4f9-0ee9f6179f4a")]
		[return: MarshalAs(UnmanagedType.Bool)]
		public static extern bool GetPerformanceInfo(ref PERFORMANCE_INFORMATION pPerformanceInformation, uint cb);

		/// <summary>
		/// <para>Retrieves the name of the executable file for the specified process.</para>
		/// </summary>
		/// <param name="hProcess">
		/// <para>
		/// A handle to the process. The handle must have the <c>PROCESS_QUERY_INFORMATION</c> or <c>PROCESS_QUERY_LIMITED_INFORMATION</c>
		/// access right. For more information, see Process Security and Access Rights.
		/// </para>
		/// <para><c>Windows Server 2003 and Windows XP:</c> The handle must have the <c>PROCESS_QUERY_INFORMATION</c> access right.</para>
		/// </param>
		/// <param name="lpImageFileName">
		/// <para>A pointer to a buffer that receives the full path to the executable file.</para>
		/// </param>
		/// <param name="nSize">
		/// <para>The size of the lpImageFileName buffer, in characters.</para>
		/// </param>
		/// <returns>
		/// <para>If the function succeeds, the return value specifies the length of the string copied to the buffer.</para>
		/// <para>If the function fails, the return value is zero. To get extended error information, call GetLastError.</para>
		/// </returns>
		/// <remarks>
		/// <para>
		/// The file Psapi.dll is installed in the %windir%\System32 directory. If there is another copy of this DLL on your computer, it can
		/// lead to the following error when running applications on your system: "The procedure entry point GetProcessImageFileName could
		/// not be located in the dynamic link library PSAPI.DLL." To work around this problem, locate any versions that are not in the
		/// %windir%\System32 directory and delete or rename them, then restart.
		/// </para>
		/// <para>
		/// The <c>GetProcessImageFileName</c> function returns the path in device form, rather than drive letters. For example, the file
		/// name C:\Windows\System32\Ctype.nls would look as follows in device form:
		/// </para>
		/// <para>\Device\Harddisk0\Partition1\Windows\System32\Ctype.nls</para>
		/// <para>
		/// To retrieve the module name of the current process, use the GetModuleFileName function with a NULL module handle. This is more
		/// efficient than calling the <c>GetProcessImageFileName</c> function with a handle to the current process.
		/// </para>
		/// <para>
		/// To retrieve the name of the main executable module for a remote process in win32 path format, use the QueryFullProcessImageName function.
		/// </para>
		/// <para>
		/// Starting with Windows 7 and Windows Server 2008 R2, Psapi.h establishes version numbers for the PSAPI functions. The PSAPI
		/// version number affects the name used to call the function and the library that a program must load.
		/// </para>
		/// <para>
		/// If <c>PSAPI_VERSION</c> is 2 or greater, this function is defined as <c>K32GetProcessImageFileName</c> in Psapi.h and exported in
		/// Kernel32.lib and Kernel32.dll. If <c>PSAPI_VERSION</c> is 1, this function is defined as <c>GetProcessImageFileName</c> in
		/// Psapi.h and exported in Psapi.lib and Psapi.dll as a wrapper that calls <c>K32GetProcessImageFileName</c>.
		/// </para>
		/// <para>
		/// Programs that must run on earlier versions of Windows as well as Windows 7 and later versions should always call this function as
		/// <c>GetProcessImageFileName</c>. To ensure correct resolution of symbols, add Psapi.lib to the <c>TARGETLIBS</c> macro and compile
		/// the program with <c>-DPSAPI_VERSION=1</c>. To use run-time dynamic linking, load Psapi.dll.
		/// </para>
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows/desktop/api/psapi/nf-psapi-getprocessimagefilenamea DWORD GetProcessImageFileNameA(
		// HANDLE hProcess, LPSTR lpImageFileName, DWORD nSize );
		[DllImport(Lib.Kernel32, SetLastError = true, CharSet = CharSet.Auto)]
		[PInvokeData("psapi.h", MSDNShortId = "819fc2f4-0801-417b-9cbb-d7fd2894634e")]
		public static extern uint GetProcessImageFileName(HPROCESS hProcess, StringBuilder lpImageFileName, uint nSize);

		/// <summary>
		/// <para>Retrieves information about the memory usage of the specified process.</para>
		/// </summary>
		/// <param name="Process">
		/// <para>
		/// A handle to the process. The handle must have the <c>PROCESS_QUERY_INFORMATION</c> or <c>PROCESS_QUERY_LIMITED_INFORMATION</c>
		/// access right and the <c>PROCESS_VM_READ</c> access right. For more information, see Process Security and Access Rights.
		/// </para>
		/// <para>
		/// <c>Windows Server 2003 and Windows XP:</c> The handle must have the <c>PROCESS_QUERY_INFORMATION</c> and <c>PROCESS_VM_READ</c>
		/// access rights.
		/// </para>
		/// </param>
		/// <param name="ppsmemCounters">
		/// <para>
		/// A pointer to the PROCESS_MEMORY_COUNTERS or PROCESS_MEMORY_COUNTERS_EX structure that receives information about the memory usage
		/// of the process.
		/// </para>
		/// </param>
		/// <param name="cb">
		/// <para>The size of the ppsmemCounters structure, in bytes.</para>
		/// </param>
		/// <returns>
		/// <para>If the function succeeds, the return value is nonzero.</para>
		/// <para>If the function fails, the return value is zero. To get extended error information, call GetLastError.</para>
		/// </returns>
		/// <remarks>
		/// <para>
		/// Starting with Windows 7 and Windows Server 2008 R2, Psapi.h establishes version numbers for the PSAPI functions. The PSAPI
		/// version number affects the name used to call the function and the library that a program must load.
		/// </para>
		/// <para>
		/// If <c>PSAPI_VERSION</c> is 2 or greater, this function is defined as <c>K32GetProcessMemoryInfo</c> in Psapi.h and exported in
		/// Kernel32.lib and Kernel32.dll. If <c>PSAPI_VERSION</c> is 1, this function is defined as <c>GetProcessMemoryInfo</c> in Psapi.h
		/// and exported in Psapi.lib and Psapi.dll as a wrapper that calls <c>K32GetProcessMemoryInfo</c>.
		/// </para>
		/// <para>
		/// Programs that must run on earlier versions of Windows as well as Windows 7 and later versions should always call this function as
		/// <c>GetProcessMemoryInfo</c>. To ensure correct resolution of symbols, add Psapi.lib to the <c>TARGETLIBS</c> macro and compile
		/// the program with <c>-DPSAPI_VERSION=1</c>. To use run-time dynamic linking, load Psapi.dll.
		/// </para>
		/// <para>Examples</para>
		/// <para>For an example, see Collecting Memory Usage Information for a Process.</para>
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows/desktop/api/psapi/nf-psapi-getprocessmemoryinfo BOOL GetProcessMemoryInfo( HANDLE
		// Process, PPROCESS_MEMORY_COUNTERS ppsmemCounters, DWORD cb );
		[DllImport(Lib.Kernel32, SetLastError = true, CharSet = CharSet.Auto)]
		[PInvokeData("psapi.h", MSDNShortId = "12990e8d-6097-4502-824e-db6c3f76c715")]
		[return: MarshalAs(UnmanagedType.Bool)]
		public static extern bool GetProcessMemoryInfo(HPROCESS Process, ref PROCESS_MEMORY_COUNTERS ppsmemCounters, uint cb);

		/// <summary>
		/// <para>
		/// Retrieves information about the pages that have been added to the working set of the specified process since the last time this
		/// function or the InitializeProcessForWsWatch function was called.
		/// </para>
		/// <para>To retrieve extended information, use the GetWsChangesEx function.</para>
		/// </summary>
		/// <param name="hProcess">
		/// <para>
		/// A handle to the process. The handle must have the <c>PROCESS_QUERY_INFORMATION</c> access right. For more information, see
		/// Process Security and Access Rights.
		/// </para>
		/// </param>
		/// <param name="lpWatchInfo">
		/// <para>
		/// A pointer to a user-allocated buffer that receives an array of PSAPI_WS_WATCH_INFORMATION structures. The array is terminated
		/// with a structure whose <c>FaultingPc</c> member is NULL.
		/// </para>
		/// </param>
		/// <param name="cb">
		/// <para>The size of the lpWatchInfo buffer, in bytes.</para>
		/// </param>
		/// <returns>
		/// <para>If the function succeeds, the return value is nonzero.</para>
		/// <para>If the function fails, the return value is zero. To get extended error information, call GetLastError.</para>
		/// <para>
		/// GetLastError returns <c>ERROR_INSUFFICIENT_BUFFER</c> if the lpWatchInfo buffer is not large enough to contain all the working
		/// set change records; the buffer is returned empty. Reallocate a larger block of memory for the buffer and call again.
		/// </para>
		/// </returns>
		/// <remarks>
		/// <para>
		/// The operating system uses one buffer per process to maintain working set change records. If more than one application (or
		/// multiple threads in the same application) calls this function with the same process handle, neither application will have a
		/// complete accounting of the working set changes because each call empties the buffer.
		/// </para>
		/// <para>
		/// The operating system does not record new change records while it is processing the query (and emptying the buffer). The function
		/// sets the error code to <c>NO_MORE_ENTRIES</c> if a concurrent query is received while it is processing another query.
		/// </para>
		/// <para>
		/// If the buffer becomes full, no new records are added to the buffer until this function or the InitializeProcessForWsWatch
		/// function is called. You should call this method with enough frequency to prevent possible data loss. If records are lost, the
		/// array is terminated with a structure whose <c>FaultingPc</c> member is NULL and whose <c>FaultingVa</c> member is set to the
		/// number of records that were lost.
		/// </para>
		/// <para>
		/// <c>Windows Server 2003 and Windows XP:</c> If records are lost, the array is terminated with a structure whose <c>FaultingPc</c>
		/// member is NULL and whose <c>FaultingVa</c> member is 1.
		/// </para>
		/// <para>
		/// Starting with Windows 7 and Windows Server 2008 R2, Psapi.h establishes version numbers for the PSAPI functions. The PSAPI
		/// version number affects the name used to call the function and the library that a program must load.
		/// </para>
		/// <para>
		/// If <c>PSAPI_VERSION</c> is 2 or greater, this function is defined as <c>K32GetWsChanges</c> in Psapi.h and exported in
		/// Kernel32.lib and Kernel32.dll. If <c>PSAPI_VERSION</c> is 1, this function is defined as <c>GetWsChanges</c> in Psapi.h and
		/// exported in Psapi.lib and Psapi.dll as a wrapper that calls <c>K32GetWsChanges</c>.
		/// </para>
		/// <para>
		/// Programs that must run on earlier versions of Windows as well as Windows 7 and later versions should always call this function as
		/// <c>GetWsChanges</c>. To ensure correct resolution of symbols, add Psapi.lib to the <c>TARGETLIBS</c> macro and compile the
		/// program with <c>-DPSAPI_VERSION=1</c>. To use run-time dynamic linking, load Psapi.dll.
		/// </para>
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows/desktop/api/psapi/nf-psapi-getwschanges BOOL GetWsChanges( HANDLE hProcess,
		// PPSAPI_WS_WATCH_INFORMATION lpWatchInfo, DWORD cb );
		[DllImport(Lib.Kernel32, SetLastError = true, ExactSpelling = true)]
		[PInvokeData("psapi.h", MSDNShortId = "ace5106c-9c7b-4d5f-a69a-c3a8bff0bb2d")]
		[return: MarshalAs(UnmanagedType.Bool)]
		public static extern bool GetWsChanges(HPROCESS hProcess, IntPtr lpWatchInfo, uint cb);

		/// <summary>
		/// <para>
		/// Retrieves extended information about the pages that have been added to the working set of the specified process since the last
		/// time this function or the InitializeProcessForWsWatch function was called.
		/// </para>
		/// </summary>
		/// <param name="hProcess">
		/// <para>
		/// A handle to the process. The handle must have the <c>PROCESS_QUERY_INFORMATION</c> access right. For more information, see
		/// Process Security and Access Rights.
		/// </para>
		/// </param>
		/// <param name="lpWatchInfoEx">
		/// <para>
		/// A pointer to a user-allocated buffer that receives an array of PSAPI_WS_WATCH_INFORMATION_EX structures. The array is terminated
		/// with a structure whose <c>FaultingPc</c> member is NULL.
		/// </para>
		/// </param>
		/// <param name="cb">
		/// <para>The size of the lpWatchInfoEx buffer, in bytes.</para>
		/// </param>
		/// <returns>
		/// <para>If the function succeeds, the return value is nonzero.</para>
		/// <para>If the function fails, the return value is zero. To get extended error information, call the GetLastError function.</para>
		/// <para>
		/// The GetLastError function returns <c>ERROR_INSUFFICIENT_BUFFER</c> if the lpWatchInfoEx buffer is not large enough to contain all
		/// the working set change records; the buffer is returned empty. Reallocate a larger block of memory for the buffer and call again.
		/// </para>
		/// </returns>
		/// <remarks>
		/// <para>
		/// The operating system uses one buffer per process to maintain working set change records. If more than one application (or
		/// multiple threads in the same application) calls this function with the same process handle, neither application will have a
		/// complete accounting of the working set changes because each call empties the buffer.
		/// </para>
		/// <para>
		/// The operating system does not record new change records while it is processing the query (and emptying the buffer). This function
		/// sets the error code to <c>NO_MORE_ENTRIES</c> if a concurrent query is received while it is processing another query.
		/// </para>
		/// <para>
		/// If the buffer becomes full, no new records are added to the buffer until this function or the InitializeProcessForWsWatch
		/// function is called. You should call <c>GetWsChangesEx</c> with enough frequency to prevent possible data loss. If records are
		/// lost, the array is terminated with a structure whose <c>FaultingPc</c> member is NULL and whose <c>FaultingVa</c> member is set
		/// to the number of records that were lost.
		/// </para>
		/// <para>
		/// Starting with Windows 7 and Windows Server 2008 R2, Psapi.h establishes version numbers for the PSAPI functions. The PSAPI
		/// version number affects the name used to call the function and the library that a program must load.
		/// </para>
		/// <para>
		/// If <c>PSAPI_VERSION</c> is 2 or greater, this function is defined as <c>K32GetWsChangesEx</c> in Psapi.h and exported in
		/// Kernel32.lib and Kernel32.dll. If <c>PSAPI_VERSION</c> is 1, this function is defined as <c>GetWsChangesEx</c> in Psapi.h and
		/// exported in Psapi.lib and Psapi.dll as a wrapper that calls <c>K32GetWsChangesEx</c>.
		/// </para>
		/// <para>
		/// Programs that must run on earlier versions of Windows as well as Windows 7 and later versions should always call this function as
		/// <c>GetWsChangesEx</c>. To ensure correct resolution of symbols, add Psapi.lib to the <c>TARGETLIBS</c> macro and compile the
		/// program with <c>-DPSAPI_VERSION=1</c>. To use run-time dynamic linking, load Psapi.dll.
		/// </para>
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows/desktop/api/psapi/nf-psapi-getwschangesex BOOL GetWsChangesEx( HANDLE hProcess,
		// PPSAPI_WS_WATCH_INFORMATION_EX lpWatchInfoEx, PDWORD cb );
		[DllImport(Lib.Kernel32, SetLastError = true, CharSet = CharSet.Auto)]
		[PInvokeData("psapi.h", MSDNShortId = "8572db5c-2ffc-424f-8cec-b6a6902fed62")]
		[return: MarshalAs(UnmanagedType.Bool)]
		public static extern bool GetWsChangesEx(HPROCESS hProcess, IntPtr lpWatchInfoEx, ref uint cb);

		/// <summary>
		/// <para>
		/// Initiates monitoring of the working set of the specified process. You must call this function before calling the GetWsChanges function.
		/// </para>
		/// </summary>
		/// <param name="hProcess">
		/// <para>
		/// A handle to the process. The handle must have the PROCESS_QUERY_INFORMATION access right. For more information, see Process
		/// Security and Access Rights.
		/// </para>
		/// </param>
		/// <returns>
		/// <para>If the function succeeds, the return value is nonzero.</para>
		/// <para>If the function fails, the return value is zero. To get extended error information, call GetLastError.</para>
		/// </returns>
		/// <remarks>
		/// <para>
		/// Starting with Windows 7 and Windows Server 2008 R2, Psapi.h establishes version numbers for the PSAPI functions. The PSAPI
		/// version number affects the name used to call the function and the library that a program must load.
		/// </para>
		/// <para>
		/// If <c>PSAPI_VERSION</c> is 2 or greater, this function is defined as <c>K32InitializeProcessForWsWatch</c> in Psapi.h and
		/// exported in Kernel32.lib and Kernel32.dll. If <c>PSAPI_VERSION</c> is 1, this function is defined as
		/// <c>InitializeProcessForWsWatch</c> in Psapi.h and exported in Psapi.lib and Psapi.dll as a wrapper that calls <c>K32InitializeProcessForWsWatch</c>.
		/// </para>
		/// <para>
		/// Programs that must run on earlier versions of Windows as well as Windows 7 and later versions should always call this function as
		/// <c>InitializeProcessForWsWatch</c>. To ensure correct resolution of symbols, add Psapi.lib to the <c>TARGETLIBS</c> macro and
		/// compile the program with <c>-DPSAPI_VERSION=1</c>. To use run-time dynamic linking, load Psapi.dll.
		/// </para>
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows/desktop/api/psapi/nf-psapi-initializeprocessforwswatch BOOL InitializeProcessForWsWatch(
		// HANDLE hProcess );
		[DllImport(Lib.Kernel32, SetLastError = true, CharSet = CharSet.Auto)]
		[PInvokeData("psapi.h", MSDNShortId = "c928656c-a59d-41b5-9434-911329b0278e")]
		[return: MarshalAs(UnmanagedType.Bool)]
		public static extern bool InitializeProcessForWsWatch(HPROCESS hProcess);

		/// <summary>
		/// <para>Retrieves information about the pages currently added to the working set of the specified process.</para>
		/// <para>
		/// To retrieve working set information for a subset of virtual addresses, or to retrieve information about pages that are not part
		/// of the working set (such as AWE or large pages), use the QueryWorkingSetEx function.
		/// </para>
		/// </summary>
		/// <param name="hProcess">
		/// <para>
		/// A handle to the process. The handle must have the <c>PROCESS_QUERY_INFORMATION</c> and <c>PROCESS_VM_READ</c> access rights. For
		/// more information, see Process Security and Access Rights.
		/// </para>
		/// </param>
		/// <param name="pv">
		/// <para>A pointer to the buffer that receives the information. For more information, see PSAPI_WORKING_SET_INFORMATION.</para>
		/// <para>
		/// If the buffer pointed to by the pv parameter is not large enough to contain all working set entries for the target process, the
		/// function fails with <c>ERROR_BAD_LENGTH</c>. In this case, the <c>NumberOfEntries</c> member of the PSAPI_WORKING_SET_INFORMATION
		/// structure is set to the required number of entries, but the function does not return information about the working set entries.
		/// </para>
		/// </param>
		/// <param name="cb">
		/// <para>The size of the pv buffer, in bytes.</para>
		/// </param>
		/// <returns>
		/// <para>If the function succeeds, the return value is nonzero.</para>
		/// <para>If the function fails, the return value is zero. To get extended error information, call GetLastError.</para>
		/// </returns>
		/// <remarks>
		/// <para>
		/// Starting with Windows 7 and Windows Server 2008 R2, Psapi.h establishes version numbers for the PSAPI functions. The PSAPI
		/// version number affects the name used to call the function and the library that a program must load.
		/// </para>
		/// <para>
		/// If <c>PSAPI_VERSION</c> is 2 or greater, this function is defined as <c>K32QueryWorkingSet</c> in Psapi.h and exported in
		/// Kernel32.lib and Kernel32.dll. If <c>PSAPI_VERSION</c> is 1, this function is defined as <c>QueryWorkingSet</c> in Psapi.h and
		/// exported in Psapi.lib and Psapi.dll as a wrapper that calls <c>K32QueryWorkingSet</c>.
		/// </para>
		/// <para>
		/// Programs that must run on earlier versions of Windows as well as Windows 7 and later versions should always call this function as
		/// <c>QueryWorkingSet</c>. To ensure correct resolution of symbols, add Psapi.lib to the <c>TARGETLIBS</c> macro and compile the
		/// program with <c>-DPSAPI_VERSION=1</c>. To use run-time dynamic linking, load Psapi.dll.
		/// </para>
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows/desktop/api/psapi/nf-psapi-queryworkingset BOOL QueryWorkingSet( HANDLE hProcess, PVOID
		// pv, DWORD cb );
		[DllImport(Lib.Kernel32, SetLastError = true, ExactSpelling = true)]
		[PInvokeData("psapi.h", MSDNShortId = "b932153f-2bbd-460e-8ff7-b3e493c397bb")]
		[return: MarshalAs(UnmanagedType.Bool)]
		public static extern bool QueryWorkingSet(HPROCESS hProcess, IntPtr pv, uint cb);

		/// <summary>
		/// <para>Retrieves extended information about the pages at specific virtual addresses in the address space of the specified process.</para>
		/// </summary>
		/// <param name="hProcess">
		/// <para>
		/// A handle to the process. The handle must have the <c>PROCESS_QUERY_INFORMATION</c> and <c>PROCESS_VM_READ</c> access rights. For
		/// more information, see Process Security and Access Rights.
		/// </para>
		/// </param>
		/// <param name="pv">
		/// <para>
		/// A pointer to an array of PSAPI_WORKING_SET_EX_INFORMATION structures. On input, each item in the array specifies a virtual
		/// address of interest. On output, each item in the array receives information about the corresponding virtual page.
		/// </para>
		/// </param>
		/// <param name="cb">
		/// <para>The size of the pv buffer, in bytes.</para>
		/// </param>
		/// <returns>
		/// <para>If the function succeeds, the return value is nonzero.</para>
		/// <para>If the function fails, the return value is zero. To get extended error information, call GetLastError.</para>
		/// </returns>
		/// <remarks>
		/// <para>
		/// Unlike the QueryWorkingSet function, which is limited to the working set of the target process, the <c>QueryWorkingSetEx</c>
		/// function can be used to query addresses that are not in the process working set but are still part of the process, such as AWE
		/// and large pages.
		/// </para>
		/// <para>
		/// Starting with Windows 7 and Windows Server 2008 R2, Psapi.h establishes version numbers for the PSAPI functions. The PSAPI
		/// version number affects the name used to call the function and the library that a program must load.
		/// </para>
		/// <para>
		/// If <c>PSAPI_VERSION</c> is 2 or greater, this function is defined as <c>K32QueryWorkingSetEx</c> in Psapi.h and exported in
		/// Kernel32.lib and Kernel32.dll. If <c>PSAPI_VERSION</c> is 1, this function is defined as <c>QueryWorkingSetEx</c> in Psapi.h and
		/// exported in Psapi.lib and Psapi.dll as a wrapper that calls <c>K32QueryWorkingSetEx</c>.
		/// </para>
		/// <para>
		/// Programs that must run on earlier versions of Windows as well as Windows 7 and later versions should always call this function as
		/// <c>QueryWorkingSetEx</c>. To ensure correct resolution of symbols, add Psapi.lib to the <c>TARGETLIBS</c> macro and compile the
		/// program with "–DPSAPI_VERSION=1". To use run-time dynamic linking, load Psapi.dll.
		/// </para>
		/// <para>Examples</para>
		/// <para>For an example, see Allocating Memory from a NUMA Node.</para>
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows/desktop/api/psapi/nf-psapi-queryworkingsetex BOOL QueryWorkingSetEx( HANDLE hProcess,
		// PVOID pv, DWORD cb );
		[DllImport(Lib.Kernel32, SetLastError = true, ExactSpelling = true)]
		[PInvokeData("psapi.h", MSDNShortId = "59ae76c9-e954-4648-9c9f-787136375b02")]
		[return: MarshalAs(UnmanagedType.Bool)]
		public static extern bool QueryWorkingSetEx(HPROCESS hProcess, IntPtr pv, uint cb);

		/// <summary>
		/// <para>Contains information about a pagefile.</para>
		/// </summary>
		// https://docs.microsoft.com/en-us/windows/desktop/api/psapi/ns-psapi-_enum_page_file_information typedef struct
		// _ENUM_PAGE_FILE_INFORMATION { DWORD cb; DWORD Reserved; SIZE_T TotalSize; SIZE_T TotalInUse; SIZE_T PeakUsage; }
		// ENUM_PAGE_FILE_INFORMATION, *PENUM_PAGE_FILE_INFORMATION;
		[PInvokeData("psapi.h", MSDNShortId = "020f3be8-f624-4788-8079-0f7679c9bef0")]
		[StructLayout(LayoutKind.Sequential, CharSet = CharSet.Auto)]
		public struct ENUM_PAGE_FILE_INFORMATION
		{
			/// <summary>
			/// <para>The size of this structure, in bytes.</para>
			/// </summary>
			public uint cb;

			/// <summary>
			/// <para>This member is reserved.</para>
			/// </summary>
			public uint Reserved;

			/// <summary>
			/// <para>The total size of the pagefile, in pages.</para>
			/// </summary>
			public SizeT TotalSize;

			/// <summary>
			/// <para>The current pagefile usage, in pages.</para>
			/// </summary>
			public SizeT TotalInUse;

			/// <summary>
			/// <para>The peak pagefile usage, in pages.</para>
			/// </summary>
			public SizeT PeakUsage;
		}

		/// <summary>
		/// <para>Contains the module load address, size, and entry point.</para>
		/// </summary>
		/// <remarks>
		/// <para>
		/// The load address of a module is the same as the <c>HMODULE</c> value. The information returned in the <c>SizeOfImage</c> and
		/// <c>EntryPoint</c> members comes from the module's Portable Executable (PE) header. The module entry point is the location called
		/// during process startup, thread startup, process shutdown, and thread shutdown. While this is not the address of the DllMain
		/// function, it should be close enough for most purposes.
		/// </para>
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows/desktop/api/psapi/ns-psapi-_moduleinfo typedef struct _MODULEINFO { LPVOID lpBaseOfDll;
		// DWORD SizeOfImage; LPVOID EntryPoint; } MODULEINFO, *LPMODULEINFO;
		[PInvokeData("psapi.h", MSDNShortId = "583caafe-7fa3-4041-b5bc-4e8899b3a08a")]
		[StructLayout(LayoutKind.Sequential)]
		public struct MODULEINFO
		{
			/// <summary>
			/// <para>The load address of the module.</para>
			/// </summary>
			public IntPtr lpBaseOfDll;

			/// <summary>
			/// <para>The size of the linear space that the module occupies, in bytes.</para>
			/// </summary>
			public uint SizeOfImage;

			/// <summary>
			/// <para>The entry point of the module.</para>
			/// </summary>
			public IntPtr EntryPoint;
		}

		/// <summary>
		/// <para>Contains performance information.</para>
		/// </summary>
		// https://docs.microsoft.com/en-us/windows/desktop/api/psapi/ns-psapi-_performance_information typedef struct
		// _PERFORMANCE_INFORMATION { DWORD cb; SIZE_T CommitTotal; SIZE_T CommitLimit; SIZE_T CommitPeak; SIZE_T PhysicalTotal; SIZE_T
		// PhysicalAvailable; SIZE_T SystemCache; SIZE_T KernelTotal; SIZE_T KernelPaged; SIZE_T KernelNonpaged; SIZE_T PageSize; DWORD
		// HandleCount; DWORD ProcessCount; DWORD ThreadCount; } PERFORMANCE_INFORMATION, *PPERFORMANCE_INFORMATION, PERFORMACE_INFORMATION, *PPERFORMACE_INFORMATION;
		[PInvokeData("psapi.h", MSDNShortId = "efc47f6e-1a60-4e77-9e5d-c725f9042ab8")]
		[StructLayout(LayoutKind.Sequential)]
		public struct PERFORMANCE_INFORMATION
		{
			/// <summary>
			/// <para>The size of this structure, in bytes.</para>
			/// </summary>
			public uint cb;

			/// <summary>
			/// <para>
			/// The number of pages currently committed by the system. Note that committing pages (using VirtualAlloc with MEM_COMMIT)
			/// changes this value immediately; however, the physical memory is not charged until the pages are accessed.
			/// </para>
			/// </summary>
			public SizeT CommitTotal;

			/// <summary>
			/// <para>
			/// The current maximum number of pages that can be committed by the system without extending the paging file(s). This number can
			/// change if memory is added or deleted, or if pagefiles have grown, shrunk, or been added. If the paging file can be extended,
			/// this is a soft limit.
			/// </para>
			/// </summary>
			public SizeT CommitLimit;

			/// <summary>
			/// <para>The maximum number of pages that were simultaneously in the committed state since the last system reboot.</para>
			/// </summary>
			public SizeT CommitPeak;

			/// <summary>
			/// <para>The amount of actual physical memory, in pages.</para>
			/// </summary>
			public SizeT PhysicalTotal;

			/// <summary>
			/// <para>
			/// The amount of physical memory currently available, in pages. This is the amount of physical memory that can be immediately
			/// reused without having to write its contents to disk first. It is the sum of the size of the standby, free, and zero lists.
			/// </para>
			/// </summary>
			public SizeT PhysicalAvailable;

			/// <summary>
			/// <para>The amount of system cache memory, in pages. This is the size of the standby list plus the system working set.</para>
			/// </summary>
			public SizeT SystemCache;

			/// <summary>
			/// <para>The sum of the memory currently in the paged and nonpaged kernel pools, in pages.</para>
			/// </summary>
			public SizeT KernelTotal;

			/// <summary>
			/// <para>The memory currently in the paged kernel pool, in pages.</para>
			/// </summary>
			public SizeT KernelPaged;

			/// <summary>
			/// <para>The memory currently in the nonpaged kernel pool, in pages.</para>
			/// </summary>
			public SizeT KernelNonpaged;

			/// <summary>
			/// <para>The size of a page, in bytes.</para>
			/// </summary>
			public SizeT PageSize;

			/// <summary>
			/// <para>The current number of open handles.</para>
			/// </summary>
			public uint HandleCount;

			/// <summary>
			/// <para>The current number of processes.</para>
			/// </summary>
			public uint ProcessCount;

			/// <summary>
			/// <para>The current number of threads.</para>
			/// </summary>
			public uint ThreadCount;
		}

		/// <summary>
		/// <para>Contains the memory statistics for a process.</para>
		/// </summary>
		// https://docs.microsoft.com/en-us/windows/desktop/api/psapi/ns-psapi-_process_memory_counters typedef struct
		// _PROCESS_MEMORY_COUNTERS { DWORD cb; DWORD PageFaultCount; SIZE_T PeakWorkingSetSize; SIZE_T WorkingSetSize; SIZE_T
		// QuotaPeakPagedPoolUsage; SIZE_T QuotaPagedPoolUsage; SIZE_T QuotaPeakNonPagedPoolUsage; SIZE_T QuotaNonPagedPoolUsage; SIZE_T
		// PagefileUsage; SIZE_T PeakPagefileUsage; } PROCESS_MEMORY_COUNTERS;
		[PInvokeData("psapi.h", MSDNShortId = "288b5865-28a3-478b-ad32-c710fe4f3a81")]
		[StructLayout(LayoutKind.Sequential)]
		public struct PROCESS_MEMORY_COUNTERS
		{
			/// <summary>
			/// <para>The size of the structure, in bytes.</para>
			/// </summary>
			public uint cb;

			/// <summary>
			/// <para>The number of page faults.</para>
			/// </summary>
			public uint PageFaultCount;

			/// <summary>
			/// <para>The peak working set size, in bytes.</para>
			/// </summary>
			public SizeT PeakWorkingSetSize;

			/// <summary>
			/// <para>The current working set size, in bytes.</para>
			/// </summary>
			public SizeT WorkingSetSize;

			/// <summary>
			/// <para>The peak paged pool usage, in bytes.</para>
			/// </summary>
			public SizeT QuotaPeakPagedPoolUsage;

			/// <summary>
			/// <para>The current paged pool usage, in bytes.</para>
			/// </summary>
			public SizeT QuotaPagedPoolUsage;

			/// <summary>
			/// <para>The peak nonpaged pool usage, in bytes.</para>
			/// </summary>
			public SizeT QuotaPeakNonPagedPoolUsage;

			/// <summary>
			/// <para>The current nonpaged pool usage, in bytes.</para>
			/// </summary>
			public SizeT QuotaNonPagedPoolUsage;

			/// <summary>
			/// <para>
			/// The Commit Charge value in bytes for this process. Commit Charge is the total amount of memory that the memory manager has
			/// committed for a running process.
			/// </para>
			/// </summary>
			public SizeT PagefileUsage;

			/// <summary>
			/// <para>The peak value in bytes of the Commit Charge during the lifetime of this process.</para>
			/// </summary>
			public SizeT PeakPagefileUsage;
		}

		/// <summary>
		/// <para>Contains information about a page added to a process working set.</para>
		/// </summary>
		// https://docs.microsoft.com/en-us/windows/desktop/api/psapi/ns-psapi-_psapi_ws_watch_information typedef struct
		// _PSAPI_WS_WATCH_INFORMATION { LPVOID FaultingPc; LPVOID FaultingVa; } PSAPI_WS_WATCH_INFORMATION, *PPSAPI_WS_WATCH_INFORMATION;
		[PInvokeData("psapi.h", MSDNShortId = "61083366-2a55-431c-807a-3eb85ba0b347")]
		[StructLayout(LayoutKind.Sequential)]
		public struct PSAPI_WS_WATCH_INFORMATION
		{
			/// <summary>
			/// <para>A pointer to the instruction that caused the page fault.</para>
			/// </summary>
			public IntPtr FaultingPc;

			/// <summary>
			/// <para>A pointer to the page that was added to the working set.</para>
			/// </summary>
			public IntPtr FaultingVa;
		}

		/// <summary>
		/// <para>Contains extended information about a page added to a process working set.</para>
		/// </summary>
		// https://docs.microsoft.com/en-us/windows/desktop/api/psapi/ns-psapi-_psapi_ws_watch_information_ex typedef struct
		// _PSAPI_WS_WATCH_INFORMATION_EX { PSAPI_WS_WATCH_INFORMATION BasicInfo; ULONG_PTR FaultingThreadId; ULONG_PTR Flags; }
		// PSAPI_WS_WATCH_INFORMATION_EX, *PPSAPI_WS_WATCH_INFORMATION_EX;
		[PInvokeData("psapi.h", MSDNShortId = "fb0429b1-ec93-401c-aeb1-f7e9d9acfa47")]
		[StructLayout(LayoutKind.Sequential)]
		public struct PSAPI_WS_WATCH_INFORMATION_EX
		{
			/// <summary>
			/// <para>A PSAPI_WS_WATCH_INFORMATION structure.</para>
			/// </summary>
			public PSAPI_WS_WATCH_INFORMATION BasicInfo;

			/// <summary>
			/// <para>The identifier of the thread that caused the page fault.</para>
			/// </summary>
			public UIntPtr FaultingThreadId;

			/// <summary>
			/// <para>This member is reserved for future use.</para>
			/// </summary>
			public UIntPtr Flags;
		}
	}
}