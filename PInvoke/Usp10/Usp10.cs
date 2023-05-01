#pragma warning disable IDE1006 // Naming Styles

using System;
using System.Runtime.InteropServices;
using Vanara.Extensions;

namespace Vanara.PInvoke;

/// <summary>Items from the Usp10.dll.</summary>
public static partial class Usp10
{
	/// <summary>
	/// SCRIPT_UNDEFINED: This is the only public script ordinal. May be forced into the eScript field of a SCRIPT_ANALYSIS to disable
	/// shaping. SCRIPT_UNDEFINED is supported by all fonts - ScriptShape will display whatever glyph is defined in the font CMAP table,
	/// or, if none, the missing glyph.
	/// </summary>
	public const ushort SCRIPT_UNDEFINED = 0;

	/// <summary>Substitution type. This member is normally set by ScriptRecordDigitSubstitution.</summary>
	[PInvokeData("usp10.h", MSDNShortId = "NS:usp10.tag_SCRIPT_DIGITSUBSTITUTE")]
	public enum SCRIPT_DIGITSUB : byte
	{
		/// <summary>
		/// SCRIPT_DIGITSUBSTITUTE_CONTEXT: Digits U+0030 - U+0039 will be substituted according to the language of prior letters. Before
		/// any letters, digits will be substituted according to the TraditionalDigitLangauge field of the SCRIPT_DIGIT_SUBSTITUTE
		/// structure. This field is normally set to the primary language of the Locale passed to ScriptRecordDigitSubstitution.
		/// </summary>
		SCRIPT_DIGITSUBSTITUTE_CONTEXT = 0,

		/// <summary>
		/// SCRIPT_DIGITSUBSTITUTE_NONE: Digits will not be substituted. Unicode values U+0030 to U+0039 will be displayed with Arabic (i.e.
		/// Western) numerals.
		/// </summary>
		SCRIPT_DIGITSUBSTITUTE_NONE = 1,

		/// <summary>
		/// SCRIPT_DIGITSUBSTITUTE_NATIONAL: Digits U+0030 - U+0039 will be substituted according to the NationalDigitLangauge field of
		/// the SCRIPT_DIGIT_SUBSTITUTE structure. This field is normally set to the national digits returned for the NLS LCTYPE
		/// LOCALE_SNATIVEDIGITS by ScriptRecordDigitSubstitution.
		/// </summary>
		SCRIPT_DIGITSUBSTITUTE_NATIONAL = 2,

		/// <summary>
		/// SCRIPT_DIGITSUBSTITUTE_TRADITIONAL: Digits U+0030 - U+0039 will be substituted according to the TraditionalDigitLangauge
		/// field of the SCRIPT_DIGIT_SUBSTITUTE structure. This field is normally set to the primary language of the Locale passed to ScriptRecordDigitSubstitution.
		/// </summary>
		SCRIPT_DIGITSUBSTITUTE_TRADITIONAL = 3,
	}

	/// <summary>Defines glyph characteristic information that an application needs to implement justification.</summary>
	// https://docs.microsoft.com/en-us/windows/win32/api/usp10/ne-usp10-script_justify typedef enum tag_SCRIPT_JUSTIFY {
	// SCRIPT_JUSTIFY_NONE = 0, SCRIPT_JUSTIFY_ARABIC_BLANK = 1, SCRIPT_JUSTIFY_CHARACTER = 2, SCRIPT_JUSTIFY_RESERVED1 = 3,
	// SCRIPT_JUSTIFY_BLANK = 4, SCRIPT_JUSTIFY_RESERVED2 = 5, SCRIPT_JUSTIFY_RESERVED3 = 6, SCRIPT_JUSTIFY_ARABIC_NORMAL = 7,
	// SCRIPT_JUSTIFY_ARABIC_KASHIDA = 8, SCRIPT_JUSTIFY_ARABIC_ALEF = 9, SCRIPT_JUSTIFY_ARABIC_HA = 10, SCRIPT_JUSTIFY_ARABIC_RA = 11,
	// SCRIPT_JUSTIFY_ARABIC_BA = 12, SCRIPT_JUSTIFY_ARABIC_BARA = 13, SCRIPT_JUSTIFY_ARABIC_SEEN = 14, SCRIPT_JUSTIFY_ARABIC_SEEN_M = 15
	// } SCRIPT_JUSTIFY;
	[PInvokeData("usp10.h", MSDNShortId = "NE:usp10.tag_SCRIPT_JUSTIFY")]
	public enum SCRIPT_JUSTIFY : ushort
	{
		/// <summary>Justification cannot be applied at the glyph.</summary>
		SCRIPT_JUSTIFY_NONE,

		/// <summary>The glyph represents a blank in an Arabic run.</summary>
		SCRIPT_JUSTIFY_ARABIC_BLANK = 1,

		/// <summary>An inter-character justification point follows the glyph.</summary>
		SCRIPT_JUSTIFY_CHARACTER = 2,

		/// <summary>Reserved.</summary>
		SCRIPT_JUSTIFY_RESERVED1 = 3,

		/// <summary>The glyph represents a blank outside an Arabic run.</summary>
		SCRIPT_JUSTIFY_BLANK = 4,

		/// <summary>Reserved.</summary>
		SCRIPT_JUSTIFY_RESERVED2 = 5,

		/// <summary>Reserved.</summary>
		SCRIPT_JUSTIFY_RESERVED3 = 6,

		/// <summary>Normal middle-of-word glyph that connects to the right (begin).</summary>
		SCRIPT_JUSTIFY_ARABIC_NORMAL = 7,

		/// <summary>Kashida (U+0640) in the middle of the word.</summary>
		SCRIPT_JUSTIFY_ARABIC_KASHIDA = 8,

		/// <summary>Final form of an alef-like (U+0627, U+0625, U+0623, U+0622).</summary>
		SCRIPT_JUSTIFY_ARABIC_ALEF = 9,

		/// <summary>Final form of Ha (U+0647).</summary>
		SCRIPT_JUSTIFY_ARABIC_HA = 10,

		/// <summary>Final form of Ra (U+0631).</summary>
		SCRIPT_JUSTIFY_ARABIC_RA = 11,

		/// <summary>Final form of Ba (U+0628).</summary>
		SCRIPT_JUSTIFY_ARABIC_BA = 12,

		/// <summary>Ligature of alike (U+0628,U+0631).</summary>
		SCRIPT_JUSTIFY_ARABIC_BARA = 13,

		/// <summary>Highest priority: initial shape of Seen class (U+0633).</summary>
		SCRIPT_JUSTIFY_ARABIC_SEEN = 14,

		/// <summary>Highest priority: medial shape of Seen class (U+0633).</summary>
		SCRIPT_JUSTIFY_ARABIC_SEEN_M = 15
	}

	/// <summary>
	/// Flags specifying any special handling of the glyphs. By default, the glyphs are provided in logical order with no special handling.
	/// </summary>
	[PInvokeData("usp10.h", MSDNShortId = "NF:usp10.ScriptGetCMap")]
	[Flags]
	public enum SGCM : uint
	{
		/// <summary>
		/// The glyph array indicated by <c>pwOutGlyphs</c> should contain mirrored glyphs for those glyphs that have a mirrored equivalent.
		/// </summary>
		SGCM_RTL = 0x00000001
	}

	/// <summary>Flags specifying testing details.</summary>
	[Flags]
	public enum SIC : uint
	{
		/// <summary>Treat complex script letters as complex. This flag should normally be set.</summary>
		SIC_COMPLEX = 1,

		/// <summary>
		/// Treat digits U+0030 to U+0039 as complex. The application sets this flag if the string is displayed with digit substitution
		/// enabled. If the application is following the user's National Language Support (NLS) settings using the
		/// ScriptRecordDigitSubstitution function, it can pass a SCRIPT_DIGITSUBSTITUTE structure with the <c>DigitSubstitute</c> member
		/// set to SCRIPT_DIGITSUBSTITUTE_NONE.
		/// </summary>
		SIC_ASCIIDIGIT = 2,

		/// <summary>Treat neutrals as complex. The application sets this flag to display the string with right-to-left reading order.</summary>
		SIC_NEUTRAL = 4,
	}

	/// <summary>Flags indicating the analysis that is required.</summary>
	[PInvokeData("usp10.h", MSDNShortId = "NF:usp10.ScriptShapeOpenType")]
	[Flags]
	public enum SSA : uint
	{
		/// <summary>Retrieve break flags, that is, character and word stops.</summary>
		SSA_BREAK = 0x00000040,

		/// <summary>Clip the string at <c>iReqWidth.</c></summary>
		SSA_CLIP = 0x00000004,

		/// <summary>Internal - Used only by GDI during metafiling - Use ExtTextOutA for positioning</summary>
		SSA_DONTGLYPH = 0x40000000,

		/// <summary>Provide representation glyphs for control characters.</summary>
		SSA_DZWG = 0x00000010,

		/// <summary>Use fallback fonts.</summary>
		SSA_FALLBACK = 0x00000020,

		/// <summary>Justify the string to <c>iReqWidth</c>.</summary>
		SSA_FIT = 0x00000008,

		/// <summary>Internal - calculate full width and out the number of chars can fit in iReqWidth.</summary>
		SSA_FULLMEASURE = 0x04000000,

		/// <summary>Retrieve missing glyphs and <c>pwLogClust</c> with GetCharacterPlacement conventions.</summary>
		SSA_GCP = 0x00000200,

		/// <summary>Generate glyphs, positions, and attributes.</summary>
		SSA_GLYPHS = 0x00000080,

		/// <summary>Remove the first "&amp;" from displayed string.</summary>
		SSA_HIDEHOTKEY = 0x00002000,

		/// <summary>Replace "&amp;" with underline on subsequent code point.</summary>
		SSA_HOTKEY = 0x00000400,

		/// <summary>
		/// Display underline only. The resulting bit pattern might be displayed, using an XOR mask, to toggle the visibility of the
		/// hotkey underline without disturbing the text.
		/// </summary>
		SSA_HOTKEYONLY = 0x00002400,

		/// <summary>Internal - Used when DC is mirrored</summary>
		SSA_LAYOUTRTL = 0x20000000,

		/// <summary>Apply East Asian font linking and association to noncomplex text.</summary>
		SSA_LINK = 0x00001000,

		/// <summary>Internal - enable FallBack for all LPK Ansi calls Except BiDi hDC calls</summary>
		SSA_LPKANSIFALLBACK = 0x08000000,

		/// <summary>Write items with ExtTextOutW calls, not with glyphs.</summary>
		SSA_METAFILE = 0x00000800,

		/// <summary>Internal - Used by GCP to justify the non Arabic glyphs only.</summary>
		SSA_NOKASHIDA = 0x80000000,

		/// <summary>Duplicate input string containing a single character <c>cString</c> times.</summary>
		SSA_PASSWORD = 0x00000001,

		/// <summary>Internal</summary>
		SSA_PIDX = 0x10000000,

		/// <summary>Use base embedding level 1.</summary>
		SSA_RTL = 0x00000100,

		/// <summary>Expand tabs.</summary>
		SSA_TAB = 0x00000002,
	}

	/// <summary>Contains the x and y offsets of the combining glyph.</summary>
	/// <remarks>
	/// The members of this structure are named as they are so that they are not confused with the "dx" and "dy" designators for physical
	/// units in Uniscribe functions and structures.
	/// </remarks>
	// https://docs.microsoft.com/en-us/windows/win32/api/usp10/ns-usp10-goffset typedef struct tagGOFFSET { LONG du; LONG dv; } GOFFSET;
	[PInvokeData("usp10.h", MSDNShortId = "NS:usp10.tagGOFFSET")]
	[StructLayout(LayoutKind.Sequential)]
	public struct GOFFSET
	{
		/// <summary>x offset, in logical units, for the combining glyph.</summary>
		public int du;

		/// <summary>y offset, in logical units, for the combining glyph.</summary>
		public int dv;
	}

	/// <summary>Contains information about a single OpenType feature to apply to a run.</summary>
	// https://docs.microsoft.com/en-us/windows/win32/api/usp10/ns-usp10-opentype_feature_record typedef struct opentype_feature_record {
	// OPENTYPE_TAG tagFeature; LONG lParameter; } OPENTYPE_FEATURE_RECORD;
	[PInvokeData("usp10.h", MSDNShortId = "NS:usp10.opentype_feature_record")]
	[StructLayout(LayoutKind.Sequential)]
	public struct OPENTYPE_FEATURE_RECORD
	{
		/// <summary>
		/// OPENTYPE_TAG value containing a registered or private OpenType feature tag. For information on feature tags, see http://www.microsoft.com/typography/otspec/featuretags.htm.
		/// </summary>
		public uint tagFeature;

