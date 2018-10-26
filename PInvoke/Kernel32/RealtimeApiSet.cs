using System;
using System.Runtime.InteropServices;

namespace Vanara.PInvoke
{
	public static partial class Kernel32
	{
		/// <summary>
		/// Converts the specified auxiliary counter value to the corresponding performance counter value; optionally provides the estimated conversion error in
		/// nanoseconds due to latencies and maximum possible drift.
		/// </summary>
		/// <param name="ullAuxiliaryCounterValue">The auxiliary counter value to convert.</param>
		/// <param name="lpPerformanceCounterValue">On success, contains the converted performance counter value. Will be undefined if the function fails.</param>
		/// <param name="lpConversionError">On success, contains the estimated conversion error, in nanoseconds. Will be undefined if the function fails.</param>
		/// <returns>
		/// <para>Returns <c>S_OK</c> if the conversion succeeds; otherwise, returns another <c>HRESULT</c> specifying the error.</para>
		/// <para>
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
		/// </para>
		/// </returns>
		// HRESULT WINAPI ConvertAuxiliaryCounterToPerformanceCounter( _In_ ULONGLONG ullAuxiliaryCounterValue, _Out_ PULONGLONG lpPerformanceCounterValue,
		// _Out_opt_ PULONGLONG lpConversionError); https://msdn.microsoft.com/en-us/library/windows/desktop/mt781214(v=vs.85).aspx
		[DllImport(Lib.Kernel32, SetLastError = false, ExactSpelling = true)]
		[PInvokeData("Realtimeapiset.h", MSDNShortId = "mt781214")]
		public static extern HRESULT ConvertAuxiliaryCounterToPerformanceCounter(ulong ullAuxiliaryCounterValue, out ulong lpPerformanceCounterValue, out ulong lpConversionError);

		/// <summary>
		/// Converts the specified performance counter value to the corresponding auxiliary counter value; optionally provides the estimated conversion error in
		/// nanoseconds due to latencies and maximum possible drift.
		/// </summary>
		/// <param name="ullPerformanceCounterValue">The performance counter value to convert.</param>
		/// <param name="lpAuxiliaryCounterValue">On success, contains the converted auxiliary counter value. Will be undefined if the function fails.</param>
		/// <param name="lpConversionError">On success, contains the estimated conversion error, in nanoseconds. Will be undefined if the function fails.</param>
		/// <returns>
		/// <para>Returns <c>S_OK</c> if the conversion succeeds; otherwise, returns another <c>HRESULT</c> specifying the error.</para>
		/// <para>
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
		/// </para>
		/// </returns>
		// HRESULT WINAPI ConvertPerformanceCounterToAuxiliaryCounter( _In_ ULONGLONG ullPerformanceCounterValue, _Out_ PULONGLONG lpAuxiliaryCounterValue,
		// _Out_opt_ PULONGLONG lpConversionError); https://msdn.microsoft.com/en-us/library/windows/desktop/mt781215(v=vs.85).aspx
		[DllImport(Lib.Kernel32, SetLastError = false, ExactSpelling = true)]
		[PInvokeData("Realtimeapiset.h", MSDNShortId = "mt781215")]
		public static extern HRESULT ConvertPerformanceCounterToAuxiliaryCounter(ulong ullPerformanceCounterValue, out ulong lpAuxiliaryCounterValue, out ulong lpConversionError);

		/// <summary>Queries the auxiliary counter frequency.</summary>
		/// <param name="lpAuxiliaryCounterFrequency">
		/// Long pointer to an output buffer that contains the specified auxiliary counter frequency. If the auxiliary counter is not supported, the value in the
		/// output buffer will be undefined.
		/// </param>
		/// <returns>Returns <c>S_OK</c> if the auxiliary counter is supported and <c>E_NOTIMPL</c> if the auxiliary counter is not supported.</returns>
		// HRESULT WINAPI QueryAuxiliaryCounterFrequency( _Out_ PULONGLONG lpAuxiliaryCounterFrequency); https://msdn.microsoft.com/en-us/library/windows/desktop/mt781218(v=vs.85).aspx
		[DllImport(Lib.Kernel32, SetLastError = false, ExactSpelling = true)]
		[PInvokeData("Realtimeapiset.h", MSDNShortId = "mt781218")]
		public static extern HRESULT QueryAuxiliaryCounterFrequency(out ulong lpAuxiliaryCounterFrequency);

