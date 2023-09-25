#pragma warning disable CS1591 // Missing XML comment for publicly visible type or member
namespace Vanara.PInvoke;

public static partial class UxTheme
{
	public enum BGTYPE
	{
		BT_IMAGEFILE = 0,
		BT_BORDERFILL = 1,
		BT_NONE = 2,
	}

	public enum BORDERTYPE
	{
		BT_RECT = 0,
		BT_ROUNDRECT = 1,
		BT_ELLIPSE = 2,
	}

	public enum CONTENTALIGNMENT
	{
		CA_LEFT = 0,
		CA_CENTER = 1,
		CA_RIGHT = 2,
	}

	public enum FILLTYPE
	{
		FT_SOLID = 0,
		FT_VERTGRADIENT = 1,
		FT_HORZGRADIENT = 2,
		FT_RADIALGRADIENT = 3,
		FT_TILEIMAGE = 4,
	}

	public enum GLYPHFONTSIZINGTYPE
	{
		GFST_NONE = 0,
		GFST_SIZE = 1,
		GFST_DPI = 2,
	}

	public enum GLYPHTYPE
	{
		GT_NONE = 0,
		GT_IMAGEGLYPH = 1,
		GT_FONTGLYPH = 2,
	}

	public enum HALIGN
	{
		HA_LEFT = 0,
		HA_CENTER = 1,
		HA_RIGHT = 2,
	}

	public enum ICONEFFECT
	{
		ICE_NONE = 0,
		ICE_GLOW = 1,
		ICE_SHADOW = 2,
		ICE_PULSE = 3,
		ICE_ALPHA = 4,
	}

	public enum IMAGELAYOUT
	{
		IL_VERTICAL = 0,
		IL_HORIZONTAL = 1,
	}

	public enum IMAGESELECTTYPE
	{
		IST_NONE = 0,
		IST_SIZE = 1,
		IST_DPI = 2,
	}

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

	public enum SIZINGTYPE
	{
		ST_TRUESIZE = 0,
		ST_STRETCH = 1,
		ST_TILE = 2,
	}

	public enum TEXTSHADOWTYPE
	{
		TST_NONE = 0,

		TST_SINGLE = 1,

		TST_CONTINUOUS = 2,
	}

	public enum ThemeProperty
	{
		[CorrespondingType(typeof(IntPtr))]
		TMT_DIBDATA = 2,

		[CorrespondingType(typeof(IntPtr))]
		TMT_GLYPHDIBDATA = 3,

		TMT_ENUM = 200,

		TMT_STRING = 201,

		TMT_INT = 202,

		TMT_BOOL = 203,

		TMT_COLOR = 204,

		TMT_MARGINS = 205,

		TMT_FILENAME = 206,

		TMT_SIZE = 207,

		TMT_POSITION = 208,

		TMT_RECT = 209,

		TMT_FONT = 210,

		TMT_INTLIST = 211,

		[CorrespondingType(typeof(IntPtr))]
		TMT_HBITMAP = 212,

		[CorrespondingType(typeof(byte[]))]
		TMT_DISKSTREAM = 213,

		[CorrespondingType(typeof(byte[]))]
		TMT_STREAM = 214,

		TMT_BITMAPREF = 215,

		TMT_FLOAT = 216,

		TMT_FLOATLIST = 217,

		[CorrespondingType(typeof(string))]
		TMT_COLORSCHEMES = 401,

		[CorrespondingType(typeof(string))]
		TMT_SIZES = 402,

		TMT_CHARSET = 403,

		[CorrespondingType(typeof(string))]
		TMT_NAME = 600,

		[CorrespondingType(typeof(string))]
		TMT_DISPLAYNAME = 601,

		[CorrespondingType(typeof(string))]
		TMT_TOOLTIP = 602,

		[CorrespondingType(typeof(string))]
		TMT_COMPANY = 603,

		[CorrespondingType(typeof(string))]
		TMT_AUTHOR = 604,

