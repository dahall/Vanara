using System;
using System.Runtime.InteropServices;

namespace Vanara.PInvoke
{
	public static partial class Kernel32
	{
		/// <summary>
		/// An application-defined function that serves as the starting address for a timer callback or a registered wait callback. Specify
		/// this address when calling the CreateTimerQueueTimer, RegisterWaitForSingleObject function.
		/// </summary>
		/// <param name="lpParameter">
		/// The thread data passed to the function using a parameter of the CreateTimerQueueTimer or RegisterWaitForSingleObject function.
		/// </param>
		/// <param name="TimerOrWaitFired">
		/// If this parameter is TRUE, the wait timed out. If this parameter is FALSE, the wait event has been signaled. (This parameter is
		/// always TRUE for timer callbacks.)
		/// </param>
		// https://msdn.microsoft.com/en-us/library/windows/desktop/ms687066(v=vs.85).aspx
		[PInvokeData("WinBase.h", MSDNShortId = "ms687066")]
		[UnmanagedFunctionPointer(CallingConvention.StdCall)]
		public delegate void WaitOrTimerCallback(IntPtr lpParameter, [MarshalAs(UnmanagedType.U1)] bool TimerOrWaitFired);

		/// <summary>The flags that control execution.</summary>
		public enum WT
		{
			/// <summary>
			/// By default, the callback function is queued to a non-I/O worker thread.
			/// <para>
			/// The callback function is queued to a thread that uses I/O completion ports, which means they cannot perform an alertable
			/// wait. Therefore, if I/O completes and generates an APC, the APC might wait indefinitely because there is no guarantee that
			/// the thread will enter an alertable wait state after the callback completes.
			/// </para>
			/// </summary>
			WT_EXECUTEDEFAULT = 0x00000000,

			/// <summary>
			/// This flag is not used.
			/// <para>
			/// Windows Server 2003 and Windows XP: The callback function is queued to an I/O worker thread. This flag should be used if the
			/// function should be executed in a thread that waits in an alertable state. I/O worker threads were removed starting with
			/// Windows Vista and Windows Server 2008.
			/// </para>
			/// </summary>
			WT_EXECUTEINIOTHREAD = 0x00000001,

			/// <summary>Undocumented.</summary>
			WT_EXECUTEINUITHREAD = 0x00000002,

			/// <summary>
			/// The callback function is invoked by the wait thread itself. This flag should be used only for short tasks or it could affect
			/// other wait operations.
			/// <para>
			/// Deadlocks can occur if some other thread acquires an exclusive lock and calls the UnregisterWait or UnregisterWaitEx function
			/// while the callback function is trying to acquire the same lock.
			/// </para>
			/// </summary>
			WT_EXECUTEINWAITTHREAD = 0x00000004,

			/// <summary>The timer will be set to the signaled state only once. If this flag is set, the Period parameter must be zero.</summary>
			WT_EXECUTEONLYONCE = 0x00000008,

			/// <summary>
			/// The callback function is invoked by the timer thread itself. This flag should be used only for short tasks or it could affect
			/// other timer operations.
			/// <para>The callback function is queued as an APC. It should not perform alertable wait operations.</para>
			/// </summary>
			WT_EXECUTEINTIMERTHREAD = 0x00000020,

			/// <summary>
			/// The callback function can perform a long wait. This flag helps the system to decide if it should create a new thread.
			/// </summary>
			WT_EXECUTELONGFUNCTION = 0x00000010,

			/// <summary>Undocumented.</summary>
			WT_EXECUTEINPERSISTENTIOTHREAD = 0x00000040,

			/// <summary>
			/// The callback function is queued to a thread that never terminates. It does not guarantee that the same thread is used each
			/// time. This flag should be used only for short tasks or it could affect other timer operations. This flag must be set if the
			/// thread calls functions that use APCs. For more information, see Asynchronous Procedure Calls.
			/// <para>
			/// Note that currently no worker thread is truly persistent, although worker threads do not terminate if there are any pending
			/// I/O requests.
			/// </para>
			/// </summary>
			WT_EXECUTEINPERSISTENTTHREAD = 0x00000080,

			/// <summary>
			/// Callback functions will use the current access token, whether it is a process or impersonation token. If this flag is not
			/// specified, callback functions execute only with the process token.
			/// <para>Windows XP: This flag is not supported until Windows XP SP2 and Windows Server 2003.</para>
			/// </summary>
			WT_TRANSFER_IMPERSONATION = 0x00000100,

			/// <summary>
			/// The callback function can perform a long wait. This flag helps the system to decide if it should create a new thread.
			/// </summary>
			WT_EXECUTEINLONGTHREAD = 0x00000010,

			/// <summary>The timer will be set to the signaled state only once. If this flag is set, the Period parameter must be zero.</summary>
			WT_EXECUTEDELETEWAIT = 0x00000008,
		}

