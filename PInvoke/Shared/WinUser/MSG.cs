﻿namespace Vanara.PInvoke;

/// <summary>Contains message information from a thread's message queue.</summary>
/// <remarks>Initializes a new instance of the <see cref="MSG"/> struct.</remarks>
/// <param name="hwnd">
/// A handle to the window whose window procedure receives the message. This member is NULL when the message is a thread message.
/// </param>
/// <param name="msg">The message identifier. Applications can only use the low word; the high word is reserved by the system.</param>
/// <param name="wParam">Additional information about the message. The exact meaning depends on the value of the message member.</param>
/// <param name="lParam">Additional information about the message. The exact meaning depends on the value of the message member.</param>
/// <param name="pt">The cursor position, in screen coordinates, when the message was posted.</param>
/// <param name="time">The time at which the message was posted.</param>
// https://docs.microsoft.com/en-us/windows/win32/api/winuser/ns-winuser-msg typedef struct tagMSG { HWND hwnd; UINT message; WPARAM
// wParam; LPARAM lParam; DWORD time; POINT pt; DWORD lPrivate; } MSG, *PMSG, *NPMSG, *LPMSG;
[PInvokeData("winuser.h", MSDNShortId = "NS:winuser.tagMSG")]
[StructLayout(LayoutKind.Sequential)]
public struct MSG(HWND hwnd, uint msg, IntPtr wParam, IntPtr lParam, POINT pt = default, uint time = default)
{
	/// <summary>
	/// A handle to the window whose window procedure receives the message. This member is NULL when the message is a thread message.
	/// </summary>
	public HWND hwnd = hwnd;

	/// <summary>The message identifier. Applications can only use the low word; the high word is reserved by the system.</summary>
	public uint message = msg;

	/// <summary>Additional information about the message. The exact meaning depends on the value of the message member.</summary>
	public IntPtr wParam = wParam;

	/// <summary>Additional information about the message. The exact meaning depends on the value of the message member.</summary>
	public IntPtr lParam = lParam;

	/// <summary>The time at which the message was posted.</summary>
	public uint time = time;

	/// <summary>The cursor position, in screen coordinates, when the message was posted.</summary>
	public POINT pt = pt;

	/// <summary>The horizontal cursor position, in screen coordinates, when the message was posted.</summary>
	public int pt_x { get => pt.X; set => pt.X = value; }

	/// <summary>The vertical cursor position, in screen coordinates, when the message was posted.</summary>
	public int pt_y { get => pt.Y; set => pt.Y = value; }

	/// <summary>Initializes a new instance of the <see cref="MSG"/> struct.</summary>
	/// <param name="hwnd">
	/// A handle to the window whose window procedure receives the message. This member is NULL when the message is a thread message.
	/// </param>
	/// <param name="msg">The message identifier. Applications can only use the low word; the high word is reserved by the system.</param>
	/// <param name="wParam">Additional information about the message. The exact meaning depends on the value of the message member.</param>
	/// <param name="lParam">Additional information about the message. The exact meaning depends on the value of the message member.</param>
	/// <param name="pt_x">The horizontal cursor position, in screen coordinates, when the message was posted.</param>
	/// <param name="pt_y">The vertical cursor position, in screen coordinates, when the message was posted.</param>
	/// <param name="time">The time at which the message was posted.</param>
	public MSG(HWND hwnd, uint msg, IntPtr wParam, IntPtr lParam, int pt_x, int pt_y, uint time = default) :
		this(hwnd, msg, wParam, lParam, new POINT(pt_x, pt_y), time) { }
}