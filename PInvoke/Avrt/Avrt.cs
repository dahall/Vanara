using System;
using System.Runtime.InteropServices;

namespace Vanara.PInvoke;

/// <summary>Functions from Avrt.dll.</summary>
public static partial class Avrt
{
	private const string Lib_Avrt = "Avrt.dll";

	/// <summary>The relative thread priority of this thread to other threads performing a similar task.</summary>
	[PInvokeData("avrt.h", MSDNShortId = "NF:avrt.AvSetMmThreadPriority")]
	public enum AVRT_PRIORITY
	{
		/// <summary>very low</summary>
		AVRT_PRIORITY_VERYLOW = -2,

		/// <summary>low</summary>
		AVRT_PRIORITY_LOW,

		/// <summary>normal</summary>
		AVRT_PRIORITY_NORMAL,

		/// <summary>high</summary>
		AVRT_PRIORITY_HIGH,

		/// <summary>critical</summary>
		AVRT_PRIORITY_CRITICAL
	}

	/// <summary>Retrieves the system responsiveness setting used by the multimedia class scheduler service.</summary>
	/// <param name="AvrtHandle">
	/// A handle to the task. This handle is returned by the AvSetMmThreadCharacteristics or AvSetMmMaxThreadCharacteristics function.
	/// </param>
	/// <param name="SystemResponsivenessValue">The system responsiveness value. This value can range from 10 to 100 percent.</param>
	/// <returns>
	/// <para>If the function succeeds, the return value is nonzero.</para>
	/// <para>If the function fails, the return value is zero. To get extended error information, call GetLastError.</para>
	/// </returns>
	// https://learn.microsoft.com/en-us/windows/win32/api/avrt/nf-avrt-avquerysystemresponsiveness AVRTAPI BOOL AvQuerySystemResponsiveness(
	// [in] HAVRT AvrtHandle, [out] PULONG SystemResponsivenessValue );
	[PInvokeData("avrt.h", MSDNShortId = "NF:avrt.AvQuerySystemResponsiveness")]
	[DllImport(Lib_Avrt, SetLastError = true, ExactSpelling = true)]
	[return: MarshalAs(UnmanagedType.Bool)]
	public static extern bool AvQuerySystemResponsiveness([In] HAVRT AvrtHandle, out uint SystemResponsivenessValue);

	/// <summary>Indicates that a thread is no longer performing work associated with the specified task.</summary>
	/// <param name="AvrtHandle">
	/// A handle to the task. This handle is returned by the AvSetMmThreadCharacteristics or AvSetMmMaxThreadCharacteristics function.
	/// </param>
	/// <returns>
	/// <para>If the function succeeds, the return value is nonzero.</para>
	/// <para>If the function fails, the return value is zero. To get extended error information, call GetLastError.</para>
	/// </returns>
	/// <remarks>
	/// This function must be called from the same thread that called the AvSetMmThreadCharacteristics or AvSetMmMaxThreadCharacteristics
	/// function to create the handle. Otherwise, the function will fail.
	/// </remarks>
	// https://learn.microsoft.com/en-us/windows/win32/api/avrt/nf-avrt-avrevertmmthreadcharacteristics AVRTAPI BOOL
	// AvRevertMmThreadCharacteristics( [in] HAVRT AvrtHandle );
	[PInvokeData("avrt.h", MSDNShortId = "NF:avrt.AvRevertMmThreadCharacteristics")]
	[DllImport(Lib_Avrt, SetLastError = true, ExactSpelling = true)]
	[return: MarshalAs(UnmanagedType.Bool)]
	public static extern bool AvRevertMmThreadCharacteristics([In] HAVRT AvrtHandle);

