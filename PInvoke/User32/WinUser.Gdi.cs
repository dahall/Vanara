using System;
using System.Diagnostics.CodeAnalysis;
using System.Drawing;
using System.Runtime.InteropServices;
using System.Text;
using static Vanara.PInvoke.Gdi32;
// ReSharper disable FieldCanBeMadeReadOnly.Global
// ReSharper disable InconsistentNaming

namespace Vanara.PInvoke
{
	public static partial class User32
	{
		public const int OCM_NOTIFY = 0x204E; // WM_NOTIFY + WM_REFLECT

		[UnmanagedFunctionPointer(CallingConvention.Winapi, CharSet = CharSet.Unicode)]
		public delegate IntPtr DialogProc(IntPtr hwndDlg, uint uMsg, IntPtr wParam, IntPtr lParam);

		/// <summary>
		/// For use with ChildWindowFromPointEx 
		/// </summary>
		[Flags]
		public enum ChildWindowSkipOptions
		{
			/// <summary>
			/// Does not skip any child windows
			/// </summary>
			CWP_ALL = 0x0000,
			/// <summary>
			/// Skips invisible child windows
			/// </summary>
			CWP_SKIPINVISIBLE = 0x0001,
			/// <summary>
			/// Skips disabled child windows
			/// </summary>
			CWP_SKIPDISABLED = 0x0002,
			/// <summary>
			/// Skips transparent child windows
			/// </summary>
			CWP_SKIPTRANSPARENT = 0x0004
		}

		[Flags]
		public enum CopyImageOptions
		{
			/// <summary>Returns the original hImage if it satisfies the criteria for the copy—that is, correct dimensions and color depth—in which case the LR_COPYDELETEORG flag is ignored. If this flag is not specified, a new object is always created.</summary>
			LR_COPYRETURNORG = 0x00000004,
			/// <summary>Deletes the original image after creating the copy.</summary>
			LR_COPYDELETEORG = 0x00000008,
			/// <summary>Tries to reload an icon or cursor resource from the original resource file rather than simply copying the current image. This is useful for creating a different-sized copy when the resource file contains multiple sizes of the resource. Without this flag, CopyImage stretches the original image to the new size. If this flag is set, CopyImage uses the size in the resource file closest to the desired size. This will succeed only if hImage was loaded by LoadIcon or LoadCursor, or by LoadImage with the LR_SHARED flag.</summary>
			LR_COPYFROMRESOURCE = 0x00004000,
			/// <summary>When the uType parameter specifies IMAGE_BITMAP, causes the function to return a DIB section bitmap rather than a compatible bitmap. This flag is useful for loading a bitmap without mapping it to the colors of the display device.</summary>
			LR_CREATEDIBSECTION = 0x00002000,
			/// <summary>Uses the width or height specified by the system metric values for cursors or icons, if the cxDesired or cyDesired values are set to zero. If this flag is not specified and cxDesired and cyDesired are set to zero, the function uses the actual resource size. If the resource contains multiple images, the function uses the size of the first image.</summary>
			LR_DEFAULTSIZE = 0x00000040,
			/// <summary>Loads the image in black and white.</summary>
			LR_MONOCHROME = 0x00000001,
		}

		/// <summary>
		/// Values to use a return codes when handling the WM_HCHITTEST message.
		/// </summary>
		public enum HitTestValues
		{
			/// <summary>In the border of a window that does not have a sizing border.</summary>
			HTBORDER = 18,

			/// <summary>In the lower-horizontal border of a resizable window (the user can click the mouse to resize the window vertically).</summary>
			HTBOTTOM = 15,

			/// <summary>In the lower-left corner of a border of a resizable window (the user can click the mouse to resize the window diagonally).</summary>
			HTBOTTOMLEFT = 16,

			/// <summary>In the lower-right corner of a border of a resizable window (the user can click the mouse to resize the window diagonally).</summary>
			HTBOTTOMRIGHT = 17,

			/// <summary>In a title bar.</summary>
			HTCAPTION = 2,

			/// <summary>In a client area.</summary>
			HTCLIENT = 1,

			/// <summary>In a Close button.</summary>
			HTCLOSE = 20,

			/// <summary>
			/// On the screen background or on a dividing line between windows (same as HTNOWHERE, except that the DefWindowProc function produces a system beep
			/// to indicate an error).
			/// </summary>
			HTERROR = -2,

			/// <summary>In a size box (same as HTSIZE).</summary>
			HTGROWBOX = 4,

			/// <summary>In a Help button.</summary>
			HTHELP = 21,

			/// <summary>In a horizontal scroll bar.</summary>
			HTHSCROLL = 6,

			/// <summary>In the left border of a resizable window (the user can click the mouse to resize the window horizontally).</summary>
			HTLEFT = 10,

			/// <summary>In a menu.</summary>
			HTMENU = 5,

			/// <summary>In a Maximize button.</summary>
			HTMAXBUTTON = 9,

			/// <summary>In a Minimize button.</summary>
			HTMINBUTTON = 8,

			/// <summary>On the screen background or on a dividing line between windows.</summary>
			HTNOWHERE = 0,

			/// <summary>Not implemented.</summary>
			/* HTOBJECT = 19, */

			/// <summary>In a Minimize button.</summary>
			HTREDUCE = HTMINBUTTON,

			/// <summary>In the right border of a resizable window (the user can click the mouse to resize the window horizontally).</summary>
			HTRIGHT = 11,

			/// <summary>In a size box (same as HTGROWBOX).</summary>
			HTSIZE = HTGROWBOX,

			/// <summary>In a window menu or in a Close button in a child window.</summary>
			HTSYSMENU = 3,

			/// <summary>In the upper-horizontal border of a window.</summary>
			HTTOP = 12,

			/// <summary>In the upper-left corner of a window border.</summary>
			HTTOPLEFT = 13,

