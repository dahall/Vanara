using System;
using System.Collections.Generic;
using System.Globalization;

namespace Vanara.PInvoke;

public static partial class Gdi32
{
	/// <summary>Mask for GetFontLanguageInfo results.</summary>
	public const ushort FLI_MASK = 0x103B;

	/// <summary>Font weight value.</summary>
	public const int FW_BOLD = 700;

	/// <summary>Font weight value.</summary>
	public const int FW_DONTCARE = 0;

	/// <summary>Font weight value.</summary>
	public const int FW_EXTRABOLD = 800;

	/// <summary>Font weight value.</summary>
	public const int FW_EXTRALIGHT = 200;

	/// <summary>Font weight value.</summary>
	public const int FW_HEAVY = 900;

	/// <summary>Font weight value.</summary>
	public const int FW_LIGHT = 300;

	/// <summary>Font weight value.</summary>
	public const int FW_MEDIUM = 500;

	/// <summary>Font weight value.</summary>
	public const int FW_NORMAL = 400;

	/// <summary>Font weight value.</summary>
	public const int FW_SEMIBOLD = 600;

	/// <summary>Font weight value.</summary>
	public const int FW_THIN = 100;

	/// <summary>Error value for some functions.</summary>
	public const uint GCP_ERROR = 0x8000;

	/// <summary>Value for <see cref="GCP_RESULTS"/><c>.lpGlyph</c> field.</summary>
	public const ushort GCPGLYPH_LINKAFTER = 0x4000;

	/// <summary>Value for <see cref="GCP_RESULTS"/><c>.lpGlyph</c> field.</summary>
	public const ushort GCPGLYPH_LINKBEFORE = 0x8000;

	/// <summary>Represents a generic GDI error.</summary>
	public const uint GDI_ERROR = 0xFFFFFFFF;

	/// <summary>
	/// The <c>EnumFontFamExProc</c> function is an application defined callback function used with the <c>EnumFontFamiliesEx</c> function.
	/// It is used to process the fonts. It is called once for each enumerated font. The <c>FONTENUMPROC</c> type defines a pointer to this
	/// callback function. <c>EnumFontFamExProc</c> is a placeholder for the application defined function name.
	/// </summary>
	/// <param name="lpelfe">
	/// A pointer to an <c>LOGFONT</c> structure that contains information about the logical attributes of the font. To obtain additional
	/// information about the font, you can cast the result as an <c>ENUMLOGFONTEX</c> or <c>ENUMLOGFONTEXDV</c> structure.
	/// </param>
	/// <param name="lpntme">
	/// <para>
	/// A pointer to a structure that contains information about the physical attributes of a font. The function uses the
	/// <c>NEWTEXTMETRICEX</c> structure for TrueType fonts; and the <c>TEXTMETRIC</c> structure for other fonts.
	/// </para>
	/// <para>This can be an <c>ENUMTEXTMETRIC</c> structure.</para>
	/// </param>
	/// <param name="FontType">
	/// <para>The type of the font. This parameter can be a combination of these values:</para>
	/// <para><c>DEVICE_FONTTYPE</c></para>
	/// <para><c>RASTER_FONTTYPE</c></para>
	/// <para><c>TRUETYPE_FONTTYPE</c></para>
	/// </param>
	/// <param name="lParam">The application-defined data passed by the <c>EnumFontFamiliesEx</c> function.</param>
	/// <returns>The return value must be a nonzero value to continue enumeration; to stop enumeration, the return value must be zero.</returns>
	/// <remarks>
	/// <para>An application must register this callback function by passing its address to the <c>EnumFontFamiliesEx</c> function.</para>
	/// <para>
	/// When the graphics mode on the device context is set to GM_ADVANCED using the <c>SetGraphicsMode</c> function and the DEVICE_FONTTYPE
	/// flag is passed to the FontType parameter, this function returns a list of type 1 and OpenType fonts on the system. When the graphics
	/// mode is not set to GM_ADVANCED, this function returns a list of type 1, OpenType, and TrueType fonts on the system.
	/// </para>
	/// <para>
	/// Unlike the <c>EnumFontFamProc</c> callback function, <c>EnumFontFamExProc</c> receives extended information about a font. The
	/// <c>ENUMLOGFONTEX</c> structure includes the localized name of the script (character set) and the <c>NEWTEXTMETRICEX</c> structure
	/// includes a font-coverage signature.
	/// </para>
	/// </remarks>
	// https://docs.microsoft.com/en-us/previous-versions/dd162618(v=vs.85) int CALLBACK EnumFontFamExProc( const LOGFONT *lpelfe, const
	// TEXTMETRIC *lpntme, DWORD FontType, LPARAM lParam );
	[UnmanagedFunctionPointer(CallingConvention.Winapi, CharSet = CharSet.Auto)]
	[PInvokeData("Wingdi.h")]
	public delegate int EnumFontFamExProc(in ENUMLOGFONTEXDV lpelfe, in ENUMTEXTMETRIC lpntme, FontType FontType, IntPtr lParam);

	/// <summary>
	/// <para>
	/// The <c>EnumFontFamProc</c> function is an application defined callback function used with the <c>EnumFontFamilies</c> function. It
	/// receives data describing the available fonts. The <c>FONTENUMPROC</c> type defines a pointer to this callback function.
	/// <c>EnumFontFamProc</c> is a placeholder for the application definedfunction name.
	/// </para>
	/// <para>
	/// <c>Note</c> This function is provided only for compatibility with 16-bit versions of Windows. Applications should call the
	/// <c>EnumFontFamiliesEx</c> function.
	/// </para>
	/// </summary>
	/// <param name="lpelf">
	/// <para>[in]</para>
	/// <para>
	/// A pointer to an <c>ENUMLOGFONT</c> structure that contains information about the logical attributes of the font. This structure is
	/// locally defined.
	/// </para>
	/// <para>This can be an <c>ENUMLOGFONTEXDV</c> structure.</para>
	/// </param>
	/// <param name="lpntm">
	/// <para>[in]</para>
	/// <para>
	/// A pointer to a <c>NEWTEXTMETRIC</c> structure that contains information about the physical attributes of the font, if the font is a
	/// TrueType font. If the font is not a TrueType font, this parameter is a pointer to a <c>TEXTMETRIC</c> structure.
	/// </para>
	/// <para>This can be an <c>ENUMTEXTMETRIC</c> structure.</para>
	/// </param>
	/// <param name="FontType">
	/// <para>[in]</para>
	/// <para>The type of the font. This parameter can be a combination of the following values:</para>
	/// <para><c>DEVICE_FONTTYPE</c></para>
	/// <para><c>RASTER_FONTTYPE</c></para>
	/// <para><c>TRUETYPE_FONTTYPE</c></para>
	/// </param>
	/// <param name="lParam">
	/// <para>[in]</para>
	/// <para>A pointer to the application-defined data passed by the <c>EnumFontFamilies</c> function.</para>
	/// </param>
	/// <returns>The return value must be a nonzero value to continue enumeration; to stop enumeration, it must return zero.</returns>
	/// <remarks>
	/// <para>An application must register this callback function by passing its address to the <c>EnumFontFamilies</c> function.</para>
	/// <para>
	/// When the graphics mode on the device context is set to GM_ADVANCED using the <c>SetGraphicsMode</c> function and the DEVICE_FONTTYPE
	/// flag is passed to the FontType parameter, this function returns a list of type 1 and OpenType fonts on the system. When the graphics
	/// mode is not set to GM_ADVANCED, this function returns a list of type 1, OpenType, and TrueType fonts on the system.
	/// </para>
	/// <para>
	/// The AND (&amp;) operator can be used with the RASTER_FONTTYPE, DEVICE_FONTTYPE, and TRUETYPE_FONTTYPE constants to determine the font
	/// type. If the RASTER_FONTTYPE bit is set, the font is a raster font. If the TRUETYPE_FONTTYPE bit is set, the font is a TrueType font.
	/// If neither bit is set, the font is a vector font. DEVICE_FONTTYPE is set when a device (for example, a laser
	/// printer) supports downloading TrueType fonts or when the font is a device-resident font; it is zero if the device is a display
	/// adapter, dot-matrix printer, or other raster device. An application can also use DEVICE_FONTTYPE to distinguish graphics device
	/// interface (GDI)-supplied raster fonts from device-supplied fonts. GDI can simulate bold, italic, underline, and strikeout attributes
	/// for GDI-supplied raster fonts, but not for device-supplied fonts.
	/// </para>
	/// </remarks>
	// https://docs.microsoft.com/en-us/previous-versions/dd162621%28v%3dvs.85%29 int CALLBACK EnumFontFamProc( _In_ ENUMLOGFONT *lpelf, _In_
	// NEWTEXTMETRIC *lpntm, _In_ DWORD FontType, _In_ LPARAM lParam );
	[UnmanagedFunctionPointer(CallingConvention.Winapi)]
	[PInvokeData("Wingdi.h")]
	public delegate int EnumFontFamProc(in ENUMLOGFONT lpelf, in NEWTEXTMETRIC lpntm, FontType FontType, IntPtr lParam);

	/// <summary>
	/// <para>
	/// The <c>EnumFontsProc</c> function is an application definedcallback function that processes font data from the <c>EnumFonts</c>
	/// function. The <c>FONTENUMPROC</c> type defines a pointer to this callback function. <c>EnumFontsProc</c> is a placeholder for the
	/// application definedfunction name.
	/// </para>
	/// <para>
	/// <c>Note</c> This function is provided only for compatibility with 16-bit versions of Windows. Applications should call the
	/// <c>EnumFontFamiliesEx</c> function.
	/// </para>
	/// </summary>
	/// <param name="lplf">
	/// <para>[in]</para>
	/// <para>A pointer to a <c>LOGFONT</c> structure that contains information about the logical attributes of the font.</para>
	/// <para>This can be an <c>ENUMLOGFONTEXDV</c> structure.</para>
	/// </param>
	/// <param name="lptm">
	/// <para>[in]</para>
	/// <para>A pointer to a <c>TEXTMETRIC</c> structure that contains information about the physical attributes of the font.</para>
	/// <para>This can be an <c>ENUMTEXTMETRIC</c> structure.</para>
	/// </param>
	/// <param name="dwType">
	/// <para>[in]</para>
	/// <para>The type of the font. This parameter can be a combination of the following values:</para>
	/// <para><c>DEVICE_FONTTYPE</c></para>
	/// <para><c>RASTER_FONTTYPE</c></para>
	/// <para><c>TRUETYPE_FONTTYPE</c></para>
	/// </param>
	/// <param name="lpData">
	/// <para>[in]</para>
	/// <para>A pointer to the application-defined data passed by <c>EnumFonts</c>.</para>
	/// </param>
	/// <returns>The return value must be a nonzero value to continue enumeration; to stop enumeration, it must be zero.</returns>
	/// <remarks>
	/// <para>
	/// The AND (&amp;) operator can be used with the RASTER_FONTTYPE and DEVICE_FONTTYPE constants to determine the font type. The
	/// RASTER_FONTTYPE bit of the FontType parameter specifies whether the font is a raster or vector font. If the bit is one, the font is a
	/// raster font; if zero, it is a vector font. The DEVICE_FONTTYPE bit of FontType specifies whether the font is a device-based or
	/// graphics device interface (GDI)-based font. If the bit is one, the font is a device-based font; if zero, it is a GDI-based font.
	/// </para>
	/// <para>
	/// If the device is capable of text transformations (scaling, italicizing, and so on) only the base font is enumerated. The user must
	/// inquire into the device's text-transformation abilities to determine which additional fonts are available directly from the device.
	/// </para>
	/// <para>An application must register the <c>EnumFontsProc</c> function by passing its address to the <c>EnumFonts</c> function.</para>
	/// </remarks>
	// https://docs.microsoft.com/en-us/previous-versions/dd162623(v=vs.85) int CALLBACK EnumFontsProc( _In_ const LOGFONT *lplf, _In_ const
	// TEXTMETRIC *lptm, _In_ DWORD dwType, _In_ LPARAM lpData );
	[UnmanagedFunctionPointer(CallingConvention.Winapi)]
	[PInvokeData("Wingdi.h")]
	public delegate int EnumFontsProc(in LOGFONT lplf, in TEXTMETRIC lptm, FontType dwType, IntPtr lpData);

	/// <summary>The character set (4-bytes).</summary>
	[PInvokeData("Wingdi.h", MSDNShortId = "dd145037")]
	public enum CharacterSetUint : uint
	{
		/// <summary>Specifies the English character set.</summary>
		ANSI_CHARSET = 0,

		/// <summary>
		/// Specifies a character set based on the current system locale; for example, when the system locale is United States English, the
		/// default character set is ANSI_CHARSET.
		/// </summary>
		DEFAULT_CHARSET = 1,

		/// <summary>Specifies a character set of symbols.</summary>
		SYMBOL_CHARSET = 2,

		/// <summary>Specifies the Japanese character set.</summary>
		SHIFTJIS_CHARSET = 128,

		/// <summary>Specifies the Hangul Korean character set.</summary>
		HANGEUL_CHARSET = 129,

		/// <summary>Also spelled "Hangeul". Specifies the Hangul Korean character set.</summary>
		HANGUL_CHARSET = 129,

		/// <summary>Specifies the "simplified" Chinese character set for People's Republic of China.</summary>
		GB2312_CHARSET = 134,

		/// <summary>
		/// Specifies the "traditional" Chinese character set, used mostly in Taiwan and in the Hong Kong and Macao Special Administrative Regions.
		/// </summary>
		CHINESEBIG5_CHARSET = 136,

		/// <summary>Specifies a mapping to one of the OEM code pages, according to the current system locale setting.</summary>
		OEM_CHARSET = 255,

		/// <summary>Also spelled "Johap". Specifies the Johab Korean character set.</summary>
		JOHAB_CHARSET = 130,

		/// <summary>Specifies the Hebrew character set.</summary>
		HEBREW_CHARSET = 177,

		/// <summary>Specifies the Arabic character set.</summary>
		ARABIC_CHARSET = 178,

		/// <summary>Specifies the Greek character set.</summary>
		GREEK_CHARSET = 161,

		/// <summary>Specifies the Turkish character set.</summary>
		TURKISH_CHARSET = 162,

		/// <summary>Specifies the Vietnamese character set.</summary>
		VIETNAMESE_CHARSET = 163,

		/// <summary>Specifies the Thai character set.</summary>
		THAI_CHARSET = 222,

		/// <summary>Specifies a Eastern European character set.</summary>
		EASTEUROPE_CHARSET = 238,

		/// <summary>Specifies the Russian Cyrillic character set.</summary>
		RUSSIAN_CHARSET = 204,

		/// <summary>Specifies the Apple Macintosh character set.</summary>
		MAC_CHARSET = 77,

		/// <summary>Specifies the Baltic (Northeastern European) character set.</summary>
		BALTIC_CHARSET = 186
	}

	/// <summary>The clipping precision defines how to clip characters that are partially outside the clipping region.</summary>
	[PInvokeData("Wingdi.h", MSDNShortId = "dd145037")]
	public enum ClippingPrecision : byte
	{
		/// <summary>Not used.</summary>
		CLIP_CHARACTER_PRECIS = 1,

		/// <summary>Specifies default clipping behavior.</summary>
		CLIP_DEFAULT_PRECIS = 0,

		/// <summary>
		/// Windows XP SP1: Turns off font association for the font. Note that this flag is not guaranteed to have any effect on any platform
		/// after Windows Server 2003.
		/// </summary>
		CLIP_DFA_DISABLE = 4 << 4,

		/// <summary>
		/// Turns off font association for the font. This is identical to CLIP_DFA_DISABLE, but it can have problems in some situations; the
		/// recommended flag to use is CLIP_DFA_DISABLE.
		/// </summary>
		CLIP_DFA_OVERRIDE = 64,

		/// <summary>You must specify this flag to use an embedded read-only font.</summary>
		CLIP_EMBEDDED = 8 << 4,

		/// <summary>
		/// When this value is used, the rotation for all fonts depends on whether the orientation of the coordinate system is left-handed or
		/// right-handed. If not used, device fonts always rotate counterclockwise, but the rotation of other fonts is dependent on the
		/// orientation of the coordinate system.
		/// </summary>
		CLIP_LH_ANGLES = 1 << 4,

		/// <summary>Not used.</summary>
		CLIP_MASK = 0xf,

		/// <summary>
		/// Not used by the font mapper, but is returned when raster, vector, or TrueType fonts are enumerated. For compatibility, this value
		/// is always returned when enumerating fonts.
		/// </summary>
		CLIP_STROKE_PRECIS = 2,

		/// <summary>Not used.</summary>
		CLIP_TT_ALWAYS = 2 << 4,
	}

	/// <summary>Options for <see cref="ExtTextOut"/>.</summary>
	[PInvokeData("wingdi.h", MSDNShortId = "74f8fcb8-8ad4-47f2-a330-fa56713bdb37")]
	[Flags]
	public enum ETO
	{
		/// <summary>The current background color should be used to fill the rectangle.</summary>
		ETO_OPAQUE = 0x0002,

		/// <summary>The text will be clipped to the rectangle.</summary>
		ETO_CLIPPED = 0x0004,

		/// <summary>
		/// The lpString array refers to an array returned from GetCharacterPlacement and should be parsed directly by GDI as no further
		/// language-specific processing is required. Glyph indexing only applies to TrueType fonts, but the flag can be used for bitmap and
		/// vector fonts to indicate that no further language processing is necessary and GDI should process the string directly. Note that
		/// all glyph indexes are 16-bit values even though the string is assumed to be an array of 8-bit values for raster fonts. For
		/// ExtTextOutW, the glyph indexes are saved to a metafile. However, to display the correct characters the metafile must be played
		/// back using the same font. For ExtTextOutA, the glyph indexes are not saved.
		/// </summary>
		ETO_GLYPH_INDEX = 0x0010,

		/// <summary>
		/// Middle East language edition of Windows: If this value is specified and a Hebrew or Arabic font is selected into the device
		/// context, the string is output using right-to-left reading order. If this value is not specified, the string is output in
		/// left-to-right order. The same effect can be achieved by setting the TA_RTLREADING value in SetTextAlign. This value is preserved
		/// for backward compatibility.
		/// </summary>
		ETO_RTLREADING = 0x0080,

		/// <summary>To display numbers, use digits appropriate to the locale.</summary>
		ETO_NUMERICSLOCAL = 0x0400,

		/// <summary>To display numbers, use European digits.</summary>
		ETO_NUMERICSLATIN = 0x0800,

		/// <summary>
		/// Reserved for system use. If an application sets this flag, it loses international scripting support and in some cases it may
		/// display no text at all.
		/// </summary>
		ETO_IGNORELANGUAGE = 0x1000,

		/// <summary>
		/// When this is set, the array pointed to by lpDx contains pairs of values. The first value of each pair is, as usual, the distance
		/// between origins of adjacent character cells, but the second value is the displacement along the vertical direction of the font.
		/// </summary>
		ETO_PDY = 0x2000,

		/// <summary>Reserved and SHOULD NOT be used.</summary>
		ETO_REVERSE_INDEX_MAP = 0x10000,
	}

	/// <summary>Font type.</summary>
	[PInvokeData("Wingdi.h")]
	public enum FontType
	{
		/// <summary/>
		DEVICE_FONTTYPE,

		/// <summary/>
		RASTER_FONTTYPE,

		/// <summary/>
		TRUETYPE_FONTTYPE
	}

	/// <summary>Flags for <see cref="AddFontResourceEx"/>.</summary>
	[PInvokeData("wingdi.h", MSDNShortId = "eaf8ebf0-1b06-4a09-a842-83540245a117")]
	[Flags]
	public enum FR
	{
		/// <summary>
		/// Specifies that only the process that called the AddFontResourceEx function can use this font. When the font name matches a public
		/// font, the private font will be chosen. When the process terminates, the system will remove all fonts installed by the process
		/// with the AddFontResourceEx function.
		/// </summary>
		FR_PRIVATE = 0x10,

		/// <summary>Specifies that no process, including the process that called the AddFontResourceEx function, can enumerate this font.</summary>
		FR_NOT_ENUM = 0x20,
	}

	/// <summary>Flags for <see cref="GetCharacterPlacement"/> and <see cref="GetFontLanguageInfo"/>.</summary>
	[PInvokeData("wingdi.h", MSDNShortId = "80d3f4b3-503b-4abb-826c-e5c09972ba2f")]
	[Flags]
	public enum GCP : uint
	{
		/// <summary>
		/// The font contains extra glyphs not normally accessible using the code page. Use GetCharacterPlacement to access the glyphs. This
		/// value is for information only and is not intended to be passed to GetCharacterPlacement.
		/// </summary>
		FLI_GLYPHS = 0x00040000,

		/// <summary>
		/// Specifies that the lpClass array contains preset classifications for characters. The classifications may be the same as on
		/// output. If the particular classification for a character is not known, the corresponding location in the array must be set to
		/// zero. for more information about the classifications, see GCP_RESULTS. This is useful only if GetFontLanguageInfo returned the
		/// GCP_REORDER flag.
		/// </summary>
		GCP_CLASSIN = 0x00080000,

		/// <summary>The character set is DBCS.</summary>
		GCP_DBCS = 0x0001,

		/// <summary>
		/// Determines how diacritics in the string are handled. If this value is not set, diacritics are treated as zero-width characters.
		/// For example, a Hebrew string may contain diacritics, but you may not want to display them. Use GetFontLanguageInfo to determine
		/// whether a font supports diacritics. If it does, you can use or not use the GCP_DIACRITIC flag in the call to
		/// GetCharacterPlacement, depending on the needs of your application.
		/// </summary>
		GCP_DIACRITIC = 0x0100,

		/// <summary>
		/// For languages that need reordering or different glyph shapes depending on the positions of the characters within a word,
		/// nondisplayable characters often appear in the code page. For example, in the Hebrew code page, there are Left-To-Right and
		/// Right-To-Left markers, to help determine the final positioning of characters within the output strings. Normally these are not
		/// displayed and are removed from the lpGlyphs and lpDx arrays. You can use the GCP_DISPLAYZWG flag to display these characters.
		/// </summary>
		GCP_DISPLAYZWG = 0x00400000,

		/// <summary>
		/// Specifies that some or all characters in the string are to be displayed using shapes other than the standard shapes defined in
		/// the currently selected font for the current code page. Some languages, such as Arabic, cannot support glyph creation unless this
		/// value is specified. As a general rule, if GetFontLanguageInfo returns this value for a string, this value must be used with GetCharacterPlacement.
		/// </summary>
		GCP_GLYPHSHAPE = 0x0010,

		/// <summary>
		/// Adjusts the extents in the lpDx array so that the string length is the same as nMaxExtent. GCP_JUSTIFY may only be used in
		/// conjunction with GCP_MAXEXTENT.
		/// </summary>
		GCP_JUSTIFY = 0x00010000,

		/// <summary/>
		GCP_JUSTIFYIN = 0x00200000,

		/// <summary>
		/// Use Kashidas as well as, or instead of, adjusted extents to modify the length of the string so that it is equal to the value
		/// specified by nMaxExtent. In the lpDx array, a Kashida is indicated by a negative justification index. GCP_KASHIDA may be used
		/// only in conjunction with GCP_JUSTIFY and only if the font (and language) support Kashidas. Use GetFontLanguageInfo to determine
		/// whether the current font supports Kashidas. Using Kashidas to justify the string can result in the number of glyphs required
		/// being greater than the number of characters in the input string. Because of this, when Kashidas are used, the application cannot
		/// assume that setting the arrays to be the size of the input string will be sufficient. (The maximum possible will be approximately
		/// dxPageWidth/dxAveCharWidth, where dxPageWidth is the width of the document and dxAveCharWidth is the average character width as
		/// returned from a GetTextMetrics call). Note that just because GetFontLanguageInfo returns the GCP_KASHIDA flag does not mean that
		/// it has to be used in the call to GetCharacterPlacement, just that the option is available.
		/// </summary>
		GCP_KASHIDA = 0x0400,

		/// <summary>
		/// Use ligations wherever characters ligate. A ligation occurs where one glyph is used for two or more characters. For example, the
		/// letters a and e can ligate to ?. For this to be used, however, both the language support and the font must support the required
		/// glyphs (the example will not be processed by default in English). Use GetFontLanguageInfo to determine whether the current font
		/// supports ligation. If it does and a specific maximum is required for the number of characters that will ligate, set the number in
		/// the first element of the lpGlyphs array. If normal ligation is required, set this value to zero. If GCP_LIGATE is not specified,
		/// no ligation will take place. See GCP_RESULTS for more information. If the GCP_REORDER value is usually required for the character
		/// set but is not specified, the output will be meaningless unless the string being passed in is already in visual ordering (that
		/// is, the result that gets put into lpGcpResults-&gt;lpOutString in one call to GetCharacterPlacement is the input string of a
		/// second call). Note that just because GetFontLanguageInfo returns the GCP_LIGATE flag does not mean that it has to be used in the
		/// call to GetCharacterPlacement, just that the option is available.
		/// </summary>
		GCP_LIGATE = 0x0020,

		/// <summary>
		/// Compute extents of the string only as long as the resulting extent, in logical units, does not exceed the values specified by the
		/// nMaxExtent parameter.
		/// </summary>
		GCP_MAXEXTENT = 0x00100000,

		/// <summary>
		/// Certain languages only. Override the normal handling of neutrals and treat them as strong characters that match the strings
		/// reading order. Useful only with the GCP_REORDER flag.
		/// </summary>
		GCP_NEUTRALOVERRIDE = 0x02000000,

		/// <summary>
		/// Certain languages only. Override the normal handling of numerics and treat them as strong characters that match the strings
		/// reading order. Useful only with the GCP_REORDER flag.
		/// </summary>
		GCP_NUMERICOVERRIDE = 0x01000000,

		/// <summary>
		/// Arabic/Thai only. Use standard Latin glyphs for numbers and override the system default. To determine if this option is available
		/// in the language of the font, use GetStringTypeEx to see if the language supports more than one number format.
		/// </summary>
		GCP_NUMERICSLATIN = 0x04000000,

		/// <summary>
		/// Arabic/Thai only. Use local glyphs for numeric characters and override the system default. To determine if this option is
		/// available in the language of the font, use GetStringTypeEx to see if the language supports more than one number format.
		/// </summary>
		GCP_NUMERICSLOCAL = 0x08000000,

		/// <summary>
		/// Reorder the string. Use for languages that are not SBCS and left-to-right reading order. If this value is not specified, the
		/// string is assumed to be in display order already. If this flag is set for Semitic languages and the lpClass array is used, the
		/// first two elements of the array are used to specify the reading order beyond the bounds of the string. GCP_CLASS_PREBOUNDRTL and
		/// GCP_CLASS_PREBOUNDLTR can be used to set the order. If no preset order is required, set the values to zero. These values can be
		/// combined with other values if the GCPCLASSIN flag is set. If the GCP_REORDER value is not specified, the lpString parameter is
		/// taken to be visual ordered for languages where this is used, and the lpOutString and lpOrder fields are ignored. Use
		/// GetFontLanguageInfo to determine whether the current font supports reordering.
		/// </summary>
		GCP_REORDER = 0x0002,

		/// <summary>
		/// Semitic languages only. Specifies that swappable characters are not reset. For example, in a right-to-left string, the '(' and
		/// ')' are not reversed.
		/// </summary>
		GCP_SYMSWAPOFF = 0x00800000,

		/// <summary>
		/// Use kerning pairs in the font (if any) when creating the widths arrays. Use GetFontLanguageInfo to determine whether the current
		/// font supports kerning pairs. Note that just because GetFontLanguageInfo returns the GCP_USEKERNING flag does not mean that it has
		/// to be used in the call to GetCharacterPlacement, just that the option is available. Most TrueType fonts have a kerning table, but
		/// you do not have to use it.
		/// </summary>
		GCP_USEKERNING = 0x0008,
	}

	/// <summary>Values for <see cref="GCP_RESULTS"/><c>.lpClass</c> field.</summary>
	[PInvokeData("wingdi.h", MSDNShortId = "7692637e-963a-4e0a-8a04-e05a6d01c417")]
	[Flags]
	public enum GCPCLASS : byte
	{
		/// <summary>Character from a Latin or other single-byte character set for a left-to-right language.</summary>
		GCPCLASS_LATIN = 1,

		/// <summary>Hebrew character.</summary>
		GCPCLASS_HEBREW = 2,

		/// <summary>Arabic character.</summary>
		GCPCLASS_ARABIC = 2,

		/// <summary>Input only. Character has no specific classification.</summary>
		GCPCLASS_NEUTRAL = 3,

		/// <summary>Digit from the character set associated with the current font.</summary>
		GCPCLASS_LOCALNUMBER = 4,

		/// <summary>Digit from a Latin or other single-byte character set for a left-to-right language.</summary>
		GCPCLASS_LATINNUMBER = 5,

		/// <summary>Input only. Character used to terminate Latin digits, such as a plus or minus sign.</summary>
		GCPCLASS_LATINNUMERICTERMINATOR = 6,

		/// <summary>Input only. Character used to separate Latin digits, such as a comma or decimal point.</summary>
		GCPCLASS_LATINNUMERICSEPARATOR = 7,

		/// <summary>Input only. Character used to separate digits, such as a comma or decimal point.</summary>
		GCPCLASS_NUMERICSEPARATOR = 8,

		/// <summary>Set lpClass[0] to GCPCLASS_PREBOUNDLTR to bind the string to left-to-right reading order before the string.</summary>
		GCPCLASS_PREBOUNDLTR = 0x80,

		/// <summary>Set lpClass[0] to GCPCLASS_PREBOUNDRTL to bind the string to right-to-left reading order before the string.</summary>
		GCPCLASS_PREBOUNDRTL = 0x40,

		/// <summary>Set lpClass[0] to GCPCLASS_POSTBOUNDLTR to bind the string to left-to-right reading order after the string.</summary>
		GCPCLASS_POSTBOUNDLTR = 0x20,

		/// <summary>Set lpClass[0] to GCPCLASS_POSTBOUNDRTL to bind the string to right-to-left reading order after the string.</summary>
		GCPCLASS_POSTBOUNDRTL = 0x10,
	}

	/// <summary>Specifies how glyphs should be handled if they are not supported.</summary>
	[PInvokeData("wingdi.h", MSDNShortId = "7abfee7a-dd5d-4f33-96f1-b38364ba5afd")]
	[Flags]
	public enum GGI
	{
		/// <summary>Marks unsupported glyphs with the hexadecimal value 0xffff.</summary>
		GGI_MARK_NONEXISTING_GLYPHS = 1
	}

	/// <summary>The format of the data that <c>GetGlyphOutline</c> retrieves.</summary>
	[PInvokeData("wingdi.h", MSDNShortId = "08f06007-5b21-44ab-b234-21a58c94ed4e")]
	public enum GGO
	{
		/// <summary>
		/// The function only retrieves the GLYPHMETRICS structure specified by lpgm. The lpvBuffer is ignored. This value affects the
		/// meaning of the function's return value upon failure; see the Return Values section.
		/// </summary>
		GGO_METRICS = 0,

		/// <summary>The function retrieves the glyph bitmap. For information about memory allocation, see the following Remarks section.</summary>
		GGO_BITMAP = 1,

		/// <summary>The function retrieves the curve data points in the rasterizer's native format and uses the font's design units.</summary>
		GGO_NATIVE = 2,

		/// <summary>The function retrieves the curve data as a cubic Bézier spline (not in quadratic spline format).</summary>
		GGO_BEZIER = 3,

		/// <summary>The function retrieves a glyph bitmap that contains five levels of gray.</summary>
		GGO_GRAY2_BITMAP = 4,

		/// <summary>The function retrieves a glyph bitmap that contains 17 levels of gray.</summary>
		GGO_GRAY4_BITMAP = 5,

		/// <summary>The function retrieves a glyph bitmap that contains 65 levels of gray.</summary>
		GGO_GRAY8_BITMAP = 6,

		/// <summary>
		/// Indicates that the uChar parameter is a TrueType Glyph Index rather than a character code. See the ExtTextOut function for
		/// additional remarks on Glyph Indexing.
		/// </summary>
		GGO_GLYPH_INDEX = 0x0080,

		/// <summary>The function only returns unhinted outlines. This flag only works in conjunction with GGO_BEZIER and GGO_NATIVE.</summary>
		GGO_UNHINTED = 0x0100,
	}

	/// <summary>Flags describing the maximum size of the glyph indices.</summary>
	public enum GSISize : uint
	{
		/// <summary>Treat glyph indices as 16-bit wide values.</summary>
		GS_16BIT_INDICES = 0,

		/// <summary>Treat glyph indices as 8-bit wide values.</summary>
		GS_8BIT_INDICES = 1
	}

	/// <summary>
	/// The output precision. The output precision defines how closely the output must match the requested font's height, width, character
	/// orientation, escapement, pitch, and font type.
	/// </summary>
	[PInvokeData("Wingdi.h", MSDNShortId = "dd145037")]
	public enum OutputPrecision : byte
	{
		/// <summary>Not used.</summary>
		OUT_CHARACTER_PRECIS = 2,

		/// <summary>Specifies the default font mapper behavior.</summary>
		OUT_DEFAULT_PRECIS = 0,

		/// <summary>Instructs the font mapper to choose a Device font when the system contains multiple fonts with the same name.</summary>
		OUT_DEVICE_PRECIS = 5,

		/// <summary>This value instructs the font mapper to choose from TrueType and other outline-based fonts.</summary>
		OUT_OUTLINE_PRECIS = 8,

		/// <summary>
		/// Instructs the font mapper to choose from only PostScript fonts. If there are no PostScript fonts installed in the system, the
		/// font mapper returns to default behavior.
		/// </summary>
		OUT_PS_ONLY_PRECIS = 10,

		/// <summary>Instructs the font mapper to choose a raster font when the system contains multiple fonts with the same name.</summary>
		OUT_RASTER_PRECIS = 6,

		/// <summary>A value that specifies a preference for TrueType and other outline fonts.</summary>
		OUT_SCREEN_OUTLINE_PRECIS = 9,

		/// <summary>This value is not used by the font mapper, but it is returned when raster fonts are enumerated.</summary>
		OUT_STRING_PRECIS = 1,

		/// <summary>
		/// This value is not used by the font mapper, but it is returned when TrueType, other outline-based fonts, and vector fonts are enumerated.
		/// </summary>
		OUT_STROKE_PRECIS = 3,

		/// <summary>
		/// Instructs the font mapper to choose from only TrueType fonts. If there are no TrueType fonts installed in the system, the font
		/// mapper returns to default behavior.
		/// </summary>
		OUT_TT_ONLY_PRECIS = 7,

		/// <summary>Instructs the font mapper to choose a TrueType font when the system contains multiple fonts with the same name.</summary>
		OUT_TT_PRECIS = 4,
	}

	/// <summary>
	/// The output quality defines how carefully the graphics device interface (GDI) must attempt to match the logical-font attributes to
	/// those of an actual physical font.
	/// </summary>
	[PInvokeData("Wingdi.h", MSDNShortId = "dd145037")]
	public enum OutputQuality : byte
	{
		/// <summary>Appearance of the font does not matter.</summary>
		DEFAULT_QUALITY = 0,

		/// <summary>
		/// Appearance of the font is less important than when PROOF_QUALITY is used. For GDI raster fonts, scaling is enabled, which means
		/// that more font sizes are available, but the quality may be lower. Bold, italic, underline, and strikeout fonts are synthesized if necessary.
		/// </summary>
		DRAFT_QUALITY = 1,

		/// <summary>
		/// Character quality of the font is more important than exact matching of the logical-font attributes. For GDI raster fonts, scaling
		/// is disabled and the font closest in size is chosen. Although the chosen font size may not be mapped exactly when PROOF_QUALITY is
		/// used, the quality of the font is high and there is no distortion of appearance. Bold, italic, underline, and strikeout fonts are
		/// synthesized if necessary.
		/// </summary>
		PROOF_QUALITY = 2,

		/// <summary>Font is never antialiased.</summary>
		NONANTIALIASED_QUALITY = 3,

		/// <summary>Font is always antialiased if the font supports it and the size of the font is not too small or too large.</summary>
		ANTIALIASED_QUALITY = 4,

		/// <summary>
		/// If set, text is rendered (when possible) using ClearType antialiasing method. The font quality is given less importance than
		/// maintaining the text size.
		/// </summary>
		CLEARTYPE_QUALITY = 5,

		/// <summary>
		/// If set, text is rendered (when possible) using ClearType antialiasing method. The font quality is given more importance than
		/// maintaining the text size.
		/// </summary>
		CLEARTYPE_NATURAL_QUALITY = 6
	}

	/// <summary>PANOSE font-classification values for a TrueType font.</summary>
	[PInvokeData("wingdi.h", MSDNShortId = "18aa4a36-8e47-4e35-973f-376d412ed923")]
	public enum PAN_ARMS : byte
	{
		/// <summary>Any</summary>
		PAN_ANY = 0,

		/// <summary>No Fit</summary>
		PAN_NO_FIT = 1,

		/// <summary>Straight Arms/Horizontal</summary>
		PAN_STRAIGHT_ARMS_HORZ = 2,

		/// <summary>Straight Arms/Wedge</summary>
		PAN_STRAIGHT_ARMS_WEDGE = 3,

		/// <summary>Straight Arms/Vertical</summary>
		PAN_STRAIGHT_ARMS_VERT = 4,

		/// <summary>Straight Arms/Single-Serif</summary>
		PAN_STRAIGHT_ARMS_SINGLE_SERIF = 5,

		/// <summary>Straight Arms/Double-Serif</summary>
		PAN_STRAIGHT_ARMS_DOUBLE_SERIF = 6,

		/// <summary>Non-Straight Arms/Horizontal</summary>
		PAN_BENT_ARMS_HORZ = 7,

		/// <summary>Non-Straight Arms/Wedge</summary>
		PAN_BENT_ARMS_WEDGE = 8,

		/// <summary>Non-Straight Arms/Vertical</summary>
		PAN_BENT_ARMS_VERT = 9,

		/// <summary>Non-Straight Arms/Single-Serif</summary>
		PAN_BENT_ARMS_SINGLE_SERIF = 10,

		/// <summary>Non-Straight Arms/Double-Serif</summary>
		PAN_BENT_ARMS_DOUBLE_SERIF = 11,
	}

	/// <summary>PANOSE font-classification values for a TrueType font.</summary>
	[PInvokeData("wingdi.h", MSDNShortId = "18aa4a36-8e47-4e35-973f-376d412ed923")]
	public enum PAN_CONTRAST : byte
	{
		/// <summary>Any</summary>
		PAN_ANY = 0,

		/// <summary>No Fit</summary>
		PAN_NO_FIT = 1,

		/// <summary>None</summary>
		PAN_CONTRAST_NONE = 2,

		/// <summary>Very Low</summary>
		PAN_CONTRAST_VERY_LOW = 3,

