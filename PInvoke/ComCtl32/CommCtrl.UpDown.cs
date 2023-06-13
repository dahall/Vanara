using System;
using System.Runtime.InteropServices;
using static Vanara.PInvoke.User32;

namespace Vanara.PInvoke;

public static partial class ComCtl32
{
	/// <summary>Maximum value for an up-down control.</summary>
	public const short UD_MAXVAL = 0x7fff;

	/// <summary>Minimum value for an up-down control.</summary>
	public const short UD_MINVAL = -UD_MAXVAL;

	/// <summary>Window class for the up-down control.</summary>
	public const string UPDOWN_CLASS = "msctls_updown32";

	private const int UDN_FIRST = -721;

	/// <summary>Window messages for the up-down control.</summary>
	public enum UpDownMessage : uint
	{
		/// <summary>Retrieves acceleration information for an up-down control.
		/// <para>
		/// <strong>Parameters</strong>
		/// </para>
		/// <para><em>wParam</em></para>
		/// <para>Number of elements in the array specified by lParam.</para>
		/// <para><em>lParam</em></para>
		/// <para>Pointer to an array of <c>UDACCEL</c> structures that receive acceleration information.</para>
		/// <para>
		/// <strong>Returns</strong>
		/// </para>
		/// <para>The return value is the number of accelerators currently set for the control.</para>
		/// </summary>
		// https://docs.microsoft.com/en-us/windows/win32/controls/udm-getaccel
		[MsgParams(typeof(int), typeof(UDACCEL[]))]
		UDM_GETACCEL = WindowMessage.WM_USER + 108,

		/// <summary>Retrieves the current radix base (that is, either base 10 or 16) for an up-down control.
		/// <para>
		/// <strong>Parameters</strong>
		/// </para>
		/// <para><em>wParam</em></para>
		/// <para>Must be zero.</para>
		/// <para><em>lParam</em></para>
		/// <para>Must be zero.</para>
		/// <para>
		/// <strong>Returns</strong>
		/// </para>
		/// <para>The return value is the current base value.</para>
		/// </summary>
		// https://docs.microsoft.com/en-us/windows/win32/controls/udm-getbase
		[MsgParams(null, null, LResultType = typeof(int))]
		UDM_GETBASE = WindowMessage.WM_USER + 110,

		/// <summary>Retrieves the handle to the current buddy window.
		/// <para>
		/// <strong>Parameters</strong>
		/// </para>
		/// <para><em>wParam</em></para>
		/// <para>Must be zero.</para>
		/// <para><em>lParam</em></para>
		/// <para>Must be zero.</para>
		/// <para>
		/// <strong>Returns</strong>
		/// </para>
		/// <para>The return value is the handle to the current buddy window.</para>
		/// </summary>
		// https://docs.microsoft.com/en-us/windows/win32/controls/udm-getbuddy
		[MsgParams(null, null, LResultType = typeof(HWND))]
		UDM_GETBUDDY = WindowMessage.WM_USER + 106,

		/// <summary>Returns the 32-bit position of an up-down control.
		/// <para>
		/// <strong>Parameters</strong>
		/// </para>
		/// <para><em>wParam</em></para>
		/// <para>Must be zero.</para>
		/// <para><em>lParam</em></para>
		/// <para>Pointer to a <c>BOOL</c> value that is set to zero if the value is successfully retrieved or nonzero if an error occurs. If this parameter is set to <c>NULL</c>, errors are not reported.</para>
		/// <para>If <c>UDM_GETPOS32</c> is used in a cross-process situation, this parameter must be <c>NULL</c>.</para>
		/// <para>
		/// <strong>Returns</strong>
		/// </para>
		/// <para>Returns the position of an up-down control with 32-bit precision. Applications must check the lParam value to determine whether the return value is valid.</para>
		/// </summary>
		/// <remarks>When it processes this message, the up-down control updates its current position based on the caption of the buddy window. It returns an error if there is no buddy window or if the caption specifies an invalid or out-of-range value.</remarks>
		// https://docs.microsoft.com/en-us/windows/win32/controls/udm-getpos32
		[MsgParams(null, typeof(BOOL?), LResultType = typeof(int))]
		UDM_GETPOS = WindowMessage.WM_USER + 104,

