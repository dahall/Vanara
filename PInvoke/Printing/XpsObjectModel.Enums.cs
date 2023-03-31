namespace Vanara.PInvoke;

public static partial class XpsObjectModel
{
	/// <summary>Describes the gamma function used for color interpolation.</summary>
	// https://docs.microsoft.com/en-us/windows/win32/api/xpsobjectmodel/ne-xpsobjectmodel-xps_color_interpolation typedef enum
	// __MIDL___MIDL_itf_xpsobjectmodel_0000_0000_0002 { XPS_COLOR_INTERPOLATION_SCRGBLINEAR, XPS_COLOR_INTERPOLATION_SRGBLINEAR } XPS_COLOR_INTERPOLATION;
	[PInvokeData("xpsobjectmodel.h", MSDNShortId = "ad203082-d5a3-4414-88e1-8fd4dded6ea9")]
	public enum XPS_COLOR_INTERPOLATION
	{
		/// <summary>First, the color values are converted to scRGB, then a linear interpolation is performed between them.</summary>
		XPS_COLOR_INTERPOLATION_SCRGBLINEAR = 1,

		/// <summary>First, the color values are converted to sRGB, then a linear interpolation is performed between them.</summary>
		XPS_COLOR_INTERPOLATION_SRGBLINEAR = 2
	}

	/// <summary>Describes the color type used by the XPS_COLOR structure.</summary>
	// https://docs.microsoft.com/en-us/windows/win32/api/xpsobjectmodel/ne-xpsobjectmodel-xps_color_type typedef enum
	// __MIDL___MIDL_itf_xpsobjectmodel_0000_0000_0009 { XPS_COLOR_TYPE_SRGB, XPS_COLOR_TYPE_SCRGB, XPS_COLOR_TYPE_CONTEXT } XPS_COLOR_TYPE;
	[PInvokeData("xpsobjectmodel.h", MSDNShortId = "995576a6-ccca-4c0d-8346-2155801a2fbc")]
	public enum XPS_COLOR_TYPE
	{
		/// <summary>The color value is an sRGB value.</summary>
		XPS_COLOR_TYPE_SRGB = 1,

		/// <summary>The color value is an scRGB value.</summary>
		XPS_COLOR_TYPE_SCRGB,

		/// <summary>The color value is specified using context color syntax.</summary>
		XPS_COLOR_TYPE_CONTEXT
	}

	/// <summary>Specifies the style of a dash cap on a dashed stroke.</summary>
	// https://docs.microsoft.com/en-us/windows/win32/api/xpsobjectmodel/ne-xpsobjectmodel-xps_dash_cap typedef enum
	// __MIDL___MIDL_itf_xpsobjectmodel_0000_0000_0006 { XPS_DASH_CAP_FLAT, XPS_DASH_CAP_ROUND, XPS_DASH_CAP_SQUARE,
	// XPS_DASH_CAP_TRIANGLE } XPS_DASH_CAP;
	[PInvokeData("xpsobjectmodel.h", MSDNShortId = "8c4d7314-71ad-4700-bc3e-f611e72c05df")]
	public enum XPS_DASH_CAP
	{
		/// <summary>Flat-line cap.</summary>
		XPS_DASH_CAP_FLAT = 1,

		/// <summary>Round-line cap.</summary>
		XPS_DASH_CAP_ROUND = 2,

		/// <summary>Square-line cap.</summary>
		XPS_DASH_CAP_SQUARE = 3,

		/// <summary>Triangle-line cap.</summary>
		XPS_DASH_CAP_TRIANGLE = 4
	}

	/// <summary>Indicates the format into which the document was serialized.</summary>
	// https://docs.microsoft.com/en-us/windows/win32/api/xpsobjectmodel_1/ne-xpsobjectmodel_1-xps_document_type typedef enum
	// __MIDL___MIDL_itf_xpsobjectmodel_1_0000_0000_0001 { XPS_DOCUMENT_TYPE_UNSPECIFIED, XPS_DOCUMENT_TYPE_XPS,
	// XPS_DOCUMENT_TYPE_OPENXPS } XPS_DOCUMENT_TYPE;
	[PInvokeData("xpsobjectmodel_1.h", MSDNShortId = "C34629CB-7F8C-4126-BBE3-BF506D7586E9")]
	public enum XPS_DOCUMENT_TYPE
	{
		/// <summary>For documents which have yet to be serialized, and whose type is yet to be determined.</summary>
		XPS_DOCUMENT_TYPE_UNSPECIFIED = 1,

