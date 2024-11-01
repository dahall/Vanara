namespace Vanara.PInvoke;

/// <summary>Items from the Dwrite.dll</summary>
public static partial class Dwrite
{
	/// <summary>Maximum alpha value in a texture returned by IDWriteGlyphRunAnalysis::CreateAlphaTexture.</summary>
	public const uint DWRITE_ALPHA_MAX = 255;

	/// <summary>Indicates the condition at the edges of inline object or text used to determine line-breaking behavior.</summary>
	// https://docs.microsoft.com/en-us/windows/win32/api/dwrite/ne-dwrite-dwrite_break_condition typedef enum DWRITE_BREAK_CONDITION {
	// DWRITE_BREAK_CONDITION_NEUTRAL, DWRITE_BREAK_CONDITION_CAN_BREAK, DWRITE_BREAK_CONDITION_MAY_NOT_BREAK,
	// DWRITE_BREAK_CONDITION_MUST_BREAK } ;
	[PInvokeData("dwrite.h", MSDNShortId = "26dbe63e-eeee-486f-aa94-74320b190fcb")]
	public enum DWRITE_BREAK_CONDITION
	{
		/// <summary>Indicates whether a break is allowed by determining the condition of the neighboring text span or inline object.</summary>
		DWRITE_BREAK_CONDITION_NEUTRAL,

		/// <summary>
		/// Indicates that a line break is allowed, unless overruled by the condition of the neighboring text span or inline object,
		/// either prohibited by a "may not break" condition or forced by a "must break" condition.
		/// </summary>
		DWRITE_BREAK_CONDITION_CAN_BREAK,

		/// <summary>
		/// Indicates that there should be no line break, unless overruled by a "must break" condition from the neighboring text span or
		/// inline object.
		/// </summary>
		DWRITE_BREAK_CONDITION_MAY_NOT_BREAK,

		/// <summary>Indicates that the line break must happen, regardless of the condition of the adjacent text span or inline object.</summary>
		DWRITE_BREAK_CONDITION_MUST_BREAK,
	}

	/// <summary>Specifies the type of DirectWrite factory object.</summary>
	/// <remarks>
	/// A DirectWrite factory object contains information about its internal state, such as font loader registration and cached font
	/// data. In most cases you should use the shared factory object, because it allows multiple components that use DirectWrite to
	/// share internal DirectWrite state information, thereby reducing memory usage. However, there are cases when it is desirable to
	/// reduce the impact of a component on the rest of the process, such as a plug-in from an untrusted source, by sandboxing and
	/// isolating it from the rest of the process components. In such cases, you should use an isolated factory for the sandboxed component.
	/// </remarks>
	// https://docs.microsoft.com/en-us/windows/win32/api/dwrite/ne-dwrite-dwrite_factory_type typedef enum DWRITE_FACTORY_TYPE {
	// DWRITE_FACTORY_TYPE_SHARED, DWRITE_FACTORY_TYPE_ISOLATED } ;
	[PInvokeData("dwrite.h", MSDNShortId = "ce51d8cd-3125-49e3-878c-9d4b446e2422")]
	public enum DWRITE_FACTORY_TYPE
	{
		/// <summary>
		/// Indicates that the DirectWrite factory is a shared factory and that it allows for the reuse of cached font data across
		/// multiple in-process components. Such factories also take advantage of cross process font caching components for better performance.
		/// </summary>
		DWRITE_FACTORY_TYPE_SHARED,

		/// <summary>
		/// Indicates that the DirectWrite factory object is isolated. Objects created from the isolated factory do not interact with
		/// internal DirectWrite state from other components.
		/// </summary>
		DWRITE_FACTORY_TYPE_ISOLATED,
	}

	/// <summary>Indicates the direction of how lines of text are placed relative to one another.</summary>
	// https://docs.microsoft.com/en-us/windows/win32/api/dwrite/ne-dwrite-dwrite_flow_direction typedef enum DWRITE_FLOW_DIRECTION {
	// DWRITE_FLOW_DIRECTION_TOP_TO_BOTTOM, DWRITE_FLOW_DIRECTION_BOTTOM_TO_TOP, DWRITE_FLOW_DIRECTION_LEFT_TO_RIGHT,
	// DWRITE_FLOW_DIRECTION_RIGHT_TO_LEFT } ;
	[PInvokeData("dwrite.h", MSDNShortId = "35a78bde-ba80-4328-8fb8-77ca73c1c04b")]
	public enum DWRITE_FLOW_DIRECTION
	{
		/// <summary>Specifies that text lines are placed from top to bottom.</summary>
		DWRITE_FLOW_DIRECTION_TOP_TO_BOTTOM,

		/// <summary>Specifies that text lines are placed from bottom to top.</summary>
		DWRITE_FLOW_DIRECTION_BOTTOM_TO_TOP,

		/// <summary>Specifies that text lines are placed from left to right.</summary>
		DWRITE_FLOW_DIRECTION_LEFT_TO_RIGHT,

		/// <summary>Specifies that text lines are placed from right to left.</summary>
		DWRITE_FLOW_DIRECTION_RIGHT_TO_LEFT,
	}

	/// <summary>Indicates the file format of a complete font face.</summary>
	/// <remarks>Font formats that consist of multiple files, such as Type 1 .PFM and .PFB, have a single enum entry.</remarks>
	// https://docs.microsoft.com/en-us/windows/win32/api/dwrite/ne-dwrite-dwrite_font_face_type typedef enum DWRITE_FONT_FACE_TYPE {
	// DWRITE_FONT_FACE_TYPE_CFF, DWRITE_FONT_FACE_TYPE_TRUETYPE, DWRITE_FONT_FACE_TYPE_OPENTYPE_COLLECTION,
	// DWRITE_FONT_FACE_TYPE_TYPE1, DWRITE_FONT_FACE_TYPE_VECTOR, DWRITE_FONT_FACE_TYPE_BITMAP, DWRITE_FONT_FACE_TYPE_UNKNOWN,
	// DWRITE_FONT_FACE_TYPE_RAW_CFF, DWRITE_FONT_FACE_TYPE_TRUETYPE_COLLECTION } ;
	[PInvokeData("dwrite.h", MSDNShortId = "839527fb-2560-4472-8115-960bf5b6badd")]
	public enum DWRITE_FONT_FACE_TYPE
	{
		/// <summary>OpenType font face with CFF outlines.</summary>
		DWRITE_FONT_FACE_TYPE_CFF,

		/// <summary>OpenType font face with TrueType outlines.</summary>
		DWRITE_FONT_FACE_TYPE_TRUETYPE,

		/// <summary/>
		DWRITE_FONT_FACE_TYPE_OPENTYPE_COLLECTION,

		/// <summary>A Type 1 font face.</summary>
		DWRITE_FONT_FACE_TYPE_TYPE1,

		/// <summary>A vector .FON format font face.</summary>
		DWRITE_FONT_FACE_TYPE_VECTOR,

		/// <summary>A bitmap .FON format font face.</summary>
		DWRITE_FONT_FACE_TYPE_BITMAP,

		/// <summary>Font face type is not recognized by the DirectWrite font system.</summary>
		DWRITE_FONT_FACE_TYPE_UNKNOWN,

		/// <summary>
		/// The font data includes only the CFF table from an OpenType CFF font. This font face type can be used only for embedded fonts
		/// (i.e., custom font file loaders) and the resulting font face object supports only the minimum functionality necessary to
		/// render glyphs.
		/// </summary>
		DWRITE_FONT_FACE_TYPE_RAW_CFF,

		/// <summary>OpenType font face that is a part of a TrueType collection.</summary>
		DWRITE_FONT_FACE_TYPE_TRUETYPE_COLLECTION = DWRITE_FONT_FACE_TYPE_OPENTYPE_COLLECTION,
	}

	/// <summary>A value that indicates the typographic feature of text supplied by the font.</summary>
	// https://docs.microsoft.com/en-us/windows/win32/api/dwrite/ne-dwrite-dwrite_font_feature_tag
	[PInvokeData("dwrite.h", MSDNShortId = "31f0d1b5-36f2-4bde-b39c-b1392f9d925f")]
	public enum DWRITE_FONT_FEATURE_TAG : uint
	{
		/// <summary>Replaces figures separated by a slash with an alternative form.Equivalent OpenType tag: 'afrc'</summary>
		DWRITE_FONT_FEATURE_TAG_ALTERNATIVE_FRACTIONS = ((byte)'a') | (((uint)(byte)'f') << 8) | (((uint)(byte)'r') << 16) | (((uint)(byte)'c') << 24),

		/// <summary>
		/// Turns capital characters into petite capitals. It is generally used for words which would otherwise be set in all caps, such
		/// as acronyms, but which are desired in petite-cap form to avoid disrupting the flow of text. See the pcap feature description
		/// for notes on the relationship of caps, smallcaps and petite caps.Equivalent OpenType tag: 'c2pc'
		/// </summary>
		DWRITE_FONT_FEATURE_TAG_PETITE_CAPITALS_FROM_CAPITALS = ((byte)'c') | (((uint)(byte)'2') << 8) | (((uint)(byte)'p') << 16) | (((uint)(byte)'c') << 24),

		/// <summary>
		/// Turns capital characters into small capitals. It is generally used for words which would otherwise be set in all caps, such
		/// as acronyms, but which are desired in small-cap form to avoid disrupting the flow of text. Equivalent OpenType tag: 'c2sc'
		/// </summary>
		DWRITE_FONT_FEATURE_TAG_SMALL_CAPITALS_FROM_CAPITALS = ((byte)'c') | (((uint)(byte)'2') << 8) | (((uint)(byte)'s') << 16) | (((uint)(byte)'c') << 24),

		/// <summary>
		/// In specified situations, replaces default glyphs with alternate forms which provide better joining behavior. Used in script
		/// typefaces which are designed to have some or all of their glyphs join.Equivalent OpenType tag: 'calt'
		/// </summary>
		DWRITE_FONT_FEATURE_TAG_CONTEXTUAL_ALTERNATES = ((byte)'c') | (((uint)(byte)'a') << 8) | (((uint)(byte)'l') << 16) | (((uint)(byte)'t') << 24),

		/// <summary>
		/// Shifts various punctuation marks up to a position that works better with all-capital sequences or sets of lining figures;
		/// also changes oldstyle figures to lining figures. By default, glyphs in a text face are designed to work with lowercase
		/// characters. Some characters should be shifted vertically to fit the higher visual center of all-capital or lining text.
		/// Also, lining figures are the same height (or close to it) as capitals, and fit much better with all-capital text.Equivalent
		/// OpenType tag: 'case'
		/// </summary>
		DWRITE_FONT_FEATURE_TAG_CASE_SENSITIVE_FORMS = ((byte)'c') | (((uint)(byte)'a') << 8) | (((uint)(byte)'s') << 16) | (((uint)(byte)'e') << 24),

		/// <summary>
		/// To minimize the number of glyph alternates, it is sometimes desired to decompose a character into two glyphs. Additionally,
		/// it may be preferable to compose two characters into a single glyph for better glyph processing. This feature permits such
		/// composition/decomposition. The feature should be processed as the first feature processed, and should be processed only when
		/// it is called.Equivalent OpenType tag: 'ccmp'
		/// </summary>
		DWRITE_FONT_FEATURE_TAG_GLYPH_COMPOSITION_DECOMPOSITION = ((byte)'c') | (((uint)(byte)'c') << 8) | (((uint)(byte)'m') << 16) | (((uint)(byte)'p') << 24),

		/// <summary>
		/// Replaces a sequence of glyphs with a single glyph which is preferred for typographic purposes. Unlike other ligature
		/// features, clig specifies the context in which the ligature is recommended. This capability is important in some script
		/// designs and for swash ligatures.Equivalent OpenType tag: 'clig'
		/// </summary>
		DWRITE_FONT_FEATURE_TAG_CONTEXTUAL_LIGATURES = ((byte)'c') | (((uint)(byte)'l') << 8) | (((uint)(byte)'i') << 16) | (((uint)(byte)'g') << 24),

		/// <summary>
		/// Globally adjusts inter-glyph spacing for all-capital text. Most typefaces contain capitals and lowercase characters, and the
		/// capitals are positioned to work with the lowercase. When capitals are used for words, they need more space between them for
		/// legibility and esthetics. This feature would not apply to monospaced designs. Of course the user may want to override this
		/// behavior in order to do more pronounced letterspacing for esthetic reasons.Equivalent OpenType tag: 'cpsp'
		/// </summary>
		DWRITE_FONT_FEATURE_TAG_CAPITAL_SPACING = ((byte)'c') | (((uint)(byte)'p') << 8) | (((uint)(byte)'s') << 16) | (((uint)(byte)'p') << 24),

		/// <summary>
		/// Replaces default character glyphs with corresponding swash glyphs in a specified context. Note that there may be more than
		/// one swash alternate for a given character.Equivalent OpenType tag: 'cswh'
		/// </summary>
		DWRITE_FONT_FEATURE_TAG_CONTEXTUAL_SWASH = ((byte)'c') | (((uint)(byte)'s') << 8) | (((uint)(byte)'w') << 16) | (((uint)(byte)'h') << 24),

		/// <summary>In cursive scripts like Arabic, this feature cursively positions adjacent glyphs.Equivalent OpenType tag: 'curs'</summary>
		DWRITE_FONT_FEATURE_TAG_CURSIVE_POSITIONING = ((byte)'c') | (((uint)(byte)'u') << 8) | (((uint)(byte)'r') << 16) | (((uint)(byte)'s') << 24),

		/// <summary>The default.</summary>
		DWRITE_FONT_FEATURE_TAG_DEFAULT = ((byte)'d') | (((uint)(byte)'f') << 8) | (((uint)(byte)'l') << 16) | (((uint)(byte)'t') << 24),

		/// <summary>
		/// Replaces a sequence of glyphs with a single glyph which is preferred for typographic purposes. This feature covers those
		/// ligatures which may be used for special effect, at the user's preference.Equivalent OpenType tag: 'dlig'
		/// </summary>
		DWRITE_FONT_FEATURE_TAG_DISCRETIONARY_LIGATURES = ((byte)'d') | (((uint)(byte)'l') << 8) | (((uint)(byte)'i') << 16) | (((uint)(byte)'g') << 24),

		/// <summary>
		/// Replaces standard forms in Japanese fonts with corresponding forms preferred by typographers. For example, a user would
		/// invoke this feature to replace kanji character U+5516 with U+555E.Equivalent OpenType tag: 'expt'
		/// </summary>
		DWRITE_FONT_FEATURE_TAG_EXPERT_FORMS = ((byte)'e') | (((uint)(byte)'x') << 8) | (((uint)(byte)'p') << 16) | (((uint)(byte)'t') << 24),

		/// <summary>Replaces figures separated by a slash with 'common' (diagonal) fractions.Equivalent OpenType tag: 'frac'</summary>
		DWRITE_FONT_FEATURE_TAG_FRACTIONS = ((byte)'f') | (((uint)(byte)'r') << 8) | (((uint)(byte)'a') << 16) | (((uint)(byte)'c') << 24),

		/// <summary>
		/// Replaces glyphs set on other widths with glyphs set on full (usually em) widths. In a CJKV font, this may include "lower
		/// ASCII" Latin characters and various symbols. In a European font, this feature replaces proportionally-spaced glyphs with
		/// monospaced glyphs, which are generally set on widths of 0.6 em. For example, a user may invoke this feature in a Japanese
		/// font to get full monospaced Latin glyphs instead of the corresponding proportionally-spaced versions.Equivalent OpenType
		/// tag: 'fwid'
		/// </summary>
		DWRITE_FONT_FEATURE_TAG_FULL_WIDTH = ((byte)'f') | (((uint)(byte)'w') << 8) | (((uint)(byte)'i') << 16) | (((uint)(byte)'d') << 24),

		/// <summary>
		/// Produces the half forms of consonants in Indic scripts. For example, in Hindi (Devanagari script), the conjunct KKa,
		/// obtained by doubling the Ka, is denoted with a half form of Ka followed by the full form. Equivalent OpenType tag: 'half'
		/// </summary>
		DWRITE_FONT_FEATURE_TAG_HALF_FORMS = ((byte)'h') | (((uint)(byte)'a') << 8) | (((uint)(byte)'l') << 16) | (((uint)(byte)'f') << 24),

		/// <summary>
		/// Produces the halant forms of consonants in Indic scripts. For example, in Sanskrit (Devanagari script), syllable final
		/// consonants are frequently required in their halant form.Equivalent OpenType tag: 'haln'
		/// </summary>
		DWRITE_FONT_FEATURE_TAG_HALANT_FORMS = ((byte)'h') | (((uint)(byte)'a') << 8) | (((uint)(byte)'l') << 16) | (((uint)(byte)'n') << 24),

		/// <summary>
		/// Respaces glyphs designed to be set on full-em widths, fitting them onto half-em widths. This differs from hwid in that it
		/// does not substitute new glyphs.Equivalent OpenType tag: 'halt'
		/// </summary>
		DWRITE_FONT_FEATURE_TAG_ALTERNATE_HALF_WIDTH = ((byte)'h') | (((uint)(byte)'a') << 8) | (((uint)(byte)'l') << 16) | (((uint)(byte)'t') << 24),

		/// <summary>
		/// Replaces the default (current) forms with the historical alternates. While some ligatures are also used for historical
		/// effect, this feature deals only with single characters. Some fonts include the historical forms as alternates, so they can
		/// be used for a 'period' effect. Equivalent OpenType tag: 'hist'
		/// </summary>
		DWRITE_FONT_FEATURE_TAG_HISTORICAL_FORMS = ((byte)'h') | (((uint)(byte)'i') << 8) | (((uint)(byte)'s') << 16) | (((uint)(byte)'t') << 24),

