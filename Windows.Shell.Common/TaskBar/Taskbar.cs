using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using Vanara.Extensions;
using Vanara.InteropServices;
using Vanara.PInvoke;
using static Vanara.PInvoke.ComCtl32;
using static Vanara.PInvoke.Shell32;
using static Vanara.PInvoke.User32;

namespace Vanara.Windows.Shell.TaskBar;

/// <summary>Provides information about and some control of the system taskbar.</summary>
public static class Taskbar
{
	private const string NotifyWndClass = "TrayNotifyWnd";
	private const string PagerWndClass = "SysPager";
	private const string TaskbarWndClass = "Shell_TrayWnd";
	private const string ToolbarWndClass = "ToolbarWindow32";

	private static readonly Lazy<bool> isMinWin7 = new(() => PInvokeClientExtensions.IsPlatformSupported(PInvokeClient.Windows7));
	private static bool autoHide, alwaysTop;
	private static ABE edge;
	private static HWND hwnd;
	private static RECT rect;

	/// <summary>
	/// Gets or sets a value indicating whether the taskbar is always on top. This value is always true for systems since Windows 7.
	/// </summary>
	/// <value><see langword="true"/> if always on top; otherwise, <see langword="false"/>.</value>
	public static bool AlwaysOnTop
	{
		get { GetState(); return alwaysTop; }
		set
		{
			if (!isMinWin7.Value)
			{
				GetState();
				if (alwaysTop != value)
				{
					alwaysTop = value;
					SetState();
				}
			}
			else
				throw new PlatformNotSupportedException();
		}
	}

	/// <summary>Gets or sets a value indicating whether the taskbar is configured to automatically hide itself when not used.</summary>
	/// <value><see langword="true"/> if automatically hidden; otherwise, <see langword="false"/>.</value>
	public static bool AutoHide
	{
		get { GetState(); return autoHide; }
		set { GetState(); if (autoHide != value) { autoHide = value; SetState(); } }
	}

	/// <summary>Gets the bounds of the taskbar.</summary>
	/// <value>The bounds.</value>
	public static RECT Bounds
	{
		get { GetPos(); return rect; }
		//set { GetPos(); if (rect != value) { rect = value; SetPos(); } }
	}

	/// <summary>Gets a value that determines on which edge of the screen the taskbar is displayed.</summary>
	/// <value>The screen edge.</value>
	public static ABE Edge
	{
		get { GetPos(); return edge; }
		//set { GetPos(); if (edge != value) { edge = value; SetPos(); } }
	}

	/// <summary>Gets the window handle of the System Taskbar.</summary>
	/// <value>The window handle.</value>
	public static HWND Handle
	{
		get { GetPos(); return hwnd; }
	}

	/// <summary>Gets the tray icons.</summary>
	/// <value>The tray icons.</value>
	public static IEnumerable<TrayIcon> TrayIcons
	{
		get
		{
			const TBIF bif = TBIF.TBIF_BYINDEX | TBIF.TBIF_COMMAND | TBIF.TBIF_SIZE | TBIF.TBIF_STATE | TBIF.TBIF_STYLE | TBIF.TBIF_TEXT;

			var hwnd = GetTrayWindow();
			if (hwnd.IsNull) yield break;

			using SafeCoTaskMemString strBuf = new(512);
			TBBUTTONINFO defBI = new() { cbSize = (uint)Marshal.SizeOf(typeof(TBBUTTONINFO)), dwMask = bif, pszText = strBuf, cchText = strBuf.Capacity };

			var cnt = SendMessage(hwnd, ToolbarMessage.TB_BUTTONCOUNT).ToInt32();
			var badRes = new IntPtr(-1);
			for (int i = 0; i < cnt; i++)
			{
				TBBUTTONINFO btnInf = defBI;
				btnInf.cchText = strBuf.Capacity;
				strBuf[0] = '\0';
				Win32Error.ThrowLastErrorIf(SendMessage(hwnd, ToolbarMessage.TB_GETBUTTONINFOW, (IntPtr)i, ref btnInf), p => p == badRes);
				yield return new(btnInf);
			}
		}
	}

	/// <summary>Broadcasts the "TaskbarCreated" message to all windows. This is generally used to refresh the taskbar icons.</summary>
	public static void BroadcastTaskbarCreated()
	{
		var msg = Win32Error.ThrowLastErrorIf(RegisterWindowMessage("TaskbarCreated"), i => i == 0);
		Win32Error.ThrowLastErrorIfFalse(SendNotifyMessage(HWND.HWND_BROADCAST, msg));
	}

	private static void GetPos()
	{
		APPBARDATA abd = new(default);
		Win32Error.ThrowLastErrorIf(SHAppBarMessage(ABM.ABM_GETTASKBARPOS, ref abd), r => r == IntPtr.Zero);
		rect = abd.rc;
		edge = abd.uEdge;
		hwnd = abd.hWnd == default ? User32.FindWindowEx(default, default, TaskbarWndClass, null) : abd.hWnd;
	}

	private static void GetState()
	{
		APPBARDATA abd = new(default);
		ABS state = (ABS)SHAppBarMessage(ABM.ABM_GETSTATE, ref abd).ToInt32();
		autoHide = state.IsFlagSet(ABS.ABS_AUTOHIDE);
		alwaysTop = isMinWin7.Value || state.IsFlagSet(ABS.ABS_ALWAYSONTOP);
	}

	private static HWND GetTrayWindow()
	{
		HWND hwnd = FindWindow(TaskbarWndClass, "");
		if (!hwnd.IsNull)
		{
			hwnd = FindWindowEx(hwnd, default, NotifyWndClass, "");
			if (!hwnd.IsNull)
			{
				hwnd = FindWindowEx(hwnd, default, PagerWndClass, "");
				if (!hwnd.IsNull)
				{
					return FindWindowEx(hwnd, default, ToolbarWndClass, null);
				}
			}
		}
		return hwnd;
	}

	private static void SetPos()
	{
		APPBARDATA abd = new(hwnd, 0, edge, rect);
		SHAppBarMessage(ABM.ABM_SETPOS, ref abd);
	}

	private static void SetState()
	{
		if (hwnd == default)
		{
			GetPos();
		}

		APPBARDATA abd = new(hwnd, lParam: (int)((autoHide ? ABS.ABS_AUTOHIDE : 0) | (alwaysTop ? ABS.ABS_ALWAYSONTOP : 0)));
		SHAppBarMessage(ABM.ABM_SETSTATE, ref abd);
	}
}

/// <summary></summary>
public class TrayIcon
{
	internal TrayIcon(in TBBUTTONINFO inf)
	{
		CommandId = inf.idCommand;
		ImageIdx = inf.iImage;
		State = inf.fsState;
		Style = inf.fsStyle;
		Width = inf.cx;
		Text = StringHelper.GetString(inf.pszText, CharSet.Unicode, inf.cchText);
	}

	/// <summary>Command identifier of the button.</summary>
	public int CommandId { get; }

	/// <summary>Image index of the button.</summary>
	public int ImageIdx { get; }

	/// <summary>State flags of the button. This can be one or more of the values listed in Toolbar Button States.</summary>
	public TBSTATE State { get; }

	/// <summary>Style flags of the button. This can be one or more of the values listed in Toolbar Control and Button Styles.</summary>
	public ToolbarStyle Style { get; }

	/// <summary>Address of a character buffer that contains or receives the button text.</summary>
	public string Text { get; }

	/// <summary>Width of the button, in pixels.</summary>
	public ushort Width { get; }
}