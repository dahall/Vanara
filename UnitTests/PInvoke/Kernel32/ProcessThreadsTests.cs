using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Vanara.Extensions;
using Vanara.InteropServices;
using static Vanara.PInvoke.Kernel32;

namespace Vanara.PInvoke.Tests
{
	public static class TestHelper
	{
		public static void RunForEach<TEnum>(Type lib, string name, Func<TEnum, object[]> makeParam, Action<TEnum, object, object[]> action = null, Action<Exception> error = null) where TEnum : Enum
		{
			var mi = lib.GetMethods(System.Reflection.BindingFlags.Public | System.Reflection.BindingFlags.Static).Where(m => m.IsGenericMethod && m.Name == name).First();
			if (mi is null) throw new ArgumentException("Unable to find method.");
			foreach (var e in Enum.GetValues(typeof(TEnum)).Cast<TEnum>())
			{
				var type = CorrespondingTypeAttribute.GetCorrespondingTypes(e).FirstOrDefault();
				if (type is null)
				{
					TestContext.WriteLine($"No corresponding type found for {e}.");
					continue;
				}
				var gmi = mi.MakeGenericMethod(type);
				var param = makeParam(e);
				try
				{
					var ret = gmi.Invoke(null, param);
					action?.Invoke(e, ret, param);
				}
				catch (Exception ex)
				{
					error?.Invoke(ex);
				}
			}
		}

		public static void WriteValues(this object value)
		{
			TestContext.WriteLine(ObjectDumper.ObjectDumperExtensions.DumpToString(value, value.ToString()));
		}
	}

	[TestFixture]
	public class ProcessThreadsTests
	{
		[Test]
		public void CreateProcessTest()
		{
			var res = CreateProcess(null, new StringBuilder("notepad.exe"), default, default, false, 0, default, null, STARTUPINFO.Default, out var pi);
			if (!res) TestContext.WriteLine(Win32Error.GetLastError());
			Assert.That(res);
			using (pi)
			{
				Assert.That(pi.hProcess.IsInvalid, Is.False);
				Assert.That(pi.hThread.IsInvalid, Is.False);
				Assert.That(pi.dwProcessId, Is.GreaterThan(0));
				Assert.That(pi.dwThreadId, Is.GreaterThan(0));

				Assert.That(GetProcessId(pi.hProcess), Is.EqualTo(pi.dwProcessId));
				Assert.That(GetThreadId(pi.hThread), Is.EqualTo(pi.dwThreadId));
				Assert.That(GetProcessIdOfThread(pi.hThread), Is.EqualTo(pi.dwProcessId));
				TerminateProcess(pi.hProcess, 0);
			}
		}

		[Test]
		public void CreateProcessTest2()
		{
			using (var res = CreateProcess("notepad.exe"))
			{
				Assert.That(res.IsInvalid, Is.False);
				TerminateProcess(res, 0);
			}
		}

		[Test]
		public void CreateProcessTest3()
		{
			var res = CreateProcess(null, new StringBuilder("notepad.exe"), default, default, false, 0, default, null, STARTUPINFOEX.Default, out var pi);
			if (!res) TestContext.WriteLine(Win32Error.GetLastError());
			Assert.That(res);
			using (pi)
			{
				Assert.That(pi.hProcess.IsInvalid, Is.False);
				Assert.That(pi.hThread.IsInvalid, Is.False);
				Assert.That(pi.dwProcessId, Is.GreaterThan(0));
				Assert.That(pi.dwThreadId, Is.GreaterThan(0));
				TerminateProcess(pi.hProcess, 0);
			}
		}

		[Test]
		public void CreateProcessTest4()
		{
			var res = CreateProcess(@"C:\Windows\system32\cmd.exe", null, default, default, false, 0, new[] { @"PATH=C:\Windows", "DOG=Bone" }, null, STARTUPINFO.Default, out var pi);
			if (!res) TestContext.WriteLine(Win32Error.GetLastError());
			Assert.That(res);
			using (pi)
			{
				Assert.That(pi.hProcess.IsInvalid, Is.False);
				Assert.That(pi.hThread.IsInvalid, Is.False);
				Assert.That(pi.dwProcessId, Is.GreaterThan(0));
				Assert.That(pi.dwThreadId, Is.GreaterThan(0));
				TerminateProcess(pi.hProcess, 0);
			}
		}