		/// <summary>
		/// Replaces standard kana with forms that have been specially designed for only horizontal writing. This is a typographic
		/// optimization for improved fit and more even color.Equivalent OpenType tag: 'hkna'
		/// </summary>
		DWRITE_FONT_FEATURE_TAG_HORIZONTAL_KANA_ALTERNATES = ((byte)'h') | (((uint)(byte)'k') << 8) | (((uint)(byte)'n') << 16) | (((uint)(byte)'a') << 24),

		/// <summary>
		/// Replaces the default (current) forms with the historical alternates. Some ligatures were in common use in the past, but
		/// appear anachronistic today. Some fonts include the historical forms as alternates, so they can be used for a 'period'
		/// effect.Equivalent OpenType tag: 'hlig'
		/// </summary>
		DWRITE_FONT_FEATURE_TAG_HISTORICAL_LIGATURES = ((byte)'h') | (((uint)(byte)'l') << 8) | (((uint)(byte)'i') << 16) | (((uint)(byte)'g') << 24),

		/// <summary>
		/// Replaces glyphs on proportional widths, or fixed widths other than half an em, with glyphs on half-em (en) widths. Many CJKV
		/// fonts have glyphs which are set on multiple widths; this feature selects the half-em version. There are various contexts in
		/// which this is the preferred behavior, including compatibility with older desktop documents.Equivalent OpenType tag: 'hwid'
		/// </summary>
		DWRITE_FONT_FEATURE_TAG_HALF_WIDTH = ((byte)'h') | (((uint)(byte)'w') << 8) | (((uint)(byte)'i') << 16) | (((uint)(byte)'d') << 24),

		/// <summary>
		/// Used to access the JIS X 0212-1990 glyphs for the cases when the JIS X 0213:2004 form is encoded. The JIS X 0212-1990 (aka,
		/// "Hojo Kanji") and JIS X 0213:2004 character sets overlap significantly. In some cases their prototypical glyphs differ. When
		/// building fonts that support both JIS X 0212-1990 and JIS X 0213:2004 (such as those supporting the Adobe-Japan 1-6 character
		/// collection), it is recommended that JIS X 0213:2004 forms be the preferred encoded form.Equivalent OpenType tag: 'hojo'
		/// </summary>
		DWRITE_FONT_FEATURE_TAG_HOJO_KANJI_FORMS = ((byte)'h') | (((uint)(byte)'o') << 8) | (((uint)(byte)'j') << 16) | (((uint)(byte)'o') << 24),

		/// <summary>
		/// The National Language Council (NLC) of Japan has defined new glyph shapes for a number of JIS characters, which were
		/// incorporated into JIS X 0213:2004 as new prototypical forms. The 'jp04' feature is A subset of the 'nlck' feature, and is
		/// used to access these prototypical glyphs in a manner that maintains the integrity of JIS X 0213:2004.Equivalent OpenType
		/// tag: 'jp04'
		/// </summary>
		DWRITE_FONT_FEATURE_TAG_JIS04_FORMS = ((byte)'j') | (((uint)(byte)'p') << 8) | (((uint)(byte)'0') << 16) | (((uint)(byte)'4') << 24),

		/// <summary>
		/// Replaces default (JIS90) Japanese glyphs with the corresponding forms from the JIS C 6226-1978 (JIS78)
		/// specification.Equivalent OpenType tag: 'jp78'
		/// </summary>
		DWRITE_FONT_FEATURE_TAG_JIS78_FORMS = ((byte)'j') | (((uint)(byte)'p') << 8) | (((uint)(byte)'7') << 16) | (((uint)(byte)'8') << 24),

		/// <summary>
		/// Replaces default (JIS90) Japanese glyphs with the corresponding forms from the JIS X 0208-1983 (JIS83)
		/// specification.Equivalent OpenType tag: 'jp83'
		/// </summary>
		DWRITE_FONT_FEATURE_TAG_JIS83_FORMS = ((byte)'j') | (((uint)(byte)'p') << 8) | (((uint)(byte)'8') << 16) | (((uint)(byte)'3') << 24),

		/// <summary>
		/// Replaces Japanese glyphs from the JIS78 or JIS83 specifications with the corresponding forms from the JIS X 0208-1990
		/// (JIS90) specification.Equivalent OpenType tag: 'jp90'
		/// </summary>
		DWRITE_FONT_FEATURE_TAG_JIS90_FORMS = ((byte)'j') | (((uint)(byte)'p') << 8) | (((uint)(byte)'9') << 16) | (((uint)(byte)'0') << 24),

		/// <summary>
		/// Adjusts amount of space between glyphs, generally to provide optically consistent spacing between glyphs. Although a
		/// well-designed typeface has consistent inter-glyph spacing overall, some glyph combinations require adjustment for improved
		/// legibility. Besides standard adjustment in the horizontal direction, this feature can supply size-dependent kerning data via
		/// device tables, "cross-stream" kerning in the Y text direction, and adjustment of glyph placement independent of the advance
		/// adjustment. Note that this feature may apply to runs of more than two glyphs, and would not be used in monospaced fonts.
		/// Also note that this feature does not apply to text set vertically.Equivalent OpenType tag: 'kern'
		/// </summary>
		DWRITE_FONT_FEATURE_TAG_KERNING = ((byte)'k') | (((uint)(byte)'e') << 8) | (((uint)(byte)'r') << 16) | (((uint)(byte)'n') << 24),

		/// <summary>
		/// Replaces a sequence of glyphs with a single glyph which is preferred for typographic purposes. This feature covers the
		/// ligatures which the designer/manufacturer judges should be used in normal conditions.Equivalent OpenType tag: 'liga'
		/// </summary>
		DWRITE_FONT_FEATURE_TAG_STANDARD_LIGATURES = ((byte)'l') | (((uint)(byte)'i') << 8) | (((uint)(byte)'g') << 16) | (((uint)(byte)'a') << 24),

		/// <summary>
		/// Changes selected figures from oldstyle to the default lining form. For example, a user may invoke this feature in order to
		/// get lining figures, which fit better with all-capital text. This feature overrides results of the Oldstyle Figures feature
		/// (onum).Equivalent OpenType tag: 'lnum'
		/// </summary>
		DWRITE_FONT_FEATURE_TAG_LINING_FIGURES = ((byte)'l') | (((uint)(byte)'n') << 8) | (((uint)(byte)'u') << 16) | (((uint)(byte)'m') << 24),

		/// <summary>
		/// Enables localized forms of glyphs to be substituted for default forms. Many scripts used to write multiple languages over
		/// wide geographical areas have developed localized variant forms of specific letters, which are used by individual literary
		/// communities. For example, a number of letters in the Bulgarian and Serbian alphabets have forms distinct from their Russian
		/// counterparts and from each other. In some cases the localized form differs only subtly from the script 'norm', in others the
		/// forms are radically distinct. Equivalent OpenType tag: 'locl'
		/// </summary>
		DWRITE_FONT_FEATURE_TAG_LOCALIZED_FORMS = ((byte)'l') | (((uint)(byte)'o') << 8) | (((uint)(byte)'c') << 16) | (((uint)(byte)'l') << 24),

		/// <summary>
		/// Positions mark glyphs with respect to base glyphs. For example, in Arabic script positioning the Hamza above the
		/// Yeh.Equivalent OpenType tag: 'mark'
		/// </summary>
		DWRITE_FONT_FEATURE_TAG_MARK_POSITIONING = ((byte)'m') | (((uint)(byte)'a') << 8) | (((uint)(byte)'r') << 16) | (((uint)(byte)'k') << 24),

		/// <summary>
		/// Replaces standard typographic forms of Greek glyphs with corresponding forms commonly used in mathematical notation (which
		/// are a subset of the Greek alphabet).Equivalent OpenType tag: 'mgrk'
		/// </summary>
		DWRITE_FONT_FEATURE_TAG_MATHEMATICAL_GREEK = ((byte)'m') | (((uint)(byte)'g') << 8) | (((uint)(byte)'r') << 16) | (((uint)(byte)'k') << 24),

		/// <summary>
		/// Positions marks with respect to other marks. Required in various non-Latin scripts like Arabic. For example, in Arabic, the
		/// ligaturised mark Ha with Hamza above it can also be obtained by positioning these marks relative to one another.Equivalent
		/// OpenType tag: 'mkmk'
		/// </summary>
		DWRITE_FONT_FEATURE_TAG_MARK_TO_MARK_POSITIONING = ((byte)'m') | (((uint)(byte)'k') << 8) | (((uint)(byte)'m') << 16) | (((uint)(byte)'k') << 24),

		/// <summary>
		/// Replaces default glyphs with various notational forms (such as glyphs placed in open or solid circles, squares, parentheses,
		/// diamonds or rounded boxes). In some cases an annotation form may already be present, but the user may want a different
		/// one.Equivalent OpenType tag: 'nalt'
		/// </summary>
		DWRITE_FONT_FEATURE_TAG_ALTERNATE_ANNOTATION_FORMS = ((byte)'n') | (((uint)(byte)'a') << 8) | (((uint)(byte)'l') << 16) | (((uint)(byte)'t') << 24),

		/// <summary>
		/// Used to access glyphs made from glyph shapes defined by the National Language Council (NLC) of Japan for a number of JIS
		/// characters in 2000. Equivalent OpenType tag: 'nlck'
		/// </summary>
		DWRITE_FONT_FEATURE_TAG_NLC_KANJI_FORMS = ((byte)'n') | (((uint)(byte)'l') << 8) | (((uint)(byte)'c') << 16) | (((uint)(byte)'k') << 24),

		/// <summary>
		/// Changes selected figures from the default lining style to oldstyle form. For example, a user may invoke this feature to get
		/// oldstyle figures, which fit better into the flow of normal upper- and lowercase text. This feature overrides results of the
		/// Lining Figures feature (lnum).Equivalent OpenType tag: 'onum'
		/// </summary>
		DWRITE_FONT_FEATURE_TAG_OLD_STYLE_FIGURES = ((byte)'o') | (((uint)(byte)'n') << 8) | (((uint)(byte)'u') << 16) | (((uint)(byte)'m') << 24),

		/// <summary>
		/// Replaces default alphabetic glyphs with the corresponding ordinal forms for use after figures. One exception to the
		/// follows-a-figure rule is the numero character (U+2116), which is actually a ligature substitution, but is best accessed
		/// through this feature.Equivalent OpenType tag: 'ordn'
		/// </summary>
		DWRITE_FONT_FEATURE_TAG_ORDINALS = ((byte)'o') | (((uint)(byte)'r') << 8) | (((uint)(byte)'d') << 16) | (((uint)(byte)'n') << 24),

		/// <summary>
		/// Respaces glyphs designed to be set on full-em widths, fitting them onto individual (more or less proportional) horizontal
		/// widths. This differs from pwid in that it does not substitute new glyphs (GPOS, not GSUB feature). The user may prefer the
		/// monospaced form, or may simply want to ensure that the glyph is well-fit and not rotated in vertical setting (Latin forms
		/// designed for proportional spacing would be rotated).Equivalent OpenType tag: 'palt'
		/// </summary>
		DWRITE_FONT_FEATURE_TAG_PROPORTIONAL_ALTERNATE_WIDTH = ((byte)'p') | (((uint)(byte)'a') << 8) | (((uint)(byte)'l') << 16) | (((uint)(byte)'t') << 24),

		/// <summary>
		/// Turns lowercase characters into petite capitals. Forms related to petite capitals, such as specially designed figures, may
		/// be included. Some fonts contain an additional size of capital letters, shorter than the regular smallcaps and it is referred
		/// to as petite caps. Such forms are most likely to be found in designs with a small lowercase x-height, where they better
		/// harmonise with lowercase text than the taller smallcaps (for examples of petite caps, see the Emigre type families Mrs Eaves
		/// and Filosofia). Equivalent OpenType tag: 'pcap'
		/// </summary>
		DWRITE_FONT_FEATURE_TAG_PETITE_CAPITALS = ((byte)'p') | (((uint)(byte)'c') << 8) | (((uint)(byte)'a') << 16) | (((uint)(byte)'p') << 24),

		/// <summary>
		/// Replaces figure glyphs set on uniform (tabular) widths with corresponding glyphs set on glyph-specific (proportional)
		/// widths. Tabular widths will generally be the default, but this cannot be safely assumed. Of course this feature would not be
		/// present in monospaced designs.Equivalent OpenType tag: 'pnum'
		/// </summary>
		DWRITE_FONT_FEATURE_TAG_PROPORTIONAL_FIGURES = ((byte)'p') | (((uint)(byte)'n') << 8) | (((uint)(byte)'u') << 16) | (((uint)(byte)'m') << 24),

		/// <summary>
		/// Replaces glyphs set on uniform widths (typically full or half-em) with proportionally spaced glyphs. The proportional
		/// variants are often used for the Latin characters in CJKV fonts, but may also be used for Kana in Japanese fonts.Equivalent
		/// OpenType tag: 'pwid'
		/// </summary>
		DWRITE_FONT_FEATURE_TAG_PROPORTIONAL_WIDTHS = ((byte)'p') | (((uint)(byte)'w') << 8) | (((uint)(byte)'i') << 16) | (((uint)(byte)'d') << 24),

		/// <summary>
		/// Replaces glyphs on other widths with glyphs set on widths of one quarter of an em (half an en). The characters involved are
		/// normally figures and some forms of punctuation.Equivalent OpenType tag: 'qwid'
		/// </summary>
		DWRITE_FONT_FEATURE_TAG_QUARTER_WIDTHS = ((byte)'q') | (((uint)(byte)'w') << 8) | (((uint)(byte)'i') << 16) | (((uint)(byte)'d') << 24),

		/// <summary>
		/// Replaces a sequence of glyphs with a single glyph which is preferred for typographic purposes. This feature covers those
		/// ligatures, which the script determines as required to be used in normal conditions. This feature is important for some
		/// scripts to ensure correct glyph formation. Equivalent OpenType tag: 'rlig'
		/// </summary>
		DWRITE_FONT_FEATURE_TAG_REQUIRED_LIGATURES = ((byte)'r') | (((uint)(byte)'l') << 8) | (((uint)(byte)'i') << 16) | (((uint)(byte)'g') << 24),

		/// <summary>
		/// Identifies glyphs in the font which have been designed for "ruby", from the old typesetting term for four-point-sized type.
		/// Japanese typesetting often uses smaller kana glyphs, generally in superscripted form, to clarify the meaning of kanji which
		/// may be unfamiliar to the reader. Equivalent OpenType tag: 'ruby'
		/// </summary>
		DWRITE_FONT_FEATURE_TAG_RUBY_NOTATION_FORMS = ((byte)'r') | (((uint)(byte)'u') << 8) | (((uint)(byte)'b') << 16) | (((uint)(byte)'y') << 24),

		/// <summary>
		/// Replaces the default forms with the stylistic alternates. Many fonts contain alternate glyph designs for a purely esthetic
		/// effect; these don't always fit into a clear category like swash or historical. As in the case of swash glyphs, there may be
		/// more than one alternate form. Equivalent OpenType tag: 'salt'
		/// </summary>
		DWRITE_FONT_FEATURE_TAG_STYLISTIC_ALTERNATES = ((byte)'s') | (((uint)(byte)'a') << 8) | (((uint)(byte)'l') << 16) | (((uint)(byte)'t') << 24),

		/// <summary>
		/// Replaces lining or oldstyle figures with inferior figures (smaller glyphs which sit lower than the standard baseline,
		/// primarily for chemical or mathematical notation). May also replace lowercase characters with alphabetic inferiors.Equivalent
		/// OpenType tag: 'sinf'
		/// </summary>
		DWRITE_FONT_FEATURE_TAG_SCIENTIFIC_INFERIORS = ((byte)'s') | (((uint)(byte)'i') << 8) | (((uint)(byte)'n') << 16) | (((uint)(byte)'f') << 24),

		/// <summary>
		/// Turns lowercase characters into small capitals. This corresponds to the common SC font layout. It is generally used for
		/// display lines set in Large &amp; small caps, such as titles. Forms related to small capitals, such as oldstyle figures, may
		/// be included.Equivalent OpenType tag: 'smcp'
		/// </summary>
		DWRITE_FONT_FEATURE_TAG_SMALL_CAPITALS = ((byte)'s') | (((uint)(byte)'m') << 8) | (((uint)(byte)'c') << 16) | (((uint)(byte)'p') << 24),

		/// <summary>
		/// Replaces 'traditional' Chinese or Japanese forms with the corresponding 'simplified' forms.Equivalent OpenType tag: 'smpl'
		/// </summary>
		DWRITE_FONT_FEATURE_TAG_SIMPLIFIED_FORMS = ((byte)'s') | (((uint)(byte)'m') << 8) | (((uint)(byte)'p') << 16) | (((uint)(byte)'l') << 24),

		/// <summary>
		/// In addition to, or instead of, stylistic alternatives of individual glyphs (see 'salt' feature), some fonts may contain sets
		/// of stylistic variant glyphs corresponding to portions of the character set, such as multiple variants for lowercase letters
		/// in a Latin font. Glyphs in stylistic sets may be designed to harmonise visually, interract in particular ways, or otherwise
		/// work together. Examples of fonts including stylistic sets are Zapfino Linotype and Adobe's Poetica. Individual features
		/// numbered sequentially with the tag name convention 'ss01' 'ss02' 'ss03' . 'ss20' provide a mechanism for glyphs in these
		/// sets to be associated via GSUB lookup indexes to default forms and to each other, and for users to select from available
		/// stylistic setsEquivalent OpenType tag: 'ss01'
		/// </summary>
		DWRITE_FONT_FEATURE_TAG_STYLISTIC_SET_1 = ((byte)'s') | (((uint)(byte)'s') << 8) | (((uint)(byte)'0') << 16) | (((uint)(byte)'1') << 24),

		/// <summary>See the description for DWRITE_FONT_FEATURE_TAG_STYLISTIC_SET_1.Equivalent OpenType tag: 'ss02'</summary>
		DWRITE_FONT_FEATURE_TAG_STYLISTIC_SET_2 = ((byte)'s') | (((uint)(byte)'s') << 8) | (((uint)(byte)'0') << 16) | (((uint)(byte)'2') << 24),

