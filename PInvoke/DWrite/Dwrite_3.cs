namespace Vanara.PInvoke;

public static partial class Dwrite
{
	/// <summary>
	/// Defines constants that specifies axes that can be applied automatically in layout during font selection. Values can be bitwise OR'd together.
	/// </summary>
	// https://learn.microsoft.com/en-us/windows/win32/api/dwrite_3/ne-dwrite_3-dwrite_automatic_font_axes typedef enum
	// DWRITE_AUTOMATIC_FONT_AXES { DWRITE_AUTOMATIC_FONT_AXES_NONE = 0x0000, DWRITE_AUTOMATIC_FONT_AXES_OPTICAL_SIZE = 0x0001 } ;
	[PInvokeData("dwrite_3.h", MSDNShortId = "NE:dwrite_3.DWRITE_AUTOMATIC_FONT_AXES")]
	[Flags]
	public enum DWRITE_AUTOMATIC_FONT_AXES
	{
		/// <summary>
		/// <para>Value:</para>
		/// <para>0x0000</para>
		/// <para>Specifies that no axes are automatically applied.</para>
		/// </summary>
		DWRITE_AUTOMATIC_FONT_AXES_NONE = 0x0,

		/// <summary>
		/// <para>Value:</para>
		/// <para>0x0001</para>
		/// <para>Specifies that—when no value is specified via</para>
		/// <para>DWRITE_FONT_AXIS_TAG_OPTICAL_SIZE</para>
		/// <para>—an appropriate optical value should be automatically chosen based on the font size (via</para>
		/// <para>IDWriteTextLayout::SetFontSize</para>
		/// <para>). You can still apply the 'opsz' value over text ranges via</para>
		/// <para>IDWriteTextFormat3::SetFontAxisValues</para>
		/// <para>, which take priority.</para>
		/// </summary>
		DWRITE_AUTOMATIC_FONT_AXES_OPTICAL_SIZE = 0x1,
	}

	/// <summary>
	/// Defines constants that specify a composite mode for combining source and destination paint elements in a color glyph. These are
	/// taken from the W3C Compositing and Blending Level 1 specification.
	/// </summary>
	// https://learn.microsoft.com/en-us/windows/windows-app-sdk/api/win32/dwrite_3/ne-dwrite_3-dwrite_color_composite_mode typedef enum
	// DWRITE_COLOR_COMPOSITE_MODE { DWRITE_COLOR_COMPOSITE_CLEAR, DWRITE_COLOR_COMPOSITE_SRC, DWRITE_COLOR_COMPOSITE_DEST,
	// DWRITE_COLOR_COMPOSITE_SRC_OVER, DWRITE_COLOR_COMPOSITE_DEST_OVER, DWRITE_COLOR_COMPOSITE_SRC_IN, DWRITE_COLOR_COMPOSITE_DEST_IN,
	// DWRITE_COLOR_COMPOSITE_SRC_OUT, DWRITE_COLOR_COMPOSITE_DEST_OUT, DWRITE_COLOR_COMPOSITE_SRC_ATOP, DWRITE_COLOR_COMPOSITE_DEST_ATOP,
	// DWRITE_COLOR_COMPOSITE_XOR, DWRITE_COLOR_COMPOSITE_PLUS, DWRITE_COLOR_COMPOSITE_SCREEN, DWRITE_COLOR_COMPOSITE_OVERLAY,
	// DWRITE_COLOR_COMPOSITE_DARKEN, DWRITE_COLOR_COMPOSITE_LIGHTEN, DWRITE_COLOR_COMPOSITE_COLOR_DODGE, DWRITE_COLOR_COMPOSITE_COLOR_BURN,
	// DWRITE_COLOR_COMPOSITE_HARD_LIGHT, DWRITE_COLOR_COMPOSITE_SOFT_LIGHT, DWRITE_COLOR_COMPOSITE_DIFFERENCE,
	// DWRITE_COLOR_COMPOSITE_EXCLUSION, DWRITE_COLOR_COMPOSITE_MULTIPLY, DWRITE_COLOR_COMPOSITE_HSL_HUE,
	// DWRITE_COLOR_COMPOSITE_HSL_SATURATION, DWRITE_COLOR_COMPOSITE_HSL_COLOR, DWRITE_COLOR_COMPOSITE_HSL_LUMINOSITY } ;
	[PInvokeData("dwrite_3.h", MSDNShortId = "NE:dwrite_3.DWRITE_COLOR_COMPOSITE_MODE")]
	public enum DWRITE_COLOR_COMPOSITE_MODE
	{
		/// <summary>One of the Porter-Duff modes.</summary>
		DWRITE_COLOR_COMPOSITE_CLEAR,

		/// <summary>One of the Porter-Duff modes.</summary>
		DWRITE_COLOR_COMPOSITE_SRC,

		/// <summary>One of the Porter-Duff modes.</summary>
		DWRITE_COLOR_COMPOSITE_DEST,

		/// <summary>One of the Porter-Duff modes.</summary>
		DWRITE_COLOR_COMPOSITE_SRC_OVER,

		/// <summary>One of the Porter-Duff modes.</summary>
		DWRITE_COLOR_COMPOSITE_DEST_OVER,

		/// <summary>One of the Porter-Duff modes.</summary>
		DWRITE_COLOR_COMPOSITE_SRC_IN,

		/// <summary>One of the Porter-Duff modes.</summary>
		DWRITE_COLOR_COMPOSITE_DEST_IN,

		/// <summary>One of the Porter-Duff modes.</summary>
		DWRITE_COLOR_COMPOSITE_SRC_OUT,

		/// <summary>One of the Porter-Duff modes.</summary>
		DWRITE_COLOR_COMPOSITE_DEST_OUT,

		/// <summary>One of the Porter-Duff modes.</summary>
		DWRITE_COLOR_COMPOSITE_SRC_ATOP,

		/// <summary>One of the Porter-Duff modes.</summary>
		DWRITE_COLOR_COMPOSITE_DEST_ATOP,

		/// <summary>One of the Porter-Duff modes.</summary>
		DWRITE_COLOR_COMPOSITE_XOR,

		/// <summary>One of the Porter-Duff modes.</summary>
		DWRITE_COLOR_COMPOSITE_PLUS,

		/// <summary>One of the separable color blend modes.</summary>
		DWRITE_COLOR_COMPOSITE_SCREEN,

		/// <summary>One of the separable color blend modes.</summary>
		DWRITE_COLOR_COMPOSITE_OVERLAY,

		/// <summary>One of the separable color blend modes.</summary>
		DWRITE_COLOR_COMPOSITE_DARKEN,

		/// <summary>One of the separable color blend modes.</summary>
		DWRITE_COLOR_COMPOSITE_LIGHTEN,

		/// <summary>One of the separable color blend modes.</summary>
		DWRITE_COLOR_COMPOSITE_COLOR_DODGE,

		/// <summary>One of the separable color blend modes.</summary>
		DWRITE_COLOR_COMPOSITE_COLOR_BURN,

		/// <summary>One of the separable color blend modes.</summary>
		DWRITE_COLOR_COMPOSITE_HARD_LIGHT,

		/// <summary>One of the separable color blend modes.</summary>
		DWRITE_COLOR_COMPOSITE_SOFT_LIGHT,

		/// <summary>One of the separable color blend modes.</summary>
		DWRITE_COLOR_COMPOSITE_DIFFERENCE,

		/// <summary>One of the separable color blend modes.</summary>
		DWRITE_COLOR_COMPOSITE_EXCLUSION,

		/// <summary>One of the separable color blend modes.</summary>
		DWRITE_COLOR_COMPOSITE_MULTIPLY,

		/// <summary>One of the non-separable color blend modes.</summary>
		DWRITE_COLOR_COMPOSITE_HSL_HUE,

		/// <summary>One of the non-separable color blend modes.</summary>
		DWRITE_COLOR_COMPOSITE_HSL_SATURATION,

		/// <summary>One of the non-separable color blend modes.</summary>
		DWRITE_COLOR_COMPOSITE_HSL_COLOR,

		/// <summary>One of the non-separable color blend modes.</summary>
		DWRITE_COLOR_COMPOSITE_HSL_LUMINOSITY,
	}

	/// <summary>
	/// Specifies the container format of a font resource. A container format is distinct from a font file format (DWRITE_FONT_FILE_TYPE)
	/// because the container describes the container in which the underlying font file is packaged.
	/// </summary>
	/// <remarks>DWRITE_CONTAINER_TYPE is returned by <c>IDWriteFactory5::AnalyzeContainerType</c></remarks>
	// https://learn.microsoft.com/en-us/windows/win32/api/dwrite_3/ne-dwrite_3-dwrite_container_type typedef enum DWRITE_CONTAINER_TYPE {
	// DWRITE_CONTAINER_TYPE_UNKNOWN, DWRITE_CONTAINER_TYPE_WOFF, DWRITE_CONTAINER_TYPE_WOFF2 } ;
	[PInvokeData("dwrite_3.h", MSDNShortId = "NE:dwrite_3.DWRITE_CONTAINER_TYPE")]
	public enum DWRITE_CONTAINER_TYPE
	{
		/// <summary/>
		DWRITE_CONTAINER_TYPE_UNKNOWN,

		/// <summary/>
		DWRITE_CONTAINER_TYPE_WOFF,

		/// <summary/>
		DWRITE_CONTAINER_TYPE_WOFF2,
	}

