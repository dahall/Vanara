using System;
using System.Runtime.InteropServices;
using System.Text;
using Vanara.Extensions;
using static Vanara.PInvoke.Gdi32;
using static Vanara.PInvoke.User32;

namespace Vanara.PInvoke
{
	/// <summary>Methods and enumerations from uxtheme.dll</summary>
	public static partial class UxTheme
	{
		/// <summary>Retrieves the name of the author of the theme.</summary>
		public const string SZ_THDOCPROP_AUTHOR = "author";

		/// <summary>Retrieves the name of the theme.</summary>
		public const string SZ_THDOCPROP_CANONICALNAME = "ThemeName";

		/// <summary>Retrieves the display name of the theme.</summary>
		public const string SZ_THDOCPROP_DISPLAYNAME = "DisplayName";

		/// <summary>Retrieves the tooltip associated with this theme.</summary>
		public const string SZ_THDOCPROP_TOOLTIP = "ToolTip";

		/// <summary>Callback function for DrawThemeTextEx.</summary>
		/// <param name="hdc">HDC to use for drawing.</param>
		/// <param name="pszText">Pointer to a string that contains the text to draw.</param>
		/// <param name="cchText">
		/// Value of type int that contains the number of characters to draw. If the parameter is set to -1, all the characters in the string
		/// are drawn.
		/// </param>
		/// <param name="prc">
		/// Pointer to a RECT structure that contains the rectangle, in logical coordinates, in which the text is to be drawn.
		/// </param>
		/// <param name="dwFlags">
		/// DWORD that contains one or more values that specify the string's formatting. See Format Values for possible parameter values.
		/// </param>
		/// <param name="lParam">Parameter for callback back function specified by pfnDrawTextCallback.</param>
		/// <returns>Undocumented</returns>
		[PInvokeData("Uxtheme.h")]
		[UnmanagedFunctionPointer(CallingConvention.Winapi, CharSet = CharSet.Unicode)]
		public delegate int DTT_CALLBACK_PROC(HDC hdc, string pszText, int cchText, ref RECT prc, DrawTextFlags dwFlags, IntPtr lParam);

		/// <summary>Flags that specify the selected options for DTBGOPTS.</summary>
		[PInvokeData("Uxtheme.h")]
		[Flags]
		public enum DrawThemeBackgroundFlags
		{
			/// <summary>No flags are set.</summary>
			None = 0,

			/// <summary>rcClip specifies the rectangle to which drawing is clipped.</summary>
			DTBG_CLIPRECT = 1,

			/// <summary>Deprecated. Draw transparent and alpha images as solid.</summary>
			DTBG_DRAWSOLID = 2,

			/// <summary>Do not draw the border of the part (currently this value is only supported for bgtype=borderfill).</summary>
			DTBG_OMITBORDER = 4,

			/// <summary>Do not draw the content area of the part (currently this value is only supported for bgtype=borderfill).</summary>
			DTBG_OMITCONTENT = 8,

			/// <summary>Deprecated.</summary>
			DTBG_COMPUTINGREGION = 16,

			/// <summary>Assume the hdc is mirrored and flip images as appropriate (currently this value is only supported for bgtype=imagefile).</summary>
			DTBG_MIRRORDC = 32,

			/// <summary>Do not mirror the output; even in right-to-left (RTL) layout.</summary>
			DTBG_NOMIRROR = 64
		}

		/// <summary>Flags for DrawThemeParentBackgroundEx.</summary>
		[PInvokeData("Uxtheme.h")]
		[Flags]
		public enum DrawThemeParentBackgroundFlags
		{
			/// <summary>No flags are set.</summary>
			None = 0,

			/// <summary>If set, hdc is assumed to be a window DC, not a client DC.</summary>
			DTPB_WINDOWDC = 1,

			/// <summary>
			/// If set, this function sends a WM_CTLCOLORSTATIC message to the parent and uses the brush if one is provided. Otherwise, it
			/// uses COLOR_BTNFACE.
			/// </summary>
			DTPB_USECTLCOLORSTATIC = 2,

			/// <summary>
			/// If set, this function returns S_OK without sending a WM_CTLCOLORSTATIC message if the parent actually painted on WM_ERASEBKGND.
			/// </summary>
			DTPB_USEERASEBKGND = 4
		}

		/// <summary>
		/// A combination of flags that specify whether certain values of the DTTOPTS structure have been specified, and how to interpret
		/// these values. This member can be a combination of the following.
		/// </summary>
		[PInvokeData("Uxtheme.h")]
		[Flags]
		public enum DrawThemeTextOptionsMasks
		{
			/// <summary>The crText member value is valid.</summary>
			DTT_TEXTCOLOR = 1,

			/// <summary>The crBorder member value is valid.</summary>
			DTT_BORDERCOLOR = 2,

			/// <summary>The crShadow member value is valid.</summary>
			DTT_SHADOWCOLOR = 4,

			/// <summary>The iTextShadowType member value is valid.</summary>
			DTT_SHADOWTYPE = 8,

			/// <summary>The ptShadowOffset member value is valid.</summary>
			DTT_SHADOWOFFSET = 16,

			/// <summary>The iBorderSize member value is valid.</summary>
			DTT_BORDERSIZE = 32,

			/// <summary>The iFontPropId member value is valid.</summary>
			DTT_FONTPROP = 64,

			/// <summary>The iColorPropId member value is valid.</summary>
			DTT_COLORPROP = 128,

			/// <summary>The iStateId member value is valid.</summary>
			DTT_STATEID = 256,

			/// <summary>
			/// The pRect parameter of the DrawThemeTextEx function that uses this structure will be used as both an in and an out parameter.
			/// After the function returns, the pRect parameter will contain the rectangle that corresponds to the region calculated to be drawn.
			/// </summary>
			DTT_CALCRECT = 512,

			/// <summary>The fApplyOverlay member value is valid.</summary>
			DTT_APPLYOVERLAY = 1024,

			/// <summary>The iGlowSize member value is valid.</summary>
			DTT_GLOWSIZE = 2048,

			/// <summary>The pfnDrawTextCallback member value is valid.</summary>
			DTT_CALLBACK = 4096,

			/// <summary>
			/// Draws text with antialiased alpha. Use of this flag requires a top-down DIB section. This flag works only if the HDC passed
			/// to function DrawThemeTextEx has a top-down DIB section currently selected in it. For more information, see Device-Independent Bitmaps.
			/// </summary>
			DTT_COMPOSITED = 8192
		}

		/// <summary>The flags that specify how the bitmap is to be retrieved by GetThemeBitmap.</summary>
		[PInvokeData("Uxtheme.h", MSDNShortId = "bb773388")]
		[Flags]
		public enum GBF : uint
		{
			/// <summary>Retrieves a handle to the existing bitmap.</summary>
			GBF_DIRECT = 1,

			/// <summary>Retrieves a copy of the bitmap.</summary>
			GBF_COPY = 2
		}

		/// <summary>Option values that are used with the dwOptions parameter of the HitTestThemeBackground function.</summary>
		[PInvokeData("Uxtheme.h", MSDNShortId = "bb773203")]
		[Flags]
		public enum HitTestOptions : uint
		{
			/// <summary>Theme background segment hit test option.</summary>
			HTTB_BACKGROUNDSEG = 0x00000000,

			/// <summary>Fixed border hit test option.</summary>
			HTTB_FIXEDBORDER = 0x00000002,

			/// <summary>Caption hit test option.</summary>
			HTTB_CAPTION = 0x00000004,

			/// <summary>Resizing left border hit test option.</summary>
			HTTB_RESIZINGBORDER_LEFT = 0x00000010,

			/// <summary>Resizing top border hit test option.</summary>
			HTTB_RESIZINGBORDER_TOP = 0x00000020,

			/// <summary>Resizing right border hit test option.</summary>
			HTTB_RESIZINGBORDER_RIGHT = 0x00000040,

			/// <summary>Resizing bottom border hit test option.</summary>
			HTTB_RESIZINGBORDER_BOTTOM = 0x00000080,

			/// <summary>Resizing border hit test options.</summary>
			HTTB_RESIZINGBORDER = (HTTB_RESIZINGBORDER_LEFT | HTTB_RESIZINGBORDER_TOP | HTTB_RESIZINGBORDER_RIGHT | HTTB_RESIZINGBORDER_BOTTOM),

			/// <summary>
			/// Resizing border is specified as a template, not just window edges. This option is mutually exclusive with
			/// HTTB_SYSTEMSIZINGMARGINS; HTTB_SIZINGTEMPLATE takes precedence.
			/// </summary>
			HTTB_SIZINGTEMPLATE = 0x00000100,

			/// <summary>
			/// Uses the system resizing border width rather than visual style content margins. This option is mutually exclusive with
			/// HTTB_SIZINGTEMPLATE; HTTB_SIZINGTEMPLATE takes precedence.
			/// </summary>
			HTTB_SYSTEMSIZINGMARGINS = 0x00000200,
		}

		/// <summary>Optional flags that control how to return the theme data.</summary>
		[PInvokeData("Uxtheme.h", MSDNShortId = "bb759823")]
		[Flags]
		public enum OpenThemeDataOptions
		{
			/// <summary>No flags are set.</summary>
			None = 0,

			/// <summary>Forces drawn images from this theme to stretch to fit the rectangles specified by drawing functions.</summary>
			OTD_FORCE_RECT_SIZING = 1,

			/// <summary>Allows theme elements to be drawn in the non-client area of the window.</summary>
			OTD_NONCLIENT = 2
		}

		/// <summary>Returned by <c>GetThemePropertyOrigin</c> to specify where a property was found.</summary>
		// typedef enum { PO_STATE = 0, PO_PART = 1, PO_CLASS = 2, PO_GLOBAL = 3, PO_NOTFOUND = 4} PROPERTYORIGIN; https://msdn.microsoft.com/en-us/library/windows/desktop/bb759837(v=vs.85).aspx
		[PInvokeData("Uxtheme.h", MSDNShortId = "bb759837")]
		public enum PROPERTYORIGIN
		{
			/// <summary>Property was found in the state section.</summary>
			PO_STATE = 0,

			/// <summary>Property was found in the part section.</summary>
			PO_PART = 1,

			/// <summary>Property was found in the class section.</summary>
			PO_CLASS = 2,

			/// <summary>Property was found in the list of global variables.</summary>
			PO_GLOBAL = 3,

			/// <summary>Property was not found.</summary>
			PO_NOTFOUND = 4
		}

		/// <summary>A property that is associated with an animation storyboard and target.</summary>
		[PInvokeData("Uxtheme.h", MSDNShortId = "hh404183")]
		public enum TA_PROPERTY
		{
			/// <summary>Undocumented</summary>
			TAP_FLAGS,

			/// <summary>Undocumented</summary>
			TAP_TRANSFORMCOUNT,

			/// <summary>Undocumented</summary>
			TAP_STAGGERDELAY,

			/// <summary>Undocumented</summary>
			TAP_STAGGERDELAYCAP,

			/// <summary>Undocumented</summary>
			TAP_STAGGERDELAYFACTOR,

			/// <summary>Undocumented</summary>
			TAP_ZORDER,
		}

		/// <summary>Undocumented values for the TA_TRANSFORM structure returned by GetThemeAnimationTransform.</summary>
		[PInvokeData("Uxtheme.h", MSDNShortId = "hh404183")]
		[Flags]
		public enum TA_PROPERTY_FLAG
		{
			/// <summary>Undocumented</summary>
			TAPF_NONE = 0x0,

			/// <summary>Undocumented</summary>
			TAPF_HASSTAGGER = 0x1,

			/// <summary>Undocumented</summary>
			TAPF_ISRTLAWARE = 0x2,

			/// <summary>Undocumented</summary>
			TAPF_ALLOWCOLLECTION = 0x4,

			/// <summary>Undocumented</summary>
			TAPF_HASBACKGROUND = 0x8,

			/// <summary>Undocumented</summary>
			TAPF_HASPERSPECTIVE = 0x10,
		}

		/// <summary>Undocumented values for the TA_TIMINGFUNCTION structure returned by GetThemeTimingFunction.</summary>
		[PInvokeData("Uxtheme.h", MSDNShortId = "hh404194")]
		public enum TA_TIMINGFUNCTION_TYPE
		{
			/// <summary>Undocumented</summary>
			TTFT_UNDEFINED,

			/// <summary>Undocumented</summary>
			TTFT_CUBIC_BEZIER,
		}

		/// <summary>Undocumented values for the TA_TRANSFORM structure returned by GetThemeAnimationTransform.</summary>
		[PInvokeData("UxTheme.h")]
		[Flags]
		public enum TA_TRANSFORM_FLAG
		{
			/// <summary>Undocumented</summary>
			TATF_NONE = 0x0,

			/// <summary>Undocumented</summary>
			TATF_TARGETVALUES_USER = 0x1,

			/// <summary>Undocumented</summary>
			TATF_HASINITIALVALUES = 0x2,

			/// <summary>Undocumented</summary>
			TATF_HASORIGINVALUES = 0x4,
		}

		/// <summary>Undocumented values for the TA_TRANSFORM structure returned by GetThemeAnimationTransform.</summary>
		[PInvokeData("UxTheme.h")]
		public enum TA_TRANSFORM_TYPE
		{
			/// <summary>Undocumented</summary>
			TATT_TRANSLATE_2D,

			/// <summary>Undocumented</summary>
			TATT_SCALE_2D,

			/// <summary>Undocumented</summary>
			TATT_OPACITY,

			/// <summary>Undocumented</summary>
			TATT_CLIP,
		}

		/// <summary>Flags used by the iTextShadowType member of DTTOPS.</summary>
		[PInvokeData("UxTheme.h")]
		public enum TextShadowType
		{
			/// <summary>No shadow will be drawn.</summary>
			/// <remarks>TST_NONE</remarks>
			TST_NONE = 0,

			/// <summary>The shadow will be drawn to appear detailed underneath text.</summary>
			/// <remarks>TST_SINGLE</remarks>
			TST_SINGLE = 1,

			/// <summary>The shadow will be drawn to appear blurred underneath text.</summary>
			/// <remarks>TST_CONTINUOUS</remarks>
			TST_CONTINUOUS = 2
		}

		/// <summary>Values returned by GetThemeAppProperties.</summary>
		[PInvokeData("UxTheme.h", MSDNShortId = "bb773320")]
		[Flags]
		public enum ThemeAppProperties : uint
		{
			/// <summary>Specifies that the non-client areas of application windows have visual styles applied.</summary>
			STAP_ALLOW_NONCLIENT = (1U << 0),

			/// <summary>Specifies that controls in application windows have visual styles applied.</summary>
			STAP_ALLOW_CONTROLS = (1U << 1),

			/// <summary>Specifies that all web content displayed in an application is rendered using visual styles.</summary>
			STAP_ALLOW_WEBCONTENT = (1U << 2),
		}

		/// <summary>Options for EnableThemeDialogTexture.</summary>
		[PInvokeData("UxTheme.h", MSDNShortId = "bb773320")]
		[Flags]
		public enum ThemeDialogTextureFlags
		{
			/// <summary>Disables background texturing.</summary>
			ETDT_DISABLE = 0x00000001,

			/// <summary>Enables dialog window background texturing. The texturing is defined by a visual style.</summary>
			ETDT_ENABLE = 0x00000002,

			/// <summary>Uses the Tab control texture for the background texture of a dialog window.</summary>
			ETDT_USETABTEXTURE = 0x00000004,

			/// <summary>
			/// Enables dialog window background texturing. The texture is the Tab control texture defined by the visual style. This flag is
			/// equivalent to (ETDT_ENABLE | ETDT_USETABTEXTURE).
			/// </summary>
			ETDT_ENABLETAB = (ETDT_ENABLE | ETDT_USETABTEXTURE),

			/// <summary>Uses the Aero wizard texture for the background texture of a dialog window.</summary>
			ETDT_USEAEROWIZARDTABTEXTURE = 0x00000008,

			/// <summary>ETDT_ENABLE | ETDT_USEAEROWIZARDTABTEXTURE.</summary>
			ETDT_ENABLEAEROWIZARDTAB = (ETDT_ENABLE | ETDT_USEAEROWIZARDTABTEXTURE),

			/// <summary>ETDT_DISABLE | ETDT_ENABLE | ETDT_USETABTEXTURE | ETDT_USEAEROWIZARDTABTEXTURE.</summary>
			ETDT_VALIDBITS = (ETDT_DISABLE | ETDT_ENABLE | ETDT_USETABTEXTURE | ETDT_USEAEROWIZARDTABTEXTURE),
		}

		/// <summary>Identifies the type of size value to retrieve for a visual style part.</summary>
		// typedef enum { TS_MIN, TS_TRUE, TS_DRAW} THEME_SIZE; https://msdn.microsoft.com/en-us/library/windows/desktop/bb759839(v=vs.85).aspx
		[PInvokeData("Uxtheme.h", MSDNShortId = "bb759839")]
		public enum THEMESIZE
		{
			/// <summary>Receives the minimum size of a visual style part.</summary>
			TS_MIN,

			/// <summary>Receives the size of the visual style part that will best fit the available space.</summary>
			TS_TRUE,

			/// <summary>Receives the size that the theme manager uses to draw a part.</summary>
			TS_DRAW
		}

		/// <summary>Specifies the type of visual style attribute to set on a window.</summary>
		// typedef enum { WTA_NONCLIENT = 1} WINDOWTHEMEATTRIBUTETYPE; https://msdn.microsoft.com/en-us/library/windows/desktop/bb759870(v=vs.85).aspx
		[PInvokeData("Uxtheme.h", MSDNShortId = "bb759870")]
		public enum WINDOWTHEMEATTRIBUTETYPE
		{
			/// <summary>Non-client area window attributes will be set.</summary>
			WTA_NONCLIENT = 1,
		}

		/// <summary>Specifies flags that modify window visual style attributes. Use one, or a bitwise combination of the following values.</summary>
		[PInvokeData("Uxtheme.h", MSDNShortId = "bb759875")]
		[Flags]
		public enum WTNCA
		{
			/// <summary>Prevents the window caption from being drawn.</summary>
			WTNCA_NODRAWCAPTION = 0x00000001,

			/// <summary>Prevents the system icon from being drawn.</summary>
			WTNCA_NODRAWICON = 0x00000002,

			/// <summary>Prevents the system icon menu from appearing.</summary>
			WTNCA_NOSYSMENU = 0x00000004,

			/// <summary>Prevents mirroring of the question mark, even in right-to-left (RTL) layout.</summary>
			WTNCA_NOMIRRORHELP = 0x00000008
		}

		/// <summary>Closes the theme data handle.</summary>
		/// <param name="hTheme">
		/// <para>Type: <c>HTHEME</c></para>
		/// <para>Handle to a window's specified theme data. Use <c>OpenThemeData</c> to create an <c>HTHEME</c>.</para>
		/// </param>
		/// <returns>
		/// <para>Type: <c><c>HRESULT</c></c></para>
		/// <para>If this function succeeds, it returns <c>S_OK</c>. Otherwise, it returns an <c>HRESULT</c> error code.</para>
		/// </returns>
		// HRESULT CloseThemeData( _In_ HTHEME hTheme); https://msdn.microsoft.com/en-us/library/windows/desktop/bb773287(v=vs.85).aspx
		[DllImport(Lib.UxTheme, SetLastError = false, ExactSpelling = true)]
		[PInvokeData("Uxtheme.h", MSDNShortId = "bb773287")]
		public static extern HRESULT CloseThemeData(HTHEME hTheme);

		/// <summary>Draws the border and fill defined by the visual style for the specified control part.</summary>
		/// <param name="hTheme">
		/// <para>Type: <c>HTHEME</c></para>
		/// <para>Handle to a window's specified theme data. Use <c>OpenThemeData</c> to create an HTHEME.</para>
		/// </param>
		/// <param name="hdc">
		/// <para>Type: <c><c>HDC</c></c></para>
		/// <para>HDC used for drawing the theme-defined background image.</para>
		/// </param>
		/// <param name="iPartId">
		/// <para>Type: <c>int</c></para>
		/// <para>Value of type <c>int</c> that specifies the part to draw. See Parts and States.</para>
		/// </param>
		/// <param name="iStateId">
		/// <para>Type: <c>int</c></para>
		/// <para>Value of type <c>int</c> that specifies the state of the part to draw. See Parts and States.</para>
		/// </param>
		/// <param name="pRect">
		/// <para>Type: <c>const <c>RECT</c>*</c></para>
		/// <para>
		/// Pointer to a <c>RECT</c> structure that contains the rectangle, in logical coordinates, in which the background image is drawn.
		/// </para>
		/// </param>
		/// <param name="pClipRect">
		/// <para>Type: <c>const <c>RECT</c>*</c></para>
		/// <para>Pointer to a <c>RECT</c> structure that contains a clipping rectangle. This parameter may be set to <c>NULL</c>.</para>
		/// </param>
		/// <returns>
		/// <para>Type: <c><c>HRESULT</c></c></para>
		/// <para>If this function succeeds, it returns <c>S_OK</c>. Otherwise, it returns an <c>HRESULT</c> error code.</para>
		/// </returns>
		// HRESULT DrawThemeBackground( _In_ HTHEME hTheme, _In_ HDC hdc, _In_ int iPartId, _In_ int iStateId, _In_ const RECT *pRect, _In_
		// const RECT
		// *pClipRect); https://msdn.microsoft.com/en-us/library/windows/desktop/bb773289(v=vs.85).aspx
		[DllImport(Lib.UxTheme, SetLastError = false, ExactSpelling = true)]
		[PInvokeData("Uxtheme.h", MSDNShortId = "bb773289")]
		public static extern HRESULT DrawThemeBackground(HTHEME hTheme, HDC hdc, int iPartId, int iStateId, in RECT pRect, PRECT pClipRect);

