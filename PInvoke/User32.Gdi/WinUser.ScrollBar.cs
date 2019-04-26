using System;
using System.Runtime.InteropServices;

namespace Vanara.PInvoke
{
	public static partial class User32_Gdi
	{
		/// <summary>Flags used to enable or disable scroll bars.</summary>
		[PInvokeData("winuser.h")]
		public enum ESB_FLAGS : uint
		{
			/// <summary>Disables both direction buttons on the specified scroll bar.</summary>
			ESB_DISABLE_BOTH = 0x0003,

			/// <summary>Disables the down direction button on the vertical scroll bar.</summary>
			ESB_DISABLE_DOWN = 0x0002,

			/// <summary>Disables the left direction button on the horizontal scroll bar.</summary>
			ESB_DISABLE_LEFT = 0x0001,

			/// <summary>
			/// Disables the left direction button on the horizontal scroll bar or the up direction button on the vertical scroll bar.
			/// </summary>
			ESB_DISABLE_LTUP = ESB_DISABLE_LEFT,

			/// <summary>Disables the right direction button on the horizontal scroll bar.</summary>
			ESB_DISABLE_RIGHT = 0x0002,

			/// <summary>
			/// Disables the right direction button on the horizontal scroll bar or the down direction button on the vertical scroll bar.
			/// </summary>
			ESB_DISABLE_RTDN = ESB_DISABLE_RIGHT,

			/// <summary>Disables the up direction button on the vertical scroll bar.</summary>
			ESB_DISABLE_UP = 0x0001,

			/// <summary>Enables both direction buttons on the specified scroll bar.</summary>
			ESB_ENABLE_BOTH = 0x0000,
		}

		/// <summary>Specifies the scroll bar type.</summary>
		[PInvokeData("winuser.h")]
		public enum SB
		{
			/// <summary>The horizontal and vertical scroll bars.</summary>
			SB_BOTH = 3,

			/// <summary>The horizontal scroll bar.</summary>
			SB_HORZ = 0,

			/// <summary>The vertical scroll bar.</summary>
			SB_VERT = 1,

			/// <summary>The scroll bar control.</summary>
			SB_CTL = 2,
		}

		/// <summary>Specifies flags that control scrolling.</summary>
		[PInvokeData("winuser.h", MSDNShortId = "")]
		[Flags]
		public enum ScrollWindowFlags
		{
			/// <summary>
			/// Scrolls all child windows that intersect the rectangle pointed to by the prcScroll parameter. The child windows are scrolled
			/// by the number of pixels specified by the dx and dy parameters. The system sends a WM_MOVE message to all child windows that
			/// intersect the prcScroll rectangle, even if they do not move.
			/// </summary>
			SW_SCROLLCHILDREN = 0x0001,

			/// <summary>Invalidates the region identified by the hrgnUpdate parameter after scrolling.</summary>
			SW_INVALIDATE = 0x0002,

			/// <summary>
			/// Erases the newly invalidated region by sending a WM_ERASEBKGND message to the window when specified with the SW_INVALIDATE flag.
			/// </summary>
			SW_ERASE = 0x0004,

			/// <summary>
			/// Scrolls using smooth scrolling. Use the HIWORD portion of the flags parameter to indicate how much time, in milliseconds, the
			/// smooth-scrolling operation should take.
			/// </summary>
			SW_SMOOTHSCROLL = 0x0010,
		}

		/// <summary>Specifies the scroll bar parameters to set or retrieve.</summary>
		[PInvokeData("winuser.h", MSDNShortId = "")]
		[Flags]
		public enum SIF
		{
			/// <summary>The nMin and nMax members contain the minimum and maximum values for the scrolling range.</summary>
			SIF_RANGE = 0x0001,

			/// <summary>The nPage member contains the page size for a proportional scroll bar.</summary>
			SIF_PAGE = 0x0002,

			/// <summary>The nPos member contains the scroll box position, which is not updated while the user drags the scroll box.</summary>
			SIF_POS = 0x0004,

			/// <summary>
			/// This value is used only when setting a scroll bar's parameters. If the scroll bar's new parameters make the scroll bar
			/// unnecessary, disable the scroll bar instead of removing it.
			/// </summary>
			SIF_DISABLENOSCROLL = 0x0008,

			/// <summary>The nTrackPos member contains the current position of the scroll box while the user is dragging it.</summary>
			SIF_TRACKPOS = 0x0010,

			/// <summary>Combination of SIF_PAGE, SIF_POS, SIF_RANGE, and SIF_TRACKPOS.</summary>
			SIF_ALL = SIF_RANGE | SIF_PAGE | SIF_POS | SIF_TRACKPOS,
		}

		/// <summary>The <c>EnableScrollBar</c> function enables or disables one or both scroll bar arrows.</summary>
		/// <param name="hWnd">
		/// <para>Type: <c>HWND</c></para>
		/// <para>Handle to a window or a scroll bar control, depending on the value of the wSBflags parameter.</para>
		/// </param>
		/// <param name="wSBflags">
		/// <para>Type: <c>UINT</c></para>
		/// <para>Specifies the scroll bar type. This parameter can be one of the following values.</para>
		/// <list type="table">
		/// <listheader>
		/// <term>Value</term>
		/// <term>Meaning</term>
		/// </listheader>
		/// <item>
		/// <term>SB_BOTH</term>
		/// <term>
		/// Enables or disables the arrows on the horizontal and vertical scroll bars associated with the specified window. The hWnd
		/// parameter must be the handle to the window.
		/// </term>
		/// </item>
		/// <item>
		/// <term>SB_CTL</term>
		/// <term>Indicates that the scroll bar is a scroll bar control. The hWnd must be the handle to the scroll bar control.</term>
		/// </item>
		/// <item>
		/// <term>SB_HORZ</term>
		/// <term>
		/// Enables or disables the arrows on the horizontal scroll bar associated with the specified window. The hWnd parameter must be the
		/// handle to the window.
		/// </term>
		/// </item>
		/// <item>
		/// <term>SB_VERT</term>
		/// <term>
		/// Enables or disables the arrows on the vertical scroll bar associated with the specified window. The hWnd parameter must be the
		/// handle to the window.
		/// </term>
		/// </item>
		/// </list>
		/// </param>
		/// <param name="wArrows">
		/// <para>Type: <c>UINT</c></para>
		/// <para>
		/// Specifies whether the scroll bar arrows are enabled or disabled and indicates which arrows are enabled or disabled. This
		/// parameter can be one of the following values.
		/// </para>
		/// <list type="table">
		/// <listheader>
		/// <term>Value</term>
		/// <term>Meaning</term>
		/// </listheader>
		/// <item>
		/// <term>ESB_DISABLE_BOTH</term>
		/// <term>Disables both arrows on a scroll bar.</term>
		/// </item>
		/// <item>
		/// <term>ESB_DISABLE_DOWN</term>
		/// <term>Disables the down arrow on a vertical scroll bar.</term>
		/// </item>
		/// <item>
		/// <term>ESB_DISABLE_LEFT</term>
		/// <term>Disables the left arrow on a horizontal scroll bar.</term>
		/// </item>
		/// <item>
		/// <term>ESB_DISABLE_LTUP</term>
		/// <term>Disables the left arrow on a horizontal scroll bar or the up arrow of a vertical scroll bar.</term>
		/// </item>
		/// <item>
		/// <term>ESB_DISABLE_RIGHT</term>
		/// <term>Disables the right arrow on a horizontal scroll bar.</term>
		/// </item>
		/// <item>
		/// <term>ESB_DISABLE_RTDN</term>
		/// <term>Disables the right arrow on a horizontal scroll bar or the down arrow of a vertical scroll bar.</term>
		/// </item>
		/// <item>
		/// <term>ESB_DISABLE_UP</term>
		/// <term>Disables the up arrow on a vertical scroll bar.</term>
		/// </item>
		/// <item>
		/// <term>ESB_ENABLE_BOTH</term>
		/// <term>Enables both arrows on a scroll bar.</term>
		/// </item>
		/// </list>
		/// </param>
		/// <returns>
		/// <para>Type: <c>BOOL</c></para>
		/// <para>If the arrows are enabled or disabled as specified, the return value is nonzero.</para>
		/// <para>
		/// If the arrows are already in the requested state or an error occurs, the return value is zero. To get extended error information,
		/// call GetLastError.
		/// </para>
		/// </returns>
		// https://docs.microsoft.com/en-us/windows/desktop/api/winuser/nf-winuser-enablescrollbar BOOL EnableScrollBar( HWND hWnd, UINT
		// wSBflags, UINT wArrows );
		[DllImport(Lib.User32, SetLastError = true, ExactSpelling = true)]
		[PInvokeData("winuser.h", MSDNShortId = "")]
		[return: MarshalAs(UnmanagedType.Bool)]
		public static extern bool EnableScrollBar(HWND hWnd, uint wSBflags, uint wArrows);

