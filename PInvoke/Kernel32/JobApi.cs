using System;
using System.Runtime.InteropServices;
using Vanara.Extensions;
using Vanara.InteropServices;

namespace Vanara.PInvoke
{
	public static partial class Kernel32
	{
		/// <summary/>
		public const int JOB_OBJECT_NET_RATE_CONTROL_MAX_DSCP_TAG = 64;

		/// <summary>The scheduling policy for CPU rate control.</summary>
		[Flags]
		public enum JOB_OBJECT_CPU_RATE_CONTROL_FLAGS
		{
			/// <summary>
			/// This flag enables the job's CPU rate to be controlled based on weight or hard cap. You must set this value if you also set
			/// JOB_OBJECT_CPU_RATE_CONTROL_WEIGHT_BASED, JOB_OBJECT_CPU_RATE_CONTROL_HARD_CAP, or JOB_OBJECT_CPU_RATE_CONTROL_MIN_MAX_RATE.
			/// </summary>
			JOB_OBJECT_CPU_RATE_CONTROL_ENABLE = 0x1,

			/// <summary>
			/// The job's CPU rate is calculated based on its relative weight to the weight of other jobs. If this flag is set, the Weight
			/// member contains more information. If this flag is clear, the CpuRate member contains more information.If you set
			/// JOB_OBJECT_CPU_RATE_CONTROL_WEIGHT_BASED, you cannot also set JOB_OBJECT_CPU_RATE_CONTROL_MIN_MAX_RATE.
			/// </summary>
			JOB_OBJECT_CPU_RATE_CONTROL_WEIGHT_BASED = 0x2,

			/// <summary>
			/// The job's CPU rate is a hard limit. After the job reaches its CPU cycle limit for the current scheduling interval, no threads
			/// associated with the job will run until the next interval. If you set JOB_OBJECT_CPU_RATE_CONTROL_HARD_CAP, you cannot also
			/// set JOB_OBJECT_CPU_RATE_CONTROL_MIN_MAX_RATE.
			/// </summary>
			JOB_OBJECT_CPU_RATE_CONTROL_HARD_CAP = 0x4,

			/// <summary>Sends messages when the CPU rate for the job exceeds the rate limits for the job during the tolerance interval.</summary>
			JOB_OBJECT_CPU_RATE_CONTROL_NOTIFY = 0x8,

			/// <summary>
			/// The CPU rate for the job is limited by minimum and maximum rates that you specify in the MinRate and MaxRate members.If you
			/// set JOB_OBJECT_CPU_RATE_CONTROL_MIN_MAX_RATE, you can set neither JOB_OBJECT_CPU_RATE_CONTROL_WEIGHT_BASED nor JOB_OBJECT_CPU_RATE_CONTROL_HARD_CAP.
			/// </summary>
			JOB_OBJECT_CPU_RATE_CONTROL_MIN_MAX_RATE = 0x10,
		}

		/// <summary>The policy for control of the I/O rate.</summary>
		[Flags]
		public enum JOB_OBJECT_IO_RATE_CONTROL_FLAGS
		{
			/// <summary>
			/// Turns on control of the I/O rate for the job when this structure is passed to the SetIoRateControlInformationJobObject
			/// function. Indicates that control of the I/O rate for the job is turned on when this structure is used with the
			/// QueryIoRateControlInformationJobObject function.
			/// </summary>
			JOB_OBJECT_IO_RATE_CONTROL_ENABLE = 0x1,

			/// <summary/>
			JOB_OBJECT_IO_RATE_CONTROL_STANDALONE_VOLUME = 0x2,

			/// <summary/>
			JOB_OBJECT_IO_RATE_CONTROL_FORCE_UNIT_ACCESS_ALL = 0x4,

			/// <summary/>
			JOB_OBJECT_IO_RATE_CONTROL_FORCE_UNIT_ACCESS_ON_SOFT_CAP = 0x8,
		}

		/// <summary>
		/// Completion Port Messages for job objects. These values are returned via the lpNumberOfBytesTransferred parameter when calling <c>GetQueuedCompletionStatus</c>.
		/// </summary>
		[Flags]
		public enum JOB_OBJECT_MSG : uint
		{
			/// <summary>
			/// Indicates that the JOB_OBJECT_POST_AT_END_OF_JOB option is in effect and the end-of-job time limit has been reached. Upon
			/// posting this message, the time limit is canceled and the job's processes can continue to run. The value of lpOverlapped is NULL.
			/// </summary>
			JOB_OBJECT_MSG_END_OF_JOB_TIME = 1,

			/// <summary>
			/// Indicates that a process has exceeded a per-process time limit. The system sends this message after the process termination
			/// has been requested. The value of lpOverlapped is the identifier of the process that exceeded its limit.
			/// </summary>
			JOB_OBJECT_MSG_END_OF_PROCESS_TIME = 2,

			/// <summary>Indicates that the active process limit has been exceeded. The value of lpOverlapped is NULL.</summary>
			JOB_OBJECT_MSG_ACTIVE_PROCESS_LIMIT = 3,

			/// <summary>
			/// Indicates that the active process count has been decremented to 0. For example, if the job currently has two active
			/// processes, the system sends this message after they both terminate. The value of lpOverlapped is NULL.
			/// </summary>
			JOB_OBJECT_MSG_ACTIVE_PROCESS_ZERO = 4,

			/// <summary>
			/// Indicates that a process has been added to the job. Processes added to a job at the time a completion port is associated are
			/// also reported. The value of lpOverlapped is the identifier of the process added to the job.
			/// </summary>
			JOB_OBJECT_MSG_NEW_PROCESS = 6,

			/// <summary>
			/// Indicates that a process associated with the job has exited. The value of lpOverlapped is the identifier of the exiting process.
			/// </summary>
			JOB_OBJECT_MSG_EXIT_PROCESS = 7,

			/// <summary>
			/// Indicates that a process associated with the job exited with an exit code that indicates an abnormal exit (see the list
			/// following this table). The value of lpOverlapped is the identifier of the exiting process.
			/// </summary>
			JOB_OBJECT_MSG_ABNORMAL_EXIT_PROCESS = 8,

			/// <summary>
			/// Indicates that a process associated with the job has exceeded its memory limit (if one is in effect). The value of
			/// lpOverlapped is the identifier of the process that has exceeded its limit. The system does not send this message if the
			/// process has not yet reported its process identifier.
			/// </summary>
			JOB_OBJECT_MSG_PROCESS_MEMORY_LIMIT = 9,

			/// <summary>
			/// Indicates that a process associated with the job caused the job to exceed the job-wide memory limit (if one is in effect).
			/// The value of lpOverlapped specifies the identifier of the process that has attempted to exceed the limit. The system does not
			/// send this message if the process has not yet reported its process identifier.
			/// </summary>
			JOB_OBJECT_MSG_JOB_MEMORY_LIMIT = 10,

			/// <summary>
			/// Indicates that a process associated with a job that has registered for resource limit notifications has exceeded one or more
			/// limits. Use the QueryInformationJobObject function with JobObjectLimitViolationInformation to determine which limit was
			/// exceeded. The value of lpOverlapped is the identifier of the process that has exceeded its limit. The system does not send
			/// this message if the process has not yet reported its process identifier.
			/// </summary>
			JOB_OBJECT_MSG_NOTIFICATION_LIMIT = 11,

			/// <summary>Undocumented.</summary>
			JOB_OBJECT_MSG_JOB_CYCLE_TIME_LIMIT = 12,

			/// <summary>Undocumented.</summary>
			JOB_OBJECT_MSG_SILO_TERMINATED = 13,
		}

		/// <summary>Specifies types of scheduling policies for network rate control.</summary>
		// typedef enum JOB_OBJECT_NET_RATE_CONTROL_FLAGS { JOB_OBJECT_NET_RATE_CONTROL_ENABLE = 0x1,
		// JOB_OBJECT_NET_RATE_CONTROL_MAX_BANDWITH = 0x2, JOB_OBJECT_NET_RATE_CONTROL_DSCP_TAG = 0x4,
		// JOB_OBJECT_NET_RATE_CONTROL_VALID_FLAGS = 0x7} JOB_OBJECT_NET_RATE_CONTROL_FLAGS; https://msdn.microsoft.com/en-us/library/windows/desktop/mt280126(v=vs.85).aspx
		[PInvokeData("Winnt.h", MSDNShortId = "mt280126")]
		[Flags]
		public enum JOB_OBJECT_NET_RATE_CONTROL_FLAGS
		{
			/// <summary>
			/// Turns on the control of the network traffic. You must set this value if you also set either
			/// <c>JOB_OBJECT_NET_RATE_CONTROL_MAX_BANDWIDTH</c> or <c>JOB_OBJECT_NET_RATE_CONTROL_DSCP_TAG</c>.
			/// </summary>
			JOB_OBJECT_NET_RATE_CONTROL_ENABLE = 0x1,

			/// <summary>
			/// Uses the value of the <c>MaxBandwidth</c> member of the <c>JOBOBJECT_NET_RATE_CONTROL_INFORMATION</c> structure to set the
			/// maximum bandwidth for outgoing network traffic for the job, in bytes.
			/// </summary>
			JOB_OBJECT_NET_RATE_CONTROL_MAX_BANDWIDTH = 0x2,

			/// <summary>
			/// Sets the DSCP field in the packet header to the value of the <c>DscpTag</c> member of the
			/// <c>JOBOBJECT_NET_RATE_CONTROL_INFORMATION</c> structure. For information about DSCP, see Differentiated Services.
			/// </summary>
			JOB_OBJECT_NET_RATE_CONTROL_DSCP_TAG = 0x4,

			/// <summary>The combination of all of the valid flags for the <c>JOB_OBJECT_NET_RATE_CONTROL_FLAGS</c> enumeration.</summary>
			JOB_OBJECT_NET_RATE_CONTROL_VALID_FLAGS = 0x7
		}

		/// <summary>
		/// <para>
		/// The Microsoft Windows security model enables you to control access to job objects. For more information about security, see
		/// Access-Control Model.
		/// </para>
		/// <para>
		/// You can specify a security descriptor for a job object when you call the <c>CreateJobObject</c> function. If you specify NULL,
		/// the job object gets a default security descriptor. The ACLs in the default security descriptor for a job object come from the
		/// primary or impersonation token of the creator.
		/// </para>
		/// <para>
		/// To get or set the security descriptor for a job object, call the <c>GetNamedSecurityInfo</c>, <c>SetNamedSecurityInfo</c>,
		/// <c>GetSecurityInfo</c>, or <c>SetSecurityInfo</c> function.
		/// </para>
		/// <para>
		/// The valid access rights for job objects include the standard access rights and some job-specific access rights. The following
		/// table lists the standard access rights used by all objects.
		/// </para>
		/// <list type="table">
		/// <listheader>
		/// <term>Value</term>
		/// <term>Meaning</term>
		/// </listheader>
		/// <item>
		/// <term>DELETE (0x00010000L)</term>
		/// <term>Required to delete the object.</term>
		/// </item>
		/// <item>
		/// <term>READ_CONTROL (0x00020000L)</term>
		/// <term>
		/// Required to read information in the security descriptor for the object, not including the information in the SACL. To read or
		/// write the SACL, you must request the ACCESS_SYSTEM_SECURITY access right. For more information, see SACL Access Right.
		/// </term>
		/// </item>
		/// <item>
		/// <term>SYNCHRONIZE (0x00100000L)</term>
		/// <term>The right to use the object for synchronization. This enables a thread to wait until the object is in the signaled state.</term>
		/// </item>
		/// <item>
		/// <term>WRITE_DAC (0x00040000L)</term>
		/// <term>Required to modify the DACL in the security descriptor for the object.</term>
		/// </item>
		/// <item>
		/// <term>WRITE_OWNER (0x00080000L)</term>
		/// <term>Required to change the owner in the security descriptor for the object.</term>
		/// </item>
		/// </list>
		/// <para>The following table lists the job-specific access rights.</para>
		/// <list type="table">
		/// <listheader>
		/// <term>Value</term>
		/// <term>Meaning</term>
		/// </listheader>
		/// <item>
		/// <term>JOB_OBJECT_ALL_ACCESS (0x1F001F)</term>
		/// <term>Combines all valid job object access rights.</term>
		/// </item>
		/// <item>
		/// <term>JOB_OBJECT_ASSIGN_PROCESS (0x0001)</term>
		/// <term>Required to call the AssignProcessToJobObject function to assign processes to the job object.</term>
		/// </item>
		/// <item>
		/// <term>JOB_OBJECT_QUERY (0x0004)</term>
		/// <term>
		/// Required to retrieve certain information about a job object, such as attributes and accounting information (see
		/// QueryInformationJobObject and IsProcessInJob).
		/// </term>
		/// </item>
		/// <item>
		/// <term>JOB_OBJECT_SET_ATTRIBUTES (0x0002)</term>
		/// <term>Required to call the SetInformationJobObject function to set the attributes of the job object.</term>
		/// </item>
		/// <item>
		/// <term>JOB_OBJECT_SET_SECURITY_ATTRIBUTES (0x0010)</term>
		/// <term>
		/// This flag is not supported. You must set security limitations individually for each process associated with a job object.Windows
		/// Server 2003 and Windows XP: Required to call the SetInformationJobObject function with the JobObjectSecurityLimitInformation
		/// information class to set security limitations for the processes associated with the job object. Support for this flag was removed
		/// in Windows Vista and Windows Server 2008.
		/// </term>
		/// </item>
		/// <item>
		/// <term>JOB_OBJECT_TERMINATE (0x0008)</term>
		/// <term>Required to call the TerminateJobObject function to terminate all processes in the job object.</term>
		/// </item>
		/// </list>
		/// <para>
		/// The handle returned by <c>CreateJobObject</c> has <c>JOB_OBJECT_ALL_ACCESS</c> access to the job object. When you call the
		/// <c>OpenJobObject</c> function, the system checks the requested access rights against the object's security descriptor. If a job
		/// object is in a hierarchy of nested jobs, a caller with access to the job object implicitly has access to all of its child jobs in
		/// the hierarchy.
		/// </para>
		/// <para>
		/// You can request the <c>ACCESS_SYSTEM_SECURITY</c> access right to a job object if you want to read or write the object's SACL.
		/// For more information, see Access-Control Lists (ACLs) and SACL Access Right.
		/// </para>
		/// <para>
		/// You must set security limitations individually for each process associated with a job object, rather than setting them for the
		/// job object itself. For information, see Process Security and Access Rights.
		/// </para>
		/// <para>
		/// **Windows Server 2003 and Windows XP: ** You can use the <c>SetInformationJobObject</c> function to set security limitations for
		/// the job object. This capability was removed in Windows Vista and Windows Server 2008.
		/// </para>
		/// </summary>
		// https://docs.microsoft.com/en-us/windows/win32/procthread/job-object-security-and-access-rights
		[PInvokeData("", MSDNShortId = "8d212292-f087-41e4-884e-cec4423dac49")]
		[Flags]
		public enum JobAccessRight : uint
		{
			/// <summary>Required to delete the object.</summary>
			DELETE = ACCESS_MASK.DELETE,

			/// <summary>
			/// Required to read information in the security descriptor for the object, not including the information in the SACL. To read or
			/// write the SACL, you must request the ACCESS_SYSTEM_SECURITY access right. For more information, see SACL Access Right.
			/// </summary>
			READ_CONTROL = ACCESS_MASK.READ_CONTROL,

			/// <summary>
			/// The right to use the object for synchronization. This enables a thread to wait until the object is in the signaled state.
			/// </summary>
			SYNCHRONIZE = ACCESS_MASK.SYNCHRONIZE,

			/// <summary>Required to modify the DACL in the security descriptor for the object.</summary>
			WRITE_DAC = ACCESS_MASK.WRITE_DAC,

			/// <summary>Required to change the owner in the security descriptor for the object.</summary>
			WRITE_OWNER = ACCESS_MASK.WRITE_OWNER,

			/// <summary>Required to call the AssignProcessToJobObject function to assign processes to the job object.</summary>
			JOB_OBJECT_ASSIGN_PROCESS = 0x0001,

			/// <summary>
			/// Required to retrieve certain information about a job object, such as attributes and accounting information (see
			/// QueryInformationJobObject and IsProcessInJob).
			/// </summary>
			JOB_OBJECT_QUERY = 0x0004,

			/// <summary>Required to call the SetInformationJobObject function to set the attributes of the job object.</summary>
			JOB_OBJECT_SET_ATTRIBUTES = 0x0002,

			/// <summary>
			/// This flag is not supported. You must set security limitations individually for each process associated with a job
			/// object.Windows Server 2003 and Windows XP: Required to call the SetInformationJobObject function with the
			/// JobObjectSecurityLimitInformation information class to set security limitations for the processes associated with the job
			/// object. Support for this flag was removed in Windows Vista and Windows Server 2008.
			/// </summary>
			JOB_OBJECT_SET_SECURITY_ATTRIBUTES = 0x0010,

			/// <summary>Required to call the TerminateJobObject function to terminate all processes in the job object.</summary>
			JOB_OBJECT_TERMINATE = 0x0008,

			/// <summary>Undocumented.</summary>
			JOB_OBJECT_IMPERSONATE = 0x0020,

			/// <summary>Combines all valid job object access rights.</summary>
			JOB_OBJECT_ALL_ACCESS = ACCESS_MASK.STANDARD_RIGHTS_REQUIRED | ACCESS_MASK.SYNCHRONIZE | 0x3F,
		}

		/// <summary>The action that the system will perform when the end-of-job time limit has been exceeded.</summary>
		public enum JOBOBJECT_END_OF_JOB_TIME_ACTION
		{
			/// <summary>
			/// Terminates all processes and sets the exit status to ERROR_NOT_ENOUGH_QUOTA. The processes cannot prevent or delay their own
			/// termination. The job object is set to the signaled state and remains signaled until this limit is reset. No additional
			/// processes can be assigned to the job until the limit is reset. This is the default termination action.
			/// </summary>
			JOB_OBJECT_TERMINATE_AT_END_OF_JOB = 0,

			/// <summary>
			/// Posts a completion packet to the completion port using the PostQueuedCompletionStatus function. After the completion packet
			/// is posted, the system clears the end-of-job time limit, and processes in the job can continue their execution. If no
			/// completion port is associated with the job when the time limit has been exceeded, the action taken is the same as for JOB_OBJECT_TERMINATE_AT_END_OF_JOB.
			/// </summary>
			JOB_OBJECT_POST_AT_END_OF_JOB = 1
		}

		/// <summary/>
		[Flags]
		public enum JOBOBJECT_IO_ATTRIBUTION_CONTROL_FLAGS
		{
			/// <summary/>
			JOBOBJECT_IO_ATTRIBUTION_CONTROL_ENABLE = 0x1,

			/// <summary/>
			JOBOBJECT_IO_ATTRIBUTION_CONTROL_DISABLE = 0x2,

			/// <summary/>
			JOBOBJECT_IO_ATTRIBUTION_CONTROL_VALID_FLAGS = 0x3
		}

		/// <summary>Flags that identify the notification limits in effect for the job.</summary>
		[Flags]
		public enum JOBOBJECT_LIMIT_FLAGS
		{
			/// <summary>
			/// Causes all processes associated with the job to use the same minimum and maximum working set sizes. The MinimumWorkingSetSize
			/// and MaximumWorkingSetSize members contain additional information.If the job is nested, the effective working set size is the
			/// smallest working set size in the job chain.
			/// </summary>
			JOB_OBJECT_LIMIT_WORKINGSET = 0x00000001,

			/// <summary>
			/// Establishes a user-mode execution time limit for each currently active process and for all future processes associated with
			/// the job. The PerProcessUserTimeLimit member contains additional information.
			/// </summary>
			JOB_OBJECT_LIMIT_PROCESS_TIME = 0x00000002,

			/// <summary>
			/// Establishes a user-mode execution time limit for the job. The PerJobUserTimeLimit member contains additional information.
			/// This flag cannot be used with JOB_OBJECT_LIMIT_PRESERVE_JOB_TIME.
			/// </summary>
			JOB_OBJECT_LIMIT_JOB_TIME = 0x00000004,

			/// <summary>
			/// Establishes a maximum number of simultaneously active processes associated with the job. The ActiveProcessLimit member
			/// contains additional information.
			/// </summary>
			JOB_OBJECT_LIMIT_ACTIVE_PROCESS = 0x00000008,

			/// <summary>
			/// Causes all processes associated with the job to use the same processor affinity. The Affinity member contains additional
			/// information.If the job is nested, the specified processor affinity must be a subset of the effective affinity of the parent
			/// job. If the specified affinity a superset of the affinity of the parent job, it is ignored and the affinity of the parent job
			/// is used.
			/// </summary>
			JOB_OBJECT_LIMIT_AFFINITY = 0x00000010,

			/// <summary>
			/// Causes all processes associated with the job to use the same priority class. For more information, see Scheduling Priorities.
			/// The PriorityClass member contains additional information.If the job is nested, the effective priority class is the lowest
			/// priority class in the job chain.
			/// </summary>
			JOB_OBJECT_LIMIT_PRIORITY_CLASS = 0x00000020,

			/// <summary>
			/// Preserves any job time limits you previously set. As long as this flag is set, you can establish a per-job time limit once,
			/// then alter other limits in subsequent calls. This flag cannot be used with JOB_OBJECT_LIMIT_JOB_TIME.
			/// </summary>
			JOB_OBJECT_LIMIT_PRESERVE_JOB_TIME = 0x00000040,

			/// <summary>
			/// Causes all processes in the job to use the same scheduling class. The SchedulingClass member contains additional
			/// information.If the job is nested, the effective scheduling class is the lowest scheduling class in the job chain.
			/// </summary>
			JOB_OBJECT_LIMIT_SCHEDULING_CLASS = 0x00000080,

			/// <summary>
			/// Causes all processes associated with the job to limit their committed memory. When a process attempts to commit memory that
			/// would exceed the per-process limit, it fails. If the job object is associated with a completion port, a
			/// JOB_OBJECT_MSG_PROCESS_MEMORY_LIMIT message is sent to the completion port.If the job is nested, the effective memory limit
			/// is the most restrictive memory limit in the job chain.This limit requires use of a JOBOBJECT_EXTENDED_LIMIT_INFORMATION
			/// structure. Its BasicLimitInformation member is a JOBOBJECT_BASIC_LIMIT_INFORMATION structure.
			/// </summary>
			JOB_OBJECT_LIMIT_PROCESS_MEMORY = 0x00000100,

			/// <summary>
			/// Causes all processes associated with the job to limit the job-wide sum of their committed memory. When a process attempts to
			/// commit memory that would exceed the job-wide limit, it fails. If the job object is associated with a completion port, a
			/// JOB_OBJECT_MSG_JOB_MEMORY_LIMIT message is sent to the completion port.This limit requires use of a
			/// JOBOBJECT_EXTENDED_LIMIT_INFORMATION structure. Its BasicLimitInformation member is a JOBOBJECT_BASIC_LIMIT_INFORMATION
			/// structure.To register for notification when this limit is exceeded while allowing processes to continue to commit memory, use
			/// the SetInformationJobObject function with the JobObjectNotificationLimitInformation information class.
			/// </summary>
			JOB_OBJECT_LIMIT_JOB_MEMORY = 0x00000200,

			/// <summary>
			/// Forces a call to the SetErrorMode function with the SEM_NOGPFAULTERRORBOX flag for each process associated with the job. If
			/// an exception occurs and the system calls the UnhandledExceptionFilter function, the debugger will be given a chance to act.
			/// If there is no debugger, the functions returns EXCEPTION_EXECUTE_HANDLER. Normally, this will cause termination of the
			/// process with the exception code as the exit status.This limit requires use of a JOBOBJECT_EXTENDED_LIMIT_INFORMATION
			/// structure. Its BasicLimitInformation member is a JOBOBJECT_BASIC_LIMIT_INFORMATION structure.
			/// </summary>
			JOB_OBJECT_LIMIT_DIE_ON_UNHANDLED_EXCEPTION = 0x00000400,

			/// <summary>
			/// If any process associated with the job creates a child process using the CREATE_BREAKAWAY_FROM_JOB flag while this limit is
			/// in effect, the child process is not associated with the job. This limit requires use of a
			/// JOBOBJECT_EXTENDED_LIMIT_INFORMATION structure. Its BasicLimitInformation member is a JOBOBJECT_BASIC_LIMIT_INFORMATION structure.
			/// </summary>
			JOB_OBJECT_LIMIT_BREAKAWAY_OK = 0x00000800,