		/// <summary>Low</summary>
		PAN_CONTRAST_LOW = 4,

		/// <summary>Medium Low</summary>
		PAN_CONTRAST_MEDIUM_LOW = 5,

		/// <summary>Medium</summary>
		PAN_CONTRAST_MEDIUM = 6,

		/// <summary>Mediim High</summary>
		PAN_CONTRAST_MEDIUM_HIGH = 7,

		/// <summary>High</summary>
		PAN_CONTRAST_HIGH = 8,

		/// <summary>Very High</summary>
		PAN_CONTRAST_VERY_HIGH = 9,
	}

	/// <summary>PANOSE font-classification values for a TrueType font.</summary>
	[PInvokeData("wingdi.h", MSDNShortId = "18aa4a36-8e47-4e35-973f-376d412ed923")]
	public enum PAN_FAMILY : byte
	{
		/// <summary>Any</summary>
		PAN_ANY = 0,

		/// <summary>No Fit</summary>
		PAN_NO_FIT = 1,

		/// <summary>Text and Display</summary>
		PAN_FAMILY_TEXT_DISPLAY = 2,

		/// <summary>Script</summary>
		PAN_FAMILY_SCRIPT = 3,

		/// <summary>Decorative</summary>
		PAN_FAMILY_DECORATIVE = 4,

		/// <summary>Pictorial</summary>
		PAN_FAMILY_PICTORIAL = 5,
	}

	/// <summary>PANOSE font-classification values for a TrueType font.</summary>
	[PInvokeData("wingdi.h", MSDNShortId = "18aa4a36-8e47-4e35-973f-376d412ed923")]
	public enum PAN_LETT : byte
	{
		/// <summary>Any</summary>
		PAN_ANY = 0,

		/// <summary>No Fit</summary>
		PAN_NO_FIT = 1,

		/// <summary>Normal/Contact</summary>
		PAN_LETT_NORMAL_CONTACT = 2,

		/// <summary>Normal/Weighted</summary>
		PAN_LETT_NORMAL_WEIGHTED = 3,

		/// <summary>Normal/Boxed</summary>
		PAN_LETT_NORMAL_BOXED = 4,

		/// <summary>Normal/Flattened</summary>
		PAN_LETT_NORMAL_FLATTENED = 5,

		/// <summary>Normal/Rounded</summary>
		PAN_LETT_NORMAL_ROUNDED = 6,

		/// <summary>Normal/Off Center</summary>
		PAN_LETT_NORMAL_OFF_CENTER = 7,

		/// <summary>Normal/Square</summary>
		PAN_LETT_NORMAL_SQUARE = 8,

		/// <summary>Oblique/Contact</summary>
		PAN_LETT_OBLIQUE_CONTACT = 9,

		/// <summary>Oblique/Weighted</summary>
		PAN_LETT_OBLIQUE_WEIGHTED = 10,

		/// <summary>Oblique/Boxed</summary>
		PAN_LETT_OBLIQUE_BOXED = 11,

		/// <summary>Oblique/Flattened</summary>
		PAN_LETT_OBLIQUE_FLATTENED = 12,

		/// <summary>Oblique/Rounded</summary>
		PAN_LETT_OBLIQUE_ROUNDED = 13,

		/// <summary>Oblique/Off Center</summary>
		PAN_LETT_OBLIQUE_OFF_CENTER = 14,

		/// <summary>Oblique/Square</summary>
		PAN_LETT_OBLIQUE_SQUARE = 15,
	}

	/// <summary>PANOSE font-classification values for a TrueType font.</summary>
	[PInvokeData("wingdi.h", MSDNShortId = "18aa4a36-8e47-4e35-973f-376d412ed923")]
	public enum PAN_MIDLINE : byte
	{
		/// <summary>Any</summary>
		PAN_ANY = 0,

		/// <summary>No Fit</summary>
		PAN_NO_FIT = 1,

		/// <summary>Standard/Trimmed</summary>
		PAN_MIDLINE_STANDARD_TRIMMED = 2,

		/// <summary>Standard/Pointed</summary>
		PAN_MIDLINE_STANDARD_POINTED = 3,

		/// <summary>Standard/Serifed</summary>
		PAN_MIDLINE_STANDARD_SERIFED = 4,

		/// <summary>High/Trimmed</summary>
		PAN_MIDLINE_HIGH_TRIMMED = 5,

		/// <summary>High/Pointed</summary>
		PAN_MIDLINE_HIGH_POINTED = 6,

		/// <summary>High/Serifed</summary>
		PAN_MIDLINE_HIGH_SERIFED = 7,

		/// <summary>Constant/Trimmed</summary>
		PAN_MIDLINE_CONSTANT_TRIMMED = 8,

		/// <summary>Constant/Pointed</summary>
		PAN_MIDLINE_CONSTANT_POINTED = 9,

		/// <summary>Constant/Serifed</summary>
		PAN_MIDLINE_CONSTANT_SERIFED = 10,

		/// <summary>Low/Trimmed</summary>
		PAN_MIDLINE_LOW_TRIMMED = 11,

		/// <summary>Low/Pointed</summary>
		PAN_MIDLINE_LOW_POINTED = 12,

		/// <summary>Low/Serifed</summary>
		PAN_MIDLINE_LOW_SERIFED = 13,
	}

	/// <summary>PANOSE font-classification values for a TrueType font.</summary>
	[PInvokeData("wingdi.h", MSDNShortId = "18aa4a36-8e47-4e35-973f-376d412ed923")]
	public enum PAN_PROP : byte
	{
		/// <summary>Any</summary>
		PAN_ANY = 0,

		/// <summary>No Fit</summary>
		PAN_NO_FIT = 1,

		/// <summary>Old Style</summary>
		PAN_PROP_OLD_STYLE = 2,

		/// <summary>Modern</summary>
		PAN_PROP_MODERN = 3,

		/// <summary>Even Width</summary>
		PAN_PROP_EVEN_WIDTH = 4,

		/// <summary>Expanded</summary>
		PAN_PROP_EXPANDED = 5,

		/// <summary>Condensed</summary>
		PAN_PROP_CONDENSED = 6,

		/// <summary>Very Expanded</summary>
		PAN_PROP_VERY_EXPANDED = 7,

		/// <summary>Very Condensed</summary>
		PAN_PROP_VERY_CONDENSED = 8,

		/// <summary>Monospaced</summary>
		PAN_PROP_MONOSPACED = 9,
	}

	/// <summary>PANOSE font-classification values for a TrueType font.</summary>
	[PInvokeData("wingdi.h", MSDNShortId = "18aa4a36-8e47-4e35-973f-376d412ed923")]
	public enum PAN_SERIF : byte
	{
		/// <summary>Any</summary>
		PAN_ANY = 0,

		/// <summary>No Fit</summary>
		PAN_NO_FIT = 1,

		/// <summary>Cove</summary>
		PAN_SERIF_COVE = 2,

		/// <summary>Obtuse Cove</summary>
		PAN_SERIF_OBTUSE_COVE = 3,

		/// <summary>Square Cove</summary>
		PAN_SERIF_SQUARE_COVE = 4,

		/// <summary>Obtuse Square Cove</summary>
		PAN_SERIF_OBTUSE_SQUARE_COVE = 5,

		/// <summary>Square</summary>
		PAN_SERIF_SQUARE = 6,

		/// <summary>Thin</summary>
		PAN_SERIF_THIN = 7,

		/// <summary>Bone</summary>
		PAN_SERIF_BONE = 8,

		/// <summary>Exaggerated</summary>
		PAN_SERIF_EXAGGERATED = 9,

		/// <summary>Triangle</summary>
		PAN_SERIF_TRIANGLE = 10,

		/// <summary>Normal Sans</summary>
		PAN_SERIF_NORMAL_SANS = 11,

		/// <summary>Obtuse Sans</summary>
		PAN_SERIF_OBTUSE_SANS = 12,

		/// <summary>Prep Sans</summary>
		PAN_SERIF_PERP_SANS = 13,

		/// <summary>Flared</summary>
		PAN_SERIF_FLARED = 14,

		/// <summary>Rounded</summary>
		PAN_SERIF_ROUNDED = 15,
	}

	/// <summary>PANOSE font-classification values for a TrueType font.</summary>
	[PInvokeData("wingdi.h", MSDNShortId = "18aa4a36-8e47-4e35-973f-376d412ed923")]
	public enum PAN_STROKE : byte
	{
		/// <summary>Any</summary>
		PAN_ANY = 0,

		/// <summary>No Fit</summary>
		PAN_NO_FIT = 1,

		/// <summary>Gradual/Diagonal</summary>
		PAN_STROKE_GRADUAL_DIAG = 2,

		/// <summary>Gradual/Transitional</summary>
		PAN_STROKE_GRADUAL_TRAN = 3,

		/// <summary>Gradual/Vertical</summary>
		PAN_STROKE_GRADUAL_VERT = 4,

		/// <summary>Gradual/Horizontal</summary>
		PAN_STROKE_GRADUAL_HORZ = 5,

		/// <summary>Rapid/Vertical</summary>
		PAN_STROKE_RAPID_VERT = 6,

		/// <summary>Rapid/Horizontal</summary>
		PAN_STROKE_RAPID_HORZ = 7,

		/// <summary>Instant/Vertical</summary>
		PAN_STROKE_INSTANT_VERT = 8,
	}

	/// <summary>PANOSE font-classification values for a TrueType font.</summary>
	[PInvokeData("wingdi.h", MSDNShortId = "18aa4a36-8e47-4e35-973f-376d412ed923")]
	public enum PAN_WEIGHT : byte
	{
		/// <summary>Any</summary>
		PAN_ANY = 0,

		/// <summary>No Fit</summary>
		PAN_NO_FIT = 1,

		/// <summary>Very Light</summary>
		PAN_WEIGHT_VERY_LIGHT = 2,

		/// <summary>Light</summary>
		PAN_WEIGHT_LIGHT = 3,

		/// <summary>Thin</summary>
		PAN_WEIGHT_THIN = 4,

		/// <summary>Book</summary>
		PAN_WEIGHT_BOOK = 5,

		/// <summary>Medium</summary>
		PAN_WEIGHT_MEDIUM = 6,

		/// <summary>Demi</summary>
		PAN_WEIGHT_DEMI = 7,

		/// <summary>Bold</summary>
		PAN_WEIGHT_BOLD = 8,

		/// <summary>Heavy</summary>
		PAN_WEIGHT_HEAVY = 9,

		/// <summary>Black</summary>
		PAN_WEIGHT_BLACK = 10,

		/// <summary>Nord</summary>
		PAN_WEIGHT_NORD = 11,
	}

	/// <summary>PANOSE font-classification values for a TrueType font.</summary>
	[PInvokeData("wingdi.h", MSDNShortId = "18aa4a36-8e47-4e35-973f-376d412ed923")]
	public enum PAN_XHEIGHT : byte
	{
		/// <summary>Any</summary>
		PAN_ANY = 0,

		/// <summary>No Fit</summary>
		PAN_NO_FIT = 1,

		/// <summary>Constant/Small</summary>
		PAN_XHEIGHT_CONSTANT_SMALL = 2,

		/// <summary>Constant/Standard</summary>
		PAN_XHEIGHT_CONSTANT_STD = 3,

		/// <summary>Constant/Large</summary>
		PAN_XHEIGHT_CONSTANT_LARGE = 4,

		/// <summary>Ducking/Small</summary>
		PAN_XHEIGHT_DUCKING_SMALL = 5,

		/// <summary>Ducking/Standard</summary>
		PAN_XHEIGHT_DUCKING_STD = 6,

		/// <summary>Ducking/Large</summary>
		PAN_XHEIGHT_DUCKING_LARGE = 7,
	}

	/// <summary>Flags specifying pitch and family for fonts.</summary>
	[PInvokeData("wingdi.h", MSDNShortId = "373bac6e-5d4d-4909-8096-2f0e909d2f1d")]
	[Flags]
	public enum PitchAndFamily : uint
	{
		/// <summary>The default pitch, which is implementation-dependent.</summary>
		DEFAULT_PITCH = 0,

		/// <summary>A fixed pitch, which means that all the characters in the font occupy the same width when output in a string.</summary>
		FIXED_PITCH = 1,

		/// <summary>
		/// A variable pitch, which means that the characters in the font occupy widths that are proportional to the actual widths of the
		/// glyphs when output in a string. For example, the "i" and space characters usually have much smaller widths than a "W" or "O" character.
		/// </summary>
		VARIABLE_PITCH = 2,

		/// <summary>The mono font/</summary>
		MONO_FONT = 8,

		/// <summary>
		/// If this bit is set the font is a variable pitch font. If this bit is clear the font is a fixed pitch font. Note very carefully
		/// that those meanings are the opposite of what the constant name implies.
		/// </summary>
		TMPF_FIXED_PITCH = 0x01,

		/// <summary>If this bit is set the font is a vector font.</summary>
		TMPF_VECTOR = 0x02,

		/// <summary>If this bit is set the font is a TrueType font.</summary>
		TMPF_TRUETYPE = 0x04,

		/// <summary>If this bit is set the font is a device font.</summary>
		TMPF_DEVICE = 0x08,

		/// <summary>Use default font.</summary>
		FF_DONTCARE = 0 << 4,

		/// <summary>Fonts with variable stroke width (proportional) and with serifs. MS Serif is an example.</summary>
		FF_ROMAN = 1 << 4,

		/// <summary>Fonts with variable stroke width (proportional) and without serifs. MS Sans Serif is an example.</summary>
		FF_SWISS = 2 << 4,

		/// <summary>
		/// Fonts with constant stroke width (monospace), with or without serifs. Monospace fonts are usually modern. Pica, Elite, and
		/// CourierNew are examples.
		/// </summary>
		FF_MODERN = 3 << 4,

		/// <summary>Fonts designed to look like handwriting. Script and Cursive are examples.</summary>
		FF_SCRIPT = 4 << 4,

		/// <summary>Novelty fonts. Old English is an example.</summary>
		FF_DECORATIVE = 5 << 4,
	}

	/// <summary>Text-alignment settings for a device context.</summary>
	[PInvokeData("wingdi.h", MSDNShortId = "d3ec0350-2eb8-4843-88bb-d72cece710e7")]
	[Flags]
	public enum TextAlign : uint
	{
		/// <summary>The current position is not updated after each text output call.</summary>
		TA_NOUPDATECP = 0,

		/// <summary>The current position is updated after each text output call.</summary>
		TA_UPDATECP = 1,

		/// <summary>The reference point is on the left edge of the bounding rectangle.</summary>
		TA_LEFT = 0,

		/// <summary>The reference point is on the right edge of the bounding rectangle.</summary>
		TA_RIGHT = 2,

		/// <summary>The reference point is aligned horizontally with the center of the bounding rectangle.</summary>
		TA_CENTER = 6,

		/// <summary>The reference point is on the top edge of the bounding rectangle.</summary>
		TA_TOP = 0,

		/// <summary>The reference point is on the bottom edge of the bounding rectangle.</summary>
		TA_BOTTOM = 8,

		/// <summary>The reference point is on the base line of the text.</summary>
		TA_BASELINE = 24,

		/// <summary>
		/// Middle East language edition of Windows: The text is laid out in right to left reading order, as opposed to the default left to
		/// right order. This only applies when the font selected into the device context is either Hebrew or Arabic.
		/// </summary>
		TA_RTLREADING = 256,
	}

	/// <summary>Flags regarding TrueType status.</summary>
	[PInvokeData("wingdi.h", MSDNShortId = "40bb4b59-90a4-4780-ae5f-fef8a6fa62cb")]
	[Flags]
	public enum TT : short
	{
		/// <summary>TrueType is available.</summary>
		TT_AVAILABLE = 1,

		/// <summary>TrueType is enabled.</summary>
		TT_ENABLED = 2
	}

	/// <summary>The type of curve described by <see cref="TTPOLYCURVE"/>.</summary>
	[PInvokeData("wingdi.h", MSDNShortId = "NS:wingdi.tagTTPOLYCURVE")]
	public enum TT_PRIM : ushort
	{
		/// <summary>Curve is a polyline.</summary>
		TT_PRIM_LINE = 1,

		/// <summary>Curve is a quadratic BÃ©zier spline.</summary>
		TT_PRIM_QSPLINE = 2,

		/// <summary>Curve is a cubic BÃ©zier spline.</summary>
		TT_PRIM_CSPLINE = 3,
	}

	/// <summary>The type of character outline returned by <see cref="TTPOLYGONHEADER"/>.</summary>
	[PInvokeData("wingdi.h", MSDNShortId = "NS:wingdi.tagTTPOLYGONHEADER")]
	public enum TT_TYPE : uint
	{
		/// <summary>The polygon type.</summary>
		TT_POLYGON_TYPE = 24,
	}

	/// <summary>The <c>AddFontMemResourceEx</c> function adds the font resource from a memory image to the system.</summary>
	/// <param name="pFileView">A pointer to a font resource.</param>
	/// <param name="cjSize">The number of bytes in the font resource that is pointed to by pbFont.</param>
	/// <param name="pvResrved">Reserved. Must be 0.</param>
	/// <param name="pNumFonts">A pointer to a variable that specifies the number of fonts installed.</param>
	/// <returns>
	/// If the function succeeds, the return value specifies the handle to the font added. This handle uniquely identifies the fonts that
	/// were installed on the system. If the function fails, the return value is zero. No extended error information is available.
	/// </returns>
	/// <remarks>
	/// <para>
	/// This function allows an application to get a font that is embedded in a document or a webpage. A font that is added by
	/// <c>AddFontMemResourceEx</c> is always private to the process that made the call and is not enumerable.
	/// </para>
	/// <para>
	/// A memory image can contain more than one font. When this function succeeds, pcFonts is a pointer to a <c>DWORD</c> whose value is the
	/// number of fonts added to the system as a result of this call. For example, this number could be 2 for the vertical and horizontal
	/// faces of an Asian font.
	/// </para>
	/// <para>
	/// When the function succeeds, the caller of this function can free the memory pointed to by pbFont because the system has made its own
	/// copy of the memory. To remove the fonts that were installed, call RemoveFontMemResourceEx. However, when the process goes away, the
	/// system will unload the fonts even if the process did not call RemoveFontMemResource.
	/// </para>
	/// </remarks>
	// https://docs.microsoft.com/en-us/windows/win32/api/wingdi/nf-wingdi-addfontmemresourceex HANDLE AddFontMemResourceEx( PVOID pFileView,
	// DWORD cjSize, PVOID pvResrved, DWORD *pNumFonts );
	[DllImport(Lib.Gdi32, SetLastError = false, ExactSpelling = true)]
	[PInvokeData("wingdi.h", MSDNShortId = "ad5153ba-fa9d-4a07-9be3-a07b524c1539")]
	public static extern HANDLE AddFontMemResourceEx([In, SizeDef(nameof(cjSize))] IntPtr pFileView, uint cjSize, [Optional, Ignore] IntPtr pvResrved, out uint pNumFonts);

	/// <summary>
	/// <para>
	/// The <c>AddFontResource</c> function adds the font resource from the specified file to the system font table. The font can
	/// subsequently be used for text output by any application.
	/// </para>
	/// <para>To mark a font as private or not enumerable, use the AddFontResourceEx function.</para>
	/// </summary>
	/// <param name="name">
	/// <para>
	/// A pointer to a null-terminated character string that contains a valid font file name. This parameter can specify any of the following files.
	/// </para>
	/// <list type="table">
	/// <listheader>
	/// <term>File Extension</term>
	/// <term>Meaning</term>
	/// </listheader>
	/// <item>
	/// <term>.fon</term>
	/// <term>Font resource file.</term>
	/// </item>
	/// <item>
	/// <term>.fnt</term>
	/// <term>Raw bitmap font file.</term>
	/// </item>
	/// <item>
	/// <term>.ttf</term>
	/// <term>Raw TrueType file.</term>
	/// </item>
	/// <item>
	/// <term>.ttc</term>
	/// <term>East Asian Windows: TrueType font collection.</term>
	/// </item>
	/// <item>
	/// <term>.fot</term>
	/// <term>TrueType resource file.</term>
	/// </item>
	/// <item>
	/// <term>.otf</term>
	/// <term>PostScript OpenType font.</term>
	/// </item>
	/// <item>
	/// <term>.mmm</term>
	/// <term>Multiple master Type1 font resource file. It must be used with .pfm and .pfb files.</term>
	/// </item>
	/// <item>
	/// <term>.pfb</term>
	/// <term>Type 1 font bits file. It is used with a .pfm file.</term>
	/// </item>
	/// <item>
	/// <term>.pfm</term>
	/// <term>Type 1 font metrics file. It is used with a .pfb file.</term>
	/// </item>
	/// </list>
	/// <para>
	/// To add a font whose information comes from several resource files, have lpszFileName point to a string with the file names separated
	/// by a "|" --for example, abcxxxxx.pfm | abcxxxxx.pfb.
	/// </para>
	/// </param>
	/// <returns>
	/// <para>If the function succeeds, the return value specifies the number of fonts added.</para>
	/// <para>If the function fails, the return value is zero. No extended error information is available.</para>
	/// </returns>
	/// <remarks>
	/// <para>
	/// Any application that adds or removes fonts from the system font table should notify other windows of the change by sending a
	/// WM_FONTCHANGE message to all top-level windows in the operating system. The application should send this message by calling the
	/// SendMessage function and setting the hwnd parameter to HWND_BROADCAST.
	/// </para>
	/// <para>
	/// When an application no longer needs a font resource that it loaded by calling the <c>AddFontResource</c> function, it must remove
	/// that resource by calling the RemoveFontResource function.
	/// </para>
	/// <para>
	/// This function installs the font only for the current session. When the system restarts, the font will not be present. To have the
	/// font installed even after restarting the system, the font must be listed in the registry.
	/// </para>
	/// <para>
	/// A font listed in the registry and installed to a location other than the %windir%\fonts\ folder cannot be modified, deleted, or
	/// replaced as long as it is loaded in any session. In order to change one of these fonts, it must first be removed by calling
	/// RemoveFontResource, removed from the font registry ( <c>HKEY_LOCAL_MACHINE\SOFTWARE\Microsoft\Windows NT\CurrentVersion\Fonts</c>),
	/// and the system restarted. After restarting the system, the font will no longer be loaded and can be changed.
	/// </para>
	/// </remarks>
	// https://docs.microsoft.com/en-us/windows/win32/api/wingdi/nf-wingdi-addfontresourcea int AddFontResourceA( LPCSTR Arg1 );
	[DllImport(Lib.Gdi32, SetLastError = false, CharSet = CharSet.Auto)]
	[PInvokeData("wingdi.h", MSDNShortId = "e553a25a-f281-4ddc-8e95-1f61ed8238f9")]
	public static extern int AddFontResource(string name);

	/// <summary>
	/// The <c>AddFontResourceEx</c> function adds the font resource from the specified file to the system. Fonts added with the
	/// <c>AddFontResourceEx</c> function can be marked as private and not enumerable.
	/// </summary>
	/// <param name="name">
	/// <para>
	/// A pointer to a null-terminated character string that contains a valid font file name. This parameter can specify any of the following files.
	/// </para>
	/// <list type="table">
	/// <listheader>
	/// <term>File Extension</term>
	/// <term>Meaning</term>
	/// </listheader>
	/// <item>
	/// <term>.fon</term>
	/// <term>Font resource file.</term>
	/// </item>
	/// <item>
	/// <term>.fnt</term>
	/// <term>Raw bitmap font file.</term>
	/// </item>
	/// <item>
	/// <term>.ttf</term>
	/// <term>Raw TrueType file.</term>
	/// </item>
	/// <item>
	/// <term>.ttc</term>
	/// <term>East Asian Windows: TrueType font collection.</term>
	/// </item>
	/// <item>
	/// <term>.fot</term>
	/// <term>TrueType resource file.</term>
	/// </item>
	/// <item>
	/// <term>.otf</term>
	/// <term>PostScript OpenType font.</term>
	/// </item>
	/// <item>
	/// <term>.mmm</term>
	/// <term>multiple master Type1 font resource file. It must be used with .pfm and .pfb files.</term>
	/// </item>
	/// <item>
	/// <term>.pfb</term>
	/// <term>Type 1 font bits file. It is used with a .pfm file.</term>
	/// </item>
	/// <item>
	/// <term>.pfm</term>
	/// <term>Type 1 font metrics file. It is used with a .pfb file.</term>
	/// </item>
	/// </list>
	/// <para>
	/// To add a font whose information comes from several resource files, point lpszFileName to a string with the file names separated by a
	/// | --for example, abcxxxxx.pfm | abcxxxxx.pfb.
	/// </para>
	/// </param>
	/// <param name="fl">
	/// <para>The characteristics of the font to be added to the system. This parameter can be one of the following values.</para>
	/// <list type="table">
	/// <listheader>
	/// <term>Value</term>
	/// <term>Meaning</term>
	/// </listheader>
	/// <item>
	/// <term>FR_PRIVATE</term>
	/// <term>
	/// Specifies that only the process that called the AddFontResourceEx function can use this font. When the font name matches a public
	/// font, the private font will be chosen. When the process terminates, the system will remove all fonts installed by the process with
	/// the AddFontResourceEx function.
	/// </term>
	/// </item>
	/// <item>
	/// <term>FR_NOT_ENUM</term>
	/// <term>Specifies that no process, including the process that called the AddFontResourceEx function, can enumerate this font.</term>
	/// </item>
	/// </list>
	/// </param>
	/// <param name="res">Reserved. Must be zero.</param>
	/// <returns>
	/// <para>If the function succeeds, the return value specifies the number of fonts added.</para>
	/// <para>If the function fails, the return value is zero. No extended error information is available.</para>
	/// </returns>
	/// <remarks>
	/// <para>This function allows a process to use fonts without allowing other processes access to the fonts.</para>
	/// <para>
	/// When an application no longer needs a font resource it loaded by calling the <c>AddFontResourceEx</c> function, it must remove the
	/// resource by calling the RemoveFontResourceEx function.
	/// </para>
	/// <para>
	/// This function installs the font only for the current session. When the system restarts, the font will not be present. To have the
	/// font installed even after restarting the system, the font must be listed in the registry.
	/// </para>
	/// <para>
	/// A font listed in the registry and installed to a location other than the %windir%\fonts\ folder cannot be modified, deleted, or
	/// replaced as long as it is loaded in any session. In order to change one of these fonts, it must first be removed by calling
	/// RemoveFontResource, removed from the font registry ( <c>HKEY_LOCAL_MACHINE\SOFTWARE\Microsoft\Windows NT\CurrentVersion\Fonts</c>),
	/// and the system restarted. After restarting the system, the font will no longer be loaded and can be changed.
	/// </para>
	/// </remarks>
	// https://docs.microsoft.com/en-us/windows/win32/api/wingdi/nf-wingdi-addfontresourceexa int AddFontResourceExA( LPCSTR name, DWORD fl,
	// PVOID res );
	[DllImport(Lib.Gdi32, SetLastError = false, CharSet = CharSet.Auto)]
	[PInvokeData("wingdi.h", MSDNShortId = "eaf8ebf0-1b06-4a09-a842-83540245a117")]
	public static extern int AddFontResourceEx(string name, FR fl, IntPtr res = default);

	/// <summary>
	/// The <c>CreateFont</c> function creates a logical font with the specified characteristics. The logical font can subsequently be
	/// selected as the font for any device.
	/// </summary>
	/// <param name="cHeight">
	/// <para>
	/// The height, in logical units, of the font's character cell or character. The character height value (also known as the em height) is
	/// the character cell height value minus the internal-leading value. The font mapper interprets the value specified in nHeight in the
	/// following manner.
	/// </para>
	/// <list type="table">
	/// <listheader>
	/// <term>Value</term>
	/// <term>Meaning</term>
	/// </listheader>
	/// <item>
	/// <term>&gt; 0</term>
	/// <term>The font mapper transforms this value into device units and matches it against the cell height of the available fonts.</term>
	/// </item>
	/// <item>
	/// <term>0</term>
	/// <term>The font mapper uses a default height value when it searches for a match.</term>
	/// </item>
	/// <item>
	/// <term>&lt; 0</term>
	/// <term>
	/// The font mapper transforms this value into device units and matches its absolute value against the character height of the available fonts.
	/// </term>
	/// </item>
	/// </list>
	/// <para>For all height comparisons, the font mapper looks for the largest font that does not exceed the requested size.</para>
	/// <para>This mapping occurs when the font is used for the first time.</para>
	/// <para>For the MM_TEXT mapping mode, you can use the following formula to specify a height for a font with a specified point size:</para>
	/// <para>nHeight = -MulDiv(PointSize, GetDeviceCaps(hDC, LOGPIXELSY), 72);</para>
	/// </param>
	/// <param name="cWidth">
	/// The average width, in logical units, of characters in the requested font. If this value is zero, the font mapper chooses a closest
	/// match value. The closest match value is determined by comparing the absolute values of the difference between the current device's
	/// aspect ratio and the digitized aspect ratio of available fonts.
	/// </param>
	/// <param name="cEscapement">
	/// <para>
	/// The angle, in tenths of degrees, between the escapement vector and the x-axis of the device. The escapement vector is parallel to the
	/// base line of a row of text.
	/// </para>
	/// <para>
	/// When the graphics mode is set to GM_ADVANCED, you can specify the escapement angle of the string independently of the orientation
	/// angle of the string's characters.
	/// </para>
	/// <para>
	/// When the graphics mode is set to GM_COMPATIBLE, nEscapement specifies both the escapement and orientation. You should set nEscapement
	/// and nOrientation to the same value.
	/// </para>
	/// </param>
	/// <param name="cOrientation">The angle, in tenths of degrees, between each character's base line and the x-axis of the device.</param>
	/// <param name="cWeight">
	/// <para>
	/// The weight of the font in the range 0 through 1000. For example, 400 is normal and 700 is bold. If this value is zero, a default
	/// weight is used.
	/// </para>
	/// <para>The following values are defined for convenience.</para>
	/// <list type="table">
	/// <listheader>
	/// <term>Weight</term>
	/// <term>Value</term>
	/// </listheader>
	/// <item>
	/// <term>FW_DONTCARE</term>
	/// <term>0</term>
	/// </item>
	/// <item>
	/// <term>FW_THIN</term>
	/// <term>100</term>
	/// </item>
	/// <item>
	/// <term>FW_EXTRALIGHT</term>
	/// <term>200</term>
	/// </item>
	/// <item>
	/// <term>FW_ULTRALIGHT</term>
	/// <term>200</term>
	/// </item>
	/// <item>
	/// <term>FW_LIGHT</term>
	/// <term>300</term>
	/// </item>
	/// <item>
	/// <term>FW_NORMAL</term>
	/// <term>400</term>
	/// </item>
	/// <item>
	/// <term>FW_REGULAR</term>
	/// <term>400</term>
	/// </item>
	/// <item>
	/// <term>FW_MEDIUM</term>
	/// <term>500</term>
	/// </item>
	/// <item>
	/// <term>FW_SEMIBOLD</term>
	/// <term>600</term>
	/// </item>
	/// <item>
	/// <term>FW_DEMIBOLD</term>
	/// <term>600</term>
	/// </item>
	/// <item>
	/// <term>FW_BOLD</term>
	/// <term>700</term>
	/// </item>
	/// <item>
	/// <term>FW_EXTRABOLD</term>
	/// <term>800</term>
	/// </item>
	/// <item>
	/// <term>FW_ULTRABOLD</term>
	/// <term>800</term>
	/// </item>
	/// <item>
	/// <term>FW_HEAVY</term>
	/// <term>900</term>
	/// </item>
	/// <item>
	/// <term>FW_BLACK</term>
	/// <term>900</term>
	/// </item>
	/// </list>
	/// </param>
	/// <param name="bItalic">Specifies an italic font if set to <c>TRUE</c>.</param>
	/// <param name="bUnderline">Specifies an underlined font if set to <c>TRUE</c>.</param>
	/// <param name="bStrikeOut">A strikeout font if set to <c>TRUE</c>.</param>
	/// <param name="iCharSet">
	/// <para>The character set. The following values are predefined:</para>
	/// <list type="bullet">
	/// <item>
	/// <term>ANSI_CHARSET</term>
	/// </item>
	/// <item>
	/// <term>BALTIC_CHARSET</term>
	/// </item>
	/// <item>
	/// <term>CHINESEBIG5_CHARSET</term>
	/// </item>
	/// <item>
	/// <term>DEFAULT_CHARSET</term>
	/// </item>
	/// <item>
	/// <term>EASTEUROPE_CHARSET</term>
	/// </item>
	/// <item>
	/// <term>GB2312_CHARSET</term>
	/// </item>
	/// <item>
	/// <term>GREEK_CHARSET</term>
	/// </item>
	/// <item>
	/// <term>HANGUL_CHARSET</term>
	/// </item>
	/// <item>
	/// <term>MAC_CHARSET</term>
	/// </item>
	/// <item>
	/// <term>OEM_CHARSET</term>
	/// </item>
	/// <item>
	/// <term>RUSSIAN_CHARSET</term>
	/// </item>
	/// <item>
	/// <term>SHIFTJIS_CHARSET</term>
	/// </item>
	/// <item>
	/// <term>SYMBOL_CHARSET</term>
	/// </item>
	/// <item>
	/// <term>TURKISH_CHARSET</term>
	/// </item>
	/// <item>
	/// <term>VIETNAMESE_CHARSET</term>
	/// </item>
	/// </list>
	/// <para>Korean language edition of Windows:</para>
	/// <list type="bullet">
	/// <item>
	/// <term>JOHAB_CHARSET</term>
	/// </item>
	/// </list>
	/// <para>Middle East language edition of Windows:</para>
	/// <list type="bullet">
	/// <item>
	/// <term>ARABIC_CHARSET</term>
	/// </item>
	/// <item>
	/// <term>HEBREW_CHARSET</term>
	/// </item>
	/// </list>
	/// <para>Thai language edition of Windows:</para>
	/// <list type="bullet">
	/// <item>
	/// <term>THAI_CHARSET</term>
	/// </item>
	/// </list>
	/// <para>The OEM_CHARSET value specifies a character set that is operating-system dependent.</para>
	/// <para>
	/// DEFAULT_CHARSET is set to a value based on the current system locale. For example, when the system locale is English (United States),
	/// it is set as ANSI_CHARSET.
	/// </para>
	/// <para>
	/// Fonts with other character sets may exist in the operating system. If an application uses a font with an unknown character set, it
	/// should not attempt to translate or interpret strings that are rendered with that font.
	/// </para>
	/// <para>
	/// To ensure consistent results when creating a font, do not specify OEM_CHARSET or DEFAULT_CHARSET. If you specify a typeface name in
	/// the lpszFace parameter, make sure that the fdwCharSet value matches the character set of the typeface specified in lpszFace.
	/// </para>
	/// </param>
	/// <param name="iOutPrecision">
	/// <para>
	/// The output precision. The output precision defines how closely the output must match the requested font's height, width, character
	/// orientation, escapement, pitch, and font type. It can be one of the following values.
	/// </para>
	/// <list type="table">
	/// <listheader>
	/// <term>Value</term>
	/// <term>Meaning</term>
	/// </listheader>
	/// <item>
	/// <term>OUT_CHARACTER_PRECIS</term>
	/// <term>Not used.</term>
	/// </item>
	/// <item>
	/// <term>OUT_DEFAULT_PRECIS</term>
	/// <term>The default font mapper behavior.</term>
	/// </item>
	/// <item>
	/// <term>OUT_DEVICE_PRECIS</term>
	/// <term>Instructs the font mapper to choose a Device font when the system contains multiple fonts with the same name.</term>
	/// </item>
	/// <item>
	/// <term>OUT_OUTLINE_PRECIS</term>
	/// <term>This value instructs the font mapper to choose from TrueType and other outline-based fonts.</term>
	/// </item>
	/// <item>
	/// <term>OUT_PS_ONLY_PRECIS</term>
	/// <term>
	/// Instructs the font mapper to choose from only PostScript fonts. If there are no PostScript fonts installed in the system, the font
	/// mapper returns to default behavior.
	/// </term>
	/// </item>
	/// <item>
	/// <term>OUT_RASTER_PRECIS</term>
	/// <term>Instructs the font mapper to choose a raster font when the system contains multiple fonts with the same name.</term>
	/// </item>
	/// <item>
	/// <term>OUT_STRING_PRECIS</term>
	/// <term>This value is not used by the font mapper, but it is returned when raster fonts are enumerated.</term>
	/// </item>
	/// <item>
	/// <term>OUT_STROKE_PRECIS</term>
	/// <term>
	/// This value is not used by the font mapper, but it is returned when TrueType, other outline-based fonts, and vector fonts are enumerated.
	/// </term>
	/// </item>
	/// <item>
	/// <term>OUT_TT_ONLY_PRECIS</term>
	/// <term>
	/// Instructs the font mapper to choose from only TrueType fonts. If there are no TrueType fonts installed in the system, the font mapper
	/// returns to default behavior.
	/// </term>
	/// </item>
	/// <item>
	/// <term>OUT_TT_PRECIS</term>
	/// <term>Instructs the font mapper to choose a TrueType font when the system contains multiple fonts with the same name.</term>
	/// </item>
	/// </list>
	/// <para>
	/// Applications can use the OUT_DEVICE_PRECIS, OUT_RASTER_PRECIS, OUT_TT_PRECIS, and OUT_PS_ONLY_PRECIS values to control how the font
	/// mapper chooses a font when the operating system contains more than one font with a specified name. For example, if an operating
	/// system contains a font named Symbol in raster and TrueType form, specifying OUT_TT_PRECIS forces the font mapper to choose the
	/// TrueType version. Specifying OUT_TT_ONLY_PRECIS forces the font mapper to choose a TrueType font, even if it must substitute a
	/// TrueType font of another name.
	/// </para>
	/// </param>
	/// <param name="iClipPrecision">
	/// <para>
	/// The clipping precision. The clipping precision defines how to clip characters that are partially outside the clipping region. It can
	/// be one or more of the following values.
	/// </para>
	/// <list type="table">
	/// <listheader>
	/// <term>Value</term>
	/// <term>Meaning</term>
	/// </listheader>
	/// <item>
	/// <term>CLIP_CHARACTER_PRECIS</term>
	/// <term>Not used.</term>
	/// </item>
	/// <item>
	/// <term>CLIP_DEFAULT_PRECIS</term>
	/// <term>Specifies default clipping behavior.</term>
	/// </item>
	/// <item>
	/// <term>CLIP_DFA_DISABLE</term>
	/// <term>
	/// Windows XP SP1: Turns off font association for the font. Note that this flag is not guaranteed to have any effect on any platform
	/// after Windows Server 2003.
	/// </term>
	/// </item>
	/// <item>
	/// <term>CLIP_EMBEDDED</term>
	/// <term>You must specify this flag to use an embedded read-only font.</term>
	/// </item>
	/// <item>
	/// <term>CLIP_LH_ANGLES</term>
	/// <term>
	/// When this value is used, the rotation for all fonts depends on whether the orientation of the coordinate system is left-handed or
	/// right-handed. If not used, device fonts always rotate counterclockwise, but the rotation of other fonts is dependent on the
	/// orientation of the coordinate system. For more information about the orientation of coordinate systems, see the description of the
	/// nOrientation parameter
	/// </term>
	/// </item>
	/// <item>
	/// <term>CLIP_MASK</term>
	/// <term>Not used.</term>
	/// </item>
	/// <item>
	/// <term>CLIP_DFA_OVERRIDE</term>
	/// <term>
	/// Turns off font association for the font. This is identical to CLIP_DFA_DISABLE, but it can have problems in some situations; the
	/// recommended flag to use is CLIP_DFA_DISABLE.
	/// </term>
	/// </item>
	/// <item>
	/// <term>CLIP_STROKE_PRECIS</term>
	/// <term>
	/// Not used by the font mapper, but is returned when raster, vector, or TrueType fonts are enumerated. For compatibility, this value is
	/// always returned when enumerating fonts.
	/// </term>
	/// </item>
	/// <item>
	/// <term>CLIP_TT_ALWAYS</term>
	/// <term>Not used.</term>
	/// </item>
	/// </list>
	/// </param>
	/// <param name="iQuality">
	/// <para>
	/// The output quality. The output quality defines how carefully GDI must attempt to match the logical-font attributes to those of an
	/// actual physical font. It can be one of the following values.
	/// </para>
	/// <list type="table">
	/// <listheader>
	/// <term>Value</term>
	/// <term>Meaning</term>
	/// </listheader>
	/// <item>
	/// <term>ANTIALIASED_QUALITY</term>
	/// <term>Font is antialiased, or smoothed, if the font supports it and the size of the font is not too small or too large.</term>
	/// </item>
	/// <item>
	/// <term>CLEARTYPE_QUALITY</term>
	/// <term>If set, text is rendered (when possible) using ClearType antialiasing method. See Remarks for more information.</term>
	/// </item>
	/// <item>
	/// <term>DEFAULT_QUALITY</term>
	/// <term>Appearance of the font does not matter.</term>
	/// </item>
	/// <item>
	/// <term>DRAFT_QUALITY</term>
	/// <term>
	/// Appearance of the font is less important than when the PROOF_QUALITY value is used. For GDI raster fonts, scaling is enabled, which
	/// means that more font sizes are available, but the quality may be lower. Bold, italic, underline, and strikeout fonts are synthesized,
	/// if necessary.
	/// </term>
	/// </item>
	/// <item>
	/// <term>NONANTIALIASED_QUALITY</term>
	/// <term>Font is never antialiased, that is, font smoothing is not done.</term>
	/// </item>
	/// <item>
	/// <term>PROOF_QUALITY</term>
	/// <term>
	/// Character quality of the font is more important than exact matching of the logical-font attributes. For GDI raster fonts, scaling is
	/// disabled and the font closest in size is chosen. Although the chosen font size may not be mapped exactly when PROOF_QUALITY is used,
	/// the quality of the font is high and there is no distortion of appearance. Bold, italic, underline, and strikeout fonts are
	/// synthesized, if necessary.
	/// </term>
	/// </item>
	/// </list>
	/// <para>
	/// If the output quality is DEFAULT_QUALITY, DRAFT_QUALITY, or PROOF_QUALITY, then the font is antialiased if the SPI_GETFONTSMOOTHING
	/// system parameter is <c>TRUE</c>. Users can control this system parameter from the Control Panel. (The precise wording of the setting
	/// in the Control panel depends on the version of Windows, but it will be words to the effect of "Smooth edges of screen fonts".)
	/// </para>
	/// </param>
	/// <param name="iPitchAndFamily">
	/// <para>The pitch and family of the font. The two low-order bits specify the pitch of the font and can be one of the following values:</para>
	/// <list type="bullet">
	/// <item>
	/// <term>DEFAULT_PITCH</term>
	/// </item>
	/// <item>
	/// <term>FIXED_PITCH</term>
	/// </item>
	/// <item>
	/// <term>VARIABLE_PITCH</term>
	/// </item>
	/// </list>
	/// <para>The four high-order bits specify the font family and can be one of the following values.</para>
	/// <list type="table">
	/// <listheader>
	/// <term>Value</term>
	/// <term>Meaning</term>
	/// </listheader>
	/// <item>
	/// <term>FF_DECORATIVE</term>
	/// <term>Novelty fonts. Old English is an example.</term>
	/// </item>
	/// <item>
	/// <term>FF_DONTCARE</term>
	/// <term>Use default font.</term>
	/// </item>
	/// <item>
	/// <term>FF_MODERN</term>
	/// <term>Fonts with constant stroke width, with or without serifs. Pica, Elite, and Courier New are examples.</term>
	/// </item>
	/// <item>
	/// <term>FF_ROMAN</term>
	/// <term>Fonts with variable stroke width and with serifs. MS Serif is an example.</term>
	/// </item>
	/// <item>
	/// <term>FF_SCRIPT</term>
	/// <term>Fonts designed to look like handwriting. Script and Cursive are examples.</term>
	/// </item>
	/// <item>
	/// <term>FF_SWISS</term>
	/// <term>Fonts with variable stroke width and without serifs. MS?Sans Serif is an example.</term>
	/// </item>
	/// </list>
	/// <para>
	/// An application can specify a value for the fdwPitchAndFamily parameter by using the Boolean OR operator to join a pitch constant with
	/// a family constant.
	/// </para>
	/// <para>
	/// Font families describe the look of a font in a general way. They are intended for specifying fonts when the exact typeface requested
	/// is not available.
	/// </para>
	/// </param>
	/// <param name="pszFaceName">
	/// <para>
	/// A pointer to a null-terminated string that specifies the typeface name of the font. The length of this string must not exceed 32
	/// characters, including the terminating null character. The EnumFontFamilies function can be used to enumerate the typeface names of
	/// all currently available fonts. For more information, see the Remarks.
	/// </para>
	/// <para>If lpszFace is <c>NULL</c> or empty string, GDI uses the first font that matches the other specified attributes.</para>
	/// </param>
	/// <returns>
	/// <para>If the function succeeds, the return value is a handle to a logical font.</para>
	/// <para>If the function fails, the return value is <c>NULL</c>.</para>
	/// </returns>
	/// <remarks>
	/// <para>When you no longer need the font, call the DeleteObject function to delete it.</para>
	/// <para>
	/// To help protect the copyrights of vendors who provide fonts for Windows, applications should always report the exact name of a
	/// selected font. Because available fonts can vary from system to system, do not assume that the selected font is always the same as the
	/// requested font. For example, if you request a font named Palatino, but no such font is available on the system, the font mapper will
	/// substitute a font that has similar attributes but a different name. Always report the name of the selected font to the user.
	/// </para>
	/// <para>
	/// To get the appropriate font on different language versions of the OS, call EnumFontFamiliesEx with the desired font characteristics
	/// in the LOGFONT structure, then retrieve the appropriate typeface name and create the font using <c>CreateFont</c> or CreateFontIndirect.
	/// </para>
	/// <para>
	/// The font mapper for <c>CreateFont</c>,CreateFontIndirect, and CreateFontIndirectEx recognizes both the English and the localized
	/// typeface name, regardless of locale.
	/// </para>
	/// <para>The following situations do not support ClearType antialiasing:</para>
	/// <list type="bullet">
	/// <item>
	/// <term>Text rendered on a printer.</term>
	/// </item>
	/// <item>
	/// <term>A display set for 256 colors or less.</term>
	/// </item>
	/// <item>
	/// <term>Text rendered to a terminal server client.</term>
	/// </item>
	/// <item>
	/// <term>
	/// The font is not a TrueType font or an OpenType font with TrueType outlines. For example, the following do not support ClearType
	/// antialiasing: Type 1 fonts, Postscript OpenType fonts without TrueType outlines, bitmap fonts, vector fonts, and device fonts.
	/// </term>
	/// </item>
	/// <item>
	/// <term>
	/// The font has tuned embedded bitmaps, only for the font sizes that contain the embedded bitmaps. For example, this occurs commonly in
	/// East Asian fonts.
	/// </term>
	/// </item>
	/// </list>
	/// <para>Examples</para>
	/// <para>For another example, see "Setting Fonts for Menu-Item Text Strings" in Using Menus.</para>
	/// </remarks>
	// https://docs.microsoft.com/en-us/windows/win32/api/wingdi/nf-wingdi-createfonta HFONT CreateFontA( int cHeight, int cWidth, int
	// cEscapement, int cOrientation, int cWeight, DWORD bItalic, DWORD bUnderline, DWORD bStrikeOut, DWORD iCharSet, DWORD iOutPrecision,
	// DWORD iClipPrecision, DWORD iQuality, DWORD iPitchAndFamily, LPCSTR pszFaceName );
	[DllImport(Lib.Gdi32, SetLastError = false, CharSet = CharSet.Auto)]
	[PInvokeData("wingdi.h", MSDNShortId = "373bac6e-5d4d-4909-8096-2f0e909d2f1d")]
	[return: AddAsCtor]
	public static extern SafeHFONT CreateFont([Optional] int cHeight, [Optional] int cWidth, [Optional] int cEscapement, [Optional] int cOrientation,
		[Optional] int cWeight, [Optional, MarshalAs(UnmanagedType.Bool)] bool bItalic, [Optional, MarshalAs(UnmanagedType.Bool)] bool bUnderline,
		[Optional, MarshalAs(UnmanagedType.Bool)] bool bStrikeOut, CharacterSet iCharSet = CharacterSet.DEFAULT_CHARSET,
		OutputPrecision iOutPrecision = OutputPrecision.OUT_DEFAULT_PRECIS, ClippingPrecision iClipPrecision = ClippingPrecision.CLIP_DEFAULT_PRECIS,
		OutputQuality iQuality = OutputQuality.DEFAULT_QUALITY, PitchAndFamily iPitchAndFamily = PitchAndFamily.FF_DONTCARE, string? pszFaceName = null);

