namespace Vanara.PInvoke;

public static partial class D2d1
{
	/// <summary>Gets a property from an effect.</summary>
	/// <param name="effect">A pointer to the IUnknown interface for the effect on which the property will be retrieved.</param>
	/// <param name="data">A pointer to a variable that stores the data that this function retrieves on the property.</param>
	/// <param name="dataSize">The number of bytes in the property to retrieve.</param>
	/// <param name="actualSize">
	/// A optional pointer to a variable that stores the actual number of bytes retrieved on the property. If not used, set to <c>NULL</c>.
	/// </param>
	/// <returns>Returns S_OK if successful; otherwise, returns an <c>HRESULT</c> error code.</returns>
	/// <remarks>
	/// Supply a <c>PD2D1_PROPERTY_GET_FUNCTION</c> to the <c>getFunction</c> member of a D2D1_PROPERTY_BINDING structure to specify the
	/// function that Direct2D uses to get data for a property.
	/// </remarks>
	// https://learn.microsoft.com/en-us/windows/win32/api/d2d1effectauthor/nc-d2d1effectauthor-pd2d1_property_get_function
	// PD2D1_PROPERTY_GET_FUNCTION Pd2d1PropertyGetFunction; HRESULT Pd2d1PropertyGetFunction( [in] const IUnknown *effect, [out] BYTE
	// *data, UINT32 dataSize, [out, optional] UINT32 *actualSize ) {...}
	[PInvokeData("d2d1effectauthor.h", MSDNShortId = "NC:d2d1effectauthor.PD2D1_PROPERTY_GET_FUNCTION")]
	[UnmanagedFunctionPointer(CallingConvention.Winapi, SetLastError = false)]
	public delegate HRESULT PD2D1_PROPERTY_GET_FUNCTION([In, MarshalAs(UnmanagedType.IUnknown)] object effect,
		[Out] IntPtr data, uint dataSize, out uint actualSize);

	/// <summary>Sets a property on an effect.</summary>
	/// <param name="effect">A pointer to the IUnknown interface for the effect on which the property will be set.</param>
	/// <param name="data">A pointer to the data to be set on the property.</param>
	/// <param name="dataSize">The number of bytes in the property set by the function.</param>
	/// <returns>Returns S_OK if successful; otherwise, returns an <c>HRESULT</c> error code.</returns>
	/// <remarks>
	/// Supply a <c>PD2D1_PROPERTY_SET_FUNCTION</c> function pointer to the <c>setFunction</c> member of a D2D1_PROPERTY_BINDING structure
	/// to specify the function that Direct2D uses to set data for a property.
	/// </remarks>
	// https://learn.microsoft.com/en-us/windows/win32/api/d2d1effectauthor/nc-d2d1effectauthor-pd2d1_property_set_function
	// PD2D1_PROPERTY_SET_FUNCTION Pd2d1PropertySetFunction; HRESULT Pd2d1PropertySetFunction( [in] IUnknown *effect, [in] const BYTE *data,
	// UINT32 dataSize ) {...}
	[PInvokeData("d2d1effectauthor.h", MSDNShortId = "NC:d2d1effectauthor.PD2D1_PROPERTY_SET_FUNCTION")]
	[UnmanagedFunctionPointer(CallingConvention.Winapi, SetLastError = false)]
	public delegate HRESULT PD2D1_PROPERTY_SET_FUNCTION([In, MarshalAs(UnmanagedType.IUnknown)] object effect,
		[In] IntPtr data, uint dataSize);

	/// <summary>Specifies how one of the color sources is to be derived and optionally specifies a preblend operation on the color source.</summary>
	/// <remarks>This enumeration has the same numeric values as D3D10_BLEND.</remarks>
	// https://learn.microsoft.com/en-us/windows/win32/api/d2d1effectauthor/ne-d2d1effectauthor-d2d1_blend typedef enum D2D1_BLEND {
	// D2D1_BLEND_ZERO = 1, D2D1_BLEND_ONE = 2, D2D1_BLEND_SRC_COLOR = 3, D2D1_BLEND_INV_SRC_COLOR = 4, D2D1_BLEND_SRC_ALPHA = 5,
	// D2D1_BLEND_INV_SRC_ALPHA = 6, D2D1_BLEND_DEST_ALPHA = 7, D2D1_BLEND_INV_DEST_ALPHA = 8, D2D1_BLEND_DEST_COLOR = 9,
	// D2D1_BLEND_INV_DEST_COLOR = 10, D2D1_BLEND_SRC_ALPHA_SAT = 11, D2D1_BLEND_BLEND_FACTOR = 14, D2D1_BLEND_INV_BLEND_FACTOR = 15,
	// D2D1_BLEND_FORCE_DWORD = 0xffffffff } ;
	[PInvokeData("d2d1effectauthor.h", MSDNShortId = "NE:d2d1effectauthor.D2D1_BLEND")]
	public enum D2D1_BLEND : uint
	{
		/// <summary>
		/// <para>Value:</para>
		/// <para>1</para>
		/// <para>The data source is black (0, 0, 0, 0). There is no preblend operation.</para>
		/// </summary>
		D2D1_BLEND_ZERO = 1,

