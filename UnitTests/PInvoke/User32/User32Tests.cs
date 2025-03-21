﻿using NUnit.Framework;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Runtime.CompilerServices;
using static Vanara.PInvoke.User32;

namespace Vanara.PInvoke.Tests;

[TestFixture()]
public partial class User32Tests
{
	private const ushort ID_HELP = 150;
	private const ushort ID_TEXT = 200;

	public enum ICONSZ
	{
		ICON_BIG,
		ICON_SMALL
	}

	[Test]
	public void CreateDialogTest()
	{
		//-----------------------
		// Define a dialog box.
		//-----------------------
		DLGTEMPLATE dt = new()
		{
			style = (uint)(WindowStyles.WS_POPUP | WindowStyles.WS_BORDER | WindowStyles.WS_SYSMENU | WindowStyles.WS_CAPTION) | (uint)DialogBoxStyles.DS_MODALFRAME,
			cdit = 3,
			x = 10,
			y = 10,
			cx = 100,
			cy = 100,
		};
		using SafeCoTaskMemStruct<DLGTEMPLATE> lpdt = new(dt, 256);
		int lpw = Marshal.SizeOf<DLGTEMPLATE>();
		lpw += Write((ushort)0); // No menu
		lpw += Write((ushort)0); // Predefined dialog box class (by default)
		lpw += WriteStr("My Dialog");

		//-----------------------
		// Define an OK button.
		//-----------------------
		lpw = (int)Macros.ALIGN_TO_MULTIPLE(lpw, 4);    // Align DLGITEMTEMPLATE on DWORD boundary
		DLGITEMTEMPLATE lpdit = new()
		{
			x = 10,
			y = 70,
			cx = 80,
			cy = 20,
			id = (ushort)MB_RESULT.IDOK, // OK button identifier
			style = (uint)WindowStyles.WS_CHILD | (uint)WindowStyles.WS_VISIBLE | (uint)ButtonStyle.BS_DEFPUSHBUTTON
		};
		lpw += Write(lpdit);
		lpw += Write((ushort)0xFFFF); // Use id
		lpw += Write((ushort)0x0080); // Button class
		lpw += WriteStr("OK");
		lpw += Write((ushort)0); // No creation data

		//-----------------------
		// Define a Help button.
		//-----------------------
		lpw = (int)Macros.ALIGN_TO_MULTIPLE(lpw, 4);    // Align DLGITEMTEMPLATE on DWORD boundary
		lpdit = new()
		{
			x = 55,
			y = 10,
			cx = 40,
			cy = 20,
			id = ID_HELP, // Help button identifier
			style = (uint)WindowStyles.WS_CHILD | (uint)WindowStyles.WS_VISIBLE | (uint)ButtonStyle.BS_PUSHBUTTON
		};
		lpw += Write(lpdit);
		lpw += Write((ushort)0xFFFF); // Use id
		lpw += Write((ushort)0x0080); // Button class
		lpw += WriteStr("Help");
		lpw += Write((ushort)0); // No creation data

		//-----------------------
		// Define a static text control.
		//-----------------------
		lpw = (int)Macros.ALIGN_TO_MULTIPLE(lpw, 4);    // Align DLGITEMTEMPLATE on DWORD boundary
		lpdit = new()
		{
			x = 10,
			y = 10,
			cx = 40,
			cy = 20,
			id = ID_TEXT, // Text identifier
			style = (uint)WindowStyles.WS_CHILD | (uint)WindowStyles.WS_VISIBLE | (uint)StaticStyle.SS_LEFT
		};
		lpw += Write(lpdit);
		lpw += Write((ushort)0xFFFF); // Use id
		lpw += Write((ushort)0x0082); // Static class
		lpw += WriteStr("Test text");
		lpw += Write((ushort)0); // No creation data

		TestContext.WriteLine(lpw);
		TestContext.Write(lpdt.Dump);
		Assert.That(DialogBoxIndirectParam(hDialogTemplate: lpdt, hWndParent: GetDesktopWindow(), lpDialogFunc: DlgProc), ResultIs.Not.Value((IntPtr)(-1)));

		int Write<T>(in T o) where T : unmanaged => lpdt.DangerousGetHandle().Write(o, lpw, lpdt.Size);
		int WriteStr(string o) { StringHelper.Write(o + '\0', lpdt.DangerousGetHandle().Offset(lpw), out var nchar, true, CharSet.Unicode, lpdt.Size - lpw); return nchar; }
	}