		/// <summary>See the description for DWRITE_FONT_FEATURE_TAG_STYLISTIC_SET_1.Equivalent OpenType tag: 'ss03'</summary>
		DWRITE_FONT_FEATURE_TAG_STYLISTIC_SET_3 = ((byte)'s') | (((uint)(byte)'s') << 8) | (((uint)(byte)'0') << 16) | (((uint)(byte)'3') << 24),

		/// <summary>See the description for DWRITE_FONT_FEATURE_TAG_STYLISTIC_SET_1.Equivalent OpenType tag: 'ss04'</summary>
		DWRITE_FONT_FEATURE_TAG_STYLISTIC_SET_4 = ((byte)'s') | (((uint)(byte)'s') << 8) | (((uint)(byte)'0') << 16) | (((uint)(byte)'4') << 24),

		/// <summary>See the description for DWRITE_FONT_FEATURE_TAG_STYLISTIC_SET_1.Equivalent OpenType tag: 'ss05'</summary>
		DWRITE_FONT_FEATURE_TAG_STYLISTIC_SET_5 = ((byte)'s') | (((uint)(byte)'s') << 8) | (((uint)(byte)'0') << 16) | (((uint)(byte)'5') << 24),

		/// <summary>See the description for DWRITE_FONT_FEATURE_TAG_STYLISTIC_SET_1.Equivalent OpenType tag: 'ss06'</summary>
		DWRITE_FONT_FEATURE_TAG_STYLISTIC_SET_6 = ((byte)'s') | (((uint)(byte)'s') << 8) | (((uint)(byte)'0') << 16) | (((uint)(byte)'6') << 24),

		/// <summary>See the description for DWRITE_FONT_FEATURE_TAG_STYLISTIC_SET_1.Equivalent OpenType tag: 'ss07'</summary>
		DWRITE_FONT_FEATURE_TAG_STYLISTIC_SET_7 = ((byte)'s') | (((uint)(byte)'s') << 8) | (((uint)(byte)'0') << 16) | (((uint)(byte)'7') << 24),

		/// <summary>See the description for DWRITE_FONT_FEATURE_TAG_STYLISTIC_SET_1.Equivalent OpenType tag: 'ss08'</summary>
		DWRITE_FONT_FEATURE_TAG_STYLISTIC_SET_8 = ((byte)'s') | (((uint)(byte)'s') << 8) | (((uint)(byte)'0') << 16) | (((uint)(byte)'8') << 24),

		/// <summary>See the description for DWRITE_FONT_FEATURE_TAG_STYLISTIC_SET_1.Equivalent OpenType tag: 'ss09'</summary>
		DWRITE_FONT_FEATURE_TAG_STYLISTIC_SET_9 = ((byte)'s') | (((uint)(byte)'s') << 8) | (((uint)(byte)'0') << 16) | (((uint)(byte)'9') << 24),

		/// <summary>See the description for DWRITE_FONT_FEATURE_TAG_STYLISTIC_SET_1.Equivalent OpenType tag: 'ss10'</summary>
		DWRITE_FONT_FEATURE_TAG_STYLISTIC_SET_10 = ((byte)'s') | (((uint)(byte)'s') << 8) | (((uint)(byte)'1') << 16) | (((uint)(byte)'0') << 24),

		/// <summary>See the description for DWRITE_FONT_FEATURE_TAG_STYLISTIC_SET_1.Equivalent OpenType tag: 'ss11'</summary>
		DWRITE_FONT_FEATURE_TAG_STYLISTIC_SET_11 = ((byte)'s') | (((uint)(byte)'s') << 8) | (((uint)(byte)'1') << 16) | (((uint)(byte)'1') << 24),

		/// <summary>See the description for DWRITE_FONT_FEATURE_TAG_STYLISTIC_SET_1.Equivalent OpenType tag: 'ss12'</summary>
		DWRITE_FONT_FEATURE_TAG_STYLISTIC_SET_12 = ((byte)'s') | (((uint)(byte)'s') << 8) | (((uint)(byte)'1') << 16) | (((uint)(byte)'2') << 24),

		/// <summary>See the description for DWRITE_FONT_FEATURE_TAG_STYLISTIC_SET_1.Equivalent OpenType tag: 'ss13'</summary>
		DWRITE_FONT_FEATURE_TAG_STYLISTIC_SET_13 = ((byte)'s') | (((uint)(byte)'s') << 8) | (((uint)(byte)'1') << 16) | (((uint)(byte)'3') << 24),

		/// <summary>See the description for DWRITE_FONT_FEATURE_TAG_STYLISTIC_SET_1.Equivalent OpenType tag: 'ss14'</summary>
		DWRITE_FONT_FEATURE_TAG_STYLISTIC_SET_14 = ((byte)'s') | (((uint)(byte)'s') << 8) | (((uint)(byte)'1') << 16) | (((uint)(byte)'4') << 24),

		/// <summary>See the description for DWRITE_FONT_FEATURE_TAG_STYLISTIC_SET_1.Equivalent OpenType tag: 'ss15'</summary>
		DWRITE_FONT_FEATURE_TAG_STYLISTIC_SET_15 = ((byte)'s') | (((uint)(byte)'s') << 8) | (((uint)(byte)'1') << 16) | (((uint)(byte)'5') << 24),

		/// <summary>See the description for DWRITE_FONT_FEATURE_TAG_STYLISTIC_SET_1.Equivalent OpenType tag: 'ss16'</summary>
		DWRITE_FONT_FEATURE_TAG_STYLISTIC_SET_16 = ((byte)'s') | (((uint)(byte)'s') << 8) | (((uint)(byte)'1') << 16) | (((uint)(byte)'6') << 24),

		/// <summary>See the description for DWRITE_FONT_FEATURE_TAG_STYLISTIC_SET_1.Equivalent OpenType tag: 'ss17'</summary>
		DWRITE_FONT_FEATURE_TAG_STYLISTIC_SET_17 = ((byte)'s') | (((uint)(byte)'s') << 8) | (((uint)(byte)'1') << 16) | (((uint)(byte)'7') << 24),

		/// <summary>See the description for DWRITE_FONT_FEATURE_TAG_STYLISTIC_SET_1.Equivalent OpenType tag: 'ss18'</summary>
		DWRITE_FONT_FEATURE_TAG_STYLISTIC_SET_18 = ((byte)'s') | (((uint)(byte)'s') << 8) | (((uint)(byte)'1') << 16) | (((uint)(byte)'8') << 24),

		/// <summary>See the description for DWRITE_FONT_FEATURE_TAG_STYLISTIC_SET_1.Equivalent OpenType tag: 'ss19'</summary>
		DWRITE_FONT_FEATURE_TAG_STYLISTIC_SET_19 = ((byte)'s') | (((uint)(byte)'s') << 8) | (((uint)(byte)'1') << 16) | (((uint)(byte)'9') << 24),

		/// <summary>See the description for DWRITE_FONT_FEATURE_TAG_STYLISTIC_SET_1.Equivalent OpenType tag: 'ss20'</summary>
		DWRITE_FONT_FEATURE_TAG_STYLISTIC_SET_20 = ((byte)'s') | (((uint)(byte)'s') << 8) | (((uint)(byte)'2') << 16) | (((uint)(byte)'0') << 24),

		/// <summary>
		/// May replace a default glyph with a subscript glyph, or it may combine a glyph substitution with positioning adjustments for
		/// proper placement.Equivalent OpenType tag: 'subs'
		/// </summary>
		DWRITE_FONT_FEATURE_TAG_SUBSCRIPT = ((byte)'s') | (((uint)(byte)'u') << 8) | (((uint)(byte)'b') << 16) | (((uint)(byte)'s') << 24),

		/// <summary>
		/// Replaces lining or oldstyle figures with superior figures (primarily for footnote indication), and replaces lowercase
		/// letters with superior letters (primarily for abbreviated French titles).Equivalent OpenType tag: 'sups'
		/// </summary>
		DWRITE_FONT_FEATURE_TAG_SUPERSCRIPT = ((byte)'s') | (((uint)(byte)'u') << 8) | (((uint)(byte)'p') << 16) | (((uint)(byte)'s') << 24),

		/// <summary>
		/// Replaces default character glyphs with corresponding swash glyphs. Note that there may be more than one swash alternate for
		/// a given character.Equivalent OpenType tag: 'swsh'
		/// </summary>
		DWRITE_FONT_FEATURE_TAG_SWASH = ((byte)'s') | (((uint)(byte)'w') << 8) | (((uint)(byte)'s') << 16) | (((uint)(byte)'h') << 24),

		/// <summary>
		/// Replaces the default glyphs with corresponding forms designed specifically for titling. These may be all-capital and/or
		/// larger on the body, and adjusted for viewing at larger sizes.Equivalent OpenType tag: 'titl'
		/// </summary>
		DWRITE_FONT_FEATURE_TAG_TITLING = ((byte)'t') | (((uint)(byte)'i') << 8) | (((uint)(byte)'t') << 16) | (((uint)(byte)'l') << 24),

		/// <summary>
		/// Replaces 'simplified' Japanese kanji forms with the corresponding 'traditional' forms. This is equivalent to the Traditional
		/// Forms feature, but explicitly limited to the traditional forms considered proper for use in personal names (as many as 205
		/// glyphs in some fonts).Equivalent OpenType tag: 'tnam'
		/// </summary>
		DWRITE_FONT_FEATURE_TAG_TRADITIONAL_NAME_FORMS = ((byte)'t') | (((uint)(byte)'n') << 8) | (((uint)(byte)'a') << 16) | (((uint)(byte)'m') << 24),

		/// <summary>
		/// Replaces figure glyphs set on proportional widths with corresponding glyphs set on uniform (tabular) widths. Tabular widths
		/// will generally be the default, but this cannot be safely assumed. Of course this feature would not be present in monospaced
		/// designs.Equivalent OpenType tag: 'tnum'
		/// </summary>
		DWRITE_FONT_FEATURE_TAG_TABULAR_FIGURES = ((byte)'t') | (((uint)(byte)'n') << 8) | (((uint)(byte)'u') << 16) | (((uint)(byte)'m') << 24),

		/// <summary>
		/// Replaces 'simplified' Chinese hanzi or Japanese kanji forms with the corresponding 'traditional' forms.Equivalent OpenType
		/// tag: 'trad'
		/// </summary>
		DWRITE_FONT_FEATURE_TAG_TRADITIONAL_FORMS = ((byte)'t') | (((uint)(byte)'r') << 8) | (((uint)(byte)'a') << 16) | (((uint)(byte)'d') << 24),

		/// <summary>
		/// Replaces glyphs on other widths with glyphs set on widths of one third of an em. The characters involved are normally
		/// figures and some forms of punctuation.Equivalent OpenType tag: 'twid'
		/// </summary>
		DWRITE_FONT_FEATURE_TAG_THIRD_WIDTHS = ((byte)'t') | (((uint)(byte)'w') << 8) | (((uint)(byte)'i') << 16) | (((uint)(byte)'d') << 24),

		/// <summary>
		/// Maps upper- and lowercase letters to a mixed set of lowercase and small capital forms, resulting in a single case alphabet
		/// (for an example of unicase, see the Emigre type family Filosofia). The letters substituted may vary from font to font, as
		/// appropriate to the design. If aligning to the x-height, smallcap glyphs may be substituted, or specially designed unicase
		/// forms might be used. Substitutions might also include specially designed figures.Equivalent OpenType tag: 'unic'
		/// </summary>
		DWRITE_FONT_FEATURE_TAG_UNICASE = ((byte)'u') | (((uint)(byte)'n') << 8) | (((uint)(byte)'i') << 16) | (((uint)(byte)'c') << 24),

		/// <summary>Indicates that the font is displayed vertically.</summary>
		DWRITE_FONT_FEATURE_TAG_VERTICAL_WRITING = ((byte)'v') | (((uint)(byte)'e') << 8) | (((uint)(byte)'r') << 16) | (((uint)(byte)'t') << 24),

		/// <summary>Replaces normal figures with figures adjusted for vertical display.</summary>
		DWRITE_FONT_FEATURE_TAG_VERTICAL_ALTERNATES_AND_ROTATION = ((byte)'v') | (((uint)(byte)'r') << 8) | (((uint)(byte)'t') << 16) | (((uint)(byte)'2') << 24),

		/// <summary>
		/// Allows the user to change from the default 0 to a slashed form. Some fonts contain both a default form of zero, and an
		/// alternative form which uses a diagonal slash through the counter. Especially in condensed designs, it can be difficult to
		/// distinguish between 0 and O (zero and capital O) in any situation where capitals and lining figures may be arbitrarily
		/// mixed. Equivalent OpenType tag: 'zero'
		/// </summary>
		DWRITE_FONT_FEATURE_TAG_SLASHED_ZERO = ((byte)'z') | (((uint)(byte)'e') << 8) | (((uint)(byte)'r') << 16) | (((uint)(byte)'o') << 24),
	}

	/// <summary>
	/// The type of a font represented by a single font file. Font formats that consist of multiple files, for example Type 1 .PFM and
	/// .PFB, have separate enum values for each of the file types.
	/// </summary>
	// https://docs.microsoft.com/en-us/windows/win32/api/dwrite/ne-dwrite-dwrite_font_file_type typedef enum DWRITE_FONT_FILE_TYPE {
	// DWRITE_FONT_FILE_TYPE_UNKNOWN, DWRITE_FONT_FILE_TYPE_CFF, DWRITE_FONT_FILE_TYPE_TRUETYPE,
	// DWRITE_FONT_FILE_TYPE_OPENTYPE_COLLECTION, DWRITE_FONT_FILE_TYPE_TYPE1_PFM, DWRITE_FONT_FILE_TYPE_TYPE1_PFB,
	// DWRITE_FONT_FILE_TYPE_VECTOR, DWRITE_FONT_FILE_TYPE_BITMAP, DWRITE_FONT_FILE_TYPE_TRUETYPE_COLLECTION } ;
	[PInvokeData("dwrite.h", MSDNShortId = "04db41a6-b08b-4d01-a878-c05c0f1f2d9c")]
	public enum DWRITE_FONT_FILE_TYPE
	{
		/// <summary>Font type is not recognized by the DirectWrite font system.</summary>
		DWRITE_FONT_FILE_TYPE_UNKNOWN,

		/// <summary>OpenType font with CFF outlines.</summary>
		DWRITE_FONT_FILE_TYPE_CFF,

		/// <summary>OpenType font with TrueType outlines.</summary>
		DWRITE_FONT_FILE_TYPE_TRUETYPE,

		/// <summary/>
		DWRITE_FONT_FILE_TYPE_OPENTYPE_COLLECTION,

		/// <summary>Type 1 PFM font.</summary>
		DWRITE_FONT_FILE_TYPE_TYPE1_PFM,

		/// <summary>Type 1 PFB font.</summary>
		DWRITE_FONT_FILE_TYPE_TYPE1_PFB,

		/// <summary>Vector .FON font.</summary>
		DWRITE_FONT_FILE_TYPE_VECTOR,

		/// <summary>Bitmap .FON font.</summary>
		DWRITE_FONT_FILE_TYPE_BITMAP,

		/// <summary>OpenType font that contains a TrueType collection.</summary>
		DWRITE_FONT_FILE_TYPE_TRUETYPE_COLLECTION = DWRITE_FONT_FILE_TYPE_OPENTYPE_COLLECTION,
	}

	/// <summary>
	/// Specifies algorithmic style simulations to be applied to the font face. Bold and oblique simulations can be combined via bitwise
	/// OR operation.
	/// </summary>
	/// <remarks>Style simulations are not recommended for good typographic quality.</remarks>
	// https://docs.microsoft.com/en-us/windows/win32/api/dwrite/ne-dwrite-dwrite_font_simulations typedef enum DWRITE_FONT_SIMULATIONS
	// { DWRITE_FONT_SIMULATIONS_NONE, DWRITE_FONT_SIMULATIONS_BOLD, DWRITE_FONT_SIMULATIONS_OBLIQUE } ;
	[PInvokeData("dwrite.h", MSDNShortId = "0881afec-2fa5-4f17-96a2-68a5293e0bba")]
	[Flags]
	public enum DWRITE_FONT_SIMULATIONS
	{
		/// <summary>Indicates that no simulations are applied to the font face.</summary>
		DWRITE_FONT_SIMULATIONS_NONE = 0x0000,

		/// <summary>
		/// Indicates that algorithmic emboldening is applied to the font face. DWRITE_FONT_SIMULATIONS_BOLD increases weight by
		/// applying a widening algorithm to the glyph outline. This may be used to simulate a bold weight where no designed bold weight
		/// is available.
		/// </summary>
		DWRITE_FONT_SIMULATIONS_BOLD = 0x0001,

		/// <summary>
		/// Indicates that algorithmic italicization is applied to the font face. DWRITE_FONT_SIMULATIONS_OBLIQUE applies obliquing
		/// (shear) to the glyph outline. This may be used to simulate an oblique/italic style where no designed oblique/italic style is available.
		/// </summary>
		DWRITE_FONT_SIMULATIONS_OBLIQUE = 0x0002
	}

	/// <summary>
	/// Represents the degree to which a font has been stretched compared to a font's normal aspect ratio.The enumerated values
	/// correspond to the usWidthClass definition in the OpenType specification. The usWidthClass represents an integer value between 1
	/// and 9—lower values indicate narrower widths; higher values indicate wider widths.
	/// </summary>
	/// <remarks>
	/// <para>
	/// A font stretch describes the degree to which a font form is stretched from its normal aspect ratio, which is the original width
	/// to height ratio specified for the glyphs in the font. The following illustration shows an example of Normal and Condensed
	/// stretches for the Rockwell Bold typeface.
	/// </para>
	/// <para>
	/// <c>Note</c> Values other than the ones defined in the enumeration are considered to be invalid, and are rejected by font API functions.
	/// </para>
	/// </remarks>

