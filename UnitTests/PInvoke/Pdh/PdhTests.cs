using NUnit.Framework;
using System;
using System.Linq;
using System.Threading;
using Vanara.Extensions;
using Vanara.InteropServices;
using static Vanara.PInvoke.Pdh;

namespace Vanara.PInvoke.Tests
{
	[TestFixture]
	public class PdhTests
	{
		private const string counterPath = "\\Processor(0)\\% Processor Time";
		private const string dsn = "Test";
		private const string logFile = @"C:\Temp\TestLogFile.etl";

		[Test]
		public void BrowsePerfCountersTest()
		{
			Assert.That(PdhOpenQuery(null, default, out var Query), ResultIs.Successful);
			using (Query)
			using (var CounterPathBuffer = new SafeCoTaskMemString(counterPath + '\0', PDH_MAX_COUNTER_PATH))
			{
				// Initialize the browser dialog window settings.
				var BrowseDlgData = new PDH_BROWSE_DLG_CONFIG
				{
					Flags = BrowseFlag.bSingleCounterPerAdd | BrowseFlag.bSingleCounterPerDialog | BrowseFlag.bWildCardInstances | BrowseFlag.bHideDetailBox | BrowseFlag.bInitializePath,
					szReturnPathBuffer = CounterPathBuffer,
					cchReturnPathLength = PDH_MAX_COUNTER_PATH,
					dwDefaultDetailLevel = PERF_DETAIL.PERF_DETAIL_WIZARD,
					szDialogBoxCaption = "Select a counter to monitor. Press OK to complete Test."
				};

				// Display the counter browser window. The dialog is configured to return a single selection from the counter list.
				Assert.That(PdhBrowseCounters(ref BrowseDlgData), ResultIs.Successful);
				TestContext.Write("Counter(s) selected: {0}\n", string.Join(", ", BrowseDlgData.CounterPaths));

				// Add the selected counter to the query.
				Assert.That(PdhAddCounter(Query, CounterPathBuffer, default, out var Counter), ResultIs.Successful);
				using (Counter)
				{
					// Most counters require two sample values to display a formatted value. PDH stores the current sample value and the
					// previously collected sample value. This call retrieves the first value that will be used by
					// PdhGetFormattedCounterValue in the first iteration of the loop Note that this value is lost if the counter does not
					// require two values to compute a displayable value.
					Assert.That(PdhCollectQueryData(Query), ResultIs.Successful);

					// Print counter for 2 seconds.
					for (var i = 0; i < 20; i++)
					{
						System.Threading.Thread.Sleep(100);
						var SampleTime = DateTime.Now;
						Assert.That(PdhCollectQueryData(Query), ResultIs.Successful);
						TestContext.Write(SampleTime);

						// Compute a displayable value for the counter.
						Assert.That(PdhGetFormattedCounterValue(Counter, PDH_FMT.PDH_FMT_DOUBLE, out var CounterType, out var DisplayValue), ResultIs.Successful);
						TestContext.WriteLine($",\"{DisplayValue.doubleValue}\"");
					}
				}
			}
		}

		[Test]
		public void PdhBindInputDataSourceTest()
		{
			throw new NotImplementedException();
			//Assert.That(PdhBindInputDataSource(), ResultIs.Successful);
		}

		[Test]
		public void PdhCollectQueryDataExTest()
		{
			Assert.That(PdhOpenQuery(null, default, out var Query), ResultIs.Successful);
			using (Query)
			{
				// Add the selected counter to the query.
				Assert.That(PdhAddCounter(Query, counterPath, default, out var Counter), ResultIs.Successful);
				using (Counter)
				{
					using (var evt = new AutoResetEvent(false))
					{
						Assert.That(PdhCollectQueryDataEx(Query, 0, evt), ResultIs.Successful);
						evt.WaitOne(100);
						Thread.Sleep(1000);
						Assert.That(PdhCollectQueryDataEx(Query, 0, evt), ResultIs.Successful);
						evt.WaitOne(100);
					}

					// Compute a displayable value for the counter.
					Assert.That(PdhGetFormattedCounterValue(Counter, PDH_FMT.PDH_FMT_DOUBLE, out var CounterType, out var DisplayValue), ResultIs.Successful);
					TestContext.WriteLine($",\"{DisplayValue.doubleValue}\"");
				}
			}
		}

		[Test]
		public void PdhCollectQueryDataTest()
		{
			Assert.That(PdhOpenQuery(null, default, out var Query), ResultIs.Successful);
			using (Query)
			{
				// Add the selected counter to the query.
				Assert.That(PdhAddCounter(Query, counterPath, default, out var Counter), ResultIs.Successful);
				using (Counter)
				{
					Assert.That(PdhCollectQueryData(Query), ResultIs.Successful);
					Assert.That(PdhCollectQueryData(Query), ResultIs.Successful);

					// Compute a displayable value for the counter.
					Assert.That(PdhGetFormattedCounterValue(Counter, PDH_FMT.PDH_FMT_DOUBLE, out var CounterType, out var DisplayValue), ResultIs.Successful);
					TestContext.WriteLine($",\"{DisplayValue.doubleValue}\"");
				}
			}
		}

