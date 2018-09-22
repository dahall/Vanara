using System;
using System.Runtime.InteropServices;
using static Vanara.PInvoke.Kernel32;
using static Vanara.PInvoke.User32_Gdi;

// ReSharper disable InconsistentNaming
// ReSharper disable FieldCanBeMadeReadOnly.Global
// ReSharper disable InconsistentNaming

namespace Vanara.PInvoke
{
	public static partial class ComCtl32
	{
		private const int UDN_FIRST = -721;

		/// <summary>Window class for the up-down control.</summary>
		public const string UPDOWN_CLASS = "msctls_updown32";
		/// <summary>Maximum value for an up-down control.</summary>
		public const short UD_MAXVAL = 0x7fff;
		/// <summary>Minimum value for an up-down control.</summary>
		public const short UD_MINVAL = -UD_MAXVAL;

		/// <summary>Window messages for the up-down control.</summary>
		public enum UpDownMessage : uint
		{
			/// <summary>Retrieves acceleration information for an up-down control.</summary>
			UDM_GETACCEL = WindowMessage.WM_USER + 108,
			/// <summary>Retrieves the current radix base (that is, either base 10 or 16) for an up-down control.</summary>
			UDM_GETBASE = WindowMessage.WM_USER + 110,
			/// <summary>Retrieves the handle to the current buddy window.</summary>
			UDM_GETBUDDY = WindowMessage.WM_USER + 106,
			/// <summary>Retrieves the current position of an up-down control with 16-bit precision.</summary>
			UDM_GETPOS = WindowMessage.WM_USER + 104,
			/// <summary>Returns the 32-bit position of an up-down control.</summary>
			UDM_GETPOS32 = WindowMessage.WM_USER + 114,
			/// <summary>Retrieves the minimum and maximum positions (range) for an up-down control.</summary>
			UDM_GETRANGE = WindowMessage.WM_USER + 102,
			/// <summary>Retrieves the 32-bit range of an up-down control.</summary>
			UDM_GETRANGE32 = WindowMessage.WM_USER + 112,
			/// <summary>Retrieves the Unicode character format flag for the control.</summary>
			UDM_GETUNICODEFORMAT = CommonControlMessage.CCM_GETUNICODEFORMAT,
			/// <summary>Sets the acceleration for an up-down control.</summary>
			UDM_SETACCEL = WindowMessage.WM_USER + 107,
			/// <summary>Sets the radix base for an up-down control. The base value determines whether the buddy window displays numbers in decimal or hexadecimal digits. Hexadecimal numbers are always unsigned, and decimal numbers are signed.</summary>
			UDM_SETBASE = WindowMessage.WM_USER + 109,
			/// <summary>Sets the buddy window for an up-down control.</summary>
			UDM_SETBUDDY = WindowMessage.WM_USER + 105,
			/// <summary>Sets the current position for an up-down control with 16-bit precision.</summary>
			UDM_SETPOS = WindowMessage.WM_USER + 103,
			/// <summary>Sets the position of an up-down control with 32-bit precision.</summary>
			UDM_SETPOS32 = WindowMessage.WM_USER + 113,
			/// <summary>Sets the minimum and maximum positions (range) for an up-down control.</summary>
			UDM_SETRANGE = WindowMessage.WM_USER + 101,
			/// <summary>Sets the 32-bit range of an up-down control.</summary>
			UDM_SETRANGE32 = WindowMessage.WM_USER + 111,
			/// <summary>Sets the Unicode character format flag for the control. This message allows you to change the character set used by the control at run time rather than having to re-create the control.</summary>
			UDM_SETUNICODEFORMAT = CommonControlMessage.CCM_SETUNICODEFORMAT,
		}

		/// <summary>Notifications for the up-down control.</summary>
		public enum UpDownNotification : int
		{
			/// <summary>Notifies an up-down control's parent window that the control is releasing mouse capture. This notification is sent in the form of a WM_NOTIFY message.</summary>
			NM_RELEASEDCAPTURE = UDN_FIRST - 1,
			/// <summary>Sent by the operating system to the parent window of an up-down control when the position of the control is about to change.This happens when the user requests a change in the value by pressing the control's up or down arrow. The UDN_DELTAPOS message is sent in the form of a WM_NOTIFY message.</summary>
			UDN_DELTAPOS = UDN_FIRST
		}

		/// <summary>Styles for the up-down control.</summary>
		[Flags]
		public enum UpDownStyle : uint
		{
			/// <summary>Positions the up-down control next to the left edge of the buddy window. The buddy window is moved to the right, and its width is decreased to accommodate the width of the up-down control.</summary>
			UDS_ALIGNLEFT = 0x08,
			/// <summary>Positions the up-down control next to the right edge of the buddy window. The width of the buddy window is decreased to accommodate the width of the up-down control.</summary>
			UDS_ALIGNRIGHT = 0x04,
			/// <summary>Causes the up-down control to increment and decrement the position when the UP ARROW and DOWN ARROW keys are pressed.</summary>
			UDS_ARROWKEYS = 0x20,
			/// <summary>Automatically selects the previous window in the z-order as the up-down control's buddy window.</summary>
			UDS_AUTOBUDDY = 0x10,
			/// <summary>Causes the up-down control's arrows to point left and right instead of up and down.</summary>
			UDS_HORZ = 0x40,
			/// <summary>Causes the control to exhibit "hot tracking" behavior. That is, it highlights the UP ARROW and DOWN ARROW on the control as the pointer passes over them. This style requires Windows 98 or Windows 2000. If the system is running Windows 95 or Windows NT 4.0, the flag is ignored. To check whether hot tracking is enabled, call SystemParametersInfo.</summary>
			UDS_HOTTRACK = 0x100,
			/// <summary>Does not insert a thousands separator between every three decimal digits.</summary>
			UDS_NOTHOUSANDS = 0x80,
			/// <summary>Causes the up-down control to set the text of the buddy window (using the WM_SETTEXT message) when the position changes. The text consists of the position formatted as a decimal or hexadecimal string.</summary>
			UDS_SETBUDDYINT = 0x02,
			/// <summary>Causes the position to "wrap" if it is incremented or decremented beyond the ending or beginning of the range.</summary>
			UDS_WRAP = 0x01,
		}

