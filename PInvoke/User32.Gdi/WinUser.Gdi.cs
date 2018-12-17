using System;
using System.Diagnostics.CodeAnalysis;
using System.Drawing;
using System.Runtime.InteropServices;
using System.Text;
using Vanara.InteropServices;
using static Vanara.PInvoke.Gdi32;

namespace Vanara.PInvoke
{
	/// <summary>User32.dll function with GDI params.</summary>
	public static partial class User32_Gdi
	{
		public const int OCM_NOTIFY = 0x204E; // WM_NOTIFY + WM_REFLECT

		/// <summary>Flags used by the <see cref="DrawEdge"/> method.</summary>
		[PInvokeData("WinUser.h")]
		[Flags]
		public enum BorderFlags : uint
		{
			/// <summary>Left side of border rectangle.</summary>
			BF_LEFT = 0x0001,

			/// <summary>Top of border rectangle.</summary>
			BF_TOP = 0x0002,

			/// <summary>Right side of border rectangle.</summary>
			BF_RIGHT = 0x0004,

			/// <summary>Bottom of border rectangle.</summary>
			BF_BOTTOM = 0x0008,

			/// <summary>Top and left side of border rectangle.</summary>
			BF_TOPLEFT = (BF_TOP | BF_LEFT),

			/// <summary>Top and right side of border rectangle.</summary>
			BF_TOPRIGHT = (BF_TOP | BF_RIGHT),

			/// <summary>Bottom and left side of border rectangle.</summary>
			BF_BOTTOMLEFT = (BF_BOTTOM | BF_LEFT),

			/// <summary>Bottom and right side of border rectangle.</summary>
			BF_BOTTOMRIGHT = (BF_BOTTOM | BF_RIGHT),

			/// <summary>Entire border rectangle.</summary>
			BF_RECT = (BF_LEFT | BF_TOP | BF_RIGHT | BF_BOTTOM),

			/// <summary>Diagonal border.</summary>
			BF_DIAGONAL = 0x0010,

			/// <summary>Diagonal border. The end point is the top-right corner of the rectangle; the origin is lower-left corner.</summary>
			BF_DIAGONAL_ENDTOPRIGHT = (BF_DIAGONAL | BF_TOP | BF_RIGHT),

			/// <summary>Diagonal border. The end point is the top-left corner of the rectangle; the origin is lower-right corner.</summary>
			BF_DIAGONAL_ENDTOPLEFT = (BF_DIAGONAL | BF_TOP | BF_LEFT),

			/// <summary>Diagonal border. The end point is the lower-left corner of the rectangle; the origin is top-right corner.</summary>
			BF_DIAGONAL_ENDBOTTOMLEFT = (BF_DIAGONAL | BF_BOTTOM | BF_LEFT),

			/// <summary>Diagonal border. The end point is the lower-right corner of the rectangle; the origin is top-left corner.</summary>
			BF_DIAGONAL_ENDBOTTOMRIGHT = (BF_DIAGONAL | BF_BOTTOM | BF_RIGHT),

			/// <summary>Interior of rectangle to be filled.</summary>
			BF_MIDDLE = 0x0800,

			/// <summary>Soft buttons instead of tiles.</summary>
			BF_SOFT = 0x1000,

			/// <summary>
			/// The rectangle pointed to by the pDestRect parameter is shrunk to exclude the edges that were drawn; otherwise the rectangle
			/// does not change.
			/// </summary>
			BF_ADJUST = 0x2000,

			/// <summary>Flat border.</summary>
			BF_FLAT = 0x4000,

			/// <summary>One-dimensional border.</summary>
			BF_MONO = 0x8000,
		}

		/// <summary>Styles used by the <see cref="DrawEdge"/> method.</summary>
		[PInvokeData("WinUser.h")]
		[Flags]
		public enum BorderStyles3D : uint
		{
			/// <summary>Raised outer edge</summary>
			BDR_RAISEDOUTER = 0x0001,

			/// <summary>Sunken outer edge</summary>
			BDR_SUNKENOUTER = 0x0002,

			/// <summary>Raised inner edge</summary>
			BDR_RAISEDINNER = 0x0004,

			/// <summary>Sunken inner edge</summary>
			BDR_SUNKENINNER = 0x0008,

			/// <summary>Combination of BDR_RAISEDOUTER and BDR_SUNKENINNER</summary>
			BDR_OUTER = (BDR_RAISEDOUTER | BDR_SUNKENOUTER),

			/// <summary>Combination of BDR_RAISEDINNER and BDR_SUNKENINNER</summary>
			BDR_INNER = (BDR_RAISEDINNER | BDR_SUNKENINNER),

			/// <summary>Combination of BDR_RAISEDOUTER and BDR_RAISEDINNER</summary>
			BDR_RAISED = (BDR_RAISEDOUTER | BDR_RAISEDINNER),

			/// <summary>Combination of BDR_SUNKENOUTER and BDR_SUNKENINNER</summary>
			BDR_SUNKEN = (BDR_SUNKENOUTER | BDR_SUNKENINNER),

			/// <summary>Combination of BDR_RAISEDOUTER and BDR_RAISEDINNER</summary>
			EDGE_RAISED = (BDR_RAISEDOUTER | BDR_RAISEDINNER),

			/// <summary>Combination of BDR_SUNKENOUTER and BDR_SUNKENINNER</summary>
			EDGE_SUNKEN = (BDR_SUNKENOUTER | BDR_SUNKENINNER),

			/// <summary>Combination of BDR_SUNKENOUTER and BDR_RAISEDINNER</summary>
			EDGE_ETCHED = (BDR_SUNKENOUTER | BDR_RAISEDINNER),

			/// <summary>Combination of BDR_RAISEDOUTER and BDR_SUNKENINNER</summary>
			EDGE_BUMP = (BDR_RAISEDOUTER | BDR_SUNKENINNER),
		}

		[Flags]
		public enum CopyImageOptions
		{
			/// <summary>
			/// Returns the original hImage if it satisfies the criteria for the copy—that is, correct dimensions and color depth—in which
			/// case the LR_COPYDELETEORG flag is ignored. If this flag is not specified, a new object is always created.
			/// </summary>
			LR_COPYRETURNORG = 0x00000004,

			/// <summary>Deletes the original image after creating the copy.</summary>
			LR_COPYDELETEORG = 0x00000008,

			/// <summary>
			/// Tries to reload an icon or cursor resource from the original resource file rather than simply copying the current image. This
			/// is useful for creating a different-sized copy when the resource file contains multiple sizes of the resource. Without this
			/// flag, CopyImage stretches the original image to the new size. If this flag is set, CopyImage uses the size in the resource
			/// file closest to the desired size. This will succeed only if hImage was loaded by LoadIcon or LoadCursor, or by LoadImage with
			/// the LR_SHARED flag.
			/// </summary>
			LR_COPYFROMRESOURCE = 0x00004000,

			/// <summary>
			/// When the uType parameter specifies IMAGE_BITMAP, causes the function to return a DIB section bitmap rather than a compatible
			/// bitmap. This flag is useful for loading a bitmap without mapping it to the colors of the display device.
			/// </summary>
			LR_CREATEDIBSECTION = 0x00002000,

			/// <summary>
			/// Uses the width or height specified by the system metric values for cursors or icons, if the cxDesired or cyDesired values are
			/// set to zero. If this flag is not specified and cxDesired and cyDesired are set to zero, the function uses the actual resource
			/// size. If the resource contains multiple images, the function uses the size of the first image.
			/// </summary>
			LR_DEFAULTSIZE = 0x00000040,

			/// <summary>Loads the image in black and white.</summary>
			LR_MONOCHROME = 0x00000001,
		}