	/// <summary>
	/// The <c>CreateFontIndirect</c> function creates a logical font that has the specified characteristics. The font can subsequently be
	/// selected as the current font for any device context.
	/// </summary>
	/// <param name="lplf">A pointer to a LOGFONT structure that defines the characteristics of the logical font.</param>
	/// <returns>
	/// <para>If the function succeeds, the return value is a handle to a logical font.</para>
	/// <para>If the function fails, the return value is <c>NULL</c>.</para>
	/// </returns>
	/// <remarks>
	/// <para>
	/// The <c>CreateFontIndirect</c> function creates a logical font with the characteristics specified in the LOGFONT structure. When this
	/// font is selected by using the SelectObject function, GDI's font mapper attempts to match the logical font with an existing physical
	/// font. If it fails to find an exact match, it provides an alternative whose characteristics match as many of the requested
	/// characteristics as possible.
	/// </para>
	/// <para>
	/// To get the appropriate font on different language versions of the OS, call EnumFontFamiliesEx with the desired font characteristics
	/// in the LOGFONT structure, retrieve the appropriate typeface name, and create the font using CreateFont or <c>CreateFontIndirect</c>.
	/// </para>
	/// <para>When you no longer need the font, call the DeleteObject function to delete it.</para>
	/// <para>
	/// The fonts for many East Asian languages have two typeface names: an English name and a localized name. CreateFont and
	/// <c>CreateFontIndirect</c> take the localized typeface name only on a system locale that matches the language, while they take the
	/// English typeface name on all other system locales. The best method is to try one name and, on failure, try the other. Note that
	/// EnumFonts, EnumFontFamilies, and EnumFontFamiliesEx return the English typeface name if the system locale does not match the language
	/// of the font.
	/// </para>
	/// <para>
	/// The font mapper for CreateFont, <c>CreateFontIndirect</c>, and CreateFontIndirectEx recognizes both the English and the localized
	/// typeface name, regardless of locale.
	/// </para>
	/// <para>Examples</para>
	/// <para>For an example, see Creating a Logical Font.</para>
	/// </remarks>
	// https://docs.microsoft.com/en-us/windows/win32/api/wingdi/nf-wingdi-createfontindirecta HFONT CreateFontIndirectA( const LOGFONTA
	// *lplf );
	[DllImport(Lib.Gdi32, SetLastError = false, CharSet = CharSet.Auto)]
	[PInvokeData("wingdi.h", MSDNShortId = "b7919fb6-8515-4f1b-af9c-dc7eac381b90")]
	[return: AddAsCtor]
	public static extern SafeHFONT CreateFontIndirect(in LOGFONT lplf);

	/// <summary>
	/// The <c>CreateFontIndirectEx</c> function specifies a logical font that has the characteristics in the specified structure. The font
	/// can subsequently be selected as the current font for any device context.
	/// </summary>
	/// <param name="Arg1">
	/// <para>Pointer to an ENUMLOGFONTEXDV structure that defines the characteristics of a multiple master font.</para>
	/// <para>Note, this function ignores the <c>elfDesignVector</c> member in ENUMLOGFONTEXDV.</para>
	/// </param>
	/// <returns>
	/// <para>If the function succeeds, the return value is the handle to the new ENUMLOGFONTEXDV structure.</para>
	/// <para>If the function fails, the return value is zero. No extended error information is available.</para>
	/// </returns>
	/// <remarks>
	/// <para>
	/// The <c>CreateFontIndirectEx</c> function creates a logical font with the characteristics specified in the ENUMLOGFONTEXDV structure.
	/// When this font is selected by using the SelectObject function, GDI's font mapper attempts to match the logical font with an existing
	/// physical font. If it fails to find an exact match, it provides an alternative whose characteristics match as many of the requested
	/// characteristics as possible.
	/// </para>
	/// <para>When you no longer need the font, call the DeleteObject function to delete it.</para>
	/// <para>
	/// The font mapper for CreateFont, CreateFontIndirect, and <c>CreateFontIndirectEx</c> recognizes both the English and the localized
	/// typeface name, regardless of locale.
	/// </para>
	/// </remarks>
	// https://docs.microsoft.com/en-us/windows/win32/api/wingdi/nf-wingdi-createfontindirectexa HFONT CreateFontIndirectExA( const
	// ENUMLOGFONTEXDVA *Arg1 );
	[DllImport(Lib.Gdi32, SetLastError = false, CharSet = CharSet.Auto)]
	[PInvokeData("wingdi.h", MSDNShortId = "1161b79e-f9c8-4073-97c4-1ccc1a78279b")]
	[return: AddAsCtor]
	public static extern SafeHFONT CreateFontIndirectEx(in ENUMLOGFONTEXDV Arg1);

	/// <summary>
	/// <para>
	/// [The <c>CreateScalableFontResource</c> function is available for use in the operating systems specified in the Requirements section.
	/// It may be
	/// </para>
	/// <para>altered or unavailable in subsequent versions.]</para>
	/// <para>The <c>CreateScalableFontResource</c> function creates a font resource file for a scalable font.</para>
	/// </summary>
	/// <param name="fdwHidden">
	/// <para>Specifies whether the font is a read-only font. This parameter can be one of the following values.</para>
	/// <list type="table">
	/// <listheader>
	/// <term>Value</term>
	/// <term>Meaning</term>
	/// </listheader>
	/// <item>
	/// <term>0</term>
	/// <term>The font has read/write permission.</term>
	/// </item>
	/// <item>
	/// <term>1</term>
	/// <term>
	/// The font has read-only permission and should be hidden from other applications in the system. When this flag is set, the font is not
	/// enumerated by the EnumFonts or EnumFontFamilies function.
	/// </term>
	/// </item>
	/// </list>
	/// </param>
	/// <param name="lpszFont">
	/// A pointer to a null-terminated string specifying the name of the font resource file to create. If this parameter specifies an
	/// existing font resource file, the function fails.
	/// </param>
	/// <param name="lpszFile">
	/// A pointer to a null-terminated string specifying the name of the scalable font file that this function uses to create the font
	/// resource file.
	/// </param>
	/// <param name="lpszPath">A pointer to a null-terminated string specifying the path to the scalable font file.</param>
	/// <returns>
	/// <para>If the function succeeds, the return value is nonzero.</para>
	/// <para>If the function fails, the return value is zero.</para>
	/// <para>If lpszFontRes specifies an existing font file, GetLastError returns ERROR_FILE_EXISTS</para>
	/// </returns>
	/// <remarks>
	/// <para>
	/// The <c>CreateScalableFontResource</c> function is used by applications that install TrueType fonts. An application uses the
	/// <c>CreateScalableFontResource</c> function to create a font resource file (typically with a .fot file name extension) and then uses
	/// the AddFontResource function to install the font. The TrueType font file (typically with a .ttf file name extension) must be in the
	/// System subdirectory of the Windows directory to be used by the AddFontResource function.
	/// </para>
	/// <para>The <c>CreateScalableFontResource</c> function currently supports only TrueType-technology scalable fonts.</para>
	/// <para>
	/// When the lpszFontFile parameter specifies only a file name and extension, the lpszCurrentPath parameter must specify a path. When the
	/// lpszFontFile parameter specifies a full path, the lpszCurrentPath parameter must be <c>NULL</c> or a pointer to <c>NULL</c>.
	/// </para>
	/// <para>
	/// When only a file name and extension are specified in the lpszFontFile parameter and a path is specified in the lpszCurrentPath
	/// parameter, the string in lpszFontFile is copied into the .fot file as the .ttf file that belongs to this resource. When the
	/// AddFontResource function is called, the operating system assumes that the .ttf file has been copied into the System directory (or
	/// into the main Windows directory in the case of a network installation). The .ttf file need not be in this directory when the
	/// <c>CreateScalableFontResource</c> function is called, because the lpszCurrentPath parameter contains the directory information. A
	/// resource created in this manner does not contain absolute path information and can be used in any installation.
	/// </para>
	/// <para>
	/// When a path is specified in the lpszFontFile parameter and <c>NULL</c> is specified in the lpszCurrentPath parameter, the string in
	/// lpszFontFile is copied into the .fot file. In this case, when the AddFontResource function is called, the .ttf file must be at the
	/// location specified in the lpszFontFile parameter when the <c>CreateScalableFontResource</c> function was called; the lpszCurrentPath
	/// parameter is not needed. A resource created in this manner contains absolute references to paths and drives and does not work if the
	/// .ttf file is moved to a different location.
	/// </para>
	/// </remarks>
	// https://docs.microsoft.com/en-us/windows/win32/api/wingdi/nf-wingdi-createscalablefontresourcea BOOL CreateScalableFontResourceA(
	// DWORD fdwHidden, LPCSTR lpszFont, LPCSTR lpszFile, LPCSTR lpszPath );
	[DllImport(Lib.Gdi32, SetLastError = true, CharSet = CharSet.Auto)]
	[PInvokeData("wingdi.h", MSDNShortId = "9a43a254-4cf4-46de-80b2-a83838871fd7")]
	[return: MarshalAs(UnmanagedType.Bool)]
	public static extern bool CreateScalableFontResource(uint fdwHidden, string lpszFont, string lpszFile, string? lpszPath);

	/// <summary>This function enables or disables support for end-user-defined characters (EUDC).</summary>
	/// <param name="fEnableEUDC">Boolean that is set to <c>TRUE</c> to enable EUDC, and to <c>FALSE</c> to disable EUDC.</param>
	/// <returns>
	/// <para>If the function succeeds, the return value is nonzero.</para>
	/// <para>If the function fails, the return value is zero.</para>
	/// </returns>
	/// <remarks>
	/// <para>If EUDC is disabled, trying to display EUDC characters will result in missing or bad glyphs.</para>
	/// <para>During multi-session, this function affects the current session only.</para>
	/// <para>It is recommended that you use this function with Windows XP SP2 or later.</para>
	/// </remarks>
	// https://docs.microsoft.com/en-us/windows/win32/gdi/enableeudc BOOL EnableEUDC( _In_ HDC BOOL fEnableEUDC );
	[DllImport(Lib.Gdi32, SetLastError = false, ExactSpelling = true)]
	[PInvokeData("", MSDNShortId = "9e531d8c-6008-4189-ae25-cda707be5e2c")]
	[return: MarshalAs(UnmanagedType.Bool)]
	public static extern bool EnableEUDC([MarshalAs(UnmanagedType.Bool)] bool fEnableEUDC);

	/// <summary>
	/// <para>The <c>EnumFontFamilies</c> function enumerates the fonts in a specified font family that are available on a specified device.</para>
	/// <para>
	/// <c>Note</c> This function is provided only for compatibility with 16-bit versions of Windows. Applications should use the
	/// EnumFontFamiliesEx function.
	/// </para>
	/// </summary>
	/// <param name="hdc">A handle to the device context from which to enumerate the fonts.</param>
	/// <param name="lpLogfont">
	/// A pointer to a null-terminated string that specifies the family name of the desired fonts. If lpszFamily is <c>NULL</c>,
	/// <c>EnumFontFamilies</c> selects and enumerates one font of each available type family.
	/// </param>
	/// <param name="lpProc">A pointer to the application defined callback function. For information, see EnumFontFamProc.</param>
	/// <param name="lParam">A pointer to application-supplied data. The data is passed to the callback function along with the font information.</param>
	/// <returns>The return value is the last value returned by the callback function. Its meaning is implementation specific.</returns>
	/// <remarks>
	/// <para>
	/// For each font having the typeface name specified by the lpszFamily parameter, the <c>EnumFontFamilies</c> function retrieves
	/// information about that font and passes it to the function pointed to by the lpEnumFontFamProc parameter. The application defined
	/// callback function can process the font information as desired. Enumeration continues until there are no more fonts or the callback
	/// function returns zero.
	/// </para>
	/// <para>
	/// When the graphics mode on the device context is set to GM_ADVANCED using the SetGraphicsMode function and the DEVICE_FONTTYPE flag is
	/// passed to the FontType parameter, this function returns a list of type 1 and OpenType fonts on the system. When the graphics mode is
	/// not set to GM_ADVANCED, this function returns a list of type 1, OpenType, and TrueType fonts on the system.
	/// </para>
	/// <para>
	/// The fonts for many East Asian languages have two typeface names: an English name and a localized name. EnumFonts,
	/// <c>EnumFontFamilies</c>, and EnumFontFamiliesEx return the English typeface name if the system locale does not match the language of
	/// the font.
	/// </para>
	/// <para>Examples</para>
	/// <para>For examples, see Enumerating the Installed Fonts.</para>
	/// </remarks>
	// https://docs.microsoft.com/en-us/windows/win32/api/wingdi/nf-wingdi-enumfontfamiliesa int EnumFontFamiliesA( HDC hdc, LPCSTR
	// lpLogfont, FONTENUMPROCA lpProc, LPARAM lParam );
	[DllImport(Lib.Gdi32, SetLastError = false, CharSet = CharSet.Auto)]
	[PInvokeData("wingdi.h", MSDNShortId = "4960afbb-eeba-4030-ac89-d1ff077bb2f3")]
	public static extern int EnumFontFamilies(HDC hdc, [Optional] string? lpLogfont, EnumFontFamProc lpProc, [Optional] IntPtr lParam);

	/// <summary>
	/// The <c>EnumFontFamiliesEx</c> function enumerates all uniquely-named fonts in the system that match the font characteristics
	/// specified by the LOGFONT structure. <c>EnumFontFamiliesEx</c> enumerates fonts based on typeface name, character set, or both.
	/// </summary>
	/// <param name="hdc">A handle to the device context from which to enumerate the fonts.</param>
	/// <param name="lpLogfont">
	/// <para>
	/// A pointer to a LOGFONT structure that contains information about the fonts to enumerate. The function examines the following members.
	/// </para>
	/// <list type="table">
	/// <listheader>
	/// <term>Member</term>
	/// <term>Description</term>
	/// </listheader>
	/// <item>
	/// <term>lfCharSet</term>
	/// <term>
	/// If set to DEFAULT_CHARSET, the function enumerates all uniquely-named fonts in all character sets. (If there are two fonts with the
	/// same name, only one is enumerated.) If set to a valid character set value, the function enumerates only fonts in the specified
	/// character set.
	/// </term>
	/// </item>
	/// <item>
	/// <term>lfFaceName</term>
	/// <term>
	/// If set to an empty string, the function enumerates one font in each available typeface name. If set to a valid typeface name, the
	/// function enumerates all fonts with the specified name.
	/// </term>
	/// </item>
	/// <item>
	/// <term>lfPitchAndFamily</term>
	/// <term>Must be set to zero for all language versions of the operating system.</term>
	/// </item>
	/// </list>
	/// </param>
	/// <param name="lpProc">A pointer to the application defined callback function. For more information, see the EnumFontFamExProc function.</param>
	/// <param name="lParam">An application defined value. The function passes this value to the callback function along with font information.</param>
	/// <param name="dwFlags">This parameter is not used and must be zero.</param>
	/// <returns>
	/// The return value is the last value returned by the callback function. This value depends on which font families are available for the
	/// specified device.
	/// </returns>
	/// <remarks>
	/// <para>
	/// The <c>EnumFontFamiliesEx</c> function does not use tagged typeface names to identify character sets. Instead, it always passes the
	/// correct typeface name and a separate character set value to the callback function. The function enumerates fonts based on the values
	/// of the <c>lfCharSet</c> and <c>lfFaceName</c> members in the LOGFONT structure.
	/// </para>
	/// <para>
	/// As with EnumFontFamilies, <c>EnumFontFamiliesEx</c> enumerates all font styles. Not all styles of a font cover the same character
	/// sets. For example, Fontorama Bold might contain ANSI, Greek, and Cyrillic characters, but Fontorama Italic might contain only ANSI
	/// characters. For this reason, it's best not to assume that a specified font covers a specific character set, even if it is the ANSI
	/// character set. The following table shows the results of various combinations of values for <c>lfCharSet</c> and <c>lfFaceName</c>.
	/// </para>
	/// <list type="table">
	/// <listheader>
	/// <term>Values</term>
	/// <term>Meaning</term>
	/// </listheader>
	/// <item>
	/// <term>lfCharSet = DEFAULT_CHARSET lfFaceName = '\0'</term>
	/// <term>Enumerates all uniquely-named fonts within all character sets. If there are two fonts with the same name, only one is enumerated.</term>
	/// </item>
	/// <item>
	/// <term>lfCharSet = DEFAULT_CHARSET lfFaceName = a specific font</term>
	/// <term>Enumerates all character sets and styles in a specific font.</term>
	/// </item>
	/// <item>
	/// <term>lfCharSet =a specific character set lfFaceName = '\0'</term>
	/// <term>Enumerates all styles of all fonts in the specific character set.</term>
	/// </item>
	/// <item>
	/// <term>lfCharSet =a specific character set lfFaceName = a specific font</term>
	/// <term>Enumerates all styles of a font in a specific character set.</term>
	/// </item>
	/// </list>
	/// <para>The following code sample shows how these values are used.</para>
	/// <para>
	/// The callback functions for EnumFontFamilies and <c>EnumFontFamiliesEx</c> are very similar. The main difference is that the
	/// ENUMLOGFONTEX structure includes a script field.
	/// </para>
	/// <para>
	/// Note, based on the values of <c>lfCharSet</c> and <c>lfFaceName</c>, <c>EnumFontFamiliesEx</c> will enumerate the same font as many
	/// times as there are distinct character sets in the font. This can create an extensive list of fonts which can be burdensome to a user.
	/// For example, the Century Schoolbook font can appear for the Baltic, Western, Greek, Turkish, and Cyrillic character sets. To avoid
	/// this, an application should filter the list of fonts.
	/// </para>
	/// <para>
	/// The fonts for many East Asian languages have two typeface names: an English name and a localized name. EnumFonts, EnumFontFamilies,
	/// and <c>EnumFontFamiliesEx</c> return the English typeface name if the system locale does not match the language of the font.
	/// </para>
	/// <para>
	/// When the graphics mode on the device context is set to GM_ADVANCED using the SetGraphicsMode function and the DEVICE_FONTTYPE flag is
	/// passed to the FontType parameter, this function returns a list of type 1 and OpenType fonts on the system. When the graphics mode is
	/// not set to GM_ADVANCED, this function returns a list of type 1, OpenType, and TrueType fonts on the system.
	/// </para>
	/// </remarks>
	// https://docs.microsoft.com/en-us/windows/win32/api/wingdi/nf-wingdi-enumfontfamiliesexa int EnumFontFamiliesExA( HDC hdc, LPLOGFONTA
	// lpLogfont, FONTENUMPROCA lpProc, LPARAM lParam, DWORD dwFlags );
	[DllImport(Lib.Gdi32, SetLastError = false, CharSet = CharSet.Auto)]
	[PInvokeData("wingdi.h", MSDNShortId = "4d70906d-8005-4c4a-869e-16dd3e6fa3f2")]
	public static extern int EnumFontFamiliesEx(HDC hdc, in LOGFONT lpLogfont, EnumFontFamExProc lpProc, [Optional] IntPtr lParam, uint dwFlags = 0);

	/// <summary>
	/// The <c>EnumFontFamiliesEx</c> function enumerates all uniquely-named fonts in the system that match the font characteristics
	/// specified by the LOGFONT structure. <c>EnumFontFamiliesEx</c> enumerates fonts based on typeface name, character set, or both.
	/// </summary>
	/// <param name="hdc">A handle to the device context from which to enumerate the fonts.</param>
	/// <param name="lfCharSet">The character set.</param>
	/// <param name="lfFaceName">
	/// A null-terminated string that specifies the typeface name of the font. The length of this string must not exceed 32 TCHAR values,
	/// including the terminating NULL. The EnumFontFamiliesEx function can be used to enumerate the typeface names of all currently
	/// available fonts. If lfFaceName is an empty string, GDI uses the first font that matches the other specified attributes.
	/// </param>
	/// <returns>A sequence of tuples that contain the ENUMLOGFONTEXDV, ENUMTEXTMETRIC and FontType for each font family.</returns>
	[PInvokeData("wingdi.h", MSDNShortId = "4d70906d-8005-4c4a-869e-16dd3e6fa3f2")]
	public static IEnumerable<(ENUMLOGFONTEXDV lpelfe, ENUMTEXTMETRIC lpntme, FontType FontType)> EnumFontFamiliesEx([In, AddAsMember] HDC hdc, CharacterSet lfCharSet = CharacterSet.DEFAULT_CHARSET, string lfFaceName = "")
	{
		LOGFONT lf = new() { lfCharSet = lfCharSet, lfFaceName = lfFaceName };
		List<(ENUMLOGFONTEXDV lpelfe, ENUMTEXTMETRIC lpntme, FontType FontType)> l = [];
		_ = EnumFontFamiliesEx(hdc, lf, (in v, in m, t, _) => { l.Add((v, m, t)); return 1; });
		return l;
	}

	/// <summary>
	/// <para>
	/// The <c>EnumFonts</c> function enumerates the fonts available on a specified device. For each font with the specified typeface name,
	/// the <c>EnumFonts</c> function retrieves information about that font and passes it to the application defined callback function. This
	/// callback function can process the font information as desired. Enumeration continues until there are no more fonts or the callback
	/// function returns zero.
	/// </para>
	/// <para>
	/// <c>Note</c> This function is provided only for compatibility with 16-bit versions of Windows. Applications should use the
	/// EnumFontFamiliesEx function.
	/// </para>
	/// </summary>
	/// <param name="hdc">A handle to the device context from which to enumerate the fonts.</param>
	/// <param name="lpLogfont">
	/// A pointer to a null-terminated string that specifies the typeface name of the desired fonts. If lpFaceName is <c>NULL</c>,
	/// <c>EnumFonts</c> randomly selects and enumerates one font of each available typeface.
	/// </param>
	/// <param name="lpProc">A pointer to the application definedcallback function. For more information, see EnumFontsProc.</param>
	/// <param name="lParam">
	/// A pointer to any application-defined data. The data is passed to the callback function along with the font information.
	/// </param>
	/// <returns>The return value is the last value returned by the callback function. Its meaning is defined by the application.</returns>
	/// <remarks>
	/// <para>
	/// Use EnumFontFamiliesEx instead of <c>EnumFonts</c>. The <c>EnumFontFamiliesEx</c> function differs from the <c>EnumFonts</c> function
	/// in that it retrieves the style names associated with a TrueType font. With <c>EnumFontFamiliesEx</c>, you can retrieve information
	/// about font styles that cannot be enumerated using the <c>EnumFonts</c> function.
	/// </para>
	/// <para>
	/// The fonts for many East Asian languages have two typeface names: an English name and a localized name. <c>EnumFonts</c>,
	/// EnumFontFamilies, and EnumFontFamiliesEx return the English typeface name if the system locale does not match the language of the font.
	/// </para>
	/// </remarks>
	// https://docs.microsoft.com/en-us/windows/win32/api/wingdi/nf-wingdi-enumfontsa int EnumFontsA( HDC hdc, LPCSTR lpLogfont,
	// FONTENUMPROCA lpProc, LPARAM lParam );
	[DllImport(Lib.Gdi32, SetLastError = false, CharSet = CharSet.Auto)]
	[PInvokeData("wingdi.h", MSDNShortId = "b5dfc38d-c400-4900-a15b-f251815ee346")]
	public static extern int EnumFonts([In] HDC hdc, [Optional] string? lpLogfont, EnumFontsProc lpProc, [Optional] IntPtr lParam);

	/// <summary>
	/// The <c>ExtTextOut</c> function draws text using the currently selected font, background color, and text color. You can optionally
	/// provide dimensions to be used for clipping, opaquing, or both.
	/// </summary>
	/// <param name="hdc">A handle to the device context.</param>
	/// <param name="x">The x-coordinate, in logical coordinates, of the reference point used to position the string.</param>
	/// <param name="y">The y-coordinate, in logical coordinates, of the reference point used to position the string.</param>
	/// <param name="options">
	/// <para>Specifies how to use the application-defined rectangle. This parameter can be one or more of the following values.</para>
	/// <list type="table">
	/// <listheader>
	/// <term>Value</term>
	/// <term>Meaning</term>
	/// </listheader>
	/// <item>
	/// <term>ETO_CLIPPED</term>
	/// <term>The text will be clipped to the rectangle.</term>
	/// </item>
	/// <item>
	/// <term>ETO_GLYPH_INDEX</term>
	/// <term>
	/// The lpString array refers to an array returned from GetCharacterPlacement and should be parsed directly by GDI as no further
	/// language-specific processing is required. Glyph indexing only applies to TrueType fonts, but the flag can be used for bitmap and
	/// vector fonts to indicate that no further language processing is necessary and GDI should process the string directly. Note that all
	/// glyph indexes are 16-bit values even though the string is assumed to be an array of 8-bit values for raster fonts. For ExtTextOutW,
	/// the glyph indexes are saved to a metafile. However, to display the correct characters the metafile must be played back using the same
	/// font. For ExtTextOutA, the glyph indexes are not saved.
	/// </term>
	/// </item>
	/// <item>
	/// <term>ETO_IGNORELANGUAGE</term>
	/// <term>
	/// Reserved for system use. If an application sets this flag, it loses international scripting support and in some cases it may display
	/// no text at all.
	/// </term>
	/// </item>
	/// <item>
	/// <term>ETO_NUMERICSLATIN</term>
	/// <term>To display numbers, use European digits.</term>
	/// </item>
	/// <item>
	/// <term>ETO_NUMERICSLOCAL</term>
	/// <term>To display numbers, use digits appropriate to the locale.</term>
	/// </item>
	/// <item>
	/// <term>ETO_OPAQUE</term>
	/// <term>The current background color should be used to fill the rectangle.</term>
	/// </item>
	/// <item>
	/// <term>ETO_PDY</term>
	/// <term>
	/// When this is set, the array pointed to by lpDx contains pairs of values. The first value of each pair is, as usual, the distance
	/// between origins of adjacent character cells, but the second value is the displacement along the vertical direction of the font.
	/// </term>
	/// </item>
	/// <item>
	/// <term>ETO_RTLREADING</term>
	/// <term>
	/// Middle East language edition of Windows: If this value is specified and a Hebrew or Arabic font is selected into the device context,
	/// the string is output using right-to-left reading order. If this value is not specified, the string is output in left-to-right order.
	/// The same effect can be achieved by setting the TA_RTLREADING value in SetTextAlign. This value is preserved for backward compatibility.
	/// </term>
	/// </item>
	/// </list>
	/// <para>
	/// The ETO_GLYPH_INDEX and ETO_RTLREADING values cannot be used together. Because ETO_GLYPH_INDEX implies that all language processing
	/// has been completed, the function ignores the ETO_RTLREADING flag if also specified.
	/// </para>
	/// </param>
	/// <param name="lprect">
	/// A pointer to an optional RECT structure that specifies the dimensions, in logical coordinates, of a rectangle that is used for
	/// clipping, opaquing, or both.
	/// </param>
	/// <param name="lpString">
	/// A pointer to a string that specifies the text to be drawn. The string does not need to be zero-terminated, since cbCount specifies
	/// the length of the string.
	/// </param>
	/// <param name="c">
	/// <para>The length of the string pointed to by lpString.</para>
	/// <para>This value may not exceed 8192.</para>
	/// </param>
	/// <param name="lpDx">
	/// A pointer to an optional array of values that indicate the distance between origins of adjacent character cells. For example, lpDx[i]
	/// logical units separate the origins of character cell i and character cell i + 1.
	/// </param>
	/// <returns>
	/// <para>
	/// If the string is drawn, the return value is nonzero. However, if the ANSI version of <c>ExtTextOut</c> is called with
	/// ETO_GLYPH_INDEX, the function returns <c>TRUE</c> even though the function does nothing.
	/// </para>
	/// <para>If the function fails, the return value is zero.</para>
	/// </returns>
	/// <remarks>
	/// <para>
	/// The current text-alignment settings for the specified device context determine how the reference point is used to position the text.
	/// The text-alignment settings are retrieved by calling the GetTextAlign function. The text-alignment settings are altered by calling
	/// the SetTextAlign function. You can use the following values for text alignment. Only one flag can be chosen from those that affect
	/// horizontal and vertical alignment. In addition, only one of the two flags that alter the current position can be chosen.
	/// </para>
	/// <list type="table">
	/// <listheader>
	/// <term>Term</term>
	/// <term>Description</term>
	/// </listheader>
	/// <item>
	/// <term>TA_BASELINE</term>
	/// <term>The reference point will be on the base line of the text.</term>
	/// </item>
	/// <item>
	/// <term>TA_BOTTOM</term>
	/// <term>The reference point will be on the bottom edge of the bounding rectangle.</term>
	/// </item>
	/// <item>
	/// <term>TA_TOP</term>
	/// <term>The reference point will be on the top edge of the bounding rectangle.</term>
	/// </item>
	/// <item>
	/// <term>TA_CENTER</term>
	/// <term>The reference point will be aligned horizontally with the center of the bounding rectangle.</term>
	/// </item>
	/// <item>
	/// <term>TA_LEFT</term>
	/// <term>The reference point will be on the left edge of the bounding rectangle.</term>
	/// </item>
	/// <item>
	/// <term>TA_RIGHT</term>
	/// <term>The reference point will be on the right edge of the bounding rectangle.</term>
	/// </item>
	/// <item>
	/// <term>TA_NOUPDATECP</term>
	/// <term>The current position is not updated after each text output call. The reference point is passed to the text output function.</term>
	/// </item>
	/// <item>
	/// <term>TA_RTLREADING</term>
	/// <term>
	/// Middle East language edition of Windows: The text is laid out in right to left reading order, as opposed to the default left to right
	/// order. This applies only when the font selected into the device context is either Hebrew or Arabic.
	/// </term>
	/// </item>
	/// <item>
	/// <term>TA_UPDATECP</term>
	/// <term>The current position is updated after each text output call. The current position is used as the reference point.</term>
	/// </item>
	/// </list>
	/// <para>
	/// If the lpDx parameter is <c>NULL</c>, the <c>ExtTextOut</c> function uses the default spacing between characters. The character-cell
	/// origins and the contents of the array pointed to by the lpDx parameter are specified in logical units. A character-cell origin is
	/// defined as the upper-left corner of the character cell.
	/// </para>
	/// <para>
	/// By default, the current position is not used or updated by this function. However, an application can call the SetTextAlign function
	/// with the fMode parameter set to TA_UPDATECP to permit the system to use and update the current position each time the application
	/// calls <c>ExtTextOut</c> for a specified device context. When this flag is set, the system ignores the X and Y parameters on
	/// subsequent <c>ExtTextOut</c> calls.
	/// </para>
	/// <para>
	/// For the ANSI version of <c>ExtTextOut</c>, the lpDx array has the same number of INT values as there are bytes in lpString. For DBCS
	/// characters, you can apportion the dx in the lpDx entries between the lead byte and the trail byte, as long as the sum of the two
	/// bytes adds up to the desired dx. For DBCS characters with the Unicode version of <c>ExtTextOut</c>, each Unicode glyph gets a single
	/// pdx entry.
	/// </para>
	/// <para>
	/// Note, the alpDx values from GetTextExtentExPoint are not the same as the lpDx values for <c>ExtTextOut</c>. To use the alpDx values
	/// in lpDx, you must first process them.
	/// </para>
	/// <para>Examples</para>
	/// <para>For an example, see "Setting Fonts for Menu-Item Text Strings" in Using Menus.</para>
	/// </remarks>
	// https://docs.microsoft.com/en-us/windows/win32/api/wingdi/nf-wingdi-exttextouta BOOL ExtTextOutA( HDC hdc, int x, int y, UINT options,
	// const RECT *lprect, LPCSTR lpString, UINT c, const INT *lpDx );
	[DllImport(Lib.Gdi32, SetLastError = false, CharSet = CharSet.Auto)]
	[PInvokeData("wingdi.h", MSDNShortId = "74f8fcb8-8ad4-47f2-a330-fa56713bdb37")]
	[return: MarshalAs(UnmanagedType.Bool)]
	public static extern bool ExtTextOut([In, AddAsMember] HDC hdc, int x, int y, ETO options, [In, Optional] PRECT? lprect, string lpString, uint c, [In, Optional] int[]? lpDx);

