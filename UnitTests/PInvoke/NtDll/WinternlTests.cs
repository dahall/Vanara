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

		[Test]
		public void GetCommandLineTest()
		{
			var randProc = System.Diagnostics.Process.GetProcesses().Where(p => p.ProcessName.StartsWith("devenv")).First();
			using var hProc = Kernel32.OpenProcess((uint)(Kernel32.ProcessAccess.PROCESS_QUERY_INFORMATION | Kernel32.ProcessAccess.PROCESS_VM_READ), false, (uint)randProc.Id);
			Assert.That(hProc, ResultIs.ValidHandle);

			NtQueryResult<PROCESS_BASIC_INFORMATION> info = null;
			Assert.That(() => info = NtQueryInformationProcess<PROCESS_BASIC_INFORMATION>(hProc, PROCESSINFOCLASS.ProcessBasicInformation), Throws.Nothing);
			Assert.That(info, Is.Not.Null);
			Assert.That(info.AsRef().PebBaseAddress, Is.Not.EqualTo(IntPtr.Zero));

			using var pebPtr = new SafeHGlobalStruct<PEB>();
			Assert.That(Kernel32.ReadProcessMemory(hProc, info.AsRef().PebBaseAddress, pebPtr, pebPtr.Size, out var pebSzRead), ResultIs.Successful);
			Assert.That(pebSzRead, Is.LessThanOrEqualTo(pebPtr.Size));

			using var rtlUserParamsPtr = new SafeHGlobalStruct<RTL_USER_PROCESS_PARAMETERS>();
			Assert.That(Kernel32.ReadProcessMemory(hProc, pebPtr.Value.ProcessParameters, rtlUserParamsPtr, rtlUserParamsPtr.Size, out var rtlUserParamsRead), ResultIs.Successful);
			Assert.That(rtlUserParamsRead, Is.LessThanOrEqualTo(rtlUserParamsPtr.Size));
			var rtlUser = rtlUserParamsPtr.Value;
			Assert.That(rtlUser.ImagePathName.Length, Is.GreaterThan(0));

			var sImage = GetString(rtlUser.ImagePathName);
			StringAssert.StartsWith("C:\\", sImage);
			TestContext.WriteLine($"Img: {sImage}; CmdLine: {GetString(rtlUser.CommandLine)}");

			string GetString(in UNICODE_STRING us)
			{
				using var mem = new SafeCoTaskMemString(us.MaximumLength);
				Assert.That(Kernel32.ReadProcessMemory(hProc, us.Buffer, mem, mem.Size, out _), ResultIs.Successful);
				return mem;
			}
		}
	}
}