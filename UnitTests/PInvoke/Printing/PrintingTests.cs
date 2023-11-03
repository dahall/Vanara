using NUnit.Framework;
using NUnit.Framework.Constraints;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using static Vanara.PInvoke.WinSpool;

namespace Vanara.PInvoke.Tests;

[TestFixture]
public class PrintingTests
{
	private string connPtrName = "";
	//private (string un, string pw, string sv) creds = ("", "", "");
	private const string defKey = "PrinterDriverData";
	private static readonly string defaultPrinterName = new System.Drawing.Printing.PrinterSettings().PrinterName;
#pragma warning disable CS8618 // Non-nullable field must contain a non-null value when exiting constructor. Consider declaring as nullable.
	private SafeHPRINTER hprnt;
#pragma warning restore CS8618 // Non-nullable field must contain a non-null value when exiting constructor. Consider declaring as nullable.

	[OneTimeSetUp]
	public void _Setup()
	{
		Assert.That(OpenPrinter(defaultPrinterName, out hprnt, new() { DesiredAccess = (uint)AccessRights.PRINTER_ACCESS_USE, pDatatype = "RAW", pDevMode = new DEVMODE() { dmDeviceName = defaultPrinterName } }), ResultIs.Successful);
		var auth = (object[])TestCaseSources.GetAuthCasesFromFile(true, true)[0];
		connPtrName = string.Concat(auth[5], '\\', auth[9]);
		if (!connPtrName.StartsWith('\\'))
			connPtrName = @"\\" + connPtrName;
		//creds = ((string)auth[6], (string)auth[7], (string)auth[5]);
	}

	[OneTimeTearDown]
	public void _TearDown() => hprnt?.Dispose();

	[Test]
	public void AddMonitorTest()
	{
		const string name = "mytestmon";
		var mon = EnumMonitors<MONITOR_INFO_2>().First();
		mon.pName = name;
		Assert.That(AddMonitor(null, mon), ResultIs.Successful);
		Assert.That(DeleteMonitor(null, mon.pEnvironment, mon.pName), ResultIs.Successful);
	}

	[Test]
	public void AddPortTest()
	{
		var mon = EnumMonitors<MONITOR_INFO_1>().First().pName;
		Assert.That(AddPort(null, HWND.NULL, mon), ResultIs.Successful);
	}

	[Test]
	public void AddPrinterConnection2Test()
	{
		var drv = GetPrinter<PRINTER_INFO_2>(hprnt).pDriverName;
		Assert.That(AddPrinterConnection2(default, connPtrName, PRINTER_CONNECTION_FLAGS.PRINTER_CONNECTION_MISMATCH, drv), ResultIs.Successful);
		Assert.That(DeletePrinterConnection(connPtrName), ResultIs.Successful);
	}

	[Test]
	public void AddPrinterConnectionTest()
	{
		Assert.That(AddPrinterConnection(connPtrName), ResultIs.Successful);
		Assert.That(DeletePrinterConnection(connPtrName), ResultIs.Successful);
	}

	[Test]
	public void AddPrinterDriverExTest()
	{
		const string name = "mydriver";
		var di2 = EnumPrinterDrivers<DRIVER_INFO_2>().First();
		di2.pName = name;
		using var priv = new ElevPriv("SeLoadDriverPrivilege");
		Assert.That(AddPrinterDriverEx(null, di2), ResultIs.Successful);
		Assert.That(DeletePrinterDriverEx(null, null, name, DPD.DPD_DELETE_UNUSED_FILES, 0), ResultIs.Successful);
	}