		/// <summary>The <c>GetScrollBarInfo</c> function retrieves information about the specified scroll bar.</summary>
		/// <param name="hwnd">
		/// <para>Type: <c>HWND</c></para>
		/// <para>
		/// Handle to a window associated with the scroll bar whose information is to be retrieved. If the idObject parameter is
		/// OBJID_CLIENT, hwnd is a handle to a scroll bar control. Otherwise, hwnd is a handle to a window created with WS_VSCROLL and/or
		/// WS_HSCROLL style.
		/// </para>
		/// </param>
		/// <param name="idObject">
		/// <para>Type: <c>LONG</c></para>
		/// <para>Specifies the scroll bar object. This parameter can be one of the following values.</para>
		/// <list type="table">
		/// <listheader>
		/// <term>Value</term>
		/// <term>Meaning</term>
		/// </listheader>
		/// <item>
		/// <term>OBJID_CLIENT</term>
		/// <term>The hwnd parameter is a handle to a scroll bar control.</term>
		/// </item>
		/// <item>
		/// <term>OBJID_HSCROLL</term>
		/// <term>The horizontal scroll bar of the hwnd window.</term>
		/// </item>
		/// <item>
		/// <term>OBJID_VSCROLL</term>
		/// <term>The vertical scroll bar of the hwnd window.</term>
		/// </item>
		/// </list>
		/// </param>
		/// <param name="psbi">
		/// <para>Type: <c>PSCROLLBARINFO</c></para>
		/// <para>
		/// Pointer to a SCROLLBARINFO structure to receive the information. Before calling <c>GetScrollBarInfo</c>, set the <c>cbSize</c>
		/// member to <c>sizeof</c>( <c>SCROLLBARINFO</c>).
		/// </para>
		/// </param>
		/// <returns>
		/// <para>Type: <c>BOOL</c></para>
		/// <para>If the function succeeds, the return value is nonzero.</para>
		/// <para>If the function fails, the return value is zero. To get extended error information, call GetLastError.</para>
		/// </returns>
		/// <remarks>
		/// If idObject is OBJID_CLIENT and the window specified by hwnd is not a system scroll bar control, the system sends the
		/// SBM_GETSCROLLBARINFO message to the window to obtain scroll bar information. This allows <c>GetScrollBarInfo</c> to operate on a
		/// custom control that mimics a scroll bar. If the window does not handle the <c>SBM_GETSCROLLBARINFO</c> message, the
		/// <c>GetScrollBarInfo</c> function fails.
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows/desktop/api/winuser/nf-winuser-getscrollbarinfo BOOL GetScrollBarInfo( HWND hwnd, LONG
		// idObject, PSCROLLBARINFO psbi );
		[DllImport(Lib.User32, SetLastError = true, ExactSpelling = true)]
		[PInvokeData("winuser.h", MSDNShortId = "")]
		[return: MarshalAs(UnmanagedType.Bool)]
		public static extern bool GetScrollBarInfo(HWND hwnd, int idObject, ref SCROLLBARINFO psbi);

		/// <summary>
		/// The <c>GetScrollInfo</c> function retrieves the parameters of a scroll bar, including the minimum and maximum scrolling
		/// positions, the page size, and the position of the scroll box (thumb).
		/// </summary>
		/// <param name="hwnd">
		/// <para>Type: <c>HWND</c></para>
		/// <para>Handle to a scroll bar control or a window with a standard scroll bar, depending on the value of the fnBar parameter.</para>
		/// </param>
		/// <param name="nBar">
		/// <para>Type: <c>int</c></para>
		/// <para>Specifies the type of scroll bar for which to retrieve parameters. This parameter can be one of the following values.</para>
		/// <list type="table">
		/// <listheader>
		/// <term>Value</term>
		/// <term>Meaning</term>
		/// </listheader>
		/// <item>
		/// <term>SB_CTL</term>
		/// <term>Retrieves the parameters for a scroll bar control. The hwnd parameter must be the handle to the scroll bar control.</term>
		/// </item>
		/// <item>
		/// <term>SB_HORZ</term>
		/// <term>Retrieves the parameters for the window's standard horizontal scroll bar.</term>
		/// </item>
		/// <item>
		/// <term>SB_VERT</term>
		/// <term>Retrieves the parameters for the window's standard vertical scroll bar.</term>
		/// </item>
		/// </list>
		/// </param>
		/// <param name="lpsi">
		/// <para>Type: <c>LPSCROLLINFO</c></para>
		/// <para>
		/// Pointer to a SCROLLINFO structure. Before calling <c>GetScrollInfo</c>, set the <c>cbSize</c> member to <c>sizeof</c>(
		/// <c>SCROLLINFO</c>), and set the <c>fMask</c> member to specify the scroll bar parameters to retrieve. Before returning, the
		/// function copies the specified parameters to the appropriate members of the structure.
		/// </para>
		/// <para>The <c>fMask</c> member can be one or more of the following values.</para>
		/// <list type="table">
		/// <listheader>
		/// <term>Value</term>
		/// <term>Meaning</term>
		/// </listheader>
		/// <item>
		/// <term>SIF_PAGE</term>
		/// <term>Copies the scroll page to the nPage member of the SCROLLINFO structure pointed to by lpsi.</term>
		/// </item>
		/// <item>
		/// <term>SIF_POS</term>
		/// <term>Copies the scroll position to the nPos member of the SCROLLINFO structure pointed to by lpsi.</term>
		/// </item>
		/// <item>
		/// <term>SIF_RANGE</term>
		/// <term>Copies the scroll range to the nMin and nMax members of the SCROLLINFO structure pointed to by lpsi.</term>
		/// </item>
		/// <item>
		/// <term>SIF_TRACKPOS</term>
		/// <term>Copies the current scroll box tracking position to the nTrackPos member of the SCROLLINFO structure pointed to by lpsi.</term>
		/// </item>
		/// </list>
		/// </param>
		/// <returns>
		/// <para>Type: <c>BOOL</c></para>
		/// <para>If the function retrieved any values, the return value is nonzero.</para>
		/// <para>If the function does not retrieve any values, the return value is zero. To get extended error information, call GetLastError.</para>
		/// </returns>
		/// <remarks>
		/// <para>
		/// The <c>GetScrollInfo</c> function enables applications to use 32-bit scroll positions. Although the messages that indicate scroll
		/// bar position, WM_HSCROLL and WM_VSCROLL, provide only 16 bits of position data, the functions SetScrollInfo and
		/// <c>GetScrollInfo</c> provide 32 bits of scroll bar position data. Thus, an application can call <c>GetScrollInfo</c> while
		/// processing either the <c>WM_HSCROLL</c> or <c>WM_VSCROLL</c> messages to obtain 32-bit scroll bar position data.
		/// </para>
		/// <para>
		/// To get the 32-bit position of the scroll box (thumb) during a SB_THUMBTRACK request code in a WM_HSCROLL or WM_VSCROLL message,
		/// call <c>GetScrollInfo</c> with the SIF_TRACKPOS value in the <c>fMask</c> member of the SCROLLINFO structure. The function
		/// returns the tracking position of the scroll box in the <c>nTrackPos</c> member of the <c>SCROLLINFO</c> structure. This allows
		/// you to get the position of the scroll box as the user moves it. The following sample code illustrates the technique.
		/// </para>
		/// <para>
		/// If the fnBar parameter is SB_CTL and the window specified by the hwnd parameter is not a system scroll bar control, the system
		/// sends the SBM_GETSCROLLINFO message to the window to obtain scroll bar information. This allows <c>GetScrollInfo</c> to operate
		/// on a custom control that mimics a scroll bar. If the window does not handle the <c>SBM_GETSCROLLINFO</c> message, the
		/// <c>GetScrollInfo</c> function fails.
		/// </para>
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows/desktop/api/winuser/nf-winuser-getscrollinfo BOOL GetScrollInfo( HWND hwnd, int nBar,
		// LPSCROLLINFO lpsi );
		[DllImport(Lib.User32, SetLastError = true, ExactSpelling = true)]
		[PInvokeData("winuser.h", MSDNShortId = "")]
		[return: MarshalAs(UnmanagedType.Bool)]
		public static extern bool GetScrollInfo(HWND hwnd, int nBar, ref SCROLLINFO lpsi);

		/// <summary>
		/// <para>
		/// The <c>GetScrollPos</c> function retrieves the current position of the scroll box (thumb) in the specified scroll bar. The
		/// current position is a relative value that depends on the current scrolling range. For example, if the scrolling range is 0
		/// through 100 and the scroll box is in the middle of the bar, the current position is 50.
		/// </para>
		/// <para>
		/// <c>Note</c> The <c>GetScrollPos</c> function is provided for backward compatibility. New applications should use the
		/// GetScrollInfo function.
		/// </para>
		/// </summary>
		/// <param name="hWnd">
		/// <para>Type: <c>HWND</c></para>
		/// <para>Handle to a scroll bar control or a window with a standard scroll bar, depending on the value of the nBar parameter.</para>
		/// </param>
		/// <param name="nBar">
		/// <para>Type: <c>int</c></para>
		/// <para>Specifies the scroll bar to be examined. This parameter can be one of the following values.</para>
		/// <list type="table">
		/// <listheader>
		/// <term>Value</term>
		/// <term>Meaning</term>
		/// </listheader>
		/// <item>
		/// <term>SB_CTL</term>
		/// <term>
		/// Retrieves the position of the scroll box in a scroll bar control. The hWnd parameter must be the handle to the scroll bar control.
		/// </term>
		/// </item>
		/// <item>
		/// <term>SB_HORZ</term>
		/// <term>Retrieves the position of the scroll box in a window's standard horizontal scroll bar.</term>
		/// </item>
		/// <item>
		/// <term>SB_VERT</term>
		/// <term>Retrieves the position of the scroll box in a window's standard vertical scroll bar.</term>
		/// </item>
		/// </list>
		/// </param>
		/// <returns>
		/// <para>Type: <c>int</c></para>
		/// <para>If the function succeeds, the return value is the current position of the scroll box.</para>
		/// <para>If the function fails, the return value is zero. To get extended error information, call GetLastError.</para>
		/// </returns>
		/// <remarks>
		/// <para>
		/// The <c>GetScrollPos</c> function enables applications to use 32-bit scroll positions. Although the messages that indicate scroll
		/// bar position, WM_HSCROLL and WM_VSCROLL, are limited to 16 bits of position data, the functions SetScrollPos, SetScrollRange,
		/// <c>GetScrollPos</c>, and GetScrollRange support 32-bit scroll bar position data. Thus, an application can call
		/// <c>GetScrollPos</c> while processing either the <c>WM_HSCROLL</c> or <c>WM_VSCROLL</c> messages to obtain 32-bit scroll bar
		/// position data.
		/// </para>
		/// <para>
		/// To get the 32-bit position of the scroll box (thumb) during a SB_THUMBTRACK request code in a WM_HSCROLL or WM_VSCROLL message,
		/// use the GetScrollInfo function.
		/// </para>
		/// <para>
		/// If the nBar parameter is SB_CTL and the window specified by the hWnd parameter is not a system scroll bar control, the system
		/// sends the SBM_GETPOS message to the window to obtain scroll bar information. This allows <c>GetScrollPos</c> to operate on a
		/// custom control that mimics a scroll bar. If the window does not handle the <c>SBM_GETPOS</c> message, the <c>GetScrollPos</c>
		/// function fails.
		/// </para>
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows/desktop/api/winuser/nf-winuser-getscrollpos int GetScrollPos( HWND hWnd, int nBar );
		[DllImport(Lib.User32, SetLastError = true, ExactSpelling = true)]
		[PInvokeData("winuser.h", MSDNShortId = "")]
		public static extern int GetScrollPos(HWND hWnd, int nBar);

		/// <summary>
		/// <para>
		/// The <c>GetScrollRange</c> function retrieves the current minimum and maximum scroll box (thumb) positions for the specified
		/// scroll bar.
		/// </para>
		/// <para>
		/// <c>Note</c> The <c>GetScrollRange</c> function is provided for compatibility only. New applications should use the GetScrollInfo function.
		/// </para>
		/// </summary>
		/// <param name="hWnd">
		/// <para>Type: <c>HWND</c></para>
		/// <para>Handle to a scroll bar control or a window with a standard scroll bar, depending on the value of the nBar parameter.</para>
		/// </param>
		/// <param name="nBar">
		/// <para>Type: <c>int</c></para>
		/// <para>Specifies the scroll bar from which the positions are retrieved. This parameter can be one of the following values.</para>
		/// <list type="table">
		/// <listheader>
		/// <term>Value</term>
		/// <term>Meaning</term>
		/// </listheader>
		/// <item>
		/// <term>SB_CTL</term>
		/// <term>Retrieves the positions of a scroll bar control. The hWnd parameter must be the handle to the scroll bar control.</term>
		/// </item>
		/// <item>
		/// <term>SB_HORZ</term>
		/// <term>Retrieves the positions of the window's standard horizontal scroll bar.</term>
		/// </item>
		/// <item>
		/// <term>SB_VERT</term>
		/// <term>Retrieves the positions of the window's standard vertical scroll bar.</term>
		/// </item>
		/// </list>
		/// </param>
		/// <param name="lpMinPos">
		/// <para>Type: <c>LPINT</c></para>
		/// <para>Pointer to the integer variable that receives the minimum position.</para>
		/// </param>
		/// <param name="lpMaxPos">
		/// <para>Type: <c>LPINT</c></para>
		/// <para>Pointer to the integer variable that receives the maximum position.</para>
		/// </param>
		/// <returns>
		/// <para>Type: <c>BOOL</c></para>
		/// <para>If the function succeeds, the return value is nonzero.</para>
		/// <para>If the function fails, the return value is zero. To get extended error information, call GetLastError.</para>
		/// </returns>
		/// <remarks>
		/// <para>
		/// If the specified window does not have standard scroll bars or is not a scroll bar control, the <c>GetScrollRange</c> function
		/// copies zero to the lpMinPos and lpMaxPos parameters.
		/// </para>
		/// <para>
		/// The default range for a standard scroll bar is 0 through 100. The default range for a scroll bar control is empty (both values
		/// are zero).
		/// </para>
		/// <para>
		/// The messages that indicate scroll bar position, WM_HSCROLL and WM_VSCROLL, are limited to 16 bits of position data. However,
		/// because SetScrollInfo, SetScrollPos, SetScrollRange, GetScrollInfo, GetScrollPos, and <c>GetScrollRange</c> support 32-bit scroll
		/// bar position data, there is a way to circumvent the 16-bit barrier of the <c>WM_HSCROLL</c> and <c>WM_VSCROLL</c> messages. See
		/// the <c>GetScrollInfo</c> function for a description of the technique.
		/// </para>
		/// <para>
		/// If the nBar parameter is SB_CTL and the window specified by the hWnd parameter is not a system scroll bar control, the system
		/// sends the SBM_GETRANGE message to the window to obtain scroll bar information. This allows <c>GetScrollRange</c> to operate on a
		/// custom control that mimics a scroll bar. If the window does not handle the <c>SBM_GETRANGE</c> message, the <c>GetScrollRange</c>
		/// function fails.
		/// </para>
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows/desktop/api/winuser/nf-winuser-getscrollrange BOOL GetScrollRange( HWND hWnd, int nBar,
		// LPINT lpMinPos, LPINT lpMaxPos );
		[DllImport(Lib.User32, SetLastError = true, ExactSpelling = true)]
		[PInvokeData("winuser.h", MSDNShortId = "")]
		[return: MarshalAs(UnmanagedType.Bool)]
		public static extern bool GetScrollRange(HWND hWnd, int nBar, out int lpMinPos, out int lpMaxPos);

		/// <summary>The <c>ScrollDC</c> function scrolls a rectangle of bits horizontally and vertically.</summary>
		/// <param name="hDC">
		/// <para>Type: <c>HDC</c></para>
		/// <para>Handle to the device context that contains the bits to be scrolled.</para>
		/// </param>
		/// <param name="dx">
		/// <para>Type: <c>int</c></para>
		/// <para>
		/// Specifies the amount, in device units, of horizontal scrolling. This parameter must be a negative value to scroll to the left.
		/// </para>
		/// </param>
		/// <param name="dy">
		/// <para>Type: <c>int</c></para>
		/// <para>Specifies the amount, in device units, of vertical scrolling. This parameter must be a negative value to scroll up.</para>
		/// </param>
		/// <param name="lprcScroll">
		/// <para>Type: <c>const RECT*</c></para>
		/// <para>
		/// Pointer to a RECT structure containing the coordinates of the bits to be scrolled. The only bits affected by the scroll operation
		/// are bits in the intersection of this rectangle and the rectangle specified by lprcClip. If lprcScroll is <c>NULL</c>, the entire
		/// client area is used.
		/// </para>
		/// </param>
		/// <param name="lprcClip">
		/// <para>Type: <c>const RECT*</c></para>
		/// <para>
		/// Pointer to a RECT structure containing the coordinates of the clipping rectangle. The only bits that will be painted are the bits
		/// that remain inside this rectangle after the scroll operation has been completed. If lprcClip is <c>NULL</c>, the entire client
		/// area is used.
		/// </para>
		/// </param>
		/// <param name="hrgnUpdate">
		/// <para>Type: <c>HRGN</c></para>
		/// <para>
		/// Handle to the region uncovered by the scrolling process. <c>ScrollDC</c> defines this region; it is not necessarily a rectangle.
		/// </para>
		/// </param>
		/// <param name="lprcUpdate">
		/// <para>Type: <c>LPRECT</c></para>
		/// <para>
		/// Pointer to a RECT structure that receives the coordinates of the rectangle bounding the scrolling update region. This is the
		/// largest rectangular area that requires repainting. When the function returns, the values in the structure are in client
		/// coordinates, regardless of the mapping mode for the specified device context. This allows applications to use the update region
		/// in a call to the InvalidateRgn function, if required.
		/// </para>
		/// </param>
		/// <returns>
		/// <para>Type: <c>BOOL</c></para>
		/// <para>If the function succeeds, the return value is nonzero.</para>
		/// <para>If the function fails, the return value is zero. To get extended error information, call GetLastError.</para>
		/// </returns>
		/// <remarks>
		/// <para>
		/// If the lprcUpdate parameter is <c>NULL</c>, the system does not compute the update rectangle. If both the hrgnUpdate and
		/// lprcUpdate parameters are <c>NULL</c>, the system does not compute the update region. If hrgnUpdate is not <c>NULL</c>, the
		/// system proceeds as though it contains a valid handle to the region uncovered by the scrolling process (defined by <c>ScrollDC</c>).
		/// </para>
		/// <para>When you must scroll the entire client area of a window, use the ScrollWindowEx function.</para>
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows/desktop/api/winuser/nf-winuser-scrolldc BOOL ScrollDC( HDC hDC, int dx, int dy, const
		// RECT *lprcScroll, const RECT *lprcClip, HRGN hrgnUpdate, LPRECT lprcUpdate );
		[DllImport(Lib.User32, SetLastError = true, ExactSpelling = true)]
		[PInvokeData("winuser.h", MSDNShortId = "")]
		[return: MarshalAs(UnmanagedType.Bool)]
		public static extern bool ScrollDC(HDC hDC, int dx, int dy, PRECT lprcScroll, PRECT lprcClip, HRGN hrgnUpdate, out RECT lprcUpdate);

		/// <summary>
		/// <para>The <c>ScrollWindow</c> function scrolls the contents of the specified window's client area.</para>
		/// <para>
		/// <c>Note</c> The <c>ScrollWindow</c> function is provided for backward compatibility. New applications should use the
		/// ScrollWindowEx function.
		/// </para>
		/// </summary>
		/// <param name="hWnd">
		/// <para>Type: <c>HWND</c></para>
		/// <para>Handle to the window where the client area is to be scrolled.</para>
		/// </param>
		/// <param name="XAmount">
		/// <para>Type: <c>int</c></para>
		/// <para>
		/// Specifies the amount, in device units, of horizontal scrolling. If the window being scrolled has the CS_OWNDC or CS_CLASSDC
		/// style, then this parameter uses logical units rather than device units. This parameter must be a negative value to scroll the
		/// content of the window to the left.
		/// </para>
		/// </param>
		/// <param name="YAmount">
		/// <para>Type: <c>int</c></para>
		/// <para>
		/// Specifies the amount, in device units, of vertical scrolling. If the window being scrolled has the CS_OWNDC or CS_CLASSDC style,
		/// then this parameter uses logical units rather than device units. This parameter must be a negative value to scroll the content of
		/// the window up.
		/// </para>
		/// </param>
		/// <param name="lpRect">
		/// <para>Type: <c>const RECT*</c></para>
		/// <para>
		/// Pointer to the RECT structure specifying the portion of the client area to be scrolled. If this parameter is <c>NULL</c>, the
		/// entire client area is scrolled.
		/// </para>
		/// </param>
		/// <param name="lpClipRect">
		/// <para>Type: <c>const RECT*</c></para>
		/// <para>
		/// Pointer to the RECT structure containing the coordinates of the clipping rectangle. Only device bits within the clipping
		/// rectangle are affected. Bits scrolled from the outside of the rectangle to the inside are painted; bits scrolled from the inside
		/// of the rectangle to the outside are not painted.
		/// </para>
		/// </param>
		/// <returns>
		/// <para>Type: <c>BOOL</c></para>
		/// <para>If the function succeeds, the return value is nonzero.</para>
		/// <para>If the function fails, the return value is zero. To get extended error information, call GetLastError.</para>
		/// </returns>
		/// <remarks>
		/// <para>
		/// If the caret is in the window being scrolled, <c>ScrollWindow</c> automatically hides the caret to prevent it from being erased
		/// and then restores the caret after the scrolling is finished. The caret position is adjusted accordingly.
		/// </para>
		/// <para>
		/// The area uncovered by <c>ScrollWindow</c> is not repainted, but it is combined into the window's update region. The application
		/// eventually receives a WM_PAINT message notifying it that the region must be repainted. To repaint the uncovered area at the same
		/// time the scrolling is in action, call the UpdateWindow function immediately after calling <c>ScrollWindow</c>.
		/// </para>
		/// <para>
		/// If the lpRect parameter is <c>NULL</c>, the positions of any child windows in the window are offset by the amount specified by
		/// the XAmount and YAmount parameters; invalid (unpainted) areas in the window are also offset. <c>ScrollWindow</c> is faster when
		/// lpRect is <c>NULL</c>.
		/// </para>
		/// <para>
		/// If lpRect is not <c>NULL</c>, the positions of child windows are not changed and invalid areas in the window are not offset. To
		/// prevent updating problems when lpRect is not <c>NULL</c>, call UpdateWindow to repaint the window before calling <c>ScrollWindow</c>.
		/// </para>
		/// <para>Examples</para>
		/// <para>For an example, see Scrolling Text with the WM_PAINT Message.</para>
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows/desktop/api/winuser/nf-winuser-scrollwindow BOOL ScrollWindow( HWND hWnd, int XAmount,
		// int YAmount, const RECT *lpRect, const RECT *lpClipRect );
		[DllImport(Lib.User32, SetLastError = true, ExactSpelling = true)]
		[PInvokeData("winuser.h", MSDNShortId = "")]
		[return: MarshalAs(UnmanagedType.Bool)]
		public static extern bool ScrollWindow(HWND hWnd, int XAmount, int YAmount, PRECT lpRect, in RECT lpClipRect);

		/// <summary>The <c>ScrollWindowEx</c> function scrolls the contents of the specified window's client area.</summary>
		/// <param name="hWnd">
		/// <para>Type: <c>HWND</c></para>
		/// <para>Handle to the window where the client area is to be scrolled.</para>
		/// </param>
		/// <param name="dx">
		/// <para>Type: <c>int</c></para>
		/// <para>
		/// Specifies the amount, in device units, of horizontal scrolling. This parameter must be a negative value to scroll to the left.
		/// </para>
		/// </param>
		/// <param name="dy">
		/// <para>Type: <c>int</c></para>
		/// <para>Specifies the amount, in device units, of vertical scrolling. This parameter must be a negative value to scroll up.</para>
		/// </param>
		/// <param name="prcScroll">
		/// <para>Type: <c>const RECT*</c></para>
		/// <para>
		/// Pointer to a RECT structure that specifies the portion of the client area to be scrolled. If this parameter is <c>NULL</c>, the
		/// entire client area is scrolled.
		/// </para>
		/// </param>
		/// <param name="prcClip">
		/// <para>Type: <c>const RECT*</c></para>
		/// <para>
		/// Pointer to a RECT structure that contains the coordinates of the clipping rectangle. Only device bits within the clipping
		/// rectangle are affected. Bits scrolled from the outside of the rectangle to the inside are painted; bits scrolled from the inside
		/// of the rectangle to the outside are not painted. This parameter may be <c>NULL</c>.
		/// </para>
		/// </param>
		/// <param name="hrgnUpdate">
		/// <para>Type: <c>HRGN</c></para>
		/// <para>Handle to the region that is modified to hold the region invalidated by scrolling. This parameter may be <c>NULL</c>.</para>
		/// </param>
		/// <param name="prcUpdate">
		/// <para>Type: <c>LPRECT</c></para>
		/// <para>
		/// Pointer to a RECT structure that receives the boundaries of the rectangle invalidated by scrolling. This parameter may be <c>NULL</c>.
		/// </para>
		/// </param>
		/// <param name="flags">
		/// <para>Type: <c>UINT</c></para>
		/// <para>Specifies flags that control scrolling. This parameter can be a combination of the following values.</para>
		/// <list type="table">
		/// <listheader>
		/// <term>Value</term>
		/// <term>Meaning</term>
		/// </listheader>
		/// <item>
		/// <term>SW_ERASE</term>
		/// <term>
		/// Erases the newly invalidated region by sending a WM_ERASEBKGND message to the window when specified with the SW_INVALIDATE flag.
		/// </term>
		/// </item>
		/// <item>
		/// <term>SW_INVALIDATE</term>
		/// <term>Invalidates the region identified by the hrgnUpdate parameter after scrolling.</term>
		/// </item>
		/// <item>
		/// <term>SW_SCROLLCHILDREN</term>
		/// <term>
		/// Scrolls all child windows that intersect the rectangle pointed to by the prcScroll parameter. The child windows are scrolled by
		/// the number of pixels specified by the dx and dy parameters. The system sends a WM_MOVE message to all child windows that
		/// intersect the prcScroll rectangle, even if they do not move.
		/// </term>
		/// </item>
		/// <item>
		/// <term>SW_SMOOTHSCROLL</term>
		/// <term>
		/// Scrolls using smooth scrolling. Use the HIWORD portion of the flags parameter to indicate how much time, in milliseconds, the
		/// smooth-scrolling operation should take.
		/// </term>
		/// </item>
		/// </list>
		/// </param>
		/// <returns>
		/// <para>Type: <c>int</c></para>
		/// <para>
		/// If the function succeeds, the return value is SIMPLEREGION (rectangular invalidated region), COMPLEXREGION (nonrectangular
		/// invalidated region; overlapping rectangles), or NULLREGION (no invalidated region).
		/// </para>
		/// <para>If the function fails, the return value is ERROR. To get extended error information, call GetLastError.</para>
		/// </returns>
		/// <remarks>
		/// <para>
		/// If the SW_INVALIDATE and SW_ERASE flags are not specified, <c>ScrollWindowEx</c> does not invalidate the area that is scrolled
		/// from. If either of these flags is set, <c>ScrollWindowEx</c> invalidates this area. The area is not updated until the application
		/// calls the UpdateWindow function, calls the RedrawWindow function (specifying the RDW_UPDATENOW or RDW_ERASENOW flag), or
		/// retrieves the WM_PAINT message from the application queue.
		/// </para>
		/// <para>
		/// If the window has the WS_CLIPCHILDREN style, the returned areas specified by hrgnUpdate and prcUpdate represent the total area of
		/// the scrolled window that must be updated, including any areas in child windows that need updating.
		/// </para>
		/// <para>
		/// If the SW_SCROLLCHILDREN flag is specified, the system does not properly update the screen if part of a child window is scrolled.
		/// The part of the scrolled child window that lies outside the source rectangle is not erased and is not properly redrawn in its new
		/// destination. To move child windows that do not lie completely within the rectangle specified by prcScroll, use the DeferWindowPos
		/// function. The cursor is repositioned if the SW_SCROLLCHILDREN flag is set and the caret rectangle intersects the scroll rectangle.
		/// </para>
		/// <para>
		/// All input and output coordinates (for prcScroll, prcClip, prcUpdate, and hrgnUpdate) are determined as client coordinates,
		/// regardless of whether the window has the CS_OWNDC or CS_CLASSDC class style. Use the LPtoDP and DPtoLP functions to convert to
		/// and from logical coordinates, if necessary.
		/// </para>
		/// <para>Examples</para>
		/// <para>For an example, see Scrolling Text with the WM_PAINT Message.</para>
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows/desktop/api/winuser/nf-winuser-scrollwindowex int ScrollWindowEx( HWND hWnd, int dx, int
		// dy, const RECT *prcScroll, const RECT *prcClip, HRGN hrgnUpdate, LPRECT prcUpdate, UINT flags );
		[DllImport(Lib.User32, SetLastError = true, ExactSpelling = true)]
		[PInvokeData("winuser.h", MSDNShortId = "")]
		public static extern int ScrollWindowEx(HWND hWnd, int dx, int dy, PRECT prcScroll, PRECT prcClip, HRGN hrgnUpdate, out RECT prcUpdate, ScrollWindowFlags flags);

		/// <summary>
		/// The <c>SetScrollInfo</c> function sets the parameters of a scroll bar, including the minimum and maximum scrolling positions, the
		/// page size, and the position of the scroll box (thumb). The function also redraws the scroll bar, if requested.
		/// </summary>
		/// <param name="hwnd">
		/// <para>Type: <c>HWND</c></para>
		/// <para>Handle to a scroll bar control or a window with a standard scroll bar, depending on the value of the fnBar parameter.</para>
		/// </param>
		/// <param name="nBar">
		/// <para>Type: <c>int</c></para>
		/// <para>Specifies the type of scroll bar for which to set parameters. This parameter can be one of the following values.</para>
		/// <list type="table">
		/// <listheader>
		/// <term>Value</term>
		/// <term>Meaning</term>
		/// </listheader>
		/// <item>
		/// <term>SB_CTL</term>
		/// <term>Sets the parameters of a scroll bar control. The hwnd parameter must be the handle to the scroll bar control.</term>
		/// </item>
		/// <item>
		/// <term>SB_HORZ</term>
		/// <term>Sets the parameters of the window's standard horizontal scroll bar.</term>
		/// </item>
		/// <item>
		/// <term>SB_VERT</term>
		/// <term>Sets the parameters of the window's standard vertical scroll bar.</term>
		/// </item>
		/// </list>
		/// </param>
		/// <param name="lpsi">
		/// <para>Type: <c>LPCSCROLLINFO</c></para>
		/// <para>
		/// Pointer to a SCROLLINFO structure. Before calling <c>SetScrollInfo</c>, set the <c>cbSize</c> member of the structure to
		/// <c>sizeof</c>( <c>SCROLLINFO</c>), set the <c>fMask</c> member to indicate the parameters to set, and specify the new parameter
		/// values in the appropriate members.
		/// </para>
		/// <para>The <c>fMask</c> member can be one or more of the following values.</para>
		/// <list type="table">
		/// <listheader>
		/// <term>Value</term>
		/// <term>Meaning</term>
		/// </listheader>
		/// <item>
		/// <term>SIF_DISABLENOSCROLL</term>
		/// <term>Disables the scroll bar instead of removing it, if the scroll bar's new parameters make the scroll bar unnecessary.</term>
		/// </item>
		/// <item>
		/// <term>SIF_PAGE</term>
		/// <term>Sets the scroll page to the value specified in the nPage member of the SCROLLINFO structure pointed to by lpsi.</term>
		/// </item>
		/// <item>
		/// <term>SIF_POS</term>
		/// <term>Sets the scroll position to the value specified in the nPos member of the SCROLLINFO structure pointed to by lpsi.</term>
		/// </item>
		/// <item>
		/// <term>SIF_RANGE</term>
		/// <term>Sets the scroll range to the value specified in the nMin and nMax members of the SCROLLINFO structure pointed to by lpsi.</term>
		/// </item>
		/// </list>
		/// </param>
		/// <param name="redraw">
		/// <para>Type: <c>BOOL</c></para>
		/// <para>
		/// Specifies whether the scroll bar is redrawn to reflect the changes to the scroll bar. If this parameter is <c>TRUE</c>, the
		/// scroll bar is redrawn, otherwise, it is not redrawn.
		/// </para>
		/// </param>
		/// <returns>
		/// <para>Type: <c>int</c></para>
		/// <para>The return value is the current position of the scroll box.</para>
		/// </returns>
		/// <remarks>
		/// <para>
		/// The <c>SetScrollInfo</c> function performs range checking on the values specified by the <c>nPage</c> and <c>nPos</c> members of
		/// the SCROLLINFO structure. The <c>nPage</c> member must specify a value from 0 to <c>nMax</c> - <c>nMin</c> +1. The <c>nPos</c>
		/// member must specify a value between <c>nMin</c> and <c>nMax</c> - <c>max</c>( <c>nPage</c>– 1, 0). If either value is beyond its
		/// range, the function sets it to a value that is just within the range.
		/// </para>
		/// <para>
		/// If the fnBar parameter is SB_CTL and the window specified by the hwnd parameter is not a system scroll bar control, the system
		/// sends the SBM_SETSCROLLINFO message to the window to set scroll bar information (The system can optimize the message to
		/// SBM_SETPOS or SBM_SETRANGE if the request is solely for the position or range). This allows <c>SetScrollInfo</c> to operate on a
		/// custom control that mimics a scroll bar. If the window does not handle <c>SBM_SETSCROLLINFO</c> (or the optimized
		/// <c>SBM_SETPOS</c> message or <c>SBM_SETRANGE</c> message), then the <c>SetScrollInfo</c> function fails.
		/// </para>
		/// <para>For an example, see Scrolling Text with the WM_PAINT Message.</para>
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows/desktop/api/winuser/nf-winuser-setscrollinfo int SetScrollInfo( HWND hwnd, int nBar,
		// LPCSCROLLINFO lpsi, BOOL redraw );
		[DllImport(Lib.User32, SetLastError = false, ExactSpelling = true)]
		[PInvokeData("winuser.h", MSDNShortId = "")]
		public static extern int SetScrollInfo(HWND hwnd, int nBar, in SCROLLINFO lpsi, [MarshalAs(UnmanagedType.Bool)] bool redraw);

		/// <summary>
		/// <para>
		/// The <c>SetScrollPos</c> function sets the position of the scroll box (thumb) in the specified scroll bar and, if requested,
		/// redraws the scroll bar to reflect the new position of the scroll box.
		/// </para>
		/// <para>
		/// <c>Note</c> The <c>SetScrollPos</c> function is provided for backward compatibility. New applications should use the
		/// SetScrollInfo function.
		/// </para>
		/// </summary>
		/// <param name="hWnd">
		/// <para>Type: <c>HWND</c></para>
		/// <para>Handle to a scroll bar control or a window with a standard scroll bar, depending on the value of the nBar parameter.</para>
		/// </param>
		/// <param name="nBar">
		/// <para>Type: <c>int</c></para>
		/// <para>Specifies the scroll bar to be set. This parameter can be one of the following values.</para>
		/// <list type="table">
		/// <listheader>
		/// <term>Value</term>
		/// <term>Meaning</term>
		/// </listheader>
		/// <item>
		/// <term>SB_CTL</term>
		/// <term>Sets the position of the scroll box in a scroll bar control. The hwnd parameter must be the handle to the scroll bar control.</term>
		/// </item>
		/// <item>
		/// <term>SB_HORZ</term>
		/// <term>Sets the position of the scroll box in a window's standard horizontal scroll bar.</term>
		/// </item>
		/// <item>
		/// <term>SB_VERT</term>
		/// <term>Sets the position of the scroll box in a window's standard vertical scroll bar.</term>
		/// </item>
		/// </list>
		/// </param>
		/// <param name="nPos">
		/// <para>Type: <c>int</c></para>
		/// <para>
		/// Specifies the new position of the scroll box. The position must be within the scrolling range. For more information about the
		/// scrolling range, see the SetScrollRange function.
		/// </para>
		/// </param>
		/// <param name="bRedraw">
		/// <para>Type: <c>BOOL</c></para>
		/// <para>
		/// Specifies whether the scroll bar is redrawn to reflect the new scroll box position. If this parameter is <c>TRUE</c>, the scroll
		/// bar is redrawn. If it is <c>FALSE</c>, the scroll bar is not redrawn.
		/// </para>
		/// </param>
		/// <returns>
		/// <para>Type: <c>int</c></para>
		/// <para>If the function succeeds, the return value is the previous position of the scroll box.</para>
		/// <para>If the function fails, the return value is zero. To get extended error information, call GetLastError.</para>
		/// </returns>
		/// <remarks>
		/// <para>
		/// If the scroll bar is redrawn by a subsequent call to another function, setting the bRedraw parameter to <c>FALSE</c> is useful.
		/// </para>
		/// <para>
		/// Because the messages that indicate scroll bar position, WM_HSCROLL and WM_VSCROLL, are limited to 16 bits of position data,
		/// applications that rely solely on those messages for position data have a practical maximum value of 65,535 for the
		/// <c>SetScrollPos</c> function's nPos parameter.
		/// </para>
		/// <para>
		/// However, because the SetScrollInfo, <c>SetScrollPos</c>, SetScrollRange, GetScrollInfo, GetScrollPos, and GetScrollRange
		/// functions support 32-bit scroll bar position data, there is a way to circumvent the 16-bit barrier of the WM_HSCROLL and
		/// WM_VSCROLL messages. See <c>GetScrollInfo</c> for a description of the technique.
		/// </para>
		/// <para>
		/// If the nBar parameter is SB_CTL and the window specified by the hWnd parameter is not a system scroll bar control, the system
		/// sends the SBM_SETPOS message to the window to set scroll bar information. This allows <c>SetScrollPos</c> to operate on a custom
		/// control that mimics a scroll bar. If the window does not handle the <c>SBM_SETPOS</c> message, the <c>SetScrollPos</c> function fails.
		/// </para>
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows/desktop/api/winuser/nf-winuser-setscrollpos int SetScrollPos( HWND hWnd, int nBar, int
		// nPos, BOOL bRedraw );
		[DllImport(Lib.User32, SetLastError = true, ExactSpelling = true)]
		[PInvokeData("winuser.h", MSDNShortId = "")]
		public static extern int SetScrollPos(HWND hWnd, int nBar, int nPos, [MarshalAs(UnmanagedType.Bool)] bool bRedraw);

		/// <summary>
		/// <para>The <c>SetScrollRange</c> function sets the minimum and maximum scroll box positions for the specified scroll bar.</para>
		/// <para>
		/// <c>Note</c> The <c>SetScrollRange</c> function is provided for backward compatibility. New applications should use the
		/// SetScrollInfo function.
		/// </para>
		/// </summary>
		/// <param name="hWnd">
		/// <para>Type: <c>HWND</c></para>
		/// <para>Handle to a scroll bar control or a window with a standard scroll bar, depending on the value of the nBar parameter.</para>
		/// </param>
		/// <param name="nBar">
		/// <para>Type: <c>int</c></para>
		/// <para>Specifies the scroll bar to be set. This parameter can be one of the following values.</para>
		/// <list type="table">
		/// <listheader>
		/// <term>Value</term>
		/// <term>Meaning</term>
		/// </listheader>
		/// <item>
		/// <term>SB_CTL</term>
		/// <term>Sets the range of a scroll bar control. The hwnd parameter must be the handle to the scroll bar control.</term>
		/// </item>
		/// <item>
		/// <term>SB_HORZ</term>
		/// <term>Sets the range of a window's standard horizontal scroll bar.</term>
		/// </item>
		/// <item>
		/// <term>SB_VERT</term>
		/// <term>Sets the range of a window's standard vertical scroll bar.</term>
		/// </item>
		/// </list>
		/// </param>
		/// <param name="nMinPos">
		/// <para>Type: <c>int</c></para>
		/// <para>Specifies the minimum scrolling position.</para>
		/// </param>
		/// <param name="nMaxPos">
		/// <para>Type: <c>int</c></para>
		/// <para>Specifies the maximum scrolling position.</para>
		/// </param>
		/// <param name="bRedraw">
		/// <para>Type: <c>BOOL</c></para>
		/// <para>
		/// Specifies whether the scroll bar should be redrawn to reflect the change. If this parameter is <c>TRUE</c>, the scroll bar is
		/// redrawn. If it is <c>FALSE</c>, the scroll bar is not redrawn.
		/// </para>
		/// </param>
		/// <returns>
		/// <para>Type: <c>BOOL</c></para>
		/// <para>If the function succeeds, the return value is nonzero.</para>
		/// <para>If the function fails, the return value is zero. To get extended error information, call GetLastError.</para>
		/// </returns>
		/// <remarks>
		/// <para>
		/// You can use <c>SetScrollRange</c> to hide the scroll bar by setting nMinPos and nMaxPos to the same value. An application should
		/// not call the <c>SetScrollRange</c> function to hide a scroll bar while processing a scroll bar message. New applications should
		/// use the ShowScrollBar function to hide the scroll bar.
		/// </para>
		/// <para>
		/// If the call to <c>SetScrollRange</c> immediately follows a call to the SetScrollPos function, the bRedraw parameter in
		/// <c>SetScrollPos</c> must be zero to prevent the scroll bar from being drawn twice.
		/// </para>
		/// <para>
		/// The default range for a standard scroll bar is 0 through 100. The default range for a scroll bar control is empty (both the
		/// nMinPos and nMaxPos parameter values are zero). The difference between the values specified by the nMinPos and nMaxPos parameters
		/// must not be greater than the value of MAXLONG.
		/// </para>
		/// <para>
		/// Because the messages that indicate scroll bar position, WM_HSCROLL and WM_VSCROLL, are limited to 16 bits of position data,
		/// applications that rely solely on those messages for position data have a practical maximum value of 65,535 for the
		/// <c>SetScrollRange</c> function's nMaxPos parameter.
		/// </para>
		/// <para>
		/// However, because the SetScrollInfo, SetScrollPos, <c>SetScrollRange</c>, GetScrollInfo, GetScrollPos, and GetScrollRange
		/// functions support 32-bit scroll bar position data, there is a way to circumvent the 16-bit barrier of the WM_HSCROLL and
		/// WM_VSCROLL messages. See <c>GetScrollInfo</c> for a description of the technique.
		/// </para>
		/// <para>
		/// If the nBar parameter is SB_CTL and the window specified by the hWnd parameter is not a system scroll bar control, the system
		/// sends the SBM_SETRANGE message to the window to set scroll bar information. This allows <c>SetScrollRange</c> to operate on a
		/// custom control that mimics a scroll bar. If the window does not handle the <c>SBM_SETRANGE</c> message, the <c>SetScrollRange</c>
		/// function fails.
		/// </para>
		/// <para>Examples</para>
		/// <para>For an example, see Using the Owner-Display Clipboard Format.</para>
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows/desktop/api/winuser/nf-winuser-setscrollrange BOOL SetScrollRange( HWND hWnd, int nBar,
		// int nMinPos, int nMaxPos, BOOL bRedraw );
		[DllImport(Lib.User32, SetLastError = true, ExactSpelling = true)]
		[PInvokeData("winuser.h", MSDNShortId = "")]
		[return: MarshalAs(UnmanagedType.Bool)]
		public static extern bool SetScrollRange(HWND hWnd, int nBar, int nMinPos, int nMaxPos, [MarshalAs(UnmanagedType.Bool)] bool bRedraw);

		/// <summary>The <c>ShowScrollBar</c> function shows or hides the specified scroll bar.</summary>
		/// <param name="hWnd">
		/// <para>Type: <c>HWND</c></para>
		/// <para>Handle to a scroll bar control or a window with a standard scroll bar, depending on the value of the wBar parameter.</para>
		/// </param>
		/// <param name="wBar">
		/// <para>Type: <c>int</c></para>
		/// <para>Specifies the scroll bar(s) to be shown or hidden. This parameter can be one of the following values.</para>
		/// <list type="table">
		/// <listheader>
		/// <term>Value</term>
		/// <term>Meaning</term>
		/// </listheader>
		/// <item>
		/// <term>SB_BOTH</term>
		/// <term>Shows or hides a window's standard horizontal and vertical scroll bars.</term>
		/// </item>
		/// <item>
		/// <term>SB_CTL</term>
		/// <term>Shows or hides a scroll bar control. The hwnd parameter must be the handle to the scroll bar control.</term>
		/// </item>
		/// <item>
		/// <term>SB_HORZ</term>
		/// <term>Shows or hides a window's standard horizontal scroll bars.</term>
		/// </item>
		/// <item>
		/// <term>SB_VERT</term>
		/// <term>Shows or hides a window's standard vertical scroll bar.</term>
		/// </item>
		/// </list>
		/// </param>
		/// <param name="bShow">
		/// <para>Type: <c>BOOL</c></para>
		/// <para>
		/// Specifies whether the scroll bar is shown or hidden. If this parameter is <c>TRUE</c>, the scroll bar is shown; otherwise, it is hidden.
		/// </para>
		/// </param>
		/// <returns>
		/// <para>Type: <c>BOOL</c></para>
		/// <para>If the function succeeds, the return value is nonzero.</para>
		/// <para>If the function fails, the return value is zero. To get extended error information, call GetLastError.</para>
		/// </returns>
		/// <remarks>You should not call this function to hide a scroll bar while processing a scroll bar message.</remarks>
		// https://docs.microsoft.com/en-us/windows/desktop/api/winuser/nf-winuser-showscrollbar BOOL ShowScrollBar( HWND hWnd, int wBar,
		// BOOL bShow );
		[DllImport(Lib.User32, SetLastError = true, ExactSpelling = true)]
		[PInvokeData("winuser.h", MSDNShortId = "")]
		[return: MarshalAs(UnmanagedType.Bool)]
		public static extern bool ShowScrollBar(HWND hWnd, int wBar, [MarshalAs(UnmanagedType.Bool)] bool bShow);

		/// <summary>The <c>SCROLLBARINFO</c> structure contains scroll bar information.</summary>
		// https://docs.microsoft.com/en-us/windows/desktop/api/winuser/ns-winuser-tagscrollbarinfo typedef struct tagSCROLLBARINFO { DWORD
		// cbSize; RECT rcScrollBar; int dxyLineButton; int xyThumbTop; int xyThumbBottom; int reserved; DWORD rgstate[CCHILDREN_SCROLLBAR +
		// 1]; } SCROLLBARINFO, *PSCROLLBARINFO, *LPSCROLLBARINFO;
		[PInvokeData("winuser.h", MSDNShortId = "")]
		[StructLayout(LayoutKind.Sequential, CharSet = CharSet.Auto)]
		public struct SCROLLBARINFO
		{
			/// <summary>
			/// <para>Type: <c>DWORD</c></para>
			/// <para>
			/// Specifies the size, in bytes, of the structure. Before calling the GetScrollBarInfo function, set <c>cbSize</c> to
			/// <c>sizeof</c>( <c>SCROLLBARINFO</c>).
			/// </para>
			/// </summary>
			public uint cbSize;

			/// <summary>
			/// <para>Type: <c>RECT</c></para>
			/// <para>Coordinates of the scroll bar as specified in a RECT structure.</para>
			/// </summary>
			public RECT rcScrollBar;

			/// <summary>
			/// <para>Type: <c>int</c></para>
			/// <para>Height or width of the thumb.</para>
			/// </summary>
			public int dxyLineButton;

			/// <summary>
			/// <para>Type: <c>int</c></para>
			/// <para>Position of the top or left of the thumb.</para>
			/// </summary>
			public int xyThumbTop;

			/// <summary>
			/// <para>Type: <c>int</c></para>
			/// <para>Position of the bottom or right of the thumb.</para>
			/// </summary>
			public int xyThumbBottom;

			/// <summary>
			/// <para>Type: <c>int</c></para>
			/// <para>Reserved.</para>
			/// </summary>
			public int reserved;

			/// <summary>
			/// <para>Type: <c>DWORD[CCHILDREN_SCROLLBAR+1]</c></para>
			/// <para>
			/// An array of <c>DWORD</c> elements. Each element indicates the state of a scroll bar component. The following values show the
			/// scroll bar component that corresponds to each array index.
			/// </para>
			/// <list type="table">
			/// <listheader>
			/// <term>Index</term>
			/// <term>Scroll bar component</term>
			/// </listheader>
			/// <item>
			/// <term>0</term>
			/// <term>The scroll bar itself.</term>
			/// </item>
			/// <item>
			/// <term>1</term>
			/// <term>The top or right arrow button.</term>
			/// </item>
			/// <item>
			/// <term>2</term>
			/// <term>The page up or page right region.</term>
			/// </item>
			/// <item>
			/// <term>3</term>
			/// <term>The scroll box (thumb).</term>
			/// </item>
			/// <item>
			/// <term>4</term>
			/// <term>The page down or page left region.</term>
			/// </item>
			/// <item>
			/// <term>5</term>
			/// <term>The bottom or left arrow button.</term>
			/// </item>
			/// </list>
			/// <para>The <c>DWORD</c> element for each scroll bar component can include a combination of the following bit flags.</para>
			/// <list type="table">
			/// <listheader>
			/// <term>Value</term>
			/// <term>Meaning</term>
			/// </listheader>
			/// <item>
			/// <term>STATE_SYSTEM_INVISIBLE</term>
			/// <term>
			/// For the scroll bar itself, indicates the specified vertical or horizontal scroll bar does not exist. For the page up or page
			/// down regions, indicates the thumb is positioned such that the region does not exist.
			/// </term>
			/// </item>
			/// <item>
			/// <term>STATE_SYSTEM_OFFSCREEN</term>
			/// <term>
			/// For the scroll bar itself, indicates the window is sized such that the specified vertical or horizontal scroll bar is not
			/// currently displayed.
			/// </term>
			/// </item>
			/// <item>
			/// <term>STATE_SYSTEM_PRESSED</term>
			/// <term>The arrow button or page region is pressed.</term>
			/// </item>
			/// <item>
			/// <term>STATE_SYSTEM_UNAVAILABLE</term>
			/// <term>The component is disabled.</term>
			/// </item>
			/// </list>
			/// </summary>
			/// <value>The <see cref="System.UInt32"/>.</value>
			/// <returns></returns>
			[MarshalAs(UnmanagedType.ByValArray, SizeConst = 6)]
			public uint[] rgstate;
		}

		/// <summary>
		/// The <c>SCROLLINFO</c> structure contains scroll bar parameters to be set by the SetScrollInfo function (or SBM_SETSCROLLINFO
		/// message), or retrieved by the GetScrollInfo function (or SBM_GETSCROLLINFO message).
		/// </summary>
		// https://docs.microsoft.com/en-us/windows/desktop/api/winuser/ns-winuser-tagscrollinfo typedef struct tagSCROLLINFO { UINT cbSize;
		// UINT fMask; int nMin; int nMax; UINT nPage; int nPos; int nTrackPos; } SCROLLINFO, *LPSCROLLINFO;
		[PInvokeData("winuser.h", MSDNShortId = "")]
		[StructLayout(LayoutKind.Sequential, CharSet = CharSet.Auto)]
		public struct SCROLLINFO
		{
			/// <summary>
			/// <para>Type: <c>UINT</c></para>
			/// <para>Specifies the size, in bytes, of this structure. The caller must set this to sizeof( <c>SCROLLINFO</c>).</para>
			/// </summary>
			public uint cbSize;

			/// <summary>
			/// <para>Type: <c>UINT</c></para>
			/// <para>Specifies the scroll bar parameters to set or retrieve. This member can be a combination of the following values:</para>
			/// <list type="table">
			/// <listheader>
			/// <term>Value</term>
			/// <term>Meaning</term>
			/// </listheader>
			/// <item>
			/// <term>SIF_ALL</term>
			/// <term>Combination of SIF_PAGE, SIF_POS, SIF_RANGE, and SIF_TRACKPOS.</term>
			/// </item>
			/// <item>
			/// <term>SIF_DISABLENOSCROLL</term>
			/// <term>
			/// This value is used only when setting a scroll bar's parameters. If the scroll bar's new parameters make the scroll bar
			/// unnecessary, disable the scroll bar instead of removing it.
			/// </term>
			/// </item>
			/// <item>
			/// <term>SIF_PAGE</term>
			/// <term>The nPage member contains the page size for a proportional scroll bar.</term>
			/// </item>
			/// <item>
			/// <term>SIF_POS</term>
			/// <term>The nPos member contains the scroll box position, which is not updated while the user drags the scroll box.</term>
			/// </item>
			/// <item>
			/// <term>SIF_RANGE</term>
			/// <term>The nMin and nMax members contain the minimum and maximum values for the scrolling range.</term>
			/// </item>
			/// <item>
			/// <term>SIF_TRACKPOS</term>
			/// <term>The nTrackPos member contains the current position of the scroll box while the user is dragging it.</term>
			/// </item>
			/// </list>
			/// </summary>
			public SIF fMask;

			/// <summary>
			/// <para>Type: <c>int</c></para>
			/// <para>Specifies the minimum scrolling position.</para>
			/// </summary>
			public int nMin;

			/// <summary>
			/// <para>Type: <c>int</c></para>
			/// <para>Specifies the maximum scrolling position.</para>
			/// </summary>
			public int nMax;

			/// <summary>
			/// <para>Type: <c>UINT</c></para>
			/// <para>
			/// Specifies the page size, in device units. A scroll bar uses this value to determine the appropriate size of the proportional
			/// scroll box.
			/// </para>
			/// </summary>
			public uint nPage;

			/// <summary>
			/// <para>Type: <c>int</c></para>
			/// <para>Specifies the position of the scroll box.</para>
			/// </summary>
			public int nPos;

			/// <summary>
			/// <para>Type: <c>int</c></para>
			/// <para>
			/// Specifies the immediate position of a scroll box that the user is dragging. An application can retrieve this value while
			/// processing the SB_THUMBTRACK request code. An application cannot set the immediate scroll position; the SetScrollInfo
			/// function ignores this member.
			/// </para>
			/// </summary>
			public int nTrackPos;
		}
	}
}