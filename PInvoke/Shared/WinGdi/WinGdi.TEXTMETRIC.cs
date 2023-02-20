using System.Runtime.InteropServices;

namespace Vanara.PInvoke;

/// <summary>
/// The <c>TEXTMETRIC</c> structure contains basic information about a physical font. All sizes are specified in logical units; that
/// is, they depend on the current mapping mode of the display context.
/// </summary>
// https://docs.microsoft.com/en-us/windows/desktop/api/wingdi/ns-wingdi-tagtextmetrica typedef struct tagTEXTMETRICA { LONG
// tmHeight; LONG tmAscent; LONG tmDescent; LONG tmInternalLeading; LONG tmExternalLeading; LONG tmAveCharWidth; LONG tmMaxCharWidth;
// LONG tmWeight; LONG tmOverhang; LONG tmDigitizedAspectX; LONG tmDigitizedAspectY; BYTE tmFirstChar; BYTE tmLastChar; BYTE
// tmDefaultChar; BYTE tmBreakChar; BYTE tmItalic; BYTE tmUnderlined; BYTE tmStruckOut; BYTE tmPitchAndFamily; BYTE tmCharSet; }
// TEXTMETRICA, *PTEXTMETRICA, *NPTEXTMETRICA, *LPTEXTMETRICA;
[PInvokeData("wingdi.h", MSDNShortId = "0a46da58-5d0f-4db4-bba6-9e1b6c1f892c")]
[StructLayout(LayoutKind.Sequential, CharSet = CharSet.Auto)]
public struct TEXTMETRIC
{
	/// <summary>
	/// <para>The height (ascent + descent) of characters.</para>
	/// </summary>
	public int tmHeight;

	/// <summary>
	/// <para>The ascent (units above the base line) of characters.</para>
	/// </summary>
	public int tmAscent;

	/// <summary>
	/// <para>The descent (units below the base line) of characters.</para>
	/// </summary>
	public int tmDescent;

	/// <summary>
	/// <para>
	/// The amount of leading (space) inside the bounds set by the <c>tmHeight</c> member. Accent marks and other diacritical
	/// characters may occur in this area. The designer may set this member to zero.
	/// </para>
	/// </summary>
	public int tmInternalLeading;

	/// <summary>
	/// <para>
	/// The amount of extra leading (space) that the application adds between rows. Since this area is outside the font, it contains
	/// no marks and is not altered by text output calls in either OPAQUE or TRANSPARENT mode. The designer may set this member to zero.
	/// </para>
	/// </summary>
	public int tmExternalLeading;

	/// <summary>
	/// <para>
	/// The average width of characters in the font (generally defined as the width of the letter x ). This value does not include
	/// the overhang required for bold or italic characters.
	/// </para>
	/// </summary>
	public int tmAveCharWidth;

	/// <summary>
	/// <para>The width of the widest character in the font.</para>
	/// </summary>
	public int tmMaxCharWidth;

	/// <summary>
	/// <para>The weight of the font.</para>
	/// </summary>
	public int tmWeight;

	/// <summary>
	/// <para>
	/// The extra width per string that may be added to some synthesized fonts. When synthesizing some attributes, such as bold or
	/// italic, graphics device interface (GDI) or a device may have to add width to a string on both a per-character and per-string
	/// basis. For example, GDI makes a string bold by expanding the spacing of each character and overstriking by an offset value;
	/// it italicizes a font by shearing the string. In either case, there is an overhang past the basic string. For bold strings,
	/// the overhang is the distance by which the overstrike is offset. For italic strings, the overhang is the amount the top of the
	/// font is sheared past the bottom of the font.
	/// </para>
	/// <para>
	/// The <c>tmOverhang</c> member enables the application to determine how much of the character width returned by a
	/// GetTextExtentPoint32 function call on a single character is the actual character width and how much is the per-string extra
	/// width. The actual width is the extent minus the overhang.
	/// </para>
	/// </summary>
	public int tmOverhang;

	/// <summary>
	/// <para>The horizontal aspect of the device for which the font was designed.</para>
	/// </summary>
	public int tmDigitizedAspectX;

	/// <summary>
	/// <para>
	/// The vertical aspect of the device for which the font was designed. The ratio of the <c>tmDigitizedAspectX</c> and
	/// <c>tmDigitizedAspectY</c> members is the aspect ratio of the device for which the font was designed.
	/// </para>
	/// </summary>
	public int tmDigitizedAspectY;

	/// <summary>
	/// <para>The value of the first character defined in the font.</para>
	/// </summary>
	public char tmFirstChar;

	/// <summary>
	/// <para>The value of the last character defined in the font.</para>
	/// </summary>
	public char tmLastChar;

	/// <summary>
	/// <para>The value of the character to be substituted for characters not in the font.</para>
	/// </summary>
	public char tmDefaultChar;

	/// <summary>
	/// <para>The value of the character that will be used to define word breaks for text justification.</para>
	/// </summary>
	public char tmBreakChar;

	/// <summary>
	/// <para>Specifies an italic font if it is nonzero.</para>
	/// </summary>
	public byte tmItalic;

	/// <summary>
	/// <para>Specifies an underlined font if it is nonzero.</para>
	/// </summary>
	public byte tmUnderlined;

	/// <summary>
	/// <para>A strikeout font if it is nonzero.</para>
	/// </summary>
	public byte tmStruckOut;

	/// <summary>
	/// <para>Specifies information about the pitch, the technology, and the family of a physical font.</para>
	/// <para>
	/// The four low-order bits of this member specify information about the pitch and the technology of the font. A constant is
	/// defined for each of the four bits.
	/// </para>
	/// <list type="table">
	/// <listheader>
	/// <term>Constant</term>
	/// <term>Meaning</term>
	/// </listheader>
	/// <item>
	/// <term>TMPF_FIXED_PITCH</term>
	/// <term>
	/// If this bit is set the font is a variable pitch font. If this bit is clear the font is a fixed pitch font. Note very
	/// carefully that those meanings are the opposite of what the constant name implies.
	/// </term>
	/// </item>
	/// <item>
	/// <term>TMPF_VECTOR</term>
	/// <term>If this bit is set the font is a vector font.</term>
	/// </item>
	/// <item>
	/// <term>TMPF_TRUETYPE</term>
	/// <term>If this bit is set the font is a TrueType font.</term>
	/// </item>
	/// <item>
	/// <term>TMPF_DEVICE</term>
	/// <term>If this bit is set the font is a device font.</term>
	/// </item>
	/// </list>
	/// <para>
	/// An application should carefully test for qualities encoded in these low-order bits, making no arbitrary assumptions. For
	/// example, besides having their own bits set, TrueType and PostScript fonts set the TMPF_VECTOR bit. A monospace bitmap font
	/// has all of these low-order bits clear; a proportional bitmap font sets the TMPF_FIXED_PITCH bit. A Postscript printer device
	/// font sets the TMPF_DEVICE, TMPF_VECTOR, and TMPF_FIXED_PITCH bits.
	/// </para>
	/// <para>
	/// The four high-order bits of <c>tmPitchAndFamily</c> designate the font's font family. An application can use the value 0xF0
	/// and the bitwise AND operator to mask out the four low-order bits of <c>tmPitchAndFamily</c>, thus obtaining a value that can
	/// be directly compared with font family names to find an identical match. For information about font families, see the
	/// description of the LOGFONT structure.
	/// </para>
	/// </summary>
	public byte tmPitchAndFamily;

	/// <summary>
	/// <para>The character set of the font. The character set can be one of the following values.</para>
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
	/// </summary>
	public CharacterSet tmCharSet;
}