		/// <summary>
		/// Associates the I/O completion port owned by the thread pool with the specified file handle. On completion of an I/O request
		/// involving this file, a non-I/O worker thread will execute the specified callback function.
		/// </summary>
		/// <param name="FileHandle">
		/// A handle to the file opened for overlapped I/O completion. This handle is returned by the <c>CreateFile</c> function, with the
		/// <c>FILE_FLAG_OVERLAPPED</c> flag.
		/// </param>
		/// <param name="Function">
		/// <para>
		/// A pointer to the callback function to be executed in a non-I/O worker thread when the I/O operation is complete. This callback
		/// function must not call the <c>TerminateThread</c> function.
		/// </para>
		/// <para>For more information about the completion routine, see <c>FileIOCompletionRoutine</c>.</para>
		/// </param>
		/// <param name="Flags">This parameter must be zero.</param>
		/// <returns>
		/// <para>If the function succeeds, the return value is nonzero.</para>
		/// <para>
		/// If the function fails, the return value is zero. To get extended error information, call the <c>GetLastError</c> function. The
		/// value returned is an <c>NTSTATUS</c> error code. To retrieve the corresponding system error code, use the
		/// <c>RtlNtStatusToDosError</c> function.
		/// </para>
		/// </returns>
		// BOOL WINAPI BindIoCompletionCallback( _In_ HANDLE FileHandle, _In_ LPOVERLAPPED_COMPLETION_ROUTINE Function, _In_ ULONG Flags); https://msdn.microsoft.com/en-us/library/windows/desktop/aa363484(v=vs.85).aspx
		[DllImport(Lib.Kernel32, SetLastError = true, ExactSpelling = true)]
		[PInvokeData("WinBase.h", MSDNShortId = "aa363484")]
		[return: MarshalAs(UnmanagedType.Bool)]
		public static extern bool BindIoCompletionCallback([In] HFILE FileHandle, FileIOCompletionRoutine Function, [Optional] uint Flags);

		/// <summary>Updates a timer-queue timer that was created by the <c>CreateTimerQueueTimer</c> function.</summary>
		/// <param name="TimerQueue">
		/// <para>A handle to the timer queue. This handle is returned by the <c>CreateTimerQueue</c> function.</para>
		/// <para>If this parameter is <c>NULL</c>, the timer is associated with the default timer queue.</para>
		/// </param>
		/// <param name="Timer">A handle to the timer-queue timer. This handle is returned by the <c>CreateTimerQueueTimer</c> function.</param>
		/// <param name="DueTime">The time after which the timer should expire, in milliseconds.</param>
		/// <param name="Period">
		/// The period of the timer, in milliseconds. If this parameter is zero, the timer is signaled once. If this parameter is greater
		/// than zero, the timer is periodic. A periodic timer automatically reactivates each time the period elapses, until the timer is
		/// canceled using the <c>DeleteTimerQueueTimer</c> function or reset using <c>ChangeTimerQueueTimer</c>.
		/// </param>
		/// <returns>
		/// <para>If the function succeeds, the return value is nonzero.</para>
		/// <para>If the function fails, the return value is zero. To get extended error information, call <c>GetLastError</c>.</para>
		/// </returns>
		// BOOL WINAPI ChangeTimerQueueTimer( _In_opt_ HANDLE TimerQueue, _Inout_ HANDLE Timer, _In_ ULONG DueTime, _In_ ULONG Period); https://msdn.microsoft.com/en-us/library/windows/desktop/ms682004(v=vs.85).aspx
		[DllImport(Lib.Kernel32, SetLastError = true, ExactSpelling = true)]
		[PInvokeData("WinBase.h", MSDNShortId = "ms682004")]
		[return: MarshalAs(UnmanagedType.Bool)]
		public static extern bool ChangeTimerQueueTimer([In] TimerQueueHandle TimerQueue, TimerQueueTimerHandle Timer, uint DueTime, uint Period);

		/// <summary>
		/// Creates a queue for timers. Timer-queue timers are lightweight objects that enable you to specify a callback function to be
		/// called at a specified time.
		/// </summary>
		/// <returns>
		/// <para>
		/// If the function succeeds, the return value is a handle to the timer queue. This handle can be used only in functions that require
		/// a handle to a timer queue.
		/// </para>
		/// <para>If the function fails, the return value is <c>NULL</c>. To get extended error information, call <c>GetLastError</c>.</para>
		/// </returns>
		// HANDLE WINAPI CreateTimerQueue(void); https://msdn.microsoft.com/en-us/library/windows/desktop/ms682483(v=vs.85).aspx
		[DllImport(Lib.Kernel32, SetLastError = true, ExactSpelling = true)]
		[PInvokeData("WinBase.h", MSDNShortId = "ms682483")]
		public static extern SafeTimerQueueHandle CreateTimerQueue();