	[Test]
	public void AddPrinterTest()
	{
		const string key = "TestOnly";
		const string name = "TestOnlyPrinter";
		var pi = GetPrinter<PRINTER_INFO_2>(hprnt);
		var pi2 = new PRINTER_INFO_2
		{
			pPrinterName = name,
			pPortName = "LPT1:",
			pDriverName = pi.pDriverName,
			pPrintProcessor = pi.pPrintProcessor,
			Attributes = PRINTER_ATTRIBUTE.PRINTER_ATTRIBUTE_LOCAL
		};
		SafeHPRINTER p2 = new(default, false);
		Assert.That(p2 = AddPrinter(null, 2, pi2), ResultIs.ValidHandle);
		try
		{
			GetSet("Test", 123, 123U);
			GetSet("Test", 123L, 123UL);
			GetSet("Test", "123");
			GetSet("Test", new byte[] { 1, 2, 3 });
			GetSet("Test", new[] { "1", "2", "3" });
			GetSet("Test", 123, 123U, REG_VALUE_TYPE.REG_DWORD_BIG_ENDIAN);
			// Test serializable
			var sz = new System.Drawing.Size(4, 4);
			GetSet("Test", sz, new byte[] { 4, 0, 0, 0, 4, 0, 0, 0 });

			Assert.That(() => SetPrinterData(p2, "Test8", 1, REG_VALUE_TYPE.REG_LINK), Throws.Exception);
			Assert.That(() => SetPrinterData(p2, "Test8", 1, REG_VALUE_TYPE.REG_RESOURCE_LIST), Throws.Exception);
			Assert.That(ResetPrinter(p2, new PRINTER_DEFAULTS { pDatatype = pi.pDatatype }), ResultIs.Successful);
		}
		finally
		{
			Assert.That(DeletePrinter(p2), ResultIs.Successful);
		}

		void GetSet(string vn, object v, object? r = null, REG_VALUE_TYPE t = REG_VALUE_TYPE.REG_NONE)
		{
			r ??= v;
			Assert.That(SetPrinterData(p2, vn, v, t), ResultIs.Successful);
			Assert.That(GetPrinterData(p2, vn), v.GetType().IsArray ? (IResolveConstraint)Is.EquivalentTo((IEnumerable)r) : Is.EqualTo(r));
			Assert.That(DeletePrinterData(p2, vn), ResultIs.Successful);
			Assert.That(SetPrinterDataEx(p2, key, vn, v, t), ResultIs.Successful);
			Assert.That(GetPrinterDataEx(p2, key, vn), v.GetType().IsArray ? (IResolveConstraint)Is.EquivalentTo((IEnumerable)r) : Is.EqualTo(r));
			Assert.That(DeletePrinterDataEx(p2, key, vn), ResultIs.Successful);
			Assert.That(DeletePrinterKey(p2, key), ResultIs.Successful);
		}
	}

	[Test]
	public void AddPrintProcessorTest()
	{
		using var priv = new ElevPriv("SeLoadDriverPrivilege");
		Assert.That(AddPrintProcessor(null, null, "dummy.dll", "Dummy"), ResultIs.Successful);
		Assert.That(DeletePrintProcessor(null, null, "Dummy"), ResultIs.Successful);
	}

	[Test]
	public void AddPrintProvidorTest()
	{
		var pi1 = new PROVIDOR_INFO_1 { pName = "Dummy", pDLLName = "dummy.dll" };
		Assert.That(AddPrintProvidor(null, pi1), ResultIs.Successful);
		Assert.That(DeletePrintProvidor(null, null, pi1.pName), ResultIs.Successful);
	}

	[Test]
	public void AdvancedDocumentPropertiesTest()
	{
		var devmodeOut = DEVMODE.Default;
		Assert.That(AdvancedDocumentProperties(HWND.NULL, hprnt, defaultPrinterName, ref devmodeOut, DEVMODE.Default), ResultIs.Successful);
		Assert.That(AdvancedDocumentProperties(HWND.NULL, hprnt, defaultPrinterName), ResultIs.Successful);
	}

	[Test]
	public void ConnectToPrinterDlgTest()
	{
		SafeHPRINTER p;
		Assert.That(p = ConnectToPrinterDlg(HWND.NULL), ResultIs.ValidHandle);
		p.Dispose();
	}

