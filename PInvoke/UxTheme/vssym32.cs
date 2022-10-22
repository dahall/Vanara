using System;
using Vanara.InteropServices;

namespace Vanara.PInvoke
{
#pragma warning disable CS1591 // Missing XML comment for publicly visible type or member
	public static partial class UxTheme
	{
		/// <summary>The basic drawing type for this part.</summary>
		public enum BGTYPE
		{
			BT_IMAGEFILE = 0,
			BT_BORDERFILL = 1,
			BT_NONE = 2,
		}

		/// <summary>The type of border drawn if this part is a border fill.</summary>
		public enum BORDERTYPE
		{
			BT_RECT = 0,
			BT_ROUNDRECT = 1,
			BT_ELLIPSE = 2,
		}

		/// <summary>The alignment of text in the caption associated with this part.</summary>
		public enum CONTENTALIGNMENT
		{
			CA_LEFT = 0,
			CA_CENTER = 1,
			CA_RIGHT = 2,
		}

		/// <summary>The type of fill shape drawn if this part is a border fill.</summary>
		public enum FILLTYPE
		{
			FT_SOLID = 0,
			FT_VERTGRADIENT = 1,
			FT_HORZGRADIENT = 2,
			FT_RADIALGRADIENT = 3,
			FT_TILEIMAGE = 4,
		}

		/// <summary>The type of method used to select between different-sized glyphs.</summary>
		public enum GLYPHFONTSIZINGTYPE
		{
			GFST_NONE = 0,
			GFST_SIZE = 1,
			GFST_DPI = 2,
		}

		/// <summary>The type of glyph drawn on this part.</summary>
		public enum GLYPHTYPE
		{
			GT_NONE = 0,
			GT_IMAGEGLYPH = 1,
			GT_FONTGLYPH = 2,
		}

		/// <summary>The horizontal alignment if this part uses a true-size image.</summary>
		public enum HALIGN
		{
			HA_LEFT = 0,
			HA_CENTER = 1,
			HA_RIGHT = 2,
		}

		/// <summary>The type of effect to be displayed when this part is drawn using DrawThemeIcon.</summary>
		public enum ICONEFFECT
		{
			ICE_NONE = 0,
			ICE_GLOW = 1,
			ICE_SHADOW = 2,
			ICE_PULSE = 3,
			ICE_ALPHA = 4,
		}

		/// <summary>The type of alignment used when multiple images are drawn.</summary>
		public enum IMAGELAYOUT
		{
			IL_VERTICAL = 0,
			IL_HORIZONTAL = 1,
		}

		/// <summary>The type of method used to select between sized images for this part. See the TMT_IMAGEFILE1 value of GetThemeFilename.</summary>
		public enum IMAGESELECTTYPE
		{
			IST_NONE = 0,
			IST_SIZE = 1,
			IST_DPI = 2,
		}

		/// <summary>The alignment of this part on the window.</summary>
		public enum OFFSETTYPE
		{
			OT_TOPLEFT = 0,
			OT_TOPRIGHT = 1,
			OT_TOPMIDDLE = 2,
			OT_BOTTOMLEFT = 3,
			OT_BOTTOMRIGHT = 4,
			OT_BOTTOMMIDDLE = 5,
			OT_MIDDLELEFT = 6,
			OT_MIDDLERIGHT = 7,
			OT_LEFTOFCAPTION = 8,
			OT_RIGHTOFCAPTION = 9,
			OT_LEFTOFLASTBUTTON = 10,
			OT_RIGHTOFLASTBUTTON = 11,
			OT_ABOVELASTBUTTON = 12,
			OT_BELOWLASTBUTTON = 13,
		}

		/// <summary>The method used to size an image if this part uses an image file.</summary>
		public enum SIZINGTYPE
		{
			ST_TRUESIZE = 0,
			ST_STRETCH = 1,
			ST_TILE = 2,
		}

		/// <summary>The type of shadow effect to draw behind text associated with this part.</summary>
		public enum TEXTSHADOWTYPE
		{
			/// <summary>No shadow will be drawn.</summary>
			TST_NONE = 0,

			/// <summary>The shadow will be drawn to appear detailed underneath text.</summary>
			TST_SINGLE = 1,

			/// <summary>The shadow will be drawn to appear blurred underneath text.</summary>
			TST_CONTINUOUS = 2,
		}

		/// <summary>TMT_ values for UxTheme methods.</summary>
		public enum ThemeProperty
		{
			/// <summary>The background image.</summary>
			[CorrespondingType(typeof(IntPtr))]
			TMT_DIBDATA = 2,

			/// <summary>The glyph image drawn on top of the background, if present.</summary>
			[CorrespondingType(typeof(IntPtr))]
			TMT_GLYPHDIBDATA = 3,

			/// <summary>Enumerated value</summary>
			TMT_ENUM = 200,

			/// <summary>Unicode string</summary>
			TMT_STRING = 201,

			/// <summary>Signed number</summary>
			TMT_INT = 202,

			/// <summary>TRUE or FALSE</summary>
			TMT_BOOL = 203,

			/// <summary>RGB color value</summary>
			TMT_COLOR = 204,

			/// <summary>Margins: left, top, right, and bottom</summary>
			TMT_MARGINS = 205,

			/// <summary>Filename relative to the theme directory</summary>
			TMT_FILENAME = 206,

			/// <summary>Size of an item</summary>
			TMT_SIZE = 207,

