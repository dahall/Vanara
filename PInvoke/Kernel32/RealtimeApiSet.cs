namespace Vanara.PInvoke;

public static partial class Kernel32
{
	/// <summary>
	/// Converts the specified auxiliary counter value to the corresponding performance counter value; optionally provides the estimated
	/// conversion error in nanoseconds due to latencies and maximum possible drift.
	/// </summary>
	/// <param name="ullAuxiliaryCounterValue">The auxiliary counter value to convert.</param>
	/// <param name="lpPerformanceCounterValue">
	/// On success, contains the converted performance counter value. Will be undefined if the function fails.
	/// </param>
	/// <param name="lpConversionError">
	/// On success, contains the estimated conversion error, in nanoseconds. Will be undefined if the function fails.
	/// </param>
	/// <returns>
	/// <para>Returns <c>S_OK</c> if the conversion succeeds; otherwise, returns another <c>HRESULT</c> specifying the error.</para>
	/// <list type="table">
	/// <listheader>
	/// <term>Return value</term>
	/// <term>Description</term>
	/// </listheader>
	/// <item>
	/// <term>S_OK</term>
	/// <term>The function succeeded.</term>
	/// </item>
	/// <item>
	/// <term>E_NOTIMPL</term>
	/// <term>The auxiliary counter is not supported.</term>
	/// </item>
	/// <item>
	/// <term>E_BOUNDS</term>
	/// <term>The value to convert is outside the permitted range (+/- 10 seconds from when the called occurred).</term>
	/// </item>
	/// </list>
	/// </returns>
	// https://docs.microsoft.com/en-us/windows/win32/api/realtimeapiset/nf-realtimeapiset-convertauxiliarycountertoperformancecounter
	// HRESULT ConvertAuxiliaryCounterToPerformanceCounter( ULONGLONG ullAuxiliaryCounterValue, PULONGLONG lpPerformanceCounterValue,
	// PULONGLONG lpConversionError );
	[DllImport(Lib.KernelBase, SetLastError = false, ExactSpelling = true)]
	[PInvokeData("realtimeapiset.h", MSDNShortId = "94664D63-D1B0-443B-BB88-C8A8771577A6")]
	public static extern HRESULT ConvertAuxiliaryCounterToPerformanceCounter(ulong ullAuxiliaryCounterValue, out ulong lpPerformanceCounterValue, out ulong lpConversionError);

	/// <summary>
	/// Converts the specified performance counter value to the corresponding auxiliary counter value; optionally provides the estimated
	/// conversion error in nanoseconds due to latencies and maximum possible drift.
	/// </summary>
	/// <param name="ullPerformanceCounterValue">The performance counter value to convert.</param>
	/// <param name="lpAuxiliaryCounterValue">
	/// On success, contains the converted auxiliary counter value. Will be undefined if the function fails.
	/// </param>
	/// <param name="lpConversionError">
	/// On success, contains the estimated conversion error, in nanoseconds. Will be undefined if the function fails.
	/// </param>
	/// <returns>
	/// <para>Returns <c>S_OK</c> if the conversion succeeds; otherwise, returns another <c>HRESULT</c> specifying the error.</para>
	/// <list type="table">
	/// <listheader>
	/// <term>Return value</term>
	/// <term>Description</term>
	/// </listheader>
	/// <item>
	/// <term>S_OK</term>
	/// <term>The function succeeded.</term>
	/// </item>
	/// <item>
	/// <term>E_NOTIMPL</term>
	/// <term>The auxiliary counter is not supported.</term>
	/// </item>
	/// <item>
	/// <term>E_BOUNDS</term>
	/// <term>The value to convert is outside the permitted range (+/- 10 seconds from when the called occurred).</term>
	/// </item>
	/// <item>
	/// <term>E_BOUNDS</term>
	/// <term>The value to convert is prior to the last system boot or S3/S4 transition.</term>
	/// </item>
	/// </list>
	/// </returns>
	// https://docs.microsoft.com/en-us/windows/win32/api/realtimeapiset/nf-realtimeapiset-convertperformancecountertoauxiliarycounter
	// HRESULT ConvertPerformanceCounterToAuxiliaryCounter( ULONGLONG ullPerformanceCounterValue, PULONGLONG lpAuxiliaryCounterValue,
	// PULONGLONG lpConversionError );
	[DllImport(Lib.KernelBase, SetLastError = false, ExactSpelling = true)]
	[PInvokeData("realtimeapiset.h", MSDNShortId = "2499981B-6C13-4A3D-836A-D4CCD11C8D50")]
	public static extern HRESULT ConvertPerformanceCounterToAuxiliaryCounter(ulong ullPerformanceCounterValue, out ulong lpAuxiliaryCounterValue, out ulong lpConversionError);

