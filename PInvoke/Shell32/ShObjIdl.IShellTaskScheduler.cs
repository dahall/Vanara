namespace Vanara.PInvoke;

public static partial class Shell32
{
	/// <summary>Accept the default priority assigned to the task by the scheduler.</summary>
	public const uint ITSAT_DEFAULT_PRIORITY = 0x10000000;

	/// <summary>High priority.</summary>
	public const uint ITSAT_MAX_PRIORITY = 0x7fffffff;

	/// <summary>Low priority.</summary>
	public const uint ITSAT_MIN_PRIORITY = 0x00000000;

	/// <summary>Default milliseconds until a sleeping worker thread is released</summary>
	public const uint ITSS_THREAD_DESTROY_DEFAULT_TIMEOUT = 10 * 1000;

	/// <summary>Set sleeping worker threads to never be released.</summary>
	public const uint ITSS_THREAD_TERMINATE_TIMEOUT = Kernel32.INFINITE;

	/// <summary>No change to the thread timeout</summary>
	public const uint ITSS_THREAD_TIMEOUT_NO_CHANGE = Kernel32.INFINITE - 1;

	/// <summary>Default value for <see cref="IShellTaskScheduler.AddTask(IRunnableTask, in Guid, IntPtr, uint)"/><c>lParam</c> parameter.</summary>
	public static readonly IntPtr ITSAT_DEFAULT_LPARAM = (IntPtr)(-1);

	/// <summary>Indicates the current execution state.</summary>
	[PInvokeData("shobjidl_core.h", MSDNShortId = "NN:shobjidl_core.IRunnableTask")]
	public enum IRTIR_TASK
	{
		/// <summary>Extraction has not yet started.</summary>
		IRTIR_TASK_NOT_RUNNING = 0,

		/// <summary>The task is running.</summary>
		IRTIR_TASK_RUNNING = 1,

		/// <summary>The task is suspended.</summary>
		IRTIR_TASK_SUSPENDED = 2,

		/// <summary>IRunnableTask::Kill has been called on the thread, but the thread has not yet completely shut down.</summary>
		IRTIR_TASK_PENDING = 3,

		/// <summary>The task is finished.</summary>
		IRTIR_TASK_FINISHED = 4
	}

	/// <summary>The release status for <see cref="IShellTaskScheduler.Status(uint, uint)"/>.</summary>
	[PInvokeData("shobjidl_core.h", MSDNShortId = "NN:shobjidl_core.IShellTaskScheduler")]
	[Flags]
	public enum ITSSFLAG : uint
	{
		/// <summary>Wait for the current task to complete before deleting the scheduler.</summary>
		ITSSFLAG_COMPLETE_ON_DESTROY = 0x0000,

		/// <summary>Immediately cease execution of the current task when the IShellTaskScheduler instance is released.</summary>
		ITSSFLAG_KILL_ON_DESTROY = 0x0001
	}

