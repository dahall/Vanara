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