		/// <summary>Returns the 32-bit position of an up-down control.
		/// <para>
		/// <strong>Parameters</strong>
		/// </para>
		/// <para><em>wParam</em></para>
		/// <para>Must be zero.</para>
		/// <para><em>lParam</em></para>
		/// <para>Pointer to a <c>BOOL</c> value that is set to zero if the value is successfully retrieved or nonzero if an error occurs. If this parameter is set to <c>NULL</c>, errors are not reported.</para>
		/// <para>If <c>UDM_GETPOS32</c> is used in a cross-process situation, this parameter must be <c>NULL</c>.</para>
		/// <para>
		/// <strong>Returns</strong>
		/// </para>
		/// <para>Returns the position of an up-down control with 32-bit precision. Applications must check the lParam value to determine whether the return value is valid.</para>
		/// </summary>
		/// <remarks>When it processes this message, the up-down control updates its current position based on the caption of the buddy window. It returns an error if there is no buddy window or if the caption specifies an invalid or out-of-range value.</remarks>
		// https://docs.microsoft.com/en-us/windows/win32/controls/udm-getpos32
		[MsgParams(null, typeof(BOOL?), LResultType = typeof(int))]
		UDM_GETPOS32 = WindowMessage.WM_USER + 114,

		/// <summary>Retrieves the minimum and maximum positions (range) for an up-down control.
		/// <para>
		/// <strong>Parameters</strong>
		/// </para>
		/// <para><em>wParam</em></para>
		/// <para>Must be zero.</para>
		/// <para><em>lParam</em></para>
		/// <para>Must be zero.</para>
		/// <para>
		/// <strong>Returns</strong>
		/// </para>
		/// <para>The return value is a 32-bit value that contains the minimum and maximum positions. The <c>LOWORD</c> is the maximum position for the control, and the <c>HIWORD</c> is the minimum position.</para>
		/// </summary>
		// https://docs.microsoft.com/en-us/windows/win32/controls/udm-getrange
		[MsgParams(null, null, LResultType = typeof(int))]
		UDM_GETRANGE = WindowMessage.WM_USER + 102,

		/// <summary>Retrieves the 32-bit range of an up-down control.
		/// <para>
		/// <strong>Parameters</strong>
		/// </para>
		/// <para><em>wParam</em></para>
		/// <para>Pointer to a signed integer that receives the lower limit of the up-down control range. This parameter may be <c>NULL</c>.</para>
		/// <para><em>lParam</em></para>
		/// <para>Pointer to a signed integer that receives the upper limit of the up-down control range. This parameter may be <c>NULL</c>.</para>
		/// <para>
		/// <strong>Returns</strong>
		/// </para>
		/// <para>The return value for this message is not used.</para>
		/// </summary>
		// https://docs.microsoft.com/en-us/windows/win32/controls/udm-getrange32
		[MsgParams(typeof(int), typeof(int), LResultType = null)]
		UDM_GETRANGE32 = WindowMessage.WM_USER + 112,

		/// <summary>Retrieves the Unicode character format flag for the control.
		/// <para>
		/// <strong>Parameters</strong>
		/// </para>
		/// <para><em>wParam</em></para>
		/// <para>Must be zero.</para>
		/// <para><em>lParam</em></para>
		/// <para>Must be zero.</para>
		/// <para>
		/// <strong>Returns</strong>
		/// </para>
		/// <para>Returns the Unicode format flag for the control. If this value is nonzero, the control is using Unicode characters. If this value is zero, the control is using ANSI characters.</para>
		/// </summary>
		/// <remarks>See the remarks for <c>CCM_GETUNICODEFORMAT</c> for a discussion of this message.</remarks>
		// https://docs.microsoft.com/en-us/windows/win32/controls/udm-getunicodeformat
		[MsgParams(null, null, LResultType = typeof(BOOL))]
		UDM_GETUNICODEFORMAT = CommonControlMessage.CCM_GETUNICODEFORMAT,