		/// <summary>MSXPS v1.0 document format.</summary>
		XPS_DOCUMENT_TYPE_XPS = 2,

		/// <summary>OpenXPS v1.0 document format.</summary>
		XPS_DOCUMENT_TYPE_OPENXPS = 3,
	}

	/// <summary>The rule used by a composite shape to determine whether a given point is part of the geometry.</summary>
	// https://docs.microsoft.com/en-us/windows/win32/api/xpsobjectmodel/ne-xpsobjectmodel-xps_fill_rule typedef enum
	// __MIDL___MIDL_itf_xpsobjectmodel_0000_0000_0010 { XPS_FILL_RULE_EVENODD, XPS_FILL_RULE_NONZERO } XPS_FILL_RULE;
	[PInvokeData("xpsobjectmodel.h", MSDNShortId = "353a4dc3-0c4d-46df-ae31-cc94c4116ca3")]
	public enum XPS_FILL_RULE
	{
		/// <summary>
		/// The rule that determines whether a point is in the fill region. This is determined by drawing a ray from the point to
		/// infinity in any direction, and counting the number of path segments within the shape that the ray crosses. If this number is
		/// odd, the point is inside; if even, the point is outside.
		/// </summary>
		XPS_FILL_RULE_EVENODD = 1,

		/// <summary>
		/// The rule that determines whether a point is in the fill region of the path. This is determined by drawing a ray from the
		/// point to infinity in any direction, and examining the places where a segment of the shape crosses the ray. Start the count
		/// at 0, then add 1 whenever a path segment crosses the ray from left to right; subtract 1 whenever a path segment crosses the
		/// ray from right to left. After the crossings are counted, the point is outside the path if the result is zero and inside if otherwise.
		/// </summary>
		XPS_FILL_RULE_NONZERO = 2
	}

	/// <summary>Describes the option for embedding a font.</summary>
	// https://docs.microsoft.com/en-us/windows/win32/api/xpsobjectmodel/ne-xpsobjectmodel-xps_font_embedding typedef enum
	// __MIDL___MIDL_itf_xpsobjectmodel_0000_0000_0013 { XPS_FONT_EMBEDDING_NORMAL, XPS_FONT_EMBEDDING_OBFUSCATED,
	// XPS_FONT_EMBEDDING_RESTRICTED, XPS_FONT_EMBEDDING_RESTRICTED_UNOBFUSCATED } XPS_FONT_EMBEDDING;
	[PInvokeData("xpsobjectmodel.h", MSDNShortId = "9701b1c2-a909-410e-b05b-76bbd5bc8b44")]
	public enum XPS_FONT_EMBEDDING
	{
		/// <summary>The embedded font is neither obfuscated nor restricted.</summary>
		XPS_FONT_EMBEDDING_NORMAL = 1,

		/// <summary>The embedded font is obfuscated but not restricted.</summary>
		XPS_FONT_EMBEDDING_OBFUSCATED = 2,

		/// <summary>The embedded font is obfuscated and restricted.</summary>
		XPS_FONT_EMBEDDING_RESTRICTED = 3,

		/// <summary>
		/// The font is restricted but not obfuscated.
		/// <para>
		/// This value cannot be set by an application. It is set when the document being deserialized contains a restricted font that
		/// is not obfuscated. Restricted fonts should be obfuscated, so this value usually indicates an error in the application that
		/// created the XPS document being deserialized.
		/// </para>
		/// </summary>
		XPS_FONT_EMBEDDING_RESTRICTED_UNOBFUSCATED = 4
	}

	/// <summary>Describes the image type.</summary>
	// https://docs.microsoft.com/en-us/windows/win32/api/xpsobjectmodel/ne-xpsobjectmodel-xps_image_type typedef enum
	// __MIDL___MIDL_itf_xpsobjectmodel_0000_0000_0008 { XPS_IMAGE_TYPE_JPEG, XPS_IMAGE_TYPE_PNG, XPS_IMAGE_TYPE_TIFF,
	// XPS_IMAGE_TYPE_WDP, XPS_IMAGE_TYPE_JXR } XPS_IMAGE_TYPE;
	[PInvokeData("xpsobjectmodel.h", MSDNShortId = "b4300a8c-f0bf-465f-a717-c54de95c1183")]
	public enum XPS_IMAGE_TYPE
	{
		/// <summary>A JPEG (Joint Photographic Experts Group) image.</summary>
		XPS_IMAGE_TYPE_JPEG = 1,

