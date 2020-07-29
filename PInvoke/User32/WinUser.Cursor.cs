using System;
using System.Drawing;
using System.Runtime.InteropServices;

namespace Vanara.PInvoke
{
	public static partial class User32
	{
		/// <summary>The cursor state.</summary>
		[PInvokeData("winuser.h", MSDNShortId = "cursorinfo")]
		[Flags]
		public enum CursorState
		{
			/// <summary>The cursor is hidden.</summary>
			CURSOR_HIDDEN = 0,

			/// <summary>The cursor is showing.</summary>
			CURSOR_SHOWING = 0x00000001,

			/// <summary>
			/// Windows 8: The cursor is suppressed. This flag indicates that the system is not drawing the cursor because the user is
			/// providing input through touch or pen instead of the mouse.
			/// </summary>
			CURSOR_SUPPRESSED = 0x00000002,
		}

		/// <summary>System cursor types.</summary>
		[PInvokeData("winuser.h", MSDNShortId = "setsystemcursor")]
		public enum OCR
		{
			/// <summary>Standard arrow and small hourglass</summary>
			OCR_APPSTARTING = 32650,

			/// <summary>Standard arrow</summary>
			OCR_NORMAL = 32512,

			/// <summary>Crosshair</summary>
			OCR_CROSS = 32515,

			/// <summary>Hand</summary>
			OCR_HAND = 32649,

			/// <summary>Arrow and question mark</summary>
			OCR_HELP = 32651,

			/// <summary>I-beam</summary>
			OCR_IBEAM = 32513,

			/// <summary>Slashed circle</summary>
			OCR_NO = 32648,

			/// <summary>Four-pointed arrow pointing north, south, east, and west</summary>
			OCR_SIZEALL = 32646,

			/// <summary>Double-pointed arrow pointing northeast and southwest</summary>
			OCR_SIZENESW = 32643,

			/// <summary>Double-pointed arrow pointing north and south</summary>
			OCR_SIZENS = 32645,

			/// <summary>Double-pointed arrow pointing northwest and southeast</summary>
			OCR_SIZENWSE = 32642,

			/// <summary>Double-pointed arrow pointing west and east</summary>
			OCR_SIZEWE = 32644,

			/// <summary>Vertical arrow</summary>
			OCR_UP = 32516,

			/// <summary>Hourglass</summary>
			OCR_WAIT = 32514,
		}

		/// <summary>
		/// <para>
		/// Confines the cursor to a rectangular area on the screen. If a subsequent cursor position (set by the SetCursorPos function or the
		/// mouse) lies outside the rectangle, the system automatically adjusts the position to keep the cursor inside the rectangular area.
		/// </para>
		/// </summary>
		/// <param name="lpRect">
		/// <para>Type: <c>const RECT*</c></para>
		/// <para>
		/// A pointer to the structure that contains the screen coordinates of the upper-left and lower-right corners of the confining
		/// rectangle. If this parameter is <c>NULL</c>, the cursor is free to move anywhere on the screen.
		/// </para>
		/// </param>
		/// <returns>
		/// <para>Type: <c>BOOL</c></para>
		/// <para>If the function succeeds, the return value is nonzero.</para>
		/// <para>If the function fails, the return value is zero. To get extended error information, call GetLastError.</para>
		/// </returns>
		/// <remarks>
		/// <para>
		/// The cursor is a shared resource. If an application confines the cursor, it must release the cursor by using <c>ClipCursor</c>
		/// before relinquishing control to another application.
		/// </para>
		/// <para>The calling process must have <c>WINSTA_WRITEATTRIBUTES</c> access to the window station.</para>
		/// <para>Examples</para>
		/// <para>For an example, see Confining a Cursor.</para>
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows/desktop/api/winuser/nf-winuser-clipcursor BOOL ClipCursor( CONST RECT *lpRect );
		[DllImport(Lib.User32, SetLastError = true, ExactSpelling = true)]
		[PInvokeData("winuser.h", MSDNShortId = "clipcursor")]
		[return: MarshalAs(UnmanagedType.Bool)]
		public static extern bool ClipCursor(in RECT lpRect);

		/// <summary>
		/// Creates a new cursor and copies the attributes of the specified image to the new one. If necessary, the function stretches the
		/// bits to fit the desired size of the new image.
		/// </summary>
		/// <param name="h">
		/// <para>A handle to the image to be copied.</para>
		/// </param>
		/// <param name="desiredSize">
		/// The desired size, in pixels, of the image. If this is Size.Empty, then the returned image will have the same size as the original hImage.
		/// </param>
		/// <param name="options">
		/// <para>This parameter can be one or more of the following values.</para>
		/// <list type="table">
		/// <listheader>
		/// <term>Value</term>
		/// <term>Meaning</term>
		/// </listheader>
		/// <item>
		/// <term>LR_COPYDELETEORG 0x00000008</term>
		/// <term>Deletes the original image after creating the copy.</term>
		/// </item>
		/// <item>
		/// <term>LR_COPYFROMRESOURCE 0x00004000</term>
		/// <term>
		/// Tries to reload an icon or cursor resource from the original resource file rather than simply copying the current image. This is
		/// useful for creating a different-sized copy when the resource file contains multiple sizes of the resource. Without this flag,
		/// CopyImage stretches the original image to the new size. If this flag is set, CopyImage uses the size in the resource file closest
		/// to the desired size. This will succeed only if hImage was loaded by LoadIcon or LoadCursor, or by LoadImage with the LR_SHARED flag.
		/// </term>
		/// </item>
		/// <item>
		/// <term>LR_COPYRETURNORG 0x00000004</term>
		/// <term>
		/// Returns the original hImage if it satisfies the criteria for the copy—that is, correct dimensions and color depth—in which case
		/// the LR_COPYDELETEORG flag is ignored. If this flag is not specified, a new object is always created.
		/// </term>
		/// </item>
		/// <item>
		/// <term>LR_CREATEDIBSECTION 0x00002000</term>
		/// <term>
		/// If this is set and a new bitmap is created, the bitmap is created as a DIB section. Otherwise, the bitmap image is created as a
		/// device-dependent bitmap. This flag is only valid if uType is IMAGE_BITMAP.
		/// </term>
		/// </item>
		/// <item>
		/// <term>LR_DEFAULTSIZE 0x00000040</term>
		/// <term>
		/// Uses the width or height specified by the system metric values for cursors or icons, if the cxDesired or cyDesired values are set
		/// to zero. If this flag is not specified and cxDesired and cyDesired are set to zero, the function uses the actual resource size.
		/// If the resource contains multiple images, the function uses the size of the first image.
		/// </term>
		/// </item>
		/// <item>
		/// <term>LR_MONOCHROME 0x00000001</term>
		/// <term>Creates a new monochrome image.</term>
		/// </item>
		/// </list>
		/// </param>
		/// <returns>
		/// <para>The return value is a safe handle to the newly created image.</para>
		/// </returns>
		[PInvokeData("winuser.h")]
		public static SafeHCURSOR CopyCursor(HCURSOR h, Size desiredSize = default, CopyImageOptions options = 0)
		{
			var hret = CopyImage(h.DangerousGetHandle(), LoadImageType.IMAGE_CURSOR, desiredSize.Width, desiredSize.Height, options);
			if (hret == HANDLE.NULL) Win32Error.ThrowLastError();
			return new SafeHCURSOR(hret.DangerousGetHandle(), true);
		}