		/// <summary>Sets the acceleration for an up-down control.
		/// <para>
		/// <strong>Parameters</strong>
		/// </para>
		/// <para><em>wParam</em></para>
		/// <para>Number of <c>UDACCEL</c> structures specified by aAccels.</para>
		/// <para><em>lParam</em></para>
		/// <para>Pointer to an array of <c>UDACCEL</c> structures that contain acceleration information. Elements should be sorted in ascending order based on the <c>nSec</c> member.</para>
		/// <para>
		/// <strong>Returns</strong>
		/// </para>
		/// <para>Returns <c>TRUE</c> if successful, or <c>FALSE</c> otherwise.</para>
		/// </summary>
		// https://docs.microsoft.com/en-us/windows/win32/controls/udm-setaccel
		[MsgParams(typeof(int), typeof(UDACCEL[]), LResultType = typeof(BOOL))]
		UDM_SETACCEL = WindowMessage.WM_USER + 107,

		/// <summary>Sets the radix base for an up-down control. The base value determines whether the buddy window displays numbers in decimal or hexadecimal digits. Hexadecimal numbers are always unsigned, and decimal numbers are signed.
		/// <para>
		/// <strong>Parameters</strong>
		/// </para>
		/// <para><em>wParam</em></para>
		/// <para>New base value for the control. This parameter can be 10 for decimal or 16 for hexadecimal.</para>
		/// <para><em>lParam</em></para>
		/// <para>Must be zero.</para>
		/// <para>
		/// <strong>Returns</strong>
		/// </para>
		/// <para>The return value is the previous base value. If an invalid base is given, the return value is zero.</para>
		/// </summary>
		// https://docs.microsoft.com/en-us/windows/win32/controls/udm-setbase
		[MsgParams(typeof(int), null, LResultType = typeof(int))]
		UDM_SETBASE = WindowMessage.WM_USER + 109,

		/// <summary>Sets the buddy window for an up-down control.
		/// <para>
		/// <strong>Parameters</strong>
		/// </para>
		/// <para><em>wParam</em></para>
		/// <para>Handle to the new buddy window.</para>
		/// <para><em>lParam</em></para>
		/// <para>Must be zero.</para>
		/// <para>
		/// <strong>Returns</strong>
		/// </para>
		/// <para>The return value is the handle to the previous buddy window.</para>
		/// </summary>
		// https://docs.microsoft.com/en-us/windows/win32/controls/udm-setbuddy
		[MsgParams(typeof(HWND), null, LResultType = typeof(HWND))]
		UDM_SETBUDDY = WindowMessage.WM_USER + 105,

		/// <summary>Sets the current position for an up-down control with 16-bit precision.
		/// <para>
		/// <strong>Parameters</strong>
		/// </para>
		/// <para><em>wParam</em></para>
		/// <para>Must be zero.</para>
		/// <para><em>lParam</em></para>
		/// <para>New position for the up-down control. If the parameter is outside the control's specified range, lParam will be set to the nearest valid value.</para>
		/// <para>
		/// <strong>Returns</strong>
		/// </para>
		/// <para>The return value is the previous position.</para>
		/// </summary>
		/// <remarks>This message only supports 16-bit positions. If 32-bit values have been enabled for an up-down control with <c>UDM_SETRANGE32</c>, use <c>UDM_SETPOS32</c>.</remarks>
		// https://docs.microsoft.com/en-us/windows/win32/controls/udm-setpos
		[MsgParams(null, typeof(int), LResultType = typeof(int))]
		UDM_SETPOS = WindowMessage.WM_USER + 103,