		/// <summary>Values to use a return codes when handling the WM_HCHITTEST message.</summary>
		public enum HitTestValues : short
		{
			/// <summary>In the border of a window that does not have a sizing border.</summary>
			HTBORDER = 18,

			/// <summary>In the lower-horizontal border of a resizable window (the user can click the mouse to resize the window vertically).</summary>
			HTBOTTOM = 15,

			/// <summary>
			/// In the lower-left corner of a border of a resizable window (the user can click the mouse to resize the window diagonally).
			/// </summary>
			HTBOTTOMLEFT = 16,

			/// <summary>
			/// In the lower-right corner of a border of a resizable window (the user can click the mouse to resize the window diagonally).
			/// </summary>
			HTBOTTOMRIGHT = 17,

			/// <summary>In a title bar.</summary>
			HTCAPTION = 2,

			/// <summary>In a client area.</summary>
			HTCLIENT = 1,

			/// <summary>In a Close button.</summary>
			HTCLOSE = 20,

			/// <summary>
			/// On the screen background or on a dividing line between windows (same as HTNOWHERE, except that the DefWindowProc function
			/// produces a system beep to indicate an error).
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

			/* /// <summary>Not implemented.</summary>
			HTOBJECT = 19, */

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
			/// In a window currently covered by another window in the same thread (the message will be sent to underlying windows in the
			/// same thread until one of them returns a code that is not HTTRANSPARENT).
			/// </summary>
			HTTRANSPARENT = -1,

			/// <summary>In the vertical scroll bar.</summary>
			HTVSCROLL = 7,

			/// <summary>In a Maximize button.</summary>
			HTZOOM = HTMAXBUTTON,
		}

		/// <summary>
		/// Flags used for <see cref="GetWindowLong"/> and <see cref="SetWindowLong"/> methods to retrieve information about a window.
		/// </summary>
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

		/// <summary>The <c>DrawEdge</c> function draws one or more edges of rectangle.</summary>
		/// <param name="hdc">A handle to the device context.</param>
		/// <param name="qrc">A pointer to a <c>RECT</c> structure that contains the logical coordinates of the rectangle.</param>
		/// <param name="edge">
		/// <para>
		/// The type of inner and outer edges to draw. This parameter must be a combination of one inner-border flag and one outer-border
		/// flag. The inner-border flags are as follows.
		/// </para>
		/// <para>
		/// <list type="table">
		/// <listheader>
		/// <term>Value</term>
		/// <term>Meaning</term>
		/// </listheader>
		/// <item>
		/// <term>BDR_RAISEDINNER</term>
		/// <term>Raised inner edge.</term>
		/// </item>
		/// <item>
		/// <term>BDR_SUNKENINNER</term>
		/// <term>Sunken inner edge.</term>
		/// </item>
		/// </list>
		/// </para>
		/// <para>The outer-border flags are as follows.</para>
		/// <para>
		/// <list type="table">
		/// <listheader>
		/// <term>Value</term>
		/// <term>Meaning</term>
		/// </listheader>
		/// <item>
		/// <term>BDR_RAISEDOUTER</term>
		/// <term>Raised outer edge.</term>
		/// </item>
		/// <item>
		/// <term>BDR_SUNKENOUTER</term>
		/// <term>Sunken outer edge.</term>
		/// </item>
		/// </list>
		/// </para>
		/// <para>Alternatively, the edge parameter can specify one of the following flags.</para>
		/// <para>
		/// <list type="table">
		/// <listheader>
		/// <term>Value</term>
		/// <term>Meaning</term>
		/// </listheader>
		/// <item>
		/// <term>EDGE_BUMP</term>
		/// <term>Combination of BDR_RAISEDOUTER and BDR_SUNKENINNER.</term>
		/// </item>
		/// <item>
		/// <term>EDGE_ETCHED</term>
		/// <term>Combination of BDR_SUNKENOUTER and BDR_RAISEDINNER.</term>
		/// </item>
		/// <item>
		/// <term>EDGE_RAISED</term>
		/// <term>Combination of BDR_RAISEDOUTER and BDR_RAISEDINNER.</term>
		/// </item>
		/// <item>
		/// <term>EDGE_SUNKEN</term>
		/// <term>Combination of BDR_SUNKENOUTER and BDR_SUNKENINNER.</term>
		/// </item>
		/// </list>
		/// </para>
		/// </param>
		/// <param name="grfFlags">
		/// <para>The type of border. This parameter can be a combination of the following values.</para>
		/// <para>
		/// <list type="table">
		/// <listheader>
		/// <term>Value</term>
		/// <term>Meaning</term>
		/// </listheader>
		/// <item>
		/// <term>BF_ADJUST</term>
		/// <term>
		/// If this flag is passed, shrink the rectangle pointed to by the qrc parameter to exclude the edges that were drawn.If this flag is
		/// not passed, then do not change the rectangle pointed to by the qrc parameter.
		/// </term>
		/// </item>
		/// <item>
		/// <term>BF_BOTTOM</term>
		/// <term>Bottom of border rectangle.</term>
		/// </item>
		/// <item>
		/// <term>BF_BOTTOMLEFT</term>
		/// <term>Bottom and left side of border rectangle.</term>
		/// </item>
		/// <item>
		/// <term>BF_BOTTOMRIGHT</term>
		/// <term>Bottom and right side of border rectangle.</term>
		/// </item>
		/// <item>
		/// <term>BF_DIAGONAL</term>
		/// <term>Diagonal border.</term>
		/// </item>
		/// <item>
		/// <term>BF_DIAGONAL_ENDBOTTOMLEFT</term>
		/// <term>Diagonal border. The end point is the lower-left corner of the rectangle; the origin is top-right corner.</term>
		/// </item>
		/// <item>
		/// <term>BF_DIAGONAL_ENDBOTTOMRIGHT</term>
		/// <term>Diagonal border. The end point is the lower-right corner of the rectangle; the origin is top-left corner.</term>
		/// </item>
		/// <item>
		/// <term>BF_DIAGONAL_ENDTOPLEFT</term>
		/// <term>Diagonal border. The end point is the top-left corner of the rectangle; the origin is lower-right corner.</term>
		/// </item>
		/// <item>
		/// <term>BF_DIAGONAL_ENDTOPRIGHT</term>
		/// <term>Diagonal border. The end point is the top-right corner of the rectangle; the origin is lower-left corner.</term>
		/// </item>
		/// <item>
		/// <term>BF_FLAT</term>
		/// <term>Flat border.</term>
		/// </item>
		/// <item>
		/// <term>BF_LEFT</term>
		/// <term>Left side of border rectangle.</term>
		/// </item>
		/// <item>
		/// <term>BF_MIDDLE</term>
		/// <term>Interior of rectangle to be filled.</term>
		/// </item>
		/// <item>
		/// <term>BF_MONO</term>
		/// <term>One-dimensional border.</term>
		/// </item>
		/// <item>
		/// <term>BF_RECT</term>
		/// <term>Entire border rectangle.</term>
		/// </item>
		/// <item>
		/// <term>BF_RIGHT</term>
		/// <term>Right side of border rectangle.</term>
		/// </item>
		/// <item>
		/// <term>BF_SOFT</term>
		/// <term>Soft buttons instead of tiles.</term>
		/// </item>
		/// <item>
		/// <term>BF_TOP</term>
		/// <term>Top of border rectangle.</term>
		/// </item>
		/// <item>
		/// <term>BF_TOPLEFT</term>
		/// <term>Top and left side of border rectangle.</term>
		/// </item>
		/// <item>
		/// <term>BF_TOPRIGHT</term>
		/// <term>Top and right side of border rectangle.</term>
		/// </item>
		/// </list>
		/// </para>
		/// </param>
		/// <returns>
		/// <para>If the function succeeds, the return value is nonzero.</para>
		/// <para>If the function fails, the return value is zero.</para>
		/// </returns>
		// BOOL DrawEdge( _In_ HDC hdc, _Inout_ LPRECT qrc, _In_ UINT edge, _In_ UINT grfFlags); https://msdn.microsoft.com/en-us/library/windows/desktop/dd162477(v=vs.85).aspx
		[DllImport(Lib.User32, SetLastError = false, ExactSpelling = true)]
		[PInvokeData("Winuser.h", MSDNShortId = "dd162477")]
		public static extern bool DrawEdge(HDC hdc, ref RECT qrc, BorderStyles3D edge, BorderFlags grfFlags);

