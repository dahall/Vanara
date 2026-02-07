using NUnit.Framework;
using static Vanara.PInvoke.Kernel32;
using static Vanara.PInvoke.User32;

namespace Vanara.PInvoke.Tests;

[TestFixture()]
public partial class User32Tests
{
	private static readonly Lazy<bool> IsWide = new(() => StringHelper.GetCharSize() == 2);
	private const string caption = "Hello, World!";
	private const int captionLen = 13;

	[Test]
	public void WindowClassCtorTest()
	{
		WindowClass? wc = null;

		Assert.DoesNotThrow(() => wc = new());
		Assert.That(wc!.wc.hInstance, Is.EqualTo((HINSTANCE)GetModuleHandle()));
		Assert.That(wc.Unregister());

		Assert.DoesNotThrow(() => wc = new("MyCustomName"));
		Assert.That(GetClassInfoEx(wc.wc.hInstance, wc.ClassName, out var wcex));
		Assert.That(wcex.lpszClassName, Is.EqualTo("MyCustomName"));
		Assert.That(wc.Unregister());

		Assert.DoesNotThrow(() => wc = WindowClass.MakeVisibleWindowClass("MyWindowClass", DefWindowProc));
		Assert.That(GetClassInfoEx(wc.wc.hInstance, wc.ClassName, out wcex));
		Assert.That(wcex.lpszClassName, Is.EqualTo("MyWindowClass"));
		Assert.That(wcex.hIcon, Is.Not.EqualTo(HICON.NULL));
		Assert.That(wcex.hCursor, Is.Not.EqualTo(HCURSOR.NULL));
		Assert.That(wcex.hbrBackground, Is.Not.EqualTo(HBRUSH.NULL));
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
		HWND h = HWND.NULL;
		using WindowBase wnd = new();
		wnd.Created += () => h = wnd.Handle;
		wnd.CreateHandle(null, caption, style: WindowStyles.WS_OVERLAPPED);
		Assert.That(wnd.ClassName, Is.Not.Null);
		Assert.That(h.IsInvalid, Is.False);
		Assert.That(h, Is.EqualTo(wnd.Handle));
		Assert.That(wnd.Handle, Is.Not.EqualTo(HWND.NULL));
		Assert.That(IsWindowUnicode(wnd.Handle), Is.EqualTo(IsWide.Value));
		Assert.That(wnd.Text, Is.EqualTo(caption));
		Assert.That(GetWindowTextLength(wnd.Handle), Is.EqualTo(captionLen));
		Assert.That(SetWindowText(wnd.Handle, null));
		Assert.That(GetWindowTextLength(wnd.Handle), Is.Zero);
		Assert.That(wnd.Text, Is.Empty);
	}

	[Test]
	public void VisibleWindowRunTest()
	{
		VisibleWindow.Run(WndProc, caption);
	}

	[Test]
	public void VisibleWindowRunWithAccelTest()
	{
		Accelerator[] a = [new(1001, VK.VK_F2), new(1002, VK.VK_F3), new(1003, 0x4D, ConsoleModifiers.Control)];
		VisibleWindow.Run(WndProc, caption, hAccl: a.CreateHandle());
	}

	static IntPtr WndProc(HWND hwnd, uint msg, IntPtr wParam, IntPtr lParam)
	{
		System.Diagnostics.Debug.WriteLine($"TestWndProc={(WindowMessage)msg} (WrapperTests.cs)");
		if (msg == (uint)WindowMessage.WM_COMMAND) MessageBox(hwnd, $"Got command {Macros.LOWORD(wParam)}");
		return DefWindowProc(hwnd, msg, wParam, lParam);
	}

	[Test]
	public void WindowRunTest() => VisibleWindow.Run<MyWin>(caption);

	public class MyWin : VisibleWindow
	{
		protected override IntPtr WndProc(HWND hwnd, uint msg, IntPtr wParam, IntPtr lParam)
		{
			System.Diagnostics.Debug.WriteLine($"MyWndProc={(WindowMessage)msg} (WrapperTests.cs)");
			return base.WndProc(hwnd, msg, wParam, lParam);
		}
	}
}