	// https://docs.microsoft.com/en-us/windows/win32/api/dwrite/ne-dwrite-dwrite_font_stretch typedef enum DWRITE_FONT_STRETCH {
	// DWRITE_FONT_STRETCH_UNDEFINED, DWRITE_FONT_STRETCH_ULTRA_CONDENSED, DWRITE_FONT_STRETCH_EXTRA_CONDENSED,
	// DWRITE_FONT_STRETCH_CONDENSED, DWRITE_FONT_STRETCH_SEMI_CONDENSED, DWRITE_FONT_STRETCH_NORMAL, DWRITE_FONT_STRETCH_MEDIUM,
	// DWRITE_FONT_STRETCH_SEMI_EXPANDED, DWRITE_FONT_STRETCH_EXPANDED, DWRITE_FONT_STRETCH_EXTRA_EXPANDED,
	// DWRITE_FONT_STRETCH_ULTRA_EXPANDED } ;
	[PInvokeData("dwrite.h", MSDNShortId = "10b3a703-239b-4fb1-9a20-e466b123b060")]
	// public enum DWRITE_FONT_STRETCH{DWRITE_FONT_STRETCH_UNDEFINED, DWRITE_FONT_STRETCH_ULTRA_CONDENSED,
	// DWRITE_FONT_STRETCH_EXTRA_CONDENSED, DWRITE_FONT_STRETCH_CONDENSED, DWRITE_FONT_STRETCH_SEMI_CONDENSED,
	// DWRITE_FONT_STRETCH_NORMAL, DWRITE_FONT_STRETCH_MEDIUM, DWRITE_FONT_STRETCH_SEMI_EXPANDED, DWRITE_FONT_STRETCH_EXPANDED,
	// DWRITE_FONT_STRETCH_EXTRA_EXPANDED, DWRITE_FONT_STRETCH_ULTRA_EXPANDED, }
	public enum DWRITE_FONT_STRETCH
	{
		/// <summary>Predefined font stretch : Not known (0).</summary>
		DWRITE_FONT_STRETCH_UNDEFINED,

		/// <summary>Predefined font stretch : Ultra-condensed (1).</summary>
		DWRITE_FONT_STRETCH_ULTRA_CONDENSED,

		/// <summary>Predefined font stretch : Extra-condensed (2).</summary>
		DWRITE_FONT_STRETCH_EXTRA_CONDENSED,

		/// <summary>Predefined font stretch : Condensed (3).</summary>
		DWRITE_FONT_STRETCH_CONDENSED,

		/// <summary>Predefined font stretch : Semi-condensed (4).</summary>
		DWRITE_FONT_STRETCH_SEMI_CONDENSED,

		/// <summary>Predefined font stretch : Normal (5).</summary>
		DWRITE_FONT_STRETCH_NORMAL,

		/// <summary>Predefined font stretch : Medium (5).</summary>
		DWRITE_FONT_STRETCH_MEDIUM = DWRITE_FONT_STRETCH_NORMAL,

		/// <summary>Predefined font stretch : Semi-expanded (6).</summary>
		DWRITE_FONT_STRETCH_SEMI_EXPANDED,

		/// <summary>Predefined font stretch : Expanded (7).</summary>
		DWRITE_FONT_STRETCH_EXPANDED,

		/// <summary>Predefined font stretch : Extra-expanded (8).</summary>
		DWRITE_FONT_STRETCH_EXTRA_EXPANDED,

		/// <summary>Predefined font stretch : Ultra-expanded (9).</summary>
		DWRITE_FONT_STRETCH_ULTRA_EXPANDED,
	}

	/// <summary>Represents the style of a font face as normal, italic, or oblique.</summary>
	/// <remarks>
	/// <para>Three terms categorize the slant of a font: normal, italic, and oblique.</para>
	/// <list type="table">
	/// <listheader>
	/// <term>Font style</term>
	/// <term>Description</term>
	/// </listheader>
	/// <item>
	/// <term>Normal</term>
	/// <term>The characters in a normal, or roman, font are upright.</term>
	/// </item>
	/// <item>
	/// <term>Italic</term>
	/// <term>The characters in an italic font are truly slanted and appear as they were designed.</term>
	/// </item>
	/// <item>
	/// <term>Oblique</term>
	/// <term>The characters in an oblique font are artificially slanted.</term>
	/// </item>
	/// </list>
	/// <para>
	/// For Oblique, the slant is achieved by performing a shear transformation on the characters from a normal font. When a true italic
	/// font is not available on a computer or printer, an oblique style can be generated from the normal font and used to simulate an
	/// italic font.
	/// </para>
	/// <para>
	/// The following illustration shows the normal, italic, and oblique font styles for the Palatino Linotype font. Notice how the
	/// italic font style has a more flowing and visually appealing appearance than the oblique font style, which is simply created by
	/// skewing the normal font style version of the text.
	/// </para>
	/// <para>
	/// <c>Note</c> Values other than the ones defined in the enumeration are considered to be invalid, and they are rejected by font
	/// API functions.
	/// </para>
	/// </remarks>
	// https://docs.microsoft.com/en-us/windows/win32/api/dwrite/ne-dwrite-dwrite_font_style typedef enum DWRITE_FONT_STYLE {
	// DWRITE_FONT_STYLE_NORMAL, DWRITE_FONT_STYLE_OBLIQUE, DWRITE_FONT_STYLE_ITALIC } ;
	[PInvokeData("dwrite.h", MSDNShortId = "e48a3b82-4a60-472d-8cb8-a6f63d7eeefc")]
	public enum DWRITE_FONT_STYLE
	{
		/// <summary>Font style : Normal.</summary>
		DWRITE_FONT_STYLE_NORMAL,

		/// <summary>Font style : Oblique.</summary>
		DWRITE_FONT_STYLE_OBLIQUE,

		/// <summary>Font style : Italic.</summary>
		DWRITE_FONT_STYLE_ITALIC,
	}

	/// <summary>
	/// Represents the density of a typeface, in terms of the lightness or heaviness of the strokes. The enumerated values correspond to
	/// the usWeightClass definition in the OpenType specification. The usWeightClass represents an integer value between 1 and 999.
	/// Lower values indicate lighter weights; higher values indicate heavier weights.
	/// </summary>
	/// <remarks>
	/// <para>
	/// Weight differences are generally differentiated by an increased stroke or thickness that is associated with a given character in
	/// a typeface, as compared to a "normal" character from that same typeface. The following illustration shows an example of Normal
	/// and UltraBold weights for the Palatino Linotype typeface.
	/// </para>
	/// <para>
	/// <c>Note</c> Not all weights are available for all typefaces. When a weight is not available for a typeface, the closest matching
	/// weight is returned.
	/// </para>
	/// <para>Font weight values less than 1 or greater than 999 are considered invalid, and they are rejected by font API functions.</para>
	/// </remarks>
	// https://docs.microsoft.com/en-us/windows/win32/api/dwrite/ne-dwrite-dwrite_font_weight typedef enum DWRITE_FONT_WEIGHT {
	// DWRITE_FONT_WEIGHT_THIN, DWRITE_FONT_WEIGHT_EXTRA_LIGHT, DWRITE_FONT_WEIGHT_ULTRA_LIGHT, DWRITE_FONT_WEIGHT_LIGHT,
	// DWRITE_FONT_WEIGHT_SEMI_LIGHT, DWRITE_FONT_WEIGHT_NORMAL, DWRITE_FONT_WEIGHT_REGULAR, DWRITE_FONT_WEIGHT_MEDIUM,
	// DWRITE_FONT_WEIGHT_DEMI_BOLD, DWRITE_FONT_WEIGHT_SEMI_BOLD, DWRITE_FONT_WEIGHT_BOLD, DWRITE_FONT_WEIGHT_EXTRA_BOLD,
	// DWRITE_FONT_WEIGHT_ULTRA_BOLD, DWRITE_FONT_WEIGHT_BLACK, DWRITE_FONT_WEIGHT_HEAVY, DWRITE_FONT_WEIGHT_EXTRA_BLACK,
	// DWRITE_FONT_WEIGHT_ULTRA_BLACK } ;
	[PInvokeData("dwrite.h", MSDNShortId = "82396f80-eb62-4865-ba07-9653220c84f2")]
	public enum DWRITE_FONT_WEIGHT
	{
		/// <summary>Predefined font weight : Thin (100).</summary>
		DWRITE_FONT_WEIGHT_THIN = 100,

		/// <summary>Predefined font weight : Extra-light (200).</summary>
		DWRITE_FONT_WEIGHT_EXTRA_LIGHT = 200,

		/// <summary>Predefined font weight : Ultra-light (200).</summary>
		DWRITE_FONT_WEIGHT_ULTRA_LIGHT = 200,

		/// <summary>Predefined font weight : Light (300).</summary>
		DWRITE_FONT_WEIGHT_LIGHT = 300,

		/// <summary>Predefined font weight : Semi-light (350).</summary>
		DWRITE_FONT_WEIGHT_SEMI_LIGHT = 350,

		/// <summary>Predefined font weight : Normal (400).</summary>
		DWRITE_FONT_WEIGHT_NORMAL = 400,

		/// <summary>Predefined font weight : Regular (400).</summary>
		DWRITE_FONT_WEIGHT_REGULAR = 400,

		/// <summary>Predefined font weight : Medium (500).</summary>
		DWRITE_FONT_WEIGHT_MEDIUM = 500,

		/// <summary>Predefined font weight : Demi-bold (600).</summary>
		DWRITE_FONT_WEIGHT_DEMI_BOLD = 600,

		/// <summary>Predefined font weight : Semi-bold (600).</summary>
		DWRITE_FONT_WEIGHT_SEMI_BOLD = 600,

		/// <summary>Predefined font weight : Bold (700).</summary>
		DWRITE_FONT_WEIGHT_BOLD = 700,

		/// <summary>Predefined font weight : Extra-bold (800).</summary>
		DWRITE_FONT_WEIGHT_EXTRA_BOLD = 800,

		/// <summary>Predefined font weight : Ultra-bold (800).</summary>
		DWRITE_FONT_WEIGHT_ULTRA_BOLD = 800,

		/// <summary>Predefined font weight : Black (900).</summary>
		DWRITE_FONT_WEIGHT_BLACK = 900,

		/// <summary>Predefined font weight : Heavy (900).</summary>
		DWRITE_FONT_WEIGHT_HEAVY = 900,

		/// <summary>Predefined font weight : Extra-black (950).</summary>
		DWRITE_FONT_WEIGHT_EXTRA_BLACK = 950,

		/// <summary>Predefined font weight : Ultra-black (950).</summary>
		DWRITE_FONT_WEIGHT_ULTRA_BLACK = 950
	}

	/// <summary>The informational string enumeration which identifies a string embedded in a font file.</summary>
	// https://docs.microsoft.com/en-us/windows/win32/api/dwrite/ne-dwrite-dwrite_informational_string_id typedef enum
	// DWRITE_INFORMATIONAL_STRING_ID { DWRITE_INFORMATIONAL_STRING_NONE, DWRITE_INFORMATIONAL_STRING_COPYRIGHT_NOTICE,
	// DWRITE_INFORMATIONAL_STRING_VERSION_STRINGS, DWRITE_INFORMATIONAL_STRING_TRADEMARK, DWRITE_INFORMATIONAL_STRING_MANUFACTURER,
	// DWRITE_INFORMATIONAL_STRING_DESIGNER, DWRITE_INFORMATIONAL_STRING_DESIGNER_URL, DWRITE_INFORMATIONAL_STRING_DESCRIPTION,
	// DWRITE_INFORMATIONAL_STRING_FONT_VENDOR_URL, DWRITE_INFORMATIONAL_STRING_LICENSE_DESCRIPTION,
	// DWRITE_INFORMATIONAL_STRING_LICENSE_INFO_URL, DWRITE_INFORMATIONAL_STRING_WIN32_FAMILY_NAMES,
	// DWRITE_INFORMATIONAL_STRING_WIN32_SUBFAMILY_NAMES, DWRITE_INFORMATIONAL_STRING_TYPOGRAPHIC_FAMILY_NAMES,
	// DWRITE_INFORMATIONAL_STRING_TYPOGRAPHIC_SUBFAMILY_NAMES, DWRITE_INFORMATIONAL_STRING_SAMPLE_TEXT,
	// DWRITE_INFORMATIONAL_STRING_FULL_NAME, DWRITE_INFORMATIONAL_STRING_POSTSCRIPT_NAME,
	// DWRITE_INFORMATIONAL_STRING_POSTSCRIPT_CID_NAME, DWRITE_INFORMATIONAL_STRING_WEIGHT_STRETCH_STYLE_FAMILY_NAME,
	// DWRITE_INFORMATIONAL_STRING_DESIGN_SCRIPT_LANGUAGE_TAG, DWRITE_INFORMATIONAL_STRING_SUPPORTED_SCRIPT_LANGUAGE_TAG,
	// DWRITE_INFORMATIONAL_STRING_PREFERRED_FAMILY_NAMES, DWRITE_INFORMATIONAL_STRING_PREFERRED_SUBFAMILY_NAMES,
	// DWRITE_INFORMATIONAL_STRING_WWS_FAMILY_NAME } ;
	[PInvokeData("dwrite.h", MSDNShortId = "bbd5ea62-0837-49e4-a1e8-1d55d5d39ee3")]
	// public enum DWRITE_INFORMATIONAL_STRING_ID{DWRITE_INFORMATIONAL_STRING_NONE, DWRITE_INFORMATIONAL_STRING_COPYRIGHT_NOTICE,
	// DWRITE_INFORMATIONAL_STRING_VERSION_STRINGS, DWRITE_INFORMATIONAL_STRING_TRADEMARK, DWRITE_INFORMATIONAL_STRING_MANUFACTURER,
	// DWRITE_INFORMATIONAL_STRING_DESIGNER, DWRITE_INFORMATIONAL_STRING_DESIGNER_URL, DWRITE_INFORMATIONAL_STRING_DESCRIPTION,
	// DWRITE_INFORMATIONAL_STRING_FONT_VENDOR_URL, DWRITE_INFORMATIONAL_STRING_LICENSE_DESCRIPTION,
	// DWRITE_INFORMATIONAL_STRING_LICENSE_INFO_URL, DWRITE_INFORMATIONAL_STRING_WIN32_FAMILY_NAMES,
	// DWRITE_INFORMATIONAL_STRING_WIN32_SUBFAMILY_NAMES, DWRITE_INFORMATIONAL_STRING_TYPOGRAPHIC_FAMILY_NAMES,
	// DWRITE_INFORMATIONAL_STRING_TYPOGRAPHIC_SUBFAMILY_NAMES, DWRITE_INFORMATIONAL_STRING_SAMPLE_TEXT,
	// DWRITE_INFORMATIONAL_STRING_FULL_NAME, DWRITE_INFORMATIONAL_STRING_POSTSCRIPT_NAME,
	// DWRITE_INFORMATIONAL_STRING_POSTSCRIPT_CID_NAME, DWRITE_INFORMATIONAL_STRING_WEIGHT_STRETCH_STYLE_FAMILY_NAME,
	// DWRITE_INFORMATIONAL_STRING_DESIGN_SCRIPT_LANGUAGE_TAG, DWRITE_INFORMATIONAL_STRING_SUPPORTED_SCRIPT_LANGUAGE_TAG,
	// DWRITE_INFORMATIONAL_STRING_PREFERRED_FAMILY_NAMES, DWRITE_INFORMATIONAL_STRING_PREFERRED_SUBFAMILY_NAMES,
	// DWRITE_INFORMATIONAL_STRING_WWS_FAMILY_NAME, }
	public enum DWRITE_INFORMATIONAL_STRING_ID
	{
		/// <summary>Indicates the string containing the unspecified name ID.</summary>
		DWRITE_INFORMATIONAL_STRING_NONE,

		/// <summary>Indicates the string containing the copyright notice provided by the font.</summary>
		DWRITE_INFORMATIONAL_STRING_COPYRIGHT_NOTICE,

		/// <summary>Indicates the string containing a version number.</summary>
		DWRITE_INFORMATIONAL_STRING_VERSION_STRINGS,

		/// <summary>Indicates the string containing the trademark information provided by the font.</summary>
		DWRITE_INFORMATIONAL_STRING_TRADEMARK,

		/// <summary>Indicates the string containing the name of the font manufacturer.</summary>
		DWRITE_INFORMATIONAL_STRING_MANUFACTURER,

		/// <summary>Indicates the string containing the name of the font designer.</summary>
		DWRITE_INFORMATIONAL_STRING_DESIGNER,

		/// <summary>Indicates the string containing the URL of the font designer (with protocol, e.g., http://, ftp://).</summary>
		DWRITE_INFORMATIONAL_STRING_DESIGNER_URL,

		/// <summary>
		/// Indicates the string containing the description of the font. This may also contain revision information, usage
		/// recommendations, history, features, and so on.
		/// </summary>
		DWRITE_INFORMATIONAL_STRING_DESCRIPTION,

		/// <summary>
		/// Indicates the string containing the URL of the font vendor (with protocol, e.g., http://, ftp://). If a unique serial number
		/// is embedded in the URL, it can be used to register the font.
		/// </summary>
		DWRITE_INFORMATIONAL_STRING_FONT_VENDOR_URL,

		/// <summary>
		/// Indicates the string containing the description of how the font may be legally used, or different example scenarios for
		/// licensed use.
		/// </summary>
		DWRITE_INFORMATIONAL_STRING_LICENSE_DESCRIPTION,

		/// <summary>Indicates the string containing the URL where additional licensing information can be found.</summary>
		DWRITE_INFORMATIONAL_STRING_LICENSE_INFO_URL,

		/// <summary>
		/// Indicates the string containing the GDI-compatible family name. Since GDI allows a maximum of four fonts per family, fonts
		/// in the same family may have different GDI-compatible family names (e.g., "Arial", "Arial Narrow", "Arial Black").
		/// </summary>
		DWRITE_INFORMATIONAL_STRING_WIN32_FAMILY_NAMES,