		/// <summary>
		/// <para>
		/// [ <c>DrawThemeBackgroundEx</c> is available for use in the operating systems specified in the Requirements section. It may be
		/// altered or unavailable in subsequent versions.]
		/// </para>
		/// <para>Draws the background image defined by the visual style for the specified control part.</para>
		/// </summary>
		/// <param name="hTheme">
		/// <para>Type: <c>HTHEME</c></para>
		/// <para>Handle to a window's specified theme data. Use <c>OpenThemeData</c> to create an HTHEME.</para>
		/// </param>
		/// <param name="hdc">
		/// <para>Type: <c><c>HDC</c></c></para>
		/// <para>HDC used for drawing the theme-defined background image.</para>
		/// </param>
		/// <param name="iPartId">
		/// <para>Type: <c>int</c></para>
		/// <para>Value of type <c>int</c> that specifies the part to draw. See Parts and States.</para>
		/// </param>
		/// <param name="iStateId">
		/// <para>Type: <c>int</c></para>
		/// <para>Value of type <c>int</c> that specifies the state of the part to draw. See Parts and States.</para>
		/// </param>
		/// <param name="pRect">
		/// <para>Type: <c>const <c>RECT</c>*</c></para>
		/// <para>
		/// Pointer to a <c>RECT</c> structure that contains the rectangle, in logical coordinates, in which the background image is drawn.
		/// </para>
		/// </param>
		/// <param name="pOptions">
		/// <para>Type: <c>const <c>DTBGOPTS</c>*</c></para>
		/// <para>Pointer to a <c>DTBGOPTS</c> structure that contains clipping information. This parameter may be set to <c>NULL</c>.</para>
		/// </param>
		/// <returns>
		/// <para>Type: <c><c>HRESULT</c></c></para>
		/// <para>If this function succeeds, it returns <c>S_OK</c>. Otherwise, it returns an <c>HRESULT</c> error code.</para>
		/// </returns>
		// HRESULT DrawThemeBackgroundEx( _In_ HTHEME hTheme, _In_ HDC hdc, _In_ int iPartId, _In_ int iStateId, _In_ const RECT *pRect, _In_
		// const DTBGOPTS
		// *pOptions); https://msdn.microsoft.com/en-us/library/windows/desktop/bb773294(v=vs.85).aspx
		[DllImport(Lib.UxTheme, SetLastError = false, ExactSpelling = true)]
		[PInvokeData("Uxtheme.h", MSDNShortId = "bb773294")]
		public static extern HRESULT DrawThemeBackgroundEx(HTHEME hTheme, HDC hdc, int iPartId, int iStateId, in RECT pRect, DTBGOPTS pOptions);

		/// <summary>Draws one or more edges defined by the visual style of a rectangle.</summary>
		/// <param name="hTheme">
		/// <para>Type: <c>HTHEME</c></para>
		/// <para>Handle to a window's specified theme data. Use <c>OpenThemeData</c> to create an HTHEME.</para>
		/// </param>
		/// <param name="hdc">
		/// <para>Type: <c><c>HDC</c></c></para>
		/// <para>HDC.</para>
		/// </param>
		/// <param name="iPartId">
		/// <para>Type: <c>int</c></para>
		/// <para>Value of type <c>int</c> that specifies the part that contains the rectangle. See Parts and States.</para>
		/// </param>
		/// <param name="iStateId">
		/// <para>Type: <c>int</c></para>
		/// <para>Value of type <c>int</c> that specifies the state of the part. See Parts and States.</para>
		/// </param>
		/// <param name="pDestRect">
		/// <para>Type: <c>LPCRECT</c></para>
		/// <para>Pointer to a <c>RECT</c> structure that contains, in logical coordinates, the rectangle.</para>
		/// </param>
		/// <param name="uEdge">
		/// <para>Type: <c><c>UINT</c></c></para>
		/// <para>
		/// <c>UINT</c> that specifies the type of inner and outer edges to draw. This parameter must be a combination of one inner-border
		/// flag and one outer-border flag, or one of the combination flags. The border flags are:
		/// </para>
		/// <para>
		/// <list type="table">
		/// <listheader>
		/// <term>Value</term>
		/// <term>Meaning</term>
		/// </listheader>
		/// <item>
		/// <term>BDR_RAISEDINNER</term>
		/// <term>Raised inner edge</term>
		/// </item>
		/// <item>
		/// <term>BDR_SUNKENINNER</term>
		/// <term>Sunken inner edge</term>
		/// </item>
		/// <item>
		/// <term>BDR_RAISEDOUTER</term>
		/// <term>Raised outer edge</term>
		/// </item>
		/// <item>
		/// <term>BDR_SUNKENOUTER</term>
		/// <term>Sunken outer edge</term>
		/// </item>
		/// <item>
		/// <term>EDGE_BUMP</term>
		/// <term>Combination of BDR_RAISEDOUTER and BDR_SUNKENINNER</term>
		/// </item>
		/// <item>
		/// <term>EDGE_ETCHED</term>
		/// <term>Combination of BDR_SUNKENOUTER and BDR_RAISEDINNER</term>
		/// </item>
		/// <item>
		/// <term>EDGE_RAISED</term>
		/// <term>Combination of BDR_RAISEDOUTER and BDR_RAISEDINNER</term>
		/// </item>
		/// <item>
		/// <term>EDGE_SUNKEN</term>
		/// <term>Combination of BDR_SUNKENOUTER and BDR_SUNKENINNER</term>
		/// </item>
		/// </list>
		/// </para>
		/// </param>
		/// <param name="uFlags">
		/// <para>Type: <c><c>UINT</c></c></para>
		/// <para><c>UINT</c> that specifies the type of border to draw. This parameter can be a combination of the following values.</para>
		/// <para>
		/// <list type="table">
		/// <listheader>
		/// <term>Value</term>
		/// <term>Meaning</term>
		/// </listheader>
		/// <item>
		/// <term>BF_ADJUST</term>
		/// <term>
		/// The rectangle pointed to by the pDestRect parameter is shrunk to exclude the edges that were drawn; otherwise the rectangle does
		/// not change.
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
		/// <term>Diagonal border. The end point is the lower-left corner of the rectangle; the origin is the upper-right corner.</term>
		/// </item>
		/// <item>
		/// <term>BF_DIAGONAL_ENDBOTTOMRIGHT</term>
		/// <term>Diagonal border. The end point is the lower-right corner of the rectangle; the origin is the upper-left corner.</term>
		/// </item>
		/// <item>
		/// <term>BF_DIAGONAL_ENDTOPLEFT</term>
		/// <term>Diagonal border. The end point is the upper-left corner of the rectangle; the origin is the lower-right corner.</term>
		/// </item>
		/// <item>
		/// <term>BF_DIAGONAL_ENDTOPRIGHT</term>
		/// <term>Diagonal border. The end point is the upper-right corner of the rectangle; the origin is the lower-left corner.</term>
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
		/// <term>Interior of the rectangle is to be filled.</term>
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
		/// <param name="pContentRect">
		/// <para>Type: <c>LPRECT</c></para>
		/// <para>
		/// Pointer to a <c>RECT</c> structure that contains, in logical coordinates, the rectangle that receives the interior rectangle, if
		/// uFlags is set to BF_ADJUST. This parameter may be set to <c>NULL</c>.
		/// </para>
		/// </param>
		/// <returns>
		/// <para>Type: <c><c>HRESULT</c></c></para>
		/// <para>If this function succeeds, it returns <c>S_OK</c>. Otherwise, it returns an <c>HRESULT</c> error code.</para>
		/// </returns>
		// HRESULT DrawThemeEdge( _In_ HTHEME hTheme, _In_ HDC hdc, _In_ int iPartId, _In_ int iStateId, _In_ LPCRECT pDestRect, _In_ UINT
		// uEdge, _In_ UINT uFlags, _Out_ LPRECT pContentRect); https://msdn.microsoft.com/en-us/library/windows/desktop/bb773298(v=vs.85).aspx
		[DllImport(Lib.UxTheme, SetLastError = false, ExactSpelling = true)]
		[PInvokeData("Uxtheme.h", MSDNShortId = "bb773298")]
		public static extern HRESULT DrawThemeEdge(HTHEME hTheme, HDC hdc, int iPartId, int iStateId, in RECT pDestRect, BorderStyles3D uEdge, BorderFlags uFlags, out RECT pContentRect);

		/// <summary>Draws an image from an image list with the icon effect defined by the visual style.</summary>
		/// <param name="hTheme">
		/// <para>Type: <c>HTHEME</c></para>
		/// <para>Handle to a window's specified theme data. Use <c>OpenThemeData</c> to create an HTHEME.</para>
		/// </param>
		/// <param name="hdc">
		/// <para>Type: <c><c>HDC</c></c></para>
		/// <para>HDC.</para>
		/// </param>
		/// <param name="iPartId">
		/// <para>Type: <c>int</c></para>
		/// <para>Value of type <c>int</c> that specifies the part in which the image is drawn. See Parts and States.</para>
		/// </param>
		/// <param name="iStateId">
		/// <para>Type: <c>int</c></para>
		/// <para>Value of type <c>int</c> that specifies the state of the part. See Parts and States.</para>
		/// </param>
		/// <param name="pRect">
		/// <para>Type: <c>LPCRECT</c></para>
		/// <para>Pointer to a <c>RECT</c> structure that contains, in logical coordinates, the rectangle in which the image is drawn.</para>
		/// </param>
		/// <param name="himl">
		/// <para>Type: <c>HIMAGELIST</c></para>
		/// <para>Handle to an <c>image list</c> that contains the image to draw.</para>
		/// </param>
		/// <param name="iImageIndex">
		/// <para>Type: <c>int</c></para>
		/// <para>Value of type <c>int</c> that specifies the index of the image to draw.</para>
		/// </param>
		/// <returns>
		/// <para>Type: <c><c>HRESULT</c></c></para>
		/// <para>If this function succeeds, it returns <c>S_OK</c>. Otherwise, it returns an <c>HRESULT</c> error code.</para>
		/// </returns>
		// HRESULT DrawThemeIcon( _In_ HTHEME hTheme, _In_ HDC hdc, _In_ int iPartId, _In_ int iStateId, _In_ LPCRECT pRect, _In_ HIMAGELIST
		// himl, _In_ int iImageIndex); https://msdn.microsoft.com/en-us/library/windows/desktop/bb773301(v=vs.85).aspx
		[DllImport(Lib.UxTheme, SetLastError = false, ExactSpelling = true)]
		[PInvokeData("Uxtheme.h", MSDNShortId = "bb773301")]
		public static extern HRESULT DrawThemeIcon(HTHEME hTheme, HDC hdc, int iPartId, int iStateId, in RECT pRect, HIMAGELIST himl, int iImageIndex);

		/// <summary>Draws the part of a parent control that is covered by a partially-transparent or alpha-blended child control.</summary>
		/// <param name="hwnd">
		/// <para>Type: <c><c>HWND</c></c></para>
		/// <para>The child control.</para>
		/// </param>
		/// <param name="hdc">
		/// <para>Type: <c><c>HDC</c></c></para>
		/// <para>The child control's DC.</para>
		/// </param>
		/// <param name="prc">
		/// <para>Type: <c>const <c>RECT</c>*</c></para>
		/// <para>
		/// The area to be drawn. The rectangle is in the child window's coordinates. If this parameter is NULL, the area to be drawn
		/// includes the entire area occupied by the child control.
		/// </para>
		/// </param>
		/// <returns>
		/// <para>Type: <c><c>HRESULT</c></c></para>
		/// <para>If this function succeeds, it returns <c>S_OK</c>. Otherwise, it returns an <c>HRESULT</c> error code.</para>
		/// </returns>
		// HRESULT DrawThemeParentBackground( _In_ HWND hwnd, _In_ HDC hdc, _In_ const RECT *prc); https://msdn.microsoft.com/en-us/library/windows/desktop/bb773306(v=vs.85).aspx
		[DllImport(Lib.UxTheme, SetLastError = false, ExactSpelling = true)]
		[PInvokeData("Uxtheme.h", MSDNShortId = "bb773306")]
		public static extern HRESULT DrawThemeParentBackground(HWND hwnd, HDC hdc, PRECT prc);

		/// <summary>
		/// Used by partially-transparent or alpha-blended child controls to draw the part of their parent in front of which they appear.
		/// Sends a <c>WM_ERASEBKGND</c> message followed by a <c>WM_PRINTCLIENT</c>.
		/// </summary>
		/// <param name="hwnd">
		/// <para>Type: <c><c>HWND</c></c></para>
		/// <para>Handle of the child control.</para>
		/// </param>
		/// <param name="hdc">
		/// <para>Type: <c><c>HDC</c></c></para>
		/// <para>HDC of the child control.</para>
		/// </param>
		/// <param name="dwFlags">
		/// <para>Type: <c><c>DWORD</c></c></para>
		/// <para>Zero or more of the following values. If this value is zero, this function returns S_OK only if the parent handled <c>WM_PRINTCLIENT</c>.</para>
		/// <para>
		/// <list type="table">
		/// <listheader>
		/// <term>Value</term>
		/// <term>Meaning</term>
		/// </listheader>
		/// <item>
		/// <term>DTPB_WINDOWDC</term>
		/// <term>If set, hdc is assumed to be a window DC, not a client DC.</term>
		/// </item>
		/// <item>
		/// <term>DTPB_USECTLCOLORSTATIC</term>
		/// <term>
		/// If set, this function sends a WM_CTLCOLORSTATIC message to the parent and uses the brush if one is provided. Otherwise, it uses COLOR_BTNFACE.
		/// </term>
		/// </item>
		/// <item>
		/// <term>DTPB_USEERASEBKGND</term>
		/// <term>If set, this function returns S_OK without sending a WM_CTLCOLORSTATIC message if the parent actually painted on WM_ERASEBKGND.</term>
		/// </item>
		/// </list>
		/// </para>
		/// </param>
		/// <param name="prc">
		/// <para>Type: <c>const <c>RECT</c>*</c></para>
		/// <para>
		/// Optional. The area to be drawn, in child coordinates. If this parameter is NULL, the area to be drawn includes the entire area
		/// occupied by the child control.
		/// </para>
		/// </param>
		/// <returns>
		/// <para>Type: <c><c>HRESULT</c></c></para>
		/// <para>S_OK if successful; otherwise, S_FALSE.</para>
		/// </returns>
		// HRESULT DrawThemeParentBackgroundEx( _In_ HWND hwnd, _In_ HDC hdc, _In_ DWORD dwFlags, _In_ const RECT *prc); https://msdn.microsoft.com/en-us/library/windows/desktop/bb773309(v=vs.85).aspx
		[DllImport(Lib.UxTheme, SetLastError = false, ExactSpelling = true)]
		[PInvokeData("Uxtheme.h", MSDNShortId = "bb773309")]
		public static extern HRESULT DrawThemeParentBackgroundEx(HWND hwnd, HDC hdc, DrawThemeParentBackgroundFlags dwFlags, PRECT prc);

		/// <summary>Draws text using the color and font defined by the visual style.</summary>
		/// <param name="hTheme">
		/// <para>Type: <c>HTHEME</c></para>
		/// <para>Handle to a window's theme data. Use <c>OpenThemeData</c> to create an HTHEME.</para>
		/// </param>
		/// <param name="hdc">
		/// <para>Type: <c><c>HDC</c></c></para>
		/// <para>HDC to use for drawing.</para>
		/// </param>
		/// <param name="iPartId">
		/// <para>Type: <c>int</c></para>
		/// <para>
		/// The control part that has the desired text appearance. See Parts and States. If this value is 0, the text is drawn in the default
		/// font, or a font selected into the device context.
		/// </para>
		/// </param>
		/// <param name="iStateId">
		/// <para>Type: <c>int</c></para>
		/// <para>The control state that has the desired text appearance. See Parts and States.</para>
		/// </param>
		/// <param name="pszText">
		/// <para>Type: <c><c>LPCWSTR</c></c></para>
		/// <para>Pointer to a string that contains the text to draw.</para>
		/// </param>
		/// <param name="iCharCount">
		/// <para>Type: <c>int</c></para>
		/// <para>
		/// Value of type <c>int</c> that contains the number of characters to draw. If the parameter is set to -1, all the characters in the
		/// string are drawn.
		/// </para>
		/// </param>
		/// <param name="dwTextFlags">
		/// <para>Type: <c><c>DWORD</c></c></para>
		/// <para>
		/// <c>DWORD</c> that contains one or more values that specify the string's formatting. See Format Values for possible parameter values.
		/// </para>
		/// </param>
		/// <param name="dwTextFlags2">
		/// <para>Type: <c><c>DWORD</c></c></para>
		/// <para>Not used. Set to zero.</para>
		/// </param>
		/// <param name="pRect">
		/// <para>Type: <c>LPCRECT</c></para>
		/// <para>
		/// Pointer to a <c>RECT</c> structure that contains the rectangle, in logical coordinates, in which the text is to be drawn. It is
		/// recommended to use <c>pExtentRect</c> from <c>GetThemeTextExtent</c> to retrieve the correct coordinates.
		/// </para>
		/// </param>
		/// <returns>
		/// <para>Type: <c><c>HRESULT</c></c></para>
		/// <para>If this function succeeds, it returns <c>S_OK</c>. Otherwise, it returns an <c>HRESULT</c> error code.</para>
		/// </returns>
		// HRESULT DrawThemeText( _In_ HTHEME hTheme, _In_ HDC hdc, _In_ int iPartId, _In_ int iStateId, _In_ LPCWSTR pszText, _In_ int
		// iCharCount, _In_ DWORD dwTextFlags, _In_ DWORD dwTextFlags2, _In_ LPCRECT pRect); https://msdn.microsoft.com/en-us/library/windows/desktop/bb773312(v=vs.85).aspx
		[DllImport(Lib.UxTheme, SetLastError = false, ExactSpelling = true, CharSet = CharSet.Unicode)]
		[PInvokeData("Uxtheme.h", MSDNShortId = "bb773312")]
		public static extern HRESULT DrawThemeText(HTHEME hTheme, HDC hdc, int iPartId, int iStateId, string pszText, int iCharCount, DrawTextFlags dwTextFlags, [Optional] int dwTextFlags2, in RECT pRect);

		/// <summary>
		/// Draws text using the color and font defined by the visual style. Extends <c>DrawThemeText</c> by allowing additional text format options.
		/// </summary>
		/// <param name="hTheme">
		/// <para>Type: <c>HTHEME</c></para>
		/// <para>Handle to a window's specified theme data. Use <c>OpenThemeData</c> to create an HTHEME.</para>
		/// </param>
		/// <param name="hdc">
		/// <para>Type: <c><c>HDC</c></c></para>
		/// <para>HDC to use for drawing.</para>
		/// </param>
		/// <param name="iPartId">
		/// <para>Type: <c>int</c></para>
		/// <para>
		/// The control part that has the desired text appearance. See Parts and States. If this value is 0, the text is drawn in the default
		/// font, or a font selected into the device context.
		/// </para>
		/// </param>
		/// <param name="iStateId">
		/// <para>Type: <c>int</c></para>
		/// <para>The control state that has the desired text appearance. See Parts and States.</para>
		/// </param>
		/// <param name="pszText">
		/// <para>Type: <c><c>LPCWSTR</c></c></para>
		/// <para>Pointer to a string that contains the text to draw.</para>
		/// </param>
		/// <param name="iCharCount">
		/// <para>Type: <c>int</c></para>
		/// <para>
		/// Value of type <c>int</c> that contains the number of characters to draw. If the parameter is set to -1, all the characters in the
		/// string are drawn.
		/// </para>
		/// </param>
		/// <param name="dwFlags">
		/// <para>Type: <c><c>DWORD</c></c></para>
		/// <para>
		/// <c>DWORD</c> that contains one or more values that specify the string's formatting. See Format Values for possible parameter values.
		/// </para>
		/// </param>
		/// <param name="pRect">
		/// <para>Type: <c>LPRECT</c></para>
		/// <para>Pointer to a <c>RECT</c> structure that contains the rectangle, in logical coordinates, in which the text is to be drawn.</para>
		/// </param>
		/// <param name="pOptions">
		/// <para>Type: <c>const <c>DTTOPTS</c>*</c></para>
		/// <para>A <c>DTTOPTS</c> structure that defines additional formatting options that will be applied to the text being drawn.</para>
		/// </param>
		/// <returns>
		/// <para>Type: <c><c>HRESULT</c></c></para>
		/// <para>If this function succeeds, it returns <c>S_OK</c>. Otherwise, it returns an <c>HRESULT</c> error code.</para>
		/// </returns>
		// HRESULT DrawThemeTextEx( _In_ HTHEME hTheme, _In_ HDC hdc, _In_ int iPartId, _In_ int iStateId, _In_ LPCWSTR pszText, _In_ int
		// iCharCount, _In_ DWORD dwFlags, _Inout_ LPRECT pRect, _In_ const DTTOPTS *pOptions); https://msdn.microsoft.com/en-us/library/windows/desktop/bb773317(v=vs.85).aspx
		[DllImport(Lib.UxTheme, SetLastError = false, ExactSpelling = true, CharSet = CharSet.Unicode)]
		[PInvokeData("Uxtheme.h", MSDNShortId = "bb773317")]
		public static extern HRESULT DrawThemeTextEx(HTHEME hTheme, HDC hdc, int iPartId, int iStateId, string pszText, int iCharCount, DrawTextFlags dwFlags, ref RECT pRect, in DTTOPTS pOptions);

		/// <summary>Enables or disables the visual style of the background of a dialog window.</summary>
		/// <param name="hwnd">
		/// <para>Type: <c><c>HWND</c></c></para>
		/// <para>Window handle of the target dialog box.</para>
		/// </param>
		/// <param name="dwFlags">
		/// <para>Type: <c><c>DWORD</c></c></para>
		/// <para>One of the following option flag values:</para>
		/// <para>
		/// <list type="table">
		/// <listheader>
		/// <term>Value</term>
		/// <term>Meaning</term>
		/// </listheader>
		/// <item>
		/// <term>ETDT_DISABLE</term>
		/// <term>Disables background texturing.</term>
		/// </item>
		/// <item>
		/// <term>ETDT_ENABLE</term>
		/// <term>Enables dialog window background texturing. The texturing is defined by a visual style.</term>
		/// </item>
		/// <item>
		/// <term>ETDT_USETABTEXTURE</term>
		/// <term>Uses the Tab control texture for the background texture of a dialog window.</term>
		/// </item>
		/// <item>
		/// <term>ETDT_USEAEROWIZARDTABTEXTURE</term>
		/// <term>Uses the Aero wizard texture for the background texture of a dialog window.</term>
		/// </item>
		/// <item>
		/// <term>ETDT_ENABLETAB</term>
		/// <term>
		/// Enables dialog window background texturing. The texture is the Tab control texture defined by the visual style. This flag is
		/// equivalent to (ETDT_ENABLE | ETDT_USETABTEXTURE).
		/// </term>
		/// </item>
		/// <item>
		/// <term>ETDT_ENABLEAEROWIZARDTAB</term>
		/// <term>ETDT_ENABLE | ETDT_USEAEROWIZARDTABTEXTURE.</term>
		/// </item>
		/// <item>
		/// <term>ETDT_VALIDBITS</term>
		/// <term>ETDT_DISABLE | ETDT_ENABLE | ETDT_USETABTEXTURE | ETDT_USEAEROWIZARDTABTEXTURE.</term>
		/// </item>
		/// </list>
		/// </para>
		/// </param>
		/// <returns>
		/// <para>Type: <c><c>HRESULT</c></c></para>
		/// <para>If this function succeeds, it returns <c>S_OK</c>. Otherwise, it returns an <c>HRESULT</c> error code.</para>
		/// </returns>
		// HRESULT EnableThemeDialogTexture( _In_ HWND hwnd, _In_ DWORD dwFlags); https://msdn.microsoft.com/en-us/library/windows/desktop/bb773320(v=vs.85).aspx
		[DllImport(Lib.UxTheme, SetLastError = false, ExactSpelling = true)]
		[PInvokeData("Uxtheme.h", MSDNShortId = "bb773320")]
		public static extern HRESULT EnableThemeDialogTexture(HWND hwnd, ThemeDialogTextureFlags dwFlags);