		/// <summary>
		/// <para>Retrieves the cycle time for the idle thread of each processor in the system.</para>
		/// <para>
		/// On a system with more than 64 processors, this function retrieves the cycle time for the idle thread of each processor in the processor group to
		/// which the calling thread is assigned. Use the <c>QueryIdleProcessorCycleTimeEx</c> function to retrieve the cycle time for the idle thread on each
		/// logical processor for a specific processor group.
		/// </para>
		/// </summary>
		/// <param name="BufferLength">
		/// <para>
		/// On input, specifies the size of the ProcessorIdleCycleTime buffer, in bytes. This buffer is expected to be 8 times the number of processors in the group.
		/// </para>
		/// <para>
		/// On output, specifies the number of elements written to the buffer. If the buffer size is not sufficient, the function fails and this parameter
		/// receives the required length of the buffer.
		/// </para>
		/// </param>
		/// <param name="ProcessorIdleCycleTime">
		/// The number of CPU clock cycles used by each idle thread. This buffer must be 8 times the number of processors in the system in size.
		/// </param>
		/// <returns>
		/// <para>If the function succeeds, the return value is nonzero.</para>
		/// <para>If the function fails, the return value is zero. To get extended error information, call <c>GetLastError</c>.</para>
		/// </returns>
		// BOOL WINAPI QueryIdleProcessorCycleTime( _Inout_ PULONG BufferLength, _Out_ PULONG64 ProcessorIdleCycleTime); https://msdn.microsoft.com/en-us/library/windows/desktop/ms684922(v=vs.85).aspx
		[DllImport(Lib.Kernel32, SetLastError = true, ExactSpelling = true)]
		[PInvokeData("WinBase.h", MSDNShortId = "ms684922")]
		[return: MarshalAs(UnmanagedType.Bool)]
		public static extern bool QueryIdleProcessorCycleTime(ref uint BufferLength, IntPtr ProcessorIdleCycleTime);

		/// <summary>Retrieves the accumulated cycle time for the idle thread on each logical processor in the specified processor group.</summary>
		/// <param name="Group">The number of the processor group for which to retrieve the cycle time.</param>
		/// <param name="BufferLength">
		/// <para>
		/// On input, specifies the size of the ProcessorIdleCycleTime buffer, in bytes. This buffer is expected to be 8 times the number of processors in the group.
		/// </para>
		/// <para>
		/// On output, specifies the number of elements written to the buffer. If the buffer size is not sufficient, the function fails and this parameter
		/// receives the required length of the buffer.
		/// </para>
		/// </param>
		/// <param name="ProcessorIdleCycleTime">
		/// The number of CPU clock cycles used by each idle thread. If this parameter is NULL, the function updates the BufferLength parameter with the required length.
		/// </param>
		/// <returns>
		/// <para>If the function succeeds, the return value is nonzero.</para>
		/// <para>If the function fails, the return value is zero. To get extended error information, use <c>GetLastError</c>.</para>
		/// </returns>
		// BOOL QueryIdleProcessorCycleTimeEx( _In_ USHORT Group, _Inout_ PULONG BufferLength, _Out_ PULONG64 ProcessorIdleCycleTime); https://msdn.microsoft.com/en-us/library/windows/desktop/dd405507(v=vs.85).aspx
		[DllImport(Lib.Kernel32, SetLastError = true, ExactSpelling = true)]
		[PInvokeData("WinBase.h", MSDNShortId = "dd405507")]
		[return: MarshalAs(UnmanagedType.Bool)]
		public static extern bool QueryIdleProcessorCycleTimeEx(ushort Group, ref uint BufferLength, IntPtr ProcessorIdleCycleTime);

		/// <summary>Gets the current interrupt-time count. For a more precise count, use <c>QueryInterruptTimePrecise</c>.</summary>
		/// <param name="lpInterruptTime">
		/// A pointer to a ULONGLONG in which to receive the interrupt-time count in system time units of 100 nanoseconds. Divide by ten million, or 1e7, to get
		/// seconds (there are 1e9 nanoseconds in a second, so there are 1e7 100-nanoseconds in a second).
		/// </param>
		/// <returns>This function does not return a value.</returns>
		// VOID QueryInterruptTime( _Out_ PULONGLONG lpInterruptTime); https://msdn.microsoft.com/en-us/library/windows/desktop/dn903659(v=vs.85).aspx
		[DllImport(Lib.Kernel32, SetLastError = false, ExactSpelling = true)]
		[PInvokeData("Realtimeapiset.h", MSDNShortId = "dn903659")]
		public static extern void QueryInterruptTime(out ulong lpInterruptTime);

		/// <summary>Gets the current interrupt-time count, in a more precise form than <c>QueryInterruptTime</c> does.</summary>
		/// <param name="lpInterruptTimePrecise">
		/// A pointer to a ULONGLONG in which to receive the interrupt-time count in system time units of 100 nanoseconds. Divide by ten million, or 1e7, to get
		/// seconds (there are 1e9 nanoseconds in a second, so there are 1e7 100-nanoseconds in a second).
		/// </param>
		/// <returns>This function does not return a value.</returns>
		// VOID QueryInterruptTimePrecise( _Out_ PULONGLONG lpInterruptTimePrecise); https://msdn.microsoft.com/en-us/library/windows/desktop/dn903660(v=vs.85).aspx
		[DllImport(Lib.Kernel32, SetLastError = false, ExactSpelling = true)]
		[PInvokeData("Realtimeapiset.h", MSDNShortId = "dn903660")]
		public static extern void QueryInterruptTimePrecise(out ulong lpInterruptTimePrecise);