	[Test]
	public void CorePrinterDriverInstalledTest()
	{
		//Assert.That(CorePrinterDriverInstalled(null, null, ), ResultIs.Successful);
	}

	[Test]
	public void EnumFormsTest()
	{
		FORM_INFO_1[] res1;
		Assert.That(res1 = EnumForms<FORM_INFO_1>(hprnt).ToArray(), Is.Not.Empty);
		TestContext.WriteLine(string.Join(",", res1.Select(v => v.pName)));
		FORM_INFO_2[] res2;
		Assert.That(res2 = EnumForms<FORM_INFO_2>(hprnt).ToArray(), Is.Not.Empty);
		TestContext.WriteLine(string.Join(",", res2.Select(v => v.Flags)));
	}

	[Test]
	public void EnumJobsTest()
	{
		Assert.That(EnumJobs<JOB_INFO_1>(hprnt), Is.Empty);
		Assert.That(EnumJobs<JOB_INFO_2>(hprnt), Is.Empty);
		Assert.That(EnumJobs<JOB_INFO_3>(hprnt), Is.Empty);
		Assert.That(EnumJobs<JOB_INFO_4>(hprnt), Is.Empty);
	}

	[Test]
	public void EnumMonitorsTest()
	{
		MONITOR_INFO_1[] mon1;
		Assert.That(mon1 = EnumMonitors<MONITOR_INFO_1>().ToArray(), Is.Not.Empty);
		TestContext.WriteLine(string.Join(",", mon1.Select(v => v.pName)));
		MONITOR_INFO_2[] mon2;
		Assert.That(mon2 = EnumMonitors<MONITOR_INFO_2>().ToArray(), Is.Not.Empty);
		TestContext.WriteLine(string.Join(",", mon2.Select(v => v.pEnvironment)));
	}

	[Test]
	public void EnumPortsTest()
	{
		PORT_INFO_1[] port1;
		Assert.That(port1 = EnumPorts<PORT_INFO_1>().ToArray(), Is.Not.Empty);
		TestContext.WriteLine(string.Join(",", port1.Select(v => v.pName)));
		PORT_INFO_2[] port2;
		Assert.That(port2 = EnumPorts<PORT_INFO_2>().ToArray(), Is.Not.Empty);
		TestContext.WriteLine(string.Join(",", port2.Select(v => v.fPortType)));
	}

	[Test]
	public void EnumPrinterDataExTest()
	{
		var res1 = EnumPrinterDataEx(hprnt, defKey);
		Assert.That(res1, Is.Not.Empty);
		TestContext.WriteLine(string.Join(",", res1.Select(v => $"{v.valueName}={v.value} ({v.valueType})")));
	}

	[Test]
	public void EnumPrinterDataTest()
	{
		var res1 = EnumPrinterData(hprnt);
		Assert.That(res1, Is.Not.Empty);
		TestContext.WriteLine(string.Join(",", res1.Select(v => $"{v.valueName}={v.value} ({v.valueType})")));
	}

	[Test]
	public void EnumPrinterDriversTest()
	{
		DRIVER_INFO_1[] res1;
		Assert.That(res1 = EnumPrinterDrivers<DRIVER_INFO_1>().ToArray(), Is.Not.Empty);
		TestContext.WriteLine(string.Join(",", res1.Select(v => v.pName)));
		DRIVER_INFO_2[] res2;
		Assert.That(res2 = EnumPrinterDrivers<DRIVER_INFO_2>().ToArray(), Is.Not.Empty);
		TestContext.WriteLine(string.Join(",", res2.Select(v => v.pEnvironment)));
		DRIVER_INFO_3[] res3;
		Assert.That(res3 = EnumPrinterDrivers<DRIVER_INFO_3>().ToArray(), Is.Not.Empty);
		TestContext.WriteLine(string.Join(",", res3.Select(v => v.pDriverPath)));
		DRIVER_INFO_4[] res4;
		Assert.That(res4 = EnumPrinterDrivers<DRIVER_INFO_4>().ToArray(), Is.Not.Empty);
		TestContext.WriteLine(string.Join(",", res4.Select(v => v.pDataFile)));
		DRIVER_INFO_5[] res5;
		Assert.That(res5 = EnumPrinterDrivers<DRIVER_INFO_5>().ToArray(), Is.Not.Empty);
		TestContext.WriteLine(string.Join(",", res5.Select(v => v.pConfigFile)));
		DRIVER_INFO_6[] res6;
		Assert.That(res6 = EnumPrinterDrivers<DRIVER_INFO_6>().ToArray(), Is.Not.Empty);
		TestContext.WriteLine(string.Join(",", res6.Select(v => v.pHelpFile)));
		DRIVER_INFO_8[] res8;
		Assert.That(res8 = EnumPrinterDrivers<DRIVER_INFO_8>().ToArray(), Is.Not.Empty);
		TestContext.WriteLine(string.Join(",", res8.Select(v => v.pszMfgName)));
	}