		/// <summary>
		/// <para>
		/// <c>Windows Vista through Windows 7</c>: Enables or disables visual styles for the current user in the current and later sessions.
		/// </para>
		/// <para><c>Windows 8 and later</c>: This function does nothing. Visual styles are always enabled in Windows 8 and later.</para>
		/// </summary>
		/// <param name="fEnable">
		/// <para>Type: <c><c>BOOL</c></c></para>
		/// <para>Receives one of the following values.</para>
		/// <para>
		/// <list type="table">
		/// <listheader>
		/// <term>Value</term>
		/// <term>Meaning</term>
		/// </listheader>
		/// <item>
		/// <term>TRUE</term>
		/// <term>Enables visual styles. If the user previously had an active visual style, it becomes active again.</term>
		/// </item>
		/// <item>
		/// <term>FALSE</term>
		/// <term>Disables visual styles and turns visual styles off.</term>
		/// </item>
		/// </list>
		/// </para>
		/// </param>
		/// <returns>
		/// <para>Type: <c><c>HRESULT</c></c></para>
		/// <para>If this function succeeds, it returns <c>S_OK</c>. Otherwise, it returns an <c>HRESULT</c> error code.</para>
		/// </returns>
		// HRESULT EnableTheming( _In_ BOOL fEnable); https://msdn.microsoft.com/en-us/library/windows/desktop/bb773324(v=vs.85).aspx
		[DllImport(Lib.UxTheme, SetLastError = false, ExactSpelling = true)]
		[PInvokeData("Uxtheme.h", MSDNShortId = "bb773324")]
		public static extern HRESULT EnableTheming([MarshalAs(UnmanagedType.Bool)] bool fEnable);

		/// <summary>Retrieves the name of the current visual style, and optionally retrieves the color scheme name and size name.</summary>
		/// <param name="pszThemeFileName">
		/// <para>Type: <c><c>LPWSTR</c></c></para>
		/// <para>Pointer to a string that receives the theme path and file name.</para>
		/// </param>
		/// <param name="dwMaxNameChars">
		/// <para>Type: <c>int</c></para>
		/// <para>Value of type <c>int</c> that contains the maximum number of characters allowed in the theme file name.</para>
		/// </param>
		/// <param name="pszColorBuff">
		/// <para>Type: <c><c>LPWSTR</c></c></para>
		/// <para>Pointer to a string that receives the color scheme name. This parameter may be set to <c>NULL</c>.</para>
		/// </param>
		/// <param name="cchMaxColorChars">
		/// <para>Type: <c>int</c></para>
		/// <para>Value of type <c>int</c> that contains the maximum number of characters allowed in the color scheme name.</para>
		/// </param>
		/// <param name="pszSizeBuff">
		/// <para>Type: <c><c>LPWSTR</c></c></para>
		/// <para>Pointer to a string that receives the size name. This parameter may be set to <c>NULL</c>.</para>
		/// </param>
		/// <param name="cchMaxSizeChars">
		/// <para>Type: <c>int</c></para>
		/// <para>Value of type <c>int</c> that contains the maximum number of characters allowed in the size name.</para>
		/// </param>
		/// <returns>
		/// <para>Type: <c><c>HRESULT</c></c></para>
		/// <para>Returns S_OK if successful, otherwise an error code.</para>
		/// </returns>
		// HRESULT GetCurrentThemeName( _Out_ LPWSTR pszThemeFileName, _In_ int dwMaxNameChars, _Out_ LPWSTR pszColorBuff, _In_ int
		// cchMaxColorChars, _Out_ LPWSTR pszSizeBuff, _In_ int cchMaxSizeChars); https://msdn.microsoft.com/en-us/library/windows/desktop/bb773365(v=vs.85).aspx
		[DllImport(Lib.UxTheme, SetLastError = false, ExactSpelling = true)]
		[PInvokeData("Uxtheme.h", MSDNShortId = "bb773365")]
		public static extern HRESULT GetCurrentThemeName([MarshalAs(UnmanagedType.LPWStr)] StringBuilder pszThemeFileName, int dwMaxNameChars, [MarshalAs(UnmanagedType.LPWStr)] StringBuilder pszColorBuff,
			int cchMaxColorChars, [MarshalAs(UnmanagedType.LPWStr)] StringBuilder pszSizeBuff, int cchMaxSizeChars);

		/*
		/// <summary>Gets the string containing the name of an element like ‘StartBackground’ or ‘StartDesktopTilesBackground’.</summary>
		/// <param name="index">The index.</param>
		/// <returns></returns>
		[PInvokeData("UxTheme.h")]
		[DllImport(Lib.UxTheme, ExactSpelling = true, EntryPoint = "#100")]
		[return: MarshalAs(UnmanagedType.LPWStr)]
		public static extern string GetImmersiveColorNamedTypeByIndex(uint index);

		[PInvokeData("UxTheme.h")]
		[DllImport(Lib.UxTheme, ExactSpelling = true, EntryPoint = "#94")]
		public static extern uint GetImmersiveColorSetCount();

		/// <summary>Gets the immersive color from color set ex.</summary>
		/// <param name="dwImmersiveColorSet">The color set ID (between 0 and 24 for Windows 8)</param>
		/// <param name="dwImmersiveColorType">The color type (e.g. 0 for 'StartBackground').</param>
		/// <param name="bIgnoreHighContrast">
		/// Determines whether high contrast mode should be ignored – set it to <c>true</c> to retrieve the active color set's colors even
		/// when high contrast mode is enabled.
		/// </param>
		/// <param name="dwHighContrastCacheMode">
		/// Set to 1 to force UxTheme to check whether the system is in high contrast mode even with it already thinks it is (this check
		/// would otherwise only occur if high contrast mode had previously not been enabled).
		/// </param>
		/// <returns></returns>
		[DllImport(Lib.UxTheme, ExactSpelling = true, EntryPoint = "#95")]
		public static extern COLORREF GetImmersiveColorFromColorSetEx(uint dwImmersiveColorSet, uint dwImmersiveColorType, [MarshalAs(UnmanagedType.Bool)] bool bIgnoreHighContrast, uint dwHighContrastCacheMode);

		/// <summary>Gets the name of the immersive color type from.</summary>
		/// <param name="pName">
		/// Prepend 'Immersive' to the string first, or the function will fail ('StartBackground' becomes 'ImmersiveStartBackground', for example).
		/// </param>
		/// <returns></returns>
		[DllImport(Lib.UxTheme, ExactSpelling = true, EntryPoint = "#96")]
		public static extern uint GetImmersiveColorTypeFromName([MarshalAs(UnmanagedType.LPWStr)] string pName);

		/// <summary>Gets the immersive user color set preference.</summary>
		/// <param name="bForceCheckRegistry">
		/// true to force UxTheme to read the value stored in the registry (and update the system setting if what’s in the registry is
		/// different to what’s in memory).
		/// </param>
		/// <param name="bSkipCheckOnFail">
		/// Setting it to true will stop the function attempting to retrieve the user preference a second time if the first call returns –1.
		/// May only be relevant in the event that UxTheme doesn’t have permission to update the system setting with the value from the registry.
		/// </param>
		/// <returns></returns>
		[DllImport(Lib.UxTheme, ExactSpelling = true, EntryPoint = "#98")]
		public static extern uint GetImmersiveUserColorSetPreference([MarshalAs(UnmanagedType.Bool)] bool bForceCheckRegistry, [MarshalAs(UnmanagedType.Bool)] bool bSkipCheckOnFail);
		*/

		/// <summary>Gets a theme animation property basedon the storyboard id and the target id.</summary>
		/// <param name="hTheme">An opened theme handle.</param>
		/// <param name="iStoryboardId">A predefined storyboard identifier.</param>
		/// <param name="iTargetId">A predefined target identifier.</param>
		/// <param name="eProperty">The property that is associated with the animation storyboard and target.</param>
		/// <param name="pvProperty">The buffer to receive the returned property value.</param>
		/// <param name="cbSize">The byte size of a buffer that is pointed by pvProperty.</param>
		/// <param name="pcbSizeOut">The byte size of the returned property.</param>
		/// <returns>If this function succeeds, it returns <c>S_OK</c>. Otherwise, it returns an <c>HRESULT</c> error code.</returns>
		// HRESULT THEMEAPI GetThemeAnimationProperty( _In_ HTHEME hTheme, _In_ int iStoryboardId, _In_ int iTargetId, _In_ TA_PROPERTY
		// eProperty, _Out_ VOID
		// *pvProperty, _In_ DWORD cbSize, _Out_ DWORD pcbSizeOut); https://msdn.microsoft.com/en-us/library/windows/desktop/hh404183(v=vs.85).aspx
		[DllImport(Lib.UxTheme, SetLastError = false, ExactSpelling = true)]
		[PInvokeData("Uxtheme.h", MSDNShortId = "hh404183")]
		public static extern HRESULT GetThemeAnimationProperty(HTHEME hTheme, int iStoryboardId, int iTargetId, TA_PROPERTY eProperty, IntPtr pvProperty, uint cbSize, out uint pcbSizeOut);

		/// <summary>Gets an animation transform operationbased on storyboard id, target id and transformindex.</summary>
		/// <param name="hTheme">An opened theme handle.</param>
		/// <param name="iStoryboardId">A predefined storyboard identifier.</param>
		/// <param name="iTargetId">A predefined target identifier.</param>
		/// <param name="dwTransformIndex">The zero-based index of a transform operation.</param>
		/// <param name="pTransform">A pointer to a buffer to receive a transform structure.</param>
		/// <param name="cbSize">The byte size of the buffer pointed by pTransform.</param>
		/// <param name="pcbSizeOut">The byte size of a transform operation structure.</param>
		/// <returns>If this function succeeds, it returns <c>S_OK</c>. Otherwise, it returns an <c>HRESULT</c> error code.</returns>
		// HRESULT THEMEAPI GetThemeAnimationTransform( _In_ HTHEME hTheme, _In_ int iStoryboardId, _In_ int iTargetId, _In_ DWORD
		// dwTransformIndex, _Out_ TA_TRANSFORM *pTransform, _In_ DWORD cbSize, _Out_ DWORD pcbSizeOut); https://msdn.microsoft.com/en-us/library/windows/desktop/hh404186(v=vs.85).aspx
		[DllImport(Lib.UxTheme, SetLastError = false, ExactSpelling = true)]
		[PInvokeData("Uxtheme.h", MSDNShortId = "hh404186")]
		public static extern HRESULT GetThemeAnimationTransform(HTHEME hTheme, int iStoryboardId, int iTargetId, uint dwTransformIndex, out TA_TRANSFORM pTransform, uint cbSize, out uint pcbSizeOut);

		/// <summary>Retrieves the property flags that control how visual styles are applied in the current application.</summary>
		/// <returns>
		/// <para>Type: <c><c>DWORD</c></c></para>
		/// <para>The following return values are bit flags combined with a logical OR operator.</para>
		/// <para>
		/// <list type="table">
		/// <listheader>
		/// <term>Return code</term>
		/// <term>Description</term>
		/// </listheader>
		/// <item>
		/// <term>STAP_ALLOW_NONCLIENT</term>
		/// <term>Specifies that the nonclient areas of application windows have visual styles applied.</term>
		/// </item>
		/// <item>
		/// <term>STAP_ALLOW_CONTROLS</term>
		/// <term>Specifies that controls in application windows have visual styles applied.</term>
		/// </item>
		/// <item>
		/// <term>STAP_ALLOW_WEBCONTENT</term>
		/// <term>Specifies that all web content displayed in an application is rendered using visual styles.</term>
		/// </item>
		/// </list>
		/// </para>
		/// </returns>
		// DWORD GetThemeAppProperties(void); https://msdn.microsoft.com/en-us/library/windows/desktop/bb773369(v=vs.85).aspx
		[DllImport(Lib.UxTheme, SetLastError = false, ExactSpelling = true)]
		[PInvokeData("Uxtheme.h", MSDNShortId = "bb773369")]
		public static extern ThemeAppProperties GetThemeAppProperties();

		/// <summary>Retrieves the size of the content area for the background defined by the visual style.</summary>
		/// <param name="hTheme">
		/// <para>Type: <c>HTHEME</c></para>
		/// <para>Handle to a window's specified theme data. Use <c>OpenThemeData</c> to create an HTHEME.</para>
		/// </param>
		/// <param name="hdc">
		/// <para>Type: <c><c>HDC</c></c></para>
		/// <para>HDC to use when drawing. This parameter may be set to <c>NULL</c>.</para>
		/// </param>
		/// <param name="iPartId">
		/// <para>Type: <c>int</c></para>
		/// <para>Value of type <c>int</c> that specifies the part that contains the content area. See Parts and States.</para>
		/// </param>
		/// <param name="iStateId">
		/// <para>Type: <c>int</c></para>
		/// <para>Value of type <c>int</c> that specifies the state of the part that contains the content area. See Parts and States.</para>
		/// </param>
		/// <param name="pBoundingRect">
		/// <para>Type: <c>LPCRECT</c></para>
		/// <para>
		/// Pointer to a <c>RECT</c> structure that contains the total background rectangle, in logical coordinates. This is the area inside
		/// the borders or margins.
		/// </para>
		/// </param>
		/// <param name="pContentRect">
		/// <para>Type: <c>LPRECT</c></para>
		/// <para>
		/// Pointer to a <c>RECT</c> structure that receives the content area background rectangle, in logical coordinates. This rectangle is
		/// calculated to fit the content area.
		/// </para>
		/// </param>
		/// <returns>
		/// <para>Type: <c><c>HRESULT</c></c></para>
		/// <para>If this function succeeds, it returns <c>S_OK</c>. Otherwise, it returns an <c>HRESULT</c> error code.</para>
		/// </returns>
		// HRESULT GetThemeBackgroundContentRect( _In_ HTHEME hTheme, _In_ HDC hdc, _In_ int iPartId, _In_ int iStateId, _In_ LPCRECT
		// pBoundingRect, _Out_ LPRECT pContentRect); https://msdn.microsoft.com/en-us/library/windows/desktop/bb773375(v=vs.85).aspx
		[DllImport(Lib.UxTheme, SetLastError = false, ExactSpelling = true)]
		[PInvokeData("Uxtheme.h", MSDNShortId = "bb773375")]
		public static extern HRESULT GetThemeBackgroundContentRect(HTHEME hTheme, HDC hdc, int iPartId, int iStateId, in RECT pBoundingRect, out RECT pContentRect);

		/// <summary>Calculates the size and location of the background, defined by the visual style, given the content area.</summary>
		/// <param name="hTheme">
		/// <para>Type: <c>HTHEME</c></para>
		/// <para>Handle to a window's specified theme data. Use <c>OpenThemeData</c> to create an HTHEME.</para>
		/// </param>
		/// <param name="hdc">
		/// <para>Type: <c><c>HDC</c></c></para>
		/// <para>HDC to use when drawing. This parameter may be set to <c>NULL</c>.</para>
		/// </param>
		/// <param name="iPartId">
		/// <para>Type: <c>int</c></para>
		/// <para>Value of type <c>int</c> that specifies the part that contains the content. See Parts and States.</para>
		/// </param>
		/// <param name="iStateId">
		/// <para>Type: <c>int</c></para>
		/// <para>Value of type <c>int</c> that specifies the state of the part that contains the content. See Parts and States.</para>
		/// </param>
		/// <param name="pContentRect">
		/// <para>Type: <c>LPCRECT</c></para>
		/// <para>
		/// Pointer to a <c>RECT</c> structure that contains the content background rectangle, in logical coordinates. This rectangle is
		/// returned from <c>GetThemeBackgroundContentRect</c>.
		/// </para>
		/// </param>
		/// <param name="pExtentRect">
		/// <para>Type: <c>LPRECT</c></para>
		/// <para>
		/// Pointer to a <c>RECT</c> structure that receives the background rectangle, in logical coordinates. This rectangle is based on the pContentRect.
		/// </para>
		/// </param>
		/// <returns>
		/// <para>Type: <c><c>HRESULT</c></c></para>
		/// <para>If this function succeeds, it returns <c>S_OK</c>. Otherwise, it returns an <c>HRESULT</c> error code.</para>
		/// </returns>
		// HRESULT GetThemeBackgroundExtent( _In_ HTHEME hTheme, _In_ HDC hdc, _In_ int iPartId, _In_ int iStateId, _In_ LPCRECT
		// pContentRect, _Out_ LPRECT pExtentRect); https://msdn.microsoft.com/en-us/library/windows/desktop/bb773380(v=vs.85).aspx
		[DllImport(Lib.UxTheme, SetLastError = false, ExactSpelling = true)]
		[PInvokeData("Uxtheme.h", MSDNShortId = "bb773380")]
		public static extern HRESULT GetThemeBackgroundExtent(HTHEME hTheme, HDC hdc, int iPartId, int iStateId, in RECT pContentRect, out RECT pExtentRect);

		/// <summary>Computes the region for a regular or partially transparent background that is bounded by a specified rectangle.</summary>
		/// <param name="hTheme">
		/// <para>Type: <c>HTHEME</c></para>
		/// <para>Handle to a window's specified theme data. Use <c>OpenThemeData</c> to create an HTHEME.</para>
		/// </param>
		/// <param name="hdc">
		/// <para>Type: <c><c>HDC</c></c></para>
		/// <para>HDC to draw into. The DC uses dots per inch (DPI) scaling. This parameter may be set to <c>NULL</c>.</para>
		/// </param>
		/// <param name="iPartId">
		/// <para>Type: <c>int</c></para>
		/// <para>Value of type <c>int</c> that specifies the part that contains the region. See Parts and States.</para>
		/// </param>
		/// <param name="iStateId">
		/// <para>Type: <c>int</c></para>
		/// <para>Value of type <c>int</c> that specifies the state of the part. See Parts and States.</para>
		/// </param>
		/// <param name="pRect">
		/// <para>Type: <c>LPCRECT</c></para>
		/// <para>
		/// Pointer to a <c>RECT</c> structure that contains, in logical coordinates, the specified rectangle used to compute the region.
		/// </para>
		/// </param>
		/// <param name="pRegion">
		/// <para>Type: <c><c>HRGN</c>*</c></para>
		/// <para>Pointer to the handle to the computed region.</para>
		/// </param>
		/// <returns>
		/// <para>Type: <c><c>HRESULT</c></c></para>
		/// <para>If this function succeeds, it returns <c>S_OK</c>. Otherwise, it returns an <c>HRESULT</c> error code.</para>
		/// </returns>
		// HRESULT GetThemeBackgroundRegion( _In_ HTHEME hTheme, _In_ HDC hdc, _In_ int iPartId, _In_ int iStateId, _In_ LPCRECT pRect, _Out_
		// HRGN *pRegion); https://msdn.microsoft.com/en-us/library/windows/desktop/bb773384(v=vs.85).aspx
		[DllImport(Lib.UxTheme, SetLastError = false, ExactSpelling = true)]
		[PInvokeData("Uxtheme.h", MSDNShortId = "bb773384")]
		public static extern HRESULT GetThemeBackgroundRegion(HTHEME hTheme, HDC hdc, int iPartId, int iStateId, in RECT pRect, out SafeHRGN pRegion);

		/// <summary>Retrieves the bitmap associated with a particular theme, part, state, and property.</summary>
		/// <param name="hTheme">
		/// <para>Type: <c>HTHEME</c></para>
		/// <para>A handle to theme data.</para>
		/// </param>
		/// <param name="iPartId">
		/// <para>Type: <c>int</c></para>
		/// <para>The part that contains the bitmap. See Parts and States.</para>
		/// </param>
		/// <param name="iStateId">
		/// <para>Type: <c>int</c></para>
		/// <para>The state of the part.</para>
		/// </param>
		/// <param name="iPropId">
		/// <para>Type: <c>int</c></para>
		/// <para>
		/// The property to retrieve. Pass zero to automatically select the first available bitmap for this part and state, or use one of the
		/// following values.
		/// </para>
		/// <para>
		/// <list type="table">
		/// <listheader>
		/// <term>Value</term>
		/// <term>Meaning</term>
		/// </listheader>
		/// <item>
		/// <term>TMT_DIBDATA</term>
		/// <term>The background image.</term>
		/// </item>
		/// <item>
		/// <term>TMT_GLYPHDIBDATA</term>
		/// <term>The glyph image drawn on top of the background, if present.</term>
		/// </item>
		/// <item>
		/// <term>TMT_HBITMAP</term>
		/// <term>Not currently supported.</term>
		/// </item>
		/// </list>
		/// </para>
		/// </param>
		/// <param name="dwFlags">
		/// <para>Type: <c><c>ULONG</c></c></para>
		/// <para>The flags that specify how the bitmap is to be retrieved. Can be one of the following values.</para>
		/// <para>
		/// <list type="table">
		/// <listheader>
		/// <term>Value</term>
		/// <term>Meaning</term>
		/// </listheader>
		/// <item>
		/// <term>GBF_DIRECT</term>
		/// <term>Retrieves a handle to the existing bitmap.</term>
		/// </item>
		/// <item>
		/// <term>GBF_COPY</term>
		/// <term>Retrieves a copy of the bitmap.</term>
		/// </item>
		/// <item>
		/// <term>GBF_VALIDBITS</term>
		/// <term>GBF_DIRECT | GBF_COPY</term>
		/// </item>
		/// </list>
		/// </para>
		/// </param>
		/// <param name="phBitmap">
		/// <para>Type: <c><c>HBITMAP</c>*</c></para>
		/// <para>A pointer that receives a handle to the requested bitmap.</para>
		/// </param>
		/// <returns>
		/// <para>Type: <c><c>HRESULT</c></c></para>
		/// <para>If this function succeeds, it returns <c>S_OK</c>. Otherwise, it returns an <c>HRESULT</c> error code.</para>
		/// </returns>
		// HRESULT GetThemeBitmap( _In_ HTHEME hTheme, _In_ int iPartId, _In_ int iStateId, _In_ int iPropId, _In_ ULONG dwFlags, _Out_
		// HBITMAP *phBitmap); https://msdn.microsoft.com/en-us/library/windows/desktop/bb773388(v=vs.85).aspx
		[DllImport(Lib.UxTheme, SetLastError = false, ExactSpelling = true)]
		[PInvokeData("Uxtheme.h", MSDNShortId = "bb773388")]
		public static extern HRESULT GetThemeBitmap(HTHEME hTheme, int iPartId, int iStateId, int iPropId, GBF dwFlags, out SafeHBITMAP phBitmap);