	/// <summary>Queries the auxiliary counter frequency.</summary>
	/// <param name="lpAuxiliaryCounterFrequency">
	/// Long pointer to an output buffer that contains the specified auxiliary counter frequency. If the auxiliary counter is not
	/// supported, the value in the output buffer will be undefined.
	/// </param>
	/// <returns>Returns <c>S_OK</c> if the auxiliary counter is supported and <c>E_NOTIMPL</c> if the auxiliary counter is not supported.</returns>
	/// <remarks>
	/// <para>You can determine the availability of the auxiliary counter by comparing the returned value against <c>E_NOTIMPL</c>.</para>
	/// <para>Examples</para>
	/// <para>The following sample describes how to call <c>QueryAuxiliaryCounterFrequency</c> to retrieve the counter frequency.</para>
	/// </remarks>
	// https://docs.microsoft.com/en-us/windows/win32/api/realtimeapiset/nf-realtimeapiset-queryauxiliarycounterfrequency HRESULT
	// QueryAuxiliaryCounterFrequency( PULONGLONG lpAuxiliaryCounterFrequency );
	[DllImport(Lib.KernelBase, SetLastError = false, ExactSpelling = true)]
	[PInvokeData("realtimeapiset.h", MSDNShortId = "71E00DF2-7F67-43D2-9D6D-BFE9FEA4B30A")]
	public static extern HRESULT QueryAuxiliaryCounterFrequency(out ulong lpAuxiliaryCounterFrequency);

	/// <summary>
	/// <para>Retrieves the cycle time for the idle thread of each processor in the system.</para>
	/// <para>
	/// On a system with more than 64 processors, this function retrieves the cycle time for the idle thread of each processor in the
	/// processor group to which the calling thread is assigned. Use the QueryIdleProcessorCycleTimeEx function to retrieve the cycle
	/// time for the idle thread on each logical processor for a specific processor group.
	/// </para>
	/// </summary>
	/// <param name="BufferLength">
	/// <para>
	/// On input, specifies the size of the ProcessorIdleCycleTime buffer, in bytes. This buffer is expected to be 8 times the number of
	/// processors in the group.
	/// </para>
	/// <para>
	/// On output, specifies the number of elements written to the buffer. If the buffer size is not sufficient, the function fails and
	/// this parameter receives the required length of the buffer.
	/// </para>
	/// </param>
	/// <param name="ProcessorIdleCycleTime">
	/// The number of CPU clock cycles used by each idle thread. This buffer must be 8 times the number of processors in the system in size.
	/// </param>
	/// <returns>
	/// <para>If the function succeeds, the return value is nonzero.</para>
	/// <para>If the function fails, the return value is zero. To get extended error information, call GetLastError.</para>
	/// </returns>
	/// <remarks>To compile an application that uses this function, define _WIN32_WINNT as 0x0600 or later.</remarks>
	// https://docs.microsoft.com/en-us/windows/win32/api/realtimeapiset/nf-realtimeapiset-queryidleprocessorcycletime BOOL
	// QueryIdleProcessorCycleTime( PULONG BufferLength, PULONG64 ProcessorIdleCycleTime );
	[DllImport(Lib.KernelBase, SetLastError = true, ExactSpelling = true)]
	[PInvokeData("realtimeapiset.h", MSDNShortId = "75a5c4cf-ccc7-47ab-a2a9-88051e0a7d06")]
	[return: MarshalAs(UnmanagedType.Bool)]
	public static extern bool QueryIdleProcessorCycleTime(ref uint BufferLength, ulong[] ProcessorIdleCycleTime);

