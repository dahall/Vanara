using System;
using System.Collections;
using System.Reflection;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using Vanara.InteropServices;
// ReSharper disable UnusedMember.Global

namespace Vanara.PInvoke
{
	public static partial class TaskSchd
	{
		/// <summary>Defines the type of actions that a task can perform.</summary>
		[PInvokeData("taskschd.h", MSDNShortId = "aa383553")]
		public enum TASK_ACTION_TYPE
		{
			/// <summary>
			/// This action performs a command-line operation. For example, the action can run a script, launch an executable, or, if the name of a document is
			/// provided, find its associated application and launch the application with the document.
			/// </summary>
			TASK_ACTION_EXEC = 0,

			/// <summary>This action fires a handler. This action can only be used if the task Compatibility property is set to TASK_COMPATIBILITY_V2.</summary>
			TASK_ACTION_COM_HANDLER = 5,

			/// <summary>This action sends email message. This action can only be used if the task Compatibility property is set to TASK_COMPATIBILITY_V2.</summary>
			TASK_ACTION_SEND_EMAIL = 6,

			/// <summary>This action shows a message box. This action can only be used if the task Compatibility property is set to TASK_COMPATIBILITY_V2.</summary>
			TASK_ACTION_SHOW_MESSAGE = 7
		}

		/// <summary>Defines what versions of Task Scheduler or the AT command that the task is compatible with.</summary>
		[PInvokeData("taskschd.h", MSDNShortId = "aa383557")]
		public enum TASK_COMPATIBILITY
		{
			/// <summary>The task is compatible with the AT command.</summary>
			TASK_COMPATIBILITY_AT = 0,

			/// <summary>The task is compatible with Task Scheduler 1.0.</summary>
			TASK_COMPATIBILITY_V1 = 1,

			/// <summary>The task is compatible with Task Scheduler 2.0.</summary>
			TASK_COMPATIBILITY_V2 = 2,

			/// <summary>The task is compatible with Task Scheduler 2.1.</summary>
			TASK_COMPATIBILITY_V2_1 = 3,

			/// <summary>The task is compatible with Task Scheduler 2.2.</summary>
			TASK_COMPATIBILITY_V2_2 = 4,

			/// <summary>The task is compatible with Task Scheduler 2.3.</summary>
			TASK_COMPATIBILITY_V2_3 = 5,

			/// <summary>The task is compatible with Task Scheduler 2.4.</summary>
			TASK_COMPATIBILITY_V2_4 = 6
		}

		/// <summary>Defines how the Task Scheduler service creates, updates, or disables the task.</summary>
		[PInvokeData("taskschd.h", MSDNShortId = "aa382538")]
		[Flags]
		public enum TASK_CREATION
		{
			/// <summary>
			/// The Task Scheduler service checks the syntax of the XML that describes the task but does not register the task. This constant cannot be combined
			/// with the TASK_CREATE, TASK_UPDATE, or TASK_CREATE_OR_UPDATE values.
			/// </summary>
			TASK_VALIDATE_ONLY = 0x1,

			/// <summary>The Task Scheduler service registers the task as a new task.</summary>
			TASK_CREATE = 0x2,

			/// <summary>
			/// The Task Scheduler service registers the task as an updated version of an existing task. When a task with a registration trigger is updated, the
			/// task will execute after the update occurs.
			/// </summary>
			TASK_UPDATE = 0x4,

			/// <summary>
			/// The Task Scheduler service either registers the task as a new task or as an updated version if the task already exists. Equivalent to TASK_CREATE
			/// | TASK_UPDATE.
			/// </summary>
			TASK_CREATE_OR_UPDATE = 0x6,

			/// <summary>
			/// The Task Scheduler service registers the disabled task. A disabled task cannot run until it is enabled. For more information, see Enabled
			/// Property of ITaskSettings and Enabled Property of IRegisteredTask.
			/// </summary>
			TASK_DISABLE = 0x8,

			/// <summary>
			/// The Task Scheduler service is prevented from adding the allow access-control entry (ACE) for the context principal. When the
			/// ITaskFolder::RegisterTaskDefinition or ITaskFolder::RegisterTask functions are called with this flag to update a task, the Task Scheduler service
			/// does not add the ACE for the new context principal and does not remove the ACE from the old context principal.
			/// </summary>
			TASK_DONT_ADD_PRINCIPAL_ACE = 0x10,

			/// <summary>
			/// The Task Scheduler service creates the task, but ignores the registration triggers in the task. By ignoring the registration triggers, the task
			/// will not execute when it is registered unless a time-based trigger causes it to execute on registration.
			/// </summary>
			TASK_IGNORE_REGISTRATION_TRIGGERS = 0x20
		}

		/// <summary>Defines how the Task Scheduler enumerates through registered tasks.</summary>
		[PInvokeData("taskschd.h", MSDNShortId = "aa383558")]
		[Flags]
		public enum TASK_ENUM_FLAGS
		{
			/// <summary>Enumerates all the tasks in the folder excluding the hidden tasks.</summary>
			TASK_ENUM_UNHIDDEN = 0,

			/// <summary>Enumerates all tasks, including tasks that are hidden.</summary>
			TASK_ENUM_HIDDEN = 1
		}

		/// <summary>Defines how the Task Scheduler handles existing instances of the task when it starts a new instance of the task.</summary>
		[PInvokeData("taskschd.h", MSDNShortId = "aa383563")]
		public enum TASK_INSTANCES_POLICY
		{
			/// <summary>Starts new instance while an existing instance is running.</summary>
			TASK_INSTANCES_PARALLEL = 0,

			/// <summary>Starts a new instance of the task after all other instances of the task are complete.</summary>
			TASK_INSTANCES_QUEUE = 1,

			/// <summary>Does not start a new instance if an existing instance of the task is running.</summary>
			TASK_INSTANCES_IGNORE_NEW = 2,

			/// <summary>Stops an existing instance of the task before it starts a new instance.</summary>
			TASK_INSTANCES_STOP_EXISTING = 3
		}

		/// <summary>Defines what logon technique is required to run a task.</summary>
		[PInvokeData("taskschd.h", MSDNShortId = "aa383566")]
		public enum TASK_LOGON_TYPE
		{
			/// <summary>The logon method is not specified. Used for non-NT credentials.</summary>
			TASK_LOGON_NONE = 0,

			/// <summary>Use a password for logging on the user. The password must be supplied at registration time.</summary>
			TASK_LOGON_PASSWORD = 1,

			/// <summary>
			/// The service will log the user on using Service For User (S4U), and the task will run in a non-interactive desktop. When an S4U logon is used, no
			/// password is stored by the system and there is no access to either the network or to encrypted files.
			/// </summary>
			TASK_LOGON_S4U = 2,

			/// <summary>User must already be logged on. The task will be run only in an existing interactive session.</summary>
			TASK_LOGON_INTERACTIVE_TOKEN = 3,

			/// <summary>Group activation. The groupId field specifies the group.</summary>
			TASK_LOGON_GROUP = 4,

			/// <summary>Indicates that a Local System, Local Service, or Network Service account is being used as a security context to run the task.</summary>
			TASK_LOGON_SERVICE_ACCOUNT = 5,

			/// <summary>
			/// First use the interactive token. If the user is not logged on (no interactive token is available), then the password is used. The password must
			/// be specified when a task is registered. This flag is not recommended for new tasks because it is less reliable than TASK_LOGON_PASSWORD.
			/// </summary>
			TASK_LOGON_INTERACTIVE_TOKEN_OR_PASSWORD = 6
		}

		/// <summary>
		/// Defines the types of process security identifier (SID) that can be used by tasks. These changes are used to specify the type of process SID in the
		/// IPrincipal2 interface.
		/// </summary>
		[PInvokeData("taskschd.h", MSDNShortId = "ee695874")]
		public enum TASK_PROCESSTOKENSID_TYPE
		{
			/// <summary>No changes will be made to the process token groups list.</summary>
			TASK_PROCESSTOKENSID_NONE = 0,

			/// <summary>
			/// A task SID that is derived from the task name will be added to the process token groups list, and the token default discretionary access control
			/// list (DACL) will be modified to allow only the task SID and local system full control and the account SID read control.
			/// </summary>
			TASK_PROCESSTOKENSID_UNRESTRICTED = 1,

			/// <summary>A Task Scheduler will apply default settings to the task process.</summary>
			TASK_PROCESSTOKENSID_DEFAULT = 2
		}

		/// <summary>Defines how a task is run.</summary>
		[PInvokeData("taskschd.h", MSDNShortId = "aa383574")]
		[Flags]
		public enum TASK_RUN_FLAGS
		{
			/// <summary>The task is run with all flags ignored.</summary>
			TASK_RUN_NO_FLAGS = 0,

			/// <summary>The task is run as the user who is calling the Run method.</summary>
			TASK_RUN_AS_SELF = 0x1,

			/// <summary>The task is run regardless of constraints such as "do not run on batteries" or "run only if idle".</summary>
			TASK_RUN_IGNORE_CONSTRAINTS = 0x2,

			/// <summary>The task is run using a terminal server session identifier.</summary>
			TASK_RUN_USE_SESSION_ID = 0x4,

			/// <summary>The task is run using a security identifier.</summary>
			TASK_RUN_USER_SID = 0x8
		}

		/// <summary>Defines LUA elevation flags that specify with what privilege level the task will be run.</summary>
		[PInvokeData("taskschd.h", MSDNShortId = "aa383553")]
		public enum TASK_RUNLEVEL_TYPE
		{
			/// <summary>Tasks will be run with the least privileges.</summary>
			TASK_RUNLEVEL_LUA = 0,

			/// <summary>Tasks will be run with the highest privileges.</summary>
			TASK_RUNLEVEL_HIGHEST = 1
		}

		/// <summary>
		/// Defines what kind of Terminal Server session state change you can use to trigger a task to start. These changes are used to specify the type of state
		/// change in the ISessionStateChangeTrigger interface.
		/// </summary>
		[PInvokeData("taskschd.h", MSDNShortId = "aa383616")]
		public enum TASK_SESSION_STATE_CHANGE_TYPE
		{
			/// <summary>
			/// Terminal Server console connection state change. For example, when you connect to a user session on the local computer by switching users on the computer.
			/// </summary>
			TASK_CONSOLE_CONNECT = 1,

			/// <summary>
			/// Terminal Server console disconnection state change. For example, when you disconnect to a user session on the local computer by switching users
			/// on the computer.
			/// </summary>
			TASK_CONSOLE_DISCONNECT = 2,

			/// <summary>
			/// Terminal Server remote connection state change. For example, when a user connects to a user session by using the Remote Desktop Connection
			/// program from a remote computer.
			/// </summary>
			TASK_REMOTE_CONNECT = 3,

			/// <summary>
			/// Terminal Server remote disconnection state change. For example, when a user disconnects from a user session while using the Remote Desktop
			/// Connection program from a remote computer.
			/// </summary>
			TASK_REMOTE_DISCONNECT = 4,

			/// <summary>Terminal Server session locked state change. For example, this state change causes the task to run when the computer is locked.</summary>
			TASK_SESSION_LOCK = 7,

			/// <summary>Terminal Server session unlocked state change. For example, this state change causes the task to run when the computer is unlocked.</summary>
			TASK_SESSION_UNLOCK = 8
		}

		/// <summary>Defines the different states that a registered task can be in.</summary>
		[PInvokeData("taskschd.h", MSDNShortId = "aa383617")]
		public enum TASK_STATE
		{
			/// <summary>The state of the task is unknown.</summary>
			TASK_STATE_UNKNOWN = 0,

			/// <summary>The task is registered but is disabled and no instances of the task are queued or running. The task cannot be run until it is enabled.</summary>
			TASK_STATE_DISABLED = 1,

			/// <summary>Instances of the task are queued.</summary>
			TASK_STATE_QUEUED = 2,

			/// <summary>The task is ready to be executed, but no instances are queued or running.</summary>
			TASK_STATE_READY = 3,

			/// <summary>One or more instances of the task is running.</summary>
			TASK_STATE_RUNNING = 4
		}

		/// <summary>Defines the type of triggers that can be used by tasks.</summary>
		[PInvokeData("taskschd.h", MSDNShortId = "aa383915")]
		public enum TASK_TRIGGER_TYPE2
		{
			/// <summary>Triggers the task when a specific event occurs. For more information about event triggers, see IEventTrigger.</summary>
			TASK_TRIGGER_EVENT = 0,

			/// <summary>Triggers the task at a specific time of day. For more information about time triggers, see ITimeTrigger.</summary>
			TASK_TRIGGER_TIME = 1,

			/// <summary>
			/// Triggers the task on a daily schedule. For example, the task starts at a specific time every day, every other day, or every third day. For more
			/// information about daily triggers, see IDailyTrigger.
			/// </summary>
			TASK_TRIGGER_DAILY = 2,

			/// <summary>
			/// Triggers the task on a weekly schedule. For example, the task starts at 8:00 AM on a specific day every week or other week. For more information
			/// about weekly triggers, see IWeeklyTrigger.
			/// </summary>
			TASK_TRIGGER_WEEKLY = 3,

			/// <summary>
			/// Triggers the task on a monthly schedule. For example, the task starts on specific days of specific months. For more information about monthly
			/// triggers, see IMonthlyTrigger.
			/// </summary>
			TASK_TRIGGER_MONTHLY = 4,

			/// <summary>
			/// Triggers the task on a monthly day-of-week schedule. For example, the task starts on a specific days of the week, weeks of the month, and months
			/// of the year. For more information about monthly day-of-week triggers, see IMonthlyDOWTrigger.
			/// </summary>
			TASK_TRIGGER_MONTHLYDOW = 5,

			/// <summary>Triggers the task when the computer goes into an idle state. For more information about idle triggers, see IIdleTrigger.</summary>
			TASK_TRIGGER_IDLE = 6,

			/// <summary>Triggers the task when the task is registered. For more information about registration triggers, see IRegistrationTrigger.</summary>
			TASK_TRIGGER_REGISTRATION = 7,

			/// <summary>Triggers the task when the computer boots. For more information about boot triggers, see IBootTrigger.</summary>
			TASK_TRIGGER_BOOT = 8,

			/// <summary>Triggers the task when a specific user logs on. For more information about logon triggers, see ILogonTrigger.</summary>
			TASK_TRIGGER_LOGON = 9,

			/// <summary>Triggers the task when a specific user session state changes. For more information about session state change triggers, see ISessionStateChangeTrigger.</summary>
			TASK_TRIGGER_SESSION_STATE_CHANGE = 11,

			/// <summary>Custom triggers defined by the operating system. User defined custom triggers are not supported.</summary>
			TASK_TRIGGER_CUSTOM_TRIGGER_01 = 12
		}

		/// <summary>Provides the common properties inherited by all action objects. An action object is created by the IActionCollection::Create method.</summary>
		[ComImport, Guid("BAE54997-48B1-4CBE-9965-D6BE263EBEA4"), InterfaceType(ComInterfaceType.InterfaceIsDual),
		 System.Security.SuppressUnmanagedCodeSecurity]
		[PInvokeData("taskschd.h", MSDNShortId = "aa446895")]
		public interface IAction
		{
			/// <summary>Gets or sets the identifier of the action.</summary>
			/// <value>The user-defined identifier for the action. This identifier is used by the Task Scheduler for logging purposes.</value>
			string Id { [return: MarshalAs(UnmanagedType.BStr)] get; [param: In, MarshalAs(UnmanagedType.BStr)] set; }

			/// <summary>Gets the type of action.</summary>
			/// <value>This property returns one of the following TASK_ACTION_TYPE enumeration constants.</value>
			TASK_ACTION_TYPE Type { get; }
		}

		/// <summary>Contains the actions that are performed by the task.</summary>
		/// <seealso cref="System.Collections.IEnumerable"/>
		[ComImport, Guid("02820E19-7B98-4ED2-B2E8-FDCCCEFF619B"), InterfaceType(ComInterfaceType.InterfaceIsDual),
		 System.Security.SuppressUnmanagedCodeSecurity]
		[PInvokeData("taskschd.h", MSDNShortId = "aa446901")]
		public interface IActionCollection : IEnumerable
		{
			/// <summary>Gets the number of actions in the collection.</summary>
			/// <value>The number of actions in the collection. The collection can contain up to 32 actions.</value>
			int Count { get; }

			/// <summary>Gets a specified action from the collection.</summary>
			/// <value>An <see cref="IAction"/> interface that represents the requested action.</value>
			/// <param name="index">The index. Collections are 1-based. In other words, the index for the first item in the collection is 1.</param>
			IAction this[int index] { [return: MarshalAs(UnmanagedType.Interface)] get; }

			/// <summary>Returns an enumerator that iterates through a collection.</summary>
			/// <returns>An <see cref="T:System.Collections.IEnumerator"/> object that can be used to iterate through the collection.</returns>
			[return: MarshalAs(UnmanagedType.Interface)]
			new IEnumerator GetEnumerator();

			/// <summary>Gets or sets an XML-formatted version of the collection.</summary>
			/// <value>An XML-formatted version of the collection.</value>
			string XmlText { [return: MarshalAs(UnmanagedType.BStr)] get; [param: In, MarshalAs(UnmanagedType.BStr)] set; }

			/// <summary>Creates and adds a new action to the collection.</summary>
			/// <param name="Type">This parameter is set to one of the following TASK_ACTION_TYPE enumeration constants.</param>
			/// <returns>An <see cref="IAction"/> interface that represents the new action.</returns>
			[return: MarshalAs(UnmanagedType.Interface)]
			IAction Create([In] TASK_ACTION_TYPE Type);

			/// <summary>Removes the specified action from the collection.</summary>
			/// <param name="index">The index of the action to be removed. Use a LONG value for the index number.</param>
			void Remove([In, MarshalAs(UnmanagedType.Struct)] object index);

			/// <summary>Clears all the actions from the collection.</summary>
			void Clear();

			/// <summary>
			/// Gets or sets the identifier of the principal for the task. The principal of the task specifies the security context under which the actions of
			/// the task are performed.
			/// </summary>
			/// <value>
			/// The identifier of the principal for the task. The identifier that is specified here must match the identifier that is specified in the IPrincipal
			/// interface for the task.
			/// </value>
			string Context { [return: MarshalAs(UnmanagedType.BStr)] get; [param: In, MarshalAs(UnmanagedType.BStr)] set; }
		}

		/// <summary>Represents a trigger that starts a task when the system is started.</summary>
		/// <seealso cref="Vanara.PInvoke.TaskSchd.ITrigger"/>
		[ComImport, Guid("2A9C35DA-D357-41F4-BBC1-207AC1B1F3CB"), InterfaceType(ComInterfaceType.InterfaceIsDual),
		 System.Security.SuppressUnmanagedCodeSecurity]
		[PInvokeData("taskschd.h", MSDNShortId = "aa380607")]
		public interface IBootTrigger : ITrigger
		{
			/// <summary>
			/// Gets the type of the trigger. The trigger type is defined when the trigger is created and cannot be changed later. For information on creating a
			/// trigger, see ITriggerCollection::Create.
			/// </summary>
			/// <value>One of the following TASK_TRIGGER_TYPE2 enumeration values.</value>
			new TASK_TRIGGER_TYPE2 Type { get; }

			/// <summary>Gets or sets the identifier for the trigger.</summary>
			/// <value>The identifier for the trigger. This identifier is used by the Task Scheduler for logging purposes.</value>
			new string Id { [return: MarshalAs(UnmanagedType.BStr)] get; [param: In, MarshalAs(UnmanagedType.BStr)] set; }

			/// <summary>
			/// Gets or sets a value that indicates how often the task is run and how long the repetition pattern is repeated after the task is started.
			/// </summary>
			/// <value>The repetition pattern for how often the task is run and how long the repetition pattern is repeated after the task is started.</value>
			new IRepetitionPattern Repetition
			{
				[return: MarshalAs(UnmanagedType.Interface)]
				get;
				[param: In, MarshalAs(UnmanagedType.Interface)]
				set;
			}

			/// <summary>Gets or sets the maximum amount of time that the task launched by this trigger is allowed to run.</summary>
			/// <value>The maximum amount of time that the task launched by the trigger is allowed to run.</value>
			/// <remarks>
			/// The format for this string is PnYnMnDTnHnMnS, where nY is the number of years, nM is the number of months, nD is the number of days, 'T' is the
			/// date/time separator, nH is the number of hours, nM is the number of minutes, and nS is the number of seconds (for example, PT5M specifies 5
			/// minutes and P1M4DT2H5M specifies one month, four days, two hours, and five minutes).
			/// </remarks>
			new string ExecutionTimeLimit
			{
				[return: MarshalAs(UnmanagedType.BStr)]
				get;
				[param: In, MarshalAs(UnmanagedType.BStr)]
				set;
			}

			/// <summary>Gets or sets the date and time when the trigger is activated.</summary>
			/// <value>The date and time when the trigger is activated.</value>
			/// <remarks>
			/// The date and time must be in the following format: YYYY-MM-DDTHH:MM:SS(+-)HH:MM. The (+-)HH:MM section of the format defines a certain number of
			/// hours and minutes ahead or behind Coordinated Universal Time (UTC). For example the date October 11th, 2005 at 1:21:17 with an offset of eight
			/// hours behind UTC would be written as 2005-10-11T13:21:17-08:00. If Z is specified for the UTC offset (for example, 2005-10-11T13:21:17Z), then
			/// the no offset from UTC will be used. If you do not specify any offset time or Z for the offset (for example, 2005-10-11T13:21:17), then the time
			/// zone and daylight saving information that is set on the local computer will be used. When an offset is specified (using hours and minutes or Z),
			/// then the time and offset are always used regardless of the time zone and daylight saving settings on the local computer.
			/// </remarks>
			new string StartBoundary { [return: MarshalAs(UnmanagedType.BStr)] get; [param: In, MarshalAs(UnmanagedType.BStr)] set; }

			/// <summary>Gets or sets the date and time when the trigger is deactivated.</summary>
			/// <value>The date and time when the trigger is deactivated.</value>
			/// <remarks>
			/// The date and time must be in the following format: YYYY-MM-DDTHH:MM:SS(+-)HH:MM. The (+-)HH:MM section of the format defines a certain number of
			/// hours and minutes ahead or behind Coordinated Universal Time (UTC). For example the date October 11th, 2005 at 1:21:17 with an offset of eight
			/// hours behind UTC would be written as 2005-10-11T13:21:17-08:00. If Z is specified for the UTC offset (for example, 2005-10-11T13:21:17Z), then
			/// the no offset from UTC will be used. If you do not specify any offset time or Z for the offset (for example, 2005-10-11T13:21:17), then the time
			/// zone and daylight saving information that is set on the local computer will be used. When an offset is specified (using hours and minutes or Z),
			/// then the time and offset are always used regardless of the time zone and daylight saving settings on the local computer.
			/// </remarks>
			new string EndBoundary { [return: MarshalAs(UnmanagedType.BStr)] get; [param: In, MarshalAs(UnmanagedType.BStr)] set; }

			/// <summary>Gets or sets a Boolean value that indicates whether the trigger is enabled.</summary>
			/// <value>True if the trigger is enabled; otherwise, false. The default is true.</value>
			new bool Enabled { get; [param: In] set; }

			/// <summary>Gets or sets a value that indicates the amount of time between when the system is booted and when the task is started.</summary>
			/// <value>
			/// A value that indicates the amount of time between when the system is booted and when the task is started. The format for this string is
			/// PnYnMnDTnHnMnS, where nY is the number of years, nM is the number of months, nD is the number of days, 'T' is the date/time separator, nH is the
			/// number of hours, nM is the number of minutes, and nS is the number of seconds (for example, PT5M specifies 5 minutes and P1M4DT2H5M specifies one
			/// month, four days, two hours, and five minutes).
			/// </value>
			string Delay { [return: MarshalAs(UnmanagedType.BStr)] get; [param: In, MarshalAs(UnmanagedType.BStr)] set; }
		}

		/// <summary>Represents an action that fires a handler.</summary>
		/// <seealso cref="Vanara.PInvoke.TaskSchd.IAction"/>
		[ComImport, Guid("6D2FD252-75C5-4F66-90BA-2A7D8CC3039F"), InterfaceType(ComInterfaceType.InterfaceIsDual),
		 System.Security.SuppressUnmanagedCodeSecurity]
		[PInvokeData("taskschd.h", MSDNShortId = "aa380613")]
		public interface IComHandlerAction : IAction
		{
			/// <summary>Gets or sets the identifier of the action.</summary>
			/// <value>The user-defined identifier for the action. This identifier is used by the Task Scheduler for logging purposes.</value>
			new string Id { [return: MarshalAs(UnmanagedType.BStr)] get; [param: In, MarshalAs(UnmanagedType.BStr)] set; }

