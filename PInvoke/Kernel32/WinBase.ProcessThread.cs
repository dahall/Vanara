using System;
using System.Runtime.InteropServices;

namespace Vanara.PInvoke
{
	public static partial class Kernel32
	{
		/// <summary>
		/// An application-defined function used with the <c>CreateFiber</c> function. It serves as the starting address for a fiber. The
		/// <c>LPFIBER_START_ROUTINE</c> type defines a pointer to this callback function. <c>FiberProc</c> is a placeholder for the application-defined function name.
		/// </summary>
		/// <param name="lpParameter">The fiber data passed using the lpParameter parameter of the <c>CreateFiber</c> function.</param>
		/// <returns>This function does not return a value.</returns>
		// VOID CALLBACK FiberProc( _In_ PVOID lpParameter); https://msdn.microsoft.com/en-us/library/windows/desktop/ms682660(v=vs.85).aspx
		[UnmanagedFunctionPointer(CallingConvention.Winapi)]
		[PInvokeData("WinBase.h", MSDNShortId = "ms682660")]
		public delegate void FiberProc(IntPtr lpParameter);

		/// <summary>The thread's execution requirements.</summary>
		public enum EXECUTION_STATE : uint
		{
			/// <summary>
			/// Enables away mode. This value must be specified with ES_CONTINUOUS.
			/// <para>
			/// Away mode should be used only by media-recording and media-distribution applications that must perform critical background processing on desktop
			/// computers while the computer appears to be sleeping. See Remarks.
			/// </para>
			/// </summary>
			ES_AWAYMODE_REQUIRED = 0x00000040,
			/// <summary>
			/// Informs the system that the state being set should remain in effect until the next call that uses ES_CONTINUOUS and one of the other state flags
			/// is cleared.
			/// </summary>
			ES_CONTINUOUS = 0x80000000,
			/// <summary>Forces the display to be on by resetting the display idle timer.</summary>
			ES_DISPLAY_REQUIRED = 0x00000002,
			/// <summary>Forces the system to be in the working state by resetting the system idle timer.</summary>
			ES_SYSTEM_REQUIRED = 0x00000001,
			/// <summary>
			/// This value is not supported. If ES_USER_PRESENT is combined with other esFlags values, the call will fail and none of the specified states will
			/// be set.
			/// </summary>
			ES_USER_PRESENT = 0x00000004,
		}

		/// <summary>Flags used by <see cref="ConvertThreadToFiberEx"/>.</summary>
		[PInvokeData("winbase.h", MSDNShortId = "cb0473f8-bc49-44c9-a8b7-6d5b55aa37a5")]
		public enum FIBER_FLAG
		{
			/// <summary>
			/// The floating-point state on x86 systems is not switched and data can be corrupted if a fiber uses floating-point arithmetic.
			/// </summary>
			FIBER_FLAG_NONE = 0,

			/// <summary>The floating-point state is switched for the fiber.</summary>
			FIBER_FLAG_FLOAT_SWITCH = 1,
		}

		/// <summary>Converts the current fiber into a thread.</summary>
		/// <returns>
		/// <para>If the function succeeds, the return value is nonzero.</para>
		/// <para>If the function fails, the return value is zero. To get extended error information, call <c>GetLastError</c>.</para>
		/// </returns>
		// BOOL WINAPI ConvertFiberToThread(void); https://msdn.microsoft.com/en-us/library/windows/desktop/ms682112(v=vs.85).aspx
		[DllImport(Lib.Kernel32, SetLastError = true, ExactSpelling = true)]
		[PInvokeData("WinBase.h", MSDNShortId = "ms682112")]
		[return: MarshalAs(UnmanagedType.Bool)]
		public static extern bool ConvertFiberToThread();

		/// <summary>Converts the current thread into a fiber. You must convert a thread into a fiber before you can schedule other fibers.</summary>
		/// <param name="lpParameter">
		/// A pointer to a variable that is passed to the fiber. The fiber can retrieve this data by using the <c>GetFiberData</c> macro.
		/// </param>
		/// <returns>
		/// <para>If the function succeeds, the return value is the address of the fiber.</para>
		/// <para>If the function fails, the return value is NULL. To get extended error information, call <c>GetLastError</c>.</para>
		/// </returns>
		// LPVOID WINAPI ConvertThreadToFiber( _In_opt_ LPVOID lpParameter); https://msdn.microsoft.com/en-us/library/windows/desktop/ms682115(v=vs.85).aspx
		[DllImport(Lib.Kernel32, SetLastError = true, ExactSpelling = true)]
		[PInvokeData("WinBase.h", MSDNShortId = "ms682115")]
		public static extern IntPtr ConvertThreadToFiber([In] IntPtr lpParameter);

