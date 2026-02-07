using static Vanara.PInvoke.User32;

namespace Vanara.PInvoke;

public static partial class ComCtl32
{
	/// <summary>Specifies the visual effects for flat scroll bars.</summary>
	[PInvokeData("commctrl.h", MSDNShortId = "NF:commctrl.FlatSB_SetScrollProp")]
	public enum FSB
	{
		/// <summary>A normal, nonflat scroll bar is displayed. No special visual effects will be applied.</summary>
		FSB_REGULAR_MODE = 0,

		/// <summary>
		/// A standard flat scroll bar is displayed. When the mouse moves over a direction button or the thumb, that portion of the scroll
		/// bar will be displayed in 3-D.
		/// </summary>
		FSB_ENCARTA_MODE = 1,

		/// <summary>
		/// A standard flat scroll bar is displayed. When the mouse moves over a direction button or the thumb, that portion of the scroll
		/// bar will be displayed in inverted colors.
		/// </summary>
		FSB_FLAT_MODE = 2,
	}

	/// <summary>
	/// Specifies the properties and styles for scroll bars in a window, allowing for customization of appearance and behavior. This
	/// enumeration supports bitwise combination of its member values.
	/// </summary>
	/// <remarks>
	/// The <see cref="WSB_PROP"/> enumeration provides flags that can be used to enable or disable specific features of scroll bars, such as
	/// direction buttons and thumbs, as well as to retrieve style and color information. It is typically used in conjunction with window
	/// management functions to customize the scroll bars' appearance and functionality.
	/// </remarks>
	[Flags]
	public enum WSB_PROP : uint
	{
		/// <summary>the height, in pixels, of the direction buttons in a vertical scroll bar.</summary>
		[CorrespondingType(typeof(int))]
		WSB_PROP_CYVSCROLL = 0x00000001,

		/// <summary>the width, in pixels, of the direction buttons in a horizontal scroll bar.</summary>
		[CorrespondingType(typeof(int))]
		WSB_PROP_CXHSCROLL = 0x00000002,

		/// <summary>the height, in pixels, of the horizontal scroll bar.</summary>
		[CorrespondingType(typeof(int))]
		WSB_PROP_CYHSCROLL = 0x00000004,

		/// <summary>the width, in pixels, of the vertical scroll bar.</summary>
		[CorrespondingType(typeof(int))]
		WSB_PROP_CXVSCROLL = 0x00000008,

		/// <summary>the width, in pixels, of the thumb in a horizontal scroll bar.</summary>
		[CorrespondingType(typeof(int))]
		WSB_PROP_CXHTHUMB = 0x00000010,

		/// <summary>the height, in pixels, of the thumb in a vertical scroll bar.</summary>
		[CorrespondingType(typeof(int))]
		WSB_PROP_CYVTHUMB = 0x00000020,

		/// <summary>a COLORREF value that represents the background color in a vertical scroll bar.</summary>
		[CorrespondingType(typeof(COLORREF))]
		WSB_PROP_VBKGCOLOR = 0x00000040,

		/// <summary>a COLORREF value that represents the background color in a horizontal scroll bar.</summary>
		[CorrespondingType(typeof(COLORREF))]
		WSB_PROP_HBKGCOLOR = 0x00000080,

		/// <summary>changes the visual effects for the vertical scroll bar:</summary>
		[CorrespondingType(typeof(FSB))]
		WSB_PROP_VSTYLE = 0x00000100,

		/// <summary>changes the visual effects for the horizontal scroll bar.</summary>
		[CorrespondingType(typeof(FSB))]
		WSB_PROP_HSTYLE = 0x00000200,

		/// <summary>Gets the window styles for a window that contains a flat scroll bar.</summary>
		[CorrespondingType(typeof(WindowStyles), CorrespondingAction.Get)]
		WSB_PROP_WINSTYLE = 0x00000400,

		/// <summary>an HPALETTE value that represents the new palette that the scroll bar should use when drawing.</summary>
		[CorrespondingType(typeof(HPALETTE))]
		WSB_PROP_PALETTE = 0x00000800
	}

	/// <summary>
	/// Enables or disables one or both flat scroll bar direction buttons. If flat scroll bars are not initialized for the window, this
	/// function calls the standard <c>EnableScrollBar</c> function.
	/// </summary>
	/// <param name="hParent">
	/// <para>Type: <b><c>HWND</c></b></para>
	/// <para>
	/// A handle to the window that contains the flat scroll bar. This window handle must have been passed previously in a call to <c>InitializeFlatSB</c>.
	/// </para>
	/// </param>
	/// <param name="type">
	/// <para>Type: <b>int</b></para>
	/// <para>A parameter that specifies the scroll bar type. It can be one of the following values:</para>
	/// <list type="table">
	/// <listheader>
	/// <description>Value</description>
	/// <description>Meaning</description>
	/// </listheader>
	/// <item>
	/// <description><c></c><c></c><b>SB_BOTH</b></description>
	/// <description>Enables or disables the direction buttons on the horizontal and vertical scroll bars.</description>
	/// </item>
	/// <item>
	/// <description><c></c><c></c><b>SB_HORZ</b></description>
	/// <description>Enables or disables the direction buttons on the horizontal scroll bar.</description>
	/// </item>
	/// <item>
	/// <description><c></c><c></c><b>SB_VERT</b></description>
	/// <description>Enables or disables the direction buttons on the vertical scroll bar.</description>
	/// </item>
	/// </list>
	/// </param>
	/// <param name="flags">
	/// <para>Type: <b><c>UINT</c></b></para>
	/// <para>
	/// A parameter that specifies whether the scroll bar arrows are enabled or disabled and indicates which arrows are enabled or disabled.
	/// It can be one of the following values:
	/// </para>
	/// <list type="table">
	/// <listheader>
	/// <description>Value</description>
	/// <description>Meaning</description>
	/// </listheader>
	/// <item>
	/// <description><c></c><c></c><b>ESB_DISABLE_BOTH</b></description>
	/// <description>Disables both direction buttons on the specified scroll bar.</description>
	/// </item>
	/// <item>
	/// <description><c></c><c></c><b>ESB_DISABLE_DOWN</b></description>
	/// <description>Disables the down direction button on the vertical scroll bar.</description>
	/// </item>
	/// <item>
	/// <description><c></c><c></c><b>ESB_DISABLE_LEFT</b></description>
	/// <description>Disables the left direction button on the horizontal scroll bar.</description>
	/// </item>
	/// <item>
	/// <description><c></c><c></c><b>ESB_DISABLE_LTUP</b></description>
	/// <description>
	/// Disables the left direction button on the horizontal scroll bar or the up direction button on the vertical scroll bar.
	/// </description>
	/// </item>
	/// <item>
	/// <description><c></c><c></c><b>ESB_DISABLE_RIGHT</b></description>
	/// <description>Disables the right direction button on the horizontal scroll bar.</description>
	/// </item>
	/// <item>
	/// <description><c></c><c></c><b>ESB_DISABLE_RTDN</b></description>
	/// <description>
	/// Disables the right direction button on the horizontal scroll bar or the down direction button on the vertical scroll bar.
	/// </description>
	/// </item>
	/// <item>
	/// <description><c></c><c></c><b>ESB_DISABLE_UP</b></description>
	/// <description>Disables the up direction button on the vertical scroll bar.</description>
	/// </item>
	/// <item>
	/// <description><c></c><c></c><b>ESB_ENABLE_BOTH</b></description>
	/// <description>Enables both direction buttons on the specified scroll bar.</description>
	/// </item>
	/// </list>
	/// </param>
	/// <returns>
	/// <para>Type: <b><c>BOOL</c></b></para>
	/// <para>Returns nonzero if the scroll bar changes, or zero otherwise.</para>
	/// </returns>
	/// <remarks>
	/// <para>
	/// <b>Note</b>  Flat scroll bar functions are implemented in Comctl32.dll versions 4.71 through 5.82. Comctl32.dll versions 6.00 and
	/// higher do not support flat scroll bars.
	/// </para>
	/// <para></para>
	/// </remarks>
	// https://learn.microsoft.com/en-us/windows/win32/api/commctrl/nf-commctrl-flatsb_enablescrollbar BOOL FlatSB_EnableScrollBar( HWND
	// hParent, int type, UINT flags );
	[PInvokeData("commctrl.h", MSDNShortId = "NF:commctrl.FlatSB_EnableScrollBar")]
	[DllImport(Lib.ComCtl32, SetLastError = false, ExactSpelling = true)]
	[return: MarshalAs(UnmanagedType.Bool)]
	public static extern bool FlatSB_EnableScrollBar(HWND hParent, SB type, ESB_FLAGS flags);