		/// <summary>
		/// The DrawText function draws formatted text in the specified rectangle. It formats the text according to the specified method
		/// (expanding tabs, justifying characters, breaking lines, and so forth).
		/// </summary>
		/// <param name="hDC">A handle to the device context.</param>
		/// <param name="lpchText">
		/// A pointer to the string that specifies the text to be drawn. If the nCount parameter is -1, the string must be null-terminated.
		/// If uFormat includes DT_MODIFYSTRING, the function could add up to four additional characters to this string. The buffer
		/// containing the string should be large enough to accommodate these extra characters.
		/// </param>
		/// <param name="nCount">
		/// The length, in characters, of the string. If nCount is -1, then the lpchText parameter is assumed to be a pointer to a
		/// null-terminated string and DrawText computes the character count automatically.
		/// </param>
		/// <param name="lpRect">
		/// A pointer to a RECT structure that contains the rectangle (in logical coordinates) in which the text is to be formatted.
		/// </param>
		/// <param name="uFormat">The method of formatting the text.</param>
		/// <returns>
		/// If the function succeeds, the return value is the height of the text in logical units. If DT_VCENTER or DT_BOTTOM is specified,
		/// the return value is the offset from lpRect-&gt;top to the bottom of the drawn text. If the function fails, the return value is zero.
		/// </returns>
		[PInvokeData("WinUser.h", MSDNShortId = "dd162498")]
		[DllImport(Lib.User32, CharSet = CharSet.Auto, SetLastError = true)]
		public static extern int DrawText(HDC hDC, string lpchText, int nCount, ref RECT lpRect, DrawTextFlags uFormat);

		/// <summary>
		/// The GetDC function retrieves a handle to a device context (DC) for the client area of a specified window or for the entire
		/// screen. You can use the returned handle in subsequent GDI functions to draw in the DC. The device context is an opaque data
		/// structure, whose values are used internally by GDI.
		/// </summary>
		/// <param name="ptr">
		/// A handle to the window whose DC is to be retrieved. If this value is NULL, GetDC retrieves the DC for the entire screen.
		/// </param>
		/// <returns>
		/// If the function succeeds, the return value is a handle to the DC for the specified window's client area. If the function fails,
		/// the return value is NULL.
		/// </returns>
		// https://msdn.microsoft.com/en-us/library/windows/desktop/dd144871(v=vs.85).aspx
		[DllImport(Lib.User32, SetLastError = false, ExactSpelling = true)]
		[PInvokeData("Winuser.h", MSDNShortId = "dd144871")]
		public static extern SafeHDC GetDC(HWND ptr);

		/// <summary>
		/// Retrieves the current color of the specified display element. Display elements are the parts of a window and the display that
		/// appear on the system display screen.
		/// </summary>
		/// <param name="nIndex">The display element whose color is to be retrieved.</param>
		/// <returns>
		/// The function returns the red, green, blue (RGB) color value of the given element.
		/// <para>
		/// If the nIndex parameter is out of range, the return value is zero.Because zero is also a valid RGB value, you cannot use
		/// GetSysColor to determine whether a system color is supported by the current platform.Instead, use the GetSysColorBrush function,
		/// which returns NULL if the color is not supported.
		/// </para>
		/// </returns>
		[PInvokeData("WinUser.h", MSDNShortId = "ms724371")]
		[DllImport(Lib.User32, SetLastError = true, ExactSpelling = true)]
		public static extern COLORREF GetSysColor(SystemColorIndex nIndex);

		/// <summary>
		/// The GetSysColorBrush function retrieves a handle identifying a logical brush that corresponds to the specified color index.
		/// </summary>
		/// <param name="nIndex">
		/// A color index. This value corresponds to the color used to paint one of the window elements. See GetSysColor for system color
		/// index values.
		/// </param>
		/// <returns>
		/// he return value identifies a logical brush if the nIndex parameter is supported by the current platform. Otherwise, it returns NULL.
		/// </returns>
		[PInvokeData("WinUser.h", MSDNShortId = "dd144927")]
		[DllImport(Lib.User32, SetLastError = true, ExactSpelling = true)]
		public static extern HBRUSH GetSysColorBrush(SystemColorIndex nIndex);

		/// <summary>
		/// Retrieves information about the specified window. The function also retrieves the value at a specified offset into the extra
		/// window memory.
		/// </summary>
		/// <param name="hWnd">A handle to the window and, indirectly, the class to which the window belongs.</param>
		/// <param name="nIndex">
		/// The zero-based offset to the value to be retrieved. Valid values are in the range zero through the number of bytes of extra
		/// window memory, minus four; for example, if you specified 12 or more bytes of extra memory, a value of 8 would be an index to the
		/// third 32-bit integer. To retrieve any other value, specify one of the following values.
		/// </param>
		/// <returns>
		/// If the function succeeds, the return value is the requested value. If the function fails, the return value is zero.To get
		/// extended error information, call GetLastError.
		/// </returns>
		[DllImport(Lib.User32, CharSet = CharSet.Auto, SetLastError = true)]
		[SuppressMessage("Microsoft.Portability", "CA1901:PInvokeDeclarationsShouldBePortable", MessageId = "return", Justification = "This declaration is not used on 64-bit Windows.")]
		[SuppressMessage("Microsoft.Portability", "CA1901:PInvokeDeclarationsShouldBePortable", MessageId = "2", Justification = "This declaration is not used on 64-bit Windows.")]
		[System.Security.SecurityCritical]
		public static extern int GetWindowLong(HWND hWnd, int nIndex);

		/// <summary>
		/// Retrieves information about the specified window. The function also retrieves the value at a specified offset into the extra
		/// window memory.
		/// </summary>
		/// <param name="hWnd">A handle to the window and, indirectly, the class to which the window belongs.</param>
		/// <param name="nIndex">
		/// The zero-based offset to the value to be retrieved. Valid values are in the range zero through the number of bytes of extra
		/// window memory, minus the size of an integer. To retrieve any other value, specify one of the following values.
		/// </param>
		/// <returns>
		/// If the function succeeds, the return value is the requested value. If the function fails, the return value is zero.To get
		/// extended error information, call GetLastError.
		/// </returns>
		public static IntPtr GetWindowLongAuto(HWND hWnd, int nIndex)
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
		/// Retrieves information about the specified window. The function also retrieves the value at a specified offset into the extra
		/// window memory.
		/// </summary>
		/// <param name="hWnd">A handle to the window and, indirectly, the class to which the window belongs.</param>
		/// <param name="nIndex">
		/// The zero-based offset to the value to be retrieved. Valid values are in the range zero through the number of bytes of extra
		/// window memory, minus the size of an integer. To retrieve any other value, specify one of the following values.
		/// </param>
		/// <returns>
		/// If the function succeeds, the return value is the requested value. If the function fails, the return value is zero.To get
		/// extended error information, call GetLastError.
		/// </returns>
		[DllImport(Lib.User32, CharSet = CharSet.Auto, SetLastError = true)]
		[SuppressMessage("Microsoft.Interoperability", "CA1400:PInvokeEntryPointsShouldExist", Justification = "Entry point does exist on 64-bit Windows.")]
		[System.Security.SecurityCritical]
		public static extern IntPtr GetWindowLongPtr(HWND hWnd, int nIndex);