			/// <summary>Location of an item</summary>
			TMT_POSITION = 208,

			/// <summary>Size and location of a rectangle</summary>
			TMT_RECT = 209,

			/// <summary>Font description</summary>
			TMT_FONT = 210,

			/// <summary>List of integers</summary>
			TMT_INTLIST = 211,

			/// <summary>Bitmap</summary>
			[CorrespondingType(typeof(IntPtr))]
			TMT_HBITMAP = 212,

			/// <summary>Disk stream</summary>
			[CorrespondingType(typeof(byte[]))]
			TMT_DISKSTREAM = 213,

			/// <summary>Stream - Valid for GetThemeStream.</summary>
			[CorrespondingType(typeof(byte[]))]
			TMT_STREAM = 214,

			/// <summary>Undocumented</summary>
			TMT_BITMAPREF = 215,

			/// <summary>A float value.</summary>
			TMT_FLOAT = 216,

			/// <summary>A list of float values.</summary>
			TMT_FLOATLIST = 217,

			/// <summary></summary>
			[CorrespondingType(typeof(string))]
			TMT_COLORSCHEMES = 401,

			/// <summary></summary>
			[CorrespondingType(typeof(string))]
			TMT_SIZES = 402,

			/// <summary></summary>
			TMT_CHARSET = 403,

			/// <summary></summary>
			[CorrespondingType(typeof(string))]
			TMT_NAME = 600,

			/// <summary></summary>
			[CorrespondingType(typeof(string))]
			TMT_DISPLAYNAME = 601,

			/// <summary></summary>
			[CorrespondingType(typeof(string))]
			TMT_TOOLTIP = 602,

			/// <summary></summary>
			[CorrespondingType(typeof(string))]
			TMT_COMPANY = 603,

			/// <summary></summary>
			[CorrespondingType(typeof(string))]
			TMT_AUTHOR = 604,

			/// <summary></summary>
			[CorrespondingType(typeof(string))]
			TMT_COPYRIGHT = 605,

			/// <summary></summary>
			[CorrespondingType(typeof(string))]
			TMT_URL = 606,

			/// <summary></summary>
			[CorrespondingType(typeof(string))]
			TMT_VERSION = 607,

			/// <summary></summary>
			[CorrespondingType(typeof(string))]
			TMT_DESCRIPTION = 608,

			/// <summary></summary>
			TMT_FIRST_RCSTRING_NAME = TMT_DISPLAYNAME,

			/// <summary></summary>
			TMT_LAST_RCSTRING_NAME = TMT_DESCRIPTION,

			/// <summary></summary>
			[CorrespondingType(typeof(LOGFONT))]
			TMT_CAPTIONFONT = 801,

			/// <summary></summary>
			[CorrespondingType(typeof(LOGFONT))]
			TMT_SMALLCAPTIONFONT = 802,

			/// <summary></summary>
			[CorrespondingType(typeof(LOGFONT))]
			TMT_MENUFONT = 803,

			/// <summary></summary>
			[CorrespondingType(typeof(LOGFONT))]
			TMT_STATUSFONT = 804,

			/// <summary></summary>
			[CorrespondingType(typeof(LOGFONT))]
			TMT_MSGBOXFONT = 805,

			/// <summary></summary>
			[CorrespondingType(typeof(LOGFONT))]
			TMT_ICONTITLEFONT = 806,

			/// <summary></summary>
			[CorrespondingType(typeof(LOGFONT))]
			TMT_HEADING1FONT = 807,

			/// <summary></summary>
			[CorrespondingType(typeof(LOGFONT))]
			TMT_HEADING2FONT = 808,

			/// <summary></summary>
			[CorrespondingType(typeof(LOGFONT))]
			TMT_BODYFONT = 809,

			/// <summary></summary>
			TMT_FIRSTFONT = TMT_CAPTIONFONT,

			/// <summary></summary>
			TMT_LASTFONT = TMT_BODYFONT,

			/// <summary>
			/// Describes how menus are drawn. If TRUE, menus are drawn without shadows. If FALSE, menus have shadows underneath them.
			/// </summary>
			[CorrespondingType(typeof(bool))]
			TMT_FLATMENUS = 1001,

			/// <summary></summary>
			TMT_FIRSTBOOL = TMT_FLATMENUS,

			/// <summary></summary>
			TMT_LASTBOOL = TMT_FLATMENUS,

			/// <summary>Width of a sizing border.</summary>
			[CorrespondingType(typeof(SIZE))]
			TMT_SIZINGBORDERWIDTH = 1201,

			/// <summary>Scroll bar width.</summary>
			[CorrespondingType(typeof(SIZE))]
			TMT_SCROLLBARWIDTH = 1202,

			/// <summary>Scroll bar height.</summary>
			[CorrespondingType(typeof(SIZE))]
			TMT_SCROLLBARHEIGHT = 1203,

			/// <summary>Caption bar width.</summary>
			[CorrespondingType(typeof(SIZE))]
			TMT_CAPTIONBARWIDTH = 1204,

			/// <summary>Caption bar height.</summary>
			[CorrespondingType(typeof(SIZE))]
			TMT_CAPTIONBARHEIGHT = 1205,

			/// <summary>Caption bar width.</summary>
			[CorrespondingType(typeof(SIZE))]
			TMT_SMCAPTIONBARWIDTH = 1206,

			/// <summary>Caption bar height.</summary>
			[CorrespondingType(typeof(SIZE))]
			TMT_SMCAPTIONBARHEIGHT = 1207,

