using System;
using System.Drawing;
using System.Runtime.InteropServices;
using System.Text;
using Vanara.Extensions;
using static Vanara.PInvoke.Gdi32;
using static Vanara.PInvoke.User32_Gdi;

// ReSharper disable FieldCanBeMadeReadOnly.Global ReSharper disable InconsistentNaming ReSharper disable FieldCanBeMadeReadOnly.Local

namespace Vanara.PInvoke
{
	public static partial class UxTheme
	{
		[UnmanagedFunctionPointer(CallingConvention.Winapi, CharSet = CharSet.Unicode)]
		public delegate int DrawThemeTextCallback(SafeDCHandle hdc, string text, int textLen, ref RECT rc, int flags, IntPtr lParam);

		[Flags]
		public enum DrawThemeBackgroundFlags
		{
			None = 0,

			/// <summary>The ClipRectangle value is defined.</summary>
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

		[Flags]
		public enum DrawThemeParentBackgroundFlags
		{
			None = 0,

			/// <summary>If set, hdc is assumed to be a window DC, not a client DC.</summary>
			DTPB_WINDOWDC = 1,

			/// <summary>
			/// If set, this function sends a WM_CTLCOLORSTATIC message to the parent and uses the brush if one is provided. Otherwise, it uses COLOR_BTNFACE.
			/// </summary>
			DTPB_USECTLCOLORSTATIC = 2,

			/// <summary>If set, this function returns S_OK without sending a WM_CTLCOLORSTATIC message if the parent actually painted on WM_ERASEBKGND.</summary>
			DTPB_USEERASEBKGND = 4
		}

		[Flags]
		public enum DrawThemeTextOptionsMasks
		{
			DTT_TEXTCOLOR = 1,
			DTT_BORDERCOLOR = 2,
			DTT_SHADOWCOLOR = 4,
			DTT_SHADOWTYPE = 8,
			DTT_SHADOWOFFSET = 16,
			DTT_BORDERSIZE = 32,
			DTT_FONTPROP = 64,
			DTT_COLORPROP = 128,
			DTT_STATEID = 256,
			DTT_CALCRECT = 512,
			DTT_APPLYOVERLAY = 1024,
			DTT_GLOWSIZE = 2048,
			DTT_CALLBACK = 4096,
			DTT_COMPOSITED = 8192
		}

		public enum DrawThemeTextSystemFonts
		{
			Caption = 801,
			SmallCaption = 802,
			Menu = 803,
			Status = 804,
			MessageBox = 805,
			IconTitle = 806
		}

		[Flags]
		public enum HitTestOptions : uint
		{
			HTTB_BACKGROUNDSEG = 0x00000000,
			HTTB_FIXEDBORDER = 0x00000002,
			HTTB_CAPTION = 0x00000004,
			HTTB_RESIZINGBORDER_LEFT = 0x00000010,
			HTTB_RESIZINGBORDER_TOP = 0x00000020,
			HTTB_RESIZINGBORDER_RIGHT = 0x00000040,
			HTTB_RESIZINGBORDER_BOTTOM = 0x00000080,
			HTTB_RESIZINGBORDER = (HTTB_RESIZINGBORDER_LEFT | HTTB_RESIZINGBORDER_TOP | HTTB_RESIZINGBORDER_RIGHT | HTTB_RESIZINGBORDER_BOTTOM),
			HTTB_SIZINGTEMPLATE = 0x00000100,
			HTTB_SYSTEMSIZINGMARGINS = 0x00000200,
		}

		public enum IntegerListProperty
		{
			TransitionDuration = 6000
		}

		public enum OpenThemeDataOptions
		{
			None = 0,

			/// <summary>Forces drawn images from this theme to stretch to fit the rectangles specified by drawing functions.</summary>
			OTD_FORCE_RECT_SIZING = 1,

			/// <summary>Allows theme elements to be drawn in the non-client area of the window.</summary>
			OTD_NONCLIENT = 2
		}

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

		public enum TA_PROPERTY
		{
			TAP_FLAGS,
			TAP_TRANSFORMCOUNT,
			TAP_STAGGERDELAY,
			TAP_STAGGERDELAYCAP,
			TAP_STAGGERDELAYFACTOR,
			TAP_ZORDER,
		}

		[Flags]
		public enum TA_PROPERTY_FLAG
		{
			TAPF_NONE = 0x0,
			TAPF_HASSTAGGER = 0x1,
			TAPF_ISRTLAWARE = 0x2,
			TAPF_ALLOWCOLLECTION = 0x4,
			TAPF_HASBACKGROUND = 0x8,
			TAPF_HASPERSPECTIVE = 0x10,
		}

		public enum TA_TIMINGFUNCTION_TYPE
		{
			TTFT_UNDEFINED,
			TTFT_CUBIC_BEZIER,
		}

		[PInvokeData("UxTheme.h")]
		[Flags]
		public enum TA_TRANSFORM_FLAG
		{
			TATF_NONE = 0x0,
			TATF_TARGETVALUES_USER = 0x1,
			TATF_HASINITIALVALUES = 0x2,
			TATF_HASORIGINVALUES = 0x4,
		}

		[PInvokeData("UxTheme.h")]
		public enum TA_TRANSFORM_TYPE
		{
			TATT_TRANSLATE_2D,
			TATT_SCALE_2D,
			TATT_OPACITY,
			TATT_CLIP,
		}

		public enum TextShadowType
		{
			/// <summary>No shadow will be drawn.</summary>
			/// <remarks>TST_NONE</remarks>
			None = 0,

			/// <summary>The shadow will be drawn to appear detailed underneath text.</summary>
			/// <remarks>TST_SINGLE</remarks>
			Single = 1,

			/// <summary>The shadow will be drawn to appear blurred underneath text.</summary>
			/// <remarks>TST_CONTINUOUS</remarks>
			Continuous = 2
		}

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

		public enum ThemeDialogTextureFlags
		{
			/// <summary>Disables background texturing.</summary>
			ETDT_DISABLE = 0x00000001,

			/// <summary>Enables dialog window background texturing. The texturing is defined by a visual style.</summary>
			ETDT_ENABLE = 0x00000002,

			/// <summary>Uses the Tab control texture for the background texture of a dialog window.</summary>
			ETDT_USETABTEXTURE = 0x00000004,

			/// <summary>
			/// Enables dialog window background texturing. The texture is the Tab control texture defined by the visual style. This flag is equivalent to
			/// (ETDT_ENABLE | ETDT_USETABTEXTURE).
			/// </summary>
			ETDT_ENABLETAB = (ETDT_ENABLE | ETDT_USETABTEXTURE),

			/// <summary>Uses the Aero wizard texture for the background texture of a dialog window.</summary>
			ETDT_USEAEROWIZARDTABTEXTURE = 0x00000008,

			/// <summary>ETDT_ENABLE | ETDT_USEAEROWIZARDTABTEXTURE.</summary>
			ETDT_ENABLEAEROWIZARDTAB = (ETDT_ENABLE | ETDT_USEAEROWIZARDTABTEXTURE),