			/// <summary>In the upper-right corner of a window border.</summary>
			HTTOPRIGHT = 14,

			/// <summary>
			/// In a window currently covered by another window in the same thread (the message will be sent to underlying windows in the same thread until one
			/// of them returns a code that is not HTTRANSPARENT).
			/// </summary>
			HTTRANSPARENT = -1,

			/// <summary>In the vertical scroll bar.</summary>
			HTVSCROLL = 7,

			/// <summary>In a Maximize button.</summary>
			HTZOOM = HTMAXBUTTON,
		}

		/// <summary>Window sizing and positioning flags.</summary>
		[Flags]
		public enum SetWindowPosFlags : uint
		{
			/// <summary>
			/// If the calling thread and the thread that owns the window are attached to different input queues, the
			/// system posts the request to the thread that owns the window. This prevents the calling thread from
			/// blocking its execution while other threads process the request.
			/// </summary>
			SWP_ASYNCWINDOWPOS = 0x4000,

			/// <summary>Prevents generation of the WM_SYNCPAINT message.</summary>
			SWP_DEFERERASE = 0x2000,

			/// <summary>Draws a frame (defined in the window's class description) around the window.</summary>
			SWP_DRAWFRAME = 0x0020,

			/// <summary>
			/// Applies new frame styles set using the SetWindowLong function. Sends a WM_NCCALCSIZE message to the
			/// window, even if the window's size is not being changed. If this flag is not specified, WM_NCCALCSIZE is
			/// sent only when the window's size is being changed.
			/// </summary>
			SWP_FRAMECHANGED = 0x0020,

			/// <summary>Hides the window.</summary>
			SWP_HIDEWINDOW = 0x0080,

			/// <summary>
			/// Does not activate the window. If this flag is not set, the window is activated and moved to the top of
			/// either the topmost or non-topmost group (depending on the setting of the hWndInsertAfter parameter).
			/// </summary>
			SWP_NOACTIVATE = 0x0010,

			/// <summary>
			/// Discards the entire contents of the client area. If this flag is not specified, the valid contents of the
			/// client area are saved and copied back into the client area after the window is sized or repositioned.
			/// </summary>
			SWP_NOCOPYBITS = 0x0100,

			/// <summary>Retains the current position (ignores X and Y parameters).</summary>
			SWP_NOMOVE = 0x0002,

			/// <summary>Does not change the owner window's position in the Z order.</summary>
			SWP_NOOWNERZORDER = 0x0200,

			/// <summary>
			/// Does not redraw changes. If this flag is set, no repainting of any kind occurs. This applies to the
			/// client area, the nonclient area (including the title bar and scroll bars), and any part of the parent
			/// window uncovered as a result of the window being moved. When this flag is set, the application must
			/// explicitly invalidate or redraw any parts of the window and parent window that need redrawing.
			/// </summary>
			SWP_NOREDRAW = 0x0008,

			/// <summary>Same as the SWP_NOOWNERZORDER flag.</summary>
			SWP_NOREPOSITION = 0x0200,

			/// <summary>Prevents the window from receiving the WM_WINDOWPOSCHANGING message.</summary>
			SWP_NOSENDCHANGING = 0x0400,

			/// <summary>Retains the current size (ignores the cx and cy parameters).</summary>
			SWP_NOSIZE = 0x0001,

			/// <summary>Retains the current Z order (ignores the hWndInsertAfter parameter).</summary>
			SWP_NOZORDER = 0x0004,

			/// <summary>Displays the window.</summary>
			SWP_SHOWWINDOW = 0x0040,
		}

		/// <summary>Flags used for <see cref="GetWindowLong"/> and <see cref="SetWindowLong"/> methods to retrieve information about a window.</summary>
		[Flags]
		public enum WindowLongFlags
		{
			/// <summary>The extended window styles</summary>
			GWL_EXSTYLE = -20,
			/// <summary>The application instance handle</summary>
			GWL_HINSTANCE = -6,
			/// <summary>The parent window handle</summary>
			GWL_HWNDPARENT = -8,
			/// <summary>The window identifier</summary>
			GWL_ID = -12,
			/// <summary>The window styles</summary>
			GWL_STYLE = -16,
			/// <summary>The window user data</summary>
			GWL_USERDATA = -21,
			/// <summary>The window procedure address or handle</summary>
			GWL_WNDPROC = -4,
			/// <summary>The dialog user data</summary>
			DWLP_USER = 0x8,
			/// <summary>The dialog procedure message result</summary>
			DWLP_MSGRESULT = 0x0,
			/// <summary>The dialog procedure address or handle</summary>
			DWLP_DLGPROC = 0x4
		}

		/// <summary>
		/// The DrawText function draws formatted text in the specified rectangle. It formats the text according to the specified method (expanding tabs, justifying characters, breaking lines, and so forth).
		/// </summary>
		/// <param name="hDC">A handle to the device context.</param>
		/// <param name="lpchText">A pointer to the string that specifies the text to be drawn. If the nCount parameter is -1, the string must be null-terminated. If uFormat includes DT_MODIFYSTRING, the function could add up to four additional characters to this string. The buffer containing the string should be large enough to accommodate these extra characters.</param>
		/// <param name="nCount">The length, in characters, of the string. If nCount is -1, then the lpchText parameter is assumed to be a pointer to a null-terminated string and DrawText computes the character count automatically.</param>
		/// <param name="lpRect">A pointer to a RECT structure that contains the rectangle (in logical coordinates) in which the text is to be formatted.</param>
		/// <param name="uFormat">The method of formatting the text.</param>
		/// <returns>If the function succeeds, the return value is the height of the text in logical units. If DT_VCENTER or DT_BOTTOM is specified, the return value is the offset from lpRect->top to the bottom of the drawn text. If the function fails, the return value is zero.</returns>
		[PInvokeData("WinUser.h", MSDNShortId = "dd162498")]
		[DllImport(Lib.User32, CharSet = CharSet.Auto, SetLastError = true)]
		public static extern int DrawText(SafeDCHandle hDC, string lpchText, int nCount, ref RECT lpRect, DrawTextFlags uFormat);