			/// <summary>Menu bar width.</summary>
			[CorrespondingType(typeof(SIZE))]
			TMT_MENUBARWIDTH = 1208,

			/// <summary>Menu bar height.</summary>
			[CorrespondingType(typeof(SIZE))]
			TMT_MENUBARHEIGHT = 1209,

			/// <summary>Padded border width.</summary>
			[CorrespondingType(typeof(SIZE))]
			TMT_PADDEDBORDERWIDTH = 1210,

			/// <summary></summary>
			TMT_FIRSTSIZE = TMT_SIZINGBORDERWIDTH,

			/// <summary></summary>
			TMT_LASTSIZE = TMT_PADDEDBORDERWIDTH,

			/// <summary></summary>
			[CorrespondingType(typeof(int))]
			TMT_MINCOLORDEPTH = 1301,

			/// <summary></summary>
			TMT_FIRSTINT = TMT_MINCOLORDEPTH,

			/// <summary></summary>
			TMT_LASTINT = TMT_MINCOLORDEPTH,

			/// <summary>The name of the CSS file associated with the theme specified by hTheme.</summary>
			[CorrespondingType(typeof(string))]
			TMT_CSSNAME = 1401,

			/// <summary>The name of the XML file associated with the theme specified by hTheme.</summary>
			[CorrespondingType(typeof(string))]
			TMT_XMLNAME = 1402,

			/// <summary></summary>
			[CorrespondingType(typeof(string))]
			TMT_LASTUPDATED = 1403,

			/// <summary></summary>
			[CorrespondingType(typeof(string))]
			TMT_ALIAS = 1404,

			/// <summary></summary>
			TMT_FIRSTSTRING = TMT_CSSNAME,

			/// <summary></summary>
			TMT_LASTSTRING = TMT_ALIAS,

			/// <summary></summary>
			[CorrespondingType(typeof(COLORREF))]
			TMT_SCROLLBAR = 1601,

			/// <summary></summary>
			[CorrespondingType(typeof(COLORREF))]
			TMT_BACKGROUND = 1602,

			/// <summary></summary>
			[CorrespondingType(typeof(COLORREF))]
			TMT_ACTIVECAPTION = 1603,

			/// <summary></summary>
			[CorrespondingType(typeof(COLORREF))]
			TMT_INACTIVECAPTION = 1604,

			/// <summary></summary>
			[CorrespondingType(typeof(COLORREF))]
			TMT_MENU = 1605,

			/// <summary></summary>
			[CorrespondingType(typeof(COLORREF))]
			TMT_WINDOW = 1606,

			/// <summary></summary>
			[CorrespondingType(typeof(COLORREF))]
			TMT_WINDOWFRAME = 1607,

			/// <summary></summary>
			[CorrespondingType(typeof(COLORREF))]
			TMT_MENUTEXT = 1608,

			/// <summary></summary>
			[CorrespondingType(typeof(COLORREF))]
			TMT_WINDOWTEXT = 1609,

			/// <summary></summary>
			[CorrespondingType(typeof(COLORREF))]
			TMT_CAPTIONTEXT = 1610,

			/// <summary></summary>
			[CorrespondingType(typeof(COLORREF))]
			TMT_ACTIVEBORDER = 1611,

			/// <summary></summary>
			[CorrespondingType(typeof(COLORREF))]
			TMT_INACTIVEBORDER = 1612,

			/// <summary></summary>
			[CorrespondingType(typeof(COLORREF))]
			TMT_APPWORKSPACE = 1613,

			/// <summary></summary>
			[CorrespondingType(typeof(COLORREF))]
			TMT_HIGHLIGHT = 1614,

			/// <summary></summary>
			[CorrespondingType(typeof(COLORREF))]
			TMT_HIGHLIGHTTEXT = 1615,

			/// <summary></summary>
			[CorrespondingType(typeof(COLORREF))]
			TMT_BTNFACE = 1616,

			/// <summary></summary>
			[CorrespondingType(typeof(COLORREF))]
			TMT_BTNSHADOW = 1617,

			/// <summary></summary>
			[CorrespondingType(typeof(COLORREF))]
			TMT_GRAYTEXT = 1618,

			/// <summary></summary>
			[CorrespondingType(typeof(COLORREF))]
			TMT_BTNTEXT = 1619,

			/// <summary></summary>
			[CorrespondingType(typeof(COLORREF))]
			TMT_INACTIVECAPTIONTEXT = 1620,

			/// <summary></summary>
			[CorrespondingType(typeof(COLORREF))]
			TMT_BTNHIGHLIGHT = 1621,

			/// <summary></summary>
			[CorrespondingType(typeof(COLORREF))]
			TMT_DKSHADOW3D = 1622,

			/// <summary></summary>
			[CorrespondingType(typeof(COLORREF))]
			TMT_LIGHT3D = 1623,

			/// <summary></summary>
			[CorrespondingType(typeof(COLORREF))]
			TMT_INFOTEXT = 1624,

			/// <summary></summary>
			[CorrespondingType(typeof(COLORREF))]
			TMT_INFOBK = 1625,

			/// <summary></summary>
			[CorrespondingType(typeof(COLORREF))]
			TMT_BUTTONALTERNATEFACE = 1626,

			/// <summary></summary>
			[CorrespondingType(typeof(COLORREF))]
			TMT_HOTTRACKING = 1627,