			/// <summary>
			/// Allows any process associated with the job to create child processes that are not associated with the job. If the job is
			/// nested and its immediate job object allows breakaway, the child process breaks away from the immediate job object and from
			/// each job in the parent job chain, moving up the hierarchy until it reaches a job that does not permit breakaway. If the
			/// immediate job object does not allow breakaway, the child process does not break away even if jobs in its parent job chain
			/// allow it.This limit requires use of a JOBOBJECT_EXTENDED_LIMIT_INFORMATION structure. Its BasicLimitInformation member is a
			/// JOBOBJECT_BASIC_LIMIT_INFORMATION structure.
			/// </summary>
			JOB_OBJECT_LIMIT_SILENT_BREAKAWAY_OK = 0x00001000,

			/// <summary>
			/// Causes all processes associated with the job to terminate when the last handle to the job is closed.This limit requires use
			/// of a JOBOBJECT_EXTENDED_LIMIT_INFORMATION structure. Its BasicLimitInformation member is a JOBOBJECT_BASIC_LIMIT_INFORMATION structure.
			/// </summary>
			JOB_OBJECT_LIMIT_KILL_ON_JOB_CLOSE = 0x00002000,

			/// <summary>
			/// Allows processes to use a subset of the processor affinity for all processes associated with the job. This value must be
			/// combined with JOB_OBJECT_LIMIT_AFFINITY. Windows Server 2008, Windows Vista, Windows Server 2003 and Windows XP: This flag is
			/// supported starting with Windows 7 and Windows Server 2008 R2.
			/// </summary>
			JOB_OBJECT_LIMIT_SUBSET_AFFINITY = 0x00004000,

			/// <summary>The job has a committed minimum memory notification limit. The JobLowMemoryLimit member contains more information.</summary>
			JOB_OBJECT_LIMIT_JOB_MEMORY_LOW = 0x00008000,

			/// <summary>The job has an I/O read bytes notification limit. The IoReadBytesLimit member contains more information.</summary>
			JOB_OBJECT_LIMIT_JOB_READ_BYTES = 0x00010000,

			/// <summary>The job has an I/O write bytes notification limit. The IoWriteBytesLimit member contains more information.</summary>
			JOB_OBJECT_LIMIT_JOB_WRITE_BYTES = 0x00020000,

			/// <summary>
			/// The job has notification limit for the extent to which a job can exceed its CPU rate control limit. The
			/// RateControlToleranceLimit member contains more information.
			/// </summary>
			JOB_OBJECT_LIMIT_RATE_CONTROL = 0x00040000,

			/// <summary>
			/// The job has notification limit for the extent to which a job can exceed its CPU rate control limit. The
			/// CpuRateControlToleranceLimit member contains more information.
			/// </summary>
			JOB_OBJECT_LIMIT_CPU_RATE_CONTROL = JOB_OBJECT_LIMIT_RATE_CONTROL,

			/// <summary>
			/// The job has notification limit for the extent to which a job can exceed its I/O rate control limit. The
			/// IoRateControlToleranceLimit member contains more information.
			/// </summary>
			JOB_OBJECT_LIMIT_IO_RATE_CONTROL = 0x00080000,

			/// <summary>
			/// The job has notification limit for the extent to which a job can exceed its network rate control limit. The
			/// NetRateControlToleranceLimit member contains more information.
			/// </summary>
			JOB_OBJECT_LIMIT_NET_RATE_CONTROL = 0x00100000,
		}

		/// <summary>
		/// Specifies the extent to which a job can exceed its CPU rate control limits during the interval specified by the
		/// <c>RateControlToleranceInterval</c> member.
		/// </summary>
		public enum JOBOBJECT_RATE_CONTROL_TOLERANCE
		{
			/// <summary>The job can exceed its CPU rate control limits for 20% of the tolerance interval.</summary>
			ToleranceLow = 1,

			/// <summary>The job can exceed its CPU rate control limits for 40% of the tolerance interval.</summary>
			ToleranceMedium,

			/// <summary>The job can exceed its CPU rate control limits for 60% of the tolerance interval.</summary>
			ToleranceHigh
		}

		/// <summary>
		/// Specifies the interval during which a job's CPU usage is monitored to determine whether the job has exceeded its CPU rate control limits.
		/// </summary>
		public enum JOBOBJECT_RATE_CONTROL_TOLERANCE_INTERVAL
		{
			/// <summary>The tolerance interval is 10 seconds.</summary>
			ToleranceIntervalShort = 1,

			/// <summary>The tolerance interval is one minute.</summary>
			ToleranceIntervalMedium,

			/// <summary>The tolerance interval is 10 minutes.</summary>
			ToleranceIntervalLong
		}

		/// <summary>The security limitations for the job.</summary>
		[Flags]
		public enum JOBOBJECT_SECURITY_FLAGS
		{
			/// <summary>Prevents any process in the job from using a token that specifies the local administrators group.</summary>
			JOB_OBJECT_SECURITY_NO_ADMIN = 0x00000001,

			/// <summary>Prevents any process in the job from using a token that was not created with the CreateRestrictedToken function.</summary>
			JOB_OBJECT_SECURITY_RESTRICTED_TOKEN = 0x00000002,

			/// <summary>Forces processes in the job to run under a specific token. Requires a token handle in the JobToken member.</summary>
			JOB_OBJECT_SECURITY_ONLY_TOKEN = 0x00000004,

			/// <summary>
			/// Applies a filter to the token when a process impersonates a client. Requires at least one of the following members to be set:
			/// SidsToDisable, PrivilegesToDelete, or RestrictedSids.
			/// </summary>
			JOB_OBJECT_SECURITY_FILTER_TOKENS = 0x00000008,
		}

		/// <summary>The restriction class for the user interface.</summary>
		[Flags]
		public enum JOBOBJECT_UILIMIT_FLAGS
		{
			/// <summary/>
			JOB_OBJECT_UILIMIT_NONE = 0x00000000,

			/// <summary>
			/// Prevents processes associated with the job from using USER handles owned by processes not associated with the same job.
			/// </summary>
			JOB_OBJECT_UILIMIT_HANDLES = 0x00000001,

			/// <summary>Prevents processes associated with the job from reading data from the clipboard.</summary>
			JOB_OBJECT_UILIMIT_READCLIPBOARD = 0x00000002,

			/// <summary>Prevents processes associated with the job from writing data to the clipboard.</summary>
			JOB_OBJECT_UILIMIT_WRITECLIPBOARD = 0x00000004,

			/// <summary>
			/// Prevents processes associated with the job from changing system parameters by using the SystemParametersInfo function.
			/// </summary>
			JOB_OBJECT_UILIMIT_SYSTEMPARAMETERS = 0x00000008,

			/// <summary>Prevents processes associated with the job from calling the ChangeDisplaySettings function.</summary>
			JOB_OBJECT_UILIMIT_DISPLAYSETTINGS = 0x00000010,

			/// <summary>
			/// Prevents processes associated with the job from accessing global atoms. When this flag is used, each job has its own atom table.
			/// </summary>
			JOB_OBJECT_UILIMIT_GLOBALATOMS = 0x00000020,

			/// <summary>
			/// Prevents processes associated with the job from creating desktops and switching desktops using the CreateDesktop and
			/// SwitchDesktop functions.
			/// </summary>
			JOB_OBJECT_UILIMIT_DESKTOP = 0x00000040,

			/// <summary>Prevents processes associated with the job from calling the ExitWindows or ExitWindowsEx function.</summary>
			JOB_OBJECT_UILIMIT_EXITWINDOWS = 0x00000080,

			/// <summary>All values.</summary>
			JOB_OBJECT_UILIMIT_ALL = 0x000000FF,
		}

		/// <summary>The information class for the limits to be queried.</summary>
		public enum JOBOBJECTINFOCLASS
		{
			/// <summary>The lpJobObjectInfo parameter is a pointer to a JOBOBJECT_BASIC_ACCOUNTING_INFORMATION structure.</summary>
			[CorrespondingType(typeof(JOBOBJECT_BASIC_ACCOUNTING_INFORMATION), CorrespondingAction.Get)]
			JobObjectBasicAccountingInformation = 1,

			/// <summary>The lpJobObjectInfo parameter is a pointer to a JOBOBJECT_BASIC_LIMIT_INFORMATION structure.</summary>
			[CorrespondingType(typeof(JOBOBJECT_BASIC_LIMIT_INFORMATION), CorrespondingAction.GetSet)]
			JobObjectBasicLimitInformation,

			/// <summary>The lpJobObjectInfo parameter is a pointer to a JOBOBJECT_BASIC_PROCESS_ID_LIST structure.</summary>
			[CorrespondingType(typeof(JOBOBJECT_BASIC_PROCESS_ID_LIST), CorrespondingAction.Get)]
			JobObjectBasicProcessIdList,

			/// <summary>The lpJobObjectInfo parameter is a pointer to a JOBOBJECT_BASIC_UI_RESTRICTIONS structure.</summary>
			[CorrespondingType(typeof(JOBOBJECT_BASIC_UI_RESTRICTIONS), CorrespondingAction.GetSet)]
			JobObjectBasicUIRestrictions,

			/// <summary>This flag is not supported. Applications must set security limits individually for each process.</summary>
			[CorrespondingType(typeof(JOBOBJECT_SECURITY_LIMIT_INFORMATION), CorrespondingAction.GetSet)]
			JobObjectSecurityLimitInformation,

			/// <summary>The lpJobObjectInfo parameter is a pointer to a JOBOBJECT_END_OF_JOB_TIME_INFORMATION structure.</summary>
			[CorrespondingType(typeof(JOBOBJECT_END_OF_JOB_TIME_INFORMATION), CorrespondingAction.GetSet)]
			JobObjectEndOfJobTimeInformation,

			/// <summary>The job object associate completion port information</summary>
			[CorrespondingType(typeof(JOBOBJECT_ASSOCIATE_COMPLETION_PORT), CorrespondingAction.Set)]
			JobObjectAssociateCompletionPortInformation,

			/// <summary>The lpJobObjectInfo parameter is a pointer to a JOBOBJECT_BASIC_AND_IO_ACCOUNTING_INFORMATION structure.</summary>
			[CorrespondingType(typeof(JOBOBJECT_BASIC_AND_IO_ACCOUNTING_INFORMATION), CorrespondingAction.Get)]
			JobObjectBasicAndIoAccountingInformation,

			/// <summary>The lpJobObjectInfo parameter is a pointer to a JOBOBJECT_EXTENDED_LIMIT_INFORMATION structure.</summary>
			[CorrespondingType(typeof(JOBOBJECT_EXTENDED_LIMIT_INFORMATION), CorrespondingAction.GetSet)]
			JobObjectExtendedLimitInformation,

			/// <summary>Undocumented.</summary>
			JobObjectJobSetInformation,

			/// <summary>
			/// The lpJobObjectInfo parameter is a pointer to a buffer that receives the list of processor groups to which the job is
			/// currently assigned. The variable pointed to by the lpReturnLength parameter is set to the size of the group data. Divide this
			/// value by sizeof(USHORT) to determine the number of groups.
			/// </summary>
			[CorrespondingType(typeof(ushort[]), CorrespondingAction.GetSet)]
			JobObjectGroupInformation,

			/// <summary>The lpJobObjectInfo parameter is a pointer to a JOBOBJECT_NOTIFICATION_LIMIT_INFORMATION structure.</summary>
			[CorrespondingType(typeof(JOBOBJECT_NOTIFICATION_LIMIT_INFORMATION), CorrespondingAction.GetSet)]
			JobObjectNotificationLimitInformation,

			/// <summary>The lpJobObjectInfo parameter is a pointer to a JOBOBJECT_LIMIT_VIOLATION_INFORMATION structure.</summary>
			[CorrespondingType(typeof(JOBOBJECT_LIMIT_VIOLATION_INFORMATION), CorrespondingAction.Get)]
			JobObjectLimitViolationInformation,

			/// <summary>
			/// The lpJobObjectInfo parameter is a pointer to a buffer that receives an array of GROUP_AFFINITY structures that indicate the
			/// affinity of the job in the processor groups to which the job is currently assigned. The variable pointed to by the
			/// lpReturnLength parameter is set to the size of the group affinity data. Divide this value by sizeof(GROUP_AFFINITY) to
			/// determine the number of groups.
			/// </summary>
			[CorrespondingType(typeof(GROUP_AFFINITY[]), CorrespondingAction.GetSet)]
			JobObjectGroupInformationEx,

			/// <summary>The lpJobObjectInfo parameter is a pointer to a JOBOBJECT_CPU_RATE_CONTROL_INFORMATION structure.</summary>
			[CorrespondingType(typeof(JOBOBJECT_CPU_RATE_CONTROL_INFORMATION), CorrespondingAction.GetSet)]
			JobObjectCpuRateControlInformation,

			/// <summary>Undocumented.</summary>
			JobObjectCompletionFilter,

			/// <summary>Undocumented.</summary>
			JobObjectCompletionCounter,

			/// <summary>Undocumented.</summary>
			JobObjectReserved1Information = 18,

			/// <summary>Undocumented.</summary>
			JobObjectReserved2Information,

			/// <summary>Undocumented.</summary>
			JobObjectReserved3Information,

			/// <summary>Undocumented.</summary>
			JobObjectReserved4Information,

			/// <summary>Undocumented.</summary>
			JobObjectReserved5Information,

			/// <summary>Undocumented.</summary>
			JobObjectReserved6Information,

			/// <summary>Undocumented.</summary>
			JobObjectReserved7Information,

			/// <summary>Undocumented.</summary>
			JobObjectReserved8Information,

			/// <summary>Undocumented.</summary>
			JobObjectReserved9Information,

			/// <summary>Undocumented.</summary>
			JobObjectReserved10Information,

			/// <summary>Undocumented.</summary>
			JobObjectReserved11Information,

			/// <summary>Undocumented.</summary>
			JobObjectReserved12Information,

			/// <summary>Undocumented.</summary>
			JobObjectReserved13Information,

			/// <summary>Undocumented.</summary>
			JobObjectReserved14Information = 31,

			/// <summary>The lpJobObjectInfo parameter is a pointer to a JOBOBJECT_NET_RATE_CONTROL_INFORMATION structure.</summary>
			[CorrespondingType(typeof(JOBOBJECT_NET_RATE_CONTROL_INFORMATION), CorrespondingAction.GetSet)]
			JobObjectNetRateControlInformation,

			/// <summary>The lpJobObjectInfo parameter is a pointer to a JOBOBJECT_NOTIFICATION_LIMIT_INFORMATION_2 structure.</summary>
			[CorrespondingType(typeof(JOBOBJECT_NOTIFICATION_LIMIT_INFORMATION_2), CorrespondingAction.GetSet)]
			JobObjectNotificationLimitInformation2,

			/// <summary>The lpJobObjectInfo parameter is a pointer to a JOBOBJECT_LIMIT_VIOLATION_INFORMATION_2 structure.</summary>
			[CorrespondingType(typeof(JOBOBJECT_LIMIT_VIOLATION_INFORMATION_2), CorrespondingAction.GetSet)]
			JobObjectLimitViolationInformation2,

			/// <summary>Undocumented.</summary>
			JobObjectCreateSilo,

			/// <summary>Undocumented.</summary>
			JobObjectSiloBasicInformation,

			/// <summary>Undocumented.</summary>
			JobObjectReserved15Information = 37,

			/// <summary>Undocumented.</summary>
			JobObjectReserved16Information = 38,

			/// <summary>Undocumented.</summary>
			JobObjectReserved17Information = 39,

			/// <summary>Undocumented.</summary>
			JobObjectReserved18Information = 40,

			/// <summary>Undocumented.</summary>
			JobObjectReserved19Information = 41,

			/// <summary>Undocumented.</summary>
			JobObjectReserved20Information = 42,

			/// <summary>Undocumented.</summary>
			JobObjectReserved21Information = 43,

			/// <summary>Undocumented.</summary>
			JobObjectReserved22Information = 44,

			/// <summary>Undocumented.</summary>
			JobObjectReserved23Information = 45,

			/// <summary>Undocumented.</summary>
			JobObjectReserved24Information = 46,

			/// <summary>Undocumented.</summary>
			JobObjectReserved25Information = 47,
		}

		/// <summary>Assigns a process to an existing job object.</summary>
		/// <param name="hJob">
		/// A handle to the job object to which the process will be associated. The <c>CreateJobObject</c> or <c>OpenJobObject</c> function
		/// returns this handle. The handle must have the JOB_OBJECT_ASSIGN_PROCESS access right. For more information, see Job Object
		/// Security and Access Rights.
		/// </param>
		/// <param name="hProcess">
		/// <para>
		/// A handle to the process to associate with the job object. The handle must have the PROCESS_SET_QUOTA and PROCESS_TERMINATE access
		/// rights. For more information, see Process Security and Access Rights.
		/// </para>
		/// <para>
		/// If the process is already associated with a job, the job specified by hJob must be empty or it must be in the hierarchy of nested
		/// jobs to which the process already belongs, and it cannot have UI limits set ( <c>SetInformationJobObject</c> with
		/// <c>JobObjectBasicUIRestrictions</c>). For more information, see Remarks.
		/// </para>
		/// <para>
		/// <c>Windows 7, Windows Server 2008 R2, Windows XP with SP3, Windows Server 2008, Windows Vista and Windows Server 2003:</c> The
		/// process must not already be assigned to a job; if it is, the function fails with ERROR_ACCESS_DENIED. This behavior changed
		/// starting in Windows 8 and Windows Server 2012.
		/// </para>
		/// <para><c>Terminal Services:</c> All processes within a job must run within the same session as the job.</para>
		/// </param>
		/// <returns>
		/// <para>If the function succeeds, the return value is nonzero.</para>
		/// <para>If the function fails, the return value is zero. To get extended error information, call <c>GetLastError</c>.</para>
		/// </returns>
		// BOOL WINAPI AssignProcessToJobObject( _In_ HANDLE hJob, _In_ HANDLE hProcess); https://msdn.microsoft.com/en-us/library/windows/desktop/ms681949(v=vs.85).aspx
		[DllImport(Lib.Kernel32, SetLastError = true, ExactSpelling = true)]
		[PInvokeData("WinBase.h", MSDNShortId = "ms681949")]
		[return: MarshalAs(UnmanagedType.Bool)]
		public static extern bool AssignProcessToJobObject([In] HJOB hJob, [In] HPROCESS hProcess);