			/// <summary>ETDT_DISABLE | ETDT_ENABLE | ETDT_USETABTEXTURE | ETDT_USEAEROWIZARDTABTEXTURE.</summary>
			ETDT_VALIDBITS = (ETDT_DISABLE | ETDT_ENABLE | ETDT_USETABTEXTURE | ETDT_USEAEROWIZARDTABTEXTURE),
		}

		public enum ThemeProperty
		{
			/// <summary></summary>
			TMT_DIBDATA = 2,

			/// <summary></summary>
			TMT_GLYPHDIBDATA = 8,

			/// <summary></summary>
			TMT_ENUM = 200,

			/// <summary></summary>
			TMT_STRING = 201,

			/// <summary></summary>
			TMT_INT = 202,

			/// <summary></summary>
			TMT_BOOL = 203,

			/// <summary></summary>
			TMT_COLOR = 204,

			/// <summary></summary>
			TMT_MARGINS = 205,

			/// <summary></summary>
			TMT_FILENAME = 206,

			/// <summary></summary>
			TMT_SIZE = 207,

			/// <summary></summary>
			TMT_POSITION = 208,

			/// <summary></summary>
			TMT_RECT = 209,

			/// <summary></summary>
			TMT_FONT = 210,

			/// <summary></summary>
			TMT_INTLIST = 211,

			/// <summary></summary>
			TMT_HBITMAP = 212,

			/// <summary></summary>
			TMT_DISKSTREAM = 213,

			/// <summary></summary>
			TMT_STREAM = 214,

			/// <summary></summary>
			TMT_BITMAPREF = 215,

			/// <summary></summary>
			TMT_FLOAT = 216,

			/// <summary></summary>
			TMT_FLOATLIST = 217,

			/// <summary></summary>
			TMT_COLORSCHEMES = 401,

			/// <summary></summary>
			TMT_SIZES = 402,

			/// <summary></summary>
			TMT_CHARSET = 403,

			/// <summary></summary>
			TMT_NAME = 600,

			/// <summary></summary>
			TMT_DISPLAYNAME = 601,

			/// <summary></summary>
			TMT_TOOLTIP = 602,

			/// <summary></summary>
			TMT_COMPANY = 603,

			/// <summary></summary>
			TMT_AUTHOR = 604,

			/// <summary></summary>
			TMT_COPYRIGHT = 605,

			/// <summary></summary>
			TMT_URL = 606,

			/// <summary></summary>
			TMT_VERSION = 607,

			/// <summary></summary>
			TMT_DESCRIPTION = 608,

			/// <summary></summary>
			TMT_FIRST_RCSTRING_NAME = TMT_DISPLAYNAME,

			/// <summary></summary>
			TMT_LAST_RCSTRING_NAME = TMT_DESCRIPTION,

			/// <summary></summary>
			TMT_CAPTIONFONT = 801,

			/// <summary></summary>
			TMT_SMALLCAPTIONFONT = 802,

			/// <summary></summary>
			TMT_MENUFONT = 803,

			/// <summary></summary>
			TMT_STATUSFONT = 804,

			/// <summary></summary>
			TMT_MSGBOXFONT = 805,

			/// <summary></summary>
			TMT_ICONTITLEFONT = 806,

			/// <summary></summary>
			TMT_HEADING1FONT = 807,

			/// <summary></summary>
			TMT_HEADING2FONT = 808,

			/// <summary></summary>
			TMT_BODYFONT = 809,

			/// <summary></summary>
			TMT_FIRSTFONT = TMT_CAPTIONFONT,

			/// <summary></summary>
			TMT_LASTFONT = TMT_BODYFONT,

			/// <summary></summary>
			TMT_FLATMENUS = 1001,

			/// <summary></summary>
			TMT_FIRSTBOOL = TMT_FLATMENUS,

			/// <summary></summary>
			TMT_LASTBOOL = TMT_FLATMENUS,

			/// <summary></summary>
			TMT_SIZINGBORDERWIDTH = 1201,

			/// <summary></summary>
			TMT_SCROLLBARWIDTH = 1202,

			/// <summary></summary>
			TMT_SCROLLBARHEIGHT = 1203,

			/// <summary></summary>
			TMT_CAPTIONBARWIDTH = 1204,

			/// <summary></summary>
			TMT_CAPTIONBARHEIGHT = 1205,

			/// <summary></summary>
			TMT_SMCAPTIONBARWIDTH = 1206,

			/// <summary></summary>
			TMT_SMCAPTIONBARHEIGHT = 1207,

			/// <summary></summary>
			TMT_MENUBARWIDTH = 1208,

			/// <summary></summary>
			TMT_MENUBARHEIGHT = 1209,

			/// <summary></summary>
			TMT_PADDEDBORDERWIDTH = 1210,

			/// <summary></summary>
			TMT_FIRSTSIZE = TMT_SIZINGBORDERWIDTH,

			/// <summary></summary>
			TMT_LASTSIZE = TMT_PADDEDBORDERWIDTH,

			/// <summary></summary>
			TMT_MINCOLORDEPTH = 1301,

			/// <summary></summary>
			TMT_FIRSTINT = TMT_MINCOLORDEPTH,

			/// <summary></summary>
			TMT_LASTINT = TMT_MINCOLORDEPTH,

			/// <summary></summary>
			TMT_CSSNAME = 1401,

			/// <summary></summary>
			TMT_XMLNAME = 1402,

			/// <summary></summary>
			TMT_LASTUPDATED = 1403,

			/// <summary></summary>
			TMT_ALIAS = 1404,

			/// <summary></summary>
			TMT_FIRSTSTRING = TMT_CSSNAME,

			/// <summary></summary>
			TMT_LASTSTRING = TMT_ALIAS,

			/// <summary></summary>
			TMT_SCROLLBAR = 1601,

			/// <summary></summary>
			TMT_BACKGROUND = 1602,

			/// <summary></summary>
			TMT_ACTIVECAPTION = 1603,

			/// <summary></summary>
			TMT_INACTIVECAPTION = 1604,

			/// <summary></summary>
			TMT_MENU = 1605,

			/// <summary></summary>
			TMT_WINDOW = 1606,

			/// <summary></summary>
			TMT_WINDOWFRAME = 1607,

			/// <summary></summary>
			TMT_MENUTEXT = 1608,

			/// <summary></summary>
			TMT_WINDOWTEXT = 1609,

			/// <summary></summary>
			TMT_CAPTIONTEXT = 1610,

			/// <summary></summary>
			TMT_ACTIVEBORDER = 1611,

			/// <summary></summary>
			TMT_INACTIVEBORDER = 1612,

			/// <summary></summary>
			TMT_APPWORKSPACE = 1613,

			/// <summary></summary>
			TMT_HIGHLIGHT = 1614,

			/// <summary></summary>
			TMT_HIGHLIGHTTEXT = 1615,

			/// <summary></summary>
			TMT_BTNFACE = 1616,

			/// <summary></summary>
			TMT_BTNSHADOW = 1617,