		/// <summary>
		/// The InvalidateRect function adds a rectangle to the specified window's update region. The update region represents the portion of
		/// the window's client area that must be redrawn.
		/// </summary>
		/// <param name="hWnd">
		/// A handle to the window whose update region has changed. If this parameter is NULL, the system invalidates and redraws all
		/// windows, not just the windows for this application, and sends the WM_ERASEBKGND and WM_NCPAINT messages before the function
		/// returns. Setting this parameter to NULL is not recommended.
		/// </param>
		/// <param name="rect">
		/// A pointer to a RECT structure that contains the client coordinates of the rectangle to be added to the update region. If this
		/// parameter is NULL, the entire client area is added to the update region.
		/// </param>
		/// <param name="bErase">
		/// Specifies whether the background within the update region is to be erased when the update region is processed. If this parameter
		/// is TRUE, the background is erased when the BeginPaint function is called. If this parameter is FALSE, the background remains unchanged.
		/// </param>
		/// <returns>
		/// If the function succeeds, the return value is true. If the function fails, the return value is false. To get extended error
		/// information, call GetLastError.
		/// </returns>
		[PInvokeData("WinUser.h", MSDNShortId = "")]
		[DllImport(Lib.User32, ExactSpelling = true, SetLastError = true)]
		[return: MarshalAs(UnmanagedType.Bool)]
		[System.Security.SecurityCritical]
		public static extern bool InvalidateRect(HWND hWnd, [In, Optional] PRECT rect, [MarshalAs(UnmanagedType.Bool)] bool bErase);

		/// <summary>
		/// The MapWindowPoints function converts (maps) a set of points from a coordinate space relative to one window to a coordinate space
		/// relative to another window.
		/// </summary>
		/// <param name="hWndFrom">
		/// A handle to the window from which points are converted. If this parameter is NULL or HWND_DESKTOP, the points are presumed to be
		/// in screen coordinates.
		/// </param>
		/// <param name="hWndTo">
		/// A handle to the window to which points are converted. If this parameter is NULL or HWND_DESKTOP, the points are converted to
		/// screen coordinates.
		/// </param>
		/// <param name="lpPoints">
		/// A pointer to an array of POINT structures that contain the set of points to be converted. The points are in device units. This
		/// parameter can also point to a RECT structure, in which case the cPoints parameter should be set to 2.
		/// </param>
		/// <param name="cPoints">The number of POINT structures in the array pointed to by the lpPoints parameter.</param>
		/// <returns>
		/// If the function succeeds, the low-order word of the return value is the number of pixels added to the horizontal coordinate of
		/// each source point in order to compute the horizontal coordinate of each destination point. (In addition to that, if precisely one
		/// of hWndFrom and hWndTo is mirrored, then each resulting horizontal coordinate is multiplied by -1.) The high-order word is the
		/// number of pixels added to the vertical coordinate of each source point in order to compute the vertical coordinate of each
		/// destination point.
		/// <para>
		/// If the function fails, the return value is zero. Call SetLastError prior to calling this method to differentiate an error return
		/// value from a legitimate "0" return value.
		/// </para>
		/// </returns>
		[PInvokeData("WinUser.h", MSDNShortId = "")]
		[DllImport(Lib.User32, ExactSpelling = true, SetLastError = true)]
		public static extern int MapWindowPoints(HWND hWndFrom, HWND hWndTo, ref RECT lpPoints, uint cPoints = 2);

		/// <summary>
		/// The MapWindowPoints function converts (maps) a set of points from a coordinate space relative to one window to a coordinate space
		/// relative to another window.
		/// </summary>
		/// <param name="hWndFrom">
		/// A handle to the window from which points are converted. If this parameter is NULL or HWND_DESKTOP, the points are presumed to be
		/// in screen coordinates.
		/// </param>
		/// <param name="hWndTo">
		/// A handle to the window to which points are converted. If this parameter is NULL or HWND_DESKTOP, the points are converted to
		/// screen coordinates.
		/// </param>
		/// <param name="lpPoints">
		/// A pointer to an array of POINT structures that contain the set of points to be converted. The points are in device units. This
		/// parameter can also point to a RECT structure, in which case the cPoints parameter should be set to 2.
		/// </param>
		/// <param name="cPoints">The number of POINT structures in the array pointed to by the lpPoints parameter.</param>
		/// <returns>
		/// If the function succeeds, the low-order word of the return value is the number of pixels added to the horizontal coordinate of
		/// each source point in order to compute the horizontal coordinate of each destination point. (In addition to that, if precisely one
		/// of hWndFrom and hWndTo is mirrored, then each resulting horizontal coordinate is multiplied by -1.) The high-order word is the
		/// number of pixels added to the vertical coordinate of each source point in order to compute the vertical coordinate of each
		/// destination point.
		/// <para>
		/// If the function fails, the return value is zero. Call SetLastError prior to calling this method to differentiate an error return
		/// value from a legitimate "0" return value.
		/// </para>
		/// </returns>
		[PInvokeData("WinUser.h", MSDNShortId = "")]
		[DllImport(Lib.User32, ExactSpelling = true, SetLastError = true)]
		public static extern int MapWindowPoints(HWND hWndFrom, HWND hWndTo, ref Point lpPoints, uint cPoints = 1);

		/// <summary>
		/// The MapWindowPoints function converts (maps) a set of points from a coordinate space relative to one window to a coordinate space
		/// relative to another window.
		/// </summary>
		/// <param name="hWndFrom">
		/// A handle to the window from which points are converted. If this parameter is NULL or HWND_DESKTOP, the points are presumed to be
		/// in screen coordinates.
		/// </param>
		/// <param name="hWndTo">
		/// A handle to the window to which points are converted. If this parameter is NULL or HWND_DESKTOP, the points are converted to
		/// screen coordinates.
		/// </param>
		/// <param name="lpPoints">
		/// A pointer to an array of POINT structures that contain the set of points to be converted. The points are in device units. This
		/// parameter can also point to a RECT structure, in which case the cPoints parameter should be set to 2.
		/// </param>
		/// <param name="cPoints">The number of POINT structures in the array pointed to by the lpPoints parameter.</param>
		/// <returns>
		/// If the function succeeds, the low-order word of the return value is the number of pixels added to the horizontal coordinate of
		/// each source point in order to compute the horizontal coordinate of each destination point. (In addition to that, if precisely one
		/// of hWndFrom and hWndTo is mirrored, then each resulting horizontal coordinate is multiplied by -1.) The high-order word is the
		/// number of pixels added to the vertical coordinate of each source point in order to compute the vertical coordinate of each
		/// destination point.
		/// <para>
		/// If the function fails, the return value is zero. Call SetLastError prior to calling this method to differentiate an error return
		/// value from a legitimate "0" return value.
		/// </para>
		/// </returns>
		[PInvokeData("WinUser.h", MSDNShortId = "")]
		[DllImport(Lib.User32, ExactSpelling = true, SetLastError = true)]
		public static extern int MapWindowPoints(HWND hWndFrom, HWND hWndTo, [MarshalAs(UnmanagedType.LPArray, SizeParamIndex = 3)] Point[] lpPoints, [MarshalAs(UnmanagedType.U4)] int cPoints);