		/// <summary>
		/// Retrieves the coordinates of a window's client area. The client coordinates specify the upper-left and lower-right corners of the client area. Because client coordinates are relative to the upper-left corner of a window's client area, the coordinates of the upper-left corner are (0,0).
		/// </summary>
		/// <param name="hWnd">A handle to the window whose client coordinates are to be retrieved.</param>
		/// <param name="lpRect">A pointer to a RECT structure that receives the client coordinates. The left and top members are zero. The right and bottom members contain the width and height of the window.</param>
		/// <returns>If the function succeeds, the return value is true. If the function fails, the return value is false. To get extended error information, call GetLastError.</returns>
		[PInvokeData("WinUser.h", MSDNShortId = "ms633503")]
		[DllImport(Lib.User32, CharSet = CharSet.Auto, ExactSpelling = true, SetLastError = true)]
		[return: MarshalAs(UnmanagedType.Bool)]
		[System.Security.SecurityCritical]
		public static extern bool GetClientRect(HandleRef hWnd, [In, Out] ref RECT lpRect);

		/// <summary>
		/// Retrieves the dimensions of the bounding rectangle of the specified window. The dimensions are given in screen coordinates that are relative to the upper-left corner of the screen.
		/// </summary>
		/// <param name="hWnd">A handle to the window.</param>
		/// <param name="lpRect">A pointer to a RECT structure that receives the screen coordinates of the upper-left and lower-right corners of the window.</param>
		/// <returns>If the function succeeds, the return value is true. If the function fails, the return value is false. To get extended error information, call GetLastError.</returns>
		[PInvokeData("WinUser.h", MSDNShortId = "ms633519")]
		[DllImport(Lib.User32, ExactSpelling = true, SetLastError = true)]
		[return: MarshalAs(UnmanagedType.Bool)]
		[System.Security.SecurityCritical]
		public static extern bool GetWindowRect(HandleRef hWnd, out RECT lpRect);

		/// <summary>
		/// The InvalidateRect function adds a rectangle to the specified window's update region. The update region represents the portion of the window's client area that must be redrawn.
		/// </summary>
		/// <param name="hWnd">A handle to the window whose update region has changed. If this parameter is NULL, the system invalidates and redraws all windows, not just the windows for this application, and sends the WM_ERASEBKGND and WM_NCPAINT messages before the function returns. Setting this parameter to NULL is not recommended.</param>
		/// <param name="rect">A pointer to a RECT structure that contains the client coordinates of the rectangle to be added to the update region. If this parameter is NULL, the entire client area is added to the update region.</param>
		/// <param name="bErase">Specifies whether the background within the update region is to be erased when the update region is processed. If this parameter is TRUE, the background is erased when the BeginPaint function is called. If this parameter is FALSE, the background remains unchanged.</param>
		/// <returns>If the function succeeds, the return value is true. If the function fails, the return value is false. To get extended error information, call GetLastError.</returns>
		[PInvokeData("WinUser.h", MSDNShortId = "")]
		[DllImport(Lib.User32, ExactSpelling = true, SetLastError = true)]
		[return: MarshalAs(UnmanagedType.Bool)]
		[System.Security.SecurityCritical]
		public static extern bool InvalidateRect(HandleRef hWnd, [In] PRECT rect, [MarshalAs(UnmanagedType.Bool)] bool bErase);

		/// <summary>
		/// The MapWindowPoints function converts (maps) a set of points from a coordinate space relative to one window to a coordinate space relative to another window.
		/// </summary>
		/// <param name="hWndFrom">A handle to the window from which points are converted. If this parameter is NULL or HWND_DESKTOP, the points are presumed to be in screen coordinates.</param>
		/// <param name="hWndTo">A handle to the window to which points are converted. If this parameter is NULL or HWND_DESKTOP, the points are converted to screen coordinates.</param>
		/// <param name="lpPoints">A pointer to an array of POINT structures that contain the set of points to be converted. The points are in device units. This parameter can also point to a RECT structure, in which case the cPoints parameter should be set to 2.</param>
		/// <param name="cPoints">The number of POINT structures in the array pointed to by the lpPoints parameter.</param>
		/// <returns>If the function succeeds, the low-order word of the return value is the number of pixels added to the horizontal coordinate of each source point in order to compute the horizontal coordinate of each destination point. (In addition to that, if precisely one of hWndFrom and hWndTo is mirrored, then each resulting horizontal coordinate is multiplied by -1.) The high-order word is the number of pixels added to the vertical coordinate of each source point in order to compute the vertical coordinate of each destination point.
		/// <para>If the function fails, the return value is zero. Call SetLastError prior to calling this method to differentiate an error return value from a legitimate "0" return value.</para></returns>
		[PInvokeData("WinUser.h", MSDNShortId = "")]
		[DllImport(Lib.User32, ExactSpelling = true, SetLastError = true)]
		public static extern int MapWindowPoints(HandleRef hWndFrom, HandleRef hWndTo, [In, Out] ref RECT lpPoints, [MarshalAs(UnmanagedType.U4)] int cPoints);