			/// <summary></summary>
			[CorrespondingType(typeof(COLORREF))]
			TMT_GRADIENTACTIVECAPTION = 1628,

			/// <summary></summary>
			[CorrespondingType(typeof(COLORREF))]
			TMT_GRADIENTINACTIVECAPTION = 1629,

			/// <summary></summary>
			[CorrespondingType(typeof(COLORREF))]
			TMT_MENUHILIGHT = 1630,

			/// <summary></summary>
			[CorrespondingType(typeof(COLORREF))]
			TMT_MENUBAR = 1631,

			/// <summary></summary>
			TMT_FIRSTCOLOR = TMT_SCROLLBAR,

			/// <summary></summary>
			TMT_LASTCOLOR = TMT_MENUBAR,

			/// <summary></summary>
			[CorrespondingType(typeof(int))]
			TMT_FROMHUE1 = 1801,

			/// <summary></summary>
			[CorrespondingType(typeof(int))]
			TMT_FROMHUE2 = 1802,

			/// <summary></summary>
			[CorrespondingType(typeof(int))]
			TMT_FROMHUE3 = 1803,

			/// <summary></summary>
			[CorrespondingType(typeof(int))]
			TMT_FROMHUE4 = 1804,

			/// <summary></summary>
			[CorrespondingType(typeof(int))]
			TMT_FROMHUE5 = 1805,

			/// <summary></summary>
			[CorrespondingType(typeof(int))]
			TMT_TOHUE1 = 1806,

			/// <summary></summary>
			[CorrespondingType(typeof(int))]
			TMT_TOHUE2 = 1807,

			/// <summary></summary>
			[CorrespondingType(typeof(int))]
			TMT_TOHUE3 = 1808,

			/// <summary></summary>
			[CorrespondingType(typeof(int))]
			TMT_TOHUE4 = 1809,

			/// <summary></summary>
			[CorrespondingType(typeof(int))]
			TMT_TOHUE5 = 1810,

			/// <summary></summary>
			[CorrespondingType(typeof(int))]
			TMT_FROMCOLOR1 = 2001,

			/// <summary></summary>
			[CorrespondingType(typeof(int))]
			TMT_FROMCOLOR2 = 2002,

			/// <summary></summary>
			[CorrespondingType(typeof(int))]
			TMT_FROMCOLOR3 = 2003,

			/// <summary></summary>
			[CorrespondingType(typeof(int))]
			TMT_FROMCOLOR4 = 2004,

			/// <summary></summary>
			[CorrespondingType(typeof(int))]
			TMT_FROMCOLOR5 = 2005,

			/// <summary></summary>
			[CorrespondingType(typeof(int))]
			TMT_TOCOLOR1 = 2006,

			/// <summary></summary>
			[CorrespondingType(typeof(int))]
			TMT_TOCOLOR2 = 2007,

			/// <summary></summary>
			[CorrespondingType(typeof(int))]
			TMT_TOCOLOR3 = 2008,

			/// <summary></summary>
			[CorrespondingType(typeof(int))]
			TMT_TOCOLOR4 = 2009,

			/// <summary></summary>
			[CorrespondingType(typeof(int))]
			TMT_TOCOLOR5 = 2010,

			/// <summary></summary>
			[CorrespondingType(typeof(bool))]
			TMT_TRANSPARENT = 2201,

			/// <summary>TRUE if the nonclient caption area associated with the part and state vary with text width.</summary>
			[CorrespondingType(typeof(bool))]
			TMT_AUTOSIZE = 2202,

			/// <summary>TRUE if the image associated with the part and state should only have its border drawn.</summary>
			[CorrespondingType(typeof(bool))]
			TMT_BORDERONLY = 2203,

			/// <summary>TRUE if the control associated with the part and state will handle its own compositing of images.</summary>
			[CorrespondingType(typeof(bool))]
			TMT_COMPOSITED = 2204,

			/// <summary>TRUE if true-sized images associated with the part and state are to be drawn on the background fill.</summary>
			[CorrespondingType(typeof(bool))]
			TMT_BGFILL = 2205,

			/// <summary>
			/// TRUE if the glyph associated with the part and state have transparent areas. See GetThemeColor for the definition of the
			/// TMT_GLYPHCOLOR value that defines the transparent color.
			/// </summary>
			[CorrespondingType(typeof(bool))]
			TMT_GLYPHTRANSPARENT = 2206,

			/// <summary>TRUE if the glyph associated with the part and state should be drawn without a background.</summary>
			[CorrespondingType(typeof(bool))]
			TMT_GLYPHONLY = 2207,

			/// <summary>TRUE if the sizing bar associated with the part and state should always be shown.</summary>
			[CorrespondingType(typeof(bool))]
			TMT_ALWAYSSHOWSIZINGBAR = 2208,

			/// <summary>
			/// TRUE if the image associated with the part and state should be flipped if the window is being viewed in right-to-left reading mode.
			/// </summary>
			[CorrespondingType(typeof(bool))]
			TMT_MIRRORIMAGE = 2209,

			/// <summary>TRUE if the image associated with the part and state must have equal height and width.</summary>
			[CorrespondingType(typeof(bool))]
			TMT_UNIFORMSIZING = 2210,

			/// <summary>TRUE if the truesize image or border associated with the part and state must be sized to a factor of 2.</summary>
			[CorrespondingType(typeof(bool))]
			TMT_INTEGRALSIZING = 2211,

