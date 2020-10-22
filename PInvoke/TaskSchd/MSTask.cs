using System;
using System.Diagnostics;
using System.Runtime.InteropServices;
using Vanara.InteropServices;

namespace Vanara.PInvoke
{
	/// <summary>Exposes interfaces for Task Scheduler 1.0.</summary>
	public static class MSTask
	{
		/// <summary>Valid types of triggers</summary>
		public enum TASK_TRIGGER_TYPE
		{
			/// <summary>Trigger is set to run the task a single time.</summary>
			TASK_TIME_TRIGGER_ONCE = 0,

			/// <summary>Trigger is set to run the task on a daily interval.</summary>
			TASK_TIME_TRIGGER_DAILY = 1,

			/// <summary>Trigger is set to run the work item on specific days of a specific week of a specific month.</summary>
			TASK_TIME_TRIGGER_WEEKLY = 2,

			/// <summary>Trigger is set to run the task on a specific day(s) of the month.</summary>
			TASK_TIME_TRIGGER_MONTHLYDATE = 3,

			/// <summary>Trigger is set to run the task on specific days, weeks, and months.</summary>
			TASK_TIME_TRIGGER_MONTHLYDOW = 4,

			/// <summary>
			/// Trigger is set to run the task if the system remains idle for the amount of time specified by the idle wait time of the task.
			/// </summary>
			TASK_EVENT_TRIGGER_ON_IDLE = 5,

			/// <summary>Trigger is set to run the task at system startup.</summary>
			TASK_EVENT_TRIGGER_AT_SYSTEMSTART = 6,

			/// <summary>Trigger is set to run the task when a user logs on.</summary>
			TASK_EVENT_TRIGGER_AT_LOGON = 7
		}

		/// <summary>Specifies the day(s) of the week (specified in wWhichWeek) when the task runs.</summary>
		[Flags]
		[PInvokeData("mstask.h", MSDNShortId = "aa381950")]
		public enum TaskDaysOfTheWeek : ushort
		{
			/// <summary>The task will run on Sunday.</summary>
			TASK_SUNDAY = 0x1,

			/// <summary>The task will run on Monday</summary>
			TASK_MONDAY = 0x2,

			/// <summary>The task will run on Tuesday</summary>
			TASK_TUESDAY = 0x4,

			/// <summary>The task will run on Wednesday</summary>
			TASK_WEDNESDAY = 0x8,

			/// <summary>The task will run on Thursday</summary>
			TASK_THURSDAY = 0x10,

			/// <summary>The task will run on Friday</summary>
			TASK_FRIDAY = 0x20,

			/// <summary>The task will run on Saturday</summary>
			TASK_SATURDAY = 0x40,
		}

		/// <summary>
		/// Options for a task, used for the Flags property of a Task. Uses the "Flags" attribute, so these values are combined with |. Some
		/// flags are documented as Windows 95 only, but they have a user interface in Windows XP so that may not be true.
		/// </summary>
		[Flags]
		[PInvokeData("mstask.h", MSDNShortId = "aa381283")]
		public enum TaskFlags
		{
			/// <summary>
			/// This flag is used when converting Windows NT AT service jobs into work items. The Windows NT AT service job refers to At.exe,
			/// the Windows NT command-line utility used for creating jobs for the Windows NT Schedule service. The Task Scheduler service
			/// replaces the Schedule service and is backward compatible with it. The conversion occurs when the Task Scheduler is installed
			/// on Windows NT/Windows 2000— for example, if you install Internet Explorer 4.0, or upgrade to Windows 2000. During the setup
			/// process, the Task Scheduler installation code searches the registry for jobs created for the AT service and creates work
			/// items that will accomplish the same operation. For such converted jobs, the interactive flag is set if the work item is
			/// intended to be displayed to the user. When this flag is not set, no work items are displayed in the Tasks folder, and no user
			/// interface associated with the work item is presented to the user when the work item is executed.
			/// </summary>
			TASK_FLAG_INTERACTIVE = 0x1,

			/// <summary>The work item will be deleted when there are no more scheduled run times.</summary>
			TASK_FLAG_DELETE_WHEN_DONE = 0x2,

			/// <summary>The work item is disabled. This is useful to temporarily prevent a work item from running at the scheduled time(s).</summary>
			TASK_FLAG_DISABLED = 0x4,

			/// <summary>The task runs only if the system is docked. Windows 95 only.</summary>
			TASK_FLAG_RUN_ONLY_IF_DOCKED = 0x100,

			/// <summary>The work item created will be hidden.</summary>
			TASK_FLAG_HIDDEN = 0x200,

			/// <summary>
			/// The work item runs only if the user specified in IScheduledWorkItem::SetAccountInformation is logged on interactively. This
			/// flag has no effect on the work items that are set to run in the local account.
			/// </summary>
			TASK_FLAG_RUN_ONLY_IF_LOGGED_ON = 0x2000,

			/// <summary>The work item begins only if the computer is not in use at the scheduled start time.</summary>
			TASK_FLAG_START_ONLY_IF_IDLE = 0x10,

			/// <summary>
			/// The work item causes the system to be resumed, or awakened, if the system is running on battery power. This flag is supported
			/// only on systems that support resume timers.
			/// </summary>
			TASK_FLAG_SYSTEM_REQUIRED = 0x1000,

			/// <summary>
			/// The work item terminates if the computer makes an idle to non-idle transition while the work item is running. The computer is
			/// not considered idle until the IdleWait triggers' time elapses with no user input. For information regarding idle triggers,
			/// see Idle Trigger.
			/// </summary>
			TASK_FLAG_KILL_ON_IDLE_END = 0x20,

			/// <summary>
			/// The work item starts again if the computer makes a non-idle to idle transition before all the work item's task_triggers
			/// elapse. (Use this flag in conjunction with TASK_FLAG_KILL_ON_IDLE_END.)
			/// </summary>
			TASK_FLAG_RESTART_ON_IDLE_RESUME = 0x800,

			/// <summary>The work item does not start if its target computer is running on battery power.</summary>
			TASK_FLAG_DONT_START_IF_ON_BATTERIES = 0x40,

			/// <summary>
			/// The work item ends, and the associated application quits if the work item's target computer switches to battery power.
			/// </summary>
			TASK_FLAG_KILL_IF_GOING_ON_BATTERIES = 0x80,

			/// <summary>The work item runs only if there is currently a valid Internet connection.</summary>
			TASK_FLAG_RUN_IF_CONNECTED_TO_INTERNET = 0x400,
		}

		/// <summary>Value that describes the month(s) when the task runs.</summary>
		[Flags]
		public enum TaskMonths : ushort
		{
			/// <summary>The task will run in January.</summary>
			TASK_JANUARY = 0x1,

			/// <summary>The task will run in February</summary>
			TASK_FEBRUARY = 0x2,

			/// <summary>The task will run in March</summary>
			TASK_MARCH = 0x4,

			/// <summary>The task will run in April</summary>
			TASK_APRIL = 0x8,

			/// <summary>The task will run in May</summary>
			TASK_MAY = 0x10,

			/// <summary>The task will run in June</summary>
			TASK_JUNE = 0x20,

