using NUnit.Framework;
using System;
using System.Linq;
using System.Reflection;
using System.Runtime.InteropServices;
using System.Text;
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
		Assert.AreEqual(wc.wc.hInstance, (HINSTANCE)GetModuleHandle());
		Assert.True(wc.Unregister());

		Assert.DoesNotThrow(() => wc = new("MyCustomName"));
		Assert.AreEqual(wc.ClassName, "MyCustomName");
		Assert.True(wc.Unregister());

		Assert.DoesNotThrow(() => wc = WindowClass.MakeVisibleWindowClass("MyWindowClass", DefWindowProc));
		Assert.AreEqual(wc.ClassName, "MyWindowClass");
		Assert.AreNotEqual(wc.wc.hIcon, HICON.NULL);
		Assert.AreNotEqual(wc.wc.hCursor, HCURSOR.NULL);
		Assert.AreNotEqual(wc.wc.hbrBackground, HBRUSH.NULL);
	}

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
		HWND hwnd = default;
		TestWin wnd = new("Hello", new(0, 0, 300, 200));
		wnd.Show();
		new MessagePump().Run(wnd);
		wnd.Dispose();
		Assert.IsFalse(IsWindowVisible(hwnd));
		Assert.IsTrue(wnd.gotMsg);
	}

	private class TestWin : VisibleWindow
	{
		public bool gotMsg = false;

		public TestWin(string text, RECT bounds) : base(null, text, bounds) { }
		protected override IntPtr WndProc(HWND hwnd, uint msg, IntPtr wParam, IntPtr lParam)
		{
			gotMsg = true;
			return base.WndProc(hwnd, msg, wParam, lParam);
		}
	}
}