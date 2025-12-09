using NUnit.Framework;
using System.Linq;
using static Vanara.PInvoke.Gdi32;
using static Vanara.PInvoke.User32;

namespace Vanara.PInvoke.Tests;

[TestFixture()]
public partial class User32Tests
{
	//[Test()]
	public void CallNextHookExTest() => throw new NotImplementedException();

	//[Test()]
	public void ChildWindowFromPointExTest() => throw new NotImplementedException();

	//[Test()]
	public void DestroyIconTest() => throw new NotImplementedException();

	[Test]
	public void EnumDisplayDevicesTest()
	{
		var devNum = 0U;
		var dd = DISPLAY_DEVICE.Default;
		while (EnumDisplayDevices(null, devNum, ref dd, EDD.EDD_GET_DEVICE_INTERFACE_NAME))
		{
			TestContext.WriteLine($"Name: {dd.DeviceName} : {dd.DeviceString}; State: {dd.StateFlags}");
			var dm = DEVMODE.Default;
			var mode = 0U;
			while (EnumDisplaySettings(dd.DeviceName, mode, ref dm))
			{
				TestContext.WriteLine($"   {mode}) {dm.dmBitsPerPel},{dm.dmPelsWidth},{dm.dmPelsHeight},{dm.dmDisplayFlags},{dm.dmDisplayFrequency}");
				mode++;
			}
			dm = DEVMODE.Default;
			mode = 0U;
			while (EnumDisplaySettingsEx(dd.DeviceName, mode, ref dm, EDS.EDS_ROTATEDMODE))
			{
				TestContext.WriteLine($"   {mode}) {dm.dmBitsPerPel},{dm.dmPelsWidth},{dm.dmPelsHeight},{dm.dmDisplayFlags},{dm.dmDisplayFrequency},{dm.dmDisplayOrientation},{dm.dmPosition}");
				mode++;
			}
			devNum++;
		}
	}

	[Test]
	public void DisplayConfigTest()
	{
		Assert.That(QueryDisplayConfig(QDC.QDC_ONLY_ACTIVE_PATHS, out var paths, out var modes, out var topId).Succeeded, Is.True);
		foreach (var mode in modes.Where(m => m.infoType == DISPLAYCONFIG_MODE_INFO_TYPE.DISPLAYCONFIG_MODE_INFO_TYPE_TARGET))
		{
			Assert.That(() => DisplayConfigGetDeviceInfo<DISPLAYCONFIG_TARGET_DEVICE_NAME>(mode.adapterId, mode.id, DISPLAYCONFIG_DEVICE_INFO_TYPE.DISPLAYCONFIG_DEVICE_INFO_GET_ADAPTER_NAME), Throws.Exception);
			TestContext.WriteLine(DisplayConfigGetDeviceInfo<DISPLAYCONFIG_TARGET_DEVICE_NAME>(mode.adapterId, mode.id).monitorFriendlyDeviceName);
			TestContext.WriteLine(DisplayConfigGetDeviceInfo<DISPLAYCONFIG_ADAPTER_NAME>(mode.adapterId, mode.id).adapterDevicePath);
			TestContext.WriteLine(DisplayConfigGetDeviceInfo<DISPLAYCONFIG_TARGET_BASE_TYPE>(mode.adapterId, mode.id).baseOutputTechnology);
			TestContext.WriteLine(DisplayConfigGetDeviceInfo<DISPLAYCONFIG_SUPPORT_VIRTUAL_RESOLUTION>(mode.adapterId, mode.id).value);
			TestContext.WriteLine(DisplayConfigGetDeviceInfo<DISPLAYCONFIG_GET_ADVANCED_COLOR_INFO>(mode.adapterId, mode.id).colorEncoding);
			TestContext.WriteLine(DisplayConfigGetDeviceInfo<DISPLAYCONFIG_SDR_WHITE_LEVEL>(mode.adapterId, mode.id).SDRWhiteLevel);
			TestContext.WriteLine(DisplayConfigGetDeviceInfo<DISPLAYCONFIG_TARGET_PREFERRED_MODE>(mode.adapterId, mode.id).targetMode);
		}
		foreach (var path in paths.Where(p => p.targetInfo.targetAvailable))
		{
			TestContext.WriteLine(DisplayConfigGetDeviceInfo<DISPLAYCONFIG_SOURCE_DEVICE_NAME>(path.sourceInfo.adapterId, path.sourceInfo.id).viewGdiDeviceName);
		}
	}

	[Test()]
	public void GetActiveWindowTest()
	{
		Assert.That(() => GetActiveWindow(), Throws.Nothing);
	}

	[Test]
	public void GetDisplayAutoRotationPreferencesTest()
	{
		Assert.That(GetDisplayAutoRotationPreferences(out var o));
		Assert.That(o, Is.EqualTo(ORIENTATION_PREFERENCE.ORIENTATION_PREFERENCE_NONE));
	}
}