		/// <summary>
		/// <para>Value indicating how to apply the feature tag. Possible values are defined in the following table.</para>
		/// <list type="table">
		/// <listheader>
		/// <term>Value</term>
		/// <term>Description</term>
		/// </listheader>
		/// <item>
		/// <term>0</term>
		/// <term>Feature is disabled and should not be applied.</term>
		/// </item>
		/// <item>
		/// <term>1</term>
		/// <term>Feature is active. If the feature offers several alternatives, select the first value.</term>
		/// </item>
		/// <item>
		/// <term>Greater than 1</term>
		/// <term>
		/// Feature is active. Select the alternative value at this index. Should be used only when multiple alternatives are available
		/// for a feature.
		/// </term>
		/// </item>
		/// </list>
		/// </summary>
		public int lParameter;
	}

	/// <summary>
	/// Defines a 4-byte array that contains four 8-bit ASCII values of space, A-Z, or a-z to identify OpenType script, language, and
	/// font feature tags.
	/// </summary>
	/// <remarks>
	/// <para>The following examples define representations of OpenType feature tags.</para>
	/// <list type="bullet">
	/// <item>
	/// <term>The feature tag for the ligature feature is "liga".</term>
	/// </item>
	/// <item>
	/// <term>
	/// The language tags for Romanian, Urdu, and Persian are "ROM ", "URD ", and "FAR ", respectively. Note that each of these tags ends
	/// with a space.
	/// </term>
	/// </item>
	/// <item>
	/// <term>The script tags for Latin and Arabic scripts are "latn" and "arab", respectively.</term>
	/// </item>
	/// </list>
	/// <para>For more information on OpenType feature tags and the OpenType specification, see <a href="https://www.microsoft.com/typography/otspec/featuretags.htm">https://www.microsoft.com/typography/otspec/featuretags.htm</a>.</para>
	/// </remarks>
	// https://docs.microsoft.com/en-us/windows/win32/intl/opentype-tag
	[PInvokeData("usp10.h")]
	[StructLayout(LayoutKind.Sequential)]
	public struct OPENTYPE_TAG : IEquatable<OPENTYPE_TAG>
	{
		/// <summary>When all characters in an item are neutral.</summary>
		public const uint SCRIPT_TAG_UNKNOWN = 0x00000000;

		private readonly uint value;

		/// <summary>Creates an <see cref="OPENTYPE_TAG"/> from a <see cref="uint"/> value.</summary>
		public OPENTYPE_TAG(uint value) => this.value = value;

		/// <summary>Creates an <see cref="OPENTYPE_TAG"/> from four characters.</summary>
		/// <param name="a">The first character.</param>
		/// <param name="b">The second character.</param>
		/// <param name="c">The third character.</param>
		/// <param name="d">The fourth character.</param>
		public OPENTYPE_TAG(char a, char b, char c, char d) : this(new byte[] { (byte)a, (byte)b, (byte)c, (byte)d }) { }

		/// <summary>Creates an <see cref="OPENTYPE_TAG"/> from a four character string.</summary>
		/// <param name="tag">The four character string.</param>
		public OPENTYPE_TAG(string tag) : this(tag.GetBytes(false, CharSet.Ansi)) { }

		/// <summary>Creates an <see cref="OPENTYPE_TAG"/> from a four characters array.</summary>
		/// <param name="chars">The four character array.</param>
		public OPENTYPE_TAG(char[] chars) : this(Array.ConvertAll(chars, c => (byte)c)) { }

		/// <summary>Creates an <see cref="OPENTYPE_TAG"/> from a four byte array.</summary>
		/// <param name="bytes">The four byte array.</param>
		public OPENTYPE_TAG(byte[] bytes) : this(bytes.Length == 4 ? BitConverter.ToUInt32(bytes, 0) :
			throw new ArgumentOutOfRangeException(nameof(bytes), "Value must have only four elements.")) { }

		/// <summary>Performs an implicit conversion from <see cref="OPENTYPE_TAG"/> to <see cref="System.UInt32"/>.</summary>
		/// <param name="tag">The tag.</param>
		/// <returns>The result of the conversion.</returns>
		public static implicit operator uint(OPENTYPE_TAG tag) => tag.value;

		/// <summary>Performs an implicit conversion from <see cref="System.UInt32"/> to <see cref="OPENTYPE_TAG"/>.</summary>
		/// <param name="tag">The tag.</param>
		/// <returns>The result of the conversion.</returns>
		public static implicit operator OPENTYPE_TAG(uint tag) => new(tag);

		/// <summary>Performs an implicit conversion from <see cref="string"/> to <see cref="OPENTYPE_TAG"/>.</summary>
		/// <param name="tag">The tag.</param>
		/// <returns>The result of the conversion.</returns>
		public static implicit operator OPENTYPE_TAG(string tag) => new(tag);

		/// <summary>Determines whether the specified <see cref="System.Object"/>, is equal to this instance.</summary>
		/// <param name="obj">The <see cref="System.Object"/> to compare with this instance.</param>
		/// <returns>
		/// <see langword="true"/> if the specified <see cref="System.Object"/> is equal to this instance; otherwise, <see langword="false"/>.
		/// </returns>
		public override bool Equals(object? obj) => obj is OPENTYPE_TAG tAG && Equals(tAG);

		/// <summary>Determines whether the specified <see cref="OPENTYPE_TAG"/>, is equal to this instance.</summary>
		/// <param name="other">The <see cref="OPENTYPE_TAG"/> to compare with this instance.</param>
		/// <returns>
		/// <see langword="true"/> if the specified <see cref="OPENTYPE_TAG"/> is equal to this instance; otherwise, <see langword="false"/>.
		/// </returns>
		public bool Equals(OPENTYPE_TAG other) => value==other.value;

		/// <summary>Returns a hash code for this instance.</summary>
		/// <returns>A hash code for this instance, suitable for use in hashing algorithms and data structures like a hash table.</returns>
		public override int GetHashCode() => value.GetHashCode();

		/// <summary>Converts to string.</summary>
		/// <returns>A <see cref="string"/> that represents this instance.</returns>
		public override string ToString()
		{
			if (value == SCRIPT_TAG_UNKNOWN)
				return "Unknown";
			var bytes = BitConverter.GetBytes(value);
			return $"'{(char)bytes[0]}{(char)bytes[1]}{(char)bytes[2]}{(char)bytes[3]}'";
		}
	}

	/// <summary>Contains a portion of a Unicode string, that is, an "item".</summary>
	/// <remarks>
	/// <para>
	/// This structure is filled by ScriptItemize or ScriptItemizeOpenType, each of which breaks a Unicode string into individually
	/// shapeable items. Neither function accesses the <c>SCRIPT_ANALYSIS</c> structure directly. Each function handles an array of
	/// SCRIPT_ITEM structures, each of which has a member defining a <c>SCRIPT_ANALYSIS</c> structure.
	/// </para>
	/// <para>
	/// Applications that use ScriptItemizeOpenType instead of ScriptItemize should also use ScriptShapeOpenType and ScriptPlaceOpenType
	/// instead of ScriptShape and ScriptPlace. For more information, see Displaying Text with Uniscribe.
	/// </para>
	/// </remarks>
	// https://docs.microsoft.com/en-us/windows/win32/api/usp10/ns-usp10-script_analysis typedef struct tag_SCRIPT_ANALYSIS { WORD
	// eScript : 10; WORD fRTL : 1; WORD fLayoutRTL : 1; WORD fLinkBefore : 1; WORD fLinkAfter : 1; WORD fLogicalOrder : 1; WORD
	// fNoGlyphIndex : 1; SCRIPT_STATE s; } SCRIPT_ANALYSIS;
	[PInvokeData("usp10.h", MSDNShortId = "NS:usp10.tag_SCRIPT_ANALYSIS")]
	[StructLayout(LayoutKind.Sequential)]
	public struct SCRIPT_ANALYSIS
	{
		private ushort bits;

		/// <summary>Initializes a new instance of the <see cref="SCRIPT_ANALYSIS"/> struct.</summary>
		/// <param name="bits">The bits.</param>
		/// <param name="state">The state.</param>
		public SCRIPT_ANALYSIS(ushort bits, SCRIPT_STATE state) => (this.bits, s) = (bits, state);

		/// <summary>
		/// <para>
		/// Opaque value identifying the engine that Uniscribe uses when calling the ScriptShape, ScriptPlace, and ScriptTextOut
		/// functions for the item. The value for this member is undefined and applications should not rely on its value being the same
		/// from one release to the next. An application can obtain the attributes of <c>eScript</c> by calling ScriptGetProperties.
		/// </para>
		/// <para>To disable shaping, the application should set this member to <see cref="SCRIPT_UNDEFINED"/>.</para>
		/// </summary>
		public ushort eScript { get => BitHelper.GetBits(bits, 0, 10); set => BitHelper.SetBits(ref bits, 0, 10, value); }

		/// <summary>
		/// <para>
		/// Value indicating rendering direction. Possible values are defined in the following table. This member is set to <c>TRUE</c>
		/// for a number in a left-to-right run, because digits are always displayed left to right, or <c>FALSE</c> for a number in a
		/// right-to-left run. The value of this member is normally identical to the parity of the Unicode embedding level, but it might
		/// differ if overridden by GetCharacterPlacement legacy support.
		/// </para>
		/// <list type="table">
		/// <listheader>
		/// <term>Value</term>
		/// <term>Meaning</term>
		/// </listheader>
		/// <item>
		/// <term><c><c>TRUE</c></c></term>
		/// <term>Use a right-to-left rendering direction.</term>
		/// </item>
		/// <item>
		/// <term><c><c>FALSE</c></c></term>
		/// <term>Use a left-to-right rendering direction.</term>
		/// </item>
		/// </list>
		/// </summary>
		public bool fRTL { get => BitHelper.GetBit(bits, 10); set => BitHelper.SetBit(ref bits, 10, value); }

		/// <summary>
		/// <para>
		/// Value indicating layout direction for a number. Possible values are defined in the following table. This member is usually
		/// the same as the value assigned to <c>fRTL</c> for a number in a right-to-left run.
		/// </para>
		/// <list type="table">
		/// <listheader>
		/// <term>Value</term>
		/// <term>Meaning</term>
		/// </listheader>
		/// <item>
		/// <term><c><c>TRUE</c></c></term>
		/// <term>Lay out the number in a right-to-left run, because it is read as part of the right-to-left sequence.</term>
		/// </item>
		/// <item>
		/// <term><c><c>FALSE</c></c></term>
		/// <term>Lay out the number in a left-to-right run, because it is read as part of the left-to-right sequence.</term>
		/// </item>
		/// </list>
		/// </summary>
		public bool fLayoutRTL { get => BitHelper.GetBit(bits, 11); set => BitHelper.SetBit(ref bits, 11, value); }

		/// <summary>
		/// <para>
		/// Value indicating if the shaping engine shapes the first character of the item as if it joins with a previous character.
		/// Possible values are defined in the following table. This member is set by ScriptItemize. The application can override the
		/// value before calling ScriptShape.
		/// </para>
		/// <list type="table">
		/// <listheader>
		/// <term>Value</term>
		/// <term>Meaning</term>
		/// </listheader>
		/// <item>
		/// <term><c><c>TRUE</c></c></term>
		/// <term>Shape the first character by linking with a previous character.</term>
		/// </item>
		/// <item>
		/// <term><c><c>FALSE</c></c></term>
		/// <term>Do not shape the first character by linking with a previous character.</term>
		/// </item>
		/// </list>
		/// </summary>
		public bool fLinkBefore { get => BitHelper.GetBit(bits, 12); set => BitHelper.SetBit(ref bits, 12, value); }

		/// <summary>
		/// <para>
		/// Value indicating if the shaping engine shapes the last character of the item as if it joins with a subsequent character.
		/// Possible values are defined in the following table. This member is set by ScriptItemize. The application can override the
		/// value before calling <c>ScriptItemize</c>.
		/// </para>
		/// <list type="table">
		/// <listheader>
		/// <term>Value</term>
		/// <term>Meaning</term>
		/// </listheader>
		/// <item>
		/// <term><c><c>TRUE</c></c></term>
		/// <term>Shape the last character by linking with a subsequent character.</term>
		/// </item>
		/// <item>
		/// <term><c><c>FALSE</c></c></term>
		/// <term>Do not shape the last character by linking with a subsequent character.</term>
		/// </item>
		/// </list>
		/// </summary>
		public bool fLinkAfter { get => BitHelper.GetBit(bits, 13); set => BitHelper.SetBit(ref bits, 13, value); }