		/// <summary>
		/// Creates a timer-queue timer. This timer expires at the specified due time, then after every specified period. When the timer
		/// expires, the callback function is called.
		/// </summary>
		/// <param name="phNewTimer">
		/// A pointer to a buffer that receives a handle to the timer-queue timer on return. When this handle has expired and is no longer
		/// required, release it by calling <c>DeleteTimerQueueTimer</c>.
		/// </param>
		/// <param name="TimerQueue">
		/// <para>A handle to the timer queue. This handle is returned by the <c>CreateTimerQueue</c> function.</para>
		/// <para>If this parameter is <c>NULL</c>, the timer is associated with the default timer queue.</para>
		/// </param>
		/// <param name="Callback">
		/// A pointer to the application-defined function of type <c>WAITORTIMERCALLBACK</c> to be executed when the timer expires. For more
		/// information, see <c>WaitOrTimerCallback</c>.
		/// </param>
		/// <param name="Parameter">A single parameter value that will be passed to the callback function.</param>
		/// <param name="DueTime">
		/// The amount of time in milliseconds relative to the current time that must elapse before the timer is signaled for the first time.
		/// </param>
		/// <param name="Period">
		/// The period of the timer, in milliseconds. If this parameter is zero, the timer is signaled once. If this parameter is greater
		/// than zero, the timer is periodic. A periodic timer automatically reactivates each time the period elapses, until the timer is canceled.
		/// </param>
		/// <param name="Flags">
		/// <para>This parameter can be one or more of the following values from WinNT.h.</para>
		/// <para>
		/// <list type="table">
		/// <listheader>
		/// <term>Value</term>
		/// <term>Meaning</term>
		/// </listheader>
		/// <item>
		/// <term>WT_EXECUTEDEFAULT0x00000000</term>
		/// <term>By default, the callback function is queued to a non-I/O worker thread.</term>
		/// </item>
		/// <item>
		/// <term>WT_EXECUTEINTIMERTHREAD0x00000020</term>
		/// <term>
		/// The callback function is invoked by the timer thread itself. This flag should be used only for short tasks or it could affect
		/// other timer operations. The callback function is queued as an APC. It should not perform alertable wait operations.
		/// </term>
		/// </item>
		/// <item>
		/// <term>WT_EXECUTEINIOTHREAD0x00000001</term>
		/// <term>
		/// This flag is not used.Windows Server 2003 and Windows XP: The callback function is queued to an I/O worker thread. This flag
		/// should be used if the function should be executed in a thread that waits in an alertable state. I/O worker threads were removed
		/// starting with Windows Vista and Windows Server 2008.
		/// </term>
		/// </item>
		/// <item>
		/// <term>WT_EXECUTEINPERSISTENTTHREAD0x00000080</term>
		/// <term>
		/// The callback function is queued to a thread that never terminates. It does not guarantee that the same thread is used each time.
		/// This flag should be used only for short tasks or it could affect other timer operations. This flag must be set if the thread
		/// calls functions that use APCs. For more information, see Asynchronous Procedure Calls.Note that currently no worker thread is
		/// truly persistent, although no worker thread will terminate if there are any pending I/O requests.
		/// </term>
		/// </item>
		/// <item>
		/// <term>WT_EXECUTELONGFUNCTION0x00000010</term>
		/// <term>The callback function can perform a long wait. This flag helps the system to decide if it should create a new thread.</term>
		/// </item>
		/// <item>
		/// <term>WT_EXECUTEONLYONCE0x00000008</term>
		/// <term>The timer will be set to the signaled state only once. If this flag is set, the Period parameter must be zero.</term>
		/// </item>
		/// <item>
		/// <term>WT_TRANSFER_IMPERSONATION0x00000100</term>
		/// <term>
		/// Callback functions will use the current access token, whether it is a process or impersonation token. If this flag is not
		/// specified, callback functions execute only with the process token.Windows XP: This flag is not supported until Windows XP with
		/// SP2 and Windows Server 2003.
		/// </term>
		/// </item>
		/// </list>
		/// </para>
		/// </param>
		/// <returns>
		/// <para>If the function succeeds, the return value is nonzero.</para>
		/// <para>If the function fails, the return value is zero. To get extended error information, call <c>GetLastError</c>.</para>
		/// </returns>
		// BOOL WINAPI CreateTimerQueueTimer( _Out_ PHANDLE phNewTimer, _In_opt_ HANDLE TimerQueue, _In_ WAITORTIMERCALLBACK Callback,
		// _In_opt_ PVOID Parameter, _In_ DWORD DueTime, _In_ DWORD Period, _In_ ULONG Flags); https://msdn.microsoft.com/en-us/library/windows/desktop/ms682485(v=vs.85).aspx
		[PInvokeData("WinBase.h", MSDNShortId = "ms682485")]
		[DllImport(Lib.Kernel32, SetLastError = true, ExactSpelling = true)]
		[return: MarshalAs(UnmanagedType.Bool)]
		public static extern bool CreateTimerQueueTimer(out TimerQueueTimerHandle phNewTimer, [In] TimerQueueHandle TimerQueue, WaitOrTimerCallback Callback, [In, Optional] IntPtr Parameter, uint DueTime, [Optional] uint Period, [Optional] WT Flags);

