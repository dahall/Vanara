using NUnit.Framework;
using static Vanara.PInvoke.Kernel32;

namespace Vanara.PInvoke.Tests;

[TestFixture]
public class JobApiTests
{
	[Test]
	public void ClearSetValueTest()
	{
		using SafeHJOB job = CreateJobObject();

		var bi = QueryInformationJobObject<JOBOBJECT_BASIC_LIMIT_INFORMATION>(job, JOBOBJECTINFOCLASS.JobObjectBasicLimitInformation);
		Assert.That(bi.LimitFlags, Is.EqualTo((JOBOBJECT_LIMIT_FLAGS)0));
		Assert.That(bi.ActiveProcessLimit, Is.Zero);
		bi.WriteValues();

		bi.ActiveProcessLimit = 2U;
		bi.Affinity = (UIntPtr)0xfU;
		bi.LimitFlags |= JOBOBJECT_LIMIT_FLAGS.JOB_OBJECT_LIMIT_ACTIVE_PROCESS | JOBOBJECT_LIMIT_FLAGS.JOB_OBJECT_LIMIT_AFFINITY;
		Assert.That(() => SetInformationJobObject(job, JOBOBJECTINFOCLASS.JobObjectBasicLimitInformation, bi), Throws.Nothing);

		var bi2 = QueryInformationJobObject<JOBOBJECT_BASIC_LIMIT_INFORMATION>(job, JOBOBJECTINFOCLASS.JobObjectBasicLimitInformation);
		Assert.That(bi2.LimitFlags, Is.EqualTo(JOBOBJECT_LIMIT_FLAGS.JOB_OBJECT_LIMIT_ACTIVE_PROCESS | JOBOBJECT_LIMIT_FLAGS.JOB_OBJECT_LIMIT_AFFINITY));
		Assert.That(bi2.ActiveProcessLimit, Is.Not.Zero);
		Assert.That(bi2.Affinity, Is.EqualTo((UIntPtr)0xfU));
		bi2.WriteValues();

		bi2.ActiveProcessLimit = 0;
		bi2.LimitFlags &= ~JOBOBJECT_LIMIT_FLAGS.JOB_OBJECT_LIMIT_ACTIVE_PROCESS;
		Assert.That(() => SetInformationJobObject(job, JOBOBJECTINFOCLASS.JobObjectBasicLimitInformation, bi2), Throws.Nothing);

		var bi3 = QueryInformationJobObject<JOBOBJECT_BASIC_LIMIT_INFORMATION>(job, JOBOBJECTINFOCLASS.JobObjectBasicLimitInformation);
		Assert.That(bi3.LimitFlags.IsFlagSet(JOBOBJECT_LIMIT_FLAGS.JOB_OBJECT_LIMIT_ACTIVE_PROCESS), Is.False);
		Assert.That(bi3.ActiveProcessLimit, Is.Zero);
		bi3.WriteValues();
	}

	[Test]
	public void QueryJobObjectTest()
	{
		using NotepadRunner app = new();

		var sli = QueryInformationJobObject<JOBOBJECT_SECURITY_LIMIT_INFORMATION>(app.Job, JOBOBJECTINFOCLASS.JobObjectSecurityLimitInformation);
		sli.WriteValues();

		var gi = QueryInformationJobObjectArray<ushort>(app.Job, JOBOBJECTINFOCLASS.JobObjectGroupInformation);
		gi.WriteValues();

		var giex = QueryInformationJobObjectArray<GROUP_AFFINITY>(app.Job, JOBOBJECTINFOCLASS.JobObjectGroupInformationEx);
		giex.WriteValues();
	}

	[Test]
	public void CreateAssignChcekJobObjectTest()
	{
		using NotepadRunner app = new();
	}

	[Test]
	public void QuerySetInformationJobObjectTest()
	{
		using NotepadRunner app = new();

		JOBOBJECT_BASIC_LIMIT_INFORMATION bi = QueryInformationJobObject<JOBOBJECT_BASIC_LIMIT_INFORMATION>(app.Job, JOBOBJECTINFOCLASS.JobObjectBasicLimitInformation);
		SetInformationJobObject(app.Job, JOBOBJECTINFOCLASS.JobObjectBasicLimitInformation, bi);

		Assert.That(TerminateJobObject(app.Job, 0), Is.True);
	}

	// Not supported after Win10 1607 [Test]
	public void QuerySetIoRateControlInformationJobObjectTest()
	{
		using NotepadRunner app = new();

		JOBOBJECT_IO_RATE_CONTROL_INFORMATION[] ret = QueryIoRateControlInformationJobObject(app.Job);
		Assert.That(ret, Is.Not.Empty);

		Assert.That(TerminateJobObject(app.Job, 0), Is.True);
	}

	internal class NotepadRunner : IDisposable
	{
		private readonly SafeHPROCESS hProc;
		private readonly SafeHJOB hJob;

		public NotepadRunner()
		{
			hProc = CreateProcess(@"C:\Windows\notepad.exe");
			Assert.That(hProc, ResultIs.ValidHandle);
			hJob = CreateJobObject(null, "Job1");
			Assert.That(hJob, ResultIs.ValidHandle);
			Assert.That(AssignProcessToJobObject(hJob, hProc), Is.True);
			Assert.That(IsProcessInJob(hProc, hJob, out bool res), Is.True);
			Assert.That(res, Is.True);
		}

		public HPROCESS Process => hProc;
		public HJOB Job => hJob;

		public void Dispose()
		{
			Assert.That(TerminateJobObject(hJob, 0), Is.True);
		}
	}
}