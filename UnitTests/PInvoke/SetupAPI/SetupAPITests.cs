using NUnit.Framework;
using NUnit.Framework.Internal;
using System.Linq;
using static Vanara.PInvoke.SetupAPI;

namespace Vanara.PInvoke.Tests;

[TestFixture]
public class SetupAPITests
{
	private SafeHDEVINFO? hDevInfo;

	[OneTimeSetUp]
	public void _Setup() => hDevInfo = SetupDiGetClassDevs(Flags: DIGCF.DIGCF_PRESENT|DIGCF.DIGCF_ALLCLASSES);

	[OneTimeTearDown]
	public void _TearDown() => hDevInfo?.Dispose();

	[Test]
	public void _StructSizeTest()
	{
		//foreach (var s in typeof(Vanara.PInvoke.SetupAPI).GetNestedStructSizes())
		//	TestContext.WriteLine(s);

		TestHelper.DumpStructSizeAndOffsets<SP_DEVINFO_LIST_DETAIL_DATA>();
		TestHelper.DumpStructSizeAndOffsets<SP_DEVINSTALL_PARAMS>();
	}

	[Test]
	public void SetupDiEnumDeviceInfoTest()
	{
		var ie = SetupDiEnumDeviceInfo(hDevInfo!).ToList();
		Assert.That(ie, Is.Not.Empty);

		foreach (SP_DEVINFO_DATA i in ie)
		{
			SetupDiClassNameFromGuid(i.ClassGuid, out var sb);
			TestContext.WriteLine($"{sb} ({i.ClassGuid}) = {i.DevInst}");
		}
	}

	[Test]
	public void SetupDiEnumDeviceInterfacesTest()
	{
		var guid = new Guid(0xA5DCBF10, 0x6530, 0x11D2, 0x90, 0x1F, 0x00, 0xC0, 0x4F, 0xB9, 0x51, 0xED); // GUID_DEVINTERFACE_USB_DEVICE
		using var hdi = SetupDiGetClassDevs(guid, Flags: DIGCF.DIGCF_PRESENT | DIGCF.DIGCF_DEVICEINTERFACE);
		Assert.That(hdi, ResultIs.ValidHandle);

		var ie = SetupDiEnumDeviceInterfaces(hdi, guid).ToList();
		Assert.That(ie, Is.Not.Empty);

		foreach (SP_DEVICE_INTERFACE_DATA i in ie)
		{
			Assert.That(SetupDiGetDeviceInterfaceDetail(hdi, i, out var path, out _), ResultIs.Successful);

			TestContext.WriteLine($"{path}; {i.Flags}");
		}
	}

	[Test]
	public void SetupDiGetDevicePropertyKeysTest()
	{
		foreach (var did in SetupDiEnumDeviceInfo(hDevInfo!))
		{
			Assert.That(SetupDiGetDevicePropertyKeys(hDevInfo!, did, null, 0, out var cnt), ResultIs.FailureCode(Win32Error.ERROR_INSUFFICIENT_BUFFER));
			var arr = new DEVPROPKEY[cnt];
			Assert.That(SetupDiGetDevicePropertyKeys(hDevInfo!, did, arr, (uint)arr.Length, out _), ResultIs.Successful);
			foreach (var key in arr)
			{
				Assert.That(SetupDiGetDeviceProperty(hDevInfo!, did, key, out var value), ResultIs.Successful);
				//var obj = value.GetType().IsArray ? string.Join(", ", ((IEnumerable)value).Cast<object>()) :
				//	(value is System.Runtime.InteropServices.ComTypes.FILETIME ft ? (object)ft.ToDateTime() : value)
				//TestContext.WriteLine($"{key.fmtid},{key.pid} = {obj}");
			}
		}
	}
}