		/// <summary>
		/// <para>Value:</para>
		/// <para>2</para>
		/// <para>The data source is white (1, 1, 1, 1). There is no preblend operation.</para>
		/// </summary>
		D2D1_BLEND_ONE,

		/// <summary>
		/// <para>Value:</para>
		/// <para>3</para>
		/// <para>The data source is color data (RGB) from the second input of the blend transform. There is not a preblend operation.</para>
		/// </summary>
		D2D1_BLEND_SRC_COLOR,

		/// <summary>
		/// <para>Value:</para>
		/// <para>4</para>
		/// <para>
		/// The data source is color data (RGB) from second input of the blend transform. The preblend operation inverts the data,
		/// generating 1 - RGB.
		/// </para>
		/// </summary>
		D2D1_BLEND_INV_SRC_COLOR,

		/// <summary>
		/// <para>Value:</para>
		/// <para>5</para>
		/// <para>The data source is alpha data (A) from second input of the blend transform. There is no preblend operation.</para>
		/// </summary>
		D2D1_BLEND_SRC_ALPHA,

		/// <summary>
		/// <para>Value:</para>
		/// <para>6</para>
		/// <para>
		/// The data source is alpha data (A) from the second input of the blend transform. The preblend operation inverts the data,
		/// generating 1 - A.
		/// </para>
		/// </summary>
		D2D1_BLEND_INV_SRC_ALPHA,

		/// <summary>
		/// <para>Value:</para>
		/// <para>7</para>
		/// <para>The data source is alpha data (A) from the first input of the blend transform. There is no preblend operation.</para>
		/// </summary>
		D2D1_BLEND_DEST_ALPHA,

		/// <summary>
		/// <para>Value:</para>
		/// <para>8</para>
		/// <para>
		/// The data source is alpha data (A) from the first input of the blend transform. The preblend operation inverts the data,
		/// generating 1 - A.
		/// </para>
		/// </summary>
		D2D1_BLEND_INV_DEST_ALPHA,

		/// <summary>
		/// <para>Value:</para>
		/// <para>9</para>
		/// <para>The data source is color data from the first input of the blend transform. There is no preblend operation.</para>
		/// </summary>
		D2D1_BLEND_DEST_COLOR,

		/// <summary>
		/// <para>Value:</para>
		/// <para>10</para>
		/// <para>
		/// The data source is color data from the first input of the blend transform. The preblend operation inverts the data, generating 1
		/// - RGB.
		/// </para>
		/// </summary>
		D2D1_BLEND_INV_DEST_COLOR,

		/// <summary>
		/// <para>Value:</para>
		/// <para>11</para>
		/// <para>
		/// The data source is alpha data from the second input of the blend transform. The preblend operation clamps the data to 1 or less.
		/// </para>
		/// </summary>
		D2D1_BLEND_SRC_ALPHA_SAT,

		/// <summary>
		/// <para>Value:</para>
		/// <para>14</para>
		/// <para>The data source is the blend factor. There is no preblend operation.</para>
		/// </summary>
		D2D1_BLEND_BLEND_FACTOR,

		/// <summary>
		/// <para>Value:</para>
		/// <para>15</para>
		/// <para>The data source is the blend factor. The preblend operation inverts the blend factor, generating 1 - blend_factor.</para>
		/// </summary>
		D2D1_BLEND_INV_BLEND_FACTOR,
	}

	/// <summary>Specifies the blend operation on two color sources.</summary>
	/// <remarks>This enumeration has the same numeric values as D3D10_BLEND_OP.</remarks>
	// https://learn.microsoft.com/en-us/windows/win32/api/d2d1effectauthor/ne-d2d1effectauthor-d2d1_blend_operation typedef enum
	// D2D1_BLEND_OPERATION { D2D1_BLEND_OPERATION_ADD = 1, D2D1_BLEND_OPERATION_SUBTRACT = 2, D2D1_BLEND_OPERATION_REV_SUBTRACT = 3,
	// D2D1_BLEND_OPERATION_MIN = 4, D2D1_BLEND_OPERATION_MAX = 5, D2D1_BLEND_OPERATION_FORCE_DWORD = 0xffffffff } ;
	[PInvokeData("d2d1effectauthor.h", MSDNShortId = "NE:d2d1effectauthor.D2D1_BLEND_OPERATION")]
	public enum D2D1_BLEND_OPERATION : uint
	{
		/// <summary>
		/// <para>Value:</para>
		/// <para>1</para>
		/// <para>Add source 1 and source 2.</para>
		/// </summary>
		D2D1_BLEND_OPERATION_ADD = 1,