		/// <summary>
		/// <para>
		/// Value indicating if the shaping engine generates all glyph-related arrays in logical order. Possible values are defined in
		/// the following table. This member is set to <c>FALSE</c> by ScriptItemize. The application can override the value before
		/// calling ScriptShape.
		/// </para>
		/// <list type="table">
		/// <listheader>
		/// <term>Value</term>
		/// <term>Meaning</term>
		/// </listheader>
		/// <item>
		/// <term><c><c>TRUE</c></c></term>
		/// <term>Generate all glyph-related arrays in logical order.</term>
		/// </item>
		/// <item>
		/// <term><c><c>FALSE</c></c></term>
		/// <term>
		/// Generate all glyph-related arrays in visual order, with the first array entry corresponding to the leftmost glyph. This value
		/// is the default.
		/// </term>
		/// </item>
		/// </list>
		/// </summary>
		public bool fLogicalOrder { get => BitHelper.GetBit(bits, 14); set => BitHelper.SetBit(ref bits, 14, value); }

		/// <summary>
		/// <para>
		/// Value indicating the use of glyphs for the item. Possible values are defined in the following table. The application can set
		/// this member to <c>TRUE</c> on input to ScriptShape to disable the use of glyphs for the item. Additionally,
		/// <c>ScriptShape</c> sets it to <c>TRUE</c> for a hardware context containing symbolic, unrecognized, and device fonts.
		/// </para>
		/// <para>
		/// Disabling the use of glyphs also disables complex script shaping. Setting this member to <c>TRUE</c> implements shaping and
		/// placing directly by calls to GetTextExtentExPoint and ExtTextOut.
		/// </para>
		/// <list type="table">
		/// <listheader>
		/// <term>Value</term>
		/// <term>Meaning</term>
		/// </listheader>
		/// <item>
		/// <term><c><c>TRUE</c></c></term>
		/// <term>Disable the use of glyphs for the item. This value is used for bitmap, vector, and device fonts.</term>
		/// </item>
		/// <item>
		/// <term><c><c>FALSE</c></c></term>
		/// <term>Enable the use of glyphs for the item. This value is the default.</term>
		/// </item>
		/// </list>
		/// </summary>
		public bool fNoGlyphIndex { get => BitHelper.GetBit(bits, 15); set => BitHelper.SetBit(ref bits, 15, value); }

		/// <summary>A SCRIPT_STATE structure containing a copy of the Unicode algorithm state.</summary>
		public SCRIPT_STATE s;
	}

	/// <summary>
	/// Contains information about a single character in a run (input string). The information indicates if the character glyph is
	/// affected by surrounding letters of the run.
	/// </summary>
	/// <remarks>
	/// <para>
	/// One or more characters in a run, immediately preceding and/or following the letter being shaped, can influence shaping.
	/// Information about these characters can help optimize higher-level layout code, such as that used to optimize paragraph layout.
	/// </para>
	/// <para>Examples</para>
	/// <para>Let's look at an example of the use of this structure.</para>
	/// <list type="bullet">
	/// <item>
	/// <term>A font has ligatures for letter combinations "fi" and "fl", and no others.</term>
	/// </item>
	/// <item>
	/// <term>The input string is "I like flying fish".</term>
	/// </item>
	/// <item>
	/// <term>An array of <c>SCRIPT_CHARPROP</c> structures contains one structure for each character of the input string.</term>
	/// </item>
	/// </list>
	/// <para>For the provided input string, the array of structures has the following values in the <c>fCanGlyphAlone</c> members:</para>
	/// <para>
	/// <code>I like flying fish 111111100111110011</code>
	/// </para>
	/// </remarks>
	// https://docs.microsoft.com/en-us/windows/win32/api/usp10/ns-usp10-script_charprop typedef struct script_charprop { WORD
	// fCanGlyphAlone : 1; WORD reserved : 15; } SCRIPT_CHARPROP;
	[PInvokeData("usp10.h", MSDNShortId = "NS:usp10.script_charprop")]
	[StructLayout(LayoutKind.Sequential)]
	public struct SCRIPT_CHARPROP
	{
		private ushort bits;

		/// <summary>
		/// <para>
		/// Value indicating if the shaping of a letter depends on other characters around the letter being shaped. Possible values are
		/// defined in the following table.
		/// </para>
		/// <list type="table">
		/// <listheader>
		/// <term>Value</term>
		/// <term>Meaning</term>
		/// </listheader>
		/// <item>
		/// <term>TRUE</term>
		/// <term>The shape of a letter is independent of surrounding characters.</term>
		/// </item>
		/// <item>
		/// <term>FALSE</term>
		/// <term>The shape of a letter depends on one or more adjacent characters.</term>
		/// </item>
		/// </list>
		/// </summary>
		public bool fCanGlyphAlone { get => BitHelper.GetBit(bits, 0); set => BitHelper.SetBit(ref bits, 0, value); }

		/// <summary>Reserved.</summary>
		public ushort reserved { get => BitHelper.GetBits(bits, 1, 15); set => BitHelper.SetBits(ref bits, 1, 15, value); }
	}

	/// <summary>Contains script control flags for several Uniscribe functions, for example, ScriptItemize.</summary>
	// https://docs.microsoft.com/en-us/windows/win32/api/usp10/ns-usp10-script_control typedef struct tag_SCRIPT_CONTROL { DWORD
	// uDefaultLanguage : 16; DWORD fContextDigits : 1; DWORD fInvertPreBoundDir : 1; DWORD fInvertPostBoundDir : 1; DWORD
	// fLinkStringBefore : 1; DWORD fLinkStringAfter : 1; DWORD fNeutralOverride : 1; DWORD fNumericOverride : 1; DWORD fLegacyBidiClass
	// : 1; DWORD fMergeNeutralItems : 1; DWORD fUseStandardBidi : 1; DWORD fReserved : 6; } SCRIPT_CONTROL;
	[PInvokeData("usp10.h", MSDNShortId = "NS:usp10.tag_SCRIPT_CONTROL")]
	[StructLayout(LayoutKind.Sequential)]
	public struct SCRIPT_CONTROL
	{
		/// <summary>
		/// Primary language identifier for the language to use when Unicode values are ambiguous. This value is used in numeric
		/// processing to select digit shape when the <c>fDigitSubstitute</c> member of SCRIPT_STATE is set.
		/// </summary>
		public ushort uDefaultLanguage;

		private ushort bits;

		/// <summary>
		/// <para>Value indicating how national digits are selected. Possible values are defined in the following table.</para>
		/// <list type="table">
		/// <listheader>
		/// <term>Value</term>
		/// <term>Meaning</term>
		/// </listheader>
		/// <item>
		/// <term><c>TRUE</c></term>
		/// <term>Choose national digits according to the nearest previous strong text.</term>
		/// </item>
		/// <item>
		/// <term><c>FALSE</c></term>
		/// <term>Choose national digits according to the value of the <c>uDefaultLanguage</c> member.</term>
		/// </item>
		/// </list>
		/// </summary>
		public bool fContextDigits { get => BitHelper.GetBit(bits, 0); set => BitHelper.SetBit(ref bits, 0, value); }

		/// <summary>
		/// <para>
		/// Value indicating if the initial context is set to the opposite of the base embedding level, or to the base embedding level
		/// itself. Possible values are defined in the following table. The application sets this member to indicate that text at the
		/// start of the string defaults to being laid out as if it follows a strong left-to-right character if the base embedding level
		/// is 0, and as if it follows a strong right-to-left character if the base embedding level is 1. This member is used for
		/// GetCharacterPlacement legacy support.
		/// </para>
		/// <list type="table">
		/// <listheader>
		/// <term>Value</term>
		/// <term>Meaning</term>
		/// </listheader>
		/// <item>
		/// <term><c>TRUE</c></term>
		/// <term>Change the initial context to the opposite of the base embedding level.</term>
		/// </item>
		/// <item>
		/// <term><c>FALSE</c></term>
		/// <term>Set the initial context to the base embedding level.</term>
		/// </item>
		/// </list>
		/// </summary>
		public bool fInvertPreBoundDir { get => BitHelper.GetBit(bits, 1); set => BitHelper.SetBit(ref bits, 1, value); }

		/// <summary>
		/// <para>
		/// Value indicating if the final context is set to the opposite of the base embedding level, or to the base embedding level
		/// itself. Possible values are defined in the following table. The application sets this member to indicate that text at the end
		/// of the string defaults to being laid out as if it precedes strong text of the same direction as the base embedding level. It
		/// is used for GetCharacterPlacement legacy support.
		/// </para>
		/// <list type="table">
		/// <listheader>
		/// <term>Value</term>
		/// <term>Meaning</term>
		/// </listheader>
		/// <item>
		/// <term><c>TRUE</c></term>
		/// <term>Change the final context to the opposite of the base embedding level.</term>
		/// </item>
		/// <item>
		/// <term><c>FALSE</c></term>
		/// <term>Set the final context to the base embedding level.</term>
		/// </item>
		/// </list>
		/// </summary>
		public bool fInvertPostBoundDir { get => BitHelper.GetBit(bits, 2); set => BitHelper.SetBit(ref bits, 2, value); }

		/// <summary>
		/// <para>
		/// Value indicating if the shaping engine shapes the first character of the string as if it joins with a previous character.
		/// Possible values are defined in the following table.
		/// </para>
		/// <list type="table">
		/// <listheader>
		/// <term>Value</term>
		/// <term>Meaning</term>
		/// </listheader>
		/// <item>
		/// <term><c>TRUE</c></term>
		/// <term>Shape the first character by linking with a previous character.</term>
		/// </item>
		/// <item>
		/// <term><c>FALSE</c></term>
		/// <term>Do not shape the first character by linking with a previous character.</term>
		/// </item>
		/// </list>
		/// </summary>
		public bool fLinkStringBefore { get => BitHelper.GetBit(bits, 3); set => BitHelper.SetBit(ref bits, 3, value); }

		/// <summary>
		/// <para>
		/// Value indicating if the shaping engine shapes the last character of the string as if it is joined to a subsequent character.
		/// Possible values are defined in the following table.
		/// </para>
		/// <list type="table">
		/// <listheader>
		/// <term>Value</term>
		/// <term>Meaning</term>
		/// </listheader>
		/// <item>
		/// <term><c>TRUE</c></term>
		/// <term>Shape the last character by linking with a subsequent character.</term>
		/// </item>
		/// <item>
		/// <term><c>FALSE</c></term>
		/// <term>Do not shape the last character by linking with a subsequent character.</term>
		/// </item>
		/// </list>
		/// </summary>
		public bool fLinkStringAfter { get => BitHelper.GetBit(bits, 4); set => BitHelper.SetBit(ref bits, 4, value); }

		/// <summary>
		/// <para>
		/// Value indicating the treatment of all neutral characters in the string. Possible values are defined in the following table.
		/// </para>
		/// <list type="table">
		/// <listheader>
		/// <term>Value</term>
		/// <term>Meaning</term>
		/// </listheader>
		/// <item>
		/// <term><c>TRUE</c></term>
		/// <term>
		/// Set neutral items to a strong direction, that is, right-to-left or left-to-right, depending on the current embedding level.
		/// This setting effectively locks the items in place, and reordering occurs only between neutrals.
		/// </term>
		/// </item>
		/// <item>
		/// <term><c>FALSE</c></term>
		/// <term>Do not set neutral items to a strong direction.</term>
		/// </item>
		/// </list>
		/// </summary>
		public bool fNeutralOverride { get => BitHelper.GetBit(bits, 5); set => BitHelper.SetBit(ref bits, 5, value); }

		/// <summary>
		/// <para>
		/// Value indicating the treatment of all numeric characters in the string. Possible values are defined in the following table.
		/// </para>
		/// <list type="table">
		/// <listheader>
		/// <term>Value</term>
		/// <term>Meaning</term>
		/// </listheader>
		/// <item>
		/// <term><c>TRUE</c></term>
		/// <term>
		/// Set numeric characters to a strong direction, that is, right-to-left or left-to-right, depending on the current embedding
		/// level. This setting effectively locks the items in place, and reordering occurs only between numeric characters.
		/// </term>
		/// </item>
		/// <item>
		/// <term><c>FALSE</c></term>
		/// <term>Do not set numeric characters to a strong direction.</term>
		/// </item>
		/// </list>
		/// </summary>
		public bool fNumericOverride { get => BitHelper.GetBit(bits, 6); set => BitHelper.SetBit(ref bits, 6, value); }