	[Test]
	public void CreateWindowExTest()
	{
		WindowClass wc = WindowClass.MakeVisibleWindowClass("MyWindowClass", null);
		using SafeCoTaskMemHandle mem = new(128);
		SafeHWND wnd = new(IntPtr.Zero, false);
		Assert.That(wnd = CreateWindowEx(0, wc.ClassName, "1234567890", WindowStyles.WS_OVERLAPPEDWINDOW, lpParam: mem), ResultIs.ValidHandle);
		Assert.That(IsWindowUnicode(wnd), Is.EqualTo(IsWide.Value));
		Assert.That(GetWindowTextLength(wnd), Is.EqualTo(10));
		Assert.That(SetWindowText(wnd, "Hello, World!\0"));
		Assert.That(GetWindowTextLength(wnd), Is.EqualTo(13));
		StringBuilder sb = new(256);
		Assert.That(GetWindowText(wnd, sb, sb.Capacity), Is.EqualTo(13));
		Assert.That(sb.ToString(), Is.EqualTo("Hello, World!"));
		wnd.Dispose();
	}

	[Test]
	public void DrawTextTest() => throw new NotImplementedException();

	[Test]
	public void ExitWindowsExTest() => throw new NotImplementedException();

	[Test]
	public void GetClientRectTest() => throw new NotImplementedException();

