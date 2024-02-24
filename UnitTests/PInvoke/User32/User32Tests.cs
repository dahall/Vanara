using NUnit.Framework;
using System.Linq;
using System.Reflection;
using static Vanara.PInvoke.User32;

namespace Vanara.PInvoke.Tests;

[TestFixture()]
public partial class User32Tests
{
	[Test]
	public void GetGestureConfigTest()
	{
		var array = new GESTURECONFIG[] { new GESTURECONFIG(GID.GID_ZOOM), new GESTURECONFIG(GID.GID_ROTATE), new GESTURECONFIG(GID.GID_PAN) };
		var aLen = (uint)array.Length;
		var b = GetGestureConfig(FindWindow(null, null), 0, 0, ref aLen, array, (uint)Marshal.SizeOf(typeof(GESTURECONFIG)));
		if (!b) Win32Error.ThrowLastError();
		Assert.That(b, Is.True);
		Assert.That(aLen, Is.GreaterThan(0));
		for (var i = 0; i < aLen; i++)
			TestContext.WriteLine($"{array[i].dwID} = {array[i].dwWant} / {array[i].dwBlock}");
	}

	[Test]
	public void GetRawInputDeviceInfoTest()
	{
		uint nDev = 0;
		Assert.That(GetRawInputDeviceList(null, ref nDev, (uint)Marshal.SizeOf(typeof(RAWINPUTDEVICELIST))), ResultIs.Not.Value(uint.MaxValue));
		Assert.That(nDev, Is.GreaterThan(0));
		RAWINPUTDEVICELIST[] devs = new RAWINPUTDEVICELIST[(int)nDev];
		Assert.That(nDev = GetRawInputDeviceList(devs, ref nDev, (uint)Marshal.SizeOf(typeof(RAWINPUTDEVICELIST))), ResultIs.Not.Value(uint.MaxValue));
		Assert.That(nDev, Is.GreaterThan(0));

		for (int i = 0; i < nDev; i++)
		{
			uint sz = 0;
			Assert.That(GetRawInputDeviceInfo(devs[i].hDevice, RIDI.RIDI_DEVICENAME, default, ref sz), ResultIs.Value(0));
			SafeLPTSTR data = new((int)sz + 1);
			Assert.That(GetRawInputDeviceInfo(devs[i].hDevice, RIDI.RIDI_DEVICENAME, data, ref sz), Is.GreaterThan(0));
			TestContext.WriteLine($"{data}");
		}
	}

	[Test]
	public void WinTest()
	{
		var timer = System.Diagnostics.Stopwatch.StartNew();
		var gotMsg = false;
		using (var win = new BasicMessageWindow(meth))
		{
			for (int i = 0; i < 100; i++)
				System.Threading.Thread.Sleep(20);
		}
		timer.Stop();
		Assert.True(gotMsg);

		bool meth(HWND hwnd, uint uMsg, IntPtr wParam, IntPtr lParam, out IntPtr lReturn)
		{
			lReturn = default;
			TestContext.WriteLine($"{timer.ElapsedMilliseconds} Message: {(WindowMessage)uMsg} ({uMsg})");
			gotMsg = true;
			return false;
		}
	}

	[Test()]
	public void GetWindowLongTest() => throw new NotImplementedException();

	[Test()]
	public void GetWindowLong32Test() => throw new NotImplementedException();

	[Test()]
	public void GetWindowLongPtrTest() => throw new NotImplementedException();

	[Test()]
	public void LockWorkStationTest() => throw new NotImplementedException();

	[Test()]
	public void MB_GetStringTest()
	{
		Assert.NotNull((string?)MB_GetString(1));
		TestContext.WriteLine((string?)MB_GetString(1));
	}

	[Test()]
	public void RealGetWindowClassTest() => throw new NotImplementedException();

	[Test()]
	public void RegisterHotKeyTest() => throw new NotImplementedException();

	[Test()]
	public void RegisterWindowMessageTest() => throw new NotImplementedException();

	[Test()]
	public void ScreenToClientTest() => throw new NotImplementedException();

