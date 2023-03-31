using NUnit.Framework;
using System;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading;
using Vanara.Extensions;
using Vanara.InteropServices;
using static Vanara.PInvoke.Pdh;

namespace Vanara.PInvoke.Tests;

[TestFixture]
public class PdhTests
{
	private const string counterPath = @"\Processor(0)\% Processor Time";
	private const string dsn = "TestSet";
	private const string logFile = @"C:\PerfLogs\Admin\TestSet\System Monitor Log.blg";

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
		Assert.That(PdhBindInputDataSource(out var hLog, new[] { logFile }), ResultIs.Successful);
		hLog.Dispose();
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

				Assert.That(PdhFormatFromRawValue(type, PDH_FMT.PDH_FMT_LONG, ft2, rawCounter1, rawCounter2, out fmtValue), ResultIs.Successful);
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
				Assert.That(PdhGetRawCounterValue(Counter, out var type, out var rawCounter), ResultIs.Successful);
				var values = new PDH_RAW_COUNTER[] { rawCounter };
				Assert.That(PdhComputeCounterStatistics(Counter, PDH_FMT.PDH_FMT_LONG, 0, (uint)values.Length, values, out var stats), ResultIs.Successful);
				stats.WriteValues();
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
	public void PdhExpandWildCardPathHTest()
	{
		Assert.That(CallMethodWithStrings((IntPtr p, ref uint sz) => PdhExpandWildCardPathH(default, @"\Process(*)\ID Process", p, ref sz, 0), out var strs), ResultIs.Successful);
		TestContext.WriteLine(string.Join("\n", strs));
	}

	[Test]
	public void PdhExpandWildCardPathTest()
	{
		Assert.That(CallMethodWithStrings((IntPtr p, ref uint sz) => PdhExpandWildCardPath(null, @"\Process(*)\ID Process", p, ref sz, 0), out var strs), ResultIs.Successful);
		TestContext.WriteLine(string.Join("\n", strs));
	}

	[Test]
	public void PdhGetCounterInfoTest()
	{
		Assert.That(PdhOpenQuery(null, default, out var Query), ResultIs.Successful);
		using (Query)
		{
			// Add the selected counter to the query.
			Assert.That(PdhAddCounter(Query, counterPath, default, out var Counter), ResultIs.Successful);
			using (Counter)
			{
				Assert.That(PdhSetCounterScaleFactor(Counter, 1), ResultIs.Successful);

				uint sz = 0;
				Assert.That(PdhGetCounterInfo(Counter, true, ref sz, default), ResultIs.FailureCode(Win32Error.PDH_MORE_DATA));
				using (var buffer = new SafeHGlobalHandle(sz))
				{
					Assert.That(PdhGetCounterInfo(Counter, true, ref sz, buffer), ResultIs.Successful);
					buffer.ToStructure<PDH_COUNTER_INFO>().WriteValues();
				}
			}
		}
	}

	[Test]
	public void PdhGetCounterTimeBaseTest()
	{
		Assert.That(PdhOpenQuery(null, default, out var Query), ResultIs.Successful);
		using (Query)
		{
			// Add the selected counter to the query.
			Assert.That(PdhAddCounter(Query, counterPath, default, out var Counter), ResultIs.Successful);
			using (Counter)
			{
				Assert.That(PdhGetCounterTimeBase(Counter, out var ft), ResultIs.Successful);
				TestContext.Write(ft.ToString("U"));
			}
		}
	}

	[Test]
	public void PdhGetDataSourceTimeRangeHTest()
	{
		Assert.That(PdhBindInputDataSource(out var hLog, new[] { logFile }), ResultIs.Successful);
		using (hLog)
		{
			uint sz = (uint)Marshal.SizeOf<PDH_TIME_INFO>();
			Assert.That(PdhGetDataSourceTimeRangeH(hLog, out var cnt, out var info, ref sz), ResultIs.Successful);
			Assert.That(cnt, Is.EqualTo(1));
			info.WriteValues();
		}
	}

	[Test]
	public void PdhGetDataSourceTimeRangeTest()
	{
		uint sz = (uint)Marshal.SizeOf<PDH_TIME_INFO>();
		Assert.That(PdhGetDataSourceTimeRange(logFile, out var cnt, out var info, ref sz), ResultIs.Successful);
		Assert.That(cnt, Is.EqualTo(1));
		info.WriteValues();
	}