	/// <summary>
	/// Gets the information for a flat scroll bar. If flat scroll bars are not initialized for the window, this function calls the standard
	/// <c>GetScrollInfo</c> function.
	/// </summary>
	/// <param name="hParent">
	/// <para>Type: <b><c>HWND</c></b></para>
	/// <para>
	/// A handle to the window that contains the flat scroll bar. This window handle must have been passed previously in a call to <c>InitializeFlatSB</c>.
	/// </para>
	/// </param>
	/// <param name="code">
	/// <para>Type: <b>int</b></para>
	/// <para>A parameter that specifies the scroll bar type. It can be one of the following values:</para>
	/// <list type="table">
	/// <listheader>
	/// <description>Value</description>
	/// <description>Meaning</description>
	/// </listheader>
	/// <item>
	/// <description><c></c><c></c><b>SB_HORZ</b></description>
	/// <description>Retrieves the information for the horizontal scroll bar.</description>
	/// </item>
	/// <item>
	/// <description><c></c><c></c><b>SB_VERT</b></description>
	/// <description>Retrieves the information for the vertical scroll bar.</description>
	/// </item>
	/// </list>
	/// </param>
	/// <param name="psi">
	/// <para>Type: <b>LPSCROLLINFO</b></para>
	/// <para>
	/// A pointer to a <c>SCROLLINFO</c> structure that will receive the information for the specified scroll bar. The <b>cbSize</b> and
	/// <b>fMask</b> members of the structure must be filled out prior to calling <b>FlatSB_GetScrollInfo</b>. The <b>fMask</b> member
	/// specifies which properties should be retrieved and can be any combination of the following values:
	/// </para>
	/// <list type="table">
	/// <listheader>
	/// <description>Value</description>
	/// <description>Meaning</description>
	/// </listheader>
	/// <item>
	/// <description><c></c><c></c><b>SIF_PAGE</b></description>
	/// <description>
	/// Retrieves the page information for the flat scroll bar. This will be placed in the <b>nPage</b> member of the <c>SCROLLINFO</c> structure.
	/// </description>
	/// </item>
	/// <item>
	/// <description><c></c><c></c><b>SIF_POS</b></description>
	/// <description>
	/// Retrieves the position information for the flat scroll bar. This will be placed in the <b>nPos</b> member of the <c>SCROLLINFO</c> structure.
	/// </description>
	/// </item>
	/// <item>
	/// <description><c></c><c></c><b>SIF_RANGE</b></description>
	/// <description>
	/// Retrieves the range information for the flat scroll bar. This will be placed in the <b>nMin</b> and <b>nMax</b> members of the
	/// <c>SCROLLINFO</c> structure.
	/// </description>
	/// </item>
	/// <item>
	/// <description><c></c><c></c><b>SIF_ALL</b></description>
	/// <description>A combination of SIF_PAGE, SIF_POS, and SIF_RANGE.</description>
	/// </item>
	/// </list>
	/// </param>
	/// <returns>
	/// <para>Type: <b><c>BOOL</c></b></para>
	/// <para>Returns nonzero if successful, or zero otherwise.</para>
	/// </returns>
	/// <remarks>
	/// <para>
	/// <b>Note</b>  Flat scroll bar functions are implemented in Comctl32.dll versions 4.71 through 5.82. Comctl32.dll versions 6.00 and
	/// higher do not support flat scroll bars.
	/// </para>
	/// <para></para>
	/// </remarks>
	// https://learn.microsoft.com/en-us/windows/win32/api/commctrl/nf-commctrl-flatsb_getscrollinfo BOOL FlatSB_GetScrollInfo( HWND hParent,
	// int code, LPSCROLLINFO flags );
	[PInvokeData("commctrl.h", MSDNShortId = "NF:commctrl.FlatSB_GetScrollInfo")]
	[DllImport(Lib.ComCtl32, SetLastError = false, ExactSpelling = true)]
	[return: MarshalAs(UnmanagedType.Bool)]
	public static extern bool FlatSB_GetScrollInfo(HWND hParent, SB code, out SCROLLINFO psi);