		/// <summary>
		/// The MapWindowPoints function converts (maps) a set of points from a coordinate space relative to one window to a coordinate space relative to another window.
		/// </summary>
		/// <param name="hWndFrom">A handle to the window from which points are converted. If this parameter is NULL or HWND_DESKTOP, the points are presumed to be in screen coordinates.</param>
		/// <param name="hWndTo">A handle to the window to which points are converted. If this parameter is NULL or HWND_DESKTOP, the points are converted to screen coordinates.</param>
		/// <param name="lpPoints">A pointer to an array of POINT structures that contain the set of points to be converted. The points are in device units. This parameter can also point to a RECT structure, in which case the cPoints parameter should be set to 2.</param>
		/// <param name="cPoints">The number of POINT structures in the array pointed to by the lpPoints parameter.</param>
		/// <returns>If the function succeeds, the low-order word of the return value is the number of pixels added to the horizontal coordinate of each source point in order to compute the horizontal coordinate of each destination point. (In addition to that, if precisely one of hWndFrom and hWndTo is mirrored, then each resulting horizontal coordinate is multiplied by -1.) The high-order word is the number of pixels added to the vertical coordinate of each source point in order to compute the vertical coordinate of each destination point.
		/// <para>If the function fails, the return value is zero. Call SetLastError prior to calling this method to differentiate an error return value from a legitimate "0" return value.</para></returns>
		[PInvokeData("WinUser.h", MSDNShortId = "")]
		[DllImport(Lib.User32, ExactSpelling = true, SetLastError = true)]
		public static extern int MapWindowPoints(HandleRef hWndFrom, HandleRef hWndTo, [In, Out] ref Point lpPoints, [MarshalAs(UnmanagedType.U4)] int cPoints);

		/// <summary>
		/// The MapWindowPoints function converts (maps) a set of points from a coordinate space relative to one window to a coordinate space relative to another window.
		/// </summary>
		/// <param name="hWndFrom">A handle to the window from which points are converted. If this parameter is NULL or HWND_DESKTOP, the points are presumed to be in screen coordinates.</param>
		/// <param name="hWndTo">A handle to the window to which points are converted. If this parameter is NULL or HWND_DESKTOP, the points are converted to screen coordinates.</param>
		/// <param name="lpPoints">A pointer to an array of POINT structures that contain the set of points to be converted. The points are in device units. This parameter can also point to a RECT structure, in which case the cPoints parameter should be set to 2.</param>
		/// <param name="cPoints">The number of POINT structures in the array pointed to by the lpPoints parameter.</param>
		/// <returns>If the function succeeds, the low-order word of the return value is the number of pixels added to the horizontal coordinate of each source point in order to compute the horizontal coordinate of each destination point. (In addition to that, if precisely one of hWndFrom and hWndTo is mirrored, then each resulting horizontal coordinate is multiplied by -1.) The high-order word is the number of pixels added to the vertical coordinate of each source point in order to compute the vertical coordinate of each destination point.
		/// <para>If the function fails, the return value is zero. Call SetLastError prior to calling this method to differentiate an error return value from a legitimate "0" return value.</para></returns>
		[PInvokeData("WinUser.h", MSDNShortId = "")]
		[DllImport(Lib.User32, ExactSpelling = true, SetLastError = true)]
		public static extern int MapWindowPoints(HandleRef hWndFrom, HandleRef hWndTo, [MarshalAs(UnmanagedType.LPArray, SizeParamIndex = 3)] Point[] lpPoints, [MarshalAs(UnmanagedType.U4)] int cPoints);

		/// <summary>
		/// Sends the specified message to a window or windows. The SendMessage function calls the window procedure for the specified window and does not return until the window procedure has processed the message.
		/// </summary>
		/// <param name="hWnd">A handle to the window whose window procedure will receive the message. If this parameter is HWND_BROADCAST ((HWND)0xffff), the message is sent to all top-level windows in the system, including disabled or invisible unowned windows, overlapped windows, and pop-up windows; but the message is not sent to child windows.</param>
		/// <param name="msg">The message to be sent.</param>
		/// <param name="wParam">Additional message-specific information.</param>
		/// <param name="rect">Additional message-specific information.</param>
		/// <returns>The return value specifies the result of the message processing; it depends on the message sent.</returns>
		[PInvokeData("WinUser.h", MSDNShortId = "")]
		[DllImport(Lib.User32, CharSet = CharSet.Auto, SetLastError = false)]
		[System.Security.SecurityCritical]
		public static extern IntPtr SendMessage(HandleRef hWnd, uint msg, IntPtr wParam, ref RECT rect);

		/// <summary>
		/// Determines which, if any, of the child windows belonging to the specified parent window contains the specified point. The function can ignore invisible, disabled, and transparent child windows. The search is restricted to immediate child windows. Grandchildren and deeper descendants are not searched.
		/// </summary>
		/// <param name="hwndParent">A handle to the parent window.</param>
		/// <param name="pt">A structure that defines the client coordinates (relative to hwndParent) of the point to be checked.</param>
		/// <param name="uFlags">The child windows to be skipped. This parameter can be one or more of the following values.</param>
		/// <returns>The return value is a handle to the first child window that contains the point and meets the criteria specified by uFlags. If the point is within the parent window but not within any child window that meets the criteria, the return value is a handle to the parent window. If the point lies outside the parent window or if the function fails, the return value is NULL.</returns>
		[DllImport(Lib.User32, CharSet = CharSet.Auto, ExactSpelling = true)]
		[System.Security.SecurityCritical]
		public static extern IntPtr ChildWindowFromPointEx(HandleRef hwndParent, ref Point pt, ChildWindowSkipOptions uFlags);

		/// <summary>
		/// Destroys an icon and frees any memory the icon occupied.
		/// </summary>
		/// <param name="hIcon">A handle to the icon to be destroyed. The icon must not be in use.</param>
		/// <returns>If the function succeeds, the return value is true. If the function fails, the return value is false. To get extended error information, call GetLastError.</returns>
		[DllImport(Lib.User32, ExactSpelling = true, SetLastError = true)]
		[return: MarshalAs(UnmanagedType.Bool)]
		[System.Security.SecurityCritical]
		public static extern bool DestroyIcon(IntPtr hIcon);