		[CorrespondingType(typeof(string))]
		TMT_COPYRIGHT = 605,

		[CorrespondingType(typeof(string))]
		TMT_URL = 606,

		[CorrespondingType(typeof(string))]
		TMT_VERSION = 607,

		[CorrespondingType(typeof(string))]
		TMT_DESCRIPTION = 608,

		TMT_FIRST_RCSTRING_NAME = TMT_DISPLAYNAME,

		TMT_LAST_RCSTRING_NAME = TMT_DESCRIPTION,

		[CorrespondingType(typeof(LOGFONT))]
		TMT_CAPTIONFONT = 801,

		[CorrespondingType(typeof(LOGFONT))]
		TMT_SMALLCAPTIONFONT = 802,

		[CorrespondingType(typeof(LOGFONT))]
		TMT_MENUFONT = 803,

		[CorrespondingType(typeof(LOGFONT))]
		TMT_STATUSFONT = 804,

		[CorrespondingType(typeof(LOGFONT))]
		TMT_MSGBOXFONT = 805,

		[CorrespondingType(typeof(LOGFONT))]
		TMT_ICONTITLEFONT = 806,

		[CorrespondingType(typeof(LOGFONT))]
		TMT_HEADING1FONT = 807,

		[CorrespondingType(typeof(LOGFONT))]
		TMT_HEADING2FONT = 808,

		[CorrespondingType(typeof(LOGFONT))]
		TMT_BODYFONT = 809,

		TMT_FIRSTFONT = TMT_CAPTIONFONT,

		TMT_LASTFONT = TMT_BODYFONT,

		[CorrespondingType(typeof(bool))]
		TMT_FLATMENUS = 1001,

		TMT_FIRSTBOOL = TMT_FLATMENUS,

		TMT_LASTBOOL = TMT_FLATMENUS,

		[CorrespondingType(typeof(SIZE))]
		TMT_SIZINGBORDERWIDTH = 1201,

		[CorrespondingType(typeof(SIZE))]
		TMT_SCROLLBARWIDTH = 1202,

		[CorrespondingType(typeof(SIZE))]
		TMT_SCROLLBARHEIGHT = 1203,

		[CorrespondingType(typeof(SIZE))]
		TMT_CAPTIONBARWIDTH = 1204,

		[CorrespondingType(typeof(SIZE))]
		TMT_CAPTIONBARHEIGHT = 1205,

		[CorrespondingType(typeof(SIZE))]
		TMT_SMCAPTIONBARWIDTH = 1206,

		[CorrespondingType(typeof(SIZE))]
		TMT_SMCAPTIONBARHEIGHT = 1207,

		[CorrespondingType(typeof(SIZE))]
		TMT_MENUBARWIDTH = 1208,

		[CorrespondingType(typeof(SIZE))]
		TMT_MENUBARHEIGHT = 1209,

		[CorrespondingType(typeof(SIZE))]
		TMT_PADDEDBORDERWIDTH = 1210,

		TMT_FIRSTSIZE = TMT_SIZINGBORDERWIDTH,

		TMT_LASTSIZE = TMT_PADDEDBORDERWIDTH,

		[CorrespondingType(typeof(int))]
		TMT_MINCOLORDEPTH = 1301,

		TMT_FIRSTINT = TMT_MINCOLORDEPTH,

		TMT_LASTINT = TMT_MINCOLORDEPTH,

		[CorrespondingType(typeof(string))]
		TMT_CSSNAME = 1401,

		[CorrespondingType(typeof(string))]
		TMT_XMLNAME = 1402,

		[CorrespondingType(typeof(string))]
		TMT_LASTUPDATED = 1403,

		[CorrespondingType(typeof(string))]
		TMT_ALIAS = 1404,

		TMT_FIRSTSTRING = TMT_CSSNAME,

		TMT_LASTSTRING = TMT_ALIAS,

