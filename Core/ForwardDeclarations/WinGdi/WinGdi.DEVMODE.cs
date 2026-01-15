namespace Vanara.PInvoke;

/// <summary>Specifies whether collation should be used when printing multiple copies.</summary>
[PInvokeData("wingdi.h", MSDNShortId = "85741025-9393-42ab-8a6d-27f1ae2c0f1b")]
public enum DMCOLLATE : short
{
	/// <summary>Do NOT collate when printing multiple copies.</summary>
	DMCOLLATE_FALSE = 0,

	/// <summary>Collate when printing multiple copies.</summary>
	DMCOLLATE_TRUE = 1
}

/// <summary>The printer color.</summary>
[PInvokeData("wingdi.h", MSDNShortId = "85741025-9393-42ab-8a6d-27f1ae2c0f1b")]
public enum DMCOLOR : short
{
	/// <summary>Monochrome.</summary>
	DMCOLOR_MONOCHROME = 1,

	/// <summary>Color.</summary>
	DMCOLOR_COLOR = 2
}

/// <summary>How the display presents a low-resolution mode on a higher-resolution display.</summary>
[PInvokeData("wingdi.h", MSDNShortId = "85741025-9393-42ab-8a6d-27f1ae2c0f1b")]
public enum DMDFO : uint
{
	/// <summary>The display's default setting.</summary>
	DMDFO_DEFAULT = 0,

	/// <summary>The low-resolution image is stretched to fill the larger screen space.</summary>
	DMDFO_STRETCH = 1,

	/// <summary>The low-resolution image is centered in the larger screen space.</summary>
	DMDFO_CENTER = 2,
}

/// <summary>Specifies the device's display mode.</summary>
[PInvokeData("wingdi.h", MSDNShortId = "85741025-9393-42ab-8a6d-27f1ae2c0f1b")]
public enum DMDISPLAY : uint
{
	/// <summary>Specifies that the display is a noncolor device. If this flag is not set, color is assumed.</summary>
	DM_GRAYSCALE = 0x00000001,

	/// <summary>Specifies that the display mode is interlaced. If the flag is not set, noninterlaced is assumed.</summary>
	DM_INTERLACED = 0x00000002,

	/// <summary>Undocumented</summary>
	DMDISPLAYFLAGS_TEXTMODE = 0x00000004,
}

/// <summary>Specifies how dithering is to be done.</summary>
[PInvokeData("wingdi.h", MSDNShortId = "85741025-9393-42ab-8a6d-27f1ae2c0f1b")]
public enum DMDITHER : uint
{
	/// <summary>No dithering.</summary>
	DMDITHER_NONE = 1,

	/// <summary>Dithering with a coarse brush.</summary>
	DMDITHER_COARSE = 2,

	/// <summary>Dithering with a fine brush.</summary>
	DMDITHER_FINE = 3,

	/// <summary>
	/// Line art dithering, a special dithering method that produces well defined borders between black, white, and gray scaling. It
	/// is not suitable for images that include continuous graduations in intensity and hue, such as scanned photographs.
	/// </summary>
	DMDITHER_LINEART = 4,

	/// <summary>Dithering with error diffusion.</summary>
	DMDITHER_ERRORDIFFUSION = 5,

	/// <summary>Reserved</summary>
	DMDITHER_RESERVED6 = 6,

	/// <summary>Reserved</summary>
	DMDITHER_RESERVED7 = 7,

	/// <summary>Reserved</summary>
	DMDITHER_RESERVED8 = 8,

	/// <summary>Reserved</summary>
	DMDITHER_RESERVED9 = 9,

	/// <summary>Device does gray scaling.</summary>
	DMDITHER_GRAYSCALE = 10,

	/// <summary>Base for driver-defined values.</summary>
	DMDITHER_USER = 256,
}

/// <summary>The orientation at which images should be presented.</summary>
[PInvokeData("wingdi.h", MSDNShortId = "85741025-9393-42ab-8a6d-27f1ae2c0f1b")]
public enum DMDO : uint
{
	/// <summary>The display orientation is the natural orientation of the display device; it should be used as the default.</summary>
	DMDO_DEFAULT = 0,

	/// <summary>The display orientation is rotated 90 degrees (measured clockwise) from DMDO_DEFAULT.</summary>
	DMDO_90 = 1,

	/// <summary>The display orientation is rotated 180 degrees (measured clockwise) from DMDO_DEFAULT.</summary>
	DMDO_180 = 2,

	/// <summary>The display orientation is rotated 270 degrees (measured clockwise) from DMDO_DEFAULT.</summary>
	DMDO_270 = 3,
}

/// <summary>Selects duplex or double-sided printing for printers capable of duplex printing.</summary>
[PInvokeData("wingdi.h", MSDNShortId = "85741025-9393-42ab-8a6d-27f1ae2c0f1b")]
public enum DMDUP : short
{
	/// <summary>Unknown setting.</summary>
	DMDUP_UNKNOWN = 0,

	/// <summary>Normal (nonduplex) printing.</summary>
	DMDUP_SIMPLEX = 1,

	/// <summary>Long-edge binding, that is, the long edge of the page is vertical.</summary>
	DMDUP_VERTICAL = 2,

	/// <summary>Short-edge binding, that is, the long edge of the page is horizontal.</summary>
	DMDUP_HORIZONTAL = 3,
}

/// <summary>Specifies whether certain members of the DEVMODE structure have been initialized.</summary>
[PInvokeData("wingdi.h", MSDNShortId = "85741025-9393-42ab-8a6d-27f1ae2c0f1b")]
[Flags]
public enum DMFIELDS : uint
{
	/// <summary/>
	DM_ORIENTATION = 0x00000001,
	/// <summary/>
	DM_PAPERSIZE = 0x00000002,
	/// <summary/>
	DM_PAPERLENGTH = 0x00000004,
	/// <summary/>
	DM_PAPERWIDTH = 0x00000008,
	/// <summary/>
	DM_SCALE = 0x00000010,
	/// <summary/>
	DM_POSITION = 0x00000020,
	/// <summary/>
	DM_NUP = 0x00000040,
	/// <summary/>
	DM_DISPLAYORIENTATION = 0x00000080,
	/// <summary/>
	DM_COPIES = 0x00000100,
	/// <summary/>
	DM_DEFAULTSOURCE = 0x00000200,
	/// <summary/>
	DM_PRINTQUALITY = 0x00000400,
	/// <summary/>
	DM_COLOR = 0x00000800,
	/// <summary/>
	DM_DUPLEX = 0x00001000,
	/// <summary/>
	DM_YRESOLUTION = 0x00002000,
	/// <summary/>
	DM_TTOPTION = 0x00004000,
	/// <summary/>
	DM_COLLATE = 0x00008000,
	/// <summary/>
	DM_FORMNAME = 0x00010000,
	/// <summary/>
	DM_LOGPIXELS = 0x00020000,
	/// <summary/>
	DM_BITSPERPEL = 0x00040000,
	/// <summary/>
	DM_PELSWIDTH = 0x00080000,
	/// <summary/>
	DM_PELSHEIGHT = 0x00100000,
	/// <summary/>
	DM_DISPLAYFLAGS = 0x00200000,
	/// <summary/>
	DM_DISPLAYFREQUENCY = 0x00400000,
	/// <summary/>
	DM_ICMMETHOD = 0x00800000,
	/// <summary/>
	DM_ICMINTENT = 0x01000000,
	/// <summary/>
	DM_MEDIATYPE = 0x02000000,
	/// <summary/>
	DM_DITHERTYPE = 0x04000000,
	/// <summary/>
	DM_PANNINGWIDTH = 0x08000000,
	/// <summary/>
	DM_PANNINGHEIGHT = 0x10000000,
	/// <summary/>
	DM_DISPLAYFIXEDOUTPUT = 0x20000000,
}

/// <summary>
/// Specifies which color matching method, or intent, should be used by default. This member is primarily for non-ICM applications.
/// ICM applications can establish intents by using the ICM functions.
/// </summary>
[PInvokeData("wingdi.h", MSDNShortId = "85741025-9393-42ab-8a6d-27f1ae2c0f1b")]
public enum DMICM : uint
{
	/// <summary>
	/// Color matching should optimize for color saturation. This value is the most appropriate choice for business graphs when
	/// dithering is not desired.
	/// </summary>
	DMICM_SATURATE = 1,

	/// <summary>
	/// Color matching should optimize for color contrast. This value is the most appropriate choice for scanned or photographic
	/// images when dithering is desired.
	/// </summary>
	DMICM_CONTRAST = 2,

	/// <summary>
	/// Color matching should optimize to match the exact color requested. This value is most appropriate for use with business logos
	/// or other images when an exact color match is desired.
	/// </summary>
	DMICM_COLORIMETRIC = 3,

	/// <summary>
	/// Color matching should optimize to match the exact color requested without white point mapping. This value is most appropriate
	/// for use with proofing.
	/// </summary>
	DMICM_ABS_COLORIMETRIC = 4,

	/// <summary>Base for driver-defined values.</summary>
	DMICM_USER = 256,
}

/// <summary>
/// Specifies how ICM is handled. For a non-ICM application, this member determines if ICM is enabled or disabled. For ICM
/// applications, the system examines this member to determine how to handle ICM support.
/// </summary>
[PInvokeData("wingdi.h", MSDNShortId = "85741025-9393-42ab-8a6d-27f1ae2c0f1b")]
public enum DMICMMETHOD : uint
{
	/// <summary>Specifies that ICM is disabled.</summary>
	DMICMMETHOD_NONE = 1,

