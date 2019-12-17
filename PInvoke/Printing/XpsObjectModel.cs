using System;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using System.Runtime.InteropServices.ComTypes;
using Vanara.InteropServices;
using static Vanara.PInvoke.Ole32;
using static Vanara.PInvoke.Opc;
using static Vanara.PInvoke.UrlMon;

namespace Vanara.PInvoke
{
	// https://docs.microsoft.com/en-us/windows/win32/printdocs/xps-programming-reference
	public static partial class XpsObjectModel
	{
		/// <summary>Describes the gamma function used for color interpolation.</summary>
		// https://docs.microsoft.com/en-us/windows/win32/api/xpsobjectmodel/ne-xpsobjectmodel-xps_color_interpolation
		// typedef enum __MIDL___MIDL_itf_xpsobjectmodel_0000_0000_0002 { XPS_COLOR_INTERPOLATION_SCRGBLINEAR, XPS_COLOR_INTERPOLATION_SRGBLINEAR } XPS_COLOR_INTERPOLATION;
		[PInvokeData("xpsobjectmodel.h", MSDNShortId = "ad203082-d5a3-4414-88e1-8fd4dded6ea9")]
		public enum XPS_COLOR_INTERPOLATION
		{
			/// <summary>
			/// First, the color values are converted to scRGB, then a linear interpolation is performed between them.
			/// </summary>
			XPS_COLOR_INTERPOLATION_SCRGBLINEAR = 1,
			/// <summary>
			/// First, the color values are converted to sRGB, then a linear interpolation is performed between them.
			/// </summary>
			XPS_COLOR_INTERPOLATION_SRGBLINEAR = 2
		}

		/// <summary>Describes the color type used by the XPS_COLOR structure.</summary>
		// https://docs.microsoft.com/en-us/windows/win32/api/xpsobjectmodel/ne-xpsobjectmodel-xps_color_type
		// typedef enum __MIDL___MIDL_itf_xpsobjectmodel_0000_0000_0009 { XPS_COLOR_TYPE_SRGB, XPS_COLOR_TYPE_SCRGB, XPS_COLOR_TYPE_CONTEXT } XPS_COLOR_TYPE;
		[PInvokeData("xpsobjectmodel.h", MSDNShortId = "995576a6-ccca-4c0d-8346-2155801a2fbc")]
		public enum XPS_COLOR_TYPE
		{
			/// <summary>
			/// The color value is an sRGB value.
			/// </summary>
			XPS_COLOR_TYPE_SRGB = 1,
			/// <summary>
			/// The color value is an scRGB value.
			/// </summary>
			XPS_COLOR_TYPE_SCRGB,
			/// <summary>
			/// The color value is specified using context color syntax.
			/// </summary>
			XPS_COLOR_TYPE_CONTEXT
		}

		/// <summary>Specifies the style of a dash cap on a dashed stroke.</summary>
		// https://docs.microsoft.com/en-us/windows/win32/api/xpsobjectmodel/ne-xpsobjectmodel-xps_dash_cap
		// typedef enum __MIDL___MIDL_itf_xpsobjectmodel_0000_0000_0006 { XPS_DASH_CAP_FLAT, XPS_DASH_CAP_ROUND, XPS_DASH_CAP_SQUARE, XPS_DASH_CAP_TRIANGLE } XPS_DASH_CAP;
		[PInvokeData("xpsobjectmodel.h", MSDNShortId = "8c4d7314-71ad-4700-bc3e-f611e72c05df")]
		public enum XPS_DASH_CAP
		{
			/// <summary>
			/// Flat-line cap.
			/// </summary>
			XPS_DASH_CAP_FLAT = 1,
			/// <summary>
			/// Round-line cap.
			/// </summary>
			XPS_DASH_CAP_ROUND = 2,
			/// <summary>
			/// Square-line cap.
			/// </summary>
			XPS_DASH_CAP_SQUARE = 3,
			/// <summary>
			/// Triangle-line cap.
			/// </summary>
			XPS_DASH_CAP_TRIANGLE = 4
		}

		/// <summary>Indicates the format into which the document was serialized.</summary>
		// https://docs.microsoft.com/en-us/windows/win32/api/xpsobjectmodel_1/ne-xpsobjectmodel_1-xps_document_type
		// typedef enum __MIDL___MIDL_itf_xpsobjectmodel_1_0000_0000_0001 { XPS_DOCUMENT_TYPE_UNSPECIFIED, XPS_DOCUMENT_TYPE_XPS, XPS_DOCUMENT_TYPE_OPENXPS } XPS_DOCUMENT_TYPE;
		[PInvokeData("xpsobjectmodel_1.h", MSDNShortId = "C34629CB-7F8C-4126-BBE3-BF506D7586E9")]
		public enum XPS_DOCUMENT_TYPE
		{
			/// <summary>
			/// For documents which have yet to be serialized, and whose type is yet to be determined.
			/// </summary>
			XPS_DOCUMENT_TYPE_UNSPECIFIED = 1,
			/// <summary>
			/// MSXPS v1.0 document format.
			/// </summary>
			XPS_DOCUMENT_TYPE_XPS = 2,
			/// <summary>
			/// OpenXPS v1.0 document format.
			/// </summary>
			XPS_DOCUMENT_TYPE_OPENXPS = 3,
		}

		/// <summary>The rule used by a composite shape to determine whether a given point is part of the geometry.</summary>
		// https://docs.microsoft.com/en-us/windows/win32/api/xpsobjectmodel/ne-xpsobjectmodel-xps_fill_rule
		// typedef enum __MIDL___MIDL_itf_xpsobjectmodel_0000_0000_0010 { XPS_FILL_RULE_EVENODD, XPS_FILL_RULE_NONZERO } XPS_FILL_RULE;
		[PInvokeData("xpsobjectmodel.h", MSDNShortId = "353a4dc3-0c4d-46df-ae31-cc94c4116ca3")]
		public enum XPS_FILL_RULE
		{
			/// <summary>
			/// The rule that determines whether a point is in the fill region. This is determined by drawing a ray from the point to infinity in any direction, and counting the number of path segments within the shape that the ray crosses. If this number is odd, the point is inside; if even, the point is outside.
			/// </summary>
			XPS_FILL_RULE_EVENODD = 1,
			/// <summary>
			/// The rule that determines whether a point is in the fill region of the path. This is determined by drawing a ray from the point to infinity in any direction, and examining the places where a segment of the shape crosses the ray. Start the count at 0, then add 1 whenever a path segment crosses the ray from left to right; subtract 1 whenever a path segment crosses the ray from right to left. After the crossings are counted, the point is outside the path if the result is zero and inside if otherwise.
			/// </summary>
			XPS_FILL_RULE_NONZERO = 2
		}

		/// <summary>Describes the option for embedding a font.</summary>
		// https://docs.microsoft.com/en-us/windows/win32/api/xpsobjectmodel/ne-xpsobjectmodel-xps_font_embedding
		// typedef enum __MIDL___MIDL_itf_xpsobjectmodel_0000_0000_0013 { XPS_FONT_EMBEDDING_NORMAL, XPS_FONT_EMBEDDING_OBFUSCATED, XPS_FONT_EMBEDDING_RESTRICTED, XPS_FONT_EMBEDDING_RESTRICTED_UNOBFUSCATED } XPS_FONT_EMBEDDING;
		[PInvokeData("xpsobjectmodel.h", MSDNShortId = "9701b1c2-a909-410e-b05b-76bbd5bc8b44")]
		public enum XPS_FONT_EMBEDDING
		{
			/// <summary>
			/// The embedded font is neither obfuscated nor restricted.
			/// </summary>
			XPS_FONT_EMBEDDING_NORMAL = 1,
			/// <summary>
			/// The embedded font is obfuscated but not restricted.
			/// </summary>
			XPS_FONT_EMBEDDING_OBFUSCATED = 2,
			/// <summary>
			/// The embedded font is obfuscated and restricted.
			/// </summary>
			XPS_FONT_EMBEDDING_RESTRICTED = 3,
			/// <summary>
			/// The font is restricted but not obfuscated.
			/// <para>This value cannot be set by an application. It is set when the document being deserialized contains a restricted font that is not obfuscated. Restricted fonts should be obfuscated, so this value usually indicates an error in the application that created the XPS document being deserialized.</para>
			/// </summary>
			XPS_FONT_EMBEDDING_RESTRICTED_UNOBFUSCATED = 4
		}

		/// <summary>Describes the image type.</summary>
		// https://docs.microsoft.com/en-us/windows/win32/api/xpsobjectmodel/ne-xpsobjectmodel-xps_image_type
		// typedef enum __MIDL___MIDL_itf_xpsobjectmodel_0000_0000_0008 { XPS_IMAGE_TYPE_JPEG, XPS_IMAGE_TYPE_PNG, XPS_IMAGE_TYPE_TIFF, XPS_IMAGE_TYPE_WDP, XPS_IMAGE_TYPE_JXR } XPS_IMAGE_TYPE;
		[PInvokeData("xpsobjectmodel.h", MSDNShortId = "b4300a8c-f0bf-465f-a717-c54de95c1183")]
		public enum XPS_IMAGE_TYPE
		{
			/// <summary>
			/// A JPEG (Joint Photographic Experts Group) image.
			/// </summary>
			XPS_IMAGE_TYPE_JPEG = 1,
			/// <summary>
			/// A PNG (Portable Network Graphics) image.
			/// </summary>
			XPS_IMAGE_TYPE_PNG = 2,
			/// <summary>
			/// A TIFF (Tagged Image File Format) image.
			/// </summary>
			XPS_IMAGE_TYPE_TIFF = 3,
			/// <summary>
			/// An HD Photo (formerly Windows Media Photo) image.
			/// </summary>
			XPS_IMAGE_TYPE_WDP = 4,
			/// <summary>
			/// JPEG extended range (JPEG XR) image.
			/// </summary>
			XPS_IMAGE_TYPE_JXR = 5
		}

		/// <summary>Specifies whether the content of the XPS OM will be interleaved when it is written to a file or a stream.</summary>
		// https://docs.microsoft.com/en-us/windows/win32/api/xpsobjectmodel/ne-xpsobjectmodel-xps_interleaving
		// typedef enum __MIDL___MIDL_itf_xpsobjectmodel_0000_0000_0016 { XPS_INTERLEAVING_OFF, XPS_INTERLEAVING_ON } XPS_INTERLEAVING;
		[PInvokeData("xpsobjectmodel.h", MSDNShortId = "cfb2d1f3-2edb-4342-9fcc-c058afa3ef83")]
		public enum XPS_INTERLEAVING
		{
			/// <summary>
			/// The content of the XPS OM is not interleaved. The document parts are written as complete parts.
			/// </summary>
			XPS_INTERLEAVING_OFF = 1,
			/// <summary>
			/// The content of the XPS OM is interleaved. The document parts are divided into smaller pieces before they are written.
			/// </summary>
			XPS_INTERLEAVING_ON = 2
		}

		/// <summary>Specifies the shapes of line segment caps.</summary>
		/// <remarks>In the illustration that follows, the shaded area at the end of each line segment shows the cap that is added to the line segment depending on the value of <c>XPS_LINE_CAP</c>.</remarks>
		// https://docs.microsoft.com/en-us/windows/win32/api/xpsobjectmodel/ne-xpsobjectmodel-xps_line_cap
		// typedef enum __MIDL___MIDL_itf_xpsobjectmodel_0000_0000_0005 { XPS_LINE_CAP_FLAT, XPS_LINE_CAP_ROUND, XPS_LINE_CAP_SQUARE, XPS_LINE_CAP_TRIANGLE } XPS_LINE_CAP;
		[PInvokeData("xpsobjectmodel.h", MSDNShortId = "63ee8c2d-e7c5-4453-9555-25896dc13870")]
		public enum XPS_LINE_CAP
		{
			/// <summary>
			/// Flat line cap.
			/// </summary>
			XPS_LINE_CAP_FLAT = 1,
			/// <summary>
			/// Round line cap.
			/// </summary>
			XPS_LINE_CAP_ROUND = 2,
			/// <summary>
			/// Square line cap.
			/// </summary>
			XPS_LINE_CAP_SQUARE = 3,
			/// <summary>
			/// Triangle line cap.
			/// </summary>
			XPS_LINE_CAP_TRIANGLE = 4
		}

		/// <summary>Describes the joint made by two intersecting line segments.</summary>
		/// <remarks>In the illustration that follows, the shaded area at the vertex of the line segments in each example shows how the joint fill is determined by the value of <c>XPS_LINE_JOIN</c>.</remarks>
		// https://docs.microsoft.com/en-us/windows/win32/api/xpsobjectmodel/ne-xpsobjectmodel-xps_line_join
		// typedef enum __MIDL___MIDL_itf_xpsobjectmodel_0000_0000_0007 { XPS_LINE_JOIN_MITER, XPS_LINE_JOIN_BEVEL, XPS_LINE_JOIN_ROUND } XPS_LINE_JOIN;
		[PInvokeData("xpsobjectmodel.h", MSDNShortId = "b0409564-a6b3-4e9d-b136-3d865dd46f1d")]
		public enum XPS_LINE_JOIN
		{
			/// <summary>
			/// Produces a sharp or clipped corner, depending on whether the length of the miter exceeds the miter limit.
			/// </summary>
			XPS_LINE_JOIN_MITER = 1,
			/// <summary>
			/// Produces a diagonal corner.
			/// </summary>
			XPS_LINE_JOIN_BEVEL = 2,
			/// <summary>
			/// Produces a smooth, circular arc between the lines.
			/// </summary>
			XPS_LINE_JOIN_ROUND = 3
		}