		[CorrespondingType(typeof(COLORREF))]
		TMT_SCROLLBAR = 1601,

		[CorrespondingType(typeof(COLORREF))]
		TMT_BACKGROUND = 1602,

		[CorrespondingType(typeof(COLORREF))]
		TMT_ACTIVECAPTION = 1603,

		[CorrespondingType(typeof(COLORREF))]
		TMT_INACTIVECAPTION = 1604,

		[CorrespondingType(typeof(COLORREF))]
		TMT_MENU = 1605,

		[CorrespondingType(typeof(COLORREF))]
		TMT_WINDOW = 1606,

		[CorrespondingType(typeof(COLORREF))]
		TMT_WINDOWFRAME = 1607,

		[CorrespondingType(typeof(COLORREF))]
		TMT_MENUTEXT = 1608,

		[CorrespondingType(typeof(COLORREF))]
		TMT_WINDOWTEXT = 1609,

		[CorrespondingType(typeof(COLORREF))]
		TMT_CAPTIONTEXT = 1610,

		[CorrespondingType(typeof(COLORREF))]
		TMT_ACTIVEBORDER = 1611,

		[CorrespondingType(typeof(COLORREF))]
		TMT_INACTIVEBORDER = 1612,

		[CorrespondingType(typeof(COLORREF))]
		TMT_APPWORKSPACE = 1613,

		[CorrespondingType(typeof(COLORREF))]
		TMT_HIGHLIGHT = 1614,

		[CorrespondingType(typeof(COLORREF))]
		TMT_HIGHLIGHTTEXT = 1615,

		[CorrespondingType(typeof(COLORREF))]
		TMT_BTNFACE = 1616,

		[CorrespondingType(typeof(COLORREF))]
		TMT_BTNSHADOW = 1617,

		[CorrespondingType(typeof(COLORREF))]
		TMT_GRAYTEXT = 1618,

		[CorrespondingType(typeof(COLORREF))]
		TMT_BTNTEXT = 1619,

		[CorrespondingType(typeof(COLORREF))]
		TMT_INACTIVECAPTIONTEXT = 1620,

		[CorrespondingType(typeof(COLORREF))]
		TMT_BTNHIGHLIGHT = 1621,

		[CorrespondingType(typeof(COLORREF))]
		TMT_DKSHADOW3D = 1622,

		[CorrespondingType(typeof(COLORREF))]
		TMT_LIGHT3D = 1623,

		[CorrespondingType(typeof(COLORREF))]
		TMT_INFOTEXT = 1624,

		[CorrespondingType(typeof(COLORREF))]
		TMT_INFOBK = 1625,

		[CorrespondingType(typeof(COLORREF))]
		TMT_BUTTONALTERNATEFACE = 1626,

		[CorrespondingType(typeof(COLORREF))]
		TMT_HOTTRACKING = 1627,

		[CorrespondingType(typeof(COLORREF))]
		TMT_GRADIENTACTIVECAPTION = 1628,

		[CorrespondingType(typeof(COLORREF))]
		TMT_GRADIENTINACTIVECAPTION = 1629,

		[CorrespondingType(typeof(COLORREF))]
		TMT_MENUHILIGHT = 1630,

		[CorrespondingType(typeof(COLORREF))]
		TMT_MENUBAR = 1631,

		TMT_FIRSTCOLOR = TMT_SCROLLBAR,

		TMT_LASTCOLOR = TMT_MENUBAR,

		[CorrespondingType(typeof(int))]
		TMT_FROMHUE1 = 1801,

		[CorrespondingType(typeof(int))]
		TMT_FROMHUE2 = 1802,

		[CorrespondingType(typeof(int))]
		TMT_FROMHUE3 = 1803,

		[CorrespondingType(typeof(int))]
		TMT_FROMHUE4 = 1804,

		[CorrespondingType(typeof(int))]
		TMT_FROMHUE5 = 1805,

		[CorrespondingType(typeof(int))]
		TMT_TOHUE1 = 1806,