		/// <summary>
		/// <para>
		/// Value indicating the handling for plus and minus characters by the shaping engine. Possible values are defined in the
		/// following table.
		/// </para>
		/// <list type="table">
		/// <listheader>
		/// <term>Value</term>
		/// <term>Meaning</term>
		/// </listheader>
		/// <item>
		/// <term><c>TRUE</c></term>
		/// <term>
		/// Treat the plus and minus characters as for legacy bidirectional classes in pre-Windows XP operating systems. In this case,
		/// the characters are treated as neutral characters, that is, with no implied direction, and the slash character is treated as a
		/// common separator.
		/// </term>
		/// </item>
		/// <item>
		/// <term><c>FALSE</c></term>
		/// <term>
		/// Treat the plus and minus characters as for Windows XP and later. In this case, the characters are treated as European separators.
		/// </term>
		/// </item>
		/// </list>
		/// </summary>
		public bool fLegacyBidiClass { get => BitHelper.GetBit(bits, 7); set => BitHelper.SetBit(ref bits, 7, value); }

		/// <summary>
		/// <para>
		/// Value specifying if the shaping engine should merge neutral characters into strong items when possible. Possible values are
		/// defined in the following table.
		/// </para>
		/// <list type="table">
		/// <listheader>
		/// <term>Value</term>
		/// <term>Meaning</term>
		/// </listheader>
		/// <item>
		/// <term><c>TRUE</c></term>
		/// <term>Merge neutral characters into strong items.</term>
		/// </item>
		/// <item>
		/// <term><c>FALSE</c></term>
		/// <term>Do not merge neutral characters into strong items.</term>
		/// </item>
		/// </list>
		/// </summary>
		public bool fMergeNeutralItems { get => BitHelper.GetBit(bits, 8); set => BitHelper.SetBit(ref bits, 8, value); }

		/// <summary>
		/// <para>
		/// Value specifying if the shaping engine should use the standard bidirectional matching pair algorithm. Possible values are
		/// defined in the following table.
		/// </para>
		/// <list type="table">
		/// <listheader>
		/// <term>Value</term>
		/// <term>Meaning</term>
		/// </listheader>
		/// <item>
		/// <term><c>TRUE</c></term>
		/// <term>Skip the matching pair algorithm.</term>
		/// </item>
		/// <item>
		/// <term><c>FALSE</c></term>
		/// <term>Use the matching pair algorithm.</term>
		/// </item>
		/// </list>
		/// </summary>
		public bool fUseStandardBidi { get => BitHelper.GetBit(bits, 9); set => BitHelper.SetBit(ref bits, 9, value); }

		/// <summary>Reserved; always initialize to 0.</summary>
		public ushort fReserved { get => BitHelper.GetBits(bits, 10, 6); set => BitHelper.SetBits(ref bits, 10, 6, value); }
	}

	/// <summary>Contains native digit and digit substitution settings.</summary>
	// https://docs.microsoft.com/en-us/windows/win32/api/usp10/ns-usp10-script_digitsubstitute typedef struct tag_SCRIPT_DIGITSUBSTITUTE
	// { DWORD NationalDigitLanguage : 16; DWORD TraditionalDigitLanguage : 16; DWORD DigitSubstitute : 8; DWORD dwReserved; } SCRIPT_DIGITSUBSTITUTE;
	[PInvokeData("usp10.h", MSDNShortId = "NS:usp10.tag_SCRIPT_DIGITSUBSTITUTE")]
	[StructLayout(LayoutKind.Sequential, Pack = 1)]
	public struct SCRIPT_DIGITSUBSTITUTE
	{
		/// <summary>Language for native substitution.</summary>
		public ushort NationalDigitLanguage;

		/// <summary>Language for traditional substitution.</summary>
		public ushort TraditionalDigitLanguage;

		/// <summary>
		/// <para>
		/// Substitution type. This member is normally set by ScriptRecordDigitSubstitution. However, it can also have any of the values
		/// defined in the following table.
		/// </para>
		/// <list type="table">
		/// <listheader>
		/// <term>Value</term>
		/// <term>Meaning</term>
		/// </listheader>
		/// <item>
		/// <term><c>SCRIPT_DIGITSUBSTITUTE_CONTEXT</c></term>
		/// <term>
		/// Substitute digits U+0030 to U+0039 using the language of the prior letters. If there are no prior letters, substitute digits
		/// using the <c>TraditionalDigitLanguage</c> member. This member is normally set to the primary language of the locale passed to ScriptRecordDigitSubstitution.
		/// </term>
		/// </item>
		/// <item>
		/// <term><c>SCRIPT_DIGITSUBSTITUTE_NATIONAL</c></term>
		/// <term>
		/// Substitute digits U+0030 to U+0039 using the <c>NationalDigitLanguage</c> member. This member is normally set to the national
		/// digits retrieved for the constant LOCALE_SNATIVEDIGITS by ScriptRecordDigitSubstitution.
		/// </term>
		/// </item>
		/// <item>
		/// <term><c>SCRIPT_DIGITSUBSTITUTE_NONE</c></term>
		/// <term>Do not substitute digits. Display Unicode values U+0030 to U+0039 with European numerals.</term>
		/// </item>
		/// <item>
		/// <term><c>SCRIPT_DIGITSUBSTITUTE_TRADITIONAL</c></term>
		/// <term>
		/// Substitute digits U+0030 to U+0039 using the <c>TraditionalDigitLanguage</c> member. This member is normally set to the
		/// primary language of the locale passed to ScriptRecordDigitSubstitution.
		/// </term>
		/// </item>
		/// </list>
		/// </summary>
		public SCRIPT_DIGITSUB DigitSubstitute;

		/// <summary>Reserved; initialize to 0.</summary>
		public uint dwReserved;
	}

	/// <summary>Contains information about the properties of the current font.</summary>
	// https://docs.microsoft.com/en-us/windows/win32/api/usp10/ns-usp10-script_fontproperties typedef struct { int cBytes; WORD wgBlank;
	// WORD wgDefault; WORD wgInvalid; WORD wgKashida; int iKashidaWidth; } SCRIPT_FONTPROPERTIES;
	[PInvokeData("usp10.h", MSDNShortId = "NS:usp10.__unnamed_struct_1")]
	[StructLayout(LayoutKind.Sequential)]
	public struct SCRIPT_FONTPROPERTIES
	{
		/// <summary>Size, in bytes, of the structure.</summary>
		public int cBytes;

		/// <summary>Glyph used to indicate a blank.</summary>
		public ushort wgBlank;

		/// <summary>Glyph used to indicate Unicode characters not present in the font.</summary>
		public ushort wgDefault;

		/// <summary>Glyph used to indicate invalid character combinations.</summary>
		public ushort wgInvalid;

		/// <summary>Glyph used to indicate the shortest continuous kashida, with 1 indicating that the font contains no kashida.</summary>
		public ushort wgKashida;

		/// <summary>Width of the shortest continuous kashida glyph in the font, indicated by the <c>wgKashida</c> member.</summary>
		public int iKashidaWidth;

		/// <summary>Gets a default instance with the size field set.</summary>
		public static SCRIPT_FONTPROPERTIES Default { get; } = new() { cBytes = Marshal.SizeOf(typeof(SCRIPT_FONTPROPERTIES)) };
	}

	/// <summary>Contains information about a glyph that is part of an output glyph array.</summary>
	// https://docs.microsoft.com/en-us/windows/win32/api/usp10/ns-usp10-script_glyphprop typedef struct script_glyphprop {
	// SCRIPT_VISATTR sva; WORD reserved; } SCRIPT_GLYPHPROP;
	[PInvokeData("usp10.h", MSDNShortId = "NS:usp10.script_glyphprop")]
	[StructLayout(LayoutKind.Sequential)]
	public struct SCRIPT_GLYPHPROP
	{
		/// <summary>
		/// A buffer of SCRIPT_VISATTR structures defining visual (glyph) attributes identifying clusters and justification points. The
		/// buffer is generated by ScriptShape or ScriptShapeOpenType.
		/// </summary>
		public SCRIPT_VISATTR sva;

		/// <summary>Reserved.</summary>
		public ushort reserved;
	}

	/// <summary>
	/// Contains a script item, including a SCRIPT_ANALYSIS structure with the string offset of the first character of the item.
	/// </summary>
	// https://docs.microsoft.com/en-us/windows/win32/api/usp10/ns-usp10-script_item typedef struct tag_SCRIPT_ITEM { int iCharPos;
	// SCRIPT_ANALYSIS a; } SCRIPT_ITEM;
	[PInvokeData("usp10.h", MSDNShortId = "NS:usp10.tag_SCRIPT_ITEM")]
	[StructLayout(LayoutKind.Sequential)]
	public struct SCRIPT_ITEM
	{
		/// <summary>
		/// Offset from the beginning of the itemized string to the first character of the item, counted in Unicode code points (WCHAR values).
		/// </summary>
		public int iCharPos;

		/// <summary>A SCRIPT_ANALYSIS structure containing the analysis of the item.</summary>
		public SCRIPT_ANALYSIS a;
	}

	/// <summary>Contains attributes of logical characters that are useful when editing and formatting text.</summary>
	// https://docs.microsoft.com/en-us/windows/win32/api/usp10/ns-usp10-script_logattr typedef struct tag_SCRIPT_LOGATTR { BYTE
	// fSoftBreak : 1; BYTE fWhiteSpace : 1; BYTE fCharStop : 1; BYTE fWordStop : 1; BYTE fInvalid : 1; BYTE fReserved : 3; } SCRIPT_LOGATTR;
	[PInvokeData("usp10.h", MSDNShortId = "NS:usp10.tag_SCRIPT_LOGATTR")]
	[StructLayout(LayoutKind.Sequential)]
	public struct SCRIPT_LOGATTR
	{
		private byte bits;

		/// <summary>
		/// <para>
		/// Value indicating if breaking the line in front of the character, called a "soft break", is valid. Possible values are defined
		/// in the following table. This member is set on the first character of Southeast Asian words.
		/// </para>
		/// <list type="table">
		/// <listheader>
		/// <term>Value</term>
		/// <term>Meaning</term>
		/// </listheader>
		/// <item>
		/// <term><c>TRUE</c></term>
		/// <term>A soft break is valid.</term>
		/// </item>
		/// <item>
		/// <term><c>FALSE</c></term>
		/// <term>A soft break is not valid.</term>
		/// </item>
		/// </list>
		/// </summary>
		public bool fSoftBreak { get => BitHelper.GetBit(bits, 0); set => BitHelper.SetBit(ref bits, 0, value); }

		/// <summary>
		/// <para>
		/// Value indicating if the character is one of the many Unicode characters classified as breakable white space. Possible values
		/// are defined in the following table. Breakable white space can break a word. All white space is breakable except nonbreaking
		/// space (NBSP) and zero-width nonbreaking space (ZWNBSP).
		/// </para>
		/// <list type="table">
		/// <listheader>
		/// <term>Value</term>
		/// <term>Meaning</term>
		/// </listheader>
		/// <item>
		/// <term><c>TRUE</c></term>
		/// <term>The character is breakable white space.</term>
		/// </item>
		/// <item>
		/// <term><c>FALSE</c></term>
		/// <term>The character is not breakable white space.</term>
		/// </item>
		/// </list>
		/// </summary>
		public bool fWhiteSpace { get => BitHelper.GetBit(bits, 1); set => BitHelper.SetBit(ref bits, 1, value); }

		/// <summary>
		/// <para>
		/// Value indicating if the character is a valid position for showing the caret upon a character movement keyboard action.
		/// Possible values are defined in the following table. This member is set for most characters, but not on code points inside
		/// Indian and Southeast Asian character clusters. This member can be used to implement LEFT ARROW and RIGHT ARROW operations in editors.
		/// </para>
		/// <list type="table">
		/// <listheader>
		/// <term>Value</term>
		/// <term>Meaning</term>
		/// </listheader>
		/// <item>
		/// <term><c>TRUE</c></term>
		/// <term>The character is a valid position for showing the caret upon a character movement keyboard action.</term>
		/// </item>
		/// <item>
		/// <term><c>FALSE</c></term>
		/// <term>The character is not a valid position for showing the caret upon a character movement keyboard action.</term>
		/// </item>
		/// </list>
		/// </summary>
		public bool fCharStop { get => BitHelper.GetBit(bits, 2); set => BitHelper.SetBit(ref bits, 2, value); }

