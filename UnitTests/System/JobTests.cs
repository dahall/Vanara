using NUnit.Framework;
using NUnit.Framework.Internal;
using System.Diagnostics;
using System.Linq;
using System.Threading;
using Vanara.PInvoke;
using Vanara.PInvoke.Tests;
using static Vanara.PInvoke.Kernel32;

namespace Vanara.Diagnostics.Tests;

[TestFixture]
public class JobTests
{
	[Test]
	public void ActiveProcessLimitTest()
	{
		using var job = Job.Create();

		job.RuntimeLimits.ActiveProcessLimit = 2;
		Assert.That(job.RuntimeLimits.ActiveProcessLimit.Value, Is.EqualTo(2U));
		job.RuntimeLimits.ActiveProcessLimit = 0;
		Assert.That(job.RuntimeLimits.ActiveProcessLimit.Value, Is.EqualTo(0U));
		Assert.That(() => job.StartProcess("notepad.exe"), Throws.Exception);
		job.RuntimeLimits.ActiveProcessLimit = null;
		Assert.That(job.RuntimeLimits.ActiveProcessLimit.HasValue, Is.False);
	}

	[Test]
	public void EventsTest()
	{
		using var job = Job.Create(Environment.UserName);
		try
		{
			job.NewProcess += msgHndlr;
			job.ProcessExited += msgHndlr;
			job.JobMemoryLimitExceeded += msgHndlr;
			job.JobNotificationLimitExceeded += notHndlr;

			var startInfo = new ProcessStartInfo("notepad.exe") { UseShellExecute = false };
			var p1 = new Process { StartInfo = startInfo };
			p1.StartEx(CREATE_PROCESS.CREATE_SUSPENDED);
			job.AssignProcess(p1);
			p1.ResumePrimaryThread();

			Thread.Sleep(200);

			job.Notifications.JobMemoryLimit = job.Statistics.PeakJobMemoryUsed;
			job.RuntimeLimits.JobMemoryLimit = job.Notifications.JobMemoryLimit * 3;
			//TestContext.WriteLine($"JobMemory: NotLim: {job.JobMemory.NotificationLimit}, Lim: {job.JobMemory.Limit}");

			//job.PerJobUserTime.NotificationLimit = job.Statistics.TotalUserTime;
			//job.PerJobUserTime.Limit = TimeSpan.FromTicks(job.PerJobUserTime.NotificationLimit.Value.Ticks * 3);
			//TestContext.WriteLine($"PerJobUserTime: NotLim: {job.PerJobUserTime.NotificationLimit}, Lim: {job.PerJobUserTime.Limit}");

			var p2 = new Process { StartInfo = startInfo };
			p2.StartEx(CREATE_PROCESS.CREATE_SUSPENDED);
			job.AssignProcess(p2);
			p2.ResumePrimaryThread();

			Thread.Sleep(2000);
			Thread.Yield();

			p1.Kill();
			Thread.Sleep(200);
			Thread.Yield();
		}
		finally
		{
			job.TerminateAllProcesses(0);
		}

		static void msgHndlr(object? s, JobEventArgs e) => TestContext.WriteLine($"{DateTime.Now:u}: {e.JobMessage}, {e.ProcessId}");
		static void notHndlr(object? s, JobNotificationEventArgs e) => TestContext.WriteLine($"{DateTime.Now:u}: {e.JobMessage}, {e.Limit}, Limit: {e.NotificationLimit}, Val: {e.ReportedValue}");
	}