		/// <summary>
		/// Retrieves the window handle to the active window attached to the calling thread's message queue.
		/// </summary>
		/// <returns>The return value is the handle to the active window attached to the calling thread's message queue. Otherwise, the return value is NULL.</returns>
		[DllImport(Lib.User32, ExactSpelling = true)]
		[System.Security.SecurityCritical]
		public static extern IntPtr GetActiveWindow();

		/// <summary>
		/// Retrieves information about the specified window. The function also retrieves the value at a specified offset into the extra window memory.
		/// </summary>
		/// <param name="hWnd">A handle to the window and, indirectly, the class to which the window belongs.</param>
		/// <param name="nIndex">The zero-based offset to the value to be retrieved. Valid values are in the range zero through the number of bytes of extra window memory, minus the size of an integer. To retrieve any other value, specify one of the following values.</param>
		/// <returns>If the function succeeds, the return value is the requested value. If the function fails, the return value is zero.To get extended error information, call GetLastError.</returns>
		public static IntPtr GetWindowLongAuto(HandleRef hWnd, int nIndex)
		{
			IntPtr ret;
			if (IntPtr.Size == 4)
				ret = (IntPtr)GetWindowLong(hWnd, nIndex);
			else
				ret = GetWindowLongPtr(hWnd, nIndex);
			if (ret == IntPtr.Zero)
				throw new System.ComponentModel.Win32Exception();
			return ret;
		}

		/// <summary>
		/// Retrieves information about the specified window. The function also retrieves the value at a specified offset into the extra window memory.
		/// </summary>
		/// <param name="hWnd">A handle to the window and, indirectly, the class to which the window belongs.</param>
		/// <param name="nIndex">The zero-based offset to the value to be retrieved. Valid values are in the range zero through the number of bytes of extra window memory, minus four; for example, if you specified 12 or more bytes of extra memory, a value of 8 would be an index to the third 32-bit integer. To retrieve any other value, specify one of the following values.</param>
		/// <returns>If the function succeeds, the return value is the requested value. If the function fails, the return value is zero.To get extended error information, call GetLastError.</returns>
		[DllImport(Lib.User32, CharSet = CharSet.Auto, SetLastError = true)]
		[SuppressMessage("Microsoft.Portability", "CA1901:PInvokeDeclarationsShouldBePortable", MessageId = "return", Justification = "This declaration is not used on 64-bit Windows.")]
		[SuppressMessage("Microsoft.Portability", "CA1901:PInvokeDeclarationsShouldBePortable", MessageId = "2", Justification = "This declaration is not used on 64-bit Windows.")]
		[System.Security.SecurityCritical]
		public static extern int GetWindowLong(HandleRef hWnd, int nIndex);

		/// <summary>
		/// Retrieves information about the specified window. The function also retrieves the value at a specified offset into the extra window memory.
		/// </summary>
		/// <param name="hWnd">A handle to the window and, indirectly, the class to which the window belongs.</param>
		/// <param name="nIndex">The zero-based offset to the value to be retrieved. Valid values are in the range zero through the number of bytes of extra window memory, minus the size of an integer. To retrieve any other value, specify one of the following values.</param>
		/// <returns>If the function succeeds, the return value is the requested value. If the function fails, the return value is zero.To get extended error information, call GetLastError.</returns>
		[DllImport(Lib.User32, CharSet = CharSet.Auto, SetLastError = true)]
		[SuppressMessage("Microsoft.Interoperability", "CA1400:PInvokeEntryPointsShouldExist", Justification = "Entry point does exist on 64-bit Windows.")]
		[System.Security.SecurityCritical]
		public static extern IntPtr GetWindowLongPtr(HandleRef hWnd, int nIndex);

		[DllImport(Lib.User32, CharSet = CharSet.Auto, SetLastError = true)]
		public static extern int RealGetWindowClass(HandleRef hwnd, System.Text.StringBuilder pszType, int cchType);

		/// <summary>
		/// Defines a new window message that is guaranteed to be unique throughout the system. The message value can be used when sending or posting messages.
		/// </summary>
		/// <param name="lpString">The message to be registered.</param>
		/// <returns>If the message is successfully registered, the return value is a message identifier in the range 0xC000 through 0xFFFF. If the function fails, the return value is zero. To get extended error information, call GetLastError.</returns>
		[DllImport(Lib.User32, SetLastError = true, CharSet = CharSet.Auto)]
		[System.Security.SecurityCritical]
		public static extern uint RegisterWindowMessage(string lpString);

		/// <summary>
		/// The ScreenToClient function converts the screen coordinates of a specified point on the screen to client-area coordinates.
		/// </summary>
		/// <param name="hWnd">A handle to the window whose client area will be used for the conversion.</param>
		/// <param name="lpPoint">A pointer to a POINT structure that specifies the screen coordinates to be converted.</param>
		/// <returns>If the function succeeds, the return value is true. If the function fails, the return value is false. To get extended error information, call GetLastError.</returns>
		[DllImport(Lib.User32, ExactSpelling = true, SetLastError = true)]
		[return: MarshalAs(UnmanagedType.Bool)]
		[System.Security.SecurityCritical]
		public static extern bool ScreenToClient(HandleRef hWnd, [In, Out] ref Point lpPoint);

