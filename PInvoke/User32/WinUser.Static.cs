namespace Vanara.PInvoke;

public static partial class User32
{
	/// <summary>Static Control Messages</summary>
	// https://docs.microsoft.com/en-us/windows/win32/controls/bumper-static-control-reference-messages
	[PInvokeData("winuser.h")]
	public enum StaticMessage : uint
	{
		/// <summary>
		/// An application sends the <c>STM_SETICON</c> message to associate an icon with an icon control.
		/// <list type="bullet">
		/// <item>
		/// <term>wParam</term>
		/// <description>Handle to the icon to associate with the icon control.</description>
		/// </item>
		/// <item>
		/// <term>lParam</term>
		/// <description>This parameter is not used.</description>
		/// </item>
		/// <item>
		/// <term>Returns</term>
		/// <description>
		/// The return value is a handle to the icon previously associated with the icon control, or zero if an error occurs.
		/// </description>
		/// </item>
		/// </list>
		/// </summary>
		// https://docs.microsoft.com/en-us/windows/win32/controls/stm-seticon
		[MsgParams(typeof(HICON), null, LResultType = typeof(HICON))]
		STM_SETICON = 0x0170,

		/// <summary>
		/// An application sends the <c>STM_GETICON</c> message to retrieve a handle to the icon associated with a static control that
		/// has the SS_ICON style.
		/// <list type="bullet">
		/// <item>
		/// <term>wParam</term>
		/// <description>Not used; must be zero.</description>
		/// </item>
		/// <item>
		/// <term>lParam</term>
		/// <description>Not used; must be zero.</description>
		/// </item>
		/// <item>
		/// <term>Returns</term>
		/// <description>
		/// The return value is a handle to the icon, or <c>NULL</c> if either the static control has no associated icon or if an error occurred.
		/// </description>
		/// </item>
		/// </list>
		/// </summary>
		// https://docs.microsoft.com/en-us/windows/win32/controls/stm-geticon
		[MsgParams(null, null, LResultType = typeof(HICON))]
		STM_GETICON = 0x0171,

		/// <summary>
		/// An application sends an <c>STM_SETIMAGE</c> message to associate a new image with a static control.
		/// <list type="bullet">
		/// <item>
		/// <term>wParam</term>
		/// <description>
		/// Specifies the type of image to associate with the static control. This parameter can be one of the following values:
		/// <list type="table">
		/// <listheader>
		/// <term>Value</term>
		/// <term>Meaning</term>
		/// </listheader>
		/// <item>
		/// <description>IMAGE_BITMAP</description>
		/// <description>Bitmap.</description>
		/// </item>
		/// <item>
		/// <description>IMAGE_CURSOR</description>
		/// <description>Cursor.</description>
		/// </item>
		/// <item>
		/// <description>IMAGE_ENHMETAFILE</description>
		/// <description>Enhanced metafile.</description>
		/// </item>
		/// <item>
		/// <description>IMAGE_ICON</description>
		/// <description>Icon.</description>
		/// </item>
		/// </list>
		/// </description>
		/// </item>
		/// <item>
		/// <term>lParam</term>
		/// <description>Handle to the image to associate with the static control.</description>
		/// </item>
		/// <item>
		/// <term>Returns</term>
		/// <description>
		/// The return value is a handle to the image previously associated with the static control, if any; otherwise, it is <c>NULL</c>.
		/// </description>
		/// </item>
		/// </list>
		/// </summary>
		/// <remarks>
		/// <para>
		/// To associate an image with a static control, the control must have the proper style. The following table shows the style
		/// needed for each image type.
		/// </para>
		/// <list type="table">
		/// <listheader>
		/// <term>Image type</term>
		/// <term>Static control style</term>
		/// </listheader>
		/// <item>
		/// <description>IMAGE_BITMAP</description>
		/// <description>SS_BITMAP</description>
		/// </item>
		/// <item>
		/// <description>IMAGE_CURSOR</description>
		/// <description>SS_ICON</description>
		/// </item>
		/// <item>
		/// <description>IMAGE_ENHMETAFILE</description>
		/// <description>SS_ENHMETAFILE</description>
		/// </item>
		/// <item>
		/// <description>IMAGE_ICON</description>
		/// <description>SS_ICON</description>
		/// </item>
		/// </list>
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows/win32/controls/stm-setimage
		[MsgParams(typeof(LoadImageType), typeof(HANDLE), LResultType = typeof(HANDLE))]
		STM_SETIMAGE = 0x0172,