		/// <summary>Indicates the string containing a GDI-compatible subfamily name.</summary>
		DWRITE_INFORMATIONAL_STRING_WIN32_SUBFAMILY_NAMES,

		/// <summary/>
		DWRITE_INFORMATIONAL_STRING_TYPOGRAPHIC_FAMILY_NAMES,

		/// <summary/>
		DWRITE_INFORMATIONAL_STRING_TYPOGRAPHIC_SUBFAMILY_NAMES,

		/// <summary>
		/// Contains sample text for display in font lists. This can be the font name or any other text that the designer thinks is the
		/// best example to display the font in.
		/// </summary>
		DWRITE_INFORMATIONAL_STRING_SAMPLE_TEXT,

		/// <summary>The full name of the font, like Arial Bold, from name id 4 in the name table</summary>
		DWRITE_INFORMATIONAL_STRING_FULL_NAME,

		/// <summary>The postscript name of the font, like GillSans-Bold, from name id 6 in the name table.</summary>
		DWRITE_INFORMATIONAL_STRING_POSTSCRIPT_NAME,

		/// <summary>The postscript CID findfont name, from name id 20 in the name table</summary>
		DWRITE_INFORMATIONAL_STRING_POSTSCRIPT_CID_NAME,

		/// <summary/>
		DWRITE_INFORMATIONAL_STRING_WEIGHT_STRETCH_STYLE_FAMILY_NAME,

		/// <summary/>
		DWRITE_INFORMATIONAL_STRING_DESIGN_SCRIPT_LANGUAGE_TAG,

		/// <summary/>
		DWRITE_INFORMATIONAL_STRING_SUPPORTED_SCRIPT_LANGUAGE_TAG,

		/// <summary>
		/// Indicates the string containing the family name preferred by the designer. This enables font designers to group more than
		/// four fonts in a single family without losing compatibility with GDI. This name is typically only present if it differs from
		/// the GDI-compatible family name.
		/// </summary>
		DWRITE_INFORMATIONAL_STRING_PREFERRED_FAMILY_NAMES = DWRITE_INFORMATIONAL_STRING_TYPOGRAPHIC_FAMILY_NAMES,

		/// <summary>
		/// Indicates the string containing the subfamily name preferred by the designer. This name is typically only present if it
		/// differs from the GDI-compatible subfamily name.
		/// </summary>
		DWRITE_INFORMATIONAL_STRING_PREFERRED_SUBFAMILY_NAMES = DWRITE_INFORMATIONAL_STRING_TYPOGRAPHIC_SUBFAMILY_NAMES,

		/// <summary/>
		DWRITE_INFORMATIONAL_STRING_WWS_FAMILY_NAME = DWRITE_INFORMATIONAL_STRING_WEIGHT_STRETCH_STYLE_FAMILY_NAME,
	}

	/// <summary>The method used for line spacing in a text layout.</summary>
	/// <remarks>
	/// The line spacing method is set by using the SetLineSpacing method of the IDWriteTextFormat or IDWriteTextLayout interfaces. To
	/// get the current line spacing method of a text format or text layou use the GetLineSpacing.
	/// </remarks>
	// https://docs.microsoft.com/en-us/windows/win32/api/dwrite/ne-dwrite-dwrite_line_spacing_method typedef enum
	// DWRITE_LINE_SPACING_METHOD { DWRITE_LINE_SPACING_METHOD_DEFAULT, DWRITE_LINE_SPACING_METHOD_UNIFORM,
	// DWRITE_LINE_SPACING_METHOD_PROPORTIONAL } ;
	[PInvokeData("dwrite.h", MSDNShortId = "b75e8fee-ed6c-455d-8733-e6972792572c")]
	public enum DWRITE_LINE_SPACING_METHOD
	{
		/// <summary>Line spacing depends solely on the content, adjusting to accommodate the size of fonts and inline objects.</summary>
		DWRITE_LINE_SPACING_METHOD_DEFAULT,

		/// <summary>
		/// Lines are explicitly set to uniform spacing, regardless of the size of fonts and inline objects. This can be useful to avoid
		/// the uneven appearance that can occur from font fallback.
		/// </summary>
		DWRITE_LINE_SPACING_METHOD_UNIFORM,

		/// <summary>
		/// Line spacing and baseline distances are proportional to the computed values based on the content, the size of the fonts and
		/// inline objects.
		/// </summary>
		DWRITE_LINE_SPACING_METHOD_PROPORTIONAL,
	}

	/// <summary>Indicates the measuring method used for text layout.</summary>
	// https://docs.microsoft.com/en-us/windows/win32/api/dcommon/ne-dcommon-dwrite_measuring_mode typedef enum DWRITE_MEASURING_MODE {
	// DWRITE_MEASURING_MODE_NATURAL, DWRITE_MEASURING_MODE_GDI_CLASSIC, DWRITE_MEASURING_MODE_GDI_NATURAL } ;
	[PInvokeData("dcommon.h", MSDNShortId = "99e89754-8bc2-457d-bfdb-a3c9ccfe00c1")]
	public enum DWRITE_MEASURING_MODE
	{
		/// <summary>
		/// Specifies that text is measured using glyph ideal metrics whose values are independent to the current display resolution.
		/// </summary>
		DWRITE_MEASURING_MODE_NATURAL,

		/// <summary>
		/// Specifies that text is measured using glyph display-compatible metrics whose values tuned for the current display resolution.
		/// </summary>
		DWRITE_MEASURING_MODE_GDI_CLASSIC,

		/// <summary>
		/// Specifies that text is measured using the same glyph display metrics as text measured by GDI using a font created with CLEARTYPE_NATURAL_QUALITY.
		/// </summary>
		DWRITE_MEASURING_MODE_GDI_NATURAL,
	}

	/// <summary>Specifies how to apply number substitution on digits and related punctuation.</summary>
	// https://docs.microsoft.com/en-us/windows/win32/api/dwrite/ne-dwrite-dwrite_number_substitution_method typedef enum
	// DWRITE_NUMBER_SUBSTITUTION_METHOD { DWRITE_NUMBER_SUBSTITUTION_METHOD_FROM_CULTURE, DWRITE_NUMBER_SUBSTITUTION_METHOD_CONTEXTUAL,
	// DWRITE_NUMBER_SUBSTITUTION_METHOD_NONE, DWRITE_NUMBER_SUBSTITUTION_METHOD_NATIONAL, DWRITE_NUMBER_SUBSTITUTION_METHOD_TRADITIONAL
	// } ;
	[PInvokeData("dwrite.h", MSDNShortId = "9702007f-ab08-4ad2-9fac-6482e17161ca")]
	public enum DWRITE_NUMBER_SUBSTITUTION_METHOD
	{
		/// <summary>
		/// Specifies that the substitution method should be determined based on the LOCALE_IDIGITSUBSTITUTION value of the specified
		/// text culture.
		/// </summary>
		DWRITE_NUMBER_SUBSTITUTION_METHOD_FROM_CULTURE,

		/// <summary>
		/// If the culture is Arabic or Persian, specifies that the number shapes depend on the context. Either traditional or nominal
		/// number shapes are used, depending on the nearest preceding strong character or (if there is none) the reading direction of
		/// the paragraph.
		/// </summary>
		DWRITE_NUMBER_SUBSTITUTION_METHOD_CONTEXTUAL,

		/// <summary>
		/// Specifies that code points 0x30-0x39 are always rendered as nominal numeral shapes (ones of the European number), that is,
		/// no substitution is performed.
		/// </summary>
		DWRITE_NUMBER_SUBSTITUTION_METHOD_NONE,

		/// <summary>
		/// Specifies that numbers are rendered using the national number shapes as specified by the LOCALE_SNATIVEDIGITS value of the
		/// specified text culture.
		/// </summary>
		DWRITE_NUMBER_SUBSTITUTION_METHOD_NATIONAL,

		/// <summary>
		/// Specifies that numbers are rendered using the traditional shapes for the specified culture. For most cultures, this is the
		/// same as NativeNational. However, NativeNational results in Latin numbers for some Arabic cultures,
		/// whereasDWRITE_NUMBER_SUBSTITUTION_METHOD_TRADITIONAL results in arabic numbers for all Arabic cultures.
		/// </summary>
		DWRITE_NUMBER_SUBSTITUTION_METHOD_TRADITIONAL,
	}

	/// <summary>
	/// Specifies the alignment of paragraph text along the flow direction axis, relative to the top and bottom of the flow's layout box.
	/// </summary>
	// https://docs.microsoft.com/en-us/windows/win32/api/dwrite/ne-dwrite-dwrite_paragraph_alignment typedef enum
	// DWRITE_PARAGRAPH_ALIGNMENT { DWRITE_PARAGRAPH_ALIGNMENT_NEAR, DWRITE_PARAGRAPH_ALIGNMENT_FAR, DWRITE_PARAGRAPH_ALIGNMENT_CENTER } ;
	[PInvokeData("dwrite.h", MSDNShortId = "fcd11308-741a-47cb-aa7a-0ae2c7a9e769")]
	public enum DWRITE_PARAGRAPH_ALIGNMENT
	{
		/// <summary>The top of the text flow is aligned to the top edge of the layout box.</summary>
		DWRITE_PARAGRAPH_ALIGNMENT_NEAR,

		/// <summary>The bottom of the text flow is aligned to the bottom edge of the layout box.</summary>
		DWRITE_PARAGRAPH_ALIGNMENT_FAR,

		/// <summary>The center of the flow is aligned to the center of the layout box.</summary>
		DWRITE_PARAGRAPH_ALIGNMENT_CENTER,
	}

	/// <summary>
	/// Represents the internal structure of a device pixel (that is, the physical arrangement of red, green, and blue color components)
	/// that is assumed for purposes of rendering text.
	/// </summary>
	// https://docs.microsoft.com/en-us/windows/win32/api/dwrite/ne-dwrite-dwrite_pixel_geometry typedef enum DWRITE_PIXEL_GEOMETRY {
	// DWRITE_PIXEL_GEOMETRY_FLAT, DWRITE_PIXEL_GEOMETRY_RGB, DWRITE_PIXEL_GEOMETRY_BGR } ;
	[PInvokeData("dwrite.h", MSDNShortId = "de84b37b-bcb1-432c-8876-d84eaa0e30e0")]
	public enum DWRITE_PIXEL_GEOMETRY
	{
		/// <summary>The red, green, and blue color components of each pixel are assumed to occupy the same point.</summary>
		DWRITE_PIXEL_GEOMETRY_FLAT,

		/// <summary>
		/// Each pixel is composed of three vertical stripes, with red on the left, green in the center, and blue on the right. This is
		/// the most common pixel geometry for LCD monitors.
		/// </summary>
		DWRITE_PIXEL_GEOMETRY_RGB,

		/// <summary>
		/// Each pixel is composed of three vertical stripes, with blue on the left, green in the center, and red on the right.
		/// </summary>
		DWRITE_PIXEL_GEOMETRY_BGR,
	}

	/// <summary>
	/// <para>Specifies the direction in which reading progresses.</para>
	/// <para>
	/// <c>Note</c><c>DWRITE_READING_DIRECTION_TOP_TO_BOTTOM</c> and <c>DWRITE_READING_DIRECTION_BOTTOM_TO_TOP</c> are available in
	/// Windows 8.1 and later, only.
	/// </para>
	/// </summary>
	// https://docs.microsoft.com/en-us/windows/win32/api/dwrite/ne-dwrite-dwrite_reading_direction typedef enum
	// DWRITE_READING_DIRECTION { DWRITE_READING_DIRECTION_LEFT_TO_RIGHT, DWRITE_READING_DIRECTION_RIGHT_TO_LEFT,
	// DWRITE_READING_DIRECTION_TOP_TO_BOTTOM, DWRITE_READING_DIRECTION_BOTTOM_TO_TOP } ;
	[PInvokeData("dwrite.h", MSDNShortId = "37288d34-d533-474c-b3c0-8c6361074a9b")]
	public enum DWRITE_READING_DIRECTION
	{
		/// <summary>Indicates that reading progresses from left to right.</summary>
		DWRITE_READING_DIRECTION_LEFT_TO_RIGHT,

		/// <summary>Indicates that reading progresses from right to left.</summary>
		DWRITE_READING_DIRECTION_RIGHT_TO_LEFT,

		/// <summary>Indicates that reading progresses from top to bottom.</summary>
		DWRITE_READING_DIRECTION_TOP_TO_BOTTOM,

		/// <summary>Indicates that reading progresses from bottom to top.</summary>
		DWRITE_READING_DIRECTION_BOTTOM_TO_TOP,
	}

	/// <summary>
	/// <para>Represents a method of rendering glyphs.</para>
	/// <para>
	/// <c>Note</c> This topic is about <c>DWRITE_RENDERING_MODE</c> in Windows 8 and later. For info on the previous version see the
	/// Remarks section.
	/// </para>
	/// </summary>
	/// <remarks>
	/// <para>DWRITE_RENDERING_MODE previous to Windows 8</para>
	/// <para>
	/// enum DWRITE_RENDERING_MODE { DWRITE_RENDERING_MODE_DEFAULT, DWRITE_RENDERING_MODE_ALIASED,
	/// DWRITE_RENDERING_MODE_CLEARTYPE_GDI_CLASSIC, DWRITE_RENDERING_MODE_CLEARTYPE_GDI_NATURAL,
	/// DWRITE_RENDERING_MODE_CLEARTYPE_NATURAL, DWRITE_RENDERING_MODE_CLEARTYPE_NATURAL_SYMMETRIC, DWRITE_RENDERING_MODE_OUTLINE };
	/// </para>
	/// </remarks>
	// https://docs.microsoft.com/en-us/windows/win32/api/dwrite/ne-dwrite-dwrite_rendering_mode typedef enum DWRITE_RENDERING_MODE {
	// DWRITE_RENDERING_MODE_DEFAULT, DWRITE_RENDERING_MODE_ALIASED, DWRITE_RENDERING_MODE_GDI_CLASSIC,
	// DWRITE_RENDERING_MODE_GDI_NATURAL, DWRITE_RENDERING_MODE_NATURAL, DWRITE_RENDERING_MODE_NATURAL_SYMMETRIC,
	// DWRITE_RENDERING_MODE_OUTLINE, DWRITE_RENDERING_MODE_CLEARTYPE_GDI_CLASSIC, DWRITE_RENDERING_MODE_CLEARTYPE_GDI_NATURAL,
	// DWRITE_RENDERING_MODE_CLEARTYPE_NATURAL, DWRITE_RENDERING_MODE_CLEARTYPE_NATURAL_SYMMETRIC } ;
	[PInvokeData("dwrite.h", MSDNShortId = "c6b2c15a-be22-49ce-affd-1369e23f4d6b")]
	public enum DWRITE_RENDERING_MODE
	{
		/// <summary>Specifies that the rendering mode is determined automatically, based on the font and size.</summary>
		DWRITE_RENDERING_MODE_DEFAULT,

		/// <summary>
		/// Specifies that no anti-aliasing is performed. Each pixel is either set to the foreground color of the text or retains the
		/// color of the background.
		/// </summary>
		DWRITE_RENDERING_MODE_ALIASED,

		/// <summary>
		/// Specifies that antialiasing is performed in the horizontal direction and the appearance of glyphs is layout-compatible with
		/// GDI using CLEARTYPE_QUALITY. Use DWRITE_MEASURING_MODE_GDI_CLASSIC to get glyph advances. The antialiasing may be either
		/// ClearType or grayscale depending on the text antialiasing mode.
		/// </summary>
		DWRITE_RENDERING_MODE_GDI_CLASSIC,

		/// <summary>
		/// Specifies that antialiasing is performed in the horizontal direction and the appearance of glyphs is layout-compatible with
		/// GDI using CLEARTYPE_NATURAL_QUALITY. Glyph advances are close to the font design advances, but are still rounded to whole
		/// pixels. Use DWRITE_MEASURING_MODE_GDI_NATURAL to get glyph advances. The antialiasing may be either ClearType or grayscale
		/// depending on the text antialiasing mode.
		/// </summary>
		DWRITE_RENDERING_MODE_GDI_NATURAL,

		/// <summary>
		/// Specifies that antialiasing is performed in the horizontal direction. This rendering mode allows glyphs to be positioned
		/// with subpixel precision and is therefore suitable for natural (i.e., resolution-independent) layout. The antialiasing may be
		/// either ClearType or grayscale depending on the text antialiasing mode.
		/// </summary>
		DWRITE_RENDERING_MODE_NATURAL,

		/// <summary>
		/// Similar to natural mode except that antialiasing is performed in both the horizontal and vertical directions. This is
		/// typically used at larger sizes to make curves and diagonal lines look smoother. The antialiasing may be either ClearType or
		/// grayscale depending on the text antialiasing mode.
		/// </summary>
		DWRITE_RENDERING_MODE_NATURAL_SYMMETRIC,

		/// <summary>
		/// Specifies that rendering should bypass the rasterizer and use the outlines directly. This is typically used at very large sizes.
		/// </summary>
		DWRITE_RENDERING_MODE_OUTLINE,

		/// <summary/>
		DWRITE_RENDERING_MODE_CLEARTYPE_GDI_CLASSIC = DWRITE_RENDERING_MODE_GDI_CLASSIC,

		/// <summary/>
		DWRITE_RENDERING_MODE_CLEARTYPE_GDI_NATURAL = DWRITE_RENDERING_MODE_GDI_NATURAL,

		/// <summary/>
		DWRITE_RENDERING_MODE_CLEARTYPE_NATURAL = DWRITE_RENDERING_MODE_NATURAL,

		/// <summary/>
		DWRITE_RENDERING_MODE_CLEARTYPE_NATURAL_SYMMETRIC = DWRITE_RENDERING_MODE_NATURAL_SYMMETRIC
	}