			/// <summary>The task will run in July</summary>
			TASK_JULY = 0x40,

			/// <summary>The task will run in August</summary>
			TASK_AUGUST = 0x80,

			/// <summary>The task will run in September</summary>
			TASK_SEPTEMBER = 0x100,

			/// <summary>The task will run in October</summary>
			TASK_OCTOBER = 0x200,

			/// <summary>The task will run in November</summary>
			TASK_NOVEMBER = 0x400,

			/// <summary>The task will run in December</summary>
			TASK_DECEMBER = 0x800,
		}

		/// <summary>
		/// Status values returned for a task. Some values have been determined to occur although they do no appear in the Task Scheduler
		/// system documentation.
		/// </summary>
		public enum TaskStatus : uint
		{
			/// <summary>The task is ready to run at its next scheduled time.</summary>
			Ready = HRESULT.SCHED_S_TASK_READY,

			/// <summary>The task is currently running.</summary>
			Running = HRESULT.SCHED_S_TASK_RUNNING,

			/// <summary>One or more of the properties that are needed to run this task on a schedule have not been set.</summary>
			NotScheduled = HRESULT.SCHED_S_TASK_NOT_SCHEDULED,

			/// <summary>The task has not yet run.</summary>
			NeverRun = HRESULT.SCHED_S_TASK_HAS_NOT_RUN,

			/// <summary>The task will not run at the scheduled times because it has been disabled.</summary>
			Disabled = HRESULT.SCHED_S_TASK_DISABLED,

			/// <summary>There are no more runs scheduled for this task.</summary>
			NoMoreRuns = HRESULT.SCHED_S_TASK_NO_MORE_RUNS,

			/// <summary>The last run of the task was terminated by the user.</summary>
			Terminated = HRESULT.SCHED_S_TASK_TERMINATED,

			/// <summary>Either the task has no triggers or the existing triggers are disabled or not set.</summary>
			NoTriggers = HRESULT.SCHED_S_TASK_NO_VALID_TRIGGERS,

			/// <summary>Event triggers don't have set run times.</summary>
			NoTriggerTime = HRESULT.SCHED_S_EVENT_TRIGGER
		}

		/// <summary>Value that describes the behavior of the trigger. This value is a combination of the following flags.</summary>
		[Flags]
		public enum TaskTriggerFlags : uint
		{
			/// <summary>
			/// Trigger structure's end date is valid. If this flag is not set, the end date data is ignored and the trigger will be valid indefinitely.
			/// </summary>
			TASK_TRIGGER_FLAG_HAS_END_DATE = 0x1,

			/// <summary>
			/// Task will be terminated at the end of the active trigger's lifetime. At the duration end, the Task Scheduler sends a WM_CLOSE
			/// message to the associated application. If WM_CLOSE cannot be sent (for example, the application has no windows) or the
			/// application has not exited within three minutes of the receiving WM_CLOSE, the Task Scheduler terminates the application
			/// using TerminateProcess.
			/// </summary>
			TASK_TRIGGER_FLAG_KILL_AT_DURATION_END = 0x2,

			/// <summary>Task trigger is inactive.</summary>
			TASK_TRIGGER_FLAG_DISABLED = 0x4
		}

		/// <summary>Specifies the week of the month when the task runs.</summary>
		public enum TaskWhichWeek : ushort
		{
			/// <summary>The task will run between the first and seventh day of the month.</summary>
			TASK_FIRST_WEEK = 1,

			/// <summary>The task will run between the eighth and 14th day of the month.</summary>
			TASK_SECOND_WEEK = 2,

			/// <summary>The task will run between the 15th and 21st day of the month.</summary>
			TASK_THIRD_WEEK = 3,

			/// <summary>The task will run between the 22nd and 28th of the month.</summary>
			TASK_FOURTH_WEEK = 4,

			/// <summary>The task will run between the last seven days of the month.</summary>
			TASK_LAST_WEEK = 5,
		}

		/// <summary>
		/// Provides the methods for enumerating the tasks in the Scheduled Tasks folder.
		/// <para>IEnumWorkItems is the primary interface of the enumeration object. To create the enumeration, call ITaskScheduler::Enum.</para>
		/// </summary>
		[Guid("148BD528-A2AB-11CE-B11F-00AA00530503"), InterfaceType(ComInterfaceType.InterfaceIsIUnknown), System.Security.SuppressUnmanagedCodeSecurity]
		[PInvokeData("mstask.h", MSDNShortId = "aa380706")]
		public interface IEnumWorkItems
		{
			/// <summary>
			/// Creates a new enumeration object that contains the same enumeration state as the current enumeration. Because the new object
			/// points to the same place in the enumeration sequence, a client can use the Clone method to record a particular point in the
			/// enumeration sequence and return to that point later.
			/// </summary>
			/// <returns>
			/// A pointer to a pointer to a new IEnumWorkItems interface. This pointer will point to the newly created enumeration. If the
			/// method fails, this parameter is undefined.
			/// </returns>
			[return: MarshalAs(UnmanagedType.Interface)]
			IEnumWorkItems Clone();

			/// <summary>
			/// <para>
			/// [[This API may be altered or unavailable in subsequent versions of the operating system or product. Please use the Task
			/// Scheduler 2.0 Interfaces instead.] ]
			/// </para>
			/// <para>Retrieves the next specified number of tasks in the enumeration sequence.</para>
			/// <para>If there are fewer than the requested number of tasks left in the sequence, all the remaining elements are retrieved.</para>
			/// </summary>
			/// <param name="celt">
			/// <para>The number of tasks to retrieve.</para>
			/// </param>
			/// <param name="rgpwszNames">
			/// <para>
			/// A pointer to an array of pointers ( <c>LPWSTR</c>) to <c>null</c>-terminated character strings containing the file names of
			/// the tasks returned from the enumeration sequence. These file names are taken from the Scheduled Tasks folder and have the
			/// ".job" extension.
			/// </para>
			/// <para>
			/// After processing the names returned in rgpwszNames, you must first free each character string in the array and then the array
			/// itself using <c>CoTaskMemFree</c>.
			/// </para>
			/// </param>
			/// <param name="pceltFetched">
			/// <para>A pointer to the number of tasks returned in rgpwszNames. If the celt parameter is 1, this parameter may be <c>NULL</c>.</para>
			/// </param>
			/// <returns>
			/// <para>Returns one of the following values.</para>
			/// <list type="table">
			/// <listheader>
			/// <term>Return code</term>
			/// <term>Description</term>
			/// </listheader>
			/// <item>
			/// <term>S_OK</term>
			/// <term>The number of tasks retrieved equals the number requested.</term>
			/// </item>
			/// <item>
			/// <term>S_FALSE</term>
			/// <term>The number returned is less than the number requested. (Thus, there are no more tasks to enumerate.)</term>
			/// </item>
			/// <item>
			/// <term>E_INVALIDARG</term>
			/// <term>A parameter is invalid.</term>
			/// </item>
			/// <item>
			/// <term>E_OUTOFMEMORY</term>
			/// <term>Not enough memory is available.</term>
			/// </item>
			/// </list>
			/// </returns>
			/// <remarks>
			/// <para>
			/// The IEnumWorkItems interface also provides methods for resetting the enumeration, skipping tasks, and making a copy of the
			/// current state of the enumeration.
			/// </para>
			/// <para>Examples</para>
			/// <para>
			/// For an example of how to use <c>Next</c> to enumerate the tasks in the Scheduled Tasks folder, see Enumerating Tasks Example.
			/// </para>
			/// </remarks>
			// https://docs.microsoft.com/en-us/windows/desktop/api/mstask/nf-mstask-ienumworkitems-next HRESULT Next( ULONG celt, LPWSTR
			// **rgpwszNames, ULONG *pceltFetched );
			[PInvokeData("mstask.h", MSDNShortId = "a606e340-33fb-4a51-acdd-b7428c755ac5")]
			HRESULT Next([In] uint celt, [Out] out IntPtr rgpwszNames, [Out] out uint pceltFetched);