		/// <summary>
		/// Sends the specified message to a window or windows. The SendMessage function calls the window procedure for the specified window and does not return until the window procedure has processed the message.
		/// </summary>
		/// <param name="hWnd">A handle to the window whose window procedure will receive the message. If this parameter is HWND_BROADCAST ((HWND)0xffff), the message is sent to all top-level windows in the system, including disabled or invisible unowned windows, overlapped windows, and pop-up windows; but the message is not sent to child windows.</param>
		/// <param name="msg">The message to be sent.</param>
		/// <param name="wParam">Additional message-specific information.</param>
		/// <param name="lParam">Additional message-specific information.</param>
		/// <returns>The return value specifies the result of the message processing; it depends on the message sent.</returns>
		[PInvokeData("Winuser.h", MSDNShortId = "ms644950")]
		[DllImport(Lib.User32, CharSet = CharSet.Auto, SetLastError = false)]
		[System.Security.SecurityCritical]
		public static extern IntPtr SendMessage(HandleRef hWnd, uint msg, IntPtr wParam, IntPtr lParam);

		/// <summary>
		/// Sends the specified message to a window or windows. The SendMessage function calls the window procedure for the specified window and does not return until the window procedure has processed the message.
		/// </summary>
		/// <param name="hWnd">A handle to the window whose window procedure will receive the message. If this parameter is HWND_BROADCAST ((HWND)0xffff), the message is sent to all top-level windows in the system, including disabled or invisible unowned windows, overlapped windows, and pop-up windows; but the message is not sent to child windows.</param>
		/// <param name="msg">The message to be sent.</param>
		/// <param name="wParam">Additional message-specific information.</param>
		/// <param name="lParam">Additional message-specific information.</param>
		/// <returns>The return value specifies the result of the message processing; it depends on the message sent.</returns>
		[PInvokeData("Winuser.h", MSDNShortId = "ms644950")]
		[DllImport(Lib.User32, CharSet = CharSet.Auto, SetLastError = false)]
		[System.Security.SecurityCritical]
		public static extern IntPtr SendMessage(HandleRef hWnd, uint msg, UIntPtr wParam, UIntPtr lParam);

		/// <summary>
		/// Sends the specified message to a window or windows. The SendMessage function calls the window procedure for the specified window and does not return until the window procedure has processed the message.
		/// </summary>
		/// <param name="hWnd">A handle to the window whose window procedure will receive the message. If this parameter is HWND_BROADCAST ((HWND)0xffff), the message is sent to all top-level windows in the system, including disabled or invisible unowned windows, overlapped windows, and pop-up windows; but the message is not sent to child windows.</param>
		/// <param name="msg">The message to be sent.</param>
		/// <param name="wParam">Additional message-specific information.</param>
		/// <param name="lParam">Additional message-specific information.</param>
		/// <returns>The return value specifies the result of the message processing; it depends on the message sent.</returns>
		[PInvokeData("Winuser.h", MSDNShortId = "ms644950")]
		public static IntPtr SendMessage(HandleRef hWnd, uint msg, int wParam = 0, int lParam = 0) => SendMessage(hWnd, msg, (IntPtr)wParam, (IntPtr)lParam);

		/// <summary>
		/// Sends the specified message to a window or windows. The SendMessage function calls the window procedure for the specified window and does not return until the window procedure has processed the message.
		/// </summary>
		/// <param name="hWnd">A handle to the window whose window procedure will receive the message. If this parameter is HWND_BROADCAST ((HWND)0xffff), the message is sent to all top-level windows in the system, including disabled or invisible unowned windows, overlapped windows, and pop-up windows; but the message is not sent to child windows.</param>
		/// <param name="msg">The message to be sent.</param>
		/// <param name="wParam">Additional message-specific information.</param>
		/// <param name="lParam">Additional message-specific information.</param>
		/// <returns>The return value specifies the result of the message processing; it depends on the message sent.</returns>
		[PInvokeData("Winuser.h", MSDNShortId = "ms644950")]
		public static IntPtr SendMessage(HandleRef hWnd, uint msg, int wParam, string lParam) => SendMessage(hWnd, msg, (IntPtr)wParam, lParam);

		/// <summary>
		/// Sends the specified message to a window or windows. The SendMessage function calls the window procedure for the specified window and does not return until the window procedure has processed the message.
		/// </summary>
		/// <param name="hWnd">A handle to the window whose window procedure will receive the message. If this parameter is HWND_BROADCAST ((HWND)0xffff), the message is sent to all top-level windows in the system, including disabled or invisible unowned windows, overlapped windows, and pop-up windows; but the message is not sent to child windows.</param>
		/// <param name="msg">The message to be sent.</param>
		/// <param name="wParam">Additional message-specific information.</param>
		/// <param name="lParam">Additional message-specific information.</param>
		/// <returns>The return value specifies the result of the message processing; it depends on the message sent.</returns>
		[PInvokeData("Winuser.h", MSDNShortId = "ms644950")]
		[DllImport(Lib.User32, CharSet = CharSet.Unicode, SetLastError = false)]
		[System.Security.SecurityCritical]
		public static extern IntPtr SendMessage(HandleRef hWnd, uint msg, IntPtr wParam, [In, MarshalAs(UnmanagedType.LPWStr)] string lParam);

		/// <summary>
		/// Sends the specified message to a window or windows. The SendMessage function calls the window procedure for the specified window and does not return until the window procedure has processed the message.
		/// </summary>
		/// <param name="hWnd">A handle to the window whose window procedure will receive the message. If this parameter is HWND_BROADCAST ((HWND)0xffff), the message is sent to all top-level windows in the system, including disabled or invisible unowned windows, overlapped windows, and pop-up windows; but the message is not sent to child windows.</param>
		/// <param name="msg">The message to be sent.</param>
		/// <param name="wParam">Additional message-specific information.</param>
		/// <param name="lParam">Additional message-specific information.</param>
		/// <returns>The return value specifies the result of the message processing; it depends on the message sent.</returns>
		[PInvokeData("Winuser.h", MSDNShortId = "ms644950")]
		[DllImport(Lib.User32, CharSet = CharSet.Auto, SetLastError = false)]
		[System.Security.SecurityCritical]
		public static extern IntPtr SendMessage(HandleRef hWnd, uint msg, ref int wParam, [In, Out] StringBuilder lParam);

