namespace Vanara.PInvoke;

public static partial class Dwrite
{
	/// <summary>The <b>DWRITE_BASELINE</b> enumeration contains values that specify the baseline for text alignment.</summary>
	// https://learn.microsoft.com/en-us/windows/win32/api/dwrite_1/ne-dwrite_1-dwrite_baseline typedef enum DWRITE_BASELINE {
	// DWRITE_BASELINE_DEFAULT, DWRITE_BASELINE_ROMAN, DWRITE_BASELINE_CENTRAL, DWRITE_BASELINE_MATH, DWRITE_BASELINE_HANGING,
	// DWRITE_BASELINE_IDEOGRAPHIC_BOTTOM, DWRITE_BASELINE_IDEOGRAPHIC_TOP, DWRITE_BASELINE_MINIMUM, DWRITE_BASELINE_MAXIMUM } ;
	[PInvokeData("dwrite_1.h", MSDNShortId = "NE:dwrite_1.DWRITE_BASELINE")]
	public enum DWRITE_BASELINE
	{
		/// <summary>The Roman baseline for horizontal; the Central baseline for vertical.</summary>
		DWRITE_BASELINE_DEFAULT,

		/// <summary>The baseline that is used by alphabetic scripts such as Latin, Greek, and Cyrillic.</summary>
		DWRITE_BASELINE_ROMAN,

		/// <summary>Central baseline, which is generally used for vertical text.</summary>
		DWRITE_BASELINE_CENTRAL,

		/// <summary>Mathematical baseline, which math characters are centered on.</summary>
		DWRITE_BASELINE_MATH,

		/// <summary>Hanging baseline, which is used in scripts like Devanagari.</summary>
		DWRITE_BASELINE_HANGING,

		/// <summary>Ideographic bottom baseline for CJK, left in vertical.</summary>
		DWRITE_BASELINE_IDEOGRAPHIC_BOTTOM,

		/// <summary>Ideographic top baseline for CJK, right in vertical.</summary>
		DWRITE_BASELINE_IDEOGRAPHIC_TOP,

		/// <summary>The bottom-most extent in horizontal, left-most in vertical.</summary>
		DWRITE_BASELINE_MINIMUM,

		/// <summary>The top-most extent in horizontal, right-most in vertical.</summary>
		DWRITE_BASELINE_MAXIMUM,
	}

	/// <summary>
	/// The <b>DWRITE_GLYPH_ORIENTATION_ANGLE</b> enumeration contains values that specify how the glyph is oriented to the x-axis.
	/// </summary>
	/// <remarks>
	/// The text analyzer outputs <b>DWRITE_GLYPH_ORIENTATION_ANGLE</b> values. The value that it outputs depends on the desired
	/// orientation, bidi level, and character properties.
	/// </remarks>
	// https://learn.microsoft.com/en-us/windows/win32/api/dwrite_1/ne-dwrite_1-dwrite_glyph_orientation_angle typedef enum
	// DWRITE_GLYPH_ORIENTATION_ANGLE { DWRITE_GLYPH_ORIENTATION_ANGLE_0_DEGREES, DWRITE_GLYPH_ORIENTATION_ANGLE_90_DEGREES,
	// DWRITE_GLYPH_ORIENTATION_ANGLE_180_DEGREES, DWRITE_GLYPH_ORIENTATION_ANGLE_270_DEGREES } ;
	[PInvokeData("dwrite_1.h", MSDNShortId = "NE:dwrite_1.DWRITE_GLYPH_ORIENTATION_ANGLE")]
	public enum DWRITE_GLYPH_ORIENTATION_ANGLE
	{
		/// <summary>Glyph orientation is upright.</summary>
		DWRITE_GLYPH_ORIENTATION_ANGLE_0_DEGREES,

		/// <summary>Glyph orientation is rotated 90 degrees clockwise.</summary>
		DWRITE_GLYPH_ORIENTATION_ANGLE_90_DEGREES,

		/// <summary>Glyph orientation is upside-down.</summary>
		DWRITE_GLYPH_ORIENTATION_ANGLE_180_DEGREES,

		/// <summary>Glyph orientation is rotated 270 degrees clockwise.</summary>
		DWRITE_GLYPH_ORIENTATION_ANGLE_270_DEGREES,
	}

	/// <summary>
	/// The <b>DWRITE_OUTLINE_THRESHOLD</b> enumeration contains values that specify the policy used by the
	/// <c>IDWriteFontFace1::GetRecommendedRenderingMode</c> method to determine whether to render glyphs in outline mode.
	/// </summary>
	/// <remarks>
	/// Glyphs are rendered in outline mode by default at large sizes for performance reasons, but how large (that is, the outline
	/// threshold) depends on the quality of outline rendering. If the graphics system renders anti-aliased outlines, a relatively low
	/// threshold is used. But if the graphics system renders aliased outlines, a much higher threshold is used.
	/// </remarks>
	// https://learn.microsoft.com/en-us/windows/win32/api/dwrite_1/ne-dwrite_1-dwrite_outline_threshold typedef enum
	// DWRITE_OUTLINE_THRESHOLD { DWRITE_OUTLINE_THRESHOLD_ANTIALIASED, DWRITE_OUTLINE_THRESHOLD_ALIASED } ;
	[PInvokeData("dwrite_1.h", MSDNShortId = "NE:dwrite_1.DWRITE_OUTLINE_THRESHOLD")]
	public enum DWRITE_OUTLINE_THRESHOLD
	{
		/// <summary>Graphics system renders anti-aliased outlines.</summary>
		DWRITE_OUTLINE_THRESHOLD_ANTIALIASED,

		/// <summary>Graphics system renders aliased outlines.</summary>
		DWRITE_OUTLINE_THRESHOLD_ALIASED,
	}

	/// <summary>
	/// The <b>DWRITE_PANOSE_ARM_STYLE</b> enumeration contains values that specify the style of termination of stems and rounded
	/// letterforms for text.
	/// </summary>
	// https://learn.microsoft.com/en-us/windows/win32/api/dwrite_1/ne-dwrite_1-dwrite_panose_arm_style typedef enum DWRITE_PANOSE_ARM_STYLE
	// { DWRITE_PANOSE_ARM_STYLE_ANY = 0, DWRITE_PANOSE_ARM_STYLE_NO_FIT = 1, DWRITE_PANOSE_ARM_STYLE_STRAIGHT_ARMS_HORIZONTAL = 2,
	// DWRITE_PANOSE_ARM_STYLE_STRAIGHT_ARMS_WEDGE = 3, DWRITE_PANOSE_ARM_STYLE_STRAIGHT_ARMS_VERTICAL = 4,
	// DWRITE_PANOSE_ARM_STYLE_STRAIGHT_ARMS_SINGLE_SERIF = 5, DWRITE_PANOSE_ARM_STYLE_STRAIGHT_ARMS_DOUBLE_SERIF = 6,
	// DWRITE_PANOSE_ARM_STYLE_NONSTRAIGHT_ARMS_HORIZONTAL = 7, DWRITE_PANOSE_ARM_STYLE_NONSTRAIGHT_ARMS_WEDGE = 8,
	// DWRITE_PANOSE_ARM_STYLE_NONSTRAIGHT_ARMS_VERTICAL = 9, DWRITE_PANOSE_ARM_STYLE_NONSTRAIGHT_ARMS_SINGLE_SERIF = 10,
	// DWRITE_PANOSE_ARM_STYLE_NONSTRAIGHT_ARMS_DOUBLE_SERIF = 11, DWRITE_PANOSE_ARM_STYLE_STRAIGHT_ARMS_HORZ,
	// DWRITE_PANOSE_ARM_STYLE_STRAIGHT_ARMS_VERT, DWRITE_PANOSE_ARM_STYLE_BENT_ARMS_HORZ, DWRITE_PANOSE_ARM_STYLE_BENT_ARMS_WEDGE,
	// DWRITE_PANOSE_ARM_STYLE_BENT_ARMS_VERT, DWRITE_PANOSE_ARM_STYLE_BENT_ARMS_SINGLE_SERIF,
	// DWRITE_PANOSE_ARM_STYLE_BENT_ARMS_DOUBLE_SERIF } ;
	[PInvokeData("dwrite_1.h", MSDNShortId = "NE:dwrite_1.DWRITE_PANOSE_ARM_STYLE")]
	public enum DWRITE_PANOSE_ARM_STYLE
	{
		/// <summary>
		/// <para>Value:</para>
		/// <para>0</para>
		/// <para>Any arm style.</para>
		/// </summary>
		DWRITE_PANOSE_ARM_STYLE_ANY,

		/// <summary>
		/// <para>Value:</para>
		/// <para>1</para>
		/// <para>No fit arm style.</para>
		/// </summary>
		DWRITE_PANOSE_ARM_STYLE_NO_FIT,

		/// <summary>
		/// <para>Value:</para>
		/// <para>2</para>
		/// <para>The arm style is straight horizontal.</para>
		/// </summary>
		DWRITE_PANOSE_ARM_STYLE_STRAIGHT_ARMS_HORIZONTAL,

		/// <summary>
		/// <para>Value:</para>
		/// <para>3</para>
		/// <para>The arm style is straight wedge.</para>
		/// </summary>
		DWRITE_PANOSE_ARM_STYLE_STRAIGHT_ARMS_WEDGE,

		/// <summary>
		/// <para>Value:</para>
		/// <para>4</para>
		/// <para>The arm style is straight vertical.</para>
		/// </summary>
		DWRITE_PANOSE_ARM_STYLE_STRAIGHT_ARMS_VERTICAL,

		/// <summary>
		/// <para>Value:</para>
		/// <para>5</para>
		/// <para>The arm style is straight single serif.</para>
		/// </summary>
		DWRITE_PANOSE_ARM_STYLE_STRAIGHT_ARMS_SINGLE_SERIF,

		/// <summary>
		/// <para>Value:</para>
		/// <para>6</para>
		/// <para>The arm style is straight double serif.</para>
		/// </summary>
		DWRITE_PANOSE_ARM_STYLE_STRAIGHT_ARMS_DOUBLE_SERIF,

		/// <summary>
		/// <para>Value:</para>
		/// <para>7</para>
		/// <para>The arm style is non-straight horizontal.</para>
		/// </summary>
		DWRITE_PANOSE_ARM_STYLE_NONSTRAIGHT_ARMS_HORIZONTAL,

		/// <summary>
		/// <para>Value:</para>
		/// <para>8</para>
		/// <para>The arm style is non-straight wedge.</para>
		/// </summary>
		DWRITE_PANOSE_ARM_STYLE_NONSTRAIGHT_ARMS_WEDGE,

		/// <summary>
		/// <para>Value:</para>
		/// <para>9</para>
		/// <para>The arm style is non-straight vertical.</para>
		/// </summary>
		DWRITE_PANOSE_ARM_STYLE_NONSTRAIGHT_ARMS_VERTICAL,

		/// <summary>
		/// <para>Value:</para>
		/// <para>10</para>
		/// <para>The arm style is non-straight single serif.</para>
		/// </summary>
		DWRITE_PANOSE_ARM_STYLE_NONSTRAIGHT_ARMS_SINGLE_SERIF,

		/// <summary>
		/// <para>Value:</para>
		/// <para>11</para>
		/// <para>The arm style is non-straight double serif.</para>
		/// </summary>
		DWRITE_PANOSE_ARM_STYLE_NONSTRAIGHT_ARMS_DOUBLE_SERIF,

		/// <summary>The arm style is straight horizontal.</summary>
		DWRITE_PANOSE_ARM_STYLE_STRAIGHT_ARMS_HORZ,

		/// <summary>The arm style is straight vertical.</summary>
		DWRITE_PANOSE_ARM_STYLE_STRAIGHT_ARMS_VERT,

		/// <summary>The arm style is non-straight horizontal.</summary>
		DWRITE_PANOSE_ARM_STYLE_BENT_ARMS_HORZ,

		/// <summary>The arm style is non-straight wedge.</summary>
		DWRITE_PANOSE_ARM_STYLE_BENT_ARMS_WEDGE,

		/// <summary>The arm style is non-straight vertical.</summary>
		DWRITE_PANOSE_ARM_STYLE_BENT_ARMS_VERT,

		/// <summary>The arm style is non-straight single serif.</summary>
		DWRITE_PANOSE_ARM_STYLE_BENT_ARMS_SINGLE_SERIF,

		/// <summary>The arm style is non-straight double serif.</summary>
		DWRITE_PANOSE_ARM_STYLE_BENT_ARMS_DOUBLE_SERIF,
	}

	/// <summary>
	/// The <b>DWRITE_PANOSE_ASPECT</b> enumeration contains values that specify the ratio between the width and height of the character face.
	/// </summary>
	// https://learn.microsoft.com/en-us/windows/win32/api/dwrite_1/ne-dwrite_1-dwrite_panose_aspect typedef enum DWRITE_PANOSE_ASPECT {
	// DWRITE_PANOSE_ASPECT_ANY = 0, DWRITE_PANOSE_ASPECT_NO_FIT = 1, DWRITE_PANOSE_ASPECT_SUPER_CONDENSED = 2,
	// DWRITE_PANOSE_ASPECT_VERY_CONDENSED = 3, DWRITE_PANOSE_ASPECT_CONDENSED = 4, DWRITE_PANOSE_ASPECT_NORMAL = 5,
	// DWRITE_PANOSE_ASPECT_EXTENDED = 6, DWRITE_PANOSE_ASPECT_VERY_EXTENDED = 7, DWRITE_PANOSE_ASPECT_SUPER_EXTENDED = 8,
	// DWRITE_PANOSE_ASPECT_MONOSPACED = 9 } ;
	[PInvokeData("dwrite_1.h", MSDNShortId = "NE:dwrite_1.DWRITE_PANOSE_ASPECT")]
	public enum DWRITE_PANOSE_ASPECT
	{
		/// <summary>
		/// <para>Value:</para>
		/// <para>0</para>
		/// <para>Any aspect.</para>
		/// </summary>
		DWRITE_PANOSE_ASPECT_ANY,

		/// <summary>
		/// <para>Value:</para>
		/// <para>1</para>
		/// <para>No fit for aspect.</para>
		/// </summary>
		DWRITE_PANOSE_ASPECT_NO_FIT,

		/// <summary>
		/// <para>Value:</para>
		/// <para>2</para>
		/// <para>Super condensed aspect.</para>
		/// </summary>
		DWRITE_PANOSE_ASPECT_SUPER_CONDENSED,

		/// <summary>
		/// <para>Value:</para>
		/// <para>3</para>
		/// <para>Very condensed aspect.</para>
		/// </summary>
		DWRITE_PANOSE_ASPECT_VERY_CONDENSED,

		/// <summary>
		/// <para>Value:</para>
		/// <para>4</para>
		/// <para>Condensed aspect.</para>
		/// </summary>
		DWRITE_PANOSE_ASPECT_CONDENSED,

		/// <summary>
		/// <para>Value:</para>
		/// <para>5</para>
		/// <para>Normal aspect.</para>
		/// </summary>
		DWRITE_PANOSE_ASPECT_NORMAL,

		/// <summary>
		/// <para>Value:</para>
		/// <para>6</para>
		/// <para>Extended aspect.</para>
		/// </summary>
		DWRITE_PANOSE_ASPECT_EXTENDED,

		/// <summary>
		/// <para>Value:</para>
		/// <para>7</para>
		/// <para>Very extended aspect.</para>
		/// </summary>
		DWRITE_PANOSE_ASPECT_VERY_EXTENDED,

		/// <summary>
		/// <para>Value:</para>
		/// <para>8</para>
		/// <para>Super extended aspect.</para>
		/// </summary>
		DWRITE_PANOSE_ASPECT_SUPER_EXTENDED,

		/// <summary>
		/// <para>Value:</para>
		/// <para>9</para>
		/// <para>Monospace aspect.</para>
		/// </summary>
		DWRITE_PANOSE_ASPECT_MONOSPACED,
	}

	/// <summary>
	/// The <b>DWRITE_PANOSE_ASPECT_RATIO</b> enumeration contains values that specify info about the ratio between width and height of the
	/// character face.
	/// </summary>
	// https://learn.microsoft.com/en-us/windows/win32/api/dwrite_1/ne-dwrite_1-dwrite_panose_aspect_ratio typedef enum
	// DWRITE_PANOSE_ASPECT_RATIO { DWRITE_PANOSE_ASPECT_RATIO_ANY = 0, DWRITE_PANOSE_ASPECT_RATIO_NO_FIT = 1,
	// DWRITE_PANOSE_ASPECT_RATIO_VERY_CONDENSED = 2, DWRITE_PANOSE_ASPECT_RATIO_CONDENSED = 3, DWRITE_PANOSE_ASPECT_RATIO_NORMAL = 4,
	// DWRITE_PANOSE_ASPECT_RATIO_EXPANDED = 5, DWRITE_PANOSE_ASPECT_RATIO_VERY_EXPANDED = 6 } ;
	[PInvokeData("dwrite_1.h", MSDNShortId = "NE:dwrite_1.DWRITE_PANOSE_ASPECT_RATIO")]
	public enum DWRITE_PANOSE_ASPECT_RATIO
	{
		/// <summary>
		/// <para>Value:</para>
		/// <para>0</para>
		/// <para>Any aspect ratio.</para>
		/// </summary>
		DWRITE_PANOSE_ASPECT_RATIO_ANY,

		/// <summary>
		/// <para>Value:</para>
		/// <para>1</para>
		/// <para>No fit for aspect ratio.</para>
		/// </summary>
		DWRITE_PANOSE_ASPECT_RATIO_NO_FIT,

		/// <summary>
		/// <para>Value:</para>
		/// <para>2</para>
		/// <para>Very condensed aspect ratio.</para>
		/// </summary>
		DWRITE_PANOSE_ASPECT_RATIO_VERY_CONDENSED,

		/// <summary>
		/// <para>Value:</para>
		/// <para>3</para>
		/// <para>Condensed aspect ratio.</para>
		/// </summary>
		DWRITE_PANOSE_ASPECT_RATIO_CONDENSED,

		/// <summary>
		/// <para>Value:</para>
		/// <para>4</para>
		/// <para>Normal aspect ratio.</para>
		/// </summary>
		DWRITE_PANOSE_ASPECT_RATIO_NORMAL,

		/// <summary>
		/// <para>Value:</para>
		/// <para>5</para>
		/// <para>Expanded aspect ratio.</para>
		/// </summary>
		DWRITE_PANOSE_ASPECT_RATIO_EXPANDED,

		/// <summary>
		/// <para>Value:</para>
		/// <para>6</para>
		/// <para>Very expanded aspect ratio.</para>
		/// </summary>
		DWRITE_PANOSE_ASPECT_RATIO_VERY_EXPANDED,
	}

	/// <summary>
	/// The <b>DWRITE_PANOSE_CHARACTER_RANGES</b> enumeration contains values that specify the type of characters available in the font.
	/// </summary>
	// https://learn.microsoft.com/en-us/windows/win32/api/dwrite_1/ne-dwrite_1-dwrite_panose_character_ranges typedef enum
	// DWRITE_PANOSE_CHARACTER_RANGES { DWRITE_PANOSE_CHARACTER_RANGES_ANY = 0, DWRITE_PANOSE_CHARACTER_RANGES_NO_FIT = 1,
	// DWRITE_PANOSE_CHARACTER_RANGES_EXTENDED_COLLECTION = 2, DWRITE_PANOSE_CHARACTER_RANGES_LITERALS = 3,
	// DWRITE_PANOSE_CHARACTER_RANGES_NO_LOWER_CASE = 4, DWRITE_PANOSE_CHARACTER_RANGES_SMALL_CAPS = 5 } ;
	[PInvokeData("dwrite_1.h", MSDNShortId = "NE:dwrite_1.DWRITE_PANOSE_CHARACTER_RANGES")]
	public enum DWRITE_PANOSE_CHARACTER_RANGES
	{
		/// <summary>
		/// <para>Value:</para>
		/// <para>0</para>
		/// <para>Any range.</para>
		/// </summary>
		DWRITE_PANOSE_CHARACTER_RANGES_ANY,

		/// <summary>
		/// <para>Value:</para>
		/// <para>1</para>
		/// <para>No fit for range.</para>
		/// </summary>
		DWRITE_PANOSE_CHARACTER_RANGES_NO_FIT,

		/// <summary>
		/// <para>Value:</para>
		/// <para>2</para>
		/// <para>The range includes extended collection.</para>
		/// </summary>
		DWRITE_PANOSE_CHARACTER_RANGES_EXTENDED_COLLECTION,

		/// <summary>
		/// <para>Value:</para>
		/// <para>3</para>
		/// <para>The range includes literals.</para>
		/// </summary>
		DWRITE_PANOSE_CHARACTER_RANGES_LITERALS,

		/// <summary>
		/// <para>Value:</para>
		/// <para>4</para>
		/// <para>The range doesn't include lower case.</para>
		/// </summary>
		DWRITE_PANOSE_CHARACTER_RANGES_NO_LOWER_CASE,

		/// <summary>
		/// <para>Value:</para>
		/// <para>5</para>
		/// <para>The range includes small capitals.</para>
		/// </summary>
		DWRITE_PANOSE_CHARACTER_RANGES_SMALL_CAPS,
	}

	/// <summary>
	/// The <b>DWRITE_PANOSE_CONTRAST</b> enumeration contains values that specify the ratio between thickest and thinnest point of the
	/// stroke for a letter such as uppercase 'O'.
	/// </summary>
	// https://learn.microsoft.com/en-us/windows/win32/api/dwrite_1/ne-dwrite_1-dwrite_panose_contrast typedef enum DWRITE_PANOSE_CONTRAST {
	// DWRITE_PANOSE_CONTRAST_ANY = 0, DWRITE_PANOSE_CONTRAST_NO_FIT = 1, DWRITE_PANOSE_CONTRAST_NONE = 2, DWRITE_PANOSE_CONTRAST_VERY_LOW =
	// 3, DWRITE_PANOSE_CONTRAST_LOW = 4, DWRITE_PANOSE_CONTRAST_MEDIUM_LOW = 5, DWRITE_PANOSE_CONTRAST_MEDIUM = 6,
	// DWRITE_PANOSE_CONTRAST_MEDIUM_HIGH = 7, DWRITE_PANOSE_CONTRAST_HIGH = 8, DWRITE_PANOSE_CONTRAST_VERY_HIGH = 9,
	// DWRITE_PANOSE_CONTRAST_HORIZONTAL_LOW = 10, DWRITE_PANOSE_CONTRAST_HORIZONTAL_MEDIUM = 11, DWRITE_PANOSE_CONTRAST_HORIZONTAL_HIGH =
	// 12, DWRITE_PANOSE_CONTRAST_BROKEN = 13 } ;
	[PInvokeData("dwrite_1.h", MSDNShortId = "NE:dwrite_1.DWRITE_PANOSE_CONTRAST")]
	public enum DWRITE_PANOSE_CONTRAST
	{
		/// <summary>
		/// <para>Value:</para>
		/// <para>0</para>
		/// <para>Any contrast.</para>
		/// </summary>
		DWRITE_PANOSE_CONTRAST_ANY,

		/// <summary>
		/// <para>Value:</para>
		/// <para>1</para>
		/// <para>No fit contrast.</para>
		/// </summary>
		DWRITE_PANOSE_CONTRAST_NO_FIT,

		/// <summary>
		/// <para>Value:</para>
		/// <para>2</para>
		/// <para>No contrast.</para>
		/// </summary>
		DWRITE_PANOSE_CONTRAST_NONE,

		/// <summary>
		/// <para>Value:</para>
		/// <para>3</para>
		/// <para>Very low contrast.</para>
		/// </summary>
		DWRITE_PANOSE_CONTRAST_VERY_LOW,

		/// <summary>
		/// <para>Value:</para>
		/// <para>4</para>
		/// <para>Low contrast.</para>
		/// </summary>
		DWRITE_PANOSE_CONTRAST_LOW,

		/// <summary>
		/// <para>Value:</para>
		/// <para>5</para>
		/// <para>Medium low contrast.</para>
		/// </summary>
		DWRITE_PANOSE_CONTRAST_MEDIUM_LOW,

		/// <summary>
		/// <para>Value:</para>
		/// <para>6</para>
		/// <para>Medium contrast.</para>
		/// </summary>
		DWRITE_PANOSE_CONTRAST_MEDIUM,

		/// <summary>
		/// <para>Value:</para>
		/// <para>7</para>
		/// <para>Medium high contrast.</para>
		/// </summary>
		DWRITE_PANOSE_CONTRAST_MEDIUM_HIGH,

		/// <summary>
		/// <para>Value:</para>
		/// <para>8</para>
		/// <para>High contrast.</para>
		/// </summary>
		DWRITE_PANOSE_CONTRAST_HIGH,

		/// <summary>
		/// <para>Value:</para>
		/// <para>9</para>
		/// <para>Very high contrast.</para>
		/// </summary>
		DWRITE_PANOSE_CONTRAST_VERY_HIGH,

		/// <summary>
		/// <para>Value:</para>
		/// <para>10</para>
		/// <para>Horizontal low contrast.</para>
		/// </summary>
		DWRITE_PANOSE_CONTRAST_HORIZONTAL_LOW,

		/// <summary>
		/// <para>Value:</para>
		/// <para>11</para>
		/// <para>Horizontal medium contrast.</para>
		/// </summary>
		DWRITE_PANOSE_CONTRAST_HORIZONTAL_MEDIUM,

		/// <summary>
		/// <para>Value:</para>
		/// <para>12</para>
		/// <para>Horizontal high contrast.</para>
		/// </summary>
		DWRITE_PANOSE_CONTRAST_HORIZONTAL_HIGH,

		/// <summary>
		/// <para>Value:</para>
		/// <para>13</para>
		/// <para>Broken contrast.</para>
		/// </summary>
		DWRITE_PANOSE_CONTRAST_BROKEN,
	}

	/// <summary>
	/// The <b>DWRITE_PANOSE_DECORATIVE_CLASS</b> enumeration contains values that specify the general look of the character face.
	/// </summary>
	// https://learn.microsoft.com/en-us/windows/win32/api/dwrite_1/ne-dwrite_1-dwrite_panose_decorative_class typedef enum
	// DWRITE_PANOSE_DECORATIVE_CLASS { DWRITE_PANOSE_DECORATIVE_CLASS_ANY = 0, DWRITE_PANOSE_DECORATIVE_CLASS_NO_FIT = 1,
	// DWRITE_PANOSE_DECORATIVE_CLASS_DERIVATIVE = 2, DWRITE_PANOSE_DECORATIVE_CLASS_NONSTANDARD_TOPOLOGY = 3,
	// DWRITE_PANOSE_DECORATIVE_CLASS_NONSTANDARD_ELEMENTS = 4, DWRITE_PANOSE_DECORATIVE_CLASS_NONSTANDARD_ASPECT = 5,
	// DWRITE_PANOSE_DECORATIVE_CLASS_INITIALS = 6, DWRITE_PANOSE_DECORATIVE_CLASS_CARTOON = 7, DWRITE_PANOSE_DECORATIVE_CLASS_PICTURE_STEMS
	// = 8, DWRITE_PANOSE_DECORATIVE_CLASS_ORNAMENTED = 9, DWRITE_PANOSE_DECORATIVE_CLASS_TEXT_AND_BACKGROUND = 10,
	// DWRITE_PANOSE_DECORATIVE_CLASS_COLLAGE = 11, DWRITE_PANOSE_DECORATIVE_CLASS_MONTAGE = 12 } ;
	[PInvokeData("dwrite_1.h", MSDNShortId = "NE:dwrite_1.DWRITE_PANOSE_DECORATIVE_CLASS")]
	public enum DWRITE_PANOSE_DECORATIVE_CLASS
	{
		/// <summary>
		/// <para>Value:</para>
		/// <para>0</para>
		/// <para>Any class of decorative typeface.</para>
		/// </summary>
		DWRITE_PANOSE_DECORATIVE_CLASS_ANY,

		/// <summary>
		/// <para>Value:</para>
		/// <para>1</para>
		/// <para>No fit for decorative typeface.</para>
		/// </summary>
		DWRITE_PANOSE_DECORATIVE_CLASS_NO_FIT,

		/// <summary>
		/// <para>Value:</para>
		/// <para>2</para>
		/// <para>Derivative decorative typeface.</para>
		/// </summary>
		DWRITE_PANOSE_DECORATIVE_CLASS_DERIVATIVE,

		/// <summary>
		/// <para>Value:</para>
		/// <para>3</para>
		/// <para>Nonstandard topology decorative typeface.</para>
		/// </summary>
		DWRITE_PANOSE_DECORATIVE_CLASS_NONSTANDARD_TOPOLOGY,

		/// <summary>
		/// <para>Value:</para>
		/// <para>4</para>
		/// <para>Nonstandard elements decorative typeface.</para>
		/// </summary>
		DWRITE_PANOSE_DECORATIVE_CLASS_NONSTANDARD_ELEMENTS,

		/// <summary>
		/// <para>Value:</para>
		/// <para>5</para>
		/// <para>Nonstandard aspect decorative typeface.</para>
		/// </summary>
		DWRITE_PANOSE_DECORATIVE_CLASS_NONSTANDARD_ASPECT,

		/// <summary>
		/// <para>Value:</para>
		/// <para>6</para>
		/// <para>Initials decorative typeface.</para>
		/// </summary>
		DWRITE_PANOSE_DECORATIVE_CLASS_INITIALS,

		/// <summary>
		/// <para>Value:</para>
		/// <para>7</para>
		/// <para>Cartoon decorative typeface.</para>
		/// </summary>
		DWRITE_PANOSE_DECORATIVE_CLASS_CARTOON,

		/// <summary>
		/// <para>Value:</para>
		/// <para>8</para>
		/// <para>Picture stems decorative typeface.</para>
		/// </summary>
		DWRITE_PANOSE_DECORATIVE_CLASS_PICTURE_STEMS,

		/// <summary>
		/// <para>Value:</para>
		/// <para>9</para>
		/// <para>Ornamented decorative typeface.</para>
		/// </summary>
		DWRITE_PANOSE_DECORATIVE_CLASS_ORNAMENTED,

		/// <summary>
		/// <para>Value:</para>
		/// <para>10</para>
		/// <para>Text and background decorative typeface.</para>
		/// </summary>
		DWRITE_PANOSE_DECORATIVE_CLASS_TEXT_AND_BACKGROUND,

		/// <summary>
		/// <para>Value:</para>
		/// <para>11</para>
		/// <para>Collage decorative typeface.</para>
		/// </summary>
		DWRITE_PANOSE_DECORATIVE_CLASS_COLLAGE,

		/// <summary>
		/// <para>Value:</para>
		/// <para>12</para>
		/// <para>Montage decorative typeface.</para>
		/// </summary>
		DWRITE_PANOSE_DECORATIVE_CLASS_MONTAGE,
	}

	/// <summary>
	/// The <b>DWRITE_PANOSE_DECORATIVE_TOPOLOGY</b> enumeration contains values that specify the overall shape characteristics of the font.
	/// </summary>
	// https://learn.microsoft.com/en-us/windows/win32/api/dwrite_1/ne-dwrite_1-dwrite_panose_decorative_topology typedef enum
	// DWRITE_PANOSE_DECORATIVE_TOPOLOGY { DWRITE_PANOSE_DECORATIVE_TOPOLOGY_ANY = 0, DWRITE_PANOSE_DECORATIVE_TOPOLOGY_NO_FIT = 1,
	// DWRITE_PANOSE_DECORATIVE_TOPOLOGY_STANDARD = 2, DWRITE_PANOSE_DECORATIVE_TOPOLOGY_SQUARE = 3,
	// DWRITE_PANOSE_DECORATIVE_TOPOLOGY_MULTIPLE_SEGMENT = 4, DWRITE_PANOSE_DECORATIVE_TOPOLOGY_ART_DECO = 5,
	// DWRITE_PANOSE_DECORATIVE_TOPOLOGY_UNEVEN_WEIGHTING = 6, DWRITE_PANOSE_DECORATIVE_TOPOLOGY_DIVERSE_ARMS = 7,
	// DWRITE_PANOSE_DECORATIVE_TOPOLOGY_DIVERSE_FORMS = 8, DWRITE_PANOSE_DECORATIVE_TOPOLOGY_LOMBARDIC_FORMS = 9,
	// DWRITE_PANOSE_DECORATIVE_TOPOLOGY_UPPER_CASE_IN_LOWER_CASE = 10, DWRITE_PANOSE_DECORATIVE_TOPOLOGY_IMPLIED_TOPOLOGY = 11,
	// DWRITE_PANOSE_DECORATIVE_TOPOLOGY_HORSESHOE_E_AND_A = 12, DWRITE_PANOSE_DECORATIVE_TOPOLOGY_CURSIVE = 13,
	// DWRITE_PANOSE_DECORATIVE_TOPOLOGY_BLACKLETTER = 14, DWRITE_PANOSE_DECORATIVE_TOPOLOGY_SWASH_VARIANCE = 15 } ;
	[PInvokeData("dwrite_1.h", MSDNShortId = "NE:dwrite_1.DWRITE_PANOSE_DECORATIVE_TOPOLOGY")]
	public enum DWRITE_PANOSE_DECORATIVE_TOPOLOGY
	{
		/// <summary>
		/// <para>Value:</para>
		/// <para>0</para>
		/// <para>Any decorative topology.</para>
		/// </summary>
		DWRITE_PANOSE_DECORATIVE_TOPOLOGY_ANY,

		/// <summary>
		/// <para>Value:</para>
		/// <para>1</para>
		/// <para>No fit for decorative topology.</para>
		/// </summary>
		DWRITE_PANOSE_DECORATIVE_TOPOLOGY_NO_FIT,

		/// <summary>
		/// <para>Value:</para>
		/// <para>2</para>
		/// <para>Standard decorative topology.</para>
		/// </summary>
		DWRITE_PANOSE_DECORATIVE_TOPOLOGY_STANDARD,

		/// <summary>
		/// <para>Value:</para>
		/// <para>3</para>
		/// <para>Square decorative topology.</para>
		/// </summary>
		DWRITE_PANOSE_DECORATIVE_TOPOLOGY_SQUARE,

		/// <summary>
		/// <para>Value:</para>
		/// <para>4</para>
		/// <para>Multiple segment decorative topology.</para>
		/// </summary>
		DWRITE_PANOSE_DECORATIVE_TOPOLOGY_MULTIPLE_SEGMENT,

		/// <summary>
		/// <para>Value:</para>
		/// <para>5</para>
		/// <para>Art deco decorative topology.</para>
		/// </summary>
		DWRITE_PANOSE_DECORATIVE_TOPOLOGY_ART_DECO,

		/// <summary>
		/// <para>Value:</para>
		/// <para>6</para>
		/// <para>Uneven weighting decorative topology.</para>
		/// </summary>
		DWRITE_PANOSE_DECORATIVE_TOPOLOGY_UNEVEN_WEIGHTING,

		/// <summary>
		/// <para>Value:</para>
		/// <para>7</para>
		/// <para>Diverse arms decorative topology.</para>
		/// </summary>
		DWRITE_PANOSE_DECORATIVE_TOPOLOGY_DIVERSE_ARMS,

		/// <summary>
		/// <para>Value:</para>
		/// <para>8</para>
		/// <para>Diverse forms decorative topology.</para>
		/// </summary>
		DWRITE_PANOSE_DECORATIVE_TOPOLOGY_DIVERSE_FORMS,

		/// <summary>
		/// <para>Value:</para>
		/// <para>9</para>
		/// <para>Lombardic forms decorative topology.</para>
		/// </summary>
		DWRITE_PANOSE_DECORATIVE_TOPOLOGY_LOMBARDIC_FORMS,

		/// <summary>
		/// <para>Value:</para>
		/// <para>10</para>
		/// <para>Upper case in lower case decorative topology.</para>
		/// </summary>
		DWRITE_PANOSE_DECORATIVE_TOPOLOGY_UPPER_CASE_IN_LOWER_CASE,

		/// <summary>
		/// <para>Value:</para>
		/// <para>11</para>
		/// <para>The decorative topology is implied.</para>
		/// </summary>
		DWRITE_PANOSE_DECORATIVE_TOPOLOGY_IMPLIED_TOPOLOGY,

		/// <summary>
		/// <para>Value:</para>
		/// <para>12</para>
		/// <para>Horseshoe E and A decorative topology.</para>
		/// </summary>
		DWRITE_PANOSE_DECORATIVE_TOPOLOGY_HORSESHOE_E_AND_A,

		/// <summary>
		/// <para>Value:</para>
		/// <para>13</para>
		/// <para>Cursive decorative topology.</para>
		/// </summary>
		DWRITE_PANOSE_DECORATIVE_TOPOLOGY_CURSIVE,

		/// <summary>
		/// <para>Value:</para>
		/// <para>14</para>
		/// <para>Blackletter decorative topology.</para>
		/// </summary>
		DWRITE_PANOSE_DECORATIVE_TOPOLOGY_BLACKLETTER,

		/// <summary>
		/// <para>Value:</para>
		/// <para>15</para>
		/// <para>Swash variance decorative topology.</para>
		/// </summary>
		DWRITE_PANOSE_DECORATIVE_TOPOLOGY_SWASH_VARIANCE,
	}

	/// <summary>The <b>DWRITE_PANOSE_FAMILY</b> enumeration contains values that specify the kind of typeface classification.</summary>
	// https://learn.microsoft.com/en-us/windows/win32/api/dwrite_1/ne-dwrite_1-dwrite_panose_family typedef enum DWRITE_PANOSE_FAMILY {
	// DWRITE_PANOSE_FAMILY_ANY = 0, DWRITE_PANOSE_FAMILY_NO_FIT = 1, DWRITE_PANOSE_FAMILY_TEXT_DISPLAY = 2, DWRITE_PANOSE_FAMILY_SCRIPT =
	// 3, DWRITE_PANOSE_FAMILY_DECORATIVE = 4, DWRITE_PANOSE_FAMILY_SYMBOL = 5, DWRITE_PANOSE_FAMILY_PICTORIAL } ;
	[PInvokeData("dwrite_1.h", MSDNShortId = "NE:dwrite_1.DWRITE_PANOSE_FAMILY")]
	public enum DWRITE_PANOSE_FAMILY : byte
	{
		/// <summary>
		/// <para>Value:</para>
		/// <para>0</para>
		/// <para>Any typeface classification.</para>
		/// </summary>
		DWRITE_PANOSE_FAMILY_ANY,

		/// <summary>
		/// <para>Value:</para>
		/// <para>1</para>
		/// <para>No fit typeface classification.</para>
		/// </summary>
		DWRITE_PANOSE_FAMILY_NO_FIT,

		/// <summary>
		/// <para>Value:</para>
		/// <para>2</para>
		/// <para>Text display typeface classification.</para>
		/// </summary>
		DWRITE_PANOSE_FAMILY_TEXT_DISPLAY,

		/// <summary>
		/// <para>Value:</para>
		/// <para>3</para>
		/// <para>Script (or hand written) typeface classification.</para>
		/// </summary>
		DWRITE_PANOSE_FAMILY_SCRIPT,

		/// <summary>
		/// <para>Value:</para>
		/// <para>4</para>
		/// <para>Decorative typeface classification.</para>
		/// </summary>
		DWRITE_PANOSE_FAMILY_DECORATIVE,

		/// <summary>
		/// <para>Value:</para>
		/// <para>5</para>
		/// <para>Symbol typeface classification.</para>
		/// </summary>
		DWRITE_PANOSE_FAMILY_SYMBOL,

		/// <summary>Pictorial (or symbol) typeface classification.</summary>
		DWRITE_PANOSE_FAMILY_PICTORIAL,
	}

	/// <summary>The <b>DWRITE_PANOSE_FILL</b> enumeration contains values that specify the type of fill and line treatment.</summary>
	// https://learn.microsoft.com/en-us/windows/win32/api/dwrite_1/ne-dwrite_1-dwrite_panose_fill typedef enum DWRITE_PANOSE_FILL {
	// DWRITE_PANOSE_FILL_ANY = 0, DWRITE_PANOSE_FILL_NO_FIT = 1, DWRITE_PANOSE_FILL_STANDARD_SOLID_FILL = 2, DWRITE_PANOSE_FILL_NO_FILL =
	// 3, DWRITE_PANOSE_FILL_PATTERNED_FILL = 4, DWRITE_PANOSE_FILL_COMPLEX_FILL = 5, DWRITE_PANOSE_FILL_SHAPED_FILL = 6,
	// DWRITE_PANOSE_FILL_DRAWN_DISTRESSED = 7 } ;
	[PInvokeData("dwrite_1.h", MSDNShortId = "NE:dwrite_1.DWRITE_PANOSE_FILL")]
	public enum DWRITE_PANOSE_FILL
	{
		/// <summary>
		/// <para>Value:</para>
		/// <para>0</para>
		/// <para>Any fill.</para>
		/// </summary>
		DWRITE_PANOSE_FILL_ANY,

		/// <summary>
		/// <para>Value:</para>
		/// <para>1</para>
		/// <para>No fit for fill.</para>
		/// </summary>
		DWRITE_PANOSE_FILL_NO_FIT,

		/// <summary>
		/// <para>Value:</para>
		/// <para>2</para>
		/// <para>The fill is the standard solid fill.</para>
		/// </summary>
		DWRITE_PANOSE_FILL_STANDARD_SOLID_FILL,

		/// <summary>
		/// <para>Value:</para>
		/// <para>3</para>
		/// <para>No fill.</para>
		/// </summary>
		DWRITE_PANOSE_FILL_NO_FILL,

		/// <summary>
		/// <para>Value:</para>
		/// <para>4</para>
		/// <para>The fill is patterned fill.</para>
		/// </summary>
		DWRITE_PANOSE_FILL_PATTERNED_FILL,

		/// <summary>
		/// <para>Value:</para>
		/// <para>5</para>
		/// <para>The fill is complex fill.</para>
		/// </summary>
		DWRITE_PANOSE_FILL_COMPLEX_FILL,

		/// <summary>
		/// <para>Value:</para>
		/// <para>6</para>
		/// <para>The fill is shaped fill.</para>
		/// </summary>
		DWRITE_PANOSE_FILL_SHAPED_FILL,

		/// <summary>
		/// <para>Value:</para>
		/// <para>7</para>
		/// <para>The fill is drawn distressed.</para>
		/// </summary>
		DWRITE_PANOSE_FILL_DRAWN_DISTRESSED,
	}

	/// <summary>
	/// The <b>DWRITE_PANOSE_FINIALS</b> enumeration contains values that specify how character ends and minuscule ascenders are treated.
	/// </summary>
	// https://learn.microsoft.com/en-us/windows/win32/api/dwrite_1/ne-dwrite_1-dwrite_panose_finials typedef enum DWRITE_PANOSE_FINIALS {
	// DWRITE_PANOSE_FINIALS_ANY = 0, DWRITE_PANOSE_FINIALS_NO_FIT = 1, DWRITE_PANOSE_FINIALS_NONE_NO_LOOPS = 2,
	// DWRITE_PANOSE_FINIALS_NONE_CLOSED_LOOPS = 3, DWRITE_PANOSE_FINIALS_NONE_OPEN_LOOPS = 4, DWRITE_PANOSE_FINIALS_SHARP_NO_LOOPS = 5,
	// DWRITE_PANOSE_FINIALS_SHARP_CLOSED_LOOPS = 6, DWRITE_PANOSE_FINIALS_SHARP_OPEN_LOOPS = 7, DWRITE_PANOSE_FINIALS_TAPERED_NO_LOOPS = 8,
	// DWRITE_PANOSE_FINIALS_TAPERED_CLOSED_LOOPS = 9, DWRITE_PANOSE_FINIALS_TAPERED_OPEN_LOOPS = 10, DWRITE_PANOSE_FINIALS_ROUND_NO_LOOPS =
	// 11, DWRITE_PANOSE_FINIALS_ROUND_CLOSED_LOOPS = 12, DWRITE_PANOSE_FINIALS_ROUND_OPEN_LOOPS = 13 } ;
	[PInvokeData("dwrite_1.h", MSDNShortId = "NE:dwrite_1.DWRITE_PANOSE_FINIALS")]
	public enum DWRITE_PANOSE_FINIALS
	{
		/// <summary>
		/// <para>Value:</para>
		/// <para>0</para>
		/// <para>Any finials.</para>
		/// </summary>
		DWRITE_PANOSE_FINIALS_ANY,

		/// <summary>
		/// <para>Value:</para>
		/// <para>1</para>
		/// <para>No fit for finials.</para>
		/// </summary>
		DWRITE_PANOSE_FINIALS_NO_FIT,

		/// <summary>
		/// <para>Value:</para>
		/// <para>2</para>
		/// <para>No loops.</para>
		/// </summary>
		DWRITE_PANOSE_FINIALS_NONE_NO_LOOPS,

		/// <summary>
		/// <para>Value:</para>
		/// <para>3</para>
		/// <para>No closed loops.</para>
		/// </summary>
		DWRITE_PANOSE_FINIALS_NONE_CLOSED_LOOPS,

		/// <summary>
		/// <para>Value:</para>
		/// <para>4</para>
		/// <para>No open loops.</para>
		/// </summary>
		DWRITE_PANOSE_FINIALS_NONE_OPEN_LOOPS,

		/// <summary>
		/// <para>Value:</para>
		/// <para>5</para>
		/// <para>Sharp with no loops.</para>
		/// </summary>
		DWRITE_PANOSE_FINIALS_SHARP_NO_LOOPS,

		/// <summary>
		/// <para>Value:</para>
		/// <para>6</para>
		/// <para>Sharp with closed loops.</para>
		/// </summary>
		DWRITE_PANOSE_FINIALS_SHARP_CLOSED_LOOPS,

		/// <summary>
		/// <para>Value:</para>
		/// <para>7</para>
		/// <para>Sharp with open loops.</para>
		/// </summary>
		DWRITE_PANOSE_FINIALS_SHARP_OPEN_LOOPS,

		/// <summary>
		/// <para>Value:</para>
		/// <para>8</para>
		/// <para>Tapered with no loops.</para>
		/// </summary>
		DWRITE_PANOSE_FINIALS_TAPERED_NO_LOOPS,

		/// <summary>
		/// <para>Value:</para>
		/// <para>9</para>
		/// <para>Tapered with closed loops.</para>
		/// </summary>
		DWRITE_PANOSE_FINIALS_TAPERED_CLOSED_LOOPS,

		/// <summary>
		/// <para>Value:</para>
		/// <para>10</para>
		/// <para>Tapered with open loops.</para>
		/// </summary>
		DWRITE_PANOSE_FINIALS_TAPERED_OPEN_LOOPS,

		/// <summary>
		/// <para>Value:</para>
		/// <para>11</para>
		/// <para>Round with no loops.</para>
		/// </summary>
		DWRITE_PANOSE_FINIALS_ROUND_NO_LOOPS,

		/// <summary>
		/// <para>Value:</para>
		/// <para>12</para>
		/// <para>Round with closed loops.</para>
		/// </summary>
		DWRITE_PANOSE_FINIALS_ROUND_CLOSED_LOOPS,

		/// <summary>
		/// <para>Value:</para>
		/// <para>13</para>
		/// <para>Round with open loops.</para>
		/// </summary>
		DWRITE_PANOSE_FINIALS_ROUND_OPEN_LOOPS,
	}

	/// <summary>The <b>DWRITE_PANOSE_LETTERFORM</b> enumeration contains values that specify the roundness of letterform for text.</summary>
	// https://learn.microsoft.com/en-us/windows/win32/api/dwrite_1/ne-dwrite_1-dwrite_panose_letterform typedef enum
	// DWRITE_PANOSE_LETTERFORM { DWRITE_PANOSE_LETTERFORM_ANY = 0, DWRITE_PANOSE_LETTERFORM_NO_FIT = 1,
	// DWRITE_PANOSE_LETTERFORM_NORMAL_CONTACT = 2, DWRITE_PANOSE_LETTERFORM_NORMAL_WEIGHTED = 3, DWRITE_PANOSE_LETTERFORM_NORMAL_BOXED = 4,
	// DWRITE_PANOSE_LETTERFORM_NORMAL_FLATTENED = 5, DWRITE_PANOSE_LETTERFORM_NORMAL_ROUNDED = 6,
	// DWRITE_PANOSE_LETTERFORM_NORMAL_OFF_CENTER = 7, DWRITE_PANOSE_LETTERFORM_NORMAL_SQUARE = 8, DWRITE_PANOSE_LETTERFORM_OBLIQUE_CONTACT
	// = 9, DWRITE_PANOSE_LETTERFORM_OBLIQUE_WEIGHTED = 10, DWRITE_PANOSE_LETTERFORM_OBLIQUE_BOXED = 11,
	// DWRITE_PANOSE_LETTERFORM_OBLIQUE_FLATTENED = 12, DWRITE_PANOSE_LETTERFORM_OBLIQUE_ROUNDED = 13,
	// DWRITE_PANOSE_LETTERFORM_OBLIQUE_OFF_CENTER = 14, DWRITE_PANOSE_LETTERFORM_OBLIQUE_SQUARE = 15 } ;
	[PInvokeData("dwrite_1.h", MSDNShortId = "NE:dwrite_1.DWRITE_PANOSE_LETTERFORM")]
	public enum DWRITE_PANOSE_LETTERFORM
	{
		/// <summary>
		/// <para>Value:</para>
		/// <para>0</para>
		/// <para>Any letterform.</para>
		/// </summary>
		DWRITE_PANOSE_LETTERFORM_ANY,

		/// <summary>
		/// <para>Value:</para>
		/// <para>1</para>
		/// <para>No fit letterform.</para>
		/// </summary>
		DWRITE_PANOSE_LETTERFORM_NO_FIT,

		/// <summary>
		/// <para>Value:</para>
		/// <para>2</para>
		/// <para>Normal contact letterform.</para>
		/// </summary>
		DWRITE_PANOSE_LETTERFORM_NORMAL_CONTACT,

		/// <summary>
		/// <para>Value:</para>
		/// <para>3</para>
		/// <para>Normal weighted letterform.</para>
		/// </summary>
		DWRITE_PANOSE_LETTERFORM_NORMAL_WEIGHTED,

		/// <summary>
		/// <para>Value:</para>
		/// <para>4</para>
		/// <para>Normal boxed letterform.</para>
		/// </summary>
		DWRITE_PANOSE_LETTERFORM_NORMAL_BOXED,

		/// <summary>
		/// <para>Value:</para>
		/// <para>5</para>
		/// <para>Normal flattened letterform.</para>
		/// </summary>
		DWRITE_PANOSE_LETTERFORM_NORMAL_FLATTENED,

		/// <summary>
		/// <para>Value:</para>
		/// <para>6</para>
		/// <para>Normal rounded letterform.</para>
		/// </summary>
		DWRITE_PANOSE_LETTERFORM_NORMAL_ROUNDED,

		/// <summary>
		/// <para>Value:</para>
		/// <para>7</para>
		/// <para>Normal off-center letterform.</para>
		/// </summary>
		DWRITE_PANOSE_LETTERFORM_NORMAL_OFF_CENTER,

		/// <summary>
		/// <para>Value:</para>
		/// <para>8</para>
		/// <para>Normal square letterform.</para>
		/// </summary>
		DWRITE_PANOSE_LETTERFORM_NORMAL_SQUARE,

		/// <summary>
		/// <para>Value:</para>
		/// <para>9</para>
		/// <para>Oblique contact letterform.</para>
		/// </summary>
		DWRITE_PANOSE_LETTERFORM_OBLIQUE_CONTACT,

		/// <summary>
		/// <para>Value:</para>
		/// <para>10</para>
		/// <para>Oblique weighted letterform.</para>
		/// </summary>
		DWRITE_PANOSE_LETTERFORM_OBLIQUE_WEIGHTED,

		/// <summary>
		/// <para>Value:</para>
		/// <para>11</para>
		/// <para>Oblique boxed letterform.</para>
		/// </summary>
		DWRITE_PANOSE_LETTERFORM_OBLIQUE_BOXED,

		/// <summary>
		/// <para>Value:</para>
		/// <para>12</para>
		/// <para>Oblique flattened letterform.</para>
		/// </summary>
		DWRITE_PANOSE_LETTERFORM_OBLIQUE_FLATTENED,

		/// <summary>
		/// <para>Value:</para>
		/// <para>13</para>
		/// <para>Oblique rounded letterform.</para>
		/// </summary>
		DWRITE_PANOSE_LETTERFORM_OBLIQUE_ROUNDED,

		/// <summary>
		/// <para>Value:</para>
		/// <para>14</para>
		/// <para>Oblique off-center letterform.</para>
		/// </summary>
		DWRITE_PANOSE_LETTERFORM_OBLIQUE_OFF_CENTER,

		/// <summary>
		/// <para>Value:</para>
		/// <para>15</para>
		/// <para>Oblique square letterform.</para>
		/// </summary>
		DWRITE_PANOSE_LETTERFORM_OBLIQUE_SQUARE,
	}

	/// <summary>
	/// The <b>DWRITE_PANOSE_LINING</b> enumeration contains values that specify the handling of the outline for the decorative typeface.
	/// </summary>
	// https://learn.microsoft.com/en-us/windows/win32/api/dwrite_1/ne-dwrite_1-dwrite_panose_lining typedef enum DWRITE_PANOSE_LINING {
	// DWRITE_PANOSE_LINING_ANY = 0, DWRITE_PANOSE_LINING_NO_FIT = 1, DWRITE_PANOSE_LINING_NONE = 2, DWRITE_PANOSE_LINING_INLINE = 3,
	// DWRITE_PANOSE_LINING_OUTLINE = 4, DWRITE_PANOSE_LINING_ENGRAVED = 5, DWRITE_PANOSE_LINING_SHADOW = 6, DWRITE_PANOSE_LINING_RELIEF =
	// 7, DWRITE_PANOSE_LINING_BACKDROP = 8 } ;
	[PInvokeData("dwrite_1.h", MSDNShortId = "NE:dwrite_1.DWRITE_PANOSE_LINING")]
	public enum DWRITE_PANOSE_LINING
	{
		/// <summary>
		/// <para>Value:</para>
		/// <para>0</para>
		/// <para>Any lining.</para>
		/// </summary>
		DWRITE_PANOSE_LINING_ANY,

		/// <summary>
		/// <para>Value:</para>
		/// <para>1</para>
		/// <para>No fit for lining.</para>
		/// </summary>
		DWRITE_PANOSE_LINING_NO_FIT,

		/// <summary>
		/// <para>Value:</para>
		/// <para>2</para>
		/// <para>No lining.</para>
		/// </summary>
		DWRITE_PANOSE_LINING_NONE,

		/// <summary>
		/// <para>Value:</para>
		/// <para>3</para>
		/// <para>The lining is inline.</para>
		/// </summary>
		DWRITE_PANOSE_LINING_INLINE,

		/// <summary>
		/// <para>Value:</para>
		/// <para>4</para>
		/// <para>The lining is outline.</para>
		/// </summary>
		DWRITE_PANOSE_LINING_OUTLINE,

		/// <summary>
		/// <para>Value:</para>
		/// <para>5</para>
		/// <para>The lining is engraved.</para>
		/// </summary>
		DWRITE_PANOSE_LINING_ENGRAVED,

		/// <summary>
		/// <para>Value:</para>
		/// <para>6</para>
		/// <para>The lining is shadowed.</para>
		/// </summary>
		DWRITE_PANOSE_LINING_SHADOW,

		/// <summary>
		/// <para>Value:</para>
		/// <para>7</para>
		/// <para>The lining is relief.</para>
		/// </summary>
		DWRITE_PANOSE_LINING_RELIEF,

		/// <summary>
		/// <para>Value:</para>
		/// <para>8</para>
		/// <para>The lining is backdrop.</para>
		/// </summary>
		DWRITE_PANOSE_LINING_BACKDROP,
	}

	/// <summary>
	/// The <b>DWRITE_PANOSE_MIDLINE</b> enumeration contains values that specify info about the placement of midline across uppercase
	/// characters and the treatment of diagonal stem apexes.
	/// </summary>
	// https://learn.microsoft.com/en-us/windows/win32/api/dwrite_1/ne-dwrite_1-dwrite_panose_midline typedef enum DWRITE_PANOSE_MIDLINE {
	// DWRITE_PANOSE_MIDLINE_ANY = 0, DWRITE_PANOSE_MIDLINE_NO_FIT = 1, DWRITE_PANOSE_MIDLINE_STANDARD_TRIMMED = 2,
	// DWRITE_PANOSE_MIDLINE_STANDARD_POINTED = 3, DWRITE_PANOSE_MIDLINE_STANDARD_SERIFED = 4, DWRITE_PANOSE_MIDLINE_HIGH_TRIMMED = 5,
	// DWRITE_PANOSE_MIDLINE_HIGH_POINTED = 6, DWRITE_PANOSE_MIDLINE_HIGH_SERIFED = 7, DWRITE_PANOSE_MIDLINE_CONSTANT_TRIMMED = 8,
	// DWRITE_PANOSE_MIDLINE_CONSTANT_POINTED = 9, DWRITE_PANOSE_MIDLINE_CONSTANT_SERIFED = 10, DWRITE_PANOSE_MIDLINE_LOW_TRIMMED = 11,
	// DWRITE_PANOSE_MIDLINE_LOW_POINTED = 12, DWRITE_PANOSE_MIDLINE_LOW_SERIFED = 13 } ;
	[PInvokeData("dwrite_1.h", MSDNShortId = "NE:dwrite_1.DWRITE_PANOSE_MIDLINE")]
	public enum DWRITE_PANOSE_MIDLINE
	{
		/// <summary>
		/// <para>Value:</para>
		/// <para>0</para>
		/// <para>Any midline.</para>
		/// </summary>
		DWRITE_PANOSE_MIDLINE_ANY,

		/// <summary>
		/// <para>Value:</para>
		/// <para>1</para>
		/// <para>No fit midline.</para>
		/// </summary>
		DWRITE_PANOSE_MIDLINE_NO_FIT,

		/// <summary>
		/// <para>Value:</para>
		/// <para>2</para>
		/// <para>Standard trimmed midline.</para>
		/// </summary>
		DWRITE_PANOSE_MIDLINE_STANDARD_TRIMMED,

		/// <summary>
		/// <para>Value:</para>
		/// <para>3</para>
		/// <para>Standard pointed midline.</para>
		/// </summary>
		DWRITE_PANOSE_MIDLINE_STANDARD_POINTED,

		/// <summary>
		/// <para>Value:</para>
		/// <para>4</para>
		/// <para>Standard serifed midline.</para>
		/// </summary>
		DWRITE_PANOSE_MIDLINE_STANDARD_SERIFED,

		/// <summary>
		/// <para>Value:</para>
		/// <para>5</para>
		/// <para>High trimmed midline.</para>
		/// </summary>
		DWRITE_PANOSE_MIDLINE_HIGH_TRIMMED,

		/// <summary>
		/// <para>Value:</para>
		/// <para>6</para>
		/// <para>High pointed midline.</para>
		/// </summary>
		DWRITE_PANOSE_MIDLINE_HIGH_POINTED,

		/// <summary>
		/// <para>Value:</para>
		/// <para>7</para>
		/// <para>High serifed midline.</para>
		/// </summary>
		DWRITE_PANOSE_MIDLINE_HIGH_SERIFED,

		/// <summary>
		/// <para>Value:</para>
		/// <para>8</para>
		/// <para>Constant trimmed midline.</para>
		/// </summary>
		DWRITE_PANOSE_MIDLINE_CONSTANT_TRIMMED,

		/// <summary>
		/// <para>Value:</para>
		/// <para>9</para>
		/// <para>Constant pointed midline.</para>
		/// </summary>
		DWRITE_PANOSE_MIDLINE_CONSTANT_POINTED,

		/// <summary>
		/// <para>Value:</para>
		/// <para>10</para>
		/// <para>Constant serifed midline.</para>
		/// </summary>
		DWRITE_PANOSE_MIDLINE_CONSTANT_SERIFED,

		/// <summary>
		/// <para>Value:</para>
		/// <para>11</para>
		/// <para>Low trimmed midline.</para>
		/// </summary>
		DWRITE_PANOSE_MIDLINE_LOW_TRIMMED,

		/// <summary>
		/// <para>Value:</para>
		/// <para>12</para>
		/// <para>Low pointed midline.</para>
		/// </summary>
		DWRITE_PANOSE_MIDLINE_LOW_POINTED,

		/// <summary>
		/// <para>Value:</para>
		/// <para>13</para>
		/// <para>Low serifed midline.</para>
		/// </summary>
		DWRITE_PANOSE_MIDLINE_LOW_SERIFED,
	}

	/// <summary>
	/// The <b>DWRITE_PANOSE_PROPORTION</b> enumeration contains values that specify the proportion of the glyph shape by considering
	/// additional detail to standard characters.
	/// </summary>
	// https://learn.microsoft.com/en-us/windows/win32/api/dwrite_1/ne-dwrite_1-dwrite_panose_proportion typedef enum
	// DWRITE_PANOSE_PROPORTION { DWRITE_PANOSE_PROPORTION_ANY = 0, DWRITE_PANOSE_PROPORTION_NO_FIT = 1, DWRITE_PANOSE_PROPORTION_OLD_STYLE
	// = 2, DWRITE_PANOSE_PROPORTION_MODERN = 3, DWRITE_PANOSE_PROPORTION_EVEN_WIDTH = 4, DWRITE_PANOSE_PROPORTION_EXPANDED = 5,
	// DWRITE_PANOSE_PROPORTION_CONDENSED = 6, DWRITE_PANOSE_PROPORTION_VERY_EXPANDED = 7, DWRITE_PANOSE_PROPORTION_VERY_CONDENSED = 8,
	// DWRITE_PANOSE_PROPORTION_MONOSPACED = 9 } ;
	[PInvokeData("dwrite_1.h", MSDNShortId = "NE:dwrite_1.DWRITE_PANOSE_PROPORTION")]
	public enum DWRITE_PANOSE_PROPORTION
	{
		/// <summary>
		/// <para>Value:</para>
		/// <para>0</para>
		/// <para>Any proportion for the text.</para>
		/// </summary>
		DWRITE_PANOSE_PROPORTION_ANY,

		/// <summary>
		/// <para>Value:</para>
		/// <para>1</para>
		/// <para>No fit proportion for the text.</para>
		/// </summary>
		DWRITE_PANOSE_PROPORTION_NO_FIT,

		/// <summary>
		/// <para>Value:</para>
		/// <para>2</para>
		/// <para>Old style proportion for the text.</para>
		/// </summary>
		DWRITE_PANOSE_PROPORTION_OLD_STYLE,

		/// <summary>
		/// <para>Value:</para>
		/// <para>3</para>
		/// <para>Modern proportion for the text.</para>
		/// </summary>
		DWRITE_PANOSE_PROPORTION_MODERN,

		/// <summary>
		/// <para>Value:</para>
		/// <para>4</para>
		/// <para>Extra width proportion for the text.</para>
		/// </summary>
		DWRITE_PANOSE_PROPORTION_EVEN_WIDTH,

		/// <summary>
		/// <para>Value:</para>
		/// <para>5</para>
		/// <para>Expanded proportion for the text.</para>
		/// </summary>
		DWRITE_PANOSE_PROPORTION_EXPANDED,

		/// <summary>
		/// <para>Value:</para>
		/// <para>6</para>
		/// <para>Condensed proportion for the text.</para>
		/// </summary>
		DWRITE_PANOSE_PROPORTION_CONDENSED,

		/// <summary>
		/// <para>Value:</para>
		/// <para>7</para>
		/// <para>Very expanded proportion for the text.</para>
		/// </summary>
		DWRITE_PANOSE_PROPORTION_VERY_EXPANDED,

		/// <summary>
		/// <para>Value:</para>
		/// <para>8</para>
		/// <para>Very condensed proportion for the text.</para>
		/// </summary>
		DWRITE_PANOSE_PROPORTION_VERY_CONDENSED,

		/// <summary>
		/// <para>Value:</para>
		/// <para>9</para>
		/// <para>Monospaced proportion for the text.</para>
		/// </summary>
		DWRITE_PANOSE_PROPORTION_MONOSPACED,
	}

	/// <summary>
	/// The <b>DWRITE_PANOSE_SCRIPT_FORM</b> enumeration contains values that specify the general look of the character face, with
	/// consideration of its slope and tails.
	/// </summary>
	// https://learn.microsoft.com/en-us/windows/win32/api/dwrite_1/ne-dwrite_1-dwrite_panose_script_form typedef enum
	// DWRITE_PANOSE_SCRIPT_FORM { DWRITE_PANOSE_SCRIPT_FORM_ANY = 0, DWRITE_PANOSE_SCRIPT_FORM_NO_FIT = 1,
	// DWRITE_PANOSE_SCRIPT_FORM_UPRIGHT_NO_WRAPPING = 2, DWRITE_PANOSE_SCRIPT_FORM_UPRIGHT_SOME_WRAPPING = 3,
	// DWRITE_PANOSE_SCRIPT_FORM_UPRIGHT_MORE_WRAPPING = 4, DWRITE_PANOSE_SCRIPT_FORM_UPRIGHT_EXTREME_WRAPPING = 5,
	// DWRITE_PANOSE_SCRIPT_FORM_OBLIQUE_NO_WRAPPING = 6, DWRITE_PANOSE_SCRIPT_FORM_OBLIQUE_SOME_WRAPPING = 7,
	// DWRITE_PANOSE_SCRIPT_FORM_OBLIQUE_MORE_WRAPPING = 8, DWRITE_PANOSE_SCRIPT_FORM_OBLIQUE_EXTREME_WRAPPING = 9,
	// DWRITE_PANOSE_SCRIPT_FORM_EXAGGERATED_NO_WRAPPING = 10, DWRITE_PANOSE_SCRIPT_FORM_EXAGGERATED_SOME_WRAPPING = 11,
	// DWRITE_PANOSE_SCRIPT_FORM_EXAGGERATED_MORE_WRAPPING = 12, DWRITE_PANOSE_SCRIPT_FORM_EXAGGERATED_EXTREME_WRAPPING = 13 } ;
	[PInvokeData("dwrite_1.h", MSDNShortId = "NE:dwrite_1.DWRITE_PANOSE_SCRIPT_FORM")]
	public enum DWRITE_PANOSE_SCRIPT_FORM
	{
		/// <summary>
		/// <para>Value:</para>
		/// <para>0</para>
		/// <para>Any script form.</para>
		/// </summary>
		DWRITE_PANOSE_SCRIPT_FORM_ANY,

		/// <summary>
		/// <para>Value:</para>
		/// <para>1</para>
		/// <para>No fit for script form.</para>
		/// </summary>
		DWRITE_PANOSE_SCRIPT_FORM_NO_FIT,

		/// <summary>
		/// <para>Value:</para>
		/// <para>2</para>
		/// <para>Script form is upright with no wrapping.</para>
		/// </summary>
		DWRITE_PANOSE_SCRIPT_FORM_UPRIGHT_NO_WRAPPING,

		/// <summary>
		/// <para>Value:</para>
		/// <para>3</para>
		/// <para>Script form is upright with some wrapping.</para>
		/// </summary>
		DWRITE_PANOSE_SCRIPT_FORM_UPRIGHT_SOME_WRAPPING,

		/// <summary>
		/// <para>Value:</para>
		/// <para>4</para>
		/// <para>Script form is upright with more wrapping.</para>
		/// </summary>
		DWRITE_PANOSE_SCRIPT_FORM_UPRIGHT_MORE_WRAPPING,

		/// <summary>
		/// <para>Value:</para>
		/// <para>5</para>
		/// <para>Script form is upright with extreme wrapping.</para>
		/// </summary>
		DWRITE_PANOSE_SCRIPT_FORM_UPRIGHT_EXTREME_WRAPPING,

		/// <summary>
		/// <para>Value:</para>
		/// <para>6</para>
		/// <para>Script form is oblique with no wrapping.</para>
		/// </summary>
		DWRITE_PANOSE_SCRIPT_FORM_OBLIQUE_NO_WRAPPING,

		/// <summary>
		/// <para>Value:</para>
		/// <para>7</para>
		/// <para>Script form is oblique with some wrapping.</para>
		/// </summary>
		DWRITE_PANOSE_SCRIPT_FORM_OBLIQUE_SOME_WRAPPING,

		/// <summary>
		/// <para>Value:</para>
		/// <para>8</para>
		/// <para>Script form is oblique with more wrapping.</para>
		/// </summary>
		DWRITE_PANOSE_SCRIPT_FORM_OBLIQUE_MORE_WRAPPING,

		/// <summary>
		/// <para>Value:</para>
		/// <para>9</para>
		/// <para>Script form is oblique with extreme wrapping.</para>
		/// </summary>
		DWRITE_PANOSE_SCRIPT_FORM_OBLIQUE_EXTREME_WRAPPING,

		/// <summary>
		/// <para>Value:</para>
		/// <para>10</para>
		/// <para>Script form is exaggerated with no wrapping.</para>
		/// </summary>
		DWRITE_PANOSE_SCRIPT_FORM_EXAGGERATED_NO_WRAPPING,

		/// <summary>
		/// <para>Value:</para>
		/// <para>11</para>
		/// <para>Script form is exaggerated with some wrapping.</para>
		/// </summary>
		DWRITE_PANOSE_SCRIPT_FORM_EXAGGERATED_SOME_WRAPPING,

		/// <summary>
		/// <para>Value:</para>
		/// <para>12</para>
		/// <para>Script form is exaggerated with more wrapping.</para>
		/// </summary>
		DWRITE_PANOSE_SCRIPT_FORM_EXAGGERATED_MORE_WRAPPING,

		/// <summary>
		/// <para>Value:</para>
		/// <para>13</para>
		/// <para>Script form is exaggerated with extreme wrapping.</para>
		/// </summary>
		DWRITE_PANOSE_SCRIPT_FORM_EXAGGERATED_EXTREME_WRAPPING,
	}

	/// <summary>The <b>DWRITE_PANOSE_SCRIPT_TOPOLOGY</b> enumeration contains values that specify the topology of letterforms.</summary>
	// https://learn.microsoft.com/en-us/windows/win32/api/dwrite_1/ne-dwrite_1-dwrite_panose_script_topology typedef enum
	// DWRITE_PANOSE_SCRIPT_TOPOLOGY { DWRITE_PANOSE_SCRIPT_TOPOLOGY_ANY = 0, DWRITE_PANOSE_SCRIPT_TOPOLOGY_NO_FIT = 1,
	// DWRITE_PANOSE_SCRIPT_TOPOLOGY_ROMAN_DISCONNECTED = 2, DWRITE_PANOSE_SCRIPT_TOPOLOGY_ROMAN_TRAILING = 3,
	// DWRITE_PANOSE_SCRIPT_TOPOLOGY_ROMAN_CONNECTED = 4, DWRITE_PANOSE_SCRIPT_TOPOLOGY_CURSIVE_DISCONNECTED = 5,
	// DWRITE_PANOSE_SCRIPT_TOPOLOGY_CURSIVE_TRAILING = 6, DWRITE_PANOSE_SCRIPT_TOPOLOGY_CURSIVE_CONNECTED = 7,
	// DWRITE_PANOSE_SCRIPT_TOPOLOGY_BLACKLETTER_DISCONNECTED = 8, DWRITE_PANOSE_SCRIPT_TOPOLOGY_BLACKLETTER_TRAILING = 9,
	// DWRITE_PANOSE_SCRIPT_TOPOLOGY_BLACKLETTER_CONNECTED = 10 } ;
	[PInvokeData("dwrite_1.h", MSDNShortId = "NE:dwrite_1.DWRITE_PANOSE_SCRIPT_TOPOLOGY")]
	public enum DWRITE_PANOSE_SCRIPT_TOPOLOGY
	{
		/// <summary>
		/// <para>Value:</para>
		/// <para>0</para>
		/// <para>Any script topology.</para>
		/// </summary>
		DWRITE_PANOSE_SCRIPT_TOPOLOGY_ANY,

		/// <summary>
		/// <para>Value:</para>
		/// <para>1</para>
		/// <para>No fit for script topology.</para>
		/// </summary>
		DWRITE_PANOSE_SCRIPT_TOPOLOGY_NO_FIT,

		/// <summary>
		/// <para>Value:</para>
		/// <para>2</para>
		/// <para>Script topology is roman disconnected.</para>
		/// </summary>
		DWRITE_PANOSE_SCRIPT_TOPOLOGY_ROMAN_DISCONNECTED,

		/// <summary>
		/// <para>Value:</para>
		/// <para>3</para>
		/// <para>Script topology is roman trailing.</para>
		/// </summary>
		DWRITE_PANOSE_SCRIPT_TOPOLOGY_ROMAN_TRAILING,

		/// <summary>
		/// <para>Value:</para>
		/// <para>4</para>
		/// <para>Script topology is roman connected.</para>
		/// </summary>
		DWRITE_PANOSE_SCRIPT_TOPOLOGY_ROMAN_CONNECTED,

		/// <summary>
		/// <para>Value:</para>
		/// <para>5</para>
		/// <para>Script topology is cursive disconnected.</para>
		/// </summary>
		DWRITE_PANOSE_SCRIPT_TOPOLOGY_CURSIVE_DISCONNECTED,

		/// <summary>
		/// <para>Value:</para>
		/// <para>6</para>
		/// <para>Script topology is cursive trailing.</para>
		/// </summary>
		DWRITE_PANOSE_SCRIPT_TOPOLOGY_CURSIVE_TRAILING,

		/// <summary>
		/// <para>Value:</para>
		/// <para>7</para>
		/// <para>Script topology is cursive connected.</para>
		/// </summary>
		DWRITE_PANOSE_SCRIPT_TOPOLOGY_CURSIVE_CONNECTED,

		/// <summary>
		/// <para>Value:</para>
		/// <para>8</para>
		/// <para>Script topology is black-letter disconnected.</para>
		/// </summary>
		DWRITE_PANOSE_SCRIPT_TOPOLOGY_BLACKLETTER_DISCONNECTED,

		/// <summary>
		/// <para>Value:</para>
		/// <para>9</para>
		/// <para>Script topology is black-letter trailing.</para>
		/// </summary>
		DWRITE_PANOSE_SCRIPT_TOPOLOGY_BLACKLETTER_TRAILING,

		/// <summary>
		/// <para>Value:</para>
		/// <para>10</para>
		/// <para>Script topology is black-letter connected.</para>
		/// </summary>
		DWRITE_PANOSE_SCRIPT_TOPOLOGY_BLACKLETTER_CONNECTED,
	}

	/// <summary>The <b>DWRITE_PANOSE_SERIF_STYLE</b> enumeration contains values that specify the appearance of the serif text.</summary>
	// https://learn.microsoft.com/en-us/windows/win32/api/dwrite_1/ne-dwrite_1-dwrite_panose_serif_style typedef enum
	// DWRITE_PANOSE_SERIF_STYLE { DWRITE_PANOSE_SERIF_STYLE_ANY = 0, DWRITE_PANOSE_SERIF_STYLE_NO_FIT = 1, DWRITE_PANOSE_SERIF_STYLE_COVE =
	// 2, DWRITE_PANOSE_SERIF_STYLE_OBTUSE_COVE = 3, DWRITE_PANOSE_SERIF_STYLE_SQUARE_COVE = 4, DWRITE_PANOSE_SERIF_STYLE_OBTUSE_SQUARE_COVE
	// = 5, DWRITE_PANOSE_SERIF_STYLE_SQUARE = 6, DWRITE_PANOSE_SERIF_STYLE_THIN = 7, DWRITE_PANOSE_SERIF_STYLE_OVAL = 8,
	// DWRITE_PANOSE_SERIF_STYLE_EXAGGERATED = 9, DWRITE_PANOSE_SERIF_STYLE_TRIANGLE = 10, DWRITE_PANOSE_SERIF_STYLE_NORMAL_SANS = 11,
	// DWRITE_PANOSE_SERIF_STYLE_OBTUSE_SANS = 12, DWRITE_PANOSE_SERIF_STYLE_PERPENDICULAR_SANS = 13, DWRITE_PANOSE_SERIF_STYLE_FLARED = 14,
	// DWRITE_PANOSE_SERIF_STYLE_ROUNDED = 15, DWRITE_PANOSE_SERIF_STYLE_SCRIPT = 16, DWRITE_PANOSE_SERIF_STYLE_PERP_SANS,
	// DWRITE_PANOSE_SERIF_STYLE_BONE } ;
	[PInvokeData("dwrite_1.h", MSDNShortId = "NE:dwrite_1.DWRITE_PANOSE_SERIF_STYLE")]
	public enum DWRITE_PANOSE_SERIF_STYLE
	{
		/// <summary>
		/// <para>Value:</para>
		/// <para>0</para>
		/// <para>Any appearance of the serif text.</para>
		/// </summary>
		DWRITE_PANOSE_SERIF_STYLE_ANY,

		/// <summary>
		/// <para>Value:</para>
		/// <para>1</para>
		/// <para>No fit appearance of the serif text.</para>
		/// </summary>
		DWRITE_PANOSE_SERIF_STYLE_NO_FIT,

		/// <summary>
		/// <para>Value:</para>
		/// <para>2</para>
		/// <para>Cove appearance of the serif text.</para>
		/// </summary>
		DWRITE_PANOSE_SERIF_STYLE_COVE,

		/// <summary>
		/// <para>Value:</para>
		/// <para>3</para>
		/// <para>Obtuse cove appearance of the serif text.</para>
		/// </summary>
		DWRITE_PANOSE_SERIF_STYLE_OBTUSE_COVE,

		/// <summary>
		/// <para>Value:</para>
		/// <para>4</para>
		/// <para>Square cove appearance of the serif text.</para>
		/// </summary>
		DWRITE_PANOSE_SERIF_STYLE_SQUARE_COVE,

		/// <summary>
		/// <para>Value:</para>
		/// <para>5</para>
		/// <para>Obtuse square cove appearance of the serif text.</para>
		/// </summary>
		DWRITE_PANOSE_SERIF_STYLE_OBTUSE_SQUARE_COVE,

		/// <summary>
		/// <para>Value:</para>
		/// <para>6</para>
		/// <para>Square appearance of the serif text.</para>
		/// </summary>
		DWRITE_PANOSE_SERIF_STYLE_SQUARE,

		/// <summary>
		/// <para>Value:</para>
		/// <para>7</para>
		/// <para>Thin appearance of the serif text.</para>
		/// </summary>
		DWRITE_PANOSE_SERIF_STYLE_THIN,

		/// <summary>
		/// <para>Value:</para>
		/// <para>8</para>
		/// <para>Oval appearance of the serif text.</para>
		/// </summary>
		DWRITE_PANOSE_SERIF_STYLE_OVAL,

		/// <summary>
		/// <para>Value:</para>
		/// <para>9</para>
		/// <para>Exaggerated appearance of the serif text.</para>
		/// </summary>
		DWRITE_PANOSE_SERIF_STYLE_EXAGGERATED,

		/// <summary>
		/// <para>Value:</para>
		/// <para>10</para>
		/// <para>Triangle appearance of the serif text.</para>
		/// </summary>
		DWRITE_PANOSE_SERIF_STYLE_TRIANGLE,

		/// <summary>
		/// <para>Value:</para>
		/// <para>11</para>
		/// <para>Normal sans appearance of the serif text.</para>
		/// </summary>
		DWRITE_PANOSE_SERIF_STYLE_NORMAL_SANS,

		/// <summary>
		/// <para>Value:</para>
		/// <para>12</para>
		/// <para>Obtuse sans appearance of the serif text.</para>
		/// </summary>
		DWRITE_PANOSE_SERIF_STYLE_OBTUSE_SANS,

		/// <summary>
		/// <para>Value:</para>
		/// <para>13</para>
		/// <para>Perpendicular sans appearance of the serif text.</para>
		/// </summary>
		DWRITE_PANOSE_SERIF_STYLE_PERPENDICULAR_SANS,

		/// <summary>
		/// <para>Value:</para>
		/// <para>14</para>
		/// <para>Flared appearance of the serif text.</para>
		/// </summary>
		DWRITE_PANOSE_SERIF_STYLE_FLARED,

		/// <summary>
		/// <para>Value:</para>
		/// <para>15</para>
		/// <para>Rounded appearance of the serif text.</para>
		/// </summary>
		DWRITE_PANOSE_SERIF_STYLE_ROUNDED,

		/// <summary>
		/// <para>Value:</para>
		/// <para>16</para>
		/// <para>Script appearance of the serif text.</para>
		/// </summary>
		DWRITE_PANOSE_SERIF_STYLE_SCRIPT,

		/// <summary>Perpendicular sans appearance of the serif text.</summary>
		DWRITE_PANOSE_SERIF_STYLE_PERP_SANS,

		/// <summary>Oval appearance of the serif text.</summary>
		DWRITE_PANOSE_SERIF_STYLE_BONE,
	}

	/// <summary>The <b>DWRITE_PANOSE_SPACING</b> enumeration contains values that specify character spacing (monospace versus proportional).</summary>
	// https://learn.microsoft.com/en-us/windows/win32/api/dwrite_1/ne-dwrite_1-dwrite_panose_spacing typedef enum DWRITE_PANOSE_SPACING {
	// DWRITE_PANOSE_SPACING_ANY = 0, DWRITE_PANOSE_SPACING_NO_FIT = 1, DWRITE_PANOSE_SPACING_PROPORTIONAL_SPACED = 2,
	// DWRITE_PANOSE_SPACING_MONOSPACED = 3 } ;
	[PInvokeData("dwrite_1.h", MSDNShortId = "NE:dwrite_1.DWRITE_PANOSE_SPACING")]
	public enum DWRITE_PANOSE_SPACING
	{
		/// <summary>
		/// <para>Value:</para>
		/// <para>0</para>
		/// <para>Any spacing.</para>
		/// </summary>
		DWRITE_PANOSE_SPACING_ANY,

		/// <summary>
		/// <para>Value:</para>
		/// <para>1</para>
		/// <para>No fit for spacing.</para>
		/// </summary>
		DWRITE_PANOSE_SPACING_NO_FIT,

		/// <summary>
		/// <para>Value:</para>
		/// <para>2</para>
		/// <para>Spacing is proportional.</para>
		/// </summary>
		DWRITE_PANOSE_SPACING_PROPORTIONAL_SPACED,

		/// <summary>
		/// <para>Value:</para>
		/// <para>3</para>
		/// <para>Spacing is monospace.</para>
		/// </summary>
		DWRITE_PANOSE_SPACING_MONOSPACED,
	}

	/// <summary>
	/// The <b>DWRITE_PANOSE_STROKE_VARIATION</b> enumeration contains values that specify the relationship between thin and thick stems of
	/// text characters.
	/// </summary>
	// https://learn.microsoft.com/en-us/windows/win32/api/dwrite_1/ne-dwrite_1-dwrite_panose_stroke_variation typedef enum
	// DWRITE_PANOSE_STROKE_VARIATION { DWRITE_PANOSE_STROKE_VARIATION_ANY = 0, DWRITE_PANOSE_STROKE_VARIATION_NO_FIT = 1,
	// DWRITE_PANOSE_STROKE_VARIATION_NO_VARIATION = 2, DWRITE_PANOSE_STROKE_VARIATION_GRADUAL_DIAGONAL = 3,
	// DWRITE_PANOSE_STROKE_VARIATION_GRADUAL_TRANSITIONAL = 4, DWRITE_PANOSE_STROKE_VARIATION_GRADUAL_VERTICAL = 5,
	// DWRITE_PANOSE_STROKE_VARIATION_GRADUAL_HORIZONTAL = 6, DWRITE_PANOSE_STROKE_VARIATION_RAPID_VERTICAL = 7,
	// DWRITE_PANOSE_STROKE_VARIATION_RAPID_HORIZONTAL = 8, DWRITE_PANOSE_STROKE_VARIATION_INSTANT_VERTICAL = 9,
	// DWRITE_PANOSE_STROKE_VARIATION_INSTANT_HORIZONTAL = 10 } ;
	[PInvokeData("dwrite_1.h", MSDNShortId = "NE:dwrite_1.DWRITE_PANOSE_STROKE_VARIATION")]
	public enum DWRITE_PANOSE_STROKE_VARIATION
	{
		/// <summary>
		/// <para>Value:</para>
		/// <para>0</para>
		/// <para>Any stroke variation for text characters.</para>
		/// </summary>
		DWRITE_PANOSE_STROKE_VARIATION_ANY,

		/// <summary>
		/// <para>Value:</para>
		/// <para>1</para>
		/// <para>No fit stroke variation for text characters.</para>
		/// </summary>
		DWRITE_PANOSE_STROKE_VARIATION_NO_FIT,

		/// <summary>
		/// <para>Value:</para>
		/// <para>2</para>
		/// <para>No stroke variation for text characters.</para>
		/// </summary>
		DWRITE_PANOSE_STROKE_VARIATION_NO_VARIATION,

		/// <summary>
		/// <para>Value:</para>
		/// <para>3</para>
		/// <para>The stroke variation for text characters is gradual diagonal.</para>
		/// </summary>
		DWRITE_PANOSE_STROKE_VARIATION_GRADUAL_DIAGONAL,

		/// <summary>
		/// <para>Value:</para>
		/// <para>4</para>
		/// <para>The stroke variation for text characters is gradual transitional.</para>
		/// </summary>
		DWRITE_PANOSE_STROKE_VARIATION_GRADUAL_TRANSITIONAL,

		/// <summary>
		/// <para>Value:</para>
		/// <para>5</para>
		/// <para>The stroke variation for text characters is gradual vertical.</para>
		/// </summary>
		DWRITE_PANOSE_STROKE_VARIATION_GRADUAL_VERTICAL,

		/// <summary>
		/// <para>Value:</para>
		/// <para>6</para>
		/// <para>The stroke variation for text characters is gradual horizontal.</para>
		/// </summary>
		DWRITE_PANOSE_STROKE_VARIATION_GRADUAL_HORIZONTAL,

		/// <summary>
		/// <para>Value:</para>
		/// <para>7</para>
		/// <para>The stroke variation for text characters is rapid vertical.</para>
		/// </summary>
		DWRITE_PANOSE_STROKE_VARIATION_RAPID_VERTICAL,

		/// <summary>
		/// <para>Value:</para>
		/// <para>8</para>
		/// <para>The stroke variation for text characters is rapid horizontal.</para>
		/// </summary>
		DWRITE_PANOSE_STROKE_VARIATION_RAPID_HORIZONTAL,

		/// <summary>
		/// <para>Value:</para>
		/// <para>9</para>
		/// <para>The stroke variation for text characters is instant vertical.</para>
		/// </summary>
		DWRITE_PANOSE_STROKE_VARIATION_INSTANT_VERTICAL,

		/// <summary>
		/// <para>Value:</para>
		/// <para>10</para>
		/// <para>The stroke variation for text characters is instant horizontal.</para>
		/// </summary>
		DWRITE_PANOSE_STROKE_VARIATION_INSTANT_HORIZONTAL,
	}

	/// <summary>The <b>DWRITE_PANOSE_SYMBOL_ASPECT_RATIO</b> enumeration contains values that specify the aspect ratio of symbolic characters.</summary>
	// https://learn.microsoft.com/en-us/windows/win32/api/dwrite_1/ne-dwrite_1-dwrite_panose_symbol_aspect_ratio typedef enum
	// DWRITE_PANOSE_SYMBOL_ASPECT_RATIO { DWRITE_PANOSE_SYMBOL_ASPECT_RATIO_ANY = 0, DWRITE_PANOSE_SYMBOL_ASPECT_RATIO_NO_FIT = 1,
	// DWRITE_PANOSE_SYMBOL_ASPECT_RATIO_NO_WIDTH = 2, DWRITE_PANOSE_SYMBOL_ASPECT_RATIO_EXCEPTIONALLY_WIDE = 3,
	// DWRITE_PANOSE_SYMBOL_ASPECT_RATIO_SUPER_WIDE = 4, DWRITE_PANOSE_SYMBOL_ASPECT_RATIO_VERY_WIDE = 5,
	// DWRITE_PANOSE_SYMBOL_ASPECT_RATIO_WIDE = 6, DWRITE_PANOSE_SYMBOL_ASPECT_RATIO_NORMAL = 7, DWRITE_PANOSE_SYMBOL_ASPECT_RATIO_NARROW =
	// 8, DWRITE_PANOSE_SYMBOL_ASPECT_RATIO_VERY_NARROW = 9 } ;
	[PInvokeData("dwrite_1.h", MSDNShortId = "NE:dwrite_1.DWRITE_PANOSE_SYMBOL_ASPECT_RATIO")]
	public enum DWRITE_PANOSE_SYMBOL_ASPECT_RATIO
	{
		/// <summary>
		/// <para>Value:</para>
		/// <para>0</para>
		/// <para>Any aspect ratio of symbolic characters.</para>
		/// </summary>
		DWRITE_PANOSE_SYMBOL_ASPECT_RATIO_ANY,

		/// <summary>
		/// <para>Value:</para>
		/// <para>1</para>
		/// <para>No fit for aspect ratio of symbolic characters.</para>
		/// </summary>
		DWRITE_PANOSE_SYMBOL_ASPECT_RATIO_NO_FIT,

		/// <summary>
		/// <para>Value:</para>
		/// <para>2</para>
		/// <para>No width aspect ratio of symbolic characters.</para>
		/// </summary>
		DWRITE_PANOSE_SYMBOL_ASPECT_RATIO_NO_WIDTH,

		/// <summary>
		/// <para>Value:</para>
		/// <para>3</para>
		/// <para>Exceptionally wide symbolic characters.</para>
		/// </summary>
		DWRITE_PANOSE_SYMBOL_ASPECT_RATIO_EXCEPTIONALLY_WIDE,

		/// <summary>
		/// <para>Value:</para>
		/// <para>4</para>
		/// <para>Super wide symbolic characters.</para>
		/// </summary>
		DWRITE_PANOSE_SYMBOL_ASPECT_RATIO_SUPER_WIDE,

		/// <summary>
		/// <para>Value:</para>
		/// <para>5</para>
		/// <para>Very wide symbolic characters.</para>
		/// </summary>
		DWRITE_PANOSE_SYMBOL_ASPECT_RATIO_VERY_WIDE,

		/// <summary>
		/// <para>Value:</para>
		/// <para>6</para>
		/// <para>Wide symbolic characters.</para>
		/// </summary>
		DWRITE_PANOSE_SYMBOL_ASPECT_RATIO_WIDE,

		/// <summary>
		/// <para>Value:</para>
		/// <para>7</para>
		/// <para>Normal aspect ratio of symbolic characters.</para>
		/// </summary>
		DWRITE_PANOSE_SYMBOL_ASPECT_RATIO_NORMAL,

		/// <summary>
		/// <para>Value:</para>
		/// <para>8</para>
		/// <para>Narrow symbolic characters.</para>
		/// </summary>
		DWRITE_PANOSE_SYMBOL_ASPECT_RATIO_NARROW,

		/// <summary>
		/// <para>Value:</para>
		/// <para>9</para>
		/// <para>Very narrow symbolic characters.</para>
		/// </summary>
		DWRITE_PANOSE_SYMBOL_ASPECT_RATIO_VERY_NARROW,
	}

	/// <summary>The <b>DWRITE_PANOSE_SYMBOL_KIND</b> enumeration contains values that specify the kind of symbol set.</summary>
	// https://learn.microsoft.com/en-us/windows/win32/api/dwrite_1/ne-dwrite_1-dwrite_panose_symbol_kind typedef enum
	// DWRITE_PANOSE_SYMBOL_KIND { DWRITE_PANOSE_SYMBOL_KIND_ANY = 0, DWRITE_PANOSE_SYMBOL_KIND_NO_FIT = 1,
	// DWRITE_PANOSE_SYMBOL_KIND_MONTAGES = 2, DWRITE_PANOSE_SYMBOL_KIND_PICTURES = 3, DWRITE_PANOSE_SYMBOL_KIND_SHAPES = 4,
	// DWRITE_PANOSE_SYMBOL_KIND_SCIENTIFIC = 5, DWRITE_PANOSE_SYMBOL_KIND_MUSIC = 6, DWRITE_PANOSE_SYMBOL_KIND_EXPERT = 7,
	// DWRITE_PANOSE_SYMBOL_KIND_PATTERNS = 8, DWRITE_PANOSE_SYMBOL_KIND_BOARDERS = 9, DWRITE_PANOSE_SYMBOL_KIND_ICONS = 10,
	// DWRITE_PANOSE_SYMBOL_KIND_LOGOS = 11, DWRITE_PANOSE_SYMBOL_KIND_INDUSTRY_SPECIFIC = 12 } ;
	[PInvokeData("dwrite_1.h", MSDNShortId = "NE:dwrite_1.DWRITE_PANOSE_SYMBOL_KIND")]
	public enum DWRITE_PANOSE_SYMBOL_KIND
	{
		/// <summary>
		/// <para>Value:</para>
		/// <para>0</para>
		/// <para>Any kind of symbol set.</para>
		/// </summary>
		DWRITE_PANOSE_SYMBOL_KIND_ANY,

		/// <summary>
		/// <para>Value:</para>
		/// <para>1</para>
		/// <para>No fit for the kind of symbol set.</para>
		/// </summary>
		DWRITE_PANOSE_SYMBOL_KIND_NO_FIT,

		/// <summary>
		/// <para>Value:</para>
		/// <para>2</para>
		/// <para>The kind of symbol set is montages.</para>
		/// </summary>
		DWRITE_PANOSE_SYMBOL_KIND_MONTAGES,

		/// <summary>
		/// <para>Value:</para>
		/// <para>3</para>
		/// <para>The kind of symbol set is pictures.</para>
		/// </summary>
		DWRITE_PANOSE_SYMBOL_KIND_PICTURES,

		/// <summary>
		/// <para>Value:</para>
		/// <para>4</para>
		/// <para>The kind of symbol set is shapes.</para>
		/// </summary>
		DWRITE_PANOSE_SYMBOL_KIND_SHAPES,

		/// <summary>
		/// <para>Value:</para>
		/// <para>5</para>
		/// <para>The kind of symbol set is scientific symbols.</para>
		/// </summary>
		DWRITE_PANOSE_SYMBOL_KIND_SCIENTIFIC,

		/// <summary>
		/// <para>Value:</para>
		/// <para>6</para>
		/// <para>The kind of symbol set is music symbols.</para>
		/// </summary>
		DWRITE_PANOSE_SYMBOL_KIND_MUSIC,

		/// <summary>
		/// <para>Value:</para>
		/// <para>7</para>
		/// <para>The kind of symbol set is expert symbols.</para>
		/// </summary>
		DWRITE_PANOSE_SYMBOL_KIND_EXPERT,

		/// <summary>
		/// <para>Value:</para>
		/// <para>8</para>
		/// <para>The kind of symbol set is patterns.</para>
		/// </summary>
		DWRITE_PANOSE_SYMBOL_KIND_PATTERNS,

		/// <summary>
		/// <para>Value:</para>
		/// <para>9</para>
		/// <para>The kind of symbol set is boarders.</para>
		/// </summary>
		DWRITE_PANOSE_SYMBOL_KIND_BOARDERS,

		/// <summary>
		/// <para>Value:</para>
		/// <para>10</para>
		/// <para>The kind of symbol set is icons.</para>
		/// </summary>
		DWRITE_PANOSE_SYMBOL_KIND_ICONS,

		/// <summary>
		/// <para>Value:</para>
		/// <para>11</para>
		/// <para>The kind of symbol set is logos.</para>
		/// </summary>
		DWRITE_PANOSE_SYMBOL_KIND_LOGOS,

		/// <summary>
		/// <para>Value:</para>
		/// <para>12</para>
		/// <para>The kind of symbol set is industry specific.</para>
		/// </summary>
		DWRITE_PANOSE_SYMBOL_KIND_INDUSTRY_SPECIFIC,
	}

	/// <summary>
	/// The <b>DWRITE_PANOSE_TOOL_KIND</b> enumeration contains values that specify the kind of tool that is used to create character forms.
	/// </summary>
	// https://learn.microsoft.com/en-us/windows/win32/api/dwrite_1/ne-dwrite_1-dwrite_panose_tool_kind typedef enum DWRITE_PANOSE_TOOL_KIND
	// { DWRITE_PANOSE_TOOL_KIND_ANY = 0, DWRITE_PANOSE_TOOL_KIND_NO_FIT = 1, DWRITE_PANOSE_TOOL_KIND_FLAT_NIB = 2,
	// DWRITE_PANOSE_TOOL_KIND_PRESSURE_POINT = 3, DWRITE_PANOSE_TOOL_KIND_ENGRAVED = 4, DWRITE_PANOSE_TOOL_KIND_BALL = 5,
	// DWRITE_PANOSE_TOOL_KIND_BRUSH = 6, DWRITE_PANOSE_TOOL_KIND_ROUGH = 7, DWRITE_PANOSE_TOOL_KIND_FELT_PEN_BRUSH_TIP = 8,
	// DWRITE_PANOSE_TOOL_KIND_WILD_BRUSH = 9 } ;
	[PInvokeData("dwrite_1.h", MSDNShortId = "NE:dwrite_1.DWRITE_PANOSE_TOOL_KIND")]
	public enum DWRITE_PANOSE_TOOL_KIND
	{
		/// <summary>
		/// <para>Value:</para>
		/// <para>0</para>
		/// <para>Any kind of tool.</para>
		/// </summary>
		DWRITE_PANOSE_TOOL_KIND_ANY,

		/// <summary>
		/// <para>Value:</para>
		/// <para>1</para>
		/// <para>No fit for the kind of tool.</para>
		/// </summary>
		DWRITE_PANOSE_TOOL_KIND_NO_FIT,

		/// <summary>
		/// <para>Value:</para>
		/// <para>2</para>
		/// <para>Flat NIB tool.</para>
		/// </summary>
		DWRITE_PANOSE_TOOL_KIND_FLAT_NIB,

		/// <summary>
		/// <para>Value:</para>
		/// <para>3</para>
		/// <para>Pressure point tool.</para>
		/// </summary>
		DWRITE_PANOSE_TOOL_KIND_PRESSURE_POINT,

		/// <summary>
		/// <para>Value:</para>
		/// <para>4</para>
		/// <para>Engraved tool.</para>
		/// </summary>
		DWRITE_PANOSE_TOOL_KIND_ENGRAVED,

		/// <summary>
		/// <para>Value:</para>
		/// <para>5</para>
		/// <para>Ball tool.</para>
		/// </summary>
		DWRITE_PANOSE_TOOL_KIND_BALL,

		/// <summary>
		/// <para>Value:</para>
		/// <para>6</para>
		/// <para>Brush tool.</para>
		/// </summary>
		DWRITE_PANOSE_TOOL_KIND_BRUSH,

		/// <summary>
		/// <para>Value:</para>
		/// <para>7</para>
		/// <para>Rough tool.</para>
		/// </summary>
		DWRITE_PANOSE_TOOL_KIND_ROUGH,

		/// <summary>
		/// <para>Value:</para>
		/// <para>8</para>
		/// <para>Felt-pen-brush-tip tool.</para>
		/// </summary>
		DWRITE_PANOSE_TOOL_KIND_FELT_PEN_BRUSH_TIP,

		/// <summary>
		/// <para>Value:</para>
		/// <para>9</para>
		/// <para>Wild-brush tool.</para>
		/// </summary>
		DWRITE_PANOSE_TOOL_KIND_WILD_BRUSH,
	}

	/// <summary>The <b>DWRITE_PANOSE_WEIGHT</b> enumeration contains values that specify the weight of characters.</summary>
	/// <remarks>
	/// The <b>DWRITE_PANOSE_WEIGHT</b> values roughly correspond to the <c>DWRITE_FONT_WEIGHT</c> values by using (panose_weight - 2) * 100
	/// = font_weight.
	/// </remarks>
	// https://learn.microsoft.com/en-us/windows/win32/api/dwrite_1/ne-dwrite_1-dwrite_panose_weight typedef enum DWRITE_PANOSE_WEIGHT {
	// DWRITE_PANOSE_WEIGHT_ANY = 0, DWRITE_PANOSE_WEIGHT_NO_FIT = 1, DWRITE_PANOSE_WEIGHT_VERY_LIGHT = 2, DWRITE_PANOSE_WEIGHT_LIGHT = 3,
	// DWRITE_PANOSE_WEIGHT_THIN = 4, DWRITE_PANOSE_WEIGHT_BOOK = 5, DWRITE_PANOSE_WEIGHT_MEDIUM = 6, DWRITE_PANOSE_WEIGHT_DEMI = 7,
	// DWRITE_PANOSE_WEIGHT_BOLD = 8, DWRITE_PANOSE_WEIGHT_HEAVY = 9, DWRITE_PANOSE_WEIGHT_BLACK = 10, DWRITE_PANOSE_WEIGHT_EXTRA_BLACK =
	// 11, DWRITE_PANOSE_WEIGHT_NORD } ;
	[PInvokeData("dwrite_1.h", MSDNShortId = "NE:dwrite_1.DWRITE_PANOSE_WEIGHT")]
	public enum DWRITE_PANOSE_WEIGHT
	{
		/// <summary>
		/// <para>Value:</para>
		/// <para>0</para>
		/// <para>Any weight.</para>
		/// </summary>
		DWRITE_PANOSE_WEIGHT_ANY,

		/// <summary>
		/// <para>Value:</para>
		/// <para>1</para>
		/// <para>No fit weight.</para>
		/// </summary>
		DWRITE_PANOSE_WEIGHT_NO_FIT,

		/// <summary>
		/// <para>Value:</para>
		/// <para>2</para>
		/// <para>Very light weight.</para>
		/// </summary>
		DWRITE_PANOSE_WEIGHT_VERY_LIGHT,

		/// <summary>
		/// <para>Value:</para>
		/// <para>3</para>
		/// <para>Light weight.</para>
		/// </summary>
		DWRITE_PANOSE_WEIGHT_LIGHT,

		/// <summary>
		/// <para>Value:</para>
		/// <para>4</para>
		/// <para>Thin weight.</para>
		/// </summary>
		DWRITE_PANOSE_WEIGHT_THIN,

		/// <summary>
		/// <para>Value:</para>
		/// <para>5</para>
		/// <para>Book weight.</para>
		/// </summary>
		DWRITE_PANOSE_WEIGHT_BOOK,

		/// <summary>
		/// <para>Value:</para>
		/// <para>6</para>
		/// <para>Medium weight.</para>
		/// </summary>
		DWRITE_PANOSE_WEIGHT_MEDIUM,

		/// <summary>
		/// <para>Value:</para>
		/// <para>7</para>
		/// <para>Demi weight.</para>
		/// </summary>
		DWRITE_PANOSE_WEIGHT_DEMI,

		/// <summary>
		/// <para>Value:</para>
		/// <para>8</para>
		/// <para>Bold weight.</para>
		/// </summary>
		DWRITE_PANOSE_WEIGHT_BOLD,

		/// <summary>
		/// <para>Value:</para>
		/// <para>9</para>
		/// <para>Heavy weight.</para>
		/// </summary>
		DWRITE_PANOSE_WEIGHT_HEAVY,

		/// <summary>
		/// <para>Value:</para>
		/// <para>10</para>
		/// <para>Black weight.</para>
		/// </summary>
		DWRITE_PANOSE_WEIGHT_BLACK,

		/// <summary>
		/// <para>Value:</para>
		/// <para>11</para>
		/// <para>Extra black weight.</para>
		/// </summary>
		DWRITE_PANOSE_WEIGHT_EXTRA_BLACK,

		/// <summary>Extra black weight.</summary>
		DWRITE_PANOSE_WEIGHT_NORD,
	}

	/// <summary>The <b>DWRITE_PANOSE_XASCENT</b> enumeration contains values that specify the relative size of the lowercase letters.</summary>
	// https://learn.microsoft.com/en-us/windows/win32/api/dwrite_1/ne-dwrite_1-dwrite_panose_xascent typedef enum DWRITE_PANOSE_XASCENT {
	// DWRITE_PANOSE_XASCENT_ANY = 0, DWRITE_PANOSE_XASCENT_NO_FIT = 1, DWRITE_PANOSE_XASCENT_VERY_LOW = 2, DWRITE_PANOSE_XASCENT_LOW = 3,
	// DWRITE_PANOSE_XASCENT_MEDIUM = 4, DWRITE_PANOSE_XASCENT_HIGH = 5, DWRITE_PANOSE_XASCENT_VERY_HIGH = 6 } ;
	[PInvokeData("dwrite_1.h", MSDNShortId = "NE:dwrite_1.DWRITE_PANOSE_XASCENT")]
	public enum DWRITE_PANOSE_XASCENT
	{
		/// <summary>
		/// <para>Value:</para>
		/// <para>0</para>
		/// <para>Any xascent.</para>
		/// </summary>
		DWRITE_PANOSE_XASCENT_ANY,

		/// <summary>
		/// <para>Value:</para>
		/// <para>1</para>
		/// <para>No fit for xascent.</para>
		/// </summary>
		DWRITE_PANOSE_XASCENT_NO_FIT,

		/// <summary>
		/// <para>Value:</para>
		/// <para>2</para>
		/// <para>Very low xascent.</para>
		/// </summary>
		DWRITE_PANOSE_XASCENT_VERY_LOW,

		/// <summary>
		/// <para>Value:</para>
		/// <para>3</para>
		/// <para>Low xascent.</para>
		/// </summary>
		DWRITE_PANOSE_XASCENT_LOW,

		/// <summary>
		/// <para>Value:</para>
		/// <para>4</para>
		/// <para>Medium xascent.</para>
		/// </summary>
		DWRITE_PANOSE_XASCENT_MEDIUM,

		/// <summary>
		/// <para>Value:</para>
		/// <para>5</para>
		/// <para>High xascent.</para>
		/// </summary>
		DWRITE_PANOSE_XASCENT_HIGH,

		/// <summary>
		/// <para>Value:</para>
		/// <para>6</para>
		/// <para>Very high xascent.</para>
		/// </summary>
		DWRITE_PANOSE_XASCENT_VERY_HIGH,
	}

	/// <summary>
	/// The <b>DWRITE_PANOSE_XHEIGHT</b> enumeration contains values that specify info about the relative size of lowercase letters and the
	/// treatment of diacritic marks (xheight).
	/// </summary>
	// https://learn.microsoft.com/en-us/windows/win32/api/dwrite_1/ne-dwrite_1-dwrite_panose_xheight typedef enum DWRITE_PANOSE_XHEIGHT {
	// DWRITE_PANOSE_XHEIGHT_ANY = 0, DWRITE_PANOSE_XHEIGHT_NO_FIT = 1, DWRITE_PANOSE_XHEIGHT_CONSTANT_SMALL = 2,
	// DWRITE_PANOSE_XHEIGHT_CONSTANT_STANDARD = 3, DWRITE_PANOSE_XHEIGHT_CONSTANT_LARGE = 4, DWRITE_PANOSE_XHEIGHT_DUCKING_SMALL = 5,
	// DWRITE_PANOSE_XHEIGHT_DUCKING_STANDARD = 6, DWRITE_PANOSE_XHEIGHT_DUCKING_LARGE = 7, DWRITE_PANOSE_XHEIGHT_CONSTANT_STD,
	// DWRITE_PANOSE_XHEIGHT_DUCKING_STD } ;
	[PInvokeData("dwrite_1.h", MSDNShortId = "NE:dwrite_1.DWRITE_PANOSE_XHEIGHT")]
	public enum DWRITE_PANOSE_XHEIGHT
	{
		/// <summary>
		/// <para>Value:</para>
		/// <para>0</para>
		/// <para>Any xheight.</para>
		/// </summary>
		DWRITE_PANOSE_XHEIGHT_ANY,

		/// <summary>
		/// <para>Value:</para>
		/// <para>1</para>
		/// <para>No fit xheight.</para>
		/// </summary>
		DWRITE_PANOSE_XHEIGHT_NO_FIT,

		/// <summary>
		/// <para>Value:</para>
		/// <para>2</para>
		/// <para>Constant small xheight.</para>
		/// </summary>
		DWRITE_PANOSE_XHEIGHT_CONSTANT_SMALL,

		/// <summary>
		/// <para>Value:</para>
		/// <para>3</para>
		/// <para>Constant standard xheight.</para>
		/// </summary>
		DWRITE_PANOSE_XHEIGHT_CONSTANT_STANDARD,

		/// <summary>
		/// <para>Value:</para>
		/// <para>4</para>
		/// <para>Constant large xheight.</para>
		/// </summary>
		DWRITE_PANOSE_XHEIGHT_CONSTANT_LARGE,

		/// <summary>
		/// <para>Value:</para>
		/// <para>5</para>
		/// <para>Ducking small xheight.</para>
		/// </summary>
		DWRITE_PANOSE_XHEIGHT_DUCKING_SMALL,

		/// <summary>
		/// <para>Value:</para>
		/// <para>6</para>
		/// <para>Ducking standard xheight.</para>
		/// </summary>
		DWRITE_PANOSE_XHEIGHT_DUCKING_STANDARD,

		/// <summary>
		/// <para>Value:</para>
		/// <para>7</para>
		/// <para>Ducking large xheight.</para>
		/// </summary>
		DWRITE_PANOSE_XHEIGHT_DUCKING_LARGE,

		/// <summary>Constant standard xheight.</summary>
		DWRITE_PANOSE_XHEIGHT_CONSTANT_STD,

		/// <summary>Ducking standard xheight.</summary>
		DWRITE_PANOSE_XHEIGHT_DUCKING_STD,
	}

	/// <summary>
	/// The <b>DWRITE_TEXT_ANTIALIAS_MODE</b> enumeration contains values that specify the type of antialiasing to use for text when the
	/// rendering mode calls for antialiasing.
	/// </summary>
	// https://learn.microsoft.com/en-us/windows/win32/api/dwrite_1/ne-dwrite_1-dwrite_text_antialias_mode typedef enum
	// DWRITE_TEXT_ANTIALIAS_MODE { DWRITE_TEXT_ANTIALIAS_MODE_CLEARTYPE, DWRITE_TEXT_ANTIALIAS_MODE_GRAYSCALE } ;
	[PInvokeData("dwrite_1.h", MSDNShortId = "NE:dwrite_1.DWRITE_TEXT_ANTIALIAS_MODE")]
	public enum DWRITE_TEXT_ANTIALIAS_MODE
	{
		/// <summary>
		/// ClearType antialiasing computes coverage independently for the red, green, and blue color elements of each pixel. This allows
		/// for more detail than conventional antialiasing. However, because there is no one alpha value for each pixel, ClearType is not
		/// suitable for rendering text onto a transparent intermediate bitmap.
		/// </summary>
		DWRITE_TEXT_ANTIALIAS_MODE_CLEARTYPE,

		/// <summary>
		/// <para>
		/// Grayscale antialiasing computes one coverage value for each pixel. Because the alpha value of each pixel is well-defined, text
		/// can be rendered onto a transparent bitmap, which can then be composited with other content.
		/// </para>
		/// <para><b>Note</b>  Grayscale rendering with <c>IDWriteBitmapRenderTarget1</c> uses premultiplied alpha.</para>
		/// <para></para>
		/// </summary>
		DWRITE_TEXT_ANTIALIAS_MODE_GRAYSCALE,
	}

	/// <summary>
	/// The <b>DWRITE_VERTICAL_GLYPH_ORIENTATION</b> enumeration contains values that specify the desired kind of glyph orientation for the text.
	/// </summary>
	/// <remarks>
	/// <para>The client specifies a <b>DWRITE_VERTICAL_GLYPH_ORIENTATION</b>-typed value to the analyzer as the desired orientation.</para>
	/// <para><b>Note</b>  This is the client preference, and the constraints of the script determine the final presentation.</para>
	/// <para></para>
	/// </remarks>
	// https://learn.microsoft.com/en-us/windows/win32/api/dwrite_1/ne-dwrite_1-dwrite_vertical_glyph_orientation typedef enum
	// DWRITE_VERTICAL_GLYPH_ORIENTATION { DWRITE_VERTICAL_GLYPH_ORIENTATION_DEFAULT, DWRITE_VERTICAL_GLYPH_ORIENTATION_STACKED } ;
	[PInvokeData("dwrite_1.h", MSDNShortId = "NE:dwrite_1.DWRITE_VERTICAL_GLYPH_ORIENTATION")]
	public enum DWRITE_VERTICAL_GLYPH_ORIENTATION
	{
		/// <summary>
		/// The default glyph orientation. In vertical layout, naturally horizontal scripts (Latin, Thai, Arabic, Devanagari) rotate 90
		/// degrees clockwise, while ideographic scripts (Chinese, Japanese, Korean) remain upright, 0 degrees.
		/// </summary>
		DWRITE_VERTICAL_GLYPH_ORIENTATION_DEFAULT,

		/// <summary>
		/// Stacked glyph orientation. Ideographic scripts and scripts that permit stacking (Latin, Hebrew) are stacked in vertical reading
		/// layout. Connected scripts (Arabic, Syriac, 'Phags-pa, Ogham), which would otherwise look broken if glyphs were kept at 0
		/// degrees, remain connected and rotate.
		/// </summary>
		DWRITE_VERTICAL_GLYPH_ORIENTATION_STACKED,
	}

	/// <summary>Encapsulates a 32-bit device independent bitmap and device context, which you can use for rendering glyphs.</summary>
	// https://learn.microsoft.com/en-us/windows/win32/api/dwrite_1/nn-dwrite_1-idwritebitmaprendertarget1
	[PInvokeData("dwrite_1.h", MSDNShortId = "NN:dwrite_1.IDWriteBitmapRenderTarget1")]
	[ComImport, Guid("791e8298-3ef3-4230-9880-c9bdecc42064"), InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
	public interface IDWriteBitmapRenderTarget1 : IDWriteBitmapRenderTarget
	{
		/// <summary>Draws a run of glyphs to a bitmap target at the specified position.</summary>
		/// <param name="baselineOriginX">
		/// <para>Type: <c>FLOAT</c></para>
		/// <para>The horizontal position of the baseline origin, in DIPs, relative to the upper-left corner of the DIB.</para>
		/// </param>
		/// <param name="baselineOriginY">
		/// <para>Type: <c>FLOAT</c></para>
		/// <para>The vertical position of the baseline origin, in DIPs, relative to the upper-left corner of the DIB.</para>
		/// </param>
		/// <param name="measuringMode">
		/// <para>Type: <c>DWRITE_MEASURING_MODE</c></para>
		/// <para>The measuring method for glyphs in the run, used with the other properties to determine the rendering mode.</para>
		/// </param>
		/// <param name="glyphRun">
		/// <para>Type: <c>const DWRITE_GLYPH_RUN*</c></para>
		/// <para>The structure containing the properties of the glyph run.</para>
		/// </param>
		/// <param name="renderingParams">
		/// <para>Type: <c>IDWriteRenderingParams*</c></para>
		/// <para>The object that controls rendering behavior.</para>
		/// </param>
		/// <param name="textColor">
		/// <para>Type: <c>COLORREF</c></para>
		/// <para>The foreground color of the text.</para>
		/// </param>
		/// <param name="blackBoxRect">
		/// <para>Type: <c>RECT*</c></para>
		/// <para>
		/// The optional rectangle that receives the bounding box (in pixels not DIPs) of all the pixels affected by drawing the glyph run.
		/// The black box rectangle may extend beyond the dimensions of the bitmap.
		/// </para>
		/// </param>
		/// <remarks>
		/// <para>
		/// You can use the <c>IDWriteBitmapRenderTarget::DrawGlyphRun</c> to render to a bitmap from a custom text renderer that you
		/// implement. The custom text renderer should call this method from within the IDWriteTextRenderer::DrawGlyphRun callback method as
		/// shown in the following code.
		/// </para>
		/// <para>
		/// The baselineOriginX, baslineOriginY, measuringMethod, and glyphRun parameters are provided (as arguments) when the callback
		/// method is invoked. The renderingParams, textColor and blackBoxRect are not.
		/// </para>
		/// <para>Default rendering params can be retrieved by using the IDWriteFactory::CreateMonitorRenderingParams method.</para>
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows/win32/api/dwrite/nf-dwrite-idwritebitmaprendertarget-drawglyphrun HRESULT DrawGlyphRun(
		// FLOAT baselineOriginX, FLOAT baselineOriginY, DWRITE_MEASURING_MODE measuringMode, DWRITE_GLYPH_RUN const
		// *glyphRun, IDWriteRenderingParams *renderingParams, COLORREF textColor, RECT *blackBoxRect );
		new void DrawGlyphRun(float baselineOriginX, float baselineOriginY, DWRITE_MEASURING_MODE measuringMode, in DWRITE_GLYPH_RUN glyphRun, [In] IDWriteRenderingParams renderingParams, COLORREF textColor, out RECT blackBoxRect);

		/// <summary>Gets a handle to the memory device context.</summary>
		/// <returns>
		/// <para>Type: <c>HDC</c></para>
		/// <para>Returns a device context handle to the memory device context.</para>
		/// </returns>
		/// <remarks>
		/// <para>
		/// An application can use the device context to draw using GDI functions. An application can obtain the bitmap handle (HBITMAP) by
		/// calling GetCurrentObject. An application that wants information about the underlying bitmap, including a pointer to the pixel
		/// data, can call GetObject to fill in a DIBSECTION structure. The bitmap is always a 32-bit top-down DIB.
		/// </para>
		/// <para>Note that this method takes no parameters and returns an HDC variable, not an HRESULT.</para>
		/// <para>The HDC returned here is still owned by the bitmap render targer object and should not be released or deleted by the client.</para>
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows/win32/api/dwrite/nf-dwrite-idwritebitmaprendertarget-getmemorydc HDC GetMemoryDC();
		[PreserveSig]
		new HDC GetMemoryDC();

		/// <summary>Gets the number of bitmap pixels per DIP.</summary>
		/// <returns>
		/// <para>Type: <c>FLOAT</c></para>
		/// <para>The number of bitmap pixels per DIP.</para>
		/// </returns>
		/// <remarks>
		/// A DIP (device-independent pixel) is 1/96 inch. Therefore, this value is the number if pixels per inch divided by 96.
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows/win32/api/dwrite/nf-dwrite-idwritebitmaprendertarget-getpixelsperdip FLOAT GetPixelsPerDip();
		[PreserveSig]
		new float GetPixelsPerDip();

		/// <summary>
		/// Sets the number of bitmap pixels per DIP (device-independent pixel). A DIP is 1/96 inch, so this value is the number if pixels
		/// per inch divided by 96.
		/// </summary>
		/// <param name="pixelsPerDip">
		/// <para>Type: <c>FLOAT</c></para>
		/// <para>A value that specifies the number of pixels per DIP.</para>
		/// </param>
		// https://docs.microsoft.com/en-us/windows/win32/api/dwrite/nf-dwrite-idwritebitmaprendertarget-setpixelsperdip HRESULT
		// SetPixelsPerDip( FLOAT pixelsPerDip );
		new void SetPixelsPerDip(float pixelsPerDip);

		/// <summary>
		/// Gets the transform that maps abstract coordinates to DIPs. By default this is the identity transform. Note that this is
		/// unrelated to the world transform of the underlying device context.
		/// </summary>
		/// <returns>
		/// <para>Type: <c>DWRITE_MATRIX*</c></para>
		/// <para>When this method returns, contains a transform matrix.</para>
		/// </returns>
		// https://docs.microsoft.com/en-us/windows/win32/api/dwrite/nf-dwrite-idwritebitmaprendertarget-getcurrenttransform HRESULT
		// GetCurrentTransform( DWRITE_MATRIX *transform );
		new DWRITE_MATRIX GetCurrentTransform();

		/// <summary>
		/// Sets the transform that maps abstract coordinate to DIPs (device-independent pixel). This does not affect the world transform of
		/// the underlying device context.
		/// </summary>
		/// <param name="transform">
		/// <para>Type: <c>const DWRITE_MATRIX*</c></para>
		/// <para>Specifies the new transform. This parameter can be <c>NULL</c>, in which case the identity transform is implied.</para>
		/// </param>
		// https://docs.microsoft.com/en-us/windows/win32/api/dwrite/nf-dwrite-idwritebitmaprendertarget-setcurrenttransform HRESULT
		// SetCurrentTransform( DWRITE_MATRIX const *transform );
		new void SetCurrentTransform([In, Optional] IntPtr transform);

		/// <summary>Gets the dimensions of the target bitmap.</summary>
		/// <returns>
		/// <para>Type: <c>SIZE*</c></para>
		/// <para>Returns the width and height of the bitmap in pixels.</para>
		/// </returns>
		// https://docs.microsoft.com/en-us/windows/win32/api/dwrite/nf-dwrite-idwritebitmaprendertarget-getsize HRESULT GetSize( SIZE
		// *size );
		new SIZE GetSize();

		/// <summary>Resizes the bitmap.</summary>
		/// <param name="width">
		/// <para>Type: <c>UINT32</c></para>
		/// <para>The new bitmap width, in pixels.</para>
		/// </param>
		/// <param name="height">
		/// <para>Type: <c>UINT32</c></para>
		/// <para>The new bitmap height, in pixels.</para>
		/// </param>
		// https://docs.microsoft.com/en-us/windows/win32/api/dwrite/nf-dwrite-idwritebitmaprendertarget-resize HRESULT Resize( UINT32
		// width, UINT32 height );
		new void Resize(uint width, uint height);

		/// <summary>Gets the current text antialiasing mode of the bitmap render target.</summary>
		/// <returns>
		/// <para>Type: <b><c>DWRITE_TEXT_ANTIALIAS_MODE</c></b></para>
		/// <para>Returns a <c>DWRITE_TEXT_ANTIALIAS_MODE</c>-typed value that specifies the antialiasing mode.</para>
		/// </returns>
		// https://learn.microsoft.com/en-us/windows/win32/api/dwrite_1/nf-dwrite_1-idwritebitmaprendertarget1-gettextantialiasmode
		// DWRITE_TEXT_ANTIALIAS_MODE GetTextAntialiasMode();
		[PreserveSig]
		DWRITE_TEXT_ANTIALIAS_MODE GetTextAntialiasMode();

		/// <summary>Sets the current text antialiasing mode of the bitmap render target.</summary>
		/// <param name="antialiasMode">
		/// <para>Type: <b><c>DWRITE_TEXT_ANTIALIAS_MODE</c></b></para>
		/// <para>A <c>DWRITE_TEXT_ANTIALIAS_MODE</c>-typed value that specifies the antialiasing mode.</para>
		/// </param>
		/// <returns>
		/// <para>Type: <b>HRESULT</b></para>
		/// <para>Returns S_OK if successful, or E_INVALIDARG if the argument is not valid.</para>
		/// </returns>
		/// <remarks>
		/// The antialiasing mode of a newly-created bitmap render target defaults to <c>DWRITE_TEXT_ANTIALIAS_MODE_CLEARTYPE</c>. An app
		/// can change the antialiasing mode by calling <b>SetTextAntialiasMode</b>. For example, an app might specify
		/// <c>DWRITE_TEXT_ANTIALIAS_MODE_GRAYSCALE</c> for grayscale antialiasing when it renders text onto a transparent bitmap.
		/// </remarks>
		// https://learn.microsoft.com/en-us/windows/win32/api/dwrite_1/nf-dwrite_1-idwritebitmaprendertarget1-settextantialiasmode HRESULT
		// SetTextAntialiasMode( DWRITE_TEXT_ANTIALIAS_MODE antialiasMode );
		void SetTextAntialiasMode(DWRITE_TEXT_ANTIALIAS_MODE antialiasMode);
	}

	/// <summary>The root factory interface for all <c>DirectWrite</c> objects.</summary>
	// https://learn.microsoft.com/en-us/windows/win32/api/dwrite_1/nn-dwrite_1-idwritefactory1
	[PInvokeData("dwrite_1.h", MSDNShortId = "NN:dwrite_1.IDWriteFactory1")]
	[ComImport, Guid("30572f99-dac6-41db-a16e-0486307e606a"), InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
	public interface IDWriteFactory1 : IDWriteFactory
	{
		/// <summary>Gets an object which represents the set of installed fonts.</summary>
		/// <param name="fontCollection">
		/// <para>Type: <c>IDWriteFontCollection**</c></para>
		/// <para>
		/// When this method returns, contains the address of a pointer to the system font collection object, or <c>NULL</c> in case of failure.
		/// </para>
		/// </param>
		/// <param name="checkForUpdates">
		/// <para>Type: <c>BOOL</c></para>
		/// <para>
		/// If this parameter is nonzero, the function performs an immediate check for changes to the set of installed fonts. If this
		/// parameter is <c>FALSE</c>, the function will still detect changes if the font cache service is running, but there may be some
		/// latency. For example, an application might specify <c>TRUE</c> if it has itself just installed a font and wants to be sure the
		/// font collection contains that font.
		/// </para>
		/// </param>
		// https://docs.microsoft.com/en-us/windows/win32/api/dwrite/nf-dwrite-idwritefactory-getsystemfontcollection HRESULT
		// GetSystemFontCollection( IDWriteFontCollection **fontCollection, BOOL checkForUpdates );
		new void GetSystemFontCollection(out IDWriteFontCollection fontCollection, [MarshalAs(UnmanagedType.Bool)] bool checkForUpdates = false);

		/// <summary>Creates a font collection using a custom font collection loader.</summary>
		/// <param name="collectionLoader">
		/// <para>Type: <c>IDWriteFontCollectionLoader*</c></para>
		/// <para>An application-defined font collection loader, which must have been previously registered using RegisterFontCollectionLoader.</para>
		/// </param>
		/// <param name="collectionKey">
		/// <para>Type: <c>const void*</c></para>
		/// <para>
		/// The key used by the loader to identify a collection of font files. The buffer allocated for this key should at least be the size
		/// of collectionKeySize.
		/// </para>
		/// </param>
		/// <param name="collectionKeySize">
		/// <para>Type: <c>UINT32</c></para>
		/// <para>The size, in bytes, of the collection key.</para>
		/// </param>
		/// <returns>
		/// <para>Type: <c>IDWriteFontCollection**</c></para>
		/// <para>
		/// Contains an address of a pointer to the system font collection object if the method succeeds, or <c>NULL</c> in case of failure.
		/// </para>
		/// </returns>
		// https://docs.microsoft.com/en-us/windows/win32/api/dwrite/nf-dwrite-idwritefactory-createcustomfontcollection HRESULT
		// CreateCustomFontCollection( IDWriteFontCollectionLoader *collectionLoader, void const *collectionKey, UINT32 collectionKeySize,
		// IDWriteFontCollection **fontCollection );
		new IDWriteFontCollection CreateCustomFontCollection([In] IDWriteFontCollectionLoader collectionLoader, [In] IntPtr collectionKey, uint collectionKeySize);

		/// <summary>Registers a custom font collection loader with the factory object.</summary>
		/// <param name="fontCollectionLoader">
		/// <para>Type: <c>IDWriteFontCollectionLoader*</c></para>
		/// <para>Pointer to a IDWriteFontCollectionLoader object to be registered.</para>
		/// </param>
		/// <remarks>
		/// This function registers a font collection loader with DirectWrite. The font collection loader interface, which should be
		/// implemented by a singleton object, handles enumerating font files in a font collection given a particular type of key. A given
		/// instance can only be registered once. Succeeding attempts will return an error, indicating that it has already been registered.
		/// Note that font file loader implementations must not register themselves with DirectWrite inside their constructors, and must not
		/// unregister themselves inside their destructors, because registration and unregistraton operations increment and decrement the
		/// object reference count respectively. Instead, registration and unregistration with DirectWrite of font file loaders should be
		/// performed outside of the font file loader implementation.
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows/win32/api/dwrite/nf-dwrite-idwritefactory-registerfontcollectionloader HRESULT
		// RegisterFontCollectionLoader( IDWriteFontCollectionLoader *fontCollectionLoader );
		new void RegisterFontCollectionLoader([In] IDWriteFontCollectionLoader fontCollectionLoader);

		/// <summary>Unregisters a custom font collection loader that was previously registered using RegisterFontCollectionLoader.</summary>
		/// <param name="fontCollectionLoader">
		/// <para>Type: <c>IDWriteFontCollectionLoader*</c></para>
		/// <para>Pointer to a IDWriteFontCollectionLoader object to be unregistered.</para>
		/// </param>
		// https://docs.microsoft.com/en-us/windows/win32/api/dwrite/nf-dwrite-idwritefactory-unregisterfontcollectionloader HRESULT
		// UnregisterFontCollectionLoader( IDWriteFontCollectionLoader *fontCollectionLoader );
		new void UnregisterFontCollectionLoader([In] IDWriteFontCollectionLoader fontCollectionLoader);

		/// <summary>Creates a font file reference object from a local font file.</summary>
		/// <param name="filePath">
		/// <para>Type: <c>const WCHAR*</c></para>
		/// <para>
		/// An array of characters that contains the absolute file path for the font file. Subsequent operations on the constructed object
		/// may fail if the user provided filePath doesn't correspond to a valid file on the disk.
		/// </para>
		/// </param>
		/// <param name="lastWriteTime">
		/// <para>Type: <c>const FILETIME*</c></para>
		/// <para>
		/// The last modified time of the input file path. If the parameter is omitted, the function will access the font file to obtain its
		/// last write time. You should specify this value to avoid extra disk access. Subsequent operations on the constructed object may
		/// fail if the user provided lastWriteTime doesn't match the file on the disk.
		/// </para>
		/// </param>
		/// <returns>
		/// <para>Type: <c>IDWriteFontFile**</c></para>
		/// <para>
		/// When this method returns, contains an address of a pointer to the newly created font file reference object, or <c>NULL</c> in
		/// case of failure.
		/// </para>
		/// </returns>
		// https://docs.microsoft.com/en-us/windows/win32/api/dwrite/nf-dwrite-idwritefactory-createfontfilereference HRESULT
		// CreateFontFileReference( WCHAR const *filePath, FILETIME const *lastWriteTime, IDWriteFontFile **fontFile );
		new IDWriteFontFile CreateFontFileReference([MarshalAs(UnmanagedType.LPWStr)] string filePath, [In, Optional] IntPtr lastWriteTime);

		/// <summary>Creates a reference to an application-specific font file resource.</summary>
		/// <param name="fontFileReferenceKey">
		/// <para>Type: <c>const void*</c></para>
		/// <para>A font file reference key that uniquely identifies the font file resource during the lifetime of fontFileLoader.</para>
		/// </param>
		/// <param name="fontFileReferenceKeySize">
		/// <para>Type: <c>UINT32</c></para>
		/// <para>The size of the font file reference key in bytes.</para>
		/// </param>
		/// <param name="fontFileLoader">
		/// <para>Type: <c>IDWriteFontFileLoader*</c></para>
		/// <para>The font file loader that will be used by the font system to load data from the file identified by fontFileReferenceKey.</para>
		/// </param>
		/// <returns>
		/// <para>Type: <c>IDWriteFontFile**</c></para>
		/// <para>
		/// Contains an address of a pointer to the newly created font file object when this method succeeds, or <c>NULL</c> in case of failure.
		/// </para>
		/// </returns>
		/// <remarks>
		/// This function is provided for cases when an application or a document needs to use a private font without having to install it
		/// on the system. fontFileReferenceKey has to be unique only in the scope of the fontFileLoader used in this call.
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows/win32/api/dwrite/nf-dwrite-idwritefactory-createcustomfontfilereference HRESULT
		// CreateCustomFontFileReference( void const *fontFileReferenceKey, UINT32 fontFileReferenceKeySize, IDWriteFontFileLoader
		// *fontFileLoader, IDWriteFontFile **fontFile );
		new IDWriteFontFile CreateCustomFontFileReference([In] IntPtr fontFileReferenceKey, uint fontFileReferenceKeySize, [In] IDWriteFontFileLoader fontFileLoader);

		/// <summary>Creates an object that represents a font face.</summary>
		/// <param name="fontFaceType">
		/// <para>Type: <c>DWRITE_FONT_FACE_TYPE</c></para>
		/// <para>A value that indicates the type of file format of the font face.</para>
		/// </param>
		/// <param name="numberOfFiles">
		/// <para>Type: <c>UINT32</c></para>
		/// <para>The number of font files, in element count, required to represent the font face.</para>
		/// </param>
		/// <param name="fontFiles">
		/// <para>Type: <c>const IDWriteFontFile*</c></para>
		/// <para>
		/// A font file object representing the font face. Because IDWriteFontFacemaintains its own references to the input font file
		/// objects, you may release them after this call.
		/// </para>
		/// </param>
		/// <param name="faceIndex">
		/// <para>Type: <c>UINT32</c></para>
		/// <para>
		/// The zero-based index of a font face, in cases when the font files contain a collection of font faces. If the font files contain
		/// a single face, this value should be zero.
		/// </para>
		/// </param>
		/// <param name="fontFaceSimulationFlags">
		/// <para>Type: <c>DWRITE_FONT_SIMULATIONS</c></para>
		/// <para>
		/// A value that indicates which, if any, font face simulation flags for algorithmic means of making text bold or italic are applied
		/// to the current font face.
		/// </para>
		/// </param>
		/// <returns>
		/// <para>Type: <c>IDWriteFontFace**</c></para>
		/// <para>
		/// When this method returns, contains an address of a pointer to the newly created font face object, or <c>NULL</c> in case of failure.
		/// </para>
		/// </returns>
		// https://docs.microsoft.com/en-us/windows/win32/api/dwrite/nf-dwrite-idwritefactory-createfontface HRESULT CreateFontFace(
		// DWRITE_FONT_FACE_TYPE fontFaceType, UINT32 numberOfFiles, IDWriteFontFile * const *fontFiles, UINT32 faceIndex,
		// DWRITE_FONT_SIMULATIONS fontFaceSimulationFlags, IDWriteFontFace **fontFace );
		new IDWriteFontFace CreateFontFace(DWRITE_FONT_FACE_TYPE fontFaceType, uint numberOfFiles,
			[In, MarshalAs(UnmanagedType.LPArray, ArraySubType = UnmanagedType.Interface)] IDWriteFontFile[] fontFiles,
			uint faceIndex, DWRITE_FONT_SIMULATIONS fontFaceSimulationFlags);

		/// <summary>
		/// Creates a rendering parameters object with default settings for the primary monitor. Different monitors may have different
		/// rendering parameters, for more information see the How to Add Support for Multiple Monitors topic.
		/// </summary>
		/// <returns>
		/// <para>Type: <c>IDWriteRenderingParams**</c></para>
		/// <para>When this method returns, contains an address of a pointer to the newly created rendering parameters object.</para>
		/// </returns>
		// https://docs.microsoft.com/en-us/windows/win32/api/dwrite/nf-dwrite-idwritefactory-createrenderingparams HRESULT
		// CreateRenderingParams( IDWriteRenderingParams **renderingParams );
		new IDWriteRenderingParams CreateRenderingParams();

		/// <summary>
		/// Creates a rendering parameters object with default settings for the specified monitor. In most cases, this is the preferred way
		/// to create a rendering parameters object.
		/// </summary>
		/// <param name="monitor">
		/// <para>Type: <c>HMONITOR</c></para>
		/// <para>A handle for the specified monitor.</para>
		/// </param>
		/// <returns>
		/// <para>Type: <c>IDWriteRenderingParams**</c></para>
		/// <para>When this method returns, contains an address of a pointer to the rendering parameters object created by this method.</para>
		/// </returns>
		// https://docs.microsoft.com/en-us/windows/win32/api/dwrite/nf-dwrite-idwritefactory-createmonitorrenderingparams HRESULT
		// CreateMonitorRenderingParams( HMONITOR monitor, IDWriteRenderingParams **renderingParams );
		new IDWriteRenderingParams CreateMonitorRenderingParams(HMONITOR monitor);

		/// <summary>Creates a rendering parameters object with the specified properties.</summary>
		/// <param name="gamma">
		/// <para>Type: <c>FLOAT</c></para>
		/// <para>The gamma level to be set for the new rendering parameters object.</para>
		/// </param>
		/// <param name="enhancedContrast">
		/// <para>Type: <c>FLOAT</c></para>
		/// <para>The enhanced contrast level to be set for the new rendering parameters object.</para>
		/// </param>
		/// <param name="clearTypeLevel">
		/// <para>Type: <c>FLOAT</c></para>
		/// <para>The ClearType level to be set for the new rendering parameters object.</para>
		/// </param>
		/// <param name="pixelGeometry">
		/// <para>Type: <c>DWRITE_PIXEL_GEOMETRY</c></para>
		/// <para>
		/// Represents the internal structure of a device pixel (that is, the physical arrangement of red, green, and blue color
		/// components) that is assumed for purposes of rendering text.
		/// </para>
		/// </param>
		/// <param name="renderingMode">
		/// <para>Type: <c>DWRITE_RENDERING_MODE</c></para>
		/// <para>A value that represents the method (for example, ClearType natural quality) for rendering glyphs.</para>
		/// </param>
		/// <returns>
		/// <para>Type: <c>IDWriteRenderingParams**</c></para>
		/// <para>When this method returns, contains an address of a pointer to the newly created rendering parameters object.</para>
		/// </returns>
		// https://docs.microsoft.com/en-us/windows/win32/api/dwrite/nf-dwrite-idwritefactory-createcustomrenderingparams HRESULT
		// CreateCustomRenderingParams( FLOAT gamma, FLOAT enhancedContrast, FLOAT clearTypeLevel, DWRITE_PIXEL_GEOMETRY pixelGeometry,
		// DWRITE_RENDERING_MODE renderingMode, IDWriteRenderingParams **renderingParams );
		new IDWriteRenderingParams CreateCustomRenderingParams(float gamma, float enhancedContrast, float clearTypeLevel, DWRITE_PIXEL_GEOMETRY pixelGeometry, DWRITE_RENDERING_MODE renderingMode);

		/// <summary>Registers a font file loader with DirectWrite.</summary>
		/// <param name="fontFileLoader">
		/// <para>Type: <c>IDWriteFontFileLoader*</c></para>
		/// <para>Pointer to a IDWriteFontFileLoader object for a particular file resource type.</para>
		/// </param>
		/// <remarks>
		/// This function registers a font file loader with DirectWrite. The font file loader interface, which should be implemented by a
		/// singleton object, handles loading font file resources of a particular type from a key. A given instance can only be registered
		/// once. Succeeding attempts will return an error, indicating that it has already been registered. Note that font file loader
		/// implementations must not register themselves with DirectWrite inside their constructors, and must not unregister themselves
		/// inside their destructors, because registration and unregistraton operations increment and decrement the object reference count
		/// respectively. Instead, registration and unregistration with DirectWrite of font file loaders should be performed outside of the
		/// font file loader implementation.
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows/win32/api/dwrite/nf-dwrite-idwritefactory-registerfontfileloader HRESULT
		// RegisterFontFileLoader( IDWriteFontFileLoader *fontFileLoader );
		new void RegisterFontFileLoader([In] IDWriteFontFileLoader fontFileLoader);

		/// <summary>Unregisters a font file loader that was previously registered with the DirectWrite font system using RegisterFontFileLoader.</summary>
		/// <param name="fontFileLoader">
		/// <para>Type: <c>IDWriteFontFileLoader*</c></para>
		/// <para>Pointer to the file loader that was previously registered with the DirectWrite font system using RegisterFontFileLoader.</para>
		/// </param>
		/// <remarks>
		/// This function unregisters font file loader callbacks with the DirectWrite font system. You should implement the font file loader
		/// interface by a singleton object. Note that font file loader implementations must not register themselves with DirectWrite inside
		/// their constructors and must not unregister themselves in their destructors, because registration and unregistraton operations
		/// increment and decrement the object reference count respectively. Instead, registration and unregistration of font file loaders
		/// with DirectWrite should be performed outside of the font file loader implementation.
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows/win32/api/dwrite/nf-dwrite-idwritefactory-unregisterfontfileloader HRESULT
		// UnregisterFontFileLoader( IDWriteFontFileLoader *fontFileLoader );
		new void UnregisterFontFileLoader([In] IDWriteFontFileLoader fontFileLoader);

		/// <summary>Creates a text format object used for text layout.</summary>
		/// <param name="fontFamilyName">
		/// <para>Type: <c>const WCHAR*</c></para>
		/// <para>An array of characters that contains the name of the font family</para>
		/// </param>
		/// <param name="fontCollection">
		/// <para>Type: <c>IDWriteFontCollection*</c></para>
		/// <para>A pointer to a font collection object. When this is <c>NULL</c>, indicates the system font collection.</para>
		/// </param>
		/// <param name="fontWeight">
		/// <para>Type: <c>DWRITE_FONT_WEIGHT</c></para>
		/// <para>A value that indicates the font weight for the text object created by this method.</para>
		/// </param>
		/// <param name="fontStyle">
		/// <para>Type: <c>DWRITE_FONT_STYLE</c></para>
		/// <para>A value that indicates the font style for the text object created by this method.</para>
		/// </param>
		/// <param name="fontStretch">
		/// <para>Type: <c>DWRITE_FONT_STRETCH</c></para>
		/// <para>A value that indicates the font stretch for the text object created by this method.</para>
		/// </param>
		/// <param name="fontSize">
		/// <para>Type: <c>FLOAT</c></para>
		/// <para>The logical size of the font in DIP ("device-independent pixel") units. A DIP equals 1/96 inch.</para>
		/// </param>
		/// <param name="localeName">
		/// <para>Type: <c>const WCHAR*</c></para>
		/// <para>An array of characters that contains the locale name.</para>
		/// </param>
		/// <returns>
		/// <para>Type: <c>IDWriteTextFormat**</c></para>
		/// <para>
		/// When this method returns, contains an address of a pointer to a newly created text format object, or <c>NULL</c> in case of failure.
		/// </para>
		/// </returns>
		// https://docs.microsoft.com/en-us/windows/win32/api/dwrite/nf-dwrite-idwritefactory-createtextformat HRESULT CreateTextFormat(
		// WCHAR const *fontFamilyName, IDWriteFontCollection *fontCollection, DWRITE_FONT_WEIGHT fontWeight, DWRITE_FONT_STYLE fontStyle,
		// DWRITE_FONT_STRETCH fontStretch, FLOAT fontSize, WCHAR const *localeName, IDWriteTextFormat **textFormat );
		new IDWriteTextFormat CreateTextFormat([MarshalAs(UnmanagedType.LPWStr)] string fontFamilyName, [In, Optional] IDWriteFontCollection? fontCollection, DWRITE_FONT_WEIGHT fontWeight,
			DWRITE_FONT_STYLE fontStyle, DWRITE_FONT_STRETCH fontStretch, float fontSize, [MarshalAs(UnmanagedType.LPWStr)] string localeName);

		/// <summary>Creates a typography object for use in a text layout.</summary>
		/// <returns>
		/// <para>Type: <c>IDWriteTypography**</c></para>
		/// <para>
		/// When this method returns, contains the address of a pointer to a newly created typography object, or <c>NULL</c> in case of failure.
		/// </para>
		/// </returns>
		// https://docs.microsoft.com/en-us/windows/win32/api/dwrite/nf-dwrite-idwritefactory-createtypography HRESULT CreateTypography(
		// IDWriteTypography **typography );
		new IDWriteTypography CreateTypography();

		/// <summary>Creates an object that is used for interoperability with GDI.</summary>
		/// <returns>
		/// <para>Type: <c>IDWriteGdiInterop**</c></para>
		/// <para>
		/// When this method returns, contains an address of a pointer to a GDI interop object if successful, or <c>NULL</c> in case of failure.
		/// </para>
		/// </returns>
		// https://docs.microsoft.com/en-us/windows/win32/api/dwrite/nf-dwrite-idwritefactory-getgdiinterop HRESULT GetGdiInterop(
		// IDWriteGdiInterop **gdiInterop );
		new IDWriteGdiInterop GetGdiInterop();

		/// <summary>
		/// Takes a string, text format, and associated constraints, and produces an object that represents the fully analyzed and formatted result.
		/// </summary>
		/// <param name="string">
		/// <para>Type: <c>const WCHAR*</c></para>
		/// <para>
		/// An array of characters that contains the string to create a new IDWriteTextLayout object from. This array must be of length
		/// stringLength and can contain embedded <c>NULL</c> characters.
		/// </para>
		/// </param>
		/// <param name="stringLength">
		/// <para>Type: <c>UINT32</c></para>
		/// <para>The number of characters in the string.</para>
		/// </param>
		/// <param name="textFormat">
		/// <para>Type: <c>IDWriteTextFormat*</c></para>
		/// <para>A pointer to an object that indicates the format to apply to the string.</para>
		/// </param>
		/// <param name="maxWidth">
		/// <para>Type: <c>FLOAT</c></para>
		/// <para>The width of the layout box.</para>
		/// </param>
		/// <param name="maxHeight">
		/// <para>Type: <c>FLOAT</c></para>
		/// <para>The height of the layout box.</para>
		/// </param>
		/// <returns>
		/// <para>Type: <c>IDWriteTextLayout**</c></para>
		/// <para>When this method returns, contains an address of a pointer to the resultant text layout object.</para>
		/// </returns>
		// https://docs.microsoft.com/en-us/windows/win32/api/dwrite/nf-dwrite-idwritefactory-createtextlayout HRESULT CreateTextLayout(
		// WCHAR const *string, UINT32 stringLength, IDWriteTextFormat *textFormat, FLOAT maxWidth, FLOAT maxHeight, IDWriteTextLayout
		// **textLayout );
		new IDWriteTextLayout CreateTextLayout([MarshalAs(UnmanagedType.LPWStr)] string @string, uint stringLength, [In] IDWriteTextFormat textFormat, float maxWidth, float maxHeight);

		/// <summary>
		/// Takes a string, format, and associated constraints, and produces an object representing the result, formatted for a particular
		/// display resolution and measuring mode.
		/// </summary>
		/// <param name="string">
		/// <para>Type: <c>const WCHAR*</c></para>
		/// <para>
		/// An array of characters that contains the string to create a new IDWriteTextLayout object from. This array must be of length
		/// stringLength and can contain embedded <c>NULL</c> characters.
		/// </para>
		/// </param>
		/// <param name="stringLength">
		/// <para>Type: <c>UINT32</c></para>
		/// <para>The length of the string, in character count.</para>
		/// </param>
		/// <param name="textFormat">
		/// <para>Type: <c>IDWriteTextFormat*</c></para>
		/// <para>The text formatting object to apply to the string.</para>
		/// </param>
		/// <param name="layoutWidth">
		/// <para>Type: <c>FLOAT</c></para>
		/// <para>The width of the layout box.</para>
		/// </param>
		/// <param name="layoutHeight">
		/// <para>Type: <c>FLOAT</c></para>
		/// <para>The height of the layout box.</para>
		/// </param>
		/// <param name="pixelsPerDip">
		/// <para>Type: <c>FLOAT</c></para>
		/// <para>
		/// The number of physical pixels per DIP (device independent pixel). For example, if rendering onto a 96 DPI device pixelsPerDipis
		/// 1. If rendering onto a 120 DPI device pixelsPerDip is 1.25 (120/96).
		/// </para>
		/// </param>
		/// <param name="transform">
		/// <para>Type: <c>const DWRITE_MATRIX*</c></para>
		/// <para>
		/// An optional transform applied to the glyphs and their positions. This transform is applied after the scaling specifies the font
		/// size and pixels per DIP.
		/// </para>
		/// </param>
		/// <param name="useGdiNatural">
		/// <para>Type: <c>BOOL</c></para>
		/// <para>
		/// Instructs the text layout to use the same metrics as GDI bi-level text when set to <c>FALSE</c>. When set to <c>TRUE</c>,
		/// instructs the text layout to use the same metrics as text measured by GDI using a font created with <c>CLEARTYPE_NATURAL_QUALITY</c>.
		/// </para>
		/// </param>
		/// <returns>
		/// <para>Type: <c>IDWriteTextLayout**</c></para>
		/// <para>When this method returns, contains an address to the pointer of the resultant text layout object.</para>
		/// </returns>
		/// <remarks>
		/// The resulting text layout should only be used for the intended resolution, and for cases where text scalability is desired
		/// CreateTextLayout should be used instead.
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows/win32/api/dwrite/nf-dwrite-idwritefactory-creategdicompatibletextlayout HRESULT
		// CreateGdiCompatibleTextLayout( WCHAR const *string, UINT32 stringLength, IDWriteTextFormat *textFormat, FLOAT layoutWidth, FLOAT
		// layoutHeight, FLOAT pixelsPerDip, DWRITE_MATRIX const *transform, BOOL useGdiNatural, IDWriteTextLayout **textLayout );
		new IDWriteTextLayout CreateGdiCompatibleTextLayout([MarshalAs(UnmanagedType.LPWStr)] string @string, uint stringLength, [In] IDWriteTextFormat textFormat,
			float layoutWidth, float layoutHeight, float pixelsPerDip, [In, Optional] IntPtr transform, [MarshalAs(UnmanagedType.Bool)] bool useGdiNatural);

		/// <summary>Creates an inline object for trimming, using an ellipsis as the omission sign.</summary>
		/// <param name="textFormat">
		/// <para>Type: <c>IDWriteTextFormat*</c></para>
		/// <para>A text format object, created with CreateTextFormat, used for text layout.</para>
		/// </param>
		/// <returns>
		/// <para>Type: <c>IDWriteInlineObject**</c></para>
		/// <para>
		/// When this method returns, contains an address of a pointer to the omission (that is, ellipsis trimming) sign created by this method.
		/// </para>
		/// </returns>
		/// <remarks>
		/// The ellipsis will be created using the current settings of the format, including base font, style, and any effects. Alternate
		/// omission signs can be created by the application by implementing IDWriteInlineObject.
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows/win32/api/dwrite/nf-dwrite-idwritefactory-createellipsistrimmingsign HRESULT
		// CreateEllipsisTrimmingSign( IDWriteTextFormat *textFormat, IDWriteInlineObject **trimmingSign );
		new IDWriteInlineObject CreateEllipsisTrimmingSign([In] IDWriteTextFormat textFormat);

		/// <summary>Returns an interface for performing text analysis.</summary>
		/// <returns>
		/// <para>Type: <c>IDWriteTextAnalyzer**</c></para>
		/// <para>When this method returns, contains an address of a pointer to the newly created text analyzer object.</para>
		/// </returns>
		// https://docs.microsoft.com/en-us/windows/win32/api/dwrite/nf-dwrite-idwritefactory-createtextanalyzer HRESULT CreateTextAnalyzer(
		// IDWriteTextAnalyzer **textAnalyzer );
		new IDWriteTextAnalyzer CreateTextAnalyzer();

		/// <summary>
		/// Creates a number substitution object using a locale name, substitution method, and an indicator whether to ignore user overrides
		/// (use NLS defaults for the given culture instead).
		/// </summary>
		/// <param name="substitutionMethod">
		/// <para>Type: <c>DWRITE_NUMBER_SUBSTITUTION_METHOD</c></para>
		/// <para>A value that specifies how to apply number substitution on digits and related punctuation.</para>
		/// </param>
		/// <param name="localeName">
		/// <para>Type: <c>const WCHAR*</c></para>
		/// <para>The name of the locale to be used in the numberSubstitution object.</para>
		/// </param>
		/// <param name="ignoreUserOverride">
		/// <para>Type: <c>BOOL</c></para>
		/// <para>A Boolean flag that indicates whether to ignore user overrides.</para>
		/// </param>
		/// <returns>
		/// <para>Type: <c>IDWriteNumberSubstitution**</c></para>
		/// <para>When this method returns, contains an address to a pointer to the number substitution object created by this method.</para>
		/// </returns>
		// https://docs.microsoft.com/en-us/windows/win32/api/dwrite/nf-dwrite-idwritefactory-createnumbersubstitution HRESULT
		// CreateNumberSubstitution( DWRITE_NUMBER_SUBSTITUTION_METHOD substitutionMethod, WCHAR const *localeName, BOOL ignoreUserOverride,
		// IDWriteNumberSubstitution **numberSubstitution );
		new IDWriteNumberSubstitution CreateNumberSubstitution([In] DWRITE_NUMBER_SUBSTITUTION_METHOD substitutionMethod, [MarshalAs(UnmanagedType.LPWStr)] string localeName, [In][MarshalAs(UnmanagedType.Bool)] bool ignoreUserOverride);

		/// <summary>Creates a glyph run analysis object, which encapsulates information used to render a glyph run.</summary>
		/// <param name="glyphRun">
		/// <para>Type: <c>const DWRITE_GLYPH_RUN*</c></para>
		/// <para>A structure that contains the properties of the glyph run (font face, advances, and so on).</para>
		/// </param>
		/// <param name="pixelsPerDip">
		/// <para>Type: <c>FLOAT</c></para>
		/// <para>
		/// Number of physical pixels per DIP (device independent pixel). For example, if rendering onto a 96 DPI bitmap then pixelsPerDipis
		/// 1. If rendering onto a 120 DPI bitmap then pixelsPerDip is 1.25.
		/// </para>
		/// </param>
		/// <param name="transform">
		/// <para>Type: <c>const DWRITE_MATRIX*</c></para>
		/// <para>
		/// Optional transform applied to the glyphs and their positions. This transform is applied after the scaling specified the emSize
		/// and pixelsPerDip.
		/// </para>
		/// </param>
		/// <param name="renderingMode">
		/// <para>Type: <c>DWRITE_RENDERING_MODE</c></para>
		/// <para>
		/// A value that specifies the rendering mode, which must be one of the raster rendering modes (that is, not default and not outline).
		/// </para>
		/// </param>
		/// <param name="measuringMode">
		/// <para>Type: <c>DWRITE_MEASURING_MODE</c></para>
		/// <para>Specifies the measuring mode to use with glyphs.</para>
		/// </param>
		/// <param name="baselineOriginX">
		/// <para>Type: <c>FLOAT</c></para>
		/// <para>The horizontal position (X-coordinate) of the baseline origin, in DIPs.</para>
		/// </param>
		/// <param name="baselineOriginY">
		/// <para>Type: <c>FLOAT</c></para>
		/// <para>Vertical position (Y-coordinate) of the baseline origin, in DIPs.</para>
		/// </param>
		/// <returns>
		/// <para>Type: <c>IDWriteGlyphRunAnalysis**</c></para>
		/// <para>When this method returns, contains an address of a pointer to the newly created glyph run analysis object.</para>
		/// </returns>
		/// <remarks>
		/// <para>
		/// The glyph run analysis object contains the results of analyzing the glyph run, including the positions of all the glyphs and
		/// references to all of the rasterized glyphs in the font cache.
		/// </para>
		/// <para>Examples</para>
		/// <para>
		/// The following code example shows how to create a glyph run analysis object. In this example, an empty glyph run is being used.
		/// </para>
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows/win32/api/dwrite/nf-dwrite-idwritefactory-createglyphrunanalysis HRESULT
		// CreateGlyphRunAnalysis( DWRITE_GLYPH_RUN const *glyphRun, FLOAT pixelsPerDip, DWRITE_MATRIX const *transform,
		// DWRITE_RENDERING_MODE renderingMode, DWRITE_MEASURING_MODE measuringMode, FLOAT baselineOriginX, FLOAT baselineOriginY,
		// IDWriteGlyphRunAnalysis **glyphRunAnalysis );
		new IDWriteGlyphRunAnalysis CreateGlyphRunAnalysis(in DWRITE_GLYPH_RUN glyphRun, float pixelsPerDip, [In, Optional] IntPtr transform,
			DWRITE_RENDERING_MODE renderingMode, DWRITE_MEASURING_MODE measuringMode, float baselineOriginX, float baselineOriginY);

		/// <summary>Gets a font collection representing the set of EUDC (end-user defined characters) fonts.</summary>
		/// <param name="fontCollection">
		/// <para>Type: <b><c>IDWriteFontCollection</c>**</b></para>
		/// <para>The font collection to fill.</para>
		/// </param>
		/// <param name="checkForUpdates">
		/// <para>Type: <b>BOOL</b></para>
		/// <para>Whether to check for updates.</para>
		/// </param>
		/// <remarks>
		/// Note that if no EUDC is set on the system, the returned collection will be empty, meaning it will return success but
		/// GetFontFamilyCount will be zero.
		/// </remarks>
		// https://learn.microsoft.com/en-us/windows/win32/api/dwrite_1/nf-dwrite_1-idwritefactory1-geteudcfontcollection HRESULT
		// GetEudcFontCollection( [out] IDWriteFontCollection **fontCollection, BOOL checkForUpdates );
		void GetEudcFontCollection(out IDWriteFontCollection fontCollection, bool checkForUpdates = false);

		/// <summary>Creates a rendering parameters object with the specified properties.</summary>
		/// <param name="gamma">
		/// <para>Type: <b>FLOAT</b></para>
		/// <para>The gamma level to be set for the new rendering parameters object.</para>
		/// </param>
		/// <param name="enhancedContrast">
		/// <para>Type: <b>FLOAT</b></para>
		/// <para>The enhanced contrast level to be set for the new rendering parameters object.</para>
		/// </param>
		/// <param name="enhancedContrastGrayscale">
		/// <para>Type: <b>FLOAT</b></para>
		/// <para>The amount of contrast enhancement to use for grayscale antialiasing, zero or greater.</para>
		/// </param>
		/// <param name="clearTypeLevel">
		/// <para>Type: <b>FLOAT</b></para>
		/// <para>The ClearType level to be set for the new rendering parameters object.</para>
		/// </param>
		/// <param name="pixelGeometry">
		/// <para>Type: <b><c>DWRITE_PIXEL_GEOMETRY</c></b></para>
		/// <para>
		/// Represents the internal structure of a device pixel (that is, the physical arrangement of red, green, and blue color components)
		/// that is assumed for purposes of rendering text.
		/// </para>
		/// </param>
		/// <param name="renderingMode">
		/// <para>Type: <b><c>DWRITE_RENDERING_MODE</c></b></para>
		/// <para>A value that represents the method (for example, ClearType natural quality) for rendering glyphs.</para>
		/// </param>
		/// <returns>
		/// <para>Type: <b><c>IDWriteRenderingParams1</c>**</b></para>
		/// <para>When this method returns, contains an address of a pointer to the newly created rendering parameters object.</para>
		/// </returns>
		// https://learn.microsoft.com/en-us/windows/win32/api/dwrite_1/nf-dwrite_1-idwritefactory1-createcustomrenderingparams HRESULT
		// CreateCustomRenderingParams( FLOAT gamma, FLOAT enhancedContrast, FLOAT enhancedContrastGrayscale, FLOAT clearTypeLevel,
		// DWRITE_PIXEL_GEOMETRY pixelGeometry, DWRITE_RENDERING_MODE renderingMode, [out] IDWriteRenderingParams1 **renderingParams );
		IDWriteRenderingParams1 CreateCustomRenderingParams(float gamma, float enhancedContrast, float enhancedContrastGrayscale, float clearTypeLevel, DWRITE_PIXEL_GEOMETRY pixelGeometry, DWRITE_RENDERING_MODE renderingMode);
	}

	/// <summary>Represents a physical font in a font collection.</summary>
	// https://learn.microsoft.com/en-us/windows/win32/api/dwrite_1/nn-dwrite_1-idwritefont1
	[PInvokeData("dwrite_1.h", MSDNShortId = "NN:dwrite_1.IDWriteFont1")]
	[ComImport, Guid("acd16696-8c14-4f5d-877e-fe3fc1d32738"), InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
	public interface IDWriteFont1 : IDWriteFont
	{
		/// <summary>Gets the font family to which the specified font belongs.</summary>
		/// <returns>
		/// <para>Type: <c>IDWriteFontFamily**</c></para>
		/// <para>When this method returns, contains an address of a pointer to the font family object to which the specified font belongs.</para>
		/// </returns>
		// https://docs.microsoft.com/en-us/windows/win32/api/dwrite/nf-dwrite-idwritefont-getfontfamily HRESULT GetFontFamily(
		// IDWriteFontFamily **fontFamily );
		new IDWriteFontFamily GetFontFamily();

		/// <summary>Gets the weight, or stroke thickness, of the specified font.</summary>
		/// <returns>
		/// <para>Type: <c>DWRITE_FONT_WEIGHT</c></para>
		/// <para>A value that indicates the weight for the specified font.</para>
		/// </returns>
		// https://docs.microsoft.com/en-us/windows/win32/api/dwrite/nf-dwrite-idwritefont-getweight DWRITE_FONT_WEIGHT GetWeight();
		[PreserveSig]
		new DWRITE_FONT_WEIGHT GetWeight();

		/// <summary>Gets the stretch, or width, of the specified font.</summary>
		/// <returns>
		/// <para>Type: <c>DWRITE_FONT_STRETCH</c></para>
		/// <para>A value that indicates the type of stretch, or width, applied to the specified font.</para>
		/// </returns>
		// https://docs.microsoft.com/en-us/windows/win32/api/dwrite/nf-dwrite-idwritefont-getstretch DWRITE_FONT_STRETCH GetStretch();
		[PreserveSig]
		new DWRITE_FONT_STRETCH GetStretch();

		/// <summary>Gets the style, or slope, of the specified font.</summary>
		/// <returns>
		/// <para>Type: <c>DWRITE_FONT_STYLE</c></para>
		/// <para>A value that indicates the type of style, or slope, of the specified font.</para>
		/// </returns>
		// https://docs.microsoft.com/en-us/windows/win32/api/dwrite/nf-dwrite-idwritefont-getstyle DWRITE_FONT_STYLE GetStyle();
		[PreserveSig]
		new DWRITE_FONT_STYLE GetStyle();

		/// <summary>Determines whether the font is a symbol font.</summary>
		/// <returns>
		/// <para>Type: <c>BOOL</c></para>
		/// <para><c>TRUE</c> if the font is a symbol font; otherwise, <c>FALSE</c>.</para>
		/// </returns>
		// https://docs.microsoft.com/en-us/windows/win32/api/dwrite/nf-dwrite-idwritefont-issymbolfont BOOL IsSymbolFont();
		[PreserveSig]
		[return: MarshalAs(UnmanagedType.Bool)]
		new bool IsSymbolFont();

		/// <summary>
		/// Gets a localized strings collection containing the face names for the font (such as Regular or Bold), indexed by locale name.
		/// </summary>
		/// <returns>
		/// <para>Type: <c>IDWriteLocalizedStrings**</c></para>
		/// <para>When this method returns, contains an address to a pointer to the newly created localized strings object.</para>
		/// </returns>
		// https://docs.microsoft.com/en-us/windows/win32/api/dwrite/nf-dwrite-idwritefont-getfacenames HRESULT GetFaceNames(
		// IDWriteLocalizedStrings **names );
		new IDWriteLocalizedStrings GetFaceNames();

		/// <summary>Gets a localized strings collection containing the specified informational strings, indexed by locale name.</summary>
		/// <param name="informationalStringID">
		/// <para>Type: <c>DWRITE_INFORMATIONAL_STRING_ID</c></para>
		/// <para>
		/// A value that identifies the informational string to get. For example, DWRITE_INFORMATIONAL_STRING_DESCRIPTION specifies a string
		/// that contains a description of the font.
		/// </para>
		/// </param>
		/// <param name="informationalStrings">
		/// <para>Type: <c>IDWriteLocalizedStrings**</c></para>
		/// <para>When this method returns, contains an address of a pointer to the newly created localized strings object.</para>
		/// </param>
		/// <param name="exists">
		/// <para>Type: <c>BOOL*</c></para>
		/// <para>When this method returns, <c>TRUE</c> if the font contains the specified string ID; otherwise, <c>FALSE</c>.</para>
		/// </param>
		/// <remarks>
		/// If the font does not contain the string specified by informationalStringID, the return value is <c>S_OK</c> but
		/// informationalStrings receives a <c>NULL</c> pointer and exists receives the value <c>FALSE</c>.
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows/win32/api/dwrite/nf-dwrite-idwritefont-getinformationalstrings HRESULT
		// GetInformationalStrings( DWRITE_INFORMATIONAL_STRING_ID informationalStringID, IDWriteLocalizedStrings
		// **informationalStrings, BOOL *exists );
		new void GetInformationalStrings(DWRITE_INFORMATIONAL_STRING_ID informationalStringID, out IDWriteLocalizedStrings informationalStrings, [MarshalAs(UnmanagedType.Bool)] out bool exists);

		/// <summary>Gets a value that indicates what simulations are applied to the specified font.</summary>
		/// <returns>
		/// <para>Type: <c>DWRITE_FONT_SIMULATIONS</c></para>
		/// <para>A value that indicates one or more of the types of simulations (none, bold, or oblique) applied to the specified font.</para>
		/// </returns>
		// https://docs.microsoft.com/en-us/windows/win32/api/dwrite/nf-dwrite-idwritefont-getsimulations DWRITE_FONT_SIMULATIONS GetSimulations();
		[PreserveSig]
		new DWRITE_FONT_SIMULATIONS GetSimulations();

		/// <summary>
		/// Obtains design units and common metrics for the font face. These metrics are applicable to all the glyphs within a font face and
		/// are used by applications for layout calculations.
		/// </summary>
		/// <param name="fontMetrics">
		/// <para>Type: <c>DWRITE_FONT_METRICS*</c></para>
		/// <para>
		/// When this method returns, contains a structure that has font metrics for the current font face. The metrics returned by this
		/// function are in font design units.
		/// </para>
		/// </param>
		/// <returns>None</returns>
		// https://docs.microsoft.com/en-us/windows/win32/api/dwrite/nf-dwrite-idwritefont-getmetrics void GetMetrics( DWRITE_FONT_METRICS
		// *fontMetrics );
		[PreserveSig]
		new void GetMetrics(out DWRITE_FONT_METRICS fontMetrics);

		/// <summary>Determines whether the font supports a specified character.</summary>
		/// <param name="unicodeValue">
		/// <para>Type: <b>UINT32</b></para>
		/// <para>A Unicode (UCS-4) character value for the method to inspect.</para>
		/// </param>
		/// <param name="exists">
		/// <para>Type: <b>BOOL*</b></para>
		/// <para>When this method returns, <b>TRUE</b> if the font supports the specified character; otherwise, <b>FALSE</b>.</para>
		/// </param>
		/// <returns>
		/// <para>Type: <b>HRESULT</b></para>
		/// <para>If this method succeeds, it returns <b>S_OK</b>. Otherwise, it returns an <b>HRESULT</b> error code.</para>
		/// </returns>
		// https://learn.microsoft.com/en-us/windows/win32/api/dwrite/nf-dwrite-idwritefont-hascharacter
		// HRESULT HasCharacter( UINT32 unicodeValue, [out] BOOL *exists );
		[PreserveSig]
		new HRESULT HasCharacter(uint unicodeValue, [MarshalAs(UnmanagedType.Bool)] out bool exists);

		/// <summary>Creates a font face object for the font.</summary>
		/// <returns>
		/// <para>Type: <c>IDWriteFontFace**</c></para>
		/// <para>When this method returns, contains an address of a pointer to the newly created font face object.</para>
		/// </returns>
		// https://docs.microsoft.com/en-us/windows/win32/api/dwrite/nf-dwrite-idwritefont-createfontface HRESULT CreateFontFace(
		// IDWriteFontFace **fontFace );
		new IDWriteFontFace CreateFontFace();

		/// <summary><c>fontMetrics</c></summary>
		/// <param name="fontMetrics"/>
		/// <returns>None</returns>
		// https://learn.microsoft.com/en-us/windows/windows-app-sdk/api/win32/dwrite_1/nf-dwrite_1-idwritefont1-getmetrics void GetMetrics(
		// DWRITE_FONT_METRICS1 *fontMetrics );
		[PreserveSig]
		void GetMetrics(out DWRITE_FONT_METRICS1 fontMetrics);

		/// <summary>Gets the PANOSE values from the font and is used for font selection and matching.</summary>
		/// <param name="panose">
		/// <para>Type: <b><c>DWRITE_PANOSE</c>*</b></para>
		/// <para>A pointer to the <c>DWRITE_PANOSE</c> structure to fill in.</para>
		/// </param>
		/// <returns>None</returns>
		/// <remarks>If the font has no PANOSE values, they are set to 'any' (0) and <c>DirectWrite</c> doesn't simulate those values.</remarks>
		// https://learn.microsoft.com/en-us/windows/win32/api/dwrite_1/nf-dwrite_1-idwritefont1-getpanose void GetPanose( [out]
		// DWRITE_PANOSE *panose );
		[PreserveSig]
		void GetPanose(out DWRITE_PANOSE panose);

		/// <summary>Retrieves the list of character ranges supported by a font.</summary>
		/// <param name="maxRangeCount">
		/// <para>Type: <b>UINT32</b></para>
		/// <para>The maximum number of character ranges passed in from the client.</para>
		/// </param>
		/// <param name="unicodeRanges">
		/// <para>Type: <b><c>DWRITE_UNICODE_RANGE</c>*</b></para>
		/// <para>An array of <c>DWRITE_UNICODE_RANGE</c> structures that are filled with the character ranges.</para>
		/// </param>
		/// <param name="actualRangeCount">
		/// <para>Type: <b>UINT32*</b></para>
		/// <para>A pointer to the actual number of character ranges, regardless of the maximum count.</para>
		/// </param>
		/// <returns>
		/// <para>Type: <b>HRESULT</b></para>
		/// <para>This method can return one of these values.</para>
		/// <list type="table">
		/// <listheader>
		/// <description>Return value</description>
		/// <description>Description</description>
		/// </listheader>
		/// <item>
		/// <description>S_OK</description>
		/// <description>The method executed successfully.</description>
		/// </item>
		/// <item>
		/// <description>E_NOT_SUFFICIENT_BUFFER</description>
		/// <description>The buffer is too small. The <i>actualRangeCount</i> was more than the <i>maxRangeCount</i>.</description>
		/// </item>
		/// </list>
		/// </returns>
		/// <remarks>
		/// <para>
		/// The list of character ranges supported by a font, is useful for scenarios like character picking, glyph display, and efficient
		/// font selection lookup. GetUnicodeRanges is similar to GDI's GetFontUnicodeRanges, except that it returns the full Unicode range,
		/// not just 16-bit UCS-2.
		/// </para>
		/// <para>These ranges are from the cmap, not the OS/2::ulCodePageRange1.</para>
		/// <para>
		/// If this method is unavailable, you can use the <c>IDWriteFontFace::GetGlyphIndices</c> method to check for missing glyphs. The
		/// method returns the 0 index for glyphs that aren't present in the font.
		/// </para>
		/// <para>
		/// The <c>IDWriteFont::HasCharacter</c> method is often simpler in cases where you need to check a single character or a series of
		/// single characters in succession, such as in font fallback.
		/// </para>
		/// </remarks>
		// https://learn.microsoft.com/en-us/windows/win32/api/dwrite_1/nf-dwrite_1-idwritefont1-getunicoderanges HRESULT GetUnicodeRanges(
		// UINT32 maxRangeCount, [out, optional] DWRITE_UNICODE_RANGE *unicodeRanges, [out] UINT32 *actualRangeCount );
		void GetUnicodeRanges(int maxRangeCount, [Out, Optional, MarshalAs(UnmanagedType.LPArray, SizeParamIndex = 0)] DWRITE_UNICODE_RANGE[]? unicodeRanges,
			out uint actualRangeCount);

		/// <summary>Determines if the font is monospaced, that is, the characters are the same fixed-pitch width (non-proportional).</summary>
		/// <returns>
		/// <para>Type: <b>BOOL</b></para>
		/// <para>Returns true if the font is monospaced, else it returns false.</para>
		/// </returns>
		// https://learn.microsoft.com/en-us/windows/win32/api/dwrite_1/nf-dwrite_1-idwritefont1-ismonospacedfont BOOL IsMonospacedFont();
		[PreserveSig]
		bool IsMonospacedFont();
	}

	/// <summary>
	/// <para>
	/// Represents an absolute reference to a font face. This interface contains font face type, appropriate file references, and face
	/// identification data.
	/// </para>
	/// <para>
	/// This interface extends <c>IDWriteFontFace</c>. Various font data such as metrics, names, and glyph outlines are obtained from <b>IDWriteFontFace</b>.
	/// </para>
	/// </summary>
	// https://learn.microsoft.com/en-us/windows/win32/api/dwrite_1/nn-dwrite_1-idwritefontface1
	[PInvokeData("dwrite_1.h", MSDNShortId = "NN:dwrite_1.IDWriteFontFace1")]
	[ComImport, Guid("a71efdb4-9fdb-4838-ad90-cfc3be8c3daf"), InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
	public interface IDWriteFontFace1 : IDWriteFontFace
	{
		/// <summary>Obtains the file format type of a font face.</summary>
		/// <returns>
		/// <para>Type: <c>DWRITE_FONT_FACE_TYPE</c></para>
		/// <para>A value that indicates the type of format for the font face (such as Type 1, TrueType, vector, or bitmap).</para>
		/// </returns>
		// https://docs.microsoft.com/en-us/windows/win32/api/dwrite/nf-dwrite-idwritefontface-gettype DWRITE_FONT_FACE_TYPE GetType();
		[PreserveSig]
		new DWRITE_FONT_FACE_TYPE GetType();

		/// <summary>Obtains the font files representing a font face.</summary>
		/// <param name="numberOfFiles">
		/// <para>Type: <c>UINT32*</c></para>
		/// <para>
		/// If fontFiles is <c>NULL</c>, receives the number of files representing the font face. Otherwise, the number of font files being
		/// requested should be passed. See the Remarks section below for more information.
		/// </para>
		/// </param>
		/// <param name="fontFiles">
		/// <para>Type: <c>IDWriteFontFile**</c></para>
		/// <para>
		/// When this method returns, contains a pointer to a user-provided array that stores pointers to font files representing the font
		/// face. This parameter can be <c>NULL</c> if the user wants only the number of files representing the font face. This API
		/// increments reference count of the font file pointers returned according to COM conventions, and the client should release them
		/// when finished.
		/// </para>
		/// </param>
		/// <remarks>
		/// <para>
		/// The <c>IDWriteFontFace::GetFiles</c> method should be called twice. The first time you call <c>GetFiles</c> fontFiles should be
		/// <c>NULL</c>. When the method returns, numberOfFiles receives the number of font files that represent the font face.
		/// </para>
		/// <para>
		/// Then, call the method a second time, passing the numberOfFiles value that was output the first call, and a non-null buffer of
		/// the correct size to store the IDWriteFontFile pointers.
		/// </para>
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows/win32/api/dwrite/nf-dwrite-idwritefontface-getfiles HRESULT GetFiles( UINT32
		// *numberOfFiles, IDWriteFontFile **fontFiles );
		new void GetFiles(ref uint numberOfFiles, [Out, Optional, MarshalAs(UnmanagedType.LPArray, ArraySubType = UnmanagedType.Interface)] IDWriteFontFile[]? fontFiles);

		/// <summary>Obtains the index of a font face in the context of its font files.</summary>
		/// <returns>
		/// <para>Type: <c>UINT32</c></para>
		/// <para>
		/// The zero-based index of a font face in cases when the font files contain a collection of font faces. If the font files contain a
		/// single face, this value is zero.
		/// </para>
		/// </returns>
		// https://docs.microsoft.com/en-us/windows/win32/api/dwrite/nf-dwrite-idwritefontface-getindex UINT32 GetIndex();
		[PreserveSig]
		new uint GetIndex();

		/// <summary>Obtains the algorithmic style simulation flags of a font face.</summary>
		/// <returns>
		/// <para>Type: <c>DWRITE_FONT_SIMULATIONS</c></para>
		/// <para>Font face simulation flags for algorithmic means of making text bold or italic.</para>
		/// </returns>
		// https://docs.microsoft.com/en-us/windows/win32/api/dwrite/nf-dwrite-idwritefontface-getsimulations DWRITE_FONT_SIMULATIONS GetSimulations();
		[PreserveSig]
		new DWRITE_FONT_SIMULATIONS GetSimulations();

		/// <summary>Determines whether the font is a symbol font.</summary>
		/// <returns>
		/// <para>Type: <c>BOOL</c></para>
		/// <para>Returns <c>TRUE</c> if the font is a symbol font, otherwise <c>FALSE</c>.</para>
		/// </returns>
		// https://docs.microsoft.com/en-us/windows/win32/api/dwrite/nf-dwrite-idwritefontface-issymbolfont BOOL IsSymbolFont();
		[PreserveSig]
		[return: MarshalAs(UnmanagedType.Bool)]
		new bool IsSymbolFont();

		/// <summary>
		/// Obtains design units and common metrics for the font face. These metrics are applicable to all the glyphs within a font face and
		/// are used by applications for layout calculations.
		/// </summary>
		/// <param name="fontFaceMetrics">
		/// <para>Type: <c>DWRITE_FONT_METRICS*</c></para>
		/// <para>
		/// When this method returns, a DWRITE_FONT_METRICS structure that holds metrics (such as ascent, descent, or cap height) for the
		/// current font face element. The metrics returned by this function are in font design units.
		/// </para>
		/// </param>
		/// <returns>None</returns>
		// https://docs.microsoft.com/en-us/windows/win32/api/dwrite/nf-dwrite-idwritefontface-getmetrics void GetMetrics(
		// DWRITE_FONT_METRICS *fontFaceMetrics );
		[PreserveSig]
		new void GetMetrics(out DWRITE_FONT_METRICS fontFaceMetrics);

		/// <summary>Obtains the number of glyphs in the font face.</summary>
		/// <returns>
		/// <para>Type: <c>UINT16</c></para>
		/// <para>The number of glyphs in the font face.</para>
		/// </returns>
		// https://docs.microsoft.com/en-us/windows/win32/api/dwrite/nf-dwrite-idwritefontface-getglyphcount UINT16 GetGlyphCount();
		[PreserveSig]
		new ushort GetGlyphCount();

		/// <summary>Obtains ideal (resolution-independent) glyph metrics in font design units.</summary>
		/// <param name="glyphIndices">
		/// <para>Type: <c>const UINT16*</c></para>
		/// <para>
		/// An array of glyph indices for which to compute metrics. The array must contain at least as many elements as specified by glyphCount.
		/// </para>
		/// </param>
		/// <param name="glyphCount">
		/// <para>Type: <c>UINT32</c></para>
		/// <para>The number of elements in the glyphIndices array.</para>
		/// </param>
		/// <param name="glyphMetrics">
		/// <para>Type: <c>DWRITE_GLYPH_METRICS*</c></para>
		/// <para>
		/// When this method returns, contains an array of DWRITE_GLYPH_METRICS structures. glyphMetrics must be initialized with an empty
		/// buffer that contains at least as many elements as glyphCount. The metrics returned by this function are in font design units.
		/// </para>
		/// </param>
		/// <param name="isSideways">
		/// <para>Type: <c>BOOL</c></para>
		/// <para>
		/// Indicates whether the font is being used in a sideways run. This can affect the glyph metrics if the font has oblique simulation
		/// because sideways oblique simulation differs from non-sideways oblique simulation
		/// </para>
		/// </param>
		/// <remarks>Design glyph metrics are used for glyph positioning.</remarks>
		// https://docs.microsoft.com/en-us/windows/win32/api/dwrite/nf-dwrite-idwritefontface-getdesignglyphmetrics HRESULT
		// GetDesignGlyphMetrics( UINT16 const *glyphIndices, UINT32 glyphCount, DWRITE_GLYPH_METRICS *glyphMetrics, BOOL isSideways );
		new void GetDesignGlyphMetrics([In, MarshalAs(UnmanagedType.LPArray, SizeParamIndex = 1)] ushort[] glyphIndices, uint glyphCount,
			[Out, MarshalAs(UnmanagedType.LPArray, SizeParamIndex = 1)] DWRITE_GLYPH_METRICS[] glyphMetrics, [MarshalAs(UnmanagedType.Bool)] bool isSideways = false);

		/// <summary>Returns the nominal mapping of UCS4 Unicode code points to glyph indices as defined by the font 'CMAP' table.</summary>
		/// <param name="codePoints">
		/// <para>Type: <c>const UINT32*</c></para>
		/// <para>
		/// An array of USC4 code points from which to obtain nominal glyph indices. The array must be allocated and be able to contain the
		/// number of elements specified by codePointCount.
		/// </para>
		/// </param>
		/// <param name="codePointCount">
		/// <para>Type: <c>UINT32</c></para>
		/// <para>The number of elements in the codePoints array.</para>
		/// </param>
		/// <param name="glyphIndices">
		/// <para>Type: <c>UINT16*</c></para>
		/// <para>When this method returns, contains a pointer to an array of nominal glyph indices filled by this function.</para>
		/// </param>
		/// <remarks>
		/// <para>
		/// Note that this mapping is primarily provided for line layout engines built on top of the physical font API. Because of OpenType
		/// glyph substitution and line layout character substitution, the nominal conversion does not always correspond to how a Unicode
		/// string will map to glyph indices when rendering using a particular font face. Also, note that Unicode variant selectors provide
		/// for alternate mappings for character to glyph. This call will always return the default variant.
		/// </para>
		/// <para>
		/// When characters are not present in the font this method returns the index 0, which is the undefined glyph or ".notdef" glyph. If
		/// a character isn't in a font, IDWriteFont::HasCharacter returns false and GetUnicodeRanges doesn't return it in the range.
		/// </para>
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows/win32/api/dwrite/nf-dwrite-idwritefontface-getglyphindices HRESULT GetGlyphIndices(
		// UINT32 const *codePoints, UINT32 codePointCount, UINT16 *glyphIndices );
		new void GetGlyphIndices([In, MarshalAs(UnmanagedType.LPArray, SizeParamIndex = 1)] uint[] codePoints, uint codePointCount,
			[Out, MarshalAs(UnmanagedType.LPArray, SizeParamIndex = 1)] ushort[] glyphIndices);

		/// <summary>
		/// Finds the specified OpenType font table if it exists and returns a pointer to it. The function accesses the underlying font data
		/// through the IDWriteFontFileStream interface implemented by the font file loader.
		/// </summary>
		/// <param name="openTypeTableTag">
		/// <para>Type: <c>UINT32</c></para>
		/// <para>
		/// The four-character tag of a OpenType font table to find. Use the <c>DWRITE_MAKE_OPENTYPE_TAG</c> macro to create it as an
		/// <c>UINT32</c>. Unlike GDI, it does not support the special TTCF and null tags to access the whole font.
		/// </para>
		/// </param>
		/// <param name="tableData">
		/// <para>Type: <c>const void**</c></para>
		/// <para>
		/// When this method returns, contains the address of a pointer to the base of the table in memory. The pointer is valid only as
		/// long as the font face used to get the font table still exists; (not any other font face, even if it actually refers to the same
		/// physical font). This parameter is passed uninitialized.
		/// </para>
		/// </param>
		/// <param name="tableSize">
		/// <para>Type: <c>UINT32*</c></para>
		/// <para>When this method returns, contains a pointer to the size, in bytes, of the font table.</para>
		/// </param>
		/// <param name="tableContext">
		/// <para>Type: <c>void**</c></para>
		/// <para>
		/// When this method returns, the address of a pointer to the opaque context, which must be freed by calling ReleaseFontTable. The
		/// context actually comes from the lower-level IDWriteFontFileStream, which may be implemented by the application or DWrite itself.
		/// It is possible for a <c>NULL</c> tableContext to be returned, especially if the implementation performs direct memory mapping on
		/// the whole file. Nevertheless, always release it later, and do not use it as a test for function success. The same table can be
		/// queried multiple times, but because each returned context can be different, you must release each context separately.
		/// </para>
		/// </param>
		/// <param name="exists">
		/// <para>Type: <c>BOOL*</c></para>
		/// <para>When this method returns, <c>TRUE</c> if the font table exists; otherwise, <c>FALSE</c>.</para>
		/// </param>
		/// <returns>
		/// <para>Type: <c>HRESULT</c></para>
		/// <para>If this method succeeds, it returns <c>S_OK</c>. Otherwise, it returns an <c>HRESULT</c> error code.</para>
		/// </returns>
		/// <remarks>The context for the same tag may be different for each call, so each one must be held and released separately.</remarks>
		// https://docs.microsoft.com/en-us/windows/win32/api/dwrite/nf-dwrite-idwritefontface-trygetfonttable HRESULT TryGetFontTable(
		// UINT32 openTypeTableTag, const void **tableData, UINT32 *tableSize, void **tableContext, BOOL *exists );
		new HRESULT TryGetFontTable([In] uint openTypeTableTag, out IntPtr tableData, out uint tableSize, out IntPtr tableContext, [MarshalAs(UnmanagedType.Bool)] out bool exists);

		/// <summary>Releases the table obtained earlier from TryGetFontTable.</summary>
		/// <param name="tableContext">
		/// <para>Type: <c>void*</c></para>
		/// <para>A pointer to the opaque context from TryGetFontTable.</para>
		/// </param>
		/// <returns>None</returns>
		// https://docs.microsoft.com/en-us/windows/win32/api/dwrite/nf-dwrite-idwritefontface-releasefonttable void ReleaseFontTable( void
		// *tableContext );
		[PreserveSig]
		new void ReleaseFontTable([In] IntPtr tableContext);

		/// <summary>Computes the outline of a run of glyphs by calling back to the outline sink interface.</summary>
		/// <param name="emSize">
		/// <para>Type: <c>FLOAT</c></para>
		/// <para>The logical size of the font in DIP units. A DIP ("device-independent pixel") equals 1/96 inch.</para>
		/// </param>
		/// <param name="glyphIndices">
		/// <para>Type: <c>const UINT16*</c></para>
		/// <para>
		/// An array of glyph indices. The glyphs are in logical order and the advance direction depends on the isRightToLeft parameter. The
		/// array must be allocated and be able to contain the number of elements specified by glyphCount.
		/// </para>
		/// </param>
		/// <param name="glyphAdvances">
		/// <para>Type: <c>const FLOAT*</c></para>
		/// <para>
		/// An optional array of glyph advances in DIPs. The advance of a glyph is the amount to advance the position (in the direction of
		/// the baseline) after drawing the glyph. glyphAdvances contains the number of elements specified by glyphCount.
		/// </para>
		/// </param>
		/// <param name="glyphOffsets">
		/// <para>Type: <c>const DWRITE_GLYPH_OFFSET*</c></para>
		/// <para>
		/// An optional array of glyph offsets, each of which specifies the offset along the baseline and offset perpendicular to the
		/// baseline of a glyph relative to the current pen position. glyphOffsets contains the number of elements specified by glyphCount.
		/// </para>
		/// </param>
		/// <param name="glyphCount">
		/// <para>Type: <c>UINT32</c></para>
		/// <para>The number of glyphs in the run.</para>
		/// </param>
		/// <param name="isSideways">
		/// <para>Type: <c>BOOL</c></para>
		/// <para>
		/// If <c>TRUE</c>, the ascender of the glyph runs alongside the baseline. If <c>FALSE</c>, the glyph ascender runs perpendicular to
		/// the baseline. For example, an English alphabet on a vertical baseline would have isSideways set to <c>FALSE</c>.
		/// </para>
		/// <para>
		/// A client can render a vertical run by setting isSideways to <c>TRUE</c> and rotating the resulting geometry 90 degrees to the
		/// right using a transform. The isSideways and isRightToLeft parameters cannot both be true.
		/// </para>
		/// </param>
		/// <param name="isRightToLeft">
		/// <para>Type: <c>BOOL</c></para>
		/// <para>
		/// The visual order of the glyphs. If this parameter is <c>FALSE</c>, then glyph advances are from left to right. If <c>TRUE</c>,
		/// the advance direction is right to left. By default, the advance direction is left to right.
		/// </para>
		/// </param>
		/// <param name="geometrySink">
		/// <para>Type: <c>IDWriteGeometrySink*</c></para>
		/// <para>A pointer to the interface that is called back to perform outline drawing operations.</para>
		/// </param>
		// https://docs.microsoft.com/en-us/windows/win32/api/dwrite/nf-dwrite-idwritefontface-getglyphrunoutline HRESULT
		// GetGlyphRunOutline( FLOAT emSize, UINT16 const *glyphIndices, FLOAT const *glyphAdvances, DWRITE_GLYPH_OFFSET const
		// *glyphOffsets, UINT32 glyphCount, BOOL isSideways, BOOL isRightToLeft, IDWriteGeometrySink *geometrySink );
		new void GetGlyphRunOutline(float emSize, [In, MarshalAs(UnmanagedType.LPArray, SizeParamIndex = 4)] ushort[] glyphIndices,
			[In, Optional, MarshalAs(UnmanagedType.LPArray, SizeParamIndex = 4)] float[]? glyphAdvances,
			[In, Optional, MarshalAs(UnmanagedType.LPArray, SizeParamIndex = 4)] DWRITE_GLYPH_OFFSET[]? glyphOffsets,
			uint glyphCount, [MarshalAs(UnmanagedType.Bool)] bool isSideways, [MarshalAs(UnmanagedType.Bool)] bool isRightToLeft,
			[In, MarshalAs(UnmanagedType.Interface)] object geometrySink);

		/// <summary>Determines the recommended rendering mode for the font, using the specified size and rendering parameters.</summary>
		/// <param name="emSize">
		/// <para>Type: <c>FLOAT</c></para>
		/// <para>The logical size of the font in DIP units. A DIP ("device-independent pixel") equals 1/96 inch.</para>
		/// </param>
		/// <param name="pixelsPerDip">
		/// <para>Type: <c>FLOAT</c></para>
		/// <para>
		/// The number of physical pixels per DIP. For example, if the DPI of the rendering surface is 96, this value is 1.0f. If the DPI is
		/// 120, this value is 120.0f/96.
		/// </para>
		/// </param>
		/// <param name="measuringMode">
		/// <para>Type: <c>DWRITE_MEASURING_MODE</c></para>
		/// <para>
		/// The measuring method that will be used for glyphs in the font. Renderer implementations may choose different rendering modes for
		/// different measuring methods, for example:
		/// </para>
		/// <list type="bullet">
		/// <item>
		/// <term>DWRITE_RENDERING_MODE_CLEARTYPE_NATURAL for DWRITE_MEASURING_MODE_NATURAL</term>
		/// </item>
		/// <item>
		/// <term>DWRITE_RENDERING_MODE_CLEARTYPE_GDI_CLASSIC for DWRITE_MEASURING_MODE_GDI_CLASSIC</term>
		/// </item>
		/// <item>
		/// <term>DWRITE_RENDERING_MODE_CLEARTYPE_GDI_NATURAL for DWRITE_MEASURING_MODE_GDI_NATURAL</term>
		/// </item>
		/// </list>
		/// </param>
		/// <param name="renderingParams">
		/// <para>Type: <c>IDWriteRenderingParams*</c></para>
		/// <para>
		/// A pointer to an object that contains rendering settings such as gamma level, enhanced contrast, and ClearType level. This
		/// parameter is necessary in case the rendering parameters object overrides the rendering mode.
		/// </para>
		/// </param>
		/// <returns>
		/// <para>Type: <c>DWRITE_RENDERING_MODE*</c></para>
		/// <para>When this method returns, contains a value that indicates the recommended rendering mode to use.</para>
		/// </returns>
		// https://docs.microsoft.com/en-us/windows/win32/api/dwrite/nf-dwrite-idwritefontface-getrecommendedrenderingmode HRESULT
		// GetRecommendedRenderingMode( FLOAT emSize, FLOAT pixelsPerDip, DWRITE_MEASURING_MODE measuringMode, IDWriteRenderingParams
		// *renderingParams, DWRITE_RENDERING_MODE *renderingMode );
		new DWRITE_RENDERING_MODE GetRecommendedRenderingMode(float emSize, float pixelsPerDip, DWRITE_MEASURING_MODE measuringMode, IDWriteRenderingParams renderingParams);

		/// <summary>
		/// Obtains design units and common metrics for the font face. These metrics are applicable to all the glyphs within a fontface and
		/// are used by applications for layout calculations.
		/// </summary>
		/// <param name="emSize">
		/// <para>Type: <c>FLOAT</c></para>
		/// <para>The logical size of the font in DIP units.</para>
		/// </param>
		/// <param name="pixelsPerDip">
		/// <para>Type: <c>FLOAT</c></para>
		/// <para>The number of physical pixels per DIP.</para>
		/// </param>
		/// <param name="transform">
		/// <para>Type: <c>const DWRITE_MATRIX*</c></para>
		/// <para>
		/// An optional transform applied to the glyphs and their positions. This transform is applied after the scaling specified by the
		/// font size and pixelsPerDip.
		/// </para>
		/// </param>
		/// <returns>
		/// <para>Type: <c>DWRITE_FONT_METRICS*</c></para>
		/// <para>A pointer to a DWRITE_FONT_METRICS structure to fill in. The metrics returned by this function are in font design units.</para>
		/// </returns>
		// https://docs.microsoft.com/en-us/windows/win32/api/dwrite/nf-dwrite-idwritefontface-getgdicompatiblemetrics HRESULT
		// GetGdiCompatibleMetrics( FLOAT emSize, FLOAT pixelsPerDip, DWRITE_MATRIX const *transform, DWRITE_FONT_METRICS
		// *fontFaceMetrics );
		new DWRITE_FONT_METRICS GetGdiCompatibleMetrics(float emSize, float pixelsPerDip, [In, Optional] IntPtr transform);

		/// <summary>Obtains glyph metrics in font design units with the return values compatible with what GDI would produce.</summary>
		/// <param name="emSize">
		/// <para>Type: <c>FLOAT</c></para>
		/// <para>The ogical size of the font in DIP units.</para>
		/// </param>
		/// <param name="pixelsPerDip">
		/// <para>Type: <c>FLOAT</c></para>
		/// <para>The number of physical pixels per DIP.</para>
		/// </param>
		/// <param name="transform">
		/// <para>Type: <c>const DWRITE_MATRIX*</c></para>
		/// <para>
		/// An optional transform applied to the glyphs and their positions. This transform is applied after the scaling specified by the
		/// font size and pixelsPerDip.
		/// </para>
		/// </param>
		/// <param name="useGdiNatural">
		/// <para>Type: <c>BOOL</c></para>
		/// <para>
		/// When set to <c>FALSE</c>, the metrics are the same as the metrics of GDI aliased text. When set to <c>TRUE</c>, the metrics are
		/// the same as the metrics of text measured by GDI using a font created with <c>CLEARTYPE_NATURAL_QUALITY</c>.
		/// </para>
		/// </param>
		/// <param name="glyphIndices">
		/// <para>Type: <c>const UINT16*</c></para>
		/// <para>An array of glyph indices for which to compute the metrics.</para>
		/// </param>
		/// <param name="glyphCount">
		/// <para>Type: <c>UINT32</c></para>
		/// <para>The number of elements in the glyphIndices array.</para>
		/// </param>
		/// <param name="glyphMetrics">
		/// <para>Type: <c>DWRITE_GLYPH_METRICS*</c></para>
		/// <para>An array of DWRITE_GLYPH_METRICS structures filled by this function. The metrics are in font design units.</para>
		/// </param>
		/// <param name="isSideways">
		/// <para>Type: <c>BOOL</c></para>
		/// <para>
		/// A BOOL value that indicates whether the font is being used in a sideways run. This can affect the glyph metrics if the font has
		/// oblique simulation because sideways oblique simulation differs from non-sideways oblique simulation.
		/// </para>
		/// </param>
		// https://docs.microsoft.com/en-us/windows/win32/api/dwrite/nf-dwrite-idwritefontface-getgdicompatibleglyphmetrics HRESULT
		// GetGdiCompatibleGlyphMetrics( FLOAT emSize, FLOAT pixelsPerDip, DWRITE_MATRIX const *transform, BOOL useGdiNatural, UINT16 const
		// *glyphIndices, UINT32 glyphCount, DWRITE_GLYPH_METRICS *glyphMetrics, BOOL isSideways );
		new void GetGdiCompatibleGlyphMetrics(float emSize, float pixelsPerDip, [In, Optional] IntPtr transform, [MarshalAs(UnmanagedType.Bool)] bool useGdiNatural,
			[In, MarshalAs(UnmanagedType.LPArray, SizeParamIndex = 5)] ushort[] glyphIndices, uint glyphCount,
			[Out, MarshalAs(UnmanagedType.LPArray, SizeParamIndex = 5)] DWRITE_GLYPH_METRICS[] glyphMetrics, [MarshalAs(UnmanagedType.Bool)] bool isSideways = false);

		/// <summary>
		/// Obtains design units and common metrics for the font face. These metrics are applicable to all the glyphs within a font face and
		/// are used by applications for layout calculations.
		/// </summary>
		/// <param name="fontMetrics">
		/// <para>Type: <b><c>DWRITE_FONT_METRICS1</c>*</b></para>
		/// <para>
		/// A filled <c>DWRITE_FONT_METRICS1</c> structure that holds metrics for the current font face element. The metrics returned by
		/// this method are in font design units.
		/// </para>
		/// </param>
		/// <returns>None</returns>
		// https://learn.microsoft.com/en-us/windows/win32/api/dwrite_1/nf-dwrite_1-idwritefontface1-getmetrics void GetMetrics( [out]
		// DWRITE_FONT_METRICS1 *fontMetrics );
		[PreserveSig]
		void GetMetrics(out DWRITE_FONT_METRICS1 fontMetrics);

		/// <summary>
		/// Obtains design units and common metrics for the font face. These metrics are applicable to all the glyphs within a fontface and
		/// are used by applications for layout calculations.
		/// </summary>
		/// <param name="emSize">
		/// <para>Type: <b>FLOAT</b></para>
		/// <para>The logical size of the font in DIP units.</para>
		/// </param>
		/// <param name="pixelsPerDip">
		/// <para>Type: <b>FLOAT</b></para>
		/// <para>The number of physical pixels per DIP.</para>
		/// </param>
		/// <param name="transform">
		/// <para>Type: <b>const <c>DWRITE_MATRIX</c>*</b></para>
		/// <para>
		/// An optional transform applied to the glyphs and their positions. This transform is applied after the scaling specified by the
		/// font size and <i>pixelsPerDip</i>.
		/// </para>
		/// </param>
		/// <returns>
		/// <para>Type: <b><c>DWRITE_FONT_METRICS1</c>*</b></para>
		/// <para>
		/// A pointer to a <c>DWRITE_FONT_METRICS1</c> structure to fill in. The metrics returned by this function are in font design units.
		/// </para>
		/// </returns>
		// https://learn.microsoft.com/en-us/windows/win32/api/dwrite_1/nf-dwrite_1-idwritefontface1-getgdicompatiblemetrics HRESULT
		// GetGdiCompatibleMetrics( FLOAT emSize, FLOAT pixelsPerDip, [in, optional] DWRITE_MATRIX const *transform, [out]
		// DWRITE_FONT_METRICS1 *fontMetrics );
		DWRITE_FONT_METRICS1 GetGdiCompatibleMetrics(float emSize, float pixelsPerDip, [In, Optional] StructPointer<DWRITE_MATRIX> transform);

		/// <summary>Gets caret metrics for the font in design units.</summary>
		/// <param name="caretMetrics">
		/// <para>Type: <b>DWRITE_CARET_METRICS*</b></para>
		/// <para>A pointer to the <c>DWRITE_CARET_METRICS</c> structure that is filled.</para>
		/// </param>
		/// <returns>None</returns>
		/// <remarks>Caret metrics are used by text editors for drawing the correct caret placement and slant.</remarks>
		// https://learn.microsoft.com/en-us/windows/win32/api/dwrite_1/nf-dwrite_1-idwritefontface1-getcaretmetrics void GetCaretMetrics(
		// [out] DWRITE_CARET_METRICS *caretMetrics );
		[PreserveSig]
		void GetCaretMetrics(out DWRITE_CARET_METRICS caretMetrics);

		/// <summary>Retrieves a list of character ranges supported by a font.</summary>
		/// <param name="maxRangeCount">
		/// <para>Type: <b>UINT32</b></para>
		/// <para>Maximum number of character ranges passed in from the client.</para>
		/// </param>
		/// <param name="unicodeRanges">
		/// <para>Type: <b><c>DWRITE_UNICODE_RANGE</c>*</b></para>
		/// <para>An array of <c>DWRITE_UNICODE_RANGE</c> structures that are filled with the character ranges.</para>
		/// </param>
		/// <param name="actualRangeCount">
		/// <para>Type: <b>UINT32*</b></para>
		/// <para>A pointer to the actual number of character ranges, regardless of the maximum count.</para>
		/// </param>
		/// <remarks>
		/// <para>
		/// A list of character ranges supported by the font is useful for scenarios like character picking, glyph display, and efficient
		/// font selection lookup. This is similar to GDI's <c>GetFontUnicodeRanges</c>, except that it returns the full Unicode range, not
		/// just 16-bit UCS-2.
		/// </para>
		/// <para>These ranges are from the cmap, not the OS/2::ulCodePageRange1.</para>
		/// <para>
		/// If this method is unavailable, you can use the <c>IDWriteFontFace::GetGlyphIndices</c> method to check for missing glyphs. The
		/// method returns the 0 index for glyphs that aren't present in the font.
		/// </para>
		/// <para>
		/// The <c>IDWriteFont::HasCharacter</c> method is often simpler in cases where you need to check a single character or a series of
		/// single characters in succession, such as in font fallback.
		/// </para>
		/// </remarks>
		// https://learn.microsoft.com/en-us/windows/win32/api/dwrite_1/nf-dwrite_1-idwritefontface1-getunicoderanges HRESULT
		// GetUnicodeRanges( UINT32 maxRangeCount, [out, optional] DWRITE_UNICODE_RANGE *unicodeRanges, [out] UINT32 *actualRangeCount );
		void GetUnicodeRanges(int maxRangeCount, [Out, MarshalAs(UnmanagedType.LPArray, SizeParamIndex = 0)] DWRITE_UNICODE_RANGE[]? unicodeRanges, out uint actualRangeCount);

		/// <summary>
		/// Determines whether the font of a text range is monospaced, that is, the font characters are the same fixed-pitch width.
		/// </summary>
		/// <returns>
		/// <para>Type: <b>BOOL</b></para>
		/// <para>Returns TRUE if the font is monospaced, otherwise it returns FALSE.</para>
		/// </returns>
		// https://learn.microsoft.com/en-us/windows/win32/api/dwrite_1/nf-dwrite_1-idwritefontface1-ismonospacedfont BOOL IsMonospacedFont();
		[PreserveSig]
		bool IsMonospacedFont();

		/// <summary>Retrieves the advances in design units for a sequences of glyphs.</summary>
		/// <param name="glyphCount">
		/// <para>Type: <b>UINT32</b></para>
		/// <para>The number of glyphs to retrieve advances for.</para>
		/// </param>
		/// <param name="glyphIndices">
		/// <para>Type: <b>const UINT16*</b></para>
		/// <para>An array of glyph id's to retrieve advances for.</para>
		/// </param>
		/// <param name="glyphAdvances">
		/// <para>Type: <b>INT32*</b></para>
		/// <para>The returned advances in font design units for each glyph.</para>
		/// </param>
		/// <param name="isSideways">
		/// <para>Type: <b>BOOL</b></para>
		/// <para>Retrieve the glyph's vertical advance height rather than horizontal advance widths.</para>
		/// </param>
		/// <remarks>This is equivalent to calling GetGlyphMetrics and using only the advance width and height.</remarks>
		// https://learn.microsoft.com/en-us/windows/win32/api/dwrite_1/nf-dwrite_1-idwritefontface1-getdesignglyphadvances HRESULT
		// GetDesignGlyphAdvances( UINT32 glyphCount, [in] UINT16 const *glyphIndices, [out] INT32 *glyphAdvances, BOOL isSideways );
		void GetDesignGlyphAdvances(int glyphCount, [In, MarshalAs(UnmanagedType.LPArray, SizeParamIndex = 0)] ushort[] glyphIndices,
			[Out, MarshalAs(UnmanagedType.LPArray, SizeParamIndex = 0)] int[] glyphAdvances, bool isSideways = false);

		/// <summary>Returns the pixel-aligned advances for a sequences of glyphs.</summary>
		/// <param name="emSize">
		/// <para>Type: <b>FLOAT</b></para>
		/// <para>Logical size of the font in DIP units. A DIP ("device-independent pixel") equals 1/96 inch.</para>
		/// </param>
		/// <param name="pixelsPerDip">
		/// <para>Type: <b>FLOAT</b></para>
		/// <para>
		/// Number of physical pixels per DIP. For example, if the DPI of the rendering surface is 96 this value is 1.0f. If the DPI is 120,
		/// this value is 120.0f/96.
		/// </para>
		/// </param>
		/// <param name="transform">
		/// <para>Type: <b>const <c>DWRITE_MATRIX</c>*</b></para>
		/// <para>
		/// Optional transform applied to the glyphs and their positions. This transform is applied after the scaling specified by the font
		/// size and pixelsPerDip.
		/// </para>
		/// </param>
		/// <param name="useGdiNatural">
		/// <para>Type: <b>BOOL</b></para>
		/// <para>
		/// When FALSE, the metrics are the same as GDI aliased text (DWRITE_MEASURING_MODE_GDI_CLASSIC). When TRUE, the metrics are the
		/// same as those measured by GDI using a font using CLEARTYPE_NATURAL_QUALITY (DWRITE_MEASURING_MODE_GDI_NATURAL).
		/// </para>
		/// </param>
		/// <param name="isSideways">
		/// <para>Type: <b>BOOL</b></para>
		/// <para>Retrieve the glyph's vertical advances rather than horizontal advances.</para>
		/// </param>
		/// <param name="glyphCount">
		/// <para>Type: <b>UINT32</b></para>
		/// <para>Total glyphs to retrieve adjustments for.</para>
		/// </param>
		/// <param name="glyphIndices">
		/// <para>Type: <b>const UINT16*</b></para>
		/// <para>An array of glyph id's to retrieve advances.</para>
		/// </param>
		/// <param name="glyphAdvances">
		/// <para>Type: <b>const INT32*</b></para>
		/// <para>The returned advances in font design units for each glyph.</para>
		/// </param>
		/// <remarks>
		/// <para>This is equivalent to calling <c>GetGdiCompatibleGlyphMetrics</c> and using only the advance width and height.</para>
		/// <para>Like <c>GetGdiCompatibleGlyphMetrics</c>, these are in design units, meaning they must be scaled down by DWRITE_FONT_METRICS::designUnitsPerEm.</para>
		/// </remarks>
		// https://learn.microsoft.com/en-us/windows/win32/api/dwrite_1/nf-dwrite_1-idwritefontface1-getgdicompatibleglyphadvances HRESULT
		// GetGdiCompatibleGlyphAdvances( FLOAT emSize, FLOAT pixelsPerDip, [in, optional] DWRITE_MATRIX const *transform, BOOL
		// useGdiNatural, BOOL isSideways, UINT32 glyphCount, [in] UINT16 const *glyphIndices, [out] INT32 *glyphAdvances );
		void GetGdiCompatibleGlyphAdvances(float emSize, float pixelsPerDip, [In, Optional] StructPointer<DWRITE_MATRIX> transform, bool useGdiNatural,
			bool isSideways, int glyphCount, [In, MarshalAs(UnmanagedType.LPArray, SizeParamIndex = 5)] ushort[] glyphIndices,
			[Out, MarshalAs(UnmanagedType.LPArray, SizeParamIndex = 5)] int[] glyphAdvances);

		/// <summary>Retrieves the kerning pair adjustments from the font's kern table.</summary>
		/// <param name="glyphCount">
		/// <para>Type: <b>UINT32</b></para>
		/// <para>Number of glyphs to retrieve adjustments for.</para>
		/// </param>
		/// <param name="glyphIndices">
		/// <para>Type: <b>const UINT16*</b></para>
		/// <para>An array of glyph id's to retrieve adjustments for.</para>
		/// </param>
		/// <param name="glyphAdvanceAdjustments">
		/// <para>Type: <b>INT32*</b></para>
		/// <para>The advances, returned in font design units, for each glyph. The last glyph adjustment is zero.</para>
		/// </param>
		/// <remarks>
		/// <para>
		/// <b>GetKerningPairAdjustments</b> isn't a direct replacement for GDI's character based <c>GetKerningPairs</c>, but it serves the
		/// same role, without the client needing to cache them locally. <b>GetKerningPairAdjustments</b> also uses glyph id's directly
		/// rather than UCS-2 characters (how the kern table actually stores them), which avoids glyph collapse and ambiguity, such as the
		/// dash and hyphen, or space and non-breaking space.
		/// </para>
		/// <para>
		/// Newer fonts may have only GPOS kerning instead of the legacy pair-table kerning. Such fonts, like Gabriola, will only return 0's
		/// for adjustments. <b>GetKerningPairAdjustments</b> doesn't virtualize and flatten these GPOS entries into kerning pairs.
		/// </para>
		/// <para>
		/// You can realize a performance benefit by calling <c>IDWriteFontFace1::HasKerningPairs</c> to determine whether you need to call
		/// <b>GetKerningPairAdjustments</b>. If you previously called <b>IDWriteFontFace1::HasKerningPairs</b> and it returned FALSE, you
		/// can avoid calling <b>GetKerningPairAdjustments</b> because the font has no kerning pair-table entries. That is, in this
		/// situation, a call to <b>GetKerningPairAdjustments</b> would be a no-op.
		/// </para>
		/// </remarks>
		// https://learn.microsoft.com/en-us/windows/win32/api/dwrite_1/nf-dwrite_1-idwritefontface1-getkerningpairadjustments HRESULT
		// GetKerningPairAdjustments( UINT32 glyphCount, [in] UINT16 const *glyphIndices, [out] INT32 *glyphAdvanceAdjustments );
		void GetKerningPairAdjustments(int glyphCount, [In, MarshalAs(UnmanagedType.LPArray, SizeParamIndex = 0)] ushort[] glyphIndices,
			[Out, MarshalAs(UnmanagedType.LPArray, SizeParamIndex = 0)] int[] glyphAdvanceAdjustments);

		/// <summary>Determines whether the font supports pair-kerning.</summary>
		/// <returns>Returns TRUE if the font supports kerning pairs, otherwise FALSE.</returns>
		/// <remarks>
		/// If the font doesn't support pair table kerning, you don't need to call <c>IDWriteFontFace1::GetKerningPairAdjustments</c>
		/// because it would retrieve all zeroes.
		/// </remarks>
		// https://learn.microsoft.com/en-us/windows/win32/api/dwrite_1/nf-dwrite_1-idwritefontface1-haskerningpairs BOOL HasKerningPairs();
		[PreserveSig]
		bool HasKerningPairs();

		/// <summary>Determines the recommended rendering mode for the font, using the specified size and rendering parameters.</summary>
		/// <param name="fontEmSize">
		/// <para>Type: <b>FLOAT</b></para>
		/// <para>The logical size of the font in DIP units. A DIP ("device-independent pixel") equals 1/96 inch.</para>
		/// </param>
		/// <param name="dpiX">
		/// <para>Type: <b>FLOAT</b></para>
		/// <para>
		/// The number of physical pixels per DIP in a horizontal position. For example, if the DPI of the rendering surface is 96, this
		/// value is 1.0f. If the DPI is 120, this value is 120.0f/96.
		/// </para>
		/// </param>
		/// <param name="dpiY">
		/// <para>Type: <b>FLOAT</b></para>
		/// <para>
		/// The number of physical pixels per DIP in a vertical position. For example, if the DPI of the rendering surface is 96, this value
		/// is 1.0f. If the DPI is 120, this value is 120.0f/96.
		/// </para>
		/// </param>
		/// <param name="transform">
		/// <para>Type: <b>const DWRITE_MATRIX*</b></para>
		/// <para>Specifies the world transform.</para>
		/// </param>
		/// <param name="isSideways">
		/// <para>Type: <b>BOOL</b></para>
		/// <para>Whether the glyphs in the run are sideways or not.</para>
		/// </param>
		/// <param name="outlineThreshold">
		/// <para>Type: <b><c>DWRITE_OUTLINE_THRESHOLD</c></b></para>
		/// <para>
		/// A <c>DWRITE_OUTLINE_THRESHOLD</c>-typed value that specifies the quality of the graphics system's outline rendering, affects the
		/// size threshold above which outline rendering is used.
		/// </para>
		/// </param>
		/// <param name="measuringMode">
		/// <para>Type: <b><c>DWRITE_MEASURING_MODE</c></b></para>
		/// <para>
		/// The measuring method that will be used for glyphs in the font. Renderer implementations may choose different rendering modes for
		/// different measuring methods, for example:
		/// </para>
		/// <list type="bullet">
		/// <item>
		/// <description>DWRITE_RENDERING_MODE_CLEARTYPE_NATURAL for <c>DWRITE_MEASURING_MODE_NATURAL</c></description>
		/// </item>
		/// <item>
		/// <description>DWRITE_RENDERING_MODE_CLEARTYPE_GDI_CLASSIC for <c>DWRITE_MEASURING_MODE_GDI_CLASSIC</c></description>
		/// </item>
		/// <item>
		/// <description>DWRITE_RENDERING_MODE_CLEARTYPE_GDI_NATURAL for <c>DWRITE_MEASURING_MODE_GDI_NATURAL</c></description>
		/// </item>
		/// </list>
		/// </param>
		/// <returns>
		/// <para>Type: <b><c>DWRITE_RENDERING_MODE</c>*</b></para>
		/// <para>When this method returns, contains a value that indicates the recommended rendering mode to use.</para>
		/// </returns>
		/// <remarks>
		/// This method should be used to determine the actual rendering mode in cases where the rendering mode of the rendering params
		/// object is DWRITE_RENDERING_MODE_DEFAULT.
		/// </remarks>
		// https://learn.microsoft.com/en-us/windows/win32/api/dwrite_1/nf-dwrite_1-idwritefontface1-getrecommendedrenderingmode HRESULT
		// GetRecommendedRenderingMode( FLOAT fontEmSize, FLOAT dpiX, FLOAT dpiY, [in, optional] DWRITE_MATRIX const *transform, BOOL
		// isSideways, DWRITE_OUTLINE_THRESHOLD outlineThreshold, DWRITE_MEASURING_MODE measuringMode, [out] DWRITE_RENDERING_MODE
		// *renderingMode );
		DWRITE_RENDERING_MODE GetRecommendedRenderingMode(float fontEmSize, float dpiX, float dpiY, [In, Optional] StructPointer<DWRITE_MATRIX> transform,
			bool isSideways, DWRITE_OUTLINE_THRESHOLD outlineThreshold, DWRITE_MEASURING_MODE measuringMode);

		/// <summary>Retrieves the vertical forms of the nominal glyphs retrieved from GetGlyphIndices.</summary>
		/// <param name="glyphCount">
		/// <para>Type: <b>UINT32</b></para>
		/// <para>The number of glyphs to retrieve.</para>
		/// </param>
		/// <param name="nominalGlyphIndices">
		/// <para>Type: <b>const UINT16*</b></para>
		/// <para>Original glyph indices from cmap.</para>
		/// </param>
		/// <param name="verticalGlyphIndices">
		/// <para>Type: <b>UINT16*</b></para>
		/// <para>The vertical form of glyph indices.</para>
		/// </param>
		/// <remarks>
		/// <para>The retrieval uses the font's 'vert' table. This is used in CJK vertical layout so the correct characters are shown.</para>
		/// <para>
		/// Call <c>GetGlyphIndices</c> to get the nominal glyph indices, followed by calling this to remap the to the substituted forms,
		/// when the run is sideways, and the font has vertical glyph variants. See <c>HasVerticalGlyphVariants</c> for more info.
		/// </para>
		/// </remarks>
		// https://learn.microsoft.com/en-us/windows/win32/api/dwrite_1/nf-dwrite_1-idwritefontface1-getverticalglyphvariants HRESULT
		// GetVerticalGlyphVariants( UINT32 glyphCount, [in] UINT16 const *nominalGlyphIndices, [out] UINT16 *verticalGlyphIndices );
		void GetVerticalGlyphVariants(int glyphCount, [In, MarshalAs(UnmanagedType.LPArray, SizeParamIndex = 0)] ushort[] nominalGlyphIndices,
			[Out, MarshalAs(UnmanagedType.LPArray, SizeParamIndex = 0)] ushort[] verticalGlyphIndices);

		/// <summary>Determines whether the font has any vertical glyph variants.</summary>
		/// <returns>Returns TRUE if the font contains vertical glyph variants, otherwise FALSE.</returns>
		/// <remarks>
		/// <para>For OpenType fonts, <b>HasVerticalGlyphVariants</b> returns TRUE if the font contains a "vert"feature.</para>
		/// <para>
		/// <c>IDWriteFontFace1::GetVerticalGlyphVariants</c> retrieves the vertical forms of the nominal glyphs that are retrieved from <c>IDWriteFontFace::GetGlyphIndices</c>.
		/// </para>
		/// </remarks>
		// https://learn.microsoft.com/en-us/windows/win32/api/dwrite_1/nf-dwrite_1-idwritefontface1-hasverticalglyphvariants BOOL HasVerticalGlyphVariants();
		[PreserveSig]
		bool HasVerticalGlyphVariants();
	}

	/// <summary>Represents text rendering settings for glyph rasterization and filtering.</summary>
	// https://learn.microsoft.com/en-us/windows/win32/api/dwrite_1/nn-dwrite_1-idwriterenderingparams1
	[PInvokeData("dwrite_1.h", MSDNShortId = "NN:dwrite_1.IDWriteRenderingParams1")]
	[ComImport, Guid("94413cf4-a6fc-4248-8b50-6674348fcad3"), InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
	public interface IDWriteRenderingParams1 : IDWriteRenderingParams
	{
		/// <summary>Gets the gamma value used for gamma correction. Valid values must be greater than zero and cannot exceed 256.</summary>
		/// <returns>
		/// <para>Type: <c>FLOAT</c></para>
		/// <para>Returns the gamma value used for gamma correction. Valid values must be greater than zero and cannot exceed 256.</para>
		/// </returns>
		/// <remarks>The gamma value is used for gamma correction, which compensates for the non-linear luminosity response of most monitors.</remarks>
		// https://docs.microsoft.com/en-us/windows/win32/api/dwrite/nf-dwrite-idwriterenderingparams-getgamma FLOAT GetGamma();
		[PreserveSig]
		new float GetGamma();

		/// <summary>
		/// Gets the enhanced contrast property of the rendering parameters object. Valid values are greater than or equal to zero.
		/// </summary>
		/// <returns>
		/// <para>Type: <c>FLOAT</c></para>
		/// <para>Returns the amount of contrast enhancement. Valid values are greater than or equal to zero.</para>
		/// </returns>
		/// <remarks>
		/// Enhanced contrast is the amount to increase the darkness of text, and typically ranges from 0 to 1. Zero means no contrast enhancement.
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows/win32/api/dwrite/nf-dwrite-idwriterenderingparams-getenhancedcontrast FLOAT GetEnhancedContrast();
		[PreserveSig]
		new float GetEnhancedContrast();

		/// <summary>Gets the ClearType level of the rendering parameters object.</summary>
		/// <returns>
		/// <para>Type: <c>FLOAT</c></para>
		/// <para>The ClearType level of the rendering parameters object.</para>
		/// </returns>
		/// <remarks>
		/// The ClearType level represents the amount of ClearType – that is, the degree to which the red, green, and blue subpixels of each
		/// pixel are treated differently. Valid values range from zero (meaning no ClearType, which is equivalent to grayscale
		/// anti-aliasing) to one (meaning full ClearType)
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows/win32/api/dwrite/nf-dwrite-idwriterenderingparams-getcleartypelevel FLOAT GetClearTypeLevel();
		[PreserveSig]
		new float GetClearTypeLevel();

		/// <summary>Gets the pixel geometry of the rendering parameters object.</summary>
		/// <returns>
		/// <para>Type: <c>DWRITE_PIXEL_GEOMETRY</c></para>
		/// <para>A value that indicates the type of pixel geometry used in the rendering parameters object.</para>
		/// </returns>
		// https://docs.microsoft.com/en-us/windows/win32/api/dwrite/nf-dwrite-idwriterenderingparams-getpixelgeometry DWRITE_PIXEL_GEOMETRY GetPixelGeometry();
		[PreserveSig]
		new DWRITE_PIXEL_GEOMETRY GetPixelGeometry();

		/// <summary>Gets the rendering mode of the rendering parameters object.</summary>
		/// <returns>
		/// <para>Type: <c>DWRITE_RENDERING_MODE</c></para>
		/// <para>A value that indicates the rendering mode of the rendering parameters object.</para>
		/// </returns>
		/// <remarks>
		/// By default, the rendering mode is initialized to DWRITE_RENDERING_MODE_DEFAULT, which means the rendering mode is determined
		/// automatically based on the font and size. To determine the recommended rendering mode to use for a given font and size and
		/// rendering parameters object, use the IDWriteFontFace::GetRecommendedRenderingMode method.
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows/win32/api/dwrite/nf-dwrite-idwriterenderingparams-getrenderingmode DWRITE_RENDERING_MODE GetRenderingMode();
		[PreserveSig]
		new DWRITE_RENDERING_MODE GetRenderingMode();

		/// <summary>Gets the amount of contrast enhancement to use for grayscale antialiasing.</summary>
		/// <returns>
		/// <para>Type: <b>FLOAT</b></para>
		/// <para>The contrast enhancement value. Valid values are greater than or equal to zero.</para>
		/// </returns>
		// https://learn.microsoft.com/en-us/windows/win32/api/dwrite_1/nf-dwrite_1-idwriterenderingparams1-getgrayscaleenhancedcontrast
		// FLOAT GetGrayscaleEnhancedContrast();
		[PreserveSig]
		float GetGrayscaleEnhancedContrast();
	}

	/// <summary>The interface you implement to receive the output of the text analyzers.</summary>
	// https://learn.microsoft.com/en-us/windows/win32/api/dwrite_1/nn-dwrite_1-idwritetextanalysissink1
	[PInvokeData("dwrite_1.h", MSDNShortId = "NN:dwrite_1.IDWriteTextAnalysisSink1")]
	[ComImport, Guid("b0d941a0-85e7-4d8b-9fd3-5ced9934482a"), InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
	public interface IDWriteTextAnalysisSink1 : IDWriteTextAnalysisSink
	{
		/// <summary>Reports script analysis for the specified text range.</summary>
		/// <param name="textPosition">
		/// <para>Type: <c>UINT32</c></para>
		/// <para>The starting position from which to report.</para>
		/// </param>
		/// <param name="textLength">
		/// <para>Type: <c>UINT32</c></para>
		/// <para>The number of UTF16 units of the reported range.</para>
		/// </param>
		/// <param name="scriptAnalysis">
		/// <para>Type: <c>const DWRITE_SCRIPT_ANALYSIS*</c></para>
		/// <para>
		/// A pointer to a structure that contains a zero-based index representation of a writing system script and a value indicating
		/// whether additional shaping of text is required.
		/// </para>
		/// </param>
		/// <returns>
		/// <para>Type: <c>HRESULT</c></para>
		/// <para>A successful code or error code to stop analysis.</para>
		/// </returns>
		// https://docs.microsoft.com/en-us/windows/win32/api/dwrite/nf-dwrite-idwritetextanalysissink-setscriptanalysis HRESULT
		// SetScriptAnalysis( UINT32 textPosition, UINT32 textLength, DWRITE_SCRIPT_ANALYSIS const *scriptAnalysis );
		[PreserveSig]
		new HRESULT SetScriptAnalysis(uint textPosition, uint textLength, in DWRITE_SCRIPT_ANALYSIS scriptAnalysis);

		/// <summary>Sets line-break opportunities for each character, starting from the specified position.</summary>
		/// <param name="textPosition">
		/// <para>Type: <c>UINT32</c></para>
		/// <para>The starting text position from which to report.</para>
		/// </param>
		/// <param name="textLength">
		/// <para>Type: <c>UINT32</c></para>
		/// <para>The number of UTF16 units of the reported range.</para>
		/// </param>
		/// <param name="lineBreakpoints">
		/// <para>Type: <c>DWRITE_LINE_BREAKPOINT*</c></para>
		/// <para>
		/// A pointer to a structure that contains breaking conditions set for each character from the starting position to the end of the
		/// specified range.
		/// </para>
		/// </param>
		/// <returns>
		/// <para>Type: <c>HRESULT</c></para>
		/// <para>A successful code or error code to stop analysis.</para>
		/// </returns>
		// https://docs.microsoft.com/en-us/windows/win32/api/dwrite/nf-dwrite-idwritetextanalysissink-setlinebreakpoints HRESULT
		// SetLineBreakpoints( UINT32 textPosition, UINT32 textLength, DWRITE_LINE_BREAKPOINT const *lineBreakpoints );
		[PreserveSig]
		new HRESULT SetLineBreakpoints(uint textPosition, uint textLength, [In] DWRITE_LINE_BREAKPOINT[] lineBreakpoints);

		/// <summary>Sets a bidirectional level on the range, which is called once per run change (either explicit or resolved implicit).</summary>
		/// <param name="textPosition">
		/// <para>Type: <c>UINT32</c></para>
		/// <para>The starting position from which to report.</para>
		/// </param>
		/// <param name="textLength">
		/// <para>Type: <c>UINT32</c></para>
		/// <para>The number of UTF16 units of the reported range.</para>
		/// </param>
		/// <param name="explicitLevel">
		/// <para>Type: <c>UINT8</c></para>
		/// <para>
		/// The explicit level from the paragraph reading direction and any embedded control codes RLE/RLO/LRE/LRO/PDF, which is determined
		/// before any additional rules.
		/// </para>
		/// </param>
		/// <param name="resolvedLevel">
		/// <para>Type: <c>UINT8</c></para>
		/// <para>
		/// The final implicit level considering the explicit level and characters' natural directionality, after all Bidi rules have been applied.
		/// </para>
		/// </param>
		/// <returns>
		/// <para>Type: <c>HRESULT</c></para>
		/// <para>A successful code or error code to stop analysis.</para>
		/// </returns>
		// https://docs.microsoft.com/en-us/windows/win32/api/dwrite/nf-dwrite-idwritetextanalysissink-setbidilevel HRESULT SetBidiLevel(
		// UINT32 textPosition, UINT32 textLength, UINT8 explicitLevel, UINT8 resolvedLevel );
		[PreserveSig]
		new HRESULT SetBidiLevel(uint textPosition, uint textLength, byte explicitLevel, byte resolvedLevel);

		/// <summary>Sets the number substitution on the text range affected by the text analysis.</summary>
		/// <param name="textPosition">
		/// <para>Type: <c>UINT32</c></para>
		/// <para>The starting position from which to report.</para>
		/// </param>
		/// <param name="textLength">
		/// <para>Type: <c>UINT32</c></para>
		/// <para>The number of UTF16 units of the reported range.</para>
		/// </param>
		/// <param name="numberSubstitution">
		/// <para>Type: <c>IDWriteNumberSubstitution*</c></para>
		/// <para>
		/// An object that holds the appropriate digits and numeric punctuation for a given locale. Use
		/// IDWriteFactory::CreateNumberSubstitution to create this object.
		/// </para>
		/// </param>
		/// <returns>
		/// <para>Type: <c>HRESULT</c></para>
		/// <para>A successful code or error code to stop analysis.</para>
		/// </returns>
		// https://docs.microsoft.com/en-us/windows/win32/api/dwrite/nf-dwrite-idwritetextanalysissink-setnumbersubstitution HRESULT
		// SetNumberSubstitution( UINT32 textPosition, UINT32 textLength, IDWriteNumberSubstitution *numberSubstitution );
		[PreserveSig]
		new HRESULT SetNumberSubstitution(uint textPosition, uint textLength, [In] IDWriteNumberSubstitution numberSubstitution);

		/// <summary>The text analyzer calls back to this to report the actual orientation of each character for shaping and drawing.</summary>
		/// <param name="textPosition">
		/// <para>Type: <b>UINT32</b></para>
		/// <para>The starting position to report from.</para>
		/// </param>
		/// <param name="textLength">
		/// <para>Type: <b>UINT32</b></para>
		/// <para>Number of UTF-16 units of the reported range.</para>
		/// </param>
		/// <param name="glyphOrientationAngle">
		/// <para>Type: <b><c>DWRITE_GLYPH_ORIENTATION_ANGLE</c></b></para>
		/// <para>
		/// A <c>DWRITE_GLYPH_ORIENTATION_ANGLE</c>-typed value that specifies the angle of the glyphs within the text range (pass to
		/// <c>IDWriteTextAnalyzer1::GetGlyphOrientationTransform</c> to get the world relative transform).
		/// </para>
		/// </param>
		/// <param name="adjustedBidiLevel">
		/// <para>Type: <b>UINT8</b></para>
		/// <para>
		/// The adjusted bidi level to be used by the client layout for reordering runs. This will differ from the resolved bidi level
		/// retrieved from the source for cases such as Arabic stacked top-to-bottom, where the glyphs are still shaped as RTL, but the runs
		/// are TTB along with any CJK or Latin.
		/// </para>
		/// </param>
		/// <param name="isSideways">
		/// <para>Type: <b>BOOL</b></para>
		/// <para>Whether the glyphs are rotated on their side, which is the default case for CJK and the case stacked Latin</para>
		/// </param>
		/// <param name="isRightToLeft">
		/// <para>Type: <b>BOOL</b></para>
		/// <para>
		/// Whether the script should be shaped as right-to-left. For Arabic stacked top-to-bottom, even when the adjusted bidi level is
		/// coerced to an even level, this will still be true.
		/// </para>
		/// </param>
		// https://learn.microsoft.com/en-us/windows/win32/api/dwrite_1/nf-dwrite_1-idwritetextanalysissink1-setglyphorientation HRESULT
		// SetGlyphOrientation( UINT32 textPosition, UINT32 textLength, DWRITE_GLYPH_ORIENTATION_ANGLE glyphOrientationAngle, UINT8
		// adjustedBidiLevel, BOOL isSideways, BOOL isRightToLeft );
		[PreserveSig]
		HRESULT SetGlyphOrientation(uint textPosition, uint textLength, DWRITE_GLYPH_ORIENTATION_ANGLE glyphOrientationAngle,
			byte adjustedBidiLevel, bool isSideways, bool isRightToLeft);
	}

	/// <summary>
	/// <para>The interface you implement to provide needed information to the text analyzer, like the text and associated text properties.</para>
	/// <para>
	/// <b>Note</b>   If any of these callbacks return an error, the analysis functions will stop prematurely and return a callback error.
	/// </para>
	/// <para></para>
	/// </summary>
	// https://learn.microsoft.com/en-us/windows/win32/api/dwrite_1/nn-dwrite_1-idwritetextanalysissource1
	[PInvokeData("dwrite_1.h", MSDNShortId = "NN:dwrite_1.IDWriteTextAnalysisSource1")]
	[ComImport, Guid("639cfad8-0fb4-4b21-a58a-067920120009"), InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
	public interface IDWriteTextAnalysisSource1 : IDWriteTextAnalysisSource
	{
		/// <summary>Gets a block of text starting at the specified text position.</summary>
		/// <param name="textPosition">
		/// <para>Type: <c>UINT32</c></para>
		/// <para>
		/// The first position of the piece to obtain. All positions are in <c>UTF16</c> code units, not whole characters, which matters
		/// when supplementary characters are used.
		/// </para>
		/// </param>
		/// <param name="textString">
		/// <para>Type: <c>const WCHAR**</c></para>
		/// <para>
		/// When this method returns, contains an address of the block of text as an array of characters to be retrieved from the text analysis.
		/// </para>
		/// </param>
		/// <param name="textLength">
		/// <para>Type: <c>UINT32*</c></para>
		/// <para>
		/// When this method returns, contains the number of <c>UTF16</c> units of the retrieved chunk. The returned length is not the
		/// length of the block, but the length remaining in the block, from the specified position until its end. For example, querying for
		/// a position that is 75 positions into a 100-position block would return 25.
		/// </para>
		/// </param>
		/// <returns>
		/// <para>Type: <c>HRESULT</c></para>
		/// <para>If this method succeeds, it returns <c>S_OK</c>. Otherwise, it returns an <c>HRESULT</c> error code.</para>
		/// </returns>
		/// <remarks>
		/// <para>
		/// Returning <c>NULL</c> indicates the end of text, which is the position after the last character. This function is called
		/// iteratively for each consecutive block, tying together several fragmented blocks in the backing store into a virtual contiguous string.
		/// </para>
		/// <para>
		/// Although applications can implement sparse textual content that maps only part of the backing store, the application must map
		/// any text that is in the range passed to any analysis functions.
		/// </para>
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows/win32/api/dwrite/nf-dwrite-idwritetextanalysissource-gettextatposition HRESULT
		// GetTextAtPosition( UINT32 textPosition, WCHAR const **textString, UINT32 *textLength );
		new void GetTextAtPosition(uint textPosition, out StrPtrUni textString, out uint textLength);

		/// <summary>Gets a block of text immediately preceding the specified position.</summary>
		/// <param name="textPosition">
		/// <para>Type: <c>UINT32</c></para>
		/// <para>The position immediately after the last position of the block of text to obtain.</para>
		/// </param>
		/// <param name="textString">
		/// <para>Type: <c>const WCHAR**</c></para>
		/// <para>
		/// When this method returns, contains an address of a pointer to the block of text, as an array of characters from the specified
		/// range. The text range will be from textPosition to the front of the block.
		/// </para>
		/// </param>
		/// <param name="textLength">
		/// <para>Type: <c>UINT32*</c></para>
		/// <para>Number of UTF16 units of the retrieved block. The length returned is from the specified position to the front of the block.</para>
		/// </param>
		/// <returns>
		/// <para>Type: <c>HRESULT</c></para>
		/// <para>If this method succeeds, it returns <c>S_OK</c>. Otherwise, it returns an <c>HRESULT</c> error code.</para>
		/// </returns>
		/// <remarks>
		/// <para>
		/// NULL indicates no chunk available at the specified position, either because textPosition equals 0, textPosition is greater than
		/// the entire text content length, or the queried position is not mapped into the application's backing store.
		/// </para>
		/// <para>
		/// Although applications can implement sparse textual content that maps only part of the backing store, the application must map
		/// any text that is in the range passed to any analysis functions.
		/// </para>
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows/win32/api/dwrite/nf-dwrite-idwritetextanalysissource-gettextbeforeposition HRESULT
		// GetTextBeforePosition( UINT32 textPosition, WCHAR const **textString, UINT32 *textLength );
		new void GetTextBeforePosition(uint textPosition, out StrPtrUni textString, out uint textLength);

		/// <summary>Gets the paragraph reading direction.</summary>
		/// <returns>
		/// <para>Type: <c>DWRITE_READING_DIRECTION</c></para>
		/// <para>The reading direction of the current paragraph.</para>
		/// </returns>
		// https://docs.microsoft.com/en-us/windows/win32/api/dwrite/nf-dwrite-idwritetextanalysissource-getparagraphreadingdirection
		// DWRITE_READING_DIRECTION GetParagraphReadingDirection();
		[PreserveSig]
		new DWRITE_READING_DIRECTION GetParagraphReadingDirection();

		/// <summary>Gets the locale name on the range affected by the text analysis.</summary>
		/// <param name="textPosition">
		/// <para>Type: <c>UINT32</c></para>
		/// <para>The text position to examine.</para>
		/// </param>
		/// <param name="textLength">
		/// <para>Type: <c>UINT32*</c></para>
		/// <para>Contains the length of the text being affected by the text analysis up to the next differing locale.</para>
		/// </param>
		/// <param name="localeName">
		/// <para>Type: <c>const WCHAR**</c></para>
		/// <para>
		/// Contains an address of a pointer to an array of characters which receives the locale name from the text affected by the text
		/// analysis. The array of characters is null-terminated.
		/// </para>
		/// </param>
		/// <returns>
		/// <para>Type: <c>HRESULT</c></para>
		/// <para>If this method succeeds, it returns <c>S_OK</c>. Otherwise, it returns an <c>HRESULT</c> error code.</para>
		/// </returns>
		/// <remarks>The localeName pointer must remain valid until the next call or until the analysis returns.</remarks>
		// https://docs.microsoft.com/en-us/windows/win32/api/dwrite/nf-dwrite-idwritetextanalysissource-getlocalename HRESULT
		// GetLocaleName( UINT32 textPosition, UINT32 *textLength, WCHAR const **localeName );
		new void GetLocaleName(uint textPosition, out uint textLength, out StrPtrUni localeName);

		/// <summary>Gets the number substitution from the text range affected by the text analysis.</summary>
		/// <param name="textPosition">
		/// <para>Type: <c>UINT32</c></para>
		/// <para>The starting position from which to report.</para>
		/// </param>
		/// <param name="textLength">
		/// <para>Type: <c>UINT32*</c></para>
		/// <para>Contains the length of the text, in characters, remaining in the text range up to the next differing number substitution.</para>
		/// </param>
		/// <param name="numberSubstitution">
		/// <para>Type: <c>IDWriteNumberSubstitution**</c></para>
		/// <para>
		/// Contains an address of a pointer to an object, which was created with IDWriteFactory::CreateNumberSubstitution, that holds the
		/// appropriate digits and numeric punctuation for a given locale.
		/// </para>
		/// </param>
		/// <returns>
		/// <para>Type: <c>HRESULT</c></para>
		/// <para>If this method succeeds, it returns <c>S_OK</c>. Otherwise, it returns an <c>HRESULT</c> error code.</para>
		/// </returns>
		/// <remarks>
		/// Any implementation should return the number substitution with an incremented reference count, and the analysis will release when
		/// finished with it (either before the next call or before it returns). However, the sink callback may hold onto it after that.
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows/win32/api/dwrite/nf-dwrite-idwritetextanalysissource-getnumbersubstitution HRESULT
		// GetNumberSubstitution( UINT32 textPosition, UINT32 *textLength, IDWriteNumberSubstitution **numberSubstitution );
		new void GetNumberSubstitution(uint textPosition, out uint textLength, out IDWriteNumberSubstitution? numberSubstitution);

		/// <summary>Used by the text analyzer to obtain the desired glyph orientation and resolved bidi level.</summary>
		/// <param name="textPosition">
		/// <para>Type: <b>UINT32</b></para>
		/// <para>The text position.</para>
		/// </param>
		/// <param name="textLength">
		/// <para>Type: <b>UINT32*</b></para>
		/// <para>A pointer to the text length.</para>
		/// </param>
		/// <param name="glyphOrientation">
		/// <para>Type: <b><c>DWRITE_VERTICAL_GLYPH_ORIENTATION</c>*</b></para>
		/// <para>A <c>DWRITE_VERTICAL_GLYPH_ORIENTATION</c>-typed value that specifies the desired kind of glyph orientation for the text.</para>
		/// </param>
		/// <param name="bidiLevel">
		/// <para>Type: <b>UINT8*</b></para>
		/// <para>A pointer to the resolved bidi level.</para>
		/// </param>
		/// <remarks>
		/// The text analyzer calls back to this to get the desired glyph orientation and resolved bidi level, which it uses along with the
		/// script properties of the text to determine the actual orientation of each character, which it reports back to the client via the
		/// sink SetGlyphOrientation method.
		/// </remarks>
		// https://learn.microsoft.com/en-us/windows/win32/api/dwrite_1/nf-dwrite_1-idwritetextanalysissource1-getverticalglyphorientation
		// HRESULT GetVerticalGlyphOrientation( UINT32 textPosition, [out] UINT32 *textLength, [out] DWRITE_VERTICAL_GLYPH_ORIENTATION
		// *glyphOrientation, [out] UINT8 *bidiLevel );
		void GetVerticalGlyphOrientation(uint textPosition, out uint textLength, out DWRITE_VERTICAL_GLYPH_ORIENTATION glyphOrientation, out byte bidiLevel);
	}

	/// <summary>Analyzes various text properties for complex script processing.</summary>
	// https://learn.microsoft.com/en-us/windows/win32/api/dwrite_1/nn-dwrite_1-idwritetextanalyzer1
	[PInvokeData("dwrite_1.h", MSDNShortId = "NN:dwrite_1.IDWriteTextAnalyzer1")]
	[ComImport, Guid("80dad800-e21f-4e83-96ce-bfcce500db7c"), InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
	public interface IDWriteTextAnalyzer1 : IDWriteTextAnalyzer
	{
		/// <summary>
		/// Analyzes a text range for script boundaries, reading text attributes from the source and reporting the Unicode script ID to the
		/// sink callback SetScript.
		/// </summary>
		/// <param name="analysisSource">
		/// <para>Type: <c>IDWriteTextAnalysisSource*</c></para>
		/// <para>A pointer to the source object to analyze.</para>
		/// </param>
		/// <param name="textPosition">
		/// <para>Type: <c>UINT32</c></para>
		/// <para>The starting text position within the source object.</para>
		/// </param>
		/// <param name="textLength">
		/// <para>Type: <c>UINT32</c></para>
		/// <para>The text length to analyze.</para>
		/// </param>
		/// <param name="analysisSink">
		/// <para>Type: <c>IDWriteTextAnalysisSink*</c></para>
		/// <para>A pointer to the sink callback object that receives the text analysis.</para>
		/// </param>
		// https://docs.microsoft.com/en-us/windows/win32/api/dwrite/nf-dwrite-idwritetextanalyzer-analyzescript HRESULT AnalyzeScript(
		// IDWriteTextAnalysisSource *analysisSource, UINT32 textPosition, UINT32 textLength, IDWriteTextAnalysisSink *analysisSink );
		new void AnalyzeScript([In] IDWriteTextAnalysisSource analysisSource, uint textPosition, uint textLength, [In] IDWriteTextAnalysisSink analysisSink);

		/// <summary>
		/// Analyzes a text range for script directionality, reading attributes from the source and reporting levels to the sink callback SetBidiLevel.
		/// </summary>
		/// <param name="analysisSource">
		/// <para>Type: <c>IDWriteTextAnalysisSource*</c></para>
		/// <para>A pointer to a source object to analyze.</para>
		/// </param>
		/// <param name="textPosition">
		/// <para>Type: <c>UINT32</c></para>
		/// <para>The starting text position within the source object.</para>
		/// </param>
		/// <param name="textLength">
		/// <para>Type: <c>UINT32</c></para>
		/// <para>The text length to analyze.</para>
		/// </param>
		/// <param name="analysisSink">
		/// <para>Type: <c>IDWriteTextAnalysisSink*</c></para>
		/// <para>A pointer to the sink callback object that receives the text analysis.</para>
		/// </param>
		/// <remarks>
		/// While the function can handle multiple paragraphs, the text range should not arbitrarily split the middle of paragraphs.
		/// Otherwise, the returned levels may be wrong, because the Bidi algorithm is meant to apply to the paragraph as a whole.
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows/win32/api/dwrite/nf-dwrite-idwritetextanalyzer-analyzebidi HRESULT AnalyzeBidi(
		// IDWriteTextAnalysisSource *analysisSource, UINT32 textPosition, UINT32 textLength, IDWriteTextAnalysisSink *analysisSink );
		new void AnalyzeBidi([In] IDWriteTextAnalysisSource analysisSource, uint textPosition, uint textLength, [In] IDWriteTextAnalysisSink analysisSink);

		/// <summary>
		/// Analyzes a text range for spans where number substitution is applicable, reading attributes from the source and reporting
		/// substitutable ranges to the sink callback SetNumberSubstitution.
		/// </summary>
		/// <param name="analysisSource">
		/// <para>Type: <c>IDWriteTextAnalysisSource*</c></para>
		/// <para>The source object to analyze.</para>
		/// </param>
		/// <param name="textPosition">
		/// <para>Type: <c>UINT32</c></para>
		/// <para>The starting position within the source object.</para>
		/// </param>
		/// <param name="textLength">
		/// <para>Type: <c>UINT32</c></para>
		/// <para>The length to analyze.</para>
		/// </param>
		/// <param name="analysisSink">
		/// <para>Type: <c>IDWriteTextAnalysisSink*</c></para>
		/// <para>A pointer to the sink callback object that receives the text analysis.</para>
		/// </param>
		/// <remarks>
		/// Although the function can handle multiple ranges of differing number substitutions, the text ranges should not arbitrarily split
		/// the middle of numbers. Otherwise, it will treat the numbers separately and will not translate any intervening punctuation.
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows/win32/api/dwrite/nf-dwrite-idwritetextanalyzer-analyzenumbersubstitution HRESULT
		// AnalyzeNumberSubstitution( IDWriteTextAnalysisSource *analysisSource, UINT32 textPosition, UINT32 textLength,
		// IDWriteTextAnalysisSink *analysisSink );
		new void AnalyzeNumberSubstitution([In] IDWriteTextAnalysisSource analysisSource, uint textPosition, uint textLength, [In] IDWriteTextAnalysisSink analysisSink);

		/// <summary>
		/// Analyzes a text range for potential breakpoint opportunities, reading attributes from the source and reporting breakpoint
		/// opportunities to the sink callback SetLineBreakpoints.
		/// </summary>
		/// <param name="analysisSource">
		/// <para>Type: <c>IDWriteTextAnalysisSource*</c></para>
		/// <para>A pointer to the source object to analyze.</para>
		/// </param>
		/// <param name="textPosition">
		/// <para>Type: <c>UINT32</c></para>
		/// <para>The starting text position within the source object.</para>
		/// </param>
		/// <param name="textLength">
		/// <para>Type: <c>UINT32</c></para>
		/// <para>The text length to analyze.</para>
		/// </param>
		/// <param name="analysisSink">
		/// <para>Type: <c>IDWriteTextAnalysisSink*</c></para>
		/// <para>A pointer to the sink callback object that receives the text analysis.</para>
		/// </param>
		/// <remarks>
		/// Although the function can handle multiple paragraphs, the text range should not arbitrarily split the middle of paragraphs,
		/// unless the specified text span is considered a whole unit. Otherwise, the returned properties for the first and last characters
		/// will inappropriately allow breaks.
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows/win32/api/dwrite/nf-dwrite-idwritetextanalyzer-analyzelinebreakpoints HRESULT
		// AnalyzeLineBreakpoints( IDWriteTextAnalysisSource *analysisSource, UINT32 textPosition, UINT32 textLength,
		// IDWriteTextAnalysisSink *analysisSink );
		new void AnalyzeLineBreakpoints([In] IDWriteTextAnalysisSource analysisSource, uint textPosition, uint textLength, [In] IDWriteTextAnalysisSink analysisSink);

		/// <summary>
		/// Parses the input text string and maps it to the set of glyphs and associated glyph data according to the font and the writing
		/// system's rendering rules.
		/// </summary>
		/// <param name="textString">
		/// <para>Type: <c>const WCHAR*</c></para>
		/// <para>An array of characters to convert to glyphs.</para>
		/// </param>
		/// <param name="textLength">
		/// <para>Type: <c>UINT32</c></para>
		/// <para>The length of textString.</para>
		/// </param>
		/// <param name="fontFace">
		/// <para>Type: <c>IDWriteFontFace*</c></para>
		/// <para>The font face that is the source of the output glyphs.</para>
		/// </param>
		/// <param name="isSideways">
		/// <para>Type: <c>BOOL</c></para>
		/// <para>A Boolean flag set to <c>TRUE</c> if the text is intended to be drawn vertically.</para>
		/// </param>
		/// <param name="isRightToLeft">
		/// <para>Type: <c>BOOL</c></para>
		/// <para>A Boolean flag set to <c>TRUE</c> for right-to-left text.</para>
		/// </param>
		/// <param name="scriptAnalysis">
		/// <para>Type: <c>const DWRITE_SCRIPT_ANALYSIS*</c></para>
		/// <para>A pointer to a Script analysis result from an AnalyzeScript call.</para>
		/// </param>
		/// <param name="localeName">
		/// <para>Type: <c>const WCHAR*</c></para>
		/// <para>
		/// The locale to use when selecting glyphs. For example the same character may map to different glyphs for ja-jp versus zh-chs. If
		/// this is <c>NULL</c>, then the default mapping based on the script is used.
		/// </para>
		/// </param>
		/// <param name="numberSubstitution">
		/// <para>Type: <c>IDWriteNumberSubstitution*</c></para>
		/// <para>
		/// A pointer to an optional number substitution which selects the appropriate glyphs for digits and related numeric characters,
		/// depending on the results obtained from AnalyzeNumberSubstitution. Passing <c>NULL</c> indicates that no substitution is needed
		/// and that the digits should receive nominal glyphs.
		/// </para>
		/// </param>
		/// <param name="features">
		/// <para>Type: <c>const DWRITE_TYPOGRAPHIC_FEATURES**</c></para>
		/// <para>An array of pointers to the sets of typographic features to use in each feature range.</para>
		/// </param>
		/// <param name="featureRangeLengths">
		/// <para>Type: <c>const UINT32*</c></para>
		/// <para>The length of each feature range, in characters. The sum of all lengths should be equal to textLength.</para>
		/// </param>
		/// <param name="featureRanges">
		/// <para>Type: <c>UINT32</c></para>
		/// <para>The number of feature ranges.</para>
		/// </param>
		/// <param name="maxGlyphCount">
		/// <para>Type: <c>UINT32</c></para>
		/// <para>The maximum number of glyphs that can be returned.</para>
		/// </param>
		/// <param name="clusterMap">
		/// <para>Type: <c>UINT16*</c></para>
		/// <para>When this method returns, contains the mapping from character ranges to glyph ranges.</para>
		/// </param>
		/// <param name="textProps">
		/// <para>Type: <c>DWRITE_SHAPING_TEXT_PROPERTIES*</c></para>
		/// <para>When this method returns, contains a pointer to an array of structures that contains shaping properties for each character.</para>
		/// </param>
		/// <param name="glyphIndices">
		/// <para>Type: <c>UINT16*</c></para>
		/// <para>The output glyph indices.</para>
		/// </param>
		/// <param name="glyphProps">
		/// <para>Type: <c>DWRITE_SHAPING_GLYPH_PROPERTIES*</c></para>
		/// <para>
		/// When this method returns, contains a pointer to an array of structures that contain shaping properties for each output glyph.
		/// </para>
		/// </param>
		/// <param name="actualGlyphCount">
		/// <para>Type: <c>UINT32*</c></para>
		/// <para>When this method returns, contains the actual number of glyphs returned if the call succeeds.</para>
		/// </param>
		/// <remarks>
		/// Note that the mapping from characters to glyphs is, in general, many-to-many. The recommended estimate for the per-glyph output
		/// buffers is (3 * textLength / 2 + 16). This is not guaranteed to be sufficient.
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows/win32/api/dwrite/nf-dwrite-idwritetextanalyzer-getglyphs HRESULT GetGlyphs( WCHAR const
		// *textString, UINT32 textLength, IDWriteFontFace *fontFace, BOOL isSideways, BOOL isRightToLeft, DWRITE_SCRIPT_ANALYSIS const
		// *scriptAnalysis, WCHAR const *localeName, IDWriteNumberSubstitution *numberSubstitution, DWRITE_TYPOGRAPHIC_FEATURES const
		// **features, UINT32 const *featureRangeLengths, UINT32 featureRanges, UINT32 maxGlyphCount, UINT16 *clusterMap,
		// DWRITE_SHAPING_TEXT_PROPERTIES *textProps, UINT16 *glyphIndices, DWRITE_SHAPING_GLYPH_PROPERTIES *glyphProps, UINT32
		// *actualGlyphCount );
		new void GetGlyphs([MarshalAs(UnmanagedType.LPWStr)] string textString, uint textLength, [In] IDWriteFontFace fontFace,
			[MarshalAs(UnmanagedType.Bool)] bool isSideways, [MarshalAs(UnmanagedType.Bool)] bool isRightToLeft,
			in DWRITE_SCRIPT_ANALYSIS scriptAnalysis, [MarshalAs(UnmanagedType.LPWStr)] string localeName,
			[In, Optional] IDWriteNumberSubstitution? numberSubstitution, [In, Optional, MarshalAs(UnmanagedType.LPArray)] DWRITE_TYPOGRAPHIC_FEATURES[]? features,
			[In, Optional] uint[]? featureRangeLengths, uint featureRanges, uint maxGlyphCount, [Out, MarshalAs(UnmanagedType.LPArray)] ushort[] clusterMap,
			[Out, MarshalAs(UnmanagedType.LPArray)] DWRITE_SHAPING_TEXT_PROPERTIES[] textProps, [Out, MarshalAs(UnmanagedType.LPArray)] ushort[] glyphIndices,
			[Out, MarshalAs(UnmanagedType.LPArray)] DWRITE_SHAPING_GLYPH_PROPERTIES[] glyphProps, out uint actualGlyphCount);

		/// <summary>Places glyphs output from the GetGlyphs method according to the font and the writing system's rendering rules.</summary>
		/// <param name="textString">
		/// <para>Type: <c>const WCHAR*</c></para>
		/// <para>An array of characters containing the original string from which the glyphs came.</para>
		/// </param>
		/// <param name="clusterMap">
		/// <para>Type: <c>const UINT16*</c></para>
		/// <para>A pointer to the mapping from character ranges to glyph ranges. This is returned by GetGlyphs.</para>
		/// </param>
		/// <param name="textProps">
		/// <para>Type: <c>DWRITE_SHAPING_TEXT_PROPERTIES*</c></para>
		/// <para>
		/// A pointer to an array of structures that contains shaping properties for each character. This structure is returned by GetGlyphs.
		/// </para>
		/// </param>
		/// <param name="textLength">
		/// <para>Type: <c>UINT32</c></para>
		/// <para>The text length of textString.</para>
		/// </param>
		/// <param name="glyphIndices">
		/// <para>Type: <c>const UINT16*</c></para>
		/// <para>An array of glyph indices returned by GetGlyphs.</para>
		/// </param>
		/// <param name="glyphProps">
		/// <para>Type: <c>const DWRITE_SHAPING_GLYPH_PROPERTIES*</c></para>
		/// <para>A pointer to an array of structures that contain shaping properties for each glyph returned by GetGlyphs.</para>
		/// </param>
		/// <param name="glyphCount">
		/// <para>Type: <c>UINT32</c></para>
		/// <para>The number of glyphs returned from GetGlyphs.</para>
		/// </param>
		/// <param name="fontFace">
		/// <para>Type: <c>IDWriteFontFace*</c></para>
		/// <para>A pointer to the font face that is the source for the output glyphs.</para>
		/// </param>
		/// <param name="fontEmSize">
		/// <para>Type: <c>FLOAT</c></para>
		/// <para>The logical font size in DIPs.</para>
		/// </param>
		/// <param name="isSideways">
		/// <para>Type: <c>BOOL</c></para>
		/// <para>A Boolean flag set to <c>TRUE</c> if the text is intended to be drawn vertically.</para>
		/// </param>
		/// <param name="isRightToLeft">
		/// <para>Type: <c>BOOL</c></para>
		/// <para>A Boolean flag set to <c>TRUE</c> for right-to-left text.</para>
		/// </param>
		/// <param name="scriptAnalysis">
		/// <para>Type: <c>const DWRITE_SCRIPT_ANALYSIS*</c></para>
		/// <para>A pointer to a Script analysis result from an AnalyzeScript call.</para>
		/// </param>
		/// <param name="localeName">
		/// <para>Type: <c>const WCHAR*</c></para>
		/// <para>
		/// An array of characters containing the locale to use when selecting glyphs. For example, the same character may map to different
		/// glyphs for ja-jp versus zh-chs. If this is <c>NULL</c>, the default mapping based on the script is used.
		/// </para>
		/// </param>
		/// <param name="features">
		/// <para>Type: <c>const DWRITE_TYPOGRAPHIC_FEATURES**</c></para>
		/// <para>An array of pointers to the sets of typographic features to use in each feature range.</para>
		/// </param>
		/// <param name="featureRangeLengths">
		/// <para>Type: <c>const UINT32*</c></para>
		/// <para>The length of each feature range, in characters. The sum of all lengths should be equal to textLength.</para>
		/// </param>
		/// <param name="featureRanges">
		/// <para>Type: <c>UINT32</c></para>
		/// <para>The number of feature ranges.</para>
		/// </param>
		/// <param name="glyphAdvances">
		/// <para>Type: <c>FLOAT*</c></para>
		/// <para>When this method returns, contains the advance width of each glyph.</para>
		/// </param>
		/// <param name="glyphOffsets">
		/// <para>Type: <c>DWRITE_GLYPH_OFFSET*</c></para>
		/// <para>When this method returns, contains the offset of the origin of each glyph.</para>
		/// </param>
		// https://docs.microsoft.com/en-us/windows/win32/api/dwrite/nf-dwrite-idwritetextanalyzer-getglyphplacements HRESULT
		// GetGlyphPlacements( WCHAR const *textString, UINT16 const *clusterMap, DWRITE_SHAPING_TEXT_PROPERTIES *textProps, UINT32
		// textLength, UINT16 const *glyphIndices, DWRITE_SHAPING_GLYPH_PROPERTIES const *glyphProps, UINT32 glyphCount, IDWriteFontFace
		// *fontFace, FLOAT fontEmSize, BOOL isSideways, BOOL isRightToLeft, DWRITE_SCRIPT_ANALYSIS const *scriptAnalysis, WCHAR const
		// *localeName, DWRITE_TYPOGRAPHIC_FEATURES const **features, UINT32 const *featureRangeLengths, UINT32 featureRanges, FLOAT
		// *glyphAdvances, DWRITE_GLYPH_OFFSET *glyphOffsets );
		new void GetGlyphPlacements([MarshalAs(UnmanagedType.LPWStr)] string textString, [In, MarshalAs(UnmanagedType.LPArray)] ushort[] clusterMap,
			[In, MarshalAs(UnmanagedType.LPArray)] DWRITE_SHAPING_TEXT_PROPERTIES[] textProps, uint textLength, [In, MarshalAs(UnmanagedType.LPArray)] ushort[] glyphIndices,
			[In, MarshalAs(UnmanagedType.LPArray)] DWRITE_SHAPING_GLYPH_PROPERTIES[] glyphProps, uint glyphCount, [In] IDWriteFontFace fontFace, float fontEmSize,
			[MarshalAs(UnmanagedType.Bool)] bool isSideways, [MarshalAs(UnmanagedType.Bool)] bool isRightToLeft,
			in DWRITE_SCRIPT_ANALYSIS scriptAnalysis, [MarshalAs(UnmanagedType.LPWStr)] string localeName,
			[In, Optional, MarshalAs(UnmanagedType.LPArray, ArraySubType = UnmanagedType.LPStruct)] DWRITE_TYPOGRAPHIC_FEATURES[]? features,
			[In, Optional, MarshalAs(UnmanagedType.LPArray)] uint[]? featureRangeLengths, uint featureRanges, [Out, MarshalAs(UnmanagedType.LPArray)] float[] glyphAdvances,
			[Out, MarshalAs(UnmanagedType.LPArray)] DWRITE_GLYPH_OFFSET[] glyphOffsets);

		/// <summary>Place glyphs output from the GetGlyphs method according to the font and the writing system's rendering rules.</summary>
		/// <param name="textString">
		/// <para>Type: <c>const WCHAR*</c></para>
		/// <para>An array of characters containing the original string from which the glyphs came.</para>
		/// </param>
		/// <param name="clusterMap">
		/// <para>Type: <c>const UINT16*</c></para>
		/// <para>A pointer to the mapping from character ranges to glyph ranges. This is returned by GetGlyphs.</para>
		/// </param>
		/// <param name="textProps">
		/// <para>Type: <c>DWRITE_SHAPING_TEXT_PROPERTIES*</c></para>
		/// <para>
		/// A pointer to an array of structures that contains shaping properties for each character. This structure is returned by GetGlyphs.
		/// </para>
		/// </param>
		/// <param name="textLength">
		/// <para>Type: <c>UINT32</c></para>
		/// <para>The text length of textString.</para>
		/// </param>
		/// <param name="glyphIndices">
		/// <para>Type: <c>const UINT16*</c></para>
		/// <para>An array of glyph indices returned by GetGlyphs.</para>
		/// </param>
		/// <param name="glyphProps">
		/// <para>Type: <c>const DWRITE_SHAPING_GLYPH_PROPERTIES*</c></para>
		/// <para>A pointer to an array of structures that contain shaping properties for each glyph returned by GetGlyphs.</para>
		/// </param>
		/// <param name="glyphCount">
		/// <para>Type: <c>UINT32</c></para>
		/// <para>The number of glyphs returned from GetGlyphs.</para>
		/// </param>
		/// <param name="fontFace">
		/// <para>Type: <c>IDWriteFontFace*</c></para>
		/// <para>A pointer to the font face that is the source for the output glyphs.</para>
		/// </param>
		/// <param name="fontEmSize">
		/// <para>Type: <c>FLOAT</c></para>
		/// <para>The logical font size in DIPs.</para>
		/// </param>
		/// <param name="pixelsPerDip">
		/// <para>Type: <c>FLOAT</c></para>
		/// <para>The number of physical pixels per DIP.</para>
		/// </param>
		/// <param name="transform">
		/// <para>Type: <c>const DWRITE_MATRIX*</c></para>
		/// <para>
		/// An optional transform applied to the glyphs and their positions. This transform is applied after the scaling specified by the
		/// font size and pixelsPerDip.
		/// </para>
		/// </param>
		/// <param name="useGdiNatural">
		/// <para>Type: <c>BOOL</c></para>
		/// <para>
		/// When set to <c>FALSE</c>, the metrics are the same as the metrics of GDI aliased text. When set to <c>TRUE</c>, the metrics are
		/// the same as the metrics of text measured by GDI using a font created with <c>CLEARTYPE_NATURAL_QUALITY</c>.
		/// </para>
		/// </param>
		/// <param name="isSideways">
		/// <para>Type: <c>BOOL</c></para>
		/// <para>A Boolean flag set to <c>TRUE</c> if the text is intended to be drawn vertically.</para>
		/// </param>
		/// <param name="isRightToLeft">
		/// <para>Type: <c>BOOL</c></para>
		/// <para>A Boolean flag set to <c>TRUE</c> for right-to-left text.</para>
		/// </param>
		/// <param name="scriptAnalysis">
		/// <para>Type: <c>const DWRITE_SCRIPT_ANALYSIS*</c></para>
		/// <para>A pointer to a Script analysis result from anAnalyzeScript call.</para>
		/// </param>
		/// <param name="localeName">
		/// <para>Type: <c>const WCHAR*</c></para>
		/// <para>
		/// An array of characters containing the locale to use when selecting glyphs. For example, the same character may map to different
		/// glyphs for ja-jp versus zh-chs. If this is <c>NULL</c>, then the default mapping based on the script is used.
		/// </para>
		/// </param>
		/// <param name="features">
		/// <para>Type: <c>const DWRITE_TYPOGRAPHIC_FEATURES**</c></para>
		/// <para>An array of pointers to the sets of typographic features to use in each feature range.</para>
		/// </param>
		/// <param name="featureRangeLengths">
		/// <para>Type: <c>const UINT32*</c></para>
		/// <para>The length of each feature range, in characters. The sum of all lengths should be equal to textLength.</para>
		/// </param>
		/// <param name="featureRanges">
		/// <para>Type: <c>UINT32</c></para>
		/// <para>The number of feature ranges.</para>
		/// </param>
		/// <param name="glyphAdvances">
		/// <para>Type: <c>FLOAT*</c></para>
		/// <para>When this method returns, contains the advance width of each glyph.</para>
		/// </param>
		/// <param name="glyphOffsets">
		/// <para>Type: <c>DWRITE_GLYPH_OFFSET*</c></para>
		/// <para>When this method returns, contains the offset of the origin of each glyph.</para>
		/// </param>
		// https://docs.microsoft.com/en-us/windows/win32/api/dwrite/nf-dwrite-idwritetextanalyzer-getgdicompatibleglyphplacements HRESULT
		// GetGdiCompatibleGlyphPlacements( WCHAR const *textString, UINT16 const *clusterMap, DWRITE_SHAPING_TEXT_PROPERTIES
		// *textProps, UINT32 textLength, UINT16 const *glyphIndices, DWRITE_SHAPING_GLYPH_PROPERTIES const *glyphProps, UINT32 glyphCount,
		// IDWriteFontFace *fontFace, FLOAT fontEmSize, FLOAT pixelsPerDip, DWRITE_MATRIX const *transform, BOOL useGdiNatural, BOOL
		// isSideways, BOOL isRightToLeft, DWRITE_SCRIPT_ANALYSIS const *scriptAnalysis, WCHAR const *localeName,
		// DWRITE_TYPOGRAPHIC_FEATURES const **features, UINT32 const *featureRangeLengths, UINT32 featureRanges, FLOAT *glyphAdvances,
		// DWRITE_GLYPH_OFFSET *glyphOffsets );
		new void GetGdiCompatibleGlyphPlacements([MarshalAs(UnmanagedType.LPWStr)] string textString, [In, MarshalAs(UnmanagedType.LPArray)] ushort[] clusterMap,
			[In, MarshalAs(UnmanagedType.LPArray)] DWRITE_SHAPING_TEXT_PROPERTIES[] textProps, uint textLength, [In, MarshalAs(UnmanagedType.LPArray)] ushort[] glyphIndices,
			[In, MarshalAs(UnmanagedType.LPArray)] DWRITE_SHAPING_GLYPH_PROPERTIES[] glyphProps, uint glyphCount, [In] IDWriteFontFace fontFace, float fontEmSize,
			float pixelsPerDip, [In, Optional] IntPtr transform, [MarshalAs(UnmanagedType.Bool)] bool useGdiNatural,
			[MarshalAs(UnmanagedType.Bool)] bool isSideways, [MarshalAs(UnmanagedType.Bool)] bool isRightToLeft,
			in DWRITE_SCRIPT_ANALYSIS scriptAnalysis, [MarshalAs(UnmanagedType.LPWStr)] string localeName,
			[In, Optional, MarshalAs(UnmanagedType.LPArray, ArraySubType = UnmanagedType.LPStruct)] DWRITE_TYPOGRAPHIC_FEATURES[]? features,
			[In, Optional, MarshalAs(UnmanagedType.LPArray)] uint[]? featureRangeLengths, uint featureRanges, [Out, MarshalAs(UnmanagedType.LPArray)] float[] glyphAdvances,
			[Out, MarshalAs(UnmanagedType.LPArray)] DWRITE_GLYPH_OFFSET[] glyphOffsets);

		/// <summary>Applies spacing between characters, properly adjusting glyph clusters and diacritics.</summary>
		/// <param name="leadingSpacing">The spacing before each character, in reading order.</param>
		/// <param name="trailingSpacing">The spacing after each character, in reading order.</param>
		/// <param name="minimumAdvanceWidth">
		/// The minimum advance of each character, to prevent characters from becoming too thin or zero-width. This must be zero or greater.
		/// </param>
		/// <param name="textLength">The length of the clustermap and original text.</param>
		/// <param name="glyphCount">The number of glyphs.</param>
		/// <param name="clusterMap">Mapping from character ranges to glyph ranges.</param>
		/// <param name="glyphAdvances">The advance width of each glyph.</param>
		/// <param name="glyphOffsets">The offset of the origin of each glyph.</param>
		/// <param name="glyphProperties">Properties of each glyph, from GetGlyphs.</param>
		/// <param name="modifiedGlyphAdvances">The new advance width of each glyph.</param>
		/// <param name="modifiedGlyphOffsets">The new offset of the origin of each glyph.</param>
		/// <remarks>The input and output advances/offsets are allowed to alias the same array.</remarks>
		// https://learn.microsoft.com/en-us/windows/win32/api/dwrite_1/nf-dwrite_1-idwritetextanalyzer1-applycharacterspacing HRESULT
		// ApplyCharacterSpacing( FLOAT leadingSpacing, FLOAT trailingSpacing, FLOAT minimumAdvanceWidth, UINT32 textLength, UINT32
		// glyphCount, [in] UINT16 const *clusterMap, [in] FLOAT const *glyphAdvances, [in] DWRITE_GLYPH_OFFSET const *glyphOffsets, [in]
		// DWRITE_SHAPING_GLYPH_PROPERTIES const *glyphProperties, [out] FLOAT *modifiedGlyphAdvances, [out] DWRITE_GLYPH_OFFSET
		// *modifiedGlyphOffsets );
		void ApplyCharacterSpacing(float leadingSpacing, float trailingSpacing, float minimumAdvanceWidth, int textLength, int glyphCount,
			[In, MarshalAs(UnmanagedType.LPArray, SizeParamIndex = 3)] ushort[] clusterMap,
			[In, MarshalAs(UnmanagedType.LPArray, SizeParamIndex = 4)] float[] glyphAdvances,
			[In, MarshalAs(UnmanagedType.LPArray, SizeParamIndex = 4)] DWRITE_GLYPH_OFFSET[] glyphOffsets,
			[In, MarshalAs(UnmanagedType.LPArray, SizeParamIndex = 4)] DWRITE_SHAPING_GLYPH_PROPERTIES[] glyphProperties,
			[Out, MarshalAs(UnmanagedType.LPArray, SizeParamIndex = 4)] float[] modifiedGlyphAdvances,
			[Out, MarshalAs(UnmanagedType.LPArray, SizeParamIndex = 4)] DWRITE_GLYPH_OFFSET[] modifiedGlyphOffsets);

		/// <summary>Retrieves the given baseline from the font.</summary>
		/// <param name="fontFace">
		/// <para>Type: <b><c>IDWriteFontFace</c>*</b></para>
		/// <para>The font face to read.</para>
		/// </param>
		/// <param name="baseline">
		/// <para>Type: <b><c>DWRITE_BASELINE</c></b></para>
		/// <para>A <c>DWRITE_BASELINE</c>-typed value that specifies the baseline of interest.</para>
		/// </param>
		/// <param name="isVertical">
		/// <para>Type: <b>BOOL</b></para>
		/// <para>Whether the baseline is vertical or horizontal.</para>
		/// </param>
		/// <param name="isSimulationAllowed">
		/// <para>Type: <b>BOOL</b></para>
		/// <para>Simulate the baseline if it is missing in the font.</para>
		/// </param>
		/// <param name="scriptAnalysis">
		/// <para>Type: <b><c>DWRITE_SCRIPT_ANALYSIS</c></b></para>
		/// <para>Script analysis result from AnalyzeScript.</para>
		/// <para>
		/// <b>Note</b>  You can pass an empty script analysis structure, like this <c>DWRITE_SCRIPT_ANALYSIS scriptAnalysis = {};</c>, and
		/// this method will return the default baseline.
		/// </para>
		/// <para></para>
		/// </param>
		/// <param name="localeName">
		/// <para>Type: <b>const WCHAR*</b></para>
		/// <para>The language of the run.</para>
		/// </param>
		/// <param name="baselineCoordinate">
		/// <para>Type: <b>INT32*</b></para>
		/// <para>The baseline coordinate value in design units.</para>
		/// </param>
		/// <param name="exists">
		/// <para>Type: <b>BOOL*</b></para>
		/// <para>Whether the returned baseline exists in the font.</para>
		/// </param>
		/// <remarks>
		/// If the baseline does not exist in the font, it is not considered an error, but the function will return exists = false. You may
		/// then use heuristics to calculate the missing base, or, if the flag simulationAllowed is true, the function will compute a
		/// reasonable approximation for you.
		/// </remarks>
		// https://learn.microsoft.com/en-us/windows/win32/api/dwrite_1/nf-dwrite_1-idwritetextanalyzer1-getbaseline HRESULT GetBaseline(
		// IDWriteFontFace *fontFace, DWRITE_BASELINE baseline, BOOL isVertical, BOOL isSimulationAllowed, DWRITE_SCRIPT_ANALYSIS
		// scriptAnalysis, [in, optional] WCHAR const *localeName, [out] INT32 *baselineCoordinate, [out] BOOL *exists );
		void GetBaseline([In] IDWriteFontFace fontFace, DWRITE_BASELINE baseline, bool isVertical, bool isSimulationAllowed,
			DWRITE_SCRIPT_ANALYSIS scriptAnalysis, [In, Optional, MarshalAs(UnmanagedType.LPWStr)] string? localeName, out int baselineCoordinate,
			out bool exists);

		/// <summary>
		/// Analyzes a text range for script orientation, reading text and attributes from the source and reporting results to the sink
		/// callback <c>SetGlyphOrientation</c>.
		/// </summary>
		/// <param name="analysisSource">
		/// <para>Type: <b><c>IDWriteTextAnalysisSource1</c>*</b></para>
		/// <para>Source object to analyze.</para>
		/// </param>
		/// <param name="textPosition">
		/// <para>Type: <b>UINT32</b></para>
		/// <para>Starting position within the source object.</para>
		/// </param>
		/// <param name="textLength">
		/// <para>Type: <b>UINT32</b></para>
		/// <para>Length to analyze.</para>
		/// </param>
		/// <param name="analysisSink">
		/// <para>Type: <b><c>IDWriteTextAnalysisSink1</c>*</b></para>
		/// <para>Length to analyze.</para>
		/// </param>
		/// <returns>
		/// <para>Type: <b>HRESULT</b></para>
		/// <para>If this method succeeds, it returns <b>S_OK</b>. Otherwise, it returns an <b>HRESULT</b> error code.</para>
		/// </returns>
		// https://learn.microsoft.com/en-us/windows/win32/api/dwrite_1/nf-dwrite_1-idwritetextanalyzer1-analyzeverticalglyphorientation
		// HRESULT AnalyzeVerticalGlyphOrientation( IDWriteTextAnalysisSource1 *analysisSource, UINT32 textPosition, UINT32 textLength,
		// IDWriteTextAnalysisSink1 *analysisSink );
		void AnalyzeVerticalGlyphOrientation([In] IDWriteTextAnalysisSource1 analysisSource, uint textPosition, uint textLength, [In] IDWriteTextAnalysisSink1 analysisSink);

		/// <summary>Returns 2x3 transform matrix for the respective angle to draw the glyph run.</summary>
		/// <param name="glyphOrientationAngle">
		/// <para>Type: <b><c>DWRITE_GLYPH_ORIENTATION_ANGLE</c></b></para>
		/// <para>A <c>DWRITE_GLYPH_ORIENTATION_ANGLE</c>-typed value that specifies the angle that was reported into <c>IDWriteTextAnalysisSink1::SetGlyphOrientation</c>.</para>
		/// </param>
		/// <param name="isSideways">
		/// <para>Type: <b>BOOL</b></para>
		/// <para>Whether the run's glyphs are sideways or not.</para>
		/// </param>
		/// <returns>
		/// <para>Type: <b><c>DWRITE_MATRIX</c>*</b></para>
		/// <para>Returned transform.</para>
		/// </returns>
		/// <remarks>The translation component of the transform returned is zero.</remarks>
		// https://learn.microsoft.com/en-us/windows/win32/api/dwrite_1/nf-dwrite_1-idwritetextanalyzer1-getglyphorientationtransform
		// HRESULT GetGlyphOrientationTransform( DWRITE_GLYPH_ORIENTATION_ANGLE glyphOrientationAngle, BOOL isSideways, [out] DWRITE_MATRIX
		// *transform );
		DWRITE_MATRIX GetGlyphOrientationTransform(DWRITE_GLYPH_ORIENTATION_ANGLE glyphOrientationAngle, bool isSideways = false);

		/// <summary>Retrieves the properties for a given script.</summary>
		/// <param name="scriptAnalysis">
		/// <para>Type: <b><c>DWRITE_SCRIPT_ANALYSIS</c></b></para>
		/// <para>The script for a run of text returned from <c>IDWriteTextAnalyzer::AnalyzeScript</c>.</para>
		/// </param>
		/// <returns>
		/// <para>Type: <b><c>DWRITE_SCRIPT_PROPERTIES</c>*</b></para>
		/// <para>A pointer to a <c>DWRITE_SCRIPT_PROPERTIES</c> structure that describes info for the script.</para>
		/// </returns>
		// https://learn.microsoft.com/en-us/windows/win32/api/dwrite_1/nf-dwrite_1-idwritetextanalyzer1-getscriptproperties HRESULT
		// GetScriptProperties( DWRITE_SCRIPT_ANALYSIS scriptAnalysis, [out] DWRITE_SCRIPT_PROPERTIES *scriptProperties );
		DWRITE_SCRIPT_PROPERTIES GetScriptProperties(DWRITE_SCRIPT_ANALYSIS scriptAnalysis);

		/// <summary>
		/// Determines the complexity of text, and whether you need to call <c>IDWriteTextAnalyzer::GetGlyphs</c> for full script shaping.
		/// </summary>
		/// <param name="textString">
		/// <para>Type: <b>const WCHAR*</b></para>
		/// <para>The text to check for complexity. This string may be UTF-16, but any supplementary characters will be considered complex.</para>
		/// </param>
		/// <param name="textLength">
		/// <para>Type: <b>UINT32</b></para>
		/// <para>Length of the text to check.</para>
		/// </param>
		/// <param name="fontFace">
		/// <para>Type: <b><c>IDWriteFontFace</c>*</b></para>
		/// <para>The font face to read.</para>
		/// </param>
		/// <param name="isTextSimple">
		/// <para>Type: <b>BOOL*</b></para>
		/// <para>
		/// If true, the text is simple, and the <i>glyphIndices</i> array will already have the nominal glyphs for you. Otherwise, you need
		/// to call <c>IDWriteTextAnalyzer::GetGlyphs</c> to properly shape complex scripts and OpenType features.
		/// </para>
		/// </param>
		/// <param name="textLengthRead">
		/// <para>Type: <b>UINT32*</b></para>
		/// <para>The length read of the text run with the same complexity, simple or complex. You may call again from that point onward.</para>
		/// </param>
		/// <param name="glyphIndices">
		/// <para>Type: <b>UINT16*</b></para>
		/// <para>
		/// Optional glyph indices for the text. If the function returned that the text was simple, you already have the glyphs you need.
		/// Otherwise the glyph indices are not meaningful, and you need to call <c>IDWriteTextAnalyzer::GetGlyphs</c> for shaping instead.
		/// </para>
		/// </param>
		/// <remarks>
		/// Text is not simple if the characters are part of a script that has complex shaping requirements, require bidi analysis, combine
		/// with other characters, reside in the supplementary planes, or have glyphs that participate in standard OpenType features. The
		/// length returned will not split combining marks from their base characters.
		/// </remarks>
		// https://learn.microsoft.com/en-us/windows/win32/api/dwrite_1/nf-dwrite_1-idwritetextanalyzer1-gettextcomplexity HRESULT
		// GetTextComplexity( [in] WCHAR const *textString, UINT32 textLength, IDWriteFontFace *fontFace, [out] BOOL *isTextSimple, [out]
		// UINT32 *textLengthRead, [out, optional] UINT16 *glyphIndices );
		void GetTextComplexity([MarshalAs(UnmanagedType.LPWStr)] string textString, int textLength, [In] IDWriteFontFace fontFace, out bool isTextSimple,
			out uint textLengthRead, [Out, Optional, MarshalAs(UnmanagedType.LPArray, SizeParamIndex = 1)] ushort[]? glyphIndices);

		/// <summary>Retrieves justification opportunity information for each of the glyphs given the text and shaping glyph properties.</summary>
		/// <param name="fontFace">
		/// <para>Type: <b><c>IDWriteFontFace</c>*</b></para>
		/// <para>Font face that was used for shaping. This is mainly important for returning correct results of the kashida width.</para>
		/// <para>May be NULL.</para>
		/// </param>
		/// <param name="fontEmSize">
		/// <para>Type: <b>FLOAT</b></para>
		/// <para>Font em size used for the glyph run.</para>
		/// </param>
		/// <param name="scriptAnalysis">
		/// <para>Type: <b><c>DWRITE_SCRIPT_ANALYSIS</c></b></para>
		/// <para>Script of the text from the itemizer.</para>
		/// </param>
		/// <param name="textLength">
		/// <para>Type: <b>UINT32</b></para>
		/// <para>Length of the text.</para>
		/// </param>
		/// <param name="glyphCount">
		/// <para>Type: <b>UINT32</b></para>
		/// <para>Number of glyphs.</para>
		/// </param>
		/// <param name="textString">
		/// <para>Type: <b>const WCHAR*</b></para>
		/// <para>Characters used to produce the glyphs.</para>
		/// </param>
		/// <param name="clusterMap">
		/// <para>Type: <b>const UINT16*</b></para>
		/// <para>Clustermap produced from shaping.</para>
		/// </param>
		/// <param name="glyphProperties">
		/// <para>Type: <b>const <c>DWRITE_SHAPING_GLYPH_PROPERTIES</c>*</b></para>
		/// <para>Glyph properties produced from shaping.</para>
		/// </param>
		/// <param name="justificationOpportunities">
		/// <para>Type: <b><c>DWRITE_JUSTIFICATION_OPPORTUNITY</c>*</b></para>
		/// <para>
		/// A pointer to a <c>DWRITE_JUSTIFICATION_OPPORTUNITY</c> structure that receives info for the allowed justification
		/// expansion/compression for each glyph.
		/// </para>
		/// </param>
		/// <remarks>
		/// <para>This function is called per-run, after shaping is done via the <c>IDWriteTextAnalyzer::GetGlyphs</c> method.</para>
		/// <para><b>Note</b>  this function only supports natural metrics ( <c>DWRITE_MEASURING_MODE_NATURAL</c>).</para>
		/// <para></para>
		/// </remarks>
		// https://learn.microsoft.com/en-us/windows/win32/api/dwrite_1/nf-dwrite_1-idwritetextanalyzer1-getjustificationopportunities
		// HRESULT GetJustificationOpportunities( IDWriteFontFace *fontFace, FLOAT fontEmSize, DWRITE_SCRIPT_ANALYSIS scriptAnalysis, UINT32
		// textLength, UINT32 glyphCount, [in] WCHAR const *textString, [in] UINT16 const *clusterMap, [in] DWRITE_SHAPING_GLYPH_PROPERTIES
		// const *glyphProperties, [out] DWRITE_JUSTIFICATION_OPPORTUNITY *justificationOpportunities );
		void GetJustificationOpportunities([In, Optional] IDWriteFontFace? fontFace, float fontEmSize, DWRITE_SCRIPT_ANALYSIS scriptAnalysis,
			int textLength, int glyphCount, [MarshalAs(UnmanagedType.LPWStr)] string textString,
			[In, MarshalAs(UnmanagedType.LPArray, SizeParamIndex = 3)] ushort[] clusterMap,
			[In, MarshalAs(UnmanagedType.LPArray, SizeParamIndex = 4)] DWRITE_SHAPING_GLYPH_PROPERTIES[] glyphProperties,
			[Out, MarshalAs(UnmanagedType.LPArray, SizeParamIndex = 4)] DWRITE_JUSTIFICATION_OPPORTUNITY[] justificationOpportunities);

		/// <summary>Justifies an array of glyph advances to fit the line width.</summary>
		/// <param name="lineWidth">
		/// <para>Type: <b>FLOAT</b></para>
		/// <para>The line width.</para>
		/// </param>
		/// <param name="glyphCount">
		/// <para>Type: <b>UINT32</b></para>
		/// <para>The glyph count.</para>
		/// </param>
		/// <param name="justificationOpportunities">
		/// <para>Type: <b>const <c>DWRITE_JUSTIFICATION_OPPORTUNITY</c>*</b></para>
		/// <para>
		/// A pointer to a <c>DWRITE_JUSTIFICATION_OPPORTUNITY</c> structure that contains info for the allowed justification
		/// expansion/compression for each glyph. Get this info from <c>IDWriteTextAnalyzer1::GetJustificationOpportunities</c>.
		/// </para>
		/// </param>
		/// <param name="glyphAdvances">
		/// <para>Type: <b>const FLOAT*</b></para>
		/// <para>An array of glyph advances.</para>
		/// </param>
		/// <param name="glyphOffsets">
		/// <para>Type: <b>const <c>DWRITE_GLYPH_OFFSET</c>*</b></para>
		/// <para>An array of glyph offsets.</para>
		/// </param>
		/// <param name="justifiedGlyphAdvances">
		/// <para>Type: <b>FLOAT*</b></para>
		/// <para>The returned array of justified glyph advances.</para>
		/// </param>
		/// <param name="justifiedGlyphOffsets">
		/// <para>Type: <b><c>DWRITE_GLYPH_OFFSET</c>*</b></para>
		/// <para>The returned array of justified glyph offsets.</para>
		/// </param>
		/// <remarks>
		/// You call <b>JustifyGlyphAdvances</b> after you call <c>IDWriteTextAnalyzer1::GetJustificationOpportunities</c> to collect all
		/// the opportunities, and <b>JustifyGlyphAdvances</b> spans across the entire line. The input and output arrays are allowed to
		/// alias each other, permitting in-place update.
		/// </remarks>
		// https://learn.microsoft.com/en-us/windows/win32/api/dwrite_1/nf-dwrite_1-idwritetextanalyzer1-justifyglyphadvances HRESULT
		// JustifyGlyphAdvances( FLOAT lineWidth, UINT32 glyphCount, [in] DWRITE_JUSTIFICATION_OPPORTUNITY const
		// *justificationOpportunities, [in] FLOAT const *glyphAdvances, [in] DWRITE_GLYPH_OFFSET const *glyphOffsets, [out] FLOAT
		// *justifiedGlyphAdvances, [out, optional] DWRITE_GLYPH_OFFSET *justifiedGlyphOffsets );
		void JustifyGlyphAdvances(float lineWidth, int glyphCount,
			[In, MarshalAs(UnmanagedType.LPArray, SizeParamIndex = 1)] DWRITE_JUSTIFICATION_OPPORTUNITY[] justificationOpportunities,
			[In, MarshalAs(UnmanagedType.LPArray, SizeParamIndex = 1)] float[] glyphAdvances,
			[In, MarshalAs(UnmanagedType.LPArray, SizeParamIndex = 1)] DWRITE_GLYPH_OFFSET[] glyphOffsets,
			[Out, MarshalAs(UnmanagedType.LPArray, SizeParamIndex = 1)] float[] justifiedGlyphAdvances,
			[Out, MarshalAs(UnmanagedType.LPArray, SizeParamIndex = 1)] DWRITE_GLYPH_OFFSET[] justifiedGlyphOffsets);

		/// <summary>
		/// Fills in new glyphs for complex scripts where justification increased the advances of glyphs, such as Arabic with kashida.
		/// </summary>
		/// <param name="fontFace">
		/// <para>Type: <b><c>IDWriteFontFace</c>*</b></para>
		/// <para>Font face used for shaping.</para>
		/// <para>May be NULL.</para>
		/// </param>
		/// <param name="fontEmSize">
		/// <para>Type: <b>FLOAT</b></para>
		/// <para>Font em size used for the glyph run.</para>
		/// </param>
		/// <param name="scriptAnalysis">
		/// <para>Type: <b><c>DWRITE_SCRIPT_ANALYSIS</c></b></para>
		/// <para>Script of the text from the itemizer.</para>
		/// </param>
		/// <param name="textLength">
		/// <para>Type: <b>UINT32</b></para>
		/// <para>Length of the text.</para>
		/// </param>
		/// <param name="glyphCount">
		/// <para>Type: <b>UINT32</b></para>
		/// <para>Number of glyphs.</para>
		/// </param>
		/// <param name="maxGlyphCount">
		/// <para>Type: <b>UINT32</b></para>
		/// <para>Maximum number of output glyphs allocated by caller.</para>
		/// </param>
		/// <param name="clusterMap">
		/// <para>Type: <b>const UINT16*</b></para>
		/// <para>Clustermap produced from shaping.</para>
		/// </param>
		/// <param name="glyphIndices">
		/// <para>Type: <b>const UINT16*</b></para>
		/// <para>Original glyphs produced from shaping.</para>
		/// </param>
		/// <param name="glyphAdvances">
		/// <para>Type: <b>const FLOAT*</b></para>
		/// <para>Original glyph advances produced from shaping.</para>
		/// </param>
		/// <param name="justifiedGlyphAdvances">
		/// <para>Type: <b>const FLOAT*</b></para>
		/// <para>Justified glyph advances from <c>IDWriteTextAnalyzer1::JustifyGlyphAdvances</c>.</para>
		/// </param>
		/// <param name="justifiedGlyphOffsets">
		/// <para>Type: <b>const <c>DWRITE_GLYPH_OFFSET</c>*</b></para>
		/// <para>Justified glyph offsets from <c>IDWriteTextAnalyzer1::JustifyGlyphAdvances</c>.</para>
		/// </param>
		/// <param name="glyphProperties">
		/// <para>Type: <b>const <c>DWRITE_SHAPING_GLYPH_PROPERTIES</c>*</b></para>
		/// <para>Properties of each glyph, from <c>IDWriteTextAnalyzer::GetGlyphs</c>.</para>
		/// </param>
		/// <param name="actualGlyphCount">
		/// <para>Type: <b>UINT32*</b></para>
		/// <para>The new glyph count written to the modified arrays, or the needed glyph count if the size is not large enough.</para>
		/// </param>
		/// <param name="modifiedClusterMap">
		/// <para>Type: <b>UINT16*</b></para>
		/// <para>Updated clustermap.</para>
		/// </param>
		/// <param name="modifiedGlyphIndices">
		/// <para>Type: <b>UINT16*</b></para>
		/// <para>Updated glyphs with new glyphs inserted where needed.</para>
		/// </param>
		/// <param name="modifiedGlyphAdvances">
		/// <para>Type: <b>FLOAT*</b></para>
		/// <para>Updated glyph advances.</para>
		/// </param>
		/// <param name="modifiedGlyphOffsets">
		/// <para>Type: <b><c>DWRITE_GLYPH_OFFSET</c>*</b></para>
		/// <para>Updated glyph offsets.</para>
		/// </param>
		/// <remarks>
		/// <para>You call <b>GetJustifiedGlyphs</b> after the line has been justified, and it is per-run.</para>
		/// <para>
		/// You should call <b>GetJustifiedGlyphs</b> if <c>IDWriteTextAnalyzer1::GetScriptProperties</c> returns a non-null
		/// <c>DWRITE_SCRIPT_PROPERTIES.justificationCharacter</c> for that script.
		/// </para>
		/// <para>
		/// Use <b>GetJustifiedGlyphs</b> mainly for cursive scripts like Arabic. If <i>maxGlyphCount</i> is not large enough,
		/// <b>GetJustifiedGlyphs</b> returns the error E_NOT_SUFFICIENT_BUFFER and fills the variable to which <i>actualGlyphCount</i>
		/// points with the needed glyph count.
		/// </para>
		/// </remarks>
		// https://learn.microsoft.com/en-us/windows/win32/api/dwrite_1/nf-dwrite_1-idwritetextanalyzer1-getjustifiedglyphs HRESULT
		// GetJustifiedGlyphs( IDWriteFontFace *fontFace, FLOAT fontEmSize, DWRITE_SCRIPT_ANALYSIS scriptAnalysis, UINT32 textLength, UINT32
		// glyphCount, UINT32 maxGlyphCount, [in, optional] UINT16 const *clusterMap, [in] UINT16 const *glyphIndices, [in] FLOAT const
		// *glyphAdvances, [in] FLOAT const *justifiedGlyphAdvances, [in] DWRITE_GLYPH_OFFSET const *justifiedGlyphOffsets, [in]
		// DWRITE_SHAPING_GLYPH_PROPERTIES const *glyphProperties, [out] UINT32 *actualGlyphCount, [out, optional] UINT16
		// *modifiedClusterMap, [out] UINT16 *modifiedGlyphIndices, [out] FLOAT *modifiedGlyphAdvances, [out] DWRITE_GLYPH_OFFSET
		// *modifiedGlyphOffsets );
		void GetJustifiedGlyphs([In, Optional] IDWriteFontFace? fontFace, float fontEmSize, DWRITE_SCRIPT_ANALYSIS scriptAnalysis, int textLength,
			int glyphCount, int maxGlyphCount, [In, Optional, MarshalAs(UnmanagedType.LPArray, SizeParamIndex = 3)] ushort[]? clusterMap,
			[In, MarshalAs(UnmanagedType.LPArray, SizeParamIndex = 4)] ushort[] glyphIndices, [In, MarshalAs(UnmanagedType.LPArray, SizeParamIndex = 4)] float[] glyphAdvances,
			[In, MarshalAs(UnmanagedType.LPArray, SizeParamIndex = 4)] float[] justifiedGlyphAdvances,
			[In, MarshalAs(UnmanagedType.LPArray, SizeParamIndex = 4)] DWRITE_GLYPH_OFFSET[] justifiedGlyphOffsets,
			[In, MarshalAs(UnmanagedType.LPArray, SizeParamIndex = 4)] DWRITE_SHAPING_GLYPH_PROPERTIES[] glyphProperties,
			[Out, MarshalAs(UnmanagedType.LPArray, SizeParamIndex = 4)] uint[] actualGlyphCount,
			[Out, Optional, MarshalAs(UnmanagedType.LPArray, SizeParamIndex = 3)] ushort[]? modifiedClusterMap,
			[Out, MarshalAs(UnmanagedType.LPArray, SizeParamIndex = 5)] ushort[] modifiedGlyphIndices,
			[Out, MarshalAs(UnmanagedType.LPArray, SizeParamIndex = 5)] float[] modifiedGlyphAdvances,
			[Out, MarshalAs(UnmanagedType.LPArray, SizeParamIndex = 5)] DWRITE_GLYPH_OFFSET[] modifiedGlyphOffsets);
	}

	/// <summary>Represents a block of text after it has been fully analyzed and formatted.</summary>
	// https://learn.microsoft.com/en-us/windows/win32/api/dwrite_1/nn-dwrite_1-idwritetextlayout1
	[PInvokeData("dwrite_1.h", MSDNShortId = "NN:dwrite_1.IDWriteTextLayout1")]
	[ComImport, Guid("9064d822-80a7-465c-a986-df65f78b8feb"), InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
	public interface IDWriteTextLayout1 : IDWriteTextLayout, IDWriteTextFormat
	{
		/// <summary>
		/// Sets the alignment of text in a paragraph, relative to the leading and trailing edge of a layout box for a IDWriteTextFormat interface.
		/// </summary>
		/// <param name="textAlignment">
		/// <para>Type: <c>DWRITE_TEXT_ALIGNMENT</c></para>
		/// <para>The text alignment option being set for the paragraph of type DWRITE_TEXT_ALIGNMENT. For more information, see Remarks.</para>
		/// </param>
		/// <remarks>
		/// <para>
		/// The text can be aligned to the leading or trailing edge of the layout box, or it can be centered. The following illustration
		/// shows text with the alignment set to DWRITE_TEXT_ALIGNMENT_LEADING, <c>DWRITE_TEXT_ALIGNMENT_CENTER</c>, and
		/// <c>DWRITE_TEXT_ALIGNMENT_TRAILING</c>, respectively.
		/// </para>
		/// <para>
		/// <c>Note</c> The alignment is dependent on reading direction, the above is for left-to-right reading direction. For right-to-left
		/// reading direction it would be the opposite.
		/// </para>
		/// <para>See DWRITE_TEXT_ALIGNMENT for more information.</para>
		/// <para>Examples</para>
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows/win32/api/dwrite/nf-dwrite-idwritetextformat-settextalignment HRESULT SetTextAlignment(
		// DWRITE_TEXT_ALIGNMENT textAlignment );
		new void SetTextAlignment(DWRITE_TEXT_ALIGNMENT textAlignment);

		/// <summary>Sets the alignment option of a paragraph relative to the layout box's top and bottom edge.</summary>
		/// <param name="paragraphAlignment">
		/// <para>Type: <c>DWRITE_PARAGRAPH_ALIGNMENT</c></para>
		/// <para>The paragraph alignment option being set for a paragraph; see DWRITE_PARAGRAPH_ALIGNMENT for more information.</para>
		/// </param>
		// https://docs.microsoft.com/en-us/windows/win32/api/dwrite/nf-dwrite-idwritetextformat-setparagraphalignment HRESULT
		// SetParagraphAlignment( DWRITE_PARAGRAPH_ALIGNMENT paragraphAlignment );
		new void SetParagraphAlignment(DWRITE_PARAGRAPH_ALIGNMENT paragraphAlignment);

		/// <summary>Sets the word wrapping option.</summary>
		/// <param name="wordWrapping">
		/// <para>Type: <c>DWRITE_WORD_WRAPPING</c></para>
		/// <para>The word wrapping option being set for a paragraph; see DWRITE_WORD_WRAPPING for more information.</para>
		/// </param>
		// https://docs.microsoft.com/en-us/windows/win32/api/dwrite/nf-dwrite-idwritetextformat-setwordwrapping HRESULT SetWordWrapping(
		// DWRITE_WORD_WRAPPING wordWrapping );
		new void SetWordWrapping(DWRITE_WORD_WRAPPING wordWrapping);

		/// <summary>Sets the paragraph reading direction.</summary>
		/// <param name="readingDirection">
		/// <para>Type: <c>DWRITE_READING_DIRECTION</c></para>
		/// <para>
		/// The text reading direction (for example, DWRITE_READING_DIRECTION_RIGHT_TO_LEFT for languages, such as Arabic, that read from
		/// right to left) for a paragraph.
		/// </para>
		/// </param>
		/// <remarks>
		/// The reading direction and flow direction must always be set 90 degrees orthogonal to each other, or else you will get the error
		/// DWRITE_E_FLOWDIRECTIONCONFLICTS when you use layout functions like Draw or GetMetrics. So if you set a vertical reading
		/// direction (for example, to DWRITE_READING_DIRECTION_TOP_TO_BOTTOM), then you must also use SetFlowDirection to set the flow
		/// direction appropriately (for example, to DWRITE_FLOW_DIRECTION_RIGHT_TO_LEFT).
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows/win32/api/dwrite/nf-dwrite-idwritetextformat-setreadingdirection HRESULT
		// SetReadingDirection( DWRITE_READING_DIRECTION readingDirection );
		new void SetReadingDirection(DWRITE_READING_DIRECTION readingDirection);

		/// <summary>Sets the paragraph flow direction.</summary>
		/// <param name="flowDirection">
		/// <para>Type: <c>DWRITE_FLOW_DIRECTION</c></para>
		/// <para>The paragraph flow direction; see DWRITE_FLOW_DIRECTION for more information.</para>
		/// </param>
		// https://docs.microsoft.com/en-us/windows/win32/api/dwrite/nf-dwrite-idwritetextformat-setflowdirection HRESULT SetFlowDirection(
		// DWRITE_FLOW_DIRECTION flowDirection );
		new void SetFlowDirection(DWRITE_FLOW_DIRECTION flowDirection);

		/// <summary>Sets a fixed distance between two adjacent tab stops.</summary>
		/// <param name="incrementalTabStop">
		/// <para>Type: <c>FLOAT</c></para>
		/// <para>The fixed distance between two adjacent tab stops.</para>
		/// </param>
		// https://docs.microsoft.com/en-us/windows/win32/api/dwrite/nf-dwrite-idwritetextformat-setincrementaltabstop HRESULT
		// SetIncrementalTabStop( FLOAT incrementalTabStop );
		new void SetIncrementalTabStop(float incrementalTabStop);

		/// <summary>Sets trimming options for text overflowing the layout width.</summary>
		/// <param name="trimmingOptions">
		/// <para>Type: <c>const DWRITE_TRIMMING*</c></para>
		/// <para>Text trimming options.</para>
		/// </param>
		/// <param name="trimmingSign">
		/// <para>Type: <c>IDWriteInlineObject*</c></para>
		/// <para>Application-defined omission sign. This parameter may be <c>NULL</c>. See IDWriteInlineObject for more information.</para>
		/// </param>
		// https://docs.microsoft.com/en-us/windows/win32/api/dwrite/nf-dwrite-idwritetextformat-settrimming HRESULT SetTrimming(
		// DWRITE_TRIMMING const *trimmingOptions, IDWriteInlineObject *trimmingSign );
		new void SetTrimming(in DWRITE_TRIMMING trimmingOptions, [In, Optional] IDWriteInlineObject? trimmingSign);

		/// <summary>Sets the line spacing.</summary>
		/// <param name="lineSpacingMethod">
		/// <para>Type: <c>DWRITE_LINE_SPACING_METHOD</c></para>
		/// <para>Specifies how line height is being determined; see DWRITE_LINE_SPACING_METHOD for more information.</para>
		/// </param>
		/// <param name="lineSpacing">
		/// <para>Type: <c>FLOAT</c></para>
		/// <para>The line height, or distance between one baseline to another.</para>
		/// </param>
		/// <param name="baseline">
		/// <para>Type: <c>FLOAT</c></para>
		/// <para>The distance from top of line to baseline. A reasonable ratio to lineSpacing is 80 percent.</para>
		/// </param>
		/// <remarks>
		/// For the default method, spacing depends solely on the content. For uniform spacing, the specified line height overrides the content.
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows/win32/api/dwrite/nf-dwrite-idwritetextformat-setlinespacing HRESULT SetLineSpacing(
		// DWRITE_LINE_SPACING_METHOD lineSpacingMethod, FLOAT lineSpacing, FLOAT baseline );
		new void SetLineSpacing(DWRITE_LINE_SPACING_METHOD lineSpacingMethod, float lineSpacing, float baseline);

		/// <summary>Gets the alignment option of text relative to the layout box's leading and trailing edge.</summary>
		/// <returns>
		/// <para>Type: <c>DWRITE_TEXT_ALIGNMENT</c></para>
		/// <para>Returns the text alignment option of the current paragraph.</para>
		/// </returns>
		// https://docs.microsoft.com/en-us/windows/win32/api/dwrite/nf-dwrite-idwritetextformat-gettextalignment DWRITE_TEXT_ALIGNMENT GetTextAlignment();
		[PreserveSig]
		new DWRITE_TEXT_ALIGNMENT GetTextAlignment();

		/// <summary>Gets the alignment option of a paragraph which is relative to the top and bottom edges of a layout box.</summary>
		/// <returns>
		/// <para>Type: <c>DWRITE_PARAGRAPH_ALIGNMENT</c></para>
		/// <para>A value that indicates the current paragraph alignment option.</para>
		/// </returns>
		// https://docs.microsoft.com/en-us/windows/win32/api/dwrite/nf-dwrite-idwritetextformat-getparagraphalignment
		// DWRITE_PARAGRAPH_ALIGNMENT GetParagraphAlignment();
		[PreserveSig]
		new DWRITE_PARAGRAPH_ALIGNMENT GetParagraphAlignment();

		/// <summary>Gets the word wrapping option.</summary>
		/// <returns>
		/// <para>Type: <c>DWRITE_WORD_WRAPPING</c></para>
		/// <para>Returns the word wrapping option; see DWRITE_WORD_WRAPPING for more information.</para>
		/// </returns>
		// https://docs.microsoft.com/en-us/windows/win32/api/dwrite/nf-dwrite-idwritetextformat-getwordwrapping DWRITE_WORD_WRAPPING GetWordWrapping();
		[PreserveSig]
		new DWRITE_WORD_WRAPPING GetWordWrapping();

		/// <summary>Gets the current reading direction for text in a paragraph.</summary>
		/// <returns>
		/// <para>Type: <c>DWRITE_READING_DIRECTION</c></para>
		/// <para>A value that indicates the current reading direction for text in a paragraph.</para>
		/// </returns>
		// https://docs.microsoft.com/en-us/windows/win32/api/dwrite/nf-dwrite-idwritetextformat-getreadingdirection
		// DWRITE_READING_DIRECTION GetReadingDirection();
		[PreserveSig]
		new DWRITE_READING_DIRECTION GetReadingDirection();

		/// <summary>Gets the direction that text lines flow.</summary>
		/// <returns>
		/// <para>Type: <c>DWRITE_FLOW_DIRECTION</c></para>
		/// <para>
		/// The direction that text lines flow within their parent container. For example, DWRITE_FLOW_DIRECTION_TOP_TO_BOTTOM indicates
		/// that text lines are placed from top to bottom.
		/// </para>
		/// </returns>
		// https://docs.microsoft.com/en-us/windows/win32/api/dwrite/nf-dwrite-idwritetextformat-getflowdirection DWRITE_FLOW_DIRECTION GetFlowDirection();
		[PreserveSig]
		new DWRITE_FLOW_DIRECTION GetFlowDirection();

		/// <summary>Gets the incremental tab stop position.</summary>
		/// <returns>
		/// <para>Type: <c>FLOAT</c></para>
		/// <para>The incremental tab stop value.</para>
		/// </returns>
		// https://docs.microsoft.com/en-us/windows/win32/api/dwrite/nf-dwrite-idwritetextformat-getincrementaltabstop FLOAT GetIncrementalTabStop();
		[PreserveSig]
		new float GetIncrementalTabStop();

		/// <summary>Gets the trimming options for text that overflows the layout box.</summary>
		/// <param name="trimmingOptions">
		/// <para>Type: <c>DWRITE_TRIMMING*</c></para>
		/// <para>
		/// When this method returns, it contains a pointer to a DWRITE_TRIMMING structure that holds the text trimming options for the
		/// overflowing text.
		/// </para>
		/// </param>
		/// <param name="trimmingSign">
		/// <para>Type: <c>IDWriteInlineObject**</c></para>
		/// <para>When this method returns, contains an address of a pointer to a trimming omission sign. This parameter may be <c>NULL</c>.</para>
		/// </param>
		// https://docs.microsoft.com/en-us/windows/win32/api/dwrite/nf-dwrite-idwritetextformat-gettrimming HRESULT GetTrimming(
		// DWRITE_TRIMMING *trimmingOptions, IDWriteInlineObject **trimmingSign );
		new void GetTrimming(out DWRITE_TRIMMING trimmingOptions, out IDWriteInlineObject trimmingSign);

		/// <summary>Gets the line spacing adjustment set for a multiline text paragraph.</summary>
		/// <param name="lineSpacingMethod">
		/// <para>Type: <c>DWRITE_LINE_SPACING_METHOD*</c></para>
		/// <para>A value that indicates how line height is determined.</para>
		/// </param>
		/// <param name="lineSpacing">
		/// <para>Type: <c>FLOAT*</c></para>
		/// <para>When this method returns, contains the line height, or distance between one baseline to another.</para>
		/// </param>
		/// <param name="baseline">
		/// <para>Type: <c>FLOAT*</c></para>
		/// <para>
		/// When this method returns, contains the distance from top of line to baseline. A reasonable ratio to lineSpacing is 80 percent.
		/// </para>
		/// </param>
		// https://docs.microsoft.com/en-us/windows/win32/api/dwrite/nf-dwrite-idwritetextformat-getlinespacing HRESULT GetLineSpacing(
		// DWRITE_LINE_SPACING_METHOD *lineSpacingMethod, FLOAT *lineSpacing, FLOAT *baseline );
		new void GetLineSpacing(out DWRITE_LINE_SPACING_METHOD lineSpacingMethod, out float lineSpacing, out float baseline);

		/// <summary>Gets the current font collection.</summary>
		/// <returns>
		/// <para>Type: <c>IDWriteFontCollection**</c></para>
		/// <para>When this method returns, contains an address of a pointer to the font collection being used for the current text.</para>
		/// </returns>
		// https://docs.microsoft.com/en-us/windows/win32/api/dwrite/nf-dwrite-idwritetextformat-getfontcollection HRESULT
		// GetFontCollection( IDWriteFontCollection **fontCollection );
		new IDWriteFontCollection GetFontCollection();

		/// <summary>Gets the length of the font family name.</summary>
		/// <returns>
		/// <para>Type: <c>UINT32</c></para>
		/// <para>The size of the character array, in character count, not including the terminated <c>NULL</c> character.</para>
		/// </returns>
		// https://docs.microsoft.com/en-us/windows/win32/api/dwrite/nf-dwrite-idwritetextformat-getfontfamilynamelength UINT32 GetFontFamilyNameLength();
		[PreserveSig]
		new uint GetFontFamilyNameLength();

		/// <summary>Gets a copy of the font family name.</summary>
		/// <param name="fontFamilyName">
		/// <para>Type: <c>WCHAR*</c></para>
		/// <para>
		/// When this method returns, contains a pointer to a character array, which is null-terminated, that receives the current font
		/// family name. The buffer allocated for this array should be at least the size, in elements, of nameSize.
		/// </para>
		/// </param>
		/// <param name="nameSize">
		/// <para>Type: <c>UINT32</c></para>
		/// <para>
		/// The size of the fontFamilyName character array, in character count, including the terminated <c>NULL</c> character. To find the
		/// size of fontFamilyName, use GetFontFamilyNameLength.
		/// </para>
		/// </param>
		// https://docs.microsoft.com/en-us/windows/win32/api/dwrite/nf-dwrite-idwritetextformat-getfontfamilyname HRESULT
		// GetFontFamilyName( WCHAR *fontFamilyName, UINT32 nameSize );
		new void GetFontFamilyName([MarshalAs(UnmanagedType.LPWStr)] StringBuilder fontFamilyName, uint nameSize);

		/// <summary>Gets the font weight of the text.</summary>
		/// <returns>
		/// <para>Type: <c>DWRITE_FONT_WEIGHT</c></para>
		/// <para>A value that indicates the type of weight (such as normal, bold, or black).</para>
		/// </returns>
		// https://docs.microsoft.com/en-us/windows/win32/api/dwrite/nf-dwrite-idwritetextformat-getfontweight DWRITE_FONT_WEIGHT GetFontWeight();
		[PreserveSig]
		new DWRITE_FONT_WEIGHT GetFontWeight();

		/// <summary>Gets the font style of the text.</summary>
		/// <returns>
		/// <para>Type: <c>DWRITE_FONT_STYLE</c></para>
		/// <para>A value which indicates the type of font style (such as slope or incline).</para>
		/// </returns>
		// https://docs.microsoft.com/en-us/windows/win32/api/dwrite/nf-dwrite-idwritetextformat-getfontstyle DWRITE_FONT_STYLE GetFontStyle();
		[PreserveSig]
		new DWRITE_FONT_STYLE GetFontStyle();

		/// <summary>Gets the font stretch of the text.</summary>
		/// <returns>
		/// <para>Type: <c>DWRITE_FONT_STRETCH</c></para>
		/// <para>A value which indicates the type of font stretch (such as normal or condensed).</para>
		/// </returns>
		// https://docs.microsoft.com/en-us/windows/win32/api/dwrite/nf-dwrite-idwritetextformat-getfontstretch DWRITE_FONT_STRETCH GetFontStretch();
		[PreserveSig]
		new DWRITE_FONT_STRETCH GetFontStretch();

		/// <summary>Gets the font size in DIP unites.</summary>
		/// <returns>
		/// <para>Type: <c>FLOAT</c></para>
		/// <para>The current font size in DIP units.</para>
		/// </returns>
		// https://docs.microsoft.com/en-us/windows/win32/api/dwrite/nf-dwrite-idwritetextformat-getfontsize FLOAT GetFontSize();
		[PreserveSig]
		new float GetFontSize();

		/// <summary>Gets the length of the locale name.</summary>
		/// <returns>
		/// <para>Type: <c>UINT32</c></para>
		/// <para>The size of the character array in character count, not including the terminated <c>NULL</c> character.</para>
		/// </returns>
		// https://docs.microsoft.com/en-us/windows/win32/api/dwrite/nf-dwrite-idwritetextformat-getlocalenamelength UINT32 GetLocaleNameLength();
		[PreserveSig]
		new uint GetLocaleNameLength();

		/// <summary>Gets a copy of the locale name.</summary>
		/// <param name="localeName">
		/// <para>Type: <c>WCHAR*</c></para>
		/// <para>Contains a character array that receives the current locale name.</para>
		/// </param>
		/// <param name="nameSize">
		/// <para>Type: <c>UINT32</c></para>
		/// <para>
		/// The size of the character array, in character count, including the terminated <c>NULL</c> character. Use GetLocaleNameLength to
		/// get the size of the locale name character array.
		/// </para>
		/// </param>
		// https://docs.microsoft.com/en-us/windows/win32/api/dwrite/nf-dwrite-idwritetextformat-getlocalename HRESULT GetLocaleName( WCHAR
		// *localeName, UINT32 nameSize );
		new void GetLocaleName([MarshalAs(UnmanagedType.LPWStr)] StringBuilder localeName, uint nameSize);

		/// <summary>Sets the layout maximum width.</summary>
		/// <param name="maxWidth">
		/// <para>Type: <c>FLOAT</c></para>
		/// <para>A value that indicates the maximum width of the layout box.</para>
		/// </param>
		// https://docs.microsoft.com/en-us/windows/win32/api/dwrite/nf-dwrite-idwritetextlayout-setmaxwidth HRESULT SetMaxWidth( FLOAT
		// maxWidth );
		new void SetMaxWidth(float maxWidth);

		/// <summary>Sets the layout maximum height.</summary>
		/// <param name="maxHeight">
		/// <para>Type: <c>FLOAT</c></para>
		/// <para>A value that indicates the maximum height of the layout box.</para>
		/// </param>
		// https://docs.microsoft.com/en-us/windows/win32/api/dwrite/nf-dwrite-idwritetextlayout-setmaxheight HRESULT SetMaxHeight( FLOAT
		// maxHeight );
		new void SetMaxHeight(float maxHeight);

		/// <summary>Sets the font collection.</summary>
		/// <param name="fontCollection">
		/// <para>Type: <c>IDWriteFontCollection*</c></para>
		/// <para>The font collection to set.</para>
		/// </param>
		/// <param name="textRange">
		/// <para>Type: <c>DWRITE_TEXT_RANGE</c></para>
		/// <para>Text range to which this change applies.</para>
		/// </param>
		// https://docs.microsoft.com/en-us/windows/win32/api/dwrite/nf-dwrite-idwritetextlayout-setfontcollection HRESULT
		// SetFontCollection( IDWriteFontCollection *fontCollection, DWRITE_TEXT_RANGE textRange );
		new void SetFontCollection([In] IDWriteFontCollection fontCollection, DWRITE_TEXT_RANGE textRange);

		/// <summary>Sets null-terminated font family name for text within a specified text range.</summary>
		/// <param name="fontFamilyName">
		/// <para>Type: <c>const WCHAR*</c></para>
		/// <para>The font family name that applies to the entire text string within the range specified by textRange.</para>
		/// </param>
		/// <param name="textRange">
		/// <para>Type: <c>DWRITE_TEXT_RANGE</c></para>
		/// <para>Text range to which this change applies.</para>
		/// </param>
		// https://docs.microsoft.com/en-us/windows/win32/api/dwrite/nf-dwrite-idwritetextlayout-setfontfamilyname HRESULT
		// SetFontFamilyName( WCHAR const *fontFamilyName, DWRITE_TEXT_RANGE textRange );
		new void SetFontFamilyName([MarshalAs(UnmanagedType.LPWStr)] string fontFamilyName, DWRITE_TEXT_RANGE textRange);

		/// <summary>Sets the font weight for text within a text range specified by a DWRITE_TEXT_RANGE structure.</summary>
		/// <param name="fontWeight">
		/// <para>Type: <c>DWRITE_FONT_WEIGHT</c></para>
		/// <para>The font weight to be set for text within the range specified by textRange.</para>
		/// </param>
		/// <param name="textRange">
		/// <para>Type: <c>DWRITE_TEXT_RANGE</c></para>
		/// <para>Text range to which this change applies.</para>
		/// </param>
		/// <remarks>
		/// <para>
		/// The font weight can be set to one of the predefined font weight values provided in the DWRITE_FONT_WEIGHT enumeration or an
		/// integer from 1 to 999. Values outside this range will cause the method to fail with an <c>E_INVALIDARG</c> return value.
		/// </para>
		/// <para>The following illustration shows an example of Normal and UltraBold weights for the Palatino Linotype typeface.</para>
		/// <para>Examples</para>
		/// <para>The following code illustrates how to set the font weight to bold.</para>
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows/win32/api/dwrite/nf-dwrite-idwritetextlayout-setfontweight HRESULT SetFontWeight(
		// DWRITE_FONT_WEIGHT fontWeight, DWRITE_TEXT_RANGE textRange );
		new void SetFontWeight(DWRITE_FONT_WEIGHT fontWeight, DWRITE_TEXT_RANGE textRange);

		/// <summary>Sets the font style for text within a text range specified by a DWRITE_TEXT_RANGE structure.</summary>
		/// <param name="fontStyle">
		/// <para>Type: <c>DWRITE_FONT_STYLE</c></para>
		/// <para>The font style to be set for text within a range specified by textRange.</para>
		/// </param>
		/// <param name="textRange">
		/// <para>Type: <c>DWRITE_TEXT_RANGE</c></para>
		/// <para>The text range to which this change applies.</para>
		/// </param>
		/// <remarks>
		/// <para>
		/// The font style can be set to Normal, Italic or Oblique. The following illustration shows three styles for the Palatino font. For
		/// more information, see DWRITE_FONT_STYLE.
		/// </para>
		/// <para>Examples</para>
		/// <para>The following code illustrates how to set the font style to italic.</para>
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows/win32/api/dwrite/nf-dwrite-idwritetextlayout-setfontstyle HRESULT SetFontStyle(
		// DWRITE_FONT_STYLE fontStyle, DWRITE_TEXT_RANGE textRange );
		new void SetFontStyle(DWRITE_FONT_STYLE fontStyle, DWRITE_TEXT_RANGE textRange);

		/// <summary>Sets the font stretch for text within a specified text range.</summary>
		/// <param name="fontStretch">
		/// <para>Type: <c>DWRITE_FONT_STRETCH</c></para>
		/// <para>A value which indicates the type of font stretch for text within the range specified by textRange.</para>
		/// </param>
		/// <param name="textRange">
		/// <para>Type: <c>DWRITE_TEXT_RANGE</c></para>
		/// <para>Text range to which this change applies.</para>
		/// </param>
		// https://docs.microsoft.com/en-us/windows/win32/api/dwrite/nf-dwrite-idwritetextlayout-setfontstretch HRESULT SetFontStretch(
		// DWRITE_FONT_STRETCH fontStretch, DWRITE_TEXT_RANGE textRange );
		new void SetFontStretch(DWRITE_FONT_STRETCH fontStretch, DWRITE_TEXT_RANGE textRange);

		/// <summary>Sets the font size in DIP units for text within a specified text range.</summary>
		/// <param name="fontSize">
		/// <para>Type: <c>FLOAT</c></para>
		/// <para>The font size in DIP units to be set for text in the range specified by textRange.</para>
		/// </param>
		/// <param name="textRange">
		/// <para>Type: <c>DWRITE_TEXT_RANGE</c></para>
		/// <para>Text range to which this change applies.</para>
		/// </param>
		// https://docs.microsoft.com/en-us/windows/win32/api/dwrite/nf-dwrite-idwritetextlayout-setfontsize HRESULT SetFontSize( FLOAT
		// fontSize, DWRITE_TEXT_RANGE textRange );
		new void SetFontSize(float fontSize, DWRITE_TEXT_RANGE textRange);

		/// <summary>Sets underlining for text within a specified text range.</summary>
		/// <param name="hasUnderline">
		/// <para>Type: <c>BOOL</c></para>
		/// <para>A Boolean flag that indicates whether underline takes place within a specified text range.</para>
		/// </param>
		/// <param name="textRange">
		/// <para>Type: <c>DWRITE_TEXT_RANGE</c></para>
		/// <para>Text range to which this change applies.</para>
		/// </param>
		// https://docs.microsoft.com/en-us/windows/win32/api/dwrite/nf-dwrite-idwritetextlayout-setunderline HRESULT SetUnderline( BOOL
		// hasUnderline, DWRITE_TEXT_RANGE textRange );
		new void SetUnderline([MarshalAs(UnmanagedType.Bool)] bool hasUnderline, DWRITE_TEXT_RANGE textRange);

		/// <summary>Sets strikethrough for text within a specified text range.</summary>
		/// <param name="hasStrikethrough">
		/// <para>Type: <c>BOOL</c></para>
		/// <para>A Boolean flag that indicates whether strikethrough takes place in the range specified by textRange.</para>
		/// </param>
		/// <param name="textRange">
		/// <para>Type: <c>DWRITE_TEXT_RANGE</c></para>
		/// <para>Text range to which this change applies.</para>
		/// </param>
		// https://docs.microsoft.com/en-us/windows/win32/api/dwrite/nf-dwrite-idwritetextlayout-setstrikethrough HRESULT SetStrikethrough(
		// BOOL hasStrikethrough, DWRITE_TEXT_RANGE textRange );
		new void SetStrikethrough([MarshalAs(UnmanagedType.Bool)] bool hasStrikethrough, DWRITE_TEXT_RANGE textRange);

		/// <summary>Sets the application-defined drawing effect.</summary>
		/// <param name="drawingEffect">
		/// <para>Type: <c>IUnknown*</c></para>
		/// <para>
		/// Application-defined drawing effects that apply to the range. This data object will be passed back to the application's drawing
		/// callbacks for final rendering.
		/// </para>
		/// </param>
		/// <param name="textRange">
		/// <para>Type: <c>DWRITE_TEXT_RANGE</c></para>
		/// <para>The text range to which this change applies.</para>
		/// </param>
		/// <remarks>
		/// <para>
		/// An ID2D1Brush, such as a color or gradient brush, can be set as a drawing effect if you are using the
		/// ID2D1RenderTarget::DrawTextLayout to draw text and that brush will be used to draw the specified range of text.
		/// </para>
		/// <para>
		/// This drawing effect is associated with the specified range and will be passed back to the application by way of the callback
		/// when the range is drawn at drawing time.
		/// </para>
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows/win32/api/dwrite/nf-dwrite-idwritetextlayout-setdrawingeffect HRESULT SetDrawingEffect(
		// IUnknown *drawingEffect, DWRITE_TEXT_RANGE textRange );
		new void SetDrawingEffect([MarshalAs(UnmanagedType.Interface)] object drawingEffect, DWRITE_TEXT_RANGE textRange);

		/// <summary>Sets the inline object.</summary>
		/// <param name="inlineObject">
		/// <para>Type: <c>IDWriteInlineObject*</c></para>
		/// <para>An application-defined inline object.</para>
		/// </param>
		/// <param name="textRange">
		/// <para>Type: <c>DWRITE_TEXT_RANGE</c></para>
		/// <para>Text range to which this change applies.</para>
		/// </param>
		/// <remarks>
		/// <para>
		/// The application may call this function to specify the set of properties describing an application-defined inline object for
		/// specific range.
		/// </para>
		/// <para>
		/// This inline object applies to the specified range and will be passed back to the application by way of the DrawInlineObject
		/// callback when the range is drawn. Any text in that range will be suppressed.
		/// </para>
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows/win32/api/dwrite/nf-dwrite-idwritetextlayout-setinlineobject HRESULT SetInlineObject(
		// IDWriteInlineObject *inlineObject, DWRITE_TEXT_RANGE textRange );
		new void SetInlineObject([In] IDWriteInlineObject inlineObject, DWRITE_TEXT_RANGE textRange);

		/// <summary>Sets font typography features for text within a specified text range.</summary>
		/// <param name="typography">
		/// <para>Type: <c>IDWriteTypography*</c></para>
		/// <para>Pointer to font typography settings.</para>
		/// </param>
		/// <param name="textRange">
		/// <para>Type: <c>DWRITE_TEXT_RANGE</c></para>
		/// <para>Text range to which this change applies.</para>
		/// </param>
		// https://docs.microsoft.com/en-us/windows/win32/api/dwrite/nf-dwrite-idwritetextlayout-settypography HRESULT SetTypography(
		// IDWriteTypography *typography, DWRITE_TEXT_RANGE textRange );
		new void SetTypography([In] IDWriteTypography typography, DWRITE_TEXT_RANGE textRange);

		/// <summary>Sets the locale name for text within a specified text range.</summary>
		/// <param name="localeName">
		/// <para>Type: <c>const WCHAR*</c></para>
		/// <para>A null-terminated locale name string.</para>
		/// </param>
		/// <param name="textRange">
		/// <para>Type: <c>DWRITE_TEXT_RANGE</c></para>
		/// <para>Text range to which this change applies.</para>
		/// </param>
		// https://docs.microsoft.com/en-us/windows/win32/api/dwrite/nf-dwrite-idwritetextlayout-setlocalename HRESULT SetLocaleName( WCHAR
		// const *localeName, DWRITE_TEXT_RANGE textRange );
		new void SetLocaleName([MarshalAs(UnmanagedType.LPWStr)] string localeName, DWRITE_TEXT_RANGE textRange);

		/// <summary>Gets the layout maximum width.</summary>
		/// <returns>
		/// <para>Type: <c>FLOAT</c></para>
		/// <para>Returns the layout maximum width.</para>
		/// </returns>
		// https://docs.microsoft.com/en-us/windows/win32/api/dwrite/nf-dwrite-idwritetextlayout-getmaxwidth FLOAT GetMaxWidth();
		[PreserveSig]
		new float GetMaxWidth();

		/// <summary>Gets the layout maximum height.</summary>
		/// <returns>
		/// <para>Type: <c>FLOAT</c></para>
		/// <para>The layout maximum height.</para>
		/// </returns>
		// https://docs.microsoft.com/en-us/windows/win32/api/dwrite/nf-dwrite-idwritetextlayout-getmaxheight FLOAT GetMaxHeight();
		[PreserveSig]
		new float GetMaxHeight();

		/// <summary>Gets the font collection associated with the text at the specified position.</summary>
		/// <param name="currentPosition">
		/// <para>Type: <c>UINT32</c></para>
		/// <para>The position of the text to inspect.</para>
		/// </param>
		/// <param name="fontCollection">
		/// <para>Type: <c>IDWriteFontCollection**</c></para>
		/// <para>Contains an address of a pointer to the current font collection.</para>
		/// </param>
		/// <param name="textRange">
		/// <para>Type: <c>DWRITE_TEXT_RANGE*</c></para>
		/// <para>
		/// The range of text that has the same formatting as the text at the position specified by currentPosition. This means the run has
		/// the exact formatting as the position specified, including but not limited to the underline.
		/// </para>
		/// </param>
		// https://docs.microsoft.com/en-us/windows/win32/api/dwrite/nf-dwrite-idwritetextlayout-getfontcollection HRESULT
		// GetFontCollection( UINT32 currentPosition, IDWriteFontCollection **fontCollection, DWRITE_TEXT_RANGE *textRange );
		new void GetFontCollection(uint currentPosition, out IDWriteFontCollection fontCollection, out DWRITE_TEXT_RANGE textRange);

		/// <summary>Get the length of the font family name at the current position.</summary>
		/// <param name="currentPosition">
		/// <para>Type: <c>UINT32</c></para>
		/// <para>The current text position.</para>
		/// </param>
		/// <param name="nameLength">
		/// <para>Type: <c>UINT32*</c></para>
		/// <para>
		/// When this method returns, contains the size of the character array containing the font family name, in character count, not
		/// including the terminated <c>NULL</c> character.
		/// </para>
		/// </param>
		/// <param name="textRange">
		/// <para>Type: <c>DWRITE_TEXT_RANGE*</c></para>
		/// <para>
		/// The range of text that has the same formatting as the text at the position specified by currentPosition. This means the run has
		/// the exact formatting as the position specified, including but not limited to the font family.
		/// </para>
		/// </param>
		// https://docs.microsoft.com/en-us/windows/win32/api/dwrite/nf-dwrite-idwritetextlayout-getfontfamilynamelength HRESULT
		// GetFontFamilyNameLength( UINT32 currentPosition, UINT32 *nameLength, DWRITE_TEXT_RANGE *textRange );
		new void GetFontFamilyNameLength(uint currentPosition, out uint nameLength, out DWRITE_TEXT_RANGE textRange);

		/// <summary>Copies the font family name of the text at the specified position.</summary>
		/// <param name="currentPosition">
		/// <para>Type: <c>UINT32</c></para>
		/// <para>The position of the text to examine.</para>
		/// </param>
		/// <param name="fontFamilyName">
		/// <para>Type: <c>WCHAR*</c></para>
		/// <para>
		/// When this method returns, contains an array of characters that receives the current font family name. You must allocate storage
		/// for this parameter.
		/// </para>
		/// </param>
		/// <param name="nameSize">
		/// <para>Type: <c>UINT32</c></para>
		/// <para>The size of the character array in character count including the terminated <c>NULL</c> character.</para>
		/// </param>
		/// <param name="textRange">
		/// <para>Type: <c>DWRITE_TEXT_RANGE*</c></para>
		/// <para>
		/// The range of text that has the same formatting as the text at the position specified by currentPosition. This means the run has
		/// the exact formatting as the position specified, including but not limited to the font family name.
		/// </para>
		/// </param>
		// https://docs.microsoft.com/en-us/windows/win32/api/dwrite/nf-dwrite-idwritetextlayout-getfontfamilyname HRESULT
		// GetFontFamilyName( UINT32 currentPosition, WCHAR *fontFamilyName, UINT32 nameSize, DWRITE_TEXT_RANGE *textRange );
		new void GetFontFamilyName(uint currentPosition, [MarshalAs(UnmanagedType.LPWStr)] StringBuilder fontFamilyName, uint nameSize, out DWRITE_TEXT_RANGE textRange);

		/// <summary>Gets the font weight of the text at the specified position.</summary>
		/// <param name="currentPosition">
		/// <para>Type: <c>UINT32</c></para>
		/// <para>The position of the text to inspect.</para>
		/// </param>
		/// <param name="fontWeight">
		/// <para>Type: <c>DWRITE_FONT_WEIGHT*</c></para>
		/// <para>When this method returns, contains a value which indicates the type of font weight being applied at the specified position.</para>
		/// </param>
		/// <param name="textRange">
		/// <para>Type: <c>DWRITE_TEXT_RANGE*</c></para>
		/// <para>
		/// The range of text that has the same formatting as the text at the position specified by currentPosition. This means the run has
		/// the exact formatting as the position specified, including but not limited to the font weight.
		/// </para>
		/// </param>
		// https://docs.microsoft.com/en-us/windows/win32/api/dwrite/nf-dwrite-idwritetextlayout-getfontweight HRESULT GetFontWeight( UINT32
		// currentPosition, DWRITE_FONT_WEIGHT *fontWeight, DWRITE_TEXT_RANGE *textRange );
		new void GetFontWeight(uint currentPosition, out DWRITE_FONT_WEIGHT fontWeight, out DWRITE_TEXT_RANGE textRange);

		/// <summary>Gets the font style (also known as slope) of the text at the specified position.</summary>
		/// <param name="currentPosition">
		/// <para>Type: <c>UINT32</c></para>
		/// <para>The position of the text to inspect.</para>
		/// </param>
		/// <param name="fontStyle">
		/// <para>Type: <c>DWRITE_FONT_STYLE*</c></para>
		/// <para>
		/// When this method returns, contains a value which indicates the type of font style (also known as slope or incline) being applied
		/// at the specified position.
		/// </para>
		/// </param>
		/// <param name="textRange">
		/// <para>Type: <c>DWRITE_TEXT_RANGE*</c></para>
		/// <para>
		/// The range of text that has the same formatting as the text at the position specified by currentPosition. This means the run has
		/// the exact formatting as the position specified, including but not limited to the font style.
		/// </para>
		/// </param>
		// https://docs.microsoft.com/en-us/windows/win32/api/dwrite/nf-dwrite-idwritetextlayout-getfontstyle HRESULT GetFontStyle( UINT32
		// currentPosition, DWRITE_FONT_STYLE *fontStyle, DWRITE_TEXT_RANGE *textRange );
		new void GetFontStyle(uint currentPosition, out DWRITE_FONT_STYLE fontStyle, out DWRITE_TEXT_RANGE textRange);

		/// <summary>Gets the font stretch of the text at the specified position.</summary>
		/// <param name="currentPosition">
		/// <para>Type: <c>UINT32</c></para>
		/// <para>The position of the text to inspect.</para>
		/// </param>
		/// <param name="fontStretch">
		/// <para>Type: <c>DWRITE_FONT_STRETCH*</c></para>
		/// <para>
		/// When this method returns, contains a value which indicates the type of font stretch (also known as width) being applied at the
		/// specified position.
		/// </para>
		/// </param>
		/// <param name="textRange">
		/// <para>Type: <c>DWRITE_TEXT_RANGE*</c></para>
		/// <para>
		/// The range of text that has the same formatting as the text at the position specified by currentPosition. This means the run has
		/// the exact formatting as the position specified, including but not limited to the font stretch.
		/// </para>
		/// </param>
		// https://docs.microsoft.com/en-us/windows/win32/api/dwrite/nf-dwrite-idwritetextlayout-getfontstretch HRESULT GetFontStretch(
		// UINT32 currentPosition, DWRITE_FONT_STRETCH *fontStretch, DWRITE_TEXT_RANGE *textRange );
		new void GetFontStretch(uint currentPosition, out DWRITE_FONT_STRETCH fontStretch, out DWRITE_TEXT_RANGE textRange);

		/// <summary>Gets the font em height of the text at the specified position.</summary>
		/// <param name="currentPosition">
		/// <para>Type: <c>UINT32</c></para>
		/// <para>The position of the text to inspect.</para>
		/// </param>
		/// <param name="fontSize">
		/// <para>Type: <c>FLOAT*</c></para>
		/// <para>When this method returns, contains the size of the font in ems of the text at the specified position.</para>
		/// </param>
		/// <param name="textRange">
		/// <para>Type: <c>DWRITE_TEXT_RANGE*</c></para>
		/// <para>
		/// The range of text that has the same formatting as the text at the position specified by currentPosition. This means the run has
		/// the exact formatting as the position specified, including but not limited to the font size.
		/// </para>
		/// </param>
		// https://docs.microsoft.com/en-us/windows/win32/api/dwrite/nf-dwrite-idwritetextlayout-getfontsize HRESULT GetFontSize( UINT32
		// currentPosition, FLOAT *fontSize, DWRITE_TEXT_RANGE *textRange );
		new void GetFontSize(uint currentPosition, out float fontSize, out DWRITE_TEXT_RANGE textRange);

		/// <summary>Gets the underline presence of the text at the specified position.</summary>
		/// <param name="currentPosition">
		/// <para>Type: <c>UINT32</c></para>
		/// <para>The current text position.</para>
		/// </param>
		/// <param name="hasUnderline">
		/// <para>Type: <c>BOOL*</c></para>
		/// <para>A Boolean flag that indicates whether underline is present at the position indicated by currentPosition.</para>
		/// </param>
		/// <param name="textRange">
		/// <para>Type: <c>DWRITE_TEXT_RANGE*</c></para>
		/// <para>
		/// The range of text that has the same formatting as the text at the position specified by currentPosition. This means the run has
		/// the exact formatting as the position specified, including but not limited to the underline.
		/// </para>
		/// </param>
		// https://docs.microsoft.com/en-us/windows/win32/api/dwrite/nf-dwrite-idwritetextlayout-getunderline HRESULT GetUnderline( UINT32
		// currentPosition, BOOL *hasUnderline, DWRITE_TEXT_RANGE *textRange );
		new void GetUnderline(uint currentPosition, [MarshalAs(UnmanagedType.Bool)] out bool hasUnderline, out DWRITE_TEXT_RANGE textRange);

		/// <summary>Get the strikethrough presence of the text at the specified position.</summary>
		/// <param name="currentPosition">
		/// <para>Type: <c>UINT32</c></para>
		/// <para>The position of the text to inspect.</para>
		/// </param>
		/// <param name="hasStrikethrough">
		/// <para>Type: <c>BOOL*</c></para>
		/// <para>A Boolean flag that indicates whether strikethrough is present at the position indicated by currentPosition.</para>
		/// </param>
		/// <param name="textRange">
		/// <para>Type: <c>DWRITE_TEXT_RANGE*</c></para>
		/// <para>
		/// Contains the range of text that has the same formatting as the text at the position specified by currentPosition. This means the
		/// run has the exact formatting as the position specified, including but not limited to strikethrough.
		/// </para>
		/// </param>
		// https://docs.microsoft.com/en-us/windows/win32/api/dwrite/nf-dwrite-idwritetextlayout-getstrikethrough HRESULT GetStrikethrough(
		// UINT32 currentPosition, BOOL *hasStrikethrough, DWRITE_TEXT_RANGE *textRange );
		new void GetStrikethrough(uint currentPosition, [MarshalAs(UnmanagedType.Bool)] out bool hasStrikethrough, out DWRITE_TEXT_RANGE textRange);

		/// <summary>Gets the application-defined drawing effect at the specified text position.</summary>
		/// <param name="currentPosition">
		/// <para>Type: <c>UINT32</c></para>
		/// <para>The position of the text whose drawing effect is to be retrieved.</para>
		/// </param>
		/// <param name="drawingEffect">
		/// <para>Type: <c>IUnknown**</c></para>
		/// <para>
		/// When this method returns, contains an address of a pointer to the current application-defined drawing effect. Usually this
		/// effect is a foreground brush that is used in glyph drawing.
		/// </para>
		/// </param>
		/// <param name="textRange">
		/// <para>Type: <c>DWRITE_TEXT_RANGE*</c></para>
		/// <para>
		/// Contains the range of text that has the same formatting as the text at the position specified by currentPosition. This means the
		/// run has the exact formatting as the position specified, including but not limited to the drawing effect.
		/// </para>
		/// </param>
		// https://docs.microsoft.com/en-us/windows/win32/api/dwrite/nf-dwrite-idwritetextlayout-getdrawingeffect HRESULT GetDrawingEffect(
		// UINT32 currentPosition, IUnknown **drawingEffect, DWRITE_TEXT_RANGE *textRange );
		new void GetDrawingEffect(uint currentPosition, [MarshalAs(UnmanagedType.Interface)] out object drawingEffect, out DWRITE_TEXT_RANGE textRange);

		/// <summary>Gets the inline object at the specified position.</summary>
		/// <param name="currentPosition">
		/// <para>Type: <c>UINT32</c></para>
		/// <para>The specified text position.</para>
		/// </param>
		/// <param name="inlineObject">
		/// <para>Type: <c>IDWriteInlineObject**</c></para>
		/// <para>Contains the application-defined inline object.</para>
		/// </param>
		/// <param name="textRange">
		/// <para>Type: <c>DWRITE_TEXT_RANGE*</c></para>
		/// <para>
		/// The range of text that has the same formatting as the text at the position specified by currentPosition. This means the run has
		/// the exact formatting as the position specified, including but not limited to the inline object.
		/// </para>
		/// </param>
		// https://docs.microsoft.com/en-us/windows/win32/api/dwrite/nf-dwrite-idwritetextlayout-getinlineobject HRESULT GetInlineObject(
		// UINT32 currentPosition, IDWriteInlineObject **inlineObject, DWRITE_TEXT_RANGE *textRange );
		new void GetInlineObject(uint currentPosition, out IDWriteInlineObject inlineObject, out DWRITE_TEXT_RANGE textRange);

		/// <summary>Gets the typography setting of the text at the specified position.</summary>
		/// <param name="currentPosition">
		/// <para>Type: <c>UINT32</c></para>
		/// <para>The position of the text to inspect.</para>
		/// </param>
		/// <param name="typography">
		/// <para>Type: <c>IDWriteTypography**</c></para>
		/// <para>When this method returns, contains an address of a pointer to the current typography setting.</para>
		/// </param>
		/// <param name="textRange">
		/// <para>Type: <c>DWRITE_TEXT_RANGE*</c></para>
		/// <para>
		/// The range of text that has the same formatting as the text at the position specified by currentPosition. This means the run has
		/// the exact formatting as the position specified, including but not limited to the typography.
		/// </para>
		/// </param>
		// https://docs.microsoft.com/en-us/windows/win32/api/dwrite/nf-dwrite-idwritetextlayout-gettypography HRESULT GetTypography( UINT32
		// currentPosition, IDWriteTypography **typography, DWRITE_TEXT_RANGE *textRange );
		new void GetTypography(uint currentPosition, out IDWriteTypography typography, out DWRITE_TEXT_RANGE textRange);

		/// <summary>Gets the length of the locale name of the text at the specified position.</summary>
		/// <param name="currentPosition">
		/// <para>Type: <c>UINT32</c></para>
		/// <para>The position of the text to inspect.</para>
		/// </param>
		/// <param name="nameLength">
		/// <para>Type: <c>UINT32*</c></para>
		/// <para>Size of the character array, in character count, not including the terminated <c>NULL</c> character.</para>
		/// </param>
		/// <param name="textRange">
		/// <para>Type: <c>DWRITE_TEXT_RANGE*</c></para>
		/// <para>
		/// The range of text that has the same formatting as the text at the position specified by currentPosition. This means the run has
		/// the exact formatting as the position specified, including but not limited to the locale name.
		/// </para>
		/// </param>
		// https://docs.microsoft.com/en-us/windows/win32/api/dwrite/nf-dwrite-idwritetextlayout-getlocalenamelength HRESULT
		// GetLocaleNameLength( UINT32 currentPosition, UINT32 *nameLength, DWRITE_TEXT_RANGE *textRange );
		new void GetLocaleNameLength(uint currentPosition, out uint nameLength, out DWRITE_TEXT_RANGE textRange);

		/// <summary>Gets the locale name of the text at the specified position.</summary>
		/// <param name="currentPosition">
		/// <para>Type: <c>UINT32</c></para>
		/// <para>The position of the text to inspect.</para>
		/// </param>
		/// <param name="localeName">
		/// <para>Type: <c>WCHAR*</c></para>
		/// <para>When this method returns, contains the character array receiving the current locale name.</para>
		/// </param>
		/// <param name="nameSize">
		/// <para>Type: <c>UINT32</c></para>
		/// <para>Size of the character array, in character count, including the terminated <c>NULL</c> character.</para>
		/// </param>
		/// <param name="textRange">
		/// <para>Type: <c>DWRITE_TEXT_RANGE*</c></para>
		/// <para>
		/// The range of text that has the same formatting as the text at the position specified by currentPosition. This means the run has
		/// the exact formatting as the position specified, including but not limited to the locale name.
		/// </para>
		/// </param>
		// https://docs.microsoft.com/en-us/windows/win32/api/dwrite/nf-dwrite-idwritetextlayout-getlocalename HRESULT GetLocaleName( UINT32
		// currentPosition, WCHAR *localeName, UINT32 nameSize, DWRITE_TEXT_RANGE *textRange );
		new void GetLocaleName(uint currentPosition, [MarshalAs(UnmanagedType.LPWStr)] StringBuilder localeName, uint nameSize, out DWRITE_TEXT_RANGE textRange);

		/// <summary>Draws text using the specified client drawing context.</summary>
		/// <param name="clientDrawingContext">
		/// <para>Type: <c>void*</c></para>
		/// <para>An application-defined drawing context.</para>
		/// </param>
		/// <param name="renderer">
		/// <para>Type: <c>IDWriteTextRenderer*</c></para>
		/// <para>Pointer to the set of callback functions used to draw parts of a text string.</para>
		/// </param>
		/// <param name="originX">
		/// <para>Type: <c>FLOAT</c></para>
		/// <para>The x-coordinate of the layout's left side.</para>
		/// </param>
		/// <param name="originY">
		/// <para>Type: <c>FLOAT</c></para>
		/// <para>The y-coordinate of the layout's top side.</para>
		/// </param>
		/// <returns>
		/// <para>Type: <c>HRESULT</c></para>
		/// <para>If this method succeeds, it returns <c>S_OK</c>. Otherwise, it returns an <c>HRESULT</c> error code.</para>
		/// </returns>
		/// <remarks>
		/// <para>To draw text with this method, a textLayout object needs to be created by the application using IDWriteFactory::CreateTextLayout.</para>
		/// <para>
		/// After the textLayout object is obtained, the application calls the <c>IDWriteTextLayout::Draw</c> method to draw the text,
		/// decorations, and inline objects. The actual drawing is done through the callback interface passed in as the textRenderer
		/// argument; there, the corresponding DrawGlyphRun API is called.
		/// </para>
		/// <para>
		/// If you set a vertical text reading direction on IDWriteTextLayout via SetReadingDirection with
		/// DWRITE_READING_DIRECTION_TOP_TO_BOTTOM (or bottom to top), then you must pass an interface that implements IDWriteTextRenderer1.
		/// Otherwise you get the error DWRITE_E_TEXTRENDERERINCOMPATIBLE because the original IDWriteTextRenderer interface only supported
		/// horizontal text.
		/// </para>
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows/win32/api/dwrite/nf-dwrite-idwritetextlayout-draw HRESULT Draw( void
		// *clientDrawingContext, IDWriteTextRenderer *renderer, FLOAT originX, FLOAT originY );
		new void Draw([In, Optional] IntPtr clientDrawingContext, [In] IDWriteTextRenderer renderer, float originX, float originY);

		/// <summary>Retrieves the information about each individual text line of the text string.</summary>
		/// <param name="lineMetrics">
		/// <para>Type: <c>DWRITE_LINE_METRICS*</c></para>
		/// <para>
		/// When this method returns, contains a pointer to an array of structures containing various calculated length values of individual
		/// text lines.
		/// </para>
		/// </param>
		/// <param name="maxLineCount">
		/// <para>Type: <c>UINT32</c></para>
		/// <para>The maximum size of the lineMetrics array.</para>
		/// </param>
		/// <param name="actualLineCount">
		/// <para>Type: <c>UINT32*</c></para>
		/// <para>When this method returns, contains the actual size of the lineMetricsarray that is needed.</para>
		/// </param>
		/// <returns>
		/// <para>Type: <c>HRESULT</c></para>
		/// <para>If this method succeeds, it returns <c>S_OK</c>. Otherwise, it returns an <c>HRESULT</c> error code.</para>
		/// </returns>
		/// <remarks>
		/// If maxLineCount is not large enough E_NOT_SUFFICIENT_BUFFER, which is equivalent to
		/// HRESULT_FROM_WIN32(ERROR_INSUFFICIENT_BUFFER), is returned and *actualLineCount is set to the number of lines needed.
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows/win32/api/dwrite/nf-dwrite-idwritetextlayout-getlinemetrics HRESULT GetLineMetrics(
		// DWRITE_LINE_METRICS *lineMetrics, UINT32 maxLineCount, UINT32 *actualLineCount );
		new void GetLineMetrics([Out, Optional, MarshalAs(UnmanagedType.LPArray)] DWRITE_LINE_METRICS[]? lineMetrics, uint maxLineCount, out uint actualLineCount);

		/// <summary>Retrieves overall metrics for the formatted string.</summary>
		/// <returns>
		/// <para>Type: <c>DWRITE_TEXT_METRICS*</c></para>
		/// <para>When this method returns, contains the measured distances of text and associated content after being formatted.</para>
		/// </returns>
		// https://docs.microsoft.com/en-us/windows/win32/api/dwrite/nf-dwrite-idwritetextlayout-getmetrics HRESULT GetMetrics(
		// DWRITE_TEXT_METRICS *textMetrics );
		new DWRITE_TEXT_METRICS GetMetrics();

		/// <summary>
		/// Returns the overhangs (in DIPs) of the layout and all objects contained in it, including text glyphs and inline objects.
		/// </summary>
		/// <returns>
		/// <para>Type: <c>DWRITE_OVERHANG_METRICS*</c></para>
		/// <para>Overshoots of visible extents (in DIPs) outside the layout.</para>
		/// </returns>
		/// <remarks>
		/// Underlines and strikethroughs do not contribute to the black box determination, since these are actually drawn by the renderer,
		/// which is allowed to draw them in any variety of styles.
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows/win32/api/dwrite/nf-dwrite-idwritetextlayout-getoverhangmetrics HRESULT
		// GetOverhangMetrics( DWRITE_OVERHANG_METRICS *overhangs );
		new DWRITE_OVERHANG_METRICS GetOverhangMetrics();

		/// <summary>Retrieves logical properties and measurements of each glyph cluster.</summary>
		/// <param name="clusterMetrics">
		/// <para>Type: <c>DWRITE_CLUSTER_METRICS*</c></para>
		/// <para>When this method returns, contains metrics, such as line-break or total advance width, for a glyph cluster.</para>
		/// </param>
		/// <param name="maxClusterCount">
		/// <para>Type: <c>UINT32</c></para>
		/// <para>The maximum size of the clusterMetrics array.</para>
		/// </param>
		/// <param name="actualClusterCount">
		/// <para>Type: <c>UINT32*</c></para>
		/// <para>When this method returns, contains the actual size of the clusterMetrics array that is needed.</para>
		/// </param>
		/// <remarks>
		/// If maxClusterCount is not large enough, then E_NOT_SUFFICIENT_BUFFER, which is equivalent to
		/// HRESULT_FROM_WIN32(ERROR_INSUFFICIENT_BUFFER), is returned and actualClusterCount is set to the number of clusters needed.
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows/win32/api/dwrite/nf-dwrite-idwritetextlayout-getclustermetrics HRESULT
		// GetClusterMetrics( DWRITE_CLUSTER_METRICS *clusterMetrics, UINT32 maxClusterCount, UINT32 *actualClusterCount );
		new void GetClusterMetrics([Out, Optional, MarshalAs(UnmanagedType.LPArray, SizeParamIndex = 1)] DWRITE_CLUSTER_METRICS[]? clusterMetrics, uint maxClusterCount, out uint actualClusterCount);

		/// <summary>
		/// Determines the minimum possible width the layout can be set to without emergency breaking between the characters of whole words occurring.
		/// </summary>
		/// <returns>
		/// <para>Type: <c>FLOAT*</c></para>
		/// <para>Minimum width.</para>
		/// </returns>
		// https://docs.microsoft.com/en-us/windows/win32/api/dwrite/nf-dwrite-idwritetextlayout-determineminwidth HRESULT
		// DetermineMinWidth( FLOAT *minWidth );
		new float DetermineMinWidth();

		/// <summary>
		/// The application calls this function passing in a specific pixel location relative to the top-left location of the layout box and
		/// obtains the information about the correspondent hit-test metrics of the text string where the hit-test has occurred. When the
		/// specified pixel location is outside the text string, the function sets the output value *isInside to <c>FALSE</c>.
		/// </summary>
		/// <param name="pointX">
		/// <para>Type: <c>FLOAT</c></para>
		/// <para>The pixel location X to hit-test, relative to the top-left location of the layout box.</para>
		/// </param>
		/// <param name="pointY">
		/// <para>Type: <c>FLOAT</c></para>
		/// <para>The pixel location Y to hit-test, relative to the top-left location of the layout box.</para>
		/// </param>
		/// <param name="isTrailingHit">
		/// <para>Type: <c>BOOL*</c></para>
		/// <para>
		/// An output flag that indicates whether the hit-test location is at the leading or the trailing side of the character. When the
		/// output *isInside value is set to <c>FALSE</c>, this value is set according to the output hitTestMetrics-&gt;textPosition value
		/// to represent the edge closest to the hit-test location.
		/// </para>
		/// </param>
		/// <param name="isInside">
		/// <para>Type: <c>BOOL*</c></para>
		/// <para>
		/// An output flag that indicates whether the hit-test location is inside the text string. When <c>FALSE</c>, the position nearest
		/// the text's edge is returned.
		/// </para>
		/// </param>
		/// <param name="hitTestMetrics">
		/// <para>Type: <c>DWRITE_HIT_TEST_METRICS*</c></para>
		/// <para>
		/// The output geometry fully enclosing the hit-test location. When the output *isInside value is set to <c>FALSE</c>, this
		/// structure represents the geometry enclosing the edge closest to the hit-test location.
		/// </para>
		/// </param>
		// https://docs.microsoft.com/en-us/windows/win32/api/dwrite/nf-dwrite-idwritetextlayout-hittestpoint HRESULT HitTestPoint( FLOAT
		// pointX, FLOAT pointY, BOOL *isTrailingHit, BOOL *isInside, DWRITE_HIT_TEST_METRICS *hitTestMetrics );
		new void HitTestPoint(float pointX, float pointY, [MarshalAs(UnmanagedType.Bool)] out bool isTrailingHit,
			[MarshalAs(UnmanagedType.Bool)] out bool isInside, out DWRITE_HIT_TEST_METRICS hitTestMetrics);

		/// <summary>
		/// The application calls this function to get the pixel location relative to the top-left of the layout box given the text position
		/// and the logical side of the position. This function is normally used as part of caret positioning of text where the caret is
		/// drawn at the location corresponding to the current text editing position. It may also be used as a way to programmatically
		/// obtain the geometry of a particular text position in UI automation.
		/// </summary>
		/// <param name="textPosition">
		/// <para>Type: <c>UINT32</c></para>
		/// <para>The text position used to get the pixel location.</para>
		/// </param>
		/// <param name="isTrailingHit">
		/// <para>Type: <c>BOOL</c></para>
		/// <para>
		/// A Boolean flag that indicates whether the pixel location is of the leading or the trailing side of the specified text position.
		/// </para>
		/// </param>
		/// <param name="pointX">
		/// <para>Type: <c>FLOAT*</c></para>
		/// <para>When this method returns, contains the output pixel location X, relative to the top-left location of the layout box.</para>
		/// </param>
		/// <param name="pointY">
		/// <para>Type: <c>FLOAT*</c></para>
		/// <para>When this method returns, contains the output pixel location Y, relative to the top-left location of the layout box.</para>
		/// </param>
		/// <param name="hitTestMetrics">
		/// <para>Type: <c>DWRITE_HIT_TEST_METRICS*</c></para>
		/// <para>When this method returns, contains the output geometry fully enclosing the specified text position.</para>
		/// </param>
		// https://docs.microsoft.com/en-us/windows/win32/api/dwrite/nf-dwrite-idwritetextlayout-hittesttextposition HRESULT
		// HitTestTextPosition( UINT32 textPosition, BOOL isTrailingHit, FLOAT *pointX, FLOAT *pointY, DWRITE_HIT_TEST_METRICS
		// *hitTestMetrics );
		new void HitTestTextPosition(uint textPosition, [MarshalAs(UnmanagedType.Bool)] bool isTrailingHit, out float pointX, out float pointY,
			out DWRITE_HIT_TEST_METRICS hitTestMetrics);

		/// <summary>
		/// <para>
		/// The application calls this function to get a set of hit-test metrics corresponding to a range of text positions. One of the main
		/// usages is to implement highlight selection of the text string.
		/// </para>
		/// <para>
		/// The function returns E_NOT_SUFFICIENT_BUFFER, which is equivalent to HRESULT_FROM_WIN32(ERROR_INSUFFICIENT_BUFFER), when the
		/// buffer size of hitTestMetrics is too small to hold all the regions calculated by the function. In this situation, the function
		/// sets the output value *actualHitTestMetricsCount to the number of geometries calculated.
		/// </para>
		/// <para>The application is responsible for allocating a new buffer of greater size and calling the function again.</para>
		/// <para>A good value to use as an initial value for maxHitTestMetricsCount may be calculated from the following equation:</para>
		/// <para>
		/// where lineCount is obtained from the value of the output argument *actualLineCount (from the function
		/// IDWriteTextLayout::GetLineLengths), and the maxBidiReorderingDepth value from the DWRITE_TEXT_METRICSstructure of the output
		/// argument *textMetrics (from the function IDWriteFactory::CreateTextLayout).
		/// </para>
		/// </summary>
		/// <param name="textPosition">
		/// <para>Type: <c>UINT32</c></para>
		/// <para>The first text position of the specified range.</para>
		/// </param>
		/// <param name="textLength">
		/// <para>Type: <c>UINT32</c></para>
		/// <para>The number of positions of the specified range.</para>
		/// </param>
		/// <param name="originX">
		/// <para>Type: <c>FLOAT</c></para>
		/// <para>The origin pixel location X at the left of the layout box. This offset is added to the hit-test metrics returned.</para>
		/// </param>
		/// <param name="originY">
		/// <para>Type: <c>FLOAT</c></para>
		/// <para>The origin pixel location Y at the top of the layout box. This offset is added to the hit-test metrics returned.</para>
		/// </param>
		/// <param name="hitTestMetrics">
		/// <para>Type: <c>DWRITE_HIT_TEST_METRICS*</c></para>
		/// <para>
		/// When this method returns, contains a pointer to a buffer of the output geometry fully enclosing the specified position range.
		/// The buffer must be at least as large as maxHitTestMetricsCount.
		/// </para>
		/// </param>
		/// <param name="maxHitTestMetricsCount">
		/// <para>Type: <c>UINT32</c></para>
		/// <para>Maximum number of boxes hitTestMetrics could hold in its buffer memory.</para>
		/// </param>
		/// <param name="actualHitTestMetricsCount">
		/// <para>Type: <c>UINT32*</c></para>
		/// <para>Actual number of geometries hitTestMetrics holds in its buffer memory.</para>
		/// </param>
		// https://docs.microsoft.com/en-us/windows/win32/api/dwrite/nf-dwrite-idwritetextlayout-hittesttextrange HRESULT HitTestTextRange(
		// UINT32 textPosition, UINT32 textLength, FLOAT originX, FLOAT originY, DWRITE_HIT_TEST_METRICS
		// *hitTestMetrics, UINT32 maxHitTestMetricsCount, UINT32 *actualHitTestMetricsCount );
		new void HitTestTextRange(uint textPosition, uint textLength, float originX, float originY,
			[Out, Optional, MarshalAs(UnmanagedType.LPArray, SizeParamIndex = 5)] DWRITE_HIT_TEST_METRICS[]? hitTestMetrics,
			uint maxHitTestMetricsCount, out uint actualHitTestMetricsCount);

		/// <summary>Enables or disables pair-kerning on a given text range.</summary>
		/// <param name="isPairKerningEnabled">
		/// <para>Type: <b>BOOL</b></para>
		/// <para>The flag that indicates whether text is pair-kerned.</para>
		/// </param>
		/// <param name="textRange">
		/// <para>Type: <b><c>DWRITE_TEXT_RANGE</c></b></para>
		/// <para>The text range to which the change applies.</para>
		/// </param>
		// https://learn.microsoft.com/en-us/windows/win32/api/dwrite_1/nf-dwrite_1-idwritetextlayout1-setpairkerning HRESULT
		// SetPairKerning( BOOL isPairKerningEnabled, DWRITE_TEXT_RANGE textRange );
		void SetPairKerning(bool isPairKerningEnabled, DWRITE_TEXT_RANGE textRange);

		/// <summary>Gets whether or not pair-kerning is enabled at given position.</summary>
		/// <param name="currentPosition">
		/// <para>Type: <b>UINT32</b></para>
		/// <para>The current text position.</para>
		/// </param>
		/// <param name="isPairKerningEnabled">
		/// <para>Type: <b>BOOL*</b></para>
		/// <para>The flag that indicates whether text is pair-kerned.</para>
		/// </param>
		/// <param name="textRange">
		/// <para>Type: <b><c>DWRITE_TEXT_RANGE</c>*</b></para>
		/// <para>The position range of the current format.</para>
		/// </param>
		// https://learn.microsoft.com/en-us/windows/win32/api/dwrite_1/nf-dwrite_1-idwritetextlayout1-getpairkerning HRESULT
		// GetPairKerning( UINT32 currentPosition, [out] BOOL *isPairKerningEnabled, [out, optional] DWRITE_TEXT_RANGE *textRange );
		void GetPairKerning(uint currentPosition, out bool isPairKerningEnabled, [Out, Optional] StructPointer<DWRITE_TEXT_RANGE> textRange);

		/// <summary>Sets the spacing between characters.</summary>
		/// <param name="leadingSpacing">
		/// <para>Type: <b>FLOAT</b></para>
		/// <para>The spacing before each character, in reading order.</para>
		/// </param>
		/// <param name="trailingSpacing">
		/// <para>Type: <b>FLOAT</b></para>
		/// <para>The spacing after each character, in reading order.</para>
		/// </param>
		/// <param name="minimumAdvanceWidth">
		/// <para>Type: <b>FLOAT</b></para>
		/// <para>
		/// The minimum advance of each character, to prevent characters from becoming too thin or zero-width. This must be zero or greater.
		/// </para>
		/// </param>
		/// <param name="textRange">
		/// <para>Type: <b><c>DWRITE_TEXT_RANGE</c></b></para>
		/// <para>Text range to which this change applies.</para>
		/// </param>
		// https://learn.microsoft.com/en-us/windows/win32/api/dwrite_1/nf-dwrite_1-idwritetextlayout1-setcharacterspacing HRESULT
		// SetCharacterSpacing( FLOAT leadingSpacing, FLOAT trailingSpacing, FLOAT minimumAdvanceWidth, DWRITE_TEXT_RANGE textRange );
		void SetCharacterSpacing(float leadingSpacing, float trailingSpacing, float minimumAdvanceWidth, DWRITE_TEXT_RANGE textRange);

		/// <summary>Gets the spacing between characters.</summary>
		/// <param name="currentPosition">
		/// <para>Type: <b>UINT32</b></para>
		/// <para>The current text position.</para>
		/// </param>
		/// <param name="leadingSpacing">
		/// <para>Type: <b>FLOAT*</b></para>
		/// <para>The spacing before each character, in reading order.</para>
		/// </param>
		/// <param name="trailingSpacing">
		/// <para>Type: <b>FLOAT*</b></para>
		/// <para>The spacing after each character, in reading order.</para>
		/// </param>
		/// <param name="minimumAdvanceWidth">
		/// <para>Type: <b>FLOAT*</b></para>
		/// <para>
		/// The minimum advance of each character, to prevent characters from becoming too thin or zero-width. This must be zero or greater.
		/// </para>
		/// </param>
		/// <param name="textRange">
		/// <para>Type: <b><c>DWRITE_TEXT_RANGE</c>*</b></para>
		/// <para>The position range of the current format.</para>
		/// </param>
		// https://learn.microsoft.com/en-us/windows/win32/api/dwrite_1/nf-dwrite_1-idwritetextlayout1-getcharacterspacing HRESULT
		// GetCharacterSpacing( UINT32 currentPosition, [out] FLOAT *leadingSpacing, [out] FLOAT *trailingSpacing, [out] FLOAT
		// *minimumAdvanceWidth, [out, optional] DWRITE_TEXT_RANGE *textRange );
		void GetCharacterSpacing(uint currentPosition, out float leadingSpacing, out float trailingSpacing, out float minimumAdvanceWidth,
			[Out, Optional] StructPointer<DWRITE_TEXT_RANGE> textRange);
	}

	/// <summary>The <b>DWRITE_CARET_METRICS</b> structure specifies the metrics for caret placement in a font.</summary>
	// https://learn.microsoft.com/en-us/windows/win32/api/dwrite_1/ns-dwrite_1-dwrite_caret_metrics struct DWRITE_CARET_METRICS { INT16
	// slopeRise; INT16 slopeRun; INT16 offset; };
	[PInvokeData("dwrite_1.h", MSDNShortId = "NS:dwrite_1.DWRITE_CARET_METRICS")]
	[StructLayout(LayoutKind.Sequential)]
	public struct DWRITE_CARET_METRICS
	{
		/// <summary>
		/// Vertical rise of the caret in font design units. Rise / Run yields the caret angle. Rise = 1 for perfectly upright fonts (non-italic).
		/// </summary>
		public short slopeRise;

		/// <summary>
		/// Horizontal run of the caret in font design units. Rise / Run yields the caret angle. Run = 0 for perfectly upright fonts (non-italic).
		/// </summary>
		public short slopeRun;

		/// <summary>
		/// Horizontal offset of the caret, in font design units, along the baseline for good appearance. Offset = 0 for perfectly upright
		/// fonts (non-italic).
		/// </summary>
		public short offset;
	}

	/// <summary>The <b>DWRITE_FONT_METRICS1</b> structure specifies the metrics that are applicable to all glyphs within the font face.</summary>
	/// <remarks>
	/// <para><b>DWRITE_FONT_METRICS1</b> inherits from <c>DWRITE_FONT_METRICS</c>:</para>
	/// <para><c>struct DWRITE_FONT_METRICS1 : public DWRITE_FONT_METRICS { ... };</c></para>
	/// </remarks>
	// https://learn.microsoft.com/en-us/windows/win32/api/dwrite_1/ns-dwrite_1-dwrite_font_metrics1 struct DWRITE_FONT_METRICS1 :
	// DWRITE_FONT_METRICS { INT16 glyphBoxLeft; INT16 glyphBoxTop; INT16 glyphBoxRight; INT16 glyphBoxBottom; INT16 subscriptPositionX;
	// INT16 subscriptPositionY; INT16 subscriptSizeX; INT16 subscriptSizeY; INT16 superscriptPositionX; INT16 superscriptPositionY; INT16
	// superscriptSizeX; INT16 superscriptSizeY; BOOL hasTypographicMetrics; };
	[PInvokeData("dwrite_1.h", MSDNShortId = "NS:dwrite_1.DWRITE_FONT_METRICS1")]
	[StructLayout(LayoutKind.Sequential)]
	public struct DWRITE_FONT_METRICS1
	{
		/// <summary>
		/// <para>Type: <c>UINT16</c></para>
		/// <para>
		/// The number of font design units per em unit. Font files use their own coordinate system of font design units. A font design unit
		/// is the smallest measurable unit in the em square, an imaginary square that is used to size and align glyphs. The concept of em
		/// square is used as a reference scale factor when defining font size and device transformation semantics. The size of one em
		/// square is also commonly used to compute the paragraph identation value.
		/// </para>
		/// </summary>
		public ushort designUnitsPerEm;

		/// <summary>
		/// <para>Type: <c>UINT16</c></para>
		/// <para>
		/// The ascent value of the font face in font design units. Ascent is the distance from the top of font character alignment box to
		/// the English baseline.
		/// </para>
		/// </summary>
		public ushort ascent;

		/// <summary>
		/// <para>Type: <c>UINT16</c></para>
		/// <para>
		/// The descent value of the font face in font design units. Descent is the distance from the bottom of font character alignment box
		/// to the English baseline.
		/// </para>
		/// </summary>
		public ushort descent;

		/// <summary>
		/// <para>Type: <c>INT16</c></para>
		/// <para>
		/// The line gap in font design units. Recommended additional white space to add between lines to improve legibility. The
		/// recommended line spacing (baseline-to-baseline distance) is the sum of <c>ascent</c>, <c>descent</c>, and <c>lineGap</c>. The
		/// line gap is usually positive or zero but can be negative, in which case the recommended line spacing is less than the height of
		/// the character alignment box.
		/// </para>
		/// </summary>
		public short lineGap;

		/// <summary>
		/// <para>Type: <c>UINT16</c></para>
		/// <para>
		/// The cap height value of the font face in font design units. Cap height is the distance from the English baseline to the top of a
		/// typical English capital. Capital "H" is often used as a reference character for the purpose of calculating the cap height value.
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
		/// The underline position value of the font face in font design units. Underline position is the position of underline relative to
		/// the English baseline. The value is usually made negative in order to place the underline below the baseline.
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
		/// The strikethrough position value of the font face in font design units. Strikethrough position is the position of strikethrough
		/// relative to the English baseline. The value is usually made positive in order to place the strikethrough above the baseline.
		/// </para>
		/// </summary>
		public short strikethroughPosition;

		/// <summary>
		/// <para>Type: <c>UINT16</c></para>
		/// <para>The suggested strikethrough thickness value of the font face in font design units.</para>
		/// </summary>
		public ushort strikethroughThickness;

		/// <summary>Left edge of accumulated bounding blackbox of all glyphs in the font.</summary>
		public short glyphBoxLeft;

		/// <summary>Top edge of accumulated bounding blackbox of all glyphs in the font.</summary>
		public short glyphBoxTop;

		/// <summary>Right edge of accumulated bounding blackbox of all glyphs in the font.</summary>
		public short glyphBoxRight;

		/// <summary>Bottom edge of accumulated bounding blackbox of all glyphs in the font.</summary>
		public short glyphBoxBottom;

		/// <summary>
		/// Horizontal position of the subscript relative to the baseline origin. This is typically negative (to the left) in italic and
		/// oblique fonts, and zero in regular fonts.
		/// </summary>
		public short subscriptPositionX;

		/// <summary>Vertical position of the subscript relative to the baseline. This is typically negative.</summary>
		public short subscriptPositionY;

		/// <summary>
		/// Horizontal size of the subscript em box in design units, used to scale the simulated subscript relative to the full em box size.
		/// This is the numerator of the scaling ratio where denominator is the design units per em. If this member is zero, the font does
		/// not specify a scale factor, and the client uses its own policy.
		/// </summary>
		public short subscriptSizeX;

		/// <summary>
		/// Vertical size of the subscript em box in design units, used to scale the simulated subscript relative to the full em box size.
		/// This is the numerator of the scaling ratio where denominator is the design units per em. If this member is zero, the font does
		/// not specify a scale factor, and the client uses its own policy.
		/// </summary>
		public short subscriptSizeY;

		/// <summary>
		/// Horizontal position of the superscript relative to the baseline origin. This is typically positive (to the right) in italic and
		/// oblique fonts, and zero in regular fonts.
		/// </summary>
		public short superscriptPositionX;

		/// <summary>Vertical position of the superscript relative to the baseline. This is typically positive.</summary>
		public short superscriptPositionY;

		/// <summary>
		/// Horizontal size of the superscript em box in design units, used to scale the simulated superscript relative to the full em box
		/// size. This is the numerator of the scaling ratio where denominator is the design units per em. If this member is zero, the font
		/// does not specify a scale factor, and the client should use its own policy.
		/// </summary>
		public short superscriptSizeX;

		/// <summary>
		/// Vertical size of the superscript em box in design units, used to scale the simulated superscript relative to the full em box
		/// size. This is the numerator of the scaling ratio where denominator is the design units per em. If this member is zero, the font
		/// does not specify a scale factor, and the client should use its own policy.
		/// </summary>
		public short superscriptSizeY;

		/// <summary>
		/// A Boolean value that indicates that the ascent, descent, and lineGap are based on newer 'typographic' values in the font, rather
		/// than legacy values.
		/// </summary>
		[MarshalAs(UnmanagedType.Bool)] public bool hasTypographicMetrics;
	}

	/// <summary>The <b>DWRITE_JUSTIFICATION_OPPORTUNITY</b> structure specifies justification info per glyph.</summary>
	// https://learn.microsoft.com/en-us/windows/win32/api/dwrite_1/ns-dwrite_1-dwrite_justification_opportunity struct
	// DWRITE_JUSTIFICATION_OPPORTUNITY { FLOAT expansionMinimum; FLOAT expansionMaximum; FLOAT compressionMaximum; UINT32 expansionPriority
	// : 8; UINT32 compressionPriority : 8; UINT32 allowResidualExpansion : 1; UINT32 allowResidualCompression : 1; UINT32
	// applyToLeadingEdge : 1; UINT32 applyToTrailingEdge : 1; UINT32 reserved : 12; };
	[PInvokeData("dwrite_1.h", MSDNShortId = "NS:dwrite_1.DWRITE_JUSTIFICATION_OPPORTUNITY")]
	[StructLayout(LayoutKind.Sequential)]
	public struct DWRITE_JUSTIFICATION_OPPORTUNITY
	{
		/// <summary>
		/// Minimum amount of expansion to apply to the side of the glyph. This might vary from zero to infinity, typically being zero
		/// except for kashida.
		/// </summary>
		public float expansionMinimum;

		/// <summary>
		/// Maximum amount of expansion to apply to the side of the glyph. This might vary from zero to infinity, being zero for fixed-size
		/// characters and connected scripts, and non-zero for discrete scripts, and non-zero for cursive scripts at expansion points.
		/// </summary>
		public float expansionMaximum;

		/// <summary>
		/// Maximum amount of compression to apply to the side of the glyph. This might vary from zero up to the glyph cluster size.
		/// </summary>
		public float compressionMaximum;

		private uint bits;

		/// <summary>Priority of this expansion point. Larger priorities are applied later, while priority zero does nothing.</summary>
		public byte expansionPriority { get => (byte)BitHelper.GetBits(bits, 0, 8); set => BitHelper.SetBits(ref bits, 0, 8, value); }

		/// <summary>Priority of this compression point. Larger priorities are applied later, while priority zero does nothing.</summary>
		public byte compressionPriority { get => (byte)BitHelper.GetBits(bits, 8, 8); set => BitHelper.SetBits(ref bits, 8, 8, value); }

		/// <summary>
		/// Allow this expansion point to use up any remaining slack space even after all expansion priorities have been used up.
		/// </summary>
		public bool allowResidualExpansion { get => BitHelper.GetBit(bits, 16); set => BitHelper.SetBit(ref bits, 16, value); }

		/// <summary>
		/// Allow this compression point to use up any remaining space even after all compression priorities have been used up.
		/// </summary>
		public bool allowResidualCompression { get => BitHelper.GetBit(bits, 17); set => BitHelper.SetBit(ref bits, 17, value); }

		/// <summary>
		/// Apply expansion and compression to the leading edge of the glyph. This bit is <b>FALSE</b> (0) for connected scripts, fixed-size
		/// characters, and diacritics. It is generally <b>FALSE</b> within a multi-glyph cluster, unless the script allows expansion of
		/// glyphs within a cluster, like Thai.
		/// </summary>
		public bool applyToLeadingEdge { get => BitHelper.GetBit(bits, 18); set => BitHelper.SetBit(ref bits, 18, value); }

		/// <summary>
		/// Apply expansion and compression to the trailing edge of the glyph. This bit is <b>FALSE</b> (0) for connected scripts,
		/// fixed-size characters, and diacritics. It is generally <b>FALSE</b> within a multi-glyph cluster, unless the script allows
		/// expansion of glyphs within a cluster, like Thai.
		/// </summary>
		public bool applyToTrailingEdge { get => BitHelper.GetBit(bits, 19); set => BitHelper.SetBit(ref bits, 19, value); }
	}

	/// <summary>
	/// The <b>DWRITE_PANOSE</b> union describes typeface classification values that you use with <c>IDWriteFont1::GetPanose</c> to select
	/// and match the font.
	/// </summary>
	/// <remarks>
	/// <para>
	/// <b>Note</b>  The <b>familyKind</b> member (index 0) is the only stable entry in the 10-byte array because all the entries that
	/// follow can change dynamically depending on the context of the first member.
	/// </para>
	/// <para></para>
	/// </remarks>
	// https://learn.microsoft.com/en-us/windows/win32/api/dwrite_1/ns-dwrite_1-dwrite_panose union DWRITE_PANOSE { UINT8 values[10]; UINT8
	// familyKind; struct { UINT8 familyKind; UINT8 serifStyle; UINT8 weight; UINT8 proportion; UINT8 contrast; UINT8 strokeVariation; UINT8
	// armStyle; UINT8 letterform; UINT8 midline; UINT8 xHeight; } text; struct { UINT8 familyKind; UINT8 toolKind; UINT8 weight; UINT8
	// spacing; UINT8 aspectRatio; UINT8 contrast; UINT8 scriptTopology; UINT8 scriptForm; UINT8 finials; UINT8 xAscent; } script; struct {
	// UINT8 familyKind; UINT8 decorativeClass; UINT8 weight; UINT8 aspect; UINT8 contrast; UINT8 serifVariant; UINT8 fill; UINT8 lining;
	// UINT8 decorativeTopology; UINT8 characterRange; } decorative; struct { UINT8 familyKind; UINT8 symbolKind; UINT8 weight; UINT8
	// spacing; UINT8 aspectRatioAndContrast; UINT8 aspectRatio94; UINT8 aspectRatio119; UINT8 aspectRatio157; UINT8 aspectRatio163; UINT8
	// aspectRatio211; } symbol; };
	[PInvokeData("dwrite_1.h", MSDNShortId = "NS:dwrite_1.DWRITE_PANOSE")]
	[StructLayout(LayoutKind.Explicit, Pack = 1)]
	public struct DWRITE_PANOSE
	{
		/// <summary>A 10-byte array of typeface classification values.</summary>
		[FieldOffset(0)]
		public unsafe fixed byte values[10];

		/// <summary>A DWRITE_PANOSE_FAMILY-typed value that specifies the typeface classification values to get.</summary>
		[FieldOffset(0)]
		public DWRITE_PANOSE_FAMILY familyKind;

		/// <summary>The text structure.</summary>
		[FieldOffset(0)]
		public TEXT text;

		/// <summary>The script structure.</summary>
		[FieldOffset(0)]
		public SCRIPT script;

		/// <summary>The decorative structure.</summary>
		[FieldOffset(0)]
		public DECORATIVE decorative;

		/// <summary>The symbol structure.</summary>
		[FieldOffset(0)]
		public SYMBOL symbol;

		/// <summary>The text structure.</summary>
		[StructLayout(LayoutKind.Sequential)]
		public struct TEXT
		{
			/// <summary>The DWRITE_PANOSE_FAMILY_TEXT_DISPLAY value (2) that specifies text display typeface classification.</summary>
			public byte familyKind;

			/// <summary>A DWRITE_PANOSE_SERIF_STYLE-typed value that specifies the serif style of text.</summary>
			public byte serifStyle;

			/// <summary>A DWRITE_PANOSE_WEIGHT-typed value that specifies the weight of the text.</summary>
			public byte weight;

			/// <summary>A DWRITE_PANOSE_PROPORTION-typed value that specifies the proportion for the text.</summary>
			public byte proportion;

			/// <summary>A DWRITE_PANOSE_CONTRAST-typed value that specifies the contrast for the text.</summary>
			public byte contrast;

			/// <summary>A DWRITE_PANOSE_STROKE_VARIATION-typed value that specifies the stroke variation for the text.</summary>
			public byte strokeVariation;

			/// <summary>A DWRITE_PANOSE_ARM_STYLE-typed value that specifies the arm style of text.</summary>
			public byte armStyle;

			/// <summary>A DWRITE_PANOSE_LETTERFORM-typed value that specifies the letter form for the text.</summary>
			public byte letterform;

			/// <summary>A DWRITE_PANOSE_MIDLINE-typed value that specifies the midline for the text.</summary>
			public byte midline;

			/// <summary>A DWRITE_PANOSE_XHEIGHT-typed value that specifies the relative size of lowercase text.</summary>
			public byte xHeight;
		}

		/// <summary>The script structure.</summary>
		[StructLayout(LayoutKind.Sequential)]
		public struct SCRIPT
		{
			/// <summary>The DWRITE_PANOSE_FAMILY_SCRIPT value (3) that specifies script typeface classification.</summary>
			public byte familyKind;

			/// <summary>A DWRITE_PANOSE_TOOL_KIND-typed value that specifies the kind of tool for the script.</summary>
			public byte toolKind;

			/// <summary>A DWRITE_PANOSE_WEIGHT-typed value that specifies the weight of the script.</summary>
			public byte weight;

			/// <summary>A DWRITE_PANOSE_SPACING-typed value that specifies the spacing of the script.</summary>
			public byte spacing;

			/// <summary>A DWRITE_PANOSE_ASPECT_RATIO-typed value that specifies the aspect ratio of the script.</summary>
			public byte aspectRatio;

			/// <summary>A DWRITE_PANOSE_CONTRAST-typed value that specifies the contrast for the script.</summary>
			public byte contrast;

			/// <summary>A DWRITE_PANOSE_SCRIPT_TOPOLOGY-typed value that specifies the script topology.</summary>
			public byte scriptTopology;

			/// <summary>A DWRITE_PANOSE_SCRIPT_FORM-typed value that specifies the script form.</summary>
			public byte scriptForm;

			/// <summary>A DWRITE_PANOSE_FINIALS-typed value that specifies the script finials.</summary>
			public byte finials;

			/// <summary>A DWRITE_PANOSE_XASCENT-typed value that specifies the relative size of lowercase letters.</summary>
			public byte xAscent;
		}

		/// <summary>The decorative structure.</summary>
		[StructLayout(LayoutKind.Sequential)]
		public struct DECORATIVE
		{
			/// <summary>The DWRITE_PANOSE_FAMILY_DECORATIVE value (4) that specifies decorative typeface classification.</summary>
			public byte familyKind;

			/// <summary>A DWRITE_PANOSE_DECORATIVE_CLASS-typed value that specifies the class of the decorative typeface.</summary>
			public byte decorativeClass;

			/// <summary>A DWRITE_PANOSE_WEIGHT-typed value that specifies the weight of the decorative typeface.</summary>
			public byte weight;

			/// <summary>A DWRITE_PANOSE_ASPECT-typed value that specifies the aspect of the decorative typeface.</summary>
			public byte aspect;

			/// <summary>A DWRITE_PANOSE_CONTRAST-typed value that specifies the contrast for the decorative typeface.</summary>
			public byte contrast;

			/// <summary>The serif variant of the decorative typeface.</summary>
			public byte serifVariant;

			/// <summary>A DWRITE_PANOSE_FILL-typed value that specifies the fill of the decorative typeface.</summary>
			public byte fill;

			/// <summary>A DWRITE_PANOSE_LINING-typed value that specifies the lining of the decorative typeface.</summary>
			public byte lining;

			/// <summary>A DWRITE_PANOSE_DECORATIVE_TOPOLOGY-typed value that specifies the decorative topology.</summary>
			public byte decorativeTopology;

			/// <summary>A DWRITE_PANOSE_CHARACTER_RANGES-typed value that specifies the character range of the decorative typeface.</summary>
			public byte characterRange;
		}

		/// <summary>The symbol structure.</summary>
		[StructLayout(LayoutKind.Sequential)]
		public struct SYMBOL
		{
			/// <summary>The DWRITE_PANOSE_FAMILY_SYMBOL value (5) that specifies symbol typeface classification.</summary>
			public byte familyKind;

			/// <summary>A DWRITE_PANOSE_SYMBOL_KIND-typed value that specifies the kind of symbol set.</summary>
			public byte symbolKind;

			/// <summary>A DWRITE_PANOSE_WEIGHT-typed value that specifies the weight of the symbol typeface.</summary>
			public byte weight;

			/// <summary>A DWRITE_PANOSE_SPACING-typed value that specifies the spacing of the symbol typeface.</summary>
			public byte spacing;

			/// <summary>A DWRITE_PANOSE_SYMBOL_ASPECT_RATIO-typed value that specifies the aspect ratio and contrast of the symbol typeface.</summary>
			public byte aspectRatioAndContrast;

			/// <summary>A DWRITE_PANOSE_SYMBOL_ASPECT_RATIO-typed value that specifies the aspect ratio 94 of the symbol typeface.</summary>
			public byte aspectRatio94;

			/// <summary>A DWRITE_PANOSE_SYMBOL_ASPECT_RATIO-typed value that specifies the aspect ratio 119 of the symbol typeface.</summary>
			public byte aspectRatio119;

			/// <summary>A DWRITE_PANOSE_SYMBOL_ASPECT_RATIO-typed value that specifies the aspect ratio 157 of the symbol typeface.</summary>
			public byte aspectRatio157;

			/// <summary>A DWRITE_PANOSE_SYMBOL_ASPECT_RATIO-typed value that specifies the aspect ratio 163 of the symbol typeface.</summary>
			public byte aspectRatio163;

			/// <summary>A DWRITE_PANOSE_SYMBOL_ASPECT_RATIO-typed value that specifies the aspect ratio 211 of the symbol typeface.</summary>
			public byte aspectRatio211;
		}
	}

	/// <summary>The <b>DWRITE_SCRIPT_PROPERTIES</b> structure specifies script properties for caret navigation and justification.</summary>
	// https://learn.microsoft.com/en-us/windows/win32/api/dwrite_1/ns-dwrite_1-dwrite_script_properties struct DWRITE_SCRIPT_PROPERTIES {
	// UINT32 isoScriptCode; UINT32 isoScriptNumber; UINT32 clusterLookahead; UINT32 justificationCharacter; UINT32 restrictCaretToClusters
	// : 1; UINT32 usesWordDividers : 1; UINT32 isDiscreteWriting : 1; UINT32 isBlockWriting : 1; UINT32 isDistributedWithinCluster : 1;
	// UINT32 isConnectedWriting : 1; UINT32 isCursiveWriting : 1; UINT32 reserved : 25; };
	[PInvokeData("dwrite_1.h", MSDNShortId = "NS:dwrite_1.DWRITE_SCRIPT_PROPERTIES")]
	[StructLayout(LayoutKind.Sequential)]
	public struct DWRITE_SCRIPT_PROPERTIES
	{
		/// <summary>
		/// <para>The standardized four character code for the given script.</para>
		/// <para>
		/// <b>Note</b>  These only include the general Unicode scripts, not any additional <c>ISO 15924</c> scripts for bibliographic distinction.
		/// </para>
		/// </summary>
		public uint isoScriptCode;

		/// <summary>The standardized numeric code, ranging 0-999.</summary>
		public uint isoScriptNumber;

		/// <summary>
		/// <para>
		/// Number of characters to estimate look-ahead for complex scripts. Latin and all Kana are generally 1. Indic scripts are up to 15,
		/// and most others are 8.
		/// </para>
		/// <para>
		/// <b>Note</b>  Combining marks and variation selectors can produce clusters that are longer than these look-aheads, so this
		/// estimate is considered typical language use. Diacritics must be tested explicitly separately.
		/// </para>
		/// </summary>
		public uint clusterLookahead;

		/// <summary>
		/// <para>Appropriate character to elongate the given script for justification. For example:</para>
		/// <list type="bullet">
		/// <item>
		/// <description>Arabic - U+0640 Tatweel</description>
		/// </item>
		/// <item>
		/// <description>Ogham - U+1680 Ogham Space Mark</description>
		/// </item>
		/// </list>
		/// </summary>
		public uint justificationCharacter;

		private uint bits;

		/// <summary>
		/// Restrict the caret to whole clusters, like Thai and Devanagari. Scripts such as Arabic by default allow navigation between
		/// clusters. Others like Thai always navigate across whole clusters.
		/// </summary>
		public bool restrictCaretToClusters { get => BitHelper.GetBit(bits, 0); set => BitHelper.SetBit(ref bits, 0, value); }

		/// <summary>
		/// The language uses dividers between words, such as spaces between Latin or the Ethiopic wordspace. Examples include Latin, Greek,
		/// Devanagari, and Ethiopic. Chinese, Korean, and Thai are excluded.
		/// </summary>
		public bool usesWordDividers { get => BitHelper.GetBit(bits, 1); set => BitHelper.SetBit(ref bits, 1, value); }

		/// <summary>
		/// The characters are discrete units from each other. This includes both block scripts and clustered scripts. Examples include
		/// Latin, Greek, Cyrillic, Hebrew, Chinese, and Thai.
		/// </summary>
		public bool isDiscreteWriting { get => BitHelper.GetBit(bits, 2); set => BitHelper.SetBit(ref bits, 2, value); }

		/// <summary>The language is a block script, expanding between characters. Examples include Chinese, Japanese, Korean, and Bopomofo.</summary>
		public bool isBlockWriting { get => BitHelper.GetBit(bits, 3); set => BitHelper.SetBit(ref bits, 3, value); }

		/// <summary>
		/// The language is justified within glyph clusters, not just between glyph clusters, such as the character sequence of Thai Lu and
		/// Sara Am (U+E026, U+E033), which form a single cluster but still expand between them. Examples include Thai, Lao, and Khmer.
		/// </summary>
		public bool isDistributedWithinCluster { get => BitHelper.GetBit(bits, 4); set => BitHelper.SetBit(ref bits, 4, value); }

		/// <summary>
		/// <para>
		/// The script's clusters are connected to each other (such as the baseline-linked Devanagari), and no separation is added between characters.
		/// </para>
		/// <para><b>Note</b>  Cursively linked scripts like Arabic are also connected (but not all connected scripts are cursive).</para>
		/// <para>Examples include Devanagari, Arabic, Syriac, Bengala, Gurmukhi, and Ogham. Latin, Chinese, and Thaana are excluded.</para>
		/// </summary>
		public bool isConnectedWriting { get => BitHelper.GetBit(bits, 5); set => BitHelper.SetBit(ref bits, 5, value); }

		/// <summary>
		/// <para>
		/// The script is naturally cursive (Arabic and Syriac), meaning it uses other justification methods like kashida extension rather
		/// than inter-character spacing.
		/// </para>
		/// <para>
		/// <b>Note</b>   Although other scripts like Latin and Japanese might actually support handwritten cursive forms, they are not
		/// considered cursive scripts.
		/// </para>
		/// <para>Examples include Arabic, Syriac, and Mongolian. Thaana, Devanagari, Latin, and Chinese are excluded.</para>
		/// </summary>
		public bool isCursiveWriting { get => BitHelper.GetBit(bits, 6); set => BitHelper.SetBit(ref bits, 6, value); }
	}

	/// <summary>The <b>DWRITE_UNICODE_RANGE</b> structure specifies the range of Unicode code points.</summary>
	// https://learn.microsoft.com/en-us/windows/win32/api/dwrite_1/ns-dwrite_1-dwrite_unicode_range struct DWRITE_UNICODE_RANGE { UINT32
	// first; UINT32 last; };
	[PInvokeData("dwrite_1.h", MSDNShortId = "NS:dwrite_1.DWRITE_UNICODE_RANGE")]
	[StructLayout(LayoutKind.Sequential)]
	public struct DWRITE_UNICODE_RANGE
	{
		/// <summary>The first code point in the Unicode range.</summary>
		public uint first;

		/// <summary>The last code point in the Unicode range.</summary>
		public uint last;
	}
}