		/// <summary>
		/// <para>
		/// Value indicating the valid position for showing the caret upon a word movement keyboard action, such as CTRL+LEFT ARROW and
		/// CTRL+RIGHT ARROW. Possible values are defined in the following table. This member can be used to implement the CTRL+LEFT
		/// ARROW and CTRL+RIGHT ARROW operations in editors.
		/// </para>
		/// <list type="table">
		/// <listheader>
		/// <term>Value</term>
		/// <term>Meaning</term>
		/// </listheader>
		/// <item>
		/// <term><c>TRUE</c></term>
		/// <term>The character is a valid position for showing the caret upon a word movement keyboard action.</term>
		/// </item>
		/// <item>
		/// <term><c>FALSE</c></term>
		/// <term>The character is not a valid position for showing the caret upon a word movement keyboard action.</term>
		/// </item>
		/// </list>
		/// </summary>
		public bool fWordStop { get => BitHelper.GetBit(bits, 3); set => BitHelper.SetBit(ref bits, 3, value); }

		/// <summary>
		/// <para>
		/// Value used to mark characters that form an invalid or undisplayable combination. Possible values are defined in the following
		/// table. A script that can set this member has the <c>fInvalidLogAttr</c> member set in its SCRIPT_PROPERTIES structure.
		/// </para>
		/// <list type="table">
		/// <listheader>
		/// <term>Value</term>
		/// <term>Meaning</term>
		/// </listheader>
		/// <item>
		/// <term><c>TRUE</c></term>
		/// <term>The character forms an invalid or undisplayable combination.</term>
		/// </item>
		/// <item>
		/// <term><c>FALSE</c></term>
		/// <term>The character does not form an invalid or undisplayable combination.</term>
		/// </item>
		/// </list>
		/// </summary>
		public bool fInvalid { get => BitHelper.GetBit(bits, 4); set => BitHelper.SetBit(ref bits, 4, value); }

		/// <summary>Reserved.</summary>
		public byte fReserved { get => BitHelper.GetBits(bits, 5, 3); set => BitHelper.SetBits(ref bits, 5, 3, value); }
	}

	/// <summary>Contains information about special processing for each script.</summary>
	/// <remarks>
	/// <para>This structure is filled by the ScriptGetProperties function.</para>
	/// <para>
	/// Many Uniscribe scripts do not correspond directly to 8-bit character sets. When some of the characters in a script are supported
	/// by more than one character set, the <c>fAmbiguousCharSet</c> member is set. The application should do further processing to
	/// determine the character set to use when requesting a font suitable for the run. For example, it might determine that the run
	/// consists of multiple languages and split the run so that a different font is used for each language.
	/// </para>
	/// <para>The application uses the following code during initialization to get a pointer to the <c>SCRIPT_PROPERTIES</c> array.</para>
	/// <para>
	/// <code>const SCRIPT_PROPERTIES **ppScriptProperties; // Array of pointers // to properties int iMaxScript; HRESULT hr; hr = ScriptGetProperties(&amp;ppScriptProperties, &amp;iMaxScript);</code>
	/// </para>
	/// <para>Then the application can inspect the properties of the script of an item as shown in the next example.</para>
	/// <para>
	/// <code>hr = ScriptItemize(pwcInChars, cInChars, cMaxItems, psControl, psState, pItems, pcItems); //... if (ppScriptProperties[pItems[iItem].a.eScript]-&gt;fNeedsCaretInfo) { // Use ScriptBreak to restrict the caret from entering clusters (for example). }</code>
	/// </para>
	/// </remarks>
	// https://docs.microsoft.com/en-us/windows/win32/api/usp10/ns-usp10-script_properties typedef struct { DWORD langid : 16; DWORD
	// fNumeric : 1; DWORD fComplex : 1; DWORD fNeedsWordBreaking : 1; DWORD fNeedsCaretInfo : 1; DWORD bCharSet : 8; DWORD fControl : 1;
	// DWORD fPrivateUseArea : 1; DWORD fNeedsCharacterJustify : 1; DWORD fInvalidGlyph : 1; DWORD fInvalidLogAttr : 1; DWORD fCDM : 1;
	// DWORD fAmbiguousCharSet : 1; DWORD fClusterSizeVaries : 1; DWORD fRejectInvalid : 1; } SCRIPT_PROPERTIES;
	[PInvokeData("usp10.h", MSDNShortId = "NS:usp10.__unnamed_struct_0")]
	[StructLayout(LayoutKind.Sequential)]
	public struct SCRIPT_PROPERTIES
	{
		private ulong bits;

		/// <summary>
		/// Language identifier for the language associated with the script. When a script is used for many languages, this member
		/// represents a default language. For example, Western script is represented by LANG_ENGLISH although it is also used for
		/// French, German, and other European languages.
		/// </summary>
		public ushort langid { get => (ushort)BitHelper.GetBits(bits, 0, 16); set => BitHelper.SetBits(ref bits, 0, 16, value); }

		/// <summary>
		/// <para>
		/// Value indicating if a script contains only digits and the other characters used in writing numbers by the rules of the
		/// Unicode bidirectional algorithm. For example, currency symbols, the thousands separator, and the decimal point are classified
		/// as numeric when adjacent to or between digits. Possible values for this member are defined in the following table.
		/// </para>
		/// <list type="table">
		/// <listheader>
		/// <term>Value</term>
		/// <term>Meaning</term>
		/// </listheader>
		/// <item>
		/// <term><c>TRUE</c></term>
		/// <term>
		/// The script contains only digits and the other characters used in writing numbers by the rules of the Unicode bidirectional algorithm.
		/// </term>
		/// </item>
		/// <item>
		/// <term><c>FALSE</c></term>
		/// <term>
		/// The script does not contain only digits and the other characters used in writing numbers by the rules of the Unicode
		/// bidirectional algorithm.
		/// </term>
		/// </item>
		/// </list>
		/// </summary>
		public bool fNumeric { get => BitHelper.GetBit(bits, 16); set => BitHelper.SetBit(ref bits, 16, value); }

		/// <summary>
		/// <para>
		/// Value indicating a complex script for a language that requires special shaping or layout. Possible values are defined in the
		/// following table.
		/// </para>
		/// <list type="table">
		/// <listheader>
		/// <term>Value</term>
		/// <term>Meaning</term>
		/// </listheader>
		/// <item>
		/// <term><c>TRUE</c></term>
		/// <term>The script requires special shaping or layout.</term>
		/// </item>
		/// <item>
		/// <term><c>FALSE</c></term>
		/// <term>The script contains no combining characters and requires no contextual shaping or reordering.</term>
		/// </item>
		/// </list>
		/// </summary>
		public bool fComplex { get => BitHelper.GetBit(bits, 17); set => BitHelper.SetBit(ref bits, 17, value); }

		/// <summary>
		/// <para>Value indicating the type of word break placement for a language. Possible values are defined in the following table.</para>
		/// <list type="table">
		/// <listheader>
		/// <term>Value</term>
		/// <term>Meaning</term>
		/// </listheader>
		/// <item>
		/// <term><c>TRUE</c></term>
		/// <term>
		/// The language has word break placement that requires the application to call ScriptBreak and that includes character positions
		/// marked by the <c>fWordStop</c> member in SCRIPT_LOGATTR.
		/// </term>
		/// </item>
		/// <item>
		/// <term><c>FALSE</c></term>
		/// <term>
		/// Word break placement is identified by scanning for characters marked by the <c>fWhiteSpace</c> member in SCRIPT_LOGATTR, or
		/// for glyphs marked by the value SCRIPT_JUSTIFY_BLANK or SCRIPT_JUSTIFY_ARABIC_BLANK for the <c>uJustification</c> member of SCRIPT_VISATTR.
		/// </term>
		/// </item>
		/// </list>
		/// </summary>
		public bool fNeedsWordBreaking { get => BitHelper.GetBit(bits, 18); set => BitHelper.SetBit(ref bits, 18, value); }

		/// <summary>
		/// <para>
		/// Value indicating if a language, for example, Thai or Indian, restricts caret placement to cluster boundaries. Possible values
		/// are defined in the following table. To determine valid caret positions, the application inspects the <c>fCharStop</c> value
		/// in the logical attributes retrieved by ScriptBreak, or compares adjacent values in the <c>pwLogClust</c> array retrieved by ScriptShape.
		/// </para>
		/// <para><c>Note</c> ScriptXtoCP and ScriptCPtoX automatically apply caret placement restrictions.</para>
		/// <list type="table">
		/// <listheader>
		/// <term>Value</term>
		/// <term>Meaning</term>
		/// </listheader>
		/// <item>
		/// <term><c>TRUE</c></term>
		/// <term>The language restricts caret placement to cluster boundaries.</term>
		/// </item>
		/// <item>
		/// <term><c>FALSE</c></term>
		/// <term>The language does not restrict caret placement to cluster boundaries.</term>
		/// </item>
		/// </list>
		/// </summary>
		public bool fNeedsCaretInfo { get => BitHelper.GetBit(bits, 19); set => BitHelper.SetBit(ref bits, 19, value); }

		/// <summary>
		/// <para>
		/// Nominal character set associated with the script. During creation of a font suitable for displaying the script, this
		/// character set can be used as the value of the <c>lfCharSet</c> member of LOGFONT.
		/// </para>
		/// <para>
		/// For a new script having no character set defined, the application should typically set <c>bCharSet</c> to DEFAULT_CHARSET.
		/// See the description of member <c>fAmbiguousCharSet</c>.
		/// </para>
		/// </summary>
		public byte bCharSet { get => (byte)BitHelper.GetBits(bits, 20, 8); set => BitHelper.SetBits(ref bits, 20, 8, value); }

		/// <summary>
		/// <para>
		/// Value indicating if only control characters are used in the script. Possible values are defined in the following table. Note
		/// that every control character does not end up in a SCRIPT_CONTROL structure.
		/// </para>
		/// <list type="table">
		/// <listheader>
		/// <term>Value</term>
		/// <term>Meaning</term>
		/// </listheader>
		/// <item>
		/// <term><c>TRUE</c></term>
		/// <term>Set only control characters in the script.</term>
		/// </item>
		/// <item>
		/// <term><c>FALSE</c></term>
		/// <term>Do not set only control characters in the script.</term>
		/// </item>
		/// </list>
		/// </summary>
		public bool fControl { get => BitHelper.GetBit(bits, 28); set => BitHelper.SetBit(ref bits, 28, value); }

		/// <summary>
		/// <para>
		/// Value indicating the use of a private use area, a special set of characters that is privately defined for the Unicode range
		/// U+E000 through U+F8FF. Possible values are defined in the following table.
		/// </para>
		/// <list type="table">
		/// <listheader>
		/// <term>Value</term>
		/// <term>Meaning</term>
		/// </listheader>
		/// <item>
		/// <term><c>TRUE</c></term>
		/// <term>Use a private use area.</term>
		/// </item>
		/// <item>
		/// <term><c>FALSE</c></term>
		/// <term>Do not use a private use area.</term>
		/// </item>
		/// </list>
		/// </summary>
		public bool fPrivateUseArea { get => BitHelper.GetBit(bits, 29); set => BitHelper.SetBit(ref bits, 29, value); }

		/// <summary>
		/// <para>
		/// Value indicating the handling of justification for the script by increasing all the spaces between letters, not just the
		/// spaces between words. Possible values are defined in the following table. When performing inter-character justification,
		/// Uniscribe inserts extra space only after glyphs marked with the SCRIPT_JUSTIFY_CHARACTER value for the <c>uJustification</c>
		/// member of SCRIPT_VISATTR.
		/// </para>
		/// <list type="table">
		/// <listheader>
		/// <term>Value</term>
		/// <term>Meaning</term>
		/// </listheader>
		/// <item>
		/// <term><c>TRUE</c></term>
		/// <term>Use character justification.</term>
		/// </item>
		/// <item>
		/// <term><c>FALSE</c></term>
		/// <term>Do not use character justification.</term>
		/// </item>
		/// </list>
		/// </summary>
		public bool fNeedsCharacterJustify { get => BitHelper.GetBit(bits, 30); set => BitHelper.SetBit(ref bits, 30, value); }

