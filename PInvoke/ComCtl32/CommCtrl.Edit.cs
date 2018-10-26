using System;
using System.Runtime.InteropServices;

namespace Vanara.PInvoke
{
	public static partial class ComCtl32
	{
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
		[DllImport(Lib.User32, SetLastError = false, CharSet = CharSet.Auto)]
		public static extern IntPtr SendMessage(HWND hWnd, User32_Gdi.EditMessage Msg, int wParam, ref EDITBALLOONTIP balloonTip);
	}
}