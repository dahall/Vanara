using System.IO;
using D2D1_COLOR_F = Vanara.PInvoke.DXGI.D3DCOLORVALUE;
using D2D1_MATRIX_3X2_F = Vanara.PInvoke.DXGI.D2D_MATRIX_3X2_F;
using D2D1_POINT_2F = Vanara.PInvoke.DXGI.D2D_POINT_2F;
using D2D1_TAG = System.UInt64;

namespace Vanara.PInvoke;

public static partial class D2d1
{
	/// <summary>Describes the implementation of an effect.</summary>
	/// <param name="effectImpl">The effect implementation returned by the factory.</param>
	/// <returns>The effect factory is implemented by an effect author.</returns>
	// https://learn.microsoft.com/en-us/windows/win32/api/d2d1_1/nc-d2d1_1-pd2d1_effect_factory
	// PD2D1_EFFECT_FACTORY Pd2d1EffectFactory; HRESULT Pd2d1EffectFactory( IUnknown **effectImpl ) {...}
	[PInvokeData("d2d1_1.h", MSDNShortId = "NC:d2d1_1.PD2D1_EFFECT_FACTORY")]
	[UnmanagedFunctionPointer(CallingConvention.Winapi, SetLastError = false)]
	public delegate HRESULT PD2D1_EFFECT_FACTORY([MarshalAs(UnmanagedType.IUnknown)] out object? effectImpl);

	/// <summary>Specifies how a bitmap can be used.</summary>
	/// <remarks>
	/// <para>
	/// <c>D2D1_BITMAP_OPTIONS_NONE</c> implies that none of the flags are set. This means that the bitmap can be used for drawing from,
	/// cannot be set as a target and cannot be read from by the CPU.
	/// </para>
	/// <para>
	/// <c>D2D1_BITMAP_OPTIONS_TARGET</c> means that the bitmap can be specified as a target in ID2D1DeviceContext::SetTarget. If you
	/// also specify the <c>D2D1_BITMAP_OPTIONS_CANNOT_DRAW</c> flag the bitmap can be used a target but, it cannot be drawn from.
	/// Attempting to draw with a bitmap that has both flags set will result in the device context being put into an error state with <c>D2DERR_BITMAP_CANNOT_DRAW</c>.
	/// </para>
	/// <para>
	/// <c>D2D1_BITMAP_OPTIONS_CPU_READ</c> means that the bitmap can be mapped by using ID2D1Bitmap1::Map. This flag requires
	/// <c>D2D1_BITMAP_OPTIONS_CANNOT_DRAW</c> and cannot be combined with any other flags. The bitmap must be updated with the
	/// CopyFromBitmap or CopyFromRenderTarget methods.
	/// </para>
	/// <para>
	/// <c>Note</c> You should only use <c>D2D1_BITMAP_OPTIONS_CANNOT_DRAW</c> is when the purpose of the bitmap is to be a target only
	/// or when the bitmap will be mapped .
	/// </para>
	/// <para>
	/// <c>D2D1_BITMAP_OPTIONS_GDI_COMPATIBLE</c> means that it is possible to get a DC associated with this bitmap. This must be used
	/// in conjunction with <c>D2D1_BITMAP_OPTIONS_TARGET</c>. The DXGI_FORMAT must be either <c>DXGI_FORMAT_B8G8R8A8_UNORM</c> or <c>DXGI_FORMAT_B8G8R8A8_UNORM_SRGB</c>.
	/// </para>
	/// </remarks>
	// https://docs.microsoft.com/en-us/windows/win32/api/d2d1_1/ne-d2d1_1-d2d1_bitmap_options typedef enum D2D1_BITMAP_OPTIONS {
	// D2D1_BITMAP_OPTIONS_NONE, D2D1_BITMAP_OPTIONS_TARGET, D2D1_BITMAP_OPTIONS_CANNOT_DRAW, D2D1_BITMAP_OPTIONS_CPU_READ,
	// D2D1_BITMAP_OPTIONS_GDI_COMPATIBLE, D2D1_BITMAP_OPTIONS_FORCE_DWORD } ;
	[PInvokeData("d2d1_1.h", MSDNShortId = "c080e23e-99c4-46ed-8b21-be26dec288af")]
	[Flags]
	public enum D2D1_BITMAP_OPTIONS : uint
	{
		/// <summary>The bitmap is created with default properties.</summary>
		D2D1_BITMAP_OPTIONS_NONE = 0x00000000,

		/// <summary>The bitmap can be used as a device context target.</summary>
		D2D1_BITMAP_OPTIONS_TARGET = 0x00000001,

		/// <summary>The bitmap cannot be used as an input.</summary>
		D2D1_BITMAP_OPTIONS_CANNOT_DRAW = 0x00000002,

		/// <summary>The bitmap can be read from the CPU.</summary>
		D2D1_BITMAP_OPTIONS_CPU_READ = 0x00000004,

		/// <summary>The bitmap works with ID2D1GdiInteropRenderTarget::GetDC.</summary>
		D2D1_BITMAP_OPTIONS_GDI_COMPATIBLE = 0x00000008,
	}

	/// <summary>Represents the bit depth of the imaging pipeline in Direct2D.</summary>
	/// <remarks><c>Note</c> Feature level 9 may or may not support precision types other than 8BPC.</remarks>
	// https://docs.microsoft.com/en-us/windows/win32/api/d2d1_1/ne-d2d1_1-d2d1_buffer_precision typedef enum D2D1_BUFFER_PRECISION {
	// D2D1_BUFFER_PRECISION_UNKNOWN, D2D1_BUFFER_PRECISION_8BPC_UNORM, D2D1_BUFFER_PRECISION_8BPC_UNORM_SRGB,
	// D2D1_BUFFER_PRECISION_16BPC_UNORM, D2D1_BUFFER_PRECISION_16BPC_FLOAT, D2D1_BUFFER_PRECISION_32BPC_FLOAT,
	// D2D1_BUFFER_PRECISION_FORCE_DWORD } ;
	[PInvokeData("d2d1_1.h", MSDNShortId = "a2a4b4fd-685d-4068-b1f5-609e6ab024e2")]
	public enum D2D1_BUFFER_PRECISION : uint
	{
		/// <summary>The buffer precision is not specified.</summary>
		D2D1_BUFFER_PRECISION_UNKNOWN = 0,

		/// <summary>Use 8-bit normalized integer per channel.</summary>
		D2D1_BUFFER_PRECISION_8BPC_UNORM,

		/// <summary>Use 8-bit normalized integer standard RGB data per channel.</summary>
		D2D1_BUFFER_PRECISION_8BPC_UNORM_SRGB,

		/// <summary>Use 16-bit normalized integer per channel.</summary>
		D2D1_BUFFER_PRECISION_16BPC_UNORM,

		/// <summary>Use 16-bit floats per channel.</summary>
		D2D1_BUFFER_PRECISION_16BPC_FLOAT,

		/// <summary>Use 32-bit floats per channel.</summary>
		D2D1_BUFFER_PRECISION_32BPC_FLOAT,
	}

	/// <summary>Defines how to interpolate between colors.</summary>
	// https://docs.microsoft.com/en-us/windows/win32/api/d2d1_1/ne-d2d1_1-d2d1_color_interpolation_mode typedef enum
	// D2D1_COLOR_INTERPOLATION_MODE { D2D1_COLOR_INTERPOLATION_MODE_STRAIGHT, D2D1_COLOR_INTERPOLATION_MODE_PREMULTIPLIED,
	// D2D1_COLOR_INTERPOLATION_MODE_FORCE_DWORD } ;
	[PInvokeData("d2d1_1.h", MSDNShortId = "E3E9FB4C-5E77-451B-ABED-39D9C7AE567A")]
	public enum D2D1_COLOR_INTERPOLATION_MODE : uint
	{
		/// <summary>Colors are interpolated with straight alpha.</summary>
		D2D1_COLOR_INTERPOLATION_MODE_STRAIGHT = 0,

		/// <summary>Colors are interpolated with premultiplied alpha.</summary>
		D2D1_COLOR_INTERPOLATION_MODE_PREMULTIPLIED,
	}

	/// <summary>Defines options that should be applied to the color space.</summary>
	// https://docs.microsoft.com/en-us/windows/win32/api/d2d1_1/ne-d2d1_1-d2d1_color_space typedef enum D2D1_COLOR_SPACE {
	// D2D1_COLOR_SPACE_CUSTOM, D2D1_COLOR_SPACE_SRGB, D2D1_COLOR_SPACE_SCRGB, D2D1_COLOR_SPACE_FORCE_DWORD } ;
	[PInvokeData("d2d1_1.h", MSDNShortId = "2c90978b-8a5a-4e5d-9ced-e0ec917271ff")]
	public enum D2D1_COLOR_SPACE : uint
	{
		/// <summary>The color space is otherwise described, such as with a color profile.</summary>
		D2D1_COLOR_SPACE_CUSTOM,

		/// <summary>The color space is sRGB.</summary>
		D2D1_COLOR_SPACE_SRGB,

		/// <summary>The color space is scRGB.</summary>
		D2D1_COLOR_SPACE_SCRGB,

		/// <summary/>
		D2D1_COLOR_SPACE_FORCE_DWORD = 0xffffffff,
	}

	/// <summary>Used to specify the blend mode for all of the Direct2D blending operations.</summary>
	/// <remarks>
	/// <para>The figure here shows an example of each of the modes with images that have an opacity of 1.0 or 0.5.</para>
	/// <para>There can be slightly different interpretations of these enumeration values depending on where the value is used.</para>
	/// <list type="bullet">
	/// <item>
	/// <term>
	/// With a composite effect: <c>D2D1_COMPOSITE_MODE_DESTINATION_COPY</c> is equivalent to <c>D2D1_COMPOSITE_MODE_SOURCE_COPY</c>
	/// with the inputs inverted.
	/// </term>
	/// </item>
	/// <item>
	/// <term>
	/// As a parameter to ID2D1DeviceContext::DrawImage: <c>D2D1_COMPOSITE_MODE_DESTINATION_COPY</c> is a no-op since the destination is
	/// already in the selected target.
	/// </term>
	/// </item>
	/// </list>
	/// <para>Sample code</para>
	/// <para>For an example that uses composite modes, download the Direct2D composite effect modes sample.</para>
	/// </remarks>
	// https://docs.microsoft.com/en-us/windows/win32/api/d2d1_1/ne-d2d1_1-d2d1_composite_mode typedef enum D2D1_COMPOSITE_MODE {
	// D2D1_COMPOSITE_MODE_SOURCE_OVER, D2D1_COMPOSITE_MODE_DESTINATION_OVER, D2D1_COMPOSITE_MODE_SOURCE_IN,
	// D2D1_COMPOSITE_MODE_DESTINATION_IN, D2D1_COMPOSITE_MODE_SOURCE_OUT, D2D1_COMPOSITE_MODE_DESTINATION_OUT,
	// D2D1_COMPOSITE_MODE_SOURCE_ATOP, D2D1_COMPOSITE_MODE_DESTINATION_ATOP, D2D1_COMPOSITE_MODE_XOR, D2D1_COMPOSITE_MODE_PLUS,
	// D2D1_COMPOSITE_MODE_SOURCE_COPY, D2D1_COMPOSITE_MODE_BOUNDED_SOURCE_COPY, D2D1_COMPOSITE_MODE_MASK_INVERT,
	// D2D1_COMPOSITE_MODE_FORCE_DWORD } ;
	[PInvokeData("d2d1_1.h", MSDNShortId = "4f01e805-aed7-4bfc-9793-42a9fdde3473")]
	public enum D2D1_COMPOSITE_MODE : uint
	{
		/// <summary>The standard source-over-destination blend mode.</summary>
		D2D1_COMPOSITE_MODE_SOURCE_OVER = 0,

		/// <summary>The destination is rendered over the source.</summary>
		D2D1_COMPOSITE_MODE_DESTINATION_OVER,

		/// <summary>Performs a logical clip of the source pixels against the destination pixels.</summary>
		D2D1_COMPOSITE_MODE_SOURCE_IN,

		/// <summary>The inverse of the D2D1_COMPOSITE_MODE_SOURCE_IN operation.</summary>
		D2D1_COMPOSITE_MODE_DESTINATION_IN,

		/// <summary>This is the logical inverse to D2D1_COMPOSITE_MODE_SOURCE_IN.</summary>
		D2D1_COMPOSITE_MODE_SOURCE_OUT,

		/// <summary>The is the logical inverse to D2D1_COMPOSITE_MODE_DESTINATION_IN.</summary>
		D2D1_COMPOSITE_MODE_DESTINATION_OUT,

		/// <summary>Writes the source pixels over the destination where there are destination pixels.</summary>
		D2D1_COMPOSITE_MODE_SOURCE_ATOP,

		/// <summary>The logical inverse of D2D1_COMPOSITE_MODE_SOURCE_ATOP.</summary>
		D2D1_COMPOSITE_MODE_DESTINATION_ATOP,

		/// <summary>The source is inverted with the destination.</summary>
		D2D1_COMPOSITE_MODE_XOR,

		/// <summary>The channel components are summed.</summary>
		D2D1_COMPOSITE_MODE_PLUS,

		/// <summary>The source is copied to the destination; the destination pixels are ignored.</summary>
		D2D1_COMPOSITE_MODE_SOURCE_COPY,

		/// <summary>Equivalent to D2D1_COMPOSITE_MODE_SOURCE_COPY, but pixels outside of the source bounds are unchanged.</summary>
		D2D1_COMPOSITE_MODE_BOUNDED_SOURCE_COPY,

		/// <summary>Destination colors are inverted according to a source mask.</summary>
		D2D1_COMPOSITE_MODE_MASK_INVERT,
	}

	/// <summary>This specifies options that apply to the device context for its lifetime.</summary>
	// https://docs.microsoft.com/en-us/windows/win32/api/d2d1_1/ne-d2d1_1-d2d1_device_context_options typedef enum
	// D2D1_DEVICE_CONTEXT_OPTIONS { D2D1_DEVICE_CONTEXT_OPTIONS_NONE, D2D1_DEVICE_CONTEXT_OPTIONS_ENABLE_MULTITHREADED_OPTIMIZATIONS,
	// D2D1_DEVICE_CONTEXT_OPTIONS_FORCE_DWORD } ;
	[PInvokeData("d2d1_1.h", MSDNShortId = "be4e6eb7-0767-4faf-9f27-eeb3bed48244")]
	public enum D2D1_DEVICE_CONTEXT_OPTIONS : uint
	{
		/// <summary>The device context is created with default options.</summary>
		D2D1_DEVICE_CONTEXT_OPTIONS_NONE,

		/// <summary>
		/// Distribute rendering work across multiple threads. Refer to Improving the performance of Direct2D apps for additional notes
		/// on the use of this flag.
		/// </summary>
		D2D1_DEVICE_CONTEXT_OPTIONS_ENABLE_MULTITHREADED_OPTIMIZATIONS,

		/// <summary/>
		D2D1_DEVICE_CONTEXT_OPTIONS_FORCE_DWORD = 0xffffffff,
	}

	/// <summary>Determines what gamma is used for interpolation and blending.</summary>
	// https://learn.microsoft.com/en-us/windows/win32/api/d2d1_3/ne-d2d1_3-d2d1_gamma1
	// typedef enum D2D1_GAMMA1 { D2D1_GAMMA1_G22, D2D1_GAMMA1_G10, D2D1_GAMMA1_G2084 = 2, D2D1_GAMMA1_FORCE_DWORD = 0xffffffff } ;
	[PInvokeData("d2d1_3.h", MSDNShortId = "NE:d2d1_3.D2D1_GAMMA1")]
	public enum D2D1_GAMMA1 : uint
	{
		/// <summary>Colors are manipulated in 2.2 gamma color space.</summary>
		D2D1_GAMMA1_G22,

		/// <summary>Colors are manipulated in 1.0 gamma color space.</summary>
		D2D1_GAMMA1_G10,

		/// <summary>
		///   <para>Value:</para>
		///   <para>2</para>
		///   <para>Colors are manipulated in ST.2084 PQ gamma color space.</para>
		/// </summary>
		D2D1_GAMMA1_G2084,
	}

	/// <summary>Specifies the appearance of the ink nib (pen tip) as part of an D2D1_INK_STYLE_PROPERTIES structure.</summary>
	// https://learn.microsoft.com/en-us/windows/win32/api/d2d1_3/ne-d2d1_3-d2d1_ink_nib_shape
	// typedef enum D2D1_INK_NIB_SHAPE { D2D1_INK_NIB_SHAPE_ROUND = 0, D2D1_INK_NIB_SHAPE_SQUARE = 1, D2D1_INK_NIB_SHAPE_FORCE_DWORD = 0xffffffff } ;
	[PInvokeData("d2d1_3.h", MSDNShortId = "NE:d2d1_3.D2D1_INK_NIB_SHAPE")]
	public enum D2D1_INK_NIB_SHAPE
	{
		/// <summary>
		///   <para>Value:</para>
		///   <para>0</para>
		///   <para>The pen tip is circular.</para>
		/// </summary>
		D2D1_INK_NIB_SHAPE_ROUND,

		/// <summary>
		///   <para>Value:</para>
		///   <para>1</para>
		///   <para>The pen tip is square.</para>
		/// </summary>
		D2D1_INK_NIB_SHAPE_SQUARE,
	}

	/// <summary>
	/// This is used to specify the quality of image scaling with ID2D1DeviceContext::DrawImage and with the 2D affine transform effect.
	/// </summary>
	// https://docs.microsoft.com/en-us/windows/win32/api/d2d1_1/ne-d2d1_1-d2d1_interpolation_mode typedef enum D2D1_INTERPOLATION_MODE
	// { D2D1_INTERPOLATION_MODE_NEAREST_NEIGHBOR, D2D1_INTERPOLATION_MODE_LINEAR, D2D1_INTERPOLATION_MODE_CUBIC,
	// D2D1_INTERPOLATION_MODE_MULTI_SAMPLE_LINEAR, D2D1_INTERPOLATION_MODE_ANISOTROPIC, D2D1_INTERPOLATION_MODE_HIGH_QUALITY_CUBIC,
	// D2D1_INTERPOLATION_MODE_FORCE_DWORD } ;
	[PInvokeData("d2d1_1.h", MSDNShortId = "7a32f551-afad-4eb2-953f-a9acc71d7776")]
	public enum D2D1_INTERPOLATION_MODE : uint
	{
		/// <summary>
		/// Samples the nearest single point and uses that exact color. This mode uses less processing time, but outputs the lowest
		/// quality image.
		/// </summary>
		D2D1_INTERPOLATION_MODE_NEAREST_NEIGHBOR,

		/// <summary>
		/// Uses a four point sample and linear interpolation. This mode uses more processing time than the nearest neighbor mode, but
		/// outputs a higher quality image.
		/// </summary>
		D2D1_INTERPOLATION_MODE_LINEAR,

		/// <summary>
		/// Uses a 16 sample cubic kernel for interpolation. This mode uses the most processing time, but outputs a higher quality image.
		/// </summary>
		D2D1_INTERPOLATION_MODE_CUBIC,

		/// <summary>
		/// Uses 4 linear samples within a single pixel for good edge anti-aliasing. This mode is good for scaling down by small amounts
		/// on images with few pixels.
		/// </summary>
		D2D1_INTERPOLATION_MODE_MULTI_SAMPLE_LINEAR,

		/// <summary>Uses anisotropic filtering to sample a pattern according to the transformed shape of the bitmap.</summary>
		D2D1_INTERPOLATION_MODE_ANISOTROPIC,

		/// <summary>
		/// Uses a variable size high quality cubic kernel to perform a pre-downscale the image if downscaling is involved in the
		/// transform matrix. Then uses the cubic interpolation mode for the final output.
		/// </summary>
		D2D1_INTERPOLATION_MODE_HIGH_QUALITY_CUBIC,
	}

	/// <summary>Specifies how the layer contents should be prepared.</summary>
	// https://docs.microsoft.com/en-us/windows/win32/api/d2d1_1/ne-d2d1_1-d2d1_layer_options1 typedef enum D2D1_LAYER_OPTIONS1 {
	// D2D1_LAYER_OPTIONS1_NONE, D2D1_LAYER_OPTIONS1_INITIALIZE_FROM_BACKGROUND, D2D1_LAYER_OPTIONS1_IGNORE_ALPHA,
	// D2D1_LAYER_OPTIONS1_FORCE_DWORD } ;
	[PInvokeData("d2d1_1.h", MSDNShortId = "13C9EDE7-A1D0-4359-8EF3-77FF763B9244")]
	public enum D2D1_LAYER_OPTIONS1 : uint
	{
		/// <summary>Default layer behavior. A premultiplied layer target is pushed and its contents are cleared to transparent black.</summary>
		D2D1_LAYER_OPTIONS1_NONE = 0,

		/// <summary>The layer is not cleared to transparent black.</summary>
		D2D1_LAYER_OPTIONS1_INITIALIZE_FROM_BACKGROUND,

		/// <summary>The layer is always created as ignore alpha. All content rendered into the layer will be treated as opaque.</summary>
		D2D1_LAYER_OPTIONS1_IGNORE_ALPHA,
	}

	/// <summary>Specifies how the memory to be mapped from the corresponding ID2D1Bitmap1 should be treated.</summary>
	/// <remarks>
	/// <para>
	/// The <c>D2D1_MAP_OPTIONS_READ</c> option can be used only if the bitmap was created with the <c>D2D1_BITMAP_OPTIONS_CPU_READ</c> flag.
	/// </para>
	/// <para>
	/// These flags will be not be able to be used on bitmaps created by the ID2D1DeviceContext. However, the ID2D1SourceTransform will
	/// receive bitmaps for which these flags are valid.
	/// </para>
	/// <para>
	/// <c>D2D1_MAP_OPTIONS_DISCARD</c> can only be used with <c>D2D1_MAP_OPTIONS_WRITE</c>. Both of these options are only available
	/// through the effect author API, not through the Direct2D rendering API.
	/// </para>
	/// </remarks>
	// https://docs.microsoft.com/en-us/windows/win32/api/d2d1_1/ne-d2d1_1-d2d1_map_options typedef enum D2D1_MAP_OPTIONS {
	// D2D1_MAP_OPTIONS_NONE, D2D1_MAP_OPTIONS_READ, D2D1_MAP_OPTIONS_WRITE, D2D1_MAP_OPTIONS_DISCARD, D2D1_MAP_OPTIONS_FORCE_DWORD } ;
	[PInvokeData("d2d1_1.h", MSDNShortId = "8706c3e3-eb29-4760-bdfd-f19afc6f2bf7")]
	[Flags]
	public enum D2D1_MAP_OPTIONS : uint
	{
		/// <summary/>
		D2D1_MAP_OPTIONS_NONE = 0x00,

		/// <summary>Allow CPU Read access.</summary>
		D2D1_MAP_OPTIONS_READ = 0x01,

		/// <summary>Allow CPU Write access.</summary>
		D2D1_MAP_OPTIONS_WRITE = 0x02,

		/// <summary>Discard the previous contents of the resource when it is mapped.</summary>
		D2D1_MAP_OPTIONS_DISCARD = 0x04,
	}

	/// <summary>Specifies the flip and rotation at which an image appears.</summary>
	// https://learn.microsoft.com/en-us/windows/win32/api/d2d1_3/ne-d2d1_3-d2d1_orientation
	// typedef enum D2D1_ORIENTATION { D2D1_ORIENTATION_DEFAULT = 1, D2D1_ORIENTATION_FLIP_HORIZONTAL = 2, D2D1_ORIENTATION_ROTATE_CLOCKWISE180 = 3, D2D1_ORIENTATION_ROTATE_CLOCKWISE180_FLIP_HORIZONTAL = 4, D2D1_ORIENTATION_ROTATE_CLOCKWISE90_FLIP_HORIZONTAL = 5, D2D1_ORIENTATION_ROTATE_CLOCKWISE270 = 6, D2D1_ORIENTATION_ROTATE_CLOCKWISE270_FLIP_HORIZONTAL = 7, D2D1_ORIENTATION_ROTATE_CLOCKWISE90 = 8, D2D1_ORIENTATION_FORCE_DWORD = 0xffffffff } ;
	[PInvokeData("d2d1_3.h", MSDNShortId = "NE:d2d1_3.D2D1_ORIENTATION")]
	public enum D2D1_ORIENTATION : uint
	{
		/// <summary>
		///   <para>Value:</para>
		///   <para>1</para>
		///   <para>The orientation is unchanged.</para>
		/// </summary>
		D2D1_ORIENTATION_DEFAULT = 1,

		/// <summary>
		///   <para>Value:</para>
		///   <para>2</para>
		///   <para>The image is flipped horizontally.</para>
		/// </summary>
		D2D1_ORIENTATION_FLIP_HORIZONTAL,

		/// <summary>
		///   <para>Value:</para>
		///   <para>3</para>
		///   <para>The image is rotated clockwise 180 degrees.</para>
		/// </summary>
		D2D1_ORIENTATION_ROTATE_CLOCKWISE180,

		/// <summary>
		///   <para>Value:</para>
		///   <para>4</para>
		///   <para>The image is rotated clockwise 180 degrees, then flipped horizontally.</para>
		/// </summary>
		D2D1_ORIENTATION_ROTATE_CLOCKWISE180_FLIP_HORIZONTAL,

		/// <summary>
		///   <para>Value:</para>
		///   <para>5</para>
		///   <para>The image is rotated clockwise 90 degrees, then flipped horizontally.</para>
		/// </summary>
		D2D1_ORIENTATION_ROTATE_CLOCKWISE90_FLIP_HORIZONTAL,

		/// <summary>
		///   <para>Value:</para>
		///   <para>6</para>
		///   <para>The image is rotated clockwise 270 degrees.</para>
		/// </summary>
		D2D1_ORIENTATION_ROTATE_CLOCKWISE270,

		/// <summary>
		///   <para>Value:</para>
		///   <para>7</para>
		///   <para>The image is rotated clockwise 270 degrees, then flipped horizontally.</para>
		/// </summary>
		D2D1_ORIENTATION_ROTATE_CLOCKWISE270_FLIP_HORIZONTAL,

		/// <summary>
		///   <para>Value:</para>
		///   <para>8</para>
		///   <para>The image is rotated clockwise 90 degrees.</para>
		/// </summary>
		D2D1_ORIENTATION_ROTATE_CLOCKWISE90,
	}

	/// <summary>Specifies how to render gradient mesh edges.</summary>
	// https://learn.microsoft.com/en-us/windows/win32/api/d2d1_3/ne-d2d1_3-d2d1_patch_edge_mode
	// typedef enum D2D1_PATCH_EDGE_MODE { D2D1_PATCH_EDGE_MODE_ALIASED = 0, D2D1_PATCH_EDGE_MODE_ANTIALIASED = 1, D2D1_PATCH_EDGE_MODE_ALIASED_INFLATED = 2, D2D1_PATCH_EDGE_MODE_FORCE_DWORD = 0xffffffff } ;
	[PInvokeData("d2d1_3.h", MSDNShortId = "NE:d2d1_3.D2D1_PATCH_EDGE_MODE")]
	public enum D2D1_PATCH_EDGE_MODE : uint
	{
		/// <summary>
		///   <para>Value:</para>
		///   <para>0</para>
		///   <para>Render this patch edge aliased. Use this value for the internal edges of your gradient mesh.</para>
		/// </summary>
		D2D1_PATCH_EDGE_MODE_ALIASED,

		/// <summary>
		///   <para>Value:</para>
		///   <para>1</para>
		///   <para>Render this patch edge antialiased. Use this value for the external (boundary) edges of your mesh.</para>
		/// </summary>
		D2D1_PATCH_EDGE_MODE_ANTIALIASED,

		/// <summary>
		///   <para>Value:</para>
		///   <para>2</para>
		///   <para>Render this patch edge aliased and also slightly inflated. Use this for the internal edges of your gradient mesh when there could be t-junctions among patches.</para>
		///   <para>Inflating the internal edges mitigates seams that can appear along those junctions.</para>
		/// </summary>
		D2D1_PATCH_EDGE_MODE_ALIASED_INFLATED,
	}

	/// <summary>Used to specify the geometric blend mode for all Direct2D primitives.</summary>
	/// <remarks>
	/// <para>Blend modes</para>
	/// <para>
	/// For aliased rendering (except for MIN mode), the output value O is computed by linearly interpolating the value blend(S, D) with
	/// the destination pixel value, based on the amount that the primitive covers the destination pixel.
	/// </para>
	/// <para>
	/// The table here shows the primitive blend modes for both aliased and antialiased blending. The equations listed in the table use
	/// these elements:
	/// </para>
	/// <list type="bullet">
	/// <item>
	/// <term>O = Output</term>
	/// </item>
	/// <item>
	/// <term>S = Source</term>
	/// </item>
	/// <item>
	/// <term>SA = Source Alpha</term>
	/// </item>
	/// <item>
	/// <term>D = Destination</term>
	/// </item>
	/// <item>
	/// <term>DA = Destination Alpha</term>
	/// </item>
	/// <item>
	/// <term>C = Pixel coverage</term>
	/// </item>
	/// </list>
	/// <list type="table">
	/// <listheader>
	/// <term>Primitive blend mode</term>
	/// <term>Aliased blending</term>
	/// <term>Antialiased blending</term>
	/// <term>Description</term>
	/// </listheader>
	/// <item>
	/// <term>D2D1_PRIMITIVE_BLEND_SOURCE_OVER</term>
	/// <term>O = (S + (1 – SA) * D) * C + D * (1 – C)</term>
	/// <term>O = S * C + D *(1 – SA *C)</term>
	/// <term>The standard source-over-destination blend mode.</term>
	/// </item>
	/// <item>
	/// <term>D2D1_PRIMITIVE_BLEND_COPY</term>
	/// <term>O = S * C + D * (1 – C)</term>
	/// <term>O = S * C + D * (1 – C)</term>
	/// <term>The source is copied to the destination; the destination pixels are ignored.</term>
	/// </item>
	/// <item>
	/// <term>D2D1_PRIMITIVE_BLEND_MIN</term>
	/// <term>O = Min(S + 1-SA, D)</term>
	/// <term>O = Min(S * C + 1 – SA *C, D)</term>
	/// <term>The resulting pixel values use the minimum of the source and destination pixel values. Available in Windows 8.1 and later.</term>
	/// </item>
	/// <item>
	/// <term>D2D1_PRIMITIVE_BLEND_ADD</term>
	/// <term>O = (S + D) * C + D * (1 – C)</term>
	/// <term>O = S * C + D</term>
	/// <term>The resulting pixel values are the sum of the source and destination pixel values. Available in Windows 8.1 and later.</term>
	/// </item>
	/// </list>
	/// <para>An illustration of the primitive blend modes with varying opacity and backgrounds.</para>
	/// </remarks>
	// https://docs.microsoft.com/en-us/windows/win32/api/d2d1_1/ne-d2d1_1-d2d1_primitive_blend typedef enum D2D1_PRIMITIVE_BLEND {
	// D2D1_PRIMITIVE_BLEND_SOURCE_OVER, D2D1_PRIMITIVE_BLEND_COPY, D2D1_PRIMITIVE_BLEND_MIN, D2D1_PRIMITIVE_BLEND_ADD,
	// D2D1_PRIMITIVE_BLEND_MAX, D2D1_PRIMITIVE_BLEND_FORCE_DWORD } ;
	[PInvokeData("d2d1_1.h", MSDNShortId = "411a42c9-f8d7-46f3-a6e6-51afc83375ad")]
	public enum D2D1_PRIMITIVE_BLEND : uint
	{
		/// <summary>The standard source-over-destination blend mode.</summary>
		D2D1_PRIMITIVE_BLEND_SOURCE_OVER = 0,

		/// <summary>The source is copied to the destination; the destination pixels are ignored.</summary>
		D2D1_PRIMITIVE_BLEND_COPY,

		/// <summary>
		/// The resulting pixel values use the minimum of the source and destination pixel values. Available in Windows 8 and later.
		/// </summary>
		D2D1_PRIMITIVE_BLEND_MIN,

		/// <summary>
		/// The resulting pixel values are the sum of the source and destination pixel values. Available in Windows 8 and later.
		/// </summary>
		D2D1_PRIMITIVE_BLEND_ADD,

		/// <summary>
		/// The resulting pixel values use the maximum of the source and destination pixel values. Available in Windows 10 and later
		/// (set using ID21CommandSink4::SetPrimitiveBlend2).
		/// </summary>
		D2D1_PRIMITIVE_BLEND_MAX,
	}

	/// <summary>Defines when font resources should be subset during printing.</summary>
	// https://docs.microsoft.com/en-us/windows/win32/api/d2d1_1/ne-d2d1_1-d2d1_print_font_subset_mode typedef enum
	// D2D1_PRINT_FONT_SUBSET_MODE { D2D1_PRINT_FONT_SUBSET_MODE_DEFAULT, D2D1_PRINT_FONT_SUBSET_MODE_EACHPAGE,
	// D2D1_PRINT_FONT_SUBSET_MODE_NONE, D2D1_PRINT_FONT_SUBSET_MODE_FORCE_DWORD } ;
	[PInvokeData("d2d1_1.h", MSDNShortId = "B8361117-6018-48EE-AD3D-2A37F6B71293")]
	public enum D2D1_PRINT_FONT_SUBSET_MODE : uint
	{
		/// <summary/>
		D2D1_PRINT_FONT_SUBSET_MODE_DEFAULT,

		/// <summary/>
		D2D1_PRINT_FONT_SUBSET_MODE_EACHPAGE,

		/// <summary/>
		D2D1_PRINT_FONT_SUBSET_MODE_NONE,

		/// <summary/>
		D2D1_PRINT_FONT_SUBSET_MODE_FORCE_DWORD = 0xffffffff,
	}

	/// <summary>Specifies the indices of the system properties present on the ID2D1Properties interface for an ID2D1Effect.</summary>
	/// <remarks>Under normal circumstances the minimum and maximum number of inputs to the effect are the same. If the effect supports a variable number of inputs, the ID2D1Effect::SetNumberOfInputs method can be used to choose the number that the application will enable.</remarks>
	// https://learn.microsoft.com/en-us/windows/win32/api/d2d1_1/ne-d2d1_1-d2d1_property
	// typedef enum D2D1_PROPERTY { D2D1_PROPERTY_CLSID = 0x80000000, D2D1_PROPERTY_DISPLAYNAME = 0x80000001, D2D1_PROPERTY_AUTHOR = 0x80000002, D2D1_PROPERTY_CATEGORY = 0x80000003, D2D1_PROPERTY_DESCRIPTION = 0x80000004, D2D1_PROPERTY_INPUTS = 0x80000005, D2D1_PROPERTY_CACHED = 0x80000006, D2D1_PROPERTY_PRECISION = 0x80000007, D2D1_PROPERTY_MIN_INPUTS = 0x80000008, D2D1_PROPERTY_MAX_INPUTS = 0x80000009, D2D1_PROPERTY_FORCE_DWORD = 0xffffffff } ;
	[PInvokeData("d2d1_1.h", MSDNShortId = "NE:d2d1_1.D2D1_PROPERTY")]
	public enum D2D1_PROPERTY
	{
		/// <summary>
		///   <para>Value:</para>
		///   <para>0x80000000</para>
		///   <para>The CLSID of the effect.</para>
		/// </summary>
		D2D1_PROPERTY_CLSID = 0,
		/// <summary>
		///   <para>Value:</para>
		///   <para>0x80000001</para>
		///   <para>The name of the effect.</para>
		/// </summary>
		D2D1_PROPERTY_DISPLAYNAME,
		/// <summary>
		///   <para>Value:</para>
		///   <para>0x80000002</para>
		///   <para>The author of the effect.</para>
		/// </summary>
		D2D1_PROPERTY_AUTHOR,
		/// <summary>
		///   <para>Value:</para>
		///   <para>0x80000003</para>
		///   <para>The category of the effect.</para>
		/// </summary>
		D2D1_PROPERTY_CATEGORY,
		/// <summary>
		///   <para>Value:</para>
		///   <para>0x80000004</para>
		///   <para>The description of the effect.</para>
		/// </summary>
		D2D1_PROPERTY_DESCRIPTION,
		/// <summary>
		///   <para>Value:</para>
		///   <para>0x80000005</para>
		///   <para>The names of the effect's inputs.</para>
		/// </summary>
		D2D1_PROPERTY_INPUTS,
		/// <summary>
		///   <para>Value:</para>
		///   <para>0x80000006</para>
		///   <para>The output of the effect should be cached.</para>
		/// </summary>
		D2D1_PROPERTY_CACHED,
		/// <summary>
		///   <para>Value:</para>
		///   <para>0x80000007</para>
		///   <para>The buffer precision of the effect output.</para>
		/// </summary>
		D2D1_PROPERTY_PRECISION,
		/// <summary>
		///   <para>Value:</para>
		///   <para>0x80000008</para>
		///   <para>The minimum number of inputs supported by the effect.</para>
		/// </summary>
		D2D1_PROPERTY_MIN_INPUTS,
		/// <summary>
		///   <para>Value:</para>
		///   <para>0x80000009</para>
		///   <para>The maximum number of inputs supported by the effect.</para>
		/// </summary>
		D2D1_PROPERTY_MAX_INPUTS,
	}
	
	/// <summary>Specifies the types of properties supported by the Direct2D property interface.</summary>
	// https://docs.microsoft.com/en-us/windows/win32/api/d2d1_1/ne-d2d1_1-d2d1_property_type typedef enum D2D1_PROPERTY_TYPE {
	// D2D1_PROPERTY_TYPE_UNKNOWN, D2D1_PROPERTY_TYPE_STRING, D2D1_PROPERTY_TYPE_BOOL, D2D1_PROPERTY_TYPE_UINT32,
	// D2D1_PROPERTY_TYPE_INT32, D2D1_PROPERTY_TYPE_FLOAT, D2D1_PROPERTY_TYPE_VECTOR2, D2D1_PROPERTY_TYPE_VECTOR3,
	// D2D1_PROPERTY_TYPE_VECTOR4, D2D1_PROPERTY_TYPE_BLOB, D2D1_PROPERTY_TYPE_IUNKNOWN, D2D1_PROPERTY_TYPE_ENUM,
	// D2D1_PROPERTY_TYPE_ARRAY, D2D1_PROPERTY_TYPE_CLSID, D2D1_PROPERTY_TYPE_MATRIX_3X2, D2D1_PROPERTY_TYPE_MATRIX_4X3,
	// D2D1_PROPERTY_TYPE_MATRIX_4X4, D2D1_PROPERTY_TYPE_MATRIX_5X4, D2D1_PROPERTY_TYPE_COLOR_CONTEXT, D2D1_PROPERTY_TYPE_FORCE_DWORD } ;
	[PInvokeData("d2d1_1.h", MSDNShortId = "6535d71a-c76c-462c-9972-4db7e4ef383d")]
	public enum D2D1_PROPERTY_TYPE : uint
	{
		/// <summary>An unknown property.</summary>
		D2D1_PROPERTY_TYPE_UNKNOWN,

		/// <summary>An arbitrary-length string.</summary>
		D2D1_PROPERTY_TYPE_STRING,

		/// <summary>A 32-bit integer value constrained to be either 0 or 1.</summary>
		D2D1_PROPERTY_TYPE_BOOL,

		/// <summary>An unsigned 32-bit integer.</summary>
		D2D1_PROPERTY_TYPE_UINT32,

		/// <summary>A signed 32-bit integer.</summary>
		D2D1_PROPERTY_TYPE_INT32,

		/// <summary>A 32-bit float.</summary>
		D2D1_PROPERTY_TYPE_FLOAT,

		/// <summary>Two 32-bit float values.</summary>
		D2D1_PROPERTY_TYPE_VECTOR2,

		/// <summary>Three 32-bit float values.</summary>
		D2D1_PROPERTY_TYPE_VECTOR3,

		/// <summary>Four 32-bit float values.</summary>
		D2D1_PROPERTY_TYPE_VECTOR4,

		/// <summary>An arbitrary number of bytes.</summary>
		D2D1_PROPERTY_TYPE_BLOB,

		/// <summary>A returned COM or nano-COM interface.</summary>
		D2D1_PROPERTY_TYPE_IUNKNOWN,

		/// <summary>
		/// An enumeration. The value should be treated as a UINT32 with a defined array of fields to specify the bindings to
		/// human-readable strings.
		/// </summary>
		D2D1_PROPERTY_TYPE_ENUM,

		/// <summary>
		/// An enumeration. The value is the count of sub-properties in the array. The set of array elements will be contained in the sub-property.
		/// </summary>
		D2D1_PROPERTY_TYPE_ARRAY,

		/// <summary>A CLSID.</summary>
		D2D1_PROPERTY_TYPE_CLSID,

		/// <summary>A 3x2 matrix of float values.</summary>
		D2D1_PROPERTY_TYPE_MATRIX_3X2,

		/// <summary>A 4x2 matrix of float values.</summary>
		D2D1_PROPERTY_TYPE_MATRIX_4X3,

		/// <summary>A 4x4 matrix of float values.</summary>
		D2D1_PROPERTY_TYPE_MATRIX_4X4,

		/// <summary>A 5x4 matrix of float values.</summary>
		D2D1_PROPERTY_TYPE_MATRIX_5X4,

		/// <summary>A nano-COM color context interface pointer.</summary>
		D2D1_PROPERTY_TYPE_COLOR_CONTEXT,
	}

	/// <summary>Defines how the world transform, dots per inch (dpi), and stroke width affect the shape of the pen used to stroke a primitive.</summary>
	/// <remarks>
	/// <para>If you specify <c>D2D1_STROKE_TRANSFORM_TYPE_FIXED</c> the stroke isn't affected by the world transform.</para>
	/// <para>If you specify <c>D2D1_STROKE_TRANSFORM_TYPE_FIXED</c> the application has the same behavior in Windows 7 and later.</para>
	/// <para>If you specify <c>D2D1_STROKE_TRANSFORM_TYPE_HAIRLINE</c> the stroke is always 1 pixel wide.</para>
	/// <para>Apart from the stroke, any value derived from the stroke width is not affected when the transformType is either fixed or hairline. This includes miters, line caps and so on.</para>
	/// <para>It is important to distinguish between the geometry being stroked and the shape of the stroke pen. When D2D1_STROKE_TRANSFORM_TYPE_FIXED or D2D1_STROKE_TRANSFORM_TYPE_HAIRLINE is specified, the geometry still respects the transform and dpi, but the pen that traces the geometry will not.</para>
	/// <para>Here is an illustration of a stroke with dashing and a skew and stretch transform.</para>
	/// <para>And here is an illustration of a fixed width stroke which does not get transformed.</para>
	/// </remarks>
	// https://learn.microsoft.com/en-us/windows/win32/api/d2d1_1/ne-d2d1_1-d2d1_stroke_transform_type
	// typedef enum D2D1_STROKE_TRANSFORM_TYPE { D2D1_STROKE_TRANSFORM_TYPE_NORMAL = 0, D2D1_STROKE_TRANSFORM_TYPE_FIXED = 1, D2D1_STROKE_TRANSFORM_TYPE_HAIRLINE = 2, D2D1_STROKE_TRANSFORM_TYPE_FORCE_DWORD = 0xffffffff } ;
	[PInvokeData("d2d1_1.h", MSDNShortId = "NE:d2d1_1.D2D1_STROKE_TRANSFORM_TYPE")]
	public enum D2D1_STROKE_TRANSFORM_TYPE : uint
	{
		/// <summary>
		///   <para>Value:</para>
		///   <para>0</para>
		///   <para>The stroke respects the currently set world transform, the dpi, and the stroke width.</para>
		/// </summary>
		D2D1_STROKE_TRANSFORM_TYPE_NORMAL,

		/// <summary>
		///   <para>Value:</para>
		///   <para>1</para>
		///   <para>The stroke does not respect the world transform but it does respect the dpi and stroke width.</para>
		/// </summary>
		D2D1_STROKE_TRANSFORM_TYPE_FIXED,

		/// <summary>
		///   <para>Value:</para>
		///   <para>2</para>
		///   <para>The stroke is forced to 1 pixel wide (in device space) and does not respect the world transform, the dpi, or the stroke width.</para>
		/// </summary>
		D2D1_STROKE_TRANSFORM_TYPE_HAIRLINE,
	}

	/// <summary>Specifies the indices of the system sub-properties that may be present in any property.</summary>
	// https://learn.microsoft.com/en-us/windows/win32/api/d2d1_1/ne-d2d1_1-d2d1_subproperty
	// typedef enum D2D1_SUBPROPERTY { D2D1_SUBPROPERTY_DISPLAYNAME = 0x80000000, D2D1_SUBPROPERTY_ISREADONLY = 0x80000001, D2D1_SUBPROPERTY_MIN = 0x80000002, D2D1_SUBPROPERTY_MAX = 0x80000003, D2D1_SUBPROPERTY_DEFAULT = 0x80000004, D2D1_SUBPROPERTY_FIELDS = 0x80000005, D2D1_SUBPROPERTY_INDEX = 0x80000006, D2D1_SUBPROPERTY_FORCE_DWORD = 0xffffffff } ;
	[PInvokeData("d2d1_1.h", MSDNShortId = "NE:d2d1_1.D2D1_SUBPROPERTY")]
	public enum D2D1_SUBPROPERTY : uint
	{
		/// <summary>
		///   <para>Value:</para>
		///   <para>0x80000000</para>
		///   <para>The name for the parent property.</para>
		/// </summary>
		D2D1_SUBPROPERTY_DISPLAYNAME = 0x80000000,
		/// <summary>
		///   <para>Value:</para>
		///   <para>0x80000001</para>
		///   <para>A Boolean indicating whether the parent property is writable.</para>
		/// </summary>
		D2D1_SUBPROPERTY_ISREADONLY = 0x80000001,
		/// <summary>
		///   <para>Value:</para>
		///   <para>0x80000002</para>
		///   <para>The minimum value that can be set to the parent property.</para>
		/// </summary>
		D2D1_SUBPROPERTY_MIN = 0x80000002,
		/// <summary>
		///   <para>Value:</para>
		///   <para>0x80000003</para>
		///   <para>The maximum value that can be set to the parent property.</para>
		/// </summary>
		D2D1_SUBPROPERTY_MAX = 0x80000003,
		/// <summary>
		///   <para>Value:</para>
		///   <para>0x80000004</para>
		///   <para>The default value of the parent property.</para>
		/// </summary>
		D2D1_SUBPROPERTY_DEFAULT = 0x80000004,
		/// <summary>
		///   <para>Value:</para>
		///   <para>0x80000005</para>
		///   <para>An array of name/index pairs that indicate the possible values that can be set to the parent property.</para>
		/// </summary>
		D2D1_SUBPROPERTY_FIELDS = 0x80000005,
		/// <summary>
		///   <para>Value:</para>
		///   <para>0x80000006</para>
		///   <para>An index sub-property used by the elements of the</para>
		///   <para>D2D1_SUBPROPERTY_FIELDS</para>
		///   <para>array.</para>
		/// </summary>
		D2D1_SUBPROPERTY_INDEX = 0x80000006,
	}
	
	/// <summary>Specifies the threading mode used while simultaneously creating the device, factory, and device context.</summary>
	// https://docs.microsoft.com/en-us/windows/win32/api/d2d1_1/ne-d2d1_1-d2d1_threading_mode typedef enum D2D1_THREADING_MODE {
	// D2D1_THREADING_MODE_SINGLE_THREADED, D2D1_THREADING_MODE_MULTI_THREADED, D2D1_THREADING_MODE_FORCE_DWORD } ;
	[PInvokeData("d2d1_1.h", MSDNShortId = "21fba5ee-3d31-4142-b66a-94b343e1c6eb")]
	public enum D2D1_THREADING_MODE : uint
	{
		/// <summary>Resources may only be invoked serially. Device context state is not protected from multi-threaded access.</summary>
		D2D1_THREADING_MODE_SINGLE_THREADED = 0,

		/// <summary>Resources may be invoked from multiple threads. Resources use interlocked reference counting and their state is protected.</summary>
		D2D1_THREADING_MODE_MULTI_THREADED = 1,
	}

	/// <summary>Option flags for transformed image sources.</summary>
	// https://learn.microsoft.com/en-us/windows/win32/api/d2d1_3/ne-d2d1_3-d2d1_transformed_image_source_options
	// typedef enum D2D1_TRANSFORMED_IMAGE_SOURCE_OPTIONS { D2D1_TRANSFORMED_IMAGE_SOURCE_OPTIONS_NONE = 0, D2D1_TRANSFORMED_IMAGE_SOURCE_OPTIONS_DISABLE_DPI_SCALE = 1, D2D1_TRANSFORMED_IMAGE_SOURCE_OPTIONS_FORCE_DWORD = 0xffffffff } ;
	[PInvokeData("d2d1_3.h", MSDNShortId = "NE:d2d1_3.D2D1_TRANSFORMED_IMAGE_SOURCE_OPTIONS")]
	public enum D2D1_TRANSFORMED_IMAGE_SOURCE_OPTIONS : uint
	{
		/// <summary>
		///   <para>Value:</para>
		///   <para>0</para>
		///   <para>No option flags.</para>
		/// </summary>
		D2D1_TRANSFORMED_IMAGE_SOURCE_OPTIONS_NONE,

		/// <summary>
		///   <para>Value:</para>
		///   <para>1</para>
		///   <para>Prevents the image source from being automatically scaled (by a ratio of the context DPI divided by 96) while drawn.</para>
		/// </summary>
		D2D1_TRANSFORMED_IMAGE_SOURCE_OPTIONS_DISABLE_DPI_SCALE,
	}

	/// <summary>Specifies how units in Direct2D will be interpreted.</summary>
	/// <remarks>
	/// Setting the unit mode to <c>D2D1_UNIT_MODE_PIXELS</c> is similar to setting the ID2D1DeviceContext dots per inch (dpi) to 96.
	/// However, Direct2D still checks the dpi to determine the threshold for enabling vertical antialiasing for text, and when the unit
	/// mode is restored, the dpi will be remembered.
	/// </remarks>
	// https://docs.microsoft.com/en-us/windows/win32/api/d2d1_1/ne-d2d1_1-d2d1_unit_mode typedef enum D2D1_UNIT_MODE {
	// D2D1_UNIT_MODE_DIPS, D2D1_UNIT_MODE_PIXELS, D2D1_UNIT_MODE_FORCE_DWORD } ;
	[PInvokeData("d2d1_1.h", MSDNShortId = "1ba11761-f3e9-4996-8494-384db5bddc99")]
	public enum D2D1_UNIT_MODE : uint
	{
		/// <summary>Units will be interpreted as device-independent pixels (1/96").</summary>
		D2D1_UNIT_MODE_DIPS = 0,

		/// <summary>Units will be interpreted as pixels.</summary>
		D2D1_UNIT_MODE_PIXELS,
	}

	/// <summary>
	/// Represents a bitmap that can be used as a surface for an ID2D1DeviceContext or mapped into system memory, and can contain
	/// additional color context information.
	/// </summary>
	/// <remarks>
	/// <para>Creating ID2D1Bitmap Objects</para>
	/// <para>Use one of these methods to create an ID2D1Bitmap object.</para>
	/// <list type="bullet">
	/// <item>
	/// <term>ID2D1DeviceContext::CreateBitmap</term>
	/// </item>
	/// <item>
	/// <term>ID2D1DeviceContext::CreateBitmapFromWicBitmap</term>
	/// </item>
	/// </list>
	/// <para>For information about the pixel formats supported by Direct2D bitmaps, see Supported Pixel Formats and Alpha Modes.</para>
	/// <para>
	/// An ID2D1Bitmap is a device-dependent resource: your application should create bitmaps after it initializes the render target
	/// with which the bitmap will be used, and recreate the bitmap whenever the render target needs recreated. (For more information
	/// about resources, see Resources Overview.)
	/// </para>
	/// </remarks>
	// https://docs.microsoft.com/en-us/windows/win32/api/d2d1_1/nn-d2d1_1-id2d1bitmap1
	[PInvokeData("d2d1_1.h", MSDNShortId = "669a9377-248c-4a86-b447-ed117fff43a6")]
	[ComImport, Guid("a898a84c-3873-4588-b08b-ebbf978df041"), InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
	public interface ID2D1Bitmap1 : ID2D1Bitmap
	{
		/// <summary>Retrieves the factory associated with this resource.</summary>
		/// <param name="factory">
		/// <para>Type: <c>ID2D1Factory**</c></para>
		/// <para>
		/// When this method returns, contains a pointer to a pointer to the factory that created this resource. This parameter is
		/// passed uninitialized.
		/// </para>
		/// </param>
		// https://docs.microsoft.com/en-us/windows/win32/api/d2d1/nf-d2d1-id2d1resource-getfactory void GetFactory( ID2D1Factory
		// **factory );
		[PreserveSig]
		new void GetFactory(out ID2D1Factory factory);

		/// <summary>Returns the size, in device-independent pixels (DIPs), of the bitmap.</summary>
		/// <returns>
		/// <para>Type: <c>D2D1_SIZE_F</c></para>
		/// <para>The size, in DIPs, of the bitmap.</para>
		/// </returns>
		/// <remarks>A DIP is 1/96 of an inch. To retrieve the size in device pixels, use the ID2D1Bitmap::GetPixelSizemethod.</remarks>
		// https://docs.microsoft.com/en-us/windows/win32/api/d2d1/nf-d2d1-id2d1bitmap-getsize D2D1_SIZE_F GetSize();
		[PreserveSig]
		new D2D_SIZE_F GetSize();

		/// <summary>Returns the size, in device-dependent units (pixels), of the bitmap.</summary>
		/// <returns>
		/// <para>Type: <c>D2D1_SIZE_U</c></para>
		/// <para>The size, in pixels, of the bitmap.</para>
		/// </returns>
		// https://docs.microsoft.com/en-us/windows/win32/api/d2d1/nf-d2d1-id2d1bitmap-getpixelsize D2D1_SIZE_U GetPixelSize();
		[PreserveSig]
		new D2D_SIZE_U GetPixelSize();

		/// <summary>Retrieves the pixel format and alpha mode of the bitmap.</summary>
		/// <returns>
		/// <para>Type: <c>D2D1_PIXEL_FORMAT</c></para>
		/// <para>The pixel format and alpha mode of the bitmap.</para>
		/// </returns>
		// https://docs.microsoft.com/en-us/windows/win32/api/d2d1/nf-d2d1-id2d1bitmap-getpixelformat D2D1_PIXEL_FORMAT GetPixelFormat();
		[PreserveSig]
		new D2D1_PIXEL_FORMAT GetPixelFormat();

		/// <summary>Return the dots per inch (DPI) of the bitmap.</summary>
		/// <param name="dpiX">
		/// <para>Type: <c>FLOAT*</c></para>
		/// <para>The horizontal DPI of the image. You must allocate storage for this parameter.</para>
		/// </param>
		/// <param name="dpiY">
		/// <para>Type: <c>FLOAT*</c></para>
		/// <para>The vertical DPI of the image. You must allocate storage for this parameter.</para>
		/// </param>
		/// <returns>None</returns>
		// https://docs.microsoft.com/en-us/windows/win32/api/d2d1/nf-d2d1-id2d1bitmap-getdpi void GetDpi( FLOAT *dpiX, FLOAT *dpiY );
		[PreserveSig]
		new void GetDpi(out float dpiX, out float dpiY);

		/// <summary>Copies the specified region from the specified bitmap into the current bitmap.</summary>
		/// <param name="destPoint">
		/// <para>Type: <c>const D2D1_POINT_2U*</c></para>
		/// <para>In the current bitmap, the upper-left corner of the area to which the region specified by srcRect is copied.</para>
		/// </param>
		/// <param name="bitmap">
		/// <para>Type: <c>ID2D1Bitmap*</c></para>
		/// <para>The bitmap to copy from.</para>
		/// </param>
		/// <param name="srcRect">
		/// <para>Type: <c>const D2D1_RECT_U*</c></para>
		/// <para>The area of bitmap to copy.</para>
		/// </param>
		/// <returns>
		/// <para>Type: <c>HRESULT</c></para>
		/// <para>If this method succeeds, it returns <c>S_OK</c>. Otherwise, it returns an <c>HRESULT</c> error code.</para>
		/// </returns>
		/// <remarks>
		/// <para>
		/// This method does not update the size of the current bitmap. If the contents of the source bitmap do not fit in the current
		/// bitmap, this method fails. Also, note that this method does not perform format conversion, and will fail if the bitmap
		/// formats do not match.
		/// </para>
		/// <para>
		/// Calling this method may cause the current batch to flush if the bitmap is active in the batch. If the batch that was flushed
		/// does not complete successfully, this method fails. However, this method does not clear the error state of the render target
		/// on which the batch was flushed. The failing HRESULT and tag state will be returned at the next call to EndDraw or Flush.
		/// </para>
		/// <para>
		/// Starting with Windows 8.1, this method supports block compressed bitmaps. If you are using a block compressed format, the
		/// end coordinates of the srcRect parameter must be multiples of 4 or the method returns <c>E_INVALIDARG</c>.
		/// </para>
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows/win32/api/d2d1/nf-d2d1-id2d1bitmap-copyfrombitmap HRESULT CopyFromBitmap( const
		// D2D1_POINT_2U *destPoint, ID2D1Bitmap *bitmap, const D2D1_RECT_U *srcRect );
		new void CopyFromBitmap([In, Optional] IntPtr destPoint, [In] ID2D1Bitmap bitmap, [In, Optional] IntPtr srcRect);

		/// <summary>Copies the specified region from the specified render target into the current bitmap.</summary>
		/// <param name="destPoint">
		/// <para>Type: <c>const D2D1_POINT_2U*</c></para>
		/// <para>In the current bitmap, the upper-left corner of the area to which the region specified by srcRect is copied.</para>
		/// </param>
		/// <param name="renderTarget">
		/// <para>Type: <c>ID2D1RenderTarget*</c></para>
		/// <para>The render target that contains the region to copy.</para>
		/// </param>
		/// <param name="srcRect">
		/// <para>Type: <c>const D2D1_RECT_U*</c></para>
		/// <para>The area of renderTarget to copy.</para>
		/// </param>
		/// <returns>
		/// <para>Type: <c>HRESULT</c></para>
		/// <para>If this method succeeds, it returns <c>S_OK</c>. Otherwise, it returns an <c>HRESULT</c> error code.</para>
		/// </returns>
		/// <remarks>
		/// <para>
		/// This method does not update the size of the current bitmap. If the contents of the source bitmap do not fit in the current
		/// bitmap, this method fails. Also, note that this method does not perform format conversion, and will fail if the bitmap
		/// formats do not match.
		/// </para>
		/// <para>
		/// Calling this method may cause the current batch to flush if the bitmap is active in the batch. If the batch that was flushed
		/// does not complete successfully, this method fails. However, this method does not clear the error state of the render target
		/// on which the batch was flushed. The failing HRESULT and tag state will be returned at the next call to EndDraw or Flush.
		/// </para>
		/// <para>
		/// All clips and layers must be popped off of the render target before calling this method. The method returns
		/// D2DERR_RENDER_TARGET_HAS_LAYER_OR_CLIPRECT if any clips or layers are currently applied to the render target.
		/// </para>
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows/win32/api/d2d1/nf-d2d1-id2d1bitmap-copyfromrendertarget HRESULT
		// CopyFromRenderTarget( const D2D1_POINT_2U *destPoint, ID2D1RenderTarget *renderTarget, const D2D1_RECT_U *srcRect );
		new void CopyFromRenderTarget([In, Optional] IntPtr destPoint, [In] ID2D1RenderTarget renderTarget, [In, Optional] IntPtr srcRect);

		/// <summary>Copies the specified region from memory into the current bitmap.</summary>
		/// <param name="dstRect">
		/// <para>Type: <c>const D2D1_RECT_U*</c></para>
		/// <para>In the current bitmap, the rectangle to which the region specified by srcRect is copied.</para>
		/// </param>
		/// <param name="srcData">
		/// <para>Type: <c>const void*</c></para>
		/// <para>The data to copy.</para>
		/// </param>
		/// <param name="pitch">
		/// <para>Type: <c>UINT32</c></para>
		/// <para>
		/// The stride, or pitch, of the source bitmap stored in srcData. The stride is the byte count of a scanline (one row of pixels
		/// in memory). The stride can be computed from the following formula: pixel width * bytes per pixel + memory padding.
		/// </para>
		/// </param>
		/// <returns>
		/// <para>Type: <c>HRESULT</c></para>
		/// <para>If this method succeeds, it returns <c>S_OK</c>. Otherwise, it returns an <c>HRESULT</c> error code.</para>
		/// </returns>
		/// <remarks>
		/// <para>
		/// This method does not update the size of the current bitmap. If the contents of the source bitmap do not fit in the current
		/// bitmap, this method fails. Also, note that this method does not perform format conversion; the two bitmap formats should match.
		/// </para>
		/// <para>
		/// If this method is passed invalid input (such as an invalid destination rectangle), can produce unpredictable results, such
		/// as a distorted image or device failure.
		/// </para>
		/// <para>
		/// Calling this method may cause the current batch to flush if the bitmap is active in the batch. If the batch that was flushed
		/// does not complete successfully, this method fails. However, this method does not clear the error state of the render target
		/// on which the batch was flushed. The failing HRESULT and tag state will be returned at the next call to EndDraw or Flush.
		/// </para>
		/// <para>
		/// Starting with Windows 8.1, this method supports block compressed bitmaps. If you are using a block compressed format, the
		/// end coordinates of the srcRect parameter must be multiples of 4 or the method returns <c>E_INVALIDARG</c>.
		/// </para>
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows/win32/api/d2d1/nf-d2d1-id2d1bitmap-copyfrommemory HRESULT CopyFromMemory( const
		// D2D1_RECT_U *dstRect, const void *srcData, UINT32 pitch );
		new void CopyFromMemory([In, Optional] IntPtr dstRect, [In] IntPtr srcData, uint pitch);

		/// <summary>Gets the color context information associated with the bitmap.</summary>
		/// <param name="colorContext">
		/// <para>Type: <c>ID2D1ColorContext**</c></para>
		/// <para>When this method returns, contains the address of a pointer to the color context interface associated with the bitmap.</para>
		/// </param>
		/// <returns>None</returns>
		/// <remarks>If the bitmap was created without specifying a color context, the returned context is <c>NULL</c>.</remarks>
		// https://docs.microsoft.com/en-us/windows/win32/api/d2d1_1/nf-d2d1_1-id2d1bitmap1-getcolorcontext void GetColorContext(
		// ID2D1ColorContext **colorContext );
		[PreserveSig]
		void GetColorContext(out ID2D1ColorContext colorContext);

		/// <summary>Gets the options used in creating the bitmap.</summary>
		/// <returns>
		/// <para>Type: <c>D2D1_BITMAP_OPTIONS</c></para>
		/// <para>This method returns the options used.</para>
		/// </returns>
		// https://docs.microsoft.com/en-us/windows/win32/api/d2d1_1/nf-d2d1_1-id2d1bitmap1-getoptions D2D1_BITMAP_OPTIONS GetOptions();
		[PreserveSig]
		D2D1_BITMAP_OPTIONS GetOptions();

		/// <summary>
		/// Gets either the surface that was specified when the bitmap was created, or the default surface created when the bitmap was created.
		/// </summary>
		/// <returns>
		/// <para>Type: <c>IDXGISurface**</c></para>
		/// <para>The underlying DXGI surface for the bitmap.</para>
		/// </returns>
		/// <remarks>
		/// <para>
		/// The bitmap used must have been created from a DXGI surface render target, a derived render target, or a device context
		/// created from an ID2D1Device.
		/// </para>
		/// <para>
		/// The returned surface can be used with Microsoft Direct3D or any other API that interoperates with shared surfaces. The
		/// application must transitively ensure that the surface is usable on the Direct3D device that is used in this context. For
		/// example, if using the surface with Direct2D then the Direct2D render target must have been created through
		/// ID2D1Factory::CreateDxgiSurfaceRenderTarget or on a device context created on the same device.
		/// </para>
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows/win32/api/d2d1_1/nf-d2d1_1-id2d1bitmap1-getsurface HRESULT GetSurface( IDXGISurface
		// **dxgiSurface );
		IDXGISurface GetSurface();

		/// <summary>Maps the given bitmap into memory.</summary>
		/// <param name="options">
		/// <para>Type: <c>D2D1_MAP_OPTIONS</c></para>
		/// <para>The options used in mapping the bitmap into memory.</para>
		/// </param>
		/// <returns>
		/// <para>Type: <c>D2D1_MAPPED_RECT*</c></para>
		/// <para>When this method returns, contains a reference to the rectangle that is mapped into memory.</para>
		/// </returns>
		/// <remarks>
		/// <para>
		/// <c>Note</c> You can't use bitmaps for some purposes while mapped. Particularly, the ID2D1Bitmap::CopyFromBitmap method
		/// doesn't work if either the source or destination bitmap is mapped.
		/// </para>
		/// <para>The bitmap must have been created with the <c>D2D1_BITMAP_OPTIONS_CPU_READ</c> flag specified.</para>
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows/win32/api/d2d1_1/nf-d2d1_1-id2d1bitmap1-map HRESULT Map( D2D1_MAP_OPTIONS options,
		// D2D1_MAPPED_RECT *mappedRect );
		D2D1_MAPPED_RECT Map(D2D1_MAP_OPTIONS options);

		/// <summary>Unmaps the bitmap from memory.</summary>
		/// <remarks>
		/// <para>
		/// Any memory returned from the Map call is now invalid and may be reclaimed by the operating system or used for other purposes.
		/// </para>
		/// <para>The bitmap must have been previously mapped.</para>
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows/win32/api/d2d1_1/nf-d2d1_1-id2d1bitmap1-unmap HRESULT Unmap();
		void Unmap();
	}

	/// <summary>Paints an area with a bitmap.</summary>
	// https://docs.microsoft.com/en-us/windows/win32/api/d2d1_1/nn-d2d1_1-id2d1bitmapbrush1
	[PInvokeData("d2d1_1.h", MSDNShortId = "5EF60CF5-DB7E-4453-80A2-F248A82A37E3")]
	[ComImport, Guid("41343a53-e41a-49a2-91cd-21793bbb62e5"), InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
	public interface ID2D1BitmapBrush1 : ID2D1BitmapBrush
	{
		/// <summary>Retrieves the factory associated with this resource.</summary>
		/// <param name="factory">
		/// <para>Type: <c>ID2D1Factory**</c></para>
		/// <para>
		/// When this method returns, contains a pointer to a pointer to the factory that created this resource. This parameter is
		/// passed uninitialized.
		/// </para>
		/// </param>
		// https://docs.microsoft.com/en-us/windows/win32/api/d2d1/nf-d2d1-id2d1resource-getfactory void GetFactory( ID2D1Factory
		// **factory );
		[PreserveSig]
		new void GetFactory(out ID2D1Factory factory);

		/// <summary>Sets the degree of opacity of this brush.</summary>
		/// <param name="opacity">
		/// <para>Type: <c>FLOAT</c></para>
		/// <para>
		/// A value between zero and 1 that indicates the opacity of the brush. This value is a constant multiplier that linearly scales
		/// the alpha value of all pixels filled by the brush. The opacity values are clamped in the range 0–1 before they are multipled together.
		/// </para>
		/// </param>
		/// <returns>None</returns>
		// https://docs.microsoft.com/en-us/windows/win32/api/d2d1/nf-d2d1-id2d1brush-setopacity void SetOpacity( FLOAT opacity );
		[PreserveSig]
		new void SetOpacity(float opacity);

		/// <summary>Sets the transformation applied to the brush.</summary>
		/// <param name="transform">
		/// <para>Type: <c>const D2D1_MATRIX_3X2_F</c></para>
		/// <para>The transformation to apply to this brush.</para>
		/// </param>
		/// <returns>None</returns>
		/// <remarks>
		/// <para>
		/// When you paint with a brush, it paints in the coordinate space of the render target. Brushes do not automatically position
		/// themselves to align with the object being painted; by default, they begin painting at the origin (0, 0) of the render target.
		/// </para>
		/// <para>
		/// You can "move" the gradient defined by an ID2D1LinearGradientBrush to a target area by setting its start point and end
		/// point. Likewise, you can move the gradient defined by an ID2D1RadialGradientBrush by changing its center and radii.
		/// </para>
		/// <para>
		/// To align the content of an ID2D1BitmapBrush to the area being painted, you can use the SetTransform method to translate the
		/// bitmap to the desired location. This transform only affects the brush; it does not affect any other content drawn by the
		/// render target.
		/// </para>
		/// <para>
		/// The following illustrations show the effect of using an ID2D1BitmapBrush to fill a rectangle located at (100, 100). The
		/// illustration on the left illustration shows the result of filling the rectangle without transforming the brush: the bitmap
		/// is drawn at the render target's origin. As a result, only a portion of the bitmap appears in the rectangle.
		/// </para>
		/// <para>
		/// The illustration on the right shows the result of transforming the ID2D1BitmapBrush so that its content is shifted 50 pixels
		/// to the right and 50 pixels down. The bitmap now fills the rectangle.
		/// </para>
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows/win32/api/d2d1/nf-d2d1-id2d1brush-settransform(constd2d1_matrix_3x2_f_) void
		// SetTransform( const D2D1_MATRIX_3X2_F &amp; transform );
		[PreserveSig]
		new void SetTransform(in D2D_MATRIX_3X2_F transform);

		/// <summary>Gets the degree of opacity of this brush.</summary>
		/// <returns>
		/// <para>Type: <c>FLOAT</c></para>
		/// <para>
		/// A value between zero and 1 that indicates the opacity of the brush. This value is a constant multiplier that linearly scales
		/// the alpha value of all pixels filled by the brush. The opacity values are clamped in the range 0–1 before they are multipled together.
		/// </para>
		/// </returns>
		// https://docs.microsoft.com/en-us/windows/win32/api/d2d1/nf-d2d1-id2d1brush-getopacity FLOAT GetOpacity();
		[PreserveSig]
		new float GetOpacity();

		/// <summary>Gets the transform applied to this brush.</summary>
		/// <param name="transform">
		/// <para>Type: <c>D2D1_MATRIX_3X2_F*</c></para>
		/// <para>The transform applied to this brush.</para>
		/// </param>
		/// <returns>None</returns>
		/// <remarks>
		/// When the brush transform is the identity matrix, the brush appears in the same coordinate space as the render target in
		/// which it is drawn.
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows/win32/api/d2d1/nf-d2d1-id2d1brush-gettransform void GetTransform( D2D1_MATRIX_3X2_F
		// *transform );
		[PreserveSig]
		new void GetTransform(out D2D_MATRIX_3X2_F transform);

		/// <summary>Specifies how the brush horizontally tiles those areas that extend past its bitmap.</summary>
		/// <param name="extendModeX">
		/// <para>Type: <c>D2D1_EXTEND_MODE</c></para>
		/// <para>A value that specifies how the brush horizontally tiles those areas that extend past its bitmap.</para>
		/// </param>
		/// <returns>None</returns>
		/// <remarks>
		/// <para>
		/// Sometimes, the bitmap for a bitmap brush doesn't completely fill the area being painted. When this happens, Direct2D uses
		/// the brush's horizontal ( <c>SetExtendModeX</c>) and vertical (SetExtendModeY) extend mode settings to determine how to fill
		/// the remaining area.
		/// </para>
		/// <para>
		/// The following illustration shows the results from every possible combination of the extend modes for an ID2D1BitmapBrush:
		/// D2D1_EXTEND_MODE_CLAMP (CLAMP), <c>D2D1_EXTEND_MODE_WRAP</c> (WRAP), and <c>D2D1_EXTEND_MIRROR</c> (MIRROR).
		/// </para>
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows/win32/api/d2d1/nf-d2d1-id2d1bitmapbrush-setextendmodex void SetExtendModeX(
		// D2D1_EXTEND_MODE extendModeX );
		[PreserveSig]
		new void SetExtendModeX(D2D1_EXTEND_MODE extendModeX);

		/// <summary>Specifies how the brush vertically tiles those areas that extend past its bitmap.</summary>
		/// <param name="extendModeY">
		/// <para>Type: <c>D2D1_EXTEND_MODE</c></para>
		/// <para>A value that specifies how the brush vertically tiles those areas that extend past its bitmap.</para>
		/// </param>
		/// <returns>None</returns>
		/// <remarks>
		/// <para>
		/// Sometimes, the bitmap for a bitmap brush doesn't completely fill the area being painted. When this happens, Direct2D uses
		/// the brush's horizontal (SetExtendModeX) and vertical ( <c>SetExtendModeY</c>) extend mode settings to determine how to fill
		/// the remaining area.
		/// </para>
		/// <para>
		/// The following illustration shows the results from every possible combination of the extend modes for an ID2D1BitmapBrush:
		/// D2D1_EXTEND_MODE_CLAMP (CLAMP), <c>D2D1_EXTEND_MODE_WRAP</c> (WRAP), and <c>D2D1_EXTEND_MIRROR</c> (MIRROR).
		/// </para>
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows/win32/api/d2d1/nf-d2d1-id2d1bitmapbrush-setextendmodey void SetExtendModeY(
		// D2D1_EXTEND_MODE extendModeY );
		[PreserveSig]
		new void SetExtendModeY(D2D1_EXTEND_MODE extendModeY);

		/// <summary>Specifies the interpolation mode used when the brush bitmap is scaled or rotated.</summary>
		/// <param name="interpolationMode">
		/// <para>Type: <c>D2D1_BITMAP_INTERPOLATION_MODE</c></para>
		/// <para>The interpolation mode used when the brush bitmap is scaled or rotated.</para>
		/// </param>
		/// <returns>None</returns>
		/// <remarks>
		/// <para>
		/// This method sets the interpolation mode for a bitmap, which is an enum value that is specified in the
		/// D2D1_BITMAP_INTERPOLATION_MODE enumeration type. D2D1_BITMAP_INTERPOLATION_MODE_NEAREST_NEIGHBOR represents nearest neighbor
		/// filtering. It looks up the nearest bitmap pixel to the current rendering pixel and chooses its exact color.
		/// D2D1_BITMAP_INTERPOLATION_MODE_LINEAR represents linear filtering, and interpolates a color from the four nearest bitmap pixels.
		/// </para>
		/// <para>
		/// The interpolation mode of a bitmap also affects subpixel translations. In a subpixel translation, bilinear interpolation
		/// positions the bitmap more precisely to the application requests, but blurs the bitmap in the process.
		/// </para>
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows/win32/api/d2d1/nf-d2d1-id2d1bitmapbrush-setinterpolationmode void
		// SetInterpolationMode( D2D1_BITMAP_INTERPOLATION_MODE interpolationMode );
		[PreserveSig]
		new void SetInterpolationMode(D2D1_BITMAP_INTERPOLATION_MODE interpolationMode);

		/// <summary>Specifies the bitmap source that this brush uses to paint.</summary>
		/// <param name="bitmap">
		/// <para>Type: <c>ID2D1Bitmap*</c></para>
		/// <para>The bitmap source used by the brush.</para>
		/// </param>
		/// <returns>None</returns>
		/// <remarks>
		/// <para>
		/// This method specifies the bitmap source that this brush uses to paint. The bitmap is not resized or rescaled automatically
		/// to fit the geometry that it fills. The bitmap stays at its native size. To resize or translate the bitmap, use the
		/// SetTransform method to apply a transform to the brush.
		/// </para>
		/// <para>
		/// The native size of a bitmap is the width and height in bitmap pixels, divided by the bitmap DPI. This native size forms the
		/// base tile of the brush. To tile a subregion of the bitmap, you must generate a new bitmap containing this subregion and use
		/// <c>SetBitmap</c> to apply it to the brush.
		/// </para>
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows/win32/api/d2d1/nf-d2d1-id2d1bitmapbrush-setbitmap void SetBitmap( ID2D1Bitmap
		// *bitmap );
		[PreserveSig]
		new void SetBitmap([In, Optional] ID2D1Bitmap? bitmap);

		/// <summary>Gets the method by which the brush horizontally tiles those areas that extend past its bitmap.</summary>
		/// <returns>
		/// <para>Type: <c>D2D1_EXTEND_MODE</c></para>
		/// <para>A value that specifies how the brush horizontally tiles those areas that extend past its bitmap.</para>
		/// </returns>
		/// <remarks>
		/// Like all brushes, ID2D1BitmapBrush defines an infinite plane of content. Because bitmaps are finite, it relies on an extend
		/// mode to determine how the plane is filled horizontally and vertically.
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows/win32/api/d2d1/nf-d2d1-id2d1bitmapbrush-getextendmodex D2D1_EXTEND_MODE GetExtendModeX();
		[PreserveSig]
		new D2D1_EXTEND_MODE GetExtendModeX();

		/// <summary>Gets the method by which the brush vertically tiles those areas that extend past its bitmap.</summary>
		/// <returns>
		/// <para>Type: <c>D2D1_EXTEND_MODE</c></para>
		/// <para>A value that specifies how the brush vertically tiles those areas that extend past its bitmap.</para>
		/// </returns>
		/// <remarks>
		/// <para>Like all brushes, ID2D1BitmapBrush defines an infinite plane of content.</para>
		/// <para>Because bitmaps are finite, it relies on an extend mode to determine how the plane is filled horizontally and vertically.</para>
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows/win32/api/d2d1/nf-d2d1-id2d1bitmapbrush-getextendmodey D2D1_EXTEND_MODE GetExtendModeY();
		[PreserveSig]
		new D2D1_EXTEND_MODE GetExtendModeY();

		/// <summary>Gets the interpolation method used when the brush bitmap is scaled or rotated.</summary>
		/// <returns>
		/// <para>Type: <c>D2D1_BITMAP_INTERPOLATION_MODE</c></para>
		/// <para>The interpolation method used when the brush bitmap is scaled or rotated.</para>
		/// </returns>
		/// <remarks>
		/// <para>
		/// This method gets the interpolation mode of a bitmap, which is specified by the D2D1_BITMAP_INTERPOLATION_MODE enumeration
		/// type. <c>D2D1_BITMAP_INTERPOLATION_MODE_NEAREST_NEIGHBOR</c> represents nearest neighbor filtering. It looks up the bitmap
		/// pixel nearest to the current rendering pixel and chooses its exact color. <c>D2D1_BITMAP_INTERPOLATION_MODE_LINEAR</c>
		/// represents linear filtering, and interpolates a color from the four nearest bitmap pixels.
		/// </para>
		/// <para>
		/// The interpolation mode of a bitmap also affects subpixel translations. In a subpixel translation, linear interpolation
		/// positions the bitmap more precisely to the application request, but blurs the bitmap in the process.
		/// </para>
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows/win32/api/d2d1/nf-d2d1-id2d1bitmapbrush-getinterpolationmode
		// D2D1_BITMAP_INTERPOLATION_MODE GetInterpolationMode();
		[PreserveSig]
		new D2D1_BITMAP_INTERPOLATION_MODE GetInterpolationMode();

		/// <summary>Gets the bitmap source that this brush uses to paint.</summary>
		/// <param name="bitmap">
		/// <para>Type: <c>ID2D1Bitmap**</c></para>
		/// <para>When this method returns, contains the address to a pointer to the bitmap with which this brush paints.</para>
		/// </param>
		/// <returns>None</returns>
		// https://docs.microsoft.com/en-us/windows/win32/api/d2d1/nf-d2d1-id2d1bitmapbrush-getbitmap void GetBitmap( ID2D1Bitmap
		// **bitmap );
		[PreserveSig]
		new void GetBitmap(out ID2D1Bitmap bitmap);

		/// <summary>Sets the interpolation mode for the brush.</summary>
		/// <param name="interpolationMode">
		/// <para>Type: <c>D2D1_INTERPOLATION_MODE</c></para>
		/// <para>The mode to use.</para>
		/// </param>
		/// <returns>
		/// <c>Note</c> If interpolationMode is not a valid member of D2D1_INTERPOLATION_MODE, then this method silently ignores the call.
		/// </returns>
		// https://docs.microsoft.com/en-us/windows/win32/api/d2d1_1/nf-d2d1_1-id2d1bitmapbrush1-setinterpolationmode1 void
		// SetInterpolationMode1( D2D1_INTERPOLATION_MODE interpolationMode );
		[PreserveSig]
		void SetInterpolationMode1(D2D1_INTERPOLATION_MODE interpolationMode);

		/// <summary>Returns the current interpolation mode of the brush.</summary>
		/// <returns>
		/// <para>Type: <c>D2D1_INTERPOLATION_MODE</c></para>
		/// <para>The current interpolation mode.</para>
		/// </returns>
		// https://docs.microsoft.com/en-us/windows/win32/api/d2d1_1/nf-d2d1_1-id2d1bitmapbrush1-getinterpolationmode1
		// D2D1_INTERPOLATION_MODE GetInterpolationMode1();
		[PreserveSig]
		D2D1_INTERPOLATION_MODE GetInterpolationMode1();
	}

	/// <summary>Represents a color context that can be used with an ID2D1Bitmap1 object.</summary>
	// https://docs.microsoft.com/en-us/windows/win32/api/d2d1_1/nn-d2d1_1-id2d1colorcontext
	[PInvokeData("d2d1_1.h", MSDNShortId = "acdda11e-eb3f-4258-b24e-daa3b7a23fd6")]
	[ComImport, Guid("1c4820bb-5771-4518-a581-2fe4dd0ec657"), InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
	public interface ID2D1ColorContext : ID2D1Resource
	{
		/// <summary>Retrieves the factory associated with this resource.</summary>
		/// <param name="factory">
		/// <para>Type: <c>ID2D1Factory**</c></para>
		/// <para>
		/// When this method returns, contains a pointer to a pointer to the factory that created this resource. This parameter is
		/// passed uninitialized.
		/// </para>
		/// </param>
		// https://docs.microsoft.com/en-us/windows/win32/api/d2d1/nf-d2d1-id2d1resource-getfactory void GetFactory( ID2D1Factory
		// **factory );
		[PreserveSig]
		new void GetFactory(out ID2D1Factory factory);

		/// <summary>Gets the color space of the color context.</summary>
		/// <returns>
		/// <para>Type: <c>D2D1_COLOR_SPACE</c></para>
		/// <para>This method returns the color space of the contained ICC profile.</para>
		/// </returns>
		// https://docs.microsoft.com/en-us/windows/win32/api/d2d1_1/nf-d2d1_1-id2d1colorcontext-getcolorspace D2D1_COLOR_SPACE GetColorSpace();
		[PreserveSig]
		D2D1_COLOR_SPACE GetColorSpace();

		/// <summary>Gets the size of the color profile associated with the bitmap.</summary>
		/// <returns>
		/// <para>Type: <c>UINT32</c></para>
		/// <para>This method returns the size of the profile in bytes.</para>
		/// </returns>
		/// <remarks>This can be used to allocate a buffer to receive the color profile bytes associated with the context.</remarks>
		// https://docs.microsoft.com/ja-jp/windows/win32/api/d2d1_1/nf-d2d1_1-id2d1colorcontext-getprofilesize UINT32 GetProfileSize();
		[PreserveSig]
		uint GetProfileSize();

		/// <summary>Gets the color profile bytes for an ID2D1ColorContext.</summary>
		/// <param name="profile">
		/// <para>Type: <c>BYTE*</c></para>
		/// <para>When this method returns, contains the color profile.</para>
		/// </param>
		/// <param name="profileSize">
		/// <para>Type: <c>UINT32</c></para>
		/// <para>The size of the profile buffer.</para>
		/// </param>
		/// <returns>
		/// <para>Type: <c>HRESULT</c></para>
		/// <para>The method returns an <c>HRESULT</c>. Possible values include, but are not limited to, those in the following table.</para>
		/// <list type="table">
		/// <listheader>
		/// <term>HRESULT</term>
		/// <term>Description</term>
		/// </listheader>
		/// <item>
		/// <term>S_OK</term>
		/// <term>No error occurred.</term>
		/// </item>
		/// <item>
		/// <term>D2DERR_INSUFFICIENT_BUFFER</term>
		/// <term>The supplied buffer was too small to accomodate the data.</term>
		/// </item>
		/// </list>
		/// </returns>
		/// <remarks>If profileSize is insufficient to store the entire profile, profile is zero-initialized before this method fails.</remarks>
		// https://docs.microsoft.com/en-us/windows/win32/api/d2d1_1/nf-d2d1_1-id2d1colorcontext-getprofile HRESULT GetProfile( BYTE
		// *profile, UINT32 profileSize );
		void GetProfile([Out] byte[] profile, uint profileSize);
	}

	/// <summary>Represents a sequence of commands that can be recorded and played back.</summary>
	/// <remarks>
	/// <para>
	/// The command list does not include static copies of resources with the recorded set of commands. All bitmaps, effects, and
	/// geometries are stored as references to the actual resource and all the brushes are stored by value. All the resource creation
	/// and destruction happens outside of the command list. The following table lists resources and how they are treated inside of a
	/// command list.
	/// </para>
	/// <list type="table">
	/// <listheader>
	/// <term>Resource</term>
	/// <term>How it is treated by the command list</term>
	/// </listheader>
	/// <item>
	/// <term>Solid-color brush</term>
	/// <term>Passed by value.</term>
	/// </item>
	/// <item>
	/// <term>Bitmap brush</term>
	/// <term>The brush is passed by value but the bitmap that is used to create the brush is in fact referenced.</term>
	/// </item>
	/// <item>
	/// <term>Gradient brushes – both linear and radial gradient</term>
	/// <term>
	/// The brush is passed by value but the gradient stop collection itself is referenced. The gradient stop collection object is immutable.
	/// </term>
	/// </item>
	/// <item>
	/// <term>Bitmaps</term>
	/// <term>Passed by reference.</term>
	/// </item>
	/// <item>
	/// <term>Drawing state block</term>
	/// <term>The actual state on the device context is converted into set functions like set transform and is passed by value.</term>
	/// </item>
	/// <item>
	/// <term>Geometry</term>
	/// <term>Immutable object passed by value.</term>
	/// </item>
	/// <item>
	/// <term>Stroke style</term>
	/// <term>Immutable object passed by value.</term>
	/// </item>
	/// <item>
	/// <term>Mesh</term>
	/// <term>Immutable object passed by value.</term>
	/// </item>
	/// </list>
	/// <para>Using a CommandList as a Target</para>
	/// <para>The following pseudocode illustrates the different cases where a target is set as either a command list or as a bitmap.</para>
	/// <list type="bullet">
	/// <item>
	/// <term>
	/// <c>Set the bitmap as the target:</c> In this case, all contents rendered to the bitmap are rasterized. If this bitmap is used
	/// somewhere else, it will not be resolution independent and if a transformation like High Quality Scale is used, it will not
	/// maintain fidelity.
	/// </term>
	/// </item>
	/// <item>
	/// <term>
	/// <c>Set the command list as the target:</c> In this case, instead of the scene being rasterized, all of the commands are
	/// recorded. When the command list is used later for screen drawing using ID2D1DeviceContext::DrawImage or passed to an XPS print
	/// control, the vector content is replayed with no loss of fidelity.
	/// </term>
	/// </item>
	/// <item>
	/// <term>
	/// <c>Drawing a command list to a bitmap target:</c> In this case because the target is a bitmap, the command list is drawn to the
	/// bitmap and is no longer resolution independent.
	/// </term>
	/// </item>
	/// </list>
	/// <para>
	/// The only way to retain vector content for later playback with full fidelity is to set the target type as a command list. When a
	/// bitmap is set as a target, any drawing on that target will get rasterized.
	/// </para>
	/// <para>Using a CommandList to Create a Brush</para>
	/// <para>
	/// Command lists are a good way to support pattern brushes, because they are capable of retaining fidelity on replay. The desired
	/// pattern can be stored as a command list, which can be used to create an image brush. This brush can then be used to paint paths.
	/// </para>
	/// <para>The type of brush that supports filling a path with a command list is called an image brush.</para>
	/// <para>The following psuedocode illustrates the process of using a command list with an image brush.</para>
	/// <para>Because the brush accepts an image, it has the following other benefits as well:</para>
	/// <list type="bullet">
	/// <item>
	/// <term>
	/// Because the output of an effect graph is an image, this image can be used to create an image brush, which effectively provides
	/// the capability of using an effect as a fill.
	/// </term>
	/// </item>
	/// <item>
	/// <term>
	/// Because the command list is a type of image, vector content can be inserted into an effect graph and can also be tiled or
	/// operated on. For example, a large copyright notice can be inserted over a graph with a virtualized image and then encoded.
	/// </term>
	/// </item>
	/// </list>
	/// <para>Using a CommandList as a Replacement for a Compatible Render Target</para>
	/// <para>
	/// Compatible render targets are used very often for off-screen rendering to an intermediate bitmap that is later composited with
	/// the actual scene. Especially in the case of printing, using compatible render targets will increase the memory footprint because
	/// everything will be rasterized and sent to XPS instead of retaining the actual primitives. In this scenario, a developer is
	/// better off replacing the compatible render target with an intermediate command list. The following pseudo code illustrates this point.
	/// </para>
	/// <para>Working with Other APIs</para>
	/// <para>
	/// Direct2D employs a simple model when interoperating with GDI and Direct3D/DXGI APIs. The command list does not record these
	/// commands. It instead rasterizes the contents in place and stores them as an ID2D1Bitmap. Because the contents are rasterized,
	/// these interop points do not maintain high fidelity.
	/// </para>
	/// <para>
	/// <c>GDI:</c> The command sink interface does not support Get/ReleaseDC() calls. When a call to
	/// ID2D1GdiInteropRenderTarget::ReleaseDC is made, Direct2D renders the contents of the updated region into a D2D1Bitmap. This will
	/// be replayed as an aliased DrawBitmap call with a copy composite mode. To rasterize the bitmap at the correct DPI, at the time of
	/// playback of the commands, whatever DPI value is set using the SetDPI() function is used. This is the only case where the sink
	/// respects the SetDPI() call.
	/// </para>
	/// <para>
	/// <c>DX:</c> Direct3D cannot render directly to the command list. To render Direct3D content in this case, the application can
	/// call DrawBitmap with the ID2D1Bitmap backed by a Direct3D surface.
	/// </para>
	/// </remarks>
	// https://docs.microsoft.com/en-us/windows/win32/api/d2d1_1/nn-d2d1_1-id2d1commandlist
	[ComImport, Guid("b4f34a19-2383-4d76-94f6-ec343657c3dc"), InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
	public interface ID2D1CommandList : ID2D1Image
	{
		/// <summary>Retrieves the factory associated with this resource.</summary>
		/// <param name="factory">
		/// <para>Type: <c>ID2D1Factory**</c></para>
		/// <para>
		/// When this method returns, contains a pointer to a pointer to the factory that created this resource. This parameter is
		/// passed uninitialized.
		/// </para>
		/// </param>
		// https://docs.microsoft.com/en-us/windows/win32/api/d2d1/nf-d2d1-id2d1resource-getfactory void GetFactory( ID2D1Factory
		// **factory );
		[PreserveSig]
		new void GetFactory(out ID2D1Factory factory);

		/// <summary>Streams the contents of the command list to the specified command sink.</summary>
		/// <param name="sink">
		/// <para>Type: <c>ID2D1CommandSink*</c></para>
		/// <para>The sink into which the command list will be streamed.</para>
		/// </param>
		/// <remarks>
		/// <para>The command sink can be implemented by any caller of the API.</para>
		/// <para>
		/// If the caller makes any design-time failure calls while a command list is selected as a target, the command list is placed
		/// in an error state. The stream call fails without making any calls to the passed in sink.
		/// </para>
		/// <para>Sample use:</para>
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows/win32/api/d2d1_1/nf-d2d1_1-id2d1commandlist-stream HRESULT Stream( ID2D1CommandSink
		// *sink );
		void Stream([In] ID2D1CommandSink sink);

		/// <summary>
		/// Instructs the command list to stop accepting commands so that you can use it as an input to an effect or in a call to
		/// ID2D1DeviceContext::DrawImage. You should call the method after it has been attached to an ID2D1DeviceContext and written to
		/// but before the command list is used.
		/// </summary>
		/// <remarks>
		/// <para>
		/// This method returns D2DERR_WRONG_STATE if it has already been called on the command list. If an error occurred on the device
		/// context during population, the method returns that error. Otherwise, the method returns S_OK.
		/// </para>
		/// <para>If the <c>Close</c> method returns an error, any future use of the command list results in the same error.</para>
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows/win32/api/d2d1_1/nf-d2d1_1-id2d1commandlist-close HRESULT Close();
		void Close();
	}

	/// <summary>
	/// <para>
	/// The command sink is implemented by you for an application when you want to receive a playback of the commands recorded in a
	/// command list. A typical usage will be for transforming the command list into another format such as XPS when some degree of
	/// conversion between the Direct2D primitives and the target format is required.
	/// </para>
	/// <para>
	/// The command sink interface doesn't have any resource creation methods on it. The resources are still logically bound to the
	/// Direct2D device on which the command list was created and will be passed in to the command sink implementation.
	/// </para>
	/// </summary>
	/// <remarks>
	/// <para>
	/// The <c>ID2D1CommandSink</c> can be implemented to receive a play-back of the commands recorded in a command list. This interface
	/// is typically used for transforming the command list into another format where some degree of conversion between the Direct2D
	/// primitives and the target format is required.
	/// </para>
	/// <para>
	/// The <c>ID2D1CommandSink</c> interface does not have any resource creation methods. The resources are logically bound to the
	/// Direct2D device on which the ID2D1CommandList was created and will be passed in to the <c>ID2D1CommandSink</c> implementation.
	/// </para>
	/// <para>Not all methods implemented by ID2D1DeviceContext are present.</para>
	/// </remarks>
	// https://docs.microsoft.com/en-us/windows/win32/api/d2d1_1/nn-d2d1_1-id2d1commandsink
	[PInvokeData("d2d1_1.h", MSDNShortId = "4e0ce837-7f4e-4b93-8dd7-68f60cfb1105")]
	[ComImport, Guid("54d7898a-a061-40a7-bec7-e465bcba2c4f"), InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
	public interface ID2D1CommandSink
	{
		/// <summary>Notifies the implementation of the command sink that drawing is about to commence.</summary>
		/// <returns>
		/// <para>Type: <c>HRESULT</c></para>
		/// <para>This method always returns <c>S_OK</c>.</para>
		/// </returns>
		// https://docs.microsoft.com/en-us/windows/win32/api/d2d1_1/nf-d2d1_1-id2d1commandsink-begindraw HRESULT BeginDraw();
		[PreserveSig]
		HRESULT BeginDraw();

		/// <summary>Indicates when ID2D1CommandSink processing has completed.</summary>
		/// <returns>
		/// <para>Type: <c>HRESULT</c></para>
		/// <para>If the method/function succeeds, it returns <c>S_OK</c>. If it fails, it returns an <c>HRESULT</c> error code.</para>
		/// </returns>
		/// <remarks>
		/// <para>The <c>HRESULT</c> active at the end of the command list will be returned.</para>
		/// <para>It allows the calling function or method to indicate a failure back to the stream implementation.</para>
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows/win32/api/d2d1_1/nf-d2d1_1-id2d1commandsink-enddraw HRESULT EndDraw();
		[PreserveSig]
		HRESULT EndDraw();

		/// <summary>Sets the antialiasing mode that will be used to render any subsequent geometry.</summary>
		/// <param name="antialiasMode">
		/// <para>Type: <c>D2D1_ANTIALIAS_MODE</c></para>
		/// <para>The antialiasing mode selected for the command list.</para>
		/// </param>
		/// <returns>
		/// <para>Type: <c>HRESULT</c></para>
		/// <para>If the method succeeds, it returns <c>S_OK</c>. If it fails, it returns an <c>HRESULT</c> error code.</para>
		/// </returns>
		// https://docs.microsoft.com/en-us/windows/win32/api/d2d1_1/nf-d2d1_1-id2d1commandsink-setantialiasmode HRESULT
		// SetAntialiasMode( D2D1_ANTIALIAS_MODE antialiasMode );
		[PreserveSig]
		HRESULT SetAntialiasMode(D2D1_ANTIALIAS_MODE antialiasMode);

		/// <summary>Sets the tags that correspond to the tags in the command sink.</summary>
		/// <param name="tag1">
		/// <para>Type: <c>D2D1_TAG</c></para>
		/// <para>The first tag to associate with the primitive.</para>
		/// </param>
		/// <param name="tag2">
		/// <para>Type: <c>D2D1_TAG</c></para>
		/// <para>The second tag to associate with the primitive.</para>
		/// </param>
		/// <returns>
		/// <para>Type: <c>HRESULT</c></para>
		/// <para>If the method succeeds, it returns <c>S_OK</c>. If it fails, it returns an <c>HRESULT</c> error code.</para>
		/// </returns>
		// https://docs.microsoft.com/en-us/windows/win32/api/d2d1_1/nf-d2d1_1-id2d1commandsink-settags HRESULT SetTags( D2D1_TAG tag1,
		// D2D1_TAG tag2 );
		[PreserveSig]
		HRESULT SetTags(ulong tag1, ulong tag2);

		/// <summary>Indicates the new default antialiasing mode for text.</summary>
		/// <param name="textAntialiasMode">
		/// <para>Type: <c>D2D1_TEXT_ANTIALIAS_MODE</c></para>
		/// <para>The antialiasing mode for the text.</para>
		/// </param>
		/// <returns>
		/// <para>Type: <c>HRESULT</c></para>
		/// <para>If the method succeeds, it returns <c>S_OK</c>. If it fails, it returns an <c>HRESULT</c> error code.</para>
		/// </returns>
		// https://docs.microsoft.com/en-us/windows/win32/api/d2d1_1/nf-d2d1_1-id2d1commandsink-settextantialiasmode HRESULT
		// SetTextAntialiasMode( D2D1_TEXT_ANTIALIAS_MODE textAntialiasMode );
		[PreserveSig]
		HRESULT SetTextAntialiasMode(D2D1_TEXT_ANTIALIAS_MODE textAntialiasMode);

		/// <summary>Indicates more detailed text rendering parameters.</summary>
		/// <param name="textRenderingParams">
		/// <para>Type: <c>IDWriteRenderingParams*</c></para>
		/// <para>The parameters to use for text rendering.</para>
		/// </param>
		/// <returns>
		/// <para>Type: <c>HRESULT</c></para>
		/// <para>If the method succeeds, it returns <c>S_OK</c>. If it fails, it returns an <c>HRESULT</c> error code.</para>
		/// </returns>
		// https://docs.microsoft.com/en-us/windows/win32/api/d2d1_1/nf-d2d1_1-id2d1commandsink-settextrenderingparams HRESULT
		// SetTextRenderingParams( IDWriteRenderingParams *textRenderingParams );
		[PreserveSig]
		HRESULT SetTextRenderingParams([In, Optional] IDWriteRenderingParams? textRenderingParams);

		/// <summary>Sets a new transform.</summary>
		/// <param name="transform">
		/// <para>Type: <c>const D2D1_MATRIX_3X2_F*</c></para>
		/// <para>The transform to be set.</para>
		/// </param>
		/// <returns>
		/// <para>Type: <c>HRESULT</c></para>
		/// <para>If the method succeeds, it returns <c>S_OK</c>. If it fails, it returns an <c>HRESULT</c> error code.</para>
		/// </returns>
		/// <remarks>The transform will be applied to the corresponding device context.</remarks>
		// https://docs.microsoft.com/en-us/windows/win32/api/d2d1_1/nf-d2d1_1-id2d1commandsink-settransform HRESULT SetTransform( const
		// D2D1_MATRIX_3X2_F *transform );
		[PreserveSig]
		HRESULT SetTransform(in D2D_MATRIX_3X2_F transform);

		/// <summary>Sets a new primitive blend mode.</summary>
		/// <param name="primitiveBlend">
		/// <para>Type: <c>D2D1_PRIMITIVE_BLEND</c></para>
		/// <para>The primitive blend that will apply to subsequent primitives.</para>
		/// </param>
		/// <returns>
		/// <para>Type: <c>HRESULT</c></para>
		/// <para>If the method succeeds, it returns <c>S_OK</c>. If it fails, it returns an <c>HRESULT</c> error code.</para>
		/// </returns>
		// https://docs.microsoft.com/en-us/windows/win32/api/d2d1_1/nf-d2d1_1-id2d1commandsink-setprimitiveblend HRESULT
		// SetPrimitiveBlend( D2D1_PRIMITIVE_BLEND primitiveBlend );
		[PreserveSig]
		HRESULT SetPrimitiveBlend(D2D1_PRIMITIVE_BLEND primitiveBlend);

		/// <summary>
		/// The unit mode changes the meaning of subsequent units from device-independent pixels (DIPs) to pixels or the other way. The
		/// command sink does not record a DPI, this is implied by the playback context or other playback interface such as ID2D1PrintControl.
		/// </summary>
		/// <param name="unitMode">
		/// <para>Type: <c>D2D1_UNIT_MODE</c></para>
		/// <para>The enumeration that specifies how units are to be interpreted.</para>
		/// </param>
		/// <returns>
		/// <para>Type: <c>HRESULT</c></para>
		/// <para>If the method succeeds, it returns <c>S_OK</c>. If it fails, it returns an <c>HRESULT</c> error code.</para>
		/// </returns>
		/// <remarks>The unit mode changes the interpretation of units from DIPs to pixels or vice versa.</remarks>
		// https://docs.microsoft.com/en-us/windows/win32/api/d2d1_1/nf-d2d1_1-id2d1commandsink-setunitmode HRESULT SetUnitMode(
		// D2D1_UNIT_MODE unitMode );
		[PreserveSig]
		HRESULT SetUnitMode(D2D1_UNIT_MODE unitMode);

		/// <summary>Clears the drawing area to the specified color.</summary>
		/// <param name="color">
		/// <para>Type: <c>const D2D1_COLOR_F*</c></para>
		/// <para>The color to which the command sink should be cleared.</para>
		/// </param>
		/// <returns>
		/// <para>Type: <c>HRESULT</c></para>
		/// <para>If the method succeeds, it returns <c>S_OK</c>. If it fails, it returns an <c>HRESULT</c> error code.</para>
		/// </returns>
		/// <remarks>
		/// <para>The clear color is restricted by the currently selected clip and layer bounds.</para>
		/// <para>If no color is specified, the color should be interpreted by context. Examples include but are not limited to:</para>
		/// <list type="bullet">
		/// <item>
		/// <term>Transparent black for a premultiplied bitmap target.</term>
		/// </item>
		/// <item>
		/// <term>Opaque black for an ignore bitmap target.</term>
		/// </item>
		/// <item>
		/// <term>Containing no content (or white) for a printer page.</term>
		/// </item>
		/// </list>
		/// </remarks>
		// https://docs.microsoft.com/ja-jp/windows/win32/api/d2d1_1/nf-d2d1_1-id2d1commandsink-clear HRESULT Clear( const D2D1_COLOR_F
		// *color );
		[PreserveSig]
		HRESULT Clear([In, Optional] IntPtr color);

		/// <summary>Indicates the glyphs to be drawn.</summary>
		/// <param name="baselineOrigin">
		/// <para>Type: <c>D2D1_POINT_2F</c></para>
		/// <para>The upper left corner of the baseline.</para>
		/// </param>
		/// <param name="glyphRun">
		/// <para>Type: <c>const DWRITE_GLYPH_RUN*</c></para>
		/// <para>The glyphs to render.</para>
		/// </param>
		/// <param name="glyphRunDescription">
		/// <para>Type: <c>const DWRITE_GLYPH_RUN_DESCRIPTION*</c></para>
		/// <para>Additional non-rendering information about the glyphs.</para>
		/// </param>
		/// <param name="foregroundBrush">
		/// <para>Type: <c>ID2D1Brush*</c></para>
		/// <para>The brush used to fill the glyphs.</para>
		/// </param>
		/// <param name="measuringMode">
		/// <para>Type: <c>DWRITE_MEASURING_MODE</c></para>
		/// <para>The measuring mode to apply to the glyphs.</para>
		/// </param>
		/// <returns>
		/// <para>Type: <c>HRESULT</c></para>
		/// <para>If the method succeeds, it returns <c>S_OK</c>. If it fails, it returns an <c>HRESULT</c> error code.</para>
		/// </returns>
		/// <remarks>
		/// DrawText and DrawTextLayout are broken down into glyph runs and rectangles by the time the command sink is processed. So,
		/// these methods aren't available on the command sink. Since the application may require additional callback processing when
		/// calling <c>DrawTextLayout</c>, this semantic can't be easily preserved in the command list.
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows/win32/api/d2d1_1/nf-d2d1_1-id2d1commandsink-drawglyphrun HRESULT DrawGlyphRun(
		// D2D1_POINT_2F baselineOrigin, const DWRITE_GLYPH_RUN *glyphRun, const DWRITE_GLYPH_RUN_DESCRIPTION *glyphRunDescription,
		// ID2D1Brush *foregroundBrush, DWRITE_MEASURING_MODE measuringMode );
		[PreserveSig]
		HRESULT DrawGlyphRun(D2D_POINT_2F baselineOrigin, in DWRITE_GLYPH_RUN glyphRun, [In, Optional] IntPtr glyphRunDescription, [In] ID2D1Brush foregroundBrush, DWRITE_MEASURING_MODE measuringMode);

		/// <summary>Draws a line drawn between two points.</summary>
		/// <param name="point0">
		/// <para>Type: <c>D2D1_POINT_2F</c></para>
		/// <para>The start point of the line.</para>
		/// </param>
		/// <param name="point1">
		/// <para>Type: <c>D2D1_POINT_2F</c></para>
		/// <para>The end point of the line.</para>
		/// </param>
		/// <param name="brush">
		/// <para>Type: <c>ID2D1Brush*</c></para>
		/// <para>The brush used to fill the line.</para>
		/// </param>
		/// <param name="strokeWidth">
		/// <para>Type: <c>FLOAT</c></para>
		/// <para>The width of the stroke to fill the line.</para>
		/// </param>
		/// <param name="strokeStyle">
		/// <para>Type: <c>ID2D1StrokeStyle*</c></para>
		/// <para>The style of the stroke. If not specified, the stroke is solid.</para>
		/// </param>
		/// <returns>
		/// <para>Type: <c>HRESULT</c></para>
		/// <para>If the method succeeds, it returns <c>S_OK</c>. If it fails, it returns an <c>HRESULT</c> error code.</para>
		/// </returns>
		/// <remarks>Additional References</remarks>
		// https://docs.microsoft.com/en-us/windows/win32/api/d2d1_1/nf-d2d1_1-id2d1commandsink-drawline HRESULT DrawLine( D2D1_POINT_2F
		// point0, D2D1_POINT_2F point1, ID2D1Brush *brush, FLOAT strokeWidth, ID2D1StrokeStyle *strokeStyle );
		[PreserveSig]
		HRESULT DrawLine(D2D_POINT_2F point0, D2D_POINT_2F point1, [In] ID2D1Brush brush, float strokeWidth, [In, Optional] ID2D1StrokeStyle? strokeStyle);

		/// <summary>Indicates the geometry to be drawn to the command sink.</summary>
		/// <param name="geometry">
		/// <para>Type: <c>ID2D1Geometry *</c></para>
		/// <para>The geometry to be stroked.</para>
		/// </param>
		/// <param name="brush">
		/// <para>Type: <c>ID2D1Brush*</c></para>
		/// <para>The brush that will be used to fill the stroked geometry.</para>
		/// </param>
		/// <param name="strokeWidth">
		/// <para>Type: <c>FLOAT</c></para>
		/// <para>The width of the stroke.</para>
		/// </param>
		/// <param name="strokeStyle">
		/// <para>Type: <c>ID2D1StrokeStyle*</c></para>
		/// <para>The style of the stroke.</para>
		/// </param>
		/// <returns>
		/// <para>Type: <c>HRESULT</c></para>
		/// <para>An HRESULT.</para>
		/// </returns>
		/// <remarks>
		/// Ellipses and rounded rectangles are converted to the corresponding ellipse and rounded rectangle geometries before calling
		/// into the <c>DrawGeometry</c> method.
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows/win32/api/d2d1_1/nf-d2d1_1-id2d1commandsink-drawgeometry HRESULT DrawGeometry(
		// ID2D1Geometry *geometry, ID2D1Brush *brush, FLOAT strokeWidth, ID2D1StrokeStyle *strokeStyle );
		[PreserveSig]
		HRESULT DrawGeometry([In] ID2D1Geometry geometry, [In] ID2D1Brush brush, float strokeWidth, [In, Optional] ID2D1StrokeStyle? strokeStyle);

		/// <summary>Draws a rectangle.</summary>
		/// <param name="rect">
		/// <para>Type: <c>const D2D1_RECT_F*</c></para>
		/// <para>The rectangle to be drawn to the command sink.</para>
		/// </param>
		/// <param name="brush">
		/// <para>Type: <c>ID2D1Brush*</c></para>
		/// <para>The brush used to stroke the geometry.</para>
		/// </param>
		/// <param name="strokeWidth">
		/// <para>Type: <c>FLOAT</c></para>
		/// <para>The width of the stroke.</para>
		/// </param>
		/// <param name="strokeStyle">
		/// <para>Type: <c>ID2D1StrokeStyle*</c></para>
		/// <para>The style of the stroke.</para>
		/// </param>
		/// <returns>
		/// <para>Type: <c>HRESULT</c></para>
		/// <para>If the method succeeds, it returns <c>S_OK</c>. If it fails, it returns an <c>HRESULT</c> error code.</para>
		/// </returns>
		// https://docs.microsoft.com/en-us/windows/win32/api/d2d1_1/nf-d2d1_1-id2d1commandsink-drawrectangle HRESULT DrawRectangle(
		// const D2D1_RECT_F *rect, ID2D1Brush *brush, FLOAT strokeWidth, ID2D1StrokeStyle *strokeStyle );
		[PreserveSig]
		HRESULT DrawRectangle(in D2D_RECT_F rect, [In] ID2D1Brush brush, float strokeWidth, [In, Optional] ID2D1StrokeStyle? strokeStyle);

		/// <summary>Draws a bitmap to the render target.</summary>
		/// <param name="bitmap">
		/// <para>Type: <c>ID2D1Bitmap*</c></para>
		/// <para>The bitmap to draw.</para>
		/// </param>
		/// <param name="destinationRectangle">
		/// <para>Type: <c>D2D1_RECT_F</c></para>
		/// <para>
		/// The destination rectangle. The default is the size of the bitmap and the location is the upper left corner of the render target.
		/// </para>
		/// </param>
		/// <param name="opacity">
		/// <para>Type: <c>FLOAT</c></para>
		/// <para>The opacity of the bitmap.</para>
		/// </param>
		/// <param name="interpolationMode">
		/// <para>Type: <c>D2D1_INTERPOLATION_MODE</c></para>
		/// <para>The interpolation mode to use.</para>
		/// </param>
		/// <param name="sourceRectangle">
		/// <para>Type: <c>const D2D1_RECT_F</c></para>
		/// <para>An optional source rectangle.</para>
		/// </param>
		/// <param name="perspectiveTransform">
		/// <para>Type: <c>const D2D1_MATRIX_4X4_F</c></para>
		/// <para>An optional perspective transform.</para>
		/// </param>
		/// <returns>This method does not return a value.</returns>
		/// <remarks>
		/// <para>
		/// The destinationRectangle parameter defines the rectangle in the target where the bitmap will appear (in device-independent
		/// pixels (DIPs)). This is affected by the currently set transform and the perspective transform, if set. If you specify NULL,
		/// then the destination rectangle is (left=0, top=0, right = width(sourceRectangle), bottom = height(sourceRectangle).
		/// </para>
		/// <para>
		/// The sourceRectangle defines the sub-rectangle of the source bitmap (in DIPs). <c>DrawBitmap</c> clips this rectangle to the
		/// size of the source bitmap, so it's impossible to sample outside of the bitmap. If you specify NULL, then the source
		/// rectangle is taken to be the size of the source bitmap.
		/// </para>
		/// <para>The perspectiveTransform is specified in addition to the transform on device context.</para>
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows/win32/api/d2d1_1/nf-d2d1_1-id2d1commandsink-drawbitmap HRESULT DrawBitmap(
		// ID2D1Bitmap *bitmap, const D2D1_RECT_F *destinationRectangle, FLOAT opacity, D2D1_INTERPOLATION_MODE interpolationMode, const
		// D2D1_RECT_F *sourceRectangle, const D2D1_MATRIX_4X4_F *perspectiveTransform );
		[PreserveSig]
		HRESULT DrawBitmap([In] ID2D1Bitmap bitmap, [In, Optional] IntPtr destinationRectangle, float opacity, D2D1_INTERPOLATION_MODE interpolationMode, [In, Optional] IntPtr sourceRectangle, [In, Optional] IntPtr perspectiveTransform);

		/// <summary>Draws the provided image to the command sink.</summary>
		/// <param name="image">
		/// <para>Type: <c>ID2D1Image*</c></para>
		/// <para>The image to be drawn to the command sink.</para>
		/// </param>
		/// <param name="targetOffset">
		/// <para>Type: <c>const D2D1_POINT_2F*</c></para>
		/// <para>
		/// This defines the offset in the destination space that the image will be rendered to. The entire logical extent of the image
		/// will be rendered to the corresponding destination. If not specified, the destination origin will be (0, 0). The top-left
		/// corner of the image will be mapped to the target offset. This will not necessarily be the origin.
		/// </para>
		/// </param>
		/// <param name="imageRectangle">
		/// <para>Type: <c>const D2D1_RECT_F*</c></para>
		/// <para>The corresponding rectangle in the image space will be mapped to the provided origins when processing the image.</para>
		/// </param>
		/// <param name="interpolationMode">
		/// <para>Type: <c>D2D1_INTERPOLATION_MODE</c></para>
		/// <para>The interpolation mode to use to scale the image if necessary.</para>
		/// </param>
		/// <param name="compositeMode">
		/// <para>Type: <c>D2D1_COMPOSITE_MODE</c></para>
		/// <para>If specified, the composite mode that will be applied to the limits of the currently selected clip.</para>
		/// </param>
		/// <returns>
		/// <para>Type: <c>HRESULT</c></para>
		/// <para>If the method succeeds, it returns <c>S_OK</c>. If it fails, it returns an <c>HRESULT</c> error code.</para>
		/// </returns>
		/// <remarks>
		/// Because the image can itself be a command list or contain an effect graph that in turn contains a command list, this method
		/// can result in recursive processing.
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows/win32/api/d2d1_1/nf-d2d1_1-id2d1commandsink-drawimage HRESULT DrawImage( ID2D1Image
		// *image, const D2D1_POINT_2F *targetOffset, const D2D1_RECT_F *imageRectangle, D2D1_INTERPOLATION_MODE interpolationMode,
		// D2D1_COMPOSITE_MODE compositeMode );
		[PreserveSig]
		HRESULT DrawImage([In] ID2D1Image image, [In, Optional] IntPtr targetOffset, [In, Optional] IntPtr imageRectangle, D2D1_INTERPOLATION_MODE interpolationMode, D2D1_COMPOSITE_MODE compositeMode);

		/// <summary>Draw a metafile to the device context.</summary>
		/// <param name="gdiMetafile">
		/// <para>Type: <c>ID2D1GdiMetafile*</c></para>
		/// <para>The metafile to draw.</para>
		/// </param>
		/// <param name="targetOffset">
		/// <para>Type: <c>const D2D1_POINT_2F*</c></para>
		/// <para>The offset from the upper left corner of the render target.</para>
		/// </param>
		/// <returns>This method does not return a value.</returns>
		/// <remarks>
		/// The targetOffset defines the offset in the destination space that the image will be rendered to. The entire logical extent
		/// of the image is rendered to the corresponding destination. If you don't specify the offset, the destination origin will be
		/// (0, 0). The top, left corner of the image will be mapped to the target offset. This will not necessarily be the origin.
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows/win32/api/d2d1_1/nf-d2d1_1-id2d1commandsink-drawgdimetafile HRESULT DrawGdiMetafile(
		// ID2D1GdiMetafile *gdiMetafile, const D2D1_POINT_2F *targetOffset );
		[PreserveSig]
		HRESULT DrawGdiMetafile([In] ID2D1GdiMetafile gdiMetafile, [In, Optional] IntPtr targetOffset);

		/// <summary>Indicates a mesh to be filled by the command sink.</summary>
		/// <param name="mesh">
		/// <para>Type: <c>ID2D1Mesh*</c></para>
		/// <para>The mesh object to be filled.</para>
		/// </param>
		/// <param name="brush">
		/// <para>Type: <c>ID2D1Brush*</c></para>
		/// <para>The brush with which to fill the mesh.</para>
		/// </param>
		/// <returns>
		/// <para>Type: <c>HRESULT</c></para>
		/// <para>If the method succeeds, it returns <c>S_OK</c>. If it fails, it returns an <c>HRESULT</c> error code.</para>
		/// </returns>
		// https://docs.microsoft.com/en-us/windows/win32/api/d2d1_1/nf-d2d1_1-id2d1commandsink-fillmesh HRESULT FillMesh( ID2D1Mesh
		// *mesh, ID2D1Brush *brush );
		[PreserveSig]
		HRESULT FillMesh([In] ID2D1Mesh mesh, [In] ID2D1Brush brush);

		/// <summary>Fills an opacity mask on the command sink.</summary>
		/// <param name="opacityMask">
		/// <para>Type: <c>ID2D1Bitmap*</c></para>
		/// <para>The bitmap whose alpha channel will be sampled to define the opacity mask.</para>
		/// </param>
		/// <param name="brush">
		/// <para>Type: <c>ID2D1Brush*</c></para>
		/// <para>The brush with which to fill the mask.</para>
		/// </param>
		/// <param name="destinationRectangle">
		/// <para>Type: <c>const D2D1_RECT_F*</c></para>
		/// <para>The destination rectangle in which to fill the mask. If not specified, this is the origin.</para>
		/// </param>
		/// <param name="sourceRectangle">
		/// <para>Type: <c>const D2D1_RECT_F*</c></para>
		/// <para>The source rectangle within the opacity mask. If not specified, this is the entire mask.</para>
		/// </param>
		/// <returns>
		/// <para>Type: <c>HRESULT</c></para>
		/// <para>If the method succeeds, it returns <c>S_OK</c>. If it fails, it returns an <c>HRESULT</c> error code.</para>
		/// </returns>
		/// <remarks>The opacity mask bitmap must be considered to be clamped on each axis.</remarks>
		// https://docs.microsoft.com/en-us/windows/win32/api/d2d1_1/nf-d2d1_1-id2d1commandsink-fillopacitymask HRESULT FillOpacityMask(
		// ID2D1Bitmap *opacityMask, ID2D1Brush *brush, const D2D1_RECT_F *destinationRectangle, const D2D1_RECT_F *sourceRectangle );
		[PreserveSig]
		HRESULT FillOpacityMask([In] ID2D1Bitmap opacityMask, [In] ID2D1Brush brush, [In, Optional] IntPtr destinationRectangle, [In, Optional] IntPtr sourceRectangle);

		/// <summary>Indicates to the command sink a geometry to be filled.</summary>
		/// <param name="geometry">
		/// <para>Type: <c>ID2D1Geometry*</c></para>
		/// <para>The geometry that should be filled.</para>
		/// </param>
		/// <param name="brush">
		/// <para>Type: <c>ID2D1Brush*</c></para>
		/// <para>The primary brush used to fill the geometry.</para>
		/// </param>
		/// <param name="opacityBrush">
		/// <para>Type: <c>ID2D1Brush*</c></para>
		/// <para>A brush whose alpha channel is used to modify the opacity of the primary fill brush.</para>
		/// </param>
		/// <returns>
		/// <para>Type: <c>HRESULT</c></para>
		/// <para>If the method succeeds, it returns <c>S_OK</c>. If it fails, it returns an <c>HRESULT</c> error code.</para>
		/// </returns>
		/// <remarks>
		/// <para>If the opacity brush is specified, the primary brush will be a bitmap brush fixed on both the x-axis and the y-axis.</para>
		/// <para>Ellipses and rounded rectangles are converted to the corresponding geometry before being passed to <c>FillGeometry</c>.</para>
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows/win32/api/d2d1_1/nf-d2d1_1-id2d1commandsink-fillgeometry HRESULT FillGeometry(
		// ID2D1Geometry *geometry, ID2D1Brush *brush, ID2D1Brush *opacityBrush );
		[PreserveSig]
		HRESULT FillGeometry([In] ID2D1Geometry geometry, [In] ID2D1Brush brush, [In, Optional] ID2D1Brush? opacityBrush);

		/// <summary>Indicates to the command sink a rectangle to be filled.</summary>
		/// <param name="rect">
		/// <para>Type: <c>const D2D1_RECT_F*</c></para>
		/// <para>The rectangle to fill.</para>
		/// </param>
		/// <param name="brush">
		/// <para>Type: <c>ID2D1Brush*</c></para>
		/// <para>The brush with which to fill the rectangle.</para>
		/// </param>
		/// <returns>
		/// <para>Type: <c>HRESULT</c></para>
		/// <para>If the method succeeds, it returns <c>S_OK</c>. If it fails, it returns an <c>HRESULT</c> error code.</para>
		/// </returns>
		// https://docs.microsoft.com/en-us/windows/win32/api/d2d1_1/nf-d2d1_1-id2d1commandsink-fillrectangle HRESULT FillRectangle(
		// const D2D1_RECT_F *rect, ID2D1Brush *brush );
		[PreserveSig]
		HRESULT FillRectangle(in D2D_RECT_F rect, [In] ID2D1Brush brush);

		/// <summary>Pushes a clipping rectangle onto the clip and layer stack.</summary>
		/// <param name="clipRect">
		/// <para>Type: <c>const D2D1_RECT_F*</c></para>
		/// <para>The rectangle that defines the clip.</para>
		/// </param>
		/// <param name="antialiasMode">
		/// <para>Type: <c>D2D1_ANTIALIAS_MODE</c></para>
		/// <para>The antialias mode for the clip.</para>
		/// </param>
		/// <returns>
		/// <para>Type: <c>HRESULT</c></para>
		/// <para>If the method succeeds, it returns <c>S_OK</c>. If it fails, it returns an <c>HRESULT</c> error code.</para>
		/// </returns>
		/// <remarks>
		/// If the current world transform is not preserving the axis, clipRectangle is transformed and the bounds of the transformed
		/// rectangle are used instead.
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows/win32/api/d2d1_1/nf-d2d1_1-id2d1commandsink-pushaxisalignedclip HRESULT
		// PushAxisAlignedClip( const D2D1_RECT_F *clipRect, D2D1_ANTIALIAS_MODE antialiasMode );
		[PreserveSig]
		HRESULT PushAxisAlignedClip(in D2D_RECT_F clipRect, D2D1_ANTIALIAS_MODE antialiasMode);

		/// <summary>Pushes a layer onto the clip and layer stack.</summary>
		/// <param name="layerParameters1">
		/// <para>Type: <c>const D2D1_LAYER_PARAMETERS1*</c></para>
		/// <para>The parameters that define the layer.</para>
		/// </param>
		/// <param name="layer">
		/// <para>Type: <c>ID2D1Layer*</c></para>
		/// <para>The layer resource that receives subsequent drawing operations.</para>
		/// </param>
		/// <returns>
		/// <para>Type: <c>HRESULT</c></para>
		/// <para>If the method succeeds, it returns <c>S_OK</c>. If it fails, it returns an <c>HRESULT</c> error code.</para>
		/// </returns>
		// https://docs.microsoft.com/en-us/windows/win32/api/d2d1_1/nf-d2d1_1-id2d1commandsink-pushlayer HRESULT PushLayer( const
		// D2D1_LAYER_PARAMETERS1 *layerParameters1, ID2D1Layer *layer );
		[PreserveSig]
		HRESULT PushLayer(in D2D1_LAYER_PARAMETERS1 layerParameters1, [In, Optional] ID2D1Layer? layer);

		/// <summary>Removes an axis-aligned clip from the layer and clip stack.</summary>
		/// <returns>
		/// <para>Type: <c>HRESULT</c></para>
		/// <para>If the method succeeds, it returns <c>S_OK</c>. If it fails, it returns an <c>HRESULT</c> error code.</para>
		/// </returns>
		// https://docs.microsoft.com/en-us/windows/win32/api/d2d1_1/nf-d2d1_1-id2d1commandsink-popaxisalignedclip HRESULT PopAxisAlignedClip();
		[PreserveSig]
		HRESULT PopAxisAlignedClip();

		/// <summary>Removes a layer from the layer and clip stack.</summary>
		/// <returns>
		/// <para>Type: <c>HRESULT</c></para>
		/// <para>If the method succeeds, it returns <c>S_OK</c>. If it fails, it returns an <c>HRESULT</c> error code.</para>
		/// </returns>
		// https://docs.microsoft.com/en-us/windows/win32/api/d2d1_1/nf-d2d1_1-id2d1commandsink-poplayer HRESULT PopLayer();
		[PreserveSig]
		HRESULT PopLayer();
	}

	/// <summary>Represents a resource domain whose objects and device contexts can be used together.</summary>
	// https://docs.microsoft.com/en-us/windows/win32/api/d2d1_1/nn-d2d1_1-id2d1device
	[PInvokeData("d2d1_1.h", MSDNShortId = "21f77c38-c115-4fdf-b294-570577a29201")]
	[ComImport, Guid("47dd575d-ac05-4cdd-8049-9b02cd16f44c"), InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
	public interface ID2D1Device : ID2D1Resource
	{
		/// <summary>Retrieves the factory associated with this resource.</summary>
		/// <param name="factory">
		/// <para>Type: <c>ID2D1Factory**</c></para>
		/// <para>
		/// When this method returns, contains a pointer to a pointer to the factory that created this resource. This parameter is
		/// passed uninitialized.
		/// </para>
		/// </param>
		// https://docs.microsoft.com/en-us/windows/win32/api/d2d1/nf-d2d1-id2d1resource-getfactory void GetFactory( ID2D1Factory
		// **factory );
		[PreserveSig]
		new void GetFactory(out ID2D1Factory factory);

		/// <summary>Creates a new device context from a Direct2D device.</summary>
		/// <param name="options">
		/// <para>Type: <c>D2D1_DEVICE_CONTEXT_OPTIONS</c></para>
		/// <para>The options to be applied to the created device context.</para>
		/// </param>
		/// <returns>
		/// <para>Type: <c>const ID2D1DeviceContext**</c></para>
		/// <para>When this method returns, contains the address of a pointer to the new device context.</para>
		/// </returns>
		/// <remarks>
		/// The new device context will not have a selected target bitmap. The caller must create and select a bitmap as the target
		/// surface of the context.
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows/win32/api/d2d1_1/nf-d2d1_1-id2d1device-createdevicecontext HRESULT
		// CreateDeviceContext( D2D1_DEVICE_CONTEXT_OPTIONS options, ID2D1DeviceContext **deviceContext );
		ID2D1DeviceContext CreateDeviceContext(D2D1_DEVICE_CONTEXT_OPTIONS options);

		/// <summary>
		/// Creates an ID2D1PrintControl object that converts Direct2D primitives stored in ID2D1CommandList into a fixed page
		/// representation. The print sub-system then consumes the primitives.
		/// </summary>
		/// <param name="wicFactory">
		/// <para>Type: <c>IWICImagingFactory*</c></para>
		/// <para>A WIC imaging factory.</para>
		/// </param>
		/// <param name="documentTarget">
		/// <para>Type: <c>IPrintDocumentPackageTarget*</c></para>
		/// <para>The target print job for this control.</para>
		/// </param>
		/// <param name="printControlProperties">
		/// <para>Type: <c>const D2D1_PRINT_CONTROL_PROPERTIES*</c></para>
		/// <para>The options to be applied to the print control.</para>
		/// </param>
		/// <returns>
		/// <para>Type: <c>ID2D1PrintControl**</c></para>
		/// <para>When this method returns, contains the address of a pointer to an ID2D1PrintControl object.</para>
		/// </returns>
		/// <remarks>
		/// <c>Note</c> This is a blocking or synchronous function and might not return immediately. How quickly this function returns
		/// depends on run-time factors such as network status, print server configuration, and printer driver implementation—factors
		/// that are difficult to predict when writing an application. Calling this function from a thread that manages interaction with
		/// the user interface could make the application appear to be unresponsive.
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows/win32/api/d2d1_1/nf-d2d1_1-id2d1device-createprintcontrol(iwicimagingfactory_iprintdocumentpackagetarget_constd2d1_print_control_properties_id2d1printcontrol)
		// HRESULT CreatePrintControl( IWICImagingFactory *wicFactory, IPrintDocumentPackageTarget *documentTarget, const
		// D2D1_PRINT_CONTROL_PROPERTIES *printControlProperties, ID2D1PrintControl **printControl );
		ID2D1PrintControl CreatePrintControl(IWICImagingFactory wicFactory, [In, MarshalAs(UnmanagedType.Interface)] /*IPrintDocumentPackageTarget*/ object documentTarget, in D2D1_PRINT_CONTROL_PROPERTIES printControlProperties);

		/// <summary>
		/// Sets the maximum amount of texture memory Direct2D accumulates before it purges the image caches and cached texture allocations.
		/// </summary>
		/// <param name="maximumInBytes">
		/// <para>Type: <c>UINT64</c></para>
		/// <para>The new maximum texture memory in bytes.</para>
		/// </param>
		/// <returns>None</returns>
		/// <remarks>
		/// <c>Note</c> Direct2D may exceed the maximum texture memory you set with this method for a single frame if necessary to
		/// render the frame.
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows/win32/api/d2d1_1/nf-d2d1_1-id2d1device-setmaximumtexturememory void
		// SetMaximumTextureMemory( UINT64 maximumInBytes );
		[PreserveSig]
		void SetMaximumTextureMemory(ulong maximumInBytes);

		/// <summary>
		/// Sets the maximum amount of texture memory Direct2D accumulates before it purges the image caches and cached texture allocations.
		/// </summary>
		/// <returns>
		/// <para>Type: <c>UINT64</c></para>
		/// <para>The maximum amount of texture memory in bytes.</para>
		/// </returns>
		// https://docs.microsoft.com/en-us/windows/win32/api/d2d1_1/nf-d2d1_1-id2d1device-getmaximumtexturememory UINT64 GetMaximumTextureMemory();
		[PreserveSig]
		ulong GetMaximumTextureMemory();

		/// <summary>Clears all of the rendering resources used by Direct2D.</summary>
		/// <param name="millisecondsSinceUse">
		/// <para>Type: <c>UINT</c></para>
		/// <para>
		/// Discards only resources that haven't been used for greater than the specified time in milliseconds. The default is 0 milliseconds.
		/// </para>
		/// </param>
		/// <returns>
		/// <para>Type: <c>HRESULT</c></para>
		/// <para>If the function succeeds, it returns <c>S_OK</c>. Otherwise, it returns an <c>HRESULT</c> error code.</para>
		/// </returns>
		// https://docs.microsoft.com/en-us/windows/win32/api/d2d1_1/nf-d2d1_1-id2d1device-clearresources void ClearResources( UINT32
		// millisecondsSinceUse );
		[PreserveSig]
		void ClearResources(uint millisecondsSinceUse);
	}

	/// <summary>
	/// <para>Represents a set of state and command buffers that are used to render to a target.</para>
	/// <para>The device context can render to a target bitmap or a command list.</para>
	/// </summary>
	/// <remarks>
	/// Any resource created from a device context can be shared with any other resource created from a device context when both
	/// contexts are created on the same device.
	/// </remarks>
	// https://docs.microsoft.com/en-us/windows/win32/api/d2d1_1/nn-d2d1_1-id2d1devicecontext
	[PInvokeData("d2d1_1.h", MSDNShortId = "a54dd628-c2a2-4b04-9ced-7749a395f187")]
	[ComImport, Guid("e8f7fe7a-191c-466d-ad95-975678bda998"), InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
	public interface ID2D1DeviceContext : ID2D1RenderTarget
	{
		/// <summary>Retrieves the factory associated with this resource.</summary>
		/// <param name="factory">
		/// <para>Type: <c>ID2D1Factory**</c></para>
		/// <para>
		/// When this method returns, contains a pointer to a pointer to the factory that created this resource. This parameter is
		/// passed uninitialized.
		/// </para>
		/// </param>
		// https://docs.microsoft.com/en-us/windows/win32/api/d2d1/nf-d2d1-id2d1resource-getfactory void GetFactory( ID2D1Factory
		// **factory );
		[PreserveSig]
		new void GetFactory(out ID2D1Factory factory);

		/// <summary>Creates a Direct2D bitmap from a pointer to in-memory source data.</summary>
		/// <param name="size">
		/// <para>Type: [in] <c>D2D1_SIZE_U</c></para>
		/// <para>The dimensions of the bitmap to create in pixels.</para>
		/// </param>
		/// <param name="srcData">
		/// <para>Type: [in, optional] <c>const void*</c></para>
		/// <para>A pointer to the memory location of the image data, or <c>NULL</c> to create an uninitialized bitmap.</para>
		/// </param>
		/// <param name="pitch">
		/// <para>Type: [in] <c>UINT32</c></para>
		/// <para>
		/// The byte count of each scanline, which is equal to (the image width in pixels × the number of bytes per pixel) + memory
		/// padding. If srcData is <c>NULL</c>, this value is ignored. (Note that pitch is also sometimes called stride.)
		/// </para>
		/// </param>
		/// <param name="bitmapProperties">
		/// <para>Type: [in] <c>const D2D1_BITMAP_PROPERTIES &amp;</c></para>
		/// <para>The pixel format and dots per inch (DPI) of the bitmap to create.</para>
		/// </param>
		/// <returns>
		/// <para>Type: [out] <c>ID2D1Bitmap**</c></para>
		/// <para>When this method returns, contains a pointer to a pointer to the new bitmap. This parameter is passed uninitialized.</para>
		/// </returns>
		// https://docs.microsoft.com/en-us/windows/win32/api/d2d1/nf-d2d1-id2d1rendertarget-createbitmap(d2d1_size_u_constvoid_uint32_constd2d1_bitmap_properties__id2d1bitmap)
		// HRESULT CreateBitmap( D2D1_SIZE_U size, const void *srcData, UINT32 pitch, const D2D1_BITMAP_PROPERTIES &amp;
		// bitmapProperties, ID2D1Bitmap **bitmap );
		new ID2D1Bitmap CreateBitmap(D2D_SIZE_U size, [In, Optional] IntPtr srcData, uint pitch, in D2D1_BITMAP_PROPERTIES bitmapProperties);

		/// <summary>Creates an ID2D1Bitmap by copying the specified Microsoft Windows Imaging Component (WIC) bitmap.</summary>
		/// <param name="wicBitmapSource">
		/// <para>Type: [in] <c>IWICBitmapSource*</c></para>
		/// <para>The WIC bitmap to copy.</para>
		/// </param>
		/// <param name="bitmapProperties">
		/// <para>Type: [in, optional] <c>const D2D1_BITMAP_PROPERTIES*</c></para>
		/// <para>
		/// The pixel format and DPI of the bitmap to create. The pixel format must match the pixel format of wicBitmapSource, or the
		/// method will fail. To prevent a mismatch, you can pass <c>NULL</c> or pass the value obtained from calling the
		/// D2D1::PixelFormat helper function without specifying any parameter values. If both dpiX and dpiY are 0.0f, the default DPI,
		/// 96, is used. DPI information embedded in wicBitmapSource is ignored.
		/// </para>
		/// </param>
		/// <returns>
		/// <para>Type: <c>ID2D1Bitmap**</c></para>
		/// <para>When this method returns, contains the address of a pointer to the new bitmap. This parameter is passed uninitialized.</para>
		/// </returns>
		/// <remarks>
		/// Before Direct2D can load a WIC bitmap, that bitmap must be converted to a supported pixel format and alpha mode. For a list
		/// of supported pixel formats and alpha modes, see Supported Pixel Formats and Alpha Modes.
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows/win32/api/d2d1/nf-d2d1-id2d1rendertarget-createbitmapfromwicbitmap(iwicbitmapsource_constd2d1_bitmap_properties_id2d1bitmap)
		// HRESULT CreateBitmapFromWicBitmap( IWICBitmapSource *wicBitmapSource, const D2D1_BITMAP_PROPERTIES *bitmapProperties,
		// ID2D1Bitmap **bitmap );
		new ID2D1Bitmap CreateBitmapFromWicBitmap(IWICBitmapSource wicBitmapSource, [In, Optional] IntPtr bitmapProperties);

		/// <summary>Creates an ID2D1Bitmap whose data is shared with another resource.</summary>
		/// <param name="riid">
		/// <para>Type: <c>REFIID</c></para>
		/// <para>The interface ID of the object supplying the source data.</para>
		/// </param>
		/// <param name="data">
		/// <para>Type: <c>void*</c></para>
		/// <para>
		/// An ID2D1Bitmap, IDXGISurface, or an IWICBitmapLock that contains the data to share with the new <c>ID2D1Bitmap</c>. For more
		/// information, see the Remarks section.
		/// </para>
		/// </param>
		/// <param name="bitmapProperties">
		/// <para>Type: <c>D2D1_BITMAP_PROPERTIES*</c></para>
		/// <para>
		/// The pixel format and DPI of the bitmap to create . The DXGI_FORMAT portion of the pixel format must match the DXGI_FORMAT of
		/// data or the method will fail, but the alpha modes don't have to match. To prevent a mismatch, you can pass <c>NULL</c> or
		/// the value obtained from the D2D1::PixelFormat helper function. The DPI settings do not have to match those of data. If both
		/// dpiX and dpiY are 0.0f, the DPI of the render target is used.
		/// </para>
		/// </param>
		/// <returns>
		/// <para>Type: <c>ID2D1Bitmap**</c></para>
		/// <para>When this method returns, contains the address of a pointer to the new bitmap. This parameter is passed uninitialized.</para>
		/// </returns>
		/// <remarks>
		/// <para>
		/// The <c>CreateSharedBitmap</c> method is useful for efficiently reusing bitmap data and can also be used to provide
		/// interoperability with Direct3D.
		/// </para>
		/// <para>Sharing an ID2D1Bitmap</para>
		/// <para>
		/// By passing an ID2D1Bitmap created by a render target that is resource-compatible, you can share a bitmap with that render
		/// target; both the original <c>ID2D1Bitmap</c> and the new <c>ID2D1Bitmap</c> created by this method will point to the same
		/// bitmap data. For more information about when render target resources can be shared, see the Sharing Render Target Resources
		/// section of the Resources Overview.
		/// </para>
		/// <para>
		/// You may also use this method to reinterpret the data of an existing bitmap and specify a new DPI or alpha mode. For example,
		/// in the case of a bitmap atlas, an ID2D1Bitmap may contain multiple sub-images, each of which should be rendered with a
		/// different D2D1_ALPHA_MODE ( <c>D2D1_ALPHA_MODE_PREMULTIPLIED</c> or <c>D2D1_ALPHA_MODE_IGNORE</c>). You could use the
		/// <c>CreateSharedBitmap</c> method to reinterpret the bitmap using the desired alpha mode without having to load a separate
		/// copy of the bitmap into memory.
		/// </para>
		/// <para>Sharing an IDXGISurface</para>
		/// <para>
		/// When using a DXGI surface render target (an ID2D1RenderTarget object created by the CreateDxgiSurfaceRenderTarget method),
		/// you can pass an IDXGISurface surface to the <c>CreateSharedBitmap</c> method to share video memory with Direct3D and
		/// manipulate Direct3D content as an ID2D1Bitmap. As described in the Resources Overview, the render target and the
		/// IDXGISurface must be using the same Direct3D device.
		/// </para>
		/// <para>
		/// Note also that the IDXGISurface must use one of the supported pixel formats and alpha modes described in Supported Pixel
		/// Formats and Alpha Modes.
		/// </para>
		/// <para>For more information about interoperability with Direct3D, see the Direct2D and Direct3D Interoperability Overview.</para>
		/// <para>Sharing an IWICBitmapLock</para>
		/// <para>
		/// An IWICBitmapLock stores the content of a WIC bitmap and shields it from simultaneous accesses. By passing an
		/// <c>IWICBitmapLock</c> to the <c>CreateSharedBitmap</c> method, you can create an ID2D1Bitmap that points to the bitmap data
		/// already stored in the <c>IWICBitmapLock</c>.
		/// </para>
		/// <para>
		/// To use an IWICBitmapLock with the <c>CreateSharedBitmap</c> method, the render target must use software rendering. To force
		/// a render target to use software rendering, set to D2D1_RENDER_TARGET_TYPE_SOFTWARE the <c>type</c> field of the
		/// D2D1_RENDER_TARGET_PROPERTIES structure that you use to create the render target. To check whether an existing render target
		/// uses software rendering, use the IsSupported method.
		/// </para>
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows/win32/api/d2d1/nf-d2d1-id2d1rendertarget-createsharedbitmap HRESULT
		// CreateSharedBitmap( REFIID riid, void *data, const D2D1_BITMAP_PROPERTIES *bitmapProperties, ID2D1Bitmap **bitmap );
		new ID2D1Bitmap CreateSharedBitmap(in Guid riid, [In, Out] IntPtr data, [In, Optional] IntPtr bitmapProperties);

		/// <summary>Creates an ID2D1BitmapBrush from the specified bitmap.</summary>
		/// <param name="bitmap">
		/// <para>Type: <c>ID2D1Bitmap*</c></para>
		/// <para>The bitmap contents of the new brush.</para>
		/// </param>
		/// <param name="bitmapBrushProperties">
		/// <para>Type: <c>D2D1_BITMAP_BRUSH_PROPERTIES*</c></para>
		/// <para>
		/// The extend modes and interpolation mode of the new brush, or <c>NULL</c>. If you set this parameter to <c>NULL</c>, the
		/// brush defaults to the D2D1_EXTEND_MODE_CLAMP horizontal and vertical extend modes and the
		/// D2D1_BITMAP_INTERPOLATION_MODE_LINEAR interpolation mode.
		/// </para>
		/// </param>
		/// <param name="brushProperties">
		/// <para>Type: <c>D2D1_BRUSH_PROPERTIES*</c></para>
		/// <para>
		/// A structure that contains the opacity and transform of the new brush, or <c>NULL</c>. If you set this parameter to
		/// <c>NULL</c>, the brush sets the opacity member to 1.0F and the transform member to the identity matrix.
		/// </para>
		/// </param>
		/// <returns>
		/// <para>Type: <c>ID2D1BitmapBrush**</c></para>
		/// <para>
		/// When this method returns, this output parameter contains a pointer to a pointer to the new brush. Pass this parameter uninitialized.
		/// </para>
		/// </returns>
		// https://docs.microsoft.com/en-us/windows/win32/api/d2d1/nf-d2d1-id2d1rendertarget-createbitmapbrush(id2d1bitmap_constd2d1_bitmap_brush_properties_constd2d1_brush_properties_id2d1bitmapbrush)
		// HRESULT CreateBitmapBrush( ID2D1Bitmap *bitmap, const D2D1_BITMAP_BRUSH_PROPERTIES *bitmapBrushProperties, const
		// D2D1_BRUSH_PROPERTIES *brushProperties, ID2D1BitmapBrush **bitmapBrush );
		new ID2D1BitmapBrush CreateBitmapBrush([In, Optional] ID2D1Bitmap? bitmap, [In, Optional] IntPtr bitmapBrushProperties, [In, Optional] IntPtr brushProperties);

		/// <summary>Creates a new ID2D1SolidColorBrush that has the specified color and opacity.</summary>
		/// <param name="color">
		/// <para>Type: [in] <c>const D2D1_COLOR_F &amp;</c></para>
		/// <para>The red, green, blue, and alpha values of the brush's color.</para>
		/// </param>
		/// <param name="brushProperties">
		/// <para>Type: [in] <c>const D2D1_BRUSH_PROPERTIES &amp;</c></para>
		/// <para>The base opacity of the brush.</para>
		/// </param>
		/// <returns>
		/// <para>Type: [out] <c>ID2D1SolidColorBrush**</c></para>
		/// <para>When this method returns, contains the address of a pointer to the new brush. This parameter is passed uninitialized.</para>
		/// </returns>
		// https://docs.microsoft.com/en-us/windows/win32/api/d2d1/nf-d2d1-id2d1rendertarget-createsolidcolorbrush(constd2d1_color_f__constd2d1_brush_properties__id2d1solidcolorbrush)
		// HRESULT CreateSolidColorBrush( const D2D1_COLOR_F &amp; color, const D2D1_BRUSH_PROPERTIES &amp; brushProperties,
		// ID2D1SolidColorBrush **solidColorBrush );
		new ID2D1SolidColorBrush CreateSolidColorBrush(in D3DCOLORVALUE color, [In, Optional] IntPtr brushProperties);

		/// <summary>Creates an ID2D1GradientStopCollection from the specified array of D2D1_GRADIENT_STOP structures.</summary>
		/// <param name="gradientStops">
		/// <para>Type: [in] <c>D2D1_GRADIENT_STOP*</c></para>
		/// <para>A pointer to an array of D2D1_GRADIENT_STOP structures.</para>
		/// </param>
		/// <param name="gradientStopsCount">
		/// <para>Type: [in] <c>UINT</c></para>
		/// <para>A value greater than or equal to 1 that specifies the number of gradient stops in the gradientStops array.</para>
		/// </param>
		/// <param name="colorInterpolationGamma">
		/// <para>Type: [in] <c>D2D1_GAMMA</c></para>
		/// <para>The space in which color interpolation between the gradient stops is performed.</para>
		/// </param>
		/// <param name="extendMode">
		/// <para>Type: [in] <c>D2D1_EXTEND_MODE</c></para>
		/// <para>The behavior of the gradient outside the [0,1] normalized range.</para>
		/// </param>
		/// <returns>
		/// <para>Type: [out] <c>ID2D1GradientStopCollection**</c></para>
		/// <para>When this method returns, contains a pointer to a pointer to the new gradient stop collection.</para>
		/// </returns>
		// https://docs.microsoft.com/en-us/windows/win32/api/d2d1/nf-d2d1-id2d1rendertarget-creategradientstopcollection%28constd2d1_gradient_stop_uint32_d2d1_gamma_d2d1_extend_mode_id2d1gradientstopcollection%29
		// HRESULT CreateGradientStopCollection( const D2D1_GRADIENT_STOP *gradientStops, UINT32 gradientStopsCount, D2D1_GAMMA
		// colorInterpolationGamma, D2D1_EXTEND_MODE extendMode, ID2D1GradientStopCollection **gradientStopCollection );
		new ID2D1GradientStopCollection CreateGradientStopCollection([In] D2D1_GRADIENT_STOP[] gradientStops, uint gradientStopsCount, D2D1_GAMMA colorInterpolationGamma, D2D1_EXTEND_MODE extendMode);

		/// <summary>Creates an ID2D1LinearGradientBrush object for painting areas with a linear gradient.</summary>
		/// <param name="linearGradientBrushProperties">
		/// <para>Type: [in] <c>const D2D1_LINEAR_GRADIENT_BRUSH_PROPERTIES*</c></para>
		/// <para>The start and end points of the gradient.</para>
		/// </param>
		/// <param name="brushProperties">
		/// <para>Type: [in] <c>const D2D1_BRUSH_PROPERTIES*</c></para>
		/// <para>The transform and base opacity of the new brush.</para>
		/// </param>
		/// <param name="gradientStopCollection">
		/// <para>Type: [in] <c>ID2D1GradientStopCollection*</c></para>
		/// <para>
		/// A collection of D2D1_GRADIENT_STOP structures that describe the colors in the brush's gradient and their locations along the
		/// gradient line.
		/// </para>
		/// </param>
		/// <returns>
		/// <para>Type: [out] <c>ID2D1LinearGradientBrush**</c></para>
		/// <para>When this method returns, contains the address of a pointer to the new brush. This parameter is passed uninitialized.</para>
		/// </returns>
		// https://docs.microsoft.com/en-us/windows/win32/api/d2d1/nf-d2d1-id2d1rendertarget-createlineargradientbrush%28constd2d1_linear_gradient_brush_properties_constd2d1_brush_properties_id2d1gradientstopcollection_id2d1lineargradientbrush%29
		// HRESULT CreateLinearGradientBrush( const D2D1_LINEAR_GRADIENT_BRUSH_PROPERTIES *linearGradientBrushProperties, const
		// D2D1_BRUSH_PROPERTIES *brushProperties, ID2D1GradientStopCollection *gradientStopCollection, ID2D1LinearGradientBrush
		// **linearGradientBrush );
		new ID2D1LinearGradientBrush CreateLinearGradientBrush(in D2D1_LINEAR_GRADIENT_BRUSH_PROPERTIES linearGradientBrushProperties, [In, Optional] IntPtr brushProperties, [In] ID2D1GradientStopCollection gradientStopCollection);

		/// <summary>Creates an ID2D1RadialGradientBrush object that can be used to paint areas with a radial gradient.</summary>
		/// <param name="radialGradientBrushProperties">
		/// <para>Type: <c>const D2D1_RADIAL_GRADIENT_BRUSH_PROPERTIES*</c></para>
		/// <para>The center, gradient origin offset, and x-radius and y-radius of the brush's gradient.</para>
		/// </param>
		/// <param name="brushProperties">
		/// <para>Type: [in] <c>const D2D1_BRUSH_PROPERTIES*</c></para>
		/// <para>The transform and base opacity of the new brush.</para>
		/// </param>
		/// <param name="gradientStopCollection">
		/// <para>Type: [in] <c>ID2D1GradientStopCollection*</c></para>
		/// <para>
		/// A collection of D2D1_GRADIENT_STOP structures that describe the colors in the brush's gradient and their locations along the gradient.
		/// </para>
		/// </param>
		/// <returns>
		/// <para>Type: [out] <c>ID2D1RadialGradientBrush**</c></para>
		/// <para>When this method returns, contains a pointer to a pointer to the new brush. This parameter is passed uninitialized.</para>
		/// </returns>
		// https://docs.microsoft.com/en-us/windows/win32/api/d2d1/nf-d2d1-id2d1rendertarget-createradialgradientbrush%28constd2d1_radial_gradient_brush_properties_constd2d1_brush_properties_id2d1gradientstopcollection_id2d1radialgradientbrush%29
		// HRESULT CreateRadialGradientBrush( const D2D1_RADIAL_GRADIENT_BRUSH_PROPERTIES *radialGradientBrushProperties, const
		// D2D1_BRUSH_PROPERTIES *brushProperties, ID2D1GradientStopCollection *gradientStopCollection, ID2D1RadialGradientBrush
		// **radialGradientBrush );
		new ID2D1RadialGradientBrush CreateRadialGradientBrush(in D2D1_RADIAL_GRADIENT_BRUSH_PROPERTIES radialGradientBrushProperties, [In, Optional] IntPtr brushProperties, [In] ID2D1GradientStopCollection gradientStopCollection);

		/// <summary>
		/// Creates a bitmap render target for use during intermediate offscreen drawing that is compatible with the current render target.
		/// </summary>
		/// <param name="desiredSize">
		/// <para>Type: [in] <c>const D2D1_SIZE_F*</c></para>
		/// <para>
		/// The desired size of the new render target (in device-independent pixels), if it should be different from the original render
		/// target. For more info, see the Remarks section.
		/// </para>
		/// </param>
		/// <param name="desiredPixelSize">
		/// <para>Type: [in] <c>const D2D1_SIZE_U*</c></para>
		/// <para>
		/// The desired size of the new render target in pixels if it should be different from the original render target. For more
		/// information, see the Remarks section.
		/// </para>
		/// </param>
		/// <param name="desiredFormat">
		/// <para>Type: [in] <c>const D2D1_PIXEL_FORMAT*</c></para>
		/// <para>
		/// The desired pixel format and alpha mode of the new render target. If the pixel format is set to DXGI_FORMAT_UNKNOWN, the new
		/// render target uses the same pixel format as the original render target. If the alpha mode is D2D1_ALPHA_MODE_UNKNOWN, the
		/// alpha mode of the new render target defaults to <c>D2D1_ALPHA_MODE_PREMULTIPLIED</c>. For information about supported pixel
		/// formats, see Supported Pixel Formats and Alpha Modes.
		/// </para>
		/// </param>
		/// <param name="options">
		/// <para>Type: [in] <c>D2D1_COMPATIBLE_RENDER_TARGET_OPTIONS</c></para>
		/// <para>A value that specifies whether the new render target must be compatible with GDI.</para>
		/// </param>
		/// <returns>
		/// <para>Type: [out] <c>ID2D1BitmapRenderTarget**</c></para>
		/// <para>
		/// When this method returns, contains a pointer to a pointer to a new bitmap render target. This parameter is passed uninitialized.
		/// </para>
		/// </returns>
		/// <remarks>
		/// <para>The pixel size and DPI of the new render target can be altered by specifying values for desiredSize or desiredPixelSize:</para>
		/// <list type="bullet">
		/// <item>
		/// <term>
		/// If desiredSize is specified but desiredPixelSize is not, the pixel size is computed from the desired size using the parent
		/// target DPI. If the desiredSize maps to a integer-pixel size, the DPI of the compatible render target is the same as the DPI
		/// of the parent target. If desiredSize maps to a fractional-pixel size, the pixel size is rounded up to the nearest integer
		/// and the DPI for the compatible render target is slightly higher than the DPI of the parent render target. In all cases, the
		/// coordinate (desiredSize.width, desiredSize.height) maps to the lower-right corner of the compatible render target.
		/// </term>
		/// </item>
		/// <item>
		/// <term>
		/// If the desiredPixelSize is specified and desiredSize is not, the DPI of the new render target is the same as the original
		/// render target.
		/// </term>
		/// </item>
		/// <item>
		/// <term>
		/// If both desiredSize and desiredPixelSize are specified, the DPI of the new render target is computed to account for the
		/// difference in scale.
		/// </term>
		/// </item>
		/// <item>
		/// <term>
		/// If neither desiredSize nor desiredPixelSize is specified, the new render target size and DPI match the original render target.
		/// </term>
		/// </item>
		/// </list>
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows/win32/api/d2d1/nf-d2d1-id2d1rendertarget-createcompatiblerendertarget(constd2d1_size_f_constd2d1_size_u_constd2d1_pixel_format_d2d1_compatible_render_target_options_id2d1bitmaprendertarget)
		// HRESULT CreateCompatibleRenderTarget( const D2D1_SIZE_F *desiredSize, const D2D1_SIZE_U *desiredPixelSize, const
		// D2D1_PIXEL_FORMAT *desiredFormat, D2D1_COMPATIBLE_RENDER_TARGET_OPTIONS options, ID2D1BitmapRenderTarget **bitmapRenderTarget );
		new ID2D1BitmapRenderTarget CreateCompatibleRenderTarget([In, Optional] IntPtr desiredSize, [In, Optional] IntPtr desiredPixelSize, [In, Optional] IntPtr desiredFormat, [In, Optional] D2D1_COMPATIBLE_RENDER_TARGET_OPTIONS options);

		/// <summary>Creates a layer resource that can be used with this render target and its compatible render targets.</summary>
		/// <param name="size">
		/// <para>Type: [in] <c>const D2D1_SIZE_F*</c></para>
		/// <para>
		/// If (0, 0) is specified, no backing store is created behind the layer resource. The layer resource is allocated to the
		/// minimum size when PushLayer is called.
		/// </para>
		/// </param>
		/// <returns>
		/// <para>Type: [out] <c>ID2D1Layer**</c></para>
		/// <para>When the method returns, contains a pointer to a pointer to the new layer. This parameter is passed uninitialized.</para>
		/// </returns>
		/// <remarks>The layer automatically resizes itself, as needed.</remarks>
		// https://docs.microsoft.com/en-us/windows/win32/api/d2d1/nf-d2d1-id2d1rendertarget-createlayer(constd2d1_size_f_id2d1layer)
		// HRESULT CreateLayer( const D2D1_SIZE_F *size, ID2D1Layer **layer );
		new ID2D1Layer CreateLayer([In, Optional] IntPtr size);

		/// <summary>Create a mesh that uses triangles to describe a shape.</summary>
		/// <returns>
		/// <para>Type: <c>ID2D1Mesh**</c></para>
		/// <para>When this method returns, contains a pointer to a pointer to the new mesh.</para>
		/// </returns>
		/// <remarks>
		/// To populate a mesh, use its Open method to obtain an ID2D1TessellationSink. To draw the mesh, use the render target's
		/// FillMesh method.
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows/win32/api/d2d1/nf-d2d1-id2d1rendertarget-createmesh HRESULT CreateMesh( ID2D1Mesh
		// **mesh );
		new ID2D1Mesh CreateMesh();

		/// <summary>Draws a line between the specified points using the specified stroke style.</summary>
		/// <param name="point0">
		/// <para>Type: <c>D2D1_POINT_2F</c></para>
		/// <para>The start point of the line, in device-independent pixels.</para>
		/// </param>
		/// <param name="point1">
		/// <para>Type: <c>D2D1_POINT_2F</c></para>
		/// <para>The end point of the line, in device-independent pixels.</para>
		/// </param>
		/// <param name="brush">
		/// <para>Type: <c>ID2D1Brush*</c></para>
		/// <para>The brush used to paint the line's stroke.</para>
		/// </param>
		/// <param name="strokeWidth">
		/// <para>Type: <c>FLOAT</c></para>
		/// <para>
		/// The width of the stroke, in device-independent pixels. The value must be greater than or equal to 0.0f. If this parameter
		/// isn't specified, it defaults to 1.0f. The stroke is centered on the line.
		/// </para>
		/// </param>
		/// <param name="strokeStyle">
		/// <para>Type: <c>ID2D1StrokeStyle*</c></para>
		/// <para>The style of stroke to paint, or <c>NULL</c> to paint a solid line.</para>
		/// </param>
		/// <returns>None</returns>
		/// <remarks>
		/// This method doesn't return an error code if it fails. To determine whether a drawing operation (such as <c>DrawLine</c>)
		/// failed, check the result returned by the ID2D1RenderTarget::EndDraw or ID2D1RenderTarget::Flush methods.
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows/win32/api/d2d1/nf-d2d1-id2d1rendertarget-drawline void DrawLine( D2D1_POINT_2F
		// point0, D2D1_POINT_2F point1, ID2D1Brush *brush, FLOAT strokeWidth, ID2D1StrokeStyle *strokeStyle );
		[PreserveSig]
		new void DrawLine(D2D_POINT_2F point0, D2D_POINT_2F point1, [In] ID2D1Brush brush, float strokeWidth = 1.0f, [In] ID2D1StrokeStyle? strokeStyle = null);

		/// <summary>Draws the outline of a rectangle that has the specified dimensions and stroke style.</summary>
		/// <param name="rect">
		/// <para>Type: [in] <c>const D2D1_RECT_F &amp;</c></para>
		/// <para>The dimensions of the rectangle to draw, in device-independent pixels.</para>
		/// </param>
		/// <param name="brush">
		/// <para>Type: [in] <c>ID2D1Brush*</c></para>
		/// <para>The brush used to paint the rectangle's stroke.</para>
		/// </param>
		/// <param name="strokeWidth">
		/// <para>Type: [in] <c>FLOAT</c></para>
		/// <para>
		/// The width of the stroke, in device-independent pixels. The value must be greater than or equal to 0.0f. If this parameter
		/// isn't specified, it defaults to 1.0f. The stroke is centered on the line.
		/// </para>
		/// </param>
		/// <param name="strokeStyle">
		/// <para>Type: [in, optional] <c>ID2D1StrokeStyle*</c></para>
		/// <para>The style of stroke to paint, or <c>NULL</c> to paint a solid stroke.</para>
		/// </param>
		/// <returns>None</returns>
		/// <remarks>
		/// When this method fails, it does not return an error code. To determine whether a drawing method (such as DrawRectangle)
		/// failed, check the result returned by the ID2D1RenderTarget::EndDraw or ID2D1RenderTarget::Flush method.
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows/win32/api/d2d1/nf-d2d1-id2d1rendertarget-drawrectangle(constd2d1_rect_f__id2d1brush_float_id2d1strokestyle)
		// void DrawRectangle( const D2D1_RECT_F &amp; rect, ID2D1Brush *brush, FLOAT strokeWidth, ID2D1StrokeStyle *strokeStyle );
		[PreserveSig]
		new void DrawRectangle(in D2D_RECT_F rect, [In] ID2D1Brush brush, float strokeWidth = 1.0f, [In] ID2D1StrokeStyle? strokeStyle = null);

		/// <summary>Paints the interior of the specified rectangle.</summary>
		/// <param name="rect">
		/// <para>Type: [in] <c>const D2D1_RECT_F &amp;</c></para>
		/// <para>The dimension of the rectangle to paint, in device-independent pixels.</para>
		/// </param>
		/// <param name="brush">
		/// <para>Type: [in] <c>ID2D1Brush*</c></para>
		/// <para>The brush used to paint the rectangle's interior.</para>
		/// </param>
		/// <returns>None</returns>
		/// <remarks>
		/// This method doesn't return an error code if it fails. To determine whether a drawing operation (such as FillRectangle)
		/// failed, check the result returned by the ID2D1RenderTarget::EndDraw or ID2D1RenderTarget::Flush methods.
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows/win32/api/d2d1/nf-d2d1-id2d1rendertarget-fillrectangle(constd2d1_rect_f__id2d1brush)
		// void FillRectangle( const D2D1_RECT_F &amp; rect, ID2D1Brush *brush );
		[PreserveSig]
		new void FillRectangle(in D2D_RECT_F rect, [In] ID2D1Brush brush);

		/// <summary>Draws the outline of the specified rounded rectangle using the specified stroke style.</summary>
		/// <param name="roundedRect">
		/// <para>Type: [in] <c>const D2D1_ROUNDED_RECT &amp;</c></para>
		/// <para>The dimensions of the rounded rectangle to draw, in device-independent pixels.</para>
		/// </param>
		/// <param name="brush">
		/// <para>Type: [in] <c>ID2D1Brush*</c></para>
		/// <para>The brush used to paint the rounded rectangle's outline.</para>
		/// </param>
		/// <param name="strokeWidth">
		/// <para>Type: [in] <c>FLOAT</c></para>
		/// <para>
		/// The width of the stroke, in device-independent pixels. The value must be greater than or equal to 0.0f. If this parameter
		/// isn't specified, it defaults to 1.0f. The stroke is centered on the line.
		/// </para>
		/// </param>
		/// <param name="strokeStyle">
		/// <para>Type: [in, optional] <c>ID2D1StrokeStyle*</c></para>
		/// <para>The style of the rounded rectangle's stroke, or <c>NULL</c> to paint a solid stroke. The default value is <c>NULL</c>.</para>
		/// </param>
		/// <returns>None</returns>
		/// <remarks>
		/// This method doesn't return an error code if it fails. To determine whether a drawing operation (such as
		/// DrawRoundedRectangle) failed, check the result returned by the ID2D1RenderTarget::EndDraw or ID2D1RenderTarget::Flush methods.
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows/win32/api/d2d1/nf-d2d1-id2d1rendertarget-drawroundedrectangle(constd2d1_rounded_rect__id2d1brush_float_id2d1strokestyle)
		// void DrawRoundedRectangle( const D2D1_ROUNDED_RECT &amp; roundedRect, ID2D1Brush *brush, FLOAT strokeWidth, ID2D1StrokeStyle
		// *strokeStyle );
		[PreserveSig]
		new void DrawRoundedRectangle(in D2D1_ROUNDED_RECT roundedRect, [In] ID2D1Brush brush, float strokeWidth = 1.0f, [In] ID2D1StrokeStyle? strokeStyle = null);

		/// <summary>Paints the interior of the specified rounded rectangle.</summary>
		/// <param name="roundedRect">
		/// <para>Type: [in] <c>const D2D1_ROUNDED_RECT &amp;</c></para>
		/// <para>The dimensions of the rounded rectangle to paint, in device independent pixels.</para>
		/// </param>
		/// <param name="brush">
		/// <para>Type: [in] <c>ID2D1Brush*</c></para>
		/// <para>The brush used to paint the interior of the rounded rectangle.</para>
		/// </param>
		/// <returns>None</returns>
		/// <remarks>
		/// This method doesn't return an error code if it fails. To determine whether a drawing operation (such as
		/// FillRoundedRectangle) failed, check the result returned by the ID2D1RenderTarget::EndDraw or ID2D1RenderTarget::Flush methods.
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows/win32/api/d2d1/nf-d2d1-id2d1rendertarget-fillroundedrectangle(constd2d1_rounded_rect__id2d1brush)
		// void FillRoundedRectangle( const D2D1_ROUNDED_RECT &amp; roundedRect, ID2D1Brush *brush );
		[PreserveSig]
		new void FillRoundedRectangle(in D2D1_ROUNDED_RECT roundedRect, [In] ID2D1Brush brush);

		/// <summary>Draws the outline of the specified ellipse using the specified stroke style.</summary>
		/// <param name="ellipse">
		/// <para>Type: [in] <c>const D2D1_ELLIPSE &amp;</c></para>
		/// <para>The position and radius of the ellipse to draw, in device-independent pixels.</para>
		/// </param>
		/// <param name="brush">
		/// <para>Type: [in] <c>ID2D1Brush*</c></para>
		/// <para>The brush used to paint the ellipse's outline.</para>
		/// </param>
		/// <param name="strokeWidth">
		/// <para>Type: [in] <c>FLOAT</c></para>
		/// <para>
		/// The width of the stroke, in device-independent pixels. The value must be greater than or equal to 0.0f. If this parameter
		/// isn't specified, it defaults to 1.0f. The stroke is centered on the line.
		/// </para>
		/// </param>
		/// <param name="strokeStyle">
		/// <para>Type: [in, optional] <c>ID2D1StrokeStyle*</c></para>
		/// <para>The style of stroke to apply to the ellipse's outline, or <c>NULL</c> to paint a solid stroke.</para>
		/// </param>
		/// <returns>None</returns>
		/// <remarks>
		/// The DrawEllipse method doesn't return an error code if it fails. To determine whether a drawing operation (such as
		/// <c>DrawEllipse</c>) failed, check the result returned by the ID2D1RenderTarget::EndDraw or ID2D1RenderTarget::Flush methods.
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows/win32/api/d2d1/nf-d2d1-id2d1rendertarget-drawellipse(constd2d1_ellipse__id2d1brush_float_id2d1strokestyle)
		// void DrawEllipse( const D2D1_ELLIPSE &amp; ellipse, ID2D1Brush *brush, FLOAT strokeWidth, ID2D1StrokeStyle *strokeStyle );
		[PreserveSig]
		new void DrawEllipse(in D2D1_ELLIPSE ellipse, [In] ID2D1Brush brush, float strokeWidth = 1.0f, [In] ID2D1StrokeStyle? strokeStyle = null);

		/// <summary>Paints the interior of the specified ellipse.</summary>
		/// <param name="ellipse">
		/// <para>Type: [in] <c>const D2D1_ELLIPSE &amp;</c></para>
		/// <para>The position and radius, in device-independent pixels, of the ellipse to paint.</para>
		/// </param>
		/// <param name="brush">
		/// <para>Type: [in] <c>ID2D1Brush*</c></para>
		/// <para>The brush used to paint the interior of the ellipse.</para>
		/// </param>
		/// <returns>None</returns>
		/// <remarks>
		/// This method doesn't return an error code if it fails. To determine whether a drawing operation (such as FillEllipse) failed,
		/// check the result returned by the ID2D1RenderTarget::EndDraw or ID2D1RenderTarget::Flush methods.
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows/win32/api/d2d1/nf-d2d1-id2d1rendertarget-fillellipse(constd2d1_ellipse__id2d1brush)
		// void FillEllipse( const D2D1_ELLIPSE &amp; ellipse, ID2D1Brush *brush );
		[PreserveSig]
		new void FillEllipse(in D2D1_ELLIPSE ellipse, [In] ID2D1Brush brush);

		/// <summary>Draws the outline of the specified geometry using the specified stroke style.</summary>
		/// <param name="geometry">
		/// <para>Type: <c>ID2D1Geometry*</c></para>
		/// <para>The geometry to draw.</para>
		/// </param>
		/// <param name="brush">
		/// <para>Type: <c>ID2D1Brush*</c></para>
		/// <para>The brush used to paint the geometry's stroke.</para>
		/// </param>
		/// <param name="strokeWidth">
		/// <para>Type: <c>FLOAT</c></para>
		/// <para>
		/// The width of the stroke, in device-independent pixels. The value must be greater than or equal to 0.0f. If this parameter
		/// isn't specified, it defaults to 1.0f. The stroke is centered on the line.
		/// </para>
		/// </param>
		/// <param name="strokeStyle">
		/// <para>Type: <c>ID2D1StrokeStyle*</c></para>
		/// <para>The style of stroke to apply to the geometry's outline, or <c>NULL</c> to paint a solid stroke.</para>
		/// </param>
		/// <returns>None</returns>
		/// <remarks>
		/// This method doesn't return an error code if it fails. To determine whether a drawing operation (such as <c>DrawGeometry</c>)
		/// failed, check the result returned by the ID2D1RenderTarget::EndDraw or ID2D1RenderTarget::Flush methods.
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows/win32/api/d2d1/nf-d2d1-id2d1rendertarget-drawgeometry void DrawGeometry(
		// ID2D1Geometry *geometry, ID2D1Brush *brush, FLOAT strokeWidth, ID2D1StrokeStyle *strokeStyle );
		[PreserveSig]
		new void DrawGeometry([In] ID2D1Geometry geometry, [In] ID2D1Brush brush, float strokeWidth = 1.0f, [In] ID2D1StrokeStyle? strokeStyle = null);

		/// <summary>Paints the interior of the specified geometry.</summary>
		/// <param name="geometry">
		/// <para>Type: <c>ID2D1Geometry*</c></para>
		/// <para>The geometry to paint.</para>
		/// </param>
		/// <param name="brush">
		/// <para>Type: <c>ID2D1Brush*</c></para>
		/// <para>The brush used to paint the geometry's interior.</para>
		/// </param>
		/// <param name="opacityBrush">
		/// <para>Type: <c>ID2D1Brush*</c></para>
		/// <para>
		/// The opacity mask to apply to the geometry, or <c>NULL</c> for no opacity mask. If an opacity mask (the opacityBrush
		/// parameter) is specified, brush must be an ID2D1BitmapBrush that has its x- and y-extend modes set to D2D1_EXTEND_MODE_CLAMP.
		/// For more information, see the Remarks section.
		/// </para>
		/// </param>
		/// <returns>None</returns>
		/// <remarks>
		/// <para>
		/// If the opacityBrush parameter is not <c>NULL</c>, the alpha value of each pixel of the mapped opacityBrush is used to
		/// determine the resulting opacity of each corresponding pixel of the geometry. Only the alpha value of each color in the brush
		/// is used for this processing; all other color information is ignored.
		/// </para>
		/// <para>
		/// The alpha value specified by the brush is multiplied by the alpha value of the geometry after the geometry has been painted
		/// by brush.
		/// </para>
		/// <para>
		/// When this method fails, it does not return an error code. To determine whether a drawing operation (such as
		/// <c>FillGeometry</c>) failed, check the result returned by the ID2D1RenderTarget::EndDraw or ID2D1RenderTarget::Flush method.
		/// </para>
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows/win32/api/d2d1/nf-d2d1-id2d1rendertarget-fillgeometry void FillGeometry(
		// ID2D1Geometry *geometry, ID2D1Brush *brush, ID2D1Brush *opacityBrush );
		[PreserveSig]
		new void FillGeometry([In] ID2D1Geometry geometry, [In] ID2D1Brush brush, [In] ID2D1Brush? opacityBrush = null);

		/// <summary>Paints the interior of the specified mesh.</summary>
		/// <param name="mesh">
		/// <para>Type: <c>ID2D1Mesh*</c></para>
		/// <para>The mesh to paint.</para>
		/// </param>
		/// <param name="brush">
		/// <para>Type: <c>ID2D1Brush*</c></para>
		/// <para>The brush used to paint the mesh.</para>
		/// </param>
		/// <returns>None</returns>
		/// <remarks>
		/// <para>
		/// The current antialias mode of the render target must be D2D1_ANTIALIAS_MODE_ALIASED when <c>FillMesh</c> is called. To
		/// change the render target's antialias mode, use the SetAntialiasMode method.
		/// </para>
		/// <para>
		/// <c>FillMesh</c> does not expect a particular winding order for the triangles in the ID2D1Mesh; both clockwise and
		/// counter-clockwise will work.
		/// </para>
		/// <para>
		/// This method doesn't return an error code if it fails. To determine whether a drawing operation (such as <c>FillMesh</c>)
		/// failed, check the result returned by the ID2D1RenderTarget::EndDraw or ID2D1RenderTarget::Flush methods.
		/// </para>
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows/win32/api/d2d1/nf-d2d1-id2d1rendertarget-fillmesh void FillMesh( ID2D1Mesh *mesh,
		// ID2D1Brush *brush );
		[PreserveSig]
		new void FillMesh([In] ID2D1Mesh mesh, [In] ID2D1Brush brush);

		/// <summary>
		/// Applies the opacity mask described by the specified bitmap to a brush and uses that brush to paint a region of the render target.
		/// </summary>
		/// <param name="opacityMask">
		/// <para>Type: <c>ID2D1Bitmap*</c></para>
		/// <para>
		/// The opacity mask to apply to the brush. The alpha value of each pixel in the region specified by sourceRectangle is
		/// multiplied with the alpha value of the brush after the brush has been mapped to the area defined by destinationRectangle.
		/// </para>
		/// </param>
		/// <param name="brush">
		/// <para>Type: <c>ID2D1Brush*</c></para>
		/// <para>The brush used to paint the region of the render target specified by destinationRectangle.</para>
		/// </param>
		/// <param name="content">
		/// <para>Type: <c>D2D1_OPACITY_MASK_CONTENT</c></para>
		/// <para>
		/// The type of content the opacity mask contains. The value is used to determine the color space in which the opacity mask is blended.
		/// </para>
		/// <para>
		/// <c>Note</c> Starting with Windows 8, the D2D1_OPACITY_MASK_CONTENT is not required. See the
		/// ID2D1DeviceContext::FillOpacityMask method, which has no <c>D2D1_OPACITY_MASK_CONTENT</c> parameter.
		/// </para>
		/// </param>
		/// <param name="destinationRectangle">
		/// <para>Type: <c>const D2D1_RECT_F</c></para>
		/// <para>The region of the render target to paint, in device-independent pixels.</para>
		/// </param>
		/// <param name="sourceRectangle">
		/// <para>Type: <c>const D2D1_RECT_F</c></para>
		/// <para>The region of the bitmap to use as the opacity mask, in device-independent pixels.</para>
		/// </param>
		/// <returns>None</returns>
		/// <remarks>
		/// <para>
		/// For this method to work properly, the render target must be using the D2D1_ANTIALIAS_MODE_ALIASED antialiasing mode. You can
		/// set the antialiasing mode by calling the ID2D1RenderTarget::SetAntialiasMode method.
		/// </para>
		/// <para>
		/// This method doesn't return an error code if it fails. To determine whether a drawing operation (such as FillOpacityMask)
		/// failed, check the result returned by the ID2D1RenderTarget::EndDraw or ID2D1RenderTarget::Flush methods.
		/// </para>
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows/win32/api/d2d1/nf-d2d1-id2d1rendertarget-fillopacitymask(id2d1bitmap_id2d1brush_d2d1_opacity_mask_content_constd2d1_rect_f__constd2d1_rect_f_)
		// void FillOpacityMask( ID2D1Bitmap *opacityMask, ID2D1Brush *brush, D2D1_OPACITY_MASK_CONTENT content, const D2D1_RECT_F &amp;
		// destinationRectangle, const D2D1_RECT_F &amp; sourceRectangle );
		[PreserveSig]
		new void FillOpacityMask([In] ID2D1Bitmap opacityMask, [In] ID2D1Brush brush, D2D1_OPACITY_MASK_CONTENT content, [In, Optional] IntPtr destinationRectangle, [In, Optional] IntPtr sourceRectangle);

		/// <summary>Draws the specified bitmap after scaling it to the size of the specified rectangle.</summary>
		/// <param name="bitmap">
		/// <para>Type: <c>ID2D1Bitmap*</c></para>
		/// <para>The bitmap to render.</para>
		/// </param>
		/// <param name="destinationRectangle">
		/// <para>Type: <c>const D2D1_RECT_F</c></para>
		/// <para>
		/// The size and position, in device-independent pixels in the render target's coordinate space, of the area to which the bitmap
		/// is drawn. If the rectangle is not well-ordered, nothing is drawn, but the render target does not enter an error state.
		/// </para>
		/// </param>
		/// <param name="opacity">
		/// <para>Type: <c>FLOAT</c></para>
		/// <para>
		/// A value between 0.0f and 1.0f, inclusive, that specifies an opacity value to apply to the bitmap; this value is multiplied
		/// against the alpha values of the bitmap's contents.
		/// </para>
		/// </param>
		/// <param name="interpolationMode">
		/// <para>Type: <c>D2D1_BITMAP_INTERPOLATION_MODE</c></para>
		/// <para>The interpolation mode to use if the bitmap is scaled or rotated by the drawing operation.</para>
		/// </param>
		/// <param name="sourceRectangle">
		/// <para>Type: <c>const D2D1_RECT_F</c></para>
		/// <para>
		/// The size and position, in device-independent pixels in the bitmap's coordinate space, of the area within the bitmap to draw.
		/// </para>
		/// </param>
		/// <returns>None</returns>
		/// <remarks>
		/// This method doesn't return an error code if it fails. To determine whether a drawing operation (such as DrawBitmap) failed,
		/// check the result returned by the ID2D1RenderTarget::EndDraw or ID2D1RenderTarget::Flush methods.
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows/win32/api/d2d1/nf-d2d1-id2d1rendertarget-drawbitmap(id2d1bitmap_constd2d1_rect_f__float_d2d1_bitmap_interpolation_mode_constd2d1_rect_f_)
		// void DrawBitmap( ID2D1Bitmap *bitmap, const D2D1_RECT_F &amp; destinationRectangle, FLOAT opacity,
		// D2D1_BITMAP_INTERPOLATION_MODE interpolationMode, const D2D1_RECT_F &amp; sourceRectangle );
		[PreserveSig]
		new void DrawBitmap([In] ID2D1Bitmap bitmap, [In, Optional] IntPtr destinationRectangle, float opacity = 1.0f,
			D2D1_BITMAP_INTERPOLATION_MODE interpolationMode = D2D1_BITMAP_INTERPOLATION_MODE.D2D1_BITMAP_INTERPOLATION_MODE_LINEAR, [In] IntPtr sourceRectangle = default);

		/// <summary>Draws the specified text using the format information provided by an IDWriteTextFormat object.</summary>
		/// <param name="string">
		/// <para>Type: <c>WCHAR*</c></para>
		/// <para>A pointer to an array of Unicode characters to draw.</para>
		/// </param>
		/// <param name="stringLength">
		/// <para>Type: <c>UINT</c></para>
		/// <para>The number of characters in string.</para>
		/// </param>
		/// <param name="textFormat">
		/// <para>Type: <c>IDWriteTextFormat*</c></para>
		/// <para>An object that describes formatting details of the text to draw, such as the font, the font size, and flow direction.</para>
		/// </param>
		/// <param name="layoutRect">
		/// <para>Type: <c>const D2D1_RECT_F</c></para>
		/// <para>The size and position of the area in which the text is drawn.</para>
		/// </param>
		/// <param name="defaultFillBrush">
		/// <para>Type: <c>ID2D1Brush*</c></para>
		/// <para>The brush used to paint the text.</para>
		/// </param>
		/// <param name="options">
		/// <para>Type: <c>D2D1_DRAW_TEXT_OPTIONS</c></para>
		/// <para>
		/// A value that indicates whether the text should be snapped to pixel boundaries and whether the text should be clipped to the
		/// layout rectangle. The default value is D2D1_DRAW_TEXT_OPTIONS_NONE, which indicates that text should be snapped to pixel
		/// boundaries and it should not be clipped to the layout rectangle.
		/// </para>
		/// </param>
		/// <param name="measuringMode">
		/// <para>Type: <c>DWRITE_MEASURING_MODE</c></para>
		/// <para>A value that indicates how glyph metrics are used to measure text when it is formatted. The default value is DWRITE_MEASURING_MODE_NATURAL.</para>
		/// </param>
		/// <returns>None</returns>
		/// <remarks>
		/// <para>To create an IDWriteTextFormat object, create an IDWriteFactory and call its CreateTextFormat method.</para>
		/// <para>
		/// This method doesn't return an error code if it fails. To determine whether a drawing operation (such as DrawText) failed,
		/// check the result returned by the ID2D1RenderTarget::EndDraw or ID2D1RenderTarget::Flush methods.
		/// </para>
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows/win32/api/d2d1/nf-d2d1-id2d1rendertarget-drawtext(constwchar_uint32_idwritetextformat_constd2d1_rect_f__id2d1brush_d2d1_draw_text_options_dwrite_measuring_mode)
		// void DrawText( const WCHAR *string, UINT32 stringLength, IDWriteTextFormat *textFormat, const D2D1_RECT_F &amp; layoutRect,
		// ID2D1Brush *defaultFillBrush, D2D1_DRAW_TEXT_OPTIONS options, DWRITE_MEASURING_MODE measuringMode );
		[PreserveSig]
		new void DrawText([MarshalAs(UnmanagedType.LPWStr)] string @string, uint stringLength, [In] IDWriteTextFormat textFormat, in D2D_RECT_F layoutRect,
			[In] ID2D1Brush defaultFillBrush, D2D1_DRAW_TEXT_OPTIONS options = D2D1_DRAW_TEXT_OPTIONS.D2D1_DRAW_TEXT_OPTIONS_NONE,
			DWRITE_MEASURING_MODE measuringMode = DWRITE_MEASURING_MODE.DWRITE_MEASURING_MODE_NATURAL);

		/// <summary>Draws the formatted text described by the specified IDWriteTextLayout object.</summary>
		/// <param name="origin">
		/// <para>Type: <c>D2D1_POINT_2F</c></para>
		/// <para>
		/// The point, described in device-independent pixels, at which the upper-left corner of the text described by textLayout is drawn.
		/// </para>
		/// </param>
		/// <param name="textLayout">
		/// <para>Type: <c>IDWriteTextLayout*</c></para>
		/// <para>
		/// The formatted text to draw. Any drawing effects that do not inherit from ID2D1Resource are ignored. If there are drawing
		/// effects that inherit from <c>ID2D1Resource</c> that are not brushes, this method fails and the render target is put in an
		/// error state.
		/// </para>
		/// </param>
		/// <param name="defaultFillBrush">
		/// <para>Type: <c>ID2D1Brush*</c></para>
		/// <para>
		/// The brush used to paint any text in textLayout that does not already have a brush associated with it as a drawing effect
		/// (specified by the IDWriteTextLayout::SetDrawingEffect method).
		/// </para>
		/// </param>
		/// <param name="options">
		/// <para>Type: <c>D2D1_DRAW_TEXT_OPTIONS</c></para>
		/// <para>
		/// A value that indicates whether the text should be snapped to pixel boundaries and whether the text should be clipped to the
		/// layout rectangle. The default value is D2D1_DRAW_TEXT_OPTIONS_NONE, which indicates that text should be snapped to pixel
		/// boundaries and it should not be clipped to the layout rectangle.
		/// </para>
		/// </param>
		/// <returns>None</returns>
		/// <remarks>
		/// <para>
		/// When drawing the same text repeatedly, using the <c>DrawTextLayout</c> method is more efficient than using the DrawText
		/// method because the text doesn't need to be formatted and the layout processed with each call.
		/// </para>
		/// <para>
		/// This method doesn't return an error code if it fails. To determine whether a drawing operation (such as
		/// <c>DrawTextLayout</c>) failed, check the result returned by the ID2D1RenderTarget::EndDraw or ID2D1RenderTarget::Flush methods.
		/// </para>
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows/win32/api/d2d1/nf-d2d1-id2d1rendertarget-drawtextlayout void DrawTextLayout(
		// D2D1_POINT_2F origin, IDWriteTextLayout *textLayout, ID2D1Brush *defaultFillBrush, D2D1_DRAW_TEXT_OPTIONS options );
		[PreserveSig]
		new void DrawTextLayout(D2D_POINT_2F origin, [In] IDWriteTextLayout textLayout, [In] ID2D1Brush defaultFillBrush,
			D2D1_DRAW_TEXT_OPTIONS options = D2D1_DRAW_TEXT_OPTIONS.D2D1_DRAW_TEXT_OPTIONS_NONE);

		/// <summary>Draws the specified glyphs.</summary>
		/// <param name="baselineOrigin">
		/// <para>Type: <c>D2D1_POINT_2F</c></para>
		/// <para>The origin, in device-independent pixels, of the glyphs' baseline.</para>
		/// </param>
		/// <param name="glyphRun">
		/// <para>Type: <c>const DWRITE_GLYPH_RUN*</c></para>
		/// <para>The glyphs to render.</para>
		/// </param>
		/// <param name="foregroundBrush">
		/// <para>Type: <c>ID2D1Brush*</c></para>
		/// <para>The brush used to paint the specified glyphs.</para>
		/// </param>
		/// <param name="measuringMode">
		/// <para>Type: <c>DWRITE_MEASURING_MODE</c></para>
		/// <para>A value that indicates how glyph metrics are used to measure text when it is formatted. The default value is DWRITE_MEASURING_MODE_NATURAL.</para>
		/// </param>
		/// <returns>None</returns>
		/// <remarks>
		/// This method doesn't return an error code if it fails. To determine whether a drawing operation (such as <c>DrawGlyphRun</c>)
		/// failed, check the result returned by the ID2D1RenderTarget::EndDraw or ID2D1RenderTarget::Flush methods.
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows/win32/api/d2d1/nf-d2d1-id2d1rendertarget-drawglyphrun void DrawGlyphRun(
		// D2D1_POINT_2F baselineOrigin, const DWRITE_GLYPH_RUN *glyphRun, ID2D1Brush *foregroundBrush, DWRITE_MEASURING_MODE
		// measuringMode );
		[PreserveSig]
		new void DrawGlyphRun(D2D_POINT_2F baselineOrigin, in DWRITE_GLYPH_RUN glyphRun, [In] ID2D1Brush foregroundBrush,
			DWRITE_MEASURING_MODE measuringMode = DWRITE_MEASURING_MODE.DWRITE_MEASURING_MODE_NATURAL);

		/// <summary>
		/// Applies the specified transform to the render target, replacing the existing transformation. All subsequent drawing
		/// operations occur in the transformed space.
		/// </summary>
		/// <param name="transform">
		/// <para>Type: <c>const D2D1_MATRIX_3X2_F</c></para>
		/// <para>The transform to apply to the render target.</para>
		/// </param>
		/// <returns>None</returns>
		// https://docs.microsoft.com/en-us/windows/win32/api/d2d1/nf-d2d1-id2d1rendertarget-settransform(constd2d1_matrix_3x2_f_) void
		// SetTransform( const D2D1_MATRIX_3X2_F &amp; transform );
		[PreserveSig]
		new void SetTransform(in D2D_MATRIX_3X2_F transform);

		/// <summary>Gets the current transform of the render target.</summary>
		/// <param name="transform">
		/// <para>Type: <c>D2D1_MATRIX_3X2_F*</c></para>
		/// <para>When this returns, contains the current transform of the render target. This parameter is passed uninitialized.</para>
		/// </param>
		/// <returns>None</returns>
		// https://docs.microsoft.com/en-us/windows/win32/api/d2d1/nf-d2d1-id2d1rendertarget-gettransform void GetTransform(
		// D2D1_MATRIX_3X2_F *transform );
		[PreserveSig]
		new void GetTransform(out D2D_MATRIX_3X2_F transform);

		/// <summary>
		/// Sets the antialiasing mode of the render target. The antialiasing mode applies to all subsequent drawing operations,
		/// excluding text and glyph drawing operations.
		/// </summary>
		/// <param name="antialiasMode">
		/// <para>Type: <c>D2D1_ANTIALIAS_MODE</c></para>
		/// <para>The antialiasing mode for future drawing operations.</para>
		/// </param>
		/// <returns>None</returns>
		/// <remarks>To specify the antialiasing mode for text and glyph operations, use the SetTextAntialiasMode method.</remarks>
		// https://docs.microsoft.com/en-us/windows/win32/api/d2d1/nf-d2d1-id2d1rendertarget-setantialiasmode void SetAntialiasMode(
		// D2D1_ANTIALIAS_MODE antialiasMode );
		[PreserveSig]
		new void SetAntialiasMode(D2D1_ANTIALIAS_MODE antialiasMode);

		/// <summary>Retrieves the current antialiasing mode for nontext drawing operations.</summary>
		/// <returns>
		/// <para>Type: <c>D2D1_ANTIALIAS_MODE</c></para>
		/// <para>The current antialiasing mode for nontext drawing operations.</para>
		/// </returns>
		// https://docs.microsoft.com/en-us/windows/win32/api/d2d1/nf-d2d1-id2d1rendertarget-getantialiasmode D2D1_ANTIALIAS_MODE GetAntialiasMode();
		[PreserveSig]
		new D2D1_ANTIALIAS_MODE GetAntialiasMode();

		/// <summary>Specifies the antialiasing mode to use for subsequent text and glyph drawing operations.</summary>
		/// <param name="textAntialiasMode">
		/// <para>Type: <c>D2D1_TEXT_ANTIALIAS_MODE</c></para>
		/// <para>The antialiasing mode to use for subsequent text and glyph drawing operations.</para>
		/// </param>
		/// <returns>None</returns>
		// https://docs.microsoft.com/en-us/windows/win32/api/d2d1/nf-d2d1-id2d1rendertarget-settextantialiasmode void
		// SetTextAntialiasMode( D2D1_TEXT_ANTIALIAS_MODE textAntialiasMode );
		[PreserveSig]
		new void SetTextAntialiasMode(D2D1_TEXT_ANTIALIAS_MODE textAntialiasMode);

		/// <summary>Gets the current antialiasing mode for text and glyph drawing operations.</summary>
		/// <returns>
		/// <para>Type: <c>D2D1_TEXT_ANTIALIAS_MODE</c></para>
		/// <para>The current antialiasing mode for text and glyph drawing operations.</para>
		/// </returns>
		// https://docs.microsoft.com/en-us/windows/win32/api/d2d1/nf-d2d1-id2d1rendertarget-gettextantialiasmode
		// D2D1_TEXT_ANTIALIAS_MODE GetTextAntialiasMode();
		[PreserveSig]
		new D2D1_TEXT_ANTIALIAS_MODE GetTextAntialiasMode();

		/// <summary>Specifies text rendering options to be applied to all subsequent text and glyph drawing operations.</summary>
		/// <param name="textRenderingParams">
		/// <para>Type: <c>IDWriteRenderingParams*</c></para>
		/// <para>
		/// The text rendering options to be applied to all subsequent text and glyph drawing operations; <c>NULL</c> to clear current
		/// text rendering options.
		/// </para>
		/// </param>
		/// <returns>None</returns>
		/// <remarks>
		/// If the settings specified by textRenderingParams are incompatible with the render target's text antialiasing mode (specified
		/// by SetTextAntialiasMode), subsequent text and glyph drawing operations will fail and put the render target into an error state.
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows/win32/api/d2d1/nf-d2d1-id2d1rendertarget-settextrenderingparams void
		// SetTextRenderingParams( IDWriteRenderingParams *textRenderingParams );
		[PreserveSig]
		new void SetTextRenderingParams([In, Optional] IDWriteRenderingParams? textRenderingParams);

		/// <summary>Retrieves the render target's current text rendering options.</summary>
		/// <param name="textRenderingParams">
		/// <para>Type: <c>IDWriteRenderingParams**</c></para>
		/// <para>
		/// When this method returns, textRenderingParamscontains the address of a pointer to the render target's current text rendering options.
		/// </para>
		/// </param>
		/// <returns>None</returns>
		/// <remarks>
		/// If the settings specified by textRenderingParams are incompatible with the render target's text antialiasing mode (specified
		/// by SetTextAntialiasMode), subsequent text and glyph drawing operations will fail and put the render target into an error state.
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows/win32/api/d2d1/nf-d2d1-id2d1rendertarget-gettextrenderingparams void
		// GetTextRenderingParams( IDWriteRenderingParams **textRenderingParams );
		[PreserveSig]
		new void GetTextRenderingParams(out IDWriteRenderingParams textRenderingParams);

		/// <summary>Specifies a label for subsequent drawing operations.</summary>
		/// <param name="tag1">
		/// <para>Type: <c>ulong</c></para>
		/// <para>A label to apply to subsequent drawing operations.</para>
		/// </param>
		/// <param name="tag2">
		/// <para>Type: <c>ulong</c></para>
		/// <para>A label to apply to subsequent drawing operations.</para>
		/// </param>
		/// <returns>None</returns>
		/// <remarks>
		/// The labels specified by this method are printed by debug error messages. If no tag is set, the default value for each tag is 0.
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows/win32/api/d2d1/nf-d2d1-id2d1rendertarget-settags void SetTags( ulong tag1, ulong
		// tag2 );
		[PreserveSig]
		new void SetTags(ulong tag1, ulong tag2);

		/// <summary>Gets the label for subsequent drawing operations.</summary>
		/// <param name="tag1">
		/// <para>Type: <c>D2D1_TAG*</c></para>
		/// <para>
		/// When this method returns, contains the first label for subsequent drawing operations. This parameter is passed
		/// uninitialized. If <c>NULL</c> is specified, no value is retrieved for this parameter.
		/// </para>
		/// </param>
		/// <param name="tag2">
		/// <para>Type: <c>D2D1_TAG*</c></para>
		/// <para>
		/// When this method returns, contains the second label for subsequent drawing operations. This parameter is passed
		/// uninitialized. If <c>NULL</c> is specified, no value is retrieved for this parameter.
		/// </para>
		/// </param>
		/// <returns>None</returns>
		/// <remarks>If the same address is passed for both parameters, both parameters receive the value of the second tag.</remarks>
		// https://docs.microsoft.com/en-us/windows/win32/api/d2d1/nf-d2d1-id2d1rendertarget-gettags void GetTags( D2D1_TAG *tag1,
		// D2D1_TAG *tag2 );
		[PreserveSig]
		new void GetTags(out ulong tag1, out ulong tag2);

		/// <summary>
		/// Adds the specified layer to the render target so that it receives all subsequent drawing operations until PopLayer is called.
		/// </summary>
		/// <param name="layerParameters">
		/// <para>Type: <c>const D2D1_LAYER_PARAMETERS</c></para>
		/// <para>The content bounds, geometric mask, opacity, opacity mask, and antialiasing options for the layer.</para>
		/// </param>
		/// <param name="layer">
		/// <para>Type: <c>ID2D1Layer*</c></para>
		/// <para>The layer that receives subsequent drawing operations.</para>
		/// <para>
		/// <c>Note</c> Starting with Windows 8, this parameter is optional. If a layer is not specified, Direct2D manages the layer
		/// resource automatically.
		/// </para>
		/// </param>
		/// <returns>None</returns>
		/// <remarks>
		/// <para>
		/// The <c>PushLayer</c> method allows a caller to begin redirecting rendering to a layer. All rendering operations are valid in
		/// a layer. The location of the layer is affected by the world transform set on the render target.
		/// </para>
		/// <para>
		/// Each PushLayer must have a matching PopLayer call. If there are more <c>PopLayer</c> calls than <c>PushLayer</c> calls, the
		/// render target is placed into an error state. If Flush is called before all outstanding layers are popped, the render target
		/// is placed into an error state, and an error is returned. The error state can be cleared by a call to EndDraw.
		/// </para>
		/// <para>
		/// A particular ID2D1Layer resource can be active only at one time. In other words, you cannot call a <c>PushLayer</c> method,
		/// and then immediately follow with another <c>PushLayer</c> method with the same layer resource. Instead, you must call the
		/// second <c>PushLayer</c> method with different layer resources.
		/// </para>
		/// <para>
		/// This method doesn't return an error code if it fails. To determine whether a drawing operation (such as PushLayer) failed,
		/// check the result returned by the ID2D1RenderTarget::EndDraw or ID2D1RenderTarget::Flush methods.
		/// </para>
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows/win32/api/d2d1/nf-d2d1-id2d1rendertarget-pushlayer(constd2d1_layer_parameters__id2d1layer)
		// void PushLayer( const D2D1_LAYER_PARAMETERS &amp; layerParameters, ID2D1Layer *layer );
		[PreserveSig]
		new void PushLayer(in D2D1_LAYER_PARAMETERS layerParameters, [In, Optional] ID2D1Layer? layer);

		/// <summary>Stops redirecting drawing operations to the layer that is specified by the last PushLayer call.</summary>
		/// <returns>None</returns>
		/// <remarks>
		/// <para>A <c>PopLayer</c> must match a previous PushLayer call.</para>
		/// <para>
		/// This method doesn't return an error code if it fails. To determine whether a drawing operation (such as <c>PopLayer</c>)
		/// failed, check the result returned by the ID2D1RenderTarget::EndDraw or ID2D1RenderTarget::Flush methods.
		/// </para>
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows/win32/api/d2d1/nf-d2d1-id2d1rendertarget-poplayer void PopLayer();
		[PreserveSig]
		new void PopLayer();

		/// <summary>Executes all pending drawing commands.</summary>
		/// <param name="tag1">
		/// <para>Type: <c>D2D1_TAG*</c></para>
		/// <para>
		/// When this method returns, contains the tag for drawing operations that caused errors or 0 if there were no errors. This
		/// parameter is passed uninitialized.
		/// </para>
		/// </param>
		/// <param name="tag2">
		/// <para>Type: <c>D2D1_TAG*</c></para>
		/// <para>
		/// When this method returns, contains the tag for drawing operations that caused errors or 0 if there were no errors. This
		/// parameter is passed uninitialized.
		/// </para>
		/// </param>
		/// <returns>
		/// <para>Type: <c>HRESULT</c></para>
		/// <para>
		/// If the method succeeds, it returns <c>S_OK</c>. Otherwise, it returns an <c>HRESULT</c> error code and sets tag1 and tag2 to
		/// the tags that were active when the error occurred. If no error occurred, this method sets the error tag state to be (0,0).
		/// </para>
		/// </returns>
		/// <remarks>
		/// <para>This command does not flush the Direct3D device context that is associated with the render target.</para>
		/// <para>Calling this method resets the error state of the render target.</para>
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows/win32/api/d2d1/nf-d2d1-id2d1rendertarget-flush HRESULT Flush( D2D1_TAG *tag1,
		// D2D1_TAG *tag2 );
		new void Flush(out ulong tag1, out ulong tag2);

		/// <summary>Saves the current drawing state to the specified ID2D1DrawingStateBlock.</summary>
		/// <param name="drawingStateBlock">
		/// <para>Type: <c>ID2D1DrawingStateBlock*</c></para>
		/// <para>
		/// When this method returns, contains the current drawing state of the render target. This parameter must be initialized before
		/// passing it to the method.
		/// </para>
		/// </param>
		/// <returns>None</returns>
		// https://docs.microsoft.com/en-us/windows/win32/api/d2d1/nf-d2d1-id2d1rendertarget-savedrawingstate void SaveDrawingState(
		// ID2D1DrawingStateBlock *drawingStateBlock );
		[PreserveSig]
		new void SaveDrawingState([In, Out] ID2D1DrawingStateBlock drawingStateBlock);

		/// <summary>Sets the render target's drawing state to that of the specified ID2D1DrawingStateBlock.</summary>
		/// <param name="drawingStateBlock">
		/// <para>Type: <c>ID2D1DrawingStateBlock*</c></para>
		/// <para>The new drawing state of the render target.</para>
		/// </param>
		/// <returns>None</returns>
		// https://docs.microsoft.com/en-us/windows/win32/api/d2d1/nf-d2d1-id2d1rendertarget-restoredrawingstate void
		// RestoreDrawingState( ID2D1DrawingStateBlock *drawingStateBlock );
		[PreserveSig]
		new void RestoreDrawingState([In] ID2D1DrawingStateBlock drawingStateBlock);

		/// <summary>Specifies a rectangle to which all subsequent drawing operations are clipped.</summary>
		/// <param name="clipRect">
		/// <para>Type: [in] <c>const D2D1_RECT_F &amp;</c></para>
		/// <para>The size and position of the clipping area, in device-independent pixels.</para>
		/// </param>
		/// <param name="antialiasMode">
		/// <para>Type: [in] <c>D2D1_ANTIALIAS_MODE</c></para>
		/// <para>
		/// The antialiasing mode that is used to draw the edges of clip rects that have subpixel boundaries, and to blend the clip with
		/// the scene contents. The blending is performed once when the PopAxisAlignedClip method is called, and does not apply to each
		/// primitive within the layer.
		/// </para>
		/// </param>
		/// <returns>None</returns>
		/// <remarks>
		/// <para>
		/// The clipRect is transformed by the current world transform set on the render target. After the transform is applied to the
		/// clipRect that is passed in, the axis-aligned bounding box for the clipRect is computed. For efficiency, the contents are
		/// clipped to this axis-aligned bounding box and not to the original clipRect that is passed in.
		/// </para>
		/// <para>
		/// The following diagrams show how a rotation transform is applied to the render target, the resulting clipRect, and a
		/// calculated axis-aligned bounding box.
		/// </para>
		/// <list type="number">
		/// <item>
		/// <term>Assume the rectangle in the following illustration is a render target that is aligned to the screen pixels.</term>
		/// </item>
		/// <item>
		/// <term>
		/// Apply a rotation transform to the render target. In the following illustration, the black rectangle represents the original
		/// render target and the red dashed rectangle represents the transformed render target.
		/// </term>
		/// </item>
		/// <item>
		/// <term>
		/// After calling <c>PushAxisAlignedClip</c>, the rotation transform is applied to the clipRect. In the following illustration,
		/// the blue rectangle represents the transformed clipRect.
		/// </term>
		/// </item>
		/// <item>
		/// <term>
		/// The axis-aligned bounding box is calculated. The green dashed rectangle represents the bounding box in the following
		/// illustration. All contents are clipped to this axis-aligned bounding box.
		/// </term>
		/// </item>
		/// </list>
		/// <para>
		/// <c>Note</c> If rendering operations fail or if PopAxisAlignedClip is not called, clip rects may cause some artifacts on the
		/// render target. <c>PopAxisAlignedClip</c> can be considered a drawing operation that is designed to fix the borders of a
		/// clipping region. Without this call, the borders of a clipped area may be not antialiased or otherwise corrected.
		/// </para>
		/// <para>
		/// The <c>PushAxisAlignedClip</c> and PopAxisAlignedClip must match. Otherwise, the error state is set. For the render target
		/// to continue receiving new commands, you can call Flush to clear the error.
		/// </para>
		/// <para>
		/// A <c>PushAxisAlignedClip</c> and PopAxisAlignedClip pair can occur around or within a PushLayer and PopLayer, but cannot
		/// overlap. For example, the sequence of <c>PushAxisAlignedClip</c>, PushLayer, PopLayer, <c>PopAxisAlignedClip</c> is valid,
		/// but the sequence of <c>PushAxisAlignedClip</c>, <c>PushLayer</c>, <c>PopAxisAlignedClip</c>, <c>PopLayer</c> is invalid.
		/// </para>
		/// <para>
		/// This method doesn't return an error code if it fails. To determine whether a drawing operation (such as PushAxisAlignedClip)
		/// failed, check the result returned by the ID2D1RenderTarget::EndDraw or ID2D1RenderTarget::Flush methods.
		/// </para>
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows/win32/api/d2d1/nf-d2d1-id2d1rendertarget-pushaxisalignedclip(constd2d1_rect_f__d2d1_antialias_mode)
		// void PushAxisAlignedClip( const D2D1_RECT_F &amp; clipRect, D2D1_ANTIALIAS_MODE antialiasMode );
		[PreserveSig]
		new void PushAxisAlignedClip(in D2D_RECT_F clipRect, D2D1_ANTIALIAS_MODE antialiasMode);

		/// <summary>
		/// Removes the last axis-aligned clip from the render target. After this method is called, the clip is no longer applied to
		/// subsequent drawing operations.
		/// </summary>
		/// <returns>None</returns>
		/// <remarks>
		/// <para>
		/// A PushAxisAlignedClip/ <c>PopAxisAlignedClip</c> pair can occur around or within a PushLayer/PopLayer pair, but may not
		/// overlap. For example, a <c>PushAxisAlignedClip</c>, <c>PushLayer</c>, <c>PopLayer</c>, <c>PopAxisAlignedClip</c> sequence is
		/// valid, but a <c>PushAxisAlignedClip</c>, <c>PushLayer</c>, <c>PopAxisAlignedClip</c>, <c>PopLayer</c> sequence is not.
		/// </para>
		/// <para><c>PopAxisAlignedClip</c> must be called once for every call to PushAxisAlignedClip.</para>
		/// <para>For an example, see How to Clip with an Axis-Aligned Clip Rectangle.</para>
		/// <para>
		/// This method doesn't return an error code if it fails. To determine whether a drawing operation (such as
		/// <c>PopAxisAlignedClip</c>) failed, check the result returned by the ID2D1RenderTarget::EndDraw or ID2D1RenderTarget::Flush methods.
		/// </para>
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows/win32/api/d2d1/nf-d2d1-id2d1rendertarget-popaxisalignedclip void PopAxisAlignedClip();
		[PreserveSig]
		new void PopAxisAlignedClip();

		/// <summary>Clears the drawing area to the specified color.</summary>
		/// <param name="clearColor">
		/// <para>Type: [in] <c>const D2D1_COLOR_F &amp;</c></para>
		/// <para>The color to which the drawing area is cleared.</para>
		/// </param>
		/// <returns>None</returns>
		/// <remarks>
		/// <para>
		/// Direct2D interprets the clearColor as straight alpha (not premultiplied). If the render target's alpha mode is
		/// D2D1_ALPHA_MODE_IGNORE, the alpha channel of clearColor is ignored and replaced with 1.0f (fully opaque).
		/// </para>
		/// <para>
		/// If the render target has an active clip (specified by PushAxisAlignedClip), the clear command is applied only to the area
		/// within the clip region.
		/// </para>
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows/win32/api/d2d1/nf-d2d1-id2d1rendertarget-clear(constd2d1_color_f_) void Clear( const
		// D2D1_COLOR_F &amp; clearColor );
		[PreserveSig]
		new void Clear([In, Optional] IntPtr clearColor);

		/// <summary>Initiates drawing on this render target.</summary>
		/// <returns>None</returns>
		/// <remarks>
		/// <para>Drawing operations can only be issued between a <c>BeginDraw</c> and EndDraw call.</para>
		/// <para>
		/// BeginDraw and EndDraw are used to indicate that a render target is in use by the Direct2D system. Different implementations
		/// of ID2D1RenderTarget might behave differently when <c>BeginDraw</c> is called. An ID2D1BitmapRenderTarget may be locked
		/// between <c>BeginDraw</c>/EndDraw calls, a DXGI surface render target might be acquired on <c>BeginDraw</c> and released on
		/// <c>EndDraw</c>, while an ID2D1HwndRenderTarget may begin batching at <c>BeginDraw</c> and may present on <c>EndDraw</c>, for example.
		/// </para>
		/// <para>
		/// The BeginDraw method must be called before rendering operations can be called, though state-setting and state-retrieval
		/// operations can be performed even outside of <c>BeginDraw</c>/EndDraw.
		/// </para>
		/// <para>
		/// After <c>BeginDraw</c> is called, a render target will normally build up a batch of rendering commands, but defer processing
		/// of these commands until either an internal buffer is full, the Flush method is called, or until EndDraw is called. The
		/// <c>EndDraw</c> method causes any batched drawing operations to complete, and then returns an HRESULT indicating the success
		/// of the operations and, optionally, the tag state of the render target at the time the error occurred. The <c>EndDraw</c>
		/// method always succeeds: it should not be called twice even if a previous <c>EndDraw</c> resulted in a failing HRESULT.
		/// </para>
		/// <para>
		/// If EndDraw is called without a matched call to <c>BeginDraw</c>, it returns an error indicating that <c>BeginDraw</c> must
		/// be called before <c>EndDraw</c>.
		/// </para>
		/// <para>
		/// Calling <c>BeginDraw</c> twice on a render target puts the target into an error state where nothing further is drawn, and
		/// returns an appropriate HRESULT and error information when <c>EndDraw</c> is called.
		/// </para>
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows/win32/api/d2d1/nf-d2d1-id2d1rendertarget-begindraw void BeginDraw();
		[PreserveSig]
		new void BeginDraw();

		/// <summary>Ends drawing operations on the render target and indicates the current error state and associated tags.</summary>
		/// <param name="tag1">
		/// <para>Type: <c>D2D1_TAG*</c></para>
		/// <para>
		/// When this method returns, contains the tag for drawing operations that caused errors or 0 if there were no errors. This
		/// parameter is passed uninitialized.
		/// </para>
		/// </param>
		/// <param name="tag2">
		/// <para>Type: <c>D2D1_TAG*</c></para>
		/// <para>
		/// When this method returns, contains the tag for drawing operations that caused errors or 0 if there were no errors. This
		/// parameter is passed uninitialized.
		/// </para>
		/// </param>
		/// <returns>
		/// <para>Type: <c>HRESULT</c></para>
		/// <para>
		/// If the method succeeds, it returns <c>S_OK</c>. Otherwise, it returns an <c>HRESULT</c> error code and sets tag1 and tag2 to
		/// the tags that were active when the error occurred.
		/// </para>
		/// </returns>
		/// <remarks>
		/// <para>Drawing operations can only be issued between a BeginDraw and <c>EndDraw</c> call.</para>
		/// <para>
		/// BeginDraw and <c>EndDraw</c> are use to indicate that a render target is in use by the Direct2D system. Different
		/// implementations of ID2D1RenderTarget might behave differently when <c>BeginDraw</c> is called. An ID2D1BitmapRenderTarget
		/// may be locked between <c>BeginDraw</c>/ <c>EndDraw</c> calls, a DXGI surface render target might be acquired on
		/// <c>BeginDraw</c> and released on <c>EndDraw</c>, while an ID2D1HwndRenderTarget may begin batching at <c>BeginDraw</c> and
		/// may present on <c>EndDraw</c>, for example.
		/// </para>
		/// <para>
		/// The BeginDraw method must be called before rendering operations can be called, though state-setting and state-retrieval
		/// operations can be performed even outside of <c>BeginDraw</c>/ <c>EndDraw</c>.
		/// </para>
		/// <para>
		/// After BeginDraw is called, a render target will normally build up a batch of rendering commands, but defer processing of
		/// these commands until either an internal buffer is full, the Flush method is called, or until <c>EndDraw</c> is called. The
		/// <c>EndDraw</c> method causes any batched drawing operations to complete, and then returns an <c>HRESULT</c> indicating the
		/// success of the operations and, optionally, the tag state of the render target at the time the error occurred. The
		/// <c>EndDraw</c> method always succeeds: it should not be called twice even if a previous <c>EndDraw</c> resulted in a failing <c>HRESULT</c>.
		/// </para>
		/// <para>
		/// If <c>EndDraw</c> is called without a matched call to BeginDraw, it returns an error indicating that <c>BeginDraw</c> must
		/// be called before <c>EndDraw</c>.
		/// </para>
		/// <para>
		/// Calling <c>BeginDraw</c> twice on a render target puts the target into an error state where nothing further is drawn, and
		/// returns an appropriate <c>HRESULT</c> and error information when <c>EndDraw</c> is called.
		/// </para>
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows/win32/api/d2d1/nf-d2d1-id2d1rendertarget-enddraw HRESULT EndDraw( D2D1_TAG *tag1,
		// D2D1_TAG *tag2 );
		new void EndDraw(out ulong tag1, out ulong tag2);

		/// <summary>Retrieves the pixel format and alpha mode of the render target.</summary>
		/// <returns>
		/// <para>Type: <c>D2D1_PIXEL_FORMAT</c></para>
		/// <para>The pixel format and alpha mode of the render target.</para>
		/// </returns>
		// https://docs.microsoft.com/en-us/windows/win32/api/d2d1/nf-d2d1-id2d1rendertarget-getpixelformat D2D1_PIXEL_FORMAT GetPixelFormat();
		[PreserveSig]
		new D2D1_PIXEL_FORMAT GetPixelFormat();

		/// <summary>Sets the dots per inch (DPI) of the render target.</summary>
		/// <param name="dpiX">
		/// <para>Type: <c>FLOAT</c></para>
		/// <para>A value greater than or equal to zero that specifies the horizontal DPI of the render target.</para>
		/// </param>
		/// <param name="dpiY">
		/// <para>Type: <c>FLOAT</c></para>
		/// <para>A value greater than or equal to zero that specifies the vertical DPI of the render target.</para>
		/// </param>
		/// <returns>None</returns>
		/// <remarks>
		/// <para>
		/// This method specifies the mapping from pixel space to device-independent space for the render target. If both dpiX and dpiY
		/// are 0, the factory-read system DPI is chosen. If one parameter is zero and the other unspecified, the DPI is not changed.
		/// </para>
		/// <para>
		/// For ID2D1HwndRenderTarget, the DPI defaults to the most recently factory-read system DPI. The default value for all other
		/// render targets is 96 DPI.
		/// </para>
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows/win32/api/d2d1/nf-d2d1-id2d1rendertarget-setdpi void SetDpi( FLOAT dpiX, FLOAT dpiY );
		[PreserveSig]
		new void SetDpi(float dpiX, float dpiY);

		/// <summary>Return the render target's dots per inch (DPI).</summary>
		/// <param name="dpiX">
		/// <para>Type: <c>FLOAT*</c></para>
		/// <para>When this method returns, contains the horizontal DPI of the render target. This parameter is passed uninitialized.</para>
		/// </param>
		/// <param name="dpiY">
		/// <para>Type: <c>FLOAT*</c></para>
		/// <para>When this method returns, contains the vertical DPI of the render target. This parameter is passed uninitialized.</para>
		/// </param>
		/// <returns>None</returns>
		/// <remarks>
		/// <para>This method indicates the mapping from pixel space to device-independent space for the render target.</para>
		/// <para>
		/// For ID2D1HwndRenderTarget, the DPI defaults to the most recently factory-read system DPI. The default value for all other
		/// render targets is 96 DPI.
		/// </para>
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows/win32/api/d2d1/nf-d2d1-id2d1rendertarget-getdpi void GetDpi( FLOAT *dpiX, FLOAT
		// *dpiY );
		[PreserveSig]
		new void GetDpi(out float dpiX, out float dpiY);

		/// <summary>Returns the size of the render target in device-independent pixels.</summary>
		/// <returns>
		/// <para>Type: <c>D2D1_SIZE_F</c></para>
		/// <para>The current size of the render target in device-independent pixels.</para>
		/// </returns>
		// https://docs.microsoft.com/en-us/windows/win32/api/d2d1/nf-d2d1-id2d1rendertarget-getsize D2D1_SIZE_F GetSize();
		[PreserveSig]
		new D2D_SIZE_F GetSize();

		/// <summary>Returns the size of the render target in device pixels.</summary>
		/// <returns>
		/// <para>Type: <c>D2D1_SIZE_U</c></para>
		/// <para>The size of the render target in device pixels.</para>
		/// </returns>
		// https://docs.microsoft.com/en-us/windows/win32/api/d2d1/nf-d2d1-id2d1rendertarget-getpixelsize D2D1_SIZE_U GetPixelSize();
		[PreserveSig]
		new D2D_SIZE_U GetPixelSize();

		/// <summary>
		/// Gets the maximum size, in device-dependent units (pixels), of any one bitmap dimension supported by the render target.
		/// </summary>
		/// <returns>
		/// <para>Type: <c>UINT32</c></para>
		/// <para>The maximum size, in pixels, of any one bitmap dimension supported by the render target.</para>
		/// </returns>
		/// <remarks>
		/// <para>This method returns the maximum texture size of the Direct3D device.</para>
		/// <para>
		/// <c>Note</c> The software renderer and WARP devices return the value of 16 megapixels (16*1024*1024). You can create a
		/// Direct2D texture that is this size, but not a Direct3D texture that is this size.
		/// </para>
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows/win32/api/d2d1/nf-d2d1-id2d1rendertarget-getmaximumbitmapsize UINT32 GetMaximumBitmapSize();
		[PreserveSig]
		new uint GetMaximumBitmapSize();

		/// <summary>Indicates whether the render target supports the specified properties.</summary>
		/// <param name="renderTargetProperties">
		/// <para>Type: <c>const D2D1_RENDER_TARGET_PROPERTIES*</c></para>
		/// <para>The render target properties to test.</para>
		/// </param>
		/// <returns>
		/// <para>Type: <c>BOOL</c></para>
		/// <para><c>TRUE</c> if the specified render target properties are supported by this render target; otherwise, <c>FALSE</c>.</para>
		/// </returns>
		/// <remarks>This method does not evaluate the DPI settings specified by the renderTargetProperties parameter.</remarks>
		// https://docs.microsoft.com/en-us/windows/win32/api/d2d1/nf-d2d1-id2d1rendertarget-issupported(constd2d1_render_target_properties_)
		// BOOL IsSupported( const D2D1_RENDER_TARGET_PROPERTIES &amp; renderTargetProperties );
		[PreserveSig]
		[return: MarshalAs(UnmanagedType.Bool)]
		new bool IsSupported(in D2D1_RENDER_TARGET_PROPERTIES renderTargetProperties);

		/// <summary>
		/// Creates a bitmap that can be used as a target surface, for reading back to the CPU, or as a source for the DrawBitmap and
		/// ID2D1BitmapBrush APIs. In addition, color context information can be passed to the bitmap.
		/// </summary>
		/// <param name="size">
		/// <para>Type: <c>D2D1_SIZE_U</c></para>
		/// <para>The pixel size of the bitmap to be created.</para>
		/// </param>
		/// <param name="sourceData">
		/// <para>Type: <c>const void*</c></para>
		/// <para>The initial data that will be loaded into the bitmap.</para>
		/// </param>
		/// <param name="pitch">
		/// <para>Type: <c>UINT32</c></para>
		/// <para>The pitch of the source data, if specified.</para>
		/// </param>
		/// <param name="bitmapProperties">
		/// <para>Type: <c>const D2D1_BITMAP_PROPERTIES1</c></para>
		/// <para>The properties of the bitmap to be created.</para>
		/// </param>
		/// <returns>
		/// <para>Type: <c>ID2D1Bitmap1**</c></para>
		/// <para>When this method returns, contains the address of a pointer to a new bitmap object.</para>
		/// </returns>
		/// <remarks>The new bitmap can be used as a target for SetTarget if it is created with D2D1_BITMAP_OPTIONS_TARGET.</remarks>
		// https://docs.microsoft.com/en-us/windows/win32/api/d2d1_1/nf-d2d1_1-id2d1devicecontext-createbitmap(d2d1_size_u_constvoid_uint32_constd2d1_bitmap_properties1_id2d1bitmap1)
		// HRESULT CreateBitmap( D2D1_SIZE_U size, const void *sourceData, UINT32 pitch, const D2D1_BITMAP_PROPERTIES1
		// *bitmapProperties, ID2D1Bitmap1 **bitmap );
		ID2D1Bitmap1 CreateBitmap(D2D_SIZE_U size, [In, Optional] IntPtr sourceData, uint pitch, in D2D1_BITMAP_PROPERTIES1 bitmapProperties);

		/// <summary>Creates an ID2D1Bitmap by copying the specified Microsoft Windows Imaging Component (WIC) bitmap.</summary>
		/// <param name="wicBitmapSource">
		/// <para>Type: <c>IWICBitmapSource*</c></para>
		/// <para>The WIC bitmap to copy.</para>
		/// </param>
		/// <param name="bitmapProperties">
		/// <para>Type: <c>const D2D1_BITMAP_PROPERTIES1</c></para>
		/// <para>The properties of the bitmap to be created.</para>
		/// </param>
		/// <returns>
		/// <para>Type: <c>ID2D1Bitmap1**</c></para>
		/// <para>When this method returns, contains a pointer to a pointer to the new bitmap. This parameter is passed uninitialized.</para>
		/// </returns>
		// https://docs.microsoft.com/en-us/windows/win32/api/d2d1_1/nf-d2d1_1-id2d1devicecontext-createbitmapfromwicbitmap(iwicbitmapsource_id2d1bitmap1)
		// HRESULT CreateBitmapFromWicBitmap( IWICBitmapSource *wicBitmapSource, ID2D1Bitmap1 **bitmap );
		ID2D1Bitmap1 CreateBitmap1FromWicBitmap(IWICBitmapSource wicBitmapSource, [In, Optional] IntPtr bitmapProperties);

		/// <summary>Creates a color context.</summary>
		/// <param name="space">
		/// <para>Type: <c>D2D1_COLOR_SPACE</c></para>
		/// <para>The space of color context to create.</para>
		/// </param>
		/// <param name="profile">
		/// <para>Type: <c>const BYTE*</c></para>
		/// <para>
		/// A buffer containing the ICC profile bytes used to initialize the color context when space is D2D1_COLOR_SPACE_CUSTOM. For
		/// other types, the parameter is ignored and should be set to <c>NULL</c>.
		/// </para>
		/// </param>
		/// <param name="profileSize">
		/// <para>Type: <c>UINT32</c></para>
		/// <para>The size in bytes of Profile.</para>
		/// </param>
		/// <returns>
		/// <para>Type: <c>ID2D1ColorContext**</c></para>
		/// <para>When this method returns, contains the address of a pointer to a new color context object.</para>
		/// </returns>
		/// <remarks>
		/// <para>The new color context can be used in D2D1_BITMAP_PROPERTIES1 to initialize the color context of a created bitmap.</para>
		/// <para>
		/// When space is D2D1_COLOR_SPACE_CUSTOM, profile and profileSize must be specified. Otherwise, these parameters should be set
		/// to <c>NULL</c> and zero respectively. When the space is D2D1_COLOR_SPACE_CUSTOM, the model field of the profile header is
		/// inspected to determine if this profile is sRGB or scRGB and the color space is updated respectively. Otherwise the space
		/// remains custom.
		/// </para>
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows/win32/api/d2d1_1/nf-d2d1_1-id2d1devicecontext-createcolorcontext HRESULT
		// CreateColorContext( D2D1_COLOR_SPACE space, const BYTE *profile, UINT32 profileSize, ID2D1ColorContext **colorContext );
		ID2D1ColorContext CreateColorContext(D2D1_COLOR_SPACE space, [In, Optional] IntPtr profile, int profileSize);

		/// <summary>
		/// Creates a color context by loading it from the specified filename. The profile bytes are the contents of the file specified
		/// by Filename.
		/// </summary>
		/// <param name="filename">
		/// <para>Type: <c>PCWSTR</c></para>
		/// <para>The path to the file containing the profile bytes to initialize the color context with.</para>
		/// </param>
		/// <returns>
		/// <para>Type: <c>ID2D1ColorContext**</c></para>
		/// <para>When this method returns, contains the address of a pointer to a new color context.</para>
		/// </returns>
		/// <remarks>
		/// The new color context can be used in D2D1_BITMAP_PROPERTIES1 to initialize the color context of a created bitmap. The model
		/// field of the profile header is inspected to determine whether this profile is sRGB or scRGB and the color space is updated
		/// respectively. Otherwise the space is custom.
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows/win32/api/d2d1_1/nf-d2d1_1-id2d1devicecontext-createcolorcontextfromfilename HRESULT
		// CreateColorContextFromFilename( PCWSTR filename, ID2D1ColorContext **colorContext );
		ID2D1ColorContext CreateColorContextFromFilename([MarshalAs(UnmanagedType.LPWStr)] string filename);

		/// <summary>
		/// Creates a color context from an IWICColorContext. The D2D1ColorContext space of the resulting context varies, see Remarks
		/// for more info.
		/// </summary>
		/// <param name="wicColorContext">
		/// <para>Type: <c>IWICColorContext*</c></para>
		/// <para>The IWICColorContext used to initialize the color context.</para>
		/// </param>
		/// <returns>
		/// <para>Type: <c>ID2D1ColorContext**</c></para>
		/// <para>When this method returns, contains the address of a pointer to a new color context.</para>
		/// </returns>
		/// <remarks>
		/// The new color context can be used in D2D1_BITMAP_PROPERTIES1 to initialize the color context of a created bitmap. The model
		/// field of the profile header is inspected to determine whether this profile is sRGB or scRGB and the color space is updated
		/// respectively. Otherwise the space is custom.
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows/win32/api/d2d1_1/nf-d2d1_1-id2d1devicecontext-createcolorcontextfromwiccolorcontext
		// HRESULT CreateColorContextFromWicColorContext( IWICColorContext *wicColorContext, ID2D1ColorContext **colorContext );
		ID2D1ColorContext CreateColorContextFromWicColorContext(IWICColorContext wicColorContext);

		/// <summary>
		/// Creates a bitmap from a DXGI surface that can be set as a target surface or have additional color context information specified.
		/// </summary>
		/// <param name="surface">
		/// <para>Type: <c>IDXGISurface*</c></para>
		/// <para>The DXGI surface from which the bitmap can be created.</para>
		/// <para>
		/// <c>Note</c> The DXGI surface must have been created from the same Direct3D device that the Direct2D device context is
		/// associated with.
		/// </para>
		/// </param>
		/// <param name="bitmapProperties">
		/// <para>Type: <c>const D2D1_BITMAP_PROPERTIES1*</c></para>
		/// <para>The bitmap properties specified in addition to the surface.</para>
		/// </param>
		/// <returns>
		/// <para>Type: <c>ID2D1Bitmap1**</c></para>
		/// <para>When this method returns, contains the address of a pointer to a new bitmap object.</para>
		/// </returns>
		/// <remarks>
		/// <para>If the bitmap properties are not specified, the following information is assumed:</para>
		/// <list type="bullet">
		/// <item>
		/// <term>The bitmap DPI is 96.</term>
		/// </item>
		/// <item>
		/// <term>The pixel format matches that of the surface.</term>
		/// </item>
		/// <item>
		/// <term>The returned bitmap will inherit the bind flags of the DXGI surface.</term>
		/// </item>
		/// <item>
		/// <term>The color context is unknown.</term>
		/// </item>
		/// <item>
		/// <term>The alpha mode of the bitmap will be premultiplied (common case) or straight (A8).</term>
		/// </item>
		/// </list>
		/// <para>If the bitmap properties are specified, the bitmap properties will be used as follows:</para>
		/// <list type="bullet">
		/// <item>
		/// <term>The bitmap DPI will be specified by the bitmap properties.</term>
		/// </item>
		/// <item>
		/// <term>If both dpiX and dpiY are 0, the bitmap DPI will be 96.</term>
		/// </item>
		/// <item>
		/// <term>The pixel format must be compatible with the shader resource view or render target view of the surface.</term>
		/// </item>
		/// <item>
		/// <term>
		/// The bitmap options must be compatible with the bind flags of the DXGI surface. However, they may be a subset. This will
		/// influence what resource views are created by the bitmap.
		/// </term>
		/// </item>
		/// <item>
		/// <term>The color context information will be used from the bitmap properties, if specified.</term>
		/// </item>
		/// </list>
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows/win32/api/d2d1_1/nf-d2d1_1-id2d1devicecontext-createbitmapfromdxgisurface(idxgisurface_constd2d1_bitmap_properties1__id2d1bitmap1)
		// HRESULT CreateBitmapFromDxgiSurface( IDXGISurface *surface, const D2D1_BITMAP_PROPERTIES1 &amp; bitmapProperties,
		// ID2D1Bitmap1 **bitmap );
		ID2D1Bitmap1 CreateBitmapFromDxgiSurface(IDXGISurface surface, [In, Optional] IntPtr bitmapProperties);

		/// <summary>Creates an effect for the specified class ID.</summary>
		/// <param name="effectId">
		/// <para>Type: <c>REFCLSID</c></para>
		/// <para>The class ID of the effect to create. See Built-in Effects for a list of effect IDs.</para>
		/// </param>
		/// <returns>
		/// <para>Type: <c>ID2D1Effect**</c></para>
		/// <para>When this method returns, contains the address of a pointer to a new effect.</para>
		/// </returns>
		/// <remarks>
		/// If the created effect is a custom effect that is implemented in a DLL, this doesn't increment the reference count for that
		/// DLL. If the application deletes an effect while that effect is loaded, the resulting behavior is unpredictable.
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows/win32/api/d2d1_1/nf-d2d1_1-id2d1devicecontext-createeffect HRESULT CreateEffect(
		// REFCLSID effectId, ID2D1Effect **effect );
		ID2D1Effect CreateEffect(in Guid effectId);

		/// <summary>
		/// Creates a gradient stop collection, enabling the gradient to contain color channels with values outside of [0,1] and also
		/// enabling rendering to a high-color render target with interpolation in sRGB space.
		/// </summary>
		/// <param name="straightAlphaGradientStops">
		/// <para>Type: <c>const D2D1_GRADIENT_STOP*</c></para>
		/// <para>An array of color values and offsets.</para>
		/// </param>
		/// <param name="straightAlphaGradientStopsCount">
		/// <para>Type: <c>UINT</c></para>
		/// <para>The number of elements in the gradientStops array.</para>
		/// </param>
		/// <param name="preInterpolationSpace">
		/// <para>Type: <c>D2D1_COLOR_SPACE</c></para>
		/// <para>Specifies both the input color space and the space in which the color interpolation occurs.</para>
		/// </param>
		/// <param name="postInterpolationSpace">
		/// <para>Type: <c>D2D1_COLOR_SPACE</c></para>
		/// <para>The color space that colors will be converted to after interpolation occurs.</para>
		/// </param>
		/// <param name="bufferPrecision">
		/// <para>Type: <c>D2D1_BUFFER_PRECISION</c></para>
		/// <para>The precision of the texture used to hold interpolated values.</para>
		/// <para>
		/// <c>Note</c> This method will fail if the underlying Direct3D device does not support the requested buffer precision. Use
		/// ID2D1DeviceContext::IsBufferPrecisionSupported to determine what is supported.
		/// </para>
		/// </param>
		/// <param name="extendMode">
		/// <para>Type: <c>D2D1_EXTEND_MODE</c></para>
		/// <para>Defines how colors outside of the range defined by the stop collection are determined.</para>
		/// </param>
		/// <param name="colorInterpolationMode">
		/// <para>Type: <c>D2D1_COLOR_INTERPOLATION_MODE</c></para>
		/// <para>
		/// Defines how colors are interpolated. D2D1_COLOR_INTERPOLATION_MODE_PREMULTIPLIED is the default, see Remarks for more info.
		/// </para>
		/// </param>
		/// <returns>
		/// <para>Type: <c>ID2D1GradientStopCollection1**</c></para>
		/// <para>The new gradient stop collection.</para>
		/// </returns>
		/// <remarks>
		/// <para>
		/// This method linearly interpolates between the color stops. An optional color space conversion is applied post-interpolation.
		/// Whether and how this gamma conversion is applied is determined by the pre- and post-interpolation. This method will fail if
		/// the device context does not support the requested buffer precision.
		/// </para>
		/// <para>In order to get the desired result, you need to ensure that the inputs are specified in the correct color space.</para>
		/// <para>
		/// You must always specify colors in straight alpha, regardless of interpolation mode being premultiplied or straight. The
		/// interpolation mode only affects the interpolated values. Likewise, the stops returned by
		/// ID2D1GradientStopCollection::GetGradientStops will always have straight alpha.
		/// </para>
		/// <para>
		/// If you specify D2D1_COLOR_INTERPOLATION_MODE_PREMULTIPLIED, then all stops are premultiplied before interpolation, and then
		/// un-premultiplied before color conversion.
		/// </para>
		/// <para>Starting with Windows 8, the interpolation behavior of this method has changed.</para>
		/// <para>The table here shows the behavior in Windows 7 and earlier.</para>
		/// <list type="table">
		/// <listheader>
		/// <term>Gamma</term>
		/// <term>Before Interpolation Behavior</term>
		/// <term>After Interpolation Behavior</term>
		/// <term>GetColorInteroplationGamma (output color space)</term>
		/// </listheader>
		/// <item>
		/// <term>1.0</term>
		/// <term>Clamps the inputs and then converts from sRGB to scRGB.</term>
		/// <term>Converts from scRGB to sRGB post-interpolation.</term>
		/// <term>1.0</term>
		/// </item>
		/// <item>
		/// <term>2.2</term>
		/// <term>Clamps the inputs.</term>
		/// <term>No Operation</term>
		/// <term>2.2</term>
		/// </item>
		/// </list>
		/// <para>The table here shows the behavior in Windows 8 and later.</para>
		/// <list type="table">
		/// <listheader>
		/// <term>Gamma</term>
		/// <term>Before Interpolation Behavior</term>
		/// <term>After Interpolation Behavior</term>
		/// <term>GetColorInteroplationGamma (output color space)</term>
		/// </listheader>
		/// <item>
		/// <term>sRGB to scRGB</term>
		/// <term>No Operation</term>
		/// <term>Clamps the outputs and then converts from sRGB to scRGB.</term>
		/// <term>1.0</term>
		/// </item>
		/// <item>
		/// <term>scRGB to sRGB</term>
		/// <term>No Operation</term>
		/// <term>Clamps the outputs and then converts from sRGB to scRGB.</term>
		/// <term>2.2</term>
		/// </item>
		/// <item>
		/// <term>sRGB to sRGB</term>
		/// <term>No Operation</term>
		/// <term>No Operation</term>
		/// <term>2.2</term>
		/// </item>
		/// <item>
		/// <term>scRGB to scRGB</term>
		/// <term>No Operation</term>
		/// <term>No Operation</term>
		/// <term>1.0</term>
		/// </item>
		/// </list>
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows/win32/api/d2d1_1/nf-d2d1_1-id2d1devicecontext-creategradientstopcollection HRESULT
		// CreateGradientStopCollection( const D2D1_GRADIENT_STOP *straightAlphaGradientStops, UINT32 straightAlphaGradientStopsCount,
		// D2D1_COLOR_SPACE preInterpolationSpace, D2D1_COLOR_SPACE postInterpolationSpace, D2D1_BUFFER_PRECISION bufferPrecision,
		// D2D1_EXTEND_MODE extendMode, D2D1_COLOR_INTERPOLATION_MODE colorInterpolationMode, ID2D1GradientStopCollection1
		// **gradientStopCollection1 );
		ID2D1GradientStopCollection1 CreateGradientStopCollection([In, MarshalAs(UnmanagedType.LPArray, SizeParamIndex = 1)] D2D1_GRADIENT_STOP[] straightAlphaGradientStops, uint straightAlphaGradientStopsCount,
			D2D1_COLOR_SPACE preInterpolationSpace, D2D1_COLOR_SPACE postInterpolationSpace, D2D1_BUFFER_PRECISION bufferPrecision, D2D1_EXTEND_MODE extendMode, D2D1_COLOR_INTERPOLATION_MODE colorInterpolationMode);

		/// <summary>Creates an image brush. The input image can be any type of image, including a bitmap, effect, or a command list.</summary>
		/// <param name="image">
		/// <para>Type: <c>ID2D1Image*</c></para>
		/// <para>The image to be used as a source for the image brush.</para>
		/// </param>
		/// <param name="imageBrushProperties">
		/// <para>Type: <c>const D2D1_IMAGE_BRUSH_PROPERTIES</c></para>
		/// <para>The properties specific to an image brush.</para>
		/// </param>
		/// <param name="brushProperties">
		/// <para>Type: <c>const D2D1_BRUSH_PROPERTIES</c></para>
		/// <para>Properties common to all brushes.</para>
		/// </param>
		/// <returns>
		/// <para>Type: <c>ID2D1ImageBrush**</c></para>
		/// <para>When this method returns, contains the address of a pointer to the input rectangles.</para>
		/// </returns>
		/// <remarks>
		/// <para>The image brush can be used to fill an arbitrary geometry, an opacity mask or text.</para>
		/// <para>This sample illustrates drawing a rectangle with an image brush.</para>
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows/win32/api/d2d1_1/nf-d2d1_1-id2d1devicecontext-createimagebrush(id2d1image_constd2d1_image_brush_properties__constd2d1_brush_properties__id2d1imagebrush)
		// HRESULT CreateImageBrush( ID2D1Image *image, const D2D1_IMAGE_BRUSH_PROPERTIES &amp; imageBrushProperties, const
		// D2D1_BRUSH_PROPERTIES &amp; brushProperties, ID2D1ImageBrush **imageBrush );
		ID2D1ImageBrush CreateImageBrush([Optional] ID2D1Image? image, in D2D1_IMAGE_BRUSH_PROPERTIES imageBrushProperties, [In, Optional] IntPtr brushProperties);

		/// <summary>Creates a bitmap brush, the input image is a Direct2D bitmap object.</summary>
		/// <param name="bitmap">
		/// <para>Type: <c>ID2D1Bitmap*</c></para>
		/// <para>The bitmap to use as the brush.</para>
		/// </param>
		/// <param name="bitmapBrushProperties">
		/// <para>Type: <c>D2D1_BITMAP_BRUSH_PROPERTIES1*</c></para>
		/// <para>A bitmap brush properties structure.</para>
		/// </param>
		/// <param name="brushProperties">
		/// <para>Type: <c>D2D1_BRUSH_PROPERTIES*</c></para>
		/// <para>A brush properties structure.</para>
		/// </param>
		/// <returns>
		/// <para>Type: <c>ID2D1BitmapBrush1**</c></para>
		/// <para>The address of the newly created bitmap brush object.</para>
		/// </returns>
		// https://docs.microsoft.com/en-us/windows/win32/api/d2d1_1/nf-d2d1_1-id2d1devicecontext-createbitmapbrush%28id2d1bitmap_constd2d1_bitmap_brush_properties1_constd2d1_brush_properties_id2d1bitmapbrush1%29
		// HRESULT CreateBitmapBrush( ID2D1Bitmap *bitmap, const D2D1_BITMAP_BRUSH_PROPERTIES1 *bitmapBrushProperties, const
		// D2D1_BRUSH_PROPERTIES *brushProperties, ID2D1BitmapBrush1 **bitmapBrush );
		ID2D1BitmapBrush1 CreateBitmapBrush1([Optional] ID2D1Bitmap? bitmap, [In, Optional] IntPtr bitmapBrushProperties, [In, Optional] IntPtr brushProperties);

		/// <summary>Creates a ID2D1CommandList object.</summary>
		/// <returns>
		/// <para>Type: <c>ID2D1CommandList**</c></para>
		/// <para>When this method returns, contains the address of a pointer to a command list.</para>
		/// </returns>
		/// <remarks>
		/// A ID2D1CommandList can store Direct2D commands to be displayed later through ID2D1DeviceContext::DrawImage or through an
		/// image brush.
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows/win32/api/d2d1_1/nf-d2d1_1-id2d1devicecontext-createcommandlist HRESULT
		// CreateCommandList( ID2D1CommandList **commandList );
		ID2D1CommandList CreateCommandList();

		/// <summary>
		/// Indicates whether the format is supported by the device context. The formats supported are usually determined by the
		/// underlying hardware.
		/// </summary>
		/// <param name="format">
		/// <para>Type: <c>format</c></para>
		/// <para>The DXGI format to check.</para>
		/// </param>
		/// <returns>
		/// <para>Type: <c>BOOL</c></para>
		/// <para>Returns TRUE if the format is supported. Returns FALSE if the format is not supported.</para>
		/// </returns>
		/// <remarks>
		/// <para>You can use supported formats in the D2D1_PIXEL_FORMAT structure to create bitmaps and render targets.</para>
		/// <para>Direct2D doesn't support all DXGI formats, even though they may have some level of Direct3D support by the hardware.</para>
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows/win32/api/d2d1_1/nf-d2d1_1-id2d1devicecontext-isdxgiformatsupported BOOL
		// IsDxgiFormatSupported( DXGI_FORMAT format );
		[PreserveSig]
		[return: MarshalAs(UnmanagedType.Bool)]
		bool IsDxgiFormatSupported(DXGI_FORMAT format);

		/// <summary>Indicates whether the buffer precision is supported by the underlying Direct3D device.</summary>
		/// <param name="bufferPrecision">
		/// <para>Type: <c>D2D1_BUFFER_PRECISION</c></para>
		/// <para>The buffer precision to check.</para>
		/// </param>
		/// <returns>
		/// <para>Type: <c>BOOL</c></para>
		/// <para>Returns TRUE if the buffer precision is supported. Returns FALSE if the buffer precision is not supported.</para>
		/// </returns>
		// https://docs.microsoft.com/en-us/windows/win32/api/d2d1_1/nf-d2d1_1-id2d1devicecontext-isbufferprecisionsupported BOOL
		// IsBufferPrecisionSupported( D2D1_BUFFER_PRECISION bufferPrecision );
		[PreserveSig]
		[return: MarshalAs(UnmanagedType.Bool)]
		bool IsBufferPrecisionSupported(D2D1_BUFFER_PRECISION bufferPrecision);

		/// <summary>Gets the bounds of an image without the world transform of the context applied.</summary>
		/// <param name="image">
		/// <para>Type: <c>ID2D1Image*</c></para>
		/// <para>The image whose bounds will be calculated.</para>
		/// </param>
		/// <returns>
		/// <para>Type: <c>D2D1_RECT_F[1]</c></para>
		/// <para>
		/// When this method returns, contains a pointer to the bounds of the image in device independent pixels (DIPs) and in local space.
		/// </para>
		/// </returns>
		/// <remarks>
		/// <para>
		/// The image bounds don't include multiplication by the world transform. They do reflect the current DPI, unit mode, and
		/// interpolation mode of the context. To get the bounds that include the world transform, use ID2D1DeviceContext::GetImageWorldBounds.
		/// </para>
		/// <para>
		/// The returned bounds reflect which pixels would be impacted by calling DrawImage with a target offset of (0,0) and an
		/// identity world transform matrix. They do not reflect the current clip rectangle set on the device context or the extent of
		/// the context's current target image.
		/// </para>
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows/win32/api/d2d1_1/nf-d2d1_1-id2d1devicecontext-getimagelocalbounds HRESULT
		// GetImageLocalBounds( ID2D1Image *image, D2D1_RECT_F *localBounds );
		D2D_RECT_F GetImageLocalBounds(ID2D1Image image);

		/// <summary>Gets the bounds of an image with the world transform of the context applied.</summary>
		/// <param name="image">
		/// <para>Type: <c>ID2D1Image*</c></para>
		/// <para>The image whose bounds will be calculated.</para>
		/// </param>
		/// <returns>
		/// <para>Type: <c>D2D1_RECT_F[1]</c></para>
		/// <para>When this method returns, contains a pointer to the bounds of the image in device independent pixels (DIPs).</para>
		/// </returns>
		/// <remarks>
		/// <para>
		/// The image bounds reflect the current DPI, unit mode, and world transform of the context. To get bounds which don't include
		/// the world transform, use ID2D1DeviceContext::GetImageLocalBounds.
		/// </para>
		/// <para>
		/// The returned bounds reflect which pixels would be impacted by calling DrawImage with the same image and a target offset of
		/// (0,0). They do not reflect the current clip rectangle set on the device context or the extent of the context’s current
		/// target image.
		/// </para>
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows/win32/api/d2d1_1/nf-d2d1_1-id2d1devicecontext-getimageworldbounds HRESULT
		// GetImageWorldBounds( ID2D1Image *image, D2D1_RECT_F *worldBounds );
		D2D_RECT_F GetImageWorldBounds(ID2D1Image image);

		/// <summary>Gets the world-space bounds in DIPs of the glyph run using the device context DPI.</summary>
		/// <param name="baselineOrigin">
		/// <para>Type: <c>D2D1_POINT_2F</c></para>
		/// <para>The origin of the baseline for the glyph run.</para>
		/// </param>
		/// <param name="glyphRun">
		/// <para>Type: <c>const DWRITE_GLYPH_RUN*</c></para>
		/// <para>The glyph run to render.</para>
		/// </param>
		/// <param name="measuringMode">
		/// <para>Type: <c>DWRITE_MEASURING_MODE</c></para>
		/// <para>The DirectWrite measuring mode that indicates how glyph metrics are used to measure text when it is formatted.</para>
		/// </param>
		/// <returns>
		/// <para>Type: <c>D2D1_RECT_F*</c></para>
		/// <para>The bounds of the glyph run in DIPs and in world space.</para>
		/// </returns>
		/// <remarks>The image bounds reflect the current DPI, unit mode, and world transform of the context.</remarks>
		// https://docs.microsoft.com/en-us/windows/win32/api/d2d1_1/nf-d2d1_1-id2d1devicecontext-getglyphrunworldbounds HRESULT
		// GetGlyphRunWorldBounds( D2D1_POINT_2F baselineOrigin, const DWRITE_GLYPH_RUN *glyphRun, DWRITE_MEASURING_MODE measuringMode,
		// D2D1_RECT_F *bounds );
		D2D_RECT_F GetGlyphRunWorldBounds(D2D_POINT_2F baselineOrigin, in DWRITE_GLYPH_RUN glyphRun, DWRITE_MEASURING_MODE measuringMode);

		/// <summary>Gets the device associated with a device context.</summary>
		/// <param name="device">
		/// <para>Type: <c>ID2D1Device**</c></para>
		/// <para>When this method returns, contains the address of a pointer to a Direct2D device associated with this device context.</para>
		/// </param>
		/// <returns>None</returns>
		/// <remarks>
		/// The application can retrieve the device even if it is created from an earlier render target code-path. The application must
		/// use an ID2D1DeviceContext interface and then call <c>GetDevice</c>. Some functionality for controlling all of the resources
		/// for a set of device contexts is maintained only on an ID2D1Device object.
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows/win32/api/d2d1_1/nf-d2d1_1-id2d1devicecontext-getdevice void GetDevice( ID2D1Device
		// **device );
		[PreserveSig]
		void GetDevice(out ID2D1Device device);

		/// <summary>The bitmap or command list to which the Direct2D device context will now render.</summary>
		/// <param name="image">
		/// <para>Type: <c>ID2D1Image*</c></para>
		/// <para>The surface or command list to which the Direct2D device context will render.</para>
		/// </param>
		/// <returns>None</returns>
		/// <remarks>
		/// <para>The target can be changed at any time, including while the context is drawing.</para>
		/// <para>
		/// The target can be either a bitmap created with the D2D1_BITMAP_OPTIONS_TARGET flag, or it can be a command list. Other kinds
		/// of images cannot be set as a target. For example, you cannot set the output of an effect as target. If the target is not
		/// valid the context will enter the <c>D2DERR_INVALID_TARGET</c> error state.
		/// </para>
		/// <para>
		/// You cannot use <c>SetTarget</c> to render to a bitmap/command list from multiple device contexts simultaneously. An image is
		/// considered “being rendered to” if it has ever been set on a device context within a BeginDraw/EndDraw timespan. If an
		/// attempt is made to render to an image through multiple device contexts, all subsequent device contexts after the first will
		/// enter an error state.
		/// </para>
		/// <para>Callers wishing to attach an image to a second device context should first call EndDraw on the first device context.</para>
		/// <para>Here is an example of the correct calling order.</para>
		/// <para>Here is an example of the incorrect calling order.</para>
		/// <para>
		/// <c>Note</c> Changing the target does not change the bitmap that an HWND render target presents from, nor does it change the
		/// bitmap that a DC render target blts to/from.
		/// </para>
		/// <para>
		/// This API makes it easy for an application to use a bitmap as a source (like in DrawBitmap) and as a destination at the same
		/// time. Attempting to use a bitmap as a source on the same device context to which it is bound as a target will put the device
		/// context into the D2DERR_BITMAP_BOUND_AS_TARGET error state.
		/// </para>
		/// <para>
		/// It is acceptable to have a bitmap bound as a target bitmap on multiple render targets at once. Applications that do this
		/// must properly synchronize rendering with Flush or EndDraw.
		/// </para>
		/// <para>You can change the target at any time, including while the context is drawing.</para>
		/// <para>
		/// You can set the target to NULL, in which case drawing calls will put the device context into an error state with
		/// D2DERR_WRONG_STATE. Calling <c>SetTarget</c> with a NULL target does not restore the original target bitmap to the device context.
		/// </para>
		/// <para>
		/// If the device context has an outstanding HDC, the context will enter the <c>D2DERR_WRONG_STATE</c> error state. The target
		/// will not be changed.
		/// </para>
		/// <para>
		/// If the bitmap and the device context are not in the same resource domain, the context will enter <c>&lt;/b&gt; error state.
		/// The target will not be changed.</c>
		/// </para>
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows/win32/api/d2d1_1/nf-d2d1_1-id2d1devicecontext-settarget void SetTarget( ID2D1Image
		// *image );
		[PreserveSig]
		void SetTarget(ID2D1Image? image);

		/// <summary>Gets the target currently associated with the device context.</summary>
		/// <param name="image">
		/// <para>Type: <c>ID2D1Image**</c></para>
		/// <para>When this method returns, contains the address of a pointer to the target currently associated with the device context.</para>
		/// </param>
		/// <returns>None</returns>
		/// <remarks>
		/// <para>If a target is not associated with the device context, target will contain <c>NULL</c> when the methods returns.</para>
		/// <para>
		/// If the currently selected target is a bitmap rather than a command list, the application can gain access to the initial
		/// bitmaps created by using one of the following methods:
		/// </para>
		/// <list type="bullet">
		/// <item>
		/// <term>CreateHwndRenderTarget</term>
		/// </item>
		/// <item>
		/// <term>CreateDxgiSurfaceRenderTarget</term>
		/// </item>
		/// <item>
		/// <term>CreateWicBitmapRenderTarget</term>
		/// </item>
		/// <item>
		/// <term>CreateDCRenderTarget</term>
		/// </item>
		/// <item>
		/// <term>CreateCompatibleRenderTarget</term>
		/// </item>
		/// </list>
		/// <para>
		/// It is not possible for an application to destroy these bitmaps. All of these bitmaps are bindable as bitmap targets. However
		/// not all of these bitmaps can be used as bitmap sources for ID2D1RenderTarget methods.
		/// </para>
		/// <para>
		/// CreateDxgiSurfaceRenderTarget will create a bitmap that is usable as a bitmap source if the DXGI surface is bindable as a
		/// shader resource view.
		/// </para>
		/// <para>CreateCompatibleRenderTarget will always create bitmaps that are usable as a bitmap source.</para>
		/// <para>
		/// ID2D1RenderTarget::BeginDraw will copy from the HDC to the original bitmap associated with it. ID2D1RenderTarget::EndDraw
		/// will copy from the original bitmap to the HDC.
		/// </para>
		/// <para>IWICBitmap objects will be locked in the following circumstances:</para>
		/// <list type="bullet">
		/// <item>
		/// <term>BeginDraw has been called and the currently selected target bitmap is a WIC bitmap.</term>
		/// </item>
		/// <item>
		/// <term>
		/// A WIC bitmap is set as the target of a device context after BeginDraw has been called and before EndDraw has been called.
		/// </term>
		/// </item>
		/// <item>
		/// <term>Any of the ID2D1Bitmap::Copy* methods are called with a WIC bitmap as either the source or destination.</term>
		/// </item>
		/// </list>
		/// <para>IWICBitmap objects will be unlocked in the following circumstances:</para>
		/// <list type="bullet">
		/// <item>
		/// <term>EndDraw is called and the currently selected target bitmap is a WIC bitmap.</term>
		/// </item>
		/// <item>
		/// <term>A WIC bitmap is removed as the target of a device context between the calls to BeginDraw and EndDraw.</term>
		/// </item>
		/// <item>
		/// <term>Any of the ID2D1Bitmap::Copy* methods are called with a WIC bitmap as either the source or destination.</term>
		/// </item>
		/// </list>
		/// <para>Direct2D will only lock bitmaps that are not currently locked.</para>
		/// <para>
		/// Calling QueryInterface for ID2D1GdiInteropRenderTarget will always succeed. ID2D1GdiInteropRenderTarget::GetDC will return a
		/// device context corresponding to the currently bound target bitmap. GetDC will fail if the target bitmap was not created with
		/// the GDI_COMPATIBLE flag set.
		/// </para>
		/// <para>
		/// ID2D1HwndRenderTarget::Resize will return <c>DXGI_ERROR_INVALID_CALL</c> if there are any outstanding references to the
		/// original target bitmap associated with the render target.
		/// </para>
		/// <para>
		/// Although the target can be a command list, it cannot be any other type of image. It cannot be the output image of an effect.
		/// </para>
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows/win32/api/d2d1_1/nf-d2d1_1-id2d1devicecontext-gettarget void GetTarget( ID2D1Image
		// **image );
		[PreserveSig]
		void GetTarget(out ID2D1Image? image);

		/// <summary>Sets the rendering controls for the given device context.</summary>
		/// <param name="renderingControls">
		/// <para>Type: <c>const D2D1_RENDERING_CONTROLS*</c></para>
		/// <para>The rendering controls to be applied.</para>
		/// </param>
		/// <returns>None</returns>
		/// <remarks>
		/// The rendering controls allow the application to tune the precision, performance, and resource usage of rendering operations.
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows/win32/api/d2d1_1/nf-d2d1_1-id2d1devicecontext-setrenderingcontrols(constd2d1_rendering_controls_)
		// void SetRenderingControls( const D2D1_RENDERING_CONTROLS &amp; renderingControls );
		[PreserveSig]
		void SetRenderingControls(in D2D1_RENDERING_CONTROLS renderingControls);

		/// <summary>Gets the rendering controls that have been applied to the context.</summary>
		/// <param name="renderingControls">
		/// <para>Type: <c>D2D1_RENDERING_CONTROLS*</c></para>
		/// <para>When this method returns, contains a pointer to the rendering controls for this context.</para>
		/// </param>
		/// <returns>None</returns>
		// https://docs.microsoft.com/en-us/windows/win32/api/d2d1_1/nf-d2d1_1-id2d1devicecontext-getrenderingcontrols void
		// GetRenderingControls( D2D1_RENDERING_CONTROLS *renderingControls );
		[PreserveSig]
		void GetRenderingControls(out D2D1_RENDERING_CONTROLS renderingControls);

		/// <summary>Changes the primitive blend mode that is used for all rendering operations in the device context.</summary>
		/// <param name="primitiveBlend">
		/// <para>Type: <c>D2D1_PRIMITIVE_BLEND</c></para>
		/// <para>The primitive blend to use.</para>
		/// </param>
		/// <returns>None</returns>
		/// <remarks>
		/// <para>
		/// The primitive blend will apply to all of the primitive drawn on the context, unless this is overridden with the
		/// compositeMode parameter on the DrawImage API.
		/// </para>
		/// <para>
		/// The primitive blend applies to the interior of any primitives drawn on the context. In the case of DrawImage, this will be
		/// implied by the image rectangle, offset and world transform.
		/// </para>
		/// <para>
		/// If the primitive blend is anything other than <c>D2D1_PRIMITIVE_BLEND_SOURCE_OVER</c> then ClearType rendering will be
		/// turned off. If the application explicitly forces ClearType rendering in these modes, the drawing context will be placed in
		/// an error state. D2DERR_WRONG_STATE will be returned from either EndDraw or Flush.
		/// </para>
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows/win32/api/d2d1_1/nf-d2d1_1-id2d1devicecontext-setprimitiveblend void
		// SetPrimitiveBlend( D2D1_PRIMITIVE_BLEND primitiveBlend );
		[PreserveSig]
		void SetPrimitiveBlend(D2D1_PRIMITIVE_BLEND primitiveBlend);

		/// <summary>Returns the currently set primitive blend used by the device context.</summary>
		/// <returns>
		/// <para>Type: <c>D2D1_PRIMITIVE_BLEND</c></para>
		/// <para>The current primitive blend. The default value is <c>D2D1_PRIMITIVE_BLEND_SOURCE_OVER</c>.</para>
		/// </returns>
		// https://docs.microsoft.com/en-us/windows/win32/api/d2d1_1/nf-d2d1_1-id2d1devicecontext-getprimitiveblend D2D1_PRIMITIVE_BLEND GetPrimitiveBlend();
		[PreserveSig]
		D2D1_PRIMITIVE_BLEND GetPrimitiveBlend();

		/// <summary>Sets what units will be used to interpret values passed into the device context.</summary>
		/// <param name="unitMode">
		/// <para>Type: <c>D2D1_UNIT_MODE</c></para>
		/// <para>An enumeration defining how passed-in units will be interpreted by the device context.</para>
		/// </param>
		/// <returns>None</returns>
		/// <remarks>
		/// <para>
		/// This method will affect all properties and parameters affected by SetDpi and GetDpi. This affects all coordinates, lengths,
		/// and other properties that are not explicitly defined as being in another unit. For example:
		/// </para>
		/// <list type="bullet">
		/// <item>
		/// <term>
		/// <c>SetUnitMode</c> will affect a coordinate passed into ID2D1DeviceContext::DrawLine, and the scaling of a geometry passed
		/// into ID2D1DeviceContext::FillGeometry.
		/// </term>
		/// </item>
		/// <item>
		/// <term><c>SetUnitMode</c> will not affect the value returned by ID2D1Bitmap::GetPixelSize.</term>
		/// </item>
		/// </list>
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows/win32/api/d2d1_1/nf-d2d1_1-id2d1devicecontext-setunitmode void SetUnitMode(
		// D2D1_UNIT_MODE unitMode );
		[PreserveSig]
		void SetUnitMode(D2D1_UNIT_MODE unitMode);

		/// <summary>Gets the mode that is being used to interpret values by the device context.</summary>
		/// <returns>
		/// <para>Type: <c>D2D1_UNIT_MODE</c></para>
		/// <para>The unit mode.</para>
		/// </returns>
		// https://docs.microsoft.com/en-us/windows/win32/api/d2d1_1/nf-d2d1_1-id2d1devicecontext-getunitmode D2D1_UNIT_MODE GetUnitMode();
		[PreserveSig]
		D2D1_UNIT_MODE GetUnitMode();

		/// <summary>Draws a series of glyphs to the device context.</summary>
		/// <param name="baselineOrigin">
		/// <para>Type: <c>D2D1_POINT_2F</c></para>
		/// <para>Origin of first glyph in the series.</para>
		/// </param>
		/// <param name="glyphRun">
		/// <para>Type: <c>const DWRITE_GLYPH_RUN*</c></para>
		/// <para>The glyphs to render.</para>
		/// </param>
		/// <param name="glyphRunDescription">
		/// <para>Type: <c>const DWRITE_GLYPH_RUN_DESCRIPTION*</c></para>
		/// <para>Supplementary glyph series information.</para>
		/// </param>
		/// <param name="foregroundBrush">
		/// <para>Type: <c>ID2D1Brush*</c></para>
		/// <para>The brush that defines the text color.</para>
		/// </param>
		/// <param name="measuringMode">
		/// <para>Type: <c>DWRITE_MEASURING_MODE</c></para>
		/// <para>The measuring mode of the glyph series, used to determine the advances and offsets. The default value is DWRITE_MEASURING_MODE_NATURAL.</para>
		/// </param>
		/// <returns>None</returns>
		/// <remarks>
		/// The glyphRunDescription is ignored when rendering, but can be useful for printing and serialization of rendering commands,
		/// such as to an XPS or SVG file. This extends ID2D1RenderTarget::DrawGlyphRun, which lacked the glyph run description.
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows/win32/api/d2d1_1/nf-d2d1_1-id2d1devicecontext-drawglyphrun void DrawGlyphRun(
		// D2D1_POINT_2F baselineOrigin, const DWRITE_GLYPH_RUN *glyphRun, const DWRITE_GLYPH_RUN_DESCRIPTION *glyphRunDescription,
		// ID2D1Brush *foregroundBrush, DWRITE_MEASURING_MODE measuringMode );
		[PreserveSig]
		void DrawGlyphRun(D2D_POINT_2F baselineOrigin, in DWRITE_GLYPH_RUN glyphRun, [In, Optional] IntPtr glyphRunDescription, ID2D1Brush foregroundBrush, DWRITE_MEASURING_MODE measuringMode);

		/// <summary>Draws an image to the device context.</summary>
		/// <param name="image">
		/// <para>Type: <c>ID2D1Image*</c></para>
		/// <para>The image to be drawn to the device context.</para>
		/// </param>
		/// <param name="targetOffset">
		/// <para>Type: <c>const D2D1_POINT_2F*</c></para>
		/// <para>
		/// The offset in the destination space that the image will be rendered to. The entire logical extent of the image will be
		/// rendered to the corresponding destination. If not specified, the destination origin will be (0, 0). The top-left corner of
		/// the image will be mapped to the target offset. This will not necessarily be the origin. This default value is NULL.
		/// </para>
		/// </param>
		/// <param name="imageRectangle">
		/// <para>Type: <c>const D2D1_RECT_F*</c></para>
		/// <para>
		/// The corresponding rectangle in the image space will be mapped to the given origins when processing the image. This default
		/// value is NULL.
		/// </para>
		/// </param>
		/// <param name="interpolationMode">
		/// <para>Type: <c>D2D1_INTERPOLATION_MODE</c></para>
		/// <para>The interpolation mode that will be used to scale the image if necessary.</para>
		/// </param>
		/// <param name="compositeMode">
		/// <para>Type: <c>D2D1_COMPOSITE_MODE</c></para>
		/// <para>The composite mode that will be applied to the limits of the currently selected clip. The default value is <c>D2D1_COMPOSITE_MODE_SOURCE_OVER</c></para>
		/// </param>
		/// <returns>None</returns>
		/// <remarks>
		/// <para>
		/// If interpolationMode is <c>D2D1_INTERPOLATION_MODE_HIGH_QUALITY</c>, different scalers will be used depending on the scale
		/// factor implied by the world transform.
		/// </para>
		/// <para>
		/// Any invalid rectangles accumulated on any effect that is drawn by this call will be discarded regardless of which portion of
		/// the image rectangle is drawn.
		/// </para>
		/// <para>
		/// If compositeMode is <c>D2D1_COMPOSITE_MODE_SOURCE_OVER</c>, DrawImage will use the currently selected primitive blend
		/// specified by ID2D1DeviceContext::SetPrimitiveBlend. If compositeMode is not <c>D2D1_COMPOSITE_MODE_SOURCE_OVER</c>, the
		/// image will be extended to transparent up to the current axis-aligned clip.
		/// </para>
		/// <para>
		/// If there is an image rectangle and a world transform, this is equivalent to inserting a clip effect to represent the image
		/// rectangle and a 2D affine transform to take into account the world transform.
		/// </para>
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows/win32/api/d2d1_1/nf-d2d1_1-id2d1devicecontext-drawimage(id2d1effect_constd2d1_point_2f_constd2d1_rect_f_d2d1_interpolation_mode_d2d1_composite_mode)
		// void DrawImage( ID2D1Effect *effect, const D2D1_POINT_2F *targetOffset, const D2D1_RECT_F *imageRectangle,
		// D2D1_INTERPOLATION_MODE interpolationMode, D2D1_COMPOSITE_MODE compositeMode );
		[PreserveSig]
		void DrawImage(ID2D1Image image, [In, Optional] IntPtr targetOffset, [In, Optional] IntPtr imageRectangle, D2D1_INTERPOLATION_MODE interpolationMode, D2D1_COMPOSITE_MODE compositeMode);

		/// <summary>Draw a metafile to the device context.</summary>
		/// <param name="gdiMetafile">
		/// <para>Type: <c>ID2D1GdiMetafile*</c></para>
		/// <para>The metafile to draw.</para>
		/// </param>
		/// <param name="targetOffset">
		/// <para>Type: <c>const D2D1_POINT_2F*</c></para>
		/// <para>The offset from the upper left corner of the render target.</para>
		/// </param>
		/// <returns>None</returns>
		// https://docs.microsoft.com/en-us/windows/win32/api/d2d1_1/nf-d2d1_1-id2d1devicecontext-drawgdimetafile(id2d1gdimetafile_d2d1_point_2f)
		// void DrawGdiMetafile( ID2D1GdiMetafile *gdiMetafile, D2D1_POINT_2F targetOffset );
		[PreserveSig]
		void DrawGdiMetafile(ID2D1GdiMetafile gdiMetafile, [In, Optional] IntPtr targetOffset);

		/// <summary>Draws a bitmap to the render target.</summary>
		/// <param name="bitmap">
		/// <para>Type: <c>ID2D1Bitmap*</c></para>
		/// <para>The bitmap to draw.</para>
		/// </param>
		/// <param name="destinationRectangle">
		/// <para>Type: <c>D2D1_RECT_F*</c></para>
		/// <para>
		/// The destination rectangle. The default is the size of the bitmap and the location is the upper left corner of the render target.
		/// </para>
		/// </param>
		/// <param name="opacity">
		/// <para>Type: <c>FLOAT</c></para>
		/// <para>The opacity of the bitmap.</para>
		/// </param>
		/// <param name="interpolationMode">
		/// <para>Type: <c>D2D1_INTERPOLATION_MODE</c></para>
		/// <para>The interpolation mode to use.</para>
		/// </param>
		/// <param name="sourceRectangle">
		/// <para>Type: <c>const D2D1_RECT_F</c></para>
		/// <para>An optional source rectangle.</para>
		/// </param>
		/// <param name="perspectiveTransform">
		/// <para>Type: <c>const D2D1_MATRIX_4X4_F</c></para>
		/// <para>An optional perspective transform.</para>
		/// </param>
		/// <returns>None</returns>
		/// <remarks>
		/// <para>
		/// The destinationRectangle parameter defines the rectangle in the target where the bitmap will appear (in device-independent
		/// pixels (DIPs)). This is affected by the currently set transform and the perspective transform, if set. If NULL is specified,
		/// then the destination rectangle is (left=0, top=0, right = width(sourceRectangle), bottom = height(sourceRectangle)).
		/// </para>
		/// <para>
		/// The sourceRectangle parameter defines the sub-rectangle of the source bitmap (in DIPs). <c>DrawBitmap</c> will clip this
		/// rectangle to the size of the source bitmap, thus making it impossible to sample outside of the bitmap. If NULL is specified,
		/// then the source rectangle is taken to be the size of the source bitmap.
		/// </para>
		/// <para>If you specify perspectiveTransform it is applied to the rect in addition to the transform set on the render target.</para>
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows/win32/api/d2d1_1/nf-d2d1_1-id2d1devicecontext-drawbitmap(id2d1bitmap_constd2d1_rect_f__float_d2d1_interpolation_mode_constd2d1_rect_f_constd2d1_matrix_4x4_f)
		// void DrawBitmap( ID2D1Bitmap *bitmap, const D2D1_RECT_F &amp; destinationRectangle, FLOAT opacity, D2D1_INTERPOLATION_MODE
		// interpolationMode, const D2D1_RECT_F *sourceRectangle, const D2D1_MATRIX_4X4_F *perspectiveTransform );
		[PreserveSig]
		void DrawBitmap(ID2D1Bitmap bitmap, [In, Optional] IntPtr destinationRectangle, float opacity, D2D1_INTERPOLATION_MODE interpolationMode, [In, Optional] IntPtr sourceRectangle, [In, Optional] IntPtr perspectiveTransform);

		/// <summary>Push a layer onto the clip and layer stack of the device context.</summary>
		/// <param name="layerParameters">
		/// <para>Type: <c>const D2D1_LAYER_PARAMETERS1*</c></para>
		/// <para>The parameters that defines the layer.</para>
		/// </param>
		/// <param name="layer">
		/// <para>Type: <c>ID2D1Layer*</c></para>
		/// <para>The layer resource to push on the device context that receives subsequent drawing operations.</para>
		/// <para><c>Note</c> If a layer is not specified, Direct2D manages the layer resource automatically.</para>
		/// </param>
		/// <returns>None</returns>
		// https://docs.microsoft.com/en-us/windows/win32/api/d2d1_1/nf-d2d1_1-id2d1devicecontext-pushlayer(constd2d1_layer_parameters1__id2d1layer)
		// void PushLayer( const D2D1_LAYER_PARAMETERS1 &amp; layerParameters, ID2D1Layer *layer );
		[PreserveSig]
		void PushLayer(in D2D1_LAYER_PARAMETERS1 layerParameters, [In, Optional] ID2D1Layer? layer);

		/// <summary>
		/// <para>This indicates that a portion of an effect's input is invalid. This method can be called many times.</para>
		/// <para>
		/// You can use this method to propagate invalid rectangles through an effect graph. You can query Direct2D using the
		/// GetEffectInvalidRectangles method.
		/// </para>
		/// <para>
		/// <c>Note</c> Direct2D does not automatically use these invalid rectangles to reduce the region of an effect that is rendered.
		/// </para>
		/// <para>
		/// You can also use this method to invalidate caches that have accumulated while rendering effects that have the
		/// <c>D2D1_PROPERTY_CACHED</c> property set to true.
		/// </para>
		/// </summary>
		/// <param name="effect">
		/// <para>Type: <c>ID2D1Effect*</c></para>
		/// <para>The effect to invalidate.</para>
		/// </param>
		/// <param name="input">
		/// <para>Type: <c>UINT32</c></para>
		/// <para>The input index.</para>
		/// </param>
		/// <param name="inputRectangle">
		/// <para>Type: <c>const D2D1_RECT_F*</c></para>
		/// <para>The rect to invalidate.</para>
		/// </param>
		// https://docs.microsoft.com/en-us/windows/win32/api/d2d1_1/nf-d2d1_1-id2d1devicecontext-invalidateeffectinputrectangle HRESULT
		// InvalidateEffectInputRectangle( ID2D1Effect *effect, UINT32 input, const D2D1_RECT_F *inputRectangle );
		void InvalidateEffectInputRectangle(ID2D1Effect effect, uint input, in D2D_RECT_F inputRectangle);

		/// <summary>Gets the number of invalid output rectangles that have accumulated on the effect.</summary>
		/// <param name="effect">
		/// <para>Type: <c>ID2D1Effect*</c></para>
		/// <para>The effect to count the invalid rectangles on.</para>
		/// </param>
		/// <returns>
		/// <para>Type: <c>UINT32*</c></para>
		/// <para>The returned rectangle count.</para>
		/// </returns>
		// https://docs.microsoft.com/en-us/windows/win32/api/d2d1_1/nf-d2d1_1-id2d1devicecontext-geteffectinvalidrectanglecount HRESULT
		// GetEffectInvalidRectangleCount( ID2D1Effect *effect, UINT32 *rectangleCount );
		uint GetEffectInvalidRectangleCount(ID2D1Effect effect);

		/// <summary>
		/// Gets the invalid rectangles that have accumulated since the last time the effect was drawn and EndDraw was then called on
		/// the device context.
		/// </summary>
		/// <param name="effect">
		/// <para>Type: <c>ID2D1Effect*</c></para>
		/// <para>The effect to get the invalid rectangles from.</para>
		/// </param>
		/// <param name="rectangles">
		/// <para>Type: <c>D2D1_RECT_F*</c></para>
		/// <para>
		/// An array of D2D1_RECT_F structures. You must allocate this to the correct size. You can get the count of the invalid
		/// rectangles using the GetEffectInvalidRectangleCount method.
		/// </para>
		/// </param>
		/// <param name="rectanglesCount">
		/// <para>Type: <c>UINT32</c></para>
		/// <para>The number of rectangles to get.</para>
		/// </param>
		/// <remarks>
		/// <para>
		/// <c>Note</c> Direct2D does not automatically use these invalid rectangles to reduce the region of an effect that is rendered.
		/// </para>
		/// <para>
		/// You can use the InvalidateEffectInputRectangle method to specify invalidated rectangles for Direct2D to propagate through an
		/// effect graph.
		/// </para>
		/// <para>
		/// If multiple invalid rectangles are requested, the rectangles that this method returns may overlap. When this is the case,
		/// the rectangle count might be lower than the count that GetEffectInvalidRectangleCount.
		/// </para>
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows/win32/api/d2d1_1/nf-d2d1_1-id2d1devicecontext-geteffectinvalidrectangles HRESULT
		// GetEffectInvalidRectangles( ID2D1Effect *effect, D2D1_RECT_F *rectangles, UINT32 rectanglesCount );
		void GetEffectInvalidRectangles(ID2D1Effect effect, [Out, MarshalAs(UnmanagedType.LPArray, SizeParamIndex = 2)] D2D_RECT_F[] rectangles, int rectanglesCount);

		/// <summary>Returns the input rectangles that are required to be supplied by the caller to produce the given output rectangle.</summary>
		/// <param name="renderEffect">
		/// <para>Type: <c>ID2D1Effect*</c></para>
		/// <para>The image whose output is being rendered.</para>
		/// </param>
		/// <param name="renderImageRectangle">
		/// <para>Type: <c>const D2D1_RECT_F*</c></para>
		/// <para>The portion of the output image whose inputs are being inspected.</para>
		/// </param>
		/// <param name="inputDescriptions">
		/// <para>Type: <c>const D2D1_EFFECT_INPUT_DESCRIPTION*</c></para>
		/// <para>A list of the inputs whos rectangles are being queried.</para>
		/// </param>
		/// <param name="requiredInputRects">
		/// <para>Type: <c>D2D1_RECT_F*</c></para>
		/// <para>The input rectangles returned to the caller.</para>
		/// </param>
		/// <param name="inputCount">
		/// <para>Type: <c>UINT32</c></para>
		/// <para>The number of inputs.</para>
		/// </param>
		/// <remarks>
		/// The caller should be very careful not to place a reliance on the required input rectangles returned. Small changes for
		/// correctness to an effect's behavior can result in different rectangles being returned. In addition, different kinds of
		/// optimization applied inside the render can also influence the result.
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows/win32/api/d2d1_1/nf-d2d1_1-id2d1devicecontext-geteffectrequiredinputrectangles
		// HRESULT GetEffectRequiredInputRectangles( ID2D1Effect *renderEffect, const D2D1_RECT_F *renderImageRectangle, const
		// D2D1_EFFECT_INPUT_DESCRIPTION *inputDescriptions, D2D1_RECT_F *requiredInputRects, UINT32 inputCount );
		void GetEffectRequiredInputRectangles(ID2D1Effect renderEffect, [In, Optional] IntPtr renderImageRectangle,
			[In, MarshalAs(UnmanagedType.LPArray, SizeParamIndex = 4)] D2D1_EFFECT_INPUT_DESCRIPTION[] inputDescriptions,
			[Out, MarshalAs(UnmanagedType.LPArray, SizeParamIndex = 4)] D2D_RECT_F[] requiredInputRects, int inputCount);

		/// <summary>
		/// Fill using the alpha channel of the supplied opacity mask bitmap. The brush opacity will be modulated by the mask. The
		/// render target antialiasing mode must be set to aliased.
		/// </summary>
		/// <param name="opacityMask">
		/// <para>Type: <c>ID2D1Bitmap*</c></para>
		/// <para>The bitmap that acts as the opacity mask</para>
		/// </param>
		/// <param name="brush">
		/// <para>Type: <c>ID2D1Brush*</c></para>
		/// <para>The brush to use for filling the primitive.</para>
		/// </param>
		/// <param name="destinationRectangle">
		/// <para>Type: <c>const D2D1_RECT_F</c></para>
		/// <para>The destination rectangle to output to in the render target</para>
		/// </param>
		/// <param name="sourceRectangle">
		/// <para>Type: <c>const D2D1_RECT_F</c></para>
		/// <para>The source rectangle from the opacity mask bitmap.</para>
		/// </param>
		/// <returns>None</returns>
		// https://docs.microsoft.com/en-us/windows/win32/api/d2d1_1/nf-d2d1_1-id2d1devicecontext-fillopacitymask(id2d1bitmap_id2d1brush_constd2d1_rect_f__constd2d1_rect_f_)
		// void FillOpacityMask( ID2D1Bitmap *opacityMask, ID2D1Brush *brush, const D2D1_RECT_F &amp; destinationRectangle, const
		// D2D1_RECT_F &amp; sourceRectangle );
		[PreserveSig]
		void FillOpacityMask(ID2D1Bitmap opacityMask, ID2D1Brush brush, [In, Optional] IntPtr destinationRectangle, [In, Optional] IntPtr sourceRectangle);
	}

	/// <summary>Represents a basic image-processing construct in Direct2D.</summary>
	/// <remarks>
	/// An effect takes zero or more input images, and has an output image. The images that are input into and output from an effect are
	/// lazily evaluated. This definition is sufficient to allow an arbitrary graph of effects to be created from the application by
	/// feeding output images into the input image of the next effect in the chain.
	/// </remarks>
	// https://docs.microsoft.com/en-us/windows/win32/api/d2d1_1/nn-d2d1_1-id2d1effect
	[PInvokeData("d2d1_1.h", MSDNShortId = "e90d1830-c356-48f1-ac7b-1d94c8c26569")]
	[ComImport, Guid("28211a43-7d89-476f-8181-2d6159b220ad"), InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
	public interface ID2D1Effect : ID2D1Properties
	{
		/// <summary>Gets the number of top-level properties.</summary>
		/// <returns>
		/// <para>Type: <c>UINT32</c></para>
		/// <para>This method returns the number of custom (non-system) properties that can be accessed by the object.</para>
		/// </returns>
		/// <remarks>
		/// This method returns the number of custom properties on the ID2D1Properties interface. System properties and sub-properties
		/// are part of a closed set, and are enumerable by iterating over this closed set.
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows/win32/api/d2d1_1/nf-d2d1_1-id2d1properties-getpropertycount UINT32 GetPropertyCount();
		[PreserveSig]
		new uint GetPropertyCount();

		/// <summary>Gets the property name that corresponds to the given index.</summary>
		/// <param name="index">
		/// <para>Type: <c>UINT32</c></para>
		/// <para>The index of the property for which the name is being returned.</para>
		/// </param>
		/// <param name="name">
		/// <para>Type: <c>PWSTR</c></para>
		/// <para>When this method returns, contains the name being retrieved.</para>
		/// </param>
		/// <param name="nameCount">
		/// <para>Type: <c>UINT32</c></para>
		/// <para>The number of characters in the name buffer.</para>
		/// </param>
		/// <remarks>
		/// This method returns an empty string if index is invalid. If the method returns
		/// <c>RESULT_FROM_WIN32(ERROR_INSUFFICIENT_BUFFER)</c>, name will still be filled and truncated.
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows/win32/api/d2d1_1/nf-d2d1_1-id2d1properties-getpropertyname(uint32_pwstr_uint32)
		// HRESULT GetPropertyName( UINT32 index, PWSTR name, UINT32 nameCount );
		new void GetPropertyName(uint index, [MarshalAs(UnmanagedType.LPWStr)] StringBuilder name, uint nameCount);

		/// <summary>Gets the number of characters for the given property name. This is a template overload. See Remarks.</summary>
		/// <param name="index">
		/// <para>Type: <c>U</c></para>
		/// <para>The index of the property name to retrieve.</para>
		/// </param>
		/// <returns>
		/// <para>Type: <c>UINT32</c></para>
		/// <para>
		/// This method returns the size in characters of the name corresponding to the given property index, or zero if the property
		/// index does not exist.
		/// </para>
		/// </returns>
		/// <remarks>
		/// <para>The value returned by this method can be used to ensure that the buffer size for GetPropertyName is appropriate.</para>
		/// <para>template&lt;typename U&gt; UINT32 GetPropertyNameLength( U index ) CONST;</para>
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows/win32/api/d2d1_1/nf-d2d1_1-id2d1properties-getpropertynamelength%28u%29 UINT32
		// GetPropertyNameLength( U index );
		[PreserveSig]
		new uint GetPropertyNameLength(uint index);

		/// <summary>Gets the D2D1_PROPERTY_TYPE of the selected property.</summary>
		/// <param name="index">
		/// <para>Type: <c>UINT32</c></para>
		/// <para>The index of the property for which the type will be retrieved.</para>
		/// </param>
		/// <returns>
		/// <para>Type: <c>D2D1_PROPERTY_TYPE</c></para>
		/// <para>This method returns a D2D1_PROPERTY_TYPE-typed value for the type of the selected property.</para>
		/// </returns>
		/// <remarks>If the property does not exist, the method returns D2D1_PROPERTY_TYPE_UNKNOWN.</remarks>
		// https://docs.microsoft.com/en-us/windows/win32/api/d2d1_1/nf-d2d1_1-id2d1properties-gettype%28uint32%29 D2D1_PROPERTY_TYPE
		// GetType( UINT32 index );
		[PreserveSig]
		new D2D1_PROPERTY_TYPE GetType(uint index);

		/// <summary>Gets the index corresponding to the given property name.</summary>
		/// <param name="name">
		/// <para>Type: <c>PCWSTR</c></para>
		/// <para>The name of the property to retrieve.</para>
		/// </param>
		/// <returns>
		/// <para>Type: <c>UINT32</c></para>
		/// <para>The index of the corresponding property name.</para>
		/// </returns>
		/// <remarks>
		/// If the property doesn't exist, then this method returns D2D1_INVALID_PROPERTY_INDEX. This reserved value will never map to a
		/// valid index, and will cause <c>NULL</c> or sentinel values to be returned from other parts of the property interface.
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows/win32/api/d2d1_1/nf-d2d1_1-id2d1properties-getpropertyindex UINT32 GetPropertyIndex(
		// PCWSTR name );
		[PreserveSig]
		new uint GetPropertyIndex([MarshalAs(UnmanagedType.LPWStr)] string name);

		/// <summary>Sets the named property to the given value.</summary>
		/// <param name="name">
		/// <para>Type: <c>PCWSTR</c></para>
		/// <para>The name of the property to set.</para>
		/// </param>
		/// <param name="type">TBD</param>
		/// <param name="data">
		/// <para>Type: <c>const BYTE*</c></para>
		/// <para>The data to set.</para>
		/// </param>
		/// <param name="dataSize">
		/// <para>Type: <c>UINT32</c></para>
		/// <para>The number of bytes in the data to set.</para>
		/// </param>
		/// <remarks>
		/// <para>If the property does not exist, the request is ignored and the method returns <c>D2DERR_INVALID_PROPERTY</c>.</para>
		/// <para>Any error not in the standard set returned by a property implementation will be mapped into the standard error range.</para>
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows/win32/api/d2d1_1/nf-d2d1_1-id2d1properties-setvaluebyname%28pcwstr_d2d1_property_type_constbyte_uint32%29
		// HRESULT SetValueByName( PCWSTR name, D2D1_PROPERTY_TYPE type, const BYTE *data, UINT32 dataSize );
		new void SetValueByName([MarshalAs(UnmanagedType.LPWStr)] string name, D2D1_PROPERTY_TYPE type, [In] IntPtr data, uint dataSize);

		/// <summary>Sets the corresponding property by index.</summary>
		/// <param name="index">
		/// <para>Type: <c>UINT32</c></para>
		/// <para>The index of the property to set.</para>
		/// </param>
		/// <param name="type">TBD</param>
		/// <param name="data">
		/// <para>Type: <c>const BYTE*</c></para>
		/// <para>The data to set.</para>
		/// </param>
		/// <param name="dataSize">
		/// <para>Type: <c>UINT32</c></para>
		/// <para>The number of bytes in the data to set.</para>
		/// </param>
		/// <returns>
		/// <para>Type: <c>HRESULT</c></para>
		/// <para>The method returns an <c>HRESULT</c>. Possible values include, but are not limited to, those in the following table.</para>
		/// <list type="table">
		/// <listheader>
		/// <term>HRESULT</term>
		/// <term>Description</term>
		/// </listheader>
		/// <item>
		/// <term>S_OK</term>
		/// <term>No error occurred.</term>
		/// </item>
		/// <item>
		/// <term>D2DERR_INVALID_PROPERTY</term>
		/// <term>The specified property does not exist.</term>
		/// </item>
		/// <item>
		/// <term>E_OUTOFMEMORY</term>
		/// <term>Failed to allocate necessary memory.</term>
		/// </item>
		/// <item>
		/// <term>D3DERR_OUT_OF_VIDEO_MEMORY</term>
		/// <term>Failed to allocate required video memory.</term>
		/// </item>
		/// <item>
		/// <term>E_INVALIDARG</term>
		/// <term>One or more arguments are invalid.</term>
		/// </item>
		/// <item>
		/// <term>E_FAIL</term>
		/// <term>Unspecified failure.</term>
		/// </item>
		/// </list>
		/// </returns>
		/// <remarks>
		/// <para>If the property does not exist, the request is ignored and <c>D2DERR_INVALID_PROPERTY</c> is returned.</para>
		/// <para>Any error not in the standard set returned by a property implementation will be mapped into the standard error range.</para>
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows/win32/api/d2d1_1/nf-d2d1_1-id2d1properties-setvalue(uint32_d2d1_property_type_constbyte_uint32)
		// HRESULT SetValue( UINT32 index, D2D1_PROPERTY_TYPE type, const BYTE *data, UINT32 dataSize );
		new void SetValue(uint index, D2D1_PROPERTY_TYPE type, [In] IntPtr data, uint dataSize);

		/// <summary>Gets the property value by name.</summary>
		/// <param name="name">
		/// <para>Type: <c>PCWSTR</c></para>
		/// <para>The property name to get.</para>
		/// </param>
		/// <param name="type">TBD</param>
		/// <param name="data">
		/// <para>Type: <c>BYTE*</c></para>
		/// <para>When this method returns, contains the buffer with the data value.</para>
		/// </param>
		/// <param name="dataSize">
		/// <para>Type: <c>UINT32</c></para>
		/// <para>The number of bytes in the data to be retrieved.</para>
		/// </param>
		/// <returns>
		/// <para>Type: <c>HRESULT</c></para>
		/// <para>The method returns an <c>HRESULT</c>. Possible values include, but are not limited to, those in the following table.</para>
		/// <list type="table">
		/// <listheader>
		/// <term>HRESULT</term>
		/// <term>Description</term>
		/// </listheader>
		/// <item>
		/// <term>S_OK</term>
		/// <term>No error occurred.</term>
		/// </item>
		/// <item>
		/// <term>D2DERR_INVALID_PROPERTY</term>
		/// <term>The specified property does not exist.</term>
		/// </item>
		/// <item>
		/// <term>E_OUTOFMEMORY</term>
		/// <term>Failed to allocate necessary memory.</term>
		/// </item>
		/// <item>
		/// <term>D3DERR_OUT_OF_VIDEO_MEMORY</term>
		/// <term>Failed to allocate required video memory.</term>
		/// </item>
		/// <item>
		/// <term>E_INVALIDARG</term>
		/// <term>One or more arguments are invalid.</term>
		/// </item>
		/// <item>
		/// <term>E_FAIL</term>
		/// <term>Unspecified failure.</term>
		/// </item>
		/// </list>
		/// </returns>
		/// <remarks>
		/// <para>If name does not exist, no information is retrieved.</para>
		/// <para>Any error not in the standard set returned by a property implementation will be mapped into the standard error range.</para>
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows/win32/api/d2d1_1/nf-d2d1_1-id2d1properties-getvaluebyname(pcwstr_d2d1_property_type_byte_uint32)
		// HRESULT GetValueByName( PCWSTR name, D2D1_PROPERTY_TYPE type, BYTE *data, UINT32 dataSize );
		new void GetValueByName([MarshalAs(UnmanagedType.LPWStr)] string name, D2D1_PROPERTY_TYPE type, [Out] IntPtr data, uint dataSize);

		/// <summary>Gets the value of the specified property by index.</summary>
		/// <param name="index">
		/// <para>Type: <c>UINT32</c></para>
		/// <para>The index of the property from which the data is to be obtained.</para>
		/// </param>
		/// <param name="type">TBD</param>
		/// <param name="data">
		/// <para>Type: <c>BYTE*</c></para>
		/// <para>When this method returns, contains a pointer to the data requested.</para>
		/// </param>
		/// <param name="dataSize">
		/// <para>Type: <c>UINT32</c></para>
		/// <para>The number of bytes in the data to be retrieved.</para>
		/// </param>
		/// <returns>
		/// <para>Type: <c>HRESULT</c></para>
		/// <para>The method returns an <c>HRESULT</c>. Possible values include, but are not limited to, those in the following table.</para>
		/// <list type="table">
		/// <listheader>
		/// <term>HRESULT</term>
		/// <term>Description</term>
		/// </listheader>
		/// <item>
		/// <term>S_OK</term>
		/// <term>No error occurred.</term>
		/// </item>
		/// <item>
		/// <term>D2DERR_INVALID_PROPERTY</term>
		/// <term>The specified property does not exist.</term>
		/// </item>
		/// <item>
		/// <term>E_OUTOFMEMORY</term>
		/// <term>Failed to allocate necessary memory.</term>
		/// </item>
		/// <item>
		/// <term>D3DERR_OUT_OF_VIDEO_MEMORY</term>
		/// <term>Failed to allocate required video memory.</term>
		/// </item>
		/// <item>
		/// <term>E_INVALIDARG</term>
		/// <term>One or more arguments are invalid.</term>
		/// </item>
		/// <item>
		/// <term>E_FAIL</term>
		/// <term>Unspecified failure.</term>
		/// </item>
		/// </list>
		/// </returns>
		// https://docs.microsoft.com/en-us/windows/win32/api/d2d1_1/nf-d2d1_1-id2d1properties-getvalue(uint32_d2d1_property_type_byte_uint32)
		// HRESULT GetValue( UINT32 index, D2D1_PROPERTY_TYPE type, BYTE *data, UINT32 dataSize );
		new void GetValue(uint index, D2D1_PROPERTY_TYPE type, [Out] IntPtr data, uint dataSize);

		/// <summary>Gets the size of the property value in bytes, using the property index. This is a template overload. See Remarks.</summary>
		/// <param name="index">
		/// <para>Type: <c>U</c></para>
		/// <para>The index of the property.</para>
		/// </param>
		/// <returns>
		/// <para>Type: <c>UINT32</c></para>
		/// <para>This method returns size of the value in bytes, using the property index</para>
		/// </returns>
		/// <remarks>
		/// <para>This method returns zero if index does not exist.</para>
		/// <para>template&lt;typename U&gt; UINT32 GetValueSize( U index ) CONST;</para>
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows/win32/api/d2d1_1/nf-d2d1_1-id2d1properties-getvaluesize%28u%29 UINT32 GetValueSize(
		// U index );
		[PreserveSig]
		new uint GetValueSize(uint index);

		/// <summary>Gets the sub-properties of the provided property by index.</summary>
		/// <param name="index">
		/// <para>Type: <c>UINT32</c></para>
		/// <para>The index of the sub-properties to be retrieved.</para>
		/// </param>
		/// <returns>
		/// <para>Type: <c>ID2D1Properties**</c></para>
		/// <para>When this method returns, contains the address of a pointer to the sub-properties.</para>
		/// </returns>
		/// <remarks>
		/// If there are no sub-properties, subProperties will be <c>NULL</c>, and <c>D2DERR_NO_SUBPROPERTIES</c> will be returned.
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows/win32/api/d2d1_1/nf-d2d1_1-id2d1properties-getsubproperties%28uint32_id2d1properties%29
		// HRESULT GetSubProperties( UINT32 index, ID2D1Properties **subProperties );
		new ID2D1Properties GetSubProperties(uint index);

		/// <summary>Sets the given input image by index.</summary>
		/// <param name="index">
		/// <para>Type: <c>UINT32</c></para>
		/// <para>The index of the image to set.</para>
		/// </param>
		/// <param name="input">
		/// <para>Type: <c>ID2D1Image*</c></para>
		/// <para>The input image to set.</para>
		/// </param>
		/// <param name="invalidate">
		/// <para>Type: <c>BOOL</c></para>
		/// <para>Whether to invalidate the graph at the location of the effect input</para>
		/// </param>
		/// <returns>None</returns>
		/// <remarks>If the input index is out of range, the input image is ignored.</remarks>
		// https://docs.microsoft.com/en-us/windows/win32/api/d2d1_1/nf-d2d1_1-id2d1effect-setinput void SetInput( UINT32 index,
		// ID2D1Image *input, BOOL invalidate );
		[PreserveSig]
		void SetInput(uint index, [In, Optional] ID2D1Image? input, [MarshalAs(UnmanagedType.Bool)] bool invalidate = true);

		/// <summary>Allows the application to change the number of inputs to an effect.</summary>
		/// <param name="inputCount">
		/// <para>Type: <c>UINT32</c></para>
		/// <para>The number of inputs to the effect.</para>
		/// </param>
		/// <remarks>
		/// <para>
		/// Most effects do not support a variable number of inputs. Use ID2D1Properties::GetValue with the
		/// <c>D2D1_PROPERTY_MIN_INPUTS</c> and <c>D2D1_PROPERTY_MAX_INPUTS</c> values to determine the number of inputs supported by an effect.
		/// </para>
		/// <para>If the input count is less than the minimum or more than the maximum supported inputs, the call will fail.</para>
		/// <para>If the input count is unchanged, the call will succeed with <c>S_OK</c>.</para>
		/// <para>
		/// Any inputs currently selected on the effect will be unaltered by this call unless the number of inputs is made smaller. If
		/// the number of inputs is made smaller, inputs beyond the selected range will be released.
		/// </para>
		/// <para>If the method fails, the existing input and input count will remain unchanged.</para>
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows/win32/api/d2d1_1/nf-d2d1_1-id2d1effect-setinputcount HRESULT SetInputCount( UINT32
		// inputCount );
		void SetInputCount(uint inputCount);

		/// <summary>Gets the given input image by index.</summary>
		/// <param name="index">
		/// <para>Type: <c>UINT32</c></para>
		/// <para>The index of the image to retrieve.</para>
		/// </param>
		/// <param name="input">
		/// <para>Type: <c>ID2D1Image**</c></para>
		/// <para>When this method returns, contains the address of a pointer to the image that is identified by Index.</para>
		/// </param>
		/// <returns>None</returns>
		/// <remarks>If the input index is out of range, the returned image will be <c>NULL</c>.</remarks>
		// https://docs.microsoft.com/en-us/windows/win32/api/d2d1_1/nf-d2d1_1-id2d1effect-getinput void GetInput( UINT32 index,
		// ID2D1Image **input );
		[PreserveSig]
		void GetInput(uint index, out ID2D1Image input);

		/// <summary>Gets the number of inputs to the effect.</summary>
		/// <returns>
		/// <para>Type: <c>UINT32</c></para>
		/// <para>This method returns the number of inputs to the effect.</para>
		/// </returns>
		// https://docs.microsoft.com/en-us/windows/win32/api/d2d1_1/nf-d2d1_1-id2d1effect-getinputcount UINT32 GetInputCount();
		[PreserveSig]
		uint GetInputCount();

		/// <summary>Gets the output image from the effect.</summary>
		/// <param name="outputImage">
		/// <para>Type: <c>ID2D1Image**</c></para>
		/// <para>When this method returns, contains the address of a pointer to the output image for the effect.</para>
		/// </param>
		/// <returns>None</returns>
		/// <remarks>
		/// <para>
		/// The output image can be set as an input to another effect, or can be directly passed into the ID2D1DeviceContext in order to
		/// render the effect.
		/// </para>
		/// <para>It is also possible to use QueryInterface to retrieve the same output image.</para>
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows/win32/api/d2d1_1/nf-d2d1_1-id2d1effect-getoutput void GetOutput( ID2D1Image
		// **outputImage );
		[PreserveSig]
		void GetOutput(out ID2D1Image outputImage);
	}

	/// <summary>A Direct2D resource that wraps a WMF, EMF, or EMF+ metafile.</summary>
	// https://docs.microsoft.com/en-us/windows/win32/api/d2d1_1/nn-d2d1_1-id2d1gdimetafile
	[PInvokeData("d2d1_1.h", MSDNShortId = "36A454EC-7DE0-4610-B49C-7FBBD21C425C")]
	[ComImport, Guid("2f543dc3-cfc1-4211-864f-cfd91c6f3395"), InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
	public interface ID2D1GdiMetafile : ID2D1Resource
	{
		/// <summary>Retrieves the factory associated with this resource.</summary>
		/// <param name="factory">
		/// <para>Type: <c>ID2D1Factory**</c></para>
		/// <para>
		/// When this method returns, contains a pointer to a pointer to the factory that created this resource. This parameter is
		/// passed uninitialized.
		/// </para>
		/// </param>
		// https://docs.microsoft.com/en-us/windows/win32/api/d2d1/nf-d2d1-id2d1resource-getfactory void GetFactory( ID2D1Factory
		// **factory );
		[PreserveSig]
		new void GetFactory(out ID2D1Factory factory);

		/// <summary>This method streams the contents of the command to the given metafile sink.</summary>
		/// <param name="sink">
		/// <para>Type: <c>ID2D1GdiMetafileSink</c></para>
		/// <para>The sink into which Direct2D will call back.</para>
		/// </param>
		/// <returns>
		/// <para>Type: <c>HRESULT</c></para>
		/// <para>The method returns an <c>HRESULT</c>. Possible values include, but are not limited to, those in the following table.</para>
		/// <list type="table">
		/// <listheader>
		/// <term>HRESULT</term>
		/// <term>Description</term>
		/// </listheader>
		/// <item>
		/// <term>S_OK</term>
		/// <term>No error occurred.</term>
		/// </item>
		/// <item>
		/// <term>E_OUTOFMEMORY</term>
		/// <term>Direct2D could not allocate sufficient memory to complete the call.</term>
		/// </item>
		/// <item>
		/// <term>E_INVALIDARG</term>
		/// <term>An invalid value was passed to the method.</term>
		/// </item>
		/// </list>
		/// </returns>
		// https://docs.microsoft.com/en-us/windows/win32/api/d2d1_1/nf-d2d1_1-id2d1gdimetafile-stream HRESULT Stream(
		// ID2D1GdiMetafileSink *sink );
		void Stream([In] ID2D1GdiMetafileSink sink);

		/// <summary>Gets the bounds of the metafile, in device-independent pixels (DIPs), as reported in the metafile’s header.</summary>
		/// <returns>
		/// <para>Type: <c>D2D1_RECT_F*</c></para>
		/// <para>The bounds, in DIPs, of the metafile.</para>
		/// </returns>
		// https://docs.microsoft.com/en-us/windows/win32/api/d2d1_1/nf-d2d1_1-id2d1gdimetafile-getbounds HRESULT GetBounds( D2D1_RECT_F
		// *bounds );
		D2D_RECT_F GetBounds();
	}

	/// <summary>A developer implemented interface that allows a metafile to be replayed.</summary>
	// https://docs.microsoft.com/en-us/windows/win32/api/d2d1_1/nn-d2d1_1-id2d1gdimetafilesink
	[PInvokeData("d2d1_1.h", MSDNShortId = "1E9866C3-2A07-48C2-A4C5-F9AE3C7B2272")]
	[ComImport, Guid("82237326-8111-4f7c-bcf4-b5c1175564fe"), InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
	public interface ID2D1GdiMetafileSink
	{
		/// <summary>This method is called once for each record stored in a metafile.</summary>
		/// <param name="recordType">
		/// <para>Type: <c>DWORD</c></para>
		/// <para>The type of the record.</para>
		/// </param>
		/// <param name="recordData">
		/// <para>Type: <c>void*</c></para>
		/// <para>The data for the record.</para>
		/// </param>
		/// <param name="recordDataSize">
		/// <para>Type: <c>UINT</c></para>
		/// <para>The byte size of the record data.</para>
		/// </param>
		/// <returns>
		/// <para>Type: <c>BOOL</c></para>
		/// <para>Return true if the record is successfully.</para>
		/// </returns>
		// https://docs.microsoft.com/en-us/windows/win32/api/d2d1_1/nf-d2d1_1-id2d1gdimetafilesink-processrecord HRESULT ProcessRecord(
		// DWORD recordType, const void *recordData, DWORD recordDataSize );
		[PreserveSig]
		HRESULT ProcessRecord(uint recordType, [In, Optional] IntPtr recordData, uint recordDataSize);
	}

	/// <summary>
	/// Represents a collection of D2D1_GRADIENT_STOP objects for linear and radial gradient brushes. It provides get methods for all
	/// the new parameters added to the gradient stop collection.
	/// </summary>
	// https://docs.microsoft.com/en-us/windows/win32/api/d2d1_1/nn-d2d1_1-id2d1gradientstopcollection1
	[PInvokeData("d2d1_1.h", MSDNShortId = "aa423e18-c6b5-4587-b044-deda00a84615")]
	[ComImport, Guid("ae1572f4-5dd0-4777-998b-9279472ae63b"), InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
	public interface ID2D1GradientStopCollection1 : ID2D1GradientStopCollection
	{
		/// <summary>Retrieves the factory associated with this resource.</summary>
		/// <param name="factory">
		/// <para>Type: <c>ID2D1Factory**</c></para>
		/// <para>
		/// When this method returns, contains a pointer to a pointer to the factory that created this resource. This parameter is
		/// passed uninitialized.
		/// </para>
		/// </param>
		// https://docs.microsoft.com/en-us/windows/win32/api/d2d1/nf-d2d1-id2d1resource-getfactory void GetFactory( ID2D1Factory
		// **factory );
		[PreserveSig]
		new void GetFactory(out ID2D1Factory factory);

		/// <summary>Retrieves the number of gradient stops in the collection.</summary>
		/// <returns>
		/// <para>Type: <c>UINT32</c></para>
		/// <para>The number of gradient stops in the collection.</para>
		/// </returns>
		// https://docs.microsoft.com/en-us/windows/win32/api/d2d1/nf-d2d1-id2d1gradientstopcollection-getgradientstopcount UINT32 GetGradientStopCount();
		[PreserveSig]
		new uint GetGradientStopCount();

		/// <summary>Copies the gradient stops from the collection into an array of D2D1_GRADIENT_STOP structures.</summary>
		/// <param name="gradientStops">
		/// <para>Type: <c>D2D1_GRADIENT_STOP*</c></para>
		/// <para>
		/// A pointer to a one-dimensional array of D2D1_GRADIENT_STOP structures. When this method returns, the array contains copies
		/// of the collection's gradient stops. You must allocate the memory for this array.
		/// </para>
		/// </param>
		/// <param name="gradientStopsCount">
		/// <para>Type: <c>UINT</c></para>
		/// <para>
		/// A value indicating the number of gradient stops to copy. If the value is less than the number of gradient stops in the
		/// collection, the remaining gradient stops are omitted. If the value is larger than the number of gradient stops in the
		/// collection, the extra gradient stops are set to <c>NULL</c>. To obtain the number of gradient stops in the collection, use
		/// the GetGradientStopCount method.
		/// </para>
		/// </param>
		/// <returns>None</returns>
		/// <remarks>
		/// Gradient stops are copied in order of position, starting with the gradient stop with the smallest position value and
		/// progressing to the gradient stop with the largest position value.
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows/win32/api/d2d1/nf-d2d1-id2d1gradientstopcollection-getgradientstops void
		// GetGradientStops( D2D1_GRADIENT_STOP *gradientStops, UINT32 gradientStopsCount );
		[PreserveSig]
		new void GetGradientStops([Out, MarshalAs(UnmanagedType.LPArray, SizeParamIndex = 1)] D2D1_GRADIENT_STOP[] gradientStops, uint gradientStopsCount);

		/// <summary>Indicates the gamma space in which the gradient stops are interpolated.</summary>
		/// <returns>
		/// <para>Type: <c>D2D1_GAMMA</c></para>
		/// <para>The gamma space in which the gradient stops are interpolated.</para>
		/// </returns>
		// https://docs.microsoft.com/en-us/windows/win32/api/d2d1/nf-d2d1-id2d1gradientstopcollection-getcolorinterpolationgamma
		// D2D1_GAMMA GetColorInterpolationGamma();
		[PreserveSig]
		new D2D1_GAMMA GetColorInterpolationGamma();

		/// <summary>Indicates the behavior of the gradient outside the normalized gradient range.</summary>
		/// <returns>
		/// <para>Type: <c>D2D1_EXTEND_MODE</c></para>
		/// <para>The behavior of the gradient outside the [0,1] normalized gradient range.</para>
		/// </returns>
		// https://docs.microsoft.com/en-us/windows/win32/api/d2d1/nf-d2d1-id2d1gradientstopcollection-getextendmode D2D1_EXTEND_MODE GetExtendMode();
		[PreserveSig]
		new D2D1_EXTEND_MODE GetExtendMode();

		/// <summary>Copies the gradient stops from the collection into memory.</summary>
		/// <param name="gradientStops">
		/// <para>Type: <c>D2D1_GRADIENT_STOP*</c></para>
		/// <para>When this method returns, contains a pointer to a one-dimensional array of D2D1_GRADIENT_STOP structures.</para>
		/// </param>
		/// <param name="gradientStopsCount">
		/// <para>Type: <c>UINT</c></para>
		/// <para>The number of gradient stops to copy.</para>
		/// </param>
		/// <returns>None</returns>
		/// <remarks>
		/// <para>
		/// If the ID2D1DeviceContext::CreateGradientStopCollection, this method returns the same values specified in the creation
		/// method. If the <c>ID2D1GradientStopCollection1</c> object was created using
		/// <c>ID2D1RenderTarget::CreateGradientStopCollection</c>, the stops returned here will first be transformed into the gamma
		/// space specified by the colorInterpolationGamma parameter. See the ID2D1DeviceContext::CreateGradientStopCollection method
		/// for more info about color space and gamma space.
		/// </para>
		/// <para>
		/// If gradientStopsCount is less than the number of gradient stops in the collection, the remaining gradient stops are omitted.
		/// If gradientStopsCount is larger than the number of gradient stops in the collection, the extra gradient stops are set to
		/// <c>NULL</c>. To obtain the number of gradient stops in the collection, use the GetGradientStopCount method.
		/// </para>
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows/win32/api/d2d1_1/nf-d2d1_1-id2d1gradientstopcollection1-getgradientstops1 void
		// GetGradientStops1( D2D1_GRADIENT_STOP *gradientStops, UINT32 gradientStopsCount );
		[PreserveSig]
		void GetGradientStops1([Out] D2D1_GRADIENT_STOP[] gradientStops, uint gradientStopsCount);

		/// <summary>Gets the color space of the input colors as well as the space in which gradient stops are interpolated.</summary>
		/// <returns>
		/// <para>Type: <c>D2D1_COLOR_SPACE</c></para>
		/// <para>This method returns the color space.</para>
		/// </returns>
		/// <remarks>
		/// If this object was created using ID2D1RenderTarget::CreateGradientStopCollection, this method returns the color space
		/// related to the color interpolation gamma.
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows/win32/api/d2d1_1/nf-d2d1_1-id2d1gradientstopcollection1-getpreinterpolationspace
		// D2D1_COLOR_SPACE GetPreInterpolationSpace();
		[PreserveSig]
		D2D1_COLOR_SPACE GetPreInterpolationSpace();

		/// <summary>Gets the color space after interpolation has occurred.</summary>
		/// <returns>
		/// <para>Type: <c>D2D1_COLOR_SPACE</c></para>
		/// <para>This method returns the color space.</para>
		/// </returns>
		/// <remarks>If you create using ID2D1RenderTarget::CreateGradientStopCollection, this method returns D2D1_COLOR_SPACE_SRGB.</remarks>
		// https://docs.microsoft.com/en-us/windows/win32/api/d2d1_1/nf-d2d1_1-id2d1gradientstopcollection1-getpostinterpolationspace
		// D2D1_COLOR_SPACE GetPostInterpolationSpace();
		[PreserveSig]
		D2D1_COLOR_SPACE GetPostInterpolationSpace();

		/// <summary>Gets the precision of the gradient buffer.</summary>
		/// <returns>
		/// <para>Type: <c>D2D1_BUFFER_PRECISION</c></para>
		/// <para>The buffer precision of the gradient buffer.</para>
		/// </returns>
		/// <remarks>If this object was created using ID2D1RenderTarget::CreateGradientStopCollection, this method returns D2D1_BUFFER_PRECISION_8BPC_UNORM.</remarks>
		// https://docs.microsoft.com/en-us/windows/win32/api/d2d1_1/nf-d2d1_1-id2d1gradientstopcollection1-getbufferprecision
		// D2D1_BUFFER_PRECISION GetBufferPrecision();
		[PreserveSig]
		D2D1_BUFFER_PRECISION GetBufferPrecision();

		/// <summary>Retrieves the color interpolation mode that the gradient stop collection uses.</summary>
		/// <returns>
		/// <para>Type: <c>D2D1_COLOR_INTERPOLATION_MODE</c></para>
		/// <para>The color interpolation mode.</para>
		/// </returns>
		// https://docs.microsoft.com/en-us/windows/win32/api/d2d1_1/nf-d2d1_1-id2d1gradientstopcollection1-getcolorinterpolationmode
		// D2D1_COLOR_INTERPOLATION_MODE GetColorInterpolationMode();
		[PreserveSig]
		D2D1_COLOR_INTERPOLATION_MODE GetColorInterpolationMode();
	}

	/// <summary>Represents a brush based on an ID2D1Image.</summary>
	// https://docs.microsoft.com/en-us/windows/win32/api/d2d1_1/nn-d2d1_1-id2d1imagebrush
	[PInvokeData("d2d1_1.h", MSDNShortId = "c5088ce2-5744-4061-957b-25831478a714")]
	[ComImport, Guid("fe9e984d-3f95-407c-b5db-cb94d4e8f87c"), InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
	public interface ID2D1ImageBrush : ID2D1Brush
	{
		/// <summary>Retrieves the factory associated with this resource.</summary>
		/// <param name="factory">
		/// <para>Type: <c>ID2D1Factory**</c></para>
		/// <para>
		/// When this method returns, contains a pointer to a pointer to the factory that created this resource. This parameter is
		/// passed uninitialized.
		/// </para>
		/// </param>
		// https://docs.microsoft.com/en-us/windows/win32/api/d2d1/nf-d2d1-id2d1resource-getfactory void GetFactory( ID2D1Factory
		// **factory );
		[PreserveSig]
		new void GetFactory(out ID2D1Factory factory);

		/// <summary>Sets the degree of opacity of this brush.</summary>
		/// <param name="opacity">
		/// <para>Type: <c>FLOAT</c></para>
		/// <para>
		/// A value between zero and 1 that indicates the opacity of the brush. This value is a constant multiplier that linearly scales
		/// the alpha value of all pixels filled by the brush. The opacity values are clamped in the range 0–1 before they are multipled together.
		/// </para>
		/// </param>
		/// <returns>None</returns>
		// https://docs.microsoft.com/en-us/windows/win32/api/d2d1/nf-d2d1-id2d1brush-setopacity void SetOpacity( FLOAT opacity );
		[PreserveSig]
		new void SetOpacity(float opacity);

		/// <summary>Sets the transformation applied to the brush.</summary>
		/// <param name="transform">
		/// <para>Type: <c>const D2D1_MATRIX_3X2_F</c></para>
		/// <para>The transformation to apply to this brush.</para>
		/// </param>
		/// <returns>None</returns>
		/// <remarks>
		/// <para>
		/// When you paint with a brush, it paints in the coordinate space of the render target. Brushes do not automatically position
		/// themselves to align with the object being painted; by default, they begin painting at the origin (0, 0) of the render target.
		/// </para>
		/// <para>
		/// You can "move" the gradient defined by an ID2D1LinearGradientBrush to a target area by setting its start point and end
		/// point. Likewise, you can move the gradient defined by an ID2D1RadialGradientBrush by changing its center and radii.
		/// </para>
		/// <para>
		/// To align the content of an ID2D1BitmapBrush to the area being painted, you can use the SetTransform method to translate the
		/// bitmap to the desired location. This transform only affects the brush; it does not affect any other content drawn by the
		/// render target.
		/// </para>
		/// <para>
		/// The following illustrations show the effect of using an ID2D1BitmapBrush to fill a rectangle located at (100, 100). The
		/// illustration on the left illustration shows the result of filling the rectangle without transforming the brush: the bitmap
		/// is drawn at the render target's origin. As a result, only a portion of the bitmap appears in the rectangle.
		/// </para>
		/// <para>
		/// The illustration on the right shows the result of transforming the ID2D1BitmapBrush so that its content is shifted 50 pixels
		/// to the right and 50 pixels down. The bitmap now fills the rectangle.
		/// </para>
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows/win32/api/d2d1/nf-d2d1-id2d1brush-settransform(constd2d1_matrix_3x2_f_) void
		// SetTransform( const D2D1_MATRIX_3X2_F &amp; transform );
		[PreserveSig]
		new void SetTransform(in D2D_MATRIX_3X2_F transform);

		/// <summary>Gets the degree of opacity of this brush.</summary>
		/// <returns>
		/// <para>Type: <c>FLOAT</c></para>
		/// <para>
		/// A value between zero and 1 that indicates the opacity of the brush. This value is a constant multiplier that linearly scales
		/// the alpha value of all pixels filled by the brush. The opacity values are clamped in the range 0–1 before they are multipled together.
		/// </para>
		/// </returns>
		// https://docs.microsoft.com/en-us/windows/win32/api/d2d1/nf-d2d1-id2d1brush-getopacity FLOAT GetOpacity();
		[PreserveSig]
		new float GetOpacity();

		/// <summary>Gets the transform applied to this brush.</summary>
		/// <param name="transform">
		/// <para>Type: <c>D2D1_MATRIX_3X2_F*</c></para>
		/// <para>The transform applied to this brush.</para>
		/// </param>
		/// <returns>None</returns>
		/// <remarks>
		/// When the brush transform is the identity matrix, the brush appears in the same coordinate space as the render target in
		/// which it is drawn.
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows/win32/api/d2d1/nf-d2d1-id2d1brush-gettransform void GetTransform( D2D1_MATRIX_3X2_F
		// *transform );
		[PreserveSig]
		new void GetTransform(out D2D_MATRIX_3X2_F transform);

		/// <summary>Sets the image associated with the provided image brush.</summary>
		/// <param name="image">
		/// <para>Type: <c>ID2D1Image*</c></para>
		/// <para>The image to be associated with the image brush.</para>
		/// </param>
		/// <returns>None</returns>
		// https://docs.microsoft.com/en-us/windows/win32/api/d2d1_1/nf-d2d1_1-id2d1imagebrush-setimage void SetImage( ID2D1Image *image );
		[PreserveSig]
		void SetImage([In, Optional] ID2D1Image? image);

		/// <summary>Sets how the content inside the source rectangle in the image brush will be extended on the x-axis.</summary>
		/// <param name="extendModeX">
		/// <para>Type: <c>D2D1_EXTEND_MODE</c></para>
		/// <para>The extend mode on the x-axis of the image.</para>
		/// </param>
		/// <returns>None</returns>
		// https://docs.microsoft.com/en-us/windows/win32/api/d2d1_1/nf-d2d1_1-id2d1imagebrush-setextendmodex void SetExtendModeX(
		// D2D1_EXTEND_MODE extendModeX );
		[PreserveSig]
		void SetExtendModeX(D2D1_EXTEND_MODE extendModeX);

		/// <summary>Sets the extend mode on the y-axis.</summary>
		/// <param name="extendModeY">
		/// <para>Type: <c>D2D1_EXTEND_MODE</c></para>
		/// <para>The extend mode on the y-axis of the image.</para>
		/// </param>
		/// <returns>None</returns>
		// https://docs.microsoft.com/en-us/windows/win32/api/d2d1_1/nf-d2d1_1-id2d1imagebrush-setextendmodey void SetExtendModeY(
		// D2D1_EXTEND_MODE extendModeY );
		[PreserveSig]
		void SetExtendModeY(D2D1_EXTEND_MODE extendModeY);

		/// <summary>Sets the interpolation mode for the image brush.</summary>
		/// <param name="interpolationMode">
		/// <para>Type: <c>D2D1_INTERPOLATION_MODE</c></para>
		/// <para>How the contents of the image will be interpolated to handle the brush transform.</para>
		/// </param>
		/// <returns>None</returns>
		// https://docs.microsoft.com/en-us/windows/win32/api/d2d1_1/nf-d2d1_1-id2d1imagebrush-setinterpolationmode void
		// SetInterpolationMode( D2D1_INTERPOLATION_MODE interpolationMode );
		[PreserveSig]
		void SetInterpolationMode(D2D1_INTERPOLATION_MODE interpolationMode);

		/// <summary>Sets the source rectangle in the image brush.</summary>
		/// <param name="sourceRectangle">
		/// <para>Type: <c>const D2D1_RECT_F*</c></para>
		/// <para>The source rectangle that defines the portion of the image to tile.</para>
		/// </param>
		/// <returns>None</returns>
		/// <remarks>
		/// <para>
		/// The top left corner of the sourceRectangle parameter maps to the brush space origin. That is, if the brush and world
		/// transforms are both identity, the portion of the image in the top left corner of the source rectangle will be rendered at
		/// (0,0) in the render target.
		/// </para>
		/// <para>
		/// The source rectangle will be expanded differently depending on whether the input image is based on pixels (a bitmap or
		/// effect) or by a command list.
		/// </para>
		/// <list type="bullet">
		/// <item>
		/// <term>
		/// If the input image is a bitmap or an effect, the rectangle will be expanded to encapsulate a full input pixel before being
		/// additionally down-scaled to ensure that the projected rectangle will be correct in the final scene-space.
		/// </term>
		/// </item>
		/// <item>
		/// <term>If the input image is a command list, the command list will be slightly expanded to encapsulate a full input pixel.</term>
		/// </item>
		/// </list>
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows/win32/api/d2d1_1/nf-d2d1_1-id2d1imagebrush-setsourcerectangle void
		// SetSourceRectangle( const D2D1_RECT_F *sourceRectangle );
		[PreserveSig]
		void SetSourceRectangle(in D2D_RECT_F sourceRectangle);

		/// <summary>Gets the image associated with the image brush.</summary>
		/// <param name="image">
		/// <para>Type: <c>ID2D1Image**</c></para>
		/// <para>When this method returns, contains the address of a pointer to the image associated with this brush.</para>
		/// </param>
		/// <returns>None</returns>
		// https://docs.microsoft.com/en-us/windows/win32/api/d2d1_1/nf-d2d1_1-id2d1imagebrush-getimage void GetImage( ID2D1Image
		// **image );
		[PreserveSig]
		void GetImage(out ID2D1Image image);

		/// <summary>Gets the extend mode of the image brush on the x-axis.</summary>
		/// <returns>
		/// <para>Type: <c>D2D1_EXTEND_MODE</c></para>
		/// <para>This method returns the x-extend mode.</para>
		/// </returns>
		// https://docs.microsoft.com/en-us/windows/win32/api/d2d1_1/nf-d2d1_1-id2d1imagebrush-getextendmodex D2D1_EXTEND_MODE GetExtendModeX();
		[PreserveSig]
		D2D1_EXTEND_MODE GetExtendModeX();

		/// <summary>Gets the extend mode of the image brush on the y-axis of the image.</summary>
		/// <returns>
		/// <para>Type: <c>D2D1_EXTEND_MODE</c></para>
		/// <para>This method returns the y-extend mode.</para>
		/// </returns>
		// https://docs.microsoft.com/en-us/windows/win32/api/d2d1_1/nf-d2d1_1-id2d1imagebrush-getextendmodey D2D1_EXTEND_MODE GetExtendModeY();
		[PreserveSig]
		D2D1_EXTEND_MODE GetExtendModeY();

		/// <summary>Gets the interpolation mode of the image brush.</summary>
		/// <returns>
		/// <para>Type: <c>D2D1_INTERPOLATION_MODE</c></para>
		/// <para>This method returns the interpolation mode.</para>
		/// </returns>
		// https://docs.microsoft.com/en-us/windows/win32/api/d2d1_1/nf-d2d1_1-id2d1imagebrush-getinterpolationmode
		// D2D1_INTERPOLATION_MODE GetInterpolationMode();
		[PreserveSig]
		D2D1_INTERPOLATION_MODE GetInterpolationMode();

		/// <summary>Gets the rectangle that will be used as the bounds of the image when drawn as an image brush.</summary>
		/// <param name="sourceRectangle">
		/// <para>Type: <c>D2D1_RECT_F*</c></para>
		/// <para>When this method returns, contains the address of the output source rectangle.</para>
		/// </param>
		/// <returns>None</returns>
		// https://docs.microsoft.com/en-us/windows/win32/api/d2d1_1/nf-d2d1_1-id2d1imagebrush-getsourcerectangle void
		// GetSourceRectangle( D2D1_RECT_F *sourceRectangle );
		[PreserveSig]
		void GetSourceRectangle(out D2D_RECT_F sourceRectangle);
	}

	/// <summary>
	/// Converts Direct2D primitives stored in an ID2D1CommandList into a fixed page representation. The print sub-system then consumes
	/// the primitives.
	/// </summary>
	// https://docs.microsoft.com/en-us/windows/win32/api/d2d1_1/nn-d2d1_1-id2d1printcontrol
	[ComImport, Guid("2c1d867d-c290-41c8-ae7e-34a98702e9a5"), InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
	public interface ID2D1PrintControl
	{
		/// <summary>
		/// Converts Direct2D primitives in the passed-in command list into a fixed page representation for use by the print subsystem.
		/// </summary>
		/// <param name="commandList">
		/// <para>Type: <c>ID2D1CommandList*</c></para>
		/// <para>The command list that contains the rendering operations.</para>
		/// </param>
		/// <param name="pageSize">
		/// <para>Type: <c>D2D_SIZE_F</c></para>
		/// <para>The size of the page to add.</para>
		/// </param>
		/// <param name="pagePrintTicketStream">
		/// <para>Type: <c>IStream*</c></para>
		/// <para>The print ticket stream.</para>
		/// </param>
		/// <param name="tag1">
		/// <para>Type: <c>ulong*</c></para>
		/// <para>
		/// Contains the first label for subsequent drawing operations. This parameter is passed uninitialized. If NULL is specified, no
		/// value is retrieved for this parameter.
		/// </para>
		/// </param>
		/// <param name="tag2">
		/// <para>Type: <c>ulong*</c></para>
		/// <para>
		/// Contains the second label for subsequent drawing operations. This parameter is passed uninitialized. If NULL is specified,
		/// no value is retrieved for this parameter.
		/// </para>
		/// </param>
		// https://docs.microsoft.com/en-us/windows/win32/api/d2d1_1/nf-d2d1_1-id2d1printcontrol-addpage HRESULT AddPage(
		// ID2D1CommandList *commandList, D2D_SIZE_F pageSize, IStream *pagePrintTicketStream, ulong *tag1, ulong *tag2 );
		void AddPage(ID2D1CommandList commandList, D2D_SIZE_F pageSize, [Optional] IStream? pagePrintTicketStream, out ulong tag1, out ulong tag2);

		/// <summary>Passes all remaining resources to the print sub-system, then clean up and close the current print job.</summary>
		// https://docs.microsoft.com/en-us/windows/win32/api/d2d1_1/nf-d2d1_1-id2d1printcontrol-close HRESULT Close();
		void Close();
	}

	/// <summary>
	/// Represents a set of run-time bindable and discoverable properties that allow a data-driven application to modify the state of a
	/// Direct2D effect.
	/// </summary>
	/// <remarks>
	/// <para>
	/// This interface supports access through either indices or property names. In addition to top-level properties, each property in
	/// an <c>ID2D1Properties</c> object may contain an <c>ID2D1Properties</c> object, which stores metadata describing the parent property.
	/// </para>
	/// <para>Overview</para>
	/// <para>
	/// The <c>ID2D1Properties</c> interface exposes a set of run-time bindable and discoverable properties that allow a data-driven
	/// application such as an effect graph authoring tool or an animation system to modify the state of a Direct2D effect.
	/// </para>
	/// <para>
	/// The interface supports access through either indices or property names. In addition to top-level properties, each property in an
	/// <c>ID2D1Properties</c> may contain a sub- <c>ID2D1Properties</c> interface, which stores metadata describing its parent
	/// property. Sub-properties are accessed by requesting this sub-interface by property index, or by using a property name string
	/// separated by a dot (.).
	/// </para>
	/// <para>
	/// The interface is intentionally designed to avoid dependencies on a run-time basis. All allocation is done by the caller of the
	/// API and <c>VARIANT</c> types are not used. The property interface generally is designed not to return failures where the
	/// application could trivially change their calling sequence in order to avoid the condition. For example, since the number of
	/// properties supported by the instance is returned by the GetPropertyCount method, other methods that take a property index do not
	/// return a failure, unless they also use the plug-in effect's property system.
	/// </para>
	/// <para>
	/// The interface is primarily based upon an index-based access model, and it supports nested sub-properties within properties.
	/// Unlike a directory structure, the property itself has a value and a type and might optionally support sub-properties
	/// (directories are not files). These are normally metadata that describe the property, but, this is also used to specify arrays of
	/// objects. In order to simplify accessing sub-properties and to allow name-based access, two helper methods – GetValueByName – are
	/// defined. These use a "dotted" notation in order to allow sub-properties to be directly specified, for example:
	/// </para>
	/// <para>Or:</para>
	/// <para>Standard Effect Properties</para>
	/// <list type="table">
	/// <listheader>
	/// <term>Property name/index</term>
	/// <term>Property type</term>
	/// <term>Property description</term>
	/// </listheader>
	/// <item>
	/// <term>CLSID / D2D1_PROPERTY_CLSID</term>
	/// <term>D2D1_PROPERTY_TYPE_CLSID</term>
	/// <term>The CLSID of the effect.</term>
	/// </item>
	/// <item>
	/// <term>DisplayName / D2D1_PROPERTY_DISPLAYNAME</term>
	/// <term>D2D1_PROPERTY_TYPE_STRING</term>
	/// <term>A displayable, localized name for the effect.</term>
	/// </item>
	/// <item>
	/// <term>Author / D2D1_PROPERTY_AUTHOR</term>
	/// <term>D2D1_PROPERTY_TYPE_STRING</term>
	/// <term>The author of the effect.</term>
	/// </item>
	/// <item>
	/// <term>Category / D2D1_PROPERTY_CATEGORY</term>
	/// <term>D2D1_PROPERTY_TYPE_STRING</term>
	/// <term>The category of the effect.</term>
	/// </item>
	/// <item>
	/// <term>Description / D2D1_PROPERTY_DESCRIPTION</term>
	/// <term>D2D1_PROPERTY_TYPE_STRING</term>
	/// <term>A description of the effect.</term>
	/// </item>
	/// <item>
	/// <term>Inputs / D2D1_PROPERTY_INPUTS</term>
	/// <term>D2D1_PROPERTY_TYPE_ARRAY</term>
	/// <term>An array of names for the effect’s inputs. Each element of the array is a localized string specifying the name of an input.</term>
	/// </item>
	/// </list>
	/// <para>Standard Sub-Properties</para>
	/// <para>
	/// The following are standard sub-properties that can be used for meta-data access, and may be available on both system and custom
	/// properties. Please see the D2D1_SUBPROPERTY and D2D1_PROPERTY_TYPE enumerations for more information.
	/// </para>
	/// <list type="table">
	/// <listheader>
	/// <term>Property name/index</term>
	/// <term>Property type</term>
	/// <term>Property description</term>
	/// </listheader>
	/// <item>
	/// <term>DisplayName / D2D1_SUBPROPERTY_DISPLAYNAME</term>
	/// <term>D2D1_PROPERTY_TYPE_STRING</term>
	/// <term>A displayable, localized name for the parent property. This sub-property is present on all top-level properties.</term>
	/// </item>
	/// <item>
	/// <term>IsReadOnly / D2D1_SUBPROPERTY_ISREADONLY</term>
	/// <term>D2D1_PROPERTY_TYPE_BOOL</term>
	/// <term>A value indicating whether the parent property can be written to. This sub-property is present on all top-level properties.</term>
	/// </item>
	/// <item>
	/// <term>Default / D2D1_SUBPROPERTY_DEFAULT</term>
	/// <term>Same as parent property.</term>
	/// <term>The default value for the property. This sub-property is optionally present on all properties.</term>
	/// </item>
	/// <item>
	/// <term>Min / D2D1_SUBPROPERTY_MIN</term>
	/// <term>Same as parent property.</term>
	/// <term>The minimum value that the parent property supports being set to.</term>
	/// </item>
	/// <item>
	/// <term>Max / D2D1_SUBPROPERTY_MIN</term>
	/// <term>Same as parent property.</term>
	/// <term>The maximum value that the parent property supports being set to.</term>
	/// </item>
	/// <item>
	/// <term>Fields / D2D1_SUBPROPERTY_FIELDS</term>
	/// <term>Array / D2D1_PROPERTY_TYPE_ARRAY</term>
	/// <term>
	/// The set of valid values that can be set to the parent property. Each value in this array is a name/index pair. The indices can
	/// be set to the parent and the names are localized values designed for consumption by UI. See the following section for more details.
	/// </term>
	/// </item>
	/// </list>
	/// <para>Array-Type Sub-Properties</para>
	/// <para>
	/// See ID2D1Properties::GetType and D2D1_PROPERTY_TYPE for more information. If the property type is
	/// <c>D2D1_PROPERTY_TYPE_ARRAY</c>, the value of the property will be considered to be a <c>UINT</c> that has the count of array
	/// elements. The next sub-property will directly map the index to the requested property value. For example:
	/// </para>
	/// <para>
	/// The above example makes use of the following sub-properties, which will appear on <c>ARRAY</c>-type properties. Note that the
	/// numbered properties are not system properties, and are in the normal (0x0 – 0x80000000) range.
	/// </para>
	/// <list type="table">
	/// <listheader>
	/// <term>Property name</term>
	/// <term>Property index</term>
	/// <term>Property description</term>
	/// </listheader>
	/// <item>
	/// <term>Property.0</term>
	/// <term>0</term>
	/// <term>First element of the property array.</term>
	/// </item>
	/// <item>
	/// <term>...</term>
	/// <term>...</term>
	/// <term>...</term>
	/// </item>
	/// <item>
	/// <term>Property.N</term>
	/// <term>N</term>
	/// <term>Nth element of the property array.</term>
	/// </item>
	/// </list>
	/// <para>The type of each sub-element will be whatever the type of the array is. In the example above, this was an array of strings.</para>
	/// <para>Enum-Type Sub-Poperties</para>
	/// <para>
	/// If the property has type <c>D2D1_PROPERTY_TYPE_ENUM</c> then the property will have the value of the corresponding enumeration.
	/// There will be a sub-array of fields that will conform to the general rules for array sub-properties and consist of the
	/// name/value pairs. For example:
	/// </para>
	/// <para>
	/// The above example makes use of the following sub-properties. Please see the D2D1_SUBPROPERTY and D2D1_PROPERTY_TYPE enumerations
	/// for more information.
	/// </para>
	/// <list type="table">
	/// <listheader>
	/// <term>Property name</term>
	/// <term>Property index</term>
	/// <term>Property description</term>
	/// </listheader>
	/// <item>
	/// <term>Property.Fields</term>
	/// <term>D2D1_SUBPROPERTY_FIELDS</term>
	/// <term>An array type property that gives information about each field in the enumeration.</term>
	/// </item>
	/// <item>
	/// <term>Property.Fields.N</term>
	/// <term>N</term>
	/// <term>An array element that gives the name of the Nth enumeration value.</term>
	/// </item>
	/// <item>
	/// <term>Property.Fields.N.Index</term>
	/// <term>D2D1_SUBPROPERTY_INDEX</term>
	/// <term>The index which corresponds to the Nth enumeration value.</term>
	/// </item>
	/// </list>
	/// </remarks>
	// https://docs.microsoft.com/en-us/windows/win32/api/d2d1_1/nn-d2d1_1-id2d1properties
	[ComImport, Guid("483473d7-cd46-4f9d-9d3a-3112aa80159d"), InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
	public interface ID2D1Properties
	{
		/// <summary>Gets the number of top-level properties.</summary>
		/// <returns>
		/// <para>Type: <c>UINT32</c></para>
		/// <para>This method returns the number of custom (non-system) properties that can be accessed by the object.</para>
		/// </returns>
		/// <remarks>
		/// This method returns the number of custom properties on the ID2D1Properties interface. System properties and sub-properties
		/// are part of a closed set, and are enumerable by iterating over this closed set.
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows/win32/api/d2d1_1/nf-d2d1_1-id2d1properties-getpropertycount UINT32 GetPropertyCount();
		[PreserveSig]
		uint GetPropertyCount();

		/// <summary>Gets the property name that corresponds to the given index.</summary>
		/// <param name="index">
		/// <para>Type: <c>UINT32</c></para>
		/// <para>The index of the property for which the name is being returned.</para>
		/// </param>
		/// <param name="name">
		/// <para>Type: <c>PWSTR</c></para>
		/// <para>When this method returns, contains the name being retrieved.</para>
		/// </param>
		/// <param name="nameCount">
		/// <para>Type: <c>UINT32</c></para>
		/// <para>The number of characters in the name buffer.</para>
		/// </param>
		/// <remarks>
		/// This method returns an empty string if index is invalid. If the method returns
		/// <c>RESULT_FROM_WIN32(ERROR_INSUFFICIENT_BUFFER)</c>, name will still be filled and truncated.
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows/win32/api/d2d1_1/nf-d2d1_1-id2d1properties-getpropertyname(uint32_pwstr_uint32)
		// HRESULT GetPropertyName( UINT32 index, PWSTR name, UINT32 nameCount );
		void GetPropertyName(uint index, [MarshalAs(UnmanagedType.LPWStr)] StringBuilder name, uint nameCount);

		/// <summary>Gets the number of characters for the given property name. This is a template overload. See Remarks.</summary>
		/// <param name="index">
		/// <para>Type: <c>U</c></para>
		/// <para>The index of the property name to retrieve.</para>
		/// </param>
		/// <returns>
		/// <para>Type: <c>UINT32</c></para>
		/// <para>
		/// This method returns the size in characters of the name corresponding to the given property index, or zero if the property
		/// index does not exist.
		/// </para>
		/// </returns>
		/// <remarks>
		/// <para>The value returned by this method can be used to ensure that the buffer size for GetPropertyName is appropriate.</para>
		/// <para>template&lt;typename U&gt; UINT32 GetPropertyNameLength( U index ) CONST;</para>
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows/win32/api/d2d1_1/nf-d2d1_1-id2d1properties-getpropertynamelength%28u%29 UINT32
		// GetPropertyNameLength( U index );
		[PreserveSig]
		uint GetPropertyNameLength(uint index);

		/// <summary>Gets the D2D1_PROPERTY_TYPE of the selected property.</summary>
		/// <param name="index">
		/// <para>Type: <c>UINT32</c></para>
		/// <para>The index of the property for which the type will be retrieved.</para>
		/// </param>
		/// <returns>
		/// <para>Type: <c>D2D1_PROPERTY_TYPE</c></para>
		/// <para>This method returns a D2D1_PROPERTY_TYPE-typed value for the type of the selected property.</para>
		/// </returns>
		/// <remarks>If the property does not exist, the method returns D2D1_PROPERTY_TYPE_UNKNOWN.</remarks>
		// https://docs.microsoft.com/en-us/windows/win32/api/d2d1_1/nf-d2d1_1-id2d1properties-gettype%28uint32%29 D2D1_PROPERTY_TYPE
		// GetType( UINT32 index );
		[PreserveSig]
		D2D1_PROPERTY_TYPE GetType(uint index);

		/// <summary>Gets the index corresponding to the given property name.</summary>
		/// <param name="name">
		/// <para>Type: <c>PCWSTR</c></para>
		/// <para>The name of the property to retrieve.</para>
		/// </param>
		/// <returns>
		/// <para>Type: <c>UINT32</c></para>
		/// <para>The index of the corresponding property name.</para>
		/// </returns>
		/// <remarks>
		/// If the property doesn't exist, then this method returns D2D1_INVALID_PROPERTY_INDEX. This reserved value will never map to a
		/// valid index, and will cause <c>NULL</c> or sentinel values to be returned from other parts of the property interface.
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows/win32/api/d2d1_1/nf-d2d1_1-id2d1properties-getpropertyindex UINT32 GetPropertyIndex(
		// PCWSTR name );
		[PreserveSig]
		uint GetPropertyIndex([MarshalAs(UnmanagedType.LPWStr)] string name);

		/// <summary>Sets the named property to the given value.</summary>
		/// <param name="name">
		/// <para>Type: <c>PCWSTR</c></para>
		/// <para>The name of the property to set.</para>
		/// </param>
		/// <param name="type">TBD</param>
		/// <param name="data">
		/// <para>Type: <c>const BYTE*</c></para>
		/// <para>The data to set.</para>
		/// </param>
		/// <param name="dataSize">
		/// <para>Type: <c>UINT32</c></para>
		/// <para>The number of bytes in the data to set.</para>
		/// </param>
		/// <remarks>
		/// <para>If the property does not exist, the request is ignored and the method returns <c>D2DERR_INVALID_PROPERTY</c>.</para>
		/// <para>Any error not in the standard set returned by a property implementation will be mapped into the standard error range.</para>
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows/win32/api/d2d1_1/nf-d2d1_1-id2d1properties-setvaluebyname%28pcwstr_d2d1_property_type_constbyte_uint32%29
		// HRESULT SetValueByName( PCWSTR name, D2D1_PROPERTY_TYPE type, const BYTE *data, UINT32 dataSize );
		void SetValueByName([MarshalAs(UnmanagedType.LPWStr)] string name, D2D1_PROPERTY_TYPE type, [In] IntPtr data, uint dataSize);

		/// <summary>Sets the corresponding property by index.</summary>
		/// <param name="index">
		/// <para>Type: <c>UINT32</c></para>
		/// <para>The index of the property to set.</para>
		/// </param>
		/// <param name="type">TBD</param>
		/// <param name="data">
		/// <para>Type: <c>const BYTE*</c></para>
		/// <para>The data to set.</para>
		/// </param>
		/// <param name="dataSize">
		/// <para>Type: <c>UINT32</c></para>
		/// <para>The number of bytes in the data to set.</para>
		/// </param>
		/// <returns>
		/// <para>Type: <c>HRESULT</c></para>
		/// <para>The method returns an <c>HRESULT</c>. Possible values include, but are not limited to, those in the following table.</para>
		/// <list type="table">
		/// <listheader>
		/// <term>HRESULT</term>
		/// <term>Description</term>
		/// </listheader>
		/// <item>
		/// <term>S_OK</term>
		/// <term>No error occurred.</term>
		/// </item>
		/// <item>
		/// <term>D2DERR_INVALID_PROPERTY</term>
		/// <term>The specified property does not exist.</term>
		/// </item>
		/// <item>
		/// <term>E_OUTOFMEMORY</term>
		/// <term>Failed to allocate necessary memory.</term>
		/// </item>
		/// <item>
		/// <term>D3DERR_OUT_OF_VIDEO_MEMORY</term>
		/// <term>Failed to allocate required video memory.</term>
		/// </item>
		/// <item>
		/// <term>E_INVALIDARG</term>
		/// <term>One or more arguments are invalid.</term>
		/// </item>
		/// <item>
		/// <term>E_FAIL</term>
		/// <term>Unspecified failure.</term>
		/// </item>
		/// </list>
		/// </returns>
		/// <remarks>
		/// <para>If the property does not exist, the request is ignored and <c>D2DERR_INVALID_PROPERTY</c> is returned.</para>
		/// <para>Any error not in the standard set returned by a property implementation will be mapped into the standard error range.</para>
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows/win32/api/d2d1_1/nf-d2d1_1-id2d1properties-setvalue(uint32_d2d1_property_type_constbyte_uint32)
		// HRESULT SetValue( UINT32 index, D2D1_PROPERTY_TYPE type, const BYTE *data, UINT32 dataSize );
		void SetValue(uint index, D2D1_PROPERTY_TYPE type, [In] IntPtr data, uint dataSize);

		/// <summary>Gets the property value by name.</summary>
		/// <param name="name">
		/// <para>Type: <c>PCWSTR</c></para>
		/// <para>The property name to get.</para>
		/// </param>
		/// <param name="type">TBD</param>
		/// <param name="data">
		/// <para>Type: <c>BYTE*</c></para>
		/// <para>When this method returns, contains the buffer with the data value.</para>
		/// </param>
		/// <param name="dataSize">
		/// <para>Type: <c>UINT32</c></para>
		/// <para>The number of bytes in the data to be retrieved.</para>
		/// </param>
		/// <returns>
		/// <para>Type: <c>HRESULT</c></para>
		/// <para>The method returns an <c>HRESULT</c>. Possible values include, but are not limited to, those in the following table.</para>
		/// <list type="table">
		/// <listheader>
		/// <term>HRESULT</term>
		/// <term>Description</term>
		/// </listheader>
		/// <item>
		/// <term>S_OK</term>
		/// <term>No error occurred.</term>
		/// </item>
		/// <item>
		/// <term>D2DERR_INVALID_PROPERTY</term>
		/// <term>The specified property does not exist.</term>
		/// </item>
		/// <item>
		/// <term>E_OUTOFMEMORY</term>
		/// <term>Failed to allocate necessary memory.</term>
		/// </item>
		/// <item>
		/// <term>D3DERR_OUT_OF_VIDEO_MEMORY</term>
		/// <term>Failed to allocate required video memory.</term>
		/// </item>
		/// <item>
		/// <term>E_INVALIDARG</term>
		/// <term>One or more arguments are invalid.</term>
		/// </item>
		/// <item>
		/// <term>E_FAIL</term>
		/// <term>Unspecified failure.</term>
		/// </item>
		/// </list>
		/// </returns>
		/// <remarks>
		/// <para>If name does not exist, no information is retrieved.</para>
		/// <para>Any error not in the standard set returned by a property implementation will be mapped into the standard error range.</para>
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows/win32/api/d2d1_1/nf-d2d1_1-id2d1properties-getvaluebyname(pcwstr_d2d1_property_type_byte_uint32)
		// HRESULT GetValueByName( PCWSTR name, D2D1_PROPERTY_TYPE type, BYTE *data, UINT32 dataSize );
		void GetValueByName([MarshalAs(UnmanagedType.LPWStr)] string name, D2D1_PROPERTY_TYPE type, [Out] IntPtr data, uint dataSize);

		/// <summary>Gets the value of the specified property by index.</summary>
		/// <param name="index">
		/// <para>Type: <c>UINT32</c></para>
		/// <para>The index of the property from which the data is to be obtained.</para>
		/// </param>
		/// <param name="type">TBD</param>
		/// <param name="data">
		/// <para>Type: <c>BYTE*</c></para>
		/// <para>When this method returns, contains a pointer to the data requested.</para>
		/// </param>
		/// <param name="dataSize">
		/// <para>Type: <c>UINT32</c></para>
		/// <para>The number of bytes in the data to be retrieved.</para>
		/// </param>
		/// <returns>
		/// <para>Type: <c>HRESULT</c></para>
		/// <para>The method returns an <c>HRESULT</c>. Possible values include, but are not limited to, those in the following table.</para>
		/// <list type="table">
		/// <listheader>
		/// <term>HRESULT</term>
		/// <term>Description</term>
		/// </listheader>
		/// <item>
		/// <term>S_OK</term>
		/// <term>No error occurred.</term>
		/// </item>
		/// <item>
		/// <term>D2DERR_INVALID_PROPERTY</term>
		/// <term>The specified property does not exist.</term>
		/// </item>
		/// <item>
		/// <term>E_OUTOFMEMORY</term>
		/// <term>Failed to allocate necessary memory.</term>
		/// </item>
		/// <item>
		/// <term>D3DERR_OUT_OF_VIDEO_MEMORY</term>
		/// <term>Failed to allocate required video memory.</term>
		/// </item>
		/// <item>
		/// <term>E_INVALIDARG</term>
		/// <term>One or more arguments are invalid.</term>
		/// </item>
		/// <item>
		/// <term>E_FAIL</term>
		/// <term>Unspecified failure.</term>
		/// </item>
		/// </list>
		/// </returns>
		// https://docs.microsoft.com/en-us/windows/win32/api/d2d1_1/nf-d2d1_1-id2d1properties-getvalue(uint32_d2d1_property_type_byte_uint32)
		// HRESULT GetValue( UINT32 index, D2D1_PROPERTY_TYPE type, BYTE *data, UINT32 dataSize );
		void GetValue(uint index, D2D1_PROPERTY_TYPE type, [Out] IntPtr data, uint dataSize);

		/// <summary>Gets the size of the property value in bytes, using the property index. This is a template overload. See Remarks.</summary>
		/// <param name="index">
		/// <para>Type: <c>U</c></para>
		/// <para>The index of the property.</para>
		/// </param>
		/// <returns>
		/// <para>Type: <c>UINT32</c></para>
		/// <para>This method returns size of the value in bytes, using the property index</para>
		/// </returns>
		/// <remarks>
		/// <para>This method returns zero if index does not exist.</para>
		/// <para>template&lt;typename U&gt; UINT32 GetValueSize( U index ) CONST;</para>
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows/win32/api/d2d1_1/nf-d2d1_1-id2d1properties-getvaluesize%28u%29 UINT32 GetValueSize(
		// U index );
		[PreserveSig]
		uint GetValueSize(uint index);

		/// <summary>Gets the sub-properties of the provided property by index.</summary>
		/// <param name="index">
		/// <para>Type: <c>UINT32</c></para>
		/// <para>The index of the sub-properties to be retrieved.</para>
		/// </param>
		/// <returns>
		/// <para>Type: <c>ID2D1Properties**</c></para>
		/// <para>When this method returns, contains the address of a pointer to the sub-properties.</para>
		/// </returns>
		/// <remarks>
		/// If there are no sub-properties, subProperties will be <c>NULL</c>, and <c>D2DERR_NO_SUBPROPERTIES</c> will be returned.
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows/win32/api/d2d1_1/nf-d2d1_1-id2d1properties-getsubproperties%28uint32_id2d1properties%29
		// HRESULT GetSubProperties( UINT32 index, ID2D1Properties **subProperties );
		ID2D1Properties GetSubProperties(uint index);
	}

	/// <summary>Describes the extend modes and the interpolation mode of an ID2D1BitmapBrush.</summary>
	// https://learn.microsoft.com/en-us/windows/win32/api/d2d1_1/ns-d2d1_1-d2d1_bitmap_brush_properties1
	// typedef struct D2D1_BITMAP_BRUSH_PROPERTIES1 { D2D1_EXTEND_MODE extendModeX; D2D1_EXTEND_MODE extendModeY; D2D1_INTERPOLATION_MODE interpolationMode; } D2D1_BITMAP_BRUSH_PROPERTIES1;
	[PInvokeData("d2d1_1.h", MSDNShortId = "NS:d2d1_1.D2D1_BITMAP_BRUSH_PROPERTIES1")]
	[StructLayout(LayoutKind.Sequential)]
	public struct D2D1_BITMAP_BRUSH_PROPERTIES1
	{
		/// <summary>
		///   <para>Type: <c>D2D1_EXTEND_MODE</c></para>
		///   <para>A value that describes how the brush horizontally tiles those areas that extend past its bitmap.</para>
		/// </summary>
		public D2D1_EXTEND_MODE extendModeX;

		/// <summary>
		///   <para>Type: <c>D2D1_EXTEND_MODE</c></para>
		///   <para>A value that describes how the brush vertically tiles those areas that extend past its bitmap.</para>
		/// </summary>
		public D2D1_EXTEND_MODE extendModeY;

		/// <summary>
		///   <para>Type: <c>D2D1_INTERPOLATION_MODE</c></para>
		///   <para>A value that specifies how the bitmap is interpolated when it is scaled or rotated.</para>
		/// </summary>
		public D2D1_INTERPOLATION_MODE interpolationMode;
	}

	/// <summary>This structure allows a ID2D1Bitmap1 to be created with bitmap options and color context information available.</summary>
	/// <remarks>
	/// If both <c>dpiX</c> and <c>dpiY</c> are 0, the dpi of the bitmap will be set to the desktop dpi if the device context is a
	/// windowed context, or 96 dpi for any other device context.
	/// </remarks>
	// https://docs.microsoft.com/en-us/windows/win32/api/d2d1_1/ns-d2d1_1-d2d1_bitmap_properties1 typedef struct
	// D2D1_BITMAP_PROPERTIES1 { D2D1_PIXEL_FORMAT pixelFormat; FLOAT dpiX; FLOAT dpiY; D2D1_BITMAP_OPTIONS bitmapOptions;
	// ID2D1ColorContext *colorContext; } D2D1_BITMAP_PROPERTIES1;
	[PInvokeData("d2d1_1.h", MSDNShortId = "c9371ce3-f6fc-4fe6-ada6-0aa64a8f29a2")]
	[StructLayout(LayoutKind.Sequential)]
	public struct D2D1_BITMAP_PROPERTIES1
	{
		/// <summary>
		/// <para>Type: <c>D2D1_PIXEL_FORMAT</c></para>
		/// <para>The DXGI format and alpha mode to create the bitmap with.</para>
		/// </summary>
		public D2D1_PIXEL_FORMAT pixelFormat;

		/// <summary>
		/// <para>Type: <c>FLOAT</c></para>
		/// <para>The bitmap dpi in the x direction.</para>
		/// </summary>
		public float dpiX;

		/// <summary>
		/// <para>Type: <c>FLOAT</c></para>
		/// <para>The bitmap dpi in the y direction.</para>
		/// </summary>
		public float dpiY;

		/// <summary>
		/// <para>Type: <c>D2D1_BITMAP_OPTIONS</c></para>
		/// <para>The special creation options of the bitmap.</para>
		/// </summary>
		public D2D1_BITMAP_OPTIONS bitmapOptions;

		/// <summary>
		/// <para>Type: <c>ID2D1ColorContext*</c></para>
		/// <para>The optionally specified color context information.</para>
		/// </summary>
		public IntPtr colorContext;
	}

	/// <summary>Specifies the options with which the Direct2D device, factory, and device context are created.</summary>
	/// <remarks>The root objects referred to here are the Direct2D device, Direct2D factory and the Direct2D device context.</remarks>
	// https://docs.microsoft.com/en-us/windows/win32/api/d2d1_1/ns-d2d1_1-d2d1_creation_properties
	// typedef struct D2D1_CREATION_PROPERTIES { D2D1_THREADING_MODE threadingMode; D2D1_DEBUG_LEVEL debugLevel; D2D1_DEVICE_CONTEXT_OPTIONS options; } D2D1_CREATION_PROPERTIES;
	[PInvokeData("d2d1_1.h", MSDNShortId = "657439fe-dc17-42af-9e2c-2f3cb769a5a3")]
	[StructLayout(LayoutKind.Sequential)]
	public struct D2D1_CREATION_PROPERTIES
	{
		/// <summary>The threading mode with which the corresponding root objects will be created.</summary>
		public D2D1_THREADING_MODE threadingMode;

		/// <summary>The debug level that the root objects should be created with.</summary>
		public D2D1_DEBUG_LEVEL debugLevel;

		/// <summary>The device context options that the root objects should be created with.</summary>
		public D2D1_DEVICE_CONTEXT_OPTIONS options;
	}

	/// <summary>Describes the drawing state of a device context.</summary>
	// https://learn.microsoft.com/en-us/windows/win32/api/d2d1_1/ns-d2d1_1-d2d1_drawing_state_description1 typedef struct
	// D2D1_DRAWING_STATE_DESCRIPTION1 { D2D1_ANTIALIAS_MODE antialiasMode; D2D1_TEXT_ANTIALIAS_MODE textAntialiasMode; D2D1_TAG tag1;
	// D2D1_TAG tag2; D2D1_MATRIX_3X2_F transform; D2D1_PRIMITIVE_BLEND primitiveBlend; D2D1_UNIT_MODE unitMode; } D2D1_DRAWING_STATE_DESCRIPTION1;
	[PInvokeData("d2d1_1.h", MSDNShortId = "NS:d2d1_1.D2D1_DRAWING_STATE_DESCRIPTION1")]
	[StructLayout(LayoutKind.Sequential)]
	public struct D2D1_DRAWING_STATE_DESCRIPTION1
	{
		/// <summary>
		///   <para>Type: <c>D2D1_ANTIALIAS_MODE</c></para>
		///   <para>The antialiasing mode for subsequent nontext drawing operations.</para>
		/// </summary>
		public D2D1_ANTIALIAS_MODE antialiasMode;

		/// <summary>
		///   <para>Type: <c>D2D1_TEXT_ANTIALIAS_MODE</c></para>
		///   <para>The antialiasing mode for subsequent text and glyph drawing operations.</para>
		/// </summary>
		public D2D1_TEXT_ANTIALIAS_MODE textAntialiasMode;

		/// <summary>
		///   <para>Type: <c>D2D1_TAG</c></para>
		///   <para>A label for subsequent drawing operations.</para>
		/// </summary>
		public D2D1_TAG tag1;

		/// <summary>
		///   <para>Type: <c>D2D1_TAG</c></para>
		///   <para>A label for subsequent drawing operations.</para>
		/// </summary>
		public D2D1_TAG tag2;

		/// <summary>
		///   <para>Type: <c>D2D1_MATRIX_3X2_F</c></para>
		///   <para>The transformation to apply to subsequent drawing operations.</para>
		/// </summary>
		public D2D_MATRIX_3X2_F transform;

		/// <summary>
		///   <para>Type: <c>D2D1_PRIMITIVE_BLEND</c></para>
		///   <para>The blend mode for the device context to apply to subsequent drawing operations.</para>
		/// </summary>
		public D2D1_PRIMITIVE_BLEND primitiveBlend;

		/// <summary>
		///   <para>Type: <c>D2D1_UNIT_MODE</c></para>
		///   <para>D2D1_UNIT_MODE</para>
		/// </summary>
		public D2D1_UNIT_MODE unitMode;
	}

	/// <summary>Describes features of an effect.</summary>
	/// <remarks>
	/// <c>Note</c> The caller should not rely heavily on the input rectangles returned by this structure. They can change due to subtle
	/// changes in effect implementations and due to optimization changes in the effect rendering system.
	/// </remarks>
	// https://docs.microsoft.com/en-us/windows/win32/api/d2d1_1/ns-d2d1_1-d2d1_effect_input_description typedef struct
	// D2D1_EFFECT_INPUT_DESCRIPTION { ID2D1Effect *effect; UINT32 inputIndex; D2D1_RECT_F inputRectangle; } D2D1_EFFECT_INPUT_DESCRIPTION;
	[PInvokeData("d2d1_1.h", MSDNShortId = "2ce9405a-e36d-4b9e-b9d2-2a58b78696ac")]
	[StructLayout(LayoutKind.Sequential)]
	public struct D2D1_EFFECT_INPUT_DESCRIPTION
	{
		/// <summary/>
		public IntPtr effect;

		/// <summary>The input index of the effect that is being considered.</summary>
		public uint inputIndex;

		/// <summary>
		/// The amount of data that would be available on the input. This can be used to query this information when the data is not yet available.
		/// </summary>
		public D2D_RECT_F inputRectangle;
	}

	/// <summary>Represents a tensor patch with 16 control points, 4 corner colors, and boundary flags. An ID2D1GradientMesh is made up of 1 or more gradient mesh patches. Use the GradientMeshPatch function or the GradientMeshPatchFromCoonsPatch function to create one.</summary>
	/// <remarks>The following image shows the numbering of control points on a tensor grid.</remarks>
	// https://learn.microsoft.com/en-us/windows/win32/api/d2d1_3/ns-d2d1_3-d2d1_gradient_mesh_patch
	// typedef struct D2D1_GRADIENT_MESH_PATCH { D2D1_POINT_2F point00; D2D1_POINT_2F point01; D2D1_POINT_2F point02; D2D1_POINT_2F point03; D2D1_POINT_2F point10; D2D1_POINT_2F point11; D2D1_POINT_2F point12; D2D1_POINT_2F point13; D2D1_POINT_2F point20; D2D1_POINT_2F point21; D2D1_POINT_2F point22; D2D1_POINT_2F point23; D2D1_POINT_2F point30; D2D1_POINT_2F point31; D2D1_POINT_2F point32; D2D1_POINT_2F point33; D2D1_COLOR_F color00; D2D1_COLOR_F color03; D2D1_COLOR_F color30; D2D1_COLOR_F color33; D2D1_PATCH_EDGE_MODE topEdgeMode; D2D1_PATCH_EDGE_MODE leftEdgeMode; D2D1_PATCH_EDGE_MODE bottomEdgeMode; D2D1_PATCH_EDGE_MODE rightEdgeMode; } D2D1_GRADIENT_MESH_PATCH;
	[PInvokeData("d2d1_3.h", MSDNShortId = "NS:d2d1_3.D2D1_GRADIENT_MESH_PATCH")]
	[StructLayout(LayoutKind.Sequential)]
	public struct D2D1_GRADIENT_MESH_PATCH
	{
		/// <summary>The coordinate-space location of the control point in column 0 and row 0 of the tensor grid.</summary>
		public D2D1_POINT_2F point00;

		/// <summary>The coordinate-space location of the control point in column 0 and row 1 of the tensor grid.</summary>
		public D2D1_POINT_2F point01;

		/// <summary>The coordinate-space location of the control point in column 0 and row 2 of the tensor grid.</summary>
		public D2D1_POINT_2F point02;

		/// <summary>The coordinate-space location of the control point in column 0 and row 3 of the tensor grid.</summary>
		public D2D1_POINT_2F point03;

		/// <summary>The coordinate-space location of the control point in column 1 and row 0 of the tensor grid.</summary>
		public D2D1_POINT_2F point10;

		/// <summary>The coordinate-space location of the control point in column 1 and row 1 of the tensor grid.</summary>
		public D2D1_POINT_2F point11;

		/// <summary>The coordinate-space location of the control point in column 1 and row 2 of the tensor grid.</summary>
		public D2D1_POINT_2F point12;

		/// <summary>The coordinate-space location of the control point in column 1 and row 3 of the tensor grid.</summary>
		public D2D1_POINT_2F point13;

		/// <summary>The coordinate-space location of the control point in column 2 and row 0 of the tensor grid.</summary>
		public D2D1_POINT_2F point20;

		/// <summary>The coordinate-space location of the control point in column 2 and row 1 of the tensor grid.</summary>
		public D2D1_POINT_2F point21;

		/// <summary>The coordinate-space location of the control point in column 2 and row 2 of the tensor grid.</summary>
		public D2D1_POINT_2F point22;

		/// <summary>The coordinate-space location of the control point in column 2 and row 3 of the tensor grid.</summary>
		public D2D1_POINT_2F point23;

		/// <summary>The coordinate-space location of the control point in column 3 and row 0 of the tensor grid.</summary>
		public D2D1_POINT_2F point30;

		/// <summary>The coordinate-space location of the control point in column 3 and row 1 of the tensor grid.</summary>
		public D2D1_POINT_2F point31;

		/// <summary>The coordinate-space location of the control point in column 3 and row 2 of the tensor grid.</summary>
		public D2D1_POINT_2F point32;

		/// <summary>The coordinate-space location of the control point in column 3 and row 3 of the tensor grid.</summary>
		public D2D1_POINT_2F point33;

		/// <summary>The color associated with the control point in column 0 and row 0 of the tensor grid.</summary>
		public D2D1_COLOR_F color00;

		/// <summary>The color associated with the control point in column 0 and row 3 of the tensor grid.</summary>
		public D2D1_COLOR_F color03;

		/// <summary>The color associated with the control point in column 3 and row 0 of the tensor grid.</summary>
		public D2D1_COLOR_F color30;

		/// <summary>The color associated with the control point in column 3 and row 3 of the tensor grid.</summary>
		public D2D1_COLOR_F color33;

		/// <summary>Specifies how to render the top edge of the mesh.</summary>
		public D2D1_PATCH_EDGE_MODE topEdgeMode;

		/// <summary>Specifies how to render the left edge of the mesh.</summary>
		public D2D1_PATCH_EDGE_MODE leftEdgeMode;

		/// <summary>Specifies how to render the bottom edge of the mesh.</summary>
		public D2D1_PATCH_EDGE_MODE bottomEdgeMode;

		/// <summary>Specifies how to render the right edge of the mesh.</summary>
		public D2D1_PATCH_EDGE_MODE rightEdgeMode;
	}

	/// <summary>Describes image brush features.</summary>
	// https://docs.microsoft.com/en-us/windows/win32/api/d2d1_1/ns-d2d1_1-d2d1_image_brush_properties typedef struct
	// D2D1_IMAGE_BRUSH_PROPERTIES { D2D1_RECT_F sourceRectangle; D2D1_EXTEND_MODE extendModeX; D2D1_EXTEND_MODE extendModeY;
	// D2D1_INTERPOLATION_MODE interpolationMode; } D2D1_IMAGE_BRUSH_PROPERTIES;
	[PInvokeData("d2d1_1.h", MSDNShortId = "c7bcae4d-cdef-4bfc-aa5a-68b85497a7f6")]
	[StructLayout(LayoutKind.Sequential)]
	public struct D2D1_IMAGE_BRUSH_PROPERTIES
	{
		/// <summary>
		/// <para>Type: <c>D2D1_RECT_F</c></para>
		/// <para>The source rectangle in the image space from which the image will be tiled or interpolated.</para>
		/// </summary>
		public D2D_RECT_F sourceRectangle;

		/// <summary>
		/// <para>Type: <c>D2D1_EXTEND_MODE</c></para>
		/// <para>The extend mode in the image x-axis.</para>
		/// </summary>
		public D2D1_EXTEND_MODE extendModeX;

		/// <summary>
		/// <para>Type: <c>D2D1_EXTEND_MODE</c></para>
		/// <para>The extend mode in the image y-axis.</para>
		/// </summary>
		public D2D1_EXTEND_MODE extendModeY;

		/// <summary>
		/// <para>Type: <c>D2D1_INTERPOLATION_MODE</c></para>
		/// <para>The interpolation mode to use when scaling the image brush.</para>
		/// </summary>
		public D2D1_INTERPOLATION_MODE interpolationMode;
	}

	/// <summary>Represents a Bezier segment to be used in the creation of an ID2D1Ink object. This structure differs from D2D1_BEZIER_SEGMENT in that it is composed of D2D1_INK_POINTs, which contain a radius in addition to x- and y-coordinates.</summary>
	// https://learn.microsoft.com/en-us/windows/win32/api/d2d1_3/ns-d2d1_3-d2d1_ink_bezier_segment
	// typedef struct D2D1_INK_BEZIER_SEGMENT { D2D1_INK_POINT point1; D2D1_INK_POINT point2; D2D1_INK_POINT point3; } D2D1_INK_BEZIER_SEGMENT;
	[PInvokeData("d2d1_3.h", MSDNShortId = "NS:d2d1_3.D2D1_INK_BEZIER_SEGMENT")]
	[StructLayout(LayoutKind.Sequential)]
	public struct D2D1_INK_BEZIER_SEGMENT
	{
		/// <summary>The first control point for the Bezier segment.</summary>
		public D2D1_INK_POINT point1;

		/// <summary>The second control point for the Bezier segment.</summary>
		public D2D1_INK_POINT point2;

		/// <summary>The end point for the Bezier segment.</summary>
		public D2D1_INK_POINT point3;
	}

	/// <summary>Represents a point, radius pair that makes up part of a D2D1_INK_BEZIER_SEGMENT.</summary>
	// https://learn.microsoft.com/en-us/windows/win32/api/d2d1_3/ns-d2d1_3-d2d1_ink_point
	// typedef struct D2D1_INK_POINT { FLOAT x; FLOAT y; FLOAT radius; } D2D1_INK_POINT;
	[PInvokeData("d2d1_3.h", MSDNShortId = "NS:d2d1_3.D2D1_INK_POINT")]
	[StructLayout(LayoutKind.Sequential)]
	public struct D2D1_INK_POINT
	{
		/// <summary>The x-coordinate of the point.</summary>
		public float x;

		/// <summary>The y-coordinate of the point.</summary>
		public float y;

		/// <summary>The radius of this point. Corresponds to the width of the ink stroke at this point in the stroke.</summary>
		public float radius;
	}

	/// <summary>Defines the general pen tip shape and the transform used in an ID2D1InkStyle object.</summary>
	// https://learn.microsoft.com/en-us/windows/win32/api/d2d1_3/ns-d2d1_3-d2d1_ink_style_properties
	// typedef struct D2D1_INK_STYLE_PROPERTIES { D2D1_INK_NIB_SHAPE nibShape; D2D1_MATRIX_3X2_F nibTransform; } D2D1_INK_STYLE_PROPERTIES;
	[PInvokeData("d2d1_3.h", MSDNShortId = "NS:d2d1_3.D2D1_INK_STYLE_PROPERTIES")]
	[StructLayout(LayoutKind.Sequential)]
	public struct D2D1_INK_STYLE_PROPERTIES
	{
		/// <summary>The pre-transform shape of the nib (pen tip) used to draw a given ink object.</summary>
		public D2D1_INK_NIB_SHAPE nibShape;

		/// <summary>The transform applied to the nib. Note that the translation components of the transform matrix are ignored for the purposes of rendering.</summary>
		public D2D1_MATRIX_3X2_F nibTransform;
	}

	/// <summary>Contains the content bounds, mask information, opacity settings, and other options for a layer resource.</summary>
	// https://docs.microsoft.com/en-us/windows/win32/api/d2d1_1/ns-d2d1_1-d2d1_layer_parameters1 typedef struct D2D1_LAYER_PARAMETERS1
	// { D2D1_RECT_F contentBounds; ID2D1Geometry *geometricMask; D2D1_ANTIALIAS_MODE maskAntialiasMode; D2D1_MATRIX_3X2_F
	// maskTransform; FLOAT opacity; ID2D1Brush *opacityBrush; D2D1_LAYER_OPTIONS1 layerOptions; } D2D1_LAYER_PARAMETERS1;
	[PInvokeData("d2d1_1.h", MSDNShortId = "D7CC93F8-D871-4DFC-84A3-CA60EB52FF0A")]
	[StructLayout(LayoutKind.Sequential)]
	public struct D2D1_LAYER_PARAMETERS1
	{
		/// <summary>
		/// <para>Type: <c>D2D1_RECT_F</c></para>
		/// <para>The content bounds of the layer. Content outside these bounds is not guaranteed to render.</para>
		/// </summary>
		public D2D_RECT_F contentBounds;

		/// <summary>
		/// <para>Type: <c>ID2D1Geometry*</c></para>
		/// <para>The geometric mask specifies the area of the layer that is composited into the render target.</para>
		/// </summary>
		public IntPtr geometricMask;

		/// <summary>
		/// <para>Type: <c>D2D1_ANTIALIAS_MODE</c></para>
		/// <para>A value that specifies the antialiasing mode for the geometricMask.</para>
		/// </summary>
		public D2D1_ANTIALIAS_MODE maskAntialiasMode;

		/// <summary>
		/// <para>Type: <c>D2D1_MATRIX_3X2_F</c></para>
		/// <para>A value that specifies the transform that is applied to the geometric mask when composing the layer.</para>
		/// </summary>
		public D2D_MATRIX_3X2_F maskTransform;

		/// <summary>
		/// <para>Type: <c>FLOAT</c></para>
		/// <para>An opacity value that is applied uniformly to all resources in the layer when compositing to the target.</para>
		/// </summary>
		public float opacity;

		/// <summary>
		/// <para>Type: <c>ID2D1Brush*</c></para>
		/// <para>
		/// A brush that is used to modify the opacity of the layer. The brush is mapped to the layer, and the alpha channel of each
		/// mapped brush pixel is multiplied against the corresponding layer pixel.
		/// </para>
		/// </summary>
		public IntPtr opacityBrush;

		/// <summary>
		/// <para>Type: <c>D2D1_LAYER_OPTIONS1</c></para>
		/// <para>Additional options for the layer creation.</para>
		/// </summary>
		public D2D1_LAYER_OPTIONS1 layerOptions;
	}

	/// <summary>Describes mapped memory from the ID2D1Bitmap1::Map API.</summary>
	/// <remarks>The mapped rectangle is used to map a rectangle into the caller's address space.</remarks>
	// https://docs.microsoft.com/en-us/windows/win32/api/d2d1_1/ns-d2d1_1-d2d1_mapped_rect typedef struct D2D1_MAPPED_RECT { UINT32
	// pitch; BYTE *bits; } D2D1_MAPPED_RECT;
	[PInvokeData("d2d1_1.h", MSDNShortId = "1cd81f1a-c39b-4975-a801-aa9444dde172")]
	[StructLayout(LayoutKind.Sequential)]
	public struct D2D1_MAPPED_RECT
	{
		/// <summary>The size in bytes of an individual scanline in the bitmap.</summary>
		public uint pitch;

		/// <summary>The data inside the bitmap.</summary>
		public IntPtr bits;
	}

	/// <summary>Describes a point on a path geometry.</summary>
	// https://learn.microsoft.com/en-us/windows/win32/api/d2d1_1/ns-d2d1_1-d2d1_point_description
	// typedef struct D2D1_POINT_DESCRIPTION { D2D1_POINT_2F point; D2D1_POINT_2F unitTangentVector; UINT32 endSegment; UINT32 endFigure; FLOAT lengthToEndSegment; } D2D1_POINT_DESCRIPTION;
	[PInvokeData("d2d1_1.h", MSDNShortId = "NS:d2d1_1.D2D1_POINT_DESCRIPTION")]
	[StructLayout(LayoutKind.Sequential)]
	public struct D2D1_POINT_DESCRIPTION
	{
		/// <summary>The end point after walking the path.</summary>
		public D2D1_POINT_2F point;

		/// <summary>A unit vector indicating the tangent point.</summary>
		public D2D1_POINT_2F unitTangentVector;

		/// <summary>The index of the segment on which point resides. This index is global to the entire path, not just to a particular figure.</summary>
		public uint endSegment;

		/// <summary>The index of the figure on which point resides.</summary>
		public uint endFigure;

		/// <summary>The length of the section of the path stretching from the start of the path to the start of <c>endSegment</c>.</summary>
		public float lengthToEndSegment;
	}

	/// <summary>The creation properties for a ID2D1PrintControl object.</summary>
	// https://docs.microsoft.com/en-us/windows/win32/api/d2d1_1/ns-d2d1_1-d2d1_print_control_properties typedef struct
	// D2D1_PRINT_CONTROL_PROPERTIES { D2D1_PRINT_FONT_SUBSET_MODE fontSubset; FLOAT rasterDPI; D2D1_COLOR_SPACE colorSpace; } D2D1_PRINT_CONTROL_PROPERTIES;
	[PInvokeData("d2d1_1.h", MSDNShortId = "5A4D4DDC-4161-44A2-9EB6-E4C14696B810")]
	[StructLayout(LayoutKind.Sequential)]
	public struct D2D1_PRINT_CONTROL_PROPERTIES
	{
		/// <summary>
		/// <para>Type: <c>D2D1_PRINT_FONT_SUBSET_MODE</c></para>
		/// <para>The mode to use for subsetting fonts for printing, defaults to D2D1_PRINT_FONT_SUBSET_MODE_DEFAULT.</para>
		/// </summary>
		public D2D1_PRINT_FONT_SUBSET_MODE fontSubset;

		/// <summary>
		/// <para>Type: <c>FLOAT</c></para>
		/// <para>DPI for rasterization of all unsupported Direct2D commands or options, defaults to 150.0.</para>
		/// </summary>
		public float rasterDPI;

		/// <summary>
		/// <para>Type: <c>D2D1_COLOR_SPACE</c></para>
		/// <para>Color space for vector graphics, defaults to D2D1_COLOR_SPACE_SRGB.</para>
		/// </summary>
		public D2D1_COLOR_SPACE colorSpace;
	}

	/// <summary>Describes limitations to be applied to an imaging effect renderer.</summary>
	/// <remarks>
	/// <para>
	/// The renderer can allocate tiles larger than the minimum tile allocation. The allocated tiles will be powers of two of the
	/// minimum size on each axis, except that the size on each axis will not exceed the guaranteed maximum texture size for the device
	/// feature level.
	/// </para>
	/// <para>
	/// The "minimum pixel render extent" is the size of the square tile below which the renderer will expand the tile allocation rather
	/// than attempting to subdivide the rendering tile any further. When this threshold is reached, the allocation tile size is
	/// expanded. This might occur repeatedly until either rendering can proceed, or it is determined that the graph can't be rendered.
	/// </para>
	/// <para>
	/// The buffer precision is used for intermediate buffers if it is otherwise unspecified by the effects (for example, through
	/// calling SetValue on the effect with the D2D1_PROPERTY_PRECISION property) or the internal effect topology if required. If the
	/// buffer type on the context is D2D1_BUFFER_PRECISION_UNKNOWN, and otherwise not specified by the effect or transform, then the
	/// precision of the output will be the maximum precision of the inputs to the transform. The buffer precision does not affect the
	/// number of channels used.
	/// </para>
	/// </remarks>
	// https://docs.microsoft.com/en-us/windows/win32/api/d2d1_1/ns-d2d1_1-d2d1_rendering_controls typedef struct
	// D2D1_RENDERING_CONTROLS { D2D1_BUFFER_PRECISION bufferPrecision; D2D1_SIZE_U tileSize; } D2D1_RENDERING_CONTROLS;
	[PInvokeData("d2d1_1.h", MSDNShortId = "e563cbb0-2ee0-43d8-978c-0bde1950a926")]
	[StructLayout(LayoutKind.Sequential)]
	public struct D2D1_RENDERING_CONTROLS
	{
		/// <summary>
		/// The buffer precision used by default if the buffer precision is not otherwise specified by the effect or by the transform.
		/// </summary>
		public D2D1_BUFFER_PRECISION bufferPrecision;

		/// <summary>The tile allocation size to be used by the imaging effect renderer.</summary>
		public D2D_SIZE_U tileSize;
	}

	/// <summary>Describes the memory used by image textures and shaders.</summary>
	/// <remarks>
	/// <para>The processing texture area memory will take the width and height of all of the textures allocated for processing and multiply this by the number of channels and the bit depth per channel.</para>
	/// <para>The <c>cachingTextureArea</c> memory will take the width and height of all of the textures allocated for cache effects and multiply this by the number of channels and the bit depth per channel.</para>
	/// <para>The <c>shaderCacheMemory</c> will sum the number of bytes of pre-JITed shader code that has been loaded.</para>
	/// <para>None of these measures take into account:</para>
	/// <list type="bullet">
	/// <item>
	/// <description>Driver allocation boundaries or overhead.</description>
	/// </item>
	/// <item>
	/// <description>The cost of system memory structures used to track the video memory.</description>
	/// </item>
	/// <item>
	/// <description>The contraction or expansion caused by JITing shaders.</description>
	/// </item>
	/// </list>
	/// <para>This data is intended to be used by the application as a reference for when it should clear resources. It is not intended to be a precise profiling tool.</para>
	/// </remarks>
	// https://learn.microsoft.com/en-us/previous-versions/windows/desktop/legacy/hh404326(v=vs.85)
	// typedef struct D2D1_RESOURCE_USAGE { SIZE_T workingTextureAreaMemory; SIZE_T cachingTextureAreaMemory; SIZE_T shaderCacheMemory; } D2D1_RESOURCE_USAGE, *PD2D1_RESOURCE_USAGE;
	[PInvokeData("D2D1.h")]
	[StructLayout(LayoutKind.Sequential)]
	public struct D2D1_RESOURCE_USAGE
	{
		/// <summary>
		///   <c>workingTextureAreaMemory</c> An approximate amount of memory usage by image pipeline processing textures.</summary>
		public SizeT workingTextureAreaMemory;

		/// <summary>
		///   <c>cachingTextureAreaMemory</c> The approximate amount of memory used by the cached effect.</summary>
		public SizeT cachingTextureAreaMemory;

		/// <summary>
		///   <c>shaderCacheMemory</c> The approximate amount of memory used by cached shaders.</summary>
		public SizeT shaderCacheMemory;
	}

	/// <summary>Simple description of a color space.</summary>
	// https://learn.microsoft.com/en-us/windows/win32/api/d2d1_3/ns-d2d1_3-d2d1_simple_color_profile
	// typedef struct D2D1_SIMPLE_COLOR_PROFILE { D2D1_POINT_2F redPrimary; D2D1_POINT_2F greenPrimary; D2D1_POINT_2F bluePrimary; D2D1_POINT_2F whitePointXZ; D2D1_GAMMA1 gamma; } D2D1_SIMPLE_COLOR_PROFILE;
	[PInvokeData("d2d1_3.h", MSDNShortId = "NS:d2d1_3.D2D1_SIMPLE_COLOR_PROFILE")]
	[StructLayout(LayoutKind.Sequential)]
	public struct D2D1_SIMPLE_COLOR_PROFILE
	{
		/// <summary>The xy coordinates of the red primary in the CIExyY color space.</summary>
		public D2D1_POINT_2F redPrimary;

		/// <summary>The xy coordinates of the green primary in the CIExyY color space.</summary>
		public D2D1_POINT_2F greenPrimary;

		/// <summary>The xy coordinates of the blue primary in the CIExyY color space.</summary>
		public D2D1_POINT_2F bluePrimary;

		/// <summary>The XZ tristimulus values for the whitepoint in the CIEXYZ color space, normalized to luminance (Y) of 1.</summary>
		public D2D1_POINT_2F whitePointXZ;

		/// <summary>The gamma encoding to use for this color space.</summary>
		public D2D1_GAMMA1 gamma;
	}
	/// <summary>Describes the stroke that outlines a shape.</summary>
	// https://learn.microsoft.com/en-us/windows/win32/api/d2d1_1/ns-d2d1_1-d2d1_stroke_style_properties1
	// typedef struct D2D1_STROKE_STYLE_PROPERTIES1 { D2D1_CAP_STYLE startCap; D2D1_CAP_STYLE endCap; D2D1_CAP_STYLE dashCap; D2D1_LINE_JOIN lineJoin; FLOAT miterLimit; D2D1_DASH_STYLE dashStyle; FLOAT dashOffset; D2D1_STROKE_TRANSFORM_TYPE transformType; } D2D1_STROKE_STYLE_PROPERTIES1;
	[PInvokeData("d2d1_1.h", MSDNShortId = "NS:d2d1_1.D2D1_STROKE_STYLE_PROPERTIES1")]
	[StructLayout(LayoutKind.Sequential)]
	public struct D2D1_STROKE_STYLE_PROPERTIES1
	{
		/// <summary>
		///   <para>Type: <c>D2D1_CAP_STYLE</c></para>
		///   <para>The cap to use at the start of each open figure.</para>
		/// </summary>
		public D2D1_CAP_STYLE startCap;

		/// <summary>
		///   <para>Type: <c>D2D1_CAP_STYLE</c></para>
		///   <para>The cap to use at the end of each open figure.</para>
		/// </summary>
		public D2D1_CAP_STYLE endCap;

		/// <summary>
		///   <para>Type: <c>D2D1_CAP_STYLE</c></para>
		///   <para>The cap to use at the start and end of each dash.</para>
		/// </summary>
		public D2D1_CAP_STYLE dashCap;

		/// <summary>
		///   <para>Type: <c>D2D1_LINE_JOIN</c></para>
		///   <para>The line join to use.</para>
		/// </summary>
		public D2D1_LINE_JOIN lineJoin;

		/// <summary>
		///   <para>Type: <c>FLOAT</c></para>
		///   <para>The limit beyond which miters are either clamped or converted to bevels.</para>
		/// </summary>
		public float miterLimit;

		/// <summary>
		///   <para>Type: <c>D2D1_DASH_STYLE</c></para>
		///   <para>The type of dash to use.</para>
		/// </summary>
		public D2D1_DASH_STYLE dashStyle;

		/// <summary>
		///   <para>Type: <c>FLOAT</c></para>
		///   <para>The location of the first dash, relative to the start of the figure.</para>
		/// </summary>
		public float dashOffset;

		/// <summary>
		///   <para>Type: <c>D2D1_STROKE_TRANSFORM_TYPE</c></para>
		///   <para>The rule that determines what render target properties affect the nib of the stroke.</para>
		/// </summary>
		public D2D1_STROKE_TRANSFORM_TYPE transformType;
	}

	/// <summary>Properties of a transformed image source.</summary>
	// https://learn.microsoft.com/en-us/windows/win32/api/d2d1_3/ns-d2d1_3-d2d1_transformed_image_source_properties
	// typedef struct D2D1_TRANSFORMED_IMAGE_SOURCE_PROPERTIES { D2D1_ORIENTATION orientation; FLOAT scaleX; FLOAT scaleY; D2D1_INTERPOLATION_MODE interpolationMode; D2D1_TRANSFORMED_IMAGE_SOURCE_OPTIONS options; } D2D1_TRANSFORMED_IMAGE_SOURCE_PROPERTIES;
	[PInvokeData("d2d1_3.h", MSDNShortId = "NS:d2d1_3.D2D1_TRANSFORMED_IMAGE_SOURCE_PROPERTIES")]
	[StructLayout(LayoutKind.Sequential)]
	public struct D2D1_TRANSFORMED_IMAGE_SOURCE_PROPERTIES
	{
		/// <summary>
		///   <para>Type: <c>D2D1_ORIENTATION</c></para>
		///   <para>The orientation at which the image source is drawn.</para>
		/// </summary>
		public D2D1_ORIENTATION orientation;

		/// <summary>
		///   <para>Type: <c>FLOAT</c></para>
		///   <para>The horizontal scale factor at which the image source is drawn.</para>
		/// </summary>
		public float scaleX;

		/// <summary>
		///   <para>Type: <c>FLOAT</c></para>
		///   <para>The vertical scale factor at which the image source is drawn.</para>
		/// </summary>
		public float scaleY;

		/// <summary>
		///   <para>Type: <c>D2D1_INTERPOLATION_MODE</c></para>
		///   <para>The interpolation mode used when the image source is drawn. This is ignored if the image source is drawn using the DrawImage method, or using an image brush.</para>
		/// </summary>
		public D2D1_INTERPOLATION_MODE interpolationMode;

		/// <summary>
		///   <para>Type: <c>D2D1_TRANSFORMED_IMAGE_SOURCE_OPTIONS</c></para>
		///   <para>Image source option flags.</para>
		/// </summary>
		public D2D1_TRANSFORMED_IMAGE_SOURCE_OPTIONS options;
	}

	/// <summary>Computes the maximum factor by which a given transform can stretch any vector.</summary>
	/// <param name="matrix">The input transform matrix.</param>
	/// <returns>The scale factor.</returns>
	/// <remarks>
	/// <para>
	/// Formally, if M is the input matrix, this method will return the maximum value of |V * M| / |V| for all vectors V, where |.|
	/// denotes length.
	/// </para>
	/// <para>
	/// <c>Note</c> Since this describes how M affects vectors (rather than points), the translation components (_31 and _32) of M are ignored.
	/// </para>
	/// </remarks>
	// https://docs.microsoft.com/en-us/windows/win32/api/d2d1_2/nf-d2d1_2-d2d1computemaximumscalefactor FLOAT
	// D2D1ComputeMaximumScaleFactor( const D2D1_MATRIX_3X2_F *matrix );
	[DllImport(Lib.D2d1, SetLastError = false, ExactSpelling = true)]
	[PInvokeData("d2d1_2.h", MSDNShortId = "5BC10305-436F-4528-9647-E70713130505")]
	public static extern float D2D1ComputeMaximumScaleFactor(in D2D_MATRIX_3X2_F matrix);

	/// <summary>Converts the given color from one colorspace to another.</summary>
	/// <param name="sourceColorSpace">
	/// <para>Type: <c>D2D1_COLOR_SPACE</c></para>
	/// <para>The source color space.</para>
	/// </param>
	/// <param name="destinationColorSpace">
	/// <para>Type: <c>D2D1_COLOR_SPACE</c></para>
	/// <para>The destination color space.</para>
	/// </param>
	/// <param name="color">
	/// <para>Type: <c>const D2D1_COLOR_F*</c></para>
	/// <para>The source color.</para>
	/// </param>
	/// <returns>
	/// <para>Type: <c>D2D1_COLOR_F</c></para>
	/// <para>The converted color.</para>
	/// </returns>
	// https://docs.microsoft.com/en-us/windows/win32/api/d2d1_1/nf-d2d1_1-d2d1convertcolorspace D2D1_COLOR_F D2D1ConvertColorSpace(
	// D2D1_COLOR_SPACE sourceColorSpace, D2D1_COLOR_SPACE destinationColorSpace, const D2D1_COLOR_F *color );
	[DllImport(Lib.D2d1, SetLastError = false, ExactSpelling = true)]
	[PInvokeData("d2d1_1.h", MSDNShortId = "ECFE9F50-290D-4E6C-90AB-A46B9E413A48")]
	public static extern D3DCOLORVALUE D2D1ConvertColorSpace(D2D1_COLOR_SPACE sourceColorSpace, D2D1_COLOR_SPACE destinationColorSpace, in D3DCOLORVALUE color);

	/// <summary>Creates a new Direct2D device associated with the provided DXGI device.</summary>
	/// <param name="dxgiDevice">The DXGI device the Direct2D device is associated with.</param>
	/// <param name="creationProperties">The properties to apply to the Direct2D device.</param>
	/// <param name="d2dDevice">When this function returns, contains the address of a pointer to a Direct2D device.</param>
	/// <returns>
	/// <para>The function returns an <c>HRESULT</c>. Possible values include, but are not limited to, those in the following table.</para>
	/// <list type="table">
	/// <listheader>
	/// <term>HRESULT</term>
	/// <term>Description</term>
	/// </listheader>
	/// <item>
	/// <term>S_OK</term>
	/// <term>No error occurred.</term>
	/// </item>
	/// <item>
	/// <term>E_OUTOFMEMORY</term>
	/// <term>Direct2D could not allocate sufficient memory to complete the call.</term>
	/// </item>
	/// <item>
	/// <term>E_INVALIDARG</term>
	/// <term>An invalid value was passed to the method.</term>
	/// </item>
	/// </list>
	/// </returns>
	/// <remarks>
	/// <para>This function will also create a new ID2D1Factory1 that can be retrieved through ID2D1Resource::GetFactory.</para>
	/// <para>
	/// If the creation properties are not specified, then d2dDevice will inherit its threading mode from dxgiDevice and debug tracing
	/// will not be enabled.
	/// </para>
	/// </remarks>
	// https://docs.microsoft.com/en-us/windows/win32/api/d2d1_1/nf-d2d1_1-d2d1createdevice HRESULT D2D1CreateDevice( IDXGIDevice
	// *dxgiDevice, const D2D1_CREATION_PROPERTIES *creationProperties, ID2D1Device **d2dDevice );
	[DllImport(Lib.D2d1, SetLastError = false, ExactSpelling = true)]
	[PInvokeData("d2d1_1.h", MSDNShortId = "5ed3ec21-b609-41b6-9568-6ede460bc395")]
	public static extern HRESULT D2D1CreateDevice(IDXGIDevice dxgiDevice, in D2D1_CREATION_PROPERTIES creationProperties, out ID2D1Device d2dDevice);

	/// <summary>Creates a new Direct2D device context associated with a DXGI surface.</summary>
	/// <param name="dxgiSurface">The DXGI surface the Direct2D device context is associated with.</param>
	/// <param name="creationProperties">The properties to apply to the Direct2D device context.</param>
	/// <param name="d2dDeviceContext">When this function returns, contains the address of a pointer to a Direct2D device context.</param>
	/// <returns>
	/// <para>The function returns an <c>HRESULT</c>. Possible values include, but are not limited to, those in the following table.</para>
	/// <list type="table">
	/// <listheader>
	/// <term>HRESULT</term>
	/// <term>Description</term>
	/// </listheader>
	/// <item>
	/// <term>S_OK</term>
	/// <term>No error occurred.</term>
	/// </item>
	/// <item>
	/// <term>E_OUTOFMEMORY</term>
	/// <term>Direct2D could not allocate sufficient memory to complete the call.</term>
	/// </item>
	/// <item>
	/// <term>E_INVALIDARG</term>
	/// <term>An invalid value was passed to the method.</term>
	/// </item>
	/// </list>
	/// </returns>
	/// <remarks>
	/// <para>This function will also create a new ID2D1Factory1 that can be retrieved through ID2D1Resource::GetFactory.</para>
	/// <para>This function will also create a new ID2D1Device that can be retrieved through ID2D1DeviceContext::GetDevice.</para>
	/// <para>The DXGI device will be specified implicitly through dxgiSurface.</para>
	/// <para>
	/// If creationProperties are not specified, the Direct2D device will inherit its threading mode from the DXGI device implied by
	/// dxgiSurface and debug tracing will not be enabled.
	/// </para>
	/// </remarks>
	// https://docs.microsoft.com/en-us/windows/win32/api/d2d1_1/nf-d2d1_1-d2d1createdevicecontext HRESULT D2D1CreateDeviceContext(
	// IDXGISurface *dxgiSurface, const D2D1_CREATION_PROPERTIES *creationProperties, ID2D1DeviceContext **d2dDeviceContext );
	[DllImport(Lib.D2d1, SetLastError = false, ExactSpelling = true)]
	[PInvokeData("d2d1_1.h", MSDNShortId = "0e56d057-20a5-47b7-aec9-63c8e31f349b")]
	public static extern HRESULT D2D1CreateDeviceContext(IDXGISurface dxgiSurface, in D2D1_CREATION_PROPERTIES creationProperties, out ID2D1DeviceContext d2dDeviceContext);

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
	// D2D1_POINT_2F *pPoint11, D2D1_POINT_2F *pTensorPoint11, D2D1_POINT_2F *pTensorPoint12, D2D1_POINT_2F *pTensorPoint21,
	// D2D1_POINT_2F *pTensorPoint22 );
	[DllImport(Lib.D2d1, SetLastError = false, ExactSpelling = true)]
	[PInvokeData("d2d1_3.h", MSDNShortId = "388d5cbf-cb15-f0c9-3f3b-897f68519a4c")]
	public static extern void D2D1GetGradientMeshInteriorPointsFromCoonsPatch(in D2D_POINT_2F pPoint0, in D2D_POINT_2F pPoint1, in D2D_POINT_2F pPoint2, in D2D_POINT_2F pPoint3,
		in D2D_POINT_2F pPoint4, in D2D_POINT_2F pPoint5, in D2D_POINT_2F pPoint6, in D2D_POINT_2F pPoint7, in D2D_POINT_2F pPoint8, in D2D_POINT_2F pPoint9,
		in D2D_POINT_2F pPoint10, in D2D_POINT_2F pPoint11, out D2D_POINT_2F pTensorPoint11, out D2D_POINT_2F pTensorPoint12, out D2D_POINT_2F pTensorPoint21, out D2D_POINT_2F pTensorPoint22);

	/// <summary>Returns the sine and cosine of an angle.</summary>
	/// <param name="angle">
	/// <para>Type: <c>FLOAT</c></para>
	/// <para>The angle to calculate.</para>
	/// </param>
	/// <param name="s">
	/// <para>Type: <c>FLOAT*</c></para>
	/// <para>The sine of the angle.</para>
	/// </param>
	/// <param name="c">
	/// <para>Type: <c>FLOAT*</c></para>
	/// <para>The cosine of the angle.</para>
	/// </param>
	/// <returns>None</returns>
	// https://docs.microsoft.com/en-us/windows/win32/api/d2d1_1/nf-d2d1_1-d2d1sincos void D2D1SinCos( FLOAT angle, FLOAT *s, FLOAT *c );
	[DllImport(Lib.D2d1, SetLastError = false, ExactSpelling = true)]
	[PInvokeData("d2d1_1.h", MSDNShortId = "CE5899A8-B70F-492E-9A16-849FB64830AC")]
	public static extern void D2D1SinCos(float angle, out float s, out float c);

	/// <summary>Returns the tangent of an angle.</summary>
	/// <param name="angle">
	/// <para>Type: <c>FLOAT</c></para>
	/// <para>The angle to calculate the tangent for.</para>
	/// </param>
	/// <returns>
	/// <para>Type: <c>FLOAT</c></para>
	/// <para>The tangent of the angle.</para>
	/// </returns>
	// https://docs.microsoft.com/en-us/windows/win32/api/d2d1_1/nf-d2d1_1-d2d1tan FLOAT D2D1Tan( FLOAT angle );
	[DllImport(Lib.D2d1, SetLastError = false, ExactSpelling = true)]
	[PInvokeData("d2d1_1.h", MSDNShortId = "2BC66DEA-5C40-4EBA-8CDB-B48036E8A85F")]
	public static extern float D2D1Tan(float angle);

	/// <summary>Returns the length of a 3 dimensional vector.</summary>
	/// <param name="x">
	/// <para>Type: <c>FLOAT</c></para>
	/// <para>The x value of the vector.</para>
	/// </param>
	/// <param name="y">
	/// <para>Type: <c>FLOAT</c></para>
	/// <para>The y value of the vector.</para>
	/// </param>
	/// <param name="z">
	/// <para>Type: <c>FLOAT</c></para>
	/// <para>The z value of the vector.</para>
	/// </param>
	/// <returns>
	/// <para>Type: <c>FLOAT</c></para>
	/// <para>The length of the vector.</para>
	/// </returns>
	// https://docs.microsoft.com/en-us/windows/win32/api/d2d1_1/nf-d2d1_1-d2d1vec3length FLOAT D2D1Vec3Length( FLOAT x, FLOAT y, FLOAT
	// z );
	[DllImport(Lib.D2d1, SetLastError = false, ExactSpelling = true)]
	[PInvokeData("d2d1_1.h", MSDNShortId = "0E305151-63EA-4865-B9C4-5F685D17FD5A")]
	public static extern float D2D1Vec3Length(float x, float y, float z);

	/*
	ID2D1DrawingStateBlock1
	ID2D1Factory1
	ID2D1Multithread
	ID2D1PathGeometry1
	ID2D1StrokeStyle1
	*/
}