		/// <summary>Sets the position of an up-down control with 32-bit precision.
		/// <para>
		/// <strong>Parameters</strong>
		/// </para>
		/// <para><em>wParam</em></para>
		/// <para>Must be zero.</para>
		/// <para><em>lParam</em></para>
		/// <para>Variable of type integer that specifies the new position for the up-down control. If the parameter is outside the control's specified range, lParam is set to the nearest valid value.</para>
		/// <para>
		/// <strong>Returns</strong>
		/// </para>
		/// <para>Returns the previous position.</para>
		/// </summary>
		// https://docs.microsoft.com/en-us/windows/win32/controls/udm-setpos32
		[MsgParams(null, typeof(int), LResultType = typeof(int))]
		UDM_SETPOS32 = WindowMessage.WM_USER + 113,

		/// <summary>Sets the minimum and maximum positions (range) for an up-down control.
		/// <para>
		/// <strong>Parameters</strong>
		/// </para>
		/// <para><em>wParam</em></para>
		/// <para>Must be zero.</para>
		/// <para><em>lParam</em></para>
		/// <para>The <c>LOWORD</c> is a <c>short</c> that specifies the maximum position for the up-down control, and the <c>HIWORD</c> is a <c>short</c> that specifies the minimum position. Neither position can be greater than the UD_MAXVAL value or less than the UD_MINVAL value. In addition, the difference between the two positions cannot exceed UD_MAXVAL.</para>
		/// <para>
		/// <strong>Returns</strong>
		/// </para>
		/// <para>No return value.</para>
		/// </summary>
		/// <remarks>The maximum position can be less than the minimum position. Clicking the up arrow button moves the current position closer to the maximum position, and clicking the down arrow button moves toward the minimum position.</remarks>
		// https://docs.microsoft.com/en-us/windows/win32/controls/udm-setrange
		[MsgParams(null, typeof(uint), LResultType = null)]
		UDM_SETRANGE = WindowMessage.WM_USER + 101,

		/// <summary>Sets the 32-bit range of an up-down control.
		/// <para>
		/// <strong>Parameters</strong>
		/// </para>
		/// <para><em>wParam</em></para>
		/// <para>Signed integer value that represents the new lower limit of the up-down control range.</para>
		/// <para><em>lParam</em></para>
		/// <para>Signed integer value that represents the new upper limit of the up-down control range.</para>
		/// <para>
		/// <strong>Returns</strong>
		/// </para>
		/// <para>The return value for this message is not used.</para>
		/// </summary>
		// https://docs.microsoft.com/en-us/windows/win32/controls/udm-setrange32
		[MsgParams(typeof(int), typeof(int), LResultType = null)]
		UDM_SETRANGE32 = WindowMessage.WM_USER + 111,

		/// <summary>Sets the Unicode character format flag for the control. This message allows you to change the character set used by the control at run time rather than having to re-create the control.
		/// <para>
		/// <strong>Parameters</strong>
		/// </para>
		/// <para><em>wParam</em></para>
		/// <para>Determines the character set that is used by the control. If this value is <c>TRUE</c>, the control will use Unicode characters. If this value is <c>FALSE</c>, the control will use ANSI characters.</para>
		/// <para><em>lParam</em></para>
		/// <para>Must be zero.</para>
		/// <para>
		/// <strong>Returns</strong>
		/// </para>
		/// <para>Returns the previous Unicode format flag for the control.</para>
		/// </summary>
		/// <remarks>See the remarks for <c>CCM_SETUNICODEFORMAT</c> for a discussion of this message.</remarks>
		// https://docs.microsoft.com/en-us/windows/win32/controls/udm-setunicodeformat
		[MsgParams(typeof(BOOL), typeof(int), LResultType = typeof(BOOL))]
		UDM_SETUNICODEFORMAT = CommonControlMessage.CCM_SETUNICODEFORMAT,
	}