		[Test]
		public void CreateRemoteThreadTest()
		{
			//Assert.That(CreateRemoteThread(), Is.Zero);
		}

		[Test]
		public void CreateThreadTest()
		{
			uint threadId = 0;
			using (var hThread = CreateThread(lpStartAddress: ThreadProc, dwCreationFlags: CREATE_THREAD_FLAGS.CREATE_SUSPENDED, lpThreadId: out threadId))
			{
				Assert.That(hThread.IsInvalid, Is.False);
				Assert.That(GetThreadId(hThread), Is.EqualTo(threadId));
				Assert.That(ResumeThread(hThread), Is.LessThanOrEqualTo(1));
				Sleep(50);
				Assert.That(ResumeThread(hThread), Is.LessThanOrEqualTo(1));
				Assert.That(WaitForSingleObject(hThread, INFINITE), Is.EqualTo(WAIT_STATUS.WAIT_OBJECT_0));
				Assert.That(GetExitCodeThread(hThread, out var exitCode), Is.True);
				Assert.That((HRESULT)exitCode, Is.EqualTo((HRESULT)0));
			}

			uint ThreadProc(IntPtr param)
			{
				using (var hThread = OpenThread((int)ThreadAccess.THREAD_ALL_ACCESS, false, threadId))
				{
					SuspendThread(hThread);

					Assert.That(GetThreadPriority(hThread), Is.EqualTo((int)THREAD_PRIORITY.THREAD_PRIORITY_NORMAL));
					Assert.That(SetThreadPriority(hThread, (int)THREAD_PRIORITY.THREAD_PRIORITY_BELOW_NORMAL), Is.True);

					var ctx = new CONTEXT(CONTEXT_FLAG.CONTEXT_ALL);
					var ret = GetThreadContext(hThread, ref ctx);
					if (!ret) return (uint)(int)(HRESULT)Win32Error.GetLastError();
					ret = SetThreadContext(hThread, ctx);
					if (!ret) return (uint)(int)(HRESULT)Win32Error.GetLastError();
				}
				return 0U;
			}
		}

		[Test]
		public void FlushCacheTest()
		{
			Assert.That(() => FlushProcessWriteBuffers(), Throws.Nothing);
			Assert.That(FlushInstructionCache(GetCurrentProcess()), Is.True);
		}

		[Test]
		public void GetCurrentProcessIdTest()
		{
			Assert.That(GetCurrentProcessId(), Is.GreaterThan(0));
		}

		[Test]
		public void GetCurrentProcessorNumberTest()
		{
			var p = GetCurrentProcessorNumber();
			Assert.That(p, Is.LessThan(8));
			GetCurrentProcessorNumberEx(out var pNum);
			Assert.That(pNum.Number, Is.LessThan(8));
			TestContext.Write($"Num:{p}; Grp:{pNum.Group}; GrpNum:{pNum.Number}");
		}

		[Test]
		public void GetCurrentProcessTest()
		{
			var h = GetCurrentProcess();
			Assert.That(h, Is.EqualTo((HPROCESS)new IntPtr(-1)));
		}

		[Test]
		public void GetCurrentProcessTokenTest()
		{
			var h = GetCurrentProcessToken();
			Assert.That(h, Is.EqualTo((HTOKEN)new IntPtr(-4)));
		}

		[Test]
		public void GetCurrentThreadEffectiveTokenTest()
		{
			var h = GetCurrentThreadEffectiveToken();
			Assert.That(h, Is.EqualTo((HTOKEN)new IntPtr(-6)));
		}

		[Test]
		public void GetCurrentThreadIdTest()
		{
			var i = GetCurrentThreadId();
			Assert.That(i, Is.Not.EqualTo(0));
		}

		[Test]
		public void GetCurrentThreadStackLimitsTest()
		{
			GetCurrentThreadStackLimits(out var low, out var high);
			Assert.That(low.ToUInt64(), Is.GreaterThan(0));
			Assert.That(high.ToUInt64(), Is.GreaterThan(low.ToUInt64()));
			TestContext.Write($"{low}:{high}");
		}

