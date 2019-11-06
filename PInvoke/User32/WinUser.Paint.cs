using System;
using System.Runtime.InteropServices;

namespace Vanara.PInvoke
{
	public static partial class User32
	{
		/// <summary>
		/// The <c>DrawStateProc</c> function is an application-defined callback function that renders a complex image for the DrawState
		/// function. The <c>DRAWSTATEPROC</c> type defines a pointer to this callback function. <c>DrawStateProc</c> is a placeholder for
		/// the application-defined function name.
		/// </summary>
		/// <param name="hdc">
		/// A handle to the device context to draw in. The device context is a memory device context with a bitmap selected, the dimensions
		/// of which are at least as great as those specified by the <c>cx</c> and <c>cy</c> parameters.
		/// </param>
		/// <param name="lData">Specifies information about the image, which the application passed to DrawState.</param>
		/// <param name="wData">Specifies information about the image, which the application passed to DrawState.</param>
		/// <param name="cx">The image width, in device units, as specified by the call to DrawState.</param>
		/// <param name="cy">The image height, in device units, as specified by the call to DrawState.</param>
		/// <returns>
		/// <para>If the function succeeds, the return value is <c>TRUE</c>.</para>
		/// <para>If the function fails, the return value is <c>FALSE</c>.</para>
		/// </returns>
		// https://docs.microsoft.com/en-us/windows/desktop/api/winuser/nc-winuser-drawstateproc DRAWSTATEPROC Drawstateproc; BOOL
		// Drawstateproc( HDC hdc, LPARAM lData, WPARAM wData, int cx, int cy ) {...}
		[PInvokeData("winuser.h", MSDNShortId = "a95a4020-e433-4b2c-96e7-f272e28e5a43")]
		[UnmanagedFunctionPointer(CallingConvention.Winapi)]
		[return: MarshalAs(UnmanagedType.Bool)]
		public delegate bool DrawStateProc(HDC hdc, IntPtr lData, IntPtr wData, int cx, int cy);

		/// <summary>
		/// The <c>OutputProc</c> function is an application-defined callback function used with the GrayString function. It is used to draw
		/// a string. The <c>GRAYSTRINGPROC</c> type defines a pointer to this callback function. <c>OutputProc</c> is a placeholder for the
		/// application-defined or library-defined function name.
		/// </summary>
		/// <param name="hdc">
		/// A handle to a device context with a bitmap of at least the width and height specified by the nWidth and nHeight parameters passed
		/// to GrayString.
		/// </param>
		/// <param name="lpData">A pointer to the string to be drawn.</param>
		/// <param name="cchData">The length, in characters, of the string.</param>
		/// <returns>
		/// <para>If it succeeds, the callback function should return <c>TRUE</c>.</para>
		/// <para>If the function fails, the return value is <c>FALSE</c>.</para>
		/// </returns>
		/// <remarks>The callback function must draw an image relative to the coordinates (0,0).</remarks>
		// https://docs.microsoft.com/en-us/windows/desktop/api/winuser/nc-winuser-graystringproc GRAYSTRINGPROC Graystringproc; BOOL
		// Graystringproc( HDC Arg1, LPARAM Arg2, int Arg3 ) {...}
		[PInvokeData("winuser.h", MSDNShortId = "4d9145d2-5be4-4da3-9d03-01ebd74e0d06")]
		[UnmanagedFunctionPointer(CallingConvention.Winapi, CharSet = CharSet.Auto)]
		[return: MarshalAs(UnmanagedType.Bool)]
		public delegate bool OutputProc(HDC hdc, string lpData, int cchData);

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
			BF_TOPLEFT = BF_TOP | BF_LEFT,

			/// <summary>Top and right side of border rectangle.</summary>
			BF_TOPRIGHT = BF_TOP | BF_RIGHT,

			/// <summary>Bottom and left side of border rectangle.</summary>
			BF_BOTTOMLEFT = BF_BOTTOM | BF_LEFT,

			/// <summary>Bottom and right side of border rectangle.</summary>
			BF_BOTTOMRIGHT = BF_BOTTOM | BF_RIGHT,

			/// <summary>Entire border rectangle.</summary>
			BF_RECT = BF_LEFT | BF_TOP | BF_RIGHT | BF_BOTTOM,

			/// <summary>Diagonal border.</summary>
			BF_DIAGONAL = 0x0010,

			/// <summary>Diagonal border. The end point is the top-right corner of the rectangle; the origin is lower-left corner.</summary>
			BF_DIAGONAL_ENDTOPRIGHT = BF_DIAGONAL | BF_TOP | BF_RIGHT,

			/// <summary>Diagonal border. The end point is the top-left corner of the rectangle; the origin is lower-right corner.</summary>
			BF_DIAGONAL_ENDTOPLEFT = BF_DIAGONAL | BF_TOP | BF_LEFT,

			/// <summary>Diagonal border. The end point is the lower-left corner of the rectangle; the origin is top-right corner.</summary>
			BF_DIAGONAL_ENDBOTTOMLEFT = BF_DIAGONAL | BF_BOTTOM | BF_LEFT,

			/// <summary>Diagonal border. The end point is the lower-right corner of the rectangle; the origin is top-left corner.</summary>
			BF_DIAGONAL_ENDBOTTOMRIGHT = BF_DIAGONAL | BF_BOTTOM | BF_RIGHT,

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
			BDR_OUTER = BDR_RAISEDOUTER | BDR_SUNKENOUTER,

			/// <summary>Combination of BDR_RAISEDINNER and BDR_SUNKENINNER</summary>
			BDR_INNER = BDR_RAISEDINNER | BDR_SUNKENINNER,

			/// <summary>Combination of BDR_RAISEDOUTER and BDR_RAISEDINNER</summary>
			BDR_RAISED = BDR_RAISEDOUTER | BDR_RAISEDINNER,

			/// <summary>Combination of BDR_SUNKENOUTER and BDR_SUNKENINNER</summary>
			BDR_SUNKEN = BDR_SUNKENOUTER | BDR_SUNKENINNER,

			/// <summary>Combination of BDR_RAISEDOUTER and BDR_RAISEDINNER</summary>
			EDGE_RAISED = BDR_RAISEDOUTER | BDR_RAISEDINNER,

			/// <summary>Combination of BDR_SUNKENOUTER and BDR_SUNKENINNER</summary>
			EDGE_SUNKEN = BDR_SUNKENOUTER | BDR_SUNKENINNER,

			/// <summary>Combination of BDR_SUNKENOUTER and BDR_RAISEDINNER</summary>
			EDGE_ETCHED = BDR_SUNKENOUTER | BDR_RAISEDINNER,

			/// <summary>Combination of BDR_RAISEDOUTER and BDR_SUNKENINNER</summary>
			EDGE_BUMP = BDR_RAISEDOUTER | BDR_SUNKENINNER,
		}

		/// <summary>Flags used by <see cref="DrawCaption"/>.</summary>
		[PInvokeData("winuser.h", MSDNShortId = "9348e29f-ce56-4664-8862-f5810c797622")]
		[Flags]
		public enum DrawCaptionFlags
		{
			/// <summary>The function uses the colors that denote an active caption.</summary>
			DC_ACTIVE = 0x0001,

			/// <summary>The function draws a small caption, using the current small caption font.</summary>
			DC_SMALLCAP = 0x0002,

			/// <summary>The function draws the icon when drawing the caption text.</summary>
			DC_ICON = 0x0004,

			/// <summary>The function draws the caption text when drawing the caption.</summary>
			DC_TEXT = 0x0008,

			/// <summary>The function draws the caption as a button.</summary>
			DC_INBUTTON = 0x0010,

			/// <summary>
			/// When this flag is set, the function uses COLOR_GRADIENTACTIVECAPTION (if the DC_ACTIVE flag was set) or
			/// COLOR_GRADIENTINACTIVECAPTION for the title-bar color.
			/// <para>If this flag is not set, the function uses COLOR_ACTIVECAPTION or COLOR_INACTIVECAPTION for both colors.</para>
			/// </summary>
			DC_GRADIENT = 0x0020,

			/// <summary>If set, the function draws the buttons in the caption bar (to minimize, restore, or close an application).</summary>
			DC_BUTTONS = 0x1000,
		}

		/// <summary>Flags used by <see cref="DrawState(HDC, HBRUSH, DrawStateProc, IntPtr, IntPtr, int, int, int, int, DrawStateFlags)"/>.</summary>
		[PInvokeData("winuser.h", MSDNShortId = "b92150be-8264-4ea8-a2ea-d70b7fba6361")]
		[Flags]
		public enum DrawStateFlags
		{
			/// <summary>
			/// The image is application defined. To render the image, DrawState calls the callback function specified by the lpOutputFunc parameter.
			/// </summary>
			DST_COMPLEX = 0x0000,

			/// <summary>
			/// The image is text. The lData parameter is a pointer to the string, and the wData parameter specifies the length. If wData is
			/// zero, the string must be null-terminated.
			/// </summary>
			DST_TEXT = 0x0001,

			/// <summary>The image is text that may contain an accelerator mnemonic. DrawState interprets the ampersand (&amp;) prefix character
			/// as a directive to underscore the character that follows. The lData parameter is a pointer to the string, and the wData
			/// parameter specifies the length. If wData is zero, the string must be null-terminated.</summary>
			DST_PREFIXTEXT = 0x0002,

			/// <summary>The image is an icon. The lData parameter is the icon handle.</summary>
			DST_ICON = 0x0003,

			/// <summary>
			/// The image is a bitmap. The lData parameter is the bitmap handle. Note that the bitmap cannot already be selected into an
			/// existing device context.
			/// </summary>
			DST_BITMAP = 0x0004,

			/// <summary>Draws the image without any modification.</summary>
			DSS_NORMAL = 0x0000,

			/// <summary>Dithers the image.</summary>
			DSS_UNION = 0x0010,

			/// <summary>Embosses the image.</summary>
			DSS_DISABLED = 0x0020,

			/// <summary>Draws the image using the brush specified by the hbr parameter.</summary>
			DSS_MONO = 0x0080,

			/// <summary>Ignores the ampersand (&amp;) prefix character in the text, thus the letter that follows will not be underlined. This
			/// must be used with DST_PREFIXTEXT.</summary>
			DSS_HIDEPREFIX = 0x0200,

			/// <summary>Draws only the underline at the position of the letter after the ampersand (&amp;) prefix character. No text in the
			/// string is drawn. This must be used with DST_PREFIXTEXT.</summary>
			DSS_PREFIXONLY = 0x0400,

			/// <summary>Aligns the text to the right.</summary>
			DSS_RIGHT = 0x8000,
		}