	[Test()]
	public void SendMessageTest()
	{
		// WM_ERASEBKGND
		SendMessage(default, WindowMessage.WM_ERASEBKGND, (IntPtr)HDC.NULL);

		// WM_GETFONT
		HFONT hFont = SendMessage(default, WindowMessage.WM_GETFONT);

		// WM_GETTEXT
		var sb = new StringBuilder(256);
		SendMessage(default, WindowMessage.WM_GETTEXT, sb.Capacity, sb);

		// WM_GETTEXTLEN
		SendMessage(default, WindowMessage.WM_GETTEXTLENGTH);

		// WM_SETFONT
		SendMessage(default, WindowMessage.WM_SETFONT, (IntPtr)HFONT.NULL, true);

		// WM_SETICON
		SendMessage(default, WindowMessage.WM_SETICON, ICONSZ.ICON_BIG, (IntPtr)HICON.NULL);

		// WM_SETTEXT
		SendMessage(default, WindowMessage.WM_SETTEXT, default, "Text");
		SendMessage(default, WindowMessage.WM_SETTEXT, 4, "Text");

		// WM_DRAWITEM
		var dis = new DRAWITEMSTRUCT();
		SendMessage(default, WindowMessage.WM_DRAWITEM, 12, ref dis);

		// BCM_SETSPLITINFO
		SendMessage(default, ButtonMessage.BCM_SETSPLITINFO, default, ref dis);
		SendMessage(default, ButtonMessage.BCM_SETSPLITINFO, true, ref dis);
		SendMessage(default, ButtonMessage.BCM_SETSPLITINFO, 4, ref dis);


		// BCM_SETSPLITINFO
		SendMessage(default, ButtonMessage.BCM_SETDROPDOWNSTATE, true);

	}

	public enum ICONSZ
	{
		ICON_BIG,
		ICON_SMALL
	}

	//public static IntPtr SendMessage<TMsg, THandle>(HWND hwnd, TMsg msg, THandle wParam) where TMsg : struct, IConvertible where THandle : IHandle
	//	=> SendMessage(hwnd, Convert.ToUInt32(msg), (IntPtr)wParam, IntPtr.Zero);

	[Test()]
	public void SendMessageTest1()
	{
		var length = 256;
		var sb = new StringBuilder(length);
		Assert.That(SendMessage(FindWindow("Progman", null), (uint)WindowMessage.WM_GETTEXT, (IntPtr)sb.Capacity, sb).ToInt32(), Is.GreaterThanOrEqualTo(1));
		TestContext.WriteLine(sb);
	}

	[Test()]
	public void SendMessageTest2() => throw new NotImplementedException();

	[Test()]
	public void SendMessageTest3() => throw new NotImplementedException();

	[Test()]
	public void SendMessageTest4() => throw new NotImplementedException();

	[Test()]
	public void SendMessageTest5() => throw new NotImplementedException();

	[Test()]
	public void SetWindowLongTest() => throw new NotImplementedException();

	[Test()]
	public void SetWindowPosTest() => throw new NotImplementedException();

	[Test()]
	public void SetWindowTextTest() => throw new NotImplementedException();

	[Test()]
	public void ShutdownBlockReasonCreateTest() => throw new NotImplementedException();

	[Test()]
	public void ShutdownBlockReasonDestroyTest() => throw new NotImplementedException();

	[Test()]
	public void ShutdownBlockReasonQueryTest() => throw new NotImplementedException();

	[Test()]
	public void ShutdownBlockReasonQueryTest1() => throw new NotImplementedException();

	[Test()]
	public void UnhookWindowsHookExTest() => throw new NotImplementedException();

	[Test()]
	public void UnregisterHotKeyTest() => throw new NotImplementedException();

	[Test()]
	public void WindowFromPointTest() => throw new NotImplementedException();

	[Test()]
	public void ExitWindowsExTest() => throw new NotImplementedException();

	[Test()]
	public void DrawTextTest() => throw new NotImplementedException();

	[Test()]
	public void GetClientRectTest() => throw new NotImplementedException();

	[Test()]
	public void GetWindowRectTest() => throw new NotImplementedException();

	[Test()]
	public void InvalidateRectTest() => throw new NotImplementedException();