			/// <summary>Gets the type of action.</summary>
			/// <value>This property returns one of the following TASK_ACTION_TYPE enumeration constants.</value>
			new TASK_ACTION_TYPE Type { get; }

			/// <summary>Gets or sets the identifier of the handler class.</summary>
			/// <value>The identifier of the class that defines the handler to be fired.</value>
			string ClassId { [return: MarshalAs(UnmanagedType.BStr)] get; [param: In, MarshalAs(UnmanagedType.BStr)] set; }

			/// <summary>Gets or sets additional data that is associated with the handler.</summary>
			/// <value>The arguments that are needed by the handler.</value>
			string Data { [return: MarshalAs(UnmanagedType.BStr)] get; [param: In, MarshalAs(UnmanagedType.BStr)] set; }
		}

		/// <summary>
		/// Represents a trigger that starts a task based on a daily schedule. For example, the task starts at a specific time every day, every other day, every
		/// third day, and so on.
		/// </summary>
		/// <seealso cref="Vanara.PInvoke.TaskSchd.ITrigger"/>
		[ComImport, InterfaceType(ComInterfaceType.InterfaceIsDual), Guid("126C5CD8-B288-41D5-8DBF-E491446ADC5C"),
		 System.Security.SuppressUnmanagedCodeSecurity]
		[PInvokeData("taskschd.h", MSDNShortId = "aa380656")]
		public interface IDailyTrigger : ITrigger
		{
			/// <summary>
			/// Gets the type of the trigger. The trigger type is defined when the trigger is created and cannot be changed later. For information on creating a
			/// trigger, see ITriggerCollection::Create.
			/// </summary>
			/// <value>One of the following TASK_TRIGGER_TYPE2 enumeration values.</value>
			new TASK_TRIGGER_TYPE2 Type { get; }

			/// <summary>Gets or sets the identifier for the trigger.</summary>
			/// <value>The identifier for the trigger. This identifier is used by the Task Scheduler for logging purposes.</value>
			new string Id { [return: MarshalAs(UnmanagedType.BStr)] get; [param: In, MarshalAs(UnmanagedType.BStr)] set; }

			/// <summary>
			/// Gets or sets a value that indicates how often the task is run and how long the repetition pattern is repeated after the task is started.
			/// </summary>
			/// <value>The repetition pattern for how often the task is run and how long the repetition pattern is repeated after the task is started.</value>
			new IRepetitionPattern Repetition
			{
				[return: MarshalAs(UnmanagedType.Interface)]
				get;
				[param: In, MarshalAs(UnmanagedType.Interface)]
				set;
			}

			/// <summary>Gets or sets the maximum amount of time that the task launched by this trigger is allowed to run.</summary>
			/// <value>The maximum amount of time that the task launched by the trigger is allowed to run.</value>
			/// <remarks>
			/// The format for this string is PnYnMnDTnHnMnS, where nY is the number of years, nM is the number of months, nD is the number of days, 'T' is the
			/// date/time separator, nH is the number of hours, nM is the number of minutes, and nS is the number of seconds (for example, PT5M specifies 5
			/// minutes and P1M4DT2H5M specifies one month, four days, two hours, and five minutes).
			/// </remarks>
			new string ExecutionTimeLimit
			{
				[return: MarshalAs(UnmanagedType.BStr)]
				get;
				[param: In, MarshalAs(UnmanagedType.BStr)]
				set;
			}

			/// <summary>Gets or sets the date and time when the trigger is activated.</summary>
			/// <value>The date and time when the trigger is activated.</value>
			/// <remarks>
			/// The date and time must be in the following format: YYYY-MM-DDTHH:MM:SS(+-)HH:MM. The (+-)HH:MM section of the format defines a certain number of
			/// hours and minutes ahead or behind Coordinated Universal Time (UTC). For example the date October 11th, 2005 at 1:21:17 with an offset of eight
			/// hours behind UTC would be written as 2005-10-11T13:21:17-08:00. If Z is specified for the UTC offset (for example, 2005-10-11T13:21:17Z), then
			/// the no offset from UTC will be used. If you do not specify any offset time or Z for the offset (for example, 2005-10-11T13:21:17), then the time
			/// zone and daylight saving information that is set on the local computer will be used. When an offset is specified (using hours and minutes or Z),
			/// then the time and offset are always used regardless of the time zone and daylight saving settings on the local computer.
			/// </remarks>
			new string StartBoundary { [return: MarshalAs(UnmanagedType.BStr)] get; [param: In, MarshalAs(UnmanagedType.BStr)] set; }

			/// <summary>Gets or sets the date and time when the trigger is deactivated.</summary>
			/// <value>The date and time when the trigger is deactivated.</value>
			/// <remarks>
			/// The date and time must be in the following format: YYYY-MM-DDTHH:MM:SS(+-)HH:MM. The (+-)HH:MM section of the format defines a certain number of
			/// hours and minutes ahead or behind Coordinated Universal Time (UTC). For example the date October 11th, 2005 at 1:21:17 with an offset of eight
			/// hours behind UTC would be written as 2005-10-11T13:21:17-08:00. If Z is specified for the UTC offset (for example, 2005-10-11T13:21:17Z), then
			/// the no offset from UTC will be used. If you do not specify any offset time or Z for the offset (for example, 2005-10-11T13:21:17), then the time
			/// zone and daylight saving information that is set on the local computer will be used. When an offset is specified (using hours and minutes or Z),
			/// then the time and offset are always used regardless of the time zone and daylight saving settings on the local computer.
			/// </remarks>
			new string EndBoundary { [return: MarshalAs(UnmanagedType.BStr)] get; [param: In, MarshalAs(UnmanagedType.BStr)] set; }

			/// <summary>Gets or sets a Boolean value that indicates whether the trigger is enabled.</summary>
			/// <value>True if the trigger is enabled; otherwise, false. The default is true.</value>
			new bool Enabled { get; [param: In] set; }

			/// <summary>Gets or sets the interval between the days in the schedule.</summary>
			/// <value>The interval between the days in the schedule.</value>
			short DaysInterval { get; [param: In] set; }

			/// <summary>Gets or sets a delay time that is randomly added to the start time of the trigger.</summary>
			/// <value>
			/// A BSTR value that contains the upper bound of the random delay time that is added to the start time of the trigger. The format for this string is
			/// P&lt;days&gt;DT&lt;hours&gt;H&lt;minutes&gt;M&lt;seconds&gt;S (for example, P2DT5S is a 2 day, 5 second time span).
			/// </value>
			/// <remarks>
			/// The specified random delay time is the upper bound for the random interval. The trigger will fire at random during the period specified by the
			/// randomDelay parameter, which doesn't begin until the specified start time of the trigger. For example, if the task trigger is set to every
			/// seventh day, and the randomDelay parameter is set to P2DT5S (2 day, 5 second time span), then once the seventh day is reached, the trigger will
			/// fire once randomly during the next 2 days, 5 seconds.
			/// </remarks>
			string RandomDelay { [return: MarshalAs(UnmanagedType.BStr)] get; [param: In, MarshalAs(UnmanagedType.BStr)] set; }
		}

		/// <summary>
		/// Represents an action that sends an email message. <note>This interface is no longer supported. Please use IExecAction with the powershell
		/// Send-MailMessage cmdlet as a workaround.</note>
		/// </summary>
		/// <seealso cref="Vanara.PInvoke.TaskSchd.IAction"/>
		[ComImport, Guid("10F62C64-7E16-4314-A0C2-0C3683F99D40"), InterfaceType(ComInterfaceType.InterfaceIsDual),
		 System.Security.SuppressUnmanagedCodeSecurity]
		[PInvokeData("taskschd.h", MSDNShortId = "aa380693")]
		public interface IEmailAction : IAction
		{
			/// <summary>Gets or sets the identifier of the action.</summary>
			/// <value>The user-defined identifier for the action. This identifier is used by the Task Scheduler for logging purposes.</value>
			new string Id { [return: MarshalAs(UnmanagedType.BStr)] get; [param: In, MarshalAs(UnmanagedType.BStr)] set; }

			/// <summary>Gets the type of action.</summary>
			/// <value>This property returns one of the following TASK_ACTION_TYPE enumeration constants.</value>
			new TASK_ACTION_TYPE Type { get; }

			/// <summary>Gets or sets the name of the SMTP server that you use to send email from.</summary>
			/// <value>The name of the server that you use to send email from.</value>
			/// <remarks>
			/// Make sure the SMTP server that sends the email is setup correctly. E-mail is sent using NTLM authentication for Windows SMTP servers, which means
			/// that the security credentials used for running the task must also have privileges on the SMTP server to send email message. If the SMTP server is
			/// a non-Windows based server, then the email will be sent if the server allows anonymous access. For information about setting up the SMTP server,
			/// see SMTP Server Setup, and for information about managing SMTP server settings, see SMTP Administration.
			/// </remarks>
			string Server { [return: MarshalAs(UnmanagedType.BStr)] get; [param: In, MarshalAs(UnmanagedType.BStr)] set; }

			/// <summary>Gets or sets the subject of the email message.</summary>
			/// <value>The subject of the email message.</value>
			/// <remarks>
			/// When setting this property value, the value can be text that is retrieved from a resource .dll file. A specialized string is used to reference
			/// the text from the resource file. The format of the string is $(@ [Dll], [ResourceID]) where [Dll] is the path to the .dll file that contains the
			/// resource and [ResourceID] is the identifier for the resource text. For example, the setting this property value to $(@
			/// %SystemRoot%\System32\ResourceName.dll, -101) will set the property to the value of the resource text with an identifier equal to -101 in the
			/// %SystemRoot%\System32\ResourceName.dll file.
			/// </remarks>
			string Subject { [return: MarshalAs(UnmanagedType.BStr)] get; [param: In, MarshalAs(UnmanagedType.BStr)] set; }

			/// <summary>Gets or sets to.</summary>
			/// <value>To.</value>
			string To { [return: MarshalAs(UnmanagedType.BStr)] get; [param: In, MarshalAs(UnmanagedType.BStr)] set; }

			/// <summary>Gets or sets the email address or addresses that you want to Cc in the email message.</summary>
			/// <value>The email address or addresses that you want to Cc in the email message.</value>
			string Cc { [return: MarshalAs(UnmanagedType.BStr)] get; [param: In, MarshalAs(UnmanagedType.BStr)] set; }

			/// <summary>Gets or sets the email address or addresses that you want to Bcc in the email message.</summary>
			/// <value>The email address or addresses that you want to Bcc in the email message.</value>
			string Bcc { [return: MarshalAs(UnmanagedType.BStr)] get; [param: In, MarshalAs(UnmanagedType.BStr)] set; }

			/// <summary>Gets or sets the email address that you want to reply to.</summary>
			/// <value>The email address that you want to reply to.</value>
			string ReplyTo { [return: MarshalAs(UnmanagedType.BStr)] get; [param: In, MarshalAs(UnmanagedType.BStr)] set; }

			/// <summary>Gets or sets the email address that you want to send the email from.</summary>
			/// <value>The email address that you want to send the email from.</value>
			string From { [return: MarshalAs(UnmanagedType.BStr)] get; [param: In, MarshalAs(UnmanagedType.BStr)] set; }

			/// <summary>Gets or sets the header information in the email message to send.</summary>
			/// <value>The header information in the email message to send.</value>
			ITaskNamedValueCollection HeaderFields
			{
				[return: MarshalAs(UnmanagedType.Interface)]
				get;
				[param: In, MarshalAs(UnmanagedType.Interface)]
				set;
			}

			/// <summary>Gets or sets the body of the email that contains the email message.</summary>
			/// <value>The body of the email that contains the email message.</value>
			/// <remarks>
			/// When setting this property value, the value can be text that is retrieved from a resource .dll file. A specialized string is used to reference
			/// the text from the resource file. The format of the string is $(@ [Dll], [ResourceID]) where [Dll] is the path to the .dll file that contains the
			/// resource and [ResourceID] is the identifier for the resource text. For example, the setting this property value to $(@
			/// %SystemRoot%\System32\ResourceName.dll, -101) will set the property to the value of the resource text with an identifier equal to -101 in the
			/// %SystemRoot%\System32\ResourceName.dll file.
			/// </remarks>
			string Body { [return: MarshalAs(UnmanagedType.BStr)] get; [param: In, MarshalAs(UnmanagedType.BStr)] set; }

			/// <summary>Gets or sets the pointer to an array of attachments that is sent with the email message.</summary>
			/// <value>An array of attachments that is sent with the email message.</value>
			object[] Attachments
			{
				[return: MarshalAs(UnmanagedType.SafeArray, SafeArraySubType = VarEnum.VT_VARIANT)]
				get;
				[param: In, MarshalAs(UnmanagedType.SafeArray, SafeArraySubType = VarEnum.VT_VARIANT)]
				set;
			}
		}

		/// <summary>Represents a trigger that starts a task when a system event occurs.</summary>
		/// <seealso cref="Vanara.PInvoke.TaskSchd.ITrigger"/>
		[ComImport, Guid("D45B0167-9653-4EEF-B94F-0732CA7AF251"), InterfaceType(ComInterfaceType.InterfaceIsDual),
		 System.Security.SuppressUnmanagedCodeSecurity]
		[PInvokeData("taskschd.h", MSDNShortId = "aa380711")]
		public interface IEventTrigger : ITrigger
		{
			/// <summary>
			/// Gets the type of the trigger. The trigger type is defined when the trigger is created and cannot be changed later. For information on creating a
			/// trigger, see ITriggerCollection::Create.
			/// </summary>
			/// <value>One of the following TASK_TRIGGER_TYPE2 enumeration values.</value>
			new TASK_TRIGGER_TYPE2 Type { get; }

			/// <summary>Gets or sets the identifier for the trigger.</summary>
			/// <value>The identifier for the trigger. This identifier is used by the Task Scheduler for logging purposes.</value>
			new string Id { [return: MarshalAs(UnmanagedType.BStr)] get; [param: In, MarshalAs(UnmanagedType.BStr)] set; }

			/// <summary>
			/// Gets or sets a value that indicates how often the task is run and how long the repetition pattern is repeated after the task is started.
			/// </summary>
			/// <value>The repetition pattern for how often the task is run and how long the repetition pattern is repeated after the task is started.</value>
			new IRepetitionPattern Repetition
			{
				[return: MarshalAs(UnmanagedType.Interface)]
				get;
				[param: In, MarshalAs(UnmanagedType.Interface)]
				set;
			}

			/// <summary>Gets or sets the maximum amount of time that the task launched by this trigger is allowed to run.</summary>
			/// <value>The maximum amount of time that the task launched by the trigger is allowed to run.</value>
			/// <remarks>
			/// The format for this string is PnYnMnDTnHnMnS, where nY is the number of years, nM is the number of months, nD is the number of days, 'T' is the
			/// date/time separator, nH is the number of hours, nM is the number of minutes, and nS is the number of seconds (for example, PT5M specifies 5
			/// minutes and P1M4DT2H5M specifies one month, four days, two hours, and five minutes).
			/// </remarks>
			new string ExecutionTimeLimit
			{
				[return: MarshalAs(UnmanagedType.BStr)]
				get;
				[param: In, MarshalAs(UnmanagedType.BStr)]
				set;
			}

			/// <summary>Gets or sets the date and time when the trigger is activated.</summary>
			/// <value>The date and time when the trigger is activated.</value>
			/// <remarks>
			/// The date and time must be in the following format: YYYY-MM-DDTHH:MM:SS(+-)HH:MM. The (+-)HH:MM section of the format defines a certain number of
			/// hours and minutes ahead or behind Coordinated Universal Time (UTC). For example the date October 11th, 2005 at 1:21:17 with an offset of eight
			/// hours behind UTC would be written as 2005-10-11T13:21:17-08:00. If Z is specified for the UTC offset (for example, 2005-10-11T13:21:17Z), then
			/// the no offset from UTC will be used. If you do not specify any offset time or Z for the offset (for example, 2005-10-11T13:21:17), then the time
			/// zone and daylight saving information that is set on the local computer will be used. When an offset is specified (using hours and minutes or Z),
			/// then the time and offset are always used regardless of the time zone and daylight saving settings on the local computer.
			/// </remarks>
			new string StartBoundary { [return: MarshalAs(UnmanagedType.BStr)] get; [param: In, MarshalAs(UnmanagedType.BStr)] set; }

			/// <summary>Gets or sets the date and time when the trigger is deactivated.</summary>
			/// <value>The date and time when the trigger is deactivated.</value>
			/// <remarks>
			/// The date and time must be in the following format: YYYY-MM-DDTHH:MM:SS(+-)HH:MM. The (+-)HH:MM section of the format defines a certain number of
			/// hours and minutes ahead or behind Coordinated Universal Time (UTC). For example the date October 11th, 2005 at 1:21:17 with an offset of eight
			/// hours behind UTC would be written as 2005-10-11T13:21:17-08:00. If Z is specified for the UTC offset (for example, 2005-10-11T13:21:17Z), then
			/// the no offset from UTC will be used. If you do not specify any offset time or Z for the offset (for example, 2005-10-11T13:21:17), then the time
			/// zone and daylight saving information that is set on the local computer will be used. When an offset is specified (using hours and minutes or Z),
			/// then the time and offset are always used regardless of the time zone and daylight saving settings on the local computer.
			/// </remarks>
			new string EndBoundary { [return: MarshalAs(UnmanagedType.BStr)] get; [param: In, MarshalAs(UnmanagedType.BStr)] set; }

			/// <summary>Gets or sets a Boolean value that indicates whether the trigger is enabled.</summary>
			/// <value>True if the trigger is enabled; otherwise, false. The default is true.</value>
			new bool Enabled { get; [param: In] set; }

			/// <summary>Gets or sets a query string that identifies the event that fires the trigger.</summary>
			/// <value>A query string that identifies the event that fires the trigger.</value>
			string Subscription { [return: MarshalAs(UnmanagedType.BStr)] get; [param: In, MarshalAs(UnmanagedType.BStr)] set; }

			/// <summary>
			/// Gets or sets a value that indicates the amount of time between when the event occurs and when the task is started. The format for this string is
			/// PnYnMnDTnHnMnS, where nY is the number of years, nM is the number of months, nD is the number of days, 'T' is the date/time separator, nH is the
			/// number of hours, nM is the number of minutes, and nS is the number of seconds (for example, PT5M specifies 5 minutes and P1M4DT2H5M specifies one
			/// month, four days, two hours, and five minutes).
			/// </summary>
			/// <value>A value that indicates the amount of time between when the event occurs and when the task is started.</value>
			string Delay { [return: MarshalAs(UnmanagedType.BStr)] get; [param: In, MarshalAs(UnmanagedType.BStr)] set; }

			/// <summary>
			/// Gets or sets a collection of named XPath queries. Each query in the collection is applied to the last matching event XML returned from the
			/// subscription query specified in the Subscription property.
			/// </summary>
			/// <value>
			/// A pointer to collection of name-value pairs. Each name-value pair in the collection defines a unique name for a property value of the event that
			/// triggers the event trigger. The property value of the event is defined as an XPath event query. For more information about XPath event queries,
			/// see Event Selection.
			/// </value>
			ITaskNamedValueCollection ValueQueries
			{
				[return: MarshalAs(UnmanagedType.Interface)]
				get;
				[param: In, MarshalAs(UnmanagedType.Interface)]
				set;
			}
		}

		/// <summary>Represents an action that executes a command-line operation.</summary>
		/// <seealso cref="Vanara.PInvoke.TaskSchd.IAction"/>
		[ComImport, Guid("4C3D624D-FD6B-49A3-B9B7-09CB3CD3F047"), InterfaceType(ComInterfaceType.InterfaceIsDual),
		 System.Security.SuppressUnmanagedCodeSecurity]
		[PInvokeData("taskschd.h", MSDNShortId = "aa380715")]
		public interface IExecAction : IAction
		{
			/// <summary>Gets or sets the identifier of the action.</summary>
			/// <value>The user-defined identifier for the action. This identifier is used by the Task Scheduler for logging purposes.</value>
			new string Id { [return: MarshalAs(UnmanagedType.BStr)] get; [param: In, MarshalAs(UnmanagedType.BStr)] set; }

			/// <summary>Gets the type of action.</summary>
			/// <value>This property returns one of the following TASK_ACTION_TYPE enumeration constants.</value>
			new TASK_ACTION_TYPE Type { get; }

			/// <summary>Gets or sets the path to an executable file.</summary>
			/// <value>The path to the executable file to be run by the action.</value>
			/// <remarks>
			/// This action performs a command-line operation. For example, the action could run a script or launch an executable.
			/// <para>The path is checked to make sure it is valid when the task is registered, not when this property is set.</para>
			/// </remarks>
			string Path { [return: MarshalAs(UnmanagedType.BStr)] get; [param: In, MarshalAs(UnmanagedType.BStr)] set; }

			/// <summary>Gets or sets the arguments associated with the command-line operation.</summary>
			/// <value>The arguments that are needed by the command-line operation.</value>
			string Arguments { [return: MarshalAs(UnmanagedType.BStr)] get; [param: In, MarshalAs(UnmanagedType.BStr)] set; }

			/// <summary>Gets or sets the directory that contains either the executable file or the files that are used by the executable file.</summary>
			/// <value>The directory that contains either the executable file or the files that are used by the executable file.</value>
			/// <remarks>The path is checked to make sure it is valid when the task is registered, not when this property is set.</remarks>
			string WorkingDirectory
			{
				[return: MarshalAs(UnmanagedType.BStr)]
				get;
				[param: In, MarshalAs(UnmanagedType.BStr)]
				set;
			}
		}

		/// <summary>
		/// Specifies how the Task Scheduler performs tasks when the computer is in an idle condition. For information about idle conditions, see Task Idle Conditions.
		/// </summary>
		[ComImport, Guid("84594461-0053-4342-A8FD-088FABF11F32"), InterfaceType(ComInterfaceType.InterfaceIsDual),
		 System.Security.SuppressUnmanagedCodeSecurity]
		[PInvokeData("taskschd.h", MSDNShortId = "aa380719")]
		public interface IIdleSettings
		{
			/// <summary>Gets or sets a value that indicates the amount of time that the computer must be in an idle state before the task is run.</summary>
			/// <value>
			/// A value that indicates the amount of time that the computer must be in an idle state before the task is run. The format for this string is
			/// PnYnMnDTnHnMnS, where nY is the number of years, nM is the number of months, nD is the number of days, 'T' is the date/time separator, nH is the
			/// number of hours, nM is the number of minutes, and nS is the number of seconds (for example, PT5M specifies 5 minutes and P1M4DT2H5M specifies one
			/// month, four days, two hours, and five minutes). The minimum value is one minute. If this value is NULL, then the delay will be set to the default
			/// of 10 minutes.
			/// </value>
			string IdleDuration { [return: MarshalAs(UnmanagedType.BStr)] get; [param: In, MarshalAs(UnmanagedType.BStr)] set; }

			/// <summary>
			/// Gets or sets a value that indicates the amount of time that the Task Scheduler will wait for an idle condition to occur. If no value is specified
			/// for this property, then the Task Scheduler service will wait indefinitely for an idle condition to occur.
			/// </summary>
			/// <value>
			/// A value that indicates the amount of time that the Task Scheduler will wait for an idle condition to occur. The format for this string is
			/// PnYnMnDTnHnMnS, where nY is the number of years, nM is the number of months, nD is the number of days, 'T' is the date/time separator, nH is the
			/// number of hours, nM is the number of minutes, and nS is the number of seconds (for example, PT5M specifies 5 minutes and P1M4DT2H5M specifies one
			/// month, four days, two hours, and five minutes). The minimum time allowed is 1 minute. If this value is NULL, then the delay will be set to the
			/// default of 1 hour.
			/// </value>
			string WaitTimeout { [return: MarshalAs(UnmanagedType.BStr)] get; [param: In, MarshalAs(UnmanagedType.BStr)] set; }

			/// <summary>
			/// Gets or sets a Boolean value that indicates that the Task Scheduler will terminate the task if the idle condition ends before the task is
			/// completed. The idle condition ends when the computer is no longer idle.
			/// </summary>
			/// <value>
			/// A Boolean value that indicates that the Task Scheduler will terminate the task if the idle condition ends before the task is completed. The idle
			/// condition ends when the computer is no longer idle.
			/// </value>
			bool StopOnIdleEnd { get; [param: In] set; }

			/// <summary>
			/// Gets or sets a Boolean value that indicates whether the task is restarted when the computer cycles into an idle condition more than once.
			/// </summary>
			/// <value>
			/// A Boolean value that indicates whether the task must be restarted when the computer cycles into an idle condition more than once. The default is False.
			/// </value>
			bool RestartOnIdle { get; [param: In] set; }
		}

