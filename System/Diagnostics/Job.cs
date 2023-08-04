using Microsoft.Win32.SafeHandles;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices;
using System.Security.AccessControl;
using Vanara.Extensions;
using Vanara.InteropServices;
using Vanara.PInvoke;
using static Vanara.PInvoke.Kernel32;

namespace Vanara.Diagnostics;

/// <summary>The job limit type exceeded as communicated by a <see cref="JobNotificationEventArgs"/>.</summary>
public enum JobLimit
{
	/// <summary>The <see cref="JobNotifications.IoRateControlTolerance"/> or <see cref="JobNotifications.IoRateControlToleranceInterval"/> value was exceeded.</summary>
	IoRateControlTolerance = JOBOBJECT_LIMIT_FLAGS.JOB_OBJECT_LIMIT_IO_RATE_CONTROL,

	/// <summary>The <see cref="JobNotifications.IoReadBytesLimit"/> value was exceeded.</summary>
	IoReadBytes = JOBOBJECT_LIMIT_FLAGS.JOB_OBJECT_LIMIT_JOB_READ_BYTES,

	/// <summary>The <see cref="JobNotifications.IoWriteBytesLimit"/> value was exceeded.</summary>
	IoWriteBytes = JOBOBJECT_LIMIT_FLAGS.JOB_OBJECT_LIMIT_JOB_WRITE_BYTES,

	/// <summary>The <see cref="JobNotifications.JobLowMemoryLimit"/> value was exceeded.</summary>
	JobLowMemory = JOBOBJECT_LIMIT_FLAGS.JOB_OBJECT_LIMIT_JOB_MEMORY_LOW,

	/// <summary>The <see cref="JobNotifications.JobMemoryLimit"/> value was exceeded.</summary>
	JobMemory = JOBOBJECT_LIMIT_FLAGS.JOB_OBJECT_LIMIT_JOB_MEMORY,

	/// <summary>The <see cref="JobNotifications.NetRateControlTolerance"/> or <see cref="JobNotifications.NetRateControlToleranceInterval"/> value was exceeded.</summary>
	NetRateControlTolerance = JOBOBJECT_LIMIT_FLAGS.JOB_OBJECT_LIMIT_NET_RATE_CONTROL,

	/// <summary>The <see cref="JobNotifications.PerJobUserTimeLimit"/> value was exceeded.</summary>
	PerJobUserTime = JOBOBJECT_LIMIT_FLAGS.JOB_OBJECT_LIMIT_JOB_TIME,

	/// <summary>The <see cref="JobNotifications.RateControlTolerance"/> or <see cref="JobNotifications.RateControlToleranceInterval"/> value was exceeded.</summary>
	RateControlTolerance = JOBOBJECT_LIMIT_FLAGS.JOB_OBJECT_LIMIT_RATE_CONTROL,
}

/// <summary>
/// Represents a system Job Object that allows groups of processes to be managed as a unit. Job objects are nameable, securable, sharable
/// objects that control attributes of the processes associated with them. Operations performed on a job object affect all processes
/// associated with the job object. Examples include enforcing limits such as working set size and process priority or terminating all
/// processes associated with a job. For more information see
/// <a href="https://docs.microsoft.com/en-us/windows/win32/procthread/job-objects">Job Objects</a>.
/// </summary>
/// <seealso cref="System.IDisposable"/>
public class Job : IDisposable
{
	internal SafeHJOB hJob;
	private readonly IoCompletionPort complPort;
	private bool disposedValue = false;
	private JobLimits limits;
	private JobNotifications notifications;
	private JobProcessCollection processes;
	private JobSettings settings;
	private JobStatistics stats;

	private Job(SafeHJOB jobHandle)
	{
		if (jobHandle is null || jobHandle.IsNull)
			throw new ArgumentNullException(nameof(jobHandle));
		hJob = jobHandle;

		// Create completion port
		complPort = IoCompletionPort.Create();
		complPort.AddKeyHandler(hJob.DangerousGetHandle(), FireEventThread);
		AssociateCompletionPort(complPort.Handle, hJob.DangerousGetHandle());
	}

	/// <summary>Finalizes an instance of the <see cref="Job"/> class.</summary>
	~Job() => Dispose(false);

	/// <summary>Action with a parameter passed by reference.</summary>
	/// <typeparam name="T">The parameter type.</typeparam>
	/// <param name="t1">The first parameter value.</param>
	internal delegate void RefAction<T>(ref T t1);

	/// <summary>Function with parameter passed by reference.</summary>
	/// <typeparam name="T1">The type of the parameter.</typeparam>
	/// <typeparam name="T2">The type of the return value.</typeparam>
	/// <param name="t1">The type instance on which to act.</param>
	/// <returns>The return value.</returns>
	internal delegate T2 RefFunc<T1, T2>(ref T1 t1);

	/// <summary>
	/// Indicates that a process associated with the job exited with an exit code that indicates an abnormal exit (see the list following
	/// this table).
	/// </summary>
	public event EventHandler<JobEventArgs> AbnormalProcessExit;

	/// <summary>
	/// Indicates that the active process count has been decremented to 0. For example, if the job currently has two active processes,
	/// the system sends this message after they both terminate.
	/// </summary>
	public event EventHandler<JobEventArgs> ActiveProcessCountZero;

	/// <summary>Indicates that the active process limit has been exceeded.</summary>
	public event EventHandler<JobEventArgs> ActiveProcessLimitExceeded;

	/// <summary>
	/// Indicates that the Settings property <see cref="JobSettings.TerminateProcessesAtEndOfJobTimeLimit"/> is set to
	/// <see langword="false"/> and the end-of-job time limit has been reached. Upon posting this message, the time limit is canceled and
	/// the job's processes can continue to run.
	/// </summary>
	public event EventHandler<JobEventArgs> EndOfJobTime;

	/// <summary>
	/// Indicates that a process has exceeded a per-process time limit. The system sends this message after the process termination has
	/// been requested.
	/// </summary>
	public event EventHandler<JobEventArgs> EndofProcessTime;

	/// <summary>
	/// Indicates that a process associated with the job caused the job to exceed the job-wide memory limit (if one is in effect). The
	/// system does not send this message if the process has not yet reported its process identifier.
	/// </summary>
	public event EventHandler<JobEventArgs> JobMemoryLimitExceeded;

	/// <summary>
	/// Indicates that a process associated with a job that has registered for resource limit notifications has exceeded one or more
	/// limits. The system does not send this message if the process has not yet reported its process identifier.
	/// </summary>
	public event EventHandler<JobNotificationEventArgs> JobNotificationLimitExceeded;

	/// <summary>
	/// Indicates that a process has been added to the job. Processes added to a job at the time a completion port is associated are also reported.
	/// </summary>
	public event EventHandler<JobEventArgs> NewProcess;

	/// <summary>Indicates that a process associated with the job has exited.</summary>
	public event EventHandler<JobEventArgs> ProcessExited;

	/// <summary>
	/// Indicates that a process associated with the job has exceeded its memory limit (if one is in effect). The system does not send
	/// this message if the process has not yet reported its process identifier.
	/// </summary>
	public event EventHandler<JobEventArgs> ProcessMemoryLimitExceeded;

	/// <summary>Exposes the handle (HJOB) of the job.</summary>
	/// <value>The handle.</value>
	public IntPtr Handle => hJob.DangerousGetHandle();

	/// <summary>Notification limits that can be set for various properties.</summary>
	/// <value>The notifications.</value>
	public JobNotifications Notifications => notifications ?? (notifications = new JobNotifications(this));

	/// <summary>Gets the processes assigned to this job.</summary>
	/// <value>The process list for the job.</value>
	public IReadOnlyCollection<Process> Processes => processes ?? (processes = new JobProcessCollection(this));

	/// <summary>Gets or sets the list of processor groups to which the job is currently assigned.</summary>
	public IEnumerable<ushort> ProcessorGroups
	{
		get
		{
			using var mem = new SafeHGlobalHandle(4);
			uint req;
			while (!QueryInformationJobObject(hJob, JOBOBJECTINFOCLASS.JobObjectGroupInformation, mem, mem.Size, out req))
			{
				Win32Error.ThrowLastErrorUnless(Win32Error.ERROR_MORE_DATA);
				mem.Size = req;
			}
			return mem.ToEnumerable<ushort>((int)req / 2).TakeWhile(id => id > 0);
		}
		set
		{
			using var mem = SafeHGlobalHandle.CreateFromList(value);
			if (!SetInformationJobObject(hJob, JOBOBJECTINFOCLASS.JobObjectGroupInformation, mem, mem.Size))
				Win32Error.ThrowLastError();
		}
	}

	/// <summary>Gets the hard limits for different runtime values of the job object.</summary>
	/// <value>The runtime limits.</value>
	public JobLimits RuntimeLimits => limits ?? (limits = new JobLimits(this));

	/// <summary>Gets the job settings.</summary>
	/// <value>The job settings.</value>
	public JobSettings Settings => settings ?? (settings = new JobSettings(this));

	/// <summary>Usage statistics for the job.</summary>
	/// <value>Usage statistics.</value>
	public JobStatistics Statistics => stats ?? (stats = new JobStatistics(this));

	/// <summary>Creates or opens a job object.</summary>
	/// <param name="jobName">
	/// <para>The name of the job. The name is limited to <c>MAX_PATH</c> characters. Name comparison is case-sensitive.</para>
	/// <para>If lpName is <see langword="null"/>, the job is created without a name.</para>
	/// <para>
	/// If lpName matches the name of an existing event, semaphore, mutex, waitable timer, or file-mapping object, the function fails and
	/// an exception corresponding to <c>ERROR_INVALID_HANDLE</c> is thrown. This occurs because these objects share the same namespace.
	/// </para>
	/// <para>The object can be created in a private namespace. For more information, see Object Namespaces.</para>
	/// <para>
	/// <c>Terminal Services:</c> The name can have a "Global" or "Local" prefix to explicitly create the object in the global or session
	/// namespace. The remainder of the name can contain any character except the backslash character (). For more information, see
	/// Kernel Object Namespaces.
	/// </para>
	/// </param>
	/// <param name="jobSecurity">
	/// An optional <see cref="JobSecurity"/> instance that specifies the security descriptor for the job object and determines whether
	/// child processes can inherit the returned handle. If <see langword="null"/>, the job object gets a default security descriptor and
	/// the handle cannot be inherited. The ACLs in the default security descriptor for a job object come from the primary or
	/// impersonation token of the creator.
	/// </param>
	/// <param name="inheritable">
	/// If this value is <see cref="HandleInheritability.Inheritable"/>, processes created by this process will inherit the handle.
	/// Otherwise, the processes do not inherit this handle.
	/// </param>
	/// <returns>
	/// If the function succeeds, the return value is a <see cref="Job"/> object. The handle has the <c>JOB_OBJECT_ALL_ACCESS</c> access right.
	/// </returns>
	/// <remarks>
	/// <para>
	/// When a job is created, its accounting information is initialized to zero, all limits are inactive, and there are no associated
	/// processes. To assign a process to a job object, use the AssignProcessToJobObject function. To get or set limits for a job, use
	/// the object's properties.
	/// </para>
	/// <para>
	/// All processes associated with a job must run in the same session. A job is associated with the session of the first process to be
	/// assigned to the job.
	/// </para>
	/// <para><c>Windows Server 2003 and Windows XP:</c> A job is associated with the session of the process that created it.</para>
	/// <para>
	/// If the job has the KillOnJobClose property set to <see langword="true"/>, closing the last job object handle terminates all
	/// associated processes and then destroys the job object itself.
	/// </para>
	/// </remarks>
	public static Job Create(string jobName = null, JobSecurity jobSecurity = null, HandleInheritability inheritable = HandleInheritability.None)
	{
		var sa = GetSecAttr(jobSecurity, inheritable == HandleInheritability.Inheritable, out var hMem);
		var job = new Job(CreateJobObject(sa, jobName));
		hMem?.Dispose();
		return job;
	}