			/// <summary></summary>
			TMT_GRAYTEXT = 1618,

			/// <summary></summary>
			TMT_BTNTEXT = 1619,

			/// <summary></summary>
			TMT_INACTIVECAPTIONTEXT = 1620,

			/// <summary></summary>
			TMT_BTNHIGHLIGHT = 1621,

			/// <summary></summary>
			TMT_DKSHADOW3D = 1622,

			/// <summary></summary>
			TMT_LIGHT3D = 1623,

			/// <summary></summary>
			TMT_INFOTEXT = 1624,

			/// <summary></summary>
			TMT_INFOBK = 1625,

			/// <summary></summary>
			TMT_BUTTONALTERNATEFACE = 1626,

			/// <summary></summary>
			TMT_HOTTRACKING = 1627,

			/// <summary></summary>
			TMT_GRADIENTACTIVECAPTION = 1628,

			/// <summary></summary>
			TMT_GRADIENTINACTIVECAPTION = 1629,

			/// <summary></summary>
			TMT_MENUHILIGHT = 1630,

			/// <summary></summary>
			TMT_MENUBAR = 1631,

			/// <summary></summary>
			TMT_FIRSTCOLOR = TMT_SCROLLBAR,

			/// <summary></summary>
			TMT_LASTCOLOR = TMT_MENUBAR,

			/// <summary></summary>
			TMT_FROMHUE1 = 1801,

			/// <summary></summary>
			TMT_FROMHUE2 = 1802,

			/// <summary></summary>
			TMT_FROMHUE3 = 1803,

			/// <summary></summary>
			TMT_FROMHUE4 = 1804,

			/// <summary></summary>
			TMT_FROMHUE5 = 1805,

			/// <summary></summary>
			TMT_TOHUE1 = 1806,

			/// <summary></summary>
			TMT_TOHUE2 = 1807,

			/// <summary></summary>
			TMT_TOHUE3 = 1808,

			/// <summary></summary>
			TMT_TOHUE4 = 1809,

			/// <summary></summary>
			TMT_TOHUE5 = 1810,

			/// <summary></summary>
			TMT_FROMCOLOR1 = 2001,

			/// <summary></summary>
			TMT_FROMCOLOR2 = 2002,

			/// <summary></summary>
			TMT_FROMCOLOR3 = 2003,

			/// <summary></summary>
			TMT_FROMCOLOR4 = 2004,

			/// <summary></summary>
			TMT_FROMCOLOR5 = 2005,

			/// <summary></summary>
			TMT_TOCOLOR1 = 2006,

			/// <summary></summary>
			TMT_TOCOLOR2 = 2007,

			/// <summary></summary>
			TMT_TOCOLOR3 = 2008,

			/// <summary></summary>
			TMT_TOCOLOR4 = 2009,

			/// <summary></summary>
			TMT_TOCOLOR5 = 2010,

			/// <summary></summary>
			TMT_TRANSPARENT = 2201,

			/// <summary></summary>
			TMT_AUTOSIZE = 2202,

			/// <summary></summary>
			TMT_BORDERONLY = 2203,

			/// <summary></summary>
			TMT_COMPOSITED = 2204,

			/// <summary></summary>
			TMT_BGFILL = 2205,

			/// <summary></summary>
			TMT_GLYPHTRANSPARENT = 2206,

			/// <summary></summary>
			TMT_GLYPHONLY = 2207,

			/// <summary></summary>
			TMT_ALWAYSSHOWSIZINGBAR = 2208,

			/// <summary></summary>
			TMT_MIRRORIMAGE = 2209,

			/// <summary></summary>
			TMT_UNIFORMSIZING = 2210,

			/// <summary></summary>
			TMT_INTEGRALSIZING = 2211,

			/// <summary></summary>
			TMT_SOURCEGROW = 2212,

			/// <summary></summary>
			TMT_SOURCESHRINK = 2213,

			/// <summary></summary>
			TMT_DRAWBORDERS = 2214,

			/// <summary></summary>
			TMT_NOETCHEDEFFECT = 2215,

			/// <summary></summary>
			TMT_TEXTAPPLYOVERLAY = 2216,

			/// <summary></summary>
			TMT_TEXTGLOW = 2217,

			/// <summary></summary>
			TMT_TEXTITALIC = 2218,

			/// <summary></summary>
			TMT_COMPOSITEDOPAQUE = 2219,

			/// <summary></summary>
			TMT_LOCALIZEDMIRRORIMAGE = 2220,

			/// <summary></summary>
			TMT_IMAGECOUNT = 2401,

			/// <summary></summary>
			TMT_ALPHALEVEL = 2402,

			/// <summary></summary>
			TMT_BORDERSIZE = 2403,

			/// <summary></summary>
			TMT_ROUNDCORNERWIDTH = 2404,

			/// <summary></summary>
			TMT_ROUNDCORNERHEIGHT = 2405,

			/// <summary></summary>
			TMT_GRADIENTRATIO1 = 2406,

			/// <summary></summary>
			TMT_GRADIENTRATIO2 = 2407,

			/// <summary></summary>
			TMT_GRADIENTRATIO3 = 2408,

			/// <summary></summary>
			TMT_GRADIENTRATIO4 = 2409,

			/// <summary></summary>
			TMT_GRADIENTRATIO5 = 2410,

			/// <summary></summary>
			TMT_PROGRESSCHUNKSIZE = 2411,

			/// <summary></summary>
			TMT_PROGRESSSPACESIZE = 2412,

			/// <summary></summary>
			TMT_SATURATION = 2413,

			/// <summary></summary>
			TMT_TEXTBORDERSIZE = 2414,

			/// <summary></summary>
			TMT_ALPHATHRESHOLD = 2415,

			/// <summary></summary>
			TMT_WIDTH = 2416,

			/// <summary></summary>
			TMT_HEIGHT = 2417,

			/// <summary></summary>
			TMT_GLYPHINDEX = 2418,

			/// <summary></summary>
			TMT_TRUESIZESTRETCHMARK = 2419,

			/// <summary></summary>
			TMT_MINDPI1 = 2420,

			/// <summary></summary>
			TMT_MINDPI2 = 2421,

			/// <summary></summary>
			TMT_MINDPI3 = 2422,

			/// <summary></summary>
			TMT_MINDPI4 = 2423,

			/// <summary></summary>
			TMT_MINDPI5 = 2424,

			/// <summary></summary>
			TMT_TEXTGLOWSIZE = 2425,

			/// <summary></summary>
			TMT_FRAMESPERSECOND = 2426,

			/// <summary></summary>
			TMT_PIXELSPERFRAME = 2427,

			/// <summary></summary>
			TMT_ANIMATIONDELAY = 2428,

			/// <summary></summary>
			TMT_GLOWINTENSITY = 2429,

			/// <summary></summary>
			TMT_OPACITY = 2430,

			/// <summary></summary>
			TMT_COLORIZATIONCOLOR = 2431,

			/// <summary></summary>
			TMT_COLORIZATIONOPACITY = 2432,