	/// <summary>
	/// Gets the thumb position in a flat scroll bar. If flat scroll bars are not initialized for the window, this function calls the
	/// standard <c>GetScrollPos</c> function.
	/// </summary>
	/// <param name="hParent">
	/// <para>Type: <b><c>HWND</c></b></para>
	/// <para>
	/// A handle to the window that contains the flat scroll bar. This window handle must have been passed previously in a call to <c>InitializeFlatSB</c>.
	/// </para>
	/// </param>
	/// <param name="code">
	/// <para>Type: <b>int</b></para>
	/// <para>The parameter that specifies the scroll bar type. It can be one of the following values:</para>
	/// <list type="table">
	/// <listheader>
	/// <description>Value</description>
	/// <description>Meaning</description>
	/// </listheader>
	/// <item>
	/// <description><c></c><c></c><b>SB_HORZ</b></description>
	/// <description>Retrieves the thumb position of the horizontal scroll bar.</description>
	/// </item>
	/// <item>
	/// <description><c></c><c></c><b>SB_VERT</b></description>
	/// <description>Retrieves the thumb position of the vertical scroll bar.</description>
	/// </item>
	/// </list>
	/// </param>
	/// <returns>
	/// <para>Type: <b>int</b></para>
	/// <para>Returns the current thumb position of the specified flat scroll bar.</para>
	/// </returns>
	/// <remarks>
	/// <para>
	/// <b>Note</b>  Flat scroll bar functions are implemented in Comctl32.dll versions 4.71 through 5.82. Comctl32.dll versions 6.00 and
	/// higher do not support flat scroll bars.
	/// </para>
	/// <para></para>
	/// </remarks>
	// https://learn.microsoft.com/en-us/windows/win32/api/commctrl/nf-commctrl-flatsb_getscrollpos int FlatSB_GetScrollPos( HWND hParent,
	// int code );
	[PInvokeData("commctrl.h", MSDNShortId = "NF:commctrl.FlatSB_GetScrollPos")]
	[DllImport(Lib.ComCtl32, SetLastError = false, ExactSpelling = true)]
	public static extern int FlatSB_GetScrollPos(HWND hParent, SB code);

	/// <summary>
	/// Gets the properties for a flat scroll bar. This function can also be used to determine if <c>InitializeFlatSB</c> has been called for
	/// this window.
	/// </summary>
	/// <param name="hParent">
	/// <para>Type: <b><c>HWND</c></b></para>
	/// <para>
	/// A handle to the window that contains the flat scroll bar. This window handle must have been passed previously in a call to <c>InitializeFlatSB</c>.
	/// </para>
	/// </param>
	/// <param name="propIndex">
	/// <para>Type: <b><c>UINT</c></b></para>
	/// <para>
	/// The parameter that determines what <i>pValue</i> represents and which property is being retrieved. It can be one of the following values.
	/// </para>
	/// <list type="table">
	/// <listheader>
	/// <description>Value</description>
	/// <description>Meaning</description>
	/// </listheader>
	/// <item>
	/// <description><c></c><c></c><b>WSB_PROP_CXHSCROLL</b></description>
	/// <description>
	/// <i>pValue</i> is a pointer to an INT value that receives the width, in pixels, of the direction buttons in a horizontal scroll bar.
	/// </description>
	/// </item>
	/// <item>
	/// <description><c></c><c></c><b>WSB_PROP_CXHTHUMB</b></description>
	/// <description>
	/// <i>pValue</i> is a pointer to an INT value that receives the width, in pixels, of the thumb in a horizontal scroll bar.
	/// </description>
	/// </item>
	/// <item>
	/// <description><c></c><c></c><b>WSB_PROP_CXVSCROLL</b></description>
	/// <description><i>pValue</i> a pointer to an INT value that receives the width, in pixels, of a vertical scroll bar.</description>
	/// </item>
	/// <item>
	/// <description><c></c><c></c><b>WSB_PROP_CYHSCROLL</b></description>
	/// <description><i>pValue</i> is a pointer to an INT value that receives the height, in pixels, of a horizontal scroll bar.</description>
	/// </item>
	/// <item>
	/// <description><c></c><c></c><b>WSB_PROP_CYVSCROLL</b></description>
	/// <description>
	/// <i>pValue</i> is a pointer to an INT value that receives the height, in pixels, of the direction buttons in a vertical scroll bar.
	/// </description>
	/// </item>
	/// <item>
	/// <description><c></c><c></c><b>WSB_PROP_CYVTHUMB</b></description>
	/// <description>
	/// <i>pValue</i> is a pointer to an INT value that receives the height, in pixels, of the thumb in a vertical scroll bar.
	/// </description>
	/// </item>
	/// <item>
	/// <description><c></c><c></c><b>WSB_PROP_HBKGCOLOR</b></description>
	/// <description>
	/// <i>pValue</i> is a pointer to a <b>COLORREF</b> value that receives the background color in a horizontal scroll bar.
	/// </description>
	/// </item>
	/// <item>
	/// <description><c></c><c></c><b>WSB_PROP_HSTYLE</b></description>
	/// <description>
	/// <i>pValue</i> is a pointer to an INT value that receives one of the following visual effects for the horizontal scroll bar.
	/// FSB_ENCARTA_MODE A standard flat scroll bar is displayed. When the mouse moves over a direction button or the thumb, that portion of
	/// the scroll bar is displayed in 3-D. FSB_FLAT_MODE A standard flat scroll bar is displayed. When the mouse moves over a direction
	/// button or the thumb, that portion of the scroll bar is displayed in inverted colors. FSB_REGULAR_MODE A normal, nonflat scroll bar is
	/// displayed. No special visual effects are applied.
	/// </description>
	/// </item>
	/// <item>
	/// <description><c></c><c></c><b>WSB_PROP_PALETTE</b></description>
	/// <description>
	/// <i>pValue</i> is a pointer to an <b>HPALETTE</b> value that receives the palette that a scroll bar uses when drawing.
	/// </description>
	/// </item>
	/// <item>
	/// <description><c></c><c></c><b>WSB_PROP_VBKGCOLOR</b></description>
	/// <description>
	/// <i>pValue</i> is a pointer to a <b>COLORREF</b> value that receives the background color in a vertical scroll bar.
	/// </description>
	/// </item>
	/// <item>
	/// <description><c></c><c></c><b>WSB_PROP_VSTYLE</b></description>
	/// <description>
	/// <i>pValue</i> is a pointer to an INT value that receives one of the following visual effects for the vertical scroll bar.
	/// FSB_ENCARTA_MODE A standard flat scroll bar is displayed. When the mouse moves over a direction button or the thumb, that portion of
	/// the scroll bar is displayed in 3-D. FSB_FLAT_MODE A standard flat scroll bar is displayed. When the mouse moves over a direction
	/// button or the thumb, that portion of the scroll bar is displayed in inverted colors. FSB_REGULAR_MODE A normal, nonflat scroll bar is
	/// displayed. No special visual effects are applied.
	/// </description>
	/// </item>
	/// <item>
	/// <description><c></c><c></c><b>WSB_PROP_WINSTYLE</b></description>
	/// <description>
	/// <i>pValue</i> is a pointer to an INT value that receives the <c>WS_HSCROLL</c> and <c>WS_VSCROLL</c> style bits contained by the
	/// current window.
	/// </description>
	/// </item>
	/// </list>
	/// </param>
	/// <param name="pData">
	/// <para>Type: <b><c>LPINT</c></b></para>
	/// <para>A pointer to an <b>int</b> that receives the requested data. This parameter depends on the flag passed in <i>index</i>.</para>
	/// </param>
	/// <returns>
	/// <para>Type: <b><c>BOOL</c></b></para>
	/// <para>
	/// Returns nonzero if successful, or zero otherwise. If <i>index</i> is WSB_PROP_HSTYLE, the return is nonzero if
	/// <c>InitializeFlatSB</c> has been called for this window, or zero otherwise.
	/// </para>
	/// </returns>
	/// <remarks>
	/// <para>
	/// <b>Note</b>  Flat scroll bar functions are implemented in Comctl32.dll versions 4.71 through 5.82. Comctl32.dll versions 6.00 and
	/// higher do not support flat scroll bars.
	/// </para>
	/// <para></para>
	/// </remarks>
	// https://learn.microsoft.com/en-us/windows/win32/api/commctrl/nf-commctrl-flatsb_getscrollprop BOOL FlatSB_GetScrollProp( HWND hParent,
	// int propIndex, LPINT flags );
	[PInvokeData("commctrl.h", MSDNShortId = "NF:commctrl.FlatSB_GetScrollProp")]
	[DllImport(Lib.ComCtl32, SetLastError = false, ExactSpelling = true)]
	[return: MarshalAs(UnmanagedType.Bool)]
	public static extern bool FlatSB_GetScrollProp(HWND hParent, WSB_PROP propIndex, out int pData);

