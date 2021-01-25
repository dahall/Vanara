using NUnit.Framework;
using NUnit.Framework.Constraints;
using System;
using System.Diagnostics;
using System.Linq;
using Vanara.Extensions;
using Vanara.InteropServices;
using static Vanara.PInvoke.NtDll;

namespace Vanara.PInvoke.Tests
{
	[TestFixture]
	public partial class WinternlTests
	{
		[Test]
		public void NtQueryInformationProcessTest()
		{
			HPROCESS hProc = Kernel32.GetCurrentProcess();

			using var pbi = NtQueryInformationProcess<PROCESS_BASIC_INFORMATION>(hProc, PROCESSINFOCLASS.ProcessBasicInformation);
			Assert.That(pbi, ResultIs.ValidHandle);
			// Can get pointer here since PROCESS_BASIC_INFORMATION has no managed types
			unsafe
			{
				var rpbi = (PROCESS_BASIC_INFORMATION*)pbi;
				Assert.That(rpbi->UniqueProcessId.ToInt32(), Is.EqualTo(Kernel32.GetCurrentProcessId()));
				Assert.That(rpbi->PebBaseAddress, Is.Not.EqualTo(IntPtr.Zero));
				// Have to use ToStructure here since PEB has managed types
				var peb = rpbi->PebBaseAddress.ToStructure<PEB>();
				// Have to use ToStructure here since RTL_USER_PROCESS_PARAMETERS has managed types
				var upp = peb.ProcessParameters.ToStructure<RTL_USER_PROCESS_PARAMETERS>();
				Assert.That(upp.CommandLine.ToString(hProc), Is.Not.Empty);
				TestContext.WriteLine($"Img: {upp.ImagePathName.ToString(hProc)}; CmdLine: {upp.CommandLine.ToString(hProc)}");
			}

			NtQueryResult<IntPtr> pdp = null;
			Assert.That(() => pdp = NtQueryInformationProcess<IntPtr>(hProc, PROCESSINFOCLASS.ProcessDebugPort), Throws.Nothing);
			Assert.That(pdp, ResultIs.ValidHandle);
			TestContext.WriteLine($"DbgPort: {pdp.Value.ToInt64()}");

			NtQueryResult<BOOL> pwi = null;
			Assert.That(() => pwi = NtQueryInformationProcess<BOOL>(hProc, PROCESSINFOCLASS.ProcessWow64Information), Throws.Nothing);
			Assert.That(pwi, ResultIs.ValidHandle);
			Assert.That(pwi.Value.Value, Is.True);

			NtQueryResult<UNICODE_STRING> pfn = null;
			Assert.That(() => pfn = NtQueryInformationProcess<UNICODE_STRING>(hProc, PROCESSINFOCLASS.ProcessImageFileName), Throws.Nothing);
			Assert.That(pfn, ResultIs.ValidHandle);
			TestContext.WriteLine($"Fn: {pfn.Value.ToString(hProc)}");

			NtQueryResult<BOOL> pbt = null;
			Assert.That(() => pbt = NtQueryInformationProcess<BOOL>(hProc, PROCESSINFOCLASS.ProcessBreakOnTermination), Throws.Nothing);
			Assert.That(pbt, ResultIs.ValidHandle);
			Assert.That(pbt.Value.Value, Is.False);

			NtQueryResult<SUBSYSTEM_INFORMATION_TYPE> psi = null;
			// This is documented, but fails on Win10
			Assert.That(() => psi = NtQueryInformationProcess<SUBSYSTEM_INFORMATION_TYPE>(hProc, PROCESSINFOCLASS.ProcessSubsystemInformation), Throws.ArgumentException);
			//Assert.That(psi, ResultIs.ValidHandle);
			//Assert.That(Enum.IsDefined(typeof(SUBSYSTEM_INFORMATION_TYPE), psi.Value), Is.True);
			//TestContext.WriteLine($"SubSys: {psi.Value}");

			// Try undocumented fetch
			NtQueryResult<uint> ppb = null;
			Assert.That(() => ppb = NtQueryInformationProcess<uint>(hProc, PROCESSINFOCLASS.ProcessPriorityBoost), Throws.Nothing);
			TestContext.WriteLine($"Priority boost: {ppb.Value}");
		}
	}
}