	/// <summary>Specifies that ICM is handled by Windows.</summary>
	DMICMMETHOD_SYSTEM = 2,

	/// <summary>Specifies that ICM is handled by the device driver.</summary>
	DMICMMETHOD_DRIVER = 3,

	/// <summary>Specifies that ICM is handled by the destination device.</summary>
	DMICMMETHOD_DEVICE = 4,

	/// <summary>Base for driver-defined values.</summary>
	DMICMMETHOD_USER = 256,
}

/// <summary>Specifies the type of media being printed on.</summary>
[PInvokeData("wingdi.h", MSDNShortId = "85741025-9393-42ab-8a6d-27f1ae2c0f1b")]
public enum DMMEDIA : uint
{
	/// <summary>Plain paper.</summary>
	DMMEDIA_STANDARD = 1,

	/// <summary>Transparent film.</summary>
	DMMEDIA_TRANSPARENCY = 2,

	/// <summary>Glossy paper.</summary>
	DMMEDIA_GLOSSY = 3,

	/// <summary>Base for driver-defined values.</summary>
	DMMEDIA_USER = 256,
}

/// <summary>Specifies where the NUP is done.</summary>
[PInvokeData("wingdi.h", MSDNShortId = "85741025-9393-42ab-8a6d-27f1ae2c0f1b")]
public enum DMNUP : uint
{
	/// <summary>The print spooler does the NUP.</summary>
	DMNUP_SYSTEM = 1,

	/// <summary>The application does the NUP.</summary>
	DMNUP_ONEUP = 2
}

/// <summary>The orientation of the paper.</summary>
[PInvokeData("wingdi.h", MSDNShortId = "85741025-9393-42ab-8a6d-27f1ae2c0f1b")]
public enum DMORIENT : short
{
	/// <summary>Portrait</summary>
	DMORIENT_PORTRAIT = 1,

	/// <summary>Landscape</summary>
	DMORIENT_LANDSCAPE = 2
}

/// <summary>The size of the paper to print on.</summary>
[PInvokeData("wingdi.h", MSDNShortId = "85741025-9393-42ab-8a6d-27f1ae2c0f1b")]
public enum DMPAPER : short
{
	/// <summary>Letter 8 1/2 x 11 in</summary>
	DMPAPER_LETTER = 1,

	/// <summary>Letter Small 8 1/2 x 11 in</summary>
	DMPAPER_LETTERSMALL = 2,

	/// <summary>Tabloid 11 x 17 in</summary>
	DMPAPER_TABLOID = 3,

	/// <summary>Ledger 17 x 11 in</summary>
	DMPAPER_LEDGER = 4,

	/// <summary>Legal 8 1/2 x 14 in</summary>
	DMPAPER_LEGAL = 5,

	/// <summary>Statement 5 1/2 x 8 1/2 in</summary>
	DMPAPER_STATEMENT = 6,

	/// <summary>Executive 7 1/4 x 10 1/2 in</summary>
	DMPAPER_EXECUTIVE = 7,

	/// <summary>A3 297 x 420 mm</summary>
	DMPAPER_A3 = 8,

	/// <summary>A4 210 x 297 mm</summary>
	DMPAPER_A4 = 9,

	/// <summary>A4 Small 210 x 297 mm</summary>
	DMPAPER_A4SMALL = 10,

	/// <summary>A5 148 x 210 mm</summary>
	DMPAPER_A5 = 11,

	/// <summary>B4 (JIS) 250 x 354</summary>
	DMPAPER_B4 = 12,

	/// <summary>B5 (JIS) 182 x 257 mm</summary>
	DMPAPER_B5 = 13,

	/// <summary>Folio 8 1/2 x 13 in</summary>
	DMPAPER_FOLIO = 14,

	/// <summary>Quarto 215 x 275 mm</summary>
	DMPAPER_QUARTO = 15,

	/// <summary>10x14 in</summary>
	DMPAPER_10X14 = 16,

	/// <summary>11x17 in</summary>
	DMPAPER_11X17 = 17,

	/// <summary>Note 8 1/2 x 11 in</summary>
	DMPAPER_NOTE = 18,

	/// <summary>Envelope #9 3 7/8 x 8 7/8</summary>
	DMPAPER_ENV_9 = 19,

	/// <summary>Envelope #10 4 1/8 x 9 1/2</summary>
	DMPAPER_ENV_10 = 20,

	/// <summary>Envelope #11 4 1/2 x 10 3/8</summary>
	DMPAPER_ENV_11 = 21,

	/// <summary>Envelope #12 4 \276 x 11</summary>
	DMPAPER_ENV_12 = 22,

	/// <summary>Envelope #14 5 x 11 1/2</summary>
	DMPAPER_ENV_14 = 23,

	/// <summary>C size sheet</summary>
	DMPAPER_CSHEET = 24,

	/// <summary>D size sheet</summary>
	DMPAPER_DSHEET = 25,

	/// <summary>E size sheet</summary>
	DMPAPER_ESHEET = 26,

	/// <summary>Envelope DL 110 x 220mm</summary>
	DMPAPER_ENV_DL = 27,

	/// <summary>Envelope C5 162 x 229 mm</summary>
	DMPAPER_ENV_C5 = 28,

	/// <summary>Envelope C3 324 x 458 mm</summary>
	DMPAPER_ENV_C3 = 29,

	/// <summary>Envelope C4 229 x 324 mm</summary>
	DMPAPER_ENV_C4 = 30,

	/// <summary>Envelope C6 114 x 162 mm</summary>
	DMPAPER_ENV_C6 = 31,

	/// <summary>Envelope C65 114 x 229 mm</summary>
	DMPAPER_ENV_C65 = 32,

	/// <summary>Envelope B4 250 x 353 mm</summary>
	DMPAPER_ENV_B4 = 33,

	/// <summary>Envelope B5 176 x 250 mm</summary>
	DMPAPER_ENV_B5 = 34,

	/// <summary>Envelope B6 176 x 125 mm</summary>
	DMPAPER_ENV_B6 = 35,

	/// <summary>Envelope 110 x 230 mm</summary>
	DMPAPER_ENV_ITALY = 36,

	/// <summary>Envelope Monarch 3.875 x 7.5 in</summary>
	DMPAPER_ENV_MONARCH = 37,

	/// <summary>6 3/4 Envelope 3 5/8 x 6 1/2 in</summary>
	DMPAPER_ENV_PERSONAL = 38,

	/// <summary>US Std Fanfold 14 7/8 x 11 in</summary>
	DMPAPER_FANFOLD_US = 39,

	/// <summary>German Std Fanfold 8 1/2 x 12 in</summary>
	DMPAPER_FANFOLD_STD_GERMAN = 40,

	/// <summary>German Legal Fanfold 8 1/2 x 13 in</summary>
	DMPAPER_FANFOLD_LGL_GERMAN = 41,

	/// <summary>B4 (ISO) 250 x 353 mm</summary>
	DMPAPER_ISO_B4 = 42,

	/// <summary>Japanese Postcard 100 x 148 mm</summary>
	DMPAPER_JAPANESE_POSTCARD = 43,

	/// <summary>9 x 11 in</summary>
	DMPAPER_9X11 = 44,

	/// <summary>10 x 11 in</summary>
	DMPAPER_10X11 = 45,

	/// <summary>15 x 11 in</summary>
	DMPAPER_15X11 = 46,

	/// <summary>Envelope Invite 220 x 220 mm</summary>
	DMPAPER_ENV_INVITE = 47,

	/// <summary>RESERVED--DO NOT USE</summary>
	DMPAPER_RESERVED_48 = 48,

	/// <summary>RESERVED--DO NOT USE</summary>
	DMPAPER_RESERVED_49 = 49,

	/// <summary>Letter Extra 9 \275 x 12 in</summary>
	DMPAPER_LETTER_EXTRA = 50,

	/// <summary>Legal Extra 9 \275 x 15 in</summary>
	DMPAPER_LEGAL_EXTRA = 51,

	/// <summary>Tabloid Extra 11.69 x 18 in</summary>
	DMPAPER_TABLOID_EXTRA = 52,

	/// <summary>A4 Extra 9.27 x 12.69 in</summary>
	DMPAPER_A4_EXTRA = 53,

	/// <summary>Letter Transverse 8 \275 x 11 in</summary>
	DMPAPER_LETTER_TRANSVERSE = 54,

	/// <summary>A4 Transverse 210 x 297 mm</summary>
	DMPAPER_A4_TRANSVERSE = 55,

	/// <summary>Letter Extra Transverse 9\275 x 12 in</summary>
	DMPAPER_LETTER_EXTRA_TRANSVERSE = 56,

	/// <summary>SuperA/SuperA/A4 227 x 356 mm</summary>
	DMPAPER_A_PLUS = 57,

	/// <summary>SuperB/SuperB/A3 305 x 487 mm</summary>
	DMPAPER_B_PLUS = 58,

	/// <summary>Letter Plus 8.5 x 12.69 in</summary>
	DMPAPER_LETTER_PLUS = 59,

	/// <summary>A4 Plus 210 x 330 mm</summary>
	DMPAPER_A4_PLUS = 60,

	/// <summary>A5 Transverse 148 x 210 mm</summary>
	DMPAPER_A5_TRANSVERSE = 61,

	/// <summary>B5 (JIS) Transverse 182 x 257 mm</summary>
	DMPAPER_B5_TRANSVERSE = 62,