		/// <summary>
		/// Defines a new window message that is guaranteed to be unique throughout the system. The message value can be used when sending or
		/// posting messages.
		/// </summary>
		/// <param name="lpString">The message to be registered.</param>
		/// <returns>
		/// If the message is successfully registered, the return value is a message identifier in the range 0xC000 through 0xFFFF. If the
		/// function fails, the return value is zero. To get extended error information, call GetLastError.
		/// </returns>
		[DllImport(Lib.User32, SetLastError = true, CharSet = CharSet.Auto)]
		[System.Security.SecurityCritical]
		public static extern uint RegisterWindowMessage(string lpString);

		/// <summary>The ScreenToClient function converts the screen coordinates of a specified point on the screen to client-area coordinates.</summary>
		/// <param name="hWnd">A handle to the window whose client area will be used for the conversion.</param>
		/// <param name="lpPoint">A pointer to a POINT structure that specifies the screen coordinates to be converted.</param>
		/// <returns>
		/// If the function succeeds, the return value is true. If the function fails, the return value is false. To get extended error
		/// information, call GetLastError.
		/// </returns>
		[DllImport(Lib.User32, ExactSpelling = true, SetLastError = true)]
		[return: MarshalAs(UnmanagedType.Bool)]
		[System.Security.SecurityCritical]
		public static extern bool ScreenToClient(HWND hWnd, [In, Out] ref Point lpPoint);

		/// <summary>
		/// <para>
		/// Sends the specified message to a window or windows. The <c>SendMessage</c> function calls the window procedure for the specified
		/// window and does not return until the window procedure has processed the message.
		/// </para>
		/// <para>
		/// To send a message and return immediately, use the <c>SendMessageCallback</c> or <c>SendNotifyMessage</c> function. To post a
		/// message to a thread's message queue and return immediately, use the <c>PostMessage</c> or <c>PostThreadMessage</c> function.
		/// </para>
		/// </summary>
		/// <param name="hWnd">
		/// <para>
		/// A handle to the window whose window procedure will receive the message. If this parameter is <c>HWND_BROADCAST</c>
		/// ((HWND)0xffff), the message is sent to all top-level windows in the system, including disabled or invisible unowned windows,
		/// overlapped windows, and pop-up windows; but the message is not sent to child windows.
		/// </para>
		/// <para>
		/// Message sending is subject to UIPI. The thread of a process can send messages only to message queues of threads in processes of
		/// lesser or equal integrity level.
		/// </para>
		/// </param>
		/// <param name="msg">
		/// <para>The message to be sent.</para>
		/// <para>For lists of the system-provided messages, see System-Defined Messages.</para>
		/// </param>
		/// <param name="wParam">Additional message-specific information.</param>
		/// <param name="lParam">Additional message-specific information.</param>
		/// <returns>The return value specifies the result of the message processing; it depends on the message sent.</returns>
		// LRESULT WINAPI SendMessage( _In_ HWND hWnd, _In_ UINT Msg, _In_ WPARAM wParam, _In_ LPARAM lParam); https://msdn.microsoft.com/en-us/library/windows/desktop/ms644950(v=vs.85).aspx
		[DllImport(Lib.User32, SetLastError = false, CharSet = CharSet.Auto)]
		[PInvokeData("Winuser.h", MSDNShortId = "ms644950")]
		[System.Security.SecurityCritical]
		public static extern IntPtr SendMessage(HWND hWnd, uint msg, IntPtr wParam = default, IntPtr lParam = default);

		/// <summary>
		/// <para>
		/// Sends the specified message to a window or windows. The <c>SendMessage</c> function calls the window procedure for the specified
		/// window and does not return until the window procedure has processed the message.
		/// </para>
		/// <para>
		/// To send a message and return immediately, use the <c>SendMessageCallback</c> or <c>SendNotifyMessage</c> function. To post a
		/// message to a thread's message queue and return immediately, use the <c>PostMessage</c> or <c>PostThreadMessage</c> function.
		/// </para>
		/// </summary>
		/// <param name="hWnd">
		/// <para>
		/// A handle to the window whose window procedure will receive the message. If this parameter is <c>HWND_BROADCAST</c>
		/// ((HWND)0xffff), the message is sent to all top-level windows in the system, including disabled or invisible unowned windows,
		/// overlapped windows, and pop-up windows; but the message is not sent to child windows.
		/// </para>
		/// <para>
		/// Message sending is subject to UIPI. The thread of a process can send messages only to message queues of threads in processes of
		/// lesser or equal integrity level.
		/// </para>
		/// </param>
		/// <param name="msg">
		/// <para>The message to be sent.</para>
		/// <para>For lists of the system-provided messages, see System-Defined Messages.</para>
		/// </param>
		/// <param name="wParam">Additional message-specific information.</param>
		/// <param name="lParam">Additional message-specific information.</param>
		/// <returns>The return value specifies the result of the message processing; it depends on the message sent.</returns>
		// LRESULT WINAPI SendMessage( _In_ HWND hWnd, _In_ UINT Msg, _In_ WPARAM wParam, _In_ LPARAM lParam); https://msdn.microsoft.com/en-us/library/windows/desktop/ms644950(v=vs.85).aspx
		[DllImport(Lib.User32, SetLastError = false, CharSet = CharSet.Auto)]
		[PInvokeData("Winuser.h", MSDNShortId = "ms644950")]
		[System.Security.SecurityCritical]
		public static extern IntPtr SendMessage(HWND hWnd, uint msg, IntPtr wParam, string lParam);

		/// <summary>
		/// <para>
		/// Sends the specified message to a window or windows. The <c>SendMessage</c> function calls the window procedure for the specified
		/// window and does not return until the window procedure has processed the message.
		/// </para>
		/// <para>
		/// To send a message and return immediately, use the <c>SendMessageCallback</c> or <c>SendNotifyMessage</c> function. To post a
		/// message to a thread's message queue and return immediately, use the <c>PostMessage</c> or <c>PostThreadMessage</c> function.
		/// </para>
		/// </summary>
		/// <param name="hWnd">
		/// <para>
		/// A handle to the window whose window procedure will receive the message. If this parameter is <c>HWND_BROADCAST</c>
		/// ((HWND)0xffff), the message is sent to all top-level windows in the system, including disabled or invisible unowned windows,
		/// overlapped windows, and pop-up windows; but the message is not sent to child windows.
		/// </para>
		/// <para>
		/// Message sending is subject to UIPI. The thread of a process can send messages only to message queues of threads in processes of
		/// lesser or equal integrity level.
		/// </para>
		/// </param>
		/// <param name="msg">
		/// <para>The message to be sent.</para>
		/// <para>For lists of the system-provided messages, see System-Defined Messages.</para>
		/// </param>
		/// <param name="wParam">Additional message-specific information.</param>
		/// <param name="lParam">Additional message-specific information.</param>
		/// <returns>The return value specifies the result of the message processing; it depends on the message sent.</returns>
		// LRESULT WINAPI SendMessage( _In_ HWND hWnd, _In_ UINT Msg, _In_ WPARAM wParam, _In_ LPARAM lParam); https://msdn.microsoft.com/en-us/library/windows/desktop/ms644950(v=vs.85).aspx
		[DllImport(Lib.User32, SetLastError = false, CharSet = CharSet.Auto)]
		[PInvokeData("Winuser.h", MSDNShortId = "ms644950")]
		[System.Security.SecurityCritical]
		public static extern IntPtr SendMessage(HWND hWnd, uint msg, ref int wParam, [In, Out] StringBuilder lParam);