	/// <summary>Defines constants that specify attributes for a font axis. Values can be bitwise OR'd together.</summary>
	// https://learn.microsoft.com/en-us/windows/win32/api/dwrite_3/ne-dwrite_3-dwrite_font_axis_attributes typedef enum
	// DWRITE_FONT_AXIS_ATTRIBUTES { DWRITE_FONT_AXIS_ATTRIBUTES_NONE = 0x0000, DWRITE_FONT_AXIS_ATTRIBUTES_VARIABLE = 0x0001,
	// DWRITE_FONT_AXIS_ATTRIBUTES_HIDDEN = 0x0002 } ;
	[PInvokeData("dwrite_3.h", MSDNShortId = "NE:dwrite_3.DWRITE_FONT_AXIS_ATTRIBUTES")]
	[Flags]
	public enum DWRITE_FONT_AXIS_ATTRIBUTES
	{
		/// <summary>
		/// <para>Value:</para>
		/// <para>0x0000</para>
		/// <para>Specifies no attributes.</para>
		/// </summary>
		DWRITE_FONT_AXIS_ATTRIBUTES_NONE = 0x0,

		/// <summary>
		/// <para>Value:</para>
		/// <para>0x0001</para>
		/// <para>
		/// Specifies that this axis is implemented as a variation axis in a variable font, with a continuous range of values, such as a
		/// range of weights from 100..900. Otherwise, it is either a static axis that holds a single point, or it has a range but doesn't
		/// vary, such as optical size in the Skia Heading font (which covers a range of points but doesn't interpolate any new glyph outlines).
		/// </para>
		/// </summary>
		DWRITE_FONT_AXIS_ATTRIBUTES_VARIABLE = 0x1,

		/// <summary>
		/// <para>Value:</para>
		/// <para>0x0002</para>
		/// <para>
		/// Specifies that this axis is recommended to be remain hidden in user interfaces. The font developer may recommend this if an axis
		/// is intended to be accessed only programmatically, or is meant for font-internal or font-developer use only. The axis may be
		/// exposed in lower-level font inspection utilities, but should not be exposed in common nor even advanced-mode user interfaces in
		/// content-authoring apps.
		/// </para>
		/// </summary>
		DWRITE_FONT_AXIS_ATTRIBUTES_HIDDEN = 0x2,
	}

	/// <summary>Defines constants that specify how font families are grouped together. Used by <c>IDWriteFontCollection2</c>, for example.</summary>
	// https://learn.microsoft.com/en-us/windows/win32/api/dwrite_3/ne-dwrite_3-dwrite_font_family_model typedef enum
	// DWRITE_FONT_FAMILY_MODEL { DWRITE_FONT_FAMILY_MODEL_TYPOGRAPHIC, DWRITE_FONT_FAMILY_MODEL_WEIGHT_STRETCH_STYLE } ;
	[PInvokeData("dwrite_3.h", MSDNShortId = "NE:dwrite_3.DWRITE_FONT_FAMILY_MODEL")]
	public enum DWRITE_FONT_FAMILY_MODEL
	{
		/// <summary>
		/// <para>
		/// Families are grouped by the typographic family name preferred by the font author. The family can contain as many faces as the
		/// font author wants. This corresponds to
		/// </para>
		/// <para>DWRITE_FONT_PROPERTY_ID_TYPOGRAPHIC_FAMILY_NAME</para>
		/// <para>.</para>
		/// </summary>
		DWRITE_FONT_FAMILY_MODEL_TYPOGRAPHIC,

		/// <summary>
		/// <para>
		/// Families are grouped by the weight-stretch-style family name, where all faces that differ only by those three axes are grouped
		/// into the same family, but any other axes go into a distinct family. For example, the Sitka family with six different optical
		/// sizes yields six separate families (Sitka Caption, Display, Text, Subheading, Heading, Banner...). This corresponds to
		/// </para>
		/// <para>DWRITE_FONT_PROPERTY_ID_WEIGHT_STRETCH_STYLE_FAMILY_NAME</para>
		/// <para>.</para>
		/// </summary>
		DWRITE_FONT_FAMILY_MODEL_WEIGHT_STRETCH_STYLE,
	}

	/// <summary>Specify whether <c>DWRITE_FONT_METRICS</c>::lineGap value should be part of the line metrics</summary>
	// https://learn.microsoft.com/en-us/windows/win32/api/dwrite_3/ne-dwrite_3-dwrite_font_line_gap_usage typedef enum
	// DWRITE_FONT_LINE_GAP_USAGE { DWRITE_FONT_LINE_GAP_USAGE_DEFAULT, DWRITE_FONT_LINE_GAP_USAGE_DISABLED,
	// DWRITE_FONT_LINE_GAP_USAGE_ENABLED } ;
	[PInvokeData("dwrite_3.h", MSDNShortId = "NE:dwrite_3.DWRITE_FONT_LINE_GAP_USAGE")]
	public enum DWRITE_FONT_LINE_GAP_USAGE
	{
		/// <summary>The usage of the font line gap depends on the method used for text layout.</summary>
		DWRITE_FONT_LINE_GAP_USAGE_DEFAULT,

		/// <summary>The font line gap is excluded from line spacing.</summary>
		DWRITE_FONT_LINE_GAP_USAGE_DISABLED,

		/// <summary>The font line gap is included in line spacing.</summary>
		DWRITE_FONT_LINE_GAP_USAGE_ENABLED,
	}

	/// <summary>Identifies a string in a font.</summary>
	// https://learn.microsoft.com/en-us/windows/win32/api/dwrite_3/ne-dwrite_3-dwrite_font_property_id typedef enum DWRITE_FONT_PROPERTY_ID
	// { DWRITE_FONT_PROPERTY_ID_NONE, DWRITE_FONT_PROPERTY_ID_WEIGHT_STRETCH_STYLE_FAMILY_NAME,
	// DWRITE_FONT_PROPERTY_ID_TYPOGRAPHIC_FAMILY_NAME, DWRITE_FONT_PROPERTY_ID_WEIGHT_STRETCH_STYLE_FACE_NAME,
	// DWRITE_FONT_PROPERTY_ID_FULL_NAME, DWRITE_FONT_PROPERTY_ID_WIN32_FAMILY_NAME, DWRITE_FONT_PROPERTY_ID_POSTSCRIPT_NAME,
	// DWRITE_FONT_PROPERTY_ID_DESIGN_SCRIPT_LANGUAGE_TAG, DWRITE_FONT_PROPERTY_ID_SUPPORTED_SCRIPT_LANGUAGE_TAG,
	// DWRITE_FONT_PROPERTY_ID_SEMANTIC_TAG, DWRITE_FONT_PROPERTY_ID_WEIGHT, DWRITE_FONT_PROPERTY_ID_STRETCH, DWRITE_FONT_PROPERTY_ID_STYLE,
	// DWRITE_FONT_PROPERTY_ID_TYPOGRAPHIC_FACE_NAME, DWRITE_FONT_PROPERTY_ID_TOTAL, DWRITE_FONT_PROPERTY_ID_TOTAL_RS3,
	// DWRITE_FONT_PROPERTY_ID_PREFERRED_FAMILY_NAME, DWRITE_FONT_PROPERTY_ID_FAMILY_NAME, DWRITE_FONT_PROPERTY_ID_FACE_NAME } ;
	[PInvokeData("dwrite_3.h", MSDNShortId = "NE:dwrite_3.DWRITE_FONT_PROPERTY_ID")]
	public enum DWRITE_FONT_PROPERTY_ID
	{
		/// <summary>Unspecified font property identifier.</summary>
		DWRITE_FONT_PROPERTY_ID_NONE,

		/// <summary/>
		DWRITE_FONT_PROPERTY_ID_WEIGHT_STRETCH_STYLE_FAMILY_NAME,

		/// <summary/>
		DWRITE_FONT_PROPERTY_ID_TYPOGRAPHIC_FAMILY_NAME,

		/// <summary/>
		DWRITE_FONT_PROPERTY_ID_WEIGHT_STRETCH_STYLE_FACE_NAME,

		/// <summary>The full name of the font, for example "Arial Bold", from name id 4 in the name table.</summary>
		DWRITE_FONT_PROPERTY_ID_FULL_NAME,

		/// <summary>
		/// <para>
		/// GDI-compatible family name. Because GDI allows a maximum of four fonts per family, fonts in the same family may have different
		/// GDI-compatible family names,
		/// </para>
		/// <para>for example "Arial", "Arial Narrow", "Arial Black".</para>
		/// </summary>
		DWRITE_FONT_PROPERTY_ID_WIN32_FAMILY_NAME,

		/// <summary>The postscript name of the font, for example "GillSans-Bold", from name id 6 in the name table.</summary>
		DWRITE_FONT_PROPERTY_ID_POSTSCRIPT_NAME,

		/// <summary>Script/language tag to identify the scripts or languages that the font was primarily designed to support.</summary>
		DWRITE_FONT_PROPERTY_ID_DESIGN_SCRIPT_LANGUAGE_TAG,

		/// <summary>Script/language tag to identify the scripts or languages that the font declares it is able to support.</summary>
		DWRITE_FONT_PROPERTY_ID_SUPPORTED_SCRIPT_LANGUAGE_TAG,

		/// <summary>Semantic tag to describe the font, for example Fancy, Decorative, Handmade, Sans-serif, Swiss, Pixel, Futuristic.</summary>
		DWRITE_FONT_PROPERTY_ID_SEMANTIC_TAG,

		/// <summary>Weight of the font represented as a decimal string in the range 1-999.</summary>
		DWRITE_FONT_PROPERTY_ID_WEIGHT,

		/// <summary>Stretch of the font represented as a decimal string in the range 1-9.</summary>
		DWRITE_FONT_PROPERTY_ID_STRETCH,

		/// <summary>Style of the font represented as a decimal string in the range 0-2.</summary>
		DWRITE_FONT_PROPERTY_ID_STYLE,

		/// <summary/>
		DWRITE_FONT_PROPERTY_ID_TYPOGRAPHIC_FACE_NAME,

		/// <summary>Total number of properties.</summary>
		DWRITE_FONT_PROPERTY_ID_TOTAL,

		/// <summary/>
		DWRITE_FONT_PROPERTY_ID_TOTAL_RS3,