	/// <summary>
	/// <para>Creates a thread ordering group.</para>
	/// <para>
	/// To prevent the server thread for the thread ordering group from being starved if higher priority client threads are running, use the
	/// AvRtCreateThreadOrderingGroupEx function.
	/// </para>
	/// </summary>
	/// <param name="Context">A pointer to a context handle.</param>
	/// <param name="Period">
	/// <para>
	/// A pointer to a value, in 100-nanosecond increments, that specifies the period for the thread ordering group. Each thread in the
	/// thread ordering group runs one time during this period. If all threads complete their execution before a period ends, all threads
	/// wait until the remainder of the period elapses before any are executed again.
	/// </para>
	/// <para>
	/// The possible values for this parameter depend on the platform, but this parameter can be as low as 500 microseconds or as high as
	/// 0x1FFFFFFFFFFFFFFF. If this parameter is less than 500 microseconds, then it is set to 500 microseconds. If this parameter is greater
	/// than the maximum, then it is set to 0x1FFFFFFFFFFFFFFF.
	/// </para>
	/// </param>
	/// <param name="ThreadOrderingGuid">
	/// <para>
	/// A pointer to the unique identifier for the thread ordering group to be created. If this value is not unique to the thread ordering
	/// service, the function fails.
	/// </para>
	/// <para>If the identifier is GUID_NULL on input, the thread ordering service generates and returns a unique identifier.</para>
	/// </param>
	/// <param name="Timeout">
	/// <para>A pointer to a time-out value. All threads within the group should complete their execution within <c>Period</c> plus <c>Timeout</c>.</para>
	/// <para>
	/// If a thread fails to complete its processing within the period plus this time-out interval, it is removed from the thread ordering
	/// group. If the parent fails to complete its processing within the period plus the time-out interval, the thread ordering group is destroyed.
	/// </para>
	/// <para>
	/// The possible values for this parameter depend on the platform, but can be as low as 500 microseconds or as high as
	/// 0x1FFFFFFFFFFFFFFF. If this parameter is less than 500 microseconds, then it is set to 500 microseconds. If this parameter is greater
	/// than the maximum, then it is set to 0x1FFFFFFFFFFFFFFF.
	/// </para>
	/// <para>If this parameter is <c>NULL</c> or 0, the default is five times the value of <c>Period</c>.</para>
	/// <para>
	/// If this parameter is THREAD_ORDER_GROUP_INFINITE_TIMEOUT, the group is created with an infinite time-out interval. This can be useful
	/// for debugging purposes.
	/// </para>
	/// </param>
	/// <returns>
	/// <para>If the function succeeds, the return value is nonzero.</para>
	/// <para>If the function fails, the return value is zero. To get extended error information, call GetLastError.</para>
	/// <para>If a thread ordering group with the specified identifier already exists, the function fails and sets the last error to ERROR_ALREADY_EXISTS.</para>
	/// </returns>
	/// <remarks>
	/// <para>
	/// The calling thread is considered to be the parent thread. Each thread ordering group has one parent thread. Each parent thread can
	/// have zero or more predecessor threads and zero or more successor threads. A client thread can join a thread ordering group and
	/// specify whether it is a predecessor or successor using the AvRtJoinThreadOrderingGroup function.
	/// </para>
	/// <para>
	/// The parent thread encloses the code to be executed during each period within a loop that is controlled by the
	/// AvRtWaitOnThreadOrderingGroup function.
	/// </para>
	/// <para>To delete the thread ordering group, call the AvRtDeleteThreadOrderingGroup function.</para>
	/// <para>
	/// A thread can create more than one thread ordering group and join more than one thread ordering group. However, a thread cannot join
	/// the same thread ordering group more than one time.
	/// </para>
	/// <para>Examples</para>
	/// <para>The following snippet creates a thread ordering group.</para>
	/// </remarks>
	// https://learn.microsoft.com/en-us/windows/win32/api/avrt/nf-avrt-avrtcreatethreadorderinggroup AVRTAPI BOOL
	// AvRtCreateThreadOrderingGroup( [out] PHANDLE Context, [in] PLARGE_INTEGER Period, [in, out] GUID *ThreadOrderingGuid, [in, optional]
	// PLARGE_INTEGER Timeout );
	[PInvokeData("avrt.h", MSDNShortId = "NF:avrt.AvRtCreateThreadOrderingGroup")]
	[DllImport(Lib_Avrt, SetLastError = true, ExactSpelling = true)]
	[return: MarshalAs(UnmanagedType.Bool)]
	public static extern bool AvRtCreateThreadOrderingGroup(out HANDLE Context, in long Period, ref Guid ThreadOrderingGuid,
		[In, Optional] in long Timeout);