		/// <summary>
		/// <para>
		/// Value indicating if ScriptShape generates an invalid glyph for a script to represent invalid sequences. Possible values are
		/// defined in the following table. The application can obtain the glyph index of the invalid glyph for a particular font by
		/// calling ScriptGetFontProperties.
		/// </para>
		/// <list type="table">
		/// <listheader>
		/// <term>Value</term>
		/// <term>Meaning</term>
		/// </listheader>
		/// <item>
		/// <term><c>TRUE</c></term>
		/// <term>Generate an invalid glyph to represent invalid sequences.</term>
		/// </item>
		/// <item>
		/// <term><c>FALSE</c></term>
		/// <term>Do not generate an invalid glyph to represent invalid sequences.</term>
		/// </item>
		/// </list>
		/// </summary>
		public bool fInvalidGlyph { get => BitHelper.GetBit(bits, 31); set => BitHelper.SetBit(ref bits, 31, value); }

		/// <summary>
		/// <para>
		/// Value indicating if ScriptBreak marks invalid combinations for a script by setting <c>fInvalid</c> in the logical attributes
		/// buffer. Possible values are defined in the following table.
		/// </para>
		/// <list type="table">
		/// <listheader>
		/// <term>Value</term>
		/// <term>Meaning</term>
		/// </listheader>
		/// <item>
		/// <term><c>TRUE</c></term>
		/// <term>Mark invalid combinations for the script.</term>
		/// </item>
		/// <item>
		/// <term><c>FALSE</c></term>
		/// <term>Do not mark invalid combinations for the script.</term>
		/// </item>
		/// </list>
		/// </summary>
		public bool fInvalidLogAttr { get => BitHelper.GetBit(bits, 32); set => BitHelper.SetBit(ref bits, 32, value); }

		/// <summary>
		/// <para>
		/// Value indicating if a script contains an item that has been analyzed by ScriptItemize as including Combining Diacritical
		/// Marks (U+0300 through U+36F). Possible values are defined in the following table.
		/// </para>
		/// <list type="table">
		/// <listheader>
		/// <term>Value</term>
		/// <term>Meaning</term>
		/// </listheader>
		/// <item>
		/// <term><c>TRUE</c></term>
		/// <term>The script contains an item that includes combining diacritical marks.</term>
		/// </item>
		/// <item>
		/// <term><c>FALSE</c></term>
		/// <term>The script does not contain an item that includes combining diacritical marks.</term>
		/// </item>
		/// </list>
		/// </summary>
		public bool fCDM { get => BitHelper.GetBit(bits, 33); set => BitHelper.SetBit(ref bits, 33, value); }

		/// <summary>
		/// <para>
		/// Value indicating if a script contains characters that are supported by more than one character set. Possible values are
		/// defined in the following table.
		/// </para>
		/// <list type="table">
		/// <listheader>
		/// <term>Value</term>
		/// <term>Meaning</term>
		/// </listheader>
		/// <item>
		/// <term><c>TRUE</c></term>
		/// <term>
		/// The script contains characters that are supported by more than one character set. In this case, the <c>bCharSet</c> member of
		/// this structure should be ignored, and the <c>lfCharSet</c> member of LOGFONT should be set to DEFAULT_CHARSET. See the
		/// Remarks section for more information.
		/// </term>
		/// </item>
		/// <item>
		/// <term><c>FALSE</c></term>
		/// <term>The script does not contain characters that are supported by more than one character set.</term>
		/// </item>
		/// </list>
		/// </summary>
		public bool fAmbiguousCharSet { get => BitHelper.GetBit(bits, 34); set => BitHelper.SetBit(ref bits, 34, value); }

		/// <summary>
		/// <para>
		/// Value indicating if a script, such as Arabic, might use contextual shaping that causes a string to increase in size during
		/// removal of characters. Possible values are defined in the following table.
		/// </para>
		/// <list type="table">
		/// <listheader>
		/// <term>Value</term>
		/// <term>Meaning</term>
		/// </listheader>
		/// <item>
		/// <term><c>TRUE</c></term>
		/// <term>Use a variable cluster size for contextual shaping.</term>
		/// </item>
		/// <item>
		/// <term><c>FALSE</c></term>
		/// <term>Do not use a variable cluster size for contextual shaping.</term>
		/// </item>
		/// </list>
		/// </summary>
		public bool fClusterSizeVaries { get => BitHelper.GetBit(bits, 35); set => BitHelper.SetBit(ref bits, 35, value); }

		/// <summary>
		/// <para>
		/// Value indicating if a script, for example, Thai, should reject invalid sequences that conventionally cause an editor program,
		/// such as Notepad, to beep and ignore keystrokes. Possible values are defined in the following table.
		/// </para>
		/// <list type="table">
		/// <listheader>
		/// <term>Value</term>
		/// <term>Meaning</term>
		/// </listheader>
		/// <item>
		/// <term><c>TRUE</c></term>
		/// <term>Reject invalid sequences.</term>
		/// </item>
		/// <item>
		/// <term><c>FALSE</c></term>
		/// <term>Do not reject invalid sequences.</term>
		/// </item>
		/// </list>
		/// </summary>
		public bool fRejectInvalid { get => BitHelper.GetBit(bits, 36); set => BitHelper.SetBit(ref bits, 36, value); }

		/// <summary>Performs an implicit conversion from <see cref="System.Int64"/> to <see cref="SCRIPT_PROPERTIES"/>.</summary>
		/// <param name="value">The value.</param>
		/// <returns>The result of the conversion.</returns>
		public static implicit operator SCRIPT_PROPERTIES(long value) => new() { bits = unchecked((ulong)value) };
	}

	/// <summary>Contains script state information.</summary>
	/// <remarks>
	/// This structure is used to initialize the Unicode algorithm state as an input to ScriptItemize. It is also used as a component of
	/// the analysis retrieved by <c>ScriptItemize</c>.
	/// </remarks>
	// https://docs.microsoft.com/en-us/windows/win32/api/usp10/ns-usp10-script_state typedef struct tag_SCRIPT_STATE { WORD uBidiLevel :
	// 5; WORD fOverrideDirection { get => BitHelper.GetBit(bits, 5); set => BitHelper.SetBit(ref bits, 5, value); } WORD fInhibitSymSwap
	// { get => BitHelper.GetBit(bits, 5); set => BitHelper.SetBit(ref bits, 5, value); } WORD fCharShape { get => BitHelper.GetBit(bits,
	// 5); set => BitHelper.SetBit(ref bits, 5, value); } WORD fDigitSubstitute { get => BitHelper.GetBit(bits, 5); set =>
	// BitHelper.SetBit(ref bits, 5, value); } WORD fInhibitLigate { get => BitHelper.GetBit(bits, 5); set => BitHelper.SetBit(ref bits,
	// 5, value); } WORD fDisplayZWG { get => BitHelper.GetBit(bits, 5); set => BitHelper.SetBit(ref bits, 5, value); } WORD
	// fArabicNumContext { get => BitHelper.GetBit(bits, 5); set => BitHelper.SetBit(ref bits, 5, value); } WORD fGcpClusters { get =>
	// BitHelper.GetBit(bits, 5); set => BitHelper.SetBit(ref bits, 5, value); } WORD fReserved { get => BitHelper.GetBit(bits, 5); set
	// => BitHelper.SetBit(ref bits, 5, value); } WORD fEngineReserved : 2; } SCRIPT_STATE;
	[PInvokeData("usp10.h", MSDNShortId = "NS:usp10.tag_SCRIPT_STATE")]
	[StructLayout(LayoutKind.Sequential)]
	public struct SCRIPT_STATE
	{
		private ushort bits;

		/// <summary>
		/// Embedding level associated with all characters in the associated run according to the Unicode bidirectional algorithm. When
		/// the application passes this structure to ScriptItemize, this member should be initialized to 0 for a left-to-right base
		/// embedding level, or to 1 for a right-to-left base embedding level.
		/// </summary>
		public ushort uBidiLevel { get => BitHelper.GetBits(bits, 0, 5); set => BitHelper.SetBits(ref bits, 0, 5, value); }

		/// <summary>
		/// <para>
		/// Initial override direction value indicating if the script uses an override level (LRO or RLO code in the string). Possible
		/// values are defined in the following table. For an override level, characters are laid out in one direction only, either left
		/// to right or right to left. No reordering of digits or strong characters of opposing direction takes place. Note that this
		/// value is reset by LRE, RLE, LRO or RLO codes in the string.
		/// </para>
		/// <list type="table">
		/// <listheader>
		/// <term>Value</term>
		/// <term>Meaning</term>
		/// </listheader>
		/// <item>
		/// <term><c><c>TRUE</c></c></term>
		/// <term>Use an override level that reflects the embedding level.</term>
		/// </item>
		/// <item>
		/// <term><c><c>FALSE</c></c></term>
		/// <term>Do not use an override level that reflects the embedding level.</term>
		/// </item>
		/// </list>
		/// </summary>
		public bool fOverrideDirection { get => BitHelper.GetBit(bits, 5); set => BitHelper.SetBit(ref bits, 5, value); }

		/// <summary>
		/// <para>
		/// Value indicating if the shaping engine bypasses mirroring of Unicode mirrored glyphs, for example, brackets. Possible values
		/// are defined in the following table. This member is set by Unicode character ISS, and cleared by ASS.
		/// </para>
		/// <list type="table">
		/// <listheader>
		/// <term>Value</term>
		/// <term>Meaning</term>
		/// </listheader>
		/// <item>
		/// <term><c><c>TRUE</c></c></term>
		/// <term>Bypass mirroring of Unicode mirrored glyphs.</term>
		/// </item>
		/// <item>
		/// <term><c><c>FALSE</c></c></term>
		/// <term>Do not bypass mirroring of Unicode mirrored glyphs.</term>
		/// </item>
		/// </list>
		/// </summary>
		public bool fInhibitSymSwap { get => BitHelper.GetBit(bits, 6); set => BitHelper.SetBit(ref bits, 6, value); }

		/// <summary>
		/// <para>
		/// Not implemented. Value indicating if character codes in the Arabic Presentation Forms areas of Unicode should be shaped.
		/// Possible values are defined in the following table.
		/// </para>
		/// <list type="table">
		/// <listheader>
		/// <term>Value</term>
		/// <term>Meaning</term>
		/// </listheader>
		/// <item>
		/// <term><c><c>TRUE</c></c></term>
		/// <term>Shape character codes in the Arabic Presentation Forms areas of Unicode.</term>
		/// </item>
		/// <item>
		/// <term><c><c>FALSE</c></c></term>
		/// <term>Do not shape character codes in the Arabic Presentation Forms areas of Unicode.</term>
		/// </item>
		/// </list>
		/// </summary>
		public bool fCharShape { get => BitHelper.GetBit(bits, 7); set => BitHelper.SetBit(ref bits, 7, value); }

		/// <summary>
		/// <para>
		/// This member provides the same control over digit substitution behavior that might have been obtained in legacy
		/// implementations using the now-deprecated Unicode characters U+206E NATIONAL DIGIT SHAPES ("NADS") and U+206F NOMINAL DIGIT
		/// SHAPES ("NODS"). Possible values are defined in the following table.
		/// </para>
		/// <list type="table">
		/// <listheader>
		/// <term>Value</term>
		/// <term>Meaning</term>
		/// </listheader>
		/// <item>
		/// <term><c><c>TRUE</c></c></term>
		/// <term>Character codes U+0030 through U+0039 are substituted by national digits.</term>
		/// </item>
		/// <item>
		/// <term><c><c>FALSE</c></c></term>
		/// <term>Character codes U+0030 through U+0039 are not substituted by national digits.</term>
		/// </item>
		/// </list>
		/// </summary>
		public bool fDigitSubstitute { get => BitHelper.GetBit(bits, 8); set => BitHelper.SetBit(ref bits, 8, value); }

		/// <summary>
		/// <para>
		/// Value indicating if ligatures are used in the shaping of Arabic or Hebrew characters. Possible values are defined in the
		/// following table.
		/// </para>
		/// <list type="table">
		/// <listheader>
		/// <term>Value</term>
		/// <term>Meaning</term>
		/// </listheader>
		/// <item>
		/// <term><c><c>TRUE</c></c></term>
		/// <term>Do not use ligatures in the shaping of Arabic or Hebrew characters.</term>
		/// </item>
		/// <item>
		/// <term><c><c>FALSE</c></c></term>
		/// <term>Use ligatures in the shaping of Arabic or Hebrew characters.</term>
		/// </item>
		/// </list>
		/// </summary>
		public bool fInhibitLigate { get => BitHelper.GetBit(bits, 9); set => BitHelper.SetBit(ref bits, 9, value); }