			/// <summary>Resets the enumeration sequence to the beginning.</summary>
			void Reset();

			/// <summary>Skips the next specified number of tasks in the enumeration sequence.</summary>
			/// <param name="celt">The number of tasks to be skipped.</param>
			void Skip([In] uint celt);
		}

		/// <summary>
		/// Provides the methods for running tasks, getting or setting task information, and terminating tasks. It is derived from the
		/// IScheduledWorkItem interface and inherits all the methods of that interface.
		/// </summary>
		[ComImport, Guid("148BD524-A2AB-11CE-B11F-00AA00530503"), InterfaceType(ComInterfaceType.InterfaceIsIUnknown), System.Security.SuppressUnmanagedCodeSecurity, CoClass(typeof(CTask))]
		[PInvokeData("mstask.h", MSDNShortId = "aa381311")]
		public interface ITask
		{
			/// <summary>Creates a trigger using a work item object.</summary>
			/// <param name="piNewTrigger">
			/// A pointer to the returned trigger index value of the new trigger. The trigger index for the first trigger associated with a
			/// work item is "0". See Remarks for other uses of the trigger index.
			/// </param>
			/// <returns>An ITaskTrigger interface. Currently, the only supported work items are tasks.</returns>
			[return: MarshalAs(UnmanagedType.Interface)]
			ITaskTrigger CreateTrigger([Out] out ushort piNewTrigger);

			/// <summary>Deletes a trigger from a work item.</summary>
			/// <param name="iTrigger">A trigger index value that specifies the trigger to be deleted. For more information, see Remarks.</param>
			void DeleteTrigger([In] ushort iTrigger);

			/// <summary>Retrieves the number of triggers for the current work item.</summary>
			/// <returns>A WORD that will contain the number of triggers associated with the work item.</returns>
			[return: MarshalAs(UnmanagedType.U2)]
			ushort GetTriggerCount();

			/// <summary>Retrieves a task trigger.</summary>
			/// <param name="iTrigger">The index of the trigger to retrieve.</param>
			/// <returns>An ITaskTrigger interface for the retrieved trigger.</returns>
			[return: MarshalAs(UnmanagedType.Interface)]
			ITaskTrigger GetTrigger([In] ushort iTrigger);

			/// <summary>Retrieves a string that describes the work item trigger.</summary>
			/// <param name="iTrigger">
			/// The index of the trigger to be retrieved. The first trigger is always referenced by 0. For more information, see Remarks.
			/// </param>
			/// <returns>
			/// A pointer to a null-terminated string that contains the retrieved trigger description. Note that this string must be release
			/// by a call to CoTaskMemFree after the string is no longer needed.
			/// </returns>
			[return: MarshalAs(UnmanagedType.LPWStr)]
			string GetTriggerString([In] ushort iTrigger);

			/// <summary>Retrieves the work item run times for a specified time period.</summary>
			/// <param name="pstBegin">
			/// A pointer to a SYSTEMTIME structure that contains the starting time of the time period to check. This value is inclusive.
			/// </param>
			/// <param name="pstEnd">
			/// A pointer to a SYSTEMTIME structure that contains the ending time of the time period to check. This value is exclusive. If
			/// NULL is passed for this value, the end time is infinite.
			/// </param>
			/// <param name="pCount">
			/// A pointer to a WORD value that specifies the number of run times to retrieve.
			/// <para>On input, this parameter contains the number of run times being requested. This can be a number of between 1 and TASK_MAX_RUN_TIMES.</para>
			/// <para>On output, this parameter contains the number of run times retrieved.</para>
			/// </param>
			/// <returns>
			/// A pointer to an array of SYSTEMTIME structures. A NULL LPSYSTEMTIME object should be passed into this parameter. On return,
			/// this array contains pCount run times. You must free this array by a calling the CoTaskMemFree function.
			/// </returns>
			SafeCoTaskMemHandle GetRunTimes(in SYSTEMTIME pstBegin, in SYSTEMTIME pstEnd, ref ushort pCount);

			/// <summary>Retrieves the next time the work item will run.</summary>
			/// <returns>A pointer to a SYSTEMTIME structure that contains the next time the work item will run.</returns>
			[return: MarshalAs(UnmanagedType.Struct)]
			SYSTEMTIME GetNextRunTime();

			/// <summary>Sets the minutes that the system must be idle before the work item can run.</summary>
			/// <param name="wIdleMinutes">
			/// A value that specifies how long, in minutes, the system must remain idle before the work item can run.
			/// </param>
			/// <param name="wDeadlineMinutes">
			/// A value that specifies the maximum number of minutes that the Task Scheduler will wait for the idle-time period returned in pwIdleMinutes.
			/// </param>
			void SetIdleWait([In] ushort wIdleMinutes, [In] ushort wDeadlineMinutes);

			/// <summary>Retrieves the idle wait time for the work item. For information about idle conditions, see Task Idle Conditions.</summary>
			/// <param name="wIdleMinutes">A pointer to a WORD that contains the idle wait time for the current work item, in minutes.</param>
			/// <param name="wDeadlineMinutes">
			/// A pointer to a WORD that specifies the maximum number of minutes that the Task Scheduler will wait for the idle-time period
			/// returned in pwIdleMinutes.
			/// </param>
			void GetIdleWait([Out] out ushort wIdleMinutes, [Out] out ushort wDeadlineMinutes);

			/// <summary>Sends a request to the Task Scheduler service to run the work item.</summary>
			void Run();

			/// <summary>This method ends the execution of the work item.</summary>
			void Terminate();

			/// <summary>
			/// Displays the Task, Schedule, and settings property pages for the work item, allowing a user set the properties on those pages.
			/// </summary>
			/// <param name="hParent">Reserved for future use. Set this parameter to NULL.</param>
			/// <param name="dwReserved">Reserved for internal use; this parameter must be set to zero.</param>
			void EditWorkItem([In] HWND hParent, [In] uint dwReserved);

			/// <summary>Retrieves the most recent time the work item began running.</summary>
			/// <returns>A pointer to a SYSTEMTIME structure that contains the most recent time the current work item ran.</returns>
			[return: MarshalAs(UnmanagedType.Struct)]
			SYSTEMTIME GetMostRecentRunTime();

			/// <summary>Retrieves the status of the work item.</summary>
			/// <returns>A pointer to an HRESULT value.</returns>
			HRESULT GetStatus();

