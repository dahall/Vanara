namespace Vanara.PInvoke;

public static partial class D2d1
{
	/// <summary>Determines what gamma is used for interpolation and blending.</summary>
	// https://learn.microsoft.com/en-us/windows/win32/api/d2d1_3/ne-d2d1_3-d2d1_gamma1 typedef enum D2D1_GAMMA1 { D2D1_GAMMA1_G22,
	// D2D1_GAMMA1_G10, D2D1_GAMMA1_G2084 = 2, D2D1_GAMMA1_FORCE_DWORD = 0xffffffff } ;
	[PInvokeData("d2d1_3.h", MSDNShortId = "NE:d2d1_3.D2D1_GAMMA1")]
	public enum D2D1_GAMMA1 : uint
	{
		/// <summary>Colors are manipulated in 2.2 gamma color space.</summary>
		D2D1_GAMMA1_G22,

		/// <summary>Colors are manipulated in 1.0 gamma color space.</summary>
		D2D1_GAMMA1_G10,

		/// <summary>
		/// <para>Value:</para>
		/// <para>2</para>
		/// <para>Colors are manipulated in ST.2084 PQ gamma color space.</para>
		/// </summary>
		D2D1_GAMMA1_G2084,
	}

	/// <summary>Specifies the appearance of the ink nib (pen tip) as part of an D2D1_INK_STYLE_PROPERTIES structure.</summary>
	// https://learn.microsoft.com/en-us/windows/win32/api/d2d1_3/ne-d2d1_3-d2d1_ink_nib_shape typedef enum D2D1_INK_NIB_SHAPE {
	// D2D1_INK_NIB_SHAPE_ROUND = 0, D2D1_INK_NIB_SHAPE_SQUARE = 1, D2D1_INK_NIB_SHAPE_FORCE_DWORD = 0xffffffff } ;
	[PInvokeData("d2d1_3.h", MSDNShortId = "NE:d2d1_3.D2D1_INK_NIB_SHAPE")]
	public enum D2D1_INK_NIB_SHAPE
	{
		/// <summary>
		/// <para>Value:</para>
		/// <para>0</para>
		/// <para>The pen tip is circular.</para>
		/// </summary>
		D2D1_INK_NIB_SHAPE_ROUND,

		/// <summary>
		/// <para>Value:</para>
		/// <para>1</para>
		/// <para>The pen tip is square.</para>
		/// </summary>
		D2D1_INK_NIB_SHAPE_SQUARE,
	}

	/// <summary>Specifies the flip and rotation at which an image appears.</summary>
	// https://learn.microsoft.com/en-us/windows/win32/api/d2d1_3/ne-d2d1_3-d2d1_orientation typedef enum D2D1_ORIENTATION {
	// D2D1_ORIENTATION_DEFAULT = 1, D2D1_ORIENTATION_FLIP_HORIZONTAL = 2, D2D1_ORIENTATION_ROTATE_CLOCKWISE180 = 3,
	// D2D1_ORIENTATION_ROTATE_CLOCKWISE180_FLIP_HORIZONTAL = 4, D2D1_ORIENTATION_ROTATE_CLOCKWISE90_FLIP_HORIZONTAL = 5,
	// D2D1_ORIENTATION_ROTATE_CLOCKWISE270 = 6, D2D1_ORIENTATION_ROTATE_CLOCKWISE270_FLIP_HORIZONTAL = 7,
	// D2D1_ORIENTATION_ROTATE_CLOCKWISE90 = 8, D2D1_ORIENTATION_FORCE_DWORD = 0xffffffff } ;
	[PInvokeData("d2d1_3.h", MSDNShortId = "NE:d2d1_3.D2D1_ORIENTATION")]
	public enum D2D1_ORIENTATION : uint
	{
		/// <summary>
		/// <para>Value:</para>
		/// <para>1</para>
		/// <para>The orientation is unchanged.</para>
		/// </summary>
		D2D1_ORIENTATION_DEFAULT = 1,

		/// <summary>
		/// <para>Value:</para>
		/// <para>2</para>
		/// <para>The image is flipped horizontally.</para>
		/// </summary>
		D2D1_ORIENTATION_FLIP_HORIZONTAL,

		/// <summary>
		/// <para>Value:</para>
		/// <para>3</para>
		/// <para>The image is rotated clockwise 180 degrees.</para>
		/// </summary>
		D2D1_ORIENTATION_ROTATE_CLOCKWISE180,

		/// <summary>
		/// <para>Value:</para>
		/// <para>4</para>
		/// <para>The image is rotated clockwise 180 degrees, then flipped horizontally.</para>
		/// </summary>
		D2D1_ORIENTATION_ROTATE_CLOCKWISE180_FLIP_HORIZONTAL,

		/// <summary>
		/// <para>Value:</para>
		/// <para>5</para>
		/// <para>The image is rotated clockwise 90 degrees, then flipped horizontally.</para>
		/// </summary>
		D2D1_ORIENTATION_ROTATE_CLOCKWISE90_FLIP_HORIZONTAL,

		/// <summary>
		/// <para>Value:</para>
		/// <para>6</para>
		/// <para>The image is rotated clockwise 270 degrees.</para>
		/// </summary>
		D2D1_ORIENTATION_ROTATE_CLOCKWISE270,

		/// <summary>
		/// <para>Value:</para>
		/// <para>7</para>
		/// <para>The image is rotated clockwise 270 degrees, then flipped horizontally.</para>
		/// </summary>
		D2D1_ORIENTATION_ROTATE_CLOCKWISE270_FLIP_HORIZONTAL,

		/// <summary>
		/// <para>Value:</para>
		/// <para>8</para>
		/// <para>The image is rotated clockwise 90 degrees.</para>
		/// </summary>
		D2D1_ORIENTATION_ROTATE_CLOCKWISE90,
	}