		[CorrespondingType(typeof(int))]
		TMT_TOHUE2 = 1807,

		[CorrespondingType(typeof(int))]
		TMT_TOHUE3 = 1808,

		[CorrespondingType(typeof(int))]
		TMT_TOHUE4 = 1809,

		[CorrespondingType(typeof(int))]
		TMT_TOHUE5 = 1810,

		[CorrespondingType(typeof(int))]
		TMT_FROMCOLOR1 = 2001,

		[CorrespondingType(typeof(int))]
		TMT_FROMCOLOR2 = 2002,

		[CorrespondingType(typeof(int))]
		TMT_FROMCOLOR3 = 2003,

		[CorrespondingType(typeof(int))]
		TMT_FROMCOLOR4 = 2004,

		[CorrespondingType(typeof(int))]
		TMT_FROMCOLOR5 = 2005,

		[CorrespondingType(typeof(int))]
		TMT_TOCOLOR1 = 2006,

		[CorrespondingType(typeof(int))]
		TMT_TOCOLOR2 = 2007,

		[CorrespondingType(typeof(int))]
		TMT_TOCOLOR3 = 2008,

		[CorrespondingType(typeof(int))]
		TMT_TOCOLOR4 = 2009,

		[CorrespondingType(typeof(int))]
		TMT_TOCOLOR5 = 2010,

		[CorrespondingType(typeof(bool))]
		TMT_TRANSPARENT = 2201,

		[CorrespondingType(typeof(bool))]
		TMT_AUTOSIZE = 2202,

		[CorrespondingType(typeof(bool))]
		TMT_BORDERONLY = 2203,

		[CorrespondingType(typeof(bool))]
		TMT_COMPOSITED = 2204,

		[CorrespondingType(typeof(bool))]
		TMT_BGFILL = 2205,

		[CorrespondingType(typeof(bool))]
		TMT_GLYPHTRANSPARENT = 2206,

		[CorrespondingType(typeof(bool))]
		TMT_GLYPHONLY = 2207,

		[CorrespondingType(typeof(bool))]
		TMT_ALWAYSSHOWSIZINGBAR = 2208,

		[CorrespondingType(typeof(bool))]
		TMT_MIRRORIMAGE = 2209,

		[CorrespondingType(typeof(bool))]
		TMT_UNIFORMSIZING = 2210,

		[CorrespondingType(typeof(bool))]
		TMT_INTEGRALSIZING = 2211,

		[CorrespondingType(typeof(bool))]
		TMT_SOURCEGROW = 2212,

		[CorrespondingType(typeof(bool))]
		TMT_SOURCESHRINK = 2213,

		[CorrespondingType(typeof(bool))]
		TMT_DRAWBORDERS = 2214,

		[CorrespondingType(typeof(bool))]
		TMT_NOETCHEDEFFECT = 2215,

		[CorrespondingType(typeof(bool))]
		TMT_TEXTAPPLYOVERLAY = 2216,

		[CorrespondingType(typeof(bool))]
		TMT_TEXTGLOW = 2217,

		[CorrespondingType(typeof(bool))]
		TMT_TEXTITALIC = 2218,

		[CorrespondingType(typeof(bool))]
		TMT_COMPOSITEDOPAQUE = 2219,

		[CorrespondingType(typeof(bool))]
		TMT_LOCALIZEDMIRRORIMAGE = 2220,

		[CorrespondingType(typeof(int))]
		TMT_IMAGECOUNT = 2401,

		[CorrespondingType(typeof(int))]
		TMT_ALPHALEVEL = 2402,

		[CorrespondingType(typeof(int))]
		TMT_BORDERSIZE = 2403,

		[CorrespondingType(typeof(int))]
		TMT_ROUNDCORNERWIDTH = 2404,

		[CorrespondingType(typeof(int))]
		TMT_ROUNDCORNERHEIGHT = 2405,