		/// <summary>Deletes a timer queue. Any pending timers in the queue are canceled and deleted.</summary>
		/// <param name="TimerQueue">A handle to the timer queue. This handle is returned by the <c>CreateTimerQueue</c> function.</param>
		/// <param name="CompletionEvent">
		/// <para>
		/// A handle to the event object to be signaled when the function is successful and all callback functions have completed. This
		/// parameter can be <c>NULL</c>.
		/// </para>
		/// <para>If this parameter is <c>INVALID_HANDLE_VALUE</c>, the function waits for all callback functions to complete before returning.</para>
		/// <para>
		/// If this parameter is <c>NULL</c>, the function marks the timer for deletion and returns immediately. However, most callers should
		/// wait for the callback function to complete so they can perform any needed cleanup.
		/// </para>
		/// </param>
		/// <returns>
		/// <para>If the function succeeds, the return value is nonzero.</para>
		/// <para>If the function fails, the return value is zero. To get extended error information, call <c>GetLastError</c>.</para>
		/// </returns>
		// BOOL WINAPI DeleteTimerQueueEx( _In_ HANDLE TimerQueue, _In_opt_ HANDLE CompletionEvent); https://msdn.microsoft.com/en-us/library/windows/desktop/ms682568(v=vs.85).aspx
		[DllImport(Lib.Kernel32, SetLastError = true, ExactSpelling = true)]
		[PInvokeData("WinBase.h", MSDNShortId = "ms682568")]
		[return: MarshalAs(UnmanagedType.Bool)]
		public static extern bool DeleteTimerQueueEx([In] TimerQueueHandle TimerQueue, [In] SafeEventHandle CompletionEvent);

		/// <summary>
		/// Removes a timer from the timer queue and optionally waits for currently running timer callback functions to complete before
		/// deleting the timer.
		/// </summary>
		/// <param name="TimerQueue">
		/// <para>A handle to the timer queue. This handle is returned by the <c>CreateTimerQueue</c> function.</para>
		/// <para>If the timer was created using the default timer queue, this parameter should be <c>NULL</c>.</para>
		/// </param>
		/// <param name="Timer">A handle to the timer-queue timer. This handle is returned by the <c>CreateTimerQueueTimer</c> function.</param>
		/// <param name="CompletionEvent">
		/// <para>
		/// A handle to the event object to be signaled when the system has canceled the timer and all callback functions have completed.
		/// This parameter can be <c>NULL</c>.
		/// </para>
		/// <para>
		/// If this parameter is <c>INVALID_HANDLE_VALUE</c>, the function waits for any running timer callback functions to complete before returning.
		/// </para>
		/// <para>
		/// If this parameter is <c>NULL</c>, the function marks the timer for deletion and returns immediately. If the timer has already
		/// expired, the timer callback function will run to completion. However, there is no notification sent when the timer callback
		/// function has completed. Most callers should not use this option, and should wait for running timer callback functions to complete
		/// so they can perform any needed cleanup.
		/// </para>
		/// </param>
		/// <returns>
		/// <para>If the function succeeds, the return value is nonzero.</para>
		/// <para>
		/// If the function fails, the return value is zero. To get extended error information, call <c>GetLastError</c>. If the error code
		/// is <c>ERROR_IO_PENDING</c>, it is not necessary to call this function again. For any other error, you should retry the call.
		/// </para>
		/// </returns>
		// BOOL WINAPI DeleteTimerQueueTimer( _In_opt_ HANDLE TimerQueue, _In_ HANDLE Timer, _In_opt_ HANDLE CompletionEvent); https://msdn.microsoft.com/en-us/library/windows/desktop/ms682569(v=vs.85).aspx
		[DllImport(Lib.Kernel32, SetLastError = true, ExactSpelling = true)]
		[PInvokeData("WinBase.h", MSDNShortId = "ms682569")]
		[return: MarshalAs(UnmanagedType.Bool)]
		public static extern bool DeleteTimerQueueTimer([In] TimerQueueHandle TimerQueue, [In] TimerQueueTimerHandle Timer, [In] SafeEventHandle CompletionEvent);

		/// <summary>Queues a work item to a worker thread in the thread pool.</summary>
		/// <param name="Function">
		/// A pointer to the application-defined callback function of type LPTHREAD_START_ROUTINE to be executed by the thread in the thread
		/// pool. This value represents the starting address of the thread. This callback function must not call the TerminateThread function.
		/// <para>For more information, see ThreadProc.</para>
		/// </param>
		/// <param name="Context">A single parameter value to be passed to the thread function.</param>
		/// <param name="Flags">The flags that control execution. This parameter can be one or more of the following values.</param>
		/// <returns>
		/// <para>If the function succeeds, the return value is nonzero.</para>
		/// <para>If the function fails, the return value is zero. To get extended error information, call <c>GetLastError</c>.</para>
		/// </returns>
		// https://msdn.microsoft.com/en-us/library/windows/desktop/ms684957(v=vs.85).aspx
		[DllImport(Lib.Kernel32, SetLastError = false, ExactSpelling = true)]
		[PInvokeData("WinBase.h", MSDNShortId = "ms684957")]
		[return: MarshalAs(UnmanagedType.Bool)]
		public static extern bool QueueUserWorkItem(ThreadProc Function, [In] IntPtr Context, WT Flags);