		[Test]
		public void PdhCollectQueryDataWithTimeTest()
		{
			Assert.That(PdhOpenQuery(null, default, out var Query), ResultIs.Successful);
			using (Query)
			{
				// Add the selected counter to the query.
				Assert.That(PdhAddCounter(Query, counterPath, default, out var Counter), ResultIs.Successful);
				using (Counter)
				{
					Assert.That(PdhCollectQueryDataWithTime(Query, out var ft1), ResultIs.Successful);
					Assert.That(PdhCollectQueryDataWithTime(Query, out var ft2), ResultIs.Successful);

					Assert.That(PdhGetRawCounterValue(Counter, out var type, out var rawCounter1), ResultIs.Successful);
					TestContext.WriteLine($"0x{type}, {rawCounter1.CStatus}, 0x{rawCounter1.FirstValue:X}");
					Assert.That(PdhGetRawCounterValue(Counter, out type, out var rawCounter2), ResultIs.Successful);

					Assert.That(PdhCalculateCounterFromRawValue(Counter, PDH_FMT.PDH_FMT_LONG, rawCounter1, rawCounter2, out var fmtValue), ResultIs.Successful);
					TestContext.WriteLine($"{fmtValue.longValue}");

					//Assert.That(PdhFormatFromRawValue(CounterType.PERF_100NSEC_TIMER)
				}
			}
		}

		[Test]
		public void PdhComputeCounterStatisticsTest()
		{
			Assert.That(PdhOpenQuery(null, default, out var Query), ResultIs.Successful);
			using (Query)
			{
				// Add the selected counter to the query.
				Assert.That(PdhAddCounter(Query, counterPath, default, out var Counter), ResultIs.Successful);
				using (Counter)
				{
					var first = 0U;
					var values = new PDH_RAW_COUNTER[] { };
					Assert.That(PdhComputeCounterStatistics(Counter, PDH_FMT.PDH_FMT_LONG, first, (uint)values.Length, values, out var stats), ResultIs.Failure);
				}
			}
		}

		[Test]
		public void PdhConnectMachineTest()
		{
			Assert.That(PdhConnectMachine(), ResultIs.Successful);
		}

		[Test]
		public void PdhEnumLogSetNamesTest()
		{
			Assert.That(CallMethodWithStrings((IntPtr p, ref uint sz) => PdhEnumLogSetNames(dsn, p, ref sz), out var strs), ResultIs.Successful);
			TestContext.WriteLine(string.Join("\n", strs));
		}

		[Test]
		public void PdhEnumMachinesHTest()
		{
			Assert.That(CallMethodWithStrings((IntPtr p, ref uint sz) => PdhEnumMachinesH(PDH_HLOG.NULL, p, ref sz), out var strs), ResultIs.Successful);
			TestContext.WriteLine(string.Join("\n", strs));
		}

		[Test]
		public void PdhEnumMachinesTest()
		{
			Assert.That(CallMethodWithStrings((IntPtr p, ref uint sz) => PdhEnumMachines(null, p, ref sz), out var strs), ResultIs.Successful);
			TestContext.WriteLine(string.Join("\n", strs));
		}

		[Test]
		public void PdhEnumObjectItemsHTest()
		{
			// Determine the required buffer size for the data.
			uint dwCounterListSize = 0U, dwInstanceListSize = 0U;
			Assert.That(PdhEnumObjectItemsH(default, null, "Process", default, ref dwCounterListSize, default, ref dwInstanceListSize, PERF_DETAIL.PERF_DETAIL_WIZARD), ResultIs.FailureCode(Win32Error.PDH_MORE_DATA));

			// Allocate the buffers and try the call again.
			using (var pwsCounterListBuffer = new SafeCoTaskMemHandle(dwCounterListSize * StringHelper.GetCharSize()))
			using (var pwsInstanceListBuffer = new SafeCoTaskMemHandle(dwInstanceListSize * StringHelper.GetCharSize()))
			{
				Assert.That(PdhEnumObjectItemsH(default, null, "Process", pwsCounterListBuffer, ref dwCounterListSize, pwsInstanceListBuffer, ref dwInstanceListSize, PERF_DETAIL.PERF_DETAIL_WIZARD), ResultIs.Successful);
				TestContext.WriteLine("Counters that the Process objects defines:\n");
				TestContext.WriteLine(string.Join("\n", pwsCounterListBuffer.ToStringEnum()));
				TestContext.WriteLine("\nInstances of the Process object:\n");
				TestContext.WriteLine(string.Join("\n", pwsInstanceListBuffer.ToStringEnum()));
			}
		}