	/// <summary>Specifies how to render gradient mesh edges.</summary>
	// https://learn.microsoft.com/en-us/windows/win32/api/d2d1_3/ne-d2d1_3-d2d1_patch_edge_mode typedef enum D2D1_PATCH_EDGE_MODE {
	// D2D1_PATCH_EDGE_MODE_ALIASED = 0, D2D1_PATCH_EDGE_MODE_ANTIALIASED = 1, D2D1_PATCH_EDGE_MODE_ALIASED_INFLATED = 2,
	// D2D1_PATCH_EDGE_MODE_FORCE_DWORD = 0xffffffff } ;
	[PInvokeData("d2d1_3.h", MSDNShortId = "NE:d2d1_3.D2D1_PATCH_EDGE_MODE")]
	public enum D2D1_PATCH_EDGE_MODE : uint
	{
		/// <summary>
		/// <para>Value:</para>
		/// <para>0</para>
		/// <para>Render this patch edge aliased. Use this value for the internal edges of your gradient mesh.</para>
		/// </summary>
		D2D1_PATCH_EDGE_MODE_ALIASED,

		/// <summary>
		/// <para>Value:</para>
		/// <para>1</para>
		/// <para>Render this patch edge antialiased. Use this value for the external (boundary) edges of your mesh.</para>
		/// </summary>
		D2D1_PATCH_EDGE_MODE_ANTIALIASED,

		/// <summary>
		/// <para>Value:</para>
		/// <para>2</para>
		/// <para>
		/// Render this patch edge aliased and also slightly inflated. Use this for the internal edges of your gradient mesh when there
		/// could be t-junctions among patches.
		/// </para>
		/// <para>Inflating the internal edges mitigates seams that can appear along those junctions.</para>
		/// </summary>
		D2D1_PATCH_EDGE_MODE_ALIASED_INFLATED,
	}

	/// <summary>Option flags for transformed image sources.</summary>
	// https://learn.microsoft.com/en-us/windows/win32/api/d2d1_3/ne-d2d1_3-d2d1_transformed_image_source_options typedef enum
	// D2D1_TRANSFORMED_IMAGE_SOURCE_OPTIONS { D2D1_TRANSFORMED_IMAGE_SOURCE_OPTIONS_NONE = 0,
	// D2D1_TRANSFORMED_IMAGE_SOURCE_OPTIONS_DISABLE_DPI_SCALE = 1, D2D1_TRANSFORMED_IMAGE_SOURCE_OPTIONS_FORCE_DWORD = 0xffffffff } ;
	[PInvokeData("d2d1_3.h", MSDNShortId = "NE:d2d1_3.D2D1_TRANSFORMED_IMAGE_SOURCE_OPTIONS")]
	[Flags]
	public enum D2D1_TRANSFORMED_IMAGE_SOURCE_OPTIONS : uint
	{
		/// <summary>
		/// <para>Value:</para>
		/// <para>0</para>
		/// <para>No option flags.</para>
		/// </summary>
		D2D1_TRANSFORMED_IMAGE_SOURCE_OPTIONS_NONE,

		/// <summary>
		/// <para>Value:</para>
		/// <para>1</para>
		/// <para>Prevents the image source from being automatically scaled (by a ratio of the context DPI divided by 96) while drawn.</para>
		/// </summary>
		D2D1_TRANSFORMED_IMAGE_SOURCE_OPTIONS_DISABLE_DPI_SCALE,
	}

	/// <summary>Specifies the pixel snapping policy when rendering color bitmap glyphs.</summary>
	// https://learn.microsoft.com/en-us/windows/win32/api/d2d1_3/ne-d2d1_3-d2d1_color_bitmap_glyph_snap_option
	// typedef enum D2D1_COLOR_BITMAP_GLYPH_SNAP_OPTION { D2D1_COLOR_BITMAP_GLYPH_SNAP_OPTION_DEFAULT = 0, D2D1_COLOR_BITMAP_GLYPH_SNAP_OPTION_DISABLE = 1, D2D1_COLOR_BITMAP_GLYPH_SNAP_OPTION_FORCE_DWORD = 0xffffffff } ;
	[PInvokeData("d2d1_3.h", MSDNShortId = "NE:d2d1_3.D2D1_COLOR_BITMAP_GLYPH_SNAP_OPTION")]
	public enum D2D1_COLOR_BITMAP_GLYPH_SNAP_OPTION : uint
	{
		/// <summary>
		///   <para>Value:</para>
		///   <para>0</para>
		///   <para>Color bitmap glyph positions are snapped to the nearest pixel if the bitmap</para>
		///   <para>resolution matches that of the device context.</para>
		/// </summary>
		D2D1_COLOR_BITMAP_GLYPH_SNAP_OPTION_DEFAULT,
		/// <summary>
		///   <para>Value:</para>
		///   <para>1</para>
		///   <para>Color bitmap glyph positions are not snapped.</para>
		/// </summary>
		D2D1_COLOR_BITMAP_GLYPH_SNAP_OPTION_DISABLE,
	}

	/// <summary>Specifies which way a color profile is defined.</summary>
	// https://learn.microsoft.com/en-us/windows/win32/api/d2d1_3/ne-d2d1_3-d2d1_color_context_type
	// typedef enum D2D1_COLOR_CONTEXT_TYPE { D2D1_COLOR_CONTEXT_TYPE_ICC = 0, D2D1_COLOR_CONTEXT_TYPE_SIMPLE = 1, D2D1_COLOR_CONTEXT_TYPE_DXGI = 2, D2D1_COLOR_CONTEXT_TYPE_FORCE_DWORD = 0xffffffff } ;
	[PInvokeData("d2d1_3.h", MSDNShortId = "NE:d2d1_3.D2D1_COLOR_CONTEXT_TYPE")]
	public enum D2D1_COLOR_CONTEXT_TYPE : uint
	{
		/// <summary>
		///   <para>Value:</para>
		///   <para>0</para>
		/// </summary>
		D2D1_COLOR_CONTEXT_TYPE_ICC,
		/// <summary>
		///   <para>Value:</para>
		///   <para>1</para>
		/// </summary>
		D2D1_COLOR_CONTEXT_TYPE_SIMPLE,
		/// <summary>
		///   <para>Value:</para>
		///   <para>2</para>
		/// </summary>
		D2D1_COLOR_CONTEXT_TYPE_DXGI,
	}