	[Test]
	public void PdhGetDefaultPerfCounterObjectHTest()
	{
		var sz = 1024U;
		var sb = new StringBuilder((int)sz);
		Assert.That(PdhGetDefaultPerfObjectH(PDH_HLOG.NULL, null, sb, ref sz), ResultIs.Successful);
		TestContext.WriteLine($"DefObj: {sb}");

		sz = (uint)sb.Capacity;
		var obj = sb.ToString();
		Assert.That(PdhGetDefaultPerfCounterH(PDH_HLOG.NULL, null, obj, sb, ref sz), ResultIs.Successful);
		TestContext.WriteLine($"DefCntr: {sb}");
	}

	[Test]
	public void PdhGetDefaultPerfCounterObjectTest()
	{
		var sz = 1024U;
		var sb = new StringBuilder((int)sz);
		Assert.That(PdhGetDefaultPerfObject(null, null, sb, ref sz), ResultIs.Successful);
		TestContext.WriteLine($"DefObj: {sb}");

		sz = (uint)sb.Capacity;
		var obj = sb.ToString();
		Assert.That(PdhGetDefaultPerfCounter(null, null, obj, sb, ref sz), ResultIs.Successful);
		TestContext.WriteLine($"DefCntr: {sb}");
	}

	[Test]
	public void PdhGetDllVersionTest()
	{
		Assert.That(PdhGetDllVersion(out var ver), ResultIs.Successful);
		TestContext.Write(ver);
	}

	[Test]
	public void PdhGetFormattedRawCounterArrayTest()
	{
		Assert.That(PdhOpenQuery(null, default, out var Query), ResultIs.Successful);
		using (Query)
		{
			// Add the selected counter to the query.
			Assert.That(PdhAddCounter(Query, counterPath.Replace("(0)", "(*)"), default, out var Counter), ResultIs.Successful);
			using (Counter)
			{
				Assert.That(PdhCollectQueryData(Query), ResultIs.Successful);
				Assert.That(PdhCollectQueryData(Query), ResultIs.Successful);

				// Compute a displayable value for the counter.
				using (var mem = new SafeHGlobalHandle(4096))
				{
					var sz = (uint)mem.Size;
					Assert.That(PdhGetFormattedCounterArray(Counter, PDH_FMT.PDH_FMT_DOUBLE, ref sz, out var n, mem), ResultIs.Successful);
					mem.ToArray<PDH_FMT_COUNTERVALUE_ITEM>((int)n).WriteValues();

					TestContext.WriteLine("===============================");

					sz = (uint)mem.Size;
					Assert.That(PdhGetRawCounterArray(Counter, ref sz, out n, mem), ResultIs.Successful);
					mem.ToArray<PDH_RAW_COUNTER_ITEM>((int)n).WriteValues();
				}
			}
		}
	}

	[Test]
	public void PdhGetLogFileSizeTest()
	{
		var type = PDH_LOG_TYPE.PDH_LOG_TYPE_UNDEFINED;
		Assert.That(PdhOpenLog(logFile, PdhLogAccess.PDH_LOG_READ_ACCESS | PdhLogAccess.PDH_LOG_OPEN_EXISTING, ref type, phLog: out var hlog), ResultIs.Successful);
		using (hlog)
		{
			Assert.That(PdhGetLogFileSize(hlog, out var sz), ResultIs.Successful);
			TestContext.Write(sz);
		}
	}

	[Test]
	public void PdhLookupPerfNameByIndexTest()
	{
		var name = "Cache";
		Assert.That(PdhLookupPerfIndexByName(null, name, out var idx), ResultIs.Successful);

		var sz = 1024U;
		var sb = new StringBuilder((int)sz);
		Assert.That(PdhLookupPerfNameByIndex(null, idx, sb, ref sz), ResultIs.Successful);

		Assert.That(name, Is.EqualTo(sb.ToString()));
	}

	[Test]
	public void PdhMakeCounterPathTest()
	{
		var e = new PDH_COUNTER_PATH_ELEMENTS { szObjectName = "Processor", szInstanceName = "1", szCounterName = "% Processor Time" };
		var sz = 1024U;
		var sb = new StringBuilder((int)sz);
		Assert.That(PdhMakeCounterPath(e, sb, ref sz, 0, Kernel32.GetSystemDefaultLangID()), ResultIs.Successful);
		TestContext.Write(sb);
	}