		/// <summary>Creates an up-down control. Note: This function is obsolete. It is a 16 bit function and cannot handle 32 bit values for range and position.</summary>
		/// <param name="dwStyle">
		/// <para>Type: <c><c>DWORD</c></c></para>
		/// <para>
		/// Window styles for the control. This parameter should include the <c>WS_CHILD</c>, <c>WS_BORDER</c>, and <c>WS_VISIBLE</c> styles, and it may include
		/// any of the window styles specific to the up-down control.
		/// </para>
		/// </param>
		/// <param name="x">
		/// <para>Type: <c>int</c></para>
		/// <para>Horizontal coordinate, in client coordinates, of the upper-left corner of the control.</para>
		/// </param>
		/// <param name="y">
		/// <para>Type: <c>int</c></para>
		/// <para>Vertical coordinate, in client coordinates, of the upper-left corner of the control.</para>
		/// </param>
		/// <param name="cx">
		/// <para>Type: <c>int</c></para>
		/// <para>Width, in pixels, of the up-down control.</para>
		/// </param>
		/// <param name="cy">
		/// <para>Type: <c>int</c></para>
		/// <para>Height, in pixels, of the up-down control.</para>
		/// </param>
		/// <param name="hParent">
		/// <para>Type: <c><c>HWND</c></c></para>
		/// <para>Handle to the parent window of the up-down control.</para>
		/// </param>
		/// <param name="nID">
		/// <para>Type: <c>int</c></para>
		/// <para>Identifier for the up-down control.</para>
		/// </param>
		/// <param name="hInst">
		/// <para>Type: <c><c>HINSTANCE</c></c></para>
		/// <para>Handle to the module instance of the application creating the up-down control.</para>
		/// </param>
		/// <param name="hBuddy">
		/// <para>Type: <c><c>HWND</c></c></para>
		/// <para>Handle to the window associated with the up-down control. If this parameter is <c>NULL</c>, the control has no buddy window.</para>
		/// </param>
		/// <param name="nUpper">
		/// <para>Type: <c>int</c></para>
		/// <para>Upper limit (range) of the up-down control.</para>
		/// </param>
		/// <param name="nLower">
		/// <para>Type: <c>int</c></para>
		/// <para>Lower limit (range) of the up-down control.</para>
		/// </param>
		/// <param name="nPos">
		/// <para>Type: <c>int</c></para>
		/// <para>Position of the control.</para>
		/// </param>
		/// <returns>
		/// <para>Type: <c><c>HWND</c></c></para>
		/// <para>If the function succeeds, the return value is the window handle to the up-down control. If the function fails, the return value is <c>NULL</c>.</para>
		/// </returns>
		// HWND CreateUpDownControl( DWORD dwStyle, int x, int y, int cx, int cy, HWND hParent, int nID, HINSTANCE hInst, HWND hBuddy, int nUpper, int nLower, int nPos);
		// https://msdn.microsoft.com/en-us/library/windows/desktop/bb759977(v=vs.85).aspx
		[DllImport(Lib.ComCtl32, SetLastError = false, ExactSpelling = true)]
		[PInvokeData("Commctrl.h", MSDNShortId = "bb759977")]
		public static extern IntPtr CreateUpDownControl(uint dwStyle, int x, int y, int cx, int cy, HWND hParent, int nID, HINSTANCE hInst, HWND hBuddy, int nUpper, int nLower, int nPos);

		/// <summary>Contains information specific to up-down control notification messages. It is identical to and replaces the <c>NM_UPDOWN</c> structure.</summary>
		// typedef struct _NM_UPDOWN { NMHDR hdr; int iPos; int iDelta;} NMUPDOWN, *LPNMUPDOWN;
		// https://msdn.microsoft.com/en-us/library/windows/desktop/bb759893(v=vs.85).aspx
		[PInvokeData("Commctrl.h", MSDNShortId = "bb759893")]
		public struct NMUPDOWN
		{
			/// <summary><para>Type: <c><c>NMHDR</c></c></para><para><c>NMHDR</c> structure that contains additional information about the notification.</para></summary>
			public NMHDR hdr;
			/// <summary><para>Type: <c>int</c></para><para>Signed integer value that represents the up-down control&#39;s current position.</para></summary>
			public int iPos;
			/// <summary><para>Type: <c>int</c></para><para>Signed integer value that represents the proposed change in the up-down control&#39;s position.</para></summary>
			public int iDelta;
		}

		/// <summary>Contains acceleration information for an up-down control.</summary>
		// typedef struct { UINT nSec; UINT nInc;} UDACCEL, *LPUDACCEL;
		// https://msdn.microsoft.com/en-us/library/windows/desktop/bb759897(v=vs.85).aspx
		[PInvokeData("Commctrl.h", MSDNShortId = "bb759897")]
		[StructLayout(LayoutKind.Sequential)]
		public struct UDACCEL
		{
			/// <summary><para>Type: <c><c>UINT</c></c></para><para>Amount of elapsed time, in seconds, before the position change increment specified by <c>nInc</c> is used.</para></summary>
			public uint nSec;
			/// <summary><para>Type: <c><c>UINT</c></c></para><para>Position change increment to use after the time specified by <c>nSec</c> elapses.</para></summary>
			public uint nInc;
		}
	}
}