			/// <summary>TRUE if the image associated with the part and state will scale larger in size if necessary.</summary>
			[CorrespondingType(typeof(bool))]
			TMT_SOURCEGROW = 2212,

			/// <summary>TRUE if the image associated with the part and state will scale smaller in size if necessary.</summary>
			[CorrespondingType(typeof(bool))]
			TMT_SOURCESHRINK = 2213,

			/// <summary></summary>
			[CorrespondingType(typeof(bool))]
			TMT_DRAWBORDERS = 2214,

			/// <summary></summary>
			[CorrespondingType(typeof(bool))]
			TMT_NOETCHEDEFFECT = 2215,

			/// <summary></summary>
			[CorrespondingType(typeof(bool))]
			TMT_TEXTAPPLYOVERLAY = 2216,

			/// <summary></summary>
			[CorrespondingType(typeof(bool))]
			TMT_TEXTGLOW = 2217,

			/// <summary></summary>
			[CorrespondingType(typeof(bool))]
			TMT_TEXTITALIC = 2218,

			/// <summary></summary>
			[CorrespondingType(typeof(bool))]
			TMT_COMPOSITEDOPAQUE = 2219,

			/// <summary></summary>
			[CorrespondingType(typeof(bool))]
			TMT_LOCALIZEDMIRRORIMAGE = 2220,

			/// <summary>The number of state images present in an image file.</summary>
			[CorrespondingType(typeof(int))]
			TMT_IMAGECOUNT = 2401,

			/// <summary>The alpha value (0-255) used for DrawThemeIcon.</summary>
			[CorrespondingType(typeof(int))]
			TMT_ALPHALEVEL = 2402,

			/// <summary></summary>
			[CorrespondingType(typeof(int))]
			TMT_BORDERSIZE = 2403,

			/// <summary>The roundness (0 to 100 percent) of the part's corners.</summary>
			[CorrespondingType(typeof(int))]
			TMT_ROUNDCORNERWIDTH = 2404,

			/// <summary>The roundness (0 to 100 percent) of the part's corners.</summary>
			[CorrespondingType(typeof(int))]
			TMT_ROUNDCORNERHEIGHT = 2405,

			/// <summary>
			/// The amount of the first gradient color (TMT_GRADIENTCOLOR1) to use in drawing the part. This value can be from 0 to 255, but
			/// this value plus the values of each of the GRADIENTRATIO values must add up to 255.
			/// </summary>
			[CorrespondingType(typeof(int))]
			TMT_GRADIENTRATIO1 = 2406,

			/// <summary>The amount of the second gradient color (TMT_GRADIENTCOLOR2) to use in drawing the part.</summary>
			[CorrespondingType(typeof(int))]
			TMT_GRADIENTRATIO2 = 2407,

			/// <summary>The amount of the third gradient color (TMT_GRADIENTCOLOR3) to use in drawing the part.</summary>
			[CorrespondingType(typeof(int))]
			TMT_GRADIENTRATIO3 = 2408,

			/// <summary>The amount of the fourth gradient color (TMT_GRADIENTCOLOR4) to use in drawing the part.</summary>
			[CorrespondingType(typeof(int))]
			TMT_GRADIENTRATIO4 = 2409,

			/// <summary>The amount of the fifth gradient color (TMT_GRADIENTCOLOR5) to use in drawing the part.</summary>
			[CorrespondingType(typeof(int))]
			TMT_GRADIENTRATIO5 = 2410,

			/// <summary>The size of the progress control "chunk" shapes that define how far an operation has progressed.</summary>
			[CorrespondingType(typeof(int))]
			TMT_PROGRESSCHUNKSIZE = 2411,

			/// <summary>The total size of all of the progress control "chunks".</summary>
			[CorrespondingType(typeof(int))]
			TMT_PROGRESSSPACESIZE = 2412,

			/// <summary>The amount of saturation (0-255) to apply to an icon drawn using DrawThemeIcon.</summary>
			[CorrespondingType(typeof(int))]
			TMT_SATURATION = 2413,

			/// <summary>The thickness of the border drawn around text characters.</summary>
			[CorrespondingType(typeof(int))]
			TMT_TEXTBORDERSIZE = 2414,

			/// <summary>The minimum alpha value (0-255) that a pixel must have to be considered opaque.</summary>
			[CorrespondingType(typeof(int))]
			TMT_ALPHATHRESHOLD = 2415,

			/// <summary>The width of the part.</summary>
			[CorrespondingType(typeof(int))]
			TMT_WIDTH = 2416,

			/// <summary>The height of the part.</summary>
			[CorrespondingType(typeof(int))]
			TMT_HEIGHT = 2417,

			/// <summary>The character index into the selected font that will be used for the glyph, if the part uses a font-based glyph.</summary>
			[CorrespondingType(typeof(int))]
			TMT_GLYPHINDEX = 2418,

			/// <summary>The percentage of a true-size image's original size at which the image will be stretched.</summary>
			[CorrespondingType(typeof(int))]
			TMT_TRUESIZESTRETCHMARK = 2419,

			/// <summary>The minimum dots per inch (dpi) that the first image file was designed for.</summary>
			[CorrespondingType(typeof(int))]
			TMT_MINDPI1 = 2420,

			/// <summary>The minimum dpi that the second image file was designed for.</summary>
			[CorrespondingType(typeof(int))]
			TMT_MINDPI2 = 2421,