		/// <summary>
		/// Sends the specified message to a window or windows. The SendMessage function calls the window procedure for the specified window
		/// and does not return until the window procedure has processed the message.
		/// </summary>
		/// <typeparam name="TEnum">The type of the <paramref name="msg"/> value.</typeparam>
		/// <typeparam name="TWP">The type of the <paramref name="wParam"/> value.</typeparam>
		/// <typeparam name="TLP">The type of the <paramref name="lParam"/> value.</typeparam>
		/// <param name="hWnd">
		/// A handle to the window whose window procedure will receive the message. If this parameter is HWND_BROADCAST ((HWND)0xffff), the
		/// message is sent to all top-level windows in the system, including disabled or invisible unowned windows, overlapped windows, and
		/// pop-up windows; but the message is not sent to child windows.
		/// </param>
		/// <param name="msg">The message to be sent.</param>
		/// <param name="wParam">Additional message-specific information.</param>
		/// <param name="lParam">Additional message-specific information.</param>
		/// <returns>The return value specifies the result of the message processing; it depends on the message sent.</returns>
		public static IntPtr SendMessage<TEnum, TWP, TLP>(HWND hWnd, TEnum msg, IntPtr wParam, TLP lParam)
			where TEnum : struct, IConvertible where TLP : class
		{
			var m = Convert.ToUInt32(msg);
			using (var lp = new PinnedObject(lParam))
				return SendMessage(hWnd, m, wParam, (IntPtr)lp);
		}

		/// <summary>
		/// Sends the specified message to a window or windows. The SendMessage function calls the window procedure for the specified window
		/// and does not return until the window procedure has processed the message.
		/// </summary>
		/// <typeparam name="TEnum">The type of the <paramref name="msg"/> value.</typeparam>
		/// <typeparam name="TWP">The type of the <paramref name="wParam"/> value.</typeparam>
		/// <typeparam name="TLP">The type of the <paramref name="lParam"/> value.</typeparam>
		/// <param name="hWnd">
		/// A handle to the window whose window procedure will receive the message. If this parameter is HWND_BROADCAST ((HWND)0xffff), the
		/// message is sent to all top-level windows in the system, including disabled or invisible unowned windows, overlapped windows, and
		/// pop-up windows; but the message is not sent to child windows.
		/// </param>
		/// <param name="msg">The message to be sent.</param>
		/// <param name="wParam">Additional message-specific information.</param>
		/// <param name="lParam">Additional message-specific information.</param>
		/// <returns>The return value specifies the result of the message processing; it depends on the message sent.</returns>
		public static IntPtr SendMessage<TEnum, TWP, TLP>(HWND hWnd, TEnum msg, IntPtr wParam, ref TLP lParam)
			where TEnum : struct, IConvertible where TLP : struct
		{
			using (var lp = GetPtr(lParam))
			{
				var lr = SendMessage(hWnd, Convert.ToUInt32(msg), wParam, (IntPtr)lp);
				lParam = lp.ToStructure<TLP>();
				return lr;
			}
		}

		/// <summary>
		/// Sends the specified message to a window or windows. The SendMessage function calls the window procedure for the specified window
		/// and does not return until the window procedure has processed the message.
		/// </summary>
		/// <typeparam name="TEnum">The type of the <paramref name="msg"/> value.</typeparam>
		/// <typeparam name="TWP">The type of the <paramref name="wParam"/> value.</typeparam>
		/// <typeparam name="TLP">The type of the <paramref name="lParam"/> value.</typeparam>
		/// <param name="hWnd">
		/// A handle to the window whose window procedure will receive the message. If this parameter is HWND_BROADCAST ((HWND)0xffff), the
		/// message is sent to all top-level windows in the system, including disabled or invisible unowned windows, overlapped windows, and
		/// pop-up windows; but the message is not sent to child windows.
		/// </param>
		/// <param name="msg">The message to be sent.</param>
		/// <param name="wParam">Additional message-specific information.</param>
		/// <param name="lParam">Additional message-specific information.</param>
		/// <returns>The return value specifies the result of the message processing; it depends on the message sent.</returns>
		public static IntPtr SendMessage<TEnum, TWP, TLP>(HWND hWnd, TEnum msg, TWP wParam, TLP lParam)
			where TEnum : struct, IConvertible where TWP : struct, IConvertible where TLP : class
		{
			using (var lp = new PinnedObject(lParam))
				return SendMessage(hWnd, Convert.ToUInt32(msg), new IntPtr(Convert.ToInt64(wParam)), (IntPtr)lp);
		}

		/// <summary>
		/// Sends the specified message to a window or windows. The SendMessage function calls the window procedure for the specified window
		/// and does not return until the window procedure has processed the message.
		/// </summary>
		/// <typeparam name="TEnum">The type of the <paramref name="msg"/> value.</typeparam>
		/// <typeparam name="TWP">The type of the <paramref name="wParam"/> value.</typeparam>
		/// <typeparam name="TLP">The type of the <paramref name="lParam"/> value.</typeparam>
		/// <param name="hWnd">
		/// A handle to the window whose window procedure will receive the message. If this parameter is HWND_BROADCAST ((HWND)0xffff), the
		/// message is sent to all top-level windows in the system, including disabled or invisible unowned windows, overlapped windows, and
		/// pop-up windows; but the message is not sent to child windows.
		/// </param>
		/// <param name="msg">The message to be sent.</param>
		/// <param name="wParam">Additional message-specific information.</param>
		/// <param name="lParam">Additional message-specific information.</param>
		/// <returns>The return value specifies the result of the message processing; it depends on the message sent.</returns>
		public static IntPtr SendMessage<TEnum, TWP, TLP>(HWND hWnd, TEnum msg, TWP wParam, ref TLP lParam)
			where TEnum : struct, IConvertible where TWP : struct, IConvertible where TLP : struct
		{
			using (var lp = GetPtr(lParam))
			{
				var lr = SendMessage(hWnd, Convert.ToUInt32(msg), new IntPtr(Convert.ToInt64(wParam)), (IntPtr)lp);
				lParam = lp.ToStructure<TLP>();
				return lr;
			}
		}

		/// <summary>
		/// Sends the specified message to a window or windows. The SendMessage function calls the window procedure for the specified window
		/// and does not return until the window procedure has processed the message.
		/// </summary>
		/// <typeparam name="TEnum">The type of the <paramref name="msg"/> value.</typeparam>
		/// <typeparam name="TWP">The type of the <paramref name="wParam"/> value.</typeparam>
		/// <typeparam name="TLP">The type of the <paramref name="lParam"/> value.</typeparam>
		/// <param name="hWnd">
		/// A handle to the window whose window procedure will receive the message. If this parameter is HWND_BROADCAST ((HWND)0xffff), the
		/// message is sent to all top-level windows in the system, including disabled or invisible unowned windows, overlapped windows, and
		/// pop-up windows; but the message is not sent to child windows.
		/// </param>
		/// <param name="msg">The message to be sent.</param>
		/// <param name="wParam">Additional message-specific information.</param>
		/// <param name="lParam">Additional message-specific information.</param>
		/// <returns>The return value specifies the result of the message processing; it depends on the message sent.</returns>
		public static IntPtr SendMessage<TEnum, TWP, TLP>(HWND hWnd, TEnum msg, in TWP wParam, TLP lParam)
			where TEnum : struct, IConvertible where TWP : struct where TLP : class
		{
			using (PinnedObject wp = new PinnedObject(wParam), lp = new PinnedObject(lParam))
				return SendMessage(hWnd, Convert.ToUInt32(msg), wp, (IntPtr)lp);
		}