		/// <summary>Describes the type of an object that is derived from IXpsOMShareable.</summary>
		// https://docs.microsoft.com/en-us/windows/win32/api/xpsobjectmodel/ne-xpsobjectmodel-xps_object_type
		// typedef enum __MIDL___MIDL_itf_xpsobjectmodel_0000_0000_0014 { XPS_OBJECT_TYPE_CANVAS, XPS_OBJECT_TYPE_GLYPHS, XPS_OBJECT_TYPE_PATH, XPS_OBJECT_TYPE_MATRIX_TRANSFORM, XPS_OBJECT_TYPE_GEOMETRY, XPS_OBJECT_TYPE_SOLID_COLOR_BRUSH, XPS_OBJECT_TYPE_IMAGE_BRUSH, XPS_OBJECT_TYPE_LINEAR_GRADIENT_BRUSH, XPS_OBJECT_TYPE_RADIAL_GRADIENT_BRUSH, XPS_OBJECT_TYPE_VISUAL_BRUSH } XPS_OBJECT_TYPE;
		[PInvokeData("xpsobjectmodel.h", MSDNShortId = "2e53f22e-7521-45c9-ac88-b76fb381f556")]
		public enum XPS_OBJECT_TYPE
		{
			/// <summary>
			/// The object is an IXpsOMCanvas interface.
			/// </summary>
			XPS_OBJECT_TYPE_CANVAS = 1,
			/// <summary>
			/// The object is an IXpsOMGlyphs interface.
			/// </summary>
			XPS_OBJECT_TYPE_GLYPHS = 2,
			/// <summary>
			/// The object is an IXpsOMPath interface.
			/// </summary>
			XPS_OBJECT_TYPE_PATH = 3,
			/// <summary>
			/// The object is an IXpsOMMatrixTransform interface.
			/// </summary>
			XPS_OBJECT_TYPE_MATRIX_TRANSFORM = 4,
			/// <summary>
			/// The object is an IXpsOMGeometry interface.
			/// </summary>
			XPS_OBJECT_TYPE_GEOMETRY = 5,
			/// <summary>
			/// The object is an IXpsOMSolidColorBrush interface.
			/// </summary>
			XPS_OBJECT_TYPE_SOLID_COLOR_BRUSH = 6,
			/// <summary>
			/// The object is an IXpsOMImageBrush interface.
			/// </summary>
			XPS_OBJECT_TYPE_IMAGE_BRUSH = 7,
			/// <summary>
			/// The object is an IXpsOMLinearGradientBrush interface.
			/// </summary>
			XPS_OBJECT_TYPE_LINEAR_GRADIENT_BRUSH = 8,
			/// <summary>
			/// The object is an IXpsOMRadialGradientBrush interface.
			/// </summary>
			XPS_OBJECT_TYPE_RADIAL_GRADIENT_BRUSH = 9,
			/// <summary>
			/// The object is an IXpsOMVisualBrush interface.
			/// </summary>
			XPS_OBJECT_TYPE_VISUAL_BRUSH = 10
		}

		/// <summary>Indicates whether all, some, or none of the segments in a figure are stroked.</summary>
		// https://docs.microsoft.com/en-us/windows/win32/api/xpsobjectmodel/ne-xpsobjectmodel-xps_segment_stroke_pattern
		// typedef enum __MIDL___MIDL_itf_xpsobjectmodel_0000_0000_0012 { XPS_SEGMENT_STROKE_PATTERN_ALL, XPS_SEGMENT_STROKE_PATTERN_NONE, XPS_SEGMENT_STROKE_PATTERN_MIXED } XPS_SEGMENT_STROKE_PATTERN;
		[PInvokeData("xpsobjectmodel.h", MSDNShortId = "e824884e-ffad-4c44-9df8-e9c21e1f3758")]
		public enum XPS_SEGMENT_STROKE_PATTERN
		{
			/// <summary>
			/// All segments in the figure are stroked.
			/// </summary>
			XPS_SEGMENT_STROKE_PATTERN_ALL = 1,
			/// <summary>
			/// No segments in the figure are stroked.
			/// </summary>
			XPS_SEGMENT_STROKE_PATTERN_NONE = 2,
			/// <summary>
			/// Some segments in the figure are stroked, others are not.
			/// </summary>
			XPS_SEGMENT_STROKE_PATTERN_MIXED = 3
		}

		/// <summary>Describes a line segment.</summary>
		/// <remarks>
		/// <para>A geometry segment is described by the start point, the segment type, and additional parameters whose values are determined by the segment type. The coordinates for the start point of the first segment are a property of the geometry figure. The start point of each subsequent segment is the end point of the preceding segment.</para>
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows/win32/api/xpsobjectmodel/ne-xpsobjectmodel-xps_segment_type
		// typedef enum __MIDL___MIDL_itf_xpsobjectmodel_0000_0000_0011 { XPS_SEGMENT_TYPE_ARC_LARGE_CLOCKWISE, XPS_SEGMENT_TYPE_ARC_LARGE_COUNTERCLOCKWISE, XPS_SEGMENT_TYPE_ARC_SMALL_CLOCKWISE, XPS_SEGMENT_TYPE_ARC_SMALL_COUNTERCLOCKWISE, XPS_SEGMENT_TYPE_BEZIER, XPS_SEGMENT_TYPE_LINE, XPS_SEGMENT_TYPE_QUADRATIC_BEZIER } XPS_SEGMENT_TYPE;
		[PInvokeData("xpsobjectmodel.h", MSDNShortId = "dc36e80f-0c49-4317-a545-d50c9cbefd03")]
		public enum XPS_SEGMENT_TYPE
		{
			/// <summary>
			///The line segment is an arc that covers more than 180 degrees and is drawn in a clockwise direction from the start point to the end point.
			/// </summary>
			XPS_SEGMENT_TYPE_ARC_LARGE_CLOCKWISE = 1,
			/// <summary>
			/// The line segment is an arc that covers more than 180 degrees and is drawn in a counterclockwise direction from the start point to the end point.
			/// </summary>
			XPS_SEGMENT_TYPE_ARC_LARGE_COUNTERCLOCKWISE = 2,
			/// <summary>
			/// The line segment is an arc that covers at most 180 degrees and is drawn in a clockwise direction from the start point to the end point.
			/// </summary>
			XPS_SEGMENT_TYPE_ARC_SMALL_CLOCKWISE = 3,
			/// <summary>
			/// The line segment is an arc that covers at most 180 degrees and is drawn in a counterclockwise direction from the start point to the end point.
			/// </summary>
			XPS_SEGMENT_TYPE_ARC_SMALL_COUNTERCLOCKWISE = 4,
			/// <summary>
			/// The line segment is a cubic Bezier curve that is drawn between two points.
			/// </summary>
			XPS_SEGMENT_TYPE_BEZIER = 5,
			/// <summary>
			/// The line segment is a straight line that is drawn between two points.
			/// </summary>
			XPS_SEGMENT_TYPE_LINE = 6,
			/// <summary>
			/// The line segment is a quadratic Bezier curve that is drawn between two points.
			/// </summary>
			XPS_SEGMENT_TYPE_QUADRATIC_BEZIER = 7
		}

		/// <summary>Describes how the spread region is to be filled. The spread region is the area that falls within the drawing area but outside of the gradient region.</summary>
		// https://docs.microsoft.com/en-us/windows/win32/api/xpsobjectmodel/ne-xpsobjectmodel-xps_spread_method
		// typedef enum __MIDL___MIDL_itf_xpsobjectmodel_0000_0000_0003 { XPS_SPREAD_METHOD_PAD, XPS_SPREAD_METHOD_REFLECT, XPS_SPREAD_METHOD_REPEAT } XPS_SPREAD_METHOD;
		[PInvokeData("xpsobjectmodel.h", MSDNShortId = "9c9cadaf-6f38-4a56-942e-78617017a905")]
		public enum XPS_SPREAD_METHOD
		{
			/// <summary>
			/// The spread region is filled with the color whose value equals the color at the end of the gradient region.
			/// </summary>
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
		/// <para>To simulate the appearance of a style that is not provided by the font or glyph, style simulation modifies an existing font or a glyph image.</para>
		/// </summary>
		// https://docs.microsoft.com/en-us/windows/win32/api/xpsobjectmodel/ne-xpsobjectmodel-xps_style_simulation
		// typedef enum __MIDL___MIDL_itf_xpsobjectmodel_0000_0000_0004 { XPS_STYLE_SIMULATION_NONE, XPS_STYLE_SIMULATION_ITALIC, XPS_STYLE_SIMULATION_BOLD, XPS_STYLE_SIMULATION_BOLDITALIC } XPS_STYLE_SIMULATION;
		[PInvokeData("xpsobjectmodel.h", MSDNShortId = "3f77c349-ba78-44e9-866a-9f654ed0e9dd")]
		public enum XPS_STYLE_SIMULATION
		{
			/// <summary>
			/// No font style simulation.
			/// </summary>
			XPS_STYLE_SIMULATION_NONE = 1,
			/// <summary>
			/// Italic style simulation.
			/// </summary>
			XPS_STYLE_SIMULATION_ITALIC = 2,
			/// <summary>
			/// Bold style simulation.
			/// </summary>
			XPS_STYLE_SIMULATION_BOLD = 3,
			/// <summary>
			/// Both bold and italic style simulation: first bold, then italic.
			/// </summary>
			XPS_STYLE_SIMULATION_BOLDITALIC = 4
		}

		/// <summary>
		/// Describes the size of a thumbnail image.
		/// </summary>
		// https://docs.microsoft.com/en-us/windows/win32/api/xpsobjectmodel/ne-xpsobjectmodel-xps_thumbnail_size
		// typedef enum __MIDL___MIDL_itf_xpsobjectmodel_0000_0000_0015 { XPS_THUMBNAIL_SIZE_VERYSMALL, XPS_THUMBNAIL_SIZE_SMALL, XPS_THUMBNAIL_SIZE_MEDIUM, XPS_THUMBNAIL_SIZE_LARGE } XPS_THUMBNAIL_SIZE;
		[PInvokeData("xpsobjectmodel.h", MSDNShortId = "308083dd-74b4-4674-b5d7-e14e917fbc1f")]
		public enum XPS_THUMBNAIL_SIZE
		{
			/// <summary>
			/// The thumbnail image is 32 pixels wide and 32 pixels high.
			/// </summary>
			XPS_THUMBNAIL_SIZE_VERYSMALL = 1,
			/// <summary>
			/// The thumbnail image is 64 pixels wide and 64 pixels high.
			/// </summary>
			XPS_THUMBNAIL_SIZE_SMALL = 2,
			/// <summary>
			/// The thumbnail image is 100 pixels wide and 100 pixels high.
			/// </summary>
			XPS_THUMBNAIL_SIZE_MEDIUM = 3,
			/// <summary>
			/// The thumbnail image is 300 pixels wide and 300 pixels high.
			/// </summary>
			XPS_THUMBNAIL_SIZE_LARGE = 4
		}

		/// <summary>
		/// Describes the tiling behavior of a tile brush.
		/// </summary>
		// https://docs.microsoft.com/en-us/windows/win32/api/xpsobjectmodel/ne-xpsobjectmodel-xps_tile_mode
		// typedef enum __MIDL___MIDL_itf_xpsobjectmodel_0000_0000_0001 { XPS_TILE_MODE_NONE, XPS_TILE_MODE_TILE, XPS_TILE_MODE_FLIPX, XPS_TILE_MODE_FLIPY, XPS_TILE_MODE_FLIPXY } XPS_TILE_MODE;
		[PInvokeData("xpsobjectmodel.h", MSDNShortId = "59434771-6402-4b0f-b8b6-58a4dda0f836")]
		public enum XPS_TILE_MODE
		{
			/// <summary>
			/// Only the base tile is drawn.
			/// </summary>
			XPS_TILE_MODE_NONE = 1,
			/// <summary>
			/// First, the base tile is drawn. Next, the remaining area is filled by repeating the base tile such that the right edge of one tile is adjacent to the left edge of the next, and similarly for bottom and top.
			/// </summary>
			XPS_TILE_MODE_TILE = 2,
			/// <summary>
			/// The same as XPS_TILE_MODE_TILE, but alternate columns of tiles are flipped horizontally.
			/// </summary>
			XPS_TILE_MODE_FLIPX = 3,
			/// <summary>
			/// The same as XPS_TILE_MODE_TILE, but alternate rows of tiles are flipped vertically.
			/// </summary>
			XPS_TILE_MODE_FLIPY = 4,
			/// <summary>
			/// The combination of the effects produced by XPS_TILE_MODE_FLIPX and XPS_TILE_MODE_FLIPY.
			/// </summary>
			XPS_TILE_MODE_FLIPXY = 5
		}