			/// <summary></summary>
			TMT_MINDPI6 = 2433,

			/// <summary></summary>
			TMT_MINDPI7 = 2434,

			/// <summary></summary>
			TMT_GLYPHFONT = 2601,

			/// <summary></summary>
			TMT_IMAGEFILE = 3001,

			/// <summary></summary>
			TMT_IMAGEFILE1 = 3002,

			/// <summary></summary>
			TMT_IMAGEFILE2 = 3003,

			/// <summary></summary>
			TMT_IMAGEFILE3 = 3004,

			/// <summary></summary>
			TMT_IMAGEFILE4 = 3005,

			/// <summary></summary>
			TMT_IMAGEFILE5 = 3006,

			/// <summary></summary>
			TMT_GLYPHIMAGEFILE = 3008,

			/// <summary></summary>
			TMT_IMAGEFILE6 = 3009,

			/// <summary></summary>
			TMT_IMAGEFILE7 = 3010,

			/// <summary></summary>
			TMT_TEXT = 3201,

			/// <summary></summary>
			TMT_CLASSICVALUE = 3202,

			/// <summary></summary>
			TMT_OFFSET = 3401,

			/// <summary></summary>
			TMT_TEXTSHADOWOFFSET = 3402,

			/// <summary></summary>
			TMT_MINSIZE = 3403,

			/// <summary></summary>
			TMT_MINSIZE1 = 3404,

			/// <summary></summary>
			TMT_MINSIZE2 = 3405,

			/// <summary></summary>
			TMT_MINSIZE3 = 3406,

			/// <summary></summary>
			TMT_MINSIZE4 = 3407,

			/// <summary></summary>
			TMT_MINSIZE5 = 3408,

			/// <summary></summary>
			TMT_NORMALSIZE = 3409,

			/// <summary></summary>
			TMT_MINSIZE6 = 3410,

			/// <summary></summary>
			TMT_MINSIZE7 = 3411,

			/// <summary></summary>
			TMT_SIZINGMARGINS = 3601,

			/// <summary></summary>
			TMT_CONTENTMARGINS = 3602,

			/// <summary></summary>
			TMT_CAPTIONMARGINS = 3603,

			/// <summary></summary>
			TMT_BORDERCOLOR = 3801,

			/// <summary></summary>
			TMT_FILLCOLOR = 3802,

			/// <summary></summary>
			TMT_TEXTCOLOR = 3803,

			/// <summary></summary>
			TMT_EDGELIGHTCOLOR = 3804,

			/// <summary></summary>
			TMT_EDGEHIGHLIGHTCOLOR = 3805,

			/// <summary></summary>
			TMT_EDGESHADOWCOLOR = 3806,

			/// <summary></summary>
			TMT_EDGEDKSHADOWCOLOR = 3807,

			/// <summary></summary>
			TMT_EDGEFILLCOLOR = 3808,

			/// <summary></summary>
			TMT_TRANSPARENTCOLOR = 3809,

			/// <summary></summary>
			TMT_GRADIENTCOLOR1 = 3810,

			/// <summary></summary>
			TMT_GRADIENTCOLOR2 = 3811,

			/// <summary></summary>
			TMT_GRADIENTCOLOR3 = 3812,

			/// <summary></summary>
			TMT_GRADIENTCOLOR4 = 3813,

			/// <summary></summary>
			TMT_GRADIENTCOLOR5 = 3814,

			/// <summary></summary>
			TMT_SHADOWCOLOR = 3815,

			/// <summary></summary>
			TMT_GLOWCOLOR = 3816,

			/// <summary></summary>
			TMT_TEXTBORDERCOLOR = 3817,

			/// <summary></summary>
			TMT_TEXTSHADOWCOLOR = 3818,

			/// <summary></summary>
			TMT_GLYPHTEXTCOLOR = 3819,

			/// <summary></summary>
			TMT_GLYPHTRANSPARENTCOLOR = 3820,

			/// <summary></summary>
			TMT_FILLCOLORHINT = 3821,

			/// <summary></summary>
			TMT_BORDERCOLORHINT = 3822,

			/// <summary></summary>
			TMT_ACCENTCOLORHINT = 3823,

			/// <summary></summary>
			TMT_TEXTCOLORHINT = 3824,

			/// <summary></summary>
			TMT_HEADING1TEXTCOLOR = 3825,

			/// <summary></summary>
			TMT_HEADING2TEXTCOLOR = 3826,

			/// <summary></summary>
			TMT_BODYTEXTCOLOR = 3827,

			/// <summary></summary>
			TMT_BGTYPE = 4001,

			/// <summary></summary>
			TMT_BORDERTYPE = 4002,

			/// <summary></summary>
			TMT_FILLTYPE = 4003,

			/// <summary></summary>
			TMT_SIZINGTYPE = 4004,

			/// <summary></summary>
			TMT_HALIGN = 4005,

			/// <summary></summary>
			TMT_CONTENTALIGNMENT = 4006,

			/// <summary></summary>
			TMT_VALIGN = 4007,

			/// <summary></summary>
			TMT_OFFSETTYPE = 4008,

			/// <summary></summary>
			TMT_ICONEFFECT = 4009,

			/// <summary></summary>
			TMT_TEXTSHADOWTYPE = 4010,

			/// <summary></summary>
			TMT_IMAGELAYOUT = 4011,

			/// <summary></summary>
			TMT_GLYPHTYPE = 4012,

			/// <summary></summary>
			TMT_IMAGESELECTTYPE = 4013,

			/// <summary></summary>
			TMT_GLYPHFONTSIZINGTYPE = 4014,

			/// <summary></summary>
			TMT_TRUESIZESCALINGTYPE = 4015,

			/// <summary></summary>
			TMT_USERPICTURE = 5001,

			/// <summary></summary>
			TMT_DEFAULTPANESIZE = 5002,

			/// <summary></summary>
			TMT_BLENDCOLOR = 5003,

			/// <summary></summary>
			TMT_CUSTOMSPLITRECT = 5004,

			/// <summary></summary>
			TMT_ANIMATIONBUTTONRECT = 5005,

			/// <summary></summary>
			TMT_ANIMATIONDURATION = 5006,

			/// <summary></summary>
			TMT_TRANSITIONDURATIONS = 6000,

			/// <summary></summary>
			TMT_SCALEDBACKGROUND = 7001,

			/// <summary></summary>
			TMT_ATLASIMAGE = 8000,

			/// <summary></summary>
			TMT_ATLASINPUTIMAGE = 8001,

			/// <summary></summary>
			TMT_ATLASRECT = 8002,
		}

		public enum THEMESIZE
		{
			/// <summary>Receives the minimum size of a visual style part.</summary>
			TS_MIN,

			/// <summary>Receives the size of the visual style part that will best fit the available space.</summary>
			TS_TRUE,

			/// <summary>Receives the size that the theme manager uses to draw a part.</summary>
			TS_DRAW
		}

		public enum WindowThemeAttributeType
		{
			NonClient = 1,
		}