	/// <summary>Notifications for the up-down control.</summary>
	public enum UpDownNotification : int
	{
		/// <summary>
		/// <para>Notifies a control's parent window that the control is releasing mouse capture. This notification code is sent in the form of a <c>WM_NOTIFY</c> message.</para>
		/// <para><code>NM_RELEASEDCAPTURE lpnmh = (LPNMHDR) lParam; </code></para>
		/// <para>
		/// <strong>Parameters</strong>
		/// </para>
		/// <para><em>lParam</em></para>
		/// <para>A pointer to an <c>NMHDR</c> structure that contains additional information about this notification.</para>
		/// <para>
		/// <strong>Returns</strong>
		/// </para>
		/// <para>Unless otherwise specified, the control ignores the return value from this notification code.</para>
		/// </summary>
		// https://docs.microsoft.com/en-us/windows/win32/controls/nm-releasedcapture
		[MsgParams(null, typeof(NMHDR?), LResultType = null)]
		NM_RELEASEDCAPTURE = UDN_FIRST - 1,

		/// <summary>
		/// <para>Sent by the operating system to the parent window of an up-down control when the position of the control is about to change. This happens when the user requests a change in the value by pressing the control's up or down arrow. This notification code is sent in the form of a <c>WM_NOTIFY</c> message.</para>
		/// <para><code>UDN_DELTAPOS lpnmud = (LPNMUPDOWN) lParam; </code></para>
		/// <para>
		/// <strong>Parameters</strong>
		/// </para>
		/// <para><em>lParam</em></para>
		/// <para>Pointer to an <c>NMUPDOWN</c> structure that contains information about the position change. The <c>iPos</c> member of this structure contains the current position of the control. The <c>iDelta</c> member of the structure is a signed integer that contains the proposed change in position. If the user has clicked the up button, this is a positive value. If the user has clicked the down button, this is a negative value.</para>
		/// <para>
		/// <strong>Returns</strong>
		/// </para>
		/// <para>Return nonzero to prevent the change in the control's position, or zero to allow the change.</para>
		/// </summary>
		/// <remarks>The UDN_DELTAPOS notification code is sent before the <c>WM_VSCROLL</c> or <c>WM_HSCROLL</c> message, which actually changes the control's position. This lets you examine, allow, modify, or disallow the change.</remarks>
		// https://docs.microsoft.com/en-us/windows/win32/controls/udn-deltapos
		[MsgParams(null, typeof(NMUPDOWN?), LResultType = typeof(int))]
		UDN_DELTAPOS = UDN_FIRST
	}

	/// <summary>Styles for the up-down control.</summary>
	[Flags]
	public enum UpDownStyle : uint
	{
		/// <summary>
		/// Positions the up-down control next to the left edge of the buddy window. The buddy window is moved to the right, and its
		/// width is decreased to accommodate the width of the up-down control.
		/// </summary>
		UDS_ALIGNLEFT = 0x08,

		/// <summary>
		/// Positions the up-down control next to the right edge of the buddy window. The width of the buddy window is decreased to
		/// accommodate the width of the up-down control.
		/// </summary>
		UDS_ALIGNRIGHT = 0x04,

		/// <summary>
		/// Causes the up-down control to increment and decrement the position when the UP ARROW and DOWN ARROW keys are pressed.
		/// </summary>
		UDS_ARROWKEYS = 0x20,

		/// <summary>Automatically selects the previous window in the z-order as the up-down control's buddy window.</summary>
		UDS_AUTOBUDDY = 0x10,

		/// <summary>Causes the up-down control's arrows to point left and right instead of up and down.</summary>
		UDS_HORZ = 0x40,

		/// <summary>
		/// Causes the control to exhibit "hot tracking" behavior. That is, it highlights the UP ARROW and DOWN ARROW on the control as
		/// the pointer passes over them. This style requires Windows 98 or Windows 2000. If the system is running Windows 95 or Windows
		/// NT 4.0, the flag is ignored. To check whether hot tracking is enabled, call SystemParametersInfo.
		/// </summary>
		UDS_HOTTRACK = 0x100,

		/// <summary>Does not insert a thousands separator between every three decimal digits.</summary>
		UDS_NOTHOUSANDS = 0x80,