	/// <summary>
	/// <para>Retrieves the cycle time for the idle thread of each processor in the system.</para>
	/// <para>
	/// On a system with more than 64 processors, this function retrieves the cycle time for the idle thread of each processor in the
	/// processor group to which the calling thread is assigned. Use the QueryIdleProcessorCycleTimeEx function to retrieve the cycle
	/// time for the idle thread on each logical processor for a specific processor group.
	/// </para>
	/// </summary>
	/// <returns>The number of CPU clock cycles used by each idle thread.</returns>
	[PInvokeData("realtimeapiset.h", MSDNShortId = "75a5c4cf-ccc7-47ab-a2a9-88051e0a7d06")]
	public static ulong[] QueryIdleProcessorCycleTime()
	{
		var ct = new ulong[Environment.ProcessorCount];
		var sz = (uint)ct.Length * sizeof(ulong);
		if (!QueryIdleProcessorCycleTime(ref sz, ct))
			Win32Error.ThrowLastError();
		return ct;
	}

	/// <summary>Retrieves the accumulated cycle time for the idle thread on each logical processor in the specified processor group.</summary>
	/// <param name="Group">The number of the processor group for which to retrieve the cycle time.</param>
	/// <param name="BufferLength">
	/// <para>
	/// On input, specifies the size of the ProcessorIdleCycleTime buffer, in bytes. This buffer is expected to be 8 times the number of
	/// processors in the group.
	/// </para>
	/// <para>
	/// On output, specifies the number of elements written to the buffer. If the buffer size is not sufficient, the function fails and
	/// this parameter receives the required length of the buffer.
	/// </para>
	/// </param>
	/// <param name="ProcessorIdleCycleTime">
	/// The number of CPU clock cycles used by each idle thread. If this parameter is NULL, the function updates the BufferLength
	/// parameter with the required length.
	/// </param>
	/// <returns>
	/// <para>If the function succeeds, the return value is nonzero.</para>
	/// <para>If the function fails, the return value is zero. To get extended error information, use GetLastError.</para>
	/// </returns>
	/// <remarks>
	/// To compile an application that uses this function, set _WIN32_WINNT &gt;= 0x0601. For more information, see Using the Windows Headers.
	/// </remarks>
	// https://docs.microsoft.com/en-us/windows/win32/api/realtimeapiset/nf-realtimeapiset-queryidleprocessorcycletimeex BOOL
	// QueryIdleProcessorCycleTimeEx( USHORT Group, PULONG BufferLength, PULONG64 ProcessorIdleCycleTime );
	[DllImport(Lib.KernelBase, SetLastError = true, ExactSpelling = true)]
	[PInvokeData("realtimeapiset.h", MSDNShortId = "4bf05e40-96d1-4c01-b3a8-8a45934b38c6")]
	[return: MarshalAs(UnmanagedType.Bool)]
	public static extern bool QueryIdleProcessorCycleTimeEx(ushort Group, ref uint BufferLength, ulong[] ProcessorIdleCycleTime);

	/// <summary>Retrieves the accumulated cycle time for the idle thread on each logical processor in the specified processor group.</summary>
	/// <param name="Group">The number of the processor group for which to retrieve the cycle time.</param>
	/// <returns>The number of CPU clock cycles used by each idle thread.</returns>
	[PInvokeData("realtimeapiset.h", MSDNShortId = "4bf05e40-96d1-4c01-b3a8-8a45934b38c6")]
	public static ulong[] QueryIdleProcessorCycleTimeEx(ushort Group)
	{
		var ct = new ulong[Environment.ProcessorCount];
		var sz = (uint)ct.Length * sizeof(ulong);
		if (!QueryIdleProcessorCycleTimeEx(Group, ref sz, ct))
			Win32Error.ThrowLastError();
		return ct;
	}