		/// <summary>
		/// <para>Creates a cursor having the specified size, bit patterns, and hot spot.</para>
		/// </summary>
		/// <param name="hInst">
		/// <para>Type: <c>HINSTANCE</c></para>
		/// <para>A handle to the current instance of the application creating the cursor.</para>
		/// </param>
		/// <param name="xHotSpot">
		/// <para>Type: <c>int</c></para>
		/// <para>The horizontal position of the cursor's hot spot.</para>
		/// </param>
		/// <param name="yHotSpot">
		/// <para>Type: <c>int</c></para>
		/// <para>The vertical position of the cursor's hot spot.</para>
		/// </param>
		/// <param name="nWidth">
		/// <para>Type: <c>int</c></para>
		/// <para>The width of the cursor, in pixels.</para>
		/// </param>
		/// <param name="nHeight">
		/// <para>Type: <c>int</c></para>
		/// <para>The height of the cursor, in pixels.</para>
		/// </param>
		/// <param name="pvANDPlane">
		/// <para>Type: <c>const VOID*</c></para>
		/// <para>An array of bytes that contains the bit values for the AND mask of the cursor, as in a device-dependent monochrome bitmap.</para>
		/// </param>
		/// <param name="pvXORPlane">
		/// <para>Type: <c>const VOID*</c></para>
		/// <para>An array of bytes that contains the bit values for the XOR mask of the cursor, as in a device-dependent monochrome bitmap.</para>
		/// </param>
		/// <returns>
		/// <para>Type: <c>HCURSOR</c></para>
		/// <para>If the function succeeds, the return value is a handle to the cursor.</para>
		/// <para>If the function fails, the return value is <c>NULL</c>. To get extended error information, call GetLastError.</para>
		/// </returns>
		/// <remarks>
		/// <para>
		/// The nWidth and nHeight parameters must specify a width and height that are supported by the current display driver, because the
		/// system cannot create cursors of other sizes. To determine the width and height supported by the display driver, use the
		/// GetSystemMetrics function, specifying the <c>SM_CXCURSOR</c> or <c>SM_CYCURSOR</c> value.
		/// </para>
		/// <para>Before closing, an application must call the DestroyCursor function to free any system resources associated with the cursor.</para>
		/// <para>DPI Virtualization</para>
		/// <para>
		/// This API does not participate in DPI virtualization. The output returned is in terms of physical coordinates, and is not affected
		/// by the DPI of the calling thread. Note that the cursor created may still be scaled to match the DPI of any given window it is
		/// drawn into.
		/// </para>
		/// <para>Examples</para>
		/// <para>For an example, see Creating a Cursor.</para>
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows/desktop/api/winuser/nf-winuser-createcursor HCURSOR CreateCursor( HINSTANCE hInst, int
		// xHotSpot, int yHotSpot, int nWidth, int nHeight, CONST VOID *pvANDPlane, CONST VOID *pvXORPlane );
		[DllImport(Lib.User32, SetLastError = true, ExactSpelling = true)]
		[PInvokeData("winuser.h", MSDNShortId = "createcursor")]
		public static extern SafeHCURSOR CreateCursor(HINSTANCE hInst, int xHotSpot, int yHotSpot, int nWidth, int nHeight, IntPtr pvANDPlane, IntPtr pvXORPlane);

		/// <summary>
		/// <para>Destroys a cursor and frees any memory the cursor occupied. Do not use this function to destroy a shared cursor.</para>
		/// </summary>
		/// <param name="hCursor">
		/// <para>Type: <c>HCURSOR</c></para>
		/// <para>A handle to the cursor to be destroyed. The cursor must not be in use.</para>
		/// </param>
		/// <returns>
		/// <para>Type: <c>BOOL</c></para>
		/// <para>If the function succeeds, the return value is nonzero.</para>
		/// <para>If the function fails, the return value is zero. To get extended error information, call GetLastError.</para>
		/// </returns>
		/// <remarks>
		/// <para>
		/// The <c>DestroyCursor</c> function destroys a nonshared cursor. Do not use this function to destroy a shared cursor. A shared
		/// cursor is valid as long as the module from which it was loaded remains in memory. The following functions obtain a shared cursor:
		/// </para>
		/// <list type="bullet">
		/// <item>
		/// <term>LoadCursor</term>
		/// </item>
		/// <item>
		/// <term>LoadCursorFromFile</term>
		/// </item>
		/// <item>
		/// <term>LoadImage (if you use the <c>LR_SHARED</c> flag)</term>
		/// </item>
		/// <item>
		/// <term>CopyImage (if you use the <c>LR_COPYRETURNORG</c> flag and the hImage parameter is a shared cursor)</term>
		/// </item>
		/// </list>
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows/desktop/api/winuser/nf-winuser-destroycursor BOOL DestroyCursor( HCURSOR hCursor );
		[DllImport(Lib.User32, SetLastError = true, ExactSpelling = true)]
		[PInvokeData("winuser.h", MSDNShortId = "destroycursor")]
		[return: MarshalAs(UnmanagedType.Bool)]
		public static extern bool DestroyCursor(HCURSOR hCursor);

		/// <summary>
		/// <para>Retrieves the screen coordinates of the rectangular area to which the cursor is confined.</para>
		/// </summary>
		/// <param name="lpRect">
		/// <para>Type: <c>LPRECT</c></para>
		/// <para>
		/// A pointer to a RECT structure that receives the screen coordinates of the confining rectangle. The structure receives the
		/// dimensions of the screen if the cursor is not confined to a rectangle.
		/// </para>
		/// </param>
		/// <returns>
		/// <para>Type: <c>BOOL</c></para>
		/// <para>If the function succeeds, the return value is nonzero.</para>
		/// <para>If the function fails, the return value is zero. To get extended error information, call GetLastError.</para>
		/// </returns>
		/// <remarks>
		/// <para>
		/// The cursor is a shared resource. If an application confines the cursor with the ClipCursor function, it must later release the
		/// cursor by using <c>ClipCursor</c> before relinquishing control to another application.
		/// </para>
		/// <para>The calling process must have <c>WINSTA_READATTRIBUTES</c> access to the window station.</para>
		/// <para>Examples</para>
		/// <para>For an example, see Confining a Cursor.</para>
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows/desktop/api/winuser/nf-winuser-getclipcursor BOOL GetClipCursor( LPRECT lpRect );
		[DllImport(Lib.User32, SetLastError = true, ExactSpelling = true)]
		[PInvokeData("winuser.h", MSDNShortId = "getclipcursor")]
		[return: MarshalAs(UnmanagedType.Bool)]
		public static extern bool GetClipCursor(out RECT lpRect);

		/// <summary>
		/// <para>Retrieves a handle to the current cursor.</para>
		/// <para>To get information on the global cursor, even if it is not owned by the current thread, use GetCursorInfo.</para>
		/// </summary>
		/// <returns>
		/// <para>Type: <c>HCURSOR</c></para>
		/// <para>The return value is the handle to the current cursor. If there is no cursor, the return value is <c>NULL</c>.</para>
		/// </returns>
		// https://docs.microsoft.com/en-us/windows/desktop/api/winuser/nf-winuser-getcursor HCURSOR GetCursor( );
		[DllImport(Lib.User32, SetLastError = false, ExactSpelling = true)]
		[PInvokeData("winuser.h", MSDNShortId = "getcursor")]
		public static extern SafeHCURSOR GetCursor();

		/// <summary>
		/// <para>Retrieves information about the global cursor.</para>
		/// </summary>
		/// <param name="pci">
		/// <para>Type: <c>PCURSORINFO</c></para>
		/// <para>
		/// A pointer to a CURSORINFO structure that receives the information. Note that you must set the <c>cbSize</c> member to before
		/// calling this function.
		/// </para>
		/// </param>
		/// <returns>
		/// <para>Type: <c>BOOL</c></para>
		/// <para>If the function succeeds, the return value is nonzero.</para>
		/// <para>If the function fails, the return value is zero. To get extended error information, call GetLastError.</para>
		/// </returns>
		// https://docs.microsoft.com/en-us/windows/desktop/api/winuser/nf-winuser-getcursorinfo BOOL GetCursorInfo( PCURSORINFO pci );
		[DllImport(Lib.User32, SetLastError = true, ExactSpelling = true)]
		[PInvokeData("winuser.h", MSDNShortId = "getcursorinfo")]
		[return: MarshalAs(UnmanagedType.Bool)]
		public static extern bool GetCursorInfo(ref CURSORINFO pci);

		/// <summary>
		/// <para>Retrieves the position of the mouse cursor, in screen coordinates.</para>
		/// </summary>
		/// <param name="lpPoint">
		/// <para>Type: <c>LPPOINT</c></para>
		/// <para>A pointer to a POINT structure that receives the screen coordinates of the cursor.</para>
		/// </param>
		/// <returns>
		/// <para>Type: <c>BOOL</c></para>
		/// <para>Returns nonzero if successful or zero otherwise. To get extended error information, call GetLastError.</para>
		/// </returns>
		/// <remarks>
		/// <para>
		/// The cursor position is always specified in screen coordinates and is not affected by the mapping mode of the window that contains
		/// the cursor.
		/// </para>
		/// <para>The calling process must have <c>WINSTA_READATTRIBUTES</c> access to the window station.</para>
		/// <para>
		/// The input desktop must be the current desktop when you call <c>GetCursorPos</c>. Call OpenInputDesktop to determine whether the
		/// current desktop is the input desktop. If it is not, call SetThreadDesktop with the <c>HDESK</c> returned by
		/// <c>OpenInputDesktop</c> to switch to that desktop.
		/// </para>
		/// <para>Examples</para>
		/// <para>For an example, see Using the Keyboard to Move the Cursor.</para>
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows/desktop/api/winuser/nf-winuser-getcursorpos BOOL GetCursorPos( LPPOINT lpPoint );
		[DllImport(Lib.User32, SetLastError = true, ExactSpelling = true)]
		[PInvokeData("winuser.h", MSDNShortId = "getcursorpos")]
		[return: MarshalAs(UnmanagedType.Bool)]
		public static extern bool GetCursorPos(out System.Drawing.Point lpPoint);

		/// <summary>
		/// <para>Retrieves the position of the cursor in physical coordinates.</para>
		/// </summary>
		/// <param name="lpPoint">
		/// <para>Type: <c>LPPOINT</c></para>
		/// <para>The position of the cursor, in physical coordinates.</para>
		/// </param>
		/// <returns>
		/// <para>Type: <c>BOOL</c></para>
		/// <para><c>TRUE</c> if successful; otherwise <c>FALSE</c>.</para>
		/// <para>GetLastError can be called to get more information about any error that is generated.</para>
		/// </returns>
		/// <remarks>
		/// <para>For a description of the difference between logicial coordinates and physical coordinates, see PhysicalToLogicalPoint.</para>
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows/desktop/api/winuser/nf-winuser-getphysicalcursorpos BOOL GetPhysicalCursorPos( LPPOINT
		// lpPoint );
		[DllImport(Lib.User32, SetLastError = true, ExactSpelling = true)]
		[PInvokeData("winuser.h", MSDNShortId = "getphysicalcursorpos")]
		[return: MarshalAs(UnmanagedType.Bool)]
		public static extern bool GetPhysicalCursorPos(out System.Drawing.Point lpPoint);

		/// <summary>
		/// <para>Loads the specified cursor resource from the executable (.EXE) file associated with an application instance.</para>
		/// <para><c>Note</c> This function has been superseded by the LoadImage function.</para>
		/// </summary>
		/// <param name="hInstance">
		/// <para>Type: <c>HINSTANCE</c></para>
		/// <para>A handle to an instance of the module whose executable file contains the cursor to be loaded.</para>
		/// </param>
		/// <param name="lpCursorName">
		/// <para>Type: <c>LPCTSTR</c></para>
		/// <para>
		/// The name of the cursor resource to be loaded. Alternatively, this parameter can consist of the resource identifier in the
		/// low-order word and zero in the high-order word. The MAKEINTRESOURCE macro can also be used to create this value. To use one of
		/// the predefined cursors, the application must set the hInstance parameter to <c>NULL</c> and the lpCursorName parameter to one the
		/// following values.
		/// </para>
		/// <list type="table">
		/// <listheader>
		/// <term>Value</term>
		/// <term>Meaning</term>
		/// </listheader>
		/// <item>
		/// <term>IDC_APPSTARTING MAKEINTRESOURCE(32650)</term>
		/// <term>Standard arrow and small hourglass</term>
		/// </item>
		/// <item>
		/// <term>IDC_ARROW MAKEINTRESOURCE(32512)</term>
		/// <term>Standard arrow</term>
		/// </item>
		/// <item>
		/// <term>IDC_CROSS MAKEINTRESOURCE(32515)</term>
		/// <term>Crosshair</term>
		/// </item>
		/// <item>
		/// <term>IDC_HAND MAKEINTRESOURCE(32649)</term>
		/// <term>Hand</term>
		/// </item>
		/// <item>
		/// <term>IDC_HELP MAKEINTRESOURCE(32651)</term>
		/// <term>Arrow and question mark</term>
		/// </item>
		/// <item>
		/// <term>IDC_IBEAM MAKEINTRESOURCE(32513)</term>
		/// <term>I-beam</term>
		/// </item>
		/// <item>
		/// <term>IDC_ICON MAKEINTRESOURCE(32641)</term>
		/// <term>Obsolete for applications marked version 4.0 or later.</term>
		/// </item>
		/// <item>
		/// <term>IDC_NO MAKEINTRESOURCE(32648)</term>
		/// <term>Slashed circle</term>
		/// </item>
		/// <item>
		/// <term>IDC_SIZE MAKEINTRESOURCE(32640)</term>
		/// <term>Obsolete for applications marked version 4.0 or later. Use IDC_SIZEALL.</term>
		/// </item>
		/// <item>
		/// <term>IDC_SIZEALL MAKEINTRESOURCE(32646)</term>
		/// <term>Four-pointed arrow pointing north, south, east, and west</term>
		/// </item>
		/// <item>
		/// <term>IDC_SIZENESW MAKEINTRESOURCE(32643)</term>
		/// <term>Double-pointed arrow pointing northeast and southwest</term>
		/// </item>
		/// <item>
		/// <term>IDC_SIZENS MAKEINTRESOURCE(32645)</term>
		/// <term>Double-pointed arrow pointing north and south</term>
		/// </item>
		/// <item>
		/// <term>IDC_SIZENWSE MAKEINTRESOURCE(32642)</term>
		/// <term>Double-pointed arrow pointing northwest and southeast</term>
		/// </item>
		/// <item>
		/// <term>IDC_SIZEWE MAKEINTRESOURCE(32644)</term>
		/// <term>Double-pointed arrow pointing west and east</term>
		/// </item>
		/// <item>
		/// <term>IDC_UPARROW MAKEINTRESOURCE(32516)</term>
		/// <term>Vertical arrow</term>
		/// </item>
		/// <item>
		/// <term>IDC_WAIT MAKEINTRESOURCE(32514)</term>
		/// <term>Hourglass</term>
		/// </item>
		/// </list>
		/// </param>
		/// <returns>
		/// <para>Type: <c>HCURSOR</c></para>
		/// <para>If the function succeeds, the return value is the handle to the newly loaded cursor.</para>
		/// <para>If the function fails, the return value is <c>NULL</c>. To get extended error information, call GetLastError.</para>
		/// </returns>
		/// <remarks>
		/// <para>
		/// The <c>LoadCursor</c> function loads the cursor resource only if it has not been loaded; otherwise, it retrieves the handle to
		/// the existing resource. This function returns a valid cursor handle only if the lpCursorName parameter is a pointer to a cursor
		/// resource. If lpCursorName is a pointer to any type of resource other than a cursor (such as an icon), the return value is not
		/// <c>NULL</c>, even though it is not a valid cursor handle.
		/// </para>
		/// <para>
		/// The <c>LoadCursor</c> function searches the cursor resource most appropriate for the cursor for the current display device. The
		/// cursor resource can be a color or monochrome bitmap.
		/// </para>
		/// <para>DPI Virtualization</para>
		/// <para>This API does not participate in DPI virtualization. The output returned is not affected by the DPI of the calling thread.</para>
		/// <para>Examples</para>
		/// <para>For an example, see Creating a Cursor.</para>
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows/desktop/api/winuser/nf-winuser-loadcursora HCURSOR LoadCursorA( HINSTANCE hInstance,
		// LPCSTR lpCursorName );
		[DllImport(Lib.User32, SetLastError = true, CharSet = CharSet.Auto)]
		[PInvokeData("winuser.h", MSDNShortId = "loadcursor")]
		public static extern SafeHCURSOR LoadCursor(HINSTANCE hInstance, string lpCursorName);

		/// <summary>
		/// <para>Loads the specified cursor resource from the executable (.EXE) file associated with an application instance.</para>
		/// <para><c>Note</c> This function has been superseded by the LoadImage function.</para>
		/// </summary>
		/// <param name="hInstance">
		/// <para>Type: <c>HINSTANCE</c></para>
		/// <para>A handle to an instance of the module whose executable file contains the cursor to be loaded.</para>
		/// </param>
		/// <param name="lpCursorName">
		/// <para>Type: <c>LPCTSTR</c></para>
		/// <para>
		/// The name of the cursor resource to be loaded. Alternatively, this parameter can consist of the resource identifier in the
		/// low-order word and zero in the high-order word. The MAKEINTRESOURCE macro can also be used to create this value. To use one of
		/// the predefined cursors, the application must set the hInstance parameter to <c>NULL</c> and the lpCursorName parameter to one the
		/// following values.
		/// </para>
		/// <list type="table">
		/// <listheader>
		/// <term>Value</term>
		/// <term>Meaning</term>
		/// </listheader>
		/// <item>
		/// <term>IDC_APPSTARTING MAKEINTRESOURCE(32650)</term>
		/// <term>Standard arrow and small hourglass</term>
		/// </item>
		/// <item>
		/// <term>IDC_ARROW MAKEINTRESOURCE(32512)</term>
		/// <term>Standard arrow</term>
		/// </item>
		/// <item>
		/// <term>IDC_CROSS MAKEINTRESOURCE(32515)</term>
		/// <term>Crosshair</term>
		/// </item>
		/// <item>
		/// <term>IDC_HAND MAKEINTRESOURCE(32649)</term>
		/// <term>Hand</term>
		/// </item>
		/// <item>
		/// <term>IDC_HELP MAKEINTRESOURCE(32651)</term>
		/// <term>Arrow and question mark</term>
		/// </item>
		/// <item>
		/// <term>IDC_IBEAM MAKEINTRESOURCE(32513)</term>
		/// <term>I-beam</term>
		/// </item>
		/// <item>
		/// <term>IDC_ICON MAKEINTRESOURCE(32641)</term>
		/// <term>Obsolete for applications marked version 4.0 or later.</term>
		/// </item>
		/// <item>
		/// <term>IDC_NO MAKEINTRESOURCE(32648)</term>
		/// <term>Slashed circle</term>
		/// </item>
		/// <item>
		/// <term>IDC_SIZE MAKEINTRESOURCE(32640)</term>
		/// <term>Obsolete for applications marked version 4.0 or later. Use IDC_SIZEALL.</term>
		/// </item>
		/// <item>
		/// <term>IDC_SIZEALL MAKEINTRESOURCE(32646)</term>
		/// <term>Four-pointed arrow pointing north, south, east, and west</term>
		/// </item>
		/// <item>
		/// <term>IDC_SIZENESW MAKEINTRESOURCE(32643)</term>
		/// <term>Double-pointed arrow pointing northeast and southwest</term>
		/// </item>
		/// <item>
		/// <term>IDC_SIZENS MAKEINTRESOURCE(32645)</term>
		/// <term>Double-pointed arrow pointing north and south</term>
		/// </item>
		/// <item>
		/// <term>IDC_SIZENWSE MAKEINTRESOURCE(32642)</term>
		/// <term>Double-pointed arrow pointing northwest and southeast</term>
		/// </item>
		/// <item>
		/// <term>IDC_SIZEWE MAKEINTRESOURCE(32644)</term>
		/// <term>Double-pointed arrow pointing west and east</term>
		/// </item>
		/// <item>
		/// <term>IDC_UPARROW MAKEINTRESOURCE(32516)</term>
		/// <term>Vertical arrow</term>
		/// </item>
		/// <item>
		/// <term>IDC_WAIT MAKEINTRESOURCE(32514)</term>
		/// <term>Hourglass</term>
		/// </item>
		/// </list>
		/// </param>
		/// <returns>
		/// <para>Type: <c>HCURSOR</c></para>
		/// <para>If the function succeeds, the return value is the handle to the newly loaded cursor.</para>
		/// <para>If the function fails, the return value is <c>NULL</c>. To get extended error information, call GetLastError.</para>
		/// </returns>
		/// <remarks>
		/// <para>
		/// The <c>LoadCursor</c> function loads the cursor resource only if it has not been loaded; otherwise, it retrieves the handle to
		/// the existing resource. This function returns a valid cursor handle only if the lpCursorName parameter is a pointer to a cursor
		/// resource. If lpCursorName is a pointer to any type of resource other than a cursor (such as an icon), the return value is not
		/// <c>NULL</c>, even though it is not a valid cursor handle.
		/// </para>
		/// <para>
		/// The <c>LoadCursor</c> function searches the cursor resource most appropriate for the cursor for the current display device. The
		/// cursor resource can be a color or monochrome bitmap.
		/// </para>
		/// <para>DPI Virtualization</para>
		/// <para>This API does not participate in DPI virtualization. The output returned is not affected by the DPI of the calling thread.</para>
		/// <para>Examples</para>
		/// <para>For an example, see Creating a Cursor.</para>
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows/desktop/api/winuser/nf-winuser-loadcursora HCURSOR LoadCursorA( HINSTANCE hInstance,
		// LPCSTR lpCursorName );
		[DllImport(Lib.User32, SetLastError = true, CharSet = CharSet.Auto)]
		[PInvokeData("winuser.h", MSDNShortId = "loadcursor")]
		public static extern SafeHCURSOR LoadCursor([Optional] HINSTANCE hInstance, ResourceId lpCursorName);

		/// <summary>
		/// <para>Creates a cursor based on data contained in a file.</para>
		/// </summary>
		/// <param name="lpFileName">
		/// <para>Type: <c>LPCTSTR</c></para>
		/// <para>The source of the file data to be used to create the cursor. The data in the file must be in either .CUR or .ANI format.</para>
		/// <para>
		/// If the high-order word of lpFileName is nonzero, it is a pointer to a string that is a fully qualified name of a file containing
		/// cursor data.
		/// </para>
		/// </param>
		/// <returns>
		/// <para>Type: <c>HCURSOR</c></para>
		/// <para>If the function is successful, the return value is a handle to the new cursor.</para>
		/// <para>
		/// If the function fails, the return value is <c>NULL</c>. To get extended error information, call GetLastError. <c>GetLastError</c>
		/// may return the following value.
		/// </para>
		/// <list type="table">
		/// <listheader>
		/// <term>Return code</term>
		/// <term>Description</term>
		/// </listheader>
		/// <item>
		/// <term>ERROR_FILE_NOT_FOUND</term>
		/// <term>The specified file cannot be found.</term>
		/// </item>
		/// </list>
		/// </returns>
		/// <remarks>
		/// <para>DPI Virtualization</para>
		/// <para>This API does not participate in DPI virtualization. The output returned is not affected by the DPI of the calling thread.</para>
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows/desktop/api/winuser/nf-winuser-loadcursorfromfilea HCURSOR LoadCursorFromFileA( LPCSTR
		// lpFileName );
		[DllImport(Lib.User32, SetLastError = true, CharSet = CharSet.Auto)]
		[PInvokeData("winuser.h", MSDNShortId = "loadcursorfromfile")]
		public static extern SafeHCURSOR LoadCursorFromFile(string lpFileName);

		/// <summary>
		/// <para>Sets the cursor shape.</para>
		/// </summary>
		/// <param name="hCursor">
		/// <para>Type: <c>HCURSOR</c></para>
		/// <para>
		/// A handle to the cursor. The cursor must have been created by the CreateCursor function or loaded by the LoadCursor or LoadImage
		/// function. If this parameter is <c>NULL</c>, the cursor is removed from the screen.
		/// </para>
		/// </param>
		/// <returns>
		/// <para>Type: <c>HCURSOR</c></para>
		/// <para>The return value is the handle to the previous cursor, if there was one.</para>
		/// <para>If there was no previous cursor, the return value is <c>NULL</c>.</para>
		/// </returns>
		/// <remarks>
		/// <para>The cursor is set only if the new cursor is different from the previous cursor; otherwise, the function returns immediately.</para>
		/// <para>
		/// The cursor is a shared resource. A window should set the cursor shape only when the cursor is in its client area or when the
		/// window is capturing mouse input. In systems without a mouse, the window should restore the previous cursor before the cursor
		/// leaves the client area or before it relinquishes control to another window.
		/// </para>
		/// <para>
		/// If your application must set the cursor while it is in a window, make sure the class cursor for the specified window's class is
		/// set to <c>NULL</c>. If the class cursor is not <c>NULL</c>, the system restores the class cursor each time the mouse is moved.
		/// </para>
		/// <para>
		/// The cursor is not shown on the screen if the internal cursor display count is less than zero. This occurs if the application uses
		/// the ShowCursor function to hide the cursor more times than to show the cursor.
		/// </para>
		/// <para>Examples</para>
		/// <para>For an example, see Displaying a Cursor.</para>
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows/desktop/api/winuser/nf-winuser-setcursor HCURSOR SetCursor( HCURSOR hCursor );
		[DllImport(Lib.User32, SetLastError = false, ExactSpelling = true)]
		[PInvokeData("winuser.h", MSDNShortId = "setcursor")]
		public static extern SafeHCURSOR SetCursor(SafeHCURSOR hCursor);

		/// <summary>
		/// <para>
		/// Moves the cursor to the specified screen coordinates. If the new coordinates are not within the screen rectangle set by the most
		/// recent ClipCursor function call, the system automatically adjusts the coordinates so that the cursor stays within the rectangle.
		/// </para>
		/// </summary>
		/// <param name="X">
		/// <para>Type: <c>int</c></para>
		/// <para>The new x-coordinate of the cursor, in screen coordinates.</para>
		/// </param>
		/// <param name="Y">
		/// <para>Type: <c>int</c></para>
		/// <para>The new y-coordinate of the cursor, in screen coordinates.</para>
		/// </param>
		/// <returns>
		/// <para>Type: <c>BOOL</c></para>
		/// <para>Returns nonzero if successful or zero otherwise. To get extended error information, call GetLastError.</para>
		/// </returns>
		/// <remarks>
		/// <para>The cursor is a shared resource. A window should move the cursor only when the cursor is in the window's client area.</para>
		/// <para>The calling process must have <c>WINSTA_WRITEATTRIBUTES</c> access to the window station.</para>
		/// <para>
		/// The input desktop must be the current desktop when you call <c>SetCursorPos</c>. Call OpenInputDesktop to determine whether the
		/// current desktop is the input desktop. If it is not, call SetThreadDesktop with the <c>HDESK</c> returned by
		/// <c>OpenInputDesktop</c> to switch to that desktop.
		/// </para>
		/// <para>Examples</para>
		/// <para>For an example, see Using the Keyboard to Move the Cursor.</para>
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows/desktop/api/winuser/nf-winuser-setcursorpos BOOL SetCursorPos( int X, int Y );
		[DllImport(Lib.User32, SetLastError = true, ExactSpelling = true)]
		[PInvokeData("winuser.h", MSDNShortId = "setcursorpos")]
		[return: MarshalAs(UnmanagedType.Bool)]
		public static extern bool SetCursorPos(int X, int Y);

		/// <summary>
		/// <para>Sets the position of the cursor in physical coordinates.</para>
		/// </summary>
		/// <param name="X">
		/// <para>Type: <c>int</c></para>
		/// <para>The new x-coordinate of the cursor, in physical coordinates.</para>
		/// </param>
		/// <param name="Y">
		/// <para>Type: <c>int</c></para>
		/// <para>The new y-coordinate of the cursor, in physical coordinates.</para>
		/// </param>
		/// <returns>
		/// <para>Type: <c>BOOL</c></para>
		/// <para><c>TRUE</c> if successful; otherwise <c>FALSE</c>.</para>
		/// </returns>
		/// <remarks>
		/// <para>For a description of the difference between logicial coordinates and physical coordinates, see PhysicalToLogicalPoint.</para>
		/// <para>GetLastError can be called to get more information about any error that is generated.</para>
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows/desktop/api/winuser/nf-winuser-setphysicalcursorpos BOOL SetPhysicalCursorPos( int X, int
		// Y );
		[DllImport(Lib.User32, SetLastError = true, ExactSpelling = true)]
		[PInvokeData("winuser.h", MSDNShortId = "setphysicalcursorpos")]
		[return: MarshalAs(UnmanagedType.Bool)]
		public static extern bool SetPhysicalCursorPos(int X, int Y);

		/// <summary>
		/// Enables an application to customize the system cursors. It replaces the contents of the system cursor specified by the id
		/// parameter with the contents of the cursor specified by the hcur parameter and then destroys hcur.
		/// </summary>
		/// <param name="hcur">
		/// <para>Type: <c>HCURSOR</c></para>
		/// <para>
		/// A handle to the cursor. The function replaces the contents of the system cursor specified by id with the contents of the cursor
		/// handled by hcur.
		/// </para>
		/// <para>
		/// The system destroys hcur by calling the DestroyCursor function. Therefore, hcur cannot be a cursor loaded using the LoadCursor
		/// function. To specify a cursor loaded from a resource, copy the cursor using the CopyCursor function, then pass the copy to <c>SetSystemCursor</c>.
		/// </para>
		/// </param>
		/// <param name="id">
		/// <para>Type: <c>DWORD</c></para>
		/// <para>The system cursor to replace with the contents of hcur. This parameter can be one of the following values.</para>
		/// <list type="table">
		/// <listheader>
		/// <term>Value</term>
		/// <term>Meaning</term>
		/// </listheader>
		/// <item>
		/// <term>OCR_APPSTARTING 32650</term>
		/// <term>Standard arrow and small hourglass</term>
		/// </item>
		/// <item>
		/// <term>OCR_NORMAL 32512</term>
		/// <term>Standard arrow</term>
		/// </item>
		/// <item>
		/// <term>OCR_CROSS 32515</term>
		/// <term>Crosshair</term>
		/// </item>
		/// <item>
		/// <term>OCR_HAND 32649</term>
		/// <term>Hand</term>
		/// </item>
		/// <item>
		/// <term>OCR_HELP 32651</term>
		/// <term>Arrow and question mark</term>
		/// </item>
		/// <item>
		/// <term>OCR_IBEAM 32513</term>
		/// <term>I-beam</term>
		/// </item>
		/// <item>
		/// <term>OCR_NO 32648</term>
		/// <term>Slashed circle</term>
		/// </item>
		/// <item>
		/// <term>OCR_SIZEALL 32646</term>
		/// <term>Four-pointed arrow pointing north, south, east, and west</term>
		/// </item>
		/// <item>
		/// <term>OCR_SIZENESW 32643</term>
		/// <term>Double-pointed arrow pointing northeast and southwest</term>
		/// </item>
		/// <item>
		/// <term>OCR_SIZENS 32645</term>
		/// <term>Double-pointed arrow pointing north and south</term>
		/// </item>
		/// <item>
		/// <term>OCR_SIZENWSE 32642</term>
		/// <term>Double-pointed arrow pointing northwest and southeast</term>
		/// </item>
		/// <item>
		/// <term>OCR_SIZEWE 32644</term>
		/// <term>Double-pointed arrow pointing west and east</term>
		/// </item>
		/// <item>
		/// <term>OCR_UP 32516</term>
		/// <term>Vertical arrow</term>
		/// </item>
		/// <item>
		/// <term>OCR_WAIT 32514</term>
		/// <term>Hourglass</term>
		/// </item>
		/// </list>
		/// </param>
		/// <returns>
		/// <para>Type: <c>BOOL</c></para>
		/// <para>If the function succeeds, the return value is nonzero.</para>
		/// <para>If the function fails, the return value is zero. To get extended error information, call GetLastError.</para>
		/// </returns>
		/// <remarks>
		/// For an application to use any of the OCR_ constants, the constant <c>OEMRESOURCE</c> must be defined before the Windows.h header
		/// file is included.
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows/desktop/api/winuser/nf-winuser-setsystemcursor BOOL SetSystemCursor( HCURSOR hcur, DWORD
		// id );
		[DllImport(Lib.User32, SetLastError = true, ExactSpelling = true)]
		[PInvokeData("winuser.h", MSDNShortId = "setsystemcursor")]
		[return: MarshalAs(UnmanagedType.Bool)]
		// Not using SafeCursorHandle as system destroys this cursor.
		public static extern bool SetSystemCursor(HCURSOR hcur, OCR id);

		/// <summary>Displays or hides the cursor.</summary>
		/// <param name="bShow">
		/// <para>Type: <c>BOOL</c></para>
		/// <para>
		/// If bShow is <c>TRUE</c>, the display count is incremented by one. If bShow is <c>FALSE</c>, the display count is decremented by one.
		/// </para>
		/// </param>
		/// <returns>
		/// <para>Type: <c>int</c></para>
		/// <para>The return value specifies the new display counter.</para>
		/// </returns>
		/// <remarks>
		/// <para><c>Windows 8</c>: Call GetCursorInfo to determine the cursor visibility.</para>
		/// <para>
		/// This function sets an internal display counter that determines whether the cursor should be displayed. The cursor is displayed
		/// only if the display count is greater than or equal to 0. If a mouse is installed, the initial display count is 0. If no mouse is
		/// installed, the display count is –1.
		/// </para>
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows/desktop/api/winuser/nf-winuser-showcursor int ShowCursor( BOOL bShow );
		[DllImport(Lib.User32, SetLastError = false, ExactSpelling = true)]
		[PInvokeData("winuser.h", MSDNShortId = "showcursor")]
		public static extern int ShowCursor([MarshalAs(UnmanagedType.Bool)] bool bShow);

		/// <summary>
		/// <para>Contains global cursor information.</para>
		/// </summary>
		// https://docs.microsoft.com/en-us/windows/desktop/api/winuser/ns-winuser-tagcursorinfo typedef struct tagCURSORINFO { DWORD cbSize;
		// DWORD flags; HCURSOR hCursor; POINT ptScreenPos; } CURSORINFO, *PCURSORINFO, *LPCURSORINFO;
		[PInvokeData("winuser.h", MSDNShortId = "cursorinfo")]
		[StructLayout(LayoutKind.Sequential, CharSet = CharSet.Auto)]
		public struct CURSORINFO
		{
			/// <summary>
			/// <para>Type: <c>DWORD</c></para>
			/// <para>The size of the structure, in bytes. The caller must set this to .</para>
			/// </summary>
			public uint cbSize;

			/// <summary>
			/// <para>Type: <c>DWORD</c></para>
			/// <para>The cursor state. This parameter can be one of the following values.</para>
			/// <list type="table">
			/// <listheader>
			/// <term>Value</term>
			/// <term>Meaning</term>
			/// </listheader>
			/// <item>
			/// <term>0</term>
			/// <term>The cursor is hidden.</term>
			/// </item>
			/// <item>
			/// <term>CURSOR_SHOWING 0x00000001</term>
			/// <term>The cursor is showing.</term>
			/// </item>
			/// <item>
			/// <term>CURSOR_SUPPRESSED 0x00000002</term>
			/// <term>
			/// Windows 8: The cursor is suppressed. This flag indicates that the system is not drawing the cursor because the user is
			/// providing input through touch or pen instead of the mouse.
			/// </term>
			/// </item>
			/// </list>
			/// </summary>
			public CursorState flags;

			/// <summary>
			/// <para>Type: <c>HCURSOR</c></para>
			/// <para>A handle to the cursor.</para>
			/// </summary>
			public HCURSOR hCursor;

			/// <summary>
			/// <para>Type: <c>POINT</c></para>
			/// <para>A structure that receives the screen coordinates of the cursor.</para>
			/// </summary>
			public System.Drawing.Point ptScreenPos;
		}

		/// <summary>Provides a <see cref="SafeHandle"/> to a Windows that disposes a created HCURSOR instance at disposal using DestroyCursor.</summary>
		public class SafeHCURSOR : SafeHANDLE, IUserHandle
		{
			/// <summary>Initializes a new instance of the <see cref="HCURSOR"/> class and assigns an existing handle.</summary>
			/// <param name="preexistingHandle">An <see cref="IntPtr"/> object that represents the pre-existing handle to use.</param>
			/// <param name="ownsHandle">
			/// <see langword="true"/> to reliably release the handle during the finalization phase; otherwise, <see langword="false"/> (not recommended).
			/// </param>
			public SafeHCURSOR(IntPtr preexistingHandle, bool ownsHandle = true) : base(preexistingHandle, ownsHandle) { }

			private SafeHCURSOR() : base()
			{
			}

			/// <summary>Performs an implicit conversion from <see cref="SafeHCURSOR"/> to <see cref="HCURSOR"/>.</summary>
			/// <param name="h">The safe handle instance.</param>
			/// <returns>The result of the conversion.</returns>
			public static implicit operator HCURSOR(SafeHCURSOR h) => h.handle;

			/// <inheritdoc/>
			protected override bool InternalReleaseHandle() => DestroyCursor(this);
		}

		/// <summary>Predefined cursors for <see cref="LoadCursor(HINSTANCE, ResourceId)"/>.</summary>
		[PInvokeData("winuser.h", MSDNShortId = "loadcursor")]
		public static class StandardCursor
		{
			/// <summary>Standard arrow</summary>
			public static readonly ResourceId IDC_ARROW = 32512;

			/// <summary>I-beam</summary>
			public static readonly ResourceId IDC_IBEAM = 32513;

			/// <summary>Hourglass</summary>
			public static readonly ResourceId IDC_WAIT = 32514;

			/// <summary>Crosshair</summary>
			public static readonly ResourceId IDC_CROSS = 32515;

			/// <summary>Vertical arrow</summary>
			public static readonly ResourceId IDC_UPARROW = 32516;

			/// <summary>Obsolete for applications marked version 4.0 or later. Use IDC_SIZEALL.</summary>
			[Obsolete("Use IDC_SIZEALL")]
			public static readonly ResourceId IDC_SIZE = 32640;  /* OBSOLETE: use IDC_SIZEALL */

			/// <summary>Obsolete for applications marked version 4.0 or later.</summary>
			[Obsolete("Use IDC_ARROW")]
			public static readonly ResourceId IDC_ICON = 32641;  /* OBSOLETE: use IDC_ARROW */

			/// <summary>Double-pointed arrow pointing northwest and southeast</summary>
			public static readonly ResourceId IDC_SIZENWSE = 32642;

			/// <summary>Double-pointed arrow pointing northeast and southwest</summary>
			public static readonly ResourceId IDC_SIZENESW = 32643;

			/// <summary>Double-pointed arrow pointing west and east</summary>
			public static readonly ResourceId IDC_SIZEWE = 32644;

			/// <summary>Double-pointed arrow pointing north and south</summary>
			public static readonly ResourceId IDC_SIZENS = 32645;

			/// <summary>Four-pointed arrow pointing north, south, east, and west</summary>
			public static readonly ResourceId IDC_SIZEALL = 32646;

			/// <summary>Slashed circle</summary>
			public static readonly ResourceId IDC_NO = 32648; /*not in win3.1 */

			/// <summary>Hand</summary>
			public static readonly ResourceId IDC_HAND = 32649;

			/// <summary>Standard arrow and small hourglass</summary>
			public static readonly ResourceId IDC_APPSTARTING = 32650; /*not in win3.1 */

			/// <summary>Arrow and question mark</summary>
			public static readonly ResourceId IDC_HELP = 32651;

			/// <summary>Undocumented</summary>
			public static readonly ResourceId IDC_PIN = 32671;

			/// <summary>Undocumented</summary>
			public static readonly ResourceId IDC_PERSON = 32672;
		}
	}
}