		[Flags]
		public enum WTNCA
		{
			/// <summary>Do Not Draw The Caption (Text)</summary>
			WTNCA_NODRAWCAPTION = 0x00000001,

			/// <summary>Do Not Draw the Icon</summary>
			WTNCA_NODRAWICON = 0x00000002,

			/// <summary>Do Not Show the System Menu</summary>
			WTNCA_NOSYSMENU = 0x00000004,

			/// <summary>Do Not Mirror the Question mark Symbol</summary>
			WTNCA_NOMIRRORHELP = 0x00000008
		}

		[PInvokeData("UxTheme.h")]
		[DllImport(Lib.UxTheme, ExactSpelling = true)]
		public static extern HRESULT CloseThemeData(IntPtr hTheme);

		[PInvokeData("UxTheme.h")]
		[DllImport(Lib.UxTheme, ExactSpelling = true)]
		[System.Security.SecurityCritical]
		public static extern HRESULT DrawThemeBackground(SafeThemeHandle hTheme, SafeDCHandle hdc, int iPartId, int iStateId, ref RECT pRect, PRECT pClipRect);

		[PInvokeData("UxTheme.h")]
		[DllImport(Lib.UxTheme, ExactSpelling = true)]
		[System.Security.SecurityCritical]
		public static extern HRESULT DrawThemeBackgroundEx(SafeThemeHandle hTheme, SafeDCHandle hdc, int iPartId, int iStateId, ref RECT pRect, DTBGOPTS opts);

		[PInvokeData("UxTheme.h")]
		[DllImport(Lib.UxTheme, ExactSpelling = true)]
		[System.Security.SecurityCritical]
		public static extern HRESULT DrawThemeEdge(SafeThemeHandle hTheme, SafeDCHandle hdc, int iPartId, int iStateId, ref RECT pDestRect, BorderStyles3D uEdge, BorderFlags uFlags, out RECT pContentRect);

		[PInvokeData("UxTheme.h")]
		[DllImport(Lib.UxTheme, ExactSpelling = true)]
		[System.Security.SecurityCritical]
		public static extern HRESULT DrawThemeIcon(SafeThemeHandle hTheme, SafeDCHandle hdc, int iPartId, int iStateId, ref RECT pRect, IntPtr himl, int iImageIndex);

		[PInvokeData("UxTheme.h")]
		[DllImport(Lib.UxTheme, ExactSpelling = true)]
		[System.Security.SecurityCritical]
		public static extern HRESULT DrawThemeParentBackground(HandleRef hwnd, SafeDCHandle hdc, PRECT pRect);

		[PInvokeData("UxTheme.h")]
		[DllImport(Lib.UxTheme, ExactSpelling = true)]
		[System.Security.SecurityCritical]
		public static extern HRESULT DrawThemeParentBackgroundEx(HandleRef hwnd, SafeDCHandle hdc, DrawThemeParentBackgroundFlags dwFlags, PRECT pRect);

		[PInvokeData("UxTheme.h")]
		[DllImport(Lib.UxTheme, ExactSpelling = true, CharSet = CharSet.Unicode)]
		public static extern HRESULT DrawThemeText(SafeThemeHandle hTheme, SafeDCHandle hdc, int iPartId, int iStateId, string text, int textLength, DrawTextFlags textFlags, int textFlags2, ref RECT pRect);

		[PInvokeData("UxTheme.h")]
		[DllImport(Lib.UxTheme, ExactSpelling = true, CharSet = CharSet.Unicode)]
		[System.Security.SecurityCritical]
		public static extern HRESULT DrawThemeTextEx(SafeThemeHandle hTheme, SafeDCHandle hdc, int iPartId, int iStateId, string text, int iCharCount, DrawTextFlags dwFlags, ref RECT pRect, ref DTTOPTS pOptions);

		[PInvokeData("UxTheme.h")]
		[DllImport(Lib.UxTheme, ExactSpelling = true)]
		[System.Security.SecurityCritical]
		public static extern HRESULT EnableThemeDialogTexture(HandleRef hwnd, ThemeDialogTextureFlags dwFlags);

		[PInvokeData("UxTheme.h")]
		[DllImport(Lib.UxTheme, ExactSpelling = true)]
		[System.Security.SecurityCritical]
		public static extern HRESULT EnableTheming([MarshalAs(UnmanagedType.Bool)] bool fEnable);

		[PInvokeData("UxTheme.h")]
		[DllImport(Lib.UxTheme, ExactSpelling = true)]
		[System.Security.SecurityCritical]
		public static extern HRESULT GetCurrentThemeName([MarshalAs(UnmanagedType.LPWStr)] StringBuilder pszThemeFileName, int dwMaxNameChars, [MarshalAs(UnmanagedType.LPWStr)] StringBuilder pszColorBuff, int cchMaxColorChars, [MarshalAs(UnmanagedType.LPWStr)] StringBuilder pszSizeBuff, int cchMaxSizeChars);

		[PInvokeData("UxTheme.h")]
		[DllImport(Lib.UxTheme, ExactSpelling = true)]
		public static extern HRESULT GetThemeAnimationProperty(SafeThemeHandle hTheme, int iStoryboardId, int iTargetId, TA_PROPERTY eProperty, IntPtr pvProperty, uint cbSize, out uint pcbSizeOut);

		[PInvokeData("UxTheme.h")]
		[DllImport(Lib.UxTheme, ExactSpelling = true)]
		public static extern HRESULT GetThemeAnimationTransform(SafeThemeHandle hTheme, int iStoryboardId, int iTargetId, uint dwTransformIndex, ref TA_TRANSFORM pTransform, uint cbSize, out uint pcbSizeOut);

		[PInvokeData("UxTheme.h")]
		[DllImport(Lib.UxTheme, ExactSpelling = true)]
		public static extern ThemeAppProperties GetThemeAppProperties();

		[PInvokeData("UxTheme.h")]
		[DllImport(Lib.UxTheme, ExactSpelling = true)]
		public static extern HRESULT GetThemeBackgroundContentRect(SafeThemeHandle hTheme, SafeDCHandle hdc, int iPartId, int iStateId, ref RECT pBoundingRect, out RECT pContentRect);

		[PInvokeData("UxTheme.h")]
		[DllImport(Lib.UxTheme, ExactSpelling = true)]
		public static extern HRESULT GetThemeBackgroundExtent(SafeThemeHandle hTheme, SafeDCHandle hdc, int iPartId, int iStateId, ref RECT pContentRect, out RECT pExtentRect);

		[PInvokeData("UxTheme.h")]
		[DllImport(Lib.UxTheme, ExactSpelling = true)]
		public static extern HRESULT GetThemeBackgroundRegion(SafeThemeHandle hTheme, SafeDCHandle hdc, int iPartId, int iStateId, ref RECT pRect, out IntPtr pRegion);

		[PInvokeData("UxTheme.h")]
		[DllImport(Lib.UxTheme, ExactSpelling = true)]
		public static extern HRESULT GetThemeBitmap(SafeThemeHandle hTheme, SafeDCHandle hdc, int iPartId, int iStateId, int iPropId, int dwFlags, out IntPtr phBitmap);