			/// <summary>
			/// Retrieves the last exit code returned by the executable associated with the work item on its last run. The method also
			/// returns the exit code returned to Task Scheduler when it last attempted to run the work item.
			/// </summary>
			/// <returns>
			/// A pointer to a DWORD value that is set to the last exit code for the work item. This is the exit code that the work item
			/// returned when it last stopped running. If the work item has never been started, 0 is returned.
			/// </returns>
			uint GetExitCode();

			/// <summary>Sets the comment for the work item.</summary>
			/// <param name="pwszComment">A null-terminated string that specifies the comment for the current work item.</param>
			void SetComment([In, MarshalAs(UnmanagedType.LPWStr)] string pwszComment);

			/// <summary>Retrieves the comment for the work item.</summary>
			/// <returns>A pointer to a null-terminated string that contains the retrieved comment for the current work item.</returns>
			[return: MarshalAs(UnmanagedType.LPWStr)]
			string GetComment();

			/// <summary>Sets the name of the work item's creator.</summary>
			/// <param name="Creator">A null-terminated string that contains the name of the work item's creator.</param>
			void SetCreator([In, MarshalAs(UnmanagedType.LPWStr)] string Creator);

			/// <summary>Retrieves the name of the creator of the work item.</summary>
			/// <returns>
			/// A pointer to a null-terminated string that contains the name of the creator of the current work item. The application that
			/// invokes GetCreator is responsible for freeing this string using the CoTaskMemFree function.
			/// </returns>
			[return: MarshalAs(UnmanagedType.LPWStr)]
			string GetCreator();

			/// <summary>This method stores application-defined data associated with the work item.</summary>
			/// <param name="cBytes">The number of bytes in the data buffer. The caller allocates and frees this memory.</param>
			/// <param name="rgbData">The data to copy.</param>
			void SetWorkItemData([In] ushort cBytes, [In, MarshalAs(UnmanagedType.LPArray, SizeParamIndex = 0, ArraySubType = UnmanagedType.U1)] byte[] rgbData);

			/// <summary>Retrieves application-defined data associated with the work item.</summary>
			/// <param name="pcBytes">A pointer to the number of bytes copied.</param>
			/// <param name="ppBytes">
			/// A pointer to a pointer to a BYTE that contains user-defined data for the current work item. The method that invokes
			/// GetWorkItemData is responsible for freeing this memory by using CoTaskMemFree.
			/// </param>
			void GetWorkItemData(out ushort pcBytes, out SafeCoTaskMemHandle ppBytes);

			/// <summary>
			/// Sets the number of times Task Scheduler will try to run the work item again if an error occurs. This method is not implemented.
			/// </summary>
			/// <param name="wRetryCount">A value that specifies the number of error retries for the current work item.</param>
			void SetErrorRetryCount([In] ushort wRetryCount);

			/// <summary>
			/// Retrieves the number of times that the Task Scheduler will retry an operation when an error occurs. This method is not implemented.
			/// </summary>
			/// <returns>A pointer to a WORD that contains the number of times to retry.</returns>
			ushort GetErrorRetryCount();

			/// <summary>
			/// Sets the time interval, in minutes, between Task Scheduler's attempts to run a work item after an error occurs. This method
			/// is not implemented.
			/// </summary>
			/// <param name="wRetryInterval">A value that specifies the interval between error retries for the current work item, in minutes.</param>
			void SetErrorRetryInterval([In] ushort wRetryInterval);

			/// <summary>
			/// Retrieves the time interval, in minutes, between Task Scheduler's attempts to run a work item if an error occurs. This method
			/// is not implemented.
			/// </summary>
			/// <returns>A pointer to a WORD value that contains the time interval between retries of the current work item.</returns>
			ushort GetErrorRetryInterval();

			/// <summary>Sets the flags that modify the behavior of any type of work item.</summary>
			/// <param name="dwFlags">A value that specifies a combination of one or more flags.</param>
			void SetFlags([In] TaskFlags dwFlags);

			/// <summary>Retrieves the flags that modify the behavior of any type of work item.</summary>
			/// <returns>A pointer to a DWORD that contains the flags for the work item. For a list of these flags, see SetFlags.</returns>
			TaskFlags GetFlags();

			/// <summary>Sets the account name and password used to run the work item.</summary>
			/// <param name="pwszAccountName">
			/// A string that contains the null-terminated name of the user account in which the work item will run. To specify the local
			/// system account, use the empty string, L"". Do not use any other string to specify the local system account. For more
			/// information, see Remarks.
			/// </param>
			/// <param name="pwszPassword">
			/// A string that contains the password for the account specified in pwszAccountName.
			/// <para>
			/// Set this parameter to NULL if the local system account is specified. If you set the TASK_FLAG_RUN_ONLY_IF_LOGGED_ON flag, you
			/// may also set pwszPassword to NULL for local or domain user accounts. Use the IScheduledWorkItem::SetFlags method to set the flag.
			/// </para>
			/// <para>
			/// Task Scheduler stores account information only once for all tasks that use the same account. If the account password is
			/// updated for one task, then all tasks using that same account will use the updated password.
			/// </para>
			/// <para>
			/// When you have finished using the password, clear the password information by calling the SecureZeroMemory function. For more
			/// information about protecting passwords, see Handling Passwords.
			/// </para>
			/// </param>
			void SetAccountInformation([In, MarshalAs(UnmanagedType.LPWStr)] string pwszAccountName, [In] IntPtr pwszPassword);

			/// <summary>Retrieves the account name for the work item.</summary>
			/// <returns>
			/// A pointer to a null-terminated string that contains the account name for the current work item. The empty string, L"", is
			/// returned for the local system account. After processing the account name, be sure to call CoTaskMemFree to free the string.
			/// </returns>
			[return: MarshalAs(UnmanagedType.LPWStr)]
			string GetAccountInformation();

			/// <summary>This method assigns a specific application to the current task.</summary>
			/// <param name="pwszApplicationName">
			/// A null-terminated string that contains the name of the application that will be associated with the task. Use an empty string
			/// to clear the application name.
			/// </param>
			void SetApplicationName([In, MarshalAs(UnmanagedType.LPWStr)] string pwszApplicationName);

			/// <summary>This method retrieves the name of the application that the task is associated with.</summary>
			/// <returns>
			/// A pointer to a null-terminated string that contains the name of the application the current task is associated with. After
			/// processing this name, call CoTaskMemFree to free resources.
			/// </returns>
			[return: MarshalAs(UnmanagedType.LPWStr)]
			string GetApplicationName();

			/// <summary>This method sets the command-line parameters for the task.</summary>
			/// <param name="pwszParameters">
			/// A null-terminated string that contains task parameters. These parameters are passed as command-line arguments to the
			/// application the task will run. To clear the command-line parameter property, set pwszParameters to L"".
			/// </param>
			void SetParameters([In, MarshalAs(UnmanagedType.LPWStr)] string pwszParameters);

			/// <summary>This method retrieves the task's command-line parameters.</summary>
			/// <returns>
			/// A pointer to a null-terminated string that contains the command-line parameters for the task. The method that invokes
			/// GetParameters is responsible for freeing this string using the CoTaskMemFree function.
			/// </returns>
			[return: MarshalAs(UnmanagedType.LPWStr)]
			string GetParameters();