		/// <summary>
		/// Changes an attribute of the specified window. The function also sets a value at the specified offset in the extra window memory.
		/// </summary>
		/// <param name="hWnd">A handle to the window and, indirectly, the class to which the window belongs. The SetWindowLongPtr function fails if the process that owns the window specified by the hWnd parameter is at a higher process privilege in the UIPI hierarchy than the process the calling thread resides in.</param>
		/// <param name="nIndex">The zero-based offset to the value to be set. Valid values are in the range zero through the number of bytes of extra window memory, minus the size of an integer. Alternately, this can be a value from <see cref="WindowLongFlags"/>.</param>
		/// <param name="dwNewLong">The replacement value.</param>
		/// <returns>If the function succeeds, the return value is the previous value of the specified offset. If the function fails, the return value is zero. To get extended error information, call GetLastError.
		/// <para>If the previous value is zero and the function succeeds, the return value is zero, but the function does not clear the last error information. To determine success or failure, clear the last error information by calling SetLastError with 0, then call SetWindowLongPtr. Function failure will be indicated by a return value of zero and a GetLastError result that is nonzero.</para></returns>
		public static IntPtr SetWindowLong(HandleRef hWnd, int nIndex, IntPtr dwNewLong)
		{
			IntPtr ret;
			if (IntPtr.Size == 4)
				ret = (IntPtr)SetWindowLongPtr32(hWnd, nIndex, dwNewLong);
			else
				ret = SetWindowLongPtr64(hWnd, nIndex, dwNewLong);
			if (ret == IntPtr.Zero)
				throw new System.ComponentModel.Win32Exception();
			return ret;
		}

		/// <summary>
		/// Changes the size, position, and Z order of a child, pop-up, or top-level window. These windows are ordered according to their appearance on the screen. The topmost window receives the highest rank and is the first window in the Z order.
		/// </summary>
		/// <param name="hWnd">A handle to the window.</param>
		/// <param name="hWndInsertAfter">A handle to the window to precede the positioned window in the Z order. This parameter must be a window handle or one of the following values.
		/// <list type="table">
		/// <listheader><term>Value</term><description>Meaning</description></listheader>
		/// <item><term><c>HWND_BOTTOM</c> (HWND)1</term><description>Places the window at the bottom of the Z order. If the hWnd parameter identifies a topmost window, the window loses its topmost status and is placed at the bottom of all other windows.</description></item>
		/// <item><term><c>HWND_NOTOPMOST</c> (HWND)-2</term><description>Places the window above all non-topmost windows (that is, behind all topmost windows). This flag has no effect if the window is already a non-topmost window.</description></item>
		/// <item><term><c>HWND_TOP</c> (HWND)0</term><description>Places the window at the top of the Z order.</description></item>
		/// <item><term><c>HWND_TOPMOST</c> (HWND)-1</term><description>Places the window above all non-topmost windows. The window maintains its topmost position even when it is deactivated.</description></item>
		/// </list>
		/// </param>
		/// <param name="X">The new position of the left side of the window, in client coordinates.</param>
		/// <param name="Y">The new position of the top of the window, in client coordinates.</param>
		/// <param name="cx">The new width of the window, in pixels.</param>
		/// <param name="cy">The new height of the window, in pixels.</param>
		/// <param name="uFlags">The window sizing and positioning flags.</param>
		/// <returns>If the function succeeds, the return value is true. If the function fails, the return value is false. To get extended error information, call GetLastError.</returns>
		[DllImport(Lib.User32, ExactSpelling = true, SetLastError = true)]
		[return: MarshalAs(UnmanagedType.Bool)]
		[System.Security.SecurityCritical]
		public static extern bool SetWindowPos(HandleRef hWnd, IntPtr hWndInsertAfter, int X, int Y, int cx, int cy, SetWindowPosFlags uFlags);

		/// <summary>
		/// Changes the text of the specified window's title bar (if it has one). If the specified window is a control, the text of the control is changed. However, SetWindowText cannot change the text of a control in another application.
		/// </summary>
		/// <param name="hWnd">A handle to the window or control whose text is to be changed.</param>
		/// <param name="lpString">The new title or control text.</param>
		/// <returns>If the function succeeds, the return value is true. If the function fails, the return value is false. To get extended error information, call GetLastError.</returns>
		[DllImport(Lib.User32, CharSet = CharSet.Auto, SetLastError = true)]
		[return: MarshalAs(UnmanagedType.Bool)]
		[System.Security.SecurityCritical]
		public static extern bool SetWindowText(HandleRef hWnd, string lpString);

		/// <summary>Retrieves a handle to the window that contains the specified point.</summary>
		/// <param name="Point">The point to be checked.</param>
		/// <returns>
		/// The return value is a handle to the window that contains the point. If no window exists at the given point, the return value is NULL. If the point is
		/// over a static text control, the return value is a handle to the window under the static text control.
		/// </returns>
		[DllImport(Lib.User32, ExactSpelling = true, SetLastError = true)]
		public static extern IntPtr WindowFromPoint(Point Point);

