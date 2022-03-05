using System;
using Vanara.Extensions;
using Vanara.PInvoke;

using static Vanara.PInvoke.Shell32;

namespace Vanara.Windows.Shell.TaskBar
{
	/// <summary>Provides information about and some control of the system taskbar.</summary>
	public static class Taskbar
	{
		private static bool autoHide, alwaysTop;
		private static ABE edge;
		private static HWND hwnd;
		private static readonly Lazy<bool> isMinWin7 = new(() => PInvokeClientExtensions.IsPlatformSupported(PInvokeClient.Windows7));
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

		private static void GetPos()
		{
			APPBARDATA abd = new(default);
			Win32Error.ThrowLastErrorIf(SHAppBarMessage(ABM.ABM_GETTASKBARPOS, ref abd), r => r == IntPtr.Zero);
			rect = abd.rc;
			edge = abd.uEdge;
			hwnd = abd.hWnd == default ? User32.FindWindowEx(default, default, "Shell_TrayWnd", null) : abd.hWnd;
		}

		private static void GetState()
		{
			APPBARDATA abd = new(default);
			ABS state = (ABS)SHAppBarMessage(ABM.ABM_GETSTATE, ref abd).ToInt32();
			autoHide = state.IsFlagSet(ABS.ABS_AUTOHIDE);
			alwaysTop = isMinWin7.Value || state.IsFlagSet(ABS.ABS_ALWAYSONTOP);
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
}