		[CorrespondingType(typeof(int))]
		TMT_GRADIENTRATIO1 = 2406,

		[CorrespondingType(typeof(int))]
		TMT_GRADIENTRATIO2 = 2407,

		[CorrespondingType(typeof(int))]
		TMT_GRADIENTRATIO3 = 2408,

		[CorrespondingType(typeof(int))]
		TMT_GRADIENTRATIO4 = 2409,

		[CorrespondingType(typeof(int))]
		TMT_GRADIENTRATIO5 = 2410,

		[CorrespondingType(typeof(int))]
		TMT_PROGRESSCHUNKSIZE = 2411,

		[CorrespondingType(typeof(int))]
		TMT_PROGRESSSPACESIZE = 2412,

		[CorrespondingType(typeof(int))]
		TMT_SATURATION = 2413,

		[CorrespondingType(typeof(int))]
		TMT_TEXTBORDERSIZE = 2414,

		[CorrespondingType(typeof(int))]
		TMT_ALPHATHRESHOLD = 2415,

		[CorrespondingType(typeof(int))]
		TMT_WIDTH = 2416,

		[CorrespondingType(typeof(int))]
		TMT_HEIGHT = 2417,

		[CorrespondingType(typeof(int))]
		TMT_GLYPHINDEX = 2418,

		[CorrespondingType(typeof(int))]
		TMT_TRUESIZESTRETCHMARK = 2419,

		[CorrespondingType(typeof(int))]
		TMT_MINDPI1 = 2420,

		[CorrespondingType(typeof(int))]
		TMT_MINDPI2 = 2421,

		[CorrespondingType(typeof(int))]
		TMT_MINDPI3 = 2422,

		[CorrespondingType(typeof(int))]
		TMT_MINDPI4 = 2423,

		[CorrespondingType(typeof(int))]
		TMT_MINDPI5 = 2424,

		[CorrespondingType(typeof(int))]
		TMT_TEXTGLOWSIZE = 2425,

		[CorrespondingType(typeof(int))]
		TMT_FRAMESPERSECOND = 2426,

		[CorrespondingType(typeof(int))]
		TMT_PIXELSPERFRAME = 2427,

		[CorrespondingType(typeof(int))]
		TMT_ANIMATIONDELAY = 2428,

		[CorrespondingType(typeof(int))]
		TMT_GLOWINTENSITY = 2429,

		[CorrespondingType(typeof(int))]
		TMT_OPACITY = 2430,

		[CorrespondingType(typeof(int))]
		TMT_COLORIZATIONCOLOR = 2431,

		[CorrespondingType(typeof(int))]
		TMT_COLORIZATIONOPACITY = 2432,

		[CorrespondingType(typeof(int))]
		TMT_MINDPI6 = 2433,

		[CorrespondingType(typeof(int))]
		TMT_MINDPI7 = 2434,

		[CorrespondingType(typeof(LOGFONT))]
		TMT_GLYPHFONT = 2601,

		[CorrespondingType(typeof(string))]
		TMT_IMAGEFILE = 3001,

		[CorrespondingType(typeof(string))]
		TMT_IMAGEFILE1 = 3002,

		[CorrespondingType(typeof(string))]
		TMT_IMAGEFILE2 = 3003,

		[CorrespondingType(typeof(string))]
		TMT_IMAGEFILE3 = 3004,

		[CorrespondingType(typeof(string))]
		TMT_IMAGEFILE4 = 3005,

		[CorrespondingType(typeof(string))]
		TMT_IMAGEFILE5 = 3006,

		[CorrespondingType(typeof(string))]
		TMT_GLYPHIMAGEFILE = 3008,

		[CorrespondingType(typeof(string))]
		TMT_IMAGEFILE6 = 3009,

		[CorrespondingType(typeof(string))]
		TMT_IMAGEFILE7 = 3010,

		[CorrespondingType(typeof(string))]
		TMT_TEXT = 3201,