		/// <summary>
		/// An application sends an <c>STM_GETIMAGE</c> message to retrieve a handle to the image (icon or bitmap) associated with a
		/// static control.
		/// <list type="bullet">
		/// <item>
		/// <term>wParam</term>
		/// <description>Specifies the type of image to retrieve. This parameter can be one of the following values:
		/// <list type="table">
		/// <listheader>
		/// <term>Value</term>
		/// <term>Meaning</term>
		/// </listheader>
		/// <item>
		/// <description>IMAGE_BITMAP</description>
		/// <description>Bitmap.</description>
		/// </item>
		/// <item>
		/// <description>IMAGE_CURSOR</description>
		/// <description>Cursor.</description>
		/// </item>
		/// <item>
		/// <description>IMAGE_ENHMETAFILE</description>
		/// <description>Enhanced metafile.</description>
		/// </item>
		/// <item>
		/// <description>IMAGE_ICON</description>
		/// <description>Icon.</description>
		/// </item>
		/// </list>
		/// </description>
		/// </item>
		/// <item>
		/// <term>lParam</term>
		/// <description>This parameter is not used.</description>
		/// </item>
		/// <item>
		/// <term>Returns</term>
		/// <description>The return value is a handle to the image, if any; otherwise, it is <c>NULL</c>.</description>
		/// </item>
		/// </list>
		/// </summary>
		// https://docs.microsoft.com/en-us/windows/win32/controls/stm-getimage
		[MsgParams(typeof(HANDLE), null, LResultType = typeof(HANDLE))]
		STM_GETIMAGE = 0x0173,
	}

	/// <summary>Static Control Notifications</summary>
	// https://docs.microsoft.com/en-us/windows/win32/controls/bumper-static-control-reference-notifications
	[PInvokeData("winuser.h")]
	public enum StaticNotification : uint
	{
		/// <summary>
		/// <para>
		/// The STN_CLICKED notification code is sent when the user clicks a static control that has the <c>SS_NOTIFY</c> style. The
		/// parent window of the control receives this notification code through the <c>WM_COMMAND</c> message.
		/// </para>
		/// <code lang="cs">STN_CLICKED WPARAM wParam; LPARAM lParam;</code>
		/// <list type="bullet">
		/// <item>
		/// <term>wParam</term>
		/// <description>
		/// The <c>LOWORD</c> contains the identifier of the static control. The <c>HIWORD</c> specifies the notification code.
		/// </description>
		/// </item>
		/// <item>
		/// <term>lParam</term>
		/// <description>Handle to the static control.</description>
		/// </item>
		/// </list>
		/// </summary>
		// https://docs.microsoft.com/en-us/windows/win32/controls/stn-clicked
		[MsgParams(typeof(uint), typeof(HWND))]
		STN_CLICKED = 0,

		/// <summary>
		/// <para>
		/// The STN_DBLCLK notification code is sent when the user double-clicks a static control that has the <c>SS_NOTIFY</c> style.
		/// The parent window of the control receives this notification code through the <c>WM_COMMAND</c> message.
		/// </para>
		/// <code lang="cs">STN_DBLCLK WPARAM wParam; LPARAM lParam;</code>
		/// <list type="bullet">
		/// <item>
		/// <term>wParam</term>
		/// <description>
		/// The <c>LOWORD</c> contains the identifier of the static control. The <c>HIWORD</c> specifies the notification code.
		/// </description>
		/// </item>
		/// <item>
		/// <term>lParam</term>
		/// <description>Handle to the static control.</description>
		/// </item>
		/// </list>
		/// </summary>
		// https://docs.microsoft.com/en-us/windows/win32/controls/stn-dblclk
		[MsgParams(typeof(uint), typeof(HWND))]
		STN_DBLCLK = 1,