		/// <summary>
		/// <para>
		/// Family name preferred by the designer. This enables font designers to group more than four fonts in a single family without
		/// losing compatibility with
		/// </para>
		/// <para>GDI. This name is typically only present if it differs from the GDI-compatible family name.</para>
		/// </summary>
		DWRITE_FONT_PROPERTY_ID_PREFERRED_FAMILY_NAME,

		/// <summary>Family name for the weight-width-slope model.</summary>
		DWRITE_FONT_PROPERTY_ID_FAMILY_NAME,

		/// <summary>Face name of the font, for example Regular or Bold.</summary>
		DWRITE_FONT_PROPERTY_ID_FACE_NAME,
	}

	/// <summary>Defines constants that specify the mechanism by which a font came to be included in a font set.</summary>
	// https://learn.microsoft.com/en-us/windows/win32/api/dwrite_3/ne-dwrite_3-dwrite_font_source_type typedef enum DWRITE_FONT_SOURCE_TYPE
	// { DWRITE_FONT_SOURCE_TYPE_UNKNOWN, DWRITE_FONT_SOURCE_TYPE_PER_MACHINE, DWRITE_FONT_SOURCE_TYPE_PER_USER,
	// DWRITE_FONT_SOURCE_TYPE_APPX_PACKAGE, DWRITE_FONT_SOURCE_TYPE_REMOTE_FONT_PROVIDER } ;
	[PInvokeData("dwrite_3.h", MSDNShortId = "NE:dwrite_3.DWRITE_FONT_SOURCE_TYPE")]
	public enum DWRITE_FONT_SOURCE_TYPE
	{
		/// <summary>Specifies that the font source is unknown, or is not any of the other defined font source types.</summary>
		DWRITE_FONT_SOURCE_TYPE_UNKNOWN,

		/// <summary>Specifies that the font source is a font file that's installed for all users on the device.</summary>
		DWRITE_FONT_SOURCE_TYPE_PER_MACHINE,

		/// <summary>Specifies that the font source is a font file that's installed for the current user.</summary>
		DWRITE_FONT_SOURCE_TYPE_PER_USER,

		/// <summary>
		/// Specifies that the font source is an APPX package, which includes one or more font files. The font source name is the full name
		/// of the package.
		/// </summary>
		DWRITE_FONT_SOURCE_TYPE_APPX_PACKAGE,

		/// <summary>Specifies that the font source is a font provider for downloadable fonts.</summary>
		DWRITE_FONT_SOURCE_TYPE_REMOTE_FONT_PROVIDER,
	}

	/// <summary>Specifies the location of a resource.</summary>
	// https://learn.microsoft.com/en-us/windows/win32/api/dwrite_3/ne-dwrite_3-dwrite_locality typedef enum DWRITE_LOCALITY {
	// DWRITE_LOCALITY_REMOTE, DWRITE_LOCALITY_PARTIAL, DWRITE_LOCALITY_LOCAL } ;
	[PInvokeData("dwrite_3.h", MSDNShortId = "NE:dwrite_3.DWRITE_LOCALITY")]
	public enum DWRITE_LOCALITY
	{
		/// <summary>
		/// The resource is remote, and information about it is unknown, including the file size and date. If you attempt to create a font
		/// or file stream, the creation will fail until locality becomes at least partial.
		/// </summary>
		DWRITE_LOCALITY_REMOTE,

		/// <summary>
		/// The resource is partially local, which means you can query the size and date of the file stream. With this type, you also might
		/// be able to create a font face and retrieve the particular glyphs for metrics and drawing, but not all the glyphs will be present.
		/// </summary>
		DWRITE_LOCALITY_PARTIAL,

		/// <summary>
		/// The resource is completely local, and all font functions can be called without concern of missing data or errors related to
		/// network connectivity.
		/// </summary>
		DWRITE_LOCALITY_LOCAL,
	}

	/// <summary>
	/// Defines constants that specify (as combinable flags) attributes of a color glyph, or of specific color values in a color glyph.
	/// </summary>
	// https://learn.microsoft.com/en-us/windows/windows-app-sdk/api/win32/dwrite_3/ne-dwrite_3-dwrite_paint_attributes typedef enum
	// DWRITE_PAINT_ATTRIBUTES { DWRITE_PAINT_ATTRIBUTES_NONE = 0, DWRITE_PAINT_ATTRIBUTES_USES_PALETTE = 0x01,
	// DWRITE_PAINT_ATTRIBUTES_USES_TEXT_COLOR = 0x02 } ;
	[PInvokeData("dwrite_3.h", MSDNShortId = "NE:dwrite_3.DWRITE_PAINT_ATTRIBUTES")]
	[Flags]
	public enum DWRITE_PAINT_ATTRIBUTES
	{
		/// <summary>
		/// <para>Value:</para>
		/// <para>0</para>
		/// <para>Specifies no attribute.</para>
		/// </summary>
		DWRITE_PAINT_ATTRIBUTES_NONE = 0x0,

		/// <summary>
		/// <para>Value:</para>
		/// <para>0x01</para>
		/// <para>
		/// Specifies that the color value (or any color value in the glyph) comes from the font's color palette. This means that the
		/// appearance might depend on the current palette index, which might be important to clients that cache color glyphs.
		/// </para>
		/// </summary>
		DWRITE_PAINT_ATTRIBUTES_USES_PALETTE = 0x1,

		/// <summary>
		/// <para>Value:</para>
		/// <para>0x02</para>
		/// <para>
		/// Specifies that the color value (or any color value in the glyph) comes from the client-specified text color. This means the
		/// appearance might depend on the text color, which might be important to clients that cache color glyphs.
		/// </para>
		/// </summary>
		DWRITE_PAINT_ATTRIBUTES_USES_TEXT_COLOR = 0x2,
	}

	/// <summary>
	/// Defines constants that specify known feature levels for use with the <c>IDWritePaintReader</c> interface and related APIs. A feature
	/// level represents a level of functionality. For example, it determines what <c>DWRITE_PAINT_TYPE</c> values might be returned.
	/// </summary>
	/// <remarks>For info about which paint types are required for each feature level, see the <c>DWRITE_PAINT_TYPE</c> enumeration.</remarks>
	// https://learn.microsoft.com/en-us/windows/windows-app-sdk/api/win32/dwrite_3/ne-dwrite_3-dwrite_paint_feature_level typedef enum
	// DWRITE_PAINT_FEATURE_LEVEL { DWRITE_PAINT_FEATURE_LEVEL_NONE, DWRITE_PAINT_FEATURE_LEVEL_COLR_V0, DWRITE_PAINT_FEATURE_LEVEL_COLR_V1
	// } ;
	[PInvokeData("dwrite_3.h", MSDNShortId = "NE:dwrite_3.DWRITE_PAINT_FEATURE_LEVEL")]
	public enum DWRITE_PAINT_FEATURE_LEVEL
	{
		/// <summary>No paint API support.</summary>
		DWRITE_PAINT_FEATURE_LEVEL_NONE,

		/// <summary>Specifies a level of functionality corresponding to OpenType COLR version 0.</summary>
		DWRITE_PAINT_FEATURE_LEVEL_COLR_V0,

		/// <summary>Specifies a level of functionality corresponding to OpenType COLR version 1.</summary>
		DWRITE_PAINT_FEATURE_LEVEL_COLR_V1,
	}

	/// <summary>
	/// Defines constants that specify a type of paint element in a color glyph. A color glyph's visual representation is defined by a tree
	/// of paint elements. A paint element's properties are specified by a <c>DWRITE_PAINT_ELEMENT</c> structure, which combines a paint
	/// type an a union.
	/// </summary>
	/// <remarks>For more info about each paint type, see the <c>DWRITE_PAINT_ELEMENT</c> structure.</remarks>
	// https://learn.microsoft.com/en-us/windows/windows-app-sdk/api/win32/dwrite_3/ne-dwrite_3-dwrite_paint_type typedef enum
	// DWRITE_PAINT_TYPE { DWRITE_PAINT_TYPE_NONE, DWRITE_PAINT_TYPE_LAYERS, DWRITE_PAINT_TYPE_SOLID_GLYPH, DWRITE_PAINT_TYPE_SOLID,
	// DWRITE_PAINT_TYPE_LINEAR_GRADIENT, DWRITE_PAINT_TYPE_RADIAL_GRADIENT, DWRITE_PAINT_TYPE_SWEEP_GRADIENT, DWRITE_PAINT_TYPE_GLYPH,
	// DWRITE_PAINT_TYPE_COLOR_GLYPH, DWRITE_PAINT_TYPE_TRANSFORM, DWRITE_PAINT_TYPE_COMPOSITE } ;
	[PInvokeData("dwrite_3.h", MSDNShortId = "NE:dwrite_3.DWRITE_PAINT_TYPE")]
	public enum DWRITE_PAINT_TYPE
	{
		/// <summary>
		/// <para>Specifies no rendering action. Can be returned for color feature levels greater than or equal to</para>
		/// <para>DWRITE_PAINT_FEATURE_LEVEL_COLR_V0</para>
		/// <para>.</para>
		/// </summary>
		DWRITE_PAINT_TYPE_NONE,

		/// <summary>
		/// <para>
		/// Specifies a rendering action of rendering the child paint elements in bottom-up order. Can be returned for color feature levels
		/// greater than or equal to
		/// </para>
		/// <para>DWRITE_PAINT_FEATURE_LEVEL_COLR_V0</para>
		/// <para>.</para>
		/// </summary>
		DWRITE_PAINT_TYPE_LAYERS,

		/// <summary>
		/// <para>
		/// Specifies a rendering action of filling the specified glyph shape with the specified color. Can be returned for color feature
		/// levels greater than or equal to
		/// </para>
		/// <para>DWRITE_PAINT_FEATURE_LEVEL_COLR_V0</para>
		/// <para>.</para>
		/// </summary>
		DWRITE_PAINT_TYPE_SOLID_GLYPH,