		[CorrespondingType(typeof(string))]
		TMT_CLASSICVALUE = 3202,

		[CorrespondingType(typeof(POINT))]
		TMT_OFFSET = 3401,

		[CorrespondingType(typeof(POINT))]
		TMT_TEXTSHADOWOFFSET = 3402,

		[CorrespondingType(typeof(POINT))]
		TMT_MINSIZE = 3403,

		[CorrespondingType(typeof(POINT))]
		TMT_MINSIZE1 = 3404,

		[CorrespondingType(typeof(POINT))]
		TMT_MINSIZE2 = 3405,

		[CorrespondingType(typeof(POINT))]
		TMT_MINSIZE3 = 3406,

		[CorrespondingType(typeof(POINT))]
		TMT_MINSIZE4 = 3407,

		[CorrespondingType(typeof(POINT))]
		TMT_MINSIZE5 = 3408,

		[CorrespondingType(typeof(POINT))]
		TMT_NORMALSIZE = 3409,

		[CorrespondingType(typeof(POINT))]
		TMT_MINSIZE6 = 3410,

		[CorrespondingType(typeof(POINT))]
		TMT_MINSIZE7 = 3411,

		[CorrespondingType(typeof(MARGINS))]
		TMT_SIZINGMARGINS = 3601,

		[CorrespondingType(typeof(MARGINS))]
		TMT_CONTENTMARGINS = 3602,

		[CorrespondingType(typeof(MARGINS))]
		TMT_CAPTIONMARGINS = 3603,

		[CorrespondingType(typeof(COLORREF))]
		TMT_BORDERCOLOR = 3801,

		[CorrespondingType(typeof(COLORREF))]
		TMT_FILLCOLOR = 3802,

		[CorrespondingType(typeof(COLORREF))]
		TMT_TEXTCOLOR = 3803,

		[CorrespondingType(typeof(COLORREF))]
		TMT_EDGELIGHTCOLOR = 3804,

		[CorrespondingType(typeof(COLORREF))]
		TMT_EDGEHIGHLIGHTCOLOR = 3805,

		[CorrespondingType(typeof(COLORREF))]
		TMT_EDGESHADOWCOLOR = 3806,

		[CorrespondingType(typeof(COLORREF))]
		TMT_EDGEDKSHADOWCOLOR = 3807,

		[CorrespondingType(typeof(COLORREF))]
		TMT_EDGEFILLCOLOR = 3808,

		[CorrespondingType(typeof(COLORREF))]
		TMT_TRANSPARENTCOLOR = 3809,

		[CorrespondingType(typeof(COLORREF))]
		TMT_GRADIENTCOLOR1 = 3810,

		[CorrespondingType(typeof(COLORREF))]
		TMT_GRADIENTCOLOR2 = 3811,

		[CorrespondingType(typeof(COLORREF))]
		TMT_GRADIENTCOLOR3 = 3812,

		[CorrespondingType(typeof(COLORREF))]
		TMT_GRADIENTCOLOR4 = 3813,

		[CorrespondingType(typeof(COLORREF))]
		TMT_GRADIENTCOLOR5 = 3814,

		[CorrespondingType(typeof(COLORREF))]
		TMT_SHADOWCOLOR = 3815,

		[CorrespondingType(typeof(COLORREF))]
		TMT_GLOWCOLOR = 3816,

		[CorrespondingType(typeof(COLORREF))]
		TMT_TEXTBORDERCOLOR = 3817,

		[CorrespondingType(typeof(COLORREF))]
		TMT_TEXTSHADOWCOLOR = 3818,

		[CorrespondingType(typeof(COLORREF))]
		TMT_GLYPHTEXTCOLOR = 3819,

		[CorrespondingType(typeof(COLORREF))]
		TMT_GLYPHTRANSPARENTCOLOR = 3820,

		[CorrespondingType(typeof(COLORREF))]
		TMT_FILLCOLORHINT = 3821,