	[Test()]
	public void MapWindowPointsTest() => throw new NotImplementedException();

	[Test()]
	public void MapWindowPointsTest1() => throw new NotImplementedException();

	[Test()]
	public void MapWindowPointsTest2() => throw new NotImplementedException();

	[Test()]
	public void SendMessageTest6() => throw new NotImplementedException();

	[Test()]
	public void LoadImageTest() => throw new NotImplementedException();

	[Test()]
	public void LoadStringTest() => throw new NotImplementedException();

	[Test()]
	public void LoadStringTest1() => throw new NotImplementedException();

	[Test()]
	public void SetWindowsHookExTest() => throw new NotImplementedException();

	[Test]
	public void SystemParametersInfoGetTest()
	{
		// Try get integral value
		var ptr = new SafeHGlobalHandle(4);
		Assert.That(SystemParametersInfo(SPI.SPI_GETFOCUSBORDERHEIGHT, 0, (IntPtr)ptr, 0));
		var uval1 = ptr.ToStructure<uint>();
		Assert.That(uval1, Is.Not.Zero);

		// Try get generic integral value
		Assert.That(SystemParametersInfo(SPI.SPI_GETFOCUSBORDERHEIGHT, out uint uval2));
		Assert.That(uval2, Is.EqualTo(uval1));

		// Try get bool value
		ptr = new SafeHGlobalHandle(4);
		Assert.That(SystemParametersInfo(SPI.SPI_GETCLIENTAREAANIMATION, 0, (IntPtr)ptr, 0));
		bool bval1 = ptr.ToStructure<BOOL>();

		// Try get generic bool value
		Assert.That(SystemParametersInfo(SPI.SPI_GETCLIENTAREAANIMATION, out bool bval2));
		Assert.That(bval2, Is.EqualTo(bval1));

		// Try get enum value
		ptr = new SafeHGlobalHandle(4);
		Assert.That(SystemParametersInfo(SPI.SPI_GETCONTACTVISUALIZATION, 0, (IntPtr)ptr, 0));
		var eval1 = ptr.ToStructure<ContactVisualization>();
		Assert.That(eval1, Is.Not.Zero);

		// Try get generic enum value
		Assert.That(SystemParametersInfo(SPI.SPI_GETCONTACTVISUALIZATION, out ContactVisualization eval2));
		Assert.That(eval2, Is.EqualTo(eval1));

		// Try get struct value
		ptr = SafeHGlobalHandle.CreateFromStructure<RECT>();
		Assert.That(SystemParametersInfo(SPI.SPI_GETWORKAREA, 0, (IntPtr)ptr, 0));
		var rval1 = ptr.ToStructure<RECT>();
		Assert.That(rval1.IsEmpty, Is.False);

		// Try get generic struct value
		Assert.That(SystemParametersInfo(SPI.SPI_GETWORKAREA, out RECT rval2));
		Assert.That(rval2, Is.EqualTo(rval1));

		// Try get string value
		var sb = new StringBuilder(Kernel32.MAX_PATH, Kernel32.MAX_PATH);
		Assert.That(SystemParametersInfo(SPI.SPI_GETDESKWALLPAPER, (uint)sb.Capacity, sb, 0));
	}