			/// <summary>This method sets the working directory for the task.</summary>
			/// <param name="pwszWorkingDirectory">
			/// A null-terminated string that contains a directory path to the working directory for the task.
			/// <para>
			/// The application starts with this directory as the current working directory. To clear the directory, set pwszWorkingDirectory
			/// to L"". If the working directory is set to L"", when the application is run, the current directory will be the directory in
			/// which the task scheduler service executable, Mstask.exe, resides.
			/// </para>
			/// </param>
			void SetWorkingDirectory([In, MarshalAs(UnmanagedType.LPWStr)] string pwszWorkingDirectory);

			/// <summary>This method retrieves the task's working directory.</summary>
			/// <returns>
			/// A pointer to a null-terminated string that contains the task's working directory. The application that invokes
			/// GetWorkingDirectory is responsible for freeing this string using the CoTaskMemFree function.
			/// </returns>
			[return: MarshalAs(UnmanagedType.LPWStr)]
			string GetWorkingDirectory();

			/// <summary>This method sets the priority for the task.</summary>
			/// <param name="dwPriority">
			/// A DWORD that specifies the priority for the current task. The priority of a task determines the frequency and length of the
			/// time slices for a process. This applies only to the Windows Server 2003, Windows XP, and Windows 2000 operating systems.
			/// These values are taken from the CreateProcess priority class and can be one of following flags (in descending order of thread
			/// scheduling priority):
			/// <list type="bullet">
			/// <item>
			/// <term>REALTIME_PRIORITY_CLASS</term>
			/// </item>
			/// <item>
			/// <term>HIGH_PRIORITY_CLASS</term>
			/// </item>
			/// <item>
			/// <term>NORMAL_PRIORITY_CLASS</term>
			/// </item>
			/// <item>
			/// <term>IDLE_PRIORITY_CLASS</term>
			/// </item>
			/// </list>
			/// </param>
			void SetPriority([In] ProcessPriorityClass dwPriority);

			/// <summary>This method retrieves the priority for the task.</summary>
			/// <returns>
			/// A pointer to a DWORD that contains the priority for the current task. The priority value determines the frequency and length
			/// of the time slices for a process. This applies only to the Windows Server 2003, Windows XP, and Windows 2000 operating
			/// systems. It is taken from the <c>CreateProcess</c> priority class and can be one of the following flags (in descending order
			/// of thread scheduling priority):
			/// <list type="bullet">
			/// <item>
			/// <term>REALTIME_PRIORITY_CLASS</term>
			/// </item>
			/// <item>
			/// <term>HIGH_PRIORITY_CLASS</term>
			/// </item>
			/// <item>
			/// <term>NORMAL_PRIORITY_CLASS</term>
			/// </item>
			/// <item>
			/// <term>IDLE_PRIORITY_CLASS</term>
			/// </item>
			/// </list>
			/// </returns>
			ProcessPriorityClass GetPriority();

			/// <summary>This method sets the flags that modify the behavior of a scheduled task.</summary>
			/// <param name="dwFlags">Currently, there are no flags defined for scheduled tasks.</param>
			void SetTaskFlags([In] uint dwFlags);

			/// <summary>This method returns the flags that modify the behavior of a task.</summary>
			/// <returns>Currently, there are no defined flags for scheduled tasks.</returns>
			uint GetTaskFlags();

			/// <summary>This method sets the maximum time the task can run, in milliseconds, before terminating.</summary>
			/// <param name="dwMaxRunTime">
			/// A DWORD value that specifies the maximum run time (in milliseconds), for the task. This parameter may be set to INFINITE to
			/// specify an unlimited time.
			/// </param>
			void SetMaxRunTime([In] uint dwMaxRunTime);

			/// <summary>This method retrieves the maximum length of time, in milliseconds, the task can run before terminating.</summary>
			/// <returns>
			/// A pointer to a DWORD that contains the maximum run time of the current task. If the maximum run time is reached during the
			/// execution of a task, the Task Scheduler first sends a WM_CLOSE message to the associated application. If the application does
			/// not exit within three minutes, TerminateProcess is run.
			/// </returns>
			uint GetMaxRunTime();
		}

		/// <summary>Provides the methods for scheduling tasks.</summary>
		[ComImport, Guid("148BD527-A2AB-11CE-B11F-00AA00530503"), InterfaceType(ComInterfaceType.InterfaceIsIUnknown), System.Security.SuppressUnmanagedCodeSecurity, CoClass(typeof(CTaskScheduler))]
		[PInvokeData("mstask.h", MSDNShortId = "aa381811")]
		public interface ITaskScheduler
		{
			/// <summary>
			/// The SetTargetComputer method selects the computer that the ITaskScheduler interface operates on, allowing remote task
			/// management and enumeration.
			/// </summary>
			/// <param name="pwszComputer">
			/// A pointer to a null-terminated wide character string that specifies the target computer name for the current instance of the
			/// ITaskScheduler interface. Specify the target computer name in the Universal Naming Convention (UNC) format. To indicate the
			/// local computer, set this value to NULL or to the local computer's UNC name. <note>When specifying a remote computer name, use
			/// two backslash (\\) characters before the computer name. For example, use "\\ComputerName" instead of "ComputerName".</note>
			/// </param>
			void SetTargetComputer([In, MarshalAs(UnmanagedType.LPWStr)] string pwszComputer);

			/// <summary>The GetTargetComputer method returns the name of the computer on which ITaskScheduler is currently targeted.</summary>
			/// <returns>
			/// A pointer to a null-terminated string that contains the name of the target computer for the current task. This string is
			/// allocated by the application that invokes GetTargetComputer, and must also be freed using CoTaskMemFree.
			/// </returns>
			[return: MarshalAs(UnmanagedType.LPWStr)]
			string GetTargetComputer();

			/// <summary>
			/// The Enum method retrieves a pointer to an OLE enumerator object that enumerates the tasks in the current task folder.
			/// </summary>
			/// <returns>
			/// A pointer to a pointer to an IEnumWorkItems interface. This interface contains the enumeration context of the current task(s).
			/// </returns>
			[return: MarshalAs(UnmanagedType.Interface)]
			IEnumWorkItems Enum();

			/// <summary>The Activate method returns an active interface for a specified work item.</summary>
			/// <param name="pwszName">A null-terminated string that specifies the name of the work item to activate.</param>
			/// <param name="riid">
			/// An identifier that identifies the interface being requested. The only interface supported at this time, ITask, has the
			/// identifier IID_ITask.
			/// </param>
			/// <returns>A pointer to an interface pointer that receives the address of the requested interface.</returns>
			[return: MarshalAs(UnmanagedType.Interface)]
			ITask Activate([In, MarshalAs(UnmanagedType.LPWStr)] string pwszName, in Guid riid);

			/// <summary>The Delete method deletes a task.</summary>
			/// <param name="pwszName">A null-terminated string that specifies the name of the task to delete.</param>
			void Delete([In, MarshalAs(UnmanagedType.LPWStr)] string pwszName);