		/// <summary>
		/// <para>Value:</para>
		/// <para>2</para>
		/// <para>Subtract source 1 from source 2.</para>
		/// </summary>
		D2D1_BLEND_OPERATION_SUBTRACT,

		/// <summary>
		/// <para>Value:</para>
		/// <para>3</para>
		/// <para>Subtract source 2 from source 1.</para>
		/// </summary>
		D2D1_BLEND_OPERATION_REV_SUBTRACT,

		/// <summary>
		/// <para>Value:</para>
		/// <para>4</para>
		/// <para>Find the minimum of source 1 and source 2.</para>
		/// </summary>
		D2D1_BLEND_OPERATION_MIN,

		/// <summary>
		/// <para>Value:</para>
		/// <para>5</para>
		/// <para>Find the maximum of source 1 and source 2.</para>
		/// </summary>
		D2D1_BLEND_OPERATION_MAX,
	}

	/// <summary>Allows a caller to control the channel depth of a stage in the rendering pipeline.</summary>
	// https://learn.microsoft.com/en-us/windows/win32/api/d2d1effectauthor/ne-d2d1effectauthor-d2d1_channel_depth typedef enum
	// D2D1_CHANNEL_DEPTH { D2D1_CHANNEL_DEPTH_DEFAULT = 0, D2D1_CHANNEL_DEPTH_1 = 1, D2D1_CHANNEL_DEPTH_4 = 4,
	// D2D1_CHANNEL_DEPTH_FORCE_DWORD = 0xffffffff } ;
	[PInvokeData("d2d1effectauthor.h", MSDNShortId = "NE:d2d1effectauthor.D2D1_CHANNEL_DEPTH")]
	public enum D2D1_CHANNEL_DEPTH : uint
	{
		/// <summary>
		/// <para>Value:</para>
		/// <para>0</para>
		/// <para>The channel depth is the default. It is inherited from the inputs.</para>
		/// </summary>
		D2D1_CHANNEL_DEPTH_DEFAULT,

		/// <summary>
		/// <para>Value:</para>
		/// <para>1</para>
		/// <para>The channel depth is 1.</para>
		/// </summary>
		D2D1_CHANNEL_DEPTH_1,

		/// <summary>
		/// <para>Value:</para>
		/// <para>4</para>
		/// <para>The channel depth is 4.</para>
		/// </summary>
		D2D1_CHANNEL_DEPTH_4 = 4,
	}

	/// <summary>Represents filtering modes that a transform may select to use on input textures.</summary>
	/// <remarks>This enumeration has the same numeric values as D3D11_FILTER.</remarks>
	// https://learn.microsoft.com/en-us/windows/win32/api/d2d1effectauthor/ne-d2d1effectauthor-d2d1_filter typedef enum D2D1_FILTER {
	// D2D1_FILTER_MIN_MAG_MIP_POINT = 0x00, D2D1_FILTER_MIN_MAG_POINT_MIP_LINEAR = 0x01, D2D1_FILTER_MIN_POINT_MAG_LINEAR_MIP_POINT = 0x04,
	// D2D1_FILTER_MIN_POINT_MAG_MIP_LINEAR = 0x05, D2D1_FILTER_MIN_LINEAR_MAG_MIP_POINT = 0x10, D2D1_FILTER_MIN_LINEAR_MAG_POINT_MIP_LINEAR
	// = 0x11, D2D1_FILTER_MIN_MAG_LINEAR_MIP_POINT = 0x14, D2D1_FILTER_MIN_MAG_MIP_LINEAR = 0x15, D2D1_FILTER_ANISOTROPIC = 0x55,
	// D2D1_FILTER_FORCE_DWORD = 0xffffffff } ;
	[PInvokeData("d2d1effectauthor.h", MSDNShortId = "NE:d2d1effectauthor.D2D1_FILTER")]
	public enum D2D1_FILTER : uint
	{
		/// <summary>
		/// <para>Value:</para>
		/// <para>0x00</para>
		/// <para>Use point sampling for minification, magnification, and mip-level sampling.</para>
		/// </summary>
		D2D1_FILTER_MIN_MAG_MIP_POINT,

		/// <summary>
		/// <para>Value:</para>
		/// <para>0x01</para>
		/// <para>Use point sampling for minification and magnification; use linear interpolation for mip-level sampling.</para>
		/// </summary>
		D2D1_FILTER_MIN_MAG_POINT_MIP_LINEAR,

		/// <summary>
		/// <para>Value:</para>
		/// <para>0x04</para>
		/// <para>Use point sampling for minification; use linear interpolation for magnification; use point sampling for mip-level sampling.</para>
		/// </summary>
		D2D1_FILTER_MIN_POINT_MAG_LINEAR_MIP_POINT = 4,

		/// <summary>
		/// <para>Value:</para>
		/// <para>0x05</para>
		/// <para>Use point sampling for minification; use linear interpolation for magnification and mip-level sampling.</para>
		/// </summary>
		D2D1_FILTER_MIN_POINT_MAG_MIP_LINEAR,

