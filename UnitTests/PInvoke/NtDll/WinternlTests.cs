using NUnit.Framework;
using System;
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
            HPROCESS hProc = Kernel32.GetCurrentProcess();
            var procIsWow64 = hProc.IsWow64();
            var procIs64 = Environment.Is64BitProcess;
            var osIs64 = Environment.Is64BitOperatingSystem;

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

        [Test]
        public void DbgUiSetThreadDebugObjectAndNtRemoveProcessDebugTest()
        {
            Kernel32.STARTUPINFO StartInfo = new Kernel32.STARTUPINFO
            {
                dwFlags = Kernel32.STARTF.STARTF_USESHOWWINDOW,
                wShowWindow = (ushort)ShowWindowCommand.SW_HIDE
            };

            Assert.IsTrue(Kernel32.CreateProcess("notepad.exe", dwCreationFlags: Kernel32.CREATE_PROCESS.DEBUG_PROCESS | Kernel32.CREATE_PROCESS.CREATE_UNICODE_ENVIRONMENT, lpStartupInfo: StartInfo, lpProcessInformation: out Kernel32.SafePROCESS_INFORMATION Information));

            using (Information)
            using (NtQueryResult<IntPtr> DebugObjectHandleQueryResult = NtQueryInformationProcess<IntPtr>(Information.hProcess, PROCESSINFOCLASS.ProcessDebugObjectHandle))
            {
                Assert.That(DebugObjectHandleQueryResult, ResultIs.ValidHandle);
                Assert.That(DebugObjectHandleQueryResult.Value, ResultIs.ValidHandle);

                try
                {
                    Assert.DoesNotThrow(() => DbgUiSetThreadDebugObject(DebugObjectHandleQueryResult.Value).ThrowIfFailed());

                    try
                    {
                        Kernel32.SafeHPROCESS DebugProcessHandle = Kernel32.SafeHPROCESS.Null;

                        try
                        {
                            while (true)
                            {
                                Assert.IsTrue(Kernel32.WaitForDebugEvent(out Kernel32.DEBUG_EVENT Event, Kernel32.INFINITE));

                                if (Event.dwDebugEventCode == Kernel32.DEBUG_EVENT_CODE.CREATE_PROCESS_DEBUG_EVENT)
                                {
                                    DebugProcessHandle = new Kernel32.SafeHPROCESS(Event.u.CreateProcessInfo.hProcess);
                                    break;
                                }

                                Assert.IsTrue(Kernel32.ContinueDebugEvent(Event.dwProcessId, Event.dwThreadId, Kernel32.DEBUG_CONTINUE.DBG_CONTINUE));
                            }

                            Assert.AreNotEqual(Kernel32.SafeHPROCESS.Null, DebugProcessHandle);
                        }
                        finally
                        {
                            DebugProcessHandle.Dispose();
                        }
                    }
                    finally
                    {
                        Assert.DoesNotThrow(() => DbgUiSetThreadDebugObject(IntPtr.Zero).ThrowIfFailed());
                    }
                }
                finally
                {
                    Assert.IsTrue(Kernel32.TerminateProcess(Information.hProcess, 0));
                    Assert.DoesNotThrow(() => NtRemoveProcessDebug(Information.hProcess, DebugObjectHandleQueryResult.Value).ThrowIfFailed());
                }
            }
        }
    }
}