	/// <summary>Option flags controlling primary conversion performed by <c>CreateImageSourceFromDxgi</c>, if any.</summary>
	// https://learn.microsoft.com/en-us/windows/win32/api/d2d1_3/ne-d2d1_3-d2d1_image_source_from_dxgi_options
	// typedef enum D2D1_IMAGE_SOURCE_FROM_DXGI_OPTIONS { D2D1_IMAGE_SOURCE_FROM_DXGI_OPTIONS_NONE = 0, D2D1_IMAGE_SOURCE_FROM_DXGI_OPTIONS_LOW_QUALITY_PRIMARY_CONVERSION = 1, D2D1_IMAGE_SOURCE_FROM_DXGI_OPTIONS_FORCE_DWORD = 0xffffffff } ;
	[PInvokeData("d2d1_3.h", MSDNShortId = "NE:d2d1_3.D2D1_IMAGE_SOURCE_FROM_DXGI_OPTIONS")]
	[Flags]
	public enum D2D1_IMAGE_SOURCE_FROM_DXGI_OPTIONS : uint
	{
		/// <summary>
		///   <para>Value:</para>
		///   <para>0</para>
		///   <para>No primary conversion is performed.</para>
		/// </summary>
		D2D1_IMAGE_SOURCE_FROM_DXGI_OPTIONS_NONE,
		/// <summary>
		///   <para>Value:</para>
		///   <para>1</para>
		///   <para>Low quality primary conversion is performed.</para>
		/// </summary>
		D2D1_IMAGE_SOURCE_FROM_DXGI_OPTIONS_LOW_QUALITY_PRIMARY_CONVERSION,
	}

	/// <summary>Controls option flags for a new ID2D1ImageSource when it is created.</summary>
	/// <remarks>D2D1_IMAGE_SOURCE_CREATION_OPTIONS_RELEASE_SOURCE causes the image source to not retain a reference to the source object used to create it. It can decrease the quality and efficiency of printing.</remarks>
	// https://learn.microsoft.com/en-us/windows/win32/api/d2d1_3/ne-d2d1_3-d2d1_image_source_loading_options
	// typedef enum D2D1_IMAGE_SOURCE_LOADING_OPTIONS { D2D1_IMAGE_SOURCE_LOADING_OPTIONS_NONE = 0, D2D1_IMAGE_SOURCE_LOADING_OPTIONS_RELEASE_SOURCE = 1, D2D1_IMAGE_SOURCE_LOADING_OPTIONS_CACHE_ON_DEMAND = 2, D2D1_IMAGE_SOURCE_LOADING_OPTIONS_FORCE_DWORD = 0xffffffff } ;
	[PInvokeData("d2d1_3.h", MSDNShortId = "NE:d2d1_3.D2D1_IMAGE_SOURCE_LOADING_OPTIONS")]
	[Flags]
	public enum D2D1_IMAGE_SOURCE_LOADING_OPTIONS : uint
	{
		/// <summary>
		///   <para>Value:</para>
		///   <para>0</para>
		///   <para>No options are used.</para>
		/// </summary>
		D2D1_IMAGE_SOURCE_LOADING_OPTIONS_NONE,
		/// <summary>
		///   <para>Value:</para>
		///   <para>1</para>
		///   <para>Indicates the image source should release its reference to the WIC bitmap source after it has initialized.</para>
		///   <para>By default, the image source retains a reference to the WIC bitmap source for the lifetime of the object to enable quality and speed optimizations for printing.</para>
		///   <para>This option disables that optimization.</para>
		/// </summary>
		D2D1_IMAGE_SOURCE_LOADING_OPTIONS_RELEASE_SOURCE,
		/// <summary>
		///   <para>Value:</para>
		///   <para>2</para>
		///   <para>Indicates the image source should only populate subregions of the image cache on-demand. You can control this behavior using</para>
		///   <para>the</para>
		///   <para>EnsureCached</para>
		///   <para>and</para>
		///   <para>TrimCache</para>
		///   <para>methods.</para>
		///   <para>This options provides the ability to improve memory usage by only keeping needed portions of the image in memory.</para>
		///   <para>This option requires that the image source has a reference to the WIC bitmap source, and is incompatible with D2D1_IMAGE_SOURCE_LOADING_OPTIONS_RELEASE_SOURCE.</para>
		/// </summary>
		D2D1_IMAGE_SOURCE_LOADING_OPTIONS_CACHE_ON_DEMAND,
	}