	[Test]
	public void LimitsTest()
	{
		using var job = Job.Create();
		try
		{
			Assert.That(job.Processes.Count, Is.EqualTo(0));
			var p1 = TestHelper.RunThrottleApp();
			job.AssignProcess(p1);
			Thread.Sleep(200);

			job.RuntimeLimits.ActiveProcessLimit = 1;
			Assert.That(() => job.StartProcess("notepad.exe"), Throws.Exception);
			job.RuntimeLimits.ActiveProcessLimit = null;

			Test(job.RuntimeLimits, 1.0, (s, v) => s.CpuRateLimit = v, s => s.CpuRateLimit, true);
			Test(job.RuntimeLimits, (25.0, 75.0), (s, v) => s.CpuRatePortion = v, s => s.CpuRatePortion, true);
			Test(job.RuntimeLimits, 3, (s, v) => s.CpuRateRelativeWeight = v, s => s.CpuRateRelativeWeight, true);
			Test(job.RuntimeLimits, 4096UL, (s, v) => s.JobMemoryLimit = v, s => s.JobMemoryLimit, true);
			Test(job.RuntimeLimits, 4096UL, (s, v) => s.MaxBandwidth = v, s => s.MaxBandwidth);
			TestGT(job.RuntimeLimits, TimeSpan.FromTicks(30000), (s, v) => s.PerJobUserTimeLimit = v, s => s.PerJobUserTimeLimit);
			TestGT(job.RuntimeLimits, TimeSpan.FromTicks(30000), (s, v) => s.PerProcessUserTimeLimit = v, s => s.PerProcessUserTimeLimit);
			Test(job.RuntimeLimits, 4096UL, (s, v) => s.ProcessMemoryLimit = v, s => s.ProcessMemoryLimit, true);
			var pmc = PROCESS_MEMORY_COUNTERS.Default;
			GetProcessMemoryInfo(p1, out pmc, pmc.cb);
			Test(job.RuntimeLimits, (pmc.WorkingSetSize, pmc.PeakWorkingSetSize), (s, v) => s.WorkingSetSize = v, s => s.WorkingSetSize, true);
		}
		finally
		{
			job.TerminateAllProcesses(0);
			Thread.Sleep(200);
		}

		void TestGT<T, TS>(TS js, T? value, Action<TS, T?> set, Func<TS, T?> get) where TS : notnull where T : struct
		{
			Assert.That(() => set(js, value), Throws.Nothing);
			Assert.That(get(js).GetValueOrDefault(), Is.GreaterThanOrEqualTo(value!));

			Assert.That(() => set(js, null), Throws.Nothing);
			Assert.That(get(js), Is.Null);
		}
	}

	[Test]
	public void NotificationTest()
	{
		using var job = Job.Create();
		try
		{
			job.NewProcess += (s, e) => TestContext.WriteLine($"{DateTime.Now:u}: {e.JobMessage}, {e.ProcessId}");
			job.JobNotificationLimitExceeded += notHndlr;

			job.Notifications.IoRateControlTolerance = JOBOBJECT_RATE_CONTROL_TOLERANCE.ToleranceLow;
			job.Notifications.IoRateControlToleranceInterval = JOBOBJECT_RATE_CONTROL_TOLERANCE_INTERVAL.ToleranceIntervalShort;
			//job.Notifications.IoReadBytesLimit = 1;
			//job.Notifications.IoWriteBytesLimit = 1;
			job.Notifications.JobMemoryLimit = 8092;
			job.Notifications.JobLowMemoryLimit = 4096;
			job.Notifications.NetRateControlTolerance = JOBOBJECT_RATE_CONTROL_TOLERANCE.ToleranceLow;
			job.Notifications.NetRateControlToleranceInterval = JOBOBJECT_RATE_CONTROL_TOLERANCE_INTERVAL.ToleranceIntervalShort;
			//job.Notifications.PerJobUserTimeLimit = TimeSpan.FromMilliseconds(1);
			//job.Notifications.RateControlTolerance = JOBOBJECT_RATE_CONTROL_TOLERANCE.ToleranceLow;
			//job.Notifications.RateControlToleranceInterval = JOBOBJECT_RATE_CONTROL_TOLERANCE_INTERVAL.ToleranceIntervalShort;

			job.StartProcess("notepad.exe");

			for (int i = 0; i < 10; i++)
			{
				Thread.Sleep(1000);
				Thread.Yield();
			}
		}
		finally
		{
			job.TerminateAllProcesses(0);
		}

		static void notHndlr(object? s, JobNotificationEventArgs e) => TestContext.WriteLine($"{DateTime.Now:u}: {e.JobMessage}, {e.Limit}, Limit: {e.NotificationLimit}, Val: {e.ReportedValue}");
	}