	/// <summary>
	/// <para>
	/// Gets the properties for a flat scroll bar. This function can also be used to determine if <c>InitializeFlatSB</c> has been called for
	/// this window.
	/// </para>
	/// <para><b>Note</b>  This is identical to <c>FlatSB_GetScrollProp</c>.</para>
	/// <para></para>
	/// </summary>
	/// <param name="hParent">
	/// <para>Type: <b><c>HWND</c></b></para>
	/// <para>
	/// A handle to the window that contains the flat scroll bar. This window handle must have been passed previously in a call to <c>InitializeFlatSB</c>.
	/// </para>
	/// </param>
	/// <param name="propIndex">
	/// <para>Type: <b><c>UINT</c></b></para>
	/// <para>
	/// The parameter that determines what <i>pValue</i> represents and which property is being retrieved. It can be one of the following values.
	/// </para>
	/// <list type="table">
	/// <listheader>
	/// <description>Value</description>
	/// <description>Meaning</description>
	/// </listheader>
	/// <item>
	/// <description><c></c><c></c><b>WSB_PROP_CXHSCROLL</b></description>
	/// <description>
	/// <i>pValue</i> is a pointer to an INT value that receives the width, in pixels, of the direction buttons in a horizontal scroll bar.
	/// </description>
	/// </item>
	/// <item>
	/// <description><c></c><c></c><b>WSB_PROP_CXHTHUMB</b></description>
	/// <description>
	/// <i>pValue</i> is a pointer to an INT value that receives the width, in pixels, of the thumb in a horizontal scroll bar.
	/// </description>
	/// </item>
	/// <item>
	/// <description><c></c><c></c><b>WSB_PROP_CXVSCROLL</b></description>
	/// <description><i>pValue</i> a pointer to an INT value that receives the width, in pixels, of a vertical scroll bar.</description>
	/// </item>
	/// <item>
	/// <description><c></c><c></c><b>WSB_PROP_CYHSCROLL</b></description>
	/// <description><i>pValue</i> is a pointer to an INT value that receives the height, in pixels, of a horizontal scroll bar.</description>
	/// </item>
	/// <item>
	/// <description><c></c><c></c><b>WSB_PROP_CYVSCROLL</b></description>
	/// <description>
	/// <i>pValue</i> is a pointer to an INT value that receives the height, in pixels, of the direction buttons in a vertical scroll bar.
	/// </description>
	/// </item>
	/// <item>
	/// <description><c></c><c></c><b>WSB_PROP_CYVTHUMB</b></description>
	/// <description>
	/// <i>pValue</i> is a pointer to an INT value that receives the height, in pixels, of the thumb in a vertical scroll bar.
	/// </description>
	/// </item>
	/// <item>
	/// <description><c></c><c></c><b>WSB_PROP_HBKGCOLOR</b></description>
	/// <description>
	/// <i>pValue</i> is a pointer to a <b>COLORREF</b> value that receives the background color in a horizontal scroll bar.
	/// </description>
	/// </item>
	/// <item>
	/// <description><c></c><c></c><b>WSB_PROP_HSTYLE</b></description>
	/// <description>
	/// <i>pValue</i> is a pointer to an INT value that receives one of the following visual effects for the horizontal scroll bar.
	/// FSB_ENCARTA_MODE A standard flat scroll bar is displayed. When the mouse moves over a direction button or the thumb, that portion of
	/// the scroll bar is displayed in 3-D. FSB_FLAT_MODE A standard flat scroll bar is displayed. When the mouse moves over a direction
	/// button or the thumb, that portion of the scroll bar is displayed in inverted colors. FSB_REGULAR_MODE A normal, nonflat scroll bar is
	/// displayed. No special visual effects are applied.
	/// </description>
	/// </item>
	/// <item>
	/// <description><c></c><c></c><b>WSB_PROP_PALETTE</b></description>
	/// <description>
	/// <i>pValue</i> is a pointer to an <b>HPALETTE</b> value that receives the palette that a scroll bar uses when drawing.
	/// </description>
	/// </item>
	/// <item>
	/// <description><c></c><c></c><b>WSB_PROP_VBKGCOLOR</b></description>
	/// <description>
	/// <i>pValue</i> is a pointer to a <b>COLORREF</b> value that receives the background color in a vertical scroll bar.
	/// </description>
	/// </item>
	/// <item>
	/// <description><c></c><c></c><b>WSB_PROP_VSTYLE</b></description>
	/// <description>
	/// <i>pValue</i> is a pointer to an INT value that receives one of the following visual effects for the vertical scroll bar.
	/// FSB_ENCARTA_MODE A standard flat scroll bar is displayed. When the mouse moves over a direction button or the thumb, that portion of
	/// the scroll bar is displayed in 3-D. FSB_FLAT_MODE A standard flat scroll bar is displayed. When the mouse moves over a direction
	/// button or the thumb, that portion of the scroll bar is displayed in inverted colors. FSB_REGULAR_MODE A normal, nonflat scroll bar is
	/// displayed. No special visual effects are applied.
	/// </description>
	/// </item>
	/// <item>
	/// <description><c></c><c></c><b>WSB_PROP_WINSTYLE</b></description>
	/// <description>
	/// <i>pValue</i> is a pointer to an INT value that receives the <c>WS_HSCROLL</c> and <c>WS_VSCROLL</c> style bits contained by the
	/// current window.
	/// </description>
	/// </item>
	/// </list>
	/// </param>
	/// <param name="ppData">
	/// <para>Type: <b><c>LPINT</c></b></para>
	/// <para>A pointer to an <b>int</b> that receives the requested data. This parameter depends on the flag passed in <i>index</i>.</para>
	/// </param>
	/// <returns>
	/// <para>Type: <b><c>BOOL</c></b></para>
	/// <para>
	/// Returns nonzero if successful, or zero otherwise. If <i>index</i> is WSB_PROP_HSTYLE, the return is nonzero if
	/// <c>InitializeFlatSB</c> has been called for this window, or zero otherwise.
	/// </para>
	/// </returns>
	/// <remarks>
	/// <para>
	/// <b>Note</b>  Flat scroll bar functions are implemented in Comctl32.dll versions 4.71 through 5.82. Comctl32.dll versions 6.00 and
	/// higher do not support flat scroll bars.
	/// </para>
	/// <para></para>
	/// </remarks>
	// https://learn.microsoft.com/en-us/windows/win32/api/commctrl/nf-commctrl-flatsb_getscrollpropptr BOOL FlatSB_GetScrollPropPtr( HWND
	// hParent, int propIndex, PINT_PTR flags );
	[PInvokeData("commctrl.h", MSDNShortId = "NF:commctrl.FlatSB_GetScrollPropPtr")]
	[DllImport(Lib.ComCtl32, SetLastError = false, ExactSpelling = true)]
	[return: MarshalAs(UnmanagedType.Bool)]
	public static extern bool FlatSB_GetScrollPropPtr(HWND hParent, WSB_PROP propIndex, out IntPtr ppData);