	/// <summary>The <c>GetAspectRatioFilterEx</c> function retrieves the setting for the current aspect-ratio filter.</summary>
	/// <param name="hdc">Handle to a device context.</param>
	/// <param name="lpsize">Pointer to a SIZE structure that receives the current aspect-ratio filter.</param>
	/// <returns>
	/// <para>If the function succeeds, the return value is nonzero.</para>
	/// <para>If the function fails, the return value is zero.</para>
	/// </returns>
	/// <remarks>
	/// <para>The aspect ratio is the ratio formed by the width and height of a pixel on a specified device.</para>
	/// <para>
	/// The system provides a special filter, the aspect-ratio filter, to select fonts that were designed for a particular device. An
	/// application can specify that the system should only retrieve fonts matching the specified aspect ratio by calling the SetMapperFlags function.
	/// </para>
	/// </remarks>
	// https://docs.microsoft.com/en-us/windows/win32/api/wingdi/nf-wingdi-getaspectratiofilterex BOOL GetAspectRatioFilterEx( HDC hdc,
	// LPSIZE lpsize );
	[DllImport(Lib.Gdi32, SetLastError = false, ExactSpelling = true)]
	[PInvokeData("wingdi.h", MSDNShortId = "3f2dd47d-08bf-4848-897f-5ae506fba342")]
	[return: MarshalAs(UnmanagedType.Bool)]
	public static extern bool GetAspectRatioFilterEx([In, AddAsMember] HDC hdc, out SIZE lpsize);

	/// <summary>
	/// The <c>GetCharABCWidths</c> function retrieves the widths, in logical units, of consecutive characters in a specified range from the
	/// current TrueType font. This function succeeds only with TrueType fonts.
	/// </summary>
	/// <param name="hdc">A handle to the device context.</param>
	/// <param name="wFirst">The first character in the group of consecutive characters from the current font.</param>
	/// <param name="wLast">The last character in the group of consecutive characters from the current font.</param>
	/// <param name="lpABC">
	/// A pointer to an array of ABC structures that receives the character widths, in logical units. This array must contain at least as
	/// many <c>ABC</c> structures as there are characters in the range specified by the uFirstChar and uLastChar parameters.
	/// </param>
	/// <returns>
	/// <para>If the function succeeds, the return value is nonzero</para>
	/// <para>If the function fails, the return value is zero.</para>
	/// </returns>
	/// <remarks>
	/// <para>
	/// The TrueType rasterizer provides ABC character spacing after a specific point size has been selected. A spacing is the distance added
	/// to the current position before placing the glyph. B spacing is the width of the black part of the glyph. C spacing is the distance
	/// added to the current position to provide white space to the right of the glyph. The total advanced width is specified by A+B+C.
	/// </para>
	/// <para>
	/// When the <c>GetCharABCWidths</c> function retrieves negative A or C widths for a character, that character includes underhangs or overhangs.
	/// </para>
	/// <para>
	/// To convert the ABC widths to font design units, an application should use the value stored in the <c>otmEMSquare</c> member of a
	/// OUTLINETEXTMETRIC structure. This value can be retrieved by calling the GetOutlineTextMetrics function.
	/// </para>
	/// <para>The ABC widths of the default character are used for characters outside the range of the currently selected font.</para>
	/// <para>To retrieve the widths of characters in non-TrueType fonts, applications should use the GetCharWidth function.</para>
	/// </remarks>
	// https://docs.microsoft.com/en-us/windows/win32/api/wingdi/nf-wingdi-getcharabcwidthsa BOOL GetCharABCWidthsA( HDC hdc, UINT wFirst,
	// UINT wLast, LPABC lpABC );
	[DllImport(Lib.Gdi32, SetLastError = false, CharSet = CharSet.Auto)]
	[PInvokeData("wingdi.h", MSDNShortId = "b48ab66d-ff0a-48d9-b7dd-28610bf69d51")]
	[return: MarshalAs(UnmanagedType.Bool)]
	public static extern bool GetCharABCWidths([In, AddAsMember] HDC hdc, uint wFirst, uint wLast, [In, Out] ABC[] lpABC);

	/// <summary>
	/// The <c>GetCharABCWidthsFloat</c> function retrieves the widths, in logical units, of consecutive characters in a specified range from
	/// the current font.
	/// </summary>
	/// <param name="hdc">Handle to the device context.</param>
	/// <param name="iFirst">
	/// Specifies the code point of the first character in the group of consecutive characters where the ABC widths are seeked.
	/// </param>
	/// <param name="iLast">
	/// Specifies the code point of the last character in the group of consecutive characters where the ABC widths are seeked. This range is
	/// inclusive. An error is returned if the specified last character precedes the specified first character.
	/// </param>
	/// <param name="lpABC">Pointer to an array of ABCFLOAT structures that receives the character widths, in logical units.</param>
	/// <returns>
	/// <para>If the function succeeds, the return value is nonzero.</para>
	/// <para>If the function fails, the return value is zero.</para>
	/// </returns>
	/// <remarks>
	/// <para>
	/// Unlike the GetCharABCWidths function that returns widths only for TrueType fonts, the <c>GetCharABCWidthsFloat</c> function retrieves
	/// widths for any font. The widths returned by this function are in the IEEE floating-point format.
	/// </para>
	/// <para>
	/// If the current world-to-device transformation is not identified, the returned widths may be noninteger values, even if the
	/// corresponding values in the device space are integers.
	/// </para>
	/// <para>
	/// A spacing is the distance added to the current position before placing the glyph. B spacing is the width of the black part of the
	/// glyph. C spacing is the distance added to the current position to provide white space to the right of the glyph. The total advanced
	/// width is specified by A+B+C.
	/// </para>
	/// <para>The ABC spaces are measured along the character base line of the selected font.</para>
	/// <para>The ABC widths of the default character are used for characters outside the range of the currently selected font.</para>
	/// </remarks>
	// https://docs.microsoft.com/en-us/windows/win32/api/wingdi/nf-wingdi-getcharabcwidthsfloata BOOL GetCharABCWidthsFloatA( HDC hdc, UINT
	// iFirst, UINT iLast, LPABCFLOAT lpABC );
	[DllImport(Lib.Gdi32, SetLastError = false, CharSet = CharSet.Auto)]
	[PInvokeData("wingdi.h", MSDNShortId = "552942c9-e2a6-43f9-901f-3aba1e2523e5")]
	[return: MarshalAs(UnmanagedType.Bool)]
	public static extern bool GetCharABCWidthsFloat([In, AddAsMember] HDC hdc, uint iFirst, uint iLast, [In, Out] ABCFLOAT[] lpABC);

	/// <summary>
	/// The <c>GetCharABCWidthsI</c> function retrieves the widths, in logical units, of consecutive glyph indices in a specified range from
	/// the current TrueType font. This function succeeds only with TrueType fonts.
	/// </summary>
	/// <param name="hdc">A handle to the device context.</param>
	/// <param name="giFirst">
	/// The first glyph index in the group of consecutive glyph indices from the current font. This parameter is only used if the pgi
	/// parameter is <c>NULL</c>.
	/// </param>
	/// <param name="cgi">The number of glyph indices.</param>
	/// <param name="pgi">
	/// A pointer to an array that contains glyph indices. If this parameter is <c>NULL</c>, the giFirst parameter is used instead. The cgi
	/// parameter specifies the number of glyph indices in this array.
	/// </param>
	/// <param name="pabc">
	/// A pointer to an array of ABC structures that receives the character widths, in logical units. This array must contain at least as
	/// many <c>ABC</c> structures as there are glyph indices specified by the cgi parameter.
	/// </param>
	/// <returns>
	/// <para>If the function succeeds, the return value is nonzero.</para>
	/// <para>If the function fails, the return value is zero.</para>
	/// </returns>
	/// <remarks>
	/// <para>
	/// The TrueType rasterizer provides ABC character spacing after a specific point size has been selected. A spacing is the distance added
	/// to the current position before placing the glyph. B spacing is the width of the black part of the glyph. C spacing is the distance
	/// added to the current position to provide white space to the right of the glyph. The total advanced width is specified by A+B+C.
	/// </para>
	/// <para>
	/// When the <c>GetCharABCWidthsI</c> function retrieves negative A or C widths for a character, that character includes underhangs or overhangs.
	/// </para>
	/// <para>
	/// To convert the ABC widths to font design units, an application should use the value stored in the <c>otmEMSquare</c> member of a
	/// OUTLINETEXTMETRIC structure. This value can be retrieved by calling the GetOutlineTextMetrics function.
	/// </para>
	/// <para>The ABC widths of the default character are used for characters outside the range of the currently selected font.</para>
	/// <para>To retrieve the widths of glyph indices in non-TrueType fonts, applications should use the GetCharWidthI function.</para>
	/// </remarks>
	// https://docs.microsoft.com/en-us/windows/win32/api/wingdi/nf-wingdi-getcharabcwidthsi BOOL GetCharABCWidthsI( HDC hdc, UINT giFirst,
	// UINT cgi, LPWORD pgi, LPABC pabc );
	[DllImport(Lib.Gdi32, SetLastError = false, ExactSpelling = true)]
	[PInvokeData("wingdi.h", MSDNShortId = "7d1210ee-42b7-4f2e-9e89-fb1543d76290")]
	[return: MarshalAs(UnmanagedType.Bool)]
	public static extern bool GetCharABCWidthsI([In, AddAsMember] HDC hdc, uint giFirst, uint cgi, [In, Optional] ushort[]? pgi, [In, Out] ABC[] pabc);

	/// <summary>
	/// <para>
	/// The <c>GetCharacterPlacement</c> function retrieves information about a character string, such as character widths, caret
	/// positioning, ordering within the string, and glyph rendering. The type of information returned depends on the dwFlags parameter and
	/// is based on the currently selected font in the specified display context. The function copies the information to the specified
	/// GCP_RESULTS structure or to one or more arrays specified by the structure.
	/// </para>
	/// <para>
	/// Although this function was once adequate for working with character strings, a need to work with an increasing number of languages
	/// and scripts has rendered it obsolete. It has been superseded by the functionality of the Uniscribe module. For more information, see Uniscribe.
	/// </para>
	/// <para>
	/// It is recommended that an application use the GetFontLanguageInfo function to determine whether the GCP_DIACRITIC, GCP_DBCS,
	/// GCP_USEKERNING, GCP_LIGATE, GCP_REORDER, GCP_GLYPHSHAPE, and GCP_KASHIDA values are valid for the currently selected font. If not
	/// valid, <c>GetCharacterPlacement</c> ignores the value.
	/// </para>
	/// <para>The GCP_NODIACRITICS value is no longer defined and should not be used.</para>
	/// </summary>
	/// <param name="hdc">A handle to the device context.</param>
	/// <param name="lpString">
	/// A pointer to the character string to process. The string does not need to be zero-terminated, since nCount specifies the length of
	/// the string.
	/// </param>
	/// <param name="nCount">The length of the string pointed to by lpString.</param>
	/// <param name="nMexExtent">
	/// The maximum extent (in logical units) to which the string is processed. Characters that, if processed, would exceed this extent are
	/// ignored. Computations for any required ordering or glyph arrays apply only to the included characters. This parameter is used only if
	/// the GCP_MAXEXTENT value is specified in the dwFlags parameter. As the function processes the input string, each character and its
	/// extent is added to the output, extent, and other arrays only if the total extent has not yet exceeded the maximum. Once the limit is
	/// reached, processing will stop.
	/// </param>
	/// <param name="lpResults">A pointer to a GCP_RESULTS structure that receives the results of the function.</param>
	/// <param name="dwFlags">
	/// <para>Specifies how to process the string into the required arrays. This parameter can be one or more of the following values.</para>
	/// <list type="table">
	/// <listheader>
	/// <term>Value</term>
	/// <term>Meaning</term>
	/// </listheader>
	/// <item>
	/// <term>GCP_CLASSIN</term>
	/// <term>
	/// Specifies that the lpClass array contains preset classifications for characters. The classifications may be the same as on output. If
	/// the particular classification for a character is not known, the corresponding location in the array must be set to zero. for more
	/// information about the classifications, see GCP_RESULTS. This is useful only if GetFontLanguageInfo returned the GCP_REORDER flag.
	/// </term>
	/// </item>
	/// <item>
	/// <term>GCP_DIACRITIC</term>
	/// <term>
	/// Determines how diacritics in the string are handled. If this value is not set, diacritics are treated as zero-width characters. For
	/// example, a Hebrew string may contain diacritics, but you may not want to display them. Use GetFontLanguageInfo to determine whether a
	/// font supports diacritics. If it does, you can use or not use the GCP_DIACRITIC flag in the call to GetCharacterPlacement, depending
	/// on the needs of your application.
	/// </term>
	/// </item>
	/// <item>
	/// <term>GCP_DISPLAYZWG</term>
	/// <term>
	/// For languages that need reordering or different glyph shapes depending on the positions of the characters within a word,
	/// nondisplayable characters often appear in the code page. For example, in the Hebrew code page, there are Left-To-Right and
	/// Right-To-Left markers, to help determine the final positioning of characters within the output strings. Normally these are not
	/// displayed and are removed from the lpGlyphs and lpDx arrays. You can use the GCP_DISPLAYZWG flag to display these characters.
	/// </term>
	/// </item>
	/// <item>
	/// <term>GCP_GLYPHSHAPE</term>
	/// <term>
	/// Specifies that some or all characters in the string are to be displayed using shapes other than the standard shapes defined in the
	/// currently selected font for the current code page. Some languages, such as Arabic, cannot support glyph creation unless this value is
	/// specified. As a general rule, if GetFontLanguageInfo returns this value for a string, this value must be used with GetCharacterPlacement.
	/// </term>
	/// </item>
	/// <item>
	/// <term>GCP_JUSTIFY</term>
	/// <term>
	/// Adjusts the extents in the lpDx array so that the string length is the same as nMaxExtent. GCP_JUSTIFY may only be used in
	/// conjunction with GCP_MAXEXTENT.
	/// </term>
	/// </item>
	/// <item>
	/// <term>GCP_KASHIDA</term>
	/// <term>
	/// Use Kashidas as well as, or instead of, adjusted extents to modify the length of the string so that it is equal to the value
	/// specified by nMaxExtent. In the lpDx array, a Kashida is indicated by a negative justification index. GCP_KASHIDA may be used only in
	/// conjunction with GCP_JUSTIFY and only if the font (and language) support Kashidas. Use GetFontLanguageInfo to determine whether the
	/// current font supports Kashidas. Using Kashidas to justify the string can result in the number of glyphs required being greater than
	/// the number of characters in the input string. Because of this, when Kashidas are used, the application cannot assume that setting the
	/// arrays to be the size of the input string will be sufficient. (The maximum possible will be approximately dxPageWidth/dxAveCharWidth,
	/// where dxPageWidth is the width of the document and dxAveCharWidth is the average character width as returned from a GetTextMetrics
	/// call). Note that just because GetFontLanguageInfo returns the GCP_KASHIDA flag does not mean that it has to be used in the call to
	/// GetCharacterPlacement, just that the option is available.
	/// </term>
	/// </item>
	/// <item>
	/// <term>GCP_LIGATE</term>
	/// <term>
	/// Use ligations wherever characters ligate. A ligation occurs where one glyph is used for two or more characters. For example, the
	/// letters a and e can ligate to ?. For this to be used, however, both the language support and the font must support the required
	/// glyphs (the example will not be processed by default in English). Use GetFontLanguageInfo to determine whether the current font
	/// supports ligation. If it does and a specific maximum is required for the number of characters that will ligate, set the number in the
	/// first element of the lpGlyphs array. If normal ligation is required, set this value to zero. If GCP_LIGATE is not specified, no
	/// ligation will take place. See GCP_RESULTS for more information. If the GCP_REORDER value is usually required for the character set
	/// but is not specified, the output will be meaningless unless the string being passed in is already in visual ordering (that is, the
	/// result that gets put into lpGcpResults-&gt;lpOutString in one call to GetCharacterPlacement is the input string of a second call).
	/// Note that just because GetFontLanguageInfo returns the GCP_LIGATE flag does not mean that it has to be used in the call to
	/// GetCharacterPlacement, just that the option is available.
	/// </term>
	/// </item>
	/// <item>
	/// <term>GCP_MAXEXTENT</term>
	/// <term>
	/// Compute extents of the string only as long as the resulting extent, in logical units, does not exceed the values specified by the
	/// nMaxExtent parameter.
	/// </term>
	/// </item>
	/// <item>
	/// <term>GCP_NEUTRALOVERRIDE</term>
	/// <term>
	/// Certain languages only. Override the normal handling of neutrals and treat them as strong characters that match the strings reading
	/// order. Useful only with the GCP_REORDER flag.
	/// </term>
	/// </item>
	/// <item>
	/// <term>GCP_NUMERICOVERRIDE</term>
	/// <term>
	/// Certain languages only. Override the normal handling of numerics and treat them as strong characters that match the strings reading
	/// order. Useful only with the GCP_REORDER flag.
	/// </term>
	/// </item>
	/// <item>
	/// <term>GCP_NUMERICSLATIN</term>
	/// <term>
	/// Arabic/Thai only. Use standard Latin glyphs for numbers and override the system default. To determine if this option is available in
	/// the language of the font, use GetStringTypeEx to see if the language supports more than one number format.
	/// </term>
	/// </item>
	/// <item>
	/// <term>GCP_NUMERICSLOCAL</term>
	/// <term>
	/// Arabic/Thai only. Use local glyphs for numeric characters and override the system default. To determine if this option is available
	/// in the language of the font, use GetStringTypeEx to see if the language supports more than one number format.
	/// </term>
	/// </item>
	/// <item>
	/// <term>GCP_REORDER</term>
	/// <term>
	/// Reorder the string. Use for languages that are not SBCS and left-to-right reading order. If this value is not specified, the string
	/// is assumed to be in display order already. If this flag is set for Semitic languages and the lpClass array is used, the first two
	/// elements of the array are used to specify the reading order beyond the bounds of the string. GCP_CLASS_PREBOUNDRTL and
	/// GCP_CLASS_PREBOUNDLTR can be used to set the order. If no preset order is required, set the values to zero. These values can be
	/// combined with other values if the GCPCLASSIN flag is set. If the GCP_REORDER value is not specified, the lpString parameter is taken
	/// to be visual ordered for languages where this is used, and the lpOutString and lpOrder fields are ignored. Use GetFontLanguageInfo to
	/// determine whether the current font supports reordering.
	/// </term>
	/// </item>
	/// <item>
	/// <term>GCP_SYMSWAPOFF</term>
	/// <term>
	/// Semitic languages only. Specifies that swappable characters are not reset. For example, in a right-to-left string, the '(' and ')'
	/// are not reversed.
	/// </term>
	/// </item>
	/// <item>
	/// <term>GCP_USEKERNING</term>
	/// <term>
	/// Use kerning pairs in the font (if any) when creating the widths arrays. Use GetFontLanguageInfo to determine whether the current font
	/// supports kerning pairs. Note that just because GetFontLanguageInfo returns the GCP_USEKERNING flag does not mean that it has to be
	/// used in the call to GetCharacterPlacement, just that the option is available. Most TrueType fonts have a kerning table, but you do
	/// not have to use it.
	/// </term>
	/// </item>
	/// </list>
	/// <para>
	/// It is recommended that an application use the GetFontLanguageInfo function to determine whether the GCP_DIACRITIC, GCP_DBCS,
	/// GCP_USEKERNING, GCP_LIGATE, GCP_REORDER, GCP_GLYPHSHAPE, and GCP_KASHIDA values are valid for the currently selected font. If not
	/// valid, <c>GetCharacterPlacement</c> ignores the value.
	/// </para>
	/// <para>The GCP_NODIACRITICS value is no longer defined and should not be used.</para>
	/// </param>
	/// <returns>
	/// <para>
	/// If the function succeeds, the return value is the width and height of the string in logical units. The width is the low-order word
	/// and the height is the high-order word.
	/// </para>
	/// <para>If the function fails, the return value is zero.</para>
	/// </returns>
	/// <remarks>
	/// <para>
	/// <c>GetCharacterPlacement</c> ensures that an application can correctly process text regardless of the international setting and type
	/// of fonts available. Applications use this function before using the ExtTextOut function and in place of the GetTextExtentPoint32
	/// function (and occasionally in place of the GetCharWidth32 and GetCharABCWidths functions).
	/// </para>
	/// <para>
	/// Using <c>GetCharacterPlacement</c> to retrieve intercharacter spacing and index arrays is not always necessary unless justification
	/// or kerning is required. For non-Latin fonts, applications can improve the speed at which the ExtTextOut function renders text by
	/// using <c>GetCharacterPlacement</c> to retrieve the intercharacter spacing and index arrays before calling <c>ExtTextOut</c>. This is
	/// especially useful when rendering the same text repeatedly or when using intercharacter spacing to position the caret. If the
	/// <c>lpGlyphs</c> output array is used in the call to <c>ExtTextOut</c>, the ETO_GLYPH_INDEX flag must be set.
	/// </para>
	/// <para>
	/// <c>GetCharacterPlacement</c> checks the <c>lpOrder</c>, <c>lpDX</c>, <c>lpCaretPos</c>, <c>lpOutString</c>, and <c>lpGlyphs</c>
	/// members of the GCP_RESULTS structure and fills the corresponding arrays if these members are not set to <c>NULL</c>. If
	/// <c>GetCharacterPlacement</c> cannot fill an array, it sets the corresponding member to <c>NULL</c>. To ensure retrieval of valid
	/// information, the application is responsible for setting the member to a valid address before calling the function and for checking
	/// the value of the member after the call. If the GCP_JUSTIFY or GCP_USEKERNING values are specified, the <c>lpDX</c> and/or
	/// <c>lpCaretPos</c> members must have valid addresses.
	/// </para>
	/// <para>
	/// Note that the glyph indexes returned in GCP_RESULTS.lpGlyphs are specific to the current font in the device context and should only
	/// be used to draw text in the device context while that font remains selected.
	/// </para>
	/// <para>
	/// When computing justification, if the trailing characters in the string are spaces, the function reduces the length of the string and
	/// removes the spaces prior to computing the justification. If the array consists of only spaces, the function returns an error.
	/// </para>
	/// <para>
	/// ExtTextOut expects an <c>lpDX</c> entry for each byte of a DBCS string, whereas <c>GetCharacterPlacement</c> assigns an <c>lpDX</c>
	/// entry for each glyph. To correct this mismatch when using this combination of functions, either use GetGlyphIndices or expand the
	/// <c>lpDX</c> array with zero-width entries for the corresponding second byte of a DBCS byte pair.
	/// </para>
	/// <para>
	/// If the logical width is less than the width of the leading character in the input string, GCP_RESULTS.nMaxFit returns a bad value.
	/// For this case, call <c>GetCharacterPlacement</c> for glyph indexes and the <c>lpDX</c> array. Then use the <c>lpDX</c> array to do
	/// the extent calculation using the advance width of each character, where <c>nMaxFit</c> is the number of characters whose glyph
	/// indexes advance width is less than the width of the leading character.
	/// </para>
	/// </remarks>
	// https://docs.microsoft.com/en-us/windows/win32/api/wingdi/nf-wingdi-getcharacterplacementa DWORD GetCharacterPlacementA( HDC hdc,
	// LPCSTR lpString, int nCount, int nMexExtent, LPGCP_RESULTSA lpResults, DWORD dwFlags );
	[DllImport(Lib.Gdi32, SetLastError = false, CharSet = CharSet.Auto)]
	[PInvokeData("wingdi.h", MSDNShortId = "80d3f4b3-503b-4abb-826c-e5c09972ba2f")]
	public static extern uint GetCharacterPlacement([In, AddAsMember] HDC hdc, string lpString, int nCount, int nMexExtent, [In, Out] StructPointer<GCP_RESULTS> lpResults, GCP dwFlags);

	/// <summary>
	/// The <c>GetCharWidth32</c> function retrieves the widths, in logical coordinates, of consecutive characters in a specified range from
	/// the current font.
	/// </summary>
	/// <param name="hdc">A handle to the device context.</param>
	/// <param name="iFirst">The first character in the group of consecutive characters.</param>
	/// <param name="iLast">The last character in the group of consecutive characters, which must not precede the specified first character.</param>
	/// <param name="lpBuffer">A pointer to a buffer that receives the character widths, in logical coordinates.</param>
	/// <returns>
	/// <para>If the function succeeds, the return value is nonzero.</para>
	/// <para>If the function fails, the return value is zero.</para>
	/// </returns>
	/// <remarks>
	/// <para><c>GetCharWidth32</c> cannot be used on TrueType fonts. To retrieve character widths for TrueType fonts, use GetCharABCWidths.</para>
	/// <para>
	/// The range is inclusive; that is, the returned widths include the widths of the characters specified by the iFirstChar and iLastChar parameters.
	/// </para>
	/// <para>If a character does not exist in the current font, it is assigned the width of the default character.</para>
	/// <para>Examples</para>
	/// <para>For an example, see "Displaying Keyboard Input" in Using Keyboard Input.</para>
	/// </remarks>
	// https://docs.microsoft.com/en-us/windows/win32/api/wingdi/nf-wingdi-getcharwidth32a BOOL GetCharWidth32A( HDC hdc, UINT iFirst, UINT
	// iLast, LPINT lpBuffer );
	[DllImport(Lib.Gdi32, SetLastError = false, CharSet = CharSet.Auto)]
	[PInvokeData("wingdi.h", MSDNShortId = "f7d6e9b3-72aa-42d8-8346-b230b9e98237")]
	[return: MarshalAs(UnmanagedType.Bool)]
	public static extern bool GetCharWidth32([In, AddAsMember] HDC hdc, uint iFirst, uint iLast, [Out] int[] lpBuffer);

	/// <summary>
	/// The <c>GetCharWidthFloat</c> function retrieves the fractional widths of consecutive characters in a specified range from the current font.
	/// </summary>
	/// <param name="hdc">A handle to the device context.</param>
	/// <param name="iFirst">The code point of the first character in the group of consecutive characters.</param>
	/// <param name="iLast">The code point of the last character in the group of consecutive characters.</param>
	/// <param name="lpBuffer">A pointer to a buffer that receives the character widths, in logical units.</param>
	/// <returns>
	/// <para>If the function succeeds, the return value is nonzero.</para>
	/// <para>If the function fails, the return value is zero.</para>
	/// </returns>
	/// <remarks>
	/// <para>The returned widths are in the 32-bit IEEE floating-point format. (The widths are measured along the base line of the characters.)</para>
	/// <para>
	/// If the iFirstChar parameter specifies the letter a and the iLastChar parameter specifies the letter z, <c>GetCharWidthFloat</c>
	/// retrieves the widths of all lowercase characters.
	/// </para>
	/// <para>If a character does not exist in the current font, it is assigned the width of the default character.</para>
	/// </remarks>
	// https://docs.microsoft.com/en-us/windows/win32/api/wingdi/nf-wingdi-getcharwidthfloata BOOL GetCharWidthFloatA( HDC hdc, UINT iFirst,
	// UINT iLast, PFLOAT lpBuffer );
	[DllImport(Lib.Gdi32, SetLastError = false, CharSet = CharSet.Auto)]
	[PInvokeData("wingdi.h", MSDNShortId = "7a90b701-63f9-41e5-9069-10d344edfe02")]
	[return: MarshalAs(UnmanagedType.Bool)]
	public static extern bool GetCharWidthFloat([In, AddAsMember] HDC hdc, uint iFirst, uint iLast, [Out] float[] lpBuffer);

	/// <summary>
	/// The <c>GetCharWidthI</c> function retrieves the widths, in logical coordinates, of consecutive glyph indices in a specified range
	/// from the current font.
	/// </summary>
	/// <param name="hdc">A handle to the device context.</param>
	/// <param name="giFirst">The first glyph index in the group of consecutive glyph indices.</param>
	/// <param name="cgi">The number of glyph indices.</param>
	/// <param name="pgi">
	/// A pointer to an array of glyph indices. If this parameter is not <c>NULL</c>, it is used instead of the giFirst parameter.
	/// </param>
	/// <param name="piWidths">A pointer to a buffer that receives the widths, in logical coordinates.</param>
	/// <returns>
	/// <para>If the function succeeds, the return value is nonzero.</para>
	/// <para>If the function fails, the return value is zero.</para>
	/// </returns>
	/// <remarks>
	/// <para>
	/// The <c>GetCharWidthI</c> function processes a consecutive glyph indices if the pgi parameter is <c>NULL</c> with the giFirst
	/// parameter indicating the first glyph index to process and the cgi parameter indicating how many glyph indices to process. Otherwise
	/// the <c>GetCharWidthI</c> function processes the array of glyph indices pointed to by the pgi parameter with the cgi parameter
	/// indicating how many glyph indices to process.
	/// </para>
	/// <para>If a character does not exist in the current font, it is assigned the width of the default character.</para>
	/// </remarks>
	// https://docs.microsoft.com/en-us/windows/win32/api/wingdi/nf-wingdi-getcharwidthi BOOL GetCharWidthI( HDC hdc, UINT giFirst, UINT cgi,
	// LPWORD pgi, LPINT piWidths );
	[DllImport(Lib.Gdi32, SetLastError = false, ExactSpelling = true)]
	[PInvokeData("wingdi.h", MSDNShortId = "5f532149-7c2f-4972-9900-68c2f185d255")]
	[return: MarshalAs(UnmanagedType.Bool)]
	public static extern bool GetCharWidthI([In, AddAsMember] HDC hdc, uint giFirst, uint cgi, [In, Optional, MarshalAs(UnmanagedType.LPArray, SizeParamIndex = 2)] ushort[]? pgi, [Out] int[] piWidths);

	/// <summary>The <c>GetFontData</c> function retrieves font metric data for a TrueType font.</summary>
	/// <param name="hdc">A handle to the device context.</param>
	/// <param name="dwTable">
	/// The name of a font metric table from which the font data is to be retrieved. This parameter can identify one of the metric tables
	/// documented in the TrueType Font Files specification published by Microsoft Corporation. If this parameter is zero, the information is
	/// retrieved starting at the beginning of the file for TrueType font files or from the beginning of the data for the currently selected
	/// font for TrueType Collection files. To retrieve the data from the beginning of the file for TrueType Collection files specify 'ttcf' (0x66637474).
	/// </param>
	/// <param name="dwOffset">
	/// The offset from the beginning of the font metric table to the location where the function should begin retrieving information. If
	/// this parameter is zero, the information is retrieved starting at the beginning of the table specified by the dwTable parameter. If
	/// this value is greater than or equal to the size of the table, an error occurs.
	/// </param>
	/// <param name="pvBuffer">
	/// A pointer to a buffer that receives the font information. If this parameter is <c>NULL</c>, the function returns the size of the
	/// buffer required for the font data.
	/// </param>
	/// <param name="cjBuffer">
	/// The length, in bytes, of the information to be retrieved. If this parameter is zero, <c>GetFontData</c> returns the size of the data
	/// specified in the dwTable parameter.
	/// </param>
	/// <returns>
	/// <para>If the function succeeds, the return value is the number of bytes returned.</para>
	/// <para>If the function fails, the return value is GDI_ERROR.</para>
	/// </returns>
	/// <remarks>
	/// <para>
	/// This function is intended to be used to retrieve TrueType font information directly from the font file by font-manipulation
	/// applications. For information about embedding fonts see the Font Embedding Reference.
	/// </para>
	/// <para>
	/// An application can sometimes use the <c>GetFontData</c> function to save a TrueType font with a document. To do this, the application
	/// determines whether the font can be embedded by checking the <c>otmfsType</c> member of the OUTLINETEXTMETRIC structure. If bit 1 of
	/// <c>otmfsType</c> is set, embedding is not permitted for the font. If bit 1 is clear, the font can be embedded. If bit 2 is set, the
	/// embedding is read-only. If embedding is permitted, the application can retrieve the entire font file, specifying zero for the
	/// dwTable, dwOffset, and cbData parameters.
	/// </para>
	/// <para>If an application attempts to use this function to retrieve information for a non-TrueType font, an error occurs.</para>
	/// </remarks>
	// https://docs.microsoft.com/en-us/windows/win32/api/wingdi/nf-wingdi-getfontdata DWORD GetFontData( HDC hdc, DWORD dwTable, DWORD
	// dwOffset, PVOID pvBuffer, DWORD cjBuffer );
	[DllImport(Lib.Gdi32, SetLastError = false, ExactSpelling = true)]
	[PInvokeData("wingdi.h", MSDNShortId = "ec716ad8-bdc2-4f61-968e-f86288123cec")]
	public static extern uint GetFontData([In, AddAsMember] HDC hdc, [Optional] FOURCC dwTable, [Optional] uint dwOffset,
		[Out, Optional, SizeDef(nameof(cjBuffer), SizingMethod.QueryResultInReturn)] IntPtr pvBuffer, [Optional] uint cjBuffer);

	/// <summary>
	/// The <c>GetFontLanguageInfo</c> function returns information about the currently selected font for the specified display context.
	/// Applications typically use this information and the GetCharacterPlacement function to prepare a character string for display.
	/// </summary>
	/// <param name="hdc">Handle to a display device context.</param>
	/// <returns>
	/// <para>
	/// The return value identifies characteristics of the currently selected font. The function returns 0 if the font is "normalized" and
	/// can be treated as a simple Latin font; it returns GCP_ERROR if an error occurs. Otherwise, the function returns a combination of the
	/// following values.
	/// </para>
	/// <list type="table">
	/// <listheader>
	/// <term>Value</term>
	/// <term>Meaning</term>
	/// </listheader>
	/// <item>
	/// <term>GCP_DBCS</term>
	/// <term>The character set is DBCS.</term>
	/// </item>
	/// <item>
	/// <term>GCP_DIACRITIC</term>
	/// <term>The font/language contains diacritic glyphs.</term>
	/// </item>
	/// <item>
	/// <term>FLI_GLYPHS</term>
	/// <term>
	/// The font contains extra glyphs not normally accessible using the code page. Use GetCharacterPlacement to access the glyphs. This
	/// value is for information only and is not intended to be passed to GetCharacterPlacement.
	/// </term>
	/// </item>
	/// <item>
	/// <term>GCP_GLYPHSHAPE</term>
	/// <term>
	/// The font/language contains multiple glyphs per code point or per code point combination (supports shaping and/or ligation), and the
	/// font contains advanced glyph tables to provide extra glyphs for the extra shapes. If this value is specified, the lpGlyphs array must
	/// be used with the GetCharacterPlacement function and the ETO_GLYPHINDEX value must be passed to the ExtTextOut function when the
	/// string is drawn.
	/// </term>
	/// </item>
	/// <item>
	/// <term>GCP_KASHIDA</term>
	/// <term>The font/ language permits Kashidas.</term>
	/// </item>
	/// <item>
	/// <term>GCP_LIGATE</term>
	/// <term>The font/language contains ligation glyphs which can be substituted for specific character combinations.</term>
	/// </item>
	/// <item>
	/// <term>GCP_USEKERNING</term>
	/// <term>The font contains a kerning table which can be used to provide better spacing between the characters and glyphs.</term>
	/// </item>
	/// <item>
	/// <term>GCP_REORDER</term>
	/// <term>The language requires reordering for displayfor example, Hebrew or Arabic.</term>
	/// </item>
	/// </list>
	/// <para>The return value, when masked with FLI_MASK, can be passed directly to the GetCharacterPlacement function.</para>
	/// </returns>
	// https://docs.microsoft.com/en-us/windows/win32/api/wingdi/nf-wingdi-getfontlanguageinfo DWORD GetFontLanguageInfo( HDC hdc );
	[DllImport(Lib.Gdi32, SetLastError = false, ExactSpelling = true)]
	[PInvokeData("wingdi.h", MSDNShortId = "c2f19423-4410-44dd-83f1-5b858852051d")]
	public static extern GCP GetFontLanguageInfo([In, AddAsMember] HDC hdc);