	/// <summary>Performs an implicit conversion from <see cref="Job"/> to <see cref="HJOB"/>.</summary>
	/// <param name="job">The job.</param>
	/// <returns>The result of the conversion.</returns>
	public static implicit operator HJOB(Job job) => job.hJob;

	/// <summary>Performs an implicit conversion from <see cref="Job"/> to <see cref="SafeWaitHandle"/>.</summary>
	/// <param name="job">The Job instance.</param>
	/// <returns>The result of the conversion.</returns>
	public static implicit operator SafeWaitHandle(Job job) => new SafeWaitHandle(job.hJob.DangerousGetHandle(), false);

	/// <summary>Opens an existing job object.</summary>
	/// <param name="jobName">
	/// <para>The name of the job to be opened. Name comparisons are case sensitive.</para>
	/// <para>This function can open objects in a private namespace. For more information, see Object Namespaces.</para>
	/// <para>
	/// <c>Terminal Services:</c> The name can have a "Global\" or "Local\" prefix to explicitly open the object in the global or session
	/// namespace. The remainder of the name can contain any character except the backslash character (\). For more information, see
	/// Kernel Object Namespaces.
	/// </para>
	/// </param>
	/// <param name="desiredAccess">
	/// The access to the job object. This parameter can be one or more of the job object access rights. This access right is checked
	/// against any security descriptor for the object.
	/// </param>
	/// <param name="inheritable">
	/// If this value is <see cref="HandleInheritability.Inheritable"/>, processes created by this process will inherit the handle.
	/// Otherwise, the processes do not inherit this handle.
	/// </param>
	/// <returns>If the function succeeds, the return value is a <see cref="Job"/> object.</returns>
	public static Job Open(string jobName, JobAccessRight desiredAccess = JobAccessRight.JOB_OBJECT_ALL_ACCESS, HandleInheritability inheritable = HandleInheritability.None) =>
		new Job(OpenJobObject((uint)desiredAccess, inheritable == HandleInheritability.Inheritable, jobName));

	/// <summary>Assigns a process to an existing job object.</summary>
	/// <param name="process">
	/// <para>
	/// The process to associate with the job object. The process must have the PROCESS_SET_QUOTA and PROCESS_TERMINATE access rights.
	/// </para>
	/// <para>
	/// If the process is already associated with a job, this job must be empty or it must be in the hierarchy of nested jobs to which
	/// the process already belongs, and it cannot have UI limits set.
	/// </para>
	/// <para>
	/// <c>Windows 7, Windows Server 2008 R2, Windows XP with SP3, Windows Server 2008, Windows Vista and Windows Server 2003:</c> The
	/// process must not already be assigned to a job; if it is, the function fails with <see cref="AccessViolationException"/>. This
	/// behavior changed starting in Windows 8 and Windows Server 2012.
	/// </para>
	/// <para><c>Terminal Services:</c> All processes within a job must run within the same session as the job.</para>
	/// </param>
	public void AssignProcess(Process process)
	{
		if (process is null) throw new ArgumentNullException(nameof(process));
		CheckState();
		if (!AssignProcessToJobObject(hJob, process))
			Win32Error.ThrowLastError();
	}

	/// <summary>Associates a completion port with this job. You can associate one completion port with a job.</summary>
	/// <param name="completionPort">
	/// The completion port to use in the CompletionPort parameter of the PostQueuedCompletionStatus function when messages are sent on
	/// behalf of the job.
	/// <para>
	/// Windows 8, Windows Server 2012, Windows 8.1, Windows Server 2012 R2, Windows 10 and Windows Server 2016: Specify
	/// <see cref="HANDLE.NULL"/> to remove the association between the current completion port and the job.
	/// </para>
	/// </param>
	/// <param name="key">
	/// The value to use in the dwCompletionKey parameter of PostQueuedCompletionStatus when messages are sent on behalf of the job.
	/// </param>
	public void AssociateCompletionPort(HANDLE completionPort, IntPtr key = default) =>
		CheckThenSet((ref JOBOBJECT_ASSOCIATE_COMPLETION_PORT i) => { i.CompletionKey = key; i.CompletionPort = completionPort; });

	/// <summary>Determines whether the process is running in this job.</summary>
	/// <param name="process">
	/// The process to be tested. The handle must have the PROCESS_QUERY_INFORMATION or PROCESS_QUERY_LIMITED_INFORMATION access right.
	/// </param>
	/// <returns><see langword="true"/> if the job contains the specified process; otherwise, <see langword="false"/>.</returns>
	public bool ContainsProcess(Process process)
	{
		if (process is null) throw new ArgumentNullException(nameof(process));
		CheckState();
		if (!IsProcessInJob(process, hJob, out var isIn))
			Win32Error.ThrowLastError();
		return isIn;
	}

	/// <summary>Performs application-defined tasks associated with freeing, releasing, or resetting unmanaged resources.</summary>
	public void Dispose()
	{
		Dispose(true);
		GC.SuppressFinalize(this);
	}

	/// <summary>Gets information about the control of the I/O rate for a job object.</summary>
	/// <param name="VolumeName">
	/// The name of the volume to query. If this value is <see langword="null"/>, the function gets the information about I/O rate
	/// control for the job for all of the volumes for the system.
	/// </param>
	/// <returns>
	/// An array of <c>JOBOBJECT_IO_RATE_CONTROL_INFORMATION</c> structures that contain the information about I/O rate control for the job.
	/// </returns>
	public JOBOBJECT_IO_RATE_CONTROL_INFORMATION[] GetIoRateControlInformation(string VolumeName = null) =>
		QueryIoRateControlInformationJobObject(hJob, VolumeName);

	/// <summary>
	/// Grants or denies access to a handle to a User object to a job that has a user-interface restriction. When access is granted, all
	/// processes associated with the job can subsequently recognize and use the handle. When access is denied, the processes can no
	/// longer use the handle. For more information see User Objects.
	/// </summary>
	/// <param name="hUserObj">A handle to the User object.</param>
	/// <param name="grant">
	/// If this parameter is <see langword="true"/>, all processes associated with the job can recognize and use the handle. If the
	/// parameter is <see langword="false"/>, the processes cannot use the handle.
	/// </param>
	/// <exception cref="NotImplementedException"></exception>
	/// <remarks>
	/// <para>
	/// The <c>GrantUserAccess</c> function can be called only from a process not associated with the job specified by the hJob
	/// parameter. The User handle must not be owned by a process or thread associated with the job.
	/// </para>
	/// <para>To create user-interface restrictions, user the <see cref="JobSettings.UIRestrictionsClass"/> property.</para>
	/// </remarks>
	public void GrantUserAccess(IUserHandle hUserObj, bool grant)
	{
		if (!User32.UserHandleGrantAccess(hUserObj.DangerousGetHandle(), hJob, grant))
			Win32Error.ThrowLastError();
	}

	/// <summary>
	/// Starts a process resource by specifying the name of an application and a set of command-line arguments, and associates the
	/// resource with a new Process component which is assigned to this job.
	/// </summary>
	/// <param name="filename">The name of an application file to run in the process.</param>
	/// <param name="arguments">Command-line arguments to pass when starting the process.</param>
	/// <returns>
	/// A new <see cref="Process"/> that is associated with the process resource, or <see langword="null"/> if no process resource is
	/// started. Note that a new process that's started alongside already running instances of the same process will be independent from
	/// the others. In addition, Start may return a non-null Process with its <see cref="Process.HasExited"/> property already set to
	/// <see langword="true"/>. In this case, the started process may have activated an existing instance of itself and then exited.
	/// </returns>
	public Process StartProcess(string filename, string arguments = null) => !string.IsNullOrEmpty(filename) ? StartProcess(new ProcessStartInfo(filename, arguments)) : throw new ArgumentNullException(nameof(filename));

	/// <summary>
	/// Starts the process resource that is specified by the parameter containing process start information (for example, the file name
	/// of the process to start) and associates the resource with a new Process component which is assigned to this job.
	/// </summary>
	/// <param name="startInfo">
	/// The <see cref="ProcessStartInfo"/> that contains the information that is used to start the process, including the file name and
	/// any command-line arguments.
	/// </param>
	/// <returns>
	/// A new <see cref="Process"/> that is associated with the process resource, or <see langword="null"/> if no process resource is
	/// started. Note that a new process that's started alongside already running instances of the same process will be independent from
	/// the others. In addition, Start may return a non-null Process with its <see cref="Process.HasExited"/> property already set to
	/// <see langword="true"/>. In this case, the started process may have activated an existing instance of itself and then exited.
	/// </returns>
	public Process StartProcess(ProcessStartInfo startInfo)
	{
		startInfo.UseShellExecute = false;
		var proc = new Process { StartInfo = startInfo };
		proc.StartEx(CREATE_PROCESS.CREATE_SUSPENDED);
		try
		{
			AssignProcess(proc);
		}
		catch
		{
			proc.Kill();
			throw;
		}
		proc.ResumePrimaryThread();
		return proc;
	}

	/// <summary>
	/// Terminates all processes currently associated with the job. If the job is nested, this function terminates all processes
	/// currently associated with the job and all of its child jobs in the hierarchy.
	/// </summary>
	/// <param name="exitCode">The exit code to be used by all processes and threads in the job object.</param>
	public void TerminateAllProcesses(uint exitCode = 0)
	{
		CheckState();
		if (!TerminateJobObject(hJob, exitCode))
			Win32Error.ThrowLastError();
	}

	internal static SECURITY_ATTRIBUTES GetSecAttr(JobSecurity sec, bool inheritable, out ISafeMemoryHandle hMem)
	{
		hMem = null;
		if (sec is null && !inheritable) return null;
		hMem = new SafeHGlobalHandle(sec.GetSecurityDescriptorBinaryForm());
		return new SECURITY_ATTRIBUTES
		{
			bInheritHandle = inheritable,
			lpSecurityDescriptor = hMem.DangerousGetHandle()
		};
	}

	internal void CheckState()
	{
		if (disposedValue)
			throw new InvalidOperationException("Object has been disposed.");
	}

	internal T CheckThenGet<T>(JOBOBJECTINFOCLASS iClass = 0) where T : struct => CheckThenGet<T, T>(n => n, iClass);