	/// <summary>Specifies additional aspects of how a sprite batch is to be drawn, as part of a call to <c>ID2D1DeviceContext3::DrawSpriteBatch</c>.</summary>
	// https://learn.microsoft.com/en-us/windows/win32/api/d2d1_3/ne-d2d1_3-d2d1_sprite_options
	// typedef enum D2D1_SPRITE_OPTIONS { D2D1_SPRITE_OPTIONS_NONE = 0, D2D1_SPRITE_OPTIONS_CLAMP_TO_SOURCE_RECTANGLE = 1, D2D1_SPRITE_OPTIONS_FORCE_DWORD = 0xffffffff } ;
	[PInvokeData("d2d1_3.h", MSDNShortId = "NE:d2d1_3.D2D1_SPRITE_OPTIONS")]
	[Flags]
	public enum D2D1_SPRITE_OPTIONS : uint
	{
		/// <summary>
		///   <para>Value:</para>
		///   <para>0</para>
		///   <para>Default value. No special drawing configuration. This option yields the best drawing performance.</para>
		/// </summary>
		D2D1_SPRITE_OPTIONS_NONE,
		/// <summary>
		///   <para>Value:</para>
		///   <para>1</para>
		///   <para>Interpolation of bitmap pixels will be clamped to the sprite’s source rectangle.</para>
		///   <para>If the sub-images in your source bitmap have no pixels separating them, then you may see color bleeding when drawing them with D2D1_SPRITE_OPTIONS_NONE.</para>
		///   <para>In that case, consider adding borders between them with your sprite-packing tool, or use this option.</para>
		///   <para>Note that drawing sprites with this option enabled is slower than using D2D1_SPRITE_OPTIONS_NONE.</para>
		/// </summary>
		D2D1_SPRITE_OPTIONS_CLAMP_TO_SOURCE_RECTANGLE,
	}

