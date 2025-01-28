using NUnit.Framework;
using static Vanara.PInvoke.Kernel32;
using static Vanara.PInvoke.User32;

namespace Vanara.PInvoke.Tests;

[TestFixture()]
public partial class User32Tests
{
	[Test]
	public void WindowClassCtorTest()
	{
		WindowClass? wc = null;

		Assert.DoesNotThrow(() => wc = new());
		Assert.That(wc!.wc.hInstance, Is.EqualTo((HINSTANCE)GetModuleHandle()));
		Assert.That(wc.Unregister());

		Assert.DoesNotThrow(() => wc = new("MyCustomName"));
		Assert.That(wc.ClassName, Is.EqualTo("MyCustomName"));
		Assert.That(wc.Unregister());

		Assert.DoesNotThrow(() => wc = WindowClass.MakeVisibleWindowClass("MyWindowClass", DefWindowProc));
		Assert.That(wc.ClassName, Is.EqualTo("MyWindowClass"));
		Assert.That(wc.wc.hIcon, Is.Not.EqualTo(HICON.NULL));
		Assert.That(wc.wc.hCursor, Is.Not.EqualTo(HCURSOR.NULL));
		Assert.That(wc.wc.hbrBackground, Is.Not.EqualTo(HBRUSH.NULL));
	}

	[Test]
	public void WindowClassCreateTest()
	{
		using BasicMessageWindow wnd = new();

		WindowClass? wc3 = null;
		Assert.That(wc3 = WindowClass.GetNamedInstance(wnd!.ClassName!, GetModuleHandle()), Is.Not.Null);
		Assert.That(wnd.ClassName, Is.EqualTo(wc3!.ClassName));

		WindowClass? wc = null;
		Assert.That(wc = WindowClass.GetInstanceFromWindow(wnd.Handle), Is.Not.Null);
		Assert.That(wc!.ClassName, Is.EqualTo(wnd.ClassName));
	}

	[Test]
	public void WindowCreateTest()
	{
		bool created = false;
		using WindowBase wnd = new();
		wnd.Created += () => created = true;
		wnd.CreateHandle(null, parent: HWND.HWND_MESSAGE);
		Assert.That(wnd.ClassName, Is.Not.Null);
		Assert.That(created);
		Assert.That(wnd.Handle, Is.Not.EqualTo(HWND.NULL));
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
	public void WindowRunTest() => VisibleWindow.Run<MyWin>("Hello");

	public class MyWin : VisibleWindow
	{
		protected override IntPtr WndProc(HWND hwnd, uint msg, IntPtr wParam, IntPtr lParam)
		{
			if (msg == (uint)WindowMessage.WM_CREATE) MessageBox(hwnd, "Got it!");
			return base.WndProc(hwnd, msg, wParam, lParam);
		}
	}
}