	/// <summary>
	/// The <c>GetFontUnicodeRanges</c> function returns information about which Unicode characters are supported by a font. The information
	/// is returned as a GLYPHSET structure.
	/// </summary>
	/// <param name="hdc">A handle to the device context.</param>
	/// <param name="lpgs">
	/// A pointer to a GLYPHSET structure that receives the glyph set information. If this parameter is <c>NULL</c>, the function returns the
	/// size of the <c>GLYPHSET</c> structure required to store the information.
	/// </param>
	/// <returns>
	/// <para>
	/// If the function succeeds, it returns number of bytes written to the GLYPHSET structure or, if the lpgs parameter is <c>NULL</c>, it
	/// returns the size of the GLYPHSET structure required to store the information.
	/// </para>
	/// <para>If the function fails, it returns zero. No extended error information is available.</para>
	/// </returns>
	// https://docs.microsoft.com/en-us/windows/win32/api/wingdi/nf-wingdi-getfontunicoderanges DWORD GetFontUnicodeRanges( HDC hdc,
	// LPGLYPHSET lpgs );
	[DllImport(Lib.Gdi32, SetLastError = false, ExactSpelling = true)]
	[PInvokeData("wingdi.h", MSDNShortId = "51b0ab12-c467-4a89-8173-fdc513868aae")]
	public static extern uint GetFontUnicodeRanges([In] HDC hdc, [Out] ManagedStructPointer<GLYPHSET> lpgs);

	/// <summary>
	/// The <c>GetFontUnicodeRanges</c> function returns information about which Unicode characters are supported by a font. The information
	/// is returned as a GLYPHSET structure.
	/// </summary>
	/// <param name="hdc">A handle to the device context.</param>
	/// <returns>A <see cref="GLYPHSET"/> structure with the glyph set information.</returns>
	/// <exception cref="Exception">An unspecified error has occurred.</exception>
	public static GLYPHSET GetFontUnicodeRanges([In, AddAsMember] HDC hdc)
	{
		uint l = GetFontUnicodeRanges(hdc, IntPtr.Zero);
		if (l == 0) throw new Exception();
		using SafeAnysizeStruct<GLYPHSET> mem = new(l, nameof(GLYPHSET.cRanges));
		_ = mem.DangerousGetHandle().Write(l); // Set cbThis
		return 0 == GetFontUnicodeRanges(hdc, mem) ? throw new Exception() : mem.Value;
	}

	/// <summary>
	/// The <c>GetGlyphIndices</c> function translates a string into an array of glyph indices. The function can be used to determine whether
	/// a glyph exists in a font.
	/// </summary>
	/// <param name="hdc">A handle to the device context.</param>
	/// <param name="lpstr">A pointer to the string to be converted.</param>
	/// <param name="c">
	/// The length of both the length of the string pointed to by lpstr and the size (in WORDs) of the buffer pointed to by pgi.
	/// </param>
	/// <param name="pgi">
	/// This buffer must be of dimension c. On successful return, contains an array of glyph indices corresponding to the characters in the string.
	/// </param>
	/// <param name="fl">
	/// <para>Specifies how glyphs should be handled if they are not supported. This parameter can be the following value.</para>
	/// <list type="table">
	/// <listheader>
	/// <term>Value</term>
	/// <term>Meaning</term>
	/// </listheader>
	/// <item>
	/// <term>GGI_MARK_NONEXISTING_GLYPHS</term>
	/// <term>Marks unsupported glyphs with the hexadecimal value 0xffff.</term>
	/// </item>
	/// </list>
	/// </param>
	/// <returns>
	/// <para>If the function succeeds, it returns the number of bytes (for the ANSI function) or WORDs (for the Unicode function) converted.</para>
	/// <para>If the function fails, the return value is GDI_ERROR.</para>
	/// </returns>
	/// <remarks>
	/// This function attempts to identify a single-glyph representation for each character in the string pointed to by lpstr. While this is
	/// useful for certain low-level purposes (such as manipulating font files), higher-level applications that wish to map a string to
	/// glyphs will typically wish to use the Uniscribe functions.
	/// </remarks>
	// https://docs.microsoft.com/en-us/windows/win32/api/wingdi/nf-wingdi-getglyphindicesa DWORD GetGlyphIndicesA( HDC hdc, LPCSTR lpstr,
	// int c, LPWORD pgi, DWORD fl );
	[DllImport(Lib.Gdi32, SetLastError = false, CharSet = CharSet.Auto)]
	[PInvokeData("wingdi.h", MSDNShortId = "7abfee7a-dd5d-4f33-96f1-b38364ba5afd")]
	public static extern uint GetGlyphIndices([In, AddAsMember] HDC hdc, string lpstr, int c, [Out, MarshalAs(UnmanagedType.LPArray)] ushort[] pgi, GGI fl = GGI.GGI_MARK_NONEXISTING_GLYPHS);

	/// <summary>
	/// The <c>GetGlyphOutline</c> function retrieves the outline or bitmap for a character in the TrueType font that is selected into the
	/// specified device context.
	/// </summary>
	/// <param name="hdc">A handle to the device context.</param>
	/// <param name="uChar">The character for which data is to be returned.</param>
	/// <param name="fuFormat">
	/// <para>The format of the data that the function retrieves. This parameter can be one of the following values.</para>
	/// <list type="table">
	/// <listheader>
	/// <term>Value</term>
	/// <term>Meaning</term>
	/// </listheader>
	/// <item>
	/// <term>GGO_BEZIER</term>
	/// <term>The function retrieves the curve data as a cubic Bézier spline (not in quadratic spline format).</term>
	/// </item>
	/// <item>
	/// <term>GGO_BITMAP</term>
	/// <term>The function retrieves the glyph bitmap. For information about memory allocation, see the following Remarks section.</term>
	/// </item>
	/// <item>
	/// <term>GGO_GLYPH_INDEX</term>
	/// <term>
	/// Indicates that the uChar parameter is a TrueType Glyph Index rather than a character code. See the ExtTextOut function for additional
	/// remarks on Glyph Indexing.
	/// </term>
	/// </item>
	/// <item>
	/// <term>GGO_GRAY2_BITMAP</term>
	/// <term>The function retrieves a glyph bitmap that contains five levels of gray.</term>
	/// </item>
	/// <item>
	/// <term>GGO_GRAY4_BITMAP</term>
	/// <term>The function retrieves a glyph bitmap that contains 17 levels of gray.</term>
	/// </item>
	/// <item>
	/// <term>GGO_GRAY8_BITMAP</term>
	/// <term>The function retrieves a glyph bitmap that contains 65 levels of gray.</term>
	/// </item>
	/// <item>
	/// <term>GGO_METRICS</term>
	/// <term>
	/// The function only retrieves the GLYPHMETRICS structure specified by lpgm. The lpvBuffer is ignored. This value affects the meaning of
	/// the function's return value upon failure; see the Return Values section.
	/// </term>
	/// </item>
	/// <item>
	/// <term>GGO_NATIVE</term>
	/// <term>The function retrieves the curve data points in the rasterizer's native format and uses the font's design units.</term>
	/// </item>
	/// <item>
	/// <term>GGO_UNHINTED</term>
	/// <term>The function only returns unhinted outlines. This flag only works in conjunction with GGO_BEZIER and GGO_NATIVE.</term>
	/// </item>
	/// </list>
	/// <para>
	/// Note that, for the GGO_GRAYn_BITMAP values, the function retrieves a glyph bitmap that contains n^2+1 (n squared plus one) levels of gray.
	/// </para>
	/// </param>
	/// <param name="lpgm">A pointer to the GLYPHMETRICS structure describing the placement of the glyph in the character cell.</param>
	/// <param name="cjBuffer">
	/// The size, in bytes, of the buffer (*lpvBuffer) where the function is to copy information about the outline character. If this value
	/// is zero, the function returns the required size of the buffer.
	/// </param>
	/// <param name="pvBuffer">
	/// A pointer to the buffer that receives information about the outline character. If this value is <c>NULL</c>, the function returns the
	/// required size of the buffer.
	/// </param>
	/// <param name="lpmat2">A pointer to a MAT2 structure specifying a transformation matrix for the character.</param>
	/// <returns>
	/// <para>
	/// If GGO_BITMAP, GGO_GRAY2_BITMAP, GGO_GRAY4_BITMAP, GGO_GRAY8_BITMAP, or GGO_NATIVE is specified and the function succeeds, the return
	/// value is greater than zero; otherwise, the return value is GDI_ERROR. If one of these flags is specified and the buffer size or
	/// address is zero, the return value specifies the required buffer size, in bytes.
	/// </para>
	/// <para>If GGO_METRICS is specified and the function fails, the return value is GDI_ERROR.</para>
	/// </returns>
	/// <remarks>
	/// <para>
	/// The glyph outline returned by the <c>GetGlyphOutline</c> function is for a grid-fitted glyph. (A grid-fitted glyph is a glyph that
	/// has been modified so that its bitmapped image conforms as closely as possible to the original design of the glyph.) If an application
	/// needs an unmodified glyph outline, it can request the glyph outline for a character in a font whose size is equal to the font's em
	/// unit. The value for a font's em unit is stored in the <c>otmEMSquare</c> member of the OUTLINETEXTMETRIC structure.
	/// </para>
	/// <para>
	/// The glyph bitmap returned by <c>GetGlyphOutline</c> when GGO_BITMAP is specified is a DWORD-aligned, row-oriented, monochrome bitmap.
	/// When GGO_GRAY2_BITMAP is specified, the bitmap returned is a DWORD-aligned, row-oriented array of bytes whose values range from 0 to
	/// 4. When GGO_GRAY4_BITMAP is specified, the bitmap returned is a DWORD-aligned, row-oriented array of bytes whose values range from 0
	/// to 16. When GGO_GRAY8_BITMAP is specified, the bitmap returned is a DWORD-aligned, row-oriented array of bytes whose values range
	/// from 0 to 64.
	/// </para>
	/// <para>
	/// The native buffer returned by <c>GetGlyphOutline</c> when GGO_NATIVE is specified is a glyph outline. A glyph outline is returned as
	/// a series of one or more contours defined by a <see cref="TTPOLYGONHEADER"/> structure followed by one or more curves. Each curve in
	/// the contour is defined by a <see cref="TTPOLYCURVE"/> structure followed by a number of <see cref="POINTFX"/> data points.
	/// <c>POINTFX</c> points are absolute positions, not relative moves. The starting point of a contour is given by the <c>pfxStart</c>
	/// member of the <c>TTPOLYGONHEADER</c> structure. The starting point of each curve is the last point of the previous curve or the
	/// starting point of the contour. The count of data points in a curve is stored in the <c>cpfx</c> member of <c>TTPOLYCURVE</c>
	/// structure. The size of each contour in the buffer, in bytes, is stored in the <c>cb</c> member of <c>TTPOLYGONHEADER</c> structure.
	/// Additional curve definitions are packed into the buffer following preceding curves and additional contours are packed into the buffer
	/// following preceding contours. The buffer contains as many contours as fit within the buffer returned by <c>GetGlyphOutline</c>.
	/// </para>
	/// <para>
	/// The <see cref="GLYPHMETRICS"/> structure specifies the width of the character cell and the location of a glyph within the character
	/// cell. The origin of the character cell is located at the left side of the cell at the baseline of the font. The location of the glyph
	/// origin is relative to the character cell origin. The height of a character cell, the baseline, and other metrics global to the font
	/// are given by the <see cref="OUTLINETEXTMETRIC"/> structure.
	/// </para>
	/// <para>
	/// An application can alter the characters retrieved in bitmap or native format by specifying a 2-by-2 transformation matrix in the
	/// lpMatrix parameter. For example the glyph can be modified by shear, rotation, scaling, or any combination of the three using matrix multiplication.
	/// </para>
	/// <para>Additional information on a glyph outlines is located in the TrueType and the OpenType technical specifications.</para>
	/// </remarks>
	// https://docs.microsoft.com/en-us/windows/win32/api/wingdi/nf-wingdi-getglyphoutlinea DWORD GetGlyphOutlineA( HDC hdc, UINT uChar, UINT
	// fuFormat, LPGLYPHMETRICS lpgm, DWORD cjBuffer, LPVOID pvBuffer, const MAT2 *lpmat2 );
	[DllImport(Lib.Gdi32, SetLastError = false, CharSet = CharSet.Auto)]
	[PInvokeData("wingdi.h", MSDNShortId = "08f06007-5b21-44ab-b234-21a58c94ed4e")]
	public static extern uint GetGlyphOutline([In, AddAsMember] HDC hdc, uint uChar, GGO fuFormat, out GLYPHMETRICS lpgm, uint cjBuffer, [SizeDef(nameof(cjBuffer), SizingMethod.QueryResultInReturn)] IntPtr pvBuffer, in MAT2 lpmat2);

	/// <summary>
	/// The <c>GetKerningPairs</c> function retrieves the character-kerning pairs for the currently selected font for the specified device context.
	/// </summary>
	/// <param name="hdc">A handle to the device context.</param>
	/// <param name="nPairs">
	/// The number of pairs in the lpkrnpair array. If the font has more than nNumPairs kerning pairs, the function returns an error.
	/// </param>
	/// <param name="lpKernPair">
	/// A pointer to an array of KERNINGPAIR structures that receives the kerning pairs. The array must contain at least as many structures
	/// as specified by the nNumPairs parameter. If this parameter is <c>NULL</c>, the function returns the total number of kerning pairs for
	/// the font.
	/// </param>
	/// <returns>
	/// <para>If the function succeeds, the return value is the number of kerning pairs returned.</para>
	/// <para>If the function fails, the return value is zero.</para>
	/// </returns>
	// https://docs.microsoft.com/en-us/windows/win32/api/wingdi/nf-wingdi-getkerningpairsa DWORD GetKerningPairsA( HDC hdc, DWORD nPairs,
	// LPKERNINGPAIR lpKernPair );
	[DllImport(Lib.Gdi32, SetLastError = false, CharSet = CharSet.Auto)]
	[PInvokeData("wingdi.h", MSDNShortId = "9aba629f-afab-4ef3-8e1d-d0b90e122e94")]
	public static extern uint GetKerningPairs([In, AddAsMember] HDC hdc, uint nPairs, [Out, SizeDef(nameof(nPairs), SizingMethod.QueryResultInReturn)] KERNINGPAIR[] lpKernPair);

	/// <summary>The <c>GetOutlineTextMetrics</c> function retrieves text metrics for TrueType fonts.</summary>
	/// <param name="hdc">A handle to the device context.</param>
	/// <param name="potm">
	/// A pointer to an <see cref="OUTLINETEXTMETRIC"/> structure. If this parameter is <c>NULL</c>, the function returns the size of the
	/// buffer required for the retrieved metric data.
	/// </param>
	/// <returns>
	/// <para>If the function succeeds, the return value is nonzero or the size of the required buffer.</para>
	/// <para>If the function fails, the return value is zero.</para>
	/// </returns>
	/// <remarks>
	/// The OUTLINETEXTMETRIC structure contains most of the text metric information provided for TrueType fonts (including a TEXTMETRIC
	/// structure). The sizes returned in <c>OUTLINETEXTMETRIC</c> are in logical units; they depend on the current mapping mode.
	/// </remarks>
	// https://docs.microsoft.com/en-us/windows/win32/api/wingdi/nf-wingdi-getoutlinetextmetricsa UINT GetOutlineTextMetricsA( HDC hdc, UINT
	// cjCopy, LPOUTLINETEXTMETRICA potm );
	[PInvokeData("wingdi.h", MSDNShortId = "b8c7a557-ca35-41a4-9043-8496e5b01564")]
	public static uint GetOutlineTextMetrics([In, AddAsMember] HDC hdc, out SafeCoTaskMemStruct<OUTLINETEXTMETRIC> potm)
	{
		uint ret = GetOutlineTextMetrics(hdc);
		potm = new(ret);
		ret = GetOutlineTextMetrics(hdc, potm.Size, potm);
		return ret;

		[DllImport(Lib.Gdi32, SetLastError = false, CharSet = CharSet.Auto)]
		static extern uint GetOutlineTextMetrics([In] HDC hdc, [Optional] uint cjCopy, [Out, Optional] ManagedStructPointer<OUTLINETEXTMETRIC> potm);
	}

	/// <summary>The <c>GetRasterizerCaps</c> function returns flags indicating whether TrueType fonts are installed in the system.</summary>
	/// <param name="lpraststat">A pointer to a RASTERIZER_STATUS structure that receives information about the rasterizer.</param>
	/// <param name="cjBytes">The number of bytes to be copied into the structure pointed to by the lprs parameter.</param>
	/// <returns>
	/// <para>If the function succeeds, the return value is nonzero.</para>
	/// <para>If the function fails, the return value is zero.</para>
	/// </returns>
	/// <remarks>
	/// <para>The <c>GetRasterizerCaps</c> function enables applications and printer drivers to determine whether TrueType fonts are installed.</para>
	/// <para>
	/// If the TT_AVAILABLE flag is set in the <c>wFlags</c> member of the RASTERIZER_STATUS structure, at least one TrueType font is
	/// installed. If the TT_ENABLED flag is set, TrueType is enabled for the system.
	/// </para>
	/// <para>
	/// The actual number of bytes copied is either the member specified in the cb parameter or the length of the RASTERIZER_STATUS
	/// structure, whichever is less.
	/// </para>
	/// </remarks>
	// https://docs.microsoft.com/en-us/windows/win32/api/wingdi/nf-wingdi-getrasterizercaps BOOL GetRasterizerCaps( LPRASTERIZER_STATUS
	// lpraststat, UINT cjBytes );
	[DllImport(Lib.Gdi32, SetLastError = false, ExactSpelling = true)]
	[PInvokeData("wingdi.h", MSDNShortId = "0898d1c0-5480-4bd2-aa45-918340172a05")]
	[return: MarshalAs(UnmanagedType.Bool)]
	public static extern bool GetRasterizerCaps(out RASTERIZER_STATUS lpraststat, uint cjBytes = 6);

	/// <summary>The <c>GetTextAlign</c> function retrieves the text-alignment setting for the specified device context.</summary>
	/// <param name="hdc">A handle to the device context.</param>
	/// <returns>
	/// <para>
	/// If the function succeeds, the return value is the status of the text-alignment flags. For more information about the return value,
	/// see the Remarks section. The return value is a combination of the following values.
	/// </para>
	/// <list type="table">
	/// <listheader>
	/// <term>Value</term>
	/// <term>Meaning</term>
	/// </listheader>
	/// <item>
	/// <term>TA_BASELINE</term>
	/// <term>The reference point is on the base line of the text.</term>
	/// </item>
	/// <item>
	/// <term>TA_BOTTOM</term>
	/// <term>The reference point is on the bottom edge of the bounding rectangle.</term>
	/// </item>
	/// <item>
	/// <term>TA_TOP</term>
	/// <term>The reference point is on the top edge of the bounding rectangle.</term>
	/// </item>
	/// <item>
	/// <term>TA_CENTER</term>
	/// <term>The reference point is aligned horizontally with the center of the bounding rectangle.</term>
	/// </item>
	/// <item>
	/// <term>TA_LEFT</term>
	/// <term>The reference point is on the left edge of the bounding rectangle.</term>
	/// </item>
	/// <item>
	/// <term>TA_RIGHT</term>
	/// <term>The reference point is on the right edge of the bounding rectangle.</term>
	/// </item>
	/// <item>
	/// <term>TA_RTLREADING</term>
	/// <term>
	/// Middle East language edition of Windows: The text is laid out in right to left reading order, as opposed to the default left to right
	/// order. This only applies when the font selected into the device context is either Hebrew or Arabic.
	/// </term>
	/// </item>
	/// <item>
	/// <term>TA_NOUPDATECP</term>
	/// <term>The current position is not updated after each text output call.</term>
	/// </item>
	/// <item>
	/// <term>TA_UPDATECP</term>
	/// <term>The current position is updated after each text output call.</term>
	/// </item>
	/// </list>
	/// <para>
	/// When the current font has a vertical default base line (as with Kanji), the following values are used instead of TA_BASELINE and TA_CENTER.
	/// </para>
	/// <list type="table">
	/// <listheader>
	/// <term>Value</term>
	/// <term>Meaning</term>
	/// </listheader>
	/// <item>
	/// <term>VTA_BASELINE</term>
	/// <term>The reference point is on the base line of the text.</term>
	/// </item>
	/// <item>
	/// <term>VTA_CENTER</term>
	/// <term>The reference point is aligned vertically with the center of the bounding rectangle.</term>
	/// </item>
	/// </list>
	/// <para>If the function fails, the return value is GDI_ERROR.</para>
	/// </returns>
	/// <remarks>
	/// <para>
	/// The bounding rectangle is a rectangle bounding all of the character cells in a string of text. Its dimensions can be obtained by
	/// calling the GetTextExtentPoint32 function.
	/// </para>
	/// <para>
	/// The text-alignment flags determine how the TextOut and ExtTextOut functions align a string of text in relation to the string's
	/// reference point provided to <c>TextOut</c> or <c>ExtTextOut</c>.
	/// </para>
	/// <para>
	/// The text-alignment flags are not necessarily single bit flags and may be equal to zero. The flags must be examined in groups of
	/// related flags, as shown in the following list.
	/// </para>
	/// <list type="bullet">
	/// <item>
	/// <term>TA_LEFT, TA_RIGHT, and TA_CENTER</term>
	/// </item>
	/// <item>
	/// <term>TA_BOTTOM, TA_TOP, and TA_BASELINE</term>
	/// </item>
	/// <item>
	/// <term>TA_NOUPDATECP and TA_UPDATECP</term>
	/// </item>
	/// </list>
	/// <para>If the current font has a vertical default base line, the related flags are as shown in the following list.</para>
	/// <list type="bullet">
	/// <item>
	/// <term>TA_LEFT, TA_RIGHT, and VTA_BASELINE</term>
	/// </item>
	/// <item>
	/// <term>TA_BOTTOM, TA_TOP, and VTA_CENTER</term>
	/// </item>
	/// <item>
	/// <term>TA_NOUPDATECP and TA_UPDATECP</term>
	/// </item>
	/// </list>
	/// <para><c>To verify that a particular flag is set in the return value of this function:</c></para>
	/// <list type="number">
	/// <item>
	/// <term>Apply the bitwise OR operator to the flag and its related flags.</term>
	/// </item>
	/// <item>
	/// <term>Apply the bitwise AND operator to the result and the return value.</term>
	/// </item>
	/// <item>
	/// <term>Test for the equality of this result and the flag.</term>
	/// </item>
	/// </list>
	/// <para>Examples</para>
	/// <para>For an example, see Setting the Text Alignment.</para>
	/// </remarks>
	// https://docs.microsoft.com/en-us/windows/win32/api/wingdi/nf-wingdi-gettextalign UINT GetTextAlign( HDC hdc );
	[DllImport(Lib.Gdi32, SetLastError = false, ExactSpelling = true)]
	[PInvokeData("wingdi.h", MSDNShortId = "d3ec0350-2eb8-4843-88bb-d72cece710e7")]
	public static extern TextAlign GetTextAlign([In, AddAsMember] HDC hdc);

	/// <summary>The <c>GetTextCharacterExtra</c> function retrieves the current intercharacter spacing for the specified device context.</summary>
	/// <param name="hdc">Handle to the device context.</param>
	/// <returns>
	/// <para>If the function succeeds, the return value is the current intercharacter spacing, in logical coordinates.</para>
	/// <para>If the function fails, the return value is 0x8000000.</para>
	/// </returns>
	/// <remarks>
	/// The intercharacter spacing defines the extra space, in logical units along the base line, that the TextOut or ExtTextOut functions
	/// add to each character as a line is written. The spacing is used to expand lines of text.
	/// </remarks>
	// https://docs.microsoft.com/en-us/windows/win32/api/wingdi/nf-wingdi-gettextcharacterextra int GetTextCharacterExtra( HDC hdc );
	[DllImport(Lib.Gdi32, SetLastError = false, ExactSpelling = true)]
	[PInvokeData("wingdi.h", MSDNShortId = "44d5145d-1c42-429e-89c4-dc31d275bc73")]
	public static extern int GetTextCharacterExtra([In, AddAsMember] HDC hdc);

	/// <summary>The <c>GetTextColor</c> function retrieves the current text color for the specified device context.</summary>
	/// <param name="hdc">Handle to the device context.</param>
	/// <returns>
	/// <para>If the function succeeds, the return value is the current text color as a COLORREF value.</para>
	/// <para>If the function fails, the return value is CLR_INVALID. No extended error information is available.</para>
	/// </returns>
	/// <remarks>The text color defines the foreground color of characters drawn by using the TextOut or ExtTextOut function.</remarks>
	// https://docs.microsoft.com/en-us/windows/win32/api/wingdi/nf-wingdi-gettextcolor COLORREF GetTextColor( HDC hdc );
	[DllImport(Lib.Gdi32, SetLastError = false, ExactSpelling = true)]
	[PInvokeData("wingdi.h", MSDNShortId = "d3d91b86-5143-431a-ba18-b951b832d7b6")]
	public static extern COLORREF GetTextColor([In, AddAsMember] HDC hdc);

	/// <summary>
	/// The <c>GetTextExtentExPoint</c> function retrieves the number of characters in a specified string that will fit within a specified
	/// space and fills an array with the text extent for each of those characters. (A text extent is the distance between the beginning of
	/// the space and a character that will fit in the space.) This information is useful for word-wrapping calculations.
	/// </summary>
	/// <param name="hdc">A handle to the device context.</param>
	/// <param name="lpszString">A pointer to the null-terminated string for which extents are to be retrieved.</param>
	/// <param name="cchString">
	/// The number of characters in the string pointed to by the lpszStr parameter. For an ANSI call it specifies the string length in bytes
	/// and for a Unicode it specifies the string length in WORDs. Note that for the ANSI function, characters in SBCS code pages take one
	/// byte each, while most characters in DBCS code pages take two bytes; for the Unicode function, most currently defined Unicode
	/// characters (those in the Basic Multilingual Plane (BMP)) are one WORD while Unicode surrogates are two WORDs.
	/// </param>
	/// <param name="nMaxExtent">The maximum allowable width, in logical units, of the formatted string.</param>
	/// <param name="lpnFit">
	/// A pointer to an integer that receives a count of the maximum number of characters that will fit in the space specified by the
	/// nMaxExtent parameter. When the lpnFit parameter is <c>NULL</c>, the nMaxExtent parameter is ignored.
	/// </param>
	/// <param name="lpnDx">
	/// <para>
	/// A pointer to an array of integers that receives partial string extents. Each element in the array gives the distance, in logical
	/// units, between the beginning of the string and one of the characters that fits in the space specified by the nMaxExtent parameter.
	/// This array must have at least as many elements as characters specified by the cchString parameter because the entire array is used
	/// internally. The function fills the array with valid extents for as many characters as are specified by the lpnFit parameter. Any
	/// values in the rest of the array should be ignored. If alpDx is <c>NULL</c>, the function does not compute partial string widths.
	/// </para>
	/// <para>
	/// For complex scripts, where a sequence of characters may be represented by any number of glyphs, the values in the alpDx array up to
	/// the number specified by the lpnFit parameter match one-to-one with code points. Again, you should ignore the rest of the values in
	/// the alpDx array.
	/// </para>
	/// </param>
	/// <param name="lpSize">
	/// A pointer to a SIZE structure that receives the dimensions of the string, in logical units. This parameter cannot be <c>NULL</c>.
	/// </param>
	/// <returns>
	/// <para>If the function succeeds, the return value is nonzero.</para>
	/// <para>If the function fails, the return value is zero.</para>
	/// </returns>
	/// <remarks>
	/// <para>
	/// If both the lpnFit and alpDx parameters are <c>NULL</c>, calling the <c>GetTextExtentExPoint</c> function is equivalent to calling
	/// the GetTextExtentPoint function.
	/// </para>
	/// <para>
	/// For the ANSI version of <c>GetTextExtentExPoint</c>, the lpDx array has the same number of INT values as there are bytes in lpString.
	/// The INT values that correspond to the two bytes of a DBCS character are each the extent of the entire composite character.
	/// </para>
	/// <para>
	/// Note, the alpDx values for <c>GetTextExtentExPoint</c> are not the same as the lpDx values for ExtTextOut. To use the alpDx values in
	/// lpDx, you must first process them.
	/// </para>
	/// <para>
	/// When this function returns the text extent, it assumes that the text is horizontal, that is, that the escapement is always 0. This is
	/// true for both the horizontal and vertical measurements of the text. Even if you use a font that specifies a nonzero escapement, this
	/// function doesn't use the angle while it computes the text extent. The app must convert it explicitly. However, when the graphics mode
	/// is set to GM_ADVANCED and the character orientation is 90 degrees from the print orientation, the values that this function return do
	/// not follow this rule. When the character orientation and the print orientation match for a given string, this function returns the
	/// dimensions of the string in the SIZE structure as { cx : 116, cy : 18 }. When the character orientation and the print orientation are
	/// 90 degrees apart for the same string, this function returns the dimensions of the string in the <c>SIZE</c> structure as { cx : 18,
	/// cy : 116 }.
	/// </para>
	/// <para>
	/// This function returns the extent of each successive character in a string. When these are rounded to logical units, you get different
	/// results than what is returned from the GetCharWidth, which returns the width of each individual character rounded to logical units.
	/// </para>
	/// </remarks>
	// https://docs.microsoft.com/en-us/windows/win32/api/wingdi/nf-wingdi-gettextextentexpointa BOOL GetTextExtentExPointA( HDC hdc, LPCSTR
	// lpszString, int cchString, int nMaxExtent, LPINT lpnFit, LPINT lpnDx, LPSIZE lpSize );
	[DllImport(Lib.Gdi32, SetLastError = false, CharSet = CharSet.Auto)]
	[PInvokeData("wingdi.h", MSDNShortId = "b873a059-5aa3-47d0-b109-7acd542c7d79")]
	[return: MarshalAs(UnmanagedType.Bool)]
	public static extern bool GetTextExtentExPoint([In, AddAsMember] HDC hdc, string lpszString, int cchString, int nMaxExtent, out int lpnFit, [Out] int[]? lpnDx, out SIZE lpSize);

	/// <summary>
	/// The <c>GetTextExtentExPointI</c> function retrieves the number of characters in a specified string that will fit within a specified
	/// space and fills an array with the text extent for each of those characters. (A text extent is the distance between the beginning of
	/// the space and a character that will fit in the space.) This information is useful for word-wrapping calculations.
	/// </summary>
	/// <param name="hdc">A handle to the device context.</param>
	/// <param name="lpwszString">A pointer to an array of glyph indices for which extents are to be retrieved.</param>
	/// <param name="cwchString">The number of glyphs in the array pointed to by the pgiIn parameter.</param>
	/// <param name="nMaxExtent">The maximum allowable width, in logical units, of the formatted string.</param>
	/// <param name="lpnFit">
	/// A pointer to an integer that receives a count of the maximum number of characters that will fit in the space specified by the
	/// nMaxExtent parameter. When the lpnFit parameter is <c>NULL</c>, the nMaxExtent parameter is ignored.
	/// </param>
	/// <param name="lpnDx">
	/// A pointer to an array of integers that receives partial glyph extents. Each element in the array gives the distance, in logical
	/// units, between the beginning of the glyph indices array and one of the glyphs that fits in the space specified by the nMaxExtent
	/// parameter. Although this array should have at least as many elements as glyph indices specified by the cgi parameter, the function
	/// fills the array with extents only for as many glyph indices as are specified by the lpnFit parameter. If lpnFit is <c>NULL</c>, the
	/// function does not compute partial string widths.
	/// </param>
	/// <param name="lpSize">
	/// A pointer to a SIZE structure that receives the dimensions of the glyph indices array, in logical units. This value cannot be <c>NULL</c>.
	/// </param>
	/// <returns>
	/// <para>If the function succeeds, the return value is nonzero.</para>
	/// <para>If the function fails, the return value is zero.</para>
	/// </returns>
	/// <remarks>
	/// <para>
	/// If both the lpnFit and alpDx parameters are <c>NULL</c>, calling the <c>GetTextExtentExPointI</c> function is equivalent to calling
	/// the GetTextExtentPointI function.
	/// </para>
	/// <para>
	/// When this function returns the text extent, it assumes that the text is horizontal, that is, that the escapement is always 0. This is
	/// true for both the horizontal and vertical measurements of the text. Even if you use a font that specifies a nonzero escapement, this
	/// function doesn't use the angle while it computes the text extent. The app must convert it explicitly. However, when the graphics mode
	/// is set to GM_ADVANCED and the character orientation is 90 degrees from the print orientation, the values that this function return do
	/// not follow this rule. When the character orientation and the print orientation match for a given string, this function returns the
	/// dimensions of the string in the SIZE structure as { cx : 116, cy : 18 }. When the character orientation and the print orientation are
	/// 90 degrees apart for the same string, this function returns the dimensions of the string in the <c>SIZE</c> structure as { cx : 18,
	/// cy : 116 }.
	/// </para>
	/// </remarks>
	// https://docs.microsoft.com/en-us/windows/win32/api/wingdi/nf-wingdi-gettextextentexpointi BOOL GetTextExtentExPointI( HDC hdc, LPWORD
	// lpwszString, int cwchString, int nMaxExtent, LPINT lpnFit, LPINT lpnDx, LPSIZE lpSize );
	[DllImport(Lib.Gdi32, SetLastError = false, ExactSpelling = true)]
	[PInvokeData("wingdi.h", MSDNShortId = "d543ec43-f6f1-4463-b27d-a1abf1cf3961")]
	[return: MarshalAs(UnmanagedType.Bool)]
	public static extern bool GetTextExtentExPointI([In, AddAsMember] HDC hdc, [In, MarshalAs(UnmanagedType.LPArray, SizeParamIndex = 2)] ushort[] lpwszString, int cwchString,
		int nMaxExtent, out int lpnFit, [Out, MarshalAs(UnmanagedType.LPArray, SizeParamIndex = 2)] int[]? lpnDx, out SIZE lpSize);

	/// <summary>
	/// <para>The <c>GetTextExtentPoint</c> function computes the width and height of the specified string of text.</para>
	/// <para>
	/// <c>Note</c> This function is provided only for compatibility with 16-bit versions of Windows. Applications should call the
	/// GetTextExtentPoint32 function, which provides more accurate results.
	/// </para>
	/// </summary>
	/// <param name="hdc">A handle to the device context.</param>
	/// <param name="lpString">
	/// A pointer to the string that specifies the text. The string does not need to be zero-terminated, since cbString specifies the length
	/// of the string.
	/// </param>
	/// <param name="c">The length of the string pointed to by lpString.</param>
	/// <param name="lpsz">A pointer to a SIZE structure that receives the dimensions of the string, in logical units.</param>
	/// <returns>
	/// <para>If the function succeeds, the return value is nonzero.</para>
	/// <para>If the function fails, the return value is zero.</para>
	/// </returns>
	/// <remarks>
	/// <para>
	/// The <c>GetTextExtentPoint</c> function uses the currently selected font to compute the dimensions of the string. The width and
	/// height, in logical units, are computed without considering any clipping. Also, this function assumes that the text is horizontal,
	/// that is, that the escapement is always 0. This is true for both the horizontal and vertical measurements of the text. Even if using a
	/// font specifying a nonzero escapement, this function will not use the angle while computing the text extent. The application must
	/// convert it explicitly.
	/// </para>
	/// <para>
	/// Because some devices kern characters, the sum of the extents of the characters in a string may not be equal to the extent of the string.
	/// </para>
	/// <para>The calculated string width takes into account the intercharacter spacing set by the SetTextCharacterExtra function.</para>
	/// </remarks>
	// https://docs.microsoft.com/en-us/windows/win32/api/wingdi/nf-wingdi-gettextextentpointa BOOL GetTextExtentPointA( HDC hdc, LPCSTR
	// lpString, int c, LPSIZE lpsz );
	[DllImport(Lib.Gdi32, SetLastError = false, CharSet = CharSet.Auto)]
	[PInvokeData("wingdi.h", MSDNShortId = "731085ce-009d-42e1-885f-2f5151e0f6d3")]
	[return: MarshalAs(UnmanagedType.Bool)]
	public static extern bool GetTextExtentPoint([In, AddAsMember] HDC hdc, string lpString, int c, out SIZE lpsz);

	/// <summary>The <c>GetTextExtentPoint32</c> function computes the width and height of the specified string of text.</summary>
	/// <param name="hdc">A handle to the device context.</param>
	/// <param name="lpString">
	/// A pointer to a buffer that specifies the text string. The string does not need to be null-terminated, because the c parameter
	/// specifies the length of the string.
	/// </param>
	/// <param name="c">The length of the string pointed to by lpString.</param>
	/// <param name="psizl">A pointer to a SIZE structure that receives the dimensions of the string, in logical units.</param>
	/// <returns>
	/// <para>If the function succeeds, the return value is nonzero.</para>
	/// <para>If the function fails, the return value is zero.</para>
	/// </returns>
	/// <remarks>
	/// <para>
	/// The <c>GetTextExtentPoint32</c> function uses the currently selected font to compute the dimensions of the string. The width and
	/// height, in logical units, are computed without considering any clipping.
	/// </para>
	/// <para>
	/// Because some devices kern characters, the sum of the extents of the characters in a string may not be equal to the extent of the string.
	/// </para>
	/// <para>
	/// The calculated string width takes into account the intercharacter spacing set by the SetTextCharacterExtra function and the
	/// justification set by SetTextJustification. This is true for both displaying on a screen and for printing. However, if lpDx is set in
	/// ExtTextOut, <c>GetTextExtentPoint32</c> does not take into account either intercharacter spacing or justification. In addition, for
	/// EMF, the print result always takes both intercharacter spacing and justification into account.
	/// </para>
	/// <para>
	/// When dealing with text displayed on a screen, the calculated string width takes into account the intercharacter spacing set by the
	/// SetTextCharacterExtra function and the justification set by SetTextJustification. However, if lpDx is set in ExtTextOut,
	/// <c>GetTextExtentPoint32</c> does not take into account either intercharacter spacing or justification. However, when printing with EMF:
	/// </para>
	/// <list type="bullet">
	/// <item>
	/// <term>The print result ignores intercharacter spacing, although <c>GetTextExtentPoint32</c> takes it into account.</term>
	/// </item>
	/// <item>
	/// <term>The print result takes justification into account, although <c>GetTextExtentPoint32</c> ignores it.</term>
	/// </item>
	/// </list>
	/// <para>
	/// When this function returns the text extent, it assumes that the text is horizontal, that is, that the escapement is always 0. This is
	/// true for both the horizontal and vertical measurements of the text. Even if you use a font that specifies a nonzero escapement, this
	/// function doesn't use the angle while it computes the text extent. The app must convert it explicitly. However, when the graphics mode
	/// is set to GM_ADVANCED and the character orientation is 90 degrees from the print orientation, the values that this function return do
	/// not follow this rule. When the character orientation and the print orientation match for a given string, this function returns the
	/// dimensions of the string in the SIZE structure as { cx : 116, cy : 18 }. When the character orientation and the print orientation are
	/// 90 degrees apart for the same string, this function returns the dimensions of the string in the <c>SIZE</c> structure as { cx : 18,
	/// cy : 116 }.
	/// </para>
	/// <para>
	/// <c>GetTextExtentPoint32</c> doesn't consider "\n" (new line) or "\r\n" (carriage return and new line) characters when it computes the
	/// height of a text string.
	/// </para>
	/// <para>Examples</para>
	/// <para>For an example, see Drawing Text from Different Fonts on the Same Line.</para>
	/// </remarks>
	// https://docs.microsoft.com/en-us/windows/win32/api/wingdi/nf-wingdi-gettextextentpoint32a BOOL GetTextExtentPoint32A( HDC hdc, LPCSTR
	// lpString, int c, LPSIZE psizl );
	[DllImport(Lib.Gdi32, SetLastError = false, CharSet = CharSet.Auto)]
	[PInvokeData("wingdi.h", MSDNShortId = "530280ee-dfd8-4905-9b72-6c19efcff133")]
	[return: MarshalAs(UnmanagedType.Bool)]
	public static extern bool GetTextExtentPoint32([In, AddAsMember] HDC hdc, string lpString, int c, out SIZE psizl);