		/// <summary>
		/// <para>
		/// The STN_ENABLE notification code is sent when a static control is enabled. The static control must have the <c>SS_NOTIFY</c>
		/// style to receive this notification code. The parent window of the control receives this notification code through the
		/// <c>WM_COMMAND</c> message.
		/// </para>
		/// <para>
		/// <code lang="cs">STN_ENABLE WPARAM wParam; LPARAM lParam;</code>
		/// </para>
		/// <list type="bullet">
		/// <item>
		/// <term>wParam</term>
		/// <description>
		/// The <c>LOWORD</c> contains the identifier of the static control. The <c>HIWORD</c> specifies the notification code.
		/// </description>
		/// </item>
		/// <item>
		/// <term>lParam</term>
		/// <description>Handle to the static control.</description>
		/// </item>
		/// </list>
		/// </summary>
		// https://docs.microsoft.com/en-us/windows/win32/controls/stn-enable
		[MsgParams(typeof(uint), typeof(HWND))]
		STN_ENABLE = 2,

		/// <summary>
		/// <para>
		/// The STN_DISABLE notification code is sent when a static control is disabled. The static control must have the
		/// <c>SS_NOTIFY</c> style to receive this notification code. The parent window of the control receives this notification code
		/// through the <c>WM_COMMAND</c> message.
		/// </para>
		/// <para>
		/// <code lang="cs">STN_DISABLE WPARAM wParam; LPARAM lParam;</code>
		/// </para>
		/// <list type="bullet">
		/// <item>
		/// <term>wParam</term>
		/// <description>
		/// The <c>LOWORD</c> contains the identifier of the static control. The <c>HIWORD</c> specifies the notification code.
		/// </description>
		/// </item>
		/// <item>
		/// <term>lParam</term>
		/// <description>Handle to the static control.</description>
		/// </item>
		/// </list>
		/// </summary>
		// https://docs.microsoft.com/en-us/windows/win32/controls/stn-disable
		[MsgParams(typeof(uint), typeof(HWND))]
		STN_DISABLE = 3,
	}

	/// <summary>
	/// To create a static control using the <c>CreateWindow</c> or <c>CreateWindowEx</c> function, specify the STATIC class,
	/// appropriate window style constants, and a combination of the following static control styles.
	/// </summary>
	/// <remarks>
	/// To use a style which truncates words or strings with an ellipsis for multiline text, <c>DrawThemeText</c> or <c>DrawText</c> can
	/// be used on a owner-draw control with formatting flags <c>DT_WORDBREAK</c> and <c>DT_ENDELLIPSIS</c> set.
	/// </remarks>
	// https://docs.microsoft.com/en-us/windows/win32/controls/static-control-styles
	[PInvokeData("winuser.h")]
	[Flags]
	public enum StaticStyle : uint
	{
		/// <summary>
		/// A bitmap is to be displayed in the static control. The text is the name of a bitmap (not a filename) defined elsewhere in
		/// the resource file. The style ignores the nWidth and nHeight parameters; the control automatically sizes itself to
		/// accommodate the bitmap.
		/// </summary>
		SS_BITMAP = 0x0000000E,

		/// <summary>A box with a frame drawn in the same color as the window frames. This color is black in the default color scheme.</summary>
		SS_BLACKFRAME = 0x00000007,

		/// <summary>A rectangle filled with the current window frame color. This color is black in the default color scheme.</summary>
		SS_BLACKRECT = 0x00000004,

		/// <summary>
		/// A simple rectangle and centers the text in the rectangle. The text is formatted before it is displayed. Words that extend
		/// past the end of a line are automatically wrapped to the beginning of the next centered line. Words that are longer than the
		/// width of the control are truncated.
		/// </summary>
		SS_CENTER = 0x00000001,

		/// <summary>
		/// A bitmap is centered in the static control that contains it. The control is not resized, so that a bitmap too large for the
		/// control will be clipped. If the static control contains a single line of text, the text is centered vertically in the client
		/// area of the control.
		/// </summary>
		SS_CENTERIMAGE = 0x00000200,

		/// <summary>
		/// The static control duplicates the text-displaying characteristics of a multiline edit control. Specifically, the average
		/// character width is calculated in the same manner as with an edit control, and the function does not display a partially
		/// visible last line.
		/// </summary>
		SS_EDITCONTROL = 0x00002000,