		[Test]
		public void GetCurrentThreadTest()
		{
			var h = GetCurrentThread();
			Assert.That(h, Is.EqualTo((HTHREAD)new IntPtr(-2)));
		}

		[Test]
		public void GetCurrentThreadTokenTest()
		{
			var h = GetCurrentThreadToken();
			Assert.That(h, Is.EqualTo((HTOKEN)new IntPtr(-5)));
		}

		[Test]
		public void GetProcessHandleCountTest()
		{
			Assert.That(GetProcessHandleCount(GetCurrentProcess(), out var cnt), Is.True);
			Assert.That(cnt, Is.GreaterThan(0));
		}

		[Test]
		public void GetProcessInformationTest()
		{
			object o = 0;
			Assert.That(() => o = GetProcessInformation<MEMORY_PRIORITY_INFORMATION>(GetCurrentProcess(), PROCESS_INFORMATION_CLASS.ProcessMemoryPriority), Throws.Nothing);
			o.WriteValues();
			Assert.That(() => o = GetProcessInformation<APP_MEMORY_INFORMATION>(GetCurrentProcess(), PROCESS_INFORMATION_CLASS.ProcessAppMemoryInfo), Throws.Nothing);
			o.WriteValues();
			Assert.That(() => o = GetProcessInformation<PROCESS_PROTECTION_LEVEL_INFORMATION>(GetCurrentProcess(), PROCESS_INFORMATION_CLASS.ProcessProtectionLevelInfo), Throws.Nothing);
			o.WriteValues();

			Assert.That(() => GetProcessInformation<PROCESS_MEMORY_EXHAUSTION_INFO>(GetCurrentProcess(), PROCESS_INFORMATION_CLASS.ProcessMemoryExhaustionInfo), Throws.Exception);
			Assert.That(() => GetProcessInformation<PROCESS_POWER_THROTTLING_STATE>(GetCurrentProcess(), PROCESS_INFORMATION_CLASS.ProcessPowerThrottling), Throws.Exception);
			Assert.That(() => GetProcessInformation<uint>(GetCurrentProcess(), PROCESS_INFORMATION_CLASS.ProcessInPrivateInfo), Throws.Exception);
			Assert.That(() => GetProcessInformation<uint>(GetCurrentProcess(), PROCESS_INFORMATION_CLASS.ProcessReservedValue1), Throws.Exception);
			Assert.That(() => GetProcessInformation<uint>(GetCurrentProcess(), PROCESS_INFORMATION_CLASS.ProcessTelemetryCoverageInfo), Throws.Exception);
		}

		[Test]
		public void GetProcessMitigationPolicyTest()
		{
			var hProc = GetCurrentProcess();
			TestHelper.RunForEach<PROCESS_MITIGATION_POLICY>(typeof(Kernel32), "GetProcessMitigationPolicy", e => new object[] { hProc, e, null }, (e, ret, param) =>
			{
				if (!(bool)ret) TestContext.WriteLine($"{e} -> {Win32Error.GetLastError()}");
				Assert.That(ret, Is.True);
				param[2].WriteValues();
			});
		}

		[Test]
		public void GetProcessTimesTest()
		{
			Assert.That(GetProcessTimes(GetCurrentProcess(), out var ct, out var xt, out var kt, out var ut), Is.True);
			Assert.That(ct.ToDateTime(), Is.LessThan(DateTime.Now));
			TestContext.Write($"{ct.ToDateTime()}, {xt.ToDateTime()}, {kt.ToDateTime()}, {ut.ToDateTime()}");
		}

		[Test]
		public void GetProcessVersionTest()
		{
			var v = GetProcessVersion();
			Assert.That(v, Is.Not.Zero);
			TestContext.Write($"{new Version(Macros.HIWORD(v), Macros.LOWORD(v))}");
		}