		/// <summary>
		/// Sends the specified message to a window or windows. The SendMessage function calls the window procedure for the specified window
		/// and does not return until the window procedure has processed the message.
		/// </summary>
		/// <typeparam name="TEnum">The type of the <paramref name="msg"/> value.</typeparam>
		/// <typeparam name="TWP">The type of the <paramref name="wParam"/> value.</typeparam>
		/// <typeparam name="TLP">The type of the <paramref name="lParam"/> value.</typeparam>
		/// <param name="hWnd">
		/// A handle to the window whose window procedure will receive the message. If this parameter is HWND_BROADCAST ((HWND)0xffff), the
		/// message is sent to all top-level windows in the system, including disabled or invisible unowned windows, overlapped windows, and
		/// pop-up windows; but the message is not sent to child windows.
		/// </param>
		/// <param name="msg">The message to be sent.</param>
		/// <param name="wParam">Additional message-specific information.</param>
		/// <param name="lParam">Additional message-specific information.</param>
		/// <returns>The return value specifies the result of the message processing; it depends on the message sent.</returns>
		public static IntPtr SendMessage<TEnum, TWP, TLP>(HWND hWnd, TEnum msg, in TWP wParam, ref TLP lParam)
			where TEnum : struct, IConvertible where TWP : struct where TLP : struct
		{
			using (var lp = GetPtr(lParam))
			{
				var lr = SendMessage(hWnd, Convert.ToUInt32(msg), (IntPtr)GetPtr(wParam), (IntPtr)lp);
				lParam = lp.ToStructure<TLP>();
				return lr;
			}
		}

		/// <summary>
		/// <para>
		/// Sends the specified message to a window or windows. The <c>SendMessage</c> function calls the window procedure for the specified
		/// window and does not return until the window procedure has processed the message.
		/// </para>
		/// <para>
		/// To send a message and return immediately, use the <c>SendMessageCallback</c> or <c>SendNotifyMessage</c> function. To post a
		/// message to a thread's message queue and return immediately, use the <c>PostMessage</c> or <c>PostThreadMessage</c> function.
		/// </para>
		/// </summary>
		/// <param name="hWnd">
		/// <para>
		/// A handle to the window whose window procedure will receive the message. If this parameter is <c>HWND_BROADCAST</c>
		/// ((HWND)0xffff), the message is sent to all top-level windows in the system, including disabled or invisible unowned windows,
		/// overlapped windows, and pop-up windows; but the message is not sent to child windows.
		/// </para>
		/// <para>
		/// Message sending is subject to UIPI. The thread of a process can send messages only to message queues of threads in processes of
		/// lesser or equal integrity level.
		/// </para>
		/// </param>
		/// <param name="msg">
		/// <para>The message to be sent.</para>
		/// <para>For lists of the system-provided messages, see System-Defined Messages.</para>
		/// </param>
		/// <param name="wParam">Additional message-specific information.</param>
		/// <param name="lParam">Additional message-specific information.</param>
		/// <returns>The return value specifies the result of the message processing; it depends on the message sent.</returns>
		// LRESULT WINAPI SendMessage( _In_ HWND hWnd, _In_ UINT Msg, _In_ WPARAM wParam, _In_ LPARAM lParam); https://msdn.microsoft.com/en-us/library/windows/desktop/ms644950(v=vs.85).aspx
		[DllImport(Lib.User32, SetLastError = false, CharSet = CharSet.Auto, EntryPoint = "SendMessage")]
		[PInvokeData("Winuser.h", MSDNShortId = "ms644950")]
		[System.Security.SecurityCritical]
		public static unsafe extern void* SendMessageUnsafe(void* hWnd, uint msg, void* wParam, void* lParam);