		/// <summary>
		/// Represents a trigger that starts a task when the computer goes into an idle state. For information about idle conditions, see Task Idle Conditions.
		/// </summary>
		/// <seealso cref="Vanara.PInvoke.TaskSchd.ITrigger"/>
		[ComImport, Guid("D537D2B0-9FB3-4D34-9739-1FF5CE7B1EF3"), InterfaceType(ComInterfaceType.InterfaceIsDual),
		 System.Security.SuppressUnmanagedCodeSecurity]
		[PInvokeData("taskschd.h", MSDNShortId = "aa380724")]
		public interface IIdleTrigger : ITrigger
		{
			/// <summary>
			/// Gets the type of the trigger. The trigger type is defined when the trigger is created and cannot be changed later. For information on creating a
			/// trigger, see ITriggerCollection::Create.
			/// </summary>
			/// <value>One of the following TASK_TRIGGER_TYPE2 enumeration values.</value>
			new TASK_TRIGGER_TYPE2 Type { get; }

			/// <summary>Gets or sets the identifier for the trigger.</summary>
			/// <value>The identifier for the trigger. This identifier is used by the Task Scheduler for logging purposes.</value>
			new string Id { [return: MarshalAs(UnmanagedType.BStr)] get; [param: In, MarshalAs(UnmanagedType.BStr)] set; }

			/// <summary>
			/// Gets or sets a value that indicates how often the task is run and how long the repetition pattern is repeated after the task is started.
			/// </summary>
			/// <value>The repetition pattern for how often the task is run and how long the repetition pattern is repeated after the task is started.</value>
			new IRepetitionPattern Repetition
			{
				[return: MarshalAs(UnmanagedType.Interface)]
				get;
				[param: In, MarshalAs(UnmanagedType.Interface)]
				set;
			}

			/// <summary>Gets or sets the maximum amount of time that the task launched by this trigger is allowed to run.</summary>
			/// <value>The maximum amount of time that the task launched by the trigger is allowed to run.</value>
			/// <remarks>
			/// The format for this string is PnYnMnDTnHnMnS, where nY is the number of years, nM is the number of months, nD is the number of days, 'T' is the
			/// date/time separator, nH is the number of hours, nM is the number of minutes, and nS is the number of seconds (for example, PT5M specifies 5
			/// minutes and P1M4DT2H5M specifies one month, four days, two hours, and five minutes).
			/// </remarks>
			new string ExecutionTimeLimit
			{
				[return: MarshalAs(UnmanagedType.BStr)]
				get;
				[param: In, MarshalAs(UnmanagedType.BStr)]
				set;
			}

			/// <summary>Gets or sets the date and time when the trigger is activated.</summary>
			/// <value>The date and time when the trigger is activated.</value>
			/// <remarks>
			/// The date and time must be in the following format: YYYY-MM-DDTHH:MM:SS(+-)HH:MM. The (+-)HH:MM section of the format defines a certain number of
			/// hours and minutes ahead or behind Coordinated Universal Time (UTC). For example the date October 11th, 2005 at 1:21:17 with an offset of eight
			/// hours behind UTC would be written as 2005-10-11T13:21:17-08:00. If Z is specified for the UTC offset (for example, 2005-10-11T13:21:17Z), then
			/// the no offset from UTC will be used. If you do not specify any offset time or Z for the offset (for example, 2005-10-11T13:21:17), then the time
			/// zone and daylight saving information that is set on the local computer will be used. When an offset is specified (using hours and minutes or Z),
			/// then the time and offset are always used regardless of the time zone and daylight saving settings on the local computer.
			/// </remarks>
			new string StartBoundary { [return: MarshalAs(UnmanagedType.BStr)] get; [param: In, MarshalAs(UnmanagedType.BStr)] set; }

			/// <summary>Gets or sets the date and time when the trigger is deactivated.</summary>
			/// <value>The date and time when the trigger is deactivated.</value>
			/// <remarks>
			/// The date and time must be in the following format: YYYY-MM-DDTHH:MM:SS(+-)HH:MM. The (+-)HH:MM section of the format defines a certain number of
			/// hours and minutes ahead or behind Coordinated Universal Time (UTC). For example the date October 11th, 2005 at 1:21:17 with an offset of eight
			/// hours behind UTC would be written as 2005-10-11T13:21:17-08:00. If Z is specified for the UTC offset (for example, 2005-10-11T13:21:17Z), then
			/// the no offset from UTC will be used. If you do not specify any offset time or Z for the offset (for example, 2005-10-11T13:21:17), then the time
			/// zone and daylight saving information that is set on the local computer will be used. When an offset is specified (using hours and minutes or Z),
			/// then the time and offset are always used regardless of the time zone and daylight saving settings on the local computer.
			/// </remarks>
			new string EndBoundary { [return: MarshalAs(UnmanagedType.BStr)] get; [param: In, MarshalAs(UnmanagedType.BStr)] set; }

			/// <summary>Gets or sets a Boolean value that indicates whether the trigger is enabled.</summary>
			/// <value>True if the trigger is enabled; otherwise, false. The default is true.</value>
			new bool Enabled { get; [param: In] set; }
		}

		/// <summary>
		/// Represents a trigger that starts a task when a user logs on. When the Task Scheduler service starts, all logged-on users are enumerated and any tasks
		/// registered with logon triggers that match the logged on user are run.
		/// </summary>
		/// <seealso cref="Vanara.PInvoke.TaskSchd.ITrigger"/>
		[ComImport, Guid("72DADE38-FAE4-4B3E-BAF4-5D009AF02B1C"), InterfaceType(ComInterfaceType.InterfaceIsDual),
		 System.Security.SuppressUnmanagedCodeSecurity]
		[PInvokeData("taskschd.h", MSDNShortId = "aa380725")]
		public interface ILogonTrigger : ITrigger
		{
			/// <summary>
			/// Gets the type of the trigger. The trigger type is defined when the trigger is created and cannot be changed later. For information on creating a
			/// trigger, see ITriggerCollection::Create.
			/// </summary>
			/// <value>One of the following TASK_TRIGGER_TYPE2 enumeration values.</value>
			new TASK_TRIGGER_TYPE2 Type { get; }

			/// <summary>Gets or sets the identifier for the trigger.</summary>
			/// <value>The identifier for the trigger. This identifier is used by the Task Scheduler for logging purposes.</value>
			new string Id { [return: MarshalAs(UnmanagedType.BStr)] get; [param: In, MarshalAs(UnmanagedType.BStr)] set; }

			/// <summary>
			/// Gets or sets a value that indicates how often the task is run and how long the repetition pattern is repeated after the task is started.
			/// </summary>
			/// <value>The repetition pattern for how often the task is run and how long the repetition pattern is repeated after the task is started.</value>
			new IRepetitionPattern Repetition
			{
				[return: MarshalAs(UnmanagedType.Interface)]
				get;
				[param: In, MarshalAs(UnmanagedType.Interface)]
				set;
			}

			/// <summary>Gets or sets the maximum amount of time that the task launched by this trigger is allowed to run.</summary>
			/// <value>The maximum amount of time that the task launched by the trigger is allowed to run.</value>
			/// <remarks>
			/// The format for this string is PnYnMnDTnHnMnS, where nY is the number of years, nM is the number of months, nD is the number of days, 'T' is the
			/// date/time separator, nH is the number of hours, nM is the number of minutes, and nS is the number of seconds (for example, PT5M specifies 5
			/// minutes and P1M4DT2H5M specifies one month, four days, two hours, and five minutes).
			/// </remarks>
			new string ExecutionTimeLimit
			{
				[return: MarshalAs(UnmanagedType.BStr)]
				get;
				[param: In, MarshalAs(UnmanagedType.BStr)]
				set;
			}

			/// <summary>Gets or sets the date and time when the trigger is activated.</summary>
			/// <value>The date and time when the trigger is activated.</value>
			/// <remarks>
			/// The date and time must be in the following format: YYYY-MM-DDTHH:MM:SS(+-)HH:MM. The (+-)HH:MM section of the format defines a certain number of
			/// hours and minutes ahead or behind Coordinated Universal Time (UTC). For example the date October 11th, 2005 at 1:21:17 with an offset of eight
			/// hours behind UTC would be written as 2005-10-11T13:21:17-08:00. If Z is specified for the UTC offset (for example, 2005-10-11T13:21:17Z), then
			/// the no offset from UTC will be used. If you do not specify any offset time or Z for the offset (for example, 2005-10-11T13:21:17), then the time
			/// zone and daylight saving information that is set on the local computer will be used. When an offset is specified (using hours and minutes or Z),
			/// then the time and offset are always used regardless of the time zone and daylight saving settings on the local computer.
			/// </remarks>
			new string StartBoundary { [return: MarshalAs(UnmanagedType.BStr)] get; [param: In, MarshalAs(UnmanagedType.BStr)] set; }

			/// <summary>Gets or sets the date and time when the trigger is deactivated.</summary>
			/// <value>The date and time when the trigger is deactivated.</value>
			/// <remarks>
			/// The date and time must be in the following format: YYYY-MM-DDTHH:MM:SS(+-)HH:MM. The (+-)HH:MM section of the format defines a certain number of
			/// hours and minutes ahead or behind Coordinated Universal Time (UTC). For example the date October 11th, 2005 at 1:21:17 with an offset of eight
			/// hours behind UTC would be written as 2005-10-11T13:21:17-08:00. If Z is specified for the UTC offset (for example, 2005-10-11T13:21:17Z), then
			/// the no offset from UTC will be used. If you do not specify any offset time or Z for the offset (for example, 2005-10-11T13:21:17), then the time
			/// zone and daylight saving information that is set on the local computer will be used. When an offset is specified (using hours and minutes or Z),
			/// then the time and offset are always used regardless of the time zone and daylight saving settings on the local computer.
			/// </remarks>
			new string EndBoundary { [return: MarshalAs(UnmanagedType.BStr)] get; [param: In, MarshalAs(UnmanagedType.BStr)] set; }

			/// <summary>Gets or sets a Boolean value that indicates whether the trigger is enabled.</summary>
			/// <value>True if the trigger is enabled; otherwise, false. The default is true.</value>
			new bool Enabled { get; [param: In] set; }

			/// <summary>Gets or sets a value that indicates the amount of time between when the user logs on and when the task is started.</summary>
			/// <value>
			/// A value that indicates the amount of time between when the user logs on and when the task is started. The format for this string is
			/// PnYnMnDTnHnMnS, where nY is the number of years, nM is the number of months, nD is the number of days, 'T' is the date/time separator, nH is the
			/// number of hours, nM is the number of minutes, and nS is the number of seconds (for example, PT5M specifies 5 minutes and P1M4DT2H5M specifies one
			/// month, four days, two hours, and five minutes).
			/// </value>
			string Delay { [return: MarshalAs(UnmanagedType.BStr)] get; [param: In, MarshalAs(UnmanagedType.BStr)] set; }

			/// <summary>Gets or sets the identifier of the user.</summary>
			/// <value>
			/// The identifier of the user. For example, "MyDomain\MyName" or for a local account, "Administrator".
			/// <para>This property can be in one of the following formats:</para>
			/// <list type="bullet">
			/// <item>
			/// <term>User name or SID: The task is started when the user logs on to the computer.</term>
			/// </item>
			/// <item>
			/// <term>Group name or SID string: The task is started when a member of the user group logs on to the computer.</term>
			/// </item>
			/// <item>
			/// <term>NULL: The task is started when any user logs on to the computer.</term>
			/// </item>
			/// </list>
			/// </value>
			string UserId { [return: MarshalAs(UnmanagedType.BStr)] get; [param: In, MarshalAs(UnmanagedType.BStr)] set; }
		}

		/// <summary>Provides the settings that the Task Scheduler uses to perform task during Automatic maintenance.</summary>
		[ComImport, Guid("A6024FA8-9652-4ADB-A6BF-5CFCD877A7BA"), InterfaceType(ComInterfaceType.InterfaceIsDual),
		 System.Security.SuppressUnmanagedCodeSecurity]
		[PInvokeData("taskschd.h", MSDNShortId = "hh832144")]
		public interface IMaintenanceSettings
		{
			/// <summary>Gets or sets the amount of time the task needs to be once executed during regular Automatic maintenance.</summary>
			/// <value>
			/// The periodicity at which the task is attempted by Automatic maintenance.
			/// <para>
			/// The format for this string is PnYnMnDTnHnMnS, where nY is the number of years, nM is the number of months, nD is the number of days, T is the
			/// date/time separator, nH is the number of hours, nM is the number of minutes, and nS is the number of seconds (for example, "PT5M" specifies 5
			/// minutes and "P1M4DT2H5M" specifies one month, four days, two hours, and five minutes). The minimum value is one minute. For more information
			/// about the duration type, see XML Schema Part 2: Datatypes Second Edition. Minimum Deadline a task can use is 1 day. The value of the Deadline
			/// element should be greater than the value of the Period element. If the deadline is not specified the task will not be started during emergency
			/// Automatic maintenance.
			/// </para>
			/// <para>The minimum value for this property is 1 day (P1D).</para>
			/// </value>
			string Period { [param: In, MarshalAs(UnmanagedType.BStr)] set; [return: MarshalAs(UnmanagedType.BStr)] get; }

			/// <summary>
			/// Gets or sets the amount of time after which the Task scheduler attempts to run the task during emergency Automatic maintenance, if the task
			/// failed to complete during regular Automatic maintenance.
			/// </summary>
			/// <value>
			/// A string that specifies the amount of time after which the Task scheduler attempts to run the task during emergency Automatic maintenance, if the
			/// task failed to complete during regular Automatic maintenance.
			/// <para>
			/// The format for this string is PnYnMnDTnHnMnS, where nY is the number of years, nM is the number of months, nD is the number of days, T is the
			/// date/time separator, nH is the number of hours, nM is the number of minutes, and nS is the number of seconds (for example, "PT5M" specifies 5
			/// minutes and "P1M4DT2H5M" specifies one month, four days, two hours, and five minutes). The minimum value is one minute. For more information
			/// about the duration type, see XML Schema Part 2: Datatypes Second Edition. Minimum Deadline a task can use is 1 day. The value of the Deadline
			/// element should be greater than the value of the Period element. If the deadline is not specified the task will not be started during emergency
			/// Automatic maintenance.
			/// </para>
			/// <para>The value of this property must be greater than the value of the Period property.</para>
			/// </value>
			string Deadline { [param: In, MarshalAs(UnmanagedType.BStr)] set; [return: MarshalAs(UnmanagedType.BStr)] get; }

			/// <summary>
			/// Indicates whether the Task scheduler must start the task during the Automatic maintenance in exclusive mode.
			/// <para>
			/// The exclusivity is guaranteed only between other maintenance tasks and doesn't grant any ordering priority of the task. If exclusivity is not
			/// specified, the task is started in parallel with other maintenance tasks.
			/// </para>
			/// </summary>
			/// <value>TRUE if the task is to be started exclusive of other tasks that have maintenance settings; otherwise, FALSE.</value>
			/// <remarks>
			/// Starting a task in exclusive mode means that no other maintenance task is get started in parallel with this one. Exclusivity does not guarantee
			/// the task any priority in order of execution.
			/// </remarks>
			bool Exclusive { [param: In] set; get; }
		}

		/// <summary>
		/// Represents a trigger that starts a task on a monthly day-of-week schedule. For example, the task starts on every first Thursday, May through October.
		/// </summary>
		/// <seealso cref="Vanara.PInvoke.TaskSchd.ITrigger"/>
		[ComImport, Guid("77D025A3-90FA-43AA-B52E-CDA5499B946A"), InterfaceType(ComInterfaceType.InterfaceIsDual),
		 System.Security.SuppressUnmanagedCodeSecurity]
		[PInvokeData("taskschd.h", MSDNShortId = "aa380728")]
		public interface IMonthlyDOWTrigger : ITrigger
		{
			/// <summary>
			/// Gets the type of the trigger. The trigger type is defined when the trigger is created and cannot be changed later. For information on creating a
			/// trigger, see ITriggerCollection::Create.
			/// </summary>
			/// <value>One of the following TASK_TRIGGER_TYPE2 enumeration values.</value>
			new TASK_TRIGGER_TYPE2 Type { get; }

			/// <summary>Gets or sets the identifier for the trigger.</summary>
			/// <value>The identifier for the trigger. This identifier is used by the Task Scheduler for logging purposes.</value>
			new string Id { [return: MarshalAs(UnmanagedType.BStr)] get; [param: In, MarshalAs(UnmanagedType.BStr)] set; }

			/// <summary>
			/// Gets or sets a value that indicates how often the task is run and how long the repetition pattern is repeated after the task is started.
			/// </summary>
			/// <value>The repetition pattern for how often the task is run and how long the repetition pattern is repeated after the task is started.</value>
			new IRepetitionPattern Repetition
			{
				[return: MarshalAs(UnmanagedType.Interface)]
				get;
				[param: In, MarshalAs(UnmanagedType.Interface)]
				set;
			}

			/// <summary>Gets or sets the maximum amount of time that the task launched by this trigger is allowed to run.</summary>
			/// <value>The maximum amount of time that the task launched by the trigger is allowed to run.</value>
			/// <remarks>
			/// The format for this string is PnYnMnDTnHnMnS, where nY is the number of years, nM is the number of months, nD is the number of days, 'T' is the
			/// date/time separator, nH is the number of hours, nM is the number of minutes, and nS is the number of seconds (for example, PT5M specifies 5
			/// minutes and P1M4DT2H5M specifies one month, four days, two hours, and five minutes).
			/// </remarks>
			new string ExecutionTimeLimit
			{
				[return: MarshalAs(UnmanagedType.BStr)]
				get;
				[param: In, MarshalAs(UnmanagedType.BStr)]
				set;
			}

			/// <summary>Gets or sets the date and time when the trigger is activated.</summary>
			/// <value>The date and time when the trigger is activated.</value>
			/// <remarks>
			/// The date and time must be in the following format: YYYY-MM-DDTHH:MM:SS(+-)HH:MM. The (+-)HH:MM section of the format defines a certain number of
			/// hours and minutes ahead or behind Coordinated Universal Time (UTC). For example the date October 11th, 2005 at 1:21:17 with an offset of eight
			/// hours behind UTC would be written as 2005-10-11T13:21:17-08:00. If Z is specified for the UTC offset (for example, 2005-10-11T13:21:17Z), then
			/// the no offset from UTC will be used. If you do not specify any offset time or Z for the offset (for example, 2005-10-11T13:21:17), then the time
			/// zone and daylight saving information that is set on the local computer will be used. When an offset is specified (using hours and minutes or Z),
			/// then the time and offset are always used regardless of the time zone and daylight saving settings on the local computer.
			/// </remarks>
			new string StartBoundary { [return: MarshalAs(UnmanagedType.BStr)] get; [param: In, MarshalAs(UnmanagedType.BStr)] set; }

			/// <summary>Gets or sets the date and time when the trigger is deactivated.</summary>
			/// <value>The date and time when the trigger is deactivated.</value>
			/// <remarks>
			/// The date and time must be in the following format: YYYY-MM-DDTHH:MM:SS(+-)HH:MM. The (+-)HH:MM section of the format defines a certain number of
			/// hours and minutes ahead or behind Coordinated Universal Time (UTC). For example the date October 11th, 2005 at 1:21:17 with an offset of eight
			/// hours behind UTC would be written as 2005-10-11T13:21:17-08:00. If Z is specified for the UTC offset (for example, 2005-10-11T13:21:17Z), then
			/// the no offset from UTC will be used. If you do not specify any offset time or Z for the offset (for example, 2005-10-11T13:21:17), then the time
			/// zone and daylight saving information that is set on the local computer will be used. When an offset is specified (using hours and minutes or Z),
			/// then the time and offset are always used regardless of the time zone and daylight saving settings on the local computer.
			/// </remarks>
			new string EndBoundary { [return: MarshalAs(UnmanagedType.BStr)] get; [param: In, MarshalAs(UnmanagedType.BStr)] set; }

			/// <summary>Gets or sets a Boolean value that indicates whether the trigger is enabled.</summary>
			/// <value>True if the trigger is enabled; otherwise, false. The default is true.</value>
			new bool Enabled { get; [param: In] set; }

			/// <summary>Gets or sets the days of the week during which the task runs.</summary>
			/// <value>A bitwise mask that indicates the days of the week during which the task runs.</value>
			short DaysOfWeek { get; [param: In] set; }

			/// <summary>Gets or sets the weeks of the month during which the task runs.</summary>
			/// <value>A bitwise mask that indicates the weeks of the month during which the task runs.</value>
			short WeeksOfMonth { get; [param: In] set; }

			/// <summary>Gets or sets the months of the year during which the task runs.</summary>
			/// <value>A bitwise mask that indicates the months of the year during which the task runs.</value>
			short MonthsOfYear { get; [param: In] set; }

			/// <summary>Gets or sets a Boolean value that indicates that the task runs on the last week of the month.</summary>
			/// <value>True indicates that the task runs on the last week of the month; otherwise, False.</value>
			bool RunOnLastWeekOfMonth { get; [param: In] set; }

			/// <summary>Gets or sets a delay time that is randomly added to the start time of the trigger.</summary>
			/// <value>
			/// A BSTR value that contains the upper bound of the random delay time that is added to the start time of the trigger. The format for this string is
			/// P&lt;days&gt;DT&lt;hours&gt;H&lt;minutes&gt;M&lt;seconds&gt;S (for example, P2DT5S is a 2 day, 5 second time span).
			/// </value>
			/// <remarks>
			/// The specified random delay time is the upper bound for the random interval. The trigger will fire at random during the period specified by the
			/// randomDelay parameter, which doesn't begin until the specified start time of the trigger. For example, if the task trigger is set to every
			/// seventh day, and the randomDelay parameter is set to P2DT5S (2 day, 5 second time span), then once the seventh day is reached, the trigger will
			/// fire once randomly during the next 2 days, 5 seconds.
			/// </remarks>
			string RandomDelay { [return: MarshalAs(UnmanagedType.BStr)] get; [param: In, MarshalAs(UnmanagedType.BStr)] set; }
		}

		/// <summary>Represents a trigger that starts a job based on a monthly schedule. For example, the task starts on specific days of specific months.</summary>
		/// <seealso cref="Vanara.PInvoke.TaskSchd.ITrigger"/>
		[ComImport, Guid("97C45EF1-6B02-4A1A-9C0E-1EBFBA1500AC"), InterfaceType(ComInterfaceType.InterfaceIsDual),
		 System.Security.SuppressUnmanagedCodeSecurity]
		[PInvokeData("taskschd.h", MSDNShortId = "aa380734")]
		public interface IMonthlyTrigger : ITrigger
		{
			/// <summary>
			/// Gets the type of the trigger. The trigger type is defined when the trigger is created and cannot be changed later. For information on creating a
			/// trigger, see ITriggerCollection::Create.
			/// </summary>
			/// <value>One of the following TASK_TRIGGER_TYPE2 enumeration values.</value>
			new TASK_TRIGGER_TYPE2 Type { get; }

			/// <summary>Gets or sets the identifier for the trigger.</summary>
			/// <value>The identifier for the trigger. This identifier is used by the Task Scheduler for logging purposes.</value>
			new string Id { [return: MarshalAs(UnmanagedType.BStr)] get; [param: In, MarshalAs(UnmanagedType.BStr)] set; }

			/// <summary>
			/// Gets or sets a value that indicates how often the task is run and how long the repetition pattern is repeated after the task is started.
			/// </summary>
			/// <value>The repetition pattern for how often the task is run and how long the repetition pattern is repeated after the task is started.</value>
			new IRepetitionPattern Repetition
			{
				[return: MarshalAs(UnmanagedType.Interface)]
				get;
				[param: In, MarshalAs(UnmanagedType.Interface)]
				set;
			}

			/// <summary>Gets or sets the maximum amount of time that the task launched by this trigger is allowed to run.</summary>
			/// <value>The maximum amount of time that the task launched by the trigger is allowed to run.</value>
			/// <remarks>
			/// The format for this string is PnYnMnDTnHnMnS, where nY is the number of years, nM is the number of months, nD is the number of days, 'T' is the
			/// date/time separator, nH is the number of hours, nM is the number of minutes, and nS is the number of seconds (for example, PT5M specifies 5
			/// minutes and P1M4DT2H5M specifies one month, four days, two hours, and five minutes).
			/// </remarks>
			new string ExecutionTimeLimit
			{
				[return: MarshalAs(UnmanagedType.BStr)]
				get;
				[param: In, MarshalAs(UnmanagedType.BStr)]
				set;
			}

