using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using Vanara.InteropServices;
using static Vanara.PInvoke.NtDll;

namespace Vanara.PInvoke.Tests
{
	[TestFixture]
	public partial class NtDllTests
	{
		[Test]
		public void NtQuerySystemInformationTest()
		{
#pragma warning disable CS0618 // Type or member is obsolete
			var bi = NtQuerySystemInformation<SYSTEM_BASIC_INFORMATION>(SYSTEM_INFORMATION_CLASS.SystemBasicInformation);
#pragma warning restore CS0618 // Type or member is obsolete
			Assert.That(bi.NumberOfProcessors, Is.Not.Zero);
			var qi = NtQuerySystemInformation<SYSTEM_REGISTRY_QUOTA_INFORMATION>(SYSTEM_INFORMATION_CLASS.SystemRegistryQuotaInformation);
			Assert.That(qi.RegistryQuotaUsed, Is.Not.Zero);
			var ppi = NtQuerySystemInformation<SYSTEM_PROCESSOR_PERFORMANCE_INFORMATION[]>(SYSTEM_INFORMATION_CLASS.SystemProcessorPerformanceInformation);
			Assert.That(ppi.Length, Is.EqualTo(bi.NumberOfProcessors));

			var arr = NtQuerySystemInformation<SYSTEM_PROCESS_INFORMATION[]>(SYSTEM_INFORMATION_CLASS.SystemProcessInformation);
			var pti = NtQuerySystemInformation_Process();
			Assert.That(arr.Length, Is.EqualTo(pti.Count));

			TestContext.WriteLine($"{bi.NumberOfProcessors} Cores; {pti.Count} Processes; {pti.Sum(t => t.Item2.Length)} Threads");
		}
	}
}