		[PInvokeData("UxTheme.h")]
		[DllImport(Lib.UxTheme, ExactSpelling = true)]
		public static extern HRESULT GetThemeBool(SafeThemeHandle hTheme, int iPartId, int iStateId, int iPropId, [MarshalAs(UnmanagedType.Bool)] out bool pfVal);

		[PInvokeData("UxTheme.h")]
		[DllImport(Lib.UxTheme, ExactSpelling = true)]
		public static extern HRESULT GetThemeColor(SafeThemeHandle hTheme, int iPartId, int iStateId, int iPropId, out COLORREF pColor);

		[PInvokeData("UxTheme.h")]
		[DllImport(Lib.UxTheme, ExactSpelling = true, CharSet = CharSet.Unicode)]
		public static extern HRESULT GetThemeDocumentationProperty(string pszThemeName, string pszPropertyName, out StringBuilder pszValueBuff, int cchMaxValChars);

		[PInvokeData("UxTheme.h")]
		[DllImport(Lib.UxTheme, ExactSpelling = true)]
		public static extern HRESULT GetThemeEnumValue(SafeThemeHandle hTheme, int iPartId, int iStateId, int iPropId, out int piVal);

		[PInvokeData("UxTheme.h")]
		[DllImport(Lib.UxTheme, ExactSpelling = true, CharSet = CharSet.Unicode)]
		public static extern HRESULT GetThemeFilename(SafeThemeHandle hTheme, int iPartId, int iStateId, int iPropId, ref StringBuilder pszBuff, int buffLength);

		[PInvokeData("UxTheme.h")]
		[DllImport(Lib.UxTheme, ExactSpelling = true)]
		public static extern HRESULT GetThemeInt(SafeThemeHandle hTheme, int iPartId, int iStateId, int iPropId, out int piVal);

		public static int[] GetThemeIntList(SafeThemeHandle hTheme, int partId, int stateId, int propId)
		{
			if (Environment.OSVersion.Version.Major < 6)
			{
				INTLIST_OLD l;
				if (0 != GetThemeIntListPreVista(hTheme, partId, stateId, propId, out l))
					return null;
				var outlist = new int[l.iValueCount];
				Array.Copy(l.iValues, outlist, l.iValueCount);
				return outlist;
			}
			else
			{
				INTLIST l;
				if (0 != GetThemeIntList(hTheme, partId, stateId, propId, out l))
					return null;
				var outlist = new int[l.iValueCount];
				Array.Copy(l.iValues, outlist, l.iValueCount);
				return outlist;
			}
		}

		[PInvokeData("UxTheme.h")]
		[DllImport(Lib.UxTheme, ExactSpelling = true)]
		[System.Security.SecurityCritical]
		public static extern HRESULT GetThemeMargins(SafeThemeHandle hTheme, SafeDCHandle hdc, int iPartId, int iStateId, int iPropId, PRECT prc, out MARGINS pMargins);

		[PInvokeData("UxTheme.h")]
		[DllImport(Lib.UxTheme, ExactSpelling = true)]
		public static extern HRESULT GetThemeMetric(SafeThemeHandle hTheme, SafeDCHandle hdc, int iPartId, int iStateId, int iPropId, out int piVal);

		[PInvokeData("UxTheme.h")]
		[DllImport(Lib.UxTheme, ExactSpelling = true)]
		public static extern HRESULT GetThemePartSize(SafeThemeHandle hTheme, SafeDCHandle hdc, int part, int state, PRECT pRect, THEMESIZE eSize, out SIZE size);

		[PInvokeData("UxTheme.h")]
		[DllImport(Lib.UxTheme, ExactSpelling = true)]
		public static extern HRESULT GetThemePosition(SafeThemeHandle hTheme, int iPartId, int iStateId, int iPropId, out Point piVal);

		[PInvokeData("UxTheme.h")]
		[DllImport(Lib.UxTheme, ExactSpelling = true)]
		public static extern HRESULT GetThemePropertyOrigin(SafeThemeHandle hTheme, int iPartId, int iStateId, int iPropId, out PROPERTYORIGIN pOrigin);

		[PInvokeData("UxTheme.h")]
		[DllImport(Lib.UxTheme, ExactSpelling = true)]
		public static extern HRESULT GetThemeRect(SafeThemeHandle hTheme, int iPartId, int iStateId, int iPropId, out RECT pRect);

		[PInvokeData("UxTheme.h")]
		[DllImport(Lib.UxTheme, ExactSpelling = true)]
		public static extern HRESULT GetThemeStream(SafeThemeHandle hTheme, int iPartId, int iStateId, int iPropId, [MarshalAs(UnmanagedType.LPArray, ArraySubType = UnmanagedType.U1, SizeParamIndex = 5)] out byte[] pvStream, out int cbStream, IntPtr hInst);

		[DllImport(Lib.UxTheme, ExactSpelling = true)]
		public static extern HRESULT GetThemeString(SafeThemeHandle hTheme, int iPartId, int iStateId, int iPropId, [MarshalAs(UnmanagedType.LPWStr)] StringBuilder themeString, int themeStringLength);

		[PInvokeData("UxTheme.h")]
		[DllImport(Lib.UxTheme, ExactSpelling = true)]
		[return: MarshalAs(UnmanagedType.Bool)]
		public static extern bool GetThemeSysBool(SafeThemeHandle hTheme, int iBoolID);

		[PInvokeData("UxTheme.h")]
		[DllImport(Lib.UxTheme, ExactSpelling = true)]
		public static extern COLORREF GetThemeSysColor(SafeThemeHandle hTheme, SystemColorIndex iColorID);

		[PInvokeData("UxTheme.h")]
		[DllImport(Lib.UxTheme, ExactSpelling = true)]
		public static extern IntPtr GetThemeSysColorBrush(SafeThemeHandle hTheme, SystemColorIndex iColorID);

		[DllImport(Lib.UxTheme, ExactSpelling = true)]
		public static extern HRESULT GetThemeSysInt(SafeThemeHandle hTheme, int iIntID, out int piVal);

		[PInvokeData("UxTheme.h")]
		[DllImport(Lib.UxTheme, ExactSpelling = true)]
		public static extern int GetThemeSysSize(SafeThemeHandle hTheme, int iSizeID);

		[PInvokeData("UxTheme.h")]
		[DllImport(Lib.UxTheme, ExactSpelling = true)]
		public static extern HRESULT GetThemeSysString(SafeThemeHandle hTheme, int iStringID, [MarshalAs(UnmanagedType.LPWStr)] StringBuilder pszStringBuff, int cchMaxStringChars);

		[PInvokeData("UxTheme.h")]
		[DllImport(Lib.UxTheme, ExactSpelling = true, CharSet = CharSet.Unicode)]
		public static extern HRESULT GetThemeTextExtent(SafeThemeHandle hTheme, SafeDCHandle hdc, int iPartId, int iStateId, string pszText, int iCharCount, DrawTextFlags dwTextFlags, PRECT pBoundingRect, out RECT pExtentRect);