			/// <summary>Gets or sets the date and time when the trigger is activated.</summary>
			/// <value>The date and time when the trigger is activated.</value>
			/// <remarks>
			/// The date and time must be in the following format: YYYY-MM-DDTHH:MM:SS(+-)HH:MM. The (+-)HH:MM section of the format defines a certain number of
			/// hours and minutes ahead or behind Coordinated Universal Time (UTC). For example the date October 11th, 2005 at 1:21:17 with an offset of eight
			/// hours behind UTC would be written as 2005-10-11T13:21:17-08:00. If Z is specified for the UTC offset (for example, 2005-10-11T13:21:17Z), then
			/// the no offset from UTC will be used. If you do not specify any offset time or Z for the offset (for example, 2005-10-11T13:21:17), then the time
			/// zone and daylight saving information that is set on the local computer will be used. When an offset is specified (using hours and minutes or Z),
			/// then the time and offset are always used regardless of the time zone and daylight saving settings on the local computer.
			/// </remarks>
			new string StartBoundary { [return: MarshalAs(UnmanagedType.BStr)] get; [param: In, MarshalAs(UnmanagedType.BStr)] set; }

			/// <summary>Gets or sets the date and time when the trigger is deactivated.</summary>
			/// <value>The date and time when the trigger is deactivated.</value>
			/// <remarks>
			/// The date and time must be in the following format: YYYY-MM-DDTHH:MM:SS(+-)HH:MM. The (+-)HH:MM section of the format defines a certain number of
			/// hours and minutes ahead or behind Coordinated Universal Time (UTC). For example the date October 11th, 2005 at 1:21:17 with an offset of eight
			/// hours behind UTC would be written as 2005-10-11T13:21:17-08:00. If Z is specified for the UTC offset (for example, 2005-10-11T13:21:17Z), then
			/// the no offset from UTC will be used. If you do not specify any offset time or Z for the offset (for example, 2005-10-11T13:21:17), then the time
			/// zone and daylight saving information that is set on the local computer will be used. When an offset is specified (using hours and minutes or Z),
			/// then the time and offset are always used regardless of the time zone and daylight saving settings on the local computer.
			/// </remarks>
			new string EndBoundary { [return: MarshalAs(UnmanagedType.BStr)] get; [param: In, MarshalAs(UnmanagedType.BStr)] set; }

			/// <summary>Gets or sets a Boolean value that indicates whether the trigger is enabled.</summary>
			/// <value>True if the trigger is enabled; otherwise, false. The default is true.</value>
			new bool Enabled { get; [param: In] set; }

			/// <summary>Gets or sets the days of the month during which the task runs.</summary>
			/// <value>A bitwise mask that indicates the days of the month during which the task runs.</value>
			int DaysOfMonth { get; [param: In] set; }

			/// <summary>Gets or sets the months of the year during which the task runs.</summary>
			/// <value>A bitwise mask that indicates the months of the year during which the task runs.</value>
			short MonthsOfYear { get; [param: In] set; }

			/// <summary>Gets or sets a Boolean value that indicates that the task runs on the last day of the month.</summary>
			/// <value>True indicates that the task runs on the last day of the month, regardless of the actual date of that day; otherwise, False.</value>
			bool RunOnLastDayOfMonth { get; [param: In] set; }

			/// <summary>Gets or sets a delay time that is randomly added to the start time of the trigger.</summary>
			/// <value>
			/// A BSTR value that contains the upper bound of the random delay time that is added to the start time of the trigger. The format for this string is
			/// P&lt;days&gt;DT&lt;hours&gt;H&lt;minutes&gt;M&lt;seconds&gt;S (for example, P2DT5S is a 2 day, 5 second time span).
			/// </value>
			/// <remarks>
			/// The specified random delay time is the upper bound for the random interval. The trigger will fire at random during the period specified by the
			/// randomDelay parameter, which doesn't begin until the specified start time of the trigger. For example, if the task trigger is set to every
			/// seventh day, and the randomDelay parameter is set to P2DT5S (2 day, 5 second time span), then once the seventh day is reached, the trigger will
			/// fire once randomly during the next 2 days, 5 seconds.
			/// </remarks>
			string RandomDelay { [return: MarshalAs(UnmanagedType.BStr)] get; [param: In, MarshalAs(UnmanagedType.BStr)] set; }
		}

		/// <summary>Provides the settings that the Task Scheduler service uses to obtain a network profile.</summary>
		[ComImport, Guid("9F7DEA84-C30B-4245-80B6-00E9F646F1B4"), InterfaceType(ComInterfaceType.InterfaceIsDual),
		 System.Security.SuppressUnmanagedCodeSecurity]
		[PInvokeData("taskschd.h", MSDNShortId = "aa380739")]
		public interface INetworkSettings
		{
			/// <summary>Gets or sets the name of a network profile. The name is used for display purposes.</summary>
			/// <value>The name of a network profile.</value>
			string Name { [return: MarshalAs(UnmanagedType.BStr)] get; [param: In, MarshalAs(UnmanagedType.BStr)] set; }

			/// <summary>Gets or sets a GUID value that identifies a network profile.</summary>
			/// <value>A GUID value that identifies a network profile.</value>
			string Id { [return: MarshalAs(UnmanagedType.BStr)] get; [param: In, MarshalAs(UnmanagedType.BStr)] set; }
		}

		/// <summary>
		/// Provides the security credentials for a principal. These security credentials define the security context for the tasks that are associated with the principal.
		/// </summary>
		[ComImport, Guid("D98D51E5-C9B4-496A-A9C1-18980261CF0F"), InterfaceType(ComInterfaceType.InterfaceIsDual),
		 System.Security.SuppressUnmanagedCodeSecurity]
		[PInvokeData("taskschd.h", MSDNShortId = "aa380742")]
		public interface IPrincipal
		{
			/// <summary>Gets or sets the identifier of the principal.</summary>
			/// <value>The identifier of the principal.</value>
			string Id { [return: MarshalAs(UnmanagedType.BStr)] get; [param: In, MarshalAs(UnmanagedType.BStr)] set; }

			/// <summary>Gets or sets the name of the principal.</summary>
			/// <value>The name of the principal.</value>
			/// <remarks>
			/// When setting this property value, the value can be text that is retrieved from a resource .dll file. A specialized string is used to reference
			/// the text from the resource file. The format of the string is $(@ [Dll], [ResourceID]) where [Dll] is the path to the .dll file that contains the
			/// resource and [ResourceID] is the identifier for the resource text. For example, the setting this property value to $(@
			/// %SystemRoot%\System32\ResourceName.dll, -101) will set the property to the value of the resource text with an identifier equal to -101 in the
			/// %SystemRoot%\System32\ResourceName.dll file.
			/// </remarks>
			string DisplayName { [return: MarshalAs(UnmanagedType.BStr)] get; [param: In, MarshalAs(UnmanagedType.BStr)] set; }

			/// <summary>Gets or sets the user identifier that is required to run the tasks that are associated with the principal.</summary>
			/// <value>The user identifier that is required to run the task.</value>
			string UserId { [return: MarshalAs(UnmanagedType.BStr)] get; [param: In, MarshalAs(UnmanagedType.BStr)] set; }

			/// <summary>Gets or sets the security logon method that is required to run the tasks that are associated with the principal.</summary>
			/// <value>Sets to one of the following TASK_LOGON TYPE enumeration constants.</value>
			TASK_LOGON_TYPE LogonType { get; set; }

			/// <summary>Gets or sets the identifier of the user group that is required to run the tasks that are associated with the principal.</summary>
			/// <value>The identifier of the user group that is associated with this principal.</value>
			string GroupId { [return: MarshalAs(UnmanagedType.BStr)] get; [param: In, MarshalAs(UnmanagedType.BStr)] set; }

			/// <summary>
			/// Gets or sets the identifier that is used to specify the privilege level that is required to run the tasks that are associated with the principal.
			/// </summary>
			/// <value>The identifier that is used to specify the privilege level that is required to run the tasks that are associated with the principal.</value>
			TASK_RUNLEVEL_TYPE RunLevel { get; set; }
		}

		/// <summary>
		/// Provides the extended settings applied to security credentials for a principal. These security credentials define the security context for the tasks
		/// that are associated with the principal.
		/// </summary>
		[ComImport, Guid("248919AE-E345-4A6D-8AEB-E0D3165C904E"), InterfaceType(ComInterfaceType.InterfaceIsDual),
		 System.Security.SuppressUnmanagedCodeSecurity]
		[PInvokeData("taskschd.h", MSDNShortId = "ee695858")]
		public interface IPrincipal2
		{
			/// <summary>Gets or sets the task process security identifier (SID) type.</summary>
			/// <value>Sets to one of the following TASK_PROCESSTOKENSID TYPE enumeration constants.</value>
			TASK_PROCESSTOKENSID_TYPE ProcessTokenSidType { get; [param: In] set; }

			/// <summary>Gets the number of privileges in the required privileges array.</summary>
			/// <value>The number of privileges in the required privileges array.</value>
			int RequiredPrivilegeCount { get; }

			/// <summary>Gets the required privilege of the task by index.</summary>
			/// <value>The value of the privilege at the supplied index.</value>
			/// <param name="index">The index of the privilege to be retrieved.</param>
			string this[int index] { [return: MarshalAs(UnmanagedType.BStr)] get; }

			/// <summary>Adds the required privilege to the task process token.</summary>
			/// <param name="privilege">
			/// Specifies the right of a task to perform various system-related operations, such as shutting down the system, loading device drivers, or changing
			/// the system time.
			/// </param>
			void AddRequiredPrivilege([In, MarshalAs(UnmanagedType.BStr)] string privilege);
		}

		/// <summary>
		/// Provides the methods that are used to run the task immediately, get any running instances of the task, get or set the credentials that are used to
		/// register the task, and the properties that describe the task.
		/// </summary>
		[ComImport, Guid("9C86F320-DEE3-4DD1-B972-A303F26B061E"), InterfaceType(ComInterfaceType.InterfaceIsDual),
		 System.Security.SuppressUnmanagedCodeSecurity, DefaultMember("Path")]
		[PInvokeData("taskschd.h", MSDNShortId = "aa380751")]
		public interface IRegisteredTask
		{
			/// <summary>Gets the name of the registered task.</summary>
			/// <value>The name of the registered task.</value>
			string Name { [return: MarshalAs(UnmanagedType.BStr)] get; }

			/// <summary>Gets the path to where the registered task is stored.</summary>
			/// <value>The path to where the registered task is stored.</value>
			string Path { [return: MarshalAs(UnmanagedType.BStr)] get; }

			/// <summary>Gets the operational state of the registered task.</summary>
			/// <value>A TASK_STATE constant that defines the operational state of the task.</value>
			TASK_STATE State { get; }

			/// <summary>Gets or sets a Boolean value that indicates if the registered task is enabled.</summary>
			/// <value>A Boolean value that indicates if the registered task is enabled.</value>
			bool Enabled { get; set; }

			/// <summary>Runs the registered task immediately.</summary>
			/// <param name="parameters">
			/// The parameters used as values in the task actions. To not specify any parameter values for the task actions, set this parameter to VT_NULL or
			/// VT_EMPTY. Otherwise, a single BSTR value or an array of BSTR values can be specified.
			/// <para>
			/// The BSTR values that you specify are paired with names and stored as name-value pairs. If you specify a single BSTR value, then Arg0 will be the
			/// name assigned to the value. The value can be used in the task action where the $(Arg0) variable is used in the action properties.
			/// </para>
			/// <para>
			/// If you pass in values such as "0", "100", and "250" as an array of BSTR values, then "0" will replace the $(Arg0) variables, "100" will replace
			/// the $(Arg1) variables, and "250" will replace the $(Arg2) variables that are used in the action properties.
			/// </para>
			/// <para>A maximum of 32 BSTR values can be specified.</para>
			/// <para>
			/// For more information and a list of action properties that can use $(Arg0), $(Arg1), ..., $(Arg32) variables in their values, see Task Actions.
			/// </para>
			/// </param>
			/// <returns>An IRunningTask interface that defines the new instance of the task.</returns>
			[return: MarshalAs(UnmanagedType.Interface)]
			IRunningTask Run([In, MarshalAs(UnmanagedType.Struct)] object parameters);

			/// <summary>Runs the registered task immediately using specified flags and a session identifier.</summary>
			/// <param name="parameters">
			/// The parameters used as values in the task actions. To not specify any parameter values for the task actions, set this parameter to VT_NULL or
			/// VT_EMPTY. Otherwise, a single BSTR value or an array of BSTR values can be specified.
			/// <para>
			/// The BSTR values that you specify are paired with names and stored as name-value pairs. If you specify a single BSTR value, then Arg0 will be the
			/// name assigned to the value. The value can be used in the task action where the $(Arg0) variable is used in the action properties.
			/// </para>
			/// <para>
			/// If you pass in values such as "0", "100", and "250" as an array of BSTR values, then "0" will replace the $(Arg0) variables, "100" will replace
			/// the $(Arg1) variables, and "250" will replace the $(Arg2) variables that are used in the action properties.
			/// </para>
			/// <para>A maximum of 32 BSTR values can be specified.</para>
			/// <para>
			/// For more information and a list of action properties that can use $(Arg0), $(Arg1), ..., $(Arg32) variables in their values, see Task Actions.
			/// </para>
			/// </param>
			/// <param name="flags">A TASK_RUN_FLAGS constant that defines how the task is run.</param>
			/// <param name="sessionID">
			/// The terminal server session in which you want to start the task.
			/// <para>
			/// If the TASK_RUN_USE_SESSION_ID constant is not passed into the flags parameter, then the value specified in this parameter is ignored. If the
			/// TASK_RUN_USE_SESSION_ID constant is passed into the flags parameter and the sessionID value is less than or equal to 0, then an invalid argument
			/// error will be returned.
			/// </para>
			/// <para>
			/// If the TASK_RUN_USE_SESSION_ID constant is passed into the flags parameter and the sessionID value is a valid session ID greater than 0 and if no
			/// value is specified for the user parameter, then the Task Scheduler service will try to start the task interactively as the user who is logged on
			/// to the specified session.
			/// </para>
			/// <para>
			/// If the TASK_RUN_USE_SESSION_ID constant is passed into the flags parameter and the sessionID value is a valid session ID greater than 0 and if a
			/// user is specified in the user parameter, then the Task Scheduler service will try to start the task interactively as the user who is specified in
			/// the user parameter.
			/// </para>
			/// </param>
			/// <param name="user">The user for which the task runs.</param>
			/// <returns>An IRunningTask interface that defines the new instance of the task.</returns>
			[return: MarshalAs(UnmanagedType.Interface)]
			IRunningTask RunEx([In, MarshalAs(UnmanagedType.Struct)] object parameters, [In] TASK_RUN_FLAGS flags, [In] int sessionID,
				[In, MarshalAs(UnmanagedType.BStr)] string user);

			/// <summary>
			/// Returns all instances of the currently running registered task. <note>IRegisteredTask::GetInstances will only return instances of the currently
			/// running registered task that are running at or below a user's security context. For example, for members of the Administrators group,
			/// GetInstances will return all instances of the currently running registered task, but for members of the Users group, GetInstances will only
			/// return instances of the currently running registered task that are running under the Users group security context.</note>
			/// </summary>
			/// <param name="flags">This parameter is reserved for future use and must be set to 0.</param>
			/// <returns>An IRunningTaskCollection interface that contains all currently running instances of the task under the user's context.</returns>
			[return: MarshalAs(UnmanagedType.Interface)]
			IRunningTaskCollection GetInstances(int flags);

			/// <summary>Gets the time the registered task was last run.</summary>
			/// <value>The time the registered task was last run.</value>
			DateTime LastRunTime { get; }

			/// <summary>Gets the results that were returned the last time the registered task was run.</summary>
			/// <value>The results that were returned the last time the registered task was run.</value>
			HRESULT LastTaskResult { get; }

			/// <summary>Gets the number of times the registered task has missed a scheduled run.</summary>
			/// <value>The number of times the registered task missed a scheduled run.</value>
			uint NumberOfMissedRuns { get; }

			/// <summary>Gets the time when the registered task is next scheduled to run.</summary>
			/// <value>The time when the registered task is next scheduled to run.</value>
			DateTime NextRunTime { get; }

			/// <summary>Gets the definition of the task.</summary>
			/// <value>The definition of the task.</value>
			ITaskDefinition Definition { [return: MarshalAs(UnmanagedType.Interface)] get; }

			/// <summary>Gets the XML-formatted registration information for the registered task.</summary>
			/// <value>The XML-formatted registration information for the registered task.</value>
			string Xml { [return: MarshalAs(UnmanagedType.BStr)] get; }

			/// <summary>Gets the security descriptor that is used as credentials for the registered task.</summary>
			/// <param name="securityInformation">The security information from SECURITY_INFORMATION.</param>
			/// <returns>The security descriptor that is used as credentials for the registered task.</returns>
			[return: MarshalAs(UnmanagedType.BStr)]
			string GetSecurityDescriptor(SECURITY_INFORMATION securityInformation);

			/// <summary>Sets the security descriptor that is used as credentials for the registered task.</summary>
			/// <param name="sddl">
			/// The security descriptor that is used as credentials for the registered task. <note>If the Local System account is denied access to a task, then
			/// the Task Scheduler service can produce unexpected results.</note>
			/// </param>
			/// <param name="flags">
			/// Flags that specify how to set the security descriptor. The TASK_DONT_ADD_PRINCIPAL_ACE flag from the TASK_CREATION enumeration can be specified.
			/// </param>
			void SetSecurityDescriptor([In, MarshalAs(UnmanagedType.BStr)] string sddl, [In] int flags);

			/// <summary>Stops the registered task immediately.</summary>
			/// <param name="flags">Reserved. Must be zero.</param>
			void Stop(int flags);

			/// <summary>Gets the times that the registered task is scheduled to run during a specified time.</summary>
			/// <param name="pstStart">The starting time for the query.</param>
			/// <param name="pstEnd">The ending time for the query.</param>
			/// <param name="pCount">The requested number of runs on input and the returned number of runs on output.</param>
			/// <returns>
			/// The scheduled times that the task will run. A NULL LPSYSTEMTIME object should be passed into this parameter. On return, this array contains
			/// pCount run times. You must free this array by a calling the CoTaskMemFree function.
			/// </returns>
			[MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime), DispId(0x60020011)]
			SafeCoTaskMemHandle GetRunTimes([In] ref SYSTEMTIME pstStart, [In] ref SYSTEMTIME pstEnd, [In, Out] ref uint pCount);
		}

		/// <summary>Contains all the tasks that are registered.</summary>
		/// <seealso cref="System.Collections.IEnumerable"/>
		[ComImport, Guid("86627EB4-42A7-41E4-A4D9-AC33A72F2D52"), InterfaceType(ComInterfaceType.InterfaceIsDual),
		 System.Security.SuppressUnmanagedCodeSecurity]
		[PInvokeData("taskschd.h", MSDNShortId = "aa380752")]
		public interface IRegisteredTaskCollection : IEnumerable
		{
			/// <summary>Gets the number of registered tasks in the collection.</summary>
			/// <value>The number of registered tasks in the collection.</value>
			int Count { get; }

			/// <summary>Gets the specified registered task from the collection.</summary>
			/// <param name="index">The 1-based index of the item desired or a VARIANT string that contains the name of the task to get.</param>
			/// <returns>An IRegisteredTask interface that contains the requested context.</returns>
			IRegisteredTask this[object index] { [return: MarshalAs(UnmanagedType.Interface)] get; }

			/// <summary>Returns an enumerator that iterates through a collection.</summary>
			/// <returns>An <see cref="T:System.Collections.IEnumerator"/> object that can be used to iterate through the collection.</returns>
			[return: MarshalAs(UnmanagedType.Interface)]
			new IEnumerator GetEnumerator();
		}

		/// <summary>
		/// Provides the administrative information that can be used to describe the task. This information includes details such as a description of the task,
		/// the author of the task, the date the task is registered, and the security descriptor of the task.
		/// </summary>
		[ComImport, Guid("416D8B73-CB41-4EA1-805C-9BE9A5AC4A74"), InterfaceType(ComInterfaceType.InterfaceIsDual),
		 System.Security.SuppressUnmanagedCodeSecurity]
		[PInvokeData("taskschd.h", MSDNShortId = "aa380773")]
		public interface IRegistrationInfo
		{
			/// <summary>Gets or sets the description of the task.</summary>
			/// <value>The description of the task.</value>
			string Description { [return: MarshalAs(UnmanagedType.BStr)] get; [param: In, MarshalAs(UnmanagedType.BStr)] set; }

			/// <summary>Gets or sets the author of the task.</summary>
			/// <value>The author of the task.</value>
			string Author { [return: MarshalAs(UnmanagedType.BStr)] get; [param: In, MarshalAs(UnmanagedType.BStr)] set; }

			/// <summary>Gets or sets the version number of the task.</summary>
			/// <value>The version number of the task.</value>
			string Version { [return: MarshalAs(UnmanagedType.BStr)] get; [param: In, MarshalAs(UnmanagedType.BStr)] set; }

			/// <summary>Gets or sets the date and time when the task is registered.</summary>
			/// <value>The registration date of the task.</value>
			string Date { [return: MarshalAs(UnmanagedType.BStr)] get; [param: In, MarshalAs(UnmanagedType.BStr)] set; }

			/// <summary>Gets or sets any additional documentation for the task.</summary>
			/// <value>Any additional documentation that is associated with the task.</value>
			string Documentation { [return: MarshalAs(UnmanagedType.BStr)] get; [param: In, MarshalAs(UnmanagedType.BStr)] set; }

			/// <summary>Gets or sets an XML-formatted version of the registration information for the task.</summary>
			/// <value>An XML-formatted version of the task registration information.</value>
			string XmlText { [return: MarshalAs(UnmanagedType.BStr)] get; [param: In, MarshalAs(UnmanagedType.BStr)] set; }

			/// <summary>Gets or sets the URI of the task.</summary>
			/// <value>The URI of the task.</value>
			string URI { [return: MarshalAs(UnmanagedType.BStr)] get; [param: In, MarshalAs(UnmanagedType.BStr)] set; }

			/// <summary>
			/// Gets or sets the security descriptor of the task. If a different security descriptor is supplied during task registration, it will supersede the
			/// security descriptor that is set with this property.
			/// </summary>
			/// <value>The security descriptor that is associated with the task.</value>
			/// <remarks>
			/// If a different security descriptor is supplied when a task is registered, then it will supersede the sddl parameter that is set through this property.
			/// <para>If you try to pass an invalid security descriptor into the sddl parameter, then this method will return E_INVALIDARG.</para>
			/// </remarks>
			object SecurityDescriptor
			{
				[return: MarshalAs(UnmanagedType.Struct)]
				get;
				[param: In, MarshalAs(UnmanagedType.Struct)]
				set;
			}

			/// <summary>Gets or sets where the task originated from. For example, a task may originate from a component, service, application, or user.</summary>
			/// <value>Where the task originated from. For example, from a component, service, application, or user.</value>
			/// <remarks>The Task Scheduler UI uses the source to sort tasks. For example, tasks could be sorted by component, service, application, or user.</remarks>
			string Source { [return: MarshalAs(UnmanagedType.BStr)] get; [param: In, MarshalAs(UnmanagedType.BStr)] set; }
		}

		/// <summary>Represents a trigger that starts a task when the task is registered or updated.</summary>
		/// <seealso cref="Vanara.PInvoke.TaskSchd.ITrigger"/>
		[ComImport, Guid("4C8FEC3A-C218-4E0C-B23D-629024DB91A2"), InterfaceType(ComInterfaceType.InterfaceIsDual),
		 System.Security.SuppressUnmanagedCodeSecurity]
		[PInvokeData("taskschd.h", MSDNShortId = "aa381104")]
		public interface IRegistrationTrigger : ITrigger
		{
			/// <summary>
			/// Gets the type of the trigger. The trigger type is defined when the trigger is created and cannot be changed later. For information on creating a
			/// trigger, see ITriggerCollection::Create.
			/// </summary>
			/// <value>One of the following TASK_TRIGGER_TYPE2 enumeration values.</value>
			new TASK_TRIGGER_TYPE2 Type { get; }

			/// <summary>Gets or sets the identifier for the trigger.</summary>
			/// <value>The identifier for the trigger. This identifier is used by the Task Scheduler for logging purposes.</value>
			new string Id { [return: MarshalAs(UnmanagedType.BStr)] get; [param: In, MarshalAs(UnmanagedType.BStr)] set; }

			/// <summary>
			/// Gets or sets a value that indicates how often the task is run and how long the repetition pattern is repeated after the task is started.
			/// </summary>
			/// <value>The repetition pattern for how often the task is run and how long the repetition pattern is repeated after the task is started.</value>
			new IRepetitionPattern Repetition
			{
				[return: MarshalAs(UnmanagedType.Interface)]
				get;
				[param: In, MarshalAs(UnmanagedType.Interface)]
				set;
			}