	/// <summary>
	/// Represents a tensor patch with 16 control points, 4 corner colors, and boundary flags. An ID2D1GradientMesh is made up of 1 or more
	/// gradient mesh patches. Use the GradientMeshPatch function or the GradientMeshPatchFromCoonsPatch function to create one.
	/// </summary>
	/// <remarks>The following image shows the numbering of control points on a tensor grid.</remarks>
	// https://learn.microsoft.com/en-us/windows/win32/api/d2d1_3/ns-d2d1_3-d2d1_gradient_mesh_patch typedef struct D2D1_GRADIENT_MESH_PATCH
	// { D2D1_POINT_2F point00; D2D1_POINT_2F point01; D2D1_POINT_2F point02; D2D1_POINT_2F point03; D2D1_POINT_2F point10; D2D1_POINT_2F
	// point11; D2D1_POINT_2F point12; D2D1_POINT_2F point13; D2D1_POINT_2F point20; D2D1_POINT_2F point21; D2D1_POINT_2F point22;
	// D2D1_POINT_2F point23; D2D1_POINT_2F point30; D2D1_POINT_2F point31; D2D1_POINT_2F point32; D2D1_POINT_2F point33; D2D1_COLOR_F
	// color00; D2D1_COLOR_F color03; D2D1_COLOR_F color30; D2D1_COLOR_F color33; D2D1_PATCH_EDGE_MODE topEdgeMode; D2D1_PATCH_EDGE_MODE
	// leftEdgeMode; D2D1_PATCH_EDGE_MODE bottomEdgeMode; D2D1_PATCH_EDGE_MODE rightEdgeMode; } D2D1_GRADIENT_MESH_PATCH;
	[PInvokeData("d2d1_3.h", MSDNShortId = "NS:d2d1_3.D2D1_GRADIENT_MESH_PATCH")]
	[StructLayout(LayoutKind.Sequential)]
	public struct D2D1_GRADIENT_MESH_PATCH(D2D1_POINT_2F point00, D2D1_POINT_2F point01, D2D1_POINT_2F point02, D2D1_POINT_2F point03, D2D1_POINT_2F point10,
		D2D1_POINT_2F point11, D2D1_POINT_2F point12, D2D1_POINT_2F point13, D2D1_POINT_2F point20, D2D1_POINT_2F point21, D2D1_POINT_2F point22,
		D2D1_POINT_2F point23, D2D1_POINT_2F point30, D2D1_POINT_2F point31, D2D1_POINT_2F point32, D2D1_POINT_2F point33, D2D1_COLOR_F color00,
		D2D1_COLOR_F color03, D2D1_COLOR_F color30, D2D1_COLOR_F color33, D2D1_PATCH_EDGE_MODE topEdgeMode, D2D1_PATCH_EDGE_MODE leftEdgeMode,
		D2D1_PATCH_EDGE_MODE bottomEdgeMode, D2D1_PATCH_EDGE_MODE rightEdgeMode)
	{
		/// <summary>The coordinate-space location of the control point in column 0 and row 0 of the tensor grid.</summary>
		public D2D1_POINT_2F point00 = point00;

		/// <summary>The coordinate-space location of the control point in column 0 and row 1 of the tensor grid.</summary>
		public D2D1_POINT_2F point01 = point01;

		/// <summary>The coordinate-space location of the control point in column 0 and row 2 of the tensor grid.</summary>
		public D2D1_POINT_2F point02 = point02;

		/// <summary>The coordinate-space location of the control point in column 0 and row 3 of the tensor grid.</summary>
		public D2D1_POINT_2F point03 = point03;

		/// <summary>The coordinate-space location of the control point in column 1 and row 0 of the tensor grid.</summary>
		public D2D1_POINT_2F point10 = point10;

		/// <summary>The coordinate-space location of the control point in column 1 and row 1 of the tensor grid.</summary>
		public D2D1_POINT_2F point11 = point11;

		/// <summary>The coordinate-space location of the control point in column 1 and row 2 of the tensor grid.</summary>
		public D2D1_POINT_2F point12 = point12;

		/// <summary>The coordinate-space location of the control point in column 1 and row 3 of the tensor grid.</summary>
		public D2D1_POINT_2F point13 = point13;

		/// <summary>The coordinate-space location of the control point in column 2 and row 0 of the tensor grid.</summary>
		public D2D1_POINT_2F point20 = point20;

		/// <summary>The coordinate-space location of the control point in column 2 and row 1 of the tensor grid.</summary>
		public D2D1_POINT_2F point21 = point21;

		/// <summary>The coordinate-space location of the control point in column 2 and row 2 of the tensor grid.</summary>
		public D2D1_POINT_2F point22 = point22;

		/// <summary>The coordinate-space location of the control point in column 2 and row 3 of the tensor grid.</summary>
		public D2D1_POINT_2F point23 = point23;

		/// <summary>The coordinate-space location of the control point in column 3 and row 0 of the tensor grid.</summary>
		public D2D1_POINT_2F point30 = point30;

		/// <summary>The coordinate-space location of the control point in column 3 and row 1 of the tensor grid.</summary>
		public D2D1_POINT_2F point31 = point31;

		/// <summary>The coordinate-space location of the control point in column 3 and row 2 of the tensor grid.</summary>
		public D2D1_POINT_2F point32 = point32;

		/// <summary>The coordinate-space location of the control point in column 3 and row 3 of the tensor grid.</summary>
		public D2D1_POINT_2F point33 = point33;

		/// <summary>The color associated with the control point in column 0 and row 0 of the tensor grid.</summary>
		public D2D1_COLOR_F color00 = color00;

		/// <summary>The color associated with the control point in column 0 and row 3 of the tensor grid.</summary>
		public D2D1_COLOR_F color03 = color03;

		/// <summary>The color associated with the control point in column 3 and row 0 of the tensor grid.</summary>
		public D2D1_COLOR_F color30 = color30;

		/// <summary>The color associated with the control point in column 3 and row 3 of the tensor grid.</summary>
		public D2D1_COLOR_F color33 = color33;

		/// <summary>Specifies how to render the top edge of the mesh.</summary>
		public D2D1_PATCH_EDGE_MODE topEdgeMode = topEdgeMode;

		/// <summary>Specifies how to render the left edge of the mesh.</summary>
		public D2D1_PATCH_EDGE_MODE leftEdgeMode = leftEdgeMode;

		/// <summary>Specifies how to render the bottom edge of the mesh.</summary>
		public D2D1_PATCH_EDGE_MODE bottomEdgeMode = bottomEdgeMode;

		/// <summary>Specifies how to render the right edge of the mesh.</summary>
		public D2D1_PATCH_EDGE_MODE rightEdgeMode = rightEdgeMode;

		/// <summary>Creates a <c>D2D1_GRADIENT_MESH_PATCH</c> from a given Coons patch description.</summary>
		/// <param name="point0">
		/// <para>Type: <b><c>D2D1_POINT_2F</c></b></para>
		/// <para>The coordinate-space location of the control point at position 0.</para>
		/// </param>
		/// <param name="point1">
		/// <para>Type: <b><c>D2D1_POINT_2F</c></b></para>
		/// <para>The coordinate-space location of the control point at position 1.</para>
		/// </param>
		/// <param name="point2">
		/// <para>Type: <b><c>D2D1_POINT_2F</c></b></para>
		/// <para>The coordinate-space location of the control point at position 2.</para>
		/// </param>
		/// <param name="point3">
		/// <para>Type: <b><c>D2D1_POINT_2F</c></b></para>
		/// <para>The coordinate-space location of the control point at position 3.</para>
		/// </param>
		/// <param name="point4">
		/// <para>Type: <b><c>D2D1_POINT_2F</c></b></para>
		/// <para>The coordinate-space location of the control point at position 4.</para>
		/// </param>
		/// <param name="point5">
		/// <para>Type: <b><c>D2D1_POINT_2F</c></b></para>
		/// <para>The coordinate-space location of the control point at position 5.</para>
		/// </param>
		/// <param name="point6">
		/// <para>Type: <b><c>D2D1_POINT_2F</c></b></para>
		/// <para>The coordinate-space location of the control point at position 6.</para>
		/// </param>
		/// <param name="point7">
		/// <para>Type: <b><c>D2D1_POINT_2F</c></b></para>
		/// <para>The coordinate-space location of the control point at position 7.</para>
		/// </param>
		/// <param name="point8">
		/// <para>Type: <b><c>D2D1_POINT_2F</c></b></para>
		/// <para>The coordinate-space location of the control point at position 8.</para>
		/// </param>
		/// <param name="point9">
		/// <para>Type: <b><c>D2D1_POINT_2F</c></b></para>
		/// <para>The coordinate-space location of the control point at position 9.</para>
		/// </param>
		/// <param name="point10">
		/// <para>Type: <b><c>D2D1_POINT_2F</c></b></para>
		/// <para>The coordinate-space location of the control point at position 10.</para>
		/// </param>
		/// <param name="point11">
		/// <para>Type: <b><c>D2D1_POINT_2F</c></b></para>
		/// <para>The coordinate-space location of the control point at position 11.</para>
		/// </param>
		/// <param name="color0">
		/// <para>Type: <b><c>D2D1_COLOR_F</c></b></para>
		/// <para>The color associated with the control point at position 0.</para>
		/// </param>
		/// <param name="color1">
		/// <para>Type: <b><c>D2D1_COLOR_F</c></b></para>
		/// <para>The color associated with the control point at position 1.</para>
		/// </param>
		/// <param name="color2">
		/// <para>Type: <b><c>D2D1_COLOR_F</c></b></para>
		/// <para>The color associated with the control point at position 2.</para>
		/// </param>
		/// <param name="color3">
		/// <para>Type: <b><c>D2D1_COLOR_F</c></b></para>
		/// <para>The color associated with the control point at position 3.</para>
		/// </param>
		/// <param name="topEdgeMode">
		/// <para>Type: <b><c>D2D1_PATCH_EDGE_MODE</c></b></para>
		/// <para>Specifies how to render the top edge of the mesh.</para>
		/// </param>
		/// <param name="leftEdgeMode">
		/// <para>Type: <b><c>D2D1_PATCH_EDGE_MODE</c></b></para>
		/// <para>Specifies how to render the left edge of the mesh.</para>
		/// </param>
		/// <param name="bottomEdgeMode">
		/// <para>Type: <b><c>D2D1_PATCH_EDGE_MODE</c></b></para>
		/// <para>Specifies how to render the bottom edge of the mesh.</para>
		/// </param>
		/// <param name="rightEdgeMode">
		/// <para>Type: <b><c>D2D1_PATCH_EDGE_MODE</c></b></para>
		/// <para>Specifies how to render the right edge of the mesh.</para>
		/// </param>
		/// <returns>
		/// <para>Type: <b><c>D2D1_GRADIENT_MESH_PATCH</c></b></para>
		/// <para>Returns the created <c>D2D1_GRADIENT_MESH_PATCH</c> structure.</para>
		/// </returns>
		/// <remarks>The following image shows the numbering of control points in a Coons patch.</remarks>
		// https://learn.microsoft.com/en-us/windows/win32/api/d2d1_3helper/nf-d2d1_3helper-gradientmeshpatchfromcoonspatch
		// D2D1_GRADIENT_MESH_PATCH GradientMeshPatchFromCoonsPatch( D2D1_POINT_2F point0, D2D1_POINT_2F point1, D2D1_POINT_2F point2,
		// D2D1_POINT_2F point3, D2D1_POINT_2F point4, D2D1_POINT_2F point5, D2D1_POINT_2F point6, D2D1_POINT_2F point7, D2D1_POINT_2F
		// point8, D2D1_POINT_2F point9, D2D1_POINT_2F point10, D2D1_POINT_2F point11, D2D1_COLOR_F color0, D2D1_COLOR_F color1,
		// D2D1_COLOR_F color2, D2D1_COLOR_F color3, D2D1_PATCH_EDGE_MODE topEdgeMode, D2D1_PATCH_EDGE_MODE leftEdgeMode,
		// D2D1_PATCH_EDGE_MODE bottomEdgeMode, D2D1_PATCH_EDGE_MODE rightEdgeMode );
		[PInvokeData("d2d1_3helper.h", MSDNShortId = "NF:d2d1_3helper.GradientMeshPatchFromCoonsPatch")]
		public static D2D1_GRADIENT_MESH_PATCH FromCoonsPatch(D2D1_POINT_2F point0, D2D1_POINT_2F point1, D2D1_POINT_2F point2, D2D1_POINT_2F point3, D2D1_POINT_2F point4,
			D2D1_POINT_2F point5, D2D1_POINT_2F point6, D2D1_POINT_2F point7, D2D1_POINT_2F point8, D2D1_POINT_2F point9, D2D1_POINT_2F point10,
			D2D1_POINT_2F point11, D2D1_COLOR_F color0, D2D1_COLOR_F color1, D2D1_COLOR_F color2, D2D1_COLOR_F color3,
			D2D1_PATCH_EDGE_MODE topEdgeMode, D2D1_PATCH_EDGE_MODE leftEdgeMode, D2D1_PATCH_EDGE_MODE bottomEdgeMode, D2D1_PATCH_EDGE_MODE rightEdgeMode)
		{
			D2D1_GRADIENT_MESH_PATCH newPatch = new()
			{
				point00 = point0,
				point01 = point1,
				point02 = point2,
				point03 = point3,
				point13 = point4,
				point23 = point5,
				point33 = point6,
				point32 = point7,
				point31 = point8,
				point30 = point9,
				point20 = point10,
				point10 = point11,
				color00 = color0,
				color03 = color1,
				color33 = color2,
				color30 = color3,
				topEdgeMode = topEdgeMode,
				leftEdgeMode = leftEdgeMode,
				bottomEdgeMode = bottomEdgeMode,
				rightEdgeMode = rightEdgeMode,
			};

			D2D1GetGradientMeshInteriorPointsFromCoonsPatch(point0, point1, point2, point3, point4, point5, point6, point7, point8, point9, point10, point11,
				out newPatch.point11, out newPatch.point12, out newPatch.point21, out newPatch.point22);

			return newPatch;
		}
	}