		/// <summary>
		/// <para>
		/// Directs a wait thread in the thread pool to wait on the object. The wait thread queues the specified callback function to the
		/// thread pool when one of the following occurs:
		/// </para>
		/// <list type="bullet">
		///   <item>
		///     <term>The specified object is in the signaled state.</term>
		///   </item>
		///   <item>
		///     <term>The time-out interval elapses.</term>
		///   </item>
		/// </list>
		/// </summary>
		/// <param name="phNewWaitObject">A pointer to a variable that receives a wait handle on return. Note that a wait handle cannot be used in functions that require
		/// an object handle, such as CloseHandle.</param>
		/// <param name="hObject"><para>A handle to the object. For a list of the object types whose handles can be specified, see the following Remarks section.</para>
		/// <para>If this handle is closed while the wait is still pending, the function's behavior is undefined.</para>
		/// <para>The handles must have the <c>SYNCHRONIZE</c> access right. For more information, see Standard Access Rights.</para></param>
		/// <param name="Callback">A pointer to the application-defined function of type <c>WAITORTIMERCALLBACK</c> to be executed when hObject is in the signaled
		/// state, or dwMilliseconds elapses. For more information, see WaitOrTimerCallback.</param>
		/// <param name="Context">A single value that is passed to the callback function.</param>
		/// <param name="dwMilliseconds">The time-out interval, in milliseconds. The function returns if the interval elapses, even if the object's state is nonsignaled.
		/// If dwMilliseconds is zero, the function tests the object's state and returns immediately. If dwMilliseconds is <c>INFINITE</c>,
		/// the function's time-out interval never elapses.</param>
		/// <param name="dwFlags"><para>This parameter can be one or more of the following values.</para>
		/// <para>For information about using these values with objects that remain signaled, see the Remarks section.</para>
		/// <list type="table">
		///   <listheader>
		///     <term>Value</term>
		///     <term>Meaning</term>
		///   </listheader>
		///   <item>
		///     <term>WT_EXECUTEDEFAULT 0x00000000</term>
		///     <term>By default, the callback function is queued to a non-I/O worker thread.</term>
		///   </item>
		///   <item>
		///     <term>WT_EXECUTEINIOTHREAD 0x00000001</term>
		///     <term>
		/// This flag is not used. Windows Server 2003 and Windows XP: The callback function is queued to an I/O worker thread. This flag
		/// should be used if the function should be executed in a thread that waits in an alertable state. I/O worker threads were removed
		/// starting with Windows Vista and Windows Server 2008.
		/// </term>
		///   </item>
		///   <item>
		///     <term>WT_EXECUTEINPERSISTENTTHREAD 0x00000080</term>
		///     <term>
		/// The callback function is queued to a thread that never terminates. It does not guarantee that the same thread is used each time.
		/// This flag should be used only for short tasks or it could affect other wait operations. This flag must be set if the thread calls
		/// functions that use APCs. For more information, see Asynchronous Procedure Calls. Note that currently no worker thread is truly
		/// persistent, although no worker thread will terminate if there are any pending I/O requests.
		/// </term>
		///   </item>
		///   <item>
		///     <term>WT_EXECUTEINWAITTHREAD 0x00000004</term>
		///     <term>
		/// The callback function is invoked by the wait thread itself. This flag should be used only for short tasks or it could affect
		/// other wait operations. Deadlocks can occur if some other thread acquires an exclusive lock and calls the UnregisterWait or
		/// UnregisterWaitEx function while the callback function is trying to acquire the same lock.
		/// </term>
		///   </item>
		///   <item>
		///     <term>WT_EXECUTELONGFUNCTION 0x00000010</term>
		///     <term>The callback function can perform a long wait. This flag helps the system to decide if it should create a new thread.</term>
		///   </item>
		///   <item>
		///     <term>WT_EXECUTEONLYONCE 0x00000008</term>
		///     <term>
		/// The thread will no longer wait on the handle after the callback function has been called once. Otherwise, the timer is reset
		/// every time the wait operation completes until the wait operation is canceled.
		/// </term>
		///   </item>
		///   <item>
		///     <term>WT_TRANSFER_IMPERSONATION 0x00000100</term>
		///     <term>
		/// Callback functions will use the current access token, whether it is a process or impersonation token. If this flag is not
		/// specified, callback functions execute only with the process token. Windows XP: This flag is not supported until Windows XP with
		/// SP2 and Windows Server 2003.
		/// </term>
		///   </item>
		/// </list></param>
		/// <returns>
		/// <para>If the function succeeds, the return value is nonzero.</para>
		/// <para>If the function fails, the return value is zero. To get extended error information, call GetLastError.</para>
		/// </returns>
		/// <remarks>
		/// <para>
		/// New wait threads are created automatically when required. The wait operation is performed by a wait thread from the thread pool.
		/// The callback routine is executed by a worker thread when the object's state becomes signaled or the time-out interval elapses. If
		/// dwFlags is not <c>WT_EXECUTEONLYONCE</c>, the timer is reset every time the event is signaled or the time-out interval elapses.
		/// </para>
		/// <para>
		/// When the wait is completed, you must call the UnregisterWait or UnregisterWaitEx function to cancel the wait operation. (Even
		/// wait operations that use <c>WT_EXECUTEONLYONCE</c> must be canceled.) Do not make a blocking call to either of these functions
		/// from within the callback function.
		/// </para>
		/// <para>
		/// Note that you should not pulse an event object passed to <c>RegisterWaitForSingleObject</c>, because the wait thread might not
		/// detect that the event is signaled before it is reset. You should not register an object that remains signaled (such as a manual
		/// reset event or terminated process) unless you set the <c>WT_EXECUTEONLYONCE</c> or <c>WT_EXECUTEINWAITTHREAD</c> flag. For other
		/// flags, the callback function might be called too many times before the event is reset.
		/// </para>
		/// <para>
		/// The function modifies the state of some types of synchronization objects. Modification occurs only for the object whose signaled
		/// state caused the wait condition to be satisfied. For example, the count of a semaphore object is decreased by one.
		/// </para>
		/// <para>The <c>RegisterWaitForSingleObject</c> function can wait for the following objects:</para>
		/// <list type="bullet">
		///   <item>
		///     <term>Change notification</term>
		///   </item>
		///   <item>
		///     <term>Console input</term>
		///   </item>
		///   <item>
		///     <term>Event</term>
		///   </item>
		///   <item>
		///     <term>Memory resource notification</term>
		///   </item>
		///   <item>
		///     <term>Mutex</term>
		///   </item>
		///   <item>
		///     <term>Process</term>
		///   </item>
		///   <item>
		///     <term>Semaphore</term>
		///   </item>
		///   <item>
		///     <term>Thread</term>
		///   </item>
		///   <item>
		///     <term>Waitable timer</term>
		///   </item>
		/// </list>
		/// <para>For more information, see Synchronization Objects.</para>
		/// <para>
		/// By default, the thread pool has a maximum of 500 threads. To raise this limit, use the <c>WT_SET_MAX_THREADPOOL_THREAD</c> macro
		/// defined in WinNT.h.
		/// </para>
		/// <para>
		/// Use this macro when specifying the dwFlags parameter. The macro parameters are the desired flags and the new limit (up to
		/// (2&lt;&lt;16)-1 threads). However, note that your application can improve its performance by keeping the number of worker threads low.
		/// </para>
		/// <para>
		/// The work item and all functions it calls must be thread-pool safe. Therefore, you cannot call an asynchronous call that requires
		/// a persistent thread, such as the RegNotifyChangeKeyValue function, from the default callback environment. Instead, set the thread
		/// pool maximum equal to the thread pool minimum using the SetThreadpoolThreadMaximum and SetThreadpoolThreadMinimum functions, or
		/// create your own thread using the CreateThread function. (For the original thread pool API, specify
		/// <c>WT_EXECUTEINPERSISTENTTHREAD</c> using the QueueUserWorkItem function.)
		/// </para>
		/// <para>
		/// To compile an application that uses this function, define <c>_WIN32_WINNT</c> as 0x0500 or later. For more information, see Using
		/// the Windows Headers.
		/// </para>
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows/win32/api/winbase/nf-winbase-registerwaitforsingleobject
		// BOOL RegisterWaitForSingleObject( PHANDLE phNewWaitObject, HANDLE hObject, WAITORTIMERCALLBACK Callback, PVOID Context, ULONG dwMilliseconds, ULONG dwFlags );
		[PInvokeData("winbase.h", MSDNShortId = "d0cd8b28-6e20-449a-94dd-cca2be46b812")]
		public static bool RegisterWaitForSingleObject(out SafeRegisteredWaitHandle phNewWaitObject, ISyncHandle hObject, WaitOrTimerCallback Callback, IntPtr Context, uint dwMilliseconds, WT dwFlags) =>
			RegisterWaitForSingleObject(out phNewWaitObject, hObject?.DangerousGetHandle() ?? IntPtr.Zero, Callback, Context, dwMilliseconds, dwFlags);