	[Test]
	public void PdhParseCounterPathTest()
	{
		using (var mem = new SafeCoTaskMemHandle(1024))
		{
			uint sz = mem.Size;
			Assert.That(PdhParseCounterPath(counterPath, mem, ref sz), ResultIs.Successful);
			mem.ToStructure<PDH_COUNTER_PATH_ELEMENTS>().WriteValues();
		}
	}

	[Test]
	public void PdhParseInstanceNameTest()
	{
		var sz1 = 1024U;
		var sb1 = new StringBuilder((int)sz1);
		var sz2 = 1024U;
		var sb2 = new StringBuilder((int)sz2);
		Assert.That(PdhParseInstanceName("dog/cat#1", sb1, ref sz1, sb2, ref sz2, out var idx), ResultIs.Successful);
		Assert.That(sb2.ToString(), Is.EqualTo("dog"));
		Assert.That(idx, Is.EqualTo(1));
	}

	[Test]
	public void PdhReadRawLogRecordTest()
	{
		using (var hlog = PdhBindInputDataSource(logFile))
		using (var mem = new SafeCoTaskMemHandle(1024))
		{
			uint sz = (uint)Marshal.SizeOf<PDH_TIME_INFO>();
			Assert.That(PdhGetDataSourceTimeRangeH(hlog, out var cnt, out var info, ref sz), ResultIs.Successful);
			TestContext.WriteLine($"Start:{info.StartTime.ToString("U")}; End:{info.EndTime.ToString("U")}; Cnt:{info.SampleCount}");

			sz = mem.Size;
			// TODO: Can't get this to return anything but PDH_ENTRY_NOT_IN_LOG_FILE
			Assert.That(PdhReadRawLogRecord(hlog, info.StartTime, mem, ref sz), ResultIs.FailureCode(Win32Error.PDH_ENTRY_NOT_IN_LOG_FILE));
			//var rec = mem.ToStructure<PDH_RAW_LOG_RECORD>();
			//rec.WriteValues();
			//TestContext.Write(mem.ToByteArray((int)rec.dwItems, 12).ToHexString((int)rec.dwItems));
		}
	}

	[Test]
	public void PdhSelectDataSourceTest()
	{
		var sz = 1024U;
		var sb = new StringBuilder((int)sz);
		Assert.That(PdhSelectDataSource(default, PdhSelectDataSourceFlags.Default, sb, ref sz), ResultIs.Successful);
	}

	[Test]
	public void PdhSetQueryTimeRangeTest()
	{
		using (var hlog = PdhBindInputDataSource(logFile))
		{
			uint sz = (uint)Marshal.SizeOf<PDH_TIME_INFO>();
			Assert.That(PdhGetDataSourceTimeRangeH(hlog, out var cnt, out var info, ref sz), ResultIs.Successful);

			Assert.That(PdhOpenQueryH(hlog, default, out var Query), ResultIs.Successful);
			using (Query)
				Assert.That(PdhSetQueryTimeRange(Query, info), ResultIs.Successful);
		}
	}

	[Test]
	public void PdhUpdateLogTest()
	{
		// Open a query object.
		Assert.That(PdhOpenQuery(null, default, out var hQuery), ResultIs.Successful);
		using (var tmp = new TempFile(null))
		using (hQuery)
		{
			Assert.That(PdhIsRealTimeQuery(hQuery), Is.True);

			// Add one counter that will provide the data.
			Assert.That(PdhAddEnglishCounter(hQuery, counterPath, default, out var hCounter), ResultIs.Successful);

			// Open the log file for write access and write an entry.
			var dwLogType = PDH_LOG_TYPE.PDH_LOG_TYPE_CSV;
			Assert.That(PdhOpenLog(tmp.FullName, PdhLogAccess.PDH_LOG_WRITE_ACCESS | PdhLogAccess.PDH_LOG_CREATE_ALWAYS, ref dwLogType, hQuery, 0, null, out var hLog), ResultIs.Successful);
			using (hLog)
				Assert.That(PdhUpdateLog(hLog, null), ResultIs.Successful);
		}
	}

	[Test]
	public void PdhValidatePathExWTest()
	{
		Assert.That(PdhValidatePathExW(PDH_HLOG.NULL, counterPath), ResultIs.Successful);
	}

	[Test]
	public void PdhValidatePathTest()
	{
		Assert.That(PdhValidatePath(counterPath), ResultIs.Successful);
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