	internal T CheckThenGet<T, T2>(Func<T2, T> func, JOBOBJECTINFOCLASS iClass = 0) where T2 : struct
	{
		CheckState();
		if (iClass == 0 && !CorrespondingTypeAttribute.CanGet<T2, JOBOBJECTINFOCLASS>(out iClass))
			throw new InvalidOperationException("Invalid property retrieval.");
		var n = QueryInformationJobObject<T2>(hJob, iClass);
		return func(n);
	}

	internal void CheckThenSet<T>(RefAction<T> action, JOBOBJECTINFOCLASS iClass = 0) where T : struct
	{
		CheckState();
		if (iClass == 0 && !CorrespondingTypeAttribute.CanSet<T, JOBOBJECTINFOCLASS>(out iClass))
			throw new InvalidOperationException("Invalid property retrieval.");
		var info = CorrespondingTypeAttribute.CanGet(iClass, typeof(T)) ? QueryInformationJobObject<T>(hJob, iClass) : default;
		action?.Invoke(ref info);
		SetInformationJobObject(hJob, iClass, info);
	}

	/// <summary>Releases unmanaged and - optionally - managed resources.</summary>
	/// <param name="disposing">
	/// <see langword="true"/> to release both managed and unmanaged resources; <see langword="false"/> to release only unmanaged resources.
	/// </param>
	protected virtual void Dispose(bool disposing)
	{
		if (!disposedValue)
		{
			if (disposing)
			{
				limits?.Dispose();
				notifications?.Dispose();
				processes?.Dispose();
				settings?.Dispose();
				stats?.Dispose();
			}

			// Close the completion port handle
			complPort.Dispose();

			// Close the job.
			hJob.Dispose();
			disposedValue = true;
		}
	}

	private void FireEventThread(uint msg, IntPtr key, IntPtr ppid)
	{
		if (disposedValue) return;
		var t = new JobEventArgs((JOB_OBJECT_MSG)msg, ppid.ToInt32());
		switch (t.JobMessage)
		{
			case JOB_OBJECT_MSG.JOB_OBJECT_MSG_END_OF_JOB_TIME:
				EndOfJobTime?.Invoke(this, t);
				break;

			case JOB_OBJECT_MSG.JOB_OBJECT_MSG_END_OF_PROCESS_TIME:
				EndofProcessTime?.Invoke(this, t);
				break;

			case JOB_OBJECT_MSG.JOB_OBJECT_MSG_ACTIVE_PROCESS_LIMIT:
				ActiveProcessLimitExceeded?.Invoke(this, t);
				break;

			case JOB_OBJECT_MSG.JOB_OBJECT_MSG_ACTIVE_PROCESS_ZERO:
				ActiveProcessCountZero?.Invoke(this, t);
				break;

			case JOB_OBJECT_MSG.JOB_OBJECT_MSG_NEW_PROCESS:
				NewProcess?.Invoke(this, t);
				break;

			case JOB_OBJECT_MSG.JOB_OBJECT_MSG_EXIT_PROCESS:
				ProcessExited?.Invoke(this, t);
				break;

			case JOB_OBJECT_MSG.JOB_OBJECT_MSG_ABNORMAL_EXIT_PROCESS:
				AbnormalProcessExit?.Invoke(this, t);
				break;

			case JOB_OBJECT_MSG.JOB_OBJECT_MSG_PROCESS_MEMORY_LIMIT:
				ProcessMemoryLimitExceeded?.Invoke(this, t);
				break;

			case JOB_OBJECT_MSG.JOB_OBJECT_MSG_JOB_MEMORY_LIMIT:
				JobMemoryLimitExceeded?.Invoke(this, t);
				break;

			case JOB_OBJECT_MSG.JOB_OBJECT_MSG_NOTIFICATION_LIMIT:
				var vi = GetViolation();
				Debug.WriteLine($"Notification: {vi.ViolationLimitFlags}");
				foreach (var l in vi.ViolationLimitFlags.GetFlags().Cast<JobLimit>())
				{
					object v = null, n = null;
					switch (l)
					{
						case JobLimit.JobMemory:
							v = vi.JobMemory;
							n = vi.JobMemoryLimit;
							break;

						case JobLimit.PerJobUserTime:
							v = vi.PerJobUserTime;
							n = vi.PerJobUserTimeLimit;
							break;

						case JobLimit.IoReadBytes:
							v = vi.IoReadBytes;
							n = vi.IoReadBytesLimit;
							break;

						case JobLimit.IoWriteBytes:
							v = vi.IoWriteBytes;
							n = vi.IoWriteBytesLimit;
							break;

						case JobLimit.RateControlTolerance:
							v = vi.RateControlTolerance;
							n = vi.RateControlToleranceLimit;
							break;

						case JobLimit.IoRateControlTolerance:
							v = vi.IoRateControlTolerance;
							n = vi.IoRateControlToleranceLimit;
							break;

						case JobLimit.JobLowMemory:
							v = vi.JobMemory;
							n = vi.JobLowMemoryLimit;
							break;

						case JobLimit.NetRateControlTolerance:
							v = vi.NetRateControlTolerance;
							n = vi.NetRateControlToleranceLimit;
							break;

						default:
							Debug.WriteLine($"Unable to process notification: {vi.ViolationLimitFlags}, {vi.LimitFlags}");
							continue;
					}
					JobNotificationLimitExceeded?.Invoke(this, new JobNotificationEventArgs(t.JobMessage, t.ProcessId, l, v, n));
				}
				break;

			default:
				break;
		}

		JOBOBJECT_LIMIT_VIOLATION_INFORMATION_2 GetViolation()
		{
			using var mem = SafeHeapBlock.CreateFromStructure<JOBOBJECT_LIMIT_VIOLATION_INFORMATION_2>();
			if (!QueryInformationJobObject(hJob, JOBOBJECTINFOCLASS.JobObjectLimitViolationInformation2, mem, mem.Size, out _))
			{
				Debug.WriteLine($"Failed to get JOBOBJECT_LIMIT_VIOLATION_INFORMATION_2: {Win32Error.GetLastError()}");
				if (!QueryInformationJobObject(hJob, JOBOBJECTINFOCLASS.JobObjectLimitViolationInformation, mem, (uint)Marshal.SizeOf(typeof(JOBOBJECT_LIMIT_VIOLATION_INFORMATION)), out _))
					Debug.WriteLine($"Failed to get JOBOBJECT_LIMIT_VIOLATION_INFORMATION: {Win32Error.GetLastError()}");
			}
			return mem.ToStructure<JOBOBJECT_LIMIT_VIOLATION_INFORMATION_2>();
		}
	}

	internal class JobProcessCollection : JobHelper, IReadOnlyCollection<Process>
	{
		public JobProcessCollection(Job j) : base(j)
		{
		}

		/// <summary>
		/// The total number of processes currently associated with the job. When a process is associated with a job, but the association
		/// fails because of a limit violation, this value is temporarily incremented. When the terminated process exits and all
		/// references to the process are released, this value is decremented.
		/// </summary>
		public int Count => (int)job.CheckThenGet<JOBOBJECT_BASIC_ACCOUNTING_INFORMATION>().ActiveProcesses;

		public IEnumerator<Process> GetEnumerator() => new Enumerator(job);

		IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();

		private class Enumerator : IEnumerator<Process>
		{
			private int i;
			private Job job;
			private Process[] procs;

			public Enumerator(Job j)
			{
				job = j;
				Reset();
			}

			public Process Current => procs[i];

			object IEnumerator.Current => Current;

			public void Dispose() => job = null;

			public bool MoveNext() => ++i < procs.Length;

			public void Reset()
			{
				i = -1;
				using var mem = SafeHGlobalHandle.CreateFromStructure<JOBOBJECT_BASIC_PROCESS_ID_LIST>();
				while (!QueryInformationJobObject(job, JOBOBJECTINFOCLASS.JobObjectBasicProcessIdList, mem.DangerousGetHandle(), mem.Size, out _))
				{
					Win32Error.ThrowLastErrorUnless(Win32Error.ERROR_MORE_DATA);
					mem.Size *= 2;
				}
				var l = mem.ToStructure<uint>();
				procs = mem.ToEnumerable<UIntPtr>((int)l, 8).Select(p => { try { return Process.GetProcessById((int)p.ToUInt32()); } catch { return null; } }).Where(p => p != null).ToArray();
			}
		}
	}
}

/// <summary>Contains information about a job object message.</summary>
/// <seealso cref="System.EventArgs"/>
public class JobEventArgs : EventArgs
{
	internal JobEventArgs(JOB_OBJECT_MSG msg, int id = 0)
	{
		JobMessage = msg;
		ProcessId = id;
	}

	/// <summary>Gets the type of job message posted.</summary>
	/// <value>The job message.</value>
	public JOB_OBJECT_MSG JobMessage { get; }

	/// <summary>Gets the process identifier of the process referred to by the message.</summary>
	/// <value>The process identifier. This value can be 0.</value>
	public int ProcessId { get; }
}

/// <summary>Base class for other classes that support the <see cref="Job"/> object.</summary>
/// <seealso cref="System.IDisposable"/>
public abstract class JobHelper : IDisposable
{
	/// <summary>The job object.</summary>
	protected Job job;

	/// <summary>Initializes a new instance of the <see cref="JobHelper"/> class.</summary>
	/// <param name="jobName">Name of the job.</param>
	protected JobHelper(string jobName) : this(Job.Open(jobName, JobAccessRight.JOB_OBJECT_QUERY | JobAccessRight.JOB_OBJECT_SET_ATTRIBUTES)) { }

	/// <summary>Initializes a new instance of the <see cref="JobHelper"/> class.</summary>
	/// <param name="job">The job.</param>
	protected JobHelper(Job job) => this.job = job;

	/// <summary>Performs application-defined tasks associated with freeing, releasing, or resetting unmanaged resources.</summary>
	public virtual void Dispose() => job = null;

	/// <summary>Gets field values from JOBOBJECT_BASIC_LIMIT_INFORMATION.</summary>
	/// <typeparam name="T">The return type.</typeparam>
	/// <param name="flag">The limit flag.</param>
	/// <param name="getter">The method to get the field.</param>
	/// <returns>The value.</returns>
	internal T? GetBasic<T>(JOBOBJECT_LIMIT_FLAGS flag, Func<JOBOBJECT_BASIC_LIMIT_INFORMATION, T> getter) where T : struct =>
		job.CheckThenGet<T?, JOBOBJECT_BASIC_LIMIT_INFORMATION>(n => n.LimitFlags.IsFlagSet(flag) ? (T?)getter(n) : null);

	/// <summary>Sets a field value in JOBOBJECT_BASIC_LIMIT_INFORMATION.</summary>
	/// <typeparam name="T">The field type.</typeparam>
	/// <param name="flag">The limit flag.</param>
	/// <param name="value">The value.</param>
	/// <param name="setter">The method to set the field.</param>
	internal void SetBasic<T>(JOBOBJECT_LIMIT_FLAGS flag, T? value, Job.RefAction<JOBOBJECT_BASIC_LIMIT_INFORMATION> setter) where T : struct =>
		job.CheckThenSet((ref JOBOBJECT_BASIC_LIMIT_INFORMATION i) => { i.LimitFlags = (JOBOBJECT_LIMIT_FLAGS)0xFF & i.LimitFlags.SetFlags(flag, value.HasValue); setter(ref i); });
}