		/// <summary>Gets a value that combines <see cref="WT"/> flags values with a new maximum threadpool thread count limit.</summary>
		/// <param name="Flags">The desired flags.</param>
		/// <param name="Limit">The threadpool thread count limit. The default is 500.</param>
		/// <returns>A <see cref="WT"/> value that has been augmented with the limit.</returns>
		public static WT WT_SET_MAX_THREADPOOL_THREADS(WT Flags, ushort Limit) => Flags | (WT)((uint)Limit << 16);

		/// <summary>Cancels a registered wait operation issued by the <c>RegisterWaitForSingleObject</c> function.</summary>
		/// <param name="WaitHandle">The wait handle. This handle is returned by the <c>RegisterWaitForSingleObject</c> function.</param>
		/// <param name="CompletionEvent">
		/// <para>A handle to the event object to be signaled when the wait operation has been unregistered. This parameter can be <c>NULL</c>.</para>
		/// <para>If this parameter is <c>INVALID_HANDLE_VALUE</c>, the function waits for all callback functions to complete before returning.</para>
		/// <para>
		/// If this parameter is <c>NULL</c>, the function marks the timer for deletion and returns immediately. However, most callers should
		/// wait for the callback function to complete so they can perform any needed cleanup.
		/// </para>
		/// <para>
		/// If the caller provides this event and the function succeeds or the function fails with <c>ERROR_IO_PENDING</c>, do not close the
		/// event until it is signaled.
		/// </para>
		/// </param>
		/// <returns>
		/// <para>If the function succeeds, the return value is nonzero.</para>
		/// <para>If the function fails, the return value is zero. To get extended error information, call <c>GetLastError</c>.</para>
		/// </returns>
		// BOOL WINAPI UnregisterWaitEx( _In_ HANDLE WaitHandle, _In_opt_ HANDLE CompletionEvent); https://msdn.microsoft.com/en-us/library/windows/desktop/ms686876(v=vs.85).aspx
		[DllImport(Lib.Kernel32, SetLastError = true, ExactSpelling = true)]
		[PInvokeData("LibLoaderAPI.h", MSDNShortId = "ms686876")]
		[return: MarshalAs(UnmanagedType.Bool)]
		public static extern bool UnregisterWaitEx([In] IntPtr WaitHandle, [In] SafeEventHandle CompletionEvent);