		/// <summary>Retrieves the sum of the cycle time of all threads of the specified process.</summary>
		/// <param name="ProcessHandle">
		/// A handle to the process. The handle must have the PROCESS_QUERY_INFORMATION or PROCESS_QUERY_LIMITED_INFORMATION access right. For more information,
		/// see Process Security and Access Rights.
		/// </param>
		/// <param name="CycleTime">
		/// The number of CPU clock cycles used by the threads of the process. This value includes cycles spent in both user mode and kernel mode.
		/// </param>
		/// <returns>
		/// <para>If the function succeeds, the return value is nonzero.</para>
		/// <para>If the function fails, the return value is zero. To get extended error information, call <c>GetLastError</c>.</para>
		/// </returns>
		// BOOL WINAPI QueryProcessCycleTime( _In_ HANDLE ProcessHandle, _Out_ PULONG64 CycleTime); https://msdn.microsoft.com/en-us/library/windows/desktop/ms684929(v=vs.85).aspx
		[DllImport(Lib.Kernel32, SetLastError = true, ExactSpelling = true)]
		[PInvokeData("WinBase.h", MSDNShortId = "ms684929")]
		[return: MarshalAs(UnmanagedType.Bool)]
		public static extern bool QueryProcessCycleTime(HPROCESS ProcessHandle, out ulong CycleTime);

		/// <summary>Retrieves the cycle time for the specified thread.</summary>
		/// <param name="ThreadHandle">
		/// A handle to the thread. The handle must have the PROCESS_QUERY_INFORMATION or PROCESS_QUERY_LIMITED_INFORMATION access right. For more information,
		/// see Process Security and Access Rights.
		/// </param>
		/// <param name="CycleTime">The number of CPU clock cycles used by the thread. This value includes cycles spent in both user mode and kernel mode.</param>
		/// <returns>
		/// <para>If the function succeeds, the return value is nonzero.</para>
		/// <para>If the function fails, the return value is zero. To get extended error information, call <c>GetLastError</c>.</para>
		/// </returns>
		// BOOL WINAPI QueryThreadCycleTime( _In_ HANDLE ThreadHandle, _Out_ PULONG64 CycleTime); https://msdn.microsoft.com/en-us/library/windows/desktop/ms684943(v=vs.85).aspx
		[DllImport(Lib.Kernel32, SetLastError = true, ExactSpelling = true)]
		[PInvokeData("WinBase.h", MSDNShortId = "ms684943")]
		[return: MarshalAs(UnmanagedType.Bool)]
		public static extern bool QueryThreadCycleTime(HTHREAD ThreadHandle, out ulong CycleTime);

		/// <summary>
		/// Gets the current unbiased interrupt-time count, in units of 100 nanoseconds. The unbiased interrupt-time count does not include time the system
		/// spends in sleep or hibernation.
		/// </summary>
		/// <param name="lpUnbiasedInterruptTime">
		/// A pointer to a ULONGLONG in which to receive the unbiased interrupt-time count in system time units of 100 nanoseconds. Divide by ten million, or
		/// 1e7, to get seconds (there are 1e9 nanoseconds in a second, so there are 1e7 100-nanoseconds in a second).
		/// </param>
		/// <returns>
		/// If the function succeeds, the return value is nonzero. If the function fails because it is called with a null parameter, the return value is zero.
		/// </returns>
		// BOOL QueryUnbiasedInterruptTime( _Out_ PULONGLONG lpUnbiasedInterruptTime); https://msdn.microsoft.com/en-us/library/windows/desktop/ee662307(v=vs.85).aspx
		[DllImport(Lib.Kernel32, SetLastError = false, ExactSpelling = true)]
		[PInvokeData("Winbase.h", MSDNShortId = "ee662307")]
		[return: MarshalAs(UnmanagedType.Bool)]
		public static extern bool QueryUnbiasedInterruptTime(out ulong lpUnbiasedInterruptTime);

		/// <summary>
		/// Gets the current unbiased interrupt-time count, in a more precise form than <c>QueryUnbiasedInterruptTime</c> does. The unbiased interrupt-time count
		/// does not include time the system spends in sleep or hibernation.
		/// </summary>
		/// <param name="lpUnbiasedInterruptTimePrecise">
		/// A pointer to a ULONGLONG in which to receive the unbiased interrupt-time count in system time units of 100 nanoseconds. Divide by ten million, or
		/// 1e7, to get seconds (there are 1e9 nanoseconds in a second, so there are 1e7 100-nanoseconds in a second).
		/// </param>
		/// <returns>This function does not return a value.</returns>
		// VOID QueryUnbiasedInterruptTimePrecise( _Out_ PULONGLONG lpUnbiasedInterruptTimePrecise); https://msdn.microsoft.com/en-us/library/windows/desktop/dn891448(v=vs.85).aspx
		[DllImport(Lib.Kernel32, SetLastError = false, ExactSpelling = true)]
		[PInvokeData("Realtimeapiset.h", MSDNShortId = "dn891448")]
		public static extern void QueryUnbiasedInterruptTimePrecise(out ulong lpUnbiasedInterruptTimePrecise);
	}
}