	[Test]
	public void EnumPrinterKeyTest()
	{
		string[] res1;
		Assert.That(res1 = EnumPrinterKey(hprnt, "").ToArray(), Is.Not.Empty);
		TestContext.WriteLine(string.Join(",", res1));
	}

	[Test]
	public void EnumPrintersTest()
	{
		PRINTER_INFO_2[] res2;
		Assert.That(res2 = EnumPrinters<PRINTER_INFO_2>().ToArray(), Is.Not.Empty);
		res2.WriteValues();
		PRINTER_INFO_1[] res1;
		Assert.That(res1 = EnumPrinters<PRINTER_INFO_1>().ToArray(), Is.Not.Empty);
		//PRINTER_INFO_3[] res3;
		//Assert.That(res3 = EnumPrinters<PRINTER_INFO_3>().ToArray(), Is.Not.Empty);
		PRINTER_INFO_4[] res4;
		Assert.That(res4 = EnumPrinters<PRINTER_INFO_4>().ToArray(), Is.Not.Empty);
		PRINTER_INFO_5[] res5;
		Assert.That(res5 = EnumPrinters<PRINTER_INFO_5>().ToArray(), Is.Not.Empty);
		//PRINTER_INFO_6[] res6;
		//Assert.That(res6 = EnumPrinters<PRINTER_INFO_6>().ToArray(), Is.Not.Empty);
		//PRINTER_INFO_7[] res7;
		//Assert.That(res7 = EnumPrinters<PRINTER_INFO_7>().ToArray(), Is.Not.Empty);
		//PRINTER_INFO_8[] res8;
		//Assert.That(res8 = EnumPrinters<PRINTER_INFO_8>().ToArray(), Is.Not.Empty);
		//PRINTER_INFO_9[] res9;
		//Assert.That(res9 = EnumPrinters<PRINTER_INFO_9>().ToArray(), Is.Not.Empty);
	}

	[Test]
	public void EnumPrintProcessorDatatypesTest()
	{
		var proc = EnumPrintProcessors<PRINTPROCESSOR_INFO_1>().First().pName;
		DATATYPES_INFO_1[] res1;
		Assert.That(res1 = EnumPrintProcessorDatatypes<DATATYPES_INFO_1>(proc).ToArray(), Is.Not.Empty);
		TestContext.WriteLine(string.Join(",", res1.Select(v => v.pName)));
	}

	[Test]
	public void EnumPrintProcessorsTest()
	{
		PRINTPROCESSOR_INFO_1[] res1;
		Assert.That(res1 = EnumPrintProcessors<PRINTPROCESSOR_INFO_1>().ToArray(), Is.Not.Empty);
		TestContext.WriteLine(string.Join(",", res1.Select(v => v.pName)));
	}