	/// <summary>A3 Extra 322 x 445 mm</summary>
	DMPAPER_A3_EXTRA = 63,

	/// <summary>A5 Extra 174 x 235 mm</summary>
	DMPAPER_A5_EXTRA = 64,

	/// <summary>B5 (ISO) Extra 201 x 276 mm</summary>
	DMPAPER_B5_EXTRA = 65,

	/// <summary>A2 420 x 594 mm</summary>
	DMPAPER_A2 = 66,

	/// <summary>A3 Transverse 297 x 420 mm</summary>
	DMPAPER_A3_TRANSVERSE = 67,

	/// <summary>A3 Extra Transverse 322 x 445 mm</summary>
	DMPAPER_A3_EXTRA_TRANSVERSE = 68,

	/// <summary>Japanese Double Postcard 200 x 148 mm</summary>
	DMPAPER_DBL_JAPANESE_POSTCARD = 69,

	/// <summary>A6 105 x 148 mm</summary>
	DMPAPER_A6 = 70,

	/// <summary>Japanese Envelope Kaku #2</summary>
	DMPAPER_JENV_KAKU2 = 71,

	/// <summary>Japanese Envelope Kaku #3</summary>
	DMPAPER_JENV_KAKU3 = 72,

	/// <summary>Japanese Envelope Chou #3</summary>
	DMPAPER_JENV_CHOU3 = 73,

	/// <summary>Japanese Envelope Chou #4</summary>
	DMPAPER_JENV_CHOU4 = 74,

	/// <summary>Letter Rotated 11 x 8 1/2 11 in</summary>
	DMPAPER_LETTER_ROTATED = 75,

	/// <summary>A3 Rotated 420 x 297 mm</summary>
	DMPAPER_A3_ROTATED = 76,

	/// <summary>A4 Rotated 297 x 210 mm</summary>
	DMPAPER_A4_ROTATED = 77,

	/// <summary>A5 Rotated 210 x 148 mm</summary>
	DMPAPER_A5_ROTATED = 78,

	/// <summary>B4 (JIS) Rotated 364 x 257 mm</summary>
	DMPAPER_B4_JIS_ROTATED = 79,

	/// <summary>B5 (JIS) Rotated 257 x 182 mm</summary>
	DMPAPER_B5_JIS_ROTATED = 80,

	/// <summary>Japanese Postcard Rotated 148 x 100 mm</summary>
	DMPAPER_JAPANESE_POSTCARD_ROTATED = 81,

	/// <summary>Double Japanese Postcard Rotated 148 x 200 mm</summary>
	DMPAPER_DBL_JAPANESE_POSTCARD_ROTATED = 82,

	/// <summary>A6 Rotated 148 x 105 mm</summary>
	DMPAPER_A6_ROTATED = 83,

	/// <summary>Japanese Envelope Kaku #2 Rotated</summary>
	DMPAPER_JENV_KAKU2_ROTATED = 84,

	/// <summary>Japanese Envelope Kaku #3 Rotated</summary>
	DMPAPER_JENV_KAKU3_ROTATED = 85,

	/// <summary>Japanese Envelope Chou #3 Rotated</summary>
	DMPAPER_JENV_CHOU3_ROTATED = 86,

	/// <summary>Japanese Envelope Chou #4 Rotated</summary>
	DMPAPER_JENV_CHOU4_ROTATED = 87,

	/// <summary>B6 (JIS) 128 x 182 mm</summary>
	DMPAPER_B6_JIS = 88,

	/// <summary>B6 (JIS) Rotated 182 x 128 mm</summary>
	DMPAPER_B6_JIS_ROTATED = 89,

	/// <summary>12 x 11 in</summary>
	DMPAPER_12X11 = 90,

	/// <summary>Japanese Envelope You #4</summary>
	DMPAPER_JENV_YOU4 = 91,

	/// <summary>Japanese Envelope You #4 Rotated</summary>
	DMPAPER_JENV_YOU4_ROTATED = 92,

	/// <summary>PRC 16K 146 x 215 mm</summary>
	DMPAPER_P16K = 93,

	/// <summary>PRC 32K 97 x 151 mm</summary>
	DMPAPER_P32K = 94,

	/// <summary>PRC 32K(Big) 97 x 151 mm</summary>
	DMPAPER_P32KBIG = 95,

	/// <summary>PRC Envelope #1 102 x 165 mm</summary>
	DMPAPER_PENV_1 = 96,

	/// <summary>PRC Envelope #2 102 x 176 mm</summary>
	DMPAPER_PENV_2 = 97,

	/// <summary>PRC Envelope #3 125 x 176 mm</summary>
	DMPAPER_PENV_3 = 98,

	/// <summary>PRC Envelope #4 110 x 208 mm</summary>
	DMPAPER_PENV_4 = 99,

	/// <summary>PRC Envelope #5 110 x 220 mm</summary>
	DMPAPER_PENV_5 = 100,

	/// <summary>PRC Envelope #6 120 x 230 mm</summary>
	DMPAPER_PENV_6 = 101,

	/// <summary>PRC Envelope #7 160 x 230 mm</summary>
	DMPAPER_PENV_7 = 102,

	/// <summary>PRC Envelope #8 120 x 309 mm</summary>
	DMPAPER_PENV_8 = 103,

	/// <summary>PRC Envelope #9 229 x 324 mm</summary>
	DMPAPER_PENV_9 = 104,

	/// <summary>PRC Envelope #10 324 x 458 mm</summary>
	DMPAPER_PENV_10 = 105,

	/// <summary>PRC 16K Rotated</summary>
	DMPAPER_P16K_ROTATED = 106,

	/// <summary>PRC 32K Rotated</summary>
	DMPAPER_P32K_ROTATED = 107,

	/// <summary>PRC 32K(Big) Rotated</summary>
	DMPAPER_P32KBIG_ROTATED = 108,

	/// <summary>PRC Envelope #1 Rotated 165 x 102 mm</summary>
	DMPAPER_PENV_1_ROTATED = 109,

	/// <summary>PRC Envelope #2 Rotated 176 x 102 mm</summary>
	DMPAPER_PENV_2_ROTATED = 110,

	/// <summary>PRC Envelope #3 Rotated 176 x 125 mm</summary>
	DMPAPER_PENV_3_ROTATED = 111,

	/// <summary>PRC Envelope #4 Rotated 208 x 110 mm</summary>
	DMPAPER_PENV_4_ROTATED = 112,

	/// <summary>PRC Envelope #5 Rotated 220 x 110 mm</summary>
	DMPAPER_PENV_5_ROTATED = 113,

	/// <summary>PRC Envelope #6 Rotated 230 x 120 mm</summary>
	DMPAPER_PENV_6_ROTATED = 114,

	/// <summary>PRC Envelope #7 Rotated 230 x 160 mm</summary>
	DMPAPER_PENV_7_ROTATED = 115,

	/// <summary>PRC Envelope #8 Rotated 309 x 120 mm</summary>
	DMPAPER_PENV_8_ROTATED = 116,

	/// <summary>PRC Envelope #9 Rotated 324 x 229 mm</summary>
	DMPAPER_PENV_9_ROTATED = 117,

	/// <summary>PRC Envelope #10 Rotated 458 x 324 mm</summary>
	DMPAPER_PENV_10_ROTATED = 118,

	/// <summary>User-defined lower bounds.</summary>
	DMPAPER_USER = 256,
}

/// <summary>The printer resolution.</summary>
[PInvokeData("wingdi.h", MSDNShortId = "85741025-9393-42ab-8a6d-27f1ae2c0f1b")]
public enum DMRES : short
{
	/// <summary>Use draft resolution (96 DPI).</summary>
	DMRES_DRAFT = -1,

	/// <summary>Use low resolution (150 DPI).</summary>
	DMRES_LOW = -2,

	/// <summary>Use medium resolution (300 DPI).</summary>
	DMRES_MEDIUM = -3,

	/// <summary>Use high resolution (600 DPI).</summary>
	DMRES_HIGH = -4,
}

/// <summary>Specifies how TrueType fonts should be printed.</summary>
[PInvokeData("wingdi.h", MSDNShortId = "85741025-9393-42ab-8a6d-27f1ae2c0f1b")]
public enum DMTT : short
{
	/// <summary>Prints TrueType fonts as graphics. This is the default action for dot-matrix printers.</summary>
	DMTT_BITMAP = 1,

	/// <summary>
	/// Downloads TrueType fonts as soft fonts. This is the default action for Hewlett-Packard printers that use Printer Control
	/// Language (PCL).
	/// </summary>
	DMTT_DOWNLOAD = 2,

	/// <summary>Substitute device fonts for TrueType fonts. This is the default action for PostScript printers.</summary>
	DMTT_SUBDEV = 3,

	/// <summary>Downloads TrueType fonts as outline soft fonts.</summary>
	DMTT_DOWNLOAD_OUTLINE = 4
}