	/// <summary>
	/// Represents a Bezier segment to be used in the creation of an ID2D1Ink object. This structure differs from D2D1_BEZIER_SEGMENT in
	/// that it is composed of D2D1_INK_POINTs, which contain a radius in addition to x- and y-coordinates.
	/// </summary>
	// https://learn.microsoft.com/en-us/windows/win32/api/d2d1_3/ns-d2d1_3-d2d1_ink_bezier_segment typedef struct D2D1_INK_BEZIER_SEGMENT {
	// D2D1_INK_POINT point1; D2D1_INK_POINT point2; D2D1_INK_POINT point3; } D2D1_INK_BEZIER_SEGMENT;
	[PInvokeData("d2d1_3.h", MSDNShortId = "NS:d2d1_3.D2D1_INK_BEZIER_SEGMENT")]
	[StructLayout(LayoutKind.Sequential)]
	public struct D2D1_INK_BEZIER_SEGMENT(in D2d1.D2D1_INK_POINT point1, in D2d1.D2D1_INK_POINT point2, in D2d1.D2D1_INK_POINT point3)
	{
		/// <summary>The first control point for the Bezier segment.</summary>
		public D2D1_INK_POINT point1 = point1;

		/// <summary>The second control point for the Bezier segment.</summary>
		public D2D1_INK_POINT point2 = point2;

		/// <summary>The end point for the Bezier segment.</summary>
		public D2D1_INK_POINT point3 = point3;
	}

	/// <summary>Represents a point, radius pair that makes up part of a D2D1_INK_BEZIER_SEGMENT.</summary>
	// https://learn.microsoft.com/en-us/windows/win32/api/d2d1_3/ns-d2d1_3-d2d1_ink_point typedef struct D2D1_INK_POINT { FLOAT x; FLOAT y;
	// FLOAT radius; } D2D1_INK_POINT;
	[PInvokeData("d2d1_3.h", MSDNShortId = "NS:d2d1_3.D2D1_INK_POINT")]
	[StructLayout(LayoutKind.Sequential)]
	public struct D2D1_INK_POINT(in D2D1_POINT_2F point, float radius)
	{
		/// <summary>The x-coordinate of the point.</summary>
		public float x = point.x;

