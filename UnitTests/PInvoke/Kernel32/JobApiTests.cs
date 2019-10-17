using NUnit.Framework;
using System;
using System.Runtime.InteropServices;
using System.Text;
using Vanara.Extensions;
using Vanara.InteropServices;
using static Vanara.PInvoke.AdvApi32;
using static Vanara.PInvoke.Kernel32;

namespace Vanara.PInvoke.Tests
{
	[TestFixture]
	public class JobApiTests
	{
		[Test]
		public void ClearSetValueTest()
		{
			using var job = CreateJobObject();

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
		public void CreateAssignChcekJobObjectTest()
		{
			using (var hProc = CreateProcess(@"C:\Windows\notepad.exe"))
			{
				Assert.That(hProc, Is.Not.Null);
				using (var hJob = CreateJobObject(null, "Job1"))
				{
					Assert.That(hJob.IsInvalid, Is.False);
					Assert.That(AssignProcessToJobObject(hJob, hProc), Is.True);
					Assert.That(IsProcessInJob(hProc, hJob, out var res), Is.True);
					Assert.That(res, Is.True);
					Assert.That(TerminateJobObject(hJob, 0), Is.True);
				}
			}
		}

		[Test]
		public void QuerySetInformationJobObjectTest()
		{
			using (var hProc = CreateProcess(@"C:\Windows\notepad.exe"))
			{
				Assert.That(hProc, Is.Not.Null);
				using (var hJob = CreateJobObject(null, "Job1"))
				{
					Assert.That(hJob.IsInvalid, Is.False);
					Assert.That(AssignProcessToJobObject(hJob, hProc), Is.True);

					var bi = QueryInformationJobObject<JOBOBJECT_BASIC_LIMIT_INFORMATION>(hJob, JOBOBJECTINFOCLASS.JobObjectBasicLimitInformation);
					SetInformationJobObject(hJob, JOBOBJECTINFOCLASS.JobObjectBasicLimitInformation, bi);

					Assert.That(TerminateJobObject(hJob, 0), Is.True);
				}
			}
		}

		// Not supported after Win10 1607 [Test]
		public void QuerySetIoRateControlInformationJobObjectTest()
		{
			using (var hProc = CreateProcess(@"C:\Windows\notepad.exe"))
			{
				Assert.That(hProc, Is.Not.Null);
				using (var hJob = CreateJobObject(null, "Job1"))
				{
					Assert.That(hJob.IsInvalid, Is.False);
					Assert.That(AssignProcessToJobObject(hJob, hProc), Is.True);

					var ret = QueryIoRateControlInformationJobObject(hJob);
					Assert.That(ret, Is.Not.Empty);

					Assert.That(TerminateJobObject(hJob, 0), Is.True);
				}
			}
		}
	}
}