		/// <summary>
		/// <para>Value:</para>
		/// <para>0x10</para>
		/// <para>Use linear interpolation for minification; use point sampling for magnification and mip-level sampling.</para>
		/// </summary>
		D2D1_FILTER_MIN_LINEAR_MAG_MIP_POINT = 0x10,

		/// <summary>
		/// <para>Value:</para>
		/// <para>0x11</para>
		/// <para>
		/// Use linear interpolation for minification; use point sampling for magnification; use linear interpolation for mip-level sampling.
		/// </para>
		/// </summary>
		D2D1_FILTER_MIN_LINEAR_MAG_POINT_MIP_LINEAR,

		/// <summary>
		/// <para>Value:</para>
		/// <para>0x14</para>
		/// <para>Use linear interpolation for minification and magnification; use point sampling for mip-level sampling.</para>
		/// </summary>
		D2D1_FILTER_MIN_MAG_LINEAR_MIP_POINT = 0x14,

		/// <summary>
		/// <para>Value:</para>
		/// <para>0x15</para>
		/// <para>Use linear interpolation for minification, magnification, and mip-level sampling.</para>
		/// </summary>
		D2D1_FILTER_MIN_MAG_MIP_LINEAR,

		/// <summary>
		/// <para>Value:</para>
		/// <para>0x55</para>
		/// <para>Use anisotropic interpolation for minification, magnification, and mip-level sampling.</para>
		/// </summary>
		D2D1_FILTER_ANISOTROPIC = 0x55,
	}

	/// <summary>Indicates how pixel shader sampling will be restricted.</summary>
	/// <remarks>
	/// If the shader specifies <c>D2D1_PIXEL_OPTIONS_NONE</c>, it must still correctly implement the region of interest calculations in
	/// ID2D1Transform::MapOutputRectToInputRects and ID2D1Transform::MapInputRectsToOutputRect.
	/// </remarks>
	// https://learn.microsoft.com/en-us/windows/win32/api/d2d1effectauthor/ne-d2d1effectauthor-d2d1_pixel_options typedef enum
	// D2D1_PIXEL_OPTIONS { D2D1_PIXEL_OPTIONS_NONE = 0, D2D1_PIXEL_OPTIONS_TRIVIAL_SAMPLING = 1, D2D1_PIXEL_OPTIONS_FORCE_DWORD =
	// 0xffffffff } ;
	[PInvokeData("d2d1effectauthor.h", MSDNShortId = "NE:d2d1effectauthor.D2D1_PIXEL_OPTIONS")]
	public enum D2D1_PIXEL_OPTIONS
	{
		/// <summary>
		/// <para>Value:</para>
		/// <para>0</para>
		/// <para>The pixel shader is not restricted in its sampling.</para>
		/// </summary>
		D2D1_PIXEL_OPTIONS_NONE = 0,

		/// <summary>
		/// <para>Value:</para>
		/// <para>1</para>
		/// <para>
		/// The pixel shader samples inputs only at the same scene coordinate as the output pixel and returns transparent black whenever the
		/// input pixels are also transparent black.
		/// </para>
		/// </summary>
		D2D1_PIXEL_OPTIONS_TRIVIAL_SAMPLING,
	}

	/// <summary>Describes flags that influence how the renderer interacts with a custom vertex shader.</summary>
	// https://learn.microsoft.com/en-us/windows/win32/api/d2d1effectauthor/ne-d2d1effectauthor-d2d1_vertex_options typedef enum
	// D2D1_VERTEX_OPTIONS { D2D1_VERTEX_OPTIONS_NONE = 0, D2D1_VERTEX_OPTIONS_DO_NOT_CLEAR = 1, D2D1_VERTEX_OPTIONS_USE_DEPTH_BUFFER = 2,
	// D2D1_VERTEX_OPTIONS_ASSUME_NO_OVERLAP = 4, D2D1_VERTEX_OPTIONS_FORCE_DWORD = 0xffffffff } ;
	[PInvokeData("d2d1effectauthor.h", MSDNShortId = "NE:d2d1effectauthor.D2D1_VERTEX_OPTIONS")]
	public enum D2D1_VERTEX_OPTIONS
	{
		/// <summary>
		/// <para>Value:</para>
		/// <para>0</para>
		/// <para>The logical equivalent of having no flags set.</para>
		/// </summary>
		D2D1_VERTEX_OPTIONS_NONE = 0,

		/// <summary>
		/// <para>Value:</para>
		/// <para>1</para>
		/// <para>
		/// If this flag is set, the renderer assumes that the vertex shader will cover the entire region of interest with vertices and need
		/// not clear the destination render target. If this flag is not set, the renderer assumes that the vertices do not cover the entire
		/// region interest and must clear the render target to transparent black first.
		/// </para>
		/// </summary>
		D2D1_VERTEX_OPTIONS_DO_NOT_CLEAR,