		/// <summary>State of the control to draw with <see cref="DrawFrameControl"/>.</summary>
		[PInvokeData("winuser.h", MSDNShortId = "3102007e-e9f7-46d8-ae10-cf156d2131f6")]
		[Flags]
		public enum FrameControlState
		{
			/// <summary>Close button</summary>
			DFCS_CAPTIONCLOSE = 0x0000,

			/// <summary>Minimize button</summary>
			DFCS_CAPTIONMIN = 0x0001,

			/// <summary>Maximize button</summary>
			DFCS_CAPTIONMAX = 0x0002,

			/// <summary>Restore button</summary>
			DFCS_CAPTIONRESTORE = 0x0003,

			/// <summary>Help button</summary>
			DFCS_CAPTIONHELP = 0x0004,

			/// <summary>Submenu arrow</summary>
			DFCS_MENUARROW = 0x0000,

			/// <summary>Check mark</summary>
			DFCS_MENUCHECK = 0x0001,

			/// <summary>Bullet</summary>
			DFCS_MENUBULLET = 0x0002,

			/// <summary>
			/// Submenu arrow pointing left. This is used for the right-to-left cascading menus used with right-to-left languages such as
			/// Arabic or Hebrew.
			/// </summary>
			DFCS_MENUARROWRIGHT = 0x0004,

			/// <summary>Up arrow of scroll bar</summary>
			DFCS_SCROLLUP = 0x0000,

			/// <summary>Down arrow of scroll bar</summary>
			DFCS_SCROLLDOWN = 0x0001,

			/// <summary>Left arrow of scroll bar</summary>
			DFCS_SCROLLLEFT = 0x0002,

			/// <summary>Right arrow of scroll bar</summary>
			DFCS_SCROLLRIGHT = 0x0003,

			/// <summary>Combo box scroll bar</summary>
			DFCS_SCROLLCOMBOBOX = 0x0005,

			/// <summary>Size grip in lower-right corner of window</summary>
			DFCS_SCROLLSIZEGRIP = 0x0008,

			/// <summary>Size grip in lower-left corner of window. This is used with right-to-left languages such as Arabic or Hebrew.</summary>
			DFCS_SCROLLSIZEGRIPRIGHT = 0x0010,

			/// <summary>Check box</summary>
			DFCS_BUTTONCHECK = 0x0000,

			/// <summary>Image for radio button (nonsquare needs image)</summary>
			DFCS_BUTTONRADIOIMAGE = 0x0001,

			/// <summary>Mask for radio button (nonsquare needs mask)</summary>
			DFCS_BUTTONRADIOMASK = 0x0002,

			/// <summary>Radio button</summary>
			DFCS_BUTTONRADIO = 0x0004,

			/// <summary>Three-state button</summary>
			DFCS_BUTTON3STATE = 0x0008,

			/// <summary>Push button</summary>
			DFCS_BUTTONPUSH = 0x0010,

			/// <summary>Button is inactive (grayed).</summary>
			DFCS_INACTIVE = 0x0100,

			/// <summary>Button is pushed.</summary>
			DFCS_PUSHED = 0x0200,

			/// <summary>Button is checked.</summary>
			DFCS_CHECKED = 0x0400,

			/// <summary>The background remains untouched. This flag can only be combined with DFCS_MENUARROWUP or DFCS_MENUARROWDOWN.</summary>
			DFCS_TRANSPARENT = 0x0800,

			/// <summary>Button is hot-tracked.</summary>
			DFCS_HOT = 0x1000,

			/// <summary>Bounding rectangle is adjusted to exclude the surrounding edge of the push button.</summary>
			DFCS_ADJUSTRECT = 0x2000,

			/// <summary>Button has a flat border.</summary>
			DFCS_FLAT = 0x4000,

			/// <summary>Button has a monochrome border.</summary>
			DFCS_MONO = 0x8000,
		}

		/// <summary>Type of control to draw with <see cref="DrawFrameControl"/>.</summary>
		[PInvokeData("winuser.h", MSDNShortId = "3102007e-e9f7-46d8-ae10-cf156d2131f6")]
		public enum FrameControlType
		{
			/// <summary>Title bar.</summary>
			DFC_CAPTION = 1,

			/// <summary>Menu bar.</summary>
			DFC_MENU = 2,

			/// <summary>Scroll bar.</summary>
			DFC_SCROLL = 3,

			/// <summary>Standard button.</summary>
			DFC_BUTTON = 4,

			/// <summary>Popup menu item.</summary>
			DFC_POPUPMENU = 5,
		}

		/// <summary>Flags used by <see cref="DrawAnimatedRects"/>.</summary>
		[PInvokeData("winuser.h", MSDNShortId = "54a9234a-0056-4cfe-9158-86635dc31bc6")]
		public enum IDANI
		{
			/// <summary/>
			IDANI_OPEN = 1,

			/// <summary>
			/// The window caption will animate from the position specified by lprcFrom to the position specified by lprcTo. The effect is
			/// similar to minimizing or maximizing a window.
			/// </summary>
			IDANI_CAPTION = 3
		}

		/// <summary>Flags used to invalidate or validate a window, control repainting, and control which windows are affected by RedrawWindow.</summary>
		[PInvokeData("winuser.h", MSDNShortId = "c6cb7f74-237e-4d3e-a852-894da36e990c")]
		[Flags]
		public enum RedrawWindowFlags
		{
			/// <summary>Invalidates lprcUpdate or hrgnUpdate (only one may be non-NULL). If both are NULL, the entire window is invalidated.</summary>
			RDW_INVALIDATE = 0x0001,

			/// <summary>Causes a WM_PAINT message to be posted to the window regardless of whether any portion of the window is invalid.</summary>
			RDW_INTERNALPAINT = 0x0002,

			/// <summary>
			/// Causes the window to receive a WM_ERASEBKGND message when the window is repainted. The RDW_INVALIDATE flag must also be
			/// specified; otherwise, RDW_ERASE has no effect.
			/// </summary>
			RDW_ERASE = 0x0004,

			/// <summary>
			/// Validates lprcUpdate or hrgnUpdate (only one may be non-NULL). If both are NULL, the entire window is validated. This flag
			/// does not affect internal WM_PAINT messages.
			/// </summary>
			RDW_VALIDATE = 0x0008,

			/// <summary>
			/// Suppresses any pending internal WM_PAINT messages. This flag does not affect WM_PAINT messages resulting from a non-NULL
			/// update area.
			/// </summary>
			RDW_NOINTERNALPAINT = 0x0010,

			/// <summary>Suppresses any pending WM_ERASEBKGND messages.</summary>
			RDW_NOERASE = 0x0020,

			/// <summary>Excludes child windows, if any, from the repainting operation.</summary>
			RDW_NOCHILDREN = 0x0040,

			/// <summary>Includes child windows, if any, in the repainting operation.</summary>
			RDW_ALLCHILDREN = 0x0080,

			/// <summary>
			/// Causes the affected windows (as specified by the RDW_ALLCHILDREN and RDW_NOCHILDREN flags) to receive WM_NCPAINT,
			/// WM_ERASEBKGND, and WM_PAINT messages, if necessary, before the function returns.
			/// </summary>
			RDW_UPDATENOW = 0x0100,

			/// <summary>
			/// Causes the affected windows (as specified by the RDW_ALLCHILDREN and RDW_NOCHILDREN flags) to receive WM_NCPAINT and
			/// WM_ERASEBKGND messages, if necessary, before the function returns. WM_PAINT messages are received at the ordinary time.
			/// </summary>
			RDW_ERASENOW = 0x0200,

			/// <summary>
			/// Causes any part of the nonclient area of the window that intersects the update region to receive a WM_NCPAINT message. The
			/// RDW_INVALIDATE flag must also be specified; otherwise, RDW_FRAME has no effect. The WM_NCPAINT message is typically not sent
			/// during the execution of RedrawWindow unless either RDW_UPDATENOW or RDW_ERASENOW is specified.
			/// </summary>
			RDW_FRAME = 0x0400,

			/// <summary>
			/// Suppresses any pending WM_NCPAINT messages. This flag must be used with RDW_VALIDATE and is typically used with
			/// RDW_NOCHILDREN. RDW_NOFRAME should be used with care, as it could cause parts of a window to be painted improperly.
			/// </summary>
			RDW_NOFRAME = 0x0800,
		}