	/// <summary>The <c>GetTextExtentPointI</c> function computes the width and height of the specified array of glyph indices.</summary>
	/// <param name="hdc">Handle to the device context.</param>
	/// <param name="pgiIn">Pointer to array of glyph indices.</param>
	/// <param name="cgi">Specifies the number of glyph indices.</param>
	/// <param name="psize">Pointer to a SIZE structure that receives the dimensions of the string, in logical units.</param>
	/// <returns>
	/// <para>If the function succeeds, the return value is nonzero.</para>
	/// <para>If the function fails, the return value is zero.</para>
	/// </returns>
	/// <remarks>
	/// <para>
	/// The <c>GetTextExtentPointI</c> function uses the currently selected font to compute the dimensions of the array of glyph indices. The
	/// width and height, in logical units, are computed without considering any clipping.
	/// </para>
	/// <para>
	/// When this function returns the text extent, it assumes that the text is horizontal, that is, that the escapement is always 0. This is
	/// true for both the horizontal and vertical measurements of the text. Even if you use a font that specifies a nonzero escapement, this
	/// function doesn't use the angle while it computes the text extent. The app must convert it explicitly. However, when the graphics mode
	/// is set to GM_ADVANCED and the character orientation is 90 degrees from the print orientation, the values that this function return do
	/// not follow this rule. When the character orientation and the print orientation match for a given string, this function returns the
	/// dimensions of the string in the SIZE structure as { cx : 116, cy : 18 }. When the character orientation and the print orientation are
	/// 90 degrees apart for the same string, this function returns the dimensions of the string in the <c>SIZE</c> structure as { cx : 18,
	/// cy : 116 }.
	/// </para>
	/// <para>
	/// Because some devices kern characters, the sum of the extents of the individual glyph indices may not be equal to the extent of the
	/// entire array of glyph indices.
	/// </para>
	/// <para>The calculated string width takes into account the intercharacter spacing set by the SetTextCharacterExtra function.</para>
	/// </remarks>
	// https://docs.microsoft.com/en-us/windows/win32/api/wingdi/nf-wingdi-gettextextentpointi BOOL GetTextExtentPointI( HDC hdc, LPWORD
	// pgiIn, int cgi, LPSIZE psize );
	[DllImport(Lib.Gdi32, SetLastError = false, ExactSpelling = true)]
	[PInvokeData("wingdi.h", MSDNShortId = "d06a48dd-3f38-4c60-a4c6-954e43f718d1")]
	[return: MarshalAs(UnmanagedType.Bool)]
	public static extern bool GetTextExtentPointI([In, AddAsMember] HDC hdc, [In] ushort[] pgiIn, int cgi, out SIZE psize);

	/// <summary>The <c>GetTextFace</c> function retrieves the typeface name of the font that is selected into the specified device context.</summary>
	/// <param name="hdc">A handle to the device context.</param>
	/// <param name="c">
	/// The length of the buffer pointed to by lpFaceName. For the ANSI function it is a BYTE count and for the Unicode function it is a WORD
	/// count. Note that for the ANSI function, characters in SBCS code pages take one byte each, while most characters in DBCS code pages
	/// take two bytes; for the Unicode function, most currently defined Unicode characters (those in the Basic Multilingual Plane (BMP)) are
	/// one WORD while Unicode surrogates are two WORDs.
	/// </param>
	/// <param name="lpName">
	/// A pointer to the buffer that receives the typeface name. If this parameter is <c>NULL</c>, the function returns the number of
	/// characters in the name, including the terminating null character.
	/// </param>
	/// <returns>
	/// <para>If the function succeeds, the return value is the number of characters copied to the buffer.</para>
	/// <para>If the function fails, the return value is zero.</para>
	/// </returns>
	/// <remarks>
	/// <para>The typeface name is copied as a null-terminated character string.</para>
	/// <para>If the name is longer than the number of characters specified by the nCount parameter, the name is truncated.</para>
	/// </remarks>
	// https://docs.microsoft.com/en-us/windows/win32/api/wingdi/nf-wingdi-gettextfacea int GetTextFaceA( HDC hdc, int c, LPSTR lpName );
	[DllImport(Lib.Gdi32, SetLastError = false, CharSet = CharSet.Auto)]
	[PInvokeData("wingdi.h", MSDNShortId = "c4c8c8f5-3651-481b-a55f-da7f49d92f3a")]
	public static extern int GetTextFace([In, AddAsMember] HDC hdc, int c, [Optional, SizeDef(nameof(c), SizingMethod.QueryResultInReturn)] StringBuilder? lpName);

	/// <summary>The <c>GetTextMetrics</c> function fills the specified buffer with the metrics for the currently selected font.</summary>
	/// <param name="hdc">A handle to the device context.</param>
	/// <param name="lptm">A pointer to the TEXTMETRIC structure that receives the text metrics.</param>
	/// <returns>
	/// <para>If the function succeeds, the return value is nonzero.</para>
	/// <para>If the function fails, the return value is zero.</para>
	/// </returns>
	/// <remarks>
	/// <para>
	/// To determine whether a font is a TrueType font, first select it into a DC, then call <c>GetTextMetrics</c>, and then check for
	/// TMPF_TRUETYPE in TEXTMETRIC.tmPitchAndFamily. Note that GetDC returns an uninitialized DC, which has "System" (a bitmap font) as the
	/// default font; thus the need to select a font into the DC.
	/// </para>
	/// <para>Examples</para>
	/// <para>For an example, see "Displaying Keyboard Input" in Using Keyboard Input or Drawing Text from Different Fonts on the Same Line.</para>
	/// </remarks>
	// https://docs.microsoft.com/en-us/windows/win32/api/wingdi/nf-wingdi-gettextmetricsa BOOL GetTextMetricsA( HDC hdc, LPTEXTMETRICA lptm );
	[DllImport(Lib.Gdi32, SetLastError = false, CharSet = CharSet.Auto)]
	[PInvokeData("wingdi.h", MSDNShortId = "92d45a3b-12df-42ff-8d87-5c27b44dc481")]
	[return: MarshalAs(UnmanagedType.Bool)]
	public static extern bool GetTextMetrics([In, AddAsMember] HDC hdc, out TEXTMETRIC lptm);

	/// <summary>
	/// The <c>PolyTextOut</c> function draws several strings using the font and text colors currently selected in the specified device context.
	/// </summary>
	/// <param name="hdc">A handle to the device context.</param>
	/// <param name="ppt">
	/// A pointer to an array of POLYTEXT structures describing the strings to be drawn. The array contains one structure for each string to
	/// be drawn.
	/// </param>
	/// <param name="nstrings">The number of POLYTEXT structures in the pptxt array.</param>
	/// <returns>
	/// <para>If the function succeeds, the return value is nonzero.</para>
	/// <para>If the function fails, the return value is zero.</para>
	/// </returns>
	/// <remarks>
	/// <para>
	/// Each POLYTEXT structure contains the coordinates of a reference point that Windows uses to align the corresponding string of text. An
	/// application can specify how the reference point is used by calling the SetTextAlign function. An application can determine the
	/// current text-alignment setting for the specified device context by calling the GetTextAlign function.
	/// </para>
	/// <para>To draw a single string of text, the application should call the ExtTextOut function.</para>
	/// </remarks>
	// https://docs.microsoft.com/en-us/windows/win32/api/wingdi/nf-wingdi-polytextouta BOOL PolyTextOutA( HDC hdc, const POLYTEXTA *ppt, int
	// nstrings );
	[DllImport(Lib.Gdi32, SetLastError = false, CharSet = CharSet.Auto)]
	[PInvokeData("wingdi.h", MSDNShortId = "643b4f6a-843f-4795-adc8-a90223bdc246")]
	[return: MarshalAs(UnmanagedType.Bool)]
	public static extern bool PolyTextOut([In, AddAsMember] HDC hdc, [In, MarshalAs(UnmanagedType.LPArray, SizeParamIndex = 2)] POLYTEXT[] ppt, int nstrings);

	/// <summary>The <c>RemoveFontMemResourceEx</c> function removes the fonts added from a memory image file.</summary>
	/// <param name="h">A handle to the font-resource. This handle is returned by the AddFontMemResourceEx function.</param>
	/// <returns>
	/// <para>If the function succeeds, the return value is nonzero.</para>
	/// <para>If the function fails, the return value is zero. No extended error information is available.</para>
	/// </returns>
	/// <remarks>
	/// This function removes a font that was added by the AddFontMemResourceEx function. To remove the font, specify the same path and flags
	/// as were used in <c>AddFontMemResourceEx</c>. This function will only remove the font that is specified by fh.
	/// </remarks>
	// https://docs.microsoft.com/en-us/windows/win32/api/wingdi/nf-wingdi-removefontmemresourceex BOOL RemoveFontMemResourceEx( HANDLE h );
	[DllImport(Lib.Gdi32, SetLastError = false, ExactSpelling = true)]
	[PInvokeData("wingdi.h", MSDNShortId = "b73c3f1d-c508-418c-a5a2-105a35ec3a9b")]
	[return: MarshalAs(UnmanagedType.Bool)]
	public static extern bool RemoveFontMemResourceEx(HANDLE h);

	/// <summary>
	/// <para>The <c>RemoveFontResource</c> function removes the fonts in the specified file from the system font table.</para>
	/// <para>If the font was added using the AddFontResourceEx function, you must use the RemoveFontResourceEx function.</para>
	/// </summary>
	/// <param name="lpFileName">A pointer to a null-terminated string that names a font resource file.</param>
	/// <returns>
	/// <para>If the function succeeds, the return value is nonzero.</para>
	/// <para>If the function fails, the return value is zero.</para>
	/// </returns>
	/// <remarks>
	/// <para>
	/// We recommend that if an app adds or removes fonts from the system font table that it notify other windows of the change by sending a
	/// WM_FONTCHANGE message to all top-level windows in the system. The app sends this message by calling the SendMessage function with the
	/// hwnd parameter set to HWND_BROADCAST.
	/// </para>
	/// <para>
	/// If there are outstanding references to a font, the associated resource remains loaded until no device context is using it.
	/// Furthermore, if the font is listed in the font registry ( <c>HKEY_LOCAL_MACHINE\SOFTWARE\Microsoft\Windows
	/// NT\CurrentVersion\Fonts</c>) and is installed to any location other than the %windir%\fonts\ folder, it may be loaded into other
	/// active sessions (including session 0).
	/// </para>
	/// <para>
	/// When you try to replace an existing font file that contains a font with outstanding references to it, you might get an error that
	/// indicates that the original font can't be deleted because it’s in use even after you call <c>RemoveFontResource</c>. If your app
	/// requires that the font file be replaced, to reduce the resource count of the original font to zero, call <c>RemoveFontResource</c> in
	/// a loop as shown in this example code. If you continue to get errors, this is an indication that the font file remains loaded in other
	/// sessions. Make sure the font isn't listed in the font registry and restart the system to ensure the font is unloaded from all sessions.
	/// </para>
	/// <para>
	/// <c>Note</c> Apps where the original font file is in use will still be able to access the original file and won't use the new font
	/// until the font reloads. Call AddFontResource to reload the font. We recommend that you call <c>AddFontResource</c> the same number of
	/// times as the call to <c>RemoveFontResource</c> succeeded as shown in this example code.
	/// </para>
	/// </remarks>
	// https://docs.microsoft.com/en-us/windows/win32/api/wingdi/nf-wingdi-removefontresourcea BOOL RemoveFontResourceA( LPCSTR lpFileName );
	[DllImport(Lib.Gdi32, SetLastError = false, CharSet = CharSet.Auto)]
	[PInvokeData("wingdi.h", MSDNShortId = "ccc0ac8b-e373-47a9-a362-64fd79a33d0c")]
	[return: MarshalAs(UnmanagedType.Bool)]
	public static extern bool RemoveFontResource(string lpFileName);

	/// <summary>The <c>RemoveFontResourceEx</c> function removes the fonts in the specified file from the system font table.</summary>
	/// <param name="name">A pointer to a null-terminated string that names a font resource file.</param>
	/// <param name="fl">
	/// The characteristics of the font to be removed from the system. In order for the font to be removed, the flags used must be the same
	/// as when the font was added with the AddFontResourceEx function. See the <see cref="AddFontResourceEx"/> function for more information.
	/// </param>
	/// <param name="pdv">Reserved. Must be zero.</param>
	/// <returns>
	/// <para>If the function succeeds, the return value is nonzero.</para>
	/// <para>If the function fails, the return value is zero. No extended error information is available.</para>
	/// </returns>
	/// <remarks>
	/// <para>
	/// This function will only remove the font if the flags specified are the same as when then font was added with the AddFontResourceEx function.
	/// </para>
	/// <para>
	/// When you try to replace an existing font file that contains a font with outstanding references to it, you might get an error that
	/// indicates that the original font can't be deleted because it’s in use even after you call <c>RemoveFontResourceEx</c>. If your app
	/// requires that the font file be replaced, to reduce the resource count of the original font to zero, call <c>RemoveFontResourceEx</c>
	/// in a loop as shown in this example code. If you continue to get errors, this is an indication that the font file remains loaded in
	/// other sessions. Make sure the font isn't listed in the font registry and restart the system to ensure the font is unloaded from all sessions.
	/// </para>
	/// <para>
	/// <c>Note</c> Apps where the original font file is in use will still be able to access the original file and won't use the new font
	/// until the font reloads. Call AddFontResourceEx to reload the font. We recommend that you call <c>AddFontResourceEx</c> the same
	/// number of times as the call to <c>RemoveFontResourceEx</c> succeeded as shown in this example code.
	/// </para>
	/// </remarks>
	// https://docs.microsoft.com/en-us/windows/win32/api/wingdi/nf-wingdi-removefontresourceexa BOOL RemoveFontResourceExA( LPCSTR name,
	// DWORD fl, PVOID pdv );
	[DllImport(Lib.Gdi32, SetLastError = false, CharSet = CharSet.Auto)]
	[PInvokeData("wingdi.h", MSDNShortId = "18056fe7-1efe-428e-a828-3217c53371eb")]
	[return: MarshalAs(UnmanagedType.Bool)]
	public static extern bool RemoveFontResourceEx(string name, FR fl, IntPtr pdv = default);

	/// <summary>The <c>SetMapperFlags</c> function alters the algorithm the font mapper uses when it maps logical fonts to physical fonts.</summary>
	/// <param name="hdc">A handle to the device context that contains the font-mapper flag.</param>
	/// <param name="flags">
	/// Specifies whether the font mapper should attempt to match a font's aspect ratio to the current device's aspect ratio. If bit zero is
	/// set, the mapper selects only matching fonts.
	/// </param>
	/// <returns>
	/// <para>If the function succeeds, the return value is the previous value of the font-mapper flag.</para>
	/// <para>If the function fails, the return value is GDI_ERROR.</para>
	/// </returns>
	/// <remarks>
	/// <para>
	/// If the dwFlag parameter is set and no matching fonts exist, Windows chooses a new aspect ratio and retrieves a font that matches this ratio.
	/// </para>
	/// <para>The remaining bits of the dwFlag parameter must be zero.</para>
	/// </remarks>
	// https://docs.microsoft.com/en-us/windows/win32/api/wingdi/nf-wingdi-setmapperflags DWORD SetMapperFlags( HDC hdc, DWORD flags );
	[DllImport(Lib.Gdi32, SetLastError = false, ExactSpelling = true)]
	[PInvokeData("wingdi.h", MSDNShortId = "74cfe0d3-0d20-4382-8e76-55a6e2323308")]
	public static extern uint SetMapperFlags([In, AddAsMember] HDC hdc, uint flags);

	/// <summary>The <c>SetTextAlign</c> function sets the text-alignment flags for the specified device context.</summary>
	/// <param name="hdc">A handle to the device context.</param>
	/// <param name="align">
	/// <para>
	/// The text alignment by using a mask of the values in the following list. Only one flag can be chosen from those that affect horizontal
	/// and vertical alignment. In addition, only one of the two flags that alter the current position can be chosen.
	/// </para>
	/// <list type="table">
	/// <listheader>
	/// <term>Value</term>
	/// <term>Meaning</term>
	/// </listheader>
	/// <item>
	/// <term>TA_BASELINE</term>
	/// <term>The reference point will be on the base line of the text.</term>
	/// </item>
	/// <item>
	/// <term>TA_BOTTOM</term>
	/// <term>The reference point will be on the bottom edge of the bounding rectangle.</term>
	/// </item>
	/// <item>
	/// <term>TA_TOP</term>
	/// <term>The reference point will be on the top edge of the bounding rectangle.</term>
	/// </item>
	/// <item>
	/// <term>TA_CENTER</term>
	/// <term>The reference point will be aligned horizontally with the center of the bounding rectangle.</term>
	/// </item>
	/// <item>
	/// <term>TA_LEFT</term>
	/// <term>The reference point will be on the left edge of the bounding rectangle.</term>
	/// </item>
	/// <item>
	/// <term>TA_RIGHT</term>
	/// <term>The reference point will be on the right edge of the bounding rectangle.</term>
	/// </item>
	/// <item>
	/// <term>TA_NOUPDATECP</term>
	/// <term>The current position is not updated after each text output call. The reference point is passed to the text output function.</term>
	/// </item>
	/// <item>
	/// <term>TA_RTLREADING</term>
	/// <term>
	/// Middle East language edition of Windows: The text is laid out in right to left reading order, as opposed to the default left to right
	/// order. This applies only when the font selected into the device context is either Hebrew or Arabic.
	/// </term>
	/// </item>
	/// <item>
	/// <term>TA_UPDATECP</term>
	/// <term>The current position is updated after each text output call. The current position is used as the reference point.</term>
	/// </item>
	/// </list>
	/// <para>
	/// When the current font has a vertical default base line, as with Kanji, the following values must be used instead of TA_BASELINE and TA_CENTER.
	/// </para>
	/// <list type="table">
	/// <listheader>
	/// <term>Value</term>
	/// <term>Meaning</term>
	/// </listheader>
	/// <item>
	/// <term>VTA_BASELINE</term>
	/// <term>The reference point will be on the base line of the text.</term>
	/// </item>
	/// <item>
	/// <term>VTA_CENTER</term>
	/// <term>The reference point will be aligned vertically with the center of the bounding rectangle.</term>
	/// </item>
	/// </list>
	/// <para>The default values are TA_LEFT, TA_TOP, and TA_NOUPDATECP.</para>
	/// </param>
	/// <returns>
	/// <para>If the function succeeds, the return value is the previous text-alignment setting.</para>
	/// <para>If the function fails, the return value is GDI_ERROR.</para>
	/// </returns>
	/// <remarks>
	/// <para>
	/// The TextOut and ExtTextOut functions use the text-alignment flags to position a string of text on a display or other device. The
	/// flags specify the relationship between a reference point and a rectangle that bounds the text. The reference point is either the
	/// current position or a point passed to a text output function.
	/// </para>
	/// <para>The rectangle that bounds the text is formed by the character cells in the text string.</para>
	/// <para>The best way to get left-aligned text is to use either</para>
	/// <para>or</para>
	/// <para>You can also use <c>SetTextAlign</c> (hdc, TA_LEFT) for this purpose, but this loses any vertical or right-to-left settings.</para>
	/// <para>
	/// <c>Note</c> You should not use <c>SetTextAlign</c> with TA_UPDATECP when you are using ScriptStringOut, because selected text is not
	/// rendered correctly. If you must use this flag, you can unset and reset it as necessary to avoid the problem.
	/// </para>
	/// <para>Examples</para>
	/// <para>For an example, see Setting the Text Alignment.</para>
	/// </remarks>
	// https://docs.microsoft.com/en-us/windows/win32/api/wingdi/nf-wingdi-settextalign UINT SetTextAlign( HDC hdc, UINT align );
	[DllImport(Lib.Gdi32, SetLastError = false, ExactSpelling = true)]
	[PInvokeData("wingdi.h", MSDNShortId = "422868c5-14c9-4374-9cc5-b7bf91ab9eb4")]
	public static extern TextAlign SetTextAlign([In, AddAsMember] HDC hdc, TextAlign align);

	/// <summary>
	/// The <c>SetTextCharacterExtra</c> function sets the intercharacter spacing. Intercharacter spacing is added to each character,
	/// including break characters, when the system writes a line of text.
	/// </summary>
	/// <param name="hdc">A handle to the device context.</param>
	/// <param name="extra">
	/// The amount of extra space, in logical units, to be added to each character. If the current mapping mode is not MM_TEXT, the
	/// nCharExtra parameter is transformed and rounded to the nearest pixel.
	/// </param>
	/// <returns>
	/// <para>If the function succeeds, the return value is the previous intercharacter spacing.</para>
	/// <para>If the function fails, the return value is 0x80000000.</para>
	/// </returns>
	/// <remarks>
	/// <para>
	/// This function is supported mainly for compatibility with existing applications. New applications should generally avoid calling this
	/// function, because it is incompatible with complex scripts (scripts that require text shaping; Arabic script is an example of this).
	/// </para>
	/// <para>
	/// The recommended approach is that instead of calling this function and then TextOut, applications should call ExtTextOut and use its
	/// lpDx parameter to supply widths.
	/// </para>
	/// </remarks>
	// https://docs.microsoft.com/en-us/windows/win32/api/wingdi/nf-wingdi-settextcharacterextra int SetTextCharacterExtra( HDC hdc, int
	// extra );
	[DllImport(Lib.Gdi32, SetLastError = false, ExactSpelling = true)]
	[PInvokeData("wingdi.h", MSDNShortId = "83b7d225-4fb9-4c75-bc4a-e1bea7f901f1")]
	public static extern int SetTextCharacterExtra([In, AddAsMember] HDC hdc, int extra);

	/// <summary>The <c>SetTextColor</c> function sets the text color for the specified device context to the specified color.</summary>
	/// <param name="hdc">A handle to the device context.</param>
	/// <param name="color">The color of the text.</param>
	/// <returns>
	/// <para>If the function succeeds, the return value is a color reference for the previous text color as a COLORREF value.</para>
	/// <para>If the function fails, the return value is CLR_INVALID.</para>
	/// </returns>
	/// <remarks>
	/// <para>
	/// The text color is used to draw the face of each character written by the TextOut and ExtTextOut functions. The text color is also
	/// used in converting bitmaps from color to monochrome and vice versa.
	/// </para>
	/// <para>Examples</para>
	/// <para>For an example, see "Setting Fonts for Menu-Item Text Strings" in Using Menus.</para>
	/// </remarks>
	// https://docs.microsoft.com/en-us/windows/win32/api/wingdi/nf-wingdi-settextcolor COLORREF SetTextColor( HDC hdc, COLORREF color );
	[DllImport(Lib.Gdi32, SetLastError = false, ExactSpelling = true)]
	[PInvokeData("wingdi.h", MSDNShortId = "3875a247-7c32-4917-bf6d-50b2a49848a6")]
	public static extern COLORREF SetTextColor([In, AddAsMember] HDC hdc, COLORREF color);

	/// <summary>
	/// The <c>SetTextJustification</c> function specifies the amount of space the system should add to the break characters in a string of
	/// text. The space is added when an application calls the TextOut or ExtTextOut functions.
	/// </summary>
	/// <param name="hdc">A handle to the device context.</param>
	/// <param name="extra">
	/// The total extra space, in logical units, to be added to the line of text. If the current mapping mode is not MM_TEXT, the value
	/// identified by the nBreakExtra parameter is transformed and rounded to the nearest pixel.
	/// </param>
	/// <param name="count">The number of break characters in the line.</param>
	/// <returns>
	/// <para>If the function succeeds, the return value is nonzero.</para>
	/// <para>If the function fails, the return value is zero.</para>
	/// </returns>
	/// <remarks>
	/// <para>
	/// The break character is usually the space character (ASCII 32), but it may be defined by a font as some other character. The
	/// GetTextMetrics function can be used to retrieve a font's break character.
	/// </para>
	/// <para>The TextOut function distributes the specified extra space evenly among the break characters in the line.</para>
	/// <para>
	/// The GetTextExtentPoint32 function is always used with the <c>SetTextJustification</c> function. Sometimes the
	/// <c>GetTextExtentPoint32</c> function takes justification into account when computing the width of a specified line before
	/// justification, and sometimes it does not. For more details on this, see <c>GetTextExtentPoint32</c>. This width must be known before
	/// an appropriate nBreakExtra value can be computed.
	/// </para>
	/// <para>
	/// <c>SetTextJustification</c> can be used to justify a line that contains multiple strings in different fonts. In this case, each
	/// string must be justified separately.
	/// </para>
	/// <para>
	/// Because rounding errors can occur during justification, the system keeps a running error term that defines the current error value.
	/// When justifying a line that contains multiple runs, GetTextExtentPoint automatically uses this error term when it computes the extent
	/// of the next run, allowing TextOut to blend the error into the new run. After each line has been justified, this error term must be
	/// cleared to prevent it from being incorporated into the next line. The term can be cleared by calling <c>SetTextJustification</c> with
	/// nBreakExtra set to zero.
	/// </para>
	/// </remarks>
	// https://docs.microsoft.com/en-us/windows/win32/api/wingdi/nf-wingdi-settextjustification BOOL SetTextJustification( HDC hdc, int
	// extra, int count );
	[DllImport(Lib.Gdi32, SetLastError = false, ExactSpelling = true)]
	[PInvokeData("wingdi.h", MSDNShortId = "55fb5a28-b7da-40d8-8e64-4b42c23fa8b1")]
	[return: MarshalAs(UnmanagedType.Bool)]
	public static extern bool SetTextJustification([In, AddAsMember] HDC hdc, int extra, int count);

	/// <summary>
	/// The <c>TextOut</c> function writes a character string at the specified location, using the currently selected font, background color,
	/// and text color.
	/// </summary>
	/// <param name="hdc">A handle to the device context.</param>
	/// <param name="x">The x-coordinate, in logical coordinates, of the reference point that the system uses to align the string.</param>
	/// <param name="y">The y-coordinate, in logical coordinates, of the reference point that the system uses to align the string.</param>
	/// <param name="lpString">
	/// A pointer to the string to be drawn. The string does not need to be zero-terminated, because cchString specifies the length of the string.
	/// </param>
	/// <param name="c">The length of the string pointed to by lpString, in characters.</param>
	/// <returns>
	/// <para>If the function succeeds, the return value is nonzero.</para>
	/// <para>If the function fails, the return value is zero.</para>
	/// </returns>
	/// <remarks>
	/// <para>
	/// The interpretation of the reference point depends on the current text-alignment mode. An application can retrieve this mode by
	/// calling the GetTextAlign function; an application can alter this mode by calling the SetTextAlign function. You can use the following
	/// values for text alignment. Only one flag can be chosen from those that affect horizontal and vertical alignment. In addition, only
	/// one of the two flags that alter the current position can be chosen.
	/// </para>
	/// <list type="table">
	/// <listheader>
	/// <term>Term</term>
	/// <term>Description</term>
	/// </listheader>
	/// <item>
	/// <term>TA_BASELINE</term>
	/// <term>The reference point will be on the base line of the text.</term>
	/// </item>
	/// <item>
	/// <term>TA_BOTTOM</term>
	/// <term>The reference point will be on the bottom edge of the bounding rectangle.</term>
	/// </item>
	/// <item>
	/// <term>TA_TOP</term>
	/// <term>The reference point will be on the top edge of the bounding rectangle.</term>
	/// </item>
	/// <item>
	/// <term>TA_CENTER</term>
	/// <term>The reference point will be aligned horizontally with the center of the bounding rectangle.</term>
	/// </item>
	/// <item>
	/// <term>TA_LEFT</term>
	/// <term>The reference point will be on the left edge of the bounding rectangle.</term>
	/// </item>
	/// <item>
	/// <term>TA_RIGHT</term>
	/// <term>The reference point will be on the right edge of the bounding rectangle.</term>
	/// </item>
	/// <item>
	/// <term>TA_NOUPDATECP</term>
	/// <term>The current position is not updated after each text output call. The reference point is passed to the text output function.</term>
	/// </item>
	/// <item>
	/// <term>TA_RTLREADING</term>
	/// <term>
	/// Middle East language edition of Windows: The text is laid out in right to left reading order, as opposed to the default left to right
	/// order. This applies only when the font selected into the device context is either Hebrew or Arabic.
	/// </term>
	/// </item>
	/// <item>
	/// <term>TA_UPDATECP</term>
	/// <term>The current position is updated after each text output call. The current position is used as the reference point.</term>
	/// </item>
	/// </list>
	/// <para>
	/// By default, the current position is not used or updated by this function. However, an application can call the SetTextAlign function
	/// with the fMode parameter set to TA_UPDATECP to permit the system to use and update the current position each time the application
	/// calls <c>TextOut</c> for a specified device context. When this flag is set, the system ignores the nXStart and nYStart parameters on
	/// subsequent <c>TextOut</c> calls.
	/// </para>
	/// <para>
	/// When the <c>TextOut</c> function is placed inside a path bracket, the system generates a path for the TrueType text that includes
	/// each character plus its character box. The region generated is the character box minus the text, rather than the text itself. You can
	/// obtain the region enclosed by the outline of the TrueType text by setting the background mode to transparent before placing the
	/// <c>TextOut</c> function in the path bracket. Following is sample code that demonstrates this procedure.
	/// </para>
	/// <para>Examples</para>
	/// <para>For an example, see Enumerating the Installed Fonts.</para>
	/// </remarks>
	// https://docs.microsoft.com/en-us/windows/win32/api/wingdi/nf-wingdi-textouta BOOL TextOutA( HDC hdc, int x, int y, LPCSTR lpString,
	// int c );
	[DllImport(Lib.Gdi32, SetLastError = false, CharSet = CharSet.Auto)]
	[PInvokeData("wingdi.h", MSDNShortId = "0c437ff8-3893-4dc3-827b-fa9ce4bcd7e6")]
	[return: MarshalAs(UnmanagedType.Bool)]
	public static extern bool TextOut([In, AddAsMember] HDC hdc, int x, int y, string lpString, int c);

	/// <summary>The <c>ABC</c> structure contains the width of a character in a TrueType font.</summary>
	/// <remarks>
	/// The total width of a character is the summation of the A, B, and C spaces. Either the A or the C space can be negative to indicate
	/// underhangs or overhangs.
	/// </remarks>
	// https://docs.microsoft.com/en-us/windows/win32/api/wingdi/ns-wingdi-abc typedef struct _ABC { int abcA; UINT abcB; int abcC; } ABC,
	// *PABC, *NPABC, *LPABC;
	[PInvokeData("wingdi.h", MSDNShortId = "00000000-0000-0000-0000-000000000001")]
	[StructLayout(LayoutKind.Sequential)]
	public struct ABC
	{
		/// <summary>
		/// The A spacing of the character. The A spacing is the distance to add to the current position before drawing the character glyph.
		/// </summary>
		public int abcA;

		/// <summary>The B spacing of the character. The B spacing is the width of the drawn portion of the character glyph.</summary>
		public uint abcB;

		/// <summary>
		/// The C spacing of the character. The C spacing is the distance to add to the current position to provide white space to the right
		/// of the character glyph.
		/// </summary>
		public int abcC;
	}

	/// <summary>The <c>ABCFLOAT</c> structure contains the A, B, and C widths of a font character.</summary>
	/// <remarks>
	/// <para>The A, B, and C widths are measured along the base line of the font.</para>
	/// <para>
	/// The character increment (total width) of a character is the sum of the A, B, and C spaces. Either the A or the C space can be
	/// negative to indicate underhangs or overhangs.
	/// </para>
	/// </remarks>
	// https://docs.microsoft.com/en-us/windows/win32/api/wingdi/ns-wingdi-abcfloat typedef struct _ABCFLOAT { FLOAT abcfA; FLOAT abcfB;
	// FLOAT abcfC; } ABCFLOAT, *PABCFLOAT, *NPABCFLOAT, *LPABCFLOAT;
	[PInvokeData("wingdi.h", MSDNShortId = "540bb00c-f0e2-4ddd-98d1-cf3ed86b6ce0")]
	[StructLayout(LayoutKind.Sequential)]
	public struct ABCFLOAT
	{
		/// <summary>
		/// The A spacing of the character. The A spacing is the distance to add to the current position before drawing the character glyph.
		/// </summary>
		public float abcfA;

		/// <summary>The B spacing of the character. The B spacing is the width of the drawn portion of the character glyph.</summary>
		public float abcfB;

		/// <summary>
		/// The C spacing of the character. The C spacing is the distance to add to the current position to provide white space to the right
		/// of the character glyph.
		/// </summary>
		public float abcfC;
	}

	/// <summary>The <c>AXESLIST</c> structure contains information on all the axes of a multiple master font.</summary>
	/// <remarks>
	/// <para>The PostScript Open Type Font does not support multiple master functionality.</para>
	/// <para>
	/// The information on the axes of a multiple master font are specified by the AXISINFO structures. The <c>axlNumAxes</c> member
	/// specifies the actual size of <c>axlAxisInfo</c>, while MM_MAX_NUMAXES, which equals 16, is the maximum allowed size of <c>axlAxisInfo</c>.
	/// </para>
	/// </remarks>
	// https://docs.microsoft.com/en-us/windows/win32/api/wingdi/ns-wingdi-axeslista typedef struct tagAXESLISTA { DWORD axlReserved; DWORD
	// axlNumAxes; AXISINFOA axlAxisInfo[MM_MAX_NUMAXES]; } AXESLISTA, *PAXESLISTA, *LPAXESLISTA;
	[PInvokeData("wingdi.h", MSDNShortId = "f95f012e-f02b-46c1-94ba-69f426ee7ad9")]
	[StructLayout(LayoutKind.Sequential, CharSet = CharSet.Auto)]
	public struct AXESLIST
	{
		/// <summary>Reserved. Must be STAMP_AXESLIST.</summary>
		public uint axlReserved;

		/// <summary>Number of axes for a specified multiple master font.</summary>
		public uint axlNumAxes;

		/// <summary>
		/// An array of AXISINFO structures. Each <c>AXISINFO</c> structure contains information on an axis of a specified multiple master
		/// font. This corresponds to the <c>dvValues</c> array in the DESIGNVECTOR structure.
		/// </summary>
		[MarshalAs(UnmanagedType.ByValArray, SizeConst = 16)]
		public AXISINFO[] axlAxisInfo;
	}

	/// <summary>The <c>AXISINFO</c> structure contains information about an axis of a multiple master font.</summary>
	/// <remarks>
	/// <para>
	/// The <c>AXISINFO</c> structure contains the name of an axis in a multiple master font and also the minimum and maximum possible values
	/// for the axis. The length of the name is MM_MAX_AXES_NAMELEN, which equals 16. An application queries these values before setting its
	/// desired values in the DESIGNVECTOR array.
	/// </para>
	/// <para>The PostScript Open Type Font does not support multiple master functionality.</para>
	/// <para>For the ANSI version of this structure, <c>axAxisName</c> must be an array of bytes.</para>
	/// </remarks>
	// https://docs.microsoft.com/en-us/windows/win32/api/wingdi/ns-wingdi-axisinfoa typedef struct tagAXISINFOA { LONG axMinValue; LONG
	// axMaxValue; BYTE axAxisName[MM_MAX_AXES_NAMELEN]; } AXISINFOA, *PAXISINFOA, *LPAXISINFOA;
	[PInvokeData("wingdi.h", MSDNShortId = "a947618e-4b50-453a-82d5-5a6f825faebb")]
	[StructLayout(LayoutKind.Sequential, CharSet = CharSet.Auto)]
	public struct AXISINFO
	{
		/// <summary>The minimum value for this axis.</summary>
		public int axMinValue;

		/// <summary>The maximum value for this axis.</summary>
		public int axMaxValue;

		/// <summary>The name of the axis, specified as an array of characters.</summary>
		[MarshalAs(UnmanagedType.ByValTStr, SizeConst = 16)]
		public string axAxisName;
	}

	/// <summary>The <c>DESIGNVECTOR</c> structure is used by an application to specify values for the axes of a multiple master font.</summary>
	/// <remarks>
	/// <para>
	/// The <c>dvNumAxes</c> member determines the actual size of <c>dvValues</c>, and thus, of <c>DESIGNVECTOR</c>. The constant
	/// MM_MAX_NUMAXES, which is 16, specifies the maximum allowed size of the <c>dvValues</c> array.
	/// </para>
	/// <para>The PostScript Open Type Font does not support multiple master functionality.</para>
	/// </remarks>
	// https://docs.microsoft.com/en-us/windows/win32/api/wingdi/ns-wingdi-designvector typedef struct tagDESIGNVECTOR { DWORD dvReserved;
	// DWORD dvNumAxes; LONG dvValues[MM_MAX_NUMAXES]; } DESIGNVECTOR, *PDESIGNVECTOR, *LPDESIGNVECTOR;
	[PInvokeData("wingdi.h", MSDNShortId = "aeff9901-2405-44aa-ba46-8d784afd6b76")]
	[StructLayout(LayoutKind.Sequential)]
	public struct DESIGNVECTOR
	{
		/// <summary>Reserved. Must be STAMP_DESIGNVECTOR.</summary>
		public uint dvReserved;

		/// <summary>Number of values in the <c>dvValues</c> array.</summary>
		public uint dvNumAxes;

		/// <summary>
		/// An array specifying the values of the axes of a multiple master OpenType font. This array corresponds to the <c>axlAxisInfo</c>
		/// array in the AXESLIST structure.
		/// </summary>
		[MarshalAs(UnmanagedType.ByValArray, SizeConst = 16)]
		public int[] dvValues;
	}

