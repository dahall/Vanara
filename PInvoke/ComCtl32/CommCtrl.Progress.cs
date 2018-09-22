using System;
using System.Runtime.InteropServices;
using static Vanara.PInvoke.User32_Gdi;

// ReSharper disable InconsistentNaming

namespace Vanara.PInvoke
{
	public static partial class ComCtl32
	{
		public enum ProgressMessage
		{
			PBM_SETRANGE    = WindowMessage.WM_USER+1,
			PBM_SETPOS      = WindowMessage.WM_USER+2,
			PBM_DELTAPOS    = WindowMessage.WM_USER+3,
			PBM_SETSTEP     = WindowMessage.WM_USER+4,
			PBM_STEPIT      = WindowMessage.WM_USER+5,
			PBM_SETRANGE32  = WindowMessage.WM_USER+6,  // lParam = high, wParam = low
			PBM_GETRANGE    = WindowMessage.WM_USER+7,  // wParam = return (TRUE ? low : high). lParam = PPBRANGE or NULL
			PBM_GETPOS      = WindowMessage.WM_USER+8,
			PBM_SETBARCOLOR = WindowMessage.WM_USER+9,  // lParam = bar color
			PBM_SETBKCOLOR  = CommonControlMessage.CCM_SETBKCOLOR,  // lParam = bkColor
			PBM_SETMARQUEE  = WindowMessage.WM_USER+10,
			PBM_GETSTEP     = WindowMessage.WM_USER+13,
			PBM_GETBKCOLOR  = WindowMessage.WM_USER+14,
			PBM_GETBARCOLOR = WindowMessage.WM_USER+15,
			PBM_SETSTATE    = WindowMessage.WM_USER+16, // wParam = PBST_[State] (NORMAL, ERROR, PAUSED)
			PBM_GETSTATE    = WindowMessage.WM_USER+17,
		}

		/// <summary>State of the progress bar used in PBM_SETSTATE and PBM_GETSTATE messages.</summary>
		[PInvokeData("Commctrl.h", MSDNShortId = "bb760850")]
		public enum ProgressState
		{
			/// <summary>In progress</summary>
			PBST_NORMAL = 0x0001,
			/// <summary>Error.</summary>
			PBST_ERROR = 0x0002,
			/// <summary>Paused.</summary>
			PBST_PAUSED = 0x0003,
		}

		/// <summary>The following control styles are supported by Progress Bar controls:</summary>
		[PInvokeData("Commctrl.h", MSDNShortId = "bb760820")]
		[Flags]
		public enum ProgressStyle
		{
			/// <summary>Version 4.70 or later. The progress bar displays progress status in a smooth scrolling bar instead of the default segmented bar.
			/// <note type="note">This style is supported only in the Windows Classic theme. All other themes override this style.</note></summary>
			PBS_SMOOTH = 0x01,
			/// <summary>Version 4.70 or later. The progress bar displays progress status vertically, from bottom to top.</summary>
			PBS_VERTICAL = 0x04,
			/// <summary>Version 6.0 or later. The progress indicator does not grow in size but instead moves repeatedly along the length of the bar, indicating activity without specifying what proportion of the progress is complete.
			/// <note type="note">Comctl32.dll version 6 is not redistributable but it is included in Windows or later. To use Comctl32.dll version 6, specify it in a manifest. For more information on manifests, see Enabling Visual Styles.</note></summary>
			PBS_MARQUEE = 0x08,
			/// <summary>Version 6.0 or later and Windows Vista. Determines the animation behavior that the progress bar should use when moving backward (from a higher value to a lower value). If this is set, then a "smooth" transition will occur, otherwise the control will "jump" to the lower value.</summary>
			PBS_SMOOTHREVERSE = 0x10,
		}

		/// <summary>Contains information about the high and low limits of a progress bar control. This structure is used with the PBM_GETRANGE message.</summary>
		[PInvokeData("Commctrl.h", MSDNShortId = "bb760822")]
		[StructLayout(LayoutKind.Sequential)]
		public struct PBRANGE
		{
			/// <summary>Low limit for the progress bar control. This is a signed integer.</summary>
			public int iLow;
			/// <summary>High limit for the progress bar control. This is a signed integer.</summary>
			public int iHigh;
		}

		/// <summary>
		/// Sends the specified message to a window or windows. The SendMessage function calls the window procedure for the specified window and does not return until the window procedure has processed the message.
		/// </summary>
		/// <param name="hWnd">A handle to the window whose window procedure will receive the message. If this parameter is HWND_BROADCAST ((HWND)0xffff), the message is sent to all top-level windows in the system, including disabled or invisible unowned windows, overlapped windows, and pop-up windows; but the message is not sent to child windows.</param>
		/// <param name="Msg">The message to be sent.</param>
		/// <param name="wParam">Additional message-specific information.</param>
		/// <param name="progressRange">Additional message-specific information.</param>
		/// <returns>The return value specifies the result of the message processing; it depends on the message sent.</returns>
		public static IntPtr SendMessage(HWND hWnd, ProgressMessage Msg, bool wParam, ref PBRANGE progressRange) => User32_Gdi.SendMessage(hWnd, Msg, wParam, ref progressRange);
	}
}