		/// <summary>The y-coordinate of the point.</summary>
		public float y = point.y;

		/// <summary>The radius of this point. Corresponds to the width of the ink stroke at this point in the stroke.</summary>
		public float radius = radius;
	}

	/// <summary>Defines the general pen tip shape and the transform used in an ID2D1InkStyle object.</summary>
	// https://learn.microsoft.com/en-us/windows/win32/api/d2d1_3/ns-d2d1_3-d2d1_ink_style_properties typedef struct
	// D2D1_INK_STYLE_PROPERTIES { D2D1_INK_NIB_SHAPE nibShape; D2D1_MATRIX_3X2_F nibTransform; } D2D1_INK_STYLE_PROPERTIES;
	[PInvokeData("d2d1_3.h", MSDNShortId = "NS:d2d1_3.D2D1_INK_STYLE_PROPERTIES")]
	[StructLayout(LayoutKind.Sequential)]
	public struct D2D1_INK_STYLE_PROPERTIES(D2d1.D2D1_INK_NIB_SHAPE nibShape, in D2D1_MATRIX_3X2_F nibTransform)
	{
		/// <summary>The pre-transform shape of the nib (pen tip) used to draw a given ink object.</summary>
		public D2D1_INK_NIB_SHAPE nibShape = nibShape;

		/// <summary>
		/// The transform applied to the nib. Note that the translation components of the transform matrix are ignored for the purposes of rendering.
		/// </summary>
		public D2D1_MATRIX_3X2_F nibTransform = nibTransform;
	}

	/// <summary>Simple description of a color space.</summary>
	// https://learn.microsoft.com/en-us/windows/win32/api/d2d1_3/ns-d2d1_3-d2d1_simple_color_profile typedef struct
	// D2D1_SIMPLE_COLOR_PROFILE { D2D1_POINT_2F redPrimary; D2D1_POINT_2F greenPrimary; D2D1_POINT_2F bluePrimary; D2D1_POINT_2F
	// whitePointXZ; D2D1_GAMMA1 gamma; } D2D1_SIMPLE_COLOR_PROFILE;
	[PInvokeData("d2d1_3.h", MSDNShortId = "NS:d2d1_3.D2D1_SIMPLE_COLOR_PROFILE")]
	[StructLayout(LayoutKind.Sequential)]
	public struct D2D1_SIMPLE_COLOR_PROFILE(in D2D1_POINT_2F redPrimary, in D2D1_POINT_2F greenPrimary, in D2D1_POINT_2F bluePrimary, D2D1_GAMMA1 gamma, in D2D1_POINT_2F whitePointXZ)
	{
		/// <summary>The xy coordinates of the red primary in the CIExyY color space.</summary>
		public D2D1_POINT_2F redPrimary = redPrimary;

		/// <summary>The xy coordinates of the green primary in the CIExyY color space.</summary>
		public D2D1_POINT_2F greenPrimary = greenPrimary;

		/// <summary>The xy coordinates of the blue primary in the CIExyY color space.</summary>
		public D2D1_POINT_2F bluePrimary = bluePrimary;

		/// <summary>The XZ tristimulus values for the whitepoint in the CIEXYZ color space, normalized to luminance (Y) of 1.</summary>
		public D2D1_POINT_2F whitePointXZ = whitePointXZ;

		/// <summary>The gamma encoding to use for this color space.</summary>
		public D2D1_GAMMA1 gamma = gamma;
	}

	/// <summary>Properties of a transformed image source.</summary>
	// https://learn.microsoft.com/en-us/windows/win32/api/d2d1_3/ns-d2d1_3-d2d1_transformed_image_source_properties typedef struct
	// D2D1_TRANSFORMED_IMAGE_SOURCE_PROPERTIES { D2D1_ORIENTATION orientation; FLOAT scaleX; FLOAT scaleY; D2D1_INTERPOLATION_MODE
	// interpolationMode; D2D1_TRANSFORMED_IMAGE_SOURCE_OPTIONS options; } D2D1_TRANSFORMED_IMAGE_SOURCE_PROPERTIES;
	[PInvokeData("d2d1_3.h", MSDNShortId = "NS:d2d1_3.D2D1_TRANSFORMED_IMAGE_SOURCE_PROPERTIES")]
	[StructLayout(LayoutKind.Sequential)]
	public struct D2D1_TRANSFORMED_IMAGE_SOURCE_PROPERTIES
	{
		/// <summary>
		/// <para>Type: <c>D2D1_ORIENTATION</c></para>
		/// <para>The orientation at which the image source is drawn.</para>
		/// </summary>
		public D2D1_ORIENTATION orientation;

		/// <summary>
		/// <para>Type: <c>FLOAT</c></para>
		/// <para>The horizontal scale factor at which the image source is drawn.</para>
		/// </summary>
		public float scaleX;

		/// <summary>
		/// <para>Type: <c>FLOAT</c></para>
		/// <para>The vertical scale factor at which the image source is drawn.</para>
		/// </summary>
		public float scaleY;

		/// <summary>
		/// <para>Type: <c>D2D1_INTERPOLATION_MODE</c></para>
		/// <para>
		/// The interpolation mode used when the image source is drawn. This is ignored if the image source is drawn using the DrawImage
		/// method, or using an image brush.
		/// </para>
		/// </summary>
		public D2D1_INTERPOLATION_MODE interpolationMode;

		/// <summary>
		/// <para>Type: <c>D2D1_TRANSFORMED_IMAGE_SOURCE_OPTIONS</c></para>
		/// <para>Image source option flags.</para>
		/// </summary>
		public D2D1_TRANSFORMED_IMAGE_SOURCE_OPTIONS options;
	}