		/// <summary>
		/// Causes the up-down control to set the text of the buddy window (using the WM_SETTEXT message) when the position changes. The
		/// text consists of the position formatted as a decimal or hexadecimal string.
		/// </summary>
		UDS_SETBUDDYINT = 0x02,

		/// <summary>Causes the position to "wrap" if it is incremented or decremented beyond the ending or beginning of the range.</summary>
		UDS_WRAP = 0x01,
	}

	/// <summary>
	/// Creates an up-down control. Note: This function is obsolete. It is a 16 bit function and cannot handle 32 bit values for range
	/// and position.
	/// </summary>
	/// <param name="dwStyle">
	/// <para>Type: <c><c>DWORD</c></c></para>
	/// <para>
	/// Window styles for the control. This parameter should include the <c>WS_CHILD</c>, <c>WS_BORDER</c>, and <c>WS_VISIBLE</c> styles,
	/// and it may include any of the window styles specific to the up-down control.
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
	/// <para>
	/// If the function succeeds, the return value is the window handle to the up-down control. If the function fails, the return value
	/// is <c>NULL</c>.
	/// </para>
	/// </returns>
	// HWND CreateUpDownControl( DWORD dwStyle, int x, int y, int cx, int cy, HWND hParent, int nID, HINSTANCE hInst, HWND hBuddy, int
	// nUpper, int nLower, int nPos); https://msdn.microsoft.com/en-us/library/windows/desktop/bb759977(v=vs.85).aspx
	[DllImport(Lib.ComCtl32, SetLastError = false, ExactSpelling = true)]
	[PInvokeData("Commctrl.h", MSDNShortId = "bb759977")]
	public static extern HWND CreateUpDownControl(uint dwStyle, int x, int y, int cx, int cy, HWND hParent, int nID, HINSTANCE hInst, HWND hBuddy, int nUpper, int nLower, int nPos);

	/// <summary>
	/// Contains information specific to up-down control notification messages. It is identical to and replaces the <c>NM_UPDOWN</c> structure.
	/// </summary>
	// typedef struct _NM_UPDOWN { NMHDR hdr; int iPos; int iDelta;} NMUPDOWN, *LPNMUPDOWN; https://msdn.microsoft.com/en-us/library/windows/desktop/bb759893(v=vs.85).aspx
	[PInvokeData("Commctrl.h", MSDNShortId = "bb759893")]
	public struct NMUPDOWN : INotificationInfo
	{
		/// <summary>
		/// <para>Type: <c><c>NMHDR</c></c></para>
		/// <para><c>NMHDR</c> structure that contains additional information about the notification.</para>
		/// </summary>
		public NMHDR hdr;

		/// <summary>
		/// <para>Type: <c>int</c></para>
		/// <para>Signed integer value that represents the proposed change in the up-down control's position.</para>
		/// </summary>
		public int iDelta;

		/// <summary>
		/// <para>Type: <c>int</c></para>
		/// <para>Signed integer value that represents the up-down control's current position.</para>
		/// </summary>
		public int iPos;
	}

	/// <summary>Contains acceleration information for an up-down control.</summary>
	// typedef struct { UINT nSec; UINT nInc;} UDACCEL, *LPUDACCEL; https://msdn.microsoft.com/en-us/library/windows/desktop/bb759897(v=vs.85).aspx
	[PInvokeData("Commctrl.h", MSDNShortId = "bb759897")]
	[StructLayout(LayoutKind.Sequential)]
	public struct UDACCEL
	{
		/// <summary>
		/// <para>Type: <c><c>UINT</c></c></para>
		/// <para>Amount of elapsed time, in seconds, before the position change increment specified by <c>nInc</c> is used.</para>
		/// </summary>
		public uint nSec;

		/// <summary>
		/// <para>Type: <c><c>UINT</c></c></para>
		/// <para>Position change increment to use after the time specified by <c>nSec</c> elapses.</para>
		/// </summary>
		public uint nInc;
	}
}