		[Test]
		public void PdhEnumObjectItemsTest()
		{
			// Determine the required buffer size for the data.
			uint dwCounterListSize = 0U, dwInstanceListSize = 0U;
			Assert.That(PdhEnumObjectItems(null, null, "Process", default, ref dwCounterListSize, default, ref dwInstanceListSize, PERF_DETAIL.PERF_DETAIL_WIZARD), ResultIs.FailureCode(Win32Error.PDH_MORE_DATA));

			// Allocate the buffers and try the call again.
			using (var pwsCounterListBuffer = new SafeCoTaskMemHandle(dwCounterListSize * StringHelper.GetCharSize()))
			using (var pwsInstanceListBuffer = new SafeCoTaskMemHandle(dwInstanceListSize * StringHelper.GetCharSize()))
			{
				Assert.That(PdhEnumObjectItems(null, null, "Process", pwsCounterListBuffer, ref dwCounterListSize, pwsInstanceListBuffer, ref dwInstanceListSize, PERF_DETAIL.PERF_DETAIL_WIZARD), ResultIs.Successful);
				TestContext.WriteLine("Counters that the Process objects defines:\n");
				TestContext.WriteLine(string.Join("\n", pwsCounterListBuffer.ToStringEnum()));
				TestContext.WriteLine("\nInstances of the Process object:\n");
				TestContext.WriteLine(string.Join("\n", pwsInstanceListBuffer.ToStringEnum()));
			}
		}

		[Test]
		public void PdhEnumObjectsHTest()
		{
			uint sz = 0U;
			Assert.That(PdhEnumObjectsH(default, null, default, ref sz, PERF_DETAIL.PERF_DETAIL_WIZARD, true), ResultIs.FailureCode(Win32Error.PDH_MORE_DATA));
			using (var buffer = new SafeCoTaskMemHandle(sz * StringHelper.GetCharSize()))
			{
				Assert.That(PdhEnumObjectsH(default, null, buffer, ref sz, PERF_DETAIL.PERF_DETAIL_WIZARD, false), ResultIs.Successful);
				TestContext.WriteLine(string.Join("\n", buffer.ToStringEnum()));
			}
		}

		[Test]
		public void PdhEnumObjectsTest()
		{
			uint sz = 0U;
			Assert.That(PdhEnumObjects(null, null, default, ref sz, PERF_DETAIL.PERF_DETAIL_WIZARD, true), ResultIs.FailureCode(Win32Error.PDH_MORE_DATA));
			using (var buffer = new SafeCoTaskMemHandle(sz * StringHelper.GetCharSize()))
			{
				Assert.That(PdhEnumObjects(null, null, buffer, ref sz, PERF_DETAIL.PERF_DETAIL_WIZARD, false), ResultIs.Successful);
				TestContext.WriteLine(string.Join("\n", buffer.ToStringEnum()));
			}
		}

		[Test]
		public void PdhExpandCounterPathTest()
		{
			Assert.That(CallMethodWithStrings((IntPtr p, ref uint sz) => PdhExpandCounterPath(@"\Process(*)\ID Process", p, ref sz), out var strs), ResultIs.Successful);
			TestContext.WriteLine(string.Join("\n", strs));
		}

		[Test]
		public void PdhExpandWildCardPathTest()
		{
			Assert.That(CallMethodWithStrings((IntPtr p, ref uint sz) => PdhExpandWildCardPath(null, @"\Process(*)\ID Process", p, ref sz, 0), out var strs), ResultIs.Successful);
			TestContext.WriteLine(string.Join("\n", strs));
		}

		[Test]
		public void PdhExpandWildCardPathHTest()
		{
			Assert.That(CallMethodWithStrings((IntPtr p, ref uint sz) => PdhExpandWildCardPathH(default, @"\Process(*)\ID Process", p, ref sz, 0), out var strs), ResultIs.Successful);
			TestContext.WriteLine(string.Join("\n", strs));
		}

		[Test]
		public void PdhUpdateLogTest()
		{
			// Open a query object.
			Assert.That(PdhOpenQuery(null, default, out var hQuery), ResultIs.Successful);
			using (var tmp = new TempFile(null))
			using (hQuery)
			{
				// Add one counter that will provide the data.
				Assert.That(PdhAddEnglishCounter(hQuery, counterPath, default, out var hCounter), ResultIs.Successful);

				// Open the log file for write access and write an entry.
				var dwLogType = PDH_LOG_TYPE.PDH_LOG_TYPE_CSV;
				Assert.That(PdhOpenLog(tmp.FullName, PdhLogAccess.PDH_LOG_WRITE_ACCESS | PdhLogAccess.PDH_LOG_CREATE_ALWAYS, ref dwLogType, hQuery, 0, null, out var hLog), ResultIs.Successful);
				using (hLog)
					Assert.That(PdhUpdateLog(hLog, null), ResultIs.Successful);
			}
		}

		private static Win32Error CallMethodWithStrings(FunctionHelper.PtrFunc<uint> method, out string[] result)
		{
			var sz = 0U;
			var err = method(IntPtr.Zero, ref sz);
			if (err == Win32Error.PDH_MORE_DATA)
			{
				using (var mem = new SafeCoTaskMemHandle(sz * StringHelper.GetCharSize()))
				{
					err = method(mem, ref sz);
					if (err.Succeeded)
					{
						result = mem.ToStringEnum().ToArray();
						return err;
					}
				}
			}
			result = null;
			return err;
		}
	}
}