		[Test]
		public void GetSetPriorityClassTest()
		{
			var pc = GetPriorityClass(GetCurrentProcess());
			Assert.That(SetPriorityClass(GetCurrentProcess(), CREATE_PROCESS.BELOW_NORMAL_PRIORITY_CLASS), Is.True);
			Assert.That(GetPriorityClass(GetCurrentProcess()), Is.EqualTo(CREATE_PROCESS.BELOW_NORMAL_PRIORITY_CLASS));
			Assert.That(SetPriorityClass(GetCurrentProcess(), pc), Is.True);
		}

		[Test]
		public void GetSetProcessDefaultCpuSetsTest()
		{
			Assert.That(GetProcessDefaultCpuSets(GetCurrentProcess()), Has.Length.EqualTo(0));

			var ssi = GetSystemCpuSetInformation(GetCurrentProcess()).ToArray();
			var cpuSets = ssi.Select(s => s.CpuSet.Id).ToArray();
			Assert.That(SetProcessDefaultCpuSets(GetCurrentProcess(), cpuSets, (uint)cpuSets.Length), Is.True);

			Assert.That(GetProcessDefaultCpuSets(GetCurrentProcess()), Has.Length.EqualTo(cpuSets.Length));
			TestContext.Write(string.Join(",", GetProcessDefaultCpuSets(GetCurrentProcess())));
		}

		[Test]
		public void GetSetProcessPriorityBoostTest()
		{
			Assert.That(SetProcessPriorityBoost(GetCurrentProcess(), true));
			Assert.That(GetProcessPriorityBoost(GetCurrentProcess(), out var disable), Is.True);
			Assert.That(disable, Is.True);
		}

		[Test]
		public void GetSetProcessShutdownParametersTest()
		{
			Assert.That(SetProcessShutdownParameters(0x4C0, SHUTDOWN.SHUTDOWN_NORETRY), Is.True);
			Assert.That(GetProcessShutdownParameters(out var level, out var flags), Is.True);
			Assert.That(level, Is.EqualTo(0x4C0));
		}

		[Test]
		public void GetSetThreadContextTest()
		{
			// See CreateThreadTest
		}

		[Test]
		public void GetSetThreadDescriptionTest()
		{
			const string cDesc = "test";
			var hThread = GetCurrentThread();
			Assert.That(SetThreadDescription(hThread, cDesc).Succeeded, Is.True);
			Assert.That(GetThreadDescription(hThread, out var desc).Succeeded, Is.True);
		}

		[Test]
		public void GetSetThreadPriorityBoostTest()
		{
			Assert.That(GetThreadPriorityBoost(GetCurrentThread(), out var disable), Is.True);
			Assert.That(SetThreadPriorityBoost(GetCurrentThread(), !disable), Is.True);
			Assert.That(SetThreadPriorityBoost(GetCurrentThread(), disable), Is.True);
		}

		[Test]
		public void GetSetThreadSelectedCpuSetsTest()
		{
			Assert.That(GetThreadSelectedCpuSets(GetCurrentThread()), Has.Length.EqualTo(0));

			var ssi = GetSystemCpuSetInformation(GetCurrentProcess()).ToArray();
			var cpuSets = ssi.Select(s => s.CpuSet.Id).ToArray();
			Assert.That(SetThreadSelectedCpuSets(GetCurrentThread(), cpuSets, (uint)cpuSets.Length), Is.True);

			Assert.That(GetThreadSelectedCpuSets(GetCurrentThread()), Has.Length.EqualTo(cpuSets.Length));
			TestContext.Write(string.Join(",", GetThreadSelectedCpuSets(GetCurrentThread())));
		}

		[Test]
		public void GetStartupInfoTest()
		{
			Assert.That(() =>
			{
				GetStartupInfo(out var si);
				Assert.That(si.cb, Is.GreaterThan(0));
				Assert.That(si.lpTitle, Is.Not.Null);
			}, Throws.Nothing);
		}

		[Test]
		public void GetSystemCpuSetInformationTest()
		{
			Assert.That(GetSystemCpuSetInformation(GetCurrentProcess()), Is.Not.Empty);
		}

		[Test]
		public void GetSystemTimesTest()
		{
			Assert.That(GetSystemTimes(out var idle, out var kern, out var user), Is.True);
			Assert.That(kern.ToDateTime(), Is.GreaterThan(idle.ToDateTime()));
			Assert.That(user.ToUInt64(), Is.Not.Zero);
		}

