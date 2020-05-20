using NUnit.Framework;
using System;
using System.Diagnostics;
using Vanara.Extensions;
using static Vanara.PInvoke.NtDll;

namespace Vanara.PInvoke.Tests
{
	[TestFixture]
	public partial class WinternlTests
	{
		[Test]
		public void NtQueryInformationProcessTest()
		{
			var curProc = Process.GetCurrentProcess();
			HPROCESS hProc = curProc.Handle;

			NtQueryResult<PROCESS_BASIC_INFORMATION> pbi = null;
			Assert.That(() => pbi = NtQueryInformationProcess<PROCESS_BASIC_INFORMATION>(hProc, PROCESSINFOCLASS.ProcessBasicInformation), Throws.Nothing);
			Assert.That(pbi, Is.Not.Null);
			// Can do AsRef here since PROCESS_BASIC_INFORMATION has no managed types
			ref var rpbi = ref pbi.AsRef();
			Assert.That(rpbi.UniqueProcessId.ToInt32(), Is.EqualTo(curProc.Id));
			// Have to use ToStructure here since PEB has managed types
			var peb = rpbi.PebBaseAddress.ToStructure<PEB>();
			// Have to use ToStructure here since RTL_USER_PROCESS_PARAMETERS has managed types
			var upp = peb.ProcessParameters.ToStructure<RTL_USER_PROCESS_PARAMETERS>();
			TestContext.WriteLine($"Img: {upp.ImagePathName}; CmdLine: {upp.CommandLine}");

			NtQueryResult<IntPtr> pdp = null;
			Assert.That(() => pdp = NtQueryInformationProcess<IntPtr>(hProc, PROCESSINFOCLASS.ProcessDebugPort), Throws.Nothing);
			Assert.That(pdp, Is.Not.Null);
			TestContext.WriteLine($"DbgPort: {pdp.Value.ToInt64()}");

			NtQueryResult<BOOL> pwi = null;
			Assert.That(() => pwi = NtQueryInformationProcess<BOOL>(hProc, PROCESSINFOCLASS.ProcessWow64Information), Throws.Nothing);
			Assert.That(pwi, Is.Not.Null);
			Assert.That(pwi.Value.Value, Is.True);

			NtQueryResult<UNICODE_STRING> pfn = null;
			Assert.That(() => pfn = NtQueryInformationProcess<UNICODE_STRING>(hProc, PROCESSINFOCLASS.ProcessImageFileName), Throws.Nothing);
			Assert.That(pfn, Is.Not.Null);
			TestContext.WriteLine($"Fn: {pfn}");

			NtQueryResult<BOOL> pbt = null;
			Assert.That(() => pbt = NtQueryInformationProcess<BOOL>(hProc, PROCESSINFOCLASS.ProcessBreakOnTermination), Throws.Nothing);
			Assert.That(pbt, Is.Not.Null);
			Assert.That(pbt.Value.Value, Is.False);

			NtQueryResult<SUBSYSTEM_INFORMATION_TYPE> psi = null;
			// This is documented, but fails on Win10
			Assert.That(() => psi = NtQueryInformationProcess<SUBSYSTEM_INFORMATION_TYPE>(hProc, PROCESSINFOCLASS.ProcessSubsystemInformation), Throws.ArgumentException);
			//Assert.That(psi, Is.Not.Null);
			//Assert.That(Enum.IsDefined(typeof(SUBSYSTEM_INFORMATION_TYPE), psi.Value), Is.True);
			//TestContext.WriteLine($"SubSys: {psi.Value}");
		}
	}
}