	[Test]
	public void FormTest()
	{
		const string name = "TestOnlyForm";
		var form1 = EnumForms<FORM_INFO_1>(hprnt).First();
		form1.pName = name;
		form1.Flags = FormFlags.FORM_USER;
		Assert.That(AddForm(hprnt, form1), ResultIs.Successful);
		try
		{
			FORM_INFO_2 fi2 = default;
			Assert.That(() => fi2 = GetForm<FORM_INFO_2>(hprnt, name), Throws.Nothing);
			Assert.That(fi2.Flags, Is.EqualTo(FormFlags.FORM_USER));
			TestHelper.WriteValues(fi2);

			form1.Size = new SIZE(form1.Size.cx / 2, form1.Size.cy / 2);
			Assert.That(SetForm(hprnt, name, form1), ResultIs.Successful);
		}
		finally
		{
			Assert.That(DeleteForm(hprnt, name), ResultIs.Successful);
		}
	}

	[Test]
	public void GetCorePrinterDriversTest()
	{
		Assert.That(() => TestHelper.WriteValues(EnumCorePrinterDrivers(null, null)), Throws.Nothing);
	}

	[Test]
	public void GetDefaultPrinterTest()
	{
		var sz = 260;
		var sb = new StringBuilder(sz);
		Assert.That(GetDefaultPrinter(sb, ref sz), ResultIs.Successful);
		TestContext.WriteLine(sb);
	}

	[Test]
	public void GetPrinterDriverTest()
	{
		Assert.That(() => TestHelper.WriteValues(GetPrinterDriver<DRIVER_INFO_8>(hprnt)), Throws.Nothing);
	}

	[Test]
	public void GetPrinterDriver2Test()
	{
		Assert.That(() => TestHelper.WriteValues(GetPrinterDriver2<DRIVER_INFO_8>(hprnt)), Throws.Nothing);
	}

	[Test]
	public void GetPrinterDriverDirectoryTest()
	{
		Assert.That(GetPrinterDriverDirectory(null, null, 1, null, 0, out var req), ResultIs.Failure);
		var sb = new StringBuilder(req);
		Assert.That(GetPrinterDriverDirectory(null, null, 1, sb, sb.Capacity, out _), ResultIs.Successful);
		TestContext.Write(sb);
	}

	[Test]
	public void GetPrinterDriverPackagePathTest()
	{
		var pkg = EnumCorePrinterDrivers().First().szPackageID;
		Assert.That(GetPrinterDriverPackagePath(null, null, null, pkg, null, 0, out var req), ResultIs.Successful);
		var sb = new StringBuilder(req);
		Assert.That(GetPrinterDriverPackagePath(null, null, null, pkg, sb, sb.Capacity, out _), ResultIs.Successful);
		TestContext.Write(sb);
	}

	[Test]
	public void GetPrintExecutionDataTest()
	{
		Assert.That(GetPrintExecutionData(out var data), ResultIs.Successful);
		TestHelper.WriteValues(data);
	}

	[Test]
	public void GetPrintProcessorDirectoryTest()
	{
		Assert.That(GetPrintProcessorDirectory(null, null, 1, null, 0, out var req), ResultIs.Failure);
		var sb = new StringBuilder(req);
		Assert.That(GetPrintProcessorDirectory(null, null, 1, sb, sb.Capacity, out _), ResultIs.Successful);
		TestContext.Write(sb);
	}

	[Test]
	public void JobTest()
	{
		Assert.That(AddJob(hprnt, out var path, out var id), ResultIs.Successful);
		try
		{
			System.IO.File.WriteAllText(path!, "Test page.");

			JOB_INFO_2 ji2 = default;
			Assert.That(() => ji2 = GetJob<JOB_INFO_2>(hprnt, id), Throws.Nothing);
			Assert.That(ji2.JobId, Is.EqualTo(id));
			Assert.NotNull(ji2.pDatatype);
			TestHelper.WriteValues(ji2);

			var jobInfo = new JOB_INFO_1 { JobId = id, Priority = JOB_PRIORITY.MAX_PRIORITY, Status = ji2.Status, pDatatype = ji2.pDatatype! };
			Assert.That(SetJob(hprnt, id, jobInfo), ResultIs.Successful);

			Assert.That(ScheduleJob(hprnt, id), ResultIs.Successful);
		}
		finally
		{
			Assert.That(SetJob(hprnt, id, JOB_CONTROL.JOB_CONTROL_DELETE), ResultIs.Successful);
		}
	}