		/// <summary>
		/// Changes an attribute of the specified window. The function also sets a value at the specified offset in the extra window memory.
		/// </summary>
		/// <param name="hWnd">A handle to the window and, indirectly, the class to which the window belongs. The SetWindowLongPtr function fails if the process that owns the window specified by the hWnd parameter is at a higher process privilege in the UIPI hierarchy than the process the calling thread resides in.</param>
		/// <param name="nIndex">The zero-based offset to the value to be set. Valid values are in the range zero through the number of bytes of extra window memory, minus the size of an integer. Alternately, this can be a value from <see cref="WindowLongFlags"/>.</param>
		/// <param name="dwNewLong">The replacement value.</param>
		/// <returns>If the function succeeds, the return value is the previous value of the specified offset. If the function fails, the return value is zero. To get extended error information, call GetLastError.
		/// <para>If the previous value is zero and the function succeeds, the return value is zero, but the function does not clear the last error information. To determine success or failure, clear the last error information by calling SetLastError with 0, then call SetWindowLongPtr. Function failure will be indicated by a return value of zero and a GetLastError result that is nonzero.</para></returns>
		[DllImport(Lib.User32, SetLastError = true, EntryPoint = "SetWindowLong")]
		[SuppressMessage("Microsoft.Portability", "CA1901:PInvokeDeclarationsShouldBePortable", MessageId = "return", Justification = "This declaration is not used on 64-bit Windows.")]
		[SuppressMessage("Microsoft.Portability", "CA1901:PInvokeDeclarationsShouldBePortable", MessageId = "2", Justification = "This declaration is not used on 64-bit Windows.")]
		private static extern int SetWindowLongPtr32(HandleRef hWnd, int nIndex, IntPtr dwNewLong);

		/// <summary>
		/// Changes an attribute of the specified window. The function also sets a value at the specified offset in the extra window memory.
		/// </summary>
		/// <param name="hWnd">A handle to the window and, indirectly, the class to which the window belongs. The SetWindowLongPtr function fails if the process that owns the window specified by the hWnd parameter is at a higher process privilege in the UIPI hierarchy than the process the calling thread resides in.</param>
		/// <param name="nIndex">The zero-based offset to the value to be set. Valid values are in the range zero through the number of bytes of extra window memory, minus the size of an integer. Alternately, this can be a value from <see cref="WindowLongFlags"/>.</param>
		/// <param name="dwNewLong">The replacement value.</param>
		/// <returns>If the function succeeds, the return value is the previous value of the specified offset. If the function fails, the return value is zero. To get extended error information, call GetLastError.
		/// <para>If the previous value is zero and the function succeeds, the return value is zero, but the function does not clear the last error information. To determine success or failure, clear the last error information by calling SetLastError with 0, then call SetWindowLongPtr. Function failure will be indicated by a return value of zero and a GetLastError result that is nonzero.</para></returns>
		[DllImport(Lib.User32, SetLastError = true, EntryPoint = "SetWindowLongPtr")]
		[SuppressMessage("Microsoft.Interoperability", "CA1400:PInvokeEntryPointsShouldExist", Justification = "Entry point does exist on 64-bit Windows.")]
		private static extern IntPtr SetWindowLongPtr64(HandleRef hWnd, int nIndex, IntPtr dwNewLong);

		/// <summary>Contains information about a window's maximized size and position and its minimum and maximum tracking size.</summary>
		[StructLayout(LayoutKind.Sequential)]
		public struct MINMAXINFO
		{
			/// <summary>Reserved; do not use.</summary>
			public Point reserved;
			/// <summary>
			/// The maximized width (x member) and the maximized height (y member) of the window. For top-level windows, this value is based on the width of the
			/// primary monitor.
			/// </summary>
			public Size maxSize;
			/// <summary>
			/// The position of the left side of the maximized window (x member) and the position of the top of the maximized window (y member). For top-level
			/// windows, this value is based on the position of the primary monitor.
			/// </summary>
			public Point maxPosition;
			/// <summary>
			/// The minimum tracking width (x member) and the minimum tracking height (y member) of the window. This value can be obtained programmatically from
			/// the system metrics SM_CXMINTRACK and SM_CYMINTRACK (see the GetSystemMetrics function).
			/// </summary>
			public Size minTrackSize;
			/// <summary>
			/// The maximum tracking width (x member) and the maximum tracking height (y member) of the window. This value is based on the size of the virtual
			/// screen and can be obtained programmatically from the system metrics SM_CXMAXTRACK and SM_CYMAXTRACK (see the GetSystemMetrics function).
			/// </summary>
			public Size maxTrackSize;
		}

		/// <summary>
		/// Contains information about the size and position of a window.
		/// </summary>
		[StructLayout(LayoutKind.Sequential)]
		public struct WINDOWPOS
		{
			/// <summary>A handle to the window.</summary>
			public IntPtr hwnd;
			/// <summary>The position of the window in Z order (front-to-back position). This member can be a handle to the window behind which this window is placed, or can be one of the special values listed with the SetWindowPos function.</summary>
			public IntPtr hwndInsertAfter;
			/// <summary>The position of the left edge of the window.</summary>
			public int x;
			/// <summary>The position of the top edge of the window.</summary>
			public int y;
			/// <summary>The window width, in pixels.</summary>
			public int cx;
			/// <summary>The window height, in pixels.</summary>
			public int cy;
			/// <summary>The window position. This member can be one or more of the following values.</summary>
			public SetWindowPosFlags flags;
		}

		/// <summary>Special window handles</summary>
		public static class SpecialWindowHandles
		{
			/// <summary>
			/// Places the window at the bottom of the Z order. If the hWnd parameter identifies a topmost window, the
			/// window loses its topmost status and is placed at the bottom of all other windows.
			/// </summary>
			public static IntPtr HWND_BOTTOM = new IntPtr(1);

			/// <summary>
			/// Places the window above all non-topmost windows (that is, behind all topmost windows). This flag has no
			/// effect if the window is already a non-topmost window.
			/// </summary>
			public static IntPtr HWND_NOTOPMOST = new IntPtr(-2);

			/// <summary>Places the window at the top of the Z order.</summary>
			public static IntPtr HWND_TOP = new IntPtr(0);

			/// <summary>
			/// Places the window above all non-topmost windows. The window maintains its topmost position even when it
			/// is deactivated.
			/// </summary>
			public static IntPtr HWND_TOPMOST = new IntPtr(-1);
		}
	}
}