	/// <summary>Indicates additional shaping requirements for text.</summary>
	// https://docs.microsoft.com/en-us/windows/win32/api/dwrite/ne-dwrite-dwrite_script_shapes typedef enum DWRITE_SCRIPT_SHAPES {
	// DWRITE_SCRIPT_SHAPES_DEFAULT, DWRITE_SCRIPT_SHAPES_NO_VISUAL } ;
	[PInvokeData("dwrite.h", MSDNShortId = "81ec0f3a-4dab-4497-893f-d791d9d9be6a")]
	[Flags]
	public enum DWRITE_SCRIPT_SHAPES
	{
		/// <summary>
		/// Indicates that there is no additional shaping requirements for text. Text is shaped with the writing system default behavior.
		/// </summary>
		DWRITE_SCRIPT_SHAPES_DEFAULT,

		/// <summary>Indicates that text should leave no visible control or format control characters.</summary>
		DWRITE_SCRIPT_SHAPES_NO_VISUAL,
	}

	/// <summary>
	/// Specifies the alignment of paragraph text along the reading direction axis, relative to the leading and trailing edge of the
	/// layout box.
	/// </summary>
	// https://docs.microsoft.com/en-us/windows/win32/api/dwrite/ne-dwrite-dwrite_text_alignment typedef enum DWRITE_TEXT_ALIGNMENT {
	// DWRITE_TEXT_ALIGNMENT_LEADING, DWRITE_TEXT_ALIGNMENT_TRAILING, DWRITE_TEXT_ALIGNMENT_CENTER, DWRITE_TEXT_ALIGNMENT_JUSTIFIED } ;
	[PInvokeData("dwrite.h", MSDNShortId = "76b347f8-185b-4da6-9647-4d066334ac12")]
	public enum DWRITE_TEXT_ALIGNMENT
	{
		/// <summary>The leading edge of the paragraph text is aligned to the leading edge of the layout box.</summary>
		DWRITE_TEXT_ALIGNMENT_LEADING,

		/// <summary>The trailing edge of the paragraph text is aligned to the trailing edge of the layout box.</summary>
		DWRITE_TEXT_ALIGNMENT_TRAILING,

		/// <summary>The center of the paragraph text is aligned to the center of the layout box.</summary>
		DWRITE_TEXT_ALIGNMENT_CENTER,

		/// <summary>Align text to the leading side, and also justify text to fill the lines.</summary>
		DWRITE_TEXT_ALIGNMENT_JUSTIFIED,
	}

	/// <summary>Identifies a type of alpha texture.</summary>
	/// <remarks>An alpha texture is a bitmap of alpha values, each representing opacity of a pixel or subpixel.</remarks>
	// https://docs.microsoft.com/en-us/windows/win32/api/dwrite/ne-dwrite-dwrite_texture_type typedef enum DWRITE_TEXTURE_TYPE {
	// DWRITE_TEXTURE_ALIASED_1x1, DWRITE_TEXTURE_CLEARTYPE_3x1 } ;
	[PInvokeData("dwrite.h", MSDNShortId = "c97ee0fd-2743-4f72-aa69-bf5e3780aa33")]
	public enum DWRITE_TEXTURE_TYPE
	{
		/// <summary>
		/// Specifies an alpha texture for aliased text rendering (that is, each pixel is either fully opaque or fully transparent),
		/// with one byte per pixel.
		/// </summary>
		DWRITE_TEXTURE_ALIASED_1x1,

		/// <summary>
		/// Specifies an alpha texture for ClearType text rendering, with three bytes per pixel in the horizontal dimension and one byte
		/// per pixel in the vertical dimension.
		/// </summary>
		DWRITE_TEXTURE_CLEARTYPE_3x1,
	}

	/// <summary>Specifies the text granularity used to trim text overflowing the layout box.</summary>
	// https://docs.microsoft.com/en-us/windows/win32/api/dwrite/ne-dwrite-dwrite_trimming_granularity typedef enum
	// DWRITE_TRIMMING_GRANULARITY { DWRITE_TRIMMING_GRANULARITY_NONE, DWRITE_TRIMMING_GRANULARITY_CHARACTER,
	// DWRITE_TRIMMING_GRANULARITY_WORD } ;
	[PInvokeData("dwrite.h", MSDNShortId = "81ab22cd-7b7f-4db6-9f67-2cafd54f4621")]
	public enum DWRITE_TRIMMING_GRANULARITY
	{
		/// <summary>No trimming occurs. Text flows beyond the layout width.</summary>
		DWRITE_TRIMMING_GRANULARITY_NONE,

		/// <summary>Trimming occurs at a character cluster boundary.</summary>
		DWRITE_TRIMMING_GRANULARITY_CHARACTER,

		/// <summary>Trimming occurs at a word boundary.</summary>
		DWRITE_TRIMMING_GRANULARITY_WORD,
	}

	/// <summary>
	/// <para>Specifies the word wrapping to be used in a particular multiline paragraph.</para>
	/// <para>
	/// <c>Note</c><c>DWRITE_WORD_WRAPPING_EMERGENCY_BREAK</c>, <c>DWRITE_WORD_WRAPPING_WHOLE _WORD</c>, and
	/// <c>DWRITE_WORD_WRAPPING_CHARACTER</c> are available in Windows 8.1 and later, only.
	/// </para>
	/// </summary>
	// https://docs.microsoft.com/en-us/windows/win32/api/dwrite/ne-dwrite-dwrite_word_wrapping typedef enum DWRITE_WORD_WRAPPING {
	// DWRITE_WORD_WRAPPING_WRAP, DWRITE_WORD_WRAPPING_NO_WRAP, DWRITE_WORD_WRAPPING_EMERGENCY_BREAK, DWRITE_WORD_WRAPPING_WHOLE_WORD,
	// DWRITE_WORD_WRAPPING_CHARACTER } ;
	[PInvokeData("dwrite.h", MSDNShortId = "5b0a5e15-1bbf-433e-9c7f-d7b8fa9313c2")]
	public enum DWRITE_WORD_WRAPPING
	{
		/// <summary>Indicates that words are broken across lines to avoid text overflowing the layout box.</summary>
		DWRITE_WORD_WRAPPING_WRAP,

		/// <summary>
		/// Indicates that words are kept within the same line even when it overflows the layout box. This option is often used with
		/// scrolling to reveal overflow text.
		/// </summary>
		DWRITE_WORD_WRAPPING_NO_WRAP,

		/// <summary>
		/// Words are broken across lines to avoid text overflowing the layout box. Emergency wrapping occurs if the word is larger than
		/// the maximum width.
		/// </summary>
		DWRITE_WORD_WRAPPING_EMERGENCY_BREAK,

		/// <summary>
		/// When emergency wrapping, only wrap whole words, never breaking words when the layout width is too small for even a single word.
		/// </summary>
		DWRITE_WORD_WRAPPING_WHOLE_WORD,

		/// <summary>Wrap between any valid character clusters.</summary>
		DWRITE_WORD_WRAPPING_CHARACTER,
	}

	/// <summary>Contains information about a glyph cluster.</summary>
	// https://docs.microsoft.com/en-us/windows/win32/api/dwrite/ns-dwrite-dwrite_cluster_metrics struct DWRITE_CLUSTER_METRICS { FLOAT
	// width; UINT16 length; UINT16 canWrapLineAfter : 1; UINT16 isWhitespace : 1; UINT16 isNewline : 1; UINT16 isSoftHyphen : 1; UINT16
	// isRightToLeft : 1; UINT16 padding : 11; };
	[PInvokeData("dwrite.h", MSDNShortId = "738b7f15-fcc5-4960-ac1f-ca530c448271")]
	[StructLayout(LayoutKind.Sequential)]
	public struct DWRITE_CLUSTER_METRICS
	{
		/// <summary>
		/// <para>Type: <c>FLOAT</c></para>
		/// <para>The total advance width of all glyphs in the cluster.</para>
		/// </summary>
		public float width;

		/// <summary>
		/// <para>Type: <c>UINT16</c></para>
		/// <para>The number of text positions in the cluster.</para>
		/// </summary>
		public ushort length;

		private ushort bits;

		/// <summary>
		/// <para>Type: <c>UINT16</c></para>
		/// <para>Indicates whether a line can be broken right after the cluster.</para>
		/// </summary>
		public bool canWrapLineAfter { get => BitHelper.GetBit(bits, 0); set => BitHelper.SetBit(ref bits, 0, value); }

		/// <summary>
		/// <para>Type: <c>UINT16</c></para>
		/// <para>Indicates whether the cluster corresponds to a whitespace character.</para>
		/// </summary>
		public bool isWhitespace { get => BitHelper.GetBit(bits, 1); set => BitHelper.SetBit(ref bits, 1, value); }

		/// <summary>
		/// <para>Type: <c>UINT16</c></para>
		/// <para>Indicates whether the cluster corresponds to a newline character.</para>
		/// </summary>
		public bool isNewline { get => BitHelper.GetBit(bits, 2); set => BitHelper.SetBit(ref bits, 2, value); }

		/// <summary>
		/// <para>Type: <c>UINT16</c></para>
		/// <para>Indicates whether the cluster corresponds to a soft hyphen character.</para>
		/// </summary>
		public bool isSoftHyphen { get => BitHelper.GetBit(bits, 3); set => BitHelper.SetBit(ref bits, 3, value); }

		/// <summary>
		/// <para>Type: <c>UINT16</c></para>
		/// <para>Indicates whether the cluster is read from right to left.</para>
		/// </summary>
		public bool isRightToLeft { get => BitHelper.GetBit(bits, 4); set => BitHelper.SetBit(ref bits, 4, value); }
	}

	/// <summary>Specifies properties used to identify and execute typographic features in the current font face.</summary>
	/// <remarks>
	/// <para>
	/// A non-zero value generally enables the feature execution, while the zero value disables it. A feature requiring a selector uses
	/// this value to indicate the selector index.
	/// </para>
	/// <para>
	/// The OpenType standard provides access to typographic features available in the font by means of a feature tag with the
	/// associated parameters. The OpenType feature tag is a 4-byte identifier of the registered name of a feature. For example, the
	/// 'kern' feature name tag is used to identify the 'Kerning' feature in OpenType font. Similarly, the OpenType feature tag for
	/// 'Standard Ligatures' and 'Fractions' is 'liga' and 'frac' respectively. Since a single run can be associated with more than one
	/// typographic features, the Text String API accepts typographic settings for a run as a list of features and are executed in the
	/// order they are specified.
	/// </para>
	/// <para>
	/// The value of the tag member represents the OpenType name tag of the feature, while the param value represents additional
	/// parameter for the execution of the feature referred by the tag member. Both <c>nameTag</c> and <c>parameter</c> are stored as
	/// little endian, the same convention followed by GDI. Most features treat the Param value as a binary value that indicates whether
	/// to turn the execution of the feature on or off, with it being off by default in the majority of cases. Some features, however,
	/// treat this value as an integral value representing the integer index to the list of alternate results it may produce during the
	/// execution; for instance, the feature 'Stylistic Alternates' or 'salt' uses the <c>parameter</c> value as an index to the list of
	/// alternate substituting glyphs it could produce for a specified glyph.
	/// </para>
	/// </remarks>
	// https://docs.microsoft.com/en-us/windows/win32/api/dwrite/ns-dwrite-dwrite_font_feature struct DWRITE_FONT_FEATURE {
	// DWRITE_FONT_FEATURE_TAG nameTag; UINT32 parameter; };
	[PInvokeData("dwrite.h", MSDNShortId = "f8c2b1b0-ecab-4556-b3e6-5eda75e206ed")]
	[StructLayout(LayoutKind.Sequential)]
	public struct DWRITE_FONT_FEATURE
	{
		/// <summary>
		/// <para>Type: <c>DWRITE_FONT_FEATURE_TAG</c></para>
		/// <para>The feature OpenType name identifier.</para>
		/// </summary>
		public DWRITE_FONT_FEATURE_TAG nameTag;

		/// <summary>
		/// <para>Type: <c>UINT32</c></para>
		/// <para>The execution parameter of the feature.</para>
		/// </summary>
		public uint parameter;
	}

	/// <summary>
	/// The <c>DWRITE_FONT_METRICS</c> structure specifies the metrics that are applicable to all glyphs within the font face.
	/// </summary>
	// https://docs.microsoft.com/en-us/windows/win32/api/dwrite/ns-dwrite-dwrite_font_metrics struct DWRITE_FONT_METRICS { UINT16
	// designUnitsPerEm; UINT16 ascent; UINT16 descent; INT16 lineGap; UINT16 capHeight; UINT16 xHeight; INT16 underlinePosition; UINT16
	// underlineThickness; INT16 strikethroughPosition; UINT16 strikethroughThickness; };
	[PInvokeData("dwrite.h", MSDNShortId = "ffbf987c-145e-4b93-a48f-8948944c6e33")]
	[StructLayout(LayoutKind.Sequential)]
	public struct DWRITE_FONT_METRICS
	{
		/// <summary>
		/// <para>Type: <c>UINT16</c></para>
		/// <para>
		/// The number of font design units per em unit. Font files use their own coordinate system of font design units. A font design
		/// unit is the smallest measurable unit in the em square, an imaginary square that is used to size and align glyphs. The
		/// concept of em square is used as a reference scale factor when defining font size and device transformation semantics. The
		/// size of one em square is also commonly used to compute the paragraph identation value.
		/// </para>
		/// </summary>
		public ushort designUnitsPerEm;

		/// <summary>
		/// <para>Type: <c>UINT16</c></para>
		/// <para>
		/// The ascent value of the font face in font design units. Ascent is the distance from the top of font character alignment box
		/// to the English baseline.
		/// </para>
		/// </summary>
		public ushort ascent;

		/// <summary>
		/// <para>Type: <c>UINT16</c></para>
		/// <para>
		/// The descent value of the font face in font design units. Descent is the distance from the bottom of font character alignment
		/// box to the English baseline.
		/// </para>
		/// </summary>
		public ushort descent;

		/// <summary>
		/// <para>Type: <c>INT16</c></para>
		/// <para>
		/// The line gap in font design units. Recommended additional white space to add between lines to improve legibility. The
		/// recommended line spacing (baseline-to-baseline distance) is the sum of <c>ascent</c>, <c>descent</c>, and <c>lineGap</c>.
		/// The line gap is usually positive or zero but can be negative, in which case the recommended line spacing is less than the
		/// height of the character alignment box.
		/// </para>
		/// </summary>
		public short lineGap;

		/// <summary>
		/// <para>Type: <c>UINT16</c></para>
		/// <para>
		/// The cap height value of the font face in font design units. Cap height is the distance from the English baseline to the top
		/// of a typical English capital. Capital "H" is often used as a reference character for the purpose of calculating the cap
		/// height value.
		/// </para>
		/// </summary>
		public ushort capHeight;

		/// <summary>
		/// <para>Type: <c>UINT16</c></para>
		/// <para>
		/// The x-height value of the font face in font design units. x-height is the distance from the English baseline to the top of
		/// lowercase letter "x", or a similar lowercase character.
		/// </para>
		/// </summary>
		public ushort xHeight;

		/// <summary>
		/// <para>Type: <c>INT16</c></para>
		/// <para>
		/// The underline position value of the font face in font design units. Underline position is the position of underline relative
		/// to the English baseline. The value is usually made negative in order to place the underline below the baseline.
		/// </para>
		/// </summary>
		public short underlinePosition;

		/// <summary>
		/// <para>Type: <c>UINT16</c></para>
		/// <para>The suggested underline thickness value of the font face in font design units.</para>
		/// </summary>
		public ushort underlineThickness;

		/// <summary>
		/// <para>Type: <c>INT16</c></para>
		/// <para>
		/// The strikethrough position value of the font face in font design units. Strikethrough position is the position of
		/// strikethrough relative to the English baseline. The value is usually made positive in order to place the strikethrough above
		/// the baseline.
		/// </para>
		/// </summary>
		public short strikethroughPosition;

		/// <summary>
		/// <para>Type: <c>UINT16</c></para>
		/// <para>The suggested strikethrough thickness value of the font face in font design units.</para>
		/// </summary>
		public ushort strikethroughThickness;
	}

	/// <summary>Specifies the metrics of an individual glyph.The units depend on how the metrics are obtained.</summary>
	// https://docs.microsoft.com/en-us/windows/win32/api/dwrite/ns-dwrite-dwrite_glyph_metrics struct DWRITE_GLYPH_METRICS { INT32
	// leftSideBearing; UINT32 advanceWidth; INT32 rightSideBearing; INT32 topSideBearing; UINT32 advanceHeight; INT32
	// bottomSideBearing; INT32 verticalOriginY; };
	[PInvokeData("dwrite.h", MSDNShortId = "d2a4ac9f-f510-4235-93bb-e7bdecc65873")]
	[StructLayout(LayoutKind.Sequential)]
	public struct DWRITE_GLYPH_METRICS
	{
		/// <summary>
		/// <para>Type: <c>INT32</c></para>
		/// <para>
		/// Specifies the X offset from the glyph origin to the left edge of the black box. The glyph origin is the current horizontal
		/// writing position. A negative value means the black box extends to the left of the origin (often true for lowercase italic 'f').
		/// </para>
		/// </summary>
		public int leftSideBearing;

		/// <summary>
		/// <para>Type: <c>UINT32</c></para>
		/// <para>Specifies the X offset from the origin of the current glyph to the origin of the next glyph when writing horizontally.</para>
		/// </summary>
		public uint advanceWidth;

		/// <summary>
		/// <para>Type: <c>INT32</c></para>
		/// <para>
		/// Specifies the X offset from the right edge of the black box to the origin of the next glyph when writing horizontally. The
		/// value is negative when the right edge of the black box overhangs the layout box.
		/// </para>
		/// </summary>
		public int rightSideBearing;

		/// <summary>
		/// <para>Type: <c>INT32</c></para>
		/// <para>
		/// Specifies the vertical offset from the vertical origin to the top of the black box. Thus, a positive value adds whitespace
		/// whereas a negative value means the glyph overhangs the top of the layout box.
		/// </para>
		/// </summary>
		public int topSideBearing;