	/// <summary>
	/// A free-threaded interface that can be exposed by an object to allow operations to be performed on a background thread. For
	/// example, if the IExtractImage::GetLocation method returns E_PENDING, the calling application is permitted to extract the image
	/// on a background thread.
	/// </summary>
	/// <remarks>
	/// <para>
	/// Implement <c>IRunnableTask</c> if your namespace extension is free-threaded, and you want to allow a task such as icon
	/// extraction to be managed by a scheduler. Only the Run and IsRunning methods must be implemented. If you do not want to implement
	/// Kill, Resume, and Suspend, simply have them return E_NOTIMPL.
	/// </para>
	/// <para>
	/// If you are using <c>IRunnableTask</c> to extract an image on a background thread, that is, if the object exposes IExtractImage,
	/// then Run is not necessary, as the system will use IExtractImage::Extract to manage the task. The other methods (Kill, Resume,
	/// and Suspend) are optional in this case, but will be used by the system if they are implemented.
	/// </para>
	/// <para>
	/// You do not call this interface directly. <c>IRunnableTask</c> is used by the operating system only when it has confirmed that
	/// your application is aware of this interface.
	/// </para>
	/// <para><c>IRunnableTask</c> implements IUnknown as well as the five listed methods.</para>
	/// <para><c>Note</c><c>Windows Vista and later.</c> Prior to Windows Vista this interface was declared in Shlobj.h.</para>
	/// </remarks>
	// https://docs.microsoft.com/en-us/windows/win32/api/shobjidl_core/nn-shobjidl_core-irunnabletask
	[PInvokeData("shobjidl_core.h", MSDNShortId = "NN:shobjidl_core.IRunnableTask")]
	[ComImport, Guid("85788d00-6807-11d0-b810-00c04fd706ec"), InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
	public interface IRunnableTask
	{
		/// <summary>Requests that a task begin.</summary>
		/// <returns>
		/// <para>Type: <c>HRESULT</c></para>
		/// <para>Returns one of the following two codes.</para>
		/// <list type="table">
		/// <listheader>
		/// <term>Return code</term>
		/// <term>Description</term>
		/// </listheader>
		/// <item>
		/// <term>S_OK</term>
		/// <term>Execution is complete.</term>
		/// </item>
		/// <item>
		/// <term>E_PENDING</term>
		/// <term>Execution is suspended.</term>
		/// </item>
		/// </list>
		/// </returns>
		/// <remarks>
		/// The return value of this method only tells you whether the execution of the task completed or is suspended. Any other errors
		/// that the implementer needs to communicate to the caller must be provided through other channels, such as a callback function.
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows/win32/api/shobjidl_core/nf-shobjidl_core-irunnabletask-run HRESULT Run();
		[PreserveSig]
		HRESULT Run();

		/// <summary>Requests that a task be stopped.</summary>
		/// <param name="bWait">
		/// <para>Type: <c>BOOL</c></para>
		/// <para>Not currently used.</para>
		/// </param>
		/// <returns>
		/// <para>Type: <c>HRESULT</c></para>
		/// <para>If this method succeeds, it returns <c>S_OK</c>. Otherwise, it returns an <c>HRESULT</c> error code.</para>
		/// </returns>
		/// <remarks>
		/// Implementation of this method is optional. If you do not wish to support this functionality, create a token implementation
		/// that simply returns E_NOTIMPL.
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows/win32/api/shobjidl_core/nf-shobjidl_core-irunnabletask-kill HRESULT Kill( BOOL bWait );
		[PreserveSig]
		HRESULT Kill([MarshalAs(UnmanagedType.Bool)] bool bWait);

		/// <summary>Requests that a task be suspended.</summary>
		/// <returns>
		/// <para>Type: <c>HRESULT</c></para>
		/// <para>Return S_OK if successful, or standard COM-defined error codes otherwise.</para>
		/// </returns>
		/// <remarks>
		/// Implementation of this method is optional. If you do not wish to support this functionality, create a token implementation
		/// that simply returns E_NOTIMPL.
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows/win32/api/shobjidl_core/nf-shobjidl_core-irunnabletask-suspend HRESULT Suspend();
		[PreserveSig]
		HRESULT Suspend();

		/// <summary>Requests that a task resume.</summary>
		/// <returns>
		/// <para>Type: <c>HRESULT</c></para>
		/// <para>Returns S_OK if successful, or standard COM-defined error codes otherwise.</para>
		/// </returns>
		/// <remarks>
		/// Implementation of this method is optional. If you do not wish to support this functionality, create a token implementation
		/// that simply returns E_NOTIMPL.
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows/win32/api/shobjidl_core/nf-shobjidl_core-irunnabletask-resume HRESULT Resume();
		[PreserveSig]
		HRESULT Resume();

		/// <summary>Requests information on the state of a task, such as thumbnail extraction.</summary>
		/// <returns>
		/// <para>Type: <c>LONG</c></para>
		/// <para>Returns one of the following values to indicate the current execution state.</para>
		/// <list type="table">
		/// <listheader>
		/// <term>Return code</term>
		/// <term>Description</term>
		/// </listheader>
		/// <item>
		/// <term>IRTIR_TASK_NOT_RUNNING</term>
		/// <term>Extraction has not yet started.</term>
		/// </item>
		/// <item>
		/// <term>IRTIR_TASK_RUNNING</term>
		/// <term>The task is running.</term>
		/// </item>
		/// <item>
		/// <term>IRTIR_TASK_SUSPENDED</term>
		/// <term>The task is suspended.</term>
		/// </item>
		/// <item>
		/// <term>IRTIR_TASK_PENDING</term>
		/// <term>IRunnableTask::Kill has been called on the thread, but the thread has not yet completely shut down.</term>
		/// </item>
		/// <item>
		/// <term>IRTIR_TASK_FINISHED</term>
		/// <term>The task is finished.</term>
		/// </item>
		/// </list>
		/// </returns>
		/// <remarks>This method must be implemented.</remarks>
		// https://docs.microsoft.com/en-us/windows/win32/api/shobjidl_core/nf-shobjidl_core-irunnabletask-isrunning ULONG IsRunning();
		[PreserveSig]
		IRTIR_TASK IsRunning();
	}

	/// <summary>
	/// <para>
	/// [ <c>IShellTaskScheduler</c> is available for use in the operating systems specified in the Requirements section. It may be
	/// altered or unavailable in subsequent versions.]
	/// </para>
	/// <para>Exposes methods that enable interaction with, and control of, a task scheduler.</para>
	/// </summary>
	/// <remarks>
	/// <para>
	/// This interface does not need to be free-threaded unless the items in the queue interact with the scheduler as well as the main
	/// execution thread on which the task scheduler was created.
	/// </para>
	/// <para>This interface's class identifier (CLSID) is CLSID_ShellTaskScheduler, and its IID is IID_IShellTaskScheduler.</para>
	/// <para><c>Windows Server 2003 and Windows XP:</c><c>IShellTaskScheduler</c> was declared in Shlobj.h.</para>
	/// </remarks>
	// https://docs.microsoft.com/en-us/windows/win32/api/shobjidl_core/nn-shobjidl_core-ishelltaskscheduler
	[PInvokeData("shobjidl_core.h", MSDNShortId = "NN:shobjidl_core.IShellTaskScheduler")]
	[ComImport, Guid("6CCB7BE0-6807-11d0-B810-00C04FD706EC"), InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
	public interface IShellTaskScheduler
	{
		/// <summary>Adds a task to the scheduler's background queue.</summary>
		/// <param name="prt">
		/// <para>Type: <c>IRunnableTask*</c></para>
		/// <para>A pointer to an instance of an IRunnableTask interface representing the task to add to the queue.</para>
		/// </param>
		/// <param name="rtoid">
		/// <para>Type: <c>REFTASKOWNERID</c></para>
		/// <para>
		/// A GUID identifying the owner of the task. This information can be used to group tasks for later counting or removal by owner.
		/// </para>
		/// </param>
		/// <param name="lParam">
		/// <para>Type: <c>DWORD_PTR</c></para>
		/// <para>
		/// A pointer to a user-defined <c>DWORD</c> value allowing the task to be identified within the tasks owned by rtoid. This is
		/// used to identify single tasks or to subgroup them, for instance associating the task with a particular item such as an item
		/// in a ListView. This parameter can be zero.
		/// </para>
		/// </param>
		/// <param name="dwPriority">
		/// <para>Type: <c>DWORD</c></para>
		/// <para>
		/// One of the following values assigning the task's priority. Response to this priority depends on the cooperation of the other
		/// tasks being executed. New tasks are inserted in the queue in priority order. If a task of a low priority is currently under
		/// execution when a higher priority task is added, the scheduler attempts to suspend the task under execution. That lower
		/// priority task is resumed when the higher priority task(s) are completed.
		/// </para>
		/// <para>ITSAT_DEFAULT_PRIORITY</para>
		/// <para>Accept the default priority assigned to the task by the scheduler.</para>
		/// <para>ITSAT_MAX_PRIORITY</para>
		/// <para>High priority.</para>
		/// <para>ITSAT_MIN_PRIORITY</para>
		/// <para>Low priority.</para>
		/// </param>
		// https://docs.microsoft.com/en-us/windows/win32/api/shobjidl_core/nf-shobjidl_core-ishelltaskscheduler-addtask HRESULT
		// AddTask( IRunnableTask *prt, REFTASKOWNERID rtoid, DWORD_PTR lParam, DWORD dwPriority );
		void AddTask([In] IRunnableTask prt, in Guid rtoid, [In] IntPtr lParam, [In] uint dwPriority = ITSAT_DEFAULT_PRIORITY);

		/// <summary>Removes tasks from the scheduler's background queue.</summary>
		/// <param name="rtoid">
		/// <para>Type: <c>REFTASKOWNERID</c></para>
		/// <para>A GUID identifying the owner of the tasks to remove.</para>
		/// </param>
		/// <param name="lParam">
		/// <para>Type: <c>DWORD_PTR</c></para>
		/// <para>
		/// A pointer to a user-defined <c>DWORD</c> value that allows the task to be identified within the tasks owned by rtoid. Set
		/// this value to 0 to remove all tasks for the owner specified by rtoid.
		/// </para>
		/// </param>
		/// <param name="bWaitIfRunning">
		/// <para>Type: <c>BOOL</c></para>
		/// <para><c>TRUE</c> if you want a currently running task to complete before removing it, <c>FALSE</c> otherwise.</para>
		/// </param>
		// https://docs.microsoft.com/en-us/windows/win32/api/shobjidl_core/nf-shobjidl_core-ishelltaskscheduler-removetasks HRESULT
		// RemoveTasks( REFTASKOWNERID rtoid, DWORD_PTR lParam, BOOL bWaitIfRunning );
		void RemoveTasks(in Guid rtoid, [In] IntPtr lParam, [MarshalAs(UnmanagedType.Bool)] bool bWaitIfRunning);

		/// <summary>Counts tasks with the same owner ID in the scheduler's queue.</summary>
		/// <param name="rtoid">
		/// <para>Type: <c>REFTASKOWNERID</c></para>
		/// <para>
		/// A GUID identifying the owner of the tasks. Supplying a specific ID will count only those tasks tagged with that owner ID. To
		/// count all items in the queue, pass TOID_NULL.
		/// </para>
		/// </param>
		/// <returns>
		/// <para>Type: <c>HRESULT</c></para>
		/// <para>If this method succeeds, it returns <c>S_OK</c>. Otherwise, it returns an <c>HRESULT</c> error code.</para>
		/// </returns>
		// https://docs.microsoft.com/en-us/windows/win32/api/shobjidl_core/nf-shobjidl_core-ishelltaskscheduler-counttasks UINT
		// CountTasks( REFTASKOWNERID rtoid );
		uint CountTasks(in Guid rtoid);

		/// <summary>Sets the release status and background thread timeout for the current task.</summary>
		/// <param name="dwReleaseStatus">
		/// <para>Type: <c>DWORD</c></para>
		/// <para>The following flag or 0.</para>
		/// <para>ITSSFLAG_KILL_ON_DESTROY</para>
		/// <para>Immediately cease execution of the current task when the IShellTaskScheduler instance is released.</para>
		/// </param>
		/// <param name="dwThreadTimeout">
		/// <para>Type: <c>DWORD</c></para>
		/// <para>Not used.</para>
		/// </param>
		// https://docs.microsoft.com/en-us/windows/win32/api/shobjidl_core/nf-shobjidl_core-ishelltaskscheduler-status HRESULT Status(
		// DWORD dwReleaseStatus, DWORD dwThreadTimeout );
		void Status([In] uint dwReleaseStatus, [In, Optional] uint dwThreadTimeout);
	}
}