		/// <summary>A PNG (Portable Network Graphics) image.</summary>
		XPS_IMAGE_TYPE_PNG = 2,

		/// <summary>A TIFF (Tagged Image File Format) image.</summary>
		XPS_IMAGE_TYPE_TIFF = 3,

		/// <summary>An HD Photo (formerly Windows Media Photo) image.</summary>
		XPS_IMAGE_TYPE_WDP = 4,

		/// <summary>JPEG extended range (JPEG XR) image.</summary>
		XPS_IMAGE_TYPE_JXR = 5
	}

	/// <summary>Specifies whether the content of the XPS OM will be interleaved when it is written to a file or a stream.</summary>
	// https://docs.microsoft.com/en-us/windows/win32/api/xpsobjectmodel/ne-xpsobjectmodel-xps_interleaving typedef enum
	// __MIDL___MIDL_itf_xpsobjectmodel_0000_0000_0016 { XPS_INTERLEAVING_OFF, XPS_INTERLEAVING_ON } XPS_INTERLEAVING;
	[PInvokeData("xpsobjectmodel.h", MSDNShortId = "cfb2d1f3-2edb-4342-9fcc-c058afa3ef83")]
	public enum XPS_INTERLEAVING
	{
		/// <summary>The content of the XPS OM is not interleaved. The document parts are written as complete parts.</summary>
		XPS_INTERLEAVING_OFF = 1,

		/// <summary>
		/// The content of the XPS OM is interleaved. The document parts are divided into smaller pieces before they are written.
		/// </summary>
		XPS_INTERLEAVING_ON = 2
	}

	/// <summary>Specifies the shapes of line segment caps.</summary>
	/// <remarks>
	/// In the illustration that follows, the shaded area at the end of each line segment shows the cap that is added to the line
	/// segment depending on the value of <c>XPS_LINE_CAP</c>.
	/// </remarks>
	// https://docs.microsoft.com/en-us/windows/win32/api/xpsobjectmodel/ne-xpsobjectmodel-xps_line_cap typedef enum
	// __MIDL___MIDL_itf_xpsobjectmodel_0000_0000_0005 { XPS_LINE_CAP_FLAT, XPS_LINE_CAP_ROUND, XPS_LINE_CAP_SQUARE,
	// XPS_LINE_CAP_TRIANGLE } XPS_LINE_CAP;
	[PInvokeData("xpsobjectmodel.h", MSDNShortId = "63ee8c2d-e7c5-4453-9555-25896dc13870")]
	public enum XPS_LINE_CAP
	{
		/// <summary>Flat line cap.</summary>
		XPS_LINE_CAP_FLAT = 1,

		/// <summary>Round line cap.</summary>
		XPS_LINE_CAP_ROUND = 2,

		/// <summary>Square line cap.</summary>
		XPS_LINE_CAP_SQUARE = 3,

		/// <summary>Triangle line cap.</summary>
		XPS_LINE_CAP_TRIANGLE = 4
	}

	/// <summary>Describes the joint made by two intersecting line segments.</summary>
	/// <remarks>
	/// In the illustration that follows, the shaded area at the vertex of the line segments in each example shows how the joint fill is
	/// determined by the value of <c>XPS_LINE_JOIN</c>.
	/// </remarks>
	// https://docs.microsoft.com/en-us/windows/win32/api/xpsobjectmodel/ne-xpsobjectmodel-xps_line_join typedef enum
	// __MIDL___MIDL_itf_xpsobjectmodel_0000_0000_0007 { XPS_LINE_JOIN_MITER, XPS_LINE_JOIN_BEVEL, XPS_LINE_JOIN_ROUND } XPS_LINE_JOIN;
	[PInvokeData("xpsobjectmodel.h", MSDNShortId = "b0409564-a6b3-4e9d-b136-3d865dd46f1d")]
	public enum XPS_LINE_JOIN
	{
		/// <summary>Produces a sharp or clipped corner, depending on whether the length of the miter exceeds the miter limit.</summary>
		XPS_LINE_JOIN_MITER = 1,

		/// <summary>Produces a diagonal corner.</summary>
		XPS_LINE_JOIN_BEVEL = 2,

		/// <summary>Produces a smooth, circular arc between the lines.</summary>
		XPS_LINE_JOIN_ROUND = 3
	}