		/// <summary>Retrieves the value of a <c>BOOL</c> property from the SysMetrics section of theme data.</summary>
		/// <param name="hTheme">
		/// <para>Type: <c>HTHEME</c></para>
		/// <para>Handle to a window's specified theme data. Use <c>OpenThemeData</c> to create an HTHEME.</para>
		/// </param>
		/// <param name="iPartId">
		/// <para>Type: <c>int</c></para>
		/// <para>Value of type <c>int</c> that specifies the part containing the BOOL property. See Parts and States.</para>
		/// </param>
		/// <param name="iStateId">
		/// <para>Type: <c>int</c></para>
		/// <para>Value of type <c>int</c> that specifies the state of the part. See Parts and States.</para>
		/// </param>
		/// <param name="iPropId">
		/// <para>Type: <c>int</c></para>
		/// <para>Value of type <c>int</c> that specifies the property to retrieve. May be one of the following values.</para>
		/// <para>
		/// <list type="table">
		/// <listheader>
		/// <term>Value</term>
		/// <term>Meaning</term>
		/// </listheader>
		/// <item>
		/// <term>TMT_TRANSPARENT</term>
		/// <term>
		/// TRUE if the image associated with the part and state have transparent areas. See GetThemeColor for the definition of the
		/// TMT_TRANSPARENTCOLOR value that defines the transparent color.
		/// </term>
		/// </item>
		/// <item>
		/// <term>TMT_AUTOSIZE</term>
		/// <term>TRUE if the nonclient caption area associated with the part and state vary with text width.</term>
		/// </item>
		/// <item>
		/// <term>TMT_BORDERONLY</term>
		/// <term>TRUE if the image associated with the part and state should only have its border drawn.</term>
		/// </item>
		/// <item>
		/// <term>TMT_COMPOSITED</term>
		/// <term>TRUE if the control associated with the part and state will handle its own compositing of images.</term>
		/// </item>
		/// <item>
		/// <term>TMT_BGFILL</term>
		/// <term>TRUE if true-sized images associated with this part and state are to be drawn on the background fill.</term>
		/// </item>
		/// <item>
		/// <term>TMT_GLYPHTRANSPARENT</term>
		/// <term>
		/// TRUE if the glyph associated with this part and state have transparent areas. See GetThemeColor for the definition of the
		/// TMT_GLYPHCOLOR value that defines the transparent color.
		/// </term>
		/// </item>
		/// <item>
		/// <term>TMT_GLYPHONLY</term>
		/// <term>TRUE if the glyph associated with this part and state should be drawn without a background.</term>
		/// </item>
		/// <item>
		/// <term>TMT_ALWAYSSHOWSIZINGBAR</term>
		/// <term>TRUE if the sizing bar associated with this part and state should always be shown.</term>
		/// </item>
		/// <item>
		/// <term>TMT_MIRRORIMAGE</term>
		/// <term>
		/// TRUE if the image associated with this part and state should be flipped if the window is being viewed in right-to-left reading mode.
		/// </term>
		/// </item>
		/// <item>
		/// <term>TMT_UNIFORMSIZING</term>
		/// <term>TRUE if the image associated with this part and state must have equal height and width.</term>
		/// </item>
		/// <item>
		/// <term>TMT_INTEGRALSIZING</term>
		/// <term>TRUE if the truesize image or border associated with this part and state must be sized to a factor of 2.</term>
		/// </item>
		/// <item>
		/// <term>TMT_SOURCEGROW</term>
		/// <term>TRUE if the image associated with this part and state will scale larger in size if necessary.</term>
		/// </item>
		/// <item>
		/// <term>TMT_SOURCESHRINK</term>
		/// <term>TRUE if the image associated with this part and state will scale smaller in size if necessary.</term>
		/// </item>
		/// <item>
		/// <term>TMT_USERPICTURE</term>
		/// <term>TRUE if the image associated with this part and state is based on the current user.</term>
		/// </item>
		/// </list>
		/// </para>
		/// </param>
		/// <param name="pfVal">
		/// <para>Type: <c><c>BOOL</c>*</c></para>
		/// <para>Pointer to a <c>BOOL</c> that receives the retrieved property value.</para>
		/// </param>
		/// <returns>
		/// <para>Type: <c><c>HRESULT</c></c></para>
		/// <para>If this function succeeds, it returns <c>S_OK</c>. Otherwise, it returns an <c>HRESULT</c> error code.</para>
		/// </returns>
		// HRESULT GetThemeBool( _In_ HTHEME hTheme, _In_ int iPartId, _In_ int iStateId, _In_ int iPropId, _Out_ BOOL *pfVal); https://msdn.microsoft.com/en-us/library/windows/desktop/bb773392(v=vs.85).aspx
		[DllImport(Lib.UxTheme, SetLastError = false, ExactSpelling = true)]
		[PInvokeData("Uxtheme.h", MSDNShortId = "bb773392")]
		public static extern HRESULT GetThemeBool(HTHEME hTheme, int iPartId, int iStateId, int iPropId, [MarshalAs(UnmanagedType.Bool)] out bool pfVal);

		/// <summary>Retrieves the value of a color property.</summary>
		/// <param name="hTheme">
		/// <para>Type: <c>HTHEME</c></para>
		/// <para>Handle to a window's specified theme data. Use <c>OpenThemeData</c> to create an HTHEME.</para>
		/// </param>
		/// <param name="iPartId">
		/// <para>Type: <c>int</c></para>
		/// <para>Value of type <c>int</c> that specifies the part that contains the color property. See Parts and States.</para>
		/// </param>
		/// <param name="iStateId">
		/// <para>Type: <c>int</c></para>
		/// <para>Value of type <c>int</c> that specifies the state of the part. See Parts and States.</para>
		/// </param>
		/// <param name="iPropId">
		/// <para>Type: <c>int</c></para>
		/// <para>Value of type <c>int</c> that specifies the property to retrieve. For a list of possible values, see Property Identifiers.</para>
		/// </param>
		/// <param name="pColor">
		/// <para>Type: <c><c>COLORREF</c>*</c></para>
		/// <para>Pointer to a <c>COLORREF</c> structure that receives the color value.</para>
		/// </param>
		/// <returns>
		/// <para>Type: <c><c>HRESULT</c></c></para>
		/// <para>If this function succeeds, it returns <c>S_OK</c>. Otherwise, it returns an <c>HRESULT</c> error code.</para>
		/// </returns>
		// HRESULT GetThemeColor( _In_ HTHEME hTheme, _In_ int iPartId, _In_ int iStateId, _In_ int iPropId, _Out_ COLORREF *pColor); https://msdn.microsoft.com/en-us/library/windows/desktop/bb773397(v=vs.85).aspx
		[DllImport(Lib.UxTheme, SetLastError = false, ExactSpelling = true)]
		[PInvokeData("Uxtheme.h", MSDNShortId = "bb773397")]
		public static extern HRESULT GetThemeColor(HTHEME hTheme, int iPartId, int iStateId, int iPropId, out COLORREF pColor);

		/// <summary>Retrieves the value for a theme property from the documentation section of the specified theme file.</summary>
		/// <param name="pszThemeName">
		/// <para>Type: <c><c>LPCWSTR</c></c></para>
		/// <para>Pointer to a string that contains the name of the theme file that will be opened to query for the property.</para>
		/// </param>
		/// <param name="pszPropertyName">
		/// <para>Type: <c><c>LPCWSTR</c></c></para>
		/// <para>Pointer to a string that contains the name of the theme property to query. Can be one of the following values.</para>
		/// <para>
		/// <list type="table">
		/// <listheader>
		/// <term>Value</term>
		/// <term>Meaning</term>
		/// </listheader>
		/// <item>
		/// <term>SZ_THDOCPROP_DISPLAYNAME</term>
		/// <term>Retrieves the display name of the theme.</term>
		/// </item>
		/// <item>
		/// <term>SZ_THDOCPROP_TOOLTIP</term>
		/// <term>Retrieves the tooltip associated with this theme.</term>
		/// </item>
		/// <item>
		/// <term>SZ_THDOCPROP_AUTHOR</term>
		/// <term>Retrieves the name of the author of the theme.</term>
		/// </item>
		/// <item>
		/// <term>SZ_THDOCPROP_CANONICALNAME</term>
		/// <term>Retrieves the name of the theme.</term>
		/// </item>
		/// </list>
		/// </para>
		/// </param>
		/// <param name="pszValueBuff">
		/// <para>Type: <c><c>LPWSTR</c></c></para>
		/// <para>Pointer to a string buffer that receives the property string value.</para>
		/// </param>
		/// <param name="cchMaxValChars">
		/// <para>Type: <c>int</c></para>
		/// <para>Value of type <c>int</c> that specifies the maximum number of characters that pszValueBuff can contain.</para>
		/// </param>
		/// <returns>
		/// <para>Type: <c><c>HRESULT</c></c></para>
		/// <para>If this function succeeds, it returns <c>S_OK</c>. Otherwise, it returns an <c>HRESULT</c> error code.</para>
		/// </returns>
		// HRESULT GetThemeDocumentationProperty( _In_ LPCWSTR pszThemeName, _In_ LPCWSTR pszPropertyName, _Out_ LPWSTR pszValueBuff, _In_
		// int cchMaxValChars); https://msdn.microsoft.com/en-us/library/windows/desktop/bb773402(v=vs.85).aspx
		[DllImport(Lib.UxTheme, SetLastError = false, ExactSpelling = true, CharSet = CharSet.Unicode)]
		[PInvokeData("Uxtheme.h", MSDNShortId = "bb773402")]
		public static extern HRESULT GetThemeDocumentationProperty(string pszThemeName, string pszPropertyName, StringBuilder pszValueBuff, int cchMaxValChars);

		/// <summary>Retrieves the value of an enumerated type property.</summary>
		/// <param name="hTheme">
		/// <para>Type: <c>HTHEME</c></para>
		/// <para>Handle to a window's specified theme data. Use <c>OpenThemeData</c> to create an HTHEME.</para>
		/// </param>
		/// <param name="iPartId">
		/// <para>Type: <c>int</c></para>
		/// <para>Value of type <c>int</c> that specifies the part that contains the enumerated type property. See Parts and States.</para>
		/// </param>
		/// <param name="iStateId">
		/// <para>Type: <c>int</c></para>
		/// <para>Value of type <c>int</c> that specifies the state of the part. See Parts and States.</para>
		/// </param>
		/// <param name="iPropId">
		/// <para>Type: <c>int</c></para>
		/// <para>Value of type <c>int</c> that specifies the property to retrieve. For a list of possible values, see Property Identifiers.</para>
		/// </param>
		/// <param name="piVal">
		/// <para>Type: <c>int*</c></para>
		/// <para>Pointer to an <c>int</c> that receives the enumerated type value.</para>
		/// </param>
		/// <returns>
		/// <para>Type: <c><c>HRESULT</c></c></para>
		/// <para>If this function succeeds, it returns <c>S_OK</c>. Otherwise, it returns an <c>HRESULT</c> error code.</para>
		/// </returns>
		// HRESULT GetThemeEnumValue( _In_ HTHEME hTheme, _In_ int iPartId, _In_ int iStateId, _In_ int iPropId, _Out_ int *piVal); https://msdn.microsoft.com/en-us/library/windows/desktop/bb773406(v=vs.85).aspx
		[DllImport(Lib.UxTheme, SetLastError = false, ExactSpelling = true)]
		[PInvokeData("Uxtheme.h", MSDNShortId = "bb773406")]
		public static extern HRESULT GetThemeEnumValue(HTHEME hTheme, int iPartId, int iStateId, int iPropId, out int piVal);

		/// <summary>Retrieves the value of a filename property.</summary>
		/// <param name="hTheme">
		/// <para>Type: <c>HTHEME</c></para>
		/// <para>Handle to a window's specified theme data. Use <c>OpenThemeData</c> to create an HTHEME.</para>
		/// </param>
		/// <param name="iPartId">
		/// <para>Type: <c>int</c></para>
		/// <para>Value of type <c>int</c> that specifies the part that contains the filename property. See Parts and States.</para>
		/// </param>
		/// <param name="iStateId">
		/// <para>Type: <c>int</c></para>
		/// <para>Value of type <c>int</c> that specifies the state of the part. See Parts and States.</para>
		/// </param>
		/// <param name="iPropId">
		/// <para>Type: <c>int</c></para>
		/// <para>Value of type <c>int</c> that specifies the property to retrieve. For a list of possible values, see Property Identifiers.</para>
		/// </param>
		/// <param name="pszThemeFilename">
		/// <para>Type: <c><c>LPWSTR</c></c></para>
		/// <para>Pointer to a buffer that receives the retrieved file name.</para>
		/// </param>
		/// <param name="cchMaxBuffChars">
		/// <para>Type: <c>int</c></para>
		/// <para>Value of type <c>int</c> that receives the maximum number of characters in the file name</para>
		/// </param>
		/// <returns>
		/// <para>Type: <c><c>HRESULT</c></c></para>
		/// <para>If this function succeeds, it returns <c>S_OK</c>. Otherwise, it returns an <c>HRESULT</c> error code.</para>
		/// </returns>
		// HRESULT GetThemeFilename( _In_ HTHEME hTheme, _In_ int iPartId, _In_ int iStateId, _In_ int iPropId, _Out_ LPWSTR
		// pszThemeFilename, _In_ int cchMaxBuffChars); https://msdn.microsoft.com/en-us/library/windows/desktop/bb759743(v=vs.85).aspx
		[DllImport(Lib.UxTheme, SetLastError = false, ExactSpelling = true, CharSet = CharSet.Unicode)]
		[PInvokeData("Uxtheme.h", MSDNShortId = "bb759743")]
		public static extern HRESULT GetThemeFilename(HTHEME hTheme, int iPartId, int iStateId, int iPropId, StringBuilder pszThemeFilename, int cchMaxBuffChars);

		/// <summary>Retrieves the value of an <c>int</c> property.</summary>
		/// <param name="hTheme">
		/// <para>Type: <c>HTHEME</c></para>
		/// <para>Handle to a window's specified theme data. Use <c>OpenThemeData</c> to create an HTHEME.</para>
		/// </param>
		/// <param name="iPartId">
		/// <para>Type: <c>int</c></para>
		/// <para>Value of type <c>int</c> that specifies the part that contains the <c>int</c> property. See Parts and States.</para>
		/// </param>
		/// <param name="iStateId">
		/// <para>Type: <c>int</c></para>
		/// <para>Value of type <c>int</c> that specifies the state of the part. See Parts and States.</para>
		/// </param>
		/// <param name="iPropId">
		/// <para>Type: <c>int</c></para>
		/// <para>Value of type <c>int</c> that specifies the property to retrieve. For a list of possible values, see Property Identifiers.</para>
		/// </param>
		/// <param name="piVal">
		/// <para>Type: <c>int*</c></para>
		/// <para>Pointer to an <c>int</c> that receives the retrieved value.</para>
		/// </param>
		/// <returns>
		/// <para>Type: <c><c>HRESULT</c></c></para>
		/// <para>If this function succeeds, it returns <c>S_OK</c>. Otherwise, it returns an <c>HRESULT</c> error code.</para>
		/// </returns>
		// HRESULT GetThemeInt( _In_ HTHEME hTheme, _In_ int iPartId, _In_ int iStateId, _In_ int iPropId, _Out_ int *piVal); https://msdn.microsoft.com/en-us/library/windows/desktop/bb759749(v=vs.85).aspx
		[DllImport(Lib.UxTheme, SetLastError = false, ExactSpelling = true)]
		[PInvokeData("Uxtheme.h", MSDNShortId = "bb759749")]
		public static extern HRESULT GetThemeInt(HTHEME hTheme, int iPartId, int iStateId, int iPropId, out int piVal);

		/// <summary>Retrieves a list of <c>int</c> data from a visual style.</summary>
		/// <param name="hTheme">
		/// <para>Type: <c>HTHEME</c></para>
		/// <para>Handle to a window's specified theme data. Use <c>OpenThemeData</c> to create an HTHEME.</para>
		/// </param>
		/// <param name="partId">
		/// <para>Type: <c>int</c></para>
		/// <para>Value of type <c>int</c> that specifies the part that contains the list of data to return. See Parts and States.</para>
		/// </param>
		/// <param name="stateId">
		/// <para>Type: <c>int</c></para>
		/// <para>Value of type <c>int</c> that specifies the state of the part. See Parts and States.</para>
		/// </param>
		/// <param name="propId">
		/// <para>Type: <c>int</c></para>
		/// <para>Value of type <c>int</c> that specifies the property to retrieve. See Property Identifiers.</para>
		/// </param>
		/// <returns>An array of integers.</returns>
		public static int[] GetThemeIntList(HTHEME hTheme, int partId, int stateId, int propId)
		{
			if (Environment.OSVersion.Version.Major < 6)
			{
				if (0 != GetThemeIntListPreVista(hTheme, partId, stateId, propId, out var l))
					return null;
				var outlist = new int[l.iValueCount];
				Array.Copy(l.iValues, outlist, l.iValueCount);
				return outlist;
			}
			else
			{
				if (0 != GetThemeIntList(hTheme, partId, stateId, propId, out var l))
					return null;
				var outlist = new int[l.iValueCount];
				Array.Copy(l.iValues, outlist, l.iValueCount);
				return outlist;
			}
		}

		/// <summary>Retrieves a list of <c>int</c> data from a visual style.</summary>
		/// <param name="hTheme">
		/// <para>Type: <c>HTHEME</c></para>
		/// <para>Handle to a window's specified theme data. Use <c>OpenThemeData</c> to create an HTHEME.</para>
		/// </param>
		/// <param name="iPartId">
		/// <para>Type: <c>int</c></para>
		/// <para>Value of type <c>int</c> that specifies the part that contains the list of data to return. See Parts and States.</para>
		/// </param>
		/// <param name="iStateId">
		/// <para>Type: <c>int</c></para>
		/// <para>Value of type <c>int</c> that specifies the state of the part. See Parts and States.</para>
		/// </param>
		/// <param name="iPropId">
		/// <para>Type: <c>int</c></para>
		/// <para>Value of type <c>int</c> that specifies the property to retrieve. See Property Identifiers.</para>
		/// </param>
		/// <param name="pIntList">
		/// <para>Type: <c><c>INTLIST</c>*</c></para>
		/// <para>Pointer to an <c>INTLIST</c> structure that receives the <c>int</c> data.</para>
		/// </param>
		/// <returns>
		/// <para>Type: <c><c>HRESULT</c></c></para>
		/// <para>Returns S_OK if successful, otherwise an error code.</para>
		/// </returns>
		// HRESULT GetThemeIntList( _In_ HTHEME hTheme, _In_ int iPartId, _In_ int iStateId, _In_ int iPropId, _Out_ INTLIST *pIntList); https://msdn.microsoft.com/en-us/library/windows/desktop/bb759752(v=vs.85).aspx
		[DllImport(Lib.UxTheme, SetLastError = false, ExactSpelling = true)]
		[PInvokeData("UxTheme.h", MSDNShortId = "bb759752", MinClient = PInvokeClient.WindowsVista)]
		public static extern HRESULT GetThemeIntList(HTHEME hTheme, int iPartId, int iStateId, int iPropId, out INTLIST pIntList);

		/// <summary>Retrieves the value of a <c>MARGINS</c> property.</summary>
		/// <param name="hTheme">
		/// <para>Type: <c>HTHEME</c></para>
		/// <para>Handle to a window's specified theme data. Use <c>OpenThemeData</c> to create an HTHEME.</para>
		/// </param>
		/// <param name="hdc">
		/// <para>Type: <c><c>HDC</c></c></para>
		/// <para>HDC to select fonts into. This parameter may be set to <c>NULL</c>.</para>
		/// </param>
		/// <param name="iPartId">
		/// <para>Type: <c>int</c></para>
		/// <para>Value of type <c>int</c> that specifies the part that contains the <c>MARGINS</c> property. See Parts and States.</para>
		/// </param>
		/// <param name="iStateId">
		/// <para>Type: <c>int</c></para>
		/// <para>Value of type <c>int</c> that specifies the state of the part. See Parts and States.</para>
		/// </param>
		/// <param name="iPropId">
		/// <para>Type: <c>int</c></para>
		/// <para>Value of type <c>int</c> that specifies the property to retrieve. For a list of possible values, see Property Identifiers.</para>
		/// </param>
		/// <param name="prc">
		/// <para>Type: <c>LPRECT</c></para>
		/// <para>
		/// Pointer to a <c>RECT</c> structure that contains the rectangle that specifies the area to be drawn into. This parameter may be
		/// set to <c>NULL</c>.
		/// </para>
		/// </param>
		/// <param name="pMargins">
		/// <para>Type: <c><c>MARGINS</c>*</c></para>
		/// <para>Pointer to a <c>MARGINS</c> structure that receives the retrieved value.</para>
		/// </param>
		/// <returns>
		/// <para>Type: <c><c>HRESULT</c></c></para>
		/// <para>If this function succeeds, it returns <c>S_OK</c>. Otherwise, it returns an <c>HRESULT</c> error code.</para>
		/// </returns>
		// HRESULT GetThemeMargins( _In_ HTHEME hTheme, _In_ HDC hdc, _In_ int iPartId, _In_ int iStateId, _In_ int iPropId, _In_ LPRECT prc,
		// _Out_ MARGINS
		// *pMargins); https://msdn.microsoft.com/en-us/library/windows/desktop/bb759755(v=vs.85).aspx
		[DllImport(Lib.UxTheme, SetLastError = false, ExactSpelling = true)]
		[PInvokeData("Uxtheme.h", MSDNShortId = "bb759755")]
		public static extern HRESULT GetThemeMargins(HTHEME hTheme, HDC hdc, int iPartId, int iStateId, int iPropId, PRECT prc, out MARGINS pMargins);