		[DllImport(Lib.Kernel32, SetLastError = true, ExactSpelling = true)]
		[return: MarshalAs(UnmanagedType.Bool)]
		private static extern bool RegisterWaitForSingleObject(out SafeRegisteredWaitHandle phNewWaitObject, [In] IntPtr hObject, WaitOrTimerCallback Callback, [In] IntPtr Context, uint dwMilliseconds, WT dwFlags);

		/// <summary>Provides a handle to a timer queue.</summary>
		[StructLayout(LayoutKind.Sequential)]
		public struct TimerQueueHandle : IHandle
		{
			private IntPtr handle;

			/// <summary>Initializes a new instance of the <see cref="TimerQueueHandle"/> struct.</summary>
			/// <param name="preexistingHandle">An <see cref="IntPtr"/> object that represents the pre-existing handle to use.</param>
			public TimerQueueHandle(IntPtr preexistingHandle) => handle = preexistingHandle;

			/// <summary>Returns an invalid handle by instantiating a <see cref="TimerQueueHandle"/> object with <see cref="IntPtr.Zero"/>.</summary>
			public static TimerQueueHandle NULL => new TimerQueueHandle(IntPtr.Zero);

			/// <summary>Gets a value indicating whether this instance is a null handle.</summary>
			public bool IsNull => handle == IntPtr.Zero;

			/// <summary>Performs an explicit conversion from <see cref="TimerQueueHandle"/> to <see cref="IntPtr"/>.</summary>
			/// <param name="h">The handle.</param>
			/// <returns>The result of the conversion.</returns>
			public static explicit operator IntPtr(TimerQueueHandle h) => h.handle;

			/// <summary>Performs an implicit conversion from <see cref="IntPtr"/> to <see cref="TimerQueueHandle"/>.</summary>
			/// <param name="h">The pointer to a handle.</param>
			/// <returns>The result of the conversion.</returns>
			public static implicit operator TimerQueueHandle(IntPtr h) => new TimerQueueHandle(h);

			/// <summary>Implements the operator !=.</summary>
			/// <param name="h1">The first handle.</param>
			/// <param name="h2">The second handle.</param>
			/// <returns>The result of the operator.</returns>
			public static bool operator !=(TimerQueueHandle h1, TimerQueueHandle h2) => !(h1 == h2);

			/// <summary>Implements the operator ==.</summary>
			/// <param name="h1">The first handle.</param>
			/// <param name="h2">The second handle.</param>
			/// <returns>The result of the operator.</returns>
			public static bool operator ==(TimerQueueHandle h1, TimerQueueHandle h2) => h1.Equals(h2);

			/// <inheritdoc/>
			public override bool Equals(object obj) => obj is TimerQueueHandle h ? handle == h.handle : false;

			/// <inheritdoc/>
			public override int GetHashCode() => handle.GetHashCode();