		[Test]
		public void GetThreadIdealProcessorExTest()
		{
			Assert.That(GetThreadIdealProcessorEx(GetCurrentThread(), out var num), Is.True);
			Assert.That(num.Number, Is.LessThan(Environment.ProcessorCount));
		}

		[Test]
		public void GetThreadInformationTest()
		{
			TestHelper.RunForEach<THREAD_INFORMATION_CLASS>(typeof(Kernel32), "GetThreadInformation", e => new object[] { GetCurrentThread(), e },
				(e, ret, param) => ret.WriteValues(), ex => throw ex);
		}

		[Test]
		public void GetThreadIOPendingFlagTest()
		{
			Assert.That(GetThreadIOPendingFlag(GetCurrentThread(), out var pending), Is.True);
		}

		[Test]
		public void GetThreadTimesTest()
		{
			Assert.That(GetThreadTimes(GetCurrentThread(), out var ct, out var xt, out var kt, out var ut), Is.True);
			Assert.That(ct.ToDateTime(), Is.LessThan(DateTime.Now));
			TestContext.Write($"{ct.ToDateTime()}, {xt.ToDateTime()}, {kt.ToDateTime()}, {ut.ToDateTime()}");
		}

		[Test]
		public void IsProcessCriticalTest()
		{
			Assert.That(IsProcessCritical(GetCurrentProcess(), out var critical), Is.True);
		}

		[Test]
		public void IsProcessorFeaturePresentTest()
		{
			Assert.That(IsProcessorFeaturePresent(PROCESSOR_FEATURE.PF_RDRAND_INSTRUCTION_AVAILABLE), Is.True);
		}

		[Test]
		public void OpenProcessTest()
		{
			using (var hProc = OpenProcess((uint)ProcessAccess.PROCESS_ALL_ACCESS, false, GetCurrentProcessId()))
			{
				Assert.That(hProc.IsInvalid, Is.False);
			}
		}

		[Test]
		public void OpenThreadTest()
		{
			using (var hThread = OpenThread((uint)ThreadAccess.THREAD_ALL_ACCESS, false, GetCurrentThreadId()))
			{
				Assert.That(hThread.IsInvalid, Is.False);
			}
		}

		[Test]
		public void ProcessIdToSessionIdTest()
		{
			Assert.That(ProcessIdToSessionId(GetCurrentProcessId(), out var sess), Is.True);
		}

		[Test]
		public void QueryProcessAffinityUpdateModeTest()
		{
			Assert.That(QueryProcessAffinityUpdateMode(GetCurrentProcess(), out var flag), Is.True);
		}

		[Test]
		public void QuerySetProtectedPolicyTest()
		{
			var g = Guid.NewGuid();
			var v = new PinnedObject(100);
			Assert.That(SetProtectedPolicy(g, v, out var old), Is.True);
			Assert.That(old, Is.EqualTo(IntPtr.Zero));
			Assert.That(QueryProtectedPolicy(g, out var newVal), Is.True);
			Assert.That(newVal, Is.EqualTo((IntPtr)v));
		}

		[Test]
		public void QueueUserAPCTest()
		{
			Assert.That(QueueUserAPC(papc, GetCurrentThread(), IntPtr.Zero), Is.True);

			void papc(IntPtr dwParam) { }
		}

		[Test]
		public void SafeProcThreadAttributeListTest()
		{
			Assert.That(PROC_THREAD_ATTRIBUTE.PROC_THREAD_ATTRIBUTE_HANDLE_LIST, Is.EqualTo(new UIntPtr(0x20002)));
			Assert.That(() =>
			{
				var l = SafeProcThreadAttributeList.Create(new Dictionary<PROC_THREAD_ATTRIBUTE, object>
				{
					{PROC_THREAD_ATTRIBUTE.PROC_THREAD_ATTRIBUTE_IDEAL_PROCESSOR, new PROCESSOR_NUMBER(0, 2) },
					{PROC_THREAD_ATTRIBUTE.PROC_THREAD_ATTRIBUTE_MITIGATION_POLICY, 0x00000001UL },
				});
				l.Dispose();
			}, Throws.Nothing);
		}

