﻿using NUnit.Framework;
using static Vanara.PInvoke.Kernel32;
using static Vanara.PInvoke.User32;

namespace Vanara.PInvoke.Tests;

[TestFixture()]
public partial class User32Tests
{
	private static readonly Lazy<bool> IsWide = new(() => StringHelper.GetCharSize() == 2);
	private const string caption = "Hello, World!\0";
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
		bool created = false;
		using WindowBase wnd = new();
		wnd.Created += () => created = true;
		wnd.CreateHandle(null, caption, style: WindowStyles.WS_OVERLAPPED);
		Assert.That(wnd.ClassName, Is.Not.Null);
		Assert.That(created);
		Assert.That(wnd.Handle, Is.Not.EqualTo(HWND.NULL));
		Assert.That(IsWindowUnicode(wnd.Handle), Is.EqualTo(IsWide.Value));
		Assert.That(GetWindowTextLength(wnd.Handle), Is.EqualTo(captionLen));
		Assert.That(SetWindowText(wnd.Handle, null));
		Assert.That(GetWindowTextLength(wnd.Handle), Is.Zero);
	}

	[Test]
	public void WindowPumpTest()
	{
		VisibleWindow.Run(WndProc, caption);

		static IntPtr WndProc(HWND hwnd, uint msg, IntPtr wParam, IntPtr lParam)
		{
			System.Diagnostics.Debug.WriteLine($"TestWndProc={(WindowMessage)msg} (WrapperTests.cs)");
			if (msg == (uint)WindowMessage.WM_CREATE) MessageBox(hwnd, "Got it!");
			return DefWindowProc(hwnd, msg, wParam, lParam);
		}
	}

	[Test]
	public void WindowRunTest() => VisibleWindow.Run<MyWin>(caption);

	public class MyWin : VisibleWindow
	{
		protected override IntPtr WndProc(HWND hwnd, uint msg, IntPtr wParam, IntPtr lParam)
		{
			//if (msg == (uint)WindowMessage.WM_CREATE) MessageBox(hwnd, "Got it!");
			return base.WndProc(hwnd, msg, wParam, lParam);
		}
	}
}