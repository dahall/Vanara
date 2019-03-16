using NUnit.Framework;
using System;
using System.Linq;
using System.Runtime.InteropServices;
using Vanara.InteropServices;
using static Vanara.PInvoke.Gdi32;
using static Vanara.PInvoke.User32_Gdi;

namespace Vanara.PInvoke.Tests
{
	[TestFixture()]
	public class User32Tests
	{
		[Test()]
		public void CallNextHookExTest()
		{
			throw new NotImplementedException();
		}

		[Test()]
		public void ChildWindowFromPointExTest()
		{
			throw new NotImplementedException();
		}

		[Test()]
		public void DestroyIconTest()
		{
			throw new NotImplementedException();
		}

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
				Assert.That(() => DisplayConfigGetDeviceInfo<RECT>(mode.adapterId, mode.id), Throws.Exception);
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
			var hwnd = GetActiveWindow();
			Assert.That(hwnd.IsNull, Is.False);
		}

		[Test]
		public void GetDisplayAutoRotationPreferencesTest()
		{
			Assert.That(GetDisplayAutoRotationPreferences(out var o));
			Assert.That(o, Is.EqualTo(ORIENTATION_PREFERENCE.ORIENTATION_PREFERENCE_NONE));
		}

		[Test()]
		public void GetWindowLongTest()
		{
			throw new NotImplementedException();
		}

		[Test()]
		public void GetWindowLong32Test()
		{
			throw new NotImplementedException();
		}

		[Test()]
		public void GetWindowLongPtrTest()
		{
			throw new NotImplementedException();
		}

		[Test()]
		public void LockWorkStationTest()
		{
			throw new NotImplementedException();
		}

		[Test()]
		public void RealGetWindowClassTest()
		{
			throw new NotImplementedException();
		}

		[Test()]
		public void RegisterHotKeyTest()
		{
			throw new NotImplementedException();
		}

		[Test()]
		public void RegisterWindowMessageTest()
		{
			throw new NotImplementedException();
		}

		[Test()]
		public void ScreenToClientTest()
		{
			throw new NotImplementedException();
		}

		[Test()]
		public void SendMessageTest()
		{
			throw new NotImplementedException();
		}

		[Test()]
		public void SendMessageTest1()
		{
			throw new NotImplementedException();
		}

		[Test()]
		public void SendMessageTest2()
		{
			throw new NotImplementedException();
		}

		[Test()]
		public void SendMessageTest3()
		{
			throw new NotImplementedException();
		}

		[Test()]
		public void SendMessageTest4()
		{
			throw new NotImplementedException();
		}

		[Test()]
		public void SendMessageTest5()
		{
			throw new NotImplementedException();
		}

		[Test()]
		public void SetWindowLongTest()
		{
			throw new NotImplementedException();
		}

		[Test()]
		public void SetWindowPosTest()
		{
			throw new NotImplementedException();
		}

		[Test()]
		public void SetWindowTextTest()
		{
			throw new NotImplementedException();
		}

		[Test()]
		public void ShutdownBlockReasonCreateTest()
		{
			throw new NotImplementedException();
		}

		[Test()]
		public void ShutdownBlockReasonDestroyTest()
		{
			throw new NotImplementedException();
		}

		[Test()]
		public void ShutdownBlockReasonQueryTest()
		{
			throw new NotImplementedException();
		}

		[Test()]
		public void ShutdownBlockReasonQueryTest1()
		{
			throw new NotImplementedException();
		}

		[Test()]
		public void UnhookWindowsHookExTest()
		{
			throw new NotImplementedException();
		}

		[Test()]
		public void UnregisterHotKeyTest()
		{
			throw new NotImplementedException();
		}

		[Test()]
		public void WindowFromPointTest()
		{
			throw new NotImplementedException();
		}

		[Test()]
		public void ExitWindowsExTest()
		{
			throw new NotImplementedException();
		}

		[Test()]
		public void DrawTextTest()
		{
			throw new NotImplementedException();
		}

		[Test()]
		public void GetClientRectTest()
		{
			throw new NotImplementedException();
		}

		[Test()]
		public void GetWindowRectTest()
		{
			throw new NotImplementedException();
		}

		[Test()]
		public void InvalidateRectTest()
		{
			throw new NotImplementedException();
		}

		[Test()]
		public void MapWindowPointsTest()
		{
			throw new NotImplementedException();
		}

		[Test()]
		public void MapWindowPointsTest1()
		{
			throw new NotImplementedException();
		}

		[Test()]
		public void MapWindowPointsTest2()
		{
			throw new NotImplementedException();
		}

		[Test()]
		public void SendMessageTest6()
		{
			throw new NotImplementedException();
		}

		[Test()]
		public void LoadImageTest()
		{
			throw new NotImplementedException();
		}

		[Test()]
		public void LoadStringTest()
		{
			throw new NotImplementedException();
		}

		[Test()]
		public void LoadStringTest1()
		{
			throw new NotImplementedException();
		}

		[Test()]
		public void SetWindowsHookExTest()
		{
			throw new NotImplementedException();
		}
	}
}