			/// <summary>The NewWorkItem method creates a new work item, allocating space for the work item and retrieving its address.</summary>
			/// <param name="pwszTaskName">
			/// A null-terminated string that specifies the name of the new work item. This name must conform to Windows NT file-naming
			/// conventions, but cannot include backslashes because nesting within the task folder object is not allowed.
			/// </param>
			/// <param name="rclsid">
			/// The class identifier of the work item to be created. The only class supported at this time, the task class, has the
			/// identifier CLSID_Ctask.
			/// </param>
			/// <param name="riid">
			/// The reference identifier of the interface being requested. The only interface supported at this time, ITask, has the
			/// identifier IID_ITask.
			/// </param>
			/// <returns>
			/// A pointer to an interface pointer that receives the requested interface. See Remarks for information on saving the work item
			/// to disk.
			/// </returns>
			[return: MarshalAs(UnmanagedType.Interface)]
			ITask NewWorkItem([In, MarshalAs(UnmanagedType.LPWStr)] string pwszTaskName, in Guid rclsid, in Guid riid);

			/// <summary>The AddWorkItem method adds a task to the schedule of tasks.</summary>
			/// <param name="pwszTaskName">
			/// A null-terminated string that specifies the name of the task to add. The task name must conform to Windows NT file-naming
			/// conventions, but cannot include backslashes because nesting within the task folder object is not allowed.
			/// </param>
			/// <param name="WorkItem">A pointer to the task to add to the schedule.</param>
			void AddWorkItem([In, MarshalAs(UnmanagedType.LPWStr)] string pwszTaskName, [In, MarshalAs(UnmanagedType.Interface)] ITask WorkItem);

			/// <summary>The IsOfType method checks the object's type to verify that it supports a particular interface.</summary>
			/// <param name="pwszName">A null-terminated string that contains the name of the object to check.</param>
			/// <param name="riid">The reference identifier of the interface to be matched.</param>
			/// <returns>
			/// The IsOfType method returns S_OK if the object named by pwszName supports the interface specified in riid. Otherwise, S_FALSE
			/// is returned.
			/// </returns>
			[PreserveSig]
			HRESULT IsOfType([In, MarshalAs(UnmanagedType.LPWStr)] string pwszName, in Guid riid);
		}

		/// <summary>
		/// Provides the methods for accessing and setting triggers for a task. Triggers specify task start times, repetition criteria, and
		/// other parameters that control when a task is run.
		/// <para>ITaskTrigger is the primary interface of the task_trigger object. To create a trigger object, call CreateTrigger or GetTrigger.</para>
		/// </summary>
		[Guid("148BD52B-A2AB-11CE-B11F-00AA00530503"), InterfaceType(ComInterfaceType.InterfaceIsIUnknown), System.Security.SuppressUnmanagedCodeSecurity]
		[PInvokeData("mstask.h", MSDNShortId = "aa381864")]
		public interface ITaskTrigger
		{
			/// <summary>The GetTrigger method retrieves the current task trigger.</summary>
			/// <returns>
			/// A pointer to a TASK_TRIGGER structure that contains the current task trigger. You must set the cbTriggerSize member of the
			/// TASK_TRIGGER structure to the size of the task trigger structure before passing the structure to this method.
			/// </returns>
			[return: MarshalAs(UnmanagedType.Struct)]
			TASK_TRIGGER GetTrigger();

			/// <summary>
			/// The GetTriggerString method retrieves the current task trigger in the form of a string. This string appears in the Task
			/// Scheduler user interface in a form similar to "At 2PM every day, starting 5/11/97."
			/// </summary>
			/// <returns>
			/// A pointer to a pointer to a null-terminated string that describes the current task trigger. The method that invokes
			/// GetTriggerString is responsible for freeing this string using the CoTaskMemFree function.
			/// </returns>
			[return: MarshalAs(UnmanagedType.LPWStr)]
			string GetTriggerString();

			/// <summary>The SetTrigger method sets the trigger criteria for a task trigger.</summary>
			/// <param name="Trigger">A pointer to a TASK_TRIGGER structure that contains the values that define the new task trigger.</param>
			void SetTrigger(in TASK_TRIGGER Trigger);
		}

		/// <summary>
		/// <para>
		/// [ <c>GetNetScheduleAccountInformation</c> is no longer available for use as of Windows 8. Instead, use the Task Scheduler 2.0 Interfaces.]
		/// </para>
		/// <para>The <c>GetNetScheduleAccountInformation</c> function retrieves the AT Service account name.</para>
		/// </summary>
		/// <param name="pwszServerName">
		/// A NULL-terminated wide character string for the name of the computer whose account information is being retrieved.
		/// </param>
		/// <param name="ccAccount">
		/// The number of characters, including the NULL terminator, allocated for wszAccount. The maximum allowed length for this value is
		/// the maximum domain name length plus the maximum user name length plus 2, expressed as DNLEN + UNLEN + 2. (The last two characters
		/// are the "\" character and the NULL terminator.)
		/// </param>
		/// <param name="wszAccount">An array of wide characters, including the NULL terminator, that receives the account information.</param>
		/// <returns>
		/// The return value is an HRESULT. A value of S_OK indicates the function succeeded, and the account information is returned in
		/// wszAccount. A value of S_FALSE indicates the function succeeded, and the account is the Local System account (no information will
		/// be returned in wszAccount). Any other return values indicate an error condition.
		/// </returns>
		// HRESULT GetNetScheduleAccountInformation( _In_ LPCWSTR pwszServerName, _In_ DWORD ccAccount, _Out_ WCHAR wszAccount[]); https://msdn.microsoft.com/en-us/library/windows/desktop/aa370264(v=vs.85).aspx
		[DllImport(Lib.Mstask, SetLastError = false, ExactSpelling = true, CharSet = CharSet.Unicode)]
		[PInvokeData("AtAcct.h", MSDNShortId = "aa370264")]
		public static extern HRESULT GetNetScheduleAccountInformation(string pwszServerName, uint ccAccount, System.Text.StringBuilder wszAccount);