		[CorrespondingType(typeof(COLORREF))]
		TMT_BORDERCOLORHINT = 3822,

		[CorrespondingType(typeof(COLORREF))]
		TMT_ACCENTCOLORHINT = 3823,

		[CorrespondingType(typeof(COLORREF))]
		TMT_TEXTCOLORHINT = 3824,

		[CorrespondingType(typeof(COLORREF))]
		TMT_HEADING1TEXTCOLOR = 3825,

		[CorrespondingType(typeof(COLORREF))]
		TMT_HEADING2TEXTCOLOR = 3826,

		[CorrespondingType(typeof(COLORREF))]
		TMT_BODYTEXTCOLOR = 3827,

		[CorrespondingType(typeof(BGTYPE))]
		TMT_BGTYPE = 4001,

		[CorrespondingType(typeof(BORDERTYPE))]
		TMT_BORDERTYPE = 4002,

		[CorrespondingType(typeof(FILLTYPE))]
		TMT_FILLTYPE = 4003,

		[CorrespondingType(typeof(SIZINGTYPE))]
		TMT_SIZINGTYPE = 4004,

		[CorrespondingType(typeof(HALIGN))]
		TMT_HALIGN = 4005,

		[CorrespondingType(typeof(CONTENTALIGNMENT))]
		TMT_CONTENTALIGNMENT = 4006,

		[CorrespondingType(typeof(VALIGN))]
		TMT_VALIGN = 4007,

		[CorrespondingType(typeof(OFFSETTYPE))]
		TMT_OFFSETTYPE = 4008,

		[CorrespondingType(typeof(ICONEFFECT))]
		TMT_ICONEFFECT = 4009,

		[CorrespondingType(typeof(TEXTSHADOWTYPE))]
		TMT_TEXTSHADOWTYPE = 4010,

		[CorrespondingType(typeof(IMAGELAYOUT))]
		TMT_IMAGELAYOUT = 4011,

		[CorrespondingType(typeof(GLYPHTYPE))]
		TMT_GLYPHTYPE = 4012,

		[CorrespondingType(typeof(IMAGESELECTTYPE))]
		TMT_IMAGESELECTTYPE = 4013,

		[CorrespondingType(typeof(GLYPHFONTSIZINGTYPE))]
		TMT_GLYPHFONTSIZINGTYPE = 4014,

		[CorrespondingType(typeof(TRUESIZESCALINGTYPE))]
		TMT_TRUESIZESCALINGTYPE = 4015,

		[CorrespondingType(typeof(bool))]
		TMT_USERPICTURE = 5001,

		[CorrespondingType(typeof(RECT))]
		TMT_DEFAULTPANESIZE = 5002,

		[CorrespondingType(typeof(COLORREF))]
		TMT_BLENDCOLOR = 5003,

		[CorrespondingType(typeof(RECT))]
		TMT_CUSTOMSPLITRECT = 5004,

		[CorrespondingType(typeof(RECT))]
		TMT_ANIMATIONBUTTONRECT = 5005,

		[CorrespondingType(typeof(int))]
		TMT_ANIMATIONDURATION = 5006,

		[CorrespondingType(typeof(int[]))]
		TMT_TRANSITIONDURATIONS = 6000,

		[CorrespondingType(typeof(bool))]
		TMT_SCALEDBACKGROUND = 7001,

		[CorrespondingType(typeof(byte[]))]
		TMT_ATLASIMAGE = 8000,

		[CorrespondingType(typeof(string))]
		TMT_ATLASINPUTIMAGE = 8001,

		[CorrespondingType(typeof(RECT))]
		TMT_ATLASRECT = 8002,
	}

	public enum TRUESIZESCALINGTYPE
	{
		TSST_NONE = 0,
		TSST_SIZE = 1,
		TSST_DPI = 2,
	}

	public enum VALIGN
	{
		VA_TOP = 0,
		VA_CENTER = 1,
		VA_BOTTOM = 2,
	}
}