/// <summary>
/// The <c>DEVMODE</c> data structure contains information about the initialization and environment of a printer or a display device.
/// </summary>
/// <remarks>
/// A device driver's private data follows the public portion of the <c>DEVMODE</c> structure. The size of the public data can vary
/// for different versions of the structure. The <c>dmSize</c> member specifies the number of bytes of public data, and the
/// <c>dmDriverExtra</c> member specifies the number of bytes of private data.
/// </remarks>
// https://docs.microsoft.com/en-us/windows/desktop/api/wingdi/ns-wingdi-_devicemodea typedef struct _devicemodeA { BYTE
// dmDeviceName[CCHDEVICENAME]; WORD dmSpecVersion; WORD dmDriverVersion; WORD dmSize; WORD dmDriverExtra; DWORD dmFields; union {
// struct { short dmOrientation; short dmPaperSize; short dmPaperLength; short dmPaperWidth; short dmScale; short dmCopies; short
// dmDefaultSource; short dmPrintQuality; } DUMMYSTRUCTNAME; POINTL dmPosition; struct { POINTL dmPosition; DWORD
// dmDisplayOrientation; DWORD dmDisplayFixedOutput; } DUMMYSTRUCTNAME2; } DUMMYUNIONNAME; short dmColor; short dmDuplex; short
// dmYResolution; short dmTTOption; short dmCollate; BYTE dmFormName[CCHFORMNAME]; WORD dmLogPixels; DWORD dmBitsPerPel; DWORD
// dmPelsWidth; DWORD dmPelsHeight; union { DWORD dmDisplayFlags; DWORD dmNup; } DUMMYUNIONNAME2; DWORD dmDisplayFrequency; DWORD
// dmICMMethod; DWORD dmICMIntent; DWORD dmMediaType; DWORD dmDitherType; DWORD dmReserved1; DWORD dmReserved2; DWORD dmPanningWidth;
// DWORD dmPanningHeight; } DEVMODEA, *PDEVMODEA, *NPDEVMODEA, *LPDEVMODEA;
[PInvokeData("wingdi.h", MSDNShortId = "85741025-9393-42ab-8a6d-27f1ae2c0f1b")]
[StructLayout(LayoutKind.Sequential, CharSet = CharSet.Auto)]
public struct DEVMODE
{
	/// <summary>Version for XP and later.</summary>
	public const ushort DM_SPECVERSION = 0x0401;

	/// <summary>
	/// A zero-terminated character array that specifies the "friendly" name of the printer or display; for example, "PCL/HP
	/// LaserJet" in the case of PCL/HP LaserJet. This string is unique among device drivers. Note that this name may be truncated to
	/// fit in the <c>dmDeviceName</c> array.
	/// </summary>
	[MarshalAs(UnmanagedType.ByValTStr, SizeConst = 32)]
	public string dmDeviceName;

	/// <summary>
	/// The version number of the initialization data specification on which the structure is based. To ensure the correct version is
	/// used for any operating system, use DM_SPECVERSION.
	/// </summary>
	public ushort dmSpecVersion;

	/// <summary>The driver version number assigned by the driver developer.</summary>
	public ushort dmDriverVersion;

	/// <summary>
	/// Specifies the size, in bytes, of the <c>DEVMODE</c> structure, not including any private driver-specific data that might
	/// follow the structure's public members. Set this member to to indicate the version of the <c>DEVMODE</c> structure being used.
	/// </summary>
	public ushort dmSize;

	/// <summary>
	/// Contains the number of bytes of private driver-data that follow this structure. If a device driver does not use
	/// device-specific information, set this member to zero.
	/// </summary>
	public ushort dmDriverExtra;

	/// <summary>
	/// <para>
	/// Specifies whether certain members of the <c>DEVMODE</c> structure have been initialized. If a member is initialized, its
	/// corresponding bit is set, otherwise the bit is clear. A driver supports only those <c>DEVMODE</c> members that are
	/// appropriate for the printer or display technology.
	/// </para>
	/// <para>The following values are defined, and are listed here with the corresponding structure members.</para>
	/// <list type="table">
	/// <listheader>
	/// <term>Value</term>
	/// <term>Structure member</term>
	/// </listheader>
	/// <item>
	/// <term>DM_ORIENTATION</term>
	/// <term>dmOrientation</term>
	/// </item>
	/// <item>
	/// <term>DM_PAPERSIZE</term>
	/// <term>dmPaperSize</term>
	/// </item>
	/// <item>
	/// <term>DM_PAPERLENGTH</term>
	/// <term>dmPaperLength</term>
	/// </item>
	/// <item>
	/// <term>DM_PAPERWIDTH</term>
	/// <term>dmPaperWidth</term>
	/// </item>
	/// <item>
	/// <term>DM_SCALE</term>
	/// <term>dmScale</term>
	/// </item>
	/// <item>
	/// <term>DM_COPIES</term>
	/// <term>dmCopies</term>
	/// </item>
	/// <item>
	/// <term>DM_DEFAULTSOURCE</term>
	/// <term>dmDefaultSource</term>
	/// </item>
	/// <item>
	/// <term>DM_PRINTQUALITY</term>
	/// <term>dmPrintQuality</term>
	/// </item>
	/// <item>
	/// <term>DM_POSITION</term>
	/// <term>dmPosition</term>
	/// </item>
	/// <item>
	/// <term>DM_DISPLAYORIENTATION</term>
	/// <term>dmDisplayOrientation</term>
	/// </item>
	/// <item>
	/// <term>DM_DISPLAYFIXEDOUTPUT</term>
	/// <term>dmDisplayFixedOutput</term>
	/// </item>
	/// <item>
	/// <term>DM_COLOR</term>
	/// <term>dmColor</term>
	/// </item>
	/// <item>
	/// <term>DM_DUPLEX</term>
	/// <term>dmDuplex</term>
	/// </item>
	/// <item>
	/// <term>DM_YRESOLUTION</term>
	/// <term>dmYResolution</term>
	/// </item>
	/// <item>
	/// <term>DM_TTOPTION</term>
	/// <term>dmTTOption</term>
	/// </item>
	/// <item>
	/// <term>DM_COLLATE</term>
	/// <term>dmCollate</term>
	/// </item>
	/// <item>
	/// <term>DM_FORMNAME</term>
	/// <term>dmFormName</term>
	/// </item>
	/// <item>
	/// <term>DM_LOGPIXELS</term>
	/// <term>dmLogPixels</term>
	/// </item>
	/// <item>
	/// <term>DM_BITSPERPEL</term>
	/// <term>dmBitsPerPel</term>
	/// </item>
	/// <item>
	/// <term>DM_PELSWIDTH</term>
	/// <term>dmPelsWidth</term>
	/// </item>
	/// <item>
	/// <term>DM_PELSHEIGHT</term>
	/// <term>dmPelsHeight</term>
	/// </item>
	/// <item>
	/// <term>DM_DISPLAYFLAGS</term>
	/// <term>dmDisplayFlags</term>
	/// </item>
	/// <item>
	/// <term>DM_NUP</term>
	/// <term>dmNup</term>
	/// </item>
	/// <item>
	/// <term>DM_DISPLAYFREQUENCY</term>
	/// <term>dmDisplayFrequency</term>
	/// </item>
	/// <item>
	/// <term>DM_ICMMETHOD</term>
	/// <term>dmICMMethod</term>
	/// </item>
	/// <item>
	/// <term>DM_ICMINTENT</term>
	/// <term>dmICMIntent</term>
	/// </item>
	/// <item>
	/// <term>DM_MEDIATYPE</term>
	/// <term>dmMediaType</term>
	/// </item>
	/// <item>
	/// <term>DM_DITHERTYPE</term>
	/// <term>dmDitherType</term>
	/// </item>
	/// <item>
	/// <term>DM_PANNINGWIDTH</term>
	/// <term>dmPanningWidth</term>
	/// </item>
	/// <item>
	/// <term>DM_PANNINGHEIGHT</term>
	/// <term>dmPanningHeight</term>
	/// </item>
	/// </list>
	/// </summary>
	public DMFIELDS dmFields;

	/// <summary>DUMMYUNIONNAME</summary>
	private DEVMODE_U1 Union;

	[StructLayout(LayoutKind.Explicit)]
	private struct DEVMODE_U1
	{
		[FieldOffset(0)]
		public DMORIENT dmOrientation;

		[FieldOffset(2)]
		public DMPAPER dmPaperSize;

		[FieldOffset(4)]
		public short dmPaperLength;

		[FieldOffset(6)]
		public short dmPaperWidth;

		[FieldOffset(8)]
		public short dmScale;

		[FieldOffset(10)]
		public short dmCopies;

		[FieldOffset(12)]
		public short dmDefaultSource;

		[FieldOffset(14)]
		public DMRES dmPrintQuality;

		[FieldOffset(0)]
		public POINT dmPosition;

		[FieldOffset(8)]
		public DMDO dmDisplayOrientation;

		[FieldOffset(12)]
		public DMDFO dmDisplayFixedOutput;
	}

	/// <summary>
	/// For printer devices only, selects the orientation of the paper. This member can be either DMORIENT_PORTRAIT (1) or
	/// DMORIENT_LANDSCAPE (2).
	/// </summary>
	public DMORIENT dmOrientation { readonly get => Union.dmOrientation; set => Union.dmOrientation = value; }