		[PInvokeData("UxTheme.h")]
		[DllImport(Lib.UxTheme, ExactSpelling = true, CharSet = CharSet.Unicode)]
		public static extern HRESULT GetThemeTextMetrics(SafeThemeHandle hTheme, SafeDCHandle hdc, int iPartId, int iStateId, out TEXTMETRIC ptm);

		[PInvokeData("UxTheme.h")]
		[DllImport(Lib.UxTheme, ExactSpelling = true)]
		public static extern HRESULT GetThemeTimingFunction(SafeThemeHandle hTheme, int iTimingFunctionId, out TA_TIMINGFUNCTION pTimingFunction, uint cbSize, out uint pcbSizeOut);

		[PInvokeData("UxTheme.h")]
		[DllImport(Lib.UxTheme, ExactSpelling = true)]
		[System.Security.SecurityCritical]
		public static extern HRESULT GetThemeTransitionDuration(SafeThemeHandle hTheme, int iPartId, int iStateIdFrom, int iStateIdTo, int iPropId, out uint pdwDuration);

		[PInvokeData("UxTheme.h")]
		[DllImport(Lib.UxTheme, ExactSpelling = true)]
		public static extern IntPtr GetWindowTheme(HandleRef hWnd);

		[PInvokeData("UxTheme.h")]
		[DllImport(Lib.UxTheme, ExactSpelling = true)]
		public static extern HRESULT HitTestThemeBackground(SafeThemeHandle hTheme, SafeDCHandle hdc, int iPartId, int iStateId, HitTestOptions dwOptions, ref RECT pRect, IntPtr hrgn, Point ptTest, out HitTestValues pwHitTestCode);

		[PInvokeData("UxTheme.h")]
		[DllImport(Lib.UxTheme, ExactSpelling = true)]
		[return: MarshalAs(UnmanagedType.Bool)]
		public static extern bool IsAppThemed();

		[PInvokeData("UxTheme.h")]
		[DllImport(Lib.UxTheme, ExactSpelling = true)]
		[return: MarshalAs(UnmanagedType.Bool)]
		public static extern bool IsCompositionActive();

		[PInvokeData("UxTheme.h")]
		[DllImport(Lib.UxTheme, ExactSpelling = true)]
		[return: MarshalAs(UnmanagedType.Bool)]
		public static extern bool IsThemeActive();

		[PInvokeData("UxTheme.h")]
		[DllImport(Lib.UxTheme, ExactSpelling = true)]
		[return: MarshalAs(UnmanagedType.Bool)]
		public static extern bool IsThemeBackgroundPartiallyTransparent(SafeThemeHandle hTheme, int iPartId, int iStateId);

		[PInvokeData("UxTheme.h")]
		[DllImport(Lib.UxTheme, ExactSpelling = true)]
		[return: MarshalAs(UnmanagedType.Bool)]
		public static extern bool IsThemeDialogTextureEnabled(HandleRef hWnd);

		[PInvokeData("UxTheme.h")]
		[DllImport(Lib.UxTheme, ExactSpelling = true)]
		[return: MarshalAs(UnmanagedType.Bool)]
		public static extern bool IsThemePartDefined(SafeThemeHandle hTheme, int iPartId, int iStateId);

		[PInvokeData("UxTheme.h")]
		[DllImport(Lib.UxTheme, ExactSpelling = true, CharSet = CharSet.Unicode)]
		public static extern SafeThemeHandle OpenThemeData(HandleRef hWnd, string classList);

		[PInvokeData("UxTheme.h")]
		[DllImport(Lib.UxTheme, ExactSpelling = true, CharSet = CharSet.Unicode)]
		public static extern SafeThemeHandle OpenThemeDataEx(HandleRef hWnd, string classList, OpenThemeDataOptions dwFlags);

		[PInvokeData("UxTheme.h")]
		[DllImport(Lib.UxTheme, ExactSpelling = true)]
		public static extern void SetThemeAppProperties(ThemeAppProperties dwFlags);

		[PInvokeData("UxTheme.h")]
		[DllImport(Lib.UxTheme, ExactSpelling = true, CharSet = CharSet.Unicode)]
		[System.Security.SecurityCritical]
		public static extern HRESULT SetWindowTheme(HandleRef hWnd, string pszSubAppName, string pszSubIdList);

		/// <summary>Sets attributes to control how visual styles are applied to a specified window.</summary>
		/// <param name="hWnd">Handle to a window to apply changes to.</param>
		/// <param name="eAttribute">
		/// Value of type WINDOWTHEMEATTRIBUTETYPE that specifies the type of attribute to set. The value of this parameter determines the type of data that
		/// should be passed in the pvAttribute parameter.
		/// </param>
		/// <param name="pvAttribute">A pointer that specifies attributes to set. Type is determined by the value of the eAttribute value.</param>
		/// <param name="cbAttribute">Specifies the size, in bytes, of the data pointed to by pvAttribute.</param>
		/// <returns>If this function succeeds, it returns S_OK. Otherwise, it returns an HRESULT error code.</returns>
		[PInvokeData("UxTheme.h")]
		[DllImport(Lib.UxTheme, ExactSpelling = true)]
		[System.Security.SecurityCritical]
		public static extern HRESULT SetWindowThemeAttribute(HandleRef hWnd, WindowThemeAttributeType eAttribute, ref WTA_OPTIONS pvAttribute, int cbAttribute);

		/// <summary>Sets attributes to control how visual styles are applied to a specified window.</summary>
		/// <param name="hWnd">Handle to a window to apply changes to.</param>
		/// <param name="ncAttrs">A combination of flags that modify window visual style attributes.</param>
		/// <param name="activate">if set to <c>true</c> add the flag to the window attributes, otherwise remove the flag.</param>
		public static void SetWindowThemeNonClientAttributes(HandleRef hWnd, WTNCA ncAttrs, bool activate = true)
		{
			var opt = new WTA_OPTIONS { Flags = ncAttrs, Mask = activate ? (int)ncAttrs : 0 };
			SetWindowThemeAttribute(hWnd, WindowThemeAttributeType.NonClient, ref opt, Marshal.SizeOf(opt)).ThrowIfFailed();
		}

		[PInvokeData("UxTheme.h")]
		[DllImport(Lib.UxTheme, ExactSpelling = true)]
		private static extern HRESULT GetThemeIntList(SafeThemeHandle hTheme, int iPartId, int iStateId, int iPropId, out INTLIST pIntList);

		[PInvokeData("UxTheme.h")]
		[DllImport(Lib.UxTheme, ExactSpelling = true, EntryPoint = "GetThemeIntList")]
		private static extern HRESULT GetThemeIntListPreVista(SafeThemeHandle hTheme, int iPartId, int iStateId, int iPropId, out INTLIST_OLD pIntList);