	/// <summary>Gets the current interrupt-time count. For a more precise count, use QueryInterruptTimePrecise.</summary>
	/// <param name="lpInterruptTime">
	/// A pointer to a ULONGLONG in which to receive the interrupt-time count in system time units of 100 nanoseconds. Divide by ten
	/// million, or 1e7, to get seconds (there are 1e9 nanoseconds in a second, so there are 1e7 100-nanoseconds in a second).
	/// </param>
	/// <returns>This function does not return a value.</returns>
	/// <remarks>
	/// <para>
	/// The interrupt-time count begins at zero when the system starts and is incremented at each clock interrupt by the length of a
	/// clock tick. The exact length of a clock tick depends on underlying hardware and can vary between systems.
	/// </para>
	/// <para>
	/// Unlike system time, the interrupt-time count is not subject to adjustments by users or the Windows time service. Applications can
	/// use the interrupt-time count to measure finer durations than are possible with system time. Applications that require greater
	/// precision than the interrupt-time count should use a high-resolution timer. Use the QueryPerformanceFrequency function to
	/// retrieve the frequency of the high-resolution timer and the QueryPerformanceCounter function to retrieve the counter's value.
	/// </para>
	/// <para>
	/// The timer resolution set by the timeBeginPeriod and timeEndPeriod functions affects the resolution of the
	/// <c>QueryInterruptTime</c> function. However, increasing the timer resolution is not recommended because it can reduce overall
	/// system performance and increase system power consumption by preventing the processor from entering power-saving states. Instead,
	/// applications should use a high-resolution timer.
	/// </para>
	/// <para>
	/// <c>Note</c> The <c>QueryInterruptTime</c> function produces different results on debug ("checked") builds of Windows, because the
	/// interrupt-time count and tick count are advanced by approximately 49 days. This helps to identify bugs that might not occur until
	/// the system has been running for a long time. The checked build is available to MSDN subscribers through the Microsoft Developer
	/// Network (MSDN) Web site.
	/// </para>
	/// <para>
	/// To compile an application that uses this function, define _WIN32_WINNT as 0x0601 or later. For more information, see Using the
	/// Windows Headers.
	/// </para>
	/// </remarks>
	// https://docs.microsoft.com/en-us/windows/win32/api/realtimeapiset/nf-realtimeapiset-queryinterrupttime void QueryInterruptTime(
	// PULONGLONG lpInterruptTime );
	[DllImport(Lib.KernelBase, SetLastError = false, ExactSpelling = true)]
	[PInvokeData("realtimeapiset.h", MSDNShortId = "FB2B179B-5E44-4201-86E2-DB386607FD90")]
	public static extern void QueryInterruptTime(out ulong lpInterruptTime);