/// <summary>Settings for <see cref="Job"/> that set limits for different runtime values.</summary>
/// <seealso cref="Vanara.Diagnostics.JobHelper"/>
public class JobLimits : JobHelper
{
	/// <summary>Initializes a new instance of the <see cref="JobLimits"/> class.</summary>
	/// <param name="jobName">Name of the job.</param>
	public JobLimits(string jobName) : base(jobName) { }

	/// <summary>Initializes a new instance of the <see cref="JobLimits"/> class.</summary>
	/// <param name="job">The job.</param>
	public JobLimits(Job job) : base(job) { }

	/// <summary>
	/// <para>Gets or sets the active process limit for the job.</para>
	/// <para>
	/// If you try to associate a process with a job, and this causes the active process count to exceed this limit, the process is
	/// terminated and the association fails.
	/// </para>
	/// </summary>
	public uint? ActiveProcessLimit
	{
		get => GetBasic(JOBOBJECT_LIMIT_FLAGS.JOB_OBJECT_LIMIT_ACTIVE_PROCESS, n => n.ActiveProcessLimit);
		set => SetBasic(JOBOBJECT_LIMIT_FLAGS.JOB_OBJECT_LIMIT_ACTIVE_PROCESS, value, (ref JOBOBJECT_BASIC_LIMIT_INFORMATION i) => i.ActiveProcessLimit = value.GetValueOrDefault());
	}

	/// <summary>
	/// Gets or sets the job's CPU rate as a hard limit. If set, after the job reaches its CPU cycle limit for the current scheduling
	/// interval, no threads associated with the job will run until the next interval.
	/// </summary>
	/// <value>
	/// Specifies the portion of processor cycles that the threads in a job object can use during each scheduling interval, as a
	/// percentage of cycles. This value is greater than 0.0 and less than equal to 100.0. If this value is <see langword="null"/>, then
	/// this setting is disabled.
	/// </value>
	/// <exception cref="ArgumentOutOfRangeException">Value must be greater than 0.0 and less than equal to 100.0.</exception>
	public double? CpuRateLimit
	{
		get => job.CheckThenGet((JOBOBJECT_CPU_RATE_CONTROL_INFORMATION n) =>
			n.ControlFlags.IsFlagSet(JOB_OBJECT_CPU_RATE_CONTROL_FLAGS.JOB_OBJECT_CPU_RATE_CONTROL_HARD_CAP | JOB_OBJECT_CPU_RATE_CONTROL_FLAGS.JOB_OBJECT_CPU_RATE_CONTROL_ENABLE)
				? n.Union.CpuRate / 100.0 : (double?)null);
		set
		{
			if (value.HasValue && (value.Value <= 0.0 || value.Value > 100.0))
				throw new ArgumentOutOfRangeException(nameof(CpuRateLimit));
			job.CheckThenSet((ref JOBOBJECT_CPU_RATE_CONTROL_INFORMATION i) =>
			{
				i.ControlFlags = i.ControlFlags.SetFlags(JOB_OBJECT_CPU_RATE_CONTROL_FLAGS.JOB_OBJECT_CPU_RATE_CONTROL_HARD_CAP | JOB_OBJECT_CPU_RATE_CONTROL_FLAGS.JOB_OBJECT_CPU_RATE_CONTROL_ENABLE, value.HasValue);
				i.Union.CpuRate = value.HasValue ? (uint)(value.Value * 100) : 0;
			});
		}
	}

	/// <summary>Gets or sets the CPU rate for the job as limited by minimum and maximum rates.</summary>
	/// <value>
	/// <para>
	/// Specifies the minimum and maximum portions of the processor cycles that the threads in a job object can reserve during each
	/// scheduling interval. Specify these rates as a percentage from 0.0 to 100.0.
	/// </para>
	/// <para>
	/// For the minimum rates to work correctly, the sum of the minimum rates for all of the job objects in the system cannot exceed
	/// 100%. After the job reaches the maximum limit for a scheduling interval, no threads associated with the job can run until the
	/// next scheduling interval.
	/// </para>
	/// <para>If this value is <see langword="null"/>, then this setting is disabled.</para>
	/// </value>
	/// <exception cref="ArgumentOutOfRangeException">
	/// Values must be greater than or equal to 0.0 and less than equal to 100.0 and the minimum value must be less than the maximum value.
	/// </exception>
	public (double minPortion, double maxPortion)? CpuRatePortion
	{
		get => job.CheckThenGet((JOBOBJECT_CPU_RATE_CONTROL_INFORMATION n) =>
			n.ControlFlags.IsFlagSet(JOB_OBJECT_CPU_RATE_CONTROL_FLAGS.JOB_OBJECT_CPU_RATE_CONTROL_MIN_MAX_RATE | JOB_OBJECT_CPU_RATE_CONTROL_FLAGS.JOB_OBJECT_CPU_RATE_CONTROL_ENABLE)
				? (n.Union.MinRate / 100.0, n.Union.MaxRate / 100.0) : ((double, double)?)null);
		set
		{
			if (value.HasValue && (value.Value.minPortion < 0.0 || value.Value.minPortion > 100.0 || value.Value.maxPortion < 0.0 || value.Value.maxPortion > 100.0 || value.Value.minPortion > value.Value.maxPortion))
				throw new ArgumentOutOfRangeException(nameof(CpuRatePortion));
			job.CheckThenSet((ref JOBOBJECT_CPU_RATE_CONTROL_INFORMATION i) =>
			{
				i.ControlFlags = i.ControlFlags.SetFlags(JOB_OBJECT_CPU_RATE_CONTROL_FLAGS.JOB_OBJECT_CPU_RATE_CONTROL_MIN_MAX_RATE | JOB_OBJECT_CPU_RATE_CONTROL_FLAGS.JOB_OBJECT_CPU_RATE_CONTROL_ENABLE, value.HasValue);
				i.Union.MinRate = value.HasValue ? (ushort)(value.Value.minPortion * 100) : (ushort)0;
				i.Union.MaxRate = value.HasValue ? (ushort)(value.Value.maxPortion * 100) : (ushort)0;
			});
		}
	}

	/// <summary>Gets or sets the job's CPU rate when calculated based on its relative weight to the weight of other jobs.</summary>
	/// <value>
	/// <para>
	/// Specifies the scheduling weight of the job object, which determines the share of processor time given to the job relative to
	/// other workloads on the processor.
	/// </para>
	/// <para>
	/// This member can be a value from 1 through 9, where 1 is the smallest share and 9 is the largest share. The default is 5, which
	/// should be used for most workloads.
	/// </para>
	/// <para>If this value is <see langword="null"/>, then this setting is disabled.</para>
	/// </value>
	/// <exception cref="ArgumentOutOfRangeException">weight1to9</exception>
	public int? CpuRateRelativeWeight
	{
		get => job.CheckThenGet((JOBOBJECT_CPU_RATE_CONTROL_INFORMATION n) =>
			n.ControlFlags.IsFlagSet(JOB_OBJECT_CPU_RATE_CONTROL_FLAGS.JOB_OBJECT_CPU_RATE_CONTROL_WEIGHT_BASED | JOB_OBJECT_CPU_RATE_CONTROL_FLAGS.JOB_OBJECT_CPU_RATE_CONTROL_ENABLE)
				? (int)n.Union.Weight : (int?)null);
		set
		{
			if (value.HasValue && (value.Value < 1 || value.Value > 9))
				throw new ArgumentOutOfRangeException(nameof(CpuRateRelativeWeight));
			job.CheckThenSet((ref JOBOBJECT_CPU_RATE_CONTROL_INFORMATION i) =>
			{
				i.ControlFlags = i.ControlFlags.SetFlags(JOB_OBJECT_CPU_RATE_CONTROL_FLAGS.JOB_OBJECT_CPU_RATE_CONTROL_WEIGHT_BASED | JOB_OBJECT_CPU_RATE_CONTROL_FLAGS.JOB_OBJECT_CPU_RATE_CONTROL_ENABLE, value.HasValue);
				i.Union.Weight = value.HasValue ? (uint)value.Value : 0;
			});
		}
	}

	/// <summary>
	/// Gets or sets the limit for the virtual memory that can be committed for the job.
	/// <para>If this value is <see langword="null"/>, then this setting is disabled.</para>
	/// </summary>
	public ulong? JobMemoryLimit
	{
		get => job.CheckThenGet((JOBOBJECT_EXTENDED_LIMIT_INFORMATION n) =>
			n.BasicLimitInformation.LimitFlags.IsFlagSet(JOBOBJECT_LIMIT_FLAGS.JOB_OBJECT_LIMIT_JOB_MEMORY) ? (ulong?)n.JobMemoryLimit : null);
		set => job.CheckThenSet((ref JOBOBJECT_EXTENDED_LIMIT_INFORMATION i) => { i.BasicLimitInformation.LimitFlags = i.BasicLimitInformation.LimitFlags.SetFlags(JOBOBJECT_LIMIT_FLAGS.JOB_OBJECT_LIMIT_JOB_MEMORY, value.HasValue); i.JobMemoryLimit = value.GetValueOrDefault(); });
	}

	/// <summary>
	/// Gets or sets the maximum bandwidth for outgoing network traffic for the job, in bytes.
	/// <para>If this value is <see langword="null"/>, then this setting is disabled.</para>
	/// </summary>
	public ulong? MaxBandwidth
	{
		get
		{
			var info = job.CheckThenGet<JOBOBJECT_NET_RATE_CONTROL_INFORMATION>();
			return info.ControlFlags.IsFlagSet(JOB_OBJECT_NET_RATE_CONTROL_FLAGS.JOB_OBJECT_NET_RATE_CONTROL_MAX_BANDWIDTH) ? (ulong?)info.MaxBandwidth : null;
		}
		set
		{
			job.CheckThenSet((ref JOBOBJECT_NET_RATE_CONTROL_INFORMATION i) =>
			{
				i.ControlFlags = i.ControlFlags.SetFlags(JOB_OBJECT_NET_RATE_CONTROL_FLAGS.JOB_OBJECT_NET_RATE_CONTROL_MAX_BANDWIDTH | JOB_OBJECT_NET_RATE_CONTROL_FLAGS.JOB_OBJECT_NET_RATE_CONTROL_ENABLE, value.HasValue);
				i.MaxBandwidth = value.GetValueOrDefault();
			});
		}
	}

	/// <summary>
	/// <para>Gets or sets the per-job user-mode execution time limit.</para>
	/// <para>
	/// The system adds the current time of the processes associated with the job to this limit. For example, if you set this limit to 1
	/// minute, and the job has a process that has accumulated 5 minutes of user-mode time, the limit actually enforced is 6 minutes.
	/// </para>
	/// <para>
	/// The system periodically checks to determine whether the sum of the user-mode execution time for all processes is greater than
	/// this end-of-job limit. If it is, the action specified in the <c>EndOfJobTimeAction</c> property is carried out. By default, all
	/// processes are terminated and the status code is set to <c>ERROR_NOT_ENOUGH_QUOTA</c>.
	/// </para>
	/// <para>If this value is <see langword="null"/>, then this setting is disabled.</para>
	/// </summary>
	public TimeSpan? PerJobUserTimeLimit
	{
		get => GetBasic(JOBOBJECT_LIMIT_FLAGS.JOB_OBJECT_LIMIT_JOB_TIME, n => n.PerJobUserTimeLimit);
		set => SetBasic(JOBOBJECT_LIMIT_FLAGS.JOB_OBJECT_LIMIT_JOB_TIME, value, (ref JOBOBJECT_BASIC_LIMIT_INFORMATION i) => i.PerJobUserTimeLimit = value.GetValueOrDefault());
	}