		/// <summary>
		/// <para>Creates or opens a job object.</para>
		/// </summary>
		/// <param name="lpJobAttributes">
		/// <para>
		/// A pointer to a SECURITY_ATTRIBUTES structure that specifies the security descriptor for the job object and determines whether
		/// child processes can inherit the returned handle. If lpJobAttributes is <c>NULL</c>, the job object gets a default security
		/// descriptor and the handle cannot be inherited. The ACLs in the default security descriptor for a job object come from the primary
		/// or impersonation token of the creator.
		/// </para>
		/// </param>
		/// <param name="lpName">
		/// <para>The name of the job. The name is limited to <c>MAX_PATH</c> characters. Name comparison is case-sensitive.</para>
		/// <para>If lpName is <c>NULL</c>, the job is created without a name.</para>
		/// <para>
		/// If lpName matches the name of an existing event, semaphore, mutex, waitable timer, or file-mapping object, the function fails and
		/// the GetLastError function returns <c>ERROR_INVALID_HANDLE</c>. This occurs because these objects share the same namespace.
		/// </para>
		/// <para>The object can be created in a private namespace. For more information, see Object Namespaces.</para>
		/// <para>
		/// <c>Terminal Services:</c> The name can have a "Global" or "Local" prefix to explicitly create the object in the global or session
		/// namespace. The remainder of the name can contain any character except the backslash character (). For more information, see
		/// Kernel Object Namespaces.
		/// </para>
		/// </param>
		/// <returns>
		/// <para>
		/// If the function succeeds, the return value is a handle to the job object. The handle has the <c>JOB_OBJECT_ALL_ACCESS</c> access
		/// right. If the object existed before the function call, the function returns a handle to the existing job object and GetLastError
		/// returns <c>ERROR_ALREADY_EXISTS</c>.
		/// </para>
		/// <para>If the function fails, the return value is NULL. To get extended error information, call GetLastError.</para>
		/// </returns>
		/// <remarks>
		/// <para>
		/// When a job is created, its accounting information is initialized to zero, all limits are inactive, and there are no associated
		/// processes. To assign a process to a job object, use the AssignProcessToJobObject function. To set limits for a job, use the
		/// SetInformationJobObject function. To query accounting information, use the QueryInformationJobObject function.
		/// </para>
		/// <para>
		/// All processes associated with a job must run in the same session. A job is associated with the session of the first process to be
		/// assigned to the job.
		/// </para>
		/// <para><c>Windows Server 2003 and Windows XP:</c> A job is associated with the session of the process that created it.</para>
		/// <para>
		/// To close a job object handle, use the CloseHandle function. The job is destroyed when its last handle has been closed and all
		/// associated processes have exited. However, if the job has the <c>JOB_OBJECT_LIMIT_KILL_ON_JOB_CLOSE</c> flag specified, closing
		/// the last job object handle terminates all associated processes and then destroys the job object itself.
		/// </para>
		/// <para>
		/// To compile an application that uses this function, define <c>_WIN32_WINNT</c> as 0x0500 or later. For more information, see Using
		/// the Windows Headers.
		/// </para>
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows/desktop/api/winbase/nf-winbase-createjobobjecta HANDLE CreateJobObjectA(
		// LPSECURITY_ATTRIBUTES lpJobAttributes, LPCSTR lpName );
		[DllImport(Lib.Kernel32, SetLastError = true, CharSet = CharSet.Auto)]
		[PInvokeData("winbase.h", MSDNShortId = "ca6a044f-67ed-4a9c-9aeb-69dd77652854")]
		public static extern SafeHJOB CreateJobObject([In, Optional] SECURITY_ATTRIBUTES lpJobAttributes, [In, Optional] string lpName);

		/// <summary>
		/// Frees memory that a function related to job objects allocated. Functions related to job objects that allocate memory include <c>QueryIoRateControlInformationJobObject</c>.
		/// </summary>
		/// <param name="Buffer">A pointer to the buffer of allocated memory that you want to free.</param>
		/// <returns>This function does not return a value.</returns>
		// VOID WINAPI FreeMemoryJobObject( _In_ VOID *Buffer); https://msdn.microsoft.com/en-us/library/windows/desktop/mt280121(v=vs.85).aspx
		[DllImport(Lib.Kernel32, SetLastError = false, ExactSpelling = true)]
		[PInvokeData("Jobapi2.h", MSDNShortId = "mt280121")]
		public static extern void FreeMemoryJobObject(IntPtr Buffer);

		/// <summary>Determines whether the process is running in the specified job.</summary>
		/// <param name="ProcessHandle">
		/// <para>
		/// A handle to the process to be tested. The handle must have the PROCESS_QUERY_INFORMATION or PROCESS_QUERY_LIMITED_INFORMATION
		/// access right. For more information, see Process Security and Access Rights.
		/// </para>
		/// <para><c>Windows Server 2003 and Windows XP:</c> The handle must have the PROCESS_QUERY_INFORMATION access right.</para>
		/// </param>
		/// <param name="JobHandle">
		/// <para>A handle to the job. If this parameter is NULL, the function tests if the process is running under any job.</para>
		/// <para>
		/// If this parameter is not NULL, the handle must have the JOB_OBJECT_QUERY access right. For more information, see Job Object
		/// Security and Access Rights.
		/// </para>
		/// </param>
		/// <param name="Result">A pointer to a value that receives TRUE if the process is running in the job, and FALSE otherwise.</param>
		/// <returns>
		/// <para>If the function succeeds, the return value is nonzero.</para>
		/// <para>If the function fails, the return value is zero. To get extended error information, call <c>GetLastError</c>.</para>
		/// </returns>
		// BOOL WINAPI IsProcessInJob( _In_ HANDLE ProcessHandle, _In_opt_ HANDLE JobHandle, _Out_ PBOOL Result); https://msdn.microsoft.com/en-us/library/windows/desktop/ms684127(v=vs.85).aspx
		[DllImport(Lib.Kernel32, SetLastError = true, ExactSpelling = true)]
		[PInvokeData("WinBase.h", MSDNShortId = "ms684127")]
		[return: MarshalAs(UnmanagedType.Bool)]
		public static extern bool IsProcessInJob([In] HPROCESS ProcessHandle, [In] HJOB JobHandle, [MarshalAs(UnmanagedType.Bool)] out bool Result);

		/// <summary>Opens an existing job object.</summary>
		/// <param name="dwDesiredAccess">
		/// The access to the job object. This parameter can be one or more of the job object access rights. This access right is checked
		/// against any security descriptor for the object.
		/// </param>
		/// <param name="bInheritHandles">
		/// If this value is TRUE, processes created by this process will inherit the handle. Otherwise, the processes do not inherit this handle.
		/// </param>
		/// <param name="lpName">
		/// <para>The name of the job to be opened. Name comparisons are case sensitive.</para>
		/// <para>This function can open objects in a private namespace. For more information, see Object Namespaces.</para>
		/// <para>
		/// <c>Terminal Services:</c> The name can have a "Global\" or "Local\" prefix to explicitly open the object in the global or session
		/// namespace. The remainder of the name can contain any character except the backslash character (\). For more information, see
		/// Kernel Object Namespaces.
		/// </para>
		/// </param>
		/// <returns>
		/// <para>If the function succeeds, the return value is a handle to the job. The handle provides the requested access to the job.</para>
		/// <para>If the function fails, the return value is <c>NULL</c>. To get extended error information, call <c>GetLastError</c>.</para>
		/// </returns>
		// HANDLE WINAPI OpenJobObject( _In_ DWORD dwDesiredAccess, _In_ BOOL bInheritHandles, _In_ LPCTSTR lpName); https://msdn.microsoft.com/en-us/library/windows/desktop/ms684312(v=vs.85).aspx
		[DllImport(Lib.Kernel32, SetLastError = true, CharSet = CharSet.Auto)]
		[PInvokeData("WinBase.h", MSDNShortId = "ms684312")]
		public static extern SafeHJOB OpenJobObject(uint dwDesiredAccess, [MarshalAs(UnmanagedType.Bool)] bool bInheritHandles, string lpName);

		/// <summary>Retrieves limit and job state information from the job object.</summary>
		/// <param name="hJob">
		/// <para>
		/// A handle to the job whose information is being queried. The <c>CreateJobObject</c> or <c>OpenJobObject</c> function returns this
		/// handle. The handle must have the <c>JOB_OBJECT_QUERY</c> access right. For more information, see Job Object Security and Access Rights.
		/// </para>
		/// <para>
		/// If this value is NULL and the calling process is associated with a job, the job associated with the calling process is used. If
		/// the job is nested, the immediate job of the calling process is used.
		/// </para>
		/// </param>
		/// <param name="JobObjectInfoClass">
		/// <para>The information class for the limits to be queried. This parameter can be one of the following values.</para>
		/// <para>
		/// <list type="table">
		/// <listheader>
		/// <term>Value</term>
		/// <term>Meaning</term>
		/// </listheader>
		/// <item>
		/// <term>JobObjectBasicAccountingInformation1</term>
		/// <term>The lpJobObjectInfo parameter is a pointer to a JOBOBJECT_BASIC_ACCOUNTING_INFORMATION structure.</term>
		/// </item>
		/// <item>
		/// <term>JobObjectBasicAndIoAccountingInformation8</term>
		/// <term>The lpJobObjectInfo parameter is a pointer to a JOBOBJECT_BASIC_AND_IO_ACCOUNTING_INFORMATION structure.</term>
		/// </item>
		/// <item>
		/// <term>JobObjectBasicLimitInformation2</term>
		/// <term>The lpJobObjectInfo parameter is a pointer to a JOBOBJECT_BASIC_LIMIT_INFORMATION structure.</term>
		/// </item>
		/// <item>
		/// <term>JobObjectBasicProcessIdList3</term>
		/// <term>The lpJobObjectInfo parameter is a pointer to a JOBOBJECT_BASIC_PROCESS_ID_LIST structure.</term>
		/// </item>
		/// <item>
		/// <term>JobObjectBasicUIRestrictions4</term>
		/// <term>The lpJobObjectInfo parameter is a pointer to a JOBOBJECT_BASIC_UI_RESTRICTIONS structure.</term>
		/// </item>
		/// <item>
		/// <term>JobObjectCpuRateControlInformation15</term>
		/// <term>
		/// The lpJobObjectInfo parameter is a pointer to a JOBOBJECT_CPU_RATE_CONTROL_INFORMATION structure. Windows 7, Windows Server 2008
		/// R2, Windows Server 2008, Windows Vista, Windows Server 2003 and Windows XP: This flag is not supported.
		/// </term>
		/// </item>
		/// <item>
		/// <term>JobObjectEndOfJobTimeInformation6</term>
		/// <term>The lpJobObjectInfo parameter is a pointer to a JOBOBJECT_END_OF_JOB_TIME_INFORMATION structure.</term>
		/// </item>
		/// <item>
		/// <term>JobObjectExtendedLimitInformation9</term>
		/// <term>The lpJobObjectInfo parameter is a pointer to a JOBOBJECT_EXTENDED_LIMIT_INFORMATION structure.</term>
		/// </item>
		/// <item>
		/// <term>JobObjectGroupInformation11</term>
		/// <term>
		/// The lpJobObjectInfo parameter is a pointer to a buffer that receives the list of processor groups to which the job is currently
		/// assigned. The variable pointed to by the lpReturnLength parameter is set to the size of the group data. Divide this value by to
		/// determine the number of groups.Windows Server 2008, Windows Vista, Windows Server 2003 and Windows XP: This flag is not supported.
		/// </term>
		/// </item>
		/// <item>
		/// <term>JobObjectGroupInformationEx14</term>
		/// <term>
		/// The lpJobObjectInfo parameter is a pointer to a buffer that receives an array of GROUP_AFFINITY structures that indicate the
		/// affinity of the job in the processor groups to which the job is currently assigned. The variable pointed to by the lpReturnLength
		/// parameter is set to the size of the group affinity data. Divide this value by to determine the number of groups.Windows 7,
		/// Windows Server 2008 R2, Windows Server 2008, Windows Vista, Windows Server 2003 and Windows XP: This flag is not supported.
		/// </term>
		/// </item>
		/// <item>
		/// <term>JobObjectLimitViolationInformation13</term>
		/// <term>
		/// The lpJobObjectInfo parameter is a pointer to a JOBOBJECT_LIMIT_VIOLATION_INFORMATION structure. Windows 7, Windows Server 2008
		/// R2, Windows Server 2008, Windows Vista, Windows Server 2003 and Windows XP: This flag is not supported.
		/// </term>
		/// </item>
		/// <item>
		/// <term>JobObjectLimitViolationInformation235</term>
		/// <term>
		/// The lpJobObjectInfo parameter is a pointer to a JOBOBJECT_LIMIT_VIOLATION_INFORMATION_2 structure. Windows 8.1, Windows Server
		/// 2012 R2, Windows 8, Windows Server 2012, Windows 7, Windows Server 2008 R2, Windows Server 2008, Windows Vista, Windows Server
		/// 2003 and Windows XP: This flag is not supported.
		/// </term>
		/// </item>
		/// <item>
		/// <term>JobObjectNetRateControlInformation32</term>
		/// <term>
		/// The lpJobObjectInfo parameter is a pointer to a JOBOBJECT_NET_RATE_CONTROL_INFORMATION structure. Windows 8.1, Windows Server
		/// 2012 R2, Windows 8, Windows Server 2012, Windows 7, Windows Server 2008 R2, Windows Server 2008, Windows Vista, Windows Server
		/// 2003 and Windows XP: This flag is not supported.
		/// </term>
		/// </item>
		/// <item>
		/// <term>JobObjectNotificationLimitInformation12</term>
		/// <term>
		/// The lpJobObjectInfo parameter is a pointer to a JOBOBJECT_NOTIFICATION_LIMIT_INFORMATION structure. Windows 7, Windows Server
		/// 2008 R2, Windows Server 2008, Windows Vista, Windows Server 2003 and Windows XP: This flag is not supported.
		/// </term>
		/// </item>
		/// <item>
		/// <term>JobObjectNotificationLimitInformation234</term>
		/// <term>
		/// The lpJobObjectInfo parameter is a pointer to a JOBOBJECT_NOTIFICATION_LIMIT_INFORMATION_2 structure. Windows 8.1, Windows Server
		/// 2012 R2, Windows 8, Windows Server 2012, Windows 7, Windows Server 2008 R2, Windows Server 2008, Windows Vista, Windows Server
		/// 2003 and Windows XP: This flag is not supported.
		/// </term>
		/// </item>
		/// <item>
		/// <term>JobObjectSecurityLimitInformation5</term>
		/// <term>
		/// This flag is not supported. Applications must set security limits individually for each process. Windows Server 2003 and Windows
		/// XP: The lpJobObjectInfo parameter is a pointer to a JOBOBJECT_SECURITY_LIMIT_INFORMATION structure.
		/// </term>
		/// </item>
		/// </list>
		/// </para>
		/// </param>
		/// <param name="lpJobObjectInfo">
		/// The limit or job state information. The format of this data depends on the value of the JobObjectInfoClass parameter.
		/// </param>
		/// <param name="cbJobObjectInfoLength">
		/// The count of the job information being queried, in bytes. This value depends on the value of the JobObjectInfoClass parameter.
		/// </param>
		/// <param name="lpReturnLength">
		/// A pointer to a variable that receives the length of data written to the structure pointed to by the lpJobObjectInfo parameter.
		/// Specify <c>NULL</c> to not receive this information.
		/// </param>
		/// <returns>
		/// <para>If the function succeeds, the return value is nonzero.</para>
		/// <para>If the function fails, the return value is zero. To get extended error information, call <c>GetLastError</c>.</para>
		/// </returns>
		// BOOL WINAPI QueryInformationJobObject( _In_opt_ HANDLE hJob, _In_ JOBOBJECTINFOCLASS JobObjectInfoClass, _Out_ LPVOID
		// lpJobObjectInfo, _In_ DWORD cbJobObjectInfoLength, _Out_opt_ LPDWORD lpReturnLength); https://msdn.microsoft.com/en-us/library/windows/desktop/ms684925(v=vs.85).aspx
		[DllImport(Lib.Kernel32, SetLastError = true, ExactSpelling = true)]
		[PInvokeData("WinBase.h", MSDNShortId = "ms684925")]
		[return: MarshalAs(UnmanagedType.Bool)]
		public static extern bool QueryInformationJobObject([In] HJOB hJob, JOBOBJECTINFOCLASS JobObjectInfoClass, IntPtr lpJobObjectInfo,
			uint cbJobObjectInfoLength, out uint lpReturnLength);

		/// <summary>Retrieves limit and job state information from the job object.</summary>
		/// <param name="hJob">
		/// <para>
		/// A handle to the job whose information is being queried. The <c>CreateJobObject</c> or <c>OpenJobObject</c> function returns this
		/// handle. The handle must have the <c>JOB_OBJECT_QUERY</c> access right. For more information, see Job Object Security and Access Rights.
		/// </para>
		/// <para>
		/// If this value is NULL and the calling process is associated with a job, the job associated with the calling process is used. If
		/// the job is nested, the immediate job of the calling process is used.
		/// </para>
		/// </param>
		/// <param name="jobObjectInfoClass">
		/// <para>The information class for the limits to be queried. This parameter can be one of the following values.</para>
		/// <para>
		/// <list type="table">
		/// <listheader>
		/// <term>Value</term>
		/// <term>Meaning</term>
		/// </listheader>
		/// <item>
		/// <term>JobObjectBasicAccountingInformation1</term>
		/// <term>The lpJobObjectInfo parameter is a pointer to a JOBOBJECT_BASIC_ACCOUNTING_INFORMATION structure.</term>
		/// </item>
		/// <item>
		/// <term>JobObjectBasicAndIoAccountingInformation8</term>
		/// <term>The lpJobObjectInfo parameter is a pointer to a JOBOBJECT_BASIC_AND_IO_ACCOUNTING_INFORMATION structure.</term>
		/// </item>
		/// <item>
		/// <term>JobObjectBasicLimitInformation2</term>
		/// <term>The lpJobObjectInfo parameter is a pointer to a JOBOBJECT_BASIC_LIMIT_INFORMATION structure.</term>
		/// </item>
		/// <item>
		/// <term>JobObjectBasicProcessIdList3</term>
		/// <term>The lpJobObjectInfo parameter is a pointer to a JOBOBJECT_BASIC_PROCESS_ID_LIST structure.</term>
		/// </item>
		/// <item>
		/// <term>JobObjectBasicUIRestrictions4</term>
		/// <term>The lpJobObjectInfo parameter is a pointer to a JOBOBJECT_BASIC_UI_RESTRICTIONS structure.</term>
		/// </item>
		/// <item>
		/// <term>JobObjectCpuRateControlInformation15</term>
		/// <term>
		/// The lpJobObjectInfo parameter is a pointer to a JOBOBJECT_CPU_RATE_CONTROL_INFORMATION structure. Windows 7, Windows Server 2008
		/// R2, Windows Server 2008, Windows Vista, Windows Server 2003 and Windows XP: This flag is not supported.
		/// </term>
		/// </item>
		/// <item>
		/// <term>JobObjectEndOfJobTimeInformation6</term>
		/// <term>The lpJobObjectInfo parameter is a pointer to a JOBOBJECT_END_OF_JOB_TIME_INFORMATION structure.</term>
		/// </item>
		/// <item>
		/// <term>JobObjectExtendedLimitInformation9</term>
		/// <term>The lpJobObjectInfo parameter is a pointer to a JOBOBJECT_EXTENDED_LIMIT_INFORMATION structure.</term>
		/// </item>
		/// <item>
		/// <term>JobObjectGroupInformation11</term>
		/// <term>
		/// The lpJobObjectInfo parameter is a pointer to a buffer that receives the list of processor groups to which the job is currently
		/// assigned. The variable pointed to by the lpReturnLength parameter is set to the size of the group data. Divide this value by to
		/// determine the number of groups.Windows Server 2008, Windows Vista, Windows Server 2003 and Windows XP: This flag is not supported.
		/// </term>
		/// </item>
		/// <item>
		/// <term>JobObjectGroupInformationEx14</term>
		/// <term>
		/// The lpJobObjectInfo parameter is a pointer to a buffer that receives an array of GROUP_AFFINITY structures that indicate the
		/// affinity of the job in the processor groups to which the job is currently assigned. The variable pointed to by the lpReturnLength
		/// parameter is set to the size of the group affinity data. Divide this value by to determine the number of groups.Windows 7,
		/// Windows Server 2008 R2, Windows Server 2008, Windows Vista, Windows Server 2003 and Windows XP: This flag is not supported.
		/// </term>
		/// </item>
		/// <item>
		/// <term>JobObjectLimitViolationInformation13</term>
		/// <term>
		/// The lpJobObjectInfo parameter is a pointer to a JOBOBJECT_LIMIT_VIOLATION_INFORMATION structure. Windows 7, Windows Server 2008
		/// R2, Windows Server 2008, Windows Vista, Windows Server 2003 and Windows XP: This flag is not supported.
		/// </term>
		/// </item>
		/// <item>
		/// <term>JobObjectLimitViolationInformation235</term>
		/// <term>
		/// The lpJobObjectInfo parameter is a pointer to a JOBOBJECT_LIMIT_VIOLATION_INFORMATION_2 structure. Windows 8.1, Windows Server
		/// 2012 R2, Windows 8, Windows Server 2012, Windows 7, Windows Server 2008 R2, Windows Server 2008, Windows Vista, Windows Server
		/// 2003 and Windows XP: This flag is not supported.
		/// </term>
		/// </item>
		/// <item>
		/// <term>JobObjectNetRateControlInformation32</term>
		/// <term>
		/// The lpJobObjectInfo parameter is a pointer to a JOBOBJECT_NET_RATE_CONTROL_INFORMATION structure. Windows 8.1, Windows Server
		/// 2012 R2, Windows 8, Windows Server 2012, Windows 7, Windows Server 2008 R2, Windows Server 2008, Windows Vista, Windows Server
		/// 2003 and Windows XP: This flag is not supported.
		/// </term>
		/// </item>
		/// <item>
		/// <term>JobObjectNotificationLimitInformation12</term>
		/// <term>
		/// The lpJobObjectInfo parameter is a pointer to a JOBOBJECT_NOTIFICATION_LIMIT_INFORMATION structure. Windows 7, Windows Server
		/// 2008 R2, Windows Server 2008, Windows Vista, Windows Server 2003 and Windows XP: This flag is not supported.
		/// </term>
		/// </item>
		/// <item>
		/// <term>JobObjectNotificationLimitInformation234</term>
		/// <term>
		/// The lpJobObjectInfo parameter is a pointer to a JOBOBJECT_NOTIFICATION_LIMIT_INFORMATION_2 structure. Windows 8.1, Windows Server
		/// 2012 R2, Windows 8, Windows Server 2012, Windows 7, Windows Server 2008 R2, Windows Server 2008, Windows Vista, Windows Server
		/// 2003 and Windows XP: This flag is not supported.
		/// </term>
		/// </item>
		/// <item>
		/// <term>JobObjectSecurityLimitInformation5</term>
		/// <term>
		/// This flag is not supported. Applications must set security limits individually for each process. Windows Server 2003 and Windows
		/// XP: The lpJobObjectInfo parameter is a pointer to a JOBOBJECT_SECURITY_LIMIT_INFORMATION structure.
		/// </term>
		/// </item>
		/// </list>
		/// </para>
		/// </param>
		/// <returns>The limit or job state information. The format of this data depends on the value of the JobObjectInfoClass parameter.</returns>
		public static T QueryInformationJobObject<T>([In] HJOB hJob, JOBOBJECTINFOCLASS jobObjectInfoClass) where T : struct
		{
			if (!CorrespondingTypeAttribute.CanGet(jobObjectInfoClass, typeof(T))) throw new ArgumentException("Type mismatch.", nameof(jobObjectInfoClass));
			using (var mem = SafeHGlobalHandle.CreateFromStructure<T>())
			{
				if (!QueryInformationJobObject(hJob, jobObjectInfoClass, mem, mem.Size, out _))
					Win32Error.ThrowLastError();
				return mem.ToStructure<T>();
			}
		}

		/// <summary>Gets information about the control of the I/O rate for a job object.</summary>
		/// <param name="hJob">
		/// <para>
		/// A handle to the job to query for information. Get this handle from the <c>CreateJobObject</c> or <c>OpenJobObject</c> function.
		/// The handle must have the <c>JOB_OBJECT_QUERY</c> access right. For more information about access rights, see Job Object Security
		/// and Access Rights.
		/// </para>
		/// <para>
		/// If this value is NULL and the process that calls <c>QueryIoRateControlInformationJobObject</c> is associated with a job, the
		/// function uses job that is associated with the process. If the job is nested within another job, the function uses the immediate
		/// job for the process.
		/// </para>
		/// </param>
		/// <param name="VolumeName">
		/// The name of the volume to query. If this value is NULL, the function gets the information about I/O rate control for the job for
		/// all of the volumes for the system.
		/// </param>
		/// <param name="InfoBlocks">
		/// A pointer to array of <c>JOBOBJECT_IO_RATE_CONTROL_INFORMATION</c> structures that contain the information about I/O rate control
		/// for the job. Your code must free the memory for this array by calling the <c>FreeMemoryJobObject</c> function with the address of
		/// the array.
		/// </param>
		/// <param name="InfoBlockCount">
		/// The number of <c>JOBOBJECT_IO_RATE_CONTROL_INFORMATION</c> structures that the function allocated in the array to which the
		/// InfoBlocks parameter points.
		/// </param>
		/// <returns>
		/// <para>If the function succeeds, the return value is nonzero.</para>
		/// <para>If the function fails, the return value is zero. To get extended error information, call <c>GetLastError</c>.</para>
		/// </returns>
		// DWORD WINAPI QueryIoRateControlInformationJobObject( _In_opt_ HANDLE hJob, _In_opt_ PCWSTR VolumeName, _Out_
		// JOBOBJECT_IO_RATE_CONTROL_INFORMATION **InfoBlocks, _Out_ ULONG *InfoBlockCount); https://msdn.microsoft.com/en-us/library/windows/desktop/mt280127(v=vs.85).aspx
		[DllImport(Lib.Kernel32, SetLastError = true, ExactSpelling = true)]
		[PInvokeData("Jobapi2.h", MSDNShortId = "mt280127")]
		[return: MarshalAs(UnmanagedType.Bool)]
		public static extern bool QueryIoRateControlInformationJobObject(HJOB hJob, [MarshalAs(UnmanagedType.LPWStr)] string VolumeName, out IntPtr InfoBlocks, out uint InfoBlockCount);

		/// <summary>Gets information about the control of the I/O rate for a job object.</summary>
		/// <param name="hJob">
		/// <para>
		/// A handle to the job to query for information. Get this handle from the <c>CreateJobObject</c> or <c>OpenJobObject</c> function.
		/// The handle must have the <c>JOB_OBJECT_QUERY</c> access right. For more information about access rights, see Job Object Security
		/// and Access Rights.
		/// </para>
		/// <para>
		/// If this value is NULL and the process that calls <c>QueryIoRateControlInformationJobObject</c> is associated with a job, the
		/// function uses job that is associated with the process. If the job is nested within another job, the function uses the immediate
		/// job for the process.
		/// </para>
		/// </param>
		/// <param name="VolumeName">
		/// The name of the volume to query. If this value is NULL, the function gets the information about I/O rate control for the job for
		/// all of the volumes for the system.
		/// </param>
		/// <returns>
		/// An array of <c>JOBOBJECT_IO_RATE_CONTROL_INFORMATION</c> structures that contain the information about I/O rate control for the
		/// job. Your code must free the memory for this array by calling the <c>FreeMemoryJobObject</c> function with the address of the array.
		/// </returns>
		[PInvokeData("Jobapi2.h", MSDNShortId = "mt280127")]
		public static JOBOBJECT_IO_RATE_CONTROL_INFORMATION[] QueryIoRateControlInformationJobObject(HJOB hJob, string VolumeName = null)
		{
			var relId = int.Parse(Microsoft.Win32.Registry.GetValue(@"HKEY_LOCAL_MACHINE\SOFTWARE\Microsoft\Windows NT\CurrentVersion", "ReleaseId", "0").ToString());
			if (relId == 0 || relId >= 1607)
				throw new NotSupportedException("This function is only supported on Windows 10 releases before 1607.");
			if (!QueryIoRateControlInformationJobObject(hJob, VolumeName, out var ib, out var ibc))
				Win32Error.ThrowLastError();
			try
			{
				return ib.ToArray<JOBOBJECT_IO_RATE_CONTROL_INFORMATION>((int)ibc);
			}
			finally
			{
				FreeMemoryJobObject(ib);
			}
		}

		/// <summary>Sets limits for a job object.</summary>
		/// <param name="hJob">
		/// A handle to the job whose limits are being set. The CreateJobObject or OpenJobObject function returns this handle. The handle
		/// must have the <c>JOB_OBJECT_SET_ATTRIBUTES</c> access right. For more information, see Job Object Security and Access Rights.
		/// </param>
		/// <param name="JobObjectInformationClass">
		/// <para>The information class for the limits to be set. This parameter can be one of the following values.</para>
		/// <list type="table">
		/// <listheader>
		/// <term>Value</term>
		/// <term>Meaning</term>
		/// </listheader>
		/// <item>
		/// <term>JobObjectAssociateCompletionPortInformation 7</term>
		/// <term>The lpJobObjectInfo parameter is a pointer to a JOBOBJECT_ASSOCIATE_COMPLETION_PORT structure.</term>
		/// </item>
		/// <item>
		/// <term>JobObjectBasicLimitInformation 2</term>
		/// <term>The lpJobObjectInfo parameter is a pointer to a JOBOBJECT_BASIC_LIMIT_INFORMATION structure.</term>
		/// </item>
		/// <item>
		/// <term>JobObjectBasicUIRestrictions 4</term>
		/// <term>The lpJobObjectInfo parameter is a pointer to a JOBOBJECT_BASIC_UI_RESTRICTIONS structure.</term>
		/// </item>
		/// <item>
		/// <term>JobObjectCpuRateControlInformation 15</term>
		/// <term>
		/// The lpJobObjectInfo parameter is a pointer to a JOBOBJECT_CPU_RATE_CONTROL_INFORMATION structure. Windows 7, Windows Server 2008
		/// R2, Windows Server 2008, Windows Vista, Windows Server 2003 and Windows XP: This flag is not supported.
		/// </term>
		/// </item>
		/// <item>
		/// <term>JobObjectEndOfJobTimeInformation 6</term>
		/// <term>The lpJobObjectInfo parameter is a pointer to a JOBOBJECT_END_OF_JOB_TIME_INFORMATION structure.</term>
		/// </item>
		/// <item>
		/// <term>JobObjectExtendedLimitInformation 9</term>
		/// <term>The lpJobObjectInfo parameter is a pointer to a JOBOBJECT_EXTENDED_LIMIT_INFORMATION structure.</term>
		/// </item>
		/// <item>
		/// <term>JobObjectGroupInformation 11</term>
		/// <term>
		/// The lpJobObjectInfo parameter is a pointer to a USHORT value that specifies the list of processor groups to assign the job to.
		/// The cbJobObjectInfoLength parameter is set to the size of the group data. Divide this value by to determine the number of groups.
		/// Windows Server 2008, Windows Vista, Windows Server 2003 and Windows XP: This flag is not supported.
		/// </term>
		/// </item>
		/// <item>
		/// <term>JobObjectGroupInformationEx 14</term>
		/// <term>
		/// The lpJobObjectInfo parameter is a pointer to a buffer that contains an array of GROUP_AFFINITY structures that specify the
		/// affinity of the job for the processor groups to which the job is currently assigned. The cbJobObjectInfoLength parameter is set
		/// to the size of the group affinity data. Divide this value by to determine the number of groups. Windows 7, Windows Server 2008
		/// R2, Windows Server 2008, Windows Vista, Windows Server 2003 and Windows XP: This flag is not supported.
		/// </term>
		/// </item>
		/// <item>
		/// <term>JobObjectLimitViolationInformation2 35</term>
		/// <term>
		/// The lpJobObjectInfo parameter is a pointer to a JOBOBJECT_LIMIT_VIOLATION_INFORMATION_2 structure. Windows 8.1, Windows Server
		/// 2012 R2, Windows 8, Windows Server 2012, Windows 7, Windows Server 2008 R2, Windows Server 2008, Windows Vista, Windows Server
		/// 2003 and Windows XP: This flag is not supported.
		/// </term>
		/// </item>
		/// <item>
		/// <term>JobObjectNetRateControlInformation 32</term>
		/// <term>
		/// The lpJobObjectInfo parameter is a pointer to a JOBOBJECT_NET_RATE_CONTROL_INFORMATION structure. Windows 8.1, Windows Server
		/// 2012 R2, Windows 8, Windows Server 2012, Windows 7, Windows Server 2008 R2, Windows Server 2008, Windows Vista, Windows Server
		/// 2003 and Windows XP: This flag is not supported.
		/// </term>
		/// </item>
		/// <item>
		/// <term>JobObjectNotificationLimitInformation 12</term>
		/// <term>
		/// The lpJobObjectInfo parameter is a pointer to a JOBOBJECT_NOTIFICATION_LIMIT_INFORMATION structure. Windows 7, Windows Server
		/// 2008 R2, Windows Server 2008, Windows Vista, Windows Server 2003 and Windows XP: This flag is not supported.
		/// </term>
		/// </item>
		/// <item>
		/// <term>JobObjectNotificationLimitInformation2 34</term>
		/// <term>
		/// The lpJobObjectInfo parameter is a pointer to a JOBOBJECT_NOTIFICATION_LIMIT_INFORMATION_2 structure. Windows 8.1, Windows Server
		/// 2012 R2, Windows 8, Windows Server 2012, Windows 7, Windows Server 2008 R2, Windows Server 2008, Windows Vista, Windows Server
		/// 2003 and Windows XP: This flag is not supported.
		/// </term>
		/// </item>
		/// <item>
		/// <term>JobObjectSecurityLimitInformation 5</term>
		/// <term>
		/// This flag is not supported. Applications must set security limitations individually for each process. Windows Server 2003 and
		/// Windows XP: The lpJobObjectInfo parameter is a pointer to a JOBOBJECT_SECURITY_LIMIT_INFORMATION structure. The hJob handle must
		/// have the JOB_OBJECT_SET_SECURITY_ATTRIBUTES access right associated with it.
		/// </term>
		/// </item>
		/// </list>
		/// </param>
		/// <param name="lpJobObjectInformation">
		/// The limits or job state to be set for the job. The format of this data depends on the value of JobObjectInfoClass.
		/// </param>
		/// <param name="cbJobObjectInformationLength">The size of the job information being set, in bytes.</param>
		/// <returns>
		/// <para>If the function succeeds, the return value is nonzero.</para>
		/// <para>If the function fails, the return value is zero. To get extended error information, call GetLastError.</para>
		/// </returns>
		/// <remarks>
		/// <para>
		/// Use the <c>SetInformationJobObject</c> function to set several limits in a single call. To establish the limits one at a time or
		/// change a subset of the limits, call the QueryInformationJobObject function to obtain the current limits, modify these limits, and
		/// then call <c>SetInformationJobObject</c>.
		/// </para>
		/// <para>
		/// You must set security limits individually for each process associated with a job object, rather than setting them for the job
		/// object itself. For information, see Process Security and Access Rights.
		/// </para>
		/// <para>
		/// <c>Windows Server 2003 and Windows XP:</c> Use the <c>SetInformationJobObject</c> function to set security limits for the job object.
		/// </para>
		/// <para>
		/// To compile an application that uses this function, define _WIN32_WINNT as 0x0500 or later. For more information, see Using the
		/// Windows Headers.
		/// </para>
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows/desktop/api/jobapi2/nf-jobapi2-setinformationjobobject BOOL SetInformationJobObject(
		// HANDLE hJob, JOBOBJECTINFOCLASS JobObjectInformationClass, LPVOID lpJobObjectInformation, DWORD cbJobObjectInformationLength );
		[DllImport(Lib.Kernel32, SetLastError = true, ExactSpelling = true)]
		[PInvokeData("jobapi2.h", MSDNShortId = "46f7c579-e8d3-4434-a6ce-56573cd84387")]
		[return: MarshalAs(UnmanagedType.Bool)]
		public static extern bool SetInformationJobObject([In] HJOB hJob, JOBOBJECTINFOCLASS JobObjectInformationClass, [In] IntPtr lpJobObjectInformation, uint cbJobObjectInformationLength);

		/// <summary>Sets limits for a job object.</summary>
		/// <param name="hJob">
		/// A handle to the job whose limits are being set. The CreateJobObject or OpenJobObject function returns this handle. The handle
		/// must have the <c>JOB_OBJECT_SET_ATTRIBUTES</c> access right. For more information, see Job Object Security and Access Rights.
		/// </param>
		/// <param name="jobObjectInfoClass">
		/// <para>The information class for the limits to be set. This parameter can be one of the following values.</para>
		/// <list type="table">
		/// <listheader>
		/// <term>Value</term>
		/// <term>Meaning</term>
		/// </listheader>
		/// <item>
		/// <term>JobObjectAssociateCompletionPortInformation 7</term>
		/// <term>The lpJobObjectInfo parameter is a pointer to a JOBOBJECT_ASSOCIATE_COMPLETION_PORT structure.</term>
		/// </item>
		/// <item>
		/// <term>JobObjectBasicLimitInformation 2</term>
		/// <term>The lpJobObjectInfo parameter is a pointer to a JOBOBJECT_BASIC_LIMIT_INFORMATION structure.</term>
		/// </item>
		/// <item>
		/// <term>JobObjectBasicUIRestrictions 4</term>
		/// <term>The lpJobObjectInfo parameter is a pointer to a JOBOBJECT_BASIC_UI_RESTRICTIONS structure.</term>
		/// </item>
		/// <item>
		/// <term>JobObjectCpuRateControlInformation 15</term>
		/// <term>
		/// The lpJobObjectInfo parameter is a pointer to a JOBOBJECT_CPU_RATE_CONTROL_INFORMATION structure. Windows 7, Windows Server 2008
		/// R2, Windows Server 2008, Windows Vista, Windows Server 2003 and Windows XP: This flag is not supported.
		/// </term>
		/// </item>
		/// <item>
		/// <term>JobObjectEndOfJobTimeInformation 6</term>
		/// <term>The lpJobObjectInfo parameter is a pointer to a JOBOBJECT_END_OF_JOB_TIME_INFORMATION structure.</term>
		/// </item>
		/// <item>
		/// <term>JobObjectExtendedLimitInformation 9</term>
		/// <term>The lpJobObjectInfo parameter is a pointer to a JOBOBJECT_EXTENDED_LIMIT_INFORMATION structure.</term>
		/// </item>
		/// <item>
		/// <term>JobObjectGroupInformation 11</term>
		/// <term>
		/// The lpJobObjectInfo parameter is a pointer to a USHORT value that specifies the list of processor groups to assign the job to.
		/// The cbJobObjectInfoLength parameter is set to the size of the group data. Divide this value by to determine the number of groups.
		/// Windows Server 2008, Windows Vista, Windows Server 2003 and Windows XP: This flag is not supported.
		/// </term>
		/// </item>
		/// <item>
		/// <term>JobObjectGroupInformationEx 14</term>
		/// <term>
		/// The lpJobObjectInfo parameter is a pointer to a buffer that contains an array of GROUP_AFFINITY structures that specify the
		/// affinity of the job for the processor groups to which the job is currently assigned. The cbJobObjectInfoLength parameter is set
		/// to the size of the group affinity data. Divide this value by to determine the number of groups. Windows 7, Windows Server 2008
		/// R2, Windows Server 2008, Windows Vista, Windows Server 2003 and Windows XP: This flag is not supported.
		/// </term>
		/// </item>
		/// <item>
		/// <term>JobObjectLimitViolationInformation2 35</term>
		/// <term>
		/// The lpJobObjectInfo parameter is a pointer to a JOBOBJECT_LIMIT_VIOLATION_INFORMATION_2 structure. Windows 8.1, Windows Server
		/// 2012 R2, Windows 8, Windows Server 2012, Windows 7, Windows Server 2008 R2, Windows Server 2008, Windows Vista, Windows Server
		/// 2003 and Windows XP: This flag is not supported.
		/// </term>
		/// </item>
		/// <item>
		/// <term>JobObjectNetRateControlInformation 32</term>
		/// <term>
		/// The lpJobObjectInfo parameter is a pointer to a JOBOBJECT_NET_RATE_CONTROL_INFORMATION structure. Windows 8.1, Windows Server
		/// 2012 R2, Windows 8, Windows Server 2012, Windows 7, Windows Server 2008 R2, Windows Server 2008, Windows Vista, Windows Server
		/// 2003 and Windows XP: This flag is not supported.
		/// </term>
		/// </item>
		/// <item>
		/// <term>JobObjectNotificationLimitInformation 12</term>
		/// <term>
		/// The lpJobObjectInfo parameter is a pointer to a JOBOBJECT_NOTIFICATION_LIMIT_INFORMATION structure. Windows 7, Windows Server
		/// 2008 R2, Windows Server 2008, Windows Vista, Windows Server 2003 and Windows XP: This flag is not supported.
		/// </term>
		/// </item>
		/// <item>
		/// <term>JobObjectNotificationLimitInformation2 34</term>
		/// <term>
		/// The lpJobObjectInfo parameter is a pointer to a JOBOBJECT_NOTIFICATION_LIMIT_INFORMATION_2 structure. Windows 8.1, Windows Server
		/// 2012 R2, Windows 8, Windows Server 2012, Windows 7, Windows Server 2008 R2, Windows Server 2008, Windows Vista, Windows Server
		/// 2003 and Windows XP: This flag is not supported.
		/// </term>
		/// </item>
		/// <item>
		/// <term>JobObjectSecurityLimitInformation 5</term>
		/// <term>
		/// This flag is not supported. Applications must set security limitations individually for each process. Windows Server 2003 and
		/// Windows XP: The lpJobObjectInfo parameter is a pointer to a JOBOBJECT_SECURITY_LIMIT_INFORMATION structure. The hJob handle must
		/// have the JOB_OBJECT_SET_SECURITY_ATTRIBUTES access right associated with it.
		/// </term>
		/// </item>
		/// </list>
		/// </param>
		/// <param name="jobObjectInfo">
		/// The limits or job state to be set for the job. The format of this data depends on the value of JobObjectInfoClass.
		/// </param>
		[PInvokeData("jobapi2.h", MSDNShortId = "46f7c579-e8d3-4434-a6ce-56573cd84387")]
		public static void SetInformationJobObject<T>([In] HJOB hJob, JOBOBJECTINFOCLASS jobObjectInfoClass, in T jobObjectInfo) where T : struct
		{
			if (!CorrespondingTypeAttribute.CanSet(jobObjectInfoClass, typeof(T))) throw new ArgumentException("Type mismatch.", nameof(jobObjectInfoClass));
			using (var mem = SafeHGlobalHandle.CreateFromStructure(jobObjectInfo))
				if (!SetInformationJobObject(hJob, jobObjectInfoClass, mem, mem.Size))
					Win32Error.ThrowLastError();
		}

		/// <summary>Sets I/O limits on a job object.</summary>
		/// <param name="hJob">
		/// A handle to the job on which to set I/O limits. Get this handle from the <c>CreateJobObject</c> or <c>OpenJobObject</c> function.
		/// The handle must have the <c>JOB_OBJECT_SET_ATTRIBUTES</c> access right. For more information about access rights, see Job Object
		/// Security and Access Rights.
		/// </param>
		/// <param name="IoRateControlInfo">
		/// A pointer to a <c>JOBOBJECT_IO_RATE_CONTROL_INFORMATION</c> structure that specifies the I/O limits to set for the job.
		/// </param>
		/// <returns>
		/// <para>If the function succeeds, the return value is nonzero.</para>
		/// <para>If the function fails, the return value is zero. To get extended error information, call <c>GetLastError</c>.</para>
		/// </returns>
		// DWORD WINAPI SetIoRateControlInformationJobObject( _In_ HANDLE hJob, _In_ JOBOBJECT_IO_RATE_CONTROL_INFORMATION
		// *IoRateControlInfo); https://msdn.microsoft.com/en-us/library/windows/desktop/mt280128(v=vs.85).aspx
		[DllImport(Lib.Kernel32, SetLastError = true, ExactSpelling = true)]
		[PInvokeData("Jobapi2.h", MSDNShortId = "mt280128")]
		[return: MarshalAs(UnmanagedType.Bool)]
		public static extern bool SetIoRateControlInformationJobObject(HJOB hJob, in JOBOBJECT_IO_RATE_CONTROL_INFORMATION IoRateControlInfo);

		/// <summary>
		/// Terminates all processes currently associated with the job. If the job is nested, this function terminates all processes
		/// currently associated with the job and all of its child jobs in the hierarchy.
		/// </summary>
		/// <param name="hJob">
		/// <para>
		/// A handle to the job whose processes will be terminated. The <c>CreateJobObject</c> or <c>OpenJobObject</c> function returns this
		/// handle. This handle must have the JOB_OBJECT_TERMINATE access right. For more information, see Job Object Security and Access Rights.
		/// </para>
		/// <para>
		/// The handle for each process in the job object must have the PROCESS_TERMINATE access right. For more information, see Process
		/// Security and Access Rights.
		/// </para>
		/// </param>
		/// <param name="uExitCode">
		/// The exit code to be used by all processes and threads in the job object. Use the <c>GetExitCodeProcess</c> function to retrieve
		/// each process's exit value. Use the <c>GetExitCodeThread</c> function to retrieve each thread's exit value.
		/// </param>
		/// <returns>
		/// <para>If the function succeeds, the return value is nonzero.</para>
		/// <para>If the function fails, the return value is zero. To get extended error information, call <c>GetLastError</c>.</para>
		/// </returns>
		// BOOL WINAPI TerminateJobObject( _In_ HANDLE hJob, _In_ UINT uExitCode); https://msdn.microsoft.com/en-us/library/windows/desktop/ms686709(v=vs.85).aspx
		[DllImport(Lib.Kernel32, SetLastError = true, ExactSpelling = true)]
		[PInvokeData("WinBase.h", MSDNShortId = "ms686709")]
		[return: MarshalAs(UnmanagedType.Bool)]
		public static extern bool TerminateJobObject([In] HJOB hJob, uint uExitCode);

		/// <summary>Provides a handle to a job object.</summary>
		[StructLayout(LayoutKind.Sequential)]
		public struct HJOB : ISyncHandle
		{
			private readonly IntPtr handle;

			/// <summary>Initializes a new instance of the <see cref="HJOB"/> struct.</summary>
			/// <param name="preexistingHandle">An <see cref="IntPtr"/> object that represents the pre-existing handle to use.</param>
			public HJOB(IntPtr preexistingHandle) => handle = preexistingHandle;

			/// <summary>Returns an invalid handle by instantiating a <see cref="HJOB"/> object with <see cref="IntPtr.Zero"/>.</summary>
			public static HJOB NULL => new HJOB(IntPtr.Zero);

			/// <summary>Gets a value indicating whether this instance is a null handle.</summary>
			public bool IsNull => handle == IntPtr.Zero;

			/// <summary>Performs an explicit conversion from <see cref="HJOB"/> to <see cref="IntPtr"/>.</summary>
			/// <param name="h">The handle.</param>
			/// <returns>The result of the conversion.</returns>
			public static explicit operator IntPtr(HJOB h) => h.handle;

			/// <summary>Performs an implicit conversion from <see cref="IntPtr"/> to <see cref="HJOB"/>.</summary>
			/// <param name="h">The pointer to a handle.</param>
			/// <returns>The result of the conversion.</returns>
			public static implicit operator HJOB(IntPtr h) => new HJOB(h);

			/// <summary>Implements the operator !=.</summary>
			/// <param name="h1">The first handle.</param>
			/// <param name="h2">The second handle.</param>
			/// <returns>The result of the operator.</returns>
			public static bool operator !=(HJOB h1, HJOB h2) => !(h1 == h2);

			/// <summary>Implements the operator ==.</summary>
			/// <param name="h1">The first handle.</param>
			/// <param name="h2">The second handle.</param>
			/// <returns>The result of the operator.</returns>
			public static bool operator ==(HJOB h1, HJOB h2) => h1.Equals(h2);

			/// <inheritdoc/>
			public override bool Equals(object obj) => obj is HJOB h ? handle == h.handle : false;

			/// <inheritdoc/>
			public override int GetHashCode() => handle.GetHashCode();

			/// <inheritdoc/>
			public IntPtr DangerousGetHandle() => handle;
		}

		/// <summary>
		/// Contains I/O accounting information for a process or a job object. For a job object, the counters include all operations
		/// performed by all processes that have ever been associated with the job, in addition to all processes currently associated with
		/// the job.
		/// </summary>
		// typedef struct _IO_COUNTERS { ULONGLONG ReadOperationCount; ULONGLONG WriteOperationCount; ULONGLONG OtherOperationCount;
		// ULONGLONG ReadTransferCount; ULONGLONG WriteTransferCount; ULONGLONG OtherTransferCount;} IO_COUNTERS, *PIO_COUNTERS; https://msdn.microsoft.com/en-us/library/windows/desktop/ms684125(v=vs.85).aspx
		[PInvokeData("WinNT.h", MSDNShortId = "ms684125")]
		[StructLayout(LayoutKind.Sequential)]
		public struct IO_COUNTERS
		{
			/// <summary>The number of read operations performed.</summary>
			public ulong ReadOperationCount;

			/// <summary>The number of write operations performed.</summary>
			public ulong WriteOperationCount;

			/// <summary>The number of I/O operations performed, other than read and write operations.</summary>
			public ulong OtherOperationCount;

			/// <summary>The number of bytes read.</summary>
			public ulong ReadTransferCount;

			/// <summary>The number of bytes written.</summary>
			public ulong WriteTransferCount;

			/// <summary>The number of bytes transferred during operations other than read and write operations.</summary>
			public ulong OtherTransferCount;
		}

		/// <summary>
		/// Contains information used to associate a completion port with a job. You can associate one completion port with a job.
		/// </summary>
		[PInvokeData("WinNT.h", MSDNShortId = "ms684141")]
		[StructLayout(LayoutKind.Sequential)]
		public struct JOBOBJECT_ASSOCIATE_COMPLETION_PORT
		{
			/// <summary>
			/// The value to use in the dwCompletionKey parameter of PostQueuedCompletionStatus when messages are sent on behalf of the job.
			/// </summary>
			public UIntPtr CompletionKey;

			/// <summary>
			/// The completion port to use in the CompletionPort parameter of the PostQueuedCompletionStatus function when messages are sent
			/// on behalf of the job.
			/// <para>
			/// Windows 8, Windows Server 2012, Windows 8.1, Windows Server 2012 R2, Windows 10 and Windows Server 2016: Specify NULL to
			/// remove the association between the current completion port and the job.
			/// </para>
			/// </summary>
			public HANDLE CompletionPort;
		}

		/// <summary>Contains basic accounting information for a job object.</summary>
		// typedef struct _JOBOBJECT_BASIC_ACCOUNTING_INFORMATION { LARGE_INTEGER TotalUserTime; LARGE_INTEGER TotalKernelTime; LARGE_INTEGER
		// ThisPeriodTotalUserTime; LARGE_INTEGER ThisPeriodTotalKernelTime; DWORD TotalPageFaultCount; DWORD TotalProcesses; DWORD
		// ActiveProcesses; DWORD TotalTerminatedProcesses;} JOBOBJECT_BASIC_ACCOUNTING_INFORMATION,
		// *PJOBOBJECT_BASIC_ACCOUNTING_INFORMATION; https://msdn.microsoft.com/en-us/library/windows/desktop/ms684143(v=vs.85).aspx
		[PInvokeData("WinNT.h", MSDNShortId = "ms684143")]
		[StructLayout(LayoutKind.Sequential)]
		public struct JOBOBJECT_BASIC_ACCOUNTING_INFORMATION
		{
			/// <summary>
			/// The total amount of user-mode execution time for all active processes associated with the job, as well as all terminated
			/// processes no longer associated with the job, in 100-nanosecond ticks.
			/// </summary>
			public TimeSpan TotalUserTime;

			/// <summary>
			/// The total amount of kernel-mode execution time for all active processes associated with the job, as well as all terminated
			/// processes no longer associated with the job, in 100-nanosecond ticks.
			/// </summary>
			public TimeSpan TotalKernelTime;

			/// <summary>
			/// <para>
			/// The total amount of user-mode execution time for all active processes associated with the job (as well as all terminated
			/// processes no longer associated with the job) since the last call that set a per-job user-mode time limit, in 100-nanosecond ticks.
			/// </para>
			/// <para>This member is set to 0 on creation of the job, and each time a per-job user-mode time limit is established.</para>
			/// </summary>
			public TimeSpan ThisPeriodTotalUserTime;

			/// <summary>
			/// <para>
			/// The total amount of kernel-mode execution time for all active processes associated with the job (as well as all terminated
			/// processes no longer associated with the job) since the last call that set a per-job kernel-mode time limit, in 100-nanosecond ticks.
			/// </para>
			/// <para>This member is set to zero on creation of the job, and each time a per-job kernel-mode time limit is established.</para>
			/// </summary>
			public TimeSpan ThisPeriodTotalKernelTime;

			/// <summary>
			/// The total number of page faults encountered by all active processes associated with the job, as well as all terminated
			/// processes no longer associated with the job.
			/// </summary>
			public uint TotalPageFaultCount;

			/// <summary>
			/// The total number of processes associated with the job during its lifetime, including those that have terminated. For example,
			/// when a process is associated with a job, but the association fails because of a limit violation, this value is incremented.
			/// </summary>
			public uint TotalProcesses;

			/// <summary>
			/// The total number of processes currently associated with the job. When a process is associated with a job, but the association
			/// fails because of a limit violation, this value is temporarily incremented. When the terminated process exits and all
			/// references to the process are released, this value is decremented.
			/// </summary>
			public uint ActiveProcesses;

			/// <summary>The total number of processes terminated because of a limit violation.</summary>
			public uint TotalTerminatedProcesses;
		}

		/// <summary>Contains basic accounting and I/O accounting information for a job object.</summary>
		// typedef struct JOBOBJECT_BASIC_AND_IO_ACCOUNTING_INFORMATION { JOBOBJECT_BASIC_ACCOUNTING_INFORMATION BasicInfo; IO_COUNTERS
		// IoInfo;} JOBOBJECT_BASIC_AND_IO_ACCOUNTING_INFORMATION, *PJOBOBJECT_BASIC_AND_IO_ACCOUNTING_INFORMATION; https://msdn.microsoft.com/en-us/library/windows/desktop/ms684144(v=vs.85).aspx
		[PInvokeData("WinNT.h", MSDNShortId = "ms684144")]
		[StructLayout(LayoutKind.Sequential)]
		public struct JOBOBJECT_BASIC_AND_IO_ACCOUNTING_INFORMATION
		{
			/// <summary>
			/// A <c>JOBOBJECT_BASIC_ACCOUNTING_INFORMATION</c> structure that specifies the basic accounting information for the job.
			/// </summary>
			public JOBOBJECT_BASIC_ACCOUNTING_INFORMATION BasicInfo;

			/// <summary>
			/// An <c>IO_COUNTERS</c> structure that specifies the I/O accounting information for the job. The structure includes information
			/// for all processes that have ever been associated with the job, in addition to the information for all processes currently
			/// associated with the job.
			/// </summary>
			public IO_COUNTERS IoInfo;
		}

		/// <summary>Contains basic limit information for a job object.</summary>
		// typedef struct _JOBOBJECT_BASIC_LIMIT_INFORMATION { LARGE_INTEGER PerProcessUserTimeLimit; LARGE_INTEGER PerJobUserTimeLimit;
		// DWORD LimitFlags; SIZE_T MinimumWorkingSetSize; SIZE_T MaximumWorkingSetSize; DWORD ActiveProcessLimit; ULONG_PTR Affinity; DWORD
		// PriorityClass; DWORD SchedulingClass;} JOBOBJECT_BASIC_LIMIT_INFORMATION, *PJOBOBJECT_BASIC_LIMIT_INFORMATION; https://msdn.microsoft.com/en-us/library/windows/desktop/ms684147(v=vs.85).aspx
		[PInvokeData("WinNT.h", MSDNShortId = "ms684147")]
		[StructLayout(LayoutKind.Sequential)]
		public struct JOBOBJECT_BASIC_LIMIT_INFORMATION
		{
			/// <summary>
			/// <para>
			/// If <c>LimitFlags</c> specifies <c>JOB_OBJECT_LIMIT_PROCESS_TIME</c>, this member is the per-process user-mode execution time
			/// limit, in 100-nanosecond ticks. Otherwise, this member is ignored.
			/// </para>
			/// <para>
			/// The system periodically checks to determine whether each process associated with the job has accumulated more user-mode time
			/// than the set limit. If it has, the process is terminated.
			/// </para>
			/// <para>If the job is nested, the effective limit is the most restrictive limit in the job chain.</para>
			/// </summary>
			public TimeSpan PerProcessUserTimeLimit;

			/// <summary>
			/// <para>
			/// If <c>LimitFlags</c> specifies <c>JOB_OBJECT_LIMIT_JOB_TIME</c>, this member is the per-job user-mode execution time limit,
			/// in 100-nanosecond ticks. Otherwise, this member is ignored.
			/// </para>
			/// <para>
			/// The system adds the current time of the processes associated with the job to this limit. For example, if you set this limit
			/// to 1 minute, and the job has a process that has accumulated 5 minutes of user-mode time, the limit actually enforced is 6 minutes.
			/// </para>
			/// <para>
			/// The system periodically checks to determine whether the sum of the user-mode execution time for all processes is greater than
			/// this end-of-job limit. If it is, the action specified in the <c>EndOfJobTimeAction</c> member of the
			/// <c>JOBOBJECT_END_OF_JOB_TIME_INFORMATION</c> structure is carried out. By default, all processes are terminated and the
			/// status code is set to <c>ERROR_NOT_ENOUGH_QUOTA</c>.
			/// </para>
			/// <para>
			/// To register for notification when this limit is exceeded without terminating processes, use the
			/// <c>SetInformationJobObject</c> function with the <c>JobObjectNotificationLimitInformation</c> information class.
			/// </para>
			/// </summary>
			public TimeSpan PerJobUserTimeLimit;

			/// <summary>
			/// <para>
			/// The limit flags that are in effect. This member is a bitfield that determines whether other structure members are used. Any
			/// combination of the following values can be specified.
			/// </para>
			/// <para>
			/// <list type="table">
			/// <listheader>
			/// <term>Value</term>
			/// <term>Meaning</term>
			/// </listheader>
			/// <item>
			/// <term>JOB_OBJECT_LIMIT_ACTIVE_PROCESS0x00000008</term>
			/// <term>
			/// Establishes a maximum number of simultaneously active processes associated with the job. The ActiveProcessLimit member
			/// contains additional information.
			/// </term>
			/// </item>
			/// <item>
			/// <term>JOB_OBJECT_LIMIT_AFFINITY0x00000010</term>
			/// <term>
			/// Causes all processes associated with the job to use the same processor affinity. The Affinity member contains additional
			/// information.If the job is nested, the specified processor affinity must be a subset of the effective affinity of the parent
			/// job. If the specified affinity a superset of the affinity of the parent job, it is ignored and the affinity of the parent job
			/// is used.
			/// </term>
			/// </item>
			/// <item>
			/// <term>JOB_OBJECT_LIMIT_BREAKAWAY_OK0x00000800</term>
			/// <term>
			/// If any process associated with the job creates a child process using the CREATE_BREAKAWAY_FROM_JOB flag while this limit is
			/// in effect, the child process is not associated with the job. This limit requires use of a
			/// JOBOBJECT_EXTENDED_LIMIT_INFORMATION structure. Its BasicLimitInformation member is a JOBOBJECT_BASIC_LIMIT_INFORMATION structure.
			/// </term>
			/// </item>
			/// <item>
			/// <term>JOB_OBJECT_LIMIT_DIE_ON_UNHANDLED_EXCEPTION0x00000400</term>
			/// <term>
			/// Forces a call to the SetErrorMode function with the SEM_NOGPFAULTERRORBOX flag for each process associated with the job. If
			/// an exception occurs and the system calls the UnhandledExceptionFilter function, the debugger will be given a chance to act.
			/// If there is no debugger, the functions returns EXCEPTION_EXECUTE_HANDLER. Normally, this will cause termination of the
			/// process with the exception code as the exit status. This limit requires use of a JOBOBJECT_EXTENDED_LIMIT_INFORMATION
			/// structure. Its BasicLimitInformation member is a JOBOBJECT_BASIC_LIMIT_INFORMATION structure.
			/// </term>
			/// </item>
			/// <item>
			/// <term>JOB_OBJECT_LIMIT_JOB_MEMORY0x00000200</term>
			/// <term>
			/// Causes all processes associated with the job to limit the job-wide sum of their committed memory. When a process attempts to
			/// commit memory that would exceed the job-wide limit, it fails. If the job object is associated with a completion port, a
			/// JOB_OBJECT_MSG_JOB_MEMORY_LIMIT message is sent to the completion port. This limit requires use of a
			/// JOBOBJECT_EXTENDED_LIMIT_INFORMATION structure. Its BasicLimitInformation member is a JOBOBJECT_BASIC_LIMIT_INFORMATION
			/// structure. To register for notification when this limit is exceeded while allowing processes to continue to commit memory,
			/// use the SetInformationJobObject function with the JobObjectNotificationLimitInformation information class.
			/// </term>
			/// </item>
			/// <item>
			/// <term>JOB_OBJECT_LIMIT_JOB_TIME0x00000004</term>
			/// <term>
			/// Establishes a user-mode execution time limit for the job. The PerJobUserTimeLimit member contains additional information.
			/// This flag cannot be used with JOB_OBJECT_LIMIT_PRESERVE_JOB_TIME.
			/// </term>
			/// </item>
			/// <item>
			/// <term>JOB_OBJECT_LIMIT_KILL_ON_JOB_CLOSE0x00002000</term>
			/// <term>
			/// Causes all processes associated with the job to terminate when the last handle to the job is closed.This limit requires use
			/// of a JOBOBJECT_EXTENDED_LIMIT_INFORMATION structure. Its BasicLimitInformation member is a JOBOBJECT_BASIC_LIMIT_INFORMATION structure.
			/// </term>
			/// </item>
			/// <item>
			/// <term>JOB_OBJECT_LIMIT_PRESERVE_JOB_TIME0x00000040</term>
			/// <term>
			/// Preserves any job time limits you previously set. As long as this flag is set, you can establish a per-job time limit once,
			/// then alter other limits in subsequent calls. This flag cannot be used with JOB_OBJECT_LIMIT_JOB_TIME.
			/// </term>
			/// </item>
			/// <item>
			/// <term>JOB_OBJECT_LIMIT_PRIORITY_CLASS0x00000020</term>
			/// <term>
			/// Causes all processes associated with the job to use the same priority class. For more information, see Scheduling Priorities.
			/// The PriorityClass member contains additional information.If the job is nested, the effective priority class is the lowest
			/// priority class in the job chain.
			/// </term>
			/// </item>
			/// <item>
			/// <term>JOB_OBJECT_LIMIT_PROCESS_MEMORY0x00000100</term>
			/// <term>
			/// Causes all processes associated with the job to limit their committed memory. When a process attempts to commit memory that
			/// would exceed the per-process limit, it fails. If the job object is associated with a completion port, a
			/// JOB_OBJECT_MSG_PROCESS_MEMORY_LIMIT message is sent to the completion port.If the job is nested, the effective memory limit
			/// is the most restrictive memory limit in the job chain.This limit requires use of a JOBOBJECT_EXTENDED_LIMIT_INFORMATION
			/// structure. Its BasicLimitInformation member is a JOBOBJECT_BASIC_LIMIT_INFORMATION structure.
			/// </term>
			/// </item>
			/// <item>
			/// <term>JOB_OBJECT_LIMIT_PROCESS_TIME0x00000002</term>
			/// <term>
			/// Establishes a user-mode execution time limit for each currently active process and for all future processes associated with
			/// the job. The PerProcessUserTimeLimit member contains additional information.
			/// </term>
			/// </item>
			/// <item>
			/// <term>JOB_OBJECT_LIMIT_SCHEDULING_CLASS0x00000080</term>
			/// <term>
			/// Causes all processes in the job to use the same scheduling class. The SchedulingClass member contains additional
			/// information.If the job is nested, the effective scheduling class is the lowest scheduling class in the job chain.
			/// </term>
			/// </item>
			/// <item>
			/// <term>JOB_OBJECT_LIMIT_SILENT_BREAKAWAY_OK0x00001000</term>
			/// <term>
			/// Allows any process associated with the job to create child processes that are not associated with the job. If the job is
			/// nested and its immediate job object allows breakaway, the child process breaks away from the immediate job object and from
			/// each job in the parent job chain, moving up the hierarchy until it reaches a job that does not permit breakaway. If the
			/// immediate job object does not allow breakaway, the child process does not break away even if jobs in its parent job chain
			/// allow it.This limit requires use of a JOBOBJECT_EXTENDED_LIMIT_INFORMATION structure. Its BasicLimitInformation member is a
			/// JOBOBJECT_BASIC_LIMIT_INFORMATION structure.
			/// </term>
			/// </item>
			/// <item>
			/// <term>JOB_OBJECT_LIMIT_SUBSET_AFFINITY0x00004000</term>
			/// <term>
			/// Allows processes to use a subset of the processor affinity for all processes associated with the job. This value must be
			/// combined with JOB_OBJECT_LIMIT_AFFINITY. Windows Server 2008, Windows Vista, Windows Server 2003 and Windows XP: This flag is
			/// supported starting with Windows 7 and Windows Server 2008 R2.
			/// </term>
			/// </item>
			/// <item>
			/// <term>JOB_OBJECT_LIMIT_WORKINGSET0x00000001</term>
			/// <term>
			/// Causes all processes associated with the job to use the same minimum and maximum working set sizes. The MinimumWorkingSetSize
			/// and MaximumWorkingSetSize members contain additional information.If the job is nested, the effective working set size is the
			/// smallest working set size in the job chain.
			/// </term>
			/// </item>
			/// </list>
			/// </para>
			/// </summary>
			public JOBOBJECT_LIMIT_FLAGS LimitFlags;

			/// <summary>
			/// <para>
			/// If <c>LimitFlags</c> specifies <c>JOB_OBJECT_LIMIT_WORKINGSET</c>, this member is the minimum working set size in bytes for
			/// each process associated with the job. Otherwise, this member is ignored.
			/// </para>
			/// <para>If <c>MaximumWorkingSetSize</c> is nonzero, <c>MinimumWorkingSetSize</c> cannot be zero.</para>
			/// </summary>
			public SizeT MinimumWorkingSetSize;

			/// <summary>
			/// <para>
			/// If <c>LimitFlags</c> specifies <c>JOB_OBJECT_LIMIT_WORKINGSET</c>, this member is the maximum working set size in bytes for
			/// each process associated with the job. Otherwise, this member is ignored.
			/// </para>
			/// <para>If <c>MinimumWorkingSetSize</c> is nonzero, <c>MaximumWorkingSetSize</c> cannot be zero.</para>
			/// </summary>
			public SizeT MaximumWorkingSetSize;

			/// <summary>
			/// <para>
			/// If <c>LimitFlags</c> specifies <c>JOB_OBJECT_LIMIT_ACTIVE_PROCESS</c>, this member is the active process limit for the job.
			/// Otherwise, this member is ignored.
			/// </para>
			/// <para>
			/// If you try to associate a process with a job, and this causes the active process count to exceed this limit, the process is
			/// terminated and the association fails.
			/// </para>
			/// </summary>
			public uint ActiveProcessLimit;

			/// <summary>
			/// <para>
			/// If <c>LimitFlags</c> specifies <c>JOB_OBJECT_LIMIT_AFFINITY</c>, this member is the processor affinity for all processes
			/// associated with the job. Otherwise, this member is ignored.
			/// </para>
			/// <para>
			/// The affinity must be a subset of the system affinity mask obtained by calling the <c>GetProcessAffinityMask</c> function. The
			/// affinity of each thread is set to this value, but threads are free to subsequently set their affinity, as long as it is a
			/// subset of the specified affinity mask. Processes cannot set their own affinity mask.
			/// </para>
			/// </summary>
			public UIntPtr Affinity;

			/// <summary>
			/// <para>
			/// If <c>LimitFlags</c> specifies <c>JOB_OBJECT_LIMIT_PRIORITY_CLASS</c>, this member is the priority class for all processes
			/// associated with the job. Otherwise, this member is ignored.
			/// </para>
			/// <para>
			/// Processes and threads cannot modify their priority class. The calling process must enable the
			/// <c>SE_INC_BASE_PRIORITY_NAME</c> privilege.
			/// </para>
			/// </summary>
			public uint PriorityClass;

			/// <summary>
			/// <para>
			/// If <c>LimitFlags</c> specifies <c>JOB_OBJECT_LIMIT_SCHEDULING_CLASS</c>, this member is the scheduling class for all
			/// processes associated with the job. Otherwise, this member is ignored.
			/// </para>
			/// <para>
			/// The valid values are 0 to 9. Use 0 for the least favorable scheduling class relative to other threads, and 9 for the most
			/// favorable scheduling class relative to other threads. By default, this value is 5. To use a scheduling class greater than 5,
			/// the calling process must enable the <c>SE_INC_BASE_PRIORITY_NAME</c> privilege.
			/// </para>
			/// </summary>
			public uint SchedulingClass;
		}

		/// <summary>
		/// Contains the process identifier list for a job object. If the job is nested, the process identifier list consists of all
		/// processes associated with the job and its child jobs.
		/// </summary>
		// typedef struct _JOBOBJECT_BASIC_PROCESS_ID_LIST { DWORD NumberOfAssignedProcesses; DWORD NumberOfProcessIdsInList; ULONG_PTR
		// ProcessIdList[1];} JOBOBJECT_BASIC_PROCESS_ID_LIST, *PJOBOBJECT_BASIC_PROCESS_ID_LIST; https://msdn.microsoft.com/en-us/library/windows/desktop/ms684150(v=vs.85).aspx
		[PInvokeData("WinNT.h", MSDNShortId = "ms684150")]
		[StructLayout(LayoutKind.Sequential)]
		public struct JOBOBJECT_BASIC_PROCESS_ID_LIST
		{
			/// <summary>The number of process identifiers to be stored in <c>ProcessIdList</c>.</summary>
			public uint NumberOfAssignedProcesses;

			/// <summary>
			/// The number of process identifiers returned in the <c>ProcessIdList</c> buffer. If this number is less than
			/// <c>NumberOfAssignedProcesses</c>, increase the size of the buffer to accommodate the complete list.
			/// </summary>
			public uint NumberOfProcessIdsInList;

			/// <summary>
			/// A variable-length array of process identifiers returned by this call. Array elements 0 through
			/// <c>NumberOfProcessIdsInList</c> – 1 contain valid process identifiers.
			/// </summary>
			public IntPtr ProcessIdList;
		}

		/// <summary>Contains basic user-interface restrictions for a job object.</summary>
		// typedef struct _JOBOBJECT_BASIC_UI_RESTRICTIONS { DWORD UIRestrictionsClass;} JOBOBJECT_BASIC_UI_RESTRICTIONS,
		// *PJOBOBJECT_BASIC_UI_RESTRICTIONS; https://msdn.microsoft.com/en-us/library/windows/desktop/ms684152(v=vs.85).aspx
		[PInvokeData("WinNT.h", MSDNShortId = "ms684152")]
		[StructLayout(LayoutKind.Sequential)]
		public struct JOBOBJECT_BASIC_UI_RESTRICTIONS
		{
			/// <summary>
			/// <para>The restriction class for the user interface. This member can be one or more of the following values.</para>
			/// <para>
			/// <list type="table">
			/// <listheader>
			/// <term>Value</term>
			/// <term>Meaning</term>
			/// </listheader>
			/// <item>
			/// <term>JOB_OBJECT_UILIMIT_DESKTOP0x00000040</term>
			/// <term>
			/// Prevents processes associated with the job from creating desktops and switching desktops using the CreateDesktop and
			/// SwitchDesktop functions.
			/// </term>
			/// </item>
			/// <item>
			/// <term>JOB_OBJECT_UILIMIT_DISPLAYSETTINGS0x00000010</term>
			/// <term>Prevents processes associated with the job from calling the ChangeDisplaySettings function.</term>
			/// </item>
			/// <item>
			/// <term>JOB_OBJECT_UILIMIT_EXITWINDOWS0x00000080</term>
			/// <term>Prevents processes associated with the job from calling the ExitWindows or ExitWindowsEx function.</term>
			/// </item>
			/// <item>
			/// <term>JOB_OBJECT_UILIMIT_GLOBALATOMS0x00000020</term>
			/// <term>
			/// Prevents processes associated with the job from accessing global atoms. When this flag is used, each job has its own atom table.
			/// </term>
			/// </item>
			/// <item>
			/// <term>JOB_OBJECT_UILIMIT_HANDLES0x00000001</term>
			/// <term>
			/// Prevents processes associated with the job from using USER handles owned by processes not associated with the same job.
			/// </term>
			/// </item>
			/// <item>
			/// <term>JOB_OBJECT_UILIMIT_READCLIPBOARD0x00000002</term>
			/// <term>Prevents processes associated with the job from reading data from the clipboard.</term>
			/// </item>
			/// <item>
			/// <term>JOB_OBJECT_UILIMIT_SYSTEMPARAMETERS0x00000008</term>
			/// <term>Prevents processes associated with the job from changing system parameters by using the SystemParametersInfo function.</term>
			/// </item>
			/// <item>
			/// <term>JOB_OBJECT_UILIMIT_WRITECLIPBOARD0x00000004</term>
			/// <term>Prevents processes associated with the job from writing data to the clipboard.</term>
			/// </item>
			/// </list>
			/// </para>
			/// </summary>
			public JOBOBJECT_UILIMIT_FLAGS UIRestrictionsClass;
		}

		/// <summary>
		/// Contains CPU rate control information for a job object. This structure is used by the SetInformationJobObject and
		/// QueryInformationJobObject functions with the <c>JobObjectCpuRateControlInformation</c> information class.
		/// </summary>
		/// <remarks>
		/// <para>
		/// You can set CPU rate control for multiple jobs in a hierarchy of nested jobs. When you set CPU rate control for a job object, the
		/// settings apply to the job and its child jobs in the hierarchy. When you set CPU rate control for a job in a nested hierarchy, the
		/// system calculates the corresponding quotas with respect to the CPU rate control of the immediate parent job for the job. In other
		/// words, the rates set for the job represent its portion of the CPU rate that is allocated to its parent job. If a job object does
		/// not have a parent with CPU rate control turned on in the chain of its parent jobs, the rate control for the job represents the
		/// portion of the CPU for the entire system.
		/// </para>
		/// <para>
		/// CPU rate control cannot be used by job objects in applications running under Remote Desktop Services (formerly Terminal Services)
		/// if Dynamic Fair Share Scheduling (DFSS) is in effect.
		/// </para>
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows/win32/api/winnt/ns-winnt-jobobject_cpu_rate_control_information typedef struct
		// _JOBOBJECT_CPU_RATE_CONTROL_INFORMATION { DWORD ControlFlags; union { DWORD CpuRate; DWORD Weight; struct { WORD MinRate; WORD
		// MaxRate; } DUMMYSTRUCTNAME; } DUMMYUNIONNAME; } JOBOBJECT_CPU_RATE_CONTROL_INFORMATION, *PJOBOBJECT_CPU_RATE_CONTROL_INFORMATION;
		[PInvokeData("winnt.h", MSDNShortId = "eaa5bda2-a37e-441b-a0e4-e00dff6425b2")]
		[StructLayout(LayoutKind.Sequential)]
		public struct JOBOBJECT_CPU_RATE_CONTROL_INFORMATION
		{
			/// <summary>
			/// <para>The scheduling policy for CPU rate control. This member can be one of the following values.</para>
			/// <list type="table">
			/// <listheader>
			/// <term>Value</term>
			/// <term>Meaning</term>
			/// </listheader>
			/// <item>
			/// <term>JOB_OBJECT_CPU_RATE_CONTROL_ENABLE 0x1</term>
			/// <term>
			/// This flag enables the job's CPU rate to be controlled based on weight or hard cap. You must set this value if you also set
			/// JOB_OBJECT_CPU_RATE_CONTROL_WEIGHT_BASED, JOB_OBJECT_CPU_RATE_CONTROL_HARD_CAP, or JOB_OBJECT_CPU_RATE_CONTROL_MIN_MAX_RATE.
			/// </term>
			/// </item>
			/// <item>
			/// <term>JOB_OBJECT_CPU_RATE_CONTROL_WEIGHT_BASED 0x2</term>
			/// <term>
			/// The job's CPU rate is calculated based on its relative weight to the weight of other jobs. If this flag is set, the Weight
			/// member contains more information. If this flag is clear, the CpuRate member contains more information. If you set
			/// JOB_OBJECT_CPU_RATE_CONTROL_WEIGHT_BASED, you cannot also set JOB_OBJECT_CPU_RATE_CONTROL_MIN_MAX_RATE.
			/// </term>
			/// </item>
			/// <item>
			/// <term>JOB_OBJECT_CPU_RATE_CONTROL_HARD_CAP 0x4</term>
			/// <term>
			/// The job's CPU rate is a hard limit. After the job reaches its CPU cycle limit for the current scheduling interval, no threads
			/// associated with the job will run until the next interval. If you set JOB_OBJECT_CPU_RATE_CONTROL_HARD_CAP, you cannot also
			/// set JOB_OBJECT_CPU_RATE_CONTROL_MIN_MAX_RATE.
			/// </term>
			/// </item>
			/// <item>
			/// <term>JOB_OBJECT_CPU_RATE_CONTROL_NOTIFY 0x8</term>
			/// <term>Sends messages when the CPU rate for the job exceeds the rate limits for the job during the tolerance interval.</term>
			/// </item>
			/// <item>
			/// <term>JOB_OBJECT_ CPU_RATE_CONTROL_MIN_MAX_RATE 0x10</term>
			/// <term>
			/// The CPU rate for the job is limited by minimum and maximum rates that you specify in the MinRate and MaxRate members. If you
			/// set JOB_OBJECT_CPU_RATE_CONTROL_MIN_MAX_RATE, you can set neither JOB_OBJECT_CPU_RATE_CONTROL_WEIGHT_BASED nor JOB_OBJECT_CPU_RATE_CONTROL_HARD_CAP.
			/// </term>
			/// </item>
			/// </list>
			/// </summary>
			public JOB_OBJECT_CPU_RATE_CONTROL_FLAGS ControlFlags;

			/// <summary>Value based on which ControlFlags value is set.</summary>
			public CPU_RATE_CONTROL_UNION Union;

			/// <summary>Value based on which ControlFlags value is set.</summary>
			[StructLayout(LayoutKind.Explicit)]
			public struct CPU_RATE_CONTROL_UNION
			{
				/// <summary>
				/// <para>
				/// Specifies the portion of processor cycles that the threads in a job object can use during each scheduling interval, as
				/// the number of cycles per 10,000 cycles. If the <c>ControlFlags</c> member specifies
				/// <c>JOB_OBJECT_CPU_RATE_WEIGHT_BASED</c> or <c>JOB_OBJECT_CPU_RATE_CONTROL_MIN_MAX_RATE</c>, this member is not used.
				/// </para>
				/// <para>
				/// Set <c>CpuRate</c> to a percentage times 100. For example, to let the job use 20% of the CPU, set <c>CpuRate</c> to 20
				/// times 100, or 2,000.
				/// </para>
				/// <para>Do not set <c>CpuRate</c> to 0. If <c>CpuRate</c> is 0, SetInformationJobObject returns <c>INVALID_ARGS</c>.</para>
				/// </summary>
				[FieldOffset(0)]
				public uint CpuRate;

				/// <summary>
				/// <para>
				/// If the <c>ControlFlags</c> member specifies <c>JOB_OBJECT_CPU_RATE_WEIGHT_BASED</c>, this member specifies the scheduling
				/// weight of the job object, which determines the share of processor time given to the job relative to other workloads on
				/// the processor.
				/// </para>
				/// <para>
				/// This member can be a value from 1 through 9, where 1 is the smallest share and 9 is the largest share. The default is 5,
				/// which should be used for most workloads.
				/// </para>
				/// <para>
				/// If the <c>ControlFlags</c> member specifies <c>JOB_OBJECT_CPU_RATE_CONTROL_MIN_MAX_RATE</c>, this member is not used.
				/// </para>
				/// </summary>
				[FieldOffset(0)]
				public uint Weight;

				/// <summary>
				/// <para>
				/// Specifies the minimum portion of the processor cycles that the threads in a job object can reserve during each scheduling
				/// interval. Specify this rate as a percentage times 100. For example, to set a minimum rate of 50%, specify 50 times 100,
				/// or 5,000.
				/// </para>
				/// <para>
				/// For the minimum rates to work correctly, the sum of the minimum rates for all of the job objects in the system cannot
				/// exceed 10,000, which is the equivalent of 100%.
				/// </para>
				/// </summary>
				[FieldOffset(0)]
				public ushort MinRate;

				/// <summary>
				/// <para>
				/// Specifies the maximum portion of processor cycles that the threads in a job object can use during each scheduling
				/// interval. Specify this rate as a percentage times 100. For example, to set a maximum rate of 50%, specify 50 times 100,
				/// or 5,000.
				/// </para>
				/// <para>
				/// After the job reaches this limit for a scheduling interval, no threads associated with the job can run until the next
				/// scheduling interval.
				/// </para>
				/// </summary>
				[FieldOffset(2)]
				public ushort MaxRate;
			}
		}

		/// <summary>Specifies the action the system will perform when an end-of-job time limit is exceeded.</summary>
		// typedef struct _JOBOBJECT_END_OF_JOB_TIME_INFORMATION { DWORD EndOfJobTimeAction;} JOBOBJECT_END_OF_JOB_TIME_INFORMATION,
		// PJOBOBJECT_END_OF_JOB_TIME_INFORMATION; https://msdn.microsoft.com/en-us/library/windows/desktop/ms684155(v=vs.85).aspx
		[PInvokeData("WinNT.h", MSDNShortId = "ms684155")]
		[StructLayout(LayoutKind.Sequential)]
		public struct JOBOBJECT_END_OF_JOB_TIME_INFORMATION
		{
			/// <summary>
			/// <para>
			/// The action that the system will perform when the end-of-job time limit has been exceeded. This member can be one of the
			/// following values.
			/// </para>
			/// <para>
			/// <list type="table">
			/// <listheader>
			/// <term>Value</term>
			/// <term>Meaning</term>
			/// </listheader>
			/// <item>
			/// <term>JOB_OBJECT_TERMINATE_AT_END_OF_JOB0</term>
			/// <term>
			/// Terminates all processes and sets the exit status to ERROR_NOT_ENOUGH_QUOTA. The processes cannot prevent or delay their own
			/// termination. The job object is set to the signaled state and remains signaled until this limit is reset. No additional
			/// processes can be assigned to the job until the limit is reset. This is the default termination action.
			/// </term>
			/// </item>
			/// <item>
			/// <term>JOB_OBJECT_POST_AT_END_OF_JOB1</term>
			/// <term>
			/// Posts a completion packet to the completion port using the PostQueuedCompletionStatus function. After the completion packet
			/// is posted, the system clears the end-of-job time limit, and processes in the job can continue their execution. If no
			/// completion port is associated with the job when the time limit has been exceeded, the action taken is the same as for JOB_OBJECT_TERMINATE_AT_END_OF_JOB.
			/// </term>
			/// </item>
			/// </list>
			/// </para>
			/// </summary>
			public JOBOBJECT_END_OF_JOB_TIME_ACTION EndOfJobTimeAction;
		}

		/// <summary>Contains basic and extended limit information for a job object.</summary>
		// typedef struct _JOBOBJECT_EXTENDED_LIMIT_INFORMATION { JOBOBJECT_BASIC_LIMIT_INFORMATION BasicLimitInformation; IO_COUNTERS
		// IoInfo; SIZE_T ProcessMemoryLimit; SIZE_T JobMemoryLimit; SIZE_T PeakProcessMemoryUsed; SIZE_T PeakJobMemoryUsed;}
		// JOBOBJECT_EXTENDED_LIMIT_INFORMATION, *PJOBOBJECT_EXTENDED_LIMIT_INFORMATION; https://msdn.microsoft.com/en-us/library/windows/desktop/ms684156(v=vs.85).aspx
		[PInvokeData("WinNT.h", MSDNShortId = "ms684156")]
		[StructLayout(LayoutKind.Sequential)]
		public struct JOBOBJECT_EXTENDED_LIMIT_INFORMATION
		{
			/// <summary>A <c>JOBOBJECT_BASIC_LIMIT_INFORMATION</c> structure that contains basic limit information.</summary>
			public JOBOBJECT_BASIC_LIMIT_INFORMATION BasicLimitInformation;

			/// <summary>Reserved.</summary>
			public IO_COUNTERS IoInfo;

			/// <summary>
			/// If the <c>LimitFlags</c> member of the <c>JOBOBJECT_BASIC_LIMIT_INFORMATION</c> structure specifies the
			/// <c>JOB_OBJECT_LIMIT_PROCESS_MEMORY</c> value, this member specifies the limit for the virtual memory that can be committed by
			/// a process. Otherwise, this member is ignored.
			/// </summary>
			public SizeT ProcessMemoryLimit;

			/// <summary>
			/// If the <c>LimitFlags</c> member of the <c>JOBOBJECT_BASIC_LIMIT_INFORMATION</c> structure specifies the
			/// <c>JOB_OBJECT_LIMIT_JOB_MEMORY</c> value, this member specifies the limit for the virtual memory that can be committed for
			/// the job. Otherwise, this member is ignored.
			/// </summary>
			public SizeT JobMemoryLimit;

			/// <summary>The peak memory used by any process ever associated with the job.</summary>
			public SizeT PeakProcessMemoryUsed;

			/// <summary>The peak memory usage of all processes currently associated with the job.</summary>
			public SizeT PeakJobMemoryUsed;
		}

		/// <summary/>
		[PInvokeData("WinNT.h")]
		[StructLayout(LayoutKind.Sequential)]
		public struct JOBOBJECT_IO_ATTRIBUTION_INFORMATION
		{
			/// <summary/>
			public uint ControlFlags;

			/// <summary/>
			public JOBOBJECT_IO_ATTRIBUTION_STATS ReadStats;

			/// <summary/>
			public JOBOBJECT_IO_ATTRIBUTION_STATS WriteStats;
		}

		/// <summary/>
		[PInvokeData("WinNT.h")]
		[StructLayout(LayoutKind.Sequential)]
		public struct JOBOBJECT_IO_ATTRIBUTION_STATS
		{
			/// <summary/>
			public UIntPtr IoCount;

			/// <summary/>
			public ulong TotalNonOverlappedQueueTime;

			/// <summary/>
			public ulong TotalNonOverlappedServiceTime;

			/// <summary/>
			public ulong TotalSize;
		}

		/// <summary>
		/// Contains information used to control the I/O rate for a job. This structure is used by the
		/// <c>SetIoRateControlInformationJobObject</c> and <c>QueryIoRateControlInformationJobObject</c> functions.
		/// </summary>
		// typedef struct JOBOBJECT_IO_RATE_CONTROL_INFORMATION { LONG64 MaxIops; LONG64 MaxBandwith; LONG64 ReservationIops; PWSTR
		// VolumeName; ULONG BaseIoSize; ULONG ControlFlags;} JOBOBJECT_IO_RATE_CONTROL_INFORMATION; https://msdn.microsoft.com/en-us/library/windows/desktop/mt280122(v=vs.85).aspx
		[StructLayout(LayoutKind.Sequential, CharSet = CharSet.Unicode)]
		[PInvokeData("Jobapi2.h", MSDNShortId = "mt280122")]
		public struct JOBOBJECT_IO_RATE_CONTROL_INFORMATION
		{
			/// <summary>
			/// <para>The maximum limit for the I/O rate in I/O operations per second (IOPS). Set to 0 if to specify no limit.</para>
			/// <para>
			/// When you set both <c>MaxIops</c> and <c>MaxBandwith</c>, the operating system enforces the first limit that the I/O rate reaches.
			/// </para>
			/// </summary>
			public long MaxIops;

			/// <summary>
			/// <para>The maximum limit for the I/O rate in bytes per second. Set to 0 to specify no limit.</para>
			/// <para>
			/// When you set both <c>MaxBandwith</c> and <c>MaxIops</c>, the operating system enforces the first limit that the I/O rate reaches.
			/// </para>
			/// </summary>
			public long MaxBandwidth;

			/// <summary>
			/// <para>
			/// Sets a minimum I/O rate which the operating system reserves for the job. To make no reservation for the job, set this value
			/// to 0.
			/// </para>
			/// <para>
			/// The operating system allows the job to perform I/O operations at this rate, if possible. If the sum of the minimum rates for
			/// all jobs exceeds the capacity of the operating system, the rate at which the operating system allows each job to perform I/O
			/// operations is proportional to the reservation for the job.
			/// </para>
			/// </summary>
			public long ReservationIops;

			/// <summary>
			/// <para>
			/// The NT device name for the volume to which you want to apply the policy for the I/O rate. For information about NT device
			/// names, see NT Device Names.
			/// </para>
			/// <para>
			/// If this member is <c>NULL</c>, the policy for the I/O rate applies to all of the volumes for the operating system. For
			/// example, if this member is <c>NULL</c> and the <c>MaxIops</c> member is 100, the maximum limit for the I/O rate for each
			/// volume is set to 100 IOPS, instead of setting an aggregate limit for the I/O rate across all volumes of 100 IOPS.
			/// </para>
			/// </summary>
			[MarshalAs(UnmanagedType.LPWStr)]
			public string VolumeName;

			/// <summary>
			/// <para>
			/// The base size of the normalized I/O unit, in bytes. For example, if the <c>BaseIoSize</c> member is 8,000, every 8,000 bytes
			/// counts as one I/O unit. 4,000 bytes is also one I/O unit in this example, while 8,001 bytes is two I/O units.
			/// </para>
			/// <para>You can set the value of this base I/O size by using the <c>StorageBaseIOSize</c> value of the</para>
			/// <para><c>HKEY_LOCAL_MACHINE</c>\ <c>SYSTEM</c>\ <c>CurrentControlSet</c>\ <c>Control</c>\ <c>QoS</c></para>
			/// <para>The value of the <c>BaseIoSize</c> member is subject to the following constraints:</para>
			/// <para>
			/// To query for the base size of the normalized I/O unit without creating a job, call
			/// <c>QueryIoRateControlInformationJobObject</c> with the hJob parameter set to <c>NULL</c> from a process that is not
			/// associated with a job.
			/// </para>
			/// </summary>
			public int BaseIoSize;

			/// <summary>
			/// <para>The policy for control of the I/O rate. This member can be one of the following values.</para>
			/// <para>
			/// <list type="table">
			/// <listheader>
			/// <term>Value</term>
			/// <term>Meaning</term>
			/// </listheader>
			/// <item>
			/// <term>JOB_OBJECT_IO_RATE_CONTROL_ENABLE0x1</term>
			/// <term>
			/// Turns on control of the I/O rate for the job when this structure is passed to the SetIoRateControlInformationJobObject
			/// function. Indicates that control of the I/O rate for the job is turned on when this structure is used with the
			/// QueryIoRateControlInformationJobObject function.
			/// </term>
			/// </item>
			/// </list>
			/// </para>
			/// </summary>
			public JOB_OBJECT_IO_RATE_CONTROL_FLAGS ControlFlags;
		}

		/// <summary/>
		[PInvokeData("WinNT.h")]
		[StructLayout(LayoutKind.Sequential, CharSet = CharSet.Unicode)]
		public struct JOBOBJECT_IO_RATE_CONTROL_INFORMATION_NATIVE
		{
			/// <summary/>
			public long MaxIops;

			/// <summary/>
			public long MaxBandwidth;

			/// <summary/>
			public long ReservationIops;

			/// <summary/>
			[MarshalAs(UnmanagedType.LPWStr)]
			public string VolumeName;

			/// <summary/>
			public uint BaseIoSize;

			/// <summary/>
			public JOB_OBJECT_IO_RATE_CONTROL_FLAGS ControlFlags;

			/// <summary/>
			public ushort VolumeNameLength;
		}

		/// <summary/>
		[PInvokeData("WinNT.h")]
		[StructLayout(LayoutKind.Sequential, CharSet = CharSet.Unicode)]
		public struct JOBOBJECT_IO_RATE_CONTROL_INFORMATION_NATIVE_V2
		{
			/// <summary/>
			public long MaxIops;

			/// <summary/>
			public long MaxBandwidth;

			/// <summary/>
			public long ReservationIops;

			/// <summary/>
			public string VolumeName;

			/// <summary/>
			public uint BaseIoSize;

			/// <summary/>
			public JOB_OBJECT_IO_RATE_CONTROL_FLAGS ControlFlags;

			/// <summary/>
			public ushort VolumeNameLength;

			/// <summary/>
			public long CriticalReservationIops;

			/// <summary/>
			public long ReservationBandwidth;

			/// <summary/>
			public long CriticalReservationBandwidth;

			/// <summary/>
			public long MaxTimePercent;

			/// <summary/>
			public long ReservationTimePercent;

			/// <summary/>
			public long CriticalReservationTimePercent;
		}

		/// <summary/>
		[PInvokeData("WinNT.h")]
		[StructLayout(LayoutKind.Sequential, CharSet = CharSet.Unicode)]
		public struct JOBOBJECT_IO_RATE_CONTROL_INFORMATION_NATIVE_V3
		{
			/// <summary/>
			public long MaxIops;

			/// <summary/>
			public long MaxBandwidth;

			/// <summary/>
			public long ReservationIops;

			/// <summary/>
			public string VolumeName;

			/// <summary/>
			public uint BaseIoSize;

			/// <summary/>
			public JOB_OBJECT_IO_RATE_CONTROL_FLAGS ControlFlags;

			/// <summary/>
			public ushort VolumeNameLength;

			/// <summary/>
			public long CriticalReservationIops;

			/// <summary/>
			public long ReservationBandwidth;

			/// <summary/>
			public long CriticalReservationBandwidth;

			/// <summary/>
			public long MaxTimePercent;

			/// <summary/>
			public long ReservationTimePercent;

			/// <summary/>
			public long CriticalReservationTimePercent;

			/// <summary/>
			public long SoftMaxIops;

			/// <summary/>
			public long SoftMaxBandwidth;

			/// <summary/>
			public long SoftMaxTimePercent;

			/// <summary/>
			public long LimitExcessNotifyIops;

			/// <summary/>
			public long LimitExcessNotifyBandwidth;

			/// <summary/>
			public long LimitExcessNotifyTimePercent;
		}

		/// <summary>Undocumented.</summary>
		[StructLayout(LayoutKind.Sequential)]
		public struct JOBOBJECT_JOBSET_INFORMATION
		{
			/// <summary>Undocumented.</summary>
			public uint MemberLevel;
		}

		/// <summary>
		/// Contains information about resource notification limits that have been exceeded for a job object. This structure is used with the
		/// <c>QueryInformationJobObject</c> function with the <c>JobObjectLimitViolationInformation</c> information class.
		/// </summary>
		// typedef struct _JOBOBJECT_LIMIT_VIOLATION_INFORMATION { DWORD LimitFlags; DWORD ViolationLimitFlags; DWORD64 IoReadBytes; DWORD64
		// IoReadBytesLimit; DWORD64 IoWriteBytes; DWORD64 IoWriteBytesLimit; LARGE_INTEGER PerJobUserTime; LARGE_INTEGER
		// PerJobUserTimeLimit; DWORD64 JobMemory; DWORD64 JobMemoryLimit; JOBOBJECT_RATE_CONTROL_TOLERANCE RateControlTolerance;
		// JOBOBJECT_RATE_CONTROL_TOLERANCE RateControlToleranceLimit;} JOBOBJECT_LIMIT_VIOLATION_INFORMATION,
		// *PJOBOBJECT_LIMIT_VIOLATION_INFORMATION; https://msdn.microsoft.com/en-us/library/windows/desktop/hh448385(v=vs.85).aspx
		[PInvokeData("WinNT.h", MSDNShortId = "hh448385")]
		[StructLayout(LayoutKind.Sequential)]
		public struct JOBOBJECT_LIMIT_VIOLATION_INFORMATION
		{
			/// <summary>
			/// <para>
			/// Flags that identify the notification limits in effect for the job. This member is a bitfield that determines whether other
			/// structure members are used. This member can be any combination of the following values.
			/// </para>
			/// <para>
			/// <list type="table">
			/// <listheader>
			/// <term>Value</term>
			/// <term>Meaning</term>
			/// </listheader>
			/// <item>
			/// <term>JOB_OBJECT_LIMIT_JOB_MEMORY0x00000200</term>
			/// <term>The job has a committed memory notification limit. The JobMemoryLimit member contains more information.</term>
			/// </item>
			/// <item>
			/// <term>JOB_OBJECT_LIMIT_JOB_READ_BYTES0x00010000</term>
			/// <term>The job has an I/O read bytes notification limit. The IoReadBytesLimit member contains more information.</term>
			/// </item>
			/// <item>
			/// <term>JOB_OBJECT_LIMIT_JOB_TIME0x00000004</term>
			/// <term>The job has a user-mode execution time notification limit. The PerJobUserTimeLimit member contains more information.</term>
			/// </item>
			/// <item>
			/// <term>JOB_OBJECT_LIMIT_JOB_WRITE_BYTES0x00020000</term>
			/// <term>The job has an I/O write bytes notification limit. The IoWriteBytesLimit member contains more information.</term>
			/// </item>
			/// <item>
			/// <term>JOB_OBJECT_LIMIT_RATE_CONTROL0x00040000</term>
			/// <term>
			/// The extent to which a job can exceed its CPU rate control limit. The RateControlToleranceLimit member contains more information.
			/// </term>
			/// </item>
			/// </list>
			/// </para>
			/// </summary>
			public JOBOBJECT_LIMIT_FLAGS LimitFlags;

			/// <summary>
			/// <para>
			/// Flags that identify the notification limits that have been exceeded. This member is a bitfield that determines whether other
			/// structure members are used. This member can be any combination of the following values.
			/// </para>
			/// <para>
			/// <list type="table">
			/// <listheader>
			/// <term>Value</term>
			/// <term>Meaning</term>
			/// </listheader>
			/// <item>
			/// <term>JOB_OBJECT_LIMIT_READ_BYTES0x00010000</term>
			/// <term>The job's I/O read bytes notification limit has been exceeded. The IoReadBytes member contains more information.</term>
			/// </item>
			/// <item>
			/// <term>JOB_OBJECT_LIMIT_WRITE_BYTES0x00020000</term>
			/// <term>The job's I/O write bytes notification limit has been exceeded. The IoWriteBytes member contains more information.</term>
			/// </item>
			/// <item>
			/// <term>JOB_OBJECT_LIMIT_JOB_TIME0x00000004</term>
			/// <term>The job's user-mode execution time notification limit has been exceeded. The PerJobUserTime member contains more information.</term>
			/// </item>
			/// <item>
			/// <term>JOB_OBJECT_LIMIT_JOB_MEMORY0x00000200</term>
			/// <term>The job's committed memory notification limit has been exceeded. The JobMemory member contains more information.</term>
			/// </item>
			/// <item>
			/// <term>JOB_OBJECT_LIMIT_RATE_CONTROL0x00040000</term>
			/// <term>The job's CPU rate control limit has been exceeded. The RateControlTolerance member contains more information.</term>
			/// </item>
			/// </list>
			/// </para>
			/// </summary>
			public JOBOBJECT_LIMIT_FLAGS ViolationLimitFlags;

			/// <summary>
			/// If the ViolationLimitFlags member specifies JOB_OBJECT_LIMIT_READ_BYTES, this member contains the total I/O read bytes for
			/// all processes in the job at the time the notification was sent.
			/// </summary>
			public ulong IoReadBytes;

			/// <summary>
			/// If the LimitFlags member specifies JOB_OBJECT_LIMIT_READ_BYTES, this member contains the I/O read bytes notification limit in
			/// effect for the job.
			/// </summary>
			public ulong IoReadBytesLimit;

			/// <summary>
			/// If the ViolationLimitFlags member specifies JOB_OBJECT_LIMIT_WRITE_BYTES, this member contains the total I/O write bytes for
			/// all processes in the job at the time the notification was sent.
			/// </summary>
			public ulong IoWriteBytes;

			/// <summary>
			/// If the LimitFlags member specifies JOB_OBJECT_LIMIT_WRITE_BYTES, this member contains the I/O write bytes notification limit
			/// in effect for the job.
			/// </summary>
			public ulong IoWriteBytesLimit;

			/// <summary>
			/// If the ViolationLimitFlags member specifies JOB_OBJECT_LIMIT_JOB_TIME, this member contains the total user-mode execution
			/// time for all processes in the job at the time the notification was sent.
			/// </summary>
			public TimeSpan PerJobUserTime;

			/// <summary>
			/// If the LimitFlags member specifies JOB_OBJECT_LIMIT_JOB_TIME, this member contains the user-mode execution notification limit
			/// in effect for the job.
			/// </summary>
			public TimeSpan PerJobUserTimeLimit;

			/// <summary>
			/// If the ViolationLimitFlags member specifies JOB_OBJECT_LIMIT_JOB_MEMORY, this member contains the committed memory for all
			/// processes in the job at the time the notification was sent.
			/// </summary>
			public ulong JobMemory;

			/// <summary>
			/// If the LimitFlags member specifies JOB_OBJECT_LIMIT_JOB_MEMORY, this member contains the committed memory limit in effect for
			/// the job.
			/// </summary>
			public ulong JobMemoryLimit;

			/// <summary>
			/// <para>
			/// If the LimitFlags parameter specifies JOB_OBJECT_LIMIT_RATE_CONTROL, this member specifies the extent to which the job
			/// exceeded its CPU rate control limits at the time the notification was sent. This member can be one of the following values.
			/// </para>
			/// <para>
			/// <list type="table">
			/// <listheader>
			/// <term>Value</term>
			/// <term>Meaning</term>
			/// </listheader>
			/// <item>
			/// <term>ToleranceLow1</term>
			/// <term>The job exceeded its CPU rate control limits for 20% of the tolerance interval.</term>
			/// </item>
			/// <item>
			/// <term>ToleranceMedium2</term>
			/// <term>The job exceeded its CPU rate control limits for 40% of the tolerance interval.</term>
			/// </item>
			/// <item>
			/// <term>ToleranceHigh3</term>
			/// <term>The job exceeded its CPU rate control limits for 60% of the tolerance interval.</term>
			/// </item>
			/// </list>
			/// </para>
			/// </summary>
			public JOBOBJECT_RATE_CONTROL_TOLERANCE RateControlTolerance;

			/// <summary>
			/// <para>
			/// If the LimitFlags parameter specifies JOB_OBJECT_LIMIT_RATE_CONTROL, this member contains the CPU rate control notification
			/// limits specified for the job.
			/// </para>
			/// <para>
			/// <list type="table">
			/// <listheader>
			/// <term>Value</term>
			/// <term>Meaning</term>
			/// </listheader>
			/// <item>
			/// <term>ToleranceIntervalShort1</term>
			/// <term>The tolerance interval is 10 seconds.</term>
			/// </item>
			/// <item>
			/// <term>ToleranceIntervalMedium2</term>
			/// <term>The tolerance interval is one minute.</term>
			/// </item>
			/// <item>
			/// <term>ToleranceIntervalLong3</term>
			/// <term>The tolerance interval is 10 minutes.</term>
			/// </item>
			/// </list>
			/// </para>
			/// </summary>
			public JOBOBJECT_RATE_CONTROL_TOLERANCE RateControlToleranceLimit;
		}

		/// <summary>
		/// Contains extended information about resource notification limits that have been exceeded for a job object. This structure is used
		/// with the <c>QueryInformationJobObject</c> function with the <c>JobObjectLimitViolationInformation2</c> information class.
		/// </summary>
		// typedef struct JOBOBJECT_LIMIT_VIOLATION_INFORMATION_2 { DWORD LimitFlags; DWORD ViolationLimitFlags; DWORD64 IoReadBytes; DWORD64
		// IoReadBytesLimit; DWORD64 IoWriteBytes; DWORD64 IoWriteBytesLimit; LARGE_INTEGER PerJobUserTime; LARGE_INTEGER
		// PerJobUserTimeLimit; DWORD64 JobMemory; union { DWORD64 JobHighMemoryLimit; DWORD64 JobMemoryLimit; }; union {
		// JOBOBJECT_RATE_CONTROL_TOLERANCE RateControlTolerance; JOBOBJECT_RATE_CONTROL_TOLERANCE CpuRateControlTolerance; }; union {
		// JOBOBJECT_RATE_CONTROL_TOLERANCE RateControlToleranceLimit; JOBOBJECT_RATE_CONTROL_TOLERANCE CpuRateControlToleranceLimit; };
		// DWORD64 JobLowMemoryLimit; JOBOBJECT_RATE_CONTROL_TOLERANCE IoRateControlTolerance; JOBOBJECT_RATE_CONTROL_TOLERANCE
		// IoRateControlToleranceLimit; JOBOBJECT_RATE_CONTROL_TOLERANCE NetRateControlTolerance; JOBOBJECT_RATE_CONTROL_TOLERANCE
		// NetRateControlToleranceLimit;} JOBOBJECT_LIMIT_VIOLATION_INFORMATION_2; https://msdn.microsoft.com/en-us/library/windows/desktop/mt280123(v=vs.85).aspx
		[PInvokeData("Winnt.h", MSDNShortId = "mt280123")]
		[StructLayout(LayoutKind.Sequential)]
		public struct JOBOBJECT_LIMIT_VIOLATION_INFORMATION_2
		{
			/// <summary>
			/// <para>
			/// Flags that identify the notification limits in effect for the job. This member is a bitfield that determines whether other
			/// structure members are used. This member can be any combination of the following values.
			/// </para>
			/// <para>
			/// <list type="table">
			/// <listheader>
			/// <term>Value</term>
			/// <term>Meaning</term>
			/// </listheader>
			/// <item>
			/// <term>JOB_OBJECT_LIMIT_JOB_MEMORY0x00000200</term>
			/// <term>The job has a committed memory notification limit. The JobMemoryLimit member contains more information.</term>
			/// </item>
			/// <item>
			/// <term>JOB_OBJECT_LIMIT_JOB_READ_BYTES0x00010000</term>
			/// <term>The job has an I/O read bytes notification limit. The IoReadBytesLimit member contains more information.</term>
			/// </item>
			/// <item>
			/// <term>JOB_OBJECT_LIMIT_JOB_TIME0x00000004</term>
			/// <term>The job has a user-mode execution time notification limit. The PerJobUserTimeLimit member contains more information.</term>
			/// </item>
			/// <item>
			/// <term>JOB_OBJECT_LIMIT_JOB_WRITE_BYTES0x00020000</term>
			/// <term>The job has an I/O write bytes notification limit. The IoWriteBytesLimit member contains more information.</term>
			/// </item>
			/// <item>
			/// <term>JOB_OBJECT_LIMIT_RATE_CONTROL0x00040000</term>
			/// <term>
			/// The extent to which a job can exceed its CPU rate control limit. The RateControlToleranceLimit member contains more information.
			/// </term>
			/// </item>
			/// </list>
			/// </para>
			/// </summary>
			public JOBOBJECT_LIMIT_FLAGS LimitFlags;

			/// <summary>
			/// <para>
			/// Flags that identify the notification limits that have been exceeded. This member is a bitfield that determines whether other
			/// structure members are used. This member can be any combination of the following values.
			/// </para>
			/// <para>
			/// <list type="table">
			/// <listheader>
			/// <term>Value</term>
			/// <term>Meaning</term>
			/// </listheader>
			/// <item>
			/// <term>JOB_OBJECT_LIMIT_READ_BYTES0x00010000</term>
			/// <term>The job's I/O read bytes notification limit has been exceeded. The IoReadBytes member contains more information.</term>
			/// </item>
			/// <item>
			/// <term>JOB_OBJECT_LIMIT_WRITE_BYTES0x00020000</term>
			/// <term>The job's I/O write bytes notification limit has been exceeded. The IoWriteBytes member contains more information.</term>
			/// </item>
			/// <item>
			/// <term>JOB_OBJECT_LIMIT_JOB_TIME0x00000004</term>
			/// <term>The job's user-mode execution time notification limit has been exceeded. The PerJobUserTime member contains more information.</term>
			/// </item>
			/// <item>
			/// <term>JOB_OBJECT_LIMIT_JOB_MEMORY0x00000200</term>
			/// <term>The job's committed memory notification limit has been exceeded. The JobMemory member contains more information.</term>
			/// </item>
			/// <item>
			/// <term>JOB_OBJECT_LIMIT_RATE_CONTROL0x00040000</term>
			/// <term>The job's CPU rate control limit has been exceeded. The RateControlTolerance member contains more information.</term>
			/// </item>
			/// </list>
			/// </para>
			/// </summary>
			public JOBOBJECT_LIMIT_FLAGS ViolationLimitFlags;

			/// <summary>
			/// If the ViolationLimitFlags member specifies JOB_OBJECT_LIMIT_READ_BYTES, this member contains the total I/O read bytes for
			/// all processes in the job at the time the notification was sent.
			/// </summary>
			public ulong IoReadBytes;

			/// <summary>
			/// If the LimitFlags member specifies JOB_OBJECT_LIMIT_READ_BYTES, this member contains the I/O read bytes notification limit in
			/// effect for the job.
			/// </summary>
			public ulong IoReadBytesLimit;

			/// <summary>
			/// If the ViolationLimitFlags member specifies JOB_OBJECT_LIMIT_WRITE_BYTES, this member contains the total I/O write bytes for
			/// all processes in the job at the time the notification was sent.
			/// </summary>
			public ulong IoWriteBytes;

			/// <summary>
			/// If the LimitFlags member specifies JOB_OBJECT_LIMIT_WRITE_BYTES, this member contains the I/O write bytes notification limit
			/// in effect for the job.
			/// </summary>
			public ulong IoWriteBytesLimit;

			/// <summary>
			/// If the ViolationLimitFlags member specifies JOB_OBJECT_LIMIT_JOB_TIME, this member contains the total user-mode execution
			/// time for all processes in the job at the time the notification was sent.
			/// </summary>
			public TimeSpan PerJobUserTime;

			/// <summary>
			/// If the LimitFlags member specifies JOB_OBJECT_LIMIT_JOB_TIME, this member contains the user-mode execution notification limit
			/// in effect for the job.
			/// </summary>
			public TimeSpan PerJobUserTimeLimit;

			/// <summary>
			/// If the ViolationLimitFlags member specifies JOB_OBJECT_LIMIT_JOB_MEMORY, this member contains the committed memory for all
			/// processes in the job at the time the notification was sent.
			/// </summary>
			public ulong JobMemory;

			/// <summary>
			/// If the LimitFlags member specifies JOB_OBJECT_LIMIT_JOB_MEMORY, this member contains the committed memory limit in effect for
			/// the job.
			/// </summary>
			public ulong JobMemoryLimit;

			/// <summary>
			/// <para>
			/// If the LimitFlags parameter specifies JOB_OBJECT_LIMIT_RATE_CONTROL, this member specifies the extent to which the job
			/// exceeded its CPU rate control limits at the time the notification was sent. This member can be one of the following values.
			/// </para>
			/// <para>
			/// <list type="table">
			/// <listheader>
			/// <term>Value</term>
			/// <term>Meaning</term>
			/// </listheader>
			/// <item>
			/// <term>ToleranceLow1</term>
			/// <term>The job exceeded its CPU rate control limits for 20% of the tolerance interval.</term>
			/// </item>
			/// <item>
			/// <term>ToleranceMedium2</term>
			/// <term>The job exceeded its CPU rate control limits for 40% of the tolerance interval.</term>
			/// </item>
			/// <item>
			/// <term>ToleranceHigh3</term>
			/// <term>The job exceeded its CPU rate control limits for 60% of the tolerance interval.</term>
			/// </item>
			/// </list>
			/// </para>
			/// </summary>
			public JOBOBJECT_RATE_CONTROL_TOLERANCE RateControlTolerance;

			/// <summary>
			/// <para>
			/// If the LimitFlags parameter specifies JOB_OBJECT_LIMIT_RATE_CONTROL, this member contains the CPU rate control notification
			/// limits specified for the job.
			/// </para>
			/// <para>
			/// <list type="table">
			/// <listheader>
			/// <term>Value</term>
			/// <term>Meaning</term>
			/// </listheader>
			/// <item>
			/// <term>ToleranceIntervalShort1</term>
			/// <term>The tolerance interval is 10 seconds.</term>
			/// </item>
			/// <item>
			/// <term>ToleranceIntervalMedium2</term>
			/// <term>The tolerance interval is one minute.</term>
			/// </item>
			/// <item>
			/// <term>ToleranceIntervalLong3</term>
			/// <term>The tolerance interval is 10 minutes.</term>
			/// </item>
			/// </list>
			/// </para>
			/// </summary>
			public JOBOBJECT_RATE_CONTROL_TOLERANCE RateControlToleranceLimit;

			/// <summary>
			/// If the <c>LimitFlags</c> member specifies <c>JOB_OBJECT_LIMIT_JOB_MEMORY_LOW</c>, this member contains the committed minimum
			/// memory limit in effect for the job.
			/// </summary>
			public ulong JobLowMemoryLimit;

			/// <summary>
			/// <para>
			/// If the <c>LimitFlags</c> member specifies <c>JOB_OBJECT_LIMIT_IO_RATE_CONTROL</c>, this member specifies the extent to which
			/// the job exceeded its I/O rate control limits at the time the notification was sent. This member can be one of the following values.
			/// </para>
			/// <para>
			/// <list type="table">
			/// <listheader>
			/// <term>Value</term>
			/// <term>Meaning</term>
			/// </listheader>
			/// <item>
			/// <term>ToleranceLow1</term>
			/// <term>The job exceeded its I/O rate control limits for 20% of the tolerance interval.</term>
			/// </item>
			/// <item>
			/// <term>ToleranceMedium2</term>
			/// <term>The job exceeded its I/O rate control limits for 40% of the tolerance interval.</term>
			/// </item>
			/// <item>
			/// <term>ToleranceHigh3</term>
			/// <term>The job exceeded its I/O rate control limits for 60% of the tolerance interval.</term>
			/// </item>
			/// </list>
			/// </para>
			/// </summary>
			public JOBOBJECT_RATE_CONTROL_TOLERANCE IoRateControlTolerance;

			/// <summary>
			/// <para>
			/// If the LimitFlags parameter specifies <c>JOB_OBJECT_LIMIT_IO_RATE_CONTROL</c>, this member contains the I/O rate control
			/// notification limits specified for the job.
			/// </para>
			/// <para>
			/// <list type="table">
			/// <listheader>
			/// <term>Value</term>
			/// <term>Meaning</term>
			/// </listheader>
			/// <item>
			/// <term>ToleranceLow1</term>
			/// <term>The job can exceed its I/O rate control limits for 20% of the tolerance interval.</term>
			/// </item>
			/// <item>
			/// <term>ToleranceMedium2</term>
			/// <term>The job can exceed its I/O rate control limits for 40% of the tolerance interval.</term>
			/// </item>
			/// <item>
			/// <term>ToleranceHigh3</term>
			/// <term>The job can exceed its I/O rate control limits for 60% of the tolerance interval.</term>
			/// </item>
			/// </list>
			/// </para>
			/// </summary>
			public JOBOBJECT_RATE_CONTROL_TOLERANCE IoRateControlToleranceLimit;

			/// <summary>
			/// <para>
			/// If the <c>LimitFlags</c> member specifies <c>JOB_OBJECT_LIMIT_NET_RATE_CONTROL</c>, this member specifies the extent to which
			/// the job exceeded its network rate control limits at the time the notification was sent. This member can be one of the
			/// following values.
			/// </para>
			/// <para>
			/// <list type="table">
			/// <listheader>
			/// <term>Value</term>
			/// <term>Meaning</term>
			/// </listheader>
			/// <item>
			/// <term>ToleranceLow1</term>
			/// <term>The job exceeded its network rate control limits for 20% of the tolerance interval.</term>
			/// </item>
			/// <item>
			/// <term>ToleranceMedium2</term>
			/// <term>The job exceeded its network rate control limits for 40% of the tolerance interval.</term>
			/// </item>
			/// <item>
			/// <term>ToleranceHigh3</term>
			/// <term>The job exceeded its network rate control limits for 60% of the tolerance interval.</term>
			/// </item>
			/// </list>
			/// </para>
			/// </summary>
			public JOBOBJECT_RATE_CONTROL_TOLERANCE NetRateControlTolerance;

			/// <summary>
			/// <para>
			/// If the LimitFlags parameter specifies <c>JOB_OBJECT_LIMIT_NETWORK_RATE_CONTROL</c>, this member contains the network rate
			/// control notification limits specified for the job.
			/// </para>
			/// <para>
			/// <list type="table">
			/// <listheader>
			/// <term>Value</term>
			/// <term>Meaning</term>
			/// </listheader>
			/// <item>
			/// <term>ToleranceLow1</term>
			/// <term>The job can exceed its network rate control limits for 20% of the tolerance interval.</term>
			/// </item>
			/// <item>
			/// <term>ToleranceMedium2</term>
			/// <term>The job can exceed its network rate control limits for 40% of the tolerance interval.</term>
			/// </item>
			/// <item>
			/// <term>ToleranceHigh3</term>
			/// <term>The job can exceed its network rate control limits for 60% of the tolerance interval.</term>
			/// </item>
			/// </list>
			/// </para>
			/// </summary>
			public JOBOBJECT_RATE_CONTROL_TOLERANCE NetRateControlToleranceLimit;
		}

		/// <summary>
		/// Contains information used to control the network traffic for a job. This structure is used by the <c>SetInformationJobObject</c>
		/// and <c>QueryInformationJobObject</c> functions with the <c>JobObjectNetRateControlInformation</c> information class.
		/// </summary>
		// typedef struct JOBOBJECT_NET_RATE_CONTROL_INFORMATION { DWORD64 MaxBandwidth; JOB_OBJECT_NET_RATE_CONTROL_FLAGS ControlFlags; BYTE
		// DscpTag;} JOBOBJECT_NET_RATE_CONTROL_INFORMATION; https://msdn.microsoft.com/en-us/library/windows/desktop/mt280124(v=vs.85).aspx
		[PInvokeData("Winnt.h", MSDNShortId = "mt280124")]
		[StructLayout(LayoutKind.Sequential, Pack = 4, Size = 16)]
		public struct JOBOBJECT_NET_RATE_CONTROL_INFORMATION
		{
			/// <summary>The maximum bandwidth for outgoing network traffic for the job, in bytes.</summary>
			public ulong MaxBandwidth;

			/// <summary>
			/// A combination of <c>JOB_OBJECT_NET_RATE_CONTROL_FLAGS</c> enumeration values that specify the scheduling policy for network
			/// rate control.
			/// </summary>
			public JOB_OBJECT_NET_RATE_CONTROL_FLAGS ControlFlags;

			/// <summary>
			/// The value to use for the Differentiated Service code point (DSCP) field to turn on network quality of service (QoS) for all
			/// outgoing network traffic generated by the processes of the job object. The valid range is from 0x00 through 0x3F. For
			/// information about DSCP, see Differentiated Services.
			/// </summary>
			public byte DscpTag;
		}

		/// <summary>
		/// Contains information about notification limits for a job object. This structure is used by the <c>SetInformationJobObject</c> and
		/// <c>QueryInformationJobObject</c> functions with the <c>JobObjectNotificationLimitInformation</c> information class.
		/// </summary>
		// typedef struct _JOBOBJECT_NOTIFICATION_LIMIT_INFORMATION { DWORD64 IoReadBytesLimit; DWORD64 IoWriteBytesLimit; LARGE_INTEGER
		// PerJobUserTimeLimit; DWORD64 JobMemoryLimit; JOBOBJECT_RATE_CONTROL_TOLERANCE RateControlTolerance;
		// JOBOBJECT_RATE_CONTROL_TOLERANCE_INTERVAL RateControlToleranceInterval; DWORD LimitFlags;}
		// JOBOBJECT_NOTIFICATION_LIMIT_INFORMATION, *PJOBOBJECT_NOTIFICATION_LIMIT_INFORMATION; https://msdn.microsoft.com/en-us/library/windows/desktop/hh448386(v=vs.85).aspx
		[PInvokeData("WinNT.h", MSDNShortId = "hh448386")]
		[StructLayout(LayoutKind.Sequential)]
		public struct JOBOBJECT_NOTIFICATION_LIMIT_INFORMATION
		{
			/// <summary>
			/// If the LimitFlags member specifies JOB_OBJECT_LIMIT_FLAGS_READ_BYTES, this member is the notification limit for total I/O
			/// bytes read by all processes in the job. Otherwise, this member is ignored.
			/// </summary>
			public ulong IoReadBytesLimit;

			/// <summary>
			/// If the LimitFlags parameter specifies JOB_OBJECT_LIMIT_FLAGS_WRITE_BYTES, this member is the notification limit for total I/O
			/// bytes written by all processes in the job. Otherwise, this member is ignored.
			/// </summary>
			public ulong IoWriteBytesLimit;

			/// <summary>
			/// <para>
			/// If the LimitFlags parameter specifies JOB_OBJECT_LIMIT_JOB_TIME, this member is the notification limit for per-job user-mode
			/// execution time, in 100-nanosecond ticks. Otherwise, this member is ignored.
			/// </para>
			/// <para>
			/// The system adds the accumulated execution time of processes associated with the job to this limit when the limit is set. For
			/// example, if a process associated with the job has already accumulated 5 minutes of user-mode execution time and the limit is
			/// set to 1 minute, the limit actually enforced is 6 minutes.
			/// </para>
			/// <para>
			/// To specify <c>PerJobUserTimeLimit</c> as an enforceable limit and terminate processes in jobs that exceed the limit, see the
			/// <c>JOBOBJECT_BASIC_LIMIT_INFORMATION</c> structure.
			/// </para>
			/// </summary>
			public TimeSpan PerJobUserTimeLimit;

			/// <summary>
			/// <para>
			/// If the LimitFlags parameter specifies JOB_OBJECT_LIMIT_JOB_MEMORY, this member is the notification limit for total virtual
			/// memory that can be committed by all processes in the job, in bytes. Otherwise, this member is ignored.
			/// </para>
			/// <para>
			/// To specify <c>JobMemoryLimit</c> as an enforceable limit and prevent processes in jobs that exceed the limit from continuing
			/// to commit memory, see the <c>JOBOBJECT_EXTENDED_LIMIT_INFORMATION</c> structure.
			/// </para>
			/// </summary>
			public ulong JobMemoryLimit;

			/// <summary>
			/// <para>
			/// If the LimitFlags parameter specifies JOB_OBJECT_LIMIT_RATE_CONTROL, this member specifies the extent to which a job can
			/// exceed its CPU rate control limits during the interval specified by the <c>RateControlToleranceInterval</c> member.
			/// Otherwise, this member is ignored.
			/// </para>
			/// <para>This member can be one of the following values. If no value is specified, <c>ToleranceHigh</c> is used.</para>
			/// <para>
			/// <list type="table">
			/// <listheader>
			/// <term>Value</term>
			/// <term>Meaning</term>
			/// </listheader>
			/// <item>
			/// <term>ToleranceLow1</term>
			/// <term>The job can exceed its CPU rate control limits for 20% of the tolerance interval.</term>
			/// </item>
			/// <item>
			/// <term>ToleranceMedium2</term>
			/// <term>The job can exceed its CPU rate control limits for 40% of the tolerance interval.</term>
			/// </item>
			/// <item>
			/// <term>ToleranceHigh3</term>
			/// <term>The job can exceed its CPU rate control limits for 60% of the tolerance interval.</term>
			/// </item>
			/// </list>
			/// </para>
			/// </summary>
			public JOBOBJECT_RATE_CONTROL_TOLERANCE RateControlTolerance;

			/// <summary>
			/// <para>
			/// If the LimitFlags parameter specifies JOB_OBJECT_LIMIT_RATE_CONTROL, this member specifies the interval during which a job's
			/// CPU usage is monitored to determine whether the job has exceeded its CPU rate control limits. Otherwise, this member is ignored.
			/// </para>
			/// <para>This member can be one of the following values. If no value is specified, <c>ToleranceIntervalShort</c> is used.</para>
			/// <para>
			/// <list type="table">
			/// <listheader>
			/// <term>Value</term>
			/// <term>Meaning</term>
			/// </listheader>
			/// <item>
			/// <term>ToleranceIntervalShort1</term>
			/// <term>The tolerance interval is 10 seconds.</term>
			/// </item>
			/// <item>
			/// <term>ToleranceIntervalMedium2</term>
			/// <term>The tolerance interval is one minute.</term>
			/// </item>
			/// <item>
			/// <term>ToleranceIntervalLong3</term>
			/// <term>The tolerance interval is 10 minutes.</term>
			/// </item>
			/// </list>
			/// </para>
			/// </summary>
			public JOBOBJECT_RATE_CONTROL_TOLERANCE_INTERVAL RateControlToleranceInterval;

			/// <summary>
			/// <para>
			/// The limit flags that are in effect. This member is a bitfield that determines whether other structure members are used. Any
			/// combination of the following values can be specified.
			/// </para>
			/// <para>
			/// <list type="table">
			/// <listheader>
			/// <term>Value</term>
			/// <term>Meaning</term>
			/// </listheader>
			/// <item>
			/// <term>JOB_OBJECT_LIMIT_JOB_MEMORY0x00000200</term>
			/// <term>
			/// Establishes the committed memory limit to the job-wide sum of committed memory for all processes associated with the job. The
			/// JobMemoryLimit member contains additional information.
			/// </term>
			/// </item>
			/// <item>
			/// <term>JOB_OBJECT_LIMIT_JOB_READ_BYTES0x00010000</term>
			/// <term>
			/// Establishes the I/O read bytes limit to the job-wide sum of I/O bytes read by all processes associated with the job. The
			/// IoReadBytesLimit member contains more information.
			/// </term>
			/// </item>
			/// <item>
			/// <term>JOB_OBJECT_LIMIT_JOB_WRITE_BYTES0x00020000</term>
			/// <term>
			/// Establishes the I/O write bytes limit to the job-wide sum of I/O bytes written by all processes associated with the job. The
			/// IoWriteBytesLimit member contains more information.
			/// </term>
			/// </item>
			/// <item>
			/// <term>JOB_OBJECT_LIMIT_JOB_TIME0x00000004</term>
			/// <term>
			/// Establishes the limit for user-mode execution time for the job. The PerJobUserTimeLimit member contains additional information.
			/// </term>
			/// </item>
			/// <item>
			/// <term>JOB_OBJECT_LIMIT_RATE_CONTROL0x00040000</term>
			/// <term>
			/// Establishes the notification threshold for the CPU rate control limits established for the job. The RateControlTolerance and
			/// RateControlToleranceInterval members contain additional information.CPU rate control limits are established by calling
			/// SetInformationJobObject with the JobObjectCpuRateInformationClass information class.
			/// </term>
			/// </item>
			/// </list>
			/// </para>
			/// </summary>
			public JOBOBJECT_LIMIT_FLAGS LimitFlags;
		}

		/// <summary>
		/// Contains extended information about notification limits for a job object. This structure is used by the
		/// <c>SetInformationJobObject</c> and <c>QueryInformationJobObject</c> functions with the
		/// <c>JobObjectNotificationLimitInformation2</c> information class.
		/// </summary>
		// typedef struct JOBOBJECT_NOTIFICATION_LIMIT_INFORMATION_2 { DWORD64 IoReadBytesLimit; DWORD64 IoWriteBytesLimit; LARGE_INTEGER
		// PerJobUserTimeLimit; union { DWORD64 JobHighMemoryLimit; DWORD64 JobMemoryLimit; }; union { JOBOBJECT_RATE_CONTROL_TOLERANCE
		// RateControlTolerance; JOBOBJECT_RATE_CONTROL_TOLERANCE CpuRateControlTolerance; }; union {
		// JOBOBJECT_RATE_CONTROL_TOLERANCE_INTERVAL RateControlToleranceInterval; JOBOBJECT_RATE_CONTROL_TOLERANCE_INTERVAL
		// CpuRateControlToleranceInterval; }; DWORD LimitFlags; JOBOBJECT_RATE_CONTROL_TOLERANCE IoRateControlTolerance; DWORD64
		// JobLowMemoryLimit; JOBOBJECT_RATE_CONTROL_TOLERANCE_INTERVAL IoRateControlToleranceInterval; JOBOBJECT_RATE_CONTROL_TOLERANCE
		// NetRateControlTolerance; JOBOBJECT_RATE_CONTROL_TOLERANCE_INTERVAL NetRateControlToleranceInterval;}
		// JOBOBJECT_NOTIFICATION_LIMIT_INFORMATION_2; https://msdn.microsoft.com/en-us/library/windows/desktop/mt280125(v=vs.85).aspx
		[PInvokeData("Winnt.h", MSDNShortId = "mt280125")]
		[StructLayout(LayoutKind.Sequential)]
		public struct JOBOBJECT_NOTIFICATION_LIMIT_INFORMATION_2
		{
			/// <summary>
			/// If the LimitFlags member specifies <c>JOB_OBJECT_LIMIT_JOB_READ_BYTES</c>, this member is the notification limit for the
			/// total I/O bytes read by all processes in the job. Otherwise, this member is ignored.
			/// </summary>
			public ulong IoReadBytesLimit;

			/// <summary>
			/// If the LimitFlags parameter specifies <c>JOB_OBJECT_LIMIT_JOB_WRITE_BYTES</c>, this member is the notification limit for the
			/// total I/O bytes written by all processes in the job. Otherwise, this member is ignored.
			/// </summary>
			public ulong IoWriteBytesLimit;

			/// <summary>
			/// <para>
			/// If the LimitFlags parameter specifies <c>JOB_OBJECT_LIMIT_JOB_TIME</c>, this member is the notification limit for per-job
			/// user-mode execution time, in 100-nanosecond ticks. Otherwise, this member is ignored.
			/// </para>
			/// <para>
			/// The system adds the accumulated execution time of processes associated with the job to this limit when the limit is set. For
			/// example, if a process associated with the job has already accumulated 5 minutes of user-mode execution time and the limit is
			/// set to 1 minute, the limit actually enforced is 6 minutes.
			/// </para>
			/// <para>
			/// To specify <c>PerJobUserTimeLimit</c> as an enforceable limit and terminate processes in jobs that exceed the limit, see the
			/// <c>JOBOBJECT_BASIC_LIMIT_INFORMATION</c> structure.
			/// </para>
			/// </summary>
			public TimeSpan PerJobUserTimeLimit;

			/// <summary>
			/// If the LimitFlags parameter specifies <c>JOB_OBJECT_LIMIT_JOB_MEMORY_HIGH</c>, this member is the notification maximum limit
			/// for total virtual memory that can be committed by all processes in the job, in bytes. Otherwise, this member is ignored.
			/// <para>
			/// If the LimitFlags parameter specifies <c>JOB_OBJECT_LIMIT_JOB_MEMORY</c>, this member is the notification maximum limit for
			/// total virtual memory that can be committed by all processes in the job, in bytes. Otherwise, this member is ignored.
			/// </para>
			/// </summary>
			public ulong JobMemoryLimit;

			/// <summary>
			/// <para>
			/// If the LimitFlags parameter specifies <c>JOB_OBJECT_LIMIT_RATE_CONTROL</c>, this member specifies the extent to which a job
			/// can exceed its CPU rate control limits during the interval specified by the <c>RateControlToleranceInterval</c> member.
			/// Otherwise, this member is ignored.
			/// </para>
			/// <para>This member can be one of the following values. If no value is specified, <c>ToleranceHigh</c> is used.</para>
			/// <para>
			/// <list type="table">
			/// <listheader>
			/// <term>Value</term>
			/// <term>Meaning</term>
			/// </listheader>
			/// <item>
			/// <term>ToleranceLow1</term>
			/// <term>The job can exceed its CPU rate control limits for 20% of the tolerance interval.</term>
			/// </item>
			/// <item>
			/// <term>ToleranceMedium2</term>
			/// <term>The job can exceed its CPU rate control limits for 40% of the tolerance interval.</term>
			/// </item>
			/// <item>
			/// <term>ToleranceHigh3</term>
			/// <term>The job can exceed its CPU rate control limits for 60% of the tolerance interval.</term>
			/// </item>
			/// </list>
			/// </para>
			/// <para>
			/// If the LimitFlags parameter specifies <c>JOB_OBJECT_LIMIT_CPU_RATE_CONTROL</c>, this member specifies the extent to which a
			/// job can exceed its CPU rate control limits during the interval specified by the <c>CpuRateControlToleranceInterval</c>
			/// member. Otherwise, this member is ignored.
			/// </para>
			/// <para>This member can be one of the following values. If no value is specified, <c>ToleranceHigh</c> is used.</para>
			/// <para>
			/// <list type="table">
			/// <listheader>
			/// <term>Value</term>
			/// <term>Meaning</term>
			/// </listheader>
			/// <item>
			/// <term>ToleranceLow1</term>
			/// <term>The job can exceed its CPU rate control limits for 20% of the tolerance interval.</term>
			/// </item>
			/// <item>
			/// <term>ToleranceMedium2</term>
			/// <term>The job can exceed its CPU rate control limits for 40% of the tolerance interval.</term>
			/// </item>
			/// <item>
			/// <term>ToleranceHigh3</term>
			/// <term>The job can exceed its CPU rate control limits for 60% of the tolerance interval.</term>
			/// </item>
			/// </list>
			/// </para>
			/// </summary>
			public JOBOBJECT_RATE_CONTROL_TOLERANCE RateControlTolerance;

			/// <summary>
			/// <para>
			/// If the LimitFlags parameter specifies <c>JOB_OBJECT_LIMIT_RATE_CONTROL</c>, this member specifies the interval during which a
			/// job's CPU usage is monitored to determine whether the job has exceeded its CPU rate control limits. Otherwise, this member is ignored.
			/// </para>
			/// <para>This member can be one of the following values. If no value is specified, <c>ToleranceIntervalShort</c> is used.</para>
			/// <para>
			/// <list type="table">
			/// <listheader>
			/// <term>Value</term>
			/// <term>Meaning</term>
			/// </listheader>
			/// <item>
			/// <term>ToleranceIntervalShort1</term>
			/// <term>The tolerance interval is 10 seconds.</term>
			/// </item>
			/// <item>
			/// <term>ToleranceIntervalMedium2</term>
			/// <term>The tolerance interval is one minute.</term>
			/// </item>
			/// <item>
			/// <term>ToleranceIntervalLong3</term>
			/// <term>The tolerance interval is 10 minutes.</term>
			/// </item>
			/// </list>
			/// </para>
			/// <para>
			/// If the LimitFlags parameter specifies <c>JOB_OBJECT_CPU_LIMIT_RATE_CONTROL</c>, this member specifies the interval during
			/// which a job's CPU usage is monitored to determine whether the job has exceeded its CPU rate control limits. Otherwise, this
			/// member is ignored.
			/// </para>
			/// <para>This member can be one of the following values. If no value is specified, <c>ToleranceIntervalShort</c> is used.</para>
			/// <para>
			/// <list type="table">
			/// <listheader>
			/// <term>Value</term>
			/// <term>Meaning</term>
			/// </listheader>
			/// <item>
			/// <term>ToleranceIntervalShort1</term>
			/// <term>The tolerance interval is 10 seconds.</term>
			/// </item>
			/// <item>
			/// <term>ToleranceIntervalMedium2</term>
			/// <term>The tolerance interval is one minute.</term>
			/// </item>
			/// <item>
			/// <term>ToleranceIntervalLong3</term>
			/// <term>The tolerance interval is 10 minutes.</term>
			/// </item>
			/// </list>
			/// </para>
			/// </summary>
			public JOBOBJECT_RATE_CONTROL_TOLERANCE_INTERVAL RateControlToleranceInterval;

			/// <summary>
			/// <para>
			/// The limit flags that are in effect. This member is a bitfield that determines whether other structure members are used. Any
			/// combination of the following values can be specified.
			/// </para>
			/// <para>
			/// <list type="table">
			/// <listheader>
			/// <term>Value</term>
			/// <term>Meaning</term>
			/// </listheader>
			/// <item>
			/// <term>JOB_OBJECT_LIMIT_JOB_MEMORY_HIGH0x00000200</term>
			/// <term>
			/// Establishes the notification threshold for the job-wide sum of private committed memory for all processes associated with the
			/// job. The JobHighMemoryLimit member contains additional information.
			/// </term>
			/// </item>
			/// <item>
			/// <term>JOB_OBJECT_LIMIT_JOB_MEMORY_LOW0x00008000</term>
			/// <term>
			/// Establishes the notification minimum for the job-wide sum of private committed memory for all processes associated with the
			/// job. If this value is set, a notification is sent when the amount of private committed memory falls below this threshold. The
			/// JobLowMemoryLimit member contains additional information.
			/// </term>
			/// </item>
			/// <item>
			/// <term>JOB_OBJECT_LIMIT_JOB_READ_BYTES0x00010000</term>
			/// <term>
			/// Establishes the I/O read bytes limit to the job-wide sum of I/O bytes read by all processes associated with the job. The
			/// IoReadBytesLimit member contains more information.
			/// </term>
			/// </item>
			/// <item>
			/// <term>JOB_OBJECT_LIMIT_JOB_WRITE_BYTES0x00020000</term>
			/// <term>
			/// Establishes the I/O write bytes limit to the job-wide sum of I/O bytes written by all processes associated with the job. The
			/// IoWriteBytesLimit member contains more information.
			/// </term>
			/// </item>
			/// <item>
			/// <term>JOB_OBJECT_LIMIT_JOB_TIME0x00000004</term>
			/// <term>
			/// Establishes the limit for user-mode execution time for the job. The PerJobUserTimeLimit member contains additional information.
			/// </term>
			/// </item>
			/// <item>
			/// <term>JOB_OBJECT_LIMIT_CPU_RATE_CONTROL0x00040000</term>
			/// <term>
			/// Establishes the notification threshold for the CPU rate control limits established for the job. The CpuRateControlTolerance
			/// and CpuRateControlToleranceInterval members contain additional information.CPU rate control limits are established by calling
			/// SetInformationJobObject with the JobObjectCpuRateInformationClass information class.
			/// </term>
			/// </item>
			/// <item>
			/// <term>JOB_OBJECT_LIMIT_RATE_CONTROL0x00040000</term>
			/// <term>
			/// Establishes the notification threshold for the CPU rate control limits established for the job. The RateControlTolerance and
			/// RateControlToleranceInterval members contain additional information.CPU rate control limits are established by calling
			/// SetInformationJobObject with the JobObjectCpuRateInformationClass information class.
			/// </term>
			/// </item>
			/// <item>
			/// <term>JOB_OBJECT_LIMIT_IO_RATE_CONTROL0x00080000</term>
			/// <term>
			/// Establishes the notification threshold for the I/O rate control limits established for the job. The IoRateControlTolerance
			/// and IoRateControlToleranceInterval members contain additional information.I/O rate control limits are established by calling SetIoRateControlInformationJobObject.
			/// </term>
			/// </item>
			/// <item>
			/// <term>JOB_OBJECT_LIMIT_NET_RATE_CONTROL0x00100000</term>
			/// <term>
			/// Establishes the notification threshold for the network rate control limits established for the job. The
			/// NetRateControlTolerance and NetRateControlToleranceInterval members contain additional information.Network rate control
			/// limits are established by calling SetInformationJobObject with the JobObjectNetRateInformationClass information class.
			/// </term>
			/// </item>
			/// </list>
			/// </para>
			/// </summary>
			public JOBOBJECT_LIMIT_FLAGS LimitFlags;

			/// <summary>
			/// <para>
			/// If the LimitFlags parameter specifies <c>JOB_OBJECT_LIMIT_IO_RATE_CONTROL</c>, this member specifies the extent to which a
			/// job can exceed its I/O rate control limits during the interval specified by the <c>IoRateControlToleranceInterval</c> member.
			/// Otherwise, this member is ignored.
			/// </para>
			/// <para>This member can be one of the following values. If no value is specified, <c>ToleranceHigh</c> is used.</para>
			/// <para>
			/// <list type="table">
			/// <listheader>
			/// <term>Value</term>
			/// <term>Meaning</term>
			/// </listheader>
			/// <item>
			/// <term>ToleranceLow1</term>
			/// <term>The job can exceed its I/O rate control limits for 20% of the tolerance interval.</term>
			/// </item>
			/// <item>
			/// <term>ToleranceMedium2</term>
			/// <term>The job can exceed its I/O rate control limits for 40% of the tolerance interval.</term>
			/// </item>
			/// <item>
			/// <term>ToleranceHigh3</term>
			/// <term>The job can exceed its I/O rate control limits for 60% of the tolerance interval.</term>
			/// </item>
			/// </list>
			/// </para>
			/// </summary>
			public JOBOBJECT_RATE_CONTROL_TOLERANCE IoRateControlTolerance;

			/// <summary>
			/// If the LimitFlags parameter specifies <c>JOB_OBJECT_LIMIT_JOB_MEMORY_LOW</c>, this member is the notification limit minimum
			/// for the total virtual memory that can be committed by all processes in the job, in bytes. Otherwise, this member is ignored.
			/// </summary>
			public ulong JobLowMemoryLimit;

			/// <summary>
			/// <para>
			/// If the LimitFlags parameter specifies <c>JOB_OBJECT_IO_LIMIT_RATE_CONTROL</c>, this member specifies the interval during
			/// which a job's I/O usage is monitored to determine whether the job has exceeded its I/O rate control limits. Otherwise, this
			/// member is ignored.
			/// </para>
			/// <para>This member can be one of the following values. If no value is specified, <c>ToleranceIntervalShort</c> is used.</para>
			/// <para>
			/// <list type="table">
			/// <listheader>
			/// <term>Value</term>
			/// <term>Meaning</term>
			/// </listheader>
			/// <item>
			/// <term>ToleranceIntervalShort1</term>
			/// <term>The tolerance interval is 10 seconds.</term>
			/// </item>
			/// <item>
			/// <term>ToleranceIntervalMedium2</term>
			/// <term>The tolerance interval is one minute.</term>
			/// </item>
			/// <item>
			/// <term>ToleranceIntervalLong3</term>
			/// <term>The tolerance interval is 10 minutes.</term>
			/// </item>
			/// </list>
			/// </para>
			/// </summary>
			public JOBOBJECT_RATE_CONTROL_TOLERANCE_INTERVAL IoRateControlToleranceInterval;

			/// <summary>
			/// <para>
			/// If the LimitFlags parameter specifies <c>JOB_OBJECT_LIMIT_IO_RATE_CONTROL</c>, this member specifies the extent to which a
			/// job can exceed its network rate control limits during the interval specified by the <c>NetRateControlToleranceInterval</c>
			/// member. Otherwise, this member is ignored.
			/// </para>
			/// <para>This member can be one of the following values. If no value is specified, <c>ToleranceHigh</c> is used.</para>
			/// <para>
			/// <list type="table">
			/// <listheader>
			/// <term>Value</term>
			/// <term>Meaning</term>
			/// </listheader>
			/// <item>
			/// <term>ToleranceLow1</term>
			/// <term>The job can exceed its network rate control limits for 20% of the tolerance interval.</term>
			/// </item>
			/// <item>
			/// <term>ToleranceMedium2</term>
			/// <term>The job can exceed its network rate control limits for 40% of the tolerance interval.</term>
			/// </item>
			/// <item>
			/// <term>ToleranceHigh3</term>
			/// <term>The job can exceed its network rate control limits for 60% of the tolerance interval.</term>
			/// </item>
			/// </list>
			/// </para>
			/// </summary>
			public JOBOBJECT_RATE_CONTROL_TOLERANCE NetRateControlTolerance;

			/// <summary>
			/// <para>
			/// If the LimitFlags parameter specifies <c>JOB_OBJECT_NET_LIMIT_RATE_CONTROL</c>, this member specifies the interval during
			/// which a job's network usage is monitored to determine whether the job has exceeded its network rate control limits.
			/// Otherwise, this member is ignored.
			/// </para>
			/// <para>This member can be one of the following values. If no value is specified, <c>ToleranceIntervalShort</c> is used.</para>
			/// <para>
			/// <list type="table">
			/// <listheader>
			/// <term>Value</term>
			/// <term>Meaning</term>
			/// </listheader>
			/// <item>
			/// <term>ToleranceIntervalShort1</term>
			/// <term>The tolerance interval is 10 seconds.</term>
			/// </item>
			/// <item>
			/// <term>ToleranceIntervalMedium2</term>
			/// <term>The tolerance interval is one minute.</term>
			/// </item>
			/// <item>
			/// <term>ToleranceIntervalLong3</term>
			/// <term>The tolerance interval is 10 minutes.</term>
			/// </item>
			/// </list>
			/// </para>
			/// </summary>
			public JOBOBJECT_RATE_CONTROL_TOLERANCE_INTERVAL NetRateControlToleranceInterval;
		}

		/// <summary>
		/// <para>
		/// [JOBOBJECT_SECURITY_LIMIT_INFORMATION is available for use in the operating systems specified in the Requirements section.
		/// Support for this structure was removed starting with Windows Vista. For information, see Remarks.]
		/// </para>
		/// <para>Contains the security limitations for a job object.</para>
		/// </summary>
		// typedef struct _JOBOBJECT_SECURITY_LIMIT_INFORMATION { DWORD SecurityLimitFlags; HANDLE JobToken; PTOKEN_GROUPS SidsToDisable;
		// PTOKEN_PRIVILEGES PrivilegesToDelete; PTOKEN_GROUPS RestrictedSids;} JOBOBJECT_SECURITY_LIMIT_INFORMATION,
		// *PJOBOBJECT_SECURITY_LIMIT_INFORMATION; https://msdn.microsoft.com/en-us/library/windows/desktop/ms684159(v=vs.85).aspx
		[PInvokeData("WinNT.h", MSDNShortId = "ms684159")]
		[StructLayout(LayoutKind.Sequential)]
		public struct JOBOBJECT_SECURITY_LIMIT_INFORMATION
		{
			/// <summary>
			/// <para>The security limitations for the job. This member can be one or more of the following values.</para>
			/// <para>
			/// <list type="table">
			/// <listheader>
			/// <term>Value</term>
			/// <term>Meaning</term>
			/// </listheader>
			/// <item>
			/// <term>JOB_OBJECT_SECURITY_FILTER_TOKENS0x00000008</term>
			/// <term>
			/// Applies a filter to the token when a process impersonates a client. Requires at least one of the following members to be set:
			/// SidsToDisable, PrivilegesToDelete, or RestrictedSids.
			/// </term>
			/// </item>
			/// <item>
			/// <term>JOB_OBJECT_SECURITY_NO_ADMIN0x00000001</term>
			/// <term>Prevents any process in the job from using a token that specifies the local administrators group.</term>
			/// </item>
			/// <item>
			/// <term>JOB_OBJECT_SECURITY_ONLY_TOKEN0x00000004</term>
			/// <term>Forces processes in the job to run under a specific token. Requires a token handle in the JobToken member.</term>
			/// </item>
			/// <item>
			/// <term>JOB_OBJECT_SECURITY_RESTRICTED_TOKEN0x00000002</term>
			/// <term>Prevents any process in the job from using a token that was not created with the CreateRestrictedToken function.</term>
			/// </item>
			/// </list>
			/// </para>
			/// </summary>
			public JOBOBJECT_SECURITY_FLAGS SecurityLimitFlags;

			/// <summary>
			/// <para>A handle to the primary token that represents a user. The handle must have TOKEN_ASSIGN_PRIMARY access.</para>
			/// <para>
			/// If the token was created with <c>CreateRestrictedToken</c>, all processes in the job are limited to that token or a further
			/// restricted token. Otherwise, the caller must have the SE_ASSIGNPRIMARYTOKEN_NAME privilege.
			/// </para>
			/// </summary>
			public HTOKEN JobToken;

			/// <summary>
			/// <para>
			/// A pointer to a <c>TOKEN_GROUPS</c> structure that specifies the SIDs to disable for access checking, if
			/// <c>SecurityLimitFlags</c> is JOB_OBJECT_SECURITY_FILTER_TOKENS.
			/// </para>
			/// <para>This member can be NULL if you do not want to disable any SIDs.</para>
			/// </summary>
			public IntPtr SidsToDisable;

			/// <summary>
			/// <para>
			/// A pointer to a <c>TOKEN_PRIVILEGES</c> structure that specifies the privileges to delete from the token, if
			/// <c>SecurityLimitFlags</c> is JOB_OBJECT_SECURITY_FILTER_TOKENS.
			/// </para>
			/// <para>This member can be NULL if you do not want to delete any privileges.</para>
			/// </summary>
			public IntPtr PrivilegesToDelete;

			/// <summary>
			/// <para>
			/// A pointer to a <c>TOKEN_GROUPS</c> structure that specifies the deny-only SIDs that will be added to the access token, if
			/// <c>SecurityLimitFlags</c> is JOB_OBJECT_SECURITY_FILTER_TOKENS.
			/// </para>
			/// <para>This member can be NULL if you do not want to specify any deny-only SIDs.</para>
			/// </summary>
			public IntPtr RestrictedSids;
		}

		/// <summary>Provides a <see cref="SafeHandle"/> to a job object that releases a created HJOB instance at disposal using CloseHandle.</summary>
		public class SafeHJOB : SafeSyncHandle
		{
			/// <summary>Initializes a new instance of the <see cref="HJOB"/> class and assigns an existing handle.</summary>
			/// <param name="preexistingHandle">An <see cref="IntPtr"/> object that represents the pre-existing handle to use.</param>
			/// <param name="ownsHandle">
			/// <see langword="true"/> to reliably release the handle during the finalization phase; otherwise, <see langword="false"/> (not recommended).
			/// </param>
			public SafeHJOB(IntPtr preexistingHandle, bool ownsHandle = true) : base(preexistingHandle, ownsHandle) { }

			private SafeHJOB() : base()
			{
			}

			/// <summary>Performs an implicit conversion from <see cref="SafeHJOB"/> to <see cref="HJOB"/>.</summary>
			/// <param name="h">The safe handle instance.</param>
			/// <returns>The result of the conversion.</returns>
			public static implicit operator HJOB(SafeHJOB h) => h.handle;
		}
	}
}