	/// <summary>Creates a thread ordering group and associates the server thread with a task.</summary>
	/// <param name="Context">A pointer to a context handle.</param>
	/// <param name="Period">
	/// <para>
	/// A pointer to a value, in 100-nanosecond increments, that specifies the period for the thread ordering group. Each thread in the
	/// thread ordering group runs one time during this period. If all threads complete their execution before a period ends, all threads
	/// wait until the remainder of the period elapses before any are executed again.
	/// </para>
	/// <para>
	/// The possible values for this parameter depend on the platform, but this parameter can be as low as 500 microseconds or as high as
	/// 0x1FFFFFFFFFFFFFFF. If this parameter is less than 500 microseconds, then it is set to 500 microseconds. If this parameter is greater
	/// than the maximum, then it is set to 0x1FFFFFFFFFFFFFFF.
	/// </para>
	/// </param>
	/// <param name="ThreadOrderingGuid">
	/// <para>
	/// A pointer to the unique identifier for the thread ordering group to be created. If this value is not unique to the thread ordering
	/// service, the function fails.
	/// </para>
	/// <para>If the identifier is GUID_NULL on input, the thread ordering service generates and returns a unique identifier.</para>
	/// </param>
	/// <param name="Timeout">
	/// <para>A pointer to a time-out value. All threads within the group should complete their execution within <c>Period</c> plus <c>Timeout</c>.</para>
	/// <para>
	/// If a thread fails to complete its processing within the period plus this time-out interval, it is removed from the thread ordering
	/// group. If the parent fails to complete its processing within the period plus the time-out interval, the thread ordering group is destroyed.
	/// </para>
	/// <para>
	/// The possible values for this parameter depend on the platform, but can be as low as 500 microseconds or as high as
	/// 0x1FFFFFFFFFFFFFFF. If this parameter is less than 500 microseconds, then it is set to 500 microseconds. If this parameter is greater
	/// than the maximum, then it is set to 0x1FFFFFFFFFFFFFFF.
	/// </para>
	/// <para>If this parameter is <c>NULL</c> or 0, the default is five times the value of <c>Period</c>.</para>
	/// <para>
	/// If this parameter is THREAD_ORDER_GROUP_INFINITE_TIMEOUT, the group is created with an infinite time-out interval. This can be useful
	/// for debugging purposes.
	/// </para>
	/// </param>
	/// <param name="TaskName">The name of the task.</param>
	/// <returns>
	/// <para>If the function succeeds, the return value is nonzero.</para>
	/// <para>If the function fails, the return value is zero. To get extended error information, call GetLastError.</para>
	/// <para>If a thread ordering group with the specified identifier already exists, the function fails and sets the last error to ERROR_ALREADY_EXISTS.</para>
	/// </returns>
	/// <remarks>
	/// <para>
	/// The calling thread is considered to be the parent thread. Each thread ordering group has one parent thread. Each parent thread can
	/// have zero or more predecessor threads and zero or more successor threads. A client thread can join a thread ordering group and
	/// specify whether it is a predecessor or successor using the AvRtJoinThreadOrderingGroup function.
	/// </para>
	/// <para>
	/// The parent thread encloses the code to be executed during each period within a loop that is controlled by the
	/// AvRtWaitOnThreadOrderingGroup function.
	/// </para>
	/// <para>To delete the thread ordering group, call the AvRtDeleteThreadOrderingGroup function.</para>
	/// <para>
	/// A thread can create more than one thread ordering group and join more than one thread ordering group. However, a thread cannot join
	/// the same thread ordering group more than one time.
	/// </para>
	/// <para>
	/// The parent and client threads of a thread ordering group run at high priorities. However, the server thread that manages the thread
	/// ordering group runs at normal priority. Therefore, there can be a delay switching from one client thread to another if there are
	/// other high-priority threads running. The <c>TaskName</c> parameter of this function specifies the task to be associated with the
	/// server thread.
	/// </para>
	/// <para>Examples</para>
	/// <para>The following snippet creates a thread ordering group.</para>
	/// <para>
	/// <para>Note</para>
	/// <para>
	/// The avrt.h header defines AvRtCreateThreadOrderingGroupEx as an alias which automatically selects the ANSI or Unicode version of this
	/// function based on the definition of the UNICODE preprocessor constant. Mixing usage of the encoding-neutral alias with code that not
	/// encoding-neutral can lead to mismatches that result in compilation or runtime errors. For more information, see Conventions for
	/// Function Prototypes.
	/// </para>
	/// </para>
	/// </remarks>
	// https://learn.microsoft.com/en-us/windows/win32/api/avrt/nf-avrt-avrtcreatethreadorderinggroupexa AVRTAPI BOOL
	// AvRtCreateThreadOrderingGroupExA( [out] PHANDLE Context, [in] PLARGE_INTEGER Period, [in, out] GUID *ThreadOrderingGuid, [in,
	// optional] PLARGE_INTEGER Timeout, [in] LPCSTR TaskName );
	[PInvokeData("avrt.h", MSDNShortId = "NF:avrt.AvRtCreateThreadOrderingGroupExA")]
	[DllImport(Lib_Avrt, SetLastError = true, CharSet = CharSet.Auto)]
	[return: MarshalAs(UnmanagedType.Bool)]
	public static extern bool AvRtCreateThreadOrderingGroupEx(out HANDLE Context, in long Period, ref Guid ThreadOrderingGuid,
		[In, Optional] in long Timeout, [MarshalAs(UnmanagedType.LPTStr)] string TaskName);