		/// <summary>Defines objects that are used to paint graphical objects. Classes that derive from <c>IXpsOMBrush</c> describe how the area is painted.</summary>
		// https://docs.microsoft.com/en-us/windows/win32/api/xpsobjectmodel/nn-xpsobjectmodel-ixpsombrush
		[PInvokeData("xpsobjectmodel.h", MSDNShortId = "43cb56db-e09e-47cb-b50b-7827131659fd")]
		[ComImport, Guid("56A3F80C-EA4C-4187-A57B-A2A473B2B42B"), InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
		public interface IXpsOMBrush : IXpsOMShareable
		{
			/// <summary>Gets the opacity of the brush.</summary>
			/// <returns>
			/// The opacity value of the brush.
			/// </returns>
			/// <remarks>opacity is expressed as a value between 0.0 and 1.0; 0.0 indicates that the brush is completely transparent, 0.5 that it is 50 percent opaque, and 1.0 that it is completely opaque.</remarks>
			// https://docs.microsoft.com/en-us/windows/win32/api/xpsobjectmodel/nf-xpsobjectmodel-ixpsombrush-getopacity
			// HRESULT GetOpacity( FLOAT *opacity );
			float GetOpacity();

			/// <summary>Sets the opacity of the brush.</summary>
			/// <param name="opacity">The opacity value of the brush.</param>
			/// <remarks>
			/// <para>opacity is expressed as a value between 0.0 and 1.0; 0.0 indicates that the brush is completely transparent, 0.5 that it is 50 percent opaque, and 1.0 that it is completely opaque.</para>
			/// <para>If opacity is less than 0.0 or greater than 1.0, the method returns an error.</para>
			/// </remarks>
			// https://docs.microsoft.com/en-us/windows/win32/api/xpsobjectmodel/nf-xpsobjectmodel-ixpsombrush-setopacity
			// HRESULT SetOpacity( FLOAT opacity );
			void SetOpacity([In] float opacity);
		}

		/// <summary>A group of visual elements and related properties.</summary>
		/// <remarks>The code example that follows illustrates how to create an instance of this interface.</remarks>
		// https://docs.microsoft.com/en-us/windows/win32/api/xpsobjectmodel/nn-xpsobjectmodel-ixpsomcanvas
		[PInvokeData("xpsobjectmodel.h", MSDNShortId = "3cb0e1b3-88a8-4724-a3c5-0df416294e62")]
		[ComImport, Guid("221D1452-331E-47C6-87E9-6CCEFB9B5BA3"), InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
		public interface IXpsOMCanvas : IXpsOMVisual
		{
			/// <summary>Makes a deep copy of the interface.</summary>
			/// <returns>
			/// A pointer to the copy of the interface.
			/// </returns>
			/// <remarks>The owner of the new interface is <c>NULL</c>.</remarks>
			// https://docs.microsoft.com/en-us/windows/win32/api/xpsobjectmodel/nf-xpsobjectmodel-ixpsomcanvas-clone
			// HRESULT Clone( IXpsOMCanvas **canvas );
			IXpsOMCanvas Clone();

			/// <summary>Gets the long (detailed) textual description of the object's contents. This text is used by accessibility clients to describe the object.</summary>
			/// <returns>The long (detailed) textual description of the object's contents. A <c>NULL</c> pointer is returned if this text has not been set.</returns>
			/// <remarks>
			/// <para>The property returned by this method corresponds to the <c>AutomationProperties.HelpText</c> attribute of the <c>Canvas</c> element in the document markup.</para>
			/// </remarks>
			// https://docs.microsoft.com/en-us/windows/win32/api/xpsobjectmodel/nf-xpsobjectmodel-ixpsomcanvas-getaccessibilitylongdescription
			// HRESULT GetAccessibilityLongDescription( LPWSTR *longDescription );
			SafeCoTaskMemString GetAccessibilityLongDescription();

			/// <summary>Gets a short textual description of the object's contents. This text is used by accessibility clients to describe the object.</summary>
			/// <returns>The short textual description of the object's contents. If this description is not set, a <c>NULL</c> pointer is returned.</returns>
			/// <remarks>
			/// <para>The property returned by this method corresponds to the <c>AutomationProperties.Name</c> attribute of the <c>Canvas</c> element in the document markup.</para>
			/// </remarks>
			// https://docs.microsoft.com/en-us/windows/win32/api/xpsobjectmodel/nf-xpsobjectmodel-ixpsomcanvas-getaccessibilityshortdescription
			// HRESULT GetAccessibilityShortDescription( LPWSTR *shortDescription );
			SafeCoTaskMemString GetAccessibilityShortDescription();

			/// <summary>Gets a pointer to the resolved IXpsOMDictionary interface of the dictionary associated with the canvas.</summary>
			/// <returns>
			/// <para>A pointer to the resolved IXpsOMDictionary interface of the dictionary.</para>
			/// <para>The value that is returned in this parameter depends on which method has been most recently called to set the dictionary.</para>
			/// <list type="table">
			/// <listheader>
			/// <term>Most recent method called</term>
			/// <term>Object returned in resourceDictionary</term>
			/// </listheader>
			/// <item>
			/// <term>SetDictionaryLocal</term>
			/// <term>The local dictionary that is set by SetDictionaryLocal.</term>
			/// </item>
			/// <item>
			/// <term>SetDictionaryResource</term>
			/// <term>The shared dictionary in the dictionary resource that is set by SetDictionaryResource.</term>
			/// </item>
			/// <item>
			/// <term>Neither SetDictionaryLocal nor SetDictionaryResource has been called yet.</term>
			/// <term>NULL pointer.</term>
			/// </item>
			/// </list>
			/// </returns>
			/// <remarks>
			/// <para><c>GetDictionary</c> can return the interface pointer of a local or remote dictionary. GetOwner can be called to determine whether the dictionary is local or remote.</para>
			/// <para>After loading and parsing the resource into the XPS OM, this method might return an error that applies to another resource. This occurs because all of the relationships are parsed when a resource is loaded.</para>
			/// </remarks>
			// https://docs.microsoft.com/en-us/windows/win32/api/xpsobjectmodel/nf-xpsobjectmodel-ixpsomcanvas-getdictionary
			// HRESULT GetDictionary( IXpsOMDictionary **resourceDictionary );
			IXpsOMDictionary GetDictionary();

			/// <summary>Gets a pointer to the IXpsOMDictionary interface of the local, unshared dictionary.</summary>
			/// <returns>
			/// <para>The IXpsOMDictionary interface pointer to the local, unshared dictionary, if one has been set. If a local dictionary has not been set or if a remote dictionary resource has been set, a <c>NULL</c> pointer is returned.</para>
			/// <list type="table">
			/// <listheader>
			/// <term>Most recent method called</term>
			/// <term>Object returned in resourceDictionary</term>
			/// </listheader>
			/// <item>
			/// <term>SetDictionaryLocal</term>
			/// <term>The local dictionary that is set by SetDictionaryLocal.</term>
			/// </item>
			/// <item>
			/// <term>SetDictionaryResource</term>
			/// <term>NULL pointer.</term>
			/// </item>
			/// <item>
			/// <term>Neither SetDictionaryLocal nor SetDictionaryResource has been called yet.</term>
			/// <term>NULL pointer.</term>
			/// </item>
			/// </list>
			/// </returns>
			/// <remarks>
			/// <para>When this method loads and parses the resource into the XPS OM, it might return an error that applies to another resource. This can occur because all of the relationships are parsed when the resource is loaded.</para>
			/// <para>For more information about other return values that might be returned by this method, see XPS Document Errors.</para>
			/// </remarks>
			// https://docs.microsoft.com/en-us/windows/win32/api/xpsobjectmodel/nf-xpsobjectmodel-ixpsomcanvas-getdictionarylocal
			// HRESULT GetDictionaryLocal( IXpsOMDictionary **resourceDictionary );
			IXpsOMDictionary GetDictionaryLocal();

			/// <summary>Gets a pointer to the IXpsOMRemoteDictionaryResource interface of the remote dictionary resource.</summary>
			/// <returns>
			/// <para>The IXpsOMRemoteDictionaryResource interface pointer to the remote dictionary resource, if one has been set. If a remote dictionary resource has not been set or if a local dictionary resource has been set, a <c>NULL</c> pointer is returned.</para>
			/// <list type="table">
			/// <listheader>
			/// <term>Most recent method called</term>
			/// <term>Object returned in remoteDictionaryResource</term>
			/// </listheader>
			/// <item>
			/// <term>SetDictionaryLocal</term>
			/// <term>NULL pointer.</term>
			/// </item>
			/// <item>
			/// <term>SetDictionaryResource</term>
			/// <term>The remote dictionary resource that is set by SetDictionaryResource.</term>
			/// </item>
			/// <item>
			/// <term>Neither SetDictionaryLocal nor SetDictionaryResource has been called yet.</term>
			/// <term>NULL pointer.</term>
			/// </item>
			/// </list>
			/// </returns>
			/// <remarks>After loading and parsing the resource into the XPS OM, this method might return an error that applies to another resource. This occurs because all of the relationships are parsed when a resource is loaded.</remarks>
			// https://docs.microsoft.com/en-us/windows/win32/api/xpsobjectmodel/nf-xpsobjectmodel-ixpsomcanvas-getdictionaryresource
			// HRESULT GetDictionaryResource( IXpsOMRemoteDictionaryResource **remoteDictionaryResource );
			IXpsOMRemoteDictionaryResource GetDictionaryResource();

			/// <summary>Gets a Boolean value that determines whether the edges of the objects in the canvas are to be rendered using the aliased edge mode.</summary>
			/// <returns>
			/// <para>The Boolean value that determines whether the objects in the canvas are to be rendered using the aliased edge mode.</para>
			/// <list type="table">
			/// <listheader>
			/// <term>Value</term>
			/// <term>Meaning</term>
			/// </listheader>
			/// <item>
			/// <term>TRUE</term>
			/// <term>The edges of objects in the canvas are to be rendered without anti-aliasing using the aliased edge mode. This includes any objects in the canvas that have useAliasedEdgeMode set to FALSE. In the document markup, this corresponds to the RenderOptions.EdgeMode attribute having a value of Aliased.</term>
			/// </item>
			/// <item>
			/// <term>FALSE</term>
			/// <term>The edges of objects in the canvas are to be rendered in the default manner. In the document markup, this corresponds to the RenderOptions.EdgeMode attribute being absent.</term>
			/// </item>
			/// </list>
			/// </returns>
			/// <remarks>The property that is returned by this method corresponds to the <c>RenderOptions.EdgeMode</c> attribute of the <c>Canvas</c> element in the document markup.</remarks>
			// https://docs.microsoft.com/en-us/windows/win32/api/xpsobjectmodel/nf-xpsobjectmodel-ixpsomcanvas-getusealiasededgemode
			// HRESULT GetUseAliasedEdgeMode( BOOL *useAliasedEdgeMode );
			[return: MarshalAs(UnmanagedType.Bool)]
			bool GetUseAliasedEdgeMode();

			/// <summary>Gets a pointer to an IXpsOMVisualCollection interface that contains a collection of the visual objects in the canvas.</summary>
			/// <returns>The collection of the visual objects in the canvas. If no visual objects are attached to the canvas, an empty collection is returned.</returns>
			// https://docs.microsoft.com/en-us/windows/win32/api/xpsobjectmodel/nf-xpsobjectmodel-ixpsomcanvas-getvisuals
			// HRESULT GetVisuals( IXpsOMVisualCollection **visuals );
			IXpsOMVisualCollection GetVisuals();

			/// <summary>Sets the long (detailed) textual description of the object's contents. This text is used by accessibility clients to describe the object.</summary>
			/// <param name="longDescription">The long (detailed) textual description of the object's contents. A <c>NULL</c> pointer clears the previously assigned value.</param>
			/// <remarks>The property that is set by this method corresponds to the <c>AutomationProperties.HelpText</c> attribute of the <c>Canvas</c> element in the document markup.</remarks>
			// https://docs.microsoft.com/en-us/windows/win32/api/xpsobjectmodel/nf-xpsobjectmodel-ixpsomcanvas-setaccessibilitylongdescription
			// HRESULT SetAccessibilityLongDescription( LPCWSTR longDescription );
			void SetAccessibilityLongDescription([In, MarshalAs(UnmanagedType.LPWStr)] string longDescription);

			/// <summary>Sets the short textual description of the object's contents. This text is used by accessibility clients to describe the object.</summary>
			/// <param name="shortDescription">The short textual description of the object's contents. A <c>NULL</c> pointer clears the previously assigned text.</param>
			/// <remarks>The property that is set by this method corresponds to the <c>AutomationProperties.HelpText</c> attribute of the <c>Canvas</c> element in the document markup.</remarks>
			// https://docs.microsoft.com/en-us/windows/win32/api/xpsobjectmodel/nf-xpsobjectmodel-ixpsomcanvas-setaccessibilityshortdescription
			// HRESULT SetAccessibilityShortDescription( LPCWSTR shortDescription );
			void SetAccessibilityShortDescription([In, MarshalAs(UnmanagedType.LPWStr)] string shortDescription);

			/// <summary>
			/// Sets the IXpsOMDictionary interface pointer of the local, unshared dictionary.
			/// </summary>
			/// <param name="resourceDictionary">The IXpsOMDictionary interface of the local, unshared dictionary. A <c>NULL</c> pointer releases any previously assigned local dictionary.</param>
			/// <remarks>
			/// <para>After you call <c>SetDictionaryLocal</c>, the remote dictionary resource is released and GetDictionaryResource returns a <c>NULL</c> pointer in the remoteDictionaryResource parameter. The table that follows explains the relationship between the local and remote values of this property.</para>
			/// <list type="table">
			///   <listheader>
			///     <term>Most recent method called</term>
			///     <term>Object that is returned in resourceDictionary by GetDictionary</term>
			///     <term>Object that is returned in resourceDictionary by GetDictionaryLocal</term>
			///     <term>Object that is returned in remoteDictionaryResource by GetDictionaryResource</term>
			///   </listheader>
			///   <item>
			///     <term>SetDictionaryLocal (this method)</term>
			///     <term>The local dictionary that is set by SetDictionaryLocal.</term>
			///     <term>The local dictionary that is set by SetDictionaryLocal.</term>
			///     <term>NULL pointer.</term>
			///   </item>
			///   <item>
			///     <term>SetDictionaryResource</term>
			///     <term>The shared dictionary in the dictionary resource that is set by SetDictionaryResource.</term>
			///     <term>NULL pointer.</term>
			///     <term>The remote dictionary resource that is set by SetDictionaryResource.</term>
			///   </item>
			///   <item>
			///     <term>Neither SetDictionaryLocal nor SetDictionaryResource has been called yet.</term>
			///     <term>NULL pointer.</term>
			///     <term>NULL pointer.</term>
			///     <term>NULL pointer.</term>
			///   </item>
			/// </list>
			/// </remarks>
			// https://docs.microsoft.com/en-us/windows/win32/api/xpsobjectmodel/nf-xpsobjectmodel-ixpsomcanvas-setdictionarylocal
			// HRESULT SetDictionaryLocal( IXpsOMDictionary *resourceDictionary );
			void SetDictionaryLocal([In] IXpsOMDictionary resourceDictionary);

			/// <summary>
			/// Sets the IXpsOMRemoteDictionaryResource interface pointer of the remote dictionary resource.
			/// </summary>
			/// <param name="remoteDictionaryResource">The IXpsOMRemoteDictionaryResource interface of the remote dictionary resource. A <c>NULL</c> pointer releases any previously assigned dictionary resource.</param>
			/// <remarks>
			/// <para>After calling this method, GetDictionaryLocal returns a <c>NULL</c> pointer in the resourceDictionary parameter.</para>
			/// <list type="table">
			///   <listheader>
			///     <term>Most recent method called</term>
			///     <term>Object that is returned in resourceDictionary by GetDictionary</term>
			///     <term>Object that is returned in resourceDictionary by GetDictionaryLocal</term>
			///     <term>Object that is returned in remoteDictionaryResource by GetDictionaryResource</term>
			///   </listheader>
			///   <item>
			///     <term>SetDictionaryLocal</term>
			///     <term>The local dictionary that is set by SetDictionaryLocal.</term>
			///     <term>The local dictionary that is set by SetDictionaryLocal.</term>
			///     <term>NULL pointer.</term>
			///   </item>
			///   <item>
			///     <term>SetDictionaryResource (this method)</term>
			///     <term>The shared dictionary in the dictionary resource that is set by SetDictionaryResource.</term>
			///     <term>NULL pointer.</term>
			///     <term>The remote dictionary resource that is set by SetDictionaryResource.</term>
			///   </item>
			///   <item>
			///     <term>Neither SetDictionaryLocal nor SetDictionaryResource has been called yet.</term>
			///     <term>NULL pointer.</term>
			///     <term>NULL pointer.</term>
			///     <term>NULL pointer.</term>
			///   </item>
			/// </list>
			/// </remarks>
			// https://docs.microsoft.com/en-us/windows/win32/api/xpsobjectmodel/nf-xpsobjectmodel-ixpsomcanvas-setdictionaryresource
			// HRESULT SetDictionaryResource( IXpsOMRemoteDictionaryResource *remoteDictionaryResource );
			void SetDictionaryResource([In] IXpsOMRemoteDictionaryResource remoteDictionaryResource);

			/// <summary>
			/// Sets the value that determines whether the edges of objects in this canvas will be rendered using the aliased edge mode.
			/// </summary>
			/// <param name="useAliasedEdgeMode"><para>The Boolean value that determines whether the edges of child objects in this canvas will be rendered using the aliased edge mode.</para>
			/// <list type="table">
			///   <listheader>
			///     <term>Value</term>
			///     <term>Meaning</term>
			///   </listheader>
			///   <item>
			///     <term>TRUE</term>
			///     <term>The edges of objects in the canvas are to be rendered without anti-aliasing using the aliased edge mode. This includes any objects that have this value set to FALSE. In the document markup, this corresponds to the RenderOptions.EdgeMode attribute having the value of Aliased.</term>
			///   </item>
			///   <item>
			///     <term>FALSE</term>
			///     <term>The edges of objects in the canvas are to be rendered in the default manner. In the document markup, this corresponds to the RenderOptions.EdgeMode attribute being absent.</term>
			///   </item>
			/// </list></param>
			/// <remarks>
			/// This property corresponds to the <c>RenderOptions.EdgeMode</c> attribute of the <c>Canvas</c> element in the document markup.
			/// </remarks>
			// https://docs.microsoft.com/en-us/windows/win32/api/xpsobjectmodel/nf-xpsobjectmodel-ixpsomcanvas-setusealiasededgemode
			// HRESULT SetUseAliasedEdgeMode( BOOL useAliasedEdgeMode );
			void SetUseAliasedEdgeMode([MarshalAs(UnmanagedType.Bool)] bool useAliasedEdgeMode);
		}

		[ComImport, Guid("67BD7D69-1EEF-4BB1-B5E7-6F4F87BE8ABE"), InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
		public interface IXpsOMColorProfileResource : IXpsOMResource
		{
			[MethodImpl(MethodImplOptions.InternalCall)]
			[return: MarshalAs(UnmanagedType.Interface)]
			new IOpcPartUri GetPartName();

			[MethodImpl(MethodImplOptions.InternalCall)]
			new void SetPartName([MarshalAs(UnmanagedType.Interface)] [In] IOpcPartUri partUri);

			[MethodImpl(MethodImplOptions.InternalCall)]
			[return: MarshalAs(UnmanagedType.Interface)]
			IStream GetStream();

			[MethodImpl(MethodImplOptions.InternalCall)]
			void SetContent([MarshalAs(UnmanagedType.Interface)] [In] IStream sourceStream, [MarshalAs(UnmanagedType.Interface)] [In] IOpcPartUri partName);
		}

		[ComImport, Guid("12759630-5FBA-4283-8F7D-CCA849809EDB"), InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
		public interface IXpsOMColorProfileResourceCollection
		{
			[MethodImpl(MethodImplOptions.InternalCall)]
			uint GetCount();

			[MethodImpl(MethodImplOptions.InternalCall)]
			[return: MarshalAs(UnmanagedType.Interface)]
			IXpsOMColorProfileResource GetAt([In] uint index);

			[MethodImpl(MethodImplOptions.InternalCall)]
			void InsertAt([In] uint index, [MarshalAs(UnmanagedType.Interface)] [In] IXpsOMColorProfileResource @object);

			[MethodImpl(MethodImplOptions.InternalCall)]
			void RemoveAt([In] uint index);

			[MethodImpl(MethodImplOptions.InternalCall)]
			void SetAt([In] uint index, [MarshalAs(UnmanagedType.Interface)] [In] IXpsOMColorProfileResource @object);

			[MethodImpl(MethodImplOptions.InternalCall)]
			void Append([MarshalAs(UnmanagedType.Interface)] [In] IXpsOMColorProfileResource @object);

			[MethodImpl(MethodImplOptions.InternalCall)]
			[return: MarshalAs(UnmanagedType.Interface)]
			IXpsOMColorProfileResource GetByPartName([MarshalAs(UnmanagedType.Interface)] [In] IOpcPartUri partName);
		}

		[ComImport, Guid("3340FE8F-4027-4AA1-8F5F-D35AE45FE597"), InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
		public interface IXpsOMCoreProperties : IXpsOMPart
		{
			IXpsOMCoreProperties Clone();

			string GetCategory();

			string GetContentStatus();

			string GetContentType();

			SYSTEMTIME GetCreated();

			string GetCreator();

			string GetDescription();

			string GetIdentifier();

			string GetKeywords();

			string GetLanguage();

			string GetLastModifiedBy();

			SYSTEMTIME GetLastPrinted();

			SYSTEMTIME GetModified();

			IXpsOMPackage GetOwner();

			string GetRevision();

			string GetSubject();

			string GetTitle();

			string GetVersion();

			void SetCategory([In] string category);

			void SetContentStatus([In] string contentStatus);

			void SetContentType([In] string contentType);

			void SetCreated(in SYSTEMTIME created);

			void SetCreator([In] string creator);

			void SetDescription([In] string description);

			void SetIdentifier([In] string identifier);

			void SetKeywords([In] string keywords);

			void SetLanguage([In] string language);

			void SetLastModifiedBy([In] string lastModifiedBy);

			void SetLastPrinted(in SYSTEMTIME lastPrinted);

			void SetModified(in SYSTEMTIME modified);

			void SetRevision([In] string revision);

			void SetSubject([In] string subject);

			void SetTitle([In] string title);

			void SetVersion([In] string version);
		}

		[ComImport, Guid("081613F4-74EB-48F2-83B3-37A9CE2D7DC6"), InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
		public interface IXpsOMDashCollection
		{
			void Append([In][ComAliasName("System.Windows.Xps.Serialization.RCW.XPS_DASH")] ref XPS_DASH dash);

			XPS_DASH GetAt([In] uint index);

			uint GetCount();

			void InsertAt([In] uint index, [In][ComAliasName("System.Windows.Xps.Serialization.RCW.XPS_DASH")] ref XPS_DASH dash);

			void RemoveAt([In] uint index);

			void SetAt([In] uint index, [In][ComAliasName("System.Windows.Xps.Serialization.RCW.XPS_DASH")] ref XPS_DASH dash);
		}

		[ComImport, Guid("897C86B8-8EAF-4AE3-BDDE-56419FCF4236"), InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
		public interface IXpsOMDictionary
		{
			void Append([In] string key, [In] IXpsOMShareable entry);

			IXpsOMDictionary Clone();

			IXpsOMShareable GetAt([In] uint index, out string key);

			IXpsOMShareable GetByKey([In] string key, [In] IXpsOMShareable beforeEntry);

			uint GetCount();

			uint GetIndex([In] IXpsOMShareable entry);

			object GetOwner();

			void InsertAt([In] uint index, [In] string key, [In] IXpsOMShareable entry);

			void RemoveAt([In] uint index);

			void SetAt([In] uint index, [In] string key, [In] IXpsOMShareable entry);
		}

		[ComImport, Guid("2C2C94CB-AC5F-4254-8EE9-23948309D9F0"), InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
		public interface IXpsOMDocument : IXpsOMPart
		{
			IXpsOMDocument Clone();

			IXpsOMDocumentStructureResource GetDocumentStructureResource();

			IXpsOMDocumentSequence GetOwner();

			IXpsOMPageReferenceCollection GetPageReferences();

			IXpsOMPrintTicketResource GetPrintTicketResource();

			IXpsOMSignatureBlockResourceCollection GetSignatureBlockResources();

			void SetDocumentStructureResource([In] IXpsOMDocumentStructureResource documentStructureResource);

			void SetPrintTicketResource([In] IXpsOMPrintTicketResource printTicketResource);
		}

		[ComImport, Guid("D1C87F0D-E947-4754-8A25-971478F7E83E"), InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
		public interface IXpsOMDocumentCollection
		{
			void Append([In] IXpsOMDocument document);

			IXpsOMDocument GetAt([In] uint index);

			uint GetCount();

			void InsertAt([In] uint index, [In] IXpsOMDocument document);

			void RemoveAt([In] uint index);

			void SetAt([In] uint index, [In] IXpsOMDocument document);
		}

		[ComImport, Guid("56492EB4-D8D5-425E-8256-4C2B64AD0264"), InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
		public interface IXpsOMDocumentSequence : IXpsOMPart
		{
			IXpsOMDocumentCollection GetDocuments();

			IXpsOMPackage GetOwner();

			IXpsOMPrintTicketResource GetPrintTicketResource();

			void SetPrintTicketResource([In] IXpsOMPrintTicketResource printTicketResource);
		}

		[ComImport, Guid("85FEBC8A-6B63-48A9-AF07-7064E4ECFF30"), InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
		public interface IXpsOMDocumentStructureResource : IXpsOMResource
		{
			[MethodImpl(MethodImplOptions.InternalCall)]
			[return: MarshalAs(UnmanagedType.Interface)]
			new IOpcPartUri GetPartName();

			[MethodImpl(MethodImplOptions.InternalCall)]
			new void SetPartName([MarshalAs(UnmanagedType.Interface)] [In] IOpcPartUri partUri);

			[MethodImpl(MethodImplOptions.InternalCall)]
			[return: MarshalAs(UnmanagedType.Interface)]
			IXpsOMDocument GetOwner();

			[MethodImpl(MethodImplOptions.InternalCall)]
			[return: MarshalAs(UnmanagedType.Interface)]
			IStream GetStream();

			[MethodImpl(MethodImplOptions.InternalCall)]
			void SetContent([MarshalAs(UnmanagedType.Interface)] [In] IStream sourceStream, [MarshalAs(UnmanagedType.Interface)] [In] IOpcPartUri partName);
		}

		[ComImport, Guid("A8C45708-47D9-4AF4-8D20-33B48C9B8485"), InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
		public interface IXpsOMFontResource : IXpsOMResource
		{
			[MethodImpl(MethodImplOptions.InternalCall)]
			[return: MarshalAs(UnmanagedType.Interface)]
			IStream GetStream();

			[MethodImpl(MethodImplOptions.InternalCall)]
			void SetContent([MarshalAs(UnmanagedType.Interface)] [In] IStream sourceStream, [ComAliasName("System.Windows.Xps.Serialization.RCW.XPS_FONT_EMBEDDING")] [In] XPS_FONT_EMBEDDING embeddingOption, [MarshalAs(UnmanagedType.Interface)] [In] IOpcPartUri partName);

			[MethodImpl(MethodImplOptions.InternalCall)]
			[return: ComAliasName("System.Windows.Xps.Serialization.RCW.XPS_FONT_EMBEDDING")]
			XPS_FONT_EMBEDDING GetEmbeddingOption();
		}

		[ComImport, Guid("70B4A6BB-88D4-4FA8-AAF9-6D9C596FDBAD"), InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
		public interface IXpsOMFontResourceCollection
		{
			[MethodImpl(MethodImplOptions.InternalCall)]
			uint GetCount();

			[MethodImpl(MethodImplOptions.InternalCall)]
			[return: MarshalAs(UnmanagedType.Interface)]
			IXpsOMFontResource GetAt([In] uint index);

			[MethodImpl(MethodImplOptions.InternalCall)]
			void SetAt([In] uint index, [MarshalAs(UnmanagedType.Interface)] [In] IXpsOMFontResource value);

			[MethodImpl(MethodImplOptions.InternalCall)]
			void InsertAt([In] uint index, [MarshalAs(UnmanagedType.Interface)] [In] IXpsOMFontResource value);

			[MethodImpl(MethodImplOptions.InternalCall)]
			void Append([MarshalAs(UnmanagedType.Interface)] [In] IXpsOMFontResource value);

			[MethodImpl(MethodImplOptions.InternalCall)]
			void RemoveAt([In] uint index);

			[MethodImpl(MethodImplOptions.InternalCall)]
			[return: MarshalAs(UnmanagedType.Interface)]
			IXpsOMFontResource GetByPartName([MarshalAs(UnmanagedType.Interface)] [In] IOpcPartUri partName);
		}

		[ComImport, Guid("64FCF3D7-4D58-44BA-AD73-A13AF6492072"), InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
		public interface IXpsOMGeometry : IXpsOMShareable
		{
			IXpsOMGeometry Clone();

			IXpsOMGeometryFigureCollection GetFigures();

			XPS_FILL_RULE GetFillRule();

			IXpsOMMatrixTransform GetTransform();

			IXpsOMMatrixTransform GetTransformLocal();

			string GetTransformLookup();

			void SetFillRule([In][ComAliasName("System.Windows.Xps.Serialization.RCW.XPS_FILL_RULE")] XPS_FILL_RULE fillRule);

			void SetTransformLocal([In] IXpsOMMatrixTransform transform);

			void SetTransformLookup([In] string lookup);
		}

		[ComImport, Guid("D410DC83-908C-443E-8947-B1795D3C165A"), InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
		public interface IXpsOMGeometryFigure
		{
			IXpsOMGeometryFigure Clone();

			int GetIsClosed();

			int GetIsFilled();

			IXpsOMGeometry GetOwner();

			uint GetSegmentCount();

			void GetSegmentData([In][Out] ref uint dataCount, [In][Out] ref float segmentData);

			uint GetSegmentDataCount();

			XPS_SEGMENT_STROKE_PATTERN GetSegmentStrokePattern();

			void GetSegmentStrokes([In][Out] ref uint segmentCount, [In][Out] ref int segmentStrokes);

			void GetSegmentTypes([In][Out] ref uint segmentCount, [In][Out][ComAliasName("System.Windows.Xps.Serialization.RCW.XPS_SEGMENT_TYPE")] ref XPS_SEGMENT_TYPE segmentTypes);

			XPS_POINT GetStartPoint();

			void SetIsClosed([In] int isClosed);

			void SetIsFilled([In] int isFilled);

			void SetSegments([In] uint segmentCount, [In] uint segmentDataCount, [In][ComAliasName("System.Windows.Xps.Serialization.RCW.XPS_SEGMENT_TYPE")] ref XPS_SEGMENT_TYPE segmentTypes, in float segmentData, in int segmentStrokes);

			void SetStartPoint([In][ComAliasName("System.Windows.Xps.Serialization.RCW.XPS_POINT")] ref XPS_POINT startPoint);
		}

		[ComImport, Guid("FD48C3F3-A58E-4B5A-8826-1DE54ABE72B2"), InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
		public interface IXpsOMGeometryFigureCollection
		{
			void Append([In] IXpsOMGeometryFigure geometryFigure);

			IXpsOMGeometryFigure GetAt([In] uint index);

			uint GetCount();

			void InsertAt([In] uint index, [In] IXpsOMGeometryFigure geometryFigure);

			void RemoveAt([In] uint index);

			void SetAt([In] uint index, [In] IXpsOMGeometryFigure geometryFigure);
		}

		[ComImport, Guid("819B3199-0A5A-4B64-BEC7-A9E17E780DE2"), InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
		public interface IXpsOMGlyphs : IXpsOMVisual
		{
			IXpsOMGlyphs Clone();

			uint GetBidiLevel();

			string GetDeviceFontName();

			IXpsOMBrush GetFillBrush();

			IXpsOMBrush GetFillBrushLocal();

			string GetFillBrushLookup();

			short GetFontFaceIndex();

			float GetFontRenderingEmSize();

			IXpsOMFontResource GetFontResource();

			uint GetGlyphIndexCount();

			void GetGlyphIndices([In][Out] ref uint indexCount, [In][Out][ComAliasName("System.Windows.Xps.Serialization.RCW.XPS_GLYPH_INDEX")] ref XPS_GLYPH_INDEX glyphIndices);

			uint GetGlyphMappingCount();

			void GetGlyphMappings([In][Out] ref uint glyphMappingCount, [In][Out][ComAliasName("System.Windows.Xps.Serialization.RCW.XPS_GLYPH_MAPPING")] ref XPS_GLYPH_MAPPING glyphMappings);

			IXpsOMGlyphsEditor GetGlyphsEditor();

			int GetIsSideways();

			XPS_POINT GetOrigin();

			uint GetProhibitedCaretStopCount();

			void GetProhibitedCaretStops([In][Out] ref uint prohibitedCaretStopCount, out uint prohibitedCaretStops);

			XPS_STYLE_SIMULATION GetStyleSimulations();

			string GetUnicodeString();

			void SetFillBrushLocal([In] IXpsOMBrush fillBrush);

			void SetFillBrushLookup([In] string key);

			void SetFontFaceIndex([In] short fontFaceIndex);

			void SetFontRenderingEmSize([In] float fontRenderingEmSize);

			void SetFontResource([In] IXpsOMFontResource fontResource);

			void SetOrigin([In][ComAliasName("System.Windows.Xps.Serialization.RCW.XPS_POINT")] ref XPS_POINT origin);

			void SetStyleSimulations([In][ComAliasName("System.Windows.Xps.Serialization.RCW.XPS_STYLE_SIMULATION")] XPS_STYLE_SIMULATION styleSimulations);
		}

		[ComImport, Guid("A5AB8616-5B16-4B9F-9629-89B323ED7909"), InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
		public interface IXpsOMGlyphsEditor
		{
			void ApplyEdits();

			uint GetBidiLevel();

			string GetDeviceFontName();

			uint GetGlyphIndexCount();

			void GetGlyphIndices([In][Out] ref uint indexCount, [ComAliasName("System.Windows.Xps.Serialization.RCW.XPS_GLYPH_INDEX")] out XPS_GLYPH_INDEX glyphIndices);

			uint GetGlyphMappingCount();

			void GetGlyphMappings([In][Out] ref uint glyphMappingCount, [ComAliasName("System.Windows.Xps.Serialization.RCW.XPS_GLYPH_MAPPING")] out XPS_GLYPH_MAPPING glyphMappings);

			int GetIsSideways();

			uint GetProhibitedCaretStopCount();

			void GetProhibitedCaretStops([In][Out] ref uint count, out uint prohibitedCaretStops);

			string GetUnicodeString();

			void SetBidiLevel([In] uint bidiLevel);

			void SetDeviceFontName([In] string deviceFontName);

			void SetGlyphIndices([In] uint indexCount, [In][ComAliasName("System.Windows.Xps.Serialization.RCW.XPS_GLYPH_INDEX")] ref XPS_GLYPH_INDEX glyphIndices);

			void SetGlyphMappings([In] uint glyphMappingCount, [In][ComAliasName("System.Windows.Xps.Serialization.RCW.XPS_GLYPH_MAPPING")] ref XPS_GLYPH_MAPPING glyphMappings);

			void SetIsSideways([In] int isSideways);

			void SetProhibitedCaretStops([In] uint count, in uint prohibitedCaretStops);

			void SetUnicodeString([In] string unicodeString);
		}

		[ComImport, Guid("EDB59622-61A2-42C3-BACE-ACF2286C06BF"), InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
		public interface IXpsOMGradientBrush : IXpsOMBrush
		{
			XPS_COLOR_INTERPOLATION GetColorInterpolationMode();

			IXpsOMGradientStopCollection GetGradientStops();

			XPS_SPREAD_METHOD GetSpreadMethod();

			IXpsOMMatrixTransform GetTransform();

			IXpsOMMatrixTransform GetTransformLocal();

			string GetTransformLookup();

			void SetColorInterpolationMode([In][ComAliasName("System.Windows.Xps.Serialization.RCW.XPS_COLOR_INTERPOLATION")] XPS_COLOR_INTERPOLATION colorInterpolationMode);

			void SetSpreadMethod([In][ComAliasName("System.Windows.Xps.Serialization.RCW.XPS_SPREAD_METHOD")] XPS_SPREAD_METHOD spreadMethod);

			void SetTransformLocal([In] IXpsOMMatrixTransform transform);

			void SetTransformLookup([In] string key);
		}

		[ComImport, Guid("5CF4F5CC-3969-49B5-A70A-5550B618FE49"), InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
		public interface IXpsOMGradientStop
		{
			IXpsOMGradientStop Clone();

			IXpsOMColorProfileResource GetColor([ComAliasName("System.Windows.Xps.Serialization.RCW.XPS_COLOR")] out XPS_COLOR color);

			float GetOffset();

			IXpsOMGradientBrush GetOwner();

			void SetColor([In][ComAliasName("System.Windows.Xps.Serialization.RCW.XPS_COLOR")] ref XPS_COLOR color, [In] IXpsOMColorProfileResource colorProfile);

			void SetOffset([In] float offset);
		}

		[ComImport, Guid("C9174C3A-3CD3-4319-BDA4-11A39392CEEF"), InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
		public interface IXpsOMGradientStopCollection
		{
			void Append([In] IXpsOMGradientStop stop);

			IXpsOMGradientStop GetAt([In] uint index);

			uint GetCount();

			void InsertAt([In] uint index, [In] IXpsOMGradientStop stop);

			void RemoveAt([In] uint index);

			void SetAt([In] uint index, [In] IXpsOMGradientStop stop);
		}

		[ComImport, Guid("3DF0B466-D382-49EF-8550-DD94C80242E4"), InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
		public interface IXpsOMImageBrush : IXpsOMTileBrush
		{
			IXpsOMImageBrush Clone();

			IXpsOMColorProfileResource GetColorProfileResource();

			IXpsOMImageResource GetImageResource();

			void SetColorProfileResource([In] IXpsOMColorProfileResource colorProfileResource);

			void SetImageResource([In] IXpsOMImageResource imageResource);
		}

		[ComImport, Guid("3DB8417D-AE50-485E-9A44-D7758F78A23F"), InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
		public interface IXpsOMImageResource : IXpsOMResource
		{
			[MethodImpl(MethodImplOptions.InternalCall)]
			[return: MarshalAs(UnmanagedType.Interface)]
			IStream GetStream();

			[MethodImpl(MethodImplOptions.InternalCall)]
			void SetContent([MarshalAs(UnmanagedType.Interface)] [In] IStream sourceStream, [ComAliasName("System.Windows.Xps.Serialization.RCW.XPS_IMAGE_TYPE")] [In] XPS_IMAGE_TYPE imageType, [MarshalAs(UnmanagedType.Interface)] [In] IOpcPartUri partName);

			[MethodImpl(MethodImplOptions.InternalCall)]
			[return: ComAliasName("System.Windows.Xps.Serialization.RCW.XPS_IMAGE_TYPE")]
			XPS_IMAGE_TYPE GetImageType();
		}

		[ComImport, Guid("7A4A1A71-9CDE-4B71-B33F-62DE843EABFE"), InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
		public interface IXpsOMImageResourceCollection
		{
			[MethodImpl(MethodImplOptions.InternalCall)]
			uint GetCount();

			[MethodImpl(MethodImplOptions.InternalCall)]
			[return: MarshalAs(UnmanagedType.Interface)]
			IXpsOMImageResource GetAt([In] uint index);

			[MethodImpl(MethodImplOptions.InternalCall)]
			void InsertAt([In] uint index, [MarshalAs(UnmanagedType.Interface)] [In] IXpsOMImageResource @object);

			[MethodImpl(MethodImplOptions.InternalCall)]
			void RemoveAt([In] uint index);

			[MethodImpl(MethodImplOptions.InternalCall)]
			void SetAt([In] uint index, [MarshalAs(UnmanagedType.Interface)] [In] IXpsOMImageResource @object);

			[MethodImpl(MethodImplOptions.InternalCall)]
			void Append([MarshalAs(UnmanagedType.Interface)] [In] IXpsOMImageResource @object);

			[MethodImpl(MethodImplOptions.InternalCall)]
			[return: MarshalAs(UnmanagedType.Interface)]
			IXpsOMImageResource GetByPartName([MarshalAs(UnmanagedType.Interface)] [In] IOpcPartUri partName);
		}

		[ComImport, Guid("005E279F-C30D-40FF-93EC-1950D3C528DB"), InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
		public interface IXpsOMLinearGradientBrush : IXpsOMGradientBrush
		{
			IXpsOMLinearGradientBrush Clone();

			XPS_POINT GetEndPoint();

			XPS_POINT GetStartPoint();

			void SetEndPoint([In][ComAliasName("System.Windows.Xps.Serialization.RCW.XPS_POINT")] ref XPS_POINT endPoint);

			void SetStartPoint([In][ComAliasName("System.Windows.Xps.Serialization.RCW.XPS_POINT")] ref XPS_POINT startPoint);
		}

		[ComImport, Guid("B77330FF-BB37-4501-A93E-F1B1E50BFC46"), InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
		public interface IXpsOMMatrixTransform : IXpsOMShareable
		{
			IXpsOMMatrixTransform Clone();

			XPS_MATRIX GetMatrix();

			void SetMatrix([In][ComAliasName("System.Windows.Xps.Serialization.RCW.XPS_MATRIX")] ref XPS_MATRIX matrix);
		}

		[ComImport, Guid("4BDDF8EC-C915-421B-A166-D173D25653D2"), InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
		public interface IXpsOMNameCollection
		{
			string GetAt([In] uint index);

			uint GetCount();
		}

		[ComImport, Guid("F9B2A685-A50D-4FC2-B764-B56E093EA0CA"), InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
		public interface IXpsOMObjectFactory
		{
			[MethodImpl(MethodImplOptions.InternalCall)]
			[return: MarshalAs(UnmanagedType.Interface)]
			IXpsOMPackage CreatePackage();

			[MethodImpl(MethodImplOptions.InternalCall)]
			[return: MarshalAs(UnmanagedType.Interface)]
			IXpsOMPackage CreatePackageFromFile([MarshalAs(UnmanagedType.LPWStr)] [In] string fileName, [In] int reuseObjects);

			[MethodImpl(MethodImplOptions.InternalCall)]
			[return: MarshalAs(UnmanagedType.Interface)]
			IXpsOMPackage CreatePackageFromStream([MarshalAs(UnmanagedType.Interface)] [In] IStream stream, [In] int reuseObjects);

			[MethodImpl(MethodImplOptions.InternalCall)]
			[return: MarshalAs(UnmanagedType.Interface)]
			IXpsOMStoryFragmentsResource CreateStoryFragmentsResource([MarshalAs(UnmanagedType.Interface)] [In] IStream acquiredStream, [MarshalAs(UnmanagedType.Interface)] [In] IOpcPartUri partUri);

			[MethodImpl(MethodImplOptions.InternalCall)]
			[return: MarshalAs(UnmanagedType.Interface)]
			IXpsOMDocumentStructureResource CreateDocumentStructureResource([MarshalAs(UnmanagedType.Interface)] [In] IStream acquiredStream, [MarshalAs(UnmanagedType.Interface)] [In] IOpcPartUri partUri);

			[MethodImpl(MethodImplOptions.InternalCall)]
			[return: MarshalAs(UnmanagedType.Interface)]
			IXpsOMSignatureBlockResource CreateSignatureBlockResource([MarshalAs(UnmanagedType.Interface)] [In] IStream acquiredStream, [MarshalAs(UnmanagedType.Interface)] [In] IOpcPartUri partUri);

			[MethodImpl(MethodImplOptions.InternalCall)]
			[return: MarshalAs(UnmanagedType.Interface)]
			IXpsOMRemoteDictionaryResource CreateRemoteDictionaryResource([MarshalAs(UnmanagedType.Interface)] [In] IXpsOMDictionary dictionary, [MarshalAs(UnmanagedType.Interface)] [In] IOpcPartUri partUri);

			[MethodImpl(MethodImplOptions.InternalCall)]
			[return: MarshalAs(UnmanagedType.Interface)]
			IXpsOMRemoteDictionaryResource CreateRemoteDictionaryResourceFromStream([MarshalAs(UnmanagedType.Interface)] [In] IStream dictionaryMarkupStream, [MarshalAs(UnmanagedType.Interface)] [In] IOpcPartUri dictionaryPartUri, [MarshalAs(UnmanagedType.Interface)] [In] IXpsOMPartResources resources);

			[MethodImpl(MethodImplOptions.InternalCall)]
			[return: MarshalAs(UnmanagedType.Interface)]
			IXpsOMPartResources CreatePartResources();

			[MethodImpl(MethodImplOptions.InternalCall)]
			[return: MarshalAs(UnmanagedType.Interface)]
			IXpsOMDocumentSequence CreateDocumentSequence([MarshalAs(UnmanagedType.Interface)] [In] IOpcPartUri partUri);

			[MethodImpl(MethodImplOptions.InternalCall)]
			[return: MarshalAs(UnmanagedType.Interface)]
			IXpsOMDocument CreateDocument([MarshalAs(UnmanagedType.Interface)] [In] IOpcPartUri partUri);

			[MethodImpl(MethodImplOptions.InternalCall)]
			[return: MarshalAs(UnmanagedType.Interface)]
			IXpsOMPageReference CreatePageReference([ComAliasName("System.Windows.Xps.Serialization.RCW.XPS_SIZE")] in XPS_SIZE advisoryPageDimensions);

			[MethodImpl(MethodImplOptions.InternalCall)]
			[return: MarshalAs(UnmanagedType.Interface)]
			IXpsOMPage CreatePage([ComAliasName("System.Windows.Xps.Serialization.RCW.XPS_SIZE")] in XPS_SIZE pageDimensions, [MarshalAs(UnmanagedType.LPWStr)] [In] string language, [MarshalAs(UnmanagedType.Interface)] [In] IOpcPartUri partUri);

			[MethodImpl(MethodImplOptions.InternalCall)]
			[return: MarshalAs(UnmanagedType.Interface)]
			IXpsOMPage CreatePageFromStream([MarshalAs(UnmanagedType.Interface)] [In] IStream pageMarkupStream, [MarshalAs(UnmanagedType.Interface)] [In] IOpcPartUri partUri, [MarshalAs(UnmanagedType.Interface)] [In] IXpsOMPartResources resources, [In] int reuseObjects);

			[MethodImpl(MethodImplOptions.InternalCall)]
			[return: MarshalAs(UnmanagedType.Interface)]
			IXpsOMCanvas CreateCanvas();

			[MethodImpl(MethodImplOptions.InternalCall)]
			[return: MarshalAs(UnmanagedType.Interface)]
			IXpsOMGlyphs CreateGlyphs([MarshalAs(UnmanagedType.Interface)] [In] IXpsOMFontResource fontResource);

			[MethodImpl(MethodImplOptions.InternalCall)]
			[return: MarshalAs(UnmanagedType.Interface)]
			IXpsOMPath CreatePath();

			[MethodImpl(MethodImplOptions.InternalCall)]
			[return: MarshalAs(UnmanagedType.Interface)]
			IXpsOMGeometry CreateGeometry();

			[MethodImpl(MethodImplOptions.InternalCall)]
			[return: MarshalAs(UnmanagedType.Interface)]
			IXpsOMGeometryFigure CreateGeometryFigure([ComAliasName("System.Windows.Xps.Serialization.RCW.XPS_POINT")] in XPS_POINT startPoint);

			[MethodImpl(MethodImplOptions.InternalCall)]
			[return: MarshalAs(UnmanagedType.Interface)]
			IXpsOMMatrixTransform CreateMatrixTransform([ComAliasName("System.Windows.Xps.Serialization.RCW.XPS_MATRIX")] in XPS_MATRIX matrix);

			[MethodImpl(MethodImplOptions.InternalCall)]
			[return: MarshalAs(UnmanagedType.Interface)]
			IXpsOMSolidColorBrush CreateSolidColorBrush([ComAliasName("System.Windows.Xps.Serialization.RCW.XPS_COLOR")] in XPS_COLOR color, [MarshalAs(UnmanagedType.Interface)] [In] IXpsOMColorProfileResource colorProfile);

			[MethodImpl(MethodImplOptions.InternalCall)]
			[return: MarshalAs(UnmanagedType.Interface)]
			IXpsOMColorProfileResource CreateColorProfileResource([MarshalAs(UnmanagedType.Interface)] [In] IStream acquiredStream, [MarshalAs(UnmanagedType.Interface)] [In] IOpcPartUri partUri);

			[MethodImpl(MethodImplOptions.InternalCall)]
			[return: MarshalAs(UnmanagedType.Interface)]
			IXpsOMImageBrush CreateImageBrush([MarshalAs(UnmanagedType.Interface)] [In] IXpsOMImageResource image, [ComAliasName("System.Windows.Xps.Serialization.RCW.XPS_RECT")] in XPS_RECT viewbox, [ComAliasName("System.Windows.Xps.Serialization.RCW.XPS_RECT")] in XPS_RECT viewport);

			[MethodImpl(MethodImplOptions.InternalCall)]
			[return: MarshalAs(UnmanagedType.Interface)]
			IXpsOMVisualBrush CreateVisualBrush([ComAliasName("System.Windows.Xps.Serialization.RCW.XPS_RECT")] in XPS_RECT viewbox, [ComAliasName("System.Windows.Xps.Serialization.RCW.XPS_RECT")] in XPS_RECT viewport);

			[MethodImpl(MethodImplOptions.InternalCall)]
			[return: MarshalAs(UnmanagedType.Interface)]
			IXpsOMImageResource CreateImageResource([MarshalAs(UnmanagedType.Interface)] [In] IStream acquiredStream, [ComAliasName("System.Windows.Xps.Serialization.RCW.XPS_IMAGE_TYPE")] [In] XPS_IMAGE_TYPE contentType, [MarshalAs(UnmanagedType.Interface)] [In] IOpcPartUri partUri);

			[MethodImpl(MethodImplOptions.InternalCall)]
			[return: MarshalAs(UnmanagedType.Interface)]
			IXpsOMPrintTicketResource CreatePrintTicketResource([MarshalAs(UnmanagedType.Interface)] [In] IStream acquiredStream, [MarshalAs(UnmanagedType.Interface)] [In] IOpcPartUri partUri);

			[MethodImpl(MethodImplOptions.InternalCall)]
			[return: MarshalAs(UnmanagedType.Interface)]
			IXpsOMFontResource CreateFontResource([MarshalAs(UnmanagedType.Interface)] [In] IStream acquiredStream, [ComAliasName("System.Windows.Xps.Serialization.RCW.XPS_FONT_EMBEDDING")] [In] XPS_FONT_EMBEDDING fontEmbedding, [MarshalAs(UnmanagedType.Interface)] [In] IOpcPartUri partUri, [In] int isObfSourceStream);

			[MethodImpl(MethodImplOptions.InternalCall)]
			[return: MarshalAs(UnmanagedType.Interface)]
			IXpsOMGradientStop CreateGradientStop([ComAliasName("System.Windows.Xps.Serialization.RCW.XPS_COLOR")] in XPS_COLOR color, [MarshalAs(UnmanagedType.Interface)] [In] IXpsOMColorProfileResource colorProfile, [In] float offset);

			[MethodImpl(MethodImplOptions.InternalCall)]
			[return: MarshalAs(UnmanagedType.Interface)]
			IXpsOMLinearGradientBrush CreateLinearGradientBrush([MarshalAs(UnmanagedType.Interface)] [In] IXpsOMGradientStop gradStop1, [MarshalAs(UnmanagedType.Interface)] [In] IXpsOMGradientStop gradStop2, [ComAliasName("System.Windows.Xps.Serialization.RCW.XPS_POINT")] in XPS_POINT startPoint, [ComAliasName("System.Windows.Xps.Serialization.RCW.XPS_POINT")] in XPS_POINT endPoint);

			[MethodImpl(MethodImplOptions.InternalCall)]
			[return: MarshalAs(UnmanagedType.Interface)]
			IXpsOMRadialGradientBrush CreateRadialGradientBrush([MarshalAs(UnmanagedType.Interface)] [In] IXpsOMGradientStop gradStop1, [MarshalAs(UnmanagedType.Interface)] [In] IXpsOMGradientStop gradStop2, [ComAliasName("System.Windows.Xps.Serialization.RCW.XPS_POINT")] in XPS_POINT centerPoint, [ComAliasName("System.Windows.Xps.Serialization.RCW.XPS_POINT")] in XPS_POINT gradientOrigin, [ComAliasName("System.Windows.Xps.Serialization.RCW.XPS_SIZE")] in XPS_SIZE radiiSizes);

			[MethodImpl(MethodImplOptions.InternalCall)]
			[return: MarshalAs(UnmanagedType.Interface)]
			IXpsOMCoreProperties CreateCoreProperties([MarshalAs(UnmanagedType.Interface)] [In] IOpcPartUri partUri);

			[MethodImpl(MethodImplOptions.InternalCall)]
			[return: MarshalAs(UnmanagedType.Interface)]
			IXpsOMDictionary CreateDictionary();

			[MethodImpl(MethodImplOptions.InternalCall)]
			[return: MarshalAs(UnmanagedType.Interface)]
			IXpsOMPartUriCollection CreatePartUriCollection();

			[MethodImpl(MethodImplOptions.InternalCall)]
			[return: MarshalAs(UnmanagedType.Interface)]
			IXpsOMPackageWriter CreatePackageWriterOnFile([MarshalAs(UnmanagedType.LPWStr)] [In] string fileName, [In] IntPtr securityAttributes, [In] uint flagsAndAttributes, [In] int optimizeMarkupSize, [ComAliasName("System.Windows.Xps.Serialization.RCW.XPS_INTERLEAVING")] [In] XPS_INTERLEAVING interleaving, [MarshalAs(UnmanagedType.Interface)] [In] IOpcPartUri documentSequencePartName, [MarshalAs(UnmanagedType.Interface)] [In] IXpsOMCoreProperties coreProperties, [MarshalAs(UnmanagedType.Interface)] [In] IXpsOMImageResource packageThumbnail, [MarshalAs(UnmanagedType.Interface)] [In] IXpsOMPrintTicketResource documentSequencePrintTicket, [MarshalAs(UnmanagedType.Interface)] [In] IOpcPartUri discardControlPartName);

			[MethodImpl(MethodImplOptions.InternalCall)]
			[return: MarshalAs(UnmanagedType.Interface)]
			IXpsOMPackageWriter CreatePackageWriterOnStream([MarshalAs(UnmanagedType.Interface)] [In] ISequentialStream outputStream, [In] int optimizeMarkupSize, [ComAliasName("System.Windows.Xps.Serialization.RCW.XPS_INTERLEAVING")] [In] XPS_INTERLEAVING interleaving, [MarshalAs(UnmanagedType.Interface)] [In] IOpcPartUri documentSequencePartName, [MarshalAs(UnmanagedType.Interface)] [In] IXpsOMCoreProperties coreProperties, [MarshalAs(UnmanagedType.Interface)] [In] IXpsOMImageResource packageThumbnail, [MarshalAs(UnmanagedType.Interface)] [In] IXpsOMPrintTicketResource documentSequencePrintTicket, [MarshalAs(UnmanagedType.Interface)] [In] IOpcPartUri discardControlPartName);

			[MethodImpl(MethodImplOptions.InternalCall)]
			[return: MarshalAs(UnmanagedType.Interface)]
			IOpcPartUri CreatePartUri([MarshalAs(UnmanagedType.LPWStr)] [In] string uri);

			[MethodImpl(MethodImplOptions.InternalCall)]
			[return: MarshalAs(UnmanagedType.Interface)]
			IStream CreateReadOnlyStreamOnFile([MarshalAs(UnmanagedType.LPWStr)] [In] string fileName);
		}

		[ComImport, Guid("18C3DF65-81E1-4674-91DC-FC452F5A416F"), InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
		public interface IXpsOMPackage
		{
			IXpsOMCoreProperties GetCoreProperties();

			IOpcPartUri GetDiscardControlPartName();

			IXpsOMDocumentSequence GetDocumentSequence();

			IXpsOMImageResource GetThumbnailResource();

			void SetCoreProperties([In] IXpsOMCoreProperties coreProperties);

			void SetDiscardControlPartName([In] IOpcPartUri discardControlPartUri);

			void SetDocumentSequence([In] IXpsOMDocumentSequence documentSequence);

			void SetThumbnailResource([In] IXpsOMImageResource imageResource);

			void WriteToFile([In] string fileName, [In] SECURITY_ATTRIBUTES securityAttributes, [In] uint flagsAndAttributes, [In] int optimizeMarkupSize);

			void WriteToStream([In] ISequentialStream stream, [In] int optimizeMarkupSize);
		}

		[ComImport, Guid("4E2AA182-A443-42C6-B41B-4F8E9DE73FF9")]
		[InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
		public interface IXpsOMPackageWriter
		{
			[MethodImpl(MethodImplOptions.InternalCall)]
			void StartNewDocument([MarshalAs(UnmanagedType.Interface)] [In] IOpcPartUri documentPartName, [MarshalAs(UnmanagedType.Interface)] [In] IXpsOMPrintTicketResource documentPrintTicket, [MarshalAs(UnmanagedType.Interface)] [In] IXpsOMDocumentStructureResource documentStructure, [MarshalAs(UnmanagedType.Interface)] [In] IXpsOMSignatureBlockResourceCollection signatureBlockResources, [MarshalAs(UnmanagedType.Interface)] [In] IXpsOMPartUriCollection restrictedFonts);

			[MethodImpl(MethodImplOptions.InternalCall)]
			void AddPage([MarshalAs(UnmanagedType.Interface)] [In] IXpsOMPage page, [ComAliasName("MSXPS.XPS_SIZE")] in XPS_SIZE advisoryPageDimensions, [MarshalAs(UnmanagedType.Interface)] [In] IXpsOMPartUriCollection discardableResourceParts, [MarshalAs(UnmanagedType.Interface)] [In] IXpsOMStoryFragmentsResource storyFragments, [MarshalAs(UnmanagedType.Interface)] [In] IXpsOMPrintTicketResource pagePrintTicket, [MarshalAs(UnmanagedType.Interface)] [In] IXpsOMImageResource pageThumbnail);

			[MethodImpl(MethodImplOptions.InternalCall)]
			void AddResource([MarshalAs(UnmanagedType.Interface)] [In] IXpsOMResource resource);

			[MethodImpl(MethodImplOptions.InternalCall)]
			void Close();

			[MethodImpl(MethodImplOptions.InternalCall)]
			int isClosed();
		}

		[ComImport, Guid("D3E18888-F120-4FEE-8C68-35296EAE91D4"), InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
		public interface IXpsOMPage : IXpsOMPart
		{
			[MethodImpl(MethodImplOptions.InternalCall)]
			[return: MarshalAs(UnmanagedType.Interface)]
			new IOpcPartUri GetPartName();

			[MethodImpl(MethodImplOptions.InternalCall)]
			new void SetPartName([MarshalAs(UnmanagedType.Interface)] [In] IOpcPartUri partUri);

			[MethodImpl(MethodImplOptions.InternalCall)]
			[return: MarshalAs(UnmanagedType.Interface)]
			IXpsOMPageReference GetOwner();

			[MethodImpl(MethodImplOptions.InternalCall)]
			[return: MarshalAs(UnmanagedType.Interface)]
			IXpsOMVisualCollection GetVisuals();

			[MethodImpl(MethodImplOptions.InternalCall)]
			[return: ComAliasName("System.Windows.Xps.Serialization.RCW.XPS_SIZE")]
			XPS_SIZE GetPageDimensions();

			[MethodImpl(MethodImplOptions.InternalCall)]
			void SetPageDimensions([ComAliasName("System.Windows.Xps.Serialization.RCW.XPS_SIZE")] in XPS_SIZE pageDimensions);

			[MethodImpl(MethodImplOptions.InternalCall)]
			[return: ComAliasName("System.Windows.Xps.Serialization.RCW.XPS_RECT")]
			XPS_RECT GetContentBox();

			[MethodImpl(MethodImplOptions.InternalCall)]
			void SetContentBox([ComAliasName("System.Windows.Xps.Serialization.RCW.XPS_RECT")] in XPS_RECT contentBox);

			[MethodImpl(MethodImplOptions.InternalCall)]
			[return: ComAliasName("System.Windows.Xps.Serialization.RCW.XPS_RECT")]
			XPS_RECT GetBleedBox();

			[MethodImpl(MethodImplOptions.InternalCall)]
			void SetBleedBox([ComAliasName("System.Windows.Xps.Serialization.RCW.XPS_RECT")] in XPS_RECT bleedBox);

			[MethodImpl(MethodImplOptions.InternalCall)]
			[return: MarshalAs(UnmanagedType.LPWStr)]
			string GetLanguage();

			[MethodImpl(MethodImplOptions.InternalCall)]
			void SetLanguage([MarshalAs(UnmanagedType.LPWStr)] [In] string language);

			[MethodImpl(MethodImplOptions.InternalCall)]
			[return: MarshalAs(UnmanagedType.LPWStr)]
			string GetName();

			[MethodImpl(MethodImplOptions.InternalCall)]
			void SetName([MarshalAs(UnmanagedType.LPWStr)] [In] string name);

			[MethodImpl(MethodImplOptions.InternalCall)]
			int GetIsHyperlinkTarget();

			[MethodImpl(MethodImplOptions.InternalCall)]
			void SetIsHyperlinkTarget([In] int isHyperlinkTarget);

			[MethodImpl(MethodImplOptions.InternalCall)]
			[return: MarshalAs(UnmanagedType.Interface)]
			IXpsOMDictionary GetDictionary();

			[MethodImpl(MethodImplOptions.InternalCall)]
			[return: MarshalAs(UnmanagedType.Interface)]
			IXpsOMDictionary GetDictionaryLocal();

			[MethodImpl(MethodImplOptions.InternalCall)]
			void SetDictionaryLocal([MarshalAs(UnmanagedType.Interface)] [In] IXpsOMDictionary resourceDictionary);

			[MethodImpl(MethodImplOptions.InternalCall)]
			[return: MarshalAs(UnmanagedType.Interface)]
			IXpsOMRemoteDictionaryResource GetDictionaryResource();

			[MethodImpl(MethodImplOptions.InternalCall)]
			void SetDictionaryResource([MarshalAs(UnmanagedType.Interface)] [In] IXpsOMRemoteDictionaryResource remoteDictionaryResource);

			[MethodImpl(MethodImplOptions.InternalCall)]
			void Write([MarshalAs(UnmanagedType.Interface)] [In] ISequentialStream stream, [In] int optimizeMarkupSize);

			[MethodImpl(MethodImplOptions.InternalCall)]
			[return: MarshalAs(UnmanagedType.LPWStr)]
			string GenerateUnusedLookupKey([ComAliasName("System.Windows.Xps.Serialization.RCW.XPS_OBJECT_TYPE")] [In] XPS_OBJECT_TYPE type);

			[MethodImpl(MethodImplOptions.InternalCall)]
			[return: MarshalAs(UnmanagedType.Interface)]
			IXpsOMPage Clone();
		}

		[ComImport, Guid("ED360180-6F92-4998-890D-2F208531A0A0"), InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
		public interface IXpsOMPageReference
		{
			IXpsOMPageReference Clone();

			IXpsOMNameCollection CollectLinkTargets();

			IXpsOMPartResources CollectPartResources();

			void DiscardPage();

			XPS_SIZE GetAdvisoryPageDimensions();

			IXpsOMDocument GetOwner();

			IXpsOMPage GetPage();

			IXpsOMPrintTicketResource GetPrintTicketResource();

			IXpsOMStoryFragmentsResource GetStoryFragmentsResource();

			IXpsOMImageResource GetThumbnailResource();

			int HasRestrictedFonts();

			int IsPageLoaded();

			void SetAdvisoryPageDimensions([In][ComAliasName("System.Windows.Xps.Serialization.RCW.XPS_SIZE")] ref XPS_SIZE pageDimensions);

			void SetPage([In] IXpsOMPage page);

			void SetPrintTicketResource([In] IXpsOMPrintTicketResource printTicketResource);

			void SetStoryFragmentsResource([In] IXpsOMStoryFragmentsResource storyFragmentsResource);

			void SetThumbnailResource([In] IXpsOMImageResource imageResource);
		}

		[ComImport, Guid("CA16BA4D-E7B9-45C5-958B-F98022473745"), InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
		public interface IXpsOMPageReferenceCollection
		{
			void Append([In] IXpsOMPageReference pageReference);

			IXpsOMPageReference GetAt([In] uint index);

			uint GetCount();

			void InsertAt([In] uint index, [In] IXpsOMPageReference pageReference);

			void RemoveAt([In] uint index);

			void SetAt([In] uint index, [In] IXpsOMPageReference pageReference);
		}

		[ComImport, Guid("74EB2F0B-A91E-4486-AFAC-0FABECA3DFC6"), InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
		public interface IXpsOMPart
		{
			[MethodImpl(MethodImplOptions.InternalCall)]
			[return: MarshalAs(UnmanagedType.Interface)]
			IOpcPartUri GetPartName();

			[MethodImpl(MethodImplOptions.InternalCall)]
			void SetPartName([MarshalAs(UnmanagedType.Interface)] [In] IOpcPartUri partUri);
		}

		[ComImport, Guid("F4CF7729-4864-4275-99B3-A8717163ECAF"), InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
		public interface IXpsOMPartResources
		{
			[MethodImpl(MethodImplOptions.InternalCall)]
			[return: MarshalAs(UnmanagedType.Interface)]
			IXpsOMFontResourceCollection GetFontResources();

			[MethodImpl(MethodImplOptions.InternalCall)]
			[return: MarshalAs(UnmanagedType.Interface)]
			IXpsOMImageResourceCollection GetImageResources();

			[MethodImpl(MethodImplOptions.InternalCall)]
			[return: MarshalAs(UnmanagedType.Interface)]
			IXpsOMColorProfileResourceCollection GetColorProfileResources();

			[MethodImpl(MethodImplOptions.InternalCall)]
			[return: MarshalAs(UnmanagedType.Interface)]
			IXpsOMRemoteDictionaryResourceCollection GetRemoteDictionaryResources();
		}

		[ComImport, Guid("57C650D4-067C-4893-8C33-F62A0633730F"), InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
		public interface IXpsOMPartUriCollection
		{
			void Append([In] IOpcPartUri partUri);

			IOpcPartUri GetAt([In] uint index);

			uint GetCount();

			void InsertAt([In] uint index, [In] IOpcPartUri partUri);

			void RemoveAt([In] uint index);

			void SetAt([In] uint index, [In] IOpcPartUri partUri);
		}

		[ComImport, Guid("37D38BB6-3EE9-4110-9312-14B194163337"), InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
		public interface IXpsOMPath : IXpsOMVisual
		{
			IXpsOMPath Clone();

			string GetAccessibilityLongDescription();

			string GetAccessibilityShortDescription();

			IXpsOMBrush GetFillBrush();

			IXpsOMBrush GetFillBrushLocal();

			string GetFillBrushLookup();

			IXpsOMGeometry GetGeometry();

			IXpsOMGeometry GetGeometryLocal();

			string GetGeometryLookup();

			int GetSnapsToPixels();

			IXpsOMBrush GetStrokeBrush();

			IXpsOMBrush GetStrokeBrushLocal();

			string GetStrokeBrushLookup();

			XPS_DASH_CAP GetStrokeDashCap();

			IXpsOMDashCollection GetStrokeDashes();

			float GetStrokeDashOffset();

			XPS_LINE_CAP GetStrokeEndLineCap();

			XPS_LINE_JOIN GetStrokeLineJoin();

			float GetStrokeMiterLimit();

			XPS_LINE_CAP GetStrokeStartLineCap();

			float GetStrokeThickness();

			void SetAccessibilityLongDescription([In] string longDescription);

			void SetAccessibilityShortDescription([In] string shortDescription);

			void SetFillBrushLocal([In] IXpsOMBrush brush);

			void SetFillBrushLookup([In] string lookup);

			void SetGeometryLocal([In] IXpsOMGeometry geometry);

			void SetGeometryLookup([In] string lookup);

			void SetSnapsToPixels([In] int snapsToPixels);

			void SetStrokeBrushLocal([In] IXpsOMBrush brush);

			void SetStrokeBrushLookup([In] string lookup);

			void SetStrokeDashCap([In][ComAliasName("System.Windows.Xps.Serialization.RCW.XPS_DASH_CAP")] XPS_DASH_CAP strokeDashCap);

			void SetStrokeDashOffset([In] float strokeDashOffset);

			void SetStrokeEndLineCap([In][ComAliasName("System.Windows.Xps.Serialization.RCW.XPS_LINE_CAP")] XPS_LINE_CAP strokeEndLineCap);

			void SetStrokeLineJoin([In][ComAliasName("System.Windows.Xps.Serialization.RCW.XPS_LINE_JOIN")] XPS_LINE_JOIN strokeLineJoin);

			void SetStrokeMiterLimit([In] float strokeMiterLimit);

			void SetStrokeStartLineCap([In][ComAliasName("System.Windows.Xps.Serialization.RCW.XPS_LINE_CAP")] XPS_LINE_CAP strokeStartLineCap);

			void SetStrokeThickness([In] float strokeThickness);
		}

		[ComImport, Guid("E7FF32D2-34AA-499B-BBE9-9CD4EE6C59F7"), InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
		public interface IXpsOMPrintTicketResource : IXpsOMResource
		{
			[MethodImpl(MethodImplOptions.InternalCall)]
			[return: MarshalAs(UnmanagedType.Interface)]
			new IOpcPartUri GetPartName();

			[MethodImpl(MethodImplOptions.InternalCall)]
			new void SetPartName([MarshalAs(UnmanagedType.Interface)] [In] IOpcPartUri partUri);

			[MethodImpl(MethodImplOptions.InternalCall)]
			[return: MarshalAs(UnmanagedType.Interface)]
			IStream GetStream();

			[MethodImpl(MethodImplOptions.InternalCall)]
			void SetContent([MarshalAs(UnmanagedType.Interface)] [In] IStream sourceStream, [MarshalAs(UnmanagedType.Interface)] [In] IOpcPartUri partName);
		}

		[ComImport, Guid("75F207E5-08BF-413C-96B1-B82B4064176B"), InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
		public interface IXpsOMRadialGradientBrush : IXpsOMGradientBrush
		{
			IXpsOMRadialGradientBrush Clone();

			XPS_POINT GetCenter();

			XPS_POINT GetGradientOrigin();

			XPS_SIZE GetRadiiSizes();

			void SetCenter([In][ComAliasName("System.Windows.Xps.Serialization.RCW.XPS_POINT")] ref XPS_POINT center);

			void SetGradientOrigin([In][ComAliasName("System.Windows.Xps.Serialization.RCW.XPS_POINT")] ref XPS_POINT origin);

			void SetRadiiSizes([In][ComAliasName("System.Windows.Xps.Serialization.RCW.XPS_SIZE")] ref XPS_SIZE radiiSizes);
		}

		[ComImport, Guid("C9BD7CD4-E16A-4BF8-8C84-C950AF7A3061"), InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
		public interface IXpsOMRemoteDictionaryResource : IXpsOMResource
		{
			IXpsOMDictionary GetDictionary();

			void SetDictionary([In] IXpsOMDictionary dictionary);
		}

		[ComImport, Guid("5C38DB61-7FEC-464A-87BD-41E3BEF018BE"), InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
		public interface IXpsOMRemoteDictionaryResourceCollection
		{
			void Append([In] IXpsOMRemoteDictionaryResource @object);

			IXpsOMRemoteDictionaryResource GetAt([In] uint index);

			IXpsOMRemoteDictionaryResource GetByPartName([In] IOpcPartUri partName);

			uint GetCount();

			void InsertAt([In] uint index, [In] IXpsOMRemoteDictionaryResource @object);

			void RemoveAt([In] uint index);

			void SetAt([In] uint index, [In] IXpsOMRemoteDictionaryResource @object);
		}

		[ComImport, Guid("DA2AC0A2-73A2-4975-AD14-74097C3FF3A5"), InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
		public interface IXpsOMResource : IXpsOMPart
		{
		}

		[ComImport, Guid("7137398F-2FC1-454D-8C6A-2C3115A16ECE"), InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
		public interface IXpsOMShareable
		{
			object GetOwner();

			XPS_OBJECT_TYPE GetType();
		}

		[ComImport, Guid("4776AD35-2E04-4357-8743-EBF6C171A905"), InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
		public interface IXpsOMSignatureBlockResource : IXpsOMResource
		{
			[MethodImpl(MethodImplOptions.InternalCall)]
			[return: MarshalAs(UnmanagedType.Interface)]
			new IOpcPartUri GetPartName();

			[MethodImpl(MethodImplOptions.InternalCall)]
			new void SetPartName([MarshalAs(UnmanagedType.Interface)] [In] IOpcPartUri partUri);

			[MethodImpl(MethodImplOptions.InternalCall)]
			[return: MarshalAs(UnmanagedType.Interface)]
			IXpsOMDocument GetOwner();

			[MethodImpl(MethodImplOptions.InternalCall)]
			[return: MarshalAs(UnmanagedType.Interface)]
			IStream GetStream();

			[MethodImpl(MethodImplOptions.InternalCall)]
			void SetContent([MarshalAs(UnmanagedType.Interface)] [In] IStream sourceStream, [MarshalAs(UnmanagedType.Interface)] [In] IOpcPartUri partName);
		}

		[ComImport, Guid("AB8F5D8E-351B-4D33-AAED-FA56F0022931"), InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
		public interface IXpsOMSignatureBlockResourceCollection
		{
			void Append([In] IXpsOMSignatureBlockResource signatureBlockResource);

			IXpsOMSignatureBlockResource GetAt([In] uint index);

			IXpsOMSignatureBlockResource GetByPartName([In] IOpcPartUri partName);

			uint GetCount();

			void InsertAt([In] uint index, [In] IXpsOMSignatureBlockResource signatureBlockResource);

			void RemoveAt([In] uint index);

			void SetAt([In] uint index, [In] IXpsOMSignatureBlockResource signatureBlockResource);
		}

		[ComImport, Guid("A06F9F05-3BE9-4763-98A8-094FC672E488"), InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
		public interface IXpsOMSolidColorBrush : IXpsOMBrush
		{
			IXpsOMSolidColorBrush Clone();

			IXpsOMColorProfileResource GetColor([ComAliasName("System.Windows.Xps.Serialization.RCW.XPS_COLOR")] out XPS_COLOR color);

			void SetColor([In][ComAliasName("System.Windows.Xps.Serialization.RCW.XPS_COLOR")] ref XPS_COLOR color, [In] IXpsOMColorProfileResource colorProfile);
		}

		[ComImport, Guid("C2B3CA09-0473-4282-87AE-1780863223F0"), InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
		public interface IXpsOMStoryFragmentsResource : IXpsOMResource
		{
			[MethodImpl(MethodImplOptions.InternalCall)]
			[return: MarshalAs(UnmanagedType.Interface)]
			new IOpcPartUri GetPartName();

			[MethodImpl(MethodImplOptions.InternalCall)]
			new void SetPartName([MarshalAs(UnmanagedType.Interface)] [In] IOpcPartUri partUri);

			[MethodImpl(MethodImplOptions.InternalCall)]
			[return: MarshalAs(UnmanagedType.Interface)]
			IXpsOMPageReference GetOwner();

			[MethodImpl(MethodImplOptions.InternalCall)]
			[return: MarshalAs(UnmanagedType.Interface)]
			IStream GetStream();

			[MethodImpl(MethodImplOptions.InternalCall)]
			void SetContent([MarshalAs(UnmanagedType.Interface)] [In] IStream sourceStream, [MarshalAs(UnmanagedType.Interface)] [In] IOpcPartUri partName);
		}

		[ComImport, Guid("15B873D5-1971-41E8-83A3-6578403064C7"), InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
		public interface IXpsOMThumbnailGenerator
		{
			IXpsOMImageResource GenerateThumbnail([In] IXpsOMPage page, [In][ComAliasName("System.Windows.Xps.Serialization.RCW.XPS_IMAGE_TYPE")] XPS_IMAGE_TYPE thumbnailType, [In][ComAliasName("System.Windows.Xps.Serialization.RCW.XPS_THUMBNAIL_SIZE")] XPS_THUMBNAIL_SIZE thumbnailSize, [In] IOpcPartUri imageResourcePartName);
		}

		[ComImport, Guid("0FC2328D-D722-4A54-B2EC-BE90218A789E"), InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
		public interface IXpsOMTileBrush : IXpsOMBrush
		{
			XPS_TILE_MODE GetTileMode();

			IXpsOMMatrixTransform GetTransform();

			IXpsOMMatrixTransform GetTransformLocal();

			string GetTransformLookup();

			XPS_RECT GetViewbox();

			XPS_RECT GetViewport();

			void SetTileMode([In][ComAliasName("System.Windows.Xps.Serialization.RCW.XPS_TILE_MODE")] XPS_TILE_MODE tileMode);

			void SetTransformLocal([In] IXpsOMMatrixTransform transform);

			void SetTransformLookup([In] string key);

			void SetViewbox([In][ComAliasName("System.Windows.Xps.Serialization.RCW.XPS_RECT")] ref XPS_RECT viewbox);

			void SetViewport([In][ComAliasName("System.Windows.Xps.Serialization.RCW.XPS_RECT")] ref XPS_RECT viewport);
		}

		[ComImport, Guid("BC3E7333-FB0B-4AF3-A819-0B4EAAD0D2FD"), InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
		public interface IXpsOMVisual : IXpsOMShareable
		{
			[MethodImpl(MethodImplOptions.InternalCall)]
			[return: MarshalAs(UnmanagedType.IUnknown)]
			new object GetOwner();

			[MethodImpl(MethodImplOptions.InternalCall)]
			[return: ComAliasName("MSXPS.XPS_OBJECT_TYPE")]
			new XPS_OBJECT_TYPE GetType();

			[MethodImpl(MethodImplOptions.InternalCall)]
			[return: MarshalAs(UnmanagedType.Interface)]
			IXpsOMMatrixTransform GetTransform();

			[MethodImpl(MethodImplOptions.InternalCall)]
			[return: MarshalAs(UnmanagedType.Interface)]
			IXpsOMMatrixTransform GetTransformLocal();

			[MethodImpl(MethodImplOptions.InternalCall)]
			void SetTransformLocal([MarshalAs(UnmanagedType.Interface)] [In] IXpsOMMatrixTransform matrixTransform);

			[MethodImpl(MethodImplOptions.InternalCall)]
			[return: MarshalAs(UnmanagedType.LPWStr)]
			string GetTransformLookup();

			[MethodImpl(MethodImplOptions.InternalCall)]
			void SetTransformLookup([MarshalAs(UnmanagedType.LPWStr)] [In] string key);

			[MethodImpl(MethodImplOptions.InternalCall)]
			[return: MarshalAs(UnmanagedType.Interface)]
			IXpsOMGeometry GetClipGeometry();

			[MethodImpl(MethodImplOptions.InternalCall)]
			[return: MarshalAs(UnmanagedType.Interface)]
			IXpsOMGeometry GetClipGeometryLocal();

			[MethodImpl(MethodImplOptions.InternalCall)]
			void SetClipGeometryLocal([MarshalAs(UnmanagedType.Interface)] [In] IXpsOMGeometry clipGeometry);

			[MethodImpl(MethodImplOptions.InternalCall)]
			[return: MarshalAs(UnmanagedType.LPWStr)]
			string GetClipGeometryLookup();

			[MethodImpl(MethodImplOptions.InternalCall)]
			void SetClipGeometryLookup([MarshalAs(UnmanagedType.LPWStr)] [In] string key);

			[MethodImpl(MethodImplOptions.InternalCall)]
			float GetOpacity();

			[MethodImpl(MethodImplOptions.InternalCall)]
			void SetOpacity([In] float opacity);

			[MethodImpl(MethodImplOptions.InternalCall)]
			[return: MarshalAs(UnmanagedType.Interface)]
			IXpsOMBrush GetOpacityMaskBrush();

			[MethodImpl(MethodImplOptions.InternalCall)]
			[return: MarshalAs(UnmanagedType.Interface)]
			IXpsOMBrush GetOpacityMaskBrushLocal();

			[MethodImpl(MethodImplOptions.InternalCall)]
			void SetOpacityMaskBrushLocal([MarshalAs(UnmanagedType.Interface)] [In] IXpsOMBrush opacityMaskBrush);

			[MethodImpl(MethodImplOptions.InternalCall)]
			[return: MarshalAs(UnmanagedType.LPWStr)]
			string GetOpacityMaskBrushLookup();

			[MethodImpl(MethodImplOptions.InternalCall)]
			void SetOpacityMaskBrushLookup([MarshalAs(UnmanagedType.LPWStr)] [In] string key);

			[MethodImpl(MethodImplOptions.InternalCall)]
			[return: MarshalAs(UnmanagedType.LPWStr)]
			string GetName();

			[MethodImpl(MethodImplOptions.InternalCall)]
			void SetName([MarshalAs(UnmanagedType.LPWStr)] [In] string name);

			[MethodImpl(MethodImplOptions.InternalCall)]
			int GetIsHyperlinkTarget();

			[MethodImpl(MethodImplOptions.InternalCall)]
			void SetIsHyperlinkTarget([In] int isHyperlink);

			[MethodImpl(MethodImplOptions.InternalCall)]
			[return: MarshalAs(UnmanagedType.Interface)]
			IUri GetHyperlinkNavigateUri();

			[MethodImpl(MethodImplOptions.InternalCall)]
			void SetHyperlinkNavigateUri([MarshalAs(UnmanagedType.Interface)] [In] IUri hyperlinkUri);

			[MethodImpl(MethodImplOptions.InternalCall)]
			[return: MarshalAs(UnmanagedType.LPWStr)]
			string GetLanguage();

			[MethodImpl(MethodImplOptions.InternalCall)]
			void SetLanguage([MarshalAs(UnmanagedType.LPWStr)] [In] string language);
		}

		[ComImport, Guid("97E294AF-5B37-46B4-8057-874D2F64119B"), InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
		public interface IXpsOMVisualBrush : IXpsOMTileBrush
		{
			IXpsOMVisualBrush Clone();

			IXpsOMVisual GetVisual();

			IXpsOMVisual GetVisualLocal();

			string GetVisualLookup();

			void SetVisualLocal([In] IXpsOMVisual visual);

			void SetVisualLookup([In] string lookup);
		}

		[ComImport, Guid("94D8ABDE-AB91-46A8-82B7-F5B05EF01A96"), InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
		public interface IXpsOMVisualCollection
		{
			[MethodImpl(MethodImplOptions.InternalCall)]
			uint GetCount();

			[MethodImpl(MethodImplOptions.InternalCall)]
			[return: MarshalAs(UnmanagedType.Interface)]
			IXpsOMVisual GetAt([In] uint index);

			[MethodImpl(MethodImplOptions.InternalCall)]
			void InsertAt([In] uint index, [MarshalAs(UnmanagedType.Interface)] [In] IXpsOMVisual @object);

			[MethodImpl(MethodImplOptions.InternalCall)]
			void RemoveAt([In] uint index);

			[MethodImpl(MethodImplOptions.InternalCall)]
			void SetAt([In] uint index, [MarshalAs(UnmanagedType.Interface)] [In] IXpsOMVisual @object);

			[MethodImpl(MethodImplOptions.InternalCall)]
			void Append([MarshalAs(UnmanagedType.Interface)] [In] IXpsOMVisual @object);
		}

		[CoClass(typeof(XpsOMThumbnailGeneratorClass))]
		[ComImport, Guid("15B873D5-1971-41E8-83A3-6578403064C7")]
		public interface XpsOMThumbnailGenerator : IXpsOMThumbnailGenerator
		{
		}

		[StructLayout(LayoutKind.Sequential, Pack = 4)]
		public struct XPS_COLOR
		{
			public XPS_COLOR_TYPE colorType;

			public XPS_COLOR_TYPE_UNION value;
		}

		[ComConversionLoss]
		[StructLayout(LayoutKind.Explicit, Pack = 4, Size = 40)]
		public struct XPS_COLOR_TYPE_UNION
		{
			[FieldOffset(0)]
			public XPS_SRGB_COLOR sRGB;

			[FieldOffset(0)]
			public XPS_SCRGB_COLOR scRGB;
		}

		public struct XPS_DASH
		{
			public float gap;
			public float length;
		}

		public struct XPS_GLYPH_INDEX
		{
			public float advanceWidth;
			public float horizontalOffset;
			public int index;
			public float verticalOffset;
		}

		public struct XPS_GLYPH_MAPPING
		{
			public ushort glyphIndicesLength;
			public uint glyphIndicesStart;
			public ushort unicodeStringLength;
			public uint unicodeStringStart;
		}

		public struct XPS_MATRIX
		{
			public float m11;

			public float m12;

			public float m21;

			public float m22;

			public float m31;

			public float m32;
		}

		public struct XPS_POINT
		{
			public float x;

			public float y;
		}

		public struct XPS_RECT
		{
			public float height;
			public float width;
			public float x;

			public float y;
		}

		[StructLayout(LayoutKind.Sequential, Pack = 4)]
		public struct XPS_SCRGB_COLOR
		{
			public float alpha;

			public float red;

			public float green;

			public float blue;
		}

		public struct XPS_SIZE
		{
			public float height;
			public float width;
		}

		[StructLayout(LayoutKind.Sequential, Pack = 1)]
		public struct XPS_SRGB_COLOR
		{
			public byte alpha;

			public byte red;

			public byte green;

			public byte blue;
		}

		[ClassInterface(ClassInterfaceType.None)]
		[ComImport, Guid("7E4A23E2-B969-4761-BE35-1A8CED58E323")]
		[TypeLibType(TypeLibTypeFlags.FCanCreate)]
		public class XpsOMThumbnailGeneratorClass : IXpsOMThumbnailGenerator, XpsOMThumbnailGenerator
		{
			[MethodImpl(MethodImplOptions.InternalCall)]
			[return: MarshalAs(UnmanagedType.Interface)]
			public virtual extern IXpsOMImageResource GenerateThumbnail([In] IXpsOMPage page, [In][ComAliasName("System.Windows.Xps.Serialization.RCW.XPS_IMAGE_TYPE")] XPS_IMAGE_TYPE thumbnailType, [In][ComAliasName("System.Windows.Xps.Serialization.RCW.XPS_THUMBNAIL_SIZE")] XPS_THUMBNAIL_SIZE thumbnailSize, [In] IOpcPartUri imageResourcePartName);
		}
	}
}