			/// <summary>The minimum dpi that the third image file was designed for.</summary>
			[CorrespondingType(typeof(int))]
			TMT_MINDPI3 = 2422,

			/// <summary>The minimum dpi that the fourth image file was designed for.</summary>
			[CorrespondingType(typeof(int))]
			TMT_MINDPI4 = 2423,

			/// <summary>The minimum dpi that the fifth image file was designed for.</summary>
			[CorrespondingType(typeof(int))]
			TMT_MINDPI5 = 2424,

			/// <summary></summary>
			[CorrespondingType(typeof(int))]
			TMT_TEXTGLOWSIZE = 2425,

			/// <summary></summary>
			[CorrespondingType(typeof(int))]
			TMT_FRAMESPERSECOND = 2426,

			/// <summary></summary>
			[CorrespondingType(typeof(int))]
			TMT_PIXELSPERFRAME = 2427,

			/// <summary></summary>
			[CorrespondingType(typeof(int))]
			TMT_ANIMATIONDELAY = 2428,

			/// <summary></summary>
			[CorrespondingType(typeof(int))]
			TMT_GLOWINTENSITY = 2429,

			/// <summary></summary>
			[CorrespondingType(typeof(int))]
			TMT_OPACITY = 2430,

			/// <summary></summary>
			[CorrespondingType(typeof(int))]
			TMT_COLORIZATIONCOLOR = 2431,

			/// <summary></summary>
			[CorrespondingType(typeof(int))]
			TMT_COLORIZATIONOPACITY = 2432,

			/// <summary></summary>
			[CorrespondingType(typeof(int))]
			TMT_MINDPI6 = 2433,

			/// <summary></summary>
			[CorrespondingType(typeof(int))]
			TMT_MINDPI7 = 2434,

			/// <summary>The font that the glyph associated with this part will be drawn with, if font-based glyphs are used.</summary>
			[CorrespondingType(typeof(LOGFONT))]
			TMT_GLYPHFONT = 2601,

			/// <summary>
			/// The filename of the image associated with this part and state, or the base filename for multiple images associated with this
			/// part and state.
			/// </summary>
			[CorrespondingType(typeof(string))]
			TMT_IMAGEFILE = 3001,

			/// <summary>The filename of the first scaled image associated with this part and state, for support of different resolutions.</summary>
			[CorrespondingType(typeof(string))]
			TMT_IMAGEFILE1 = 3002,

			/// <summary>The filename of the second scaled image.</summary>
			[CorrespondingType(typeof(string))]
			TMT_IMAGEFILE2 = 3003,

			/// <summary>The filename of the third scaled image.</summary>
			[CorrespondingType(typeof(string))]
			TMT_IMAGEFILE3 = 3004,

			/// <summary>The filename of the fourth scaled image.</summary>
			[CorrespondingType(typeof(string))]
			TMT_IMAGEFILE4 = 3005,

			/// <summary>The filename of the fifth scaled image.</summary>
			[CorrespondingType(typeof(string))]
			TMT_IMAGEFILE5 = 3006,

			/// <summary>The filename for the glyph image associated with this part and state.</summary>
			[CorrespondingType(typeof(string))]
			TMT_GLYPHIMAGEFILE = 3008,

			/// <summary>The filename of the sixth scaled image.</summary>
			[CorrespondingType(typeof(string))]
			TMT_IMAGEFILE6 = 3009,

			/// <summary>The filename of the seventh scaled image.</summary>
			[CorrespondingType(typeof(string))]
			TMT_IMAGEFILE7 = 3010,

			/// <summary>The text displayed by the part.</summary>
			[CorrespondingType(typeof(string))]
			TMT_TEXT = 3201,

			/// <summary></summary>
			[CorrespondingType(typeof(string))]
			TMT_CLASSICVALUE = 3202,

			/// <summary>The position offset from the alignment for this part. The alignment is defined by the TMT_OFFSETTYPE value.</summary>
			[CorrespondingType(typeof(POINT))]
			TMT_OFFSET = 3401,

			/// <summary>The offset from the text at which text shadows are drawn.</summary>
			[CorrespondingType(typeof(POINT))]
			TMT_TEXTSHADOWOFFSET = 3402,

			/// <summary>The minimum size that the normal image file can be used for before moving to the next smallest image file.</summary>
			[CorrespondingType(typeof(POINT))]
			TMT_MINSIZE = 3403,

			/// <summary>The minimum size that the first small image file can be used for.</summary>
			[CorrespondingType(typeof(POINT))]
			TMT_MINSIZE1 = 3404,

			/// <summary>The minimum size that the second small image file can be used for.</summary>
			[CorrespondingType(typeof(POINT))]
			TMT_MINSIZE2 = 3405,

			/// <summary>The minimum size that the third small image file can be used for.</summary>
			[CorrespondingType(typeof(POINT))]
			TMT_MINSIZE3 = 3406,

			/// <summary>The minimum size that the fourth small image file can be used for.</summary>
			[CorrespondingType(typeof(POINT))]
			TMT_MINSIZE4 = 3407,

			/// <summary>The minimum size that the fifth small image file can be used for.</summary>
			[CorrespondingType(typeof(POINT))]
			TMT_MINSIZE5 = 3408,

			/// <summary>The size of the normal image associated with this part.</summary>
			[CorrespondingType(typeof(POINT))]
			TMT_NORMALSIZE = 3409,