	/// <summary>
	/// Gets the scroll range for a flat scroll bar. If flat scroll bars are not initialized for the window, this function calls the standard
	/// <c>GetScrollRange</c> function.
	/// </summary>
	/// <param name="hParent">
	/// <para>Type: <b><c>HWND</c></b></para>
	/// <para>
	/// A handle to the window that contains the flat scroll bar. This window handle must have been passed previously in a call to <c>InitializeFlatSB</c>.
	/// </para>
	/// </param>
	/// <param name="code">
	/// <para>Type: <b>int</b></para>
	/// <para>The scroll bar type. It can be one of the following values:</para>
	/// <list type="table">
	/// <listheader>
	/// <description>Value</description>
	/// <description>Meaning</description>
	/// </listheader>
	/// <item>
	/// <description><c></c><c></c><b>SB_HORZ</b></description>
	/// <description>Retrieves the scroll range of the horizontal scroll bar.</description>
	/// </item>
	/// <item>
	/// <description><c></c><c></c><b>SB_VERT</b></description>
	/// <description>Retrieves the scroll range of the vertical scroll bar.</description>
	/// </item>
	/// </list>
	/// </param>
	/// <param name="pMin">
	/// <para>Type: <b><c>LPINT</c></b></para>
	/// <para>A pointer to an INT value that receives the minimum scroll range value.</para>
	/// </param>
	/// <param name="pMax">
	/// <para>Type: <b><c>LPINT</c></b></para>
	/// <para>A pointer to an INT value that receives the maximum scroll range value.</para>
	/// </param>
	/// <returns>
	/// <para>Type: <b><c>BOOL</c></b></para>
	/// <para>Returns nonzero if successful, or zero otherwise.</para>
	/// </returns>
	/// <remarks>
	/// <para>
	/// <b>Note</b>  Flat scroll bar functions are implemented in Comctl32.dll versions 4.71 through 5.82. Comctl32.dll versions 6.00 and
	/// higher do not support flat scroll bars.
	/// </para>
	/// <para></para>
	/// </remarks>
	// https://learn.microsoft.com/en-us/windows/win32/api/commctrl/nf-commctrl-flatsb_getscrollrange BOOL FlatSB_GetScrollRange( HWND
	// hParent, int code, LPINT flags, LPINT pMax );
	[PInvokeData("commctrl.h", MSDNShortId = "NF:commctrl.FlatSB_GetScrollRange")]
	[DllImport(Lib.ComCtl32, SetLastError = false, ExactSpelling = true)]
	[return: MarshalAs(UnmanagedType.Bool)]
	public static extern bool FlatSB_GetScrollRange(HWND hParent, SB code, out int pMin, out int pMax);

	/// <summary>
	/// Sets the information for a flat scroll bar. If flat scroll bars are not initialized for the window, this function calls the standard
	/// <c>SetScrollInfo</c> function.
	/// </summary>
	/// <param name="hParent">
	/// <para>Type: <b><c>HWND</c></b></para>
	/// <para>
	/// A handle to the window that contains the flat scroll bar. This window handle must have been passed previously in a call to <c>InitializeFlatSB</c>.
	/// </para>
	/// </param>
	/// <param name="code">
	/// <para>Type: <b>int</b></para>
	/// <para>The scroll bar type. It can be one of the following values:</para>
	/// <list type="table">
	/// <listheader>
	/// <description>Value</description>
	/// <description>Meaning</description>
	/// </listheader>
	/// <item>
	/// <description><c></c><c></c><b>SB_HORZ</b></description>
	/// <description>Sets the information for the horizontal scroll bar.</description>
	/// </item>
	/// <item>
	/// <description><c></c><c></c><b>SB_VERT</b></description>
	/// <description>Sets the information for the vertical scroll bar.</description>
	/// </item>
	/// </list>
	/// </param>
	/// <param name="psi">
	/// <para>Type: <b>LPSCROLLINFO</b></para>
	/// <para>
	/// A pointer to a <c>SCROLLINFO</c> structure that contains the new information for the specified scroll bar. The <b>cbSize</b> and
	/// <b>fMask</b> members of the structure must be filled in prior to calling <b>FlatSB_SetScrollInfo</b>. The <b>fMask</b> member
	/// specifies which members of the structure contain valid information and can be any combination of the following values:
	/// </para>
	/// <list type="table">
	/// <listheader>
	/// <description>Value</description>
	/// <description>Meaning</description>
	/// </listheader>
	/// <item>
	/// <description><c></c><c></c><b>SIF_DISABLENOSCROLL</b></description>
	/// <description>Disables the scroll bar if the new information would cause the scroll bar to be removed.</description>
	/// </item>
	/// <item>
	/// <description><c></c><c></c><b>SIF_PAGE</b></description>
	/// <description>
	/// Sets the page information for the flat scroll bar. The <b>nPage</b> member of the <c>SCROLLINFO</c> structure must contain the new
	/// page value.
	/// </description>
	/// </item>
	/// <item>
	/// <description><c></c><c></c><b>SIF_POS</b></description>
	/// <description>
	/// Sets the position information for the flat scroll bar. The <b>nPos</b> member of the <c>SCROLLINFO</c> structure must contain the new
	/// position value.
	/// </description>
	/// </item>
	/// <item>
	/// <description><c></c><c></c><b>SIF_RANGE</b></description>
	/// <description>
	/// Sets the range information for the flat scroll bar. The <b>nMin</b> and <b>nMax</b> members of the <c>SCROLLINFO</c> structure must
	/// contain the new range values.
	/// </description>
	/// </item>
	/// <item>
	/// <description><c></c><c></c><b>SIF_ALL</b></description>
	/// <description>A combination of SIF_PAGE, SIF_POS, and SIF_RANGE.</description>
	/// </item>
	/// </list>
	/// </param>
	/// <param name="fRedraw">
	/// <para>Type: <b><c>BOOL</c></b></para>
	/// <para>
	/// Specifies whether the scroll bar should be redrawn immediately to reflect the change. If this parameter is <b>TRUE</b>, the scroll
	/// bar is redrawn; if it is <b>FALSE</b>, the scroll bar is not redrawn.
	/// </para>
	/// </param>
	/// <returns>
	/// <para>Type: <b>int</b></para>
	/// <para>
	/// Returns the current scroll position. If the call to <b>FlatSB_SetScrollInfo</b> changes the scroll position, then the previous
	/// position is returned.
	/// </para>
	/// </returns>
	/// <remarks>
	/// <para>
	/// <b>Note</b>  Flat scroll bar functions are implemented in Comctl32.dll versions 4.71 through 5.82. Comctl32.dll versions 6.00 and
	/// higher do not support flat scroll bars.
	/// </para>
	/// <para></para>
	/// </remarks>
	// https://learn.microsoft.com/en-us/windows/win32/api/commctrl/nf-commctrl-flatsb_setscrollinfo int FlatSB_SetScrollInfo( HWND hParent,
	// int code, LPSCROLLINFO psi, BOOL fRedraw );
	[PInvokeData("commctrl.h", MSDNShortId = "NF:commctrl.FlatSB_SetScrollInfo")]
	[DllImport(Lib.ComCtl32, SetLastError = false, ExactSpelling = true)]
	public static extern int FlatSB_SetScrollInfo(HWND hParent, SB code, in SCROLLINFO psi, [MarshalAs(UnmanagedType.Bool)] bool fRedraw);