		/// <summary>Retrieves the value of a metric property.</summary>
		/// <param name="hTheme">
		/// <para>Type: <c>HTHEME</c></para>
		/// <para>Handle to a window's specified theme data. Use <c>OpenThemeData</c> to create an HTHEME.</para>
		/// </param>
		/// <param name="hdc">
		/// <para>Type: <c><c>HDC</c></c></para>
		/// <para>HDC. This parameter may be set to <c>NULL</c>.</para>
		/// </param>
		/// <param name="iPartId">
		/// <para>Type: <c>int</c></para>
		/// <para>Value of type <c>int</c> that specifies the part that contains the metric property. See Parts and States.</para>
		/// </param>
		/// <param name="iStateId">
		/// <para>Type: <c>int</c></para>
		/// <para>Value of type <c>int</c> that specifies the state of the part. See Parts and States.</para>
		/// </param>
		/// <param name="iPropId">
		/// <para>Type: <c>int</c></para>
		/// <para>Value of type <c>int</c> that specifies the property to retrieve. Can be one of the following values.</para>
		/// <para>
		/// <list type="table">
		/// <listheader>
		/// <term>Value</term>
		/// <term>Meaning</term>
		/// </listheader>
		/// <item>
		/// <term>TMT_ALPHALEVEL</term>
		/// <term>The alpha value (0-255) used for DrawThemeIcon.</term>
		/// </item>
		/// <item>
		/// <term>TMT_ALPHATHRESHOLD</term>
		/// <term>The minimum alpha value (0-255) that a pixel must be to be considered opaque.</term>
		/// </item>
		/// <item>
		/// <term>TMT_BORDERSIZE</term>
		/// <term>The thickness of the border drawn if this part uses a border fill.</term>
		/// </item>
		/// <item>
		/// <term>TMT_GLYPHINDEX</term>
		/// <term>The character index into the selected font that will be used for the glyph, if the part uses a font-based glyph.</term>
		/// </item>
		/// <item>
		/// <term>TMT_GRADIENTRATIO1</term>
		/// <term>
		/// The amount of the first gradient color to use in drawing the part. This value can be from 0 to 255, but this value plus the
		/// values of each of the GRADIENTRATIO values must add up to 255. See the TMT_GRADIENTCOLOR1 value of GetThemeColor.
		/// </term>
		/// </item>
		/// <item>
		/// <term>TMT_GRADIENTRATIO2</term>
		/// <term>The amount of the second gradient color to use in drawing the part.</term>
		/// </item>
		/// <item>
		/// <term>TMT_GRADIENTRATIO3</term>
		/// <term>The amount of the third gradient color to use in drawing the part.</term>
		/// </item>
		/// <item>
		/// <term>TMT_GRADIENTRATIO4</term>
		/// <term>The amount of the fourth gradient color to use in drawing the part.</term>
		/// </item>
		/// <item>
		/// <term>TMT_GRADIENTRATIO5</term>
		/// <term>The amount of the fifth gradient color to use in drawing the part.</term>
		/// </item>
		/// <item>
		/// <term>TMT_HEIGHT</term>
		/// <term>The height of the part.</term>
		/// </item>
		/// <item>
		/// <term>TMT_IMAGECOUNT</term>
		/// <term>The number of state images present in an image file.</term>
		/// </item>
		/// <item>
		/// <term>TMT_MINDPI1</term>
		/// <term>The minimum dpi that the first image file was designed for. See GetThemeFilename.</term>
		/// </item>
		/// <item>
		/// <term>TMT_MINDPI2</term>
		/// <term>The minimum dpi that the second image file was designed for.</term>
		/// </item>
		/// <item>
		/// <term>TMT_MINDPI3</term>
		/// <term>The minimum dpi that the third image file was designed for.</term>
		/// </item>
		/// <item>
		/// <term>TMT_MINDPI4</term>
		/// <term>The minimum dpi that the fourth image file was designed for.</term>
		/// </item>
		/// <item>
		/// <term>TMT_MINDPI5</term>
		/// <term>The minimum dpi that the fifth image file was designed for.</term>
		/// </item>
		/// <item>
		/// <term>TMT_PROGRESSCHUNKSIZE</term>
		/// <term>The size of the progress control &amp;quot;chunk&amp;quot; shapes that define how far an operation has progressed.</term>
		/// </item>
		/// <item>
		/// <term>TMT_PROGRESSSPACESIZE</term>
		/// <term>The total size of all of the progress control &amp;quot;chunks&amp;quot;.</term>
		/// </item>
		/// <item>
		/// <term>TMT_ROUNDCORNERWIDTH</term>
		/// <term>The roundness (0-100%) of the part's corners.</term>
		/// </item>
		/// <item>
		/// <term>TMT_ROUNDCORNERHEIGHT</term>
		/// <term>The roundness (0-100%) of the part's corners.</term>
		/// </item>
		/// <item>
		/// <term>TMT_SATURATION</term>
		/// <term>The amount of saturation (0-255) to apply to an icon drawn using DrawThemeIcon.</term>
		/// </item>
		/// <item>
		/// <term>TMT_TEXTBORDERSIZE</term>
		/// <term>The thickness of the border drawn around text characters.</term>
		/// </item>
		/// <item>
		/// <term>TMT_TRUESIZESTRETCHMARK</term>
		/// <term>The percentage of a true-size image's original size at which the image will be stretched.</term>
		/// </item>
		/// <item>
		/// <term>TMT_WIDTH</term>
		/// <term>The width of the part.</term>
		/// </item>
		/// </list>
		/// </para>
		/// </param>
		/// <param name="piVal">
		/// <para>Type: <c>int*</c></para>
		/// <para>Pointer to an <c>int</c> that receives the metric property value.</para>
		/// </param>
		/// <returns>
		/// <para>Type: <c><c>HRESULT</c></c></para>
		/// <para>If this function succeeds, it returns <c>S_OK</c>. Otherwise, it returns an <c>HRESULT</c> error code.</para>
		/// </returns>
		// HRESULT GetThemeMetric( _In_ HTHEME hTheme, _In_ HDC hdc, _In_ int iPartId, _In_ int iStateId, _In_ int iPropId, _Out_ int
		// *piVal); https://msdn.microsoft.com/en-us/library/windows/desktop/bb759757(v=vs.85).aspx
		[DllImport(Lib.UxTheme, SetLastError = false, ExactSpelling = true)]
		[PInvokeData("Uxtheme.h", MSDNShortId = "bb759757")]
		public static extern HRESULT GetThemeMetric(HTHEME hTheme, HDC hdc, int iPartId, int iStateId, int iPropId, out int piVal);

		/// <summary>Calculates the original size of the part defined by a visual style.</summary>
		/// <param name="hTheme">
		/// <para>Type: <c>HTHEME</c></para>
		/// <para>Handle to a window's specified theme data. Use <c>OpenThemeData</c> to create an HTHEME.</para>
		/// </param>
		/// <param name="hdc">
		/// <para>Type: <c><c>HDC</c></c></para>
		/// <para>HDC to select fonts into.</para>
		/// </param>
		/// <param name="iPartId">
		/// <para>Type: <c>int</c></para>
		/// <para>Value of type <c>int</c> that specifies the part to calculate the size of. See Parts and States.</para>
		/// </param>
		/// <param name="iStateId">
		/// <para>Type: <c>int</c></para>
		/// <para>Value of type <c>int</c> that specifies the state of the part. See Parts and States.</para>
		/// </param>
		/// <param name="prc">
		/// <para>Type: <c>LPCRECT</c></para>
		/// <para>
		/// Pointer to a <c>RECT</c> structure that contains the rectangle used for the part drawing destination. This parameter may be set
		/// to <c>NULL</c>.
		/// </para>
		/// </param>
		/// <param name="eSize">
		/// <para>Type: <c>THEMESIZE</c></para>
		/// <para>Enumerated type that specifies the type of size to retrieve. See <c>THEMESIZE</c> for a list of type values.</para>
		/// </param>
		/// <param name="psz">
		/// <para>Type: <c><c>SIZE</c>*</c></para>
		/// <para>Pointer to a <c>SIZE</c> structure that receives the dimensions of the specified part.</para>
		/// </param>
		/// <returns>
		/// <para>Type: <c><c>HRESULT</c></c></para>
		/// <para>If this function succeeds, it returns <c>S_OK</c>. Otherwise, it returns an <c>HRESULT</c> error code.</para>
		/// </returns>
		// HRESULT GetThemePartSize( _In_ HTHEME hTheme, _In_ HDC hdc, _In_ int iPartId, _In_ int iStateId, _In_ LPCRECT prc, _In_ THEMESIZE
		// eSize, _Out_ SIZE
		// *psz); https://msdn.microsoft.com/en-us/library/windows/desktop/bb759759(v=vs.85).aspx
		[DllImport(Lib.UxTheme, SetLastError = false, ExactSpelling = true)]
		[PInvokeData("Uxtheme.h", MSDNShortId = "bb759759")]
		public static extern HRESULT GetThemePartSize(HTHEME hTheme, HDC hdc, int iPartId, int iStateId, PRECT prc, THEMESIZE eSize, out SIZE psz);

		/// <summary>Retrieves the value of a position property.</summary>
		/// <param name="hTheme">
		/// <para>Type: <c>HTHEME</c></para>
		/// <para>Handle to a window's specified theme data. Use <c>OpenThemeData</c> to create an HTHEME.</para>
		/// </param>
		/// <param name="iPartId">
		/// <para>Type: <c>int</c></para>
		/// <para>Value of type <c>int</c> that specifies the part that contains the position property. See Parts and States.</para>
		/// </param>
		/// <param name="iStateId">
		/// <para>Type: <c>int</c></para>
		/// <para>Value of type <c>int</c> that specifies the state of the part. See Parts and States.</para>
		/// </param>
		/// <param name="iPropId">
		/// <para>Type: <c>int</c></para>
		/// <para>Value of type <c>int</c> that specifies the property to retrieve. For a list of possible values, see Property Identifiers.</para>
		/// </param>
		/// <param name="pPoint">
		/// <para>Type: <c><c>POINT</c>*</c></para>
		/// <para>Pointer to a <c>POINT</c> structure that receives the position value.</para>
		/// </param>
		/// <returns>
		/// <para>Type: <c><c>HRESULT</c></c></para>
		/// <para>If this function succeeds, it returns <c>S_OK</c>. Otherwise, it returns an <c>HRESULT</c> error code.</para>
		/// </returns>
		// HRESULT GetThemePosition( _In_ HTHEME hTheme, _In_ int iPartId, _In_ int iStateId, _In_ int iPropId, _Out_ POINT *pPoint); https://msdn.microsoft.com/en-us/library/windows/desktop/bb759762(v=vs.85).aspx
		[DllImport(Lib.UxTheme, SetLastError = false, ExactSpelling = true)]
		[PInvokeData("Uxtheme.h", MSDNShortId = "bb759762")]
		public static extern HRESULT GetThemePosition(HTHEME hTheme, int iPartId, int iStateId, int iPropId, out POINT pPoint);

		/// <summary>Retrieves the location of the theme property definition for a property.</summary>
		/// <param name="hTheme">Handle to a window's specified theme data. Use OpenThemeData to create an HTHEME.</param>
		/// <param name="iPartId">Value of type int that specifies the part that contains the theme. See Parts and States.</param>
		/// <param name="iStateId">Value of type int that specifies the state of the part. See Parts and States.</param>
		/// <param name="iPropId">
		/// Value of type int that specifies the property to retrieve. You may use any of the property values from Vssym32.h. These values
		/// are described in the reference pages for the functions that use them. For instance, the GetThemeInt function uses the
		/// TMT_BORDERSIZE value. See the Visual Styles Reference for a list of functions.
		/// </param>
		/// <param name="pOrigin">Pointer to a PROPERTYORIGIN enumerated type that indicates where the property was or was not found.</param>
		/// <returns>
		/// <para>Type: <c><c>HRESULT</c></c></para>
		/// <para>If this function succeeds, it returns <c>S_OK</c>. Otherwise, it returns an <c>HRESULT</c> error code.</para>
		/// </returns>
		[DllImport(Lib.UxTheme, SetLastError = false, ExactSpelling = true)]
		[PInvokeData("Uxtheme.h", MSDNShortId = "bb759764")]
		public static extern HRESULT GetThemePropertyOrigin(HTHEME hTheme, int iPartId, int iStateId, int iPropId, out PROPERTYORIGIN pOrigin);

		/// <summary>Retrieves the value of a <c>RECT</c> property.</summary>
		/// <param name="hTheme">
		/// <para>Type: <c>HTHEME</c></para>
		/// <para>Handle to a window's specified theme data. Use <c>OpenThemeData</c> to create an HTHEME.</para>
		/// </param>
		/// <param name="iPartId">
		/// <para>Type: <c>int</c></para>
		/// <para>Value of type <c>int</c> that specifies the part containing the <c>RECT</c> property. See Parts and States.</para>
		/// </param>
		/// <param name="iStateId">
		/// <para>Type: <c>int</c></para>
		/// <para>Value of type <c>int</c> that specifies the state of the part. See Parts and States.</para>
		/// </param>
		/// <param name="iPropId">
		/// <para>Type: <c>int</c></para>
		/// <para>Value of type <c>int</c> that specifies the property to retrieve. For a list of possible values, see Property Identifiers.</para>
		/// </param>
		/// <param name="pRect">
		/// <para>Type: <c>LPRECT</c></para>
		/// <para>Pointer to a <c>RECT</c> structure that receives a rectangle.</para>
		/// </param>
		/// <returns>
		/// <para>Type: <c><c>HRESULT</c></c></para>
		/// <para>If this function succeeds, it returns <c>S_OK</c>. Otherwise, it returns an <c>HRESULT</c> error code.</para>
		/// </returns>
		// HRESULT GetThemeRect( _In_ HTHEME hTheme, _In_ int iPartId, _In_ int iStateId, _In_ int iPropId, _Out_ LPRECT pRect); https://msdn.microsoft.com/en-us/library/windows/desktop/bb759766(v=vs.85).aspx
		[DllImport(Lib.UxTheme, SetLastError = false, ExactSpelling = true)]
		[PInvokeData("Uxtheme.h", MSDNShortId = "bb759766")]
		public static extern HRESULT GetThemeRect(HTHEME hTheme, int iPartId, int iStateId, int iPropId, out RECT pRect);

		/// <summary>Retrieves a data stream corresponding to a specified theme, starting from a specified part, state, and property.</summary>
		/// <param name="hTheme">
		/// <para>Type: <c>HTHEME</c></para>
		/// <para>Handle to the theme from which the stream will be retrieved.</para>
		/// </param>
		/// <param name="iPartId">
		/// <para>Type: <c>int</c></para>
		/// <para>Specifies the part to retrieve a stream from. See Parts and States.</para>
		/// </param>
		/// <param name="iStateId">
		/// <para>Type: <c>int</c></para>
		/// <para>Specifies the state of the part.</para>
		/// </param>
		/// <param name="iPropId">
		/// <para>Type: <c>int</c></para>
		/// <para>Specifies the property to retrieve.</para>
		/// </param>
		/// <param name="ppvStream">
		/// <para>Type: <c><c>VOID</c>**</c></para>
		/// <para>Address of a pointer that receives the stream.</para>
		/// </param>
		/// <param name="pcbStream">
		/// <para>Type: <c><c>DWORD</c>*</c></para>
		/// <para>Pointer that receives the length, in bytes, of the stream received by ppvStream.</para>
		/// </param>
		/// <param name="hInst">
		/// <para>Type: <c><c>HINSTANCE</c></c></para>
		/// <para>
		/// If iPropId is TMT_STREAM, this value is <c>NULL</c>. If iPropId is TMT_DISKSTREAM, this value is the HINSTANCE of a loaded styles file.
		/// </para>
		/// </param>
		/// <returns>
		/// <para>Type: <c><c>HRESULT</c></c></para>
		/// <para>If this function succeeds, it returns <c>S_OK</c>. Otherwise, it returns an <c>HRESULT</c> error code.</para>
		/// </returns>
		// HRESULT GetThemeStream( _In_ HTHEME hTheme, _In_ int iPartId, _In_ int iStateId, _In_ int iPropId, _Out_ VOID **ppvStream, _Out_
		// DWORD *pcbStream, _In_ HINSTANCE hInst); https://msdn.microsoft.com/en-us/library/windows/desktop/bb759768(v=vs.85).aspx
		[DllImport(Lib.UxTheme, SetLastError = false, ExactSpelling = true)]
		[PInvokeData("Uxtheme.h", MSDNShortId = "bb759768")]
		public static extern HRESULT GetThemeStream(HTHEME hTheme, int iPartId, int iStateId, int iPropId, out IntPtr ppvStream, out uint pcbStream, HINSTANCE hInst);

		/// <summary>Retrieves the value of a string property.</summary>
		/// <param name="hTheme">
		/// <para>Type: <c>HTHEME</c></para>
		/// <para>Handle to a window's specified theme data. Use <c>OpenThemeData</c> to create an HTHEME.</para>
		/// </param>
		/// <param name="iPartId">
		/// <para>Type: <c>int</c></para>
		/// <para>Value of type <c>int</c> that specifies the part containing the string property. See Parts and States.</para>
		/// </param>
		/// <param name="iStateId">
		/// <para>Type: <c>int</c></para>
		/// <para>Value of type <c>int</c> that specifies the state of the part. See Parts and States.</para>
		/// </param>
		/// <param name="iPropId">
		/// <para>Type: <c>int</c></para>
		/// <para>Value of type <c>int</c> that specifies the property to retrieve. For a list of possible values, see Property Identifiers.</para>
		/// </param>
		/// <param name="pszBuff">
		/// <para>Type: <c><c>LPWSTR</c></c></para>
		/// <para>Pointer to a buffer that receives the string value.</para>
		/// </param>
		/// <param name="cchMaxBuffChars">
		/// <para>Type: <c>int</c></para>
		/// <para>Value of type <c>int</c> that specifies the maximum number of characters pszBuff can contain.</para>
		/// </param>
		/// <returns>
		/// <para>Type: <c><c>HRESULT</c></c></para>
		/// <para>If this function succeeds, it returns <c>S_OK</c>. Otherwise, it returns an <c>HRESULT</c> error code.</para>
		/// </returns>
		// HRESULT GetThemeString( _In_ HTHEME hTheme, _In_ int iPartId, _In_ int iStateId, _In_ int iPropId, _Out_ LPWSTR pszBuff, _In_ int
		// cchMaxBuffChars); https://msdn.microsoft.com/en-us/library/windows/desktop/bb759770(v=vs.85).aspx
		[DllImport(Lib.UxTheme, SetLastError = false, ExactSpelling = true)]
		[PInvokeData("Uxtheme.h", MSDNShortId = "bb759770")]
		public static extern HRESULT GetThemeString(HTHEME hTheme, int iPartId, int iStateId, int iPropId, [MarshalAs(UnmanagedType.LPWStr)] StringBuilder pszBuff, int cchMaxBuffChars);

		/// <summary>Retrieves the Boolean value of a system metric.</summary>
		/// <param name="hTheme">
		/// <para>Type: <c>HTHEME</c></para>
		/// <para>Handle to theme data.</para>
		/// </param>
		/// <param name="iBoolID">
		/// <para>Type: <c>int</c></para>
		/// <para>Value of type <c>int</c> that specifies the system Boolean metric desired. May be the following value.</para>
		/// <para>
		/// <list type="table">
		/// <listheader>
		/// <term>Value</term>
		/// <term>Meaning</term>
		/// </listheader>
		/// <item>
		/// <term>TMT_FLATMENUS</term>
		/// <term>Describes how menus are drawn. If TRUE, menus are drawn without shadows. If FALSE, menus have shadows underneath them.</term>
		/// </item>
		/// </list>
		/// </para>
		/// </param>
		/// <returns>
		/// <para>Type: <c><c>BOOL</c></c></para>
		/// <para>Value of desired system metric.</para>
		/// </returns>
		// BOOL GetThemeSysBool( _In_ HTHEME hTheme, _In_ int iBoolID); https://msdn.microsoft.com/en-us/library/windows/desktop/bb759773(v=vs.85).aspx
		[DllImport(Lib.UxTheme, SetLastError = false, ExactSpelling = true)]
		[PInvokeData("Uxtheme.h", MSDNShortId = "bb759773")]
		[return: MarshalAs(UnmanagedType.Bool)]
		public static extern bool GetThemeSysBool(HTHEME hTheme, int iBoolID);

		/// <summary>Retrieves the value of a system color.</summary>
		/// <param name="hTheme">
		/// <para>Type: <c>HTHEME</c></para>
		/// <para>Handle to theme data.</para>
		/// </param>
		/// <param name="iColorID">
		/// <para>Type: <c>int</c></para>
		/// <para>
		/// Value of type <c>int</c> that specifies the color number. May be one of the values listed in <c>GetSysColor</c> for the nIndex parameter.
		/// </para>
		/// </param>
		/// <returns>
		/// <para>Type: <c><c>COLORREF</c></c></para>
		/// <para>The value of the specified system color.</para>
		/// </returns>
		// COLORREF GetThemeSysColor( _In_ HTHEME hTheme, _In_ int iColorID); https://msdn.microsoft.com/en-us/library/windows/desktop/bb759776(v=vs.85).aspx
		[DllImport(Lib.UxTheme, SetLastError = false, ExactSpelling = true)]
		[PInvokeData("Uxtheme.h", MSDNShortId = "bb759776")]
		public static extern COLORREF GetThemeSysColor(HTHEME hTheme, SystemColorIndex iColorID);

		/// <summary>Retrieves a system color brush.</summary>
		/// <param name="hTheme">
		/// <para>Type: <c>HTHEME</c></para>
		/// <para>Handle to theme data.</para>
		/// </param>
		/// <param name="iColorID">
		/// <para>Type: <c>int</c></para>
		/// <para>Value of type <c>int</c> that specifies the number of the desired system color. May be one of the following values.</para>
		/// <para>
		/// <list type="table">
		/// <listheader>
		/// <term>Value</term>
		/// <term>Meaning</term>
		/// </listheader>
		/// <item>
		/// <term>TMT_SCROLLBAR</term>
		/// <term>The color of scroll bars.</term>
		/// </item>
		/// <item>
		/// <term>TMT_BACKGROUND</term>
		/// <term>The color of the background.</term>
		/// </item>
		/// <item>
		/// <term>TMT_ACTIVECAPTION</term>
		/// <term>The color of the caption area on an active window.</term>
		/// </item>
		/// <item>
		/// <term>TMT_INACTIVECAPTION</term>
		/// <term>The color of the caption area on an inactive window.</term>
		/// </item>
		/// <item>
		/// <term>TMT_WINDOW</term>
		/// <term>The color of a window.</term>
		/// </item>
		/// <item>
		/// <term>TMT_WINDOWFRAME</term>
		/// <term>The color of the frame around a window.</term>
		/// </item>
		/// <item>
		/// <term>TMT_MENUTEXT</term>
		/// <term>The color of text drawn on a menu.</term>
		/// </item>
		/// <item>
		/// <term>TMT_WINDOWTEXT</term>
		/// <term>The color of text drawn in a window.</term>
		/// </item>
		/// <item>
		/// <term>TMT_CAPTIONTEXT</term>
		/// <term>The color of text drawn in the caption area of an active window.</term>
		/// </item>
		/// <item>
		/// <term>TMT_ACTIVEBORDER</term>
		/// <term>The color of the border around an active window.</term>
		/// </item>
		/// <item>
		/// <term>TMT_INACTIVEBORDER</term>
		/// <term>The color of the border around an inactive window.</term>
		/// </item>
		/// <item>
		/// <term>TMT_APPWORKSPACE</term>
		/// <term>The color of the application workspace.</term>
		/// </item>
		/// <item>
		/// <term>TMT_HIGHLIGHT</term>
		/// <term>The color of a highlight.</term>
		/// </item>
		/// <item>
		/// <term>TMT_HIGHLIGHTTEXT</term>
		/// <term>The color of highlighted text.</term>
		/// </item>
		/// <item>
		/// <term>TMT_BTNFACE</term>
		/// <term>The color of a button face.</term>
		/// </item>
		/// <item>
		/// <term>TMT_BTNSHADOW</term>
		/// <term>The color of the shadow underneath a button.</term>
		/// </item>
		/// <item>
		/// <term>TMT_GRAYTEXT</term>
		/// <term>The color of dimmed text.</term>
		/// </item>
		/// <item>
		/// <term>TMT_BTNTEXT</term>
		/// <term>The color of text contained within a button.</term>
		/// </item>
		/// <item>
		/// <term>TMT_INACTIVECAPTIONTEXT</term>
		/// <term>The color of the text in the caption area of an inactive window.</term>
		/// </item>
		/// <item>
		/// <term>TMT_BTNHIGHLIGHT</term>
		/// <term>The color of the highlight around a button.</term>
		/// </item>
		/// <item>
		/// <term>TMT_DKSHADOW3D</term>
		/// <term>The color of three-dimensional dark shadows.</term>
		/// </item>
		/// <item>
		/// <term>TMT_LIGHT3D</term>
		/// <term>The color of three-dimensional light areas.</term>
		/// </item>
		/// <item>
		/// <term>TMT_INFOTEXT</term>
		/// <term>The color of informational text.</term>
		/// </item>
		/// <item>
		/// <term>TMT_INFOBK</term>
		/// <term>The color of the background behind informational text.</term>
		/// </item>
		/// <item>
		/// <term>TMT_BUTTONALTERNATEFACE</term>
		/// <term>The color of the alternate face of a button.</term>
		/// </item>
		/// <item>
		/// <term>TMT_HOTTRACKING</term>
		/// <term>The color of highlight applied when a user moves the mouse over a control.</term>
		/// </item>
		/// <item>
		/// <term>TMT_GRADIENTACTIVECAPTION</term>
		/// <term>The gradient color applied to the caption area of an active window.</term>
		/// </item>
		/// <item>
		/// <term>TMT_GRADIENTINACTIVECAPTION</term>
		/// <term>The gradient color applied to the caption area of an inactive window.</term>
		/// </item>
		/// <item>
		/// <term>TMT_MENUHILIGHT</term>
		/// <term>The color of highlight drawn on a menu item when the user moves the mouse over it.</term>
		/// </item>
		/// <item>
		/// <term>TMT_MENUBAR</term>
		/// <term>The color of the menu bar.</term>
		/// </item>
		/// </list>
		/// </para>
		/// </param>
		/// <returns>
		/// <para>Type: <c><c>HBRUSH</c></c></para>
		/// <para>Handle to brush data.</para>
		/// </returns>
		// HBRUSH GetThemeSysColorBrush( _In_ HTHEME hTheme, _In_ int iColorID); https://msdn.microsoft.com/en-us/library/windows/desktop/bb759780(v=vs.85).aspx
		[DllImport(Lib.UxTheme, SetLastError = false, ExactSpelling = true)]
		[PInvokeData("Uxtheme.h", MSDNShortId = "bb759780")]
		public static extern SafeHBRUSH GetThemeSysColorBrush(HTHEME hTheme, int iColorID);