		/// <summary>
		/// <para>
		/// Value indicating if nondisplayable control characters are shaped as representational glyphs for languages that need
		/// reordering or different glyph shapes, depending on the positions of the characters within a word. Possible values are defined
		/// in the following table. Typically, the characters are not displayed. They are shaped to the blank glyph and given a width of 0.
		/// </para>
		/// <list type="table">
		/// <listheader>
		/// <term>Value</term>
		/// <term>Meaning</term>
		/// </listheader>
		/// <item>
		/// <term><c><c>TRUE</c></c></term>
		/// <term>Shape control characters as representational glyphs.</term>
		/// </item>
		/// <item>
		/// <term><c><c>FALSE</c></c></term>
		/// <term>Do not shape control characters as representational glyphs.</term>
		/// </item>
		/// </list>
		/// </summary>
		public bool fDisplayZWG { get => BitHelper.GetBit(bits, 10); set => BitHelper.SetBit(ref bits, 10, value); }

		/// <summary>
		/// <para>
		/// Value indicating if prior strong characters are Arabic for the purposes of rule P0, as discussed in the Unicode Standard,
		/// version 2.0. Possible values are defined in the following table. This member should normally be set to <c>TRUE</c> before
		/// itemization of a right-to-left paragraph in an Arabic language, and to <c>FALSE</c> otherwise.
		/// </para>
		/// <list type="table">
		/// <listheader>
		/// <term>Value</term>
		/// <term>Meaning</term>
		/// </listheader>
		/// <item>
		/// <term><c><c>TRUE</c></c></term>
		/// <term>Consider prior strong characters to be Arabic for the purposes of rule P0.</term>
		/// </item>
		/// <item>
		/// <term><c><c>FALSE</c></c></term>
		/// <term>Do not consider prior strong characters to be Arabic for the purposes of rule P0.</term>
		/// </item>
		/// </list>
		/// </summary>
		public bool fArabicNumContext { get => BitHelper.GetBit(bits, 11); set => BitHelper.SetBit(ref bits, 1, value); }

		/// <summary>
		/// <para>
		/// For GetCharacterPlacement legacy support only. Value indicating how ScriptShape should generate the array indicated by
		/// <c>pwLogClust</c>. Possible values are defined in the following table. This member affects only Arabic and Hebrew items.
		/// </para>
		/// <list type="table">
		/// <listheader>
		/// <term>Value</term>
		/// <term>Meaning</term>
		/// </listheader>
		/// <item>
		/// <term><c><c>TRUE</c></c></term>
		/// <term>Generate the array the same way as GetCharacterPlacement does.</term>
		/// </item>
		/// <item>
		/// <term><c><c>FALSE</c></c></term>
		/// <term>Do not generate the array the same way as GetCharacterPlacement does.</term>
		/// </item>
		/// </list>
		/// </summary>
		public bool fGcpClusters { get => BitHelper.GetBit(bits, 12); set => BitHelper.SetBit(ref bits, 12, value); }

		/// <summary>Reserved; always initialize to 0.</summary>
		public bool fReserved { get => BitHelper.GetBit(bits, 13); set => BitHelper.SetBit(ref bits, 13, value); }

		/// <summary>Reserved; always initialize to 0.</summary>
		public ushort fEngineReserved { get => BitHelper.GetBits(bits, 14, 2); set => BitHelper.SetBits(ref bits, 14, 2, value); }
	}

	/// <summary>Contains definitions of the tab positions for ScriptStringAnalyse.</summary>
	/// <remarks>This structure is ignored unless the <c>dwFlags</c> parameter is set to SSA_TAB in the ScriptStringAnalyse function.</remarks>
	// https://docs.microsoft.com/en-us/windows/win32/api/usp10/ns-usp10-script_tabdef typedef struct tag_SCRIPT_TABDEF { int cTabStops;
	// int iScale; int *pTabStops; int iTabOrigin; } SCRIPT_TABDEF;
	[PInvokeData("usp10.h", MSDNShortId = "NS:usp10.tag_SCRIPT_TABDEF")]
	[StructLayout(LayoutKind.Sequential)]
	public struct SCRIPT_TABDEF
	{
		/// <summary>
		/// <para>Number of entries in the array indicated by <c>pTabStops</c>.</para>
		/// <list type="table">
		/// <listheader>
		/// <term>Value</term>
		/// <term>Meaning</term>
		/// </listheader>
		/// <item>
		/// <term>0</term>
		/// <term>Tab stops occur every eight average character widths.</term>
		/// </item>
		/// <item>
		/// <term>1</term>
		/// <term>All tab stops are the length of the first entry in the array indicated by <c>pTabStops</c>.</term>
		/// </item>
		/// <item>
		/// <term>greater than 1</term>
		/// <term>
		/// The first <c>cTabStops</c> tab stops are as specified in the array indicated by <c>pTabStops</c>, and subsequent tab stops
		/// are every eight average characters.
		/// </term>
		/// </item>
		/// </list>
		/// </summary>
		public int cTabStops;

		/// <summary>
		/// Scale factor for <c>iTabOrigin</c> and <c>pTabStops</c> values. Values are converted to device coordinates by multiplying by
		/// the value indicated by <c>iScale</c>, then dividing by 4. If values are already in device units, set <c>iScale</c> to 4. If
		/// values are in dialog units, set <c>iScale</c> to the average character width of the dialog font. If values are multiples of
		/// the average character width for the selected font, set <c>iScale</c> to 0.
		/// </summary>
		public int iScale;

		/// <summary>
		/// Pointer to an array having the number of entries indicated by <c>cTabStops</c>. Each entry specifies a tab stop position.
		/// Positive values represent near-edge alignment, while negative values represent far-edge alignment. The units for the array
		/// elements are as indicated by the value of <c>iScale</c>.
		/// </summary>
		public IntPtr pTabStops;

		/// <summary>
		/// Initial offset, in logical units, for tab stops. Tabs start <c>iTabOrigin</c> logical units before the beginning of the
		/// string. This rule helps with situations in which multiple tabbed outputs occur on the same line.
		/// </summary>
		public int iTabOrigin;
	}

	/// <summary>Contains the visual (glyph) attributes that identify clusters and justification points, as generated by ScriptShape.</summary>
	// https://docs.microsoft.com/en-us/windows/win32/api/usp10/ns-usp10-script_visattr typedef struct tag_SCRIPT_VISATTR { WORD
	// uJustification : 4; WORD fClusterStart { get => BitHelper.GetBit(bits, 5); set => BitHelper.SetBit(ref bits, 5, value); } WORD
	// fDiacritic { get => BitHelper.GetBit(bits, 5); set => BitHelper.SetBit(ref bits, 5, value); } WORD fZeroWidth { get =>
	// BitHelper.GetBit(bits, 5); set => BitHelper.SetBit(ref bits, 5, value); } WORD fReserved { get => BitHelper.GetBit(bits, 5); set
	// => BitHelper.SetBit(ref bits, 5, value); } WORD fShapeReserved : 8; } SCRIPT_VISATTR;
	[PInvokeData("usp10.h", MSDNShortId = "NS:usp10.tag_SCRIPT_VISATTR")]
	[StructLayout(LayoutKind.Sequential)]
	public struct SCRIPT_VISATTR
	{
		private ushort bits;

		/// <summary>Justification class for the glyph. See SCRIPT_JUSTIFY.</summary>
		public SCRIPT_JUSTIFY uJustification { get => (SCRIPT_JUSTIFY)BitHelper.GetBits(bits, 0, 4); set => BitHelper.SetBits(ref bits, 0, 4, (ushort)value); }

		/// <summary>
		/// <para>
		/// Value indicating the logical first glyph in every cluster, even for clusters containing just one glyph. Possible values are
		/// defined in the following table.
		/// </para>
		/// <list type="table">
		/// <listheader>
		/// <term>Value</term>
		/// <term>Meaning</term>
		/// </listheader>
		/// <item>
		/// <term><c>TRUE</c></term>
		/// <term>The glyph is the logical first glyph of the cluster.</term>
		/// </item>
		/// <item>
		/// <term><c>FALSE</c></term>
		/// <term>The glyph is not the logical first glyph of the cluster.</term>
		/// </item>
		/// </list>
		/// </summary>
		public bool fClusterStart { get => BitHelper.GetBit(bits, 4); set => BitHelper.SetBit(ref bits, 4, value); }

		/// <summary>
		/// <para>Value indicating if a glyph combines with base characters. Possible values are defined in the following table.</para>
		/// <list type="table">
		/// <listheader>
		/// <term>Value</term>
		/// <term>Meaning</term>
		/// </listheader>
		/// <item>
		/// <term><c>TRUE</c></term>
		/// <term>The glyph does combine with base characters.</term>
		/// </item>
		/// <item>
		/// <term><c>FALSE</c></term>
		/// <term>The glyph does not combine with base characters.</term>
		/// </item>
		/// </list>
		/// </summary>
		public bool fDiacritic { get => BitHelper.GetBit(bits, 5); set => BitHelper.SetBit(ref bits, 5, value); }

		/// <summary>
		/// <para>
		/// Value set by the shaping engine to indicate a zero-width character, such as ZWJ and ZWNJ. This value is set for some, but not
		/// all, zero-width characters. Possible values are defined in the following table.
		/// </para>
		/// <list type="table">
		/// <listheader>
		/// <term>Value</term>
		/// <term>Meaning</term>
		/// </listheader>
		/// <item>
		/// <term><c>TRUE</c></term>
		/// <term>The glyph indicates a zero-width character.</term>
		/// </item>
		/// <item>
		/// <term><c>FALSE</c></term>
		/// <term>The glyph does not indicate a zero-width character.</term>
		/// </item>
		/// </list>
		/// </summary>
		public bool fZeroWidth { get => BitHelper.GetBit(bits, 6); set => BitHelper.SetBit(ref bits, 6, value); }

		/// <summary>Reserved; always initialize to 0.</summary>
		public bool fReserved { get => BitHelper.GetBit(bits, 7); set => BitHelper.SetBit(ref bits, 7, value); }

		/// <summary>Reserved; for use by shaping engines.</summary>
		public ushort fShapeReserved { get => BitHelper.GetBits(bits, 8, 8); set => BitHelper.SetBits(ref bits, 8, 8, value); }
	}

	/// <summary>Contains a group of OpenType features to apply to a run.</summary>
	// https://docs.microsoft.com/en-us/windows/win32/api/usp10/ns-usp10-textrange_properties typedef struct textrange_properties {
	// OPENTYPE_FEATURE_RECORD *potfRecords; int cotfRecords; } TEXTRANGE_PROPERTIES;
	[PInvokeData("usp10.h", MSDNShortId = "NS:usp10.textrange_properties")]
	[StructLayout(LayoutKind.Sequential)]
	public struct TEXTRANGE_PROPERTIES
	{
		/// <summary>
		/// Pointer to an array of OPENTYPE_FEATURE_RECORD structures containing OpenType features (records) to apply to the characters
		/// in a specific range of text in a run.
		/// </summary>
		public IntPtr potfRecords;

		/// <summary>Number of features in the array specified by <c>potfRecords</c>.</summary>
		public int cotfRecords;
	}

	/// <summary>
	/// Defines a Uniscribe font metric cache as a <see cref="SafeHandle"/> that is disposed using <see cref="ScriptFreeCache(ref IntPtr)"/>.
	/// </summary>
	/// <summary></summary>
	/// <remarks>
	/// <para>
	/// This is an opaque structure. The application must allocate and retain one SCRIPT_CACHE variable for each character style used.
	/// </para>
	/// <para>
	/// Many script functions take a combination of a hardware device context handle and a SCRIPT_CACHE variable. Uniscribe first
	/// attempts to access font data by using the SCRIPT_CACHE variable. It only inspects the hardware device context if the required
	/// data is not already cached.
	/// </para>
	/// <para>
	/// The hardware device context handle can be passed to Uniscribe as <c>NULL</c>. If data required by Uniscribe is already cached,
	/// the device context is not accessed, and the operation continues normally.
	/// </para>
	/// <para>
	/// If the device context is passed as <c>NULL</c> and Uniscribe needs to access it for any reason, Uniscribe returns the error code
	/// E_PENDING. This code is returned quickly, allowing the application to avoid time-consuming <c>SelectObject</c> calls.
	/// </para>
	/// </remarks>
	// https://docs.microsoft.com/en-us/windows/win32/intl/script-cache
	[PInvokeData("usp10.h")]
	[StructLayout(LayoutKind.Sequential)]
	public class SafeSCRIPT_CACHE : IDisposable
	{
		private IntPtr handle = default;