		/// <summary>
		/// <para>
		/// Specifies a rendering action of filling the current clip with the specified color. Can be returned for color feature levels
		/// greater than or equal to
		/// </para>
		/// <para>DWRITE_PAINT_FEATURE_LEVEL_COLR_V1</para>
		/// <para>.</para>
		/// </summary>
		DWRITE_PAINT_TYPE_SOLID,

		/// <summary>
		/// <para>
		/// Specifies a rendering action of filling the current clip with the specified gradient. Can be returned for color feature levels
		/// greater than or equal to
		/// </para>
		/// <para>DWRITE_PAINT_FEATURE_LEVEL_COLR_V1</para>
		/// <para>.</para>
		/// </summary>
		DWRITE_PAINT_TYPE_LINEAR_GRADIENT,

		/// <summary>
		/// <para>
		/// Specifies a rendering action of filling the current clip with the specified gradient. Can be returned for color feature levels
		/// greater than or equal to
		/// </para>
		/// <para>DWRITE_PAINT_FEATURE_LEVEL_COLR_V1</para>
		/// <para>.</para>
		/// </summary>
		DWRITE_PAINT_TYPE_RADIAL_GRADIENT,

		/// <summary>
		/// <para>
		/// Specifies a rendering action of filling the current clip with the specified gradient. Can be returned for color feature levels
		/// greater than or equal to
		/// </para>
		/// <para>DWRITE_PAINT_FEATURE_LEVEL_COLR_V1</para>
		/// <para>.</para>
		/// </summary>
		DWRITE_PAINT_TYPE_SWEEP_GRADIENT,

		/// <summary>
		/// <para>
		/// Specifies a rendering action of filling the specified glyph shape with child paint element. Can be returned for color feature
		/// levels greater than or equal to
		/// </para>
		/// <para>DWRITE_PAINT_FEATURE_LEVEL_COLR_V1</para>
		/// <para>.</para>
		/// </summary>
		DWRITE_PAINT_TYPE_GLYPH,

		/// <summary>
		/// <para>
		/// Specifies a rendering action of rendering the child paint element. Can be returned for color feature levels greater than or
		/// equal to
		/// </para>
		/// <para>DWRITE_PAINT_FEATURE_LEVEL_COLR_V1</para>
		/// <para>.</para>
		/// </summary>
		DWRITE_PAINT_TYPE_COLOR_GLYPH,

		/// <summary>
		/// <para>
		/// Specifies a rendering action of rendering the child paint element with the specified transform. Can be returned for color
		/// feature levels greater than or equal to
		/// </para>
		/// <para>DWRITE_PAINT_FEATURE_LEVEL_COLR_V1</para>
		/// <para>.</para>
		/// </summary>
		DWRITE_PAINT_TYPE_TRANSFORM,

		/// <summary>
		/// <para>
		/// Specifies a rendering action of rendering the two child paint elements and compose them using the specified composite mode. Can
		/// be returned for color feature levels greater than or equal to
		/// </para>
		/// <para>DWRITE_PAINT_FEATURE_LEVEL_COLR_V1</para>
		/// <para>.</para>
		/// </summary>
		DWRITE_PAINT_TYPE_COMPOSITE,
	}

	/// <summary>Specifies how glyphs are rendered.</summary>
	// https://learn.microsoft.com/en-us/windows/win32/api/dwrite_3/ne-dwrite_3-dwrite_rendering_mode1 typedef enum DWRITE_RENDERING_MODE1 {
	// DWRITE_RENDERING_MODE1_DEFAULT, DWRITE_RENDERING_MODE1_ALIASED, DWRITE_RENDERING_MODE1_GDI_CLASSIC,
	// DWRITE_RENDERING_MODE1_GDI_NATURAL, DWRITE_RENDERING_MODE1_NATURAL, DWRITE_RENDERING_MODE1_NATURAL_SYMMETRIC,
	// DWRITE_RENDERING_MODE1_OUTLINE, DWRITE_RENDERING_MODE1_NATURAL_SYMMETRIC_DOWNSAMPLED } ;
	[PInvokeData("dwrite_3.h", MSDNShortId = "NE:dwrite_3.DWRITE_RENDERING_MODE1")]
	public enum DWRITE_RENDERING_MODE1
	{
		/// <summary>Specifies that the rendering mode is determined automatically, based on the font and size.</summary>
		DWRITE_RENDERING_MODE1_DEFAULT,

		/// <summary>
		/// Specifies that no anti-aliasing is performed. Each pixel is either set to the foreground color of the text or retains the color
		/// of the background.
		/// </summary>
		DWRITE_RENDERING_MODE1_ALIASED,

		/// <summary>
		/// <para>
		/// Specifies that antialiasing is performed in the horizontal direction and the appearance of glyphs is layout-compatible with GDI
		/// using CLEARTYPE_QUALITY.
		/// </para>
		/// <para>
		/// Use DWRITE_MEASURING_MODE_GDI_CLASSIC to get glyph advances. The antialiasing may be either ClearType or grayscale depending on
		/// the text antialiasing mode.
		/// </para>
		/// </summary>
		DWRITE_RENDERING_MODE1_GDI_CLASSIC,

		/// <summary>
		/// <para>
		/// Specifies that antialiasing is performed in the horizontal direction and the appearance of glyphs is layout-compatible with GDI
		/// using CLEARTYPE_NATURAL_QUALITY.
		/// </para>
		/// <para>
		/// Glyph advances are close to the font design advances, but are still rounded to whole pixels. Use
		/// DWRITE_MEASURING_MODE_GDI_NATURAL to get glyph advances.
		/// </para>
		/// <para>The antialiasing may be either ClearType or grayscale depending on the text antialiasing mode.</para>
		/// </summary>
		DWRITE_RENDERING_MODE1_GDI_NATURAL,

		/// <summary>
		/// <para>
		/// Specifies that antialiasing is performed in the horizontal direction. This rendering mode allows glyphs to be positioned with
		/// subpixel precision and
		/// </para>
		/// <para>is therefore suitable for natural (i.e., resolution-independent) layout.</para>
		/// <para>The antialiasing may be either ClearType or grayscale depending on the text antialiasing mode.</para>
		/// </summary>
		DWRITE_RENDERING_MODE1_NATURAL,

		/// <summary>
		/// <para>Similar to natural mode except that antialiasing is performed in both the horizontal and vertical directions.</para>
		/// <para>This is typically used at larger sizes to make curves and diagonal lines look smoother.</para>
		/// <para>The antialiasing may be either ClearType or grayscale depending on the text antialiasing mode.</para>
		/// </summary>
		DWRITE_RENDERING_MODE1_NATURAL_SYMMETRIC,

		/// <summary>
		/// Specifies that rendering should bypass the rasterizer and use the outlines directly. This is typically used at very large sizes.
		/// </summary>
		DWRITE_RENDERING_MODE1_OUTLINE,

		/// <summary>Similar to natural symmetric mode except that when possible, text should be rasterized in a downsampled form.</summary>
		DWRITE_RENDERING_MODE1_NATURAL_SYMMETRIC_DOWNSAMPLED,
	}

	/// <summary>Creates an OpenType tag for a font axis.</summary>
	/// <param name="a">
	/// <para>Type: <b><c>CHAR</c></b></para>
	/// <para>The first character in the tag.</para>
	/// </param>
	/// <param name="b">
	/// <para>Type: <b><c>CHAR</c></b></para>
	/// <para>The second character in the tag.</para>
	/// </param>
	/// <param name="c">
	/// <para>Type: <b><c>CHAR</c></b></para>
	/// <para>The third character in the tag.</para>
	/// </param>
	/// <param name="d">
	/// <para>Type: <b><c>CHAR</c></b></para>
	/// <para>The fourth character in the tag.</para>
	/// </param>
	/// <returns>None</returns>
	// https://learn.microsoft.com/en-us/windows/win32/api/dwrite_3/nf-dwrite_3-dwrite_make_font_axis_tag void DWRITE_MAKE_FONT_AXIS_TAG( a,
	// b, c, d );
	[PInvokeData("dwrite_3.h", MSDNShortId = "NF:dwrite_3.DWRITE_MAKE_FONT_AXIS_TAG")]
	public static DWRITE_FONT_AXIS_TAG DWRITE_MAKE_FONT_AXIS_TAG(char a, char b, char c, char d) => new() { tag = DWRITE_MAKE_OPENTYPE_TAG(a, b, c, d) };

	/// <summary>
	/// <para>Represents bitmap data in BGRA32 format.</para>
	/// <para>
	/// <para>Important</para>
	/// <para>
	/// This API is available as part of the DWriteCore implementation of <c>DirectWrite</c>. For more info, and code examples, see
	/// <c>DWriteCore overview</c>.
	/// </para>
	/// </para>
	/// </summary>
	// https://learn.microsoft.com/en-us/windows/windows-app-sdk/api/win32/dwrite_3/ns-dwrite_3-dwrite_bitmap_data_bgra32 struct
	// DWRITE_BITMAP_DATA_BGRA32 { UINT32 width; UINT32 height; UINT32 *pixels; };
	[PInvokeData("dwrite_3.h", MSDNShortId = "NS:dwrite_3.DWRITE_BITMAP_DATA_BGRA32")]
	[StructLayout(LayoutKind.Sequential)]
	public struct DWRITE_BITMAP_DATA_BGRA32
	{
		/// <summary>
		/// <para>Type: <b><c>UINT32</c></b></para>
		/// <para>The width, in pixels, of the bitmap.</para>
		/// </summary>
		public uint width;

		/// <summary>
		/// <para>Type: <b><c>UINT32</c></b></para>
		/// <para>The height, in pixels, of the bitmap.</para>
		/// </summary>
		public uint height;