	/// <summary>The <c>ENUMLOGFONT</c> structure defines the attributes of a font, the complete name of a font, and the style of a font.</summary>
	// https://docs.microsoft.com/en-us/windows/win32/api/wingdi/ns-wingdi-enumlogfonta typedef struct tagENUMLOGFONTA { LOGFONTA elfLogFont;
	// BYTE elfFullName[LF_FULLFACESIZE]; BYTE elfStyle[LF_FACESIZE]; } ENUMLOGFONTA, *LPENUMLOGFONTA;
	[PInvokeData("wingdi.h", MSDNShortId = "cfae9e97-c714-40fb-88ab-95e12ea3ffa9")]
	[StructLayout(LayoutKind.Sequential, CharSet = CharSet.Auto)]
	public struct ENUMLOGFONT
	{
		/// <summary>A LOGFONT structure that defines the attributes of a font.</summary>
		public LOGFONT elfLogFont;

		/// <summary>A unique name for the font. For example, ABCD Font Company TrueType Bold Italic Sans Serif.</summary>
		[MarshalAs(UnmanagedType.ByValTStr, SizeConst = 64)]
		public string elfFullName;

		/// <summary>The style of the font. For example, Bold Italic.</summary>
		[MarshalAs(UnmanagedType.ByValTStr, SizeConst = 32)]
		public string elfStyle;
	}

	/// <summary>The <c>ENUMLOGFONTEX</c> structure contains information about an enumerated font.</summary>
	// https://docs.microsoft.com/en-us/windows/win32/api/wingdi/ns-wingdi-enumlogfontexw typedef struct tagENUMLOGFONTEXW { LOGFONTW
	// elfLogFont; WCHAR elfFullName[LF_FULLFACESIZE]; WCHAR elfStyle[LF_FACESIZE]; WCHAR elfScript[LF_FACESIZE]; } ENUMLOGFONTEXW, *LPENUMLOGFONTEXW;
	[PInvokeData("wingdi.h", MSDNShortId = "2e848e47-5b5f-46ad-9963-55d6bb6748a9")]
	[StructLayout(LayoutKind.Sequential, CharSet = CharSet.Auto)]
	public struct ENUMLOGFONTEX
	{
		/// <summary>A LOGFONT structure that contains values defining the font attributes.</summary>
		public LOGFONT elfLogFont;

		/// <summary>The unique name of the font. For example, ABC Font Company TrueType Bold Italic Sans Serif.</summary>
		[MarshalAs(UnmanagedType.ByValTStr, SizeConst = LF_FULLFACESIZE)]
		public string elfFullName;

		/// <summary>The style of the font. For example, Bold Italic.</summary>
		[MarshalAs(UnmanagedType.ByValTStr, SizeConst = LF_FACESIZE)]
		public string elfStyle;

		/// <summary>The script, that is, the character set, of the font. For example, Cyrillic.</summary>
		[MarshalAs(UnmanagedType.ByValTStr, SizeConst = LF_FACESIZE)]
		public string elfScript;
	}

	/// <summary>The <c>ENUMLOGFONTEXDV</c> structure contains the information used to create a font.</summary>
	/// <remarks>
	/// <para>The actual size of <c>ENUMLOGFONTEXDV</c> depends on that of DESIGNVECTOR, which, in turn depends on its <c>dvNumAxes</c> member.</para>
	/// <para>
	/// The EnumFonts, EnumFontFamilies, and EnumFontFamiliesEx functions have been modified to return pointers to ENUMTEXTMETRIC and
	/// <c>ENUMLOGFONTEXDV</c> to the callback function.
	/// </para>
	/// </remarks>
	// https://docs.microsoft.com/en-us/windows/win32/api/wingdi/ns-wingdi-enumlogfontexdva typedef struct tagENUMLOGFONTEXDVA {
	// ENUMLOGFONTEXA elfEnumLogfontEx; DESIGNVECTOR elfDesignVector; } ENUMLOGFONTEXDVA, *PENUMLOGFONTEXDVA, *LPENUMLOGFONTEXDVA;
	[PInvokeData("wingdi.h", MSDNShortId = "8d483f52-250e-4c4f-83cf-ff952bb84fd3")]
	[StructLayout(LayoutKind.Sequential, CharSet = CharSet.Auto)]
	public struct ENUMLOGFONTEXDV
	{
		/// <summary>An ENUMLOGFONTEX structure that contains information about the logical attributes of the font.</summary>
		public ENUMLOGFONTEX elfEnumLogfontEx;

		/// <summary>A DESIGNVECTOR structure. This is zero-filled unless the font described is a multiple master OpenType font.</summary>
		public DESIGNVECTOR elfDesignVector;
	}

	/// <summary>The <c>ENUMTEXTMETRIC</c> structure contains information about a physical font.</summary>
	/// <remarks>
	/// <para><c>ENUMTEXTMETRIC</c> is an extension of NEWTEXTMETRICEX that includes the axis information for a multiple master font.</para>
	/// <para>
	/// The EnumFonts, EnumFontFamilies, and EnumFontFamiliesEx functions have been modified to return pointers to the <c>ENUMTEXTMETRIC</c>
	/// and ENUMLOGFONTEXDV structures.
	/// </para>
	/// </remarks>
	// https://docs.microsoft.com/en-us/windows/win32/api/wingdi/ns-wingdi-enumtextmetrica typedef struct tagENUMTEXTMETRICA {
	// NEWTEXTMETRICEXA etmNewTextMetricEx; AXESLISTA etmAxesList; } ENUMTEXTMETRICA, *PENUMTEXTMETRICA, *LPENUMTEXTMETRICA;
	[PInvokeData("wingdi.h", MSDNShortId = "deb81846-3ada-4c88-8c26-74224538d282")]
	[StructLayout(LayoutKind.Sequential, CharSet = CharSet.Auto)]
	public struct ENUMTEXTMETRIC
	{
		/// <summary>A NEWTEXTMETRICEX structure, containing information about a physical font.</summary>
		public NEWTEXTMETRICEX etmNewTextMetricEx;

		/// <summary>
		/// An AXESLIST structure, containing information about the axes for the font. This is only used for multiple master fonts.
		/// </summary>
		public AXESLIST etmAxesList;
	}

	/// <summary>The <c>FIXED</c> structure contains the integral and fractional parts of a fixed-point real number.</summary>
	/// <remarks>The <c>FIXED</c> structure is used to describe the elements of the MAT2 structure.</remarks>
	// https://docs.microsoft.com/en-us/windows/win32/api/wingdi/ns-wingdi-fixed typedef struct _FIXED { #if ... WORD fract; #if ... short
	// value; #else short value; #endif #else WORD fract; #endif } FIXED;
	[PInvokeData("wingdi.h", MSDNShortId = "b1d94060-e822-447f-82ba-fd1cf2ddaa3b")]
	[StructLayout(LayoutKind.Sequential)]
	public struct FIXED
	{
		/// <summary>The integral value.</summary>
		public short value;

		/// <summary>The fractional value.</summary>
		public ushort fract;

		/// <summary>Performs an implicit conversion from <see cref="FIXED"/> to <see cref="decimal"/>.</summary>
		/// <param name="f">The FIXED instance.</param>
		/// <returns>The result of the conversion.</returns>
		public static implicit operator decimal(FIXED f) => decimal.Parse($"{f.value.ToString(NumberFormatInfo.InvariantInfo)}{NumberFormatInfo.InvariantInfo.NumberDecimalSeparator}{f.fract.ToString(NumberFormatInfo.InvariantInfo)}", NumberFormatInfo.InvariantInfo);

		/// <summary>Performs an implicit conversion from <see cref="decimal"/> to <see cref="FIXED"/>.</summary>
		/// <param name="d">The decimal value.</param>
		/// <returns>The result of the conversion.</returns>
		public static implicit operator FIXED(decimal d) => new() { value = (short)Math.Truncate(d), fract = ushort.Parse(d.ToString(NumberFormatInfo.InvariantInfo).Split([NumberFormatInfo.InvariantInfo.NumberDecimalSeparator], StringSplitOptions.None)[1], NumberFormatInfo.InvariantInfo) };

		/// <summary>Converts to string.</summary>
		/// <returns>A <see cref="string"/> that represents this instance.</returns>
		public override string ToString() => ((decimal)this).ToString();
	}

	/// <summary>Contains information identifying the code pages and Unicode subranges for which a given font provides glyphs.</summary>
	/// <remarks>
	/// GDI relies on Windows code pages fitting within a 32-bit value. Furthermore, the highest 2 bits within this value are reserved for
	/// GDI internal use and may not be assigned to code pages.
	/// </remarks>
	// https://docs.microsoft.com/en-us/windows/win32/api/wingdi/ns-wingdi-fontsignature typedef struct tagFONTSIGNATURE { DWORD fsUsb[4];
	// DWORD fsCsb[2]; } FONTSIGNATURE, *PFONTSIGNATURE, *LPFONTSIGNATURE;
	[PInvokeData("wingdi.h", MSDNShortId = "5331da53-7e3d-46e9-a922-da04fedc8382")]
	[StructLayout(LayoutKind.Sequential)]
	public struct FONTSIGNATURE
	{
		/// <summary>
		/// A 128-bit Unicode subset bitfield (USB) identifying up to 126 Unicode subranges. Each bit, except the two most significant bits,
		/// represents a single subrange. The most significant bit is always 1 and identifies the bitfield as a font signature; the second
		/// most significant bit is reserved and must be 0. Unicode subranges are numbered in accordance with the ISO 10646 standard. For
		/// more information, see Unicode Subset Bitfields.
		/// </summary>
		[MarshalAs(UnmanagedType.ByValArray, SizeConst = 4)]
		public uint[] fsUsb;

		/// <summary>
		/// A 64-bit, code-page bitfield (CPB) that identifies a specific character set or code page. Code pages are in the lower 32 bits of
		/// this bitfield. The high 32 are used for non-Windows code pages. For more information, see Code Page Bitfields.
		/// </summary>
		[MarshalAs(UnmanagedType.ByValArray, SizeConst = 2)]
		public uint[] fsCsb;
	}

	/// <summary>
	/// The <c>GCP_RESULTS</c> structure contains information about characters in a string. This structure receives the results of the
	/// GetCharacterPlacement function. For some languages, the first element in the arrays may contain more, language-dependent information.
	/// </summary>
	/// <remarks>
	/// <para>Whether the <c>lpGlyphs</c>, <c>lpOutString</c>, or neither is required depends on the results of the GetFontLanguageInfo call.</para>
	/// <para>
	/// In the case of a font for a language such as English, in which none of the GCP_DBCS, GCP_REORDER, GCP_GLYPHSHAPE, GCP_LIGATE,
	/// GCP_DIACRITIC, or GCP_KASHIDA flags are returned, neither of the arrays is required for proper operation. (Though not required, they
	/// can still be used. If the <c>lpOutString</c> array is used, it will be exactly the same as the lpInputString passed to
	/// GetCharacterPlacement.) Note, however, that if GCP_MAXEXTENT is used, then <c>lpOutString</c> will contain the truncated string if it
	/// is used, NOT an exact copy of the original.
	/// </para>
	/// <para>
	/// In the case of fonts for languages such as Hebrew, which DO have reordering but do not typically have extra glyph shapes,
	/// <c>lpOutString</c> should be used. This will give the string on the screen-readable order. However, the <c>lpGlyphs</c> array is not
	/// typically needed. (Hebrew can have extra glyphs, if the font is a TrueType/Open font.)
	/// </para>
	/// <para>
	/// In the case of languages such as Thai or Arabic, in which GetFontLanguageInfo returns the GCP_GLYPHSHAPE flag, the <c>lpOutString</c>
	/// will give the display-readable order of the string passed to GetCharacterPlacement, but the values will still be the unshaped
	/// characters. For proper display, the <c>lpGlyphs</c> array must be used.
	/// </para>
	/// </remarks>
	// https://docs.microsoft.com/en-us/windows/win32/api/wingdi/ns-wingdi-gcp_resultsa typedef struct tagGCP_RESULTSA { DWORD lStructSize;
	// LPSTR lpOutString; UINT *lpOrder; int *lpDx; int *lpCaretPos; LPSTR lpClass; LPWSTR lpGlyphs; UINT nGlyphs; int nMaxFit; }
	// GCP_RESULTSA, *LPGCP_RESULTSA;
	[PInvokeData("wingdi.h", MSDNShortId = "7692637e-963a-4e0a-8a04-e05a6d01c417")]
	[StructLayout(LayoutKind.Sequential, CharSet = CharSet.Auto)]
	public struct GCP_RESULTS
	{
		/// <summary>The size, in bytes, of the structure.</summary>
		public uint lStructSize;

		/// <summary>
		/// A pointer to the buffer that receives the output string or is <c>NULL</c> if the output string is not needed. The output string
		/// is a version of the original string that is in the order that will be displayed on a specified device. Typically the output
		/// string is identical to the original string, but may be different if the string needs reordering and the GCP_REORDER flag is set
		/// or if the original string exceeds the maximum extent and the GCP_MAXEXTENT flag is set.
		/// </summary>
		public StrPtrAuto lpOutString;

		/// <summary>
		/// <para>
		/// A pointer to the array that receives ordering indexes or is <c>NULL</c> if the ordering indexes are not needed. However, its
		/// meaning depends on the other elements of <c>GCP_RESULTS</c>. If glyph indexes are to be returned, the indexes are for the
		/// <c>lpGlyphs</c> array; if glyphs indexes are not returned and <c>lpOrder</c> is requested, the indexes are for
		/// <c>lpOutString</c>. For example, in the latter case the value of <c>lpOrder</c>[i] is the position of <c>lpString</c>[i] in the
		/// output string lpOutString.
		/// </para>
		/// <para>
		/// This is typically used when GetFontLanguageInfo returns the GCP_REORDER flag, which indicates that the original string needs
		/// reordering. For example, in Hebrew, in which the text runs from right to left, the <c>lpOrder</c> array gives the exact locations
		/// of each element in the original string.
		/// </para>
		/// </summary>
		public ArrayPointer<uint> lpOrder;

		/// <summary>
		/// <para>
		/// A pointer to the array that receives the distances between adjacent character cells or is <c>NULL</c> if these distances are not
		/// needed. If glyph rendering is done, the distances are for the glyphs not the characters, so the resulting array can be used with
		/// the ExtTextOut function.
		/// </para>
		/// <para>
		/// The distances in this array are in display order. To find the distance for the i character in the original string, use the
		/// <c>lpOrder</c> array as follows:
		/// </para>
		/// <para>width = lpDx[lpOrder[i]];</para>
		/// </summary>
		public ArrayPointer<int> lpDx;

		/// <summary>
		/// <para>
		/// A pointer to the array that receives the caret position values or is <c>NULL</c> if caret positions are not needed. Each value
		/// specifies the caret position immediately before the corresponding character. In some languages the position of the caret for each
		/// character may not be immediately to the left of the character. For example, in Hebrew, in which the text runs from right to left,
		/// the caret position is to the right of the character. If glyph ordering is done, <c>lpCaretPos</c> matches the original string,
		/// not the output string. This means that some adjacent values may be the same.
		/// </para>
		/// <para>
		/// The values in this array are in input order. To find the caret position value for the i character in the original string, use the
		/// array as follows:
		/// </para>
		/// <para>position = lpCaretPos[i];</para>
		/// </summary>
		public ArrayPointer<int> lpCaretPos;

		/// <summary>
		/// <para>
		/// A pointer to the array that contains and/or receives character classifications. The values indicate how to lay out characters in
		/// the string and are similar (but not identical) to the CT_CTYPE2 values returned by the GetStringTypeEx function. Each element of
		/// the array can be set to zero or one of the following values.
		/// </para>
		/// <list type="table">
		/// <listheader>
		/// <term>Value</term>
		/// <term>Meaning</term>
		/// </listheader>
		/// <item>
		/// <term>GCPCLASS_ARABIC</term>
		/// <term>Arabic character.</term>
		/// </item>
		/// <item>
		/// <term>GCPCLASS_HEBREW</term>
		/// <term>Hebrew character.</term>
		/// </item>
		/// <item>
		/// <term>GCPCLASS_LATIN</term>
		/// <term>Character from a Latin or other single-byte character set for a left-to-right language.</term>
		/// </item>
		/// <item>
		/// <term>GCPCLASS_LATINNUMBER</term>
		/// <term>Digit from a Latin or other single-byte character set for a left-to-right language.</term>
		/// </item>
		/// <item>
		/// <term>GCPCLASS_LOCALNUMBER</term>
		/// <term>Digit from the character set associated with the current font.</term>
		/// </item>
		/// </list>
		/// <para>In addition, the following can be used when supplying values in the <c>lpClass</c> array with the GCP_CLASSIN flag.</para>
		/// <list type="table">
		/// <listheader>
		/// <term>Value</term>
		/// <term>Meaning</term>
		/// </listheader>
		/// <item>
		/// <term>GCPCLASS_LATINNUMERICSEPARATOR</term>
		/// <term>Input only. Character used to separate Latin digits, such as a comma or decimal point.</term>
		/// </item>
		/// <item>
		/// <term>GCPCLASS_LATINNUMERICTERMINATOR</term>
		/// <term>Input only. Character used to terminate Latin digits, such as a plus or minus sign.</term>
		/// </item>
		/// <item>
		/// <term>GCPCLASS_NEUTRAL</term>
		/// <term>Input only. Character has no specific classification.</term>
		/// </item>
		/// <item>
		/// <term>GCPCLASS_NUMERICSEPARATOR</term>
		/// <term>Input only. Character used to separate digits, such as a comma or decimal point.</term>
		/// </item>
		/// </list>
		/// <para>
		/// For languages that use the GCP_REORDER flag, the following values can also be used with the GCP_CLASSIN flag. Unlike the
		/// preceding values, which can be used anywhere in the <c>lpClass</c> array, all of the following values are used only in the first
		/// location in the array. All combine with other classifications.
		/// </para>
		/// <para>Note that GCPCLASS_PREBOUNDLTR and GCPCLASS_PREBOUNDRTL are mutually exclusive, as are GCPCLASSPOSTBOUNDLTR and GCPCLASSPOSTBOUNDRTL.</para>
		/// <list type="table">
		/// <listheader>
		/// <term>Value</term>
		/// <term>Meaning</term>
		/// </listheader>
		/// <item>
		/// <term>GCPCLASS_PREBOUNDLTR</term>
		/// <term>Set lpClass[0] to GCPCLASS_PREBOUNDLTR to bind the string to left-to-right reading order before the string.</term>
		/// </item>
		/// <item>
		/// <term>GCPCLASS_PREBOUNDRTL</term>
		/// <term>Set lpClass[0] to GCPCLASS_PREBOUNDRTL to bind the string to right-to-left reading order before the string.</term>
		/// </item>
		/// <item>
		/// <term>GCPCLASS_POSTBOUNDLTR</term>
		/// <term>Set lpClass[0] to GCPCLASS_POSTBOUNDLTR to bind the string to left-to-right reading order after the string.</term>
		/// </item>
		/// <item>
		/// <term>GCPCLASS_POSTBOUNDRTL</term>
		/// <term>Set lpClass[0] to GCPCLASS_POSTBOUNDRTL to bind the string to right-to-left reading order after the string.</term>
		/// </item>
		/// </list>
		/// <para>
		/// To force the layout of a character to be carried out in a specific way, preset the classification for the corresponding array
		/// element; the function leaves such preset classifications unchanged and computes classifications only for array elements that have
		/// been set to zero. Preset classifications are used only if the GCP_CLASSIN flag is set and the <c>lpClass</c> array is supplied.
		/// </para>
		/// <para>If GetFontLanguageInfo does not return GCP_REORDER for the current font, only the GCPCLASS_LATIN value is meaningful.</para>
		/// </summary>
		public ArrayPointer<GCPCLASS> lpClass;

		/// <summary>
		/// <para>
		/// A pointer to the array that receives the values identifying the glyphs used for rendering the string or is <c>NULL</c> if glyph
		/// rendering is not needed. The number of glyphs in the array may be less than the number of characters in the original string if
		/// the string contains ligated glyphs. Also if reordering is required, the order of the glyphs may not be sequential.
		/// </para>
		/// <para>
		/// This array is useful if more than one operation is being done on a string which has any form of ligation, kerning or
		/// order-switching. Using the values in this array for subsequent operations saves the time otherwise required to generate the glyph
		/// indices each time.
		/// </para>
		/// <para>
		/// This array always contains glyph indices and the ETO_GLYPH_INDEX value must always be used when this array is used with the
		/// ExtTextOut function.
		/// </para>
		/// <para>
		/// When GCP_LIGATE is used, you can limit the number of characters that will be ligated together. (In Arabic for example,
		/// three-character ligations are common). This is done by setting the maximum required in lpGcpResults-&gt;lpGlyphs[0]. If no
		/// maximum is required, you should set this field to zero.
		/// </para>
		/// <para>
		/// For languages such as Arabic, where GetFontLanguageInfo returns the GCP_GLYPHSHAPE flag, the glyphs for a character will be
		/// different depending on whether the character is at the beginning, middle, or end of a word. Typically, the first character in the
		/// input string will also be the first character in a word, and the last character in the input string will be treated as the last
		/// character in a word. However, if the displayed string is a subset of the complete string, such as when displaying a section of
		/// scrolled text, this may not be true. In these cases, it is desirable to force the first or last characters to be shaped as not
		/// being initial or final forms. To do this, again, the first location in the <c>lpGlyphs</c> array is used by performing an OR
		/// operation of the ligation value above with the values GCPGLYPH_LINKBEFORE and/or GCPGLYPH_LINKAFTER. For example, a value of
		/// GCPGLYPH_LINKBEFORE | 2 means that two-character ligatures are the maximum required, and the first character in the string should
		/// be treated as if it is in the middle of a word.
		/// </para>
		/// </summary>
		public ArrayPointer<ushort> lpGlyphs;

		/// <summary>
		/// On input, this member must be set to the size of the arrays pointed to by the array pointer members. On output, this is set to
		/// the number of glyphs filled in, in the output arrays. If glyph substitution is not required (that is, each input character maps
		/// to exactly one glyph), this member is the same as it is on input.
		/// </summary>
		public uint nGlyphs;

		/// <summary>
		/// The number of characters that fit within the extents specified by the nMaxExtent parameter of the GetCharacterPlacement function.
		/// If the GCP_MAXEXTENT or GCP_JUSTIFY value is set, this value may be less than the number of characters in the original string.
		/// This member is set regardless of whether the GCP_MAXEXTENT or GCP_JUSTIFY value is specified. Unlike <c>nGlyphs</c>, which
		/// specifies the number of output glyphs, <c>nMaxFit</c> refers to the number of characters from the input string. For Latin SBCS
		/// languages, this will be the same.
		/// </summary>
		public int nMaxFit;

		/// <summary>The default instance of this structure with the structure size value set.</summary>
		public static readonly GCP_RESULTS Default = new() { lStructSize = (uint)Marshal.SizeOf<GCP_RESULTS>() };

		/// <summary>
		/// Creates a new <see cref="SafeCoTaskMemStruct{GCP_RESULTS}"/> instance with memory layout sized and initialized for the specified string.
		/// </summary>
		/// <remarks>
		/// The returned structure has its internal pointer fields (such as lpOrder, lpDx, lpCaretPos, lpClass, and lpGlyphs) initialized to
		/// point to the correct offsets within the allocated memory block, based on the length of the input string. This method is typically
		/// used to prepare a GCP_RESULTS structure for use with native text processing APIs that require pre-allocated buffers.
		/// </remarks>
		/// <param name="text">
		/// The text for which the <see cref="GCP_RESULTS"/> structure will be prepared. The length of this string determines the size of the
		/// allocated memory buffers.
		/// </param>
		/// <param name="classes">
		/// Optional array that contains and/or receives character classifications. The values indicate how to lay out characters in the
		/// string and are similar (but not identical) to the CT_CTYPE2 values returned by the GetStringTypeEx function.
		/// </param>
		/// <returns>
		/// A <see cref="SafeCoTaskMemStruct{GCP_RESULTS}"/> instance with internal buffers sized appropriately for the specified string.
		/// </returns>
		public static SafeCoTaskMemStruct<GCP_RESULTS> CreateForString(string text, GCPCLASS[]? classes = null)
		{
			if (classes is not null && classes.Length != text.Length)
				throw new ArgumentException("The length of the classes array must match the length of the text string.", nameof(classes));
			SafeCoTaskMemStruct<GCP_RESULTS> val = new GCP_RESULTS { lStructSize = (uint)Marshal.SizeOf<GCP_RESULTS>() };
			var asz = sizeof(int) * text.Length;
			val.Size += asz * 6; // lpOrder, lpDx, lpCaretPos, lpClass
			ref var refVal = ref val.AsRef();
			refVal.lpOrder = ((IntPtr)val).Offset(refVal.lStructSize);
			refVal.lpDx = ((IntPtr)val).Offset(refVal.lStructSize + asz);
			refVal.lpCaretPos = ((IntPtr)val).Offset(refVal.lStructSize + (asz * 2));
			refVal.lpClass = ((IntPtr)val).Offset(refVal.lStructSize + (asz * 3));
			if (classes is not null)
				Marshal.UnsafeAddrOfPinnedArrayElement(classes, 0).CopyTo((IntPtr)refVal.lpClass, classes.Length * sizeof(GCPCLASS));
			refVal.lpGlyphs = ((IntPtr)val).Offset(refVal.lStructSize + (asz * 4));
			refVal.lpOutString = ((IntPtr)val).Offset(refVal.lStructSize + (asz * 5));
			return val;
		}
	}

	/// <summary>
	/// The <c>GLYPHMETRICS</c> structure contains information about the placement and orientation of a glyph in a character cell.
	/// </summary>
	/// <remarks>Values in the <c>GLYPHMETRICS</c> structure are specified in device units.</remarks>
	// https://docs.microsoft.com/en-us/windows/win32/api/wingdi/ns-wingdi-glyphmetrics typedef struct _GLYPHMETRICS { UINT gmBlackBoxX; UINT
	// gmBlackBoxY; POINT gmptGlyphOrigin; short gmCellIncX; short gmCellIncY; } GLYPHMETRICS, *LPGLYPHMETRICS;
	[PInvokeData("wingdi.h", MSDNShortId = "a6fa3813-56f7-4b54-b21d-8aabc2309a34")]
	[StructLayout(LayoutKind.Sequential)]
	public struct GLYPHMETRICS
	{
		/// <summary>The width of the smallest rectangle that completely encloses the glyph (its black box).</summary>
		public uint gmBlackBoxX;

		/// <summary>The height of the smallest rectangle that completely encloses the glyph (its black box).</summary>
		public uint gmBlackBoxY;

		/// <summary>The x- and y-coordinates of the upper left corner of the smallest rectangle that completely encloses the glyph.</summary>
		public POINT gmptGlyphOrigin;

		/// <summary>The horizontal distance from the origin of the current character cell to the origin of the next character cell.</summary>
		public short gmCellIncX;

		/// <summary>The vertical distance from the origin of the current character cell to the origin of the next character cell.</summary>
		public short gmCellIncY;
	}

	/// <summary>The <c>GLYPHSET</c> structure contains information about a range of Unicode code points.</summary>
	// https://docs.microsoft.com/en-us/windows/win32/api/wingdi/ns-wingdi-glyphset typedef struct tagGLYPHSET { DWORD cbThis; DWORD flAccel;
	// DWORD cGlyphsSupported; DWORD cRanges; WCRANGE ranges[1]; } GLYPHSET, *PGLYPHSET, *LPGLYPHSET;
	[PInvokeData("wingdi.h", MSDNShortId = "b8ac8d3f-b062-491c-966f-02f3d4c11419")]
	[VanaraMarshaler(typeof(SafeAnysizeStructMarshaler<GLYPHSET>), nameof(cRanges))]
	[StructLayout(LayoutKind.Sequential)]
	public struct GLYPHSET
	{
		/// <summary>The size, in bytes, of this structure.</summary>
		public uint cbThis;

		/// <summary>
		/// <para>Flags describing the maximum size of the glyph indices. This member can be the following value.</para>
		/// <list type="table">
		/// <listheader>
		/// <term>Value</term>
		/// <term>Meaning</term>
		/// </listheader>
		/// <item>
		/// <term>GS_8BIT_INDICES</term>
		/// <term>Treat glyph indices as 8-bit wide values. Otherwise, they are 16-bit wide values.</term>
		/// </item>
		/// </list>
		/// </summary>
		public GSISize flAccel;

		/// <summary>The total number of Unicode code points supported in the font.</summary>
		public uint cGlyphsSupported;

		/// <summary>The total number of Unicode ranges in <c>ranges</c>.</summary>
		public uint cRanges;

		/// <summary>Array of Unicode ranges that are supported in the font.</summary>
		[MarshalAs(UnmanagedType.ByValArray, SizeConst = 1)]
		public WCRANGE[] ranges;
	}

	/// <summary>The <c>KERNINGPAIR</c> structure defines a kerning pair.</summary>
	// https://docs.microsoft.com/en-us/windows/win32/api/wingdi/ns-wingdi-kerningpair typedef struct tagKERNINGPAIR { WORD wFirst; WORD
	// wSecond; int iKernAmount; } KERNINGPAIR, *LPKERNINGPAIR;
	[PInvokeData("wingdi.h", MSDNShortId = "af7bfcf7-467b-4ea9-87c5-3622303b1d8b")]
	[StructLayout(LayoutKind.Sequential)]
	public struct KERNINGPAIR
	{
		/// <summary>The character code for the first character in the kerning pair.</summary>
		public ushort wFirst;

		/// <summary>The character code for the second character in the kerning pair.</summary>
		public ushort wSecond;

		/// <summary>
		/// The amount this pair will be kerned if they appear side by side in the same font and size. This value is typically negative,
		/// because pair kerning usually results in two characters being set more tightly than normal. The value is specified in logical
		/// units; that is, it depends on the current mapping mode.
		/// </summary>
		public int iKernAmount;
	}

	/// <summary>The <c>MAT2</c> structure contains the values for a transformation matrix used by the GetGlyphOutline function.</summary>
	/// <remarks>
	/// The identity matrix produces a transformation in which the transformed graphical object is identical to the source object. In the
	/// identity matrix, the value of <c>eM11</c> is 1, the value of <c>eM12</c> is zero, the value of <c>eM21</c> is zero, and the value of
	/// <c>eM22</c> is 1.
	/// </remarks>
	// https://docs.microsoft.com/en-us/windows/win32/api/wingdi/ns-wingdi-mat2 typedef struct _MAT2 { FIXED eM11; FIXED eM12; FIXED eM21;
	// FIXED eM22; } MAT2, *LPMAT2;
	[PInvokeData("wingdi.h", MSDNShortId = "841883d6-bc4d-46ef-abf4-f179771d255b")]
	[StructLayout(LayoutKind.Sequential)]
	public struct MAT2
	{
		/// <summary>A fixed-point value for the M11 component of a 3 by 3 transformation matrix.</summary>
		public FIXED eM11;

		/// <summary>A fixed-point value for the M12 component of a 3 by 3 transformation matrix.</summary>
		public FIXED eM12;

		/// <summary>A fixed-point value for the M21 component of a 3 by 3 transformation matrix.</summary>
		public FIXED eM21;

		/// <summary>A fixed-point value for the M22 component of a 3 by 3 transformation matrix.</summary>
		public FIXED eM22;

		/// <summary>The identity matrix value.</summary>
		public static readonly MAT2 IdentityMatrix = new() { eM11 = new FIXED { fract = 1 }, eM22 = new FIXED { fract = 1 } };
	}

	/// <summary>The <c>NEWTEXTMETRIC</c> structure contains data that describes a physical font.</summary>
	/// <remarks>
	/// <para>
	/// The last four members of the <c>NEWTEXTMETRIC</c> structure are not included in the TEXTMETRIC structure; in all other respects, the
	/// structures are identical.
	/// </para>
	/// <para>
	/// The sizes in the <c>NEWTEXTMETRIC</c> structure are typically specified in logical units; that is, they depend on the current mapping
	/// mode of the display context.
	/// </para>
	/// </remarks>
	// https://docs.microsoft.com/en-us/windows/win32/api/wingdi/ns-wingdi-newtextmetrica typedef struct tagNEWTEXTMETRICA { LONG tmHeight;
	// LONG tmAscent; LONG tmDescent; LONG tmInternalLeading; LONG tmExternalLeading; LONG tmAveCharWidth; LONG tmMaxCharWidth; LONG
	// tmWeight; LONG tmOverhang; LONG tmDigitizedAspectX; LONG tmDigitizedAspectY; BYTE tmFirstChar; BYTE tmLastChar; BYTE tmDefaultChar;
	// BYTE tmBreakChar; BYTE tmItalic; BYTE tmUnderlined; BYTE tmStruckOut; BYTE tmPitchAndFamily; BYTE tmCharSet; DWORD ntmFlags; UINT
	// ntmSizeEM; UINT ntmCellHeight; UINT ntmAvgWidth; } NEWTEXTMETRICA, *PNEWTEXTMETRICA, *NPNEWTEXTMETRICA, *LPNEWTEXTMETRICA;
	[PInvokeData("wingdi.h", MSDNShortId = "0dd7fee0-0771-4c72-9843-0fee308da5cc")]
	[StructLayout(LayoutKind.Sequential, CharSet = CharSet.Auto)]
	public struct NEWTEXTMETRIC
	{
		/// <summary>The height (ascent + descent) of characters.</summary>
		public int tmHeight;

		/// <summary>The ascent (units above the base line) of characters.</summary>
		public int tmAscent;

		/// <summary>The descent (units below the base line) of characters.</summary>
		public int tmDescent;

		/// <summary>
		/// The amount of leading (space) inside the bounds set by the <c>tmHeight</c> member. Accent marks and other diacritical characters
		/// may occur in this area. The designer may set this member to zero.
		/// </summary>
		public int tmInternalLeading;

		/// <summary>
		/// The amount of extra leading (space) that the application adds between rows. Since this area is outside the font, it contains no
		/// marks and is not altered by text output calls in either OPAQUE or TRANSPARENT mode. The designer may set this member to zero.
		/// </summary>
		public int tmExternalLeading;

		/// <summary>
		/// The average width of characters in the font (generally defined as the width of the letter x). This value does not include
		/// overhang required for bold or italic characters.
		/// </summary>
		public int tmAveCharWidth;

		/// <summary>The width of the widest character in the font.</summary>
		public int tmMaxCharWidth;

		/// <summary>The weight of the font.</summary>
		public int tmWeight;

		/// <summary>
		/// <para>
		/// The extra width per string that may be added to some synthesized fonts. When synthesizing some attributes, such as bold or
		/// italic, graphics device interface (GDI) or a device may have to add width to a string on both a per-character and per-string
		/// basis. For example, GDI makes a string bold by expanding the spacing of each character and overstriking by an offset value; it
		/// italicizes a font by shearing the string. In either case, there is an overhang past the basic string. For bold strings, the
		/// overhang is the distance by which the overstrike is offset. For italic strings, the overhang is the amount the top of the font is
		/// sheared past the bottom of the font.
		/// </para>
		/// <para>
		/// The <c>tmOverhang</c> member enables the application to determine how much of the character width returned by a
		/// GetTextExtentPoint32 function call on a single character is the actual character width and how much is the per-string extra
		/// width. The actual width is the extent minus the overhang.
		/// </para>
		/// </summary>
		public int tmOverhang;

		/// <summary>The horizontal aspect of the device for which the font was designed.</summary>
		public int tmDigitizedAspectX;

		/// <summary>
		/// The vertical aspect of the device for which the font was designed. The ratio of the <c>tmDigitizedAspectX</c> and
		/// <c>tmDigitizedAspectY</c> members is the aspect ratio of the device for which the font was designed.
		/// </summary>
		public int tmDigitizedAspectY;

		/// <summary>The value of the first character defined in the font.</summary>
		public char tmFirstChar;

		/// <summary>The value of the last character defined in the font.</summary>
		public char tmLastChar;

		/// <summary>The value of the character to be substituted for characters that are not in the font.</summary>
		public char tmDefaultChar;

		/// <summary>The value of the character to be used to define word breaks for text justification.</summary>
		public char tmBreakChar;

		/// <summary>An italic font if it is nonzero.</summary>
		public byte tmItalic;

		/// <summary>An underlined font if it is nonzero.</summary>
		public byte tmUnderlined;

		/// <summary>A strikeout font if it is nonzero.</summary>
		public byte tmStruckOut;

		/// <summary>
		/// <para>
		/// The pitch and family of the selected font. The low-order bit (bit 0) specifies the pitch of the font. If it is 1, the font is
		/// variable pitch (or proportional). If it is 0, the font is fixed pitch (or monospace). Bits 1 and 2 specify the font type. If both
		/// bits are 0, the font is a raster font; if bit 1 is 1 and bit 2 is 0, the font is a vector font; if bit 1 is 0 and bit 2 is set,
		/// or if both bits are 1, the font is some other type. Bit 3 is 1 if the font is a device font; otherwise, it is 0.
		/// </para>
		/// <para>
		/// The four high-order bits designate the font family. The <c>tmPitchAndFamily</c> member can be combined with the hexadecimal value
		/// 0xF0 by using the bitwise AND operator and can then be compared with the font family names for an identical match. For more
		/// information about the font families, see LOGFONT.
		/// </para>
		/// </summary>
		public byte tmPitchAndFamily;

		/// <summary>The character set of the font.</summary>
		public byte tmCharSet;

		/// <summary>
		/// <para>
		/// Specifies whether the font is italic, underscored, outlined, bold, and so forth. May be any reasonable combination of the
		/// following values.
		/// </para>
		/// <list type="table">
		/// <listheader>
		/// <term>Bit</term>
		/// <term>Name</term>
		/// <term>Meaning</term>
		/// </listheader>
		/// <item>
		/// <term>0</term>
		/// <term>NTM_ITALIC</term>
		/// <term>italic</term>
		/// </item>
		/// <item>
		/// <term>5</term>
		/// <term>NTM_BOLD</term>
		/// <term>bold</term>
		/// </item>
		/// <item>
		/// <term>8</term>
		/// <term>NTM_REGULAR</term>
		/// <term>regular</term>
		/// </item>
		/// <item>
		/// <term>16</term>
		/// <term>NTM_NONNEGATIVE_AC</term>
		/// <term>no glyph in a font at any size has a negative A or C space.</term>
		/// </item>
		/// <item>
		/// <term>17</term>
		/// <term>NTM_PS_OPENTYPE</term>
		/// <term>PostScript OpenType font</term>
		/// </item>
		/// <item>
		/// <term>18</term>
		/// <term>NTM_TT_OPENTYPE</term>
		/// <term>TrueType OpenType font</term>
		/// </item>
		/// <item>
		/// <term>19</term>
		/// <term>NTM_MULTIPLEMASTER</term>
		/// <term>multiple master font</term>
		/// </item>
		/// <item>
		/// <term>20</term>
		/// <term>NTM_TYPE1</term>
		/// <term>Type 1 font</term>
		/// </item>
		/// <item>
		/// <term>21</term>
		/// <term>NTM_DSIG</term>
		/// <term>font with a digital signature. This allows traceability and ensures that the font has been tested and is not corrupted</term>
		/// </item>
		/// </list>
		/// </summary>
		public uint ntmFlags;