		/// <summary>Retrieves the value of a system <c>int</c>.</summary>
		/// <param name="hTheme">
		/// <para>Type: <c>HTHEME</c></para>
		/// <para>Handle to theme data.</para>
		/// </param>
		/// <param name="iIntID">
		/// <para>Type: <c>int</c></para>
		/// <para>Value of type <c>int</c> that specifies the desired system <c>int</c>. May be the following value.</para>
		/// <para>
		/// <list type="table">
		/// <listheader>
		/// <term>Value</term>
		/// <term>Meaning</term>
		/// </listheader>
		/// <item>
		/// <term>TMT_MINCOLORDEPTH</term>
		/// <term>The minimum color depth, in bits, required to properly view this style.</term>
		/// </item>
		/// </list>
		/// </para>
		/// </param>
		/// <param name="piValue">
		/// <para>Type: <c>int*</c></para>
		/// <para>Pointer to an <c>int</c> that receives the system integer value.</para>
		/// </param>
		/// <returns>
		/// <para>Type: <c><c>HRESULT</c></c></para>
		/// <para>If this function succeeds, it returns <c>S_OK</c>. Otherwise, it returns an <c>HRESULT</c> error code.</para>
		/// </returns>
		// HRESULT GetThemeSysInt( _In_ HTHEME hTheme, _In_ int iIntID, _In_ int *piValue); https://msdn.microsoft.com/en-us/library/windows/desktop/bb759787(v=vs.85).aspx
		[DllImport(Lib.UxTheme, SetLastError = false, ExactSpelling = true)]
		[PInvokeData("Uxtheme.h", MSDNShortId = "bb759787")]
		public static extern HRESULT GetThemeSysInt(HTHEME hTheme, int iIntID, out int piValue);

		/// <summary>Retrieves the value of a system size metric from theme data.</summary>
		/// <param name="hTheme">
		/// <para>Type: <c>HTHEME</c></para>
		/// <para>Handle to theme data.</para>
		/// </param>
		/// <param name="iSizeID">
		/// <para>Type: <c>int</c></para>
		/// <para>Value of type <c>int</c> that specifies the system size metric desired. The following values are valid:</para>
		/// <para>
		/// <list type="table">
		/// <listheader>
		/// <term>Value</term>
		/// <term>Meaning</term>
		/// </listheader>
		/// <item>
		/// <term>SM_CXBORDER</term>
		/// <term>Specifies the width of a border.</term>
		/// </item>
		/// <item>
		/// <term>SM_CXVSCROLL</term>
		/// <term>Specifies the width of a scroll bar.</term>
		/// </item>
		/// <item>
		/// <term>SM_CXHSCROLL</term>
		/// <term>Specifies the height of a scroll bar.</term>
		/// </item>
		/// <item>
		/// <term>SM_CXSIZE</term>
		/// <term>Specifies the width of a caption.</term>
		/// </item>
		/// <item>
		/// <term>SM_CYSIZE</term>
		/// <term>Specifies the height of a caption.</term>
		/// </item>
		/// <item>
		/// <term>SM_CXSMSIZE</term>
		/// <term>Specifies the width of a small caption.</term>
		/// </item>
		/// <item>
		/// <term>SM_CYSMSIZE</term>
		/// <term>Specifies the height of a small caption.</term>
		/// </item>
		/// <item>
		/// <term>SM_CXMENUSIZE</term>
		/// <term>Specifies the width of a menu bar.</term>
		/// </item>
		/// <item>
		/// <term>SM_CYMENUSIZE</term>
		/// <term>Specifies the height of a menu bar.</term>
		/// </item>
		/// <item>
		/// <term>SM_CXPADDEDBORDER</term>
		/// <term>Specifies the amount of border padding for captioned windows.</term>
		/// </item>
		/// </list>
		/// </para>
		/// </param>
		/// <returns>
		/// <para>Type: <c>int</c></para>
		/// <para>Returns the size in pixels.</para>
		/// </returns>
		// int GetThemeSysSize( _In_ HTHEME hTheme, _In_ int iSizeID); https://msdn.microsoft.com/en-us/library/windows/desktop/bb759790(v=vs.85).aspx
		[DllImport(Lib.UxTheme, SetLastError = false, ExactSpelling = true)]
		[PInvokeData("Uxtheme.h", MSDNShortId = "bb759790")]
		public static extern int GetThemeSysSize(HTHEME hTheme, int iSizeID);

		/// <summary>Retrieves the value of a system string.</summary>
		/// <param name="hTheme">
		/// <para>Type: <c>HTHEME</c></para>
		/// <para>Handle to theme data.</para>
		/// </param>
		/// <param name="iStringID">
		/// <para>Type: <c>int</c></para>
		/// <para>Value of type <c>int</c> that specifies a system string. May be one of the following values.</para>
		/// <para>
		/// <list type="table">
		/// <listheader>
		/// <term>Value</term>
		/// <term>Meaning</term>
		/// </listheader>
		/// <item>
		/// <term>TMT_CSSNAME</term>
		/// <term>The name of the CSS file associated with the theme specified by hTheme.</term>
		/// </item>
		/// <item>
		/// <term>TMT_XMLNAME</term>
		/// <term>The name of the XML file associated with the theme specified by hTheme.</term>
		/// </item>
		/// </list>
		/// </para>
		/// </param>
		/// <param name="pszStringBuff">
		/// <para>Type: <c><c>LPWSTR</c></c></para>
		/// <para>Pointer to the buffer that receives the string value from this function.</para>
		/// </param>
		/// <param name="cchMaxStringChars">
		/// <para>Type: <c>int</c></para>
		/// <para>Value of type <c>int</c> that specifies the maximum number of characters the string buffer can hold.</para>
		/// </param>
		/// <returns>
		/// <para>Type: <c><c>HRESULT</c></c></para>
		/// <para>If this function succeeds, it returns <c>S_OK</c>. Otherwise, it returns an <c>HRESULT</c> error code.</para>
		/// </returns>
		// HRESULT GetThemeSysString( _In_ HTHEME hTheme, _In_ int iStringID, _Out_ LPWSTR pszStringBuff, _In_ int cchMaxStringChars); https://msdn.microsoft.com/en-us/library/windows/desktop/bb759793(v=vs.85).aspx
		[DllImport(Lib.UxTheme, SetLastError = false, ExactSpelling = true)]
		[PInvokeData("Uxtheme.h", MSDNShortId = "bb759793")]
		public static extern HRESULT GetThemeSysString(HTHEME hTheme, int iStringID, [MarshalAs(UnmanagedType.LPWStr)] StringBuilder pszStringBuff, int cchMaxStringChars);

		/// <summary>Calculates the size and location of the specified text when rendered in the visual style font.</summary>
		/// <param name="hTheme">
		/// <para>Type: <c>HTHEME</c></para>
		/// <para>Handle to a window's specified theme data. Use <c>OpenThemeData</c> to create an HTHEME.</para>
		/// </param>
		/// <param name="hdc">
		/// <para>Type: <c><c>HDC</c></c></para>
		/// <para>HDC to select the font into.</para>
		/// </param>
		/// <param name="iPartId">
		/// <para>Type: <c>int</c></para>
		/// <para>Value of type <c>int</c> that specifies the part in which the text will be drawn. See Parts and States.</para>
		/// </param>
		/// <param name="iStateId">
		/// <para>Type: <c>int</c></para>
		/// <para>Value of type <c>int</c> that specifies the state of the part. See Parts and States.</para>
		/// </param>
		/// <param name="pszText">
		/// <para>Type: <c><c>LPCWSTR</c></c></para>
		/// <para>Pointer to a string that contains the text to draw.</para>
		/// </param>
		/// <param name="iCharCount">
		/// <para>Type: <c>int</c></para>
		/// <para>
		/// Value of type <c>int</c> that contains the number of characters to draw. If the parameter is set to -1, all the characters in the
		/// string are drawn.
		/// </para>
		/// </param>
		/// <param name="dwTextFlags">
		/// <para>Type: <c><c>DWORD</c></c></para>
		/// <para>
		/// <c>DWORD</c> that contains one or more values that specify the string's formatting. See Format Values for possible parameter values.
		/// </para>
		/// </param>
		/// <param name="pBoundingRect">
		/// <para>Type: <c>LPCRECT</c></para>
		/// <para>
		/// Pointer to a <c>RECT</c> structure that contains the rectangle used to control layout of the text. This parameter may be set to <c>NULL</c>.
		/// </para>
		/// </param>
		/// <param name="pExtentRect">
		/// <para>Type: <c>LPRECT</c></para>
		/// <para>Pointer to a <c>RECT</c> structure that contains, in logical coordinates, the rectangle required to fit the rendered text.</para>
		/// </param>
		/// <returns>
		/// <para>Type: <c><c>HRESULT</c></c></para>
		/// <para>If this function succeeds, it returns <c>S_OK</c>. Otherwise, it returns an <c>HRESULT</c> error code.</para>
		/// </returns>
		// HRESULT GetThemeTextExtent( _In_ HTHEME hTheme, _In_ HDC hdc, _In_ int iPartId, _In_ int iStateId, _In_ LPCWSTR pszText, _In_ int
		// iCharCount, _In_ DWORD dwTextFlags, _In_ LPCRECT pBoundingRect, _Out_ LPRECT pExtentRect); https://msdn.microsoft.com/en-us/library/windows/desktop/bb759798(v=vs.85).aspx
		[DllImport(Lib.UxTheme, SetLastError = false, ExactSpelling = true, CharSet = CharSet.Unicode)]
		[PInvokeData("Uxtheme.h", MSDNShortId = "bb759798")]
		public static extern HRESULT GetThemeTextExtent(HTHEME hTheme, HDC hdc, int iPartId, int iStateId, string pszText, int iCharCount, DrawTextFlags dwTextFlags, PRECT pBoundingRect, out RECT pExtentRect);

		/// <summary>Retrieves information about the font specified by a visual style for a particular part.</summary>
		/// <param name="hTheme">
		/// <para>Type: <c>HTHEME</c></para>
		/// <para>Handle to a window's specified theme data. Use <c>OpenThemeData</c> to create an HTHEME.</para>
		/// </param>
		/// <param name="hdc">
		/// <para>Type: <c><c>HDC</c></c></para>
		/// <para>HDC to use for screen context. This parameter may be set to <c>NULL</c>.</para>
		/// </param>
		/// <param name="iPartId">
		/// <para>Type: <c>int</c></para>
		/// <para>Value of type <c>int</c> that specifies the part to retrieve font information about. See Parts and States.</para>
		/// </param>
		/// <param name="iStateId">
		/// <para>Type: <c>int</c></para>
		/// <para>Value of type <c>int</c> that specifies the state of the part. See Parts and States.</para>
		/// </param>
		/// <param name="ptm">
		/// <para>Type: <c><c>TEXTMETRIC</c>*</c></para>
		/// <para>Receives the font information.</para>
		/// </param>
		/// <returns>
		/// <para>Type: <c><c>HRESULT</c></c></para>
		/// <para>If this function succeeds, it returns <c>S_OK</c>. Otherwise, it returns an <c>HRESULT</c> error code.</para>
		/// </returns>
		// HRESULT GetThemeTextMetrics( _In_ HTHEME hTheme, _In_ HDC hdc, _In_ int iPartId, _In_ int iStateId, _Out_ TEXTMETRIC *ptm); https://msdn.microsoft.com/en-us/library/windows/desktop/bb759801(v=vs.85).aspx
		[DllImport(Lib.UxTheme, SetLastError = false, ExactSpelling = true)]
		[PInvokeData("Uxtheme.h", MSDNShortId = "bb759801")]
		public static extern HRESULT GetThemeTextMetrics(HTHEME hTheme, HDC hdc, int iPartId, int iStateId, out TEXTMETRIC ptm);

		/// <summary>Gets a predefined timing function based ona timing function identifier.</summary>
		/// <param name="hTheme">An opened theme handle.</param>
		/// <param name="iTimingFunctionId">A timing function identifier.</param>
		/// <param name="pTimingFunction">A buffer to receive a predefined timing function pointer.</param>
		/// <param name="cbSize">The byte size of the buffer pointed by pTimingFunction.</param>
		/// <param name="pcbSizeOut">The byte size ofthe timing function structure.</param>
		/// <returns>If this function succeeds, it returns <c>S_OK</c>. Otherwise, it returns an <c>HRESULT</c> error code.</returns>
		// HRESULT THEMEAPI GetThemeTimingFunction( _In_ HTHEME hTheme, _In_ int iTimingFunctionId, _Out_ TA_TIMINGFUNCTION *pTimingFunction,
		// _In_ DWORD cbSize, _Out_ DWORD pcbSizeOut); https://msdn.microsoft.com/en-us/library/windows/desktop/hh404194(v=vs.85).aspx
		[DllImport(Lib.UxTheme, SetLastError = false, ExactSpelling = true)]
		[PInvokeData("Uxtheme.h", MSDNShortId = "hh404194")]
		public static extern HRESULT GetThemeTimingFunction(HTHEME hTheme, int iTimingFunctionId, IntPtr pTimingFunction, uint cbSize, out uint pcbSizeOut);

		/// <summary>Gets the duration for the specified transition.</summary>
		/// <param name="hTheme">
		/// <para>Type: <c>HTHEME</c></para>
		/// <para>Handle of the theme data.</para>
		/// </param>
		/// <param name="iPartId">
		/// <para>Type: <c>int</c></para>
		/// <para>ID of the part.</para>
		/// </param>
		/// <param name="iStateIdFrom">
		/// <para>Type: <c>int</c></para>
		/// <para>State ID of the part before the transition.</para>
		/// </param>
		/// <param name="iStateIdTo">
		/// <para>Type: <c>int</c></para>
		/// <para>State ID of the part after the transition.</para>
		/// </param>
		/// <param name="iPropId">
		/// <para>Type: <c>int</c></para>
		/// <para>Property ID.</para>
		/// </param>
		/// <param name="pdwDuration">
		/// <para>Type: <c><c>DWORD</c>*</c></para>
		/// <para>Address of a variable that receives the transition duration, in milliseconds.</para>
		/// </param>
		/// <returns>
		/// <para>Type: <c><c>HRESULT</c></c></para>
		/// <para>If this function succeeds, it returns <c>S_OK</c>. Otherwise, it returns an <c>HRESULT</c> error code.</para>
		/// </returns>
		// HRESULT GetThemeTransitionDuration( HTHEME hTheme, int iPartId, int iStateIdFrom, int iStateIdTo, int iPropId, _Out_ DWORD
		// *pdwDuration); https://msdn.microsoft.com/en-us/library/windows/desktop/bb759804(v=vs.85).aspx
		[DllImport(Lib.UxTheme, SetLastError = false, ExactSpelling = true)]
		[PInvokeData("Uxtheme.h", MSDNShortId = "bb759804")]
		public static extern HRESULT GetThemeTransitionDuration(HTHEME hTheme, int iPartId, int iStateIdFrom, int iStateIdTo, int iPropId, out uint pdwDuration);

		/// <summary>Retrieves a theme handle to a window that has visual styles applied.</summary>
		/// <param name="hWnd">
		/// <para>Type: <c><c>HWND</c></c></para>
		/// <para>Handle of the window.</para>
		/// </param>
		/// <returns>
		/// <para>Type: <c>HTHEME</c></para>
		/// <para>The most recent theme handle from <c>OpenThemeData</c>.</para>
		/// </returns>
		// HTHEME GetWindowTheme( _In_ HWND hWnd); https://msdn.microsoft.com/en-us/library/windows/desktop/bb759806(v=vs.85).aspx
		[DllImport(Lib.UxTheme, SetLastError = false, ExactSpelling = true)]
		[PInvokeData("Uxtheme.h", MSDNShortId = "bb759806")]
		public static extern HTHEME GetWindowTheme(HWND hWnd);

		/// <summary>Retrieves a hit test code for a point in the background specified by a visual style.</summary>
		/// <param name="hTheme">
		/// <para>Type: <c>HTHEME</c></para>
		/// <para>Handle to a window's specified theme data. Use <c>OpenThemeData</c> to create an HTHEME.</para>
		/// </param>
		/// <param name="hdc">
		/// <para>Type: <c><c>HDC</c></c></para>
		/// <para>HDC to use when drawing. This parameter may be set to <c>NULL</c>.</para>
		/// </param>
		/// <param name="iPartId">
		/// <para>Type: <c>int</c></para>
		/// <para>Value of type <c>int</c> that specifies the part. See Parts and States.</para>
		/// </param>
		/// <param name="iStateId">
		/// <para>Type: <c>int</c></para>
		/// <para>Value of type <c>int</c> that specifies the state of the part. See Parts and States.</para>
		/// </param>
		/// <param name="dwOptions">
		/// <para>Type: <c><c>DWORD</c></c></para>
		/// <para><c>DWORD</c> that specifies the hit test options. See Hit Test Options for a list of options.</para>
		/// </param>
		/// <param name="pRect">
		/// <para>Type: <c>LPCRECT</c></para>
		/// <para>Pointer to a <c>RECT</c> structure that contains, in logical coordinates, the rectangle that bounds the background.</para>
		/// </param>
		/// <param name="hrgn">
		/// <para>Type: <c><c>HRGN</c></c></para>
		/// <para>Handle to a region that can be used to specify the bounds of a hit test area. This parameter may be set to <c>NULL</c>.</para>
		/// </param>
		/// <param name="ptTest">
		/// <para>Type: <c><c>POINT</c></c></para>
		/// <para><c>POINT</c> structure that contains the coordinates of the point.</para>
		/// </param>
		/// <param name="pwHitTestCode">
		/// <para>Type: <c><c>WORD</c>*</c></para>
		/// <para>
		/// <c>WORD</c> that receives the hit test code that indicates whether the point in ptTest is in the background area bounded by pRect
		/// or hrgn. See Hit Test Return Values for a list of values returned.
		/// </para>
		/// </param>
		/// <returns>
		/// <para>Type: <c><c>HRESULT</c></c></para>
		/// <para>If this function succeeds, it returns <c>S_OK</c>. Otherwise, it returns an <c>HRESULT</c> error code.</para>
		/// </returns>
		// HRESULT HitTestThemeBackground( _In_ HTHEME hTheme, _In_ HDC hdc, _In_ int iPartId, _In_ int iStateId, _In_ DWORD dwOptions, _In_
		// LPCRECT pRect, _In_ HRGN hrgn, _In_ POINT ptTest, _Out_ WORD *pwHitTestCode); https://msdn.microsoft.com/en-us/library/windows/desktop/bb759808(v=vs.85).aspx
		[DllImport(Lib.UxTheme, SetLastError = false, ExactSpelling = true)]
		[PInvokeData("Uxtheme.h", MSDNShortId = "bb759808")]
		public static extern HRESULT HitTestThemeBackground(HTHEME hTheme, HDC hdc, int iPartId, int iStateId, HitTestOptions dwOptions, in RECT pRect, HRGN hrgn, POINT ptTest, out HitTestValues pwHitTestCode);

		/// <summary>Reports whether the current application's user interface displays using visual styles.</summary>
		/// <returns>
		/// <para>Type: <c><c>BOOL</c></c></para>
		/// <para>Returns one of the following values.</para>
		/// <para>
		/// <list type="table">
		/// <listheader>
		/// <term>Return code</term>
		/// <term>Description</term>
		/// </listheader>
		/// <item>
		/// <term>TRUE</term>
		/// <term>The application has a visual style applied.</term>
		/// </item>
		/// <item>
		/// <term>FALSE</term>
		/// <term>The application does not have a visual style applied.</term>
		/// </item>
		/// </list>
		/// </para>
		/// </returns>
		// BOOL IsAppThemed(void); https://msdn.microsoft.com/en-us/library/windows/desktop/bb759809(v=vs.85).aspx
		[DllImport(Lib.UxTheme, SetLastError = false, ExactSpelling = true)]
		[PInvokeData("Uxtheme.h", MSDNShortId = "bb759809")]
		[return: MarshalAs(UnmanagedType.Bool)]
		public static extern bool IsAppThemed();

		/// <summary>Determines whether Desktop Window Manager (DWM) composition effects are available to the theme.</summary>
		/// <returns>
		/// <para>Type: <c><c>BOOL</c></c></para>
		/// <para><c>TRUE</c> if composition effects are available; otherwise, <c>FALSE</c>.</para>
		/// </returns>
		// BOOL IsCompositionActive(void); https://msdn.microsoft.com/en-us/library/windows/desktop/bb759811(v=vs.85).aspx
		[DllImport(Lib.UxTheme, SetLastError = false, ExactSpelling = true)]
		[PInvokeData("Uxtheme.h", MSDNShortId = "bb759811")]
		[return: MarshalAs(UnmanagedType.Bool)]
		public static extern bool IsCompositionActive();