		/// <summary>
		/// <para>Value:</para>
		/// <para>2</para>
		/// <para>
		/// The renderer will use a depth buffer when rendering custom vertices. The depth buffer will be used for calculating occlusion
		/// information. This can result in the renderer output being draw-order dependent if it contains transparency.
		/// </para>
		/// </summary>
		D2D1_VERTEX_OPTIONS_USE_DEPTH_BUFFER,

		/// <summary>
		/// <para>Value:</para>
		/// <para>4</para>
		/// <para>Indicates that custom vertices do not overlap each other.</para>
		/// </summary>
		D2D1_VERTEX_OPTIONS_ASSUME_NO_OVERLAP,
	}

	/// <summary>Indicates whether the vertex buffer changes infrequently or frequently.</summary>
	/// <remarks>
	/// If a dynamic vertex buffer is created, Direct2D will not necessarily map the buffer directly to a Direct3D vertex buffer. Instead, a
	/// system memory copy can be copied to the rendering engine vertex buffer as the effects are rendered.
	/// </remarks>
	// https://learn.microsoft.com/en-us/windows/win32/api/d2d1effectauthor/ne-d2d1effectauthor-d2d1_vertex_usage typedef enum
	// D2D1_VERTEX_USAGE { D2D1_VERTEX_USAGE_STATIC = 0, D2D1_VERTEX_USAGE_DYNAMIC = 1, D2D1_VERTEX_USAGE_FORCE_DWORD = 0xffffffff } ;
	[PInvokeData("d2d1effectauthor.h", MSDNShortId = "NE:d2d1effectauthor.D2D1_VERTEX_USAGE")]
	public enum D2D1_VERTEX_USAGE : uint
	{
		/// <summary>
		/// <para>Value:</para>
		/// <para>0</para>
		/// <para>The created vertex buffer is updated infrequently.</para>
		/// </summary>
		D2D1_VERTEX_USAGE_STATIC,

		/// <summary>
		/// <para>Value:</para>
		/// <para>1</para>
		/// <para>The created vertex buffer is changed frequently.</para>
		/// </summary>
		D2D1_VERTEX_USAGE_DYNAMIC,
	}

	/// <summary>Defines a blend description to be used in a particular blend transform.</summary>
	/// <remarks>
	/// This description closely matches the D3D11_BLEND_DESC struct with some omissions and the addition of the blend factor in the description.
	/// </remarks>
	// https://learn.microsoft.com/en-us/windows/win32/api/d2d1effectauthor/ns-d2d1effectauthor-d2d1_blend_description typedef struct
	// D2D1_BLEND_DESCRIPTION { D2D1_BLEND sourceBlend; D2D1_BLEND destinationBlend; D2D1_BLEND_OPERATION blendOperation; D2D1_BLEND
	// sourceBlendAlpha; D2D1_BLEND destinationBlendAlpha; D2D1_BLEND_OPERATION blendOperationAlpha; FLOAT blendFactor[4]; } D2D1_BLEND_DESCRIPTION;
	[PInvokeData("d2d1effectauthor.h", MSDNShortId = "NS:d2d1effectauthor.D2D1_BLEND_DESCRIPTION")]
	[StructLayout(LayoutKind.Sequential)]
	public struct D2D1_BLEND_DESCRIPTION
	{
		/// <summary>Specifies the first RGB data source and includes an optional preblend operation.</summary>
		public D2D1_BLEND sourceBlend;

		/// <summary>Specifies the second RGB data source and includes an optional preblend operation.</summary>
		public D2D1_BLEND destinationBlend;

		/// <summary>Specifies how to combine the RGB data sources.</summary>
		public D2D1_BLEND_OPERATION blendOperation;

		/// <summary>
		/// Specifies the first alpha data source and includes an optional preblend operation. Blend options that end in _COLOR are not allowed.
		/// </summary>
		public D2D1_BLEND sourceBlendAlpha;

		/// <summary>
		/// Specifies the second alpha data source and includes an optional preblend operation. Blend options that end in _COLOR are not allowed.
		/// </summary>
		public D2D1_BLEND destinationBlendAlpha;

		/// <summary>Specifies how to combine the alpha data sources.</summary>
		public D2D1_BLEND_OPERATION blendOperationAlpha;

		private unsafe fixed float _blendFactor[4];

		/// <summary>Parameters to the blend operations. The blend must use <c>D2D1_BLEND_BLEND_FACTOR</c> for this to be used.</summary>
		public float[] blendFactor
		{
			get { unsafe { fixed (float* p = _blendFactor) return [p[0], p[1], p[2], p[3]]; } }
			set { unsafe { fixed (float* p = _blendFactor) { p[0] = value[0]; p[1] = value[1]; p[2] = value[2]; p[3] = value[3]; } } }
		}
	}