		/// <summary>
		/// The size of the em square for the font. This value is in notional units (that is, the units for which the font was designed).
		/// </summary>
		public uint ntmSizeEM;

		/// <summary>
		/// The height, in notional units, of the font. This value should be compared with the value of the <c>ntmSizeEM</c> member.
		/// </summary>
		public uint ntmCellHeight;

		/// <summary>
		/// The average width of characters in the font, in notional units. This value should be compared with the value of the
		/// <c>ntmSizeEM</c> member.
		/// </summary>
		public uint ntmAvgWidth;
	}

	/// <summary>The <c>NEWTEXTMETRICEX</c> structure contains information about a physical font.</summary>
	// https://docs.microsoft.com/en-us/windows/win32/api/wingdi/ns-wingdi-newtextmetricexa typedef struct tagNEWTEXTMETRICEXA {
	// NEWTEXTMETRICA ntmTm; FONTSIGNATURE ntmFontSig; } NEWTEXTMETRICEXA;
	[PInvokeData("wingdi.h", MSDNShortId = "b85ff705-2dd4-4877-9905-d4c2a0894e24")]
	[StructLayout(LayoutKind.Sequential, CharSet = CharSet.Auto)]
	public struct NEWTEXTMETRICEX
	{
		/// <summary>A NEWTEXTMETRIC structure.</summary>
		public NEWTEXTMETRIC ntmTm;

		/// <summary>A FONTSIGNATURE structure indicating the coverage of the font.</summary>
		public FONTSIGNATURE ntmFontSig;
	}

	/// <summary>The <c>OUTLINETEXTMETRIC</c> structure contains metrics describing a TrueType font.</summary>
	/// <remarks>
	/// <para>
	/// The sizes returned in <c>OUTLINETEXTMETRIC</c> are specified in logical units; that is, they depend on the current mapping mode of
	/// the specified display context.
	/// </para>
	/// <para>
	/// Note, <c>OUTLINETEXTMETRIC</c> is defined using the current pack setting. To avoid problems, make sure that the application is built
	/// using the platform default packing. For example, 32-bit Windows uses a default of 8-byte packing. For more information, see the MSDN
	/// topic "C-Compiler Packing Issues".
	/// </para>
	/// </remarks>
	// https://docs.microsoft.com/en-us/windows/win32/api/wingdi/ns-wingdi-outlinetextmetrica typedef struct _OUTLINETEXTMETRICA { UINT
	// otmSize; TEXTMETRICA otmTextMetrics; BYTE otmFiller; PANOSE otmPanoseNumber; UINT otmfsSelection; UINT otmfsType; int
	// otmsCharSlopeRise; int otmsCharSlopeRun; int otmItalicAngle; UINT otmEMSquare; int otmAscent; int otmDescent; UINT otmLineGap; UINT
	// otmsCapEmHeight; UINT otmsXHeight; RECT otmrcFontBox; int otmMacAscent; int otmMacDescent; UINT otmMacLineGap; UINT otmusMinimumPPEM;
	// POINT otmptSubscriptSize; POINT otmptSubscriptOffset; POINT otmptSuperscriptSize; POINT otmptSuperscriptOffset; UINT
	// otmsStrikeoutSize; int otmsStrikeoutPosition; int otmsUnderscoreSize; int otmsUnderscorePosition; PSTR otmpFamilyName; PSTR
	// otmpFaceName; PSTR otmpStyleName; PSTR otmpFullName; } OUTLINETEXTMETRICA, *POUTLINETEXTMETRICA, *NPOUTLINETEXTMETRICA, *LPOUTLINETEXTMETRICA;
	[PInvokeData("wingdi.h", MSDNShortId = "79d77df0-193a-49a8-b93d-4ef5807c3c9b")]
	[StructLayout(LayoutKind.Sequential, CharSet = CharSet.Auto)]
	public struct OUTLINETEXTMETRIC()
	{
		/// <summary>The size, in bytes, of the <c>OUTLINETEXTMETRIC</c> structure.</summary>
		public uint otmSize = (uint)Marshal.SizeOf<OUTLINETEXTMETRIC>();

		/// <summary>A TEXTMETRIC structure containing further information about the font.</summary>
		public TEXTMETRIC otmTextMetrics;

		/// <summary>A value that causes the structure to be byte-aligned.</summary>
		public byte otmFiller;

		/// <summary>The PANOSE number for this font.</summary>
		public PANOSE otmPanoseNumber;

		/// <summary>
		/// <para>The nature of the font pattern. This member can be a combination of the following bits.</para>
		/// <list type="table">
		/// <listheader>
		/// <term>Bit</term>
		/// <term>Meaning</term>
		/// </listheader>
		/// <item>
		/// <term>0</term>
		/// <term>Italic</term>
		/// </item>
		/// <item>
		/// <term>1</term>
		/// <term>Underscore</term>
		/// </item>
		/// <item>
		/// <term>2</term>
		/// <term>Negative</term>
		/// </item>
		/// <item>
		/// <term>3</term>
		/// <term>Outline</term>
		/// </item>
		/// <item>
		/// <term>4</term>
		/// <term>Strikeout</term>
		/// </item>
		/// <item>
		/// <term>5</term>
		/// <term>Bold</term>
		/// </item>
		/// </list>
		/// </summary>
		public uint otmfsSelection;

		/// <summary>
		/// Indicates whether the font is licensed. Licensed fonts must not be modified or exchanged. If bit 1 is set, the font may not be
		/// embedded in a document. If bit 1 is clear, the font can be embedded. If bit 2 is set, the embedding is read-only.
		/// </summary>
		public uint otmfsType;

		/// <summary>
		/// The slope of the cursor. This value is 1 if the slope is vertical. Applications can use this value and the value of the
		/// <c>otmsCharSlopeRun</c> member to create an italic cursor that has the same slope as the main italic angle (specified by the
		/// <c>otmItalicAngle</c> member).
		/// </summary>
		public int otmsCharSlopeRise;

		/// <summary>
		/// The slope of the cursor. This value is zero if the slope is vertical. Applications can use this value and the value of the
		/// <c>otmsCharSlopeRise</c> member to create an italic cursor that has the same slope as the main italic angle (specified by the
		/// <c>otmItalicAngle</c> member).
		/// </summary>
		public int otmsCharSlopeRun;

		/// <summary>
		/// The main italic angle of the font, in tenths of a degree counterclockwise from vertical. Regular (roman) fonts have a value of
		/// zero. Italic fonts typically have a negative italic angle (that is, they lean to the right).
		/// </summary>
		public int otmItalicAngle;

		/// <summary>
		/// The number of logical units defining the x- or y-dimension of the em square for this font. (The number of units in the x- and
		/// y-directions are always the same for an em square.)
		/// </summary>
		public uint otmEMSquare;

		/// <summary>The maximum distance characters in this font extend above the base line. This is the typographic ascent for the font.</summary>
		public int otmAscent;

		/// <summary>
		/// The maximum distance characters in this font extend below the base line. This is the typographic descent for the font.
		/// </summary>
		public int otmDescent;

		/// <summary>The typographic line spacing.</summary>
		public uint otmLineGap;

		/// <summary>Not supported.</summary>
		public uint otmsCapEmHeight;

		/// <summary>Not supported.</summary>
		public uint otmsXHeight;

		/// <summary>The bounding box for the font.</summary>
		public RECT otmrcFontBox;

		/// <summary>The maximum distance characters in this font extend above the base line for the Macintosh computer.</summary>
		public int otmMacAscent;

		/// <summary>The maximum distance characters in this font extend below the base line for the Macintosh computer.</summary>
		public int otmMacDescent;

		/// <summary>The line-spacing information for the Macintosh computer.</summary>
		public uint otmMacLineGap;

		/// <summary>The smallest recommended size for this font, in pixels per em-square.</summary>
		public uint otmusMinimumPPEM;

		/// <summary>The recommended horizontal and vertical size for subscripts in this font.</summary>
		public POINT otmptSubscriptSize;

		/// <summary>
		/// The recommended horizontal and vertical offset for subscripts in this font. The subscript offset is measured from the character
		/// origin to the origin of the subscript character.
		/// </summary>
		public POINT otmptSubscriptOffset;

		/// <summary>The recommended horizontal and vertical size for superscripts in this font.</summary>
		public POINT otmptSuperscriptSize;

		/// <summary>
		/// The recommended horizontal and vertical offset for superscripts in this font. The superscript offset is measured from the
		/// character base line to the base line of the superscript character.
		/// </summary>
		public POINT otmptSuperscriptOffset;

		/// <summary>The width of the strikeout stroke for this font. Typically, this is the width of the em dash for the font.</summary>
		public uint otmsStrikeoutSize;

		/// <summary>
		/// The position of the strikeout stroke relative to the base line for this font. Positive values are above the base line and
		/// negative values are below.
		/// </summary>
		public int otmsStrikeoutPosition;

		/// <summary>The thickness of the underscore character for this font.</summary>
		public int otmsUnderscoreSize;

		/// <summary>The position of the underscore character for this font.</summary>
		public int otmsUnderscorePosition;

		/// <summary>The offset from the beginning of the structure to a string specifying the family name for the font.</summary>
		public nint otmpFamilyName;

		/// <summary>
		/// The offset from the beginning of the structure to a string specifying the typeface name for the font. (This typeface name
		/// corresponds to the name specified in the LOGFONT structure.)
		/// </summary>
		public nint otmpFaceName;

		/// <summary>The offset from the beginning of the structure to a string specifying the style name for the font.</summary>
		public nint otmpStyleName;

		/// <summary>
		/// The offset from the beginning of the structure to a string specifying the full name for the font. This name is unique for the
		/// font and often contains a version number or other identifying information.
		/// </summary>
		public nint otmpFullName;
	}

	/// <summary>
	/// The <c>PANOSE</c> structure describes the PANOSE font-classification values for a TrueType font. These characteristics are then used
	/// to associate the font with other fonts of similar appearance but different names.
	/// </summary>
	// https://docs.microsoft.com/en-us/windows/win32/api/wingdi/ns-wingdi-panose typedef struct tagPANOSE { BYTE bFamilyType; BYTE
	// bSerifStyle; BYTE bWeight; BYTE bProportion; BYTE bContrast; BYTE bStrokeVariation; BYTE bArmStyle; BYTE bLetterform; BYTE bMidline;
	// BYTE bXHeight; } PANOSE, *LPPANOSE;
	[PInvokeData("wingdi.h", MSDNShortId = "18aa4a36-8e47-4e35-973f-376d412ed923")]
	[StructLayout(LayoutKind.Sequential)]
	public struct PANOSE
	{
		/// <summary>
		/// <para>For Latin fonts, one of one of the following values.</para>
		/// <list type="table">
		/// <listheader>
		/// <term>Value</term>
		/// <term>Meaning</term>
		/// </listheader>
		/// <item>
		/// <term>PAN_ANY</term>
		/// <term>Any</term>
		/// </item>
		/// <item>
		/// <term>PAN_NO_FIT</term>
		/// <term>No fit</term>
		/// </item>
		/// <item>
		/// <term>PAN_FAMILY_TEXT_DISPLAY</term>
		/// <term>Text and display</term>
		/// </item>
		/// <item>
		/// <term>PAN_FAMILY_SCRIPT</term>
		/// <term>Script</term>
		/// </item>
		/// <item>
		/// <term>PAN_FAMILY_DECORATIVE</term>
		/// <term>Decorative</term>
		/// </item>
		/// <item>
		/// <term>PAN_FAMILY_PICTORIAL</term>
		/// <term>Pictorial</term>
		/// </item>
		/// </list>
		/// </summary>
		public PAN_FAMILY bFamilyType;

		/// <summary>
		/// <para>The serif style. For Latin fonts, one of the following values.</para>
		/// <list type="table">
		/// <listheader>
		/// <term>Value</term>
		/// <term>Meaning</term>
		/// </listheader>
		/// <item>
		/// <term>PAN_ANY</term>
		/// <term>Any</term>
		/// </item>
		/// <item>
		/// <term>PAN_NO_FIT</term>
		/// <term>No fit</term>
		/// </item>
		/// <item>
		/// <term>PAN_SERIF_COVE</term>
		/// <term>Cove</term>
		/// </item>
		/// <item>
		/// <term>PAN_SERIF_OBTUSE_COVE</term>
		/// <term>Obtuse cove</term>
		/// </item>
		/// <item>
		/// <term>PAN_SERIF_SQUARE_COVE</term>
		/// <term>Square cove</term>
		/// </item>
		/// <item>
		/// <term>PAN_SERIF_OBTUSE_SQUARE_COVE</term>
		/// <term>Obtuse square cove</term>
		/// </item>
		/// <item>
		/// <term>PAN_SERIF_SQUARE</term>
		/// <term>Square</term>
		/// </item>
		/// <item>
		/// <term>PAN_SERIF_THIN</term>
		/// <term>Thin</term>
		/// </item>
		/// <item>
		/// <term>PAN_SERIF_BONE</term>
		/// <term>Bone</term>
		/// </item>
		/// <item>
		/// <term>PAN_SERIF_EXAGGERATED</term>
		/// <term>Exaggerated</term>
		/// </item>
		/// <item>
		/// <term>PAN_SERIF_TRIANGLE</term>
		/// <term>Triangle</term>
		/// </item>
		/// <item>
		/// <term>PAN_SERIF_NORMAL_SANS</term>
		/// <term>Normal sans serif</term>
		/// </item>
		/// <item>
		/// <term>PAN_SERIF_OBTUSE_SANS</term>
		/// <term>Obtuse sans serif</term>
		/// </item>
		/// <item>
		/// <term>PAN_SERIF_PERP_SANS</term>
		/// <term>Perp sans serif</term>
		/// </item>
		/// <item>
		/// <term>PAN_SERIF_FLARED</term>
		/// <term>Flared</term>
		/// </item>
		/// <item>
		/// <term>PAN_SERIF_ROUNDED</term>
		/// <term>Rounded</term>
		/// </item>
		/// </list>
		/// </summary>
		public PAN_SERIF bSerifStyle;

		/// <summary>
		/// <para>For Latin fonts, one of the following values.</para>
		/// <list type="table">
		/// <listheader>
		/// <term>Value</term>
		/// <term>Meaning</term>
		/// </listheader>
		/// <item>
		/// <term>PAN_ANY</term>
		/// <term>Any</term>
		/// </item>
		/// <item>
		/// <term>PAN_NO_FIT</term>
		/// <term>No fit</term>
		/// </item>
		/// <item>
		/// <term>PAN_WEIGHT_VERY_LIGHT</term>
		/// <term>Very light</term>
		/// </item>
		/// <item>
		/// <term>PAN_WEIGHT_LIGHT</term>
		/// <term>Light</term>
		/// </item>
		/// <item>
		/// <term>PAN_WEIGHT_THIN</term>
		/// <term>Thin</term>
		/// </item>
		/// <item>
		/// <term>PAN_WEIGHT_BOOK</term>
		/// <term>Book</term>
		/// </item>
		/// <item>
		/// <term>PAN_WEIGHT_MEDIUM</term>
		/// <term>Medium</term>
		/// </item>
		/// <item>
		/// <term>PAN_WEIGHT_DEMI</term>
		/// <term>Demibold</term>
		/// </item>
		/// <item>
		/// <term>PAN_WEIGHT_BOLD</term>
		/// <term>Bold</term>
		/// </item>
		/// <item>
		/// <term>PAN_WEIGHT_HEAVY</term>
		/// <term>Heavy</term>
		/// </item>
		/// <item>
		/// <term>PAN_WEIGHT_BLACK</term>
		/// <term>Black</term>
		/// </item>
		/// <item>
		/// <term>PAN_WEIGHT_NORD</term>
		/// <term>Nord</term>
		/// </item>
		/// </list>
		/// </summary>
		public PAN_WEIGHT bWeight;

		/// <summary>
		/// <para>For Latin fonts, one of the following values.</para>
		/// <list type="table">
		/// <listheader>
		/// <term>Value</term>
		/// <term>Meaning</term>
		/// </listheader>
		/// <item>
		/// <term>PAN_ANY</term>
		/// <term>Any</term>
		/// </item>
		/// <item>
		/// <term>PAN_NO_FIT</term>
		/// <term>No fit</term>
		/// </item>
		/// <item>
		/// <term>PAN_PROP_OLD_STYLE</term>
		/// <term>Old style</term>
		/// </item>
		/// <item>
		/// <term>PAN_PROP_MODERN</term>
		/// <term>Modern</term>
		/// </item>
		/// <item>
		/// <term>PAN_PROP_EVEN_WIDTH</term>
		/// <term>Even width</term>
		/// </item>
		/// <item>
		/// <term>PAN_PROP_EXPANDED</term>
		/// <term>Expanded</term>
		/// </item>
		/// <item>
		/// <term>PAN_PROP_CONDENSED</term>
		/// <term>Condensed</term>
		/// </item>
		/// <item>
		/// <term>PAN_PROP_VERY_EXPANDED</term>
		/// <term>Very expanded</term>
		/// </item>
		/// <item>
		/// <term>PAN_PROP_VERY_CONDENSED</term>
		/// <term>Very condensed</term>
		/// </item>
		/// <item>
		/// <term>PAN_PROP_MONOSPACED</term>
		/// <term>Monospaced</term>
		/// </item>
		/// </list>
		/// </summary>
		public PAN_PROP bProportion;

		/// <summary>
		/// <para>For Latin fonts, one of the following values.</para>
		/// <list type="table">
		/// <listheader>
		/// <term>Value</term>
		/// <term>Meaning</term>
		/// </listheader>
		/// <item>
		/// <term>PAN_ANY</term>
		/// <term>Any</term>
		/// </item>
		/// <item>
		/// <term>PAN_NO_FIT</term>
		/// <term>No fit</term>
		/// </item>
		/// <item>
		/// <term>PAN_CONTRAST_NONE</term>
		/// <term>None</term>
		/// </item>
		/// <item>
		/// <term>PAN_CONTRAST_VERY_LOW</term>
		/// <term>Very low</term>
		/// </item>
		/// <item>
		/// <term>PAN_CONTRAST_LOW</term>
		/// <term>Low</term>
		/// </item>
		/// <item>
		/// <term>PAN_CONTRAST_MEDIUM_LOW</term>
		/// <term>Medium low</term>
		/// </item>
		/// <item>
		/// <term>PAN_CONTRAST_MEDIUM</term>
		/// <term>Medium</term>
		/// </item>
		/// <item>
		/// <term>PAN_CONTRAST_MEDIUM_HIGH</term>
		/// <term>Medium high</term>
		/// </item>
		/// <item>
		/// <term>PAN_CONTRAST_HIGH</term>
		/// <term>High</term>
		/// </item>
		/// <item>
		/// <term>PAN_CONTRAST_VERY_HIGH</term>
		/// <term>Very high</term>
		/// </item>
		/// </list>
		/// </summary>
		public PAN_CONTRAST bContrast;

		/// <summary>
		/// <para>For Latin fonts, one of the following values.</para>
		/// <list type="table">
		/// <listheader>
		/// <term>Value</term>
		/// <term>Meaning</term>
		/// </listheader>
		/// <item>
		/// <term>PAN_ANY</term>
		/// <term>Any</term>
		/// </item>
		/// <item>
		/// <term>PAN_NO_FIT</term>
		/// <term>No fit</term>
		/// </item>
		/// <item>
		/// <term>PAN_STROKE_GRADUAL_DIAG</term>
		/// <term>Gradual/diagonal</term>
		/// </item>
		/// <item>
		/// <term>PAN_STROKE_GRADUAL_TRAN</term>
		/// <term>Gradual/transitional</term>
		/// </item>
		/// <item>
		/// <term>PAN_STROKE_GRADUAL_VERT</term>
		/// <term>Gradual/vertical</term>
		/// </item>
		/// <item>
		/// <term>PAN_STROKE_GRADUAL_HORZ</term>
		/// <term>Gradual/horizontal</term>
		/// </item>
		/// <item>
		/// <term>PAN_STROKE_RAPID_VERT</term>
		/// <term>Rapid/vertical</term>
		/// </item>
		/// <item>
		/// <term>PAN_STROKE_RAPID_HORZ</term>
		/// <term>Rapid/horizontal</term>
		/// </item>
		/// <item>
		/// <term>PAN_STROKE_INSTANT_VERT</term>
		/// <term>Instant/vertical</term>
		/// </item>
		/// </list>
		/// </summary>
		public PAN_STROKE bStrokeVariation;

		/// <summary>
		/// <para>For Latin fonts, one of the following values.</para>
		/// <list type="table">
		/// <listheader>
		/// <term>Value</term>
		/// <term>Meaning</term>
		/// </listheader>
		/// <item>
		/// <term>PAN_ANY</term>
		/// <term>Any</term>
		/// </item>
		/// <item>
		/// <term>PAN_NO_FIT</term>
		/// <term>No fit</term>
		/// </item>
		/// <item>
		/// <term>PAN_STRAIGHT_ARMS_HORZ</term>
		/// <term>Straight arms/horizontal</term>
		/// </item>
		/// <item>
		/// <term>PAN_STRAIGHT_ARMS_WEDGE</term>
		/// <term>Straight arms/wedge</term>
		/// </item>
		/// <item>
		/// <term>PAN_STRAIGHT_ARMS_VERT</term>
		/// <term>Straight arms/vertical</term>
		/// </item>
		/// <item>
		/// <term>PAN_STRAIGHT_ARMS_SINGLE_SERIF</term>
		/// <term>Straight arms/single-serif</term>
		/// </item>
		/// <item>
		/// <term>PAN_STRAIGHT_ARMS_DOUBLE_SERIF</term>
		/// <term>Straight arms/double-serif</term>
		/// </item>
		/// <item>
		/// <term>PAN_BENT_ARMS_HORZ</term>
		/// <term>Nonstraight arms/horizontal</term>
		/// </item>
		/// <item>
		/// <term>PAN_BENT_ARMS_WEDGE</term>
		/// <term>Nonstraight arms/wedge</term>
		/// </item>
		/// <item>
		/// <term>PAN_BENT_ARMS_VERT</term>
		/// <term>Nonstraight arms/vertical</term>
		/// </item>
		/// <item>
		/// <term>PAN_BENT_ARMS_SINGLE_SERIF</term>
		/// <term>Nonstraight arms/single-serif</term>
		/// </item>
		/// <item>
		/// <term>PAN_BENT_ARMS_DOUBLE_SERIF</term>
		/// <term>Nonstraight arms/double-serif</term>
		/// </item>
		/// </list>
		/// </summary>
		public PAN_ARMS bArmStyle;

		/// <summary>
		/// <para>For Latin fonts, one of the following values.</para>
		/// <list type="table">
		/// <listheader>
		/// <term>Value</term>
		/// <term>Meaning</term>
		/// </listheader>
		/// <item>
		/// <term>PAN_ANY</term>
		/// <term>Any</term>
		/// </item>
		/// <item>
		/// <term>PAN_NO_FIT</term>
		/// <term>No fit</term>
		/// </item>
		/// <item>
		/// <term>PAN_LETT_NORMAL_CONTACT</term>
		/// <term>Normal/contact</term>
		/// </item>
		/// <item>
		/// <term>PAN_LETT_NORMAL_WEIGHTED</term>
		/// <term>Normal/weighted</term>
		/// </item>
		/// <item>
		/// <term>PAN_LETT_NORMAL_BOXED</term>
		/// <term>Normal/boxed</term>
		/// </item>
		/// <item>
		/// <term>PAN_LETT_NORMAL_FLATTENED</term>
		/// <term>Normal/flattened</term>
		/// </item>
		/// <item>
		/// <term>PAN_LETT_NORMAL_ROUNDED</term>
		/// <term>Normal/rounded</term>
		/// </item>
		/// <item>
		/// <term>PAN_LETT_NORMAL_OFF_CENTER</term>
		/// <term>Normal/off center</term>
		/// </item>
		/// <item>
		/// <term>PAN_LETT_NORMAL_SQUARE</term>
		/// <term>Normal/square</term>
		/// </item>
		/// <item>
		/// <term>PAN_LETT_OBLIQUE_CONTACT</term>
		/// <term>Oblique/contact</term>
		/// </item>
		/// <item>
		/// <term>PAN_LETT_OBLIQUE_WEIGHTED</term>
		/// <term>Oblique/weighted</term>
		/// </item>
		/// <item>
		/// <term>PAN_LETT_OBLIQUE_BOXED</term>
		/// <term>Oblique/boxed</term>
		/// </item>
		/// <item>
		/// <term>PAN_LETT_OBLIQUE_FLATTENED</term>
		/// <term>Oblique/flattened</term>
		/// </item>
		/// <item>
		/// <term>PAN_LETT_OBLIQUE_ROUNDED</term>
		/// <term>Oblique/rounded</term>
		/// </item>
		/// <item>
		/// <term>PAN_LETT_OBLIQUE_OFF_CENTER</term>
		/// <term>Oblique/off center</term>
		/// </item>
		/// <item>
		/// <term>PAN_LETT_OBLIQUE_SQUARE</term>
		/// <term>Oblique/square</term>
		/// </item>
		/// </list>
		/// </summary>
		public PAN_LETT bLetterform;

		/// <summary>
		/// <para>For Latin fonts, one of the following values.</para>
		/// <list type="table">
		/// <listheader>
		/// <term>Value</term>
		/// <term>Meaning</term>
		/// </listheader>
		/// <item>
		/// <term>PAN_ANY</term>
		/// <term>Any</term>
		/// </item>
		/// <item>
		/// <term>PAN_NO_FIT</term>
		/// <term>No fit</term>
		/// </item>
		/// <item>
		/// <term>PAN_MIDLINE_STANDARD_TRIMMED</term>
		/// <term>Standard/trimmed</term>
		/// </item>
		/// <item>
		/// <term>PAN_MIDLINE_STANDARD_POINTED</term>
		/// <term>Standard/pointed</term>
		/// </item>
		/// <item>
		/// <term>PAN_MIDLINE_STANDARD_SERIFED</term>
		/// <term>Standard/serifed</term>
		/// </item>
		/// <item>
		/// <term>PAN_MIDLINE_HIGH_TRIMMED</term>
		/// <term>High/trimmed</term>
		/// </item>
		/// <item>
		/// <term>PAN_MIDLINE_HIGH_POINTED</term>
		/// <term>High/pointed</term>
		/// </item>
		/// <item>
		/// <term>PAN_MIDLINE_HIGH_SERIFED</term>
		/// <term>High/serifed</term>
		/// </item>
		/// <item>
		/// <term>PAN_MIDLINE_CONSTANT_TRIMMED</term>
		/// <term>Constant/trimmed</term>
		/// </item>
		/// <item>
		/// <term>PAN_MIDLINE_CONSTANT_POINTED</term>
		/// <term>Constant/pointed</term>
		/// </item>
		/// <item>
		/// <term>PAN_MIDLINE_CONSTANT_SERIFED</term>
		/// <term>Constant/serifed</term>
		/// </item>
		/// <item>
		/// <term>PAN_MIDLINE_LOW_TRIMMED</term>
		/// <term>Low/trimmed</term>
		/// </item>
		/// <item>
		/// <term>PAN_MIDLINE_LOW_POINTED</term>
		/// <term>Low/pointed</term>
		/// </item>
		/// <item>
		/// <term>PAN_MIDLINE_LOW_SERIFED</term>
		/// <term>Low/serifed</term>
		/// </item>
		/// </list>
		/// </summary>
		public PAN_MIDLINE bMidline;

		/// <summary>
		/// <para>For Latin fonts, one of the following values.</para>
		/// <list type="table">
		/// <listheader>
		/// <term>Value</term>
		/// <term>Meaning</term>
		/// </listheader>
		/// <item>
		/// <term>PAN_ANY</term>
		/// <term>Any</term>
		/// </item>
		/// <item>
		/// <term>PAN_NO_FIT</term>
		/// <term>No fit</term>
		/// </item>
		/// <item>
		/// <term>PAN_XHEIGHT_CONSTANT_SMALL</term>
		/// <term>Constant/small</term>
		/// </item>
		/// <item>
		/// <term>PAN_XHEIGHT_CONSTANT_STD</term>
		/// <term>Constant/standard</term>
		/// </item>
		/// <item>
		/// <term>PAN_XHEIGHT_CONSTANT_LARGE</term>
		/// <term>Constant/large</term>
		/// </item>
		/// <item>
		/// <term>PAN_XHEIGHT_DUCKING_SMALL</term>
		/// <term>Ducking/small</term>
		/// </item>
		/// <item>
		/// <term>PAN_XHEIGHT_DUCKING_STD</term>
		/// <term>Ducking/standard</term>
		/// </item>
		/// <item>
		/// <term>PAN_XHEIGHT_DUCKING_LARGE</term>
		/// <term>Ducking/large</term>
		/// </item>
		/// </list>
		/// </summary>
		public PAN_XHEIGHT bXHeight;
	}

	/// <summary>
	/// The <c>POINTFX</c> structure contains the coordinates of points that describe the outline of a character in a TrueType font.
	/// </summary>
	/// <remarks>
	/// The <c>POINTFX</c> structure is a member of the TTPOLYCURVE and TTPOLYGONHEADER structures. Values in the <c>POINTFX</c> structure
	/// are specified in device units.
	/// </remarks>
	// https://learn.microsoft.com/en-us/windows/win32/api/wingdi/ns-wingdi-pointfx typedef struct tagPOINTFX { FIXED x; FIXED y; } POINTFX, *LPPOINTFX;
	[PInvokeData("wingdi.h", MSDNShortId = "NS:wingdi.tagPOINTFX")]
	[StructLayout(LayoutKind.Sequential)]
	public struct POINTFX
	{
		/// <summary>The x-component of a point on the outline of a TrueType character.</summary>
		public FIXED x;

		/// <summary>The y-component of a point on the outline of a TrueType character.</summary>
		public FIXED y;
	}

	/// <summary>The <c>POLYTEXT</c> structure describes how the PolyTextOut function should draw a string of text.</summary>
	// https://docs.microsoft.com/en-us/windows/win32/api/wingdi/ns-wingdi-polytextw typedef struct tagPOLYTEXTW { int x; int y; UINT n;
	// LPCWSTR lpstr; UINT uiFlags; RECT rcl; int *pdx; } POLYTEXTW, *PPOLYTEXTW, *NPPOLYTEXTW, *LPPOLYTEXTW;
	[PInvokeData("wingdi.h", MSDNShortId = "6f03e2ff-c15f-498c-8c3d-33106222279e")]
	[StructLayout(LayoutKind.Sequential, CharSet = CharSet.Auto)]
	public struct POLYTEXT(int x, int y, string str, ETO flags = 0, in RECT rect = default, ArrayPointer<int> dx = default)
	{
		/// <summary>
		/// The horizontal reference point for the string. The string is aligned to this point using the current text-alignment mode.
		/// </summary>
		public int x = x;

		/// <summary>
		/// The vertical reference point for the string. The string is aligned to this point using the current text-alignment mode.
		/// </summary>
		public int y = y;

		/// <summary>The length of the string pointed to by <c>lpstr</c>.</summary>
		public uint n = (uint)(str?.Length ?? 0);

		/// <summary>
		/// Pointer to a string of text to be drawn by the PolyTextOut function. This string need not be null-terminated, since <c>n</c>
		/// specifies the length of the string.
		/// </summary>
		[MarshalAs(UnmanagedType.LPTStr)]
		public string lpstr = str ?? "";

		/// <summary>
		/// <para>
		/// Specifies whether the string is to be opaque or clipped and whether the string is accompanied by an array of character-width
		/// values. This member can be one or more of the following values.
		/// </para>
		/// <list type="table">
		/// <listheader>
		/// <term>Value</term>
		/// <term>Meaning</term>
		/// </listheader>
		/// <item>
		/// <term>ETO_OPAQUE</term>
		/// <term>The rectangle for each string is to be opaqued with the current background color.</term>
		/// </item>
		/// <item>
		/// <term>ETO_CLIPPED</term>
		/// <term>Each string is to be clipped to its specified rectangle.</term>
		/// </item>
		/// </list>
		/// </summary>
		public ETO uiFlags = flags;

		/// <summary>
		/// A rectangle structure that contains the dimensions of the opaquing or clipping rectangle. This member is ignored if neither of
		/// the ETO_OPAQUE nor the ETO_CLIPPED value is specified for the <c>uiFlags</c> member.
		/// </summary>
		public RECT rcl = rect;

		/// <summary>Pointer to an array containing the width value for each character in the string.</summary>
		public ArrayPointer<int> pdx = dx;
	}

	/// <summary>
	/// The <c>RASTERIZER_STATUS</c> structure contains information about whether TrueType is installed. This structure is filled when an
	/// application calls the GetRasterizerCaps function.
	/// </summary>
	// https://docs.microsoft.com/en-us/windows/win32/api/wingdi/ns-wingdi-rasterizer_status typedef struct _RASTERIZER_STATUS { short nSize;
	// short wFlags; short nLanguageID; } RASTERIZER_STATUS, *LPRASTERIZER_STATUS;
	[PInvokeData("wingdi.h", MSDNShortId = "40bb4b59-90a4-4780-ae5f-fef8a6fa62cb")]
	[StructLayout(LayoutKind.Sequential)]
	public struct RASTERIZER_STATUS
	{
		/// <summary>The size, in bytes, of the <c>RASTERIZER_STATUS</c> structure.</summary>
		public short nSize;

		/// <summary>
		/// Specifies whether at least one TrueType font is installed and whether TrueType is enabled. This value is TT_AVAILABLE,
		/// TT_ENABLED, or both if TrueType is on the system.
		/// </summary>
		public TT wFlags;

		/// <summary>The language in the system's Setup.inf file.</summary>
		public short nLanguageID;
	}

	/// <summary>The <c>TTPOLYCURVE</c> structure contains information about a curve in the outline of a TrueType character.</summary>
	/// <remarks>
	/// <para>
	/// When an application calls the GetGlyphOutline function, a glyph outline for a TrueType character is returned in a TTPOLYGONHEADER
	/// structure, followed by as many <c>TTPOLYCURVE</c> structures as are required to describe the glyph. All points are returned as
	/// POINTFX structures and represent absolute positions, not relative moves. The starting point specified by the <c>pfxStart</c> member
	/// of the <c>TTPOLYGONHEADER</c> structure is the point at which the outline for a contour begins. The <c>TTPOLYCURVE</c> structures
	/// that follow can be either polyline records or spline records.
	/// </para>
	/// <para>
	/// Polyline records are a series of points; lines drawn between the points describe the outline of the character. Spline records
	/// represent the quadratic curves (that is, quadratic b-splines) used by TrueType.
	/// </para>
	/// </remarks>
	// https://learn.microsoft.com/en-us/windows/win32/api/wingdi/ns-wingdi-ttpolycurve typedef struct tagTTPOLYCURVE { WORD wType; WORD
	// cpfx; POINTFX apfx[1]; } TTPOLYCURVE, *LPTTPOLYCURVE;
	[PInvokeData("wingdi.h", MSDNShortId = "NS:wingdi.tagTTPOLYCURVE")]
	[VanaraMarshaler(typeof(SafeAnysizeStructMarshaler<TTPOLYCURVE>), nameof(cpfx))]
	[StructLayout(LayoutKind.Sequential)]
	public struct TTPOLYCURVE
	{
		/// <summary>
		/// <para>The type of curve described by the structure. This member can be one of the following values.</para>
		/// <list type="table">
		/// <listheader>
		/// <description>Value</description>
		/// <description>Meaning</description>
		/// </listheader>
		/// <item>
		/// <description>TT_PRIM_LINE</description>
		/// <description>Curve is a polyline.</description>
		/// </item>
		/// <item>
		/// <description>TT_PRIM_QSPLINE</description>
		/// <description>Curve is a quadratic BÃ©zier spline.</description>
		/// </item>
		/// <item>
		/// <description>TT_PRIM_CSPLINE</description>
		/// <description>Curve is a cubic BÃ©zier spline.</description>
		/// </item>
		/// </list>
		/// </summary>
		public TT_PRIM wType;

		/// <summary>The number of POINTFX structures in the array.</summary>
		public ushort cpfx;

		/// <summary>Specifies an array of POINTFX structures that define the polyline or BÃ©zier spline.</summary>
		[MarshalAs(UnmanagedType.ByValArray, SizeConst = 1)]
		public POINTFX[] apfx;
	}

	/// <summary>The <c>TTPOLYGONHEADER</c> structure specifies the starting position and type of a contour in a TrueType character outline.</summary>
	/// <remarks>Each <c>TTPOLYGONHEADER</c> structure is followed by one or more TTPOLYCURVE structures.</remarks>
	// https://learn.microsoft.com/en-us/windows/win32/api/wingdi/ns-wingdi-ttpolygonheader typedef struct tagTTPOLYGONHEADER { DWORD cb;
	// DWORD dwType; POINTFX pfxStart; } TTPOLYGONHEADER, *LPTTPOLYGONHEADER;
	[PInvokeData("wingdi.h", MSDNShortId = "NS:wingdi.tagTTPOLYGONHEADER")]
	[StructLayout(LayoutKind.Sequential)]
	public struct TTPOLYGONHEADER
	{
		/// <summary>
		/// The number of bytes required by the <c>TTPOLYGONHEADER</c> structure and TTPOLYCURVE structure or structures required to describe
		/// the contour of the character.
		/// </summary>
		public uint cb;

		/// <summary>The type of character outline returned. Currently, this value must be TT_POLYGON_TYPE.</summary>
		public TT_TYPE dwType;

		/// <summary>The starting point of the contour in the character outline.</summary>
		public POINTFX pfxStart;
	}

	/// <summary>The <c>WCRANGE</c> structure specifies a range of Unicode characters.</summary>
	// https://docs.microsoft.com/en-us/windows/win32/api/wingdi/ns-wingdi-wcrange typedef struct tagWCRANGE { WCHAR wcLow; USHORT cGlyphs; }
	// WCRANGE, *PWCRANGE, *LPWCRANGE;
	[PInvokeData("wingdi.h", MSDNShortId = "20959057-6062-4c1e-a23d-535584ba6ea3")]
	[StructLayout(LayoutKind.Sequential)]
	public struct WCRANGE
	{
		/// <summary>Low Unicode code point in the range of supported Unicode code points.</summary>
		public ushort wcLow;

		/// <summary>Number of supported Unicode code points in this range.</summary>
		public ushort cGlyphs;
	}
}