		/// <summary>
		/// <para>Type: _Field_size_(width * height) <b><c>UINT32</c>*</b></para>
		/// <para>A pointer to the location of the bit values for the bitmap.</para>
		/// </summary>
		public ArrayPointer<uint> pixels;
	}

	/// <summary>
	/// Represents a color glyph run. The IDWriteFactory4::TranslateColorGlyphRun method returns an ordered collection of color glyph runs
	/// of varying types depending on what the font supports.
	/// </summary>
	// https://learn.microsoft.com/en-us/windows/win32/api/dwrite_3/ns-dwrite_3-dwrite_color_glyph_run1 struct DWRITE_COLOR_GLYPH_RUN1 :
	// DWRITE_COLOR_GLYPH_RUN { DWRITE_GLYPH_IMAGE_FORMATS glyphImageFormat; DWRITE_MEASURING_MODE measuringMode; };
	[PInvokeData("dwrite_3.h", MSDNShortId = "NS:dwrite_3.DWRITE_COLOR_GLYPH_RUN1")]
	[StructLayout(LayoutKind.Sequential)]
	public struct DWRITE_COLOR_GLYPH_RUN1
	{
		/// <summary>Glyph run to draw for this layer.</summary>
		public DWRITE_GLYPH_RUN glyphRun;

		/// <summary>
		/// Pointer to the glyph run description for this layer. This may be <b>NULL</b>. For example, when the original glyph run is split
		/// into multiple layers, one layer might have a description and the others have none.
		/// </summary>
		public StructPointer<DWRITE_GLYPH_RUN_DESCRIPTION> glyphRunDescription;

		/// <summary>X coordinate of the baseline origin for the layer.</summary>
		public float baselineOriginX;

		/// <summary>Y coordinate of the baseline origin for the layer.</summary>
		public float baselineOriginY;

		/// <summary>Color value of the run; if all members are zero, the run should be drawn using the current brush.</summary>
		public D3DCOLORVALUE runColor;

		/// <summary>
		/// Zero-based index into the font’s color palette; if this is <b>0xFFFF</b>, the run should be drawn using the current brush.
		/// </summary>
		public ushort paletteIndex;

		/// <summary>
		/// Type of glyph image format for this color run. Exactly one type will be set since TranslateColorGlyphRun has already broken down
		/// the run into separate parts.
		/// </summary>
		public DWRITE_GLYPH_IMAGE_FORMATS glyphImageFormat;

		/// <summary>Measuring mode to use for this glyph run.</summary>
		public DWRITE_MEASURING_MODE measuringMode;
	}

	/// <summary>Represents a range of bytes in a font file.</summary>
	/// <remarks>DWRITE_FILE_FRAGMENT is passed as input to <c>IDWriteRemoteFontFileStream::BeginDownload</c>.</remarks>
	// https://learn.microsoft.com/en-us/windows/win32/api/dwrite_3/ns-dwrite_3-dwrite_file_fragment struct DWRITE_FILE_FRAGMENT { UINT64
	// fileOffset; UINT64 fragmentSize; };
	[PInvokeData("dwrite_3.h", MSDNShortId = "NS:dwrite_3.DWRITE_FILE_FRAGMENT")]
	[StructLayout(LayoutKind.Sequential)]
	public struct DWRITE_FILE_FRAGMENT
	{
		/// <summary>Starting offset of the fragment from the beginning of the file.</summary>
		public ulong fileOffset;

		/// <summary>Size of the file fragment, in bytes.</summary>
		public ulong fragmentSize;
	}

	/// <summary>
	/// Represents the minimum and maximum range of the possible values for a font axis. If minValue equals maxValue, then the axis is
	/// static rather than variable.
	/// </summary>
	/// <remarks>
	/// <para>
	/// The meaning and range of axis values depends on the semantics of the particular axis. Certain well-known axes have standard ranges
	/// and defaults. Here are some examples.
	/// </para>
	/// <list type="bullet">
	/// <item>
	/// <description>Weight (1..1000, default == 400)</description>
	/// </item>
	/// <item>
	/// <description>Width (&gt;0, default == 100)</description>
	/// </item>
	/// <item>
	/// <description>Slant (-90..90, default == -20)</description>
	/// </item>
	/// <item>
	/// <description>Italic (0 or 1)</description>
	/// </item>
	/// </list>
	/// </remarks>
	// https://learn.microsoft.com/en-us/windows/win32/api/dwrite_3/ns-dwrite_3-dwrite_font_axis_range struct DWRITE_FONT_AXIS_RANGE {
	// DWRITE_FONT_AXIS_TAG axisTag; FLOAT minValue; FLOAT maxValue; };
	[PInvokeData("dwrite_3.h", MSDNShortId = "NS:dwrite_3.DWRITE_FONT_AXIS_RANGE")]
	[StructLayout(LayoutKind.Sequential)]
	public struct DWRITE_FONT_AXIS_RANGE
	{
		/// <summary>
		/// <para>Type: <b><c>DWRITE_FONT_AXIS_TAG</c></b></para>
		/// <para>The four-character identifier of the font axis (for example, weight, width, slant, italic, and so on).</para>
		/// </summary>
		public DWRITE_FONT_AXIS_TAG axisTag;

		/// <summary>
		/// <para>Type: <b><c>FLOAT</c></b></para>
		/// <para>The minimum value supported by this axis.</para>
		/// </summary>
		public float minValue;

		/// <summary>
		/// <para>Type: <b><c>FLOAT</c></b></para>
		/// <para>The maximum value supported by this axis.</para>
		/// </summary>
		public float maxValue;
	}

	/// <summary>Defines constants that specify a four-character identifier for a font axis.</summary>
	/// <remarks>
	/// <para>You can use the <b>DWRITE_MAKE_FONT_AXIS_TAG(a,b,c,d)</b> macro to create your own custom identifiers. Here's an example.</para>
	/// <para><c>DWRITE_MAKE_FONT_AXIS_TAG('c', 's', 't', 'm');</c></para>
	/// </remarks>
	// https://learn.microsoft.com/en-us/windows/win32/api/dwrite_3/ne-dwrite_3-dwrite_font_axis_tag typedef enum DWRITE_FONT_AXIS_TAG {
	// DWRITE_FONT_AXIS_TAG_WEIGHT, DWRITE_FONT_AXIS_TAG_WIDTH, DWRITE_FONT_AXIS_TAG_SLANT, DWRITE_FONT_AXIS_TAG_OPTICAL_SIZE,
	// DWRITE_FONT_AXIS_TAG_ITALIC } ;
	[PInvokeData("dwrite_3.h", MSDNShortId = "NE:dwrite_3.DWRITE_FONT_AXIS_TAG")]
	public struct DWRITE_FONT_AXIS_TAG
	{
		internal uint tag;

		/// <summary>Specifies the italic axis, using the identifier 'i','t','a','l'.</summary>
		public static DWRITE_FONT_AXIS_TAG DWRITE_FONT_AXIS_TAG_ITALIC => DWRITE_MAKE_FONT_AXIS_TAG('i', 't', 'a', 'l');

		/// <summary>Specifies the optical size axis, using the identifier 'o','p','s','z'.</summary>
		public static DWRITE_FONT_AXIS_TAG DWRITE_FONT_AXIS_TAG_OPTICAL_SIZE => DWRITE_MAKE_FONT_AXIS_TAG('o', 'p', 's', 'z');

		/// <summary>Specifies the slant axis, using the identifier 's','l','n','t'.</summary>
		public static DWRITE_FONT_AXIS_TAG DWRITE_FONT_AXIS_TAG_SLANT => DWRITE_MAKE_FONT_AXIS_TAG('s', 'l', 'n', 't');

		/// <summary>Specifies the weight axis, using the identifier 'w','g','h','t'.</summary>
		public static DWRITE_FONT_AXIS_TAG DWRITE_FONT_AXIS_TAG_WEIGHT => DWRITE_MAKE_FONT_AXIS_TAG('w', 'g', 'h', 't');

		/// <summary>Specifies the width axis, using the identifier 'w','d','t','h'.</summary>
		public static DWRITE_FONT_AXIS_TAG DWRITE_FONT_AXIS_TAG_WIDTH => DWRITE_MAKE_FONT_AXIS_TAG('w', 'd', 't', 'h');
	}

	/// <summary>Represents a value for a font axis. Used when querying and creating font instances (for example, see <c>IDWriteFontFace5::GetFontAxisValues</c>).</summary>
	// https://learn.microsoft.com/en-us/windows/win32/api/dwrite_3/ns-dwrite_3-dwrite_font_axis_value struct DWRITE_FONT_AXIS_VALUE {
	// DWRITE_FONT_AXIS_TAG axisTag; FLOAT value; };
	[PInvokeData("dwrite_3.h", MSDNShortId = "NS:dwrite_3.DWRITE_FONT_AXIS_VALUE")]
	[StructLayout(LayoutKind.Sequential)]
	public struct DWRITE_FONT_AXIS_VALUE
	{
		/// <summary>
		/// <para>Type: <b><c>DWRITE_FONT_AXIS_TAG</c></b></para>
		/// <para>The four-character identifier of the font axis (for example, weight, width, slant, italic, and so on).</para>
		/// </summary>
		public DWRITE_FONT_AXIS_TAG axisTag;

		/// <summary>
		/// <para>Type: <b><c>FLOAT</c></b></para>
		/// <para>
		/// A value for the axis specified in <c>axisTag</c>. The meaning and range of the value depends on the semantics of the particular
		/// axis. Certain well-known axes have standard ranges and defaults. Here are some examples.
		/// </para>
		/// <list type="bullet">
		/// <item>
		/// <description>Weight (1..1000, default == 400)</description>
		/// </item>
		/// <item>
		/// <description>Width (&gt;0, default == 100)</description>
		/// </item>
		/// <item>
		/// <description>Slant (-90..90, default == -20)</description>
		/// </item>
		/// <item>
		/// <description>Italic (0 or 1)</description>
		/// </item>
		/// </list>
		/// </summary>
		public float value;
	}