	/// <summary>
	/// Defines a vertex shader and the input element description to define the input layout. The combination is used to allow a custom
	/// vertex effect to create a custom vertex shader and pass it a custom layout.
	/// </summary>
	/// <remarks>
	/// <para>The vertex shader will be loaded by the CreateVertexBuffer call that accepts the vertex buffer properties.</para>
	/// <para>This structure does not need to be specified if one of the standard vertex shaders is used.</para>
	/// </remarks>
	// https://learn.microsoft.com/en-us/windows/win32/api/d2d1effectauthor/ns-d2d1effectauthor-d2d1_custom_vertex_buffer_properties typedef
	// struct D2D1_CUSTOM_VERTEX_BUFFER_PROPERTIES { const BYTE *shaderBufferWithInputSignature; UINT32 shaderBufferSize; const
	// D2D1_INPUT_ELEMENT_DESC *inputElements; UINT32 elementCount; UINT32 stride; } D2D1_CUSTOM_VERTEX_BUFFER_PROPERTIES;
	[PInvokeData("d2d1effectauthor.h", MSDNShortId = "NS:d2d1effectauthor.D2D1_CUSTOM_VERTEX_BUFFER_PROPERTIES")]
	[StructLayout(LayoutKind.Sequential)]
	public struct D2D1_CUSTOM_VERTEX_BUFFER_PROPERTIES
	{
		/// <summary>A pointer to the buffer.</summary>
		public IntPtr shaderBufferWithInputSignature;

		/// <summary>The size of the buffer.</summary>
		public uint shaderBufferSize;

		/// <summary>An array of input assembler stage data types.</summary>
		public ArrayPointer<D2D1_INPUT_ELEMENT_DESC> inputElements;

		/// <summary>The number of input elements in the vertex shader.</summary>
		public uint elementCount;

		/// <summary>The vertex stride.</summary>
		public uint stride;
	}

	/// <summary>Describes compute shader support, which is an option on D3D10 feature level.</summary>
	/// <remarks>You can fill this structure by passing a D2D1_ FEATURE_DATA_D3D10_X_HARDWARE_OPTIONS structure to ID2D1EffectContext::CheckFeatureSupport.</remarks>
	// https://learn.microsoft.com/en-us/windows/win32/api/d2d1effectauthor/ns-d2d1effectauthor-d2d1_feature_data_d3d10_x_hardware_options
	// typedef struct D2D1_FEATURE_DATA_D3D10_X_HARDWARE_OPTIONS { BOOL computeShaders_Plus_RawAndStructuredBuffers_Via_Shader_4_x; } D2D1_FEATURE_DATA_D3D10_X_HARDWARE_OPTIONS;
	[PInvokeData("d2d1effectauthor.h", MSDNShortId = "NS:d2d1effectauthor.D2D1_FEATURE_DATA_D3D10_X_HARDWARE_OPTIONS")]
	[StructLayout(LayoutKind.Sequential)]
	public struct D2D1_FEATURE_DATA_D3D10_X_HARDWARE_OPTIONS
	{
		/// <summary>Shader model 4 compute shaders are supported.</summary>
		[MarshalAs(UnmanagedType.Bool)]
		public bool computeShaders_Plus_RawAndStructuredBuffers_Via_Shader_4_x;

		/// <summary>Performs an implicit conversion from <see cref="D2D1_FEATURE_DATA_D3D10_X_HARDWARE_OPTIONS"/> to <see cref="System.Boolean"/>.</summary>
		/// <param name="d">The d.</param>
		/// <returns>The result of the conversion.</returns>
		public static implicit operator bool(D2D1_FEATURE_DATA_D3D10_X_HARDWARE_OPTIONS d) => d.computeShaders_Plus_RawAndStructuredBuffers_Via_Shader_4_x;

		/// <summary>Performs an implicit conversion from <see cref="System.Boolean"/> to <see cref="D2D1_FEATURE_DATA_D3D10_X_HARDWARE_OPTIONS"/>.</summary>
		/// <param name="b">if set to <c>true</c> [b].</param>
		/// <returns>The result of the conversion.</returns>
		public static implicit operator D2D1_FEATURE_DATA_D3D10_X_HARDWARE_OPTIONS(bool b) => new() { computeShaders_Plus_RawAndStructuredBuffers_Via_Shader_4_x = b };
	}

	/// <summary>Describes the support for doubles in shaders.</summary>
	/// <remarks>Fill this structure by passing a D2D1_FEATURE_DOUBLES structure to ID2D1EffectContext::CheckFeatureSupport.</remarks>
	// https://learn.microsoft.com/en-us/windows/win32/api/d2d1effectauthor/ns-d2d1effectauthor-d2d1_feature_data_doubles typedef struct
	// D2D1_FEATURE_DATA_DOUBLES { BOOL doublePrecisionFloatShaderOps; } D2D1_FEATURE_DATA_DOUBLES;
	[PInvokeData("d2d1effectauthor.h", MSDNShortId = "NS:d2d1effectauthor.D2D1_FEATURE_DATA_DOUBLES")]
	[StructLayout(LayoutKind.Sequential)]
	public struct D2D1_FEATURE_DATA_DOUBLES
	{
		/// <summary>TRUE is doubles are supported within the shaders.</summary>
		[MarshalAs(UnmanagedType.Bool)]
		public bool doublePrecisionFloatShaderOps;