		/// <summary>Initializes a new instance of the <see cref="SafeSCRIPT_CACHE"/> class.</summary>
		public SafeSCRIPT_CACHE()
		{ }

		/// <summary>Gets a value indicating whether this cache variable is invalid.</summary>
		/// <value><see langword="true"/> if this cache variable is invalid; otherwise, <see langword="false"/>.</value>
		public bool IsInvalid => handle == default;

		/// <summary>Releases unmanaged and - optionally - managed resources.</summary>
		public void Dispose() => ScriptFreeCache(ref handle);
	}

	/// <summary>Provides a <see cref="SafeHandle"/> for <c>SCRIPT_STRING_ANALYSIS</c> that is disposed using <see cref="ScriptStringFree"/>.</summary>
	public class SafeSCRIPT_STRING_ANALYSIS : SafeHANDLE
	{
		/// <summary>Initializes a new instance of the <see cref="SafeSCRIPT_STRING_ANALYSIS"/> class and assigns an existing handle.</summary>
		/// <param name="preexistingHandle">An <see cref="IntPtr"/> object that represents the pre-existing handle to use.</param>
		/// <param name="ownsHandle">
		/// <see langword="true"/> to reliably release the handle during the finalization phase; otherwise, <see langword="false"/> (not recommended).
		/// </param>
		public SafeSCRIPT_STRING_ANALYSIS(IntPtr preexistingHandle, bool ownsHandle = true) : base(preexistingHandle, ownsHandle) { }

		/// <summary>Initializes a new instance of the <see cref="SafeSCRIPT_STRING_ANALYSIS"/> class.</summary>
		private SafeSCRIPT_STRING_ANALYSIS() : base() { }

		private unsafe delegate TRet* GetVal<TRet>(SafeSCRIPT_STRING_ANALYSIS ssa) where TRet : unmanaged;

		/// <summary>Returns a logical attributes buffer for an analyzed string.</summary>
		/// <value>
		/// Returns a buffer containing SCRIPT_LOGATTR structures defining logical attributes if successful. The function returns <see
		/// langword="null"/> if it does not succeed.
		/// </value>
		/// <remarks>
		/// <para>The logical attribute buffer contains at least the number of integers indicated by the <c>ssa</c> parameter of ScriptString_pcOutChars.</para>
		/// <para>
		/// When scanning the SCRIPT_LOGATTR array for a word break point, the application should look backward for the values of the
		/// <c>fWordStop</c> and <c>fWhiteSpace</c> members. ScriptStringAnalyse just calls ScriptBreak on each run, and
		/// <c>ScriptBreak</c> never sets <c>fWordBreak</c> on the first character of a run, because it has no information that the
		/// previous run ended in white space.
		/// </para>
		/// </remarks>
		public SCRIPT_LOGATTR[] LogAttr
		{
			get
			{
				unsafe
				{
					SCRIPT_LOGATTR* a = ScriptString_pLogAttr(this);
					return a is not null ? ((IntPtr)a).ToArray<SCRIPT_LOGATTR>(OutChars.GetValueOrDefault())! : new SCRIPT_LOGATTR[0];
				}
			}
		}

		/// <summary>Converts visual widths into logical widths.</summary>
		/// <value>The logical widths.</value>
		/// <remarks>
		/// <para>
		/// This property converts the visual widths generated by ScriptStringAnalyse into logical widths, one per original character, in
		/// logical order.
		/// </para>
		/// <para>To use this property, the application needs to specify SSA_GLYPHS in its original call to ScriptStringAnalyse.</para>
		/// </remarks>
		public int[] LogicalWidths
		{
			get
			{
				int[] ret = new int[OutChars.GetValueOrDefault(0)];
				if (ret.Length == 0)
					return ret;
				ScriptStringGetLogicalWidths(this, ret).ThrowIfFailed();
				return ret;
			}
		}

		/// <summary>Gets an array that maps an original character position to a glyph position.</summary>
		/// <value>An array of glyph positions, indexed by the original character position.</value>
		/// <remarks>
		/// <para>
		/// When the number of glyphs and the number of characters are equal, the function retrieves an array that references every
		/// glyph. This is the same treatment that occurs in GetCharacterPlacement.
		/// </para>
		/// <para>To use this function, the application needs to specify SSA_GLYPHS in its original call to ScriptStringAnalyse.</para>
		/// </remarks>
		public uint[] Order
		{
			get
			{
				uint[] ret = new uint[OutChars.GetValueOrDefault(0)];
				if (ret.Length == 0)
					return ret;
				ScriptStringGetOrder(this, ret).ThrowIfFailed();
				return ret;
			}
		}

		/// <summary>Returns the length of a string after clipping.</summary>
		/// <value>
		/// Returns the length of the string after clipping if successful. The length is the number of Unicode code points. The function
		/// returns <see langword="null"/> if it does not succeed.
		/// </value>
		/// <remarks>To use this property, the application needs to specify SSA_CLIP in its original call to ScriptStringAnalyse.</remarks>
		public int? OutChars { get { unsafe { return RetOrDef<int>(ScriptString_pcOutChars); } } }

		/// <summary>Returns a SIZE structure for an analyzed string.</summary>
		/// <returns>
		/// Returns a pointer to a SIZE structure containing the size (width and height) of the analyzed string if successful. The
		/// function returns <see langword="null"/> if it does not succeed.
		/// </returns>
		/// <remarks>
		/// <para>
		/// The size returned by this function is the size before the effect of the justification requested by setting the SSA_FIT flag
		/// in ScriptStringAnalyse. The difference between the value of <c>iReqWidth</c> in <c>ScriptStringAnalyse</c> and the size
		/// returned by <c>ScriptString_pSize</c> is the effect of justification.
		/// </para>
		/// </remarks>
		public SIZE? Size { get { unsafe { return RetOrDef<SIZE>(ScriptString_pSize); } } }

		/// <summary>Retrieves the x coordinate for the leading or trailing edge of a character position.</summary>
		/// <param name="cp">Character position in the string.</param>
		/// <param name="trailing">
		/// <see langword="true"/> to indicate the trailing edge of the character position ( <c>icp</c>) that corresponds to the x
		/// coordinate. This parameter is set to <see langword="false"/> to indicate the leading edge of the character position.
		/// </param>
		/// <returns>The x coordinate corresponding to the character position.</returns>
		public int CPtoX(int cp, bool trailing)
		{
			ScriptStringCPtoX(this, cp, trailing, out int ret).ThrowIfFailed();
			return ret;
		}

		/// <summary>Displays a string generated by a prior call to ScriptStringAnalyse and optionally adds highlighting.</summary>
		/// <param name="pt">The x and y-coordinates of the reference point used to position the string.</param>
		/// <param name="options">
		/// <para>
		/// Options specifying the use of the application-defined rectangle. This parameter can be set to 0 or to any of the following
		/// values. The values can be combined with binary OR.
		/// </para>
		/// <list type="table">
		/// <listheader>
		/// <term>Value</term>
		/// <term>Meaning</term>
		/// </listheader>
		/// <item>
		/// <term><c>ETO_CLIPPED</c></term>
		/// <term>Clip text to the rectangle.</term>
		/// </item>
		/// <item>
		/// <term><c>ETO_OPAQUE</c></term>
		/// <term>Use current background color to fill the rectangle.</term>
		/// </item>
		/// </list>
		/// </param>
		/// <param name="rc">
		/// Pointer to a RECT structure that defines the rectangle to use. If <c>uOptions</c> is set to ETO_OPAQUE and <c>NULL</c> is
		/// provided for <c>prc</c>, the function succeeds and returns S_OK. However, if the application sets <c>uOptions</c> to ETO_CLIPPING
		/// and provides <c>NULL</c> for <c>prc</c>, the function returns E_INVALIDARG. The application can set this parameter to <c>NULL</c>
		/// to indicate that no option is needed.
		/// </param>
		/// <param name="minSel">
		/// Zero-based index specifying the starting position in the string. For no selection, the application should set <c>iMinSel &gt;= iMaxSel</c>.
		/// </param>
		/// <param name="maxSel">Zero-based index specifying the ending position in the string.</param>
		/// <param name="disabled">
		/// <c>TRUE</c> if the operating system applies disabled-text highlighting by setting the background color to COLOR_HIGHLIGHT behind
		/// all selected characters. The application can set this parameter to <c>FALSE</c> if the operating system applies enabled-text
		/// highlighting by setting the background color to COLOR_HIGHLIGHT and the text color to COLOR_HIGHLIGHTTEXT for each selected character.
		/// </param>
		/// <returns>
		/// Returns S_OK if successful. The function returns a nonzero <c>HRESULT</c> value if it does not succeed. The application can't
		/// test the return value with the <c>SUCCEEDED</c> and <c>FAILED</c> macros.
		/// </returns>
		/// <remarks>
		/// <para>To use this function, the application needs to specify SSA_GLYPHS in its original call to ScriptStringAnalyse.</para>
		/// <para>
		/// The application should not use SetTextAlign with TA_UPDATECP when using <c>ScriptStringOut</c> because selected text cannot be
		/// rendered correctly. If the application must use this flag, it can unset and reset the flag as necessary to avoid the problem.
		/// </para>
		/// </remarks>
		public HRESULT Out(POINT pt, Gdi32.ETO options = 0, [In] PRECT? rc = null, int minSel = 0, int maxSel = 0, [MarshalAs(UnmanagedType.Bool)] bool disabled = false) =>
			ScriptStringOut(this, pt.X, pt.Y, options, rc, minSel, maxSel, disabled);

		/// <summary>Checks for invalid sequences.</summary>
		/// <returns>
		/// Returns S_OK if no invalid sequences are found. The function returns S_FALSE if one or more invalid sequences are found. The
		/// function returns a nonzero HRESULT value if it does not succeed.
		/// </returns>
		/// <remarks>
		/// <para>This function is intended for use in editors that reject the input of invalid sequences.</para>
		/// <para>
		/// Invalid sequences are only checked for scripts with the <c>fRejectInvalid</c> member set in the associated SCRIPT_PROPERTIES
		/// structure. For example, it is conventional for Notepad to reject invalid Thai character sequences. However, invalid Indian
		/// sequences are not conventionally rejected, but instead are displayed in composition with a missing base character symbol.
		/// </para>
		/// </remarks>
		public HRESULT Validate() => ScriptStringValidate(this);

		/// <summary>Converts an x coordinate to a character position.</summary>
		/// <param name="x">The x coordinate.</param>
		/// <returns>
		/// A tuple with the character position in the string (cp) and a value indicating if the x coordinate is for the leading edge or
		/// the trailing edge of the character position (trailing). For more information, see the Remarks section.
		/// </returns>
		/// <remarks>
		/// <para>
		/// If the x coordinate corresponds to the leading edge of the character, the value of <c>piTrailing</c> is 0. If the x
		/// coordinate corresponds to the trailing edge of the character, the value of <c>piTrailing</c> is a positive integer. As for
		/// ScriptXtoCP, the value is 1 for a character that can be rendered on its own. The value is greater than 1 if the character is
		/// part of a cluster in a script for which cursors are not placed within a cluster, to indicate the offset to the next
		/// legitimate logical cursor position.
		/// </para>
		/// <para>
		/// If the x coordinate is before the beginning of the line, the function retrieves -1 for <c>piCh</c> and 1 for
		/// <c>piTrailing</c>, indicating the trailing edge of the nonexistent character before the line. If the x coordinate is after
		/// the end of the line, the function retrieves for <c>piCh</c> the first index beyond the length of the line and 0 for
		/// <c>piTrailing</c>. The 0 value indicates the leading edge of the nonexistent character after the line.
		/// </para>
		/// </remarks>
		public (int cp, int trailing) XtoCP(int x)
		{
			(int cp, int trailing) ret = default;
			ScriptStringXtoCP(this, x, out ret.cp, out ret.trailing).ThrowIfFailed();
			return ret;
		}

		/// <inheritdoc/>
		protected override bool InternalReleaseHandle() => ScriptStringFree(ref handle).Succeeded;

		private unsafe TRet? RetOrDef<TRet>(GetVal<TRet> f) where TRet : unmanaged
		{
			TRet* ret = f(this);
			return ret == null ? null : *ret;
		}
	}
}