	[Test]
	public void GetGestureConfigTest()
	{
		var array = new GESTURECONFIG[] { new(GID.GID_ZOOM), new(GID.GID_ROTATE), new(GID.GID_PAN) };
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
	public void GetSetWindowLongTest()
	{
		var s = WindowStyles.WS_TILED | WindowStyles.WS_TILEDWINDOW | WindowStyles.WS_CLIPSIBLINGS;
		WindowClass wc = new("MyWindowClass");
		SafeHWND wnd = CreateWindowEx(0, wc.ClassName, "1234567890", s);
		Assert.That(GetWindowLong<WindowStyles>(wnd, WindowLongFlags.GWL_STYLE), Is.EqualTo(s));
		SetWindowLong(wnd, WindowLongFlags.GWL_STYLE, (int)(s | WindowStyles.WS_DISABLED));
		Assert.That(GetWindowLong<WindowStyles>(wnd, WindowLongFlags.GWL_STYLE), Is.EqualTo(s | WindowStyles.WS_DISABLED));
	}

	[Test]
	public void GetWindowRectTest() => throw new NotImplementedException();

	[Test]
	public void InvalidateRectTest() => throw new NotImplementedException();

	[Test]
	public void LoadImageTest() => throw new NotImplementedException();

	[Test]
	public void LoadStringTest() => throw new NotImplementedException();

	[Test]
	public void LoadStringTest1() => throw new NotImplementedException();

	[Test]
	public void LockWorkStationTest() => throw new NotImplementedException();

	[Test]
	public void MapWindowPointsTest() => throw new NotImplementedException();

	[Test]
	public void MapWindowPointsTest1() => throw new NotImplementedException();

	[Test]
	public void MapWindowPointsTest2() => throw new NotImplementedException();

	[Test]
	public void MB_GetStringTest()
	{
		Assert.That((string?)MB_GetString(1), Is.Not.Null);
		TestContext.WriteLine((string?)MB_GetString(1));
	}

	[Test]
	public void MgdCreateDialogTest()
	{
		DLGTEMPLATE_MGD dlg = new()
		{
			style = WindowStyles.WS_POPUP | WindowStyles.WS_BORDER | WindowStyles.WS_SYSMENU | WindowStyles.WS_CAPTION | (WindowStyles)DialogBoxStyles.DS_MODALFRAME | (WindowStyles)DialogBoxStyles.DS_SETFONT,
			x = 10,
			y = 10,
			cx = 100,
			cy = 100,
			pointSz = 8,
			typeface = "MS Sans Serif",
			title = "My Dialog",
			controls = [
				DLGTEMPLATE_MGD.MakeButton("OK", (ushort)MB_RESULT.IDOK, 10, 70, 80, 20, WindowStyles.WS_CHILD | WindowStyles.WS_VISIBLE | WindowStyles.WS_TABSTOP | (WindowStyles)ButtonStyle.BS_DEFPUSHBUTTON),
				DLGTEMPLATE_MGD.MakeButton("Help", ID_HELP, 55, 10, 40, 20),
				DLGTEMPLATE_MGD.MakeStatic("Test text", ID_TEXT, 10, 10, 40, 20),
			]
		};
		Assert.That(DialogBoxIndirectParam(hDialogTemplate: dlg, hWndParent: GetDesktopWindow(), lpDialogFunc: DlgProc), ResultIs.Not.Value((IntPtr)(-1)));
	}

	[Test]
	public void MgdCreateDialogExTest()
	{
		DLGTEMPLATEEX_MGD dlg = new()
		{
			//style = WindowStyles.WS_POPUP | WindowStyles.WS_BORDER | WindowStyles.WS_SYSMENU | WindowStyles.WS_CAPTION | (WindowStyles)DialogBoxStyles.DS_MODALFRAME | (WindowStyles)DialogBoxStyles.DS_SETFONT,
			//x = 10,
			//y = 10,
			//cx = 100,
			//cy = 100,
			//pointsize = 8,
			//typeface = "MS Sans Serif",
			//title = "My Dialog",
			//controls = [
			//	DLGTEMPLATEEX_MGD.MakeButton("OK", (ushort)MB_RESULT.IDOK, 10, 70, 80, 20, WindowStyles.WS_CHILD | WindowStyles.WS_VISIBLE | WindowStyles.WS_TABSTOP | (WindowStyles)ButtonStyle.BS_DEFPUSHBUTTON),
			//	DLGTEMPLATEEX_MGD.MakeButton("Help", ID_HELP, 55, 10, 40, 20),
			//	DLGTEMPLATEEX_MGD.MakeStatic("Test text", ID_TEXT, 10, 10, 40, 20),
			//]
			cx = 207,
			cy = 88,
			style = (WindowStyles)(DialogBoxStyles.DS_SETFONT | DialogBoxStyles.DS_MODALFRAME | DialogBoxStyles.DS_FIXEDSYS) | WindowStyles.WS_POPUP | WindowStyles.WS_VISIBLE | WindowStyles.WS_CAPTION | WindowStyles.WS_SYSMENU,
			exStyle = WindowStylesEx.WS_EX_APPWINDOW,
			title = "Ambient Light Aware SDK Sample",
			pointsize = 8,
			typeface = "MS Shell Dlg",
			controls = [
				DLGTEMPLATEEX_MGD.MakeButton("Done", (ushort)MB_RESULT.IDOK, 7, 65, 50, 16, WindowStyles.WS_CHILD | WindowStyles.WS_VISIBLE | WindowStyles.WS_TABSTOP | (WindowStyles)ButtonStyle.BS_DEFPUSHBUTTON),
				DLGTEMPLATEEX_MGD.MakeStatic("Ambient light level: lux", 1001, 7, 7, 193, 12),
				DLGTEMPLATEEX_MGD.MakeStatic("Sample Optimized Text", 1003, 7, 33, 193, 32),
				DLGTEMPLATEEX_MGD.MakeStatic("Sensors: 0", 1002, 7, 18, 193, 9),
			]
		};
		Assert.That(DialogBoxIndirectParam(hDialogTemplate: dlg, hWndParent: GetDesktopWindow(), lpDialogFunc: DlgProc), ResultIs.Not.Value((IntPtr)(-1)));
	}

	[Test]
	public void MgdDlgTemplateReadWriteTest()
	{
		DLGTEMPLATE_MGD dlg = new()
		{
			style = WindowStyles.WS_POPUP | WindowStyles.WS_BORDER | WindowStyles.WS_SYSMENU | WindowStyles.WS_CAPTION | (WindowStyles)DialogBoxStyles.DS_MODALFRAME | (WindowStyles)DialogBoxStyles.DS_SETFONT,
			x = 10,
			y = 10,
			cx = 100,
			cy = 100,
			pointSz = 8,
			typeface = "MS Sans Serif",
			title = "My Dialog",
			controls = [
				DLGTEMPLATE_MGD.MakeButton("OK", (ushort)MB_RESULT.IDOK, 10, 70, 80, 20, WindowStyles.WS_CHILD | WindowStyles.WS_VISIBLE | WindowStyles.WS_TABSTOP | (WindowStyles)ButtonStyle.BS_DEFPUSHBUTTON),
				DLGTEMPLATE_MGD.MakeButton("Help", ID_HELP, 55, 10, 40, 20),
				DLGTEMPLATE_MGD.MakeStatic("Test text", ID_TEXT, 10, 10, 40, 20),
			]
		};
		using var mem = ((IVanaraMarshaler)dlg).MarshalManagedToNative(dlg);
		Assert.That(mem.Size, Is.GreaterThan(100));
		var dlg2 = (DLGTEMPLATE_MGD?)((IVanaraMarshaler)dlg).MarshalNativeToManaged(mem, mem.Size);
		Assert.That(dlg2, Is.Not.Null);
		Assert.That(dlg.typeface, Is.EqualTo(dlg2!.typeface));
		Assert.That(dlg.title, Is.EqualTo(dlg2!.title));
		Assert.That(dlg.controls.Count, Is.EqualTo(dlg2!.controls.Count));
		Assert.That(dlg.controls[1].title.name, Is.EqualTo(dlg2!.controls[1].title.name));
	}

	[Test]
	public void MgdDlgTemplateExReadWriteTest()
	{
		DLGTEMPLATEEX_MGD dlg = new()
		{
			style = WindowStyles.WS_POPUP | WindowStyles.WS_BORDER | WindowStyles.WS_SYSMENU | WindowStyles.WS_CAPTION | (WindowStyles)DialogBoxStyles.DS_MODALFRAME | (WindowStyles)DialogBoxStyles.DS_SETFONT,
			x = 10,
			y = 10,
			cx = 100,
			cy = 100,
			pointsize = 8,
			typeface = "MS Sans Serif",
			title = "My Dialog",
			controls = [
				DLGTEMPLATEEX_MGD.MakeButton("OK", (ushort)MB_RESULT.IDOK, 10, 70, 80, 20, WindowStyles.WS_CHILD | WindowStyles.WS_VISIBLE | WindowStyles.WS_TABSTOP | (WindowStyles)ButtonStyle.BS_DEFPUSHBUTTON),
				DLGTEMPLATEEX_MGD.MakeButton("Help", ID_HELP, 55, 10, 40, 20),
				DLGTEMPLATEEX_MGD.MakeStatic("Test text", ID_TEXT, 10, 10, 40, 20),
			]
		};
		using var mem = ((IVanaraMarshaler)dlg).MarshalManagedToNative(dlg);
		Assert.That(mem.Size, Is.GreaterThan(100));
		var dlg2 = (DLGTEMPLATEEX_MGD?)((IVanaraMarshaler)dlg).MarshalNativeToManaged(mem, mem.Size);
		Assert.That(dlg2, Is.Not.Null);
		Assert.That(dlg.typeface, Is.EqualTo(dlg2!.typeface));
		Assert.That(dlg.title, Is.EqualTo(dlg2!.title));
		Assert.That(dlg.controls.Count, Is.EqualTo(dlg2!.controls.Count));
		Assert.That(dlg.controls[1].title.name, Is.EqualTo(dlg2!.controls[1].title.name));
	}

	[Test]
	public void RealGetWindowClassTest() => throw new NotImplementedException();

	[Test]
	public void RegisterHotKeyTest() => throw new NotImplementedException();

	[Test]
	public void RegisterWindowMessageTest() => throw new NotImplementedException();

	[Test]
	public void ScreenToClientTest() => throw new NotImplementedException();

	[Test]
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

	[Test]
	public void SendMessageTest1()
	{
		var length = 256;
		var sb = new StringBuilder(length);
		Assert.That(SendMessage(FindWindow("Progman", null), (uint)WindowMessage.WM_GETTEXT, (IntPtr)sb.Capacity, sb).ToInt32(), Is.GreaterThanOrEqualTo(1));
		TestContext.WriteLine(sb);
	}

	[Test]
	public void SendMessageTest2() => throw new NotImplementedException();

	[Test]
	public void SendMessageTest3() => throw new NotImplementedException();

	[Test]
	public void SendMessageTest4() => throw new NotImplementedException();

	[Test]
	public void SendMessageTest5() => throw new NotImplementedException();

	[Test]
	public void SendMessageTest6() => throw new NotImplementedException();

	[Test]
	public void SetWindowPosTest() => throw new NotImplementedException();

	[Test]
	public void SetWindowsHookExTest() => throw new NotImplementedException();

	[Test]
	public void SetWindowTextTest() => throw new NotImplementedException();

	[Test]
	public void ShutdownBlockReasonCreateTest() => throw new NotImplementedException();

	[Test]
	public void ShutdownBlockReasonDestroyTest() => throw new NotImplementedException();

	[Test]
	public void ShutdownBlockReasonQueryTest() => throw new NotImplementedException();

	[Test]
	public void ShutdownBlockReasonQueryTest1() => throw new NotImplementedException();

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
	public void SystemParametersInfoSetTest()
	{
		// Try set bool value
		SystemParametersInfo(SPI.SPI_GETBLOCKSENDINPUTRESETS, out bool bval);
		Assert.That(SystemParametersInfo(SPI.SPI_SETBLOCKSENDINPUTRESETS, bval ? 1u : 0u, IntPtr.Zero, 0), ResultIs.Successful);

		// Try set generic bool value
		Assert.That(SystemParametersInfo(SPI.SPI_SETBLOCKSENDINPUTRESETS, bval), ResultIs.Successful);

		// Try set integral value
		SystemParametersInfo(SPI.SPI_GETFOCUSBORDERHEIGHT, out uint ival);
		Assert.That(SystemParametersInfo(SPI.SPI_SETFOCUSBORDERHEIGHT, 0, (IntPtr)(int)ival, SPIF.SPIF_SENDCHANGE), ResultIs.Successful);

		// Try set generic integral value
		Assert.That(SystemParametersInfo(SPI.SPI_SETFOCUSBORDERHEIGHT, ival, false, false), ResultIs.Successful);

		// Try set enum value
		SystemParametersInfo(SPI.SPI_GETCONTACTVISUALIZATION, out ContactVisualization cv);
		uint cvu = (uint)cv;
		using (var pi = new PinnedObject(cvu))
			Assert.That(SystemParametersInfo(SPI.SPI_SETCONTACTVISUALIZATION, 0, pi, SPIF.SPIF_SENDCHANGE), ResultIs.Successful);

		// Try set generic enum value
		Assert.That(SystemParametersInfo(SPI.SPI_SETCONTACTVISUALIZATION, cv), ResultIs.Successful);

		// Try set struct value
		Assert.That(SystemParametersInfo(SPI.SPI_GETWORKAREA, out RECT area), ResultIs.Successful);
		area.right /= 2;
		using (var ptr = new PinnedObject(area))
			Assert.That(SystemParametersInfo(SPI.SPI_SETWORKAREA, (uint)Marshal.SizeOf(typeof(RECT)), (IntPtr)ptr, SPIF.SPIF_SENDCHANGE), ResultIs.Successful);

		// Try set generic struct value
		area.right *= 2;
		Assert.That(SystemParametersInfo(SPI.SPI_SETWORKAREA, area), ResultIs.Successful);

		// Try set string value
		var sb = new StringBuilder(Kernel32.MAX_PATH, Kernel32.MAX_PATH);
		Assert.That(SystemParametersInfo(SPI.SPI_GETDESKWALLPAPER, (uint)sb.Capacity, sb, 0), ResultIs.Successful);
		var wp = TestCaseSources.ImageFile;
		Assert.That(SystemParametersInfo(SPI.SPI_SETDESKWALLPAPER, (uint)wp.Length, wp, SPIF.SPIF_SENDCHANGE), ResultIs.Successful);
		Assert.That(SystemParametersInfo(SPI.SPI_SETDESKWALLPAPER, (uint)sb.Length, sb.ToString(), SPIF.SPIF_SENDCHANGE), ResultIs.Successful);
	}

	[Test]
	public void UnhookWindowsHookExTest() => throw new NotImplementedException();

	[Test]
	public void UnregisterHotKeyTest() => throw new NotImplementedException();

	[Test]
	public void WindowFromPointTest() => throw new NotImplementedException();

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
		Assert.That(gotMsg);

		bool meth(HWND hwnd, uint uMsg, IntPtr wParam, IntPtr lParam, out IntPtr lReturn)
		{
			lReturn = default;
			TestContext.WriteLine($"{timer.ElapsedMilliseconds} Message: {(WindowMessage)uMsg} ({uMsg})");
			gotMsg = true;
			return false;
		}
	}

	private IntPtr DlgProc(HWND hwndDlg, uint uMsg, IntPtr wParam, IntPtr lParam)
	{
		if (EnumExtensions.IsValid((WindowMessage)uMsg))
			System.Diagnostics.Debug.WriteLine((WindowMessage)uMsg);
		else
			System.Diagnostics.Debug.WriteLine($"Msg: 0x{uMsg:X}");

		if (uMsg == (uint)WindowMessage.WM_COMMAND && wParam.ToInt32() == (int)MB_RESULT.IDOK || uMsg == (uint)WindowMessage.WM_CLOSE)
		{
			EndDialog(hwndDlg, (IntPtr)(int)MB_RESULT.IDOK);
		}
		return IntPtr.Zero;
	}
}