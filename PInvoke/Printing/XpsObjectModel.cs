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
			/// <summary>Gets the <c>IUnknown</c> interface of the parent.</summary>
			/// <returns>A pointer to the <c>IUnknown</c> interface of the parent.</returns>
			// https://docs.microsoft.com/en-us/windows/win32/api/xpsobjectmodel/nf-xpsobjectmodel-ixpsomshareable-getowner
			// HRESULT GetOwner( IUnknown **owner );
			[return: MarshalAs(UnmanagedType.IUnknown)]
			new object GetOwner();

			/// <summary>Gets the object type of the interface.</summary>
			/// <returns>The XPS_OBJECT_TYPE value that describes the interface that is derived from IXpsOMShareable.</returns>
			// https://docs.microsoft.com/en-us/windows/win32/api/xpsobjectmodel/nf-xpsobjectmodel-ixpsomshareable-gettype
			// HRESULT GetType( XPS_OBJECT_TYPE *type );
			new XPS_OBJECT_TYPE GetType();

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
			/// <summary>Gets the <c>IUnknown</c> interface of the parent.</summary>
			/// <returns>A pointer to the <c>IUnknown</c> interface of the parent.</returns>
			// https://docs.microsoft.com/en-us/windows/win32/api/xpsobjectmodel/nf-xpsobjectmodel-ixpsomshareable-getowner
			// HRESULT GetOwner( IUnknown **owner );
			[return: MarshalAs(UnmanagedType.IUnknown)]
			new object GetOwner();

			/// <summary>Gets the object type of the interface.</summary>
			/// <returns>The XPS_OBJECT_TYPE value that describes the interface that is derived from IXpsOMShareable.</returns>
			// https://docs.microsoft.com/en-us/windows/win32/api/xpsobjectmodel/nf-xpsobjectmodel-ixpsomshareable-gettype
			// HRESULT GetType( XPS_OBJECT_TYPE *type );
			new XPS_OBJECT_TYPE GetType();

			/// <summary>Gets a pointer to the IXpsOMMatrixTransform interface that contains the visual's resolved matrix transform.</summary>
			/// <returns>
			/// <para>A pointer to the IXpsOMMatrixTransform interface that contains the visual's resolved matrix transform. If a matrix transform has not been set, a <c>NULL</c> pointer is returned.</para>
			/// <para>The value that is returned in this parameter depends on which method has most recently been called to set the transform.</para>
			/// <list type="table">
			/// <listheader>
			/// <term>Most recent method called</term>
			/// <term>Object that is returned in matrixTransform</term>
			/// </listheader>
			/// <item>
			/// <term>SetTransformLocal</term>
			/// <term>The local transform that is set by SetTransformLocal.</term>
			/// </item>
			/// <item>
			/// <term>SetTransformLookup</term>
			/// <term>The shared transform that gets retrieved, with a lookup key that matches the key that is set by SetTransformLookup, from the resource directory.</term>
			/// </item>
			/// <item>
			/// <term>Neither SetTransformLocal nor SetTransformLookup has been called yet.</term>
			/// <term>NULL pointer.</term>
			/// </item>
			/// </list>
			/// </returns>
			// https://docs.microsoft.com/en-us/windows/win32/api/xpsobjectmodel/nf-xpsobjectmodel-ixpsomvisual-gettransform
			// HRESULT GetTransform( IXpsOMMatrixTransform **matrixTransform );
			[MethodImpl(MethodImplOptions.InternalCall)]
			new IXpsOMMatrixTransform GetTransform();

			/// <summary>Gets a pointer to the IXpsOMMatrixTransform interface that contains the local, unshared, resolved matrix transform for the visual.</summary>
			/// <returns>
			/// <para>A pointer to the IXpsOMMatrixTransform interface that contains the local, unshared, resolved matrix transform for the visual. If a matrix transform lookup key has not been set, or if a local matrix transform has been set, a <c>NULL</c> pointer is returned.</para>
			/// <list type="table">
			/// <listheader>
			/// <term>Most recent method called</term>
			/// <term>Object that is returned in matrixTransform</term>
			/// </listheader>
			/// <item>
			/// <term>SetTransformLocal</term>
			/// <term>The local transform that is set by SetTransformLocal.</term>
			/// </item>
			/// <item>
			/// <term>SetTransformLookup</term>
			/// <term>NULL pointer.</term>
			/// </item>
			/// <item>
			/// <term>Neither SetTransformLocal nor SetTransformLookup has been called yet.</term>
			/// <term>NULL pointer.</term>
			/// </item>
			/// </list>
			/// </returns>
			// https://docs.microsoft.com/en-us/windows/win32/api/xpsobjectmodel/nf-xpsobjectmodel-ixpsomvisual-gettransformlocal
			// HRESULT GetTransformLocal( IXpsOMMatrixTransform **matrixTransform );
			[MethodImpl(MethodImplOptions.InternalCall)]
			new IXpsOMMatrixTransform GetTransformLocal();

			/// <summary>
			/// Sets the local, unshared matrix transform.
			/// </summary>
			/// <param name="matrixTransform">A pointer to the IXpsOMMatrixTransform interface to be set as the local, unshared matrix transform. A <c>NULL</c> pointer releases the previously assigned transform.</param>
			/// <remarks>
			/// <para>After you call <c>SetTransformLocal</c>, the transform lookup key is released and GetTransformLookup returns a <c>NULL</c> pointer in the key parameter. The table that follows explains the relationship between the local and lookup values of this property.</para>
			/// <list type="table">
			///   <listheader>
			///     <term>Most recent method called</term>
			///     <term>Object that is returned in transform by GetTransform</term>
			///     <term>Object that is returned in matrixTransform by GetTransformLocal</term>
			///     <term>Object that is returned in key by GetTransformLookup</term>
			///   </listheader>
			///   <item>
			///     <term>SetTransformLocal (this method)</term>
			///     <term>The local transform that is set by SetTransformLocal.</term>
			///     <term>The local transform set by SetTransformLocal.</term>
			///     <term>NULL pointer.</term>
			///   </item>
			///   <item>
			///     <term>SetTransformLookup</term>
			///     <term>The shared transform that gets retrieved, with a lookup key that matches the key that is set by SetTransformLookup, from the resource directory.</term>
			///     <term>NULL pointer.</term>
			///     <term>The lookup key that is set by SetTransformLookup.</term>
			///   </item>
			///   <item>
			///     <term>Neither SetTransformLocal nor SetTransformLookup has been called yet.</term>
			///     <term>NULL pointer.</term>
			///     <term>NULL pointer.</term>
			///     <term>NULL pointer.</term>
			///   </item>
			/// </list>
			/// </remarks>
			// https://docs.microsoft.com/en-us/windows/win32/api/xpsobjectmodel/nf-xpsobjectmodel-ixpsomvisual-settransformlocal
			// HRESULT SetTransformLocal( IXpsOMMatrixTransform *matrixTransform );
			[MethodImpl(MethodImplOptions.InternalCall)]
			new void SetTransformLocal([In] IXpsOMMatrixTransform matrixTransform);

			/// <summary>Gets the lookup key name of the IXpsOMMatrixTransform interface in a resource dictionary that contains the resolved matrix transform for the visual.</summary>
			/// <returns>
			/// <para>The lookup key name for the IXpsOMMatrixTransform interface in a resource dictionary that contains the resolved matrix transform for the visual. If a matrix transform lookup key has not been set, or if a local matrix transform has been set, a <c>NULL</c> pointer is returned.</para>
			/// <list type="table">
			/// <listheader>
			/// <term>Most recent method called</term>
			/// <term>Object that is returned in key</term>
			/// </listheader>
			/// <item>
			/// <term>SetTransformLocal</term>
			/// <term>NULL pointer.</term>
			/// </item>
			/// <item>
			/// <term>SetTransformLookup</term>
			/// <term>The lookup key that is set by SetTransformLookup.</term>
			/// </item>
			/// <item>
			/// <term>Neither SetTransformLocal nor SetTransformLookup has been called yet.</term>
			/// <term>NULL pointer.</term>
			/// </item>
			/// </list>
			/// </returns>
			// https://docs.microsoft.com/en-us/windows/win32/api/xpsobjectmodel/nf-xpsobjectmodel-ixpsomvisual-gettransformlookup
			// HRESULT GetTransformLookup( LPWSTR *key );
			[MethodImpl(MethodImplOptions.InternalCall)]
			new SafeCoTaskMemString GetTransformLookup();

			/// <summary>
			/// Sets the lookup key name of a shared matrix transform in a resource dictionary.
			/// </summary>
			/// <param name="key">The lookup key name of the matrix transform in the dictionary.</param>
			/// <remarks>
			/// <para>After you call <c>SetTransformLookup</c>, the local transform is released and GetTransformLocal returns a <c>NULL</c> pointer in the matrixTransform parameter. The table that follows explains the relationship between the local and lookup values of this property.</para>
			/// <list type="table">
			///   <listheader>
			///     <term>Most recent method called</term>
			///     <term>Object that is returned in transform by GetTransform</term>
			///     <term>Object that is returned in matrixTransform by GetTransformLocal</term>
			///     <term>Object that is returned in key by GetTransformLookup</term>
			///   </listheader>
			///   <item>
			///     <term>SetTransformLocal</term>
			///     <term>The local transform that is set by SetTransformLocal.</term>
			///     <term>The local transform that is set by SetTransformLocal.</term>
			///     <term>NULL pointer.</term>
			///   </item>
			///   <item>
			///     <term>SetTransformLookup (this method)</term>
			///     <term>The shared transform that gets retrieved—with a lookup key that matches the key that is set by SetTransformLookup—from the resource directory.</term>
			///     <term>NULL pointer.</term>
			///     <term>The lookup key that is set by SetTransformLookup.</term>
			///   </item>
			///   <item>
			///     <term>Neither SetTransformLocal nor SetTransformLookup has been called yet.</term>
			///     <term>NULL pointer.</term>
			///     <term>NULL pointer.</term>
			///     <term>NULL pointer.</term>
			///   </item>
			/// </list>
			/// </remarks>
			// https://docs.microsoft.com/en-us/windows/win32/api/xpsobjectmodel/nf-xpsobjectmodel-ixpsomvisual-settransformlookup
			// HRESULT SetTransformLookup( LPCWSTR key );
			[MethodImpl(MethodImplOptions.InternalCall)]
			new void SetTransformLookup([In, MarshalAs(UnmanagedType.LPWStr)] string key);

			/// <summary>Gets a pointer to the IXpsOMGeometry interface that contains the resolved geometry of the visual's clipping region.</summary>
			/// <returns>
			/// <para>A pointer to the IXpsOMGeometry interface that contains the resolved geometry of the visual's clipping region. If the clip geometry has not been set, a <c>NULL</c> pointer is returned.</para>
			/// <para>The value that is returned in this parameter depends on which method has most recently been called to set the geometry.</para>
			/// <list type="table">
			/// <listheader>
			/// <term>Most recent method called</term>
			/// <term>Object that is returned in clipGeometry</term>
			/// </listheader>
			/// <item>
			/// <term>SetClipGeometryLocal</term>
			/// <term>The local clip geometry that is set by SetClipGeometryLocal.</term>
			/// </item>
			/// <item>
			/// <term>SetClipGeometryLookup</term>
			/// <term>The shared clip geometry that gets retrieved, with a lookup key that matches the key that is set by SetClipGeometryLookup, from the resource directory.</term>
			/// </item>
			/// <item>
			/// <term>Neither SetClipGeometryLocal nor SetClipGeometryLookup has been called yet.</term>
			/// <term>NULL pointer.</term>
			/// </item>
			/// </list>
			/// </returns>
			// https://docs.microsoft.com/en-us/windows/win32/api/xpsobjectmodel/nf-xpsobjectmodel-ixpsomvisual-getclipgeometry
			// HRESULT GetClipGeometry( IXpsOMGeometry **clipGeometry );
			[MethodImpl(MethodImplOptions.InternalCall)]
			new IXpsOMGeometry GetClipGeometry();

			/// <summary>Gets a pointer to the IXpsOMGeometry interface that contains the local, unshared geometry of the visual's clipping region.</summary>
			/// <returns>
			/// <para>A pointer to the IXpsOMGeometry interface that contains the local, unshared geometry of the visual's clipping region. If a clip geometry lookup key has been set, or if a local clip geometry has not been set, a <c>NULL</c> pointer is returned.</para>
			/// <list type="table">
			/// <listheader>
			/// <term>Most recent method called</term>
			/// <term>Object that is returned in clipGeometry</term>
			/// </listheader>
			/// <item>
			/// <term>SetClipGeometryLocal</term>
			/// <term>The local clip geometry that is set by SetClipGeometryLocal.</term>
			/// </item>
			/// <item>
			/// <term>SetClipGeometryLookup</term>
			/// <term>NULL pointer.</term>
			/// </item>
			/// <item>
			/// <term>Neither SetClipGeometryLocal nor SetClipGeometryLookup has been called yet.</term>
			/// <term>NULL pointer.</term>
			/// </item>
			/// </list>
			/// </returns>
			// https://docs.microsoft.com/en-us/windows/win32/api/xpsobjectmodel/nf-xpsobjectmodel-ixpsomvisual-getclipgeometrylocal
			// HRESULT GetClipGeometryLocal( IXpsOMGeometry **clipGeometry );
			[MethodImpl(MethodImplOptions.InternalCall)]
			new IXpsOMGeometry GetClipGeometryLocal();

			/// <summary>Sets the local, unshared clipping region for the visual.</summary>
			/// <param name="clipGeometry">A pointer to the IXpsOMGeometry interface to be set as the local, unshared clipping region for the visual. A <c>NULL</c> pointer releases the previously assigned geometry interface.</param>
			/// <remarks>
			/// <para>After you call <c>SetClipGeometryLocal</c>, the clip geometry lookup key is released and GetClipGeometryLookup returns a <c>NULL</c> pointer in the key parameter. The table that follows explains the relationship between the local and lookup values of this property.</para>
			/// <list type="table">
			/// <listheader>
			/// <term>Most recent method called</term>
			/// <term>Object that is returned in clipGeometry by GetClipGeometry</term>
			/// <term>Object that is returned in clipGeometry by GetClipGeometryLocal</term>
			/// <term>String that is returned in key by GetClipGeometryLookup</term>
			/// </listheader>
			/// <item>
			/// <term>SetClipGeometryLocal (this method)</term>
			/// <term>The local clip geometry that is set by SetClipGeometryLocal.</term>
			/// <term>The local clip geometry that is set by SetClipGeometryLocal.</term>
			/// <term>NULL pointer.</term>
			/// </item>
			/// <item>
			/// <term>SetClipGeometryLookup</term>
			/// <term>The shared clip geometry that gets retrieved, with a lookup key that matches the key that is set by SetClipGeometryLookup, from the resource directory.</term>
			/// <term>NULL pointer.</term>
			/// <term>The lookup key that is set by SetClipGeometryLookup.</term>
			/// </item>
			/// <item>
			/// <term>Neither SetClipGeometryLookup nor SetClipGeometryLocal has been called yet.</term>
			/// <term>NULL pointer.</term>
			/// <term>NULL pointer.</term>
			/// <term>NULL pointer.</term>
			/// </item>
			/// </list>
			/// </remarks>
			// https://docs.microsoft.com/en-us/windows/win32/api/xpsobjectmodel/nf-xpsobjectmodel-ixpsomvisual-setclipgeometrylocal
			// HRESULT SetClipGeometryLocal( IXpsOMGeometry *clipGeometry );
			[MethodImpl(MethodImplOptions.InternalCall)]
			new void SetClipGeometryLocal([In] IXpsOMGeometry clipGeometry);

			/// <summary>Gets the lookup key for the IXpsOMGeometry interface in a resource dictionary that contains the visual's clipping region.</summary>
			/// <returns>
			/// <para>The lookup key for the IXpsOMGeometry interface in a resource dictionary that contains the visual's clipping region. If a lookup key for the clip geometry has not been set, or if a local clip geometry has been set, a <c>NULL</c> pointer is returned.</para>
			/// <list type="table">
			/// <listheader>
			/// <term>Most recent method called</term>
			/// <term>Lookup key string that is returned in key</term>
			/// </listheader>
			/// <item>
			/// <term>SetClipGeometryLocal</term>
			/// <term>NULL pointer.</term>
			/// </item>
			/// <item>
			/// <term>SetClipGeometryLookup</term>
			/// <term>The lookup key that is set by SetClipGeometryLookup.</term>
			/// </item>
			/// <item>
			/// <term>Neither SetClipGeometryLocal nor SetClipGeometryLookup has been called yet.</term>
			/// <term>NULL pointer.</term>
			/// </item>
			/// </list>
			/// </returns>
			// https://docs.microsoft.com/en-us/windows/win32/api/xpsobjectmodel/nf-xpsobjectmodel-ixpsomvisual-getclipgeometrylookup
			// HRESULT GetClipGeometryLookup( LPWSTR *key );
			[MethodImpl(MethodImplOptions.InternalCall)]
			new SafeCoTaskMemString GetClipGeometryLookup();

			/// <summary>Sets the lookup key name of a shared clip geometry in a resource dictionary.</summary>
			/// <param name="key">The lookup key name of the clip geometry in the dictionary. A <c>NULL</c> pointer clears the previously assigned key name.</param>
			/// <remarks>
			/// <para>After you call <c>SetClipGeometryLookup</c>, the local clip geometry is released and GetClipGeometryLocal returns a <c>NULL</c> pointer in the clipGeometry parameter. The table that follows explains the relationship between the local and lookup values of this property.</para>
			/// <list type="table">
			/// <listheader>
			/// <term>Most recent method called</term>
			/// <term>Object that is returned in clipGeometry by GetClipGeometry</term>
			/// <term>Object that is returned in clipGeometry by GetClipGeometryLocal</term>
			/// <term>String that is returned in key by GetClipGeometryLookup</term>
			/// </listheader>
			/// <item>
			/// <term>SetClipGeometryLocal</term>
			/// <term>The local clip geometry that is set by SetClipGeometryLocal.</term>
			/// <term>The local clip geometry that is set by SetClipGeometryLocal.</term>
			/// <term>NULL pointer.</term>
			/// </item>
			/// <item>
			/// <term>SetClipGeometryLookup (this method)</term>
			/// <term>The shared clip geometry that gets retrieved, with a lookup key that matches the key that is set by SetClipGeometryLookup, from the resource directory.</term>
			/// <term>NULL pointer.</term>
			/// <term>The lookup key that is set by SetClipGeometryLookup.</term>
			/// </item>
			/// <item>
			/// <term>Neither SetClipGeometryLookup nor SetClipGeometryLocal has been called yet.</term>
			/// <term>NULL pointer.</term>
			/// <term>NULL pointer.</term>
			/// <term>NULL pointer.</term>
			/// </item>
			/// </list>
			/// </remarks>
			// https://docs.microsoft.com/en-us/windows/win32/api/xpsobjectmodel/nf-xpsobjectmodel-ixpsomvisual-setclipgeometrylookup
			// HRESULT SetClipGeometryLookup( LPCWSTR key );
			[MethodImpl(MethodImplOptions.InternalCall)]
			new void SetClipGeometryLookup([In, MarshalAs(UnmanagedType.LPWStr)] string key);

			/// <summary>Gets the opacity value of this visual.</summary>
			/// <returns>The opacity value.</returns>
			// https://docs.microsoft.com/en-us/windows/win32/api/xpsobjectmodel/nf-xpsobjectmodel-ixpsomvisual-getopacity
			// HRESULT GetOpacity( FLOAT *opacity );
			[MethodImpl(MethodImplOptions.InternalCall)]
			new float GetOpacity();

			/// <summary>Sets the opacity value of the visual.</summary>
			/// <param name="opacity">
			/// <para>The opacity value to be set for the visual.</para>
			/// <para>The range of allowed values for this parameter is 0.0 to 1.0; with 0.0 the visual is completely transparent, and with 1.0 it is completely opaque.</para>
			/// </param>
			// https://docs.microsoft.com/en-us/windows/win32/api/xpsobjectmodel/nf-xpsobjectmodel-ixpsomvisual-setopacity
			// HRESULT SetOpacity( FLOAT opacity );
			[MethodImpl(MethodImplOptions.InternalCall)]
			new void SetOpacity([In] float opacity);

			/// <summary>Gets a pointer to the IXpsOMBrush interface of the visual's opacity mask brush.</summary>
			/// <returns>
			/// <para>A pointer to the IXpsOMBrush interface of the visual's opacity mask brush. If an opacity mask brush has not been set for this visual, a <c>NULL</c> pointer is returned.</para>
			/// <para>The value that is returned in this parameter depends on which method has most recently been called to set the brush.</para>
			/// <list type="table">
			/// <listheader>
			/// <term>Most recent method called</term>
			/// <term>Object that is returned in opacityMaskBrush</term>
			/// </listheader>
			/// <item>
			/// <term>SetOpacityMaskBrushLocal</term>
			/// <term>The local opacity mask brush that is set by SetOpacityMaskBrushLocal.</term>
			/// </item>
			/// <item>
			/// <term>SetOpacityMaskBrushLookup</term>
			/// <term>The shared opacity mask brush that gets retrieved, with a lookup key that matches the key that is set by SetOpacityMaskBrushLookup, from the resource directory.</term>
			/// </item>
			/// <item>
			/// <term>Neither SetOpacityMaskBrushLocal nor SetOpacityMaskBrushLookup has been called yet.</term>
			/// <term>NULL pointer.</term>
			/// </item>
			/// </list>
			/// </returns>
			// https://docs.microsoft.com/en-us/windows/win32/api/xpsobjectmodel/nf-xpsobjectmodel-ixpsomvisual-getopacitymaskbrush
			// HRESULT GetOpacityMaskBrush( IXpsOMBrush **opacityMaskBrush );
			[MethodImpl(MethodImplOptions.InternalCall)]
			new IXpsOMBrush GetOpacityMaskBrush();

			/// <summary>Gets the local, unshared opacity mask brush for the visual.</summary>
			/// <returns>
			/// <para>A pointer to the IXpsOMBrush interface of the visual's opacity mask brush. If an opacity mask brush lookup key has been set, or if a local opacity mask brush has not been set, a <c>NULL</c> pointer is returned.</para>
			/// <list type="table">
			/// <listheader>
			/// <term>Most recent method called</term>
			/// <term>Object that is returned in opacityMaskBrush</term>
			/// </listheader>
			/// <item>
			/// <term>SetOpacityMaskBrushLocal</term>
			/// <term>The local opacity mask brush that is set by SetOpacityMaskBrushLocal.</term>
			/// </item>
			/// <item>
			/// <term>SetOpacityMaskBrushLookup</term>
			/// <term>NULL pointer.</term>
			/// </item>
			/// <item>
			/// <term>Neither SetOpacityMaskBrushLocal nor SetOpacityMaskBrushLookup has been called yet.</term>
			/// <term>NULL pointer.</term>
			/// </item>
			/// </list>
			/// </returns>
			// https://docs.microsoft.com/en-us/windows/win32/api/xpsobjectmodel/nf-xpsobjectmodel-ixpsomvisual-getopacitymaskbrushlocal
			// HRESULT GetOpacityMaskBrushLocal( IXpsOMBrush **opacityMaskBrush );
			[MethodImpl(MethodImplOptions.InternalCall)]
			new IXpsOMBrush GetOpacityMaskBrushLocal();

			/// <summary>
			/// Sets the IXpsOMBrush interface pointer as the local, unshared opacity mask brush.
			/// </summary>
			/// <param name="opacityMaskBrush">A pointer to the IXpsOMBrush interface to be set as the local, unshared opacity mask brush. A <c>NULL</c> pointer clears the previously assigned opacity mask brush.</param>
			/// <remarks>
			/// <para>After you call <c>SetOpacityMaskBrushLocal</c>, the opacity mask brush lookup key is released and GetOpacityMaskBrushLookup returns a <c>NULL</c> pointer in the key parameter. The table that follows explains the relationship between the local and lookup values of this property.</para>
			/// <list type="table">
			///   <listheader>
			///     <term>Most recent method called</term>
			///     <term>Object that is returned in opacityMaskBrush by GetOpacityMaskBrush</term>
			///     <term>Object that is returned in opacityMaskBrush by GetOpacityMaskBrushLocal</term>
			///     <term>String that is returned in key by GetOpacityMaskBrushLookup</term>
			///   </listheader>
			///   <item>
			///     <term>SetOpacityMaskBrushLocal (this method)</term>
			///     <term>The local opacity mask brush that is set by SetOpacityMaskBrushLocal.</term>
			///     <term>The local opacity mask brush that is set by SetOpacityMaskBrushLocal.</term>
			///     <term>NULL pointer.</term>
			///   </item>
			///   <item>
			///     <term>SetOpacityMaskBrushLookup</term>
			///     <term>The shared opacity mask brush that gets retrieved, with a lookup key that matches the key that is set by SetOpacityMaskBrushLookup, from the resource directory.</term>
			///     <term>NULL pointer.</term>
			///     <term>The lookup key that is set by SetOpacityMaskBrushLookup.</term>
			///   </item>
			///   <item>
			///     <term>Neither SetOpacityMaskBrushLocal nor SetOpacityMaskBrushLookup has been called yet.</term>
			///     <term>NULL pointer.</term>
			///     <term>NULL pointer.</term>
			///     <term>NULL pointer.</term>
			///   </item>
			/// </list>
			/// </remarks>
			// https://docs.microsoft.com/en-us/windows/win32/api/xpsobjectmodel/nf-xpsobjectmodel-ixpsomvisual-setopacitymaskbrushlocal
			// HRESULT SetOpacityMaskBrushLocal( IXpsOMBrush *opacityMaskBrush );
			[MethodImpl(MethodImplOptions.InternalCall)]
			new void SetOpacityMaskBrushLocal([In] IXpsOMBrush opacityMaskBrush);

			/// <summary>Gets the name of the lookup key of the shared opacity mask brush in a resource dictionary.</summary>
			/// <returns>
			/// <para>The name of the lookup key of the shared opacity mask brush in a resource dictionary. If the lookup key of an opacity mask brush has not been set, or if a local opacity mask brush has been set, a <c>NULL</c> pointer is returned.</para>
			/// <list type="table">
			/// <listheader>
			/// <term>Most recent method called</term>
			/// <term>Object that is returned in key</term>
			/// </listheader>
			/// <item>
			/// <term>SetOpacityMaskBrushLocal</term>
			/// <term>NULL pointer.</term>
			/// </item>
			/// <item>
			/// <term>SetOpacityMaskBrushLookup</term>
			/// <term>The lookup key that is set by SetOpacityMaskBrushLookup.</term>
			/// </item>
			/// <item>
			/// <term>Neither SetOpacityMaskBrushLocal nor SetOpacityMaskBrushLookup has been called yet.</term>
			/// <term>NULL pointer.</term>
			/// </item>
			/// </list>
			/// </returns>
			// https://docs.microsoft.com/en-us/windows/win32/api/xpsobjectmodel/nf-xpsobjectmodel-ixpsomvisual-getopacitymaskbrushlookup
			// HRESULT GetOpacityMaskBrushLookup( LPWSTR *key );
			[MethodImpl(MethodImplOptions.InternalCall)]
			new SafeCoTaskMemString GetOpacityMaskBrushLookup();

			/// <summary>
			/// Sets the lookup key name of a shared opacity mask brush in a resource dictionary.
			/// </summary>
			/// <param name="key">The lookup key name of the opacity mask brush in the dictionary. A <c>NULL</c> pointer clears the previously assigned key name.</param>
			/// <remarks>
			/// <para>After you call <c>SetOpacityMaskBrushLookup</c>, the local opacity mask brush is released and GetOpacityMaskBrushLocal returns a <c>NULL</c> pointer in the opacityMaskBrush parameter. The table that follows explains the relationship between the local and lookup values of this property.</para>
			/// <list type="table">
			///   <listheader>
			///     <term>Most recent method called</term>
			///     <term>Object that is returned in opacityMaskBrush by GetOpacityMaskBrush</term>
			///     <term>Object that is returned in opacityMaskBrush by GetOpacityMaskBrushLocal</term>
			///     <term>String that is returned in key by GetOpacityMaskBrushLookup</term>
			///   </listheader>
			///   <item>
			///     <term>SetOpacityMaskBrushLocal</term>
			///     <term>The local opacity mask brush that is set by SetOpacityMaskBrushLocal.</term>
			///     <term>The local opacity mask brush that is set by SetOpacityMaskBrushLocal.</term>
			///     <term>NULL pointer.</term>
			///   </item>
			///   <item>
			///     <term>SetOpacityMaskBrushLookup (this method)</term>
			///     <term>The shared opacity mask brush that gets retrieved—with a lookup key that matches the key that is set by SetOpacityMaskBrushLookup—from the resource directory.</term>
			///     <term>NULL pointer.</term>
			///     <term>The lookup key that is set by SetOpacityMaskBrushLookup.</term>
			///   </item>
			///   <item>
			///     <term>Neither SetOpacityMaskBrushLocal nor SetOpacityMaskBrushLookup has been called yet.</term>
			///     <term>NULL pointer.</term>
			///     <term>NULL pointer.</term>
			///     <term>NULL pointer.</term>
			///   </item>
			/// </list>
			/// </remarks>
			// https://docs.microsoft.com/en-us/windows/win32/api/xpsobjectmodel/nf-xpsobjectmodel-ixpsomvisual-setopacitymaskbrushlookup
			// HRESULT SetOpacityMaskBrushLookup( LPCWSTR key );
			[MethodImpl(MethodImplOptions.InternalCall)]
			new void SetOpacityMaskBrushLookup([In, MarshalAs(UnmanagedType.LPWStr)] string key);

			/// <summary>Gets the <c>Name</c> property of the visual.</summary>
			/// <returns>The <c>Name</c> property string. If the <c>Name</c> property has not been set, a <c>NULL</c> pointer is returned.</returns>
			// https://docs.microsoft.com/en-us/windows/win32/api/xpsobjectmodel/nf-xpsobjectmodel-ixpsomvisual-getname
			// HRESULT GetName( LPWSTR *name );
			[MethodImpl(MethodImplOptions.InternalCall)]
			new SafeCoTaskMemString GetName();

			/// <summary>
			/// Sets the <c>Name</c> property of the visual.
			/// </summary>
			/// <param name="name">The name of the visual. A <c>NULL</c> pointer clears the <c>Name</c> property.</param>
			/// <remarks>
			/// <para>Names must be unique.</para>
			/// <para>Clearing the <c>Name</c> property by passing a <c>NULL</c> pointer in name sets the <c>IsHyperlinkTarget</c> property to <c>FALSE</c>.</para>
			/// </remarks>
			// https://docs.microsoft.com/en-us/windows/win32/api/xpsobjectmodel/nf-xpsobjectmodel-ixpsomvisual-setname
			// HRESULT SetName( LPCWSTR name );
			[MethodImpl(MethodImplOptions.InternalCall)]
			new void SetName([In, MarshalAs(UnmanagedType.LPWStr)] string name);

			/// <summary>Gets a value that indicates whether the visual is the target of a hyperlink.</summary>
			/// <returns>
			/// <para>The Boolean value that indicates whether the visual is the target of a hyperlink.</para>
			/// <list type="table">
			/// <listheader>
			/// <term>Value</term>
			/// <term>Meaning</term>
			/// </listheader>
			/// <item>
			/// <term>TRUE</term>
			/// <term>The visual is the target of a hyperlink.</term>
			/// </item>
			/// <item>
			/// <term>FALSE</term>
			/// <term>The visual is not the target of a hyperlink.</term>
			/// </item>
			/// </list>
			/// </returns>
			// https://docs.microsoft.com/en-us/windows/win32/api/xpsobjectmodel/nf-xpsobjectmodel-ixpsomvisual-getishyperlinktarget
			// HRESULT GetIsHyperlinkTarget( BOOL *isHyperlink );
			[MethodImpl(MethodImplOptions.InternalCall)]
			[return: MarshalAs(UnmanagedType.Bool)]
			new bool GetIsHyperlinkTarget();

			/// <summary>
			/// Specifies whether the visual is the target of a hyperlink.
			/// </summary>
			/// <param name="isHyperlink"><para>The Boolean value that specifies whether the visual is the target of a hyperlink.</para>
			/// <list type="table">
			///   <listheader>
			///     <term>Value</term>
			///     <term>Meaning</term>
			///   </listheader>
			///   <item>
			///     <term>TRUE</term>
			///     <term>The visual is the target of a hyperlink.</term>
			///   </item>
			///   <item>
			///     <term>FALSE</term>
			///     <term>The visual is not the target of a hyperlink.</term>
			///   </item>
			/// </list></param>
			/// <remarks>
			/// The visual must be named before it can be set as the target of a hyperlink.
			/// </remarks>
			// https://docs.microsoft.com/en-us/windows/win32/api/xpsobjectmodel/nf-xpsobjectmodel-ixpsomvisual-setishyperlinktarget
			// HRESULT SetIsHyperlinkTarget( BOOL isHyperlink );
			[MethodImpl(MethodImplOptions.InternalCall)]
			new void SetIsHyperlinkTarget([In, MarshalAs(UnmanagedType.Bool)] bool isHyperlink);

			/// <summary>Gets a pointer to the IUri interface to which this visual object links.</summary>
			/// <returns>A pointer to the IUri interface that contains the destination URI for the link. If a URI has not been set for this object, a <c>NULL</c> pointer is returned.</returns>
			// https://docs.microsoft.com/en-us/windows/win32/api/xpsobjectmodel/nf-xpsobjectmodel-ixpsomvisual-gethyperlinknavigateuri
			// HRESULT GetHyperlinkNavigateUri( IUri **hyperlinkUri );
			[MethodImpl(MethodImplOptions.InternalCall)]
			new IUri GetHyperlinkNavigateUri();

			/// <summary>
			/// Sets the destination URI of the visual's hyperlink.
			/// </summary>
			/// <param name="hyperlinkUri">The IUri interface that contains the destination URI of the visual's hyperlink.</param>
			/// <remarks>
			/// Setting an object's URI makes the object a hyperlink. When activated or clicked, the object will navigate to the destination that is specified by the URI in hyperlinkUri.
			/// </remarks>
			// https://docs.microsoft.com/en-us/windows/win32/api/xpsobjectmodel/nf-xpsobjectmodel-ixpsomvisual-sethyperlinknavigateuri
			// HRESULT SetHyperlinkNavigateUri( IUri *hyperlinkUri );
			[MethodImpl(MethodImplOptions.InternalCall)]
			new void SetHyperlinkNavigateUri([In] IUri hyperlinkUri);

			/// <summary>Gets the <c>Language</c> property of the visual and of its contents.</summary>
			/// <returns>The language string that specifies the language of the page. If a language has not been set, a <c>NULL</c> pointer is returned.</returns>
			/// <remarks>
			/// <para>The <c>Language</c> property that is set by this method specifies the language of the resource content.</para>
			/// <para>Internet Engineering Task Force (IETF) RFC 3066 specifies the recommended encoding for the <c>Language</c> property.</para>
			/// </remarks>
			// https://docs.microsoft.com/en-us/windows/win32/api/xpsobjectmodel/nf-xpsobjectmodel-ixpsomvisual-getlanguage
			// HRESULT GetLanguage( LPWSTR *language );
			[MethodImpl(MethodImplOptions.InternalCall)]
			new SafeCoTaskMemString GetLanguage();

			/// <summary>
			/// Sets the <c>Language</c> property of the visual.
			/// </summary>
			/// <param name="language">The language string that specifies the language of the visual and of its contents. A <c>NULL</c> pointer clears the <c>Language</c> property.</param>
			/// <remarks>
			/// The recommended encoding for the <c>Language</c> property is specified in Internet Engineering Task Force (IETF) RFC 3066r.
			/// </remarks>
			// https://docs.microsoft.com/en-us/windows/win32/api/xpsobjectmodel/nf-xpsobjectmodel-ixpsomvisual-setlanguage
			// HRESULT SetLanguage( LPCWSTR language );
			[MethodImpl(MethodImplOptions.InternalCall)]
			new void SetLanguage([In, MarshalAs(UnmanagedType.LPWStr)] string language);

			/// <summary>Gets a pointer to an IXpsOMVisualCollection interface that contains a collection of the visual objects in the canvas.</summary>
			/// <returns>The collection of the visual objects in the canvas. If no visual objects are attached to the canvas, an empty collection is returned.</returns>
			// https://docs.microsoft.com/en-us/windows/win32/api/xpsobjectmodel/nf-xpsobjectmodel-ixpsomcanvas-getvisuals
			// HRESULT GetVisuals( IXpsOMVisualCollection **visuals );
			IXpsOMVisualCollection GetVisuals();

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

			/// <summary>Gets a short textual description of the object's contents. This text is used by accessibility clients to describe the object.</summary>
			/// <returns>The short textual description of the object's contents. If this description is not set, a <c>NULL</c> pointer is returned.</returns>
			/// <remarks>
			/// <para>The property returned by this method corresponds to the <c>AutomationProperties.Name</c> attribute of the <c>Canvas</c> element in the document markup.</para>
			/// </remarks>
			// https://docs.microsoft.com/en-us/windows/win32/api/xpsobjectmodel/nf-xpsobjectmodel-ixpsomcanvas-getaccessibilityshortdescription
			// HRESULT GetAccessibilityShortDescription( LPWSTR *shortDescription );
			SafeCoTaskMemString GetAccessibilityShortDescription();

			/// <summary>Sets the short textual description of the object's contents. This text is used by accessibility clients to describe the object.</summary>
			/// <param name="shortDescription">The short textual description of the object's contents. A <c>NULL</c> pointer clears the previously assigned text.</param>
			/// <remarks>The property that is set by this method corresponds to the <c>AutomationProperties.HelpText</c> attribute of the <c>Canvas</c> element in the document markup.</remarks>
			// https://docs.microsoft.com/en-us/windows/win32/api/xpsobjectmodel/nf-xpsobjectmodel-ixpsomcanvas-setaccessibilityshortdescription
			// HRESULT SetAccessibilityShortDescription( LPCWSTR shortDescription );
			void SetAccessibilityShortDescription([In, MarshalAs(UnmanagedType.LPWStr)] string shortDescription);

			/// <summary>Gets the long (detailed) textual description of the object's contents. This text is used by accessibility clients to describe the object.</summary>
			/// <returns>The long (detailed) textual description of the object's contents. A <c>NULL</c> pointer is returned if this text has not been set.</returns>
			/// <remarks>
			/// <para>The property returned by this method corresponds to the <c>AutomationProperties.HelpText</c> attribute of the <c>Canvas</c> element in the document markup.</para>
			/// </remarks>
			// https://docs.microsoft.com/en-us/windows/win32/api/xpsobjectmodel/nf-xpsobjectmodel-ixpsomcanvas-getaccessibilitylongdescription
			// HRESULT GetAccessibilityLongDescription( LPWSTR *longDescription );
			SafeCoTaskMemString GetAccessibilityLongDescription();

			/// <summary>Sets the long (detailed) textual description of the object's contents. This text is used by accessibility clients to describe the object.</summary>
			/// <param name="longDescription">The long (detailed) textual description of the object's contents. A <c>NULL</c> pointer clears the previously assigned value.</param>
			/// <remarks>The property that is set by this method corresponds to the <c>AutomationProperties.HelpText</c> attribute of the <c>Canvas</c> element in the document markup.</remarks>
			// https://docs.microsoft.com/en-us/windows/win32/api/xpsobjectmodel/nf-xpsobjectmodel-ixpsomcanvas-setaccessibilitylongdescription
			// HRESULT SetAccessibilityLongDescription( LPCWSTR longDescription );
			void SetAccessibilityLongDescription([In, MarshalAs(UnmanagedType.LPWStr)] string longDescription);

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

			/// <summary>Makes a deep copy of the interface.</summary>
			/// <returns>
			/// A pointer to the copy of the interface.
			/// </returns>
			/// <remarks>The owner of the new interface is <c>NULL</c>.</remarks>
			// https://docs.microsoft.com/en-us/windows/win32/api/xpsobjectmodel/nf-xpsobjectmodel-ixpsomcanvas-clone
			// HRESULT Clone( IXpsOMCanvas **canvas );
			IXpsOMCanvas Clone();
		}

		/// <summary>Provides an IStream interface to a color profile resource.</summary>
		/// <remarks>The code example that follows illustrates how to create an instance of this interface.</remarks>
		// https://docs.microsoft.com/en-us/windows/win32/api/xpsobjectmodel/nn-xpsobjectmodel-ixpsomcolorprofileresource
		[PInvokeData("xpsobjectmodel.h", MSDNShortId = "8a344300-c3fc-4225-bfa5-d5d33798a094")]
		[ComImport, Guid("67BD7D69-1EEF-4BB1-B5E7-6F4F87BE8ABE"), InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
		public interface IXpsOMColorProfileResource : IXpsOMResource
		{
			/// <summary>Gets the name that will be used when the part is serialized.</summary>
			/// <returns>
			/// A pointer to the IOpcPartUri interface that contains the part name. If the part name has not been set (by the SetPartName
			/// method), a <c>NULL</c> pointer is returned.
			/// </returns>
			// https://docs.microsoft.com/en-us/windows/win32/api/xpsobjectmodel/nf-xpsobjectmodel-ixpsompart-getpartname HRESULT
			// GetPartName( IOpcPartUri **partUri );
			[MethodImpl(MethodImplOptions.InternalCall)]
			new IOpcPartUri GetPartName();

			/// <summary>Sets the name that will be used when the part is serialized.</summary>
			/// <param name="partUri">
			/// A pointer to the IOpcPartUri interface that contains the name of this part. This parameter cannot be <c>NULL</c>.
			/// </param>
			/// <remarks>
			/// IXpsOMPackageWriter will generate an error if it encounters an XPS document part whose name is the same as that of a part it
			/// has previously serialized.
			/// </remarks>
			// https://docs.microsoft.com/en-us/windows/win32/api/xpsobjectmodel/nf-xpsobjectmodel-ixpsompart-setpartname HRESULT
			// SetPartName( IOpcPartUri *partUri );
			[MethodImpl(MethodImplOptions.InternalCall)]
			new void SetPartName([In] IOpcPartUri partUri);

			/// <summary>Gets a new, read-only copy of the stream that is associated with this resource.</summary>
			/// <returns>A new, read-only copy of the stream that is associated with this resource.</returns>
			/// <remarks>
			/// <para>The IStream object returned by this method might return an error of E_PENDING, which indicates that the stream length has not been determined yet. This behavior is different from that of a standard <c>IStream</c> object.</para>
			/// <para>This method calls the stream's <c>Clone</c> method to create the stream returned in stream. As a result, the performance of this method will depend on that of the stream's <c>Clone</c> method.</para>
			/// </remarks>
			// https://docs.microsoft.com/en-us/windows/win32/api/xpsobjectmodel/nf-xpsobjectmodel-ixpsomcolorprofileresource-getstream
			// HRESULT GetStream( IStream **stream );
			[MethodImpl(MethodImplOptions.InternalCall)]
			IStream GetStream();

			/// <summary>
			/// Sets the read-only stream to be associated with this resource.
			/// </summary>
			/// <param name="sourceStream">The read-only stream to be associated with this resource.</param>
			/// <param name="partName">The part name to be assigned to this resource.</param>
			/// <remarks>
			/// <para>The calling method should treat this stream as a single-threaded apartment (STA) model object and not re-enter any of the stream interface's methods.</para>
			/// <para>Because GetStream gets a clone of the stream that is set by this method, the provided stream should have an efficient cloning method. A stream with an inefficient cloning method will reduce the performance of <c>GetStream</c>.</para>
			/// </remarks>
			// https://docs.microsoft.com/en-us/windows/win32/api/xpsobjectmodel/nf-xpsobjectmodel-ixpsomcolorprofileresource-setcontent
			// HRESULT SetContent( IStream *sourceStream, IOpcPartUri *partName );
			[MethodImpl(MethodImplOptions.InternalCall)]
			void SetContent([In] IStream sourceStream, [In] IOpcPartUri partName);
		}

		/// <summary>A collection of IXpsOMColorProfileResource interface pointers.</summary>
		/// <remarks>For more information about the collection methods, see Working with XPS OM Collection Interfaces.</remarks>
		// https://docs.microsoft.com/en-us/windows/win32/api/xpsobjectmodel/nn-xpsobjectmodel-ixpsomcolorprofileresourcecollection
		[PInvokeData("xpsobjectmodel.h", MSDNShortId = "cb9253f3-461e-47a3-820b-bb6bf5e30210")]
		[ComImport, Guid("12759630-5FBA-4283-8F7D-CCA849809EDB"), InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
		public interface IXpsOMColorProfileResourceCollection
		{
			/// <summary>Gets the number of IXpsOMColorProfileResource interface pointers in the collection.</summary>
			/// <returns>The number of IXpsOMColorProfileResource interface pointers in the collection.</returns>
			/// <remarks>For more information about the collection methods, see Working with XPS OM Collection Interfaces.</remarks>
			// https://docs.microsoft.com/en-us/windows/win32/api/xpsobjectmodel/nf-xpsobjectmodel-ixpsomcolorprofileresourcecollection-getcount
			// HRESULT GetCount( UINT32 *count );
			[MethodImpl(MethodImplOptions.InternalCall)]
			uint GetCount();

			/// <summary>Gets an IXpsOMColorProfileResource interface pointer from a specified location in the collection.</summary>
			/// <param name="index">The zero-based index of the IXpsOMColorProfileResource interface pointer to be obtained.</param>
			/// <returns>The IXpsOMColorProfileResource interface pointer at the location specified by index.</returns>
			/// <remarks>For more information about the collection methods, see Working with XPS OM Collection Interfaces.</remarks>
			// https://docs.microsoft.com/en-us/windows/win32/api/xpsobjectmodel/nf-xpsobjectmodel-ixpsomcolorprofileresourcecollection-getat
			// HRESULT GetAt( UINT32 index, IXpsOMColorProfileResource **object );
			[MethodImpl(MethodImplOptions.InternalCall)]
			IXpsOMColorProfileResource GetAt([In] uint index);

			/// <summary>
			/// Inserts an IXpsOMColorProfileResource interface pointer at a specified location in the collection.
			/// </summary>
			/// <param name="index">The zero-based index in the collection where the interface pointer that is passed in object is to be inserted.</param>
			/// <param name="object">The IXpsOMColorProfileResource interface pointer that is to be inserted in the location specified by index.</param>
			/// <remarks>
			/// <para>At the location specified by index, this method inserts the IXpsOMColorProfileResource interface pointer that is passed in object. Prior to the insertion, the pointer in this and all subsequent locations is moved up by one index.</para>
			/// <para>For more information about the collection methods, see Working with XPS OM Collection Interfaces.</para>
			/// </remarks>
			// https://docs.microsoft.com/en-us/windows/win32/api/xpsobjectmodel/nf-xpsobjectmodel-ixpsomcolorprofileresourcecollection-insertat
			// HRESULT InsertAt( UINT32 index, IXpsOMColorProfileResource *object );
			[MethodImpl(MethodImplOptions.InternalCall)]
			void InsertAt([In] uint index, [In] IXpsOMColorProfileResource @object);

			/// <summary>
			/// Removes and releases an IXpsOMColorProfileResource interface pointer from a specified location in the collection.
			/// </summary>
			/// <param name="index">The zero-based index in the collection from which an IXpsOMColorProfileResource interface pointer is to be removed and released.</param>
			/// <remarks>
			/// <para>This method releases the interface referenced by the pointer at the location specified by index. After releasing the interface, this method compacts the collection by reducing by 1 the index of each pointer subsequent to index.</para>
			/// <para>For more information about the collection methods, see Working with XPS OM Collection Interfaces.</para>
			/// </remarks>
			// https://docs.microsoft.com/en-us/windows/win32/api/xpsobjectmodel/nf-xpsobjectmodel-ixpsomcolorprofileresourcecollection-removeat
			// HRESULT RemoveAt( UINT32 index );
			[MethodImpl(MethodImplOptions.InternalCall)]
			void RemoveAt([In] uint index);

			/// <summary>
			/// Replaces an IXpsOMColorProfileResource interface pointer at a specified location in the collection.
			/// </summary>
			/// <param name="index">The zero-based index in the collection where an IXpsOMColorProfileResource interface pointer is to be replaced.</param>
			/// <param name="object">The IXpsOMColorProfileResource interface pointer that will replace current contents at the location specified by index.</param>
			/// <remarks>
			/// <para>At the location specified by index, this method releases the IXpsOMColorProfileResource interface referenced by the existing pointer, then writes the pointer that is passed in object.</para>
			/// <para>For more information about the collection methods, see Working with XPS OM Collection Interfaces.</para>
			/// </remarks>
			// https://docs.microsoft.com/en-us/windows/win32/api/xpsobjectmodel/nf-xpsobjectmodel-ixpsomcolorprofileresourcecollection-setat
			// HRESULT SetAt( UINT32 index, IXpsOMColorProfileResource *object );
			[MethodImpl(MethodImplOptions.InternalCall)]
			void SetAt([In] uint index, [In] IXpsOMColorProfileResource @object);

			/// <summary>Appends an IXpsOMColorProfileResource interface pointer to the end of the collection.</summary>
			/// <param name="object">A pointer to the IXpsOMColorProfileResource interface that is to be appended to the collection.</param>
			/// <remarks>For more information about the collection methods, see Working with XPS OM Collection Interfaces.</remarks>
			// https://docs.microsoft.com/en-us/windows/win32/api/xpsobjectmodel/nf-xpsobjectmodel-ixpsomcolorprofileresourcecollection-append
			// HRESULT Append( IXpsOMColorProfileResource *object );
			[MethodImpl(MethodImplOptions.InternalCall)]
			void Append([In] IXpsOMColorProfileResource @object);

			/// <summary>Gets an IXpsOMColorProfileResource interface pointer from the collection by matching the interface's part name.</summary>
			/// <param name="partName">The part name of the IXpsOMColorProfileResource interface to be found in the collection.</param>
			/// <returns>A pointer to the IXpsOMColorProfileResource interface whose part name matches partName. If a matching interface is not found in the collection, a <c>NULL</c> pointer is returned.</returns>
			// https://docs.microsoft.com/en-us/windows/win32/api/xpsobjectmodel/nf-xpsobjectmodel-ixpsomcolorprofileresourcecollection-getbypartname
			// HRESULT GetByPartName( IOpcPartUri *partName, IXpsOMColorProfileResource **part );
			[MethodImpl(MethodImplOptions.InternalCall)]
			IXpsOMColorProfileResource GetByPartName([In] IOpcPartUri partName);
		}

		/// <summary>
		/// <para>This interface provides access to the metadata that is stored in the Core Properties part of the XPS document.</para>
		/// <para>The contents of the Core Properties part are described in the 1st edition, Part 2, "Open Packaging Conventions," of Standard ECMA-376, Office Open XML File Formats.</para>
		/// </summary>
		/// <remarks>The meaning and use of these properties is determined by the user or context.</remarks>
		// https://docs.microsoft.com/en-us/windows/win32/api/xpsobjectmodel/nn-xpsobjectmodel-ixpsomcoreproperties
		[PInvokeData("xpsobjectmodel.h", MSDNShortId = "705ec9c7-5aa9-4fc5-ad2c-441cb545d056")]
		[ComImport, Guid("3340FE8F-4027-4AA1-8F5F-D35AE45FE597"), InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
		public interface IXpsOMCoreProperties : IXpsOMPart
		{
			/// <summary>Gets the name that will be used when the part is serialized.</summary>
			/// <returns>
			/// A pointer to the IOpcPartUri interface that contains the part name. If the part name has not been set (by the SetPartName
			/// method), a <c>NULL</c> pointer is returned.
			/// </returns>
			// https://docs.microsoft.com/en-us/windows/win32/api/xpsobjectmodel/nf-xpsobjectmodel-ixpsompart-getpartname HRESULT
			// GetPartName( IOpcPartUri **partUri );
			[MethodImpl(MethodImplOptions.InternalCall)]
			[return: MarshalAs(UnmanagedType.Interface)]
			new IOpcPartUri GetPartName();

			/// <summary>Sets the name that will be used when the part is serialized.</summary>
			/// <param name="partUri">
			/// A pointer to the IOpcPartUri interface that contains the name of this part. This parameter cannot be <c>NULL</c>.
			/// </param>
			/// <remarks>
			/// IXpsOMPackageWriter will generate an error if it encounters an XPS document part whose name is the same as that of a part it
			/// has previously serialized.
			/// </remarks>
			// https://docs.microsoft.com/en-us/windows/win32/api/xpsobjectmodel/nf-xpsobjectmodel-ixpsompart-setpartname HRESULT
			// SetPartName( IOpcPartUri *partUri );
			[MethodImpl(MethodImplOptions.InternalCall)]
			new void SetPartName([In] IOpcPartUri partUri);

			/// <summary>Gets a pointer to the IXpsOMPackage interface that contains the core properties.</summary>
			/// <returns>A pointer to the IXpsOMPackage interface that contains the core properties. If the interface does not belong to a package, a <c>NULL</c> pointer is returned.</returns>
			// https://docs.microsoft.com/en-us/windows/win32/api/xpsobjectmodel/nf-xpsobjectmodel-ixpsomcoreproperties-getowner
			// HRESULT GetOwner( IXpsOMPackage **package );
			IXpsOMPackage GetOwner();

			/// <summary>Gets the <c>category</c> property.</summary>
			/// <returns>The string that is read from the <c>category</c> property.</returns>
			/// <remarks>
			/// <para>The <c>category</c> property contains categorization of the content.</para>
			/// </remarks>
			// https://docs.microsoft.com/en-us/windows/win32/api/xpsobjectmodel/nf-xpsobjectmodel-ixpsomcoreproperties-getcategory
			// HRESULT GetCategory( LPWSTR *category );
			SafeCoTaskMemString GetCategory();

			/// <summary>Sets the <c>category</c> property.</summary>
			/// <param name="category">The string to be written to the <c>category</c> property. A <c>NULL</c> pointer clears the <c>category</c> property.</param>
			/// <remarks>The <c>category</c> property contains a categorization of the content.</remarks>
			// https://docs.microsoft.com/en-us/windows/win32/api/xpsobjectmodel/nf-xpsobjectmodel-ixpsomcoreproperties-setcategory
			// HRESULT SetCategory( LPCWSTR category );
			void SetCategory([In, MarshalAs(UnmanagedType.LPWStr)] string category);

			/// <summary>Gets the <c>contentStatus</c> property.</summary>
			/// <returns>The string that is read from the <c>contentStatus</c> property.</returns>
			/// <remarks>
			/// <para>The <c>contentStatus</c> property stores the content's status. Examples of <c>contentStatus</c> values include <c>Draft</c>, <c>Reviewed</c>, and <c>Final</c>.</para>
			/// </remarks>
			// https://docs.microsoft.com/en-us/windows/win32/api/xpsobjectmodel/nf-xpsobjectmodel-ixpsomcoreproperties-getcontentstatus
			// HRESULT GetContentStatus( LPWSTR *contentStatus );
			SafeCoTaskMemString GetContentStatus();

			/// <summary>Sets the <c>contentStatus</c> property.</summary>
			/// <param name="contentStatus">The string to be written to the <c>contentStatus</c> property. A <c>NULL</c> pointer clears the <c>contentStatus</c> property.</param>
			/// <remarks>The <c>contentStatus</c> property contains the status of the content. Examples of <c>contentStatus</c> values include <c>Draft</c>, <c>Reviewed</c>, and <c>Final</c>.</remarks>
			// https://docs.microsoft.com/en-us/windows/win32/api/xpsobjectmodel/nf-xpsobjectmodel-ixpsomcoreproperties-setcontentstatus
			// HRESULT SetContentStatus( LPCWSTR contentStatus );
			void SetContentStatus([In, MarshalAs(UnmanagedType.LPWStr)] string contentStatus);

			/// <summary>Gets the <c>contentType</c> property.</summary>
			/// <returns>The string that is read from the <c>contentType</c> property.</returns>
			/// <remarks>
			/// <para>The <c>contentType</c> property stores the type of content that is being represented, and it is generally defined by a specific use and intended audience. Examples of <c>contentType</c> values include <c>Whitepaper</c>, <c>Security Bulletin</c>, and <c>Exam</c>.</para>
			/// </remarks>
			// https://docs.microsoft.com/en-us/windows/win32/api/xpsobjectmodel/nf-xpsobjectmodel-ixpsomcoreproperties-getcontenttype
			// HRESULT GetContentType( LPWSTR *contentType );
			SafeCoTaskMemString GetContentType();

			/// <summary>Sets the <c>contentType</c> property.</summary>
			/// <param name="contentType">The string to be written to the <c>contentType</c> property. A <c>NULL</c> pointer clears the <c>contentType</c> property.</param>
			/// <remarks>The <c>contentType</c> property contains the type of content that is being represented, which is generally defined by a specific use and intended audience. Examples of <c>contentType</c> values include <c>Whitepaper</c>, <c>Security Bulletin</c>, and <c>Exam</c>.</remarks>
			// https://docs.microsoft.com/en-us/windows/win32/api/xpsobjectmodel/nf-xpsobjectmodel-ixpsomcoreproperties-setcontenttype
			// HRESULT SetContentType( LPCWSTR contentType );
			void SetContentType([In, MarshalAs(UnmanagedType.LPWStr)] string contentType);

			/// <summary>Gets the <c>created</c> property.</summary>
			/// <returns>The date and time that are read from the <c>created</c> property.</returns>
			/// <remarks>The <c>created</c> property contains the date and time the package was created.</remarks>
			// https://docs.microsoft.com/en-us/windows/win32/api/xpsobjectmodel/nf-xpsobjectmodel-ixpsomcoreproperties-getcreated
			// HRESULT GetCreated( SYSTEMTIME *created );
			SYSTEMTIME GetCreated();

			/// <summary>Sets the <c>created</c> property.</summary>
			/// <param name="created">The date and time the package was created. A <c>NULL</c> pointer clears the <c>created</c> property</param>
			/// <remarks>The <c>created</c> property contains the date and time the package was created.</remarks>
			// https://docs.microsoft.com/en-us/windows/win32/api/xpsobjectmodel/nf-xpsobjectmodel-ixpsomcoreproperties-setcreated
			// HRESULT SetCreated( const SYSTEMTIME *created );
			void SetCreated(in SYSTEMTIME created);

			/// <summary>Gets the <c>creator</c> property.</summary>
			/// <returns>The string that is read from the <c>creator</c> property.</returns>
			/// <remarks>
			/// <para>The <c>creator</c> property describes the entity that is primarily responsible for making the content of the resource.</para>
			/// </remarks>
			// https://docs.microsoft.com/en-us/windows/win32/api/xpsobjectmodel/nf-xpsobjectmodel-ixpsomcoreproperties-getcreator
			// HRESULT GetCreator( LPWSTR *creator );
			SafeCoTaskMemString GetCreator();

			/// <summary>Sets the <c>creator</c> property.</summary>
			/// <param name="creator">The string to be written to the <c>creator</c> property. A <c>NULL</c> pointer clears the <c>creator</c> property.</param>
			/// <remarks>The <c>creator</c> property describes the entity that is primarily responsible for making the content of the resource.</remarks>
			// https://docs.microsoft.com/en-us/windows/win32/api/xpsobjectmodel/nf-xpsobjectmodel-ixpsomcoreproperties-setcreator
			// HRESULT SetCreator( LPCWSTR creator );
			void SetCreator([In, MarshalAs(UnmanagedType.LPWStr)] string creator);

			/// <summary>Gets the <c>description</c> property.</summary>
			/// <returns>The string that is read from the <c>description</c> property.</returns>
			/// <remarks>
			/// <para>The <c>description</c> property provides an explanation of the content.</para>
			/// </remarks>
			// https://docs.microsoft.com/en-us/windows/win32/api/xpsobjectmodel/nf-xpsobjectmodel-ixpsomcoreproperties-getdescription
			// HRESULT GetDescription( LPWSTR *description );
			SafeCoTaskMemString GetDescription();

			/// <summary>Sets the <c>description</c> property.</summary>
			/// <param name="description">The string to be written to the <c>description</c> property. A <c>NULL</c> pointer clears this property.</param>
			/// <remarks>The <c>description</c> property explains the content.</remarks>
			// https://docs.microsoft.com/en-us/windows/win32/api/xpsobjectmodel/nf-xpsobjectmodel-ixpsomcoreproperties-setdescription
			// HRESULT SetDescription( LPCWSTR description );
			void SetDescription([In, MarshalAs(UnmanagedType.LPWStr)] string description);

			/// <summary>Gets the <c>identifier</c> property.</summary>
			/// <returns>The string that is read from the <c>identifier</c> property.</returns>
			/// <remarks>
			/// <para>The <c>identifier</c> property is an unambiguous reference to the resource within a user-defined or application-specific context.</para>
			/// </remarks>
			// https://docs.microsoft.com/en-us/windows/win32/api/xpsobjectmodel/nf-xpsobjectmodel-ixpsomcoreproperties-getidentifier
			// HRESULT GetIdentifier( LPWSTR *identifier );
			SafeCoTaskMemString GetIdentifier();

			/// <summary>Sets the <c>identifier</c> property.</summary>
			/// <param name="identifier">The string to be written to the <c>identifier</c> property. A <c>NULL</c> pointer clears the <c>identifier</c> property.</param>
			/// <remarks>The <c>identifier</c> property is an unambiguous reference to the resource within a user-defined or application-specific context.</remarks>
			// https://docs.microsoft.com/en-us/windows/win32/api/xpsobjectmodel/nf-xpsobjectmodel-ixpsomcoreproperties-setidentifier
			// HRESULT SetIdentifier( LPCWSTR identifier );
			void SetIdentifier([In, MarshalAs(UnmanagedType.LPWStr)] string identifier);

			/// <summary>Gets the <c>keywords</c> property.</summary>
			/// <returns>The string that is read from the <c>keywords</c> property.</returns>
			/// <remarks>
			/// <para>The <c>keywords</c> property is a delimited set of keywords that are used to support searching and indexing. This is typically a list of terms that are not available in other properties.</para>
			/// </remarks>
			// https://docs.microsoft.com/en-us/windows/win32/api/xpsobjectmodel/nf-xpsobjectmodel-ixpsomcoreproperties-getkeywords
			// HRESULT GetKeywords( LPWSTR *keywords );
			SafeCoTaskMemString GetKeywords();

			/// <summary>Sets the <c>keywords</c> property.</summary>
			/// <param name="keywords">The string that contains the keywords to be written to the <c>keywords</c> property. A <c>NULL</c> pointer clears the <c>keywords</c> property.</param>
			/// <remarks>The <c>keywords</c> property is a delimited set of keywords that are used to support searching and indexing. It is typically a list of terms that are not available elsewhere in the properties.</remarks>
			// https://docs.microsoft.com/en-us/windows/win32/api/xpsobjectmodel/nf-xpsobjectmodel-ixpsomcoreproperties-setkeywords
			// HRESULT SetKeywords( LPCWSTR keywords );
			void SetKeywords([In, MarshalAs(UnmanagedType.LPWStr)] string keywords);

			/// <summary>Gets the <c>language</c> property.</summary>
			/// <returns>The value that is read from the <c>language</c> property.</returns>
			/// <remarks>
			/// <para>The <c>language</c> property describes the language of the resource's intellectual content.</para>
			/// <para>Internet Engineering Task Force (IETF) RFC 3066 describes the recommended encoding for this property.</para>
			/// </remarks>
			// https://docs.microsoft.com/en-us/windows/win32/api/xpsobjectmodel/nf-xpsobjectmodel-ixpsomcoreproperties-getlanguage
			// HRESULT GetLanguage( LPWSTR *language );
			SafeCoTaskMemString GetLanguage();

			/// <summary>Sets the <c>language</c> property.</summary>
			/// <param name="language">The string that contains the language value to be written to the <c>language</c> property. A <c>NULL</c> pointer clears the <c>language</c> property.</param>
			/// <remarks>
			/// <para>The <c>language</c> property describes the language of the resource's intellectual content.</para>
			/// <para>Internet Engineering Task Force (IETF) RFC 3066 describes the recommended encoding for this property.</para>
			/// </remarks>
			// https://docs.microsoft.com/en-us/windows/win32/api/xpsobjectmodel/nf-xpsobjectmodel-ixpsomcoreproperties-setlanguage
			// HRESULT SetLanguage( LPCWSTR language );
			void SetLanguage([In, MarshalAs(UnmanagedType.LPWStr)] string language);

			/// <summary>Gets the <c>lastModifiedBy</c> property.</summary>
			/// <returns>The value that is read from the <c>lastModifiedBy</c> property.</returns>
			/// <remarks>
			/// <para>The <c>lastModifiedBy</c> property describes the user who performed the last modification.</para>
			/// </remarks>
			// https://docs.microsoft.com/en-us/windows/win32/api/xpsobjectmodel/nf-xpsobjectmodel-ixpsomcoreproperties-getlastmodifiedby
			// HRESULT GetLastModifiedBy( LPWSTR *lastModifiedBy );
			SafeCoTaskMemString GetLastModifiedBy();

			/// <summary>Sets the <c>lastModifiedBy</c> property.</summary>
			/// <param name="lastModifiedBy">The string that contains the value to be written to the <c>lastModifiedBy</c> property. A <c>NULL</c> pointer clears the <c>lastModifiedBy</c> property.</param>
			/// <remarks>The <c>lastModifiedBy</c> property describes the user who performs the last modification.</remarks>
			// https://docs.microsoft.com/en-us/windows/win32/api/xpsobjectmodel/nf-xpsobjectmodel-ixpsomcoreproperties-setlastmodifiedby
			// HRESULT SetLastModifiedBy( LPCWSTR lastModifiedBy );
			void SetLastModifiedBy([In, MarshalAs(UnmanagedType.LPWStr)] string lastModifiedBy);

			/// <summary>Gets the <c>lastPrinted</c> property.</summary>
			/// <returns>The date and time that are read from the <c>lastPrinted</c> property.</returns>
			/// <remarks>The <c>lastPrinted</c> property contains the date and time the package was last printed.</remarks>
			// https://docs.microsoft.com/en-us/windows/win32/api/xpsobjectmodel/nf-xpsobjectmodel-ixpsomcoreproperties-getlastprinted
			// HRESULT GetLastPrinted( SYSTEMTIME *lastPrinted );
			SYSTEMTIME GetLastPrinted();

			/// <summary>
			/// Sets the <c>lastPrinted</c> property.
			/// </summary>
			/// <param name="lastPrinted">The date and time the package was last printed. A <c>NULL</c> pointer clears the <c>lastPrinted</c> property.</param>
			/// <remarks>
			/// The <c>lastPrinted</c> property contains the date and time the package was last printed.
			/// </remarks>
			// https://docs.microsoft.com/en-us/windows/win32/api/xpsobjectmodel/nf-xpsobjectmodel-ixpsomcoreproperties-setlastprinted
			// HRESULT SetLastPrinted( const SYSTEMTIME *lastPrinted );
			void SetLastPrinted(in SYSTEMTIME lastPrinted);

			/// <summary>Gets the <c>modified</c> property.</summary>
			/// <returns>The date and time that are read from the <c>modified</c> property.</returns>
			/// <remarks>The <c>modified</c> property contains the date and time the package was last modified.</remarks>
			// https://docs.microsoft.com/en-us/windows/win32/api/xpsobjectmodel/nf-xpsobjectmodel-ixpsomcoreproperties-getmodified
			// HRESULT GetModified( SYSTEMTIME *modified );
			SYSTEMTIME GetModified();

			/// <summary>Sets the <c>modified</c> property.</summary>
			/// <param name="modified">The date and time the package was last changed. A <c>NULL</c> pointer clears the <c>modified</c> property.</param>
			/// <remarks>The <c>modified</c> property contains the date and time the package was last changed.</remarks>
			// https://docs.microsoft.com/en-us/windows/win32/api/xpsobjectmodel/nf-xpsobjectmodel-ixpsomcoreproperties-setmodified
			// HRESULT SetModified( const SYSTEMTIME *modified );
			void SetModified(in SYSTEMTIME modified);

			/// <summary>Gets the <c>revision</c> property.</summary>
			/// <returns>The string that is read from the <c>revision</c> property.</returns>
			/// <remarks>
			/// <para>The <c>revision</c> property contains the resource's revision number.</para>
			/// </remarks>
			// https://docs.microsoft.com/en-us/windows/win32/api/xpsobjectmodel/nf-xpsobjectmodel-ixpsomcoreproperties-getrevision
			// HRESULT GetRevision( LPWSTR *revision );
			SafeCoTaskMemString GetRevision();

			/// <summary>Sets the <c>revision</c> property.</summary>
			/// <param name="revision">The string to be written to the <c>revision</c> property. A <c>NULL</c> pointer clears the <c>revision</c> property.</param>
			/// <remarks>The <c>revision</c> property contains the revision number of the resource.</remarks>
			// https://docs.microsoft.com/en-us/windows/win32/api/xpsobjectmodel/nf-xpsobjectmodel-ixpsomcoreproperties-setrevision
			// HRESULT SetRevision( LPCWSTR revision );
			void SetRevision([In, MarshalAs(UnmanagedType.LPWStr)] string revision);

			/// <summary>
			/// Gets the <c>subject</c> property.
			/// </summary>
			/// <returns>
			/// The string that is read from the <c>subject</c> property.
			/// </returns>
			/// <remarks>
			/// The <c>subject</c> property contains the topic of the resource's content.
			/// </remarks>
			// https://docs.microsoft.com/en-us/windows/win32/api/xpsobjectmodel/nf-xpsobjectmodel-ixpsomcoreproperties-getsubject
			// HRESULT GetSubject( LPWSTR *subject );
			SafeCoTaskMemString GetSubject();

			/// <summary>
			/// Sets the <c>subject</c> property.
			/// </summary>
			/// <param name="subject">The string to be written to the <c>subject</c> property. A <c>NULL</c> pointer clears the <c>subject</c> property.</param>
			/// <remarks>
			/// The <c>subject</c> property contains the topic of the resource content.
			/// </remarks>
			// https://docs.microsoft.com/en-us/windows/win32/api/xpsobjectmodel/nf-xpsobjectmodel-ixpsomcoreproperties-setsubject
			// HRESULT SetSubject( LPCWSTR subject );
			void SetSubject([In, MarshalAs(UnmanagedType.LPWStr)] string subject);

			/// <summary>
			/// Gets the <c>title</c> property.
			/// </summary>
			/// <returns>
			/// The string that is read from the <c>title</c> property.
			/// </returns>
			/// <remarks>
			/// The <c>title</c> property contains the resource's name.
			/// </remarks>
			// https://docs.microsoft.com/en-us/windows/win32/api/xpsobjectmodel/nf-xpsobjectmodel-ixpsomcoreproperties-gettitle
			// HRESULT GetTitle( LPWSTR *title );
			SafeCoTaskMemString GetTitle();

			/// <summary>
			/// Sets the <c>title</c> property.
			/// </summary>
			/// <param name="title">The string to be written to the <c>title</c> property. A <c>NULL</c> pointer clears the <c>title</c> property.</param>
			/// <remarks>
			/// The <c>title</c> property contains the name given to the resource.
			/// </remarks>
			// https://docs.microsoft.com/en-us/windows/win32/api/xpsobjectmodel/nf-xpsobjectmodel-ixpsomcoreproperties-settitle
			// HRESULT SetTitle( LPCWSTR title );
			void SetTitle([In, MarshalAs(UnmanagedType.LPWStr)] string title);

			/// <summary>
			/// Gets the <c>version</c> property.
			/// </summary>
			/// <returns>
			/// The string that is read from the <c>version</c> property.
			/// </returns>
			/// <remarks>
			/// The <c>version</c> property contains the resource's version number.
			/// </remarks>
			// https://docs.microsoft.com/en-us/windows/win32/api/xpsobjectmodel/nf-xpsobjectmodel-ixpsomcoreproperties-getversion
			// HRESULT GetVersion( LPWSTR *version );
			SafeCoTaskMemString GetVersion();

			/// <summary>Sets the <c>version</c> property.</summary>
			/// <param name="version">The string to be written to the <c>version</c> property. A <c>NULL</c> pointer clears the <c>version</c> property.</param>
			/// <remarks>The <c>version</c> property contains the version number of the resource.</remarks>
			// https://docs.microsoft.com/en-us/windows/win32/api/xpsobjectmodel/nf-xpsobjectmodel-ixpsomcoreproperties-setversion
			// HRESULT SetVersion( LPCWSTR version );
			void SetVersion([In, MarshalAs(UnmanagedType.LPWStr)] string version);

			/// <summary>Makes a deep copy of the interface.</summary>
			/// <returns>A pointer to the copy of the interface.</returns>
			/// <remarks>The owner of the interface returned in coreProperties is <c>NULL</c>.</remarks>
			// https://docs.microsoft.com/en-us/windows/win32/api/xpsobjectmodel/nf-xpsobjectmodel-ixpsomcoreproperties-clone
			// HRESULT Clone( IXpsOMCoreProperties **coreProperties );
			IXpsOMCoreProperties Clone();
		}

		/// <summary>A collection of XPS_DASH structures.</summary>
		/// <remarks>For more information about the collection methods, see Working with XPS OM Collection Interfaces.</remarks>
		// https://docs.microsoft.com/en-us/windows/win32/api/xpsobjectmodel/nn-xpsobjectmodel-ixpsomdashcollection
		[PInvokeData("xpsobjectmodel.h", MSDNShortId = "02a152a1-e117-42fb-8428-a2b28e6540a9")]
		[ComImport, Guid("081613F4-74EB-48F2-83B3-37A9CE2D7DC6"), InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
		public interface IXpsOMDashCollection
		{
			/// <summary>Gets the number of XPS_DASH structures in the collection.</summary>
			/// <returns>The number of XPS_DASH structures in the collection.</returns>
			/// <remarks>For more information about the collection methods, see Working with XPS OM Collection Interfaces.</remarks>
			// https://docs.microsoft.com/en-us/windows/win32/api/xpsobjectmodel/nf-xpsobjectmodel-ixpsomdashcollection-getcount
			// HRESULT GetCount( UINT32 *count );
			uint GetCount();

			/// <summary>Gets an XPS_DASH structure from a specified location in the collection.</summary>
			/// <param name="index">The zero-based index in the collection where an XPS_DASH structure is to be obtained.</param>
			/// <returns>The XPS_DASH structure that is found at the location specified by index.</returns>
			/// <remarks>For more information about the collection methods, see Working with XPS OM Collection Interfaces.</remarks>
			// https://docs.microsoft.com/en-us/windows/win32/api/xpsobjectmodel/nf-xpsobjectmodel-ixpsomdashcollection-getat
			// HRESULT GetAt( UINT32 index, XPS_DASH *dash );
			XPS_DASH GetAt([In] uint index);

			/// <summary>Inserts an XPS_DASH structure at a specified location in the collection.</summary>
			/// <param name="index">The zero-based index in the collection where the structure that is referenced by dash is to be inserted.</param>
			/// <param name="dash">A pointer to the XPS_DASH structure that is to be inserted at the location specified by index.</param>
			/// <remarks>
			/// <para>At the location specified by index, this method inserts the XPS_DASH structure that is passed in dash. Prior to insertion, the structure in this and all subsequent locations is moved up by one index.</para>
			/// <para>The figure that follows illustrates how the collection is changed by the <c>InsertAt</c> method.</para>
			/// </remarks>
			// https://docs.microsoft.com/en-us/windows/win32/api/xpsobjectmodel/nf-xpsobjectmodel-ixpsomdashcollection-insertat
			// HRESULT InsertAt( UINT32 index, const XPS_DASH *dash );
			void InsertAt([In] uint index, in XPS_DASH dash);

			/// <summary>Removes and frees an XPS_DASH structure from a specified location in the collection.</summary>
			/// <param name="index">The zero-based index in the collection from which an XPS_DASH structure is to be removed and freed.</param>
			/// <remarks>
			/// <para>This method removes and frees the XPS_DASH structure referenced by the pointer at the location specified by index. After freeing the structure, this method compacts the collection by reducing by 1 the index of each pointer subsequent to index.</para>
			/// <para>The figure that follows illustrates how the collection is changed by the <c>RemoveAt</c> method.</para>
			/// </remarks>
			// https://docs.microsoft.com/en-us/windows/win32/api/xpsobjectmodel/nf-xpsobjectmodel-ixpsomdashcollection-removeat
			// HRESULT RemoveAt( UINT32 index );
			void RemoveAt([In] uint index);

			/// <summary>
			/// Replaces an XPS_DASH structure at a specified location in the collection.
			/// </summary>
			/// <param name="index">The zero-based index in the collection where an XPS_DASH structure is to be replaced.</param>
			/// <param name="dash">A pointer to the XPS_DASH structure that will replace the current contents at the location specified by index.</param>
			/// <remarks>
			/// <para>At the location specified by index, this method frees the existing XPS_DASH structure then replaces it with the structure that is passed in dash.</para>
			/// <para>The figure that follows illustrates how the collection is changed by the <c>SetAt</c> method.</para>
			/// </remarks>
			// https://docs.microsoft.com/en-us/windows/win32/api/xpsobjectmodel/nf-xpsobjectmodel-ixpsomdashcollection-setat
			// HRESULT SetAt( UINT32 index, const XPS_DASH *dash );
			void SetAt([In] uint index, in XPS_DASH dash);

			/// <summary>Appends an XPS_DASH structure to the end of the collection.</summary>
			/// <param name="dash">A pointer to the XPS_DASH structure that is to be appended to the collection.</param>
			/// <remarks>The figure that follows illustrates how the collection is changed by the <c>Append</c> method.</remarks>
			// https://docs.microsoft.com/en-us/windows/win32/api/xpsobjectmodel/nf-xpsobjectmodel-ixpsomdashcollection-append
			// HRESULT Append( const XPS_DASH *dash );
			void Append(in XPS_DASH dash);
		}

		/// <summary>The dictionary is used by an XPS package to share resources.</summary>
		/// <remarks>
		/// <para>The interface pointers stored in a dictionary will usually point to interfaces, such as IXpsOMBrush and IXpsOMVisual, that are derived from the IXpsOMShareable interface. To determine the interface type, call the IXpsOMShareable::GetType method.</para>
		/// <para>A dictionary cannot contain duplicate interface pointers.</para>
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows/win32/api/xpsobjectmodel/nn-xpsobjectmodel-ixpsomdictionary
		[PInvokeData("xpsobjectmodel.h", MSDNShortId = "f887e3d3-973c-4267-a785-6bc190c13082")]
		[ComImport, Guid("897C86B8-8EAF-4AE3-BDDE-56419FCF4236"), InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
		public interface IXpsOMDictionary
		{
			/// <summary>Gets a pointer to the interface that contains the dictionary.</summary>
			/// <returns>The <c>IUnknown</c> interface of the interface that contains the dictionary.</returns>
			// https://docs.microsoft.com/en-us/windows/win32/api/xpsobjectmodel/nf-xpsobjectmodel-ixpsomdictionary-getowner
			// HRESULT GetOwner( IUnknown **owner );
			[return: MarshalAs(UnmanagedType.IUnknown)]
			object GetOwner();

			/// <summary>Gets the number of entries in the dictionary.</summary>
			/// <returns>The number of entries in the dictionary.</returns>
			// https://docs.microsoft.com/en-us/windows/win32/api/xpsobjectmodel/nf-xpsobjectmodel-ixpsomdictionary-getcount
			// HRESULT GetCount( UINT32 *count );
			uint GetCount();

			/// <summary>Gets the IXpsOMShareable interface pointer and the key name string of the entry at a specified index in the dictionary.</summary>
			/// <param name="index">The zero-based index of the dictionary entry that is to be obtained.</param>
			/// <param name="key">The key string that is found at the location specified by index.</param>
			/// <returns>The IXpsOMShareable interface pointer that is found at the location specified by index.</returns>
			/// <remarks>
			/// <para>The interface pointers that are stored in a dictionary will usually point to interfaces, such as IXpsOMBrush and IXpsOMVisual, that are derived from the IXpsOMShareable interface. To determine the interface type, call the IXpsOMShareable::GetType method.</para>
			/// </remarks>
			// https://docs.microsoft.com/en-us/windows/win32/api/xpsobjectmodel/nf-xpsobjectmodel-ixpsomdictionary-getat
			// HRESULT GetAt( UINT32 index, LPWSTR *key, IXpsOMShareable **entry );
			IXpsOMShareable GetAt([In] uint index, out SafeCoTaskMemString key);

			/// <summary>Gets the IXpsOMShareable interface pointer of the entry that contains the specified key.</summary>
			/// <param name="key">The entry's key to be found in the dictionary.</param>
			/// <param name="beforeEntry">The IXpsOMShareable interface pointer to the last entry in the dictionary which is to be searched for key. If beforeEntry is <c>NULL</c> or is an interface pointer to an entry that is not in the dictionary, the entire dictionary will be searched.</param>
			/// <returns>The interface pointer to the dictionary entry whose key matches key.</returns>
			/// <remarks>The interface pointers stored in a dictionary will usually point to interfaces, such as IXpsOMBrush and IXpsOMVisual, that are derived from the IXpsOMShareable interface. To determine the interface type, call the IXpsOMShareable::GetType method.</remarks>
			// https://docs.microsoft.com/en-us/windows/win32/api/xpsobjectmodel/nf-xpsobjectmodel-ixpsomdictionary-getbykey
			// HRESULT GetByKey( LPCWSTR key, IXpsOMShareable *beforeEntry, IXpsOMShareable **entry );
			IXpsOMShareable GetByKey([In, MarshalAs(UnmanagedType.LPWStr)] string key, [In] IXpsOMShareable beforeEntry);

			/// <summary>Gets the index of an IXpsOMShareable interface from the dictionary.</summary>
			/// <param name="entry">The IXpsOMShareable interface pointer to be found in the dictionary.</param>
			/// <returns>The zero-based index of entry in the dictionary.</returns>
			// https://docs.microsoft.com/en-us/windows/win32/api/xpsobjectmodel/nf-xpsobjectmodel-ixpsomdictionary-getindex
			// HRESULT GetIndex( IXpsOMShareable *entry, UINT32 *index );
			uint GetIndex([In] IXpsOMShareable entry);

			/// <summary>
			/// Appends an IXpsOMShareable interface along with its key to the end of the dictionary.
			/// </summary>
			/// <param name="key"><para>The key to be used for this entry.</para>
			/// <para>The string referenced by key must be unique in the dictionary.</para></param>
			/// <param name="entry"><para>A pointer to the IXpsOMShareable interface that is to be appended to the dictionary.</para>
			/// <para>A dictionary cannot contain duplicate interface pointers. This parameter must contain an interface pointer that is not already in the dictionary.</para></param>
			/// <remarks>
			/// <para>The interface pointers stored in a dictionary will usually point to interfaces, such as IXpsOMBrush and IXpsOMVisual, that are derived from the IXpsOMShareable interface. To determine the interface type, call the IXpsOMShareable::GetType method.</para>
			/// <para>The figure that follows illustrates how the dictionary is changed by the <c>Append</c> method.</para>
			/// </remarks>
			// https://docs.microsoft.com/en-us/windows/win32/api/xpsobjectmodel/nf-xpsobjectmodel-ixpsomdictionary-append
			// HRESULT Append( LPCWSTR key, IXpsOMShareable *entry );
			void Append([In, MarshalAs(UnmanagedType.LPWStr)] string key, [In] IXpsOMShareable entry);

			/// <summary>
			/// Inserts an IXpsOMShareable interface at a specified location in the dictionary and sets the key to identify the interface.
			/// </summary>
			/// <param name="index">The zero-based index in the dictionary where the IXpsOMShareable interface is to be inserted.</param>
			/// <param name="key"><para>The key to be used to identify the IXpsOMShareable interface in the dictionary.</para>
			/// <para>The string referenced by key must be unique in the dictionary.</para></param>
			/// <param name="entry"><para>The IXpsOMShareable interface pointer to be inserted at the location specified by index.</para>
			/// <para>A dictionary cannot contain duplicate interface pointers. This parameter must contain an interface pointer that is not already in the dictionary.</para></param>
			/// <remarks>
			/// <para>The interface pointers stored in the dictionary will usually be pointers to interfaces, such as IXpsOMBrush and IXpsOMVisual, that are derived from the IXpsOMShareable interface. To determine the interface type, call the IXpsOMShareable::GetType method.</para>
			/// <para>At the location specified by index, this method inserts the IXpsOMShareable interface pointer and sets the key; the interface pointer and key are passed in value and key, respectively. Before value and key are inserted, the interface pointer and the key at this and all subsequent locations are moved up by one index.</para>
			/// <para>The figure that follows illustrates how the dictionary is changed by the <c>InsertAt</c> method.</para>
			/// </remarks>
			// https://docs.microsoft.com/en-us/windows/win32/api/xpsobjectmodel/nf-xpsobjectmodel-ixpsomdictionary-insertat
			// HRESULT InsertAt( UINT32 index, LPCWSTR key, IXpsOMShareable *entry );
			void InsertAt([In] uint index, [In, MarshalAs(UnmanagedType.LPWStr)] string key, [In] IXpsOMShareable entry);

			/// <summary>
			/// Removes and releases the entry from a specified location in the dictionary.
			/// </summary>
			/// <param name="index">The zero-based index in the dictionary from which an entry is to be removed and released.</param>
			/// <remarks>
			/// <para>At the location specified by index, this method releases the interface referenced by the pointer. After releasing the interface, this method compacts the dictionary by reducing by 1 the index of each pointer subsequent to index.</para>
			/// <para>The figure that follows illustrates how the dictionary is changed by the <c>RemoveAt</c> method.</para>
			/// </remarks>
			// https://docs.microsoft.com/en-us/windows/win32/api/xpsobjectmodel/nf-xpsobjectmodel-ixpsomdictionary-removeat
			// HRESULT RemoveAt( UINT32 index );
			void RemoveAt([In] uint index);

			/// <summary>
			/// Replaces the entry at a specified location in the dictionary.
			/// </summary>
			/// <param name="index">The zero-based index in the dictionary in which an entry is to be replaced.</param>
			/// <param name="key"><para>The key to be used for the new entry.</para>
			/// <para>The string referenced by key must be unique in the dictionary.</para></param>
			/// <param name="entry"><para>The IXpsOMShareable interface pointer that will replace current contents at the location specified by index.</para>
			/// <para>A dictionary cannot contain duplicate interface pointers. This parameter must contain an interface pointer that is not already in the dictionary.</para></param>
			/// <remarks>
			/// <para>At the location specified by index, this method releases the IXpsOMShareable interface referenced by the existing pointer, then replaces it with the interface pointer that is passed in entry and assigns it the key passed in key.</para>
			/// <para>The interface pointers stored in a dictionary will usually point to interfaces, such as IXpsOMBrush and IXpsOMVisual, that are derived from the IXpsOMShareable interface. To determine the interface type, call the GetType method.</para>
			/// <para>The figure that follows illustrates how the dictionary is changed by the <c>SetAt</c> method.</para>
			/// </remarks>
			// https://docs.microsoft.com/en-us/windows/win32/api/xpsobjectmodel/nf-xpsobjectmodel-ixpsomdictionary-setat
			// HRESULT SetAt( UINT32 index, LPCWSTR key, IXpsOMShareable *entry );
			void SetAt([In] uint index, [In, MarshalAs(UnmanagedType.LPWStr)] string key, [In] IXpsOMShareable entry);

			/// <summary>Makes a deep copy of the interface.</summary>
			/// <returns>A pointer to the copy of the interface.</returns>
			// https://docs.microsoft.com/en-us/windows/win32/api/xpsobjectmodel/nf-xpsobjectmodel-ixpsomdictionary-clone
			// HRESULT Clone( IXpsOMDictionary **dictionary );
			IXpsOMDictionary Clone();
		}

		/// <summary>
		/// An ordered sequence of fixed pages and document-level resources that make up the document.
		/// </summary>
		/// <remarks>
		/// The code example that follows illustrates how to create an instance of this interface.
		/// </remarks>
		/// <seealso cref="Vanara.PInvoke.XpsObjectModel.IXpsOMPart" />
		// https://docs.microsoft.com/en-us/windows/win32/api/xpsobjectmodel/nn-xpsobjectmodel-ixpsomdocument
		[PInvokeData("xpsobjectmodel.h", MSDNShortId = "22d3c0a1-3ad5-4f48-9e1e-eaf3bd95b39f")]
		[ComImport, Guid("2C2C94CB-AC5F-4254-8EE9-23948309D9F0"), InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
		public interface IXpsOMDocument : IXpsOMPart
		{
			/// <summary>Gets the name that will be used when the part is serialized.</summary>
			/// <returns>
			/// A pointer to the IOpcPartUri interface that contains the part name. If the part name has not been set (by the SetPartName
			/// method), a <c>NULL</c> pointer is returned.
			/// </returns>
			// https://docs.microsoft.com/en-us/windows/win32/api/xpsobjectmodel/nf-xpsobjectmodel-ixpsompart-getpartname HRESULT
			// GetPartName( IOpcPartUri **partUri );
			[MethodImpl(MethodImplOptions.InternalCall)]
			[return: MarshalAs(UnmanagedType.Interface)]
			new IOpcPartUri GetPartName();

			/// <summary>Sets the name that will be used when the part is serialized.</summary>
			/// <param name="partUri">
			/// A pointer to the IOpcPartUri interface that contains the name of this part. This parameter cannot be <c>NULL</c>.
			/// </param>
			/// <remarks>
			/// IXpsOMPackageWriter will generate an error if it encounters an XPS document part whose name is the same as that of a part it
			/// has previously serialized.
			/// </remarks>
			// https://docs.microsoft.com/en-us/windows/win32/api/xpsobjectmodel/nf-xpsobjectmodel-ixpsompart-setpartname HRESULT
			// SetPartName( IOpcPartUri *partUri );
			[MethodImpl(MethodImplOptions.InternalCall)]
			new void SetPartName([In] IOpcPartUri partUri);

			/// <summary>Gets a pointer to the IXpsOMDocumentSequence interface that contains the document.</summary>
			/// <returns>A pointer to the IXpsOMDocumentSequence interface that contains the document. If the document does not belong to a document sequence, a <c>NULL</c> pointer is returned.</returns>
			// https://docs.microsoft.com/en-us/windows/win32/api/xpsobjectmodel/nf-xpsobjectmodel-ixpsomdocument-getowner
			// HRESULT GetOwner( IXpsOMDocumentSequence **documentSequence );
			IXpsOMDocumentSequence GetOwner();

			/// <summary>Gets the IXpsOMPageReferenceCollection interface of the document, which allows virtualized access to its pages.</summary>
			/// <returns>A pointer to the IXpsOMPageReferenceCollection interface that contains a collection of page references for each page of the document. If there are no page references, the <c>IXpsOMPageReferenceCollection</c> returned in pageReferences will be empty and will have no elements.</returns>
			/// <remarks>
			/// <para>To get the pages of a document, first get the list of IXpsOMPageReference interfaces by calling <c>GetPageReferences</c>. Then, for each <c>IXpsOMPageReference</c> interface, load a page by calling GetPage.</para>
			/// <para>If the document does not have any pages, the page reference collection returned in pageReferences will be empty. To get the number of page references in the collection, call its GetCount method.</para>
			/// <para>For an example of how this method can be used in a program, see Navigate the XPS OM.</para>
			/// </remarks>
			// https://docs.microsoft.com/en-us/windows/win32/api/xpsobjectmodel/nf-xpsobjectmodel-ixpsomdocument-getpagereferences
			// HRESULT GetPageReferences( IXpsOMPageReferenceCollection **pageReferences );
			IXpsOMPageReferenceCollection GetPageReferences();

			/// <summary>Gets the IXpsOMPrintTicketResource interface of the document-level print ticket.</summary>
			/// <returns>A pointer to the IXpsOMPrintTicketResource interface of the document-level print ticket that is associated with the document. If no print ticket has been assigned, a <c>NULL</c> pointer will be returned.</returns>
			/// <remarks>After loading and parsing the resource into the XPS OM, this method might return an error that applies to another resource. This occurs because all of the relationships are parsed when a resource is loaded.</remarks>
			// https://docs.microsoft.com/en-us/windows/win32/api/xpsobjectmodel/nf-xpsobjectmodel-ixpsomdocument-getprintticketresource
			// HRESULT GetPrintTicketResource( IXpsOMPrintTicketResource **printTicketResource );
			IXpsOMPrintTicketResource GetPrintTicketResource();

			/// <summary>Sets the IXpsOMPrintTicketResource interface for the document-level print ticket.</summary>
			/// <returns>A pointer to the IXpsOMPrintTicketResource interface for the document-level print ticket to be assigned to the document. A <c>NULL</c> pointer releases any previously assigned print ticket resource.</returns>
			/// <remarks>If the document contains an IXpsOMPrintTicketResource interface when this method is called, that interface is released before the new <c>IXpsOMPrintTicketResource</c> interface, passed in printTicketResource, is set.</remarks>
			// https://docs.microsoft.com/en-us/windows/win32/api/xpsobjectmodel/nf-xpsobjectmodel-ixpsomdocument-setprintticketresource
			// HRESULT SetPrintTicketResource( IXpsOMPrintTicketResource *printTicketResource );
			void SetPrintTicketResource([In] IXpsOMPrintTicketResource printTicketResource);

			/// <summary>Gets a pointer to the IXpsOMDocumentStructureResource interface of the resource that contains structural information about the document.</summary>
			/// <remarks>After loading and parsing the resource into the XPS OM, this method might return an error that applies to another resource. This occurs because all of the relationships are parsed when a resource is loaded.</remarks>
			// https://docs.microsoft.com/en-us/windows/win32/api/xpsobjectmodel/nf-xpsobjectmodel-ixpsomdocument-getdocumentstructureresource
			// HRESULT GetDocumentStructureResource( IXpsOMDocumentStructureResource **documentStructureResource );
			IXpsOMDocumentStructureResource GetDocumentStructureResource();

			/// <summary>Sets the IXpsOMDocumentStructureResource interface for the document.</summary>
			/// <remarks>If the document contains an IXpsOMDocumentStructureResource interface when this method is called, that interface is released before the new <c>IXpsOMDocumentStructureResource</c> interface, which is passed in documentStructureResource, is set.</remarks>
			// https://docs.microsoft.com/en-us/windows/win32/api/xpsobjectmodel/nf-xpsobjectmodel-ixpsomdocument-setdocumentstructureresource
			// HRESULT SetDocumentStructureResource( IXpsOMDocumentStructureResource *documentStructureResource );
			void SetDocumentStructureResource([In] IXpsOMDocumentStructureResource documentStructureResource);

			/// <summary>Gets a pointer to the IXpsOMSignatureBlockResourceCollection interface, which refers to a collection of the document's digital signature block resources.</summary>
			/// <returns>A pointer to the IXpsOMSignatureBlockResourceCollection interface, which refers to a collection of the document's digital signature block resources. If the document does not contain any signature block resources, the <c>IXpsOMSignatureBlockResourceCollection</c> interface will be empty.</returns>
			/// <remarks>After loading and parsing the resource into the XPS OM, this method might return an error that applies to another resource. This occurs because all of the relationships are parsed when a resource is loaded.</remarks>
			// https://docs.microsoft.com/en-us/windows/win32/api/xpsobjectmodel/nf-xpsobjectmodel-ixpsomdocument-getsignatureblockresources
			// HRESULT GetSignatureBlockResources( IXpsOMSignatureBlockResourceCollection **signatureBlockResources );
			IXpsOMSignatureBlockResourceCollection GetSignatureBlockResources();

			/// <summary>Makes a deep copy of the interface.</summary>
			/// <returns>A pointer to the copy of the interface.</returns>
			/// <remarks>This method does not update any of the resource pointers in the copy.</remarks>
			// https://docs.microsoft.com/en-us/windows/win32/api/xpsobjectmodel/nf-xpsobjectmodel-ixpsomdocument-clone
			// HRESULT Clone( IXpsOMDocument **document );
			IXpsOMDocument Clone();
		}

		/// <summary>A collection of IXpsOMDocument interface pointers.</summary>
		/// <remarks>For more information about the collection methods, see Working with XPS OM Collection Interfaces.</remarks>
		// https://docs.microsoft.com/en-us/windows/win32/api/xpsobjectmodel/nn-xpsobjectmodel-ixpsomdocumentcollection
		[PInvokeData("xpsobjectmodel.h", MSDNShortId = "4f3acae9-10a0-47ff-9170-a40abe230580")]
		[ComImport, Guid("D1C87F0D-E947-4754-8A25-971478F7E83E"), InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
		public interface IXpsOMDocumentCollection
		{
			/// <summary>Gets the number of IXpsOMDocument interface pointers in the collection.</summary>
			/// <returns>The number of IXpsOMDocument interface pointers in the collection.</returns>
			/// <remarks>For more information about the collection methods, see Working with XPS OM Collection Interfaces.</remarks>
			// https://docs.microsoft.com/en-us/windows/win32/api/xpsobjectmodel/nf-xpsobjectmodel-ixpsomdocumentcollection-getcount
			// HRESULT GetCount( UINT32 *count );
			uint GetCount();

			/// <summary>Gets an IXpsOMDocument interface pointer from a specified location in the collection.</summary>
			/// <returns>The zero-based index of the IXpsOMDocument interface pointer to be obtained.</returns>
			/// <remarks>For more information about the collection methods, see Working with XPS OM Collection Interfaces.</remarks>
			// https://docs.microsoft.com/en-us/windows/win32/api/xpsobjectmodel/nf-xpsobjectmodel-ixpsomdocumentcollection-getat
			// HRESULT GetAt( UINT32 index, IXpsOMDocument **document );
			IXpsOMDocument GetAt([In] uint index);

			/// <summary>
			/// Inserts an IXpsOMDocument interface pointer at a specified location in the collection.
			/// </summary>
			/// <param name="index">The zero-based index of the collection where the interface pointer that is passed in document is to be inserted.</param>
			/// <param name="document">The IXpsOMDocument interface pointer that is to be inserted at the location specified by index.</param>
			/// <remarks>
			/// <para>At the location specified by index, this method inserts the IXpsOMDocument interface pointer that is passed in document. Prior to the insertion, the pointer in this and all subsequent locations is moved up by one index.</para>
			/// <para>For more information about the collection methods, see Working with XPS OM Collection Interfaces.</para>
			/// </remarks>
			// https://docs.microsoft.com/en-us/windows/win32/api/xpsobjectmodel/nf-xpsobjectmodel-ixpsomdocumentcollection-insertat
			// HRESULT InsertAt( UINT32 index, IXpsOMDocument *document );
			void InsertAt([In] uint index, [In] IXpsOMDocument document);

			/// <summary>Removes and releases an IXpsOMDocument interface pointer from a specified location in the collection.</summary>
			/// <param name="index">The zero-based index in the collection from which an IXpsOMDocument interface pointer is to be removed and released.</param>
			/// <remarks>
			/// <para>This method releases the interface referenced by the pointer at the location specified by index. After releasing the interface, this method compacts the collection by reducing by 1 the index of each pointer subsequent to index.</para>
			/// <para>For more information about the collection methods, see Working with XPS OM Collection Interfaces.</para>
			/// </remarks>
			// https://docs.microsoft.com/en-us/windows/win32/api/xpsobjectmodel/nf-xpsobjectmodel-ixpsomdocumentcollection-removeat
			// HRESULT RemoveAt( UINT32 index );
			void RemoveAt([In] uint index);

			/// <summary>Replaces an IXpsOMDocument interface pointer at a specified location in the collection.</summary>
			/// <param name="index">The zero-based index in the collection where an IXpsOMDocument interface pointer is to be replaced.</param>
			/// <param name="document">The IXpsOMDocument interface pointer that will replace current contents at the location specified by index.</param>
			/// <remarks>
			/// <para>At the location specified by index, this method releases the IXpsOMDocument interface referenced by the existing pointer, then writes the pointer that is passed in document.</para>
			/// <para>For more information about the collection methods, see Working with XPS OM Collection Interfaces.</para>
			/// </remarks>
			// https://docs.microsoft.com/en-us/windows/win32/api/xpsobjectmodel/nf-xpsobjectmodel-ixpsomdocumentcollection-setat
			// HRESULT SetAt( UINT32 index, IXpsOMDocument *document );
			void SetAt([In] uint index, [In] IXpsOMDocument document);

			/// <summary>Appends an IXpsOMDocument interface to the end of the collection.</summary>
			/// <param name="document">A pointer to the IXpsOMDocument interface that is to be appended to the collection.</param>
			/// <remarks>For more information about the collection methods, see Working with XPS OM Collection Interfaces.</remarks>
			// https://docs.microsoft.com/en-us/windows/win32/api/xpsobjectmodel/nf-xpsobjectmodel-ixpsomdocumentcollection-append
			// HRESULT Append( IXpsOMDocument *document );
			void Append([In] IXpsOMDocument document);
		}

		/// <summary>The root object that has the XPS document content.</summary>
		/// <remarks>The code example that follows illustrates how to create an instance of this interface.</remarks>
		// https://docs.microsoft.com/en-us/windows/win32/api/xpsobjectmodel/nn-xpsobjectmodel-ixpsomdocumentsequence
		[PInvokeData("xpsobjectmodel.h", MSDNShortId = "472095a4-ecd8-406a-97c2-1a34b4e5184a")]
		[ComImport, Guid("56492EB4-D8D5-425E-8256-4C2B64AD0264"), InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
		public interface IXpsOMDocumentSequence : IXpsOMPart
		{
			/// <summary>Gets the name that will be used when the part is serialized.</summary>
			/// <returns>
			/// A pointer to the IOpcPartUri interface that contains the part name. If the part name has not been set (by the SetPartName
			/// method), a <c>NULL</c> pointer is returned.
			/// </returns>
			// https://docs.microsoft.com/en-us/windows/win32/api/xpsobjectmodel/nf-xpsobjectmodel-ixpsompart-getpartname HRESULT
			// GetPartName( IOpcPartUri **partUri );
			[MethodImpl(MethodImplOptions.InternalCall)]
			[return: MarshalAs(UnmanagedType.Interface)]
			new IOpcPartUri GetPartName();

			/// <summary>Sets the name that will be used when the part is serialized.</summary>
			/// <param name="partUri">
			/// A pointer to the IOpcPartUri interface that contains the name of this part. This parameter cannot be <c>NULL</c>.
			/// </param>
			/// <remarks>
			/// IXpsOMPackageWriter will generate an error if it encounters an XPS document part whose name is the same as that of a part it
			/// has previously serialized.
			/// </remarks>
			// https://docs.microsoft.com/en-us/windows/win32/api/xpsobjectmodel/nf-xpsobjectmodel-ixpsompart-setpartname HRESULT
			// SetPartName( IOpcPartUri *partUri );
			[MethodImpl(MethodImplOptions.InternalCall)]
			new void SetPartName([In] IOpcPartUri partUri);

			/// <summary>Gets a pointer to the IXpsOMPackage interface that contains the document sequence.</summary>
			/// <returns>A pointer to the IXpsOMPackage interface that contains the document sequence. If the document sequence does not belong to a package, a <c>NULL</c> pointer is returned.</returns>
			// https://docs.microsoft.com/en-us/windows/win32/api/xpsobjectmodel/nf-xpsobjectmodel-ixpsomdocumentsequence-getowner
			// HRESULT GetOwner( IXpsOMPackage **package );
			IXpsOMPackage GetOwner();

			/// <summary>Gets a pointer to the IXpsOMDocumentCollection interface, which contains the documents specified in the document sequence.</summary>
			/// <returns>A pointer to the IXpsOMDocumentCollection interface, which contains the documents specified in the document sequence. If the sequence does not have any documents, the <c>IXpsOMDocumentCollection</c> interface will be empty.</returns>
			/// <remarks>If the document sequence does not have any documents, the document collection that is returned in documents will be empty. To get the number of documents in the collection, call the collection's GetCount method.</remarks>
			// https://docs.microsoft.com/en-us/windows/win32/api/xpsobjectmodel/nf-xpsobjectmodel-ixpsomdocumentsequence-getdocuments
			// HRESULT GetDocuments( IXpsOMDocumentCollection **documents );
			IXpsOMDocumentCollection GetDocuments();

			/// <summary>Gets the IXpsOMPrintTicketResource interface to the job-level print ticket that is assigned to the document sequence.</summary>
			/// <returns>A pointer to the IXpsOMPrintTicketResource interface of the job-level print ticket that is assigned to the document sequence. If no <c>IXpsOMPrintTicketResource</c> interface has been assigned to the document sequence, a <c>NULL</c> pointer is returned.</returns>
			/// <remarks>After loading and parsing the resource into the XPS OM, this method might return an error that applies to another resource. This occurs because all of the relationships are parsed when a resource is loaded.</remarks>
			// https://docs.microsoft.com/en-us/windows/win32/api/xpsobjectmodel/nf-xpsobjectmodel-ixpsomdocumentsequence-getprintticketresource
			// HRESULT GetPrintTicketResource( IXpsOMPrintTicketResource **printTicketResource );
			IXpsOMPrintTicketResource GetPrintTicketResource();

			/// <summary>Sets the job-level print ticket resource for the document sequence.</summary>
			/// <param name="printTicketResource">A pointer to the IXpsOMPrintTicketResource interface of the job-level print ticket that will be set for the document sequence. If the document sequence has a print ticket resource, a <c>NULL</c> pointer will release it.</param>
			/// <remarks>If the document contains an IXpsOMPrintTicketResource interface when this method is called, that interface is released before the new <c>IXpsOMPrintTicketResource</c> interface, which is passed in printTicketResource, is set.</remarks>
			// https://docs.microsoft.com/en-us/windows/win32/api/xpsobjectmodel/nf-xpsobjectmodel-ixpsomdocumentsequence-setprintticketresource
			// HRESULT SetPrintTicketResource( IXpsOMPrintTicketResource *printTicketResource );
			void SetPrintTicketResource([In] IXpsOMPrintTicketResource printTicketResource);
		}

		[ComImport, Guid("85FEBC8A-6B63-48A9-AF07-7064E4ECFF30"), InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
		public interface IXpsOMDocumentStructureResource : IXpsOMResource
		{
			/// <summary>Gets the name that will be used when the part is serialized.</summary>
			/// <returns>
			/// A pointer to the IOpcPartUri interface that contains the part name. If the part name has not been set (by the SetPartName
			/// method), a <c>NULL</c> pointer is returned.
			/// </returns>
			// https://docs.microsoft.com/en-us/windows/win32/api/xpsobjectmodel/nf-xpsobjectmodel-ixpsompart-getpartname HRESULT
			// GetPartName( IOpcPartUri **partUri );
			[MethodImpl(MethodImplOptions.InternalCall)]
			new IOpcPartUri GetPartName();

			/// <summary>Sets the name that will be used when the part is serialized.</summary>
			/// <param name="partUri">
			/// A pointer to the IOpcPartUri interface that contains the name of this part. This parameter cannot be <c>NULL</c>.
			/// </param>
			/// <remarks>
			/// IXpsOMPackageWriter will generate an error if it encounters an XPS document part whose name is the same as that of a part it
			/// has previously serialized.
			/// </remarks>
			// https://docs.microsoft.com/en-us/windows/win32/api/xpsobjectmodel/nf-xpsobjectmodel-ixpsompart-setpartname HRESULT
			// SetPartName( IOpcPartUri *partUri );
			[MethodImpl(MethodImplOptions.InternalCall)]
			new void SetPartName([In] IOpcPartUri partUri);

			/// <summary>
			/// Gets a pointer to the IXpsOMDocument interface that contains the resource.
			/// </summary>
			/// <returns>A pointer to the IXpsOMDocument interface that contains the resource. If the resource is not part of a document, a NULL pointer is returned.</returns>
			// https://docs.microsoft.com/en-us/windows/win32/api/xpsobjectmodel/nf-xpsobjectmodel-ixpsomdocumentstructureresource-getowner
			[MethodImpl(MethodImplOptions.InternalCall)]
			IXpsOMDocument GetOwner();

			/// <summary>Gets a new, read-only copy of the stream that is associated with this resource.</summary>
			/// <returns>A new, read-only copy of the stream that is associated with this resource.</returns>
			/// <remarks>
			/// <para>The IStream object returned by this method might return an error of E_PENDING, which indicates that the stream length has not been determined yet. This behavior is different from that of a standard <c>IStream</c> object.</para>
			/// <para>For more information about the content of DocumentStructure part, see the XML Paper Specification.</para>
			/// <para>This method calls the stream's <c>Clone</c> method to create the stream returned in stream. As a result, the performance of this method will depend on that of the stream's <c>Clone</c> method.</para>
			/// </remarks>
			// https://docs.microsoft.com/en-us/windows/win32/api/xpsobjectmodel/nf-xpsobjectmodel-ixpsomdocumentstructureresource-getstream
			// HRESULT GetStream( IStream **stream );
			[MethodImpl(MethodImplOptions.InternalCall)]
			IStream GetStream();

			/// <summary>
			/// Sets the read-only stream to be associated with this resource.
			/// </summary>
			/// <param name="sourceStream">The read-only stream to be associated with this resource.</param>
			/// <param name="partName">The part name to be assigned to this resource.</param>
			/// <remarks>
			/// <para>The calling method should treat this stream as a single-threaded apartment (STA) model object and not re-enter any of the stream interface's methods.</para>
			/// <para>For more information about the content of DocumentStructure part, see the XML Paper Specification.</para>
			/// <para>Because GetStream gets a clone of the stream that is set by this method, the provided stream should have an efficient cloning method. A stream with an inefficient cloning method will reduce the performance of <c>GetStream</c>.</para>
			/// </remarks>
			// https://docs.microsoft.com/en-us/windows/win32/api/xpsobjectmodel/nf-xpsobjectmodel-ixpsomdocumentstructureresource-setcontent
			// HRESULT SetContent( IStream *sourceStream, IOpcPartUri *partName );
			[MethodImpl(MethodImplOptions.InternalCall)]
			void SetContent([In] IStream sourceStream, [In] IOpcPartUri partName);
		}

		/// <summary>Provides an IStream interface to a font resource.</summary>
		/// <remarks>The code example that follows illustrates how to create an instance of this interface.</remarks>
		// https://docs.microsoft.com/en-us/windows/win32/api/xpsobjectmodel/nn-xpsobjectmodel-ixpsomfontresource
		[PInvokeData("xpsobjectmodel.h", MSDNShortId = "dd0ce1c0-1c04-46a8-9075-93de9b3e3062")]
		[ComImport, Guid("A8C45708-47D9-4AF4-8D20-33B48C9B8485"), InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
		public interface IXpsOMFontResource : IXpsOMResource
		{
			/// <summary>Gets the name that will be used when the part is serialized.</summary>
			/// <returns>
			/// A pointer to the IOpcPartUri interface that contains the part name. If the part name has not been set (by the SetPartName
			/// method), a <c>NULL</c> pointer is returned.
			/// </returns>
			// https://docs.microsoft.com/en-us/windows/win32/api/xpsobjectmodel/nf-xpsobjectmodel-ixpsompart-getpartname HRESULT
			// GetPartName( IOpcPartUri **partUri );
			[MethodImpl(MethodImplOptions.InternalCall)]
			new IOpcPartUri GetPartName();

			/// <summary>Sets the name that will be used when the part is serialized.</summary>
			/// <param name="partUri">
			/// A pointer to the IOpcPartUri interface that contains the name of this part. This parameter cannot be <c>NULL</c>.
			/// </param>
			/// <remarks>
			/// IXpsOMPackageWriter will generate an error if it encounters an XPS document part whose name is the same as that of a part it
			/// has previously serialized.
			/// </remarks>
			// https://docs.microsoft.com/en-us/windows/win32/api/xpsobjectmodel/nf-xpsobjectmodel-ixpsompart-setpartname HRESULT
			// SetPartName( IOpcPartUri *partUri );
			[MethodImpl(MethodImplOptions.InternalCall)]
			new void SetPartName([In] IOpcPartUri partUri);

			/// <summary>Gets a new, read-only copy of the stream that is associated with this resource.</summary>
			/// <returns>A new, read-only copy of the stream that is associated with this resource.</returns>
			/// <remarks>
			/// <para>The IStream object returned by this method might return an error of E_PENDING, which indicates that the stream length has not been determined yet. This behavior is different from that of a standard <c>IStream</c> object.</para>
			/// <para>This method calls the stream's <c>Clone</c> method to create the stream returned in stream. As a result, the performance of this method will depend on that of the stream's <c>Clone</c> method.</para>
			/// </remarks>
			// https://docs.microsoft.com/en-us/windows/win32/api/xpsobjectmodel/nf-xpsobjectmodel-ixpsomfontresource-getstream
			// HRESULT GetStream( IStream **readerStream );
			[MethodImpl(MethodImplOptions.InternalCall)]
			IStream GetStream();

			/// <summary>Sets the read-only stream to be associated with this resource.</summary>
			/// <param name="sourceStream">The read-only stream to be associated with this resource.</param>
			/// <param name="embeddingOption">
			/// <para>The XPS_FONT_EMBEDDING value that describes how the resource is to be obfuscated.</para>
			/// <list type="table">
			/// <listheader>
			/// <term>Value</term>
			/// <term>Meaning</term>
			/// </listheader>
			/// <item>
			/// <term>XPS_FONT_EMBEDDING_NORMAL</term>
			/// <term>Font resource is neither obfuscated nor restricted.</term>
			/// </item>
			/// <item>
			/// <term>XPS_FONT_EMBEDDING_OBFUSCATED</term>
			/// <term>Font resource is obfuscated but not restricted.</term>
			/// </item>
			/// <item>
			/// <term>XPS_FONT_EMBEDDING_RESTRICTED</term>
			/// <term>Font resource is both obfuscated and restricted.</term>
			/// </item>
			/// </list>
			/// </param>
			/// <param name="partName">The part name to be assigned to this resource.</param>
			/// <remarks>
			/// <para>The calling method should treat this stream as a single-threaded apartment (STA) model object and not re-enter any of the stream interface's methods.</para>
			/// <para>The stream assigned to this resource should not be obfuscated. Obfuscation of the font resource takes place during serialization.</para>
			/// <para>Providing an obfuscated font stream while setting the embeddingOption to XPS_FONT_EMBEDDING_OBFUSCATED will result in a font that is not obfuscated in the serialized XPS document.</para>
			/// <para>partName resets the part name for this object and is checked against the value of embeddingOption for the proper obfuscation syntax.</para>
			/// <para>Because GetStream gets a clone of the stream that is set by this method, the provided stream should have an efficient cloning method. A stream with an inefficient cloning method will reduce the performance of <c>GetStream</c>.</para>
			/// </remarks>
			// https://docs.microsoft.com/en-us/windows/win32/api/xpsobjectmodel/nf-xpsobjectmodel-ixpsomfontresource-setcontent
			// HRESULT SetContent( IStream *sourceStream, XPS_FONT_EMBEDDING embeddingOption, IOpcPartUri *partName );
			[MethodImpl(MethodImplOptions.InternalCall)]
			void SetContent([In] IStream sourceStream, [In] XPS_FONT_EMBEDDING embeddingOption, [In] IOpcPartUri partName);

			/// <summary>Gets the embedding option that will be applied when the resource is serialized.</summary>
			/// <returns>
			/// <para>The stream's embedding option.</para>
			/// <para>The XPS_FONT_EMBEDDING value describes how the resource is obfuscated. The following possible values are returned in this parameter:</para>
			/// <list type="table">
			/// <listheader>
			/// <term>Value</term>
			/// <term>Meaning</term>
			/// </listheader>
			/// <item>
			/// <term>XPS_FONT_EMBEDDING_NORMAL</term>
			/// <term>Font resource is neither obfuscated nor restricted.</term>
			/// </item>
			/// <item>
			/// <term>XPS_FONT_EMBEDDING_OBFUSCATED</term>
			/// <term>Font resource is obfuscated but not restricted.</term>
			/// </item>
			/// <item>
			/// <term>XPS_FONT_EMBEDDING_RESTRICTED</term>
			/// <term>Font resource is both obfuscated and restricted.</term>
			/// </item>
			/// </list>
			/// </returns>
			// https://docs.microsoft.com/en-us/windows/win32/api/xpsobjectmodel/nf-xpsobjectmodel-ixpsomfontresource-getembeddingoption
			// HRESULT GetEmbeddingOption( XPS_FONT_EMBEDDING *embeddingOption );
			[MethodImpl(MethodImplOptions.InternalCall)]
			XPS_FONT_EMBEDDING GetEmbeddingOption();
		}

		/// <summary>A collection of IXpsOMFontResource interface pointers.</summary>
		/// <remarks>For more information about the collection methods, see Working with XPS OM Collection Interfaces.</remarks>
		// https://docs.microsoft.com/en-us/windows/win32/api/xpsobjectmodel/nn-xpsobjectmodel-ixpsomfontresourcecollection
		[PInvokeData("xpsobjectmodel.h", MSDNShortId = "71153c4c-631b-4f7a-9dd5-8537dcaca150")]
		[ComImport, Guid("70B4A6BB-88D4-4FA8-AAF9-6D9C596FDBAD"), InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
		public interface IXpsOMFontResourceCollection
		{
			/// <summary>Gets the number of IXpsOMFontResource interface pointers in the collection.</summary>
			/// <returns>The number of IXpsOMFontResource interface pointers in the collection.</returns>
			/// <remarks>For more information about the collection methods, see Working with XPS OM Collection Interfaces.</remarks>
			// https://docs.microsoft.com/en-us/windows/win32/api/xpsobjectmodel/nf-xpsobjectmodel-ixpsomfontresourcecollection-getcount
			// HRESULT GetCount( UINT32 *count );
			[MethodImpl(MethodImplOptions.InternalCall)]
			uint GetCount();

			/// <summary>Gets an IXpsOMFontResource interface pointer from a specified location in the collection.</summary>
			/// <param name="index">The zero-based index of the IXpsOMFontResource interface pointer to be obtained.</param>
			/// <returns>The IXpsOMFontResource interface pointer at the location specified by index.</returns>
			/// <remarks>For more information about the collection methods, see Working with XPS OM Collection Interfaces.</remarks>
			// https://docs.microsoft.com/en-us/windows/win32/api/xpsobjectmodel/nf-xpsobjectmodel-ixpsomfontresourcecollection-getat
			// HRESULT GetAt( UINT32 index, IXpsOMFontResource **value );
			[MethodImpl(MethodImplOptions.InternalCall)]
			IXpsOMFontResource GetAt([In] uint index);

			/// <summary>Replaces an IXpsOMFontResource interface pointer at a specified location in the collection.</summary>
			/// <param name="index">The zero-based index in the collection where an IXpsOMFontResource interface pointer is to be replaced.</param>
			/// <param name="value">The IXpsOMFontResource interface pointer that will replace current contents at the location specified by index.</param>
			/// <remarks>
			/// <para>At the location specified by index, this method releases the IXpsOMFontResource interface referenced by the existing pointer, then writes the pointer that is passed in value.</para>
			/// <para>For more information about the collection methods, see Working with XPS OM Collection Interfaces.</para>
			/// </remarks>
			// https://docs.microsoft.com/en-us/windows/win32/api/xpsobjectmodel/nf-xpsobjectmodel-ixpsomfontresourcecollection-setat
			// HRESULT SetAt( UINT32 index, IXpsOMFontResource *value );
			[MethodImpl(MethodImplOptions.InternalCall)]
			void SetAt([In] uint index, [In] IXpsOMFontResource value);

			/// <summary>Inserts an IXpsOMFontResource interface pointer at a specified location in the collection.</summary>
			/// <param name="index">The zero-based index in the collection where the interface pointer that is passed in value is to be inserted.</param>
			/// <param name="value">The IXpsOMFontResource interface pointer that is to be inserted at the location specified by index.</param>
			/// <remarks>
			/// <para>At the location specified by index, this method inserts the IXpsOMFontResource interface pointer that is passed in value. Prior to the insertion, the pointer in this and all subsequent locations is moved up by one index.</para>
			/// <para>For more information about the collection methods, see Working with XPS OM Collection Interfaces.</para>
			/// </remarks>
			// https://docs.microsoft.com/en-us/windows/win32/api/xpsobjectmodel/nf-xpsobjectmodel-ixpsomfontresourcecollection-insertat
			// HRESULT InsertAt( UINT32 index, IXpsOMFontResource *value );
			[MethodImpl(MethodImplOptions.InternalCall)]
			void InsertAt([In] uint index, [In] IXpsOMFontResource value);

			/// <summary>Appends an IXpsOMFontResource interface to the end of the collection.</summary>
			/// <param name="value">A pointer to the IXpsOMFontResource interface that is to be appended to the collection.</param>
			/// <remarks>For more information about the collection methods, see Working with XPS OM Collection Interfaces.</remarks>
			// https://docs.microsoft.com/en-us/windows/win32/api/xpsobjectmodel/nf-xpsobjectmodel-ixpsomfontresourcecollection-append
			// HRESULT Append( IXpsOMFontResource *value );
			[MethodImpl(MethodImplOptions.InternalCall)]
			void Append([In] IXpsOMFontResource value);

			/// <summary>Removes and releases an IXpsOMFontResource interface pointer from a specified location in the collection.</summary>
			/// <param name="index">The zero-based index in the collection from which an IXpsOMFontResource interface pointer is to be removed and released.</param>
			/// <remarks>
			/// <para>This method releases the interface referenced by the pointer at the location specified by index. After releasing the interface, this method compacts the collection by reducing by 1 the index of each pointer subsequent to index.</para>
			/// <para>For more information about the collection methods, see Working with XPS OM Collection Interfaces.</para>
			/// </remarks>
			// https://docs.microsoft.com/en-us/windows/win32/api/xpsobjectmodel/nf-xpsobjectmodel-ixpsomfontresourcecollection-removeat
			// HRESULT RemoveAt( UINT32 index );
			[MethodImpl(MethodImplOptions.InternalCall)]
			void RemoveAt([In] uint index);

			/// <summary>Gets an IXpsOMFontResource interface pointer from the collection by matching the interface's part name.</summary>
			/// <param name="partName">The part name of the IXpsOMFontResource interface to be found in the collection.</param>
			/// <returns>A pointer to the IXpsOMFontResource interface that has the matching part name. If a matching interface is not found in the collection, a <c>NULL</c> pointer is returned.</returns>
			// https://docs.microsoft.com/en-us/windows/win32/api/xpsobjectmodel/nf-xpsobjectmodel-ixpsomfontresourcecollection-getbypartname
			// HRESULT GetByPartName( IOpcPartUri *partName, IXpsOMFontResource **part );
			[MethodImpl(MethodImplOptions.InternalCall)]
			IXpsOMFontResource GetByPartName([In] IOpcPartUri partName);
		}

		/// <summary>Describes the shape of a path or of a clipping region.</summary>
		/// <remarks>The code example that follows illustrates how to create an instance of this interface.</remarks>
		// https://docs.microsoft.com/en-us/windows/win32/api/xpsobjectmodel/nn-xpsobjectmodel-ixpsomgeometry
		[PInvokeData("xpsobjectmodel.h", MSDNShortId = "d3f74c1e-49ef-40ee-a2f4-b6d198b57624")]
		[ComImport, Guid("64FCF3D7-4D58-44BA-AD73-A13AF6492072"), InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
		public interface IXpsOMGeometry : IXpsOMShareable
		{
			/// <summary>Gets the <c>IUnknown</c> interface of the parent.</summary>
			/// <returns>A pointer to the <c>IUnknown</c> interface of the parent.</returns>
			// https://docs.microsoft.com/en-us/windows/win32/api/xpsobjectmodel/nf-xpsobjectmodel-ixpsomshareable-getowner
			// HRESULT GetOwner( IUnknown **owner );
			[return: MarshalAs(UnmanagedType.IUnknown)]
			new object GetOwner();

			/// <summary>Gets the object type of the interface.</summary>
			/// <returns>The XPS_OBJECT_TYPE value that describes the interface that is derived from IXpsOMShareable.</returns>
			// https://docs.microsoft.com/en-us/windows/win32/api/xpsobjectmodel/nf-xpsobjectmodel-ixpsomshareable-gettype
			// HRESULT GetType( XPS_OBJECT_TYPE *type );
			new XPS_OBJECT_TYPE GetType();

			/// <summary>Gets a pointer to the geometry's IXpsOMGeometryFigureCollection interface, which contains the collection of figures that make up this geometry.</summary>
			/// <returns>A pointer to the IXpsOMGeometryFigureCollection interface.</returns>
			// https://docs.microsoft.com/en-us/windows/win32/api/xpsobjectmodel/nf-xpsobjectmodel-ixpsomgeometry-getfigures
			// HRESULT GetFigures( IXpsOMGeometryFigureCollection **figures );
			IXpsOMGeometryFigureCollection GetFigures();

			/// <summary>Gets the XPS_FILL_RULE value that describes the fill rule to be used.</summary>
			/// <returns>The XPS_FILL_RULE value that describes the fill rule to be used.</returns>
			/// <remarks>
			/// <para>For more information about how the file rule determines whether a point is inside the fill region, see XPS_FILL_RULE.</para>
			/// <para>The value that is returned in fillRule corresponds to the <c>FillRule</c> attribute of the <c>PathGeometry</c> element in the document markup.</para>
			/// </remarks>
			// https://docs.microsoft.com/en-us/windows/win32/api/xpsobjectmodel/nf-xpsobjectmodel-ixpsomgeometry-getfillrule
			// HRESULT GetFillRule( XPS_FILL_RULE *fillRule );
			XPS_FILL_RULE GetFillRule();

			/// <summary>
			/// Sets the XPS_FILL_RULE value that describes the fill rule to be used.
			/// </summary>
			/// <param name="fillRule">The XPS_FILL_RULE value that describes the fill rule to be used.</param>
			/// <remarks>
			/// <para>For more information about how the file rule determines whether a point is inside the fill region, see XPS_FILL_RULE.</para>
			/// <para>In the document markup, this value corresponds to the <c>FillRule</c> attribute of the <c>PathGeometry</c> element.</para>
			/// </remarks>
			// https://docs.microsoft.com/en-us/windows/win32/api/xpsobjectmodel/nf-xpsobjectmodel-ixpsomgeometry-setfillrule
			// HRESULT SetFillRule( XPS_FILL_RULE fillRule );
			void SetFillRule([In] XPS_FILL_RULE fillRule);

			/// <summary>Gets a pointer to the geometry's IXpsOMMatrixTransform interface, which contains the resolved matrix transform for the geometry.</summary>
			/// <returns>
			/// <para>A pointer to the geometry's IXpsOMMatrixTransform interface, which contains the resolved matrix transform for the geometry. If a matrix transform has not been set, a <c>NULL</c> pointer will be returned.</para>
			/// <para>The value that is returned in this parameter depends on which method has most recently been called to set the transform.</para>
			/// <list type="table">
			/// <listheader>
			/// <term>Most recent method called</term>
			/// <term>Object that is returned in transform</term>
			/// </listheader>
			/// <item>
			/// <term>SetTransformLocal</term>
			/// <term>The local transform that is set by SetTransformLocal.</term>
			/// </item>
			/// <item>
			/// <term>SetTransformLookup</term>
			/// <term>The shared transform retrieved, with a lookup key that matches the key that is set by SetTransformLookup, from the resource directory.</term>
			/// </item>
			/// <item>
			/// <term>Neither SetTransformLocal nor SetTransformLookup has been called yet.</term>
			/// <term>NULL pointer.</term>
			/// </item>
			/// </list>
			/// </returns>
			// https://docs.microsoft.com/en-us/windows/win32/api/xpsobjectmodel/nf-xpsobjectmodel-ixpsomgeometry-gettransform
			// HRESULT GetTransform( IXpsOMMatrixTransform **transform );
			IXpsOMMatrixTransform GetTransform();

			/// <summary>Gets a pointer to the IXpsOMMatrixTransform interface that contains the local, unshared matrix transform for the geometry.</summary>
			/// <returns>
			/// <para>A pointer to the IXpsOMMatrixTransform interface that contains the local, unshared matrix transform for the geometry. A <c>NULL</c> pointer is returned if a local matrix transform has not been set or a matrix transform lookup key has been set.</para>
			/// <para>The value that is returned in this parameter depends on which method has most recently been called to set the transform.</para>
			/// <list type="table">
			/// <listheader>
			/// <term>Most recent method called</term>
			/// <term>Object that is returned in transform</term>
			/// </listheader>
			/// <item>
			/// <term>SetTransformLocal</term>
			/// <term>The local transform that is set by SetTransformLocal.</term>
			/// </item>
			/// <item>
			/// <term>SetTransformLookup</term>
			/// <term>NULL pointer.</term>
			/// </item>
			/// <item>
			/// <term>Neither SetTransformLocal nor SetTransformLookup has been called yet.</term>
			/// <term>NULL pointer.</term>
			/// </item>
			/// </list>
			/// </returns>
			// https://docs.microsoft.com/en-us/windows/win32/api/xpsobjectmodel/nf-xpsobjectmodel-ixpsomgeometry-gettransformlocal
			// HRESULT GetTransformLocal( IXpsOMMatrixTransform **transform );
			IXpsOMMatrixTransform GetTransformLocal();

			/// <summary>
			/// Sets the local, unshared matrix transform.
			/// </summary>
			/// <param name="transform">A pointer to the IXpsOMMatrixTransform interface to be set as the local, unshared matrix transform for the geometry.</param>
			/// <remarks>
			/// <para>After you call <c>SetTransformLocal</c>, the transform lookup key is released and GetTransformLookup returns a <c>NULL</c> pointer in the lookup parameter. The table that follows explains the relationship between the local and lookup values of this property.</para>
			/// <list type="table">
			///   <listheader>
			///     <term>Most recent method called</term>
			///     <term>Object that is returned in transform by GetTransform</term>
			///     <term>Object that is returned in transform by GetTransformLocal</term>
			///     <term>Object that is returned in lookup by GetTransformLookup</term>
			///   </listheader>
			///   <item>
			///     <term>SetTransformLocal (this method)</term>
			///     <term>The local transform that is set by SetTransformLocal.</term>
			///     <term>The local transform that is set by SetTransformLocal.</term>
			///     <term>NULL pointer.</term>
			///   </item>
			///   <item>
			///     <term>SetTransformLookup</term>
			///     <term>The shared transform retrieved, with a lookup key that matches the key that is set by SetTransformLookup, from the resource directory.</term>
			///     <term>NULL pointer.</term>
			///     <term>The lookup key that is set by SetTransformLookup.</term>
			///   </item>
			///   <item>
			///     <term>Neither SetTransformLocal nor SetTransformLookup has been called yet.</term>
			///     <term>NULL pointer.</term>
			///     <term>NULL pointer.</term>
			///     <term>NULL pointer.</term>
			///   </item>
			/// </list>
			/// </remarks>
			// https://docs.microsoft.com/en-us/windows/win32/api/xpsobjectmodel/nf-xpsobjectmodel-ixpsomgeometry-settransformlocal
			// HRESULT SetTransformLocal( IXpsOMMatrixTransform *transform );
			void SetTransformLocal([In] IXpsOMMatrixTransform transform);

			/// <summary>Gets the lookup key for the IXpsOMMatrixTransform interface that contains the resolved matrix transform for the geometry. The matrix transform is stored in a resource dictionary.</summary>
			/// <returns>
			/// <para>The lookup key for the IXpsOMMatrixTransform interface in a resource dictionary. A <c>NULL</c> pointer is returned if a matrix transform lookup key has not been set or if a local matrix transform has been set.</para>
			/// <para>The value that is returned in this parameter depends on which method has most recently been called to set the transform.</para>
			/// <list type="table">
			/// <listheader>
			/// <term>Most recent method called</term>
			/// <term>Object that is returned in lookup</term>
			/// </listheader>
			/// <item>
			/// <term>SetTransformLocal</term>
			/// <term>NULL pointer.</term>
			/// </item>
			/// <item>
			/// <term>SetTransformLookup</term>
			/// <term>The lookup key set by SetTransformLookup.</term>
			/// </item>
			/// <item>
			/// <term>Neither SetTransformLocal nor SetTransformLookup has been called yet.</term>
			/// <term>NULL pointer.</term>
			/// </item>
			/// </list>
			/// </returns>
			// https://docs.microsoft.com/en-us/windows/win32/api/xpsobjectmodel/nf-xpsobjectmodel-ixpsomgeometry-gettransformlookup
			// HRESULT GetTransformLookup( LPWSTR *lookup );
			SafeCoTaskMemString GetTransformLookup();

			/// <summary>
			/// Sets the lookup key name of a shared matrix transform in a resource dictionary.
			/// </summary>
			/// <param name="lookup">The key name of the shared matrix transform in the resource dictionary.</param>
			/// <remarks>
			/// <para>After you call <c>SetTransformLookup</c>, the local transform is released and GetTransformLocal returns a <c>NULL</c> pointer in the transform parameter. The table that follows explains the relationship between the local and lookup values of this property.</para>
			/// <list type="table">
			///   <listheader>
			///     <term>Most recent method called</term>
			///     <term>Object that is returned in transform by GetTransform</term>
			///     <term>Object that is returned in transform by GetTransformLocal</term>
			///     <term>Object that is returned in lookup by GetTransformLookup</term>
			///   </listheader>
			///   <item>
			///     <term>SetTransformLocal</term>
			///     <term>The local transform that is set by SetTransformLocal.</term>
			///     <term>The local transform that is set by SetTransformLocal.</term>
			///     <term>NULL pointer.</term>
			///   </item>
			///   <item>
			///     <term>SetTransformLookup (this method)</term>
			///     <term>The shared transform retrieved, with a lookup key that matches the key set by SetTransformLookup, from the resource directory.</term>
			///     <term>NULL pointer.</term>
			///     <term>The lookup key that is set by SetTransformLookup.</term>
			///   </item>
			///   <item>
			///     <term>Neither SetTransformLocal nor SetTransformLookup has been called yet.</term>
			///     <term>NULL pointer.</term>
			///     <term>NULL pointer.</term>
			///     <term>NULL pointer.</term>
			///   </item>
			/// </list>
			/// </remarks>
			// https://docs.microsoft.com/en-us/windows/win32/api/xpsobjectmodel/nf-xpsobjectmodel-ixpsomgeometry-settransformlookup
			// HRESULT SetTransformLookup( LPCWSTR lookup );
			void SetTransformLookup([In, MarshalAs(UnmanagedType.LPWStr)] string lookup);

			/// <summary>Makes a deep copy of the interface.</summary>
			/// <returns>A pointer to the copy of the interface.</returns>
			// https://docs.microsoft.com/en-us/windows/win32/api/xpsobjectmodel/nf-xpsobjectmodel-ixpsomgeometry-clone
			// HRESULT Clone( IXpsOMGeometry **geometry );
			IXpsOMGeometry Clone();
		}

		/// <summary>Describes one portion of the path or clipping region that is specified by an IXpsOMGeometry interface.</summary>
		/// <remarks>
		/// <para>The <c>IXpsOMGeometryFigure</c> corresponds to the <c>PathFigure</c> element in XPS markup.</para>
		/// <para>The code example that follows illustrates how to create an instance of this interface.</para>
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows/win32/api/xpsobjectmodel/nn-xpsobjectmodel-ixpsomgeometryfigure
		[PInvokeData("xpsobjectmodel.h", MSDNShortId = "e76a14ce-cfc3-4a50-855e-f5779b9fc261")]
		[ComImport, Guid("D410DC83-908C-443E-8947-B1795D3C165A"), InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
		public interface IXpsOMGeometryFigure
		{
			/// <summary>Gets a pointer to the IXpsOMGeometry interface that contains the geometry figure.</summary>
			/// <returns>A pointer to the IXpsOMGeometry interface that contains the geometry figure. If the interface is not assigned to a geometry, a <c>NULL</c> pointer is returned.</returns>
			// https://docs.microsoft.com/en-us/windows/win32/api/xpsobjectmodel/nf-xpsobjectmodel-ixpsomgeometryfigure-getowner
			// HRESULT GetOwner( IXpsOMGeometry **owner );
			IXpsOMGeometry GetOwner();

			/// <summary>
			/// Gets the segment data points for the geometry figure.
			/// </summary>
			/// <param name="dataCount"><para>The size of the array referenced by the segmentData parameter.</para>
			/// <para>If the method returns successfully, dataCount will contain the number of elements returned in the array that is referenced by segmentData.</para>
			/// <para>If segmentData is set to <c>NULL</c> when the method is called, dataCount must be set to zero.</para>
			/// <para>If a <c>NULL</c> pointer is returned in segmentData, dataCount will contain the required buffer size as the number of elements.</para></param>
			/// <param name="segmentData"><para>The address of an array that has the same number of elements as specified in dataCount. This value can be set to <c>NULL</c> if the caller requires that the method return only the required buffer size in dataCount.</para>
			/// <para>If the array is large enough, this method copies the segment data points into the array and returns, in dataCount, the number of data points that are copied. If segmentData is set to <c>NULL</c> or references a buffer that is not large enough, a <c>NULL</c> pointer will be returned, no data will be copied, and dataCount will contain the required buffer size specified as the number of elements.</para></param>
			/// <remarks>
			/// <para>To determine the required size of the segment data array before calling this method, call GetSegmentDataCount.</para>
			/// <para>A geometry segment is described by the start point, the segment type, and additional parameters whose values are determined by the segment type. The coordinates for the start point of the first segment are a property of the geometry figure and are set by calling SetStartPoint. The start point of each subsequent segment is the end point of the preceding segment.</para>
			/// <para>The values in the array returned in the segmentData parameter will correspond with the XPS_SEGMENT_TYPE values in the array returned by the GetSegmentTypes method in the segmentTypes parameter. To read the segment data values correctly, you will need to know the type of each segment in the geometry figure. For example, if the first line segment has a segment type value of <c>XPS_SEGMENT_TYPE_LINE</c>, the first two data values in the segmentData array will be the x and y coordinates of the end point of that segment; if the next segment has a segment type value of <c>XPS_SEGMENT_TYPE_BEZIER</c>, the next six values in the segmentData array will describe the characteristics of that segment; and so on for each line segment in the geometry figure.</para>
			/// <para>The table that follows describes the specific set of data values that are returned for each segment type. For an example of how to access this data in a program, see the code example that follows.</para>
			/// <list type="table">
			///   <listheader>
			///     <term>Segment type</term>
			///     <term>Required data values</term>
			///   </listheader>
			///   <item>
			///     <term>XPS_SEGMENT_TYPE_LINE</term>
			///     <term>Two data values: x-coordinate of the segment line's end point. y-coordinate of the segment line's end point.</term>
			///   </item>
			///   <item>
			///     <term>XPS_SEGMENT_TYPE_ARC_LARGE_CLOCKWISE</term>
			///     <term>Five data values: x-coordinate of the arc's end point. y-coordinate of the arc's end point. Length of the ellipse's radius along the x-axis. Length of the ellipse's radius along the y-axis. Rotation angle.</term>
			///   </item>
			///   <item>
			///     <term>XPS_SEGMENT_TYPE_ARC_SMALL_CLOCKWISE</term>
			///     <term>Five data values: x-coordinate of the arc's end point. y-coordinate of the arc's end point. Length of the ellipse's radius along the x-axis. Length of the ellipse's radius along the y-axis. Rotation angle.</term>
			///   </item>
			///   <item>
			///     <term>XPS_SEGMENT_TYPE_ARC_LARGE_COUNTERCLOCKWISE</term>
			///     <term>Five data values: x-coordinate of the arc's end point. y-coordinate of the arc's end point. Length of the ellipse's radius along the x-axis. Length of the ellipse's radius along the y-axis. Rotation angle.</term>
			///   </item>
			///   <item>
			///     <term>XPS_SEGMENT_TYPE_ARC_SMALL_COUNTERCLOCKWISE</term>
			///     <term>Five data values: x-coordinate of the arc's end point. y-coordinate of the arc's end point. Length of the ellipse's radius along the x-axis. Length of the ellipse's radius along the y-axis. Rotation angle.</term>
			///   </item>
			///   <item>
			///     <term>XPS_SEGMENT_TYPE_BEZIER</term>
			///     <term>Six data values: x-coordinate of the Bezier curve's first control point. y-coordinate of the Bezier curve's first control point. x-coordinate of the Bezier curve's second control point. y-coordinate of the Bezier curve's second control point. x-coordinate of the Bezier curve's end point. y-coordinate of the Bezier curve's end point.</term>
			///   </item>
			///   <item>
			///     <term>XPS_SEGMENT_TYPE_QUADRATIC_BEZIER</term>
			///     <term>Four data values: x-coordinate of the Quad Bezier curve's control point. y-coordinate of the Quad Bezier curve's control point. x-coordinate of the Quad Bezier curve's end point. y-coordinate of the Quad Bezier curve's end point.</term>
			///   </item>
			/// </list>
			/// <para>The following code example accesses the different data points of each segment type in a geometry figure.</para>
			/// </remarks>
			// https://docs.microsoft.com/en-us/windows/win32/api/xpsobjectmodel/nf-xpsobjectmodel-ixpsomgeometryfigure-getsegmentdata
			// HRESULT GetSegmentData( UINT32 *dataCount, FLOAT *segmentData );
			void GetSegmentData([In, Out] ref uint dataCount, [In, Out] float[] segmentData);

			/// <summary>Gets the types of segments in the figure.</summary>
			/// <param name="segmentCount">
			/// <para>The size of the array that is referenced by segmentTypes (see below). This parameter must not be <c>NULL</c>.</para>
			/// <para>If the method returns successfully, segmentCount will contain the number of elements that are returned in the array referenced by segmentTypes.</para>
			/// <para>If segmentTypes is <c>NULL</c> when the method is called, segmentCount must be set to zero.</para>
			/// <para>If a <c>NULL</c> pointer is returned in segmentTypes, the value of segmentCount will contain the required buffer size, specified as the number of elements.</para>
			/// </param>
			/// <param name="segmentTypes">
			/// <para>An array of XPS_SEGMENT_TYPE values that has the same number of elements as specified in segmentCount. If the caller requires that only the specified buffer size be returned, set this value to <c>NULL</c>.</para>
			/// <para>If the array is large enough, this method will copy the XPS_SEGMENT_TYPE values into the array and return, in segmentCount, the number of the copied values. If segmentTypes is <c>NULL</c> or references a buffer that is not large enough, a <c>NULL</c> pointer will be returned, no data will be copied, and segmentCount will contain the required buffer size, which is specified as the number of elements.</para>
			/// </param>
			/// <remarks>For an example of how to use this method in a program, see the code example in GetSegmentData.</remarks>
			// https://docs.microsoft.com/en-us/windows/win32/api/xpsobjectmodel/nf-xpsobjectmodel-ixpsomgeometryfigure-getsegmenttypes
			// HRESULT GetSegmentTypes( UINT32 *segmentCount, XPS_SEGMENT_TYPE *segmentTypes );
			void GetSegmentTypes([In, Out] ref uint segmentCount, [In, Out] XPS_SEGMENT_TYPE[] segmentTypes);

			/// <summary>
			/// Gets stroke definitions for the figure's segments.
			/// </summary>
			/// <param name="segmentCount"><para>The size of the array that is referenced by segmentStrokes. This parameter must not be <c>NULL</c>.</para>
			/// <para>If the method returns successfully, segmentCount will contain the number of elements that are returned in the array referenced by segmentStrokes.</para>
			/// <para>If segmentStrokes is <c>NULL</c> when the method is called, segmentCount must be set to zero.</para>
			/// <para>If a <c>NULL</c> pointer is returned in segmentStrokes, the value of segmentCount will contain the required buffer size, specified as the number of elements.</para></param>
			/// <param name="segmentStrokes"><para>An array that has the same number of elements as specified in segmentCount. If the caller requires that this method return only the required buffer size, set this value to <c>NULL</c>.</para>
			/// <para>If the array is large enough, this method copies the segment stroke values into the array and returns, in segmentCount, the number of copied segment stroke values. If segmentData is <c>NULL</c> or references a buffer that is not large enough, a <c>NULL</c> pointer will be returned, no data will be copied, and segmentCount will contain the required buffer size that is specified as the number of elements.</para>
			/// <para>The following table shows the possible values of an element in the array that is referenced by segmentStrokes.</para>
			/// <list type="table">
			///   <listheader>
			///     <term>Value</term>
			///     <term>Meaning</term>
			///   </listheader>
			///   <item>
			///     <term>TRUE</term>
			///     <term>The segment is stroked.</term>
			///   </item>
			///   <item>
			///     <term>FALSE</term>
			///     <term>The segment is not stroked.</term>
			///   </item>
			/// </list></param>
			// https://docs.microsoft.com/en-us/windows/win32/api/xpsobjectmodel/nf-xpsobjectmodel-ixpsomgeometryfigure-getsegmentstrokes
			// HRESULT GetSegmentStrokes( UINT32 *segmentCount, BOOL *segmentStrokes );
			void GetSegmentStrokes([In, Out] ref uint segmentCount, [In, Out, MarshalAs(UnmanagedType.LPArray, ArraySubType = UnmanagedType.Bool)] bool[] segmentStrokes);

			/// <summary>
			/// Sets the segment information and data points for segments in the figure.
			/// </summary>
			/// <param name="segmentCount"><para>The number of segments.</para>
			/// <para>This value is also the number of elements in the arrays that are referenced by segmentTypes and segmentStrokes.</para></param>
			/// <param name="segmentDataCount"><para>The number of segment data points.</para>
			/// <para>This value is also the number of elements in the array that is referenced by segmentData.</para></param>
			/// <param name="segmentTypes">An array of XPS_SEGMENT_TYPE variables. The value of segmentCount specifies the number of elements in this array.</param>
			/// <param name="segmentData">An array of segment data values. The value of segmentDataCount specifies the number of elements in this array.</param>
			/// <param name="segmentStrokes">An array of segment stroke values. The value of segmentCount specifies the number of elements in this array.</param>
			/// <remarks>
			/// <para>A geometry segment is described by the start point, the segment type, and additional parameters whose values are determined by the segment type. The coordinates for the start point of the first segment are a property of the geometry figure and are set by calling SetStartPoint. The start point of each subsequent segment is the end point of the preceding segment.</para>
			/// <para>The number of data values that define a line segment depends on the segment type. The table that follows describes the specific set of required data values that must be used for each segment type. The values in the segment data array that is passed in the segmentData parameter must correspond with the XPS_SEGMENT_TYPE values in the array that is passed in the segmentTypes parameter. For example, if the first line segment has a segment type value of <c>XPS_SEGMENT_TYPE_LINE</c>, the first two data values in the segmentData array will be the x and y coordinates of the end point of that segment; if the next segment has a segment type value of <c>XPS_SEGMENT_TYPE_BEZIER</c>, the next six values in the segmentData array will describe the characteristics of that segment; and so on for each line segment in the geometry figure.</para>
			/// <list type="table">
			///   <listheader>
			///     <term>Segment type</term>
			///     <term>Required data values</term>
			///   </listheader>
			///   <item>
			///     <term>XPS_SEGMENT_TYPE_LINE</term>
			///     <term>Two data values: x-coordinate of the segment line's end point. y-coordinate of the segment line's end point.</term>
			///   </item>
			///   <item>
			///     <term>XPS_SEGMENT_TYPE_ARC_LARGE_CLOCKWISE</term>
			///     <term>Five data values: x-coordinate of the arc's end point. y-coordinate of the arc's end point. Length of the ellipse's radius along the x-axis. Length of the ellipse's radius along the y-axis. Rotation angle.</term>
			///   </item>
			///   <item>
			///     <term>XPS_SEGMENT_TYPE_ARC_SMALL_CLOCKWISE</term>
			///     <term>Five data values: x-coordinate of the arc's end point. y-coordinate of the arc's end point. Length of the ellipse's radius along the x-axis. Length of the ellipse's radius along the y-axis. Rotation angle.</term>
			///   </item>
			///   <item>
			///     <term>XPS_SEGMENT_TYPE_ARC_LARGE_COUNTERCLOCKWISE</term>
			///     <term>Five data values: x-coordinate of the arc's end point. y-coordinate of the arc's end point. Length of the ellipse's radius along the x-axis. Length of the ellipse's radius along the y-axis. Rotation angle.</term>
			///   </item>
			///   <item>
			///     <term>XPS_SEGMENT_TYPE_ARC_SMALL_COUNTERCLOCKWISE</term>
			///     <term>Five data values: x-coordinate of the arc's end point. y-coordinate of the arc's end point. Length of the ellipse's radius along the x-axis. Length of the ellipse's radius along the y-axis. Rotation angle.</term>
			///   </item>
			///   <item>
			///     <term>XPS_SEGMENT_TYPE_BEZIER</term>
			///     <term>Six data values: x-coordinate of the Bezier curve's first control point. y-coordinate of the Bezier curve's first control point. x-coordinate of the Bezier curve's second control point. y-coordinate of the Bezier curve's second control point. x-coordinate of the Bezier curve's end point. y-coordinate of the Bezier curve's end point.</term>
			///   </item>
			///   <item>
			///     <term>XPS_SEGMENT_TYPE_QUADRATIC_BEZIER</term>
			///     <term>Four data values: x-coordinate of the Quad Bezier curve's control point. y-coordinate of the Quad Bezier curve's control point. x-coordinate of the Quad Bezier curve's end point. y-coordinate of the Quad Bezier curve's end point.</term>
			///   </item>
			/// </list>
			/// <para>To get the segment types in the figure, call GetSegmentTypes.</para>
			/// <para>The following code examples demonstrate one way to create and populate the buffers required by <c>SetSegments</c>.</para>
			/// <para>In the first code example, the <c>AddSegmentDataToArrays</c> method takes the data points that describe a single segment and stores them in the three different data buffers required by the <c>SetSegments</c> method. The data buffers that are passed as arguments to <c>AddSegmentDataToArrays</c> are managed by the calling method as shown in the code example that follows <c>AddSegmentDataToArrays</c>.</para>
			/// <para>In this code example, <c>UpdateSegmentData</c> creates the data buffers required by the <c>SetSegments</c> method and calls the <c>AddSegmentDataToArrays</c> method from the preceding code example to populate them with the segment data. After the buffers have been populated, <c>SetSegments</c> is called to add this data to the geometry figure.</para>
			/// </remarks>
			// https://docs.microsoft.com/en-us/windows/win32/api/xpsobjectmodel/nf-xpsobjectmodel-ixpsomgeometryfigure-setsegments
			// HRESULT SetSegments( UINT32 segmentCount, UINT32 segmentDataCount, const XPS_SEGMENT_TYPE *segmentTypes, const FLOAT *segmentData, const BOOL *segmentStrokes );
			void SetSegments([In] uint segmentCount, [In] uint segmentDataCount, [In] XPS_SEGMENT_TYPE[] segmentTypes, [In] float[] segmentData, [In, MarshalAs(UnmanagedType.LPArray, ArraySubType = UnmanagedType.Bool)] bool[] segmentStrokes);

			/// <summary>Gets the starting point of the figure.</summary>
			/// <returns>The coordinates of the starting point of the figure.</returns>
			/// <remarks>In the document markup, the value returned in startPoint corresponds to that of the <c>StartPoint</c> attribute of the <c>PathFigure</c> element.</remarks>
			// https://docs.microsoft.com/en-us/windows/win32/api/xpsobjectmodel/nf-xpsobjectmodel-ixpsomgeometryfigure-getstartpoint
			// HRESULT GetStartPoint( XPS_POINT *startPoint );
			XPS_POINT GetStartPoint();

			/// <summary>
			/// Sets the starting point of the figure.
			/// </summary>
			/// <param name="startPoint">The coordinates of the starting point of the figure.</param>
			// https://docs.microsoft.com/en-us/windows/win32/api/xpsobjectmodel/nf-xpsobjectmodel-ixpsomgeometryfigure-setstartpoint
			// HRESULT SetStartPoint( const XPS_POINT *startPoint );
			void SetStartPoint(in XPS_POINT startPoint);

			/// <summary>Gets a value that indicates whether the figure is closed.</summary>
			/// <returns>
			/// <para>The Boolean value that indicates whether the figure is closed.</para>
			/// <list type="table">
			/// <listheader>
			/// <term>Value</term>
			/// <term>Meaning</term>
			/// </listheader>
			/// <item>
			/// <term>TRUE</term>
			/// <term>The figure is closed. The line segment between the start and end points of the figure will be stroked to close the shape.</term>
			/// </item>
			/// <item>
			/// <term>FALSE</term>
			/// <term>The figure is open. No line segment will be stroked between the start and end points of the figure.</term>
			/// </item>
			/// </list>
			/// </returns>
			/// <remarks>
			/// <para>This value only applies if the <c>PathFigure</c> attribute is used in the <c>Path</c> element that specifies a stroke.</para>
			/// <para>A closed figure adds a line segment between the start point and the end point of the figure to close the shape.</para>
			/// <para>This value corresponds to that of the <c>IsClosed</c> element of the <c>PathFigure</c> element in the document markup.</para>
			/// </remarks>
			// https://docs.microsoft.com/en-us/windows/win32/api/xpsobjectmodel/nf-xpsobjectmodel-ixpsomgeometryfigure-getisclosed
			// HRESULT GetIsClosed( BOOL *isClosed );
			[return: MarshalAs(UnmanagedType.Bool)]
			bool GetIsClosed();

			/// <summary>
			/// Sets a value that indicates whether the figure is closed.
			/// </summary>
			/// <param name="isClosed"><para>The value to be set.</para>
			/// <list type="table">
			///   <listheader>
			///     <term>Value</term>
			///     <term>Meaning</term>
			///   </listheader>
			///   <item>
			///     <term>TRUE</term>
			///     <term>The figure is closed. A line segment between the start point and the last point defined in the figure will be stroked.</term>
			///   </item>
			///   <item>
			///     <term>FALSE</term>
			///     <term>The figure is open. There is no line segment between the start point and the last point defined in the figure.</term>
			///   </item>
			/// </list></param>
			/// <remarks>
			/// <para>This value only applies if the <c>PathFigure</c> attribute is used in the <c>Path</c> element that specifies a stroke.</para>
			/// <para>A closed figure adds a line segment between the start point and the end point of the figure to close the shape.</para>
			/// <para>This value corresponds to that of the <c>IsClosed</c> element of the <c>PathFigure</c> element in the document markup.</para>
			/// </remarks>
			// https://docs.microsoft.com/en-us/windows/win32/api/xpsobjectmodel/nf-xpsobjectmodel-ixpsomgeometryfigure-setisclosed
			// HRESULT SetIsClosed( BOOL isClosed );
			void SetIsClosed([In, MarshalAs(UnmanagedType.Bool)] bool isClosed);

			/// <summary>Gets a value that indicates whether the figure is filled.</summary>
			/// <returns>
			/// <para>The Boolean value that indicates whether the figure is filled.</para>
			/// <list type="table">
			/// <listheader>
			/// <term>Value</term>
			/// <term>Meaning</term>
			/// </listheader>
			/// <item>
			/// <term>TRUE</term>
			/// <term>The figure is filled by a brush.</term>
			/// </item>
			/// <item>
			/// <term>FALSE</term>
			/// <term>The figure is not filled.</term>
			/// </item>
			/// </list>
			/// </returns>
			/// <remarks>This value corresponds to that of the <c>IsFilled</c> attribute of the <c>PathFigure</c> element in the document markup.</remarks>
			// https://docs.microsoft.com/en-us/windows/win32/api/xpsobjectmodel/nf-xpsobjectmodel-ixpsomgeometryfigure-getisfilled
			// HRESULT GetIsFilled( BOOL *isFilled );
			[return: MarshalAs(UnmanagedType.Bool)]
			bool GetIsFilled();

			/// <summary>
			/// Sets a value that indicates whether the figure is filled.
			/// </summary>
			/// <param name="isFilled"><para>The value to be set.</para>
			/// <list type="table">
			///   <listheader>
			///     <term>Value</term>
			///     <term>Meaning</term>
			///   </listheader>
			///   <item>
			///     <term>TRUE</term>
			///     <term>The figure is filled by a brush.</term>
			///   </item>
			///   <item>
			///     <term>FALSE</term>
			///     <term>The figure is not filled.</term>
			///   </item>
			/// </list></param>
			/// <remarks>
			/// In the document markup, the value returned in isFilled corresponds to that of the <c>IsFilled</c> attribute of the <c>PathFigure</c> element.
			/// </remarks>
			// https://docs.microsoft.com/en-us/windows/win32/api/xpsobjectmodel/nf-xpsobjectmodel-ixpsomgeometryfigure-setisfilled
			// HRESULT SetIsFilled( BOOL isFilled );
			void SetIsFilled([In, MarshalAs(UnmanagedType.Bool)] bool isFilled);

			/// <summary>Gets the number of segments in the figure.</summary>
			/// <returns>The number of segments in the figure.</returns>
			/// <remarks>For an example of how to use this method in a program, see the code example in GetSegmentData.</remarks>
			// https://docs.microsoft.com/en-us/windows/win32/api/xpsobjectmodel/nf-xpsobjectmodel-ixpsomgeometryfigure-getsegmentcount
			// HRESULT GetSegmentCount( UINT32 *segmentCount );
			uint GetSegmentCount();

			/// <summary>Gets the number of segment data points in the figure.</summary>
			/// <returns>The number of segment data points. segmentDataCount must not be <c>NULL</c> when the method is called.</returns>
			/// <remarks>
			/// <para>To get the segment data points, call GetSegmentData.</para>
			/// <para>For an example of how to use this method in a program, see the code example in GetSegmentData.</para>
			/// </remarks>
			// https://docs.microsoft.com/en-us/windows/win32/api/xpsobjectmodel/nf-xpsobjectmodel-ixpsomgeometryfigure-getsegmentdatacount
			// HRESULT GetSegmentDataCount( UINT32 *segmentDataCount );
			uint GetSegmentDataCount();

			/// <summary>Gets the XPS_SEGMENT_STROKE_PATTERN value that indicates whether the segments in the figure are stroked.</summary>
			/// <returns>The XPS_SEGMENT_STROKE_PATTERN value that indicates whether the segments in the figure are stroked.</returns>
			// https://docs.microsoft.com/en-us/windows/win32/api/xpsobjectmodel/nf-xpsobjectmodel-ixpsomgeometryfigure-getsegmentstrokepattern
			// HRESULT GetSegmentStrokePattern( XPS_SEGMENT_STROKE_PATTERN *segmentStrokePattern );
			XPS_SEGMENT_STROKE_PATTERN GetSegmentStrokePattern();

			/// <summary>Makes a deep copy of the interface.</summary>
			/// <returns>A pointer to the copy of the interface.</returns>
			/// <remarks>The owner of the copy is <c>NULL</c>.</remarks>
			// https://docs.microsoft.com/en-us/windows/win32/api/xpsobjectmodel/nf-xpsobjectmodel-ixpsomgeometryfigure-clone
			// HRESULT Clone( IXpsOMGeometryFigure **geometryFigure );
			IXpsOMGeometryFigure Clone();
		}

		/// <summary>A collection of IXpsOMGeometryFigure interface pointers.</summary>
		/// <remarks>For more information about the collection methods, see Working with XPS OM Collection Interfaces.</remarks>
		// https://docs.microsoft.com/en-us/windows/win32/api/xpsobjectmodel/nn-xpsobjectmodel-ixpsomgeometryfigurecollection
		[PInvokeData("xpsobjectmodel.h", MSDNShortId = "24ed79ff-9160-4e9b-b322-c538b30f113b")]
		[ComImport, Guid("FD48C3F3-A58E-4B5A-8826-1DE54ABE72B2"), InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
		public interface IXpsOMGeometryFigureCollection
		{
			/// <summary>Gets the number of IXpsOMGeometryFigure interface pointers in the collection.</summary>
			/// <returns>The number of IXpsOMGeometryFigure interface pointers in the collection.</returns>
			/// <remarks>For more information about the collection methods, see Working with XPS OM Collection Interfaces.</remarks>
			// https://docs.microsoft.com/en-us/windows/win32/api/xpsobjectmodel/nf-xpsobjectmodel-ixpsomgeometryfigurecollection-getcount
			// HRESULT GetCount( UINT32 *count );
			uint GetCount();

			/// <summary>Gets an IXpsOMGeometryFigure interface pointer from a specified location in the collection.</summary>
			/// <param name="index">The zero-based index of the IXpsOMGeometryFigure interface pointer to be obtained.</param>
			/// <returns>The IXpsOMGeometryFigure interface pointer at the location specified by index.</returns>
			/// <remarks>For more information about the collection methods, see Working with XPS OM Collection Interfaces.</remarks>
			// https://docs.microsoft.com/en-us/windows/win32/api/xpsobjectmodel/nf-xpsobjectmodel-ixpsomgeometryfigurecollection-getat
			// HRESULT GetAt( UINT32 index, IXpsOMGeometryFigure **geometryFigure );
			IXpsOMGeometryFigure GetAt([In] uint index);

			/// <summary>Inserts an IXpsOMGeometryFigure interface pointer at a specified location in the collection.</summary>
			/// <param name="index">The zero-based index in the collection where the interface pointer that is passed in geometryFigure is to be inserted.</param>
			/// <param name="geometryFigure">The IXpsOMGeometryFigure interface pointer that is to be inserted at the location specified by index.</param>
			/// <remarks>
			/// <para>At the location specified by index, this method inserts the IXpsOMGeometryFigure interface pointer that is passed in geometryFigure. Prior to the insertion, the pointer in this and all subsequent locations is moved up by one index.</para>
			/// <para>For more information about the collection methods, see Working with XPS OM Collection Interfaces.</para>
			/// </remarks>
			// https://docs.microsoft.com/en-us/windows/win32/api/xpsobjectmodel/nf-xpsobjectmodel-ixpsomgeometryfigurecollection-insertat
			// HRESULT InsertAt( UINT32 index, IXpsOMGeometryFigure *geometryFigure );
			void InsertAt([In] uint index, [In] IXpsOMGeometryFigure geometryFigure);

			/// <summary>Removes and releases an IXpsOMGeometryFigure interface pointer from a specified location in the collection.</summary>
			/// <param name="index">The zero-based index in the collection from which an IXpsOMGeometryFigure interface pointer is to be removed and released.</param>
			/// <remarks>
			/// <para>This method releases the interface referenced by the pointer at the location specified by index. After releasing the interface, this method compacts the collection by reducing by 1 the index of each pointer subsequent to index.</para>
			/// <para>For more information about the collection methods, see Working with XPS OM Collection Interfaces.</para>
			/// </remarks>
			// https://docs.microsoft.com/en-us/windows/win32/api/xpsobjectmodel/nf-xpsobjectmodel-ixpsomgeometryfigurecollection-removeat
			// HRESULT RemoveAt( UINT32 index );
			void RemoveAt([In] uint index);

			/// <summary>Replaces an IXpsOMGeometryFigure interface pointer at a specified location in the collection.</summary>
			/// <param name="index">The zero-based index in the collection where an IXpsOMGeometryFigure interface pointer is to be replaced.</param>
			/// <param name="geometryFigure">The IXpsOMGeometryFigure interface pointer that will replace current contents at the location specified by index.</param>
			/// <remarks>
			/// <para>At the location specified by index, this method releases the IXpsOMGeometryFigure interface referenced by the existing pointer, then writes the pointer that is passed in geometryFigure.</para>
			/// <para>For more information about the collection methods, see Working with XPS OM Collection Interfaces.</para>
			/// </remarks>
			// https://docs.microsoft.com/en-us/windows/win32/api/xpsobjectmodel/nf-xpsobjectmodel-ixpsomgeometryfigurecollection-setat
			// HRESULT SetAt( UINT32 index, IXpsOMGeometryFigure *geometryFigure );
			void SetAt([In] uint index, [In] IXpsOMGeometryFigure geometryFigure);

			/// <summary>Appends an IXpsOMGeometryFigure interface to the end of the collection.</summary>
			/// <param name="geometryFigure">A pointer to the IXpsOMGeometryFigure interface that is to be appended to the collection.</param>
			/// <remarks>For more information about the collection methods, see Working with XPS OM Collection Interfaces.</remarks>
			// https://docs.microsoft.com/en-us/windows/win32/api/xpsobjectmodel/nf-xpsobjectmodel-ixpsomgeometryfigurecollection-append
			// HRESULT Append( IXpsOMGeometryFigure *geometryFigure );
			void Append([In] IXpsOMGeometryFigure geometryFigure);
		}

		/// <summary>
		/// <para>Describes the text that appears on a page.</para>
		/// <para>The IXpsOMGlyphsEditor interface is used to modify the text that is described by this interface.</para>
		/// </summary>
		/// <remarks>The code example that follows illustrates how to create an instance of this interface.</remarks>
		// https://docs.microsoft.com/en-us/windows/win32/api/xpsobjectmodel/nn-xpsobjectmodel-ixpsomglyphs
		[PInvokeData("xpsobjectmodel.h", MSDNShortId = "6d2cda65-c719-46f2-97c9-8aee7b5f84b9")]
		[ComImport, Guid("819B3199-0A5A-4B64-BEC7-A9E17E780DE2"), InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
		public interface IXpsOMGlyphs : IXpsOMVisual
		{
			/// <summary>Gets the <c>IUnknown</c> interface of the parent.</summary>
			/// <returns>A pointer to the <c>IUnknown</c> interface of the parent.</returns>
			// https://docs.microsoft.com/en-us/windows/win32/api/xpsobjectmodel/nf-xpsobjectmodel-ixpsomshareable-getowner
			// HRESULT GetOwner( IUnknown **owner );
			[return: MarshalAs(UnmanagedType.IUnknown)]
			new object GetOwner();

			/// <summary>Gets the object type of the interface.</summary>
			/// <returns>The XPS_OBJECT_TYPE value that describes the interface that is derived from IXpsOMShareable.</returns>
			// https://docs.microsoft.com/en-us/windows/win32/api/xpsobjectmodel/nf-xpsobjectmodel-ixpsomshareable-gettype
			// HRESULT GetType( XPS_OBJECT_TYPE *type );
			new XPS_OBJECT_TYPE GetType();

			/// <summary>Gets a pointer to the IXpsOMMatrixTransform interface that contains the visual's resolved matrix transform.</summary>
			/// <returns>
			/// <para>A pointer to the IXpsOMMatrixTransform interface that contains the visual's resolved matrix transform. If a matrix transform has not been set, a <c>NULL</c> pointer is returned.</para>
			/// <para>The value that is returned in this parameter depends on which method has most recently been called to set the transform.</para>
			/// <list type="table">
			/// <listheader>
			/// <term>Most recent method called</term>
			/// <term>Object that is returned in matrixTransform</term>
			/// </listheader>
			/// <item>
			/// <term>SetTransformLocal</term>
			/// <term>The local transform that is set by SetTransformLocal.</term>
			/// </item>
			/// <item>
			/// <term>SetTransformLookup</term>
			/// <term>The shared transform that gets retrieved, with a lookup key that matches the key that is set by SetTransformLookup, from the resource directory.</term>
			/// </item>
			/// <item>
			/// <term>Neither SetTransformLocal nor SetTransformLookup has been called yet.</term>
			/// <term>NULL pointer.</term>
			/// </item>
			/// </list>
			/// </returns>
			// https://docs.microsoft.com/en-us/windows/win32/api/xpsobjectmodel/nf-xpsobjectmodel-ixpsomvisual-gettransform
			// HRESULT GetTransform( IXpsOMMatrixTransform **matrixTransform );
			[MethodImpl(MethodImplOptions.InternalCall)]
			new IXpsOMMatrixTransform GetTransform();

			/// <summary>Gets a pointer to the IXpsOMMatrixTransform interface that contains the local, unshared, resolved matrix transform for the visual.</summary>
			/// <returns>
			/// <para>A pointer to the IXpsOMMatrixTransform interface that contains the local, unshared, resolved matrix transform for the visual. If a matrix transform lookup key has not been set, or if a local matrix transform has been set, a <c>NULL</c> pointer is returned.</para>
			/// <list type="table">
			/// <listheader>
			/// <term>Most recent method called</term>
			/// <term>Object that is returned in matrixTransform</term>
			/// </listheader>
			/// <item>
			/// <term>SetTransformLocal</term>
			/// <term>The local transform that is set by SetTransformLocal.</term>
			/// </item>
			/// <item>
			/// <term>SetTransformLookup</term>
			/// <term>NULL pointer.</term>
			/// </item>
			/// <item>
			/// <term>Neither SetTransformLocal nor SetTransformLookup has been called yet.</term>
			/// <term>NULL pointer.</term>
			/// </item>
			/// </list>
			/// </returns>
			// https://docs.microsoft.com/en-us/windows/win32/api/xpsobjectmodel/nf-xpsobjectmodel-ixpsomvisual-gettransformlocal
			// HRESULT GetTransformLocal( IXpsOMMatrixTransform **matrixTransform );
			[MethodImpl(MethodImplOptions.InternalCall)]
			new IXpsOMMatrixTransform GetTransformLocal();

			/// <summary>
			/// Sets the local, unshared matrix transform.
			/// </summary>
			/// <param name="matrixTransform">A pointer to the IXpsOMMatrixTransform interface to be set as the local, unshared matrix transform. A <c>NULL</c> pointer releases the previously assigned transform.</param>
			/// <remarks>
			/// <para>After you call <c>SetTransformLocal</c>, the transform lookup key is released and GetTransformLookup returns a <c>NULL</c> pointer in the key parameter. The table that follows explains the relationship between the local and lookup values of this property.</para>
			/// <list type="table">
			///   <listheader>
			///     <term>Most recent method called</term>
			///     <term>Object that is returned in transform by GetTransform</term>
			///     <term>Object that is returned in matrixTransform by GetTransformLocal</term>
			///     <term>Object that is returned in key by GetTransformLookup</term>
			///   </listheader>
			///   <item>
			///     <term>SetTransformLocal (this method)</term>
			///     <term>The local transform that is set by SetTransformLocal.</term>
			///     <term>The local transform set by SetTransformLocal.</term>
			///     <term>NULL pointer.</term>
			///   </item>
			///   <item>
			///     <term>SetTransformLookup</term>
			///     <term>The shared transform that gets retrieved, with a lookup key that matches the key that is set by SetTransformLookup, from the resource directory.</term>
			///     <term>NULL pointer.</term>
			///     <term>The lookup key that is set by SetTransformLookup.</term>
			///   </item>
			///   <item>
			///     <term>Neither SetTransformLocal nor SetTransformLookup has been called yet.</term>
			///     <term>NULL pointer.</term>
			///     <term>NULL pointer.</term>
			///     <term>NULL pointer.</term>
			///   </item>
			/// </list>
			/// </remarks>
			// https://docs.microsoft.com/en-us/windows/win32/api/xpsobjectmodel/nf-xpsobjectmodel-ixpsomvisual-settransformlocal
			// HRESULT SetTransformLocal( IXpsOMMatrixTransform *matrixTransform );
			[MethodImpl(MethodImplOptions.InternalCall)]
			new void SetTransformLocal([In] IXpsOMMatrixTransform matrixTransform);

			/// <summary>Gets the lookup key name of the IXpsOMMatrixTransform interface in a resource dictionary that contains the resolved matrix transform for the visual.</summary>
			/// <returns>
			/// <para>The lookup key name for the IXpsOMMatrixTransform interface in a resource dictionary that contains the resolved matrix transform for the visual. If a matrix transform lookup key has not been set, or if a local matrix transform has been set, a <c>NULL</c> pointer is returned.</para>
			/// <list type="table">
			/// <listheader>
			/// <term>Most recent method called</term>
			/// <term>Object that is returned in key</term>
			/// </listheader>
			/// <item>
			/// <term>SetTransformLocal</term>
			/// <term>NULL pointer.</term>
			/// </item>
			/// <item>
			/// <term>SetTransformLookup</term>
			/// <term>The lookup key that is set by SetTransformLookup.</term>
			/// </item>
			/// <item>
			/// <term>Neither SetTransformLocal nor SetTransformLookup has been called yet.</term>
			/// <term>NULL pointer.</term>
			/// </item>
			/// </list>
			/// </returns>
			// https://docs.microsoft.com/en-us/windows/win32/api/xpsobjectmodel/nf-xpsobjectmodel-ixpsomvisual-gettransformlookup
			// HRESULT GetTransformLookup( LPWSTR *key );
			[MethodImpl(MethodImplOptions.InternalCall)]
			new SafeCoTaskMemString GetTransformLookup();

			/// <summary>
			/// Sets the lookup key name of a shared matrix transform in a resource dictionary.
			/// </summary>
			/// <param name="key">The lookup key name of the matrix transform in the dictionary.</param>
			/// <remarks>
			/// <para>After you call <c>SetTransformLookup</c>, the local transform is released and GetTransformLocal returns a <c>NULL</c> pointer in the matrixTransform parameter. The table that follows explains the relationship between the local and lookup values of this property.</para>
			/// <list type="table">
			///   <listheader>
			///     <term>Most recent method called</term>
			///     <term>Object that is returned in transform by GetTransform</term>
			///     <term>Object that is returned in matrixTransform by GetTransformLocal</term>
			///     <term>Object that is returned in key by GetTransformLookup</term>
			///   </listheader>
			///   <item>
			///     <term>SetTransformLocal</term>
			///     <term>The local transform that is set by SetTransformLocal.</term>
			///     <term>The local transform that is set by SetTransformLocal.</term>
			///     <term>NULL pointer.</term>
			///   </item>
			///   <item>
			///     <term>SetTransformLookup (this method)</term>
			///     <term>The shared transform that gets retrieved—with a lookup key that matches the key that is set by SetTransformLookup—from the resource directory.</term>
			///     <term>NULL pointer.</term>
			///     <term>The lookup key that is set by SetTransformLookup.</term>
			///   </item>
			///   <item>
			///     <term>Neither SetTransformLocal nor SetTransformLookup has been called yet.</term>
			///     <term>NULL pointer.</term>
			///     <term>NULL pointer.</term>
			///     <term>NULL pointer.</term>
			///   </item>
			/// </list>
			/// </remarks>
			// https://docs.microsoft.com/en-us/windows/win32/api/xpsobjectmodel/nf-xpsobjectmodel-ixpsomvisual-settransformlookup
			// HRESULT SetTransformLookup( LPCWSTR key );
			[MethodImpl(MethodImplOptions.InternalCall)]
			new void SetTransformLookup([In, MarshalAs(UnmanagedType.LPWStr)] string key);

			/// <summary>Gets a pointer to the IXpsOMGeometry interface that contains the resolved geometry of the visual's clipping region.</summary>
			/// <returns>
			/// <para>A pointer to the IXpsOMGeometry interface that contains the resolved geometry of the visual's clipping region. If the clip geometry has not been set, a <c>NULL</c> pointer is returned.</para>
			/// <para>The value that is returned in this parameter depends on which method has most recently been called to set the geometry.</para>
			/// <list type="table">
			/// <listheader>
			/// <term>Most recent method called</term>
			/// <term>Object that is returned in clipGeometry</term>
			/// </listheader>
			/// <item>
			/// <term>SetClipGeometryLocal</term>
			/// <term>The local clip geometry that is set by SetClipGeometryLocal.</term>
			/// </item>
			/// <item>
			/// <term>SetClipGeometryLookup</term>
			/// <term>The shared clip geometry that gets retrieved, with a lookup key that matches the key that is set by SetClipGeometryLookup, from the resource directory.</term>
			/// </item>
			/// <item>
			/// <term>Neither SetClipGeometryLocal nor SetClipGeometryLookup has been called yet.</term>
			/// <term>NULL pointer.</term>
			/// </item>
			/// </list>
			/// </returns>
			// https://docs.microsoft.com/en-us/windows/win32/api/xpsobjectmodel/nf-xpsobjectmodel-ixpsomvisual-getclipgeometry
			// HRESULT GetClipGeometry( IXpsOMGeometry **clipGeometry );
			[MethodImpl(MethodImplOptions.InternalCall)]
			new IXpsOMGeometry GetClipGeometry();

			/// <summary>Gets a pointer to the IXpsOMGeometry interface that contains the local, unshared geometry of the visual's clipping region.</summary>
			/// <returns>
			/// <para>A pointer to the IXpsOMGeometry interface that contains the local, unshared geometry of the visual's clipping region. If a clip geometry lookup key has been set, or if a local clip geometry has not been set, a <c>NULL</c> pointer is returned.</para>
			/// <list type="table">
			/// <listheader>
			/// <term>Most recent method called</term>
			/// <term>Object that is returned in clipGeometry</term>
			/// </listheader>
			/// <item>
			/// <term>SetClipGeometryLocal</term>
			/// <term>The local clip geometry that is set by SetClipGeometryLocal.</term>
			/// </item>
			/// <item>
			/// <term>SetClipGeometryLookup</term>
			/// <term>NULL pointer.</term>
			/// </item>
			/// <item>
			/// <term>Neither SetClipGeometryLocal nor SetClipGeometryLookup has been called yet.</term>
			/// <term>NULL pointer.</term>
			/// </item>
			/// </list>
			/// </returns>
			// https://docs.microsoft.com/en-us/windows/win32/api/xpsobjectmodel/nf-xpsobjectmodel-ixpsomvisual-getclipgeometrylocal
			// HRESULT GetClipGeometryLocal( IXpsOMGeometry **clipGeometry );
			[MethodImpl(MethodImplOptions.InternalCall)]
			new IXpsOMGeometry GetClipGeometryLocal();

			/// <summary>Sets the local, unshared clipping region for the visual.</summary>
			/// <param name="clipGeometry">A pointer to the IXpsOMGeometry interface to be set as the local, unshared clipping region for the visual. A <c>NULL</c> pointer releases the previously assigned geometry interface.</param>
			/// <remarks>
			/// <para>After you call <c>SetClipGeometryLocal</c>, the clip geometry lookup key is released and GetClipGeometryLookup returns a <c>NULL</c> pointer in the key parameter. The table that follows explains the relationship between the local and lookup values of this property.</para>
			/// <list type="table">
			/// <listheader>
			/// <term>Most recent method called</term>
			/// <term>Object that is returned in clipGeometry by GetClipGeometry</term>
			/// <term>Object that is returned in clipGeometry by GetClipGeometryLocal</term>
			/// <term>String that is returned in key by GetClipGeometryLookup</term>
			/// </listheader>
			/// <item>
			/// <term>SetClipGeometryLocal (this method)</term>
			/// <term>The local clip geometry that is set by SetClipGeometryLocal.</term>
			/// <term>The local clip geometry that is set by SetClipGeometryLocal.</term>
			/// <term>NULL pointer.</term>
			/// </item>
			/// <item>
			/// <term>SetClipGeometryLookup</term>
			/// <term>The shared clip geometry that gets retrieved, with a lookup key that matches the key that is set by SetClipGeometryLookup, from the resource directory.</term>
			/// <term>NULL pointer.</term>
			/// <term>The lookup key that is set by SetClipGeometryLookup.</term>
			/// </item>
			/// <item>
			/// <term>Neither SetClipGeometryLookup nor SetClipGeometryLocal has been called yet.</term>
			/// <term>NULL pointer.</term>
			/// <term>NULL pointer.</term>
			/// <term>NULL pointer.</term>
			/// </item>
			/// </list>
			/// </remarks>
			// https://docs.microsoft.com/en-us/windows/win32/api/xpsobjectmodel/nf-xpsobjectmodel-ixpsomvisual-setclipgeometrylocal
			// HRESULT SetClipGeometryLocal( IXpsOMGeometry *clipGeometry );
			[MethodImpl(MethodImplOptions.InternalCall)]
			new void SetClipGeometryLocal([In] IXpsOMGeometry clipGeometry);

			/// <summary>Gets the lookup key for the IXpsOMGeometry interface in a resource dictionary that contains the visual's clipping region.</summary>
			/// <returns>
			/// <para>The lookup key for the IXpsOMGeometry interface in a resource dictionary that contains the visual's clipping region. If a lookup key for the clip geometry has not been set, or if a local clip geometry has been set, a <c>NULL</c> pointer is returned.</para>
			/// <list type="table">
			/// <listheader>
			/// <term>Most recent method called</term>
			/// <term>Lookup key string that is returned in key</term>
			/// </listheader>
			/// <item>
			/// <term>SetClipGeometryLocal</term>
			/// <term>NULL pointer.</term>
			/// </item>
			/// <item>
			/// <term>SetClipGeometryLookup</term>
			/// <term>The lookup key that is set by SetClipGeometryLookup.</term>
			/// </item>
			/// <item>
			/// <term>Neither SetClipGeometryLocal nor SetClipGeometryLookup has been called yet.</term>
			/// <term>NULL pointer.</term>
			/// </item>
			/// </list>
			/// </returns>
			// https://docs.microsoft.com/en-us/windows/win32/api/xpsobjectmodel/nf-xpsobjectmodel-ixpsomvisual-getclipgeometrylookup
			// HRESULT GetClipGeometryLookup( LPWSTR *key );
			[MethodImpl(MethodImplOptions.InternalCall)]
			new SafeCoTaskMemString GetClipGeometryLookup();

			/// <summary>Sets the lookup key name of a shared clip geometry in a resource dictionary.</summary>
			/// <param name="key">The lookup key name of the clip geometry in the dictionary. A <c>NULL</c> pointer clears the previously assigned key name.</param>
			/// <remarks>
			/// <para>After you call <c>SetClipGeometryLookup</c>, the local clip geometry is released and GetClipGeometryLocal returns a <c>NULL</c> pointer in the clipGeometry parameter. The table that follows explains the relationship between the local and lookup values of this property.</para>
			/// <list type="table">
			/// <listheader>
			/// <term>Most recent method called</term>
			/// <term>Object that is returned in clipGeometry by GetClipGeometry</term>
			/// <term>Object that is returned in clipGeometry by GetClipGeometryLocal</term>
			/// <term>String that is returned in key by GetClipGeometryLookup</term>
			/// </listheader>
			/// <item>
			/// <term>SetClipGeometryLocal</term>
			/// <term>The local clip geometry that is set by SetClipGeometryLocal.</term>
			/// <term>The local clip geometry that is set by SetClipGeometryLocal.</term>
			/// <term>NULL pointer.</term>
			/// </item>
			/// <item>
			/// <term>SetClipGeometryLookup (this method)</term>
			/// <term>The shared clip geometry that gets retrieved, with a lookup key that matches the key that is set by SetClipGeometryLookup, from the resource directory.</term>
			/// <term>NULL pointer.</term>
			/// <term>The lookup key that is set by SetClipGeometryLookup.</term>
			/// </item>
			/// <item>
			/// <term>Neither SetClipGeometryLookup nor SetClipGeometryLocal has been called yet.</term>
			/// <term>NULL pointer.</term>
			/// <term>NULL pointer.</term>
			/// <term>NULL pointer.</term>
			/// </item>
			/// </list>
			/// </remarks>
			// https://docs.microsoft.com/en-us/windows/win32/api/xpsobjectmodel/nf-xpsobjectmodel-ixpsomvisual-setclipgeometrylookup
			// HRESULT SetClipGeometryLookup( LPCWSTR key );
			[MethodImpl(MethodImplOptions.InternalCall)]
			new void SetClipGeometryLookup([In, MarshalAs(UnmanagedType.LPWStr)] string key);

			/// <summary>Gets the opacity value of this visual.</summary>
			/// <returns>The opacity value.</returns>
			// https://docs.microsoft.com/en-us/windows/win32/api/xpsobjectmodel/nf-xpsobjectmodel-ixpsomvisual-getopacity
			// HRESULT GetOpacity( FLOAT *opacity );
			[MethodImpl(MethodImplOptions.InternalCall)]
			new float GetOpacity();

			/// <summary>Sets the opacity value of the visual.</summary>
			/// <param name="opacity">
			/// <para>The opacity value to be set for the visual.</para>
			/// <para>The range of allowed values for this parameter is 0.0 to 1.0; with 0.0 the visual is completely transparent, and with 1.0 it is completely opaque.</para>
			/// </param>
			// https://docs.microsoft.com/en-us/windows/win32/api/xpsobjectmodel/nf-xpsobjectmodel-ixpsomvisual-setopacity
			// HRESULT SetOpacity( FLOAT opacity );
			[MethodImpl(MethodImplOptions.InternalCall)]
			new void SetOpacity([In] float opacity);

			/// <summary>Gets a pointer to the IXpsOMBrush interface of the visual's opacity mask brush.</summary>
			/// <returns>
			/// <para>A pointer to the IXpsOMBrush interface of the visual's opacity mask brush. If an opacity mask brush has not been set for this visual, a <c>NULL</c> pointer is returned.</para>
			/// <para>The value that is returned in this parameter depends on which method has most recently been called to set the brush.</para>
			/// <list type="table">
			/// <listheader>
			/// <term>Most recent method called</term>
			/// <term>Object that is returned in opacityMaskBrush</term>
			/// </listheader>
			/// <item>
			/// <term>SetOpacityMaskBrushLocal</term>
			/// <term>The local opacity mask brush that is set by SetOpacityMaskBrushLocal.</term>
			/// </item>
			/// <item>
			/// <term>SetOpacityMaskBrushLookup</term>
			/// <term>The shared opacity mask brush that gets retrieved, with a lookup key that matches the key that is set by SetOpacityMaskBrushLookup, from the resource directory.</term>
			/// </item>
			/// <item>
			/// <term>Neither SetOpacityMaskBrushLocal nor SetOpacityMaskBrushLookup has been called yet.</term>
			/// <term>NULL pointer.</term>
			/// </item>
			/// </list>
			/// </returns>
			// https://docs.microsoft.com/en-us/windows/win32/api/xpsobjectmodel/nf-xpsobjectmodel-ixpsomvisual-getopacitymaskbrush
			// HRESULT GetOpacityMaskBrush( IXpsOMBrush **opacityMaskBrush );
			[MethodImpl(MethodImplOptions.InternalCall)]
			new IXpsOMBrush GetOpacityMaskBrush();

			/// <summary>Gets the local, unshared opacity mask brush for the visual.</summary>
			/// <returns>
			/// <para>A pointer to the IXpsOMBrush interface of the visual's opacity mask brush. If an opacity mask brush lookup key has been set, or if a local opacity mask brush has not been set, a <c>NULL</c> pointer is returned.</para>
			/// <list type="table">
			/// <listheader>
			/// <term>Most recent method called</term>
			/// <term>Object that is returned in opacityMaskBrush</term>
			/// </listheader>
			/// <item>
			/// <term>SetOpacityMaskBrushLocal</term>
			/// <term>The local opacity mask brush that is set by SetOpacityMaskBrushLocal.</term>
			/// </item>
			/// <item>
			/// <term>SetOpacityMaskBrushLookup</term>
			/// <term>NULL pointer.</term>
			/// </item>
			/// <item>
			/// <term>Neither SetOpacityMaskBrushLocal nor SetOpacityMaskBrushLookup has been called yet.</term>
			/// <term>NULL pointer.</term>
			/// </item>
			/// </list>
			/// </returns>
			// https://docs.microsoft.com/en-us/windows/win32/api/xpsobjectmodel/nf-xpsobjectmodel-ixpsomvisual-getopacitymaskbrushlocal
			// HRESULT GetOpacityMaskBrushLocal( IXpsOMBrush **opacityMaskBrush );
			[MethodImpl(MethodImplOptions.InternalCall)]
			new IXpsOMBrush GetOpacityMaskBrushLocal();

			/// <summary>
			/// Sets the IXpsOMBrush interface pointer as the local, unshared opacity mask brush.
			/// </summary>
			/// <param name="opacityMaskBrush">A pointer to the IXpsOMBrush interface to be set as the local, unshared opacity mask brush. A <c>NULL</c> pointer clears the previously assigned opacity mask brush.</param>
			/// <remarks>
			/// <para>After you call <c>SetOpacityMaskBrushLocal</c>, the opacity mask brush lookup key is released and GetOpacityMaskBrushLookup returns a <c>NULL</c> pointer in the key parameter. The table that follows explains the relationship between the local and lookup values of this property.</para>
			/// <list type="table">
			///   <listheader>
			///     <term>Most recent method called</term>
			///     <term>Object that is returned in opacityMaskBrush by GetOpacityMaskBrush</term>
			///     <term>Object that is returned in opacityMaskBrush by GetOpacityMaskBrushLocal</term>
			///     <term>String that is returned in key by GetOpacityMaskBrushLookup</term>
			///   </listheader>
			///   <item>
			///     <term>SetOpacityMaskBrushLocal (this method)</term>
			///     <term>The local opacity mask brush that is set by SetOpacityMaskBrushLocal.</term>
			///     <term>The local opacity mask brush that is set by SetOpacityMaskBrushLocal.</term>
			///     <term>NULL pointer.</term>
			///   </item>
			///   <item>
			///     <term>SetOpacityMaskBrushLookup</term>
			///     <term>The shared opacity mask brush that gets retrieved, with a lookup key that matches the key that is set by SetOpacityMaskBrushLookup, from the resource directory.</term>
			///     <term>NULL pointer.</term>
			///     <term>The lookup key that is set by SetOpacityMaskBrushLookup.</term>
			///   </item>
			///   <item>
			///     <term>Neither SetOpacityMaskBrushLocal nor SetOpacityMaskBrushLookup has been called yet.</term>
			///     <term>NULL pointer.</term>
			///     <term>NULL pointer.</term>
			///     <term>NULL pointer.</term>
			///   </item>
			/// </list>
			/// </remarks>
			// https://docs.microsoft.com/en-us/windows/win32/api/xpsobjectmodel/nf-xpsobjectmodel-ixpsomvisual-setopacitymaskbrushlocal
			// HRESULT SetOpacityMaskBrushLocal( IXpsOMBrush *opacityMaskBrush );
			[MethodImpl(MethodImplOptions.InternalCall)]
			new void SetOpacityMaskBrushLocal([In] IXpsOMBrush opacityMaskBrush);

			/// <summary>Gets the name of the lookup key of the shared opacity mask brush in a resource dictionary.</summary>
			/// <returns>
			/// <para>The name of the lookup key of the shared opacity mask brush in a resource dictionary. If the lookup key of an opacity mask brush has not been set, or if a local opacity mask brush has been set, a <c>NULL</c> pointer is returned.</para>
			/// <list type="table">
			/// <listheader>
			/// <term>Most recent method called</term>
			/// <term>Object that is returned in key</term>
			/// </listheader>
			/// <item>
			/// <term>SetOpacityMaskBrushLocal</term>
			/// <term>NULL pointer.</term>
			/// </item>
			/// <item>
			/// <term>SetOpacityMaskBrushLookup</term>
			/// <term>The lookup key that is set by SetOpacityMaskBrushLookup.</term>
			/// </item>
			/// <item>
			/// <term>Neither SetOpacityMaskBrushLocal nor SetOpacityMaskBrushLookup has been called yet.</term>
			/// <term>NULL pointer.</term>
			/// </item>
			/// </list>
			/// </returns>
			// https://docs.microsoft.com/en-us/windows/win32/api/xpsobjectmodel/nf-xpsobjectmodel-ixpsomvisual-getopacitymaskbrushlookup
			// HRESULT GetOpacityMaskBrushLookup( LPWSTR *key );
			[MethodImpl(MethodImplOptions.InternalCall)]
			new SafeCoTaskMemString GetOpacityMaskBrushLookup();

			/// <summary>
			/// Sets the lookup key name of a shared opacity mask brush in a resource dictionary.
			/// </summary>
			/// <param name="key">The lookup key name of the opacity mask brush in the dictionary. A <c>NULL</c> pointer clears the previously assigned key name.</param>
			/// <remarks>
			/// <para>After you call <c>SetOpacityMaskBrushLookup</c>, the local opacity mask brush is released and GetOpacityMaskBrushLocal returns a <c>NULL</c> pointer in the opacityMaskBrush parameter. The table that follows explains the relationship between the local and lookup values of this property.</para>
			/// <list type="table">
			///   <listheader>
			///     <term>Most recent method called</term>
			///     <term>Object that is returned in opacityMaskBrush by GetOpacityMaskBrush</term>
			///     <term>Object that is returned in opacityMaskBrush by GetOpacityMaskBrushLocal</term>
			///     <term>String that is returned in key by GetOpacityMaskBrushLookup</term>
			///   </listheader>
			///   <item>
			///     <term>SetOpacityMaskBrushLocal</term>
			///     <term>The local opacity mask brush that is set by SetOpacityMaskBrushLocal.</term>
			///     <term>The local opacity mask brush that is set by SetOpacityMaskBrushLocal.</term>
			///     <term>NULL pointer.</term>
			///   </item>
			///   <item>
			///     <term>SetOpacityMaskBrushLookup (this method)</term>
			///     <term>The shared opacity mask brush that gets retrieved—with a lookup key that matches the key that is set by SetOpacityMaskBrushLookup—from the resource directory.</term>
			///     <term>NULL pointer.</term>
			///     <term>The lookup key that is set by SetOpacityMaskBrushLookup.</term>
			///   </item>
			///   <item>
			///     <term>Neither SetOpacityMaskBrushLocal nor SetOpacityMaskBrushLookup has been called yet.</term>
			///     <term>NULL pointer.</term>
			///     <term>NULL pointer.</term>
			///     <term>NULL pointer.</term>
			///   </item>
			/// </list>
			/// </remarks>
			// https://docs.microsoft.com/en-us/windows/win32/api/xpsobjectmodel/nf-xpsobjectmodel-ixpsomvisual-setopacitymaskbrushlookup
			// HRESULT SetOpacityMaskBrushLookup( LPCWSTR key );
			[MethodImpl(MethodImplOptions.InternalCall)]
			new void SetOpacityMaskBrushLookup([In, MarshalAs(UnmanagedType.LPWStr)] string key);

			/// <summary>Gets the <c>Name</c> property of the visual.</summary>
			/// <returns>The <c>Name</c> property string. If the <c>Name</c> property has not been set, a <c>NULL</c> pointer is returned.</returns>
			// https://docs.microsoft.com/en-us/windows/win32/api/xpsobjectmodel/nf-xpsobjectmodel-ixpsomvisual-getname
			// HRESULT GetName( LPWSTR *name );
			[MethodImpl(MethodImplOptions.InternalCall)]
			new SafeCoTaskMemString GetName();

			/// <summary>
			/// Sets the <c>Name</c> property of the visual.
			/// </summary>
			/// <param name="name">The name of the visual. A <c>NULL</c> pointer clears the <c>Name</c> property.</param>
			/// <remarks>
			/// <para>Names must be unique.</para>
			/// <para>Clearing the <c>Name</c> property by passing a <c>NULL</c> pointer in name sets the <c>IsHyperlinkTarget</c> property to <c>FALSE</c>.</para>
			/// </remarks>
			// https://docs.microsoft.com/en-us/windows/win32/api/xpsobjectmodel/nf-xpsobjectmodel-ixpsomvisual-setname
			// HRESULT SetName( LPCWSTR name );
			[MethodImpl(MethodImplOptions.InternalCall)]
			new void SetName([In, MarshalAs(UnmanagedType.LPWStr)] string name);

			/// <summary>Gets a value that indicates whether the visual is the target of a hyperlink.</summary>
			/// <returns>
			/// <para>The Boolean value that indicates whether the visual is the target of a hyperlink.</para>
			/// <list type="table">
			/// <listheader>
			/// <term>Value</term>
			/// <term>Meaning</term>
			/// </listheader>
			/// <item>
			/// <term>TRUE</term>
			/// <term>The visual is the target of a hyperlink.</term>
			/// </item>
			/// <item>
			/// <term>FALSE</term>
			/// <term>The visual is not the target of a hyperlink.</term>
			/// </item>
			/// </list>
			/// </returns>
			// https://docs.microsoft.com/en-us/windows/win32/api/xpsobjectmodel/nf-xpsobjectmodel-ixpsomvisual-getishyperlinktarget
			// HRESULT GetIsHyperlinkTarget( BOOL *isHyperlink );
			[MethodImpl(MethodImplOptions.InternalCall)]
			[return: MarshalAs(UnmanagedType.Bool)]
			new bool GetIsHyperlinkTarget();

			/// <summary>
			/// Specifies whether the visual is the target of a hyperlink.
			/// </summary>
			/// <param name="isHyperlink"><para>The Boolean value that specifies whether the visual is the target of a hyperlink.</para>
			/// <list type="table">
			///   <listheader>
			///     <term>Value</term>
			///     <term>Meaning</term>
			///   </listheader>
			///   <item>
			///     <term>TRUE</term>
			///     <term>The visual is the target of a hyperlink.</term>
			///   </item>
			///   <item>
			///     <term>FALSE</term>
			///     <term>The visual is not the target of a hyperlink.</term>
			///   </item>
			/// </list></param>
			/// <remarks>
			/// The visual must be named before it can be set as the target of a hyperlink.
			/// </remarks>
			// https://docs.microsoft.com/en-us/windows/win32/api/xpsobjectmodel/nf-xpsobjectmodel-ixpsomvisual-setishyperlinktarget
			// HRESULT SetIsHyperlinkTarget( BOOL isHyperlink );
			[MethodImpl(MethodImplOptions.InternalCall)]
			new void SetIsHyperlinkTarget([In, MarshalAs(UnmanagedType.Bool)] bool isHyperlink);

			/// <summary>Gets a pointer to the IUri interface to which this visual object links.</summary>
			/// <returns>A pointer to the IUri interface that contains the destination URI for the link. If a URI has not been set for this object, a <c>NULL</c> pointer is returned.</returns>
			// https://docs.microsoft.com/en-us/windows/win32/api/xpsobjectmodel/nf-xpsobjectmodel-ixpsomvisual-gethyperlinknavigateuri
			// HRESULT GetHyperlinkNavigateUri( IUri **hyperlinkUri );
			[MethodImpl(MethodImplOptions.InternalCall)]
			new IUri GetHyperlinkNavigateUri();

			/// <summary>
			/// Sets the destination URI of the visual's hyperlink.
			/// </summary>
			/// <param name="hyperlinkUri">The IUri interface that contains the destination URI of the visual's hyperlink.</param>
			/// <remarks>
			/// Setting an object's URI makes the object a hyperlink. When activated or clicked, the object will navigate to the destination that is specified by the URI in hyperlinkUri.
			/// </remarks>
			// https://docs.microsoft.com/en-us/windows/win32/api/xpsobjectmodel/nf-xpsobjectmodel-ixpsomvisual-sethyperlinknavigateuri
			// HRESULT SetHyperlinkNavigateUri( IUri *hyperlinkUri );
			[MethodImpl(MethodImplOptions.InternalCall)]
			new void SetHyperlinkNavigateUri([In] IUri hyperlinkUri);

			/// <summary>Gets the <c>Language</c> property of the visual and of its contents.</summary>
			/// <returns>The language string that specifies the language of the page. If a language has not been set, a <c>NULL</c> pointer is returned.</returns>
			/// <remarks>
			/// <para>The <c>Language</c> property that is set by this method specifies the language of the resource content.</para>
			/// <para>Internet Engineering Task Force (IETF) RFC 3066 specifies the recommended encoding for the <c>Language</c> property.</para>
			/// </remarks>
			// https://docs.microsoft.com/en-us/windows/win32/api/xpsobjectmodel/nf-xpsobjectmodel-ixpsomvisual-getlanguage
			// HRESULT GetLanguage( LPWSTR *language );
			[MethodImpl(MethodImplOptions.InternalCall)]
			new SafeCoTaskMemString GetLanguage();

			/// <summary>
			/// Sets the <c>Language</c> property of the visual.
			/// </summary>
			/// <param name="language">The language string that specifies the language of the visual and of its contents. A <c>NULL</c> pointer clears the <c>Language</c> property.</param>
			/// <remarks>
			/// The recommended encoding for the <c>Language</c> property is specified in Internet Engineering Task Force (IETF) RFC 3066r.
			/// </remarks>
			// https://docs.microsoft.com/en-us/windows/win32/api/xpsobjectmodel/nf-xpsobjectmodel-ixpsomvisual-setlanguage
			// HRESULT SetLanguage( LPCWSTR language );
			[MethodImpl(MethodImplOptions.InternalCall)]
			new void SetLanguage([In, MarshalAs(UnmanagedType.LPWStr)] string language);

			/// <summary>Gets the text in unescaped UTF-16 scalar values.</summary>
			/// <returns>The UTF-16 Unicode string of the text to be displayed. If the string is empty, a <c>NULL</c> pointer is returned.</returns>
			// https://docs.microsoft.com/en-us/windows/win32/api/xpsobjectmodel/nf-xpsobjectmodel-ixpsomglyphs-getunicodestring
			// HRESULT GetUnicodeString( LPWSTR *unicodeString );
			SafeCoTaskMemString GetUnicodeString();

			/// <summary>Gets the number of Glyph indices.</summary>
			/// <returns>The number of glyph indices.</returns>
			/// <remarks>GetGlyphIndices gets the glyph indices.</remarks>
			// https://docs.microsoft.com/en-us/windows/win32/api/xpsobjectmodel/nf-xpsobjectmodel-ixpsomglyphs-getglyphindexcount
			// HRESULT GetGlyphIndexCount( UINT32 *indexCount );
			uint GetGlyphIndexCount();

			/// <summary>
			/// Gets an array of XPS_GLYPH_INDEX structures that describe the specific glyph indices in the font.
			/// </summary>
			/// <param name="indexCount">The number of XPS_GLYPH_INDEX structures that will fit in the array that is referenced by glyphIndices. When the method returns, indexCount will contain the number of <c>XPS_GLYPH_INDEX</c> structures that are returned in the array referenced by glyphIndices.</param>
			/// <param name="glyphIndices">The address of an array of XPS_GLYPH_INDEX structures that receive the glyph indices.</param>
			/// <remarks>
			/// <para>GetGlyphIndexCount gets the number of elements in the glyph index array.</para>
			/// <para>The glyph indices override the default <c>cmap</c> mapping from the <c>UnicodeString</c> to the glyph index. The XPS_GLYPH_INDEX structure also contains advance width as well as vertical and horizontal offset information.</para>
			/// </remarks>
			// https://docs.microsoft.com/en-us/windows/win32/api/xpsobjectmodel/nf-xpsobjectmodel-ixpsomglyphs-getglyphindices
			// HRESULT GetGlyphIndices( UINT32 *indexCount, XPS_GLYPH_INDEX *glyphIndices );
			void GetGlyphIndices(ref uint indexCount, [In, Out] XPS_GLYPH_INDEX[] glyphIndices);

			/// <summary>Gets the number of glyph mappings.</summary>
			/// <returns>The number of glyph mappings.</returns>
			/// <remarks>GetGlyphMappings gets the glyph mappings.</remarks>
			// https://docs.microsoft.com/en-us/windows/win32/api/xpsobjectmodel/nf-xpsobjectmodel-ixpsomglyphs-getglyphmappingcount
			// HRESULT GetGlyphMappingCount( UINT32 *glyphMappingCount );
			uint GetGlyphMappingCount();

			/// <summary>
			/// Gets an array of XPS_GLYPH_MAPPING structures that describe how to map UTF-16 scalar values to entries in the array of XPS_GLYPH_INDEX structures, which is returned by GetGlyphIndices.
			/// </summary>
			/// <param name="glyphMappingCount">The number of XPS_GLYPH_MAPPING structures that will fit in the array referenced by glyphMappings. When the method returns, glyphMappingCount contains the number of values returned in the array referenced by glyphMappings.</param>
			/// <param name="glyphMappings">An array of XPS_GLYPH_MAPPING structures that contain the glyph mapping values.</param>
			/// <remarks>
			/// GetGlyphMappingCount gets the number of glyph mappings.
			/// </remarks>
			// https://docs.microsoft.com/en-us/windows/win32/api/xpsobjectmodel/nf-xpsobjectmodel-ixpsomglyphs-getglyphmappings
			// HRESULT GetGlyphMappings( UINT32 *glyphMappingCount, XPS_GLYPH_MAPPING *glyphMappings );
			void GetGlyphMappings(ref uint glyphMappingCount, [In, Out] XPS_GLYPH_MAPPING[] glyphMappings);

			/// <summary>Gets the number of prohibited caret stops.</summary>
			/// <returns>The number of prohibited caret stops.</returns>
			/// <remarks>
			/// <para>GetProhibitedCaretStops gets the prohibited caret stops.</para>
			/// <para>Each caret stop index corresponds to the scalar values of a UTF-16 <c>UnicodeString</c> property. Index 0 represents the location just before the first UTF-16 scalar value of <c>UnicodeString</c>; index 1 represents the location between the first and second UTF-16 scalar values, and so on. There is an additional index at the end of <c>UnicodeString</c>. Any unspecified index is a valid caret stop location.</para>
			/// </remarks>
			// https://docs.microsoft.com/en-us/windows/win32/api/xpsobjectmodel/nf-xpsobjectmodel-ixpsomglyphs-getprohibitedcaretstopcount
			// HRESULT GetProhibitedCaretStopCount( UINT32 *prohibitedCaretStopCount );
			uint GetProhibitedCaretStopCount();

			/// <summary>
			/// Gets an array of prohibited caret stop locations.
			/// </summary>
			/// <param name="prohibitedCaretStopCount">The number of prohibited caret stop locations that will fit in the array referenced by prohibitedCaretStops. When the method returns, prohibitedCaretStopCount will contain the number of values returned in the array referenced by prohibitedCaretStops.</param>
			/// <param name="prohibitedCaretStops">An array of prohibited caret stop locations; if such are not defined, a <c>NULL</c> pointer is returned.</param>
			/// <remarks>
			/// <para>Each caret stop index corresponds to the scalar values of a UTF-16 <c>UnicodeString</c> property. Index 0 represents the location just before the first UTF-16 scalar value of <c>UnicodeString</c>; index 1 represents the location between the first and second UTF-16 scalar values, and so on. There is an additional index at the end of <c>UnicodeString</c>. Any unspecified index is a valid caret stop location.</para>
			/// <para>GetProhibitedCaretStopCount gets the number of prohibited caret stops.</para>
			/// <para>A caret stop is the index of the UTF-16 code point in the <c>UnicodeString</c> property of the glyph.</para>
			/// </remarks>
			// https://docs.microsoft.com/en-us/windows/win32/api/xpsobjectmodel/nf-xpsobjectmodel-ixpsomglyphs-getprohibitedcaretstops
			// HRESULT GetProhibitedCaretStops( UINT32 *prohibitedCaretStopCount, UINT32 *prohibitedCaretStops );
			void GetProhibitedCaretStops(ref uint prohibitedCaretStopCount, [In, Out] uint[] prohibitedCaretStops);

			/// <summary>Gets the level of bidirectional text.</summary>
			/// <returns>
			/// <para>The level of bidirectional text.</para>
			/// <para>Range: 0–61</para>
			/// </returns>
			/// <remarks>
			/// <para>The bidirectional text level, or <c>BidiLevel</c>, specifies the nesting level of the Unicode bidirectional algorithm. Even values imply the left-to-right layout and odd values the right-to-left layout, which places the run origin on the right side of the first glyph. Advance widths that are positive will move to the left, allowing subsequent glyphs to be placed to the left of the previous glyph.</para>
			/// <para>The range of allowed values for this property is between 0 and 61, inclusive, and the default value is 0.</para>
			/// </remarks>
			// https://docs.microsoft.com/en-us/windows/win32/api/xpsobjectmodel/nf-xpsobjectmodel-ixpsomglyphs-getbidilevel
			// HRESULT GetBidiLevel( UINT32 *bidiLevel );
			uint GetBidiLevel();

			/// <summary>Gets a Boolean value that indicates whether the text is to be rendered with the glyphs rotated sideways.</summary>
			/// <returns>
			/// <para>The Boolean value that indicates whether the text is to be rendered with the glyphs rotated sideways.</para>
			/// <list type="table">
			/// <listheader>
			/// <term>Value</term>
			/// <term>Meaning</term>
			/// </listheader>
			/// <item>
			/// <term>TRUE</term>
			/// <term>Render the glyphs sideways to produce sideways text.</term>
			/// </item>
			/// <item>
			/// <term>FALSE</term>
			/// <term>Do not render the glyphs sideways to produce normal text.</term>
			/// </item>
			/// </list>
			/// </returns>
			/// <remarks>The default value for this property is <c>FALSE</c>.</remarks>
			// https://docs.microsoft.com/en-us/windows/win32/api/xpsobjectmodel/nf-xpsobjectmodel-ixpsomglyphs-getissideways
			// HRESULT GetIsSideways( BOOL *isSideways );
			[return: MarshalAs(UnmanagedType.Bool)]
			bool GetIsSideways();

			/// <summary>Gets the name of the device font.</summary>
			/// <returns>The string that contains the unescaped name of the device font. If the name has not been set, a <c>NULL</c> pointer will be returned.</returns>
			/// <remarks>
			/// <para>The device font name uniquely identifies a specific device font and is typically defined by a hardware vendor or font vendor.</para>
			/// <para>The escaped version of the device font name is created when the object is serialized.</para>
			/// </remarks>
			// https://docs.microsoft.com/en-us/windows/win32/api/xpsobjectmodel/nf-xpsobjectmodel-ixpsomglyphs-getdevicefontname
			// HRESULT GetDeviceFontName( LPWSTR *deviceFontName );
			SafeCoTaskMemString GetDeviceFontName();

			/// <summary>Gets the style simulations that will be applied when rendering the glyphs.</summary>
			/// <returns>The XPS_STYLE_SIMULATION value that describes the style simulations to be applied.</returns>
			// https://docs.microsoft.com/en-us/windows/win32/api/xpsobjectmodel/nf-xpsobjectmodel-ixpsomglyphs-getstylesimulations
			// HRESULT GetStyleSimulations( XPS_STYLE_SIMULATION *styleSimulations );
			XPS_STYLE_SIMULATION GetStyleSimulations();

			/// <summary>
			/// Sets the style simulations that will be applied when the glyphs are rendered.
			/// </summary>
			/// <param name="styleSimulations">The XPS_STYLE_SIMULATION value that specifies the style simulation to be applied.</param>
			// https://docs.microsoft.com/en-us/windows/win32/api/xpsobjectmodel/nf-xpsobjectmodel-ixpsomglyphs-setstylesimulations
			// HRESULT SetStyleSimulations( XPS_STYLE_SIMULATION styleSimulations );
			void SetStyleSimulations([In] XPS_STYLE_SIMULATION styleSimulations);

			/// <summary>Gets the starting position of the text.</summary>
			/// <returns>The XPS_POINT structure that receives the starting position of the text.</returns>
			/// <remarks>In the units of the effective coordinate space, the origin specifies the x and y coordinates of the first glyph in the run. The glyph is placed such that its baseline and the leading edge of its advance vector intersect with the point defined by origin.x and origin.y.</remarks>
			// https://docs.microsoft.com/en-us/windows/win32/api/xpsobjectmodel/nf-xpsobjectmodel-ixpsomglyphs-getorigin
			// HRESULT GetOrigin( XPS_POINT *origin );
			XPS_POINT GetOrigin();

			/// <summary>
			/// Sets the starting position of the text.
			/// </summary>
			/// <param name="origin">The XPS_POINT structure that contains the coordinates to be set as the text's starting position.</param>
			/// <remarks>
			/// In the units of the effective coordinate space, the origin specifies the x and y coordinates of the first glyph in the run. The glyph is placed such that its baseline and the leading edge of its advance vector intersect with the point defined by origin.x and origin.y.
			/// </remarks>
			// https://docs.microsoft.com/en-us/windows/win32/api/xpsobjectmodel/nf-xpsobjectmodel-ixpsomglyphs-setorigin
			// HRESULT SetOrigin( const XPS_POINT *origin );
			void SetOrigin(in XPS_POINT origin);

			/// <summary>Gets the font size.</summary>
			/// <returns>The font size.</returns>
			/// <remarks>
			/// <para>The em size that is returned in fontRenderingEmSize specifies the font size in the drawing surface units. The drawing surface units are expressed as floating-point values in the effective coordinate space.</para>
			/// <para>In new glyph objects, the default value of fontRenderingEmSize is 10.0.</para>
			/// <para>If the value of fontRenderingEmSize is 0.0, no text is displayed.</para>
			/// </remarks>
			// https://docs.microsoft.com/en-us/windows/win32/api/xpsobjectmodel/nf-xpsobjectmodel-ixpsomglyphs-getfontrenderingemsize
			// HRESULT GetFontRenderingEmSize( FLOAT *fontRenderingEmSize );
			float GetFontRenderingEmSize();

			/// <summary>
			/// Sets the font size of the text.
			/// </summary>
			/// <param name="fontRenderingEmSize">The font size.</param>
			/// <remarks>
			/// <para>The em size returned in fontRenderingEmSize specifies the font size in drawing surface units. Drawing surface units are expressed as floating-point values in the units of the effective coordinate space.</para>
			/// <para>In new glyph objects, the default value of fontRenderingEmSize is 10.0.</para>
			/// <para>If the value of fontRenderingEmSize is 0.0, no text is displayed.</para>
			/// <para>A value of 0.0 results in no visible text being displayed.</para>
			/// </remarks>
			// https://docs.microsoft.com/en-us/windows/win32/api/xpsobjectmodel/nf-xpsobjectmodel-ixpsomglyphs-setfontrenderingemsize
			// HRESULT SetFontRenderingEmSize( FLOAT fontRenderingEmSize );
			void SetFontRenderingEmSize([In] float fontRenderingEmSize);

			/// <summary>Gets a pointer to the IXpsOMFontResource interface of the font resource object required for this text.</summary>
			/// <returns>A pointer to the IXpsOMFontResource interface of the font resource.</returns>
			/// <remarks>After loading and parsing the resource into the XPS OM, this method might return an error that applies to another resource. This occurs because all of the relationships are parsed when a resource is loaded.</remarks>
			// https://docs.microsoft.com/en-us/windows/win32/api/xpsobjectmodel/nf-xpsobjectmodel-ixpsomglyphs-getfontresource
			// HRESULT GetFontResource( IXpsOMFontResource **fontResource );
			IXpsOMFontResource GetFontResource();

			/// <summary>
			/// Sets the pointer to the IXpsOMFontResource interface of the font resource object that is required for this text.
			/// </summary>
			/// <param name="fontResource">The pointer to the IXpsOMFontResource interface to be used.</param>
			/// <remarks>
			/// fontResource must not be a <c>NULL</c> pointer; a glyph object must have a font resource.
			/// </remarks>
			// https://docs.microsoft.com/en-us/windows/win32/api/xpsobjectmodel/nf-xpsobjectmodel-ixpsomglyphs-setfontresource
			// HRESULT SetFontResource( IXpsOMFontResource *fontResource );
			void SetFontResource([In] IXpsOMFontResource fontResource);

			/// <summary>
			/// <para>Gets the index of the font face to be used.</para>
			/// <para>This value is only used when GetFontResource returns an IXpsOMFontResource interface that represents a <c>TrueType</c> font collection.</para>
			/// </summary>
			/// <returns>The index value of the font face. If the font face has not been set, –1 is returned.</returns>
			/// <remarks>
			/// <para>The font resource is obtained by calling the GetFontResource method.</para>
			/// <para>If a font face has not been set or is not supported by the font, a value of –1 is returned in fontFaceIndex. When the glyph is loaded from an existing XPS document file, a fontFaceIndex value of –1 indicates that the <c>FontUri</c> attribute did not include a <c>#index</c> fragment.</para>
			/// <para>In the following markup of a FixedPage, the <c>FontUri</c> attribute of the <c>Glyphs</c> element has a value of . In this case, <c>GetFontFaceIndex</c> would return a value of 1 in fontFaceIndex.</para>
			/// </remarks>
			// https://docs.microsoft.com/en-us/windows/win32/api/xpsobjectmodel/nf-xpsobjectmodel-ixpsomglyphs-getfontfaceindex
			// HRESULT GetFontFaceIndex( SHORT *fontFaceIndex );
			short GetFontFaceIndex();

			/// <summary>
			/// <para>Sets the index of the font face to be used.</para>
			/// <para>This value is only used when GetFontResource returns an IXpsOMFontResource interface that represents a <c>TrueType</c> font collection.</para>
			/// </summary>
			/// <param name="fontFaceIndex">The index value of the font face to be used.</param>
			/// <remarks>
			/// <para>The default value of the font face index property is –1, which means that a font index has not been set or the font resource is not a <c>TrueType</c> font collection.</para>
			/// <para>If this value is specified and is not –1, "#&lt;Index&gt;" is appended to the Font URI during serialization. Here, &lt;Index&gt; is the value that is set by <c>SetFontFaceIndex</c>.</para>
			/// <para>The following markup of a FixedPage shows the result of setting the fontFaceIndex to 1. Notice that the <c>FontUri</c> attribute of the <c>Glyphs</c> element has a value of , which includes the index of the font face.</para>
			/// </remarks>
			// https://docs.microsoft.com/en-us/windows/win32/api/xpsobjectmodel/nf-xpsobjectmodel-ixpsomglyphs-setfontfaceindex
			// HRESULT SetFontFaceIndex( SHORT fontFaceIndex );
			void SetFontFaceIndex([In] short fontFaceIndex);

			/// <summary>Gets a pointer to the resolved IXpsOMBrush interface of the fill brush to be used for the text.</summary>
			/// <returns>
			/// <para>A pointer to the resolved IXpsOMBrush interface of the fill brush to be used for the text. If a fill brush has not been set, a <c>NULL</c> pointer will be returned.</para>
			/// <para>The value that is returned in this parameter depends on which method has most recently been called to set the brush.</para>
			/// <list type="table">
			/// <listheader>
			/// <term>Most recent method called</term>
			/// <term>Object that is returned in fillBrush</term>
			/// </listheader>
			/// <item>
			/// <term>SetFillBrushLocal</term>
			/// <term>The local brush that is set by SetFillBrushLocal.</term>
			/// </item>
			/// <item>
			/// <term>SetFillBrushLookup</term>
			/// <term>The shared brush retrieved, with a lookup key that matches the key that is set by SetFillBrushLookup, from the local or resource directory.</term>
			/// </item>
			/// <item>
			/// <term>Neither SetFillBrushLocal nor SetFillBrushLookup has been called yet.</term>
			/// <term>NULL pointer.</term>
			/// </item>
			/// </list>
			/// </returns>
			/// <remarks>The fill brush is used to fill the shape of the rendered glyphs.</remarks>
			// https://docs.microsoft.com/en-us/windows/win32/api/xpsobjectmodel/nf-xpsobjectmodel-ixpsomglyphs-getfillbrush
			// HRESULT GetFillBrush( IXpsOMBrush **fillBrush );
			IXpsOMBrush GetFillBrush();

			/// <summary>Gets a pointer to the local, unshared IXpsOMBrush interface of the fill brush to be used for the text.</summary>
			/// <returns>
			/// <para>A pointer to the local, unshared IXpsOMBrush interface of the fill brush to be used for the text. If a fill brush lookup key has been set or if a local fill brush has not been set, a <c>NULL</c> pointer will be returned.</para>
			/// <list type="table">
			/// <listheader>
			/// <term>Most recent method called</term>
			/// <term>Object that is returned in fillBrush</term>
			/// </listheader>
			/// <item>
			/// <term>SetFillBrushLocal</term>
			/// <term>The local brush that is set by SetFillBrushLocal.</term>
			/// </item>
			/// <item>
			/// <term>SetFillBrushLookup</term>
			/// <term>NULL pointer.</term>
			/// </item>
			/// <item>
			/// <term>Neither SetFillBrushLocal nor SetFillBrushLookup has been called yet.</term>
			/// <term>NULL pointer.</term>
			/// </item>
			/// </list>
			/// </returns>
			// https://docs.microsoft.com/en-us/windows/win32/api/xpsobjectmodel/nf-xpsobjectmodel-ixpsomglyphs-getfillbrushlocal
			// HRESULT GetFillBrushLocal( IXpsOMBrush **fillBrush );
			IXpsOMBrush GetFillBrushLocal();

			/// <summary>
			/// Sets the IXpsOMBrush interface pointer to a local, unshared fill brush.
			/// </summary>
			/// <param name="fillBrush">The IXpsOMBrush interface pointer to be set as the local, unshared fill brush. A <c>NULL</c> pointer releases any previously assigned brushes.</param>
			/// <remarks>
			/// <para>After you call <c>SetFillBrushLocal</c>, the fill brush lookup key is released and GetFillBrushLookup returns a <c>NULL</c> pointer in the key parameter. The table that follows explains the relationship between the local and lookup values of this property.</para>
			/// <list type="table">
			///   <listheader>
			///     <term>Most recent method called</term>
			///     <term>Object that is returned in fillBrush by GetFillBrush</term>
			///     <term>Object that is returned in fillBrush by GetFillBrushLocal</term>
			///     <term>String that is returned in key by GetFillBrushLookup</term>
			///   </listheader>
			///   <item>
			///     <term>SetFillBrushLocal (this method)</term>
			///     <term>The local brush that is set by SetFillBrushLocal.</term>
			///     <term>The local brush that is set by SetFillBrushLocal.</term>
			///     <term>NULL pointer.</term>
			///   </item>
			///   <item>
			///     <term>SetFillBrushLookup</term>
			///     <term>The shared brush that gets retrieved, with a lookup key matching the key that is set by SetFillBrushLookup, from the resource directory.</term>
			///     <term>NULL pointer.</term>
			///     <term>The lookup key that is set by SetFillBrushLookup.</term>
			///   </item>
			///   <item>
			///     <term>Neither SetFillBrushLocal nor SetFillBrushLookup has been called yet.</term>
			///     <term>NULL pointer.</term>
			///     <term>NULL pointer.</term>
			///     <term>NULL pointer.</term>
			///   </item>
			/// </list>
			/// </remarks>
			// https://docs.microsoft.com/en-us/windows/win32/api/xpsobjectmodel/nf-xpsobjectmodel-ixpsomglyphs-setfillbrushlocal
			// HRESULT SetFillBrushLocal( IXpsOMBrush *fillBrush );
			void SetFillBrushLocal([In] IXpsOMBrush fillBrush);

			/// <summary>Gets the lookup key of the IXpsOMBrush interface that is stored in a resource dictionary and will be used as the fill brush.</summary>
			/// <returns>
			/// <para>The lookup key for the brush that is stored in a resource dictionary and will be used as the fill brush. If a fill brush lookup key has not been set or if a local fill brush has been set, a <c>NULL</c> pointer will be returned.</para>
			/// <list type="table">
			/// <listheader>
			/// <term>Most recent method called</term>
			/// <term>String that is returned in key</term>
			/// </listheader>
			/// <item>
			/// <term>SetFillBrushLocal</term>
			/// <term>NULL pointer.</term>
			/// </item>
			/// <item>
			/// <term>SetFillBrushLookup</term>
			/// <term>The lookup key that is set by SetFillBrushLookup.</term>
			/// </item>
			/// <item>
			/// <term>Neither SetFillBrushLocal nor SetFillBrushLookup has been called yet.</term>
			/// <term>NULL pointer.</term>
			/// </item>
			/// </list>
			/// </returns>
			// https://docs.microsoft.com/en-us/windows/win32/api/xpsobjectmodel/nf-xpsobjectmodel-ixpsomglyphs-getfillbrushlookup
			// HRESULT GetFillBrushLookup( LPWSTR *key );
			SafeCoTaskMemString GetFillBrushLookup();

			/// <summary>
			/// Sets the lookup key name of a shared fill brush.
			/// </summary>
			/// <param name="key">A string variable that contains the key name of the fill brush that is stored in the resource dictionary and will be used as the shared fill brush. A <c>NULL</c> pointer clears any previously assigned key string.</param>
			/// <remarks>
			/// <para>After you call <c>SetFillBrushLookup</c>, the local fill brush is released and GetFillBrushLocal returns a <c>NULL</c> pointer in the fillBrush parameter. The table that follows explains the relationship between the local and lookup values of this property.</para>
			/// <list type="table">
			///   <listheader>
			///     <term>Most recent method called</term>
			///     <term>Object that is returned in fillBrush by GetFillBrush</term>
			///     <term>Object that is returned in fillBrush by GetFillBrushLocal</term>
			///     <term>String that is returned in key by GetFillBrushLookup</term>
			///   </listheader>
			///   <item>
			///     <term>SetFillBrushLocal</term>
			///     <term>The local brush that is set by SetFillBrushLocal.</term>
			///     <term>The local brush that is set by SetFillBrushLocal.</term>
			///     <term>NULL pointer.</term>
			///   </item>
			///   <item>
			///     <term>SetFillBrushLookup (this method)</term>
			///     <term>The shared brush that gets retrieved, with a lookup key matching the key that is set by SetFillBrushLookup, from the resource directory.</term>
			///     <term>NULL pointer.</term>
			///     <term>The lookup key that is set by SetFillBrushLookup.</term>
			///   </item>
			///   <item>
			///     <term>Neither SetFillBrushLocal nor SetFillBrushLookup has been called yet.</term>
			///     <term>NULL pointer.</term>
			///     <term>NULL pointer.</term>
			///     <term>NULL pointer.</term>
			///   </item>
			/// </list>
			/// </remarks>
			// https://docs.microsoft.com/en-us/windows/win32/api/xpsobjectmodel/nf-xpsobjectmodel-ixpsomglyphs-setfillbrushlookup
			// HRESULT SetFillBrushLookup( LPCWSTR key );
			void SetFillBrushLookup([In, MarshalAs(UnmanagedType.LPWStr)] string key);

			/// <summary>Gets a pointer to the IXpsOMGlyphsEditor interface that will be used to edit the glyphs in the object.</summary>
			/// <returns>A pointer to the IXpsOMGlyphsEditor interface.</returns>
			/// <remarks>An IXpsOMGlyphsEditor interface is required to edit the read-only properties of the IXpsOMGlyphs interface.</remarks>
			// https://docs.microsoft.com/en-us/windows/win32/api/xpsobjectmodel/nf-xpsobjectmodel-ixpsomglyphs-getglyphseditor
			// HRESULT GetGlyphsEditor( IXpsOMGlyphsEditor **editor );
			IXpsOMGlyphsEditor GetGlyphsEditor();

			/// <summary>Makes a deep copy of the interface.</summary>
			/// <returns>A pointer to the copy of the interface.</returns>
			/// <remarks>This method does not update any of the resource pointers in the copy of the interface.</remarks>
			// https://docs.microsoft.com/en-us/windows/win32/api/xpsobjectmodel/nf-xpsobjectmodel-ixpsomglyphs-clone
			// HRESULT Clone( IXpsOMGlyphs **glyphs );
			IXpsOMGlyphs Clone();
		}

		/// <summary>Allows batch modification of properties that affect the text content in an IXpsOMGlyphs interface.</summary>
		// https://docs.microsoft.com/en-us/windows/win32/api/xpsobjectmodel/nn-xpsobjectmodel-ixpsomglyphseditor
		[PInvokeData("xpsobjectmodel.h", MSDNShortId = "5bdf2892-ce6f-4560-b638-e441166fc309")]
		[ComImport, Guid("A5AB8616-5B16-4B9F-9629-89B323ED7909"), InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
		public interface IXpsOMGlyphsEditor
		{
			/// <summary>
			/// Performs cross-property validation and then copies the changes to the parent IXpsOMGlyphs interface.
			/// </summary>
			/// <remarks>
			/// The IXpsOMGlyphsEditor interface remains valid after this method is called, allowing for additional modifications to be made.
			/// </remarks>
			// https://docs.microsoft.com/en-us/windows/win32/api/xpsobjectmodel/nf-xpsobjectmodel-ixpsomglyphseditor-applyedits
			// HRESULT ApplyEdits();
			void ApplyEdits();

			/// <summary>Gets the text in unescaped UTF-16 scalar values.</summary>
			/// <returns>The UTF-16 Unicode string. If the string is empty, a <c>NULL</c> pointer is returned.</returns>
			// https://docs.microsoft.com/en-us/windows/win32/api/xpsobjectmodel/nf-xpsobjectmodel-ixpsomglyphseditor-getunicodestring
			// HRESULT GetUnicodeString( LPWSTR *unicodeString );
			SafeCoTaskMemString GetUnicodeString();

			/// <summary>Sets the text in unescaped UTF-16 scalar values.</summary>
			/// <param name="unicodeString">The address of a UTF-16 Unicode string. A <c>NULL</c> pointer clears the property.</param>
			// https://docs.microsoft.com/en-us/windows/win32/api/xpsobjectmodel/nf-xpsobjectmodel-ixpsomglyphseditor-setunicodestring
			// HRESULT SetUnicodeString( LPCWSTR unicodeString );
			void SetUnicodeString([In, MarshalAs(UnmanagedType.LPWStr)] string unicodeString);

			/// <summary>Gets the number of glyph indices.</summary>
			/// <returns>The glyph index count.</returns>
			/// <remarks>To get the glyph indices, call GetGlyphIndices.</remarks>
			// https://docs.microsoft.com/en-us/windows/win32/api/xpsobjectmodel/nf-xpsobjectmodel-ixpsomglyphseditor-getglyphindexcount
			// HRESULT GetGlyphIndexCount( UINT32 *indexCount );
			uint GetGlyphIndexCount();

			/// <summary>
			/// Gets an array of XPS_GLYPH_INDEX structures that describe the specific glyph indices in the font.
			/// </summary>
			/// <param name="indexCount">The number of elements that will fit in the array referenced by the glyphIndices parameter. When the method returns, indexCount will contain the number of XPS_GLYPH_INDEX structures that are returned in the array referenced by glyphIndices.</param>
			/// <param name="glyphIndices">The XPS_GLYPH_INDEX structure array that receives the glyph indices.</param>
			/// <remarks>
			/// <para>The glyph indices that are returned in glyphIndices override the default cmap mapping from the <c>UnicodeString</c> property to the glyph index. Each XPS_GLYPH_INDEX structure also contains advance width and vertical and horizontal offset information.</para>
			/// <para>GetGlyphIndexCount gets the number of elements in the glyph index array.</para>
			/// </remarks>
			// https://docs.microsoft.com/en-us/windows/win32/api/xpsobjectmodel/nf-xpsobjectmodel-ixpsomglyphseditor-getglyphindices
			// HRESULT GetGlyphIndices( UINT32 *indexCount, XPS_GLYPH_INDEX *glyphIndices );
			void GetGlyphIndices(ref uint indexCount, [In, Out] XPS_GLYPH_INDEX[] glyphIndices);

			/// <summary>
			/// Sets an XPS_GLYPH_INDEX structure array that describes which glyph indices are to be used in the font.
			/// </summary>
			/// <param name="indexCount">The number of XPS_GLYPH_INDEX structures in the array that is referenced by glyphIndices. The value of 0 clears the property.</param>
			/// <param name="glyphIndices">An array of XPS_GLYPH_INDEX structures that contain the glyph indices. If indexCount is 0, this parameter is ignored.</param>
			/// <remarks>
			/// The glyph indices that are passed in glyphIndices override the default cmap mapping from the <c>UnicodeString</c> property to the glyph index. Each XPS_GLYPH_INDEX structure also has advance width and vertical and horizontal offset information.
			/// </remarks>
			// https://docs.microsoft.com/en-us/windows/win32/api/xpsobjectmodel/nf-xpsobjectmodel-ixpsomglyphseditor-setglyphindices
			// HRESULT SetGlyphIndices( UINT32 indexCount, const XPS_GLYPH_INDEX *glyphIndices );
			void SetGlyphIndices([In] uint indexCount, [In] XPS_GLYPH_INDEX[] glyphIndices);

			/// <summary>Gets the number of glyph mappings.</summary>
			/// <returns>The number of glyph mappings.</returns>
			/// <remarks>To get the glyph mappings, call GetGlyphMappings.</remarks>
			// https://docs.microsoft.com/en-us/windows/win32/api/xpsobjectmodel/nf-xpsobjectmodel-ixpsomglyphseditor-getglyphmappingcount
			// HRESULT GetGlyphMappingCount( UINT32 *glyphMappingCount );
			uint GetGlyphMappingCount();

			/// <summary>
			/// Gets an array of XPS_GLYPH_MAPPING structures that describe how to map UTF-16 scalar values to entries in the array of XPS_GLYPH_INDEX structures, which is returned by GetGlyphIndices.
			/// </summary>
			/// <param name="glyphMappingCount">The number of XPS_GLYPH_MAPPING structures that will fit in the array referenced by glyphMappings. When the method returns, glyphMappingCount will contain the number of values in that array.</param>
			/// <param name="glyphMappings">An array of XPS_GLYPH_MAPPING structures that receives the glyph mapping values.</param>
			/// <remarks>
			/// GetGlyphMappingCount gets the number of glyph mappings.
			/// </remarks>
			// https://docs.microsoft.com/en-us/windows/win32/api/xpsobjectmodel/nf-xpsobjectmodel-ixpsomglyphseditor-getglyphmappings
			// HRESULT GetGlyphMappings( UINT32 *glyphMappingCount, XPS_GLYPH_MAPPING *glyphMappings );
			void GetGlyphMappings(ref uint glyphMappingCount, [In, Out] XPS_GLYPH_MAPPING[] glyphMappings);

			/// <summary>
			/// Sets an array of XPS_GLYPH_MAPPING structures that describe how to map the UTF-16 scalar values in the <c>UnicodeString</c> property to entries in the array of XPS_GLYPH_INDEX structures.
			/// </summary>
			/// <param name="glyphMappingCount">The number of XPS_GLYPH_MAPPING structures in the array that is referenced by glyphMappings. A value of 0 clears the property.</param>
			/// <param name="glyphMappings">An XPS_GLYPH_MAPPING structure array that contains the glyph mapping values. If glyphMappingCount is 0, this parameter is ignored and can be set to <c>NULL</c>.</param>
			// https://docs.microsoft.com/en-us/windows/win32/api/xpsobjectmodel/nf-xpsobjectmodel-ixpsomglyphseditor-setglyphmappings
			// HRESULT SetGlyphMappings( UINT32 glyphMappingCount, const XPS_GLYPH_MAPPING *glyphMappings );
			void SetGlyphMappings([In] uint glyphMappingCount, [In] XPS_GLYPH_MAPPING[] glyphMappings);

			/// <summary>Gets the number of prohibited caret stops.</summary>
			/// <returns>The number of prohibited caret stops.</returns>
			/// <remarks>
			/// <para>To get the prohibited caret stops, call GetProhibitedCaretStops.</para>
			/// <para>Each caret stop index corresponds to the scalar values of a UTF-16 <c>UnicodeString</c> property. Index 0 represents the location just before the first UTF-16 scalar value of <c>UnicodeString</c>; index 1 represents the location between the first and second UTF-16 scalar values, and so on. There is an additional index at the end of <c>UnicodeString</c>. Any unspecified index is a valid caret stop location.</para>
			/// </remarks>
			// https://docs.microsoft.com/en-us/windows/win32/api/xpsobjectmodel/nf-xpsobjectmodel-ixpsomglyphseditor-getprohibitedcaretstopcount
			// HRESULT GetProhibitedCaretStopCount( UINT32 *prohibitedCaretStopCount );
			uint GetProhibitedCaretStopCount();

			/// <summary>
			/// Gets an array of prohibited caret stop locations.
			/// </summary>
			/// <param name="count">The number of prohibited caret stop values that will fit in the array that is referenced by the prohibitedCaretStops parameter. When the method returns, prohibitedCaretStopCount will contain the number of values in that array.</param>
			/// <param name="prohibitedCaretStops">An array of glyph mapping values. If no prohibited caret stops have been defined, a <c>NULL</c> pointer is returned.</param>
			/// <remarks>
			/// <para>Each caret stop index corresponds to the scalar values of a UTF-16 <c>UnicodeString</c> property. Index 0 represents the location just before the first UTF-16 scalar value of <c>UnicodeString</c>; index 1 represents the location between the first and second UTF-16 scalar values, and so on. There is an additional index at the end of <c>UnicodeString</c>. Any unspecified index is a valid caret stop location.</para>
			/// <para>GetProhibitedCaretStopCount gets the number of prohibited caret stops.</para>
			/// <para>A caret stop is the index of the UTF-16 code point in the <c>UnicodeString</c> property of the glyph.</para>
			/// </remarks>
			// https://docs.microsoft.com/en-us/windows/win32/api/xpsobjectmodel/nf-xpsobjectmodel-ixpsomglyphseditor-getprohibitedcaretstops
			// HRESULT GetProhibitedCaretStops( UINT32 *count, UINT32 *prohibitedCaretStops );
			void GetProhibitedCaretStops(ref uint count, [In, Out] uint[] prohibitedCaretStops);

			/// <summary>
			/// Sets an array of prohibited caret stop locations.
			/// </summary>
			/// <param name="count">The number of prohibited caret stop locations in the array that is referenced by prohibitedCaretStops. A value of 0 clears the property.</param>
			/// <param name="prohibitedCaretStops">The array of prohibited caret stop locations to be set. If count is 0, this parameter is ignored and can be set to <c>NULL</c>.</param>
			/// <remarks>
			/// Each caret stop index corresponds to the scalar values of a UTF-16 <c>UnicodeString</c> property. Index 0 represents the location just before the first UTF-16 scalar value of <c>UnicodeString</c>; index 1 represents the location between the first and second UTF-16 scalar values, and so on. There is an additional index at the end of <c>UnicodeString</c>. Any unspecified index is a valid caret stop location.
			/// </remarks>
			// https://docs.microsoft.com/en-us/windows/win32/api/xpsobjectmodel/nf-xpsobjectmodel-ixpsomglyphseditor-setprohibitedcaretstops
			// HRESULT SetProhibitedCaretStops( UINT32 count, const UINT32 *prohibitedCaretStops );
			void SetProhibitedCaretStops([In] uint count, [In] uint[] prohibitedCaretStops);

			/// <summary>Gets the bidirectional text level of the parent IXpsOMGlyphs interface.</summary>
			/// <returns>
			/// <para>The bidirectional text level.</para>
			/// <para>Range: 0–61</para>
			/// </returns>
			/// <remarks>
			/// <para>The <c>BidiLevel</c> property specifies the bidirectional nesting level of the Unicode algorithm. Even values imply the left-to-right layout and odd values the right-to-left layout. Right-to-left layout places the run origin at the right side of the first glyph. Advance widths that are positive will move to the left, allowing subsequent glyphs to be placed to the left of the previous glyph.</para>
			/// <para>The range of allowed values for this property is between 0 and 61, inclusive, and the default value is 0.</para>
			/// </remarks>
			// https://docs.microsoft.com/en-us/windows/win32/api/xpsobjectmodel/nf-xpsobjectmodel-ixpsomglyphseditor-getbidilevel
			// HRESULT GetBidiLevel( UINT32 *bidiLevel );
			uint GetBidiLevel();

			/// <summary>
			/// Sets the level of bidirectional text.
			/// </summary>
			/// <param name="bidiLevel"><para>The level of bidirectional text.</para>
			/// <para>Range: 0–61</para></param>
			/// <remarks>
			/// <para>The <c>BidiLevel</c> property specifies the bidirectional nesting level of the Unicode algorithm. Even values imply the left-to-right layout and odd values the right-to-left layout. Right-to-left layout places the run origin on the right side of the first glyph. Advance widths that are positive will move to the left, allowing subsequent glyphs to be placed to the left of the previous glyph.</para>
			/// <para>The range of allowed values for this property is between 0 and 61, inclusive, and the default value is 0.</para>
			/// </remarks>
			// https://docs.microsoft.com/en-us/windows/win32/api/xpsobjectmodel/nf-xpsobjectmodel-ixpsomglyphseditor-setbidilevel
			// HRESULT SetBidiLevel( UINT32 bidiLevel );
			void SetBidiLevel([In] uint bidiLevel);

			/// <summary>Gets a Boolean value that indicates whether the text is to be rendered with the glyphs rotated sideways.</summary>
			/// <returns>
			/// <para>The Boolean value that indicates whether the text is to be rendered with the glyphs rotated sideways.</para>
			/// <list type="table">
			/// <listheader>
			/// <term>Value</term>
			/// <term>Meaning</term>
			/// </listheader>
			/// <item>
			/// <term>TRUE</term>
			/// <term>Rotate the glyphs sideways. Produces sideways text.</term>
			/// </item>
			/// <item>
			/// <term>FALSE</term>
			/// <term>Do not rotate the glyphs sideways. Produces normal text.</term>
			/// </item>
			/// </list>
			/// </returns>
			/// <remarks>The default value for this property is <c>false</c>.</remarks>
			// https://docs.microsoft.com/en-us/windows/win32/api/xpsobjectmodel/nf-xpsobjectmodel-ixpsomglyphseditor-getissideways
			// HRESULT GetIsSideways( BOOL *isSideways );
			[return: MarshalAs(UnmanagedType.Bool)]
			bool GetIsSideways();

			/// <summary>
			/// Sets the value that indicates whether the text is to be rendered with the glyphs rotated sideways.
			/// </summary>
			/// <param name="isSideways"><para>The Boolean value that indicates whether the text is to be rendered with the glyphs rotated sideways.</para>
			/// <list type="table">
			///   <listheader>
			///     <term>Value</term>
			///     <term>Meaning</term>
			///   </listheader>
			///   <item>
			///     <term>TRUE</term>
			///     <term>Rotate the glyphs sideways. Produces sideways text.</term>
			///   </item>
			///   <item>
			///     <term>FALSE</term>
			///     <term>Do not rotate the glyphs sideways. Produces normal text.</term>
			///   </item>
			/// </list></param>
			// https://docs.microsoft.com/en-us/windows/win32/api/xpsobjectmodel/nf-xpsobjectmodel-ixpsomglyphseditor-setissideways
			// HRESULT SetIsSideways( BOOL isSideways );
			void SetIsSideways([In, MarshalAs(UnmanagedType.Bool)] bool isSideways);

			/// <summary>Gets the name of the device font.</summary>
			/// <returns>The name of the device font; if not specified, a <c>NULL</c> pointer will be returned.</returns>
			/// <remarks>
			/// <para>The device font name is created as an escaped name when the object is serialized.</para>
			/// <para>The device font name uniquely identifies a specific device font and is typically defined by a hardware or font vendor.</para>
			/// </remarks>
			// https://docs.microsoft.com/en-us/windows/win32/api/xpsobjectmodel/nf-xpsobjectmodel-ixpsomglyphseditor-getdevicefontname
			// HRESULT GetDeviceFontName( LPWSTR *deviceFontName );
			SafeCoTaskMemString GetDeviceFontName();

			/// <summary>
			/// Sets the name of the device font.
			/// </summary>
			/// <param name="deviceFontName">A pointer to the string that contains the name of the device font in its unescaped form. A <c>NULL</c> pointer clears the property.</param>
			/// <remarks>
			/// The device font name that is passed in deviceFontName can be set in its unescaped form; it will be converted to its escaped form when the document is serialized.
			/// </remarks>
			// https://docs.microsoft.com/en-us/windows/win32/api/xpsobjectmodel/nf-xpsobjectmodel-ixpsomglyphseditor-setdevicefontname
			// HRESULT SetDeviceFontName( LPCWSTR deviceFontName );
			void SetDeviceFontName([In, MarshalAs(UnmanagedType.LPWStr)] string deviceFontName);
		}

		/// <summary>
		/// <para>This interface describes a gradient that is made up of gradient stops. Classes that inherit from <c>IXpsOMGradientBrush</c> specify different ways of interpreting gradient stops.</para>
		/// <para><c>IXpsOMGradientBrush</c> is the base interface for the IXpsOMLinearGradientBrush and IXpsOMRadialGradientBrush interfaces.</para>
		/// </summary>
		/// <remarks>
		/// <para>The methods of this interface define the basic parameters of a gradient. The gradient type, which can be linear or radial, determines how these parameters are applied.</para>
		/// <para>As shown in the figure that follows, the start and end points of a linear gradient mark the end points of the gradient path. The gradient path is the straight line that connects the start and end points. The gradient region of a linear gradient consists of the area between the start and end points, including those points, and extends in both directions at a right angle to the gradient path. The spread area is the area outside the gradient region.</para>
		/// <para>Gradient stops define the color at specific locations along the gradient path; the color is interpolated along the gradient path between the gradient stops, as shown in the following illustration.</para>
		/// <para>As shown in the figure that follows, the gradient region of a radial gradient is the area enclosed by the ellipse that is described by the center point and the x and y radii that extend from the center point. The spread area is the area outside of that ellipse. The gradient path is a radial line that sweeps the entire gradient region from the gradient origin to the ellipse that bounds the gradient region. In the following illustration, the gradient path is not shown.</para>
		/// <para>The spread method describes how the spread area is filled. Implementation of the spread method depends on the gradient type (linear or radial). The following illustration shows several examples of how the spread area can be filled. For information about different spread methods, see XPS_SPREAD_METHOD.</para>
		/// <para>The transform determines how the resulting gradient is transformed. The visible part of the gradient that is ultimately rendered in the image is determined by the path, stroke, or glyph that is using the gradient brush.</para>
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows/win32/api/xpsobjectmodel/nn-xpsobjectmodel-ixpsomgradientbrush
		[PInvokeData("xpsobjectmodel.h", MSDNShortId = "d381b813-5368-4ffe-a9a1-0f5027ae9d80")]
		[ComImport, Guid("EDB59622-61A2-42C3-BACE-ACF2286C06BF"), InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
		public interface IXpsOMGradientBrush : IXpsOMBrush
		{
			/// <summary>Gets the <c>IUnknown</c> interface of the parent.</summary>
			/// <returns>A pointer to the <c>IUnknown</c> interface of the parent.</returns>
			// https://docs.microsoft.com/en-us/windows/win32/api/xpsobjectmodel/nf-xpsobjectmodel-ixpsomshareable-getowner
			// HRESULT GetOwner( IUnknown **owner );
			[return: MarshalAs(UnmanagedType.IUnknown)]
			new object GetOwner();

			/// <summary>Gets the object type of the interface.</summary>
			/// <returns>The XPS_OBJECT_TYPE value that describes the interface that is derived from IXpsOMShareable.</returns>
			// https://docs.microsoft.com/en-us/windows/win32/api/xpsobjectmodel/nf-xpsobjectmodel-ixpsomshareable-gettype
			// HRESULT GetType( XPS_OBJECT_TYPE *type );
			new XPS_OBJECT_TYPE GetType();

			/// <summary>Gets the opacity of the brush.</summary>
			/// <returns>
			/// The opacity value of the brush.
			/// </returns>
			/// <remarks>opacity is expressed as a value between 0.0 and 1.0; 0.0 indicates that the brush is completely transparent, 0.5 that it is 50 percent opaque, and 1.0 that it is completely opaque.</remarks>
			// https://docs.microsoft.com/en-us/windows/win32/api/xpsobjectmodel/nf-xpsobjectmodel-ixpsombrush-getopacity
			// HRESULT GetOpacity( FLOAT *opacity );
			new float GetOpacity();

			/// <summary>Sets the opacity of the brush.</summary>
			/// <param name="opacity">The opacity value of the brush.</param>
			/// <remarks>
			/// <para>opacity is expressed as a value between 0.0 and 1.0; 0.0 indicates that the brush is completely transparent, 0.5 that it is 50 percent opaque, and 1.0 that it is completely opaque.</para>
			/// <para>If opacity is less than 0.0 or greater than 1.0, the method returns an error.</para>
			/// </remarks>
			// https://docs.microsoft.com/en-us/windows/win32/api/xpsobjectmodel/nf-xpsobjectmodel-ixpsombrush-setopacity
			// HRESULT SetOpacity( FLOAT opacity );
			new void SetOpacity([In] float opacity);

			/// <summary>Gets a pointer to an IXpsOMGradientStopCollection interface that contains the collection of IXpsOMGradientStop interfaces that define the gradient.</summary>
			/// <returns>A pointer to the IXpsOMGradientStopCollection interface that contains the collection of IXpsOMGradientStop interfaces.</returns>
			/// <remarks>
			/// <para>Gradient stops, which are described in the XPS OM by an IXpsOMGradientStop interface, are used to define the color at a specific location along a gradient path; the color is interpolated between the gradient stops. The illustration that follows shows the gradient path and gradient stops of a linear gradient.</para>
			/// <para>The illustration that follows shows the gradient stops of a radial gradient. In this example, the gradient region is the area enclosed by the outer ellipse, and the radial gradient is using the <c>XPS_SPREAD_METHOD_REFLECT</c> spread method to fill the space outside of the gradient region.</para>
			/// </remarks>
			// https://docs.microsoft.com/en-us/windows/win32/api/xpsobjectmodel/nf-xpsobjectmodel-ixpsomgradientbrush-getgradientstops
			// HRESULT GetGradientStops( IXpsOMGradientStopCollection **gradientStops );
			IXpsOMGradientStopCollection GetGradientStops();

			/// <summary>Gets a pointer to the IXpsOMMatrixTransform interface that contains the resolved matrix transform for the brush.</summary>
			/// <returns>
			/// <para>A pointer to the IXpsOMMatrixTransform interface that contains the resolved matrix transform for the brush. If the transform has not been set, a <c>NULL</c> pointer is returned.</para>
			/// <para>The value that is returned in this parameter depends on which method has been most recently called to set the transform.</para>
			/// <list type="table">
			/// <listheader>
			/// <term>Most recent method called</term>
			/// <term>Object that is returned in transform</term>
			/// </listheader>
			/// <item>
			/// <term>SetTransformLocal</term>
			/// <term>The local transform that is set by SetTransformLocal.</term>
			/// </item>
			/// <item>
			/// <term>SetTransformLookup</term>
			/// <term>The shared transform that is retrieved, with a lookup key that matches the key set by SetTransformLookup, from the resource directory.</term>
			/// </item>
			/// <item>
			/// <term>Neither SetTransformLocal nor SetTransformLookup has been called yet.</term>
			/// <term>NULL pointer.</term>
			/// </item>
			/// </list>
			/// </returns>
			/// <remarks>The transform determines how the gradient is transformed. The visible part of the gradient that is ultimately rendered in the image is determined by the path, stroke, or glyph that is using the gradient brush.</remarks>
			// https://docs.microsoft.com/en-us/windows/win32/api/xpsobjectmodel/nf-xpsobjectmodel-ixpsomgradientbrush-gettransform
			// HRESULT GetTransform( IXpsOMMatrixTransform **transform );
			IXpsOMMatrixTransform GetTransform();

			/// <summary>Gets a pointer to the IXpsOMMatrixTransform interface that contains the local, unshared, resolved matrix transform for the brush.</summary>
			/// <returns>
			/// <para>A pointer to the IXpsOMMatrixTransform interface that contains the local, unshared, resolved matrix transform for the brush. If the transform has not been set or if a matrix transform lookup key has been set, a <c>NULL</c> pointer is returned.</para>
			/// <para>The value that is returned in this parameter depends on which method has been most recently called to set the transform.</para>
			/// <list type="table">
			/// <listheader>
			/// <term>Most recent method called</term>
			/// <term>Object that is returned in transform</term>
			/// </listheader>
			/// <item>
			/// <term>SetTransformLocal</term>
			/// <term>The local transform that is set by SetTransformLocal.</term>
			/// </item>
			/// <item>
			/// <term>SetTransformLookup</term>
			/// <term>NULL pointer.</term>
			/// </item>
			/// <item>
			/// <term>Neither SetTransformLocal nor SetTransformLookup has been called yet.</term>
			/// <term>NULL pointer.</term>
			/// </item>
			/// </list>
			/// </returns>
			/// <remarks>The transform determines how the gradient is transformed. The visible part of the gradient that is ultimately rendered in the image is determined by the path, stroke, or glyph that is using the gradient brush.</remarks>
			// https://docs.microsoft.com/en-us/windows/win32/api/xpsobjectmodel/nf-xpsobjectmodel-ixpsomgradientbrush-gettransformlocal
			// HRESULT GetTransformLocal( IXpsOMMatrixTransform **transform );
			IXpsOMMatrixTransform GetTransformLocal();

			/// <summary>
			/// Sets the IXpsOMMatrixTransform interface pointer to a local, unshared matrix transform that is to be used for the brush.
			/// </summary>
			/// <param name="transform">A pointer to the IXpsOMMatrixTransform interface of the local, unshared matrix transform that is to be used for the brush. A <c>NULL</c> pointer releases any previously set interface.</param>
			/// <remarks>
			/// <para>After you call <c>SetTransformLocal</c>, the transform lookup key is released and GetTransformLocal returns a <c>NULL</c> pointer in the transform parameter. The table that follows explains the relationship between the local and lookup values of this property.</para>
			/// <list type="table">
			///   <listheader>
			///     <term>Most recent method called</term>
			///     <term>Object that is returned in transform by GetTransform</term>
			///     <term>Object that is returned in transform by GetTransformLocal</term>
			///     <term>Object that is returned in key by GetTransformLookup</term>
			///   </listheader>
			///   <item>
			///     <term>SetTransformLocal (this method)</term>
			///     <term>The local transform that is set by SetTransformLocal.</term>
			///     <term>The local transform that is set by SetTransformLocal.</term>
			///     <term>NULL pointer.</term>
			///   </item>
			///   <item>
			///     <term>SetTransformLookup</term>
			///     <term>The shared transform retrieved, with a lookup key that matches the key that is set by SetTransformLookup, from the resource directory.</term>
			///     <term>NULL pointer.</term>
			///     <term>The lookup key that is set by SetTransformLookup.</term>
			///   </item>
			///   <item>
			///     <term>Neither SetTransformLocal nor SetTransformLookup has been called yet.</term>
			///     <term>NULL pointer.</term>
			///     <term>NULL pointer.</term>
			///     <term>NULL pointer.</term>
			///   </item>
			/// </list>
			/// <para>The transform passed in transform determines how the gradient is transformed. The visible part of the gradient that is ultimately rendered in the image is determined by the path, stroke, or glyph that is using the gradient brush.</para>
			/// </remarks>
			// https://docs.microsoft.com/en-us/windows/win32/api/xpsobjectmodel/nf-xpsobjectmodel-ixpsomgradientbrush-settransformlocal
			// HRESULT SetTransformLocal( IXpsOMMatrixTransform *transform );
			void SetTransformLocal([In] IXpsOMMatrixTransform transform);

			/// <summary>
			/// <para>Gets the name of the lookup key of the shared matrix transform interface that is to be used for the brush.</para>
			/// <para>The key name identifies a shared resource in a resource dictionary.</para>
			/// </summary>
			/// <returns>
			/// <para>The name of the lookup key of the shared matrix transform interface that is to be used for the brush. If the lookup key name has not been set or if the local matrix transform has been set, a <c>NULL</c> pointer is returned.</para>
			/// <para>The value that is returned in this parameter depends on which method has been most recently called to set the lookup key or the transform.</para>
			/// <list type="table">
			/// <listheader>
			/// <term>Most recent method called</term>
			/// <term>String that is returned in key</term>
			/// </listheader>
			/// <item>
			/// <term>SetTransformLocal</term>
			/// <term>NULL pointer.</term>
			/// </item>
			/// <item>
			/// <term>SetTransformLookup</term>
			/// <term>The key that is set by SetTransformLookup.</term>
			/// </item>
			/// <item>
			/// <term>Neither SetTransformLocal nor SetTransformLookup has been called yet.</term>
			/// <term>NULL pointer.</term>
			/// </item>
			/// </list>
			/// </returns>
			/// <remarks>
			/// <para>This method does not return an IXpsOMMatrixTransform interface pointer; to retrieve this pointer from the dictionary, call IXpsOMDictionary::GetByKey.</para>
			/// <para>The transform determines how the gradient is transformed. The visible part of the gradient that is ultimately rendered in the image is determined by the path, stroke, or glyph that is using the gradient brush.</para>
			/// </remarks>
			// https://docs.microsoft.com/en-us/windows/win32/api/xpsobjectmodel/nf-xpsobjectmodel-ixpsomgradientbrush-gettransformlookup
			// HRESULT GetTransformLookup( LPWSTR *key );
			SafeCoTaskMemString GetTransformLookup();

			/// <summary>
			/// <para>Sets the name of the lookup key of a shared matrix transform that is to be used for the brush.</para>
			/// <para>The key name identifies a shared resource in a resource dictionary.</para>
			/// </summary>
			/// <param name="key">The name of the lookup key of the matrix transform that is to be used for the brush.</param>
			/// <remarks>
			/// <para>After you call <c>SetTransformLookup</c>, the local transform is released and GetTransformLocal returns a <c>NULL</c> pointer in the transform parameter. The table that follows explains the relationship between the local and lookup values of this property.</para>
			/// <list type="table">
			///   <listheader>
			///     <term>Most recent method called</term>
			///     <term>Object that is returned in transform by GetTransform</term>
			///     <term>Object that is returned in transform by GetTransformLocal</term>
			///     <term>Object that is returned in key by GetTransformLookup</term>
			///   </listheader>
			///   <item>
			///     <term>SetTransformLocal</term>
			///     <term>The local transform that is set by SetTransformLocal.</term>
			///     <term>The local transform that is set by SetTransformLocal.</term>
			///     <term>NULL pointer.</term>
			///   </item>
			///   <item>
			///     <term>SetTransformLookup (this method)</term>
			///     <term>The shared transform retrieved, with a lookup key that matches the key that is set by SetTransformLookup, from the resource directory.</term>
			///     <term>NULL pointer.</term>
			///     <term>The lookup key that is set by SetTransformLookup.</term>
			///   </item>
			///   <item>
			///     <term>Neither SetTransformLocal nor SetTransformLookup has been called yet.</term>
			///     <term>NULL pointer.</term>
			///     <term>NULL pointer.</term>
			///     <term>NULL pointer.</term>
			///   </item>
			/// </list>
			/// <para>The transform referenced by key determines how the gradient is transformed. The visible part of the gradient that is ultimately rendered in the image is determined by the path, stroke, or glyph that is using the brush.</para>
			/// </remarks>
			// https://docs.microsoft.com/en-us/windows/win32/api/xpsobjectmodel/nf-xpsobjectmodel-ixpsomgradientbrush-settransformlookup
			// HRESULT SetTransformLookup( LPCWSTR key );
			void SetTransformLookup([In, MarshalAs(UnmanagedType.LPWStr)] string key);

			/// <summary>Gets the XPS_SPREAD_METHOD value, which describes how the area outside of the gradient region will be rendered.</summary>
			/// <returns>The XPS_SPREAD_METHOD value that describes how the area outside of the gradient region will be rendered. The gradient region is defined by the linear-gradient brush or radial-gradient brush that inherits this interface.</returns>
			/// <remarks>For more information about different types of spread methods, see XPS_SPREAD_METHOD.</remarks>
			// https://docs.microsoft.com/en-us/windows/win32/api/xpsobjectmodel/nf-xpsobjectmodel-ixpsomgradientbrush-getspreadmethod
			// HRESULT GetSpreadMethod( XPS_SPREAD_METHOD *spreadMethod );
			XPS_SPREAD_METHOD GetSpreadMethod();

			/// <summary>
			/// Sets the XPS_SPREAD_METHOD value, which describes how the area outside of the gradient region is to be rendered. The gradient region is defined by the start and end points of the gradient.
			/// </summary>
			/// <param name="spreadMethod">The XPS_SPREAD_METHOD value that describes how the area outside of the gradient region is to be rendered. The gradient region is defined by the linear-gradient brush or radial-gradient brush that inherits this interface.</param>
			/// <remarks>
			/// For more information about different types of spread methods, see XPS_SPREAD_METHOD.
			/// </remarks>
			// https://docs.microsoft.com/en-us/windows/win32/api/xpsobjectmodel/nf-xpsobjectmodel-ixpsomgradientbrush-setspreadmethod
			// HRESULT SetSpreadMethod( XPS_SPREAD_METHOD spreadMethod );
			void SetSpreadMethod([In] XPS_SPREAD_METHOD spreadMethod);

			/// <summary>Gets the gamma function to be used for color interpolation.</summary>
			/// <returns>The XPS_COLOR_INTERPOLATION value that describes the gamma function to be used for color interpolation.</returns>
			// https://docs.microsoft.com/en-us/windows/win32/api/xpsobjectmodel/nf-xpsobjectmodel-ixpsomgradientbrush-getcolorinterpolationmode
			// HRESULT GetColorInterpolationMode( XPS_COLOR_INTERPOLATION *colorInterpolationMode );
			XPS_COLOR_INTERPOLATION GetColorInterpolationMode();

			/// <summary>
			/// Sets the XPS_COLOR_INTERPOLATION value, which describes the gamma function to be used for color interpolation.
			/// </summary>
			/// <param name="colorInterpolationMode">The XPS_COLOR_INTERPOLATION value, which describes the gamma function to be used for color interpolation.</param>
			// https://docs.microsoft.com/en-us/windows/win32/api/xpsobjectmodel/nf-xpsobjectmodel-ixpsomgradientbrush-setcolorinterpolationmode
			// HRESULT SetColorInterpolationMode( XPS_COLOR_INTERPOLATION colorInterpolationMode );
			void SetColorInterpolationMode([In] XPS_COLOR_INTERPOLATION colorInterpolationMode);
		}

		/// <summary>Represents a single color and location within a gradient.</summary>
		/// <remarks>
		/// <para>A gradient stop is a specific color that is defined for a location within the gradient region. The color of the gradient changes between the gradient stops of the gradient. The area and absolute location of the gradient is defined by the gradient interface. The offset is a relative location within the gradient region and is measured between 0.0 and 1.0. An offset of 0.0 is the beginning of the gradient and 1.0 is the end. Gradient stops can be defined for any offset within the range, including the end points. This interface describes one and only one stop in a gradient.</para>
		/// <para>The gradient path is the straight line that connects the start point and the end point of a linear gradient. The gradient region of a linear gradient consists of the area between the start point and the end point, including those points, and extends in both directions at a right angle to the gradient path. The spread area is the area outside the gradient region.</para>
		/// <para>Gradient stops define the color at a specific location along the gradient path; the color is interpolated along the gradient path between the gradient stops. In the example that follows, the gradient region fills the image, so there is no spread area.</para>
		/// <para>For gradient stops used in linear-gradient brushes, the offset value of 0.0 corresponds to the start point of the gradient path, and the offset value of 1.0 corresponds to the end point. To determine the location of a gradient stop between these two points, intermediate offset values are interpolated between them. The following illustration shows two intermediate gradient stops, one at an offset of 0.25 and another at 0.75.</para>
		/// <para>For gradient stops used in radial-gradient brushes, the offset value of 0.0 corresponds to the gradient origin location, and the offset value of 1.0 corresponds to the circumference of the ellipse that bounds the gradient. Offsets between 0.0 and 1.0 define an ellipse that is interpolated between the gradient origin and the bounding ellipse. The illustration that follows has one intermediate gradient stop at an offset of 0.50 (Gradient stop 1). The gradient is using the <c>XPS_SPREAD_METHOD_REFLECT</c> spread method to fill the space outside of the gradient region.</para>
		/// <para>The calculations that are used to render a gradient are described in the XML Paper Specification.</para>
		/// <para>The code example that follows illustrates how to create an instance of this interface.</para>
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows/win32/api/xpsobjectmodel/nn-xpsobjectmodel-ixpsomgradientstop
		[PInvokeData("xpsobjectmodel.h", MSDNShortId = "e115d806-70c1-4c6a-810e-e6a058628b44")]
		[ComImport, Guid("5CF4F5CC-3969-49B5-A70A-5550B618FE49"), InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
		public interface IXpsOMGradientStop
		{
			/// <summary>Gets a pointer to the IXpsOMGradientBrush interface that contains the gradient stop.</summary>
			/// <returns>A pointer to the IXpsOMGradientBrush interface that contains the gradient stop. If the gradient stop is not assigned to a gradient brush, a <c>NULL</c> pointer is returned.</returns>
			// https://docs.microsoft.com/en-us/windows/win32/api/xpsobjectmodel/nf-xpsobjectmodel-ixpsomgradientstop-getowner
			// HRESULT GetOwner( IXpsOMGradientBrush **owner );
			IXpsOMGradientBrush GetOwner();

			/// <summary>Gets the offset value of the gradient stop.</summary>
			/// <returns>The offset value of the gradient stop, expressed as a fraction of the gradient path.</returns>
			/// <remarks>The valid range of values returned in offset is 0.0–1.0. 0.0 is the start point of the gradient, 1.0 is the end point, and a value between 0.0 and 1.0 is a location that is linearly interpolated between the start point and the end point.</remarks>
			// https://docs.microsoft.com/en-us/windows/win32/api/xpsobjectmodel/nf-xpsobjectmodel-ixpsomgradientstop-getoffset
			// HRESULT GetOffset( FLOAT *offset );
			float GetOffset();

			/// <summary>
			/// Sets the offset location of the gradient stop.
			/// </summary>
			/// <param name="offset"><para>The offset value that describes the location of the gradient stop as a fraction of the gradient path.</para>
			/// <para>The valid range of this parameter is 0.0 &lt;= offset &lt;= 1.0.</para></param>
			// https://docs.microsoft.com/en-us/windows/win32/api/xpsobjectmodel/nf-xpsobjectmodel-ixpsomgradientstop-setoffset
			// HRESULT SetOffset( FLOAT offset );
			void SetOffset([In] float offset);

			/// <summary>Gets the color value and color profile of the gradient stop.</summary>
			/// <param name="color">The color value of the gradient stop.</param>
			/// <returns>A pointer to the IXpsOMColorProfileResource interface that contains the color profile to be used. If no color profile resource has been set, a <c>NULL</c> pointer is returned. See remarks.</returns>
			/// <remarks>A color profile is only returned when the color type of color is XPS_COLOR_TYPE_CONTEXT.</remarks>
			// https://docs.microsoft.com/en-us/windows/win32/api/xpsobjectmodel/nf-xpsobjectmodel-ixpsomgradientstop-getcolor
			// HRESULT GetColor( XPS_COLOR *color, IXpsOMColorProfileResource **colorProfile );
			IXpsOMColorProfileResource GetColor( out XPS_COLOR color);

			/// <summary>
			/// Sets the color value and color profile of the gradient stop.
			/// </summary>
			/// <param name="color"><para>The color value to be set at the gradient stop.</para>
			/// <para>If the value of the <c>colorType</c> field in the XPS_COLOR structure that is passed in this parameter is XPS_COLOR_TYPE_CONTEXT, a valid color profile must be provided in the colorProfile parameter.</para></param>
			/// <param name="colorProfile"><para>The color profile to be used with color.</para>
			/// <para>A color profile is required when the value of the <c>colorType</c> field in the XPS_COLOR structure that is passed in the color parameter is XPS_COLOR_TYPE_CONTEXT. If the value of the <c>colorType</c> field is not <c>XPS_COLOR_TYPE_CONTEXT</c>, this parameter must be set to <c>NULL</c>.</para></param>
			/// <remarks>
			/// A color profile is only required when the color type of color is XPS_COLOR_TYPE_CONTEXT.
			/// </remarks>
			// https://docs.microsoft.com/en-us/windows/win32/api/xpsobjectmodel/nf-xpsobjectmodel-ixpsomgradientstop-setcolor
			// HRESULT SetColor( const XPS_COLOR *color, IXpsOMColorProfileResource *colorProfile );
			void SetColor(in XPS_COLOR color, [In] IXpsOMColorProfileResource colorProfile);

			/// <summary>Makes a deep copy of the IXpsOMGradientStop interface.</summary>
			/// <returns>A pointer to the copy of the interface.</returns>
			/// <remarks>
			/// <para>The owner of the new interface is <c>NULL</c>.</para>
			/// <para>This method does not update any of the resource pointers in the IXpsOMGradientStop interface returned in gradientStop.</para>
			/// </remarks>
			// https://docs.microsoft.com/en-us/windows/win32/api/xpsobjectmodel/nf-xpsobjectmodel-ixpsomgradientstop-clone
			// HRESULT Clone( IXpsOMGradientStop **gradientStop );
			IXpsOMGradientStop Clone();
		}

		/// <summary>A collection of IXpsOMGradientStop interface pointers.</summary>
		/// <remarks>For more information about the collection methods, see Working with XPS OM Collection Interfaces.</remarks>
		// https://docs.microsoft.com/en-us/windows/win32/api/xpsobjectmodel/nn-xpsobjectmodel-ixpsomgradientstopcollection
		[PInvokeData("xpsobjectmodel.h", MSDNShortId = "1f51f818-e9bb-4d88-9795-4e6890d24b8c")]
		[ComImport, Guid("C9174C3A-3CD3-4319-BDA4-11A39392CEEF"), InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
		public interface IXpsOMGradientStopCollection
		{
			/// <summary>Gets the number of IXpsOMGradientStop interface pointers in the collection.</summary>
			/// <returns>The number of IXpsOMGradientStop interface pointers in the collection.</returns>
			/// <remarks>For more information about the collection methods, see Working with XPS OM Collection Interfaces.</remarks>
			// https://docs.microsoft.com/en-us/windows/win32/api/xpsobjectmodel/nf-xpsobjectmodel-ixpsomgradientstopcollection-getcount
			// HRESULT GetCount( UINT32 *count );
			uint GetCount();

			/// <summary>Gets an IXpsOMGradientStop interface pointer from a specified location in the collection.</summary>
			/// <param name="index">The zero-based index of the IXpsOMGradientStop interface pointer to be obtained.</param>
			/// <returns>The IXpsOMGradientStop interface pointer at the location specified by index.</returns>
			/// <remarks>For more information about the collection methods, see Working with XPS OM Collection Interfaces.</remarks>
			// https://docs.microsoft.com/en-us/windows/win32/api/xpsobjectmodel/nf-xpsobjectmodel-ixpsomgradientstopcollection-getat
			// HRESULT GetAt( UINT32 index, IXpsOMGradientStop **stop );
			IXpsOMGradientStop GetAt([In] uint index);

			/// <summary>
			/// Inserts an IXpsOMGradientStop interface pointer at a specified location in the collection.
			/// </summary>
			/// <param name="index">The zero-based index in the collection where the interface pointer that is passed in stop is to be inserted.</param>
			/// <param name="stop">The IXpsOMGradientStop interface pointer to be inserted at the location specified by index.</param>
			/// <remarks>
			/// <para>At the location specified by index, this method inserts the IXpsOMGradientStop interface pointer that is passed in stop. Prior to the insertion, the pointer in this and all subsequent locations is moved up by one index.</para>
			/// <para>For more information about the collection methods, see Working with XPS OM Collection Interfaces.</para>
			/// </remarks>
			// https://docs.microsoft.com/en-us/windows/win32/api/xpsobjectmodel/nf-xpsobjectmodel-ixpsomgradientstopcollection-insertat
			// HRESULT InsertAt( UINT32 index, IXpsOMGradientStop *stop );
			void InsertAt([In] uint index, [In] IXpsOMGradientStop stop);

			/// <summary>
			/// Removes and releases an IXpsOMGradientStop interface pointer from a specified location in the collection.
			/// </summary>
			/// <param name="index">The zero-based index in the collection from which an IXpsOMGradientStop interface pointer is to be removed and released.</param>
			/// <remarks>
			/// <para>This method releases the IXpsOMGradientStop interface referenced by the pointer at the location specified by index. After releasing the interface, this method compacts the collection by reducing by 1 the index of each pointer subsequent to index.</para>
			/// <para>For more information about the collection methods, see Working with XPS OM Collection Interfaces.</para>
			/// </remarks>
			// https://docs.microsoft.com/en-us/windows/win32/api/xpsobjectmodel/nf-xpsobjectmodel-ixpsomgradientstopcollection-removeat
			// HRESULT RemoveAt( UINT32 index );
			void RemoveAt([In] uint index);

			/// <summary>Replaces an IXpsOMGradientStop interface pointer at a specified location in the collection.</summary>
			/// <param name="index">The zero-based index in the collection where an IXpsOMGradientStop interface pointer is to be replaced.</param>
			/// <param name="stop">The IXpsOMGradientStop interface pointer that will replace current contents at the location specified by index.</param>
			/// <remarks>
			/// <para>At the location specified by index, this method releases the IXpsOMGradientStop interface referenced by the existing pointer, then writes the pointer that is passed in stop.</para>
			/// <para>For more information about the collection methods, see Working with XPS OM Collection Interfaces.</para>
			/// </remarks>
			// https://docs.microsoft.com/en-us/windows/win32/api/xpsobjectmodel/nf-xpsobjectmodel-ixpsomgradientstopcollection-setat
			// HRESULT SetAt( UINT32 index, IXpsOMGradientStop *stop );
			void SetAt([In] uint index, [In] IXpsOMGradientStop stop);

			/// <summary>Appends an IXpsOMGradientStop interface to the end of the collection.</summary>
			/// <param name="stop">A pointer to the IXpsOMGradientStop interface that is to be appended to the collection.</param>
			/// <remarks>For more information about the collection methods, see Working with XPS OM Collection Interfaces.</remarks>
			// https://docs.microsoft.com/en-us/windows/win32/api/xpsobjectmodel/nf-xpsobjectmodel-ixpsomgradientstopcollection-append
			// HRESULT Append( IXpsOMGradientStop *stop );
			void Append([In] IXpsOMGradientStop stop);
		}

		/// <summary>A brush that uses a raster image as a source.</summary>
		/// <remarks>
		/// <para>The image used by this brush is defined in a coordinate space that is specified by the image's resolution. The image type must be JPEG, PNG, TIFF 6.0, or HD Photo.</para>
		/// <para>The code example that follows illustrates how to create an instance of this interface.</para>
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows/win32/api/xpsobjectmodel/nn-xpsobjectmodel-ixpsomimagebrush
		[PInvokeData("xpsobjectmodel.h", MSDNShortId = "f5478582-466b-496e-b7f3-42fb8caa6814")]
		[ComImport, Guid("3DF0B466-D382-49EF-8550-DD94C80242E4"), InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
		public interface IXpsOMImageBrush : IXpsOMTileBrush
		{
			/// <summary>Gets the <c>IUnknown</c> interface of the parent.</summary>
			/// <returns>A pointer to the <c>IUnknown</c> interface of the parent.</returns>
			// https://docs.microsoft.com/en-us/windows/win32/api/xpsobjectmodel/nf-xpsobjectmodel-ixpsomshareable-getowner
			// HRESULT GetOwner( IUnknown **owner );
			[return: MarshalAs(UnmanagedType.IUnknown)]
			new object GetOwner();

			/// <summary>Gets the object type of the interface.</summary>
			/// <returns>The XPS_OBJECT_TYPE value that describes the interface that is derived from IXpsOMShareable.</returns>
			// https://docs.microsoft.com/en-us/windows/win32/api/xpsobjectmodel/nf-xpsobjectmodel-ixpsomshareable-gettype
			// HRESULT GetType( XPS_OBJECT_TYPE *type );
			new XPS_OBJECT_TYPE GetType();

			/// <summary>Gets the opacity of the brush.</summary>
			/// <returns>
			/// The opacity value of the brush.
			/// </returns>
			/// <remarks>opacity is expressed as a value between 0.0 and 1.0; 0.0 indicates that the brush is completely transparent, 0.5 that it is 50 percent opaque, and 1.0 that it is completely opaque.</remarks>
			// https://docs.microsoft.com/en-us/windows/win32/api/xpsobjectmodel/nf-xpsobjectmodel-ixpsombrush-getopacity
			// HRESULT GetOpacity( FLOAT *opacity );
			new float GetOpacity();

			/// <summary>Sets the opacity of the brush.</summary>
			/// <param name="opacity">The opacity value of the brush.</param>
			/// <remarks>
			/// <para>opacity is expressed as a value between 0.0 and 1.0; 0.0 indicates that the brush is completely transparent, 0.5 that it is 50 percent opaque, and 1.0 that it is completely opaque.</para>
			/// <para>If opacity is less than 0.0 or greater than 1.0, the method returns an error.</para>
			/// </remarks>
			// https://docs.microsoft.com/en-us/windows/win32/api/xpsobjectmodel/nf-xpsobjectmodel-ixpsombrush-setopacity
			// HRESULT SetOpacity( FLOAT opacity );
			new void SetOpacity([In] float opacity);

			/// <summary>Gets a pointer to the IXpsOMMatrixTransform interface that contains the resolved matrix transform for the brush.</summary>
			/// <returns>
			/// <para>A pointer to the IXpsOMMatrixTransform interface that contains the resolved matrix transform for the brush. If a matrix transform has not been set, a <c>NULL</c> pointer is returned.</para>
			/// <para>The value that is returned in this parameter depends on which method has most recently been called to set the transform.</para>
			/// <list type="table">
			/// <listheader>
			/// <term>Most recent method called</term>
			/// <term>Object that is returned in transform</term>
			/// </listheader>
			/// <item>
			/// <term>SetTransformLocal</term>
			/// <term>The transform that is set by SetTransformLocal.</term>
			/// </item>
			/// <item>
			/// <term>SetTransformLookup</term>
			/// <term>The transform which is retrieved, using a lookup key that matches the key that is set by SetTransformLookup, from the resource directory.</term>
			/// </item>
			/// <item>
			/// <term>Neither SetTransformLocal nor SetTransformLookup has been called yet.</term>
			/// <term>NULL pointer.</term>
			/// </item>
			/// </list>
			/// </returns>
			/// <remarks>The transform determines how the output area is transformed before the brush image is rendered in the path, stroke, or glyph that is using the tile brush.</remarks>
			// https://docs.microsoft.com/en-us/windows/win32/api/xpsobjectmodel/nf-xpsobjectmodel-ixpsomtilebrush-gettransform
			// HRESULT GetTransform( IXpsOMMatrixTransform **transform );
			new IXpsOMMatrixTransform GetTransform();

			/// <summary>Gets a pointer to the IXpsOMMatrixTransform interface that contains the local, unshared resolved matrix transform for the brush.</summary>
			/// <returns>
			/// <para>A pointer to the IXpsOMMatrixTransform interface that contains the local, unshared resolved matrix transform for the brush. If a local matrix transform has not been set or if a matrix transform lookup key has been set, a <c>NULL</c> pointer is returned.</para>
			/// <list type="table">
			/// <listheader>
			/// <term>Most recent method called</term>
			/// <term>Object that is returned in transform</term>
			/// </listheader>
			/// <item>
			/// <term>SetTransformLocal</term>
			/// <term>The transform that is set by SetTransformLocal.</term>
			/// </item>
			/// <item>
			/// <term>SetTransformLookup</term>
			/// <term>NULL pointer.</term>
			/// </item>
			/// <item>
			/// <term>Neither SetTransformLocal nor SetTransformLookup has been called yet.</term>
			/// <term>NULL pointer.</term>
			/// </item>
			/// </list>
			/// </returns>
			/// <remarks>The transform determines how the output area is transformed before the brush image is rendered in the path, stroke, or glyph that is using the tile brush.</remarks>
			// https://docs.microsoft.com/en-us/windows/win32/api/xpsobjectmodel/nf-xpsobjectmodel-ixpsomtilebrush-gettransformlocal
			// HRESULT GetTransformLocal( IXpsOMMatrixTransform **transform );
			new IXpsOMMatrixTransform GetTransformLocal();

			/// <summary>
			/// Sets the IXpsOMMatrixTransform interface pointer to a local, unshared matrix transform.
			/// </summary>
			/// <param name="transform">A pointer to the IXpsOMMatrixTransform interface to be set as the local, unshared matrix transform. If a local transform has been set, a <c>NULL</c> pointer will release it.</param>
			/// <remarks>
			/// <para>The transform determines how the output area is transformed before the brush image is rendered in the path, stroke, or glyph that is using the tile brush.</para>
			/// <para>After you call <c>SetTransformLocal</c>, the transform lookup key is released and GetTransformLookup returns a <c>NULL</c> pointer in the key parameter. The table that follows explains the relationship between the local and lookup values of this property.</para>
			/// <list type="table">
			///   <listheader>
			///     <term>Most recent method called</term>
			///     <term>Object that is returned in transform by GetTransform</term>
			///     <term>Object that is returned in transform by GetTransformLocal</term>
			///     <term>String that is returned in key by GetTransformLookup</term>
			///   </listheader>
			///   <item>
			///     <term>SetTransformLocal (this method)</term>
			///     <term>The transform that is set by SetTransformLocal.</term>
			///     <term>The transform that is set by SetTransformLocal.</term>
			///     <term>NULL pointer.</term>
			///   </item>
			///   <item>
			///     <term>SetTransformLookup</term>
			///     <term>The transform which is retrieved, using a lookup key that matches the key that is set by SetTransformLookup, from the resource directory.</term>
			///     <term>NULL pointer.</term>
			///     <term>The lookup key that is set by SetTransformLookup.</term>
			///   </item>
			///   <item>
			///     <term>Neither SetTransformLocal nor SetTransformLookup has been called yet.</term>
			///     <term>NULL pointer.</term>
			///     <term>NULL pointer.</term>
			///     <term>NULL pointer.</term>
			///   </item>
			/// </list>
			/// </remarks>
			// https://docs.microsoft.com/en-us/windows/win32/api/xpsobjectmodel/nf-xpsobjectmodel-ixpsomtilebrush-settransformlocal
			// HRESULT SetTransformLocal( IXpsOMMatrixTransform *transform );
			new void SetTransformLocal([In] IXpsOMMatrixTransform transform);

			/// <summary>Gets the lookup key that identifies the IXpsOMMatrixTransform interface in a resource dictionary that contains the resolved matrix transform for the brush.</summary>
			/// <returns>
			/// <para>The lookup key that identifies the IXpsOMMatrixTransform interface in a resource dictionary that contains the resolved matrix transform for the brush. If a matrix transform lookup key has not been set or if a local matrix transform has been set, a <c>NULL</c> pointer is returned.</para>
			/// <list type="table">
			/// <listheader>
			/// <term>Most recent method called</term>
			/// <term>Object that is returned in key</term>
			/// </listheader>
			/// <item>
			/// <term>SetTransformLocal</term>
			/// <term>NULL pointer.</term>
			/// </item>
			/// <item>
			/// <term>SetTransformLookup</term>
			/// <term>The lookup key set by SetTransformLookup.</term>
			/// </item>
			/// <item>
			/// <term>Neither SetTransformLocal nor SetTransformLookup has been called yet.</term>
			/// <term>NULL pointer.</term>
			/// </item>
			/// </list>
			/// </returns>
			/// <remarks>
			/// <para>The transform determines how the output area is transformed before the brush image is rendered in the path, stroke, or glyph that is using the tile brush.</para>
			/// </remarks>
			// https://docs.microsoft.com/en-us/windows/win32/api/xpsobjectmodel/nf-xpsobjectmodel-ixpsomtilebrush-gettransformlookup
			// HRESULT GetTransformLookup( LPWSTR *key );
			new SafeCoTaskMemString GetTransformLookup();

			/// <summary>
			/// Sets the lookup key name of a shared matrix transform that will be used as the transform for this brush.The shared matrix transform that is referenced by the lookup key is stored in the resource dictionary.
			/// </summary>
			/// <param name="key">A string variable that contains the lookup key name of a shared matrix transform in the resource dictionary. If a lookup key has already been set, a <c>NULL</c> pointer will clear it.</param>
			/// <remarks>
			/// <para>The transform is applied before the brush image is rendered in the path, stroke, or glyph that is using the tile brush. The tile brush has only one transform, which can be local or remote.</para>
			/// <para>After you call <c>SetTransformLookup</c>, the local transform is released and GetTransformLocal returns a <c>NULL</c> pointer in the transform parameter. The table that follows explains the relationship between the local and lookup values of this property.</para>
			/// <list type="table">
			///   <listheader>
			///     <term>Most recent method called</term>
			///     <term>Object that is returned in transform by GetTransform</term>
			///     <term>Object that is returned in transform by GetTransformLocal</term>
			///     <term>String that is returned in key by GetTransformLookup</term>
			///   </listheader>
			///   <item>
			///     <term>SetTransformLocal</term>
			///     <term>The transform that is set by SetTransformLocal.</term>
			///     <term>The transform that is set by SetTransformLocal.</term>
			///     <term>NULL pointer.</term>
			///   </item>
			///   <item>
			///     <term>SetTransformLookup (this method)</term>
			///     <term>The transform which is retrieved—using a lookup key that matches the key that is set by SetTransformLookup— from the resource directory.</term>
			///     <term>NULL pointer.</term>
			///     <term>The lookup key that is set by SetTransformLookup.</term>
			///   </item>
			///   <item>
			///     <term>Neither SetTransformLocal nor SetTransformLookup has been called yet.</term>
			///     <term>NULL pointer.</term>
			///     <term>NULL pointer.</term>
			///     <term>NULL pointer.</term>
			///   </item>
			/// </list>
			/// </remarks>
			// https://docs.microsoft.com/en-us/windows/win32/api/xpsobjectmodel/nf-xpsobjectmodel-ixpsomtilebrush-settransformlookup
			// HRESULT SetTransformLookup( LPCWSTR key );
			new void SetTransformLookup([In, MarshalAs(UnmanagedType.LPWStr)] string key);

			/// <summary>Gets the portion of the source image to be used by the tile.</summary>
			/// <returns>The XPS_RECT structure that describes the area of the source content to be used by the tile.</returns>
			/// <remarks>
			/// <para>The brush's viewbox specifies the portion of a source image or visual to be used as the tile image.</para>
			/// <para>The coordinates of the brush's viewbox are relative to the source content, such that (0,0) specifies the upper-left corner of the source content. For images, dimensions specified by the brush's viewbox are expressed in the units of 1/96". The corresponding pixel coordinates in the source image are calculated as follows:</para>
			/// <para>In the illustration that follows, the image on the left is an example of a source image, the image in the center shows the selected viewbox, and the image on the right shows the resulting brush.</para>
			/// <para>If the source image resolution is 96 by 96 dots per inch and image dimensions are 96 by 96 pixels, the values of fields in the viewbox parameter would be:</para>
			/// <para>The preceding parameter values correspond to the source image as:</para>
			/// </remarks>
			// https://docs.microsoft.com/en-us/windows/win32/api/xpsobjectmodel/nf-xpsobjectmodel-ixpsomtilebrush-getviewbox
			// HRESULT GetViewbox( XPS_RECT *viewbox );
			new XPS_RECT GetViewbox();

			/// <summary>
			/// Sets the portion of the source content to be used as the tile image.
			/// </summary>
			/// <param name="viewbox">An XPS_RECT structure that describes the portion of the source content to be used as the tile image.</param>
			/// <remarks>
			/// <para>The brush's viewbox specifies the portion of a source image or visual to be used as the tile image.</para>
			/// <para>The coordinates of the brush's viewbox are relative to the source content, such that (0,0) specifies the upper-left corner of the source content. For images, dimensions specified by the brush's viewbox are expressed in the units of 1/96". The corresponding pixel coordinates in the source image are calculated as follows:</para>
			/// <para>In the illustration that follows, the image on the left is an example of a source image, while that on the right is the source image with the selected viewbox for the brush shown as a red rectangle. In this example, the part of the source image that is used as the content for the tile brush is the area within the red rectangle. The shaded area of the image is not used by the brush.</para>
			/// <para>If the source image resolution is 96 by 96 dots per inch and image dimensions are 96 by 96 pixels, the values of fields in the viewbox parameter would be:</para>
			/// <para>The preceding parameter values correspond to the source image as:</para>
			/// </remarks>
			// https://docs.microsoft.com/en-us/windows/win32/api/xpsobjectmodel/nf-xpsobjectmodel-ixpsomtilebrush-setviewbox
			// HRESULT SetViewbox( const XPS_RECT *viewbox );
			new void SetViewbox(in XPS_RECT viewbox);

			/// <summary>Gets the portion of the destination geometry that is covered by a single tile.</summary>
			/// <returns>The XPS_RECT structure that describes the portion of the destination geometry that is covered by a single tile.</returns>
			/// <remarks>The viewport is the portion of the output area where the first tile is drawn. In the illustration, the viewport is outlined by the purple rectangle inside the red, dotted rectangle. The tile mode of the brush determines how the rest of the tiles are drawn in the output area.</remarks>
			// https://docs.microsoft.com/en-us/windows/win32/api/xpsobjectmodel/nf-xpsobjectmodel-ixpsomtilebrush-getviewport
			// HRESULT GetViewport( XPS_RECT *viewport );
			new XPS_RECT GetViewport();

			/// <summary>
			/// Sets the portion of the destination geometry that is covered by a single tile.
			/// </summary>
			/// <param name="viewport">An XPS_RECT structure that describes the portion of the destination geometry that is covered by a single tile.</param>
			/// <remarks>
			/// The viewport is the portion of the output area where the tile is drawn. In the following illustration, the viewport is outlined by the blue rectangle inside the red, dotted rectangle. The tile mode of the brush determines how other tiles are drawn in the output area.
			/// </remarks>
			// https://docs.microsoft.com/en-us/windows/win32/api/xpsobjectmodel/nf-xpsobjectmodel-ixpsomtilebrush-setviewport
			// HRESULT SetViewport( const XPS_RECT *viewport );
			new void SetViewport(in XPS_RECT viewport);

			/// <summary>Gets the XPS_TILE_MODE value that describes the tile mode of the brush.</summary>
			/// <returns>The XPS_TILE_MODE value that describes the tile mode of the brush.</returns>
			/// <remarks>The tile mode determines how the tile image is repeated to fill the output area. If the tile mode value is XPS_TILE_MODE_NONE, the tile image is drawn only once. The following illustration shows examples of how the tile image appears in several tile modes.</remarks>
			// https://docs.microsoft.com/en-us/windows/win32/api/xpsobjectmodel/nf-xpsobjectmodel-ixpsomtilebrush-gettilemode
			// HRESULT GetTileMode( XPS_TILE_MODE *tileMode );
			new XPS_TILE_MODE GetTileMode();

			/// <summary>
			/// Sets the XPS_TILE_MODE value that describes the tiling mode of the brush.
			/// </summary>
			/// <param name="tileMode">The XPS_TILE_MODE value to be set.</param>
			/// <remarks>
			/// The tile mode determines how the tile image is repeated to fill the output area. If the tile mode value is XPS_TILE_MODE_NONE, the tile image is drawn only once.
			/// </remarks>
			// https://docs.microsoft.com/en-us/windows/win32/api/xpsobjectmodel/nf-xpsobjectmodel-ixpsomtilebrush-settilemode
			// HRESULT SetTileMode( XPS_TILE_MODE tileMode );
			new void SetTileMode([In] XPS_TILE_MODE tileMode);

			/// <summary>Gets a pointer to the IXpsOMImageResource interface, which contains the image resource to be used as the source for the brush.</summary>
			/// <returns>A pointer to the IXpsOMImageResource interface that contains the image resource to be used as the source for the brush.</returns>
			/// <remarks>After loading and parsing the resource into the XPS OM, this method might return an error that applies to another resource. This occurs because all of the relationships are parsed when a resource is loaded.</remarks>
			// https://docs.microsoft.com/en-us/windows/win32/api/xpsobjectmodel/nf-xpsobjectmodel-ixpsomimagebrush-getimageresource
			// HRESULT GetImageResource( IXpsOMImageResource **imageResource );
			IXpsOMImageResource GetImageResource();

			/// <summary>
			/// Sets a pointer to the IXpsOMImageResource interface that contains the image resource to be used as the source for the brush.
			/// </summary>
			/// <param name="imageResource">The image resource to be used as the source for the brush. This parameter must not be a <c>NULL</c> pointer.</param>
			/// <remarks>
			/// The image resource must be of type JPEG, PNG, TIFF 6.0, or HD Photo.
			/// </remarks>
			// https://docs.microsoft.com/en-us/windows/win32/api/xpsobjectmodel/nf-xpsobjectmodel-ixpsomimagebrush-setimageresource
			// HRESULT SetImageResource( IXpsOMImageResource *imageResource );
			void SetImageResource([In] IXpsOMImageResource imageResource);

			/// <summary>Gets a pointer to the IXpsOMColorProfileResource interface, which contains the color profile resource that is associated with the image.</summary>
			/// <returns>A pointer to the IXpsOMColorProfileResource interface that contains the color profile resource that is associated with the image. If no color profile resource has been set, a <c>NULL</c> pointer is returned.</returns>
			/// <remarks>After loading and parsing the resource into the XPS OM, this method might return an error that applies to another resource. This occurs because all of the relationships are parsed when a resource is loaded.</remarks>
			// https://docs.microsoft.com/en-us/windows/win32/api/xpsobjectmodel/nf-xpsobjectmodel-ixpsomimagebrush-getcolorprofileresource
			// HRESULT GetColorProfileResource( IXpsOMColorProfileResource **colorProfileResource );
			IXpsOMColorProfileResource GetColorProfileResource();

			/// <summary>
			/// Sets a pointer to the IXpsOMColorProfileResource interface, which contains the color profile resource that is associated with the image.
			/// </summary>
			/// <param name="colorProfileResource">The color profile resource that is associated with the image. A <c>NULL</c> pointer will release any previously set color profile resources.</param>
			// https://docs.microsoft.com/en-us/windows/win32/api/xpsobjectmodel/nf-xpsobjectmodel-ixpsomimagebrush-setcolorprofileresource
			// HRESULT SetColorProfileResource( IXpsOMColorProfileResource *colorProfileResource );
			void SetColorProfileResource([In] IXpsOMColorProfileResource colorProfileResource);

			/// <summary>Makes a deep copy of the interface.</summary>
			/// <returns>A pointer to the copy of the interface.</returns>
			/// <remarks>This method does not update any of the resource pointers in the copy.</remarks>
			// https://docs.microsoft.com/en-us/windows/win32/api/xpsobjectmodel/nf-xpsobjectmodel-ixpsomimagebrush-clone
			// HRESULT Clone( IXpsOMImageBrush **imageBrush );
			IXpsOMImageBrush Clone();
		}

		/// <summary>Provides an IStream interface to an image resource.</summary>
		/// <remarks>The code example that follows illustrates how to create an instance of this interface.</remarks>
		// https://docs.microsoft.com/en-us/windows/win32/api/xpsobjectmodel/nn-xpsobjectmodel-ixpsomimageresource
		[PInvokeData("xpsobjectmodel.h", MSDNShortId = "89a1530e-fa87-45bf-a1da-c8656ec09ba3")]
		[ComImport, Guid("3DB8417D-AE50-485E-9A44-D7758F78A23F"), InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
		public interface IXpsOMImageResource : IXpsOMResource
		{
			/// <summary>Gets the name that will be used when the part is serialized.</summary>
			/// <returns>
			/// A pointer to the IOpcPartUri interface that contains the part name. If the part name has not been set (by the SetPartName
			/// method), a <c>NULL</c> pointer is returned.
			/// </returns>
			// https://docs.microsoft.com/en-us/windows/win32/api/xpsobjectmodel/nf-xpsobjectmodel-ixpsompart-getpartname HRESULT
			// GetPartName( IOpcPartUri **partUri );
			[MethodImpl(MethodImplOptions.InternalCall)]
			new IOpcPartUri GetPartName();

			/// <summary>Sets the name that will be used when the part is serialized.</summary>
			/// <param name="partUri">
			/// A pointer to the IOpcPartUri interface that contains the name of this part. This parameter cannot be <c>NULL</c>.
			/// </param>
			/// <remarks>
			/// IXpsOMPackageWriter will generate an error if it encounters an XPS document part whose name is the same as that of a part it
			/// has previously serialized.
			/// </remarks>
			// https://docs.microsoft.com/en-us/windows/win32/api/xpsobjectmodel/nf-xpsobjectmodel-ixpsompart-setpartname HRESULT
			// SetPartName( IOpcPartUri *partUri );
			[MethodImpl(MethodImplOptions.InternalCall)]
			new void SetPartName([In] IOpcPartUri partUri);

			/// <summary>Gets a new, read-only copy of the stream that is associated with this resource.</summary>
			/// <returns>A new, read-only copy of the stream that is associated with this resource.</returns>
			/// <remarks>
			/// <para>The IStream object returned by this method might return an error of E_PENDING, which indicates that the stream length has not been determined yet. This behavior is different from that of a standard <c>IStream</c> object.</para>
			/// <para>This method calls the stream's <c>Clone</c> method to create the stream returned in stream. As a result, the performance of this method will depend on that of the stream's <c>Clone</c> method.</para>
			/// </remarks>
			// https://docs.microsoft.com/en-us/windows/win32/api/xpsobjectmodel/nf-xpsobjectmodel-ixpsomimageresource-getstream
			// HRESULT GetStream( IStream **readerStream );
			[MethodImpl(MethodImplOptions.InternalCall)]
			IStream GetStream();

			/// <summary>
			/// Sets the read-only stream to be associated with this resource.
			/// </summary>
			/// <param name="sourceStream">The read-only stream to be associated with this resource.</param>
			/// <param name="imageType">The XPS_IMAGE_TYPE value that describes the type of image in the stream.</param>
			/// <param name="partName">The part name to be assigned to this resource.</param>
			/// <remarks>
			/// <para>The calling method should treat this stream as a single-threaded apartment (STA) model object and not re-enter any of the stream interface's methods.</para>
			/// <para>Because GetStream gets a clone of the stream that is set by this method, the provided stream should have an efficient cloning method. A stream with an inefficient cloning method will reduce the performance of <c>GetStream</c>.</para>
			/// </remarks>
			// https://docs.microsoft.com/en-us/windows/win32/api/xpsobjectmodel/nf-xpsobjectmodel-ixpsomimageresource-setcontent
			// HRESULT SetContent( IStream *sourceStream, XPS_IMAGE_TYPE imageType, IOpcPartUri *partName );
			[MethodImpl(MethodImplOptions.InternalCall)]
			void SetContent([In] IStream sourceStream, [In] XPS_IMAGE_TYPE imageType, [In] IOpcPartUri partName);

			/// <summary>Gets the type of image resource.</summary>
			/// <returns>The XPS_IMAGE_TYPE value that describes the image type in the stream.</returns>
			// https://docs.microsoft.com/en-us/windows/win32/api/xpsobjectmodel/nf-xpsobjectmodel-ixpsomimageresource-getimagetype
			// HRESULT GetImageType( XPS_IMAGE_TYPE *imageType );
			[MethodImpl(MethodImplOptions.InternalCall)]
			XPS_IMAGE_TYPE GetImageType();
		}

		/// <summary>A collection of IXpsOMImageResource interface pointers.</summary>
		/// <remarks>For more information about the collection methods, see Working with XPS OM Collection Interfaces.</remarks>
		// https://docs.microsoft.com/en-us/windows/win32/api/xpsobjectmodel/nn-xpsobjectmodel-ixpsomimageresourcecollection
		[PInvokeData("xpsobjectmodel.h", MSDNShortId = "aed8b23e-71fd-49e6-aae9-006a59e0111b")]
		[ComImport, Guid("7A4A1A71-9CDE-4B71-B33F-62DE843EABFE"), InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
		public interface IXpsOMImageResourceCollection
		{
			/// <summary>Gets the number of IXpsOMImageResource interface pointers in the collection.</summary>
			/// <returns>The number of IXpsOMImageResource interface pointers in the collection.</returns>
			/// <remarks>For more information about the collection methods, see Working with XPS OM Collection Interfaces.</remarks>
			// https://docs.microsoft.com/en-us/windows/win32/api/xpsobjectmodel/nf-xpsobjectmodel-ixpsomimageresourcecollection-getcount
			// HRESULT GetCount( UINT32 *count );
			[MethodImpl(MethodImplOptions.InternalCall)]
			uint GetCount();

			/// <summary>Gets an IXpsOMImageResource interface pointer from a specified location in the collection.</summary>
			/// <param name="index">The zero-based index of the IXpsOMImageResource interface pointer to be obtained.</param>
			/// <returns>The IXpsOMImageResource interface pointer at the location specified by index.</returns>
			/// <remarks>For more information about the collection methods, see Working with XPS OM Collection Interfaces.</remarks>
			// https://docs.microsoft.com/en-us/windows/win32/api/xpsobjectmodel/nf-xpsobjectmodel-ixpsomimageresourcecollection-getat
			// HRESULT GetAt( UINT32 index, IXpsOMImageResource **object );
			[MethodImpl(MethodImplOptions.InternalCall)]
			IXpsOMImageResource GetAt([In] uint index);

			/// <summary>
			/// Inserts an IXpsOMImageResource interface pointer at a specified location in the collection.
			/// </summary>
			/// <param name="index">The zero-based index in the collection where the interface pointer that is passed in object is to be inserted.</param>
			/// <param name="object">The IXpsOMImageResource interface pointer that will be inserted at the location specified by index.</param>
			/// <remarks>
			/// <para>At the location specified by index, this method inserts the IXpsOMImageResource interface pointer that is passed in object. Prior to the insertion, the pointer in this and all subsequent locations is moved up by one index.</para>
			/// <para>For more information about the collection methods, see Working with XPS OM Collection Interfaces.</para>
			/// </remarks>
			// https://docs.microsoft.com/en-us/windows/win32/api/xpsobjectmodel/nf-xpsobjectmodel-ixpsomimageresourcecollection-insertat
			// HRESULT InsertAt( UINT32 index, IXpsOMImageResource *object );
			[MethodImpl(MethodImplOptions.InternalCall)]
			void InsertAt([In] uint index, [In] IXpsOMImageResource @object);

			/// <summary>Removes and releases an IXpsOMImageResource interface pointer from a specified location in the collection.</summary>
			/// <param name="index">The zero-based index in the collection from which an IXpsOMImageResource interface pointer is to be removed and released.</param>
			/// <remarks>
			/// <para>This method releases the interface referenced by the pointer at the location specified by index. After releasing the interface, this method compacts the collection by reducing by 1 the index of each pointer subsequent to index.</para>
			/// <para>For more information about the collection methods, see Working with XPS OM Collection Interfaces.</para>
			/// </remarks>
			// https://docs.microsoft.com/en-us/windows/win32/api/xpsobjectmodel/nf-xpsobjectmodel-ixpsomimageresourcecollection-removeat
			// HRESULT RemoveAt( UINT32 index );
			[MethodImpl(MethodImplOptions.InternalCall)]
			void RemoveAt([In] uint index);

			/// <summary>Replaces an IXpsOMImageResource interface pointer at a specified location in the collection.</summary>
			/// <param name="index">The zero-based index in the collection where an IXpsOMImageResource interface pointer is to be replaced.</param>
			/// <param name="object">The IXpsOMImageResource interface pointer that will replace current contents at the location specified by index.</param>
			/// <remarks>
			/// <para>At the location specified by index, this method releases the IXpsOMImageResource interface referenced by the existing pointer, then writes the pointer that is passed in object.</para>
			/// <para>For more information about the collection methods, see Working with XPS OM Collection Interfaces.</para>
			/// </remarks>
			// https://docs.microsoft.com/en-us/windows/win32/api/xpsobjectmodel/nf-xpsobjectmodel-ixpsomimageresourcecollection-setat
			// HRESULT SetAt( UINT32 index, IXpsOMImageResource *object );
			[MethodImpl(MethodImplOptions.InternalCall)]
			void SetAt([In] uint index, [In] IXpsOMImageResource @object);

			/// <summary>Appends an IXpsOMImageResource interface to the end of the collection.</summary>
			/// <param name="object">A pointer to the IXpsOMImageResource interface that is to be appended to the collection.</param>
			/// <remarks>For more information about the collection methods, see Working with XPS OM Collection Interfaces.</remarks>
			// https://docs.microsoft.com/en-us/windows/win32/api/xpsobjectmodel/nf-xpsobjectmodel-ixpsomimageresourcecollection-append
			// HRESULT Append( IXpsOMImageResource *object );
			[MethodImpl(MethodImplOptions.InternalCall)]
			void Append([In] IXpsOMImageResource @object);

			/// <summary>Gets an IXpsOMImageResource interface pointer from the collection by matching the interface's part name.</summary>
			/// <param name="partName">The part name of the interface that is to be found in the collection.</param>
			/// <returns>The IXpsOMImageResource interface whose part name matches partName. If a matching interface is not found in the collection, a <c>NULL</c> pointer is returned.</returns>
			// https://docs.microsoft.com/en-us/windows/win32/api/xpsobjectmodel/nf-xpsobjectmodel-ixpsomimageresourcecollection-getbypartname
			// HRESULT GetByPartName( IOpcPartUri *partName, IXpsOMImageResource **part );
			[MethodImpl(MethodImplOptions.InternalCall)]
			IXpsOMImageResource GetByPartName([In] IOpcPartUri partName);
		}

		/// <summary>Specifies a linear gradient, which is the color gradient along a vector.</summary>
		/// <remarks>
		/// <para>In the illustration that follows, the start and end points of a linear gradient are also the start and end points of the gradient path, which is the straight line that connects those points.</para>
		/// <para>The gradient region of a linear gradient is the area between and including the start and end points and extending in both directions at a right angle to the gradient path. The spread area is the area of the geometry that lies outside the gradient region.</para>
		/// <para>Gradient stops are used to define the color at specific locations along the gradient path. In the illustration, gradient stop 0 is located at the start point of the gradient path, and gradient stop 1 is at the end point. The <c>XPS_SPREAD_METHOD_PAD</c> spread method is used to fill the spread area.</para>
		/// <para>The code example that follows illustrates how to create an instance of this interface.</para>
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows/win32/api/xpsobjectmodel/nn-xpsobjectmodel-ixpsomlineargradientbrush
		[PInvokeData("xpsobjectmodel.h", MSDNShortId = "739bf088-0f09-47c1-9b49-6c279395f15b")]
		[ComImport, Guid("005E279F-C30D-40FF-93EC-1950D3C528DB"), InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
		public interface IXpsOMLinearGradientBrush : IXpsOMGradientBrush
		{
			/// <summary>Gets the <c>IUnknown</c> interface of the parent.</summary>
			/// <returns>A pointer to the <c>IUnknown</c> interface of the parent.</returns>
			// https://docs.microsoft.com/en-us/windows/win32/api/xpsobjectmodel/nf-xpsobjectmodel-ixpsomshareable-getowner
			// HRESULT GetOwner( IUnknown **owner );
			[return: MarshalAs(UnmanagedType.IUnknown)]
			new object GetOwner();

			/// <summary>Gets the object type of the interface.</summary>
			/// <returns>The XPS_OBJECT_TYPE value that describes the interface that is derived from IXpsOMShareable.</returns>
			// https://docs.microsoft.com/en-us/windows/win32/api/xpsobjectmodel/nf-xpsobjectmodel-ixpsomshareable-gettype
			// HRESULT GetType( XPS_OBJECT_TYPE *type );
			new XPS_OBJECT_TYPE GetType();

			/// <summary>Gets the opacity of the brush.</summary>
			/// <returns>
			/// The opacity value of the brush.
			/// </returns>
			/// <remarks>opacity is expressed as a value between 0.0 and 1.0; 0.0 indicates that the brush is completely transparent, 0.5 that it is 50 percent opaque, and 1.0 that it is completely opaque.</remarks>
			// https://docs.microsoft.com/en-us/windows/win32/api/xpsobjectmodel/nf-xpsobjectmodel-ixpsombrush-getopacity
			// HRESULT GetOpacity( FLOAT *opacity );
			new float GetOpacity();

			/// <summary>Sets the opacity of the brush.</summary>
			/// <param name="opacity">The opacity value of the brush.</param>
			/// <remarks>
			/// <para>opacity is expressed as a value between 0.0 and 1.0; 0.0 indicates that the brush is completely transparent, 0.5 that it is 50 percent opaque, and 1.0 that it is completely opaque.</para>
			/// <para>If opacity is less than 0.0 or greater than 1.0, the method returns an error.</para>
			/// </remarks>
			// https://docs.microsoft.com/en-us/windows/win32/api/xpsobjectmodel/nf-xpsobjectmodel-ixpsombrush-setopacity
			// HRESULT SetOpacity( FLOAT opacity );
			new void SetOpacity([In] float opacity);

			/// <summary>Gets a pointer to an IXpsOMGradientStopCollection interface that contains the collection of IXpsOMGradientStop interfaces that define the gradient.</summary>
			/// <returns>A pointer to the IXpsOMGradientStopCollection interface that contains the collection of IXpsOMGradientStop interfaces.</returns>
			/// <remarks>
			/// <para>Gradient stops, which are described in the XPS OM by an IXpsOMGradientStop interface, are used to define the color at a specific location along a gradient path; the color is interpolated between the gradient stops. The illustration that follows shows the gradient path and gradient stops of a linear gradient.</para>
			/// <para>The illustration that follows shows the gradient stops of a radial gradient. In this example, the gradient region is the area enclosed by the outer ellipse, and the radial gradient is using the <c>XPS_SPREAD_METHOD_REFLECT</c> spread method to fill the space outside of the gradient region.</para>
			/// </remarks>
			// https://docs.microsoft.com/en-us/windows/win32/api/xpsobjectmodel/nf-xpsobjectmodel-ixpsomgradientbrush-getgradientstops
			// HRESULT GetGradientStops( IXpsOMGradientStopCollection **gradientStops );
			new IXpsOMGradientStopCollection GetGradientStops();

			/// <summary>Gets a pointer to the IXpsOMMatrixTransform interface that contains the resolved matrix transform for the brush.</summary>
			/// <returns>
			/// <para>A pointer to the IXpsOMMatrixTransform interface that contains the resolved matrix transform for the brush. If the transform has not been set, a <c>NULL</c> pointer is returned.</para>
			/// <para>The value that is returned in this parameter depends on which method has been most recently called to set the transform.</para>
			/// <list type="table">
			/// <listheader>
			/// <term>Most recent method called</term>
			/// <term>Object that is returned in transform</term>
			/// </listheader>
			/// <item>
			/// <term>SetTransformLocal</term>
			/// <term>The local transform that is set by SetTransformLocal.</term>
			/// </item>
			/// <item>
			/// <term>SetTransformLookup</term>
			/// <term>The shared transform that is retrieved, with a lookup key that matches the key set by SetTransformLookup, from the resource directory.</term>
			/// </item>
			/// <item>
			/// <term>Neither SetTransformLocal nor SetTransformLookup has been called yet.</term>
			/// <term>NULL pointer.</term>
			/// </item>
			/// </list>
			/// </returns>
			/// <remarks>The transform determines how the gradient is transformed. The visible part of the gradient that is ultimately rendered in the image is determined by the path, stroke, or glyph that is using the gradient brush.</remarks>
			// https://docs.microsoft.com/en-us/windows/win32/api/xpsobjectmodel/nf-xpsobjectmodel-ixpsomgradientbrush-gettransform
			// HRESULT GetTransform( IXpsOMMatrixTransform **transform );
			new IXpsOMMatrixTransform GetTransform();

			/// <summary>Gets a pointer to the IXpsOMMatrixTransform interface that contains the local, unshared, resolved matrix transform for the brush.</summary>
			/// <returns>
			/// <para>A pointer to the IXpsOMMatrixTransform interface that contains the local, unshared, resolved matrix transform for the brush. If the transform has not been set or if a matrix transform lookup key has been set, a <c>NULL</c> pointer is returned.</para>
			/// <para>The value that is returned in this parameter depends on which method has been most recently called to set the transform.</para>
			/// <list type="table">
			/// <listheader>
			/// <term>Most recent method called</term>
			/// <term>Object that is returned in transform</term>
			/// </listheader>
			/// <item>
			/// <term>SetTransformLocal</term>
			/// <term>The local transform that is set by SetTransformLocal.</term>
			/// </item>
			/// <item>
			/// <term>SetTransformLookup</term>
			/// <term>NULL pointer.</term>
			/// </item>
			/// <item>
			/// <term>Neither SetTransformLocal nor SetTransformLookup has been called yet.</term>
			/// <term>NULL pointer.</term>
			/// </item>
			/// </list>
			/// </returns>
			/// <remarks>The transform determines how the gradient is transformed. The visible part of the gradient that is ultimately rendered in the image is determined by the path, stroke, or glyph that is using the gradient brush.</remarks>
			// https://docs.microsoft.com/en-us/windows/win32/api/xpsobjectmodel/nf-xpsobjectmodel-ixpsomgradientbrush-gettransformlocal
			// HRESULT GetTransformLocal( IXpsOMMatrixTransform **transform );
			new IXpsOMMatrixTransform GetTransformLocal();

			/// <summary>
			/// Sets the IXpsOMMatrixTransform interface pointer to a local, unshared matrix transform that is to be used for the brush.
			/// </summary>
			/// <param name="transform">A pointer to the IXpsOMMatrixTransform interface of the local, unshared matrix transform that is to be used for the brush. A <c>NULL</c> pointer releases any previously set interface.</param>
			/// <remarks>
			/// <para>After you call <c>SetTransformLocal</c>, the transform lookup key is released and GetTransformLocal returns a <c>NULL</c> pointer in the transform parameter. The table that follows explains the relationship between the local and lookup values of this property.</para>
			/// <list type="table">
			///   <listheader>
			///     <term>Most recent method called</term>
			///     <term>Object that is returned in transform by GetTransform</term>
			///     <term>Object that is returned in transform by GetTransformLocal</term>
			///     <term>Object that is returned in key by GetTransformLookup</term>
			///   </listheader>
			///   <item>
			///     <term>SetTransformLocal (this method)</term>
			///     <term>The local transform that is set by SetTransformLocal.</term>
			///     <term>The local transform that is set by SetTransformLocal.</term>
			///     <term>NULL pointer.</term>
			///   </item>
			///   <item>
			///     <term>SetTransformLookup</term>
			///     <term>The shared transform retrieved, with a lookup key that matches the key that is set by SetTransformLookup, from the resource directory.</term>
			///     <term>NULL pointer.</term>
			///     <term>The lookup key that is set by SetTransformLookup.</term>
			///   </item>
			///   <item>
			///     <term>Neither SetTransformLocal nor SetTransformLookup has been called yet.</term>
			///     <term>NULL pointer.</term>
			///     <term>NULL pointer.</term>
			///     <term>NULL pointer.</term>
			///   </item>
			/// </list>
			/// <para>The transform passed in transform determines how the gradient is transformed. The visible part of the gradient that is ultimately rendered in the image is determined by the path, stroke, or glyph that is using the gradient brush.</para>
			/// </remarks>
			// https://docs.microsoft.com/en-us/windows/win32/api/xpsobjectmodel/nf-xpsobjectmodel-ixpsomgradientbrush-settransformlocal
			// HRESULT SetTransformLocal( IXpsOMMatrixTransform *transform );
			new void SetTransformLocal([In] IXpsOMMatrixTransform transform);

			/// <summary>
			/// <para>Gets the name of the lookup key of the shared matrix transform interface that is to be used for the brush.</para>
			/// <para>The key name identifies a shared resource in a resource dictionary.</para>
			/// </summary>
			/// <returns>
			/// <para>The name of the lookup key of the shared matrix transform interface that is to be used for the brush. If the lookup key name has not been set or if the local matrix transform has been set, a <c>NULL</c> pointer is returned.</para>
			/// <para>The value that is returned in this parameter depends on which method has been most recently called to set the lookup key or the transform.</para>
			/// <list type="table">
			/// <listheader>
			/// <term>Most recent method called</term>
			/// <term>String that is returned in key</term>
			/// </listheader>
			/// <item>
			/// <term>SetTransformLocal</term>
			/// <term>NULL pointer.</term>
			/// </item>
			/// <item>
			/// <term>SetTransformLookup</term>
			/// <term>The key that is set by SetTransformLookup.</term>
			/// </item>
			/// <item>
			/// <term>Neither SetTransformLocal nor SetTransformLookup has been called yet.</term>
			/// <term>NULL pointer.</term>
			/// </item>
			/// </list>
			/// </returns>
			/// <remarks>
			/// <para>This method does not return an IXpsOMMatrixTransform interface pointer; to retrieve this pointer from the dictionary, call IXpsOMDictionary::GetByKey.</para>
			/// <para>The transform determines how the gradient is transformed. The visible part of the gradient that is ultimately rendered in the image is determined by the path, stroke, or glyph that is using the gradient brush.</para>
			/// </remarks>
			// https://docs.microsoft.com/en-us/windows/win32/api/xpsobjectmodel/nf-xpsobjectmodel-ixpsomgradientbrush-gettransformlookup
			// HRESULT GetTransformLookup( LPWSTR *key );
			new SafeCoTaskMemString GetTransformLookup();

			/// <summary>
			/// <para>Sets the name of the lookup key of a shared matrix transform that is to be used for the brush.</para>
			/// <para>The key name identifies a shared resource in a resource dictionary.</para>
			/// </summary>
			/// <param name="key">The name of the lookup key of the matrix transform that is to be used for the brush.</param>
			/// <remarks>
			/// <para>After you call <c>SetTransformLookup</c>, the local transform is released and GetTransformLocal returns a <c>NULL</c> pointer in the transform parameter. The table that follows explains the relationship between the local and lookup values of this property.</para>
			/// <list type="table">
			///   <listheader>
			///     <term>Most recent method called</term>
			///     <term>Object that is returned in transform by GetTransform</term>
			///     <term>Object that is returned in transform by GetTransformLocal</term>
			///     <term>Object that is returned in key by GetTransformLookup</term>
			///   </listheader>
			///   <item>
			///     <term>SetTransformLocal</term>
			///     <term>The local transform that is set by SetTransformLocal.</term>
			///     <term>The local transform that is set by SetTransformLocal.</term>
			///     <term>NULL pointer.</term>
			///   </item>
			///   <item>
			///     <term>SetTransformLookup (this method)</term>
			///     <term>The shared transform retrieved, with a lookup key that matches the key that is set by SetTransformLookup, from the resource directory.</term>
			///     <term>NULL pointer.</term>
			///     <term>The lookup key that is set by SetTransformLookup.</term>
			///   </item>
			///   <item>
			///     <term>Neither SetTransformLocal nor SetTransformLookup has been called yet.</term>
			///     <term>NULL pointer.</term>
			///     <term>NULL pointer.</term>
			///     <term>NULL pointer.</term>
			///   </item>
			/// </list>
			/// <para>The transform referenced by key determines how the gradient is transformed. The visible part of the gradient that is ultimately rendered in the image is determined by the path, stroke, or glyph that is using the brush.</para>
			/// </remarks>
			// https://docs.microsoft.com/en-us/windows/win32/api/xpsobjectmodel/nf-xpsobjectmodel-ixpsomgradientbrush-settransformlookup
			// HRESULT SetTransformLookup( LPCWSTR key );
			new void SetTransformLookup([In, MarshalAs(UnmanagedType.LPWStr)] string key);

			/// <summary>Gets the XPS_SPREAD_METHOD value, which describes how the area outside of the gradient region will be rendered.</summary>
			/// <returns>The XPS_SPREAD_METHOD value that describes how the area outside of the gradient region will be rendered. The gradient region is defined by the linear-gradient brush or radial-gradient brush that inherits this interface.</returns>
			/// <remarks>For more information about different types of spread methods, see XPS_SPREAD_METHOD.</remarks>
			// https://docs.microsoft.com/en-us/windows/win32/api/xpsobjectmodel/nf-xpsobjectmodel-ixpsomgradientbrush-getspreadmethod
			// HRESULT GetSpreadMethod( XPS_SPREAD_METHOD *spreadMethod );
			new XPS_SPREAD_METHOD GetSpreadMethod();

			/// <summary>
			/// Sets the XPS_SPREAD_METHOD value, which describes how the area outside of the gradient region is to be rendered. The gradient region is defined by the start and end points of the gradient.
			/// </summary>
			/// <param name="spreadMethod">The XPS_SPREAD_METHOD value that describes how the area outside of the gradient region is to be rendered. The gradient region is defined by the linear-gradient brush or radial-gradient brush that inherits this interface.</param>
			/// <remarks>
			/// For more information about different types of spread methods, see XPS_SPREAD_METHOD.
			/// </remarks>
			// https://docs.microsoft.com/en-us/windows/win32/api/xpsobjectmodel/nf-xpsobjectmodel-ixpsomgradientbrush-setspreadmethod
			// HRESULT SetSpreadMethod( XPS_SPREAD_METHOD spreadMethod );
			new void SetSpreadMethod([In] XPS_SPREAD_METHOD spreadMethod);

			/// <summary>Gets the gamma function to be used for color interpolation.</summary>
			/// <returns>The XPS_COLOR_INTERPOLATION value that describes the gamma function to be used for color interpolation.</returns>
			// https://docs.microsoft.com/en-us/windows/win32/api/xpsobjectmodel/nf-xpsobjectmodel-ixpsomgradientbrush-getcolorinterpolationmode
			// HRESULT GetColorInterpolationMode( XPS_COLOR_INTERPOLATION *colorInterpolationMode );
			new XPS_COLOR_INTERPOLATION GetColorInterpolationMode();

			/// <summary>
			/// Sets the XPS_COLOR_INTERPOLATION value, which describes the gamma function to be used for color interpolation.
			/// </summary>
			/// <param name="colorInterpolationMode">The XPS_COLOR_INTERPOLATION value, which describes the gamma function to be used for color interpolation.</param>
			// https://docs.microsoft.com/en-us/windows/win32/api/xpsobjectmodel/nf-xpsobjectmodel-ixpsomgradientbrush-setcolorinterpolationmode
			// HRESULT SetColorInterpolationMode( XPS_COLOR_INTERPOLATION colorInterpolationMode );
			new void SetColorInterpolationMode([In] XPS_COLOR_INTERPOLATION colorInterpolationMode);

			/// <summary>Gets the start point of the gradient.</summary>
			/// <returns>The x and y coordinates of the start point.</returns>
			/// <remarks>The coordinates are relative to the page and are expressed in the units of the transform that is in effect.</remarks>
			// https://docs.microsoft.com/en-us/windows/win32/api/xpsobjectmodel/nf-xpsobjectmodel-ixpsomlineargradientbrush-getstartpoint
			// HRESULT GetStartPoint( XPS_POINT *startPoint );
			XPS_POINT GetStartPoint();

			/// <summary>
			/// Sets the start point of the gradient.
			/// </summary>
			/// <param name="startPoint">The x and y coordinates of the start point.</param>
			/// <remarks>
			/// The coordinates are relative to the page and are expressed in the units of the transform that is in effect.
			/// </remarks>
			// https://docs.microsoft.com/en-us/windows/win32/api/xpsobjectmodel/nf-xpsobjectmodel-ixpsomlineargradientbrush-setstartpoint
			// HRESULT SetStartPoint( const XPS_POINT *startPoint );
			void SetStartPoint(in XPS_POINT startPoint);

			/// <summary>Gets the end point of the gradient.</summary>
			/// <returns>The x and y coordinates of the end point.</returns>
			/// <remarks>The coordinates are relative to the page and are expressed in units of the transform that is in effect.</remarks>
			// https://docs.microsoft.com/en-us/windows/win32/api/xpsobjectmodel/nf-xpsobjectmodel-ixpsomlineargradientbrush-getendpoint
			// HRESULT GetEndPoint( XPS_POINT *endPoint );
			XPS_POINT GetEndPoint();

			/// <summary>
			/// Sets the end point of the gradient.
			/// </summary>
			/// <param name="endPoint">The x and y coordinates of the end point.</param>
			/// <remarks>
			/// The coordinates are relative to the page and are expressed in the units of the transform that is in effect.
			/// </remarks>
			// https://docs.microsoft.com/en-us/windows/win32/api/xpsobjectmodel/nf-xpsobjectmodel-ixpsomlineargradientbrush-setendpoint
			// HRESULT SetEndPoint( const XPS_POINT *endPoint );
			void SetEndPoint(in XPS_POINT endPoint);

			/// <summary>Makes a deep copy of the interface.</summary>
			/// <returns>A pointer to the copy of the interface.</returns>
			/// <remarks>This method does not update any of the resource pointers in the copy.</remarks>
			// https://docs.microsoft.com/en-us/windows/win32/api/xpsobjectmodel/nf-xpsobjectmodel-ixpsomlineargradientbrush-clone
			// HRESULT Clone( IXpsOMLinearGradientBrush **linearGradientBrush );
			IXpsOMLinearGradientBrush Clone();
		}

		[ComImport, Guid("B77330FF-BB37-4501-A93E-F1B1E50BFC46"), InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
		public interface IXpsOMMatrixTransform : IXpsOMShareable
		{
			/// <summary>Gets the <c>IUnknown</c> interface of the parent.</summary>
			/// <returns>A pointer to the <c>IUnknown</c> interface of the parent.</returns>
			// https://docs.microsoft.com/en-us/windows/win32/api/xpsobjectmodel/nf-xpsobjectmodel-ixpsomshareable-getowner
			// HRESULT GetOwner( IUnknown **owner );
			[return: MarshalAs(UnmanagedType.IUnknown)]
			new object GetOwner();

			/// <summary>Gets the object type of the interface.</summary>
			/// <returns>The XPS_OBJECT_TYPE value that describes the interface that is derived from IXpsOMShareable.</returns>
			// https://docs.microsoft.com/en-us/windows/win32/api/xpsobjectmodel/nf-xpsobjectmodel-ixpsomshareable-gettype
			// HRESULT GetType( XPS_OBJECT_TYPE *type );
			new XPS_OBJECT_TYPE GetType();

			IXpsOMMatrixTransform Clone();

			XPS_MATRIX GetMatrix();

			void SetMatrix(in XPS_MATRIX matrix);
		}

		[ComImport, Guid("4BDDF8EC-C915-421B-A166-D173D25653D2"), InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
		public interface IXpsOMNameCollection
		{
			SafeCoTaskMemString GetAt([In] uint index);

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
			IXpsOMPackage CreatePackageFromFile([In, MarshalAs(UnmanagedType.LPWStr)] string fileName, [In] int reuseObjects);

			[MethodImpl(MethodImplOptions.InternalCall)]
			[return: MarshalAs(UnmanagedType.Interface)]
			IXpsOMPackage CreatePackageFromStream([MarshalAs(UnmanagedType.Interface)] [In] IStream stream, [In] int reuseObjects);

			[MethodImpl(MethodImplOptions.InternalCall)]
			[return: MarshalAs(UnmanagedType.Interface)]
			IXpsOMStoryFragmentsResource CreateStoryFragmentsResource([MarshalAs(UnmanagedType.Interface)] [In] IStream acquiredStream, [In] IOpcPartUri partUri);

			[MethodImpl(MethodImplOptions.InternalCall)]
			[return: MarshalAs(UnmanagedType.Interface)]
			IXpsOMDocumentStructureResource CreateDocumentStructureResource([MarshalAs(UnmanagedType.Interface)] [In] IStream acquiredStream, [In] IOpcPartUri partUri);

			[MethodImpl(MethodImplOptions.InternalCall)]
			[return: MarshalAs(UnmanagedType.Interface)]
			IXpsOMSignatureBlockResource CreateSignatureBlockResource([MarshalAs(UnmanagedType.Interface)] [In] IStream acquiredStream, [In] IOpcPartUri partUri);

			[MethodImpl(MethodImplOptions.InternalCall)]
			[return: MarshalAs(UnmanagedType.Interface)]
			IXpsOMRemoteDictionaryResource CreateRemoteDictionaryResource([In] IXpsOMDictionary dictionary, [In] IOpcPartUri partUri);

			[MethodImpl(MethodImplOptions.InternalCall)]
			[return: MarshalAs(UnmanagedType.Interface)]
			IXpsOMRemoteDictionaryResource CreateRemoteDictionaryResourceFromStream([MarshalAs(UnmanagedType.Interface)] [In] IStream dictionaryMarkupStream, [In] IOpcPartUri dictionaryPartUri, [In] IXpsOMPartResources resources);

			[MethodImpl(MethodImplOptions.InternalCall)]
			[return: MarshalAs(UnmanagedType.Interface)]
			IXpsOMPartResources CreatePartResources();

			[MethodImpl(MethodImplOptions.InternalCall)]
			[return: MarshalAs(UnmanagedType.Interface)]
			IXpsOMDocumentSequence CreateDocumentSequence([In] IOpcPartUri partUri);

			[MethodImpl(MethodImplOptions.InternalCall)]
			[return: MarshalAs(UnmanagedType.Interface)]
			IXpsOMDocument CreateDocument([In] IOpcPartUri partUri);

			[MethodImpl(MethodImplOptions.InternalCall)]
			[return: MarshalAs(UnmanagedType.Interface)]
			IXpsOMPageReference CreatePageReference( in XPS_SIZE advisoryPageDimensions);

			[MethodImpl(MethodImplOptions.InternalCall)]
			[return: MarshalAs(UnmanagedType.Interface)]
			IXpsOMPage CreatePage( in XPS_SIZE pageDimensions, [In, MarshalAs(UnmanagedType.LPWStr)] string language, [In] IOpcPartUri partUri);

			[MethodImpl(MethodImplOptions.InternalCall)]
			[return: MarshalAs(UnmanagedType.Interface)]
			IXpsOMPage CreatePageFromStream([MarshalAs(UnmanagedType.Interface)] [In] IStream pageMarkupStream, [In] IOpcPartUri partUri, [In] IXpsOMPartResources resources, [In] int reuseObjects);

			[MethodImpl(MethodImplOptions.InternalCall)]
			[return: MarshalAs(UnmanagedType.Interface)]
			IXpsOMCanvas CreateCanvas();

			[MethodImpl(MethodImplOptions.InternalCall)]
			[return: MarshalAs(UnmanagedType.Interface)]
			IXpsOMGlyphs CreateGlyphs([In] IXpsOMFontResource fontResource);

			[MethodImpl(MethodImplOptions.InternalCall)]
			[return: MarshalAs(UnmanagedType.Interface)]
			IXpsOMPath CreatePath();

			[MethodImpl(MethodImplOptions.InternalCall)]
			[return: MarshalAs(UnmanagedType.Interface)]
			IXpsOMGeometry CreateGeometry();

			[MethodImpl(MethodImplOptions.InternalCall)]
			[return: MarshalAs(UnmanagedType.Interface)]
			IXpsOMGeometryFigure CreateGeometryFigure( in XPS_POINT startPoint);

			[MethodImpl(MethodImplOptions.InternalCall)]
			[return: MarshalAs(UnmanagedType.Interface)]
			IXpsOMMatrixTransform CreateMatrixTransform( in XPS_MATRIX matrix);

			[MethodImpl(MethodImplOptions.InternalCall)]
			[return: MarshalAs(UnmanagedType.Interface)]
			IXpsOMSolidColorBrush CreateSolidColorBrush( in XPS_COLOR color, [In] IXpsOMColorProfileResource colorProfile);

			[MethodImpl(MethodImplOptions.InternalCall)]
			[return: MarshalAs(UnmanagedType.Interface)]
			IXpsOMColorProfileResource CreateColorProfileResource([MarshalAs(UnmanagedType.Interface)] [In] IStream acquiredStream, [In] IOpcPartUri partUri);

			[MethodImpl(MethodImplOptions.InternalCall)]
			[return: MarshalAs(UnmanagedType.Interface)]
			IXpsOMImageBrush CreateImageBrush([In] IXpsOMImageResource image,  in XPS_RECT viewbox,  in XPS_RECT viewport);

			[MethodImpl(MethodImplOptions.InternalCall)]
			[return: MarshalAs(UnmanagedType.Interface)]
			IXpsOMVisualBrush CreateVisualBrush( in XPS_RECT viewbox,  in XPS_RECT viewport);

			[MethodImpl(MethodImplOptions.InternalCall)]
			[return: MarshalAs(UnmanagedType.Interface)]
			IXpsOMImageResource CreateImageResource([MarshalAs(UnmanagedType.Interface)] [In] IStream acquiredStream,  [In] XPS_IMAGE_TYPE contentType, [In] IOpcPartUri partUri);

			[MethodImpl(MethodImplOptions.InternalCall)]
			[return: MarshalAs(UnmanagedType.Interface)]
			IXpsOMPrintTicketResource CreatePrintTicketResource([MarshalAs(UnmanagedType.Interface)] [In] IStream acquiredStream, [In] IOpcPartUri partUri);

			[MethodImpl(MethodImplOptions.InternalCall)]
			[return: MarshalAs(UnmanagedType.Interface)]
			IXpsOMFontResource CreateFontResource([MarshalAs(UnmanagedType.Interface)] [In] IStream acquiredStream,  [In] XPS_FONT_EMBEDDING fontEmbedding, [In] IOpcPartUri partUri, [In] int isObfSourceStream);

			[MethodImpl(MethodImplOptions.InternalCall)]
			[return: MarshalAs(UnmanagedType.Interface)]
			IXpsOMGradientStop CreateGradientStop( in XPS_COLOR color, [In] IXpsOMColorProfileResource colorProfile, [In] float offset);

			[MethodImpl(MethodImplOptions.InternalCall)]
			[return: MarshalAs(UnmanagedType.Interface)]
			IXpsOMLinearGradientBrush CreateLinearGradientBrush([In] IXpsOMGradientStop gradStop1, [In] IXpsOMGradientStop gradStop2,  in XPS_POINT startPoint,  in XPS_POINT endPoint);

			[MethodImpl(MethodImplOptions.InternalCall)]
			[return: MarshalAs(UnmanagedType.Interface)]
			IXpsOMRadialGradientBrush CreateRadialGradientBrush([In] IXpsOMGradientStop gradStop1, [In] IXpsOMGradientStop gradStop2,  in XPS_POINT centerPoint,  in XPS_POINT gradientOrigin,  in XPS_SIZE radiiSizes);

			[MethodImpl(MethodImplOptions.InternalCall)]
			[return: MarshalAs(UnmanagedType.Interface)]
			IXpsOMCoreProperties CreateCoreProperties([In] IOpcPartUri partUri);

			[MethodImpl(MethodImplOptions.InternalCall)]
			[return: MarshalAs(UnmanagedType.Interface)]
			IXpsOMDictionary CreateDictionary();

			[MethodImpl(MethodImplOptions.InternalCall)]
			[return: MarshalAs(UnmanagedType.Interface)]
			IXpsOMPartUriCollection CreatePartUriCollection();

			[MethodImpl(MethodImplOptions.InternalCall)]
			[return: MarshalAs(UnmanagedType.Interface)]
			IXpsOMPackageWriter CreatePackageWriterOnFile([In, MarshalAs(UnmanagedType.LPWStr)] string fileName, [In] IntPtr securityAttributes, [In] uint flagsAndAttributes, [In] int optimizeMarkupSize,  [In] XPS_INTERLEAVING interleaving, [In] IOpcPartUri documentSequencePartName, [In] IXpsOMCoreProperties coreProperties, [In] IXpsOMImageResource packageThumbnail, [In] IXpsOMPrintTicketResource documentSequencePrintTicket, [In] IOpcPartUri discardControlPartName);

			[MethodImpl(MethodImplOptions.InternalCall)]
			[return: MarshalAs(UnmanagedType.Interface)]
			IXpsOMPackageWriter CreatePackageWriterOnStream([MarshalAs(UnmanagedType.Interface)] [In] ISequentialStream outputStream, [In] int optimizeMarkupSize,  [In] XPS_INTERLEAVING interleaving, [In] IOpcPartUri documentSequencePartName, [In] IXpsOMCoreProperties coreProperties, [In] IXpsOMImageResource packageThumbnail, [In] IXpsOMPrintTicketResource documentSequencePrintTicket, [In] IOpcPartUri discardControlPartName);

			[MethodImpl(MethodImplOptions.InternalCall)]
			[return: MarshalAs(UnmanagedType.Interface)]
			IOpcPartUri CreatePartUri([In, MarshalAs(UnmanagedType.LPWStr)] string uri);

			[MethodImpl(MethodImplOptions.InternalCall)]
			[return: MarshalAs(UnmanagedType.Interface)]
			IStream CreateReadOnlyStreamOnFile([In, MarshalAs(UnmanagedType.LPWStr)] string fileName);
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

			void WriteToFile([In, MarshalAs(UnmanagedType.LPWStr)] string fileName, [In] SECURITY_ATTRIBUTES securityAttributes, [In] uint flagsAndAttributes, [In] int optimizeMarkupSize);

			void WriteToStream([In] ISequentialStream stream, [In] int optimizeMarkupSize);
		}

		[ComImport, Guid("4E2AA182-A443-42C6-B41B-4F8E9DE73FF9")]
		[InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
		public interface IXpsOMPackageWriter
		{
			[MethodImpl(MethodImplOptions.InternalCall)]
			void StartNewDocument([In] IOpcPartUri documentPartName, [In] IXpsOMPrintTicketResource documentPrintTicket, [In] IXpsOMDocumentStructureResource documentStructure, [In] IXpsOMSignatureBlockResourceCollection signatureBlockResources, [In] IXpsOMPartUriCollection restrictedFonts);

			[MethodImpl(MethodImplOptions.InternalCall)]
			void AddPage([In] IXpsOMPage page, [ComAliasName("MSXPS.XPS_SIZE")] in XPS_SIZE advisoryPageDimensions, [In] IXpsOMPartUriCollection discardableResourceParts, [In] IXpsOMStoryFragmentsResource storyFragments, [In] IXpsOMPrintTicketResource pagePrintTicket, [In] IXpsOMImageResource pageThumbnail);

			[MethodImpl(MethodImplOptions.InternalCall)]
			void AddResource([In] IXpsOMResource resource);

			[MethodImpl(MethodImplOptions.InternalCall)]
			void Close();

			[MethodImpl(MethodImplOptions.InternalCall)]
			int isClosed();
		}

		[ComImport, Guid("D3E18888-F120-4FEE-8C68-35296EAE91D4"), InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
		public interface IXpsOMPage : IXpsOMPart
		{
			/// <summary>Gets the name that will be used when the part is serialized.</summary>
			/// <returns>
			/// A pointer to the IOpcPartUri interface that contains the part name. If the part name has not been set (by the SetPartName
			/// method), a <c>NULL</c> pointer is returned.
			/// </returns>
			// https://docs.microsoft.com/en-us/windows/win32/api/xpsobjectmodel/nf-xpsobjectmodel-ixpsompart-getpartname HRESULT
			// GetPartName( IOpcPartUri **partUri );
			[MethodImpl(MethodImplOptions.InternalCall)]
			[return: MarshalAs(UnmanagedType.Interface)]
			new IOpcPartUri GetPartName();

			/// <summary>Sets the name that will be used when the part is serialized.</summary>
			/// <param name="partUri">
			/// A pointer to the IOpcPartUri interface that contains the name of this part. This parameter cannot be <c>NULL</c>.
			/// </param>
			/// <remarks>
			/// IXpsOMPackageWriter will generate an error if it encounters an XPS document part whose name is the same as that of a part it
			/// has previously serialized.
			/// </remarks>
			// https://docs.microsoft.com/en-us/windows/win32/api/xpsobjectmodel/nf-xpsobjectmodel-ixpsompart-setpartname HRESULT
			// SetPartName( IOpcPartUri *partUri );
			[MethodImpl(MethodImplOptions.InternalCall)]
			new void SetPartName([In] IOpcPartUri partUri);

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
			void SetPageDimensions( in XPS_SIZE pageDimensions);

			[MethodImpl(MethodImplOptions.InternalCall)]
			[return: ComAliasName("System.Windows.Xps.Serialization.RCW.XPS_RECT")]
			XPS_RECT GetContentBox();

			[MethodImpl(MethodImplOptions.InternalCall)]
			void SetContentBox( in XPS_RECT contentBox);

			[MethodImpl(MethodImplOptions.InternalCall)]
			[return: ComAliasName("System.Windows.Xps.Serialization.RCW.XPS_RECT")]
			XPS_RECT GetBleedBox();

			[MethodImpl(MethodImplOptions.InternalCall)]
			void SetBleedBox( in XPS_RECT bleedBox);

			[MethodImpl(MethodImplOptions.InternalCall)]
			[return: MarshalAs(UnmanagedType.LPWStr)]
			SafeCoTaskMemString GetLanguage();

			[MethodImpl(MethodImplOptions.InternalCall)]
			void SetLanguage([In, MarshalAs(UnmanagedType.LPWStr)] string language);

			[MethodImpl(MethodImplOptions.InternalCall)]
			[return: MarshalAs(UnmanagedType.LPWStr)]
			SafeCoTaskMemString GetName();

			[MethodImpl(MethodImplOptions.InternalCall)]
			void SetName([In, MarshalAs(UnmanagedType.LPWStr)] string name);

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
			void SetDictionaryLocal([In] IXpsOMDictionary resourceDictionary);

			[MethodImpl(MethodImplOptions.InternalCall)]
			[return: MarshalAs(UnmanagedType.Interface)]
			IXpsOMRemoteDictionaryResource GetDictionaryResource();

			[MethodImpl(MethodImplOptions.InternalCall)]
			void SetDictionaryResource([In] IXpsOMRemoteDictionaryResource remoteDictionaryResource);

			[MethodImpl(MethodImplOptions.InternalCall)]
			void Write([MarshalAs(UnmanagedType.Interface)] [In] ISequentialStream stream, [In] int optimizeMarkupSize);

			[MethodImpl(MethodImplOptions.InternalCall)]
			[return: MarshalAs(UnmanagedType.LPWStr)]
			SafeCoTaskMemString GenerateUnusedLookupKey( [In] XPS_OBJECT_TYPE type);

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

			void SetAdvisoryPageDimensions(in XPS_SIZE pageDimensions);

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

		/// <summary>The base interface for all XPS document part interfaces.</summary>
		// https://docs.microsoft.com/en-us/windows/win32/api/xpsobjectmodel/nn-xpsobjectmodel-ixpsompart
		[PInvokeData("xpsobjectmodel.h", MSDNShortId = "71cd0155-6c95-42ca-bfc3-dffd43d95dc9")]
		[ComImport, Guid("74EB2F0B-A91E-4486-AFAC-0FABECA3DFC6"), InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
		public interface IXpsOMPart
		{
			/// <summary>Gets the name that will be used when the part is serialized.</summary>
			/// <returns>
			/// A pointer to the IOpcPartUri interface that contains the part name. If the part name has not been set (by the SetPartName
			/// method), a <c>NULL</c> pointer is returned.
			/// </returns>
			// https://docs.microsoft.com/en-us/windows/win32/api/xpsobjectmodel/nf-xpsobjectmodel-ixpsompart-getpartname HRESULT
			// GetPartName( IOpcPartUri **partUri );
			[MethodImpl(MethodImplOptions.InternalCall)]
			IOpcPartUri GetPartName();

			/// <summary>Sets the name that will be used when the part is serialized.</summary>
			/// <param name="partUri">
			/// A pointer to the IOpcPartUri interface that contains the name of this part. This parameter cannot be <c>NULL</c>.
			/// </param>
			/// <remarks>
			/// IXpsOMPackageWriter will generate an error if it encounters an XPS document part whose name is the same as that of a part it
			/// has previously serialized.
			/// </remarks>
			// https://docs.microsoft.com/en-us/windows/win32/api/xpsobjectmodel/nf-xpsobjectmodel-ixpsompart-setpartname HRESULT
			// SetPartName( IOpcPartUri *partUri );
			[MethodImpl(MethodImplOptions.InternalCall)]
			void SetPartName([In] IOpcPartUri partUri);
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
			/// <summary>Gets the <c>IUnknown</c> interface of the parent.</summary>
			/// <returns>A pointer to the <c>IUnknown</c> interface of the parent.</returns>
			// https://docs.microsoft.com/en-us/windows/win32/api/xpsobjectmodel/nf-xpsobjectmodel-ixpsomshareable-getowner
			// HRESULT GetOwner( IUnknown **owner );
			[return: MarshalAs(UnmanagedType.IUnknown)]
			new object GetOwner();

			/// <summary>Gets the object type of the interface.</summary>
			/// <returns>The XPS_OBJECT_TYPE value that describes the interface that is derived from IXpsOMShareable.</returns>
			// https://docs.microsoft.com/en-us/windows/win32/api/xpsobjectmodel/nf-xpsobjectmodel-ixpsomshareable-gettype
			// HRESULT GetType( XPS_OBJECT_TYPE *type );
			new XPS_OBJECT_TYPE GetType();

			/// <summary>Gets a pointer to the IXpsOMMatrixTransform interface that contains the visual's resolved matrix transform.</summary>
			/// <returns>
			/// <para>A pointer to the IXpsOMMatrixTransform interface that contains the visual's resolved matrix transform. If a matrix transform has not been set, a <c>NULL</c> pointer is returned.</para>
			/// <para>The value that is returned in this parameter depends on which method has most recently been called to set the transform.</para>
			/// <list type="table">
			/// <listheader>
			/// <term>Most recent method called</term>
			/// <term>Object that is returned in matrixTransform</term>
			/// </listheader>
			/// <item>
			/// <term>SetTransformLocal</term>
			/// <term>The local transform that is set by SetTransformLocal.</term>
			/// </item>
			/// <item>
			/// <term>SetTransformLookup</term>
			/// <term>The shared transform that gets retrieved, with a lookup key that matches the key that is set by SetTransformLookup, from the resource directory.</term>
			/// </item>
			/// <item>
			/// <term>Neither SetTransformLocal nor SetTransformLookup has been called yet.</term>
			/// <term>NULL pointer.</term>
			/// </item>
			/// </list>
			/// </returns>
			// https://docs.microsoft.com/en-us/windows/win32/api/xpsobjectmodel/nf-xpsobjectmodel-ixpsomvisual-gettransform
			// HRESULT GetTransform( IXpsOMMatrixTransform **matrixTransform );
			[MethodImpl(MethodImplOptions.InternalCall)]
			new IXpsOMMatrixTransform GetTransform();

			/// <summary>Gets a pointer to the IXpsOMMatrixTransform interface that contains the local, unshared, resolved matrix transform for the visual.</summary>
			/// <returns>
			/// <para>A pointer to the IXpsOMMatrixTransform interface that contains the local, unshared, resolved matrix transform for the visual. If a matrix transform lookup key has not been set, or if a local matrix transform has been set, a <c>NULL</c> pointer is returned.</para>
			/// <list type="table">
			/// <listheader>
			/// <term>Most recent method called</term>
			/// <term>Object that is returned in matrixTransform</term>
			/// </listheader>
			/// <item>
			/// <term>SetTransformLocal</term>
			/// <term>The local transform that is set by SetTransformLocal.</term>
			/// </item>
			/// <item>
			/// <term>SetTransformLookup</term>
			/// <term>NULL pointer.</term>
			/// </item>
			/// <item>
			/// <term>Neither SetTransformLocal nor SetTransformLookup has been called yet.</term>
			/// <term>NULL pointer.</term>
			/// </item>
			/// </list>
			/// </returns>
			// https://docs.microsoft.com/en-us/windows/win32/api/xpsobjectmodel/nf-xpsobjectmodel-ixpsomvisual-gettransformlocal
			// HRESULT GetTransformLocal( IXpsOMMatrixTransform **matrixTransform );
			[MethodImpl(MethodImplOptions.InternalCall)]
			new IXpsOMMatrixTransform GetTransformLocal();

			/// <summary>
			/// Sets the local, unshared matrix transform.
			/// </summary>
			/// <param name="matrixTransform">A pointer to the IXpsOMMatrixTransform interface to be set as the local, unshared matrix transform. A <c>NULL</c> pointer releases the previously assigned transform.</param>
			/// <remarks>
			/// <para>After you call <c>SetTransformLocal</c>, the transform lookup key is released and GetTransformLookup returns a <c>NULL</c> pointer in the key parameter. The table that follows explains the relationship between the local and lookup values of this property.</para>
			/// <list type="table">
			///   <listheader>
			///     <term>Most recent method called</term>
			///     <term>Object that is returned in transform by GetTransform</term>
			///     <term>Object that is returned in matrixTransform by GetTransformLocal</term>
			///     <term>Object that is returned in key by GetTransformLookup</term>
			///   </listheader>
			///   <item>
			///     <term>SetTransformLocal (this method)</term>
			///     <term>The local transform that is set by SetTransformLocal.</term>
			///     <term>The local transform set by SetTransformLocal.</term>
			///     <term>NULL pointer.</term>
			///   </item>
			///   <item>
			///     <term>SetTransformLookup</term>
			///     <term>The shared transform that gets retrieved, with a lookup key that matches the key that is set by SetTransformLookup, from the resource directory.</term>
			///     <term>NULL pointer.</term>
			///     <term>The lookup key that is set by SetTransformLookup.</term>
			///   </item>
			///   <item>
			///     <term>Neither SetTransformLocal nor SetTransformLookup has been called yet.</term>
			///     <term>NULL pointer.</term>
			///     <term>NULL pointer.</term>
			///     <term>NULL pointer.</term>
			///   </item>
			/// </list>
			/// </remarks>
			// https://docs.microsoft.com/en-us/windows/win32/api/xpsobjectmodel/nf-xpsobjectmodel-ixpsomvisual-settransformlocal
			// HRESULT SetTransformLocal( IXpsOMMatrixTransform *matrixTransform );
			[MethodImpl(MethodImplOptions.InternalCall)]
			new void SetTransformLocal([In] IXpsOMMatrixTransform matrixTransform);

			/// <summary>Gets the lookup key name of the IXpsOMMatrixTransform interface in a resource dictionary that contains the resolved matrix transform for the visual.</summary>
			/// <returns>
			/// <para>The lookup key name for the IXpsOMMatrixTransform interface in a resource dictionary that contains the resolved matrix transform for the visual. If a matrix transform lookup key has not been set, or if a local matrix transform has been set, a <c>NULL</c> pointer is returned.</para>
			/// <list type="table">
			/// <listheader>
			/// <term>Most recent method called</term>
			/// <term>Object that is returned in key</term>
			/// </listheader>
			/// <item>
			/// <term>SetTransformLocal</term>
			/// <term>NULL pointer.</term>
			/// </item>
			/// <item>
			/// <term>SetTransformLookup</term>
			/// <term>The lookup key that is set by SetTransformLookup.</term>
			/// </item>
			/// <item>
			/// <term>Neither SetTransformLocal nor SetTransformLookup has been called yet.</term>
			/// <term>NULL pointer.</term>
			/// </item>
			/// </list>
			/// </returns>
			// https://docs.microsoft.com/en-us/windows/win32/api/xpsobjectmodel/nf-xpsobjectmodel-ixpsomvisual-gettransformlookup
			// HRESULT GetTransformLookup( LPWSTR *key );
			[MethodImpl(MethodImplOptions.InternalCall)]
			new SafeCoTaskMemString GetTransformLookup();

			/// <summary>
			/// Sets the lookup key name of a shared matrix transform in a resource dictionary.
			/// </summary>
			/// <param name="key">The lookup key name of the matrix transform in the dictionary.</param>
			/// <remarks>
			/// <para>After you call <c>SetTransformLookup</c>, the local transform is released and GetTransformLocal returns a <c>NULL</c> pointer in the matrixTransform parameter. The table that follows explains the relationship between the local and lookup values of this property.</para>
			/// <list type="table">
			///   <listheader>
			///     <term>Most recent method called</term>
			///     <term>Object that is returned in transform by GetTransform</term>
			///     <term>Object that is returned in matrixTransform by GetTransformLocal</term>
			///     <term>Object that is returned in key by GetTransformLookup</term>
			///   </listheader>
			///   <item>
			///     <term>SetTransformLocal</term>
			///     <term>The local transform that is set by SetTransformLocal.</term>
			///     <term>The local transform that is set by SetTransformLocal.</term>
			///     <term>NULL pointer.</term>
			///   </item>
			///   <item>
			///     <term>SetTransformLookup (this method)</term>
			///     <term>The shared transform that gets retrieved—with a lookup key that matches the key that is set by SetTransformLookup—from the resource directory.</term>
			///     <term>NULL pointer.</term>
			///     <term>The lookup key that is set by SetTransformLookup.</term>
			///   </item>
			///   <item>
			///     <term>Neither SetTransformLocal nor SetTransformLookup has been called yet.</term>
			///     <term>NULL pointer.</term>
			///     <term>NULL pointer.</term>
			///     <term>NULL pointer.</term>
			///   </item>
			/// </list>
			/// </remarks>
			// https://docs.microsoft.com/en-us/windows/win32/api/xpsobjectmodel/nf-xpsobjectmodel-ixpsomvisual-settransformlookup
			// HRESULT SetTransformLookup( LPCWSTR key );
			[MethodImpl(MethodImplOptions.InternalCall)]
			new void SetTransformLookup([In, MarshalAs(UnmanagedType.LPWStr)] string key);

			/// <summary>Gets a pointer to the IXpsOMGeometry interface that contains the resolved geometry of the visual's clipping region.</summary>
			/// <returns>
			/// <para>A pointer to the IXpsOMGeometry interface that contains the resolved geometry of the visual's clipping region. If the clip geometry has not been set, a <c>NULL</c> pointer is returned.</para>
			/// <para>The value that is returned in this parameter depends on which method has most recently been called to set the geometry.</para>
			/// <list type="table">
			/// <listheader>
			/// <term>Most recent method called</term>
			/// <term>Object that is returned in clipGeometry</term>
			/// </listheader>
			/// <item>
			/// <term>SetClipGeometryLocal</term>
			/// <term>The local clip geometry that is set by SetClipGeometryLocal.</term>
			/// </item>
			/// <item>
			/// <term>SetClipGeometryLookup</term>
			/// <term>The shared clip geometry that gets retrieved, with a lookup key that matches the key that is set by SetClipGeometryLookup, from the resource directory.</term>
			/// </item>
			/// <item>
			/// <term>Neither SetClipGeometryLocal nor SetClipGeometryLookup has been called yet.</term>
			/// <term>NULL pointer.</term>
			/// </item>
			/// </list>
			/// </returns>
			// https://docs.microsoft.com/en-us/windows/win32/api/xpsobjectmodel/nf-xpsobjectmodel-ixpsomvisual-getclipgeometry
			// HRESULT GetClipGeometry( IXpsOMGeometry **clipGeometry );
			[MethodImpl(MethodImplOptions.InternalCall)]
			new IXpsOMGeometry GetClipGeometry();

			/// <summary>Gets a pointer to the IXpsOMGeometry interface that contains the local, unshared geometry of the visual's clipping region.</summary>
			/// <returns>
			/// <para>A pointer to the IXpsOMGeometry interface that contains the local, unshared geometry of the visual's clipping region. If a clip geometry lookup key has been set, or if a local clip geometry has not been set, a <c>NULL</c> pointer is returned.</para>
			/// <list type="table">
			/// <listheader>
			/// <term>Most recent method called</term>
			/// <term>Object that is returned in clipGeometry</term>
			/// </listheader>
			/// <item>
			/// <term>SetClipGeometryLocal</term>
			/// <term>The local clip geometry that is set by SetClipGeometryLocal.</term>
			/// </item>
			/// <item>
			/// <term>SetClipGeometryLookup</term>
			/// <term>NULL pointer.</term>
			/// </item>
			/// <item>
			/// <term>Neither SetClipGeometryLocal nor SetClipGeometryLookup has been called yet.</term>
			/// <term>NULL pointer.</term>
			/// </item>
			/// </list>
			/// </returns>
			// https://docs.microsoft.com/en-us/windows/win32/api/xpsobjectmodel/nf-xpsobjectmodel-ixpsomvisual-getclipgeometrylocal
			// HRESULT GetClipGeometryLocal( IXpsOMGeometry **clipGeometry );
			[MethodImpl(MethodImplOptions.InternalCall)]
			new IXpsOMGeometry GetClipGeometryLocal();

			/// <summary>Sets the local, unshared clipping region for the visual.</summary>
			/// <param name="clipGeometry">A pointer to the IXpsOMGeometry interface to be set as the local, unshared clipping region for the visual. A <c>NULL</c> pointer releases the previously assigned geometry interface.</param>
			/// <remarks>
			/// <para>After you call <c>SetClipGeometryLocal</c>, the clip geometry lookup key is released and GetClipGeometryLookup returns a <c>NULL</c> pointer in the key parameter. The table that follows explains the relationship between the local and lookup values of this property.</para>
			/// <list type="table">
			/// <listheader>
			/// <term>Most recent method called</term>
			/// <term>Object that is returned in clipGeometry by GetClipGeometry</term>
			/// <term>Object that is returned in clipGeometry by GetClipGeometryLocal</term>
			/// <term>String that is returned in key by GetClipGeometryLookup</term>
			/// </listheader>
			/// <item>
			/// <term>SetClipGeometryLocal (this method)</term>
			/// <term>The local clip geometry that is set by SetClipGeometryLocal.</term>
			/// <term>The local clip geometry that is set by SetClipGeometryLocal.</term>
			/// <term>NULL pointer.</term>
			/// </item>
			/// <item>
			/// <term>SetClipGeometryLookup</term>
			/// <term>The shared clip geometry that gets retrieved, with a lookup key that matches the key that is set by SetClipGeometryLookup, from the resource directory.</term>
			/// <term>NULL pointer.</term>
			/// <term>The lookup key that is set by SetClipGeometryLookup.</term>
			/// </item>
			/// <item>
			/// <term>Neither SetClipGeometryLookup nor SetClipGeometryLocal has been called yet.</term>
			/// <term>NULL pointer.</term>
			/// <term>NULL pointer.</term>
			/// <term>NULL pointer.</term>
			/// </item>
			/// </list>
			/// </remarks>
			// https://docs.microsoft.com/en-us/windows/win32/api/xpsobjectmodel/nf-xpsobjectmodel-ixpsomvisual-setclipgeometrylocal
			// HRESULT SetClipGeometryLocal( IXpsOMGeometry *clipGeometry );
			[MethodImpl(MethodImplOptions.InternalCall)]
			new void SetClipGeometryLocal([In] IXpsOMGeometry clipGeometry);

			/// <summary>Gets the lookup key for the IXpsOMGeometry interface in a resource dictionary that contains the visual's clipping region.</summary>
			/// <returns>
			/// <para>The lookup key for the IXpsOMGeometry interface in a resource dictionary that contains the visual's clipping region. If a lookup key for the clip geometry has not been set, or if a local clip geometry has been set, a <c>NULL</c> pointer is returned.</para>
			/// <list type="table">
			/// <listheader>
			/// <term>Most recent method called</term>
			/// <term>Lookup key string that is returned in key</term>
			/// </listheader>
			/// <item>
			/// <term>SetClipGeometryLocal</term>
			/// <term>NULL pointer.</term>
			/// </item>
			/// <item>
			/// <term>SetClipGeometryLookup</term>
			/// <term>The lookup key that is set by SetClipGeometryLookup.</term>
			/// </item>
			/// <item>
			/// <term>Neither SetClipGeometryLocal nor SetClipGeometryLookup has been called yet.</term>
			/// <term>NULL pointer.</term>
			/// </item>
			/// </list>
			/// </returns>
			// https://docs.microsoft.com/en-us/windows/win32/api/xpsobjectmodel/nf-xpsobjectmodel-ixpsomvisual-getclipgeometrylookup
			// HRESULT GetClipGeometryLookup( LPWSTR *key );
			[MethodImpl(MethodImplOptions.InternalCall)]
			new SafeCoTaskMemString GetClipGeometryLookup();

			/// <summary>Sets the lookup key name of a shared clip geometry in a resource dictionary.</summary>
			/// <param name="key">The lookup key name of the clip geometry in the dictionary. A <c>NULL</c> pointer clears the previously assigned key name.</param>
			/// <remarks>
			/// <para>After you call <c>SetClipGeometryLookup</c>, the local clip geometry is released and GetClipGeometryLocal returns a <c>NULL</c> pointer in the clipGeometry parameter. The table that follows explains the relationship between the local and lookup values of this property.</para>
			/// <list type="table">
			/// <listheader>
			/// <term>Most recent method called</term>
			/// <term>Object that is returned in clipGeometry by GetClipGeometry</term>
			/// <term>Object that is returned in clipGeometry by GetClipGeometryLocal</term>
			/// <term>String that is returned in key by GetClipGeometryLookup</term>
			/// </listheader>
			/// <item>
			/// <term>SetClipGeometryLocal</term>
			/// <term>The local clip geometry that is set by SetClipGeometryLocal.</term>
			/// <term>The local clip geometry that is set by SetClipGeometryLocal.</term>
			/// <term>NULL pointer.</term>
			/// </item>
			/// <item>
			/// <term>SetClipGeometryLookup (this method)</term>
			/// <term>The shared clip geometry that gets retrieved, with a lookup key that matches the key that is set by SetClipGeometryLookup, from the resource directory.</term>
			/// <term>NULL pointer.</term>
			/// <term>The lookup key that is set by SetClipGeometryLookup.</term>
			/// </item>
			/// <item>
			/// <term>Neither SetClipGeometryLookup nor SetClipGeometryLocal has been called yet.</term>
			/// <term>NULL pointer.</term>
			/// <term>NULL pointer.</term>
			/// <term>NULL pointer.</term>
			/// </item>
			/// </list>
			/// </remarks>
			// https://docs.microsoft.com/en-us/windows/win32/api/xpsobjectmodel/nf-xpsobjectmodel-ixpsomvisual-setclipgeometrylookup
			// HRESULT SetClipGeometryLookup( LPCWSTR key );
			[MethodImpl(MethodImplOptions.InternalCall)]
			new void SetClipGeometryLookup([In, MarshalAs(UnmanagedType.LPWStr)] string key);

			/// <summary>Gets the opacity value of this visual.</summary>
			/// <returns>The opacity value.</returns>
			// https://docs.microsoft.com/en-us/windows/win32/api/xpsobjectmodel/nf-xpsobjectmodel-ixpsomvisual-getopacity
			// HRESULT GetOpacity( FLOAT *opacity );
			[MethodImpl(MethodImplOptions.InternalCall)]
			new float GetOpacity();

			/// <summary>Sets the opacity value of the visual.</summary>
			/// <param name="opacity">
			/// <para>The opacity value to be set for the visual.</para>
			/// <para>The range of allowed values for this parameter is 0.0 to 1.0; with 0.0 the visual is completely transparent, and with 1.0 it is completely opaque.</para>
			/// </param>
			// https://docs.microsoft.com/en-us/windows/win32/api/xpsobjectmodel/nf-xpsobjectmodel-ixpsomvisual-setopacity
			// HRESULT SetOpacity( FLOAT opacity );
			[MethodImpl(MethodImplOptions.InternalCall)]
			new void SetOpacity([In] float opacity);

			/// <summary>Gets a pointer to the IXpsOMBrush interface of the visual's opacity mask brush.</summary>
			/// <returns>
			/// <para>A pointer to the IXpsOMBrush interface of the visual's opacity mask brush. If an opacity mask brush has not been set for this visual, a <c>NULL</c> pointer is returned.</para>
			/// <para>The value that is returned in this parameter depends on which method has most recently been called to set the brush.</para>
			/// <list type="table">
			/// <listheader>
			/// <term>Most recent method called</term>
			/// <term>Object that is returned in opacityMaskBrush</term>
			/// </listheader>
			/// <item>
			/// <term>SetOpacityMaskBrushLocal</term>
			/// <term>The local opacity mask brush that is set by SetOpacityMaskBrushLocal.</term>
			/// </item>
			/// <item>
			/// <term>SetOpacityMaskBrushLookup</term>
			/// <term>The shared opacity mask brush that gets retrieved, with a lookup key that matches the key that is set by SetOpacityMaskBrushLookup, from the resource directory.</term>
			/// </item>
			/// <item>
			/// <term>Neither SetOpacityMaskBrushLocal nor SetOpacityMaskBrushLookup has been called yet.</term>
			/// <term>NULL pointer.</term>
			/// </item>
			/// </list>
			/// </returns>
			// https://docs.microsoft.com/en-us/windows/win32/api/xpsobjectmodel/nf-xpsobjectmodel-ixpsomvisual-getopacitymaskbrush
			// HRESULT GetOpacityMaskBrush( IXpsOMBrush **opacityMaskBrush );
			[MethodImpl(MethodImplOptions.InternalCall)]
			new IXpsOMBrush GetOpacityMaskBrush();

			/// <summary>Gets the local, unshared opacity mask brush for the visual.</summary>
			/// <returns>
			/// <para>A pointer to the IXpsOMBrush interface of the visual's opacity mask brush. If an opacity mask brush lookup key has been set, or if a local opacity mask brush has not been set, a <c>NULL</c> pointer is returned.</para>
			/// <list type="table">
			/// <listheader>
			/// <term>Most recent method called</term>
			/// <term>Object that is returned in opacityMaskBrush</term>
			/// </listheader>
			/// <item>
			/// <term>SetOpacityMaskBrushLocal</term>
			/// <term>The local opacity mask brush that is set by SetOpacityMaskBrushLocal.</term>
			/// </item>
			/// <item>
			/// <term>SetOpacityMaskBrushLookup</term>
			/// <term>NULL pointer.</term>
			/// </item>
			/// <item>
			/// <term>Neither SetOpacityMaskBrushLocal nor SetOpacityMaskBrushLookup has been called yet.</term>
			/// <term>NULL pointer.</term>
			/// </item>
			/// </list>
			/// </returns>
			// https://docs.microsoft.com/en-us/windows/win32/api/xpsobjectmodel/nf-xpsobjectmodel-ixpsomvisual-getopacitymaskbrushlocal
			// HRESULT GetOpacityMaskBrushLocal( IXpsOMBrush **opacityMaskBrush );
			[MethodImpl(MethodImplOptions.InternalCall)]
			new IXpsOMBrush GetOpacityMaskBrushLocal();

			/// <summary>
			/// Sets the IXpsOMBrush interface pointer as the local, unshared opacity mask brush.
			/// </summary>
			/// <param name="opacityMaskBrush">A pointer to the IXpsOMBrush interface to be set as the local, unshared opacity mask brush. A <c>NULL</c> pointer clears the previously assigned opacity mask brush.</param>
			/// <remarks>
			/// <para>After you call <c>SetOpacityMaskBrushLocal</c>, the opacity mask brush lookup key is released and GetOpacityMaskBrushLookup returns a <c>NULL</c> pointer in the key parameter. The table that follows explains the relationship between the local and lookup values of this property.</para>
			/// <list type="table">
			///   <listheader>
			///     <term>Most recent method called</term>
			///     <term>Object that is returned in opacityMaskBrush by GetOpacityMaskBrush</term>
			///     <term>Object that is returned in opacityMaskBrush by GetOpacityMaskBrushLocal</term>
			///     <term>String that is returned in key by GetOpacityMaskBrushLookup</term>
			///   </listheader>
			///   <item>
			///     <term>SetOpacityMaskBrushLocal (this method)</term>
			///     <term>The local opacity mask brush that is set by SetOpacityMaskBrushLocal.</term>
			///     <term>The local opacity mask brush that is set by SetOpacityMaskBrushLocal.</term>
			///     <term>NULL pointer.</term>
			///   </item>
			///   <item>
			///     <term>SetOpacityMaskBrushLookup</term>
			///     <term>The shared opacity mask brush that gets retrieved, with a lookup key that matches the key that is set by SetOpacityMaskBrushLookup, from the resource directory.</term>
			///     <term>NULL pointer.</term>
			///     <term>The lookup key that is set by SetOpacityMaskBrushLookup.</term>
			///   </item>
			///   <item>
			///     <term>Neither SetOpacityMaskBrushLocal nor SetOpacityMaskBrushLookup has been called yet.</term>
			///     <term>NULL pointer.</term>
			///     <term>NULL pointer.</term>
			///     <term>NULL pointer.</term>
			///   </item>
			/// </list>
			/// </remarks>
			// https://docs.microsoft.com/en-us/windows/win32/api/xpsobjectmodel/nf-xpsobjectmodel-ixpsomvisual-setopacitymaskbrushlocal
			// HRESULT SetOpacityMaskBrushLocal( IXpsOMBrush *opacityMaskBrush );
			[MethodImpl(MethodImplOptions.InternalCall)]
			new void SetOpacityMaskBrushLocal([In] IXpsOMBrush opacityMaskBrush);

			/// <summary>Gets the name of the lookup key of the shared opacity mask brush in a resource dictionary.</summary>
			/// <returns>
			/// <para>The name of the lookup key of the shared opacity mask brush in a resource dictionary. If the lookup key of an opacity mask brush has not been set, or if a local opacity mask brush has been set, a <c>NULL</c> pointer is returned.</para>
			/// <list type="table">
			/// <listheader>
			/// <term>Most recent method called</term>
			/// <term>Object that is returned in key</term>
			/// </listheader>
			/// <item>
			/// <term>SetOpacityMaskBrushLocal</term>
			/// <term>NULL pointer.</term>
			/// </item>
			/// <item>
			/// <term>SetOpacityMaskBrushLookup</term>
			/// <term>The lookup key that is set by SetOpacityMaskBrushLookup.</term>
			/// </item>
			/// <item>
			/// <term>Neither SetOpacityMaskBrushLocal nor SetOpacityMaskBrushLookup has been called yet.</term>
			/// <term>NULL pointer.</term>
			/// </item>
			/// </list>
			/// </returns>
			// https://docs.microsoft.com/en-us/windows/win32/api/xpsobjectmodel/nf-xpsobjectmodel-ixpsomvisual-getopacitymaskbrushlookup
			// HRESULT GetOpacityMaskBrushLookup( LPWSTR *key );
			[MethodImpl(MethodImplOptions.InternalCall)]
			new SafeCoTaskMemString GetOpacityMaskBrushLookup();

			/// <summary>
			/// Sets the lookup key name of a shared opacity mask brush in a resource dictionary.
			/// </summary>
			/// <param name="key">The lookup key name of the opacity mask brush in the dictionary. A <c>NULL</c> pointer clears the previously assigned key name.</param>
			/// <remarks>
			/// <para>After you call <c>SetOpacityMaskBrushLookup</c>, the local opacity mask brush is released and GetOpacityMaskBrushLocal returns a <c>NULL</c> pointer in the opacityMaskBrush parameter. The table that follows explains the relationship between the local and lookup values of this property.</para>
			/// <list type="table">
			///   <listheader>
			///     <term>Most recent method called</term>
			///     <term>Object that is returned in opacityMaskBrush by GetOpacityMaskBrush</term>
			///     <term>Object that is returned in opacityMaskBrush by GetOpacityMaskBrushLocal</term>
			///     <term>String that is returned in key by GetOpacityMaskBrushLookup</term>
			///   </listheader>
			///   <item>
			///     <term>SetOpacityMaskBrushLocal</term>
			///     <term>The local opacity mask brush that is set by SetOpacityMaskBrushLocal.</term>
			///     <term>The local opacity mask brush that is set by SetOpacityMaskBrushLocal.</term>
			///     <term>NULL pointer.</term>
			///   </item>
			///   <item>
			///     <term>SetOpacityMaskBrushLookup (this method)</term>
			///     <term>The shared opacity mask brush that gets retrieved—with a lookup key that matches the key that is set by SetOpacityMaskBrushLookup—from the resource directory.</term>
			///     <term>NULL pointer.</term>
			///     <term>The lookup key that is set by SetOpacityMaskBrushLookup.</term>
			///   </item>
			///   <item>
			///     <term>Neither SetOpacityMaskBrushLocal nor SetOpacityMaskBrushLookup has been called yet.</term>
			///     <term>NULL pointer.</term>
			///     <term>NULL pointer.</term>
			///     <term>NULL pointer.</term>
			///   </item>
			/// </list>
			/// </remarks>
			// https://docs.microsoft.com/en-us/windows/win32/api/xpsobjectmodel/nf-xpsobjectmodel-ixpsomvisual-setopacitymaskbrushlookup
			// HRESULT SetOpacityMaskBrushLookup( LPCWSTR key );
			[MethodImpl(MethodImplOptions.InternalCall)]
			new void SetOpacityMaskBrushLookup([In, MarshalAs(UnmanagedType.LPWStr)] string key);

			/// <summary>Gets the <c>Name</c> property of the visual.</summary>
			/// <returns>The <c>Name</c> property string. If the <c>Name</c> property has not been set, a <c>NULL</c> pointer is returned.</returns>
			// https://docs.microsoft.com/en-us/windows/win32/api/xpsobjectmodel/nf-xpsobjectmodel-ixpsomvisual-getname
			// HRESULT GetName( LPWSTR *name );
			[MethodImpl(MethodImplOptions.InternalCall)]
			new SafeCoTaskMemString GetName();

			/// <summary>
			/// Sets the <c>Name</c> property of the visual.
			/// </summary>
			/// <param name="name">The name of the visual. A <c>NULL</c> pointer clears the <c>Name</c> property.</param>
			/// <remarks>
			/// <para>Names must be unique.</para>
			/// <para>Clearing the <c>Name</c> property by passing a <c>NULL</c> pointer in name sets the <c>IsHyperlinkTarget</c> property to <c>FALSE</c>.</para>
			/// </remarks>
			// https://docs.microsoft.com/en-us/windows/win32/api/xpsobjectmodel/nf-xpsobjectmodel-ixpsomvisual-setname
			// HRESULT SetName( LPCWSTR name );
			[MethodImpl(MethodImplOptions.InternalCall)]
			new void SetName([In, MarshalAs(UnmanagedType.LPWStr)] string name);

			/// <summary>Gets a value that indicates whether the visual is the target of a hyperlink.</summary>
			/// <returns>
			/// <para>The Boolean value that indicates whether the visual is the target of a hyperlink.</para>
			/// <list type="table">
			/// <listheader>
			/// <term>Value</term>
			/// <term>Meaning</term>
			/// </listheader>
			/// <item>
			/// <term>TRUE</term>
			/// <term>The visual is the target of a hyperlink.</term>
			/// </item>
			/// <item>
			/// <term>FALSE</term>
			/// <term>The visual is not the target of a hyperlink.</term>
			/// </item>
			/// </list>
			/// </returns>
			// https://docs.microsoft.com/en-us/windows/win32/api/xpsobjectmodel/nf-xpsobjectmodel-ixpsomvisual-getishyperlinktarget
			// HRESULT GetIsHyperlinkTarget( BOOL *isHyperlink );
			[MethodImpl(MethodImplOptions.InternalCall)]
			[return: MarshalAs(UnmanagedType.Bool)]
			new bool GetIsHyperlinkTarget();

			/// <summary>
			/// Specifies whether the visual is the target of a hyperlink.
			/// </summary>
			/// <param name="isHyperlink"><para>The Boolean value that specifies whether the visual is the target of a hyperlink.</para>
			/// <list type="table">
			///   <listheader>
			///     <term>Value</term>
			///     <term>Meaning</term>
			///   </listheader>
			///   <item>
			///     <term>TRUE</term>
			///     <term>The visual is the target of a hyperlink.</term>
			///   </item>
			///   <item>
			///     <term>FALSE</term>
			///     <term>The visual is not the target of a hyperlink.</term>
			///   </item>
			/// </list></param>
			/// <remarks>
			/// The visual must be named before it can be set as the target of a hyperlink.
			/// </remarks>
			// https://docs.microsoft.com/en-us/windows/win32/api/xpsobjectmodel/nf-xpsobjectmodel-ixpsomvisual-setishyperlinktarget
			// HRESULT SetIsHyperlinkTarget( BOOL isHyperlink );
			[MethodImpl(MethodImplOptions.InternalCall)]
			new void SetIsHyperlinkTarget([In, MarshalAs(UnmanagedType.Bool)] bool isHyperlink);

			/// <summary>Gets a pointer to the IUri interface to which this visual object links.</summary>
			/// <returns>A pointer to the IUri interface that contains the destination URI for the link. If a URI has not been set for this object, a <c>NULL</c> pointer is returned.</returns>
			// https://docs.microsoft.com/en-us/windows/win32/api/xpsobjectmodel/nf-xpsobjectmodel-ixpsomvisual-gethyperlinknavigateuri
			// HRESULT GetHyperlinkNavigateUri( IUri **hyperlinkUri );
			[MethodImpl(MethodImplOptions.InternalCall)]
			new IUri GetHyperlinkNavigateUri();

			/// <summary>
			/// Sets the destination URI of the visual's hyperlink.
			/// </summary>
			/// <param name="hyperlinkUri">The IUri interface that contains the destination URI of the visual's hyperlink.</param>
			/// <remarks>
			/// Setting an object's URI makes the object a hyperlink. When activated or clicked, the object will navigate to the destination that is specified by the URI in hyperlinkUri.
			/// </remarks>
			// https://docs.microsoft.com/en-us/windows/win32/api/xpsobjectmodel/nf-xpsobjectmodel-ixpsomvisual-sethyperlinknavigateuri
			// HRESULT SetHyperlinkNavigateUri( IUri *hyperlinkUri );
			[MethodImpl(MethodImplOptions.InternalCall)]
			new void SetHyperlinkNavigateUri([In] IUri hyperlinkUri);

			/// <summary>Gets the <c>Language</c> property of the visual and of its contents.</summary>
			/// <returns>The language string that specifies the language of the page. If a language has not been set, a <c>NULL</c> pointer is returned.</returns>
			/// <remarks>
			/// <para>The <c>Language</c> property that is set by this method specifies the language of the resource content.</para>
			/// <para>Internet Engineering Task Force (IETF) RFC 3066 specifies the recommended encoding for the <c>Language</c> property.</para>
			/// </remarks>
			// https://docs.microsoft.com/en-us/windows/win32/api/xpsobjectmodel/nf-xpsobjectmodel-ixpsomvisual-getlanguage
			// HRESULT GetLanguage( LPWSTR *language );
			[MethodImpl(MethodImplOptions.InternalCall)]
			new SafeCoTaskMemString GetLanguage();

			/// <summary>
			/// Sets the <c>Language</c> property of the visual.
			/// </summary>
			/// <param name="language">The language string that specifies the language of the visual and of its contents. A <c>NULL</c> pointer clears the <c>Language</c> property.</param>
			/// <remarks>
			/// The recommended encoding for the <c>Language</c> property is specified in Internet Engineering Task Force (IETF) RFC 3066r.
			/// </remarks>
			// https://docs.microsoft.com/en-us/windows/win32/api/xpsobjectmodel/nf-xpsobjectmodel-ixpsomvisual-setlanguage
			// HRESULT SetLanguage( LPCWSTR language );
			[MethodImpl(MethodImplOptions.InternalCall)]
			new void SetLanguage([In, MarshalAs(UnmanagedType.LPWStr)] string language);

			IXpsOMPath Clone();

			SafeCoTaskMemString GetAccessibilityLongDescription();

			SafeCoTaskMemString GetAccessibilityShortDescription();

			IXpsOMBrush GetFillBrush();

			IXpsOMBrush GetFillBrushLocal();

			SafeCoTaskMemString GetFillBrushLookup();

			IXpsOMGeometry GetGeometry();

			IXpsOMGeometry GetGeometryLocal();

			SafeCoTaskMemString GetGeometryLookup();

			int GetSnapsToPixels();

			IXpsOMBrush GetStrokeBrush();

			IXpsOMBrush GetStrokeBrushLocal();

			SafeCoTaskMemString GetStrokeBrushLookup();

			XPS_DASH_CAP GetStrokeDashCap();

			IXpsOMDashCollection GetStrokeDashes();

			float GetStrokeDashOffset();

			XPS_LINE_CAP GetStrokeEndLineCap();

			XPS_LINE_JOIN GetStrokeLineJoin();

			float GetStrokeMiterLimit();

			XPS_LINE_CAP GetStrokeStartLineCap();

			float GetStrokeThickness();

			void SetAccessibilityLongDescription([In, MarshalAs(UnmanagedType.LPWStr)] string longDescription);

			void SetAccessibilityShortDescription([In, MarshalAs(UnmanagedType.LPWStr)] string shortDescription);

			void SetFillBrushLocal([In] IXpsOMBrush brush);

			void SetFillBrushLookup([In, MarshalAs(UnmanagedType.LPWStr)] string lookup);

			void SetGeometryLocal([In] IXpsOMGeometry geometry);

			void SetGeometryLookup([In, MarshalAs(UnmanagedType.LPWStr)] string lookup);

			void SetSnapsToPixels([In] int snapsToPixels);

			void SetStrokeBrushLocal([In] IXpsOMBrush brush);

			void SetStrokeBrushLookup([In, MarshalAs(UnmanagedType.LPWStr)] string lookup);

			void SetStrokeDashCap([In] XPS_DASH_CAP strokeDashCap);

			void SetStrokeDashOffset([In] float strokeDashOffset);

			void SetStrokeEndLineCap([In] XPS_LINE_CAP strokeEndLineCap);

			void SetStrokeLineJoin([In] XPS_LINE_JOIN strokeLineJoin);

			void SetStrokeMiterLimit([In] float strokeMiterLimit);

			void SetStrokeStartLineCap([In] XPS_LINE_CAP strokeStartLineCap);

			void SetStrokeThickness([In] float strokeThickness);
		}

		[ComImport, Guid("E7FF32D2-34AA-499B-BBE9-9CD4EE6C59F7"), InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
		public interface IXpsOMPrintTicketResource : IXpsOMResource
		{
			/// <summary>Gets the name that will be used when the part is serialized.</summary>
			/// <returns>
			/// A pointer to the IOpcPartUri interface that contains the part name. If the part name has not been set (by the SetPartName
			/// method), a <c>NULL</c> pointer is returned.
			/// </returns>
			// https://docs.microsoft.com/en-us/windows/win32/api/xpsobjectmodel/nf-xpsobjectmodel-ixpsompart-getpartname HRESULT
			// GetPartName( IOpcPartUri **partUri );
			[MethodImpl(MethodImplOptions.InternalCall)]
			new IOpcPartUri GetPartName();

			/// <summary>Sets the name that will be used when the part is serialized.</summary>
			/// <param name="partUri">
			/// A pointer to the IOpcPartUri interface that contains the name of this part. This parameter cannot be <c>NULL</c>.
			/// </param>
			/// <remarks>
			/// IXpsOMPackageWriter will generate an error if it encounters an XPS document part whose name is the same as that of a part it
			/// has previously serialized.
			/// </remarks>
			// https://docs.microsoft.com/en-us/windows/win32/api/xpsobjectmodel/nf-xpsobjectmodel-ixpsompart-setpartname HRESULT
			// SetPartName( IOpcPartUri *partUri );
			[MethodImpl(MethodImplOptions.InternalCall)]
			new void SetPartName([In] IOpcPartUri partUri);

			[MethodImpl(MethodImplOptions.InternalCall)]
			[return: MarshalAs(UnmanagedType.Interface)]
			IStream GetStream();

			[MethodImpl(MethodImplOptions.InternalCall)]
			void SetContent([MarshalAs(UnmanagedType.Interface)] [In] IStream sourceStream, [In] IOpcPartUri partName);
		}

		[ComImport, Guid("75F207E5-08BF-413C-96B1-B82B4064176B"), InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
		public interface IXpsOMRadialGradientBrush : IXpsOMGradientBrush
		{
			IXpsOMRadialGradientBrush Clone();

			XPS_POINT GetCenter();

			XPS_POINT GetGradientOrigin();

			XPS_SIZE GetRadiiSizes();

			void SetCenter(in XPS_POINT center);

			void SetGradientOrigin(in XPS_POINT origin);

			void SetRadiiSizes(in XPS_SIZE radiiSizes);
		}

		[ComImport, Guid("C9BD7CD4-E16A-4BF8-8C84-C950AF7A3061"), InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
		public interface IXpsOMRemoteDictionaryResource : IXpsOMResource
		{
			/// <summary>Gets the name that will be used when the part is serialized.</summary>
			/// <returns>
			/// A pointer to the IOpcPartUri interface that contains the part name. If the part name has not been set (by the SetPartName
			/// method), a <c>NULL</c> pointer is returned.
			/// </returns>
			// https://docs.microsoft.com/en-us/windows/win32/api/xpsobjectmodel/nf-xpsobjectmodel-ixpsompart-getpartname HRESULT
			// GetPartName( IOpcPartUri **partUri );
			[MethodImpl(MethodImplOptions.InternalCall)]
			new IOpcPartUri GetPartName();

			/// <summary>Sets the name that will be used when the part is serialized.</summary>
			/// <param name="partUri">
			/// A pointer to the IOpcPartUri interface that contains the name of this part. This parameter cannot be <c>NULL</c>.
			/// </param>
			/// <remarks>
			/// IXpsOMPackageWriter will generate an error if it encounters an XPS document part whose name is the same as that of a part it
			/// has previously serialized.
			/// </remarks>
			// https://docs.microsoft.com/en-us/windows/win32/api/xpsobjectmodel/nf-xpsobjectmodel-ixpsompart-setpartname HRESULT
			// SetPartName( IOpcPartUri *partUri );
			[MethodImpl(MethodImplOptions.InternalCall)]
			new void SetPartName([In] IOpcPartUri partUri);

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

		/// <summary>Used as the base interface for the resource interfaces of the XPS object model.</summary>
		// https://docs.microsoft.com/en-us/windows/win32/api/xpsobjectmodel/nn-xpsobjectmodel-ixpsomresource
		[PInvokeData("xpsobjectmodel.h", MSDNShortId = "ed3d6ea0-efe5-4917-85fa-bd9ad1978b4e")]
		[ComImport, Guid("DA2AC0A2-73A2-4975-AD14-74097C3FF3A5"), InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
		public interface IXpsOMResource : IXpsOMPart
		{
			/// <summary>Gets the name that will be used when the part is serialized.</summary>
			/// <returns>
			/// A pointer to the IOpcPartUri interface that contains the part name. If the part name has not been set (by the SetPartName
			/// method), a <c>NULL</c> pointer is returned.
			/// </returns>
			// https://docs.microsoft.com/en-us/windows/win32/api/xpsobjectmodel/nf-xpsobjectmodel-ixpsompart-getpartname HRESULT
			// GetPartName( IOpcPartUri **partUri );
			[MethodImpl(MethodImplOptions.InternalCall)]
			new IOpcPartUri GetPartName();

			/// <summary>Sets the name that will be used when the part is serialized.</summary>
			/// <param name="partUri">
			/// A pointer to the IOpcPartUri interface that contains the name of this part. This parameter cannot be <c>NULL</c>.
			/// </param>
			/// <remarks>
			/// IXpsOMPackageWriter will generate an error if it encounters an XPS document part whose name is the same as that of a part it
			/// has previously serialized.
			/// </remarks>
			// https://docs.microsoft.com/en-us/windows/win32/api/xpsobjectmodel/nf-xpsobjectmodel-ixpsompart-setpartname HRESULT
			// SetPartName( IOpcPartUri *partUri );
			[MethodImpl(MethodImplOptions.InternalCall)]
			new void SetPartName([In] IOpcPartUri partUri);
		}

		/// <summary>The base interface for sharable interfaces.</summary>
		// https://docs.microsoft.com/en-us/windows/win32/api/xpsobjectmodel/nn-xpsobjectmodel-ixpsomshareable
		[PInvokeData("xpsobjectmodel.h", MSDNShortId = "2071292f-b898-4ec8-99f7-294c8d820965")]
		[ComImport, Guid("7137398F-2FC1-454D-8C6A-2C3115A16ECE"), InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
		public interface IXpsOMShareable
		{
			/// <summary>Gets the <c>IUnknown</c> interface of the parent.</summary>
			/// <returns>A pointer to the <c>IUnknown</c> interface of the parent.</returns>
			// https://docs.microsoft.com/en-us/windows/win32/api/xpsobjectmodel/nf-xpsobjectmodel-ixpsomshareable-getowner
			// HRESULT GetOwner( IUnknown **owner );
			[return: MarshalAs(UnmanagedType.IUnknown)]
			object GetOwner();

			/// <summary>Gets the object type of the interface.</summary>
			/// <returns>The XPS_OBJECT_TYPE value that describes the interface that is derived from IXpsOMShareable.</returns>
			// https://docs.microsoft.com/en-us/windows/win32/api/xpsobjectmodel/nf-xpsobjectmodel-ixpsomshareable-gettype
			// HRESULT GetType( XPS_OBJECT_TYPE *type );
			XPS_OBJECT_TYPE GetType();
		}

		[ComImport, Guid("4776AD35-2E04-4357-8743-EBF6C171A905"), InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
		public interface IXpsOMSignatureBlockResource : IXpsOMResource
		{
			/// <summary>Gets the name that will be used when the part is serialized.</summary>
			/// <returns>
			/// A pointer to the IOpcPartUri interface that contains the part name. If the part name has not been set (by the SetPartName
			/// method), a <c>NULL</c> pointer is returned.
			/// </returns>
			// https://docs.microsoft.com/en-us/windows/win32/api/xpsobjectmodel/nf-xpsobjectmodel-ixpsompart-getpartname HRESULT
			// GetPartName( IOpcPartUri **partUri );
			[MethodImpl(MethodImplOptions.InternalCall)]
			new IOpcPartUri GetPartName();

			/// <summary>Sets the name that will be used when the part is serialized.</summary>
			/// <param name="partUri">
			/// A pointer to the IOpcPartUri interface that contains the name of this part. This parameter cannot be <c>NULL</c>.
			/// </param>
			/// <remarks>
			/// IXpsOMPackageWriter will generate an error if it encounters an XPS document part whose name is the same as that of a part it
			/// has previously serialized.
			/// </remarks>
			// https://docs.microsoft.com/en-us/windows/win32/api/xpsobjectmodel/nf-xpsobjectmodel-ixpsompart-setpartname HRESULT
			// SetPartName( IOpcPartUri *partUri );
			[MethodImpl(MethodImplOptions.InternalCall)]
			new void SetPartName([In] IOpcPartUri partUri);

			[MethodImpl(MethodImplOptions.InternalCall)]
			[return: MarshalAs(UnmanagedType.Interface)]
			IXpsOMDocument GetOwner();

			[MethodImpl(MethodImplOptions.InternalCall)]
			[return: MarshalAs(UnmanagedType.Interface)]
			IStream GetStream();

			[MethodImpl(MethodImplOptions.InternalCall)]
			void SetContent([MarshalAs(UnmanagedType.Interface)] [In] IStream sourceStream, [In] IOpcPartUri partName);
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
			/// <summary>Gets the <c>IUnknown</c> interface of the parent.</summary>
			/// <returns>A pointer to the <c>IUnknown</c> interface of the parent.</returns>
			// https://docs.microsoft.com/en-us/windows/win32/api/xpsobjectmodel/nf-xpsobjectmodel-ixpsomshareable-getowner
			// HRESULT GetOwner( IUnknown **owner );
			[return: MarshalAs(UnmanagedType.IUnknown)]
			new object GetOwner();

			/// <summary>Gets the object type of the interface.</summary>
			/// <returns>The XPS_OBJECT_TYPE value that describes the interface that is derived from IXpsOMShareable.</returns>
			// https://docs.microsoft.com/en-us/windows/win32/api/xpsobjectmodel/nf-xpsobjectmodel-ixpsomshareable-gettype
			// HRESULT GetType( XPS_OBJECT_TYPE *type );
			new XPS_OBJECT_TYPE GetType();

			/// <summary>Gets the opacity of the brush.</summary>
			/// <returns>
			/// The opacity value of the brush.
			/// </returns>
			/// <remarks>opacity is expressed as a value between 0.0 and 1.0; 0.0 indicates that the brush is completely transparent, 0.5 that it is 50 percent opaque, and 1.0 that it is completely opaque.</remarks>
			// https://docs.microsoft.com/en-us/windows/win32/api/xpsobjectmodel/nf-xpsobjectmodel-ixpsombrush-getopacity
			// HRESULT GetOpacity( FLOAT *opacity );
			new float GetOpacity();

			/// <summary>Sets the opacity of the brush.</summary>
			/// <param name="opacity">The opacity value of the brush.</param>
			/// <remarks>
			/// <para>opacity is expressed as a value between 0.0 and 1.0; 0.0 indicates that the brush is completely transparent, 0.5 that it is 50 percent opaque, and 1.0 that it is completely opaque.</para>
			/// <para>If opacity is less than 0.0 or greater than 1.0, the method returns an error.</para>
			/// </remarks>
			// https://docs.microsoft.com/en-us/windows/win32/api/xpsobjectmodel/nf-xpsobjectmodel-ixpsombrush-setopacity
			// HRESULT SetOpacity( FLOAT opacity );
			new void SetOpacity([In] float opacity);

			IXpsOMSolidColorBrush Clone();

			IXpsOMColorProfileResource GetColor( out XPS_COLOR color);

			void SetColor(in XPS_COLOR color, [In] IXpsOMColorProfileResource colorProfile);
		}

		[ComImport, Guid("C2B3CA09-0473-4282-87AE-1780863223F0"), InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
		public interface IXpsOMStoryFragmentsResource : IXpsOMResource
		{
			/// <summary>Gets the name that will be used when the part is serialized.</summary>
			/// <returns>
			/// A pointer to the IOpcPartUri interface that contains the part name. If the part name has not been set (by the SetPartName
			/// method), a <c>NULL</c> pointer is returned.
			/// </returns>
			// https://docs.microsoft.com/en-us/windows/win32/api/xpsobjectmodel/nf-xpsobjectmodel-ixpsompart-getpartname HRESULT
			// GetPartName( IOpcPartUri **partUri );
			[MethodImpl(MethodImplOptions.InternalCall)]
			new IOpcPartUri GetPartName();

			/// <summary>Sets the name that will be used when the part is serialized.</summary>
			/// <param name="partUri">
			/// A pointer to the IOpcPartUri interface that contains the name of this part. This parameter cannot be <c>NULL</c>.
			/// </param>
			/// <remarks>
			/// IXpsOMPackageWriter will generate an error if it encounters an XPS document part whose name is the same as that of a part it
			/// has previously serialized.
			/// </remarks>
			// https://docs.microsoft.com/en-us/windows/win32/api/xpsobjectmodel/nf-xpsobjectmodel-ixpsompart-setpartname HRESULT
			// SetPartName( IOpcPartUri *partUri );
			[MethodImpl(MethodImplOptions.InternalCall)]
			new void SetPartName([In] IOpcPartUri partUri);

			[MethodImpl(MethodImplOptions.InternalCall)]
			[return: MarshalAs(UnmanagedType.Interface)]
			IXpsOMPageReference GetOwner();

			[MethodImpl(MethodImplOptions.InternalCall)]
			[return: MarshalAs(UnmanagedType.Interface)]
			IStream GetStream();

			[MethodImpl(MethodImplOptions.InternalCall)]
			void SetContent([MarshalAs(UnmanagedType.Interface)] [In] IStream sourceStream, [In] IOpcPartUri partName);
		}

		[ComImport, Guid("15B873D5-1971-41E8-83A3-6578403064C7"), InterfaceType(ComInterfaceType.InterfaceIsIUnknown), CoClass(typeof(XpsOMThumbnailGenerator))]
		public interface IXpsOMThumbnailGenerator
		{
			IXpsOMImageResource GenerateThumbnail([In] IXpsOMPage page, [In] XPS_IMAGE_TYPE thumbnailType, [In] XPS_THUMBNAIL_SIZE thumbnailSize, [In] IOpcPartUri imageResourcePartName);
		}

		/// <summary>
		/// <para>A tile brush uses a visual image to paint a region by repeating the image.</para>
		/// <para>This is the base interface of IXpsOMImageBrush and IXpsOMVisualBrush.</para>
		/// </summary>
		/// <remarks>
		/// <para>As shown in the illustration that follows, the tile brush takes a visual element, or a part of it, transforms the visual element to create a tile, places the tile in the viewport of the output area, and fills the output area as specified by the tile mode.</para>
		/// <para>In the preceding illustration, the viewport is the area covered by the first tile in the output area. The viewport image is repeated throughout the output area as specified by the tile mode. The transform property determines how the output area is transformed after the viewport has been tiled in the output area. The part of the output area that is ultimately rendered as a visible image is determined by the path, stroke, or glyph that is using the tile brush.</para>
		/// <para>A viewbox describes the portion of the source image that is used for the brush. The viewbox in the preceding illustration has the same size as the source image, so all of the source image is used for the brush. A viewbox can also be smaller than the original image.</para>
		/// <para>In the illustration that follows, the brush is created by using a viewbox that includes only a portion of the original image or visual.</para>
		/// <para>The next illustration shows the tile modes that are used to repeat the tile image to fill the output area. If the tile mode value is XPS_TILE_MODE_NONE, the tile image is drawn only once.</para>
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows/win32/api/xpsobjectmodel/nn-xpsobjectmodel-ixpsomtilebrush
		[PInvokeData("xpsobjectmodel.h", MSDNShortId = "fc9e1925-0dbc-447b-9acc-e7f719df62d1")]
		[ComImport, Guid("0FC2328D-D722-4A54-B2EC-BE90218A789E"), InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
		public interface IXpsOMTileBrush : IXpsOMBrush
		{
			/// <summary>Gets the <c>IUnknown</c> interface of the parent.</summary>
			/// <returns>A pointer to the <c>IUnknown</c> interface of the parent.</returns>
			// https://docs.microsoft.com/en-us/windows/win32/api/xpsobjectmodel/nf-xpsobjectmodel-ixpsomshareable-getowner
			// HRESULT GetOwner( IUnknown **owner );
			[return: MarshalAs(UnmanagedType.IUnknown)]
			new object GetOwner();

			/// <summary>Gets the object type of the interface.</summary>
			/// <returns>The XPS_OBJECT_TYPE value that describes the interface that is derived from IXpsOMShareable.</returns>
			// https://docs.microsoft.com/en-us/windows/win32/api/xpsobjectmodel/nf-xpsobjectmodel-ixpsomshareable-gettype
			// HRESULT GetType( XPS_OBJECT_TYPE *type );
			new XPS_OBJECT_TYPE GetType();

			/// <summary>Gets the opacity of the brush.</summary>
			/// <returns>
			/// The opacity value of the brush.
			/// </returns>
			/// <remarks>opacity is expressed as a value between 0.0 and 1.0; 0.0 indicates that the brush is completely transparent, 0.5 that it is 50 percent opaque, and 1.0 that it is completely opaque.</remarks>
			// https://docs.microsoft.com/en-us/windows/win32/api/xpsobjectmodel/nf-xpsobjectmodel-ixpsombrush-getopacity
			// HRESULT GetOpacity( FLOAT *opacity );
			new float GetOpacity();

			/// <summary>Sets the opacity of the brush.</summary>
			/// <param name="opacity">The opacity value of the brush.</param>
			/// <remarks>
			/// <para>opacity is expressed as a value between 0.0 and 1.0; 0.0 indicates that the brush is completely transparent, 0.5 that it is 50 percent opaque, and 1.0 that it is completely opaque.</para>
			/// <para>If opacity is less than 0.0 or greater than 1.0, the method returns an error.</para>
			/// </remarks>
			// https://docs.microsoft.com/en-us/windows/win32/api/xpsobjectmodel/nf-xpsobjectmodel-ixpsombrush-setopacity
			// HRESULT SetOpacity( FLOAT opacity );
			new void SetOpacity([In] float opacity);

			/// <summary>Gets a pointer to the IXpsOMMatrixTransform interface that contains the resolved matrix transform for the brush.</summary>
			/// <returns>
			/// <para>A pointer to the IXpsOMMatrixTransform interface that contains the resolved matrix transform for the brush. If a matrix transform has not been set, a <c>NULL</c> pointer is returned.</para>
			/// <para>The value that is returned in this parameter depends on which method has most recently been called to set the transform.</para>
			/// <list type="table">
			/// <listheader>
			/// <term>Most recent method called</term>
			/// <term>Object that is returned in transform</term>
			/// </listheader>
			/// <item>
			/// <term>SetTransformLocal</term>
			/// <term>The transform that is set by SetTransformLocal.</term>
			/// </item>
			/// <item>
			/// <term>SetTransformLookup</term>
			/// <term>The transform which is retrieved, using a lookup key that matches the key that is set by SetTransformLookup, from the resource directory.</term>
			/// </item>
			/// <item>
			/// <term>Neither SetTransformLocal nor SetTransformLookup has been called yet.</term>
			/// <term>NULL pointer.</term>
			/// </item>
			/// </list>
			/// </returns>
			/// <remarks>The transform determines how the output area is transformed before the brush image is rendered in the path, stroke, or glyph that is using the tile brush.</remarks>
			// https://docs.microsoft.com/en-us/windows/win32/api/xpsobjectmodel/nf-xpsobjectmodel-ixpsomtilebrush-gettransform
			// HRESULT GetTransform( IXpsOMMatrixTransform **transform );
			IXpsOMMatrixTransform GetTransform();

			/// <summary>Gets a pointer to the IXpsOMMatrixTransform interface that contains the local, unshared resolved matrix transform for the brush.</summary>
			/// <returns>
			/// <para>A pointer to the IXpsOMMatrixTransform interface that contains the local, unshared resolved matrix transform for the brush. If a local matrix transform has not been set or if a matrix transform lookup key has been set, a <c>NULL</c> pointer is returned.</para>
			/// <list type="table">
			/// <listheader>
			/// <term>Most recent method called</term>
			/// <term>Object that is returned in transform</term>
			/// </listheader>
			/// <item>
			/// <term>SetTransformLocal</term>
			/// <term>The transform that is set by SetTransformLocal.</term>
			/// </item>
			/// <item>
			/// <term>SetTransformLookup</term>
			/// <term>NULL pointer.</term>
			/// </item>
			/// <item>
			/// <term>Neither SetTransformLocal nor SetTransformLookup has been called yet.</term>
			/// <term>NULL pointer.</term>
			/// </item>
			/// </list>
			/// </returns>
			/// <remarks>The transform determines how the output area is transformed before the brush image is rendered in the path, stroke, or glyph that is using the tile brush.</remarks>
			// https://docs.microsoft.com/en-us/windows/win32/api/xpsobjectmodel/nf-xpsobjectmodel-ixpsomtilebrush-gettransformlocal
			// HRESULT GetTransformLocal( IXpsOMMatrixTransform **transform );
			IXpsOMMatrixTransform GetTransformLocal();

			/// <summary>
			/// Sets the IXpsOMMatrixTransform interface pointer to a local, unshared matrix transform.
			/// </summary>
			/// <param name="transform">A pointer to the IXpsOMMatrixTransform interface to be set as the local, unshared matrix transform. If a local transform has been set, a <c>NULL</c> pointer will release it.</param>
			/// <remarks>
			/// <para>The transform determines how the output area is transformed before the brush image is rendered in the path, stroke, or glyph that is using the tile brush.</para>
			/// <para>After you call <c>SetTransformLocal</c>, the transform lookup key is released and GetTransformLookup returns a <c>NULL</c> pointer in the key parameter. The table that follows explains the relationship between the local and lookup values of this property.</para>
			/// <list type="table">
			///   <listheader>
			///     <term>Most recent method called</term>
			///     <term>Object that is returned in transform by GetTransform</term>
			///     <term>Object that is returned in transform by GetTransformLocal</term>
			///     <term>String that is returned in key by GetTransformLookup</term>
			///   </listheader>
			///   <item>
			///     <term>SetTransformLocal (this method)</term>
			///     <term>The transform that is set by SetTransformLocal.</term>
			///     <term>The transform that is set by SetTransformLocal.</term>
			///     <term>NULL pointer.</term>
			///   </item>
			///   <item>
			///     <term>SetTransformLookup</term>
			///     <term>The transform which is retrieved, using a lookup key that matches the key that is set by SetTransformLookup, from the resource directory.</term>
			///     <term>NULL pointer.</term>
			///     <term>The lookup key that is set by SetTransformLookup.</term>
			///   </item>
			///   <item>
			///     <term>Neither SetTransformLocal nor SetTransformLookup has been called yet.</term>
			///     <term>NULL pointer.</term>
			///     <term>NULL pointer.</term>
			///     <term>NULL pointer.</term>
			///   </item>
			/// </list>
			/// </remarks>
			// https://docs.microsoft.com/en-us/windows/win32/api/xpsobjectmodel/nf-xpsobjectmodel-ixpsomtilebrush-settransformlocal
			// HRESULT SetTransformLocal( IXpsOMMatrixTransform *transform );
			void SetTransformLocal([In] IXpsOMMatrixTransform transform);

			/// <summary>Gets the lookup key that identifies the IXpsOMMatrixTransform interface in a resource dictionary that contains the resolved matrix transform for the brush.</summary>
			/// <returns>
			/// <para>The lookup key that identifies the IXpsOMMatrixTransform interface in a resource dictionary that contains the resolved matrix transform for the brush. If a matrix transform lookup key has not been set or if a local matrix transform has been set, a <c>NULL</c> pointer is returned.</para>
			/// <list type="table">
			/// <listheader>
			/// <term>Most recent method called</term>
			/// <term>Object that is returned in key</term>
			/// </listheader>
			/// <item>
			/// <term>SetTransformLocal</term>
			/// <term>NULL pointer.</term>
			/// </item>
			/// <item>
			/// <term>SetTransformLookup</term>
			/// <term>The lookup key set by SetTransformLookup.</term>
			/// </item>
			/// <item>
			/// <term>Neither SetTransformLocal nor SetTransformLookup has been called yet.</term>
			/// <term>NULL pointer.</term>
			/// </item>
			/// </list>
			/// </returns>
			/// <remarks>
			/// <para>The transform determines how the output area is transformed before the brush image is rendered in the path, stroke, or glyph that is using the tile brush.</para>
			/// </remarks>
			// https://docs.microsoft.com/en-us/windows/win32/api/xpsobjectmodel/nf-xpsobjectmodel-ixpsomtilebrush-gettransformlookup
			// HRESULT GetTransformLookup( LPWSTR *key );
			SafeCoTaskMemString GetTransformLookup();

			/// <summary>
			/// Sets the lookup key name of a shared matrix transform that will be used as the transform for this brush.The shared matrix transform that is referenced by the lookup key is stored in the resource dictionary.
			/// </summary>
			/// <param name="key">A string variable that contains the lookup key name of a shared matrix transform in the resource dictionary. If a lookup key has already been set, a <c>NULL</c> pointer will clear it.</param>
			/// <remarks>
			/// <para>The transform is applied before the brush image is rendered in the path, stroke, or glyph that is using the tile brush. The tile brush has only one transform, which can be local or remote.</para>
			/// <para>After you call <c>SetTransformLookup</c>, the local transform is released and GetTransformLocal returns a <c>NULL</c> pointer in the transform parameter. The table that follows explains the relationship between the local and lookup values of this property.</para>
			/// <list type="table">
			///   <listheader>
			///     <term>Most recent method called</term>
			///     <term>Object that is returned in transform by GetTransform</term>
			///     <term>Object that is returned in transform by GetTransformLocal</term>
			///     <term>String that is returned in key by GetTransformLookup</term>
			///   </listheader>
			///   <item>
			///     <term>SetTransformLocal</term>
			///     <term>The transform that is set by SetTransformLocal.</term>
			///     <term>The transform that is set by SetTransformLocal.</term>
			///     <term>NULL pointer.</term>
			///   </item>
			///   <item>
			///     <term>SetTransformLookup (this method)</term>
			///     <term>The transform which is retrieved—using a lookup key that matches the key that is set by SetTransformLookup— from the resource directory.</term>
			///     <term>NULL pointer.</term>
			///     <term>The lookup key that is set by SetTransformLookup.</term>
			///   </item>
			///   <item>
			///     <term>Neither SetTransformLocal nor SetTransformLookup has been called yet.</term>
			///     <term>NULL pointer.</term>
			///     <term>NULL pointer.</term>
			///     <term>NULL pointer.</term>
			///   </item>
			/// </list>
			/// </remarks>
			// https://docs.microsoft.com/en-us/windows/win32/api/xpsobjectmodel/nf-xpsobjectmodel-ixpsomtilebrush-settransformlookup
			// HRESULT SetTransformLookup( LPCWSTR key );
			void SetTransformLookup([In, MarshalAs(UnmanagedType.LPWStr)] string key);

			/// <summary>Gets the portion of the source image to be used by the tile.</summary>
			/// <returns>The XPS_RECT structure that describes the area of the source content to be used by the tile.</returns>
			/// <remarks>
			/// <para>The brush's viewbox specifies the portion of a source image or visual to be used as the tile image.</para>
			/// <para>The coordinates of the brush's viewbox are relative to the source content, such that (0,0) specifies the upper-left corner of the source content. For images, dimensions specified by the brush's viewbox are expressed in the units of 1/96". The corresponding pixel coordinates in the source image are calculated as follows:</para>
			/// <para>In the illustration that follows, the image on the left is an example of a source image, the image in the center shows the selected viewbox, and the image on the right shows the resulting brush.</para>
			/// <para>If the source image resolution is 96 by 96 dots per inch and image dimensions are 96 by 96 pixels, the values of fields in the viewbox parameter would be:</para>
			/// <para>The preceding parameter values correspond to the source image as:</para>
			/// </remarks>
			// https://docs.microsoft.com/en-us/windows/win32/api/xpsobjectmodel/nf-xpsobjectmodel-ixpsomtilebrush-getviewbox
			// HRESULT GetViewbox( XPS_RECT *viewbox );
			XPS_RECT GetViewbox();

			/// <summary>
			/// Sets the portion of the source content to be used as the tile image.
			/// </summary>
			/// <param name="viewbox">An XPS_RECT structure that describes the portion of the source content to be used as the tile image.</param>
			/// <remarks>
			/// <para>The brush's viewbox specifies the portion of a source image or visual to be used as the tile image.</para>
			/// <para>The coordinates of the brush's viewbox are relative to the source content, such that (0,0) specifies the upper-left corner of the source content. For images, dimensions specified by the brush's viewbox are expressed in the units of 1/96". The corresponding pixel coordinates in the source image are calculated as follows:</para>
			/// <para>In the illustration that follows, the image on the left is an example of a source image, while that on the right is the source image with the selected viewbox for the brush shown as a red rectangle. In this example, the part of the source image that is used as the content for the tile brush is the area within the red rectangle. The shaded area of the image is not used by the brush.</para>
			/// <para>If the source image resolution is 96 by 96 dots per inch and image dimensions are 96 by 96 pixels, the values of fields in the viewbox parameter would be:</para>
			/// <para>The preceding parameter values correspond to the source image as:</para>
			/// </remarks>
			// https://docs.microsoft.com/en-us/windows/win32/api/xpsobjectmodel/nf-xpsobjectmodel-ixpsomtilebrush-setviewbox
			// HRESULT SetViewbox( const XPS_RECT *viewbox );
			void SetViewbox(in XPS_RECT viewbox);

			/// <summary>Gets the portion of the destination geometry that is covered by a single tile.</summary>
			/// <returns>The XPS_RECT structure that describes the portion of the destination geometry that is covered by a single tile.</returns>
			/// <remarks>The viewport is the portion of the output area where the first tile is drawn. In the illustration, the viewport is outlined by the purple rectangle inside the red, dotted rectangle. The tile mode of the brush determines how the rest of the tiles are drawn in the output area.</remarks>
			// https://docs.microsoft.com/en-us/windows/win32/api/xpsobjectmodel/nf-xpsobjectmodel-ixpsomtilebrush-getviewport
			// HRESULT GetViewport( XPS_RECT *viewport );
			XPS_RECT GetViewport();

			/// <summary>
			/// Sets the portion of the destination geometry that is covered by a single tile.
			/// </summary>
			/// <param name="viewport">An XPS_RECT structure that describes the portion of the destination geometry that is covered by a single tile.</param>
			/// <remarks>
			/// The viewport is the portion of the output area where the tile is drawn. In the following illustration, the viewport is outlined by the blue rectangle inside the red, dotted rectangle. The tile mode of the brush determines how other tiles are drawn in the output area.
			/// </remarks>
			// https://docs.microsoft.com/en-us/windows/win32/api/xpsobjectmodel/nf-xpsobjectmodel-ixpsomtilebrush-setviewport
			// HRESULT SetViewport( const XPS_RECT *viewport );
			void SetViewport(in XPS_RECT viewport);

			/// <summary>Gets the XPS_TILE_MODE value that describes the tile mode of the brush.</summary>
			/// <returns>The XPS_TILE_MODE value that describes the tile mode of the brush.</returns>
			/// <remarks>The tile mode determines how the tile image is repeated to fill the output area. If the tile mode value is XPS_TILE_MODE_NONE, the tile image is drawn only once. The following illustration shows examples of how the tile image appears in several tile modes.</remarks>
			// https://docs.microsoft.com/en-us/windows/win32/api/xpsobjectmodel/nf-xpsobjectmodel-ixpsomtilebrush-gettilemode
			// HRESULT GetTileMode( XPS_TILE_MODE *tileMode );
			XPS_TILE_MODE GetTileMode();

			/// <summary>
			/// Sets the XPS_TILE_MODE value that describes the tiling mode of the brush.
			/// </summary>
			/// <param name="tileMode">The XPS_TILE_MODE value to be set.</param>
			/// <remarks>
			/// The tile mode determines how the tile image is repeated to fill the output area. If the tile mode value is XPS_TILE_MODE_NONE, the tile image is drawn only once.
			/// </remarks>
			// https://docs.microsoft.com/en-us/windows/win32/api/xpsobjectmodel/nf-xpsobjectmodel-ixpsomtilebrush-settilemode
			// HRESULT SetTileMode( XPS_TILE_MODE tileMode );
			void SetTileMode([In] XPS_TILE_MODE tileMode);
		}

		/// <summary>The base interface for path, canvas, and glyph interfaces.</summary>
		// https://docs.microsoft.com/en-us/windows/win32/api/xpsobjectmodel/nn-xpsobjectmodel-ixpsomvisual
		[PInvokeData("xpsobjectmodel.h", MSDNShortId = "f2ec412c-aece-4b20-a721-e6c17615e56b")]
		[ComImport, Guid("BC3E7333-FB0B-4AF3-A819-0B4EAAD0D2FD"), InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
		public interface IXpsOMVisual : IXpsOMShareable
		{
			/// <summary>Gets the <c>IUnknown</c> interface of the parent.</summary>
			/// <returns>A pointer to the <c>IUnknown</c> interface of the parent.</returns>
			// https://docs.microsoft.com/en-us/windows/win32/api/xpsobjectmodel/nf-xpsobjectmodel-ixpsomshareable-getowner
			// HRESULT GetOwner( IUnknown **owner );
			[return: MarshalAs(UnmanagedType.IUnknown)]
			new object GetOwner();

			/// <summary>Gets the object type of the interface.</summary>
			/// <returns>The XPS_OBJECT_TYPE value that describes the interface that is derived from IXpsOMShareable.</returns>
			// https://docs.microsoft.com/en-us/windows/win32/api/xpsobjectmodel/nf-xpsobjectmodel-ixpsomshareable-gettype
			// HRESULT GetType( XPS_OBJECT_TYPE *type );
			new XPS_OBJECT_TYPE GetType();

			/// <summary>Gets a pointer to the IXpsOMMatrixTransform interface that contains the visual's resolved matrix transform.</summary>
			/// <returns>
			/// <para>A pointer to the IXpsOMMatrixTransform interface that contains the visual's resolved matrix transform. If a matrix transform has not been set, a <c>NULL</c> pointer is returned.</para>
			/// <para>The value that is returned in this parameter depends on which method has most recently been called to set the transform.</para>
			/// <list type="table">
			/// <listheader>
			/// <term>Most recent method called</term>
			/// <term>Object that is returned in matrixTransform</term>
			/// </listheader>
			/// <item>
			/// <term>SetTransformLocal</term>
			/// <term>The local transform that is set by SetTransformLocal.</term>
			/// </item>
			/// <item>
			/// <term>SetTransformLookup</term>
			/// <term>The shared transform that gets retrieved, with a lookup key that matches the key that is set by SetTransformLookup, from the resource directory.</term>
			/// </item>
			/// <item>
			/// <term>Neither SetTransformLocal nor SetTransformLookup has been called yet.</term>
			/// <term>NULL pointer.</term>
			/// </item>
			/// </list>
			/// </returns>
			// https://docs.microsoft.com/en-us/windows/win32/api/xpsobjectmodel/nf-xpsobjectmodel-ixpsomvisual-gettransform
			// HRESULT GetTransform( IXpsOMMatrixTransform **matrixTransform );
			[MethodImpl(MethodImplOptions.InternalCall)]
			IXpsOMMatrixTransform GetTransform();

			/// <summary>Gets a pointer to the IXpsOMMatrixTransform interface that contains the local, unshared, resolved matrix transform for the visual.</summary>
			/// <returns>
			/// <para>A pointer to the IXpsOMMatrixTransform interface that contains the local, unshared, resolved matrix transform for the visual. If a matrix transform lookup key has not been set, or if a local matrix transform has been set, a <c>NULL</c> pointer is returned.</para>
			/// <list type="table">
			/// <listheader>
			/// <term>Most recent method called</term>
			/// <term>Object that is returned in matrixTransform</term>
			/// </listheader>
			/// <item>
			/// <term>SetTransformLocal</term>
			/// <term>The local transform that is set by SetTransformLocal.</term>
			/// </item>
			/// <item>
			/// <term>SetTransformLookup</term>
			/// <term>NULL pointer.</term>
			/// </item>
			/// <item>
			/// <term>Neither SetTransformLocal nor SetTransformLookup has been called yet.</term>
			/// <term>NULL pointer.</term>
			/// </item>
			/// </list>
			/// </returns>
			// https://docs.microsoft.com/en-us/windows/win32/api/xpsobjectmodel/nf-xpsobjectmodel-ixpsomvisual-gettransformlocal
			// HRESULT GetTransformLocal( IXpsOMMatrixTransform **matrixTransform );
			[MethodImpl(MethodImplOptions.InternalCall)]
			IXpsOMMatrixTransform GetTransformLocal();

			/// <summary>
			/// Sets the local, unshared matrix transform.
			/// </summary>
			/// <param name="matrixTransform">A pointer to the IXpsOMMatrixTransform interface to be set as the local, unshared matrix transform. A <c>NULL</c> pointer releases the previously assigned transform.</param>
			/// <remarks>
			/// <para>After you call <c>SetTransformLocal</c>, the transform lookup key is released and GetTransformLookup returns a <c>NULL</c> pointer in the key parameter. The table that follows explains the relationship between the local and lookup values of this property.</para>
			/// <list type="table">
			///   <listheader>
			///     <term>Most recent method called</term>
			///     <term>Object that is returned in transform by GetTransform</term>
			///     <term>Object that is returned in matrixTransform by GetTransformLocal</term>
			///     <term>Object that is returned in key by GetTransformLookup</term>
			///   </listheader>
			///   <item>
			///     <term>SetTransformLocal (this method)</term>
			///     <term>The local transform that is set by SetTransformLocal.</term>
			///     <term>The local transform set by SetTransformLocal.</term>
			///     <term>NULL pointer.</term>
			///   </item>
			///   <item>
			///     <term>SetTransformLookup</term>
			///     <term>The shared transform that gets retrieved, with a lookup key that matches the key that is set by SetTransformLookup, from the resource directory.</term>
			///     <term>NULL pointer.</term>
			///     <term>The lookup key that is set by SetTransformLookup.</term>
			///   </item>
			///   <item>
			///     <term>Neither SetTransformLocal nor SetTransformLookup has been called yet.</term>
			///     <term>NULL pointer.</term>
			///     <term>NULL pointer.</term>
			///     <term>NULL pointer.</term>
			///   </item>
			/// </list>
			/// </remarks>
			// https://docs.microsoft.com/en-us/windows/win32/api/xpsobjectmodel/nf-xpsobjectmodel-ixpsomvisual-settransformlocal
			// HRESULT SetTransformLocal( IXpsOMMatrixTransform *matrixTransform );
			[MethodImpl(MethodImplOptions.InternalCall)]
			void SetTransformLocal([In] IXpsOMMatrixTransform matrixTransform);

			/// <summary>Gets the lookup key name of the IXpsOMMatrixTransform interface in a resource dictionary that contains the resolved matrix transform for the visual.</summary>
			/// <returns>
			/// <para>The lookup key name for the IXpsOMMatrixTransform interface in a resource dictionary that contains the resolved matrix transform for the visual. If a matrix transform lookup key has not been set, or if a local matrix transform has been set, a <c>NULL</c> pointer is returned.</para>
			/// <list type="table">
			/// <listheader>
			/// <term>Most recent method called</term>
			/// <term>Object that is returned in key</term>
			/// </listheader>
			/// <item>
			/// <term>SetTransformLocal</term>
			/// <term>NULL pointer.</term>
			/// </item>
			/// <item>
			/// <term>SetTransformLookup</term>
			/// <term>The lookup key that is set by SetTransformLookup.</term>
			/// </item>
			/// <item>
			/// <term>Neither SetTransformLocal nor SetTransformLookup has been called yet.</term>
			/// <term>NULL pointer.</term>
			/// </item>
			/// </list>
			/// </returns>
			// https://docs.microsoft.com/en-us/windows/win32/api/xpsobjectmodel/nf-xpsobjectmodel-ixpsomvisual-gettransformlookup
			// HRESULT GetTransformLookup( LPWSTR *key );
			[MethodImpl(MethodImplOptions.InternalCall)]
			SafeCoTaskMemString GetTransformLookup();

			/// <summary>
			/// Sets the lookup key name of a shared matrix transform in a resource dictionary.
			/// </summary>
			/// <param name="key">The lookup key name of the matrix transform in the dictionary.</param>
			/// <remarks>
			/// <para>After you call <c>SetTransformLookup</c>, the local transform is released and GetTransformLocal returns a <c>NULL</c> pointer in the matrixTransform parameter. The table that follows explains the relationship between the local and lookup values of this property.</para>
			/// <list type="table">
			///   <listheader>
			///     <term>Most recent method called</term>
			///     <term>Object that is returned in transform by GetTransform</term>
			///     <term>Object that is returned in matrixTransform by GetTransformLocal</term>
			///     <term>Object that is returned in key by GetTransformLookup</term>
			///   </listheader>
			///   <item>
			///     <term>SetTransformLocal</term>
			///     <term>The local transform that is set by SetTransformLocal.</term>
			///     <term>The local transform that is set by SetTransformLocal.</term>
			///     <term>NULL pointer.</term>
			///   </item>
			///   <item>
			///     <term>SetTransformLookup (this method)</term>
			///     <term>The shared transform that gets retrieved—with a lookup key that matches the key that is set by SetTransformLookup—from the resource directory.</term>
			///     <term>NULL pointer.</term>
			///     <term>The lookup key that is set by SetTransformLookup.</term>
			///   </item>
			///   <item>
			///     <term>Neither SetTransformLocal nor SetTransformLookup has been called yet.</term>
			///     <term>NULL pointer.</term>
			///     <term>NULL pointer.</term>
			///     <term>NULL pointer.</term>
			///   </item>
			/// </list>
			/// </remarks>
			// https://docs.microsoft.com/en-us/windows/win32/api/xpsobjectmodel/nf-xpsobjectmodel-ixpsomvisual-settransformlookup
			// HRESULT SetTransformLookup( LPCWSTR key );
			[MethodImpl(MethodImplOptions.InternalCall)]
			void SetTransformLookup([In, MarshalAs(UnmanagedType.LPWStr)] string key);

			/// <summary>Gets a pointer to the IXpsOMGeometry interface that contains the resolved geometry of the visual's clipping region.</summary>
			/// <returns>
			/// <para>A pointer to the IXpsOMGeometry interface that contains the resolved geometry of the visual's clipping region. If the clip geometry has not been set, a <c>NULL</c> pointer is returned.</para>
			/// <para>The value that is returned in this parameter depends on which method has most recently been called to set the geometry.</para>
			/// <list type="table">
			/// <listheader>
			/// <term>Most recent method called</term>
			/// <term>Object that is returned in clipGeometry</term>
			/// </listheader>
			/// <item>
			/// <term>SetClipGeometryLocal</term>
			/// <term>The local clip geometry that is set by SetClipGeometryLocal.</term>
			/// </item>
			/// <item>
			/// <term>SetClipGeometryLookup</term>
			/// <term>The shared clip geometry that gets retrieved, with a lookup key that matches the key that is set by SetClipGeometryLookup, from the resource directory.</term>
			/// </item>
			/// <item>
			/// <term>Neither SetClipGeometryLocal nor SetClipGeometryLookup has been called yet.</term>
			/// <term>NULL pointer.</term>
			/// </item>
			/// </list>
			/// </returns>
			// https://docs.microsoft.com/en-us/windows/win32/api/xpsobjectmodel/nf-xpsobjectmodel-ixpsomvisual-getclipgeometry
			// HRESULT GetClipGeometry( IXpsOMGeometry **clipGeometry );
			[MethodImpl(MethodImplOptions.InternalCall)]
			IXpsOMGeometry GetClipGeometry();

			/// <summary>Gets a pointer to the IXpsOMGeometry interface that contains the local, unshared geometry of the visual's clipping region.</summary>
			/// <returns>
			/// <para>A pointer to the IXpsOMGeometry interface that contains the local, unshared geometry of the visual's clipping region. If a clip geometry lookup key has been set, or if a local clip geometry has not been set, a <c>NULL</c> pointer is returned.</para>
			/// <list type="table">
			/// <listheader>
			/// <term>Most recent method called</term>
			/// <term>Object that is returned in clipGeometry</term>
			/// </listheader>
			/// <item>
			/// <term>SetClipGeometryLocal</term>
			/// <term>The local clip geometry that is set by SetClipGeometryLocal.</term>
			/// </item>
			/// <item>
			/// <term>SetClipGeometryLookup</term>
			/// <term>NULL pointer.</term>
			/// </item>
			/// <item>
			/// <term>Neither SetClipGeometryLocal nor SetClipGeometryLookup has been called yet.</term>
			/// <term>NULL pointer.</term>
			/// </item>
			/// </list>
			/// </returns>
			// https://docs.microsoft.com/en-us/windows/win32/api/xpsobjectmodel/nf-xpsobjectmodel-ixpsomvisual-getclipgeometrylocal
			// HRESULT GetClipGeometryLocal( IXpsOMGeometry **clipGeometry );
			[MethodImpl(MethodImplOptions.InternalCall)]
			IXpsOMGeometry GetClipGeometryLocal();

			/// <summary>Sets the local, unshared clipping region for the visual.</summary>
			/// <param name="clipGeometry">A pointer to the IXpsOMGeometry interface to be set as the local, unshared clipping region for the visual. A <c>NULL</c> pointer releases the previously assigned geometry interface.</param>
			/// <remarks>
			/// <para>After you call <c>SetClipGeometryLocal</c>, the clip geometry lookup key is released and GetClipGeometryLookup returns a <c>NULL</c> pointer in the key parameter. The table that follows explains the relationship between the local and lookup values of this property.</para>
			/// <list type="table">
			/// <listheader>
			/// <term>Most recent method called</term>
			/// <term>Object that is returned in clipGeometry by GetClipGeometry</term>
			/// <term>Object that is returned in clipGeometry by GetClipGeometryLocal</term>
			/// <term>String that is returned in key by GetClipGeometryLookup</term>
			/// </listheader>
			/// <item>
			/// <term>SetClipGeometryLocal (this method)</term>
			/// <term>The local clip geometry that is set by SetClipGeometryLocal.</term>
			/// <term>The local clip geometry that is set by SetClipGeometryLocal.</term>
			/// <term>NULL pointer.</term>
			/// </item>
			/// <item>
			/// <term>SetClipGeometryLookup</term>
			/// <term>The shared clip geometry that gets retrieved, with a lookup key that matches the key that is set by SetClipGeometryLookup, from the resource directory.</term>
			/// <term>NULL pointer.</term>
			/// <term>The lookup key that is set by SetClipGeometryLookup.</term>
			/// </item>
			/// <item>
			/// <term>Neither SetClipGeometryLookup nor SetClipGeometryLocal has been called yet.</term>
			/// <term>NULL pointer.</term>
			/// <term>NULL pointer.</term>
			/// <term>NULL pointer.</term>
			/// </item>
			/// </list>
			/// </remarks>
			// https://docs.microsoft.com/en-us/windows/win32/api/xpsobjectmodel/nf-xpsobjectmodel-ixpsomvisual-setclipgeometrylocal
			// HRESULT SetClipGeometryLocal( IXpsOMGeometry *clipGeometry );
			[MethodImpl(MethodImplOptions.InternalCall)]
			void SetClipGeometryLocal([In] IXpsOMGeometry clipGeometry);

			/// <summary>Gets the lookup key for the IXpsOMGeometry interface in a resource dictionary that contains the visual's clipping region.</summary>
			/// <returns>
			/// <para>The lookup key for the IXpsOMGeometry interface in a resource dictionary that contains the visual's clipping region. If a lookup key for the clip geometry has not been set, or if a local clip geometry has been set, a <c>NULL</c> pointer is returned.</para>
			/// <list type="table">
			/// <listheader>
			/// <term>Most recent method called</term>
			/// <term>Lookup key string that is returned in key</term>
			/// </listheader>
			/// <item>
			/// <term>SetClipGeometryLocal</term>
			/// <term>NULL pointer.</term>
			/// </item>
			/// <item>
			/// <term>SetClipGeometryLookup</term>
			/// <term>The lookup key that is set by SetClipGeometryLookup.</term>
			/// </item>
			/// <item>
			/// <term>Neither SetClipGeometryLocal nor SetClipGeometryLookup has been called yet.</term>
			/// <term>NULL pointer.</term>
			/// </item>
			/// </list>
			/// </returns>
			// https://docs.microsoft.com/en-us/windows/win32/api/xpsobjectmodel/nf-xpsobjectmodel-ixpsomvisual-getclipgeometrylookup
			// HRESULT GetClipGeometryLookup( LPWSTR *key );
			[MethodImpl(MethodImplOptions.InternalCall)]
			SafeCoTaskMemString GetClipGeometryLookup();

			/// <summary>Sets the lookup key name of a shared clip geometry in a resource dictionary.</summary>
			/// <param name="key">The lookup key name of the clip geometry in the dictionary. A <c>NULL</c> pointer clears the previously assigned key name.</param>
			/// <remarks>
			/// <para>After you call <c>SetClipGeometryLookup</c>, the local clip geometry is released and GetClipGeometryLocal returns a <c>NULL</c> pointer in the clipGeometry parameter. The table that follows explains the relationship between the local and lookup values of this property.</para>
			/// <list type="table">
			/// <listheader>
			/// <term>Most recent method called</term>
			/// <term>Object that is returned in clipGeometry by GetClipGeometry</term>
			/// <term>Object that is returned in clipGeometry by GetClipGeometryLocal</term>
			/// <term>String that is returned in key by GetClipGeometryLookup</term>
			/// </listheader>
			/// <item>
			/// <term>SetClipGeometryLocal</term>
			/// <term>The local clip geometry that is set by SetClipGeometryLocal.</term>
			/// <term>The local clip geometry that is set by SetClipGeometryLocal.</term>
			/// <term>NULL pointer.</term>
			/// </item>
			/// <item>
			/// <term>SetClipGeometryLookup (this method)</term>
			/// <term>The shared clip geometry that gets retrieved, with a lookup key that matches the key that is set by SetClipGeometryLookup, from the resource directory.</term>
			/// <term>NULL pointer.</term>
			/// <term>The lookup key that is set by SetClipGeometryLookup.</term>
			/// </item>
			/// <item>
			/// <term>Neither SetClipGeometryLookup nor SetClipGeometryLocal has been called yet.</term>
			/// <term>NULL pointer.</term>
			/// <term>NULL pointer.</term>
			/// <term>NULL pointer.</term>
			/// </item>
			/// </list>
			/// </remarks>
			// https://docs.microsoft.com/en-us/windows/win32/api/xpsobjectmodel/nf-xpsobjectmodel-ixpsomvisual-setclipgeometrylookup
			// HRESULT SetClipGeometryLookup( LPCWSTR key );
			[MethodImpl(MethodImplOptions.InternalCall)]
			void SetClipGeometryLookup([In, MarshalAs(UnmanagedType.LPWStr)] string key);

			/// <summary>Gets the opacity value of this visual.</summary>
			/// <returns>The opacity value.</returns>
			// https://docs.microsoft.com/en-us/windows/win32/api/xpsobjectmodel/nf-xpsobjectmodel-ixpsomvisual-getopacity
			// HRESULT GetOpacity( FLOAT *opacity );
			[MethodImpl(MethodImplOptions.InternalCall)]
			float GetOpacity();

			/// <summary>Sets the opacity value of the visual.</summary>
			/// <param name="opacity">
			/// <para>The opacity value to be set for the visual.</para>
			/// <para>The range of allowed values for this parameter is 0.0 to 1.0; with 0.0 the visual is completely transparent, and with 1.0 it is completely opaque.</para>
			/// </param>
			// https://docs.microsoft.com/en-us/windows/win32/api/xpsobjectmodel/nf-xpsobjectmodel-ixpsomvisual-setopacity
			// HRESULT SetOpacity( FLOAT opacity );
			[MethodImpl(MethodImplOptions.InternalCall)]
			void SetOpacity([In] float opacity);

			/// <summary>Gets a pointer to the IXpsOMBrush interface of the visual's opacity mask brush.</summary>
			/// <returns>
			/// <para>A pointer to the IXpsOMBrush interface of the visual's opacity mask brush. If an opacity mask brush has not been set for this visual, a <c>NULL</c> pointer is returned.</para>
			/// <para>The value that is returned in this parameter depends on which method has most recently been called to set the brush.</para>
			/// <list type="table">
			/// <listheader>
			/// <term>Most recent method called</term>
			/// <term>Object that is returned in opacityMaskBrush</term>
			/// </listheader>
			/// <item>
			/// <term>SetOpacityMaskBrushLocal</term>
			/// <term>The local opacity mask brush that is set by SetOpacityMaskBrushLocal.</term>
			/// </item>
			/// <item>
			/// <term>SetOpacityMaskBrushLookup</term>
			/// <term>The shared opacity mask brush that gets retrieved, with a lookup key that matches the key that is set by SetOpacityMaskBrushLookup, from the resource directory.</term>
			/// </item>
			/// <item>
			/// <term>Neither SetOpacityMaskBrushLocal nor SetOpacityMaskBrushLookup has been called yet.</term>
			/// <term>NULL pointer.</term>
			/// </item>
			/// </list>
			/// </returns>
			// https://docs.microsoft.com/en-us/windows/win32/api/xpsobjectmodel/nf-xpsobjectmodel-ixpsomvisual-getopacitymaskbrush
			// HRESULT GetOpacityMaskBrush( IXpsOMBrush **opacityMaskBrush );
			[MethodImpl(MethodImplOptions.InternalCall)]
			IXpsOMBrush GetOpacityMaskBrush();

			/// <summary>Gets the local, unshared opacity mask brush for the visual.</summary>
			/// <returns>
			/// <para>A pointer to the IXpsOMBrush interface of the visual's opacity mask brush. If an opacity mask brush lookup key has been set, or if a local opacity mask brush has not been set, a <c>NULL</c> pointer is returned.</para>
			/// <list type="table">
			/// <listheader>
			/// <term>Most recent method called</term>
			/// <term>Object that is returned in opacityMaskBrush</term>
			/// </listheader>
			/// <item>
			/// <term>SetOpacityMaskBrushLocal</term>
			/// <term>The local opacity mask brush that is set by SetOpacityMaskBrushLocal.</term>
			/// </item>
			/// <item>
			/// <term>SetOpacityMaskBrushLookup</term>
			/// <term>NULL pointer.</term>
			/// </item>
			/// <item>
			/// <term>Neither SetOpacityMaskBrushLocal nor SetOpacityMaskBrushLookup has been called yet.</term>
			/// <term>NULL pointer.</term>
			/// </item>
			/// </list>
			/// </returns>
			// https://docs.microsoft.com/en-us/windows/win32/api/xpsobjectmodel/nf-xpsobjectmodel-ixpsomvisual-getopacitymaskbrushlocal
			// HRESULT GetOpacityMaskBrushLocal( IXpsOMBrush **opacityMaskBrush );
			[MethodImpl(MethodImplOptions.InternalCall)]
			IXpsOMBrush GetOpacityMaskBrushLocal();

			/// <summary>
			/// Sets the IXpsOMBrush interface pointer as the local, unshared opacity mask brush.
			/// </summary>
			/// <param name="opacityMaskBrush">A pointer to the IXpsOMBrush interface to be set as the local, unshared opacity mask brush. A <c>NULL</c> pointer clears the previously assigned opacity mask brush.</param>
			/// <remarks>
			/// <para>After you call <c>SetOpacityMaskBrushLocal</c>, the opacity mask brush lookup key is released and GetOpacityMaskBrushLookup returns a <c>NULL</c> pointer in the key parameter. The table that follows explains the relationship between the local and lookup values of this property.</para>
			/// <list type="table">
			///   <listheader>
			///     <term>Most recent method called</term>
			///     <term>Object that is returned in opacityMaskBrush by GetOpacityMaskBrush</term>
			///     <term>Object that is returned in opacityMaskBrush by GetOpacityMaskBrushLocal</term>
			///     <term>String that is returned in key by GetOpacityMaskBrushLookup</term>
			///   </listheader>
			///   <item>
			///     <term>SetOpacityMaskBrushLocal (this method)</term>
			///     <term>The local opacity mask brush that is set by SetOpacityMaskBrushLocal.</term>
			///     <term>The local opacity mask brush that is set by SetOpacityMaskBrushLocal.</term>
			///     <term>NULL pointer.</term>
			///   </item>
			///   <item>
			///     <term>SetOpacityMaskBrushLookup</term>
			///     <term>The shared opacity mask brush that gets retrieved, with a lookup key that matches the key that is set by SetOpacityMaskBrushLookup, from the resource directory.</term>
			///     <term>NULL pointer.</term>
			///     <term>The lookup key that is set by SetOpacityMaskBrushLookup.</term>
			///   </item>
			///   <item>
			///     <term>Neither SetOpacityMaskBrushLocal nor SetOpacityMaskBrushLookup has been called yet.</term>
			///     <term>NULL pointer.</term>
			///     <term>NULL pointer.</term>
			///     <term>NULL pointer.</term>
			///   </item>
			/// </list>
			/// </remarks>
			// https://docs.microsoft.com/en-us/windows/win32/api/xpsobjectmodel/nf-xpsobjectmodel-ixpsomvisual-setopacitymaskbrushlocal
			// HRESULT SetOpacityMaskBrushLocal( IXpsOMBrush *opacityMaskBrush );
			[MethodImpl(MethodImplOptions.InternalCall)]
			void SetOpacityMaskBrushLocal([In] IXpsOMBrush opacityMaskBrush);

			/// <summary>Gets the name of the lookup key of the shared opacity mask brush in a resource dictionary.</summary>
			/// <returns>
			/// <para>The name of the lookup key of the shared opacity mask brush in a resource dictionary. If the lookup key of an opacity mask brush has not been set, or if a local opacity mask brush has been set, a <c>NULL</c> pointer is returned.</para>
			/// <list type="table">
			/// <listheader>
			/// <term>Most recent method called</term>
			/// <term>Object that is returned in key</term>
			/// </listheader>
			/// <item>
			/// <term>SetOpacityMaskBrushLocal</term>
			/// <term>NULL pointer.</term>
			/// </item>
			/// <item>
			/// <term>SetOpacityMaskBrushLookup</term>
			/// <term>The lookup key that is set by SetOpacityMaskBrushLookup.</term>
			/// </item>
			/// <item>
			/// <term>Neither SetOpacityMaskBrushLocal nor SetOpacityMaskBrushLookup has been called yet.</term>
			/// <term>NULL pointer.</term>
			/// </item>
			/// </list>
			/// </returns>
			// https://docs.microsoft.com/en-us/windows/win32/api/xpsobjectmodel/nf-xpsobjectmodel-ixpsomvisual-getopacitymaskbrushlookup
			// HRESULT GetOpacityMaskBrushLookup( LPWSTR *key );
			[MethodImpl(MethodImplOptions.InternalCall)]
			SafeCoTaskMemString GetOpacityMaskBrushLookup();

			/// <summary>
			/// Sets the lookup key name of a shared opacity mask brush in a resource dictionary.
			/// </summary>
			/// <param name="key">The lookup key name of the opacity mask brush in the dictionary. A <c>NULL</c> pointer clears the previously assigned key name.</param>
			/// <remarks>
			/// <para>After you call <c>SetOpacityMaskBrushLookup</c>, the local opacity mask brush is released and GetOpacityMaskBrushLocal returns a <c>NULL</c> pointer in the opacityMaskBrush parameter. The table that follows explains the relationship between the local and lookup values of this property.</para>
			/// <list type="table">
			///   <listheader>
			///     <term>Most recent method called</term>
			///     <term>Object that is returned in opacityMaskBrush by GetOpacityMaskBrush</term>
			///     <term>Object that is returned in opacityMaskBrush by GetOpacityMaskBrushLocal</term>
			///     <term>String that is returned in key by GetOpacityMaskBrushLookup</term>
			///   </listheader>
			///   <item>
			///     <term>SetOpacityMaskBrushLocal</term>
			///     <term>The local opacity mask brush that is set by SetOpacityMaskBrushLocal.</term>
			///     <term>The local opacity mask brush that is set by SetOpacityMaskBrushLocal.</term>
			///     <term>NULL pointer.</term>
			///   </item>
			///   <item>
			///     <term>SetOpacityMaskBrushLookup (this method)</term>
			///     <term>The shared opacity mask brush that gets retrieved—with a lookup key that matches the key that is set by SetOpacityMaskBrushLookup—from the resource directory.</term>
			///     <term>NULL pointer.</term>
			///     <term>The lookup key that is set by SetOpacityMaskBrushLookup.</term>
			///   </item>
			///   <item>
			///     <term>Neither SetOpacityMaskBrushLocal nor SetOpacityMaskBrushLookup has been called yet.</term>
			///     <term>NULL pointer.</term>
			///     <term>NULL pointer.</term>
			///     <term>NULL pointer.</term>
			///   </item>
			/// </list>
			/// </remarks>
			// https://docs.microsoft.com/en-us/windows/win32/api/xpsobjectmodel/nf-xpsobjectmodel-ixpsomvisual-setopacitymaskbrushlookup
			// HRESULT SetOpacityMaskBrushLookup( LPCWSTR key );
			[MethodImpl(MethodImplOptions.InternalCall)]
			void SetOpacityMaskBrushLookup([In, MarshalAs(UnmanagedType.LPWStr)] string key);

			/// <summary>Gets the <c>Name</c> property of the visual.</summary>
			/// <returns>The <c>Name</c> property string. If the <c>Name</c> property has not been set, a <c>NULL</c> pointer is returned.</returns>
			// https://docs.microsoft.com/en-us/windows/win32/api/xpsobjectmodel/nf-xpsobjectmodel-ixpsomvisual-getname
			// HRESULT GetName( LPWSTR *name );
			[MethodImpl(MethodImplOptions.InternalCall)]
			SafeCoTaskMemString GetName();

			/// <summary>
			/// Sets the <c>Name</c> property of the visual.
			/// </summary>
			/// <param name="name">The name of the visual. A <c>NULL</c> pointer clears the <c>Name</c> property.</param>
			/// <remarks>
			/// <para>Names must be unique.</para>
			/// <para>Clearing the <c>Name</c> property by passing a <c>NULL</c> pointer in name sets the <c>IsHyperlinkTarget</c> property to <c>FALSE</c>.</para>
			/// </remarks>
			// https://docs.microsoft.com/en-us/windows/win32/api/xpsobjectmodel/nf-xpsobjectmodel-ixpsomvisual-setname
			// HRESULT SetName( LPCWSTR name );
			[MethodImpl(MethodImplOptions.InternalCall)]
			void SetName([In, MarshalAs(UnmanagedType.LPWStr)] string name);

			/// <summary>Gets a value that indicates whether the visual is the target of a hyperlink.</summary>
			/// <returns>
			/// <para>The Boolean value that indicates whether the visual is the target of a hyperlink.</para>
			/// <list type="table">
			/// <listheader>
			/// <term>Value</term>
			/// <term>Meaning</term>
			/// </listheader>
			/// <item>
			/// <term>TRUE</term>
			/// <term>The visual is the target of a hyperlink.</term>
			/// </item>
			/// <item>
			/// <term>FALSE</term>
			/// <term>The visual is not the target of a hyperlink.</term>
			/// </item>
			/// </list>
			/// </returns>
			// https://docs.microsoft.com/en-us/windows/win32/api/xpsobjectmodel/nf-xpsobjectmodel-ixpsomvisual-getishyperlinktarget
			// HRESULT GetIsHyperlinkTarget( BOOL *isHyperlink );
			[MethodImpl(MethodImplOptions.InternalCall)]
			[return: MarshalAs(UnmanagedType.Bool)]
			bool GetIsHyperlinkTarget();

			/// <summary>
			/// Specifies whether the visual is the target of a hyperlink.
			/// </summary>
			/// <param name="isHyperlink"><para>The Boolean value that specifies whether the visual is the target of a hyperlink.</para>
			/// <list type="table">
			///   <listheader>
			///     <term>Value</term>
			///     <term>Meaning</term>
			///   </listheader>
			///   <item>
			///     <term>TRUE</term>
			///     <term>The visual is the target of a hyperlink.</term>
			///   </item>
			///   <item>
			///     <term>FALSE</term>
			///     <term>The visual is not the target of a hyperlink.</term>
			///   </item>
			/// </list></param>
			/// <remarks>
			/// The visual must be named before it can be set as the target of a hyperlink.
			/// </remarks>
			// https://docs.microsoft.com/en-us/windows/win32/api/xpsobjectmodel/nf-xpsobjectmodel-ixpsomvisual-setishyperlinktarget
			// HRESULT SetIsHyperlinkTarget( BOOL isHyperlink );
			[MethodImpl(MethodImplOptions.InternalCall)]
			void SetIsHyperlinkTarget([In, MarshalAs(UnmanagedType.Bool)] bool isHyperlink);

			/// <summary>Gets a pointer to the IUri interface to which this visual object links.</summary>
			/// <returns>A pointer to the IUri interface that contains the destination URI for the link. If a URI has not been set for this object, a <c>NULL</c> pointer is returned.</returns>
			// https://docs.microsoft.com/en-us/windows/win32/api/xpsobjectmodel/nf-xpsobjectmodel-ixpsomvisual-gethyperlinknavigateuri
			// HRESULT GetHyperlinkNavigateUri( IUri **hyperlinkUri );
			[MethodImpl(MethodImplOptions.InternalCall)]
			IUri GetHyperlinkNavigateUri();

			/// <summary>
			/// Sets the destination URI of the visual's hyperlink.
			/// </summary>
			/// <param name="hyperlinkUri">The IUri interface that contains the destination URI of the visual's hyperlink.</param>
			/// <remarks>
			/// Setting an object's URI makes the object a hyperlink. When activated or clicked, the object will navigate to the destination that is specified by the URI in hyperlinkUri.
			/// </remarks>
			// https://docs.microsoft.com/en-us/windows/win32/api/xpsobjectmodel/nf-xpsobjectmodel-ixpsomvisual-sethyperlinknavigateuri
			// HRESULT SetHyperlinkNavigateUri( IUri *hyperlinkUri );
			[MethodImpl(MethodImplOptions.InternalCall)]
			void SetHyperlinkNavigateUri([In] IUri hyperlinkUri);

			/// <summary>Gets the <c>Language</c> property of the visual and of its contents.</summary>
			/// <returns>The language string that specifies the language of the page. If a language has not been set, a <c>NULL</c> pointer is returned.</returns>
			/// <remarks>
			/// <para>The <c>Language</c> property that is set by this method specifies the language of the resource content.</para>
			/// <para>Internet Engineering Task Force (IETF) RFC 3066 specifies the recommended encoding for the <c>Language</c> property.</para>
			/// </remarks>
			// https://docs.microsoft.com/en-us/windows/win32/api/xpsobjectmodel/nf-xpsobjectmodel-ixpsomvisual-getlanguage
			// HRESULT GetLanguage( LPWSTR *language );
			[MethodImpl(MethodImplOptions.InternalCall)]
			SafeCoTaskMemString GetLanguage();

			/// <summary>
			/// Sets the <c>Language</c> property of the visual.
			/// </summary>
			/// <param name="language">The language string that specifies the language of the visual and of its contents. A <c>NULL</c> pointer clears the <c>Language</c> property.</param>
			/// <remarks>
			/// The recommended encoding for the <c>Language</c> property is specified in Internet Engineering Task Force (IETF) RFC 3066r.
			/// </remarks>
			// https://docs.microsoft.com/en-us/windows/win32/api/xpsobjectmodel/nf-xpsobjectmodel-ixpsomvisual-setlanguage
			// HRESULT SetLanguage( LPCWSTR language );
			[MethodImpl(MethodImplOptions.InternalCall)]
			void SetLanguage([In, MarshalAs(UnmanagedType.LPWStr)] string language);
		}

		[ComImport, Guid("97E294AF-5B37-46B4-8057-874D2F64119B"), InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
		public interface IXpsOMVisualBrush : IXpsOMTileBrush
		{
			/// <summary>Gets the <c>IUnknown</c> interface of the parent.</summary>
			/// <returns>A pointer to the <c>IUnknown</c> interface of the parent.</returns>
			// https://docs.microsoft.com/en-us/windows/win32/api/xpsobjectmodel/nf-xpsobjectmodel-ixpsomshareable-getowner
			// HRESULT GetOwner( IUnknown **owner );
			[return: MarshalAs(UnmanagedType.IUnknown)]
			new object GetOwner();

			/// <summary>Gets the object type of the interface.</summary>
			/// <returns>The XPS_OBJECT_TYPE value that describes the interface that is derived from IXpsOMShareable.</returns>
			// https://docs.microsoft.com/en-us/windows/win32/api/xpsobjectmodel/nf-xpsobjectmodel-ixpsomshareable-gettype
			// HRESULT GetType( XPS_OBJECT_TYPE *type );
			new XPS_OBJECT_TYPE GetType();

			/// <summary>Gets the opacity of the brush.</summary>
			/// <returns>
			/// The opacity value of the brush.
			/// </returns>
			/// <remarks>opacity is expressed as a value between 0.0 and 1.0; 0.0 indicates that the brush is completely transparent, 0.5 that it is 50 percent opaque, and 1.0 that it is completely opaque.</remarks>
			// https://docs.microsoft.com/en-us/windows/win32/api/xpsobjectmodel/nf-xpsobjectmodel-ixpsombrush-getopacity
			// HRESULT GetOpacity( FLOAT *opacity );
			new float GetOpacity();

			/// <summary>Sets the opacity of the brush.</summary>
			/// <param name="opacity">The opacity value of the brush.</param>
			/// <remarks>
			/// <para>opacity is expressed as a value between 0.0 and 1.0; 0.0 indicates that the brush is completely transparent, 0.5 that it is 50 percent opaque, and 1.0 that it is completely opaque.</para>
			/// <para>If opacity is less than 0.0 or greater than 1.0, the method returns an error.</para>
			/// </remarks>
			// https://docs.microsoft.com/en-us/windows/win32/api/xpsobjectmodel/nf-xpsobjectmodel-ixpsombrush-setopacity
			// HRESULT SetOpacity( FLOAT opacity );
			new void SetOpacity([In] float opacity);

			/// <summary>Gets a pointer to the IXpsOMMatrixTransform interface that contains the resolved matrix transform for the brush.</summary>
			/// <returns>
			/// <para>A pointer to the IXpsOMMatrixTransform interface that contains the resolved matrix transform for the brush. If a matrix transform has not been set, a <c>NULL</c> pointer is returned.</para>
			/// <para>The value that is returned in this parameter depends on which method has most recently been called to set the transform.</para>
			/// <list type="table">
			/// <listheader>
			/// <term>Most recent method called</term>
			/// <term>Object that is returned in transform</term>
			/// </listheader>
			/// <item>
			/// <term>SetTransformLocal</term>
			/// <term>The transform that is set by SetTransformLocal.</term>
			/// </item>
			/// <item>
			/// <term>SetTransformLookup</term>
			/// <term>The transform which is retrieved, using a lookup key that matches the key that is set by SetTransformLookup, from the resource directory.</term>
			/// </item>
			/// <item>
			/// <term>Neither SetTransformLocal nor SetTransformLookup has been called yet.</term>
			/// <term>NULL pointer.</term>
			/// </item>
			/// </list>
			/// </returns>
			/// <remarks>The transform determines how the output area is transformed before the brush image is rendered in the path, stroke, or glyph that is using the tile brush.</remarks>
			// https://docs.microsoft.com/en-us/windows/win32/api/xpsobjectmodel/nf-xpsobjectmodel-ixpsomtilebrush-gettransform
			// HRESULT GetTransform( IXpsOMMatrixTransform **transform );
			new IXpsOMMatrixTransform GetTransform();

			/// <summary>Gets a pointer to the IXpsOMMatrixTransform interface that contains the local, unshared resolved matrix transform for the brush.</summary>
			/// <returns>
			/// <para>A pointer to the IXpsOMMatrixTransform interface that contains the local, unshared resolved matrix transform for the brush. If a local matrix transform has not been set or if a matrix transform lookup key has been set, a <c>NULL</c> pointer is returned.</para>
			/// <list type="table">
			/// <listheader>
			/// <term>Most recent method called</term>
			/// <term>Object that is returned in transform</term>
			/// </listheader>
			/// <item>
			/// <term>SetTransformLocal</term>
			/// <term>The transform that is set by SetTransformLocal.</term>
			/// </item>
			/// <item>
			/// <term>SetTransformLookup</term>
			/// <term>NULL pointer.</term>
			/// </item>
			/// <item>
			/// <term>Neither SetTransformLocal nor SetTransformLookup has been called yet.</term>
			/// <term>NULL pointer.</term>
			/// </item>
			/// </list>
			/// </returns>
			/// <remarks>The transform determines how the output area is transformed before the brush image is rendered in the path, stroke, or glyph that is using the tile brush.</remarks>
			// https://docs.microsoft.com/en-us/windows/win32/api/xpsobjectmodel/nf-xpsobjectmodel-ixpsomtilebrush-gettransformlocal
			// HRESULT GetTransformLocal( IXpsOMMatrixTransform **transform );
			new IXpsOMMatrixTransform GetTransformLocal();

			/// <summary>
			/// Sets the IXpsOMMatrixTransform interface pointer to a local, unshared matrix transform.
			/// </summary>
			/// <param name="transform">A pointer to the IXpsOMMatrixTransform interface to be set as the local, unshared matrix transform. If a local transform has been set, a <c>NULL</c> pointer will release it.</param>
			/// <remarks>
			/// <para>The transform determines how the output area is transformed before the brush image is rendered in the path, stroke, or glyph that is using the tile brush.</para>
			/// <para>After you call <c>SetTransformLocal</c>, the transform lookup key is released and GetTransformLookup returns a <c>NULL</c> pointer in the key parameter. The table that follows explains the relationship between the local and lookup values of this property.</para>
			/// <list type="table">
			///   <listheader>
			///     <term>Most recent method called</term>
			///     <term>Object that is returned in transform by GetTransform</term>
			///     <term>Object that is returned in transform by GetTransformLocal</term>
			///     <term>String that is returned in key by GetTransformLookup</term>
			///   </listheader>
			///   <item>
			///     <term>SetTransformLocal (this method)</term>
			///     <term>The transform that is set by SetTransformLocal.</term>
			///     <term>The transform that is set by SetTransformLocal.</term>
			///     <term>NULL pointer.</term>
			///   </item>
			///   <item>
			///     <term>SetTransformLookup</term>
			///     <term>The transform which is retrieved, using a lookup key that matches the key that is set by SetTransformLookup, from the resource directory.</term>
			///     <term>NULL pointer.</term>
			///     <term>The lookup key that is set by SetTransformLookup.</term>
			///   </item>
			///   <item>
			///     <term>Neither SetTransformLocal nor SetTransformLookup has been called yet.</term>
			///     <term>NULL pointer.</term>
			///     <term>NULL pointer.</term>
			///     <term>NULL pointer.</term>
			///   </item>
			/// </list>
			/// </remarks>
			// https://docs.microsoft.com/en-us/windows/win32/api/xpsobjectmodel/nf-xpsobjectmodel-ixpsomtilebrush-settransformlocal
			// HRESULT SetTransformLocal( IXpsOMMatrixTransform *transform );
			new void SetTransformLocal([In] IXpsOMMatrixTransform transform);

			/// <summary>Gets the lookup key that identifies the IXpsOMMatrixTransform interface in a resource dictionary that contains the resolved matrix transform for the brush.</summary>
			/// <returns>
			/// <para>The lookup key that identifies the IXpsOMMatrixTransform interface in a resource dictionary that contains the resolved matrix transform for the brush. If a matrix transform lookup key has not been set or if a local matrix transform has been set, a <c>NULL</c> pointer is returned.</para>
			/// <list type="table">
			/// <listheader>
			/// <term>Most recent method called</term>
			/// <term>Object that is returned in key</term>
			/// </listheader>
			/// <item>
			/// <term>SetTransformLocal</term>
			/// <term>NULL pointer.</term>
			/// </item>
			/// <item>
			/// <term>SetTransformLookup</term>
			/// <term>The lookup key set by SetTransformLookup.</term>
			/// </item>
			/// <item>
			/// <term>Neither SetTransformLocal nor SetTransformLookup has been called yet.</term>
			/// <term>NULL pointer.</term>
			/// </item>
			/// </list>
			/// </returns>
			/// <remarks>
			/// <para>The transform determines how the output area is transformed before the brush image is rendered in the path, stroke, or glyph that is using the tile brush.</para>
			/// </remarks>
			// https://docs.microsoft.com/en-us/windows/win32/api/xpsobjectmodel/nf-xpsobjectmodel-ixpsomtilebrush-gettransformlookup
			// HRESULT GetTransformLookup( LPWSTR *key );
			new SafeCoTaskMemString GetTransformLookup();

			/// <summary>
			/// Sets the lookup key name of a shared matrix transform that will be used as the transform for this brush.The shared matrix transform that is referenced by the lookup key is stored in the resource dictionary.
			/// </summary>
			/// <param name="key">A string variable that contains the lookup key name of a shared matrix transform in the resource dictionary. If a lookup key has already been set, a <c>NULL</c> pointer will clear it.</param>
			/// <remarks>
			/// <para>The transform is applied before the brush image is rendered in the path, stroke, or glyph that is using the tile brush. The tile brush has only one transform, which can be local or remote.</para>
			/// <para>After you call <c>SetTransformLookup</c>, the local transform is released and GetTransformLocal returns a <c>NULL</c> pointer in the transform parameter. The table that follows explains the relationship between the local and lookup values of this property.</para>
			/// <list type="table">
			///   <listheader>
			///     <term>Most recent method called</term>
			///     <term>Object that is returned in transform by GetTransform</term>
			///     <term>Object that is returned in transform by GetTransformLocal</term>
			///     <term>String that is returned in key by GetTransformLookup</term>
			///   </listheader>
			///   <item>
			///     <term>SetTransformLocal</term>
			///     <term>The transform that is set by SetTransformLocal.</term>
			///     <term>The transform that is set by SetTransformLocal.</term>
			///     <term>NULL pointer.</term>
			///   </item>
			///   <item>
			///     <term>SetTransformLookup (this method)</term>
			///     <term>The transform which is retrieved—using a lookup key that matches the key that is set by SetTransformLookup— from the resource directory.</term>
			///     <term>NULL pointer.</term>
			///     <term>The lookup key that is set by SetTransformLookup.</term>
			///   </item>
			///   <item>
			///     <term>Neither SetTransformLocal nor SetTransformLookup has been called yet.</term>
			///     <term>NULL pointer.</term>
			///     <term>NULL pointer.</term>
			///     <term>NULL pointer.</term>
			///   </item>
			/// </list>
			/// </remarks>
			// https://docs.microsoft.com/en-us/windows/win32/api/xpsobjectmodel/nf-xpsobjectmodel-ixpsomtilebrush-settransformlookup
			// HRESULT SetTransformLookup( LPCWSTR key );
			new void SetTransformLookup([In, MarshalAs(UnmanagedType.LPWStr)] string key);

			/// <summary>Gets the portion of the source image to be used by the tile.</summary>
			/// <returns>The XPS_RECT structure that describes the area of the source content to be used by the tile.</returns>
			/// <remarks>
			/// <para>The brush's viewbox specifies the portion of a source image or visual to be used as the tile image.</para>
			/// <para>The coordinates of the brush's viewbox are relative to the source content, such that (0,0) specifies the upper-left corner of the source content. For images, dimensions specified by the brush's viewbox are expressed in the units of 1/96". The corresponding pixel coordinates in the source image are calculated as follows:</para>
			/// <para>In the illustration that follows, the image on the left is an example of a source image, the image in the center shows the selected viewbox, and the image on the right shows the resulting brush.</para>
			/// <para>If the source image resolution is 96 by 96 dots per inch and image dimensions are 96 by 96 pixels, the values of fields in the viewbox parameter would be:</para>
			/// <para>The preceding parameter values correspond to the source image as:</para>
			/// </remarks>
			// https://docs.microsoft.com/en-us/windows/win32/api/xpsobjectmodel/nf-xpsobjectmodel-ixpsomtilebrush-getviewbox
			// HRESULT GetViewbox( XPS_RECT *viewbox );
			new XPS_RECT GetViewbox();

			/// <summary>
			/// Sets the portion of the source content to be used as the tile image.
			/// </summary>
			/// <param name="viewbox">An XPS_RECT structure that describes the portion of the source content to be used as the tile image.</param>
			/// <remarks>
			/// <para>The brush's viewbox specifies the portion of a source image or visual to be used as the tile image.</para>
			/// <para>The coordinates of the brush's viewbox are relative to the source content, such that (0,0) specifies the upper-left corner of the source content. For images, dimensions specified by the brush's viewbox are expressed in the units of 1/96". The corresponding pixel coordinates in the source image are calculated as follows:</para>
			/// <para>In the illustration that follows, the image on the left is an example of a source image, while that on the right is the source image with the selected viewbox for the brush shown as a red rectangle. In this example, the part of the source image that is used as the content for the tile brush is the area within the red rectangle. The shaded area of the image is not used by the brush.</para>
			/// <para>If the source image resolution is 96 by 96 dots per inch and image dimensions are 96 by 96 pixels, the values of fields in the viewbox parameter would be:</para>
			/// <para>The preceding parameter values correspond to the source image as:</para>
			/// </remarks>
			// https://docs.microsoft.com/en-us/windows/win32/api/xpsobjectmodel/nf-xpsobjectmodel-ixpsomtilebrush-setviewbox
			// HRESULT SetViewbox( const XPS_RECT *viewbox );
			new void SetViewbox(in XPS_RECT viewbox);

			/// <summary>Gets the portion of the destination geometry that is covered by a single tile.</summary>
			/// <returns>The XPS_RECT structure that describes the portion of the destination geometry that is covered by a single tile.</returns>
			/// <remarks>The viewport is the portion of the output area where the first tile is drawn. In the illustration, the viewport is outlined by the purple rectangle inside the red, dotted rectangle. The tile mode of the brush determines how the rest of the tiles are drawn in the output area.</remarks>
			// https://docs.microsoft.com/en-us/windows/win32/api/xpsobjectmodel/nf-xpsobjectmodel-ixpsomtilebrush-getviewport
			// HRESULT GetViewport( XPS_RECT *viewport );
			new XPS_RECT GetViewport();

			/// <summary>
			/// Sets the portion of the destination geometry that is covered by a single tile.
			/// </summary>
			/// <param name="viewport">An XPS_RECT structure that describes the portion of the destination geometry that is covered by a single tile.</param>
			/// <remarks>
			/// The viewport is the portion of the output area where the tile is drawn. In the following illustration, the viewport is outlined by the blue rectangle inside the red, dotted rectangle. The tile mode of the brush determines how other tiles are drawn in the output area.
			/// </remarks>
			// https://docs.microsoft.com/en-us/windows/win32/api/xpsobjectmodel/nf-xpsobjectmodel-ixpsomtilebrush-setviewport
			// HRESULT SetViewport( const XPS_RECT *viewport );
			new void SetViewport(in XPS_RECT viewport);

			/// <summary>Gets the XPS_TILE_MODE value that describes the tile mode of the brush.</summary>
			/// <returns>The XPS_TILE_MODE value that describes the tile mode of the brush.</returns>
			/// <remarks>The tile mode determines how the tile image is repeated to fill the output area. If the tile mode value is XPS_TILE_MODE_NONE, the tile image is drawn only once. The following illustration shows examples of how the tile image appears in several tile modes.</remarks>
			// https://docs.microsoft.com/en-us/windows/win32/api/xpsobjectmodel/nf-xpsobjectmodel-ixpsomtilebrush-gettilemode
			// HRESULT GetTileMode( XPS_TILE_MODE *tileMode );
			new XPS_TILE_MODE GetTileMode();

			/// <summary>
			/// Sets the XPS_TILE_MODE value that describes the tiling mode of the brush.
			/// </summary>
			/// <param name="tileMode">The XPS_TILE_MODE value to be set.</param>
			/// <remarks>
			/// The tile mode determines how the tile image is repeated to fill the output area. If the tile mode value is XPS_TILE_MODE_NONE, the tile image is drawn only once.
			/// </remarks>
			// https://docs.microsoft.com/en-us/windows/win32/api/xpsobjectmodel/nf-xpsobjectmodel-ixpsomtilebrush-settilemode
			// HRESULT SetTileMode( XPS_TILE_MODE tileMode );
			new void SetTileMode([In] XPS_TILE_MODE tileMode);

			IXpsOMVisualBrush Clone();

			IXpsOMVisual GetVisual();

			IXpsOMVisual GetVisualLocal();

			SafeCoTaskMemString GetVisualLookup();

			void SetVisualLocal([In] IXpsOMVisual visual);

			void SetVisualLookup([In, MarshalAs(UnmanagedType.LPWStr)] string lookup);
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
			void InsertAt([In] uint index, [In] IXpsOMVisual @object);

			[MethodImpl(MethodImplOptions.InternalCall)]
			void RemoveAt([In] uint index);

			[MethodImpl(MethodImplOptions.InternalCall)]
			void SetAt([In] uint index, [In] IXpsOMVisual @object);

			[MethodImpl(MethodImplOptions.InternalCall)]
			void Append([In] IXpsOMVisual @object);
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

		[ClassInterface(ClassInterfaceType.None), ComImport, Guid("7E4A23E2-B969-4761-BE35-1A8CED58E323")]
		public class XpsOMThumbnailGenerator
		{
		}
	}
}