	/// <summary>
	/// Sets the current position of the thumb in a flat scroll bar. If flat scroll bars are not initialized for the window, this function
	/// calls the standard <c>SetScrollPos</c> function.
	/// </summary>
	/// <param name="hParent">
	/// <para>Type: <b><c>HWND</c></b></para>
	/// <para>
	/// A handle to the window that contains the flat scroll bar. This window handle must have been passed previously in a call to <c>InitializeFlatSB</c>.
	/// </para>
	/// </param>
	/// <param name="code">
	/// <para>Type: <b>int</b></para>
	/// <para>The scroll bar type. It can be one of the following values:</para>
	/// <list type="table">
	/// <listheader>
	/// <description>Value</description>
	/// <description>Meaning</description>
	/// </listheader>
	/// <item>
	/// <description><c></c><c></c><b>SB_HORZ</b></description>
	/// <description>Sets the thumb position of the horizontal scroll bar.</description>
	/// </item>
	/// <item>
	/// <description><c></c><c></c><b>SB_VERT</b></description>
	/// <description>Sets the thumb position of the vertical scroll bar.</description>
	/// </item>
	/// </list>
	/// </param>
	/// <param name="pos">
	/// <para>Type: <b>int</b></para>
	/// <para>The new thumb position.</para>
	/// </param>
	/// <param name="fRedraw">
	/// <para>Type: <b><c>BOOL</c></b></para>
	/// <para>
	/// Specifies whether the scroll bar should be redrawn immediately to reflect the change. If this parameter is <b>TRUE</b>, the scroll
	/// bar is redrawn; if it is <b>FALSE</b>, the scroll bar is not redrawn.
	/// </para>
	/// </param>
	/// <returns>
	/// <para>Type: <b>int</b></para>
	/// <para>Returns the previous position of the thumb in the specified flat scroll bar.</para>
	/// </returns>
	/// <remarks>
	/// <para>
	/// <b>Note</b>  Flat scroll bar functions are implemented in Comctl32.dll versions 4.71 through 5.82. Comctl32.dll versions 6.00 and
	/// higher do not support flat scroll bars.
	/// </para>
	/// <para></para>
	/// </remarks>
	// https://learn.microsoft.com/en-us/windows/win32/api/commctrl/nf-commctrl-flatsb_setscrollpos int FlatSB_SetScrollPos( HWND hParent,
	// int code, int pos, BOOL fRedraw );
	[PInvokeData("commctrl.h", MSDNShortId = "NF:commctrl.FlatSB_SetScrollPos")]
	[DllImport(Lib.ComCtl32, SetLastError = false, ExactSpelling = true)]
	public static extern int FlatSB_SetScrollPos(HWND hParent, SB code, int pos, [MarshalAs(UnmanagedType.Bool)] bool fRedraw);