	/// <summary>Font property used for filtering font sets and building a font set with explicit properties.</summary>
	// https://learn.microsoft.com/en-us/windows/win32/api/dwrite_3/ns-dwrite_3-dwrite_font_property struct DWRITE_FONT_PROPERTY {
	// DWRITE_FONT_PROPERTY_ID propertyId; WCHAR const *propertyValue; WCHAR const *localeName; };
	[PInvokeData("dwrite_3.h", MSDNShortId = "NS:dwrite_3.DWRITE_FONT_PROPERTY")]
	[StructLayout(LayoutKind.Sequential)]
	public struct DWRITE_FONT_PROPERTY
	{
		/// <summary>Specifies the requested font property, such as DWRITE_FONT_PROPERTY_ID_FAMILY_NAME.</summary>
		public DWRITE_FONT_PROPERTY_ID propertyId;

		/// <summary>Specifies the value, such as "Segoe UI".</summary>
		[MarshalAs(UnmanagedType.LPWStr)]
		public string propertyValue;

		/// <summary>
		/// Specifies the locale to use, such as "en-US". Simply leave this empty when used with the font set filtering functions, as they
		/// will find a match regardless of language. For passing to AddFontFaceReference, the localeName specifies the language of the
		/// property value.
		/// </summary>
		[MarshalAs(UnmanagedType.LPWStr)]
		public string? localeName;
	}

	/// <summary>Data for a single glyph from GetGlyphImageData.</summary>
	// https://learn.microsoft.com/en-us/windows/win32/api/dwrite_3/ns-dwrite_3-dwrite_glyph_image_data struct DWRITE_GLYPH_IMAGE_DATA {
	// void const *imageData; UINT32 imageDataSize; UINT32 uniqueDataId; UINT32 pixelsPerEm; D2D1_SIZE_U pixelSize; D2D1_POINT_2L
	// horizontalLeftOrigin; D2D1_POINT_2L horizontalRightOrigin; D2D1_POINT_2L verticalTopOrigin; D2D1_POINT_2L verticalBottomOrigin; };
	[PInvokeData("dwrite_3.h", MSDNShortId = "NS:dwrite_3.DWRITE_GLYPH_IMAGE_DATA")]
	[StructLayout(LayoutKind.Sequential, CharSet = CharSet.Ansi)]
	public struct DWRITE_GLYPH_IMAGE_DATA
	{
		/// <summary>Pointer to the glyph data.</summary>
		public IntPtr imageData;

		/// <summary>Size of glyph data in bytes.</summary>
		public uint imageDataSize;

		/// <summary>
		/// Unique identifier for the glyph data. Clients may use this to cache a parsed/decompressed version and tell whether a repeated
		/// call to the same font returns the same data.
		/// </summary>
		public uint uniqueDataId;

		/// <summary>
		/// Pixels per em of the returned data. For non-scalable raster data (PNG/TIFF/JPG), this can be larger or smaller than requested
		/// from GetGlyphImageData when there isn't an exact match. For scaling intermediate sizes, use: desired pixels per em * font em
		/// size / actual pixels per em.
		/// </summary>
		public uint pixelsPerEm;

		/// <summary>Size of image when the format is pixel data.</summary>
		public D2D_SIZE_U pixelSize;

		/// <summary>Left origin along the horizontal Roman baseline.</summary>
		public POINT horizontalLeftOrigin;

		/// <summary>Right origin along the horizontal Roman baseline.</summary>
		public POINT horizontalRightOrigin;

		/// <summary>Top origin along the vertical central baseline.</summary>
		public POINT verticalTopOrigin;

		/// <summary>Bottom origin along vertical central baseline.</summary>
		public POINT verticalBottomOrigin;
	}

	/// <summary>Contains information about a formatted line of text.</summary>
	// https://learn.microsoft.com/en-us/windows/win32/api/dwrite_3/ns-dwrite_3-dwrite_line_metrics1 struct DWRITE_LINE_METRICS1 :
	// DWRITE_LINE_METRICS { FLOAT leadingBefore; FLOAT leadingAfter; };
	[PInvokeData("dwrite_3.h", MSDNShortId = "NS:dwrite_3.DWRITE_LINE_METRICS1")]
	[StructLayout(LayoutKind.Sequential)]
	public struct DWRITE_LINE_METRICS1
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

		/// <summary>
		/// <para>Type: <b>FLOAT</b></para>
		/// <para>
		/// White space before the content of the line. This is included in the line height and baseline distances. If the line is formatted
		/// horizontally either with a uniform line spacing or with proportional line spacing, this value represents the extra space above
		/// the content.
		/// </para>
		/// </summary>
		public float leadingBefore;