	[Test]
	public void OpenPrinter2Test()
	{
		Assert.That(OpenPrinter2(defaultPrinterName, out var hprnt2, new PRINTER_DEFAULTS { DesiredAccess = (uint)AccessRights.PRINTER_ALL_ACCESS }, PRINTER_OPTIONS.Default), ResultIs.Successful);
		hprnt2.Dispose();
	}

	[Test]
	public void PortTest()
	{
		var port = GetPrinter<PRINTER_INFO_2>(hprnt).pPortName;

		Assert.That(ConfigurePort(null, HWND.NULL, port), ResultIs.Successful);

		Assert.That(SetPort(null, port, PORT_STATUS.PORT_STATUS_OFFLINE, PORT_STATUS_TYPE.PORT_STATUS_TYPE_ERROR), ResultIs.Successful);
		Assert.That(SetPort(null, port, "Off-line", PORT_STATUS_TYPE.PORT_STATUS_TYPE_ERROR), ResultIs.Successful);
		Assert.That(SetPort(null, port, 0, 0), ResultIs.Successful);
	}

	[Test]
	public void PrinterPropertiesTest()
	{
		Assert.That(PrinterProperties(HWND.NULL, hprnt), ResultIs.Successful);
	}

	[Test]
	public void SpoolFileTest()
	{
		var hspf = GetSpoolFileHandle(hprnt);
		Assert.That(hspf, ResultIs.ValidHandle);
		var bytes = new byte[] { 0, 1, 0, 1, 0, 1, 0, 1, 0, 1, 0, 1, 0, 1 };
		Kernel32.WriteFile(hspf, bytes, (uint)bytes.Length, out _);
		Assert.That(CommitSpoolData(hprnt, hspf, (uint)bytes.Length), ResultIs.Successful);
		Assert.That(hspf.Dispose, Throws.Nothing);
	}

	[Test]
	public void StartWriteEndDocPagePrinterTest()
	{
		var log = new List<string>();
		var cancel = false;
		new Thread(ChangeThread).Start();
		var job = StartDocPrinter(hprnt, 1, new DOC_INFO_1 { pDatatype = "RAW", pDocName = "My Document" });
		Assert.That(job, ResultIs.Not.Value(0U));
		try
		{
			Assert.That(StartPagePrinter(hprnt), ResultIs.Successful);
			try
			{
				using var s = new SafeCoTaskMemString("Testing this printer.", CharSet.Unicode);
				Assert.That(WritePrinter(hprnt, s, s.Size, out var written), ResultIs.Successful);
				Assert.That(written, Is.EqualTo((uint)s.Size));
			}
			finally
			{
				Assert.That(EndPagePrinter(hprnt), ResultIs.Successful);
			}
		}
		finally
		{
			Assert.That(EndDocPrinter(hprnt), ResultIs.Successful);
			cancel = true;
			TestContext.WriteLine(string.Join("\r\n", log));
		}

		void ChangeThread()
		{
			using var hChange = FindFirstPrinterChangeNotification(hprnt, PRINTER_CHANGE.PRINTER_CHANGE_ALL, PRINTER_NOTIFY_CATEGORY.PRINTER_NOTIFY_CATEGORY_2D);
			while (!cancel)
			{
				if (Kernel32.WaitForSingleObject(hChange, 200) == Kernel32.WAIT_STATUS.WAIT_OBJECT_0)
				{
					if (FindNextPrinterChangeNotification(hChange, out var chg, default, out var ppi) && !ppi.IsInvalid)
					{
						PRINTER_NOTIFY_INFO pi = ppi;
						if (pi.aData is not null)
							log.Add($"{chg}: {string.Join(",", pi.aData.Select(d => d.Field))}");
					}
				}
			}
		}
	}
}