	/// <summary>
	/// <para>Gets or sets the per-process user-mode execution time limit.</para>
	/// <para>
	/// The system periodically checks to determine whether each process associated with the job has accumulated more user-mode time than
	/// the set limit. If it has, the process is terminated.
	/// </para>
	/// <para>If the job is nested, the effective limit is the most restrictive limit in the job chain.</para>
	/// <para>If this value is <see langword="null"/>, then this setting is disabled.</para>
	/// </summary>
	public TimeSpan? PerProcessUserTimeLimit
	{
		get => GetBasic(JOBOBJECT_LIMIT_FLAGS.JOB_OBJECT_LIMIT_PROCESS_TIME, n => n.PerProcessUserTimeLimit);
		set => SetBasic(JOBOBJECT_LIMIT_FLAGS.JOB_OBJECT_LIMIT_PROCESS_TIME, value, (ref JOBOBJECT_BASIC_LIMIT_INFORMATION i) => i.PerProcessUserTimeLimit = value.GetValueOrDefault());
	}

	/// <summary>
	/// Gets or sets the limit for the virtual memory that can be committed by a process.
	/// <para>If this value is <see langword="null"/>, then this setting is disabled.</para>
	/// </summary>
	public ulong? ProcessMemoryLimit
	{
		get => job.CheckThenGet((JOBOBJECT_EXTENDED_LIMIT_INFORMATION n) =>
			n.BasicLimitInformation.LimitFlags.IsFlagSet(JOBOBJECT_LIMIT_FLAGS.JOB_OBJECT_LIMIT_PROCESS_MEMORY) ? (ulong?)n.ProcessMemoryLimit : null);
		set => job.CheckThenSet((ref JOBOBJECT_EXTENDED_LIMIT_INFORMATION i) => { i.BasicLimitInformation.LimitFlags = i.BasicLimitInformation.LimitFlags.SetFlags(JOBOBJECT_LIMIT_FLAGS.JOB_OBJECT_LIMIT_PROCESS_MEMORY, value.HasValue); i.ProcessMemoryLimit = value.GetValueOrDefault(); });
	}

	/// <summary>
	/// <para>Gets or sets the working set size in bytes for each process associated with the job.</para>
	/// <para>Both <c>min</c> and <c>max</c> must be zero or non-zero.</para>
	/// <para>If this value is <see langword="null"/>, then this setting is disabled.</para>
	/// </summary>
	public (SizeT min, SizeT max)? WorkingSetSize
	{
		get => job.CheckThenGet((JOBOBJECT_BASIC_LIMIT_INFORMATION n) =>
			n.LimitFlags.IsFlagSet(JOBOBJECT_LIMIT_FLAGS.JOB_OBJECT_LIMIT_WORKINGSET) ? (n.MinimumWorkingSetSize, n.MaximumWorkingSetSize) : ((SizeT, SizeT)?)null);
		set
		{
			if (value.HasValue && ((value.Value.min == SizeT.Zero && value.Value.max != SizeT.Zero) || (value.Value.max == SizeT.Zero && value.Value.min != SizeT.Zero) || value.Value.min > value.Value.max))
				throw new ArgumentOutOfRangeException(nameof(WorkingSetSize));
			job.CheckThenSet((ref JOBOBJECT_BASIC_LIMIT_INFORMATION i) =>
			{
				i.LimitFlags = i.LimitFlags.SetFlags(JOBOBJECT_LIMIT_FLAGS.JOB_OBJECT_LIMIT_WORKINGSET, value.HasValue);
				i.MinimumWorkingSetSize = value.HasValue ? value.Value.min : SizeT.Zero;
				i.MaximumWorkingSetSize = value.HasValue ? value.Value.max : SizeT.Zero;
			});
		}
	}
}

/// <summary>Contains information about a job object limit notification message.</summary>
/// <seealso cref="JobEventArgs"/>
public class JobNotificationEventArgs : JobEventArgs
{
	internal JobNotificationEventArgs(JOB_OBJECT_MSG msg, int id, JobLimit k, object v, object n) : base(msg, id)
	{
		Limit = k;
		ReportedValue = v;
		NotificationLimit = n;
	}

	/// <summary>Gets the limit which was exceeded.</summary>
	/// <value>The limit.</value>
	public JobLimit Limit { get; }

	/// <summary>Gets the value of the notification limit.</summary>
	/// <value>The notification limit value.</value>
	public object NotificationLimit { get; }

	/// <summary>Gets the value of the limited item at the time of the notification.</summary>
	/// <value>The reported value at the time of notification.</value>
	public object ReportedValue { get; }
}

/// <summary>Settings for <see cref="Job"/> that set notification limits for different properties.</summary>
/// <seealso cref="Vanara.Diagnostics.JobHelper"/>
public class JobNotifications : JobHelper
{
	/// <summary>Initializes a new instance of the <see cref="JobNotifications"/> class.</summary>
	/// <param name="jobName">Name of the job.</param>
	public JobNotifications(string jobName) : base(jobName) { }

	/// <summary>Initializes a new instance of the <see cref="JobNotifications"/> class.</summary>
	/// <param name="job">The job.</param>
	public JobNotifications(Job job) : base(job) { }

	/// <summary>
	/// <para>
	/// Gets or sets the extent to which a job can exceed its I/O rate control limits during the interval specified by the
	/// <c>IoRateControlToleranceInterval</c> member.
	/// </para>
	/// <para>If this value is <see langword="null"/>, then this setting is disabled.</para>
	/// <para>This member can be one of the following values. If no value is specified, <c>ToleranceHigh</c> is used.</para>
	/// <para>
	/// <list type="table">
	/// <listheader>
	/// <term>Value</term>
	/// <term>Meaning</term>
	/// </listheader>
	/// <item>
	/// <term>ToleranceLow</term>
	/// <term>The job can exceed its I/O rate control limits for 20% of the tolerance interval.</term>
	/// </item>
	/// <item>
	/// <term>ToleranceMedium</term>
	/// <term>The job can exceed its I/O rate control limits for 40% of the tolerance interval.</term>
	/// </item>
	/// <item>
	/// <term>ToleranceHigh</term>
	/// <term>The job can exceed its I/O rate control limits for 60% of the tolerance interval.</term>
	/// </item>
	/// </list>
	/// </para>
	/// </summary>
	public JOBOBJECT_RATE_CONTROL_TOLERANCE? IoRateControlTolerance
	{
		get => Get2(JOBOBJECT_LIMIT_FLAGS.JOB_OBJECT_LIMIT_IO_RATE_CONTROL, i => i.IoRateControlTolerance);
		set => Set2(JOBOBJECT_LIMIT_FLAGS.JOB_OBJECT_LIMIT_IO_RATE_CONTROL, value, (ref JOBOBJECT_NOTIFICATION_LIMIT_INFORMATION_2 i) =>
		{
			i.IoRateControlTolerance = value.GetValueOrDefault();
			if (value.HasValue && i.IoRateControlToleranceInterval == 0)
				i.IoRateControlToleranceInterval = JOBOBJECT_RATE_CONTROL_TOLERANCE_INTERVAL.ToleranceIntervalShort;
		});
	}

	/// <summary>
	/// <para>
	/// Gets or sets the interval during which a job's I/O usage is monitored to determine whether the job has exceeded its I/O rate
	/// control limits.
	/// </para>
	/// <para>If this value is <see langword="null"/>, then this setting is disabled.</para>
	/// <para>This member can be one of the following values. If no value is specified, <c>ToleranceIntervalShort</c> is used.</para>
	/// <para>
	/// <list type="table">
	/// <listheader>
	/// <term>Value</term>
	/// <term>Meaning</term>
	/// </listheader>
	/// <item>
	/// <term>ToleranceIntervalShort</term>
	/// <term>The tolerance interval is 10 seconds.</term>
	/// </item>
	/// <item>
	/// <term>ToleranceIntervalMedium</term>
	/// <term>The tolerance interval is one minute.</term>
	/// </item>
	/// <item>
	/// <term>ToleranceIntervalLong</term>
	/// <term>The tolerance interval is 10 minutes.</term>
	/// </item>
	/// </list>
	/// </para>
	/// </summary>
	public JOBOBJECT_RATE_CONTROL_TOLERANCE_INTERVAL? IoRateControlToleranceInterval
	{
		get => Get2(JOBOBJECT_LIMIT_FLAGS.JOB_OBJECT_LIMIT_IO_RATE_CONTROL, i => i.IoRateControlToleranceInterval);
		set => Set2(JOBOBJECT_LIMIT_FLAGS.JOB_OBJECT_LIMIT_IO_RATE_CONTROL, value, (ref JOBOBJECT_NOTIFICATION_LIMIT_INFORMATION_2 i) =>
		{
			i.IoRateControlToleranceInterval = value.GetValueOrDefault();
			if (value.HasValue && i.IoRateControlTolerance == 0)
				i.IoRateControlTolerance = JOBOBJECT_RATE_CONTROL_TOLERANCE.ToleranceHigh;
		});
	}

	/// <summary>
	/// Gets or sets the notification limit for total I/O bytes read by all processes in the job.
	/// <para>If this value is <see langword="null"/>, then this setting is disabled.</para>
	/// </summary>
	public ulong? IoReadBytesLimit
	{
		get => Get1(JOBOBJECT_LIMIT_FLAGS.JOB_OBJECT_LIMIT_JOB_READ_BYTES, i => i.IoReadBytesLimit);
		set => Set1(JOBOBJECT_LIMIT_FLAGS.JOB_OBJECT_LIMIT_JOB_READ_BYTES, value, (ref JOBOBJECT_NOTIFICATION_LIMIT_INFORMATION i) => i.IoReadBytesLimit = value.GetValueOrDefault());
	}

	/// <summary>
	/// Gets or sets the notification limit for total I/O bytes written by all processes in the job.
	/// <para>If this value is <see langword="null"/>, then this setting is disabled.</para>
	/// </summary>
	public ulong? IoWriteBytesLimit
	{
		get => Get1(JOBOBJECT_LIMIT_FLAGS.JOB_OBJECT_LIMIT_JOB_WRITE_BYTES, i => i.IoWriteBytesLimit);
		set => Set1(JOBOBJECT_LIMIT_FLAGS.JOB_OBJECT_LIMIT_JOB_WRITE_BYTES, value, (ref JOBOBJECT_NOTIFICATION_LIMIT_INFORMATION i) => i.IoWriteBytesLimit = value.GetValueOrDefault());
	}