		/// <summary>
		/// <para>Type: <c>UINT32</c></para>
		/// <para>
		/// Specifies the Y offset from the vertical origin of the current glyph to the vertical origin of the next glyph when writing
		/// vertically. Note that the term "origin" by itself denotes the horizontal origin. The vertical origin is different. Its Y
		/// coordinate is specified by <c>verticalOriginY</c> value, and its X coordinate is half the <c>advanceWidth</c> to the right
		/// of the horizontal origin.
		/// </para>
		/// </summary>
		public uint advanceHeight;

		/// <summary>
		/// <para>Type: <c>INT32</c></para>
		/// <para>
		/// Specifies the vertical distance from the bottom edge of the black box to the advance height. This is positive when the
		/// bottom edge of the black box is within the layout box, or negative when the bottom edge of black box overhangs the layout box.
		/// </para>
		/// </summary>
		public int bottomSideBearing;

		/// <summary>
		/// <para>Type: <c>INT32</c></para>
		/// <para>
		/// Specifies the Y coordinate of a glyph's vertical origin, in the font's design coordinate system. The y coordinate of a
		/// glyph's vertical origin is the sum of the glyph's top side bearing and the top (that is, yMax) of the glyph's bounding box.
		/// </para>
		/// </summary>
		public int verticalOriginY;
	}

	/// <summary>The optional adjustment to a glyph's position.</summary>
	/// <remarks>
	/// An glyph offset changes the position of a glyph without affecting the pen position. Offsets are in logical, pre-transform units.
	/// </remarks>
	// https://docs.microsoft.com/en-us/windows/win32/api/dwrite/ns-dwrite-dwrite_glyph_offset struct DWRITE_GLYPH_OFFSET { FLOAT
	// advanceOffset; FLOAT ascenderOffset; };
	[PInvokeData("dwrite.h", MSDNShortId = "f5a231c0-78df-4fe0-99a8-81fcad517cda")]
	[StructLayout(LayoutKind.Sequential)]
	public struct DWRITE_GLYPH_OFFSET
	{
		/// <summary>
		/// <para>Type: <c>FLOAT</c></para>
		/// <para>
		/// The offset in the advance direction of the run. A positive advance offset moves the glyph to the right (in pre-transform
		/// coordinates) if the run is left-to-right or to the left if the run is right-to-left.
		/// </para>
		/// </summary>
		public float advanceOffset;

		/// <summary>
		/// <para>Type: <c>FLOAT</c></para>
		/// <para>
		/// The offset in the ascent direction, that is, the direction ascenders point. A positive ascender offset moves the glyph up
		/// (in pre-transform coordinates). A negative ascender offset moves the glyph down.
		/// </para>
		/// </summary>
		public float ascenderOffset;
	}

	/// <summary>
	/// Contains the information needed by renderers to draw glyph runs. All coordinates are in device independent pixels (DIPs).
	/// </summary>
	// https://docs.microsoft.com/en-us/windows/win32/api/dwrite/ns-dwrite-dwrite_glyph_run struct DWRITE_GLYPH_RUN { IDWriteFontFace
	// *fontFace; FLOAT fontEmSize; UINT32 glyphCount; UINT16 const *glyphIndices; FLOAT const *glyphAdvances; DWRITE_GLYPH_OFFSET const
	// *glyphOffsets; BOOL isSideways; UINT32 bidiLevel; };
	[PInvokeData("dwrite.h", MSDNShortId = "2997d63f-8d33-44c3-9617-cfffe5f61f7d")]
	[StructLayout(LayoutKind.Sequential)]
	public struct DWRITE_GLYPH_RUN
	{
		/// <summary>
		/// <para>Type: <c>IDWriteFontFace*</c></para>
		/// <para>The physical font face object to draw with.</para>
		/// </summary>
		public IntPtr fontFace;

		/// <summary>
		/// <para>Type: <c>FLOAT</c></para>
		/// <para>The logical size of the font in DIPs (equals 1/96 inch), not points.</para>
		/// </summary>
		public float fontEmSize;

		/// <summary>
		/// <para>Type: <c>UINT32</c></para>
		/// <para>The number of glyphs in the glyph run.</para>
		/// </summary>
		public uint glyphCount;

		/// <summary>
		/// <para>Type: <c>const UINT16*</c></para>
		/// <para>A pointer to an array of indices to render for the glyph run.</para>
		/// </summary>
		public IntPtr glyphIndices;

		/// <summary>
		/// <para>Type: <c>const FLOAT*</c></para>
		/// <para>A pointer to an array containing glyph advance widths for the glyph run.</para>
		/// </summary>
		public IntPtr glyphAdvances;

		/// <summary>
		/// <para>Type: <c>const DWRITE_GLYPH_OFFSET*</c></para>
		/// <para>A pointer to an array containing glyph offsets for the glyph run.</para>
		/// </summary>
		public IntPtr glyphOffsets;

		/// <summary>
		/// <para>Type: <c>BOOL</c></para>
		/// <para>
		/// If true, specifies that glyphs are rotated 90 degrees to the left and vertical metrics are used. Vertical writing is
		/// achieved by specifying <c>isSideways</c> = true and rotating the entire run 90 degrees to the right via a rotate transform.
		/// </para>
		/// </summary>
		[MarshalAs(UnmanagedType.Bool)]
		public bool isSideways;

		/// <summary>
		/// <para>Type: <c>UINT32</c></para>
		/// <para>
		/// The implicit resolved bidi level of the run. Odd levels indicate right-to-left languages like Hebrew and Arabic, while even
		/// levels indicate left-to-right languages like English and Japanese (when written horizontally). For right-to-left languages,
		/// the text origin is on the right, and text should be drawn to the left.
		/// </para>
		/// </summary>
		public uint bidiLevel;
	}

	/// <summary>Contains additional properties related to those in DWRITE_GLYPH_RUN.</summary>
	// https://docs.microsoft.com/en-us/windows/win32/api/dwrite/ns-dwrite-dwrite_glyph_run_description struct
	// DWRITE_GLYPH_RUN_DESCRIPTION { WCHAR const *localeName; WCHAR const *string; UINT32 stringLength; UINT16 const *clusterMap;
	// UINT32 textPosition; };
	[PInvokeData("dwrite.h", MSDNShortId = "0fb25253-274a-42b7-8491-525d0550ce39")]
	[StructLayout(LayoutKind.Sequential)]
	public struct DWRITE_GLYPH_RUN_DESCRIPTION
	{
		/// <summary>
		/// <para>Type: <c>const WCHAR*</c></para>
		/// <para>An array of characters containing the locale name associated with this run.</para>
		/// </summary>
		public IntPtr localeName;

		/// <summary>
		/// <para>Type: <c>const WCHAR*</c></para>
		/// <para>An array of characters containing the text associated with the glyphs.</para>
		/// </summary>
		public IntPtr @string;

		/// <summary>
		/// <para>Type: <c>UINT32</c></para>
		/// <para>The number of characters in UTF16 code-units. Note that this may be different than the number of glyphs.</para>
		/// </summary>
		public uint stringLength;

		/// <summary>
		/// <para>Type: <c>const UINT16*</c></para>
		/// <para>An array of indices to the glyph indices array, of the first glyphs of all the glyph clusters of the glyphs to render.</para>
		/// </summary>
		public IntPtr clusterMap;

		/// <summary>
		/// <para>Type: <c>UINT32</c></para>
		/// <para>
		/// Corresponding text position in the string this glyph run came from. This is relative to the beginning of the string
		/// represented by the IDWriteTextLayout object.
		/// </para>
		/// </summary>
		public uint textPosition;
	}

	/// <summary>Describes the region obtained by a hit test.</summary>
	// https://docs.microsoft.com/en-us/windows/win32/api/dwrite/ns-dwrite-dwrite_hit_test_metrics struct DWRITE_HIT_TEST_METRICS {
	// UINT32 textPosition; UINT32 length; FLOAT left; FLOAT top; FLOAT width; FLOAT height; UINT32 bidiLevel; BOOL isText; BOOL
	// isTrimmed; };
	[PInvokeData("dwrite.h", MSDNShortId = "00aaed92-7078-4823-95c5-855c063c744a")]
	[StructLayout(LayoutKind.Sequential)]
	public struct DWRITE_HIT_TEST_METRICS
	{
		/// <summary>
		/// <para>Type: <c>UINT32</c></para>
		/// <para>The first text position within the hit region.</para>
		/// </summary>
		public uint textPosition;

		/// <summary>
		/// <para>Type: <c>UINT32</c></para>
		/// <para>The number of text positions within the hit region.</para>
		/// </summary>
		public uint length;

		/// <summary>
		/// <para>Type: <c>FLOAT</c></para>
		/// <para>The x-coordinate of the upper-left corner of the hit region.</para>
		/// </summary>
		public float left;

		/// <summary>
		/// <para>Type: <c>FLOAT</c></para>
		/// <para>The y-coordinate of the upper-left corner of the hit region.</para>
		/// </summary>
		public float top;

		/// <summary>
		/// <para>Type: <c>FLOAT</c></para>
		/// <para>The width of the hit region.</para>
		/// </summary>
		public float width;

		/// <summary>
		/// <para>Type: <c>FLOAT</c></para>
		/// <para>The height of the hit region.</para>
		/// </summary>
		public float height;

		/// <summary>
		/// <para>Type: <c>UINT32</c></para>
		/// <para>The BIDI level of the text positions within the hit region.</para>
		/// </summary>
		public uint bidiLevel;

		/// <summary>
		/// <para>Type: <c>BOOL</c></para>
		/// <para>true if the hit region contains text; otherwise, false.</para>
		/// </summary>
		[MarshalAs(UnmanagedType.Bool)]
		public bool isText;

		/// <summary>
		/// <para>Type: <c>BOOL</c></para>
		/// <para>true if the text range is trimmed; otherwise, false.</para>
		/// </summary>
		[MarshalAs(UnmanagedType.Bool)]
		public bool isTrimmed;
	}

	/// <summary>Contains properties describing the geometric measurement of an application-defined inline object.</summary>
	// https://docs.microsoft.com/en-us/windows/win32/api/dwrite/ns-dwrite-dwrite_inline_object_metrics struct
	// DWRITE_INLINE_OBJECT_METRICS { FLOAT width; FLOAT height; FLOAT baseline; BOOL supportsSideways; };
	[PInvokeData("dwrite.h", MSDNShortId = "a42d612c-3d16-4c27-a1d8-1cfb9de2f8b1")]
	[StructLayout(LayoutKind.Sequential)]
	public struct DWRITE_INLINE_OBJECT_METRICS
	{
		/// <summary>
		/// <para>Type: <c>FLOAT</c></para>
		/// <para>The width of the inline object.</para>
		/// </summary>
		public float width;

		/// <summary>
		/// <para>Type: <c>FLOAT</c></para>
		/// <para>The height of the inline object.</para>
		/// </summary>
		public float height;

		/// <summary>
		/// <para>Type: <c>FLOAT</c></para>
		/// <para>
		/// The distance from the top of the object to the point where it is lined up with the adjacent text. If the baseline is at the
		/// bottom, then <c>baseline</c> simply equals <c>height</c>.
		/// </para>
		/// </summary>
		public float baseline;

		/// <summary>
		/// <para>Type: <c>BOOL</c></para>
		/// <para>
		/// A Boolean flag that indicates whether the object is to be placed upright or alongside the text baseline for vertical text.
		/// </para>
		/// </summary>
		[MarshalAs(UnmanagedType.Bool)]
		public bool supportsSideways;
	}

	/// <summary>Line breakpoint characteristics of a character.</summary>
	// https://docs.microsoft.com/en-us/windows/win32/api/dwrite/ns-dwrite-dwrite_line_breakpoint struct DWRITE_LINE_BREAKPOINT { UINT8
	// breakConditionBefore : 2; UINT8 breakConditionAfter : 2; UINT8 isWhitespace : 1; UINT8 isSoftHyphen : 1; UINT8 padding : 2; };
	[PInvokeData("dwrite.h", MSDNShortId = "6f2b26e9-95b3-4ac5-ba8e-7055f873d1da")]
	[StructLayout(LayoutKind.Sequential)]
	public struct DWRITE_LINE_BREAKPOINT
	{
		private byte bits;

		/// <summary>
		/// <para>Type: <c>UINT8</c></para>
		/// <para>Indicates a breaking condition before the character.</para>
		/// </summary>
		public byte breakConditionBefore { get => BitHelper.GetBits(bits, 0, 2); set => BitHelper.SetBits(ref bits, 0, 2, value); }

		/// <summary>
		/// <para>Type: <c>UINT8</c></para>
		/// <para>Indicates a breaking condition after the character.</para>
		/// </summary>
		public byte breakConditionAfter { get => BitHelper.GetBits(bits, 2, 4); set => BitHelper.SetBits(ref bits, 2, 4, value); }

		/// <summary>
		/// <para>Type: <c>UINT8</c></para>
		/// <para>Indicates that the character is some form of whitespace, which may be meaningful for justification.</para>
		/// </summary>
		public bool isWhitespace { get => BitHelper.GetBit(bits, 4); set => BitHelper.SetBit(ref bits, 4, value); }

		/// <summary>
		/// <para>Type: <c>UINT8</c></para>
		/// <para>Indicates that the character is a soft hyphen, often used to indicate hyphenation points inside words.</para>
		/// </summary>
		public bool isSoftHyphen { get => BitHelper.GetBit(bits, 5); set => BitHelper.SetBit(ref bits, 5, value); }
	}

	/// <summary>Contains information about a formatted line of text.</summary>
	// https://docs.microsoft.com/en-us/windows/win32/api/dwrite/ns-dwrite-dwrite_line_metrics struct DWRITE_LINE_METRICS { UINT32
	// length; UINT32 trailingWhitespaceLength; UINT32 newlineLength; FLOAT height; FLOAT baseline; BOOL isTrimmed; };
	[PInvokeData("dwrite.h", MSDNShortId = "cb589949-2eba-4ebb-ada4-546802fb3d01")]
	[StructLayout(LayoutKind.Sequential)]
	public struct DWRITE_LINE_METRICS
	{
		/// <summary>
		/// <para>Type: <c>UINT32</c></para>
		/// <para>The number of text positions in the text line. This includes any trailing whitespace and newline characters.</para>
		/// </summary>
		public uint length;

		/// <summary>
		/// <para>Type: <c>UINT32</c></para>
		/// <para>The number of whitespace positions at the end of the text line. Newline sequences are considered whitespace.</para>
		/// </summary>
		public uint trailingWhitespaceLength;

		/// <summary>
		/// <para>Type: <c>UINT32</c></para>
		/// <para>
		/// The number of characters in the newline sequence at the end of the text line. If the count is zero, then the text line was
		/// either wrapped or it is the end of the text.
		/// </para>
		/// </summary>
		public uint newlineLength;

		/// <summary>
		/// <para>Type: <c>FLOAT</c></para>
		/// <para>The height of the text line.</para>
		/// </summary>
		public float height;

		/// <summary>
		/// <para>Type: <c>FLOAT</c></para>
		/// <para>The distance from the top of the text line to its baseline.</para>
		/// </summary>
		public float baseline;

		/// <summary>
		/// <para>Type: <c>BOOL</c></para>
		/// <para>The line is trimmed.</para>
		/// </summary>
		[MarshalAs(UnmanagedType.Bool)]
		public bool isTrimmed;
	}

	/// <summary>The <c>DWRITE_MATRIX</c> structure specifies the graphics transform to be applied to rendered glyphs.</summary>
	// https://docs.microsoft.com/en-us/windows/win32/api/dwrite/ns-dwrite-dwrite_matrix struct DWRITE_MATRIX { FLOAT m11; FLOAT m12;
	// FLOAT m21; FLOAT m22; FLOAT dx; FLOAT dy; };
	[PInvokeData("dwrite.h", MSDNShortId = "fe4bd8ba-fc3b-4a04-8a72-9983d52f4404")]
	[StructLayout(LayoutKind.Sequential)]
	public struct DWRITE_MATRIX
	{
		/// <summary>
		/// <para>Type: <c>FLOAT</c></para>
		/// <para>A value indicating the horizontal scaling / cosine of rotation.</para>
		/// </summary>
		public float m11;

		/// <summary>
		/// <para>Type: <c>FLOAT</c></para>
		/// <para>A value indicating the vertical shear / sine of rotation.</para>
		/// </summary>
		public float m12;

		/// <summary>
		/// <para>Type: <c>FLOAT</c></para>
		/// <para>A value indicating the horizontal shear / negative sine of rotation.</para>
		/// </summary>
		public float m21;

		/// <summary>
		/// <para>Type: <c>FLOAT</c></para>
		/// <para>A value indicating the vertical scaling / cosine of rotation.</para>
		/// </summary>
		public float m22;

		/// <summary>
		/// <para>Type: <c>FLOAT</c></para>
		/// <para>A value indicating the horizontal shift (always orthogonal regardless of rotation).</para>
		/// </summary>
		public float dx;

		/// <summary>
		/// <para>Type: <c>FLOAT</c></para>
		/// <para>A value indicating the vertical shift (always orthogonal regardless of rotation.)</para>
		/// </summary>
		public float dy;
	}

	/// <summary>
	/// <para>Indicates how much any visible DIPs (device independent pixels) overshoot each side of the layout or inline objects.</para>
	/// <para>
	/// Positive overhangs indicate that the visible area extends outside the layout box or inline object, while negative values mean
	/// there is whitespace inside. The returned values are unaffected by rendering transforms or pixel snapping. Additionally, they may
	/// not exactly match the final target's pixel bounds after applying grid fitting and hinting.
	/// </para>
	/// </summary>
	// https://docs.microsoft.com/en-us/windows/win32/api/dwrite/ns-dwrite-dwrite_overhang_metrics struct DWRITE_OVERHANG_METRICS {
	// FLOAT left; FLOAT top; FLOAT right; FLOAT bottom; };
	[PInvokeData("dwrite.h", MSDNShortId = "a285f06b-a4d0-4ebe-80f5-157e59bfba31")]
	[StructLayout(LayoutKind.Sequential)]
	public struct DWRITE_OVERHANG_METRICS
	{
		/// <summary>
		/// <para>Type: <c>FLOAT</c></para>
		/// <para>The distance from the left-most visible DIP to its left-alignment edge.</para>
		/// </summary>
		public float left;