	/// <summary>
	/// <para>
	/// For printer devices only, selects the size of the paper to print on. This member can be set to zero if the length and width
	/// of the paper are both set by the <c>dmPaperLength</c> and <c>dmPaperWidth</c> members. Otherwise, the <c>dmPaperSize</c>
	/// member can be set to a device specific value greater than or equal to DMPAPER_USER or to one of the following predefined values.
	/// </para>
	/// <list type="table">
	/// <listheader>
	/// <term>Value</term>
	/// <term>Meaning</term>
	/// </listheader>
	/// <item>
	/// <term>DMPAPER_LETTER</term>
	/// <term>Letter, 8 1/2- by 11-inches</term>
	/// </item>
	/// <item>
	/// <term>DMPAPER_LEGAL</term>
	/// <term>Legal, 8 1/2- by 14-inches</term>
	/// </item>
	/// <item>
	/// <term>DMPAPER_9X11</term>
	/// <term>9- by 11-inch sheet</term>
	/// </item>
	/// <item>
	/// <term>DMPAPER_10X11</term>
	/// <term>10- by 11-inch sheet</term>
	/// </item>
	/// <item>
	/// <term>DMPAPER_10X14</term>
	/// <term>10- by 14-inch sheet</term>
	/// </item>
	/// <item>
	/// <term>DMPAPER_15X11</term>
	/// <term>15- by 11-inch sheet</term>
	/// </item>
	/// <item>
	/// <term>DMPAPER_11X17</term>
	/// <term>11- by 17-inch sheet</term>
	/// </item>
	/// <item>
	/// <term>DMPAPER_12X11</term>
	/// <term>12- by 11-inch sheet</term>
	/// </item>
	/// <item>
	/// <term>DMPAPER_A2</term>
	/// <term>A2 sheet, 420 x 594-millimeters</term>
	/// </item>
	/// <item>
	/// <term>DMPAPER_A3</term>
	/// <term>A3 sheet, 297- by 420-millimeters</term>
	/// </item>
	/// <item>
	/// <term>DMPAPER_A3_EXTRA</term>
	/// <term>A3 Extra 322 x 445-millimeters</term>
	/// </item>
	/// <item>
	/// <term>DMPAPER_A3_EXTRA_TRAVERSE</term>
	/// <term>A3 Extra Transverse 322 x 445-millimeters</term>
	/// </item>
	/// <item>
	/// <term>DMPAPER_A3_ROTATED</term>
	/// <term>A3 rotated sheet, 420- by 297-millimeters</term>
	/// </item>
	/// <item>
	/// <term>DMPAPER_A3_TRAVERSE</term>
	/// <term>A3 Transverse 297 x 420-millimeters</term>
	/// </item>
	/// <item>
	/// <term>DMPAPER_A4</term>
	/// <term>A4 sheet, 210- by 297-millimeters</term>
	/// </item>
	/// <item>
	/// <term>DMPAPER_A4_EXTRA</term>
	/// <term>A4 sheet, 9.27 x 12.69 inches</term>
	/// </item>
	/// <item>
	/// <term>DMPAPER_A4_PLUS</term>
	/// <term>A4 Plus 210 x 330-millimeters</term>
	/// </item>
	/// <item>
	/// <term>DMPAPER_A4_ROTATED</term>
	/// <term>A4 rotated sheet, 297- by 210-millimeters</term>
	/// </item>
	/// <item>
	/// <term>DMPAPER_A4SMALL</term>
	/// <term>A4 small sheet, 210- by 297-millimeters</term>
	/// </item>
	/// <item>
	/// <term>DMPAPER_A4_TRANSVERSE</term>
	/// <term>A4 Transverse 210 x 297 millimeters</term>
	/// </item>
	/// <item>
	/// <term>DMPAPER_A5</term>
	/// <term>A5 sheet, 148- by 210-millimeters</term>
	/// </item>
	/// <item>
	/// <term>DMPAPER_A5_EXTRA</term>
	/// <term>A5 Extra 174 x 235-millimeters</term>
	/// </item>
	/// <item>
	/// <term>DMPAPER_A5_ROTATED</term>
	/// <term>A5 rotated sheet, 210- by 148-millimeters</term>
	/// </item>
	/// <item>
	/// <term>DMPAPER_A5_TRANSVERSE</term>
	/// <term>A5 Transverse 148 x 210-millimeters</term>
	/// </item>
	/// <item>
	/// <term>DMPAPER_A6</term>
	/// <term>A6 sheet, 105- by 148-millimeters</term>
	/// </item>
	/// <item>
	/// <term>DMPAPER_A6_ROTATED</term>
	/// <term>A6 rotated sheet, 148- by 105-millimeters</term>
	/// </item>
	/// <item>
	/// <term>DMPAPER_A_PLUS</term>
	/// <term>SuperA/A4 227 x 356 -millimeters</term>
	/// </item>
	/// <item>
	/// <term>DMPAPER_B4</term>
	/// <term>B4 sheet, 250- by 354-millimeters</term>
	/// </item>
	/// <item>
	/// <term>DMPAPER_B4_JIS_ROTATED</term>
	/// <term>B4 (JIS) rotated sheet, 364- by 257-millimeters</term>
	/// </item>
	/// <item>
	/// <term>DMPAPER_B5</term>
	/// <term>B5 sheet, 182- by 257-millimeter paper</term>
	/// </item>
	/// <item>
	/// <term>DMPAPER_B5_EXTRA</term>
	/// <term>B5 (ISO) Extra 201 x 276-millimeters</term>
	/// </item>
	/// <item>
	/// <term>DMPAPER_B5_JIS_ROTATED</term>
	/// <term>B5 (JIS) rotated sheet, 257- by 182-millimeters</term>
	/// </item>
	/// <item>
	/// <term>DMPAPER_B6_JIS</term>
	/// <term>B6 (JIS) sheet, 128- by 182-millimeters</term>
	/// </item>
	/// <item>
	/// <term>DMPAPER_B6_JIS_ROTATED</term>
	/// <term>B6 (JIS) rotated sheet, 182- by 128-millimeters</term>
	/// </item>
	/// <item>
	/// <term>DMPAPER_B_PLUS</term>
	/// <term>SuperB/A3 305 x 487-millimeters</term>
	/// </item>
	/// <item>
	/// <term>DMPAPER_CSHEET</term>
	/// <term>C Sheet, 17- by 22-inches</term>
	/// </item>
	/// <item>
	/// <term>DMPAPER_DBL_JAPANESE_POSTCARD</term>
	/// <term>Double Japanese Postcard, 200- by 148-millimeters</term>
	/// </item>
	/// <item>
	/// <term>DMPAPER_DBL_JAPANESE_POSTCARD_ROTATED</term>
	/// <term>Double Japanese Postcard Rotated, 148- by 200-millimeters</term>
	/// </item>
	/// <item>
	/// <term>DMPAPER_DSHEET</term>
	/// <term>D Sheet, 22- by 34-inches</term>
	/// </item>
	/// <item>
	/// <term>DMPAPER_ENV_9</term>
	/// <term>#9 Envelope, 3 7/8- by 8 7/8-inches</term>
	/// </item>
	/// <item>
	/// <term>DMPAPER_ENV_10</term>
	/// <term>#10 Envelope, 4 1/8- by 9 1/2-inches</term>
	/// </item>
	/// <item>
	/// <term>DMPAPER_ENV_11</term>
	/// <term>#11 Envelope, 4 1/2- by 10 3/8-inches</term>
	/// </item>
	/// <item>
	/// <term>DMPAPER_ENV_12</term>
	/// <term>#12 Envelope, 4 3/4- by 11-inches</term>
	/// </item>
	/// <item>
	/// <term>DMPAPER_ENV_14</term>
	/// <term>#14 Envelope, 5- by 11 1/2-inches</term>
	/// </item>
	/// <item>
	/// <term>DMPAPER_ENV_C5</term>
	/// <term>C5 Envelope, 162- by 229-millimeters</term>
	/// </item>
	/// <item>
	/// <term>DMPAPER_ENV_C3</term>
	/// <term>C3 Envelope, 324- by 458-millimeters</term>
	/// </item>
	/// <item>
	/// <term>DMPAPER_ENV_C4</term>
	/// <term>C4 Envelope, 229- by 324-millimeters</term>
	/// </item>
	/// <item>
	/// <term>DMPAPER_ENV_C6</term>
	/// <term>C6 Envelope, 114- by 162-millimeters</term>
	/// </item>
	/// <item>
	/// <term>DMPAPER_ENV_C65</term>
	/// <term>C65 Envelope, 114- by 229-millimeters</term>
	/// </item>
	/// <item>
	/// <term>DMPAPER_ENV_B4</term>
	/// <term>B4 Envelope, 250- by 353-millimeters</term>
	/// </item>
	/// <item>
	/// <term>DMPAPER_ENV_B5</term>
	/// <term>B5 Envelope, 176- by 250-millimeters</term>
	/// </item>
	/// <item>
	/// <term>DMPAPER_ENV_B6</term>
	/// <term>B6 Envelope, 176- by 125-millimeters</term>
	/// </item>
	/// <item>
	/// <term>DMPAPER_ENV_DL</term>
	/// <term>DL Envelope, 110- by 220-millimeters</term>
	/// </item>
	/// <item>
	/// <term>DMPAPER_ENV_INVITE</term>
	/// <term>Envelope Invite 220 x 220 mm</term>
	/// </item>
	/// <item>
	/// <term>DMPAPER_ENV_ITALY</term>
	/// <term>Italy Envelope, 110- by 230-millimeters</term>
	/// </item>
	/// <item>
	/// <term>DMPAPER_ENV_MONARCH</term>
	/// <term>Monarch Envelope, 3 7/8- by 7 1/2-inches</term>
	/// </item>
	/// <item>
	/// <term>DMPAPER_ENV_PERSONAL</term>
	/// <term>6 3/4 Envelope, 3 5/8- by 6 1/2-inches</term>
	/// </item>
	/// <item>
	/// <term>DMPAPER_ESHEET</term>
	/// <term>E Sheet, 34- by 44-inches</term>
	/// </item>
	/// <item>
	/// <term>DMPAPER_EXECUTIVE</term>
	/// <term>Executive, 7 1/4- by 10 1/2-inches</term>
	/// </item>
	/// <item>
	/// <term>DMPAPER_FANFOLD_US</term>
	/// <term>US Std Fanfold, 14 7/8- by 11-inches</term>
	/// </item>
	/// <item>
	/// <term>DMPAPER_FANFOLD_STD_GERMAN</term>
	/// <term>German Std Fanfold, 8 1/2- by 12-inches</term>
	/// </item>
	/// <item>
	/// <term>DMPAPER_FANFOLD_LGL_GERMAN</term>
	/// <term>German Legal Fanfold, 8 - by 13-inches</term>
	/// </item>
	/// <item>
	/// <term>DMPAPER_FOLIO</term>
	/// <term>Folio, 8 1/2- by 13-inch paper</term>
	/// </item>
	/// <item>
	/// <term>DMPAPER_ISO_B4</term>
	/// <term>B4 (ISO) 250- by 353-millimeters paper</term>
	/// </item>
	/// <item>
	/// <term>DMPAPER_JAPANESE_POSTCARD</term>
	/// <term>Japanese Postcard, 100- by 148-millimeters</term>
	/// </item>
	/// <item>
	/// <term>DMPAPER_JAPANESE_POSTCARD_ROTATED</term>
	/// <term>Japanese Postcard Rotated, 148- by 100-millimeters</term>
	/// </item>
	/// <item>
	/// <term>DMPAPER_JENV_CHOU3</term>
	/// <term>Japanese Envelope Chou #3</term>
	/// </item>
	/// <item>
	/// <term>DMPAPER_JENV_CHOU3_ROTATED</term>
	/// <term>Japanese Envelope Chou #3 Rotated</term>
	/// </item>
	/// <item>
	/// <term>DMPAPER_JENV_CHOU4</term>
	/// <term>Japanese Envelope Chou #4</term>
	/// </item>
	/// <item>
	/// <term>DMPAPER_JENV_CHOU4_ROTATED</term>
	/// <term>Japanese Envelope Chou #4 Rotated</term>
	/// </item>
	/// <item>
	/// <term>DMPAPER_JENV_KAKU2</term>
	/// <term>Japanese Envelope Kaku #2</term>
	/// </item>
	/// <item>
	/// <term>DMPAPER_JENV_KAKU2_ROTATED</term>
	/// <term>Japanese Envelope Kaku #2 Rotated</term>
	/// </item>
	/// <item>
	/// <term>DMPAPER_JENV_KAKU3</term>
	/// <term>Japanese Envelope Kaku #3</term>
	/// </item>
	/// <item>
	/// <term>DMPAPER_JENV_KAKU3_ROTATED</term>
	/// <term>Japanese Envelope Kaku #3 Rotated</term>
	/// </item>
	/// <item>
	/// <term>DMPAPER_JENV_YOU4</term>
	/// <term>Japanese Envelope You #4</term>
	/// </item>
	/// <item>
	/// <term>DMPAPER_JENV_YOU4_ROTATED</term>
	/// <term>Japanese Envelope You #4 Rotated</term>
	/// </item>
	/// <item>
	/// <term>DMPAPER_LAST</term>
	/// <term>DMPAPER_PENV_10_ROTATED</term>
	/// </item>
	/// <item>
	/// <term>DMPAPER_LEDGER</term>
	/// <term>Ledger, 17- by 11-inches</term>
	/// </item>
	/// <item>
	/// <term>DMPAPER_LEGAL_EXTRA</term>
	/// <term>Legal Extra 9 1/2 x 15 inches.</term>
	/// </item>
	/// <item>
	/// <term>DMPAPER_LETTER_EXTRA</term>
	/// <term>Letter Extra 9 1/2 x 12 inches.</term>
	/// </item>
	/// <item>
	/// <term>DMPAPER_LETTER_EXTRA_TRANSVERSE</term>
	/// <term>Letter Extra Transverse 9 1/2 x 12 inches.</term>
	/// </item>
	/// <item>
	/// <term>DMPAPER_LETTER_ROTATED</term>
	/// <term>Letter Rotated 11 by 8 1/2 inches</term>
	/// </item>
	/// <item>
	/// <term>DMPAPER_LETTERSMALL</term>
	/// <term>Letter Small, 8 1/2- by 11-inches</term>
	/// </item>
	/// <item>
	/// <term>DMPAPER_LETTER_TRANSVERSE</term>
	/// <term>Letter Transverse 8 1/2 x 11-inches</term>
	/// </item>
	/// <item>
	/// <term>DMPAPER_NOTE</term>
	/// <term>Note, 8 1/2- by 11-inches</term>
	/// </item>
	/// <item>
	/// <term>DMPAPER_P16K</term>
	/// <term>PRC 16K, 146- by 215-millimeters</term>
	/// </item>
	/// <item>
	/// <term>DMPAPER_P16K_ROTATED</term>
	/// <term>PRC 16K Rotated, 215- by 146-millimeters</term>
	/// </item>
	/// <item>
	/// <term>DMPAPER_P32K</term>
	/// <term>PRC 32K, 97- by 151-millimeters</term>
	/// </item>
	/// <item>
	/// <term>DMPAPER_P32K_ROTATED</term>
	/// <term>PRC 32K Rotated, 151- by 97-millimeters</term>
	/// </item>
	/// <item>
	/// <term>DMPAPER_P32KBIG</term>
	/// <term>PRC 32K(Big) 97- by 151-millimeters</term>
	/// </item>
	/// <item>
	/// <term>DMPAPER_P32KBIG_ROTATED</term>
	/// <term>PRC 32K(Big) Rotated, 151- by 97-millimeters</term>
	/// </item>
	/// <item>
	/// <term>DMPAPER_PENV_1</term>
	/// <term>PRC Envelope #1, 102- by 165-millimeters</term>
	/// </item>
	/// <item>
	/// <term>DMPAPER_PENV_1_ROTATED</term>
	/// <term>PRC Envelope #1 Rotated, 165- by 102-millimeters</term>
	/// </item>
	/// <item>
	/// <term>DMPAPER_PENV_2</term>
	/// <term>PRC Envelope #2, 102- by 176-millimeters</term>
	/// </item>
	/// <item>
	/// <term>DMPAPER_PENV_2_ROTATED</term>
	/// <term>PRC Envelope #2 Rotated, 176- by 102-millimeters</term>
	/// </item>
	/// <item>
	/// <term>DMPAPER_PENV_3</term>
	/// <term>PRC Envelope #3, 125- by 176-millimeters</term>
	/// </item>
	/// <item>
	/// <term>DMPAPER_PENV_3_ROTATED</term>
	/// <term>PRC Envelope #3 Rotated, 176- by 125-millimeters</term>
	/// </item>
	/// <item>
	/// <term>DMPAPER_PENV_4</term>
	/// <term>PRC Envelope #4, 110- by 208-millimeters</term>
	/// </item>
	/// <item>
	/// <term>DMPAPER_PENV_4_ROTATED</term>
	/// <term>PRC Envelope #4 Rotated, 208- by 110-millimeters</term>
	/// </item>
	/// <item>
	/// <term>DMPAPER_PENV_5</term>
	/// <term>PRC Envelope #5, 110- by 220-millimeters</term>
	/// </item>
	/// <item>
	/// <term>DMPAPER_PENV_5_ROTATED</term>
	/// <term>PRC Envelope #5 Rotated, 220- by 110-millimeters</term>
	/// </item>
	/// <item>
	/// <term>DMPAPER_PENV_6</term>
	/// <term>PRC Envelope #6, 120- by 230-millimeters</term>
	/// </item>
	/// <item>
	/// <term>DMPAPER_PENV_6_ROTATED</term>
	/// <term>PRC Envelope #6 Rotated, 230- by 120-millimeters</term>
	/// </item>
	/// <item>
	/// <term>DMPAPER_PENV_7</term>
	/// <term>PRC Envelope #7, 160- by 230-millimeters</term>
	/// </item>
	/// <item>
	/// <term>DMPAPER_PENV_7_ROTATED</term>
	/// <term>PRC Envelope #7 Rotated, 230- by 160-millimeters</term>
	/// </item>
	/// <item>
	/// <term>DMPAPER_PENV_8</term>
	/// <term>PRC Envelope #8, 120- by 309-millimeters</term>
	/// </item>
	/// <item>
	/// <term>DMPAPER_PENV_8_ROTATED</term>
	/// <term>PRC Envelope #8 Rotated, 309- by 120-millimeters</term>
	/// </item>
	/// <item>
	/// <term>DMPAPER_PENV_9</term>
	/// <term>PRC Envelope #9, 229- by 324-millimeters</term>
	/// </item>
	/// <item>
	/// <term>DMPAPER_PENV_9_ROTATED</term>
	/// <term>PRC Envelope #9 Rotated, 324- by 229-millimeters</term>
	/// </item>
	/// <item>
	/// <term>DMPAPER_PENV_10</term>
	/// <term>PRC Envelope #10, 324- by 458-millimeters</term>
	/// </item>
	/// <item>
	/// <term>DMPAPER_PENV_10_ROTATED</term>
	/// <term>PRC Envelope #10 Rotated, 458- by 324-millimeters</term>
	/// </item>
	/// <item>
	/// <term>DMPAPER_QUARTO</term>
	/// <term>Quarto, 215- by 275-millimeter paper</term>
	/// </item>
	/// <item>
	/// <term>DMPAPER_STATEMENT</term>
	/// <term>Statement, 5 1/2- by 8 1/2-inches</term>
	/// </item>
	/// <item>
	/// <term>DMPAPER_TABLOID</term>
	/// <term>Tabloid, 11- by 17-inches</term>
	/// </item>
	/// <item>
	/// <term>DMPAPER_TABLOID_EXTRA</term>
	/// <term>Tabloid, 11.69 x 18-inches</term>
	/// </item>
	/// </list>
	/// </summary>
	public DMPAPER dmPaperSize { readonly get => Union.dmPaperSize; set => Union.dmPaperSize = value; }