	[Test]
	public void SystemParametersInfoEnumTest()
	{
		var mi = typeof(User32).GetMember("SystemParametersInfo*", BindingFlags.Static | BindingFlags.Public | BindingFlags.InvokeMethod).
			Cast<MethodInfo>().First(m => m.ContainsGenericParameters && m.GetParameters().Length == 2);
		var smi = typeof(User32).GetMember("SystemParametersInfo*", BindingFlags.Static | BindingFlags.Public | BindingFlags.InvokeMethod).
			Cast<MethodInfo>().First(m => m.ContainsGenericParameters && m.GetParameters().Length == 4);
		foreach (SPI e in Enum.GetValues(typeof(SPI)))
		{
			var gmi = X(e, mi, CorrespondingAction.Get);
			if (gmi is null)
				continue;
			var param = new object?[] { e, null };
			TestContext.Write($"{e}: ");
			if ((bool)gmi.Invoke(null, param)!)
				TestContext.WriteLine($"{param[1]}");
			else
				TestContext.Write($"ERROR: {Win32Error.GetLastError()}");

			if (!Enum.TryParse(Enum.GetName(typeof(SPI), e)!.Replace("SPI_GET", "SPI_SET"), out SPI se) || se == SPI.SPI_SETSHOWSOUNDS)
				continue;
			gmi = X(se, smi, CorrespondingAction.Set);
			if (gmi is null)
				continue;
			var sparam = new object?[] { se, param[1], false, false };
			TestContext.Write($"{se}: ");
			if ((bool)gmi.Invoke(null, sparam)!)
				TestContext.WriteLine("Pass");
			else
				TestContext.Write($"Fail: {Win32Error.GetLastError()}");
		}

		static MethodInfo? X(SPI e, MethodInfo mi, CorrespondingAction a)
		{
			if (!e.GetType().GetField(e.ToString())!.GetCustomAttributes<ObsoleteAttribute>().Any())
			{
				var typeAttrs = CorrespondingTypeAttribute.GetAttrForEnum(e).ToArray();
				if (typeAttrs.Length > 0 && typeAttrs[0].Action == a)
				{
					var genType = typeAttrs[0].TypeRef;
					if (genType!.IsValueType)
						return mi.MakeGenericMethod(genType);
				}
			}
			return null;
		}
	}

	[Test]
	public void SystemParametersInfoSetTest()
	{
		// Try set bool value
		SystemParametersInfo(SPI.SPI_GETBLOCKSENDINPUTRESETS, out bool bval);
		Assert.That(SystemParametersInfo(SPI.SPI_SETBLOCKSENDINPUTRESETS, bval ? 1u : 0u, IntPtr.Zero, 0));

		// Try set generic bool value
		Assert.That(SystemParametersInfo(SPI.SPI_SETBLOCKSENDINPUTRESETS, bval));

		// Try set integral value
		SystemParametersInfo(SPI.SPI_GETFOCUSBORDERHEIGHT, out uint ival);
		Assert.That(SystemParametersInfo(SPI.SPI_SETFOCUSBORDERHEIGHT, 0, (IntPtr)(int)ival, SPIF.SPIF_SENDCHANGE));

		// Try set generic integral value
		Assert.That(SystemParametersInfo(SPI.SPI_SETFOCUSBORDERHEIGHT, ival));

		// Try set enum value
		SystemParametersInfo(SPI.SPI_GETCONTACTVISUALIZATION, out ContactVisualization cv);
		uint cvu = (uint)cv;
		using (var pi = new PinnedObject(cvu))
			Assert.That(SystemParametersInfo(SPI.SPI_SETCONTACTVISUALIZATION, 0, pi, SPIF.SPIF_SENDCHANGE));

		// Try set generic enum value
		Assert.That(SystemParametersInfo(SPI.SPI_SETCONTACTVISUALIZATION, cv));

		// Try set struct value
		Assert.That(SystemParametersInfo(SPI.SPI_GETWORKAREA, out RECT area));
		area.right /= 2;
		using (var ptr = new PinnedObject(area))
			Assert.That(SystemParametersInfo(SPI.SPI_SETWORKAREA, (uint)Marshal.SizeOf(typeof(RECT)), (IntPtr)ptr, SPIF.SPIF_SENDCHANGE));

		// Try set generic struct value
		area.right *= 2;
		Assert.That(SystemParametersInfo(SPI.SPI_SETWORKAREA, area));

		// Try set string value
		var sb = new StringBuilder(Kernel32.MAX_PATH, Kernel32.MAX_PATH);
		Assert.That(SystemParametersInfo(SPI.SPI_GETDESKWALLPAPER, (uint)sb.Capacity, sb, 0));
		var wp = TestCaseSources.ImageFile;
		Assert.That(SystemParametersInfo(SPI.SPI_SETDESKWALLPAPER, (uint)wp.Length, wp, SPIF.SPIF_SENDCHANGE));
		Assert.That(SystemParametersInfo(SPI.SPI_SETDESKWALLPAPER, (uint)sb.Length, sb.ToString(), SPIF.SPIF_SENDCHANGE));
	}
}