		/// <summary>
		/// If the end of a string does not fit in the rectangle, it is truncated and ellipses are added. If a word that is not at the
		/// end of the string goes beyond the limits of the rectangle, it is truncated without ellipses. Using this style will force the
		/// control s text to be on one line with no word wrap. Compare with SS_PATHELLIPSIS and SS_WORDELLIPSIS.
		/// </summary>
		SS_ENDELLIPSIS = 0x00004000,

		/// <summary>
		/// An enhanced metafile is to be displayed in the static control. The text is the name of a metafile. An enhanced metafile
		/// static control has a fixed size; the metafile is scaled to fit the static control's client area.
		/// </summary>
		SS_ENHMETAFILE = 0x0000000F,

		/// <summary>
		/// Draws the frame of the static control using the EDGE_ETCHED edge style. For more information, see the DrawEdge function.
		/// </summary>
		SS_ETCHEDFRAME = 0x00000012,

		/// <summary>
		/// Draws the top and bottom edges of the static control using the EDGE_ETCHED edge style. For more information, see the
		/// DrawEdge function.
		/// </summary>
		SS_ETCHEDHORZ = 0x00000010,

		/// <summary>
		/// Draws the left and right edges of the static control using the EDGE_ETCHED edge style. For more information, see the
		/// DrawEdge function.
		/// </summary>
		SS_ETCHEDVERT = 0x00000011,

		/// <summary>
		/// A box with a frame drawn with the same color as the screen background (desktop). This color is gray in the default color scheme.
		/// </summary>
		SS_GRAYFRAME = 0x00000005,

		/// <summary>A rectangle filled with the current screen background color. This color is gray in the default color scheme.</summary>
		SS_GRAYRECT = 0x00000008,

		/// <summary>
		/// An icon to be displayed in the dialog box. If the control is created as part of a dialog box, the text is the name of an
		/// icon (not a filename) defined elsewhere in the resource file. If the control is created via CreateWindow or a related
		/// function, the text is the name of an icon (not a filename) defined in the resource file associated with the module specified
		/// by the hInstance parameter to CreateWindow.
		/// <para>The icon can be an animated cursor.</para>
		/// <para>
		/// The style ignores the CreateWindow parameters nWidth and nHeight; the control automatically sizes itself to accommodate the
		/// icon. As it uses the LoadIcon function, the SS_ICON style can load only icons of dimensions SM_CXICON and SM_CYICON. This
		/// restriction can be bypassed by using the SS_REALSIZEIMAGE style in addition to SS_ICON.
		/// </para>
		/// <para>
		/// If an icon cannot be loaded through LoadIcon, an attempt is made to load the specified resource as a cursor using
		/// LoadCursor. If that too fails, an attempt is made to load from the device driver using LoadImage.
		/// </para>
		/// </summary>
		SS_ICON = 0x00000003,

		/// <summary>
		/// A simple rectangle and left-aligns the text in the rectangle. The text is formatted before it is displayed. Words that
		/// extend past the end of a line are automatically wrapped to the beginning of the next left-aligned line. Words that are
		/// longer than the width of the control are truncated.
		/// </summary>
		SS_LEFT = 0x00000000,

		/// <summary>
		/// A simple rectangle and left-aligns the text in the rectangle. Tabs are expanded, but words are not wrapped. Text that
		/// extends past the end of a line is clipped.
		/// </summary>
		SS_LEFTNOWORDWRAP = 0x0000000C,

		/// <summary>Prevents interpretation of any ampersand (&amp;) characters in the control's text as accelerator prefix characters.
		/// These are displayed with the ampersand removed and the next character in the string underlined. This static control style
		/// may be included with any of the defined static controls. You can combine SS_NOPREFIX with other styles. This can be useful
		/// when filenames or other strings that may contain an ampersand (&amp;) must be displayed in a static control in a dialog box.</summary>
		SS_NOPREFIX = 0x00000080,

		/// <summary>
		/// Sends the parent window STN_CLICKED, STN_DBLCLK, STN_DISABLE, and STN_ENABLE notification codes when the user clicks or
		/// double-clicks the control.
		/// </summary>
		SS_NOTIFY = 0x00000100,

		/// <summary>
		/// The owner of the static control is responsible for drawing the control. The owner window receives a WM_DRAWITEM message
		/// whenever the control needs to be drawn.
		/// </summary>
		SS_OWNERDRAW = 0x0000000D,