		/// <summary>Tests if a visual style for the current application is active.</summary>
		/// <returns>
		/// <para>Type: <c><c>BOOL</c></c></para>
		/// <para>Returns one of the following values.</para>
		/// <para>
		/// <list type="table">
		/// <listheader>
		/// <term>Return code</term>
		/// <term>Description</term>
		/// </listheader>
		/// <item>
		/// <term>TRUE</term>
		/// <term>
		/// A visual style is enabled, and windows with visual styles applied should call OpenThemeData to start using theme drawing services.
		/// </term>
		/// </item>
		/// <item>
		/// <term>FALSE</term>
		/// <term>
		/// A visual style is not enabled, and the window message handler does not need to make another call to IsThemeActive until it
		/// receives a WM_THEMECHANGED message.
		/// </term>
		/// </item>
		/// </list>
		/// </para>
		/// </returns>
		// BOOL IsThemeActive(void); https://msdn.microsoft.com/en-us/library/windows/desktop/bb759813(v=vs.85).aspx
		[DllImport(Lib.UxTheme, SetLastError = false, ExactSpelling = true)]
		[PInvokeData("Uxtheme.h", MSDNShortId = "bb759813")]
		[return: MarshalAs(UnmanagedType.Bool)]
		public static extern bool IsThemeActive();

		/// <summary>Retrieves whether the background specified by the visual style has transparent pieces or alpha-blended pieces.</summary>
		/// <param name="hTheme">
		/// <para>Type: <c>HTHEME</c></para>
		/// <para>Handle to a window's specified theme data. Use <c>OpenThemeData</c> to create an HTHEME.</para>
		/// </param>
		/// <param name="iPartId">
		/// <para>Type: <c>int</c></para>
		/// <para>Value of type <c>int</c> that specifies the part. See Parts and States.</para>
		/// </param>
		/// <param name="iStateId">
		/// <para>Type: <c>int</c></para>
		/// <para>Value of type <c>int</c> that specifies the state of the part. See Parts and States.</para>
		/// </param>
		/// <returns>
		/// <para>Type: <c><c>BOOL</c></c></para>
		/// <para>Returns one of the following values.</para>
		/// <para>
		/// <list type="table">
		/// <listheader>
		/// <term>Return code</term>
		/// <term>Description</term>
		/// </listheader>
		/// <item>
		/// <term>TRUE</term>
		/// <term>The theme-specified background for a particular iPartId and iStateId has transparent pieces or alpha-blended pieces.</term>
		/// </item>
		/// <item>
		/// <term>FALSE</term>
		/// <term>
		/// The theme-specified background for a particular iPartId and iStateId does not have transparent pieces or alpha-blended pieces.
		/// </term>
		/// </item>
		/// </list>
		/// </para>
		/// </returns>
		// BOOL IsThemeBackgroundPartiallyTransparent( _In_ HTHEME hTheme, _In_ int iPartId, _In_ int iStateId); https://msdn.microsoft.com/en-us/library/windows/desktop/bb759815(v=vs.85).aspx
		[DllImport(Lib.UxTheme, SetLastError = false, ExactSpelling = true)]
		[PInvokeData("Uxtheme.h", MSDNShortId = "bb759815")]
		[return: MarshalAs(UnmanagedType.Bool)]
		public static extern bool IsThemeBackgroundPartiallyTransparent(HTHEME hTheme, int iPartId, int iStateId);

		/// <summary>Reports whether a specified dialog window supports background texturing.</summary>
		/// <param name="hwnd">
		/// <para>Type: <c><c>HWND</c></c></para>
		/// <para><c>HWND</c> value that specifies a dialog window.</para>
		/// </param>
		/// <returns>
		/// <para>Type: <c><c>BOOL</c></c></para>
		/// <para>Returns one of the following values.</para>
		/// <para>
		/// <list type="table">
		/// <listheader>
		/// <term>Return code</term>
		/// <term>Description</term>
		/// </listheader>
		/// <item>
		/// <term>TRUE</term>
		/// <term>Background texturing is supported on the dialog window specified by the hwnd parameter.</term>
		/// </item>
		/// <item>
		/// <term>FALSE</term>
		/// <term>Background texturing is not supported on the dialog window specified by the hwnd parameter.</term>
		/// </item>
		/// </list>
		/// </para>
		/// </returns>
		// BOOL IsThemeDialogTextureEnabled( _In_ HWND hwnd); https://msdn.microsoft.com/en-us/library/windows/desktop/bb759818(v=vs.85).aspx
		[DllImport(Lib.UxTheme, SetLastError = false, ExactSpelling = true)]
		[PInvokeData("Uxtheme.h", MSDNShortId = "bb759818")]
		[return: MarshalAs(UnmanagedType.Bool)]
		public static extern bool IsThemeDialogTextureEnabled(HWND hwnd);

		/// <summary>Retrieves whether a visual style has defined parameters for the specified part and state.</summary>
		/// <param name="hTheme">
		/// <para>Type: <c>HTHEME</c></para>
		/// <para>Handle to a window's specified theme data. Use <c>OpenThemeData</c> to create an HTHEME.</para>
		/// </param>
		/// <param name="iPartId">
		/// <para>Type: <c>int</c></para>
		/// <para>Value of type <c>int</c> that specifies the part. See Parts and States.</para>
		/// </param>
		/// <param name="iStateId">
		/// <para>Type: <c>int</c></para>
		/// <para>Currently unused. The value should be 0.</para>
		/// </param>
		/// <returns>
		/// <para>Type: <c><c>BOOL</c></c></para>
		/// <para>Returns one of the following values.</para>
		/// <para>
		/// <list type="table">
		/// <listheader>
		/// <term>Return code</term>
		/// <term>Description</term>
		/// </listheader>
		/// <item>
		/// <term>TRUE</term>
		/// <term>The theme has defined parameters for the specified iPartId and iStateId</term>
		/// </item>
		/// <item>
		/// <term>FALSE</term>
		/// <term>The theme does not have defined parameters for the specified iPartId and iStateId</term>
		/// </item>
		/// </list>
		/// </para>
		/// </returns>
		// BOOL IsThemePartDefined( _In_ HTHEME hTheme, _In_ int iPartId, _In_ int iStateId); https://msdn.microsoft.com/en-us/library/windows/desktop/bb759819(v=vs.85).aspx
		[DllImport(Lib.UxTheme, SetLastError = false, ExactSpelling = true)]
		[PInvokeData("Uxtheme.h", MSDNShortId = "bb759819")]
		[return: MarshalAs(UnmanagedType.Bool)]
		public static extern bool IsThemePartDefined(HTHEME hTheme, int iPartId, int iStateId);

		/// <summary>Opens the theme data for a window and its associated class.</summary>
		/// <param name="hwnd">
		/// <para>Type: <c><c>HWND</c></c></para>
		/// <para>Handle of the window for which theme data is required.</para>
		/// </param>
		/// <param name="pszClassList">
		/// <para>Type: <c><c>LPCWSTR</c></c></para>
		/// <para>Pointer to a string that contains a semicolon-separated list of classes.</para>
		/// </param>
		/// <returns>
		/// <para>Type: <c>HTHEME</c></para>
		/// <para>
		/// <c>OpenThemeData</c> tries to match each class, one at a time, to a class data section in the active theme. If a match is found,
		/// an associated HTHEME handle is returned. If no match is found <c>NULL</c> is returned.
		/// </para>
		/// </returns>
		// HTHEME OpenThemeData( _In_ HWND hwnd, _In_ LPCWSTR pszClassList); https://msdn.microsoft.com/en-us/library/windows/desktop/bb759821(v=vs.85).aspx
		[DllImport(Lib.UxTheme, SetLastError = false, ExactSpelling = true, CharSet = CharSet.Unicode)]
		[PInvokeData("Uxtheme.h", MSDNShortId = "bb759821")]
		public static extern SafeHTHEME OpenThemeData(HWND hwnd, string pszClassList);

		/// <summary>Opens the theme data associated with a window for specified theme classes.</summary>
		/// <param name="hwnd">
		/// <para>Type: <c><c>HWND</c></c></para>
		/// <para>A handle to a window or control that the theme is to be retrieved from.</para>
		/// </param>
		/// <param name="pszClassIdList">
		/// <para>Type: <c><c>LPCWSTR</c></c></para>
		/// <para>A semicolon-separated list of class names to match.</para>
		/// </param>
		/// <param name="dwFlags">
		/// <para>Type: <c><c>DWORD</c></c></para>
		/// <para>Optional flags that control how to return the theme data. May be set to a combination of the following values.</para>
		/// <para>
		/// <list type="table">
		/// <listheader>
		/// <term>Value</term>
		/// <term>Meaning</term>
		/// </listheader>
		/// <item>
		/// <term>OTD_FORCE_RECT_SIZING</term>
		/// <term>Forces drawn images from this theme to stretch to fit the rectangles specified by drawing functions.</term>
		/// </item>
		/// <item>
		/// <term>OTD_NONCLIENT</term>
		/// <term>Allows theme elements to be drawn in the non-client area of the window.</term>
		/// </item>
		/// </list>
		/// </para>
		/// </param>
		/// <returns>
		/// <para>Type: <c>HTHEME</c></para>
		/// <para>If a match is found, a valid handle to a theme is returned. Otherwise, a <c>NULL</c> value will be returned.</para>
		/// </returns>
		// HTHEME OpenThemeDataEx( _In_ HWND hwnd, _In_ LPCWSTR pszClassIdList, _In_ DWORD dwFlags); https://msdn.microsoft.com/en-us/library/windows/desktop/bb759823(v=vs.85).aspx
		[DllImport(Lib.UxTheme, SetLastError = false, ExactSpelling = true, CharSet = CharSet.Unicode)]
		[PInvokeData("Uxtheme.h", MSDNShortId = "bb759823")]
		public static extern SafeHTHEME OpenThemeDataEx(HWND hwnd, string pszClassIdList, OpenThemeDataOptions dwFlags);

		/// <summary>A variant of OpenThemeData that opens a theme handle associated with a specific DPI.</summary>
		/// <param name="hwnd">The handle of the window for which theme data is required.</param>
		/// <param name="pszClassIdList">A pointer to a string that contains a semicolon-separated list of classes.</param>
		/// <param name="dpi">
		/// The specified DPI value with which to associate the theme handle. The function will return an error if this value is outside of
		/// those that correspond to the set of connected monitors.
		/// </param>
		/// <returns>See OpenThemeData.</returns>
		// HTHEME WINAPI OpenThemeDataForDpi( HWDN hwnd, PCWSTR pszClassIdList, UINT dpi); https://msdn.microsoft.com/en-us/library/windows/desktop/mt807674(v=vs.85).aspx
		[DllImport(Lib.User32, SetLastError = false, ExactSpelling = true, CharSet = CharSet.Unicode)]
		[PInvokeData("Uxtheme.h", MSDNShortId = "mt807674")]
		public static extern SafeHTHEME OpenThemeDataForDpi(HWND hwnd, string pszClassIdList, uint dpi);

		/// <summary>Sets the flags that determine how visual styles are implemented in the calling application.</summary>
		/// <param name="dwFlags">
		/// <para>Type: <c><c>DWORD</c></c></para>
		/// <para><c>DWORD</c> that specifies one or more of the following bit flags, which can be combined with a logical OR.</para>
		/// <para>
		/// <list type="table">
		/// <listheader>
		/// <term>Value</term>
		/// <term>Meaning</term>
		/// </listheader>
		/// <item>
		/// <term>STAP_ALLOW_NONCLIENT</term>
		/// <term>Specifies that the nonclient areas of application windows will have visual styles applied.</term>
		/// </item>
		/// <item>
		/// <term>STAP_ALLOW_CONTROLS</term>
		/// <term>Specifies that the common controls used in an application will have visual styles applied.</term>
		/// </item>
		/// <item>
		/// <term>STAP_ALLOW_WEBCONTENT</term>
		/// <term>Specifies that web content displayed in an application will have visual styles applied.</term>
		/// </item>
		/// </list>
		/// </para>
		/// </param>
		/// <returns>This function does not return a value.</returns>
		// void SetThemeAppProperties( DWORD dwFlags); https://msdn.microsoft.com/en-us/library/windows/desktop/bb759825(v=vs.85).aspx
		[DllImport(Lib.UxTheme, SetLastError = false, ExactSpelling = true)]
		[PInvokeData("Uxtheme.h", MSDNShortId = "bb759825")]
		public static extern void SetThemeAppProperties(ThemeAppProperties dwFlags);

		/// <summary>Causes a window to use a different set of visual style information than its class normally uses.</summary>
		/// <param name="hwnd">
		/// <para>Type: <c><c>HWND</c></c></para>
		/// <para>Handle to the window whose visual style information is to be changed.</para>
		/// </param>
		/// <param name="pszSubAppName">
		/// <para>Type: <c><c>LPCWSTR</c></c></para>
		/// <para>
		/// Pointer to a string that contains the application name to use in place of the calling application's name. If this parameter is
		/// <c>NULL</c>, the calling application's name is used.
		/// </para>
		/// </param>
		/// <param name="pszSubIdList">
		/// <para>Type: <c><c>LPCWSTR</c></c></para>
		/// <para>
		/// Pointer to a string that contains a semicolon-separated list of CLSID names to use in place of the actual list passed by the
		/// window's class. If this parameter is <c>NULL</c>, the ID list from the calling class is used.
		/// </para>
		/// </param>
		/// <returns>
		/// <para>Type: <c><c>HRESULT</c></c></para>
		/// <para>If this function succeeds, it returns <c>S_OK</c>. Otherwise, it returns an <c>HRESULT</c> error code.</para>
		/// </returns>
		// HRESULT SetWindowTheme( _In_ HWND hwnd, _In_ LPCWSTR pszSubAppName, _In_ LPCWSTR pszSubIdList); https://msdn.microsoft.com/en-us/library/windows/desktop/bb759827(v=vs.85).aspx
		[DllImport(Lib.UxTheme, SetLastError = false, ExactSpelling = true, CharSet = CharSet.Unicode)]
		[PInvokeData("Uxtheme.h", MSDNShortId = "bb759827")]
		public static extern HRESULT SetWindowTheme(HWND hwnd, string pszSubAppName, string pszSubIdList);

		/// <summary>Sets attributes to control how visual styles are applied to a specified window.</summary>
		/// <param name="hwnd">
		/// <para>Type: <c><c>HWND</c></c></para>
		/// <para>Handle to a window to apply changes to.</para>
		/// </param>
		/// <param name="eAttribute">
		/// <para>Type: <c>enum WINDOWTHEMEATTRIBUTETYPE</c></para>
		/// <para>
		/// Value of type <c>WINDOWTHEMEATTRIBUTETYPE</c> that specifies the type of attribute to set. The value of this parameter determines
		/// the type of data that should be passed in the pvAttribute parameter. Can be the following value.
		/// </para>
		/// <para>
		/// <list type="table">
		/// <listheader>
		/// <term>Value</term>
		/// <term>Meaning</term>
		/// </listheader>
		/// <item>
		/// <term>WTA_NONCLIENT</term>
		/// <term>Specifies non-client related attributes. pvAttribute must be a pointer of type WTA_OPTIONS.</term>
		/// </item>
		/// </list>
		/// </para>
		/// </param>
		/// <param name="pvAttribute">
		/// <para>Type: <c><c>PVOID</c></c></para>
		/// <para>A pointer that specifies attributes to set. Type is determined by the value of the eAttribute value.</para>
		/// </param>
		/// <param name="cbAttribute">
		/// <para>Type: <c><c>DWORD</c></c></para>
		/// <para>Specifies the size, in bytes, of the data pointed to by pvAttribute.</para>
		/// </param>
		/// <returns>
		/// <para>Type: <c><c>HRESULT</c></c></para>
		/// <para>If this function succeeds, it returns <c>S_OK</c>. Otherwise, it returns an <c>HRESULT</c> error code.</para>
		/// </returns>
		// HRESULT SetWindowThemeAttribute( _In_ HWND hwnd, _In_ enum WINDOWTHEMEATTRIBUTETYPE eAttribute, _In_ PVOID pvAttribute, _In_ DWORD
		// cbAttribute); https://msdn.microsoft.com/en-us/library/windows/desktop/bb759829(v=vs.85).aspx
		[DllImport(Lib.UxTheme, SetLastError = false, ExactSpelling = true)]
		[PInvokeData("Uxtheme.h", MSDNShortId = "bb759829")]
		public static extern HRESULT SetWindowThemeAttribute(HWND hwnd, WINDOWTHEMEATTRIBUTETYPE eAttribute, in WTA_OPTIONS pvAttribute, uint cbAttribute);

		/// <summary>Sets attributes to control how visual styles are applied to a specified window.</summary>
		/// <param name="hWnd">Handle to a window to apply changes to.</param>
		/// <param name="ncAttrs">A combination of flags that modify window visual style attributes.</param>
		/// <param name="activate">if set to <c>true</c> add the flag to the window attributes, otherwise remove the flag.</param>
		public static void SetWindowThemeNonClientAttributes(HWND hWnd, WTNCA ncAttrs, bool activate = true)
		{
			var opt = new WTA_OPTIONS { Flags = ncAttrs, Mask = activate ? (uint)ncAttrs : 0 };
			SetWindowThemeAttribute(hWnd, WINDOWTHEMEATTRIBUTETYPE.WTA_NONCLIENT, opt, (uint)Marshal.SizeOf(opt)).ThrowIfFailed();
		}

		/// <summary>Retrieves a list of <c>int</c> data from a visual style.</summary>
		/// <param name="hTheme">
		/// <para>Type: <c>HTHEME</c></para>
		/// <para>Handle to a window's specified theme data. Use <c>OpenThemeData</c> to create an HTHEME.</para>
		/// </param>
		/// <param name="iPartId">
		/// <para>Type: <c>int</c></para>
		/// <para>Value of type <c>int</c> that specifies the part that contains the list of data to return. See Parts and States.</para>
		/// </param>
		/// <param name="iStateId">
		/// <para>Type: <c>int</c></para>
		/// <para>Value of type <c>int</c> that specifies the state of the part. See Parts and States.</para>
		/// </param>
		/// <param name="iPropId">
		/// <para>Type: <c>int</c></para>
		/// <para>Value of type <c>int</c> that specifies the property to retrieve. See Property Identifiers.</para>
		/// </param>
		/// <param name="pIntList">
		/// <para>Type: <c><c>INTLIST</c>*</c></para>
		/// <para>Pointer to an <c>INTLIST</c> structure that receives the <c>int</c> data.</para>
		/// </param>
		/// <returns>
		/// <para>Type: <c><c>HRESULT</c></c></para>
		/// <para>Returns S_OK if successful, otherwise an error code.</para>
		/// </returns>
		// HRESULT GetThemeIntList( _In_ HTHEME hTheme, _In_ int iPartId, _In_ int iStateId, _In_ int iPropId, _Out_ INTLIST *pIntList); https://msdn.microsoft.com/en-us/library/windows/desktop/bb759752(v=vs.85).aspx
		[PInvokeData("UxTheme.h", MSDNShortId = "bb759752")]
		[DllImport(Lib.UxTheme, SetLastError = false, EntryPoint = "GetThemeIntList")]
		private static extern HRESULT GetThemeIntListPreVista(HTHEME hTheme, int iPartId, int iStateId, int iPropId, out INTLIST_OLD pIntList);

		/// <summary>Defines the options for the <see cref="DrawThemeTextEx"/> function.</summary>
		/// <summary>Defines the options for the <c>DrawThemeTextEx</c> function.</summary>
		// typedef struct _DTTOPTS { DWORD dwSize; DWORD dwFlags; COLORREF crText; COLORREF crBorder; COLORREF crShadow; int iTextShadowType;
		// POINT ptShadowOffset; int iBorderSize; int iFontPropId; int iColorPropId; int iStateId; BOOL fApplyOverlay; int iGlowSize;
		// DTT_CALLBACK_PROC pfnDrawTextCallback; LPARAM lParam;} DTTOPTS, *PDTTOPTS; https://msdn.microsoft.com/en-us/library/windows/desktop/bb773236(v=vs.85).aspx
		[PInvokeData("Uxtheme.h", MSDNShortId = "bb773236")]
		[StructLayout(LayoutKind.Sequential)]
		public struct DTTOPTS
		{
			/// <summary>
			/// <para>Type: <c><c>DWORD</c></c></para>
			/// <para>Size of the structure.</para>
			/// </summary>
			public uint dwSize;

			/// <summary>
			/// <para>Type: <c><c>DWORD</c></c></para>
			/// <para>
			/// A combination of flags that specify whether certain values of the <c>DTTOPTS</c> structure have been specified, and how to
			/// interpret these values. This member can be a combination of the following.
			/// </para>
			/// <para>
			/// <list type="table">
			/// <listheader>
			/// <term>Value</term>
			/// <term>Meaning</term>
			/// </listheader>
			/// <item>
			/// <term>DTT_TEXTCOLOR</term>
			/// <term>The crText member value is valid.</term>
			/// </item>
			/// <item>
			/// <term>DTT_BORDERCOLOR</term>
			/// <term>The crBorder member value is valid.</term>
			/// </item>
			/// <item>
			/// <term>DTT_SHADOWCOLOR</term>
			/// <term>The crShadow member value is valid.</term>
			/// </item>
			/// <item>
			/// <term>DTT_SHADOWTYPE</term>
			/// <term>The iTextShadowType member value is valid.</term>
			/// </item>
			/// <item>
			/// <term>DTT_SHADOWOFFSET</term>
			/// <term>The ptShadowOffset member value is valid.</term>
			/// </item>
			/// <item>
			/// <term>DTT_BORDERSIZE</term>
			/// <term>The iBorderSize member value is valid.</term>
			/// </item>
			/// <item>
			/// <term>DTT_FONTPROP</term>
			/// <term>The iFontPropId member value is valid.</term>
			/// </item>
			/// <item>
			/// <term>DTT_COLORPROP</term>
			/// <term>The iColorPropId member value is valid.</term>
			/// </item>
			/// <item>
			/// <term>DTT_STATEID</term>
			/// <term>The iStateId member value is valid.</term>
			/// </item>
			/// <item>
			/// <term>DTT_CALCRECT</term>
			/// <term>
			/// The pRect parameter of the DrawThemeTextEx function that uses this structure will be used as both an in and an out parameter.
			/// After the function returns, the pRect parameter will contain the rectangle that corresponds to the region calculated to be drawn.
			/// </term>
			/// </item>
			/// <item>
			/// <term>DTT_APPLYOVERLAY</term>
			/// <term>The fApplyOverlay member value is valid.</term>
			/// </item>
			/// <item>
			/// <term>DTT_GLOWSIZE</term>
			/// <term>The iGlowSize member value is valid.</term>
			/// </item>
			/// <item>
			/// <term>DTT_CALLBACK</term>
			/// <term>The pfnDrawTextCallback member value is valid.</term>
			/// </item>
			/// <item>
			/// <term>DTT_COMPOSITED</term>
			/// <term>
			/// Draws text with antialiased alpha. Use of this flag requires a top-down DIB section. This flag works only if the HDC passed
			/// to function DrawThemeTextEx has a top-down DIB section currently selected in it. For more information, see Device-Independent Bitmaps.
			/// </term>
			/// </item>
			/// <item>
			/// <term>DTT_VALIDBITS</term>
			/// <term>
			/// DTT_TEXTCOLOR | DTT_BORDERCOLOR | DTT_SHADOWCOLOR | DTT_SHADOWTYPE | DTT_SHADOWOFFSET | DTT_BORDERSIZE | DTT_FONTPROP |
			/// DTT_COLORPROP | DTT_STATEID | DTT_CALCRECT | DTT_APPLYOVERLAY | DTT_GLOWSIZE | DTT_COMPOSITED.
			/// </term>
			/// </item>
			/// </list>
			/// </para>
			/// </summary>
			public DrawThemeTextOptionsMasks dwMasks;