	[Test]
	public void OpenJobTest()
	{
		using var job = Job.Create(Environment.UserName);
		Assert.That(job.Handle, ResultIs.ValidHandle);
		//using var job1 = Job.Open(Environment.UserName, JobAccessRight.JOB_OBJECT_QUERY);
		//Assert.That(job1.Handle, ResultIs.ValidHandle);

		Assert.That(() => job.Settings.GroupAffinity, Throws.Nothing);
	}

	[Test]
	public void ProcessesTest()
	{
		Process? p2 = null;
		using (var job = Job.Create())
		{
			job.Settings.KillOnJobClose = true;

			var curProc = Process.GetCurrentProcess();
			Assert.That(job.ContainsProcess(curProc), Is.False);

			var p1 = Process.Start("notepad.exe");
			job.AssignProcess(p1);
			job.AssignProcess(p2 = Process.Start("notepad.exe"));

			Assert.That(job.Processes.Count, Is.EqualTo(2));
			Assert.That(job.Processes.Count(), Is.EqualTo(2));
			Assert.That(job.Processes.First().Id, Is.EqualTo(p1.Id));

			p1.Kill();
			Assert.That(p1.WaitForExit(500), Is.True);
			Assert.That(job.Processes.Count, Is.EqualTo(1));
			Assert.That(job.Processes.Count(), Is.EqualTo(1));
		}
		Assert.That(p2.WaitForExit(500), Is.True);
	}

	[Test]
	public void SettingsMixTest()
	{
		using var job = Job.Create();
		Assert.That(() => job.Settings.Affinity = (UIntPtr)0x2, Throws.Nothing);
		job.Settings.KillOnJobClose = true;
		Assert.That(() => job.Settings.Affinity = (UIntPtr)0x2, Throws.Nothing);
	}

	[Test]
	public void SettingsTest()
	{
		using var job = Job.Create();

		Test(job.Settings, new UIntPtr(0xf), (s, v) => s.Affinity = v, s => s.Affinity, true);
		TestBool(job.Settings, (s, v) => s.ChildProcessBreakawayAllowed = v, s => s.ChildProcessBreakawayAllowed);
		TestBool(job.Settings, (s, v) => s.ChildProcessSilentBreakawayAllowed = v, s => s.ChildProcessSilentBreakawayAllowed);
		TestBool(job.Settings, (s, v) => s.DieOnUnhandledException = v, s => s.DieOnUnhandledException);
		Test(job.Settings, 0xf, (s, v) => s.DscpTag = v, s => s.DscpTag);
		TestBool(job.Settings, (s, v) => s.KillOnJobClose = v, s => s.KillOnJobClose);
		Test(job.Settings, ProcessPriorityClass.BelowNormal, (s, v) => s.PriorityClass = v, s => s.PriorityClass, true);
		Test(job.Settings, 3, (s, v) => s.SchedulingClass = v, s => s.SchedulingClass);
		TestBool(job.Settings, (s, v) => s.TerminateProcessesAtEndOfJobTimeLimit = v, s => s.TerminateProcessesAtEndOfJobTimeLimit);
		Assert.That(() => job.Settings.UIRestrictionsClass = JOBOBJECT_UILIMIT_FLAGS.JOB_OBJECT_UILIMIT_ALL, Throws.Nothing);
		Assert.That(job.Settings.UIRestrictionsClass, Is.EqualTo(JOBOBJECT_UILIMIT_FLAGS.JOB_OBJECT_UILIMIT_ALL));

		Assert.That(() => job.Settings.GroupAffinity.First(), Throws.Nothing);
		Assert.That((uint)job.Settings.GroupAffinity.First().Mask, Is.Not.Zero);
		Assert.That(() => job.Settings.GroupAffinity = job.Settings.GroupAffinity, Throws.Nothing);
	}