	/// <summary>
	/// Deletes the specified thread ordering group created by the caller. It cleans up resources for the thread ordering group, including
	/// the context information, and returns.
	/// </summary>
	/// <param name="Context">
	/// A context handle. This handle is returned by the AvRtCreateThreadOrderingGroup function when creating the group.
	/// </param>
	/// <returns>
	/// <para>If the function succeeds, the return value is nonzero.</para>
	/// <para>If the function fails, the return value is zero. To get extended error information, call GetLastError.</para>
	/// </returns>
	/// <remarks>
	/// <para>
	/// This function can only be called successfully by the parent thread for the thread ordering group. If a thread other than the parent
	/// thread calls this function, the function fails with a last error code of ERROR_INVALID_FUNCTION.
	/// </para>
	/// <para>If the parent thread times out and attempts to call this function, the function fails with a last error code of ERROR_INVALID_PARAMETER.</para>
	/// <para>Examples</para>
	/// <para>The following code deletes a thread ordering group.</para>
	/// </remarks>
	// https://learn.microsoft.com/en-us/windows/win32/api/avrt/nf-avrt-avrtdeletethreadorderinggroup AVRTAPI BOOL
	// AvRtDeleteThreadOrderingGroup( [in] HANDLE Context );
	[PInvokeData("avrt.h", MSDNShortId = "NF:avrt.AvRtDeleteThreadOrderingGroup")]
	[DllImport(Lib_Avrt, SetLastError = true, ExactSpelling = true)]
	[return: MarshalAs(UnmanagedType.Bool)]
	public static extern bool AvRtDeleteThreadOrderingGroup([In] HANDLE Context);