			/// <summary>
			/// <para>Type: <c><c>COLORREF</c></c></para>
			/// <para>Specifies the color of the text that will be drawn.</para>
			/// </summary>
			public COLORREF crText;

			/// <summary>
			/// <para>Type: <c><c>COLORREF</c></c></para>
			/// <para>Specifies the color of the outline that will be drawn around the text.</para>
			/// </summary>
			public COLORREF crBorder;

			/// <summary>
			/// <para>Type: <c><c>COLORREF</c></c></para>
			/// <para>Specifies the color of the shadow that will be drawn behind the text.</para>
			/// </summary>
			public COLORREF crShadow;

			/// <summary>
			/// <para>Type: <c>int</c></para>
			/// <para>Specifies the type of the shadow that will be drawn behind the text. This member can have one of the following values.</para>
			/// <para>
			/// <list type="table">
			/// <listheader>
			/// <term>Value</term>
			/// <term>Meaning</term>
			/// </listheader>
			/// <item>
			/// <term>TST_NONE</term>
			/// <term>No shadow will be drawn.</term>
			/// </item>
			/// <item>
			/// <term>TST_SINGLE</term>
			/// <term>The shadow will be drawn to appear detailed underneath text.</term>
			/// </item>
			/// <item>
			/// <term>TST_CONTINUOUS</term>
			/// <term>The shadow will be drawn to appear blurred underneath text.</term>
			/// </item>
			/// </list>
			/// </para>
			/// </summary>
			public TextShadowType iTextShadowType;

			/// <summary>
			/// <para>Type: <c><c>POINT</c></c></para>
			/// <para>Specifies the amount of offset, in logical coordinates, between the shadow and the text.</para>
			/// </summary>
			public POINT ptShadowOffset;

			/// <summary>
			/// <para>Type: <c>int</c></para>
			/// <para>Specifies the radius of the outline that will be drawn around the text.</para>
			/// </summary>
			public int iBorderSize;

			/// <summary>
			/// <para>Type: <c>int</c></para>
			/// <para>Specifies an alternate font property to use when drawing text. For a list of possible values, see <c>GetThemeSysFont</c>.</para>
			/// </summary>
			public ThemeProperty iFontPropId;

			/// <summary>
			/// <para>Type: <c>int</c></para>
			/// <para>
			/// Specifies an alternate color property to use when drawing text. If this value is valid and the corresponding flag is set in
			/// <c>dwFlags</c>, this value will override the value of <c>crText</c>. See the values listed in <c>GetSysColor</c> for the
			/// nIndex parameter.
			/// </para>
			/// </summary>
			public ThemeProperty iColorPropId;

			/// <summary>
			/// <para>Type: <c>int</c></para>
			/// <para>Specifies an alternate state to use. This member is not used by <c>DrawThemeTextEx</c>.</para>
			/// </summary>
			public int iStateId;

			/// <summary>
			/// <para>Type: <c><c>BOOL</c></c></para>
			/// <para>
			/// If <c>TRUE</c>, text will be drawn on top of the shadow and outline effects. If <c>FALSE</c>, just the shadow and outline
			/// effects will be drawn.
			/// </para>
			/// </summary>
			[MarshalAs(UnmanagedType.Bool)]
			public bool fApplyOverlay;

			/// <summary>
			/// <para>Type: <c>int</c></para>
			/// <para>Specifies the size of a glow that will be drawn on the background prior to any text being drawn.</para>
			/// </summary>
			public int iGlowSize;

			/// <summary>
			/// <para>Type: <c>DTT_CALLBACK_PROC</c></para>
			/// <para>Pointer to callback function for <c>DrawThemeTextEx</c>.</para>
			/// </summary>
			[MarshalAs(UnmanagedType.FunctionPtr)]
			public DTT_CALLBACK_PROC pfnDrawTextCallback;

			/// <summary>
			/// <para>Type: <c><c>LPARAM</c></c></para>
			/// <para>Parameter for callback back function specified by <c>pfnDrawTextCallback</c>.</para>
			/// </summary>
			public IntPtr lParam;

			/// <summary>Initializes a new instance of the <see cref="DTTOPTS"/> struct.</summary>
			/// <param name="shouldBeNull">This value must be specified to initialize. Use null.</param>
			public DTTOPTS(byte? shouldBeNull) : this() => dwSize = (uint)Marshal.SizeOf(typeof(DTTOPTS));

			/// <summary>Gets or sets a value that specifies an alternate color property to use when drawing text.</summary>
			/// <value>The alternate color of the text.</value>
			public ThemeProperty AlternateColorProperty
			{
				get => iColorPropId;
				set
				{
					iColorPropId = value;
					dwMasks |= DrawThemeTextOptionsMasks.DTT_COLORPROP;
				}
			}

			/// <summary>Gets or sets an alternate font property to use when drawing text.</summary>
			/// <value>The alternate font.</value>
			public ThemeProperty AlternateFont
			{
				get => iFontPropId;
				set
				{
					iFontPropId = value;
					dwMasks |= DrawThemeTextOptionsMasks.DTT_FONTPROP;
				}
			}

			/// <summary>
			/// Gets or sets a value indicating whether to draw text with antialiased alpha. Use of this flag requires a top-down DIB
			/// section. This flag works only if the HDC passed to function DrawThemeTextEx has a top-down DIB section currently selected in
			/// it. For more information, see Device-Independent Bitmaps.
			/// </summary>
			/// <value><c>true</c> if antialiased alpha; otherwise, <c>false</c>.</value>
			public bool AntiAliasedAlpha
			{
				get => dwMasks.IsFlagSet(DrawThemeTextOptionsMasks.DTT_COMPOSITED);
				set => SetFlag(DrawThemeTextOptionsMasks.DTT_COMPOSITED, value);
			}

			/// <summary>
			/// Gets or sets a value indicating whether text will be drawn on top of the shadow and outline effects ( <c>true</c>) or if just
			/// the shadow and outline effects will be drawn ( <c>false</c>).
			/// </summary>
			/// <value><c>true</c> if drawn on top; otherwise, <c>false</c>.</value>
			public bool ApplyOverlay
			{
				get => fApplyOverlay;
				set
				{
					fApplyOverlay = value;
					dwMasks |= DrawThemeTextOptionsMasks.DTT_APPLYOVERLAY;
				}
			}

			/// <summary>Gets or sets the color of the outline that will be drawn around the text.</summary>
			/// <value>The color of the border.</value>
			public COLORREF BorderColor
			{
				get => crBorder;
				set
				{
					crBorder = value;
					dwMasks |= DrawThemeTextOptionsMasks.DTT_BORDERCOLOR;
				}
			}

			/// <summary>Gets or sets the radius of the outline that will be drawn around the text.</summary>
			/// <value>The size of the border.</value>
			public int BorderSize
			{
				get => iBorderSize;
				set
				{
					iBorderSize = value;
					dwMasks |= DrawThemeTextOptionsMasks.DTT_BORDERSIZE;
				}
			}

			/// <summary>Gets or sets the callback function.</summary>
			/// <value>The callback function.</value>
			public DTT_CALLBACK_PROC Callback
			{
				get => pfnDrawTextCallback;
				set
				{
					pfnDrawTextCallback = value;
					dwMasks |= DrawThemeTextOptionsMasks.DTT_CALLBACK;
				}
			}

			/// <summary>Gets or sets the size of a glow that will be drawn on the background prior to any text being drawn.</summary>
			/// <value>The size of the glow.</value>
			public int GlowSize
			{
				get => iGlowSize;
				set
				{
					iGlowSize = value;
					dwMasks |= DrawThemeTextOptionsMasks.DTT_GLOWSIZE;
				}
			}

			/// <summary>Gets or sets the parameter for callback back function specified by <see cref="Callback"/>.</summary>
			/// <value>The parameter.</value>
			public IntPtr LParam
			{
				get => lParam;
				set => lParam = value;
			}

			/// <summary>
			/// Gets or sets a value indicating whether the pRect parameter of the <see cref="DrawThemeTextEx"/> function that uses this
			/// structure will be used as both an in and an out parameter. After the function returns, the pRect parameter will contain the
			/// rectangle that corresponds to the region calculated to be drawn.
			/// </summary>
			/// <value><c>true</c> if returning the calculated rectangle; otherwise, <c>false</c>.</value>
			public bool ReturnCalculatedRectangle
			{
				get => dwMasks.IsFlagSet(DrawThemeTextOptionsMasks.DTT_CALCRECT);
				set => SetFlag(DrawThemeTextOptionsMasks.DTT_CALCRECT, value);
			}

			/// <summary>Gets or sets the color of the shadow drawn behind the text.</summary>
			/// <value>The color of the shadow.</value>
			public COLORREF ShadowColor
			{
				get => crShadow;
				set
				{
					crShadow = value;
					dwMasks |= DrawThemeTextOptionsMasks.DTT_SHADOWCOLOR;
				}
			}

			/// <summary>Gets or sets the amount of offset, in logical coordinates, between the shadow and the text.</summary>
			/// <value>The shadow offset.</value>
			public POINT ShadowOffset
			{
				get => new POINT(ptShadowOffset.X, ptShadowOffset.Y);
				set
				{
					ptShadowOffset = value;
					dwMasks |= DrawThemeTextOptionsMasks.DTT_SHADOWOFFSET;
				}
			}

			/// <summary>Gets or sets the type of the shadow that will be drawn behind the text.</summary>
			/// <value>The type of the shadow.</value>
			public TextShadowType ShadowType
			{
				get => iTextShadowType; set
				{
					iTextShadowType = value;
					dwMasks |= DrawThemeTextOptionsMasks.DTT_SHADOWTYPE;
				}
			}

			/// <summary>Gets or sets the color of the text that will be drawn.</summary>
			/// <value>The color of the text.</value>
			public COLORREF TextColor
			{
				get => crText;
				set
				{
					crText = value;
					dwMasks |= DrawThemeTextOptionsMasks.DTT_TEXTCOLOR;
				}
			}

			/// <summary>Gets an instance with default values set.</summary>
			public static DTTOPTS Default => new DTTOPTS(null);

			private void SetFlag(DrawThemeTextOptionsMasks f, bool value) => dwMasks = dwMasks.SetFlags(f, value);
		}

		/// <summary>Contains an array or list of <c>int</c> data items from a visual style.</summary>
		// typedef struct _INTLIST { int iValueCount; int iValues[MAX_INTLIST_COUNT];} INTLIST, *PINTLIST; https://msdn.microsoft.com/en-us/library/windows/desktop/bb773240(v=vs.85).aspx
		[PInvokeData("UxTheme.h", MSDNShortId = "bb773240")]
		[StructLayout(LayoutKind.Sequential)]
		public struct INTLIST
		{
			/// <summary>
			/// <para>Type: <c>int</c></para>
			/// <para>Number of values in the list.</para>
			/// </summary>
			public int iValueCount;

			/// <summary>
			/// <para>Type: <c>int[MAX_INTLIST_COUNT]</c></para>
			/// <para>
			/// List of integers. The constant MAX_INTLIST_COUNT, by definition, is equal to 402 under Windows Vista, but only 10 under
			/// earlier versions of Windows.
			/// </para>
			/// </summary>
			[MarshalAs(UnmanagedType.ByValArray, SizeConst = 402)]
			public int[] iValues;
		}

		/// <summary>Returned by the GetThemeMargins function to define the margins of windows that have visual styles applied.</summary>
		[PInvokeData("UxTheme.h", MSDNShortId = "bb773244")]
		[StructLayout(LayoutKind.Sequential)]
		public struct MARGINS
		{
			/// <summary>Width of the left border that retains its size.</summary>
			public int cxLeftWidth;

			/// <summary>Width of the right border that retains its size.</summary>
			public int cxRightWidth;

			/// <summary>Height of the top border that retains its size.</summary>
			public int cyTopHeight;

			/// <summary>Height of the bottom border that retains its size.</summary>
			public int cyBottomHeight;
		}

		/// <summary>Undocumented structured used with <see cref="GetThemeTimingFunction"/>.</summary>
		[StructLayout(LayoutKind.Sequential)]
		public struct TA_TIMINGFUNCTION
		{
			/// <summary>The timing function type.</summary>
			public TA_TIMINGFUNCTION_TYPE eTimingFunctionType;
		}

		/// <summary>An animation transform operation.</summary>
		[StructLayout(LayoutKind.Sequential)]
		public struct TA_TRANSFORM
		{
			/// <summary>Undocumented.</summary>
			public uint dwDurationTime;

			/// <summary>Undocumented.</summary>
			public uint dwStartTime;

			/// <summary>Undocumented.</summary>
			public uint dwTimingFunctionId;

			/// <summary>Undocumented.</summary>
			public TA_TRANSFORM_FLAG eFlags;

			/// <summary>Undocumented.</summary>
			public TA_TRANSFORM_TYPE eTransformType;
		}

		/// <summary>Defines options that are used to set window visual style attributes.</summary>
		// typedef struct WTA_OPTIONS { DWORD dwFlags; DWORD dwMask;} WTA_OPTIONS, *PWTA_OPTIONS; https://msdn.microsoft.com/en-us/library/windows/desktop/bb773248(v=vs.85).aspx
		[PInvokeData("Uxtheme.h", MSDNShortId = "bb773248")]
		[StructLayout(LayoutKind.Sequential)]
		public struct WTA_OPTIONS
		{
			/// <summary>
			/// <para>Type: <c><c>DWORD</c></c></para>
			/// <para>A combination of flags that modify window visual style attributes. Can be a combination of the <c>WTNCA</c> constants.</para>
			/// </summary>
			public WTNCA Flags;

			/// <summary>
			/// <para>Type: <c><c>DWORD</c></c></para>
			/// <para>
			/// A bitmask that describes how the values specified in <c>dwFlags</c> should be applied. If the bit corresponding to a value in
			/// <c>dwFlags</c> is 0, that flag will be removed. If the bit is 1, the flag will be added.
			/// </para>
			/// </summary>
			public uint Mask;
		}

		/// <summary>Contains an array or list of <c>int</c> data items from a visual style.</summary>
		// typedef struct _INTLIST { int iValueCount; int iValues[MAX_INTLIST_COUNT];} INTLIST, *PINTLIST; https://msdn.microsoft.com/en-us/library/windows/desktop/bb773240(v=vs.85).aspx
		[PInvokeData("UxTheme.h", MSDNShortId = "bb773240")]
		[StructLayout(LayoutKind.Sequential)]
		private struct INTLIST_OLD
		{
			/// <summary>
			/// <para>Type: <c>int</c></para>
			/// <para>Number of values in the list.</para>
			/// </summary>
			public int iValueCount;

			/// <summary>
			/// <para>Type: <c>int[MAX_INTLIST_COUNT]</c></para>
			/// <para>
			/// List of integers. The constant MAX_INTLIST_COUNT, by definition, is equal to 402 under Windows Vista, but only 10 under
			/// earlier versions of Windows.
			/// </para>
			/// </summary>
			[MarshalAs(UnmanagedType.ByValArray, SizeConst = 10)]
			public int[] iValues;
		}

		/// <summary>Defines the options for the <c>DrawThemeBackgroundEx</c> function.</summary>
		// typedef struct _DTBGOPTS { DWORD dwSize; DWORD dwFlags; RECT rcClip;} DTBGOPTS, *PDTBGOPTS; https://msdn.microsoft.com/en-us/library/windows/desktop/bb773233(v=vs.85).aspx
		[PInvokeData("Uxtheme.h", MSDNShortId = "bb773233")]
		[StructLayout(LayoutKind.Sequential)]
		public class DTBGOPTS
		{
			/// <summary>
			/// <para>Type: <c><c>DWORD</c></c></para>
			/// <para>Size of the structure. Set this to sizeof(DTBGOPTS).</para>
			/// </summary>
			public uint dwSize;

			/// <summary>
			/// <para>Type: <c><c>DWORD</c></c></para>
			/// <para>Flags that specify the selected options. This member can be one of the following:</para>
			/// <para>
			/// <list type="table">
			/// <listheader>
			/// <term>Value</term>
			/// <term>Meaning</term>
			/// </listheader>
			/// <item>
			/// <term>DTBG_CLIPRECT</term>
			/// <term>rcClip specifies the rectangle to which drawing is clipped.</term>
			/// </item>
			/// <item>
			/// <term>DTBG_DRAWSOLID</term>
			/// <term>Deprecated. Draw transparent and alpha images as solid.</term>
			/// </item>
			/// <item>
			/// <term>DTBG_OMITBORDER</term>
			/// <term>Do not draw the border of the part (currently this value is only supported for bgtype=borderfill).</term>
			/// </item>
			/// <item>
			/// <term>DTBG_OMITCONTENT</term>
			/// <term>Do not draw the content area of the part (currently this value is only supported for bgtype=borderfill).</term>
			/// </item>
			/// <item>
			/// <term>DTBG_COMPUTINGREGION</term>
			/// <term>Deprecated.</term>
			/// </item>
			/// <item>
			/// <term>DTBG_MIRRORDC</term>
			/// <term>Assume the hdc is mirrored and flip images as appropriate (currently this value is only supported for bgtype=imagefile).</term>
			/// </item>
			/// <item>
			/// <term>DTBG_NOMIRROR</term>
			/// <term>Do not mirror the output; even in right-to-left (RTL) layout.</term>
			/// </item>
			/// <item>
			/// <term>DTBG_VALIDBITS</term>
			/// <term>DTBG_CLIPRECT | DTBG_DRAWSOLID | DTBG_OMITBORDER | DTBG_OMITCONTENT | DTBG_COMPUTINGREGION | DTBG_MIRRORDC | DTBG_NOMIRROR.</term>
			/// </item>
			/// </list>
			/// </para>
			/// </summary>
			public DrawThemeBackgroundFlags dwFlags;

			/// <summary>
			/// <para>Type: <c><c>RECT</c></c></para>
			/// <para>A <c>RECT</c> that specifies the bounding rectangle of the clip region.</para>
			/// </summary>
			public RECT rcClip;

			/// <summary>Initializes a new instance of the <see cref="DTBGOPTS"/> class.</summary>
			/// <param name="clipRect">The rectangle to which drawing is clipped.</param>
			public DTBGOPTS(RECT? clipRect)
			{
				dwSize = (uint)Marshal.SizeOf(this);
				ClipRectangle = clipRect;
			}

			/// <summary>Gets or sets the bounding rectangle of the clip region.</summary>
			/// <value>The clip rectangle.</value>
			public RECT? ClipRectangle
			{
				get
				{
					RECT r = rcClip;
					return r.IsEmpty ? (RECT?)null : r;
				}
				set
				{
					rcClip = value ?? default(RECT);
					SetFlag(DrawThemeBackgroundFlags.DTBG_CLIPRECT, value.HasValue);
				}
			}

			/// <summary>Gets or sets a value indicating whether omit drawing the border.</summary>
			/// <value><c>true</c> if omit border; otherwise, <c>false</c>.</value>
			public bool OmitBorder { get => dwFlags.IsFlagSet(DrawThemeBackgroundFlags.DTBG_OMITBORDER); set => SetFlag(DrawThemeBackgroundFlags.DTBG_OMITBORDER, value); }

			/// <summary>Gets or sets a value indicating whether omit drawing the content area of the part.</summary>
			/// <value><c>true</c> if omit content area of the part; otherwise, <c>false</c>.</value>
			public bool OmitContent { get => dwFlags.IsFlagSet(DrawThemeBackgroundFlags.DTBG_OMITCONTENT); set => SetFlag(DrawThemeBackgroundFlags.DTBG_OMITCONTENT, value); }

			/// <summary>Gets or sets a value indicating the hdc is mirrored and flip images as appropriate.</summary>
			/// <value><c>true</c> if mirrored; otherwise, <c>false</c>.</value>
			public bool HasMirroredDC { get => dwFlags.IsFlagSet(DrawThemeBackgroundFlags.DTBG_MIRRORDC); set => SetFlag(DrawThemeBackgroundFlags.DTBG_MIRRORDC, value); }

			/// <summary>Gets or sets a value indicating whether to mirror the output; even in right-to-left (RTL) layout.</summary>
			/// <value><c>true</c> if not mirroring; otherwise, <c>false</c>.</value>
			public bool DoNotMirror { get => dwFlags.IsFlagSet(DrawThemeBackgroundFlags.DTBG_NOMIRROR); set => SetFlag(DrawThemeBackgroundFlags.DTBG_NOMIRROR, value); }

			/// <summary>Performs an implicit conversion from <see cref="RECT"/> to <see cref="DTBGOPTS"/>.</summary>
			/// <param name="clipRectangle">The clipping rectangle.</param>
			/// <returns>The result of the conversion.</returns>
			public static implicit operator DTBGOPTS(RECT clipRectangle) => new DTBGOPTS(clipRectangle);

			private void SetFlag(DrawThemeBackgroundFlags f, bool value) => dwFlags = dwFlags.SetFlags(f, value);
		}

		/// <summary>Represents a safe handle for a theme. Use in place of HTHEME.</summary>
		public class SafeHTHEME : SafeHANDLE
		{
			/// <summary>Initializes a new instance of the <see cref="SafeHTHEME"/> class.</summary>
			/// <param name="hTheme">The h theme.</param>
			/// <param name="ownsHandle">if set to <c>true</c> [owns handle].</param>
			public SafeHTHEME(IntPtr hTheme, bool ownsHandle = true) : base(hTheme, ownsHandle) { }

			private SafeHTHEME() : base()
			{
			}

			/// <summary>Performs an implicit conversion from <see cref="SafeHTHEME"/> to <see cref="HTHEME"/>.</summary>
			/// <param name="h">The safe handle instance.</param>
			/// <returns>The result of the conversion.</returns>
			public static implicit operator HTHEME(SafeHTHEME h) => h.handle;

			/// <inheritdoc/>
			protected override bool InternalReleaseHandle() => CloseThemeData(this).Succeeded;
		}
	}
}