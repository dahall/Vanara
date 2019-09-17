using NUnit.Framework;
using System;
using System.Text;
using Vanara.Extensions;
using Vanara.InteropServices;
using static Vanara.PInvoke.AdvApi32;
using static Vanara.PInvoke.Kernel32;

namespace Vanara.PInvoke.Tests
{
	[TestFixture()]
	public class WinBase_EventLogTests
	{
		private const string eventLogName = TestCaseSources.LogFile;

		[Test]
		public void OpenBackupClearCloseEventLogTest()
		{
			using (var hEL = OpenEventLog(null, eventLogName))
			using (var tmp = new TempFile(null))
			{
				Assert.That(hEL, ResultIs.ValidHandle);
				Assert.That(BackupEventLog(hEL, tmp.FullName), ResultIs.Successful);
				using (var hBEL = OpenBackupEventLog(null, tmp.FullName))
					Assert.That(hBEL, ResultIs.ValidHandle);
				using (var hBEL = OpenEventLog(null, tmp.FullName))
				{
					Assert.That(hBEL, ResultIs.ValidHandle);
					Assert.That(ClearEventLog(hBEL, null), ResultIs.Successful);
				}
			}
		}

		[Test]
		public void RegisterEventSourceTest()
		{
			using (var hES = RegisterEventSource(null, "TestSource"))
			{
				Assert.That(hES, ResultIs.ValidHandle);
				using (var mem = SafeHGlobalHandle.CreateFromStructure<EVENTLOG_FULL_INFORMATION>())
				{
					Assert.That(GetEventLogInformation(hES, 0, mem, mem.Size, out var req), ResultIs.Successful);
					mem.ToStructure<EVENTLOG_FULL_INFORMATION>().WriteValues();
				}
			}
		}

		[Test]
		public void GetEventLogInformationTest()
		{
			using (var hEL = OpenEventLog(null, eventLogName))
			using (var mem = SafeHGlobalHandle.CreateFromStructure<EVENTLOG_FULL_INFORMATION>())
			{
				Assert.That(GetEventLogInformation(hEL, 0, mem, mem.Size, out var req), ResultIs.Successful);
				mem.ToStructure<EVENTLOG_FULL_INFORMATION>().WriteValues();
			}
		}

		[Test]
		public void GetNumberOfEventLogRecordsTest()
		{
			using (var hEL = OpenEventLog(null, eventLogName))
			{
				Assert.That(GetNumberOfEventLogRecords(hEL, out var numRec), ResultIs.Successful);
				Assert.That(numRec, Is.GreaterThan(0));
				TestContext.Write(numRec);
			}
		}

		[Test]
		public void GetOldestEventLogRecordTest()
		{
			using (var hEL = OpenEventLog(null, eventLogName))
			{
				Assert.That(GetOldestEventLogRecord(hEL, out var oldRec), ResultIs.Successful);
				Assert.That(oldRec, Is.GreaterThan(0));
				TestContext.Write(oldRec);
			}
		}

		[Test]
		public void NotifyChangeEventLogTest()
		{
			using (var hEvent = CreateEvent(null, false, false, null))
			using (var hEL = OpenEventLog(null, eventLogName))
			{
				Assert.That(GetNumberOfEventLogRecords(hEL, out var numRec), ResultIs.Successful);
				var t = new System.Threading.Thread(ThreadProc);
				t.Start(((HEVENTLOG)hEL, hEvent));
				System.Threading.Thread.Sleep(100);
				Assert.That(ReportEvent(hEL, EVENTLOG_TYPE.EVENTLOG_INFORMATION_TYPE, 5, 5, SafePSID.Current, 2, 0, new[] { "Testing", "1, 2, 3" }, default), ResultIs.Successful);
				while (t.IsAlive)
				{
					System.Threading.Thread.Sleep(100);
				}
				Assert.That(GetNumberOfEventLogRecords(hEL, out var numRec2), ResultIs.Successful);
				Assert.That(numRec2, Is.GreaterThan(numRec));

				using (var mem = new SafePEVENTLOGRECORD())
				{
					Assert.That(ReadEventLog(hEL, EVENTLOG_READ.EVENTLOG_BACKWARDS_READ | EVENTLOG_READ.EVENTLOG_SEQUENTIAL_READ, 0, mem, mem.Size, out var read, out var minReq), ResultIs.Successful);
					Assert.That(mem.EventType, Is.EqualTo(EVENTLOG_TYPE.EVENTLOG_INFORMATION_TYPE));
					Assert.That(mem.Strings.Length, Is.EqualTo(2));
					Assert.That(mem.Strings[0], Is.EqualTo("Testing"));
				}
			}

			void ThreadProc(object obj)
			{
				var (hLog, hEvent) = ((HEVENTLOG hLog, SafeEventHandle hEvent))obj;
				Assert.That(NotifyChangeEventLog(hLog, hEvent), ResultIs.Successful);
				WaitForSingleObject(hEvent, 0);
			}
		}
	}
}