	/// <summary>
	/// For printer devices only, overrides the length of the paper specified by the <c>dmPaperSize</c> member, either for custom
	/// paper sizes or for devices such as dot-matrix printers that can print on a page of arbitrary length. These values, along with
	/// all other values in this structure that specify a physical length, are in tenths of a millimeter.
	/// </summary>
	public short dmPaperLength { readonly get => Union.dmPaperLength; set => Union.dmPaperLength = value; }

	/// <summary>For printer devices only, overrides the width of the paper specified by the <c>dmPaperSize</c> member.</summary>
	public short dmPaperWidth { readonly get => Union.dmPaperWidth; set => Union.dmPaperWidth = value; }

	/// <summary>
	/// Specifies the factor by which the printed output is to be scaled. The apparent page size is scaled from the physical page
	/// size by a factor of <c>dmScale</c> /100. For example, a letter-sized page with a <c>dmScale</c> value of 50 would contain as
	/// much data as a page of 17- by 22-inches because the output text and graphics would be half their original height and width.
	/// </summary>
	public short dmScale { readonly get => Union.dmScale; set => Union.dmScale = value; }

	/// <summary>Selects the number of copies printed if the device supports multiple-page copies.</summary>
	public short dmCopies { readonly get => Union.dmCopies; set => Union.dmCopies = value; }