		/// <summary>
		/// <para>Type: <b>FLOAT</b></para>
		/// <para>
		/// White space after the content of the line. This is included in the height of the line. If the line is formatted horizontally
		/// either with a uniform line spacing or with proportional line spacing, this value represents the extra space below the content.
		/// </para>
		/// </summary>
		public float leadingAfter;
	}

	/// <summary>
	/// <para><c>method</c></para>
	/// <para><c>height</c></para>
	/// <para><c>baseline</c></para>
	/// <para><c>leadingBefore</c></para>
	/// <para><c>fontLineGapUsage</c></para>
	/// </summary>
	// https://learn.microsoft.com/en-us/windows/windows-app-sdk/api/win32/dwrite_3/ns-dwrite_3-dwrite_line_spacing struct
	// DWRITE_LINE_SPACING { DWRITE_LINE_SPACING_METHOD method; FLOAT height; FLOAT baseline; FLOAT leadingBefore;
	// DWRITE_FONT_LINE_GAP_USAGE fontLineGapUsage; };
	[PInvokeData("dwrite_3.h", MSDNShortId = "NS:dwrite_3.DWRITE_LINE_SPACING")]
	[StructLayout(LayoutKind.Sequential)]
	public struct DWRITE_LINE_SPACING
	{
		/// <summary/>
		public DWRITE_LINE_SPACING_METHOD method;

		/// <summary/>
		public float height;

		/// <summary/>
		public float baseline;

		/// <summary/>
		public float leadingBefore;

		/// <summary/>
		public DWRITE_FONT_LINE_GAP_USAGE fontLineGapUsage;
	}

	/// <summary>Represents a color in a color glyph.</summary>
	// https://learn.microsoft.com/en-us/windows/windows-app-sdk/api/win32/dwrite_3/ns-dwrite_3-dwrite_paint_color struct DWRITE_PAINT_COLOR
	// { DWRITE_COLOR_F value; UINT16 paletteEntryIndex; float alphaMultiplier; DWRITE_PAINT_ATTRIBUTES colorAttributes; };
	[PInvokeData("dwrite_3.h", MSDNShortId = "NS:dwrite_3.DWRITE_PAINT_COLOR")]
	[StructLayout(LayoutKind.Sequential)]
	public struct DWRITE_PAINT_COLOR
	{
		/// <summary>
		/// <para>Type: <b><c>DWRITE_COLOR_F</c></b></para>
		/// <para>Color value (not premultiplied). See the colorAttributes member for information about how the color is determined.</para>
		/// </summary>
		public DWRITE_COLOR_F value;

		/// <summary>
		/// <para>Type: <b><c>UINT16</c></b></para>
		/// <para>
		/// If the colorAttributes member is set to <b>DWRITE_PAINT_ATTRIBUTES_USES_PALETTE</b>, then this member is the index of a palette
		/// entry in the selected color palette. Otherwise, this member is <b>DWRITE_NO_PALETTE_INDEX</b> (0xFFFF).
		/// </para>
		/// </summary>
		public ushort paletteEntryIndex;

		/// <summary>
		/// <para>Type: <b>float</b></para>
		/// <para>
		/// Specifies an alpha value multiplier in the range 0 to 1 that was used to compute the color value. Color glyph descriptions can
		/// include alpha values to be multiplied with the alpha values of palette entries.
		/// </para>
		/// </summary>
		public float alphaMultiplier;

		/// <summary>
		/// <para>Type: <b><c>DWRITE_PAINT_ATTRIBUTES</c></b></para>
		/// <para>
		/// Specifies how the color value is determined. If this member is <b>DWRITE_PAINT_ATTRIBUTES_USES_PALETTE</b>, then the color value
		/// is determined by getting the color at paletteEntryIndex in the current color palette. The color's alpha value is then multiplied
		/// by alphaMultiplier. If a font has multiple color palettes, then you can set the current color palette using the
		/// <c>IDWritePaintReader::SetColorPaletteIndex</c> method. A client that uses a custom palette can use the paletteEntryIndex and
		/// alphaMultiplier methods to compute the color. If this member's value is <b>DWRITE_PAINT_ATTRIBUTES_USES_TEXT_COLOR</b>, then the
		/// color value is equal to the text foreground color, which can be set using the <c>IDWritePaintReader::SetTextColor</c> method.
		/// </para>
		/// </summary>
		public DWRITE_PAINT_ATTRIBUTES colorAttributes;
	}

	/// <summary>
	/// <para>
	/// Specifies properties of a paint element, which is one node in a visual tree associated with a color glyph. This is passed as an
	/// output parameter to various <c>IDWritePaintReader</c> methods.
	/// </para>
	/// <para>
	/// For a detailed description of how paint elements should be rendered, see the OpenType COLR table specification. Some of the
	/// descriptions in this topic reference the COLR paint record formats associated with each paint type.
	/// </para>
	/// </summary>
	// https://learn.microsoft.com/en-us/windows/windows-app-sdk/api/win32/dwrite_3/ns-dwrite_3-dwrite_paint_element struct
	// DWRITE_PAINT_ELEMENT { DWRITE_PAINT_TYPE paintType; union { struct { UINT32 childCount; } PAINT_LAYERS; PAINT_LAYERS layers; struct {
	// UINT32 glyphIndex; DWRITE_PAINT_COLOR color; } PAINT_SOLID_GLYPH; PAINT_SOLID_GLYPH solidGlyph; DWRITE_PAINT_COLOR solid; struct {
	// UINT32 extendMode; UINT32 gradientStopCount; float x0; float y0; float x1; float y1; float x2; float y2; } PAINT_LINEAR_GRADIENT;
	// PAINT_LINEAR_GRADIENT linearGradient; struct { UINT32 extendMode; UINT32 gradientStopCount; float x0; float y0; float radius0; float
	// x1; float y1; float radius1; } PAINT_RADIAL_GRADIENT; PAINT_RADIAL_GRADIENT radialGradient; struct { UINT32 extendMode; UINT32
	// gradientStopCount; float centerX; float centerY; float startAngle; float endAngle; } PAINT_SWEEP_GRADIENT; PAINT_SWEEP_GRADIENT
	// sweepGradient; struct { UINT32 glyphIndex; } PAINT_GLYPH; PAINT_GLYPH glyph; struct { UINT32 glyphIndex; D2D_RECT_F clipBox; }
	// PAINT_COLOR_GLYPH; PAINT_COLOR_GLYPH colorGlyph; DWRITE_MATRIX transform; struct { DWRITE_COLOR_COMPOSITE_MODE mode; }
	// PAINT_COMPOSITE; PAINT_COMPOSITE composite; } PAINT_UNION; PAINT_UNION paint; };
	[PInvokeData("dwrite_3.h", MSDNShortId = "NS:dwrite_3.DWRITE_PAINT_ELEMENT")]
	[StructLayout(LayoutKind.Sequential)]
	public struct DWRITE_PAINT_ELEMENT
	{
		/// <summary>
		/// <para>Type: <b><c>DWRITE_PAINT_TYPE</c></b></para>
		/// <para>Specifies the paint type, and thus which member of the union is valid.</para>
		/// </summary>
		public DWRITE_PAINT_TYPE paintType;

		/// <summary>Specifies type-specific properties of the paint element.</summary>
		public PAINT_UNION paint;

		/// <summary>Specifies type-specific properties of the paint element.</summary>
		[StructLayout(LayoutKind.Explicit)]
		public struct PAINT_UNION
		{
			/// <summary>
			/// <para>
			/// Valid for paint elements of type <c>DWRITE_PAINT_TYPE_LAYERS</c>. Contains one or more child paint elements to be drawn in
			/// bottom-up order.
			/// </para>
			/// <para>
			/// This corresponds to a PaintColrLayers record in the OpenType COLR table. Or it might correspond to a BaseGlyph record
			/// defined by COLR version 0.
			/// </para>
			/// </summary>
			[FieldOffset(0)]
			public PAINT_LAYERS layers;

			/// <summary>
			/// <para>Type: <b><c>PAINT_UNION.PAINT_SOLID_GLYPH</c></b></para>
			/// <para>See <c>PAINT_UNION.PAINT_SOLID_GLYPH</c>.</para>
			/// </summary>
			[FieldOffset(0)]
			public PAINT_SOLID_GLYPH solidGlyph;

			/// <summary>
			/// <para>Type: <b><c>DWRITE_PAINT_COLOR</c></b></para>
			/// <para>
			/// Valid for paint elements of type <c>DWRITE_PAINT_TYPE_SOLID</c>. Specifies a solid color used to fill the current shape or
			/// clip. This paint element has no child elements.
			/// </para>
			/// <para>This corresponds to a PaintSolid or PaintVarSolid record in the OpenType COLR table.</para>
			/// </summary>
			[FieldOffset(0)]
			public DWRITE_PAINT_COLOR solid;

			/// <summary>
			/// <para>
			/// Valid for paint elements of type <c>DWRITE_PAINT_TYPE_LINEAR_GRADIENT</c>. Specifies a linear gradient used to fill the
			/// current shape or clip. This paint element has no child elements.
			/// </para>
			/// <para>This corresponds to a PaintLinearGradient or PaintVarLinearGradient record in the OpenType COLR table.</para>
			/// </summary>
			[FieldOffset(0)]
			public PAINT_LINEAR_GRADIENT linearGradient;

			/// <summary>
			/// <para>
			/// Valid for paint elements of type <c>DWRITE_PAINT_TYPE_RADIAL_GRADIENT</c>. Specifies a radial gradient used to fill the
			/// current shape or clip. This paint element has no child elements.
			/// </para>
			/// <para>This corresponds to a PaintRadialGradient or PaintVarRadialGradient record in the OpenType COLR table.</para>
			/// </summary>
			[FieldOffset(0)]
			public PAINT_RADIAL_GRADIENT radialGradient;

			/// <summary>
			/// <para>
			/// Valid for paint elements of type <c>DWRITE_PAINT_TYPE_SWEEP_GRADIENT</c>. Specifies a sweep gradient used to fill the
			/// current shape or clip. This paint element has no child elements.
			/// </para>
			/// <para>This corresponds to a PaintSweepGradient or PaintVarSweepGradient record in the OpenType COLR table.</para>
			/// </summary>
			[FieldOffset(0)]
			public PAINT_SWEEP_GRADIENT sweepGradient;

			/// <summary>
			/// <para>
			/// Valid for paint elements of type <c>DWRITE_PAINT_TYPE_GLYPH</c>. Specifies a glyph shape to be filled or, equivalently, a
			/// clip region. This paint element has one child element.
			/// </para>
			/// <para>
			/// The child paint element defines how the glyph shape is filled. The child element can be a single paint element, such as a
			/// linear gradient. Or the child element can be the root of a visual tree to be rendered with the glyph shape as a clip region.
			/// This corresponds to a PaintGlyph record in the OpenType COLR table.
			/// </para>
			/// </summary>
			[FieldOffset(0)]
			public PAINT_GLYPH glyph;

			/// <summary>
			/// <para>
			/// Valid for paint elements of type <c>DWRITE_PAINT_TYPE_COLOR_GLYPH</c>. Specifies another color glyph, used as a reusable
			/// component. This paint element has one child element, which is the root paint element of the specified color glyph.
			/// </para>
			/// <para>This corresponds to a PaintColorGlyph record in the OpenType COLR table.</para>
			/// </summary>
			[FieldOffset(0)]
			public PAINT_COLOR_GLYPH colorGlyph;

			/// <summary>
			/// <para>Type: <b><c>DWRITE_MATRIX</c></b></para>
			/// <para>
			/// Valid for paint elements of type <c>DWRITE_PAINT_TYPE_TRANSFORM</c>. Specifies an affine transform to be applied to child
			/// content. This paint element has one child element, which is the transformed content.
			/// </para>
			/// <para>This corresponds to paint formats 12 through 31 in the OpenType COLR table.</para>
			/// </summary>
			[FieldOffset(0)]
			public DWRITE_MATRIX transform;

			/// <summary>
			/// <para>
			/// Valid for paint elements of type <c>DWRITE_PAINT_TYPE_COMPOSITE</c>. Combines the two child paint elements using the
			/// specified compositing or blending mode. This paint element has two child elements. The first child is the paint source. The
			/// second child is the paint destination (or backdrop).
			/// </para>
			/// <para>This corresponds to a PaintComposite record in the OpenType COLR table.</para>
			/// </summary>
			[FieldOffset(0)]
			public PAINT_COMPOSITE composite;

			/// <summary>
			/// <para>
			/// Valid for paint elements of type <c>DWRITE_PAINT_TYPE_LAYERS</c>. Contains one or more child paint elements to be drawn in
			/// bottom-up order.
			/// </para>
			/// <para>
			/// This corresponds to a PaintColrLayers record in the OpenType COLR table. Or it might correspond to a BaseGlyph record
			/// defined by COLR version 0.
			/// </para>
			/// </summary>
			[StructLayout(LayoutKind.Sequential)]
			public struct PAINT_LAYERS
			{
				/// <summary>
				/// <para>Type: <b><c>UINT32</c></b></para>
				/// <para>
				/// Number of child paint elements in bottom-up order. Use <c>IDWritePaintReader::MoveToFirstChild</c> and
				/// <c>MoveToNextSibling</c> to retrieve the child paint elements. Use the <c>MoveToParent</c> method to return to the
				/// parent element.
				/// </para>
				/// </summary>
				public uint childCount;
			}

			/// <summary>
			/// <para>
			/// Valid for paint elements of type <c>DWRITE_PAINT_TYPE_SOLID_GLYPH</c>. Specifies a glyph with a solid color fill. This paint
			/// element has no child elements.
			/// </para>
			/// <para>
			/// This corresponds to a combination of two paint records in the OpenType COLR table: a PaintGlyph record, which references
			/// either a PaintSolid or PaintVarSolid record. Or it might correspond to a Layer record defined by COLR version 0.
			/// </para>
			/// </summary>
			[StructLayout(LayoutKind.Sequential)]
			public struct PAINT_SOLID_GLYPH
			{
				/// <summary>
				/// <para>Type: <b><c>UINT32</c></b></para>
				/// <para>Glyph index defining the shape to be filled.</para>
				/// </summary>
				public uint glyphIndex;

				/// <summary>
				/// <para>Type: <b><c>DWRITE_PAINT_COLOR</c></b></para>
				/// <para>Glyph color used to fill the glyph shape.</para>
				/// </summary>
				public DWRITE_PAINT_COLOR color;
			}

			/// <summary>
			/// <para>
			/// Valid for paint elements of type <c>DWRITE_PAINT_TYPE_LINEAR_GRADIENT</c>. Specifies a linear gradient used to fill the
			/// current shape or clip. This paint element has no child elements.
			/// </para>
			/// <para>This corresponds to a PaintLinearGradient or PaintVarLinearGradient record in the OpenType COLR table.</para>
			/// </summary>
			[StructLayout(LayoutKind.Sequential)]
			public struct PAINT_LINEAR_GRADIENT
			{
				/// <summary>
				/// <para>Type: <b><c>UINT32</c></b></para>
				/// <para>A <c>D2D1_EXTEND_MODE</c> value specifying how colors outside the interval are defined.</para>
				/// </summary>
				public uint extendMode;

				/// <summary>
				/// <para>Type: <b><c>UINT32</c></b></para>
				/// <para>Number of gradient stops. Use the <c>IDWritePaintReader::GetGradientStops</c> method to get the gradient stops.</para>
				/// </summary>
				public uint gradientStopCount;

				/// <summary>
				/// <para>Type: <b>float</b></para>
				/// <para>X coordinate of the start point of the color line.</para>
				/// </summary>
				public float x0;

				/// <summary>
				/// <para>Type: <b>float</b></para>
				/// <para>Y coordinate of the start point of the color line.</para>
				/// </summary>
				public float y0;

				/// <summary>
				/// <para>Type: <b>float</b></para>
				/// <para>X coordinate of the end point of the color line.</para>
				/// </summary>
				public float x1;

				/// <summary>
				/// <para>Type: <b>float</b></para>
				/// <para>Y coordinate of the end point of the color line.</para>
				/// </summary>
				public float y1;

				/// <summary>
				/// <para>Type: <b>float</b></para>
				/// <para>X coordinate of the rotation point of the color line.</para>
				/// </summary>
				public float x2;

				/// <summary>
				/// <para>Type: <b>float</b></para>
				/// <para>Y coordinate of the rotation point of the color line.</para>
				/// </summary>
				public float y2;
			}

			/// <summary>
			/// <para>
			/// Valid for paint elements of type <c>DWRITE_PAINT_TYPE_RADIAL_GRADIENT</c>. Specifies a radial gradient used to fill the
			/// current shape or clip. This paint element has no child elements.
			/// </para>
			/// <para>This corresponds to a PaintRadialGradient or PaintVarRadialGradient record in the OpenType COLR table.</para>
			/// </summary>
			[StructLayout(LayoutKind.Sequential)]
			public struct PAINT_RADIAL_GRADIENT
			{
				/// <summary>
				/// <para>Type: <b><c>UINT32</c></b></para>
				/// <para>A <c>D2D1_EXTEND_MODE</c> value specifying how colors outside the interval are defined.</para>
				/// </summary>
				public uint extendMode;

				/// <summary>
				/// <para>Type: <b><c>UINT32</c></b></para>
				/// <para>Number of gradient stops. Use the <c>IDWritePaintReader::GetGradientStops</c> method to get the gradient stops.</para>
				/// </summary>
				public uint gradientStopCount;

				/// <summary>
				/// <para>Type: <b>float</b></para>
				/// <para>Center X coordinate of the start circle.</para>
				/// </summary>
				public float x0;

				/// <summary>
				/// <para>Type: <b>float</b></para>
				/// <para>Center Y coordinate of the start circle.</para>
				/// </summary>
				public float y0;

				/// <summary>
				/// <para>Type: <b>float</b></para>
				/// <para>Radius of the start circle.</para>
				/// </summary>
				public float radius0;

				/// <summary>
				/// <para>Type: <b>float</b></para>
				/// <para>Center X coordinate of the end circle.</para>
				/// </summary>
				public float x1;

				/// <summary>
				/// <para>Type: <b>float</b></para>
				/// <para>Center Y coordinate of the end circle.</para>
				/// </summary>
				public float y1;

				/// <summary>
				/// <para>Type: <b>float</b></para>
				/// <para>Radius of the end circle.</para>
				/// </summary>
				public float radius1;
			}

			/// <summary>
			/// <para>
			/// Valid for paint elements of type <c>DWRITE_PAINT_TYPE_SWEEP_GRADIENT</c>. Specifies a sweep gradient used to fill the
			/// current shape or clip. This paint element has no child elements.
			/// </para>
			/// <para>This corresponds to a PaintSweepGradient or PaintVarSweepGradient record in the OpenType COLR table.</para>
			/// </summary>
			[StructLayout(LayoutKind.Sequential)]
			public struct PAINT_SWEEP_GRADIENT
			{
				/// <summary>
				/// <para>Type: <b><c>UINT32</c></b></para>
				/// <para>A <c>D2D1_EXTEND_MODE</c> value specifying how colors outside the interval are defined.</para>
				/// </summary>
				public uint extendMode;

				/// <summary>
				/// <para>Type: <b><c>UINT32</c></b></para>
				/// <para>Number of gradient stops. Use the <c>IDWritePaintReader::GetGradientStops</c> method to get the gradient stops.</para>
				/// </summary>
				public uint gradientStopCount;

				/// <summary>
				/// <para>Type: <b>float</b></para>
				/// <para>Center X coordinate.</para>
				/// </summary>
				public float centerX;

				/// <summary>
				/// <para>Type: <b>float</b></para>
				/// <para>Center Y coordinate.</para>
				/// </summary>
				public float centerY;

				/// <summary>
				/// <para>Type: <b>float</b></para>
				/// <para>
				/// Start of the angular range of the gradient, measured in counter-clockwise degrees from the direction of the positive x axis.
				/// </para>
				/// </summary>
				public float startAngle;

				/// <summary>
				/// <para>Type: <b>float</b></para>
				/// <para>
				/// End of the angular range of the gradient, measured in counter-clockwise degrees from the direction of the positive x axis.
				/// </para>
				/// </summary>
				public float endAngle;
			}

			/// <summary>
			/// <para>
			/// Valid for paint elements of type <c>DWRITE_PAINT_TYPE_GLYPH</c>. Specifies a glyph shape to be filled or, equivalently, a
			/// clip region. This paint element has one child element.
			/// </para>
			/// <para>
			/// The child paint element defines how the glyph shape is filled. The child element can be a single paint element, such as a
			/// linear gradient. Or the child element can be the root of a visual tree to be rendered with the glyph shape as a clip region.
			/// This corresponds to a PaintGlyph record in the OpenType COLR table.
			/// </para>
			/// </summary>
			[StructLayout(LayoutKind.Sequential)]
			public struct PAINT_GLYPH
			{
				/// <summary>
				/// <para>Type: <b><c>UINT32</c></b></para>
				/// <para>Glyph index of the glyph that defines the shape to be filled.</para>
				/// </summary>
				public uint glyphIndex;
			}

			/// <summary>
			/// <para>
			/// Valid for paint elements of type <c>DWRITE_PAINT_TYPE_COLOR_GLYPH</c>. Specifies another color glyph, used as a reusable
			/// component. This paint element has one child element, which is the root paint element of the specified color glyph.
			/// </para>
			/// <para>This corresponds to a PaintColorGlyph record in the OpenType COLR table.</para>
			/// </summary>
			[StructLayout(LayoutKind.Sequential)]
			public struct PAINT_COLOR_GLYPH
			{
				/// <summary>
				/// <para>Type: <b><c>UINT32</c></b></para>
				/// <para>Glyph index of the referenced color glyph.</para>
				/// </summary>
				public uint glyphIndex;

				/// <summary>
				/// <para>Type: <b><c>D2D_RECT_F</c></b></para>
				/// <para>
				/// Clip box of the referenced color glyph, in ems. If the color glyph doesn't specify a clip box, then this is an empty
				/// rectangle. If it isn't an empty rectangle, then the client is required to clip the child content to this box.
				/// </para>
				/// </summary>
				public D2D_RECT_F clipBox;
			}

			/// <summary>
			/// <para>
			/// Valid for paint elements of type <c>DWRITE_PAINT_TYPE_COMPOSITE</c>. Combines the two child paint elements using the
			/// specified compositing or blending mode. This paint element has two child elements. The first child is the paint source. The
			/// second child is the paint destination (or backdrop).
			/// </para>
			/// <para>This corresponds to a PaintComposite record in the OpenType COLR table.</para>
			/// </summary>
			[StructLayout(LayoutKind.Sequential)]
			public struct PAINT_COMPOSITE
			{
				/// <summary>
				/// <para>Type: <b><c>DWRITE_COLOR_COMPOSITE_MODE</c></b></para>
				/// <para>Specifies the compositing or blending mode.</para>
				/// </summary>
				public DWRITE_COLOR_COMPOSITE_MODE mode;
			}
		}
	}