	/// <summary>Gets the current interrupt-time count, in a more precise form than QueryInterruptTime does.</summary>
	/// <param name="lpInterruptTimePrecise">
	/// A pointer to a ULONGLONG in which to receive the interrupt-time count in system time units of 100 nanoseconds. Divide by ten
	/// million, or 1e7, to get seconds (there are 1e9 nanoseconds in a second, so there are 1e7 100-nanoseconds in a second).
	/// </param>
	/// <returns>This function does not return a value.</returns>
	/// <remarks>
	/// <para>
	/// <c>QueryInterruptTimePrecise</c> is similar to the QueryInterruptTime routine, but is more precise. The interrupt time reported
	/// by <c>QueryInterruptTime</c> is based on the latest tick of the system clock timer. The system clock timer is the hardware timer
	/// that periodically generates interrupts for the system clock. The uniform period between system clock timer interrupts is referred
	/// to as a system clock tick, and is typically in the range of 0.5 milliseconds to 15.625 milliseconds, depending on the hardware
	/// platform. The interrupt time value retrieved by <c>QueryInterruptTime</c> is accurate within a system clock tick.
	/// </para>
	/// <para>
	/// To provide a system time value that is more precise than that of QueryInterruptTime, <c>QueryInterruptTimePrecise</c> reads the
	/// timer hardware directly, therefore a <c>QueryInterruptTimePrecise</c> call can be slower than a <c>QueryInterruptTime</c> call.
	/// </para>
	/// <para>Call the KeQueryTimeIncrement routine to determine the duration of a system clock tick.</para>
	/// <para>Also see Remarks in QueryInterruptTime.</para>
	/// <para>
	/// <c>Note</c> The <c>QueryInterruptTimePrecise</c> function produces different results on debug ("checked") builds of Windows,
	/// because the interrupt-time count and tick count are advanced by approximately 49 days. This helps to identify bugs that might not
	/// occur until the system has been running for a long time. The checked build is available to MSDN subscribers through the Microsoft
	/// Developer Network (MSDN) Web site.
	/// </para>
	/// <para>
	/// To compile an application that uses this function, define _WIN32_WINNT as 0x0601 or later. For more information, see Using the
	/// Windows Headers.
	/// </para>
	/// </remarks>
	// https://docs.microsoft.com/en-us/windows/win32/api/realtimeapiset/nf-realtimeapiset-queryinterrupttimeprecise void
	// QueryInterruptTimePrecise( PULONGLONG lpInterruptTimePrecise );
	[DllImport(Lib.KernelBase, SetLastError = false, ExactSpelling = true)]
	[PInvokeData("realtimeapiset.h", MSDNShortId = "0F65A707-0899-4F79-B7CD-16C9143C4173")]
	public static extern void QueryInterruptTimePrecise(out ulong lpInterruptTimePrecise);

	/// <summary>Retrieves the sum of the cycle time of all threads of the specified process.</summary>
	/// <param name="ProcessHandle">
	/// A handle to the process. The handle must have the PROCESS_QUERY_INFORMATION or PROCESS_QUERY_LIMITED_INFORMATION access right.
	/// For more information, see Process Security and Access Rights.
	/// </param>
	/// <param name="CycleTime">
	/// The number of CPU clock cycles used by the threads of the process. This value includes cycles spent in both user mode and kernel mode.
	/// </param>
	/// <returns>
	/// <para>If the function succeeds, the return value is nonzero.</para>
	/// <para>If the function fails, the return value is zero. To get extended error information, call GetLastError.</para>
	/// </returns>
	/// <remarks>
	/// <para>To enumerate the processes in the system, use the EnumProcesses function.</para>
	/// <para>To compile an application that uses this function, define _WIN32_WINNT as 0x0600 or later.</para>
	/// </remarks>
	// https://docs.microsoft.com/en-us/windows/win32/api/realtimeapiset/nf-realtimeapiset-queryprocesscycletime BOOL
	// QueryProcessCycleTime( HANDLE ProcessHandle, PULONG64 CycleTime );
	[DllImport(Lib.KernelBase, SetLastError = true, ExactSpelling = true)]
	[PInvokeData("realtimeapiset.h", MSDNShortId = "1859bc0f-8065-4104-b421-1b4c020ad5ea")]
	[return: MarshalAs(UnmanagedType.Bool)]
	public static extern bool QueryProcessCycleTime([In, AddAsMember] HPROCESS ProcessHandle, out ulong CycleTime);