	/// <summary>
	/// The notification limit minimum for the total virtual memory that can be committed by all processes in the job, in bytes. The
	/// minimum value is 4096.
	/// <para>If this value is <see langword="null"/>, then this setting is disabled.</para>
	/// </summary>
	public ulong? JobLowMemoryLimit
	{
		get => Get2(JOBOBJECT_LIMIT_FLAGS.JOB_OBJECT_LIMIT_JOB_MEMORY_LOW, i => i.JobLowMemoryLimit);
		set => Set2(JOBOBJECT_LIMIT_FLAGS.JOB_OBJECT_LIMIT_JOB_MEMORY_LOW, value, (ref JOBOBJECT_NOTIFICATION_LIMIT_INFORMATION_2 i) => i.JobLowMemoryLimit = value.GetValueOrDefault());
	}

	/// <summary>
	/// The notification limit for total virtual memory that can be committed by all processes in the job, in bytes. The minimum value is 4096.
	/// <para>If this value is <see langword="null"/>, then this setting is disabled.</para>
	/// </summary>
	public ulong? JobMemoryLimit
	{
		get => Get1(JOBOBJECT_LIMIT_FLAGS.JOB_OBJECT_LIMIT_JOB_MEMORY, i => i.JobMemoryLimit);
		set => Set1(JOBOBJECT_LIMIT_FLAGS.JOB_OBJECT_LIMIT_JOB_MEMORY, value, (ref JOBOBJECT_NOTIFICATION_LIMIT_INFORMATION i) => i.JobMemoryLimit = value.GetValueOrDefault());
	}

	/// <summary>
	/// <para>
	/// Gets or sets the extent to which a job can exceed its network rate control limits during the interval specified by the
	/// <c>NetRateControlToleranceInterval</c> member.
	/// </para>
	/// <para>If this value is <see langword="null"/>, then this setting is disabled.</para>
	/// <para>This member can be one of the following values. If no value is specified, <c>ToleranceHigh</c> is used.</para>
	/// <para>
	/// <list type="table">
	/// <listheader>
	/// <term>Value</term>
	/// <term>Meaning</term>
	/// </listheader>
	/// <item>
	/// <term>ToleranceLow</term>
	/// <term>The job can exceed its network rate control limits for 20% of the tolerance interval.</term>
	/// </item>
	/// <item>
	/// <term>ToleranceMedium</term>
	/// <term>The job can exceed its network rate control limits for 40% of the tolerance interval.</term>
	/// </item>
	/// <item>
	/// <term>ToleranceHigh</term>
	/// <term>The job can exceed its network rate control limits for 60% of the tolerance interval.</term>
	/// </item>
	/// </list>
	/// </para>
	/// </summary>
	public JOBOBJECT_RATE_CONTROL_TOLERANCE? NetRateControlTolerance
	{
		get => Get2(JOBOBJECT_LIMIT_FLAGS.JOB_OBJECT_LIMIT_NET_RATE_CONTROL, i => i.NetRateControlTolerance);
		set => Set2(JOBOBJECT_LIMIT_FLAGS.JOB_OBJECT_LIMIT_NET_RATE_CONTROL, value, (ref JOBOBJECT_NOTIFICATION_LIMIT_INFORMATION_2 i) =>
		{
			i.NetRateControlTolerance = value.GetValueOrDefault();
			if (value.HasValue && i.NetRateControlToleranceInterval == 0)
				i.NetRateControlToleranceInterval = JOBOBJECT_RATE_CONTROL_TOLERANCE_INTERVAL.ToleranceIntervalShort;
		});
	}

	/// <summary>
	/// <para>
	/// Gets or sets the interval during which a job's network usage is monitored to determine whether the job has exceeded its network
	/// rate control limits.
	/// </para>
	/// <para>If this value is <see langword="null"/>, then this setting is disabled.</para>
	/// <para>This member can be one of the following values. If no value is specified, <c>ToleranceIntervalShort</c> is used.</para>
	/// <para>
	/// <list type="table">
	/// <listheader>
	/// <term>Value</term>
	/// <term>Meaning</term>
	/// </listheader>
	/// <item>
	/// <term>ToleranceIntervalShort</term>
	/// <term>The tolerance interval is 10 seconds.</term>
	/// </item>
	/// <item>
	/// <term>ToleranceIntervalMedium</term>
	/// <term>The tolerance interval is one minute.</term>
	/// </item>
	/// <item>
	/// <term>ToleranceIntervalLong</term>
	/// <term>The tolerance interval is 10 minutes.</term>
	/// </item>
	/// </list>
	/// </para>
	/// </summary>
	public JOBOBJECT_RATE_CONTROL_TOLERANCE_INTERVAL? NetRateControlToleranceInterval
	{
		get => Get2(JOBOBJECT_LIMIT_FLAGS.JOB_OBJECT_LIMIT_NET_RATE_CONTROL, i => i.NetRateControlToleranceInterval);
		set => Set2(JOBOBJECT_LIMIT_FLAGS.JOB_OBJECT_LIMIT_NET_RATE_CONTROL, value, (ref JOBOBJECT_NOTIFICATION_LIMIT_INFORMATION_2 i) =>
		{
			i.NetRateControlToleranceInterval = value.GetValueOrDefault();
			if (value.HasValue && i.NetRateControlTolerance == 0)
				i.NetRateControlTolerance = JOBOBJECT_RATE_CONTROL_TOLERANCE.ToleranceHigh;
		});
	}

	/// <summary>
	/// <para>Gets or sets the notification limit for per-job user-mode execution time, in 100-nanosecond ticks.</para>
	/// <para>If this value is <see langword="null"/>, then this setting is disabled.</para>
	/// <para>
	/// The system adds the accumulated execution time of processes associated with the job to this limit when the limit is set. For
	/// example, if a process associated with the job has already accumulated 5 minutes of user-mode execution time and the limit is set
	/// to 1 minute, the limit actually enforced is 6 minutes.
	/// </para>
	/// <para>
	/// To specify <c>PerJobUserTimeLimit</c> as an enforceable limit and terminate processes in jobs that exceed the limit, see the
	/// <c>JOBOBJECT_BASIC_LIMIT_INFORMATION</c> structure.
	/// </para>
	/// </summary>
	public TimeSpan? PerJobUserTimeLimit
	{
		get => Get1(JOBOBJECT_LIMIT_FLAGS.JOB_OBJECT_LIMIT_JOB_TIME, i => i.PerJobUserTimeLimit);
		set => Set1(JOBOBJECT_LIMIT_FLAGS.JOB_OBJECT_LIMIT_JOB_TIME, value, (ref JOBOBJECT_NOTIFICATION_LIMIT_INFORMATION i) => i.PerJobUserTimeLimit = value.GetValueOrDefault());
	}

	/// <summary>
	/// <para>
	/// Gets or sets the extent to which a job can exceed its CPU rate control limits during the interval specified by the
	/// <c>RateControlToleranceInterval</c> member.
	/// </para>
	/// <para>If this value is <see langword="null"/>, then this setting is disabled.</para>
	/// <para>This member can be one of the following values. If no value is specified, <c>ToleranceHigh</c> is used.</para>
	/// <para>
	/// <list type="table">
	/// <listheader>
	/// <term>Value</term>
	/// <term>Meaning</term>
	/// </listheader>
	/// <item>
	/// <term>ToleranceLow</term>
	/// <term>The job can exceed its CPU rate control limits for 20% of the tolerance interval.</term>
	/// </item>
	/// <item>
	/// <term>ToleranceMedium</term>
	/// <term>The job can exceed its CPU rate control limits for 40% of the tolerance interval.</term>
	/// </item>
	/// <item>
	/// <term>ToleranceHigh</term>
	/// <term>The job can exceed its CPU rate control limits for 60% of the tolerance interval.</term>
	/// </item>
	/// </list>
	/// </para>
	/// </summary>
	public JOBOBJECT_RATE_CONTROL_TOLERANCE? RateControlTolerance
	{
		get => Get1(JOBOBJECT_LIMIT_FLAGS.JOB_OBJECT_LIMIT_RATE_CONTROL, i => i.RateControlTolerance);
		set => Set1(JOBOBJECT_LIMIT_FLAGS.JOB_OBJECT_LIMIT_RATE_CONTROL, value, (ref JOBOBJECT_NOTIFICATION_LIMIT_INFORMATION i) =>
		{
			i.RateControlTolerance = value.GetValueOrDefault();
			if (value.HasValue && i.RateControlToleranceInterval == 0)
				i.RateControlToleranceInterval = JOBOBJECT_RATE_CONTROL_TOLERANCE_INTERVAL.ToleranceIntervalShort;
		});
	}

	/// <summary>
	/// <para>
	/// Gets or sets the interval during which a job's CPU usage is monitored to determine whether the job has exceeded its CPU rate
	/// control limits.
	/// </para>
	/// <para>If this value is <see langword="null"/>, then this setting is disabled.</para>
	/// <para>This member can be one of the following values. If no value is specified, <c>ToleranceIntervalShort</c> is used.</para>
	/// <para>
	/// <list type="table">
	/// <listheader>
	/// <term>Value</term>
	/// <term>Meaning</term>
	/// </listheader>
	/// <item>
	/// <term>ToleranceIntervalShort</term>
	/// <term>The tolerance interval is 10 seconds.</term>
	/// </item>
	/// <item>
	/// <term>ToleranceIntervalMedium</term>
	/// <term>The tolerance interval is one minute.</term>
	/// </item>
	/// <item>
	/// <term>ToleranceIntervalLong</term>
	/// <term>The tolerance interval is 10 minutes.</term>
	/// </item>
	/// </list>
	/// </para>
	/// </summary>
	public JOBOBJECT_RATE_CONTROL_TOLERANCE_INTERVAL? RateControlToleranceInterval
	{
		get => Get1(JOBOBJECT_LIMIT_FLAGS.JOB_OBJECT_LIMIT_RATE_CONTROL, i => i.RateControlToleranceInterval);
		set => Set1(JOBOBJECT_LIMIT_FLAGS.JOB_OBJECT_LIMIT_RATE_CONTROL, value, (ref JOBOBJECT_NOTIFICATION_LIMIT_INFORMATION i) =>
		{
			i.RateControlToleranceInterval = value.GetValueOrDefault();
			if (value.HasValue && i.RateControlTolerance == 0)
				i.RateControlTolerance = JOBOBJECT_RATE_CONTROL_TOLERANCE.ToleranceHigh;
		});
	}

	/// <summary>Gets field values from JOBOBJECT_NOTIFICATION_LIMIT_INFORMATION.</summary>
	/// <typeparam name="T">The return type.</typeparam>
	/// <param name="flag">The limit flag.</param>
	/// <param name="getter">The method to get the field.</param>
	/// <returns>The value.</returns>
	private T? Get1<T>(JOBOBJECT_LIMIT_FLAGS flag, Func<JOBOBJECT_NOTIFICATION_LIMIT_INFORMATION, T> getter) where T : struct =>
		job.CheckThenGet<T?, JOBOBJECT_NOTIFICATION_LIMIT_INFORMATION>(n => n.LimitFlags.IsFlagSet(flag) ? (T?)getter(n) : null);

