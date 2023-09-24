using static Vanara.PInvoke.Dwrite;
using static Vanara.PInvoke.DXGI;

namespace Vanara.PInvoke;

// TODO: Move once D2d1 lib is done
/// <summary>Items from the D2d1.dll</summary>
public static partial class D2d1
{
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

		/// <summary/>
		D2D1_BITMAP_OPTIONS_FORCE_DWORD = 0xffffffff,
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

		/// <summary>
		/// Forces this enumeration to compile to 32 bits in size. Without this value, some compilers would allow this enumeration to
		/// compile to a size other than 32 bits.Do not use this value.
		/// </summary>
		D2D1_BUFFER_PRECISION_FORCE_DWORD = 0xffffffff,
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

		/// <summary/>
		D2D1_COLOR_INTERPOLATION_MODE_FORCE_DWORD = 0xffffffff,
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

		/// <summary/>
		D2D1_COMPOSITE_MODE_FORCE_DWORD = 0xffffffff,
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

		/// <summary/>
		D2D1_INTERPOLATION_MODE_FORCE_DWORD = 0xffffffff,
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

		/// <summary/>
		D2D1_LAYER_OPTIONS1_FORCE_DWORD = 0xffffffff,
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

		/// <summary/>
		D2D1_MAP_OPTIONS_FORCE_DWORD = 0xffffffff,
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

		/// <summary/>
		D2D1_PRIMITIVE_BLEND_FORCE_DWORD = 0xffffffff,
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

		/// <summary/>
		D2D1_PROPERTY_TYPE_FORCE_DWORD = 0xffffffff,
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

		/// <summary />
		D2D1_THREADING_MODE_FORCE_DWORD = 0xffffffff,
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

		/// <summary/>
		D2D1_UNIT_MODE_FORCE_DWORD = 0xffffffff,
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
		new void CopyFromMemory([In, Optional] IntPtr dstRect, [In]  IntPtr srcData, uint pitch);

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
		new void SetBitmap([In, Optional] ID2D1Bitmap bitmap);

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
		HRESULT SetTextRenderingParams([In, Optional] IDWriteRenderingParams textRenderingParams);

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
		HRESULT DrawLine(D2D_POINT_2F point0, D2D_POINT_2F point1, [In] ID2D1Brush brush, float strokeWidth, [In, Optional] ID2D1StrokeStyle strokeStyle);

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
		HRESULT DrawGeometry([In] ID2D1Geometry geometry, [In] ID2D1Brush brush, float strokeWidth, [In, Optional] ID2D1StrokeStyle strokeStyle);

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
		HRESULT DrawRectangle(in D2D_RECT_F rect, [In] ID2D1Brush brush, float strokeWidth, [In, Optional] ID2D1StrokeStyle strokeStyle);

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
		HRESULT FillGeometry([In] ID2D1Geometry geometry, [In] ID2D1Brush brush, [In, Optional] ID2D1Brush opacityBrush);

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
		HRESULT PushLayer(in D2D1_LAYER_PARAMETERS1 layerParameters1, [In, Optional] ID2D1Layer layer);

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
		void SetInput(uint index, [In, Optional] ID2D1Image input, [MarshalAs(UnmanagedType.Bool)] bool invalidate = true);

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
		void SetImage([In, Optional] ID2D1Image image);

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
}