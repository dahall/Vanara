using System;
using System.Runtime.InteropServices;
// ReSharper disable FieldCanBeMadeReadOnly.Global

// ReSharper disable InconsistentNaming

namespace Vanara.PInvoke
{
	public static partial class ComCtl32
	{
		public const int ECM_FIRST = 0x1500;

		public enum EditMessage
		{
			EM_GETSEL              = 0x00B0,
			EM_SETSEL              = 0x00B1,
			EM_GETRECT             = 0x00B2,
			EM_SETRECT             = 0x00B3,
			EM_SETRECTNP           = 0x00B4,
			EM_SCROLL              = 0x00B5,
			EM_LINESCROLL          = 0x00B6,
			EM_SCROLLCARET         = 0x00B7,
			EM_GETMODIFY           = 0x00B8,
			EM_SETMODIFY           = 0x00B9,
			EM_GETLINECOUNT        = 0x00BA,
			EM_LINEINDEX           = 0x00BB,
			EM_SETHANDLE           = 0x00BC,
			EM_GETHANDLE           = 0x00BD,
			EM_GETTHUMB            = 0x00BE,
			EM_LINELENGTH          = 0x00C1,
			EM_REPLACESEL          = 0x00C2,
			EM_GETLINE             = 0x00C4,
			EM_LIMITTEXT           = 0x00C5,
			EM_CANUNDO             = 0x00C6,
			EM_UNDO                = 0x00C7,
			EM_FMTLINES            = 0x00C8,
			EM_LINEFROMCHAR        = 0x00C9,
			EM_SETTABSTOPS         = 0x00CB,
			EM_SETPASSWORDCHAR     = 0x00CC,
			EM_EMPTYUNDOBUFFER     = 0x00CD,
			EM_GETFIRSTVISIBLELINE = 0x00CE,
			EM_SETREADONLY         = 0x00CF,
			EM_SETWORDBREAKPROC    = 0x00D0,
			EM_GETWORDBREAKPROC    = 0x00D1,
			EM_GETPASSWORDCHAR     = 0x00D2,
			EM_SETMARGINS          = 0x00D3,
			EM_GETMARGINS          = 0x00D4,
			EM_SETLIMITTEXT        = EM_LIMITTEXT,   /* ;win40 Name change */
			EM_GETLIMITTEXT        = 0x00D5,
			EM_POSFROMCHAR         = 0x00D6,
			EM_CHARFROMPOS         = 0x00D7,
			EM_SETIMESTATUS        = 0x00D8,
			EM_GETIMESTATUS        = 0x00D9,
			EM_ENABLEFEATURE       = 0x00DA,
			EM_SETCUEBANNER        = ECM_FIRST + 1,     // Set the cue banner with the lParm = LPCWSTR
			EM_GETCUEBANNER        = ECM_FIRST + 2,     // Set the cue banner with the lParm = LPCWSTR
			EM_SHOWBALLOONTIP      = ECM_FIRST + 3,     // Show a balloon tip associated to the edit control
			EM_HIDEBALLOONTIP      = ECM_FIRST + 4,     // Hide any balloon tip associated with the edit control
			//EM_SETHILITE           = ECM_FIRST + 5,
			//EM_GETHILITE           = ECM_FIRST + 6,
			EM_NOSETFOCUS          = ECM_FIRST + 7,
			EM_TAKEFOCUS           = ECM_FIRST + 8,
		}

		public enum EditNotification
		{
			EN_SETFOCUS = 0x0100,
			EN_KILLFOCUS = 0x0200,
			EN_CHANGE = 0x0300,
			EN_UPDATE = 0x0400,
			EN_ERRSPACE = 0x0500,
			EN_MAXTEXT = 0x0501,
			EN_HSCROLL = 0x0601,
			EN_VSCROLL = 0x0602,
			EN_ALIGN_LTR_EC = 0x0700,
			EN_ALIGN_RTL_EC = 0x0701,
			EN_BEFORE_PASTE = 0x0800,
			EN_AFTER_PASTE = 0x0801,
		}

		/// <summary>
		/// Contains information about a balloon tip associated with a button control.
		/// </summary>
		[PInvokeData("Commctrl.h", MSDNShortId = "bb775466")]
		[StructLayout(LayoutKind.Sequential)]
		public struct EDITBALLOONTIP
		{
			/// <summary>
			/// A DWORD that contains the size, in bytes, of the structure.
			/// </summary>
			public int cbStruct;
			/// <summary>
			/// A pointer to a Unicode string that contains the title of the balloon tip.
			/// </summary>
			[MarshalAs(UnmanagedType.LPWStr)] public string pszTitle;
			/// <summary>
			/// A pointer to a Unicode string that contains the balloon tip text.
			/// </summary>
			[MarshalAs(UnmanagedType.LPWStr)] public string pszText;
			/// <summary>
			/// A value of type INT that specifies the type of icon to associate with the balloon tip.
			/// </summary>
			public ToolTipIcon ttiIcon;

			/// <summary>
			/// Initializes a new instance of the <see cref="EDITBALLOONTIP"/> struct.
			/// </summary>
			/// <param name="title">The title.</param>
			/// <param name="text">The text.</param>
			/// <param name="icon">The icon.</param>
			public EDITBALLOONTIP(string title, string text, ToolTipIcon icon = ToolTipIcon.TTI_NONE)
			{
				cbStruct = Marshal.SizeOf(typeof(EDITBALLOONTIP));
				pszText = text;
				pszTitle = title;
				ttiIcon = icon;
			}
		}

		/// <summary>
		/// Sends the specified message to a window or windows. The SendMessage function calls the window procedure for the specified window and does not return until the window procedure has processed the message.
		/// </summary>
		/// <param name="hWnd">A handle to the window whose window procedure will receive the message. If this parameter is HWND_BROADCAST ((HWND)0xffff), the message is sent to all top-level windows in the system, including disabled or invisible unowned windows, overlapped windows, and pop-up windows; but the message is not sent to child windows.</param>
		/// <param name="Msg">The message to be sent.</param>
		/// <param name="wParam">Additional message-specific information.</param>
		/// <param name="balloonTip">Additional message-specific information.</param>
		/// <returns>The return value specifies the result of the message processing; it depends on the message sent.</returns>
		public static IntPtr SendMessage(HandleRef hWnd, EditMessage Msg, int wParam, ref EDITBALLOONTIP balloonTip) => User32_Gdi.SendMessage(hWnd, Msg, wParam, ref balloonTip);
	}
}