	private static void Test<T, TS>(TS js, T? value, Action<TS, T?> set, Func<TS, T?> get, bool ignDef = false) where T : struct
	{
		Assert.That(() => set(js, value), Throws.Nothing);
		Assert.That(get(js).GetValueOrDefault(), Is.EqualTo(value));

		if (!ignDef)
		{
			Assert.That(() => set(js, default(T)), Throws.Nothing);
			Assert.That(get(js).GetValueOrDefault(), Is.EqualTo(default(T)));
		}

		Assert.That(() => set(js, null), Throws.Nothing);
		Assert.That(get(js), Is.Null);
	}

	private static void TestBool<TS>(TS js, Action<TS, bool> set, Func<TS, bool> get)
	{
		var orig = get(js);

		Assert.That(() => set(js, !orig), Throws.Nothing);
		Assert.That(get(js), Is.EqualTo(!orig));

		Assert.That(() => set(js, orig), Throws.Nothing);
		Assert.That(get(js), Is.EqualTo(orig));
	}

	[Test]
	public void StatsTest()
	{
		using var job = Job.Create();
		try
		{
			job.AssignProcess(Process.Start("notepad.exe"));
			Thread.Sleep(200);
		}
		finally
		{
			job.TerminateAllProcesses(0);
			Thread.Sleep(200);
		}
		var stats = job.Statistics;
		stats.WriteValues();
		Assert.That(stats.PeakJobMemoryUsed, Is.GreaterThan(0UL));
		Assert.That(stats.PeakProcessMemoryUsed, Is.GreaterThan(0UL));
		Assert.That(stats.ThisPeriodTotalKernelTime.Ticks, Is.GreaterThanOrEqualTo(0UL));
		Assert.That(stats.ThisPeriodTotalUserTime.Ticks, Is.GreaterThanOrEqualTo(0UL));
		Assert.That(stats.TotalKernelTime.Ticks, Is.GreaterThan(0UL));
		Assert.That(stats.TotalPageFaultCount, Is.GreaterThanOrEqualTo(0UL));
		Assert.That(stats.TotalProcesses, Is.GreaterThan(0UL));
		Assert.That(stats.TotalTerminatedProcesses, Is.GreaterThanOrEqualTo(0UL));
		Assert.That(stats.TotalUserTime.Ticks, Is.GreaterThanOrEqualTo(0UL));
	}

	[Test]
	public void TempTest()
	{
		using var job = Job.Create();
		var str = new JOBOBJECT_NOTIFICATION_LIMIT_INFORMATION_2 { LimitFlags = JOBOBJECT_LIMIT_FLAGS.JOB_OBJECT_LIMIT_JOB_MEMORY_LOW, JobLowMemoryLimit = 4096 };
		using var mem = SafeHGlobalHandle.CreateFromStructure(str);
		if (!SetInformationJobObject(job, JOBOBJECTINFOCLASS.JobObjectNotificationLimitInformation2, mem, mem.Size))
			TestContext.WriteLine($"{Win32Error.GetLastError()}");

		mem.Zero();
		if (QueryInformationJobObject(job, JOBOBJECTINFOCLASS.JobObjectNotificationLimitInformation2, mem, mem.Size, out _))
			mem.ToStructure<JOBOBJECT_NOTIFICATION_LIMIT_INFORMATION_2>().WriteValues();

		str.LimitFlags = 0;
		str.JobLowMemoryLimit = 0;
		mem.Write(str);
		if (!SetInformationJobObject(job, JOBOBJECTINFOCLASS.JobObjectNotificationLimitInformation2, mem, mem.Size))
			TestContext.WriteLine($"{Win32Error.GetLastError()}");

		mem.Zero();
		if (QueryInformationJobObject(job, JOBOBJECTINFOCLASS.JobObjectNotificationLimitInformation2, mem, mem.Size, out _))
			mem.ToStructure<JOBOBJECT_NOTIFICATION_LIMIT_INFORMATION_2>().WriteValues();
	}
}