			/// <summary>Gets or sets the maximum amount of time that the task launched by this trigger is allowed to run.</summary>
			/// <value>The maximum amount of time that the task launched by the trigger is allowed to run.</value>
			/// <remarks>
			/// The format for this string is PnYnMnDTnHnMnS, where nY is the number of years, nM is the number of months, nD is the number of days, 'T' is the
			/// date/time separator, nH is the number of hours, nM is the number of minutes, and nS is the number of seconds (for example, PT5M specifies 5
			/// minutes and P1M4DT2H5M specifies one month, four days, two hours, and five minutes).
			/// </remarks>
			new string ExecutionTimeLimit
			{
				[return: MarshalAs(UnmanagedType.BStr)]
				get;
				[param: In, MarshalAs(UnmanagedType.BStr)]
				set;
			}

			/// <summary>Gets or sets the date and time when the trigger is activated.</summary>
			/// <value>The date and time when the trigger is activated.</value>
			/// <remarks>
			/// The date and time must be in the following format: YYYY-MM-DDTHH:MM:SS(+-)HH:MM. The (+-)HH:MM section of the format defines a certain number of
			/// hours and minutes ahead or behind Coordinated Universal Time (UTC). For example the date October 11th, 2005 at 1:21:17 with an offset of eight
			/// hours behind UTC would be written as 2005-10-11T13:21:17-08:00. If Z is specified for the UTC offset (for example, 2005-10-11T13:21:17Z), then
			/// the no offset from UTC will be used. If you do not specify any offset time or Z for the offset (for example, 2005-10-11T13:21:17), then the time
			/// zone and daylight saving information that is set on the local computer will be used. When an offset is specified (using hours and minutes or Z),
			/// then the time and offset are always used regardless of the time zone and daylight saving settings on the local computer.
			/// </remarks>
			new string StartBoundary { [return: MarshalAs(UnmanagedType.BStr)] get; [param: In, MarshalAs(UnmanagedType.BStr)] set; }

			/// <summary>Gets or sets the date and time when the trigger is deactivated.</summary>
			/// <value>The date and time when the trigger is deactivated.</value>
			/// <remarks>
			/// The date and time must be in the following format: YYYY-MM-DDTHH:MM:SS(+-)HH:MM. The (+-)HH:MM section of the format defines a certain number of
			/// hours and minutes ahead or behind Coordinated Universal Time (UTC). For example the date October 11th, 2005 at 1:21:17 with an offset of eight
			/// hours behind UTC would be written as 2005-10-11T13:21:17-08:00. If Z is specified for the UTC offset (for example, 2005-10-11T13:21:17Z), then
			/// the no offset from UTC will be used. If you do not specify any offset time or Z for the offset (for example, 2005-10-11T13:21:17), then the time
			/// zone and daylight saving information that is set on the local computer will be used. When an offset is specified (using hours and minutes or Z),
			/// then the time and offset are always used regardless of the time zone and daylight saving settings on the local computer.
			/// </remarks>
			new string EndBoundary { [return: MarshalAs(UnmanagedType.BStr)] get; [param: In, MarshalAs(UnmanagedType.BStr)] set; }

			/// <summary>Gets or sets a Boolean value that indicates whether the trigger is enabled.</summary>
			/// <value>True if the trigger is enabled; otherwise, false. The default is true.</value>
			new bool Enabled { get; [param: In] set; }

			/// <summary>
			/// Gets or sets the amount of time between when the task is registered and when the task is started. The format for this string is PnYnMnDTnHnMnS,
			/// where nY is the number of years, nM is the number of months, nD is the number of days, 'T' is the date/time separator, nH is the number of hours,
			/// nM is the number of minutes, and nS is the number of seconds (for example, PT5M specifies 5 minutes and P1M4DT2H5M specifies one month, four
			/// days, two hours, and five minutes).
			/// </summary>
			/// <value>The amount of time between when the system is registered and when the task is started.</value>
			string Delay { [return: MarshalAs(UnmanagedType.BStr)] get; [param: In, MarshalAs(UnmanagedType.BStr)] set; }
		}

		/// <summary>Defines how often the task is run and how long the repetition pattern is repeated after the task is started.</summary>
		[ComImport, Guid("7FB9ACF1-26BE-400E-85B5-294B9C75DFD6"), InterfaceType(ComInterfaceType.InterfaceIsDual),
		 System.Security.SuppressUnmanagedCodeSecurity]
		[PInvokeData("taskschd.h", MSDNShortId = "aa381128")]
		public interface IRepetitionPattern
		{
			/// <summary>Gets or sets the amount of time between each restart of the task.</summary>
			/// <value>
			/// The amount of time between each restart of the task. The format for this string is P&lt;days&gt;DT&lt;hours&gt;H&lt;minutes&gt;M&lt;seconds&gt;S
			/// (for example, "PT5M" is 5 minutes, "PT1H" is 1 hour, and "PT20M" is 20 minutes). The maximum time allowed is 31 days, and the minimum time
			/// allowed is 1 minute.
			/// </value>
			/// <remarks>If you specify a repetition duration for a task, you must also specify the repetition interval.</remarks>
			string Interval { [return: MarshalAs(UnmanagedType.BStr)] get; [param: In, MarshalAs(UnmanagedType.BStr)] set; }

			/// <summary>Gets or sets how long the pattern is repeated.</summary>
			/// <value>
			/// The duration that the pattern is repeated. The format for this string is PnYnMnDTnHnMnS, where nY is the number of years, nM is the number of
			/// months, nD is the number of days, 'T' is the date/time separator, nH is the number of hours, nM is the number of minutes, and nS is the number of
			/// seconds (for example, PT5M specifies 5 minutes and P1M4DT2H5M specifies one month, four days, two hours, and five minutes). The minimum time
			/// allowed is one minute.
			/// <para>If no value is specified, the pattern is repeated indefinitely.</para>
			/// </value>
			/// <remarks>If you specify a repetition duration for a task, you must also specify the repetition interval.</remarks>
			string Duration { [return: MarshalAs(UnmanagedType.BStr)] get; [param: In, MarshalAs(UnmanagedType.BStr)] set; }

			/// <summary>Gets or sets a Boolean value that indicates if a running instance of the task is stopped at the end of the repetition pattern duration.</summary>
			/// <value>A Boolean value that indicates if a running instance of the task is stopped at the end of the repetition pattern duration.</value>
			bool StopAtDurationEnd { get; [param: In] set; }
		}

		/// <summary>Provides the methods to get information from and control a running task.</summary>
		[ComImport, Guid("653758FB-7B9A-4F1E-A471-BEEB8E9B834E"), InterfaceType(ComInterfaceType.InterfaceIsDual),
		 System.Security.SuppressUnmanagedCodeSecurity, DefaultMember("InstanceGuid")]
		[PInvokeData("taskschd.h", MSDNShortId = "aa381157")]
		public interface IRunningTask
		{
			/// <summary>Gets the name of the task.</summary>
			/// <value>The name of the task.</value>
			string Name { [return: MarshalAs(UnmanagedType.BStr)] get; }

			/// <summary>Gets the GUID identifier for this instance of the task.</summary>
			/// <value>The GUID identifier for this instance of the task. An identifier is generated by the Task Scheduler service each time the task is run.</value>
			string InstanceGuid { [return: MarshalAs(UnmanagedType.BStr)] get; }

			/// <summary>Gets the path to where the task is stored.</summary>
			/// <value>The path where the task is stored.</value>
			string Path { [return: MarshalAs(UnmanagedType.BStr)] get; }

			/// <summary>Gets an identifier for the state of the running task.</summary>
			/// <value>An identifier for the state of the running task.</value>
			TASK_STATE State { get; }

			/// <summary>Gets the name of the current action that the running task is performing.</summary>
			/// <value>The name of the current action that the running task is performing.</value>
			string CurrentAction { [return: MarshalAs(UnmanagedType.BStr)] get; }

			/// <summary>Stops this instance of the task.</summary>
			void Stop();

			/// <summary>Refreshes all of the local instance variables of the task.</summary>
			void Refresh();

			/// <summary>Gets the process ID for the engine (process) which is running the task.</summary>
			/// <value>The name of the current action that the running task is performing.</value>
			uint EnginePID { get; }
		}

		/// <summary>Provides a collection that is used to control running tasks.</summary>
		/// <seealso cref="System.Collections.IEnumerable"/>
		[ComImport, Guid("6A67614B-6828-4FEC-AA54-6D52E8F1F2DB"), InterfaceType(ComInterfaceType.InterfaceIsDual),
		 System.Security.SuppressUnmanagedCodeSecurity]
		[PInvokeData("taskschd.h", MSDNShortId = "aa381166")]
		public interface IRunningTaskCollection : IEnumerable
		{
			/// <summary>Gets the number of running tasks in the collection.</summary>
			/// <value>The number of tasks in the collection.</value>
			int Count { get; }

			/// <summary>Gets the specified task from the collection.</summary>
			/// <param name="index">The index. Collections are 1-based. That is, the index for the first item in the collection is 1.</param>
			/// <returns>An IRunningTask interface of the specified task.</returns>
			IRunningTask this[object index] { [return: MarshalAs(UnmanagedType.Interface)] get; }

			/// <summary>Returns an enumerator that iterates through a collection.</summary>
			/// <returns>An <see cref="T:System.Collections.IEnumerator"/> object that can be used to iterate through the collection.</returns>
			[return: MarshalAs(UnmanagedType.Interface)]
			new IEnumerator GetEnumerator();
		}

		/// <summary>Triggers tasks for console connect or disconnect, remote connect or disconnect, or workstation lock or unlock notifications.</summary>
		/// <seealso cref="Vanara.PInvoke.TaskSchd.ITrigger"/>
		[ComImport, InterfaceType(ComInterfaceType.InterfaceIsDual), Guid("754DA71B-4385-4475-9DD9-598294FA3641"),
		 System.Security.SuppressUnmanagedCodeSecurity]
		[PInvokeData("taskschd.h", MSDNShortId = "aa381292")]
		public interface ISessionStateChangeTrigger : ITrigger
		{
			/// <summary>
			/// Gets the type of the trigger. The trigger type is defined when the trigger is created and cannot be changed later. For information on creating a
			/// trigger, see ITriggerCollection::Create.
			/// </summary>
			/// <value>One of the following TASK_TRIGGER_TYPE2 enumeration values.</value>
			new TASK_TRIGGER_TYPE2 Type { get; }

			/// <summary>Gets or sets the identifier for the trigger.</summary>
			/// <value>The identifier for the trigger. This identifier is used by the Task Scheduler for logging purposes.</value>
			new string Id { [return: MarshalAs(UnmanagedType.BStr)] get; [param: In, MarshalAs(UnmanagedType.BStr)] set; }

			/// <summary>
			/// Gets or sets a value that indicates how often the task is run and how long the repetition pattern is repeated after the task is started.
			/// </summary>
			/// <value>The repetition pattern for how often the task is run and how long the repetition pattern is repeated after the task is started.</value>
			new IRepetitionPattern Repetition
			{
				[return: MarshalAs(UnmanagedType.Interface)]
				get;
				[param: In, MarshalAs(UnmanagedType.Interface)]
				set;
			}

			/// <summary>Gets or sets the maximum amount of time that the task launched by this trigger is allowed to run.</summary>
			/// <value>The maximum amount of time that the task launched by the trigger is allowed to run.</value>
			/// <remarks>
			/// The format for this string is PnYnMnDTnHnMnS, where nY is the number of years, nM is the number of months, nD is the number of days, 'T' is the
			/// date/time separator, nH is the number of hours, nM is the number of minutes, and nS is the number of seconds (for example, PT5M specifies 5
			/// minutes and P1M4DT2H5M specifies one month, four days, two hours, and five minutes).
			/// </remarks>
			new string ExecutionTimeLimit
			{
				[return: MarshalAs(UnmanagedType.BStr)]
				get;
				[param: In, MarshalAs(UnmanagedType.BStr)]
				set;
			}

			/// <summary>Gets or sets the date and time when the trigger is activated.</summary>
			/// <value>The date and time when the trigger is activated.</value>
			/// <remarks>
			/// The date and time must be in the following format: YYYY-MM-DDTHH:MM:SS(+-)HH:MM. The (+-)HH:MM section of the format defines a certain number of
			/// hours and minutes ahead or behind Coordinated Universal Time (UTC). For example the date October 11th, 2005 at 1:21:17 with an offset of eight
			/// hours behind UTC would be written as 2005-10-11T13:21:17-08:00. If Z is specified for the UTC offset (for example, 2005-10-11T13:21:17Z), then
			/// the no offset from UTC will be used. If you do not specify any offset time or Z for the offset (for example, 2005-10-11T13:21:17), then the time
			/// zone and daylight saving information that is set on the local computer will be used. When an offset is specified (using hours and minutes or Z),
			/// then the time and offset are always used regardless of the time zone and daylight saving settings on the local computer.
			/// </remarks>
			new string StartBoundary { [return: MarshalAs(UnmanagedType.BStr)] get; [param: In, MarshalAs(UnmanagedType.BStr)] set; }

			/// <summary>Gets or sets the date and time when the trigger is deactivated.</summary>
			/// <value>The date and time when the trigger is deactivated.</value>
			/// <remarks>
			/// The date and time must be in the following format: YYYY-MM-DDTHH:MM:SS(+-)HH:MM. The (+-)HH:MM section of the format defines a certain number of
			/// hours and minutes ahead or behind Coordinated Universal Time (UTC). For example the date October 11th, 2005 at 1:21:17 with an offset of eight
			/// hours behind UTC would be written as 2005-10-11T13:21:17-08:00. If Z is specified for the UTC offset (for example, 2005-10-11T13:21:17Z), then
			/// the no offset from UTC will be used. If you do not specify any offset time or Z for the offset (for example, 2005-10-11T13:21:17), then the time
			/// zone and daylight saving information that is set on the local computer will be used. When an offset is specified (using hours and minutes or Z),
			/// then the time and offset are always used regardless of the time zone and daylight saving settings on the local computer.
			/// </remarks>
			new string EndBoundary { [return: MarshalAs(UnmanagedType.BStr)] get; [param: In, MarshalAs(UnmanagedType.BStr)] set; }

			/// <summary>Gets or sets a Boolean value that indicates whether the trigger is enabled.</summary>
			/// <value>True if the trigger is enabled; otherwise, false. The default is true.</value>
			new bool Enabled { get; [param: In] set; }

			/// <summary>
			/// Gets or sets a value that indicates how long of a delay takes place before a task is started after a Terminal Server session state change is
			/// detected. The format for this string is PnYnMnDTnHnMnS, where nY is the number of years, nM is the number of months, nD is the number of days,
			/// 'T' is the date/time separator, nH is the number of hours, nM is the number of minutes, and nS is the number of seconds (for example, PT5M
			/// specifies 5 minutes and P1M4DT2H5M specifies one month, four days, two hours, and five minutes).
			/// </summary>
			/// <value>The delay that takes place before a task is started after a Terminal Server session state change is detected.</value>
			string Delay { [return: MarshalAs(UnmanagedType.BStr)] get; [param: In, MarshalAs(UnmanagedType.BStr)] set; }

			/// <summary>Gets or sets the user for the Terminal Server session. When a session state change is detected for this user, a task is started.</summary>
			/// <value>The user for the Terminal Server session.</value>
			string UserId { [return: MarshalAs(UnmanagedType.BStr)] get; [param: In, MarshalAs(UnmanagedType.BStr)] set; }

			/// <summary>Gets or sets the kind of Terminal Server session change that would trigger a task launch.</summary>
			/// <value>The kind of Terminal Server session change that triggers a task to launch.</value>
			TASK_SESSION_STATE_CHANGE_TYPE StateChange { get; [param: In] set; }
		}

		/// <summary>
		/// Represents an action that shows a message box when a task is activated. <note>This interface is no longer supported. You can use IExecAction with the
		/// Windows scripting MsgBox function to show a message in the user session.</note>
		/// </summary>
		/// <seealso cref="Vanara.PInvoke.TaskSchd.IAction"/>
		[ComImport, Guid("505E9E68-AF89-46B8-A30F-56162A83D537"), InterfaceType(ComInterfaceType.InterfaceIsDual),
		 System.Security.SuppressUnmanagedCodeSecurity]
		[PInvokeData("taskschd.h", MSDNShortId = "aa381302")]
		public interface IShowMessageAction : IAction
		{
			/// <summary>Gets or sets the identifier of the action.</summary>
			/// <value>The user-defined identifier for the action. This identifier is used by the Task Scheduler for logging purposes.</value>
			new string Id { [return: MarshalAs(UnmanagedType.BStr)] get; [param: In, MarshalAs(UnmanagedType.BStr)] set; }

			/// <summary>Gets the type of action.</summary>
			/// <value>This property returns one of the following TASK_ACTION_TYPE enumeration constants.</value>
			new TASK_ACTION_TYPE Type { get; }

			/// <summary>Gets or sets the title of the message box.</summary>
			/// <value>A BSTR value that contains the title of the message box.</value>
			/// <remarks>
			/// Parameterized strings can be used in the title text of the message box. For more information, see the Examples section in ValueQueries property
			/// of IEventTrigger.
			/// <para>
			/// When setting this property value, the value can be text that is retrieved from a resource .dll file. A specialized string is used to reference
			/// the text from the resource file. The format of the string is $(@ [Dll], [ResourceID]) where [Dll] is the path to the .dll file that contains the
			/// resource and [ResourceID] is the identifier for the resource text. For example, the setting this property value to $(@
			/// %SystemRoot%\System32\ResourceName.dll, -101) will set the property to the value of the resource text with an identifier equal to -101 in the
			/// %SystemRoot%\System32\ResourceName.dll file.
			/// </para>
			/// </remarks>
			string Title { [return: MarshalAs(UnmanagedType.BStr)] get; [param: In, MarshalAs(UnmanagedType.BStr)] set; }

			/// <summary>Gets or sets the message text that is displayed in the body of the message box.</summary>
			/// <value>A BSTR value that contains the message text that is displayed in the body of the message box.</value>
			/// <remarks>
			/// Parameterized strings can be used in the message text of the message box. For more information, see the Examples section in ValueQueries property
			/// of IEventTrigger.
			/// <para>
			/// When setting this property value, the value can be text that is retrieved from a resource .dll file. A specialized string is used to reference
			/// the text from the resource file. The format of the string is $(@ [Dll], [ResourceID]) where [Dll] is the path to the .dll file that contains the
			/// resource and [ResourceID] is the identifier for the resource text. For example, the setting this property value to $(@
			/// %SystemRoot%\System32\ResourceName.dll, -101) will set the property to the value of the resource text with an identifier equal to -101 in the
			/// %SystemRoot%\System32\ResourceName.dll file.
			/// </para>
			/// </remarks>
			string MessageBody { [return: MarshalAs(UnmanagedType.BStr)] get; [param: In, MarshalAs(UnmanagedType.BStr)] set; }
		}

		/// <summary>Defines all the components of a task, such as the task settings, triggers, actions, and registration information.</summary>
		[ComImport, Guid("F5BC8FC5-536D-4F77-B852-FBC1356FDEB6"), InterfaceType(ComInterfaceType.InterfaceIsDual),
		 System.Security.SuppressUnmanagedCodeSecurity]
		[PInvokeData("taskschd.h", MSDNShortId = "aa381313")]
		public interface ITaskDefinition
		{
			/// <summary>
			/// Gets or sets the registration information that is used to describe a task, such as the description of the task, the author of the task, and the
			/// date the task is registered.
			/// </summary>
			/// <value>
			/// The registration information that is used to describe a task, such as the description of the task, the author of the task, and the date the task
			/// is registered.
			/// </value>
			IRegistrationInfo RegistrationInfo
			{
				[return: MarshalAs(UnmanagedType.Interface)]
				get;
				[param: In, MarshalAs(UnmanagedType.Interface)]
				set;
			}

			/// <summary>Gets or sets a collection of triggers that are used to start a task.</summary>
			/// <value>The collection of triggers that are used to start a task.</value>
			ITriggerCollection Triggers
			{
				[return: MarshalAs(UnmanagedType.Interface)]
				get;
				[param: In, MarshalAs(UnmanagedType.Interface)]
				set;
			}

			/// <summary>Gets or sets the settings that define how the Task Scheduler service performs the task.</summary>
			/// <value>The settings that define how the Task Scheduler service performs the task.</value>
			ITaskSettings Settings
			{
				[return: MarshalAs(UnmanagedType.Interface)]
				get;
				[param: In, MarshalAs(UnmanagedType.Interface)]
				set;
			}

			/// <summary>
			/// Gets or sets the data that is associated with the task. This data is ignored by the Task Scheduler service, but is used by third-parties who wish
			/// to extend the task format.
			/// </summary>
			/// <value>The data that is associated with the task.</value>
			string Data { [return: MarshalAs(UnmanagedType.BStr)] get; [param: In, MarshalAs(UnmanagedType.BStr)] set; }

			/// <summary>Gets or sets the principal for the task that provides the security credentials for the task.</summary>
			/// <value>The principal for the task that provides the security credentials for the task.</value>
			IPrincipal Principal
			{
				[return: MarshalAs(UnmanagedType.Interface)]
				get;
				[param: In, MarshalAs(UnmanagedType.Interface)]
				set;
			}

			/// <summary>Gets or sets a collection of actions performed by the task.</summary>
			/// <value>A collection of actions performed by the task.</value>
			IActionCollection Actions
			{
				[return: MarshalAs(UnmanagedType.Interface)]
				get;
				[param: In, MarshalAs(UnmanagedType.Interface)]
				set;
			}

			/// <summary>Gets or sets the XML text.</summary>
			/// <value>The XML text.</value>
			string XmlText { [return: MarshalAs(UnmanagedType.BStr)] get; [param: In, MarshalAs(UnmanagedType.BStr)] set; }
		}

		/// <summary>
		/// Provides the methods that are used to register (create) tasks in the folder, remove tasks from the folder, and create or remove subfolders from the folder.
		/// </summary>
		[ComImport, Guid("8CFAC062-A080-4C15-9A88-AA7C2AF80DFC"), InterfaceType(ComInterfaceType.InterfaceIsDual),
		 System.Security.SuppressUnmanagedCodeSecurity, DefaultMember("Path")]
		[PInvokeData("taskschd.h", MSDNShortId = "aa381330")]
		public interface ITaskFolder
		{
			/// <summary>Gets the name that is used to identify the folder that contains a task.</summary>
			/// <value>The name that is used to identify the folder.</value>
			string Name { [return: MarshalAs(UnmanagedType.BStr)] get; }

			/// <summary>Gets the path to where the folder is stored.</summary>
			/// <value>
			/// The path to where the folder is stored. The root task folder is specified with a backslash (\). An example of a task folder path, under the root
			/// task folder, is \MyTaskFolder.
			/// </value>
			string Path { [return: MarshalAs(UnmanagedType.BStr)] get; }

			/// <summary>Gets a folder that contains tasks at a specified location.</summary>
			/// <param name="Path">
			/// The path (location) to the folder. Do not use a backslash following the last folder name in the path. The root task folder is specified with a
			/// backslash (\). An example of a task folder path, under the root task folder, is \MyTaskFolder. The '.' character cannot be used to specify the
			/// current task folder and the '..' characters cannot be used to specify the parent task folder in the path.
			/// </param>
			/// <returns>The folder at the specified location.</returns>
			[return: MarshalAs(UnmanagedType.Interface)]
			ITaskFolder GetFolder([MarshalAs(UnmanagedType.BStr)] string Path);

			/// <summary>Gets all the subfolders in the folder.</summary>
			/// <param name="flags">This parameter is reserved for future use and must be set to 0.</param>
			/// <returns>The collection of subfolders in the folder.</returns>
			[return: MarshalAs(UnmanagedType.Interface)]
			ITaskFolderCollection GetFolders(int flags);

			/// <summary>Creates a folder for related tasks.</summary>
			/// <param name="subFolderName">
			/// The name used to identify the folder. If "FolderName\SubFolder1\SubFolder2" is specified, the entire folder tree will be created if the folders
			/// do not exist. This parameter can be a relative path to the current ITaskFolder instance. The root task folder is specified with a backslash (\).
			/// An example of a task folder path, under the root task folder, is \MyTaskFolder. The '.' character cannot be used to specify the current task
			/// folder and the '..' characters cannot be used to specify the parent task folder in the path.
			/// </param>
			/// <param name="sddl">The security descriptor associated with the folder, in the form of a VT_BSTR in SDDL_REVISION_1 format.</param>
			/// <returns>An ITaskFolder interface that represents the new subfolder.</returns>
			[return: MarshalAs(UnmanagedType.Interface)]
			ITaskFolder CreateFolder([In, MarshalAs(UnmanagedType.BStr)] string subFolderName,
				[In, Optional, MarshalAs(UnmanagedType.Struct)] object sddl);