	/// <summary>Joins client threads to a thread ordering group.</summary>
	/// <param name="Context">A pointer to a context handle.</param>
	/// <param name="ThreadOrderingGuid">A pointer to the unique identifier for the thread ordering group.</param>
	/// <param name="Before">
	/// The thread order. If this parameter is <c>TRUE</c>, the thread is a predecessor thread that is scheduled to run before the parent
	/// thread. If this parameter is <c>FALSE</c>, the thread is a successor thread that is scheduled to run after the parent thread.
	/// </param>
	/// <returns>
	/// <para>If the function succeeds, the return value is nonzero.</para>
	/// <para>If the function fails, the return value is zero. To get extended error information, call GetLastError.</para>
	/// </returns>
	/// <remarks>
	/// <para>
	/// The thread encloses the code to be executed during each period within a loop that is controlled by the AvRtWaitOnThreadOrderingGroup function.
	/// </para>
	/// <para>
	/// A thread can create more than one thread ordering group and join more than one thread ordering group. However, a thread cannot join
	/// the same thread ordering group more than one time.
	/// </para>
	/// <para>The number of threads that can join a group is limited only by available system resources.</para>
	/// </remarks>
	// https://learn.microsoft.com/en-us/windows/win32/api/avrt/nf-avrt-avrtjointhreadorderinggroup AVRTAPI BOOL AvRtJoinThreadOrderingGroup(
	// [out] PHANDLE Context, [in] GUID *ThreadOrderingGuid, [in] BOOL Before );
	[PInvokeData("avrt.h", MSDNShortId = "NF:avrt.AvRtJoinThreadOrderingGroup")]
	[DllImport(Lib_Avrt, SetLastError = true, ExactSpelling = true)]
	[return: MarshalAs(UnmanagedType.Bool)]
	public static extern bool AvRtJoinThreadOrderingGroup(out HANDLE Context, in Guid ThreadOrderingGuid, [MarshalAs(UnmanagedType.Bool)] bool Before);

	/// <summary>Enables client threads to leave a thread ordering group.</summary>
	/// <param name="Context">A context handle. This handle is returned by the AvRtJoinThreadOrderingGroup function.</param>
	/// <returns>
	/// <para>If the function succeeds, the return value is nonzero.</para>
	/// <para>If the function fails, the return value is zero. To get extended error information, call GetLastError.</para>
	/// </returns>
	/// <remarks>
	/// <para>The parent thread for a thread ordering group should not remove itself from the group.</para>
	/// <para>If a thread times out and attempts to call this function, the function fails with a last error code of ERROR_INVALID_PARAMETER.</para>
	/// </remarks>
	// https://learn.microsoft.com/en-us/windows/win32/api/avrt/nf-avrt-avrtleavethreadorderinggroup AVRTAPI BOOL
	// AvRtLeaveThreadOrderingGroup( [in] HANDLE Context );
	[PInvokeData("avrt.h", MSDNShortId = "NF:avrt.AvRtLeaveThreadOrderingGroup")]
	[DllImport(Lib_Avrt, SetLastError = true, ExactSpelling = true)]
	[return: MarshalAs(UnmanagedType.Bool)]
	public static extern bool AvRtLeaveThreadOrderingGroup([In] HANDLE Context);

	/// <summary>Enables client threads of a thread ordering group to wait until they should execute.</summary>
	/// <param name="Context">
	/// A context handle. This handle is returned by the AvRtCreateThreadOrderingGroup or AvRtJoinThreadOrderingGroup function.
	/// </param>
	/// <returns>
	/// <para>If the function succeeds, the return value is nonzero.</para>
	/// <para>If the function fails, the return value is zero. To get extended error information, call GetLastError.</para>
	/// </returns>
	/// <remarks>
	/// <para>When this function returns, the thread should complete its processing for the period and then call the function again.</para>
	/// <para>
	/// If the thread fails to complete its processing during the time-out interval specified by the parent thread when creating the group,
	/// it is deleted from the thread ordering group. Therefore, when the thread finishes its processing loop, the next call to
	/// <c>AvRtWaitOnThreadOrderingGroup</c> fails and the last error code is set to ERROR_ACCESS_DENIED.
	/// </para>
	/// <para>If the thread ordering group is deleted during the wait, this function eventually times out and return ERROR_ACCESS_DENIED.</para>
	/// <para>Examples</para>
	/// </remarks>
	// https://learn.microsoft.com/en-us/windows/win32/api/avrt/nf-avrt-avrtwaitonthreadorderinggroup AVRTAPI BOOL
	// AvRtWaitOnThreadOrderingGroup( [in] HANDLE Context );
	[PInvokeData("avrt.h", MSDNShortId = "NF:avrt.AvRtWaitOnThreadOrderingGroup")]
	[DllImport(Lib_Avrt, SetLastError = true, ExactSpelling = true)]
	[return: MarshalAs(UnmanagedType.Bool)]
	public static extern bool AvRtWaitOnThreadOrderingGroup([In] HANDLE Context);