			/// <summary>The minimum size that the sixth small image file can be used for.</summary>
			[CorrespondingType(typeof(POINT))]
			TMT_MINSIZE6 = 3410,

			/// <summary>The minimum size that the seventh small image file can be used for.</summary>
			[CorrespondingType(typeof(POINT))]
			TMT_MINSIZE7 = 3411,

			/// <summary>The margins used for sizing a non-true-size image.</summary>
			[CorrespondingType(typeof(MARGINS))]
			TMT_SIZINGMARGINS = 3601,

			/// <summary>The margins that define where content may be placed within a part.</summary>
			[CorrespondingType(typeof(MARGINS))]
			TMT_CONTENTMARGINS = 3602,

			/// <summary>The margins that define where caption text may be placed within a part.</summary>
			[CorrespondingType(typeof(MARGINS))]
			TMT_CAPTIONMARGINS = 3603,

			/// <summary>The color of the border associated with the part and state.</summary>
			[CorrespondingType(typeof(COLORREF))]
			TMT_BORDERCOLOR = 3801,

			/// <summary>The color of the background fill associated with the part and state.</summary>
			[CorrespondingType(typeof(COLORREF))]
			TMT_FILLCOLOR = 3802,

			/// <summary>The color of the text associated with this part and state.</summary>
			[CorrespondingType(typeof(COLORREF))]
			TMT_TEXTCOLOR = 3803,

			/// <summary>The light color of the edge associated with this part and state.</summary>
			[CorrespondingType(typeof(COLORREF))]
			TMT_EDGELIGHTCOLOR = 3804,

			/// <summary>The highlight color of the edge associated with this part and state.</summary>
			[CorrespondingType(typeof(COLORREF))]
			TMT_EDGEHIGHLIGHTCOLOR = 3805,

			/// <summary>The shadow color of the edge associated with this part and state.</summary>
			[CorrespondingType(typeof(COLORREF))]
			TMT_EDGESHADOWCOLOR = 3806,

			/// <summary>The dark shadow color of the edge associated with this part and state.</summary>
			[CorrespondingType(typeof(COLORREF))]
			TMT_EDGEDKSHADOWCOLOR = 3807,

			/// <summary>The fill color of the edge associated with this part and state.</summary>
			[CorrespondingType(typeof(COLORREF))]
			TMT_EDGEFILLCOLOR = 3808,

			/// <summary>
			/// The transparent color associated with this part and state. If the TMT_TRANSPARENT value for this part and state is TRUE,
			/// parts of the graphic that use this color are not drawn.
			/// </summary>
			[CorrespondingType(typeof(COLORREF))]
			TMT_TRANSPARENTCOLOR = 3809,

			/// <summary>The first color of the gradient associated with this part and state.</summary>
			[CorrespondingType(typeof(COLORREF))]
			TMT_GRADIENTCOLOR1 = 3810,

			/// <summary>The second color of the gradient.</summary>
			[CorrespondingType(typeof(COLORREF))]
			TMT_GRADIENTCOLOR2 = 3811,

			/// <summary>The third color of the gradient.</summary>
			[CorrespondingType(typeof(COLORREF))]
			TMT_GRADIENTCOLOR3 = 3812,

			/// <summary>The fourth color of the gradient.</summary>
			[CorrespondingType(typeof(COLORREF))]
			TMT_GRADIENTCOLOR4 = 3813,

			/// <summary>The fifth color of the gradient.</summary>
			[CorrespondingType(typeof(COLORREF))]
			TMT_GRADIENTCOLOR5 = 3814,

			/// <summary>The color of the shadow drawn underneath text associated with this part and state.</summary>
			[CorrespondingType(typeof(COLORREF))]
			TMT_SHADOWCOLOR = 3815,

			/// <summary>The color of the glow produced by calling DrawThemeIcon using this part and state.</summary>
			[CorrespondingType(typeof(COLORREF))]
			TMT_GLOWCOLOR = 3816,

			/// <summary>The color of the text border associated with this part and state.</summary>
			[CorrespondingType(typeof(COLORREF))]
			TMT_TEXTBORDERCOLOR = 3817,

			/// <summary>The color of the text shadow associated with this part and state.</summary>
			[CorrespondingType(typeof(COLORREF))]
			TMT_TEXTSHADOWCOLOR = 3818,

			/// <summary>The color that the font-based glyph associated with this part and state will use.</summary>
			[CorrespondingType(typeof(COLORREF))]
			TMT_GLYPHTEXTCOLOR = 3819,

			/// <summary>
			/// The transparent glyph color associated with this part and state. If the TMT_GLYPHTRANSPARENT value for this part and state is
			/// TRUE, parts of the glyph that use this color are not drawn.
			/// </summary>
			[CorrespondingType(typeof(COLORREF))]
			TMT_GLYPHTRANSPARENTCOLOR = 3820,

			/// <summary>The color used as a fill color hint for custom controls.</summary>
			[CorrespondingType(typeof(COLORREF))]
			TMT_FILLCOLORHINT = 3821,

			/// <summary>The color used as a border color hint for custom controls.</summary>
			[CorrespondingType(typeof(COLORREF))]
			TMT_BORDERCOLORHINT = 3822,

			/// <summary>The color used as an accent color hint for custom controls.</summary>
			[CorrespondingType(typeof(COLORREF))]
			TMT_ACCENTCOLORHINT = 3823,

			/// <summary></summary>
			[CorrespondingType(typeof(COLORREF))]
			TMT_TEXTCOLORHINT = 3824,