			/// <summary>Deletes a subfolder from the parent folder.</summary>
			/// <param name="subFolderName">
			/// The name of the subfolder to be removed. The root task folder is specified with a backslash (\). This parameter can be a relative path to the
			/// folder you want to delete. An example of a task folder path, under the root task folder, is \MyTaskFolder. The '.' character cannot be used to
			/// specify the current task folder and the '..' characters cannot be used to specify the parent task folder in the path.
			/// </param>
			/// <param name="flags">Not supported.</param>
			void DeleteFolder([MarshalAs(UnmanagedType.BStr)] string subFolderName, [In] int flags);

			/// <summary>Gets a task at a specified location in a folder.</summary>
			/// <param name="Path">
			/// The path (location) to the task in a folder. The root task folder is specified with a backslash (\). An example of a task folder path, under the
			/// root task folder, is \MyTaskFolder. The '.' character cannot be used to specify the current task folder and the '..' characters cannot be used to
			/// specify the parent task folder in the path.
			/// </param>
			/// <returns>The task at the specified location.</returns>
			[return: MarshalAs(UnmanagedType.Interface)]
			IRegisteredTask GetTask([MarshalAs(UnmanagedType.BStr)] string Path);

			/// <summary>Gets all the tasks in the folder.</summary>
			/// <param name="flags">
			/// Specifies whether to retrieve hidden tasks. Pass in TASK_ENUM_HIDDEN to retrieve all tasks in the folder including hidden tasks, and pass in 0 to
			/// retrieve all the tasks in the folder excluding the hidden tasks.
			/// </param>
			/// <returns>An IRegisteredTaskCollection collection of all the tasks in the folder.</returns>
			[return: MarshalAs(UnmanagedType.Interface)]
			IRegisteredTaskCollection GetTasks(TASK_ENUM_FLAGS flags);

			/// <summary>Deletes a task from the folder.</summary>
			/// <param name="Name">
			/// The name of the task that is specified when the task was registered. The '.' character cannot be used to specify the current task folder and the
			/// '..' characters cannot be used to specify the parent task folder in the path.
			/// </param>
			/// <param name="flags">Not supported.</param>
			void DeleteTask([In, MarshalAs(UnmanagedType.BStr)] string Name, [In] int flags);

			/// <summary>Registers (creates) a new task in the folder using XML to define the task.</summary>
			/// <param name="path">
			/// The task name. If this value is NULL, the task will be registered in the root task folder and the task name will be a GUID value that is created
			/// by the Task Scheduler service.
			/// <para>
			/// A task name cannot begin or end with a space character. The '.' character cannot be used to specify the current task folder and the '..'
			/// characters cannot be used to specify the parent task folder in the path.
			/// </para>
			/// </param>
			/// <param name="xmlText">An XML-formatted definition of the task.</param>
			/// <param name="flags">A TASK_CREATION constant.</param>
			/// <param name="userId">
			/// The user credentials used to register the task. <note>If the task is defined as a Task Scheduler 1.0 task, then do not use a group name (rather
			/// than a specific user name) in this userId parameter. A task is defined as a Task Scheduler 1.0 task when the version attribute of the Task
			/// element in the task's XML is set to 1.1.</note>
			/// </param>
			/// <param name="password">
			/// The password for the userId used to register the task. When the TASK_LOGON_SERVICE_ACCOUNT logon type is used, the password must be an empty
			/// VARIANT value such as VT_NULL or VT_EMPTY.
			/// </param>
			/// <param name="logonType">A value that defines what logon technique is used to run the registered task.</param>
			/// <param name="sddl">
			/// The security descriptor associated with the registered task. You can specify the access control list (ACL) in the security descriptor for a task
			/// in order to allow or deny certain users and groups access to a task. <note>If the Local System account is denied access to a task, then the Task
			/// Scheduler service can produce unexpected results.</note>
			/// </param>
			/// <returns>An IRegisteredTask interface that represents the new task.</returns>
			[return: MarshalAs(UnmanagedType.Interface)]
			IRegisteredTask RegisterTask([In, MarshalAs(UnmanagedType.BStr)] string path,
				[In, MarshalAs(UnmanagedType.BStr)] string xmlText, [In] TASK_CREATION flags,
				[In, MarshalAs(UnmanagedType.Struct)] object userId, [In, MarshalAs(UnmanagedType.Struct)] object password,
				[In] TASK_LOGON_TYPE logonType, [In, Optional, MarshalAs(UnmanagedType.Struct)] object sddl);

			/// <summary>Registers the task definition.</summary>
			/// <param name="path">
			/// The task name. If this value is NULL, the task will be registered in the root task folder and the task name will be a GUID value that is created
			/// by the Task Scheduler service.
			/// <para>
			/// A task name cannot begin or end with a space character. The '.' character cannot be used to specify the current task folder and the '..'
			/// characters cannot be used to specify the parent task folder in the path.
			/// </para>
			/// </param>
			/// <param name="pDefinition">The definition of the registered task.</param>
			/// <param name="flags">A TASK_CREATION constant.</param>
			/// <param name="userId">
			/// The user credentials used to register the task. <note>If the task is defined as a Task Scheduler 1.0 task, then do not use a group name (rather
			/// than a specific user name) in this userId parameter. A task is defined as a Task Scheduler 1.0 task when the version attribute of the Task
			/// element in the task's XML is set to 1.1.</note>
			/// </param>
			/// <param name="password">
			/// The password for the userId used to register the task. When the TASK_LOGON_SERVICE_ACCOUNT logon type is used, the password must be an empty
			/// VARIANT value such as VT_NULL or VT_EMPTY.
			/// </param>
			/// <param name="logonType">A value that defines what logon technique is used to run the registered task.</param>
			/// <param name="sddl">
			/// The security descriptor associated with the registered task. You can specify the access control list (ACL) in the security descriptor for a task
			/// in order to allow or deny certain users and groups access to a task. <note>If the Local System account is denied access to a task, then the Task
			/// Scheduler service can produce unexpected results.</note>
			/// </param>
			/// <returns>An IRegisteredTask interface that represents the new task.</returns>
			[return: MarshalAs(UnmanagedType.Interface)]
			IRegisteredTask RegisterTaskDefinition([In, MarshalAs(UnmanagedType.BStr)] string path,
				[In, MarshalAs(UnmanagedType.Interface)] ITaskDefinition pDefinition, [In] TASK_CREATION flags,
				[In, MarshalAs(UnmanagedType.Struct)] object userId, [In, MarshalAs(UnmanagedType.Struct)] object password,
				[In] TASK_LOGON_TYPE logonType, [In, Optional, MarshalAs(UnmanagedType.Struct)] object sddl);

			/// <summary>Gets the security descriptor for the folder.</summary>
			/// <param name="securityInformation">The security information from SECURITY_INFORMATION.</param>
			/// <returns>The security descriptor for the folder.</returns>
			[return: MarshalAs(UnmanagedType.BStr)]
			string GetSecurityDescriptor(SECURITY_INFORMATION securityInformation);

			/// <summary>Sets the security descriptor for the folder.</summary>
			/// <param name="sddl">
			/// The security descriptor associated with the folder. <note>If the Local System account is denied access to a task folder, then the Task Scheduler
			/// service can produce unexpected results.</note>
			/// </param>
			/// <param name="flags">A value that specifies how the security descriptor is set.</param>
			void SetSecurityDescriptor([In, MarshalAs(UnmanagedType.BStr)] string sddl, [In] int flags);
		}

		/// <summary>Provides information and control for a collection of folders that contain tasks.</summary>
		/// <seealso cref="System.Collections.IEnumerable"/>
		[ComImport, Guid("79184A66-8664-423F-97F1-637356A5D812"), InterfaceType(ComInterfaceType.InterfaceIsDual),
		 System.Security.SuppressUnmanagedCodeSecurity]
		[PInvokeData("taskschd.h", MSDNShortId = "aa381332")]
		public interface ITaskFolderCollection : IEnumerable
		{
			/// <summary>Gets the number of folders in the collection.</summary>
			/// <value>The number of folders in the collection.</value>
			int Count { get; }

			/// <summary>Gets the <see cref="ITaskFolder"/> at the specified index from the collection.</summary>
			/// <param name="index">
			/// The index. Collections are 1-based. That is, the index for the first item in the collection is 1. You can also pass in a string with the name of
			/// folder to get.
			/// </param>
			/// <returns>An ITaskFolder interface that represents the requested folder.</returns>
			ITaskFolder this[object index] { [return: MarshalAs(UnmanagedType.Interface)] get; }

			/// <summary>Returns an enumerator that iterates through a collection.</summary>
			/// <returns>An <see cref="T:System.Collections.IEnumerator"/> object that can be used to iterate through the collection.</returns>
			[return: MarshalAs(UnmanagedType.Interface)]
			new IEnumerator GetEnumerator();
		}

		/// <summary>
		/// Defines the methods that are called by the Task Scheduler service to manage a COM handler.
		/// </summary>
		/// <remarks>
		/// This interface must be implemented for a task to perform a COM handler action. When the Task Scheduler performs a COM handler action, it creates and activates the handler and calls the methods of this interface as needed. For information on specifying a COM handler action, see the <see cref="IComHandlerAction"/> class.
		/// </remarks>
		[ComImport, Guid("839D7762-5121-4009-9234-4F0D19394F04"), InterfaceType(ComInterfaceType.InterfaceIsIUnknown), System.Security.SuppressUnmanagedCodeSecurity]
		[PInvokeData("taskschd.h", MSDNShortId = "aa381370")]
		public interface ITaskHandler
		{
			/// <summary>
			/// Called to start the COM handler. This method must be implemented by the handler.
			/// </summary>
			/// <param name="pHandlerServices">An <c>IUnkown</c> interface that is used to communicate back with the Task Scheduler.</param>
			/// <param name="Data">The arguments that are required by the handler. These arguments are defined in the <see cref="IComHandlerAction.Data"/> property of the COM handler action.</param>
			/// <remarks>When implementing this method, the handler should return control immediately to the Task Scheduler (starting its own thread if inproc).
			/// <para>After the handler starts its processing, it can call the UpdateStatus method to indicate its percentage of completion or call the TaskCompleted method to indicate when the handler has completed its processing. These methods are provided by the ITaskHandlerStatus interface.</para></remarks>
			void Start([In, MarshalAs(UnmanagedType.IUnknown)] object pHandlerServices, [In, MarshalAs(UnmanagedType.BStr)] string Data);

			/// <summary>
			/// Called to stop the COM handler. This method must be implemented by the handler.
			/// </summary>
			/// <param name="pRetCode">The return code that the Task Schedule will raise as an event when the COM handler action is completed.</param>
			void Stop([MarshalAs(UnmanagedType.Error)] out int pRetCode);

			/// <summary>
			/// Called to pause the COM handler. This method is optional and should only be implemented to give the Task Scheduler the ability to pause and restart the handler.
			/// </summary>
			void Pause();

			/// <summary>
			/// Called to resume the COM handler. This method is optional and should only be implemented to give the Task Scheduler the ability to resume the handler.
			/// </summary>
			void Resume();
		}

		/// <summary>
		/// Provides the methods that are used by COM handlers to notify the Task Scheduler about the status of the handler.
		/// </summary>
		[ComImport, Guid("EAEC7A8F-27A0-4DDC-8675-14726A01A38A"), InterfaceType(ComInterfaceType.InterfaceIsIUnknown), System.Security.SuppressUnmanagedCodeSecurity]
		[PInvokeData("taskschd.h", MSDNShortId = "aa381373")]
		public interface ITaskHandlerStatus
		{
			/// <summary>
			/// Tells the Task Scheduler about the percentage of completion of the COM handler.
			/// </summary>
			/// <param name="percentComplete">A value that indicates the percentage of completion for the COM handler.</param>
			/// <param name="statusMessage">The message that is displayed in the Task Scheduler UI.</param>
			void UpdateStatus([In] short percentComplete, [In, MarshalAs(UnmanagedType.BStr)] string statusMessage);

			/// <summary>
			/// Tells the Task Scheduler that the COM handler is completed.
			/// </summary>
			/// <param name="taskErrCode">The error code that the Task Scheduler will raise as an event.</param>
			void TaskCompleted([In, MarshalAs(UnmanagedType.Error)] int taskErrCode);
		}
		
		/// <summary>Contains a collection of ITaskNamedValuePair interface name-value pairs.</summary>
		/// <seealso cref="System.Collections.IEnumerable"/>
		[ComImport, Guid("B4EF826B-63C3-46E4-A504-EF69E4F7EA4D"), InterfaceType(ComInterfaceType.InterfaceIsDual),
		 System.Security.SuppressUnmanagedCodeSecurity]
		[PInvokeData("taskschd.h", MSDNShortId = "aa381392")]
		public interface ITaskNamedValueCollection : IEnumerable
		{
			/// <summary>Gets the number of name-value pairs in the collection.</summary>
			/// <value>The number of name-value pairs in the collection.</value>
			int Count { get; }

			/// <summary>Gets the <see cref="ITaskNamedValuePair"/> at the specified index from the collection.</summary>
			/// <param name="index">The index.</param>
			/// <returns>An ITaskNamedValuePair interface that represents the requested pair.</returns>
			ITaskNamedValuePair this[int index] { [return: MarshalAs(UnmanagedType.Interface)] get; }

			/// <summary>Returns an enumerator that iterates through a collection.</summary>
			/// <returns>An <see cref="T:System.Collections.IEnumerator"/> object that can be used to iterate through the collection.</returns>
			[return: MarshalAs(UnmanagedType.Interface)]
			new IEnumerator GetEnumerator();

			/// <summary>Creates a name-value pair in the collection.</summary>
			/// <param name="name">The name associated with a value in a name-value pair.</param>
			/// <param name="value">The value associated with a name in a name-value pair.</param>
			/// <returns>The name-value pair created in the collection.</returns>
			[return: MarshalAs(UnmanagedType.Interface)]
			ITaskNamedValuePair Create([In, MarshalAs(UnmanagedType.BStr)] string name,
				[In, MarshalAs(UnmanagedType.BStr)] string value);

			/// <summary>Removes a selected name-value pair from the collection.</summary>
			/// <param name="index">The index of the name-value pair to be removed.</param>
			void Remove([In] int index);

			/// <summary>Clears the entire collection of name-value pairs.</summary>
			void Clear();
		}

		/// <summary>Creates a name-value pair in which the name is associated with the value.</summary>
		[ComImport, Guid("39038068-2B46-4AFD-8662-7BB6F868D221"), InterfaceType(ComInterfaceType.InterfaceIsDual),
		 System.Security.SuppressUnmanagedCodeSecurity, DefaultMember("Name")]
		[PInvokeData("taskschd.h", MSDNShortId = "aa381804")]
		public interface ITaskNamedValuePair
		{
			/// <summary>Gets or sets the name that is associated with a value in a name-value pair.</summary>
			/// <value>The name that is associated with a value in a name-value pair.</value>
			string Name { [return: MarshalAs(UnmanagedType.BStr)] get; [param: In, MarshalAs(UnmanagedType.BStr)] set; }

			/// <summary>Gets or sets the value that is associated with a name in a name-value pair.</summary>
			/// <value>The value that is associated with a name in a name-value pair.</value>
			string Value { [return: MarshalAs(UnmanagedType.BStr)] get; [param: In, MarshalAs(UnmanagedType.BStr)] set; }
		}

		/// <summary>Provides access to the Task Scheduler service for managing registered tasks.</summary>
		[ComImport, DefaultMember("TargetServer"), Guid("2FABA4C7-4DA9-4013-9697-20CC3FD40F85"),
		 System.Security.SuppressUnmanagedCodeSecurity, CoClass(typeof(TaskSchedulerClass))]
		[PInvokeData("taskschd.h", MSDNShortId = "aa381832")]
		public interface ITaskService
		{
			/// <summary>Gets a folder of registered tasks.</summary>
			/// <param name="path">
			/// The path to the folder to retrieve. Do not use a backslash following the last folder name in the path. The root task folder is specified with a
			/// backslash (\). An example of a task folder path, under the root task folder, is \MyTaskFolder. The '.' character cannot be used to specify the
			/// current task folder and the '..' characters cannot be used to specify the parent task folder in the path.
			/// </param>
			/// <returns>An ITaskFolder interface for the requested folder.</returns>
			[return: MarshalAs(UnmanagedType.Interface)]
			[MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime), DispId(1)]
			ITaskFolder GetFolder([In, MarshalAs(UnmanagedType.BStr)] string path);