		/// <summary>
		/// <para>Converts the current thread into a fiber. You must convert a thread into a fiber before you can schedule other fibers.</para>
		/// </summary>
		/// <param name="lpParameter">
		/// <para>A pointer to a variable that is passed to the fiber. The fiber can retrieve this data by using the GetFiberData macro.</para>
		/// </param>
		/// <param name="dwFlags">
		/// <para>
		/// If this parameter is zero, the floating-point state on x86 systems is not switched and data can be corrupted if a fiber uses
		/// floating-point arithmetic. If this parameter is FIBER_FLAG_FLOAT_SWITCH, the floating-point state is switched for the fiber.
		/// </para>
		/// </param>
		/// <returns>
		/// <para>If the function succeeds, the return value is the address of the fiber.</para>
		/// <para>If the function fails, the return value is NULL. To get extended error information, call GetLastError.</para>
		/// </returns>
		/// <remarks>
		/// <para>
		/// Only fibers can execute other fibers. If a thread needs to execute a fiber, it must call ConvertTheadToFiber or
		/// <c>ConvertThreadToFiberEx</c> to create an area in which to save fiber state information. The thread is now the current fiber.
		/// The state information for this fiber includes the fiber data specified by .
		/// </para>
		/// <para>
		/// To compile an application that uses this function, define _WIN32_WINNT as 0x0400 or later. For more information, see Using the
		/// Windows Headers.
		/// </para>
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows/desktop/api/winbase/nf-winbase-convertthreadtofiberex LPVOID ConvertThreadToFiberEx(
		// LPVOID lpParameter, DWORD dwFlags );
		[DllImport(Lib.Kernel32, SetLastError = true, ExactSpelling = true)]
		[PInvokeData("winbase.h", MSDNShortId = "cb0473f8-bc49-44c9-a8b7-6d5b55aa37a5")]
		public static extern IntPtr ConvertThreadToFiberEx(IntPtr lpParameter, FIBER_FLAG dwFlags);

		/// <summary>
		/// Allocates a fiber object, assigns it a stack, and sets up execution to begin at the specified start address, typically the fiber function. This
		/// function does not schedule the fiber.
		/// </summary>
		/// <param name="dwStackSize">
		/// The initial size of the stack, in bytes. If this parameter is zero, the new fiber uses the default stack size for the executable. For more
		/// information, see Thread Stack Size.
		/// </param>
		/// <param name="lpStartAddress">
		/// A pointer to the application-defined function to be executed by the fiber and represents the starting address of the fiber. Execution of the newly
		/// created fiber does not begin until another fiber calls the SwitchToFiber function with this address. For more information of the fiber callback
		/// function, see FiberProc.
		/// </param>
		/// <param name="lpParameter">A pointer to a variable that is passed to the fiber. The fiber can retrieve this data by using the GetFiberData macro.</param>
		/// <returns>
		/// If the function succeeds, the return value is the address of the fiber. If the function fails, the return value is NULL.To get extended error
		/// information, call GetLastError.
		/// </returns>
		// VOID CALLBACK FiberProc( _In_ PVOID lpParameter); https://msdn.microsoft.com/en-us/library/windows/desktop/ms682402(v=vs.85).aspx
		[DllImport(Lib.Kernel32, SetLastError = true, ExactSpelling = true)]
		[PInvokeData("WinBase.h", MSDNShortId = "ms682402")]
		public static extern IntPtr CreateFiber(SizeT dwStackSize, FiberProc lpStartAddress, [In] IntPtr lpParameter);

		/// <summary>
		/// Allocates a fiber object, assigns it a stack, and sets up execution to begin at the specified start address, typically the fiber function. This
		/// function does not schedule the fiber.
		/// </summary>
		/// <param name="dwStackCommitSize">
		/// The initial commit size of the stack, in bytes. If this parameter is zero, the new fiber uses the default commit stack size for the executable. For
		/// more information, see <c>Thread Stack Size</c>.
		/// </param>
		/// <param name="dwStackReserveSize">
		/// The initial reserve size of the stack, in bytes. If this parameter is zero, the new fiber uses the default reserved stack size for the executable.
		/// For more information, see <c>Thread Stack Size</c>.
		/// </param>
		/// <param name="dwFlags">
		/// <para>
		/// If this parameter is zero, the floating-point state on x86 systems is not switched and data can be corrupted if a fiber uses floating-point
		/// arithmetic. If this parameter is <c>FIBER_FLAG_FLOAT_SWITCH</c>, the floating-point state is switched for the fiber.
		/// </para>
		/// <para><c>Windows XP:</c> The <c>FIBER_FLAG_FLOAT_SWITCH</c> flag is not supported.</para>
		/// </param>
		/// <param name="lpStartAddress">
		/// A pointer to the application-defined function to be executed by the fiber and represents the starting address of the fiber. Execution of the newly
		/// created fiber does not begin until another fiber calls the <c>SwitchToFiber</c> function with this address. For more information on the fiber
		/// callback function, see <c>FiberProc</c>.
		/// </param>
		/// <param name="lpParameter">
		/// A pointer to a variable that is passed to the fiber. The fiber can retrieve this data by using the <c>GetFiberData</c> macro.
		/// </param>
		/// <returns>
		/// <para>If the function succeeds, the return value is the address of the fiber.</para>
		/// <para>If the function fails, the return value is NULL. To get extended error information, call <c>GetLastError</c>.</para>
		/// </returns>
		// LPVOID WINAPI CreateFiberEx( _In_ SIZE_T dwStackCommitSize, _In_ SIZE_T dwStackReserveSize, _In_ DWORD dwFlags, _In_ LPFIBER_START_ROUTINE
		// lpStartAddress, _In_opt_ LPVOID lpParameter); https://msdn.microsoft.com/en-us/library/windows/desktop/ms682406(v=vs.85).aspx
		[DllImport(Lib.Kernel32, SetLastError = true, ExactSpelling = true)]
		[PInvokeData("WinBase.h", MSDNShortId = "ms682406")]
		public static extern IntPtr CreateFiberEx(SizeT dwStackCommitSize, SizeT dwStackReserveSize, FIBER_FLAG dwFlags, FiberProc lpStartAddress, [In] IntPtr lpParameter);

		/// <summary>Deletes an existing fiber.</summary>
		/// <param name="lpFiber">The address of the fiber to be deleted.</param>
		/// <returns>This function does not return a value.</returns>
		// VOID WINAPI DeleteFiber( _In_ LPVOID lpFiber); https://msdn.microsoft.com/en-us/library/windows/desktop/ms682556(v=vs.85).aspx
		[DllImport(Lib.Kernel32, SetLastError = false, ExactSpelling = true)]
		[PInvokeData("WinBase.h", MSDNShortId = "ms682556")]
		public static extern void DeleteFiber([In] IntPtr lpFiber);

		/// <summary>Retrieves a pseudo handle for the current process.</summary>
		/// <returns>The return value is a pseudo handle to the current process.</returns>
		// HANDLE WINAPI GetCurrentProcess(void);
		// https://msdn.microsoft.com/en-us/library/windows/desktop/ms683179(v=vs.85).aspx
		[DllImport(Lib.Kernel32, SetLastError = false, ExactSpelling = true)]
		[PInvokeData("WinBase.h", MSDNShortId = "ms683179")]
		public static extern HPROCESS GetCurrentProcess();

		/// <summary>
		/// <para>Retrieves the amount of memory available in the specified node.</para>
		/// <para>Use the <c>GetNumaAvailableMemoryNodeEx</c> function to specify the node as a <c>USHORT</c> value.</para>
		/// </summary>
		/// <param name="Node">The number of the node.</param>
		/// <param name="AvailableBytes">The amount of available memory for the node, in bytes.</param>
		/// <returns>
		/// <para>If the function succeeds, the return value is nonzero.</para>
		/// <para>If the function fails, the return value is zero. To get extended error information, call <c>GetLastError</c>.</para>
		/// </returns>
		// BOOL WINAPI GetNumaAvailableMemoryNode( _In_ UCHAR Node, _Out_ PULONGLONG AvailableBytes); https://msdn.microsoft.com/en-us/library/windows/desktop/ms683202(v=vs.85).aspx
		[DllImport(Lib.Kernel32, SetLastError = true, ExactSpelling = true)]
		[PInvokeData("WinBase.h", MSDNShortId = "ms683202")]
		[return: MarshalAs(UnmanagedType.Bool)]
		public static extern bool GetNumaAvailableMemoryNode(byte Node, out ulong AvailableBytes);

		/// <summary>
		/// <para>Retrieves the processor mask for the specified node.</para>
		/// <para>Use the <c>GetNumaNodeProcessorMaskEx</c> function to retrieve the processor mask for a node in any processor group.</para>
		/// </summary>
		/// <param name="Node">The number of the node.</param>
		/// <param name="ProcessorMask">
		/// <para>The processor mask for the node. A processor mask is a bit vector in which each bit represents a processor and whether it is in the node.</para>
		/// <para>If the node has no processors configured, the processor mask is zero.</para>
		/// <para>
		/// On systems with more than 64 processors, this parameter is set to the processor mask for the node only if the node is in the same processor group as
		/// the calling thread. Otherwise, the parameter is set to zero.
		/// </para>
		/// </param>
		/// <returns>
		/// <para>If the function succeeds, the return value is nonzero.</para>
		/// <para>If the function fails, the return value is zero. To get extended error information, call <c>GetLastError</c>.</para>
		/// </returns>
		// BOOL WINAPI GetNumaNodeProcessorMask( _In_ UCHAR Node, _Out_ PULONGLONG ProcessorMask); https://msdn.microsoft.com/en-us/library/windows/desktop/ms683204(v=vs.85).aspx
		[DllImport(Lib.Kernel32, SetLastError = true, ExactSpelling = true)]
		[PInvokeData("WinBase.h", MSDNShortId = "ms683204")]
		[return: MarshalAs(UnmanagedType.Bool)]
		public static extern bool GetNumaNodeProcessorMask(byte Node, out ulong ProcessorMask);

		/// <summary>
		/// <para>Retrieves the node number for the specified processor.</para>
		/// <para>Use the <c>GetNumaProcessorNodeEx</c> function to specify a processor group and retrieve the node number as a <c>USHORT</c> value.</para>
		/// </summary>
		/// <param name="Processor">
		/// <para>The processor number.</para>
		/// <para>
		/// On a system with more than 64 logical processors, the processor number is relative to the processor group that contains the processor on which the
		/// calling thread is running.
		/// </para>
		/// </param>
		/// <param name="NodeNumber">The node number. If the processor does not exist, this parameter is 0xFF.</param>
		/// <returns>
		/// <para>If the function succeeds, the return value is nonzero.</para>
		/// <para>If the function fails, the return value is zero. To get extended error information, call <c>GetLastError</c>.</para>
		/// </returns>
		// BOOL WINAPI GetNumaProcessorNode( _In_ UCHAR Processor, _Out_ PUCHAR NodeNumber); https://msdn.microsoft.com/en-us/library/windows/desktop/ms683205(v=vs.85).aspx
		[DllImport(Lib.Kernel32, SetLastError = true, ExactSpelling = true)]
		[PInvokeData("WinBase.h", MSDNShortId = "ms683205")]
		[return: MarshalAs(UnmanagedType.Bool)]
		public static extern bool GetNumaProcessorNode(byte Processor, out byte NodeNumber);

		/// <summary>Retrieves the process affinity mask for the specified process and the system affinity mask for the system.</summary>
		/// <param name="hProcess">
		/// <para>A handle to the process whose affinity mask is desired.</para>
		/// <para>
		/// This handle must have the <c>PROCESS_QUERY_INFORMATION</c> or <c>PROCESS_QUERY_LIMITED_INFORMATION</c> access right. For more information, see
		/// Process Security and Access Rights.
		/// </para>
		/// <para><c>Windows Server 2003 and Windows XP:</c> The handle must have the <c>PROCESS_QUERY_INFORMATION</c> access right.</para>
		/// </param>
		/// <param name="lpProcessAffinityMask">A pointer to a variable that receives the affinity mask for the specified process.</param>
		/// <param name="lpSystemAffinityMask">A pointer to a variable that receives the affinity mask for the system.</param>
		/// <returns>
		/// <para>
		/// If the function succeeds, the return value is nonzero and the function sets the variables pointed to by lpProcessAffinityMask and
		/// lpSystemAffinityMask to the appropriate affinity masks.
		/// </para>
		/// <para>
		/// On a system with more than 64 processors, if the threads of the calling process are in a single processor group, the function sets the variables
		/// pointed to by lpProcessAffinityMask and lpSystemAffinityMask to the process affinity mask and the processor mask of active logical processors for
		/// that group. If the calling process contains threads in multiple groups, the function returns zero for both affinity masks.
		/// </para>
		/// <para>
		/// If the function fails, the return value is zero, and the values of the variables pointed to by lpProcessAffinityMask and lpSystemAffinityMask are
		/// undefined. To get extended error information, call <c>GetLastError</c>.
		/// </para>
		/// </returns>
		// BOOL WINAPI GetProcessAffinityMask( _In_ HANDLE hProcess, _Out_ PDWORD_PTR lpProcessAffinityMask, _Out_ PDWORD_PTR lpSystemAffinityMask); https://msdn.microsoft.com/en-us/library/windows/desktop/ms683213(v=vs.85).aspx
		[DllImport(Lib.Kernel32, SetLastError = true, ExactSpelling = true)]
		[PInvokeData("WinBase.h", MSDNShortId = "ms683213")]
		[return: MarshalAs(UnmanagedType.Bool)]
		public static extern bool GetProcessAffinityMask([In] HPROCESS hProcess, out UIntPtr lpProcessAffinityMask, out UIntPtr lpSystemAffinityMask);

		/// <summary>Retrieves accounting information for all I/O operations performed by the specified process.</summary>
		/// <param name="hProcess">
		/// <para>
		/// A handle to the process. The handle must have the <c>PROCESS_QUERY_INFORMATION</c> or <c>PROCESS_QUERY_LIMITED_INFORMATION</c> access right. For more
		/// information, see Process Security and Access Rights.
		/// </para>
		/// <para><c>Windows Server 2003 and Windows XP:</c> The handle must have the <c>PROCESS_QUERY_INFORMATION</c> access right.</para>
		/// </param>
		/// <param name="lpIoCounters">A pointer to an <c>IO_COUNTERS</c> structure that receives the I/O accounting information for the process.</param>
		/// <returns>
		/// <para>If the function succeeds, the return value is nonzero.</para>
		/// <para>If the function fails, the return value is zero. To get extended error information, call <c>GetLastError</c>.</para>
		/// </returns>
		// BOOL WINAPI GetProcessIoCounters( _In_ HANDLE hProcess, _Out_ PIO_COUNTERS lpIoCounters); https://msdn.microsoft.com/en-us/library/windows/desktop/ms683218(v=vs.85).aspx
		[DllImport(Lib.Kernel32, SetLastError = true, ExactSpelling = true)]
		[PInvokeData("WinBase.h", MSDNShortId = "ms683218")]
		[return: MarshalAs(UnmanagedType.Bool)]
		public static extern bool GetProcessIoCounters([In] HPROCESS hProcess, out IO_COUNTERS lpIoCounters);

		/// <summary>Retrieves the minimum and maximum working set sizes of the specified process.</summary>
		/// <param name="hProcess">
		/// <para>
		/// A handle to the process whose working set sizes will be obtained. The handle must have the <c>PROCESS_QUERY_INFORMATION</c> or
		/// <c>PROCESS_QUERY_LIMITED_INFORMATION</c> access right. For more information, see Process Security and Access Rights.
		/// </para>
		/// <para><c>Windows Server 2003 and Windows XP:</c> The handle must have the <c>PROCESS_QUERY_INFORMATION</c> access right.</para>
		/// </param>
		/// <param name="lpMinimumWorkingSetSize">
		/// A pointer to a variable that receives the minimum working set size of the specified process, in bytes. The virtual memory manager attempts to keep at
		/// least this much memory resident in the process whenever the process is active.
		/// </param>
		/// <param name="lpMaximumWorkingSetSize">
		/// A pointer to a variable that receives the maximum working set size of the specified process, in bytes. The virtual memory manager attempts to keep no
		/// more than this much memory resident in the process whenever the process is active when memory is in short supply.
		/// </param>
		/// <returns>
		/// <para>If the function succeeds, the return value is nonzero.</para>
		/// <para>If the function fails, the return value is zero. To get extended error information, call <c>GetLastError</c>.</para>
		/// </returns>
		// BOOL WINAPI GetProcessWorkingSetSize( _In_ HANDLE hProcess, _Out_ PSIZE_T lpMinimumWorkingSetSize, _Out_ PSIZE_T lpMaximumWorkingSetSize);
		[DllImport(Lib.Kernel32, SetLastError = true, ExactSpelling = true)]
		[PInvokeData("WinBase.h", MSDNShortId = "ms683226")]
		[return: MarshalAs(UnmanagedType.Bool)]
		public static extern bool GetProcessWorkingSetSize([In] HPROCESS hProcess, [Out] out SizeT lpMinimumWorkingSetSize, [Out] out SizeT lpMaximumWorkingSetSize);

		/// <summary>Sets a processor affinity mask for the threads of the specified process.</summary>
		/// <param name="hProcess">
		/// A handle to the process whose affinity mask is to be set. This handle must have the <c>PROCESS_SET_INFORMATION</c> access right. For more
		/// information, see Process Security and Access Rights.
		/// </param>
		/// <param name="dwProcessAffinityMask">
		/// <para>The affinity mask for the threads of the process.</para>
		/// <para>On a system with more than 64 processors, the affinity mask must specify processors in a single processor group.</para>
		/// </param>
		/// <returns>
		/// <para>If the function succeeds, the return value is nonzero.</para>
		/// <para>If the function fails, the return value is zero. To get extended error information, call <c>GetLastError</c>.</para>
		/// <para>If the process affinity mask requests a processor that is not configured in the system, the last error code is <c>ERROR_INVALID_PARAMETER</c>.</para>
		/// <para>
		/// On a system with more than 64 processors, if the calling process contains threads in more than one processor group, the last error code is <c>ERROR_INVALID_PARAMETER</c>.
		/// </para>
		/// </returns>
		// BOOL WINAPI SetProcessAffinityMask( _In_ HANDLE hProcess, _In_ DWORD_PTR dwProcessAffinityMask); https://msdn.microsoft.com/en-us/library/windows/desktop/ms686223(v=vs.85).aspx
		[DllImport(Lib.Kernel32, SetLastError = true, ExactSpelling = true)]
		[PInvokeData("WinBase.h", MSDNShortId = "ms686223")]
		[return: MarshalAs(UnmanagedType.Bool)]
		public static extern bool SetProcessAffinityMask([In] HPROCESS hProcess, UIntPtr dwProcessAffinityMask);

		/// <summary>Sets the minimum and maximum working set sizes for the specified process.</summary>
		/// <param name="hProcess">
		/// <para>A handle to the process whose working set sizes is to be set.</para>
		/// <para>The handle must have the <c>PROCESS_SET_QUOTA</c> access right. For more information, see Process Security and Access Rights.</para>
		/// </param>
		/// <param name="dwMinimumWorkingSetSize">
		/// <para>
		/// The minimum working set size for the process, in bytes. The virtual memory manager attempts to keep at least this much memory resident in the process
		/// whenever the process is active.
		/// </para>
		/// <para>
		/// This parameter must be greater than zero but less than or equal to the maximum working set size. The default size is 50 pages (for example, this is
		/// 204,800 bytes on systems with a 4K page size). If the value is greater than zero but less than 20 pages, the minimum value is set to 20 pages.
		/// </para>
		/// <para>
		/// If both dwMinimumWorkingSetSize and dwMaximumWorkingSetSize have the value ( <c>SIZE_T</c>)–1, the function removes as many pages as possible from
		/// the working set of the specified process.
		/// </para>
		/// </param>
		/// <param name="dwMaximumWorkingSetSize">
		/// <para>
		/// The maximum working set size for the process, in bytes. The virtual memory manager attempts to keep no more than this much memory resident in the
		/// process whenever the process is active and available memory is low.
		/// </para>
		/// <para>
		/// This parameter must be greater than or equal to 13 pages (for example, 53,248 on systems with a 4K page size), and less than the system-wide maximum
		/// (number of available pages minus 512 pages). The default size is 345 pages (for example, this is 1,413,120 bytes on systems with a 4K page size).
		/// </para>
		/// <para>
		/// If both dwMinimumWorkingSetSize and dwMaximumWorkingSetSize have the value ( <c>SIZE_T</c>)–1, the function removes as many pages as possible from
		/// the working set of the specified process.
		/// </para>
		/// </param>
		/// <returns>
		/// <para>If the function succeeds, the return value is nonzero.</para>
		/// <para>If the function fails, the return value is zero. Call <c>GetLastError</c> to obtain extended error information.</para>
		/// </returns>
		// BOOL WINAPI SetProcessWorkingSetSize( _In_ HANDLE hProcess, _In_ SIZE_T dwMinimumWorkingSetSize, _In_ SIZE_T dwMaximumWorkingSetSize); https://msdn.microsoft.com/en-us/library/windows/desktop/ms686234(v=vs.85).aspx
		[DllImport(Lib.Kernel32, SetLastError = true, ExactSpelling = true)]
		[PInvokeData("WinBase.h", MSDNShortId = "ms686234")]
		[return: MarshalAs(UnmanagedType.Bool)]
		public static extern bool SetProcessWorkingSetSize([In] HPROCESS hProcess, SizeT dwMinimumWorkingSetSize, SizeT dwMaximumWorkingSetSize);

		/// <summary>Sets a processor affinity mask for the specified thread.</summary>
		/// <param name="hThread">
		/// <para>A handle to the thread whose affinity mask is to be set.</para>
		/// <para>
		/// This handle must have the <c>THREAD_SET_INFORMATION</c> or <c>THREAD_SET_LIMITED_INFORMATION</c> access right and the <c>THREAD_QUERY_INFORMATION</c>
		/// or <c>THREAD_QUERY_LIMITED_INFORMATION</c> access right. For more information, see Thread Security and Access Rights.
		/// </para>
		/// <para>
		/// <c>Windows Server 2003 and Windows XP:</c> The handle must have the <c>THREAD_SET_INFORMATION</c> and <c>THREAD_QUERY_INFORMATION</c> access rights.
		/// </para>
		/// </param>
		/// <param name="dwThreadAffinityMask">
		/// <para>The affinity mask for the thread.</para>
		/// <para>On a system with more than 64 processors, the affinity mask must specify processors in the thread's current processor group.</para>
		/// </param>
		/// <returns>
		/// <para>If the function succeeds, the return value is the thread's previous affinity mask.</para>
		/// <para>If the function fails, the return value is zero. To get extended error information, call <c>GetLastError</c>.</para>
		/// <para>If the thread affinity mask requests a processor that is not selected for the process affinity mask, the last error code is <c>ERROR_INVALID_PARAMETER</c>.</para>
		/// </returns>
		// DWORD_PTR WINAPI SetThreadAffinityMask( _In_ HANDLE hThread, _In_ DWORD_PTR dwThreadAffinityMask); https://msdn.microsoft.com/en-us/library/windows/desktop/ms686247(v=vs.85).aspx
		[DllImport(Lib.Kernel32, SetLastError = true, ExactSpelling = true)]
		[PInvokeData("WinBase.h", MSDNShortId = "ms686247")]
		public static extern UIntPtr SetThreadAffinityMask([In] HTHREAD hThread, UIntPtr dwThreadAffinityMask);

		/// <summary>
		/// Enables an application to inform the system that it is in use, thereby preventing the system from entering sleep or turning off the display while the
		/// application is running.
		/// </summary>
		/// <param name="esFlags">
		/// <para>The thread's execution requirements. This parameter can be one or more of the following values.</para>
		/// <para>
		/// <list type="table">
		/// <listheader>
		/// <term>Value</term>
		/// <term>Meaning</term>
		/// </listheader>
		/// <item>
		/// <term>ES_AWAYMODE_REQUIRED0x00000040</term>
		/// <term>
		/// Enables away mode. This value must be specified with ES_CONTINUOUS.Away mode should be used only by media-recording and media-distribution
		/// applications that must perform critical background processing on desktop computers while the computer appears to be sleeping. See Remarks.
		/// </term>
		/// </item>
		/// <item>
		/// <term>ES_CONTINUOUS0x80000000</term>
		/// <term>
		/// Informs the system that the state being set should remain in effect until the next call that uses ES_CONTINUOUS and one of the other state flags is cleared.
		/// </term>
		/// </item>
		/// <item>
		/// <term>ES_DISPLAY_REQUIRED0x00000002</term>
		/// <term>Forces the display to be on by resetting the display idle timer.</term>
		/// </item>
		/// <item>
		/// <term>ES_SYSTEM_REQUIRED0x00000001</term>
		/// <term>Forces the system to be in the working state by resetting the system idle timer.</term>
		/// </item>
		/// <item>
		/// <term>ES_USER_PRESENT0x00000004</term>
		/// <term>
		/// This value is not supported. If ES_USER_PRESENT is combined with other esFlags values, the call will fail and none of the specified states will be set.
		/// </term>
		/// </item>
		/// </list>
		/// </para>
		/// </param>
		/// <returns>
		/// <para>If the function succeeds, the return value is the previous thread execution state.</para>
		/// <para>If the function fails, the return value is <c>NULL</c>.</para>
		/// </returns>
		// EXECUTION_STATE WINAPI SetThreadExecutionState( _In_ EXECUTION_STATE esFlags); https://msdn.microsoft.com/en-us/library/windows/desktop/aa373208(v=vs.85).aspx
		[DllImport(Lib.Kernel32, SetLastError = false, ExactSpelling = true)]
		[PInvokeData("Winbase.h", MSDNShortId = "aa373208")]
		public static extern EXECUTION_STATE SetThreadExecutionState(EXECUTION_STATE esFlags);

		/// <summary>Schedules a fiber. The function must be called on a fiber.</summary>
		/// <param name="lpFiber">The address of the fiber to be scheduled.</param>
		/// <returns>This function does not return a value.</returns>
		// VOID WINAPI SwitchToFiber( _In_ LPVOID lpFiber); https://msdn.microsoft.com/en-us/library/windows/desktop/ms686350(v=vs.85).aspx
		[DllImport(Lib.Kernel32, SetLastError = false, ExactSpelling = true)]
		[PInvokeData("WinBase.h", MSDNShortId = "ms686350")]
		public static extern void SwitchToFiber([In] IntPtr lpFiber);

		/// <summary>Runs the specified application.</summary>
		/// <param name="lpCmdLine">
		/// The command line (file name plus optional parameters) for the application to be executed. If the name of the executable file in the lpCmdLine
		/// parameter does not contain a directory path, the system searches for the executable file in this sequence:
		/// </param>
		/// <param name="uCmdShow">
		/// The display options. For a list of the acceptable values, see the description of the nCmdShow parameter of the <c>ShowWindow</c> function.
		/// </param>
		/// <returns>
		/// <para>If the function succeeds, the return value is greater than 31.</para>
		/// <para>If the function fails, the return value is one of the following error values.</para>
		/// <para>
		/// <list type="table">
		/// <listheader>
		/// <term>Return code/value</term>
		/// <term>Description</term>
		/// </listheader>
		/// <item>
		/// <term>0</term>
		/// <term>The system is out of memory or resources.</term>
		/// </item>
		/// <item>
		/// <term>ERROR_BAD_FORMAT</term>
		/// <term>The .exe file is invalid.</term>
		/// </item>
		/// <item>
		/// <term>ERROR_FILE_NOT_FOUND</term>
		/// <term>The specified file was not found.</term>
		/// </item>
		/// <item>
		/// <term>ERROR_PATH_NOT_FOUND</term>
		/// <term>The specified path was not found.</term>
		/// </item>
		/// </list>
		/// </para>
		/// </returns>
		// UINT WINAPI WinExec( _In_ LPCSTR lpCmdLine, _In_ UINT uCmdShow); https://msdn.microsoft.com/en-us/library/windows/desktop/ms687393(v=vs.85).aspx
		[DllImport(Lib.Kernel32, SetLastError = false, ExactSpelling = true)]
		[PInvokeData("WinBase.h", MSDNShortId = "ms687393")]
		public static extern uint WinExec([In] [MarshalAs(UnmanagedType.LPStr)] string lpCmdLine, ShowWindowCommand uCmdShow);
	}
}