		/// <summary>Performs an implicit conversion from <see cref="D2D1_FEATURE_DATA_DOUBLES"/> to <see cref="System.Boolean"/>.</summary>
		/// <param name="d">The d.</param>
		/// <returns>The result of the conversion.</returns>
		public static implicit operator bool(D2D1_FEATURE_DATA_DOUBLES d) => d.doublePrecisionFloatShaderOps;

		/// <summary>Performs an implicit conversion from <see cref="System.Boolean"/> to <see cref="D2D1_FEATURE_DATA_DOUBLES"/>.</summary>
		/// <param name="b">if set to <c>true</c> [b].</param>
		/// <returns>The result of the conversion.</returns>
		public static implicit operator D2D1_FEATURE_DATA_DOUBLES(bool b) => new() { doublePrecisionFloatShaderOps = b };
	}

	/// <summary>Describes the options that transforms may set on input textures.</summary>
	// https://learn.microsoft.com/en-us/windows/win32/api/d2d1effectauthor/ns-d2d1effectauthor-d2d1_input_description typedef struct
	// D2D1_INPUT_DESCRIPTION { D2D1_FILTER filter; UINT32 levelOfDetailCount; } D2D1_INPUT_DESCRIPTION;
	[PInvokeData("d2d1effectauthor.h", MSDNShortId = "NS:d2d1effectauthor.D2D1_INPUT_DESCRIPTION")]
	[StructLayout(LayoutKind.Sequential)]
	public struct D2D1_INPUT_DESCRIPTION
	{
		/// <summary>The type of filter to apply to the input texture.</summary>
		public D2D1_FILTER filter;

		/// <summary>The mip level to retrieve from the upstream transform, if specified.</summary>
		public uint levelOfDetailCount;
	}

	/// <summary>A description of a single element to the vertex layout.</summary>
	/// <remarks>
	/// <para>This structure is a subset of D3D11_INPUT_ELEMENT_DESC that omits fields required to define a vertex layout.</para>
	/// <para>
	/// If the D2D1_APPEND_ALIGNED_ELEMENT constant is used for <c>alignedByteOffset</c>, the elements will be packed contiguously for convenience.
	/// </para>
	/// </remarks>
	// https://learn.microsoft.com/en-us/windows/win32/api/d2d1effectauthor/ns-d2d1effectauthor-d2d1_input_element_desc typedef struct
	// D2D1_INPUT_ELEMENT_DESC { PCSTR semanticName; UINT32 semanticIndex; DXGI_FORMAT format; UINT32 inputSlot; UINT32 alignedByteOffset; } D2D1_INPUT_ELEMENT_DESC;
	[PInvokeData("d2d1effectauthor.h", MSDNShortId = "NS:d2d1effectauthor.D2D1_INPUT_ELEMENT_DESC")]
	[StructLayout(LayoutKind.Sequential)]
	public struct D2D1_INPUT_ELEMENT_DESC
	{
		/// <summary>The HLSL semantic associated with this element in a shader input-signature.</summary>
		public StrPtrAnsi semanticName;

		/// <summary>
		/// The semantic index for the element. A semantic index modifies a semantic, with an integer index number. A semantic index is only
		/// needed in a case where there is more than one element with the same semantic. For example, a 4x4 matrix would have four
		/// components each with the semantic name matrix; however, each of the four components would have different semantic indices (0, 1,
		/// 2, and 3).
		/// </summary>
		public uint semanticIndex;

		/// <summary>The data type of the element data.</summary>
		public DXGI_FORMAT format;

		/// <summary>An integer value that identifies the input-assembler. Valid values are between 0 and 15.</summary>
		public uint inputSlot;

		/// <summary>The offset in bytes between each element.</summary>
		public uint alignedByteOffset;
	}

	/// <summary>Defines a property binding to a pair of functions which get and set the corresponding property.</summary>
	/// <remarks>
	/// <para>
	/// The <c>propertyName</c> is used to cross-correlate the property binding with the registration XML. The <c>propertyName</c> must be
	/// present in the XML call or the registration will fail.
	/// </para>
	/// <para>All properties must be bound.</para>
	/// </remarks>
	// https://learn.microsoft.com/en-us/windows/win32/api/d2d1effectauthor/ns-d2d1effectauthor-d2d1_property_binding typedef struct
	// D2D1_PROPERTY_BINDING { PCWSTR propertyName; PD2D1_PROPERTY_SET_FUNCTION setFunction; PD2D1_PROPERTY_GET_FUNCTION getFunction; } D2D1_PROPERTY_BINDING;
	[PInvokeData("d2d1effectauthor.h", MSDNShortId = "NS:d2d1effectauthor.D2D1_PROPERTY_BINDING")]
	[StructLayout(LayoutKind.Sequential)]
	public struct D2D1_PROPERTY_BINDING
	{
		/// <summary>The name of the property.</summary>
		[MarshalAs(UnmanagedType.LPWStr)]
		public string propertyName;