		/// <summary>
		/// <para>
		/// Sets the colors for the specified display elements. Display elements are the various parts of a window and the display that
		/// appear on the system display screen.
		/// </para>
		/// </summary>
		/// <param name="cElements">
		/// <para>Type: <c>int</c></para>
		/// <para>The number of display elements in the lpaElements array.</para>
		/// </param>
		/// <param name="lpaElements">
		/// <para>Type: <c>const INT*</c></para>
		/// <para>An array of integers that specify the display elements to be changed. For a list of display elements, see GetSysColor.</para>
		/// </param>
		/// <param name="lpaRgbValues">
		/// <para>Type: <c>const COLORREF*</c></para>
		/// <para>
		/// An array of COLORREF values that contain the new red, green, blue (RGB) color values for the display elements in the array
		/// pointed to by the lpaElements parameter.
		/// </para>
		/// <para>To generate a COLORREF, use the RGB macro.</para>
		/// </param>
		/// <returns>
		/// <para>Type: <c>Type: <c>BOOL</c></c></para>
		/// <para>If the function succeeds, the return value is a nonzero value.</para>
		/// <para>If the function fails, the return value is zero. To get extended error information, call GetLastError.</para>
		/// </returns>
		/// <remarks>
		/// <para>
		/// The <c>SetSysColors</c> function sends a WM_SYSCOLORCHANGE message to all windows to inform them of the change in color. It also
		/// directs the system to repaint the affected portions of all currently visible windows.
		/// </para>
		/// <para>
		/// It is best to respect the color settings specified by the user. If you are writing an application to enable the user to change
		/// the colors, then it is appropriate to use this function. However, this function affects only the current session. The new colors
		/// are not saved when the system terminates.
		/// </para>
		/// <para>Examples</para>
		/// <para>
		/// The following example demonstrates the use of the GetSysColor and <c>SetSysColors</c> functions. First, the example uses
		/// <c>GetSysColor</c> to retrieve the colors of the window background and active caption and displays the red, green, blue (RGB)
		/// values in hexadecimal notation. Next, example uses <c>SetSysColors</c> to change the color of the window background to light gray
		/// and the active title bars to dark purple. After a 10-second delay, the example restores the previous colors for these elements
		/// using SetSysColors.
		/// </para>
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows/desktop/api/winuser/nf-winuser-setsyscolors BOOL SetSysColors( int cElements, CONST INT
		// *lpaElements, CONST COLORREF *lpaRgbValues );
		[DllImport(Lib.User32, SetLastError = true, ExactSpelling = true)]
		[PInvokeData("winuser.h", MSDNShortId = "41a7a96c-f9d1-44e3-a7e1-fd7d155c4ed0")]
		[return: MarshalAs(UnmanagedType.Bool)]
		public static extern bool SetSysColors(int cElements, [In, MarshalAs(UnmanagedType.LPArray, ArraySubType = UnmanagedType.U4, SizeConst = 0)] SystemColorIndex[] lpaElements, [In, MarshalAs(UnmanagedType.LPArray, SizeConst = 0)] COLORREF[] lpaRgbValues);

		/// <summary>
		/// Changes an attribute of the specified window. The function also sets a value at the specified offset in the extra window memory.
		/// </summary>
		/// <param name="hWnd">
		/// A handle to the window and, indirectly, the class to which the window belongs. The SetWindowLongPtr function fails if the process
		/// that owns the window specified by the hWnd parameter is at a higher process privilege in the UIPI hierarchy than the process the
		/// calling thread resides in.
		/// </param>
		/// <param name="nIndex">
		/// The zero-based offset to the value to be set. Valid values are in the range zero through the number of bytes of extra window
		/// memory, minus the size of an integer. Alternately, this can be a value from <see cref="WindowLongFlags"/>.
		/// </param>
		/// <param name="dwNewLong">The replacement value.</param>
		/// <returns>
		/// If the function succeeds, the return value is the previous value of the specified offset. If the function fails, the return value
		/// is zero. To get extended error information, call GetLastError.
		/// <para>
		/// If the previous value is zero and the function succeeds, the return value is zero, but the function does not clear the last error
		/// information. To determine success or failure, clear the last error information by calling SetLastError with 0, then call
		/// SetWindowLongPtr. Function failure will be indicated by a return value of zero and a GetLastError result that is nonzero.
		/// </para>
		/// </returns>
		public static IntPtr SetWindowLong(HWND hWnd, int nIndex, IntPtr dwNewLong)
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

		private static SafeCoTaskMemHandle GetPtr<T>(in T val) => SafeCoTaskMemHandle.CreateFromStructure(val);

		/// <summary>
		/// Sends the specified message to a window or windows. The SendMessage function calls the window procedure for the specified window
		/// and does not return until the window procedure has processed the message.
		/// </summary>
		/// <typeparam name="TEnum">The type of the <paramref name="msg"/> value.</typeparam>
		/// <typeparam name="TWP">The type of the <paramref name="wParam"/> value.</typeparam>
		/// <typeparam name="TLP">The type of the <paramref name="lParam"/> value.</typeparam>
		/// <param name="hWnd">
		/// A handle to the window whose window procedure will receive the message. If this parameter is HWND_BROADCAST ((HWND)0xffff), the
		/// message is sent to all top-level windows in the system, including disabled or invisible unowned windows, overlapped windows, and
		/// pop-up windows; but the message is not sent to child windows.
		/// </param>
		/// <param name="msg">The message to be sent.</param>
		/// <param name="wParam">Additional message-specific information.</param>
		/// <param name="lParam">Additional message-specific information.</param>
		/// <returns>The return value specifies the result of the message processing; it depends on the message sent.</returns>
		private static IntPtr SendMessageUnmanaged<TEnum, TWP, TLP>(HWND hWnd, TEnum msg, in TWP wParam, ref TLP lParam)
			where TEnum : struct, IConvertible where TWP : unmanaged where TLP : unmanaged
		{
			var m = (uint)Convert.ChangeType(msg, typeof(uint));
			unsafe
			{
				fixed (void* wp = &wParam, lp = &lParam)
				{
					return (IntPtr)SendMessageUnsafe((void*)(IntPtr)hWnd, m, wp, lp);
				}
			}
		}

		/// <summary>
		/// Changes an attribute of the specified window. The function also sets a value at the specified offset in the extra window memory.
		/// </summary>
		/// <param name="hWnd">
		/// A handle to the window and, indirectly, the class to which the window belongs. The SetWindowLongPtr function fails if the process
		/// that owns the window specified by the hWnd parameter is at a higher process privilege in the UIPI hierarchy than the process the
		/// calling thread resides in.
		/// </param>
		/// <param name="nIndex">
		/// The zero-based offset to the value to be set. Valid values are in the range zero through the number of bytes of extra window
		/// memory, minus the size of an integer. Alternately, this can be a value from <see cref="WindowLongFlags"/>.
		/// </param>
		/// <param name="dwNewLong">The replacement value.</param>
		/// <returns>
		/// If the function succeeds, the return value is the previous value of the specified offset. If the function fails, the return value
		/// is zero. To get extended error information, call GetLastError.
		/// <para>
		/// If the previous value is zero and the function succeeds, the return value is zero, but the function does not clear the last error
		/// information. To determine success or failure, clear the last error information by calling SetLastError with 0, then call
		/// SetWindowLongPtr. Function failure will be indicated by a return value of zero and a GetLastError result that is nonzero.
		/// </para>
		/// </returns>
		[DllImport(Lib.User32, SetLastError = true, EntryPoint = "SetWindowLong")]
		[SuppressMessage("Microsoft.Portability", "CA1901:PInvokeDeclarationsShouldBePortable", MessageId = "return", Justification = "This declaration is not used on 64-bit Windows.")]
		[SuppressMessage("Microsoft.Portability", "CA1901:PInvokeDeclarationsShouldBePortable", MessageId = "2", Justification = "This declaration is not used on 64-bit Windows.")]
		private static extern int SetWindowLongPtr32(HWND hWnd, int nIndex, IntPtr dwNewLong);

		/// <summary>
		/// Changes an attribute of the specified window. The function also sets a value at the specified offset in the extra window memory.
		/// </summary>
		/// <param name="hWnd">
		/// A handle to the window and, indirectly, the class to which the window belongs. The SetWindowLongPtr function fails if the process
		/// that owns the window specified by the hWnd parameter is at a higher process privilege in the UIPI hierarchy than the process the
		/// calling thread resides in.
		/// </param>
		/// <param name="nIndex">
		/// The zero-based offset to the value to be set. Valid values are in the range zero through the number of bytes of extra window
		/// memory, minus the size of an integer. Alternately, this can be a value from <see cref="WindowLongFlags"/>.
		/// </param>
		/// <param name="dwNewLong">The replacement value.</param>
		/// <returns>
		/// If the function succeeds, the return value is the previous value of the specified offset. If the function fails, the return value
		/// is zero. To get extended error information, call GetLastError.
		/// <para>
		/// If the previous value is zero and the function succeeds, the return value is zero, but the function does not clear the last error
		/// information. To determine success or failure, clear the last error information by calling SetLastError with 0, then call
		/// SetWindowLongPtr. Function failure will be indicated by a return value of zero and a GetLastError result that is nonzero.
		/// </para>
		/// </returns>
		[DllImport(Lib.User32, SetLastError = true, EntryPoint = "SetWindowLongPtr")]
		[SuppressMessage("Microsoft.Interoperability", "CA1400:PInvokeEntryPointsShouldExist", Justification = "Entry point does exist on 64-bit Windows.")]
		private static extern IntPtr SetWindowLongPtr64(HWND hWnd, int nIndex, IntPtr dwNewLong);

		/// <summary>Contains information about a window's maximized size and position and its minimum and maximum tracking size.</summary>
		[StructLayout(LayoutKind.Sequential)]
		public struct MINMAXINFO
		{
			/// <summary>Reserved; do not use.</summary>
			public Point reserved;

			/// <summary>
			/// The maximized width (x member) and the maximized height (y member) of the window. For top-level windows, this value is based
			/// on the width of the primary monitor.
			/// </summary>
			public Size maxSize;

			/// <summary>
			/// The position of the left side of the maximized window (x member) and the position of the top of the maximized window (y
			/// member). For top-level windows, this value is based on the position of the primary monitor.
			/// </summary>
			public Point maxPosition;

			/// <summary>
			/// The minimum tracking width (x member) and the minimum tracking height (y member) of the window. This value can be obtained
			/// programmatically from the system metrics SM_CXMINTRACK and SM_CYMINTRACK (see the GetSystemMetrics function).
			/// </summary>
			public Size minTrackSize;

			/// <summary>
			/// The maximum tracking width (x member) and the maximum tracking height (y member) of the window. This value is based on the
			/// size of the virtual screen and can be obtained programmatically from the system metrics SM_CXMAXTRACK and SM_CYMAXTRACK (see
			/// the GetSystemMetrics function).
			/// </summary>
			public Size maxTrackSize;
		}

		/// <summary>Contains information about the size and position of a window.</summary>
		[StructLayout(LayoutKind.Sequential)]
		public struct WINDOWPOS
		{
			/// <summary>A handle to the window.</summary>
			public HWND hwnd;

			/// <summary>
			/// The position of the window in Z order (front-to-back position). This member can be a handle to the window behind which this
			/// window is placed, or can be one of the special values listed with the SetWindowPos function.
			/// </summary>
			public HWND hwndInsertAfter;

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
			/// Places the window at the bottom of the Z order. If the hWnd parameter identifies a topmost window, the window loses its
			/// topmost status and is placed at the bottom of all other windows.
			/// </summary>
			public static HWND HWND_BOTTOM = new IntPtr(1);

			/// <summary>
			/// Places the window above all non-topmost windows (that is, behind all topmost windows). This flag has no effect if the window
			/// is already a non-topmost window.
			/// </summary>
			public static HWND HWND_NOTOPMOST = new IntPtr(-2);

			/// <summary>Places the window at the top of the Z order.</summary>
			public static HWND HWND_TOP = new IntPtr(0);

			/// <summary>Places the window above all non-topmost windows. The window maintains its topmost position even when it is deactivated.</summary>
			public static HWND HWND_TOPMOST = new IntPtr(-1);
		}
	}
}