	/// <summary>Associates the calling thread with the specified tasks.</summary>
	/// <param name="FirstTask">
	/// The name of the first task to be performed. This name must match the name of one of the subkeys of the following key
	/// <c>HKEY_LOCAL_MACHINE\SOFTWARE\Microsoft\Windows NT\CurrentVersion\Multimedia\SystemProfile\Tasks</c>.
	/// </param>
	/// <param name="SecondTask">
	/// The name of the second task to be performed. This name must match the name of one of the subkeys of the following key
	/// <c>HKEY_LOCAL_MACHINE\SOFTWARE\Microsoft\Windows NT\CurrentVersion\Multimedia\SystemProfile\Tasks</c>.
	/// </param>
	/// <param name="TaskIndex">
	/// The unique task identifier. The first time this function is called, this value must be 0 on input. The index value is returned on
	/// output and can be used as input in subsequent calls.
	/// </param>
	/// <returns>
	/// <para>If the function succeeds, it returns a handle to the task.</para>
	/// <para>If the function fails, it returns 0. To retrieve extended error information, call GetLastError.</para>
	/// <para>The following are possible error codes.</para>
	/// <list type="table">
	/// <listheader>
	/// <term>Return code</term>
	/// <term>Description</term>
	/// </listheader>
	/// <item>
	/// <term><c>ERROR_INVALID_TASK_INDEX</c></term>
	/// <term>Either <c>TaskIndex</c> is not 0 on the first call or is not recognized value (on subsequent calls).</term>
	/// </item>
	/// <item>
	/// <term><c>ERROR_INVALID_TASK_NAME</c></term>
	/// <term>The specified task does not match any of the tasks stored in the registry.</term>
	/// </item>
	/// <item>
	/// <term><c>ERROR_PRIVILEGE_NOT_HELD</c></term>
	/// <term>The caller does not have sufficient privilege.</term>
	/// </item>
	/// </list>
	/// </returns>
	/// <remarks>
	/// <para>The resulting characteristics of the thread performing the tasks reflect the task with the highest priority.</para>
	/// <para>When the task is completed, call the AvRevertMmThreadCharacteristics function.</para>
	/// <para>
	/// <para>Note</para>
	/// <para>
	/// The avrt.h header defines AvSetMmMaxThreadCharacteristics as an alias which automatically selects the ANSI or Unicode version of this
	/// function based on the definition of the UNICODE preprocessor constant. Mixing usage of the encoding-neutral alias with code that not
	/// encoding-neutral can lead to mismatches that result in compilation or runtime errors. For more information, see Conventions for
	/// Function Prototypes.
	/// </para>
	/// </para>
	/// </remarks>
	// https://learn.microsoft.com/en-us/windows/win32/api/avrt/nf-avrt-avsetmmmaxthreadcharacteristicsa AVRTAPI HANDLE
	// AvSetMmMaxThreadCharacteristicsA( [in] LPCSTR FirstTask, [in] LPCSTR SecondTask, [in, out] LPDWORD TaskIndex );
	[PInvokeData("avrt.h", MSDNShortId = "NF:avrt.AvSetMmMaxThreadCharacteristicsA")]
	[DllImport(Lib_Avrt, SetLastError = true, CharSet = CharSet.Auto)]
	public static extern SafeHAVRT AvSetMmMaxThreadCharacteristics([MarshalAs(UnmanagedType.LPTStr)] string FirstTask,
		[MarshalAs(UnmanagedType.LPTStr)] string SecondTask, ref uint TaskIndex);