		/// <summary>The function that will receive the data to set.</summary>
		[MarshalAs(UnmanagedType.FunctionPtr)]
		public PD2D1_PROPERTY_SET_FUNCTION? setFunction;

		/// <summary>The function that will be asked to write the output data.</summary>
		[MarshalAs(UnmanagedType.FunctionPtr)]
		public PD2D1_PROPERTY_GET_FUNCTION? getFunction;
	}

	/// <summary>Defines a resource texture when the original resource texture is created.</summary>
	// https://learn.microsoft.com/en-us/windows/win32/api/d2d1effectauthor/ns-d2d1effectauthor-d2d1_resource_texture_properties typedef
	// struct D2D1_RESOURCE_TEXTURE_PROPERTIES { const UINT32 *extents; UINT32 dimensions; D2D1_BUFFER_PRECISION bufferPrecision;
	// D2D1_CHANNEL_DEPTH channelDepth; D2D1_FILTER filter; const D2D1_EXTEND_MODE *extendModes; } D2D1_RESOURCE_TEXTURE_PROPERTIES;
	[PInvokeData("d2d1effectauthor.h", MSDNShortId = "NS:d2d1effectauthor.D2D1_RESOURCE_TEXTURE_PROPERTIES")]
	[StructLayout(LayoutKind.Sequential)]
	public struct D2D1_RESOURCE_TEXTURE_PROPERTIES
	{
		/// <summary>The extents of the resource table in each dimension.</summary>
		public ArrayPointer<uint> extents;

		/// <summary>The number of dimensions in the resource texture. This must be a number from 1 to 3.</summary>
		public uint dimensions;

		/// <summary>The precision of the resource texture to create.</summary>
		public D2D1_BUFFER_PRECISION bufferPrecision;

		/// <summary>The number of channels in the resource texture.</summary>
		public D2D1_CHANNEL_DEPTH channelDepth;

		/// <summary>The filtering mode to use on the texture.</summary>
		public D2D1_FILTER filter;

		/// <summary>Specifies how pixel values beyond the extent of the texture will be sampled, in every dimension.</summary>
		public ArrayPointer<D2D1_EXTEND_MODE> extendModes;
	}

	/// <summary>Defines the properties of a vertex buffer that are standard for all vertex shader definitions.</summary>
	/// <remarks>
	/// <para>
	/// If <c>usage</c> is dynamic, the system might return a system memory buffer and copy these vertices into the rendering vertex buffer
	/// for each element.
	/// </para>
	/// <para>If the initialization data is not specified, the buffer will be uninitialized.</para>
	/// </remarks>
	// https://learn.microsoft.com/en-us/windows/win32/api/d2d1effectauthor/ns-d2d1effectauthor-d2d1_vertex_buffer_properties typedef struct
	// D2D1_VERTEX_BUFFER_PROPERTIES { UINT32 inputCount; D2D1_VERTEX_USAGE usage; const BYTE *data; UINT32 byteWidth; } D2D1_VERTEX_BUFFER_PROPERTIES;
	[PInvokeData("d2d1effectauthor.h", MSDNShortId = "NS:d2d1effectauthor.D2D1_VERTEX_BUFFER_PROPERTIES")]
	[StructLayout(LayoutKind.Sequential)]
	public struct D2D1_VERTEX_BUFFER_PROPERTIES
	{
		/// <summary>The number of inputs to the vertex shader.</summary>
		public uint inputCount;

		/// <summary>Indicates how frequently the vertex buffer is likely to be updated.</summary>
		public D2D1_VERTEX_USAGE usage;

		/// <summary>The initial contents of the vertex buffer.</summary>
		public IntPtr data;

		/// <summary>The size of the vertex buffer, in bytes.</summary>
		public uint byteWidth;
	}

	/// <summary>Defines a range of vertices that are used when rendering less than the full contents of a vertex buffer.</summary>
	// https://learn.microsoft.com/en-us/windows/win32/api/d2d1effectauthor/ns-d2d1effectauthor-d2d1_vertex_range typedef struct
	// D2D1_VERTEX_RANGE { UINT32 startVertex; UINT32 vertexCount; } D2D1_VERTEX_RANGE;
	[PInvokeData("d2d1effectauthor.h", MSDNShortId = "NS:d2d1effectauthor.D2D1_VERTEX_RANGE")]
	[StructLayout(LayoutKind.Sequential)]
	public struct D2D1_VERTEX_RANGE
	{
		/// <summary>The first vertex in the range to process.</summary>
		public uint startVertex;

		/// <summary>The number of vertices to use.</summary>
		public uint vertexCount;
	}
}