	/// <summary>
	/// <para>
	/// Specifies the paper source. To retrieve a list of the available paper sources for a printer, use the DeviceCapabilities
	/// function with the DC_BINS flag.
	/// </para>
	/// <para>This member can be one of the following values, or it can be a device-specific value greater than or equal to DMBIN_USER.</para>
	/// </summary>
	public short dmDefaultSource { readonly get => Union.dmDefaultSource; set => Union.dmDefaultSource = value; }

	/// <summary>
	/// <para>Specifies the printer resolution. There are four predefined device-independent values:</para>
	/// <para>If a positive value is specified, it specifies the number of dots per inch (DPI) and is therefore device dependent.</para>
	/// </summary>
	public DMRES dmPrintQuality { readonly get => Union.dmPrintQuality; set => Union.dmPrintQuality = value; }

	/// <summary>
	/// For display devices only, a POINTL structure that indicates the positional coordinates of the display device in reference to
	/// the desktop area. The primary display device is always located at coordinates (0,0).
	/// </summary>
	public POINT dmPosition { readonly get => Union.dmPosition; set => Union.dmPosition = value; }

	/// <summary>
	/// <para>
	/// For display devices only, the orientation at which images should be presented. If DM_DISPLAYORIENTATION is not set, this
	/// member must be zero. If DM_DISPLAYORIENTATION is set, this member must be one of the following values
	/// </para>
	/// <list type="table">
	/// <listheader>
	/// <term>Value</term>
	/// <term>Meaning</term>
	/// </listheader>
	/// <item>
	/// <term>DMDO_DEFAULT</term>
	/// <term>The display orientation is the natural orientation of the display device; it should be used as the default.</term>
	/// </item>
	/// <item>
	/// <term>DMDO_90</term>
	/// <term>The display orientation is rotated 90 degrees (measured clockwise) from DMDO_DEFAULT.</term>
	/// </item>
	/// <item>
	/// <term>DMDO_180</term>
	/// <term>The display orientation is rotated 180 degrees (measured clockwise) from DMDO_DEFAULT.</term>
	/// </item>
	/// <item>
	/// <term>DMDO_270</term>
	/// <term>The display orientation is rotated 270 degrees (measured clockwise) from DMDO_DEFAULT.</term>
	/// </item>
	/// </list>
	/// <para>
	/// To determine whether the display orientation is portrait or landscape orientation, check the ratio of <c>dmPelsWidth</c> to <c>dmPelsHeight</c>.
	/// </para>
	/// <para><c>Windows 2000:</c> Not supported.</para>
	/// </summary>
	public DMDO dmDisplayOrientation { readonly get => Union.dmDisplayOrientation; set => Union.dmDisplayOrientation = value; }

	/// <summary>
	/// <para>
	/// For fixed-resolution display devices only, how the display presents a low-resolution mode on a higher-resolution display. For
	/// example, if a display device's resolution is fixed at 1024 x 768 pixels but its mode is set to 640 x 480 pixels, the device
	/// can either display a 640 x 480 image somewhere in the interior of the 1024 x 768 screen space or stretch the 640 x 480 image
	/// to fill the larger screen space. If DM_DISPLAYFIXEDOUTPUT is not set, this member must be zero. If DM_DISPLAYFIXEDOUTPUT is
	/// set, this member must be one of the following values.
	/// </para>
	/// <list type="table">
	/// <listheader>
	/// <term>Value</term>
	/// <term>Meaning</term>
	/// </listheader>
	/// <item>
	/// <term>DMDFO_DEFAULT</term>
	/// <term>The display's default setting.</term>
	/// </item>
	/// <item>
	/// <term>DMDFO_CENTER</term>
	/// <term>The low-resolution image is centered in the larger screen space.</term>
	/// </item>
	/// <item>
	/// <term>DMDFO_STRETCH</term>
	/// <term>The low-resolution image is stretched to fill the larger screen space.</term>
	/// </item>
	/// </list>
	/// <para><c>Windows 2000:</c> Not supported.</para>
	/// </summary>
	public DMDFO dmDisplayFixedOutput { readonly get => Union.dmDisplayFixedOutput; set => Union.dmDisplayFixedOutput = value; }

	/// <summary>
	/// <para>Switches between color and monochrome on color printers. The following are the possible values:</para>
	/// <list type="bullet">
	/// <item>
	/// <term>DMCOLOR_COLOR</term>
	/// </item>
	/// <item>
	/// <term>DMCOLOR_MONOCHROME</term>
	/// </item>
	/// </list>
	/// </summary>
	public DMCOLOR dmColor;

	/// <summary>
	/// <para>Selects duplex or double-sided printing for printers capable of duplex printing. Following are the possible values.</para>
	/// <list type="table">
	/// <listheader>
	/// <term>Value</term>
	/// <term>Meaning</term>
	/// </listheader>
	/// <item>
	/// <term>DMDUP_SIMPLEX</term>
	/// <term>Normal (nonduplex) printing.</term>
	/// </item>
	/// <item>
	/// <term>DMDUP_HORIZONTAL</term>
	/// <term>Short-edge binding, that is, the long edge of the page is horizontal.</term>
	/// </item>
	/// <item>
	/// <term>DMDUP_VERTICAL</term>
	/// <term>Long-edge binding, that is, the long edge of the page is vertical.</term>
	/// </item>
	/// </list>
	/// </summary>
	public DMDUP dmDuplex;

	/// <summary>
	/// Specifies the y-resolution, in dots per inch, of the printer. If the printer initializes this member, the
	/// <c>dmPrintQuality</c> member specifies the x-resolution, in dots per inch, of the printer.
	/// </summary>
	public short dmYResolution;

	/// <summary>
	/// <para>Specifies how TrueType fonts should be printed. This member can be one of the following values.</para>
	/// <list type="table">
	/// <listheader>
	/// <term>Value</term>
	/// <term>Meaning</term>
	/// </listheader>
	/// <item>
	/// <term>DMTT_BITMAP</term>
	/// <term>Prints TrueType fonts as graphics. This is the default action for dot-matrix printers.</term>
	/// </item>
	/// <item>
	/// <term>DMTT_DOWNLOAD</term>
	/// <term>
	/// Downloads TrueType fonts as soft fonts. This is the default action for Hewlett-Packard printers that use Printer Control
	/// Language (PCL).
	/// </term>
	/// </item>
	/// <item>
	/// <term>DMTT_DOWNLOAD_OUTLINE</term>
	/// <term>Downloads TrueType fonts as outline soft fonts.</term>
	/// </item>
	/// <item>
	/// <term>DMTT_SUBDEV</term>
	/// <term>Substitutes device fonts for TrueType fonts. This is the default action for PostScript printers.</term>
	/// </item>
	/// </list>
	/// </summary>
	public DMTT dmTTOption;

	/// <summary>
	/// <para>
	/// Specifies whether collation should be used when printing multiple copies. (This member is ignored unless the printer driver
	/// indicates support for collation by setting the <c>dmFields</c> member to DM_COLLATE.) This member can be one of the following values.
	/// </para>
	/// <list type="table">
	/// <listheader>
	/// <term>Value</term>
	/// <term>Meaning</term>
	/// </listheader>
	/// <item>
	/// <term>DMCOLLATE_TRUE</term>
	/// <term>Collate when printing multiple copies.</term>
	/// </item>
	/// <item>
	/// <term>DMCOLLATE_FALSE</term>
	/// <term>Do not collate when printing multiple copies.</term>
	/// </item>
	/// </list>
	/// </summary>
	public DMCOLLATE dmCollate;

	/// <summary>
	/// A zero-terminated character array that specifies the name of the form to use; for example, "Letter" or "Legal". A complete
	/// set of names can be retrieved by using the EnumForms function.
	/// </summary>
	[MarshalAs(UnmanagedType.ByValTStr, SizeConst = 32)]
	public string dmFormName;