	/// <summary>Sets the properties for a flat scroll bar.</summary>
	/// <param name="hParent">
	/// <para>Type: <b><c>HWND</c></b></para>
	/// <para>
	/// A handle to the window that contains the flat scroll bar. This window handle must have been passed previously in a call to <c>InitializeFlatSB</c>.
	/// </para>
	/// </param>
	/// <param name="index">
	/// <para>Type: <b><c>UINT</c></b></para>
	/// <para>Determines what <i>newValue</i> represents and which property is being set. This parameter can be one of the following values:</para>
	/// <list type="table">
	/// <listheader>
	/// <description>Value</description>
	/// <description>Meaning</description>
	/// </listheader>
	/// <item>
	/// <description><c></c><c></c><b>WSB_PROP_CXHSCROLL</b></description>
	/// <description>
	/// <i>newValue</i> is an INT_PTR value that represents the width, in pixels, of the direction buttons in a horizontal scroll bar.
	/// </description>
	/// </item>
	/// <item>
	/// <description><c></c><c></c><b>WSB_PROP_CXHTHUMB</b></description>
	/// <description>
	/// <i>newValue</i> is an INT_PTR value that represents the width, in pixels, of the thumb in a horizontal scroll bar.
	/// </description>
	/// </item>
	/// <item>
	/// <description><c></c><c></c><b>WSB_PROP_CXVSCROLL</b></description>
	/// <description><i>newValue</i> is an INT_PTR value that represents the width, in pixels, of the vertical scroll bar.</description>
	/// </item>
	/// <item>
	/// <description><c></c><c></c><b>WSB_PROP_CYHSCROLL</b></description>
	/// <description><i>newValue</i> is an INT_PTR value that represents the height, in pixels, of the horizontal scroll bar.</description>
	/// </item>
	/// <item>
	/// <description><c></c><c></c><b>WSB_PROP_CYVSCROLL</b></description>
	/// <description>
	/// <i>newValue</i> is an INT_PTR value that represents the height, in pixels, of the direction buttons in a vertical scroll bar.
	/// </description>
	/// </item>
	/// <item>
	/// <description><c></c><c></c><b>WSB_PROP_CYVTHUMB</b></description>
	/// <description>
	/// <i>newValue</i> is an INT_PTR value that represents the height, in pixels, of the thumb in a vertical scroll bar.
	/// </description>
	/// </item>
	/// <item>
	/// <description><c></c><c></c><b>WSB_PROP_HBKGCOLOR</b></description>
	/// <description><i>newValue</i> is a <b>COLORREF</b> value that represents the background color in a horizontal scroll bar.</description>
	/// </item>
	/// <item>
	/// <description><c></c><c></c><b>WSB_PROP_HSTYLE</b></description>
	/// <description>
	/// <i>newValue</i> is one of the following values that changes the visual effects for the horizontal scroll bar. FSB_ENCARTA_MODE A
	/// standard flat scroll bar is displayed. When the mouse moves over a direction button or the thumb, that portion of the scroll bar will
	/// be displayed in 3-D. FSB_FLAT_MODE A standard flat scroll bar is displayed. When the mouse moves over a direction button or the
	/// thumb, that portion of the scroll bar will be displayed in inverted colors. FSB_REGULAR_MODE A normal, nonflat scroll bar is
	/// displayed. No special visual effects will be applied.
	/// </description>
	/// </item>
	/// <item>
	/// <description><c></c><c></c><b>WSB_PROP_PALETTE</b></description>
	/// <description>
	/// <i>newValue</i> is an <b>HPALETTE</b> value that represents the new palette that the scroll bar should use when drawing.
	/// </description>
	/// </item>
	/// <item>
	/// <description><c></c><c></c><b>WSB_PROP_VBKGCOLOR</b></description>
	/// <description><i>newValue</i> is a <b>COLORREF</b> value that represents the background color in a vertical scroll bar.</description>
	/// </item>
	/// <item>
	/// <description><c></c><c></c><b>WSB_PROP_VSTYLE</b></description>
	/// <description>
	/// <i>newValue</i> is one of the following values that changes the visual effects for the vertical scroll bar: FSB_ENCARTA_MODE A
	/// standard flat scroll bar is displayed. When the mouse moves over a direction button or the thumb, that portion of the scroll bar will
	/// be displayed in 3-D. FSB_FLAT_MODE A standard flat scroll bar is displayed. When the mouse moves over a direction button or the
	/// thumb, that portion of the scroll bar will be displayed in inverted colors. FSB_REGULAR_MODE A normal, nonflat scroll bar is
	/// displayed. No special visual effects will be applied.
	/// </description>
	/// </item>
	/// </list>
	/// </param>
	/// <param name="newValue">
	/// <para>Type: <b><c>INT_PTR</c></b></para>
	/// <para>A new value to set. This parameter depends on the flag passed in <i>index</i>.</para>
	/// </param>
	/// <param name="fRedraw">
	/// <para>Type: <b><c>BOOL</c></b></para>
	/// <para>
	/// Specifies whether the scroll bar should be redrawn immediately to reflect the change. If this parameter is <b>TRUE</b>, the scroll
	/// bar is redrawn; if it is <b>FALSE</b>, the scroll bar is not redrawn.
	/// </para>
	/// </param>
	/// <returns>
	/// <para>Type: <b><c>BOOL</c></b></para>
	/// <para>Returns nonzero if successful, or zero otherwise.</para>
	/// </returns>
	/// <remarks>
	/// <para>
	/// <b>Note</b>  Flat scroll bar functions are implemented in Comctl32.dll versions 4.71 through 5.82. Comctl32.dll versions 6.00 and
	/// higher do not support flat scroll bars.
	/// </para>
	/// <para></para>
	/// </remarks>
	// https://learn.microsoft.com/en-us/windows/win32/api/commctrl/nf-commctrl-flatsb_setscrollprop BOOL FlatSB_SetScrollProp( HWND hParent,
	// UINT index, INT_PTR newValue, BOOL pMax );
	[PInvokeData("commctrl.h", MSDNShortId = "NF:commctrl.FlatSB_SetScrollProp")]
	[DllImport(Lib.ComCtl32, SetLastError = false, ExactSpelling = true)]
	[return: MarshalAs(UnmanagedType.Bool)]
	public static extern bool FlatSB_SetScrollProp(HWND hParent, WSB_PROP index, [In] IntPtr newValue, [MarshalAs(UnmanagedType.Bool)] bool fRedraw);

	/// <summary>
	/// Sets the scroll range of a flat scroll bar. If flat scroll bars are not initialized for the window, this function calls the standard
	/// <c>SetScrollRange</c> function.
	/// </summary>
	/// <param name="hParent">
	/// <para>Type: <b><c>HWND</c></b></para>
	/// <para>
	/// A handle to the window that contains the flat scroll bar. This window handle must have been passed previously in a call to <c>InitializeFlatSB</c>.
	/// </para>
	/// </param>
	/// <param name="code">
	/// <para>Type: <b>int</b></para>
	/// <para>The scroll bar type. It can be one of the following values:</para>
	/// <list type="table">
	/// <listheader>
	/// <description>Value</description>
	/// <description>Meaning</description>
	/// </listheader>
	/// <item>
	/// <description><c></c><c></c><b>SB_HORZ</b></description>
	/// <description>Sets the scroll range of the horizontal scroll bar.</description>
	/// </item>
	/// <item>
	/// <description><c></c><c></c><b>SB_VERT</b></description>
	/// <description>Sets the scroll range of the vertical scroll bar.</description>
	/// </item>
	/// </list>
	/// </param>
	/// <param name="min">
	/// <para>Type: <b>int</b></para>
	/// <para>The new minimum scroll range value.</para>
	/// </param>
	/// <param name="max">
	/// <para>Type: <b>int</b></para>
	/// <para>The new maximum scroll range value.</para>
	/// </param>
	/// <param name="fRedraw">
	/// <para>Type: <b><c>BOOL</c></b></para>
	/// <para>
	/// Specifies whether the scroll bar should be redrawn immediately to reflect the change. If this parameter is <b>TRUE</b>, the scroll
	/// bar is redrawn; if it is <b>FALSE</b>, the scroll bar is not redrawn.
	/// </para>
	/// </param>
	/// <returns>
	/// <para>Type: <b>int</b></para>
	/// <para>Returns nonzero if successful, or zero otherwise.</para>
	/// </returns>
	/// <remarks>
	/// <para>
	/// <b>Note</b>  Flat scroll bar functions are implemented in Comctl32.dll versions 4.71 through 5.82. Comctl32.dll versions 6.00 and
	/// higher do not support flat scroll bars.
	/// </para>
	/// <para></para>
	/// </remarks>
	// https://learn.microsoft.com/en-us/windows/win32/api/commctrl/nf-commctrl-flatsb_setscrollrange int FlatSB_SetScrollRange( HWND
	// hParent, int code, int min, int max, BOOL fRedraw );
	[PInvokeData("commctrl.h", MSDNShortId = "NF:commctrl.FlatSB_SetScrollRange")]
	[DllImport(Lib.ComCtl32, SetLastError = false, ExactSpelling = true)]
	public static extern int FlatSB_SetScrollRange(HWND hParent, SB code, int min, int max, [MarshalAs(UnmanagedType.Bool)] bool fRedraw);