	/// <summary>
	/// <para>Returns the interior points for a gradient mesh patch based on the points defining a Coons patch.</para>
	/// <para><c>Note</c></para>
	/// </summary>
	/// <param name="pPoint0">
	/// <para>Type: <c>D2D1_POINT_2F*</c></para>
	/// <para>The coordinate-space location of the control point at position 0.</para>
	/// </param>
	/// <param name="pPoint1">
	/// <para>Type: <c>D2D1_POINT_2F*</c></para>
	/// <para>The coordinate-space location of the control point at position 1.</para>
	/// </param>
	/// <param name="pPoint2">
	/// <para>Type: <c>D2D1_POINT_2F*</c></para>
	/// <para>The coordinate-space location of the control point at position 2.</para>
	/// </param>
	/// <param name="pPoint3">
	/// <para>Type: <c>D2D1_POINT_2F*</c></para>
	/// <para>The coordinate-space location of the control point at position 3.</para>
	/// </param>
	/// <param name="pPoint4">
	/// <para>Type: <c>D2D1_POINT_2F*</c></para>
	/// <para>The coordinate-space location of the control point at position 4.</para>
	/// </param>
	/// <param name="pPoint5">
	/// <para>Type: <c>D2D1_POINT_2F*</c></para>
	/// <para>The coordinate-space location of the control point at position 5.</para>
	/// </param>
	/// <param name="pPoint6">
	/// <para>Type: <c>D2D1_POINT_2F*</c></para>
	/// <para>The coordinate-space location of the control point at position 6.</para>
	/// </param>
	/// <param name="pPoint7">
	/// <para>Type: <c>D2D1_POINT_2F*</c></para>
	/// <para>The coordinate-space location of the control point at position 7.</para>
	/// </param>
	/// <param name="pPoint8">
	/// <para>Type: <c>D2D1_POINT_2F*</c></para>
	/// <para>The coordinate-space location of the control point at position 8.</para>
	/// </param>
	/// <param name="pPoint9">
	/// <para>Type: <c>D2D1_POINT_2F*</c></para>
	/// <para>The coordinate-space location of the control point at position 9.</para>
	/// </param>
	/// <param name="pPoint10">
	/// <para>Type: <c>D2D1_POINT_2F*</c></para>
	/// <para>The coordinate-space location of the control point at position 10.</para>
	/// </param>
	/// <param name="pPoint11">
	/// <para>Type: <c>D2D1_POINT_2F*</c></para>
	/// <para>The coordinate-space location of the control point at position 11.</para>
	/// </param>
	/// <param name="pTensorPoint11">
	/// <para>Type: <c>D2D1_POINT_2F*</c></para>
	/// <para>Returns the interior point for the gradient mesh corresponding to point11 in the D2D1_GRADIENT_MESH_PATCH structure.</para>
	/// </param>
	/// <param name="pTensorPoint12">
	/// <para>Type: <c>D2D1_POINT_2F*</c></para>
	/// <para>Returns the interior point for the gradient mesh corresponding to point12 in the D2D1_GRADIENT_MESH_PATCH structure.</para>
	/// </param>
	/// <param name="pTensorPoint21">
	/// <para>Type: <c>D2D1_POINT_2F*</c></para>
	/// <para>Returns the interior point for the gradient mesh corresponding to point21 in the D2D1_GRADIENT_MESH_PATCH structure.</para>
	/// </param>
	/// <param name="pTensorPoint22">
	/// <para>Type: <c>D2D1_POINT_2F*</c></para>
	/// <para>Returns the interior point for the gradient mesh corresponding to point22 in the D2D1_GRADIENT_MESH_PATCH structure.</para>
	/// </param>
	/// <returns>None</returns>
	/// <remarks>This function is called by the GradientMeshPatchFromCoonsPatch function and is not intended to be used directly.</remarks>
	// https://docs.microsoft.com/en-us/windows/win32/api/d2d1_3/nf-d2d1_3-d2d1getgradientmeshinteriorpointsfromcoonspatch void
	// D2D1GetGradientMeshInteriorPointsFromCoonsPatch( const D2D1_POINT_2F *pPoint0, const D2D1_POINT_2F *pPoint1, const D2D1_POINT_2F
	// *pPoint2, const D2D1_POINT_2F *pPoint3, const D2D1_POINT_2F *pPoint4, const D2D1_POINT_2F *pPoint5, const D2D1_POINT_2F *pPoint6,
	// const D2D1_POINT_2F *pPoint7, const D2D1_POINT_2F *pPoint8, const D2D1_POINT_2F *pPoint9, const D2D1_POINT_2F *pPoint10, const
	// D2D1_POINT_2F *pPoint11, D2D1_POINT_2F *pTensorPoint11, D2D1_POINT_2F *pTensorPoint12, D2D1_POINT_2F *pTensorPoint21, D2D1_POINT_2F
	// *pTensorPoint22 );
	[DllImport(Lib.D2d1, SetLastError = false, ExactSpelling = true)]
	[PInvokeData("d2d1_3.h", MSDNShortId = "388d5cbf-cb15-f0c9-3f3b-897f68519a4c")]
	public static extern void D2D1GetGradientMeshInteriorPointsFromCoonsPatch(in D2D_POINT_2F pPoint0, in D2D_POINT_2F pPoint1, in D2D_POINT_2F pPoint2, in D2D_POINT_2F pPoint3,
		in D2D_POINT_2F pPoint4, in D2D_POINT_2F pPoint5, in D2D_POINT_2F pPoint6, in D2D_POINT_2F pPoint7, in D2D_POINT_2F pPoint8, in D2D_POINT_2F pPoint9,
		in D2D_POINT_2F pPoint10, in D2D_POINT_2F pPoint11, out D2D_POINT_2F pTensorPoint11, out D2D_POINT_2F pTensorPoint12, out D2D_POINT_2F pTensorPoint21, out D2D_POINT_2F pTensorPoint22);
}