			/// <summary>
			/// Gets a collection of running tasks. <note>ITaskService::GetRunningTasks will only return a collection of running tasks that are running at or
			/// below a user's security context. For example, for members of the Administrators group, GetRunningTasks will return a collection of all running
			/// tasks, but for members of the Users group, GetRunningTasks will only return a collection of tasks running under the Users group security context.</note>
			/// </summary>
			/// <param name="flags">A value from the TASK_ENUM_FLAGS enumeration. Pass in 0 to return a collection of running tasks that are not hidden tasks.</param>
			/// <returns>An IRunningTaskCollection interface that contains the currently running tasks.</returns>
			[return: MarshalAs(UnmanagedType.Interface)]
			[MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime), DispId(2)]
			IRunningTaskCollection GetRunningTasks(TASK_ENUM_FLAGS flags);

			/// <summary>
			/// Returns an empty task definition object to be filled in with settings and properties and then registered using the
			/// ITaskFolder::RegisterTaskDefinition method.
			/// </summary>
			/// <param name="flags">This parameter is reserved for future use and must be set to 0.</param>
			/// <returns>The task definition that specifies all the information required to create a new task.</returns>
			[return: MarshalAs(UnmanagedType.Interface)]
			[MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime), DispId(3)]
			ITaskDefinition NewTask([In] uint flags);

			/// <summary>
			/// Connects to a remote computer and associates all subsequent calls on this interface with a remote session. If the serverName parameter is empty,
			/// then this method will execute on the local computer. If the user is not specified, then the current token is used.
			/// </summary>
			/// <param name="serverName">
			/// The name of the computer that you want to connect to. If the serverName parameter is empty, then this method will execute on the local computer.
			/// </param>
			/// <param name="user">
			/// The user name that is used during the connection to the computer. If the user is not specified, then the current token is used.
			/// </param>
			/// <param name="domain">The domain of the user specified in the user parameter.</param>
			/// <param name="password">
			/// The password that is used to connect to the computer. If the user name and password are not specified, then the current token is used.
			/// </param>
			[MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime), DispId(4)]
			void Connect([In, Optional, MarshalAs(UnmanagedType.Struct)] object serverName,
				[In, Optional, MarshalAs(UnmanagedType.Struct)] object user,
				[In, Optional, MarshalAs(UnmanagedType.Struct)] object domain,
				[In, Optional, MarshalAs(UnmanagedType.Struct)] object password);

			/// <summary>Gets a Boolean value that indicates if you are connected to the Task Scheduler service.</summary>
			/// <value>A Boolean value that indicates if you are connected to the Task Scheduler service.</value>
			[DispId(5)]
			bool Connected
			{
				[MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime), DispId(5)]
				get;
			}

			/// <summary>Gets the name of the computer that is running the Task Scheduler service that the user is connected to.</summary>
			/// <value>
			/// The name of the computer that is running the Task Scheduler service that the user is connected to. This property returns an empty string when the
			/// user passes an IP address, Localhost, or '.' into the pServer parameter, and it returns the name of the computer that is running the Task
			/// Scheduler service when the user does not pass any parameter value.
			/// </value>
			[DispId(0)]
			string TargetServer
			{
				[return: MarshalAs(UnmanagedType.BStr)]
				[MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime), DispId(0)]
				get;
			}

			/// <summary>Gets the name of the user that is connected to the Task Scheduler service.</summary>
			/// <value>The name of the user that is connected to the Task Scheduler service.</value>
			[DispId(6)]
			string ConnectedUser
			{
				[return: MarshalAs(UnmanagedType.BStr)]
				[MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime), DispId(6)]
				get;
			}

			/// <summary>Gets the name of the domain to which the TargetServer computer is connected.</summary>
			/// <value>The name of the domain to which the TargetServer computer is connected.</value>
			[DispId(7)]
			string ConnectedDomain
			{
				[return: MarshalAs(UnmanagedType.BStr)]
				[MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime), DispId(7)]
				get;
			}

			/// <summary>Indicates the highest version of Task Scheduler that a computer supports.</summary>
			/// <value>
			/// The highest version of Task Scheduler that a computer supports. The highest version is a DWORD value that is split into MajorVersion/MinorVersion
			/// on the 16-bit boundary. The Task Scheduler service returns 1 for the major version and 2 for the minor version.
			/// </value>
			[DispId(8)]
			uint HighestVersion
			{
				[MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime), DispId(8)]
				get;
			}
		}

		/// <summary>Provides the settings that the Task Scheduler service uses to perform the task.</summary>
		[ComImport, Guid("8FD4711D-2D02-4C8C-87E3-EFF699DE127E"), InterfaceType(ComInterfaceType.InterfaceIsDual),
		 System.Security.SuppressUnmanagedCodeSecurity]
		[PInvokeData("taskschd.h", MSDNShortId = "aa381843")]
		public interface ITaskSettings
		{
			/// <summary>Gets or sets a Boolean value that indicates that the task can be started by using either the Run command or the Context menu.</summary>
			/// <value>
			/// If True, the task can be run by using the Run command or the Context menu. If False, the task cannot be run using the Run command or the Context
			/// menu. The default is True. When this property is set to True, the task can be started independent of when any triggers start the task.
			/// </value>
			bool AllowDemandStart { get; [param: In] set; }

			/// <summary>Gets or sets a value that specifies how long the Task Scheduler will attempt to restart the task.</summary>
			/// <value>
			/// A value that specifies how long the Task Scheduler will attempt to restart the task. If this property is set, the RestartCount property must also
			/// be set. The format for this string is P&lt;days&gt;DT&lt;hours&gt;H&lt;minutes&gt;M&lt;seconds&gt;S (for example, "PT5M" is 5 minutes, "PT1H" is
			/// 1 hour, and "PT20M" is 20 minutes). The maximum time allowed is 31 days, and the minimum time allowed is 1 minute.
			/// </value>
			string RestartInterval
			{
				[return: MarshalAs(UnmanagedType.BStr)]
				get;
				[param: In, MarshalAs(UnmanagedType.BStr)]
				set;
			}

			/// <summary>Gets or sets the number of times that the Task Scheduler will attempt to restart the task.</summary>
			/// <value>
			/// The number of times that the Task Scheduler will attempt to restart the task. If this property is set, the RestartInterval property must also be set.
			/// </value>
			int RestartCount { get; [param: In] set; }

			/// <summary>Gets or sets the policy that defines how the Task Scheduler deals with multiple instances of the task.</summary>
			/// <value>Specify one of these TASK_INSTANCES_POLICY constants. Default is InstanceIgnoreNew (2).</value>
			TASK_INSTANCES_POLICY MultipleInstances { get; [param: In] set; }

			/// <summary>Gets or sets a Boolean value that indicates that the task will be stopped if the computer is going onto batteries.</summary>
			/// <value>
			/// A Boolean value that indicates that the task will be stopped if the computer is going onto batteries. If True, the property indicates that the
			/// task will be stopped if the computer is going onto batteries. If False, the property indicates that the task will not be stopped if the computer
			/// is going onto batteries. The default is True. See Remarks for more details.
			/// </value>
			bool StopIfGoingOnBatteries { get; [param: In] set; }

			/// <summary>Gets or sets a Boolean value that indicates that the task will not be started if the computer is running on batteries.</summary>
			/// <value>
			/// A Boolean value that indicates that the task will not be started if the computer is running on batteries. If True, the task will not be started
			/// if the computer is running on batteries. If False, the task will be started if the computer is running on batteries. The default is True.
			/// </value>
			bool DisallowStartIfOnBatteries { get; [param: In] set; }

			/// <summary>
			/// Gets or sets a Boolean value that indicates that the task may be terminated by the Task Scheduler service using TerminateProcess. The service
			/// will try to close the running task by sending the WM_CLOSE notification, and if the task does not respond, the task will be terminated only if
			/// this property is set to true.
			/// </summary>
			/// <value>A Boolean value that indicates that the task may be terminated by using TerminateProcess.</value>
			bool AllowHardTerminate { get; [param: In] set; }

			/// <summary>
			/// Gets or sets a Boolean value that indicates that the Task Scheduler can start the task at any time after its scheduled time has passed.
			/// </summary>
			/// <value>
			/// If True, the property indicates that the Task Scheduler can start the task at any time after its scheduled time has passed. The default is False.
			/// </value>
			/// <remarks>
			/// This property applies only to time-based tasks with an end boundary or time-based tasks that are set to repeat infinitely.
			/// <para>
			/// Tasks that are started after the scheduled time has passed (because of the StartWhenAvailable property being set to True) are queued in the Task
			/// Scheduler service's queue of tasks and they are started after a delay. The default delay is 10 minutes.
			/// </para>
			/// </remarks>
			bool StartWhenAvailable { get; [param: In] set; }

			/// <summary>Gets or sets an XML-formatted definition of the task settings.</summary>
			/// <value>An XML-formatted definition of the task settings.</value>
			string XmlText { [return: MarshalAs(UnmanagedType.BStr)] get; [param: In, MarshalAs(UnmanagedType.BStr)] set; }

			/// <summary>Gets or sets a Boolean value that indicates that the Task Scheduler will run the task only when a network is available.</summary>
			/// <value>If True, the property indicates that the Task Scheduler will run the task only when a network is available. The default is False.</value>
			bool RunOnlyIfNetworkAvailable { get; [param: In] set; }

			/// <summary>
			/// Gets or sets the amount of time that is allowed to complete the task. By default, a task will be stopped 72 hours after it starts to run. You can
			/// change this by changing this setting.
			/// </summary>
			/// <value>The amount of time that is allowed to complete the task. When this parameter is set to NULL, the execution time limit is infinite.</value>
			string ExecutionTimeLimit
			{
				[return: MarshalAs(UnmanagedType.BStr)]
				get;
				[param: In, MarshalAs(UnmanagedType.BStr)]
				set;
			}

			/// <summary>Gets or sets a Boolean value that indicates that the task is enabled. The task can be performed only when this setting is True.</summary>
			/// <value>If True, the task is enabled. If False, the task is not enabled.</value>
			bool Enabled { get; [param: In] set; }

			/// <summary>
			/// Gets or sets the amount of time that the Task Scheduler will wait before deleting the task after it expires. If no value is specified for this
			/// property, then the Task Scheduler service will not delete the task.
			/// </summary>
			/// <value>
			/// A string that gets and sets the amount of time that the Task Scheduler will wait before deleting the task after it expires. The format for this
			/// string is PnYnMnDTnHnMnS, where nY is the number of years, nM is the number of months, nD is the number of days, 'T' is the date/time separator,
			/// nH is the number of hours, nM is the number of minutes, and nS is the number of seconds (for example, PT5M specifies 5 minutes and P1M4DT2H5M
			/// specifies one month, four days, two hours, and five minutes).
			/// </value>
			/// <remarks>
			/// A task expires after the end boundary has been exceeded for all triggers associated with the task. The end boundary for a trigger is specified by
			/// the EndBoundary property inherited by all trigger interfaces.
			/// </remarks>
			string DeleteExpiredTaskAfter
			{
				[return: MarshalAs(UnmanagedType.BStr)]
				get;
				[param: In, MarshalAs(UnmanagedType.BStr)]
				set;
			}

			/// <summary>Gets or sets the priority level of the task.</summary>
			/// <value>The priority level (0-10) of the task. The default is 7.</value>
			/// <remarks>
			/// Priority level 0 is the highest priority, and priority level 10 is the lowest priority. The default value is 7. Priority levels 7 and 8 are used
			/// for background tasks, and priority levels 4, 5, and 6 are used for interactive tasks.
			/// <para>
			/// The task's action is started in a process with a priority that is based on a Priority Class value. A Priority Level value (thread priority) is
			/// used for COM handler, message box, and email task actions. For more information about the Priority Class and Priority Level values, see
			/// Scheduling Priorities. The following table lists the possible values for the priority parameter, and the corresponding Priority Class and
			/// Priority Level values.
			/// </para>
			/// <list type="table">
			/// <listheader>
			/// <term>Task priority</term>
			/// <term>Priority Class</term>
			/// <term>Priority Level</term>
			/// </listheader>
			/// <item>
			/// <term>0</term>
			/// <term>REALTIME_PRIORITY_CLASS</term>
			/// <term>THREAD_PRIORITY_TIME_CRITICAL</term>
			/// </item>
			/// <item>
			/// <term>1</term>
			/// <term>HIGH_PRIORITY_CLASS</term>
			/// <term>THREAD_PRIORITY_HIGHEST</term>
			/// </item>
			/// <item>
			/// <term>2</term>
			/// <term>ABOVE_NORMAL_PRIORITY_CLASS</term>
			/// <term>THREAD_PRIORITY_ABOVE_NORMAL</term>
			/// </item>
			/// <item>
			/// <term>3</term>
			/// <term>ABOVE_NORMAL_PRIORITY_CLASS</term>
			/// <term>THREAD_PRIORITY_ABOVE_NORMAL</term>
			/// </item>
			/// <item>
			/// <term>4</term>
			/// <term>NORMAL_PRIORITY_CLASS</term>
			/// <term>THREAD_PRIORITY_NORMAL</term>
			/// </item>
			/// <item>
			/// <term>5</term>
			/// <term>NORMAL_PRIORITY_CLASS</term>
			/// <term>THREAD_PRIORITY_NORMAL</term>
			/// </item>
			/// <item>
			/// <term>6</term>
			/// <term>NORMAL_PRIORITY_CLASS</term>
			/// <term>THREAD_PRIORITY_NORMAL</term>
			/// </item>
			/// <item>
			/// <term>7</term>
			/// <term>BELOW_NORMAL_PRIORITY_CLASS</term>
			/// <term>THREAD_PRIORITY_BELOW_NORMAL</term>
			/// </item>
			/// <item>
			/// <term>8</term>
			/// <term>BELOW_NORMAL_PRIORITY_CLASS</term>
			/// <term>THREAD_PRIORITY_BELOW_NORMAL</term>
			/// </item>
			/// <item>
			/// <term>9</term>
			/// <term>IDLE_PRIORITY_CLASS</term>
			/// <term>THREAD_PRIORITY_LOWEST</term>
			/// </item>
			/// <item>
			/// <term>10</term>
			/// <term>IDLE_PRIORITY_CLASS</term>
			/// <term>THREAD_PRIORITY_IDLE</term>
			/// </item>
			/// </list>
			/// </remarks>
			int Priority { get; [param: In] set; }

			/// <summary>Gets or sets an integer value that indicates which version of Task Scheduler a task is compatible with.</summary>
			/// <value>One of the following TASK_COMPATIBILITY constants.</value>
			TASK_COMPATIBILITY Compatibility { get; [param: In] set; }

			/// <summary>
			/// Gets or sets a Boolean value that indicates that the task will not be visible in the UI. However, administrators can override this setting
			/// through the use of a 'master switch' that makes all tasks visible in the UI.
			/// </summary>
			/// <value>A Boolean value that indicates that the task will not be visible in the UI. The default is False.</value>
			bool Hidden { get; [param: In] set; }

			/// <summary>
			/// Gets or sets the information that specifies how the Task Scheduler performs tasks when the computer is in an idle condition. For information
			/// about idle conditions, see Task Idle Conditions.
			/// </summary>
			/// <value>An IIdleSettings interface that specifies how the Task Scheduler handles the task when the computer switches to an idle state.</value>
			/// <remarks>
			/// When battery saver is on, Windows Task Scheduler tasks are triggered only if the task is:
			/// <list type="bullet">
			/// <item>
			/// <term>Not set to Start the task only if the computer is idle... (task doesn't use IdleSettings)</term>
			/// </item>
			/// <item>
			/// <term>Not set to run during automatic maintenance (task doesn't use MaintenanceSettings)</term>
			/// </item>
			/// <item>
			/// <term>Is set to Run only when user is logged on (task LogonType is TASK_LOGON_INTERACTIVE_TOKEN or TASK_LOGON_GROUP)</term>
			/// </item>
			/// </list>
			/// <para>
			/// All other triggers are delayed until battery saver is off. For more information about accessing battery saver status in your application, see
			/// SYSTEM_POWER_STATUS. For general information about battery saver, see battery saver (in the hardware component guidelines).
			/// </para>
			/// </remarks>
			IIdleSettings IdleSettings
			{
				[return: MarshalAs(UnmanagedType.Interface)]
				get;
				[param: In, MarshalAs(UnmanagedType.Interface)]
				set;
			}

			/// <summary>Gets or sets a Boolean value that indicates that the Task Scheduler will run the task only if the computer is in an idle condition.</summary>
			/// <value>
			/// If True, the property indicates that the Task Scheduler will run the task only if the computer is in an idle condition. The default is False.
			/// </value>
			bool RunOnlyIfIdle { get; [param: In] set; }

			/// <summary>
			/// Gets or sets a Boolean value that indicates that the Task Scheduler will wake the computer when it is time to run the task, and keep the computer
			/// awake until the task is completed.
			/// </summary>
			/// <value>
			/// If True, the property indicates that the Task Scheduler will wake the computer when it is time to run the task, and keep the computer awake until
			/// the task is completed.
			/// </value>
			/// <remarks>
			/// If a task has this property set to true, and is triggered when the computer is already awake, Task Scheduler will request the computer to stay
			/// awake until the task has completed running.
			/// <para>
			/// When the Task Scheduler service wakes the computer to run a task, the screen may remain off even though the computer is no longer in the sleep or
			/// hibernate mode. The screen will turn on when Windows Vista detects that a user has returned to use the computer.
			/// </para>
			/// </remarks>
			bool WakeToRun { get; [param: In] set; }

			/// <summary>
			/// Gets or sets the network settings object that contains a network profile identifier and name. If the RunOnlyIfNetworkAvailable property of
			/// ITaskSettings is true and a network propfile is specified in the NetworkSettings property, then the task will run only if the specified network
			/// profile is available.
			/// </summary>
			/// <value>A pointer to an INetworkSettings object that contains a network profile identifier and name.</value>
			INetworkSettings NetworkSettings
			{
				[return: MarshalAs(UnmanagedType.Interface)]
				get;
				[param: In, MarshalAs(UnmanagedType.Interface)]
				set;
			}
		}

		/// <summary>Provides the extended settings that the Task Scheduler uses to run the task.</summary>
		[ComImport, Guid("2C05C3F0-6EED-4c05-A15F-ED7D7A98A369"), InterfaceType(ComInterfaceType.InterfaceIsDual),
		 System.Security.SuppressUnmanagedCodeSecurity]
		[PInvokeData("taskschd.h", MSDNShortId = "ee695863")]
		public interface ITaskSettings2
		{
			/// <summary>
			/// Gets or sets a Boolean value that specifies that the task will not be started if triggered to run in a Remote Applications Integrated Locally
			/// (RAIL) session.
			/// </summary>
			/// <value>If True, the task will not be started if triggered to run in a RAIL session. The default is False.</value>
			bool DisallowStartOnRemoteAppSession { get; [param: In] set; }

			/// <summary>Gets or sets a Boolean value that indicates that the Unified Scheduling Engine will be utilized to run this task.</summary>
			/// <value>A Boolean value that indicates that the Unified Scheduling Engine will be utilized to run this task.</value>
			bool UseUnifiedSchedulingEngine { get; [param: In] set; }
		}

		/// <summary>Provides the extended settings that the Task Scheduler uses to run the task.</summary>
		/// <seealso cref="Vanara.PInvoke.TaskSchd.ITaskSettings"/>
		[ComImport, Guid("0AD9D0D7-0C7F-4EBB-9A5F-D1C648DCA528"), InterfaceType(ComInterfaceType.InterfaceIsDual),
		 System.Security.SuppressUnmanagedCodeSecurity]
		[PInvokeData("taskschd.h", MSDNShortId = "hh832148")]
		public interface ITaskSettings3 : ITaskSettings
		{
			/// <summary>Gets or sets a Boolean value that indicates that the task can be started by using either the Run command or the Context menu.</summary>
			/// <value>
			/// If True, the task can be run by using the Run command or the Context menu. If False, the task cannot be run using the Run command or the Context
			/// menu. The default is True. When this property is set to True, the task can be started independent of when any triggers start the task.
			/// </value>
			new bool AllowDemandStart { get; [param: In] set; }

			/// <summary>Gets or sets a value that specifies how long the Task Scheduler will attempt to restart the task.</summary>
			/// <value>
			/// A value that specifies how long the Task Scheduler will attempt to restart the task. If this property is set, the RestartCount property must also
			/// be set. The format for this string is P&lt;days&gt;DT&lt;hours&gt;H&lt;minutes&gt;M&lt;seconds&gt;S (for example, "PT5M" is 5 minutes, "PT1H" is
			/// 1 hour, and "PT20M" is 20 minutes). The maximum time allowed is 31 days, and the minimum time allowed is 1 minute.
			/// </value>
			new string RestartInterval
			{
				[return: MarshalAs(UnmanagedType.BStr)]
				get;
				[param: In, MarshalAs(UnmanagedType.BStr)]
				set;
			}

			/// <summary>Gets or sets the number of times that the Task Scheduler will attempt to restart the task.</summary>
			/// <value>
			/// The number of times that the Task Scheduler will attempt to restart the task. If this property is set, the RestartInterval property must also be set.
			/// </value>
			new int RestartCount { get; [param: In] set; }

			/// <summary>Gets or sets the policy that defines how the Task Scheduler deals with multiple instances of the task.</summary>
			/// <value>Specify one of these TASK_INSTANCES_POLICY constants. Default is InstanceIgnoreNew (2).</value>
			new TASK_INSTANCES_POLICY MultipleInstances { get; [param: In] set; }

			/// <summary>Gets or sets a Boolean value that indicates that the task will be stopped if the computer is going onto batteries.</summary>
			/// <value>
			/// A Boolean value that indicates that the task will be stopped if the computer is going onto batteries. If True, the property indicates that the
			/// task will be stopped if the computer is going onto batteries. If False, the property indicates that the task will not be stopped if the computer
			/// is going onto batteries. The default is True. See Remarks for more details.
			/// </value>
			new bool StopIfGoingOnBatteries { get; [param: In] set; }

			/// <summary>Gets or sets a Boolean value that indicates that the task will not be started if the computer is running on batteries.</summary>
			/// <value>
			/// A Boolean value that indicates that the task will not be started if the computer is running on batteries. If True, the task will not be started
			/// if the computer is running on batteries. If False, the task will be started if the computer is running on batteries. The default is True.
			/// </value>
			new bool DisallowStartIfOnBatteries { get; [param: In] set; }

			/// <summary>
			/// Gets or sets a Boolean value that indicates that the task may be terminated by the Task Scheduler service using TerminateProcess. The service
			/// will try to close the running task by sending the WM_CLOSE notification, and if the task does not respond, the task will be terminated only if
			/// this property is set to true.
			/// </summary>
			/// <value>A Boolean value that indicates that the task may be terminated by using TerminateProcess.</value>
			new bool AllowHardTerminate { get; [param: In] set; }

			/// <summary>
			/// Gets or sets a Boolean value that indicates that the Task Scheduler can start the task at any time after its scheduled time has passed.
			/// </summary>
			/// <value>
			/// If True, the property indicates that the Task Scheduler can start the task at any time after its scheduled time has passed. The default is False.
			/// </value>
			/// <remarks>
			/// This property applies only to time-based tasks with an end boundary or time-based tasks that are set to repeat infinitely.
			/// <para>
			/// Tasks that are started after the scheduled time has passed (because of the StartWhenAvailable property being set to True) are queued in the Task
			/// Scheduler service's queue of tasks and they are started after a delay. The default delay is 10 minutes.
			/// </para>
			/// </remarks>
			new bool StartWhenAvailable { get; [param: In] set; }

			/// <summary>Gets or sets an XML-formatted definition of the task settings.</summary>
			/// <value>An XML-formatted definition of the task settings.</value>
			new string XmlText { [return: MarshalAs(UnmanagedType.BStr)] get; [param: In, MarshalAs(UnmanagedType.BStr)] set; }

			/// <summary>Gets or sets a Boolean value that indicates that the Task Scheduler will run the task only when a network is available.</summary>
			/// <value>If True, the property indicates that the Task Scheduler will run the task only when a network is available. The default is False.</value>
			new bool RunOnlyIfNetworkAvailable { get; [param: In] set; }

			/// <summary>
			/// Gets or sets the amount of time that is allowed to complete the task. By default, a task will be stopped 72 hours after it starts to run. You can
			/// change this by changing this setting.
			/// </summary>
			/// <value>The amount of time that is allowed to complete the task. When this parameter is set to NULL, the execution time limit is infinite.</value>
			new string ExecutionTimeLimit
			{
				[return: MarshalAs(UnmanagedType.BStr)]
				get;
				[param: In, MarshalAs(UnmanagedType.BStr)]
				set;
			}

			/// <summary>Gets or sets a Boolean value that indicates that the task is enabled. The task can be performed only when this setting is True.</summary>
			/// <value>If True, the task is enabled. If False, the task is not enabled.</value>
			new bool Enabled { get; [param: In] set; }

			/// <summary>
			/// Gets or sets the amount of time that the Task Scheduler will wait before deleting the task after it expires. If no value is specified for this
			/// property, then the Task Scheduler service will not delete the task.
			/// </summary>
			/// <value>
			/// A string that gets and sets the amount of time that the Task Scheduler will wait before deleting the task after it expires. The format for this
			/// string is PnYnMnDTnHnMnS, where nY is the number of years, nM is the number of months, nD is the number of days, 'T' is the date/time separator,
			/// nH is the number of hours, nM is the number of minutes, and nS is the number of seconds (for example, PT5M specifies 5 minutes and P1M4DT2H5M
			/// specifies one month, four days, two hours, and five minutes).
			/// </value>
			/// <remarks>
			/// A task expires after the end boundary has been exceeded for all triggers associated with the task. The end boundary for a trigger is specified by
			/// the EndBoundary property inherited by all trigger interfaces.
			/// </remarks>
			new string DeleteExpiredTaskAfter
			{
				[return: MarshalAs(UnmanagedType.BStr)]
				get;
				[param: In, MarshalAs(UnmanagedType.BStr)]
				set;
			}

			/// <summary>Gets or sets the priority level of the task.</summary>
			/// <value>The priority level (0-10) of the task. The default is 7.</value>
			/// <remarks>
			/// Priority level 0 is the highest priority, and priority level 10 is the lowest priority. The default value is 7. Priority levels 7 and 8 are used
			/// for background tasks, and priority levels 4, 5, and 6 are used for interactive tasks.
			/// <para>
			/// The task's action is started in a process with a priority that is based on a Priority Class value. A Priority Level value (thread priority) is
			/// used for COM handler, message box, and email task actions. For more information about the Priority Class and Priority Level values, see
			/// Scheduling Priorities. The following table lists the possible values for the priority parameter, and the corresponding Priority Class and
			/// Priority Level values.
			/// </para>
			/// <list type="table">
			/// <listheader>
			/// <term>Task priority</term>
			/// <term>Priority Class</term>
			/// <term>Priority Level</term>
			/// </listheader>
			/// <item>
			/// <term>0</term>
			/// <term>REALTIME_PRIORITY_CLASS</term>
			/// <term>THREAD_PRIORITY_TIME_CRITICAL</term>
			/// </item>
			/// <item>
			/// <term>1</term>
			/// <term>HIGH_PRIORITY_CLASS</term>
			/// <term>THREAD_PRIORITY_HIGHEST</term>
			/// </item>
			/// <item>
			/// <term>2</term>
			/// <term>ABOVE_NORMAL_PRIORITY_CLASS</term>
			/// <term>THREAD_PRIORITY_ABOVE_NORMAL</term>
			/// </item>
			/// <item>
			/// <term>3</term>
			/// <term>ABOVE_NORMAL_PRIORITY_CLASS</term>
			/// <term>THREAD_PRIORITY_ABOVE_NORMAL</term>
			/// </item>
			/// <item>
			/// <term>4</term>
			/// <term>NORMAL_PRIORITY_CLASS</term>
			/// <term>THREAD_PRIORITY_NORMAL</term>
			/// </item>
			/// <item>
			/// <term>5</term>
			/// <term>NORMAL_PRIORITY_CLASS</term>
			/// <term>THREAD_PRIORITY_NORMAL</term>
			/// </item>
			/// <item>
			/// <term>6</term>
			/// <term>NORMAL_PRIORITY_CLASS</term>
			/// <term>THREAD_PRIORITY_NORMAL</term>
			/// </item>
			/// <item>
			/// <term>7</term>
			/// <term>BELOW_NORMAL_PRIORITY_CLASS</term>
			/// <term>THREAD_PRIORITY_BELOW_NORMAL</term>
			/// </item>
			/// <item>
			/// <term>8</term>
			/// <term>BELOW_NORMAL_PRIORITY_CLASS</term>
			/// <term>THREAD_PRIORITY_BELOW_NORMAL</term>
			/// </item>
			/// <item>
			/// <term>9</term>
			/// <term>IDLE_PRIORITY_CLASS</term>
			/// <term>THREAD_PRIORITY_LOWEST</term>
			/// </item>
			/// <item>
			/// <term>10</term>
			/// <term>IDLE_PRIORITY_CLASS</term>
			/// <term>THREAD_PRIORITY_IDLE</term>
			/// </item>
			/// </list>
			/// </remarks>
			new int Priority { get; [param: In] set; }

			/// <summary>Gets or sets an integer value that indicates which version of Task Scheduler a task is compatible with.</summary>
			/// <value>One of the following TASK_COMPATIBILITY constants.</value>
			new TASK_COMPATIBILITY Compatibility { get; [param: In] set; }

			/// <summary>
			/// Gets or sets a Boolean value that indicates that the task will not be visible in the UI. However, administrators can override this setting
			/// through the use of a 'master switch' that makes all tasks visible in the UI.
			/// </summary>
			/// <value>A Boolean value that indicates that the task will not be visible in the UI. The default is False.</value>
			new bool Hidden { get; [param: In] set; }

			/// <summary>
			/// Gets or sets the information that specifies how the Task Scheduler performs tasks when the computer is in an idle condition. For information
			/// about idle conditions, see Task Idle Conditions.
			/// </summary>
			/// <value>An IIdleSettings interface that specifies how the Task Scheduler handles the task when the computer switches to an idle state.</value>
			/// <remarks>
			/// When battery saver is on, Windows Task Scheduler tasks are triggered only if the task is:
			/// <list type="bullet">
			/// <item>
			/// <term>Not set to Start the task only if the computer is idle... (task doesn't use IdleSettings)</term>
			/// </item>
			/// <item>
			/// <term>Not set to run during automatic maintenance (task doesn't use MaintenanceSettings)</term>
			/// </item>
			/// <item>
			/// <term>Is set to Run only when user is logged on (task LogonType is TASK_LOGON_INTERACTIVE_TOKEN or TASK_LOGON_GROUP)</term>
			/// </item>
			/// </list>
			/// <para>
			/// All other triggers are delayed until battery saver is off. For more information about accessing battery saver status in your application, see
			/// SYSTEM_POWER_STATUS. For general information about battery saver, see battery saver (in the hardware component guidelines).
			/// </para>
			/// </remarks>
			new IIdleSettings IdleSettings
			{
				[return: MarshalAs(UnmanagedType.Interface)]
				get;
				[param: In, MarshalAs(UnmanagedType.Interface)]
				set;
			}

			/// <summary>Gets or sets a Boolean value that indicates that the Task Scheduler will run the task only if the computer is in an idle condition.</summary>
			/// <value>
			/// If True, the property indicates that the Task Scheduler will run the task only if the computer is in an idle condition. The default is False.
			/// </value>
			new bool RunOnlyIfIdle { get; [param: In] set; }

			/// <summary>
			/// Gets or sets a Boolean value that indicates that the Task Scheduler will wake the computer when it is time to run the task, and keep the computer
			/// awake until the task is completed.
			/// </summary>
			/// <value>
			/// If True, the property indicates that the Task Scheduler will wake the computer when it is time to run the task, and keep the computer awake until
			/// the task is completed.
			/// </value>
			/// <remarks>
			/// If a task has this property set to true, and is triggered when the computer is already awake, Task Scheduler will request the computer to stay
			/// awake until the task has completed running.
			/// <para>
			/// When the Task Scheduler service wakes the computer to run a task, the screen may remain off even though the computer is no longer in the sleep or
			/// hibernate mode. The screen will turn on when Windows Vista detects that a user has returned to use the computer.
			/// </para>
			/// </remarks>
			new bool WakeToRun { get; [param: In] set; }

			/// <summary>
			/// Gets or sets the network settings object that contains a network profile identifier and name. If the RunOnlyIfNetworkAvailable property of
			/// ITaskSettings is true and a network propfile is specified in the NetworkSettings property, then the task will run only if the specified network
			/// profile is available.
			/// </summary>
			/// <value>A pointer to an INetworkSettings object that contains a network profile identifier and name.</value>
			new INetworkSettings NetworkSettings
			{
				[return: MarshalAs(UnmanagedType.Interface)]
				get;
				[param: In, MarshalAs(UnmanagedType.Interface)]
				set;
			}

			/// <summary>
			/// Gets or sets a Boolean value that specifies that the task will not be started if triggered to run in a Remote Applications Integrated Locally
			/// (RAIL) session.
			/// </summary>
			/// <value>If True, the task will not be started if triggered to run in a RAIL session. The default is False.</value>
			bool DisallowStartOnRemoteAppSession { get; [param: In] set; }

			/// <summary>Gets or sets a Boolean value that indicates that the Unified Scheduling Engine will be utilized to run this task.</summary>
			/// <value>A Boolean value that indicates that the Unified Scheduling Engine will be utilized to run this task.</value>
			bool UseUnifiedSchedulingEngine { get; [param: In] set; }

			/// <summary>Gets or sets a pointer to pointer to an IMaintenanceSettingsobject that Task scheduler uses to perform a task during Automatic maintenance.</summary>
			/// <value>A pointer to a pointer to an IMaintenanceSettings object.</value>
			/// <remarks>
			/// When battery saver is on, Windows Task Scheduler tasks are triggered only if the task is:
			/// <list type="bullet">
			/// <item>
			/// <term>Not set to Start the task only if the computer is idle... (task doesn't use IdleSettings)</term>
			/// </item>
			/// <item>
			/// <term>Not set to run during automatic maintenance (task doesn't use MaintenanceSettings)</term>
			/// </item>
			/// <item>
			/// <term>Is set to Run only when user is logged on (task LogonType is TASK_LOGON_INTERACTIVE_TOKEN or TASK_LOGON_GROUP)</term>
			/// </item>
			/// <para>
			/// All other triggers are delayed until battery saver is off. For more information about accessing battery saver status in your application, see
			/// SYSTEM_POWER_STATUS. For general information about battery saver, see battery saver (in the hardware component guidelines).
			/// </para>
			/// </list>
			/// </remarks>
			IMaintenanceSettings MaintenanceSettings
			{
				[return: MarshalAs(UnmanagedType.Interface)]
				get;
				[param: In, MarshalAs(UnmanagedType.Interface)]
				set;
			}

			/// <summary>Creates a new instance an IMaintenanceSettings object and associates it with this ITaskSettings3 object.</summary>
			/// <returns>A pointer to a pointer to the IMaintenanceSettings object this method creates.</returns>
			/// <remarks>
			/// When battery saver is on, Windows Task Scheduler tasks are triggered only if the task is:
			/// <list type="bullet">
			/// <item>
			/// <term>Not set to Start the task only if the computer is idle... (task doesn't use IdleSettings)</term>
			/// </item>
			/// <item>
			/// <term>Not set to run during automatic maintenance (task doesn't use MaintenanceSettings)</term>
			/// </item>
			/// <item>
			/// <term>Is set to Run only when user is logged on (task LogonType is TASK_LOGON_INTERACTIVE_TOKEN or TASK_LOGON_GROUP)</term>
			/// </item>
			/// <para>
			/// All other triggers are delayed until battery saver is off. For more information about accessing battery saver status in your application, see
			/// SYSTEM_POWER_STATUS. For general information about battery saver, see battery saver (in the hardware component guidelines).
			/// </para>
			/// </list>
			/// </remarks>
			[return: MarshalAs(UnmanagedType.Interface)]
			IMaintenanceSettings CreateMaintenanceSettings();

			/// <summary>Gets or sets a boolean value that indicates whether the task is automatically disabled every time Windows starts.</summary>
			/// <value>TRUE to disable the task automatically at Windows startup; otherwise, FALSE.</value>
			bool Volatile { get; [param: In] set; }
		}

		/// <summary>
		/// Defines task variables that can be passed as parameters to task handlers and external executables that are launched by tasks. Task handlers that need
		/// to input and output data to job variables should do a query interface on the services pointer for ITaskVariables.
		/// </summary>
		[ComImport, Guid("3E4C9351-D966-4B8B-BB87-CEBA68BB0107"), InterfaceType(ComInterfaceType.InterfaceIsIUnknown),
		 System.Security.SuppressUnmanagedCodeSecurity]
		[PInvokeData("taskschd.h", MSDNShortId = "aa381868")]
		public interface ITaskVariables
		{
			/// <summary>Gets the input variables for a task. This method is not implemented.</summary>
			/// <returns>The input variables for a task.</returns>
			[return: MarshalAs(UnmanagedType.BStr)]
			[MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
			string GetInput();

			/// <summary>Sets the output variables for a task. This method is not implemented.</summary>
			/// <param name="input">The output variables for a task.</param>
			[MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
			void SetOutput([In, MarshalAs(UnmanagedType.BStr)] string input);

			/// <summary>Used to share the context between different steps and tasks that are in the same job instance. This method is not implemented.</summary>
			/// <returns>The context that is used to share the context between different steps and tasks that are in the same job instance.</returns>
			[return: MarshalAs(UnmanagedType.BStr)]
			[MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
			string GetContext();
		}

		/// <summary>Represents a trigger that starts a task at a specific date and time.</summary>
		/// <seealso cref="Vanara.PInvoke.TaskSchd.ITrigger"/>
		[ComImport, Guid("B45747E0-EBA7-4276-9F29-85C5BB300006"), InterfaceType(ComInterfaceType.InterfaceIsDual),
		 System.Security.SuppressUnmanagedCodeSecurity]
		[PInvokeData("taskschd.h", MSDNShortId = "aa381885")]
		public interface ITimeTrigger : ITrigger
		{
			/// <summary>
			/// Gets the type of the trigger. The trigger type is defined when the trigger is created and cannot be changed later. For information on creating a
			/// trigger, see ITriggerCollection::Create.
			/// </summary>
			/// <value>One of the following TASK_TRIGGER_TYPE2 enumeration values.</value>
			new TASK_TRIGGER_TYPE2 Type { get; }

			/// <summary>Gets or sets the identifier for the trigger.</summary>
			/// <value>The identifier for the trigger. This identifier is used by the Task Scheduler for logging purposes.</value>
			new string Id { [return: MarshalAs(UnmanagedType.BStr)] get; [param: In, MarshalAs(UnmanagedType.BStr)] set; }

			/// <summary>
			/// Gets or sets a value that indicates how often the task is run and how long the repetition pattern is repeated after the task is started.
			/// </summary>
			/// <value>The repetition pattern for how often the task is run and how long the repetition pattern is repeated after the task is started.</value>
			new IRepetitionPattern Repetition
			{
				[return: MarshalAs(UnmanagedType.Interface)]
				get;
				[param: In, MarshalAs(UnmanagedType.Interface)]
				set;
			}

			/// <summary>Gets or sets the maximum amount of time that the task launched by this trigger is allowed to run.</summary>
			/// <value>The maximum amount of time that the task launched by the trigger is allowed to run.</value>
			/// <remarks>
			/// The format for this string is PnYnMnDTnHnMnS, where nY is the number of years, nM is the number of months, nD is the number of days, 'T' is the
			/// date/time separator, nH is the number of hours, nM is the number of minutes, and nS is the number of seconds (for example, PT5M specifies 5
			/// minutes and P1M4DT2H5M specifies one month, four days, two hours, and five minutes).
			/// </remarks>
			new string ExecutionTimeLimit
			{
				[return: MarshalAs(UnmanagedType.BStr)]
				get;
				[param: In, MarshalAs(UnmanagedType.BStr)]
				set;
			}

			/// <summary>Gets or sets the date and time when the trigger is activated.</summary>
			/// <value>The date and time when the trigger is activated.</value>
			/// <remarks>
			/// The date and time must be in the following format: YYYY-MM-DDTHH:MM:SS(+-)HH:MM. The (+-)HH:MM section of the format defines a certain number of
			/// hours and minutes ahead or behind Coordinated Universal Time (UTC). For example the date October 11th, 2005 at 1:21:17 with an offset of eight
			/// hours behind UTC would be written as 2005-10-11T13:21:17-08:00. If Z is specified for the UTC offset (for example, 2005-10-11T13:21:17Z), then
			/// the no offset from UTC will be used. If you do not specify any offset time or Z for the offset (for example, 2005-10-11T13:21:17), then the time
			/// zone and daylight saving information that is set on the local computer will be used. When an offset is specified (using hours and minutes or Z),
			/// then the time and offset are always used regardless of the time zone and daylight saving settings on the local computer.
			/// </remarks>
			new string StartBoundary { [return: MarshalAs(UnmanagedType.BStr)] get; [param: In, MarshalAs(UnmanagedType.BStr)] set; }

			/// <summary>Gets or sets the date and time when the trigger is deactivated.</summary>
			/// <value>The date and time when the trigger is deactivated.</value>
			/// <remarks>
			/// The date and time must be in the following format: YYYY-MM-DDTHH:MM:SS(+-)HH:MM. The (+-)HH:MM section of the format defines a certain number of
			/// hours and minutes ahead or behind Coordinated Universal Time (UTC). For example the date October 11th, 2005 at 1:21:17 with an offset of eight
			/// hours behind UTC would be written as 2005-10-11T13:21:17-08:00. If Z is specified for the UTC offset (for example, 2005-10-11T13:21:17Z), then
			/// the no offset from UTC will be used. If you do not specify any offset time or Z for the offset (for example, 2005-10-11T13:21:17), then the time
			/// zone and daylight saving information that is set on the local computer will be used. When an offset is specified (using hours and minutes or Z),
			/// then the time and offset are always used regardless of the time zone and daylight saving settings on the local computer.
			/// </remarks>
			new string EndBoundary { [return: MarshalAs(UnmanagedType.BStr)] get; [param: In, MarshalAs(UnmanagedType.BStr)] set; }

			/// <summary>Gets or sets a Boolean value that indicates whether the trigger is enabled.</summary>
			/// <value>True if the trigger is enabled; otherwise, false. The default is true.</value>
			new bool Enabled { get; [param: In] set; }

			/// <summary>Gets or sets a delay time that is randomly added to the start time of the trigger.</summary>
			/// <value>
			/// A BSTR value that contains the upper bound of the random delay time that is added to the start time of the trigger. The format for this string is
			/// P&lt;days&gt;DT&lt;hours&gt;H&lt;minutes&gt;M&lt;seconds&gt;S (for example, P2DT5S is a 2 day, 5 second time span).
			/// </value>
			/// <remarks>
			/// The specified random delay time is the upper bound for the random interval. The trigger will fire at random during the period specified by the
			/// randomDelay parameter, which doesn't begin until the specified start time of the trigger. For example, if the task trigger is set to every
			/// seventh day, and the randomDelay parameter is set to P2DT5S (2 day, 5 second time span), then once the seventh day is reached, the trigger will
			/// fire once randomly during the next 2 days, 5 seconds.
			/// </remarks>
			string RandomDelay { [return: MarshalAs(UnmanagedType.BStr)] get; [param: In, MarshalAs(UnmanagedType.BStr)] set; }
		}

		/// <summary>Provides the common properties that are inherited by all trigger objects.</summary>
		[ComImport, Guid("09941815-EA89-4B5B-89E0-2A773801FAC3"), InterfaceType(ComInterfaceType.InterfaceIsDual),
		 System.Security.SuppressUnmanagedCodeSecurity]
		[PInvokeData("taskschd.h", MSDNShortId = "aa381887")]
		public interface ITrigger
		{
			/// <summary>
			/// Gets the type of the trigger. The trigger type is defined when the trigger is created and cannot be changed later. For information on creating a
			/// trigger, see ITriggerCollection::Create.
			/// </summary>
			/// <value>One of the following TASK_TRIGGER_TYPE2 enumeration values.</value>
			TASK_TRIGGER_TYPE2 Type { get; }

			/// <summary>Gets or sets the identifier for the trigger.</summary>
			/// <value>The identifier for the trigger. This identifier is used by the Task Scheduler for logging purposes.</value>
			string Id { [return: MarshalAs(UnmanagedType.BStr)] get; [param: In, MarshalAs(UnmanagedType.BStr)] set; }

			/// <summary>
			/// Gets or sets a value that indicates how often the task is run and how long the repetition pattern is repeated after the task is started.
			/// </summary>
			/// <value>The repetition pattern for how often the task is run and how long the repetition pattern is repeated after the task is started.</value>
			IRepetitionPattern Repetition
			{
				[return: MarshalAs(UnmanagedType.Interface)]
				get;
				[param: In, MarshalAs(UnmanagedType.Interface)]
				set;
			}

			/// <summary>Gets or sets the maximum amount of time that the task launched by this trigger is allowed to run.</summary>
			/// <value>The maximum amount of time that the task launched by the trigger is allowed to run.</value>
			/// <remarks>
			/// The format for this string is PnYnMnDTnHnMnS, where nY is the number of years, nM is the number of months, nD is the number of days, 'T' is the
			/// date/time separator, nH is the number of hours, nM is the number of minutes, and nS is the number of seconds (for example, PT5M specifies 5
			/// minutes and P1M4DT2H5M specifies one month, four days, two hours, and five minutes).
			/// </remarks>
			string ExecutionTimeLimit
			{
				[return: MarshalAs(UnmanagedType.BStr)]
				get;
				[param: In, MarshalAs(UnmanagedType.BStr)]
				set;
			}

			/// <summary>Gets or sets the date and time when the trigger is activated.</summary>
			/// <value>The date and time when the trigger is activated.</value>
			/// <remarks>
			/// The date and time must be in the following format: YYYY-MM-DDTHH:MM:SS(+-)HH:MM. The (+-)HH:MM section of the format defines a certain number of
			/// hours and minutes ahead or behind Coordinated Universal Time (UTC). For example the date October 11th, 2005 at 1:21:17 with an offset of eight
			/// hours behind UTC would be written as 2005-10-11T13:21:17-08:00. If Z is specified for the UTC offset (for example, 2005-10-11T13:21:17Z), then
			/// the no offset from UTC will be used. If you do not specify any offset time or Z for the offset (for example, 2005-10-11T13:21:17), then the time
			/// zone and daylight saving information that is set on the local computer will be used. When an offset is specified (using hours and minutes or Z),
			/// then the time and offset are always used regardless of the time zone and daylight saving settings on the local computer.
			/// </remarks>
			string StartBoundary { [return: MarshalAs(UnmanagedType.BStr)] get; [param: In, MarshalAs(UnmanagedType.BStr)] set; }

			/// <summary>Gets or sets the date and time when the trigger is deactivated.</summary>
			/// <value>The date and time when the trigger is deactivated.</value>
			/// <remarks>
			/// The date and time must be in the following format: YYYY-MM-DDTHH:MM:SS(+-)HH:MM. The (+-)HH:MM section of the format defines a certain number of
			/// hours and minutes ahead or behind Coordinated Universal Time (UTC). For example the date October 11th, 2005 at 1:21:17 with an offset of eight
			/// hours behind UTC would be written as 2005-10-11T13:21:17-08:00. If Z is specified for the UTC offset (for example, 2005-10-11T13:21:17Z), then
			/// the no offset from UTC will be used. If you do not specify any offset time or Z for the offset (for example, 2005-10-11T13:21:17), then the time
			/// zone and daylight saving information that is set on the local computer will be used. When an offset is specified (using hours and minutes or Z),
			/// then the time and offset are always used regardless of the time zone and daylight saving settings on the local computer.
			/// </remarks>
			string EndBoundary { [return: MarshalAs(UnmanagedType.BStr)] get; [param: In, MarshalAs(UnmanagedType.BStr)] set; }

			/// <summary>Gets or sets a Boolean value that indicates whether the trigger is enabled.</summary>
			/// <value>True if the trigger is enabled; otherwise, false. The default is true.</value>
			bool Enabled { get; [param: In] set; }
		}

		/// <summary>Provides the methods that are used to add to, remove from, and get the triggers of a task.</summary>
		/// <seealso cref="System.Collections.IEnumerable"/>
		[ComImport, Guid("85DF5081-1B24-4F32-878A-D9D14DF4CB77"), InterfaceType(ComInterfaceType.InterfaceIsDual),
		 System.Security.SuppressUnmanagedCodeSecurity]
		[PInvokeData("taskschd.h", MSDNShortId = "aa381889")]
		public interface ITriggerCollection : IEnumerable
		{
			/// <summary>Gets the number of triggers in the collection.</summary>
			/// <value>The number of triggers in the collection.</value>
			int Count { get; }

			/// <summary>Gets the <see cref="ITrigger"/> at the specified index from the collection.</summary>
			/// <param name="index">The index. Collections are 1-based. That is, the index for the first item in the collection is 1.</param>
			/// <returns>An ITrigger interface that represents the requested trigger.</returns>
			ITrigger this[int index] { [return: MarshalAs(UnmanagedType.Interface)] get; }

			/// <summary>Returns an enumerator that iterates through a collection.</summary>
			/// <returns>An <see cref="T:System.Collections.IEnumerator"/> object that can be used to iterate through the collection.</returns>
			[return: MarshalAs(UnmanagedType.Interface)]
			new IEnumerator GetEnumerator();

			/// <summary>Creates a new trigger for the task.</summary>
			/// <param name="type">This parameter is set to one of the following TASK_TRIGGER_TYPE2 enumeration constants.</param>
			/// <returns>An ITrigger interface that represents the new trigger.</returns>
			[return: MarshalAs(UnmanagedType.Interface)]
			ITrigger Create([In] TASK_TRIGGER_TYPE2 type);

			/// <summary>Removes the specified trigger from the collection of triggers used by the task.</summary>
			/// <param name="index">The index of the trigger to be removed. Use a LONG value for the index number.</param>
			/// <remarks>
			/// When removing items, note that the index for the first item in the collection is 1 and the index for the last item is the value of the Count property.
			/// </remarks>
			void Remove([In, MarshalAs(UnmanagedType.Struct)] object index);

			/// <summary>Clears all triggers from the collection.</summary>
			void Clear();
		}

		/// <summary>
		/// Represents a trigger that starts a task based on a weekly schedule. For example, the task starts at 8:00 A.M. on a specific day of the week every
		/// week or every other week.
		/// </summary>
		/// <seealso cref="Vanara.PInvoke.TaskSchd.ITrigger"/>
		[ComImport, Guid("5038FC98-82FF-436D-8728-A512A57C9DC1"), InterfaceType(ComInterfaceType.InterfaceIsDual),
		 System.Security.SuppressUnmanagedCodeSecurity]
		[PInvokeData("taskschd.h", MSDNShortId = "aa381904")]
		public interface IWeeklyTrigger : ITrigger
		{
			/// <summary>
			/// Gets the type of the trigger. The trigger type is defined when the trigger is created and cannot be changed later. For information on creating a
			/// trigger, see ITriggerCollection::Create.
			/// </summary>
			/// <value>One of the following TASK_TRIGGER_TYPE2 enumeration values.</value>
			new TASK_TRIGGER_TYPE2 Type { get; }

			/// <summary>Gets or sets the identifier for the trigger.</summary>
			/// <value>The identifier for the trigger. This identifier is used by the Task Scheduler for logging purposes.</value>
			new string Id { [return: MarshalAs(UnmanagedType.BStr)] get; [param: In, MarshalAs(UnmanagedType.BStr)] set; }

			/// <summary>
			/// Gets or sets a value that indicates how often the task is run and how long the repetition pattern is repeated after the task is started.
			/// </summary>
			/// <value>The repetition pattern for how often the task is run and how long the repetition pattern is repeated after the task is started.</value>
			new IRepetitionPattern Repetition
			{
				[return: MarshalAs(UnmanagedType.Interface)]
				get;
				[param: In, MarshalAs(UnmanagedType.Interface)]
				set;
			}

			/// <summary>Gets or sets the maximum amount of time that the task launched by this trigger is allowed to run.</summary>
			/// <value>The maximum amount of time that the task launched by the trigger is allowed to run.</value>
			/// <remarks>
			/// The format for this string is PnYnMnDTnHnMnS, where nY is the number of years, nM is the number of months, nD is the number of days, 'T' is the
			/// date/time separator, nH is the number of hours, nM is the number of minutes, and nS is the number of seconds (for example, PT5M specifies 5
			/// minutes and P1M4DT2H5M specifies one month, four days, two hours, and five minutes).
			/// </remarks>
			new string ExecutionTimeLimit
			{
				[return: MarshalAs(UnmanagedType.BStr)]
				get;
				[param: In, MarshalAs(UnmanagedType.BStr)]
				set;
			}

			/// <summary>Gets or sets the date and time when the trigger is activated.</summary>
			/// <value>The date and time when the trigger is activated.</value>
			/// <remarks>
			/// The date and time must be in the following format: YYYY-MM-DDTHH:MM:SS(+-)HH:MM. The (+-)HH:MM section of the format defines a certain number of
			/// hours and minutes ahead or behind Coordinated Universal Time (UTC). For example the date October 11th, 2005 at 1:21:17 with an offset of eight
			/// hours behind UTC would be written as 2005-10-11T13:21:17-08:00. If Z is specified for the UTC offset (for example, 2005-10-11T13:21:17Z), then
			/// the no offset from UTC will be used. If you do not specify any offset time or Z for the offset (for example, 2005-10-11T13:21:17), then the time
			/// zone and daylight saving information that is set on the local computer will be used. When an offset is specified (using hours and minutes or Z),
			/// then the time and offset are always used regardless of the time zone and daylight saving settings on the local computer.
			/// </remarks>
			new string StartBoundary { [return: MarshalAs(UnmanagedType.BStr)] get; [param: In, MarshalAs(UnmanagedType.BStr)] set; }

			/// <summary>Gets or sets the date and time when the trigger is deactivated.</summary>
			/// <value>The date and time when the trigger is deactivated.</value>
			/// <remarks>
			/// The date and time must be in the following format: YYYY-MM-DDTHH:MM:SS(+-)HH:MM. The (+-)HH:MM section of the format defines a certain number of
			/// hours and minutes ahead or behind Coordinated Universal Time (UTC). For example the date October 11th, 2005 at 1:21:17 with an offset of eight
			/// hours behind UTC would be written as 2005-10-11T13:21:17-08:00. If Z is specified for the UTC offset (for example, 2005-10-11T13:21:17Z), then
			/// the no offset from UTC will be used. If you do not specify any offset time or Z for the offset (for example, 2005-10-11T13:21:17), then the time
			/// zone and daylight saving information that is set on the local computer will be used. When an offset is specified (using hours and minutes or Z),
			/// then the time and offset are always used regardless of the time zone and daylight saving settings on the local computer.
			/// </remarks>
			new string EndBoundary { [return: MarshalAs(UnmanagedType.BStr)] get; [param: In, MarshalAs(UnmanagedType.BStr)] set; }

			/// <summary>Gets or sets a Boolean value that indicates whether the trigger is enabled.</summary>
			/// <value>True if the trigger is enabled; otherwise, false. The default is true.</value>
			new bool Enabled { get; [param: In] set; }

			/// <summary>Gets or sets the days of the week in which the task runs.</summary>
			/// <value>A bitwise mask that indicates the days of the week on which the task runs.</value>
			short DaysOfWeek { get; [param: In] set; }

			/// <summary>Gets or sets the interval between the weeks in the schedule.</summary>
			/// <value>
			/// The interval between the weeks in the schedule. An interval of 1 produces a weekly schedule. An interval of 2 produces an every-other week schedule.
			/// </value>
			short WeeksInterval { get; [param: In] set; }

			/// <summary>Gets or sets a delay time that is randomly added to the start time of the trigger.</summary>
			/// <value>
			/// A BSTR value that contains the upper bound of the random delay time that is added to the start time of the trigger. The format for this string is
			/// P&lt;days&gt;DT&lt;hours&gt;H&lt;minutes&gt;M&lt;seconds&gt;S (for example, P2DT5S is a 2 day, 5 second time span).
			/// </value>
			/// <remarks>
			/// The specified random delay time is the upper bound for the random interval. The trigger will fire at random during the period specified by the
			/// randomDelay parameter, which doesn't begin until the specified start time of the trigger. For example, if the task trigger is set to every
			/// seventh day, and the randomDelay parameter is set to P2DT5S (2 day, 5 second time span), then once the seventh day is reached, the trigger will
			/// fire once randomly during the next 2 days, 5 seconds.
			/// </remarks>
			string RandomDelay { [return: MarshalAs(UnmanagedType.BStr)] get; [param: In, MarshalAs(UnmanagedType.BStr)] set; }
		}

		/// <summary>Provides access to the Task Scheduler service for managing registered tasks.</summary>
		[ComImport, DefaultMember("TargetServer"), Guid("0F87369F-A4E5-4CFC-BD3E-73E6154572DD"), ClassInterface((short)0), System.Security.SuppressUnmanagedCodeSecurity]
		[PInvokeData("taskschd.h", MSDNShortId = "aa381832")]
		public class TaskSchedulerClass
		{
		}
	}
}