		/// <summary>
		/// The <c>BeginPaint</c> function prepares the specified window for painting and fills a PAINTSTRUCT structure with information
		/// about the painting.
		/// </summary>
		/// <param name="hWnd">Handle to the window to be repainted.</param>
		/// <param name="lpPaint">Pointer to the PAINTSTRUCT structure that will receive painting information.</param>
		/// <returns>
		/// <para>If the function succeeds, the return value is the handle to a display device context for the specified window.</para>
		/// <para>If the function fails, the return value is <c>NULL</c>, indicating that no display device context is available.</para>
		/// </returns>
		/// <remarks>
		/// <para>
		/// The <c>BeginPaint</c> function automatically sets the clipping region of the device context to exclude any area outside the
		/// update region. The update region is set by the InvalidateRect or InvalidateRgn function and by the system after sizing, moving,
		/// creating, scrolling, or any other operation that affects the client area. If the update region is marked for erasing,
		/// <c>BeginPaint</c> sends a <c>WM_ERASEBKGND</c> message to the window.
		/// </para>
		/// <para>
		/// An application should not call <c>BeginPaint</c> except in response to a <c>WM_PAINT</c> message. Each call to <c>BeginPaint</c>
		/// must have a corresponding call to the EndPaint function.
		/// </para>
		/// <para>If the caret is in the area to be painted, <c>BeginPaint</c> automatically hides the caret to prevent it from being erased.</para>
		/// <para>
		/// If the window's class has a background brush, <c>BeginPaint</c> uses that brush to erase the background of the update region
		/// before returning.
		/// </para>
		/// <para>DPI Virtualization</para>
		/// <para>This API does not participate in DPI virtualization. The output returned is always in terms of physical pixels.</para>
		/// <para>Examples</para>
		/// <para>For an example, see Drawing in the Client Area.</para>
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows/desktop/api/winuser/nf-winuser-beginpaint HDC BeginPaint( HWND hWnd, LPPAINTSTRUCT
		// lpPaint );
		[DllImport(Lib.User32, SetLastError = false, ExactSpelling = true)]
		[PInvokeData("winuser.h", MSDNShortId = "513341d7-bed8-469c-a067-ee71dc8860f9")]
		public static extern HDC BeginPaint(HWND hWnd, out PAINTSTRUCT lpPaint);

		/// <summary>Animates the caption of a window to indicate the opening of an icon or the minimizing or maximizing of a window.</summary>
		/// <param name="hwnd">
		/// A handle to the window whose caption should be animated on the screen. The animation will be clipped to the parent of this window.
		/// </param>
		/// <param name="idAni">
		/// The type of animation. This must be IDANI_CAPTION. With the IDANI_CAPTION animation type, the window caption will animate from
		/// the position specified by lprcFrom to the position specified by lprcTo. The effect is similar to minimizing or maximizing a window.
		/// </param>
		/// <param name="lprcFrom">
		/// A pointer to a RECT structure specifying the location and size of the icon or minimized window. Coordinates are relative to the
		/// clipping window hwnd.
		/// </param>
		/// <param name="lprcTo">
		/// A pointer to a RECT structure specifying the location and size of the restored window. Coordinates are relative to the clipping
		/// window hwnd.
		/// </param>
		/// <returns>
		/// <para>If the function succeeds, the return value is nonzero.</para>
		/// <para>If the function fails, the return value is zero.</para>
		/// </returns>
		// https://docs.microsoft.com/en-us/windows/desktop/api/winuser/nf-winuser-drawanimatedrects BOOL DrawAnimatedRects( HWND hwnd, int
		// idAni, const RECT *lprcFrom, const RECT *lprcTo );
		[DllImport(Lib.User32, SetLastError = false, ExactSpelling = true)]
		[PInvokeData("winuser.h", MSDNShortId = "54a9234a-0056-4cfe-9158-86635dc31bc6")]
		[return: MarshalAs(UnmanagedType.Bool)]
		public static extern bool DrawAnimatedRects(HWND hwnd, IDANI idAni, in RECT lprcFrom, in RECT lprcTo);

		/// <summary>The <c>DrawCaption</c> function draws a window caption.</summary>
		/// <param name="hwnd">A handle to a window that supplies text and an icon for the window caption.</param>
		/// <param name="hdc">A handle to a device context. The function draws the window caption into this device context.</param>
		/// <param name="lprect">
		/// A pointer to a RECT structure that specifies the bounding rectangle for the window caption in logical coordinates.
		/// </param>
		/// <param name="flags">
		/// <para>The drawing options. This parameter can be zero or more of the following values.</para>
		/// <list type="table">
		/// <listheader>
		/// <term>Value</term>
		/// <term>Meaning</term>
		/// </listheader>
		/// <item>
		/// <term>DC_ACTIVE</term>
		/// <term>The function uses the colors that denote an active caption.</term>
		/// </item>
		/// <item>
		/// <term>DC_BUTTONS</term>
		/// <term>If set, the function draws the buttons in the caption bar (to minimize, restore, or close an application).</term>
		/// </item>
		/// <item>
		/// <term>DC_GRADIENT</term>
		/// <term>
		/// When this flag is set, the function uses COLOR_GRADIENTACTIVECAPTION (if the DC_ACTIVE flag was set) or
		/// COLOR_GRADIENTINACTIVECAPTION for the title-bar color. If this flag is not set, the function uses COLOR_ACTIVECAPTION or
		/// COLOR_INACTIVECAPTION for both colors.
		/// </term>
		/// </item>
		/// <item>
		/// <term>DC_ICON</term>
		/// <term>The function draws the icon when drawing the caption text.</term>
		/// </item>
		/// <item>
		/// <term>DC_INBUTTON</term>
		/// <term>The function draws the caption as a button.</term>
		/// </item>
		/// <item>
		/// <term>DC_SMALLCAP</term>
		/// <term>The function draws a small caption, using the current small caption font.</term>
		/// </item>
		/// <item>
		/// <term>DC_TEXT</term>
		/// <term>The function draws the caption text when drawing the caption.</term>
		/// </item>
		/// </list>
		/// <para>If DC_SMALLCAP is specified, the function draws a normal window caption.</para>
		/// </param>
		/// <returns>
		/// <para>If the function succeeds, the return value is nonzero.</para>
		/// <para>If the function fails, the return value is zero.</para>
		/// </returns>
		// https://docs.microsoft.com/en-us/windows/desktop/api/winuser/nf-winuser-drawcaption BOOL DrawCaption( HWND hwnd, HDC hdc, const
		// RECT *lprect, UINT flags );
		[DllImport(Lib.User32, SetLastError = false, ExactSpelling = true)]
		[PInvokeData("winuser.h", MSDNShortId = "9348e29f-ce56-4664-8862-f5810c797622")]
		[return: MarshalAs(UnmanagedType.Bool)]
		public static extern bool DrawCaption(HWND hwnd, HDC hdc, in RECT lprect, DrawCaptionFlags flags);

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

		/// <summary>The <c>DrawFocusRect</c> function draws a rectangle in the style used to indicate that the rectangle has the focus.</summary>
		/// <param name="hDC">A handle to the device context.</param>
		/// <param name="lprc">A pointer to a RECT structure that specifies the logical coordinates of the rectangle.</param>
		/// <returns>
		/// <para>If the function succeeds, the return value is nonzero.</para>
		/// <para>If the function fails, the return value is zero.</para>
		/// </returns>
		/// <remarks>
		/// <para><c>DrawFocusRect</c> works only in MM_TEXT mode.</para>
		/// <para>
		/// Because <c>DrawFocusRect</c> is an XOR function, calling it a second time with the same rectangle removes the rectangle from the screen.
		/// </para>
		/// <para>
		/// This function draws a rectangle that cannot be scrolled. To scroll an area containing a rectangle drawn by this function, call
		/// <c>DrawFocusRect</c> to remove the rectangle from the screen, scroll the area, and then call <c>DrawFocusRect</c> again to draw
		/// the rectangle in the new position.
		/// </para>
		/// <para>
		/// <c>Windows XP:</c> The focus rectangle can now be thicker than 1 pixel, so it is more visible for high-resolution, high-density
		/// displays and accessibility needs. This is handled by the SPI_SETFOCUSBORDERWIDTH and SPI_SETFOCUSBORDERHEIGHT in SystemParametersInfo.
		/// </para>
		/// <para>Examples</para>
		/// <para>For an example, see "Creating an Owner-Drawn List Box" in Using List Boxes.</para>
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows/desktop/api/winuser/nf-winuser-drawfocusrect BOOL DrawFocusRect( HDC hDC, const RECT
		// *lprc );
		[DllImport(Lib.User32, SetLastError = false, ExactSpelling = true)]
		[PInvokeData("winuser.h", MSDNShortId = "a910d04f-fe4d-4fc9-a518-abac864da6f3")]
		[return: MarshalAs(UnmanagedType.Bool)]
		public static extern bool DrawFocusRect(HDC hDC, in RECT lprc);

		/// <summary>The <c>DrawFrameControl</c> function draws a frame control of the specified type and style.</summary>
		/// <param name="hdc">Handle to the device context of the window in which to draw the control.</param>
		/// <param name="lprc">
		/// Long pointer to a RECT structure that contains the logical coordinates of the bounding rectangle for frame control.
		/// </param>
		/// <param name="uType">Specifies the type of frame control to draw.</param>
		/// <param name="uState">Specifies the initial state of the frame control.</param>
		/// <returns>
		/// <para>If the function succeeds, the return value is nonzero.</para>
		/// <para>If the function fails, the return value is zero.</para>
		/// </returns>
		/// <remarks>
		/// <para>
		/// If uType is either DFC_MENU or DFC_BUTTON and uState is not DFCS_BUTTONPUSH, the frame control is a black-on-white mask (that is,
		/// a black frame control on a white background). In such cases, the application must pass a handle to a bitmap memory device
		/// control. The application can then use the associated bitmap as the hbmMask parameter to the MaskBlt function, or it can use the
		/// device context as a parameter to the BitBlt function using ROPs such as SRCAND and SRCINVERT.
		/// </para>
		/// <para>DPI Virtualization</para>
		/// <para>
		/// This API does not participate in DPI virtualization. The input given is always in terms of physical pixels, and is not related to
		/// the calling context.
		/// </para>
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows/desktop/api/winuser/nf-winuser-drawframecontrol BOOL DrawFrameControl( HDC , LPRECT ,
		// UINT , UINT );
		[DllImport(Lib.User32, SetLastError = false, ExactSpelling = true)]
		[PInvokeData("winuser.h", MSDNShortId = "3102007e-e9f7-46d8-ae10-cf156d2131f6")]
		[return: MarshalAs(UnmanagedType.Bool)]
		public static extern bool DrawFrameControl(HDC hdc, in RECT lprc, FrameControlType uType, FrameControlState uState);

		/// <summary>
		/// The <c>DrawState</c> function displays an image and applies a visual effect to indicate a state, such as a disabled or default state.
		/// </summary>
		/// <param name="hdc">A handle to the device context to draw in.</param>
		/// <param name="hbrFore">
		/// A handle to the brush used to draw the image, if the state specified by the fuFlags parameter is DSS_MONO. This parameter is
		/// ignored for other states.
		/// </param>
		/// <param name="qfnCallBack">
		/// A pointer to an application-defined callback function used to render the image. This parameter is required if the image type in
		/// fuFlags is DST_COMPLEX. It is optional and can be <c>NULL</c> if the image type is DST_TEXT. For all other image types, this
		/// parameter is ignored. For more information about the callback function, see the DrawStateProc function.
		/// </param>
		/// <param name="lData">Information about the image. The meaning of this parameter depends on the image type.</param>
		/// <param name="wData">
		/// Information about the image. The meaning of this parameter depends on the image type. It is, however, zero extended for use with
		/// the DrawStateProc function.
		/// </param>
		/// <param name="x">The horizontal location, in device units, at which to draw the image.</param>
		/// <param name="y">The vertical location, in device units, at which to draw the image.</param>
		/// <param name="cx">
		/// The width of the image, in device units. This parameter is required if the image type is DST_COMPLEX. Otherwise, it can be zero
		/// to calculate the width of the image.
		/// </param>
		/// <param name="cy">
		/// The height of the image, in device units. This parameter is required if the image type is DST_COMPLEX. Otherwise, it can be zero
		/// to calculate the height of the image.
		/// </param>
		/// <param name="uFlags">
		/// <para>The image type and state. This parameter can be one of the following type values.</para>
		/// <list type="table">
		/// <listheader>
		/// <term>Value (type)</term>
		/// <term>Meaning</term>
		/// </listheader>
		/// <item>
		/// <term>DST_BITMAP</term>
		/// <term>
		/// The image is a bitmap. The lData parameter is the bitmap handle. Note that the bitmap cannot already be selected into an existing
		/// device context.
		/// </term>
		/// </item>
		/// <item>
		/// <term>DST_COMPLEX</term>
		/// <term>
		/// The image is application defined. To render the image, DrawState calls the callback function specified by the lpOutputFunc parameter.
		/// </term>
		/// </item>
		/// <item>
		/// <term>DST_ICON</term>
		/// <term>The image is an icon. The lData parameter is the icon handle.</term>
		/// </item>
		/// <item>
		/// <term>DST_PREFIXTEXT</term>
		/// <term>
		/// The image is text that may contain an accelerator mnemonic. DrawState interprets the ampersand (&amp;) prefix character as a
		/// directive to underscore the character that follows. The lData parameter is a pointer to the string, and the wData parameter
		/// specifies the length. If wData is zero, the string must be null-terminated.
		/// </term>
		/// </item>
		/// <item>
		/// <term>DST_TEXT</term>
		/// <term>
		/// The image is text. The lData parameter is a pointer to the string, and the wData parameter specifies the length. If wData is
		/// zero, the string must be null-terminated.
		/// </term>
		/// </item>
		/// </list>
		/// <para>This parameter can also be one of the following state values.</para>
		/// <list type="table">
		/// <listheader>
		/// <term>Value (state)</term>
		/// <term>Meaning</term>
		/// </listheader>
		/// <item>
		/// <term>DSS_DISABLED</term>
		/// <term>Embosses the image.</term>
		/// </item>
		/// <item>
		/// <term>DSS_HIDEPREFIX</term>
		/// <term>
		/// Ignores the ampersand (&amp;) prefix character in the text, thus the letter that follows will not be underlined. This must be
		/// used with DST_PREFIXTEXT.
		/// </term>
		/// </item>
		/// <item>
		/// <term>DSS_MONO</term>
		/// <term>Draws the image using the brush specified by the hbr parameter.</term>
		/// </item>
		/// <item>
		/// <term>DSS_NORMAL</term>
		/// <term>Draws the image without any modification.</term>
		/// </item>
		/// <item>
		/// <term>DSS_PREFIXONLY</term>
		/// <term>
		/// Draws only the underline at the position of the letter after the ampersand (&amp;) prefix character. No text in the string is
		/// drawn. This must be used with DST_PREFIXTEXT.
		/// </term>
		/// </item>
		/// <item>
		/// <term>DSS_RIGHT</term>
		/// <term>Aligns the text to the right.</term>
		/// </item>
		/// <item>
		/// <term>DSS_UNION</term>
		/// <term>Dithers the image.</term>
		/// </item>
		/// </list>
		/// <para>For all states except DSS_NORMAL, the image is converted to monochrome before the visual effect is applied.</para>
		/// </param>
		/// <returns>
		/// <para>If the function succeeds, the return value is nonzero.</para>
		/// <para>If the function fails, the return value is zero.</para>
		/// </returns>
		// https://docs.microsoft.com/en-us/windows/desktop/api/winuser/nf-winuser-drawstatea BOOL DrawStateA( HDC hdc, HBRUSH hbrFore,
		// DRAWSTATEPROC qfnCallBack, LPARAM lData, WPARAM wData, int x, int y, int cx, int cy, UINT uFlags );
		[DllImport(Lib.User32, SetLastError = false, CharSet = CharSet.Auto)]
		[PInvokeData("winuser.h", MSDNShortId = "b92150be-8264-4ea8-a2ea-d70b7fba6361")]
		[return: MarshalAs(UnmanagedType.Bool)]
		public static extern bool DrawState(HDC hdc, HBRUSH hbrFore, DrawStateProc qfnCallBack, IntPtr lData, IntPtr wData, int x, int y, int cx, int cy, DrawStateFlags uFlags);

		/// <summary>
		/// The <c>DrawState</c> function displays an image and applies a visual effect to indicate a state, such as a disabled or default state.
		/// </summary>
		/// <param name="hdc">A handle to the device context to draw in.</param>
		/// <param name="hbrFore">
		/// A handle to the brush used to draw the image, if the state specified by the fuFlags parameter is DSS_MONO. This parameter is
		/// ignored for other states.
		/// </param>
		/// <param name="qfnCallBack">
		/// A pointer to an application-defined callback function used to render the image. This parameter is required if the image type in
		/// fuFlags is DST_COMPLEX. It is optional and can be <c>NULL</c> if the image type is DST_TEXT. For all other image types, this
		/// parameter is ignored. For more information about the callback function, see the DrawStateProc function.
		/// </param>
		/// <param name="lData">Information about the image. The meaning of this parameter depends on the image type.</param>
		/// <param name="wData">
		/// Information about the image. The meaning of this parameter depends on the image type. It is, however, zero extended for use with
		/// the DrawStateProc function.
		/// </param>
		/// <param name="x">The horizontal location, in device units, at which to draw the image.</param>
		/// <param name="y">The vertical location, in device units, at which to draw the image.</param>
		/// <param name="cx">
		/// The width of the image, in device units. This parameter is required if the image type is DST_COMPLEX. Otherwise, it can be zero
		/// to calculate the width of the image.
		/// </param>
		/// <param name="cy">
		/// The height of the image, in device units. This parameter is required if the image type is DST_COMPLEX. Otherwise, it can be zero
		/// to calculate the height of the image.
		/// </param>
		/// <param name="uFlags">
		/// <para>The image type and state. This parameter can be one of the following type values.</para>
		/// <list type="table">
		/// <listheader>
		/// <term>Value (type)</term>
		/// <term>Meaning</term>
		/// </listheader>
		/// <item>
		/// <term>DST_BITMAP</term>
		/// <term>
		/// The image is a bitmap. The lData parameter is the bitmap handle. Note that the bitmap cannot already be selected into an existing
		/// device context.
		/// </term>
		/// </item>
		/// <item>
		/// <term>DST_COMPLEX</term>
		/// <term>
		/// The image is application defined. To render the image, DrawState calls the callback function specified by the lpOutputFunc parameter.
		/// </term>
		/// </item>
		/// <item>
		/// <term>DST_ICON</term>
		/// <term>The image is an icon. The lData parameter is the icon handle.</term>
		/// </item>
		/// <item>
		/// <term>DST_PREFIXTEXT</term>
		/// <term>
		/// The image is text that may contain an accelerator mnemonic. DrawState interprets the ampersand (&amp;) prefix character as a
		/// directive to underscore the character that follows. The lData parameter is a pointer to the string, and the wData parameter
		/// specifies the length. If wData is zero, the string must be null-terminated.
		/// </term>
		/// </item>
		/// <item>
		/// <term>DST_TEXT</term>
		/// <term>
		/// The image is text. The lData parameter is a pointer to the string, and the wData parameter specifies the length. If wData is
		/// zero, the string must be null-terminated.
		/// </term>
		/// </item>
		/// </list>
		/// <para>This parameter can also be one of the following state values.</para>
		/// <list type="table">
		/// <listheader>
		/// <term>Value (state)</term>
		/// <term>Meaning</term>
		/// </listheader>
		/// <item>
		/// <term>DSS_DISABLED</term>
		/// <term>Embosses the image.</term>
		/// </item>
		/// <item>
		/// <term>DSS_HIDEPREFIX</term>
		/// <term>
		/// Ignores the ampersand (&amp;) prefix character in the text, thus the letter that follows will not be underlined. This must be
		/// used with DST_PREFIXTEXT.
		/// </term>
		/// </item>
		/// <item>
		/// <term>DSS_MONO</term>
		/// <term>Draws the image using the brush specified by the hbr parameter.</term>
		/// </item>
		/// <item>
		/// <term>DSS_NORMAL</term>
		/// <term>Draws the image without any modification.</term>
		/// </item>
		/// <item>
		/// <term>DSS_PREFIXONLY</term>
		/// <term>
		/// Draws only the underline at the position of the letter after the ampersand (&amp;) prefix character. No text in the string is
		/// drawn. This must be used with DST_PREFIXTEXT.
		/// </term>
		/// </item>
		/// <item>
		/// <term>DSS_RIGHT</term>
		/// <term>Aligns the text to the right.</term>
		/// </item>
		/// <item>
		/// <term>DSS_UNION</term>
		/// <term>Dithers the image.</term>
		/// </item>
		/// </list>
		/// <para>For all states except DSS_NORMAL, the image is converted to monochrome before the visual effect is applied.</para>
		/// </param>
		/// <returns>
		/// <para>If the function succeeds, the return value is nonzero.</para>
		/// <para>If the function fails, the return value is zero.</para>
		/// </returns>
		// https://docs.microsoft.com/en-us/windows/desktop/api/winuser/nf-winuser-drawstatea BOOL DrawStateA( HDC hdc, HBRUSH hbrFore,
		// DRAWSTATEPROC qfnCallBack, LPARAM lData, WPARAM wData, int x, int y, int cx, int cy, UINT uFlags );
		[DllImport(Lib.User32, SetLastError = false, CharSet = CharSet.Auto)]
		[PInvokeData("winuser.h", MSDNShortId = "b92150be-8264-4ea8-a2ea-d70b7fba6361")]
		[return: MarshalAs(UnmanagedType.Bool)]
		public static extern bool DrawState(HDC hdc, HBRUSH hbrFore, DrawStateProc qfnCallBack, string lData, IntPtr wData, int x, int y, int cx, int cy, DrawStateFlags uFlags);

		/// <summary>
		/// The <c>EndPaint</c> function marks the end of painting in the specified window. This function is required for each call to the
		/// BeginPaint function, but only after painting is complete.
		/// </summary>
		/// <param name="hWnd">Handle to the window that has been repainted.</param>
		/// <param name="lpPaint">Pointer to a PAINTSTRUCT structure that contains the painting information retrieved by BeginPaint.</param>
		/// <returns>The return value is always nonzero.</returns>
		/// <remarks>
		/// <para>If the caret was hidden by BeginPaint, <c>EndPaint</c> restores the caret to the screen.</para>
		/// <para><c>EndPaint</c> releases the display device context that BeginPaint retrieved.</para>
		/// <para>Examples</para>
		/// <para>For an example, see Drawing in the Client Area.</para>
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows/desktop/api/winuser/nf-winuser-endpaint BOOL EndPaint( HWND hWnd, const PAINTSTRUCT
		// *lpPaint );
		[DllImport(Lib.User32, SetLastError = false, ExactSpelling = true)]
		[PInvokeData("winuser.h", MSDNShortId = "b07cfed9-21c4-4459-855a-eaf4d1d34ab8")]
		[return: MarshalAs(UnmanagedType.Bool)]
		public static extern bool EndPaint(HWND hWnd, in PAINTSTRUCT lpPaint);

		/// <summary>
		/// The <c>ExcludeUpdateRgn</c> function prevents drawing within invalid areas of a window by excluding an updated region in the
		/// window from a clipping region.
		/// </summary>
		/// <param name="hDC">Handle to the device context associated with the clipping region.</param>
		/// <param name="hWnd">Handle to the window to update.</param>
		/// <returns>
		/// <para>The return value specifies the complexity of the excluded region; it can be any one of the following values.</para>
		/// <list type="table">
		/// <listheader>
		/// <term>Value</term>
		/// <term>Meaning</term>
		/// </listheader>
		/// <item>
		/// <term>COMPLEXREGION</term>
		/// <term>Region consists of more than one rectangle.</term>
		/// </item>
		/// <item>
		/// <term>ERROR</term>
		/// <term>An error occurred.</term>
		/// </item>
		/// <item>
		/// <term>NULLREGION</term>
		/// <term>Region is empty.</term>
		/// </item>
		/// <item>
		/// <term>SIMPLEREGION</term>
		/// <term>Region is a single rectangle.</term>
		/// </item>
		/// </list>
		/// </returns>
		// https://docs.microsoft.com/en-us/windows/desktop/api/winuser/nf-winuser-excludeupdatergn int ExcludeUpdateRgn( HDC hDC, HWND hWnd );
		[DllImport(Lib.User32, SetLastError = false, ExactSpelling = true)]
		[PInvokeData("winuser.h", MSDNShortId = "408fda82-30c3-4eb4-be42-3085c71ba99e")]
		public static extern Gdi32.RegionFlags ExcludeUpdateRgn(HDC hDC, HWND hWnd);

		/// <summary>
		/// The <c>FillRect</c> function fills a rectangle by using the specified brush. This function includes the left and top borders, but
		/// excludes the right and bottom borders of the rectangle.
		/// </summary>
		/// <param name="hDC">A handle to the device context.</param>
		/// <param name="lprc">A pointer to a RECT structure that contains the logical coordinates of the rectangle to be filled.</param>
		/// <param name="hbr">A handle to the brush used to fill the rectangle.</param>
		/// <returns>
		/// <para>If the function succeeds, the return value is nonzero.</para>
		/// <para>If the function fails, the return value is zero.</para>
		/// </returns>
		/// <remarks>
		/// <para>
		/// The brush identified by the hbr parameter may be either a handle to a logical brush or a color value. If specifying a handle to a
		/// logical brush, call one of the following functions to obtain the handle: CreateHatchBrush, CreatePatternBrush, or
		/// CreateSolidBrush. Additionally, you may retrieve a handle to one of the stock brushes by using the GetStockObject function. If
		/// specifying a color value for the hbr parameter, it must be one of the standard system colors (the value 1 must be added to the
		/// chosen color). For example:
		/// </para>
		/// <para>For a list of all the standard system colors, see GetSysColor.</para>
		/// <para>
		/// When filling the specified rectangle, <c>FillRect</c> does not include the rectangle's right and bottom sides. GDI fills a
		/// rectangle up to, but not including, the right column and bottom row, regardless of the current mapping mode.
		/// </para>
		/// <para>Examples</para>
		/// <para>For an example, see Using Rectangles.</para>
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows/desktop/api/winuser/nf-winuser-fillrect int FillRect( HDC hDC, const RECT *lprc, HBRUSH
		// hbr );
		[DllImport(Lib.User32, SetLastError = false, ExactSpelling = true)]
		[PInvokeData("winuser.h", MSDNShortId = "98ab34da-ea07-4446-a62e-509c849d95f9")]
		[return: MarshalAs(UnmanagedType.Bool)]
		public static extern bool FillRect(HDC hDC, in RECT lprc, HBRUSH hbr);

		/// <summary>
		/// The <c>FrameRect</c> function draws a border around the specified rectangle by using the specified brush. The width and height of
		/// the border are always one logical unit.
		/// </summary>
		/// <param name="hDC">A handle to the device context in which the border is drawn.</param>
		/// <param name="lprc">
		/// A pointer to a RECT structure that contains the logical coordinates of the upper-left and lower-right corners of the rectangle.
		/// </param>
		/// <param name="hbr">A handle to the brush used to draw the border.</param>
		/// <returns>
		/// <para>If the function succeeds, the return value is nonzero.</para>
		/// <para>If the function fails, the return value is zero.</para>
		/// </returns>
		/// <remarks>
		/// <para>
		/// The brush identified by the hbr parameter must have been created by using the CreateHatchBrush, CreatePatternBrush, or
		/// CreateSolidBrush function, or retrieved by using the GetStockObject function.
		/// </para>
		/// <para>
		/// If the <c>bottom</c> member of the RECT structure is less than the <c>top</c> member, or if the <c>right</c> member is less than
		/// the <c>left</c> member, the function does not draw the rectangle.
		/// </para>
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows/desktop/api/winuser/nf-winuser-framerect int FrameRect( HDC hDC, const RECT *lprc, HBRUSH
		// hbr );
		[DllImport(Lib.User32, SetLastError = false, ExactSpelling = true)]
		[PInvokeData("winuser.h", MSDNShortId = "a1083cb5-5e6c-4134-badf-9fc5142d1453")]
		[return: MarshalAs(UnmanagedType.Bool)]
		public static extern bool FrameRect(HDC hDC, in RECT lprc, HBRUSH hbr);

		/// <summary>
		/// The <c>GetUpdateRect</c> function retrieves the coordinates of the smallest rectangle that completely encloses the update region
		/// of the specified window. <c>GetUpdateRect</c> retrieves the rectangle in logical coordinates. If there is no update region,
		/// <c>GetUpdateRect</c> retrieves an empty rectangle (sets all coordinates to zero).
		/// </summary>
		/// <param name="hWnd">Handle to the window whose update region is to be retrieved.</param>
		/// <param name="lpRect">
		/// <para>Pointer to the RECT structure that receives the coordinates, in device units, of the enclosing rectangle.</para>
		/// <para>
		/// An application can set this parameter to <c>NULL</c> to determine whether an update region exists for the window. If this
		/// parameter is <c>NULL</c>, <c>GetUpdateRect</c> returns nonzero if an update region exists, and zero if one does not. This
		/// provides a simple and efficient means of determining whether a <c>WM_PAINT</c> message resulted from an invalid area.
		/// </para>
		/// </param>
		/// <param name="bErase">
		/// Specifies whether the background in the update region is to be erased. If this parameter is <c>TRUE</c> and the update region is
		/// not empty, <c>GetUpdateRect</c> sends a <c>WM_ERASEBKGND</c> message to the specified window to erase the background.
		/// </param>
		/// <returns>
		/// <para>If the update region is not empty, the return value is nonzero.</para>
		/// <para>If there is no update region, the return value is zero.</para>
		/// </returns>
		/// <remarks>
		/// <para>The update rectangle retrieved by the BeginPaint function is identical to that retrieved by <c>GetUpdateRect</c>.</para>
		/// <para>
		/// BeginPaint automatically validates the update region, so any call to <c>GetUpdateRect</c> made immediately after the call to
		/// <c>BeginPaint</c> retrieves an empty update region.
		/// </para>
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows/desktop/api/winuser/nf-winuser-getupdaterect BOOL GetUpdateRect( HWND hWnd, LPRECT
		// lpRect, BOOL bErase );
		[DllImport(Lib.User32, SetLastError = false, ExactSpelling = true)]
		[PInvokeData("winuser.h", MSDNShortId = "e54483a1-8738-4b22-a24e-c0b31f6ca9d6")]
		[return: MarshalAs(UnmanagedType.Bool)]
		public static extern bool GetUpdateRect(HWND hWnd, PRECT lpRect, [MarshalAs(UnmanagedType.Bool)] bool bErase);

		/// <summary>
		/// The <c>GetUpdateRgn</c> function retrieves the update region of a window by copying it into the specified region. The coordinates
		/// of the update region are relative to the upper-left corner of the window (that is, they are client coordinates).
		/// </summary>
		/// <param name="hWnd">Handle to the window with an update region that is to be retrieved.</param>
		/// <param name="hRgn">Handle to the region to receive the update region.</param>
		/// <param name="bErase">
		/// Specifies whether the window background should be erased and whether nonclient areas of child windows should be drawn. If this
		/// parameter is <c>FALSE</c>, no drawing is done.
		/// </param>
		/// <returns>
		/// <para>The return value indicates the complexity of the resulting region; it can be one of the following values.</para>
		/// <list type="table">
		/// <listheader>
		/// <term>Value</term>
		/// <term>Meaning</term>
		/// </listheader>
		/// <item>
		/// <term>COMPLEXREGION</term>
		/// <term>Region consists of more than one rectangle.</term>
		/// </item>
		/// <item>
		/// <term>ERROR</term>
		/// <term>An error occurred.</term>
		/// </item>
		/// <item>
		/// <term>NULLREGION</term>
		/// <term>Region is empty.</term>
		/// </item>
		/// <item>
		/// <term>SIMPLEREGION</term>
		/// <term>Region is a single rectangle.</term>
		/// </item>
		/// </list>
		/// </returns>
		/// <remarks>
		/// The BeginPaint function automatically validates the update region, so any call to <c>GetUpdateRgn</c> made immediately after the
		/// call to <c>BeginPaint</c> retrieves an empty update region.
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows/desktop/api/winuser/nf-winuser-getupdatergn int GetUpdateRgn( HWND hWnd, HRGN hRgn, BOOL
		// bErase );
		[DllImport(Lib.User32, SetLastError = false, ExactSpelling = true)]
		[PInvokeData("winuser.h", MSDNShortId = "d80c4b44-3f50-46f9-bf5a-fff7868d91ba")]
		public static extern Gdi32.RegionFlags GetUpdateRgn(HWND hWnd, HRGN hRgn, [MarshalAs(UnmanagedType.Bool)] bool bErase);

		/// <summary>
		/// <para>
		/// The <c>GetWindowDC</c> function retrieves the device context (DC) for the entire window, including title bar, menus, and scroll
		/// bars. A window device context permits painting anywhere in a window, because the origin of the device context is the upper-left
		/// corner of the window instead of the client area.
		/// </para>
		/// <para>
		/// <c>GetWindowDC</c> assigns default attributes to the window device context each time it retrieves the device context. Previous
		/// attributes are lost.
		/// </para>
		/// </summary>
		/// <param name="hWnd">
		/// <para>
		/// A handle to the window with a device context that is to be retrieved. If this value is <c>NULL</c>, <c>GetWindowDC</c> retrieves
		/// the device context for the entire screen.
		/// </para>
		/// <para>
		/// If this parameter is <c>NULL</c>, <c>GetWindowDC</c> retrieves the device context for the primary display monitor. To get the
		/// device context for other display monitors, use the EnumDisplayMonitors and CreateDC functions.
		/// </para>
		/// </param>
		/// <returns>
		/// <para>If the function succeeds, the return value is a handle to a device context for the specified window.</para>
		/// <para>If the function fails, the return value is <c>NULL</c>, indicating an error or an invalid hWnd parameter.</para>
		/// </returns>
		/// <remarks>
		/// <para>
		/// <c>GetWindowDC</c> is intended for special painting effects within a window's nonclient area. Painting in nonclient areas of any
		/// window is not recommended.
		/// </para>
		/// <para>
		/// The GetSystemMetrics function can be used to retrieve the dimensions of various parts of the nonclient area, such as the title
		/// bar, menu, and scroll bars.
		/// </para>
		/// <para>The GetDC function can be used to retrieve a device context for the entire screen.</para>
		/// <para>
		/// After painting is complete, the ReleaseDC function must be called to release the device context. Not releasing the window device
		/// context has serious effects on painting requested by applications.
		/// </para>
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows/desktop/api/winuser/nf-winuser-getwindowdc HDC GetWindowDC( HWND hWnd );
		[DllImport(Lib.User32, SetLastError = false, ExactSpelling = true)]
		[PInvokeData("winuser.h", MSDNShortId = "9e6a135e-e337-4129-a3ad-faf9a8ac9b2d")]
		public static extern HDC GetWindowDC(HWND hWnd);

		/// <summary>
		/// The <c>GetWindowRgn</c> function obtains a copy of the window region of a window. The window region of a window is set by calling
		/// the SetWindowRgn function. The window region determines the area within the window where the system permits drawing. The system
		/// does not display any portion of a window that lies outside of the window region
		/// </summary>
		/// <param name="hWnd">Handle to the window whose window region is to be obtained.</param>
		/// <param name="hRgn">Handle to the region which will be modified to represent the window region.</param>
		/// <returns>
		/// <para>The return value specifies the type of the region that the function obtains. It can be one of the following values.</para>
		/// <list type="table">
		/// <listheader>
		/// <term>Return code</term>
		/// <term>Description</term>
		/// </listheader>
		/// <item>
		/// <term>NULLREGION</term>
		/// <term>The region is empty.</term>
		/// </item>
		/// <item>
		/// <term>SIMPLEREGION</term>
		/// <term>The region is a single rectangle.</term>
		/// </item>
		/// <item>
		/// <term>COMPLEXREGION</term>
		/// <term>The region is more than one rectangle.</term>
		/// </item>
		/// <item>
		/// <term>ERROR</term>
		/// <term>The specified window does not have a region, or an error occurred while attempting to return the region.</term>
		/// </item>
		/// </list>
		/// </returns>
		/// <remarks>
		/// <para>
		/// The coordinates of a window's window region are relative to the upper-left corner of the window, not the client area of the window.
		/// </para>
		/// <para>To set the window region of a window, call the SetWindowRgn function.</para>
		/// <para>Examples</para>
		/// <para>The following code shows how you pass in the handle of an existing region.</para>
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows/desktop/api/winuser/nf-winuser-getwindowrgn int GetWindowRgn( HWND hWnd, HRGN hRgn );
		[DllImport(Lib.User32, SetLastError = false, ExactSpelling = true)]
		[PInvokeData("winuser.h", MSDNShortId = "c8a8fa46-354b-489e-b016-fd2e728958ce")]
		public static extern Gdi32.RegionFlags GetWindowRgn(HWND hWnd, HRGN hRgn);

		/// <summary>
		/// The <c>GetWindowRgnBox</c> function retrieves the dimensions of the tightest bounding rectangle for the window region of a window.
		/// </summary>
		/// <param name="hWnd">Handle to the window.</param>
		/// <param name="lprc">
		/// Pointer to a RECT structure that receives the rectangle dimensions, in device units relative to the upper-left corner of the window.
		/// </param>
		/// <returns>
		/// <para>The return value specifies the type of the region that the function obtains. It can be one of the following values.</para>
		/// <list type="table">
		/// <listheader>
		/// <term>Value</term>
		/// <term>Meaning</term>
		/// </listheader>
		/// <item>
		/// <term>COMPLEXREGION</term>
		/// <term>The region is more than one rectangle.</term>
		/// </item>
		/// <item>
		/// <term>ERROR</term>
		/// <term>The specified window does not have a region, or an error occurred while attempting to return the region.</term>
		/// </item>
		/// <item>
		/// <term>NULLREGION</term>
		/// <term>The region is empty.</term>
		/// </item>
		/// <item>
		/// <term>SIMPLEREGION</term>
		/// <term>The region is a single rectangle.</term>
		/// </item>
		/// </list>
		/// </returns>
		/// <remarks>
		/// <para>
		/// The window region determines the area within the window where the system permits drawing. The system does not display any portion
		/// of a window that lies outside of the window region. The coordinates of a window's window region are relative to the upper-left
		/// corner of the window, not the client area of the window.
		/// </para>
		/// <para>To set the window region of a window, call the SetWindowRgn function.</para>
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows/desktop/api/winuser/nf-winuser-getwindowrgnbox int GetWindowRgnBox( HWND hWnd, LPRECT
		// lprc );
		[DllImport(Lib.User32, SetLastError = false, ExactSpelling = true)]
		[PInvokeData("winuser.h", MSDNShortId = "20e23474-a1c5-4afe-976e-a7e5790fb91b")]
		public static extern Gdi32.RegionFlags GetWindowRgnBox(HWND hWnd, out RECT lprc);

		/// <summary>
		/// <para>
		/// The <c>GrayString</c> function draws gray text at the specified location. The function draws the text by copying it into a memory
		/// bitmap, graying the bitmap, and then copying the bitmap to the screen. The function grays the text regardless of the selected
		/// brush and background. <c>GrayString</c> uses the font currently selected for the specified device context.
		/// </para>
		/// <para>
		/// If thelpOutputFuncparameter is <c>NULL</c>, GDI uses the TextOut function, and thelpDataparameter is assumed to be a pointer to
		/// the character string to be output. If the characters to be output cannot be handled by <c>TextOut</c> (for example, the string is
		/// stored as a bitmap), the application must supply its own output function.
		/// </para>
		/// </summary>
		/// <param name="hDC">A handle to the device context.</param>
		/// <param name="hBrush">
		/// A handle to the brush to be used for graying. If this parameter is <c>NULL</c>, the text is grayed with the same brush that was
		/// used to draw window text.
		/// </param>
		/// <param name="lpOutputFunc">
		/// A pointer to the application-defined function that will draw the string, or, if TextOut is to be used to draw the string, it is a
		/// <c>NULL</c> pointer. For details, see the OutputProc callback function.
		/// </param>
		/// <param name="lpData">
		/// A pointer to data to be passed to the output function. If the lpOutputFunc parameter is <c>NULL</c>, lpData must be a pointer to
		/// the string to be output.
		/// </param>
		/// <param name="nCount">
		/// The number of characters to be output. If the nCount parameter is zero, <c>GrayString</c> calculates the length of the string
		/// (assuming lpData is a pointer to the string). If nCount is 1 and the function pointed to by lpOutputFunc returns <c>FALSE</c>,
		/// the image is shown but not grayed.
		/// </param>
		/// <param name="X">The device x-coordinate of the starting position of the rectangle that encloses the string.</param>
		/// <param name="Y">The device y-coordinate of the starting position of the rectangle that encloses the string.</param>
		/// <param name="nWidth">
		/// The width, in device units, of the rectangle that encloses the string. If this parameter is zero, <c>GrayString</c> calculates
		/// the width of the area, assuming lpData is a pointer to the string.
		/// </param>
		/// <param name="nHeight">
		/// The height, in device units, of the rectangle that encloses the string. If this parameter is zero, <c>GrayString</c> calculates
		/// the height of the area, assuming lpData is a pointer to the string.
		/// </param>
		/// <returns>
		/// <para>If the string is drawn, the return value is nonzero.</para>
		/// <para>
		/// If either the TextOut function or the application-defined output function returned zero, or there was insufficient memory to
		/// create a memory bitmap for graying, the return value is zero.
		/// </para>
		/// </returns>
		/// <remarks>
		/// Without calling <c>GrayString</c>, an application can draw grayed strings on devices that support a solid gray color. The system
		/// color COLOR_GRAYTEXT is the solid-gray system color used to draw disabled text. The application can call the GetSysColor function
		/// to retrieve the color value of COLOR_GRAYTEXT. If the color is other than zero (black), the application can call the SetTextColor
		/// function to set the text color to the color value and then draw the string directly. If the retrieved color is black, the
		/// application must call <c>GrayString</c> to gray the text.
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows/desktop/api/winuser/nf-winuser-graystringa BOOL GrayStringA( HDC hDC, HBRUSH hBrush,
		// GRAYSTRINGPROC lpOutputFunc, LPARAM lpData, int nCount, int X, int Y, int nWidth, int nHeight );
		[DllImport(Lib.User32, SetLastError = false, CharSet = CharSet.Auto)]
		[PInvokeData("winuser.h", MSDNShortId = "b14b8c40-f97f-4e41-8d8d-687692acfda9")]
		[return: MarshalAs(UnmanagedType.Bool)]
		public static extern bool GrayString(HDC hDC, HBRUSH hBrush, OutputProc lpOutputFunc, string lpData, int nCount, int X, int Y, int nWidth, int nHeight);

		/// <summary>
		/// The <c>InvalidateRect</c> function adds a rectangle to the specified window's update region. The update region represents the
		/// portion of the window's client area that must be redrawn.
		/// </summary>
		/// <param name="hWnd">
		/// A handle to the window whose update region has changed. If this parameter is <c>NULL</c>, the system invalidates and redraws all
		/// windows, not just the windows for this application, and sends the WM_ERASEBKGND and WM_NCPAINT messages before the function
		/// returns. Setting this parameter to <c>NULL</c> is not recommended.
		/// </param>
		/// <param name="lpRect">
		/// A pointer to a RECT structure that contains the client coordinates of the rectangle to be added to the update region. If this
		/// parameter is <c>NULL</c>, the entire client area is added to the update region.
		/// </param>
		/// <param name="bErase">
		/// Specifies whether the background within the update region is to be erased when the update region is processed. If this parameter
		/// is <c>TRUE</c>, the background is erased when the BeginPaint function is called. If this parameter is <c>FALSE</c>, the
		/// background remains unchanged.
		/// </param>
		/// <returns>
		/// <para>If the function succeeds, the return value is nonzero.</para>
		/// <para>If the function fails, the return value is zero.</para>
		/// </returns>
		/// <remarks>
		/// <para>
		/// The invalidated areas accumulate in the update region until the region is processed when the next WM_PAINT message occurs or
		/// until the region is validated by using the ValidateRect or ValidateRgn function.
		/// </para>
		/// <para>
		/// The system sends a WM_PAINT message to a window whenever its update region is not empty and there are no other messages in the
		/// application queue for that window.
		/// </para>
		/// <para>
		/// If the bErase parameter is <c>TRUE</c> for any part of the update region, the background is erased in the entire region, not just
		/// in the specified part.
		/// </para>
		/// <para>Examples</para>
		/// <para>For an example, see Invalidating the Client Area.</para>
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows/desktop/api/winuser/nf-winuser-invalidaterect BOOL InvalidateRect( HWND hWnd, const RECT
		// *lpRect, BOOL bErase );
		[DllImport(Lib.User32, SetLastError = false, ExactSpelling = true)]
		[PInvokeData("winuser.h", MSDNShortId = "5a823d36-d08b-41c9-8857-540576f54b55")]
		[return: MarshalAs(UnmanagedType.Bool)]
		public static extern bool InvalidateRect(HWND hWnd, [In] PRECT lpRect, [MarshalAs(UnmanagedType.Bool)] bool bErase);

		/// <summary>
		/// The <c>InvalidateRgn</c> function invalidates the client area within the specified region by adding it to the current update
		/// region of a window. The invalidated region, along with all other areas in the update region, is marked for painting when the next
		/// WM_PAINT message occurs.
		/// </summary>
		/// <param name="hWnd">A handle to the window with an update region that is to be modified.</param>
		/// <param name="hRgn">
		/// A handle to the region to be added to the update region. The region is assumed to have client coordinates. If this parameter is
		/// <c>NULL</c>, the entire client area is added to the update region.
		/// </param>
		/// <param name="bErase">
		/// Specifies whether the background within the update region should be erased when the update region is processed. If this parameter
		/// is <c>TRUE</c>, the background is erased when the BeginPaint function is called. If the parameter is <c>FALSE</c>, the background
		/// remains unchanged.
		/// </param>
		/// <returns>The return value is always nonzero.</returns>
		/// <remarks>
		/// <para>
		/// Invalidated areas accumulate in the update region until the next WM_PAINT message is processed or until the region is validated
		/// by using the ValidateRect or ValidateRgn function.
		/// </para>
		/// <para>
		/// The system sends a WM_PAINT message to a window whenever its update region is not empty and there are no other messages in the
		/// application queue for that window.
		/// </para>
		/// <para>The specified region must have been created by using one of the region functions.</para>
		/// <para>
		/// If the bErase parameter is <c>TRUE</c> for any part of the update region, the background in the entire region is erased, not just
		/// in the specified part.
		/// </para>
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows/desktop/api/winuser/nf-winuser-invalidatergn BOOL InvalidateRgn( HWND hWnd, HRGN hRgn,
		// BOOL bErase );
		[DllImport(Lib.User32, SetLastError = false, ExactSpelling = true)]
		[PInvokeData("winuser.h", MSDNShortId = "b5b44efe-8045-4e54-89f9-1766689a053d")]
		[return: MarshalAs(UnmanagedType.Bool)]
		public static extern bool InvalidateRgn(HWND hWnd, HRGN hRgn, [MarshalAs(UnmanagedType.Bool)] bool bErase);

		/// <summary>
		/// The <c>LockWindowUpdate</c> function disables or enables drawing in the specified window. Only one window can be locked at a time.
		/// </summary>
		/// <param name="hWndLock">
		/// The window in which drawing will be disabled. If this parameter is <c>NULL</c>, drawing in the locked window is enabled.
		/// </param>
		/// <returns>
		/// <para>If the function succeeds, the return value is nonzero.</para>
		/// <para>If the function fails, the return value is zero, indicating that an error occurred or another window was already locked.</para>
		/// </returns>
		/// <remarks>
		/// <para>
		/// The purpose of the <c>LockWindowUpdate</c> function is to permit drag/drop feedback to be drawn over a window without
		/// interference from the window itself. The intent is that the window is locked when feedback is drawn and unlocked when feedback is
		/// complete. <c>LockWindowUpdate</c> is not intended for general-purpose suppression of window redraw. Use the WM_SETREDRAW message
		/// to disable redrawing of a particular window.
		/// </para>
		/// <para>
		/// If an application with a locked window (or any locked child windows) calls the GetDC, GetDCEx, or BeginPaint function, the called
		/// function returns a device context with a visible region that is empty. This will occur until the application unlocks the window
		/// by calling <c>LockWindowUpdate</c>, specifying a value of <c>NULL</c> for hWndLock.
		/// </para>
		/// <para>
		/// If an application attempts to draw within a locked window, the system records the extent of the attempted operation in a bounding
		/// rectangle. When the window is unlocked, the system invalidates the area within this bounding rectangle, forcing an eventual
		/// WM_PAINT message to be sent to the previously locked window and its child windows. If no drawing has occurred while the window
		/// updates were locked, no area is invalidated.
		/// </para>
		/// <para><c>LockWindowUpdate</c> does not make the specified window invisible and does not clear the WS_VISIBLE style bit.</para>
		/// <para>A locked window cannot be moved.</para>
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows/desktop/api/winuser/nf-winuser-lockwindowupdate BOOL LockWindowUpdate( HWND hWndLock );
		[DllImport(Lib.User32, SetLastError = false, ExactSpelling = true)]
		[PInvokeData("winuser.h", MSDNShortId = "00ec40c7-8ab2-40db-a9bb-48e18d66bf1a")]
		[return: MarshalAs(UnmanagedType.Bool)]
		public static extern bool LockWindowUpdate(HWND hWndLock);

		/// <summary>
		/// The <c>PaintDesktop</c> function fills the clipping region in the specified device context with the desktop pattern or wallpaper.
		/// The function is provided primarily for shell desktops.
		/// </summary>
		/// <param name="hdc">Handle to the device context.</param>
		/// <returns>
		/// <para>If the function succeeds, the return value is nonzero.</para>
		/// <para>If the function fails, the return value is zero.</para>
		/// </returns>
		// https://docs.microsoft.com/en-us/windows/desktop/api/winuser/nf-winuser-paintdesktop BOOL PaintDesktop( HDC hdc );
		[DllImport(Lib.User32, SetLastError = false, ExactSpelling = true)]
		[PInvokeData("winuser.h", MSDNShortId = "738500d4-32f5-43cf-8d40-9ad201ca6d4b")]
		[return: MarshalAs(UnmanagedType.Bool)]
		public static extern bool PaintDesktop(HDC hdc);

		/// <summary>The <c>RedrawWindow</c> function updates the specified rectangle or region in a window's client area.</summary>
		/// <param name="hWnd">A handle to the window to be redrawn. If this parameter is <c>NULL</c>, the desktop window is updated.</param>
		/// <param name="lprcUpdate">
		/// A pointer to a RECT structure containing the coordinates, in device units, of the update rectangle. This parameter is ignored if
		/// the hrgnUpdate parameter identifies a region.
		/// </param>
		/// <param name="hrgnUpdate">
		/// A handle to the update region. If both the hrgnUpdate and lprcUpdate parameters are <c>NULL</c>, the entire client area is added
		/// to the update region.
		/// </param>
		/// <param name="flags">
		/// <para>
		/// One or more redraw flags. This parameter can be used to invalidate or validate a window, control repainting, and control which
		/// windows are affected by <c>RedrawWindow</c>.
		/// </para>
		/// <para>The following flags are used to invalidate the window.</para>
		/// <list type="table">
		/// <listheader>
		/// <term>Flag (invalidation)</term>
		/// <term>Description</term>
		/// </listheader>
		/// <item>
		/// <term>RDW_ERASE</term>
		/// <term>
		/// Causes the window to receive a WM_ERASEBKGND message when the window is repainted. The RDW_INVALIDATE flag must also be
		/// specified; otherwise, RDW_ERASE has no effect.
		/// </term>
		/// </item>
		/// <item>
		/// <term>RDW_FRAME</term>
		/// <term>
		/// Causes any part of the nonclient area of the window that intersects the update region to receive a WM_NCPAINT message. The
		/// RDW_INVALIDATE flag must also be specified; otherwise, RDW_FRAME has no effect. The WM_NCPAINT message is typically not sent
		/// during the execution of RedrawWindow unless either RDW_UPDATENOW or RDW_ERASENOW is specified.
		/// </term>
		/// </item>
		/// <item>
		/// <term>RDW_INTERNALPAINT</term>
		/// <term>Causes a WM_PAINT message to be posted to the window regardless of whether any portion of the window is invalid.</term>
		/// </item>
		/// <item>
		/// <term>RDW_INVALIDATE</term>
		/// <term>Invalidates lprcUpdate or hrgnUpdate (only one may be non-NULL). If both are NULL, the entire window is invalidated.</term>
		/// </item>
		/// </list>
		/// <para>The following flags are used to validate the window.</para>
		/// <list type="table">
		/// <listheader>
		/// <term>Flag (validation)</term>
		/// <term>Description</term>
		/// </listheader>
		/// <item>
		/// <term>RDW_NOERASE</term>
		/// <term>Suppresses any pending WM_ERASEBKGND messages.</term>
		/// </item>
		/// <item>
		/// <term>RDW_NOFRAME</term>
		/// <term>
		/// Suppresses any pending WM_NCPAINT messages. This flag must be used with RDW_VALIDATE and is typically used with RDW_NOCHILDREN.
		/// RDW_NOFRAME should be used with care, as it could cause parts of a window to be painted improperly.
		/// </term>
		/// </item>
		/// <item>
		/// <term>RDW_NOINTERNALPAINT</term>
		/// <term>
		/// Suppresses any pending internal WM_PAINT messages. This flag does not affect WM_PAINT messages resulting from a non-NULL update area.
		/// </term>
		/// </item>
		/// <item>
		/// <term>RDW_VALIDATE</term>
		/// <term>
		/// Validates lprcUpdate or hrgnUpdate (only one may be non-NULL). If both are NULL, the entire window is validated. This flag does
		/// not affect internal WM_PAINT messages.
		/// </term>
		/// </item>
		/// </list>
		/// <para>
		/// The following flags control when repainting occurs. <c>RedrawWindow</c> will not repaint unless one of these flags is specified.
		/// </para>
		/// <list type="table">
		/// <listheader>
		/// <term>Flag</term>
		/// <term>Description</term>
		/// </listheader>
		/// <item>
		/// <term>RDW_ERASENOW</term>
		/// <term>
		/// Causes the affected windows (as specified by the RDW_ALLCHILDREN and RDW_NOCHILDREN flags) to receive WM_NCPAINT and
		/// WM_ERASEBKGND messages, if necessary, before the function returns. WM_PAINT messages are received at the ordinary time.
		/// </term>
		/// </item>
		/// <item>
		/// <term>RDW_UPDATENOW</term>
		/// <term>
		/// Causes the affected windows (as specified by the RDW_ALLCHILDREN and RDW_NOCHILDREN flags) to receive WM_NCPAINT, WM_ERASEBKGND,
		/// and WM_PAINT messages, if necessary, before the function returns.
		/// </term>
		/// </item>
		/// </list>
		/// <para>
		/// By default, the windows affected by <c>RedrawWindow</c> depend on whether the specified window has the WS_CLIPCHILDREN style.
		/// Child windows that are not the WS_CLIPCHILDREN style are unaffected; non-WS_CLIPCHILDREN windows are recursively validated or
		/// invalidated until a WS_CLIPCHILDREN window is encountered. The following flags control which windows are affected by the
		/// <c>RedrawWindow</c> function.
		/// </para>
		/// <list type="table">
		/// <listheader>
		/// <term>Flag</term>
		/// <term>Description</term>
		/// </listheader>
		/// <item>
		/// <term>RDW_ALLCHILDREN</term>
		/// <term>Includes child windows, if any, in the repainting operation.</term>
		/// </item>
		/// <item>
		/// <term>RDW_NOCHILDREN</term>
		/// <term>Excludes child windows, if any, from the repainting operation.</term>
		/// </item>
		/// </list>
		/// </param>
		/// <returns>
		/// <para>If the function succeeds, the return value is nonzero.</para>
		/// <para>If the function fails, the return value is zero.</para>
		/// </returns>
		/// <remarks>
		/// When <c>RedrawWindow</c> is used to invalidate part of the desktop window, the desktop window does not receive a WM_PAINT
		/// message. To repaint the desktop, an application uses the RDW_ERASE flag to generate a WM_ERASEBKGND message.
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows/desktop/api/winuser/nf-winuser-redrawwindow BOOL RedrawWindow( HWND hWnd, const RECT
		// *lprcUpdate, HRGN hrgnUpdate, UINT flags );
		[DllImport(Lib.User32, SetLastError = false, ExactSpelling = true)]
		[PInvokeData("winuser.h", MSDNShortId = "c6cb7f74-237e-4d3e-a852-894da36e990c")]
		[return: MarshalAs(UnmanagedType.Bool)]
		public static extern bool RedrawWindow(HWND hWnd, [In] PRECT lprcUpdate, HRGN hrgnUpdate, RedrawWindowFlags flags);

		/// <summary>
		/// The <c>SetWindowRgn</c> function sets the window region of a window. The window region determines the area within the window
		/// where the system permits drawing. The system does not display any portion of a window that lies outside of the window region
		/// </summary>
		/// <param name="hWnd">A handle to the window whose window region is to be set.</param>
		/// <param name="hRgn">
		/// <para>A handle to a region. The function sets the window region of the window to this region.</para>
		/// <para>If hRgn is <c>NULL</c>, the function sets the window region to <c>NULL</c>.</para>
		/// </param>
		/// <param name="bRedraw">
		/// <para>
		/// Specifies whether the system redraws the window after setting the window region. If bRedraw is <c>TRUE</c>, the system does so;
		/// otherwise, it does not.
		/// </para>
		/// <para>Typically, you set bRedraw to <c>TRUE</c> if the window is visible.</para>
		/// </param>
		/// <returns>
		/// <para>If the function succeeds, the return value is nonzero.</para>
		/// <para>If the function fails, the return value is zero.</para>
		/// </returns>
		/// <remarks>
		/// <para>
		/// When this function is called, the system sends the WM_WINDOWPOSCHANGING and <c>WM_WINDOWPOSCHANGING</c> messages to the window.
		/// </para>
		/// <para>
		/// The coordinates of a window's window region are relative to the upper-left corner of the window, not the client area of the window.
		/// </para>
		/// <para>
		/// <c>Note</c> If the window layout is right-to-left (RTL), the coordinates are relative to the upper-right corner of the window.
		/// See Window Layout and Mirroring.
		/// </para>
		/// <para>
		/// After a successful call to <c>SetWindowRgn</c>, the system owns the region specified by the region handle hRgn. The system does
		/// not make a copy of the region. Thus, you should not make any further function calls with this region handle. In particular, do
		/// not delete this region handle. The system deletes the region handle when it no longer needed.
		/// </para>
		/// <para>To obtain the window region of a window, call the GetWindowRgn function.</para>
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows/desktop/api/winuser/nf-winuser-setwindowrgn int SetWindowRgn( HWND hWnd, HRGN hRgn, BOOL
		// bRedraw );
		[DllImport(Lib.User32, SetLastError = false, ExactSpelling = true)]
		[PInvokeData("winuser.h", MSDNShortId = "06209d0c-14f9-45ec-ae2c-9cc596b5bbaa")]
		public static extern int SetWindowRgn(HWND hWnd, HRGN hRgn, [MarshalAs(UnmanagedType.Bool)] bool bRedraw);

		/// <summary>
		/// The <c>UpdateWindow</c> function updates the client area of the specified window by sending a WM_PAINT message to the window if
		/// the window's update region is not empty. The function sends a <c>WM_PAINT</c> message directly to the window procedure of the
		/// specified window, bypassing the application queue. If the update region is empty, no message is sent.
		/// </summary>
		/// <param name="hWnd">Handle to the window to be updated.</param>
		/// <returns>
		/// <para>If the function succeeds, the return value is nonzero.</para>
		/// <para>If the function fails, the return value is zero.</para>
		/// </returns>
		// https://docs.microsoft.com/en-us/windows/desktop/api/winuser/nf-winuser-updatewindow BOOL UpdateWindow( HWND hWnd );
		[DllImport(Lib.User32, SetLastError = false, ExactSpelling = true)]
		[PInvokeData("winuser.h", MSDNShortId = "51a50f1f-7b4d-4acd-83a0-1877f5181766")]
		[return: MarshalAs(UnmanagedType.Bool)]
		public static extern bool UpdateWindow(HWND hWnd);

		/// <summary>
		/// The <c>ValidateRect</c> function validates the client area within a rectangle by removing the rectangle from the update region of
		/// the specified window.
		/// </summary>
		/// <param name="hWnd">
		/// Handle to the window whose update region is to be modified. If this parameter is <c>NULL</c>, the system invalidates and redraws
		/// all windows and sends the <c>WM_ERASEBKGND</c> and <c>WM_NCPAINT</c> messages to the window procedure before the function returns.
		/// </param>
		/// <param name="lpRect">
		/// Pointer to a RECT structure that contains the client coordinates of the rectangle to be removed from the update region. If this
		/// parameter is <c>NULL</c>, the entire client area is removed.
		/// </param>
		/// <returns>
		/// <para>If the function succeeds, the return value is nonzero.</para>
		/// <para>If the function fails, the return value is zero.</para>
		/// </returns>
		/// <remarks>
		/// <para>
		/// The BeginPaint function automatically validates the entire client area. Neither the <c>ValidateRect</c> nor ValidateRgn function
		/// should be called if a portion of the update region must be validated before the next WM_PAINT message is generated.
		/// </para>
		/// <para>The system continues to generate WM_PAINT messages until the current update region is validated.</para>
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows/desktop/api/winuser/nf-winuser-validaterect BOOL ValidateRect( HWND hWnd, const RECT
		// *lpRect );
		[DllImport(Lib.User32, SetLastError = false, ExactSpelling = true)]
		[PInvokeData("winuser.h", MSDNShortId = "961dd768-1849-44df-bc7f-480881ed6477")]
		[return: MarshalAs(UnmanagedType.Bool)]
		public static extern bool ValidateRect(HWND hWnd, [In] PRECT lpRect);

		/// <summary>
		/// The <c>ValidateRgn</c> function validates the client area within a region by removing the region from the current update region
		/// of the specified window.
		/// </summary>
		/// <param name="hWnd">Handle to the window whose update region is to be modified.</param>
		/// <param name="hRgn">
		/// Handle to a region that defines the area to be removed from the update region. If this parameter is <c>NULL</c>, the entire
		/// client area is removed.
		/// </param>
		/// <returns>
		/// <para>If the function succeeds, the return value is nonzero.</para>
		/// <para>If the function fails, the return value is zero.</para>
		/// </returns>
		/// <remarks>
		/// <para>The specified region must have been created by a region function. The region coordinates are assumed to be client coordinates.</para>
		/// <para>
		/// The BeginPaint function automatically validates the entire client area. Neither the ValidateRect nor <c>ValidateRgn</c> function
		/// should be called if a portion of the update region must be validated before the next WM_PAINT message is generated.
		/// </para>
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows/desktop/api/winuser/nf-winuser-validatergn BOOL ValidateRgn( HWND hWnd, HRGN hRgn );
		[DllImport(Lib.User32, SetLastError = false, ExactSpelling = true)]
		[PInvokeData("winuser.h", MSDNShortId = "80fb1d4a-d9b1-4e67-b585-eee81893ed34")]
		[return: MarshalAs(UnmanagedType.Bool)]
		public static extern bool ValidateRgn(HWND hWnd, HRGN hRgn);

		/// <summary>
		/// <para>
		/// The <c>PAINTSTRUCT</c> structure contains information for an application. This information can be used to paint the client area
		/// of a window owned by that application.
		/// </para>
		/// </summary>
		// https://docs.microsoft.com/en-us/windows/desktop/api/winuser/ns-winuser-tagpaintstruct typedef struct tagPAINTSTRUCT { HDC hdc;
		// BOOL fErase; RECT rcPaint; BOOL fRestore; BOOL fIncUpdate; BYTE rgbReserved[32]; } PAINTSTRUCT, *PPAINTSTRUCT, *NPPAINTSTRUCT, *LPPAINTSTRUCT;
		[PInvokeData("winuser.h", MSDNShortId = "1f8c6dd2-e511-48f2-8ab0-d2fadb1ce433")]
		[StructLayout(LayoutKind.Sequential)]
		public struct PAINTSTRUCT
		{
			/// <summary>
			/// <para>A handle to the display DC to be used for painting.</para>
			/// </summary>
			public HDC hdc;

			/// <summary>
			/// <para>
			/// Indicates whether the background must be erased. This value is nonzero if the application should erase the background. The
			/// application is responsible for erasing the background if a window class is created without a background brush. For more
			/// information, see the description of the <c>hbrBackground</c> member of the WNDCLASS structure.
			/// </para>
			/// </summary>
			[MarshalAs(UnmanagedType.Bool)]
			public bool fErase;

			/// <summary>
			/// <para>
			/// A RECT structure that specifies the upper left and lower right corners of the rectangle in which the painting is requested,
			/// in device units relative to the upper-left corner of the client area.
			/// </para>
			/// </summary>
			public RECT rcPaint;

			/// <summary>
			/// <para>Reserved; used internally by the system.</para>
			/// </summary>
			[MarshalAs(UnmanagedType.Bool)]
			public bool fRestore;

			/// <summary>
			/// <para>Reserved; used internally by the system.</para>
			/// </summary>
			[MarshalAs(UnmanagedType.Bool)]
			public bool fIncUpdate;

			/// <summary>
			/// <para>Reserved; used internally by the system.</para>
			/// </summary>
			[MarshalAs(UnmanagedType.ByValArray, SizeConst = 32)]
			public byte[] rgbReserved;
		}
	}
}