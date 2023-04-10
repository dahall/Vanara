using ICSharpCode.Decompiler.IL;
using NUnit.Framework;
using System;
using System.Linq;
using System.Reflection;
using System.Runtime.InteropServices;
using System.Text;
using Vanara.Extensions;
using Vanara.InteropServices;
using static Vanara.PInvoke.Kernel32;
using static Vanara.PInvoke.User32;

namespace Vanara.PInvoke.Tests;

[TestFixture()]
public partial class User32Tests
{
	[Test]
	public void WindowClassCtorTest()
	{
		WindowClass wc = null;

		Assert.DoesNotThrow(() => wc = new());
		Assert.AreEqual(wc.wc.hInstance, HINSTANCE.NULL);
		Assert.True(wc.Unregister());

		Assert.DoesNotThrow(() => wc = new("MyCustomName"));
		Assert.AreEqual(wc.ClassName, "MyCustomName");
		Assert.True(wc.Unregister());

		Assert.DoesNotThrow(() => wc = WindowClass.MakeVisibleWindowClass("MyWindowClass", DefWindowProc));
		Assert.AreEqual(wc.ClassName, "MyWindowClass");
		Assert.AreEqual(wc.wc.hInstance, (HINSTANCE)GetModuleHandle());
		Assert.AreNotEqual(wc.wc.hIcon, HICON.NULL);
		Assert.AreNotEqual(wc.wc.hCursor, HCURSOR.NULL);
		Assert.AreNotEqual(wc.wc.hbrBackground, HBRUSH.NULL);
	}

	[Test]
	public void WindowClassCreateWinTest()
	{
		var _wndProc = new WindowProc(WndProc);
		var _gcHandle = GCHandle.Alloc(_wndProc);
		var windowClass = new WindowClass(null, HINSTANCE.NULL, _wndProc, hbrBkgd: HBRUSH.NULL);
		var exStyles = WindowStylesEx.WS_EX_LAYERED | WindowStylesEx.WS_EX_NOACTIVATE | WindowStylesEx.WS_EX_TRANSPARENT | WindowStylesEx.WS_EX_NOREDIRECTIONBITMAP;
		var styles = WindowStyles.WS_CLIPCHILDREN | WindowStyles.WS_POPUP | WindowStyles.WS_CLIPSIBLINGS;
		Assert.That(CreateWindowEx(exStyles, windowClass.ClassName, "Test Window", styles), ResultIs.ValidHandle);
	}

	private static IntPtr WndProc(HWND hwnd, uint uMsg, IntPtr wParam, IntPtr lParam) => DefWindowProc(hwnd, uMsg, wParam, lParam);

	[Test]
	public void WindowClassCreateTest()
	{
		using BasicMessageWindow wnd = new();

		WindowClass wc3 = null;
		Assert.NotNull(wc3 = WindowClass.GetNamedInstance(wnd.ClassName, GetModuleHandle()));
		Assert.AreEqual(wnd.ClassName, wc3.ClassName);

		WindowClass wc = null;
		Assert.NotNull(wc = WindowClass.GetInstanceFromWindow(wnd.Handle));
		Assert.AreEqual(wc.ClassName, wnd.ClassName);
	}

	[Test]
	public void WindowCreateTest()
	{
		bool created = false;
		using WindowBase wnd = new();
		wnd.Created += () => created = true;
		wnd.CreateHandle(null, parent: HWND.HWND_MESSAGE);
		Assert.NotNull(wnd.ClassName);
		Assert.IsTrue(created);
		Assert.AreNotEqual(wnd.Handle, HWND.NULL);
	}

	[Test]
	public void WindowPumpTest()
	{
		VisibleWindow.Run(WndProc, "Hello");

		static IntPtr WndProc(HWND hwnd, uint msg, IntPtr wParam, IntPtr lParam)
		{
			System.Diagnostics.Debug.WriteLine($"TestWndProc={(WindowMessage)msg} (WrapperTests.cs)");
			if (msg == (uint)WindowMessage.WM_CREATE) MessageBox(hwnd, "Got it!");
			return DefWindowProc(hwnd, msg, wParam, lParam);
		}
	}

	[Test]
	public void WindowRunTest()
	{
		VisibleWindow.Run<MyWin>(null, "Hello");
	}

	public class MyWin : VisibleWindow
	{
		protected override IntPtr WndProc(HWND hwnd, uint msg, IntPtr wParam, IntPtr lParam)
		{
			if (msg == (uint)WindowMessage.WM_CREATE) MessageBox(hwnd, "Got it!");
			return base.WndProc(hwnd, msg, wParam, lParam);
		}
	}
}