	/// <summary>Associates the calling thread with the specified task.</summary>
	/// <param name="TaskName">
	/// The name of the task to be performed. This name must match the name of one of the subkeys of the following key
	/// <c>HKEY_LOCAL_MACHINE\SOFTWARE\Microsoft\Windows NT\CurrentVersion\Multimedia\SystemProfile\Tasks</c>.
	/// </param>
	/// <param name="TaskIndex">
	/// The unique task identifier. The first time this function is called, this value must be 0 on input. The index value is returned on
	/// output and can be used as input in subsequent calls.
	/// </param>
	/// <returns>
	/// <para>If the function succeeds, it returns a handle to the task.</para>
	/// <para>If the function fails, it returns 0. To retrieve extended error information, call GetLastError.</para>
	/// <para>The following are possible error codes.</para>
	/// <list type="table">
	/// <listheader>
	/// <term>Return code</term>
	/// <term>Description</term>
	/// </listheader>
	/// <item>
	/// <term><c>ERROR_INVALID_TASK_INDEX</c></term>
	/// <term>Either <c>TaskIndex</c> is not 0 on the first call or is not recognized value (on subsequent calls).</term>
	/// </item>
	/// <item>
	/// <term><c>ERROR_INVALID_TASK_NAME</c></term>
	/// <term>The specified task does not match any of the tasks stored in the registry.</term>
	/// </item>
	/// <item>
	/// <term><c>ERROR_PRIVILEGE_NOT_HELD</c></term>
	/// <term>The caller does not have sufficient privilege.</term>
	/// </item>
	/// </list>
	/// </returns>
	/// <remarks>
	/// <para>When the task is completed, call the AvRevertMmThreadCharacteristics function.</para>
	/// <para>
	/// <para>Note</para>
	/// <para>
	/// The avrt.h header defines AvSetMmThreadCharacteristics as an alias which automatically selects the ANSI or Unicode version of this
	/// function based on the definition of the UNICODE preprocessor constant. Mixing usage of the encoding-neutral alias with code that not
	/// encoding-neutral can lead to mismatches that result in compilation or runtime errors. For more information, see Conventions for
	/// Function Prototypes.
	/// </para>
	/// </para>
	/// </remarks>
	// https://learn.microsoft.com/en-us/windows/win32/api/avrt/nf-avrt-avsetmmthreadcharacteristicsa AVRTAPI HANDLE
	// AvSetMmThreadCharacteristicsA( [in] LPCSTR TaskName, [in, out] LPDWORD TaskIndex );
	[PInvokeData("avrt.h", MSDNShortId = "NF:avrt.AvSetMmThreadCharacteristicsA")]
	[DllImport(Lib_Avrt, SetLastError = true, CharSet = CharSet.Auto)]
	public static extern SafeHAVRT AvSetMmThreadCharacteristics([MarshalAs(UnmanagedType.LPTStr)] string TaskName, ref uint TaskIndex);

	/// <summary>Adjusts the thread priority of the calling thread relative to other threads performing the same task.</summary>
	/// <param name="AvrtHandle">
	/// A handle to the task. This handle is returned by the AvSetMmThreadCharacteristics or AvSetMmMaxThreadCharacteristics function.
	/// </param>
	/// <param name="Priority">
	/// <para>
	/// The relative thread priority of this thread to other threads performing a similar task. This parameter can be one of the following values.
	/// </para>
	/// <para>AVRT_PRIORITY_CRITICAL (2)</para>
	/// <para>AVRT_PRIORITY_HIGH (1)</para>
	/// <para>AVRT_PRIORITY_LOW (-1)</para>
	/// <para>AVRT_PRIORITY_NORMAL (0)</para>
	/// </param>
	/// <returns>
	/// <para>If the function succeeds, the return value is nonzero.</para>
	/// <para>If the function fails, the return value is zero. To get extended error information, call GetLastError.</para>
	/// </returns>
	// https://learn.microsoft.com/en-us/windows/win32/api/avrt/nf-avrt-avsetmmthreadpriority AVRTAPI BOOL AvSetMmThreadPriority( [in] HANDLE
	// AvrtHandle, [in] AVRT_PRIORITY Priority );
	[PInvokeData("avrt.h", MSDNShortId = "NF:avrt.AvSetMmThreadPriority")]
	[DllImport(Lib_Avrt, SetLastError = true, ExactSpelling = true)]
	[return: MarshalAs(UnmanagedType.Bool)]
	public static extern bool AvSetMmThreadPriority([In] HAVRT AvrtHandle, [In] AVRT_PRIORITY Priority);