		[Test]
		public void SetProcessAffinityUpdateModeTest()
		{
			Assert.That(SetProcessAffinityUpdateMode(GetCurrentProcess(), PROCESS_AFFINITY_MODE.PROCESS_AFFINITY_ENABLE_AUTO_UPDATE), Is.True);
		}

		[Test]
		public void SetProcessInformationTest()
		{
			Assert.That(SetProcessInformation(GetCurrentProcess(), PROCESS_INFORMATION_CLASS.ProcessMemoryPriority, new MEMORY_PRIORITY_INFORMATION(MEMORY_PRIORITY.MEMORY_PRIORITY_BELOW_NORMAL)), Is.True);
			Assert.That(SetProcessInformation(GetCurrentProcess(), PROCESS_INFORMATION_CLASS.ProcessPowerThrottling, new PROCESS_POWER_THROTTLING_STATE(PROCESS_POWER_THROTTLING_MASK.PROCESS_POWER_THROTTLING_EXECUTION_SPEED, 0)), Is.True);
		}

		[Test]
		public void SetProcessMitigationPolicyTest()
		{
			Assert.That(SetProcessMitigationPolicy(PROCESS_MITIGATION_POLICY.ProcessImageLoadPolicy, new PROCESS_MITIGATION_IMAGE_LOAD_POLICY { Flags = PROCESS_MITIGATION_IMAGE_LOAD_POLICY_FLAGS.NoRemoteImages }), Is.True);
			//Assert.That(GetProcessMitigationPolicy<ulong[]>(GetCurrentProcess(), PROCESS_MITIGATION_POLICY.ProcessMitigationOptionsMask, out var p), Is.True);
			//Assert.That(SetProcessMitigationPolicy(PROCESS_MITIGATION_POLICY.ProcessMitigationOptionsMask, p), Is.True);
		}

		[Test]
		public void SetThreadIdealProcessorExTest()
		{
			var p = SetThreadIdealProcessor(GetCurrentThread(), MAXIMUM_PROCESSORS);
			Assert.That(p, Is.Not.Zero);
			var pn = new PROCESSOR_NUMBER(0, (byte)p);
			Assert.That(SetThreadIdealProcessorEx(GetCurrentThread(), pn, out var ppn), Is.True);
		}

		[Test]
		public void SetThreadIdealProcessorTest()
		{
			var p = SetThreadIdealProcessor(GetCurrentThread(), MAXIMUM_PROCESSORS);
			Assert.That(p, Is.Not.Zero);
			Assert.That(SetThreadIdealProcessor(GetCurrentThread(), p), Is.Not.EqualTo(uint.MaxValue));
		}

		[Test]
		public void SetThreadInformationTest()
		{
			Assert.That(SetThreadInformation(GetCurrentThread(), THREAD_INFORMATION_CLASS.ThreadMemoryPriority, new MEMORY_PRIORITY_INFORMATION(MEMORY_PRIORITY.MEMORY_PRIORITY_BELOW_NORMAL)), Is.True);
			Assert.That(SetThreadInformation(GetCurrentThread(), THREAD_INFORMATION_CLASS.ThreadPowerThrottling, THREAD_POWER_THROTTLING_STATE.Create()), Is.True);
		}

		[Test]
		public void SetThreadStackGuaranteeTest()
		{
			var sz = 0U;
			Assert.That(SetThreadStackGuarantee(ref sz), Is.True);
			Assert.That(sz, Is.GreaterThan(0));
			Assert.That(SetThreadStackGuarantee(ref sz), Is.True);
		}

		[Test]
		public void SwitchToThreadTest()
		{
			Assert.That(SwitchToThread(), Is.True);
		}

		[Test]
		public void TlsTest()
		{
			var idx = TlsAlloc();
			Assert.That(idx, Is.Not.EqualTo(TLS_OUT_OF_INDEXES));
			var o = new PinnedObject(256);
			try
			{
				Assert.That(TlsSetValue(idx, o), Is.True);
				Assert.That(TlsGetValue(idx), Is.EqualTo((IntPtr)o));
			}
			finally
			{
				Assert.That(TlsFree(idx), Is.True);
			}
		}
	}
}