	/// <summary>
	/// Shows or hides a flat scroll bar. If flat scroll bars are not initialized for the window, this function calls the standard
	/// <c>ShowScrollBar</c> function.
	/// </summary>
	/// <param name="hParent">
	/// <para>Type: <b><c>HWND</c></b></para>
	/// <para>
	/// A handle to the window that contains the flat scroll bar. This window handle must have been passed previously in a call to <c>InitializeFlatSB</c>.
	/// </para>
	/// </param>
	/// <param name="code">
	/// <para>Type: <b>int</b></para>
	/// <para>The scroll bar type. It can be one of the following values:</para>
	/// <list type="table">
	/// <listheader>
	/// <description>Value</description>
	/// <description>Meaning</description>
	/// </listheader>
	/// <item>
	/// <description><c></c><c></c><b>SB_BOTH</b></description>
	/// <description>Shows or hides the horizontal and vertical scroll bars.</description>
	/// </item>
	/// <item>
	/// <description><c></c><c></c><b>SB_HORZ</b></description>
	/// <description>Shows or hides the horizontal scroll bar.</description>
	/// </item>
	/// <item>
	/// <description><c></c><c></c><b>SB_VERT</b></description>
	/// <description>Shows or hides the vertical scroll bar.</description>
	/// </item>
	/// </list>
	/// </param>
	/// <param name="fShown">
	/// <para>Type: <b><c>BOOL</c></b></para>
	/// <para>
	/// Specifies whether the scroll bar should be shown or hidden. If this parameter is nonzero, the scroll bar will be shown; if it is
	/// zero, the scroll bar will be hidden.
	/// </para>
	/// </param>
	/// <returns>
	/// <para>Type: <b><c>BOOL</c></b></para>
	/// <para>Returns nonzero if successful, or zero otherwise.</para>
	/// </returns>
	/// <remarks>
	/// <para>
	/// <b>Note</b>  Flat scroll bar functions are implemented in Comctl32.dll versions 4.71 through 5.82. Comctl32.dll versions 6.00 and
	/// higher do not support flat scroll bars.
	/// </para>
	/// <para></para>
	/// </remarks>
	// https://learn.microsoft.com/en-us/windows/win32/api/commctrl/nf-commctrl-flatsb_showscrollbar BOOL FlatSB_ShowScrollBar( HWND hParent,
	// int code, BOOL flags );
	[PInvokeData("commctrl.h", MSDNShortId = "NF:commctrl.FlatSB_ShowScrollBar")]
	[DllImport(Lib.ComCtl32, SetLastError = false, ExactSpelling = true)]
	[return: MarshalAs(UnmanagedType.Bool)]
	public static extern bool FlatSB_ShowScrollBar(HWND hParent, SB code, [MarshalAs(UnmanagedType.Bool)] bool fShown);

	/// <summary>Initializes flat scroll bars for a particular window.</summary>
	/// <param name="hParent">
	/// <para>Type: <b><c>HWND</c></b></para>
	/// <para>A handle to the window that will receive flat scroll bars.</para>
	/// </param>
	/// <returns>
	/// <para>Type: <b><c>BOOL</c></b></para>
	/// <para>Returns nonzero if successful, or zero otherwise.</para>
	/// </returns>
	/// <remarks>
	/// <para>
	/// This function must be called before any other flat scroll bar functions are called. The window will receive flat scroll bars by
	/// default. The scroll bar style can be changed with the <c>FlatSB_SetScrollProp</c> function.
	/// </para>
	/// <para>
	/// <b>Note</b>  Flat scroll bar functions are implemented in Comctl32.dll versions 4.71 through 5.82. Comctl32.dll versions 6.00 and
	/// higher do not support flat scroll bars.
	/// </para>
	/// <para></para>
	/// </remarks>
	// https://learn.microsoft.com/en-us/windows/win32/api/commctrl/nf-commctrl-initializeflatsb BOOL InitializeFlatSB( HWND hParent );
	[PInvokeData("commctrl.h", MSDNShortId = "NF:commctrl.InitializeFlatSB")]
	[DllImport(Lib.ComCtl32, SetLastError = false, ExactSpelling = true)]
	[return: MarshalAs(UnmanagedType.Bool)]
	public static extern bool InitializeFlatSB(HWND hParent);

	/// <summary>Uninitializes flat scroll bars for a particular window. The specified window will revert to standard scroll bars.</summary>
	/// <param name="hParent">
	/// <para>Type: <b><c>HWND</c></b></para>
	/// <para>A handle to the window with the flat scroll bars that will be uninitialized.</para>
	/// </param>
	/// <returns>
	/// <para>Type: <b><c>HRESULT</c></b></para>
	/// <para>Returns one of the following values.</para>
	/// <list type="table">
	/// <listheader>
	/// <description>Return code</description>
	/// <description>Description</description>
	/// </listheader>
	/// <item>
	/// <description><b>E_FAIL</b></description>
	/// <description>One of the window's scroll bars is currently in use. The operation cannot be completed at this time.</description>
	/// </item>
	/// <item>
	/// <description><b>S_FALSE</b></description>
	/// <description>The window does not have flat scroll bars initialized.</description>
	/// </item>
	/// <item>
	/// <description><b>S_OK</b></description>
	/// <description>The operation was successful.</description>
	/// </item>
	/// </list>
	/// </returns>
	/// <remarks>
	/// <para>
	/// <b>Note</b>  Flat scroll bar functions are implemented in Comctl32.dll versions 4.71 through 5.82. Comctl32.dll versions 6.00 and
	/// higher do not support flat scroll bars.
	/// </para>
	/// <para></para>
	/// </remarks>
	// https://learn.microsoft.com/en-us/windows/win32/api/commctrl/nf-commctrl-uninitializeflatsb HRESULT UninitializeFlatSB( HWND hParent );
	[PInvokeData("commctrl.h", MSDNShortId = "NF:commctrl.UninitializeFlatSB")]
	[DllImport(Lib.ComCtl32, SetLastError = false, ExactSpelling = true)]
	public static extern HRESULT UninitializeFlatSB(HWND hParent);
}