	/// <summary>Describes the type of an object that is derived from IXpsOMShareable.</summary>
	// https://docs.microsoft.com/en-us/windows/win32/api/xpsobjectmodel/ne-xpsobjectmodel-xps_object_type typedef enum
	// __MIDL___MIDL_itf_xpsobjectmodel_0000_0000_0014 { XPS_OBJECT_TYPE_CANVAS, XPS_OBJECT_TYPE_GLYPHS, XPS_OBJECT_TYPE_PATH,
	// XPS_OBJECT_TYPE_MATRIX_TRANSFORM, XPS_OBJECT_TYPE_GEOMETRY, XPS_OBJECT_TYPE_SOLID_COLOR_BRUSH, XPS_OBJECT_TYPE_IMAGE_BRUSH,
	// XPS_OBJECT_TYPE_LINEAR_GRADIENT_BRUSH, XPS_OBJECT_TYPE_RADIAL_GRADIENT_BRUSH, XPS_OBJECT_TYPE_VISUAL_BRUSH } XPS_OBJECT_TYPE;
	[PInvokeData("xpsobjectmodel.h", MSDNShortId = "2e53f22e-7521-45c9-ac88-b76fb381f556")]
	public enum XPS_OBJECT_TYPE
	{
		/// <summary>The object is an IXpsOMCanvas interface.</summary>
		XPS_OBJECT_TYPE_CANVAS = 1,

		/// <summary>The object is an IXpsOMGlyphs interface.</summary>
		XPS_OBJECT_TYPE_GLYPHS = 2,

		/// <summary>The object is an IXpsOMPath interface.</summary>
		XPS_OBJECT_TYPE_PATH = 3,

		/// <summary>The object is an IXpsOMMatrixTransform interface.</summary>
		XPS_OBJECT_TYPE_MATRIX_TRANSFORM = 4,

		/// <summary>The object is an IXpsOMGeometry interface.</summary>
		XPS_OBJECT_TYPE_GEOMETRY = 5,

		/// <summary>The object is an IXpsOMSolidColorBrush interface.</summary>
		XPS_OBJECT_TYPE_SOLID_COLOR_BRUSH = 6,

		/// <summary>The object is an IXpsOMImageBrush interface.</summary>
		XPS_OBJECT_TYPE_IMAGE_BRUSH = 7,

		/// <summary>The object is an IXpsOMLinearGradientBrush interface.</summary>
		XPS_OBJECT_TYPE_LINEAR_GRADIENT_BRUSH = 8,

		/// <summary>The object is an IXpsOMRadialGradientBrush interface.</summary>
		XPS_OBJECT_TYPE_RADIAL_GRADIENT_BRUSH = 9,

		/// <summary>The object is an IXpsOMVisualBrush interface.</summary>
		XPS_OBJECT_TYPE_VISUAL_BRUSH = 10
	}

	/// <summary>Indicates whether all, some, or none of the segments in a figure are stroked.</summary>
	// https://docs.microsoft.com/en-us/windows/win32/api/xpsobjectmodel/ne-xpsobjectmodel-xps_segment_stroke_pattern typedef enum
	// __MIDL___MIDL_itf_xpsobjectmodel_0000_0000_0012 { XPS_SEGMENT_STROKE_PATTERN_ALL, XPS_SEGMENT_STROKE_PATTERN_NONE,
	// XPS_SEGMENT_STROKE_PATTERN_MIXED } XPS_SEGMENT_STROKE_PATTERN;
	[PInvokeData("xpsobjectmodel.h", MSDNShortId = "e824884e-ffad-4c44-9df8-e9c21e1f3758")]
	public enum XPS_SEGMENT_STROKE_PATTERN
	{
		/// <summary>All segments in the figure are stroked.</summary>
		XPS_SEGMENT_STROKE_PATTERN_ALL = 1,

		/// <summary>No segments in the figure are stroked.</summary>
		XPS_SEGMENT_STROKE_PATTERN_NONE = 2,

		/// <summary>Some segments in the figure are stroked, others are not.</summary>
		XPS_SEGMENT_STROKE_PATTERN_MIXED = 3
	}

