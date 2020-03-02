using System;
using System.Runtime.InteropServices;
using Vanara.InteropServices;

namespace Vanara.PInvoke
{
	public static partial class Kernel32
	{
		/// <summary/>
		public const uint UMS_VERSION = 0x0100;

		/// <summary>Flags used by UMS_SYSTEM_THREAD_INFORMATION.</summary>
		[PInvokeData("winbase.h", MSDNShortId = "eecdc592-5046-47c3-a4c6-ecb10899db3c")]
		public enum ThreadUmsFlags : uint
		{
			/// <summary>
			/// <para>
			/// A bitfield that specifies a UMS scheduler thread. If <c>IsUmsSchedulerThread</c> is set, <c>IsUmsWorkerThread</c> must be clear.
			/// </para>
			/// </summary>
			IsUmsSchedulerThread = 0x1,

			/// <summary>
			/// <para>
			/// A bitfield that specifies a UMS worker thread. If <c>IsUmsWorkerThread</c> is set, <c>IsUmsSchedulerThread</c> must be clear.
			/// </para>
			/// </summary>
			IsUmsWorkerThread = 0x2,
		}

		/// <summary>
		/// <para>Creates a user-mode scheduling (UMS) completion list.</para>
		/// </summary>
		/// <param name="UmsCompletionList">
		/// <para>A <c>PUMS_COMPLETION_LIST</c> variable. On output, this parameter receives a pointer to an empty UMS completion list.</para>
		/// </param>
		/// <returns>
		/// <para>If the function succeeds, it returns a nonzero value.</para>
		/// <para>
		/// If the function fails, the return value is zero. To get extended error information, call GetLastError. Possible error values
		/// include the following.
		/// </para>
		/// <list type="table">
		/// <listheader>
		/// <term>Return code</term>
		/// <term>Description</term>
		/// </listheader>
		/// <item>
		/// <term>ERROR_NOT_ENOUGH_MEMORY</term>
		/// <term>Not enough memory is available to create the completion list.</term>
		/// </item>
		/// </list>
		/// </returns>
		/// <remarks>
		/// <para>
		/// A completion list is associated with a UMS scheduler thread when the EnterUmsSchedulingMode function is called to create the
		/// scheduler thread. The system queues newly created UMS worker threads to the completion list. It also queues previously blocked
		/// UMS worker threads to the completion list when the threads are no longer blocked.
		/// </para>
		/// <para>
		/// When an application's UmsSchedulerProc entry point function is called, the application's scheduler should retrieve items from the
		/// completion list by calling DequeueUmsCompletionListItems.
		/// </para>
		/// <para>
		/// Each completion list has an associated completion list event which is signaled whenever the system queues items to an empty list.
		/// Use the GetUmsCompletionListEvent to obtain a handle to the event for a specified completion list.
		/// </para>
		/// <para>
		/// When a completion list is no longer needed, use the DeleteUmsCompletionList to release the list. The list must be empty before it
		/// can be released.
		/// </para>
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows/desktop/api/winbase/nf-winbase-createumscompletionlist BOOL CreateUmsCompletionList(
		// PUMS_COMPLETION_LIST *UmsCompletionList );
		[DllImport(Lib.Kernel32, SetLastError = true, ExactSpelling = true)]
		[PInvokeData("winbase.h", MSDNShortId = "6e77b793-a82e-4e23-8c8b-7aff79d69346")]
		[return: MarshalAs(UnmanagedType.Bool)]
		public static extern bool CreateUmsCompletionList(out SafePUMS_COMPLETION_LIST UmsCompletionList);

		/// <summary>
		/// <para>Creates a user-mode scheduling (UMS) thread context to represent a UMS worker thread.</para>
		/// </summary>
		/// <param name="lpUmsThread">
		/// <para>A PUMS_CONTEXT variable. On output, this parameter receives a pointer to a UMS thread context.</para>
		/// </param>
		/// <returns>
		/// <para>If the function succeeds, it returns a nonzero value.</para>
		/// <para>
		/// If the function fails, the return value is zero. To get extended error information, call GetLastError. Possible error values
		/// include the following.
		/// </para>
		/// <list type="table">
		/// <listheader>
		/// <term>Return code</term>
		/// <term>Description</term>
		/// </listheader>
		/// <item>
		/// <term>ERROR_NOT_ENOUGH_MEMORY</term>
		/// <term>Not enough memory is available to create the UMS thread context.</term>
		/// </item>
		/// </list>
		/// </returns>
		/// <remarks>
		/// <para>
		/// A UMS thread context represents the state of a UMS worker thread. Thread contexts are used to specify UMS worker threads in
		/// function calls.
		/// </para>
		/// <para>
		/// A UMS worker thread is created by calling the CreateRemoteThreadEx function after using InitializeProcThreadAttributeList and
		/// UpdateProcThreadAttribute to prepare a list of UMS attributes for the thread.
		/// </para>
		/// <para>
		/// The underlying structures for a UMS thread context are managed by the system and should not be modified directly. To get and set
		/// information about a UMS worker thread, use the QueryUmsThreadInformation and SetUmsThreadInformation functions.
		/// </para>
		/// <para>After a UMS worker thread terminates, its thread context should be released by calling DeleteUmsThreadContext.</para>
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows/desktop/api/winbase/nf-winbase-createumsthreadcontext BOOL CreateUmsThreadContext(
		// PUMS_CONTEXT *lpUmsThread );
		[DllImport(Lib.Kernel32, SetLastError = true, ExactSpelling = true)]
		[PInvokeData("winbase.h", MSDNShortId = "b27ce81a-8463-46af-8acf-2de091f625df")]
		[return: MarshalAs(UnmanagedType.Bool)]
		public static extern bool CreateUmsThreadContext(out SafePUMS_CONTEXT lpUmsThread);

		/// <summary>
		/// <para>Deletes the specified user-mode scheduling (UMS) completion list. The list must be empty.</para>
		/// </summary>
		/// <param name="UmsCompletionList">
		/// <para>A pointer to the UMS completion list to be deleted. The CreateUmsCompletionList function provides this pointer.</para>
		/// </param>
		/// <returns>
		/// <para>If the function succeeds, it returns a nonzero value.</para>
		/// <para>If the function fails, the return value is zero. To get extended error information, call GetLastError.</para>
		/// </returns>
		/// <remarks>
		/// <para>
		/// If the completion list is shared, the caller is responsible for ensuring that no active UMS thread holds a reference to the list
		/// before deleting it.
		/// </para>
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows/desktop/api/winbase/nf-winbase-deleteumscompletionlist BOOL DeleteUmsCompletionList(
		// PUMS_COMPLETION_LIST UmsCompletionList );
		[DllImport(Lib.Kernel32, SetLastError = true, ExactSpelling = true)]
		[PInvokeData("winbase.h", MSDNShortId = "98124359-ddd1-468c-9f99-74dd3f631fa1")]
		[return: MarshalAs(UnmanagedType.Bool)]
		public static extern bool DeleteUmsCompletionList(PUMS_COMPLETION_LIST UmsCompletionList);

		/// <summary>
		/// <para>Deletes the specified user-mode scheduling (UMS) thread context. The thread must be terminated.</para>
		/// </summary>
		/// <param name="UmsThread">
		/// <para>A pointer to the UMS thread context to be deleted. The CreateUmsThreadContext function provides this pointer.</para>
		/// </param>
		/// <returns>
		/// <para>If the function succeeds, it returns a nonzero value.</para>
		/// <para>If the function fails, the return value is zero. To get extended error information, call GetLastError.</para>
		/// </returns>
		/// <remarks>
		/// <para>A UMS thread context cannot be deleted until the associated thread has terminated.</para>
		/// <para>
		/// When a UMS worker thread finishes running (for example, by returning from its thread entry point function), the system terminates
		/// the thread, sets the termination status in the thread's UMS thread context, and queues the UMS thread context to the associated
		/// completion list.
		/// </para>
		/// <para>Any attempt to execute the UMS thread will fail because the thread is already terminated.</para>
		/// <para>
		/// To check the termination status of a thread, the application's scheduler should call QueryUmsThreadInformation with the
		/// <c>UmsIsThreadTerminated</c> information class.
		/// </para>
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows/desktop/api/winbase/nf-winbase-deleteumsthreadcontext BOOL DeleteUmsThreadContext(
		// PUMS_CONTEXT UmsThread );
		[DllImport(Lib.Kernel32, SetLastError = true, ExactSpelling = true)]
		[PInvokeData("winbase.h", MSDNShortId = "cdd118fc-f664-44ce-958d-857216ceb9a7")]
		[return: MarshalAs(UnmanagedType.Bool)]
		public static extern bool DeleteUmsThreadContext(PUMS_CONTEXT UmsThread);

		/// <summary>
		/// <para>Retrieves user-mode scheduling (UMS) worker threads from the specified UMS completion list.</para>
		/// </summary>
		/// <param name="UmsCompletionList">
		/// <para>A pointer to the completion list from which to retrieve worker threads.</para>
		/// </param>
		/// <param name="WaitTimeOut">
		/// <para>
		/// The time-out interval for the retrieval operation, in milliseconds. The function returns if the interval elapses, even if no
		/// worker threads are queued to the completion list.
		/// </para>
		/// <para>
		/// If the WaitTimeOut parameter is zero, the completion list is checked for available worker threads without waiting for worker
		/// threads to become available. If the WaitTimeOut parameter is INFINITE, the function's time-out interval never elapses. This is
		/// not recommended, however, because it causes the function to block until one or more worker threads become available.
		/// </para>
		/// </param>
		/// <param name="UmsThreadList">
		/// <para>
		/// A pointer to a UMS_CONTEXT variable. On output, this parameter receives a pointer to the first UMS thread context in a list of
		/// UMS thread contexts.
		/// </para>
		/// <para>
		/// If no worker threads are available before the time-out specified by the WaitTimeOut parameter, this parameter is set to NULL.
		/// </para>
		/// </param>
		/// <returns>
		/// <para>If the function succeeds, it returns a nonzero value.</para>
		/// <para>
		/// If the function fails, the return value is zero. To get extended error information, call GetLastError. Possible error values
		/// include the following.
		/// </para>
		/// <list type="table">
		/// <listheader>
		/// <term>Return code</term>
		/// <term>Description</term>
		/// </listheader>
		/// <item>
		/// <term>ERROR_TIMEOUT</term>
		/// <term>No threads became available before the specified time-out interval elapsed.</term>
		/// </item>
		/// </list>
		/// </returns>
		/// <remarks>
		/// <para>
		/// The system queues a UMS worker thread to a completion list when the worker thread is created or when a previously blocked worker
		/// thread becomes unblocked. The <c>DequeueUmsCompletionListItems</c> function retrieves a pointer to a list of all thread contexts
		/// in the specified completion list. The GetNextUmsListItem function can be used to pop UMS thread contexts off the list into the
		/// scheduler's own ready thread queue. The scheduler is responsible for selecting threads to run based on priorities chosen by the application.
		/// </para>
		/// <para>
		/// Do not run UMS threads directly from the list provided by <c>DequeueUmsCompletionListItems</c>, or run a thread transferred from
		/// the list to the ready thread queue before the list is completely empty. This can cause unpredictable behavior in the application.
		/// </para>
		/// <para>
		/// If more than one caller attempts to retrieve threads from a shared completion list, only the first caller retrieves the threads.
		/// For subsequent callers, the <c>DequeueUmsCompletionListItems</c> function returns success but the UmsThreadList parameter is set
		/// to NULL.
		/// </para>
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows/desktop/api/winbase/nf-winbase-dequeueumscompletionlistitems BOOL
		// DequeueUmsCompletionListItems( PUMS_COMPLETION_LIST UmsCompletionList, DWORD WaitTimeOut, PUMS_CONTEXT *UmsThreadList );
		[DllImport(Lib.Kernel32, SetLastError = true, ExactSpelling = true)]
		[PInvokeData("winbase.h", MSDNShortId = "91499eb9-9fc5-4135-95f6-1bced78f1e07")]
		[return: MarshalAs(UnmanagedType.Bool)]
		public static extern bool DequeueUmsCompletionListItems(PUMS_COMPLETION_LIST UmsCompletionList, uint WaitTimeOut, out PUMS_CONTEXT UmsThreadList);

		/// <summary>
		/// <para>Converts the calling thread into a user-mode scheduling (UMS) scheduler thread.</para>
		/// </summary>
		/// <param name="SchedulerStartupInfo">
		/// <para>
		/// A pointer to a UMS_SCHEDULER_STARTUP_INFO structure that specifies UMS attributes for the thread, including a completion list and
		/// a UmsSchedulerProc entry point function.
		/// </para>
		/// </param>
		/// <returns>
		/// <para>If the function succeeds, it returns a nonzero value.</para>
		/// <para>If the function fails, the return value is zero. To get extended error information, call GetLastError.</para>
		/// </returns>
		/// <remarks>
		/// <para>
		/// An application's UMS scheduler creates one UMS scheduler thread for each processor that will be used to run UMS threads. The
		/// scheduler typically sets the affinity of the scheduler thread for a single processor, effectively reserving the processor for the
		/// use of that scheduler thread. For more information about thread affinity, see Multiple Processors.
		/// </para>
		/// <para>
		/// When a UMS scheduler thread is created, the system calls the UmsSchedulerProc entry point function specified with the
		/// <c>EnterUmsSchedulingMode</c> function call. The application's scheduler is responsible for finishing any application-specific
		/// initialization of the scheduler thread and selecting a UMS worker thread to run.
		/// </para>
		/// <para>
		/// The application's scheduler selects a UMS worker thread to run by calling ExecuteUmsThread with the worker thread's UMS thread
		/// context. The worker thread runs until it yields control by calling UmsThreadYield, blocks, or terminates. The scheduler thread is
		/// then available to run another worker thread.
		/// </para>
		/// <para>
		/// A scheduler thread should continue to run until all of its worker threads reach a natural stopping point: that is, all worker
		/// threads have yielded, blocked, or terminated.
		/// </para>
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows/desktop/api/winbase/nf-winbase-enterumsschedulingmode BOOL EnterUmsSchedulingMode(
		// PUMS_SCHEDULER_STARTUP_INFO SchedulerStartupInfo );
		[DllImport(Lib.Kernel32, SetLastError = true, ExactSpelling = true)]
		[PInvokeData("winbase.h", MSDNShortId = "792bd7fa-0ae9-4c38-a664-5fb3e3d0c52b")]
		[return: MarshalAs(UnmanagedType.Bool)]
		public static extern bool EnterUmsSchedulingMode(in UMS_SCHEDULER_STARTUP_INFO SchedulerStartupInfo);

		/// <summary>
		/// <para>Runs the specified UMS worker thread.</para>
		/// </summary>
		/// <param name="UmsThread">
		/// <para>A pointer to the UMS thread context of the worker thread to run.</para>
		/// </param>
		/// <returns>
		/// <para>If the function succeeds, it does not return a value.</para>
		/// <para>
		/// If the function fails, the return value is zero. To get extended error information, call GetLastError. Possible error codes
		/// include the following.
		/// </para>
		/// <list type="table">
		/// <listheader>
		/// <term>Return code</term>
		/// <term>Description</term>
		/// </listheader>
		/// <item>
		/// <term>ERROR_RETRY</term>
		/// <term>The specified UMS worker thread is temporarily locked by the system. The caller can retry the operation.</term>
		/// </item>
		/// </list>
		/// </returns>
		/// <remarks>
		/// <para>
		/// The <c>ExecuteUmsThread</c> function loads the state of the specified UMS worker thread over the state of the calling UMS
		/// scheduler thread so that the worker thread can run. The worker thread runs until it yields by calling the UmsThreadYield
		/// function, blocks, or terminates.
		/// </para>
		/// <para>
		/// When a worker thread yields or blocks, the system calls the scheduler thread's UmsSchedulerProc entry point function. When a
		/// previously blocked worker thread becomes unblocked, the system queues the worker thread to the completion list specified with the
		/// UpdateProcThreadAttribute function when the worker thread was created.
		/// </para>
		/// <para>
		/// The <c>ExecuteUmsThread</c> function does not return unless an error occurs. If the function returns ERROR_RETRY, the error is
		/// transitory and the operation can be retried.
		/// </para>
		/// <para>
		/// If the function returns an error other than ERROR_RETRY, the application's scheduler should check whether the thread is suspended
		/// or terminated by calling QueryUmsThreadInformation with <c>UmsThreadIsSuspended</c> or <c>UmsThreadIsTerminated</c>,
		/// respectively. Other possible errors include calling the function on a thread that is not a UMS scheduler thread, passing an
		/// invalid UMS worker thread context, or specifying a worker thread that is already executing on another scheduler thread.
		/// </para>
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows/desktop/api/winbase/nf-winbase-executeumsthread BOOL ExecuteUmsThread( PUMS_CONTEXT
		// UmsThread );
		[DllImport(Lib.Kernel32, SetLastError = true, ExactSpelling = true)]
		[PInvokeData("winbase.h", MSDNShortId = "e4265351-e8e9-4878-bd42-93258b4cd1a0")]
		[return: MarshalAs(UnmanagedType.Bool)]
		public static extern bool ExecuteUmsThread(PUMS_CONTEXT UmsThread);

		/// <summary>
		/// <para>Returns the user-mode scheduling (UMS) thread context of the calling UMS thread.</para>
		/// </summary>
		/// <returns>
		/// <para>The function returns a pointer to the UMS thread context of the calling thread.</para>
		/// <para>If calling thread is not a UMS thread, the function returns NULL. To get extended error information, call GetLastError.</para>
		/// </returns>
		/// <remarks>
		/// <para>The <c>GetCurrentUmsThread</c> function can be called for a UMS scheduler thread or UMS worker thread.</para>
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows/desktop/api/winbase/nf-winbase-getcurrentumsthread PUMS_CONTEXT GetCurrentUmsThread( );
		[DllImport(Lib.Kernel32, SetLastError = true, ExactSpelling = true)]
		[PInvokeData("winbase.h", MSDNShortId = "f2e20816-919a-443d-96d3-94e98afc28f2")]
		public static extern PUMS_CONTEXT GetCurrentUmsThread();

		/// <summary>Returns the next user-mode scheduling (UMS) thread context in a list of thread contexts.</summary>
		/// <param name="UmsContext">
		/// A pointer to a UMS context in a list of thread contexts. This list is retrieved by the DequeueUmsCompletionListItems function.
		/// </param>
		/// <returns>
		/// <para>If the function succeeds, it returns a pointer to the next thread context in the list.</para>
		/// <para>
		/// If there is no thread context after the context specified by the UmsContext parameter, the function returns NULL. To get extended
		/// error information, call GetLastError.
		/// </para>
		/// </returns>
		// https://docs.microsoft.com/en-us/windows/win32/api/winbase/nf-winbase-getnextumslistitem PUMS_CONTEXT GetNextUmsListItem(
		// PUMS_CONTEXT UmsContext );
		[DllImport(Lib.Kernel32, SetLastError = true, ExactSpelling = true)]
		[PInvokeData("winbase.h", MSDNShortId = "fb2c8420-12f4-4bd7-ac00-b53bab760db0")]
		public static extern PUMS_CONTEXT GetNextUmsListItem(PUMS_CONTEXT UmsContext);

		/// <summary>
		/// <para>Retrieves a handle to the event associated with the specified user-mode scheduling (UMS) completion list.</para>
		/// </summary>
		/// <param name="UmsCompletionList">
		/// <para>A pointer to a UMS completion list. The CreateUmsCompletionList function provides this pointer.</para>
		/// </param>
		/// <param name="UmsCompletionEvent">
		/// <para>
		/// A pointer to a HANDLE variable. On output, the UmsCompletionEvent parameter is set to a handle to the event associated with the
		/// specified completion list.
		/// </para>
		/// </param>
		/// <returns>
		/// <para>If the function succeeds, it returns a nonzero value.</para>
		/// <para>If the function fails, the return value is zero. To get extended error information, call GetLastError.</para>
		/// </returns>
		/// <remarks>
		/// <para>
		/// The system signals a UMS completion list event when the system queues items to an empty completion list. A completion list event
		/// handle can be used with any wait function that takes a handle to an event. When the event is signaled, an application typically
		/// calls DequeueUmsCompletionListItems to retrieve the contents of the completion list.
		/// </para>
		/// <para>
		/// The event handle remains valid until its completion list is deleted. Do not use the event handle to wait on a completion list
		/// that has been deleted or is in the process of being deleted.
		/// </para>
		/// <para>When the handle is no longer needed, use the CloseHandle function to close the handle.</para>
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows/desktop/api/winbase/nf-winbase-getumscompletionlistevent BOOL GetUmsCompletionListEvent(
		// PUMS_COMPLETION_LIST UmsCompletionList, PHANDLE UmsCompletionEvent );
		[DllImport(Lib.Kernel32, SetLastError = true, ExactSpelling = true)]
		[PInvokeData("winbase.h", MSDNShortId = "393f6e0a-fbea-4aa0-9c18-f96da18e61e9")]
		[return: MarshalAs(UnmanagedType.Bool)]
		public static extern bool GetUmsCompletionListEvent(PUMS_COMPLETION_LIST UmsCompletionList, out SafeEventHandle UmsCompletionEvent);

		/// <summary>
		/// <para>Queries whether the specified thread is a UMS scheduler thread, a UMS worker thread, or a non-UMS thread.</para>
		/// </summary>
		/// <param name="ThreadHandle">
		/// <para>
		/// A handle to a thread. The thread handle must have the THREAD_QUERY_INFORMATION access right. For more information, see Thread
		/// Security and Access Rights.
		/// </para>
		/// </param>
		/// <param name="SystemThreadInfo">
		/// <para>A pointer to an initialized UMS_SYSTEM_THREAD_INFORMATION structure that specifies the kind of thread for the query.</para>
		/// </param>
		/// <returns>
		/// <para>
		/// Returns TRUE if the specified thread matches the kind of thread specified by the SystemThreadInfo parameter. Otherwise, the
		/// function returns FALSE.
		/// </para>
		/// </returns>
		/// <remarks>
		/// <para>
		/// The <c>GetUmsSystemThreadInformation</c> function is intended for use in debuggers, troubleshooting tools, and profiling
		/// applications. For example, thread-isolated tracing or single-stepping through instructions might involve suspending all other
		/// threads in the process. However, if the thread to be traced is a UMS worker thread, suspending UMS scheduler threads might cause
		/// a deadlock because a UMS worker thread requires the intervention of a UMS scheduler thread in order to run. A debugger can call
		/// <c>GetUmsSystemThreadInformation</c> for each thread that it might suspend to determine the kind of thread, and then suspend it
		/// or not as needed for the code being debugged.
		/// </para>
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows/desktop/api/winbase/nf-winbase-getumssystemthreadinformation BOOL
		// GetUmsSystemThreadInformation( HANDLE ThreadHandle, PUMS_SYSTEM_THREAD_INFORMATION SystemThreadInfo );
		[DllImport(Lib.Kernel32, SetLastError = false, ExactSpelling = true)]
		[PInvokeData("winbase.h", MSDNShortId = "7c8347b6-6546-4ea9-9b2a-11794782f482")]
		[return: MarshalAs(UnmanagedType.Bool)]
		public static extern bool GetUmsSystemThreadInformation(HTHREAD ThreadHandle, ref UMS_SYSTEM_THREAD_INFORMATION SystemThreadInfo);

		/// <summary>Retrieves information about the specified user-mode scheduling (UMS) worker thread.</summary>
		/// <param name="UmsThread">A pointer to a UMS thread context.</param>
		/// <param name="UmsThreadInfoClass">A UMS_THREAD_INFO_CLASS value that specifies the kind of information to retrieve.</param>
		/// <param name="UmsThreadInformation">
		/// <para>
		/// A pointer to a buffer to receive the specified information. The required size of this buffer depends on the specified information class.
		/// </para>
		/// <para>If the information class is <c>UmsThreadContext</c> or <c>UmsThreadTeb</c>, the buffer must be .</para>
		/// <para>If the information class is <c>UmsThreadIsSuspended</c> or <c>UmsThreadIsTerminated</c>, the buffer must be .</para>
		/// </param>
		/// <param name="UmsThreadInformationLength">The size of the UmsThreadInformation buffer, in bytes.</param>
		/// <param name="ReturnLength">
		/// A pointer to a ULONG variable. On output, this parameter receives the number of bytes written to the UmsThreadInformation buffer.
		/// </param>
		/// <returns>
		/// <para>If the function succeeds, it returns a nonzero value.</para>
		/// <para>
		/// If the function fails, the return value is zero. To get extended error information, call GetLastError. Possible error values
		/// include the following.
		/// </para>
		/// <list type="table">
		/// <listheader>
		/// <term>Return code</term>
		/// <term>Description</term>
		/// </listheader>
		/// <item>
		/// <term>ERROR_INFO_LENGTH_MISMATCH</term>
		/// <term>The buffer is too small for the requested information.</term>
		/// </item>
		/// <item>
		/// <term>ERROR_INVALID_INFO_CLASS</term>
		/// <term>The specified information class is not supported.</term>
		/// </item>
		/// </list>
		/// </returns>
		/// <remarks>
		/// <para>
		/// The <c>QueryUmsThreadInformation</c> function retrieves information about the specified UMS worker thread such as its
		/// application-defined context, its thread execution block (TEB), and whether the thread is suspended or terminated.
		/// </para>
		/// <para>
		/// The underlying structures for UMS worker threads are managed by the system. Information that is not exposed through
		/// <c>QueryUmsThreadInformation</c> should be considered reserved.
		/// </para>
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows/desktop/api/winbase/nf-winbase-queryumsthreadinformation BOOL QueryUmsThreadInformation(
		// PUMS_CONTEXT UmsThread, UMS_THREAD_INFO_CLASS UmsThreadInfoClass, PVOID UmsThreadInformation, ULONG UmsThreadInformationLength,
		// PULONG ReturnLength );
		[DllImport(Lib.Kernel32, SetLastError = true, ExactSpelling = true)]
		[PInvokeData("winbase.h", MSDNShortId = "5f694edf-ba5e-45a2-a938-5013edddcae2")]
		[return: MarshalAs(UnmanagedType.Bool)]
		public static extern bool QueryUmsThreadInformation(PUMS_CONTEXT UmsThread, RTL_UMS_THREAD_INFO_CLASS UmsThreadInfoClass, IntPtr UmsThreadInformation, uint UmsThreadInformationLength, out uint ReturnLength);

		/// <summary>Retrieves information about the specified user-mode scheduling (UMS) worker thread.</summary>
		/// <typeparam name="T">The return type being requested.</typeparam>
		/// <param name="UmsThread">A pointer to a UMS thread context.</param>
		/// <param name="UmsThreadInfoClass">A UMS_THREAD_INFO_CLASS value that specifies the kind of information to retrieve.</param>
		/// <returns>The specified information of type <typeparamref name="T"/>.</returns>
		/// <remarks>
		/// <para>
		/// The <c>QueryUmsThreadInformation</c> function retrieves information about the specified UMS worker thread such as its
		/// application-defined context, its thread execution block (TEB), and whether the thread is suspended or terminated.
		/// </para>
		/// <para>
		/// The underlying structures for UMS worker threads are managed by the system. Information that is not exposed through
		/// <c>QueryUmsThreadInformation</c> should be considered reserved.
		/// </para>
		/// </remarks>
		public static T QueryUmsThreadInformation<T>(PUMS_CONTEXT UmsThread, RTL_UMS_THREAD_INFO_CLASS UmsThreadInfoClass) where T : struct
		{
			if (!CorrespondingTypeAttribute.CanGet(UmsThreadInfoClass, typeof(T))) throw new ArgumentException($"Cannot use {UmsThreadInfoClass} to retrieve a value of {typeof(T).Name}.");
			if (!QueryUmsThreadInformation(UmsThread, UmsThreadInfoClass, IntPtr.Zero, 0, out var sz) && sz == 0)
				Win32Error.ThrowLastError();
			using (var mem = new SafeHGlobalHandle(sz))
			{
				if (!QueryUmsThreadInformation(UmsThread, UmsThreadInfoClass, mem, mem.Size, out sz))
					Win32Error.ThrowLastError();
				return typeof(T) == typeof(bool) ? (T)(object)(mem.ToStructure<uint>() != 0) : mem.ToStructure<T>();
			}
		}

		/// <summary>Sets application-specific context information for the specified user-mode scheduling (UMS) worker thread.</summary>
		/// <param name="UmsThread">A pointer to a UMS thread context.</param>
		/// <param name="UmsThreadInfoClass">
		/// A UMS_THREAD_INFO_CLASS value that specifies the kind of information to set. This parameter must be <c>UmsThreadUserContext</c>.
		/// </param>
		/// <param name="UmsThreadInformation">A pointer to a buffer that contains the information to set.</param>
		/// <param name="UmsThreadInformationLength">The size of the UmsThreadInformation buffer, in bytes.</param>
		/// <returns>
		/// <para>If the function succeeds, it returns a nonzero value.</para>
		/// <para>
		/// If the function fails, the return value is zero. To get extended error information, call GetLastError. Possible error values
		/// include the following.
		/// </para>
		/// <list type="table">
		/// <listheader>
		/// <term>Return code</term>
		/// <term>Description</term>
		/// </listheader>
		/// <item>
		/// <term>ERROR_INFO_LENGTH_MISMATCH</term>
		/// <term>The buffer size does not match the required size for the specified information class.</term>
		/// </item>
		/// <item>
		/// <term>ERROR_INVALID_INFO_CLASS</term>
		/// <term>The UmsThreadInfoClass parameter specifies an information class that is not supported.</term>
		/// </item>
		/// </list>
		/// </returns>
		/// <remarks>
		/// <para>
		/// The <c>SetUmsThreadInformation</c> function can be used to set an application-defined context for the specified UMS worker
		/// thread. The context information can consist of anything the application might find useful to track, such as per-scheduler or
		/// per-worker thread state. The underlying structures for UMS worker threads are managed by the system and should not be modified directly.
		/// </para>
		/// <para>
		/// The QueryUmsThreadInformation function can be used to retrieve other exposed information about the specified thread, such as its
		/// thread execution block (TEB) and whether the thread is suspended or terminated. Information that is not exposed through
		/// <c>QueryUmsThreadInformation</c> should be considered reserved.
		/// </para>
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows/desktop/api/winbase/nf-winbase-setumsthreadinformation BOOL SetUmsThreadInformation(
		// PUMS_CONTEXT UmsThread, UMS_THREAD_INFO_CLASS UmsThreadInfoClass, PVOID UmsThreadInformation, ULONG UmsThreadInformationLength );
		[DllImport(Lib.Kernel32, SetLastError = true, ExactSpelling = true)]
		[PInvokeData("winbase.h", MSDNShortId = "19f190fd-1f78-4bb6-93eb-73a5c522b44d")]
		[return: MarshalAs(UnmanagedType.Bool)]
		public static extern bool SetUmsThreadInformation(PUMS_CONTEXT UmsThread, RTL_UMS_THREAD_INFO_CLASS UmsThreadInfoClass, IntPtr UmsThreadInformation, uint UmsThreadInformationLength);

		/// <summary>
		/// <para>Yields control to the user-mode scheduling (UMS) scheduler thread on which the calling UMS worker thread is running.</para>
		/// </summary>
		/// <param name="SchedulerParam">
		/// <para>A parameter to pass to the scheduler thread's UmsSchedulerProc function.</para>
		/// </param>
		/// <returns>
		/// <para>If the function succeeds, it returns a nonzero value.</para>
		/// <para>If the function fails, the return value is zero. To get extended error information, call GetLastError.</para>
		/// </returns>
		/// <remarks>
		/// <para>
		/// A UMS worker thread calls the <c>UmsThreadYield</c> function to cooperatively yield control to the UMS scheduler thread on which
		/// the worker thread is running. If a UMS worker thread never calls <c>UmsThreadYield</c>, the worker thread runs until it either
		/// blocks or is terminated.
		/// </para>
		/// <para>
		/// When control switches to the UMS scheduler thread, the system calls the associated scheduler entry point function with the reason
		/// <c>UmsSchedulerThreadYield</c> and the ScheduleParam parameter specified by the worker thread in the <c>UmsThreadYield</c> call.
		/// </para>
		/// <para>The application's scheduler is responsible for rescheduling the worker thread.</para>
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows/desktop/api/winbase/nf-winbase-umsthreadyield BOOL UmsThreadYield( PVOID SchedulerParam );
		[DllImport(Lib.Kernel32, SetLastError = true, ExactSpelling = true)]
		[PInvokeData("winbase.h", MSDNShortId = "d7c94ed5-9536-4c39-8658-27e4237cc9ba")]
		[return: MarshalAs(UnmanagedType.Bool)]
		public static extern bool UmsThreadYield(IntPtr SchedulerParam);

		/// <summary>Provides a handle to a completion list.</summary>
		[StructLayout(LayoutKind.Sequential)]
		public struct PUMS_COMPLETION_LIST : IHandle
		{
			private IntPtr handle;

			/// <summary>Initializes a new instance of the <see cref="PUMS_COMPLETION_LIST"/> struct.</summary>
			/// <param name="preexistingHandle">An <see cref="IntPtr"/> object that represents the pre-existing handle to use.</param>
			public PUMS_COMPLETION_LIST(IntPtr preexistingHandle) => handle = preexistingHandle;

			/// <summary>Returns an invalid handle by instantiating a <see cref="PUMS_COMPLETION_LIST"/> object with <see cref="IntPtr.Zero"/>.</summary>
			public static PUMS_COMPLETION_LIST NULL => new PUMS_COMPLETION_LIST(IntPtr.Zero);

			/// <summary>Gets a value indicating whether this instance is a null handle.</summary>
			public bool IsNull => handle == IntPtr.Zero;

			/// <summary>Performs an explicit conversion from <see cref="PUMS_COMPLETION_LIST"/> to <see cref="IntPtr"/>.</summary>
			/// <param name="h">The handle.</param>
			/// <returns>The result of the conversion.</returns>
			public static explicit operator IntPtr(PUMS_COMPLETION_LIST h) => h.handle;

			/// <summary>Performs an implicit conversion from <see cref="IntPtr"/> to <see cref="PUMS_COMPLETION_LIST"/>.</summary>
			/// <param name="h">The pointer to a handle.</param>
			/// <returns>The result of the conversion.</returns>
			public static implicit operator PUMS_COMPLETION_LIST(IntPtr h) => new PUMS_COMPLETION_LIST(h);

			/// <summary>Implements the operator !=.</summary>
			/// <param name="h1">The first handle.</param>
			/// <param name="h2">The second handle.</param>
			/// <returns>The result of the operator.</returns>
			public static bool operator !=(PUMS_COMPLETION_LIST h1, PUMS_COMPLETION_LIST h2) => !(h1 == h2);

			/// <summary>Implements the operator ==.</summary>
			/// <param name="h1">The first handle.</param>
			/// <param name="h2">The second handle.</param>
			/// <returns>The result of the operator.</returns>
			public static bool operator ==(PUMS_COMPLETION_LIST h1, PUMS_COMPLETION_LIST h2) => h1.Equals(h2);

			/// <inheritdoc/>
			public override bool Equals(object obj) => obj is PUMS_COMPLETION_LIST h ? handle == h.handle : false;

			/// <inheritdoc/>
			public override int GetHashCode() => handle.GetHashCode();

			/// <inheritdoc/>
			public IntPtr DangerousGetHandle() => handle;
		}

		/// <summary>Provides a handle to a UMS context.</summary>
		[StructLayout(LayoutKind.Sequential)]
		public struct PUMS_CONTEXT : IHandle
		{
			private IntPtr handle;

			/// <summary>Initializes a new instance of the <see cref="PUMS_CONTEXT"/> struct.</summary>
			/// <param name="preexistingHandle">An <see cref="IntPtr"/> object that represents the pre-existing handle to use.</param>
			public PUMS_CONTEXT(IntPtr preexistingHandle) => handle = preexistingHandle;

			/// <summary>Returns an invalid handle by instantiating a <see cref="PUMS_CONTEXT"/> object with <see cref="IntPtr.Zero"/>.</summary>
			public static PUMS_CONTEXT NULL => new PUMS_CONTEXT(IntPtr.Zero);

			/// <summary>Gets a value indicating whether this instance is a null handle.</summary>
			public bool IsNull => handle == IntPtr.Zero;

			/// <summary>Gets a value indicating whether this instance is suspended.</summary>
			/// <value><c>true</c> if this instance is suspended; otherwise, <c>false</c>.</value>
			public bool IsSuspended => QueryUmsThreadInformation<bool>(this, RTL_UMS_THREAD_INFO_CLASS.UmsThreadIsSuspended);

			/// <summary>Gets a value indicating whether this instance is terminated.</summary>
			/// <value><c>true</c> if this instance is terminated; otherwise, <c>false</c>.</value>
			public bool IsTerminated => QueryUmsThreadInformation<bool>(this, RTL_UMS_THREAD_INFO_CLASS.UmsThreadIsTerminated);

			/// <summary>Performs an explicit conversion from <see cref="PUMS_CONTEXT"/> to <see cref="IntPtr"/>.</summary>
			/// <param name="h">The handle.</param>
			/// <returns>The result of the conversion.</returns>
			public static explicit operator IntPtr(PUMS_CONTEXT h) => h.handle;

			/// <summary>Performs an implicit conversion from <see cref="IntPtr"/> to <see cref="PUMS_CONTEXT"/>.</summary>
			/// <param name="h">The pointer to a handle.</param>
			/// <returns>The result of the conversion.</returns>
			public static implicit operator PUMS_CONTEXT(IntPtr h) => new PUMS_CONTEXT(h);

			/// <summary>Implements the operator !=.</summary>
			/// <param name="h1">The first handle.</param>
			/// <param name="h2">The second handle.</param>
			/// <returns>The result of the operator.</returns>
			public static bool operator !=(PUMS_CONTEXT h1, PUMS_CONTEXT h2) => !(h1 == h2);

			/// <summary>Implements the operator ==.</summary>
			/// <param name="h1">The first handle.</param>
			/// <param name="h2">The second handle.</param>
			/// <returns>The result of the operator.</returns>
			public static bool operator ==(PUMS_CONTEXT h1, PUMS_CONTEXT h2) => h1.Equals(h2);

			/// <inheritdoc/>
			public override bool Equals(object obj) => obj is PUMS_CONTEXT h ? handle == h.handle : false;

			/// <inheritdoc/>
			public override int GetHashCode() => handle.GetHashCode();

			/// <inheritdoc/>
			public IntPtr DangerousGetHandle() => handle;
		}

		/// <summary>
		/// Specifies attributes for a user-mode scheduling (UMS) scheduler thread. The EnterUmsSchedulingMode function uses this structure.
		/// </summary>
		// https://docs.microsoft.com/en-us/windows/desktop/api/winbase/ns-winbase-_ums_scheduler_startup_info typedef struct
		// _UMS_SCHEDULER_STARTUP_INFO { ULONG UmsVersion; PUMS_COMPLETION_LIST CompletionList; PUMS_SCHEDULER_ENTRY_POINT SchedulerProc;
		// PVOID SchedulerParam; } UMS_SCHEDULER_STARTUP_INFO, *PUMS_SCHEDULER_STARTUP_INFO;
		[PInvokeData("winbase.h", MSDNShortId = "e3f7b1b7-d2b8-432d-bce7-3633292e855b")]
		[StructLayout(LayoutKind.Sequential, CharSet = CharSet.Auto)]
		public struct UMS_SCHEDULER_STARTUP_INFO
		{
			/// <summary>The UMS version for which the application was built. This parameter must be <c>UMS_VERSION (0x0100)</c>.</summary>
			public uint UmsVersion;

			/// <summary>A pointer to a UMS completion list to associate with the calling thread.</summary>
			public PUMS_COMPLETION_LIST CompletionList;

			/// <summary>
			/// A pointer to an application-defined UmsSchedulerProc entry point function. The system calls this function when the calling
			/// thread has been converted to UMS and is ready to run UMS worker threads. Subsequently, it calls this function when a UMS
			/// worker thread running on the calling thread yields or blocks.
			/// </summary>
			public RtlUmsSchedulerEntryPoint SchedulerProc;

			/// <summary>An application-defined parameter to pass to the specified UmsSchedulerProc function.</summary>
			public IntPtr SchedulerParam;

			/// <summary>Initializes a new instance of the <see cref="UMS_SCHEDULER_STARTUP_INFO"/> struct.</summary>
			/// <param name="schedulerProc">A pointer to an application-defined UmsSchedulerProc entry point function.</param>
			/// <param name="param">An application-defined parameter to pass to the specified UmsSchedulerProc function.</param>
			/// <param name="completionList">A pointer to a UMS completion list to associate with the calling thread.</param>
			public UMS_SCHEDULER_STARTUP_INFO(RtlUmsSchedulerEntryPoint schedulerProc, [Optional] IntPtr param, [Optional] PUMS_COMPLETION_LIST completionList)
			{
				UmsVersion = UMS_VERSION;
				CompletionList = completionList;
				SchedulerProc = schedulerProc;
				SchedulerParam = param;
			}
		}

		/// <summary>
		/// Specifies a UMS scheduler thread, UMS worker thread, or non-UMS thread. The GetUmsSystemThreadInformation function uses this structure.
		/// </summary>
		/// <remarks>
		/// <para>If both <c>IsUmsSchedulerThread</c> and <c>IsUmsWorkerThread</c> are clear, the structure specifies a non-UMS thread.</para>
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows/desktop/api/winbase/ns-winbase-_ums_system_thread_information typedef struct
		// _UMS_SYSTEM_THREAD_INFORMATION { ULONG UmsVersion; union { struct { ULONG IsUmsSchedulerThread : 1; ULONG IsUmsWorkerThread : 1; }
		// DUMMYSTRUCTNAME; ULONG ThreadUmsFlags; } DUMMYUNIONNAME; } UMS_SYSTEM_THREAD_INFORMATION, *PUMS_SYSTEM_THREAD_INFORMATION;
		[PInvokeData("winbase.h", MSDNShortId = "eecdc592-5046-47c3-a4c6-ecb10899db3c")]
		[StructLayout(LayoutKind.Sequential)]
		public struct UMS_SYSTEM_THREAD_INFORMATION
		{
			/// <summary>
			/// <para>The UMS version. This member must be UMS_VERSION.</para>
			/// </summary>
			public uint UmsVersion;

			/// <summary>A bitfield that specifies a UMS thread type.</summary>
			public ThreadUmsFlags ThreadUmsFlags;

			/// <summary>Gets a default instance of this structure with the fields pre-set to default values.</summary>
			public static readonly UMS_SYSTEM_THREAD_INFORMATION Default = new UMS_SYSTEM_THREAD_INFORMATION { UmsVersion = UMS_VERSION };
		}

		/// <summary>
		/// Provides a <see cref="SafeHandle"/> to a UMS completion list that releases a created UmsCompletionList instance at disposal using DeleteUmsCompletionList.
		/// </summary>
		public class SafePUMS_COMPLETION_LIST : SafeHANDLE
		{
			/// <summary>Initializes a new instance of the <see cref="SafePUMS_COMPLETION_LIST"/> class and assigns an existing handle.</summary>
			/// <param name="preexistingHandle">An <see cref="IntPtr"/> object that represents the pre-existing handle to use.</param>
			/// <param name="ownsHandle">
			/// <see langword="true"/> to reliably release the handle during the finalization phase; otherwise, <see langword="false"/> (not recommended).
			/// </param>
			public SafePUMS_COMPLETION_LIST(IntPtr preexistingHandle, bool ownsHandle = true) : base(preexistingHandle, ownsHandle) { }

			/// <summary>Initializes a new instance of the <see cref="SafePUMS_COMPLETION_LIST"/> class.</summary>
			private SafePUMS_COMPLETION_LIST() : base() { }

			/// <summary>Converts to PUMS_COMPLETION_LIST.</summary>
			/// <param name="l">Safe list.</param>
			public static implicit operator PUMS_COMPLETION_LIST(SafePUMS_COMPLETION_LIST l) => l.handle;

			/// <inheritdoc/>
			protected override bool InternalReleaseHandle() => DeleteUmsCompletionList(handle);
		}

		/// <summary>
		/// Provides a <see cref="SafeHandle"/> to a UMS thread context that releases a created UmsThreadContext instance at disposal using DeleteUmsThreadContext.
		/// </summary>
		public class SafePUMS_CONTEXT : SafeHANDLE
		{
			/// <summary>Initializes a new instance of the <see cref="SafePUMS_CONTEXT"/> class and assigns an existing handle.</summary>
			/// <param name="preexistingHandle">An <see cref="IntPtr"/> object that represents the pre-existing handle to use.</param>
			/// <param name="ownsHandle">
			/// <see langword="true"/> to reliably release the handle during the finalization phase; otherwise, <see langword="false"/> (not recommended).
			/// </param>
			public SafePUMS_CONTEXT(IntPtr preexistingHandle, bool ownsHandle = true) : base(preexistingHandle, ownsHandle) { }

			/// <summary>Initializes a new instance of the <see cref="SafePUMS_CONTEXT"/> class.</summary>
			private SafePUMS_CONTEXT() : base() { }

			/// <summary>Converts to PUMS_CONTEXT.</summary>
			/// <param name="c">Safe context.</param>
			public static implicit operator PUMS_CONTEXT(SafePUMS_CONTEXT c) => c.handle;

			/// <inheritdoc/>
			protected override bool InternalReleaseHandle() => DeleteUmsThreadContext(handle);
		}
	}
}