		/// <summary>
		/// <para>Retrieves the next specified number of tasks in the enumeration sequence.</para>
		/// <para>If there are fewer than the requested number of tasks left in the sequence, all the remaining elements are retrieved.</para>
		/// </summary>
		/// <param name="enumItems">The <see cref="IEnumWorkItems"/> instance on which to act.</param>
		/// <param name="celt">The number of tasks to retrieve.</param>
		/// <param name="names">
		/// An array of strings containing the file names of the tasks returned from the enumeration sequence. These file names are taken
		/// from the Scheduled Tasks folder and have the ".job" extension.
		/// </param>
		/// <param name="pceltFetched">The number of tasks returned in rgpwszNames.</param>
		/// <returns>
		/// <para>Returns one of the following values.</para>
		/// <list type="table">
		/// <listheader>
		/// <term>Return code</term>
		/// <term>Description</term>
		/// </listheader>
		/// <item>
		/// <term>S_OK</term>
		/// <term>The number of tasks retrieved equals the number requested.</term>
		/// </item>
		/// <item>
		/// <term>S_FALSE</term>
		/// <term>The number returned is less than the number requested. (Thus, there are no more tasks to enumerate.)</term>
		/// </item>
		/// <item>
		/// <term>E_INVALIDARG</term>
		/// <term>A parameter is invalid.</term>
		/// </item>
		/// <item>
		/// <term>E_OUTOFMEMORY</term>
		/// <term>Not enough memory is available.</term>
		/// </item>
		/// </list>
		/// </returns>
		/// <remarks>
		/// <para>
		/// The IEnumWorkItems interface also provides methods for resetting the enumeration, skipping tasks, and making a copy of the
		/// current state of the enumeration.
		/// </para>
		/// <para>Examples</para>
		/// <para>For an example of how to use <c>Next</c> to enumerate the tasks in the Scheduled Tasks folder, see Enumerating Tasks Example.</para>
		/// </remarks>
		public static HRESULT Next(this IEnumWorkItems enumItems, uint celt, out string[] names, out uint pceltFetched)
		{
			var hr = enumItems.Next(celt, out var rgpwszNames, out pceltFetched);
			names = new string[hr.Succeeded ? pceltFetched : 0];
			if (hr.Failed) return hr;
			for (var i = 0; i < pceltFetched; i++)
			{
				var sptr = Marshal.ReadIntPtr(rgpwszNames, IntPtr.Size * i);
				names[i] = Marshal.PtrToStringUni(sptr);
				Marshal.FreeCoTaskMem(sptr);
			}
			Marshal.FreeCoTaskMem(rgpwszNames);
			return hr;
		}

		/// <summary>
		/// <para>
		/// [ <c>SetNetScheduleAccountInformation</c> is no longer available for use as of Windows 8. Instead, use the Task Scheduler 2.0 Interfaces.]
		/// </para>
		/// <para>
		/// The <c>SetNetScheduleAccountInformation</c> function sets the AT Service account name and password. The AT Service account name
		/// and password are used as the credentials for scheduled jobs created with <c>NetScheduleJobAdd</c>.
		/// </para>
		/// </summary>
		/// <param name="pwszServerName">
		/// A NULL-terminated wide character string for the name of the computer whose account information is being set.
		/// </param>
		/// <param name="pwszAccount">
		/// A pointer to a NULL-terminated wide character string for the account. To specify the local system account, set this parameter to <c>NULL</c>.
		/// </param>
		/// <param name="pwszPassword">
		/// A pointer to a NULL-terminated wide character string for the password. For information about securing password information, see
		/// Handling Passwords.
		/// </param>
		/// <returns>
		/// <para>
		/// The return value is an HRESULT. A value of S_OK indicates the account name and password were successfully set. Any other value
		/// indicates an error condition.
		/// </para>
		/// <para>If the function fails, some of the possible return values are listed below.</para>
		/// <para>
		/// <list type="table">
		/// <listheader>
		/// <term>Return code/value</term>
		/// <term>Description</term>
		/// </listheader>
		/// <item>
		/// <term>E_ACCESSDENIED0x080070005</term>
		/// <term>
		/// Access was denied. This error is returned if the caller was not a member of the Administrators group. This error is also returned
		/// if the pwszAccount parameter was not NULL indicating a named account not the local system account and the pwszPassword parameter
		/// was incorrect for the account specified in the pwszAccount parameter.
		/// </term>
		/// </item>
		/// <item>
		/// <term>HRESULT_FROM_WIN32(ERROR_INVALID_DATA)0x08007000d</term>
		/// <term>
		/// The data is invalid. This error is returned if the pwszPassword parameter was NULL or the length of pwszPassword parameter string
		/// was too long.
		/// </term>
		/// </item>
		/// <item>
		/// <term>SCHED_E_ACCOUNT_NAME_NOT_FOUND0x80041310</term>
		/// <term>
		/// Unable to establish existence of the account specified. This error is returned if the pwszAccount parameter was not NULL
		/// indicating a named account not the local system account and the pwszAccount parameter could not be found.
		/// </term>
		/// </item>
		/// </list>
		/// </para>
		/// </returns>
		// HRESULT SetNetScheduleAccountInformation( _In_ LPCWSTR pwszServerName, _In_ LPCWSTR pwszAccount, _In_ LPCWSTR pwszPassword); https://msdn.microsoft.com/en-us/library/windows/desktop/aa370955(v=vs.85).aspx
		[DllImport(Lib.Mstask, SetLastError = false, ExactSpelling = true, CharSet = CharSet.Unicode)]
		[PInvokeData("AtAcct.h", MSDNShortId = "aa370955")]
		public static extern HRESULT SetNetScheduleAccountInformation(string pwszServerName, string pwszAccount, string pwszPassword);

		/// <summary>Defines the interval, in days, at which a task is run.</summary>
		[StructLayout(LayoutKind.Sequential)]
		[PInvokeData("mstask.h", MSDNShortId = "aa446857")]
		public struct DAILY
		{
			/// <summary>Specifies the number of days between task runs.</summary>
			public ushort DaysInterval;
		}

		/// <summary>Defines the day of the month the task will run.</summary>
		[StructLayout(LayoutKind.Sequential)]
		[PInvokeData("mstask.h", MSDNShortId = "aa381918")]
		public struct MONTHLYDATE
		{
			/// <summary>
			/// Specifies the day of the month a task runs. This value is a bitfield that specifies the day(s) the task will run. Bit 0
			/// corresponds to the first of the month, bit 1 to the second, and so forth.
			/// </summary>
			public uint Days;

			/// <summary>
			/// Specifies the month(s) when the task runs. This value is a combination of the following flags. See Remarks for an example of
			/// setting multiple flags.
			/// </summary>
			public TaskMonths Months;
		}

		/// <summary>Defines the date(s) that the task runs by month, week, and day of the week.</summary>
		[StructLayout(LayoutKind.Sequential)]
		[PInvokeData("mstask.h", MSDNShortId = "aa381950")]
		public struct MONTHLYDOW
		{
			/// <summary>Specifies the week of the month when the task runs. This value is exclusive and is one of the following flags.</summary>
			public TaskWhichWeek wWhichWeek;

			/// <summary>
			/// Specifies the day(s) of the week (specified in wWhichWeek) when the task runs. This value is a combination of the following flags.
			/// </summary>
			public TaskDaysOfTheWeek rgfDaysOfTheWeek;

			/// <summary>Value that describes the month(s) when the task runs. This value is a combination of the following flags.</summary>
			public TaskMonths rgfMonths;
		}

		/// <summary>Defines the times to run a scheduled work item.</summary>
		[StructLayout(LayoutKind.Sequential)]
		[PInvokeData("mstask.h", MSDNShortId = "aa383618")]
		public struct TASK_TRIGGER
		{
			/// <summary>Size of this structure, in bytes.</summary>
			public ushort cbTriggerSize;

			/// <summary>For internal use only; this value must be zero.</summary>
			public ushort Reserved1;

			/// <summary>
			/// Year that the task trigger activates. This value must be four digits (1997, not 97). The beginning year must be specified
			/// when setting a task.
			/// </summary>
			public ushort wBeginYear;

			/// <summary>
			/// Month of the year (specified in the wBeginYear member) that the task trigger activates. The beginning month must be specified
			/// when setting a task.
			/// </summary>
			public ushort wBeginMonth;

