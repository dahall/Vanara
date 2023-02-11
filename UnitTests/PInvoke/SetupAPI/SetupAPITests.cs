using NUnit.Framework;
using NUnit.Framework.Internal;
using System;
using System.Linq;
using System.Runtime.InteropServices;
using static Vanara.PInvoke.SetupAPI;

namespace Vanara.PInvoke.Tests;

[TestFixture]
public class SetupAPITests
{
	private SafeHDEVINFO hDevInfo;

	[OneTimeSetUp]
	public void _Setup() => hDevInfo = SetupDiGetClassDevs(Flags: DIGCF.DIGCF_PRESENT | DIGCF.DIGCF_ALLCLASSES);

	[Test]
	public void _StructSizeTest()
	{
		//foreach (var s in typeof(Vanara.PInvoke.SetupAPI).GetNestedStructSizes())
		//	TestContext.WriteLine(s);

		TestHelper.DumpStructSizeAndOffsets<SP_DEVINFO_LIST_DETAIL_DATA>();
		TestHelper.DumpStructSizeAndOffsets<SP_DEVINSTALL_PARAMS>();
	}

	[OneTimeTearDown]
	public void _TearDown() => hDevInfo?.Dispose();

	[Test]
	public void SetupDiEnumDeviceInfoTest()
	{
		System.Collections.Generic.List<SP_DEVINFO_DATA> ie = SetupDiEnumDeviceInfo(hDevInfo).ToList();
		Assert.That(ie, Is.Not.Empty);

		foreach (SP_DEVINFO_DATA i in ie)
		{
			_ = SetupDiClassNameFromGuid(i.ClassGuid, out string sb);
			TestContext.WriteLine($"{sb} ({i.ClassGuid}) = {i.DevInst}");
		}
	}

	[Test]
	public void SetupDiEnumDeviceInterfacesTest()
	{
		Guid guid = new(0xA5DCBF10, 0x6530, 0x11D2, 0x90, 0x1F, 0x00, 0xC0, 0x4F, 0xB9, 0x51, 0xED); // GUID_DEVINTERFACE_USB_DEVICE
		using SafeHDEVINFO hdi = SetupDiGetClassDevs(guid, Flags: DIGCF.DIGCF_PRESENT | DIGCF.DIGCF_DEVICEINTERFACE);
		Assert.That(hdi, ResultIs.ValidHandle);

		System.Collections.Generic.List<SP_DEVICE_INTERFACE_DATA> ie = SetupDiEnumDeviceInterfaces(hdi, guid).ToList();
		Assert.That(ie, Is.Not.Empty);

		foreach (SP_DEVICE_INTERFACE_DATA i in ie)
		{
			Assert.That(SetupDiGetDeviceInterfaceDetail(hdi, i, out string path, out _), ResultIs.Successful);

			TestContext.WriteLine($"{path}; {i.Flags}");
		}
	}

	[Test]
	public void SetupDiGetDevicePropertyKeysTest()
	{
		foreach (SP_DEVINFO_DATA did in SetupDiEnumDeviceInfo(hDevInfo))
		{
			Assert.That(SetupDiGetDevicePropertyKeys(hDevInfo, did, null, 0, out uint cnt), ResultIs.FailureCode(Win32Error.ERROR_INSUFFICIENT_BUFFER));
			DEVPROPKEY[] arr = new DEVPROPKEY[cnt];
			Assert.That(SetupDiGetDevicePropertyKeys(hDevInfo, did, arr, (uint)arr.Length, out _), ResultIs.Successful);
			foreach (DEVPROPKEY key in arr)
			{
				Assert.That(SetupDiGetDeviceProperty(hDevInfo, did, key, out _), ResultIs.Successful);
				//var obj = value.GetType().IsArray ? string.Join(", ", ((IEnumerable)value).Cast<object>()) :
				//	(value is System.Runtime.InteropServices.ComTypes.FILETIME ft ? (object)ft.ToDateTime() : value)
				//TestContext.WriteLine($"{key.fmtid},{key.pid} = {obj}");
			}
		}
	}

	[Test]
	public void SetupDiEnumDriverInfoTest()
	{
		Assert.That(SetupDiBuildDriverInfoList(hDevInfo, default, SPDIT.SPDIT_CLASSDRIVER), ResultIs.Successful);
		System.Collections.Generic.List<SP_DRVINFO_DATA_V2> ie = SetupDiEnumDriverInfo(hDevInfo, null, SPDIT.SPDIT_CLASSDRIVER).ToList();
		Assert.That(ie, Is.Not.Empty);

		foreach (SP_DRVINFO_DATA_V2 i in ie)
			TestContext.WriteLine($"{i.MfgName} : {i.Description}");
	}

	[Test]
	public void SetupDiGetDriverInfoDetailTest()
	{
		Assert.That(SetupDiBuildDriverInfoList(hDevInfo, default, SPDIT.SPDIT_CLASSDRIVER), ResultIs.Successful);
		foreach (SP_DRVINFO_DATA_V2 drvData in SetupDiEnumDriverInfo(hDevInfo, null, SPDIT.SPDIT_CLASSDRIVER))
		{
			SP_DRVINFO_DETAIL_DATA_MGD mgd = null;
			Assert.That(() => mgd = SetupDiGetDriverInfoDetail(hDevInfo, null, drvData), Throws.Nothing);
			Assert.NotNull(mgd);
			Assert.That(mgd.InfDate, Is.GreaterThan(DateTime.MinValue));
			Assert.NotNull(mgd.InfFileName);
			Assert.NotNull(mgd.SectionName);
			Assert.NotNull(mgd.DrvDescription);
			Assert.NotNull(mgd.HardwareID);
			Assert.That(mgd.CompatIDs, Is.Not.Null);
			if (mgd.CompatIDs.Length > 0)
				TestContext.WriteLine($"{mgd.DrvDescription}; {mgd.HardwareID}; {string.Join("|", mgd.CompatIDs)}");
		}
	}
}