		/// <summary>
		/// Replaces characters in the middle of the string with ellipses so that the result fits in the specified rectangle. If the
		/// string contains backslash () characters, SS_PATHELLIPSIS preserves as much as possible of the text after the last backslash.
		/// Using this style will force the control s text to be on one line with no word wrap. Compare with SS_ENDELLIPSIS and SS_WORDELLIPSIS.
		/// </summary>
		SS_PATHELLIPSIS = 0x00008000,

		/// <summary>
		/// Adjusts the bitmap to fit the size of the static control. For example, changing the locale can change the system font, and
		/// thus controls might be resized. If a static control had a bitmap, the bitmap would no longer fit the control. This style bit
		/// dictates automatic redimensioning of bitmaps to fit their controls.
		/// <para>
		/// If SS_CENTERIMAGE is specified, the bitmap or icon is centered (and clipped if needed). If SS_CENTERIMAGE is not specified,
		/// the bitmap or icon is stretched or shrunk.
		/// </para>
		/// <para>Note that the redimensioning in the two axes are independent, and the result may have a changed aspect ratio.</para>
		/// <para>Compare with SS_REALSIZEIMAGE.</para>
		/// </summary>
		SS_REALSIZECONTROL = 0x00000040,

		/// <summary>
		/// Specifies that the actual resource width is used and the icon is loaded using LoadImage. SS_REALSIZEIMAGE is always used in
		/// conjunction with SS_ICON.
		/// <para>
		/// SS_REALSIZEIMAGE uses LoadImage, overriding the process normally followed under SS_ICON. It does not load cursors; if
		/// LoadImage fails, no further attempts to load are made. It uses the actual resource width. The static control is resized
		/// accordingly, but the icon remains aligned to the originally specified left and top edges of the control.
		/// </para>
		/// <para>
		/// Note that if SS_CENTERIMAGE is also specified, the icon is centered within the control's space, which was specified using
		/// the CreateWindow parameters nWidth and nHeight.
		/// </para>
		/// <para>Compare with SS_REALSIZECONTROL.</para>
		/// </summary>
		SS_REALSIZEIMAGE = 0x00000800,

		/// <summary>
		/// A simple rectangle and right-aligns the text in the rectangle. The text is formatted before it is displayed. Words that
		/// extend past the end of a line are automatically wrapped to the beginning of the next right-aligned line. Words that are
		/// longer than the width of the control are truncated.
		/// </summary>
		SS_RIGHT = 0x00000002,

		/// <summary>
		/// The lower right corner of a static control with the SS_BITMAP or SS_ICON style is to remain fixed when the control is
		/// resized. Only the top and left sides are adjusted to accommodate a new bitmap or icon.
		/// </summary>
		SS_RIGHTJUST = 0x00000400,

		/// <summary>
		/// A simple rectangle and displays a single line of left-aligned text in the rectangle. The text line cannot be shortened or
		/// altered in any way. Also, if the control is disabled, the control does not gray its text.
		/// </summary>
		SS_SIMPLE = 0x0000000B,

		/// <summary>Draws a half-sunken border around a static control.</summary>
		SS_SUNKEN = 0x00001000,

		/// <summary>
		/// A composite style bit that results from using the OR operator on SS_* style bits. Can be used to mask out valid SS_* bits
		/// from a given bitmask. Note that this is out of date and does not correctly include all valid styles. Thus, you should not
		/// use this style.
		/// </summary>
		SS_TYPEMASK = 0x0000001F,

		/// <summary>
		/// A box with a frame drawn with the same color as the window background. This color is white in the default color scheme.
		/// </summary>
		SS_WHITEFRAME = 0x00000009,

		/// <summary>A rectangle filled with the current window background color. This color is white in the default color scheme.</summary>
		SS_WHITERECT = 0x00000006,

		/// <summary>
		/// Truncates any word that does not fit in the rectangle and adds ellipses. Using this style will force the control s text to
		/// be on one line with no word wrap.
		/// <para>Compare with SS_ENDELLIPSIS and SS_PATHELLIPSIS.</para>
		/// </summary>
		SS_WORDELLIPSIS = 0x0000C000,
	}
}