			/// <summary>
			/// Day of the month (specified in the wBeginMonth member) that the task trigger activates. The beginning day must be specified
			/// when setting a task.
			/// </summary>
			public ushort wBeginDay;

			/// <summary>Year that the task trigger deactivates. This value must be four digits (1997, not 97).</summary>
			public ushort wEndYear;

			/// <summary>Month of the year (specified in the wEndYear member) that the task trigger deactivates.</summary>
			public ushort wEndMonth;

			/// <summary>Day of the month (specified in the wEndMonth member) that the task trigger deactivates.</summary>
			public ushort wEndDay;

			/// <summary>Hour of the day the task runs. This value is on a 24-hour clock; hours go from 00 to 23.</summary>
			public ushort wStartHour;

			/// <summary>Minute of the hour (specified in the wStartHour member) that the task runs.</summary>
			public ushort wStartMinute;

			/// <summary>
			/// Number of minutes after the task starts that the trigger will remain active. The number of minutes specified here must be
			/// greater than or equal to the MinutesInterval setting.
			/// <para>
			/// For example, if you start a task at 8:00 A.M. and want to repeatedly start the task until 5:00 P.M., there would be 540
			/// minutes in the duration.
			/// </para>
			/// </summary>
			public uint MinutesDuration;

			/// <summary>
			/// Number of minutes between consecutive task executions. This number is counted from the start of the previous scheduled task.
			/// The number of minutes specified here must be less than the MinutesDuration setting.
			/// <para>For example, to run a task every hour from 8:00 A.M. to 5:00 P.M., set this field to 60.</para>
			/// </summary>
			public uint MinutesInterval;

			/// <summary>Value that describes the behavior of the trigger. This value is a combination of the following flags.</summary>
			public TaskTriggerFlags rgFlags;

			/// <summary>
			/// A TASK_TRIGGER_TYPE enumerated value that specifies the type of trigger. This member is used with Type. The type of trigger
			/// specified here determines which fields of the TRIGGER_TYPE_UNION specified in Type member will be used. Trigger type is based
			/// on when the trigger will run the task.
			/// </summary>
			public TASK_TRIGGER_TYPE TriggerType;

			/// <summary>
			/// A TRIGGER_TYPE_UNION structure that specifies details about the trigger. Note that the TriggerType member determines which
			/// fields of the TRIGGER_TYPE_UNION union will be used.
			/// </summary>
			public TRIGGER_TYPE_UNION Type;

			/// <summary>For internal use only; this value must be zero.</summary>
			public ushort Reserved2;

			/// <summary>Not currently used.</summary>
			public ushort wRandomMinutesInterval;

			/// <summary>Gets or sets the begin date.</summary>
			/// <value>The begin date.</value>
			public DateTime BeginDate
			{
				get
				{
					try
					{
						return wBeginYear == 0
							? DateTime.MinValue
							: new DateTime(wBeginYear, wBeginMonth, wBeginDay, wStartHour, wStartMinute, 0, DateTimeKind.Unspecified);
					}
					catch { return DateTime.MinValue; }
				}
				set
				{
					if (value != DateTime.MinValue)
					{
						var local = value.Kind == DateTimeKind.Utc ? value.ToLocalTime() : value;
						wBeginYear = (ushort)local.Year;
						wBeginMonth = (ushort)local.Month;
						wBeginDay = (ushort)local.Day;
						wStartHour = (ushort)local.Hour;
						wStartMinute = (ushort)local.Minute;
					}
					else
						wBeginYear = wBeginMonth = wBeginDay = wStartHour = wStartMinute = 0;
				}
			}

			/// <summary>Gets or sets the end date.</summary>
			/// <value>The end date.</value>
			public DateTime? EndDate
			{
				get
				{
					try { return wEndYear == 0 ? (DateTime?)null : new DateTime(wEndYear, wEndMonth, wEndDay); }
					catch { return DateTime.MaxValue; }
				}
				set
				{
					if (value.HasValue)
					{
						wEndYear = (ushort)value.Value.Year;
						wEndMonth = (ushort)value.Value.Month;
						wEndDay = (ushort)value.Value.Day;
						rgFlags |= TaskTriggerFlags.TASK_TRIGGER_FLAG_HAS_END_DATE;
					}
					else
					{
						wEndYear = wEndMonth = wEndDay = 0;
						rgFlags &= ~TaskTriggerFlags.TASK_TRIGGER_FLAG_HAS_END_DATE;
					}
				}
			}

			/// <summary>Returns a <see cref="string"/> that represents this instance.</summary>
			/// <returns>A <see cref="string"/> that represents this instance.</returns>
			public override string ToString() =>
				$"Trigger Type: {Type};\n> Start: {BeginDate}; End: {(wEndYear == 0 ? "null" : EndDate?.ToString())};\n> DurMin: {MinutesDuration}; DurItv: {MinutesInterval};\n>";
		}

		/// <summary>Defines the invocation schedule of the trigger within the Type member of a TASK_TRIGGER structure.</summary>
		[StructLayout(LayoutKind.Explicit)]
		[PInvokeData("mstask.h", MSDNShortId = "aa384002")]
		public struct TRIGGER_TYPE_UNION
		{
			/// <summary>A DAILY structure that specifies the number of days between invocations of a task.</summary>
			[FieldOffset(0)] public DAILY Daily;

			/// <summary>
			/// A WEEKLY structure that specifies the number of weeks between invocations of a task, and day(s) of the week the task will run.
			/// </summary>
			[FieldOffset(0)] public WEEKLY Weekly;

			/// <summary>A MONTHLYDATE structure that specifies the month(s) and day(s) of the month a task will run.</summary>
			[FieldOffset(0)] public MONTHLYDATE MonthlyDate;

			/// <summary>
			/// A MONTHLYDOW structure that specifies the day(s) of the year a task runs by month(s), week of month, and day(s) of week.
			/// </summary>
			[FieldOffset(0)] public MONTHLYDOW MonthlyDOW;
		}

		/// <summary>Defines the interval, in weeks, between invocations of a task.</summary>
		[StructLayout(LayoutKind.Sequential)]
		[PInvokeData("mstask.h", MSDNShortId = "aa384014")]
		public struct WEEKLY
		{
			/// <summary>Number of weeks between invocations of a task.</summary>
			public ushort WeeksInterval;

			/// <summary>
			/// Value that describes the days of the week the task runs. This value is a bitfield and is a combination of the following
			/// flags. See Remarks for an example of specifying multiple flags.
			/// </summary>
			public TaskDaysOfTheWeek rgfDaysOfTheWeek;
		}

		/// <summary>CoClass for ITask</summary>
		[ComImport, Guid("148BD520-A2AB-11CE-B11F-00AA00530503"), System.Security.SuppressUnmanagedCodeSecurity, ClassInterface(ClassInterfaceType.None)]
		public class CTask { }

		/// <summary>CoClass for ITaskScheduler</summary>
		[ComImport, Guid("148BD52A-A2AB-11CE-B11F-00AA00530503"), System.Security.SuppressUnmanagedCodeSecurity, ClassInterface(ClassInterfaceType.None)]
		public class CTaskScheduler { }
	}
}