	/// <summary>Describes a line segment.</summary>
	/// <remarks>
	/// <para>
	/// A geometry segment is described by the start point, the segment type, and additional parameters whose values are determined by
	/// the segment type. The coordinates for the start point of the first segment are a property of the geometry figure. The start
	/// point of each subsequent segment is the end point of the preceding segment.
	/// </para>
	/// </remarks>
	// https://docs.microsoft.com/en-us/windows/win32/api/xpsobjectmodel/ne-xpsobjectmodel-xps_segment_type typedef enum
	// __MIDL___MIDL_itf_xpsobjectmodel_0000_0000_0011 { XPS_SEGMENT_TYPE_ARC_LARGE_CLOCKWISE,
	// XPS_SEGMENT_TYPE_ARC_LARGE_COUNTERCLOCKWISE, XPS_SEGMENT_TYPE_ARC_SMALL_CLOCKWISE, XPS_SEGMENT_TYPE_ARC_SMALL_COUNTERCLOCKWISE,
	// XPS_SEGMENT_TYPE_BEZIER, XPS_SEGMENT_TYPE_LINE, XPS_SEGMENT_TYPE_QUADRATIC_BEZIER } XPS_SEGMENT_TYPE;
	[PInvokeData("xpsobjectmodel.h", MSDNShortId = "dc36e80f-0c49-4317-a545-d50c9cbefd03")]
	public enum XPS_SEGMENT_TYPE
	{
		/// <summary>
		///The line segment is an arc that covers more than 180 degrees and is drawn in a clockwise direction from the start point to the end point.
		/// </summary>
		XPS_SEGMENT_TYPE_ARC_LARGE_CLOCKWISE = 1,

		/// <summary>
		/// The line segment is an arc that covers more than 180 degrees and is drawn in a counterclockwise direction from the start
		/// point to the end point.
		/// </summary>
		XPS_SEGMENT_TYPE_ARC_LARGE_COUNTERCLOCKWISE = 2,

		/// <summary>
		/// The line segment is an arc that covers at most 180 degrees and is drawn in a clockwise direction from the start point to the
		/// end point.
		/// </summary>
		XPS_SEGMENT_TYPE_ARC_SMALL_CLOCKWISE = 3,

		/// <summary>
		/// The line segment is an arc that covers at most 180 degrees and is drawn in a counterclockwise direction from the start point
		/// to the end point.
		/// </summary>
		XPS_SEGMENT_TYPE_ARC_SMALL_COUNTERCLOCKWISE = 4,

		/// <summary>The line segment is a cubic Bezier curve that is drawn between two points.</summary>
		XPS_SEGMENT_TYPE_BEZIER = 5,

		/// <summary>The line segment is a straight line that is drawn between two points.</summary>
		XPS_SEGMENT_TYPE_LINE = 6,

		/// <summary>The line segment is a quadratic Bezier curve that is drawn between two points.</summary>
		XPS_SEGMENT_TYPE_QUADRATIC_BEZIER = 7
	}

	/// <summary>
	/// Describes how the spread region is to be filled. The spread region is the area that falls within the drawing area but outside of
	/// the gradient region.
	/// </summary>
	// https://docs.microsoft.com/en-us/windows/win32/api/xpsobjectmodel/ne-xpsobjectmodel-xps_spread_method typedef enum
	// __MIDL___MIDL_itf_xpsobjectmodel_0000_0000_0003 { XPS_SPREAD_METHOD_PAD, XPS_SPREAD_METHOD_REFLECT, XPS_SPREAD_METHOD_REPEAT } XPS_SPREAD_METHOD;
	[PInvokeData("xpsobjectmodel.h", MSDNShortId = "9c9cadaf-6f38-4a56-942e-78617017a905")]
	public enum XPS_SPREAD_METHOD
	{
		/// <summary>The spread region is filled with the color whose value equals the color at the end of the gradient region.</summary>
		XPS_SPREAD_METHOD_PAD = 1,

		/// <summary>
		/// The spread region is filled by repeating the alternating reflection of the gradient that is inside the gradient region.
		/// </summary>
		XPS_SPREAD_METHOD_REFLECT = 2,

		/// <summary>
		/// The spread region is filled by repeating the gradient that is inside the gradient region, in the same orientation and direction.
		/// </summary>
		XPS_SPREAD_METHOD_REPEAT = 3
	}