		/// <summary>Defines the options for the <see cref="DrawThemeTextEx"/> function.</summary>
		[StructLayout(LayoutKind.Sequential)]
		public struct DTTOPTS
		{
			public uint dwSize;
			public DrawThemeTextOptionsMasks dwMasks;
			public COLORREF crText;
			public COLORREF crBorder;
			public COLORREF crShadow;
			public TextShadowType iTextShadowType;
			public Point ptShadowOffset;
			public int iBorderSize;
			public int iFontPropId;
			public int iColorPropId;
			public int iStateId;

			[MarshalAs(UnmanagedType.Bool)]
			public bool fApplyOverlay;

			public int iGlowSize;

			[MarshalAs(UnmanagedType.FunctionPtr)]
			public DrawThemeTextCallback pfnDrawTextCallback;

			public IntPtr lParam;

			/// <summary>Initializes a new instance of the <see cref="DTTOPTS"/> struct.</summary>
			/// <param name="shouldBeNull">This value must be specified to initialize. Use null.</param>
			public DTTOPTS(byte? shouldBeNull) : this()
			{
				dwSize = (uint)Marshal.SizeOf(typeof(DTTOPTS));
			}

			/// <summary>Gets or sets a value that specifies an alternate color property to use when drawing text.</summary>
			/// <value>The alternate color of the text.</value>
			public int AlternateColorProperty
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
			public DrawThemeTextSystemFonts AlternateFont
			{
				get => (DrawThemeTextSystemFonts)iFontPropId;
				set
				{
					iFontPropId = (int)value;
					dwMasks |= DrawThemeTextOptionsMasks.DTT_FONTPROP;
				}
			}

			/// <summary>
			/// Gets or sets a value indicating whether to draw text with antialiased alpha. Use of this flag requires a top-down DIB section. This flag works
			/// only if the HDC passed to function DrawThemeTextEx has a top-down DIB section currently selected in it. For more information, see
			/// Device-Independent Bitmaps.
			/// </summary>
			/// <value><c>true</c> if antialiased alpha; otherwise, <c>false</c>.</value>
			public bool AntiAliasedAlpha
			{
				get => dwMasks.IsFlagSet(DrawThemeTextOptionsMasks.DTT_COMPOSITED);
				set => SetFlag(DrawThemeTextOptionsMasks.DTT_COMPOSITED, value);
			}

			/// <summary>
			/// Gets or sets a value indicating whether text will be drawn on top of the shadow and outline effects ( <c>true</c>) or if just the shadow and
			/// outline effects will be drawn ( <c>false</c>).
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
			public Color BorderColor
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
			public DrawThemeTextCallback Callback
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
			/// Gets or sets a value indicating whether the pRect parameter of the <see cref="DrawThemeTextEx"/> function that uses this structure will be used
			/// as both an in and an out parameter. After the function returns, the pRect parameter will contain the rectangle that corresponds to the region
			/// calculated to be drawn.
			/// </summary>
			/// <value><c>true</c> if returning the calculated rectangle; otherwise, <c>false</c>.</value>
			public bool ReturnCalculatedRectangle
			{
				get => dwMasks.IsFlagSet(DrawThemeTextOptionsMasks.DTT_CALCRECT);
				set => SetFlag(DrawThemeTextOptionsMasks.DTT_CALCRECT, value);
			}

			/// <summary>Gets or sets the color of the shadow drawn behind the text.</summary>
			/// <value>The color of the shadow.</value>
			public Color ShadowColor
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
			public Point ShadowOffset
			{
				get => new Point(ptShadowOffset.X, ptShadowOffset.Y);
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
			public Color TextColor
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

			private void SetFlag(DrawThemeTextOptionsMasks f, bool value)
			{
				dwMasks = dwMasks.SetFlags(f, value);
			}
		}

		[PInvokeData("UxTheme.h")]
		[StructLayout(LayoutKind.Sequential)]
		public struct MARGINS
		{
			public int cxLeftWidth;
			public int cxRightWidth;
			public int cyTopHeight;
			public int cyBottomHeight;
		}

		[StructLayout(LayoutKind.Sequential)]
		public struct TA_TIMINGFUNCTION
		{
			public TA_TIMINGFUNCTION_TYPE eTimingFunctionType;
		}

		[PInvokeData("UxTheme.h")]
		[StructLayout(LayoutKind.Sequential)]
		public struct TA_TRANSFORM
		{
			public uint dwDurationTime;
			public uint dwStartTime;
			public uint dwTimingFunctionId;
			public TA_TRANSFORM_FLAG eFlags;
			public TA_TRANSFORM_TYPE eTransformType;
		}

		/// <summary>The Options of What Attributes to Add/Remove</summary>
		[StructLayout(LayoutKind.Sequential)]
		public struct WTA_OPTIONS
		{
			public WTNCA Flags;
			public int Mask;
		}

		[StructLayout(LayoutKind.Sequential)]
		private struct INTLIST
		{
			public int iValueCount;

			[MarshalAs(UnmanagedType.ByValArray, SizeConst = 402)]
			public int[] iValues;
		}

		[StructLayout(LayoutKind.Sequential)]
		private struct INTLIST_OLD
		{
			public int iValueCount;

			[MarshalAs(UnmanagedType.ByValArray, SizeConst = 10)]
			public int[] iValues;
		}

		/// <summary>Defines the options for the DrawThemeBackgroundEx function.</summary>
		[StructLayout(LayoutKind.Sequential)]
		public class DTBGOPTS
		{
			public uint dwSize;
			public DrawThemeBackgroundFlags dwFlags;
			public RECT rcClip;

			/// <summary>Initializes a new instance of the <see cref="DTBGOPTS"/> class.</summary>
			/// <param name="clipRect">The rectangle to which drawing is clipped.</param>
			public DTBGOPTS(Rectangle? clipRect)
			{
				dwSize = (uint)Marshal.SizeOf(this);
				ClipRectangle = clipRect;
			}

			/// <summary>Gets or sets the bounding rectangle of the clip region.</summary>
			/// <value>The clip rectangle.</value>
			public Rectangle? ClipRectangle
			{
				get
				{
					Rectangle r = rcClip;
					return r.IsEmpty ? (Rectangle?)null : r;
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

			/// <summary>Performs an implicit conversion from <see cref="Rectangle"/> to <see cref="DTBGOPTS"/>.</summary>
			/// <param name="clipRectangle">The clipping rectangle.</param>
			/// <returns>The result of the conversion.</returns>
			public static implicit operator DTBGOPTS(Rectangle clipRectangle) => new DTBGOPTS(clipRectangle);

			private void SetFlag(DrawThemeBackgroundFlags f, bool value)
			{
				dwFlags = dwFlags.SetFlags(f, value);
			}
		}

		/// <summary>Represents a safe handle for a theme. Use in place of HTHEME.</summary>
		public class SafeThemeHandle : Vanara.InteropServices.GenericSafeHandle
		{
			public SafeThemeHandle() : this(IntPtr.Zero) { }

			public SafeThemeHandle(IntPtr hTheme, bool ownsHandle = true) : base(hTheme, p => CloseThemeData(p) == 0, ownsHandle) { }
		}
	}
}