		/// <summary>
		/// <para>Type: <c>FLOAT</c></para>
		/// <para>The distance from the top-most visible DIP to its top alignment edge.</para>
		/// </summary>
		public float top;

		/// <summary>
		/// <para>Type: <c>FLOAT</c></para>
		/// <para>The distance from the right-most visible DIP to its right-alignment edge.</para>
		/// </summary>
		public float right;

		/// <summary>
		/// <para>Type: <c>FLOAT</c></para>
		/// <para>The distance from the bottom-most visible DIP to its lower-alignment edge.</para>
		/// </summary>
		public float bottom;
	}

	/// <summary>Stores the association of text and its writing system script, as well as some display attributes.</summary>
	// https://docs.microsoft.com/en-us/windows/win32/api/dwrite/ns-dwrite-dwrite_script_analysis struct DWRITE_SCRIPT_ANALYSIS { UINT16
	// script; DWRITE_SCRIPT_SHAPES shapes; };
	[PInvokeData("dwrite.h", MSDNShortId = "dafda5f6-39aa-4577-9213-898bdeddc7c2")]
	[StructLayout(LayoutKind.Sequential)]
	public struct DWRITE_SCRIPT_ANALYSIS
	{
		/// <summary>
		/// <para>Type: <c>UINT16</c></para>
		/// <para>The zero-based index representation of writing system script.</para>
		/// </summary>
		public ushort script;

		/// <summary>
		/// <para>Type: <c>DWRITE_SCRIPT_SHAPES</c></para>
		/// <para>A value that indicates additional shaping requirement of text.</para>
		/// </summary>
		public DWRITE_SCRIPT_SHAPES shapes;
	}

	/// <summary>Contains shaping output properties for an output glyph.</summary>
	// https://docs.microsoft.com/en-us/windows/win32/api/dwrite/ns-dwrite-dwrite_shaping_glyph_properties struct
	// DWRITE_SHAPING_GLYPH_PROPERTIES { UINT16 justification : 4; UINT16 isClusterStart : 1; UINT16 isDiacritic : 1; UINT16
	// isZeroWidthSpace : 1; UINT16 reserved : 9; };
	[PInvokeData("dwrite.h", MSDNShortId = "debaa84f-8883-4117-9be0-962857b55020")]
	[StructLayout(LayoutKind.Sequential)]
	public struct DWRITE_SHAPING_GLYPH_PROPERTIES
	{
		private ushort bits;

		/// <summary>
		/// <para>Type: <c>UINT16</c></para>
		/// <para>Indicates that the glyph has justification applied.</para>
		/// </summary>
		public ushort justification { get => BitHelper.GetBits(bits, 0, 4); set => BitHelper.SetBits(ref bits, 0, 4, value); }

		/// <summary>
		/// <para>Type: <c>UINT16</c></para>
		/// <para>Indicates that the glyph is the start of a cluster.</para>
		/// </summary>
		public bool isClusterStart { get => BitHelper.GetBit(bits, 4); set => BitHelper.SetBit(ref bits, 4, value); }

		/// <summary>
		/// <para>Type: <c>UINT16</c></para>
		/// <para>Indicates that the glyph is a diacritic mark.</para>
		/// </summary>
		public bool isDiacritic { get => BitHelper.GetBit(bits, 5); set => BitHelper.SetBit(ref bits, 5, value); }

		/// <summary>
		/// <para>Type: <c>UINT16</c></para>
		/// <para>Indicates that the glyph is a word boundary with no visible space.</para>
		/// </summary>
		public bool isZeroWidthSpace { get => BitHelper.GetBit(bits, 6); set => BitHelper.SetBit(ref bits, 6, value); }
	}

	/// <summary>Shaping output properties for an output glyph.</summary>
	// https://docs.microsoft.com/en-us/windows/win32/api/dwrite/ns-dwrite-dwrite_shaping_text_properties struct
	// DWRITE_SHAPING_TEXT_PROPERTIES { UINT16 isShapedAlone : 1; UINT16 reserved1 : 1; UINT16 canBreakShapingAfter : 1; UINT16 reserved
	// : 13; };
	[PInvokeData("dwrite.h", MSDNShortId = "2fd1af73-c2ea-4077-9cf5-77ab9f237f0a")]
	[StructLayout(LayoutKind.Sequential)]
	public struct DWRITE_SHAPING_TEXT_PROPERTIES
	{
		private ushort bits;

		/// <summary>
		/// <para>Type: <c>UINT16</c></para>
		/// <para>Indicates that the glyph is shaped alone.</para>
		/// </summary>
		public bool isShapedAlone { get => BitHelper.GetBit(bits, 0); set => BitHelper.SetBit(ref bits, 0, value); }

		/// <summary/>
		public bool canBreakShapingAfter { get => BitHelper.GetBit(bits, 2); set => BitHelper.SetBit(ref bits, 2, value); }
	}

	/// <summary>
	/// Contains information regarding the size and placement of strikethroughs.All coordinates are in device independent pixels (DIPs).
	/// </summary>
	// https://docs.microsoft.com/en-us/windows/win32/api/dwrite/ns-dwrite-dwrite_strikethrough struct DWRITE_STRIKETHROUGH { FLOAT
	// width; FLOAT thickness; FLOAT offset; DWRITE_READING_DIRECTION readingDirection; DWRITE_FLOW_DIRECTION flowDirection; WCHAR const
	// *localeName; DWRITE_MEASURING_MODE measuringMode; };
	[PInvokeData("dwrite.h", MSDNShortId = "05d86485-2c34-4e3b-99e8-ca54a3b1e5f6")]
	[StructLayout(LayoutKind.Sequential)]
	public struct DWRITE_STRIKETHROUGH
	{
		/// <summary>
		/// <para>Type: <c>FLOAT</c></para>
		/// <para>A value that indicates the width of the strikethrough, measured parallel to the baseline.</para>
		/// </summary>
		public float width;

		/// <summary>
		/// <para>Type: <c>FLOAT</c></para>
		/// <para>A value that indicates the thickness of the strikethrough, measured perpendicular to the baseline.</para>
		/// </summary>
		public float thickness;

		/// <summary>
		/// <para>Type: <c>FLOAT</c></para>
		/// <para>
		/// A value that indicates the offset of the strikethrough from the baseline. A positive offset represents a position below the
		/// baseline and a negative offset is above. Typically, the offset will be negative.
		/// </para>
		/// </summary>
		public float offset;

		/// <summary>
		/// <para>Type: <c>DWRITE_READING_DIRECTION</c></para>
		/// <para>
		/// Reading direction of the text associated with the strikethrough. This value is used to interpret whether the width value
		/// runs horizontally or vertically.
		/// </para>
		/// </summary>
		public DWRITE_READING_DIRECTION readingDirection;

		/// <summary>
		/// <para>Type: <c>DWRITE_FLOW_DIRECTION</c></para>
		/// <para>
		/// Flow direction of the text associated with the strikethrough. This value is used to interpret whether the thickness value
		/// advances top to bottom, left to right, or right to left.
		/// </para>
		/// </summary>
		public DWRITE_FLOW_DIRECTION flowDirection;

		/// <summary>
		/// <para>Type: <c>const WCHAR*</c></para>
		/// <para>An array of characters containing the locale of the text that is the strikethrough is being drawn over.</para>
		/// </summary>
		public IntPtr localeName;

		/// <summary>
		/// <para>Type: <c>DWRITE_MEASURING_MODE</c></para>
		/// <para>
		/// The measuring mode can be useful to the renderer to determine how underlines are rendered, such as rounding the thickness to
		/// a whole pixel in GDI-compatible modes.
		/// </para>
		/// </summary>
		public DWRITE_MEASURING_MODE measuringMode;
	}

	/// <summary>Contains the metrics associated with text after layout. All coordinates are in device independent pixels (DIPs).</summary>
	// https://docs.microsoft.com/en-us/windows/win32/api/dwrite/ns-dwrite-dwrite_text_metrics struct DWRITE_TEXT_METRICS { FLOAT left;
	// FLOAT top; FLOAT width; FLOAT widthIncludingTrailingWhitespace; FLOAT height; FLOAT layoutWidth; FLOAT layoutHeight; UINT32
	// maxBidiReorderingDepth; UINT32 lineCount; };
	[PInvokeData("dwrite.h", MSDNShortId = "4524ace3-fca6-4daf-9ecb-516771e53fc9")]
	[StructLayout(LayoutKind.Sequential)]
	public struct DWRITE_TEXT_METRICS
	{
		/// <summary>
		/// <para>Type: <c>FLOAT</c></para>
		/// <para>
		/// A value that indicates the left-most point of formatted text relative to the layout box, while excluding any glyph overhang.
		/// </para>
		/// </summary>
		public float left;

		/// <summary>
		/// <para>Type: <c>FLOAT</c></para>
		/// <para>
		/// A value that indicates the top-most point of formatted text relative to the layout box, while excluding any glyph overhang.
		/// </para>
		/// </summary>
		public float top;

		/// <summary>
		/// <para>Type: <c>FLOAT</c></para>
		/// <para>A value that indicates the width of the formatted text, while ignoring trailing whitespace at the end of each line.</para>
		/// </summary>
		public float width;

		/// <summary>
		/// <para>Type: <c>FLOAT</c></para>
		/// <para>The width of the formatted text, taking into account the trailing whitespace at the end of each line.</para>
		/// </summary>
		public float widthIncludingTrailingWhitespace;

		/// <summary>
		/// <para>Type: <c>FLOAT</c></para>
		/// <para>The height of the formatted text. The height of an empty string is set to the same value as that of the default font.</para>
		/// </summary>
		public float height;

		/// <summary>
		/// <para>Type: <c>FLOAT</c></para>
		/// <para>
		/// The initial width given to the layout. It can be either larger or smaller than the text content width, depending on whether
		/// the text was wrapped.
		/// </para>
		/// </summary>
		public float layoutWidth;

		/// <summary>
		/// <para>Type: <c>FLOAT</c></para>
		/// <para>
		/// Initial height given to the layout. Depending on the length of the text, it may be larger or smaller than the text content height.
		/// </para>
		/// </summary>
		public float layoutHeight;

		/// <summary>
		/// <para>Type: <c>UINT32</c></para>
		/// <para>
		/// The maximum reordering count of any line of text, used to calculate the most number of hit-testing boxes needed. If the
		/// layout has no bidirectional text, or no text at all, the minimum level is 1.
		/// </para>
		/// </summary>
		public uint maxBidiReorderingDepth;

		/// <summary>
		/// <para>Type: <c>UINT32</c></para>
		/// <para>Total number of lines.</para>
		/// </summary>
		public uint lineCount;
	}

	/// <summary>Specifies a range of text positions where format is applied in the text represented by an IDWriteTextLayout object.</summary>
	// https://docs.microsoft.com/en-us/windows/win32/api/dwrite/ns-dwrite-dwrite_text_range struct DWRITE_TEXT_RANGE { UINT32
	// startPosition; UINT32 length; };
	[PInvokeData("dwrite.h", MSDNShortId = "2e37e060-69b9-4ca2-9d95-8e9a39f6cf83")]
	[StructLayout(LayoutKind.Sequential)]
	public struct DWRITE_TEXT_RANGE
	{
		/// <summary>
		/// <para>Type: <c>UINT32</c></para>
		/// <para>The start position of the text range.</para>
		/// </summary>
		public uint startPosition;

		/// <summary>
		/// <para>Type: <c>UINT32</c></para>
		/// <para>The number positions in the text range.</para>
		/// </summary>
		public uint length;
	}

	/// <summary>Specifies the trimming option for text overflowing the layout box.</summary>
	// https://docs.microsoft.com/en-us/windows/win32/api/dwrite/ns-dwrite-dwrite_trimming struct DWRITE_TRIMMING {
	// DWRITE_TRIMMING_GRANULARITY granularity; UINT32 delimiter; UINT32 delimiterCount; };
	[PInvokeData("dwrite.h", MSDNShortId = "c252b936-8a09-45b4-8138-84cf54058f72")]
	[StructLayout(LayoutKind.Sequential)]
	public struct DWRITE_TRIMMING
	{
		/// <summary>
		/// <para>Type: <c>DWRITE_TRIMMING_GRANULARITY</c></para>
		/// <para>A value that specifies the text granularity used to trim text overflowing the layout box.</para>
		/// </summary>
		public DWRITE_TRIMMING_GRANULARITY granularity;

		/// <summary>
		/// <para>Type: <c>UINT32</c></para>
		/// <para>
		/// A character code used as the delimiter that signals the beginning of the portion of text to be preserved. Text starting from
		/// the Nth occurence of the delimiter (where N equals delimiterCount) counting backwards from the end of the text block will be
		/// preserved. For example, given the text is a path like c:\A\B\C\D\file.txt and delimiter equal to '' and delimiterCount equal
		/// to 1, the file.txt portion of the text would be preserved. Specifying a delimiterCount of 2 would preserve D\file.txt.
		/// </para>
		/// </summary>
		public uint delimiter;

		/// <summary>
		/// <para>Type: <c>UINT32</c></para>
		/// <para>The delimiter count, counting from the end of the text, to preserve text from.</para>
		/// </summary>
		public uint delimiterCount;
	}

	/// <summary>Contains a set of typographic features to be applied during text shaping.</summary>
	// https://docs.microsoft.com/en-us/windows/win32/api/dwrite/ns-dwrite-dwrite_typographic_features struct
	// DWRITE_TYPOGRAPHIC_FEATURES { DWRITE_FONT_FEATURE *features; UINT32 featureCount; };
	[PInvokeData("dwrite.h", MSDNShortId = "21ef4266-5dd6-48b6-9175-452b74e94a07")]
	// [StructLayout(LayoutKind.Sequential)] struct DWRITE_TYPOGRAPHIC_FEATURES{public IntPtr features; public uint featureCount; public
	// ; }
	[StructLayout(LayoutKind.Sequential)]
	public struct DWRITE_TYPOGRAPHIC_FEATURES
	{
		/// <summary>
		/// <para>Type: <c>DWRITE_FONT_FEATURE*</c></para>
		/// <para>A pointer to a structure that specifies properties used to identify and execute typographic features in the font.</para>
		/// </summary>
		public IntPtr features;

		/// <summary>
		/// <para>Type: <c>UINT32</c></para>
		/// <para>A value that indicates the number of features being applied to a font face.</para>
		/// </summary>
		public uint featureCount;
	}

	/// <summary>
	/// Contains information about the width, thickness, offset, run height, reading direction, and flow direction of an underline.
	/// </summary>
	// https://docs.microsoft.com/en-us/windows/win32/api/dwrite/ns-dwrite-dwrite_underline struct DWRITE_UNDERLINE { FLOAT width; FLOAT
	// thickness; FLOAT offset; FLOAT runHeight; DWRITE_READING_DIRECTION readingDirection; DWRITE_FLOW_DIRECTION flowDirection; WCHAR
	// const *localeName; DWRITE_MEASURING_MODE measuringMode; };
	[PInvokeData("dwrite.h", MSDNShortId = "01f6c48e-6986-4a6e-9dd8-9f4b098db7fd")]
	[StructLayout(LayoutKind.Sequential)]
	public struct DWRITE_UNDERLINE
	{
		/// <remarks>All coordinates are in device independent pixels (DIPs).</remarks>
		/// <summary>
		/// <para>Type: <c>FLOAT</c></para>
		/// <para>A value that indicates the width of the underline, measured parallel to the baseline.</para>
		/// </summary>
		public float width;

		/// <summary>
		/// <para>Type: <c>FLOAT</c></para>
		/// <para>A value that indicates the thickness of the underline, measured perpendicular to the baseline.</para>
		/// </summary>
		public float thickness;

		/// <summary>
		/// <para>Type: <c>FLOAT</c></para>
		/// <para>
		/// A value that indicates the offset of the underline from the baseline. A positive offset represents a position below the
		/// baseline (away from the text) and a negative offset is above (toward the text).
		/// </para>
		/// </summary>
		public float offset;

		/// <summary>
		/// <para>Type: <c>FLOAT</c></para>
		/// <para>A value that indicates the height of the tallest run where the underline is applied.</para>
		/// </summary>
		public float runHeight;

		/// <summary>
		/// <para>Type: <c>DWRITE_READING_DIRECTION</c></para>
		/// <para>
		/// A value that indicates the reading direction of the text associated with the underline. This value is used to interpret
		/// whether the width value runs horizontally or vertically.
		/// </para>
		/// </summary>
		public DWRITE_READING_DIRECTION readingDirection;

		/// <summary>
		/// <para>Type: <c>DWRITE_FLOW_DIRECTION</c></para>
		/// <para>
		/// A value that indicates the flow direction of the text associated with the underline. This value is used to interpret whether
		/// the thickness value advances top to bottom, left to right, or right to left.
		/// </para>
		/// </summary>
		public DWRITE_FLOW_DIRECTION flowDirection;

		/// <summary>
		/// <para>Type: <c>const WCHAR*</c></para>
		/// <para>
		/// An array of characters which contains the locale of the text that the underline is being drawn under. For example, in
		/// vertical text, the underline belongs on the left for Chinese but on the right for Japanese.
		/// </para>
		/// </summary>
		public IntPtr localeName;

		/// <summary>
		/// <para>Type: <c>DWRITE_MEASURING_MODE</c></para>
		/// <para>
		/// The measuring mode can be useful to the renderer to determine how underlines are rendered, such as rounding the thickness to
		/// a whole pixel in GDI-compatible modes.
		/// </para>
		/// </summary>
		public DWRITE_MEASURING_MODE measuringMode;
	}
}