	/// <summary>Retrieves the cycle time for the specified thread.</summary>
	/// <param name="ThreadHandle">
	/// A handle to the thread. The handle must have the PROCESS_QUERY_INFORMATION or PROCESS_QUERY_LIMITED_INFORMATION access right. For
	/// more information, see Process Security and Access Rights.
	/// </param>
	/// <param name="CycleTime">
	/// The number of CPU clock cycles used by the thread. This value includes cycles spent in both user mode and kernel mode.
	/// </param>
	/// <returns>
	/// <para>If the function succeeds, the return value is nonzero.</para>
	/// <para>If the function fails, the return value is zero. To get extended error information, call GetLastError.</para>
	/// </returns>
	/// <remarks>
	/// <para>
	/// To enumerate the threads of the process, use the Thread32First and Thread32Next functions. To get the thread handle for a thread
	/// identifier, use the OpenThread function.
	/// </para>
	/// <para>
	/// Do not attempt to convert the CPU clock cycles returned by <c>QueryThreadCycleTime</c> to elapsed time. This function uses timer
	/// services provided by the CPU, which can vary in implementation. For example, some CPUs will vary the frequency of the timer when
	/// changing the frequency at which the CPU runs and others will leave it at a fixed rate. The behavior of each CPU is described in
	/// the documentation provided by the CPU vendor.
	/// </para>
	/// <para>To compile an application that uses this function, define _WIN32_WINNT as 0x0600 or later.</para>
	/// </remarks>
	// https://docs.microsoft.com/en-us/windows/win32/api/realtimeapiset/nf-realtimeapiset-querythreadcycletime BOOL
	// QueryThreadCycleTime( HANDLE ThreadHandle, PULONG64 CycleTime );
	[DllImport(Lib.KernelBase, SetLastError = true, ExactSpelling = true)]
	[PInvokeData("realtimeapiset.h", MSDNShortId = "5828b073-48af-4118-9206-096b87c978e7")]
	[return: MarshalAs(UnmanagedType.Bool)]
	public static extern bool QueryThreadCycleTime([In, AddAsMember] HTHREAD ThreadHandle, out ulong CycleTime);

	/// <summary>
	/// Gets the current unbiased interrupt-time count, in units of 100 nanoseconds. The unbiased interrupt-time count does not include
	/// time the system spends in sleep or hibernation.
	/// </summary>
	/// <param name="UnbiasedTime">TBD</param>
	/// <returns>
	/// If the function succeeds, the return value is nonzero. If the function fails because it is called with a null parameter, the
	/// return value is zero.
	/// </returns>
	/// <remarks>
	/// <para>
	/// The interrupt-time count begins at zero when the system starts and is incremented at each clock interrupt by the length of a
	/// clock tick. The exact length of a clock tick depends on underlying hardware and can vary between systems.
	/// </para>
	/// <para>
	/// The interrupt-time count retrieved by the <c>QueryUnbiasedInterruptTime</c> function reflects only the time that the system is in
	/// the working state. Therefore, the interrupt-time count is not "biased" by time the system spends in sleep or hibernation. The
	/// system uses biased interrupt time for some operations, such as ensuring that relative timers that would have expired during sleep
	/// expire immediately upon waking.
	/// </para>
	/// <para>
	/// Unlike system time, the interrupt-time count is not subject to adjustments by users or the Windows time service. Applications can
	/// use the interrupt-time count to measure finer durations than are possible with system time. Applications that require greater
	/// precision than the interrupt-time count should use a high-resolution timer. Use the QueryPerformanceFrequency function to
	/// retrieve the frequency of the high-resolution timer and the QueryPerformanceCounter function to retrieve the counter's value.
	/// </para>
	/// <para>
	/// The timer resolution set by the timeBeginPeriod and timeEndPeriod functions affects the resolution of the
	/// <c>QueryUnbiasedInterruptTime</c> function. However, increasing the timer resolution is not recommended because it can reduce
	/// overall system performance and increase system power consumption by preventing the processor from entering power-saving states.
	/// Instead, applications should use a high-resolution timer.
	/// </para>
	/// <para>
	/// <c>Note</c> The <c>QueryUnbiasedInterruptTime</c> function produces different results on debug ("checked") builds of Windows,
	/// because the interrupt-time count and tick count are advanced by approximately 49 days. This helps to identify bugs that might not
	/// occur until the system has been running for a long time. The checked build is available to MSDN subscribers through the Microsoft
	/// Developer Network (MSDN) Web site.
	/// </para>
	/// <para>
	/// To compile an application that uses this function, define _WIN32_WINNT as 0x0601 or later. For more information, see Using the
	/// Windows Headers.
	/// </para>
	/// </remarks>
	// https://docs.microsoft.com/en-us/windows/win32/api/realtimeapiset/nf-realtimeapiset-queryunbiasedinterrupttime BOOL
	// QueryUnbiasedInterruptTime( PULONGLONG UnbiasedTime );
	[DllImport(Lib.KernelBase, SetLastError = false, ExactSpelling = true)]
	[PInvokeData("realtimeapiset.h", MSDNShortId = "f9cf5440-9be9-4ff9-b85c-2779b847954c")]
	[return: MarshalAs(UnmanagedType.Bool)]
	public static extern bool QueryUnbiasedInterruptTime(out ulong UnbiasedTime);