	/// <summary>Gets field values from JOBOBJECT_NOTIFICATION_LIMIT_INFORMATION_2.</summary>
	/// <typeparam name="T">The return type.</typeparam>
	/// <param name="flag">The limit flag.</param>
	/// <param name="getter">The method to get the field.</param>
	/// <returns>The value.</returns>
	private T? Get2<T>(JOBOBJECT_LIMIT_FLAGS flag, Func<JOBOBJECT_NOTIFICATION_LIMIT_INFORMATION_2, T> getter) where T : struct =>
		job.CheckThenGet<T?, JOBOBJECT_NOTIFICATION_LIMIT_INFORMATION_2>(n => n.LimitFlags.IsFlagSet(flag) ? (T?)getter(n) : null);

	/// <summary>Sets a field value in JOBOBJECT_NOTIFICATION_LIMIT_INFORMATION.</summary>
	/// <typeparam name="T">The field type.</typeparam>
	/// <param name="flag">The limit flag.</param>
	/// <param name="value">The value.</param>
	/// <param name="setter">The method to set the field.</param>
	private void Set1<T>(JOBOBJECT_LIMIT_FLAGS flag, T? value, Job.RefAction<JOBOBJECT_NOTIFICATION_LIMIT_INFORMATION> setter) where T : struct =>
		job.CheckThenSet((ref JOBOBJECT_NOTIFICATION_LIMIT_INFORMATION i) => { i.LimitFlags = i.LimitFlags.SetFlags(flag, value.HasValue); setter(ref i); });

	/// <summary>Sets a field value in JOBOBJECT_NOTIFICATION_LIMIT_INFORMATION_2.</summary>
	/// <typeparam name="T">The field type.</typeparam>
	/// <param name="flag">The limit flag.</param>
	/// <param name="value">The value.</param>
	/// <param name="setter">The method to set the field.</param>
	private void Set2<T>(JOBOBJECT_LIMIT_FLAGS flag, T? value, Job.RefAction<JOBOBJECT_NOTIFICATION_LIMIT_INFORMATION_2> setter) where T : struct =>
		job.CheckThenSet((ref JOBOBJECT_NOTIFICATION_LIMIT_INFORMATION_2 i) => { i.LimitFlags = i.LimitFlags.SetFlags(flag, value.HasValue); setter(ref i); });
}

/// <summary>Represents the security access rights of a job object.</summary>
public class JobSecurity : ObjectSecurity<JobAccessRight>
{
	/// <summary/>
	public JobSecurity() : base(true, System.Security.AccessControl.ResourceType.KernelObject) { }
}

/// <summary>Settings related to job objects.</summary>
public class JobSettings : JobHelper
{
	/// <summary>Initializes a new instance of the <see cref="JobSettings"/> class.</summary>
	/// <param name="jobName">Name of the job.</param>
	public JobSettings(string jobName) : base(jobName) { }

	/// <summary>Initializes a new instance of the <see cref="JobSettings"/> class.</summary>
	/// <param name="job">The job.</param>
	public JobSettings(Job job) : base(job) { }

	/// <summary>
	/// <para>Gets or sets the processor affinity for all processes associated with the job.</para>
	/// <para>
	/// The affinity must be a subset of the system affinity mask obtained by calling the <c>GetProcessAffinityMask</c> function. The
	/// affinity of each thread is set to this value, but threads are free to subsequently set their affinity, as long as it is a subset
	/// of the specified affinity mask. Processes cannot set their own affinity mask.
	/// </para>
	/// <para>If this value is <see langword="null"/>, then this setting is disabled.</para>
	/// </summary>
	public UIntPtr? Affinity
	{
		get => GetBasic(JOBOBJECT_LIMIT_FLAGS.JOB_OBJECT_LIMIT_AFFINITY, n => n.Affinity);
		set => SetBasic(JOBOBJECT_LIMIT_FLAGS.JOB_OBJECT_LIMIT_AFFINITY, value, (ref JOBOBJECT_BASIC_LIMIT_INFORMATION i) => i.Affinity = value.GetValueOrDefault());
	}

	/// <summary>
	/// If any process associated with the job creates a child process using the CREATE_BREAKAWAY_FROM_JOB flag while this value is
	/// <see langword="true"/>, the child process is not associated with the job.
	/// </summary>
	public bool ChildProcessBreakawayAllowed
	{
		get => job.CheckThenGet<JOBOBJECT_EXTENDED_LIMIT_INFORMATION>().BasicLimitInformation.LimitFlags.IsFlagSet(JOBOBJECT_LIMIT_FLAGS.JOB_OBJECT_LIMIT_BREAKAWAY_OK);
		set => job.CheckThenSet((ref JOBOBJECT_EXTENDED_LIMIT_INFORMATION i) => { i.BasicLimitInformation.LimitFlags = i.BasicLimitInformation.LimitFlags.SetFlags(JOBOBJECT_LIMIT_FLAGS.JOB_OBJECT_LIMIT_BREAKAWAY_OK, value); });
	}

	/// <summary>
	/// If <see langword="true"/>, allows any process associated with the job to create child processes that are not associated with the
	/// job. If the job is nested and its immediate job object allows breakaway, the child process breaks away from the immediate job
	/// object and from each job in the parent job chain, moving up the hierarchy until it reaches a job that does not permit breakaway.
	/// If the immediate job object does not allow breakaway, the child process does not break away even if jobs in its parent job chain
	/// allow it.
	/// </summary>
	public bool ChildProcessSilentBreakawayAllowed
	{
		get => job.CheckThenGet<JOBOBJECT_EXTENDED_LIMIT_INFORMATION>().BasicLimitInformation.LimitFlags.IsFlagSet(JOBOBJECT_LIMIT_FLAGS.JOB_OBJECT_LIMIT_SILENT_BREAKAWAY_OK);
		set => job.CheckThenSet((ref JOBOBJECT_EXTENDED_LIMIT_INFORMATION i) => { i.BasicLimitInformation.LimitFlags = i.BasicLimitInformation.LimitFlags.SetFlags(JOBOBJECT_LIMIT_FLAGS.JOB_OBJECT_LIMIT_SILENT_BREAKAWAY_OK, value); });
	}

	/// <summary>
	/// If <see langword="true"/>, Forces a call to the SetErrorMode function with the SEM_NOGPFAULTERRORBOX flag for each process
	/// associated with the job. If an exception occurs and the system calls the UnhandledExceptionFilter function, the debugger will be
	/// given a chance to act. If there is no debugger, the functions returns EXCEPTION_EXECUTE_HANDLER. Normally, this will cause
	/// termination of the process with the exception code as the exit status.
	/// </summary>
	public bool DieOnUnhandledException
	{
		get => job.CheckThenGet<JOBOBJECT_EXTENDED_LIMIT_INFORMATION>().BasicLimitInformation.LimitFlags.IsFlagSet(JOBOBJECT_LIMIT_FLAGS.JOB_OBJECT_LIMIT_DIE_ON_UNHANDLED_EXCEPTION);
		set => job.CheckThenSet((ref JOBOBJECT_EXTENDED_LIMIT_INFORMATION i) => { i.BasicLimitInformation.LimitFlags = i.BasicLimitInformation.LimitFlags.SetFlags(JOBOBJECT_LIMIT_FLAGS.JOB_OBJECT_LIMIT_DIE_ON_UNHANDLED_EXCEPTION, value); });
	}

	/// <summary>
	/// The value to use for the Differentiated Service code point (DSCP) field to turn on network quality of service (QoS) for all
	/// outgoing network traffic generated by the processes of the job object. The valid range is from 0x00 through 0x3F. For information
	/// about DSCP, see Differentiated Services.
	/// <para>If this value is <see langword="null"/>, then this setting is disabled.</para>
	/// </summary>
	public byte? DscpTag
	{
		get
		{
			var info = job.CheckThenGet<JOBOBJECT_NET_RATE_CONTROL_INFORMATION>();
			return info.ControlFlags.IsFlagSet(JOB_OBJECT_NET_RATE_CONTROL_FLAGS.JOB_OBJECT_NET_RATE_CONTROL_DSCP_TAG | JOB_OBJECT_NET_RATE_CONTROL_FLAGS.JOB_OBJECT_NET_RATE_CONTROL_ENABLE) ? (byte?)info.DscpTag : null;
		}
		set
		{
			if (value > 0x3F)
				throw new ArgumentOutOfRangeException(nameof(DscpTag));
			var flag = JOB_OBJECT_NET_RATE_CONTROL_FLAGS.JOB_OBJECT_NET_RATE_CONTROL_DSCP_TAG;
			if (value.HasValue) flag |= JOB_OBJECT_NET_RATE_CONTROL_FLAGS.JOB_OBJECT_NET_RATE_CONTROL_ENABLE;
			job.CheckThenSet((ref JOBOBJECT_NET_RATE_CONTROL_INFORMATION i) => { i.ControlFlags = flag; i.DscpTag = value.GetValueOrDefault(); });
		}
	}

	/// <summary>Gets or sets the list of processor groups to which the job is currently assigned.</summary>
	public IEnumerable<GROUP_AFFINITY> GroupAffinity
	{
		get
		{
			var gaSz = Marshal.SizeOf(typeof(GROUP_AFFINITY));
			using var mem = new SafeHGlobalHandle(gaSz);
			uint req;
			while (!QueryInformationJobObject(job.hJob, JOBOBJECTINFOCLASS.JobObjectGroupInformationEx, mem, mem.Size, out req))
			{
				Win32Error.ThrowLastErrorUnless(Win32Error.ERROR_MORE_DATA);
				mem.Size = req;
			}
			return mem.ToArray<GROUP_AFFINITY>((int)req / gaSz);
		}
		set
		{
			using var mem = SafeHGlobalHandle.CreateFromList(value);
			if (!SetInformationJobObject(job.hJob, JOBOBJECTINFOCLASS.JobObjectGroupInformationEx, mem, mem.Size))
				Win32Error.ThrowLastError();
		}
	}

	/// <summary>Causes all processes associated with the job to terminate when the last handle to the job is closed.</summary>
	/// <value><see langword="true"/> to kill all processes when the job is closed; otherwise, <see langword="false"/>.</value>
	public bool KillOnJobClose
	{
		get => job.CheckThenGet<JOBOBJECT_EXTENDED_LIMIT_INFORMATION>().BasicLimitInformation.LimitFlags.IsFlagSet(JOBOBJECT_LIMIT_FLAGS.JOB_OBJECT_LIMIT_KILL_ON_JOB_CLOSE);
		set => job.CheckThenSet((ref JOBOBJECT_EXTENDED_LIMIT_INFORMATION i) => { i.BasicLimitInformation.LimitFlags = i.BasicLimitInformation.LimitFlags.SetFlags(JOBOBJECT_LIMIT_FLAGS.JOB_OBJECT_LIMIT_KILL_ON_JOB_CLOSE, value); });
	}