/*
IDWriteAsyncResult
IDWriteBitmapRenderTarget2
IDWriteBitmapRenderTarget3
IDWriteColorGlyphRunEnumerator1
IDWriteFactory3
IDWriteFactory4
IDWriteFactory5
IDWriteFactory6
IDWriteFactory7
IDWriteFactory8
IDWriteFont3
IDWriteFontCollection1
IDWriteFontCollection2
IDWriteFontCollection3
IDWriteFontDownloadListener
IDWriteFontDownloadQueue
IDWriteFontFace3
IDWriteFontFace4
IDWriteFontFace5
IDWriteFontFace6
IDWriteFontFace7
IDWriteFontFaceReference
IDWriteFontFaceReference1
IDWriteFontFallback1
IDWriteFontFamily1
IDWriteFontFamily2
IDWriteFontList1
IDWriteFontList2
IDWriteFontResource
IDWriteFontSet
IDWriteFontSet1
IDWriteFontSet2
IDWriteFontSet3
IDWriteFontSet4
IDWriteFontSetBuilder
IDWriteFontSetBuilder1
IDWriteFontSetBuilder2
IDWriteGdiInterop1
IDWriteInMemoryFontFileLoader
IDWritePaintReader
IDWriteRemoteFontFileLoader
IDWriteRemoteFontFileStream
IDWriteRenderingParams3
IDWriteStringList
IDWriteTextFormat2
IDWriteTextFormat3
IDWriteTextLayout3
IDWriteTextLayout4
*/
}