	/// <summary>
	/// Gets the current unbiased interrupt-time count, in a more precise form than QueryUnbiasedInterruptTime does. The unbiased
	/// interrupt-time count does not include time the system spends in sleep or hibernation.
	/// </summary>
	/// <param name="lpUnbiasedInterruptTimePrecise">
	/// A pointer to a ULONGLONG in which to receive the unbiased interrupt-time count in system time units of 100 nanoseconds. Divide by
	/// ten million, or 1e7, to get seconds (there are 1e9 nanoseconds in a second, so there are 1e7 100-nanoseconds in a second).
	/// </param>
	/// <returns>This function does not return a value.</returns>
	/// <remarks>
	/// <para>
	/// <c>QueryUnbiasedInterruptTimePrecise</c> is similar to the QueryUnbiasedInterruptTime routine, but is more precise. The interrupt
	/// time reported by <c>QueryUnbiasedInterruptTime</c> is based on the latest tick of the system clock timer. The system clock timer
	/// is the hardware timer that periodically generates interrupts for the system clock. The uniform period between system clock timer
	/// interrupts is referred to as a system clock tick, and is typically in the range of 0.5 milliseconds to 15.625 milliseconds,
	/// depending on the hardware platform. The interrupt time value retrieved by <c>QueryUnbiasedInterruptTime</c> is accurate within a
	/// system clock tick.
	/// </para>
	/// <para>
	/// To provide a system time value that is more precise than that of QueryUnbiasedInterruptTime,
	/// <c>QueryUnbiasedInterruptTimePrecise</c> reads the timer hardware directly, therefore a <c>QueryUnbiasedInterruptTimePrecise</c>
	/// call can be slower than a <c>QueryUnbiasedInterruptTime</c> call.
	/// </para>
	/// <para>Call the KeQueryTimeIncrement routine to determine the duration of a system clock tick.</para>
	/// <para>Also see Remarks in QueryUnbiasedInterruptTime.</para>
	/// <para>
	/// <c>Note</c> The <c>QueryUnbiasedInterruptTimePrecise</c> function produces different results on debug ("checked") builds of
	/// Windows, because the interrupt-time count and tick count are advanced by approximately 49 days. This helps to identify bugs that
	/// might not occur until the system has been running for a long time. The checked build is available to MSDN subscribers through the
	/// Microsoft Developer Network (MSDN) Web site.
	/// </para>
	/// <para>
	/// To compile an application that uses this function, define _WIN32_WINNT as 0x0601 or later. For more information, see Using the
	/// Windows Headers.
	/// </para>
	/// </remarks>
	// https://docs.microsoft.com/en-us/windows/win32/api/realtimeapiset/nf-realtimeapiset-queryunbiasedinterrupttimeprecise void
	// QueryUnbiasedInterruptTimePrecise( PULONGLONG lpUnbiasedInterruptTimePrecise );
	[DllImport(Lib.KernelBase, SetLastError = false, ExactSpelling = true)]
	[PInvokeData("realtimeapiset.h", MSDNShortId = "FADFC168-A3CF-4676-9B6E-7A4028049423")]
	public static extern void QueryUnbiasedInterruptTimePrecise(out ulong lpUnbiasedInterruptTimePrecise);
}