	/// <summary>
	/// <para>Describes the simulation style of a font or glyph.</para>
	/// <para>
	/// To simulate the appearance of a style that is not provided by the font or glyph, style simulation modifies an existing font or a
	/// glyph image.
	/// </para>
	/// </summary>
	// https://docs.microsoft.com/en-us/windows/win32/api/xpsobjectmodel/ne-xpsobjectmodel-xps_style_simulation typedef enum
	// __MIDL___MIDL_itf_xpsobjectmodel_0000_0000_0004 { XPS_STYLE_SIMULATION_NONE, XPS_STYLE_SIMULATION_ITALIC,
	// XPS_STYLE_SIMULATION_BOLD, XPS_STYLE_SIMULATION_BOLDITALIC } XPS_STYLE_SIMULATION;
	[PInvokeData("xpsobjectmodel.h", MSDNShortId = "3f77c349-ba78-44e9-866a-9f654ed0e9dd")]
	public enum XPS_STYLE_SIMULATION
	{
		/// <summary>No font style simulation.</summary>
		XPS_STYLE_SIMULATION_NONE = 1,

		/// <summary>Italic style simulation.</summary>
		XPS_STYLE_SIMULATION_ITALIC = 2,

		/// <summary>Bold style simulation.</summary>
		XPS_STYLE_SIMULATION_BOLD = 3,

		/// <summary>Both bold and italic style simulation: first bold, then italic.</summary>
		XPS_STYLE_SIMULATION_BOLDITALIC = 4
	}

	/// <summary>Describes the size of a thumbnail image.</summary>
	// https://docs.microsoft.com/en-us/windows/win32/api/xpsobjectmodel/ne-xpsobjectmodel-xps_thumbnail_size typedef enum
	// __MIDL___MIDL_itf_xpsobjectmodel_0000_0000_0015 { XPS_THUMBNAIL_SIZE_VERYSMALL, XPS_THUMBNAIL_SIZE_SMALL,
	// XPS_THUMBNAIL_SIZE_MEDIUM, XPS_THUMBNAIL_SIZE_LARGE } XPS_THUMBNAIL_SIZE;
	[PInvokeData("xpsobjectmodel.h", MSDNShortId = "308083dd-74b4-4674-b5d7-e14e917fbc1f")]
	public enum XPS_THUMBNAIL_SIZE
	{
		/// <summary>The thumbnail image is 32 pixels wide and 32 pixels high.</summary>
		XPS_THUMBNAIL_SIZE_VERYSMALL = 1,

		/// <summary>The thumbnail image is 64 pixels wide and 64 pixels high.</summary>
		XPS_THUMBNAIL_SIZE_SMALL = 2,

		/// <summary>The thumbnail image is 100 pixels wide and 100 pixels high.</summary>
		XPS_THUMBNAIL_SIZE_MEDIUM = 3,

		/// <summary>The thumbnail image is 300 pixels wide and 300 pixels high.</summary>
		XPS_THUMBNAIL_SIZE_LARGE = 4
	}

	/// <summary>Describes the tiling behavior of a tile brush.</summary>
	// https://docs.microsoft.com/en-us/windows/win32/api/xpsobjectmodel/ne-xpsobjectmodel-xps_tile_mode typedef enum
	// __MIDL___MIDL_itf_xpsobjectmodel_0000_0000_0001 { XPS_TILE_MODE_NONE, XPS_TILE_MODE_TILE, XPS_TILE_MODE_FLIPX,
	// XPS_TILE_MODE_FLIPY, XPS_TILE_MODE_FLIPXY } XPS_TILE_MODE;
	[PInvokeData("xpsobjectmodel.h", MSDNShortId = "59434771-6402-4b0f-b8b6-58a4dda0f836")]
	public enum XPS_TILE_MODE
	{
		/// <summary>Only the base tile is drawn.</summary>
		XPS_TILE_MODE_NONE = 1,

		/// <summary>
		/// First, the base tile is drawn. Next, the remaining area is filled by repeating the base tile such that the right edge of one
		/// tile is adjacent to the left edge of the next, and similarly for bottom and top.
		/// </summary>
		XPS_TILE_MODE_TILE = 2,

		/// <summary>The same as XPS_TILE_MODE_TILE, but alternate columns of tiles are flipped horizontally.</summary>
		XPS_TILE_MODE_FLIPX = 3,

		/// <summary>The same as XPS_TILE_MODE_TILE, but alternate rows of tiles are flipped vertically.</summary>
		XPS_TILE_MODE_FLIPY = 4,

		/// <summary>The combination of the effects produced by XPS_TILE_MODE_FLIPX and XPS_TILE_MODE_FLIPY.</summary>
		XPS_TILE_MODE_FLIPXY = 5
	}
}