	/// <summary>
	/// <para>Gets or sets the priority class for all processes associated with the job.</para>
	/// <para>
	/// Processes and threads cannot modify their priority class. The calling process must enable the <c>SE_INC_BASE_PRIORITY_NAME</c> privilege.
	/// </para>
	/// <para>If this value is <see langword="null"/>, then this setting is disabled.</para>
	/// </summary>
	public ProcessPriorityClass? PriorityClass
	{
		get => (ProcessPriorityClass?)GetBasic(JOBOBJECT_LIMIT_FLAGS.JOB_OBJECT_LIMIT_PRIORITY_CLASS, n => n.PriorityClass);
		set => SetBasic(JOBOBJECT_LIMIT_FLAGS.JOB_OBJECT_LIMIT_PRIORITY_CLASS, value, (ref JOBOBJECT_BASIC_LIMIT_INFORMATION i) => i.PriorityClass = (uint)value.GetValueOrDefault());
	}

	/// <summary>
	/// <para>Gets or sets the scheduling class for all processes associated with the job.</para>
	/// <para>
	/// The valid values are 0 to 9. Use 0 for the least favorable scheduling class relative to other threads, and 9 for the most
	/// favorable scheduling class relative to other threads. By default, this value is 5. To use a scheduling class greater than 5, the
	/// calling process must enable the <c>SE_INC_BASE_PRIORITY_NAME</c> privilege.
	/// </para>
	/// <para>If this value is <see langword="null"/>, then this setting is disabled.</para>
	/// </summary>
	public uint? SchedulingClass
	{
		get => GetBasic(JOBOBJECT_LIMIT_FLAGS.JOB_OBJECT_LIMIT_SCHEDULING_CLASS, n => n.SchedulingClass);
		set => SetBasic(JOBOBJECT_LIMIT_FLAGS.JOB_OBJECT_LIMIT_SCHEDULING_CLASS, value, (ref JOBOBJECT_BASIC_LIMIT_INFORMATION i) => i.SchedulingClass = value.GetValueOrDefault());
	}

	/// <summary>
	/// Determines if all processes will be terminated when the end-of-job time limit has been exceeded or if only an event will be sent.
	/// The default is to terminate all processes.
	/// <para>
	/// If <see langword="true"/>, the system terminates all processes and sets the exit status to ERROR_NOT_ENOUGH_QUOTA. The processes
	/// cannot prevent or delay their own termination. The job object is set to the signaled state and remains signaled until this limit
	/// is reset. No additional processes can be assigned to the job until the limit is reset. This is the default termination action.
	/// </para>
	/// <para>
	/// If <see langword="false"/>, the system generates the <see cref="Job.EndOfJobTime"/> event. After the completion packet is posted,
	/// the system clears the end-of-job time limit, and processes in the job can continue their execution. If no completion port is
	/// associated with the job when the time limit has been exceeded, the action taken is the same as for JOB_OBJECT_TERMINATE_AT_END_OF_JOB.
	/// </para>
	/// </summary>
	public bool TerminateProcessesAtEndOfJobTimeLimit
	{
		get => job.CheckThenGet<JOBOBJECT_END_OF_JOB_TIME_INFORMATION>().EndOfJobTimeAction == JOBOBJECT_END_OF_JOB_TIME_ACTION.JOB_OBJECT_TERMINATE_AT_END_OF_JOB;
		set => job.CheckThenSet((ref JOBOBJECT_END_OF_JOB_TIME_INFORMATION i) => i.EndOfJobTimeAction = (JOBOBJECT_END_OF_JOB_TIME_ACTION)(value ? 0 : 1));
	}

	/// <summary>
	/// <para>The restriction class for the user interface. This member can be one or more of the following values.</para>
	/// <para>
	/// <list type="table">
	/// <listheader>
	/// <term>Value</term>
	/// <term>Meaning</term>
	/// </listheader>
	/// <item>
	/// <term>JOB_OBJECT_UILIMIT_DESKTOP</term>
	/// <term>
	/// Prevents processes associated with the job from creating desktops and switching desktops using the CreateDesktop and
	/// SwitchDesktop functions.
	/// </term>
	/// </item>
	/// <item>
	/// <term>JOB_OBJECT_UILIMIT_DISPLAYSETTINGS</term>
	/// <term>Prevents processes associated with the job from calling the ChangeDisplaySettings function.</term>
	/// </item>
	/// <item>
	/// <term>JOB_OBJECT_UILIMIT_EXITWINDOWS</term>
	/// <term>Prevents processes associated with the job from calling the ExitWindows or ExitWindowsEx function.</term>
	/// </item>
	/// <item>
	/// <term>JOB_OBJECT_UILIMIT_GLOBALATOMS</term>
	/// <term>
	/// Prevents processes associated with the job from accessing global atoms. When this flag is used, each job has its own atom table.
	/// </term>
	/// </item>
	/// <item>
	/// <term>JOB_OBJECT_UILIMIT_HANDLES</term>
	/// <term>Prevents processes associated with the job from using USER handles owned by processes not associated with the same job.</term>
	/// </item>
	/// <item>
	/// <term>JOB_OBJECT_UILIMIT_READCLIPBOARD</term>
	/// <term>Prevents processes associated with the job from reading data from the clipboard.</term>
	/// </item>
	/// <item>
	/// <term>JOB_OBJECT_UILIMIT_SYSTEMPARAMETERS</term>
	/// <term>Prevents processes associated with the job from changing system parameters by using the SystemParametersInfo function.</term>
	/// </item>
	/// <item>
	/// <term>JOB_OBJECT_UILIMIT_WRITECLIPBOARD</term>
	/// <term>Prevents processes associated with the job from writing data to the clipboard.</term>
	/// </item>
	/// </list>
	/// </para>
	/// </summary>
	public JOBOBJECT_UILIMIT_FLAGS UIRestrictionsClass
	{
		get => job.CheckThenGet<JOBOBJECT_BASIC_UI_RESTRICTIONS>().UIRestrictionsClass;
		set => job.CheckThenSet((ref JOBOBJECT_BASIC_UI_RESTRICTIONS i) => i.UIRestrictionsClass = value);
	}
}

/// <summary>Gets statistics for a job object.</summary>
/// <seealso cref="System.IDisposable"/>
public class JobStatistics : JobHelper
{
	/// <summary>Initializes a new instance of the <see cref="JobStatistics"/> class with a job name.</summary>
	/// <param name="jobName">Name of the job.</param>
	public JobStatistics(string jobName) : base(jobName) { }

	/// <summary>Initializes a new instance of the <see cref="JobStatistics"/> class with a job instance.</summary>
	/// <param name="job">The job.</param>
	public JobStatistics(Job job) : base(job) { }

	/// <summary>The number of I/O operations performed, other than read and write operations.</summary>
	public ulong OtherOperationCount => job.CheckThenGet<JOBOBJECT_BASIC_AND_IO_ACCOUNTING_INFORMATION>().IoInfo.OtherOperationCount;

	/// <summary>The number of bytes transferred during operations other than read and write operations.</summary>
	public ulong OtherTransferCount => job.CheckThenGet<JOBOBJECT_BASIC_AND_IO_ACCOUNTING_INFORMATION>().IoInfo.OtherTransferCount;

	/// <summary>The peak memory usage of all processes currently associated with the job.</summary>
	public ulong PeakJobMemoryUsed => job.CheckThenGet<JOBOBJECT_EXTENDED_LIMIT_INFORMATION>().PeakJobMemoryUsed;

	/// <summary>The peak memory used by any process ever associated with the job.</summary>
	public ulong PeakProcessMemoryUsed => job.CheckThenGet<JOBOBJECT_EXTENDED_LIMIT_INFORMATION>().PeakProcessMemoryUsed;

	/// <summary>The number of read operations performed.</summary>
	public ulong ReadOperationCount => job.CheckThenGet<JOBOBJECT_BASIC_AND_IO_ACCOUNTING_INFORMATION>().IoInfo.ReadOperationCount;

	/// <summary>The number of bytes read.</summary>
	public ulong ReadTransferCount => job.CheckThenGet<JOBOBJECT_BASIC_AND_IO_ACCOUNTING_INFORMATION>().IoInfo.ReadTransferCount;

	/// <summary>
	/// <para>
	/// The total amount of kernel-mode execution time for all active processes associated with the job (as well as all terminated
	/// processes no longer associated with the job) since the last call that set a per-job kernel-mode time limit, in 100-nanosecond ticks.
	/// </para>
	/// <para>This member is set to zero on creation of the job, and each time a per-job kernel-mode time limit is established.</para>
	/// </summary>
	public TimeSpan ThisPeriodTotalKernelTime => job.CheckThenGet<JOBOBJECT_BASIC_ACCOUNTING_INFORMATION>().ThisPeriodTotalKernelTime;

	/// <summary>
	/// <para>
	/// The total amount of user-mode execution time for all active processes associated with the job (as well as all terminated
	/// processes no longer associated with the job) since the last call that set a per-job user-mode time limit, in 100-nanosecond ticks.
	/// </para>
	/// <para>This member is set to 0 on creation of the job, and each time a per-job user-mode time limit is established.</para>
	/// </summary>
	public TimeSpan ThisPeriodTotalUserTime => job.CheckThenGet<JOBOBJECT_BASIC_ACCOUNTING_INFORMATION>().ThisPeriodTotalUserTime;

	/// <summary>
	/// The total amount of kernel-mode execution time for all active processes associated with the job, as well as all terminated
	/// processes no longer associated with the job, in 100-nanosecond ticks.
	/// </summary>
	public TimeSpan TotalKernelTime => job.CheckThenGet<JOBOBJECT_BASIC_ACCOUNTING_INFORMATION>().TotalKernelTime;

	/// <summary>
	/// The total number of page faults encountered by all active processes associated with the job, as well as all terminated processes
	/// no longer associated with the job.
	/// </summary>
	public uint TotalPageFaultCount => job.CheckThenGet<JOBOBJECT_BASIC_ACCOUNTING_INFORMATION>().TotalPageFaultCount;

	/// <summary>
	/// The total number of processes associated with the job during its lifetime, including those that have terminated. For example,
	/// when a process is associated with a job, but the association fails because of a limit violation, this value is incremented.
	/// </summary>
	public uint TotalProcesses => job.CheckThenGet<JOBOBJECT_BASIC_ACCOUNTING_INFORMATION>().TotalProcesses;

	/// <summary>The total number of processes terminated because of a limit violation.</summary>
	public uint TotalTerminatedProcesses => job.CheckThenGet<JOBOBJECT_BASIC_ACCOUNTING_INFORMATION>().TotalTerminatedProcesses;

	/// <summary>
	/// The total amount of user-mode execution time for all active processes associated with the job, as well as all terminated
	/// processes no longer associated with the job, in 100-nanosecond ticks.
	/// </summary>
	public TimeSpan TotalUserTime => job.CheckThenGet<JOBOBJECT_BASIC_ACCOUNTING_INFORMATION>().TotalUserTime;

	/// <summary>The number of write operations performed.</summary>
	public ulong WriteOperationCount => job.CheckThenGet<JOBOBJECT_BASIC_AND_IO_ACCOUNTING_INFORMATION>().IoInfo.WriteOperationCount;

	/// <summary>The number of bytes written.</summary>
	public ulong WriteTransferCount => job.CheckThenGet<JOBOBJECT_BASIC_AND_IO_ACCOUNTING_INFORMATION>().IoInfo.WriteTransferCount;
}