	/// <summary>Provides a handle to an AvRt task.</summary>
	[StructLayout(LayoutKind.Sequential)]
	public readonly struct HAVRT : IHandle
	{
		private readonly IntPtr handle;

		/// <summary>Initializes a new instance of the <see cref="HAVRT"/> struct.</summary>
		/// <param name="preexistingHandle">An <see cref="IntPtr"/> object that represents the pre-existing handle to use.</param>
		public HAVRT(IntPtr preexistingHandle) => handle = preexistingHandle;

		/// <summary>Returns an invalid handle by instantiating a <see cref="HAVRT"/> object with <see cref="IntPtr.Zero"/>.</summary>
		public static HAVRT NULL => new(IntPtr.Zero);

		/// <summary>Gets a value indicating whether this instance is a null handle.</summary>
		public bool IsNull => handle == IntPtr.Zero;

		/// <summary>Implements the operator !.</summary>
		/// <param name="h1">The handle.</param>
		/// <returns>The result of the operator.</returns>
		public static bool operator !(HAVRT h1) => h1.IsNull;

		/// <summary>Performs an explicit conversion from <see cref="HAVRT"/> to <see cref="IntPtr"/>.</summary>
		/// <param name="h">The handle.</param>
		/// <returns>The result of the conversion.</returns>
		public static explicit operator IntPtr(HAVRT h) => h.handle;

		/// <summary>Performs an implicit conversion from <see cref="IntPtr"/> to <see cref="HAVRT"/>.</summary>
		/// <param name="h">The pointer to a handle.</param>
		/// <returns>The result of the conversion.</returns>
		public static implicit operator HAVRT(IntPtr h) => new(h);

		/// <summary>Implements the operator !=.</summary>
		/// <param name="h1">The first handle.</param>
		/// <param name="h2">The second handle.</param>
		/// <returns>The result of the operator.</returns>
		public static bool operator !=(HAVRT h1, HAVRT h2) => !(h1 == h2);

		/// <summary>Implements the operator ==.</summary>
		/// <param name="h1">The first handle.</param>
		/// <param name="h2">The second handle.</param>
		/// <returns>The result of the operator.</returns>
		public static bool operator ==(HAVRT h1, HAVRT h2) => h1.Equals(h2);

		/// <inheritdoc/>
		public override bool Equals(object? obj) => obj is HAVRT h && handle == h.handle;

		/// <inheritdoc/>
		public override int GetHashCode() => handle.GetHashCode();

		/// <inheritdoc/>
		public IntPtr DangerousGetHandle() => handle;
	}

	/// <summary>Provides a <see cref="SafeHandle"/> for <see cref="HAVRT"/> that is disposed using <see cref="AvRevertMmThreadCharacteristics"/>.</summary>
	public class SafeHAVRT : SafeHANDLE
	{
		/// <summary>Initializes a new instance of the <see cref="SafeHAVRT"/> class and assigns an existing handle.</summary>
		/// <param name="preexistingHandle">An <see cref="IntPtr"/> object that represents the pre-existing handle to use.</param>
		/// <param name="ownsHandle">
		/// <see langword="true"/> to reliably release the handle during the finalization phase; otherwise, <see langword="false"/> (not recommended).
		/// </param>
		public SafeHAVRT(IntPtr preexistingHandle, bool ownsHandle = true) : base(preexistingHandle, ownsHandle) { }

		/// <summary>Initializes a new instance of the <see cref="SafeHAVRT"/> class.</summary>
		private SafeHAVRT() : base() { }

		/// <summary>Performs an implicit conversion from <see cref="SafeHAVRT"/> to <see cref="HAVRT"/>.</summary>
		/// <param name="h">The safe handle instance.</param>
		/// <returns>The result of the conversion.</returns>
		public static implicit operator HAVRT(SafeHAVRT h) => h.handle;

		/// <inheritdoc/>
		protected override bool InternalReleaseHandle() => AvRevertMmThreadCharacteristics((HAVRT)handle);
	}
}