			/// <summary></summary>
			[CorrespondingType(typeof(COLORREF))]
			TMT_HEADING1TEXTCOLOR = 3825,

			/// <summary></summary>
			[CorrespondingType(typeof(COLORREF))]
			TMT_HEADING2TEXTCOLOR = 3826,

			/// <summary></summary>
			[CorrespondingType(typeof(COLORREF))]
			TMT_BODYTEXTCOLOR = 3827,

			/// <summary>The basic drawing type for this part.</summary>
			[CorrespondingType(typeof(BGTYPE))]
			TMT_BGTYPE = 4001,

			/// <summary>The type of border drawn if this part is a border fill.</summary>
			[CorrespondingType(typeof(BORDERTYPE))]
			TMT_BORDERTYPE = 4002,

			/// <summary>The type of fill shape drawn if this part is a border fill.</summary>
			[CorrespondingType(typeof(FILLTYPE))]
			TMT_FILLTYPE = 4003,

			/// <summary>The method used to size an image if this part uses an image file.</summary>
			[CorrespondingType(typeof(SIZINGTYPE))]
			TMT_SIZINGTYPE = 4004,

			/// <summary>The horizontal alignment if this part uses a true-size image.</summary>
			[CorrespondingType(typeof(HALIGN))]
			TMT_HALIGN = 4005,

			/// <summary>The alignment of text in the caption associated with this part.</summary>
			[CorrespondingType(typeof(CONTENTALIGNMENT))]
			TMT_CONTENTALIGNMENT = 4006,

			/// <summary>The vertical alignment if this part uses a true-size image.</summary>
			[CorrespondingType(typeof(VALIGN))]
			TMT_VALIGN = 4007,

			/// <summary>The alignment of this part on the window.</summary>
			[CorrespondingType(typeof(OFFSETTYPE))]
			TMT_OFFSETTYPE = 4008,

			/// <summary>The type of effect to be displayed when this part is drawn using DrawThemeIcon.</summary>
			[CorrespondingType(typeof(ICONEFFECT))]
			TMT_ICONEFFECT = 4009,

			/// <summary>The type of shadow effect to draw behind text associated with this part.</summary>
			[CorrespondingType(typeof(TEXTSHADOWTYPE))]
			TMT_TEXTSHADOWTYPE = 4010,

			/// <summary>The type of alignment used when multiple images are drawn.</summary>
			[CorrespondingType(typeof(IMAGELAYOUT))]
			TMT_IMAGELAYOUT = 4011,

			/// <summary>The type of glyph drawn on this part.</summary>
			[CorrespondingType(typeof(GLYPHTYPE))]
			TMT_GLYPHTYPE = 4012,

			/// <summary>The type of method used to select between sized images for this part. See the TMT_IMAGEFILE1 value of GetThemeFilename.</summary>
			[CorrespondingType(typeof(IMAGESELECTTYPE))]
			TMT_IMAGESELECTTYPE = 4013,

			/// <summary>The type of method used to select between different-sized glyphs.</summary>
			[CorrespondingType(typeof(GLYPHFONTSIZINGTYPE))]
			TMT_GLYPHFONTSIZINGTYPE = 4014,

			/// <summary>The type of scaling used if this part uses a true-sized image.</summary>
			[CorrespondingType(typeof(TRUESIZESCALINGTYPE))]
			TMT_TRUESIZESCALINGTYPE = 4015,

			/// <summary>TRUE if the image associated with the part and state is based on the current user.</summary>
			[CorrespondingType(typeof(bool))]
			TMT_USERPICTURE = 5001,

			/// <summary>The default size of the part.</summary>
			[CorrespondingType(typeof(RECT))]
			TMT_DEFAULTPANESIZE = 5002,

			/// <summary>The color used as a blend color.</summary>
			[CorrespondingType(typeof(COLORREF))]
			TMT_BLENDCOLOR = 5003,

			/// <summary></summary>
			[CorrespondingType(typeof(RECT))]
			TMT_CUSTOMSPLITRECT = 5004,

			/// <summary></summary>
			[CorrespondingType(typeof(RECT))]
			TMT_ANIMATIONBUTTONRECT = 5005,

			/// <summary></summary>
			[CorrespondingType(typeof(int))]
			TMT_ANIMATIONDURATION = 5006,

			/// <summary></summary>
			[CorrespondingType(typeof(int[]))]
			TMT_TRANSITIONDURATIONS = 6000,

			/// <summary></summary>
			[CorrespondingType(typeof(bool))]
			TMT_SCALEDBACKGROUND = 7001,

			/// <summary></summary>
			[CorrespondingType(typeof(byte[]))]
			TMT_ATLASIMAGE = 8000,

			/// <summary></summary>
			[CorrespondingType(typeof(string))]
			TMT_ATLASINPUTIMAGE = 8001,

			/// <summary></summary>
			[CorrespondingType(typeof(RECT))]
			TMT_ATLASRECT = 8002,
		}

		/// <summary>The type of scaling used if this part uses a true-sized image.</summary>
		public enum TRUESIZESCALINGTYPE
		{
			TSST_NONE = 0,
			TSST_SIZE = 1,
			TSST_DPI = 2,
		}

		/// <summary>The vertical alignment if this part uses a true-size image.</summary>
		public enum VALIGN
		{
			VA_TOP = 0,
			VA_CENTER = 1,
			VA_BOTTOM = 2,
		}
	}
}