	/// <summary>The number of pixels per logical inch. Printer drivers do not use this member.</summary>
	public ushort dmLogPixels;

	/// <summary>
	/// Specifies the color resolution, in bits per pixel, of the display device (for example: 4 bits for 16 colors, 8 bits for 256
	/// colors, or 16 bits for 65,536 colors). Display drivers use this member, for example, in the ChangeDisplaySettings function.
	/// Printer drivers do not use this member.
	/// </summary>
	public uint dmBitsPerPel;

	/// <summary>
	/// Specifies the width, in pixels, of the visible device surface. Display drivers use this member, for example, in the
	/// ChangeDisplaySettings function. Printer drivers do not use this member.
	/// </summary>
	public uint dmPelsWidth;

	/// <summary>
	/// Specifies the height, in pixels, of the visible device surface. Display drivers use this member, for example, in the
	/// ChangeDisplaySettings function. Printer drivers do not use this member.
	/// </summary>
	public uint dmPelsHeight;

	/// <summary>DUMMYUNIONNAME2</summary>
	private DEVMODE_U2 Union2;

	[StructLayout(LayoutKind.Explicit)]
	private struct DEVMODE_U2
	{
		[FieldOffset(0)]
		public DMDISPLAY dmDisplayFlags;

		[FieldOffset(0)]
		public DMNUP dmNup;
	}

	/// <summary>
	/// <para>Specifies the device's display mode. This member can be a combination of the following values.</para>
	/// <list type="table">
	/// <listheader>
	/// <term>Value</term>
	/// <term>Meaning</term>
	/// </listheader>
	/// <item>
	/// <term>DM_GRAYSCALE</term>
	/// <term>Specifies that the display is a noncolor device. If this flag is not set, color is assumed.</term>
	/// </item>
	/// <item>
	/// <term>DM_INTERLACED</term>
	/// <term>Specifies that the display mode is interlaced. If the flag is not set, noninterlaced is assumed.</term>
	/// </item>
	/// </list>
	/// <para>
	/// Display drivers use this member, for example, in the ChangeDisplaySettings function. Printer drivers do not use this member.
	/// </para>
	/// </summary>
	public DMDISPLAY dmDisplayFlags { readonly get => Union2.dmDisplayFlags; set => Union2.dmDisplayFlags = value; }

	/// <summary>
	/// <para>Specifies where the NUP is done. It can be one of the following.</para>
	/// <list type="table">
	/// <listheader>
	/// <term>Value</term>
	/// <term>Meaning</term>
	/// </listheader>
	/// <item>
	/// <term>DMNUP_SYSTEM</term>
	/// <term>The print spooler does the NUP.</term>
	/// </item>
	/// <item>
	/// <term>DMNUP_ONEUP</term>
	/// <term>The application does the NUP.</term>
	/// </item>
	/// </list>
	/// </summary>
	public DMNUP dmNup { readonly get => Union2.dmNup; set => Union2.dmNup = value; }

	/// <summary>
	/// <para>
	/// Specifies the frequency, in hertz (cycles per second), of the display device in a particular mode. This value is also known
	/// as the display device's vertical refresh rate. Display drivers use this member. It is used, for example, in the
	/// ChangeDisplaySettings function. Printer drivers do not use this member.
	/// </para>
	/// <para>
	/// When you call the EnumDisplaySettings function, the <c>dmDisplayFrequency</c> member may return with the value 0 or 1. These
	/// values represent the display hardware's default refresh rate. This default rate is typically set by switches on a display
	/// card or computer motherboard, or by a configuration program that does not use display functions such as ChangeDisplaySettings.
	/// </para>
	/// </summary>
	public uint dmDisplayFrequency;

	/// <summary>
	/// <para>
	/// Specifies how ICM is handled. For a non-ICM application, this member determines if ICM is enabled or disabled. For ICM
	/// applications, the system examines this member to determine how to handle ICM support. This member can be one of the following
	/// predefined values, or a driver-defined value greater than or equal to the value of DMICMMETHOD_USER.
	/// </para>
	/// <list type="table">
	/// <listheader>
	/// <term>Value</term>
	/// <term>Meaning</term>
	/// </listheader>
	/// <item>
	/// <term>DMICMMETHOD_NONE</term>
	/// <term>Specifies that ICM is disabled.</term>
	/// </item>
	/// <item>
	/// <term>DMICMMETHOD_SYSTEM</term>
	/// <term>Specifies that ICM is handled by Windows.</term>
	/// </item>
	/// <item>
	/// <term>DMICMMETHOD_DRIVER</term>
	/// <term>Specifies that ICM is handled by the device driver.</term>
	/// </item>
	/// <item>
	/// <term>DMICMMETHOD_DEVICE</term>
	/// <term>Specifies that ICM is handled by the destination device.</term>
	/// </item>
	/// </list>
	/// <para>
	/// The printer driver must provide a user interface for setting this member. Most printer drivers support only the
	/// DMICMMETHOD_SYSTEM or DMICMMETHOD_NONE value. Drivers for PostScript printers support all values.
	/// </para>
	/// </summary>
	public DMICMMETHOD dmICMMethod;

	/// <summary>
	/// <para>
	/// Specifies which color matching method, or intent, should be used by default. This member is primarily for non-ICM
	/// applications. ICM applications can establish intents by using the ICM functions. This member can be one of the following
	/// predefined values, or a driver defined value greater than or equal to the value of DMICM_USER.
	/// </para>
	/// <list type="table">
	/// <listheader>
	/// <term>Value</term>
	/// <term>Meaning</term>
	/// </listheader>
	/// <item>
	/// <term>DMICM_ABS_COLORIMETRIC</term>
	/// <term>
	/// Color matching should optimize to match the exact color requested without white point mapping. This value is most appropriate
	/// for use with proofing.
	/// </term>
	/// </item>
	/// <item>
	/// <term>DMICM_COLORIMETRIC</term>
	/// <term>
	/// Color matching should optimize to match the exact color requested. This value is most appropriate for use with business logos
	/// or other images when an exact color match is desired.
	/// </term>
	/// </item>
	/// <item>
	/// <term>DMICM_CONTRAST</term>
	/// <term>
	/// Color matching should optimize for color contrast. This value is the most appropriate choice for scanned or photographic
	/// images when dithering is desired.
	/// </term>
	/// </item>
	/// <item>
	/// <term>DMICM_SATURATE</term>
	/// <term>
	/// Color matching should optimize for color saturation. This value is the most appropriate choice for business graphs when
	/// dithering is not desired.
	/// </term>
	/// </item>
	/// </list>
	/// </summary>
	public DMICM dmICMIntent;

	/// <summary>
	/// <para>
	/// Specifies the type of media being printed on. The member can be one of the following predefined values, or a driver-defined
	/// value greater than or equal to the value of DMMEDIA_USER.
	/// </para>
	/// <list type="table">
	/// <listheader>
	/// <term>Value</term>
	/// <term>Meaning</term>
	/// </listheader>
	/// <item>
	/// <term>DMMEDIA_STANDARD</term>
	/// <term>Plain paper.</term>
	/// </item>
	/// <item>
	/// <term>DMMEDIA_GLOSSY</term>
	/// <term>Glossy paper.</term>
	/// </item>
	/// <item>
	/// <term>DMMEDIA_TRANSPARENCY</term>
	/// <term>Transparent film.</term>
	/// </item>
	/// </list>
	/// <para>
	/// To retrieve a list of the available media types for a printer, use the DeviceCapabilities function with the DC_MEDIATYPES flag.
	/// </para>
	/// </summary>
	public DMMEDIA dmMediaType;

	/// <summary>
	/// <para>
	/// Specifies how dithering is to be done. The member can be one of the following predefined values, or a driver-defined value
	/// greater than or equal to the value of DMDITHER_USER.
	/// </para>
	/// <list type="table">
	/// <listheader>
	/// <term>Value</term>
	/// <term>Meaning</term>
	/// </listheader>
	/// <item>
	/// <term>DMDITHER_NONE</term>
	/// <term>No dithering.</term>
	/// </item>
	/// <item>
	/// <term>DMDITHER_COARSE</term>
	/// <term>Dithering with a coarse brush.</term>
	/// </item>
	/// <item>
	/// <term>DMDITHER_FINE</term>
	/// <term>Dithering with a fine brush.</term>
	/// </item>
	/// <item>
	/// <term>DMDITHER_LINEART</term>
	/// <term>
	/// Line art dithering, a special dithering method that produces well defined borders between black, white, and gray scaling. It
	/// is not suitable for images that include continuous graduations in intensity and hue, such as scanned photographs.
	/// </term>
	/// </item>
	/// <item>
	/// <term>DMDITHER_GRAYSCALE</term>
	/// <term>Device does gray scaling.</term>
	/// </item>
	/// </list>
	/// </summary>
	public DMDITHER dmDitherType;

	/// <summary>Not used; must be zero.</summary>
	public uint dmReserved1;

	/// <summary>Not used; must be zero.</summary>
	public uint dmReserved2;

	/// <summary>This member must be zero.</summary>
	public uint dmPanningWidth;

	/// <summary>This member must be zero.</summary>

	public uint dmPanningHeight;

	/// <summary>A default value with dmSize and dmSpecVersion set.</summary>
	public static readonly DEVMODE Default = new() { dmSize = (ushort)Marshal.SizeOf<DEVMODE>(), dmSpecVersion = DM_SPECVERSION };
}