			/// <inheritdoc/>
			public IntPtr DangerousGetHandle() => handle;
		}

		/// <summary>Provides a handle to a timer queue timer.</summary>
		[StructLayout(LayoutKind.Sequential)]
		public struct TimerQueueTimerHandle : IHandle
		{
			private IntPtr handle;

			/// <summary>Initializes a new instance of the <see cref="TimerQueueTimerHandle"/> struct.</summary>
			/// <param name="preexistingHandle">An <see cref="IntPtr"/> object that represents the pre-existing handle to use.</param>
			public TimerQueueTimerHandle(IntPtr preexistingHandle) => handle = preexistingHandle;

			/// <summary>Returns an invalid handle by instantiating a <see cref="TimerQueueTimerHandle"/> object with <see cref="IntPtr.Zero"/>.</summary>
			public static TimerQueueTimerHandle NULL => new TimerQueueTimerHandle(IntPtr.Zero);

			/// <summary>Gets a value indicating whether this instance is a null handle.</summary>
			public bool IsNull => handle == IntPtr.Zero;

			/// <summary>Performs an explicit conversion from <see cref="TimerQueueTimerHandle"/> to <see cref="IntPtr"/>.</summary>
			/// <param name="h">The handle.</param>
			/// <returns>The result of the conversion.</returns>
			public static explicit operator IntPtr(TimerQueueTimerHandle h) => h.handle;

			/// <summary>Performs an implicit conversion from <see cref="IntPtr"/> to <see cref="TimerQueueTimerHandle"/>.</summary>
			/// <param name="h">The pointer to a handle.</param>
			/// <returns>The result of the conversion.</returns>
			public static implicit operator TimerQueueTimerHandle(IntPtr h) => new TimerQueueTimerHandle(h);

			/// <summary>Implements the operator !=.</summary>
			/// <param name="h1">The first handle.</param>
			/// <param name="h2">The second handle.</param>
			/// <returns>The result of the operator.</returns>
			public static bool operator !=(TimerQueueTimerHandle h1, TimerQueueTimerHandle h2) => !(h1 == h2);

			/// <summary>Implements the operator ==.</summary>
			/// <param name="h1">The first handle.</param>
			/// <param name="h2">The second handle.</param>
			/// <returns>The result of the operator.</returns>
			public static bool operator ==(TimerQueueTimerHandle h1, TimerQueueTimerHandle h2) => h1.Equals(h2);

			/// <inheritdoc/>
			public override bool Equals(object obj) => obj is TimerQueueTimerHandle h ? handle == h.handle : false;

			/// <inheritdoc/>
			public override int GetHashCode() => handle.GetHashCode();

			/// <inheritdoc/>
			public IntPtr DangerousGetHandle() => handle;
		}

		/// <summary>
		/// Provides a <see cref="SafeHandle"/> to a timer queue that releases a created TimerQueueHandle instance at disposal using CloseHandle.
		/// </summary>
		public class SafeTimerQueueHandle : SafeHANDLE
		{
			/// <summary>Initializes a new instance of the <see cref="TimerQueueHandle"/> class and assigns an existing handle.</summary>
			/// <param name="preexistingHandle">An <see cref="IntPtr"/> object that represents the pre-existing handle to use.</param>
			/// <param name="ownsHandle">
			/// <see langword="true"/> to reliably release the handle during the finalization phase; otherwise, <see langword="false"/> (not recommended).
			/// </param>
			public SafeTimerQueueHandle(IntPtr preexistingHandle, bool ownsHandle = true) : base(preexistingHandle, ownsHandle) { }

			private SafeTimerQueueHandle() : base() { }

			/// <summary>Gets or sets the completion event associated with the disposal or closure of this timer queue.</summary>
			/// <value>
			/// <para>
			/// A handle to the event object to be signaled when the function is successful and all callback functions have completed. This
			/// parameter can be <see langword="null"/>.
			/// </para>
			/// <para>
			/// If this parameter is <see cref="SafeEventHandle.Invalid"/>, the function waits for all callback functions to complete before returning.
			/// </para>
			/// <para>
			/// If this parameter is <see langword="null"/>, the function marks the timer for deletion and returns immediately. However, most
			/// callers should wait for the callback function to complete so they can perform any needed cleanup.
			/// </para>
			/// </value>
			public SafeEventHandle CompletionEvent { get; set; }

			/// <summary>Performs an implicit conversion from <see cref="SafeTimerQueueHandle"/> to <see cref="TimerQueueHandle"/>.</summary>
			/// <param name="h">The safe handle instance.</param>
			/// <returns>The result of the conversion.</returns>
			public static implicit operator TimerQueueHandle(SafeTimerQueueHandle h) => h.handle;

			/// <inheritdoc/>
			protected override bool InternalReleaseHandle() => DeleteTimerQueueEx(this, CompletionEvent ?? SafeEventHandle.Null);
		}
	}
}